Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_CodAlternativo_Ver

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillAlternativos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            BtnAgregarCodAlternativos.ForeColor = Color.White
            BtnAgregarCodBarra.ForeColor = Color.White

        End If

    End Sub

    Private Sub Frm_CodAlternativo_Ver_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Sb_ActualizarGrilla()

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where Codigo = '" & TxtCodigo.Text.Trim & "' And Codigo_Nodo = 0 And Para_filtro = 0 And Nodo_origen = 0 And Clas_unica = 0 And Producto = 1"
        Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            Chk_Lect_Barras_IngrxCantidad.Checked = _Row.Item("Lect_Barras_IngrxCantidad")
        End If

        AddHandler GrillAlternativos.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler GrillAlternativos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Chk_Lect_Barras_IngrxCantidad.CheckedChanged, AddressOf Chk_Lect_Barras_IngrxCantidad_CheckedChanged
        AddHandler Chk_Lect_Barras_IngrxCantidad.CheckedChanging, AddressOf Chk_Lect_Barras_IngrxCantidad_CheckedChanging

    End Sub

    Sub Sb_ActualizarGrilla()

        Consulta_sql = "Select KOPRAL,NOKOPRAL,KOEN," & vbCrLf &
                       "ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN" & vbCrLf &
                       "WHERE KOEN = TABCODAL.KOEN),'Código de barras asociado') AS PROVEEDOR" & vbCrLf &
                       "FROM TABCODAL" & vbCrLf &
                       "WHERE KOPR = '" & TxtCodigo.Text & "'" & vbCrLf &
                       "Order By KOEN"

        Consulta_sql = "Select Td.KOPRAL,Td.NOKOPRAL,Td.KOEN," & vbCrLf &
                       "ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN" & vbCrLf &
                       "WHERE KOEN = Td.KOEN),'Código de barras asociado') AS PROVEEDOR,Isnull(Qr.CodigoQR,'') As CodigoQR," & vbCrLf &
                       "Cast(0 As bit) As QR" & vbCrLf &
                       "From TABCODAL Td" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Prod_CodQR Qr On Td.KOPRAL = Qr.Kopral" & vbCrLf &
                       "Where KOPR = '" & TxtCodigo.Text & "'" & vbCrLf &
                       "Order By KOEN"

        With GrillAlternativos

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            OcultarEncabezadoGrilla(GrillAlternativos, True)

            .Columns("KOPRAL").Width = 120
            .Columns("KOPRAL").HeaderText = "Código alternativo"
            .Columns("KOPRAL").Visible = True

            .Columns("KOEN").Width = 100
            .Columns("KOEN").HeaderText = "Proveedor"
            .Columns("KOEN").Visible = True

            .Columns("PROVEEDOR").Width = 360
            .Columns("PROVEEDOR").HeaderText = "Razón social"
            .Columns("PROVEEDOR").Visible = True

        End With

    End Sub

    Sub Sb_Eliminar_Linea()

        Dim _Fila As DataGridViewRow = GrillAlternativos.Rows(GrillAlternativos.CurrentRow.Index)

        Dim _CodigoQR As String = _Fila.Cells("CodigoQR").Value

        If Fx_Tiene_Permiso(Me, "Prod019") Then

            Dim _CodigoAlt As String = GrillAlternativos.Rows(GrillAlternativos.CurrentRow.Index).Cells("KOPRAL").Value
            Dim _Proveedor As String = GrillAlternativos.Rows(GrillAlternativos.CurrentRow.Index).Cells("KOEN").Value

            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la línea ",
                                 "Eliminar línea", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Delete TABCODAL" & vbCrLf &
                               "Where KOPRAL = '" & _CodigoAlt & "' And KOEN = '" & _Proveedor & "' And KOPR = '" & TxtCodigo.Text & "'" & vbCrLf & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion where Clas_unica = 1" & vbCrLf &
                               "And Codigo = '" & TxtCodigo.Text & "' And DescripcionBusqueda = '" & _CodigoAlt & "'" &
                               vbCrLf &
                               vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_ListaPreCosto" & vbCrLf &
                               "Where CodAlternativo = '" & _CodigoAlt & "' And Proveedor = '" & _Proveedor & "'" &
                               vbCrLf &
                               vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Prod_CodQR Where CodigoQR = '" & _CodigoQR & "'"

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Beep()
                    ToastNotification.Show(Me, "CODIGO ELIMINADO CORRECTAMENTE", My.Resources.cross,
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                End If

                GrillAlternativos.Rows.RemoveAt(GrillAlternativos.CurrentRow.Index)

            End If

        End If

    End Sub

    Private Sub GrillAlternativos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrillAlternativos.KeyDown

        If e.KeyValue = Keys.Delete Then
            Sb_Eliminar_Linea()
        End If

    End Sub

    Private Sub GrillAlternativos_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrillAlternativos.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ContextMenuStrip1.Enabled = True
                Else
                    ContextMenuStrip1.Enabled = False
                End If
            End With
        End If

    End Sub

    Private Sub Mnu_BtnEditarDescripProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_BtnEditarDescripProducto.Click

        Dim _Fila As DataGridViewRow = GrillAlternativos.Rows(GrillAlternativos.CurrentRow.Index)

        Dim _CodigoAlt As String = _Fila.Cells("KOPRAL").Value.ToString.Trim
        Dim _Descripcion As String = _Fila.Cells("NOKOPRAL").Value
        Dim _Aceptar As Boolean

        If Fx_Tiene_Permiso(Me, "Prod018") Then

            _Aceptar = InputBox_Bk(Me, "Cambio de descripción del código alternativo",
                                                     "Mantención de código", _Descripcion,
                                                     False, _Tipo_Mayus_Minus.Mayusculas, 50, True,
                                                     _Tipo_Imagen.Texto.Texto)

            If _Aceptar Then
                Consulta_sql = "UPDATE TABCODAL SET NOKOPRAL = '" & _Descripcion & "'" & vbCrLf &
                               "WHERE KOPRAL = '" & _CodigoAlt & "' AND KOPR = '" & TxtCodigo.Text & "'"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Beep()
                    ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                           1 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)

                    GrillAlternativos.Rows(GrillAlternativos.CurrentRow.Index).Cells("NOKOPRAL").Value = _Descripcion
                End If
            End If
        End If

    End Sub

    Private Sub GrillAlternativos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillAlternativos.CellEnter

        Dim _Descripcion As String = GrillAlternativos.Rows(GrillAlternativos.CurrentRow.Index).Cells("NOKOPRAL").Value
        TxtDescripcion_Proveedor.Text = _Descripcion

    End Sub

    Private Sub Frm_CodAlternativo_Ver_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F2 Then
            Call BtnAgregarCodBarra_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Chk_Lect_Barras_IngrxCantidad_CheckedChanged(sender As Object, e As EventArgs)

        Dim _Msg As String

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set Lect_Barras_IngrxCantidad = " & Convert.ToInt32(Chk_Lect_Barras_IngrxCantidad.Checked) & vbCrLf &
                       "Where Codigo = '" & TxtCodigo.Text.Trim & "' And Codigo_Nodo = 0 And Para_filtro = 0 And Nodo_origen = 0 And Clas_unica = 0 And Producto = 1"

        If Chk_Lect_Barras_IngrxCantidad.Checked Then
            _Msg = "El producto solicitara cantidades al pistolear en despacho/recepción"
        Else
            _Msg = "El producto NO solicitara cantidades al pistolear en despacho/recepción"
        End If

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, _Msg, "Lectura de código de barras", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Chk_Lect_Barras_IngrxCantidad_CheckedChanging(sender As Object, e As Controls.CheckBoxXChangeEventArgs)
        Chk_Lect_Barras_IngrxCantidad.Enabled = False
        If Not Fx_Tiene_Permiso(Me, "Prod063") Then
            e.Cancel = True
        End If
        Chk_Lect_Barras_IngrxCantidad.Enabled = True
    End Sub

    Private Sub BtnAgregarCodBarra_Click(sender As Object, e As EventArgs) Handles BtnAgregarCodBarra.Click

        If Not Fx_Tiene_Permiso(Me, "Prod043") Then
            Return
        End If

        Dim _Grabar As Boolean

        Dim Fm As New Frm_CreaProductos_04_CodAlternativo(TxtCodigo.Text, "", "", Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Solo_Codigo_De_Barras)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then

            Beep()
            ToastNotification.Show(Me, "CODIGO INCORPODARO CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
            Sb_ActualizarGrilla()

        End If

    End Sub

    Private Sub BtnAgregarCodAlternativos_Click(sender As Object, e As EventArgs) Handles BtnAgregarCodAlternativos.Click

        If Not Fx_Tiene_Permiso(Me, "Prod017") Then
            Return
        End If

        Dim Fm_E As New Frm_BuscarEntidad_Mt(False)
        Fm_E.Text = "Selección de proveedor para asignación de código"
        Fm_E.ShowDialog(Me)

        If Not (Fm_E.Pro_RowEntidad Is Nothing) Then

            Dim _CodProveedor As String = Fm_E.Pro_RowEntidad.Item("KOEN")
            Dim _SucProveedor As String = Fm_E.Pro_RowEntidad.Item("SUEN")

            Fm_E.Dispose()

            Dim Fm As New Frm_CreaProductos_04_CodAlternativo(TxtCodigo.Text.Trim, "", _CodProveedor, Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Codigo_Barras_Proveedor)
            Fm.ShowDialog(Me)

            If Fm.Grabar Then

                Beep()
                ToastNotification.Show(Me, "CODIGO INCORPODARO CORRECTAMENTE", My.Resources.ok_button,
                                           1 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)

                Sb_ActualizarGrilla()

            End If
        Else
            Beep()
            ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN PROVEEDOR", My.Resources.cross, 1 * 1000,
                                   eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        If Not Fx_Tiene_Permiso(Me, "Prod018") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = GrillAlternativos.Rows(GrillAlternativos.CurrentRow.Index)

        Dim _Kopral As String = _Fila.Cells("KOPRAL").Value.ToString.Trim
        Dim _Koen As String = _Fila.Cells("KOEN").Value.ToString.Trim

        Dim _Grabar As Boolean

        Dim _Accion As Frm_CreaProductos_04_CodAlternativo.Enum_Accion

        If String.IsNullOrEmpty(_Koen) Then
            _Accion = Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Solo_Codigo_De_Barras
        Else
            _Accion = Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Codigo_Barras_Proveedor
        End If

        Dim Fm As New Frm_CreaProductos_04_CodAlternativo(TxtCodigo.Text, _Kopral, _Koen, _Accion)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar

        If _Grabar Then
            TxtDescripcion_Proveedor.Text = Fm.Txt_Nokopral.Text
            _Fila.Cells("NOKOPRAL").Value = Fm.Txt_Nokopral.Text
            Beep()
            ToastNotification.Show(Me, "PRODUCTO ACTUALIZADO CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
            'Sb_ActualizarGrilla()

        End If

        Fm.Dispose()
    End Sub

    Private Sub Btn_Ver_Usuario_Con_Este_Permiso_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Usuario_Con_Este_Permiso.Click
        Sb_Eliminar_Linea()
    End Sub


    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With GrillAlternativos

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Permisos)
                End If

            End With

        End If

    End Sub

End Class
