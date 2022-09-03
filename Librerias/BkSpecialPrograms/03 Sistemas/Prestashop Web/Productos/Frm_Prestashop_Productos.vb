Imports DevComponents.DotNetBar

Public Class Frm_Prestashop_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Productos As DataTable
    Dim _Row_Sitio As DataRow

    Dim _Sitio As String

    Dim _Dv As New DataView
    Dim _Ds As DataSet

    Public Sub New(Sitio As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Sitio = Sitio

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop Where Nombre_Pagina = '" & Sitio & "'"
        _Row_Sitio = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Me.Text = "SITIO: " & _Sitio
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Prestashop_Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Chk_Primario.Validating, AddressOf Chk_Validating
        AddHandler Chk_Active.Validating, AddressOf Chk_Validating

    End Sub

    Public Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select Sitio,Id_product,Codigo,Descripcion,Stock,Precio,Active,Usar_Padre,Sum(STFI1) As Stock_Rd,Precio_Rd,Primario,FH_Actualizacion,FH_Revision
                        From " & _Global_BaseBk & "Zw_Prod_PrestaShop
                        Inner Join MAEST On KOPR = Codigo And EMPRESA = '" & ModEmpresa & "' 
                        Where Sitio = '" & _Sitio & "'
                        Group By Sitio,Id_product,Codigo,Descripcion,Stock,Precio,Active,Usar_Padre,Precio_Rd,Stock_Rd,Primario,FH_Actualizacion,FH_Revision"

        Consulta_Sql = "Select Sitio,Id_product,Codigo,Descripcion,Stock,Precio,Active,Usar_Padre,Isnull(Sum(STFI1),0) As Stock_Rd,Precio_Rd,Primario,FH_Actualizacion,FH_Revision
                        From " & _Global_BaseBk & "Zw_Prod_PrestaShop
                        Left Join MAEST On KOPR = Codigo And EMPRESA = '" & ModEmpresa & "' 
                        Where Sitio = '" & _Sitio & "'
                        Group By Sitio,Id_product,Codigo,Descripcion,Stock,Precio,Active,Usar_Padre,Precio_Rd,Stock_Rd,Primario,FH_Actualizacion,FH_Revision"

        _Ds = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Tbl_Productos = _Ds.Tables(0)
        _Dv = _Tbl_Productos.DefaultView

        With Grilla

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            Dim _Columna As String

            _Columna = "Id_product"
            .Columns(_Columna).HeaderText = "Id PS"
            .Columns(_Columna).Width = 60
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "Codigo"
            .Columns(_Columna).HeaderText = "Código"
            .Columns(_Columna).Width = 100
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "Descripcion"
            .Columns(_Columna).HeaderText = "Descripción"
            .Columns(_Columna).Width = 330
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Txt_Id_product.DataBindings.Add("text", _Tbl_Productos, "Id_product")

        Txt_Codigo.DataBindings.Add("text", _Tbl_Productos, "Codigo")
        Txt_Descripcion.DataBindings.Add("text", _Tbl_Productos, "Descripcion")

        Lbl_Stock_Rd.DataBindings.Add("Text", _Tbl_Productos, "Stock_Rd", True, 0, 0, "N0")
        Lbl_Precio_Rd.DataBindings.Add("Text", _Tbl_Productos, "Precio_Rd", True, 0, 0, "C0")

        Chk_Primario.DataBindings.Add("Checked", _Tbl_Productos, "Primario")
        Chk_Active.DataBindings.Add("Checked", _Tbl_Productos, "Active")

        Dtp_FH_Actualizacion.DataBindings.Add("Value", _Tbl_Productos, "FH_Actualizacion")
        Dtp_FH_Revision.DataBindings.Add("Value", _Tbl_Productos, "FH_Revision")


    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_product As Integer = _Fila.Cells("Id_product").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Sitio As String = _Fila.Cells("Sitio").Value
        Dim _Grabar As Boolean

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'")

        If Not CBool(_Reg) Then

            MessageBoxEx.Show(Me, "Producto no existe en Random, Código: " & _Codigo.Trim & vbCrLf &
                              "La referencia en Prestashop no coincide con algún producto en la base de datos" & vbCrLf & vbCrLf &
                              "Debe hacer lo siguiente: Ir al sitio web y cambiar el código de la referencia por el código Random que corresponde y" & vbCrLf &
                              "luego cambiar el código en el siguiente formulario por el código Random y grabar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Dim Fm As New Frm_Prestashop_Producto(_Sitio, _Id_product)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Fila.Cells("Codigo").Value = Fm.Txt_Codigo.Text
        Fm.Dispose()

    End Sub

    Private Sub Txt_Buscar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Buscar.TextChanged
        _Dv.RowFilter = String.Format("Id_product+Codigo+Descripcion Like '%{0}%'", Txt_Buscar.Text)
    End Sub

    Private Sub Chk_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Frm_Prestashop_Productos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
