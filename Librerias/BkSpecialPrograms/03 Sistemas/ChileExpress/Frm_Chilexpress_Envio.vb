Imports DevComponents.DotNetBar

Public Class Frm_Chilexpress_Envio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Cl_Chilexpress As Clas_CliexpressAPI
    Dim _Key_Cotizador As String
    Dim _Key_Cobertura As String
    Dim _Key_Envio As String
    Dim _TCC As String
    Dim _Rut_Seller As String
    Dim _Rut_Mark As String

    Dim _Idenvio As Integer
    Dim _Referencia As String
    Dim _Peso As Double
    Dim _Alto As Double
    Dim _Largo As Double
    Dim _Ancho As Double
    Dim _Nombre_Destino As String
    Dim _Telefono_Destino As String
    Dim _Correo_Destino As String
    Dim _Valor_Declarado As Double
    Dim _Detalle_Productos As String

    Public Property Referencia As String
        Get
            _Referencia = Txt_Referencia.Text
            Return _Referencia
        End Get
        Set(value As String)
            _Referencia = value
            Txt_Referencia.Text = _Referencia
        End Set
    End Property

    Public Property Peso As Double
        Get
            Return Txt_Peso.Tag
        End Get
        Set(value As Double)
            _Peso = value
            Txt_Peso.Tag = _Peso
            Txt_Peso.Text = _Peso
        End Set
    End Property

    Public Property Alto As Double
        Get
            Return Txt_Alto.Tag
        End Get
        Set(value As Double)
            _Alto = value
            Txt_Alto.Tag = _Alto
            Txt_Alto.Text = _Alto
        End Set
    End Property

    Public Property Largo As Double
        Get
            Return Txt_Largo.Tag
        End Get
        Set(value As Double)
            _Largo = value
            Txt_Largo.Tag = _Largo
            Txt_Largo.Text = _Largo
        End Set
    End Property

    Public Property Ancho As Double
        Get
            Return _Ancho
        End Get
        Set(value As Double)
            _Ancho = value
            Txt_Ancho.Tag = _Ancho
            Txt_Ancho.Text = _Ancho
        End Set
    End Property

    Public Property Nombre_Destino As String
        Get
            Return Txt_Nombre_Destino.Text
        End Get
        Set(value As String)
            _Nombre_Destino = value
            Txt_Nombre_Destino.Text = _Nombre_Destino
        End Set
    End Property

    Public Property Telefono_Destino As String
        Get
            Return Txt_Telefono_Destino.Text
        End Get
        Set(value As String)
            _Telefono_Destino = value
            Txt_Telefono_Destino.Text = _Telefono_Destino
        End Set
    End Property

    Public Property Correo_Destino As String
        Get
            Return Txt_Correo_Destino.Text
        End Get
        Set(value As String)
            _Correo_Destino = value
            Txt_Correo_Destino.Text = _Correo_Destino
        End Set
    End Property

    Public Property Valor_Declarado As Double
        Get
            Return Txt_Valor.Tag
        End Get
        Set(value As Double)
            _Valor_Declarado = value
            Txt_Valor.Tag = _Valor_Declarado
            Txt_Valor.Text = FormatNumber(_Valor_Declarado, 0)
        End Set
    End Property

    Public Property Idenvio As Integer
        Get
            Return _Idenvio
        End Get
        Set(value As Integer)
            _Idenvio = value
        End Set
    End Property

    Public Property Detalle_Productos As String
        Get
            Return _Detalle_Productos
        End Get
        Set(value As String)
            _Detalle_Productos = value
        End Set
    End Property

    Public Sub New(_Key_Cotizador As String, _Key_Cobertura As String, _Key_Envio As String, _TCC As String, _Rut_Seller As String, _Rut_Mark As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Key_Cotizador = _Key_Cotizador
        Me._Key_Cobertura = _Key_Cobertura
        Me._Key_Envio = _Key_Envio
        Me._TCC = _TCC
        Me._Rut_Seller = _Rut_Seller
        Me._Rut_Mark = _Rut_Mark

        Sb_Limpiar()

        Sb_Formato_Generico_Grilla(Grilla_Oficinas_Chilexpress, 15, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

        AddHandler Txt_Numero_Origen.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Numero_Destino.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros

    End Sub

    Private Sub Frm_Chilexpress_Envio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.Default
        AddHandler Grilla_Oficinas_Chilexpress.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Btn_Ver_Detalle_Productos.Visible = Not (String.IsNullOrEmpty(_Detalle_Productos.Trim))
    End Sub

    Sub Sb_Limpiar()

        Tab_Producto.Enabled = True

        Tabs.SelectedTabIndex = 0

        Cl_Chilexpress = New Clas_CliexpressAPI()
        Cl_Chilexpress.Fx_Establecer_Conexion()
        Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Regiones

        caract_combo(Cmb_Region_Destino, "regionId", "regionName")
        Cmb_Region_Destino.DataSource = _Tbl
        Cmb_Region_Destino.SelectedValue = "RM"

        caract_combo(Cmb_Region_Origen, "regionId", "regionName")
        Cmb_Region_Origen.DataSource = _Tbl
        Cmb_Region_Origen.SelectedValue = "RM"

        Txt_Numero_Destino.Text = String.Empty
        Txt_Calle_Destino.Text = String.Empty
        Txt_Dpto_Destino.Text = String.Empty
        Cmb_Calles.DataSource = Nothing
        Cmb_Numeros.DataSource = Nothing
        Sw_Calle_Manual.Value = True
        Cmb_Numeros.Visible = False

        Txt_Nombre_Destino.Text = String.Empty
        Txt_Telefono_Destino.Text = String.Empty
        Txt_Correo_Destino.Text = String.Empty

        Txt_Referencia.Text = String.Empty

        Tab_Destinatario.Enabled = False
        Tab_Cotizacion.Enabled = False
        'Tab_Envio.Enabled = False

        Btn_Atras.Enabled = False
        Btn_Aceptar_Cotizacion.Visible = False
        'Se habilita para activar envios pendientes
        Tab_Envio.Enabled = True
        'LlenarGrillaEnvios()

        With My.Settings
            Txt_Contacto_Origen.Text = .Contacto_Origen
            Txt_Numero_Origen.Text = .Numero_Origen
            Txt_Dpto_Origen.Text = .Dpto_Origen
            Txt_Telefono_Origen.Text = .Telefono_Origen
            Txt_Correo_Origen.Text = .Correo_Origen
            Cmb_Region_Origen.SelectedValue = .Cod_Region_Origen
            Cmb_Comuna_Origen.SelectedValue = .Cod_Comuna_Origen
            Txt_Direccion_Origen.Text = .Direccion_Origen
            Sb_Cargar_Direccion_Origen()
            'Cmb_Direccion_Origen.SelectedValue = .Cod_Direccion_Origen
        End With

        Cmb_Producto.SelectedValue = 4

    End Sub

    Private Sub Cmb_Region_Origen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Region_Origen.SelectedIndexChanged
        If Tabs.SelectedTabIndex <> 0 Then
            Return
        End If

        Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Comunas(Cmb_Region_Origen.SelectedValue)
        caract_combo(Cmb_Comuna_Origen, "countyCode", "countyName")
        Cmb_Comuna_Origen.DataSource = _Tbl
        Cmb_Comuna_Origen.SelectedValue = ""
    End Sub

    Private Sub Btn_Siguiente_Click(sender As Object, e As EventArgs) Handles Btn_Siguiente.Click

        Select Case Tabs.SelectedTabIndex

            Case 0

                If Not Fx_Revisar_Datos_Tab_Productos() Then
                    Return
                End If

                Tab_Producto.Enabled = False

                If String.IsNullOrEmpty(Cmb_Comuna_Destino.Text) Then

                    Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Comunas(Cmb_Region_Destino.SelectedValue)
                    caract_combo(Cmb_Comuna_Destino, "countyCode", "countyName")
                    Cmb_Comuna_Destino.DataSource = _Tbl
                    Cmb_Comuna_Destino.SelectedValue = ""

                End If

                Tab_Destinatario.Enabled = True
                Tabs.SelectedTabIndex = 1
                Txt_Nombre_Destino.Focus()
                Btn_Atras.Enabled = True
                Btn_Aceptar_Cotizacion.Visible = False
                Me.Refresh()

            Case 1

                If Not Fx_Revisar_Datos_Tab_Destinatario() Then
                    Return
                End If

                Dim _Destino As String

                _Destino = Cmb_Comuna_Destino.SelectedValue

                Dim _CodComunaOrigen As String = Cmb_Comuna_Origen.SelectedValue
                Dim _CodComunaDestino As String = Cmb_Comuna_Destino.SelectedValue
                Dim _Peso As String = Txt_Peso.Text
                Dim _Alto As String = Txt_Alto.Text
                Dim _Ancho As String = Txt_Ancho.Text
                Dim _Largo As String = Txt_Largo.Text
                Dim _CodTipoProducto As String
                Dim _Valor As String = Txt_Valor.Text
                Dim _CodTipoEnvio = 0

                If Tabs_Tipo_Despacho.SelectedTabIndex = 0 Then
                    If Not IsNumeric(Txt_Numero_Destino.Text) Then
                        MessageBoxEx.Show(Me, "El número de la dirección solo puede contener numeros" & vbCrLf &
                                          "Si necesita ingresar un complemento debe ingresarlo en Dpto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Txt_Numero_Destino.Focus()
                        Return
                    End If
                End If

                If Rdb_Documentos.Checked Then
                    If Val(Txt_Peso.Text) > 5 Then
                        MessageBoxEx.Show(Me, "El tamano maximo de documentos es de 5kg", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                    _CodTipoProducto = Rdb_Documentos.Tag
                End If

                If Rdb_Valijas.Checked Then _CodTipoProducto = Rdb_Valijas.Tag
                If Rdb_Encomiendas.Checked Then _CodTipoProducto = Rdb_Encomiendas.Tag

                Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Cotizar(_CodComunaOrigen, _CodComunaDestino, _Peso, _Alto, _Ancho, _Largo, _CodTipoProducto, _Valor, _CodTipoEnvio)

                Dim _CmpChk As DataColumn

                _CmpChk = New DataColumn(0, Type.GetType("System.Boolean"))
                _CmpChk.ColumnName = "Chk"
                _Tbl.Columns.Add(_CmpChk)

                Dim _CmpValor As DataColumn

                _CmpChk = New DataColumn(0, Type.GetType("System.Double"))
                _CmpChk.ColumnName = "Valor"
                _Tbl.Columns.Add(_CmpChk)

                Grilla_Cotizacion.DataSource = _Tbl

                For Each _Fl As DataRow In _Tbl.Rows
                    _Fl.Item("Valor") = Convert.ToDouble(_Fl.Item("ServiceValue"))
                Next

                OcultarEncabezadoGrilla(Grilla_Cotizacion, True)
                Dim _DisplayIndex = 0

                With Grilla_Cotizacion

                    .Columns("Chk").Width = 30
                    .Columns("Chk").HeaderText = "Sel."
                    .Columns("Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Chk").ReadOnly = False
                    .Columns("Chk").Visible = True
                    .Columns("Chk").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("ServiceDescription").Width = 200
                    .Columns("ServiceDescription").HeaderText = "Servicio"
                    .Columns("ServiceDescription").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("ServiceDescription").Visible = True
                    .Columns("ServiceDescription").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("Valor").Width = 100
                    .Columns("Valor").HeaderText = "Valor"
                    .Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Valor").DefaultCellStyle.Format = "###,##0.##"
                    .Columns("Valor").Visible = True
                    .Columns("Valor").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End With


                If Not CBool(_Tbl.Rows.Count) Then
                    MessageBoxEx.Show(Me, Cl_Chilexpress.StatusDescription, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Btn_Aceptar_Cotizacion.Visible = False

                Tab_Cotizacion.Enabled = True
                Tab_Destinatario.Enabled = False
                Tabs.SelectedTabIndex = 2
                Btn_Aceptar_Cotizacion.Visible = True
                Btn_Siguiente.Enabled = False

        End Select

        Me.Refresh()

    End Sub


    Function Fx_Revisar_Datos_Tab_Productos() As Boolean

        Txt_Peso.Tag = De_Txt_a_Num_01(Txt_Peso.Text, 3)
        Txt_Alto.Tag = De_Txt_a_Num_01(Txt_Alto.Text, 3)
        Txt_Ancho.Tag = De_Txt_a_Num_01(Txt_Ancho.Text, 3)
        Txt_Largo.Tag = De_Txt_a_Num_01(Txt_Largo.Text, 3)

        If String.IsNullOrEmpty(Cmb_Region_Origen.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una región", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If String.IsNullOrEmpty(Cmb_Comuna_Origen.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una comuna", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Direccion_Origen.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta la dirección de devolución", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Direccion_Origen.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Numero_Origen.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el número de la dirección de devolución", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Numero_Origen.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Contacto_Origen.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el nombre del contacto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Contacto_Origen.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Telefono_Origen.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el teléfono del contacto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Telefono_Origen.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Correo_Origen.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el correo del contacto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Correo_Origen.Focus()
            Return False
        End If

        If Not Fx_Validar_Email(Txt_Correo_Origen.Text.Trim) Then
            MessageBoxEx.Show(Me, "El correo del contacto no es una cuenta de correo electrónico valida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Correo_Origen.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Referencia.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta la referencia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Referencia.Focus()
            Return False
        End If

        If Txt_Peso.Tag = 0 Then
            MessageBoxEx.Show(Me, "Falta el peso del bulto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Peso.Focus()
            Return False
        End If

        If Txt_Alto.Tag = 0 Then
            MessageBoxEx.Show(Me, "Falta el alto del bulto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Alto.Focus()
            Return False
        End If

        If Txt_Ancho.Tag = 0 Then
            MessageBoxEx.Show(Me, "Falta el ancho del bulto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Ancho.Focus()
            Return False
        End If

        If Txt_Largo.Tag = 0 Then
            MessageBoxEx.Show(Me, "Falta el largo del bulto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Largo.Focus()
            Return False
        End If

        With My.Settings
            .Contacto_Origen = Txt_Contacto_Origen.Text
            .Numero_Origen = Txt_Numero_Origen.Text
            .Dpto_Origen = Txt_Dpto_Origen.Text
            .Telefono_Origen = Txt_Telefono_Origen.Text
            .Correo_Origen = Txt_Correo_Origen.Text
            .Cod_Region_Origen = Cmb_Region_Origen.SelectedValue
            .Cod_Comuna_Origen = Cmb_Comuna_Origen.SelectedValue
            .Cod_Direccion_Origen = Cmb_Direccion_Origen.SelectedValue
            .Direccion_Origen = Txt_Direccion_Origen.Text
            .Save()
        End With

        Return True
    End Function

    Function Fx_Revisar_Datos_Tab_Destinatario() As Boolean

        If String.IsNullOrEmpty(Txt_Nombre_Destino.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el nombre del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Nombre_Destino.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Telefono_Destino.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el teléfono del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Telefono_Destino.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Correo_Destino.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el correo del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Correo_Destino.Focus()
            Return False
        End If

        If Not Fx_Validar_Email(Txt_Correo_Destino.Text.Trim) Then
            MessageBoxEx.Show(Me, "El correo del destinatario no es una cuenta de correo electrónico valida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Correo_Destino.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Cmb_Producto.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el tipo de producto a enviar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Cmb_Producto.Focus()
            Return False
        End If

        If Val(Txt_Valor.Text) = 0 Then
            MessageBoxEx.Show(Me, "Falta el valor declarado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Valor.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Cmb_Region_Destino.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una región", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If String.IsNullOrEmpty(Cmb_Comuna_Destino.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una comuna", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If Tabs_Tipo_Despacho.SelectedTabIndex = 0 Then ' Rdb_Domicilio.Checked Then

            If String.IsNullOrEmpty(Txt_Calle_Destino.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre de la calle del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Calle_Destino.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(Txt_Numero_Destino.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el número de la calle del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Numero_Destino.Focus()
                Return False
            End If

        End If

        If Tabs_Tipo_Despacho.SelectedTabIndex = 1 Then ' Rdb_Oficina_Chilexpress.Checked Then

            If String.IsNullOrEmpty(Txt_Oficina_Seleccionada.Text.Trim) Then
                MessageBoxEx.Show(Me, "Debe seleccionar una oficina de Chilexpress", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Numero_Destino.Focus()
                Return False
            End If

        End If

        Return True

    End Function

    Function Fx_Revisar_Datos_Tab_Cotizacion() As Boolean
        Dim Count As Integer = 0
        For Each row As DataGridViewRow In Grilla_Cotizacion.Rows()
            If Not IsDBNull(row.Cells("Chk").Value) Then
                If row.Cells("Chk").Value = True Then
                    Count += 1
                End If
            End If
        Next
        If Count = 0 Then
            MessageBoxEx.Show(Me, "Debe seleccionar una cotizacion de Chilexpress", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        Return True
    End Function

    Private Sub Fx_Generar_Cotizacion_Guardar_Envio()

        Dim NewCl As New Enti_Cotizacion

        With NewCl

            .RegionOrigen1 = Cmb_Region_Origen.SelectedValue
            .ComunaOrigen1 = Cmb_Comuna_Origen.SelectedValue
            .DireccionOrigen1 = Txt_Direccion_Origen.Text
            .NumeroOrigen1 = Txt_Numero_Origen.Text
            .ComplementoOrigen1 = Txt_Dpto_Origen.Text
            .ContactoOrigen1 = Txt_Contacto_Origen.Text
            .TelefonoOrigen1 = Txt_Telefono_Origen.Text
            .CorreoOrigen1 = Txt_Correo_Origen.Text
            .Referencia1 = Txt_Referencia.Text
            .Peso1 = Txt_Peso.Text
            .Alto1 = Txt_Alto.Text
            .Largo1 = Txt_Largo.Text
            .Ancho1 = Txt_Ancho.Text
            .ContactoDestino1 = Txt_Nombre_Destino.Text
            .TelefonoDestino1 = Txt_Telefono_Destino.Text
            .CorreoDestino1 = Txt_Correo_Destino.Text

            If Rdb_Documentos.Checked Then .Producto1 = Rdb_Documentos.Tag
            If Rdb_Valijas.Checked Then .Producto1 = Rdb_Valijas.Tag
            If Rdb_Encomiendas.Checked Then .Producto1 = Rdb_Encomiendas.Tag

            If Tabs_Tipo_Despacho.SelectedTabIndex = 1 Then

                Dim _Fila As DataGridViewRow = Grilla_Oficinas_Chilexpress.Rows(Grilla_Oficinas_Chilexpress.CurrentRow.Index)

                Txt_Id_Oficina.Text = _Fila.Cells("officeCode").Value.ToString().Trim
                Txt_Calle_Destino.Text = _Fila.Cells("StreetName").Value.ToString().Trim
                Txt_Numero_Destino.Text = _Fila.Cells("StreetNumber").Value.ToString().Trim
                Txt_Dpto_Destino.Text = _Fila.Cells("Complement").Value.ToString().Trim

            End If

            .Contenido1 = Cmb_Producto.SelectedIndex + 1
            .Valor1 = Txt_Valor.Text
            .RegionDestino1 = Cmb_Region_Destino.SelectedValue
            .ComunaDestino1 = Cmb_Comuna_Destino.SelectedValue
            .DireccionDestino1 = Txt_Calle_Destino.Text
            .NumeroDestino1 = Txt_Numero_Destino.Text
            .ComplementoDestino1 = Txt_Dpto_Destino.Text
            .Id_oficina1 = Txt_Id_Oficina.Text
            .EntregaOficina1 = "false"

            If Not String.IsNullOrEmpty(.Id_oficina1) Then .EntregaOficina1 = "true"

            For Each row As DataGridViewRow In Grilla_Cotizacion.Rows()
                If Not IsDBNull(row.Cells("Chk").Value) Then
                    If row.Cells("Chk").Value = True Then
                        .IdServicio1 = row.Cells("serviceTypeCode").Value
                        .TipoServicio1 = row.Cells("ServiceDescription").Value
                        .CostoServicio1 = row.Cells("Valor").Value
                    End If
                End If
            Next

        End With

        'Dim Respuesta As String = Cl_Chilexpress.Fx_Guardar_Envio(NewCl)

        _Idenvio = Cl_Chilexpress.Fx_Guardar_Envio(NewCl)

        If CBool(_Idenvio) Then 'Respuesta = "OK" Then
            MessageBoxEx.Show(Me, "El envio fue mandado a revision", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBoxEx.Show(Me, Cl_Chilexpress.Errors, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Sb_Limpiar()
        'LlenarGrillaEnvios()

    End Sub
    'Private Sub LlenarGrillaEnvios()
    '    Try
    '        Dim consulta As String = "SELECT * FROM [SIERRALTA_PRB].[dbo].[ENVIOSCHILEXPRESS]"
    '        Cl_Chilexpress.LlenarGrilla(consulta, GrillaEnvios)
    '    Catch ex As Exception

    '        MsgBox(ex.Message)
    '    End Try
    'End Sub


    Private Sub Cmb_Region_Destino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Region_Destino.SelectedIndexChanged
        If Tabs.SelectedTabIndex <> 1 Then
            Return
        End If

        Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Comunas(Cmb_Region_Destino.SelectedValue)
        caract_combo(Cmb_Comuna_Destino, "countyCode", "countyName")
        Cmb_Comuna_Destino.DataSource = _Tbl
        Cmb_Comuna_Destino.SelectedValue = ""
    End Sub

    Private Sub Cmb_Comuna_Destino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Comuna_Destino.SelectedIndexChanged

        Me.Cursor = Cursors.WaitCursor

        Txt_Numero_Destino.Text = String.Empty
        Txt_Calle_Destino.Text = String.Empty
        Txt_Dpto_Destino.Text = String.Empty
        Cmb_Calles.DataSource = Nothing
        Cmb_Numeros.DataSource = Nothing
        Sw_Calle_Manual.Value = True

        'If Rdb_Domicilio.Checked Then

        'End If

        If Tabs_Tipo_Despacho.SelectedTabIndex = 1 Then ' Rdb_Oficina_Chilexpress.Checked Then
            If Not String.IsNullOrEmpty(Cmb_Comuna_Destino.Text.Trim) Then
                Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Oficinas_Chilexpress(Cmb_Region_Destino.SelectedValue, Cmb_Comuna_Destino.Text)
                Txt_Oficina_Seleccionada.Text = String.Empty
                Grilla_Oficinas_Chilexpress.DataSource = _Tbl
                Dim _DisplayIndex = 0
                With Grilla_Cotizacion

                    .Columns("Chk").Width = 30
                    .Columns("Chk").HeaderText = "Sel."
                    .Columns("Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Chk").ReadOnly = False
                    .Columns("Chk").Visible = True
                    .Columns("Chk").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("ServiceDescription").Width = 200
                    .Columns("ServiceDescription").HeaderText = "Servicio"
                    .Columns("ServiceDescription").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("ServiceDescription").Visible = True
                    .Columns("ServiceDescription").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("Valor").Width = 100
                    .Columns("Valor").HeaderText = "Valor"
                    .Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Valor").DefaultCellStyle.Format = "###,##0.##"
                    .Columns("Valor").Visible = True
                    .Columns("Valor").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End With

                If Not CBool(_Tbl.Rows.Count) Then
                    MessageBoxEx.Show(Me, Cl_Chilexpress.StatusDescription, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Txt_Calle_Destino_TextChanged(sender As Object, e As EventArgs) Handles Txt_Calle_Destino.TextChanged
        Txt_Numero_Destino.Text = String.Empty
        Cmb_Numeros.Visible = False
        Txt_Dpto_Destino.Text = String.Empty
        Sw_Calle_Manual.Value = True
    End Sub

    Private Sub Txt_Numero_Destino_TextChanged(sender As Object, e As EventArgs) Handles Txt_Numero_Destino.TextChanged
        If Val(Txt_Numero_Destino.Tag) <> 0 Then
            Cmb_Numeros.Visible = False
        End If
        Sw_Calle_Manual.Value = True
    End Sub

    Private Sub Cmb_Calles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Calles.SelectedIndexChanged
        Txt_Calle_Destino.Text = Cmb_Calles.Text
    End Sub

    Private Sub Cmb_Numeros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Numeros.SelectedIndexChanged
        Txt_Numero_Destino.Text = Cmb_Numeros.Text
        Sw_Calle_Manual.Value = False

        If Txt_Numero_Destino.Tag <> 0 Then
            Cmb_Numeros.Visible = False
        End If
        Txt_Numero_Destino.Tag = Txt_Numero_Destino.Text
    End Sub

    Private Sub Grilla_Oficinas_Chilexpress_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Oficinas_Chilexpress.CellDoubleClick
        Dim _Fila As DataGridViewRow = Grilla_Oficinas_Chilexpress.Rows(Grilla_Oficinas_Chilexpress.CurrentRow.Index)

        Dim _Id_Oficina = _Fila.Cells("officeCode").Value.ToString().Trim
        Dim _Calle = _Fila.Cells("StreetName").Value.ToString().Trim
        Dim _Numero = _Fila.Cells("StreetNumber").Value.ToString().Trim
        Dim _Complemento = _Fila.Cells("Complement").Value.ToString().Trim
        Txt_Id_Oficina.Text = _Id_Oficina
        Txt_Oficina_Seleccionada.Text = _Calle & " N° " & _Numero & " " & _Complemento
    End Sub

    Private Sub Txt_Direccion_Origen_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Direccion_Origen.KeyDown

        If e.KeyValue = Keys.Enter Then
            Sb_Cargar_Direccion_Origen()
        End If

    End Sub

    Sub Sb_Cargar_Direccion_Origen()

        Me.Cursor = Cursors.WaitCursor

        If String.IsNullOrEmpty(Cmb_Comuna_Origen.Text) Then
            Txt_Calle_Destino.Text = String.Empty
            MessageBoxEx.Show(Me, "Debe seleccionar una comuna de destino", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Cmb_Comuna_Origen.Focus()
            Return
        End If

        Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Calles(Cmb_Comuna_Origen.Text, Txt_Direccion_Origen.Text)

        If Not CBool(_Tbl.Rows.Count) Then
            _Tbl = Nothing
        End If
        caract_combo(Cmb_Direccion_Origen, "streetId", "streetName")
        Cmb_Direccion_Origen.DataSource = _Tbl

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Cmb_Direccion_Origen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Direccion_Origen.SelectedIndexChanged
        Txt_Direccion_Origen.Text = Cmb_Direccion_Origen.Text
    End Sub

    Private Sub Cmb_Comuna_Origen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Comuna_Origen.SelectedIndexChanged
        Txt_Direccion_Origen.Text = String.Empty
        Cmb_Direccion_Origen.DataSource = Nothing
        Txt_Direccion_Origen.Focus()
    End Sub

    Private Sub Txt_Calle_Destino_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Calle_Destino.KeyDown

        If e.KeyValue = Keys.Enter Then

            Me.Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(Cmb_Comuna_Destino.Text) Then
                Txt_Calle_Destino.Text = String.Empty
                MessageBoxEx.Show(Me, "Debe seleccionar una comuna de destino", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Cmb_Comuna_Destino.Focus()
                Return
            End If

            Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Calles(Cmb_Comuna_Destino.Text, Txt_Calle_Destino.Text.Trim)

            If Not CBool(_Tbl.Rows.Count) Then
                _Tbl = Nothing
            End If
            caract_combo(Cmb_Calles, "streetId", "streetName")
            Cmb_Calles.DataSource = _Tbl

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub Txt_Numero_Destino_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Numero_Destino.KeyDown

        If e.KeyValue = Keys.Enter Then

            Me.Cursor = Cursors.WaitCursor

            Dim _idCalle As Integer = Cmb_Calles.SelectedValue ' Grilla_Calles.CurrentRow().Cells(0).Value.ToString()
            Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Nro_Calles(_idCalle, Txt_Numero_Destino.Text)

            Txt_Numero_Destino.Tag = 0

            Sw_Calle_Manual.Value = Not (_Tbl.Rows.Count = 1)

            If Not CBool(_Tbl.Rows.Count) Then
                MessageBoxEx.Show(Me, Cl_Chilexpress.StatusDescription, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _Tbl = Nothing
            Else
                If _Tbl.Rows.Count > 1 Then
                    MessageBoxEx.Show(Me, "No se encontro la calle exacta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cmb_Numeros.Visible = True
                End If
                caract_combo(Cmb_Numeros, "addressId", "number")
            End If

            Cmb_Numeros.DataSource = _Tbl

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub Tabs_TabIndexChanged(sender As Object, e As EventArgs) Handles Tabs.TabIndexChanged
        If Tabs.SelectedTabIndex = 0 Then
            Tab_Cotizacion.Enabled = False
            Tab_Destinatario.Enabled = False
            Tab_Envio.Enabled = False
        End If
    End Sub

    Private Sub Btn_Atras_Click(sender As Object, e As EventArgs) Handles Btn_Atras.Click

        Select Case Tabs.SelectedTabIndex

            Case 1

                'boton atras
                Tab_Producto.Enabled = True
                Tab_Destinatario.Enabled = False
                Btn_Aceptar_Cotizacion.Visible = False
                Tabs.SelectedTabIndex = 0

            Case 2

                Tab_Destinatario.Enabled = True
                Tab_Cotizacion.Enabled = False
                Btn_Aceptar_Cotizacion.Visible = False
                Btn_Siguiente.Enabled = True
                Tabs.SelectedTabIndex = 1

            Case 3
                Tab_Cotizacion.Enabled = True
                Tab_Envio.Enabled = False
                Btn_Aceptar_Cotizacion.Visible = False
                Tabs.SelectedTabIndex = 2

        End Select

    End Sub

    Private Sub Tabs_Tipo_Despacho_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles Tabs_Tipo_Despacho.SelectedTabChanged

        Grilla_Oficinas_Chilexpress.DataSource = Nothing
        Txt_Oficina_Seleccionada.Text = String.Empty

        If Tabs_Tipo_Despacho.SelectedTabIndex = 1 Then

            Me.Cursor = Cursors.WaitCursor

            Txt_Numero_Destino.Text = String.Empty
            Txt_Calle_Destino.Text = String.Empty
            Txt_Dpto_Destino.Text = String.Empty
            Cmb_Calles.DataSource = Nothing
            Cmb_Numeros.DataSource = Nothing
            Sw_Calle_Manual.Value = True

            If Not String.IsNullOrEmpty(Cmb_Comuna_Destino.Text.Trim) Then
                Dim _Tbl As DataTable = Cl_Chilexpress.Fx_Traer_Oficinas_Chilexpress(Cmb_Region_Destino.SelectedValue, Cmb_Comuna_Destino.Text)
                Txt_Oficina_Seleccionada.Text = String.Empty
                Grilla_Oficinas_Chilexpress.DataSource = _Tbl

                Dim _DisplayIndex = 0
                With Grilla_Oficinas_Chilexpress

                    OcultarEncabezadoGrilla(Grilla_Oficinas_Chilexpress)

                    .Columns("officeName").Width = 210
                    .Columns("officeName").HeaderText = "Oficina"
                    .Columns("officeName").Visible = True
                    .Columns("officeName").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("streetName").Width = 200
                    .Columns("streetName").HeaderText = "Calle"
                    .Columns("streetName").Visible = True
                    .Columns("streetName").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("streetNumber").Width = 50
                    .Columns("streetNumber").HeaderText = "Nro"
                    .Columns("streetNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("streetNumber").Visible = True
                    .Columns("streetNumber").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("complement").Width = 100
                    .Columns("complement").HeaderText = "Local"
                    .Columns("complement").Visible = True
                    .Columns("complement").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End With


                If Not CBool(_Tbl.Rows.Count) Then
                    MessageBoxEx.Show(Me, Cl_Chilexpress.StatusDescription, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub Tabs_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles Tabs.SelectedTabChanged
        Btn_Atras.Enabled = Not (Tabs.SelectedTabIndex = 0)
    End Sub

    Private Sub Grilla_Cotizacion_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla_Cotizacion.MouseUp

        Dim _Cabeza = Grilla_Cotizacion.Columns(Grilla_Cotizacion.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Chk" Then
            Grilla_Cotizacion.EndEdit()
            Dim _Fila As DataGridViewRow = Grilla_Cotizacion.Rows(Grilla_Cotizacion.CurrentRow.Index)
            Dim _ServiceDescription = _Fila.Cells("ServiceDescription").Value

            For Each _Fl As DataGridViewRow In Grilla_Cotizacion.Rows
                If _Fl.Cells("ServiceDescription").Value <> _ServiceDescription Then _Fl.Cells("Chk").Value = False
            Next
        End If

    End Sub

    Private Sub Btn_Aceptar_Cotizacion_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar_Cotizacion.Click
        If Not Fx_Revisar_Datos_Tab_Cotizacion() Then
            Return
        End If
        Btn_Aceptar_Cotizacion.Visible = True
        'Tab_Envio.Enabled = True
        Tab_Cotizacion.Enabled = False
        Tab_Destinatario.Enabled = False
        'Btn_Siguiente.Enabled = False
        'Tabs.SelectedTabIndex = 3
        Fx_Generar_Cotizacion_Guardar_Envio()
    End Sub

    Private Sub GrillaEnvios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaEnvios.CellDoubleClick
        Btn_Aceptar_Cotizacion.Visible = True
    End Sub

    Private Sub Btn_Ver_Detalle_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Detalle_Productos.Click

        Dim Fmx As New Frm_Archivo_TXT
        Fmx.Pro_Nombre_Archivo = "ProdSinDimensiones.txt"
        Fmx.Pro_Texto_Log = _Detalle_Productos
        Fmx.ShowDialog(Me)
        Fmx.Dispose()

    End Sub
End Class
