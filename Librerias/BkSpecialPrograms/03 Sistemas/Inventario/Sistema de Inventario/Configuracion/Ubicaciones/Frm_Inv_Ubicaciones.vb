Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevComponents.DotNetBar

Public Class Frm_Inv_Ubicaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _IdInventario As Integer
    Dim _Cl_Inventario As New Cl_Inventario

    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._IdInventario = _Id_Inventario

        _Cl_Inventario = New Cl_Inventario
        _Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_Id_Inventario)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Zonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Empresa = _Cl_Inventario.Zw_Inv_Inventario.Empresa
        Dim _Sucursal = _Cl_Inventario.Zw_Inv_Inventario.Sucursal
        Dim _Bodega = _Sql.Fx_Trae_Dato("TABBO", "KOBO", "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'")

        Cmb_Bodegas.DataSource = Nothing
        caract_combo(Cmb_Bodegas)
        Consulta_sql = "Select KOBO AS Padre,KOBO+'-'+NOKOBO AS Hijo FROM TABBO " &
                       "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "'"
        Cmb_Bodegas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Bodegas.SelectedValue = _Bodega

        Sb_Actualizar_Grilla()

        AddHandler Cmb_Bodegas.SelectedIndexChanged, AddressOf Cmb_Bodegas_SelectedIndexChanged
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select *,Case Abierto When 1 Then 'Abierto' Else 'Cerrado' End As 'Estado'" & vbCrLf &
                       "From " & _Global_BaseBk & " Zw_Inv_Ubicaciones" & vbCrLf &
                       "Where IdInventario = " & _IdInventario
        Dim _Tbl_Inventarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Inventarios

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

            .Columns("CodUbicacion").Visible = True
            .Columns("CodUbicacion").HeaderText = "Cod.Ubic."
            .Columns("CodUbicacion").Width = 100
            .Columns("CodUbicacion").DisplayIndex = _DisplayIndex
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

    Private Sub Cmb_Bodegas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla()
    End Sub


    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.CurrentRow
                    Dim _Abierto As Boolean = _Fila.Cells("Abierto").Value

                    Btn_AbrirUbicacion.Visible = _Abierto
                    Btn_CerrarUbicacion.Visible = Not _Abierto

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
            .CodUbicacion = String.Empty
            .Ubicacion = _Ubicacion
            .IdInventario = _Cl_Inventario.Zw_Inv_Inventario.Id
            .Empresa = _Cl_Inventario.Zw_Inv_Inventario.Empresa
            .Sucursal = _Cl_Inventario.Zw_Inv_Inventario.Sucursal
            .Bodega = _Cl_Inventario.Zw_Inv_Inventario.Bodega
            .Abierto = True

        End With

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_InvUbicacion.Fx_Crear_Ubicacion

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
        Dim Fm As New Frm_Inv_UbicacionesImporExcel(_IdInventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Actualizar_Grilla()
    End Sub
End Class
