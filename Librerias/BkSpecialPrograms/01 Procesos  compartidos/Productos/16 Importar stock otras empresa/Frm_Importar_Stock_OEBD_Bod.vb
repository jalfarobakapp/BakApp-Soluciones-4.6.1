Imports DevComponents.DotNetBar
Public Class Frm_Importar_Stock_OEBD_Bod

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Configuraciones As DataTable

    Dim _Id_Conexion As Integer
    Dim _Cadena_ConexionSQL_Server_Origen As String
    Dim _Empresa_Ori As String

    Public Sub New(Id_Conexion As Integer, _Cadena_ConexionSQL_Server_Origen As String, _Empresa_Ori As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Cadena_ConexionSQL_Server_Origen = _Cadena_ConexionSQL_Server_Origen
        Me._Empresa_Ori = _Empresa_Ori
        Me._Id_Conexion = Id_Conexion

    End Sub

    Private Sub Frm_Importar_Stock_OEBD_Bod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest" & vbCrLf &
                       "Where Empresa_Ori = '" & ModEmpresa & "'"

        _Tbl_Configuraciones = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Configuraciones

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Empresa_Ori").Visible = True
            .Columns("Empresa_Ori").HeaderText = "Emp.O"
            .Columns("Empresa_Ori").ToolTipText = "Código de Empresa de origen"
            .Columns("Empresa_Ori").Width = 50
            .Columns("Empresa_Ori").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal_Ori").Visible = True
            .Columns("Sucursal_Ori").HeaderText = "Suc.O"
            .Columns("Sucursal_Ori").ToolTipText = "Código de Sucursal de origen"
            .Columns("Sucursal_Ori").Width = 50
            .Columns("Sucursal_Ori").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega_Ori").Visible = True
            .Columns("Bodega_Ori").HeaderText = "Bod.O"
            .Columns("Bodega_Ori").ToolTipText = "Código de Bodega de origen"
            .Columns("Bodega_Ori").Width = 50
            .Columns("Bodega_Ori").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreBod_Ori").Visible = True
            .Columns("NombreBod_Ori").HeaderText = "Nombre bod. Origen"
            .Columns("NombreBod_Ori").ToolTipText = "Nombre de Bodega de origen"
            .Columns("NombreBod_Ori").Width = 150
            .Columns("NombreBod_Ori").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Empresa_Des").Visible = True
            .Columns("Empresa_Des").HeaderText = "Emp.D"
            .Columns("Empresa_Des").ToolTipText = "Código de Empresa de origen"
            .Columns("Empresa_Des").Width = 50
            .Columns("Empresa_Des").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal_Des").Visible = True
            .Columns("Sucursal_Des").HeaderText = "Suc.D"
            .Columns("Sucursal_Des").ToolTipText = "Código de Sucursal de origen"
            .Columns("Sucursal_Des").Width = 50
            .Columns("Sucursal_Des").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega_Des").Visible = True
            .Columns("Bodega_Des").HeaderText = "Bod.D"
            .Columns("Bodega_Des").ToolTipText = "Código de Bodega de origen"
            .Columns("Bodega_Des").Width = 50
            .Columns("Bodega_Des").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreBod_Des").Visible = True
            .Columns("NombreBod_Des").HeaderText = "Nombre bod. Destino"
            .Columns("NombreBod_Des").ToolTipText = "Nombre de Bodega de destino"
            .Columns("NombreBod_Des").Width = 150
            .Columns("NombreBod_Des").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_BodegaOrigen_Click(sender As Object, e As EventArgs) Handles Btn_BodegaOrigen.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Origen

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = _Fila.Cells("Empresa_Ori").Value
        Fm_b.Pro_Sucursal = _Fila.Cells("Sucursal_Ori").Value
        Fm_b.Pro_Bodega = _Fila.Cells("Bodega_Ori").Value
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Fila.Cells("Empresa_Ori").Value = Fm_b.Pro_RowBodega.Item("EMPRESA")
            _Fila.Cells("Sucursal_Ori").Value = Fm_b.Pro_RowBodega.Item("KOSU")
            _Fila.Cells("Bodega_Ori").Value = Fm_b.Pro_RowBodega.Item("KOBO")
            _Fila.Cells("NombreBod_Ori").Value = Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

    End Sub

    Private Sub Btn_BodegaDestino_Click(sender As Object, e As EventArgs) Handles Btn_BodegaDestino.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = _Fila.Cells("Empresa_Des").Value
        Fm_b.Pro_Sucursal = _Fila.Cells("Sucursal_Des").Value
        Fm_b.Pro_Bodega = _Fila.Cells("Bodega_Des").Value
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Fila.Cells("Empresa_Des").Value = Fm_b.Pro_RowBodega.Item("EMPRESA")
            _Fila.Cells("Sucursal_Des").Value = Fm_b.Pro_RowBodega.Item("KOSU")
            _Fila.Cells("Bodega_Des").Value = Fm_b.Pro_RowBodega.Item("KOBO")
            _Fila.Cells("NombreBod_Des").Value = Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

    End Sub
    Private Sub Frm_Importar_Stock_OEBD_Bod_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub
    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_AgregarBodega_Click(sender As Object, e As EventArgs) Handles Btn_AgregarBodega.Click

        Dim _Sucursal_Ori, _Bodega_Ori, _NombreBod_Ori As String
        Dim _Empresa_Des, _Sucursal_Des, _Bodega_Des, _NombreBod_Des As String

        If Not MessageBoxEx.Show(Me, "A continuación debera ingresar la bodega de origen",
                                 "Bodega de Origen",
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
            Return
        End If

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Origen

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = _Empresa_Ori
        Fm_b.Pro_Sucursal = ModSucursal
        Fm_b.Pro_Bodega = ModBodega
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Sucursal_Ori = Fm_b.Pro_RowBodega.Item("KOSU")
            _Bodega_Ori = Fm_b.Pro_RowBodega.Item("KOBO")
            _NombreBod_Ori = Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

        If Not MessageBoxEx.Show(Me, "Ahora debe ingresar la bodega de destino",
                                 "Bodega de Destino",
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
            Return
        End If


        Fm_b = New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = ModEmpresa
        Fm_b.Pro_Sucursal = ModSucursal
        Fm_b.Pro_Bodega = ModBodega
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Empresa_Des = Fm_b.Pro_RowBodega.Item("EMPRESA")
            _Sucursal_Des = Fm_b.Pro_RowBodega.Item("KOSU")
            _Bodega_Des = Fm_b.Pro_RowBodega.Item("KOBO")
            _NombreBod_Des = Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

        If MessageBoxEx.Show(Me,
                             "CONFIRME LA GRABACION" & vbCrLf & vbCrLf &
                             "Bodega de Origen: " & _Empresa_Ori & "-" & _Sucursal_Ori & "-" & _Bodega_Ori & ": " & _NombreBod_Ori & vbCrLf &
                             "Bodega de Destino: " & _Empresa_Des & "-" & _Sucursal_Des & "-" & _Bodega_Des & ": " & _NombreBod_Ori,
                             "Confirmar grabación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DbExt_Maest (Id_Conexion,Empresa_Ori,Sucursal_Ori,Bodega_Ori,Activo,Empresa_Des,Sucursal_Des,Bodega_Des,NombreBod_Ori,NombreBod_Des) Values " &
                       "(" & _Id_Conexion & ",'" & _Empresa_Ori & "','" & _Sucursal_Ori & "','" & _Bodega_Ori & "',1,'" & _Empresa_Des & "','" & _Sucursal_Des & "','" & _Bodega_Des & "','" & _NombreBod_Ori & "','" & _NombreBod_Des & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_QuitarVendedor_Click(sender As Object, e As EventArgs) Handles Btn_QuitarVendedor.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar este registro?", "Eliminar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id As Integer = _Fila.Cells("Id").Value

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_DbExt_Maest Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Registro eliminado correctamente", "Eliminar",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

End Class
