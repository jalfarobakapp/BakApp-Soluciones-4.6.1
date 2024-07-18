Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_02_Detalle_Producto_Actual

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Codigo As String
    Private _IdInventario As Integer

    Public Property Recontado As Boolean
    Public Property Zw_Inv_FotoInventario As Zw_Inv_FotoInventario

    Public Sub New(_IdInventario As Integer, _Codigo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._IdInventario = _IdInventario
        Me._Codigo = _Codigo

        Sb_Color_Botones_Barra(Bar2)

    End Sub
    Private Sub Frm_Detalle_Producto_Actual_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Chk_NoInventariar.Enabled = True

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Ver_Detalle_Del_Producto()

        AddHandler Chk_NoInventariar.CheckedChanged, AddressOf Chk_NoInventariar_CheckedChanged
        AddHandler Chk_NoInventariar.CheckedChanging, AddressOf Chk_NoInventariar_CheckedChanging
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

    End Sub

    Private Sub GrillaHistoriaProducto_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            With _Fila

                Dim _Digitador As String = NuloPorNro(.Cells("Digitador").Value, "")
                Dim _Contador_1 As String = .Cells("Contador1").Value
                Dim _Contador_2 As String = .Cells("Contador2").Value
                Dim _Observaciones As String = .Cells("Observaciones").Value

                LblDigitador.Text = _Digitador
                LblContador1.Text = _Contador_1
                LblContador2.Text = _Contador_2
                Txt_Observaciones.Text = _Observaciones

            End With

        Catch ex As Exception

        End Try

    End Sub


    Private Sub BtnEstadisticas_Click(sender As System.Object, e As System.EventArgs)

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Sub Sb_Ver_Detalle_Del_Producto()

        Consulta_sql = "Select HDet.Id,IdHoja,Recontado,Sector,Ubicacion,Isnull(HEnc.Nro_Hoja,'') As Nro_Hoja," & vbCrLf &
                       "Item_Hoja,FechaHoraToma,FechaHoraToma AS Hora,Cantidad as 'Cantidad',Responsable,ISNULL(Resp.NOKOFU,'') As Digitador," & vbCrLf &
                       "HEnc.IdContador1,ISNULL(C1.Nombre,'') As Contador1,HEnc.IdContador2,ISNULL(C2.Nombre,'') As Contador2," & vbCrLf &
                       "Observaciones,Actualizado_por,Obs_Actualizacion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle HDet" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Inv_Hoja HEnc On HEnc.Id = HDet.IdHoja" & vbCrLf &
                       "Left Join TABFU Resp On KOFU = HEnc.CodResponsable" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Inv_Contador C1 On C1.Id = HEnc.IdContador1" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Inv_Contador C2 On C2.Id = HEnc.IdContador2" & vbCrLf &
                       "Where HDet.IdInventario = " & _IdInventario & " And Codigo = '" & _Codigo & "'" & vbCrLf &
                       "Order by Recontado,HDet.Id"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Recontado").HeaderText = "Recontado"
            .Columns("Recontado").Width = 70
            .Columns("Recontado").Visible = True
            .Columns("Recontado").ReadOnly = True

            .Columns("Sector").HeaderText = "Sector"
            .Columns("Sector").Width = 200
            .Columns("Sector").Visible = True
            .Columns("Sector").ReadOnly = True

            .Columns("Ubicacion").HeaderText = "Ubicación"
            .Columns("Ubicacion").Width = 100
            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").ReadOnly = True

            .Columns("Nro_Hoja").HeaderText = "Hoja"
            .Columns("Nro_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_Hoja").Width = 35
            .Columns("Nro_Hoja").Visible = True
            .Columns("Nro_Hoja").ReadOnly = True

            .Columns("Item_Hoja").HeaderText = "Item"
            .Columns("Item_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Item_Hoja").Width = 40
            .Columns("Item_Hoja").Visible = True
            .Columns("Item_Hoja").ReadOnly = True

            .Columns("FechaHoraToma").HeaderText = "Fecha"
            .Columns("FechaHoraToma").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaHoraToma").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaHoraToma").Width = 70
            .Columns("FechaHoraToma").Visible = True
            .Columns("FechaHoraToma").ReadOnly = True

            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 45
            .Columns("Hora").Visible = True
            .Columns("Hora").ReadOnly = True

            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 70
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").ReadOnly = True

        End With

        Consulta_sql = "Select Codigo,Recontado, SUM(Cantidad) As Cantidad" & vbCrLf &
                       "Into #PasoR" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Recontado = 1 And Codigo = '" & _Codigo & "'" & vbCrLf &
                       "Group By Codigo,Recontado" & vbCrLf &
                       vbCrLf &
                       "Select Codigo,Recontado, SUM(Cantidad) As Cantidad" & vbCrLf &
                       "Into #PasoC" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Codigo = '" & _Codigo & "'" & vbCrLf &
                       "Group By Codigo,Recontado" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Recontado = 0 Where IdInventario = 1 And Codigo = '" & _Codigo & "'" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Recontado = 1,Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #PasoR On #PasoR.Codigo = Foto.Codigo" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Foto.Codigo = '" & _Codigo & "'" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #PasoC On #PasoC.Codigo = Foto.Codigo" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Foto.Codigo = '" & _Codigo & "'" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set " &
                       "Dif_Inv_Cantidad = Cant_Inventariada-StFisicoUd1,Total_Costo_Foto = StFisicoUd1*Costo,Total_Costo_Inv = Cant_Inventariada*Costo" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Codigo = '" & _Codigo & "'" & vbCrLf &
                       vbCrLf &
                       "Drop Table #PasoR" & vbCrLf &
                       "Drop Table #PasoC"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Cl_Inventario As New Cl_Inventario

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Inventario.Fx_Llenar_Zw_Inv_FotoInventario(_IdInventario, _Codigo)

        Zw_Inv_FotoInventario = _Mensaje.Tag

        With Zw_Inv_FotoInventario

            Lbl_StFisicoUd1.Text = FormatNumber(.StFisicoUd1, 2)
            Lbl_Cant_Inventariada.Text = FormatNumber(.Cant_Inventariada, 2)
            .Dif_Inv_Cantidad = .Cant_Inventariada - .StFisicoUd1
            Lbl_Dif_Inv_Cantidad.Text = FormatNumber(.Cant_Inventariada - .StFisicoUd1, 0)

            ChkCerrado.Checked = .Cerrado
            ChkLevantado.Checked = .Levantado
            ChkRecontado.Checked = .Recontado

            Chk_NoInventariar.Checked = .NoInventariar

            If .Dif_Inv_Cantidad < 0 Then
                Lbl_Dif_Inv_Cantidad.ForeColor = Rojo
            Else
                Lbl_Dif_Inv_Cantidad.ForeColor = Verde
            End If

        End With

    End Sub

    Private Sub BtnAgregarConteo_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarConteo.Click

        If Chk_NoInventariar.Checked Then
            MessageBoxEx.Show(Me, "El producto esta marcado para no inventariar", "Producto marcado",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Hoja_Detalle",
                                                       "IdInventario = " & _IdInventario & " And Codigo = '" & _Codigo & "' And Recontado = 1")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Este producto ya tiene un reconteo previamente registrado." & vbCrLf &
                              "Para realizar un nuevo reconteo, es necesario anular el registro anterior.", "Conteo recontado",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not Fx_Tiene_Permiso(Me, "Invg0003",, , False,,,, False) Then
            Return
        End If

        Dim _PermisoAceptado As Boolean

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Invg0003", True, False)
        Fm.Text = "INGRESE CLAVE DE AUTORIZACION"
        Fm.Pro_Cerrar_Automaticamente = True
        Fm.ShowDialog(Me)

        _PermisoAceptado = Fm.Pro_Permiso_Aceptado
        Dim _RowUsuario As DataRow = Fm.Pro_RowUsuario
        Fm.Dispose()

        If Not _PermisoAceptado Then
            Return
        End If

        Dim Fm_Inv As New Frm_IngresarHoja(_IdInventario, 0, _RowUsuario.Item("KOFU"))
        Fm_Inv.Reconteo = True
        Fm_Inv.CodigoReconteo = _Codigo
        Fm_Inv.ShowDialog(Me)
        Fm_Inv.Dispose()

        Sb_Ver_Detalle_Del_Producto()

    End Sub

    Private Sub Chk_NoInventariar_CheckedChanged(sender As Object, e As EventArgs)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set NoInventariar = " & Convert.ToInt32(Chk_NoInventariar.Checked) & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Codigo = '" & _Codigo & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            If Chk_NoInventariar.Checked Then
                MessageBoxEx.Show(Me, "Se ha marcado el producto para no inventariar", "Producto marcado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBoxEx.Show(Me, "Se ha desmarcado el producto para no inventariar", "Producto desmarcado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Zw_Inv_FotoInventario.NoInventariar = Chk_NoInventariar.Checked

    End Sub

    Private Sub Chk_NoInventariar_CheckedChanging(sender As Object, e As Controls.CheckBoxXChangeEventArgs)

        If Not Fx_Tiene_Permiso(Me, "Invg0001",, , False,,,, False) Then
            Return
        End If

        Dim _PermisoAceptado As Boolean

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Invg0001", True, False)
        Fm.Text = "INGRESE CLAVE DE AUTORIZACION"
        Fm.Pro_Cerrar_Automaticamente = True
        Fm.ShowDialog(Me)

        _PermisoAceptado = Fm.Pro_Permiso_Aceptado
        Dim _RowUsuario As DataRow = Fm.Pro_RowUsuario
        Fm.Dispose()

        If Not _PermisoAceptado Then
            e.Cancel = True
        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id = _Fila.Cells("Id").Value
        Dim _IdHoja = _Fila.Cells("IdHoja").Value
        Dim _Recontado = _Fila.Cells("Recontado").Value
        Dim _Nro_Hoja = _Fila.Cells("Nro_Hoja").Value

        Dim _Cl_Conteo As New Cl_Conteo

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _PermisoAceptado As Boolean

        If Not Fx_Tiene_Permiso(Me, "Invg0004",, , False,,,, False) Then
            Return
        End If

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Invg0004", True, False)
        Fm.Text = "INGRESE CLAVE DE AUTORIZACION"
        Fm.Pro_Cerrar_Automaticamente = True
        Fm.ShowDialog(Me)

        _PermisoAceptado = Fm.Pro_Permiso_Aceptado
        Dim _RowUsuario As DataRow = Fm.Pro_RowUsuario
        Fm.Dispose()

        If Not _PermisoAceptado Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Desea eliminar el reconteo de la hoja " & _Nro_Hoja & "?", "Eliminar reconteo",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Conteo.Fx_Eliminar_Hoja(_IdHoja, _NombreEquipo, _RowUsuario.Item("KOFU"))

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Sb_Ver_Detalle_Del_Producto()

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click
        With Grilla
            Try
                Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
                Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

                Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
                Clipboard.SetText(Copiar)

                ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End With
    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.CurrentRow
                    Dim _Recontado As Boolean = _Fila.Cells("Recontado").Value

                    Btn_Editar.Enabled = Not _Recontado
                    Btn_Eliminar.Enabled = _Recontado

                    ShowContextMenu(Menu_Contextual_01)

                End If
            End With
        End If
    End Sub
End Class
