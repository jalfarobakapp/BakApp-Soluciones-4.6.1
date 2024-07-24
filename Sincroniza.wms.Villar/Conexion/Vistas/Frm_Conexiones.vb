Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Conexiones

    Private _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Conexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Txt_CodFunFCVAutoContado.ButtonCustomClick, AddressOf Txt_CodFuncionario_ButtonCustomClick
        AddHandler Txt_CodFunFCVAutoContado.ButtonCustom2Click, AddressOf Txt_CodFuncionario_ButtonCustom2Click

        AddHandler Txt_CodFunFCVAutoCredito.ButtonCustomClick, AddressOf Txt_CodFuncionario_ButtonCustomClick
        AddHandler Txt_CodFunFCVAutoCredito.ButtonCustom2Click, AddressOf Txt_CodFuncionario_ButtonCustom2Click

        AddHandler Txt_CodFunGDVAutoContado.ButtonCustomClick, AddressOf Txt_CodFuncionario_ButtonCustomClick
        AddHandler Txt_CodFunGDVAutoContado.ButtonCustom2Click, AddressOf Txt_CodFuncionario_ButtonCustom2Click

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(False)

        If Not _Mensaje.EsCorrecto OrElse _Mensaje.Id = 0 Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        With _Cl_ConfiguracionLocal.Configuracion
            'Txt_NombreEquipoImprime_Retiros.Text = .NombreEquipoImprime
            'Txt_NombreEquipoImprime_Ticket.Text = .NombreEquipoImprimeTicket
            Input_DiasRevNVV.Value = .DiasRevNVV
        End With

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

            With .Item(1)
                .NombreConexion = String.Empty
                Txt_Wms_Host.Text = .Host
                Txt_Wms_Puerto.Text = .Puerto
                Txt_Wms_Usuario.Text = .Usuario
                Txt_Wms_Password.Text = .Password
                Txt_Wms_Basededatos.Text = .Basededatos
            End With

        End With

        With _Cl_ConfiguracionLocal.Configuracion.Ls_ImpFormatos

            With .Item(0)
                Chk_ImprimirRetiros.Checked = .Imprimir
                Txt_Impresora_Retiros.Text = .Impresora
                Txt_NombreFormato_Retiros.Text = .NombreFormato
                Txt_NombreEquipoImprime_Retiros.Text = .NombreEquipoImprime
            End With

            With .Item(1)
                Chk_ImprimirDespachos.Checked = .Imprimir
                Txt_Impresora_Despachos.Text = .Impresora
                Txt_NombreFormato_Despachos.Text = .NombreFormato
                Txt_NombreEquipoImprime_Despachos.Text = .NombreEquipoImprime
            End With

            With .Item(2)
                Chk_ImprimirTicket.Checked = .Imprimir
                Txt_Impresora_Ticket.Text = .Impresora
                Txt_NombreFormato_Ticket.Text = .NombreFormato
                Txt_NombreEquipoImprime_Ticket.Text = .NombreEquipoImprime
            End With

        End With

        With _Cl_ConfiguracionLocal.Configuracion.Ls_FunFcvGdvAuto

            With .Item(0)
                Txt_CodFunFCVAutoContado.Tag = .CodFuncionario
                Txt_CodFunFCVAutoContado.Text = .NomFuncionario
            End With

            With .Item(1)
                Txt_CodFunFCVAutoCredito.Tag = .CodFuncionario
                Txt_CodFunFCVAutoCredito.Text = .NomFuncionario
            End With

            With .Item(2)
                Txt_CodFunGDVAutoContado.Tag = .CodFuncionario
                Txt_CodFunGDVAutoContado.Text = .NomFuncionario
            End With

        End With

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
    Private Sub Btn_ProbarConexionWms_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionWms.Click
        Fx_ProbarConexionWms()
    End Sub

    Function Fx_ProbarConexionWms() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Wms_Host.Text, Txt_Wms_Puerto.Text, Txt_Wms_Basededatos.Text, Txt_Wms_Usuario.Text, Txt_Wms_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos de WMS)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Wms_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Wms_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

                With .Item(1)

                    .NombreConexion = "WMS"
                    .Host = Txt_Wms_Host.Text
                    .Puerto = Txt_Wms_Puerto.Text
                    .Usuario = Txt_Wms_Usuario.Text
                    .Password = Txt_Wms_Password.Text
                    .Basededatos = Txt_Wms_Basededatos.Text

                End With

            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True

    End Function

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Not Fx_RevisarImp() Then Return
        If Not Fx_ProbarConexionRd() Then Return
        If Not Fx_ProbarConexionWms() Then Return

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_ConfiguracionLocal.Fx_GrabarConexiones()

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Function Fx_RevisarImp() As Boolean

        If Chk_ImprimirRetiros.Checked Then
            If String.IsNullOrWhiteSpace(Txt_Impresora_Retiros.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre de la impresora para imprimir la lista de verificación de retiros",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Impresora_Retiros.Focus()
                Return False
            End If
            If String.IsNullOrWhiteSpace(Txt_NombreFormato_Retiros.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre del formato de la lista de verificación de retiros",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NombreFormato_Retiros.Focus()
                Return False
            End If
        End If

        If Chk_ImprimirDespachos.Checked Then
            If String.IsNullOrWhiteSpace(Txt_Impresora_Despachos.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre de la impresora para imprimir la lista de verificación de despachos",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Impresora_Despachos.Focus()
                Return False
            End If
            If String.IsNullOrWhiteSpace(Txt_NombreFormato_Despachos.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre del formato de la lista de verificación de despachos",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NombreFormato_Despachos.Focus()
                Return False
            End If
        End If

        If Chk_ImprimirRetiros.Checked Or Chk_ImprimirDespachos.Checked Then
            If String.IsNullOrWhiteSpace(Txt_NombreEquipoImprime_Retiros.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre del servidor de impresión (equipo que imprime)",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NombreEquipoImprime_Retiros.Focus()
                Return False
            End If
        End If

        '_Cl_ConfiguracionLocal.Configuracion.NombreEquipoImprime = Txt_NombreEquipoImprime_Retiros.Text
        '_Cl_ConfiguracionLocal.Configuracion.NombreEquipoImprimeTicket = Txt_NombreEquipoImprime_Ticket.Text

        With _Cl_ConfiguracionLocal.Configuracion.Ls_ImpFormatos(0)

            .Impresora = Txt_Impresora_Retiros.Text
            .Imprimir = Chk_ImprimirRetiros.Checked
            .NombreFormato = Txt_NombreFormato_Retiros.Text
            .NombreEquipoImprime = Txt_NombreEquipoImprime_Retiros.Text

        End With

        With _Cl_ConfiguracionLocal.Configuracion.Ls_ImpFormatos(1)

            .Impresora = Txt_Impresora_Despachos.Text
            .Imprimir = Chk_ImprimirDespachos.Checked
            .NombreFormato = Txt_NombreFormato_Despachos.Text
            .NombreEquipoImprime = Txt_NombreEquipoImprime_Despachos.Text

        End With

        If _Cl_ConfiguracionLocal.Configuracion.Ls_ImpFormatos.Count = 2 Then
            Dim _ImpFormatos As New ImpFormatos
            _Cl_ConfiguracionLocal.Configuracion.Ls_ImpFormatos.Add(_ImpFormatos)
        End If

        With _Cl_ConfiguracionLocal.Configuracion.Ls_ImpFormatos(2)

            .Tipo = "Ticket"
            .Impresora = Txt_Impresora_Ticket.Text
            .Imprimir = Chk_ImprimirTicket.Checked
            .NombreFormato = Txt_NombreFormato_Ticket.Text
            .NombreEquipoImprime = Txt_NombreEquipoImprime_Ticket.Text

        End With

        If IsNothing(_Cl_ConfiguracionLocal.Configuracion.Ls_FunFcvGdvAuto) Then
            _Cl_ConfiguracionLocal.Configuracion.Ls_FunFcvGdvAuto = New List(Of FunFcvGdvAuto)
        End If
        _Cl_ConfiguracionLocal.Configuracion.Ls_FunFcvGdvAuto.Clear()

        Dim _Fun As FunFcvGdvAuto

        _Fun = New FunFcvGdvAuto

        With _Fun
            .Tido = "FCV"
            .Tipo = "Contado"
            .CodFuncionario = Txt_CodFunFCVAutoContado.Tag
            .NomFuncionario = Txt_CodFunFCVAutoContado.Text
        End With

        _Cl_ConfiguracionLocal.Configuracion.Ls_FunFcvGdvAuto.Add(_Fun)

        _Fun = New FunFcvGdvAuto

        With _Fun
            .Tido = "FCV"
            .Tipo = "Credito"
            .CodFuncionario = Txt_CodFunFCVAutoCredito.Tag
            .NomFuncionario = Txt_CodFunFCVAutoCredito.Text
        End With

        _Cl_ConfiguracionLocal.Configuracion.Ls_FunFcvGdvAuto.Add(_Fun)

        _Fun = New FunFcvGdvAuto

        With _Fun
            .Tido = "GDV"
            .Tipo = ""
            .CodFuncionario = Txt_CodFunGDVAutoContado.Tag
            .NomFuncionario = Txt_CodFunGDVAutoContado.Text
        End With

        _Cl_ConfiguracionLocal.Configuracion.Ls_FunFcvGdvAuto.Add(_Fun)

        Return True

    End Function

    Private Sub Txt_Impresora_Retiros_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Impresora_Retiros.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "IMPRESORAS DISPONIBLES"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Estaciones_Impresoras"
        _Filtrar.Campo = "Impresora"
        _Filtrar.Descripcion = "Impresora"
        _Filtrar.Ver_Codigo = False

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo = '" & Txt_NombreEquipoImprime_Retiros.Text & "'",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Impresora_Retiros.Tag = _Codigo
            Txt_Impresora_Retiros.Text = _Descripcion

        End If

    End Sub

    Private Sub Txt_Impresora_Retiros_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Impresora_Retiros.ButtonCustom2Click
        Txt_Impresora_Retiros.Tag = String.Empty
        Txt_Impresora_Retiros.Text = String.Empty
    End Sub

    Private Sub Txt_Impresora_Despachos_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Impresora_Despachos.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "IMPRESORAS DISPONIBLES"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Estaciones_Impresoras"
        _Filtrar.Campo = "Impresora"
        _Filtrar.Descripcion = "Impresora"
        _Filtrar.Ver_Codigo = False

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo = '" & Txt_NombreEquipoImprime_Retiros.Text & "'",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Impresora_Despachos.Tag = _Codigo
            Txt_Impresora_Despachos.Text = _Descripcion

        End If

    End Sub

    Private Sub Txt_Impresora_Despachos_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Impresora_Despachos.ButtonCustom2Click
        Txt_Impresora_Despachos.Tag = String.Empty
        Txt_Impresora_Despachos.Text = String.Empty
    End Sub

    Private Sub Txt_NombreEquipoImprime_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Retiros.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "DESDE DONDE SE IMPRIMIRAN LOS DOCUMENTOS (Solo estaciones con Diablito)"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_EstacionesBkp"
        _Filtrar.Campo = "NombreEquipo"
        _Filtrar.Descripcion = "Alias"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo In (Select Distinct NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_Impresoras)",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_NombreEquipoImprime_Retiros.Text = _Codigo

        End If

    End Sub

    Private Sub Txt_NombreEquipoImprime_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Retiros.ButtonCustom2Click
        Txt_NombreEquipoImprime_Retiros.Tag = String.Empty
        Txt_NombreEquipoImprime_Retiros.Text = String.Empty
    End Sub

    Private Sub Txt_NombreFormato_Retiros_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreFormato_Retiros.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Seleccionar_Formato("NVV")
        Fm.ShowDialog(Me)
        If Fm.Formato_Seleccionado Then
            Txt_NombreFormato_Retiros.Tag = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            Txt_NombreFormato_Retiros.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_NombreFormato_Retiros_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_NombreFormato_Retiros.ButtonCustom2Click
        Txt_NombreFormato_Retiros.Tag = String.Empty
        Txt_NombreFormato_Retiros.Text = String.Empty
    End Sub

    Private Sub Txt_NombreFormato_Despachos_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreFormato_Despachos.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Seleccionar_Formato("NVV")
        Fm.ShowDialog(Me)
        If Fm.Formato_Seleccionado Then
            Txt_NombreFormato_Despachos.Tag = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            Txt_NombreFormato_Despachos.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_NombreFormato_Despachos_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_NombreFormato_Despachos.ButtonCustom2Click
        Txt_NombreFormato_Despachos.Tag = String.Empty
        Txt_NombreFormato_Despachos.Text = String.Empty
    End Sub

    Private Sub Txt_CodFuncionario_ButtonCustomClick(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "SELECCIONE UN FUNCIONARIO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random,
                               "",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            CType(sender, Controls.TextBoxX).Tag = _Codigo
            CType(sender, Controls.TextBoxX).Text = _Codigo & "-" & _Descripcion

        End If
    End Sub

    Private Sub Txt_CodFuncionario_ButtonCustom2Click(sender As Object, e As EventArgs)
        CType(sender, Controls.TextBoxX).Tag = String.Empty
        CType(sender, Controls.TextBoxX).Text = String.Empty
    End Sub

    Private Sub Txt_NombreEquipoImprime_Ticket_ButtonCustomClick(sender As Object, e As EventArgs)

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "DESDE DONDE SE IMPRIMIRAN LOS TICKET (Solo estaciones con Diablito)"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_EstacionesBkp"
        _Filtrar.Campo = "NombreEquipo"
        _Filtrar.Descripcion = "Alias"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo In (Select Distinct NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_Impresoras)",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_NombreEquipoImprime_Ticket.Text = _Codigo

        End If

    End Sub

    Private Sub Txt_NombreEquipoImprime_Ticket_ButtonCustom2Click(sender As Object, e As EventArgs)
        Txt_NombreEquipoImprime_Ticket.Tag = String.Empty
        Txt_NombreEquipoImprime_Ticket.Text = String.Empty
    End Sub

    Private Sub Txt_Impresora_Ticket_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Impresora_Ticket.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "IMPRESORAS DISPONIBLES"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Estaciones_Impresoras"
        _Filtrar.Campo = "Impresora"
        _Filtrar.Descripcion = "Impresora"
        _Filtrar.Ver_Codigo = False

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo = '" & Txt_NombreEquipoImprime_Ticket.Text & "'",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Impresora_Ticket.Tag = _Codigo
            Txt_Impresora_Ticket.Text = _Descripcion

        End If

    End Sub

    Private Sub Txt_Impresora_Ticket_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Impresora_Ticket.ButtonCustom2Click, Txt_NombreFormato_Ticket.ButtonCustom2Click
        Txt_Impresora_Ticket.Tag = String.Empty
        Txt_Impresora_Ticket.Text = String.Empty
    End Sub

    Private Sub Txt_NombreFormato_Ticket_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreFormato_Ticket.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Seleccionar_Formato("NVV")
        Fm.ShowDialog(Me)
        If Fm.Formato_Seleccionado Then
            Txt_NombreFormato_Ticket.Tag = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            Txt_NombreFormato_Ticket.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_NombreFormato_Ticket_ButtonCustom2Click(sender As Object, e As EventArgs)
        Txt_NombreFormato_Ticket.Tag = String.Empty
        Txt_NombreFormato_Ticket.Text = String.Empty
    End Sub

    Private Sub Txt_NombreEquipoImprime_Ticket_ButtonCustomClick_1(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Ticket.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "DESDE DONDE SE IMPRIMIRAN LOS DOCUMENTOS (Solo estaciones con Diablito)"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_EstacionesBkp"
        _Filtrar.Campo = "NombreEquipo"
        _Filtrar.Descripcion = "Alias"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo In (Select Distinct NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_Impresoras)",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_NombreEquipoImprime_Ticket.Text = _Codigo

        End If

    End Sub

    Private Sub Txt_NombreEquipoImprime_Ticket_ButtonCustom2Click_1(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Ticket.ButtonCustom2Click
        Txt_NombreEquipoImprime_Ticket.Tag = String.Empty
        Txt_NombreEquipoImprime_Ticket.Text = String.Empty
    End Sub

    Private Sub Txt_NombreEquipoImprime_Despachos_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Despachos.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "DESDE DONDE SE IMPRIMIRAN LOS DOCUMENTOS (Solo estaciones con Diablito)"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_EstacionesBkp"
        _Filtrar.Campo = "NombreEquipo"
        _Filtrar.Descripcion = "Alias"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo In (Select Distinct NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_Impresoras)",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_NombreEquipoImprime_Despachos.Text = _Codigo

        End If

    End Sub

    Private Sub Txt_NombreEquipoImprime_Despachos_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Despachos.ButtonCustom2Click
        Txt_NombreEquipoImprime_Despachos.Tag = String.Empty
        Txt_NombreEquipoImprime_Despachos.Text = String.Empty
    End Sub
End Class
