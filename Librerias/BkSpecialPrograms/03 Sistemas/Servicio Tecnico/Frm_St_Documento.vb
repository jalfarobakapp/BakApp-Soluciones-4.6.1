Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_St_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsDocumento As DataSet
    Dim _RowEntidad As DataRow

    Dim _Info_Estado_A_Realizar As String
    ' ESTADOS

    Dim _Row_Estado_1 As DataRow
    Dim _Row_Estado_2 As DataRow
    Dim _Row_Estado_3 As DataRow
    Dim _Row_Estado_4 As DataRow
    Dim _Row_Estado_5 As DataRow
    Dim _Row_Estado_6 As DataRow
    Dim _Row_Estado_7 As DataRow
    Dim _Row_Estado_8 As DataRow

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Row_Notas As DataRow
    Dim _Tbl_Estado As DataTable
    Dim _Tbl_Accesorios As DataTable
    Dim _Row_Doc_Garantia As DataRow
    Dim _RowProducto As DataRow
    'Dim _Row_Garantia_Documento_Rd As DataRow

    Dim _Abrir_Documento As Boolean
    Dim _Grabar As Boolean
    Dim _Editar As Boolean
    Dim _Nulo As Boolean

    Dim _Id_Ot As Integer
    Dim _Id_Ot_Padre As Integer
    Dim _Id_Correo As Integer

    Dim _Garantia_Documento_Externo As Boolean
    Dim _Nro_Documento_Externo As String

    Enum Accion
        Nuevo
        Editar
    End Enum


    Dim _Sql_Query As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _Accion As Accion

    Dim _EditarContactoTodasLasSubOT As Boolean
    Dim _TieneHnosSubOT As Integer

    Public Sub New(Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Accion = Accion
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Lbl_GRP.Text = String.Empty

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Sb_Frm_St_Documento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_St_Documento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If _Accion = Accion.Nuevo Then

            Sb_New_OT_Nueva_OT()
            Sb_Formato_Grilla()

            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Tbl_ChekIn = _DsDocumento.Tables(2)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_Estado = _DsDocumento.Tables(4)
            _Tbl_Accesorios = _DsDocumento.Tables(5)


            _Row_Encabezado.Item("Pais") = _RowEntidad.Item("PAEN")
            _Row_Encabezado.Item("Ciudad") = _RowEntidad.Item("CIEN")
            _Row_Encabezado.Item("Comuna") = _RowEntidad.Item("CMEN")
            _Row_Encabezado.Item("Direccion") = _RowEntidad.Item("DIEN")

            Sb_Actualizar_Txt()

            AddHandler Btn_Check_In.Click, AddressOf Btn_Check_In_Click
            'AddHandler Btn_Grabar.Click, AddressOf Sb_New_OT_Grabar_Nueva_OT

            Btn_Direccion_Servicio.Enabled = Chk_Serv_Domicilio.Checked

            Me.Text = "CREACION DE NUEVA ORDEN DE TRABAJO... EN PROCESO"

            Estado_01_Ingreso.TextColor = Color.Black
            Estado_01_Ingreso.ProgressColors = New System.Drawing.Color() {Color.Yellow, Color.Yellow} '{Color.GreenYellow, Color.GreenYellow}
            Estado_01_Ingreso.Value = 100
            Estado_01_Ingreso.HotTracking = True

            Tabs_Producto.SelectedTabIndex = 0
            Tabs_Producto.Tabs(1).Visible = False

            Btn_Ver_GRP_PRE.Enabled = False

            Me.ActiveControl = Txt_Producto

        ElseIf _Accion = Accion.Editar Then

            Btn_Check_In.Visible = False
            Btn_Grabar.Enabled = False
            Btn_Editar.Visible = True

            Sb_Old_OT_Traer_OT()

            AddHandler Btn_Grabar.Click, AddressOf Sb_Editar_OT

            Me.Text = "GESTION DE ORDEN DE TRABAJO (" & _Id_Ot & ")"

            If Trim(_Row_Encabezado.Item("CodEstado")) = "E" Then
                Btn_Cerrar_OT.Visible = True
            End If

            Btn_Imprimir.Visible = True

            If Not (_Row_Estado_1 Is Nothing) Then
                Btn_Imprimir_Acta_ingreso.Visible = True
            End If

            If Not (_Row_Estado_4 Is Nothing) Then
                Btn_Imprimir_Evaluacion_Tecnico.Visible = True
            End If

            If Not (_Row_Estado_5 Is Nothing) Then
                Btn_Imprimir_Reporte_Final.Visible = True
            End If

            If Not IsNothing(_RowProducto) Then
                Tabs_Producto.SelectedTabIndex = 0
                Tabs_Producto.Tabs(1).Visible = False
            Else
                Tabs_Producto.SelectedTabIndex = 1
                Tabs_Producto.Tabs(0).Visible = False
            End If

            If CBool(_Id_Ot_Padre) Then
                _TieneHnosSubOT = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Encabezado", "Id_Ot_Padre = " & _Id_Ot_Padre)
            End If

            Warning_NoReparable.Visible = _Row_Notas.Item("Chk_No_se_pudo_reparar")

        End If

        If Trim(_Row_Encabezado.Item("CodEstado")) = "CE" Or Trim(_Row_Encabezado.Item("CodEstado")) = "N" Then
            Btn_Editar.Visible = False
        End If

        AddHandler Chk_Serv_Garantia.CheckedChanged, AddressOf Chk_Serv_Garantia_CheckedChanged

    End Sub

    Sub Sb_Editar_Activar_Desactivar_Objetos(_Activar As Boolean)

        'Grupo_Chk_Tipo_Reparacion.Enabled = _Activar

        Btn_Grabar.Enabled = _Activar

        Chk_Serv_Domicilio.Enabled = _Activar
        Chk_Serv_Reparacion_Stock.Enabled = _Activar
        Chk_Serv_Recoleccion.Enabled = _Activar
        Chk_Serv_Presupuesto_Pre_Aprobado.Enabled = _Activar
        Chk_Serv_Mantenimiento_Correctivo.Enabled = _Activar
        Chk_Serv_Mantenimiento_Preventivo.Enabled = _Activar
        Chk_Serv_Reparacion_Stock.Enabled = _Activar
        Chk_Serv_Garantia.Enabled = _Activar
        Chk_Serv_Demostracion_Maquina.Enabled = _Activar

        Btn_Direccion_Servicio.Enabled = Chk_Serv_Domicilio.Checked
        Btn_Documento_Garantia.Enabled = Chk_Serv_Garantia.Checked
        Btn_Garantia_Cambiar_Documento.Enabled = _Activar
        Btn_Contacto.Enabled = _Activar

        Btn_Tipo_Maquina.Enabled = _Activar
        Btn_Modelo.Enabled = _Activar
        Btn_Marca.Enabled = _Activar
        Btn_Categorias.Enabled = _Activar

        Dim _Read_Only As Boolean
        Dim _Color As Color

        If _Activar Then
            _Read_Only = False
            _Color = Color.White
            Btn_Editar.Enabled = False
        Else
            _Read_Only = True
            _Color = Color.LightGray
            Btn_Editar.Enabled = True
        End If

        Btn_Anular.Visible = _Activar

        Txt_Nro_Serie.ReadOnly = _Read_Only
        Txt_Defecto_segun_cliente.ReadOnly = _Read_Only
        Txt_Nota.ReadOnly = _Read_Only

        ''Txt_Maquina.BackColor = _Color
        'Txt_Maquina.FocusHighlightEnabled = _Activar

        ''Txt_Marca.BackColor = _Color
        'Txt_Marca.FocusHighlightEnabled = _Activar

        ''Txt_Modelo.BackColor = _Color
        'Txt_Modelo.FocusHighlightEnabled = _Activar

        ''Txt_Categoria.BackColor = _Color
        'Txt_Categoria.FocusHighlightEnabled = _Activar

        ''Txt_Nro_Serie.BackColor = _Color
        'Txt_Nro_Serie.FocusHighlightEnabled = _Activar

        ''Txt_Nota.BackColor = _Color
        'Txt_Nota.FocusHighlightEnabled = _Activar

        'Txt_Defecto_segun_cliente.BackColor = _Color
        'Txt_Defecto_segun_cliente.FocusHighlightEnabled = _Activar

        'Txt_Nombre_Contacto.BackColor = _Color
        'Txt_Nombre_Contacto.FocusHighlightEnabled = _Activar
        Txt_Nombre_Contacto.ReadOnly = _Read_Only

        'Txt_Email_Contacto.BackColor = _Color
        'Txt_Email_Contacto.FocusHighlightEnabled = _Activar
        Txt_Email_Contacto.ReadOnly = _Read_Only

        'Txt_Telefono_Contacto.BackColor = _Color
        'Txt_Telefono_Contacto.FocusHighlightEnabled = _Activar
        Txt_Telefono_Contacto.ReadOnly = _Read_Only

        Me.Refresh()

    End Sub


    Sub Sb_Actualizar_Txt()

        Dim _CodMaquina = _Row_Encabezado.Item("CodMaquina")

        Txt_Maquina.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla",
                                             "Tabla = 'MAQUINA_ST' And CodigoTabla = '" & _CodMaquina & "'")

        Dim _CodMarca = _Row_Encabezado.Item("CodMarca")

        Txt_Marca.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla",
                                             "Tabla = 'MARCAS' And CodigoTabla = '" & _CodMarca & "'")

        Dim _CodCategoria = _Row_Encabezado.Item("CodCategoria")

        Txt_Categoria.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla",
                                             "Tabla = 'CATEGOR_ST' And CodigoTabla = '" & _CodCategoria & "'")

        Dim _CodModelo = _Row_Encabezado.Item("CodModelo")

        Txt_Modelo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla",
                                             "Tabla = 'MODELOS_ST' And CodigoTabla = '" & _CodModelo & "'")

        Txt_Maquina.ReadOnly = True
        Txt_Marca.ReadOnly = True
        Txt_Modelo.ReadOnly = True
        Txt_Categoria.ReadOnly = True


    End Sub

    Sub Sb_Formato_Grilla()

        With Grilla

            .DataSource = _DsDocumento.Tables(0)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Nro_Ot").ReadOnly = True
            .Columns("Nro_Ot").Width = 80
            .Columns("Nro_Ot").HeaderText = "Nro O.T."
            .Columns("Nro_Ot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro_Ot").Visible = True

            .Columns("Sub_Ot").ReadOnly = True
            .Columns("Sub_Ot").Width = 60
            .Columns("Sub_Ot").HeaderText = "Sub OT"
            .Columns("Sub_Ot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Sub_Ot").Visible = True

            .Columns("Rut").ReadOnly = True
            .Columns("Rut").Width = 90
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Visible = True

            .Columns("Cliente").ReadOnly = True
            .Columns("Cliente").Width = 270 - 40
            .Columns("Cliente").HeaderText = "Nombre del cliente"
            .Columns("Cliente").Visible = True

            .Columns("Fecha_Ingreso").ReadOnly = True
            .Columns("Fecha_Ingreso").Width = 100
            .Columns("Fecha_Ingreso").HeaderText = "Fecha Ingreso"
            .Columns("Fecha_Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Ingreso").Visible = True

            .Columns("Fecha_Entrega").Visible = True
            .Columns("Fecha_Entrega").HeaderText = "Fecha Cierre"
            .Columns("Fecha_Entrega").Width = 100
            .Columns("Fecha_Entrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '.Columns("Hora").Visible = True
            '.Columns("Hora").HeaderText = "Hora"
            '.Columns("Hora").Width = 60
            '.Columns("Hora").DefaultCellStyle.Format = "hh:mm:ss"

            .Columns("Estado").ReadOnly = True
            .Columns("Estado").Width = 100
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").Visible = True

            '_DsDocumento.Tables(0).Columns("Cliente").ReadOnly = False

        End With

    End Sub
    '

#Region "PROCEDIMIENTO NUEVO DOCUMENTO"


#Region "PROCEDIMIENTOS GRABAR DOCUMENTO"

    Sub Sb_New_OT_Grabar_Nueva_OT()

        If Fx_Se_Puede_Grabar() Then

            With _Row_Encabezado
                .Item("CodEstado") = "I"
                .Item("Estado") = "INGRESADO"
                .Item("Codigo") = _RowProducto.Item("KOPR")
                .Item("Descripcion") = _RowProducto.Item("NOKOPR")
            End With

            Dim _Nro_GRP As String
            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese Guía/Factura del cliente", "Recepción de producto", _Nro_GRP,
                                              False, _Tipo_Mayus_Minus.Mayusculas, 10, True)

            If _Aceptar Then

                Dim _Nro_OT As String
                _Id_Ot = Fx_Crear_OT(_DsDocumento, _Nro_OT)

                If CBool(_Id_Ot) Then

                    Dim _Idmaeedo As Integer = Fx_Crear_GRP_PRE(_Nro_OT, _Nro_GRP)

                    If Convert.ToBoolean(_Idmaeedo) Then

                        MessageBoxEx.Show(Me, "Guía de recepción por prestamos creada correctamente", "Guía de recpción",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)

                        _Idmaeedo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_St_OT_Encabezado", "Idmaeedo_GRP_PRE", "Id_Ot = " & _Id_Ot)

                        Dim Fm As New Frm_Seleccionar_Formato("GRP")

                        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

                            Dim _NombreFormato = String.Empty
                            Fm.ShowDialog(Me)

                            If Fm.Formato_Seleccionado Then
                                _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                                Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _Idmaeedo,
                                                                               False, True, "", False, 0, False, "")

                                If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                                    MessageBox.Show(Me, _Imprime, "Problemas al Imprimir",
                                               MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                End If

                            End If

                        Else

                            MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        End If

                        Fm.Dispose()

                    End If

                    _Abrir_Documento = True
                    Me.Close()

                End If

            End If

        End If

    End Sub

    Function Fx_Crear_GRP_PRE(_Nro_OT As String, _Nro_GRP As String) As Integer

        Dim _ServTecnico_Empresa As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa").ToString.Trim
        Dim _ServTecnico_Sucursal As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal").ToString.Trim
        Dim _ServTecnico_Bodega As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega").ToString.Trim

        If String.IsNullOrEmpty(_ServTecnico_Empresa.Trim) Then

            MessageBoxEx.Show(Me, "Debe seleccionar la bodega por defecto para Servicio Técnico",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Dim _Row_Bodega As DataRow

            Dim Fmb As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
            Fmb.Pro_Empresa = ModEmpresa
            Fmb.Pro_Sucursal = ModSucursal
            Fmb.Pro_Bodega = ModBodega
            Fmb.ShowDialog(Me)
            _Row_Bodega = Fmb.Pro_RowBodega

            If Fmb.Pro_Seleccionado Then

                _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa") = _Row_Bodega.Item("EMPRESA")
                _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal") = _Row_Bodega.Item("KOSU")
                _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega") = _Row_Bodega.Item("KOBO")

                _ServTecnico_Empresa = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa")
                _ServTecnico_Sucursal = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal")
                _ServTecnico_Bodega = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Configuracion Set 
                                ServTecnico_Empresa = '" & _ServTecnico_Empresa & "',
                                ServTecnico_Sucursal = '" & _ServTecnico_Sucursal & "',
                                ServTecnico_Bodega = '" & _ServTecnico_Bodega & "' 
                                Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            Else

                MessageBoxEx.Show(Me, "No puede generar una Guía si no ingresa la bodega por defecto", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return 0

            End If

        End If


        'ServTecnico_Empresa, ServTecnico_Sucursal, ServTecnico_Bodega
        Consulta_sql = "Insert Into MAEST (EMPRESA,KOSU,KOBO,KOPR) Values ('" & ModEmpresa & "','" & _ServTecnico_Sucursal & "','" & _ServTecnico_Bodega & "','" & _RowProducto.Item("KOPR") & "')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Dim _NroDocumento = Fx_Rellena_ceros(_Nro_GRP, 10)

        Dim _Observaciones As String = "Documento generado desde Sis. Servicio técnico Bakapp" & vbCrLf & "Nro OT: " & _Nro_OT

        Dim _Costo As Double = _Sql.Fx_Trae_Dato("TABPRE", "PP01UD",
                                                 "KOLT = '" & ModListaPrecioVenta & "' And KOPR = '" & _RowProducto.Item("KOPR") & "'", True)

        Consulta_sql = "Select '" & _ServTecnico_Sucursal & "' As Sucursal,'" & _ServTecnico_Bodega & "' As Bodega,'" & _RowProducto.Item("KOPR") & "' As Codigo,
                        1 As Cantidad," & De_Num_a_Tx_01(_Costo, False, 5) & " As Costo"
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_Formulario_Documento("GRP", csGlobales.Enum_Tipo_Documento.Guia_Recepcion_Prestamos_GRP_PRE,
                                                   False, True, False, False, False)
        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla2(Me, _Tbl_Productos, FechaDelServidor,
                                                     "Codigo", "Cantidad", "Costo", _Observaciones, False, False, _NroDocumento)
        Dim _Mensaje As LsValiciones.Mensajes = Fm.Fx_Grabar_Documento(False,, False)
        Fm.Dispose()

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set Idmaeedo_GRP_PRE = " & _Mensaje.Id & " 
                        Where Id_Ot = " & _Id_Ot & vbCrLf &
                       "Update MAEEDOOB Set OCDO = '" & _Nro_OT & "',TEXTO1 = '" & Txt_Nombre_Contacto.Text & "'
                        Where IDMAEEDO = " & _Mensaje.Id
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        If _Mensaje.EsCorrecto Then

            Dim _Koen = _RowEntidad.Item("KOEN")
            Dim _Suen = _RowEntidad.Item("SUEN")

            Consulta_sql = "Update MAEEN Set TIEN = 'A' Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Return _Mensaje.Id

    End Function


#End Region

    Sub Sb_New_OT_Nueva_OT()

        Consulta_sql = My.Resources.Recursos_Locales.SqlQuery_Traer_OT
        Consulta_sql = Replace(Consulta_sql, "#Id_Ot#", 0)
        Consulta_sql = Replace(Consulta_sql, "#Db_BakApp#", _Global_BaseBk)

        _DsDocumento = _Sql_Query.Fx_Get_DataSet(Consulta_sql, False)

        Sb_New_OT_Agregar_Filas()

    End Sub

    Sub Sb_New_OT_Agregar_Filas()

        Dim NewFila As DataRow
        NewFila = _DsDocumento.Tables(0).NewRow
        With NewFila

            .Item("Nro_Ot") = "En proceso..."
            .Item("Fecha_Ingreso") = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            .Item("Empresa") = ModEmpresa '_Global_Row_Modalidad.Item("EMPRESA")
            .Item("Sucursal") = ModSucursal '_Global_Row_Modalidad.Item("ESUCURSAL")
            .Item("Bodega") = ModBodega '_Global_Row_Modalidad.Item("EBODEGA")

            .Item("CodEntidad") = _RowEntidad.Item("KOEN")
            .Item("SucEntidad") = _RowEntidad.Item("SUEN")
            .Item("Rten") = _RowEntidad.Item("RTEN")

            Dim _Rt = _RowEntidad.Item("RTEN")
            Dim _Rut As String = FormatNumber(_Rt, 0) & "-" & RutDigito(_Rt)
            .Item("Rut") = _Rut

            .Item("Cliente") = _RowEntidad.Item("NOKOEN")

            .Item("CodEstado") = "I"
            .Item("Estado") = "Ingresado"

            _DsDocumento.Tables(0).Rows.Add(NewFila)
        End With


        NewFila = _DsDocumento.Tables(3).NewRow
        With NewFila

            .Item("Defecto_segun_cliente") = String.Empty
            .Item("Reparacion_a_realizar") = String.Empty
            .Item("Defecto_encontrado") = String.Empty
            .Item("Reparacion_Realizada") = String.Empty
            .Item("Chk_no_se_pudo_reparar") = False
            .Item("Motivo_no_reparo") = String.Empty

            _DsDocumento.Tables(3).Rows.Add(NewFila)
        End With

    End Sub

    Function Fx_Crear_OT(_DsDocumento As DataSet,
                         ByRef _Nro_Ot As String) As Integer


        Dim _Id_Ot As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        Dim _Tipo_compra As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Cn As New SqlConnection

        Try


            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            ' INSERTAR ENCABEZADO DE DOCUMENTO

            If String.IsNullOrEmpty(_Nro_Ot) Then
                _Nro_Ot = Fx_NvoNro_OT()
            End If


            Dim _Fecha_Ingreso As String = Format("yyyyMMdd", FechaDelServidor)
            Dim _Fecha_Compromiso
            Dim _Fecha_Entrega

            Dim _CodEstado As String = _Row_Encabezado.Item("CodEstado")

            Dim _Empresa As String = _Row_Encabezado.Item("Empresa")
            Dim _Sucursal As String = _Row_Encabezado.Item("Sucursal")
            Dim _Bodega As String = _Row_Encabezado.Item("Bodega")


            Dim _CodEntidad As String = _Row_Encabezado.Item("CodEntidad")
            Dim _SucEntidad As String = _Row_Encabezado.Item("SucEntidad")
            Dim _Rten As String = _Row_Encabezado.Item("Rten")

            Dim _Rut As String = _Row_Encabezado.Item("Rut")
            Dim _CodMaquina As String = NuloPorNro(_Row_Encabezado.Item("CodMaquina"), "")
            Dim _CodMarca As String = NuloPorNro(_Row_Encabezado.Item("CodMarca"), "")
            Dim _CodModelo As String = NuloPorNro(_Row_Encabezado.Item("CodModelo"), "")
            Dim _CodCategoria As String = NuloPorNro(_Row_Encabezado.Item("CodCategoria"), "")
            Dim _NroSerie As String = _Row_Encabezado.Item("NroSerie")
            Dim _NroOcc_Cliente As String = _Row_Encabezado.Item("NroOcc_Cliente")

            Dim _Chk_Serv_Domicilio As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Domicilio")) * -1

            Dim _Pais As String = _Row_Encabezado.Item("Pais")
            Dim _Ciudad As String = _Row_Encabezado.Item("Ciudad")
            Dim _Comuna As String = _Row_Encabezado.Item("Comuna")
            Dim _Direccion As String = _Row_Encabezado.Item("Direccion")

            Dim _Chk_Serv_Reparacion_Stock As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Reparacion_Stock")) * -1
            Dim _Chk_Serv_Mantenimiento_Correctivo As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Mantenimiento_Correctivo")) * -1
            Dim _Chk_Serv_Presupuesto_Pre_Aprobado As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Presupuesto_Pre_Aprobado")) * -1
            Dim _Chk_Serv_Recoleccion As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Recoleccion")) * -1
            Dim _Chk_Serv_Mantenimiento_Preventivo As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Mantenimiento_Preventivo")) * -1
            Dim _Chk_Serv_Garantia As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Garantia")) * -1
            Dim _Chk_Serv_Demostracion_Maquina As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Demostracion_Maquina")) * -1

            Dim _Nombre_Contacto As String = Trim(Txt_Nombre_Contacto.Text)
            Dim _Telefono_Contacto As String = Trim(Txt_Telefono_Contacto.Text)
            Dim _Email_Contacto As String = Trim(Txt_Email_Contacto.Text)

            'Dim _CodTecnico As String = _Row_Encabezado.Item("SucEntidad")
            Dim _Chk_Equipo_Reparado As Integer = _Row_Encabezado.Item("Chk_Equipo_Reparado")
            Dim _Idmaeedo_COV As String = _Row_Encabezado.Item("Idmaeedo_COV")
            Dim _Nudo_COV As String = _Row_Encabezado.Item("Nudo_COV")
            Dim _Neto As String = _Row_Encabezado.Item("Neto")
            Dim _Iva As String = _Row_Encabezado.Item("Iva")
            Dim _Total As String = _Row_Encabezado.Item("Total")

            Dim _Codigo_Pr As String = _Row_Encabezado.Item("Codigo")
            Dim _Descripcion_Pr As String = _Row_Encabezado.Item("Descripcion")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Encabezado (Nro_Ot,Empresa,Sucursal,Bodega,Fecha_Ingreso,Fecha_Compromiso," &
                           "Fecha_Entrega,CodEstado,CodEntidad,SucEntidad,Rten,Rut,CodMarca,CodModelo,CodMaquina,CodCategoria,NroSerie," &
                           "NroOcc_Cliente,Chk_Serv_Domicilio,Pais,Ciudad,Comuna,Direccion,Chk_Serv_Reparacion_Stock,Chk_Serv_Mantenimiento_Correctivo," &
                           "Chk_Serv_Presupuesto_Pre_Aprobado,Chk_Serv_Recoleccion,Chk_Serv_Mantenimiento_Preventivo," &
                           "Chk_Serv_Garantia,Chk_Serv_Demostracion_Maquina,Chk_Equipo_Reparado,Idmaeedo_COV,Nudo_COV,Neto,Iva,Total," &
                           "Nombre_Contacto,Telefono_Contacto,Email_Contacto,Codigo,Descripcion) Values " & vbCrLf &
                           "('" & _Nro_Ot & "','" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',GetDate(),Null,Null,'" & _CodEstado &
                           "','" & _CodEntidad & "','" & _SucEntidad & "','" & _Rten & "','" & _Rut & "','" & _CodMarca & "','" & _CodModelo & "','" & _CodMaquina &
                           "','" & _CodCategoria & "','" & _NroSerie & "','" & _NroOcc_Cliente & "'," & _Chk_Serv_Domicilio &
                           ",'" & _Pais & "','" & _Ciudad & "','" & _Comuna & "','" & _Direccion &
                           "'," & _Chk_Serv_Reparacion_Stock & "," & _Chk_Serv_Mantenimiento_Correctivo &
                           "," & _Chk_Serv_Presupuesto_Pre_Aprobado & "," & _Chk_Serv_Recoleccion &
                           "," & _Chk_Serv_Mantenimiento_Preventivo & "," & _Chk_Serv_Garantia &
                           "," & _Chk_Serv_Demostracion_Maquina & "," & _Chk_Equipo_Reparado &
                           ",0,'',0,0,0,'" & _Nombre_Contacto & "','" & _Telefono_Contacto & "','" & _Email_Contacto & "'" &
                           ",'" & _Codigo_Pr & "','" & _Descripcion_Pr & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)


            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            ' RESCATAMOS EL ID_OT 
            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Id_Ot = dfd("Identity")
            End While
            dfd.Close()


            ' --------------------------------------------------- DETALLE CHEK-IN ---------------------------------------

            If _Tbl_ChekIn.Rows.Count > 0 Then

                'For i As Integer = 0 To TblDetalle.Rows.Count - 1
                For Each _Fila As DataRow In _Tbl_ChekIn.Rows

                    Dim Estado As DataRowState = _Fila.RowState

                    If Estado <> DataRowState.Deleted Then

                        Dim _Codigo As String = _Fila.Item("Codigo")
                        Dim _Check_In As String = _Fila.Item("Check_In")
                        Dim _Nota As String = _Fila.Item("Nota")

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_CheckIn (Id_Ot,Codigo,Check_In,Nota) Values " &
                                      "(" & _Id_Ot & ",'" & _Codigo & "','" & _Check_In & "','" & _Nota & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                Next
            End If


            ' --------------------------------------------------- DETALLE ACCESORIOS ---------------------------------------

            If _Tbl_Accesorios.Rows.Count > 0 Then

                'For i As Integer = 0 To TblDetalle.Rows.Count - 1
                For Each _Fila As DataRow In _Tbl_Accesorios.Rows

                    Dim Estado As DataRowState = _Fila.RowState

                    If Estado <> DataRowState.Deleted Then

                        Dim _Codigo As Integer = CInt(_Fila.Item("Codigo")) * -1
                        Dim _Articulo As String = _Fila.Item("Articulo")
                        Dim _Cantidad As String = De_Num_a_Tx_01(_Fila.Item("Cantidad"), False, 5)
                        Dim __NroSerie As String = _Fila.Item("NroSerie")
                        Dim _Nota As String = _Fila.Item("Nota")

                        Consulta_sql = "Insert Into " & _Global_BaseBk &
                                      "Zw_St_OT_Accesorios (Id_Ot,Codigo,Articulo,Cantidad,NroSerie,Nota) Values " &
                                      "(" & _Id_Ot & ",'" & _Codigo & "','" & _Articulo & "'," & _Cantidad &
                                      ",'" & __NroSerie & "','" & _Nota & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                Next
            End If

            ' --------------------------------------------------- NOTAS ---------------------------------------

            Dim _Defecto_segun_cliente As String = _Row_Notas.Item("Defecto_segun_cliente")
            Dim _Nota_Etapa_01 As String = _Row_Notas.Item("Nota_Etapa_01")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Notas (Id_Ot,Defecto_segun_cliente,Nota_Etapa_01) Values " &
                          "(" & _Id_Ot & ",'" & _Defecto_segun_cliente & "','" & _Nota_Etapa_01 & "')"


            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            '**********************************'************************************************************************************


            ' --------------------------------------------------- ESTADO ---------------------------------------

            Consulta_sql = "Insert Into " & _Global_BaseBk &
                           "Zw_St_OT_Estados (Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                           "(" & _Id_Ot & ",'I',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            '**********************************'*************************************************************************************


            ' --------------------------------------------------- GARANTIA ---------------------------------------
            If Chk_Serv_Garantia.Checked Then

                Dim _Idmaeedo = _Row_Doc_Garantia.Item("IDMAEEDO")
                Dim _Tido = _Row_Doc_Garantia.Item("TIDO")
                Dim _Nudo = _Row_Doc_Garantia.Item("NUDO")
                Dim _Fecha_Doc = Format(_Row_Doc_Garantia.Item("FEEMDO"), "yyyyMMdd")

                Dim _Documento_Externo = CInt(_Garantia_Documento_Externo) * -1

                Consulta_sql = "Insert Into " & _Global_BaseBk &
                               "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Asociacion," &
                               "Fecha_Doc,Garantia,Documento_Externo) Values " &
                               "(" & _Id_Ot & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo &
                               "','G',GetDate(),'" & _Fecha_Doc & "',1," & _Documento_Externo & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If



            '**********************************'**********************************




            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            Return _Id_Ot


        Catch ex As Exception
            '
            'Consulta_sql = "ROLLBACK TRANSACTION"
            'Ej_consulta_IDU(Consulta_sql, cn1)
            MsgBox(ex.Message)
            myTrans.Rollback()

            Return 0
        End Try


    End Function

    Function Fx_NvoNro_OT() As String

        Dim _NvoNro_OT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_DataTable("Select Max(Nro_Ot) As Ult_Nro_OT From " & _Global_BaseBk & "Zw_St_OT_Encabezado") ' cn1, "MAX(Nro_SOC)", _Global_BaseBk & "ZW_SOC_Encabezado", "Stand_By = " & Stby)

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Ult_Nro_OT"), "")

            If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
                _Ult_Nro_OT = 1
            Else
                _Ult_Nro_OT += 1
            End If
            _NvoNro_OT = numero_(Val(_Ult_Nro_OT), 10)
        Else
            _NvoNro_OT = numero_(1, 10)
        End If

        Return _NvoNro_OT

    End Function

    Private Sub Btn_Check_In_Click(sender As System.Object, e As System.EventArgs)

        Dim Fm As New Frm_St_Estado_01_Ingreso_Check_In(_Id_Ot, Frm_St_Estado_01_Ingreso_Check_In.Accion.Nuevo)
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            RemoveHandler Estado_01_Ingreso.DoubleClick, AddressOf Sb_Estado_01_Ingreso_Check_In_Nuevo
            Sb_Actualizar_WockFlow()
        End If
        Fm.Dispose()

    End Sub

#End Region

#Region "PROCEDIMIENTO EDITAR DOCUMENTO"

    Sub Sb_Old_OT_Traer_OT()

        _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
        _Tbl_DetProd = _DsDocumento.Tables(1)
        _Tbl_ChekIn = _DsDocumento.Tables(2)
        _Row_Notas = _DsDocumento.Tables(3).Rows(0)
        _Tbl_Estado = _DsDocumento.Tables(4)
        _Tbl_Accesorios = _DsDocumento.Tables(5)

        If _DsDocumento.Tables(9).Rows.Count Then

            _Garantia_Documento_Externo = _DsDocumento.Tables(9).Rows(0).Item("Documento_Externo")

            If _Garantia_Documento_Externo Then

                Dim _Tido = _DsDocumento.Tables(9).Rows(0).Item("Tido")
                Dim _Nudo = _DsDocumento.Tables(9).Rows(0).Item("Nudo")
                Dim _Feemdo = Format(_DsDocumento.Tables(9).Rows(0).Item("Fecha_Doc"), "yyyyMMdd")

                Consulta_sql = "Select 0 As IDMAEEDO,'" & _Tido & "' As TIDO,'" & _Nudo & "' As NUDO,'" & _Feemdo & "' as FEEMDO"
            Else
                Dim _Idmaeedo = _DsDocumento.Tables(9).Rows(0).Item("Idmaeedo")
                Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            End If


            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                _Row_Doc_Garantia = _Tbl.Rows(0)
            End If

        End If

        Dim _CodEntidad As String = Trim(_Row_Encabezado.Item("CodEntidad"))
        Dim _SucEntidad As String = Trim(_Row_Encabezado.Item("SucEntidad"))

        Sb_Formato_Grilla()
        _RowEntidad = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)

        If Not IsNothing(_RowEntidad) Then _Row_Encabezado.Item("Cliente") = _RowEntidad.Item("NOKOEN")


        With _Row_Encabezado

            Txt_Nro_Serie.Text = .Item("NroSerie")

            Chk_Serv_Domicilio.Checked = .Item("Chk_Serv_Domicilio")
            Chk_Serv_Reparacion_Stock.Checked = .Item("Chk_Serv_Reparacion_Stock")
            Chk_Serv_Mantenimiento_Correctivo.Checked = .Item("Chk_Serv_Mantenimiento_Correctivo")
            Chk_Serv_Presupuesto_Pre_Aprobado.Checked = .Item("Chk_Serv_Presupuesto_Pre_Aprobado")
            Chk_Serv_Recoleccion.Checked = .Item("Chk_Serv_Recoleccion")
            Chk_Serv_Mantenimiento_Preventivo.Checked = .Item("Chk_Serv_Mantenimiento_Preventivo")
            Chk_Serv_Garantia.Checked = .Item("Chk_Serv_Garantia")
            Chk_Serv_Demostracion_Maquina.Checked = .Item("Chk_Serv_Demostracion_Maquina")

            Txt_Nombre_Contacto.Text = .Item("Nombre_Contacto")
            Txt_Telefono_Contacto.Text = .Item("Telefono_Contacto")
            Txt_Email_Contacto.Text = .Item("Email_Contacto")

            Dim _Codigo As String = Trim(.Item("Codigo"))

            If Not String.IsNullOrEmpty(_Codigo) Then

                Txt_Producto.Tag = Trim(_Codigo)

                Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_DatosDelProducto
                Consulta_sql = Replace(Consulta_sql, "#Codigo#", Txt_Producto.Tag)

                _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                Txt_Maquina.Text = _RowProducto.Item("NOKOPR")
                Txt_Marca.Text = _RowProducto.Item("Marca")
                Txt_Modelo.Text = _RowProducto.Item("KOPR")

                Lbl_Marca.Text = _RowProducto.Item("Marca")
                Lbl_Rubro.Text = _RowProducto.Item("Rubro")
                Lbl_Super_Familia.Text = _RowProducto.Item("SuperFamilia")
                Lbl_Familia.Text = _RowProducto.Item("Familia")
                Lbl_Sub_Familia.Text = _RowProducto.Item("SubFamilia")

                Lbl_Clas_Libre.Text = _Sql.Fx_Trae_Dato("TABCARAC", "NOKOCARAC",
                                              "KOTABLA = 'CLALIBPR' and KOCARAC = '" & _RowProducto.Item("CLALIBPR") & "'")

                Txt_Producto.Text = Txt_Producto.Tag & " - " & Trim(_RowProducto.Item("NOKOPR"))

                Btn_Producto.Enabled = False

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Row_Encabezado.Item("Idmaeedo_GRP_PRE")
                Dim _Row_GRP As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_GRP) Then
                    Lbl_GRP.Text = _Row_GRP.Item("NUDO")
                    Lbl_GRP.Tag = _Row_GRP.Item("IDMAEEDO")
                End If

            End If

            Btn_Ver_GRP_PRE.Enabled = Not (String.IsNullOrEmpty(_Codigo)) 'Convert.ToBoolean(_Row_Encabezado.Item("Idmaeedo_GRP_PRE"))

        End With

        Sb_Actualizar_Txt()

        With _Row_Notas
            Txt_Nota.Text = .Item("Nota_Etapa_01")
            Txt_Defecto_segun_cliente.Text = .Item("Defecto_segun_cliente")
        End With

        Sb_Actualizar_WockFlow()

        Sb_Editar_Activar_Desactivar_Objetos(False)

    End Sub

    Sub Sb_Editar_OT()
        If Fx_Se_Puede_Grabar() Then
            If Fx_Editar_OT(_DsDocumento, _Id_Ot) Then

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar OT",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Abrir_Documento = True
                Me.Close()
            End If
        End If
    End Sub

    Function Fx_Editar_OT(_DsDocumento As DataSet,
                          _Id_Ot As Integer) As Boolean


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        'Dim _Tipo_compra As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Cn As New SqlConnection

        Try


            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            ' INSERTAR ENCABEZADO DE DOCUMENTO

            Dim _Fecha_Ingreso As String = Format("yyyyMMdd", FechaDelServidor)

            Dim _CodEstado As String = _Row_Encabezado.Item("CodEstado")

            Dim _Empresa As String = _Row_Encabezado.Item("Empresa")
            Dim _Sucursal As String = _Row_Encabezado.Item("Sucursal")
            Dim _Bodega As String = _Row_Encabezado.Item("Bodega")

            Dim _Estado As String = _Row_Encabezado.Item("Estado")

            Dim _CodEntidad As String = _Row_Encabezado.Item("CodEntidad")
            Dim _SucEntidad As String = _Row_Encabezado.Item("SucEntidad")
            Dim _Rten As String = _Row_Encabezado.Item("Rten")

            Dim _Rut As String = _Row_Encabezado.Item("Rut")
            Dim _CodMaquina As String = _Row_Encabezado.Item("CodMaquina")
            Dim _CodMarca As String = _Row_Encabezado.Item("CodMarca")
            Dim _CodModelo As String = _Row_Encabezado.Item("CodModelo")
            Dim _CodCategoria As String = _Row_Encabezado.Item("CodCategoria")
            Dim _NroSerie As String = _Row_Encabezado.Item("NroSerie")
            Dim _NroOcc_Cliente As String = _Row_Encabezado.Item("NroOcc_Cliente")

            Dim _Chk_Serv_Domicilio As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Domicilio")) * -1

            Dim _Pais As String = _Row_Encabezado.Item("Pais")
            Dim _Ciudad As String = _Row_Encabezado.Item("Ciudad")
            Dim _Comuna As String = _Row_Encabezado.Item("Comuna")
            Dim _Direccion As String = _Row_Encabezado.Item("Direccion")

            Dim _Chk_Serv_Reparacion_Stock As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Reparacion_Stock")) * -1
            Dim _Chk_Serv_Mantenimiento_Correctivo As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Mantenimiento_Correctivo")) * -1
            Dim _Chk_Serv_Presupuesto_Pre_Aprobado As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Presupuesto_Pre_Aprobado")) * -1
            Dim _Chk_Serv_Recoleccion As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Recoleccion")) * -1
            Dim _Chk_Serv_Mantenimiento_Preventivo As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Mantenimiento_Preventivo")) * -1
            Dim _Chk_Serv_Garantia As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Garantia")) * -1
            Dim _Chk_Serv_Demostracion_Maquina As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Demostracion_Maquina")) * -1

            Dim _Nombre_Contacto As String = Trim(Txt_Nombre_Contacto.Text)
            Dim _Telefono_Contacto As String = Trim(Txt_Telefono_Contacto.Text)
            Dim _Email_Contacto As String = Trim(Txt_Email_Contacto.Text)

            'Dim _CodTecnico As String = _Row_Encabezado.Item("SucEntidad")
            Dim _Chk_Equipo_Reparado As Integer = _Row_Encabezado.Item("Chk_Equipo_Reparado")
            Dim _Idmaeedo_COV As String = _Row_Encabezado.Item("Idmaeedo_COV")
            Dim _Nudo_COV As String = _Row_Encabezado.Item("Nudo_COV")
            Dim _Neto As String = _Row_Encabezado.Item("Neto")
            Dim _Iva As String = _Row_Encabezado.Item("Iva")
            Dim _Total As String = _Row_Encabezado.Item("Total")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " & vbCrLf &
                           "CodEntidad = '" & _CodEntidad & "'," &
                           "SucEntidad = '" & _SucEntidad & "'," &
                           "Rten = '" & _Rten & "'," &
                           "Rut = '" & _Rut & "'," &
                           "CodMarca = '" & _CodMarca & "'," &
                           "CodModelo= '" & _CodModelo & "'," &
                           "CodMaquina= '" & _CodMaquina & "'," &
                           "CodCategoria = '" & _CodCategoria & "'," &
                           "NroSerie = '" & _NroSerie & "'," &
                           "NroOcc_Cliente = '" & _NroOcc_Cliente & "'," &
                           "Chk_Serv_Domicilio = " & _Chk_Serv_Domicilio & "," &
                           "Pais = '" & _Pais & "'," &
                           "Ciudad = '" & _Ciudad & "'," &
                           "Comuna = '" & _Comuna & "'," &
                           "Direccion = '" & _Direccion & "'," &
                           "Chk_Serv_Reparacion_Stock = " & _Chk_Serv_Reparacion_Stock & "," &
                           "Chk_Serv_Mantenimiento_Correctivo = " & _Chk_Serv_Mantenimiento_Correctivo & "," &
                           "Chk_Serv_Presupuesto_Pre_Aprobado = " & _Chk_Serv_Presupuesto_Pre_Aprobado & "," &
                           "Chk_Serv_Recoleccion = " & _Chk_Serv_Recoleccion & "," &
                           "Chk_Serv_Mantenimiento_Preventivo = " & _Chk_Serv_Mantenimiento_Preventivo & "," &
                           "Chk_Serv_Garantia = " & _Chk_Serv_Garantia & "," &
                           "Chk_Serv_Demostracion_Maquina = " & _Chk_Serv_Demostracion_Maquina & "," &
                           "Chk_Equipo_Reparado = " & _Chk_Equipo_Reparado & "," &
                           "Nombre_Contacto = '" & _Nombre_Contacto & "'," &
                           "Telefono_Contacto = '" & _Telefono_Contacto & "'," &
                           "Email_Contacto = '" & _Email_Contacto & "'," &
                           "Idmaeedo_COV = " & _Idmaeedo_COV & "," &
                           "Nudo_COV = '" & _Nudo_COV & "'," &
                           "Neto = " & _Neto & "," &
                           "Iva = " & _Iva & "," &
                           "Total = " & _Total & vbCrLf &
                           "Where Id_Ot = " & _Id_Ot

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            ' --------------------------------------------------- DETALLE CHEK-IN ---------------------------------------


            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_CheckIn Where Id_Ot = " & _Id_Ot & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_St_OT_Accesorios Where Id_Ot = " & _Id_Ot

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            If _Tbl_ChekIn.Rows.Count > 0 Then

                'For i As Integer = 0 To TblDetalle.Rows.Count - 1
                For Each _Fila As DataRow In _Tbl_ChekIn.Rows

                    Dim Estado As DataRowState = _Fila.RowState

                    If Estado <> DataRowState.Deleted Then

                        Dim _Codigo As String = _Fila.Item("Codigo")
                        Dim _Check_In As String = _Fila.Item("Check_In")
                        Dim _Nota As String = _Fila.Item("Nota")

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_CheckIn (Id_Ot,Codigo,Check_In,Nota) Values " &
                                      "(" & _Id_Ot & ",'" & _Codigo & "','" & _Check_In & "','" & _Nota & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                Next
            End If


            ' --------------------------------------------------- DETALLE ACCESORIOS ---------------------------------------


            If _Tbl_Accesorios.Rows.Count > 0 Then

                'For i As Integer = 0 To TblDetalle.Rows.Count - 1
                For Each _Fila As DataRow In _Tbl_Accesorios.Rows

                    Dim Estado As DataRowState = _Fila.RowState

                    If Estado <> DataRowState.Deleted Then

                        Dim _Codigo As Integer = CInt(_Fila.Item("Codigo")) * -1
                        Dim _Articulo As String = _Fila.Item("Articulo")
                        Dim _Cantidad As String = De_Num_a_Tx_01(_Fila.Item("Cantidad"), False, 5)
                        Dim __NroSerie As String = _Fila.Item("NroSerie")
                        Dim _Nota As String = _Fila.Item("Nota")

                        Consulta_sql = "Insert Into " & _Global_BaseBk &
                                      "Zw_St_OT_Accesorios (Id_Ot,Codigo,Articulo,Cantidad,NroSerie,Nota) Values " &
                                      "(" & _Id_Ot & ",'" & _Codigo & "','" & _Articulo & "'," & _Cantidad &
                                      ",'" & __NroSerie & "','" & _Nota & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                Next
            End If


            ' --------------------------------------------------- NOTAS -----------------------------------------

            Dim _Defecto_segun_cliente As String = _Row_Notas.Item("Defecto_segun_cliente")
            Dim _Nota_Etapa_01 As String = _Row_Notas.Item("Nota_Etapa_01")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                          "Defecto_segun_cliente = '" & _Defecto_segun_cliente & "'," &
                          "Nota_Etapa_01 = '" & _Nota_Etapa_01 & "'" & vbCrLf &
                          "Where Id_Ot = " & _Id_Ot

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            '*****************************************************************************************************

            ' --------------------------------------------------- GARANTIA ---------------------------------------

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados" & vbCrLf &
                           "Where Id_Ot = " & _Id_Ot & " And Garantia = 1"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            If Chk_Serv_Garantia.Checked Then

                Dim _Idmaeedo = _Row_Doc_Garantia.Item("IDMAEEDO")
                Dim _Tido = _Row_Doc_Garantia.Item("TIDO")
                Dim _Nudo = _Row_Doc_Garantia.Item("NUDO")
                Dim _Fecha_Doc = Format(_Row_Doc_Garantia.Item("FEEMDO"), "yyyyMMdd")

                If _Idmaeedo = 0 Then
                    _Fecha_Doc = _Row_Doc_Garantia.Item("FEEMDO")
                End If

                Dim _Documento_Externo = CInt(_Garantia_Documento_Externo) * -1

                Consulta_sql = "Insert Into " & _Global_BaseBk &
                               "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Asociacion,Fecha_Doc," &
                               "Garantia,Documento_Externo) Values " &
                               "(" & _Id_Ot & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo &
                               "','G',GetDate(),'" & _Fecha_Doc & "',1," & _Documento_Externo & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            '**********************************'*****************************************************************

            If _EditarContactoTodasLasSubOT Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " & vbCrLf &
               "Nombre_Contacto = '" & _Nombre_Contacto & "'," &
               "Telefono_Contacto = '" & _Telefono_Contacto & "'," &
               "Email_Contacto = '" & _Email_Contacto & "'" & vbCrLf &
               "Where Id_Ot_Padre = " & _Id_Ot_Padre

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            Return True


        Catch ex As Exception
            '
            'Consulta_sql = "ROLLBACK TRANSACTION"
            'Ej_consulta_IDU(Consulta_sql, cn1)
            MsgBox(ex.Message)
            myTrans.Rollback()


        End Try


    End Function

#End Region

    Function Fx_Se_Puede_Grabar() As Boolean

        Dim _CodMaquina As String = NuloPorNro(_Row_Encabezado.Item("CodMarca"), "") 'Cmb_Marca.SelectedValue
        Dim _CodMarca As String = NuloPorNro(_Row_Encabezado.Item("CodMarca"), "") 'Cmb_Marca.SelectedValue
        Dim _CodModelo As String = NuloPorNro(_Row_Encabezado.Item("CodModelo"), "") ' Cmb_Modelo.SelectedValue
        Dim _codCategorias As String = NuloPorNro(_Row_Encabezado.Item("CodCategoria"), "") 'Cmb_Categoria.SelectedValue

        If IsNothing(_RowProducto) Then
            Beep()
            ToastNotification.Show(Me, "FALTA INGRESAR EL PRODUCTO",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)

            Return False

            If String.IsNullOrEmpty(_CodMaquina) Then
                Beep()
                ToastNotification.Show(Me, "FALTA TIPO DE MAQUINA",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Txt_Maquina.Focus()
                'Txt_Maquina.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(_CodMarca) Then
                Beep()
                ToastNotification.Show(Me, "FALTA LA MARCA",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Txt_Marca.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(_CodModelo) Then
                Beep()
                ToastNotification.Show(Me, "FALTA EL MODELO",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Txt_Modelo.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(_codCategorias) Then
                Beep()
                ToastNotification.Show(Me, "FALTA LA CATEGORIA",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Txt_Categoria.Focus()
                Return False
            End If

        End If

        If _Accion = Accion.Nuevo Then

            If String.IsNullOrEmpty(Txt_Nro_Serie.Text) Then
                Beep()
                ToastNotification.Show(Me, "FALTA NUMERO DE SERIE DE LA MAQUINA (CHASIS)",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Txt_Nro_Serie.Focus()
                Return False
            End If

        End If

        If String.IsNullOrEmpty(Txt_Defecto_segun_cliente.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA DEFECTO DE LA MAQUINA",
                                   Imagenes_32x32.Images.Item("warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Defecto_segun_cliente.Focus()
            Return False
        End If


        If Chk_Serv_Garantia.Checked Then

            If (_Row_Doc_Garantia Is Nothing) Then
                Beep()
                ToastNotification.Show(Me, "FALTA ADJUNTAR DOCUMENTO DE GARANTIA",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Return False
            Else
                If Not Fx_Tiene_Permiso(Me, "Stec0005") Then
                    Return False
                End If
            End If

        End If

        If String.IsNullOrEmpty(Txt_Nombre_Contacto.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA NOMBRE DE CONTACTO",
                                   Imagenes_32x32.Images.Item("warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Nombre_Contacto.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Telefono_Contacto.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA TELEFONO DE CONTACTO",
                                   Imagenes_32x32.Images.Item("warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Telefono_Contacto.Focus()
            Return False
        End If

        If Not String.IsNullOrEmpty(Trim(Txt_Email_Contacto.Text)) Then

            If Not Fx_Validar_Email(Txt_Email_Contacto.Text) Then
                Beep()
                ToastNotification.Show(Me, "VALIDACION DE EMAIL" & vbCrLf &
                                       "Formato Ej: micorreo@correo.com",
                                       Imagenes_32x32.Images.Item("warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Txt_Email_Contacto.Focus()
                Return False
            End If

        End If

        With _Row_Encabezado

            .Item("NroSerie") = Txt_Nro_Serie.Text
            If _Accion = Accion.Nuevo Then .Item("NroOcc_Cliente") = String.Empty

            .Item("Chk_Serv_Domicilio") = Chk_Serv_Domicilio.Checked
            .Item("Chk_Serv_Reparacion_Stock") = Chk_Serv_Reparacion_Stock.Checked
            .Item("Chk_Serv_Mantenimiento_Correctivo") = Chk_Serv_Mantenimiento_Correctivo.Checked
            .Item("Chk_Serv_Presupuesto_Pre_Aprobado") = Chk_Serv_Presupuesto_Pre_Aprobado.Checked
            .Item("Chk_Serv_Recoleccion") = Chk_Serv_Recoleccion.Checked
            .Item("Chk_Serv_Mantenimiento_Preventivo") = Chk_Serv_Mantenimiento_Preventivo.Checked
            .Item("Chk_Serv_Garantia") = Chk_Serv_Garantia.Checked
            .Item("Chk_Serv_Demostracion_Maquina") = Chk_Serv_Demostracion_Maquina.Checked

            If _Accion = Accion.Nuevo Then .Item("Chk_Equipo_Reparado") = False
            If _Accion = Accion.Nuevo Then .Item("Idmaeedo_COV") = 0
            If _Accion = Accion.Nuevo Then .Item("Nudo_COV") = String.Empty
            If _Accion = Accion.Nuevo Then .Item("Neto") = 0
            If _Accion = Accion.Nuevo Then .Item("Iva") = 0
            If _Accion = Accion.Nuevo Then .Item("Total") = 0

        End With

        With _Row_Notas
            .Item("Defecto_segun_cliente") = Txt_Defecto_segun_cliente.Text.Trim
            .Item("Nota_Etapa_01") = Txt_Nota.Text.Trim
        End With

        Dim _Contador = 0
        Dim _Check_In, _Accesorios As Boolean

        If _Accion = Accion.Nuevo Then

            If CBool(_Tbl_ChekIn.Rows.Count) Then
                For Each _F As DataRow In _Tbl_ChekIn.Rows
                    If _F.RowState <> DataRowState.Deleted Then
                        _Contador += 1
                    End If
                Next
                If CBool(_Contador) Then
                    _Check_In = True
                End If
            End If

            If Not _Check_In Then
                If MessageBoxEx.Show(Me, "¿Desea continuar sin realizar el Check-In?",
                                     "No se realizó el Check-In",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return False
                End If
            End If

            If CBool(_Tbl_Accesorios.Rows.Count) Then
                For Each _F As DataRow In _Tbl_Accesorios.Rows
                    If _F.RowState <> DataRowState.Deleted Then
                        _Contador += 1
                    End If
                Next
                If CBool(_Contador) Then
                    _Accesorios = True
                End If
            End If

            If Not _Accesorios Then
                If MessageBoxEx.Show(Me, "¿Desea continuar sin incorporar accesorios?",
                                 "No se ingresaron accesorios con la maquina",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return False
                End If
            End If

        End If

        Return True

    End Function


#Region "WORKFLOW"

    Sub Sb_Actualizar_Estados()

        For Each _Fila As DataRow In _Tbl_Estado.Rows

            Dim _CodEstado = _Fila.Item("CodEstado")

            Select Case _CodEstado
                Case "I"
                    _Row_Estado_1 = _Fila
                    Dim _Fecha As Date = _Row_Estado_1.Item("Fecha_Fijacion")
                    Fx_Estados(Estado_01_Ingreso, "Ingresado", "Check_In",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow)

                Case "A"
                    _Row_Estado_2 = _Fila

                    Dim _Fecha As Date = _Row_Estado_2.Item("Fecha_Fijacion")
                    Fx_Estados(Estado_02_Asignar_Tecnico, "Asignado", Trim(_Row_Encabezado.Item("Tecnico_Asignado")),
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow)

                Case "P"
                    _Row_Estado_3 = _Fila
                    Dim _Fecha As Date = _Row_Estado_3.Item("Fecha_Fijacion")
                    Fx_Estados(Estado_03_Presupuesto, "Presupuesto", "",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow)

                Case "C"
                    _Row_Estado_4 = _Fila
                    Dim _Fecha As Date = _Row_Estado_4.Item("Fecha_Fijacion")
                    Fx_Estados(Estado_04_Cotizacion, "Cotizacion", "",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow)

                Case "R"
                    _Row_Estado_5 = _Fila
                    Dim _Fecha As Date = _Row_Estado_5.Item("Fecha_Fijacion")
                    Fx_Estados(Estado_05_Reparacion_Cierre, "Reparación", "",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow)

                Case "V"
                    _Row_Estado_6 = _Fila
                    Dim _Fecha As Date = _Row_Estado_6.Item("Fecha_Fijacion")
                    Fx_Estados(Estado_06_Aviso, "Aviso", "",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow)

                Case "F"
                    _Row_Estado_7 = _Fila
                    Dim _Fecha As Date = _Row_Estado_6.Item("Fecha_Fijacion")
                    Fx_Estados(Estado_07_Entrega, "Entrega/Facturación", "",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow)


            End Select


        Next

    End Sub

    Sub Sb_Actualizar_WockFlow()

        Dim _CodEstado As String = Trim(_Row_Encabezado.Item("CodEstado"))
        Dim _Proximo_Estado As StepItem

        Select Case _CodEstado
            Case "I"

                _Info_Estado_A_Realizar = "Asignar un técnico / taller para la realización del presupuesto"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Nuevo

                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_06_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_08_Facturado.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_02_Asignar_Tecnico

            Case "A"

                _Info_Estado_A_Realizar = "Generar el presupuesto"
                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Nuevo


                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_06_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_08_Facturado.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_03_Presupuesto


            Case "P"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar

                _Info_Estado_A_Realizar = "Generar Cotización. (Importar desde el sistema)"
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Editar

                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Estado_04_Cotizacion_Nuevo
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_06_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_08_Facturado.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_04_Cotizacion

            Case "C"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Editar

                _Info_Estado_A_Realizar = "Reparación y  Cierre..."

                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Estado_04_Cotizacion_Lectura
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_06_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Info_Estado_a_realizar
                ' AddHandler Estado_08_Facturado.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_05_Reparacion_Cierre

            Case "R"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Editar
                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Estado_04_Cotizacion_Lectura

                _Info_Estado_A_Realizar = "Reparación y  Cierre..."

                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Estado_05_Reparacion_Nuevo
                'AddHandler Estado_06_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_08_Facturado.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_05_Reparacion_Cierre

            Case "V"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Editar
                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Estado_04_Cotizacion_Lectura
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Estado_05_Reparacion_Lectura
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Estado_06_Aviso_Cliente_Nuevo

                _Info_Estado_A_Realizar = "Aviso al cliente..."

                'AddHandler Estado_06_Cierre.Click, AddressOf Sb_Info_Estado_a_realizar

                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Info_Estado_a_realizar
                'AddHandler Estado_08_Facturado.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_06_Aviso


            Case "F"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Editar
                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Estado_04_Cotizacion_Lectura
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Estado_05_Reparacion_Lectura
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Estado_06_Aviso_Cliente_Lectura
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Estado_07_Entrega_Facturacion_Nuevo

                _Proximo_Estado = Estado_07_Entrega

            Case "E"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Editar
                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Estado_04_Cotizacion_Lectura
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Estado_05_Reparacion_Lectura
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Estado_06_Aviso_Cliente_Lectura
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Estado_07_Entrega_Facturacion_Lectura

                _Proximo_Estado = Nothing

            Case "CE"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ingreso_Check_In_Editar
                AddHandler Estado_02_Asignar_Tecnico.Click, AddressOf Sb_Estado_02_Asignar_Editar
                AddHandler Estado_03_Presupuesto.Click, AddressOf Sb_Estado_03_Presupuesto_Editar
                AddHandler Estado_04_Cotizacion.Click, AddressOf Sb_Estado_04_Cotizacion_Lectura
                AddHandler Estado_05_Reparacion_Cierre.Click, AddressOf Sb_Estado_05_Reparacion_Lectura
                AddHandler Estado_06_Aviso.Click, AddressOf Sb_Estado_06_Aviso_Cliente_Lectura
                AddHandler Estado_07_Entrega.Click, AddressOf Sb_Estado_07_Entrega_Facturacion_Lectura

                _Proximo_Estado = Nothing

            Case Else

                _Proximo_Estado = Nothing 'Estado_01_Ingreso

        End Select



        Sb_Actualizar_Estados()

        If Not (_Proximo_Estado Is Nothing) Then

            _Proximo_Estado.TextColor = Color.Black
            _Proximo_Estado.ProgressColors = New System.Drawing.Color() {Color.Yellow, Color.Yellow} '{Color.GreenYellow, Color.GreenYellow}
            _Proximo_Estado.Value = 100
            _Proximo_Estado.HotTracking = True

            AddHandler _Proximo_Estado.MouseEnter, AddressOf Estado_MouseEnter
            AddHandler _Proximo_Estado.MouseLeave, AddressOf Estado_MouseLeave

        End If

    End Sub

#End Region

#Region "PROCEDIMIENTOS LOGISTICA"

    Function Fx_Estados(_St_Etapa As StepItem,
                       _Encabezado As String,
                       _Espera As String,
                       _Etapa As String,
                       _Color_Arriba As Color,
                       _Color_Abajo As Color)

        Dim _Leyenda As String = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _Encabezado &
                              "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _Espera & "<br/>" & _Etapa & "</font>"

        With _St_Etapa
            .Text = _Leyenda
            .Value = 100
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {_Color_Arriba, _Color_Abajo} '{Color.GreenYellow, Color.GreenYellow}
            .HotTracking = True
        End With

        AddHandler _St_Etapa.MouseEnter, AddressOf Estado_MouseEnter
        AddHandler _St_Etapa.MouseLeave, AddressOf Estado_MouseLeave

    End Function


#End Region

#Region "CARGAR COMBOS"

    Sub Sb_Cargar_Marcas(_Marca As String,
                         Optional _Solo_Esta_Marca As Boolean = False)

        Dim _Condicion = String.Empty

        If _Solo_Esta_Marca Then
            _Condicion = "And CodigoTabla = '" & _Marca & "'"
        End If

        'caract_combo(Cmb_Marca)
        'Consulta_sql = "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf & _
        '               "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'MARCAS' " & _Condicion & " ORDER BY Orden"
        'Cmb_Marca.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        'Cmb_Marca.SelectedValue = _Marca

    End Sub

    Sub Sb_Cargar_Categoria(_Categoria As String,
                         Optional _Solo_Esta_Categoria As Boolean = False)

        Dim _Condicion = String.Empty

        If _Solo_Esta_Categoria Then
            _Condicion = "And CodigoTabla = '" & _Categoria & "'"
        End If

        'caract_combo(Cmb_Categoria)
        'Consulta_sql = "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf & _
        '               "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'CATEGOR_ST' " & _Condicion & " ORDER BY Orden"
        'Cmb_Categoria.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        'Cmb_Categoria.SelectedValue = _Categoria

    End Sub

    Sub Sb_Cargar_Modelo(_Modelo As String,
                         Optional _Solo_Este_Modelo As Boolean = False)

        Dim _Condicion = String.Empty

        If _Solo_Este_Modelo Then
            _Condicion = "And CodigoTabla = '" & _Modelo & "'"
        End If

        'caract_combo(Cmb_Modelo)
        'Consulta_sql = "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf & _
        '               "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'MODELOS_ST' " & _Condicion & " ORDER BY Orden"
        'Cmb_Modelo.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        'Cmb_Modelo.SelectedValue = _Modelo

    End Sub

#End Region

#Region "BOTONES MAQUINA, MARCA, MODELO, CATEGORIAS"

    Private Sub Btn_Tipo_Maquina_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Tipo_Maquina.Click
        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Maquina_ST,
                                                    Frm_Tabla_Caracterizaciones_01_Listado.Accion.Seleccionar)
        Fm.Text = "Seleccionar Maquina"
        Fm.ShowDialog(Me)
        If Not (Fm.Pro_RowFilaSeleccionada Is Nothing) Then

            Dim _CodMaquina = Fm.Pro_RowFilaSeleccionada.Item("CodigoTabla")
            _Row_Encabezado.Item("CodMaquina") = _CodMaquina
            Sb_Actualizar_Txt()

        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Marca_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Marca.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Marcas,
                                                        Frm_Tabla_Caracterizaciones_01_Listado.Accion.Seleccionar)
        Fm.Text = "Marcas"
        Fm.ShowDialog(Me)
        If Not (Fm.Pro_RowFilaSeleccionada Is Nothing) Then

            Dim _CodMarca = Fm.Pro_RowFilaSeleccionada.Item("CodigoTabla")
            _Row_Encabezado.Item("CodMarca") = _CodMarca
            Sb_Actualizar_Txt()

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Modelo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Modelo.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Modelos_ST,
                                                      Frm_Tabla_Caracterizaciones_01_Listado.Accion.Seleccionar)
        Fm.Text = "Seleccionar Modelo"
        Fm.ShowDialog(Me)
        If Not (Fm.Pro_RowFilaSeleccionada Is Nothing) Then

            Dim _CodModelo = Fm.Pro_RowFilaSeleccionada.Item("CodigoTabla")
            _Row_Encabezado.Item("CodModelo") = _CodModelo
            Sb_Actualizar_Txt()

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Categorias_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Categorias.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Categorias_ST,
                                                     Frm_Tabla_Caracterizaciones_01_Listado.Accion.Seleccionar)
        Fm.Text = "Seleccionar Categoria"
        Fm.ShowDialog(Me)
        If Not (Fm.Pro_RowFilaSeleccionada Is Nothing) Then

            Dim _CodCategoria = Fm.Pro_RowFilaSeleccionada.Item("CodigoTabla")
            _Row_Encabezado.Item("CodCategoria") = _CodCategoria
            Sb_Actualizar_Txt()

        End If
        Fm.Dispose()

    End Sub

#End Region

#Region "EVENTOS ESTADOS"

#Region "ESTADO 1"

    Sub Sb_Estado_01_Ingreso_Check_In_Nuevo()

        Dim Fm As New Frm_St_Estado_01_Ingreso_Check_In(_Id_Ot, Frm_St_Estado_01_Ingreso_Check_In.Accion.Nuevo)
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            RemoveHandler Estado_01_Ingreso.DoubleClick, AddressOf Sb_Estado_01_Ingreso_Check_In_Nuevo
            Sb_Actualizar_WockFlow()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Estado_01_Ingreso_Check_In_Editar()

        Dim _Editando_Documento As Boolean
        Dim _Grabar As Boolean

        Dim _Editar = True

        For Each _Fl As DataRow In _Tbl_Estado.Rows
            If _Fl.Item("CodEstado") = "P" Then
                _Editar = False
                Exit For
            End If
        Next

        Dim Fm As New Frm_St_Estado_01_Ingreso_Check_In(_Id_Ot, Frm_St_Estado_01_Ingreso_Check_In.Accion.Editar)
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.Btn_Editar.Enabled = _Editar
        Fm.ShowDialog(Me)
        _Editando_Documento = Fm.Pro_Editando_Documento
        _Grabar = Fm.Pro_Grabar
        Fm.Dispose()

        If _Editando_Documento Then
            _Abrir_Documento = True
            If _Grabar Then
                Fx_Editar_OT(_DsDocumento, _Id_Ot)
            End If
            Me.Close()
        End If

    End Sub

#End Region

#Region "ESTADO 2 "

    Sub Sb_Estado_02_Asignar_Nuevo()

        Dim Fm As New Frm_St_Estado_02_Asignacion(_Id_Ot, Frm_St_Estado_02_Asignacion.Accion.Nuevo)
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            If String.IsNullOrEmpty(_DsDocumento.Tables(0).Rows(0).Item("Pertenece")) Then
                _Abrir_Documento = True
            End If
            Me.Close()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Estado_02_Asignar_Editar()

        Dim _Editar = True

        For Each _Fl As DataRow In _Tbl_Estado.Rows
            If _Fl.Item("CodEstado") = "P" Then
                _Editar = False
                Exit For
            End If
        Next

        Dim Fm As New Frm_St_Estado_02_Asignacion(_Id_Ot, Frm_St_Estado_02_Asignacion.Accion.Editar)
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.Btn_Editar.Enabled = _Editar
        Fm.ShowDialog(Me)
        Dim _Editando_Documento As Boolean = Fm.Pro_Editando_Documento
        Dim _Grabar As Boolean = Fm.Pro_Grabar
        Fm.Dispose()

        If _Editando_Documento Then
            _Abrir_Documento = True
            Me.Close()
        End If

    End Sub

#End Region

#Region "ESTADO 3"

    Sub Sb_Estado_03_Presupuesto_Nuevo()

        If _Global_Row_Configuracion_General.Item("ServTecnico_Simple") Then

            Dim Fm As New Frm_St_Estado_03_Presupuesto(_Id_Ot, Frm_St_Estado_03_Presupuesto.Accion.Nuevo)
            Fm.Pro_DsDocumento = _DsDocumento
            Fm.Pro_Imagenes_32x32 = Imagenes_32x32
            Fm.ShowDialog(Me)
            If Fm.Pro_Grabar Then
                _Abrir_Documento = True
                Me.Close()
            End If

            Fm.Dispose()
            Return

        End If

        Dim _Aceptar As Boolean
        Dim _PwTecnico As String

        Dim _CodTecnico_Asignado = _Row_Encabezado.Item("CodTecnico_Asignado")
        Dim _Tecnico_Asignado = _Row_Encabezado.Item("Tecnico_Asignado")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller Where CodFuncionario = '" & _CodTecnico_Asignado & "'"
        Dim _Row_Tecnico_Asignado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Msg As String

        If _Row_Tecnico_Asignado.Item("EsTecnico") Then _Msg = "TECNICO"
        If _Row_Tecnico_Asignado.Item("EsTaller") Then _Msg = "TALLER"

        _Aceptar = InputBox_Bk(Me, "INGRESE LA CLAVE DEL " & _Msg & " ASIGNADO" & vbCrLf &
                               _Msg & " ASIGNADO: " & _CodTecnico_Asignado & "-" & _Tecnico_Asignado, "INGRESAR A GESTION DEL TALLER",
                               _PwTecnico, False, _Tipo_Mayus_Minus.Normal, 5, True, _Tipo_Imagen.Key,, _Tipo_Caracter.Solo_Numeros_Enteros, False, "*")

        If Not _Aceptar Then
            Return
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller Where PwTecnico = '" & _PwTecnico & "'"
        Dim _Row_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Funcionario) Then
            MessageBoxEx.Show(Me, "Clave desconocida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Estado_03_Presupuesto_Nuevo()
            Return
        End If

        If _Row_Funcionario.Item("CodFuncionario") <> _CodTecnico_Asignado Then

            If _Row_Tecnico_Asignado.Item("EsTecnico") Then _Msg = "técnico"
            If _Row_Tecnico_Asignado.Item("EsTaller") Then _Msg = "taller"

            MessageBoxEx.Show(Me, "El " & _Msg & ": " & _Row_Funcionario.Item("CodFuncionario") & "-" & _Row_Funcionario.Item("NomFuncionario").ToString.Trim &
                              " no esta asignado para realizar este presupuesto" & vbCrLf & vbCrLf &
                              "Debe ingresar la clave de " & _Tecnico_Asignado, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Estado_03_Presupuesto_Nuevo()
            Return
        End If

        Dim Fm0 As New Frm_St_Estado_03_Presupuesto2(_Id_Ot, Frm_St_Estado_03_Presupuesto.Accion.Nuevo)
        Fm0.Pro_DsDocumento = _DsDocumento
        Fm0.CodTecnico_Presupuesta = _CodTecnico_Asignado
        Fm0.ShowDialog(Me)
        If Fm0.Pro_Grabar Then
            _Abrir_Documento = True
            Me.Close()
        End If
        Fm0.Dispose()


    End Sub

    Sub Sb_Estado_03_Presupuesto_Editar()

        If _Row_Notas.Item("Chk_No_se_pudo_reparar") Then

            Dim _Motivo As String = Fx_AjustarTexto(_Row_Notas.Item("Motivo_no_reparo"), 50)
            MessageBoxEx.Show(Me, "Motivo: " & _Motivo, "NO SE PUDO REPARAR EL PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If

        Dim _Editar = True

        For Each _Fl As DataRow In _Tbl_Estado.Rows
            If _Fl.Item("CodEstado") = "C" Then
                _Editar = False
                Exit For
            End If
        Next

        Dim Fm As New Frm_St_Estado_03_Presupuesto2(_Id_Ot, Frm_St_Estado_03_Presupuesto2.Accion.Editar)
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.SoloLectura = True
        Fm.ShowDialog(Me)
        'If Fm0.Pro_Grabar Then
        '    Sb_Actualizar_Grilla()
        'End If
        Fm.Dispose()

        'Dim Fm As New Frm_St_Estado_03_Presupuesto(_Id_Ot, Frm_St_Estado_03_Presupuesto.Accion.Editar)
        'Fm.Pro_DsDocumento = _DsDocumento
        'Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        'Fm.Btn_Editar.Enabled = _Editar
        'Fm.ShowDialog(Me)
        'Dim _Editando_Documento As Boolean = Fm.Pro_Editando_Documento
        'Dim _Grabar As Boolean = Fm.Pro_Grabar
        'Fm.Dispose()

        'If _Editando_Documento Then
        '    _Abrir_Documento = True
        '    Me.Close()
        'End If

    End Sub

#End Region

#Region "ESTADO 4"

    Sub Sb_Estado_04_Cotizacion_Nuevo()

        Dim Fm As New Frm_St_Estado_04_Cotizaciones(Frm_St_Estado_04_Cotizaciones.Accion.Nuevo)
        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Pro_Id_Ot = _Id_Ot
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.ShowDialog(Me)
        If Fm.Pro_Fijar_Estado Then
            _Abrir_Documento = True
            Me.Close()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Estado_04_Cotizacion_Lectura()

        If _Row_Notas.Item("Chk_No_se_pudo_reparar") Then

            Dim _Motivo As String = Fx_AjustarTexto(_Row_Notas.Item("Motivo_no_reparo"), 50)
            MessageBoxEx.Show(Me, "Motivo: " & _Motivo, "NO SE PUDO REPARAR EL PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If

        Dim _Editar = True

        For Each _Fl As DataRow In _Tbl_Estado.Rows
            If _Fl.Item("CodEstado") = "R" Then
                _Editar = False
                Exit For
            End If
        Next

        Dim Fm As New Frm_St_Estado_04_Cotizaciones(Frm_St_Estado_04_Cotizaciones.Accion.Editar)
        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Pro_Id_Ot = _Id_Ot
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.Btn_Editar.Enabled = _Editar
        Fm.ShowDialog(Me)
        Dim _Editando_Documento As Boolean = Fm.Pro_Editando_Documento
        Fm.Dispose()

        If _Editando_Documento Then
            _Abrir_Documento = True
            Me.Close()
        End If

    End Sub

#End Region

#Region "ESTADO 5"

    Sub Sb_Estado_05_Reparacion_Nuevo()

        If _Global_Row_Configuracion_General.Item("ServTecnico_Simple") Then

            Dim Fm As New Frm_St_Estado_05_Reparacion(Frm_St_Estado_05_Reparacion.Accion.Nuevo)
            Fm.Pro_RowEntidad = _RowEntidad
            Fm.Pro_Imagenes_32x32 = Imagenes_32x32
            Fm.Pro_Id_Ot = _Id_Ot
            Fm.Pro_DsDocumento = _DsDocumento
            Fm.ShowDialog(Me)
            If Fm.Pro_Fijar_Estado Then
                _Abrir_Documento = True
                Me.Close()
            End If
            Fm.Dispose()

            Return

        End If

        Dim _Aceptar As Boolean
        Dim _PwTecnico As String

        Dim _CodTecnico_Asignado = _Row_Encabezado.Item("CodTecnico_Asignado")
        Dim _Tecnico_Asignado = _Row_Encabezado.Item("Tecnico_Asignado")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller Where CodFuncionario = '" & _CodTecnico_Asignado & "'"
        Dim _Row_Tecnico_Asignado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Msg As String

        If _Row_Tecnico_Asignado.Item("EsTecnico") Then _Msg = "TECNICO"
        If _Row_Tecnico_Asignado.Item("EsTaller") Then _Msg = "TALLER"

        _Aceptar = InputBox_Bk(Me, "INGRESE LA CLAVE DEL " & _Msg & " ASIGNADO" & vbCrLf &
                               _Msg & " ASIGNADO: " & _CodTecnico_Asignado & "-" & _Tecnico_Asignado, "INGRESAR A GESTION DEL TALLER",
                               _PwTecnico, False, _Tipo_Mayus_Minus.Normal, 5, True, _Tipo_Imagen.Key,, _Tipo_Caracter.Solo_Numeros_Enteros, False, "*")

        If Not _Aceptar Then
            Return
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller Where PwTecnico = '" & _PwTecnico & "'"
        Dim _Row_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Funcionario) Then
            MessageBoxEx.Show(Me, "Clave desconocida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Estado_05_Reparacion_Nuevo()
            Return
        End If

        If _Row_Funcionario.Item("CodFuncionario") <> _CodTecnico_Asignado Then

            If _Row_Tecnico_Asignado.Item("EsTecnico") Then _Msg = "técnico"
            If _Row_Tecnico_Asignado.Item("EsTaller") Then _Msg = "taller"

            MessageBoxEx.Show(Me, "El " & _Msg & ": " & _Row_Funcionario.Item("CodFuncionario") & "-" & _Row_Funcionario.Item("NomFuncionario").ToString.Trim &
                              " no esta asignado para realizar este presupuesto" & vbCrLf & vbCrLf &
                              "Debe ingresar la clave de " & _Tecnico_Asignado, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Estado_05_Reparacion_Nuevo()
            Return
        End If

        Dim Fm0 As New Frm_St_Estado_05_Reparacion2(Frm_St_Estado_05_Reparacion.Accion.Nuevo)
        Fm0.RowEntidad = _RowEntidad
        Fm0.Id_Ot = _Id_Ot
        Fm0.DsDocumento = _DsDocumento
        Fm0.CodTecnico_Repara = _CodTecnico_Asignado
        Fm0.ShowDialog(Me)
        If Fm0.Fijar_Estado Then
            _Abrir_Documento = True
            Me.Close()
        End If
        Fm0.Dispose()

    End Sub

    Sub Sb_Estado_05_Reparacion_Lectura()

        If _Row_Notas.Item("Chk_No_se_pudo_reparar") Then

            Dim _Motivo As String = Fx_AjustarTexto(_Row_Notas.Item("Motivo_no_reparo"), 50)
            MessageBoxEx.Show(Me, "Motivo: " & _Motivo, "NO SE PUDO REPARAR EL PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If

        Dim _Editar = True

        For Each _Fl As DataRow In _Tbl_Estado.Rows
            If _Fl.Item("CodEstado") = "V" Then
                _Editar = False
                Exit For
            End If
        Next

        Dim Fm As New Frm_St_Estado_05_Reparacion2(Frm_St_Estado_05_Reparacion.Accion.Editar)
        Fm.RowEntidad = _RowEntidad
        Fm.Id_Ot = _Id_Ot
        Fm.DsDocumento = _DsDocumento
        Fm.CodTecnico_Repara = _Row_Encabezado.Item("CodTecnico_Repara")
        Fm.SoloLectura = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

        'Dim Fm As New Frm_St_Estado_05_Reparacion(Frm_St_Estado_05_Reparacion.Accion.Editar)
        'Fm.Pro_RowEntidad = _RowEntidad
        'Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        'Fm.Pro_Id_Ot = _Id_Ot
        'Fm.Pro_DsDocumento = _DsDocumento
        'Fm.Btn_Editar.Enabled = _Editar
        'Fm.ShowDialog(Me)
        'Dim _Editando_Documento As Boolean = Fm.Pro_Editando_Documento
        'Fm.Dispose()

        'If _Editando_Documento Then
        '    _Abrir_Documento = True
        '    Me.Close()
        'End If

    End Sub

#End Region

#Region "ESTADO 6"

    Sub Sb_Estado_06_Aviso_Cliente_Nuevo()

        Dim Fm As New Frm_St_Estado_06_Aviso_Cliente(Frm_St_Estado_06_Aviso_Cliente.Accion.Nuevo)
        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.Pro_Id_Ot = _Id_Ot
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.ShowDialog(Me)
        If Fm.Pro_Fijar_Estado Then
            _Abrir_Documento = True
            Me.Close()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Estado_06_Aviso_Cliente_Lectura()

        Dim Fm As New Frm_St_Estado_06_Aviso_Cliente(Frm_St_Estado_06_Aviso_Cliente.Accion.Editar)
        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.Pro_Id_Ot = _Id_Ot
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

#End Region

#Region "ESTADO 7"

    Sub Sb_Estado_07_Entrega_Facturacion_Nuevo()

        Dim Fm As New Frm_St_Estado_07_Entrega_Facturacion(Frm_St_Estado_07_Entrega_Facturacion.Accion.Nuevo)
        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.Pro_Id_Ot = _Id_Ot
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.ShowDialog(Me)
        If Fm.Pro_Fijar_Estado Then
            _Abrir_Documento = True
            Me.Close()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Estado_07_Entrega_Facturacion_Lectura()

        Dim Fm As New Frm_St_Estado_07_Entrega_Facturacion(Frm_St_Estado_07_Entrega_Facturacion.Accion.Editar)
        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        Fm.Pro_Id_Ot = _Id_Ot
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.ShowDialog(Me)
        Dim _Editando_Documento As Boolean = Fm.Pro_Editando_Documento
        Fm.Dispose()

        If _Editando_Documento Then
            _Abrir_Documento = True
            Me.Close()
        End If

    End Sub

#End Region

    Sub Sb_Info_Estado_a_realizar()
        MessageBoxEx.Show(Me, "Debe: " & _Info_Estado_A_Realizar, "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

#End Region


    Private Sub Estado_MouseEnter(sender As System.Object, e As System.EventArgs)
        sender.VALUE = 0
    End Sub


    Private Sub Estado_MouseLeave(sender As System.Object, e As System.EventArgs)
        sender.VALUE = 100
    End Sub

    Private Sub Chk_Serv_Garantia_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Btn_Documento_Garantia.Enabled = Chk_Serv_Garantia.Checked
    End Sub

    Private Sub Btn_Documento_Garantia_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Documento_Garantia.Click

        Btn_Garantia_Ver_Documento.Text = "Ver Documento"

        If Not (_Row_Doc_Garantia Is Nothing) Then
            With _Row_Doc_Garantia
                Btn_Garantia_Ver_Documento.Text = "Ver Documento " & .Item("TIDO") & "-" & .Item("NUDO")
            End With
            Btn_Garantia_Agregar_Documento.Visible = False
            Btn_Garantia_Ver_Documento.Visible = True
            Btn_Garantia_Cambiar_Documento.Visible = True
        Else
            Btn_Garantia_Agregar_Documento.Visible = True
            Btn_Garantia_Ver_Documento.Visible = False
            Btn_Garantia_Cambiar_Documento.Visible = False
        End If

        ShowContextMenu(Menu_Contextual_Garantia)

    End Sub



    Private Sub Btn_Garantia_Ver_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Garantia_Ver_Documento.Click

        If _Garantia_Documento_Externo Then

            MessageBoxEx.Show(Me, "El documento es externo al sistema, no se puede visualizar: " &
                              _Row_Doc_Garantia.Item("TIDO") & " - " & _Row_Doc_Garantia.Item("NUDO"),
                              "Documento externo", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Dim _Idmaeedo As Integer = _Row_Doc_Garantia.Item("IDMAEEDO")
            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Garantia_Cambiar_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Garantia_Cambiar_Documento.Click
        ShowContextMenu(Menu_Contextual_Documentos_Grarantia)
        Return
        'Dim _RowDocumento = Fx_Garantia_Traer_Documento()

        'If Not (_RowDocumento Is Nothing) Then
        '_Row_Doc_Garantia = _RowDocumento

        'Beep()
        'ToastNotification.Show(Me, "DOCUMENTO CAMBIADO CORRECTAMENTE", _
        '                       Btn_Garantia_Cambiar_Documento.Image, _
        '                       2 * 1000, eToastGlowColor.Green, _
        '                       eToastPosition.MiddleCenter)

        'End If

    End Sub

    Function Fx_Garantia_Traer_Documento() As DataRow

        Dim Fm As New Frm_BusquedaDocumento_Filtro(False)
        Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "FCV", "Where TIDO IN ('FCV','BLV')")
        Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

        If Not (_Row_Doc_Garantia Is Nothing) Then
            Fm.Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO <> " & _Row_Doc_Garantia.Item("IDMAEEDO")
        End If

        Fm.Pro_Row_Entidad = _RowEntidad
        Fm.ShowDialog(Me)
        Fx_Garantia_Traer_Documento = Fm.Pro_Row_Documento_Seleccionado
        Fm.Dispose()

    End Function


    Private Sub Btn_Editar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Editar.Click

        If Fx_Tiene_Permiso(Me, "Stec0003") Then

            Sb_Editar_Activar_Desactivar_Objetos(True)

            Progeso_Gestion.Enabled = False

            Beep()
            ToastNotification.Show(Me, "AHORA ES POSIBLE ACTUALIZAR EL DOCUMENTO",
                                   Btn_Editar.Image,
                                   2 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)

            Btn_Cancelar.Visible = True
            'Btn_Editar.Enabled = False

            Me.Refresh()

        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        _Abrir_Documento = True
        Me.Close()
    End Sub


#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(value As DataSet)
            _DsDocumento = value
        End Set
    End Property

    Public Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Public Property Id_Ot() As Integer
        Get
            Return _Id_Ot
        End Get
        Set(value As Integer)
            _Id_Ot = value
        End Set
    End Property

    Public Property Pro_Abrir_Documeneto() As Boolean
        Get
            Return _Abrir_Documento
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Pro_Nulo() As Boolean
        Get
            Return _Nulo
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Pro_Accion() As Accion
        Get
            Return _Accion
        End Get
        Set(value As Accion)
            _Accion = value
        End Set
    End Property

    Public Property Pro_IdCorreo() As Integer
        Get

        End Get
        Set(value As Integer)
            _Id_Correo = value
        End Set
    End Property

    Public Property Id_Ot_Padre As Integer
        Get
            Return _Id_Ot_Padre
        End Get
        Set(value As Integer)
            _Id_Ot_Padre = value
        End Set
    End Property

#End Region


    Private Sub Btn_Direccion_Servicio_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Direccion_Servicio.Click

        Dim Fm As New Frm_St_Documento_Dir_Serv_Domicilio
        Fm.Pro_DsDocumento = _DsDocumento

        Fm.Pro_Editar = Chk_Serv_Domicilio.Enabled

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Chk_Serv_Domicilio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Serv_Domicilio.CheckedChanged
        Btn_Direccion_Servicio.Enabled = Chk_Serv_Domicilio.Checked
    End Sub

    Private Sub Frm_St_Documento_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _Accion = Accion.Nuevo Then
            If Not _Abrir_Documento Then

                'Dim _Botones() As Command = {Btn_Grabar_Y_Cerrar}

                'Dim _Opciones() As Command = {Chk_GGG, Chk_GAF}

                'Dim _Info As New TaskDialogInfo("Cerrar formulario", _
                'eTaskDialogIcon.Help, _
                '"¿Desea cerrar sin guardar los datos?", _
                '"Si quiere gurdar el documento debe presionar el botón", _
                'eTaskDialogButton.Cancel _
                ', eTaskDialogBackgroundColor.Red, Nothing, _Botones, Nothing, Nothing, Nothing)

                'Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                'If _Resultado = eTaskDialogResult.Yes Then

                'Else
                If MessageBoxEx.Show(Me, "No ha guardado los datos, los datos se perderan si no lo hace." & vbCrLf &
                                    "¿Desea salir de todas formas?", "Cerrar documento",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub Btn_Grabar_Y_Cerrar_Executed(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar_Y_Cerrar.Executed
        TaskDialog.Close(eTaskDialogResult.Yes)
        Sb_New_OT_Grabar_Nueva_OT()
    End Sub

    Private Sub Btn_Anular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anular.Click


        Dim _TblCotizaciones = _DsDocumento.Tables(6)

        For Each _Fila As DataRow In _TblCotizaciones.Rows
            Dim _Estado = _Fila.Item("Estado")

            If _Estado = "E" Or _Estado = "A" Then
                MessageBoxEx.Show(Me, "No puede anular la orden de trabajo, ya que hay una cotización abierta",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        Next

        If Fx_Tiene_Permiso(Me, "Stec0004") Then
            If MessageBoxEx.Show(Me, "¿Esta seguro de anular el documento?", "Anular documento",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim _Id_Ot = _Row_Encabezado.Item("Id_Ot")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set CodEstado = 'N'
                                Where  Id_Ot = " & _Id_Ot
                Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    _Nulo = True
                    Me.Close()
                End If

            End If
        End If

    End Sub

    Private Sub Btn_Cerrar_OT_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cerrar_OT.Click

        If Fx_Tiene_Permiso(Me, "Stec0011") Then

            If MessageBoxEx.Show(Me, "Si cierra el documento no podrá editar ni hacer más gestión sobre él." & vbCrLf &
                                 "¿Está seguro de cerrar esta Orden de Trabajo?",
                                 "Cerrar Orden de Trabajo",
                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set" & Space(1) &
                               "CodEstado = 'CE'," & vbCrLf &
                               "Fecha_Cierre = Getdate()" & vbCrLf &
                               "Where Id_Ot = " & _Id_Ot & vbCrLf &
                                "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                                "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                                "(" & _Id_Ot & ",'CE',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

                If _Sql_Query.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, "LA ORDEN DE TRABAJO YA NO PODRA SER EDITADA", "ORDEN DE TRABAJO CERRADA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Abrir_Documento = True
                    Me.Close()
                End If
            End If
        End If

    End Sub

    Private Sub Btn_Imprimir_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir.Click
        ShowContextMenu(Menu_Contextual_Impresion)
    End Sub

    Private Sub Btn_Imprimir_Acta_ingreso_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Acta_ingreso.Click

        If Fx_Tiene_Permiso(Me, "Stec0012") Then

            'If Btn_Ver_GRP_PRE.Enabled Then
            '    Sb_Imprimir_Documento_GRP()
            'Else
            Sb_Imprimir_Reporte_Acta_Ingreso()
            'End If

        End If

    End Sub

    Private Sub Btn_Imprimir_Evaluacion_Tecnico_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Evaluacion_Tecnico.Click
        If Fx_Tiene_Permiso(Me, "Stec0013") Then
            Sb_Imprimir_Reporte_Evaluacion_Tecnico()
        End If
    End Sub

    Private Sub Btn_Imprimir_Reporte_Final_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Reporte_Final.Click
        If Fx_Tiene_Permiso(Me, "Stec0014") Then
            Sb_Imprimir_Reporte_Reparacion_Final()
        End If
    End Sub

#Region "IMPRIMIR"

    Sub Sb_Imprimir_Documento_GRP()

        Dim _Tido = "GRP"
        Dim _Idmaeedo = _Row_Encabezado.Item("Idmaeedo_GRP_PRE")

        Dim _Vista_Previa As Boolean
        Dim _NombreFormato As String

        Dim Fm As New Frm_Seleccionar_Formato(_Tido)

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)

            If Fm.Formato_Seleccionado Then

                _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")

                If _NombreFormato = "" Then
                    _NombreFormato = String.Empty
                End If

                Dim _Instance As New Printing.PrinterSettings
                Dim _ImpresosaPredt As String = _Instance.PrinterName
                Dim _Seleccionar_Impresora = True

                If Not String.IsNullOrEmpty(_ImpresosaPredt) Then

                    If MessageBoxEx.Show(Me, "¿Desea imprimir el documento en la impresora predeterminada: " & _ImpresosaPredt & "?", "Imprimir",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button1, Me.TopMost) = DialogResult.Yes Then

                        _Seleccionar_Impresora = False

                    End If

                End If


                _Vista_Previa = False

                Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _Idmaeedo,
                                                                        True, _Seleccionar_Impresora, _ImpresosaPredt,
                                                                        _Vista_Previa, 0, False, "")

                If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                    MessageBox.Show(Me, _Imprime, "Problemas al Imprimir",
                                   MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            End If

        Else

            MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Fm.Dispose()

    End Sub


    Sub Sb_Imprimir_Reporte_Acta_Ingreso()

        Dim _Tbl_Conf_Info_Reportes As DataTable

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_St_Conf_Info_Reportes"
        _Tbl_Conf_Info_Reportes = _Sql_Query.Fx_Get_DataTable(Consulta_sql)

        Dim _Nro_Ot As String = _Row_Encabezado.Item("Nro_Ot")
        Dim _Razon_Social As String = _Row_Encabezado.Item("Cliente")
        Dim _Fecha_Emision = _Row_Encabezado.Item("Fecha_Ingreso")
        Dim _Direccion As String = _Row_Encabezado.Item("Direccion")
        Dim _Telefono As String = _RowEntidad.Item("FOEN")
        Dim _Email As String = _RowEntidad.Item("EMAIL")

        Dim _Nombre_Contacto As String = Trim(Txt_Nombre_Contacto.Text)
        If Not String.IsNullOrEmpty(Txt_Email_Contacto.Text) Then
            _Email = Txt_Email_Contacto.Text
        End If
        Dim _Telefono_Contacto As String = Trim(Txt_Telefono_Contacto.Text)

        Dim _Descripcion_Equipo As String = Txt_Maquina.Text
        Dim _Marca As String = Txt_Marca.Text
        Dim _Modelo As String = Txt_Modelo.Text
        Dim _Nro_Serie As String = Txt_Nro_Serie.Text
        Dim _Rut_Cliente As String = _Row_Encabezado.Item("Rut")

        If Btn_Ver_GRP_PRE.Enabled Then
            _Modelo = _RowProducto.Item("KOPR")
            _Descripcion_Equipo = _RowProducto.Item("NOKOPR")
            _Marca = _RowProducto.Item("Marca")
        End If

        Dim _Accesorios As String = String.Empty
        Dim _Check_In As String = String.Empty

        Dim _Defecto_segun_cliente As String = _Row_Notas.Item("Defecto_segun_cliente")
        Dim _Nota_Etapa_01 As String = _Row_Notas.Item("Nota_Etapa_01")
        Dim _Condiciones As String = String.Empty

        If CBool(_Tbl_Conf_Info_Reportes.Rows.Count) Then
            _Condiciones = _Tbl_Conf_Info_Reportes.Rows(0).Item("Condiciones")
        End If



        '"SR CLIENTE:" & vbCrLf & _
        '"- LA FECHA DE ENTREGA ES CONDICIONAL. PUDIENDO VARIAR SEGÚN EL DESARROLLO DEL PROGRAMA DE TAREAS Y DISPONIBILIDAD DE REPUESTOS." & vbCrLf & _
        '"- Si entregó su equipo con accesorios, verifique que los mismos (equipos y accesorios) estén" & vbCrLf & _
        '"correctamente indicados en esta acta, pues en caso contrario no tendrá derecho a reclamo alguno." & vbCrLf & _
        '"- Para cualquier consulta es imprescindible citar Nº de reparación indicado en esta boleta." & vbCrLf & _
        '"- Conserve este documento, pues únicamente contra su entrega podrá retirar su equipo." & vbCrLf & _
        '"- De no ser retirada su reparación en término, será actualizado el costo de la misma, al momento de la entrega." & vbCrLf & _
        '"- Toda reparación debe ser retirada dentro de los 10 días de comunicado su arreglo, no teniendo luego derecho a reclamo alguno." & vbCrLf & _
        '"- LAS REPARACIONES SERÁN ABONADAS EN EFECTIVO ÚNICAMENTE" & vbCrLf & _
        '"(ESTE TEXTO ES A MODO DE EJEMPLO)" & vbCrLf & _
        '"(COLOQUE AQUI LA INFORMACIÓN QUE QUIERA TRANSMITIRLE AL CLIENTE)"


        For Each _ChekIn As DataRow In _Tbl_ChekIn.Rows
            _Check_In += _ChekIn.Item("Check_In") & ", "
        Next

        For Each _ChekIn As DataRow In _Tbl_Accesorios.Rows
            _Accesorios += Trim(_ChekIn.Item("Articulo")) & " (" & _ChekIn.Item("Cantidad") & "), "
        Next


        Try


            'iniciamos el form y el reporte
            Dim form As New Frm_VerReportes
            Dim report As New Acta_Recepcion

            report.SetParameterValue("Nro_Ot", _Nro_Ot)

            'le indicamos el datasource al report, que sera el recordset
            'que hemos llenado
            'report.SetDataSource(_Tbl_Informe)

            'le indicamos el reportsource al crviewer del segundo form
            'que sera el report que creamos

            Dim _Garantia As String

            If Chk_Serv_Garantia.Checked Then
                _Garantia = "SI, Doc. asociado " & _Row_Doc_Garantia.Item("Tido") & "-" & _Row_Doc_Garantia.Item("Nudo")
            Else
                _Garantia = "NO Corresponde"
            End If

            report.SetParameterValue("Es_Garantia", _Garantia)

            report.SetParameterValue("Razon_Social", _Razon_Social)
            report.SetParameterValue("Fecha_Emision", _Fecha_Emision)
            report.SetParameterValue("Direccion", _Direccion)
            report.SetParameterValue("Telefono", _Telefono)
            report.SetParameterValue("Email", _Email)

            report.SetParameterValue("Nombre_Contacto", _Nombre_Contacto)
            report.SetParameterValue("Telefono_Contacto", _Telefono_Contacto)


            report.SetParameterValue("Descripcion_Equipo", _Descripcion_Equipo)
            report.SetParameterValue("Marca", _Marca)
            report.SetParameterValue("Modelo", _Modelo)
            report.SetParameterValue("Nro_Serie", _Nro_Serie)
            report.SetParameterValue("Rut_Cliente", _Rut_Cliente)

            report.SetParameterValue("Accesorios", _Accesorios)
            report.SetParameterValue("Checkin", _Check_In)
            report.SetParameterValue("Defecto_segun_cliente", _Defecto_segun_cliente)
            report.SetParameterValue("Nota_Etapa_01", _Nota_Etapa_01)
            report.SetParameterValue("Condiciones", _Condiciones)


            form.CrystalReportViewer1.ReportSource = report
            form.ShowInTaskbar = True
            form.Show()

            form = Nothing


            'MessageBoxEx.Show(Me, "No hay datos en la tabla de aprobación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Sub Sb_Imprimir_Reporte_Evaluacion_Tecnico()

        Dim _Nro_Ot As String = _Row_Encabezado.Item("Nro_Ot")
        Dim _Razon_Social As String = _Row_Encabezado.Item("Cliente")
        Dim _Fecha_Emision = _Row_Encabezado.Item("Fecha_Ingreso")
        Dim _Direccion As String = _Row_Encabezado.Item("Direccion")
        Dim _Telefono As String = _RowEntidad.Item("FOEN")
        Dim _Email As String = _RowEntidad.Item("EMAIL")
        Dim _Descripcion_Equipo As String = Txt_Maquina.Text
        Dim _Marca As String = Txt_Marca.Text
        Dim _Modelo As String = Txt_Modelo.Text
        Dim _Nro_Serie As String = Txt_Nro_Serie.Text
        Dim _Rut_Cliente As String = _Row_Encabezado.Item("Rut")

        If Btn_Ver_GRP_PRE.Enabled Then
            _Modelo = _RowProducto.Item("KOPR")
            _Descripcion_Equipo = _RowProducto.Item("NOKOPR")
            _Marca = _RowProducto.Item("Marca")
        End If

        Dim _Accesorios As String = String.Empty
        Dim _Check_In As String = String.Empty

        Dim _Defecto_segun_cliente As String = _Row_Notas.Item("Defecto_segun_cliente")

        Dim _Defecto_encontrado As String = Replace(_Row_Notas.Item("Defecto_encontrado"), Chr(13), Space(1))
        Dim _Reparacion_a_realizar As String = Replace(_Row_Notas.Item("Reparacion_a_realizar"), Chr(13), Space(1))


        Dim _Nota_Etapa_01 As String = _Row_Notas.Item("Nota_Etapa_01")
        Dim _Nota_Etapa_03 As String = _Row_Notas.Item("Nota_Etapa_03")

        Dim _Informe As String = "DEFECTO ENCONTRADO: " & LCase(_Defecto_encontrado) & vbCrLf & vbCrLf &
                                 "REPARACION A REALIZAR: " & LCase(_Reparacion_a_realizar) & vbCrLf & vbCrLf &
                                 "NOTA: " & LCase(_Nota_Etapa_03)

        '_Informe = "<b>Defecto: </b>" & _Defecto_encontrado & vbCrLf & vbCrLf & _
        '           "<b>Reparación a Realizar: </b>" & _Reparacion_a_realizar & vbCrLf & vbCrLf & _
        '           "<b>Nota:</b>" & _Nota_Etapa_03

        For Each _ChekIn As DataRow In _Tbl_ChekIn.Rows
            _Check_In += _ChekIn.Item("Check_In") & ", "
        Next

        For Each _ChekIn As DataRow In _Tbl_Accesorios.Rows
            _Accesorios += Trim(_ChekIn.Item("Articulo")) & " (" & _ChekIn.Item("Cantidad") & "), "
        Next


        Try



            'iniciamos el form y el reporte
            Dim form As New Frm_VerReportes
            Dim report As New Acta_Reparacion

            report.SetParameterValue("Nro_Ot", _Nro_Ot)

            'le indicamos el datasource al report, que sera el recordset
            'que hemos llenado
            'report.SetDataSource(_Tbl_Informe)

            'le indicamos el reportsource al crviewer del segundo form
            'que sera el report que creamos
            Dim _Garantia As String

            If Chk_Serv_Garantia.Checked Then
                _Garantia = "SI, Doc. asociado " & _Row_Doc_Garantia.Item("Tido") & "-" & _Row_Doc_Garantia.Item("Nudo")
            Else
                _Garantia = "NO Corresponde"
            End If

            report.SetParameterValue("Es_Garantia", _Garantia)

            report.SetParameterValue("Razon_Social", _Razon_Social)
            report.SetParameterValue("Fecha_Emision", _Fecha_Emision)
            report.SetParameterValue("Direccion", _Direccion)
            report.SetParameterValue("Telefono", _Telefono)
            report.SetParameterValue("Email", _Email)

            report.SetParameterValue("Descripcion_Equipo", _Descripcion_Equipo)
            report.SetParameterValue("Marca", _Marca)
            report.SetParameterValue("Modelo", _Modelo)
            report.SetParameterValue("Nro_Serie", _Nro_Serie)
            report.SetParameterValue("Rut_Cliente", _Rut_Cliente)

            report.SetParameterValue("Accesorios", _Accesorios)
            report.SetParameterValue("Checkin", _Check_In)
            report.SetParameterValue("Defecto_segun_cliente", _Defecto_segun_cliente)
            report.SetParameterValue("Nota_Etapa_01", _Nota_Etapa_01)
            report.SetParameterValue("Informe", _Informe)

            form.CrystalReportViewer1.ReportSource = report
            form.ShowInTaskbar = True
            form.Show()

            form = Nothing

            'MessageBoxEx.Show(Me, "No hay datos en la tabla de aprobación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Sub Sb_Imprimir_Reporte_Reparacion_Final()

        Dim _Tbl_Conf_Info_Reportes As DataTable

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_St_Conf_Info_Reportes"
        _Tbl_Conf_Info_Reportes = _Sql_Query.Fx_Get_DataTable(Consulta_sql)

        Dim _Nro_Ot As String = _Row_Encabezado.Item("Nro_Ot")
        Dim _Razon_Social As String = _Row_Encabezado.Item("Cliente")
        Dim _Fecha_Emision = _Row_Encabezado.Item("Fecha_Ingreso")
        Dim _Direccion As String = _Row_Encabezado.Item("Direccion")
        Dim _Telefono As String = _RowEntidad.Item("FOEN")
        Dim _Email As String = _RowEntidad.Item("EMAIL")

        Dim _Nombre_Contacto As String = Trim(Txt_Nombre_Contacto.Text)
        If Not String.IsNullOrEmpty(Txt_Email_Contacto.Text) Then
            _Email = Txt_Email_Contacto.Text
        End If
        Dim _Telefono_Contacto As String = Trim(Txt_Telefono_Contacto.Text)

        Dim _Descripcion_Equipo As String = Txt_Maquina.Text
        Dim _Marca As String = Txt_Marca.Text
        Dim _Modelo As String = Txt_Modelo.Text
        Dim _Nro_Serie As String = Txt_Nro_Serie.Text
        Dim _Rut_Cliente As String = _Row_Encabezado.Item("Rut")

        If Btn_Ver_GRP_PRE.Enabled Then
            _Modelo = _RowProducto.Item("KOPR")
            _Descripcion_Equipo = _RowProducto.Item("NOKOPR")
            _Marca = _RowProducto.Item("Marca")
        End If

        Dim _Accesorios As String = String.Empty
        Dim _Check_In As String = String.Empty

        Dim _Garantia As String = String.Empty

        Dim _Defecto_segun_cliente As String = _Row_Notas.Item("Defecto_segun_cliente")

        'Dim _Defecto_encontrado As String = Replace(_Row_Notas.Item("Defecto_encontrado"), Chr(13), Space(1))
        Dim _Reparacion_a_realizar As String = Replace(_Row_Notas.Item("Reparacion_Realizada"), Chr(13), Space(1))

        If String.IsNullOrEmpty(_Reparacion_a_realizar) Then
            _Reparacion_a_realizar = Replace(_Row_Notas.Item("Motivo_no_reparo"), Chr(13), Space(1))
        End If

        If CBool(_Tbl_Conf_Info_Reportes.Rows.Count) Then
            _Garantia = _Tbl_Conf_Info_Reportes.Rows(0).Item("Garantia")
        End If


        Dim _Nota_Etapa_01 As String = _Row_Notas.Item("Nota_Etapa_01")
        Dim _Nota_Etapa_05 As String = _Row_Notas.Item("Nota_Etapa_05")

        Dim _Informe As String = "REPARACION: " & LCase(_Reparacion_a_realizar) & vbCrLf & vbCrLf &
                                 "NOTA: " & LCase(_Nota_Etapa_05)

        '_Informe = "<b>Defecto: </b>" & _Defecto_encontrado & vbCrLf & vbCrLf & _
        '           "<b>Reparación a Realizar: </b>" & _Reparacion_a_realizar & vbCrLf & vbCrLf & _
        '           "<b>Nota:</b>" & _Nota_Etapa_03


        Try



            'iniciamos el form y el reporte
            Dim form As New Frm_VerReportes
            Dim report As New Acta_Reparacion_Final

            report.SetParameterValue("Nro_Ot", _Nro_Ot)

            'le indicamos el datasource al report, que sera el recordset
            'que hemos llenado
            'report.SetDataSource(_Tbl_Informe)

            'le indicamos el reportsource al crviewer del segundo form
            'que sera el report que creamos

            Dim _Es_Garantia As String

            If Chk_Serv_Garantia.Checked Then
                _Es_Garantia = "SI, Doc. asociado " & _Row_Doc_Garantia.Item("Tido") & "-" & _Row_Doc_Garantia.Item("Nudo")
            Else
                _Es_Garantia = "NO Corresponde"
            End If

            report.SetParameterValue("Es_Garantia", _Es_Garantia)
            report.SetParameterValue("Garantia", _Garantia)

            report.SetParameterValue("Razon_Social", _Razon_Social)
            report.SetParameterValue("Fecha_Emision", _Fecha_Emision)
            report.SetParameterValue("Direccion", _Direccion)
            report.SetParameterValue("Telefono", _Telefono)
            report.SetParameterValue("Email", _Email)

            report.SetParameterValue("Nombre_Contacto", _Nombre_Contacto)
            report.SetParameterValue("Telefono_Contacto", _Telefono_Contacto)

            report.SetParameterValue("Descripcion_Equipo", _Descripcion_Equipo)
            report.SetParameterValue("Marca", _Marca)
            report.SetParameterValue("Modelo", _Modelo)
            report.SetParameterValue("Nro_Serie", _Nro_Serie)
            report.SetParameterValue("Rut_Cliente", _Rut_Cliente)

            report.SetParameterValue("Accesorios", _Accesorios)
            report.SetParameterValue("Checkin", _Check_In)
            report.SetParameterValue("Defecto_segun_cliente", _Defecto_segun_cliente)
            report.SetParameterValue("Nota_Etapa_01", _Nota_Etapa_01)
            report.SetParameterValue("Informe", _Informe)


            form.CrystalReportViewer1.ReportSource = report
            form.ShowInTaskbar = True
            form.Show()

            form = Nothing


            'MessageBoxEx.Show(Me, "No hay datos en la tabla de aprobación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

#End Region


    Private Sub Btn_Doc_Externo_Boleta_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Doc_Externo_Boleta.Click
        Sb_Incorporar_Numero_Documento_Externo("Boleta")
    End Sub

    Private Sub Btn_Doc_Externo_Factura_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Doc_Externo_Factura.Click
        Sb_Incorporar_Numero_Documento_Externo("Factura")
    End Sub

    Sub Sb_Incorporar_Numero_Documento_Externo(_Tipo_Documento As String)

        Dim _Tido As String = String.Empty

        Select Case _Tipo_Documento
            Case "Boleta"
                _Tido = "BLV"
            Case "Factura"
                _Tido = "FCV"
        End Select

        Dim _Aceptado As Boolean
        Dim _Nro_Documento As String = _Nro_Documento_Externo

        _Aceptado = InputBox_Bk(Me, "Escriba el número de la " & _Tipo_Documento,
                         _Tipo_Documento & " del cliente",
                         _Nro_Documento,
                         False, _Tipo_Mayus_Minus.Mayusculas, 15,
                         True, _Tipo_Imagen.Texto, False, _Tipo_Caracter.Solo_Numeros_Enteros, False)

        If _Aceptado Then
            _Garantia_Documento_Externo = True

            Consulta_sql = "Select 0 As IDMAEEDO,'" & _Tido & "' As TIDO,'" & _Nro_Documento & "' As NUDO,GetDate() as FEEMDO"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                _Row_Doc_Garantia = _Tbl.Rows(0)
            End If
        End If

    End Sub

    Private Sub Btn_Documento_Sistema_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Documento_Sistema.Click

        Dim _RowDocumento = Fx_Garantia_Traer_Documento()

        If Not (_RowDocumento Is Nothing) Then

            Dim _Idmaeedo = _RowDocumento.Item("IDMAEEDO")

            Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEDDO", "IDMAEEDO = " & _Idmaeedo & " And KOPRCT = '" & Txt_Producto.Tag & "'")

            If CBool(_Reg) Then
                _Row_Doc_Garantia = _RowDocumento

                Beep()
                ToastNotification.Show(Me, "DOCUMENTO ADJUNTADO CORRECTAMENTE",
                                       Btn_Garantia_Agregar_Documento.Image,
                                       2 * 1000, eToastGlowColor.Green,
                                       eToastPosition.MiddleCenter)
                _Garantia_Documento_Externo = False
            Else
                MessageBoxEx.Show(Me, "El producto " & Txt_Producto.Text & " no se encuentra en el documento de referencia para la garantía",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub Btn_Garantia_Agregar_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Garantia_Agregar_Documento.Click
        ShowContextMenu(Menu_Contextual_Documentos_Grarantia)
    End Sub

    Private Sub Btn_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Producto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        With Fm
            .Pro_Actualizar_Precios = False
            .Pro_Mostrar_Info = False
            .BtnBuscarAlternativos.Visible = True
            .Pro_Mostrar_Imagenes = True
            .BtnCrearProductos.Visible = True
            .Pro_Mostrar_Editar = True
            .Pro_Mostrar_Eliminar = True
            .BtnExportaExcel.Visible = True
            .Pro_Tipo_Lista = "C"
            .Pro_Maestro_Productos = False
            .Pro_Sucursal_Busqueda = ModSucursal
            .Pro_Bodega_Busqueda = ModBodega
            .Pro_Lista_Busqueda = ModListaPrecioVenta
            .Pro_Mostrar_Info = True
            .ShowDialog(Me)
            _RowProducto = .Pro_RowProducto
            Dim _Seleccionado = .Pro_Seleccionado
            .Dispose()

            If _Seleccionado Then

                Txt_Producto.Tag = _RowProducto.Item("KOPR").ToString.Trim

                Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_DatosDelProducto
                Consulta_sql = Replace(Consulta_sql, "#Codigo#", Txt_Producto.Tag)
                _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Descripcion As String = _RowProducto.Item("NOKOPR").ToString.Trim

                Dim _Aceptar As Boolean = InputBox_Bk(Me, "Descripción del producto", "Producto a reparar",
                                                      _Descripcion, False, _Tipo_Mayus_Minus.Mayusculas, 50, False, _Tipo_Imagen.Texto)

                If _Aceptar Then
                    _RowProducto.Item("NOKOPR") = _Descripcion.ToString.Trim
                End If

                Lbl_Marca.Text = _RowProducto.Item("Marca")
                Lbl_Rubro.Text = _RowProducto.Item("Rubro")
                Lbl_Super_Familia.Text = _RowProducto.Item("SuperFamilia")
                Lbl_Familia.Text = _RowProducto.Item("Familia")
                Lbl_Sub_Familia.Text = _RowProducto.Item("SubFamilia")

                Lbl_Clas_Libre.Text = _Sql.Fx_Trae_Dato("TABCARAC", "NOKOCARAC",
                                              "KOTABLA = 'CLALIBPR' and KOCARAC = '" & _RowProducto.Item("CLALIBPR") & "'")


                Txt_Producto.Text = Txt_Producto.Tag & " - " & _RowProducto.Item("NOKOPR")

            End If

        End With

    End Sub

    Private Sub Txt_Producto_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Producto.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Producto_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click

        Dim _Nro_GRP As String
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese Guía/Factura del cliente", "Recepción de producto", _Nro_GRP,
                                              False, _Tipo_Mayus_Minus.Mayusculas, 10, True)

        If _Aceptar Then
            Fx_Crear_GRP_PRE(Grilla.Rows(0).Cells("Nro_Ot").Value, _Nro_GRP)
        End If

    End Sub

    Private Sub Btn_Ver_GRP_PRE_Click(sender As Object, e As EventArgs) Handles Btn_Ver_GRP_PRE.Click

        Dim _Idmaeedo = _Row_Encabezado.Item("Idmaeedo_GRP_PRE")

        Btn_GRP_Ver_Documento.Enabled = Convert.ToBoolean(_Idmaeedo)
        Btn_GRP_Crear_Guia.Enabled = Not Convert.ToBoolean(_Idmaeedo)
        Btn_GRP_Quitar.Enabled = Convert.ToBoolean(_Idmaeedo)

        ShowContextMenu(Menu_Contextual_GRP)

    End Sub

    Private Sub Btn_GRP_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_GRP_Ver_Documento.Click

        Dim _Idmaeedo = _Row_Encabezado.Item("Idmaeedo_GRP_PRE")

        If CBool(_Idmaeedo) Then
            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        Else
            Beep()
        End If

    End Sub

    Private Sub Btn_GRP_Asociar_Click(sender As Object, e As EventArgs) Handles Btn_GRP_Asociar.Click

        Dim _IdMaeedo As Integer

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)

        With _Fm

            .Pro_Sql_Filtro_Documentos_Extra = "And TIDO IN ('GRP')"
            .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
            .Rdb_Tipo_Documento_Uno.Checked = True
            .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "GRP",
                                  "WHERE TIDO IN ('GRP')")
            .Rdb_Estado_Vigente.Checked = True

            If _Editar Then
                .Pro_Mostrar_Solo_Datos_Usuario_Activo = _Editar
            Else
                .Rdb_Funcionarios_Todos.Checked = True
            End If

            .Grupo_Funcionario.Enabled = True
            .Grupo_Entidad.Enabled = False
            .Grupo_Producto.Enabled = False

            .Rdb_FEmision_Todas.Checked = True
            .Pro_Row_Entidad = _RowEntidad
            .Pro_Row_Producto = _RowProducto

            .ShowDialog(Me)

            If Not (.Pro_Row_Documento_Seleccionado Is Nothing) Then
                _IdMaeedo = .Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")
            End If

            .Dispose()

        End With

        If CBool(_IdMaeedo) Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set Idmaeedo_GRP_PRE = " & _IdMaeedo & vbCrLf &
                           "Where Id_Ot = " & _Id_Ot
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Guía de recepción asociada correctamente", "Guía de recpción",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Row_Encabezado.Item("Idmaeedo_GRP_PRE") = _IdMaeedo
                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Row_Encabezado.Item("Idmaeedo_GRP_PRE")
                Dim _Row_GRP As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_GRP) Then
                    Lbl_GRP.Text = _Row_GRP.Item("NUDO")
                    Lbl_GRP.Tag = _Row_GRP.Item("IDMAEEDO")
                End If

            End If

        End If

    End Sub

    Private Sub Btn_GRP_Crear_Guia_Click(sender As Object, e As EventArgs) Handles Btn_GRP_Crear_Guia.Click

        Dim _Nro_GRP As String
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese Guía/Factura del cliente", "Recepción de producto", _Nro_GRP,
                                              False, _Tipo_Mayus_Minus.Mayusculas, 10, True)

        If _Aceptar Then

            Dim _Idmaeedo_GRP_PRE As Integer = Fx_Crear_GRP_PRE(Grilla.Rows(0).Cells("Nro_Ot").Value, _Nro_GRP)

            If Convert.ToBoolean(_Idmaeedo_GRP_PRE) Then

                _Row_Encabezado.Item("Idmaeedo_GRP_PRE") = _Idmaeedo_GRP_PRE

                MessageBoxEx.Show(Me, "Guía de recepción por prestamos creada correctamente", "Guía de recpción",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Abrir_Documento = True
                Me.Close()

            End If

        End If

    End Sub

    Private Sub Btn_Contacto_Click(sender As Object, e As EventArgs) Handles Btn_Contacto.Click

        Dim _Koen As String = _RowEntidad.Item("KOEN")
        Dim _Suen As String = _RowEntidad.Item("SUEN")

        Dim _RowContacto As DataRow

        Dim Fm As New Frm_Crear_Entidad_Mt_Lista_contactos(True)
        Fm.Text = "SELECCIONE UN CONTACTO"
        Fm.Pro_CodEntidad = _Koen
        Fm.Pro_SucEntidad = _Suen
        Fm.ShowDialog(Me)

        If Fm.Pro_ContactoSeleccionado Then

            _EditarContactoTodasLasSubOT = False

            If _TieneHnosSubOT Then
                If MessageBoxEx.Show(Me, "¿Desea cambiar el contacto para todas las Sub-OT?", "Cambiar contacto",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _EditarContactoTodasLasSubOT = True
                End If
            End If

            _RowContacto = Fm.Pro_Tbl_DatosContacto.Rows(0)
            Txt_Email_Contacto.Text = _RowContacto.Item("EMAILCON").ToString.Trim
            Txt_Nombre_Contacto.Text = _RowContacto.Item("NOKOCON").ToString.Trim
            Txt_Telefono_Contacto.Text = _RowContacto.Item("FONOCON").ToString.Trim
            Txt_Defecto_segun_cliente.Focus()

        Else
            MessageBoxEx.Show(Me, "No se seleccionó ningún contacto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click
        'Sb_New_OT_Grabar_Nueva_OT()
    End Sub

    Private Sub Warning_NoReparable_OptionsClick(sender As Object, e As EventArgs) Handles Warning_NoReparable.OptionsClick

        Dim _Motivo As String = Fx_AjustarTexto(_Row_Notas.Item("Motivo_no_reparo"), 50)
        MessageBoxEx.Show(Me, "Motivo: " & _Motivo, "NO SE PUDO REPARAR EL PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub


End Class
