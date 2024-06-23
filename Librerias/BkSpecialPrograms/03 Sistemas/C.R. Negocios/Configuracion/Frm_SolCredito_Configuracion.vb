
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_SolCredito_Configuracion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsNegocioCr As New DsNegocioCr
    Dim _Dir_Temp = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Negocios_Cli"
    Dim _Existe = System.IO.File.Exists(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Cargar_Combos()

        If Not Directory.Exists(_Dir_Temp) Then
            System.IO.Directory.CreateDirectory(_Dir_Temp)
        End If

        _DsNegocioCr.Clear()

        With _DsNegocioCr
            If Not _Existe Then

                Dim NewFila As DataRow
                NewFila = _DsNegocioCr.Tables("Tbl_Configuracion_local").NewRow

                With NewFila

                    .Item("Ftp_Host") = String.Empty
                    .Item("Ftp_Puerto") = 21
                    .Item("Ftp_Usuario") = String.Empty
                    .Item("Ftp_Contrasena") = String.Empty

                    .Item("Direcctorio_Archivos_Adjuntos") = String.Empty
                    .Item("Correo_Al_Grabar") = String.Empty
                    .Item("Correo_Al_Cerrar") = String.Empty

                End With

                .Tables("Tbl_Configuracion_local").Rows.Add(NewFila)

                .WriteXml(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")
            Else
                .ReadXml(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")
            End If
        End With

    End Sub

    Private Sub Frm_SolCredito_Configuracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _DsNegocioCr.ReadXml(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

        Dim _Fila As DataRow = _DsNegocioCr.Tables("Tbl_Configuracion_local").Rows(0)

        Txt_Ftp_Usuario.Text = _Fila.Item("Ftp_Usuario")
        Txt_Ftp_Contrasena.Text = _Fila.Item("Ftp_Contrasena")
        Txt_Ftp_Host.Text = _Fila.Item("Ftp_Host")
        Txt_Ftp_Puerto.Text = _Fila.Item("Ftp_Puerto")

        Txt_Directorio_Seleccionado.Text = _Fila.Item("Direcctorio_Archivos_Adjuntos")
        Cmb_Correo_Al_Grabar.SelectedValue = _Fila.Item("Correo_Al_Grabar")
        Cmb_Correo_Al_Cerrar.SelectedValue = _Fila.Item("Correo_Al_Cerrar")


        'AddHandler Btn_Ruta_Directorio.Click, AddressOf Sb_Ruta_Directorio_Click

    End Sub

    Private Sub Sb_Ruta_Directorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' Configuración del FolderBrowserDialog

            If Fx_Tiene_Permiso(Me, "Ncli00005") Then

                Dim _Directorio As New FolderBrowserDialog

                With _Directorio

                    .Reset() ' resetea

                    ' leyenda
                    .Description = "Seleccionar una carpeta "
                    ' Path " Mis documentos "

                    Dim _SPath As String = Txt_Directorio_Seleccionado.Text

                    If String.IsNullOrEmpty(Txt_Directorio_Seleccionado.Text) Then
                        _SPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    End If

                    .SelectedPath = _SPath 'Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                    ' deshabilita el botón " crear nueva carpeta "
                    .ShowNewFolderButton = True
                    '.RootFolder = Environment.SpecialFolder.Desktop
                    '.RootFolder = Environment.SpecialFolder.StartMenu

                    Dim ret As DialogResult = .ShowDialog ' abre el diálogo
                    Dim _Directorio_Seleccionado As String = .SelectedPath


                    'Shell("explorer.exe " & _Directorio_Seleccionado, AppWinStyle.MaximizedFocus)

                    ' si se presionó el botón aceptar ...
                    If ret = Windows.Forms.DialogResult.OK Then
                        Txt_Directorio_Seleccionado.Text = _Directorio_Seleccionado
                        Btn_Grabar.Enabled = True
                        MessageBoxEx.Show(Me, _Directorio_Seleccionado, "Directorio seleccionado", _
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return

                        'CON ESTOS COMANDOS SE EXTRAE EL CONTENIDO DE LA CARPETA
                        Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                        nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                        MsgBox("Total de archivos: " & CStr(nFiles.Count), _
                                                MsgBoxStyle.Information)

                        'Process.Start("C:\BakApp\Empresas\Agrorama\Negocios\Ejemplo levantamiento costos.xlsx")
                    End If

                    .Dispose()

                End With
            End If

        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        'If Fx_Tiene_Permiso(Me, "Ncli00005") Then

        _DsNegocioCr.Clear()
        With _DsNegocioCr

            Dim NewFila As DataRow
            NewFila = _DsNegocioCr.Tables("Tbl_Configuracion_local").NewRow

            With NewFila

                .Item("Ftp_Host") = Txt_Ftp_Host.Text
                .Item("Ftp_Puerto") = Txt_Ftp_Puerto.Text
                .Item("Ftp_Usuario") = Txt_Ftp_Usuario.Text
                .Item("Ftp_Contrasena") = Txt_Ftp_Contrasena.Text


                .Item("Direcctorio_Archivos_Adjuntos") = Txt_Directorio_Seleccionado.Text
                .Item("Correo_Al_Grabar") = Cmb_Correo_Al_Grabar.SelectedValue
                .Item("Correo_Al_Cerrar") = Cmb_Correo_Al_Cerrar.SelectedValue

            End With
            .Tables("Tbl_Configuracion_local").Rows.Add(NewFila)

            .WriteXml(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

        End With

        ToastNotification.Show(Me, "DATOS GUARDADOS CORRECTAMENTE", My.Resources.ok_button, _
                               3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        'End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub




    Private Sub Frm_SolCredito_Configuracion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Correo_SMTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Correo_SMTP.Click
        If Fx_Tiene_Permiso(Me, "Mail0001") Then
            Dim _Correo_Grabar = Cmb_Correo_Al_Grabar.SelectedValue
            Dim _Correo_Cerrar = Cmb_Correo_Al_Cerrar.SelectedValue

            Dim Fm As New Frm_Correos_SMTP
            Fm.ShowDialog(Me)

            Sb_Cargar_Combos()

            Cmb_Correo_Al_Grabar.SelectedValue = _Correo_Grabar
            Cmb_Correo_Al_Cerrar.SelectedValue = _Correo_Cerrar
        End If
    End Sub


    Sub Sb_Cargar_Combos()

        caract_combo(Cmb_Correo_Al_Grabar)
        caract_combo(Cmb_Correo_Al_Cerrar)

        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo" & vbCrLf & _
                       "Union" & vbCrLf & _
                       "SELECT STR(Id) AS Padre,Nombre_Correo AS Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_Correos" & vbCrLf & _
                       "ORDER BY Padre"

        Cmb_Correo_Al_Grabar.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Correo_Al_Cerrar.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Private Sub Btn_Ver_Contrasena_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Contrasena.MouseDown
        Txt_Ftp_Contrasena.PasswordChar = ""
    End Sub

    Private Sub Btn_Ver_Contrasena_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Contrasena.MouseUp
        Txt_Ftp_Contrasena.PasswordChar = "*"
    End Sub

    
    Private Sub Btn_Conectar_FTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Conectar_FTP.Click
        'ftp://ftp.BAKAPP.cl/Negocios

        Dim _Dir = "ftp://" & Txt_Ftp_Host.Text & ":" & Txt_Ftp_Puerto.Text
        Dim _Carpeta = "SCN Negocios"

        Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text))

        If _Ftp.Fx_Verificar_Coneccion_FTP(Me, Txt_Ftp_Host.Text, Txt_Ftp_Puerto.Text) Then

            If _Ftp.Fx_Existe_Directorio(_Dir & "/" & _Carpeta) Then

                MessageBoxEx.Show(Me, "La carpeta ...Ftp://.../" & _Carpeta & vbCrLf & _
                                  "Esta operativa", _
                                   "Crear carpeta compartida en FTP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Txt_Directorio_Seleccionado.Text = "...Ftp://" & Txt_Ftp_Host.Text & "/" & _Carpeta
            Else

                If MessageBoxEx.Show(Me, "La carpeta [" & _Carpeta & "] no esta creada en en sitio" & vbCrLf & _
                                   "¿Desea crear esta carpeta?", "Crear carpeta en FTP", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                    Dim _Fichero_Creado = _Ftp.Fx_Crear_Directorio(_Dir & "/" & _Carpeta)

                    If String.IsNullOrEmpty(_Fichero_Creado) Then
                        MessageBoxEx.Show(Me, "Se ha creado correctamente la carpeta ...Ftp://" & Txt_Ftp_Host.Text & "/" & _Carpeta, _
                                          "Crear carpeta compartida en FTP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Txt_Directorio_Seleccionado.Text = "...Ftp://" & Txt_Ftp_Host.Text & "/" & _Carpeta
                    Else
                        MessageBoxEx.Show(Me, _Fichero_Creado, "Problemas al crear la carpeta", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

                'Dim _Lista = _Ftp.Fx_Obtener_Archivos_Directorio(_Dir)
            End If
        End If

    End Sub
End Class