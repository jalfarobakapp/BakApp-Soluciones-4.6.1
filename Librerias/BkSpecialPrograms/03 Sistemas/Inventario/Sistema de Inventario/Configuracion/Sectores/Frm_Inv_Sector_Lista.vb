Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Frm_Inv_Sector_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _IdInventario As Integer
    Dim _Cl_Inventario As New Cl_Inventario
    Dim _Tbl_Sectores As New DataTable
    Dim _Dv As New DataView

    Public _Zw_Inv_Sector_Seleccionado As Zw_Inv_Sector
    Public _SectorSeleccionado As Boolean

    Public Property ModoRevisionInventario As Boolean
    Public Property ModoSeleccionSector As Boolean
    Public Property ModoConfiguracion As Boolean

    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._IdInventario = _Id_Inventario

        _Cl_Inventario = New Cl_Inventario
        _Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_Id_Inventario)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Zonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Empresa = _Cl_Inventario.Zw_Inv_Inventario.Empresa
        Dim _Sucursal = _Cl_Inventario.Zw_Inv_Inventario.Sucursal
        Dim _Bodega = _Sql.Fx_Trae_Dato("TABBO", "KOBO", "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'")

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Btn_Crear_Ubicacion.Visible = (Not ModoRevisionInventario And Not ModoSeleccionSector)
        Btn_Importar_Desde_Excel.Visible = Not ModoRevisionInventario And Not ModoSeleccionSector
        Btn_ImprimirMasivamente.Visible = Not (ModoRevisionInventario Or ModoSeleccionSector)
        Btn_ImprimirSector.Visible = Not (ModoRevisionInventario Or ModoSeleccionSector)

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Cast(0 As Bit) As Chk, Sc.*,Isnull(NOKOFU,'') As 'FunCargo',Case Abierto When 1 Then 'Abierto' Else 'Cerrado' End As 'Estado'" & vbCrLf &
                       "From " & _Global_BaseBk & " Zw_Inv_Sector Sc" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario" & vbCrLf &
                       "Where IdInventario = " & _IdInventario

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_Sectores = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = ModoConfiguracion
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

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
            .Columns("Id").Width = 30
            .Columns("Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Id").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sector").Visible = True
            .Columns("Sector").HeaderText = "Sector"
            .Columns("Sector").Width = 100
            .Columns("Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreSector").Visible = True
            .Columns("NombreSector").HeaderText = "Nombre Sector"

            If ModoRevisionInventario Then
                .Columns("NombreSector").Width = 220
            Else
                .Columns("NombreSector").Width = 250
            End If

            .Columns("NombreSector").DisplayIndex = _DisplayIndex
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
            .Columns("Estado").Visible = ModoRevisionInventario
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

                    If ModoRevisionInventario Then
                        ShowContextMenu(Menu_Contextual_GestSector)
                    Else
                        ShowContextMenu(Menu_Contextual_MantSector)
                    End If

                End If
            End With
        End If
    End Sub

    Private Sub Btn_Crear_Ubicacion_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ubicacion.Click

        If Not _Cl_Inventario.Zw_Inv_Inventario.Activo Then
            MessageBoxEx.Show(Me, "El inventario se encuentra cerrado, no se puede realizar esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Inv_Sector_Crear(0)
        Fm.Cl_Inventario = _Cl_Inventario
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub
    Private Sub Btn_EditarUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_EditarUbicacion.Click

        If Not _Cl_Inventario.Zw_Inv_Inventario.Activo Then
            MessageBoxEx.Show(Me, "El inventario se encuentra cerrado, no se puede realizar esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Sector As String = _Fila.Cells("Sector").Value
        Dim _Cl_InvUbicacion As New Cl_InvSectores
        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Grabar As Boolean
        Dim _Eliminar As Boolean

        Dim Fm As New Frm_Inv_Sector_Crear(_Id)
        Fm.Cl_Inventario = _Cl_Inventario
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Eliminar = Fm.Eliminar
        _Cl_InvUbicacion = Fm.Cl_InvSectores
        Fm.Dispose()

        If _Grabar Then
            _Fila.Cells("Sector").Value = _Cl_InvUbicacion.Zw_Inv_Sector.Sector
            _Fila.Cells("NombreSector").Value = _Cl_InvUbicacion.Zw_Inv_Sector.NombreSector
            _Fila.Cells("CodFuncionario").Value = _Cl_InvUbicacion.Zw_Inv_Sector.CodFuncionario
            _Fila.Cells("FunCargo").Value = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Cl_InvUbicacion.Zw_Inv_Sector.CodFuncionario & "'")
            Lbl_UsuarioACargo.Text = "Usuario a cargo: " & _Fila.Cells("FunCargo").Value
        End If

        If _Eliminar Then
            Grilla.Rows.Remove(_Fila)
        End If

    End Sub
    Private Sub Btn_EliminarUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_EliminarUbicacion.Click

        If Not _Cl_Inventario.Zw_Inv_Inventario.Activo Then
            MessageBoxEx.Show(Me, "El inventario se encuentra cerrado, no se puede realizar esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Cl_InvUbicacion As New Cl_InvSectores
        Dim _Mensaje As New LsValiciones.Mensajes

        _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Sector(_Id)

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Hoja_Detalle",
                                            "IdInventario = " & _IdInventario & " And IdSector = " & _Id)
        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar el sector, tiene registros inventariados", "Eliminar Sector",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar el sector " & _Fila.Cells("Sector").Value & "?", "Eliminar Sector",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        _Mensaje = _Cl_InvUbicacion.Fx_Eliminar_Sector

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

        Dim _Cl_InvUbicacion As New Cl_InvSectores
        Dim _Mensaje As New LsValiciones.Mensajes

        _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Sector(_Id)
        _Cl_InvUbicacion.Zw_Inv_Sector.Abierto = _Abierto

        _Mensaje = _Cl_InvUbicacion.Fx_Editar_Sector

        If _Mensaje.EsCorrecto Then
            _Mensaje.Mensaje = "Ubicación " & IIf(_Abierto, "Abierta", "Cerrada") & " Correctamente"
            _Fila.Cells("Abierto").Value = _Cl_InvUbicacion.Zw_Inv_Sector.Abierto
            _Fila.Cells("Estado").Value = IIf(_Abierto, "Abierto", "Cerrado")
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

    End Sub

    Private Sub Btn_Importar_Desde_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Desde_Excel.Click

        If Not _Cl_Inventario.Zw_Inv_Inventario.Activo Then
            MessageBoxEx.Show(Me, "El inventario se encuentra cerrado, no se puede realizar esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim _UbicacionesInsertadas As Boolean

        Dim Fm As New Frm_Inv_Sector_ImporExcel(_IdInventario)
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

            _Dv.RowFilter = String.Format("Sector+NombreSector Like '%{0}%'", Txt_Filtrar.Text.Trim)

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
        ExportarTabla_JetExcel_Tabla(_Tbl_Sectores, Me, "Sectores inventario")
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

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Lbl_UsuarioACargo.Text = "Usuario a cargo: " & _Fila.Cells("FunCargo").Value
    End Sub

    Private Sub Btn_Copiar2_Click(sender As Object, e As EventArgs) Handles Btn_Copiar2.Click
        Call Btn_Copiar_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_VerProductos_Click(sender As Object, e As EventArgs) Handles Btn_VerProductos.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _IdSector As Integer = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Inv_Sector_Productos(_IdSector)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_ImprimirSector_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirSector.Click

        If Not _Cl_Inventario.Zw_Inv_Inventario.Activo Then
            MessageBoxEx.Show(Me, "El inventario se encuentra cerrado, no se puede realizar esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim _Sel_Impresora As Sel_Impresora = Fx_seleccionar_Impresora(Me)

        If Not _Sel_Impresora.ImpresoraSeleccionada Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _IdSector As Integer = _Fila.Cells("Id").Value
        Dim _CodigoBarras As String = _Fila.Cells("Sector").Value

        Sb_Imprimir_Sector(_IdSector, _CodigoBarras, _Sel_Impresora.PrtSettings)

    End Sub

    Sub Sb_Imprimir_Sector(_IdSector As Integer, _CodigoBarras As String, _PrinterSettings As PrinterSettings)

        Dim _Cl_Imprimir_Sectores As New Cl_Imprimir_Sectores(_IdSector)

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_Imprimir_Sectores.Fx_Imprimir_Sector(_PrinterSettings)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If Not ModoSeleccionSector Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _IdSector As Integer = _Fila.Cells("Id").Value

        Dim _Cl_InvSector As New Cl_InvSectores
        _Cl_InvSector.Fx_Llenar_Zw_Inv_Sector(_IdSector)

        _Zw_Inv_Sector_Seleccionado = _Cl_InvSector.Zw_Inv_Sector
        _SectorSeleccionado = True

        Me.Close()

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If ModoSeleccionSector Then
            If e.KeyCode = Keys.Enter Then
                ' Simula el evento CellDoubleClick
                Dim cellEventArgs As New DataGridViewCellEventArgs(Grilla.CurrentCell.ColumnIndex, Grilla.CurrentCell.RowIndex)
                Dim currentRowIndex As Integer = Grilla.CurrentCell.RowIndex
                Dim currentColumnIndex As Integer = Grilla.CurrentCell.ColumnIndex
                Grilla_CellDoubleClick(Grilla, cellEventArgs)
                Grilla.CurrentCell = Grilla.Rows(currentRowIndex).Cells(currentColumnIndex)
            End If
        End If
    End Sub

    Private Sub Btn_ImprimirMasivamente_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirMasivamente.Click

        If Not _Cl_Inventario.Zw_Inv_Inventario.Activo Then
            MessageBoxEx.Show(Me, "El inventario se encuentra cerrado, no se puede realizar esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not String.IsNullOrEmpty(_Dv.RowFilter) Then
            MessageBoxEx.Show(Me, "Debe quitar el filtro para poder imprimir masivamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not Fx_HayRegistrosTickeados() Then
            MessageBoxEx.Show(Me, "No hay sectores seleccionados para imprimir", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim _Sel_Impresora As Sel_Impresora = Fx_seleccionar_Impresora(Me)

        If Not _Sel_Impresora.ImpresoraSeleccionada Then
            Return
        End If



        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Fila.Cells("Chk").Value Then

                Dim _IdSector As Integer = _Fila.Cells("Id").Value
                Dim _CodigoBarras As String = _Fila.Cells("Sector").Value

                Sb_Imprimir_Sector(_IdSector, _CodigoBarras, _Sel_Impresora.PrtSettings)

            End If

        Next

    End Sub

    Private Function Fx_HayRegistrosTickeados() As Boolean
        For Each row As DataGridViewRow In Grilla.Rows
            Dim chkCell As DataGridViewCheckBoxCell = TryCast(row.Cells("Chk"), DataGridViewCheckBoxCell)
            If chkCell IsNot Nothing AndAlso CBool(chkCell.Value) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged
        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk_Marcar_Todas.Checked
        Next
    End Sub

End Class
