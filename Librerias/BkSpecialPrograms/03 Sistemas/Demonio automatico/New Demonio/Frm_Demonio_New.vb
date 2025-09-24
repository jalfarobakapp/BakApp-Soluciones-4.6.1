Imports System.IO
Imports System.Threading
Imports Newtonsoft.Json

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
    Dim _Cl_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro
    Dim _Cl_Archivador As New Cl_Archivador
    Dim _Cl_Listas_Programadas As New Cl_Listas_Programadas
    Dim _Cl_FacturacionAuto As New Cl_FacAuto_NVV
    Dim _Cl_CerrarDocumentos As New Cl_Cerrar_Documentos
    Dim _Cl_Asistente_Compras As New Cl_Asistente_Compras
    Dim _Cl_Enviar_Doc_SinRecepcion As New Cl_Enviar_Doc_SinRecepcion
    Dim _Cl_NVVAutoExterna As New Cl_NVVAutoExterna
    Dim _Cl_RecalculoPPP As New Cl_RecalculoPPP

    'Private _Timer_ImprimirDocumentos As Timer
    Private _Timer_ImprimirPicking As Timer
    Private _Timer_SolicitudProductosBodega As Timer
    Private _Timer_Prestashop_Orders As Timer
    Private _Timer_Prestashop_Prod As Timer
    Private _Timer_Archivador As Timer
    Private _Timer_ListasProgramadas As Timer

    Private logFilePath As String = "Log_Demonio.txt"


    Public Property CambioDeConfiguracion As Boolean

    Dim _RevConfiguracion As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select Cast(1 As Bit) As Chk,Cast('' As Varchar(20)) As Nombre,Cast('' As Varchar(100)) As Programacion,Cast('' As Varchar(100)) As Resumen Where 1<0"
        _Tbl_Diablito = _Sql.Fx_Get_DataTable(Consulta_sql)

        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        _DProgramaciones = New DProgramaciones

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Demonio_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Load()

        Dim tiempo As New TimeSpan(0, 5, 0)
        Dim milisegundos = tiempo.TotalMilliseconds

        Timer_Minimizar.Interval = milisegundos
        Timer_Minimizar.Start()
        timerHora.Start()
        Timer_Ejecuciones.Start()

    End Sub

    Sub Sb_Load()

        DtpFecharevision.Enabled = False

        If Global_Thema = Enum_Themas.Oscuro Then
            Listv_Programaciones.SmallImageList = Imagenes_16X16_Dark
        End If

        Me.Text = "Demonio para acciones automatizadas, V: [" & _Version_BkSpecialPrograms & "]"
        Lbl_Nombre_Equipo.Text = "Nombre equipo: " & _NombreEquipo & ", Base de datos Bakapp: " & _Global_BaseBk
        Lbl_Modalidad.Text = "Modalidad: " & Mod_Modalidad & ", Sucursal: " & Mod_Sucursal & ", Bodega: " & Mod_Bodega

        Lbl_Estatus.Text = "Empresa: " & RutEmpresa & " (" & Mod_Empresa & "), Modalidad: " & Mod_Modalidad & ", Usuario: " & FUNCIONARIO & ", Equipo: " & _NombreEquipo & ", diablito = " & _Global_EsDiablito.ToString


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

        If Fx_InsertarRegistroDeProgramacion("ImporDTESII", _DProgramaciones.Sp_ImporDTESII, "Importar DTE SII") Then
            _DProgramaciones.Sp_ImporDTESII.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("ArchivarDoc", _DProgramaciones.Sp_ArchivarDoc, "Archivador") Then
            _DProgramaciones.Sp_ArchivarDoc.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("ListasProgramadas", _DProgramaciones.Sp_ListasProgramadas, "Listas Programadas") Then
            _DProgramaciones.Sp_ListasProgramadas.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("FacAuto", _DProgramaciones.Sp_FacturacionAuto, "Facturación automática") Then
            _DProgramaciones.Sp_FacturacionAuto.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("ConsStock", _DProgramaciones.Sp_ConsStock, "Consolidación Stock") Then
            _DProgramaciones.Sp_ConsStock.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("CierreDoc", _DProgramaciones.Sp_CierreDoc, "Cierre de documentos") Then
            _DProgramaciones.Sp_CierreDoc.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("AsistenteCompras", _DProgramaciones.Sp_AsistenteCompras, "Asistente de compras") Then
            _DProgramaciones.Sp_AsistenteCompras.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("EnvDocSinRecep", _DProgramaciones.Sp_EnviarDocSinRecepcion, "Aviso documentos sin recepcionar") Then
            _DProgramaciones.Sp_EnviarDocSinRecepcion.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("NVVAuto", _DProgramaciones.Sp_NVVExterna, "Notas de venta externas") Then
            _DProgramaciones.Sp_NVVExterna.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("RecalculoPPP", _DProgramaciones.Sp_RecalculoPPP, "Recalculo Precio Promedio Ponderado") Then
            _DProgramaciones.Sp_RecalculoPPP.Activo = True
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
            Sb_Activar_ObjetosTimer(Timer_Correo, _DProgramaciones.Sp_EnvioCorreo)
        End If

        'If _DProgramaciones.Sp_ColaImpDoc.Activo Then
        '    Sb_Timer_IntervaloCada(_Timer_ImprimirDocumentos, _DProgramaciones.Sp_ColaImpDoc, AddressOf Sb_Imprimir_Documentos)
        'End If

        If _DProgramaciones.Sp_ColaImpDoc.Activo Then
            Sb_Activar_ObjetosTimer(Timer_ImprimirDocumentos, _DProgramaciones.Sp_ColaImpDoc)
            '    Sb_Timer_IntervaloCada(_Timer_ImprimirDocumentos, _DProgramaciones.Sp_ColaImpDoc, AddressOf Sb_Imprimir_Documentos)
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
            Sb_Activar_ObjetosTimer(Timer_PrestaShopWeb, _DProgramaciones.Sp_Prestashop_Prod)
        End If

        If _DProgramaciones.Sp_ImporDTESII.Activo Then
            Sb_Activar_ObjetosTimer(Timer_LibroDTESII, _DProgramaciones.Sp_ImporDTESII)
        End If

        If _DProgramaciones.Sp_ArchivarDoc.Activo Then
            Sb_Timer_IntervaloCada(_Timer_Archivador, _DProgramaciones.Sp_ArchivarDoc, AddressOf Sb_Archivador)
        End If

        If _DProgramaciones.Sp_ListasProgramadas.Activo Then
            Sb_Timer_IntervaloCada(_Timer_ListasProgramadas, _DProgramaciones.Sp_ListasProgramadas, AddressOf Sb_ListasProgramadas)
        End If

        If _DProgramaciones.Sp_FacturacionAuto.Activo Then
            Sb_Activar_ObjetosTimer(Timer_FacturacionAuto, _DProgramaciones.Sp_FacturacionAuto)
        End If

        If _DProgramaciones.Sp_ConsStock.Activo Then
            Sb_Activar_ObjetosTimer(Timer_ConsolidacionStock, _DProgramaciones.Sp_ConsStock)
        End If

        If _DProgramaciones.Sp_CierreDoc.Activo Then
            Sb_Activar_ObjetosTimer(Timer_CerrarDocumentos, _DProgramaciones.Sp_CierreDoc)
        End If

        If _DProgramaciones.Sp_AsistenteCompras.Activo Then
            Sb_Activar_ObjetosTimer(Timer_AsistenteCompras, _DProgramaciones.Sp_AsistenteCompras)
        End If

        If _DProgramaciones.Sp_EnviarDocSinRecepcion.Activo Then
            Sb_Activar_ObjetosTimer(Timer_Enviar_Doc_SinRecepcion, _DProgramaciones.Sp_EnviarDocSinRecepcion)
        End If

        If _DProgramaciones.Sp_NVVExterna.Activo Then
            Sb_Activar_ObjetosTimer(Timer_NVVAutoExterna, _DProgramaciones.Sp_NVVExterna)
        End If

        If _DProgramaciones.Sp_RecalculoPPP.Activo Then
            Sb_Activar_ObjetosTimer(Timer_RecalculoPPP, _DProgramaciones.Sp_RecalculoPPP)
        End If

        Me.Refresh()

    End Sub

    Sub Sb_Activar_ObjetosTimer(_Timer As Windows.Forms.Timer, _Sp_Programacion As Cl_NewProgramacion)

        With _Sp_Programacion

            Dim milisegundos As Long

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

            If .SucedeUnaVez Then

                Dim _Hora = .HoraUnaVez.Hour
                Dim _Minuto = .HoraUnaVez.Minute

                Dim tiempo As New TimeSpan(_Hora, _Minuto, 0)
                Dim horaProgramada As DateTime

                horaProgramada = DateTime.Today.AddHours(_Hora).AddMinutes(_Minuto)

                If horaProgramada < DateTime.Now Then
                    horaProgramada = horaProgramada.Date.AddDays(1).AddHours(_Hora).AddMinutes(_Minuto)
                    tiempo = New TimeSpan(1, _Hora, _Minuto, 0)
                End If

                Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

                milisegundos = tiempoRestante.TotalMilliseconds ' Convertir a milisegundos

            End If

            _Timer.Interval = milisegundos
            _Timer.Start()

        End With

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

                    Dim _CantCorreo As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                                   "Valor", "Informe = 'Demonio' And Campo = 'Input_CantCorreo' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    Dim _EnviarSiempreLosCorreosDTE As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                                   "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnviarSiempreLosCorreosDTE' And NombreEquipo = '" & _NombreEquipo & "'", False,, False)

                    _Cl_Correos.CantMmail = _CantCorreo
                    _Cl_Correos.EnviarSiempreLosCorreosDTE = _EnviarSiempreLosCorreosDTE

                    _Cl_Correos.ActualizarListaMayoristaMinorista = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                                   "Valor", "Informe = 'Demonio' And Campo = 'Chk_ActualizarListaMayoristaMinorista' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Cl_Correos.CorreoMayoristaMinorista = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                                   "Valor", "Informe = 'Demonio' And Campo = 'Txt_CorreoMayoristaMinorista_Tag' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Descripcion = "Se enviaran paquetes de " & _CantCorreo & " correos. " & _CI_Programacion.Resumen
                    _IndexImagen = 0

                Case "ColaImpDoc"

                    _Cl_Imprimir_Documentos.ColaImpImprmirTodoNodejarCola = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                                   "Valor", "Informe = 'Demonio' And Campo = 'Chk_ColaImpImprmirTodoNodejarCola' And NombreEquipo = '" & _NombreEquipo & "'", False,, False)

                    _Descripcion = _CI_Programacion.Resumen ' "Se imprimiran documentos. " & _CI_Programacion.Resumen
                    _IndexImagen = 1

                Case "ColaImpPick"

                    _Descripcion = _CI_Programacion.Resumen ' "Se imprimiran pickings. " & _CI_Programacion.Resumen
                    _IndexImagen = 2

                Case "SolProdBod"

                    Dim _Impresora_Prod_Sol_Bodega As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                                   "Valor", "Informe = 'Demonio' And Campo = 'Txt_ImpSolProdBod' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Cl_Solicitud_Productos_Bodega.Impresora_Prod_Sol_Bodega = _Impresora_Prod_Sol_Bodega

                    _Descripcion = _CI_Programacion.Resumen '"Solicitud de productos desde mesón de venta hacia bodega. " & _CI_Programacion.Resumen
                    _IndexImagen = 3

                Case "Prestashop_Order"

                    _Descripcion = _CI_Programacion.Resumen ' "Buscar ordenes de Prestashop en sitios Web. " & _CI_Programacion.Resumen
                    _IndexImagen = 4

                Case "Prestashop_Prod"

                    _Descripcion = _CI_Programacion.Resumen ' "Sincronización de stock y precios con productos en la(s) Web. " & _CI_Programacion.Resumen
                    _IndexImagen = 4

                Case "ImporDTESII"

                    _Descripcion = "Monitoreo Libro DTE desde SII. " & _CI_Programacion.Resumen
                    _IndexImagen = 5

                Case "ArchivarDoc"

                    Dim _Ruta_Archivador As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                                   "Valor", "Informe = 'Demonio' And Campo = 'Txt_DirArchivarDoc' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Cl_Archivador.Ruta_Archivador = _Ruta_Archivador
                    _Descripcion = _CI_Programacion.Resumen '"Archivador de documentos del sistema para respaldos. " & _CI_Programacion.Resumen
                    _IndexImagen = 6

                Case "ListasProgramadas"

                    _Descripcion = _CI_Programacion.Resumen ' "Actualización de listas programadas a futuro. " & _CI_Programacion.Resumen
                    _IndexImagen = 7

                Case "FacAuto"

                    Dim _FA_1Dia As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FacAuto_Dia' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _FA_1Semana As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FacAuto_Sem' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _FA_1Mes As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FacAuto_Mes' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _FA_1Todas As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FacAuto_Todas' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Modalidad_Fac As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Txt_FacAuto_Modalidad' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    Dim _CualquierNVV As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FacAuto_CualquierNVV' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _SoloDeSucModalidad As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FacAuto_SoloDeSucModalidad' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    Dim _CantDocFacturanXProceso As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_CantDocFacturanXProceso' And NombreEquipo = '" & _NombreEquipo & "'",,, 20)

                    Dim _FcOrden_Llegada As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FcOrden_Llegada' And NombreEquipo = '" & _NombreEquipo & "'",,, "True")
                    Dim _FcOrden_ItemMenosMas As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_FcOrden_ItemMenosMas' And NombreEquipo = '" & _NombreEquipo & "'",,, "False")

                    Dim _CodFunFactura As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Txt_FacAuto_CodFunFactura' And NombreEquipo = '" & _NombreEquipo & "'")

                    Boolean.TryParse(_FA_1Dia, _Cl_FacturacionAuto.FA_1Dia)
                    Boolean.TryParse(_FA_1Semana, _Cl_FacturacionAuto.FA_1Semana)
                    Boolean.TryParse(_FA_1Mes, _Cl_FacturacionAuto.FA_1Mes)
                    Boolean.TryParse(_FA_1Todas, _Cl_FacturacionAuto.FA_1Todas)

                    Boolean.TryParse(_CualquierNVV, _Cl_FacturacionAuto.CualquierNVV)
                    Boolean.TryParse(_SoloDeSucModalidad, _Cl_FacturacionAuto.SoloDeSucModalidad)

                    Boolean.TryParse(_FcOrden_Llegada, _Cl_FacturacionAuto.FcOrden_Llegada)
                    Boolean.TryParse(_FcOrden_ItemMenosMas, _Cl_FacturacionAuto.FcOrden_ItemMenosMas)

                    _Cl_FacturacionAuto.CantDocFacturanXProceso = _CantDocFacturanXProceso
                    _Cl_FacturacionAuto.Modalidad_Fac = _Modalidad_Fac
                    _Cl_FacturacionAuto.CodFunFactura = Replace(_CodFunFactura, "''", "'")

                    _Descripcion = _CI_Programacion.Resumen ' "Facturación de notas de venta para clientes con condición automática. " & _CI_Programacion.Resumen
                    _IndexImagen = 8

                Case "ConsStock"

                    Dim _Rdb_Cons_Stock_Mov_Hoy As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_Cons_Stock_Mov_Hoy' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Rdb_Cons_Stock_Todos As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Rdb_Cons_Stock_Todos' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    Boolean.TryParse(_Rdb_Cons_Stock_Mov_Hoy, _Cl_Consolidacion_Stock.Cons_Stock_Mov_Hoy)
                    Boolean.TryParse(_Rdb_Cons_Stock_Todos, _Cl_Consolidacion_Stock.Cons_Stock_Todos)

                    _Descripcion = _CI_Programacion.Resumen
                    _IndexImagen = 9

                Case "CierreDoc"

                    'Dim _Chk_COVCerrar As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_COVCerrar' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    'Dim _Chk_OCICerrar As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_OCICerrar' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    'Dim _Chk_OCCCerrar As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_OCCCerrar' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    'Dim _Chk_NVICerrar As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_NVICerrar' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    'Dim _Chk_NVVCerrar As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_NVVCerrar' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    'Boolean.TryParse(_Chk_COVCerrar, _Cl_CerrarDocumentos.COVCerrar)
                    'Boolean.TryParse(_Chk_OCICerrar, _Cl_CerrarDocumentos.OCICerrar)
                    'Boolean.TryParse(_Chk_OCCCerrar, _Cl_CerrarDocumentos.OCCCerrar)
                    'Boolean.TryParse(_Chk_NVICerrar, _Cl_CerrarDocumentos.NVICerrar)
                    'Boolean.TryParse(_Chk_NVVCerrar, _Cl_CerrarDocumentos.NVVCerrar)

                    '_Cl_CerrarDocumentos.DiasCOV = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_DiasCOV' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    '_Cl_CerrarDocumentos.DiasOCI = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_DiasOCI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    '_Cl_CerrarDocumentos.DiasOCC = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_DiasOCC' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    '_Cl_CerrarDocumentos.DiasNVI = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_DiasNVI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    '_Cl_CerrarDocumentos.DiasNVV = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_DiasNVV' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Descripcion = _CI_Programacion.Resumen
                    _IndexImagen = 10

                Case "AsistenteCompras"

                    _Descripcion = "Asistente de compras automática" & _CI_Programacion.Resumen
                    _IndexImagen = 11

                Case "EnvDocSinRecep"

                    Dim _Chk_EnvDocSinRecep_COV As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnvDocSinRecep_COV' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Chk_EnvDocSinRecep_NVI As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnvDocSinRecep_NVI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Chk_EnvDocSinRecep_NVV As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnvDocSinRecep_NVV' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Chk_EnvDocSinRecep_OCI As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnvDocSinRecep_OCI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Chk_EnvDocSinRecep_OCC As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnvDocSinRecep_OCC' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Chk_EnvDocSinRecep_GTI As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnvDocSinRecep_GTI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    Dim _Chk_EnvDocSinRecep_GDI As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Chk_EnvDocSinRecep_GDI' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    Boolean.TryParse(_Chk_EnvDocSinRecep_COV, _Cl_Enviar_Doc_SinRecepcion.COV)
                    Boolean.TryParse(_Chk_EnvDocSinRecep_NVI, _Cl_Enviar_Doc_SinRecepcion.NVI)
                    Boolean.TryParse(_Chk_EnvDocSinRecep_NVV, _Cl_Enviar_Doc_SinRecepcion.NVV)
                    Boolean.TryParse(_Chk_EnvDocSinRecep_OCI, _Cl_Enviar_Doc_SinRecepcion.OCI)
                    Boolean.TryParse(_Chk_EnvDocSinRecep_OCC, _Cl_Enviar_Doc_SinRecepcion.OCC)
                    Boolean.TryParse(_Chk_EnvDocSinRecep_GTI, _Cl_Enviar_Doc_SinRecepcion.GTI)
                    Boolean.TryParse(_Chk_EnvDocSinRecep_GDI, _Cl_Enviar_Doc_SinRecepcion.GDI)

                    _Cl_Enviar_Doc_SinRecepcion.DiasCOV = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_EnvDocSinRecep_DiasCOV' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Cl_Enviar_Doc_SinRecepcion.DiasNVI = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_EnvDocSinRecep_DiasNVI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Cl_Enviar_Doc_SinRecepcion.DiasNVV = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_EnvDocSinRecep_DiasNVV' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Cl_Enviar_Doc_SinRecepcion.DiasOCI = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_EnvDocSinRecep_DiasOCI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Cl_Enviar_Doc_SinRecepcion.DiasOCC = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_EnvDocSinRecep_DiasOCC' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Cl_Enviar_Doc_SinRecepcion.DiasGTI = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_EnvDocSinRecep_DiasGTI' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Cl_Enviar_Doc_SinRecepcion.DiasGDI = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_EnvDocSinRecep_DiasGDI' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Cl_Enviar_Doc_SinRecepcion.Id_Correo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Txt_CtaCorreoEnvDocSinRecep_Tag' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Cl_Enviar_Doc_SinRecepcion.Para = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Txt_ParaEnvDocSinRecep' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Descripcion = _CI_Programacion.Resumen
                    _IndexImagen = 12

                Case "NVVAuto"

                    Dim _Modalidad_NVV As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Txt_NvvAuto_Modalidad' And NombreEquipo = '" & _NombreEquipo & "'", True)

                    _Cl_NVVAutoExterna.Modalidad_NVV = _Modalidad_NVV

                    _Descripcion = _CI_Programacion.Resumen
                    _IndexImagen = 15

                Case "RecalculoPPP"

                    _Descripcion = _CI_Programacion.Resumen
                    _IndexImagen = 16

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

    Sub Sb_Timer_IntervaloCada(ByRef _Timer As Timer, ByRef _Sp_Programacion As Cl_NewProgramacion, Sb_Proceso As TimerCallback)

        _Timer = Nothing
        Dim horaProgramada As DateTime
        Dim tiempoRestante As TimeSpan

        With _Sp_Programacion

            Dim _IntervaloCada As Integer = .IntervaloCada

            If .SucedeCada Then

                If .TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                If .TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                If .TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)

                tiempoRestante = horaProgramada - DateTime.Now

            End If

            If .SucedeUnaVez Then

                Dim _Hora = .HoraUnaVez.Hour
                Dim _Minuto = .HoraUnaVez.Minute

                horaProgramada = DateTime.Today.AddHours(_Hora).AddMinutes(_Minuto)

                If horaProgramada < DateTime.Now Then
                    horaProgramada = horaProgramada.Date.AddDays(1).AddHours(_Hora).AddMinutes(_Minuto)
                End If

                tiempoRestante = horaProgramada - DateTime.Now

            End If

        End With

        _Timer = New Timer(Sb_Proceso, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub

    'Sub Sb_Imprimir_Documentos(state As Object)

    '    If IsNothing(_Timer_ImprimirDocumentos) Then Return

    '    If _Cl_Imprimir_Documentos.Procesando Or _Cl_FacturacionAuto.Procesando Then

    '        Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(2) 'DateTime.Now.AddMinutes(1)
    '        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

    '        _Timer_ImprimirDocumentos.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

    '        ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
    '        Dim registro As String = DateTime.Now.ToString() & " - Imprimir documentos (Proceso en curso se volverá a revisar en 2 segundos mas...)"

    '        ' Registrar la información en un archivo de registro
    '        RegistrarLog(registro)
    '        MostrarRegistro(registro)

    '        '_Cl_Imprimir_Documentos.Procesando = False

    '    Else

    '        _Cl_Imprimir_Documentos.Fecha_Revision = DtpFecharevision.Value
    '        _Cl_Imprimir_Documentos.Nombre_Equipo = _NombreEquipo
    '        _Cl_Imprimir_Documentos.Log_Registro = String.Empty
    '        _Cl_Imprimir_Documentos.Sb_Procedimiento_Cola_Impresion()

    '        Sb_Timer_IntervaloCada(_Timer_ImprimirDocumentos, _DProgramaciones.Sp_ColaImpDoc, AddressOf Sb_Imprimir_Documentos)
    '        'Sb_Timer_ImprimirDocumentos()

    '        Dim registro As String

    '        If Not String.IsNullOrWhiteSpace(_Cl_Imprimir_Documentos.Log_Registro) Then
    '            registro = "Tarea ejecutada (Imprimir documentos) a las: " & DateTime.Now.ToString()
    '            registro += vbCrLf & _Cl_Imprimir_Documentos.Log_Registro
    '        End If

    '        ' Registrar la información en un archivo de registro
    '        If Not String.IsNullOrWhiteSpace(registro) Then
    '            registro = registro.Trim
    '            RegistrarLog(registro)
    '            MostrarRegistro(registro)
    '        End If

    '    End If

    'End Sub

    Sub Sb_Imprimir_Picking(state As Object)

        If IsNothing(_Timer_ImprimirPicking) Then Return

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

    Sub Sb_Archivador(state As Object)

        If IsNothing(_Timer_Archivador) Then Return

        If _Cl_Archivador.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(2) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_Archivador.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Archivador (Proceso en curso se volverá a revisar en 2 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

        Else

            If String.IsNullOrEmpty(_Cl_Archivador.Ruta_Archivador) Then
                _Cl_Archivador.Ruta_Archivador = AppPath() & "\Data\" & RutEmpresa & "\Archivador"
                If Not Directory.Exists(_Cl_Archivador.Ruta_Archivador) Then
                    System.IO.Directory.CreateDirectory(_Cl_Archivador.Ruta_Archivador)
                End If
            End If

            _Cl_Archivador.Fecha_Revision = DtpFecharevision.Value
            _Cl_Archivador.Nombre_Equipo = _NombreEquipo
            _Cl_Archivador.Log_Registro = String.Empty
            _Cl_Archivador.Sb_Procedimiento_Archivar_Documentos(False)

            Sb_Timer_IntervaloCada(_Timer_Archivador, _DProgramaciones.Sp_ArchivarDoc, AddressOf Sb_Archivador)

            Dim registro As String = "Tarea ejecutada (Archivador) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Archivador.Log_Registro) Then
                registro += vbCrLf & _Cl_Archivador.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

        End If

    End Sub

    Sub Sb_ListasProgramadas(state As Object)

        If IsNothing(_Timer_ListasProgramadas) Then Return

        If _Cl_Listas_Programadas.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(2) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_ListasProgramadas.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Listas programadas a futuro (Proceso en curso se volverá a revisar en 2 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

        Else

            _Cl_Listas_Programadas.FechaProgramacion = DtpFecharevision.Value
            '_Cl_Listas_Programadas.Nombre_Equipo = _NombreEquipo
            _Cl_Listas_Programadas.Log_Registro = String.Empty
            _Cl_Listas_Programadas.Sb_Grabar_Listas_Programadas()

            Sb_Timer_IntervaloCada(_Timer_ListasProgramadas, _DProgramaciones.Sp_ListasProgramadas, AddressOf Sb_ListasProgramadas)

            Dim registro As String = "Tarea ejecutada (Listas programadas a futuro) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Listas_Programadas.Log_Registro) Then
                registro += vbCrLf & _Cl_Listas_Programadas.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

        End If

    End Sub

    Function Fx_CumpleDiaSemana(_Programacion As Cl_NewProgramacion) As Boolean

        Dim _Hoy As Date = DtpFecharevision.Value
        Dim _Dia = _Hoy.DayOfWeek

        If _Programacion.FrecuDiaria Then
            Return True
        End If

        If _Programacion.FrecuSemanal Then

            If (_Dia = DayOfWeek.Monday And _Programacion.Lunes) Or
                   (_Dia = DayOfWeek.Tuesday And _Programacion.Martes) Or
                   (_Dia = DayOfWeek.Wednesday And _Programacion.Miercoles) Or
                   (_Dia = DayOfWeek.Thursday And _Programacion.Jueves) Or
                   (_Dia = DayOfWeek.Friday And _Programacion.Viernes) Or
                   (_Dia = DayOfWeek.Saturday And _Programacion.Sabado) Or
                   (_Dia = DayOfWeek.Sunday And _Programacion.Domingo) Then
                Return True
            End If

        End If

    End Function

    Private Sub RegistrarLog(registro As String)
        If Me.WindowState = FormWindowState.Minimized Then Return
        Try
            Using writer As New StreamWriter(logFilePath, True)
                writer.WriteLine(registro)
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MostrarRegistro(registro As String)
        If Me.WindowState = FormWindowState.Minimized Then Return
        Try
            Txt_Log.Invoke(Sub() Txt_Log.AppendText(registro & Environment.NewLine))
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub Frm_Demonio_New_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Limpirar_Timers()
    End Sub

    Sub Sb_Limpirar_Timers()

        Circular_Monitoreo.IsRunning = False
        Lbl_Monitoreo.Text = "MONITOREO EN PAUSA"

        _Timer_Archivador = Nothing
        '_Timer_ImprimirDocumentos = Nothing
        _Timer_ImprimirPicking = Nothing
        _Timer_ListasProgramadas = Nothing
        _Timer_Prestashop_Orders = Nothing
        _Timer_Prestashop_Prod = Nothing
        _Timer_SolicitudProductosBodega = Nothing

        Timer_AsistenteCompras.Stop()
        Timer_CerrarDocumentos.Stop()
        Timer_ConsolidacionStock.Stop()
        Timer_Correo.Stop()
        Timer_Ejecuciones.Stop()
        Timer_Enviar_Doc_SinRecepcion.Stop()
        Timer_FacturacionAuto.Stop()
        Timer_LibroDTESII.Stop()
        Timer_Minimizar.Stop()
        Timer_PrestaShopWeb.Stop()

    End Sub

    Private Sub Btn_Configurar_Click(sender As Object, e As EventArgs) Handles Btn_Configurar.Click

        'Sb_Limpirar_Timers()

        Circular_Monitoreo.IsRunning = False
        Lbl_Monitoreo.Text = "MONITOREO EN PAUSA"

        _Timer_Archivador = Nothing
        '_Timer_ImprimirDocumentos = Nothing
        _Timer_ImprimirPicking = Nothing
        _Timer_ListasProgramadas = Nothing
        _Timer_Prestashop_Orders = Nothing
        _Timer_Prestashop_Prod = Nothing
        _Timer_SolicitudProductosBodega = Nothing


        ' Pausar timers activos y guardar su estado
        Dim timersActivos As New Dictionary(Of Object, Boolean) From {
                {Timer_AsistenteCompras, Timer_AsistenteCompras.Enabled},
                {Timer_CerrarDocumentos, Timer_CerrarDocumentos.Enabled},
                {Timer_ConsolidacionStock, Timer_ConsolidacionStock.Enabled},
                {Timer_Correo, Timer_Correo.Enabled},
                {Timer_Ejecuciones, Timer_Ejecuciones.Enabled},
                {Timer_Enviar_Doc_SinRecepcion, Timer_Enviar_Doc_SinRecepcion.Enabled},
                {Timer_FacturacionAuto, Timer_FacturacionAuto.Enabled},
                {Timer_LibroDTESII, Timer_LibroDTESII.Enabled},
                {Timer_Minimizar, Timer_Minimizar.Enabled},
                {Timer_PrestaShopWeb, Timer_PrestaShopWeb.Enabled},
                {Timer_NVVAutoExterna, Timer_NVVAutoExterna.Enabled},
                {Timer_ImprimirDocumentos, Timer_ImprimirDocumentos.Enabled},
                {Timer_RecalculoPPP, Timer_RecalculoPPP.Enabled}
            }


        For Each kvp In timersActivos
            If kvp.Value Then kvp.Key.Enabled = False
        Next

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

        Else

            Dim _CantidadFilas As Integer = Listv_Programaciones.Items.Count

            If CBool(_CantidadFilas) Then
                Lbl_Monitoreo.Text = "MONITOREO ACTIVO"
                Circular_Monitoreo.IsRunning = True
            End If

            ' Restaurar timers que estaban activos
            For Each kvp In timersActivos
                If kvp.Value Then kvp.Key.Enabled = True
            Next

            If _DProgramaciones.Sp_ArchivarDoc.Activo Then
                Sb_Timer_IntervaloCada(_Timer_Archivador, _DProgramaciones.Sp_ArchivarDoc, AddressOf Sb_Archivador)
            End If
            If _DProgramaciones.Sp_ColaImpPick.Activo Then
                Sb_Timer_IntervaloCada(_Timer_ImprimirPicking, _DProgramaciones.Sp_ColaImpPick, AddressOf Sb_Imprimir_Picking)
            End If

            If _DProgramaciones.Sp_ListasProgramadas.Activo Then
                Sb_Timer_IntervaloCada(_Timer_ListasProgramadas, _DProgramaciones.Sp_ListasProgramadas, AddressOf Sb_ListasProgramadas)
            End If

            If _DProgramaciones.Sp_Prestashop_Order.Activo Then
                Sb_Timer_IntervaloCada(_Timer_Prestashop_Orders, _DProgramaciones.Sp_Prestashop_Order, AddressOf Sb_Prestashop_Orders)
            End If

            If _DProgramaciones.Sp_Prestashop_Prod.Activo Then
                Sb_Activar_ObjetosTimer(Timer_PrestaShopWeb, _DProgramaciones.Sp_Prestashop_Prod)
            End If

            If _DProgramaciones.Sp_SolProdBod.Activo Then
                Sb_Timer_IntervaloCada(_Timer_SolicitudProductosBodega, _DProgramaciones.Sp_ColaImpPick, AddressOf Sb_Solicitud_Productos_Bodega)
            End If


            Me.Refresh()

        End If

    End Sub

    Private Sub timerHora_Tick(sender As Object, e As EventArgs) Handles timerHora.Tick

        Me.Text = "Demonio para acciones automatizadas, V: [" & _Version_BkSpecialPrograms & "] " & DateTime.Now.ToString("HH:mm:ss")

        If _Cl_Prestashop_Prod.Procesando Then
            Sb_ActualizarDetalleListview("Prestashop Web", _Cl_Prestashop_Prod.Etiqueta2.Text)
        End If

        If _Cl_Hefesto_Dte_Libro.Procesando Then
            Sb_ActualizarDetalleListview("Importar DTE SII", _Cl_Hefesto_Dte_Libro.Estatus.Text)
        End If

        If _Cl_Correos.Procesando Then
            Sb_ActualizarDetalleListview("Envio de correos", _Cl_Correos.Lbl_Estado)
        End If

        If _Cl_FacturacionAuto.Procesando Then
            Sb_ActualizarDetalleListview("Facturación automática", _Cl_FacturacionAuto.Log_Registro)
        End If

        Me.Refresh()

    End Sub

    Private Sub Timer_PrestaShopWeb_Tick(sender As Object, e As EventArgs) Handles Timer_PrestaShopWeb.Tick
        _Cl_Prestashop_Prod.Ejecutar = True
    End Sub

    Private Sub Timer_LibroDTESII_Tick(sender As Object, e As EventArgs) Handles Timer_LibroDTESII.Tick
        _Cl_Hefesto_Dte_Libro.Ejecutar = True
    End Sub

    Sub Sb_ActualizarDetalleListview(_Codigo As String, _Descripcion As String)

        For Each item As ListViewItem In Listv_Programaciones.Items
            If item.Text = _Codigo Then
                item.SubItems(1).Text = _Descripcion
                Exit For
            End If
        Next

    End Sub

    Sub Sb_Actualizar_Fecha()

        Dim _Fecha_Computador As Date = FormatDateTime(Now.Date, DateFormat.ShortDate)
        Dim _Fecha_Dtp As Date = FormatDateTime(DtpFecharevision.Value, DateFormat.ShortDate)

        If Me.WindowState = FormWindowState.Minimized Then

            If _Fecha_Computador <> _Fecha_Dtp Then

                DtpFecharevision.Value = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            End If

        End If

    End Sub

    Sub Sb_Pausa(_Pausa As Boolean)

        If _DProgramaciones.Sp_Prestashop_Prod.Activo Then
            Timer_PrestaShopWeb.Enabled = _Pausa
        End If

        If _DProgramaciones.Sp_ImporDTESII.Activo Then
            Timer_LibroDTESII.Enabled = _Pausa
        End If

        If _DProgramaciones.Sp_ConsStock.Activo Then
            Timer_ConsolidacionStock.Enabled = _Pausa
        End If

        If _DProgramaciones.Sp_CierreDoc.Activo Then
            Timer_CerrarDocumentos.Enabled = _Pausa
        End If

        If _DProgramaciones.Sp_AsistenteCompras.Activo Then
            Timer_AsistenteCompras.Enabled = _Pausa
        End If

        If _DProgramaciones.Sp_EnvioCorreo.Activo Then
            Timer_Correo.Enabled = _Pausa
        End If

        If _DProgramaciones.Sp_FacturacionAuto.Activo Then
            Timer_FacturacionAuto.Enabled = _Pausa
        End If

        Timer_Minimizar.Enabled = _Pausa

    End Sub

    Private Sub BtnCambFecha_Click(sender As Object, e As EventArgs) Handles BtnCambFecha.Click
        If Fx_Tiene_Permiso(Me, "Pick0007") Then
            DtpFecharevision.Enabled = True
        End If
    End Sub

    Private Sub Timer_ConsolidacionStock_Tick(sender As Object, e As EventArgs) Handles Timer_ConsolidacionStock.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_ConsStock) Then
            _Cl_Consolidacion_Stock.Ejecutar = True
        End If
    End Sub

    Private Sub Timer_CerrarDocumentos_Tick(sender As Object, e As EventArgs) Handles Timer_CerrarDocumentos.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_CierreDoc) Then
            _Cl_CerrarDocumentos.Ejecutar = True
        End If
    End Sub

    Private Sub Timer_AsistenteCompras_Tick(sender As Object, e As EventArgs) Handles Timer_AsistenteCompras.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_AsistenteCompras) Then
            _Cl_Asistente_Compras.Ejecutar = True
        Else
            Sb_Activar_ObjetosTimer(Timer_AsistenteCompras, _DProgramaciones.Sp_AsistenteCompras)
        End If
    End Sub

    Private Sub Timer_Correo_Tick(sender As Object, e As EventArgs) Handles Timer_Correo.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_EnvioCorreo) Then
            _Cl_Correos.Ejecutar = True
        End If
    End Sub

    Private Sub Timer_FacturacionAuto_Tick(sender As Object, e As EventArgs) Handles Timer_FacturacionAuto.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_FacturacionAuto) Then
            _Cl_FacturacionAuto.Ejecutar = True
        End If
    End Sub

    Private Sub Timer_Minimizar_Tick(sender As Object, e As EventArgs) Handles Timer_Minimizar.Tick
        If Timer_Ejecuciones.Enabled Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub Timer_Ejecuciones_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecuciones.Tick

        Timer_Ejecuciones.Stop()

        Sb_Actualizar_Fecha()

