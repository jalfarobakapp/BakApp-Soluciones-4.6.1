Imports DevComponents.DotNetBar

Public Class Frm_Codigos_Alternativos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Tablcodal As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion.ForeColor = Color.White
        End If

        Txt_Koen.Tag = String.Empty

    End Sub

    Private Sub Frm_Codigos_Alternativos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Me.ActiveControl = Txt_Descripcion

    End Sub

    Sub Sb_Actualizar_Grilla()

        Me.Cursor = Cursors.WaitCursor

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Descripcion.Text), "KOPRAL+KOPR+NOKOPRAL+KOEN LIKE '%")
        Dim _Filtro_Koen = String.Empty

        If Not String.IsNullOrEmpty(Txt_Koen.Tag) Then
            _Filtro_Koen = "KOEN = '" & Txt_Koen.Tag & "' And" & vbCrLf
        End If

        Consulta_sql = "Select Tcd.*,Isnull((Select Top 1 NOKOEN From MAEEN Een Where Een.KOEN = Tcd.KOEN),'') As NOKOEN,Cast('' As Varchar(20)) As 'Ean_13'" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From TABCODAL Tcd" & vbCrLf &
                       "Where " & _Filtro_Koen &
                       "(Tcd.KOPRAL+Tcd.KOPR+Tcd.NOKOPRAL+Tcd.KOEN Like '%" & _Cadena & "%'" & vbCrLf &
                       "Or KOPRAL In (Select Kopral From " & _Global_BaseBk & "Zw_Prod_CodQR Where CodigoQR Like '%" & _Cadena & "%'))" & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       "Order By KOPR,KOPRAL" & vbCrLf &
                       "Drop Table #Paso"

        _Tbl_Tablcodal = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla
            .DataSource = _Tbl_Tablcodal

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("KOPRAL").Width = 120
            .Columns("KOPRAL").HeaderText = "Alternativo"
            .Columns("KOPRAL").Visible = True
            .Columns("KOPRAL").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPR").Width = 110
            .Columns("KOPR").HeaderText = "Código SKU"
            .Columns("KOPR").Visible = True
            .Columns("KOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPRAL").Width = 240
            .Columns("NOKOPRAL").HeaderText = "Descripción"
            .Columns("NOKOPRAL").Visible = True
            .Columns("NOKOPRAL").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MULTIPLO").Width = 40
            .Columns("MULTIPLO").HeaderText = "Mult."
            .Columns("MULTIPLO").ToolTipText = "Multiplo"
            .Columns("MULTIPLO").Visible = True
            .Columns("MULTIPLO").DefaultCellStyle.Format = "###,##"
            .Columns("MULTIPLO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MULTIPLO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOEN").Width = 80
            .Columns("KOEN").HeaderText = "Entidad"
            .Columns("KOEN").Visible = True
            .Columns("KOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Width = 240
            .Columns("NOKOEN").HeaderText = "Proveedor asociado"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Me.Cursor = Cursors.Default

        Me.Refresh()

    End Sub

    Private Sub Btn_Exportar_Excel_Permisos_Usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel_Permisos_Usuario.Click
        ShowContextMenu(Menu_Contextual_Excel)
    End Sub

    Private Sub Txt_Descripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Crear_Codigo_Alternativo_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Codigo_Alternativo.Click

        If Not Fx_Tiene_Permiso(Me, "Prod017") Then
            Return
        End If

        Dim _Kopr As String
        Dim _Grabar As Boolean

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        With Fm
            .Pro_Actualizar_Precios = False
            .Pro_Mostrar_Info = False
            .BtnBuscarAlternativos.Visible = True
            .Pro_Mostrar_Imagenes = True
            .BtnCrearProductos.Visible = True
            .Pro_Mostrar_Editar = True
            .Pro_Mostrar_Eliminar = True
            .BtnExportaExcel.Visible = True
            .Pro_Tipo_Lista = "P"
            .Pro_Maestro_Productos = False
            .Pro_Sucursal_Busqueda = ModSucursal
            .Pro_Bodega_Busqueda = ModBodega
            .Pro_Lista_Busqueda = ModListaPrecioVenta
            .Mnu_Btn_Cambiar_Codigo_Producto.Visible = True
            .ShowDialog(Me)
            If .Pro_Seleccionado Then
                _Kopr = .Pro_RowProducto.Item("KOPR")
            End If
            .Dispose()
        End With

        If String.IsNullOrEmpty(_Kopr) Then
            Return
        End If

        Dim FmAlt As New Frm_CreaProductos_04_CodAlternativo(_Kopr, "", Txt_Koen.Tag, Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Ambos)
        FmAlt.Grupo_Proveedor.Enabled = String.IsNullOrEmpty(Txt_Koen.Tag)
        FmAlt.ShowDialog(Me)
        _Grabar = FmAlt.Grabar
        FmAlt.Dispose()

        If _Grabar Then
            If MessageBoxEx.Show(Me, "¿Desea ingresar otro código alternativo para el mismo producto?", "Opcion",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Call Btn_Crear_Codigo_Alternativo_Click(Nothing, Nothing)
                Return
            End If
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If Not Fx_Tiene_Permiso(Me, "Prod018") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kopral As String = _Fila.Cells("KOPRAL").Value.ToString.Trim
        Dim _Kopr As String = _Fila.Cells("KOPR").Value.ToString.Trim
        Dim _Koen As String = _Fila.Cells("KOEN").Value.ToString.Trim

        Dim _Grabar As Boolean
        Dim _Eliminado As Boolean

        Dim _Accion As Frm_CreaProductos_04_CodAlternativo.Enum_Accion

        If String.IsNullOrEmpty(_Koen) Then
            _Accion = Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Solo_Codigo_De_Barras
        Else
            _Accion = Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Codigo_Barras_Proveedor
        End If

        Dim Fm As New Frm_CreaProductos_04_CodAlternativo(_Kopr, _Kopral, _Koen, Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Ambos)
        Fm.Btn_Quitar_QR.Enabled = False
        If Not String.IsNullOrEmpty(Txt_Koen.Tag) Then
            Fm.Grupo_Proveedor.Enabled = False
        End If
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Eliminado = Fm.Eliminado

        Fm.Dispose()

        If _Grabar Then

            _Fila.Cells("NOKOPRAL").Value = Fm.Txt_Nokopral.Text
            Beep()
            ToastNotification.Show(Me, "PRODUCTO ACTUALIZADO CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)

        End If

        If _Eliminado Then
            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
        End If

    End Sub

    Private Sub Btn_LevantarMasivamente_Click(sender As Object, e As EventArgs) Handles Btn_LevantarMasivamente.Click

        Dim Fm As New Frm_LevantarMasivamenteCodAlt
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With Grilla

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name

                    Dim _Koen = Grilla.CurrentRow.Cells("KOEN").Value.ToString.Trim

                    Lbl_OtrasOpciones.Visible = (_Cabeza = "KOPR")
                    Btn_OO_Crear_Codigo.Visible = (_Cabeza = "KOPR" And String.IsNullOrEmpty(Txt_Koen.Tag))
                    Btn_OO_Crear_Codigo_Entidad.Visible = (_Cabeza = "KOPR" And Not String.IsNullOrEmpty(_Koen))

                    ShowContextMenu(Menu_Contextual_Permisos)

                End If

            End With

        End If

    End Sub

    Sub Sb_Eliminar_Linea()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If Fx_Tiene_Permiso(Me, "Prod019") Then

            Dim _Kopr As String = _Fila.Cells("KOPR").Value
            Dim _Kopral As String = _Fila.Cells("KOPRAL").Value
            Dim _Koen As String = _Fila.Cells("KOEN").Value
            Dim _CodigoQR As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_CodQR", "CodigoQR", "Kopral = '" & _Kopral & "'")

            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la línea ",
                                 "Eliminar línea", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Delete TABCODAL" & vbCrLf &
                               "Where KOPRAL = '" & _Kopral & "' And KOEN = '" & _Koen & "' And KOPR = '" & _Kopr & "'" & vbCrLf & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion where Clas_unica = 1" & vbCrLf &
                               "And Codigo = '" & _Kopr & "' And DescripcionBusqueda = '" & _Kopral & "'" &
                               vbCrLf &
                               vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_ListaPreCosto" & vbCrLf &
                               "Where CodAlternativo = '" & _Kopral & "' And Proveedor = '" & _Koen & "'" &
                               vbCrLf &
                               vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Prod_CodQR Where CodigoQR = '" & _CodigoQR & "'"

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Beep()
                ToastNotification.Show(Me, "CODIGO ELIMINADO CORRECTAMENTE", My.Resources.cross,
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                Sb_EjecConsultaBasesExternas(Me, Consulta_sql, True)

                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)

            End If

        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Ver_Usuario_Con_Este_Permiso_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Usuario_Con_Este_Permiso.Click
        Sb_Eliminar_Linea()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Tablcodal, Me, "TabCodal")
    End Sub

    Private Sub Btn_Exportar_ExcelEAN13_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_ExcelEAN13.Click
        Dim _i = 0

        If Chk_Ean13.Checked Then

            For Each _Fila As DataRow In _Tbl_Tablcodal.Rows

                Dim _Kopral = Trim(_Fila.Item("KOPRAL"))
                Dim _Ean_13 = Fx_GetDCBarCodEAN13(_Kopral)

                If Not String.IsNullOrEmpty(_Ean_13) Then
                    _Fila.Item("Ean_13") = _Kopral
                End If

                _Fila.Item("Ean_13") = _Kopral
                _Fila.Item("TXTMULTI") = _i
                _i += 1

            Next

        End If

        ExportarTabla_JetExcel_Tabla(_Tbl_Tablcodal, Me, "TabCodal")
    End Sub

    Private Sub Btn_OO_Crear_Codigo_Click(sender As Object, e As EventArgs) Handles Btn_OO_Crear_Codigo.Click

        If Not Fx_Tiene_Permiso(Me, "Prod017") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Kopr As String = _Fila.Cells("KOPR").Value

        Dim FmAlt As New Frm_CreaProductos_04_CodAlternativo(_Kopr, "", "", Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Ambos)
        FmAlt.ShowDialog(Me)
        If FmAlt.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        FmAlt.Dispose()

    End Sub

    Private Sub Btn_OO_Crear_Codigo_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_OO_Crear_Codigo_Entidad.Click

        If Not Fx_Tiene_Permiso(Me, "Prod017") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Kopr As String = _Fila.Cells("KOPR").Value
        Dim _Koen As String = _Fila.Cells("KOEN").Value

        Dim FmAlt As New Frm_CreaProductos_04_CodAlternativo(_Kopr, "", _Koen, Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Ambos)
        If Not String.IsNullOrEmpty(Txt_Koen.Tag) Then
            FmAlt.Grupo_Proveedor.Enabled = False
        End If
        FmAlt.ShowDialog(Me)
        If FmAlt.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        FmAlt.Dispose()

    End Sub

    Private Sub Txt_Koen_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Koen.ButtonCustomClick
        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then

            Btn_Crear_Codigo_Alternativo.Tooltip = "Crear código alternativo solo para el proveedor por defecto"

            Txt_Koen.Text = Fm.Pro_RowEntidad.Item("KOEN").ToString.Trim & "-" & Fm.Pro_RowEntidad.Item("NOKOEN").ToString.Trim
            Txt_Koen.Tag = Fm.Pro_RowEntidad.Item("KOEN")

            Sb_Actualizar_Grilla()

            MessageBoxEx.Show(Me, "Se encontraron " & FormatNumber(Grilla.RowCount, 0) & " registro(s)" & vbCrLf &
                              "Solo sera posible crear códigos alternativos para el proveedor por defecto", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        Fm.Dispose()
    End Sub

    Private Sub Txt_Koen_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Koen.ButtonCustom2Click
        Txt_Koen.Tag = String.Empty
        Txt_Koen.Text = String.Empty
        Sb_Actualizar_Grilla()

        Btn_Crear_Codigo_Alternativo.Tooltip = "Crear nuevo código alternativo"

        MessageBoxEx.Show(Me, "Ahora es posible crear cualquier tipo de código alternativo", "Información",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class
