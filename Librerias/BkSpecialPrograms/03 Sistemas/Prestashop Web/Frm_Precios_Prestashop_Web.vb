Imports DevComponents.DotNetBar
Imports MySql.Data.MySqlClient
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Precios_Prestashop_Web

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DatosConex As New ConexionBK
    Dim _Cadena_Conexion_MySql As String
    Dim _Row_Prestashop As DataRow
    Dim _Cn_MySql As MySqlConnection
    Dim _Unidad As Integer

    Dim _Tbl_ps_product As DataTable
    Dim _Tbl_ps_product_Nuevos As DataTable

    Dim _TblProductos_Web As DataTable

    Dim _Cancelar As Boolean

    Enum Tipo_Proceso
        Actualizar_Precios
        Actualizar_Stock
        Actualizar_Cosigos_Alternativos
        Actualizar_Precios_Y_Stock
    End Enum

    Dim _Tipo_Proceso As Tipo_Proceso

    Dim _Class_Prestashop As Class_Prestashop

    Public Property Pro_Tbl_Productos_Web() As DataTable
        Get
            Return _TblProductos_Web
        End Get
        Set(ByVal value As DataTable)
            _TblProductos_Web = value
        End Set
    End Property

    Public Property Pro_Row_Presatshop() As DataRow
        Get
            Return _Row_Prestashop
        End Get
        Set(ByVal value As DataRow)
            _Row_Prestashop = value
        End Set
    End Property

    Public Property Pro_Cadena_Conexion_MySql() As String
        Get
            Return _Cadena_Conexion_MySql
        End Get
        Set(ByVal value As String)
            _Cadena_Conexion_MySql = value
        End Set
    End Property

    Public Sub New(ByVal New_TblPrecios As DataTable, ByVal New_Tipo_Proceso As Tipo_Proceso)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _TblProductos_Web = New_TblPrecios
        _Tipo_Proceso = New_Tipo_Proceso
        Sb_Color_Botones_Barra(Bar2)

    End Sub


    Private Sub Frm_ActulizarDsWeb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Nombre_Pagina As String = _Row_Prestashop.Item("Nombre_Pagina")

        If _Tipo_Proceso = Tipo_Proceso.Actualizar_Cosigos_Alternativos Then

            Me.Text = "Actualización de códigos alternativos, PRESTASHOP " & _Nombre_Pagina
            Btn_Actualizar_Productos.Text = "Act. Códigos Alternativos"
            Btn_Actualizar_Precios_Stock.Visible = False

        ElseIf _Tipo_Proceso = Tipo_Proceso.Actualizar_Precios Then

            Me.Text = "Actualización de precios, PRESTASHOP"
            Btn_Actualizar_Productos.Text = "Levantar precios en la PrestaShop"

        ElseIf _Tipo_Proceso = Tipo_Proceso.Actualizar_Stock Then

            Me.Text = "Actualización de stock, PRESTASHOP"

            Consulta_sql = "Select Distinct KOPR as Codigo,NOKOPRAL as Descripcion,KOPRAL AS Id_Web," &
                           "IsNull((Select SUM(STFI1) From MAEST MS Where MS.KOPR = TD.KOPR),0) As Stock" & vbCrLf &
                           "From TABCODAL TD Where KOEN = 'PRESTASHOP'"

            _TblProductos_Web = _Sql.Fx_Get_Tablas(Consulta_sql)

            Btn_Actualizar_Productos.Text = "Levantar stock en la PrestaShop"

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Exportar_ID_Web_Referencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_ID_Web_Referencia.Click

        Dim DaMySql As MySqlDataAdapter
        Dim DsMySql As New DataSet

        Consulta_sql = "Select id_product,reference from ps_product"

        'DaMySql = New MySqlDataAdapter(Consulta_sql, _Cn_MySql)

        Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

        'Try
        'DaMySql.Fill(DsMySql, 0)

        Dim TblMySql As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_sql) ' DsMySql.Tables(0) '00300080

        If TblMySql.Rows.Count Then
            ExportarTabla_JetExcel_Tabla(TblMySql, Me, "Productos WEB")
        End If

    End Sub

    Private Sub Btn_Detener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Detener.Click
        _Class_Prestashop.Cancelar = True
    End Sub


    Sub Sb_Actualizar_Precios_PS()

        Btn_Actualizar_Productos.Visible = False
        Btn_Exportar_ID_Web_Referencia.Visible = False
        Me.ControlBox = False
        Btn_Detener.Visible = True

        Me.Refresh()


        Dim dt As New DataTable("Tabla")
        Dim dr As DataRow

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Precio", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Id_Web", System.Type.[GetType]("System.String"))


        Dim _Cant_Encontrados As Long = 0

        Progress_Porcent.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
        Progress_Canti.Maximum = _TblProductos_Web.Rows.Count

        Dim Contador As Long = 0
        Progress_Canti.Value = 0
        Progress_Porcent.Value = 0


        For Each Fila As DataRow In _TblProductos_Web.Rows
            System.Windows.Forms.Application.DoEvents()

            Dim _Fl As Integer = 0
            Dim _Codigo As String = Trim(Fila.Item("Codigo"))
            Dim _Descripcion As String = Fila.Item("Descripcion")
            Dim _Valor As Double = Fila.Item("Precio")
            Dim _Select As Boolean = Fila.Item("Select")

            Dim _ID_Producto As String = Trim(_Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL", "KOEN = 'PRESTASHOP' AND KOPR = '" & _Codigo & "'"))

            Lbl_Producto.Text = "Producto: " & _Descripcion

            If _Select Then
                If Not String.IsNullOrEmpty(_ID_Producto) Then

                    dr = dt.NewRow()
                    dr("Codigo") = _Codigo
                    dr("Descripcion") = _Descripcion
                    dr("Precio") = _Valor
                    dr("Id_Web") = _ID_Producto
                    dt.Rows.Add(dr)

                    Consulta_sql =
                    "Update ps_product_shop set price = " & De_Num_a_Tx_01(_Valor) & vbCrLf &
                    "Where id_product = " & Trim(_ID_Producto)
                    Dim query As New MySqlCommand(Consulta_sql, _Cn_MySql)

                    _Fl = query.ExecuteNonQuery()

                    Consulta_sql =
                    "Update ps_product set price = " & De_Num_a_Tx_01(_Valor) & vbCrLf &
                    "Where id_product = " & Trim(_ID_Producto) & vbCrLf

                    query = New MySqlCommand(Consulta_sql, _Cn_MySql)
                    _Fl += query.ExecuteNonQuery()

                    If _Fl > 0 Then
                        _Cant_Encontrados += 1
                    End If

                End If
            End If


            Lbl_Estado.Text = "Productos actualizados: " &
                              FormatNumber(_Cant_Encontrados, 0) & " de " & FormatNumber(_TblProductos_Web.Rows.Count, 0)

            Contador += 1
            Progress_Porcent.Value = ((Contador * 100) / _TblProductos_Web.Rows.Count) 'Mas
            Progress_Canti.Value += 1

            If _Cancelar Then
                If MessageBoxEx.Show(Me, "¿Esta seguro de detener el proceso?", "Detener proceso",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Exit For
                Else
                    _Cancelar = False
                End If
            End If

        Next

        Progress_Canti.Value = 0
        Progress_Porcent.Value = 0

        _Cn_MySql.Close()
        _Cn_MySql.Dispose()

        If _Cancelar Then
            MessageBoxEx.Show(Me, "Proceso detenido por el usuario", "Actualizar precios Web",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, "Proceso terminado", "Actualizar precios Web", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If dt.Rows.Count Then
            ExportarTabla_JetExcel_Tabla(dt, Me, "Productos actualizados en la WEB")
        End If

        Btn_Actualizar_Productos.Visible = True
        Btn_Exportar_ID_Web_Referencia.Visible = True
        Me.ControlBox = True
        Btn_Detener.Visible = False

        Me.Refresh()

        _Cancelar = False


    End Sub

    Sub Sb_Actualizar_Stock_PS()

        'Fx_Abrir_Conexion_WebMySql()

        Btn_Actualizar_Productos.Visible = False
        Btn_Exportar_ID_Web_Referencia.Visible = False
        Me.ControlBox = False
        Btn_Detener.Visible = True

        Me.Refresh()


        Dim dt As New DataTable("Tabla")
        Dim dr As DataRow

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Stock", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Id_Web", System.Type.[GetType]("System.String"))


        Dim _Cant_Encontrados As Long = 0

        Progress_Porcent.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
        Progress_Canti.Maximum = _TblProductos_Web.Rows.Count

        Dim Contador As Long = 0
        Progress_Canti.Value = 0
        Progress_Porcent.Value = 0


        For Each Fila As DataRow In _TblProductos_Web.Rows
            System.Windows.Forms.Application.DoEvents()

            Dim _Fl As Integer = 0
            Dim _Codigo As String = Trim(Fila.Item("Codigo"))
            Dim _Descripcion As String = Fila.Item("Descripcion")

            Dim _Stock As Double = Fila.Item("Stock") '_Sql.Fx_Trae_Dato(, "SUM(STFI1)", "MAEST", "KOPR = '" & _Codigo & "'") 'Fila.Item("Stock")
            Dim _ID_Producto As String = Fila.Item("Id_Web") 'String.Empty

            If _Stock < 0 Then _Stock = 0

            Lbl_Producto.Text = "Producto: " & _Descripcion
            If Not String.IsNullOrEmpty(_ID_Producto) Then

                dr = dt.NewRow()
                dr("Codigo") = _Codigo
                dr("Descripcion") = _Descripcion
                dr("Stock") = _Stock
                dr("Id_Web") = _ID_Producto
                dt.Rows.Add(dr)

                Consulta_sql =
                "Update ps_stock_available set quantity= " & De_Num_a_Tx_01(_Stock) & vbCrLf &
                "Where id_product = " & Trim(_ID_Producto) & vbCrLf
                Dim query As New MySqlCommand(Consulta_sql, _Cn_MySql)

                _Fl = query.ExecuteNonQuery()


                If _Fl > 0 Then
                    _Cant_Encontrados += 1
                End If

            End If

            Lbl_Estado.Text = "Productos actualizados: " &
                              FormatNumber(_Cant_Encontrados, 0) & " de " & FormatNumber(_TblProductos_Web.Rows.Count, 0)

            Contador += 1
            Progress_Porcent.Value = ((Contador * 100) / _TblProductos_Web.Rows.Count) 'Mas
            Progress_Canti.Value += 1

            If _Cancelar Then
                If MessageBoxEx.Show(Me, "¿Esta seguro de detener el proceso?", "Detener proceso",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Exit For
                Else
                    _Cancelar = False
                End If
            End If

        Next

        Progress_Canti.Value = 0
        Progress_Porcent.Value = 0

        _Cn_MySql.Close()
        _Cn_MySql.Dispose()

        If _Cancelar Then
            MessageBoxEx.Show(Me, "Proceso detenido por el usuario", "Actualizar precios Web",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, "Proceso terminado", "Actualizar precios Web", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If dt.Rows.Count Then
            ExportarTabla_JetExcel_Tabla(dt, Me, "Productos actualizados en la WEB")
        End If

        Btn_Actualizar_Productos.Visible = True
        Btn_Exportar_ID_Web_Referencia.Visible = True
        Me.ControlBox = True
        Btn_Detener.Visible = False

        Me.Refresh()

        _Cancelar = False


    End Sub

    Sub Sb_Actualizar_Codigos_Alternativos()

        'Fx_Abrir_Conexion_WebMySql()

        Btn_Actualizar_Productos.Enabled = False
        Btn_Exportar_ID_Web_Referencia.Enabled = False
        Me.ControlBox = False
        Btn_Detener.Visible = True

        _Cancelar = False

        Try

            Me.Refresh()

            Dim dt As New DataTable("Tabla")
            Dim dr As DataRow

            'creamos las mismas columnas que hay en el dataset
            dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
            dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
            ' dt.Columns.Add("Precio", System.Type.[GetType]("System.Double"))
            dt.Columns.Add("Id_Web", System.Type.[GetType]("System.String"))
            dt.Columns.Add("Levantado", System.Type.[GetType]("System.String"))


            Dim _Cant_Encontrados As Long = 0
            Dim _Cant_NO_Encontrados As Long = 0

            Progress_Porcent.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
            Progress_Canti.Maximum = _TblProductos_Web.Rows.Count

            Dim Contador As Long = 0
            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0

            Dim _Codigo_Pagina As String = _Row_Prestashop.Item("Codigo_Pagina")

            Consulta_sql = "DELETE TABCODAL WHERE KOEN = '" & _Codigo_Pagina & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            For Each Fila As DataRow In _TblProductos_Web.Rows
                System.Windows.Forms.Application.DoEvents()

                Dim _Fl As Integer = 0
                Dim _Codigo As String = Trim(Fila.Item("Codigo"))
                Dim _Descripcion As String = String.Empty '= Fila.Item("Descripcion")
                'Dim _Valor As Double = Fila.Item("Precio")
                Dim _ID_Producto As String = Trim(Fila.Item("id_product"))
                Dim _Levantado As String = String.Empty

                Consulta_sql = "Select KOPR as Codigo,NOKOPR as Descripcion From MAEPR Where KOPR = '" & _Codigo & "'"

                Dim _TblProd As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
                If CBool(_TblProd.Rows.Count) Then

                    _Descripcion = _TblProd.Rows(0).Item("Descripcion")
                    Consulta_sql = "INSERT INTO TABCODAL (KOPRAL,NOKOPRAL,KOPR,KOEN) VALUES " &
                                  "('" & _ID_Producto & "','" & _Descripcion & "','" & _Codigo & "','" & _Codigo_Pagina & "')"

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        _Levantado = "SI"
                    Else
                        _Levantado = "NO"
                    End If

                    _Cant_Encontrados += 1

                Else
                    _Descripcion = "ZZZ NO ENCONTRADO EN RANDOM"
                    _Levantado = "NO"
                    _Cant_NO_Encontrados += 1

                    dr = dt.NewRow()
                    dr("Codigo") = _Codigo
                    dr("Descripcion") = _Descripcion
                    dr("Levantado") = _Levantado
                    dr("Id_Web") = _ID_Producto
                    dt.Rows.Add(dr)

                End If

                Lbl_Producto.Text = "Producto: " & _Descripcion

                Lbl_Estado.Text = "Productos encontrador: " &
                                  FormatNumber(_Cant_Encontrados, 0) & " de " & FormatNumber(_TblProductos_Web.Rows.Count, 0)

                Contador += 1
                Progress_Porcent.Value = ((Contador * 100) / _TblProductos_Web.Rows.Count) 'Mas
                Progress_Canti.Value += 1

                If _Cancelar Then
                    If MessageBoxEx.Show(Me, "¿Esta seguro de detener el proceso?", "Detener proceso",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Exit For
                    Else
                        _Cancelar = False
                    End If
                End If

            Next


            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0


            If _Cancelar Then
                MessageBoxEx.Show(Me, "Proceso detenido por el usuario", "Actualizar precios Web",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                MessageBoxEx.Show(Me, "Proceso terminado", "Actualizar precios Web",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                If dt.Rows.Count Then
                    MessageBoxEx.Show(Me, "Existen " & _Cant_NO_Encontrados & " productos con problemas", "Prestashop",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ExportarTabla_JetExcel_Tabla(dt, Me, "Productos No encontrados en Random vs Web")
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problemas!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Btn_Actualizar_Productos.Enabled = True
            Btn_Exportar_ID_Web_Referencia.Enabled = True
            Me.ControlBox = True
            Btn_Detener.Visible = False

            Me.Refresh()
        End Try

    End Sub

    Sub Sb_Actualizar_Precios_Y_Stock()

        Btn_Actualizar_Productos.Enabled = False
        Btn_Actualizar_Precios_Stock.Enabled = False
        Btn_Exportar_ID_Web_Referencia.Enabled = False
        Me.ControlBox = False
        Btn_Detener.Visible = True

        _Cancelar = False

        Try

            Me.Refresh()

            Dim dt As New DataTable("Tabla")
            Dim dr As DataRow

            'creamos las mismas columnas que hay en el dataset
            dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
            dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
            dt.Columns.Add("Stock", System.Type.[GetType]("System.Boolean"))
            dt.Columns.Add("Precio", System.Type.[GetType]("System.Boolean"))
            dt.Columns.Add("Log_Error", System.Type.[GetType]("System.String"))

            Dim _Cant_Encontrados As Long = 0
            Dim _Cant_NO_Encontrados As Long = 0

            Progress_Porcent.Maximum = 100
            Progress_Canti.Maximum = _TblProductos_Web.Rows.Count

            Dim Contador As Long = 0
            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0

            Dim _Codigo_Pagina As String = _Row_Prestashop.Item("Codigo_Pagina")
            Dim _Nombre_Pagina As String = _Row_Prestashop.Item("Nombre_Pagina")
            Dim _Cod_Lista As String = _Row_Prestashop.Item("Cod_Lista")

            Dim _Usar_Stock_Maximo As Boolean = _Row_Prestashop.Item("Usar_Stock_Maximo")
            Dim _Stock_Maximo As Double = _Row_Prestashop.Item("Stock_Maximo")

            If _Usar_Stock_Maximo Then

            End If

            Lbl_Estado.Text = "Productos encontrador: 0 de " & FormatNumber(_TblProductos_Web.Rows.Count, 0)

            For Each Fila As DataRow In _TblProductos_Web.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Fl As Integer = 0
                Dim _Codigo As String = Trim(Fila.Item("Codigo"))
                Dim _Descripcion As String
                Dim _Log_Error As String
                Dim _Precio As Boolean
                Dim _Stock As Boolean

                Consulta_sql = "Select KOPR as Codigo,NOKOPR as Descripcion From MAEPR Where KOPR = '" & _Codigo & "'"
                Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_Row_Producto Is Nothing) Then

                    _Descripcion = _Row_Producto.Item("Descripcion")

                    Consulta_sql = "Select Top 1 * From TABCODAL Where KOPR = '" & _Codigo & "' And KOEN = '" & _Codigo_Pagina & "'"
                    Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Fx_Precio As String =
                    Fx_Prestashop_Actualizar_Precios(_Cadena_Conexion_MySql, _Nombre_Pagina, _Codigo, _Cod_Lista, _Row_Tabcodal)

                    Dim _Fx_Stock As String =
                    Fx_Prestashop_Actualizar_Stock(_Cadena_Conexion_MySql, _Nombre_Pagina, _Codigo, _Row_Tabcodal, _Stock_Maximo)

                    _Precio = String.IsNullOrEmpty(_Fx_Precio)
                    _Stock = String.IsNullOrEmpty(_Fx_Stock)
                    _Cant_Encontrados += 1

                    _Log_Error = _Fx_Precio & Space(2) & _Fx_Stock

                Else
                    _Descripcion = ""
                    _Log_Error = "ZZZ NO ENCONTRADO EN RANDOM"
                    _Cant_NO_Encontrados += 1

                    _Precio = False
                    _Stock = False

                End If


                dr = dt.NewRow()
                dr("Codigo") = _Codigo
                dr("Descripcion") = _Descripcion
                dr("Log_Error") = _Log_Error
                dr("Stock") = _Stock
                dr("Precio") = _Precio
                dt.Rows.Add(dr)

                Lbl_Producto.Text = "Producto: " & _Descripcion

                Lbl_Estado.Text = "Productos encontrador: " &
                                  FormatNumber(_Cant_Encontrados, 0) & " de " & FormatNumber(_TblProductos_Web.Rows.Count, 0)

                Contador += 1
                Progress_Porcent.Value = ((Contador * 100) / _TblProductos_Web.Rows.Count) 'Mas
                Progress_Canti.Value += 1

                If _Cancelar Then
                    If MessageBoxEx.Show(Me, "¿Esta seguro de detener el proceso?", "Detener proceso",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Exit For
                    Else
                        _Cancelar = False
                    End If
                End If

            Next


            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0


            If _Cancelar Then
                MessageBoxEx.Show(Me, "Proceso detenido por el usuario", "Actualizar precios Web",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                MessageBoxEx.Show(Me, "Proceso terminado", "Actualizar precios Web",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                'If dt.Rows.Count Then
                'MessageBoxEx.Show(Me, "Existen " & _Cant_NO_Encontrados & " productos con problemas", "Prestashop", _
                '                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                'End If
            End If

            ExportarTabla_JetExcel_Tabla(dt, Me, _Nombre_Pagina)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problemas!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Btn_Actualizar_Productos.Enabled = True
            Btn_Actualizar_Precios_Stock.Enabled = True
            Btn_Exportar_ID_Web_Referencia.Enabled = True
            Me.ControlBox = True
            Btn_Detener.Visible = False
            Me.Refresh()
        End Try

    End Sub


    Function Fx_Prod_Con_Problemas_Prestashop() As DataTable

        ' Traer tabla con productos que existen la la Web pero no existen en Random
        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Codigo Not In (Select KOPR From MAEPR)"
        Fx_Prod_Con_Problemas_Prestashop = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Function

    Function Fx_Prestashop_Actualizar_Precios(ByVal _Cadena_Conexion_MySql As String,
                                              ByVal _Nombre_Pagina As String,
                                              ByVal _Codigo As String,
                                              ByVal _Cod_Lista As String,
                                              ByVal _Row_Tabcodal As DataRow) As String

        Try

            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)
            Dim _Cant_Encontrados As Long = 0
            Dim Contador As Long = 0

            Dim _Error As String = String.Empty

            'Consulta_sql = "Select Top 1 * From TABCODAL" & vbCrLf & _
            '               "Where KOEN = '" & _Codigo_Pagina & "' AND KOPR = '" & _Codigo & "'"
            'Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_Row_Tabcodal Is Nothing) Then

                Dim _ID_Producto As String = Trim(_Row_Tabcodal.Item("KOPRAL"))

                Dim _Row_Precios As DataRow
                Dim _Row_Lista As DataRow

                Consulta_sql = "Select Top 1 * From TABPRE Where KOLT = '" & _Cod_Lista & "' And KOPR = '" & _Codigo & "'"
                _Row_Precios = _Sql.Fx_Get_DataRow(Consulta_sql)

                Consulta_sql = "Select Top 1 * From TABPP Where KOLT = '" & _Cod_Lista & "'"
                _Row_Lista = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Valor As Double = _Row_Precios.Item("PP01UD")
                Dim _Ecuacion As String = _Row_Precios.Item("ECUACION")
                Dim _Melt As String = _Row_Lista.Item("MELT")

                If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

                    Dim _Tiene_C As Boolean = InStr(1, _Ecuacion, "<")
                    Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

                    If Not _Tiene_C Then
                        If Not _Tiene_Cor Then

                            Dim _Campo_Precio
                            Dim _Campo_Ecuacion

                            'If _UnTrans = 1 Then
                            _Campo_Precio = "PP01UD"
                            _Campo_Ecuacion = "ECUACION"
                            'Else
                            '_Campo_Precio = "PP02UD"
                            '_Campo_Ecuacion = "ECUACIONU2"
                            'End If

                            _Valor = Fx_Precio_Formula_Random(_Row_Precios, _Campo_Precio, _Campo_Ecuacion, Nothing, True, "", 1, 1)

                            If _Melt = "B" Then
                                _Valor = Math.Round(_Valor / 1.19, 6)
                            End If

                        End If
                    End If
                End If

                '_Valor = 3000

                Consulta_sql = "Update ps_product_shop set price = " & De_Num_a_Tx_01(_Valor, False, 8) & vbCrLf &
                               "Where id_product = " & Trim(_ID_Producto)
                If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                    '_Mensaje = "Tabla [ps_product] OK,"

                    Consulta_sql = "Update ps_product set price = " & De_Num_a_Tx_01(_Valor, False, 8) & vbCrLf &
                                   "Where id_product = " & Trim(_ID_Producto) & vbCrLf
                    If Not _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then
                        _Error = _Clas_Ps.Pro_Error
                        '    _Mensaje += "Tabla [ps_product_shop] OK."
                        'Else
                        '_Mensaje = "Error!! al insertar Precio"
                    End If
                Else
                    _Error = "Error!! al insertar Precio"
                End If

                '_Mensaje = "Lista: " & _Cod_Lista & ", Precio: $ " & De_Num_a_Tx_01(_Valor, False, 6) & ", " & _Mensaje
            Else
                _Error = "No Aplica"
            End If

            Return _Error

        Catch ex As Exception
            Return "Error!! al insertar Precio"
        End Try

    End Function

    Function Fx_Prestashop_Actualizar_Stock(ByVal _Cadena_Conexion_MySql As String,
                                            ByVal _Nombre_Pagina As String,
                                            ByVal _Codigo As String,
                                            ByVal _Row_Tabcodal As DataRow,
                                            ByVal _Max_Stock As Double) As String

        Dim _Error As String = String.Empty

        Try
            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

            If Not (_Row_Tabcodal Is Nothing) Then

                Dim _ID_Producto As String = _Row_Tabcodal.Item("KOPRAL")
                Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "SUM(STFI1)", "KOPR = '" & _Codigo & "'")
                Dim _Stock_Total = _Stock

                If _Stock > _Max_Stock Then _Stock = _Max_Stock

                ' _Cadena_Conexion_MySql = "Host=" '& _Host & ".;Database=" & _Base_Datos & ";Uid=" & _Usuario & ";Password=" & _Clave & ";"

                Consulta_sql = "Update ps_stock_available set quantity= " & De_Num_a_Tx_01(_Stock) & vbCrLf &
                               "Where id_product = " & Trim(_ID_Producto) & vbCrLf

                If Not _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then
                    _Error = _Clas_Ps.Pro_Error
                    'Return "Stock en Bodega: " & De_Num_a_Tx_01(_Stock_Total, False, 0) & _
                    '       ", Stock grabado: " & De_Num_a_Tx_01(_Stock, 0) & "."
                    'Else
                    'Return "Error!! al insertar Stock" '_Clas_Ps.Pro_Error & ". "
                End If
                'Else
                ' Return "No Aplica."
            End If
            Return _Error
        Catch ex As Exception
            Return "Error!! al insertar Stock"
        End Try

    End Function


    Private Sub Btn_Actualizar_Precios_Stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Precios_Stock.Click

        'Sb_Actualizar_Precios_Y_Stock()

        'Dim _Sitio As String = _Row_Prestashop.Item("Nombre_Pagina")
        'Sb_Actualizar_Datos_En_Prestashop(_Sitio)

    End Sub

    Private Sub Btn_Actualizar_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Productos.Click
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Private Sub Btn_Actualizar_Todo_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Todo.Click

        Dim _Actualizar_Todo As Boolean

        Dim _Resetear = MessageBoxEx.Show(Me, "¿Desea actualizar todos los productos reseteando la base actual?" & vbCrLf & vbCrLf &
                                          "Esto borrarar todos los productos de este sitio los actualizara nuevamente." & vbCrLf &
                                          "En resumen: Descargar completamente la base desde Prestashop hacia Bakapp" & vbCrLf & vbCrLf &
                                          "Yes = Borra base y actualiza, No = Solo actualiza los datos", "Resertear base actual",
                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If _Resetear = DialogResult.Yes Then
            _Actualizar_Todo = True
        ElseIf _Resetear = DialogResult.No Then
            _Actualizar_Todo = False
        Else
            Return
        End If

        Sb_Actualizar_Prestashop(_Actualizar_Todo, Nothing)

    End Sub

    Private Sub Btn_Actualizar_Algunos_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Algunos.Click

        Dim _Sitio As String = _Row_Prestashop.Item("Nombre_Pagina")
        Dim _Tbl_Productos As DataTable
        Dim _Procesar As Boolean

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Sitio = '" & _Sitio & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Procesar = True
            _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro

            If _Filtrar.Pro_Filtro_Todas Then
                _Tbl_Productos = Nothing
            End If

        End If

        If _Procesar Then

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

            If Convert.ToBoolean(_Tbl_Productos.Rows.Count) Then
                _Filtro_Productos = "And Codigo In " & _Filtro_Productos
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                            Where Sitio = '" & _Sitio & "'" & Space(1) & _Filtro_Productos
            _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

            Sb_Actualizar_Prestashop(True, _Tbl_Productos)

        End If

    End Sub

    Private Sub Btn_Actualizar_Solo_Con_Cambios_BD_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Solo_Con_Cambios_BD.Click

        Dim _Sitio As String = _Row_Prestashop.Item("Nombre_Pagina")
        Dim _Cod_Lista = _Row_Prestashop.Item("Cod_Lista")
        Dim _Stock_Maximo As Double = _Row_Prestashop.Item("Stock_Maximo")

        Dim _Tbl_Productos As DataTable

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Sitio = '" & _Sitio & "'"
        _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        Progress_Porcent.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
        Progress_Canti.Maximum = _Tbl_Productos.Rows.Count

        Dim Contador As Long = 0
        Progress_Canti.Value = 0
        Progress_Porcent.Value = 0

        For Each _Fila As DataRow In _Tbl_Productos.Rows

            Dim _Id_product = _Fila.Item("Id_product")
            Dim _Codigo = _Fila.Item("Codigo")
            Dim _Descripcion = _Fila.Item("Descripcion")
            Dim _Precio As Double = _Fila.Item("Precio")
            Dim _Precio_Rd As Double = Fx_Traer_Precio(_Codigo, _Cod_Lista, 1)

            Dim _Active As Boolean = _Fila.Item("active")
            'Dim _Active_Rd As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_PrestaShop", "Active",
            '                                              "Sitio = '" & _Sitio & "' And Id_product = " & _Id_product,,,, True)

            _Precio = Math.Round(_Precio, 2)
            _Precio_Rd = Math.Round(_Precio_Rd, 2)

            If _Precio_Rd = 0 Then
                _Precio_Rd = _Precio
            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set Precio_Rd = " & De_Num_a_Tx_01(_Precio_Rd, False, 5) & ",
                            FH_Actualizacion = Getdate()
                            Where Sitio = '" & _Sitio & "' And Id_product = " & _Id_product

            _Sql.Ej_consulta_IDU(Consulta_sql, False)


            Lbl_Producto.Text = "Producto: " & _Descripcion

            Lbl_Estado.Text = "Productos encontrador: " &
                              FormatNumber(Contador, 0) & " de " & FormatNumber(_Tbl_Productos.Rows.Count, 0)

            Contador += 1
            Progress_Porcent.Value = ((Contador * 100) / _Tbl_Productos.Rows.Count) 'Mas
            Progress_Canti.Value += 1

            System.Windows.Forms.Application.DoEvents()

        Next

        Dim _Codigo_Pagina = _Row_Prestashop.Item("Codigo_Pagina")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set Stock_Rd = Isnull((Select Isnull(Sum(STFI1),0)
                            From MAEST Where KOPR = Codigo And Rtrim(Ltrim(EMPRESA))+Rtrim(LTrim(KOSU))+Rtrim(LTrim(KOBO)) In" & Space(1) &
                            "(Select Rtrim(Ltrim(Empresa))+Rtrim(LTrim(Sucursal))+Rtrim(LTrim(Bodega)) 
                            From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Activo = 1)),0) 
                            Where Sitio = '" & _Sitio & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "SELECT *,Cast(0 As Float) As Stock_Actual,Cast(0 As Bit) As Mostrar 
                        Into #Paso
                        FROM " & _Global_BaseBk & "Zw_Prod_PrestaShop
                        Where Sitio = '" & _Sitio & "' 

                        --Update #Paso Set Stock_Actual = (Select Sum(STFI1) From MAEST Where KOPR = Codigo)

                        Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo From #Paso Where Stock_Actual <> Stock_Rd And Stock_Actual < " & De_Txt_a_Num_01(_Stock_Maximo, 5) & ")
                        Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo From #Paso Where Precio <> Precio_Rd)
						Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo_Padre From " & _Global_BaseBk & "Zw_Prod_Padres Where Carpeta = '" & _Sitio & "' And Codigo_Hijo In (Select Codigo From #Paso Where Mostrar = 1))
						Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo_Hijo From " & _Global_BaseBk & "Zw_Prod_Padres Z2 Where Carpeta = '" & _Sitio & "' And Codigo_Padre In (Select Codigo From #Paso Where Mostrar = 1))

                        Select * From #Paso Where Mostrar = 1
                        Drop Table #Paso"

        _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Productos.Rows.Count) Then
            Sb_Actualizar_Prestashop(False, _Tbl_Productos)
        Else

            MessageBoxEx.Show(Me, "No se encontraron cambios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If

    End Sub

    Sub Sb_Actualizar_Prestashop(_Actualizar_Todo As Boolean, _Tbl_Productos As DataTable)

        Dim _Sitio As String = _Row_Prestashop.Item("Nombre_Pagina")
        Dim _Cancelar As Boolean

        Try

            Btn_Detener.Visible = True
            Btn_Actualizar_Productos.Enabled = False
            Me.ControlBox = False

            _Class_Prestashop = New Class_Prestashop(_Sitio)

            If _Actualizar_Todo Then
                _Tbl_Productos = _Class_Prestashop.Fx_Tbl_Productos_Prestashop(_Class_Prestashop.Sitio, _Tbl_Productos, "Codigo")
            Else
                If Not IsNothing(_Tbl_Productos) Then
                    _Tbl_Productos = _Class_Prestashop.Fx_Tbl_Productos_Prestashop(_Class_Prestashop.Sitio, _Tbl_Productos, "Codigo")
                End If
            End If

            _Class_Prestashop.Progress_Canti = Progress_Canti
            _Class_Prestashop.Progress_Porcent = Progress_Porcent

            _Class_Prestashop.Etiqueta1 = Lbl_Estado
            _Class_Prestashop.Etiqueta2 = Lbl_Producto

            If Not IsNothing(_Tbl_Productos) Then

                Dim _Filtro_Prod = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")
                Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR In " & _Filtro_Prod)

                If _Reg > 20 Then '_Tbl_Productos.Rows.Count > 20 Then
                    _Class_Prestashop.Sb_Insertar_Nuevos_Productos_Desde_Prestashop_Hacia_Tabla_Prod_PrestaShop(_Actualizar_Todo)
                End If
            End If

            _Class_Prestashop.Sb_Actualizar_Tabla_Prod_PrestaShop(_Tbl_Productos)
            _Cancelar = _Class_Prestashop.Cancelar

            If Not _Cancelar Then
                _Class_Prestashop.Sb_Actualizar_Datos_En_Prestashop(_Tbl_Productos, _Actualizar_Todo)
                _Cancelar = _Class_Prestashop.Cancelar
            End If

            If _Cancelar Then
                Throw New System.Exception("Acción cancelada por el usuario")
            Else

                Btn_Detener.Enabled = False
                Me.Refresh()
                _Class_Prestashop.Sb_Activar_Desactivar_Datos_En_Prestashop()

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Btn_Detener.Visible = False
            Btn_Actualizar_Productos.Enabled = True
            Me.ControlBox = True
            Me.Refresh()
        End Try

    End Sub


    Function Fx_Traer_Precio(_Codigo As String, _Cod_Lista As String, _UnTrans As Integer) As Double

        Dim _Row_Precios As DataRow
        Dim _Row_Lista As DataRow

        Consulta_sql = "Select Top 1 * From TABPRE Where KOLT = '" & _Cod_Lista & "' And KOPR = '" & _Codigo & "'"
        _Row_Precios = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Precios) Then Return 0

        Consulta_sql = "Select Top 1 * From TABPP Where KOLT = '" & _Cod_Lista & "'"
        _Row_Lista = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Lista) Then Return 0

        Dim _Precio As Double = _Row_Precios.Item("PP0" & _UnTrans & "UD")
        Dim _Ecuacion As String = _Row_Precios.Item("ECUACION")
        Dim _Melt As String = _Row_Lista.Item("MELT")

        If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

            Dim _Tiene_C As Boolean = InStr(1, _Ecuacion, "<")
            Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

            If Not _Tiene_C Then

                If Not _Tiene_Cor Then

                    Dim _Campo_Precio
                    Dim _Campo_Ecuacion

                    If _UnTrans = 1 Then
                        _Campo_Precio = "PP01UD"
                        _Campo_Ecuacion = "ECUACION"
                    Else
                        _Campo_Precio = "PP02UD"
                        _Campo_Ecuacion = "ECUACIONU2"
                    End If

                    _Precio = Fx_Precio_Formula_Random(_Row_Precios, _Campo_Precio, _Campo_Ecuacion, Nothing, True, "", 1, 1)

                    If _Melt = "B" Then
                        _Precio = Math.Round(_Precio / 1.19, 6)
                    End If

                End If

            End If

        End If

        Return _Precio

    End Function

End Class