#Region "IMPRIMIR DOCUMENTOS"

        If _Cl_Imprimir_Documentos.Ejecutar Then

            If Not _Cl_Imprimir_Documentos.Procesando Then

                _Cl_Imprimir_Documentos.Fecha_Revision = DtpFecharevision.Value
                _Cl_Imprimir_Documentos.Nombre_Equipo = _NombreEquipo
                _Cl_Imprimir_Documentos.Log_Registro = String.Empty
                _Cl_Imprimir_Documentos.Sb_Procedimiento_Cola_Impresion()

                Dim registro As String

                If Not String.IsNullOrWhiteSpace(_Cl_Imprimir_Documentos.Log_Registro) Then
                    registro = "Tarea ejecutada (Imprimir documentos) a las: " & DateTime.Now.ToString()
                    registro += vbCrLf & _Cl_Imprimir_Documentos.Log_Registro
                End If

                ' Registrar la información en un archivo de registro
                If Not String.IsNullOrWhiteSpace(registro) Then
                    registro = registro.Trim
                    RegistrarLog(registro)
                    MostrarRegistro(registro)
                End If

            End If

            _Cl_Imprimir_Documentos.Ejecutar = False

        End If

#End Region

#Region "ENVIO DE CORREOS"

        If _Cl_Correos.Ejecutar Then

            Sb_ActualizarDetalleListview("Envio de correos", "A la espera de procesar los envíos...")

            If Not _Cl_Correos.Procesando Then

                If _Global_Row_Configuracion_General.Item("UsarVencListaPrecios") Then

                    If _Cl_Correos.ActualizarListaMayoristaMinorista Then

                        Dim _Cl_ListaMayoristaMinorista As New Cl_ListaMayoristaMinorista
                        _Cl_ListaMayoristaMinorista.Sb_LlenarCorreosNuevosMayoristas(_Cl_Correos.CorreoMayoristaMinorista, DtpFecharevision.Value)

                    End If

                End If

                _Cl_Correos.Procesando = True
                _Cl_Correos.Fecha_Revision = DtpFecharevision.Value
                _Cl_Correos.Nombre_Equipo = _NombreEquipo
                _Cl_Correos.Sb_Procedimiento_Correos()

                Dim registro As String

                If Not String.IsNullOrEmpty(_Cl_Correos.Lbl_Estado) Then

                    registro = _Cl_Correos.Lbl_Estado
                    RegistrarLog(registro)

                End If

                registro = "Tarea ejecutada (Correo) a las: " & DateTime.Now.ToString()

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_Correos.Ejecutar = False
                _Cl_Correos.Procesando = False

                Sb_ActualizarDetalleListview("Envio de correos", _DProgramaciones.Sp_EnvioCorreo.Resumen)

            End If

        End If

