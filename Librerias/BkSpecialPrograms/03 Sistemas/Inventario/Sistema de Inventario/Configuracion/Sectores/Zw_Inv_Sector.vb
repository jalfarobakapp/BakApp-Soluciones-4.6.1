Imports DevComponents.DotNetBar

Public Class Zw_Inv_Sector

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer
    Dim _Row_Inventario As DataRow

    Public Property Id_Inventario As Integer
        Get
            Return _Id_Inventario
        End Get
        Set(value As Integer)
            _Id_Inventario = value
        End Set
    End Property

    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Inventario = _Id_Inventario

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Inventario Inv" & vbCrLf &
                       "Where Id_Inventario = " & _Id_Inventario
        _Row_Inventario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Zonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")
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

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")

        Consulta_sql = "Select Zn.*," &
                       "(Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones ZnUbic " &
                       "Where Zn.Id_Inventario = ZnUbic.Id_Inventario And Zn.Empresa = ZnUbic.Empresa And Zn.Sucursal = ZnUbic.Sucursal And Zn.Bodega = ZnUbic.Bodega And Zn.Codigo_Sector = ZnUbic.Codigo_Sector) As Ubicaciones" & vbCrLf &
                       "From " & _Global_BaseBk & " Zw_Inv_Sector Zn" & vbCrLf &
                       "Where Id_Inventario = '" & _Id_Inventario & "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & Cmb_Bodegas.SelectedValue & "'"
        Dim _Tbl_Inventarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Inventarios

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Empresa").Visible = True
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Width = 30
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Visible = True
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Width = 30
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo_Sector").Visible = True
            .Columns("Codigo_Sector").HeaderText = "Cod.Sector"
            .Columns("Codigo_Sector").Width = 100
            .Columns("Codigo_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Sector").Visible = True
            .Columns("Nombre_Sector").HeaderText = "Nombre Sector"
            .Columns("Nombre_Sector").Width = 340
            .Columns("Nombre_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ubicaciones").Visible = True
            .Columns("Ubicaciones").HeaderText = "Ubicaciones"
            .Columns("Ubicaciones").Width = 70
            .Columns("Ubicaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ubicaciones").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Ubicaciones").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cerrado").Visible = True
            .Columns("Cerrado").HeaderText = "Lock"
            .Columns("Cerrado").Width = 40
            .Columns("Cerrado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Cmb_Bodegas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Crear_Zona_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Zona.Click

        If MessageBoxEx.Show(Me, "¿Confirma la bodega " & Cmb_Bodegas.Text.Trim & " para la Zona?", "Crear Zona",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Zona As String
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el nombre de la Zona para la bodega: " & Cmb_Bodegas.Text, "Crear Zona", _Zona, False, _Tipo_Mayus_Minus.Mayusculas, 50, True, _Tipo_Imagen.Ubicacion)

        If Not _Aceptar Then
            Return
        End If

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")
        Dim _Bodega = Cmb_Bodegas.SelectedValue

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Zonas (Id_Inventario,Empresa,Sucursal,Bodega,Zona) Values " &
            "(" & _Id_Inventario & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Zona & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_Zonas)

                End If
            End With
        End If
    End Sub

    Private Sub Grilla_Zonas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")
        Dim _Bodega As String = Cmb_Bodegas.SelectedValue
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value

        Dim Fm As New Zw_Inv_Sector_vs_Ubicaciones(_Id_Inventario, _Bodega, _Codigo_Sector)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        'Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones ZnUbic Where Zn.Codigo_Sector = ZnUbic.Codigo_Sector
        _Fila.Cells("Ubicaciones").Value = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones",
                                                                    "Id_Inventario = " & _Id_Inventario & " And Empresa = '" & _Empresa & "' " &
                                                                    "And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' " &
                                                                    "And Codigo_Sector = '" & _Codigo_Sector & "'")


    End Sub

End Class
