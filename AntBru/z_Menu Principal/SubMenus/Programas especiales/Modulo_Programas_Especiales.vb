Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_Programas_Especiales

    Public Dst_Lic As Object
    Dim NotifyIcon1 As NotifyIcon '= _Fm_Menu_Padre.Notify_Demonio
    Dim _Huella As String

    Dim _Fm_Menu_Padre As Metro.MetroAppForm
    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

        If Global_Thema = Enum_Themas.Oscuro Then
            Sb_Color_Botones_Barra(Bar2)
        End If

    End Sub

    Private Sub Sistemas_Especiales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If _Menu_Extra Then
            'Btn_Demonio.Enabled = False
        Else
            'NotifyIcon1 = Frm_Menu.Notify_Demonio
        End If

    End Sub

    Private Sub BtnPicking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Demonio.Click
        Fx_Ejecutar_Demonio2(_Fm_Menu_Padre, True)
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnDTE2PDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDTE2PDF.Click

        Dim NewPanel As Dte2Imp_ = Nothing
        NewPanel = New Dte2Imp_()
        NewPanel.FmPrincipal = _Fm_Menu_Padre
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnSQL2Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSQL2Excel.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Sql00001") Then
            Dim Fm As New Frm_SQL2Excel_Consultas
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    'Private Sub BtnCreditoNegocios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreditoNegocios.Click

    '    If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Scn00001") Then

    '        Dim NewPanel As CreditosNegociosMnu = Nothing
    '        NewPanel = New CreditosNegociosMnu(_Fm_Menu_Padre)
    '        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    '    End If

    'End Sub

    Private Sub BtnCorreos_SMTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCorreos_SMTP.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Mail0001") Then

            Dim Fm As New Frm_Correos_SMTP
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub BtnCambiarDeUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarDeUsuario.Click
        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub

    Private Function Fx_CheckForm(ByVal _form As Form) As Form

        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return f
            End If
        Next

        Return Nothing

    End Function

    Private Sub Btn_CRV_Control_Ruta_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CRV_Control_Ruta_Vehiculos.Click

        Dim NewPanel As CRV_Control_Ruta_Vehiculos = Nothing
        NewPanel = New CRV_Control_Ruta_Vehiculos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)

    End Sub

    Private Sub Btn_Etiquetas_De_Barra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Etiquetas_De_Barra.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Espr0003") Or Fx_Tiene_Permiso(_Fm_Menu_Padre, "7Brr0001") Then

            Dim NewPanel As Sistema_CodBarras = Nothing
            NewPanel = New Sistema_CodBarras(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub

    Private Sub BtnCrearFormatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrearFormatos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Fmto0001") Then

            Dim Fm As New Frm_ImpresionDoc_Lista
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_DTE_Respuestas_XML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_DTE_Respuestas_XML.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Mail0005") Then

            Dim Fm As New Frm_Recibir_Correos_DTE
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Precios_PrestaShop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Precios_PrestaShop.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pshop001") Then

            Dim NewPanel As Modulo_Prestashop = Nothing
            NewPanel = New Modulo_Prestashop(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub


    Private Sub Btn_Huella_Click(sender As Object, e As EventArgs) Handles Btn_Huella.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Espr0031") Then

            'Dim NewPanel As Modulo_Huellas = Nothing
            'NewPanel = New Modulo_Huellas(_Fm_Menu_Padre)
            '_Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

            Dim Fm As New Frm_Huellas_Menu
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

        'Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        'Dim Consulta_Sql As String



        'Return

        'Dim _Verificado As Boolean
        'Dim _Registrado As Boolean

        'Dim _Msg = MessageBoxEx.Show(Me, "(YES) = Registrar" & vbCrLf &
        '                             "(NO) = Verificar", "Lector de huellas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        'Dim Fm As Frm_Huella_Identificar
        'If _Msg = DialogResult.Yes Then
        '    _Huella = String.Empty
        '    Fm = New Frm_Huella_Identificar(_Fm_Menu_Padre, _Huella, False, False, Frm_Huella_Identificar.Enum_Accion.Registrar)
        'ElseIf _Msg = DialogResult.No Then
        '    If Not String.IsNullOrEmpty(_Huella) Then
        '        Fm = New Frm_Huella_Identificar(_Fm_Menu_Padre, _Huella, False, False, Frm_Huella_Identificar.Enum_Accion.Verificar)
        '    Else
        '        MessageBoxEx.Show(Me, "Debe registrar una huella", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Return
        '    End If
        'Else
        '    Return
        'End If
        ''Dim Fm As New Frm_Huella_Identificar(_Huella, False, False, Frm_Huella_Identificar.Enum_Accion.Registrar)
        'Fm.ShowDialog(Me)
        '_Verificado = Fm.Pro_Verificado
        '_Registrado = Fm.Pro_Registrado
        'If _Registrado Then _Huella = Fm.Pro_Huella
        'Fm.Dispose()

        'If _Registrado Then
        '    Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_Huellas Where Funcionario = '" & FUNCIONARIO & "'" & vbCrLf &
        '                   "Insert Into " & _Global_BaseBk & "Zw_Usuarios_Huellas (Funcionario,Huella) Values ('" & FUNCIONARIO & "','" & _Huella & "')"
        '    _Sql.Ej_consulta_IDU(Consulta_Sql)
        '    MessageBox.Show(Me, "Huella registrada correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        'If _Verificado Then
        '    MessageBox.Show(Me, "La huella es correcta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

        ''If _Registrado Then
        ''MessageBoxEx.Show(Me, "Registro guardado correctamente", "Lector de huella", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''End If

    End Sub

    Private Sub Btn_Pocket_PC_Click(sender As Object, e As EventArgs) Handles Btn_Pocket_PC.Click
        Dim Fm As New Frm_Pocket_Dispositivos
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_SisReclamos_Click(sender As Object, e As EventArgs)

        'If Fx_Tiene_Permiso(Me, "Rcl00001") Then
        Dim NewPanel As Sistema_Reclamos = Nothing
        NewPanel = New Sistema_Reclamos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Archivador_Click(sender As Object, e As EventArgs) Handles Btn_Archivador.Click

        Dim Fm As New Frm_Archivador_Buscador
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Cierre_Reactivacion_Documentos_Click(sender As Object, e As EventArgs) Handles Btn_Cierre_Reactivacion_Documentos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Doc00011") Then

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(True)
            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "NVV", "Where TIDO In ('COV','NVI','NVV','OCC')")
            _Fm.Rdb_Estado_Todos.Enabled = False
            _Fm.Rdb_Estado_Vigente.Checked = True
            _Fm.Abrir_Cerrar_Documentos_Compromiso = True
            _Fm.ShowDialog(_Fm_Menu_Padre)
            _Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Habilitar_Nvv_Para_Facturar_Click(sender As Object, e As EventArgs) Handles Btn_Habilitar_Nvv_Para_Facturar.Click

        If Not _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then
            MessageBoxEx.Show(Me, "Esta opción no esta habilitada." & vbCrLf &
                              "Para poder habilitar esta opción debe hacerlo desde la Modalidad General",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        'Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        'Dim Consulta_sql As String

        'Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        'Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Docu_Ent Where FunAutorizaFac = '" & _NombreEquipo & "'"
        'Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        'If Not IsNothing(_Row) Then

        '    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Ent (Idmaeedo,NombreEquipo,TipoEstacion,Empresa,Modalidad,Tido,Nudo,FechaHoraGrab,HabilitadaFac,FunAutorizaFac) " & vbCrLf &
        '                   "Select Distinct Edo.IDMAEEDO,'@AUTO','N','" & ModEmpresa & "','" & Modalidad & "',Edo.TIDO,Edo.NUDO,Edo.FEEMDO,0,''" & vbCrLf &
        '                   "From MAEEDO Edo" & vbCrLf &
        '                   "Inner Join MAEDDO Ddo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
        '                   "Where Edo.TIDO = 'NVV' And FEEMDO > '20230301' And " & vbCrLf &
        '                   "Edo.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Docu_Ent Where Tido = 'NVV') And (Edo.KOFUDO = '" & FUNCIONARIO & "' Or Ddo.KOFULIDO = '" & FUNCIONARIO & "')" & vbCrLf &
        '                   "And Ddo.ESLIDO = ''"
        '    _Sql.Ej_consulta_IDU(Consulta_sql)

        'End If

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "NVV", "Where TIDO = 'NVV'")
        _Fm.Rdb_Estado_Todos.Enabled = False
        _Fm.Rdb_Estado_Vigente.Checked = True
        _Fm.Rdb_Estado_Cerradas.Enabled = False
        _Fm.HabilitarNVVParaFacturar = True
        _Fm.Rdb_Funcionarios_Uno.Checked = True
        _Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True
        _Fm.Chk_Mostrar_Vales_Transitorios.Checked = False
        _Fm.Chk_Mostrar_Vales_Transitorios.Enabled = False
        _Fm.ShowDialog(_Fm_Menu_Padre)
        _Fm.Dispose()

        'End If

    End Sub

    Private Sub Btn_ControlRutaVehiculos_Click(sender As Object, e As EventArgs)
        Dim NewPanel As CRV_Control_Ruta_Vehiculos = Nothing
        NewPanel = New CRV_Control_Ruta_Vehiculos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub
End Class