#End Region

#Region "CONSOLIDACION DE STOCK"

        If _Cl_Consolidacion_Stock.Ejecutar Then

            If Not _Cl_Consolidacion_Stock.Procesando Then

                _Cl_Consolidacion_Stock.Procesando = True

                Dim registro As String = "Ejecutando tarea Consolidación de stock a las: " & DateTime.Now.ToString()

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_Consolidacion_Stock.Log_Registro = String.Empty
                _Cl_Consolidacion_Stock.Fecha_Revision = DtpFecharevision.Value

                Consulta_sql = "Select EMPRESA From CONFIGP"
                Dim _Tbl_Configp As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Row As DataRow In _Tbl_Configp.Rows
                    Dim _Empresa = _Row.Item("EMPRESA")
                    _Cl_Consolidacion_Stock.Sb_Procedimiento_Consolidar_Stock(Me, _Empresa)
                Next

                registro = "Tarea ejecutada (Consolidación de stock) a las: " & DateTime.Now.ToString()
                registro += _Cl_Consolidacion_Stock.Log_Registro & vbCrLf
                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_Consolidacion_Stock.Procesando = False
                _Cl_Consolidacion_Stock.Ejecutar = False

                Sb_Activar_ObjetosTimer(_Timer_ConsolidacionStock, _DProgramaciones.Sp_ConsStock)

            End If

        End If

