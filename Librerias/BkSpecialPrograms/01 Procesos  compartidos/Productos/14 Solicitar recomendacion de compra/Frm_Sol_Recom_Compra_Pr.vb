Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Sol_Recom_Compra_Pr

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Cl_Sol_Recom_Compra_Pr As Cl_Sol_Recom_Compra_Pr
    Dim _Row_Producto As DataRow
    Dim _Row_Cliente As DataRow

    Public Property Pro_Cl_Sol_Recom_Compra_Pr As Cl_Sol_Recom_Compra_Pr
        Get
            Return _Cl_Sol_Recom_Compra_Pr
        End Get
        Set(value As Cl_Sol_Recom_Compra_Pr)
            _Cl_Sol_Recom_Compra_Pr = value
        End Set
    End Property

    Public Property Pro_Row_Producto As DataRow
        Get
            Return _Row_Producto
        End Get
        Set(value As DataRow)
            _Row_Producto = value
        End Set
    End Property

    Public Property Row_Cliente As DataRow
        Get
            Return _Row_Cliente
        End Get
        Set(value As DataRow)
            _Row_Cliente = value
        End Set
    End Property

    Public Sub New(Id_SCom As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cl_Sol_Recom_Compra_Pr = New Cl_Sol_Recom_Compra_Pr
        _Cl_Sol_Recom_Compra_Pr.Sb_Llenar_Row_Prod_SolCompra(Id_SCom)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Observaciones.FocusHighlightEnabled = False
            Txt_Nokopr.FocusHighlightEnabled = False
            Btn_Enviar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Sol_Recom_Compra_Pr_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Rdb_Para_Stock.CheckedChanged, AddressOf Sb_Rdb_Stock_Venta_Calzada_CheckedChanged
        AddHandler Rdb_Venta_Calzada.CheckedChanged, AddressOf Sb_Rdb_Stock_Venta_Calzada_CheckedChanged

        AddHandler Chk_Deja_Anticipo_SI.CheckedChanged, AddressOf Chk_Deja_Anticipo_SI_CheckedChanged
        AddHandler Chk_Deja_Anticipo_NO.CheckedChanged, AddressOf Chk_Deja_Anticipo_NO_CheckedChanged


        If _Cl_Sol_Recom_Compra_Pr.Estado = Cl_Sol_Recom_Compra_Pr.Enum_Estados.Ingresando Then

            If IsNothing(_Row_Producto) Then
                Txt_Nokopr.ReadOnly = False
                Me.ActiveControl = Txt_Nokopr
            Else
                Txt_Nokopr.Text = _Row_Producto.Item("NOKOPR")
                Txt_Nokopr.ReadOnly = True
                Me.ActiveControl = Txt_Observaciones
            End If

        End If

        Grupo_Cliente.Enabled = False

    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles Btn_Enviar.Click

        Sb_Crear_Nueva_Solicitud()

    End Sub

    Sub Sb_Crear_Nueva_Solicitud()

        If String.IsNullOrEmpty(Trim(Txt_Nokopr.Text)) Then
            MessageBoxEx.Show(Me, "Debe ingresar la descripción del producto", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
            Return
        End If

        If Not Convert.ToBoolean(Val(Input_Cantidad.Value)) Then
            MessageBoxEx.Show(Me, "Debe ingresar la cantidad a comprar", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
            Return
        End If

        If Not Rdb_Para_Stock.Checked And Not Rdb_Venta_Calzada.Checked Then
            MessageBoxEx.Show(Me, "Debe indicar si la compra es para stock o venta calzada", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
            Return
        End If

        If Rdb_Venta_Calzada.Checked Then

            If IsNothing(_Row_Cliente) Then

                MessageBoxEx.Show(Me, "Debe ingresar al cliente", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
                Return

            End If

            If Not Chk_Deja_Anticipo_SI.Checked And Not Chk_Deja_Anticipo_NO.Checked Then

                MessageBoxEx.Show(Me, "Debe indicar si el cliente dejo SI o NO anticipo", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
                Return

            ElseIf Chk_Deja_Anticipo_SI.Checked Then

                If Not Convert.ToBoolean(Input_Valor_Anticipo.Value) Then

                    MessageBoxEx.Show(Me, "Debe ingresar el monto del anticipo", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
                    Return

                End If

            End If

        End If

        If Rdb_Para_Stock.Checked And Not IsNothing(_Row_Producto) Then

            Dim _Codigo = Trim(_Row_Producto.Item("KOPR"))

            Consulta_sql = "Select Scom.*,TABFU.NOKOFU From " & _Global_BaseBk & "Zw_Prod_SolCompra Scom
                            Left Join TABFU On KOFU = Scom.CodFun_Solicita
                            Where Empresa = '" & Mod_Empresa & "' And Codigo = '" & _Codigo & "' And Para_Stock = 1 And Estado = 'PDT'"
            Dim _Row_Solicitado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Solicitado) Then

                If _Row_Solicitado.Item("CodFun_Solicita") = FUNCIONARIO Then

                    MessageBoxEx.Show(Me, "Este producto ya fue solicitado para stock por el usuario " & _Row_Solicitado.Item("NOKOFU").ToString & vbCrLf &
                                  "Fecha de solicitud: " & FormatDateTime(_Row_Solicitado.Item("Fecha_Envio"), DateFormat.ShortDate),
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return

                End If

            End If

        End If


        Dim _Row_Destinatario As DataRow = Fx_Traer_Funcionarios_Destino()

        If Not IsNothing(_Row_Destinatario) Then

            Dim _CodFun_Envio = _Row_Destinatario.Item("Codigo")

            Dim _Row_Prod_SolCompra = _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra

            _Row_Prod_SolCompra.Item("CodFun_Envio") = _CodFun_Envio

            Dim _Existe_Producto = Convert.ToInt32(Not IsNothing(_Row_Producto))
            Dim _Codigo = String.Empty
            Dim _Descripcion = String.Empty
            Dim _Observaciones = Replace(Txt_Observaciones.Text, "'", "")

            Dim _Cantidad = Input_Cantidad.Value
            Dim _Para_Stock = Convert.ToInt32(Rdb_Para_Stock.Checked)
            Dim _Venta_Calzada = Convert.ToInt32(Rdb_Venta_Calzada.Checked)
            Dim _CodCliente = String.Empty
            Dim _CodSucCliente = String.Empty
            Dim _Deja_Anticipo = Convert.ToInt32(Chk_Deja_Anticipo_SI.Checked)
            Dim _Valor_Anticipo = Input_Valor_Anticipo.Value

            _Descripcion = Trim(Txt_Nokopr.Text)

            If Not IsNothing(_Row_Producto) Then

                _Existe_Producto = 1
                _Codigo = Trim(_Row_Producto.Item("KOPR"))

            End If

            If Not IsNothing(_Row_Cliente) Then

                _CodCliente = Trim(_Row_Cliente.Item("KOEN"))
                _CodSucCliente = Trim(_Row_Cliente.Item("SUEN"))

            End If

            _Row_Prod_SolCompra.Item("Existe_Producto") = _Existe_Producto
            _Row_Prod_SolCompra.Item("Codigo") = _Codigo
            _Row_Prod_SolCompra.Item("Descripcion") = _Descripcion
            _Row_Prod_SolCompra.Item("Observaciones") = _Observaciones
            _Row_Prod_SolCompra.Item("Cantidad") = _Cantidad
            _Row_Prod_SolCompra.Item("CodFun_Solicita") = FUNCIONARIO
            _Row_Prod_SolCompra.Item("CodFun_Envio") = _CodFun_Envio
            _Row_Prod_SolCompra.Item("Para_Stock") = _Para_Stock
            _Row_Prod_SolCompra.Item("Venta_Calzada") = _Venta_Calzada
            _Row_Prod_SolCompra.Item("CodCliente") = _CodCliente
            _Row_Prod_SolCompra.Item("CodSucCliente") = _CodSucCliente
            _Row_Prod_SolCompra.Item("Deja_Anticipo") = _Deja_Anticipo
            _Row_Prod_SolCompra.Item("Valor_Anticipo") = _Valor_Anticipo


            If _Cl_Sol_Recom_Compra_Pr.Fx_Insertar_Recomandacion_Compra_Producto() Then

                'csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO, _CodFun_Envio,
                '                                                   "SOLICITUD DE COMPRA DE PRODUCTO",
                '                                                   "COMPRAR PRODUCTO PARA STOCK",
                '                                                   csNotificaciones.Notificacion.Imagen.Informacion, "", True, 0, True, 0)
                Dim _Texto As String
                Dim _Accion = csNotificaciones.Notificacion.Imagen.Scompra_Producto

                _Row_Prod_SolCompra = _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra

                If Rdb_Para_Stock.Checked Then
                    _Texto = "COMPRAR PRODUCTO PARA STOCK" & Environment.NewLine &
                             "NUMERO: " & _Row_Prod_SolCompra.Item("Numero") & Environment.NewLine &
                             "PROD: " & Txt_Nokopr.Text
                Else
                    _Texto = "COMPRAR PRODUCTO PARA VENTA CALZADA" & Environment.NewLine &
                             "NUMERO: " & _Row_Prod_SolCompra.Item("Numero") & Environment.NewLine &
                             "CLIENTE: " & _Row_Cliente.Item("NOKOEN") & Environment.NewLine &
                             "PROD: " & Txt_Nokopr.Text
                End If

                Dim _Titulo = "SOLICITUD DE COMPRA DE PRODUCTO"

                csNotificaciones.Notificacion.Fx_Insertar_Notificacion_SCom_Pr(_Cl_Sol_Recom_Compra_Pr.Id_SCom,
                                                                               FUNCIONARIO, _CodFun_Envio, _Titulo, _Texto, True)

                MessageBoxEx.Show(Me, "La solicitud fue enviada correctamente", "Enviar solicitud de compra de producto",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information,
                                  MessageBoxDefaultButton.Button1, True)
                Me.Close()

            End If

        Else

            MessageBoxEx.Show(Me, "Debe indicar al usuario de destino", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)

        End If

    End Sub

    Function Fx_Traer_Funcionarios_Destino() As DataRow

        Dim _Codpermiso = "Prod060"

        'Dim _Cl_Permiso As New Class_Permiso_BakApp
        '_Cl_Permiso.Sb_Existe_Permiso_En_BakApp(_Codpermiso)

        'Fx_Tiene_Permiso(Me, _Codpermiso,, False)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Descripcion = _RowPermiso.Item("DescripcionPermiso")

        Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Dim _Filtro_Usuarios_NOT_In As String

        If CBool(_Tbl.Rows.Count) Then

            _Filtro_Usuarios_NOT_In = "And KOFU In " & Generar_Filtro_IN(_Tbl, "", "CodUsuario", False, False, "'")

        Else

            MessageBoxEx.Show(Me, "No existen usuarios con el permiso necesario." & vbCrLf &
                              "Informe esta situación a la administración por favor.",
                              "Faltan usuarios con el permiso [" & _Codpermiso & "]", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                  MessageBoxDefaultButton.Button1, True)
            Return Nothing

        End If

        Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0 " & _Filtro_Usuarios_NOT_In
        Dim _Row_Destinatario As DataRow
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

            _Row_Destinatario = _Tbl_Operacion.Rows(0)

        End If

        Return _Row_Destinatario

    End Function

    Private Sub Sb_Rdb_Stock_Venta_Calzada_CheckedChanged(sender As Object, e As EventArgs)

        Grupo_Cliente.Enabled = Rdb_Venta_Calzada.Checked

        If Rdb_Venta_Calzada.Checked Then

            _Row_Cliente = Nothing
            Txt_CodCliente.Text = String.Empty
            Txt_Razon_Cliente.Text = String.Empty

            Chk_Deja_Anticipo_SI.Checked = False
            Chk_Deja_Anticipo_NO.Checked = False

            Input_Cantidad.Focus()
            Input_Cantidad.Enabled = True

        Else

            Input_Cantidad.Enabled = False
            Input_Cantidad.Value = 1

        End If

    End Sub

    Private Sub Chk_Deja_Anticipo_SI_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Deja_Anticipo_SI.Checked Then
            Input_Valor_Anticipo.Focus()
            Input_Valor_Anticipo.Enabled = True
        End If

    End Sub

    Private Sub Chk_Deja_Anticipo_NO_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Deja_Anticipo_NO.Checked Then
            Input_Valor_Anticipo.Value = 0
            Input_Valor_Anticipo.Enabled = False
        End If

    End Sub

    Private Sub Btn_Buscar_Cliente_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Cliente.Click

        Dim _Row As DataRow

        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
        Fm_Ent.Text = "SELECCIONE EL CLIENTE"
        Fm_Ent.ShowDialog(Me)

        If Fm_Ent.Pro_Entidad_Seleccionada Then _Row = Fm_Ent.Pro_RowEntidad

        Fm_Ent.Dispose()

        If Not IsNothing(_Row) Then

            _Row_Cliente = _Row

            Txt_CodCliente.Text = (_Row_Cliente.Item("KOEN")) & "-" & Trim(_Row_Cliente.Item("SUEN"))
            Txt_Razon_Cliente.Text = _Row_Cliente.Item("NOKOEN")

            Chk_Deja_Anticipo_NO.Checked = True

        End If

    End Sub

    Private Sub Txt_Nokopr_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Nokopr.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Sol_Recom_Compra_Pr_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
