Imports DevComponents.DotNetBar

Public Class Frm_Prestashop_Producto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Producto As DataTable
    Dim _Row_Producto As DataRow
    Dim _Tbl_Hijos As DataTable
    Dim _Grabar As Boolean

    Dim _Row_Padre As DataRow
    Dim _Sitio As String

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Row_Producto As DataRow
        Get
            Return _Tbl_Producto.Rows(0)
        End Get
        Set(value As DataRow)
            _Row_Producto = value
        End Set
    End Property

    Public Property Sitio As String
        Get
            Return _Sitio
        End Get
        Set(value As String)
            _Sitio = value
        End Set
    End Property

    Public Sub New(Sitio As String, Id_product As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                        Where Sitio = '" & Sitio & "' And Id_product = " & Id_product

        Dim _Row_Prod = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Codigo = _Row_Prod.Item("Codigo")

        _Sitio = Sitio

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'")

        If CBool(_Reg) Then

            Consulta_Sql = "Select Sitio,Id_product,Codigo,Descripcion,NOKOPR,Stock,Precio,Active,Usar_Padre,Sum(MAEST.STFI1) As Stock_Rd,Precio_Rd,Primario,FH_Actualizacion,FH_Revision
                            From " & _Global_BaseBk & "Zw_Prod_PrestaShop
                            Inner Join MAEST On MAEST.KOPR = Codigo And EMPRESA = '" & ModEmpresa & "' 
                            Inner Join MAEPR On MAEPR.KOPR = Codigo        
                            Where Sitio = '" & _Sitio & "' And Id_product = " & Id_product & "
                            Group By Sitio,Id_product,Codigo,Descripcion,NOKOPR,Stock,Precio,Active,Usar_Padre,Precio_Rd,Stock_Rd,Primario,FH_Actualizacion,FH_Revision"
        Else

            Consulta_Sql = "Select Sitio,Id_product,Codigo,Descripcion,Descripcion As NOKOPR,0 As Stock,0 As Precio,0 As Active,0 As Usar_Padre,
                            0 As Stock_Rd,0 As Precio_Rd,0 As Primario,FH_Actualizacion,FH_Revision
                            From " & _Global_BaseBk & "Zw_Prod_PrestaShop
                            Where Sitio = '" & _Sitio & "' And Id_product = " & Id_product

            Btn_Hijos.Enabled = False
            Txt_Codigo.ReadOnly = False
            Chk_Active.Enabled = False
            Chk_Primario.Enabled = False

        End If

        _Tbl_Producto = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Me.Text = "PRESTASHOP: " & Sitio
        Sb_Color_Botones_Barra(Bar1)
        Sb_Abrir_Productos()

    End Sub

    Private Sub Frm_Prestashop_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Sb_Abrir_Productos()

        Txt_Id_product.DataBindings.Add("text", _Tbl_Producto, "Id_product")

        Txt_Codigo.DataBindings.Add("text", _Tbl_Producto, "Codigo")
        Txt_Descripcion.DataBindings.Add("text", _Tbl_Producto, "Descripcion")

        Lbl_Stock_Rd.DataBindings.Add("Text", _Tbl_Producto, "Stock_Rd", True, 0, 0, "N0")
        Lbl_Precio_Rd.DataBindings.Add("Text", _Tbl_Producto, "Precio_Rd", True, 0, 0, "C0")

        Chk_Primario.DataBindings.Add("Checked", _Tbl_Producto, "Primario")
        Chk_Active.DataBindings.Add("Checked", _Tbl_Producto, "Active")

        Txt_FH_Actualizacion.DataBindings.Add("text", _Tbl_Producto, "FH_Actualizacion", True, 0, Now.Date, "dd/MM/yyyy")
        Txt_FH_Revision.DataBindings.Add("text", _Tbl_Producto, "FH_Revision", True, 0, Now.Date, "dd/MM/yyyy")

        Txt_Codigo.DataBindings.Add("Tag", _Tbl_Producto, "Codigo")

        Consulta_Sql = "Select Carpeta, Codigo_Hijo, Codigo_Padre,Isnull(NOKOPR,'Producto no existe!!!') As Descripcion
                        From " & _Global_BaseBk & "Zw_Prod_Padres
                        Left Join MAEPR On KOPR = Codigo_Padre
                        Where Codigo_Hijo = '" & _Tbl_Producto.Rows(0).Item("Codigo") & "' "
        _Row_Padre = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Padre) Then
            Txt_Padre.Text = _Row_Padre.Item("Codigo_Padre").ToString.Trim & "-" & _Row_Padre.Item("Descripcion").ToString.Trim
        Else
            Txt_Padre.Text = String.Empty
        End If

        Sb_Actualizar_Hijos()

    End Sub

    Sub Sb_Actualizar_Hijos()

        Txt_Hijos.Text = String.Empty

        Consulta_Sql = "Select Codigo_Hijo As Codigo,Cast(1 As Bit) As Chk From " & _Global_BaseBk & "Zw_Prod_Padres Where Codigo_Padre = '" & _Tbl_Producto.Rows(0).Item("Codigo") & "'"
        _Tbl_Hijos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Contador = 1

        For Each _Fila As DataRow In _Tbl_Hijos.Rows

            Txt_Hijos.Text += _Fila.Item("Codigo").ToString.Trim

            If _Contador <> _Tbl_Hijos.Rows.Count Then
                Txt_Hijos.Text += " - "
            End If

            _Contador += 1

        Next

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & Txt_Codigo.Text & "'")

        If CBool(_Reg) Then

            '_Reg = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_PrestaShop",
            '                                      "Id_product = " & Txt_Id_product.Text & " And Codigo = '" & Txt_Codigo.Text & "' And Sitio = '" & _Sitio & "'"))

            'If _Reg Then

            '    MessageBoxEx.Show(Me, "Este código ya tiene un ID_Producto en la base de Prestashop, no puede crear 2 producto iguales", "Validación",
            '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

            '    Txt_Codigo.Text = Row_Producto.Item("Codigo")
            '    Txt_Codigo.Focus()

            '    Return

            'End If

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set 
                        Codigo = '" & Txt_Codigo.Text.Trim & "',
                        Active = " & Convert.ToInt32(Chk_Active.Checked) & ",
                        Primario = " & Convert.ToInt32(Chk_Primario.Checked) & "
                        Where Id_product = " & Txt_Id_product.Text

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                            Where Sitio = '" & _Sitio & "' And Codigo = '" & Txt_Codigo.Text & "'"
                Dim _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_Sql)

                Sb_Actualizar_Prestashop(False, _Tbl_Productos)

                _Grabar = True

            End If

        Else

            MessageBoxEx.Show(Me, "Producto no existe en Random Código: " & Txt_Codigo.Text.Trim & vbCrLf &
                         "La referencia en Prestashop no coincide con algún producto en la base de datos" & vbCrLf & vbCrLf &
                         "Debe hacer lo siguiente: Ir al sitio web y cambiar el código de la referencia por el código Random que corresponde." & vbCrLf &
                         "Luego cambiar el código y grabar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Txt_Codigo.Text = Row_Producto.Item("Codigo")

        End If

        Me.Close()

    End Sub

    Private Sub Btn_Hijos_Click(sender As Object, e As EventArgs) Handles Btn_Hijos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN' And KOPR <> '" & Txt_Codigo.Text.Trim & "'" & Space(1)

        If Not IsNothing(_Row_Padre) Then
            Dim _Codigo_Padre = _Row_Padre.Item("Codigo_Padre").ToString.Trim
            _Sql_Filtro_Condicion_Extra += "And KOPR <> '" & _Codigo_Padre & "'"
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Hijos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False,, False) Then

            _Tbl_Hijos = _Filtrar.Pro_Tbl_Filtro

            Dim _Sitio = Row_Producto.Item("Sitio")

            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Prod_Padres Where Carpeta = '" & _Sitio & "' And Codigo_Padre = '" & Txt_Codigo.Text & "'" & vbCrLf

            If Not IsNothing(_Tbl_Hijos) Then

                For Each _Fila As DataRow In _Tbl_Hijos.Rows

                    Dim _Codigo_Hijo = _Fila.Item("Codigo").ToString.Trim
                    Consulta_Sql += "Insert Into " & _Global_BaseBk & "Zw_Prod_Padres (Carpeta,Codigo_Hijo,Codigo_Padre) Values" & Space(1) &
                                    "('" & _Sitio & "','" & _Codigo_Hijo & "','" & Txt_Codigo.Text & "')" & vbCrLf

                Next

            End If

            If Not String.IsNullOrEmpty(Consulta_Sql) Then
                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    Sb_Actualizar_Hijos()
                End If
            End If

        End If

    End Sub

    Sub Sb_Actualizar_Prestashop(_Actualizar_Todo As Boolean, _Tbl_Productos As DataTable)

        Dim _Cancelar As Boolean

        Try

            Btn_Grabar.Enabled = True
            Me.ControlBox = False
            Me.Refresh()

            Dim _Class_Prestashop As New Class_Prestashop(Sitio)

            If Not IsNothing(_Tbl_Productos) Then
                _Tbl_Productos = _Class_Prestashop.Fx_Tbl_Productos_Prestashop(_Class_Prestashop.Sitio, _Tbl_Productos, "Codigo")
            End If

            '_Class_Prestashop.Progress_Canti = Progress_Canti
            '_Class_Prestashop.Progress_Porcent = Progress_Porcent

            '_Class_Prestashop.Etiqueta1 = Lbl_Estado
            '_Class_Prestashop.Etiqueta2 = Lbl_Producto
            _Class_Prestashop.Sb_Insertar_Nuevos_Productos_Desde_Prestashop_Hacia_Tabla_Prod_PrestaShop(_Actualizar_Todo)

            _Class_Prestashop.Sb_Actualizar_Tabla_Prod_PrestaShop(_Tbl_Productos)
            _Cancelar = _Class_Prestashop.Cancelar

            If Not _Cancelar Then
                _Class_Prestashop.Sb_Actualizar_Datos_En_Prestashop(_Tbl_Productos, _Actualizar_Todo)
                _Cancelar = _Class_Prestashop.Cancelar
            End If

            If _Cancelar Then
                Throw New System.Exception("Acción cancelada por el usuario")
            Else

                Me.Refresh()
                _Class_Prestashop.Sb_Activar_Desactivar_Datos_En_Prestashop()

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Btn_Grabar.Enabled = True
            Me.ControlBox = True
            Me.Refresh()
        End Try

    End Sub

    Private Sub Frm_Prestashop_Producto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