#End Region

#Region "FACTURACION AUTOMATICA"

        If _Cl_FacturacionAuto.Ejecutar Then

            If Not _Cl_FacturacionAuto.Procesando AndAlso Not _Cl_Imprimir_Documentos.Procesando Then

                _Cl_FacturacionAuto.Procesando = True

                _Cl_FacturacionAuto.Log_Registro = String.Empty
                _Cl_FacturacionAuto.Fecha_Revision = DtpFecharevision.Value
                _Cl_FacturacionAuto.Nombre_Equipo = _NombreEquipo
                _Cl_FacturacionAuto.Log_Registro = String.Empty

                Dim _Empresa_Ori = Mod_Empresa
                Dim _Modalidad_Ori = Mod_Modalidad

                If RutEmpresa = "76095906-5" Then
                    'MessageBox.Show("Se cambiará la empresa y modalidad a la de facturación automática", "Atención",
                    '                MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Cl_FacturacionAuto.Sb_Cambiar_EmpSucBod()
                    'Me.Close()
                    'Return
                End If

                _Cl_FacturacionAuto.Sb_Traer_NVV_De_NVVAuto_A_Facturar()
                _Cl_FacturacionAuto.Sb_Traer_NVV_A_Facturar()
                _Cl_FacturacionAuto.Sb_Traer_NVV_De_Picking_A_Facturar()

                _Cl_FacturacionAuto.Sb_Facturar_Automaticamente_NVV_New(Me, Nothing)
                _Cl_FacturacionAuto.Sb_Pagar_Documentos()

                Dim registro As String = "Tarea ejecutada (Facturación automática) a las: " & DateTime.Now.ToString()

                If Not String.IsNullOrWhiteSpace(_Cl_FacturacionAuto.Log_Registro) Then
                    registro += vbCrLf & _Cl_FacturacionAuto.Log_Registro
                End If


                If RutEmpresa = "76095906-5" Then
                    Dim _Mod As New Clas_Modalidades
                    _Mod.Sb_Actualiza_Formatos_X_Modalidad(False)
                    _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "", False, _Empresa_Ori)
                    _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, _Modalidad_Ori, False, _Empresa_Ori)
                    _Mod.Sb_Actualizar_Variables_Modalidad(_Modalidad_Ori, False, _Empresa_Ori)
                End If

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_FacturacionAuto.Procesando = False
                _Cl_FacturacionAuto.Ejecutar = False

                Sb_ActualizarDetalleListview("Facturación automática", _DProgramaciones.Sp_FacturacionAuto.Resumen)

            End If

        End If

