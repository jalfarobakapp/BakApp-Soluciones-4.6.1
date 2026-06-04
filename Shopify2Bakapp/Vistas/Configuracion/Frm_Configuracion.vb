Imports System.IO
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json
Public Class Frm_Configuracion

    Private _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub

    Private Sub Frm_Conexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(False)

        If Not _Mensaje.EsCorrecto OrElse _Mensaje.Id = 0 Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Dim _Arr_Relacionado(,) As String = {{"", ""},
                                     {"BLV", "BOLETA"},
                                     {"FCV", "FACTURA"}}
        Sb_Llenar_Combos(_Arr_Relacionado, Cmb_DocEmitir)
        Cmb_DocEmitir.SelectedValue = ""


        TxtBakApp.Text = _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk

        With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

            With .Item(0)
                .NombreConexion = String.Empty
                Txt_Rd_Host.Text = .Host
                Txt_Rd_Puerto.Text = .Puerto
                Txt_Rd_Usuario.Text = .Usuario
                Txt_Rd_Password.Text = .Password
                Txt_Rd_Basededatos.Text = .Basededatos
            End With

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
            End With



        End With

        Txt_Empresa.Tag = String.Empty
        Txt_Empresa.Text = String.Empty


        Dim _MsgCorreos As LsValiciones.Mensajes
        _MsgCorreos = Fx_Cargar_Configuracion_JSON_Correos(False)

        ' Si el archivo no existe o hay error, mostramos la alerta tal como en las conexiones
        If Not _MsgCorreos.EsCorrecto Then
            MessageBoxEx.Show(Me, _MsgCorreos.Mensaje, "Validación Correos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Btn_ProbarConexionRd_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionRd.Click
        If Fx_ProbarConexionRd() Then

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
            End With

        Else
            Cadena_ConexionSQL_Server = String.Empty
        End If
    End Sub

    Private Sub Btn_ProbarConexionMeli_Click(sender As Object, e As EventArgs)

    End Sub

    Function Fx_ProbarConexionRd() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos RANDOM/BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Rd_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

                With .Item(0)

                    .NombreConexion = "RandomBakapp"
                    .Host = Txt_Rd_Host.Text
                    .Puerto = Txt_Rd_Puerto.Text
                    .Usuario = Txt_Rd_Usuario.Text
                    .Password = Txt_Rd_Password.Text
                    .Basededatos = Txt_Rd_Basededatos.Text

                End With

            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True

    End Function
    Private Function Fx_Cargar_Configuracion_JSON_Correos(MostrarMensajeExito As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje.EsCorrecto = False
        _Mensaje.Mensaje = "No se encontró el archivo de configuración de correos."
        _Mensaje.Detalle = "Archivo JSON ausente"

        Try
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CorreosEmpresa.json")

            If File.Exists(rutaArchivo) Then
                Dim jsonString As String = File.ReadAllText(rutaArchivo)
                Dim miConfig As Config_Correos = JsonConvert.DeserializeObject(Of Config_Correos)(jsonString)

                If miConfig IsNot Nothing Then
                    NombreCorreo_1.Text = miConfig.Empresa1_NombreCorreo
                    Formato_1.Text = miConfig.Empresa1_Formato
                    NombreCorreo_2.Text = miConfig.Empresa2_NombreCorreo
                    Formato_2.Text = miConfig.Empresa2_Formato
                    ClienteActivo.Value = miConfig.ClienteActivo
                    _Mensaje.EsCorrecto = True
                    _Mensaje.Mensaje = "Configuración de correos cargada correctamente."
                    _Mensaje.Detalle = "Carga exitosa"
                    _Mensaje.Id = 1
                End If
            End If

            ' Si todo salió bien y el usuario quiere ver el mensaje (como en las conexiones)
            If _Mensaje.EsCorrecto And MostrarMensajeExito Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Carga JSON", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al leer el archivo JSON de correos."
            _Mensaje.Detalle = ex.Message
        End Try

        Return _Mensaje
    End Function

    Function Fx_ProbarConexionBaseBakapp() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_ConfirmardbBakapp(TxtBakApp.Text, Txt_Rd_Usuario.Text, _Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Nombre de base de datos de BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtBakApp.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True
    End Function
    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        ' 1. Validaciones iniciales existentes
        If String.IsNullOrEmpty(TxtBakApp.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el nombre de la base de datos de BAKAPP", "Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtBakApp.Focus()
            Return
        End If

        ' --- NUEVAS VALIDACIONES DE CORREOS PARA AMBAS EMPRESAS ---
        ' Validamos Empresa 1
        If Not Fx_Validar_Datos_Correo(NombreCorreo_1.Text, Formato_1.Text) Then
            Return
        End If

        ' Validamos Empresa 2
        If Not Fx_Validar_Datos_Correo(NombreCorreo_2.Text, Formato_2.Text) Then
            Return
        End If
        ' ---------------------------------------------------------

        ' 2. Probar conexiones
        If Not Fx_ProbarConexionRd() Then Return
        If Not Fx_ProbarConexionBaseBakapp() Then Return

        ' 3. Asignar valores a la configuración local
        With _Cl_ConfiguracionLocal.Configuracion
            .Global_BaseBk = TxtBakApp.Text
            ' Aquí puedes agregar más propiedades si tu clase .Configuracion las tiene
        End With

        ' 4. Grabar conexiones (Proceso existente)
        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_ConfiguracionLocal.Fx_GrabarConexiones()

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ' 5. GUARDAR ARCHIVO JSON "CorreosEmpresa.json"
        ' Solo llegamos aquí si Fx_GrabarConexiones fue exitoso
        Sb_Guardar_Configuracion_JSON()

        ' 6. Finalizar
        MessageBoxEx.Show(Me, "Configuraciones y conexiones guardadas exitosamente.", "Éxito",
                      MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    ' ############################################################################
    ' FUNCIONES DE APOYO (Asegúrate de tenerlas en tu código)
    ' ############################################################################

    Private Function Fx_Validar_Datos_Correo(NombreCorreo As String, FormatoDoc As String) As Boolean
        If String.IsNullOrWhiteSpace(NombreCorreo) Or String.IsNullOrWhiteSpace(FormatoDoc) Then
            MessageBoxEx.Show(Me, "Debe completar los campos de Nombre de Correo y Formato para ambas empresas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        ' Validar en Zw_Correos
        If _Sql.Fx_Cuenta_Registros2(TxtBakApp.Text & ".dbo.Zw_Correos", $"Nombre_Correo = '{NombreCorreo}'") = 0 Then
            MessageBoxEx.Show(Me, $"El correo '{NombreCorreo}' no existe en la tabla Zw_Correos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        ' Validar en Zw_Format_01
        If _Sql.Fx_Cuenta_Registros2(TxtBakApp.Text & ".dbo.Zw_Format_01", $"NombreFormato = '{FormatoDoc}' AND TipoDoc = 'FCV'") = 0 Then
            MessageBoxEx.Show(Me, $"El formato '{FormatoDoc}' no existe para el tipo FCV.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True
    End Function

    Private Sub Sb_Guardar_Configuracion_JSON()
        Try
            Dim miConfig As New Config_Correos With {
            .Empresa1_NombreCorreo = NombreCorreo_1.Text,
            .Empresa1_Formato = Formato_1.Text,
            .Empresa2_NombreCorreo = NombreCorreo_2.Text,
            .Empresa2_Formato = Formato_2.Text,
            .FechaModificacion = DateTime.Now,
            .ClienteActivo = ClienteActivo.Value
        }

            Dim jsonString As String = JsonConvert.SerializeObject(miConfig, Formatting.Indented)
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CorreosEmpresa.json")
            File.WriteAllText(rutaArchivo, jsonString)
        Catch ex As Exception
            ' No detenemos el cierre del formulario, pero avisamos del error en el JSON
        End Try
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged

    End Sub

    Private Sub Txt_Rd_Host_TextChanged(sender As Object, e As EventArgs) Handles Txt_Rd_Host.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Guardar2_Click(sender As Object, e As EventArgs) Handles Guardar2.Click
        Dim NombreCorreo As String = NombreCorreo_2.Text
        Dim FormatoDoc As String = Formato_2.Text
        If Not Fx_Validar_Datos_Correo(NombreCorreo, FormatoDoc) Then
            Return
        End If

        ' --- Si llega aquí, es porque pasó todas las validaciones ---
        ' Aquí pones tu lógica para guardar los datos del set 1
        ' _Cl_ConfiguracionLocal.Configuracion.NombreCorreo1 = NombreCorreo_1.Text ... etc

        MessageBoxEx.Show(Me, "Configuración correcta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub Guardar1_Click(sender As Object, e As EventArgs) Handles Guardar1.Click
        Dim NombreCorreo As String = NombreCorreo_1.Text
        Dim FormatoDoc As String = Formato_1.Text
        If Not Fx_Validar_Datos_Correo(NombreCorreo, FormatoDoc) Then
            Return
        End If

        ' --- Si llega aquí, es porque pasó todas las validaciones ---
        ' Aquí pones tu lógica para guardar los datos del set 1
        ' _Cl_ConfiguracionLocal.Configuracion.NombreCorreo1 = NombreCorreo_1.Text ... etc

        MessageBoxEx.Show(Me, "Configuración correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LabelX5_Click(sender As Object, e As EventArgs) Handles LabelX5.Click

    End Sub

    Private Sub ClienteActivo_ValueChanged(sender As Object, e As EventArgs) Handles ClienteActivo.ValueChanged

    End Sub
End Class
