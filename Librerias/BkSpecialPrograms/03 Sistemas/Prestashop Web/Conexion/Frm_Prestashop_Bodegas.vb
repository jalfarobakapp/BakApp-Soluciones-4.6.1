Imports DevComponents.DotNetBar

Public Class Frm_Prestashop_Bodegas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo_Pagina As String
    Dim _Tbl_Bodegas As DataTable
    Dim _Grabar As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(_Codigo_Pagina As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._Codigo_Pagina = _Codigo_Pagina
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Prestashop_Bodegas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Código pagina: " & _Codigo_Pagina
        Sb_Actualizar_Grilla()
        AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse (Codigo_Pagina,Empresa,Sucursal,Bodega,id_warehouse,Activo)" & vbCrLf &
                       "Select '" & _Codigo_Pagina & "',EMPRESA,KOSU,KOBO,0,0 From TABBO" & vbCrLf &
                       "Where Rtrim(Ltrim(EMPRESA))+Rtrim(Ltrim(KOSU))+Rtrim(Ltrim(KOBO)) Not In " &
                       "(Select Rtrim(Ltrim(Empresa))+Rtrim(Ltrim(Sucursal))+Rtrim(Ltrim(Bodega)) From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse " &
                       "Where Codigo_Pagina = '" & _Codigo_Pagina & "')"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse Whs" & vbCrLf &
                       "Where Codigo_Pagina = '" & _Codigo_Pagina & "'" & vbCrLf &
                       "Order by id_warehouse"

        Consulta_sql = "Select Whs.*,NOKOBO" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse Whs" & vbCrLf &
                       "Inner Join TABBO On EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega" & vbCrLf &
                       "Where Codigo_Pagina = '" & _Codigo_Pagina & "'" & vbCrLf &
                       "Order by id_warehouse"
        _Tbl_Bodegas = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Bodegas

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Empresa").Visible = True
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Width = 50
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Width = 50
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Visible = True
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Width = 50
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOBO").Visible = True
            .Columns("NOKOBO").HeaderText = "Bodega"
            .Columns("NOKOBO").Width = 240
            .Columns("NOKOBO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("id_warehouse").Visible = True
            .Columns("id_warehouse").HeaderText = "id_warehouse"
            .Columns("id_warehouse").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("id_warehouse").Width = 80
            .Columns("id_warehouse").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Activo").Visible = True
            .Columns("Activo").HeaderText = "Activo"
            .Columns("Activo").Width = 50
            .Columns("Activo").ReadOnly = False
            .Columns("Activo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl_Bodegas.Rows

            Dim _Empresa = _Fila.Item("Empresa")
            Dim _Sucursal = _Fila.Item("Sucursal")
            Dim _Bodega = _Fila.Item("Bodega")
            Dim _id_warehouse = _Fila.Item("id_warehouse")
            Dim _Activo = Convert.ToInt32(_Fila.Item("Activo"))

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse Set Activo = " & _Activo & ",id_warehouse = " & _id_warehouse & " 
                            Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf

        Next

        If Not String.IsNullOrEmpty(Consulta_sql) Then

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Grabar = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If e.KeyValue = Keys.Enter Then

            If _Cabeza = "id_warehouse" Then

                Grilla.Columns(_Cabeza).ReadOnly = False
                Grilla.BeginEdit(True)

                e.SuppressKeyPress = False
                e.Handled = True

            End If

        End If

    End Sub

    Private Sub Grilla_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Validar As TextBox = CType(e.Control, TextBox)

        If _Cabeza = "id_warehouse" Then
            AddHandler _Validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        Else
            RemoveHandler _Validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        End If

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "id_warehouse" Then
            Grilla.Columns(_Cabeza).ReadOnly = True
        End If

    End Sub

End Class