#End Region

#Region "CIERRE DE DOCUMENTOS"

        If _Cl_CerrarDocumentos.Ejecutar Then

            If Not _Cl_CerrarDocumentos.Procesando Then

                _Cl_CerrarDocumentos.Procesando = True

                Dim registro As String = "Ejecutando tarea cierre de documentos a las: " & DateTime.Now.ToString()

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_CerrarDocumentos.Fecha_Revision = DtpFecharevision.Value

                _Cl_CerrarDocumentos.Sb_Procedimientos_Cierre_Masivo_Documentos_New(Me, "COV")
                registro += _Cl_CerrarDocumentos.Log_Registro
                _Cl_CerrarDocumentos.Sb_Procedimientos_Cierre_Masivo_Documentos_New(Me, "NVI")
                registro += _Cl_CerrarDocumentos.Log_Registro
                _Cl_CerrarDocumentos.Sb_Procedimientos_Cierre_Masivo_Documentos_New(Me, "NVV")
                registro += _Cl_CerrarDocumentos.Log_Registro
                _Cl_CerrarDocumentos.Sb_Procedimientos_Cierre_Masivo_Documentos_New(Me, "OCI")
                registro += _Cl_CerrarDocumentos.Log_Registro
                _Cl_CerrarDocumentos.Sb_Procedimientos_Cierre_Masivo_Documentos_New(Me, "OCC")
                registro += _Cl_CerrarDocumentos.Log_Registro

                _Cl_CerrarDocumentos.Fecha_Revision = DtpFecharevision.Value

                _Cl_CerrarDocumentos.Sb_Procedimientos_Envio_Correos(Me, "NVV")
                registro += _Cl_CerrarDocumentos.Log_Registro

                registro += "Tarea ejecutada correctamente (Cierre de documentos) a las: " & DateTime.Now.ToString()

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_CerrarDocumentos.Procesando = False
                _Cl_CerrarDocumentos.Ejecutar = False

                Sb_Activar_ObjetosTimer(Timer_CerrarDocumentos, _DProgramaciones.Sp_CierreDoc)

            End If

        End If

