Imports DevComponents.DotNetBar

Public Class Frm_Inv_Ubicaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _IdInventario As Integer
    Dim _Cl_Inventario As New Cl_Inventario
    Dim _Tbl_Ubicaciones As New DataTable
    Dim _Dv As New DataView
    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._IdInventario = _Id_Inventario

        _Cl_Inventario = New Cl_Inventario
        _Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_Id_Inventario)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_Zonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Empresa = _Cl_Inventario.Zw_Inv_Inventario.Empresa
        Dim _Sucursal = _Cl_Inventario.Zw_Inv_Inventario.Sucursal
        Dim _Bodega = _Sql.Fx_Trae_Dato("TABBO", "KOBO", "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'")

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select *,Case Abierto When 1 Then 'Abierto' Else 'Cerrado' End As 'Estado'" & vbCrLf &
                       "From " & _Global_BaseBk & " Zw_Inv_Ubicaciones" & vbCrLf &
                       "Where IdInventario = " & _IdInventario

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_Ubicaciones = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Empresa").Visible = True
            .Columns("Empresa").HeaderText = "Emp."
            .Columns("Empresa").Width = 30
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").HeaderText = "Suc."
            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Visible = True
            .Columns("Bodega").HeaderText = "Bod."
            .Columns("Bodega").Width = 30
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Id").Visible = True
            .Columns("Id").HeaderText = "Id"
            .Columns("Id").Width = 40
            .Columns("Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Id").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").HeaderText = "Cod.Ubic."
            .Columns("Ubicacion").Width = 100
            .Columns("Ubicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").HeaderText = "Ubicación"
            .Columns("Ubicacion").Width = 300
            .Columns("Ubicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Ubicaciones").Visible = True
            '.Columns("Ubicaciones").HeaderText = "Ubicaciones"
            '.Columns("Ubicaciones").Width = 70
            '.Columns("Ubicaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Ubicaciones").DefaultCellStyle.Format = "###,##0.##"
            '.Columns("Ubicaciones").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 60
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.CurrentRow
                    Dim _Abierto As Boolean = _Fila.Cells("Abierto").Value

                    Btn_AbrirUbicacion.Visible = Not _Abierto
                    Btn_CerrarUbicacion.Visible = _Abierto

                    ShowContextMenu(Menu_Contextual_Zonas)

                End If
            End With
        End If
    End Sub

    Private Sub Btn_Crear_Ubicacion_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ubicacion.Click

        Dim _Aceptar As Boolean
        Dim _Ubicacion As String
        Dim _Cl_InvUbicacion As New Cl_InvUbicacion

        _Aceptar = InputBox_Bk(Me, "Ingrese la Ubicación" & vbCrLf &
                               "Máximo 30 caracteres", "Crear Ubiación/Sector", _Ubicacion, False,, 30, True, _Tipo_Imagen.Texto)

        If Not _Aceptar Then
            Return
        End If

        With _Cl_InvUbicacion.Zw_Inv_Ubicaciones

            .Id = 0
            .Ubicacion = _Ubicacion
            .IdInventario = _Cl_Inventario.Zw_Inv_Inventario.Id
            .Empresa = _Cl_Inventario.Zw_Inv_Inventario.Empresa
            .Sucursal = _Cl_Inventario.Zw_Inv_Inventario.Sucursal
            .Bodega = _Cl_Inventario.Zw_Inv_Inventario.Bodega
            .Abierto = True

        End With

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_InvUbicacion.Fx_Crear_Ubicacion(_Cl_InvUbicacion.Zw_Inv_Ubicaciones)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
            Call Btn_Crear_Ubicacion_Click(Nothing, Nothing)
            Return
        End If

        Sb_Actualizar_Grilla()

        If MessageBoxEx.Show(Me, _Mensaje.Mensaje & vbCrLf & vbCrLf & "¿Desea crear una nueva Ubicación?", "Grabar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Call Btn_Crear_Ubicacion_Click(Nothing, Nothing)
        End If

    End Sub
    Private Sub Btn_EditarUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_EditarUbicacion.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Ubicacion As String = _Fila.Cells("Ubicacion").Value
        Dim _Aceptar As Boolean
        Dim _Cl_InvUbicacion As New Cl_InvUbicacion
        Dim _Mensaje As New LsValiciones.Mensajes

        _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Ubicaciones(_Id)

        _Aceptar = InputBox_Bk(Me, "Ingrese la ubicación", "Editar Ubiación/Sector", _Ubicacion, False,, 30, True, _Tipo_Imagen.Texto)

        If Not _Aceptar Then
            Return
        End If

        _Cl_InvUbicacion.Zw_Inv_Ubicaciones.Ubicacion = _Ubicacion

        _Mensaje = _Cl_InvUbicacion.Fx_Editar_Ubicacion

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            _Fila.Cells("Ubicacion").Value = _Cl_InvUbicacion.Zw_Inv_Ubicaciones.Ubicacion
        End If

    End Sub
    Private Sub Btn_EliminarUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_EliminarUbicacion.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Cl_InvUbicacion As New Cl_InvUbicacion
        Dim _Mensaje As New LsValiciones.Mensajes

        _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Ubicaciones(_Id)

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Hoja_Detalle",
                                            "IdInventario = " & _IdInventario & " And IdUbicacion = " & _Id)
        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar la ubicación, tiene registros inventariados", "Eliminar Ubicación",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar la Ubicación " & _Fila.Cells("Ubicacion").Value & "?", "Eliminar Ubicación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        _Mensaje = _Cl_InvUbicacion.Fx_Eliminar_Ubicacion

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Grilla.Rows.Remove(_Fila)
        End If

    End Sub

    Private Sub Btn_AbrirUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_AbrirUbicacion.Click
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Sb_AbrirCerrarUbicacion(_Fila, _Id, True)
    End Sub

    Private Sub Btn_CerrarUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_CerrarUbicacion.Click
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Sb_AbrirCerrarUbicacion(_Fila, _Id, False)
    End Sub

    Sub Sb_AbrirCerrarUbicacion(_Fila As DataGridViewRow, _Id As Integer, _Abierto As Boolean)

        Dim _Cl_InvUbicacion As New Cl_InvUbicacion
        Dim _Mensaje As New LsValiciones.Mensajes

        _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Ubicaciones(_Id)
        _Cl_InvUbicacion.Zw_Inv_Ubicaciones.Abierto = _Abierto

        _Mensaje = _Cl_InvUbicacion.Fx_Editar_Ubicacion

        If _Mensaje.EsCorrecto Then
            _Mensaje.Mensaje = "Ubicación " & IIf(_Abierto, "Abierta", "Cerrada") & " Correctamente"
            _Fila.Cells("Abierto").Value = _Cl_InvUbicacion.Zw_Inv_Ubicaciones.Abierto
            _Fila.Cells("Estado").Value = IIf(_Abierto, "Abierto", "Cerrado")
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

    End Sub

    Private Sub Btn_Importar_Desde_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Desde_Excel.Click

        Dim _UbicacionesInsertadas As Boolean

        Dim Fm As New Frm_Inv_UbicacionesImporExcel(_IdInventario)
        Fm.ShowDialog(Me)
        _UbicacionesInsertadas = Fm.UbicacionesInsertadas
        Fm.Dispose()

        If _UbicacionesInsertadas Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            _Dv.RowFilter = String.Format("CodUbicacion+Ubicacion Like '%{0}%'", Txt_Filtrar.Text.Trim)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If Txt_Filtrar.Text.Trim.Length > 0 Then
            _Dv.RowFilter = String.Empty
        End If
    End Sub

    Private Sub Btn_ExportarExcel_Click(sender As Object, e As EventArgs) Handles Btn_ExportarExcel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Ubicaciones, Me, "Ubicaciones inventario")
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        Txt_Filtrar.Text = String.Empty
        _Dv.RowFilter = String.Empty
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
End Class
