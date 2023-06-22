Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading
Imports DevComponents.DotNetBar

Public Class Frm_Demonio_New

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_ConfXEstacion As DataRow
    Dim _Tbl_Diablito As DataTable
    Dim _NombreEquipo As String

    Dim _DProgramaciones As DProgramaciones

    Dim _Cl_Correos As New Cl_Correos
    Dim _Cl_Imprimir_Documentos As New Cl_Imprimir_Documentos
    Dim _Cl_Imprimir_Picking As New Cl_Imprimir_Picking
    Dim _Cl_Solicitud_Productos_Bodega As New Cl_Solicitud_Productos_Bodega
    Dim _Cl_Prestashop_Orders As New Cl_Prestashop_Orders
    Dim _Cl_Prestashop_Prod As New Cl_Prestashop_Web
    Dim _Cl_Consolidacion_Stock As New Cl_Consolidacion_Stock


    Private _Timer_Correos As Timer
    Private _Timer_ImprimirDocumentos As Timer
    Private _Timer_ImprimirPicking As Timer
    Private _Timer_SolicitudProductosBodega As Timer
    Private _Timer_Prestashop_Orders As Timer
    Private _Timer_Prestashop_Prod As Timer


    Private logFilePath As String = "Log_Demonio.txt"

    Public Property CambioDeConfiguracion As Boolean

    Dim _RevConfiguracion As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select Cast(1 As Bit) As Chk,Cast('' As Varchar(20)) As Nombre,Cast('' As Varchar(100)) As Programacion,Cast('' As Varchar(100)) As Resumen Where 1<0"
        _Tbl_Diablito = _Sql.Fx_Get_Tablas(Consulta_sql)

        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        _DProgramaciones = New DProgramaciones

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Demonio_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Load()
        timerHora.Start()
    End Sub

    Sub Sb_Load()

        DtpFecharevision.Enabled = False

        If Global_Thema = Enum_Themas.Oscuro Then
            Listv_Programaciones.SmallImageList = Imagenes_16X16_Dark
        End If

        Me.Text = "Demonio para acciones automatizadas, V: [" & _Version_BkSpecialPrograms & "]"
        Lbl_Nombre_Equipo.Text = "Nombre equipo: " & _NombreEquipo
        Lbl_Modalidad.Text = "Modalidad: " & Modalidad & ", Sucursal: " & ModSucursal & ", Bodega: " & ModBodega

        Lbl_Estatus.Text = "Empresa: " & ModEmpresa & ", Modalidad: " & Modalidad & ", Usuario: " & FUNCIONARIO & ", Equipo: " & _NombreEquipo


        Dim _Grb_Programacion As New Grb_Programacion

        Dim _Id As Integer = _Global_Row_EstacionBk.Item("Id")

        Listv_Programaciones.Items.Clear()

        If Fx_InsertarRegistroDeProgramacion("EnvioCorreo", _DProgramaciones.Sp_EnvioCorreo, "Envio de correos") Then
            _DProgramaciones.Sp_EnvioCorreo.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("ColaImpDoc", _DProgramaciones.Sp_ColaImpDoc, "Imprimir documentos") Then
            _DProgramaciones.Sp_ColaImpDoc.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("ColaImpPick", _DProgramaciones.Sp_ColaImpPick, "Imprimir pickings") Then
            _DProgramaciones.Sp_ColaImpPick.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("SolProdBod", _DProgramaciones.Sp_SolProdBod, "Sol. productos a bod.") Then
            _DProgramaciones.Sp_SolProdBod.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("Prestashop_Order", _DProgramaciones.Sp_Prestashop_Order, "Prestashop Ordenes") Then
            _DProgramaciones.Sp_Prestashop_Order.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("Prestashop_Prod", _DProgramaciones.Sp_Prestashop_Prod, "Prestashop Web") Then
            _DProgramaciones.Sp_Prestashop_Prod.Activo = True
        End If

        Dim _CantidadFilas As Integer = Listv_Programaciones.Items.Count

        If _CantidadFilas = 1 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_1
        If _CantidadFilas = 2 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_2
        If _CantidadFilas = 3 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_3
        If _CantidadFilas = 4 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_4
        If _CantidadFilas = 5 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_5
        If _CantidadFilas = 6 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_6
        If _CantidadFilas = 7 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_7
        If _CantidadFilas = 8 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_8
        If _CantidadFilas = 9 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_9
        If _CantidadFilas > 9 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_9_plus

        If CBool(_CantidadFilas) Then
            Lbl_Monitoreo.Text = "MONITOREO ACTIVO"
            Circular_Monitoreo.IsRunning = True
        Else
            Lbl_Monitoreo.Text = "MONITOREO INACTIVO"
            Circular_Monitoreo.IsRunning = False
            Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink
        End If

        If _DProgramaciones.Sp_EnvioCorreo.Activo Then
            Sb_Timer_IntervaloCada(_Timer_Correos, _DProgramaciones.Sp_EnvioCorreo, AddressOf Sb_Enviar_Correos)
        End If

        If _DProgramaciones.Sp_ColaImpDoc.Activo Then
            Sb_Timer_IntervaloCada(_Timer_ImprimirDocumentos, _DProgramaciones.Sp_ColaImpDoc, AddressOf Sb_Imprimir_Documentos)
        End If

        If _DProgramaciones.Sp_ColaImpPick.Activo Then
            Sb_Timer_IntervaloCada(_Timer_ImprimirPicking, _DProgramaciones.Sp_ColaImpPick, AddressOf Sb_Imprimir_Picking)
        End If

        If _DProgramaciones.Sp_SolProdBod.Activo Then
            Sb_Timer_IntervaloCada(_Timer_SolicitudProductosBodega, _DProgramaciones.Sp_ColaImpPick, AddressOf Sb_Solicitud_Productos_Bodega)
        End If

        If _DProgramaciones.Sp_Prestashop_Order.Activo Then
            Sb_Timer_IntervaloCada(_Timer_Prestashop_Orders, _DProgramaciones.Sp_Prestashop_Order, AddressOf Sb_Prestashop_Orders)
        End If

        If _DProgramaciones.Sp_Prestashop_Prod.Activo Then
            'Sb_Timer_IntervaloCada(_Timer_Prestashop_Prod, _DProgramaciones.Sp_Prestashop_Prod, AddressOf Sb_Prestashop_Prod)

            With _DProgramaciones.Sp_Prestashop_Prod

                Dim milisegundos As Long

                If .FrecuDiaria Then
                    Dim _IntervaloCada As Integer = .IntervaloCada
                    If .SucedeCada Then

                        If .TipoIntervaloCada = "HH" Then
                            Dim tiempo As New TimeSpan(_IntervaloCada, 0, 0)
                            milisegundos = tiempo.TotalMilliseconds ' Convertir a milisegundos
                        End If

                        If .TipoIntervaloCada = "MM" Then
                            Dim tiempo As New TimeSpan(0, _IntervaloCada, 0)
                            milisegundos = tiempo.TotalMilliseconds ' Convertir a milisegundos
                        End If

                        If .TipoIntervaloCada = "SS" Then
                            Dim tiempo As New TimeSpan(0, 0, _IntervaloCada)
                            milisegundos = tiempo.TotalMilliseconds ' Convertir a milisegundos
                        End If

                    End If
                End If

                Timer_PrestaShopWeb.Interval = milisegundos
                Timer_PrestaShopWeb.Start()

            End With

        End If

        Me.Refresh()

    End Sub

    Function Fx_InsertarRegistroDeProgramacion(_Campo As String,
                                               ByRef _CI_Programacion As Cl_NewProgramacion,
                                               _Codigo As String) As Boolean


        Dim _Descripcion As String
        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Chk As Boolean
        Dim _IndexImagen As Integer
        Dim _ChkStr As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                      "Informe = 'Demonio' And Campo = 'Chk_" & _Campo & "' And NombreEquipo = '" & _NombreEquipo & "'")

        Boolean.TryParse(_ChkStr, _Chk)

        If _Chk Then

            Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id",
                                                       "NombreEquipo = '" & _NombreEquipo & "' And Tbl_Padre = 'Diablito' And Nombre = '" & _Campo & "'", True)
            _CI_Programacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

            Select Case _Campo
                Case "EnvioCorreo"

                    Dim _CantCorreo As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_CantCorreo' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Descripcion = "Se enviaran paquetes de " & _CantCorreo & " correos." & "; " & _CI_Programacion.Resumen
                    _IndexImagen = 0

                Case "ColaImpDoc"

                    _Descripcion = "Se imprimiran documentos. " & _CI_Programacion.Resumen
                    _IndexImagen = 1

                Case "ColaImpPick"

                    _Descripcion = "Se imprimiran pickings. " & _CI_Programacion.Resumen
                    _IndexImagen = 2

                Case "SolProdBod"

                    _Descripcion = "Solicitud de productos desde mesón de venta hacia bodega" & _CI_Programacion.Resumen
                    _IndexImagen = 3

                Case "Prestashop_Order"

                    _Descripcion = "Buscar ordenes de Prestashop en sitios Web..." & _CI_Programacion.Resumen
                    _IndexImagen = 4

                Case "Prestashop_Prod"

                    _Descripcion = "Sincronización de stock y precios con productos en la(s) Web" & _CI_Programacion.Resumen
                    _IndexImagen = 4

            End Select

            _CI_Programacion.Resumen = _Descripcion

            Dim _NewFila As ListViewItem = New ListViewItem(_Codigo, _IndexImagen)
            _NewFila.SubItems.Add(_Descripcion)
            Listv_Programaciones.Items.Add(_NewFila)

            Return True

        End If

    End Function

    Sub Sb_Insertar_Registro(_Nombre As String, _Programacion As String, _Resumen As String)

        Dim NewFila As DataRow
        NewFila = _Tbl_Diablito.NewRow
        With NewFila

            .Item("Chk") = True
            .Item("Nombre") = _Nombre
            .Item("Programacion") = _Programacion
            .Item("Resumen") = _Resumen

            _Tbl_Diablito.Rows.Add(NewFila)

        End With

    End Sub

