Imports DevComponents.DotNetBar
Public Class Frm_Conexiones_Prestashop

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 10), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Conexiones_Prestashop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Codigo_Pagina").Width = 120
            .Columns("Codigo_Pagina").HeaderText = "Cód. Pagina"
            .Columns("Codigo_Pagina").Visible = True

            .Columns("Nombre_Pagina").Width = 500
            .Columns("Nombre_Pagina").HeaderText = "Nombre Pagina"
            .Columns("Nombre_Pagina").Visible = True

        End With

    End Sub

    Private Sub Btn_Crear_Conexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Conexion.Click

        Dim Fm As New Frm_Conexion_Web_Prestashop
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Editar_conexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_conexion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo_Pagina = _Fila.Cells("Codigo_Pagina").Value

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_PrestaShop Where Codigo_Pagina = '" & _Codigo_Pagina & "'"
        Dim _Row_PrestaShop As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_Conexion_Web_Prestashop
        Fm.Pro_Row_PrestaShop = _Row_PrestaShop
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            Sb_Actualizar_Grilla()
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Eliminar_Conexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_Conexion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo_Pagina = _Fila.Cells("Codigo_Pagina").Value

        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar esta consulta?", "Eliminar consulta",
                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_PrestaShop Where Codigo_Pagina = '" & _Codigo_Pagina & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla.Rows.RemoveAt(_Fila.Index)
            End If

        End If
    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Grilla_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Call Btn_Editar_conexion_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_Actualizar_Tabcodal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Tabcodal.Click

        Sb_Actualizar_Tabla_Prod_PrestaShop()

        'Return

        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        'Dim _Codigo_Pagina = _Fila.Cells("Codigo_Pagina").Value

        'Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_PrestaShop Where Codigo_Pagina = '" & _Codigo_Pagina & "'"
        'Dim _Row_PrestaShop As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Dim Fm As New Frm_Conexion_Web_Prestashop
        'Fm.Pro_Row_PrestaShop = _Row_PrestaShop
        'Dim _Cadena_de_conexion_MySql = Fm.Fx_Cadena_Conexion_MySql
        'Fm.Dispose()

        'Dim _Sql_MySql As New Class_MySQL(_Cadena_de_conexion_MySql)

        '_Sql_MySql.Sb_Abrir_Conexion()
        'Dim _Error As String = _Sql_MySql.Pro_Error

        'If String.IsNullOrEmpty(_Error) Then

        '    Consulta_sql = "Select id_product,reference As Codigo from ps_product"
        '    Dim _Tbl_Productos_Web As DataTable = _Sql_MySql.Fx_Get_Datatable(Consulta_sql)

        '    Dim Fm_Ps As New Frm_Precios_Prestashop_Web(Nothing, Frm_Precios_Prestashop_Web.Tipo_Proceso.Actualizar_Cosigos_Alternativos)
        '    Fm_Ps.Pro_Cadena_Conexion_MySql = _Cadena_de_conexion_MySql
        '    Fm_Ps.Pro_Row_Presatshop = _Row_PrestaShop
        '    Fm_Ps.Pro_Tbl_Productos_Web = _Tbl_Productos_Web
        '    Fm_Ps.ShowDialog(Me)
        '    Fm_Ps.Dispose()

        'Else
        '    MessageBoxEx.Show(Me, "Problemas con la conexión a la base de datos MySQL." & vbCrLf &
        '                      "Cadena de conexión: " & _Cadena_de_conexion_MySql & vbCrLf & vbCrLf &
        '                      "Error: " & _Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

    End Sub

    Sub Sb_Actualizar_Tabla_Prod_PrestaShop()


        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo_Pagina = _Fila.Cells("Codigo_Pagina").Value

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_PrestaShop Where Codigo_Pagina = '" & _Codigo_Pagina & "'"
        Dim _Row_PrestaShop As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_Conexion_Web_Prestashop
        Fm.Pro_Row_PrestaShop = _Row_PrestaShop
        Dim _Cadena_de_conexion_MySql = Fm.Fx_Cadena_Conexion_MySql
        Fm.Dispose()

        Dim _Sql_MySql As New Class_MySQL(_Cadena_de_conexion_MySql)

        _Sql_MySql.Sb_Abrir_Conexion()
        Dim _Error As String = _Sql_MySql.Pro_Error

        If String.IsNullOrEmpty(_Error) Then

            Consulta_sql = "Select Id_product From " & _Global_BaseBk & "Zw_Prod_PrestaShop"
            Dim _Tbl_Prod_PrestaShop As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Filtro_id_product As String = Generar_Filtro_IN(_Tbl_Prod_PrestaShop, "", "id_product", True, False, "")

            If Convert.ToBoolean(_Tbl_Prod_PrestaShop.Rows.Count) Then
                _Filtro_id_product = "Where P1.id_product In " & _Filtro_id_product
            Else
                _Filtro_id_product = String.Empty
            End If

            Dim _Nombre_Pagina = _Row_PrestaShop.Item("Nombre_Pagina")

            Consulta_sql = "Select '" & _Nombre_Pagina & "' As Nombre_Pagina,P1.id_product,reference As Codigo,P4.name as Descripcion,P2.price As Precio,P3.quantity As Cantidad,P1.active 
                            From ps_product P1 
                            inner Join ps_product_shop P2 On P1.id_product = P2.id_product
                            inner Join ps_stock_available P3 On P1.id_product = P3.id_product
                            inner join ps_product_lang P4 On P1.id_product = P4.id_product" & vbCrLf &
                            _Filtro_id_product

            Dim _Tbl_Productos_Web As DataTable = _Sql_MySql.Fx_Get_Datatable(Consulta_sql)

            If IsNothing(_Tbl_Productos_Web) Then
                MessageBoxEx.Show(Me, "Problemas al querer importar los productos desde la conexión a la base de datos MySQL." & vbCrLf &
                  "Cadena de conexión: " & _Cadena_de_conexion_MySql & vbCrLf & vbCrLf &
                  "Error: " & _Sql_MySql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Tbl_Productos_Web.Rows.Count Then

                Dim Fm_Ps As New Frm_Precios_Prestashop_Web(Nothing, Frm_Precios_Prestashop_Web.Tipo_Proceso.Actualizar_Cosigos_Alternativos)
                Fm_Ps.Pro_Cadena_Conexion_MySql = _Cadena_de_conexion_MySql
                Fm_Ps.Pro_Row_Presatshop = _Row_PrestaShop
                Fm_Ps.Pro_Tbl_Productos_Web = _Tbl_Productos_Web
                Fm_Ps.ShowDialog(Me)
                Fm_Ps.Dispose()

            End If

        Else
            MessageBoxEx.Show(Me, "Problemas con la conexión a la base de datos MySQL." & vbCrLf &
                              "Cadena de conexión: " & _Cadena_de_conexion_MySql & vbCrLf & vbCrLf &
                              "Error: " & _Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub Btn_Ver_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Productos.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Sitio = _Fila.Cells("Nombre_Pagina").Value

        Dim Fm As New Frm_Prestashop_Productos(_Sitio)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Bodegas_Click(sender As Object, e As EventArgs) Handles Btn_Bodegas.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo_Pagina = _Fila.Cells("Codigo_Pagina").Value
        Dim _Sitio = _Fila.Cells("Nombre_Pagina").Value

        Dim Fm As New Frm_Prestashop_Bodegas(_Codigo_Pagina)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
