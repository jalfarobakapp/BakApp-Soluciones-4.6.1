Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Observaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Matriz_Documentos As DataSet

    Dim _Row_Entidad As DataRow
    Dim _Row_Encabezado As DataRow
    Dim _Row_Observaciones As DataRow
    Dim _Row_PermisosNecesarios As DataRow

    Dim _Grabar As Boolean
    Dim _Preguntar_Grabar_Sin_Observaciones As Boolean
    Dim _TblObservaciones As DataTable
    Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento
    Dim _Grabar_Doc_Reserva_OCC As Boolean
    Dim _Solo_Grabar As Boolean
    Dim _Grabar_Y_Pagar_Vale As Boolean

    Dim _Class_Referencias_DTE As Class_Referencias_DTE

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public Property Pro_Preguntar_Grabar_Sin_Observaciones() As Boolean
        Get
            Return _Preguntar_Grabar_Sin_Observaciones
        End Get
        Set(ByVal value As Boolean)
            _Preguntar_Grabar_Sin_Observaciones = value
        End Set
    End Property

    Public Property Pro_Class_Referencias_DTE As Class_Referencias_DTE
        Get
            Return _Class_Referencias_DTE
        End Get
        Set(value As Class_Referencias_DTE)
            _Class_Referencias_DTE = value
        End Set
    End Property

    Public Property Grabar_Doc_Reserva_OCC As Boolean
        Get
            Return _Grabar_Doc_Reserva_OCC
        End Get
        Set(value As Boolean)
            _Grabar_Doc_Reserva_OCC = value
        End Set
    End Property

    Public Property Solo_Grabar As Boolean
        Get
            Return _Solo_Grabar
        End Get
        Set(value As Boolean)
            _Solo_Grabar = value
        End Set
    End Property

    Public Property Grabar_Y_Pagar_Vale As Boolean
        Get
            Return _Grabar_Y_Pagar_Vale
        End Get
        Set(value As Boolean)
            _Grabar_Y_Pagar_Vale = value
        End Set
    End Property

    Public Property TieneOrdenDeDespacho As Boolean
    Public Property CambiarFechaEnDetalle As Boolean

    Public Sub New(Ds_Matriz_Documentos As DataSet,
                   Row_Entidad As DataRow,
                   Tipo_Documento As csGlobales.Enum_Tipo_Documento,
                   Documento_Autorizado As Boolean)


        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Obs_Adicionales, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Tipo_Documento = Tipo_Documento

        _Ds_Matriz_Documentos = Ds_Matriz_Documentos
        _Row_Entidad = Row_Entidad

        _Row_Encabezado = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)
        _Row_Observaciones = _Ds_Matriz_Documentos.Tables("Observaciones_Doc").Rows(0)

        DtpFechaEntrega.Value = NuloPorNro(_Row_Encabezado.Item("FechaRecepcion"), Now.Date)

        TxtObservaciones.Text = _Row_Observaciones.Item("Observaciones")
        TxtFormadepago.Text = _Row_Observaciones.Item("Forma_pago")
        TxtOrdendecompra.Text = _Row_Observaciones.Item("Orden_compra")

        Txt_Placa.Text = _Row_Observaciones.Item("Placa")
        Txt_CodRetirador.Text = _Row_Observaciones.Item("CodRetirador")
        Lbl_Nombre_Retirador_Mercaderia.Text = _Sql.Fx_Trae_Dato("TABRETI", "NORETI", "KORETI = '" & Txt_CodRetirador.Text & "'")

        Dim _Vizado = _Row_Encabezado.Item("Vizado")

        DtpFechaEntrega.Enabled = Not _Vizado

        _TblObservaciones = Fx_Crear_Tabla()

        Dim _Tido = _Row_Encabezado.Item("TipoDoc")

        If _Tido = "NCV" Then
            If Not Fx_Tiene_Permiso(Me, "Doc00074",, False) Then
                Documento_Autorizado = False
            End If
        End If

        If Global_Thema = Enum_Themas.Oscuro Then

            If Not Documento_Autorizado Then
                Btn_Grabar_e_Imprimir.ImageAlt = My.Resources.Recursos_Documento.save_warning___copia
                Btn_Solo_Grabar.ImageAlt = My.Resources.Recursos_Documento.save_warning___copia
            End If

        Else

            If Not Documento_Autorizado Then
                Btn_Grabar_e_Imprimir.Image = My.Resources.Recursos_Documento.save_warning
                Btn_Solo_Grabar.Image = My.Resources.Recursos_Documento.save_warning
            End If

        End If

        If _Row_Encabezado.Item("SubTido") <> "SOC" Then
            Warning_Visado.Visible = _Row_Encabezado.Item("Vizado")
        End If

        Sb_Color_Botones_Barra(Bar2)

        Btn_Solo_Grabar.Visible = Btn_Grabar_e_Imprimir.Visible

        TxtObservaciones.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub Frm_Formulario_Observaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla_Obs_Adicionales.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If _Row_Encabezado.Item("SubTido") <> "SOC" Then

            If Warning_Visado.Visible Then
                Warning_Visado.Visible = _Row_Encabezado.Item("Vizado")
            End If

        End If

        With Grilla_Obs_Adicionales

            .DataSource = _TblObservaciones

            OcultarEncabezadoGrilla(Grilla_Obs_Adicionales, True)

            .Columns("Descripcion").HeaderText = "Descripción observaciones"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").Width = 600
            .Columns("Descripcion").ReadOnly = True

        End With

        Me.ActiveControl = TxtObservaciones

        Btn_Referencias_DTE.Visible = (_Row_Encabezado.Item("Tipo_Documento") = csGlobales.Enum_Tipo_Documento.Venta.ToString)

        If _Row_Encabezado.Item("TipoDoc") = "BLV" Then
            Btn_Referencias_DTE.Visible = False
        End If

        If Not IsNothing(_Class_Referencias_DTE) Then

            Dim _Row() = _Class_Referencias_DTE.Tbl_Referencias.Select("TpoDocRef = 801")

            TxtOrdendecompra.Enabled = Not Convert.ToBoolean(_Row.Count)

        End If

        If _Grabar_Doc_Reserva_OCC Then
            Btn_Grabar_e_Imprimir.Text = "RESERVAR"
            Btn_Grabar_e_Imprimir.Tooltip = "Grabar Reservar Nro. de orden de compra"
        End If

        If Btn_Grabar_Pagar.Visible Then
            If _Global_Row_EstacionBk.Item("ImprDespGrabarCaja") Then
                Btn_Grabar_Pagar.Text = "Grabar, Pagar e Imprimir"
            End If
        End If

        If CBool(_Row_Encabezado.Item("Es_ValeTransitorio")) Then

            Btn_Grabar_e_Imprimir.Tooltip = "Grabar Vale Transitorio e imprimir"
            Btn_Grabar_e_Imprimir.Image = My.Resources.Recursos_Documento.bill_credit_card_printer
            Btn_Grabar_e_Imprimir.ImageAlt = My.Resources.Recursos_Documento.bill_credit_card_printer___copia

            Btn_Solo_Grabar.Tooltip = "Grabar Vale Transitorio - ( Sin imprimir )"
            Btn_Solo_Grabar.Image = My.Resources.Recursos_Documento.bill_credit_card_save
            Btn_Solo_Grabar.ImageAlt = My.Resources.Recursos_Documento.bill_credit_card_save___copia

        End If

        Btn_GDI_GTI.Visible = False

        If _Row_Encabezado.Item("TipoDoc") = "GDI" Then

            Btn_GDI_GTI.Visible = True

            If _Row_Encabezado.Item("Subtido") = "GTI" Then
                Btn_GDI_GTI.Text = "Se grabara GDI modo traspaso interno"
            Else
                Btn_GDI_GTI.Text = "Grabar GDI modo traspaso interno"
            End If

        End If

    End Sub


    Function Fx_Grabar_Observaciones() As Boolean

        Dim _Caracteres As Integer = Len(Trim(TxtObservaciones.Text))
        Dim _Con_Observaciones = 0

        Dim _FechaEmision As Date = FormatDateTime(_Row_Encabezado.Item("FechaEmision"), DateFormat.ShortDate)
        Dim _FechaRecepcion As Date = FormatDateTime(_Row_Encabezado.Item("FechaRecepcion"), DateFormat.ShortDate)
        Dim _FechaEntregaRecepcion As Date = FormatDateTime(DtpFechaEntrega.Value, DateFormat.ShortDate)
        Dim _FechaMaxRecepcion As Date = _Row_Encabezado.Item("FechaMaxRecepcion")

        Dim _TblPermisos As DataTable = _Ds_Matriz_Documentos.Tables("Permisos_Doc")

        If _FechaEntregaRecepcion < _FechaEmision Then

            MessageBoxEx.Show(Me, "La fecha de recepción/despacho no puede ser menor a la fecha de emisión del documento", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            DtpFechaEntrega.Value = _Row_Encabezado.Item("FechaRecepcion")
            Return False

        End If

        Dim _TblDetalle As DataTable = _Ds_Matriz_Documentos.Tables("Detalle_Doc")

        For Each _Fila As DataRow In _TblDetalle.Rows

            Try

                If CambiarFechaEnDetalle Or
                    (FormatDateTime(DtpFechaEntrega.Value, DateFormat.ShortDate) <> FormatDateTime(_Row_Encabezado.Item("FechaRecepcion"), DateFormat.ShortDate)) Then
                    _Fila.Item("FechaRecepcion") = DtpFechaEntrega.Value
                Else
                    Dim _Feerli = NuloPorNro(_Fila.Item("FechaRecepcion"), "Nulo")

                    If _Feerli = "Nulo" Then
                        _Fila.Item("FechaRecepcion") = DtpFechaEntrega.Value
                    End If
                End If

            Catch ex As Exception

            End Try

        Next

        If _Caracteres <= 250 Then

            Dim _i = 0

            With _Row_Observaciones

                Dim _Tido = _Row_Encabezado.Item("TipoDoc")

                Select Case _Tido
                    Case "NCV"
                        If Not Fx_Agregar_Permiso_Otorgado_Al_Documento(Me, _TblPermisos, "Doc00074", _Ds_Matriz_Documentos, "", "") Then
                            Return False
                        End If
                End Select

                Select Case _Tido

                    Case "BLV", "FCV", "NVV"

                        'If _FechaEntregaRecepcion > _FechaMaxRecepcion Then

                        '    MessageBoxEx.Show(Me, "La fecha de recepción/despacho no puede se mayor a " & _FechaMaxRecepcion & vbCrLf &
                        '                      "Debera solicitar permiso para grabar el documento.", "Validación",
                        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        'End If


                        TxtOrdendecompra.Text = TxtOrdendecompra.Text.Trim

                        If String.IsNullOrEmpty(TxtOrdendecompra.Text) Then

                            If Not Fx_Agregar_Permiso_Otorgado_Al_Documento(Me, _TblPermisos, "Doc00024", _Ds_Matriz_Documentos, "", "") Then
                                _Class_Referencias_DTE.Sb_Eliminar_Todas_Las_Referencias()

                                TxtOrdendecompra.Focus()
                                Return False
                            End If

                            'If Not Fx_Tiene_Permiso(Me, "Doc00024") Then

                            '    _Class_Referencias_DTE.Sb_Eliminar_Todas_Las_Referencias()

                            '    TxtOrdendecompra.Focus()
                            '    Return False

                            'End If

                        Else

                            Consulta_sql = "Select Top 1 Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.FEEMDO,Edo.KOFUDO,Tf.NOKOFU" & vbCrLf &
                                           "From MAEEDO Edo" & vbCrLf &
                                           "Inner Join MAEEDOOB Obs On Edo.IDMAEEDO = Obs.IDMAEEDO" & vbCrLf &
                                           "Left Join TABFU Tf On Tf.KOFU = Edo.KOFUDO" & vbCrLf &
                                           "Where Edo.TIDO In ('NVV','FCV','GDV','BLV') And Edo.ENDO = '" & _Row_Entidad.Item("KOEN") & "' And Obs.OCDO = '" & TxtOrdendecompra.Text.Trim & "'" & vbCrLf &
                                           "Order By Edo.IDMAEEDO"

                            Dim _RowNVVConOCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            If Not IsNothing(_RowNVVConOCC) Then
                                If MessageBoxEx.Show(Me, "El número de orden de compra ya fue relacionado anteriormente a otro documento" & vbCrLf & vbCrLf &
                                                 "Documento: " & _RowNVVConOCC.Item("TIDO") & "-" & _RowNVVConOCC.Item("NUDO") & " " &
                                                 FormatDateTime(_RowNVVConOCC.Item("FEEMDO"), DateFormat.ShortDate) &
                                                 ", Resp. " & _RowNVVConOCC.Item("KOFUDO") & " - " & _RowNVVConOCC.Item("NOKOFU") & vbCrLf & vbCrLf &
                                                 "¿Desea continuar con la grabación?", "Validación",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                                    TxtOrdendecompra.Focus()
                                    Return False
                                End If
                            End If

                            Dim _Row = _Class_Referencias_DTE.Tbl_Referencias.Select("TpoDocRef = 801 And FolioRef = '" & TxtOrdendecompra.Text & "'")

                            If False Then

                                MessageBoxEx.Show(Me, "Debe confirmar los datos de la Orden de compra para la referencia DTE", "Ref. Orden de Compra",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Dim _NroLinRef = _Class_Referencias_DTE.Tbl_Referencias.Rows.Count + 1

                                Dim _Row_Referencia As DataRow = _Class_Referencias_DTE.Fx_Row_Nueva_Referencia(0, 0, "", "", _NroLinRef,
                                                                                                                    801, TxtOrdendecompra.Text,
                                                                                                                    "", "", Now.Date, 0, "Orden de compra")

                                Dim _Grabar As Boolean
                                Dim _Habilita_CodRef = (_Tido = "NCV")

                                Dim Fm As New Frm_Referencia_DTE_Det(_Row_Referencia, _Habilita_CodRef)
                                Fm.Cmb_TpoDocRef.Enabled = False
                                Fm.Txt_FolioRef.Enabled = False
                                Fm.ShowDialog(Me)
                                _Grabar = Fm.Grabar
                                Fm.Dispose()

                                If Not _Grabar Then

                                    _Class_Referencias_DTE.Sb_Eliminar_Todas_Las_Referencias()

                                    MessageBoxEx.Show(Me, "Debe confirmar la grabación de las referencias (orden de compra) para el documento", "Validación",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Return False

                                End If

                                If False Then

                                    Dim _Eliminar_Referencias As Boolean

                                    If _Grabar Then

                                        If MessageBoxEx.Show(Me, "La referencia se incorporo correctamente." & vbCrLf & vbCrLf &
                                                         "¿Desea agregar otras referencias adicionales?",
                                                          "Referencias", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                                            Dim Fmr As New Frm_Referencia_DTE_Enc(0, _Habilita_CodRef)
                                            Fmr.Class_Referencias_DTE = _Class_Referencias_DTE
                                            Fmr.ShowDialog(Me)
                                            _Class_Referencias_DTE = Fmr.Class_Referencias_DTE
                                            Fmr.Dispose()

                                            _Row = _Class_Referencias_DTE.Tbl_Referencias.Select("TpoDocRef = 801")

                                            If Convert.ToBoolean(_Row.Count) Then

                                                TxtOrdendecompra.Enabled = False

                                            Else

                                                _Eliminar_Referencias = True

                                            End If

                                        End If

                                    Else

                                        _Eliminar_Referencias = True

                                    End If

                                    If _Eliminar_Referencias Then

                                        'TxtOrdendecompra.Text = String.Empty
                                        'TxtOrdendecompra.Enabled = True

                                        _Class_Referencias_DTE.Sb_Eliminar_Todas_Las_Referencias()
                                        MessageBoxEx.Show(Me, "Debe confirmar la grabación de las referencias para el documento", "Validación",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Return False

                                    End If

                                End If

                            End If

                        End If

                End Select

                .Item("Observaciones") = TxtObservaciones.Text
                .Item("Forma_pago") = TxtFormadepago.Text
                .Item("Orden_compra") = TxtOrdendecompra.Text

                .Item("Placa") = Txt_Placa.Text
                .Item("CodRetirador") = Txt_CodRetirador.Text

                For Each _Fila As DataRow In _TblObservaciones.Rows

                    Dim _Observacion As String = Trim(_Fila.Item("Descripcion"))

                    _i += 1
                    .Item("Obs" & _i) = Mid(_Observacion, 1, 80)

                    If Not String.IsNullOrEmpty(_Observacion) Then
                        _Con_Observaciones += 1
                    End If

                Next

            End With

            If CBool(_Caracteres) Then _Con_Observaciones += 1
            If Not String.IsNullOrEmpty(Trim(TxtFormadepago.Text)) Then _Con_Observaciones += 1
            If Not String.IsNullOrEmpty(Trim(TxtOrdendecompra.Text)) Then _Con_Observaciones += 1

            If _Con_Observaciones = 0 Then
                If _Preguntar_Grabar_Sin_Observaciones Then
                    If MessageBoxEx.Show(Me, "¿Confirma grabar sin observaciones?", "Confirmación",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                        Return False
                    End If
                End If
            End If

            Dim _Tido2 = _Row_Encabezado.Item("TipoDoc")

            If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad", "Obliga_Transportista") Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad 
                                Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido2 & "'"
                Dim _Row_Formato_Modalidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Formato_Modalidad) Then

                    Dim _Obliga_Transportista As Boolean = _Row_Formato_Modalidad.Item("Obliga_Transportista")

                    If _Obliga_Transportista Then

                        If String.IsNullOrEmpty(Txt_Placa.Text) Or String.IsNullOrEmpty(Txt_CodRetirador.Text) Then

                            If Not Fx_Agregar_Permiso_Otorgado_Al_Documento(Me, _TblPermisos, "Doc00066", _Ds_Matriz_Documentos, "", "") Then
                                Return False
                            End If

                        End If

                    End If

                End If

            End If

            _Row_Encabezado.Item("FechaRecepcion") = DtpFechaEntrega.Value
            Return True

        Else
            MessageBoxEx.Show(Me, "El máximo de caracteres para la observación es de 250",
                                  "Exede el máximo de caracteres en la observación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function

    Function Fx_Crear_Tabla()

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Nom_Columna", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Campo", System.Type.[GetType]("System.String"))

        Dim _Columna_d As New DataColumn

        _Columna_d.ColumnName = "Descripcion"
        _Columna_d.DataType = System.Type.[GetType]("System.String")
        _Columna_d.MaxLength = 80
        _Columna_d.DefaultValue = ""

        dt.Columns.Add(_Columna_d) '"Descripcion", System.Type.[GetType]("System.String"))
        ',,,,,,


        For _i = 1 To 35

            'If _Campo = "TEXTO" & _i Then
            dr = dt.NewRow()
            dr("Nom_Columna") = "TEXTO" & _i
            dr("Campo") = "Texto adicional " & numero_(_i, 2)
            dr("Descripcion") = NuloPorNro(_Row_Observaciones.Item("Obs" & _i), "") '_Sql.Fx_Trae_Dato(, "TEXTO" & _i, "MAEEDOOB", "IDMAEEDO = " & _Idmaeedo)
            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

    Private Sub Frm_Formulario_Observaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_Obs_Adicionales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Obs_Adicionales.KeyDown

        If e.KeyValue = Keys.Enter Then
            If Not TxtObservaciones.ReadOnly Then
                Grilla_Obs_Adicionales.Columns("Descripcion").ReadOnly = False
                Grilla_Obs_Adicionales.BeginEdit(True)
                e.SuppressKeyPress = False
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Grilla_Obs_Adicionales_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Obs_Adicionales.CellEndEdit
        Grilla_Obs_Adicionales.Columns("Descripcion").ReadOnly = True
    End Sub

    Private Sub Btn_Grabar_Observaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar_Observaciones.Click
        Sb_Grabar(False, False)
    End Sub

    Private Sub Warning_Visado_OptionsClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Warning_Visado.OptionsClick

        Dim Fm_p As New Frm_Formulario_Permisos_Asociados_New(_Ds_Matriz_Documentos, _Row_Entidad, _Tipo_Documento) ', _RowEntidad, _Tipo_Documento)
        Fm_p.Btn_Enviar_Solicitudes_Cadenas_Remotas.Visible = False
        Fm_p.ShowDialog(Me)

    End Sub

    Private Sub Btn_Referencias_DTE_Click(sender As Object, e As EventArgs) Handles Btn_Referencias_DTE.Click

        Dim _Tido = _Row_Encabezado.Item("TipoDoc")
        Dim _Habilita_CodRef = (_Tido = "NCV")

        Dim Fm As New Frm_Referencia_DTE_Enc(0, _Habilita_CodRef)
        Fm.Class_Referencias_DTE = _Class_Referencias_DTE
        Fm.ShowDialog(Me)
        _Class_Referencias_DTE = Fm.Class_Referencias_DTE
        Fm.Dispose()

        If _Tido <> "NCV" Then

            Dim _Row() = _Class_Referencias_DTE.Tbl_Referencias.Select("TpoDocRef = '801'")

            If Convert.ToBoolean(_Row.Count) Then
                For Each _Fila As DataRow In _Class_Referencias_DTE.Tbl_Referencias.Rows
                    If _Fila.Item("TpoDocRef") = "801" Then
                        TxtOrdendecompra.Text = _Fila.Item("FolioRef")
                        TxtOrdendecompra.Enabled = False
                        Exit For
                    End If
                Next
            Else
                TxtOrdendecompra.Text = String.Empty
                TxtOrdendecompra.Enabled = True
            End If

        End If

    End Sub

    Private Sub Btn_Buscar_Retirador_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Retirador.Click
        Try

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            _Filtrar.Tabla = "TABRETI"
            _Filtrar.Campo = "KORETI"
            _Filtrar.Descripcion = "NORETI"

            _Filtrar.Pro_Nombre_Encabezado_Informe = "RETIRADORES DE MERCADERIA"

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                                   Nothing, False, True) Then

                Dim _Tbl_Retirador As DataTable = _Filtrar.Pro_Tbl_Filtro

                Dim _Row As DataRow = _Tbl_Retirador.Rows(0)

                Dim _Codigo = _Row.Item("Codigo").ToString.Trim
                Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

                Txt_CodRetirador.Tag = _Codigo
                Txt_CodRetirador.Text = _Codigo
                Lbl_Nombre_Retirador_Mercaderia.Text = _Descripcion

            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_Buscar_Placa_Patente_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Placa_Patente.Click

        Dim _Koenresp As String = _Sql.Fx_Trae_Dato("TABRETI", "KOENRESP", "KORETI = '" & Txt_CodRetirador.Tag & "'")

        Dim _Sql_Filtro_Condicion_Extra As String

        If Not String.IsNullOrEmpty(_Koenresp.Trim) Then

            _Sql_Filtro_Condicion_Extra = "And KOENRESP = '" & _Koenresp & "'"

        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPLACA"
        _Filtrar.Campo = "PLACA"
        _Filtrar.Descripcion = "DESCRIP"

        Dim _Koen As String = _Row_Encabezado.Item("CodEntidad")

        _Filtrar.Pro_Nombre_Encabezado_Informe = "PLACAS PATENTE"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Placa As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Placa.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Placa.Tag = _Codigo
            Txt_Placa.Text = _Codigo

        End If

    End Sub

    Private Sub Txt_CodRetirador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CodRetirador.KeyDown
        If e.KeyValue = Keys.Delete Then
            Txt_CodRetirador.Tag = String.Empty
            Txt_CodRetirador.Text = String.Empty
            Lbl_Nombre_Retirador_Mercaderia.Text = String.Empty
        ElseIf e.KeyValue = Keys.Enter And String.IsNullOrEmpty(Txt_CodRetirador.Text.Trim) Then
            Call Btn_Buscar_Retirador_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Txt_Placa_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Placa.KeyDown
        If e.KeyValue = Keys.Delete Then
            Txt_Placa.Tag = String.Empty
            Txt_Placa.Text = String.Empty
        ElseIf e.KeyValue = Keys.Enter And String.IsNullOrEmpty(Txt_Placa.Text.Trim) Then
            Call Btn_Buscar_Placa_Patente_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Btn_Grabar_e_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_e_Imprimir.Click
        Sb_Grabar(True, False)
    End Sub
    Private Sub Btn_Solo_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Solo_Grabar.Click
        Sb_Grabar(False, False)
    End Sub
    Sub Sb_Grabar(_Grabar_e_Imprimir As Boolean, _Grabar_Y_Pagar As Boolean)

        If Fx_Grabar_Observaciones() Then

            If _Grabar_Doc_Reserva_OCC Then

                If MessageBoxEx.Show(Me, "Este documento se guardara sin detalles, ya que es solo para que usted pueda utilizar el número en el futuro." & vbCrLf &
                             "De igual forma este número quedara tomado en Random y no podrá ser utilizado por otro usuario que no sea usted." & vbCrLf & vbCrLf &
                             "¿Confirma la grabación de la reserva de número de orden de compra?", "Reserva de número de Orden de compra",
                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then

                    _Grabar = True

                End If

            Else

                _Grabar = True

            End If

            _Grabar_Y_Pagar_Vale = _Grabar_Y_Pagar
            _Solo_Grabar = Not _Grabar_e_Imprimir

            If _Grabar Then Me.Close()

        End If

    End Sub

    Private Sub TxtOrdendecompra_TextChanged(sender As Object, e As EventArgs) Handles TxtOrdendecompra.TextChanged
        TxtOrdendecompra.Tag = TxtOrdendecompra.Text
    End Sub

    Private Sub Btn_Crear_Retirador_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Retirador.Click

        Dim _TblPermisos As DataTable = _Ds_Matriz_Documentos.Tables("Permisos_Doc")

        If Fx_Agregar_Permiso_Otorgado_Al_Documento(Me, _TblPermisos, "Tbl00045", _Ds_Matriz_Documentos, "", "") Then

            Dim Fm As New Frm_Retirador_Mercaderia("")
            Fm.ShowDialog(Me)
            If Fm.Grabar Then
                Dim _Row As DataRow = Fm.Row_Tabreti

                Dim _Codigo = _Row.Item("KORETI")
                Dim _Descripcion = _Row.Item("NORETI").ToString.Trim

                Txt_CodRetirador.Tag = _Codigo
                Txt_CodRetirador.Text = _Codigo
                Lbl_Nombre_Retirador_Mercaderia.Text = _Descripcion
            End If
            Fm.Dispose()

        End If

    End Sub

    Private Sub Frm_Formulario_Observaciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If Not _Grabar Then

            Dim _i = 0

            With _Row_Observaciones

                .Item("Observaciones") = TxtObservaciones.Text
                .Item("Forma_pago") = TxtFormadepago.Text
                .Item("Orden_compra") = TxtOrdendecompra.Text

                .Item("Placa") = Txt_Placa.Text
                .Item("CodRetirador") = Txt_CodRetirador.Text

                For Each _Fila As DataRow In _TblObservaciones.Rows

                    Dim _Observacion As String = Trim(_Fila.Item("Descripcion"))

                    _i += 1
                    .Item("Obs" & _i) = Mid(_Observacion, 1, 80)

                Next

            End With

        End If

    End Sub

    Private Sub Btn_Grabar_Pagar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Pagar.Click
        Sb_Grabar(True, True)
    End Sub

    Private Sub DtpFechaEntrega_ButtonDropDownClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DtpFechaEntrega.ButtonDropDownClick
        If TieneOrdenDeDespacho Then
            MessageBoxEx.Show(Me, "El documento tiene orden de despacho" & vbCrLf &
                              "Debe cambiar este datos desde la orden de despacho", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub Btn_GDI_GTI_Click(sender As Object, e As EventArgs) Handles Btn_GDI_GTI.Click

        Dim _Row_Bodega_Destino As DataRow
        Dim _SeleccionarBodega As Boolean

        Dim _Respuesta As New DialogResult

        _Respuesta = MessageBoxEx.Show(Me, "Se solicitara bodega de destino para traspaso interno [Si]." & vbCrLf & vbCrLf &
                             "Usted puede omitir esta opción [No]." & vbCrLf &
                             "Lo que indicaria que esta guía pueda ser recibida en" & vbCrLf &
                             "cualquier bodega sin restricciones", "Validación",
                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

        If _Respuesta = DialogResult.Yes Then
            _SeleccionarBodega = True
        ElseIf _Respuesta = DialogResult.No Then
            ' poner un permiso
        Else
            Return
        End If

        If _SeleccionarBodega Then

            Dim Fm_Bd As New Frm_Seleccionar_Bodega_Grilla("")
            Fm_Bd.Pro_Pedir_Permiso = False
            Fm_Bd.Text = "SELECCIONE LA BODEGA DE DESTINO (Bodega que recibira los productos)"
            Fm_Bd.ShowDialog(Me)
            _Row_Bodega_Destino = Fm_Bd.Pro_Row_Bodega
            Fm_Bd.Dispose()

            If Not _Row_Bodega_Destino Is Nothing Then
                _Row_Encabezado.Item("Bodega_Destino") = _Row_Bodega_Destino.Item("KOBO")
            End If

        End If

        If MessageBoxEx.Show(Me, "¿Confirma grabar GDI modo Traspaso Interno?" & vbCrLf &
                             "(la confirmación dejara en espera la recepción de este documento)",
                             "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _Row_Encabezado.Item("Subtido") = "GTI"
            Btn_GDI_GTI.Text = "Se grabara GDI modo traspaso interno"
        Else
            _Row_Encabezado.Item("Subtido") = String.Empty
            _Row_Encabezado.Item("Bodega_Destino") = String.Empty
            Btn_GDI_GTI.Text = "Grabar GDI modo traspaso interno"
        End If


    End Sub

End Class