#End Region

#Region "HEFESTO DTE LIBROS DESDE EL SII"

        If _Cl_Hefesto_Dte_Libro.Ejecutar Then

            If Not _Cl_Hefesto_Dte_Libro.Procesando Then

                _Cl_Hefesto_Dte_Libro.Procesando = True

                Dim _Lbl As New Label
                _Cl_Hefesto_Dte_Libro.Estatus = _Lbl

                Dim Fm As New Frm_Recibir_Correos_DTE
                Fm.ActivacionAutomatica = True
                Fm.ShowDialog(Me)
                Fm.Dispose()

                Dim _Fecha As Date = DtpFecharevision.Value
                Dim _Fecha_Anterior As Date = DateAdd(DateInterval.Month, -1, _Fecha)

                Dim _Periodo = _Fecha.Year
                Dim _Mes = _Fecha.Month
                Dim _Reenviar_Documentos_al_SII = False
                Dim _periodo2 As String = _Periodo & "-" & Fx_Rellena_ceros(_Mes, 2)

                Dim _Directorio_SIIRegCV = Application.StartupPath & "\SIIRegCV\SIIRegCV.exe"
                Dim _Directorio_Error = Application.StartupPath & "\SIIRegCV\Empresas\Errores.txt"
                Dim _Ejecutar As String = _Directorio_SIIRegCV & Space(1) & "" & _periodo2 & " " & RutEmpresa
                Dim _Registro As String = String.Empty

                Dim _Ejecutar_SIIRegCv As Boolean = True

                If Not File.Exists(_Directorio_SIIRegCV) Then
                    _Registro = "No se encuentra el archivo requerido: " & _Directorio_SIIRegCV
                    RegistrarLog(_Registro)
                    MostrarRegistro(_Registro)
                    _Cl_Hefesto_Dte_Libro.Procesando = False
                    _Cl_Hefesto_Dte_Libro.Ejecutar = False
                    Sb_ActualizarDetalleListview("Importar DTE SII", _DProgramaciones.Sp_ImporDTESII.Resumen)
                    _Ejecutar_SIIRegCv = False
                End If

                Dim _EjecucionSinProblemas As Boolean

                If _Ejecutar_SIIRegCv Then

                    _Registro = "Recuperando los registros de compras desde el SII..."

                    Try
                        Shell(_Ejecutar, AppWinStyle.NormalFocus, True)
                        _EjecucionSinProblemas = True
                    Catch ex As Exception
                        _Registro = ex.Message
                        RegistrarLog(_Registro)
                        MostrarRegistro(_Registro)
                        _Cl_Hefesto_Dte_Libro.Procesando = False
                        _Cl_Hefesto_Dte_Libro.Ejecutar = False
                        Sb_ActualizarDetalleListview("Importar DTE SII", _DProgramaciones.Sp_ImporDTESII.Resumen)
                    End Try

                    ' Verificar si existe el archivo de error y mostrar alerta
                    If File.Exists(_Directorio_Error) Then
                        Dim mensajeError As String = File.ReadAllText(_Directorio_Error)
                        _Registro = "Se detectó un error al ejecutar SIIRegCV:" & vbCrLf & mensajeError
                        'MessageBoxEx.Show(Me, "Se detectó un error al ejecutar SIIRegCV:" & vbCrLf & mensajeError, "Error SIIRegCV", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        _EjecucionSinProblemas = False
                        RegistrarLog("Error SIIRegCV: " & mensajeError)
                        MostrarRegistro("Error SIIRegCV: " & mensajeError)
                        _Cl_Hefesto_Dte_Libro.Procesando = False
                        _Cl_Hefesto_Dte_Libro.Ejecutar = False
                        Sb_ActualizarDetalleListview("Importar DTE SII", _DProgramaciones.Sp_ImporDTESII.Resumen)
                    End If

                End If

                If _EjecucionSinProblemas Then

                    Dim _Dir_ComprasRegistro As String = Application.StartupPath & "\SIIRegCV\Empresas\" & RutEmpresa & "\Resultados\Compras\" & _periodo2 & "\RegistrosCompras.json"
                    Dim _Dir_ComprasRegistroPendientes As String = Application.StartupPath & "\SIIRegCV\Empresas\" & RutEmpresa & "\Resultados\Compras\" & _periodo2 & "\RegistrosComprasPendientes.json"

                    Dim _Tbl_Registro_Compras As DataTable
                    Dim _Tbl_Registro_Compras_Pendientes As DataTable

                    If File.Exists(_Dir_ComprasRegistro) Then
                        Dim _Fichero1 As String = File.ReadAllText(_Dir_ComprasRegistro)
                        ' Convierte el contenido JSON de _Fichero1 a un DataSet usando Newtonsoft.Json
                        Dim _DataSet As New DataSet()
                        _DataSet = JsonConvert.DeserializeObject(Of DataSet)(_Fichero1)
                        _Tbl_Registro_Compras = _DataSet.Tables("RegistroCompras")
                    Else
                        _Tbl_Registro_Compras = Nothing
                    End If

                    If File.Exists(_Dir_ComprasRegistroPendientes) Then
                        Dim _Fichero1 As String = File.ReadAllText(_Dir_ComprasRegistroPendientes)
                        ' Convierte el contenido JSON de _Fichero1 a un DataSet usando Newtonsoft.Json
                        Dim _DataSet As New DataSet()
                        _DataSet = JsonConvert.DeserializeObject(Of DataSet)(_Fichero1)
                        _Tbl_Registro_Compras_Pendientes = _DataSet.Tables("RegistroCompras")
                    Else
                        _Tbl_Registro_Compras_Pendientes = Nothing
                    End If

                    _Cl_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_Json(_Tbl_Registro_Compras,
                                                                                     _Tbl_Registro_Compras_Pendientes,
                                                                                     _Periodo, _Mes)

                    Sb_ActualizarDetalleListview("Importar DTE SII", _DProgramaciones.Sp_ImporDTESII.Resumen)

                End If

                _Cl_Hefesto_Dte_Libro.Procesando = False
                _Cl_Hefesto_Dte_Libro.Ejecutar = False

            End If

        End If

        'If _Cl_Hefesto_Dte_Libro.Ejecutar Then

        '    If Not _Cl_Hefesto_Dte_Libro.Procesando Then

        '        _Cl_Hefesto_Dte_Libro.Procesando = True

        '        Dim _Lbl As New Label
        '        _Cl_Hefesto_Dte_Libro.Estatus = _Lbl

        '        Dim Fm As New Frm_Recibir_Correos_DTE
        '        Fm.ActivacionAutomatica = True
        '        Fm.ShowDialog(Me)
        '        Fm.Dispose()

        '        Dim _Fecha As Date = DtpFecharevision.Value
        '        Dim _Fecha_Anterior As Date = DateAdd(DateInterval.Month, -1, _Fecha)

        '        Dim _Periodo = _Fecha.Year
        '        Dim _Mes = _Fecha.Month
        '        Dim _Reenviar_Documentos_al_SII = False

        '        'Dim _RecuperarResumenVentasRegistro As HefRespuesta
        '        'Dim _RecuperarVentasRegistro As HefRespuesta
        '        'Dim _RecuperarResumenCompras As HefRespuesta
        '        Dim _RecuperarComprasRegistro As HefRespuesta
        '        Dim _RecuperarComprasPendientes As HefRespuesta
        '        'Dim _RecuperarComprasNoIncluir As HefRespuesta
        '        'Dim _RecuperarComprasReclamadas As HefRespuesta

        '        Dim _Registro As String

        '        _Registro = "Recuperando los registros de compras desde el SII..."

        '        Sb_ActualizarDetalleListview("Importar DTE SII", _Registro)

        '        Application.DoEvents()

        '        _RecuperarComprasRegistro = _Cl_Hefesto_Dte_Libro.Fx_RecuperarComprasRegistro(_Periodo, _Mes)
        '        Thread.Sleep(2000)
        '        _Registro = "Es correcto: " & _RecuperarComprasRegistro.EsCorrecto
        '        Application.DoEvents()
        '        Thread.Sleep(2000)
        '        _Registro = "Mensaje    : " & _RecuperarComprasRegistro.Mensaje
        '        Application.DoEvents()

        '        _RecuperarComprasPendientes = _Cl_Hefesto_Dte_Libro.Fx_RecuperarComprasPendientes(_Periodo, _Mes)
        '        Thread.Sleep(2000)
        '        _Registro = "Es correcto: " & _RecuperarComprasPendientes.EsCorrecto
        '        Application.DoEvents()
        '        Thread.Sleep(2000)
        '        _Registro = "Mensaje    : " & _RecuperarComprasPendientes.Mensaje
        '        Application.DoEvents()

        '        RegistrarLog(_Registro)
        '        MostrarRegistro(_Registro)

        '        If _RecuperarComprasRegistro.EsCorrecto And _RecuperarComprasPendientes.EsCorrecto Then

        '            Dim _Fichero1 As String = File.ReadAllText(_RecuperarComprasRegistro.Directorio)
        '            Dim _Fichero2 As String = File.ReadAllText(_RecuperarComprasPendientes.Directorio)

        '            Dim _Tbl_Registro_Compras As DataTable = Fx_TblFromJson(_Fichero1, "RegistroCompras")
        '            Dim _Tbl_Registro_Compras_Pendientes As DataTable = Fx_TblFromJson(_Fichero2, "RegistroComprasPendientes")

        '            Thread.Sleep(2000)

        '            _Cl_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_Json(_Tbl_Registro_Compras,
        '                                                                  _Tbl_Registro_Compras_Pendientes,
        '                                                                  _Periodo, _Mes)

        '            'Lbl_LibroDTESII.Text = "Monitoreo Libro DTE desde SII"
        '        Else
        '            _Registro = "Problema al descargar los archivos desde el SII" & vbCrLf & _RecuperarComprasRegistro.Mensaje & "-" & _RecuperarComprasRegistro.Detalle
        '            RegistrarLog(_Registro)
        '            MostrarRegistro(_Registro)
        '        End If

        '        _Cl_Hefesto_Dte_Libro.Procesando = False
        '        _Cl_Hefesto_Dte_Libro.Ejecutar = False

        '        Sb_ActualizarDetalleListview("Importar DTE SII", _DProgramaciones.Sp_ImporDTESII.Resumen)

        '    End If

        'End If