#Region "TIMER"

    Sub Sb_Timer_Correo()

        _Timer_Correos = Nothing
        Dim horaProgramada As DateTime

        If _DProgramaciones.Sp_EnvioCorreo.FrecuDiaria Then
            Dim _IntervaloCada As Integer = _DProgramaciones.Sp_EnvioCorreo.IntervaloCada
            If _DProgramaciones.Sp_EnvioCorreo.SucedeCada Then
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
            End If
        End If

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        _Timer_Correos = New Timer(AddressOf Sb_Enviar_Correos, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub

    Sub Sb_Timer_ImprimirDocumentos()

        _Timer_ImprimirDocumentos = Nothing
        Dim horaProgramada As DateTime

        With _DProgramaciones.Sp_ColaImpDoc

            If .FrecuDiaria Then
                Dim _IntervaloCada As Integer = .IntervaloCada
                If .SucedeCada Then
                    If .TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                    If .TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                    If .TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
                End If
            End If

        End With

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        _Timer_ImprimirDocumentos = New Timer(AddressOf Sb_Imprimir_Documentos, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub

    Sub Sb_Timer_ImprimirPicking()

        _Timer_ImprimirPicking = Nothing
        Dim horaProgramada As DateTime

        With _DProgramaciones.Sp_ColaImpPick

            If .FrecuDiaria Then
                Dim _IntervaloCada As Integer = .IntervaloCada
                If .SucedeCada Then
                    If .TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                    If .TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                    If .TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
                End If
            End If

        End With

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        _Timer_ImprimirPicking = New Timer(AddressOf Sb_Imprimir_Picking, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub

#End Region

    Sub Sb_Timer_IntervaloCada(ByRef _Timer As Timer, ByRef _Sp_Programacion As Cl_NewProgramacion, Sb_Proceso As TimerCallback)

        _Timer = Nothing
        Dim horaProgramada As DateTime

        With _Sp_Programacion

            If .FrecuDiaria Then
                Dim _IntervaloCada As Integer = .IntervaloCada
                If .SucedeCada Then
                    If .TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                    If .TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                    If .TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
                End If
            End If

        End With

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        _Timer = New Timer(Sb_Proceso, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub

    Sub Sb_Enviar_Correos(state As Object)

        If IsNothing(_Timer_Correos) Then Return

        If _Cl_Correos.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(15) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

            _Timer_Correos.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Envío correo (Proceso en curso se volverá a revisar en 15 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Correos.Procesando = False

        Else

            _Cl_Correos.Fecha_Revision = DtpFecharevision.Value
            _Cl_Correos.Sb_Procedimiento_Correos()

            'Sb_Timer_Correo()
            Sb_Timer_IntervaloCada(_Timer_Correos, _DProgramaciones.Sp_EnvioCorreo, AddressOf Sb_Enviar_Correos)

            Dim registro As String = "Tarea ejecutada (Correo) a las: " & DateTime.Now.ToString() & vbCrLf

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Correos.Procesando = True

        End If

    End Sub

    Sub Sb_Imprimir_Documentos(state As Object)

        If IsNothing(_Timer_ImprimirDocumentos) Then Return

        If _Cl_Imprimir_Documentos.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(2) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

            _Timer_ImprimirDocumentos.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Imprimir documentos (Proceso en curso se volverá a revisar en 3 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Imprimir_Documentos.Procesando = False

        Else

            _Cl_Imprimir_Documentos.Fecha_Revision = DtpFecharevision.Value
            _Cl_Imprimir_Documentos.Nombre_Equipo = _NombreEquipo
            _Cl_Imprimir_Documentos.Log_Registro = String.Empty
            _Cl_Imprimir_Documentos.Sb_Procedimiento_Cola_Impresion()

            Sb_Timer_IntervaloCada(_Timer_ImprimirDocumentos, _DProgramaciones.Sp_ColaImpDoc, AddressOf Sb_Imprimir_Documentos)
            'Sb_Timer_ImprimirDocumentos()

            Dim registro As String = "Tarea ejecutada (Imprimir documentos) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Imprimir_Documentos.Log_Registro) Then
                registro += vbCrLf & _Cl_Imprimir_Documentos.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

            '_Cl_Imprimir_Documentos.Procesando = True

        End If

    End Sub

    Sub Sb_Imprimir_Picking(state As Object)

        If IsNothing(_Timer_Correos) Then Return

        If _Cl_Imprimir_Picking.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(2) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_ImprimirPicking.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Imprimir picking (Proceso en curso se volverá a revisar en 2 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Imprimir_Documentos.Procesando = False

        Else

            _Cl_Imprimir_Picking.Fecha_Revision = DtpFecharevision.Value
            _Cl_Imprimir_Picking.Nombre_Equipo = _NombreEquipo
            _Cl_Imprimir_Picking.Log_Registro = String.Empty
            _Cl_Imprimir_Picking.Sb_Procedimiento_Picking()

            Sb_Timer_IntervaloCada(_Timer_ImprimirPicking, _DProgramaciones.Sp_ColaImpPick, AddressOf Sb_Imprimir_Picking)
            'Sb_Timer_ImprimirPicking()

            Dim registro As String = "Tarea ejecutada (Imprimir picking) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Imprimir_Picking.Log_Registro) Then
                registro += vbCrLf & _Cl_Imprimir_Picking.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

            '_Cl_Imprimir_Documentos.Procesando = True

        End If

    End Sub

    Sub Sb_Solicitud_Productos_Bodega(state As Object)

        If IsNothing(_Timer_SolicitudProductosBodega) Then Return

        If _Cl_Solicitud_Productos_Bodega.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(2) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_SolicitudProductosBodega.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Solicitar productos a bodega (Proceso en curso se volverá a revisar en 2 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

        Else

            _Cl_Solicitud_Productos_Bodega.Fecha_Revision = DtpFecharevision.Value
            _Cl_Solicitud_Productos_Bodega.Nombre_Equipo = _NombreEquipo
            _Cl_Solicitud_Productos_Bodega.Log_Registro = String.Empty
            _Cl_Solicitud_Productos_Bodega.Sb_Procedimiento_Solicitud_De_Productos_A_Bodega()

            Sb_Timer_IntervaloCada(_Timer_SolicitudProductosBodega, _DProgramaciones.Sp_SolProdBod, AddressOf Sb_Solicitud_Productos_Bodega)

            Dim registro As String = "Tarea ejecutada (Solicitar producto a bodega) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Solicitud_Productos_Bodega.Log_Registro) Then
                registro += vbCrLf & _Cl_Solicitud_Productos_Bodega.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

        End If

    End Sub

    Sub Sb_Prestashop_Orders(state As Object)

        If IsNothing(_Timer_Prestashop_Orders) Then Return

        If _Cl_Prestashop_Orders.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(2) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_Prestashop_Orders.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Prestashop Ordenes (Proceso en curso se volverá a revisar en 2 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

        Else

            _Cl_Prestashop_Orders.Fecha_Revision = DtpFecharevision.Value
            _Cl_Prestashop_Orders.Nombre_Equipo = _NombreEquipo
            _Cl_Prestashop_Orders.Log_Registro = String.Empty
            _Cl_Prestashop_Orders.Sb_Procedimiento_Prestashop_orders()

            Sb_Timer_IntervaloCada(_Timer_Prestashop_Orders, _DProgramaciones.Sp_Prestashop_Order, AddressOf Sb_Prestashop_Orders)

            Dim registro As String = "Tarea ejecutada (Prestashop Ordenes) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Prestashop_Orders.Log_Registro) Then
                registro += vbCrLf & _Cl_Prestashop_Orders.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

        End If

    End Sub

    Sub Sb_Prestashop_Prod(state As Object)

        If IsNothing(_Timer_Prestashop_Prod) Then Return

        If _Cl_Prestashop_Prod.Procesando Or _Cl_Consolidacion_Stock.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(30) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_Prestashop_Prod.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Prestashop sincronización de stock y precios de productos en la web (Proceso en curso se volverá a revisar en 30 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

        Else

            Dim registro As String = "Ejecutando tarea Prestashop Web a las: " & DateTime.Now.ToString()

            RegistrarLog(registro)
            MostrarRegistro(registro)

            'Lbl_Procesando.Text = "Inicio de proceso de Prestashop Web..."

            _Cl_Prestashop_Prod.Fecha_Revision = DtpFecharevision.Value
            _Cl_Prestashop_Prod.Nombre_Equipo = _NombreEquipo
            _Cl_Prestashop_Prod.Log_Registro = String.Empty

            _Cl_Prestashop_Prod.Procesando = True

            _Cl_Consolidacion_Stock.Cons_Stock_Mov_Hoy = True
            _Cl_Consolidacion_Stock.Sb_Procedimiento_Consolidar_Stock(Me)

            _Cl_Prestashop_Prod.Lbl_Estado = Lbl_Procesando.Text
            _Cl_Prestashop_Prod.Sb_Procedimiento_Prestashop()
            _Cl_Prestashop_Prod.Sb_Procedimiento_Prestashop3()

            Sb_Timer_IntervaloCada(_Timer_Prestashop_Prod, _DProgramaciones.Sp_Prestashop_Prod, AddressOf Sb_Prestashop_Prod)

            registro = "Tarea ejecutada (Prestashop Productos Web) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Prestashop_Prod.Log_Registro) Then
                registro += vbCrLf & _Cl_Prestashop_Prod.Log_Registro

                ' Registrar la información en un archivo de registro
            End If

            RegistrarLog(registro)
            MostrarRegistro(registro)

            _Cl_Prestashop_Prod.Procesando = False



        End If

    End Sub


    Private Sub RegistrarLog(registro As String)
        Try
            ' Escribir la información en el archivo de registro
            Using writer As New StreamWriter(logFilePath, True)
                writer.WriteLine(registro)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarRegistro(registro As String)
        ' Agregar el registro al TextBox
        Try
            Txt_Log.Invoke(Sub() Txt_Log.AppendText(registro & Environment.NewLine))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Frm_Demonio_New_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Limpirar_Timers()
    End Sub

    Sub Sb_Limpirar_Timers()
        Circular_Monitoreo.IsRunning = False
        Lbl_Monitoreo.Text = "MONITOREO EN PAUSA"
        _Timer_Correos = Nothing
        _Timer_ImprimirDocumentos = Nothing
        _Timer_ImprimirPicking = Nothing
        _Timer_SolicitudProductosBodega = Nothing
        _Timer_Prestashop_Orders = Nothing
        _Timer_Prestashop_Prod = Nothing
    End Sub

    Private Sub Btn_Configurar_Click(sender As Object, e As EventArgs) Handles Btn_Configurar.Click

        Sb_Limpirar_Timers()

        Dim _Row_Usuario_Autorizado As DataRow

        Dim FmP As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
        FmP.Pro_Cerrar_Automaticamente = True
        FmP.ShowDialog(Me)
        Dim _Validar As Boolean = FmP.Pro_Permiso_Aceptado
        _Row_Usuario_Autorizado = FmP.Pro_RowUsuario
        FmP.Dispose()

        If _Validar Then
            CambioDeConfiguracion = True
            Me.Close()

            'Dim _Id As Integer = _Global_Row_EstacionBk.Item("Id")
            'Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
            'Dim _Cambiar_Usuario_X_Defecto As Boolean

            'Dim Fm As New Frm_Demonio_Configuraciones(_Id, _Row_Usuario_Autorizado.Item("KOFU"))
            'Fm.ShowDialog(Me)
            '_Cambiar_Usuario_X_Defecto = Fm.Cambiar_Usuario_X_Defecto
            'Fm.Dispose()

            'If _Cambiar_Usuario_X_Defecto Then

            '    MessageBoxEx.Show(Me, "Usuario y modalidad cambiados para revisión", "Cambio de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'End If

            'Sb_Load()

        Else

            Dim _CantidadFilas As Integer = Listv_Programaciones.Items.Count

            If CBool(_CantidadFilas) Then
                Lbl_Monitoreo.Text = "MONITOREO ACTIVO"
                Circular_Monitoreo.IsRunning = True
            End If

            Me.Refresh()

        End If

    End Sub

    Private Sub timerHora_Tick(sender As Object, e As EventArgs) Handles timerHora.Tick

        Me.Text = "Demonio para acciones automatizadas, V: [" & _Version_BkSpecialPrograms & "] " & DateTime.Now.ToString("HH:mm:ss")

        If _Cl_Prestashop_Prod.Procesando Then

            For Each item As ListViewItem In Listv_Programaciones.Items
                If item.Text = "Prestashop Web" Then
                    item.SubItems(1).Text = _Cl_Prestashop_Prod.Etiqueta2.Text
                    Exit For
                End If
            Next

        End If

        Me.Refresh()

    End Sub

    Private Sub Timer_PrestaShopWeb_Tick(sender As Object, e As EventArgs) Handles Timer_PrestaShopWeb.Tick

        Timer_PrestaShopWeb.Stop()

        Dim registro As String = "Ejecutando tarea Prestashop Web a las: " & DateTime.Now.ToString()

        RegistrarLog(registro)
        MostrarRegistro(registro)

        Lbl_Procesando.Text = "Inicio de proceso de Prestashop Web..."

        _Cl_Prestashop_Prod.Fecha_Revision = DtpFecharevision.Value
        _Cl_Prestashop_Prod.Nombre_Equipo = _NombreEquipo
        _Cl_Prestashop_Prod.Log_Registro = String.Empty

        _Cl_Prestashop_Prod.Procesando = True

        _Cl_Consolidacion_Stock.Cons_Stock_Mov_Hoy = True
        _Cl_Consolidacion_Stock.Sb_Procedimiento_Consolidar_Stock(Me)

        _Cl_Prestashop_Prod.Lbl_Estado = Lbl_Procesando.Text
        _Cl_Prestashop_Prod.Sb_Procedimiento_Prestashop()
        _Cl_Prestashop_Prod.Sb_Procedimiento_Prestashop3()

        'Sb_Timer_IntervaloCada(_Timer_Prestashop_Prod, _DProgramaciones.Sp_Prestashop_Prod, AddressOf Sb_Prestashop_Prod)

        registro = "Tarea ejecutada (Prestashop Productos Web) a las: " & DateTime.Now.ToString()

        If Not String.IsNullOrWhiteSpace(_Cl_Prestashop_Prod.Log_Registro) Then
            registro += vbCrLf & _Cl_Prestashop_Prod.Log_Registro

            ' Registrar la información en un archivo de registro
        End If

        RegistrarLog(registro)
        MostrarRegistro(registro)

        _Cl_Prestashop_Prod.Procesando = False

        Timer_PrestaShopWeb.Start()

        For Each item As ListViewItem In Listv_Programaciones.Items
            If item.Text = "Prestashop Web" Then
                item.SubItems(1).Text = _DProgramaciones.Sp_Prestashop_Prod.Resumen
                Exit For
            End If
        Next

    End Sub

    Private Sub Timer_Correos_Tick(sender As Object, e As EventArgs)

    End Sub
End Class
