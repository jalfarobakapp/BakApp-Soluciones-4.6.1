Imports System.IO
Imports BkSpecialPrograms
Imports BkSpecialPrograms.Frm_Filtro_Especial_Informes
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json

Public Class Frm_Configuracion
    Dim _SqlRandom As Class_SQL
    Private _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal
    Dim uf As DataTable
    Dim euro As DataTable
    Dim dolar As DataTable
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
        ' --- LÓGICA DE CARGA Y VALIDACIÓN DE MONEDAS ---
        If Not String.IsNullOrEmpty(Cadena_ConexionSQL_Server) Then
            SeleccionDeMonedas.Visible = True
            ' Validar si el archivo JSON de monedas existe y tiene datos
            Dim _MensajeMonedas As LsValiciones.Mensajes = Fx_LeerArchivoMonedasJson()

            If Not _MensajeMonedas.EsCorrecto Then
                MessageBoxEx.Show(Me, _MensajeMonedas.Mensaje, "Validación de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' Si falta la configuración, te lleva directo a la pestaña de monedas para arreglarlo
                SuperTabControl1.SelectedTab = SeleccionDeMonedas
            Else
                euro = _MensajeMonedas.Tag.eur
                dolar = _MensajeMonedas.Tag.usd
                uf = _MensajeMonedas.Tag.uf
            End If

        Else
            SeleccionDeMonedas.Visible = False
        End If
        ' ---------------------------------------------------------
    End Sub

    ' --- NUEVA LÓGICA: Bloquear pestaña al modificar cualquier dato de conexión ---
    Private Sub Conexion_TextChanged(sender As Object, e As EventArgs) Handles Txt_Rd_Host.TextChanged, Txt_Rd_Puerto.TextChanged, Txt_Rd_Usuario.TextChanged, Txt_Rd_Password.TextChanged, Txt_Rd_Basededatos.TextChanged, TxtBakApp.TextChanged
        ' Si la pestaña existe y está visible, la ocultamos porque se modificó la conexión
        If SeleccionDeMonedas IsNot Nothing AndAlso SeleccionDeMonedas.Visible Then
            SeleccionDeMonedas.Visible = False
        End If
    End Sub
    ' ------------------------------------------------------------------------------

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
    Private Sub Sb_Guardar_Configuracion_JSON()
        Try
            Dim miConfig As New MonedasDiccionario With {
            .uf = uf,
            .eur = euro,
            .usd = dolar
        }

            Dim jsonString As String = JsonConvert.SerializeObject(miConfig, Formatting.Indented)
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Monedas.json")
            File.WriteAllText(rutaArchivo, jsonString)
        Catch ex As Exception
            ' No detenemos el cierre del formulario, pero avisamos del error en el JSON
        End Try
    End Sub
    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click
        ' 1. Validaciones iniciales existentes
        If String.IsNullOrEmpty(TxtBakApp.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el nombre de la base de datos de BAKAPP", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtBakApp.Focus()
            Return
        End If

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

        ' 6. Finalizar
        MessageBoxEx.Show(Me, "Configuraciones y conexiones guardadas exitosamente.", "Éxito",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)



        ' --- LÓGICA ACTUALIZADA: Validar visibilidad antes de cerrar ---
        If Not SeleccionDeMonedas.Visible Then
            ' Si la pestaña estaba oculta, la habilitamos y evitamos cerrar el formulario
            SeleccionDeMonedas.Visible = True
            SuperTabControl1.SelectedTab = SeleccionDeMonedas ' Salto automático a la pestaña
            Return
        Else
            If dolar Is Nothing OrElse dolar.Rows.Count = 0 Then
                MessageBoxEx.Show(Me, "Debe configurar el filtro para la moneda Dólar usando su respectivo botón.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ButtonUSD.Focus()
                Return
            End If

            If euro Is Nothing OrElse euro.Rows.Count = 0 Then
                MessageBoxEx.Show(Me, "Debe configurar el filtro para la moneda Euro usando su respectivo botón.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ButtonEUR.Focus()
                Return
            End If

            If uf Is Nothing OrElse uf.Rows.Count = 0 Then
                MessageBoxEx.Show(Me, "Debe configurar el filtro para la moneda UF usando su respectivo botón.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ButtonUF.Focus()
                Return
            End If
            Sb_Guardar_Configuracion_JSON()

            Me.Close()
        End If
        ' -----------------------------------------------------------------------------

    End Sub


    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs)
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

    Private Sub LabelX5_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub ClienteActivo_ValueChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Bar1_ItemClick(sender As Object, e As EventArgs) Handles Bar1.ItemClick
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub
    Function Fx_LeerArchivoMonedasJson() As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Monedas.json")

            ' 1. Validar si el archivo existe
            If Not File.Exists(rutaArchivo) Then
                _Mensaje.Detalle = "Falta archivo de configuración"
                Throw New System.Exception("Debe configurar la asignación de monedas (UF, Dólar, Euro).")
            End If

            ' 2. Leer el archivo y deserializar
            Dim jsonString As String = File.ReadAllText(rutaArchivo)
            Dim miConfig As MonedasDiccionario = JsonConvert.DeserializeObject(Of MonedasDiccionario)(jsonString)

            ' 3. Validar que los datos internos no estén vacíos
            If miConfig.uf Is Nothing OrElse miConfig.uf.Rows.Count = 0 OrElse
               miConfig.eur Is Nothing OrElse miConfig.eur.Rows.Count = 0 OrElse
               miConfig.usd Is Nothing OrElse miConfig.usd.Rows.Count = 0 Then

                _Mensaje.Detalle = "Datos incompletos"
                Throw New System.Exception("Faltan monedas por configurar. Por favor, asigne las monedas correspondientes.")
            End If
            _Mensaje.Tag = miConfig
            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Monedas leídas correctamente"

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonUF.Click

        Dim _Sql_Filtro_Condicion_Extra As String = "TIMO = 'E'"
        Dim _Tbl_Filtro As DataTable = uf
        Dim _Aceptar As DialogResult

        Dim Fm As New Frm_Filtro_Especial_Informes(_Tabla_Fl._Otra,, "", "TABMO", "KOMO", "NOKOMO")
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.ShowDialog(Me)
        _Aceptar = Fm.DialogResult
        _Tbl_Filtro = Fm.Pro_Tbl_Filtro
        Fm.Dispose()

        If _Aceptar = DialogResult.OK Then

            If Not IsNothing(_Tbl_Filtro) Then
                uf = _Tbl_Filtro
            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonEUR.Click
        Dim _Sql_Filtro_Condicion_Extra As String = "TIMO = 'E'"
        Dim _Tbl_Filtro As DataTable = euro
        Dim _Aceptar As DialogResult

        Dim Fm As New Frm_Filtro_Especial_Informes(_Tabla_Fl._Otra,, "", "TABMO", "KOMO", "NOKOMO")
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.ShowDialog(Me)
        _Aceptar = Fm.DialogResult
        _Tbl_Filtro = Fm.Pro_Tbl_Filtro
        Fm.Dispose()

        If _Aceptar = DialogResult.OK Then

            If Not IsNothing(_Tbl_Filtro) Then
                euro = _Tbl_Filtro
            End If

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonUSD.Click
        Dim _Sql_Filtro_Condicion_Extra As String = "TIMO = 'E'"
        Dim _Tbl_Filtro As DataTable = dolar
        Dim _Aceptar As DialogResult

        Dim Fm As New Frm_Filtro_Especial_Informes(_Tabla_Fl._Otra,, "", "TABMO", "KOMO", "NOKOMO")
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.ShowDialog(Me)
        _Aceptar = Fm.DialogResult
        _Tbl_Filtro = Fm.Pro_Tbl_Filtro
        Fm.Dispose()

        If _Aceptar = DialogResult.OK Then

            If Not IsNothing(_Tbl_Filtro) Then
                dolar = _Tbl_Filtro
            End If

        End If

    End Sub

    Private Sub GroupBox2_Enter_1(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
