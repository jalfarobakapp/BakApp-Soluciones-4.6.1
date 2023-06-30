Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports iTextSharp.text.pdf

Public Class Cl_Prestashop_Orders

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Lbl_Estado As String
    Dim _Procesando As Boolean
    Dim _Fecha_Revision As Date
    Dim _Nombre_Equipo As String
    Dim _Path As String
    Dim _Solo_Marcar_No_Imprimir As Boolean

    Dim _Segundos_Correo As Integer
    Dim _Input_Tiempo_Correo As Integer

    Public Property Lbl_Estado As String
        Get
            Return _Lbl_Estado
        End Get
        Set(value As String)
            _Lbl_Estado = value
        End Set
    End Property

    Public Property Procesando As Boolean
        Get
            Return _Procesando
        End Get
        Set(value As Boolean)
            _Procesando = value
        End Set
    End Property

    Public Property Fecha_Revision As Date
        Get
            Return _Fecha_Revision
        End Get
        Set(value As Date)
            _Fecha_Revision = value
        End Set
    End Property

    Public Property Nombre_Equipo As String
        Get
            Return _Nombre_Equipo
        End Get
        Set(value As String)
            _Nombre_Equipo = value
        End Set
    End Property

    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property

    Public Property Segundos_Correo As Integer
        Get
            Return _Segundos_Correo
        End Get
        Set(value As Integer)
            _Segundos_Correo = value
        End Set
    End Property

    Public Property Input_Tiempo_Correo As Integer
        Get
            Return _Input_Tiempo_Correo
        End Get
        Set(value As Integer)
            _Input_Tiempo_Correo = value
        End Set
    End Property

    Public Property Solo_Marcar_No_Imprimir As Boolean
        Get
            Return _Solo_Marcar_No_Imprimir
        End Get
        Set(value As Boolean)
            _Solo_Marcar_No_Imprimir = value
        End Set
    End Property

    Public Property Log_Registro As String
    Public Property Ejecutar As Boolean
    Public Sub New()

        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True

        _Lbl_Estado = "Monitoreo Cola Impresión Automática"

    End Sub

    Sub Sb_Iniciar()

        _Procesando = True
        _BackgroundWorker.RunWorkerAsync()

    End Sub

    Sub Sb_Detener()

        If _BackgroundWorker.IsBusy Then
            _BackgroundWorker.CancelAsync()
        End If

    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        Try

            Sb_Procedimiento_Prestashop_orders()

        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged
        'Lbl_Progreso.Text = (e.ProgressPercentage.ToString() & "%")
        'ProgressBarItem1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

        If e.Cancelled = True Then
            'Lbl_Progreso.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            'Lbl_Progreso.Text = "Error: " & e.[Error].Message
        Else
            'Lbl_Progreso.Text = "Done!"
            'If _BackgroundWorker.IsBusy <> True Then
            '_BackgroundWorker.RunWorkerAsync()
            'End If
        End If

        _Procesando = False
        _Lbl_Estado = "Monitoreo Cola Impresión Automática"

    End Sub

    Sub Sb_Procedimiento_Prestashop_orders()

        _Procesando = True
        Log_Registro = String.Empty

        Consulta_Sql = "Select Od.Id_order,Od.Reference,Od.Date_add,Od.Total_paid,Ps.*
                        From " & _Global_BaseBk & "Zw_PrestaShop_orders Od
                        Inner Join " & _Global_BaseBk & "Zw_PrestaShop Ps On Ps.Codigo_Pagina = Od.Codigo_Pagina
                        Where Reference = ''"

        Dim _Tbl_PrestaShop_orders As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql, False)

        If CBool(_Tbl_PrestaShop_orders.Rows.Count) Then

            For Each _Fila As DataRow In _Tbl_PrestaShop_orders.Rows

                Dim _Codigo_Pagina = _Fila.Item("Codigo_Pagina")
                Dim _Nombre_Pagina = _Fila.Item("Nombre_Pagina")

                Dim _Host = _Fila.Item("Host")
                Dim _Usuario = _Fila.Item("Usuario")
                Dim _Clave = _Fila.Item("Clave")
                Dim _Puerto_X_Defecto = _Fila.Item("Puerto_X_Defecto")
                Dim _Puerto = _Fila.Item("Puerto")
                Dim _Base_Datos = _Fila.Item("Base_Datos")
                Dim _Cod_Lista = _Fila.Item("Cod_Lista")

                Dim _Id_order As Integer = _Fila.Item("Id_order")

                Dim _Cadena_Conexion_MySql As String
                Dim _Clas_Ps As Class_MySQL

                _Cadena_Conexion_MySql = "Host=" & _Host & ";Database=" & _Base_Datos & ";Uid=" & _Usuario & ";Password=" & _Clave & ";"
                _Clas_Ps = New Class_MySQL(_Cadena_Conexion_MySql)

                _Clas_Ps.Sb_Abrir_Conexion()

                Dim _Log_Error As String = _Clas_Ps.Pro_Error

                If String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then

                    _Log_Error = Fx_Prestashop_Traer_Orden(_Cadena_Conexion_MySql, _Codigo_Pagina, _Id_order)

                End If

                If Not String.IsNullOrEmpty(_Log_Error) Then

                    _Log_Error = Replace(_Log_Error, "'", "''")

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_PrestaShop_orders Set 
                                    Reference = 'Error! - " & Mid(_Log_Error.Trim, 1, 80) & "' 
                                    Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Id_order = " & _Id_order
                    If _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += _Log_Error & vbCrLf & _Sql.Pro_Error & vbCrLf
                    Else
                        Log_Registro += _Log_Error & vbCrLf & _Sql.Pro_Error & vbCrLf
                    End If

                End If

                _Log_Error = String.Empty

            Next

        End If

        _Procesando = False

    End Sub

    Function Fx_Prestashop_Traer_Orden(_Cadena_Conexion_MySql As String,
                                       _Codigo_Pagina As String,
                                       _Id_orders As Integer) As String

        Try

            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

            Consulta_Sql = "Select id_order,reference,total_paid,date_add,id_customer From ps_orders Where id_order = " & _Id_orders
            Dim _Tbl_ps_orders As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_Sql)

            If Not String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then Return _Clas_Ps.Pro_Error

            Consulta_Sql = "Select id_order_detail,id_order,product_id,product_reference,product_name,product_quantity,product_price,reduction_percent," &
                           "unit_price_tax_excl,unit_price_tax_incl,total_price_tax_excl,total_price_tax_incl,original_product_price 
                            From ps_order_detail Where id_order = " & _Id_orders
            Dim _Tbl_ps_orders_detail As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_Sql)

            If Not String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then Return _Clas_Ps.Pro_Error

            Consulta_Sql = "Select Imp.* From ps_order_detail_tax Imp 
                            Inner join ps_order_detail Det On Det.id_order_detail = Imp.id_order_detail
                            Where id_order = " & _Id_orders
            Dim _Tbl_ps_orders_detail_tax As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_Sql)

            'Eliminamos los registros basura
            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_PrestaShop_orders_detail" & vbCrLf &
                           "Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Id_order Not In (Select Id_order From " & _Global_BaseBk & "Zw_PrestaShop_orders Where Codigo_Pagina = '" & _Codigo_Pagina & "')" &
                           vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_PrestaShop_orders_detail_tax" & vbCrLf &
                           "Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Id_order_detail Not In (Select Id_order_detail From " & _Global_BaseBk & "Zw_PrestaShop_orders_detail Where Codigo_Pagina = '" & _Codigo_Pagina & "')"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

            If Not String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then Return _Clas_Ps.Pro_Error

            If _Tbl_ps_orders.Rows.Count Then

                Dim _Reference As String = _Tbl_ps_orders.Rows(0).Item("reference")
                Dim _Date_add As String = Format(_Tbl_ps_orders.Rows(0).Item("date_add"), "yyyyMMdd hh:mm")
                Dim _Total_paid As String = De_Num_a_Tx_01(_Tbl_ps_orders.Rows(0).Item("total_paid"), False, 5)

                Dim _Id_customer As Integer = _Tbl_ps_orders.Rows(0).Item("id_customer")

                Consulta_Sql = "Select ps_customer.firstname,ps_customer.lastname,ps_customer.email,ps_address.* 
                                From ps_customer 
                                    Inner Join ps_address ON ps_address.id_customer = ps_customer.id_customer
                                Where ps_customer.id_customer = " & _Id_customer & " And ps_address.active = 1 And ps_address.deleted = 0"
                Dim _Tbl_Customer As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_Sql)

                If CBool(_Tbl_Customer.Rows.Count) Then

                    'Select Case TOP(200) Id_customer, Id_address, Vat_number, Firstname, Lastname, Address1, Address2, Phone, Phone_mobile, Email
                    'From Zw_PrestaShop_orders_customer

                    For Each _FlCustomer As DataRow In _Tbl_Customer.Rows

                        Dim _Id_address = _FlCustomer.Item("id_address")
                        Dim _Vat_number = _FlCustomer.Item("vat_number")
                        Dim _Firstname = _FlCustomer.Item("firstname")
                        Dim _Lastname = _FlCustomer.Item("lastname")
                        Dim _Address1 = _FlCustomer.Item("address1")
                        Dim _Address2 = _FlCustomer.Item("address2")
                        Dim _Phone = _FlCustomer.Item("phone")
                        Dim _Phone_mobile = _FlCustomer.Item("phone_mobile")
                        Dim _Email = _FlCustomer.Item("email")

                        If CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_PrestaShop_orders_customer", "Id_address = " & _Id_address)) Then

                            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_PrestaShop_orders_customer Where Id_address = " & _Id_address
                            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                        End If

                        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_PrestaShop_orders_customer (Id_customer,Id_address,Vat_number,Firstname,Lastname,Address1," &
                                       "Address2,Phone,Phone_mobile,Email) Values (" & _Id_customer & "," & _Id_address & ",'" & _Vat_number &
                                       "','" & _Firstname & "','" & _Lastname & "','" & _Address1 & "','" & _Address2 & "','" & _Phone &
                                       "','" & _Phone_mobile & "','" & _Email & "')"
                        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                    Next

                End If

                Dim _Sql_Query = String.Empty


                _Sql_Query = "Delete " & _Global_BaseBk & "Zw_PrestaShop_orders Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Id_order = " & _Id_orders & " --And Reference = 'Error!'
                              Insert Into " & _Global_BaseBk & "Zw_PrestaShop_orders (Codigo_Pagina,Id_order,Reference,Date_add,Total_paid,Id_customer) " &
                              "Values ('" & _Codigo_Pagina & "'," & _Id_orders & ",'" & _Reference & "','" & _Date_add & "'," & _Total_paid & "," & _Id_customer & ")" & vbCrLf & vbCrLf

                For Each _Fila As DataRow In _Tbl_ps_orders_detail.Rows

                    Dim _Id_order_detail = _Fila.Item("id_order_detail")
                    Dim _Id_order = _Fila.Item("id_order")
                    Dim _Product_id = _Fila.Item("product_id")
                    Dim _Product_reference = _Fila.Item("product_reference")
                    Dim _Product_name = _Fila.Item("product_name")
                    Dim _Product_quantity = De_Num_a_Tx_01(_Fila.Item("product_quantity"), False, 5)
                    Dim _Product_price = De_Num_a_Tx_01(_Fila.Item("product_price"), False, 5)
                    Dim _Reduction_percent = De_Num_a_Tx_01(_Fila.Item("reduction_percent"), False, 5)
                    Dim _Unit_price_tax_excl = De_Num_a_Tx_01(_Fila.Item("unit_price_tax_excl"), False, 5)
                    Dim _Unit_price_tax_incl = De_Num_a_Tx_01(_Fila.Item("unit_price_tax_incl"), False, 5)
                    Dim _Total_price_tax_excl = De_Num_a_Tx_01(_Fila.Item("total_price_tax_excl"), False, 5)
                    Dim _Total_price_tax_incl = De_Num_a_Tx_01(_Fila.Item("total_price_tax_incl"), False, 5)
                    Dim _Original_product_price = De_Num_a_Tx_01(_Fila.Item("original_product_price"), False, 5)

                    _Sql_Query += "Insert Into " & _Global_BaseBk & "Zw_PrestaShop_orders_detail (Codigo_Pagina,Id_order_detail,Id_order,Product_id," &
                                  "Product_reference,Product_name,Product_quantity,Product_price,Reduction_percent,Unit_price_tax_excl," &
                                  "Unit_price_tax_incl,Total_price_tax_excl,Total_price_tax_incl,Original_product_price) 
                                   Values ('" & _Codigo_Pagina & "'," & _Id_order_detail & "," & _Id_order & "," & _Product_id & "," &
                                  "'" & _Product_reference & "','" & _Product_name & "'," & _Product_quantity & "," & _Product_price & "," & _Reduction_percent &
                                  "," & _Unit_price_tax_excl & "," &
                                  _Unit_price_tax_incl & "," & _Total_price_tax_excl & "," & _Total_price_tax_incl & "," & _Original_product_price & ")" & vbCrLf

                Next

                _Sql_Query += vbCrLf

                For Each _Fila_tax As DataRow In _Tbl_ps_orders_detail_tax.Rows

                    Dim _Id_order_detail = _Fila_tax.Item("id_order_detail")
                    Dim _Id_tax = _Fila_tax.Item("id_tax")
                    Dim _Unit_amount = De_Num_a_Tx_01(_Fila_tax.Item("unit_amount"), False, 5)
                    Dim _Total_amount = De_Num_a_Tx_01(_Fila_tax.Item("total_amount"), False, 5)

                    _Sql_Query += "Insert Into " & _Global_BaseBk & "Zw_PrestaShop_orders_detail_tax (Codigo_Pagina,Id_order_detail,Id_tax,Unit_amount,Total_amount,Id_order) 
                                   Values ('" & _Codigo_Pagina & "'," & _Id_order_detail & "," & _Id_tax & "," & _Unit_amount & "," & _Total_amount & "," & _Id_orders & ")" & vbCrLf

                Next

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Sql_Query) Then
                    Log_Registro = "Se inserta la Orden Id: " & _Id_orders & ", Referencia: " & _Reference & vbCrLf
                    Return ""
                Else
                    Return _Sql.Pro_Error
                End If

            Else

                Return "No se encontro el documento"

            End If


        Catch ex As Exception
            Return "Error!! al insertar documento " & ex.Message
        End Try

    End Function

End Class