#End Region

#Region "PRESTASHOP WEB"

        If _Cl_Prestashop_Prod.Ejecutar Then

            If Not _Cl_Prestashop_Prod.Procesando Then

                _Cl_Prestashop_Prod.Procesando = True

                Dim registro As String = "Ejecutando tarea Prestashop Web a las: " & DateTime.Now.ToString()

                RegistrarLog(registro)
                MostrarRegistro(registro)

                'Lbl_Procesando.Text = "Inicio de proceso de Prestashop Web..."

                _Cl_Prestashop_Prod.Fecha_Revision = DtpFecharevision.Value
                _Cl_Prestashop_Prod.Nombre_Equipo = _NombreEquipo
                _Cl_Prestashop_Prod.Log_Registro = String.Empty

                _Cl_Prestashop_Prod.Procesando = True

                Dim _Cons_Stock_Mov_Hoy As Boolean = _Cl_Consolidacion_Stock.Cons_Stock_Mov_Hoy
                Dim _Cons_Stock_Todos As Boolean = _Cl_Consolidacion_Stock.Cons_Stock_Todos

                _Cl_Consolidacion_Stock.Cons_Stock_Mov_Hoy = True
                _Cl_Consolidacion_Stock.Sb_Procedimiento_Consolidar_Stock(Me, Mod_Empresa)

                _Cl_Consolidacion_Stock.Cons_Stock_Mov_Hoy = _Cons_Stock_Mov_Hoy
                _Cl_Consolidacion_Stock.Cons_Stock_Todos = _Cons_Stock_Todos

                _Cl_Prestashop_Prod.Sb_Procedimiento_Prestashop()
                _Cl_Prestashop_Prod.Sb_Procedimiento_Prestashop3()

                registro = "Tarea ejecutada (Prestashop Productos Web) a las: " & DateTime.Now.ToString()

                If Not String.IsNullOrWhiteSpace(_Cl_Prestashop_Prod.Log_Registro) Then
                    registro += vbCrLf & _Cl_Prestashop_Prod.Log_Registro

                    ' Registrar la información en un archivo de registro
                End If

                RegistrarLog(registro)
                MostrarRegistro(registro)

                Timer_PrestaShopWeb.Start()

                _Cl_Prestashop_Prod.Ejecutar = False
                _Cl_Prestashop_Prod.Procesando = False

                Sb_ActualizarDetalleListview("Prestashop Web", _DProgramaciones.Sp_Prestashop_Prod.Resumen)

            End If

        End If

