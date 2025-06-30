Imports System.CodeDom.Compiler
Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_Demonio_Configuraciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _NombreEquipo As String
    Dim _Id_Padre As Integer
    Dim _Row_ConfEstacion As DataRow

    Dim _Funcionario_Autorizado As String

    Dim EnvioCorreo_Prog As New Cl_NewProgramacion

    Dim _Directorio = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
    Dim _Dir_Correo_Imagenes = _Directorio & "\Correo\Imagenes"

    Public Property Grabar As Boolean
    Public Property Cambiar_Usuario_X_Defecto As Boolean

    Public Property Cl_Cerrar_Documentos As New Cl_Cerrar_Documentos

    Public Sub New(_Id_Padre As Integer, _Funcionario_Autorizado As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
        Me._Funcionario_Autorizado = _Funcionario_Autorizado
        Me._Id_Padre = _Id_Padre

        Sb_Color_Botones_Barra(Bar1)

        Sb_Formato_Generico_Grilla(Grilla_AsistenteCompras, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_Demonio_Configuraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Chk_EnvioCorreo.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ColaImpDoc.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ColaImpPick.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_SolProdBod.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Prestashop_Prod.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Prestashop_Order.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Prestashop_Total.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ImporDTESII.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ArchivarDoc.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ConsStock.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Wordpress_Prod.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Wordpress_Stock.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_CierreDoc.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_FacAuto.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_AsistenteCompras.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_EnvDocSinRecep.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ListasProgramadas.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_NVVAuto.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_RecalculoPPP.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged

        AddHandler Sp_EnvioCorreo.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ColaImpDoc.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ColaImpPick.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_SolProdBod.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Prestashop_Prod.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Prestashop_Order.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Prestashop_Total.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ImporDTESII.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ArchivarDoc.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ConsStock.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Wordpress_Prod.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Wordpress_Stock.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_CierreDoc.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_FacAuto.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_EnvDocSinRecep.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_AsistenteCompras.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ListasProgramadas.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_NVVAuto.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_RecalculoPPP.Click, AddressOf Sp_SuperTabItem_Click

        Input_DiasCOV.Enabled = Chk_COVCerrar.Checked
        Rdb_COV_FEmision.Enabled = Chk_COVCerrar.Checked
        Rdb_COV_FDespacho.Enabled = Chk_COVCerrar.Checked
        Input_DiasNVI.Enabled = Chk_NVICerrar.Checked
        Rdb_NVI_FEmision.Enabled = Chk_NVICerrar.Checked
        Rdb_NVI_FDespacho.Enabled = Chk_NVICerrar.Checked
        Input_DiasNVV.Enabled = Chk_NVVCerrar.Checked
        Rdb_NVV_FEmision.Enabled = Chk_NVVCerrar.Checked
        Rdb_NVV_FDespacho.Enabled = Chk_NVVCerrar.Checked
        Input_DiasOCI.Enabled = Chk_OCICerrar.Checked
        Rdb_OCI_FEmision.Enabled = Chk_OCICerrar.Checked
        Rdb_OCI_FDespacho.Enabled = Chk_OCICerrar.Checked
        Input_DiasOCC.Enabled = Chk_OCCCerrar.Checked
        Rdb_OCC_FEmision.Enabled = Chk_OCCCerrar.Checked
        Rdb_OCC_FDespacho.Enabled = Chk_OCCCerrar.Checked

        Sb_Parametros_Informe_Sql(False)
        Sp_SuperTabItem_Click(Sp_EnvioCorreo, Nothing)
        Sb_Actualizar_Grilla_Acp()

        Sb_Llenar_Zw_Conf_Cerrar_Documentos()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        For Each _Tab As SuperTabItem In SuperTab.Tabs

            If Not IsNothing(_Tab.Image) Then

                Dim _Nombre As String = Replace(_Tab.Name, "Sp_", "")

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion" & vbCrLf &
                               "Where Id_Padre = " & _Id_Padre & " And NombreEquipo = '" & _NombreEquipo & "' And Nombre = '" & _Nombre & "'"
                Dim _Row_Programacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _RevisarProgramacion = False

                If IsNothing(_Row_Programacion) Then
                    _RevisarProgramacion = True
                Else
                    _RevisarProgramacion = String.IsNullOrEmpty(_Row_Programacion.Item("Resumen"))
                End If

                If _Nombre = "AsistenteCompras" AndAlso Not _RevisarProgramacion Then
                    _RevisarProgramacion = Not CBool(Grilla_AsistenteCompras.RowCount)
                End If

                If _RevisarProgramacion Then
                    MessageBoxEx.Show(Me, "Falta la programación para " & _Tab.Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    SuperTab.SelectedTab = _Tab
                    Sp_SuperTabItem_Click(Nothing, Nothing)
                    Return
                End If

            End If

        Next

        If Chk_SolProdBod.Checked AndAlso String.IsNullOrWhiteSpace(Txt_ImpSolProdBod.Text) Then
            MessageBoxEx.Show(Me, "Falta la impresora en solicitud de productos a bodega", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_FacAuto.Checked AndAlso String.IsNullOrWhiteSpace(Txt_FacAuto_Modalidad.Text) Then
            MessageBoxEx.Show(Me, "Falta la modalidad para la facturación automática", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_ArchivarDoc.Checked AndAlso String.IsNullOrWhiteSpace(Txt_DirArchivarDoc.Text) Then
            MessageBoxEx.Show(Me, "Falta la carpeta de destino de los archivos en el archivador de documentos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_ArchivarDoc.Checked Then
            If Not Directory.Exists(Txt_DirArchivarDoc.Text) Then
                MessageBoxEx.Show(Me, "No existe el directorio " & Txt_DirArchivarDoc.Text, "Validación archivador de documentos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Chk_EnvDocSinRecep.Checked Then

            If String.IsNullOrEmpty(Txt_ParaEnvDocSinRecep.Text) Then
                MessageBoxEx.Show(Me, "Falta el destinatario para los envio de documentos sin recepción", "Validación documentos sin recepción", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                SuperTab.SelectedTabIndex = 16
                Return
            End If

            If String.IsNullOrEmpty(Txt_CtaCorreoEnvDocSinRecep.Text) Then
                MessageBoxEx.Show(Me, "Falta el correo envio de documentos sin recepción", "Validación documentos sin recepción", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                SuperTab.SelectedTabIndex = 16
                Return
            End If

            If Not Chk_EnvDocSinRecep_COV.Checked AndAlso
               Not Chk_EnvDocSinRecep_GDI.Checked AndAlso
               Not Chk_EnvDocSinRecep_GTI.Checked AndAlso
               Not Chk_EnvDocSinRecep_NVI.Checked AndAlso
               Not Chk_EnvDocSinRecep_NVV.Checked AndAlso
               Not Chk_EnvDocSinRecep_OCC.Checked AndAlso
               Not Chk_EnvDocSinRecep_OCI.Checked Then
                MessageBoxEx.Show(Me, "Debe marcar por lo menos un documento para documentos sin recepción", "Validación documentos sin recepción", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                SuperTab.SelectedTabIndex = 16
                Return
            End If

        End If

        If Chk_CierreDoc.Checked AndAlso
            Not Chk_COVCerrar.Checked AndAlso
            Not Chk_NVICerrar.Checked AndAlso
            Not Chk_NVVCerrar.Checked AndAlso
            Not Chk_OCCCerrar.Checked AndAlso
            Not Chk_OCICerrar.Checked Then
            MessageBoxEx.Show(Me, "Debe indicar algún documento para cerrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            SuperTab.SelectedTabIndex = 13
            Return
        End If

        Dim _Cov As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "COV")
        Dim _Nvi As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "NVI")
        Dim _Nvv As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "NVV")
        Dim _Oci As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "OCI")
        Dim _Occ As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "OCC")

        _Cov.Ejecutar = Chk_COVCerrar.Checked
        _Cov.Dias = Input_DiasCOV.Value
        _Cov.FEmision = Rdb_COV_FEmision.Checked
        _Cov.FDespacho = Rdb_COV_FDespacho.Checked
        Cl_Cerrar_Documentos.Fx_Grabar_Cl_Cerrar_Documentos(_Cov)

        _Nvi.Ejecutar = Chk_NVICerrar.Checked
        _Nvi.Dias = Input_DiasNVI.Value
        _Nvi.FEmision = Rdb_NVI_FEmision.Checked
        _Nvi.FDespacho = Rdb_NVI_FDespacho.Checked
        Cl_Cerrar_Documentos.Fx_Grabar_Cl_Cerrar_Documentos(_Nvi)

        _Nvv.Ejecutar = Chk_NVVCerrar.Checked
        _Nvv.Dias = Input_DiasNVV.Value
        _Nvv.FEmision = Rdb_NVV_FEmision.Checked
        _Nvv.FDespacho = Rdb_NVV_FDespacho.Checked
        Cl_Cerrar_Documentos.Fx_Grabar_Cl_Cerrar_Documentos(_Nvv)

        _Oci.Ejecutar = Chk_OCICerrar.Checked
        _Oci.Dias = Input_DiasOCI.Value
        _Oci.FEmision = Rdb_OCI_FEmision.Checked
        _Oci.FDespacho = Rdb_OCI_FDespacho.Checked
        Cl_Cerrar_Documentos.Fx_Grabar_Cl_Cerrar_Documentos(_Oci)

        _Occ.Ejecutar = Chk_OCCCerrar.Checked
        _Occ.Dias = Input_DiasOCC.Value
        _Occ.FEmision = Rdb_OCC_FEmision.Checked
        _Occ.FDespacho = Rdb_OCC_FDespacho.Checked
        Cl_Cerrar_Documentos.Fx_Grabar_Cl_Cerrar_Documentos(_Occ)

        If Chk_NVVAuto.Checked AndAlso String.IsNullOrWhiteSpace(Txt_NvvAuto_Modalidad.Text) Then
            MessageBoxEx.Show(Me, "Falta la modalidad para las notas de venta automáticas externas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_FacAuto.Checked Then

            If Not _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then

                Dim _Directorio_GenDTE As String = _Global_Row_EstacionBk.Item("Directorio_GenDTE")

                If Not Directory.Exists(_Directorio_GenDTE) Then

                    MessageBoxEx.Show(Me, "El directorio GenDTE no existe o no esta registrado." & vbCrLf &
                                      "Debe configurar esta carpeta en la configuración local del equipo", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Chk_FacAuto.Checked = False
                    Return
                End If

            End If

        End If

        Sb_Parametros_Informe_Sql(True)
        Grabar = True
        Me.Close()

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

    Private Sub Btn_Filtro_Doc_Impresion_X_Usuario_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Impresion_X_Usuario.Click
        If Not Fx_Tiene_Permiso("Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Dim Fm As New Frm_Demonio_05_FunConecExt(_NombreEquipo, False)
        Fm.Funcionario_Autorizado = _Funcionario_Autorizado
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Txt_ImpSolProdBod_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ImpSolProdBod.ButtonCustomClick
        Dim Fm As New Frm_Seleccionar_Impresoras(Txt_ImpSolProdBod.Text)
        Fm.ShowDialog(Me)

        If Not String.IsNullOrEmpty(Trim(Fm.Pro_Impresora_Seleccionada)) Then

            Txt_ImpSolProdBod.Text = Fm.Pro_Impresora_Seleccionada
            ToastNotification.Show(Me, "IMPRESORA SELECCIONADA [" & Txt_ImpSolProdBod.Text & "]", My.Resources.ok_button,
                                         3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If
        Fm.Dispose()
    End Sub

    Private Sub Txt_ImpSolProdBod_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_ImpSolProdBod.ButtonCustom2Click
        Txt_ImpSolProdBod.Text = String.Empty
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

    Private Sub Btn_Filtro_Doc_Picking_X_Usuario_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Picking_X_Usuario.Click
        If Not Fx_Tiene_Permiso("Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Dim Fm As New Frm_Demonio_05_FunConecExt(_NombreEquipo, True)
        Fm.Funcionario_Autorizado = _Funcionario_Autorizado
        Fm.ShowDialog(Me)
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

    Private Sub Txt_DirArchivarDoc_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_DirArchivarDoc.ButtonCustomClick

        Dim _Ruta_Archivador As String = AppPath() & "\Data\" & RutEmpresa & "\Archivador"

        If MessageBoxEx.Show(Me, "¿Desea dejar la carpeta de destino por defecto?" & vbCrLf & vbCrLf &
                             "[Si] deja carpeta por defecto" & vbCrLf &
                             "[No] selecciona otro directorio", "Carpeta de destino de archivador",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If Not Directory.Exists(_Ruta_Archivador) Then
                System.IO.Directory.CreateDirectory(_Ruta_Archivador)
            End If

            Txt_DirArchivarDoc.Text = _Ruta_Archivador
            Return

        End If

        Dim _Aceptar As Boolean

        _Ruta_Archivador = Txt_DirArchivarDoc.Text

        _Aceptar = InputBox_Bk(Me, "Ingrese la carpeta de destino", "Archivador de documentos",
                               _Ruta_Archivador, False,,, True, _Tipo_Imagen.Folder,,,,,, True)

        If Not _Aceptar Then
            Return
        End If

        Txt_DirArchivarDoc.Text = _Ruta_Archivador

    End Sub

    Private Sub Btn_ConfProgramacion_Click(sender As Object, e As EventArgs) Handles Btn_ConfProgramacion.Click

        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Programacion As Cl_NewProgramacion
        Dim _Tab As SuperTabItem = SuperTab.SelectedTab

        Dim _Nombre As String = Replace(_Tab.Name, "Sp_", "")

        Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion",
                                                   "Id", "Id_Padre = " & _Id_Padre & " And NombreEquipo = '" & _NombreEquipo & "' And Nombre = '" & _Nombre & "'", True)

        If Not CBool(_Id_Prg) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion (NombreEquipo,Tbl_Padre,Id_Padre,Nombre,FrecuDiaria,SucedeUnaVez) " &
                           "Values ('" & _NombreEquipo & "','Diablito'," & _Id_Padre & ",'" & _Nombre & "',1,1)"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Prg)
        End If

        _Programacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

        If String.IsNullOrEmpty(_Programacion.Tbl_Padre) Then
            _Programacion.Tbl_Padre = "Diablito"
        End If

        Dim _Diariamente As Boolean
        Dim _Semanalmente As Boolean
        Dim _SucedeCada As Boolean
        Dim _SucedeUnaVez As Boolean
        Dim _TipoIntervalo As String = String.Empty
        Dim _TIValorDefecto As String
        Dim _TISegundos As Boolean
        Dim _TIMinutos As Boolean
        Dim _TIHoras As Boolean

        Dim _MinIntervalo As Integer
        Dim _MaxIntevalo As Integer

        Sb_Tipo_Configuracion(_Nombre, _Diariamente, _Semanalmente, _SucedeCada, _SucedeUnaVez, _TIValorDefecto, _TISegundos, _TIMinutos, _TIHoras, _TipoIntervalo, _MinIntervalo, _MaxIntevalo)

        Dim Fm As New Frm_Demonio_ConfProgramacion(_TISegundos, _TIMinutos, _TIHoras, _TIValorDefecto)
        Fm.Text = "Configuración de programación de " & _Tab.Text.ToUpper

        Fm.Rdb_FrecuDiaria.Enabled = _Diariamente
        Fm.Rdb_FrecuSemanal.Enabled = _Semanalmente
        Fm.Rdb_SucedeCada.Enabled = _SucedeCada
        Fm.Rdb_SucedeUnaVez.Enabled = _SucedeUnaVez
        Fm.Input_IntervaloCada.MinValue = _MinIntervalo
        Fm.Input_IntervaloCada.MaxValue = _MaxIntevalo

        Fm.TIMinutos = _TIMinutos
        Fm.TIHoras = _TIHoras

        Fm.Programacion = _Programacion
        Fm.Txt_Nombre.ReadOnly = True
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            _Grb_Programacion.Sb_Actualizar_programacion(_Programacion)
            Sp_SuperTabItem_Click(_Tab, Nothing)
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Tipo_Configuracion(_Nombre As String,
                              ByRef _Diariamente As Boolean,
                              ByRef _Semanalmente As Boolean,
                              ByRef _SucedeCada As Boolean,
                              ByRef _SucedeUnaVez As Boolean,
                              ByRef _TIValorDefecto As String,
                              ByRef _TISegundos As Boolean,
                              ByRef _TIMinutos As Boolean,
                              ByRef _TIHoras As Boolean,
                              ByRef _TipoIntervalo As String,
                              ByRef _MinIntervalo As Integer,
                              ByRef _MaxIntevalo As Integer)

        _MinIntervalo = 1
        _MaxIntevalo = 60

        Select Case _Nombre
            Case "EnvioCorreo", "Prestashop_Prod", "Wordpress_Prod", "Wordpress_Stock", "ImporDTESII", "ListasProgramadas"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 1 : _MaxIntevalo = 59 : _TIMinutos = True : _TIValorDefecto = "MM"
            Case "ColaImpDoc"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 3 : _MaxIntevalo = 3 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "ColaImpPick"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 4 : _MaxIntevalo = 4 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "SolProdBod"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 5 : _MaxIntevalo = 5 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "Prestashop_Order"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 2 : _MaxIntevalo = 2 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "ArchivarDoc"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 30 : _MaxIntevalo = 30 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "ConsStock", "CierreDoc", "Prestashop_Total", "RecalculoPPP"
                _Diariamente = True : _Semanalmente = True : _SucedeUnaVez = True : _SucedeCada = False
                _MinIntervalo = 5 : _MaxIntevalo = 59 : _TIMinutos = True : _TIValorDefecto = ""
            Case "FacAuto", "NVVAuto"
                _Diariamente = True : _Semanalmente = True : _SucedeUnaVez = False : _SucedeCada = True
                _MinIntervalo = 1 : _MaxIntevalo = 59 : _TIMinutos = True : _TISegundos = True : _TIValorDefecto = ""
            Case "AsistenteCompras"
                _Diariamente = True : _Semanalmente = False : _SucedeUnaVez = True : _SucedeCada = False : _TIValorDefecto = ""
            Case "AsistenteCompras", "EnvDocSinRecep"
                _Diariamente = True : _Semanalmente = True : _SucedeUnaVez = True : _SucedeCada = False : _TIValorDefecto = ""
            Case Else
                Dim A = 1
        End Select


    End Sub

    Function Fx_Traer_Progracion_De_Tab(_Nombre As String) As Cl_NewProgramacion

        Dim _Grb_Programacion As New Grb_Programacion

        Dim _Id_Prg = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id_Padre & " And Nombre = '" & _Nombre & "'")

        If Not CBool(_Id_Prg) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion (Id_Padre,Nombre) Values (" & _Id_Padre & ",'EnvioCorreo')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Prg)
        End If

        Fx_Traer_Progracion_De_Tab = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

    End Function

    Private Sub Chk_Habilitar_CheckedChanged(sender As Object, e As EventArgs)

        Dim _NombreChk As String = CType(sender, Controls.CheckBoxX).Name.Replace("Chk_", "")

        For Each _Stab As SuperTabItem In SuperTab.Tabs

            Dim _NombreTab As String = Replace(_Stab.Name, "Sp_", "")

            If _NombreTab = _NombreChk Then
                If sender.Checked Then
                    _Stab.Image = Imagenes_16X16.Images.Item("symbol-ok.png")
                Else
                    _Stab.Image = Nothing
                End If
                Exit For
            End If

        Next

    End Sub

    Private Sub Sp_SuperTabItem_Click(sender As Object, e As EventArgs)

        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Tab As SuperTabItem = SuperTab.SelectedTab

        Grupo_Resumen.Text = _Tab.Text

        If _Tab.Name = "" Then 'Or _Tab.Name = "Sp_AsistenteCompras"
            Btn_ConfProgramacion.Enabled = False
            Txt_Resumen.Text = "La programación depende de cada registro"
            Return
        End If

        Btn_ConfProgramacion.Enabled = True

        Dim _Nombre As String = Replace(_Tab.Name, "Sp_", "")

        Dim _Resumen As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Resumen", "Id_Padre = " & _Id_Padre & " And Nombre = '" & _Nombre & "'")

        If String.IsNullOrEmpty(_Resumen) Then
            _Resumen = "Sin programación..."
        Else
            _Resumen = "Descripción de la programación:" & vbCrLf & _Resumen
        End If

        Txt_Resumen.Text = _Resumen

    End Sub

    Private Sub Txt_FacAuto_Modalidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FacAuto_Modalidad.ButtonCustomClick

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

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(Me, _Modalidad, "FCV", True)

            If IsNothing(_RowFormato) Then
                _Modalidad = String.Empty
                'Throw New System.Exception("No existe formato de documento para la modalidad")
            End If

            Txt_FacAuto_Modalidad.Tag = _Modalidad
            Txt_FacAuto_Modalidad.Text = _Modalidad

        End If

    End Sub

    Private Sub Btn_AgregarConfAsisCompra_Click(sender As Object, e As EventArgs) Handles Btn_AgregarConfAsisCompra.Click

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion" & vbCrLf &
                       "Where Id_Padre = " & _Id_Padre & " And NombreEquipo = '" & _NombreEquipo & "' And Nombre = 'AsistenteCompras'"
        Dim _Row_Programacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Programacion) Then
            MessageBoxEx.Show(Me, "Falta la programación del asistente de compras", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Demonio_ConfAsisCompra(0)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla_Acp()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Actualizar_Grilla_Acp()

        Consulta_sql = "Select AcpA.Id,AcpA.NombreEquipo,AcpA.Modalidad,AcpA.NVI,AcpA.OCC_Star,AcpA.OCC_Prov,Prog.Resumen" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto AcpA" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Prog On AcpA.Id = Prog.Id_Padre And Prog.Tbl_Padre = 'AcoAuto'" & vbCrLf &
                       "Where AcpA.NombreEquipo = '" & _NombreEquipo & "'" & vbCrLf &
                       "Order by Modalidad,NVI Desc,OCC_Star Desc"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_AsistenteCompras

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_AsistenteCompras, True)

            Dim _DisplayIndex = 0

            .Columns("Modalidad").Width = 50
            .Columns("Modalidad").HeaderText = "Mod."
            .Columns("Modalidad").ToolTipText = "Modalidad"
            .Columns("Modalidad").Visible = True
            .Columns("Modalidad").Frozen = True
            .Columns("Modalidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NVI").Width = 40
            .Columns("NVI").HeaderText = "NVI"
            .Columns("NVI").Visible = True
            .Columns("NVI").Frozen = True
            .Columns("NVI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OCC_Star").Width = 40
            .Columns("OCC_Star").HeaderText = "OCC PE"
            .Columns("OCC_Star").ToolTipText = "Ordenes de compra al proveedor estrella"
            .Columns("OCC_Star").Visible = True
            .Columns("OCC_Star").Frozen = True
            .Columns("OCC_Star").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OCC_Prov").Width = 40
            .Columns("OCC_Prov").HeaderText = "OCC OP"
            .Columns("OCC_Prov").ToolTipText = "Ordenes de compra a otros proveedores"
            .Columns("OCC_Prov").Visible = True
            .Columns("OCC_Prov").Frozen = True
            .Columns("OCC_Prov").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Resumen").Width = 200
            .Columns("Resumen").HeaderText = "Resumen"
            .Columns("Resumen").Visible = True
            .Columns("Resumen").Frozen = False
            .Columns("Resumen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    'Private Sub Grilla_AsistenteCompras_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_AsistenteCompras.CellEnter

    '    Dim _Fila As DataGridViewRow = Grilla_AsistenteCompras.CurrentRow

    '    Txt_Resumen.Text = _Fila.Cells("Resumen").Value

    'End Sub

    Private Sub Grilla_AsistenteCompras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_AsistenteCompras.CellDoubleClick

        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Fila As DataGridViewRow = Grilla_AsistenteCompras.CurrentRow

        Dim _Id_Padre As Integer = _Fila.Cells("Id").Value

        Dim _Id As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id",
                                                   "Id_Padre = " & _Id_Padre & " And NombreEquipo = '" & _NombreEquipo & "' And Tbl_Padre = 'AcoAuto'", True)

        Dim _Programacion As Cl_NewProgramacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id)

        Dim Fm As New Frm_Demonio_ConfAsisCompra(_Id_Padre)
        Fm.Programacion = _Programacion
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla_Acp()
        End If
        Fm.Dispose()

    End Sub


    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _Actualizar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                           "Where Informe = 'Demonio' And NombreEquipo = '" & _NombreEquipo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        'Ejecución automática
        _Sql.Sb_Parametro_Informe_Sql(Chk_Ejecutar_Automaticamente, "Demonio",
                                      Chk_Ejecutar_Automaticamente.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Ejecutar_Automaticamente.Checked, _Actualizar, "Automatica",, False)

        'correo
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvioCorreo, "Demonio",
                                      Chk_EnvioCorreo.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvioCorreo.Checked, _Actualizar, "Correo",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_CantCorreo, "Demonio",
                                      Input_CantCorreo.Name, Class_SQLite.Enum_Type._Double,
                                      Input_CantCorreo.Value, _Actualizar, "Correo",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnviarSiempreLosCorreosDTE, "Demonio",
                                      Chk_EnviarSiempreLosCorreosDTE.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnviarSiempreLosCorreosDTE.Checked, _Actualizar, "Correo",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_ActualizarListaMayoristaMinorista, "Demonio",
                                      Chk_ActualizarListaMayoristaMinorista.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ActualizarListaMayoristaMinorista.Checked, _Actualizar, "Correo",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_CorreoMayoristaMinorista, "Demonio",
                                      Txt_CorreoMayoristaMinorista.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_CorreoMayoristaMinorista.Text, _Actualizar, "Correo",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_CorreoMayoristaMinorista, "Demonio",
                                      Txt_CorreoMayoristaMinorista.Name, Class_SQLite.Enum_Type._Tag,
                                      Txt_CorreoMayoristaMinorista.Tag, _Actualizar, "Correo",, False)


        'Impresiones
        _Sql.Sb_Parametro_Informe_Sql(Chk_ColaImpDoc, "Demonio",
                                      Chk_ColaImpDoc.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ColaImpDoc.Checked, _Actualizar, "Impresion",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_ColaImpPick, "Demonio",
                                      Chk_ColaImpPick.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ColaImpPick.Checked, _Actualizar, "Impresion",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_ColaImpImprmirTodoNodejarCola, "Demonio",
                                      Chk_ColaImpImprmirTodoNodejarCola.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ColaImpImprmirTodoNodejarCola.Checked, _Actualizar, "Impresion",, False)


        'Prestashop
        _Sql.Sb_Parametro_Informe_Sql(Chk_Prestashop_Prod, "Demonio",
                                      Chk_Prestashop_Prod.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Prestashop_Prod.Checked, _Actualizar, "Prestashop",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Prestashop_Order, "Demonio",
                                      Chk_Prestashop_Order.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Prestashop_Order.Checked, _Actualizar, "Prestashop",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Prestashop_Total, "Demonio",
                                      Chk_Prestashop_Total.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Prestashop_Total.Checked, _Actualizar, "Prestashop",, False)

        'Importar correos y actualizar libro de compras DTESII
        _Sql.Sb_Parametro_Informe_Sql(Chk_ImporDTESII, "Demonio",
                                      Chk_ImporDTESII.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ImporDTESII.Checked, _Actualizar, "ImporDTESII",, False)
        'Archivar documentos
        _Sql.Sb_Parametro_Informe_Sql(Chk_ArchivarDoc, "Demonio",
                                      Chk_ArchivarDoc.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ArchivarDoc.Checked, _Actualizar, "ArchivarDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_DirArchivarDoc, "Demonio",
                                      Txt_DirArchivarDoc.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_DirArchivarDoc.Text, _Actualizar, "ArchivarDoc",, False)

        'Consolidar stock
        _Sql.Sb_Parametro_Informe_Sql(Chk_ConsStock, "Demonio",
                                      Chk_ConsStock.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ConsStock.Checked, _Actualizar, "ConsolidarStock",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Cons_Stock_Todos, "Demonio",
                                      Rdb_Cons_Stock_Todos.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_Cons_Stock_Todos.Checked, _Actualizar, "ConsolidarStock",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Cons_Stock_Mov_Hoy, "Demonio",
                                      Rdb_Cons_Stock_Mov_Hoy.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_Cons_Stock_Mov_Hoy.Checked, _Actualizar, "ConsolidarStock",, False)

        'Wordpress
        _Sql.Sb_Parametro_Informe_Sql(Chk_Wordpress_Prod, "Demonio",
                                      Chk_Wordpress_Prod.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Wordpress_Prod.Checked, _Actualizar, "Wordpress",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Wordpress_Stock, "Demonio",
                                      Chk_Wordpress_Stock.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Wordpress_Stock.Checked, _Actualizar, "Wordpress",, False)

        ''Cierre de documentos
        _Sql.Sb_Parametro_Informe_Sql(Chk_CierreDoc, "Demonio",
                                      Chk_CierreDoc.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_CierreDoc.Checked, _Actualizar, "CierreDoc",, False)


        'Facturación automatica
        _Sql.Sb_Parametro_Informe_Sql(Chk_FacAuto, "Demonio",
                                      Chk_FacAuto.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_FacAuto.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_FacAuto_Modalidad, "Demonio",
                                      Txt_FacAuto_Modalidad.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_FacAuto_Modalidad.Text, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Dia, "Demonio",
                                      Rdb_FacAuto_Dia.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Dia.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Sem, "Demonio",
                                      Rdb_FacAuto_Sem.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Sem.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Mes, "Demonio",
                                      Rdb_FacAuto_Mes.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Mes.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Todas, "Demonio",
                                      Rdb_FacAuto_Todas.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Todas.Checked, _Actualizar, "FacAuto",, False)

        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_CualquierNVV, "Demonio",
                                      Rdb_FacAuto_CualquierNVV.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_CualquierNVV.Checked, _Actualizar, "FacAuto",, False)

        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_SoloDeSucModalidad, "Demonio",
                                      Rdb_FacAuto_SoloDeSucModalidad.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_SoloDeSucModalidad.Checked, _Actualizar, "FacAuto",, False)

        _Sql.Sb_Parametro_Informe_Sql(Txt_FacAuto_CodFunFactura, "Demonio",
                                      Txt_FacAuto_CodFunFactura.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_FacAuto_CodFunFactura.Tag, _Actualizar, "FacAuto",, False)

        Txt_FacAuto_CodFunFactura.Text = Replace(Txt_FacAuto_CodFunFactura.Tag, "''", "'")

        _Sql.Sb_Parametro_Informe_Sql(Input_CantDocFacturanXProceso, "Demonio",
                                      Input_CantDocFacturanXProceso.Name, Class_SQLite.Enum_Type._Double,
                                      Input_CantDocFacturanXProceso.Value, _Actualizar, "FacAuto",, False)

        _Sql.Sb_Parametro_Informe_Sql(Rdb_FcOrden_Llegada, "Demonio",
                                      Rdb_FcOrden_Llegada.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FcOrden_Llegada.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FcOrden_ItemMenosMas, "Demonio",
                                      Rdb_FcOrden_ItemMenosMas.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FcOrden_ItemMenosMas.Checked, _Actualizar, "FacAuto",, False)

        'Solicitud de productos a bodega
        _Sql.Sb_Parametro_Informe_Sql(Chk_SolProdBod, "Demonio",
                                      Chk_SolProdBod.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_SolProdBod.Checked, _Actualizar, "SolProdBod",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_ImpSolProdBod, "Demonio",
                                      Txt_ImpSolProdBod.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_ImpSolProdBod.Text, _Actualizar, "SolProdBod",, False)

        'Asistente de compras
        _Sql.Sb_Parametro_Informe_Sql(Chk_AsistenteCompras, "Demonio",
                                      Chk_AsistenteCompras.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_AsistenteCompras.Checked, _Actualizar, "SolProdBod",, False)

        'Listas Programadas
        _Sql.Sb_Parametro_Informe_Sql(Chk_ListasProgramadas, "Demonio",
                                      Chk_ListasProgramadas.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ListasProgramadas.Checked, _Actualizar, "ListasProgramadas",, False)


        'Envio de documentos sin recepcion
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep, "Demonio",
                                      Chk_EnvDocSinRecep.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep_COV, "Demonio",
                                      Chk_EnvDocSinRecep_COV.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep_COV.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_EnvDocSinRecep_DiasCOV, "Demonio",
                                      Input_EnvDocSinRecep_DiasCOV.Name, Class_SQLite.Enum_Type._Double,
                                      Input_EnvDocSinRecep_DiasCOV.Value, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep_GDI, "Demonio",
                                      Chk_EnvDocSinRecep_GDI.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep_GDI.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_EnvDocSinRecep_DiasGDI, "Demonio",
                                      Input_EnvDocSinRecep_DiasGDI.Name, Class_SQLite.Enum_Type._Double,
                                      Input_EnvDocSinRecep_DiasGDI.Value, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep_GTI, "Demonio",
                                      Chk_EnvDocSinRecep_GTI.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep_GTI.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_EnvDocSinRecep_DiasGTI, "Demonio",
                                      Input_EnvDocSinRecep_DiasGTI.Name, Class_SQLite.Enum_Type._Double,
                                      Input_EnvDocSinRecep_DiasGTI.Value, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep_NVI, "Demonio",
                                      Chk_EnvDocSinRecep_NVI.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep_NVI.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_EnvDocSinRecep_DiasNVI, "Demonio",
                                      Input_EnvDocSinRecep_DiasNVI.Name, Class_SQLite.Enum_Type._Double,
                                      Input_EnvDocSinRecep_DiasNVI.Value, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep_NVV, "Demonio",
                                      Chk_EnvDocSinRecep_NVV.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep_NVV.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_EnvDocSinRecep_DiasNVV, "Demonio",
                                      Input_EnvDocSinRecep_DiasNVV.Name, Class_SQLite.Enum_Type._Double,
                                      Input_EnvDocSinRecep_DiasNVV.Value, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep_OCC, "Demonio",
                                      Chk_EnvDocSinRecep_OCC.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep_OCC.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_EnvDocSinRecep_DiasOCC, "Demonio",
                                      Input_EnvDocSinRecep_DiasOCC.Name, Class_SQLite.Enum_Type._Double,
                                      Input_EnvDocSinRecep_DiasOCC.Value, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvDocSinRecep_OCI, "Demonio",
                                      Chk_EnvDocSinRecep_OCI.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvDocSinRecep_OCI.Checked, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_EnvDocSinRecep_DiasOCI, "Demonio",
                                      Input_EnvDocSinRecep_DiasOCI.Name, Class_SQLite.Enum_Type._Double,
                                      Input_EnvDocSinRecep_DiasOCI.Value, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_ParaEnvDocSinRecep, "Demonio",
                                      Txt_ParaEnvDocSinRecep.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_ParaEnvDocSinRecep.Text, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_CtaCorreoEnvDocSinRecep, "Demonio",
                                      Txt_CtaCorreoEnvDocSinRecep.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_CtaCorreoEnvDocSinRecep.Text, _Actualizar, "EnvDocSinRecep",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_CtaCorreoEnvDocSinRecep, "Demonio",
                                      Txt_CtaCorreoEnvDocSinRecep.Name, Class_SQLite.Enum_Type._Tag,
                                      Txt_CtaCorreoEnvDocSinRecep.Tag, _Actualizar, "EnvDocSinRecep",, False)

        ' Notas de venta externas
        _Sql.Sb_Parametro_Informe_Sql(Chk_NVVAuto, "Demonio",
                                      Chk_NVVAuto.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_NVVAuto.Checked, _Actualizar, "NVVAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_NvvAuto_Modalidad, "Demonio",
                                      Txt_NvvAuto_Modalidad.Name, Class_SQLite.Enum_Type._Text,
                                      Txt_NvvAuto_Modalidad.Text, _Actualizar, "NVVAuto",, False)

        'Recalculo del Precio Promedio Ponderado
        _Sql.Sb_Parametro_Informe_Sql(Chk_RecalculoPPP, "Demonio",
                                      Chk_RecalculoPPP.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_RecalculoPPP.Checked, _Actualizar, "RecalculoPPP",, False)

    End Sub

    Private Sub Btn_Carpeta_Imagenes_Click(sender As Object, e As EventArgs) Handles Btn_Carpeta_Imagenes.Click
        Process.Start("explorer.exe", _Dir_Correo_Imagenes)
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
                                         "Usuario: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim & " Modalidad: " & Modalidad,
                                         "Usuario por defecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set " &
                               "Usuario_X_Defecto = '" & FUNCIONARIO & "', Modalidad_X_Defecto = '" & Modalidad & "'" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Nombre de usuario por defecto cambiado correctamente", "Cambio de usuario",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

            Cambiar_Usuario_X_Defecto = True
            Me.Close()

        End If

    End Sub

    Private Sub Txt_DirArchivarDoc_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_DirArchivarDoc.ButtonCustom2Click

        If Not Directory.Exists(Txt_DirArchivarDoc.Text) Then
            MessageBoxEx.Show(Me, "No existe el directorio " & Txt_DirArchivarDoc.Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Process.Start("explorer.exe", Txt_DirArchivarDoc.Text)

    End Sub

    Private Sub Txt_CtaCorreoEnvDocSinRecep_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CtaCorreoEnvDocSinRecep.ButtonCustom2Click
        If MessageBoxEx.Show(Me, "Confirma quitar el correo", "Quitar correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_CtaCorreoEnvDocSinRecep.Tag = 0
            Txt_CtaCorreoEnvDocSinRecep.Text = String.Empty
        End If
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

    Private Sub Txt_NvvAuto_Modalidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NvvAuto_Modalidad.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDADES DE LA EMPRESA"

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD+': Empresa:'+EMPRESA+', Suc: '+ESUCURSAL+', Bod: '+EBODEGA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And MODALIDAD <> '  '",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Modalidad = _Row.Item("Codigo").ToString.Trim

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(Me, _Modalidad, "NVV", True)

            If IsNothing(_RowFormato) Then
                _Modalidad = String.Empty
                'Throw New System.Exception("No existe formato de documento para la modalidad")
            End If

            Txt_NvvAuto_Modalidad.Tag = _Modalidad
            Txt_NvvAuto_Modalidad.Text = _Modalidad

        End If

    End Sub

    Private Sub Txt_CorreoMayoristaMinorista_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CorreoMayoristaMinorista.ButtonCustomClick

        Dim _Row_Email As DataRow

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)
        _Row_Email = Fm.Pro_Row_Fila_Seleccionada
        Fm.Dispose()

        If Not IsNothing(_Row_Email) Then
            Txt_CorreoMayoristaMinorista.Tag = _Row_Email.Item("Id")
            Txt_CorreoMayoristaMinorista.Text = _Row_Email.Item("Nombre_Correo").ToString.Trim
        End If

    End Sub

    Private Sub Txt_CorreoMayoristaMinorista_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CorreoMayoristaMinorista.ButtonCustom2Click
        If MessageBoxEx.Show(Me, "Confirma quitar el correo", "Quitar correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_CorreoMayoristaMinorista.Tag = 0
            Txt_CorreoMayoristaMinorista.Text = String.Empty
        End If
    End Sub

    Private Sub Txt_FacAuto_CodFunFactura_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FacAuto_CodFunFactura.ButtonCustomClick

        Dim _Tbl As DataTable

        If Not String.IsNullOrWhiteSpace(Txt_FacAuto_CodFunFactura.Text.Trim) Then

            Consulta_sql = "Select KOFU As 'Codigo',NOKOFU As 'Descripcion' From TABFU Where KOFU In " & Txt_FacAuto_CodFunFactura.Text
            _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "", False, False, False) Then

            _Tbl = _Filtrar.Pro_Tbl_Filtro

            Dim _Filtro As String = Generar_Filtro_IN(_Tbl, "", "Codigo", False, False, "'")

            Txt_FacAuto_CodFunFactura.Tag = Replace(_Filtro, "'", "''")
            Txt_FacAuto_CodFunFactura.Text = _Filtro '_Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo").ToString.Trim

        End If

    End Sub

    Private Sub Txt_FacAuto_CodFunFactura_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_FacAuto_CodFunFactura.ButtonCustom2Click
        Txt_FacAuto_CodFunFactura.Tag = String.Empty
        Txt_FacAuto_CodFunFactura.Text = String.Empty
    End Sub

    Private Sub Btn_Rutas_PDF_Facturas_Click(sender As Object, e As EventArgs) Handles Btn_Rutas_PDF_Facturas.Click
        Sb_Configuracion_Salida_PDF(Me, ModEmpresa, Txt_FacAuto_Modalidad.Text, "FCV")
    End Sub

    Private Sub Btn_Rutas_PDF_Boletas_Click(sender As Object, e As EventArgs) Handles Btn_Rutas_PDF_Boletas.Click
        Sb_Configuracion_Salida_PDF(Me, ModEmpresa, Txt_FacAuto_Modalidad.Text, "BLV")
    End Sub

    Private Sub Btn_Rutas_PDF_Guias_Click(sender As Object, e As EventArgs) Handles Btn_Rutas_PDF_Guias.Click
        Sb_Configuracion_Salida_PDF(Me, ModEmpresa, Txt_FacAuto_Modalidad.Text, "GDV")
    End Sub

    Private Sub Btn_ConfCorreo_CierreNVV_Click(sender As Object, e As EventArgs) Handles Btn_ConfCorreo_CierreNVV.Click

        Dim _Nvv As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "NVV")

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Id_Padre = _Global_Row_EstacionBk.Item("Id")
        'Dim _Id As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_Conf_Correo", "Id",
        '                                       "NombreEquipo = '" & _NombreEquipo & "' And Id_Padre = " & _Id_Padre & " And Nombre_ConfCorreo = 'ConfCorreo_CierreNVV'", True)
        Dim _Id_ConfCorreo As Integer = _Nvv.Id_ConfCorreo

        Dim Fm As New Frm_Demonio_ConfCorreoAviso(_Id_ConfCorreo, "ConfCorreo_CierreNVV")
        Fm.ShowDialog(Me)
        _Nvv.Id_ConfCorreo = Fm.Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Id
        Fm.Dispose()

    End Sub

#Region "Cerrar_Documentos"

    Sub Sb_Llenar_Zw_Conf_Cerrar_Documentos()

        Cl_Cerrar_Documentos.Sb_Llenar_Zw_Conf_Cerrar_Documentos()

        Dim _Cov As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "COV")
        Dim _Nvi As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "NVI")
        Dim _Nvv As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "NVV")
        Dim _Oci As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "OCI")
        Dim _Occ As Zw_Demonio_Conf_Cerrar_Documentos = Cl_Cerrar_Documentos.LS_Zw_Demonio_Conf_Cerrar_Documentos.FirstOrDefault(Function(x) x.Tido = "OCC")

        Chk_COVCerrar.Checked = _Cov.Ejecutar
        Input_DiasCOV.Value = _Cov.Dias
        Rdb_COV_FEmision.Checked = _Cov.FEmision
        Rdb_COV_FDespacho.Checked = _Cov.FDespacho

        Chk_NVICerrar.Checked = _Nvi.Ejecutar
        Input_DiasNVI.Value = _Nvi.Dias
        Rdb_NVI_FEmision.Checked = _Nvi.FEmision
        Rdb_NVI_FDespacho.Checked = _Nvi.FDespacho

        Chk_NVVCerrar.Checked = _Nvv.Ejecutar
        Input_DiasNVV.Value = _Nvv.Dias
        Rdb_NVV_FEmision.Checked = _Nvv.FEmision
        Rdb_NVV_FDespacho.Checked = _Nvv.FDespacho

        Chk_OCICerrar.Checked = _Oci.Ejecutar
        Input_DiasOCI.Value = _Oci.Dias
        Rdb_OCI_FEmision.Checked = _Oci.FEmision
        Rdb_OCI_FDespacho.Checked = _Oci.FDespacho

        Chk_OCCCerrar.Checked = _Occ.Ejecutar
        Input_DiasOCC.Value = _Occ.Dias
        Rdb_OCC_FEmision.Checked = _Occ.FEmision
        Rdb_OCC_FDespacho.Checked = _Occ.FDespacho

    End Sub

    Private Sub Chk_COVCerrar_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_COVCerrar.CheckedChanged
        Input_DiasCOV.Enabled = Chk_COVCerrar.Checked
        Rdb_COV_FEmision.Enabled = Chk_COVCerrar.Checked
        Rdb_COV_FDespacho.Enabled = Chk_COVCerrar.Checked
    End Sub

    Private Sub Chk_NVICerrar_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_NVICerrar.CheckedChanged
        Input_DiasNVI.Enabled = Chk_NVICerrar.Checked
        Rdb_NVI_FEmision.Enabled = Chk_NVICerrar.Checked
        Rdb_NVI_FDespacho.Enabled = Chk_NVICerrar.Checked
    End Sub

    Private Sub Chk_NVVCerrar_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_NVVCerrar.CheckedChanged
        Input_DiasNVV.Enabled = Chk_NVVCerrar.Checked
        Rdb_NVV_FEmision.Enabled = Chk_NVVCerrar.Checked
        Rdb_NVV_FDespacho.Enabled = Chk_NVVCerrar.Checked
    End Sub

    Private Sub Chk_OCICerrar_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_OCICerrar.CheckedChanged
        Input_DiasOCI.Enabled = Chk_OCICerrar.Checked
        Rdb_OCI_FEmision.Enabled = Chk_OCICerrar.Checked
        Rdb_OCI_FDespacho.Enabled = Chk_OCICerrar.Checked
    End Sub

    Private Sub Chk_OCCCerrar_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_OCCCerrar.CheckedChanged
        Input_DiasOCC.Enabled = Chk_OCCCerrar.Checked
        Rdb_OCC_FEmision.Enabled = Chk_OCCCerrar.Checked
        Rdb_OCC_FDespacho.Enabled = Chk_OCCCerrar.Checked
    End Sub

#End Region

End Class
