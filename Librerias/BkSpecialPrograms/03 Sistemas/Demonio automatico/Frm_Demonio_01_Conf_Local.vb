﻿Imports DevComponents.DotNetBar

Public Class Frm_Demonio_01_Conf_Local

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Datos_Conf As New Ds_Config_Picking
    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"

    Dim _NombreEquipo As String
    Dim _Funcionario_Autorizado As String
    Dim _Cambiar_Usuario_X_Defecto As Boolean

    Dim _Ruta_Archivador As String

    Dim _Directorio = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
    Dim _Dir_Correo_Imagenes = _Directorio & "\Correo\Imagenes"

    Public Sub New(Funcionario_Autorizado As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Funcionario_Autorizado = Funcionario_Autorizado

    End Sub

    Public Property Cambiar_Usuario_X_Defecto As Boolean
        Get
            Return _Cambiar_Usuario_X_Defecto
        End Get
        Set(value As Boolean)
            _Cambiar_Usuario_X_Defecto = value
        End Set
    End Property

    Private Sub Frm_Imp_Picking_02_Configuracionvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SuperTabControl1.SelectedTabIndex = 0

        Dim _Dir_Local As String = AppPath() & "\Data\"

        'Dim _Ds As New DatosBakApp
        '_Ds.Clear()
        '_Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

        'Dim _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo") '_Row_Nom_Equipo.Item("Nombre_Equipo")

        _Datos_Conf.ReadXml(_Path & "\Config_Local.xml")

        Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)

        Txt_Impresora.Text = _Fila.Item("Impresora")
        Btn_Impresora_Prod_Sol_Bodega.Tooltip = _Fila.Item("Impresora")
        Txt_RutaImagen.Text = NuloPorNro(_Fila.Item("RutaImagen"), "")

        Chk_Ejecutar_Automaticamente.Checked = NuloPorNro(_Fila.Item("Ejecutar_Automaticamente"), False)

        Chk_Timer_Monitoreos.Checked = False
        Chk_Timer_Correo.Checked = NuloPorNro(_Fila.Item("Timer_Monitoreo_Mail"), False)
        Chk_Timer_Impresion.Checked = NuloPorNro(_Fila.Item("Timer_Monitoreo_Impresion"), False)
        Chk_Timer_SolProdBod.Checked = NuloPorNro(_Fila.Item("Timer_Monitoreo_SolProdBod"), False)
        Chk_Timer_Prestashop.Checked = NuloPorNro(_Fila.Item("Timer_Prestashop"), False)
        Chk_Timer_Prestashop_Ordenes.Checked = NuloPorNro(_Fila.Item("Timer_Prestashop_Ordenes"), False)
        Chk_Timer_Consolidacion_Stock.Checked = NuloPorNro(_Fila.Item("Timer_Consolidacion_Stock"), False)
        Chk_Timer_Picking.Checked = NuloPorNro(_Fila.Item("Timer_Picking"), False)
        Chk_Timer_LibroDTESII.Checked = NuloPorNro(_Fila.Item("Timer_LibroDTESII"), False)
        Chk_Timer_Wordpress_Stock.Checked = NuloPorNro(_Fila.Item("Timer_Wordpress_Stock"), False)
        Chk_Timer_Wordpress_Productos.Checked = NuloPorNro(_Fila.Item("Timer_Wordpress_Productos"), False)
        Chk_Timer_Listas_Programadas.Checked = NuloPorNro(_Fila.Item("Timer_Listas_Programadas"), False)

        Input_Tiempo_Correo.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Correo"), 2)
        Input_Tiempo_Impresion.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Impresion"), 1)
        Input_Tiempo_Sol_Bodega.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Sol_Bodega"), 1)
        Input_Tiempo_Prestashop.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Prestashop"), 1)
        Input_Tiempo_Picking.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Picking"), 1)
        Input_Tiempo_LibroDTESII.Value = NuloPorNro(_Fila.Item("Input_Tiempo_LibroDTESII"), 5)
        Input_Tiempo_Archivador.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Archivador"), 5)
        Input_Tiempo_Wordpress_Stock.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Wordpress_Stock"), 5)
        Input_Tiempo_Wordpress_Productos.Value = NuloPorNro(_Fila.Item("Input_Tiempo_Wordpress_Productos"), 5)

        Rdb_Cons_Stock_Todos.Checked = NuloPorNro(_Fila.Item("Rdb_Cons_Stock_Todos"), True)
        Rdb_Cons_Stock_Mov_Hoy.Checked = NuloPorNro(_Fila.Item("Rdb_Cons_Stock_Mov_Hoy"), False)

        Chk_Cons_Stock_Lunes.Checked = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Lunes"), True)
        Chk_Cons_Stock_Martes.Checked = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Martes"), True)
        Chk_Cons_Stock_Miercoles.Checked = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Miercoles"), True)
        Chk_Cons_Stock_Jueves.Checked = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Jueves"), True)
        Chk_Cons_Stock_Viernes.Checked = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Viernes"), True)
        Chk_Cons_Stock_Sabado.Checked = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Sabado"), False)
        Chk_Cons_Stock_Domingo.Checked = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Domingo"), False)

        Chk_Prestashop_Ejecucion_Total.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Ejecucion_Total"), True)

        Chk_Prestashop_Lunes.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Lunes"), True)
        Chk_Prestashop_Martes.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Martes"), True)
        Chk_Prestashop_Miercoles.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Miercoles"), True)
        Chk_Prestashop_Jueves.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Jueves"), True)
        Chk_Prestashop_Viernes.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Viernes"), True)
        Chk_Prestashop_Sabado.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Sabado"), False)
        Chk_Prestashop_Domingo.Checked = NuloPorNro(_Fila.Item("Chk_Prestashop_Domingo"), False)
        Chk_Timer_Archivador.Checked = NuloPorNro(_Fila.Item("Timer_Archivador"), False)

        Chk_Timer_CierreDoc.Checked = NuloPorNro(_Fila.Item("Chk_Timer_CierreDoc"), False)
        Chk_CierreDoc_Lunes.Checked = NuloPorNro(_Fila.Item("Chk_CierreDoc_Lunes"), False)
        Chk_CierreDoc_Martes.Checked = NuloPorNro(_Fila.Item("Chk_CierreDoc_Martes"), False)
        Chk_CierreDoc_Miercoles.Checked = NuloPorNro(_Fila.Item("Chk_CierreDoc_Miercoles"), False)
        Chk_CierreDoc_Jueves.Checked = NuloPorNro(_Fila.Item("Chk_CierreDoc_Jueves"), False)
        Chk_CierreDoc_Viernes.Checked = NuloPorNro(_Fila.Item("Chk_CierreDoc_Viernes"), False)
        Chk_CierreDoc_Sabado.Checked = NuloPorNro(_Fila.Item("Chk_CierreDoc_Sabado"), False)
        Chk_CierreDoc_Domingo.Checked = NuloPorNro(_Fila.Item("Chk_CierreDoc_Domingo"), False)

        Chk_COVCerrar.Checked = NuloPorNro(_Fila.Item("Chk_COVCerrar"), False)
        Chk_NVICerrar.Checked = NuloPorNro(_Fila.Item("Chk_NVICerrar"), False)
        Chk_NVVCerrar.Checked = NuloPorNro(_Fila.Item("Chk_NVVCerrar"), False)
        Chk_OCICerrar.Checked = NuloPorNro(_Fila.Item("Chk_OCICerrar"), False)
        Chk_OCCCerrar.Checked = NuloPorNro(_Fila.Item("Chk_OCCCerrar"), False)

        Input_DiasCOV.Value = NuloPorNro(_Fila.Item("Input_DiasCOV"), 1)
        Input_DiasNVI.Value = NuloPorNro(_Fila.Item("Input_DiasNVI"), 1)
        Input_DiasNVV.Value = NuloPorNro(_Fila.Item("Input_DiasNVV"), 1)
        Input_DiasOCI.Value = NuloPorNro(_Fila.Item("Input_DiasOCI"), 1)
        Input_DiasOCC.Value = NuloPorNro(_Fila.Item("Input_DiasOCC"), 1)

        Input_CantMail.Value = NuloPorNro(_Fila.Item("CantMail"), 30)

        _Ruta_Archivador = NuloPorNro(_Fila.Item("Ruta_Archivador"), AppPath() & "\Data\" & RutEmpresa)

        Chk_Timer_FacAuto.Checked = NuloPorNro(_Fila.Item("Timer_FacAuto"), True)

        Chk_Fac_Lunes.Checked = NuloPorNro(_Fila.Item("Chk_Fac_Lunes"), True)
        Chk_Fac_Martes.Checked = NuloPorNro(_Fila.Item("Chk_Fac_Martes"), True)
        Chk_Fac_Miercoles.Checked = NuloPorNro(_Fila.Item("Chk_Fac_Miercoles"), True)
        Chk_Fac_Jueves.Checked = NuloPorNro(_Fila.Item("Chk_Fac_Jueves"), True)
        Chk_Fac_Viernes.Checked = NuloPorNro(_Fila.Item("Chk_Fac_Viernes"), True)
        Chk_Fac_Sabado.Checked = NuloPorNro(_Fila.Item("Chk_Fac_Sabado"), False)
        Chk_Fac_Domingo.Checked = NuloPorNro(_Fila.Item("Chk_Fac_Domingo"), False)

        Rdb_FA_1Dia.Checked = NuloPorNro(_Fila.Item("Rdb_FA_1Dia"), True)
        Rdb_FA_1Semana.Checked = NuloPorNro(_Fila.Item("Rdb_FA_1Semana"), False)
        Rdb_FA_1Mes.Checked = NuloPorNro(_Fila.Item("Rdb_FA_1Mes"), False)
        Rdb_FA_1Todas.Checked = NuloPorNro(_Fila.Item("Rdb_FA_1Todas"), False)

        Txt_Modalidad_FacAuto.Text = NuloPorNro(_Fila.Item("Txt_Modalidad_FacAuto"), "")

        Dim _LaHora = Now

        Dtp_Cons_Stock_Hora_Ejecucion.Value = NuloPorNro(_Fila.Item("Dtp_Cons_Stock_Hora_Ejecuion"), _LaHora)
        Dtp_Prestashop_Total_Hora_Ejecucion.Value = NuloPorNro(_Fila.Item("Dtp_Prestashop_Total_Hora_Ejecucion"), _LaHora)
        Dtp_CierreDoc_Hora_Ejecucion.Value = NuloPorNro(_Fila.Item("Dtp_CierreDoc_Hora_Ejecucion"), _LaHora)

        Chk_AsistenteDeCompras.Checked = NuloPorNro(_Fila.Item("Chk_AsistenteDeCompras"), False)
        Dtp_AsisCompra_Hora_Ejecucion.Value = NuloPorNro(_Fila.Item("Dtp_AsisCompra_Hora_Ejecucion"), _LaHora)

        Chk_AsisComEjecLunes.Checked = NuloPorNro(_Fila.Item("Chk_AsisComEjecLunes"), False)
        Chk_AsisComEjecMartes.Checked = NuloPorNro(_Fila.Item("Chk_AsisComEjecMartes"), False)
        Chk_AsisComEjecMiercoles.Checked = NuloPorNro(_Fila.Item("Chk_AsisComEjecMiercoles"), False)
        Chk_AsisComEjecJueves.Checked = NuloPorNro(_Fila.Item("Chk_AsisComEjecJueves"), False)
        Chk_AsisComEjecViernes.Checked = NuloPorNro(_Fila.Item("Chk_AsisComEjecViernes"), False)
        Chk_AsisComEjecSabado.Checked = NuloPorNro(_Fila.Item("Chk_AsisComEjecSabado"), False)
        Chk_AsisComEjecDomingo.Checked = NuloPorNro(_Fila.Item("Chk_AsisComEjecDomingo"), False)

        Txt_AsComModLunes.Text = NuloPorNro(_Fila.Item("Txt_AsComModLunes"), "")
        Txt_AsComModMartes.Text = NuloPorNro(_Fila.Item("Txt_AsComModMartes"), "")
        Txt_AsComModMiercoles.Text = NuloPorNro(_Fila.Item("Txt_AsComModMiercoles"), "")
        Txt_AsComModJueves.Text = NuloPorNro(_Fila.Item("Txt_AsComModJueves"), "")
        Txt_AsComModViernes.Text = NuloPorNro(_Fila.Item("Txt_AsComModViernes"), "")
        Txt_AsComModSabado.Text = NuloPorNro(_Fila.Item("Txt_AsComModSabado"), "")
        Txt_AsComModDomingo.Text = NuloPorNro(_Fila.Item("Txt_AsComModDomingo"), "")

        Chk_EnvDocSinRecep_EjecLunes.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecLunes"), False)
        Chk_EnvDocSinRecep_EjecMartes.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecMartes"), False)
        Chk_EnvDocSinRecep_EjecMiercoles.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecMiercoles"), False)
        Chk_EnvDocSinRecep_EjecJueves.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecJueves"), False)
        Chk_EnvDocSinRecep_EjecViernes.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecViernes"), False)
        Chk_EnvDocSinRecep_EjecSabado.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecSabado"), False)
        Chk_EnvDocSinRecep_EjecDomingo.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecDomingo"), False)

        Chk_EnvDocSinRecep.Checked = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep"), False)
        Dtp_EnvDocSinRecep_Hora_Ejecucion.Value = NuloPorNro(_Fila.Item("Dtp_EnvDocSinRecep_Hora_Ejecucion"), _LaHora)

        Chk_EnvDocSinRecep_COV.Checked = NuloPorNro(_Fila.Item("EnvDocSinRecep_COV"), False)
        Chk_EnvDocSinRecep_NVI.Checked = NuloPorNro(_Fila.Item("EnvDocSinRecep_NVI"), False)
        Chk_EnvDocSinRecep_NVV.Checked = NuloPorNro(_Fila.Item("EnvDocSinRecep_NVV"), False)
        Chk_EnvDocSinRecep_OCI.Checked = NuloPorNro(_Fila.Item("EnvDocSinRecep_OCI"), False)
        Chk_EnvDocSinRecep_OCC.Checked = NuloPorNro(_Fila.Item("EnvDocSinRecep_OCC"), False)
        Chk_EnvDocSinRecep_GTI.Checked = NuloPorNro(_Fila.Item("EnvDocSinRecep_GTI"), False)
        Chk_EnvDocSinRecep_GDI.Checked = NuloPorNro(_Fila.Item("EnvDocSinRecep_GDI"), False)

        Input_EnvDocSinRecep_DiasCOV.Value = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasCOV"), 0)
        Input_EnvDocSinRecep_DiasNVI.Value = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasNVI"), 0)
        Input_EnvDocSinRecep_DiasNVV.Value = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasNVV"), 0)
        Input_EnvDocSinRecep_DiasOCI.Value = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasOCI"), 0)
        Input_EnvDocSinRecep_DiasOCC.Value = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasOCC"), 0)
        Input_EnvDocSinRecep_DiasGTI.Value = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasGTI"), 0)
        Input_EnvDocSinRecep_DiasGDI.Value = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasGDI"), 0)

        Txt_CtaCorreoEnvDocSinRecep.Tag = NuloPorNro(_Fila.Item("Id_CtaCorreoEnvDocSinRecep"), 0)
        Txt_CtaCorreoEnvDocSinRecep.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Correos", "Nombre_Correo", "Id = " & Txt_CtaCorreoEnvDocSinRecep.Tag)

        Txt_ParaEnvDocSinRecep.Text = NuloPorNro(_Fila.Item("Txt_ParaEnvDocSinRecep"), "")

    End Sub

    Private Sub Btn_Impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Impresora_Prod_Sol_Bodega.Click

        Dim Fm As New Frm_Seleccionar_Impresoras(Txt_Impresora.Text)
        Fm.ShowDialog(Me)

        If Not String.IsNullOrEmpty(Trim(Fm.Pro_Impresora_Seleccionada)) Then

            Txt_Impresora.Text = Fm.Pro_Impresora_Seleccionada
            ToastNotification.Show(Me, "IMPRESORA SELECCIONADA [" & Txt_Impresora.Text & "]", My.Resources.ok_button,
                                         3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_RutaImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RutaImagen.Click
        Dim OpenBuscarImagen As New OpenFileDialog
        OpenBuscarImagen.ShowDialog()
        Dim _RutaImagen = OpenBuscarImagen.FileName

        Txt_RutaImagen.Text = _RutaImagen
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        If Not Fx_Tiene_Permiso(Me, "Pick0005", _Funcionario_Autorizado) Then
            Return
        End If

        _Datos_Conf.Clear()

        Dim _Es_Diablito As Boolean

        With _Datos_Conf

            Dim NewFila As DataRow
            NewFila = _Datos_Conf.Tables("Tbl_Configuracion").NewRow

            With NewFila

                .Item("Impresora") = Txt_Impresora.Text
                .Item("RutaImagen") = Txt_RutaImagen.Text

                .Item("Ejecutar_Automaticamente") = Chk_Ejecutar_Automaticamente.Checked

                .Item("Timer_Monitoreo_Doc") = Chk_Timer_Monitoreos.Checked
                .Item("Timer_Monitoreo_Mail") = Chk_Timer_Correo.Checked
                .Item("Timer_Monitoreo_Impresion") = Chk_Timer_Impresion.Checked
                .Item("Timer_Monitoreo_SolProdBod") = Chk_Timer_SolProdBod.Checked
                .Item("Timer_Prestashop") = Chk_Timer_Prestashop.Checked
                .Item("Timer_Prestashop_Ordenes") = Chk_Timer_Prestashop_Ordenes.Checked
                .Item("Timer_Consolidacion_Stock") = Chk_Timer_Consolidacion_Stock.Checked
                .Item("Timer_Picking") = Chk_Timer_Picking.Checked
                .Item("Timer_LibroDTESII") = Chk_Timer_LibroDTESII.Checked
                .Item("CantMail") = Input_CantMail.Value

                If Chk_Timer_LibroDTESII.Checked Then

                    Dim _RecepXMLComp_CorreoPOP3 As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion",
                                                                               "RecepXMLComp_CorreoPOP3",
                                                                               "Empresa = '" & Mod_Empresa & "' And Modalidad = '  '")

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos_Cuentas Where Nombre_Usuario = '" & _RecepXMLComp_CorreoPOP3 & "'"
                    Dim _Row_Cuenta = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If IsNothing(_Row_Cuenta) Then
                        MessageBoxEx.Show(Me, "El sistema solo descargara las compras desde el SII, pero no descargara los XML desde el correo" & vbCrLf & vbCrLf &
                                          "Falta configuración para recibir correos con XML de proveedores" & vbCrLf &
                                          "Revisen en la configuraión general en la pestaña de compras",
                                          "Configuración DTE proveedores",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

                .Item("Timer_Archivador") = Chk_Timer_Archivador.Checked
                .Item("Timer_Wordpress_Stock") = Chk_Timer_Wordpress_Stock.Checked
                .Item("Timer_Wordpress_Productos") = Chk_Timer_Wordpress_Productos.Checked
                .Item("Timer_Listas_Programadas") = Chk_Timer_Listas_Programadas.Checked

                _Es_Diablito = (Chk_Timer_Impresion.Checked Or Chk_Timer_Picking.Checked)

                .Item("Input_Tiempo_Correo") = Input_Tiempo_Correo.Value
                .Item("Input_Tiempo_Impresion") = Input_Tiempo_Impresion.Value
                .Item("Input_Tiempo_Sol_Bodega") = Input_Tiempo_Sol_Bodega.Value
                .Item("Input_Tiempo_Prestashop") = Input_Tiempo_Prestashop.Value
                .Item("Input_Tiempo_Picking") = Input_Tiempo_Picking.Value
                .Item("Input_Tiempo_LibroDTESII") = Input_Tiempo_LibroDTESII.Value
                .Item("Input_Tiempo_Archivador") = Input_Tiempo_Archivador.Value
                .Item("Input_Tiempo_Wordpress_Stock") = Input_Tiempo_Wordpress_Stock.Value
                .Item("Input_Tiempo_Wordpress_Productos") = Input_Tiempo_Wordpress_Productos.Value

                .Item("Rdb_Cons_Stock_Todos") = Rdb_Cons_Stock_Todos.Checked
                .Item("Rdb_Cons_Stock_Mov_Hoy") = Rdb_Cons_Stock_Mov_Hoy.Checked

                .Item("Chk_Cons_Stock_Lunes") = Chk_Cons_Stock_Lunes.Checked
                .Item("Chk_Cons_Stock_Martes") = Chk_Cons_Stock_Martes.Checked
                .Item("Chk_Cons_Stock_Miercoles") = Chk_Cons_Stock_Miercoles.Checked
                .Item("Chk_Cons_Stock_Jueves") = Chk_Cons_Stock_Jueves.Checked
                .Item("Chk_Cons_Stock_Viernes") = Chk_Cons_Stock_Viernes.Checked
                .Item("Chk_Cons_Stock_Sabado") = Chk_Cons_Stock_Sabado.Checked
                .Item("Chk_Cons_Stock_Domingo") = Chk_Cons_Stock_Domingo.Checked
                .Item("Dtp_Cons_Stock_Hora_Ejecuion") = Dtp_Cons_Stock_Hora_Ejecucion.Value

                .Item("Chk_Prestashop_Ejecucion_Total") = Chk_Prestashop_Ejecucion_Total.Checked
                .Item("Chk_Prestashop_Lunes") = Chk_Prestashop_Lunes.Checked
                .Item("Chk_Prestashop_Martes") = Chk_Prestashop_Martes.Checked
                .Item("Chk_Prestashop_Miercoles") = Chk_Prestashop_Miercoles.Checked
                .Item("Chk_Prestashop_Jueves") = Chk_Prestashop_Jueves.Checked
                .Item("Chk_Prestashop_Viernes") = Chk_Prestashop_Viernes.Checked
                .Item("Chk_Prestashop_Sabado") = Chk_Prestashop_Sabado.Checked
                .Item("Chk_Prestashop_Domingo") = Chk_Prestashop_Domingo.Checked
                .Item("Dtp_Prestashop_Total_Hora_Ejecucion") = Dtp_Prestashop_Total_Hora_Ejecucion.Value

                .Item("Ruta_Archivador") = _Ruta_Archivador.Trim

                .Item("Chk_Prestashop_Lunes") = Chk_Prestashop_Lunes.Checked
                .Item("Chk_Prestashop_Martes") = Chk_Prestashop_Martes.Checked
                .Item("Chk_Prestashop_Miercoles") = Chk_Prestashop_Miercoles.Checked
                .Item("Chk_Prestashop_Jueves") = Chk_Prestashop_Jueves.Checked
                .Item("Chk_Prestashop_Viernes") = Chk_Prestashop_Viernes.Checked
                .Item("Chk_Prestashop_Sabado") = Chk_Prestashop_Sabado.Checked
                .Item("Chk_Prestashop_Domingo") = Chk_Prestashop_Domingo.Checked
                .Item("Timer_Archivador") = Chk_Timer_Archivador.Checked

                .Item("Chk_Timer_CierreDoc") = Chk_Timer_CierreDoc.Checked
                .Item("Chk_CierreDoc_Lunes") = Chk_CierreDoc_Lunes.Checked
                .Item("Chk_CierreDoc_Martes") = Chk_CierreDoc_Martes.Checked
                .Item("Chk_CierreDoc_Miercoles") = Chk_CierreDoc_Miercoles.Checked
                .Item("Chk_CierreDoc_Jueves") = Chk_CierreDoc_Jueves.Checked
                .Item("Chk_CierreDoc_Viernes") = Chk_CierreDoc_Viernes.Checked
                .Item("Chk_CierreDoc_Sabado") = Chk_CierreDoc_Sabado.Checked
                .Item("Chk_CierreDoc_Domingo") = Chk_CierreDoc_Domingo.Checked

                .Item("Chk_COVCerrar") = Chk_COVCerrar.Checked
                .Item("Chk_NVICerrar") = Chk_NVICerrar.Checked
                .Item("Chk_NVVCerrar") = Chk_NVVCerrar.Checked
                .Item("Chk_OCICerrar") = Chk_OCICerrar.Checked
                .Item("Chk_OCCCerrar") = Chk_OCCCerrar.Checked

                .Item("Input_DiasCOV") = Input_DiasCOV.Value
                .Item("Input_DiasNVI") = Input_DiasNVI.Value
                .Item("Input_DiasNVV") = Input_DiasNVV.Value
                .Item("Input_DiasOCI") = Input_DiasOCI.Value
                .Item("Input_DiasOCC") = Input_DiasOCC.Value

                .Item("Dtp_CierreDoc_Hora_Ejecucion") = Dtp_CierreDoc_Hora_Ejecucion.Value
                .Item("CantMail") = Input_CantMail.Value

                .Item("Timer_FacAuto") = Chk_Timer_FacAuto.Checked
                .Item("Chk_Fac_Lunes") = Chk_Fac_Lunes.Checked
                .Item("Chk_Fac_Martes") = Chk_Fac_Martes.Checked
                .Item("Chk_Fac_Miercoles") = Chk_Fac_Miercoles.Checked
                .Item("Chk_Fac_Jueves") = Chk_Fac_Jueves.Checked
                .Item("Chk_Fac_Viernes") = Chk_Fac_Viernes.Checked
                .Item("Chk_Fac_Sabado") = Chk_Fac_Sabado.Checked
                .Item("Chk_Fac_Domingo") = Chk_Fac_Domingo.Checked
                .Item("Rdb_FA_1Dia") = Rdb_FA_1Dia.Checked
                .Item("Rdb_FA_1Semana") = Rdb_FA_1Semana.Checked
                .Item("Rdb_FA_1Mes") = Rdb_FA_1Mes.Checked
                .Item("Rdb_FA_1Todas") = Rdb_FA_1Todas.Checked
                .Item("Txt_Modalidad_FacAuto") = Txt_Modalidad_FacAuto.Text

                .Item("Chk_AsistenteDeCompras") = Chk_AsistenteDeCompras.Checked
                .Item("Dtp_AsisCompra_Hora_Ejecucion") = Dtp_AsisCompra_Hora_Ejecucion.Value

                If Not Fx_RevDiaModalidadAsistenteCompras(Chk_AsisComEjecLunes, Txt_AsComModLunes) Then Return
                If Not Fx_RevDiaModalidadAsistenteCompras(Chk_AsisComEjecMartes, Txt_AsComModMartes) Then Return
                If Not Fx_RevDiaModalidadAsistenteCompras(Chk_AsisComEjecMiercoles, Txt_AsComModMiercoles) Then Return
                If Not Fx_RevDiaModalidadAsistenteCompras(Chk_AsisComEjecJueves, Txt_AsComModJueves) Then Return
                If Not Fx_RevDiaModalidadAsistenteCompras(Chk_AsisComEjecViernes, Txt_AsComModViernes) Then Return
                If Not Fx_RevDiaModalidadAsistenteCompras(Chk_AsisComEjecSabado, Txt_AsComModSabado) Then Return
                If Not Fx_RevDiaModalidadAsistenteCompras(Chk_AsisComEjecDomingo, Txt_AsComModDomingo) Then Return

                .Item("Chk_AsisComEjecLunes") = Chk_AsisComEjecLunes.Checked
                .Item("Chk_AsisComEjecMartes") = Chk_AsisComEjecMartes.Checked
                .Item("Chk_AsisComEjecMiercoles") = Chk_AsisComEjecMiercoles.Checked
                .Item("Chk_AsisComEjecJueves") = Chk_AsisComEjecJueves.Checked
                .Item("Chk_AsisComEjecViernes") = Chk_AsisComEjecViernes.Checked
                .Item("Chk_AsisComEjecSabado") = Chk_AsisComEjecSabado.Checked
                .Item("Chk_AsisComEjecDomingo") = Chk_AsisComEjecDomingo.Checked

                .Item("Txt_AsComModLunes") = Txt_AsComModLunes.Text
                .Item("Txt_AsComModMartes") = Txt_AsComModMartes.Text
                .Item("Txt_AsComModMiercoles") = Txt_AsComModMiercoles.Text
                .Item("Txt_AsComModJueves") = Txt_AsComModJueves.Text
                .Item("Txt_AsComModViernes") = Txt_AsComModViernes.Text
                .Item("Txt_AsComModSabado") = Txt_AsComModSabado.Text
                .Item("Txt_AsComModDomingo") = Txt_AsComModDomingo.Text



                .Item("Chk_EnvDocSinRecep_EjecLunes") = Chk_EnvDocSinRecep_EjecLunes.Checked
                .Item("Chk_EnvDocSinRecep_EjecMartes") = Chk_EnvDocSinRecep_EjecMartes.Checked
                .Item("Chk_EnvDocSinRecep_EjecMiercoles") = Chk_EnvDocSinRecep_EjecMiercoles.Checked
                .Item("Chk_EnvDocSinRecep_EjecJueves") = Chk_EnvDocSinRecep_EjecJueves.Checked
                .Item("Chk_EnvDocSinRecep_EjecViernes") = Chk_EnvDocSinRecep_EjecViernes.Checked
                .Item("Chk_EnvDocSinRecep_EjecSabado") = Chk_EnvDocSinRecep_EjecSabado.Checked
                .Item("Chk_EnvDocSinRecep_EjecDomingo") = Chk_EnvDocSinRecep_EjecDomingo.Checked

                .Item("Chk_EnvDocSinRecep") = Chk_EnvDocSinRecep.Checked
                .Item("Dtp_EnvDocSinRecep_Hora_Ejecucion") = Dtp_EnvDocSinRecep_Hora_Ejecucion.Value

                .Item("EnvDocSinRecep_COV") = Chk_EnvDocSinRecep_COV.Checked
                .Item("EnvDocSinRecep_NVI") = Chk_EnvDocSinRecep_NVI.Checked
                .Item("EnvDocSinRecep_NVV") = Chk_EnvDocSinRecep_NVV.Checked
                .Item("EnvDocSinRecep_OCI") = Chk_EnvDocSinRecep_OCI.Checked
                .Item("EnvDocSinRecep_OCC") = Chk_EnvDocSinRecep_OCC.Checked
                .Item("EnvDocSinRecep_GTI") = Chk_EnvDocSinRecep_GTI.Checked
                .Item("EnvDocSinRecep_GDI") = Chk_EnvDocSinRecep_GDI.Checked

                .Item("EnvDocSinRecep_DiasCOV") = Input_EnvDocSinRecep_DiasCOV.Value
                .Item("EnvDocSinRecep_DiasNVI") = Input_EnvDocSinRecep_DiasNVI.Value
                .Item("EnvDocSinRecep_DiasNVV") = Input_EnvDocSinRecep_DiasNVV.Value
                .Item("EnvDocSinRecep_DiasOCI") = Input_EnvDocSinRecep_DiasOCI.Value
                .Item("EnvDocSinRecep_DiasOCC") = Input_EnvDocSinRecep_DiasOCC.Value
                .Item("EnvDocSinRecep_DiasGTI") = Input_EnvDocSinRecep_DiasGTI.Value
                .Item("EnvDocSinRecep_DiasGDI") = Input_EnvDocSinRecep_DiasGDI.Value

                .Item("Id_CtaCorreoEnvDocSinRecep") = Txt_CtaCorreoEnvDocSinRecep.Tag
                .Item("Txt_ParaEnvDocSinRecep") = Txt_ParaEnvDocSinRecep.Text

            End With

            .Tables("Tbl_Configuracion").Rows.Add(NewFila)

            .WriteXml(_Path & "\Config_Local.xml")

            If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_EstacionesBkp", "Es_Diablito") Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Es_Diablito = " & Convert.ToInt32(_Es_Diablito) & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End With

        ToastNotification.Show(Me, "DATOS GUARDADOS CORRECTAMENTE", My.Resources.ok_button,
                                     3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        Me.Close()

    End Sub

    Function Fx_RevDiaModalidadAsistenteCompras(_Chk As Controls.CheckBoxX, _Txt As Controls.TextBoxX) As Boolean

        If Not _Chk.Checked Then
            _Txt.Text = String.Empty
        End If

        If _Chk.Checked And String.IsNullOrEmpty(_Txt.Text) Then
            SuperTabControl1.SelectedTabIndex = 4
            MessageBoxEx.Show(Me, "Falta la modalidad para la ejecución del día " & _Txt.Tag,
                                  "Validación [Asistente de compras]", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True
    End Function

    Private Sub Chk_Timer_Consolidacion_Stock_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Timer_Consolidacion_Stock.CheckedChanged
        Panel_01.Enabled = Chk_Timer_Consolidacion_Stock.Checked
    End Sub

    Private Sub Btn_Filtro_Doc_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Correo.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Correo)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Filtro_Doc_Impresion_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Impresion.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Filtro_Doc_Prestashop_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Prestashop.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Prestashop)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Filtro_Doc_Picking_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Picking.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion_Picking)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Carpeta_Archivador_Click(sender As Object, e As EventArgs) Handles Btn_Carpeta_Archivador.Click

        Dim oFD As New FolderBrowserDialog

        With oFD

            .Description = "Seleccionar el directorio de grabación"
            .RootFolder = Environment.SpecialFolder.MyComputer
            .SelectedPath = _Ruta_Archivador

            If .ShowDialog = DialogResult.OK Then
                _Ruta_Archivador = .SelectedPath
            End If

        End With

    End Sub

    Private Sub Chk_Timer_Archivador_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Timer_Archivador.Checked Then

            If String.IsNullOrEmpty(_Ruta_Archivador.Trim) Then
                Call Btn_Carpeta_Archivador_Click(Nothing, Nothing)
            End If

            If String.IsNullOrEmpty(_Ruta_Archivador) Then
                Chk_Timer_Archivador.Checked = False
            End If

        End If

    End Sub

    Private Sub Btn_Carpeta_Imagenes_Click(sender As Object, e As EventArgs) Handles Btn_Carpeta_Imagenes.Click
        Process.Start("explorer.exe", _Dir_Correo_Imagenes)
    End Sub

    Private Sub Btn_Filtro_Doc_Impresion_X_Usuario_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Impresion_X_Usuario.Click

        If Not Fx_Tiene_Permiso("Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Dim Fm As New Frm_Demonio_05_FunConecExt(_NombreEquipo, False)
        Fm.Funcionario_Autorizado = _Funcionario_Autorizado
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Filtro_Doc_Picking_X_Usuario_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Picking_X_Usuario.Click

        If Not Fx_Tiene_Permiso("Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Dim Fm As New Frm_Demonio_05_FunConecExt(_NombreEquipo, True)
        Fm.Funcionario_Autorizado = _Funcionario_Autorizado
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnCambiarDeUsuario_Click(sender As Object, e As EventArgs) Handles BtnCambiarDeUsuario.Click

        Dim _Old_Funcionario = FUNCIONARIO

        Dim Fml As New Frm_Login
        Fml.ShowDialog()
        Fml.Dispose()

        If _Old_Funcionario <> FUNCIONARIO Then

            Dim Frm_Modalidad As New Frm_Modalidades(False)
            Frm_Modalidad.ShowDialog()
            Frm_Modalidad.Dispose()

            If MessageBoxEx.Show(Me, "¿Desea dejar a este funcionario permanentemente como usuario por defecto para la estación de trabajo?" & vbCrLf & vbCrLf &
                                         "Usuario: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim & " Modalidad: " & Mod_Modalidad,
                                         "Usuario por defecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set " &
                               "Usuario_X_Defecto = '" & FUNCIONARIO & "', Modalidad_X_Defecto = '" & Mod_Modalidad & "'" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Nombre de usuario por defecto cambiado correctamente", "Cambio de usuario",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

            _Cambiar_Usuario_X_Defecto = True
            Me.Close()

        End If

    End Sub

    Private Sub Txt_Modalidad_FacAuto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Modalidad_FacAuto.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDADES DE LA EMPRESA"

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And MODALIDAD <> '  '",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Modalidad = _Row.Item("Codigo").ToString.Trim

            Txt_Modalidad_FacAuto.Tag = _Modalidad
            Txt_Modalidad_FacAuto.Text = _Modalidad

        End If

    End Sub

    Private Sub Txt_AsComModLunes_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AsComModLunes.ButtonCustomClick
        SB_BuscarModalidadXDia(sender)
    End Sub

    Private Sub Txt_AsComModMartes_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AsComModMartes.ButtonCustomClick
        SB_BuscarModalidadXDia(sender)
    End Sub

    Private Sub Txt_AsComModMiercoles_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AsComModMiercoles.ButtonCustomClick
        SB_BuscarModalidadXDia(sender)
    End Sub

    Private Sub Txt_AsComModJueves_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AsComModJueves.ButtonCustomClick
        SB_BuscarModalidadXDia(sender)
    End Sub

    Private Sub Txt_AsComModViernes_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AsComModViernes.ButtonCustomClick
        SB_BuscarModalidadXDia(sender)
    End Sub

    Private Sub Txt_AsComModSabado_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AsComModSabado.ButtonCustomClick
        SB_BuscarModalidadXDia(sender)
    End Sub

    Private Sub Txt_AsComModDomingo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AsComModDomingo.ButtonCustomClick
        SB_BuscarModalidadXDia(sender)
    End Sub

    Sub SB_BuscarModalidadXDia(_Txt As Controls.TextBoxX)

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        Dim _Tbl As DataTable

        If Not String.IsNullOrEmpty(_Txt.Text) Then

            Consulta_sql = "Select Distinct Cast(1 As Bit) As Chk,MODALIDAD As Codigo, MODALIDAD As Descripcion" & vbCrLf &
                           "From CONFIEST" & vbCrLf &
                           "Where EMPRESA = '" & Mod_Empresa & "' And MODALIDAD In " & _Txt.Text
            _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        End If

        If _Filtrar.Fx_Filtrar(_Tbl,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And EMPRESA = '" & Mod_Empresa & "'",
                               Nothing, False, False) Then

            _Txt.Text = Generar_Filtro_IN(_Filtrar.Pro_Tbl_Filtro, "Chk", "Codigo", False, True, "'")

        End If

    End Sub

    Private Sub Btn_ConfAsisCompra_Click(sender As Object, e As EventArgs) Handles Btn_ConfAsisCompra.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        'Dim _Caja_Habilitada As Boolean = _Global_Row_EstacionBk.Item("Caja_Habilitada")
        'Dim _Modalidad_Caja As String = _Global_Row_EstacionBk.Item("Modalidad_Caja")

        'Dim _Sql = "And MODALIDAD In (Select SUBSTRING(KOOP,4,5) As Modalidad From MAEUS Where KOUS = '" & _CodFuncionario & "' And KOOP Like 'MO-%')"

        'If _Caja_Habilitada Then
        '    _Sql += vbCrLf & "Or MODALIDAD = '" & _Modalidad_Caja & "'"
        'End If

        Dim _Modalidad As String

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And EMPRESA = '" & Mod_Empresa & "'",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            _Modalidad = _Row.Item("Codigo").ToString.Trim

        End If

        If String.IsNullOrEmpty(_Modalidad) Then
            Return
        End If

        Me.Enabled = False

        Dim Fm As New Frm_00_Asis_Compra_Menu(_Modalidad)
        Fm.Tipo_Informe = "Asistente de compras Configuración de OCC automatizadas"
        Fm.Modo_OCC = True
        Fm.Modo_ConfAuto = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub Txt_CtaCorreoEnvDocSinRecep_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CtaCorreoEnvDocSinRecep.ButtonCustomClick

        Dim _Row_Email As DataRow

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)
        _Row_Email = Fm.Pro_Row_Fila_Seleccionada
        Fm.Dispose()

        If Not IsNothing(_Row_Email) Then
            Txt_CtaCorreoEnvDocSinRecep.Tag = _Row_Email.Item("Id")
            Txt_CtaCorreoEnvDocSinRecep.Text = _Row_Email.Item("Nombre_Correo").ToString.Trim
        End If

    End Sub

    Private Sub Txt_CtaCorreoEnvDocSinRecep_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CtaCorreoEnvDocSinRecep.ButtonCustom2Click

        If MessageBoxEx.Show(Me, "Confirma quitar el correo", "Quitar correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_CtaCorreoEnvDocSinRecep.Tag = 0
            Txt_CtaCorreoEnvDocSinRecep.Text = String.Empty
        End If

    End Sub
End Class