#End Region

#Region "ASISTENTE DE COMPRAS"

        If _Cl_Asistente_Compras.Ejecutar Then

            If Not _Cl_Asistente_Compras.Procesando Then

                _Cl_Asistente_Compras.Procesando = True

                Dim registro As String = "Ejecutando asistente de compras a las: " & DateTime.Now.ToString()

                RegistrarLog(registro)
                MostrarRegistro(registro)

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'" & vbCrLf &
                               "Order By NVI Desc,OCC_Star Desc"
                Dim _Tbl_ConfAcpAuto As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila As DataRow In _Tbl_ConfAcpAuto.Rows

                    Dim _Id_Padre As Integer = _Fila.Item("Id")
                    Dim _Grb_Programacion As New Grb_Programacion
                    Dim _CI_Programacion As Cl_NewProgramacion

                    Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id",
                                                           "NombreEquipo = '" & _NombreEquipo & "' And Id_Padre = " & _Id_Padre)
                    _CI_Programacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

                    If Fx_CumpleDiaSemana(_CI_Programacion) Then

                        Dim _NVI As Boolean = _Fila.Item("NVI")
                        Dim _OCC_Star As Boolean = _Fila.Item("OCC_Star")
                        Dim _OCC_Prov As Boolean = _Fila.Item("OCC_Prov")

                        Dim _ModalidadOld As String = Mod_Modalidad
                        Dim _Mod As New Clas_Modalidades

                        Mod_Modalidad = _Fila.Item("Modalidad")

                        _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
                        _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Mod_Modalidad)
                        _Mod.Sb_Actualizar_Variables_Modalidad(Mod_Modalidad)
                        _Mod.Sb_Actualiza_Formatos_X_Modalidad()

                        If _NVI Then _Cl_Asistente_Compras.Sb_Ejecutar(Me, Mod_Modalidad, False, True, False, False, True)
                        If _OCC_Star Then _Cl_Asistente_Compras.Sb_Ejecutar(Me, Mod_Modalidad, True, False, False, True, False)
                        If _OCC_Prov Then _Cl_Asistente_Compras.Sb_Ejecutar(Me, Mod_Modalidad, True, False, True, False, False)

                        Mod_Modalidad = _ModalidadOld

                        _Mod = New Clas_Modalidades
                        _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
                        _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Mod_Modalidad)
                        _Mod.Sb_Actualizar_Variables_Modalidad(Mod_Modalidad)
                        _Mod.Sb_Actualiza_Formatos_X_Modalidad()

                    End If

                Next

                registro = "Tarea ejecutada (Asistente de compras) a las: " & DateTime.Now.ToString()
                registro += _Cl_Consolidacion_Stock.Log_Registro & vbCrLf

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_Asistente_Compras.Procesando = False
                _Cl_Asistente_Compras.Ejecutar = False

                Sb_Activar_ObjetosTimer(Timer_AsistenteCompras, _DProgramaciones.Sp_AsistenteCompras)

            End If

        End If

#End Region

#Region "DOCUMENTOS SIN RECEPCIONAR"

        If _Cl_Enviar_Doc_SinRecepcion.Ejecutar Then

            If Not _Cl_Enviar_Doc_SinRecepcion.Precesando Then

                _Cl_Enviar_Doc_SinRecepcion.Precesando = True

                _Cl_Enviar_Doc_SinRecepcion.Sb_Procesar_Informe(DtpFecharevision.Value)

                If _Cl_Enviar_Doc_SinRecepcion.Crear_Html.EsCorrecto Then

                    Dim _Para = _Cl_Enviar_Doc_SinRecepcion.Para
                    Dim _Id_Correo = _Cl_Enviar_Doc_SinRecepcion.Id_Correo
                    Dim _RutaArchivo = _Cl_Enviar_Doc_SinRecepcion.Crear_Html.RutaArchivo

                    _Cl_Enviar_Doc_SinRecepcion.Fx_EnviarNotificacionCorreoAlDiablito(_Para, "", _Id_Correo, _RutaArchivo)

                End If

                _Cl_Enviar_Doc_SinRecepcion.Precesando = False
                _Cl_Enviar_Doc_SinRecepcion.Ejecutar = False

                Sb_Activar_ObjetosTimer(Timer_Enviar_Doc_SinRecepcion, _DProgramaciones.Sp_EnviarDocSinRecepcion)

            End If

        End If

#End Region

#Region "CREACION DE NVV AUTOMATICAS EXTERNAS"

        If _Cl_NVVAutoExterna.Ejecutar Then

            If Not _Cl_NVVAutoExterna.Procesando Then

                _Cl_NVVAutoExterna.Sb_Procesar_NVV(Me)

                Dim registro As String = "Tarea ejecutada (Notas de ventas externas) a las: " & DateTime.Now.ToString()

                If Not String.IsNullOrWhiteSpace(_Cl_NVVAutoExterna.Log_Registro) Then
                    registro += vbCrLf & _Cl_NVVAutoExterna.Log_Registro
                End If

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_NVVAutoExterna.Procesando = False
                _Cl_NVVAutoExterna.Ejecutar = False

                Sb_ActualizarDetalleListview("Notas de venta externas", _DProgramaciones.Sp_NVVExterna.Resumen)

            End If

        End If

#End Region

#Region "RECALCULO DEL PRECIO PROMEDIO PONDERADO"

        If _Cl_RecalculoPPP.Ejecutar Then

            If Not _Cl_RecalculoPPP.Procesando Then

                _Cl_RecalculoPPP.Procesando = True

                Dim registro As String = "Ejecutando tarea recalculo de PPP a las: " & DateTime.Now.ToString()

                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_RecalculoPPP.Log_Registro = String.Empty

                Consulta_sql = "Select EMPRESA From CONFIGP"
                Dim _Tbl_Configp As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Row As DataRow In _Tbl_Configp.Rows
                    Dim _Empresa = _Row.Item("EMPRESA")
                    _Cl_RecalculoPPP.Sb_RecalcularPPP(Me, _Empresa)
                Next


                registro = "Tarea ejecutada (Recalculo del PPP) a las: " & DateTime.Now.ToString()
                registro += _Cl_RecalculoPPP.Log_Registro & vbCrLf
                RegistrarLog(registro)
                MostrarRegistro(registro)

                _Cl_RecalculoPPP.Procesando = False
                _Cl_RecalculoPPP.Ejecutar = False

                Sb_Activar_ObjetosTimer(Timer_RecalculoPPP, _DProgramaciones.Sp_RecalculoPPP)

            End If

        End If

#End Region

        Timer_Ejecuciones.Start()

    End Sub

    Private Sub Timer_Enviar_Doc_SinRecepcion_Tick(sender As Object, e As EventArgs) Handles Timer_Enviar_Doc_SinRecepcion.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_EnviarDocSinRecepcion) Then
            _Cl_Enviar_Doc_SinRecepcion.Ejecutar = True
        End If
    End Sub

    Private Sub Frm_Demonio_New_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Not CambioDeConfiguracion AndAlso CBool(Listv_Programaciones.Items.Count) Then

            Dim _Validar As Boolean

            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
            Fm.Pro_Cerrar_Automaticamente = True
            Fm.ShowDialog(Me)
            _Validar = Fm.Pro_Permiso_Aceptado
            Fm.Dispose()

            If Not _Validar Then
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub Frm_Demonio_New_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        If Me.WindowState <> FormWindowState.Minimized Then

            Timer_Minimizar.Stop()

            Dim tiempo As New TimeSpan(0, 5, 0)
            Dim milisegundos = tiempo.TotalMilliseconds

            Timer_Minimizar.Interval = milisegundos
            Timer_Minimizar.Start()

        End If

    End Sub

    Private Sub Timer_NVVAutoExterna_Tick(sender As Object, e As EventArgs) Handles Timer_NVVAutoExterna.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_NVVExterna) Then
            _Cl_NVVAutoExterna.Ejecutar = True
        End If
    End Sub

    Private Sub Timer_ImprimirDocumentos_Tick(sender As Object, e As EventArgs) Handles Timer_ImprimirDocumentos.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_ColaImpDoc) Then
            _Cl_Imprimir_Documentos.Ejecutar = True
        End If
    End Sub

    Private Sub Timer_RecalculoPPP_Tick(sender As Object, e As EventArgs) Handles Timer_RecalculoPPP.Tick
        If Fx_CumpleDiaSemana(_DProgramaciones.Sp_RecalculoPPP) Then
            _Cl_RecalculoPPP.Ejecutar = True
        End If
    End Sub
End Class
