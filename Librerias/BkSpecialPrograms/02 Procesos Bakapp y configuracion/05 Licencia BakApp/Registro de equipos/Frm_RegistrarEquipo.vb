Imports System.Drawing.Printing
Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_RegistrarEquipo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Registrado As Boolean
    Dim _Accion As Enum_Accion
    Dim _KeyReg_Editar As String

    Dim _RowEstacion As DataRow
    Dim _RutEmpresa, _NombreEmpresa As String
    Dim _EsB4A As Boolean

    Public Enum Enum_Accion
        Nuevo
        Editar
    End Enum

    Public Property Pro_Nombre_Equipo()
        Get
            Return LblNombreEquipo.Text
        End Get
        Set(ByVal value)
            LblNombreEquipo.Text = value
        End Set
    End Property

    Public ReadOnly Property Pro_Registrado() As Boolean
        Get
            Return _Registrado
        End Get
    End Property

    Public Property Grabar As Boolean

    Public Sub New(Accion As Enum_Accion, Id_Estacion As Integer, _EsB4A As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not (_Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_EstacionesBkp", "Tiene_Lector_Huella") And
                _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_EstacionesBkp", "Lector_Huella")) Then

            Chk_Tiene_Lector_Huella.Enabled = False
            Cmb_Lector_Huella.Enabled = False

        End If

        Me._EsB4A = _EsB4A

        Sb_Actualizar_Combos_Box()

        Dim MiIp = getIp()

        Dim _Ds As New DatosBakApp

        _Accion = Accion

        If _Accion = Enum_Accion.Editar Then

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_EstacionesBkp Where Id = " & Id_Estacion
            _RowEstacion = _Sql.Fx_Get_DataRow(Consulta_sql)

            LblNombreEquipo.Text = _RowEstacion.Item("NombreEquipo")
            Txt_KeyReg.Text = _RowEstacion.Item("KeyReg")

            Txt_Alias.Text = _RowEstacion.Item("Alias")

            Cmb_TipoEstacion.SelectedValue = _RowEstacion.Item("TipoEstacion")
            Cmb_Modalidad_X_Defecto.SelectedValue = _RowEstacion.Item("Modalidad_X_Defecto")
            Cmb_Usuario_X_Defecto.SelectedValue = _RowEstacion.Item("Usuario_X_Defecto")

            Chk_Buscar_Actualizacion_En_FTP.Checked = _RowEstacion.Item("Buscar_Actualizacion_En_FTP")

            If Chk_Tiene_Lector_Huella.Enabled Then

                Chk_Tiene_Lector_Huella.Checked = _RowEstacion.Item("Tiene_Lector_Huella")
                Cmb_Lector_Huella.SelectedValue = _RowEstacion.Item("Lector_Huella")

            End If

            Txt_Modalidad_Caja.Tag = _RowEstacion.Item("Modalidad_Caja")
            Txt_Modalidad_Caja.Text = _RowEstacion.Item("Modalidad_Caja")

            Chk_Caja_Habilitada.Checked = _RowEstacion.Item("Caja_Habilitada")
            Txt_Directorio_GenDTE.Tag = _RowEstacion.Item("Directorio_GenDTE")
            Txt_Directorio_GenDTE.Text = _RowEstacion.Item("Directorio_GenDTE")

            Rdb_ImprDespGrabarCaja.Checked = _RowEstacion.Item("ImprDespGrabarCaja")
            Rdb_NO_ImprDespGrabarCaja.Checked = Not _RowEstacion.Item("ImprDespGrabarCaja")

            Chk_EsDTEMonitor.Checked = _RowEstacion.Item("EsDTEMonitor")
            Chk_DTEMonitorAmbienteCertificacion.Checked = _RowEstacion.Item("DTEMonitorAmbienteCertificacion")

            Txt_KeyReg.ReadOnly = True

        ElseIf _Accion = Enum_Accion.Nuevo Then
            BtnAceptar.Text = "Guardar"
        End If

        TextBoxX1.Text = RutEmpresa
        TextBoxX2.Text = RazonEmpresa

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnAceptar.ForeColor = Color.White
            Txt_Alias.FocusHighlightEnabled = False
            Txt_KeyReg.FocusHighlightEnabled = False
            TextBoxX1.FocusHighlightEnabled = False
            TextBoxX1.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_RegistrarEquipo_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        STab.SelectedTabIndex = 0

        If _Accion = Enum_Accion.Nuevo Then
            Tab_Empresas.Visible = False
            Tab_Configuraciones.Visible = False
            Tab_Impresoras.Visible = False
            Btn_Agregar_Impresoras.Enabled = False
        Else

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            Btn_Agregar_Impresoras.Enabled = (_NombreEquipo.ToString.Trim = LblNombreEquipo.Text.Trim)
            List_Impresoras.Items.Clear()

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_Impresoras Where NombreEquipo = '" & LblNombreEquipo.Text & "'"
            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila As DataRow In _Tbl.Rows
                List_Impresoras.Items.Add(_Fila.Item("Impresora"))
            Next

        End If

        If _EsB4A Then
            Cmb_TipoEstacion.SelectedValue = "B4A"
            Cmb_TipoEstacion.Enabled = False
            Tab_Impresoras.Visible = False
            Tab_Configuraciones.Visible = False
            Grupo_ConfCaja.Enabled = False
        End If

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        'Dim _Registro As New Frm_Licencia_Empresa
        'Dim _Licencia As String = _RutEmpresa & "@" & LblNombreEquipo.Text
        'Dim _Key As String = UCase(_Registro.Fx_Encriptar(_Licencia, "ARDILLA."))

        If Chk_Caja_Habilitada.Checked And String.IsNullOrEmpty(Txt_Modalidad_Caja.Text) Then
            MessageBoxEx.Show(Me, "Falta la modalidad para la caja del Post-Venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not Chk_Caja_Habilitada.Checked Then Txt_Modalidad_Caja.Text = String.Empty

        'Dim _RutEmpresa As String = _Sql.Fx_Trae_Dato("CONFIGP", "RUT", "EMPRESA = '01'")

        '_RutEmpresa = RutEmpresaActiva

        Dim _Cadena As String = UCase(RutEmpresa.Trim & "@" & LblNombreEquipo.Text)
        Dim _Key = Encripta_md5(_Cadena)

        '249360d48e636367b865e0bc8619065d

        'If Cmb_TipoEstacion.SelectedValue <> "B4A" Then
        If _Accion = Enum_Accion.Nuevo Then

            If Txt_KeyReg.Text <> _Key Then

                MessageBoxEx.Show(Me, "Llave de acceso no valida", "Key reg.",
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                Return

            End If

        End If

        'End If

        If Not String.IsNullOrEmpty(Txt_Alias.Text.Trim) Then

            Dim _Existe_Alias As Boolean

            _Existe_Alias = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp",
                                                 "Alias = '" & Txt_Alias.Text & "' And NombreEquipo <> '" & LblNombreEquipo.Text & "'")

            If _Existe_Alias Then
                MessageBoxEx.Show(Me, "El Alias ya existe para otro usuario" & vbCrLf & vbCrLf &
                                  "No puede haber 2 equipos con el mismo nombre de Alias", "Validación",
                                   MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Alias.Focus()
                Return
            End If

        End If


        If _Accion = Enum_Accion.Nuevo Then

            If String.IsNullOrEmpty(Txt_Alias.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el Alias de la estación de trabajo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Alias.Focus()
                Return
            End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_EstacionesBkp (NombreEquipo,TipoEstacion,KeyReg,Modalidad_X_Defecto,Usuario_X_Defecto," &
                           "Empresa_X_Defecto,Usar_Datos_X_Defecto,Alias,ImprDespGrabarCaja) VALUES" & vbCrLf &
                           "('" & LblNombreEquipo.Text & "','" & Cmb_TipoEstacion.SelectedValue & "'" &
                           ",'" & _Key & "','" & Cmb_Modalidad_X_Defecto.SelectedValue & "'" &
                           ",'" & Cmb_Usuario_X_Defecto.SelectedValue & "','" & Cmb_Empresa_X_Defecto.SelectedValue & "'" &
                           "," & Convert.ToInt32(Chk_Usar_Datos_X_Defecto.Checked) &
                           ",'" & Txt_Alias.Text.Trim & "'," & Convert.ToInt32(Rdb_ImprDespGrabarCaja.Checked) & ")"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(Me, "Equipo registrado correctamente" & vbCrLf &
                             "Como estación de trabajo tipo: " & Cmb_TipoEstacion.Text, "Registrar estación",
                             Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk)
            _Registrado = True

            Grabar = True
            Me.Close()

        ElseIf _Accion = Enum_Accion.Editar Then

            Consulta_sql = String.Empty

            Dim Identificacion = Encripta_md5(Trim(LblNombreEquipo.Text))
            Dim _Id = _RowEstacion.Item("Id")

            Dim _Tiene_Huella_Sql As String

            If Chk_Tiene_Lector_Huella.Enabled Then

                _Tiene_Huella_Sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set" & Space(1) &
                                    "Tiene_Lector_Huella = " & Convert.ToInt32(Chk_Tiene_Lector_Huella.Checked) & vbCrLf &
                                    ",Lector_Huella = '" & Cmb_Lector_Huella.SelectedValue & "'" & vbCrLf &
                                    "Where Id = " & _Id

            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set" & Space(1) &
                           "TipoEstacion = '" & Cmb_TipoEstacion.SelectedValue & "'" & vbCrLf &
                           ",KeyReg = '" & Txt_KeyReg.Text & "'" & vbCrLf &
                           ",Modalidad_X_Defecto = '" & Cmb_Modalidad_X_Defecto.SelectedValue & "'" & vbCrLf &
                           ",Usuario_X_Defecto = '" & Cmb_Usuario_X_Defecto.SelectedValue & "'" & vbCrLf &
                           ",Empresa_X_Defecto = '" & Cmb_Empresa_X_Defecto.SelectedValue & "'" & vbCrLf &
                           ",Usar_Datos_X_Defecto = " & Convert.ToInt32(Chk_Usar_Datos_X_Defecto.Checked) & vbCrLf &
                           ",Buscar_Actualizacion_En_FTP = " & Convert.ToInt32(Chk_Buscar_Actualizacion_En_FTP.Checked) & vbCrLf &
                           ",Alias = '" & Txt_Alias.Text.Trim & "'" & vbCrLf &
                           ",Directorio_GenDTE = '" & Txt_Directorio_GenDTE.Text.Trim & "'" & vbCrLf &
                           ",Modalidad_Caja = '" & Txt_Modalidad_Caja.Text.Trim & "'" & vbCrLf &
                           ",Caja_Habilitada = " & Convert.ToInt32(Chk_Caja_Habilitada.Checked) & vbCrLf &
                           ",ImprDespGrabarCaja = " & Convert.ToInt32(Rdb_ImprDespGrabarCaja.Checked) & vbCrLf &
                           ",EsDTEMonitor = " & Convert.ToInt32(Chk_EsDTEMonitor.Checked) & vbCrLf &
                           ",DTEMonitorAmbienteCertificacion = " & Convert.ToInt32(Chk_DTEMonitorAmbienteCertificacion.Checked) & vbCrLf &
                           "Where Id = " & _Id & vbCrLf & vbCrLf & _Tiene_Huella_Sql

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Estaciones_Impresoras Where NombreEquipo = '" & LblNombreEquipo.Text & "'" & vbCrLf

                For i = 1 To PrinterSettings.InstalledPrinters.Count '– 1
                    Dim _Impresora As String = PrinterSettings.InstalledPrinters.Item(i - 1).ToString
                    Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Estaciones_Impresoras (NombreEquipo,Impresora) Values " &
                        "('" & LblNombreEquipo.Text & "','" & _Impresora & "')" & vbCrLf
                Next

                _Sql.Ej_consulta_IDU(Consulta_sql)

                MessageBoxEx.Show(Me, "Actualización de estación guardada correctamente", "Tipo Estación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                Grabar = True
                Me.Close()

            End If

        End If

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Frm_RegistrarEquipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Actualizar_Impresoras_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Impresoras.Click

        'Dim _Impresora As String = String.Empty

        'Dim Fm As New Frm_Seleccionar_Impresoras("")
        'Fm.ShowDialog(Me)
        '_Impresora = Fm.Pro_Impresora_Seleccionada
        'Fm.Dispose()

        'If Not String.IsNullOrEmpty(_Impresora) Then

        '    For Each itemsinlist As ListViewItem In List_Impresoras.Items
        '        itemsinlist.Selected = False
        '        If itemsinlist.Text = _Impresora Then
        '            Return
        '        End If
        '    Next

        'End If

        'List_Impresoras.Items.Add(_Impresora)

        List_Impresoras.Items.Clear()
        For i = 1 To PrinterSettings.InstalledPrinters.Count '– 1
            'Por todas las impresoras instaladas ir agregandolas al objeto sender
            List_Impresoras.Items.Add(PrinterSettings.InstalledPrinters.Item(i - 1).ToString)
        Next
    End Sub

    Private Sub Btn_Ver_Usuarios_Diablito_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Usuarios_Diablito.Click

        Dim _Rows_Usuario_Autoriza As DataRow

        If Not Fx_Tiene_Permiso(Me, "Doc00057", FUNCIONARIO,,,,,,,, _Rows_Usuario_Autoriza) Then
            Return
        End If

        Dim _Funcionario_Autorizado = _Rows_Usuario_Autoriza.Item("KOFU")

        Dim Fm As New Frm_Demonio_05_FunConecExt(LblNombreEquipo.Text, False)
        Fm.Mostrar_Todas_Las_Impresoras_X_Usuario = True
        Fm.Funcionario_Autorizado = _Funcionario_Autorizado
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub LblNombreEquipo_Click(sender As Object, e As EventArgs) Handles LblNombreEquipo.Click

        Clipboard.SetText(LblNombreEquipo.Text.Trim)
        MessageBoxEx.Show(Me, "Nombre de equipo se encuentra en el portapapeles", "Copiar nombre de equipo",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Btn_Buscar_DirectorioDTE_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_DirectorioDTE.Click

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Existe_Archivo_GenDTE = False
        Dim _FolderBrowserDialog As New FolderBrowserDialog
        Dim _Nuevo_RunMonitor As Boolean = _Sql.Fx_Exite_Campo("CONFIGP", "VERSIONACT")

        Dim _Directorio_GenDTE As String

        Txt_Directorio_GenDTE.Text = "..."

        With _FolderBrowserDialog

            .Reset()
            ' leyenda  
            .Description = "Seleccionar una carpeta "
            ' Path " Mis documentos "  
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            ' deshabilita el botón " crear nueva carpeta "  
            .ShowNewFolderButton = False
            '.RootFolder = Environment.SpecialFolder.Desktop  
            '.RootFolder = Environment.SpecialFolder.StartMenu  

            Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

            ' si se presionó el botón aceptar ...  
            If ret = Windows.Forms.DialogResult.OK Then

                Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)
                _Directorio_GenDTE = .SelectedPath

                If _Nuevo_RunMonitor Then

                    If File.Exists(_Directorio_GenDTE & "\dte\bat\GenDTE.BAT") Then
                        _Existe_Archivo_GenDTE = True
                    End If

                Else

                    If File.Exists(_Directorio_GenDTE & "\GenDTE.BAT") Then
                        _Existe_Archivo_GenDTE = True
                    End If

                End If

            Else
                Txt_Directorio_GenDTE.Text = Txt_Directorio_GenDTE.Tag
                Return
            End If

            .Dispose()

        End With

        If _Existe_Archivo_GenDTE Then
            Txt_Directorio_GenDTE.Tag = _Directorio_GenDTE
            Txt_Directorio_GenDTE.Text = _Directorio_GenDTE
        Else
            Txt_Directorio_GenDTE.Text = Txt_Directorio_GenDTE.Tag
            MessageBoxEx.Show(Me,
                                  "No se encontro el archivo GenDTE.BAT en el directorio (" & _Directorio_GenDTE & ")" & vbCrLf &
                                  "Este archivo es necesario para la generación de documentos electrónicos en DTE RunMonitor",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Buscar_Modalidad_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Modalidad.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        Dim _Sql = "And MODALIDAD <> '  '"
        '"And MODALIDAD In (Select SUBSTRING(KOOP,4,5) As Modalidad From MAEUS Where KOUS = '" & _CodFuncionario & "' And KOOP Like 'MO-%')"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And EMPRESA = '" & ModEmpresa & "' " & _Sql,
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Modalidad_Caja.Tag = _Codigo
            Txt_Modalidad_Caja.Text = _Descripcion

        End If

    End Sub

    'Private Sub Btn_Eliminar_Impresoras_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Impresoras.Click

    '    Dim _Lista_Eliminado As List(Of Integer)

    '    For Each _Fila As ListViewItem In List_Impresoras.SelectedItems
    '        _Lista_Eliminado.Add(_Fila.Index)
    '    Next

    '    For Each _Index In _Lista_Eliminado
    '        List_Impresoras.Items.RemoveAt(_Index)
    '    Next

    'End Sub

    Sub Sb_Actualizar_Combos_Box()

        Dim _Arr_Filtro(,) As String

        If _EsB4A Then
            _Arr_Filtro = {{"B4A", "DISPOSITIVO MOVIL (B4A)"}}
            Sb_Llenar_Combos(_Arr_Filtro, Cmb_TipoEstacion)
            Cmb_TipoEstacion.SelectedValue = "B4A"
        Else
            _Arr_Filtro = {{"N", "NORMAL"},
                       {"P", "POST-VENTA"},
                       {"C", "CONSULTOR DE PRECIOS"},
                       {"C1", "CAJA PAGO DOCUMENTOS"},
                       {"Cd", "CAJA AUTOMATICA (CashDro-Transbank-Nota de crédito)"},
                       {"Dfa", "REGISTRO DE FABRICACION (DFA Producción)"},
                       {"Nvv", "SOLO NOTAS DE VENTA"},
                       {"B4A", "DISPOSITIVO MOVIL (B4A)"},
                       {"BR1", "IMPRESOR DE CODIGOS DE BARRA POR PRODUCTOS"}}
            Sb_Llenar_Combos(_Arr_Filtro, Cmb_TipoEstacion)
            Cmb_TipoEstacion.SelectedValue = "N"
        End If

        caract_combo(Cmb_Modalidad_X_Defecto)
        Consulta_sql = "SELECT '' AS Padre,'' As Hijo Union" & vbCrLf &
                       "SELECT MODALIDAD AS Padre,MODALIDAD AS Hijo FROM CONFIEST WHERE EMPRESA = '" & ModEmpresa & "'" & vbCrLf &
                       "AND MODALIDAD <> '  '"
        Cmb_Modalidad_X_Defecto.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Modalidad_X_Defecto.SelectedValue = ""

        caract_combo(Cmb_Usuario_X_Defecto)
        Consulta_sql = "SELECT '' AS Padre,'' As Hijo Union" & vbCrLf &
                       "SELECT KOFU AS Padre,KOFU+'-'+NOKOFU AS Hijo FROM TABFU WHERE INACTIVO = 0"
        Cmb_Usuario_X_Defecto.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Usuario_X_Defecto.SelectedValue = ""

        caract_combo(Cmb_Empresa_X_Defecto)
        Consulta_sql = "SELECT EMPRESA AS Padre,RTRIM(LTRIM(RUT))+'-'+RAZON AS Hijo FROM CONFIGP"
        Cmb_Empresa_X_Defecto.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Empresa_X_Defecto.SelectedValue = ModEmpresa '"01"


        Dim _Arr_Filtro_Huellas(,) As String = {{"", ""},
                                                {"UareU_4500", "Lector de huellas UareU 4500"},
                                                {"ZK4500", "Lector de huellas ZKTeco ZK4500"}}

        Sb_Llenar_Combos(_Arr_Filtro_Huellas, Cmb_Lector_Huella)
        Cmb_Lector_Huella.SelectedValue = ""

    End Sub


End Class
