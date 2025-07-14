Imports DevComponents.DotNetBar

Public Class Frm_Sol_Recom_Respuesta

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Cl_Sol_Recom_Compra_Pr As Cl_Sol_Recom_Compra_Pr

    Dim _Row_Producto_Origen As DataRow
    Dim _Row_Producto_Usar As DataRow


    Dim _Producto_Sol As String
    Dim _Grabar As Boolean
    Dim _Id_SCom As Integer

    Public Property Pro_Cl_Sol_Recom_Compra_Pr As Cl_Sol_Recom_Compra_Pr
        Get
            Return _Cl_Sol_Recom_Compra_Pr
        End Get
        Set(value As Cl_Sol_Recom_Compra_Pr)
            _Cl_Sol_Recom_Compra_Pr = value
        End Set
    End Property

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(Id_SCom As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Id_SCom = Id_SCom

        _Cl_Sol_Recom_Compra_Pr = New Cl_Sol_Recom_Compra_Pr
        _Cl_Sol_Recom_Compra_Pr.Sb_Llenar_Row_Prod_SolCompra(Id_SCom)

        If Not _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("Visto") Then

            Dim _CodFun_Solicita = _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("CodFun_Solicita")

            If FUNCIONARIO = _CodFun_Solicita Then

                If _Cl_Sol_Recom_Compra_Pr.Estado = Cl_Sol_Recom_Compra_Pr.Enum_Estados.Respondido Then

                    If _Cl_Sol_Recom_Compra_Pr.Fx_Insertar_Respuesta(FUNCIONARIO, Cl_Sol_Recom_Compra_Pr.Enum_Estados.Acuse_Recibo, "", 0, 0) Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolCompra Set 
                            Visto = 1, Fecha_Visto = Getdate() 
                            Where Id_SCom = " & _Cl_Sol_Recom_Compra_Pr.Id_SCom
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                End If

            End If

        End If

        Dim _NomFun_solicita As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("CodFun_Solicita") & "'")
        Me.Text = "RESPUESTA POR SOLICITUD DE PRODUCTO (SOLICITA: " & Trim(_NomFun_solicita) & ")"

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Enviar.ForeColor = Color.White
            Txt_Respuesta.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Sol_Recom_Respuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Traer_Resgitro()

    End Sub

    Sub Sb_Traer_Resgitro()

        With _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra

            If .Item("Existe_Producto") Then
                _Producto_Sol = Trim(.Item("Codigo")) & " - " & .Item("Descripcion")
                Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & .Item("Codigo") & "'"
                _Row_Producto_Origen = _Sql.Fx_Get_DataRow(Consulta_sql)
                Btn_Mnu_Pr_Estadistica_Producto.Visible = True
            Else
                _Producto_Sol = .Item("Descripcion")
            End If

            Dim _Tipo_de_Compra As String
            Dim _Cliente As String
            Dim _Para_Stock As Boolean

            If .Item("Venta_Calzada") Then

                _Cliente = Trim(.Item("CodCliente")) & "-" & Trim(.Item("CodSucCliente")) & ": " & .Item("NOKOEN")

                _Cliente = "<b>CLIENTE:</b> " & _Cliente & "<br/>"

                If .Item("Deja_Anticipo") Then
                    _Tipo_de_Compra = "VENTA CALZADA, EL CLIENTE DEJA ANTICIPO DE " & FormatCurrency(.Item("Valor_Anticipo"), 0)
                Else
                    _Tipo_de_Compra = "VENTA CALZADA, SIN ANTICIPO"
                End If

            ElseIf .Item("Para_Stock") Then

                _Tipo_de_Compra = "COMPRAR PARA STOCK"
                _Cliente = "<br/>"
                _Para_Stock = True

                'Panel_Encontrado.Enabled = False
                'Panel_Pedido.Enabled = False

            End If



            Dim _Cantidad = FormatNumber(.Item("Cantidad"), 0)
            Dim _Observaciones As String = .Item("Observaciones")

            Dim _Solicitud = "<b>PRODUCTO A COMPRAR</b>:" & _Producto_Sol & "<br/>" &
                             "<b>CANTIDAD:</b>" & _Cantidad & "<br/><br/>" &
                             "<b>TIPO DE COMPRA:</b>" & _Tipo_de_Compra & "<br/>" &
                             "<br/>" & _Cliente &
                             "<b>OBS: </b>" & _Observaciones

            Lbl_Solicitud.Text = _Solicitud

            If _Cl_Sol_Recom_Compra_Pr.Estado = Cl_Sol_Recom_Compra_Pr.Enum_Estados.Pendiente Or
               _Cl_Sol_Recom_Compra_Pr.Estado = Cl_Sol_Recom_Compra_Pr.Enum_Estados.Revisado Then

                If _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("CodFun_Solicita") = FUNCIONARIO Then

                    Grupo_Respuesta.Enabled = False
                    Btn_Enviar.Enabled = False

                End If

                Consulta_sql = "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Prod_SolCompra_Resp 
                                Left Join TABFU On KOFU = CodFun_Responde
                                Where Id_SCom = " & _Id_SCom & " And Estado = 'REV'"
                Dim _Row_Revisado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Revisado) Then

                    Grupo_Respuesta.Text = "REVISADO POR: " & Trim(_Row_Revisado.Item("NOKOFU")) &
                                           ", FECHA: " & _Row_Revisado.Item("Fecha").ToString

                End If

            End If

            If _Cl_Sol_Recom_Compra_Pr.Estado = Cl_Sol_Recom_Compra_Pr.Enum_Estados.Respondido Then

                Dim _Codigo_Usar = _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("Codigo_Usar")

                Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigo_Usar & "'"
                _Row_Producto_Usar = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Producto_Usar) Then

                    Lbl_Producto_Reemplazo.Text = "Usar: " & Trim(_Row_Producto_Usar.Item("KOPR")) & _Row_Producto_Usar.Item("NOKOPR")

                End If

                Consulta_sql = "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Prod_SolCompra_Resp 
                                Left Join TABFU On KOFU =  CodFun_Responde
                                Where Id_SCom = " & _Id_SCom & " And Estado = 'RPD'"
                Dim _Row_Respuesta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Respuesta) Then

                    Txt_Respuesta.Text = _Row_Respuesta.Item("Observaciones")
                    Grupo_Respuesta.Text = "RESPONDE: " & Trim(_Row_Respuesta.Item("NOKOFU")) &
                                           ", FECHA: " & FormatDateTime(_Row_Respuesta.Item("Fecha"), DateFormat.ShortDate)

                    Dim _Agotado = _Row_Respuesta.Item("Agotado")
                    Dim _Pedido = _Row_Respuesta.Item("Pedido")

                    If _Para_Stock Then

                        Panel_Agotado.Enabled = False
                        Panel_Pedido.Enabled = False

                    Else

                        If _Agotado Then
                            Rdb_Agotado_SI.Checked = True
                            Rdb_Agotado_NO.Enabled = False
                        Else
                            Rdb_Agotado_NO.Checked = True
                            Rdb_Agotado_SI.Enabled = False
                        End If

                        If _Pedido Then
                            Rdb_Pedido_SI.Checked = True
                            Rdb_Pedido_NO.Enabled = False
                        Else
                            Rdb_Pedido_NO.Checked = True
                            Rdb_Pedido_SI.Enabled = False
                        End If

                    End If

                End If

                Txt_Respuesta.ReadOnly = True
                Btn_Enviar.Enabled = False
                Btn_Reemplazar_Por.Enabled = False


            End If

        End With

    End Sub

    Private Sub Btn_Enviar_Click(sender As Object, e As EventArgs) Handles Btn_Enviar.Click

        Dim _Respuesta As String

        If _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("Venta_Calzada") Then

            If Not Rdb_Pedido_SI.Checked And Not Rdb_Pedido_NO.Checked Then
                MessageBoxEx.Show(Me, "Debe indicar si el producto fue o no pedido a algún proveedor", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
                Return
            End If

            If Not Rdb_Agotado_SI.Checked And Not Rdb_Agotado_NO.Checked Then
                MessageBoxEx.Show(Me, "Debe indicar si el producto fue o no encontrado donde algún proveedor", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
                Return
            End If

        End If

        Dim _Codigo_Usar = _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("Codigo_Usar")

        Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigo_Usar & "'"
        _Row_Producto_Usar = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Producto_Usar) Then
            _Respuesta = "USAR PRODUCTO: [" & Trim(_Row_Producto_Usar.Item("KOPR")) & "] - " & _Row_Producto_Usar.Item("NOKOPR")
            _Respuesta = _Respuesta & Environment.NewLine & Txt_Respuesta.Text
        Else
            _Respuesta = Txt_Respuesta.Text
        End If

        If String.IsNullOrEmpty(Trim(Replace(Replace(_Respuesta, vbTab, ""), vbCrLf, ""))) Then

            MessageBoxEx.Show(Me, "Debe enviar una respuesta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True)
            Txt_Respuesta.Text = String.Empty
            Txt_Respuesta.Focus()
            Return

        End If

        Dim _Pedido As Boolean = Rdb_Pedido_SI.Checked
        Dim _Encontrado As Boolean = Rdb_Agotado_SI.Checked

        If _Cl_Sol_Recom_Compra_Pr.Fx_Insertar_Respuesta(FUNCIONARIO,
                                                         Cl_Sol_Recom_Compra_Pr.Enum_Estados.Respondido,
                                                         Replace(_Respuesta, "'", ""), _Encontrado, _Pedido) Then

            'csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO, _CodFun_Envio,
            '                                                   "SOLICITUD DE COMPRA DE PRODUCTO",
            '                                                   "COMPRAR PRODUCTO PARA STOCK",
            '                                                   csNotificaciones.Notificacion.Imagen.Informacion, "", True, 0, True, 0)

            Dim _Texto As String
            Dim _Accion = csNotificaciones.Notificacion.Imagen.Scompra_Producto

            Dim _Row_Prod_SolCompra As DataRow = _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra

            Dim _CodFun_Solicita = _Row_Prod_SolCompra.Item("CodFun_Solicita")

            _Texto = "PROD: " & _Producto_Sol & Environment.NewLine &
                     Replace(_Respuesta, "'", "")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Notificaciones 
                            (Empresa,Usuario_Solicita,Usuario_Destino,Titulo,Texto,Accion,NroRemota,Solicita_Confirmacion,
                            IdRespuesta,Fecha,Hora,Mostrar,RCadena_Id_Enc,Id_SCom) Values 
                            ('" & Mod_Empresa & "','" & FUNCIONARIO & "','" & _CodFun_Solicita & "','SOLICITUD DE COMPRA DE PRODUCTO','" & _Texto & "',
                            '" & _Accion.ToString & "','',1,0,Getdate(),Getdate(),1,0," & _Cl_Sol_Recom_Compra_Pr.Id_SCom & ")"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(Me, "Respuesta enviada correctamente", "Enviar solicitud de compra de producto",
                              MessageBoxButtons.OK, MessageBoxIcon.Information,
                                  MessageBoxDefaultButton.Button1, True)

            _Grabar = True

            Me.Close()

        End If


    End Sub

    Private Sub Btn_Reemplazar_Por_Click(sender As Object, e As EventArgs) Handles Btn_Reemplazar_Por.Click

        Dim _Sql_Filtro_Condicion_Extra '= "And INACTIVO = 0 " & _Filtro_Usuarios_NOT_In
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            _Row_Producto_Usar = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Lbl_Producto_Reemplazo.Text = "Usar: " & Trim(_Row_Producto_Usar.Item("Codigo")) & _Row_Producto_Usar.Item("Descripcion")
            Btn_Quitar_Reemplazo.Enabled = True
            Btn_Reemplazar_Por.Enabled = False

            _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("Codigo_Usar") = Trim(_Row_Producto_Usar.Item("Codigo"))

        End If

    End Sub

    Private Sub Btn_Quitar_Reemplazo_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Reemplazo.Click

        _Row_Producto_Usar = Nothing
        Lbl_Producto_Reemplazo.Text = "."
        Btn_Reemplazar_Por.Enabled = True
        Btn_Quitar_Reemplazo.Enabled = False
        _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("Codigo_Usar") = String.Empty

    End Sub

    Private Sub Frm_Sol_Recom_Respuesta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Mnu_Pr_Estadistica_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Pr_Estadistica_Producto.Click

        Dim _Codigo = _Row_Producto_Origen.Item("KOPR")

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim Fm As New Frm_EstadisticaProducto(_Codigo, "", Frm_EstadisticaProducto.Tipo_Doc.Compra)
            Fm.ShowInTaskbar = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub
End Class
