Imports System.Drawing.Printing
Imports System.IO
Imports DevComponents.DotNetBar
Imports MySql.Data.Authentication
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.Layout
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO

Public Class Frm_Ver_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idmaeedo As Integer
    Dim _Id_DocEnc As Integer
    Dim _Idrst As Integer
    Dim _Marcar_Stock_VS_Cantidad As Boolean

    Dim _Datos_Documento As New DataSet

    Dim _Campo_Koen As String
    Dim _Campo_Suen As String

    Dim _TblEncabezado,
        _TblDetalle,
        _TblObservaciones As DataTable
    Dim _Tbl_Mevento_Edo As DataTable

    Dim _Maeedo As DataTable
    Dim _Maeddo As DataTable
    Dim _Maeimli As DataTable
    Dim _Maedtli As DataTable
    Dim _Maeedoob As DataTable
    Dim _Maeven As DataTable
    Dim _Row_Maeen As DataRow

    Dim _Marcar_Grilla_Pendientes As Boolean
    Dim _Min_Rotacion_Anual As Double
    Dim _Correr_a_la_derecha As Boolean
    Dim _Folio_Cambiado As Boolean

    Dim _Row_Maeedo_Doc As DataRow
    Dim _Formulario_Padre As Form

    Dim _NombreFormato_Modalidad As String
    Dim _NombreFormato_PDF_Modalidad As String
    Dim _Codigo_Marcar As String

    Dim _Error As String

    Dim _Class_Referencias_DTE As Class_Referencias_DTE

    Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

    Dim _RowEntidad As DataRow

    Dim _Eliminado As Boolean
    Dim _Anulado As Boolean

    Dim _Row_Docu_Ent As DataRow

    Dim _Customizable As Boolean
    Dim _Cl_NVVCustomizable As New Cl_NVVCustomizable

    Public Property PreVenta As Boolean

    Dim _Cl_Contenedor As New Cl_Contenedor

    Enum _Sector
        Encabezado
        Pie
    End Enum

    Enum Enum_Tipo_Apertura
        Desde_Random_SQL
        Desde_Arcvhivador_XML
        Desde_Bakapp_Kasi
    End Enum

    Dim _Tipo_Apertura As Enum_Tipo_Apertura

    Public Property Marcar_Grilla_Pendientes() As Boolean
        Get
            Return _Marcar_Grilla_Pendientes
        End Get
        Set(value As Boolean)
            _Marcar_Grilla_Pendientes = value
        End Set
    End Property

    Public Property Pro_Folio_Cambiado() As Boolean
        Get
            Return _Folio_Cambiado
        End Get
        Set(value As Boolean)
            _Folio_Cambiado = value
        End Set
    End Property

    Public ReadOnly Property Pro_Existe_Documento() As Boolean
        Get
            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEDO", "IDMAEEDO = " & _Idmaeedo))
            Return _Reg
        End Get
    End Property

    Public ReadOnly Property Pro_Row_Maeedo() As DataRow
        Get
            Return _TblEncabezado.Rows(0)
        End Get
    End Property

    Public ReadOnly Property Pro_TblDetalle() As DataTable
        Get
            Return _TblDetalle
        End Get
    End Property

    Public ReadOnly Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
    End Property

    Public Property Datos_Documento As DataSet
        Get
            Return _Datos_Documento
        End Get
        Set(value As DataSet)
            _Datos_Documento = value
            Sb_Abrir_Documento_Desde_Archivador_XML()
        End Set
    End Property

    Public Property Idrst As Integer
        Get
            Return _Idrst
        End Get
        Set(value As Integer)
            _Idrst = value
        End Set
    End Property

    Public Property Marcar_Stock_VS_Cantidad As Boolean
        Get
            Return _Marcar_Stock_VS_Cantidad
        End Get
        Set(value As Boolean)
            _Marcar_Stock_VS_Cantidad = value
        End Set
    End Property

    Public Property Min_Rotacion_Anual As Double
        Get
            Return _Min_Rotacion_Anual
        End Get
        Set(value As Double)
            _Min_Rotacion_Anual = value
        End Set
    End Property

    Public Property Correr_a_la_derecha As Boolean
        Get
            Return _Correr_a_la_derecha
        End Get
        Set(value As Boolean)
            _Correr_a_la_derecha = value
        End Set
    End Property

    Public Property [Error] As String
        Get
            Return _Error
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

    Public Property Eliminado As Boolean
        Get
            Return _Eliminado
        End Get
        Set(value As Boolean)
            _Eliminado = value
        End Set
    End Property

    Public Property Anulado As Boolean
        Get
            Return _Anulado
        End Get
        Set(value As Boolean)
            _Anulado = value
        End Set
    End Property

    Public Property Codigo_Marcar As String
        Get
            Return _Codigo_Marcar
        End Get
        Set(value As String)
            _Codigo_Marcar = value
        End Set
    End Property

    Public Property VerSoloEntidadesDelVendedor As Boolean

    Public Sub New(Id As Integer,
                   Tipo_Apertura As Enum_Tipo_Apertura)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _Idmaeedo = Id
        _Id_DocEnc = Id

        '_Idrst = Idrst
        '_Marcar_Stock_VS_Cantidad = Marcar_Stock_VS_Cantidad
        '_Min_Rotacion_Anual = Min_Rotacion_Anual
        '_Correr_a_la_derecha = Correr_a_la_derecha

        _Tipo_Apertura = Tipo_Apertura

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillaEncabezado, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, False, False, False)
        Sb_Formato_Generico_Grilla(GrillaDetalleDoc, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Both, True, False, False)


        Select Case _Tipo_Apertura

            Case Enum_Tipo_Apertura.Desde_Random_SQL

                _Campo_Koen = "ENDO"
                _Campo_Suen = "SUENDO"

                Dim _Reg As Boolean = Convert.ToBoolean(_Sql.Fx_Cuenta_Registros("MAEEDO", "IDMAEEDO = " & _Idmaeedo))

                If Not _Reg Then

                    Consulta_sql = "Select * From ELIEDO Where IDMAEEDO = " & _Idmaeedo
                    Dim _Row_Eliedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not IsNothing(_Row_Eliedo) Then

                        Dim _Tido As String = _Row_Eliedo.Item("TIDO")
                        Dim _Nudo As String = _Row_Eliedo.Item("NUDO")
                        Dim _Endo As String = _Row_Eliedo.Item("ENDO")
                        Dim _Suendo As String = _Row_Eliedo.Item("SUENDO")

                        _Idmaeedo = _Sql.Fx_Trae_Dato("MAEEDO", "IDMAEEDO",
                                                      "EMPRESA = '" & Mod_Empresa & "' And TIDO = '" & _Tido &
                                                      "' and NUDO = '" & _Nudo & "' And ENDO = '" & _Endo & "'  And SUENDO = '" & _Suendo & "'",,, 0)

                    End If

                End If

                Btn_Grabar_Documentos.Visible = False

                Sb_Abrir_Documento_Desde_Random_SQL()

                If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Fincred_TramaRespuesta") Then
                    _Reg = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Fincred_TramaRespuesta", "Idmaeedo = " & _Idmaeedo))
                End If


                Btn_InfFincred.Visible = _Reg

                If _Correr_a_la_derecha Then
                    Me.Top += 10
                    Me.Left += 10
                End If

                Dim Fm As New Frm_Ver_Documentos_Permisos(_Idmaeedo)
                Btn_Permisos_Asociados.Enabled = Convert.ToBoolean(Fm.Pro_Tbl_Remotas.Rows.Count)
                Fm.Dispose()

            Case Enum_Tipo_Apertura.Desde_Arcvhivador_XML, Enum_Tipo_Apertura.Desde_Bakapp_Kasi

                'Sb_Abrir_Documento_Desde_Archivador_XML()

                _Campo_Koen = "CodEntidad"
                _Campo_Suen = "CodSucEntidad"

                Btn_Anotaciones_al_documento.Visible = False
                Btn_Enviar_documento_por_correo.Visible = False
                Btn_Traza_Documento.Visible = False
                Btn_Marcar_Baja_Rotacion.Visible = False
                Btn_Cierre_Reactivacion_Documento.Visible = False
                Btn_Firmar_Documento_DTE.Visible = False
                Btn_Revisar_Situacion_Comercial.Visible = False
                Btn_Revisar_Situacion_Comercial.Visible = False
                Btn_Grabar_Documentos.Visible = True
                Btn_Permisos_Asociados.Visible = False
                Btn_Ver_Pagos.Visible = False
                Btn_Ver_Orden_de_despacho.Visible = False
                Btn_HabilitarFacturacion.Visible = False

        End Select

        Sb_Color_Botones_Barra(Bar2)

        Me.Cursor = Cursors.WaitCursor

        'Dim _Koen As String
        'Dim _Suen As String

        '_Koen = _TblEncabezado.Rows(0).Item(_Campo_Koen)
        '_Suen = _TblEncabezado.Rows(0).Item(_Campo_Suen)

        '_RowEntidad = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        '_Cl_Contenedor.Fx_Soltar_Contenedor_Tomado()

    End Sub

    Private Sub Frm_Documento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Btn_CopiarDocOtrEmpresa.Visible = (RutEmpresa = "77458040-9" Or RutEmpresa = "07251245-6" Or RutEmpresa = "77634877-5" Or RutEmpresa = "77634879-1")
        Btn_CrearNVVdesdeOCCOtraEmpresa.Visible = (RutEmpresa = "79514800-0")

        Select Case _Tipo_Apertura

            Case Enum_Tipo_Apertura.Desde_Random_SQL

                Btn_Grabar_Documentos.Visible = False

                Sb_Abrir_Documento_Desde_Random_SQL()

                If _Correr_a_la_derecha Then
                    Me.Top += 10
                    Me.Left += 10
                End If

                AddHandler GrillaDetalleDoc.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
                AddHandler GrillaDetalleDoc.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
                AddHandler GrillaEncabezado.MouseDown, AddressOf Sb_Grilla_Encabezado_MouseDown
                AddHandler GrillaDetalleDoc.CellEnter, AddressOf GrillaDetalleDoc_CellEnter
                AddHandler GrillaDetalleDoc.CellDoubleClick, AddressOf Sb_Ver_Documento_Origen

                Dim Fm As New Frm_Ver_Documentos_Permisos(_Idmaeedo)
                Btn_Permisos_Asociados.Enabled = Convert.ToBoolean(Fm.Pro_Tbl_Remotas.Rows.Count)
                Fm.Dispose()

            Case Enum_Tipo_Apertura.Desde_Arcvhivador_XML

                Sb_Abrir_Documento_Desde_Archivador_XML()

                Btn_Anotaciones_al_documento.Visible = False
                Btn_Enviar_documento_por_correo.Visible = False
                Btn_Traza_Documento.Visible = False
                Btn_Marcar_Baja_Rotacion.Visible = False
                Btn_Cierre_Reactivacion_Documento.Visible = False
                Btn_Firmar_Documento_DTE.Visible = False
                Btn_Revisar_Situacion_Comercial.Visible = False
                Btn_Revisar_Situacion_Comercial.Visible = False
                Btn_Grabar_Documentos.Visible = True
                Btn_Ver_Orden_de_despacho.Visible = False

            Case Enum_Tipo_Apertura.Desde_Bakapp_Kasi

                Sb_Abrir_Documento_Desde_Bakapp_Kasi_SQL()

                Btn_Anotaciones_al_documento.Visible = False
                Btn_Enviar_documento_por_correo.Visible = False
                Btn_Traza_Documento.Visible = False
                Btn_Archivos_Adjuntos.Visible = False
                Btn_Marcar_Baja_Rotacion.Visible = False
                Btn_Cierre_Reactivacion_Documento.Visible = False
                Btn_Firmar_Documento_DTE.Visible = False
                Btn_Revisar_Situacion_Comercial.Visible = False
                Btn_Revisar_Situacion_Comercial.Visible = False
                Btn_Grabar_Documentos.Visible = False
                Btn_Ver_Orden_de_despacho.Visible = False

        End Select

        Dim _Koen As String
        Dim _Suen As String

        _Koen = _TblEncabezado.Rows(0).Item(_Campo_Koen)
        _Suen = _TblEncabezado.Rows(0).Item(_Campo_Suen)

        _RowEntidad = Fx_Traer_Datos_Entidad(_Koen, _Suen)


        Sb_Formato_Generico_Grilla(GrillaEncabezado, 17, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, False, False, False)

        Dim _Cantidad As Double
        Dim _CantUd1 As Double
        Dim _CantUd2 As Double
        Dim _Potencia As Double
        Dim _Flete As Double

        Dim _Ud1 = String.Empty
        Dim _Ud2 = String.Empty

        Dim _cRtu, _cUdtrpr, _cPrct, _cTipr, _cCantud1, _cCantud2 As String

        If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Or _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Arcvhivador_XML Then

            _cUdtrpr = "UDTRPR"
            _cPrct = "PRCT"
            _cTipr = "TIPR"
            _cCantud1 = "CAPRCO1"
            _cCantud2 = "CAPRCO2"
            _cRtu = "RLUDPR"

        Else

            _cUdtrpr = "UnTrans"
            _cPrct = "Prct"
            _cTipr = "Tipr"
            _cCantud1 = "CantUd1"
            _cCantud2 = "CantUd2"
            _cRtu = "Rtu"

        End If

        Dim _Sum_Kilos As Double
        Dim _Suma_Flete As String

        If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then

            For Each _Fila As DataRow In _TblDetalle.Rows

                Dim _Codigo As String = _Fila.Item("KOPRCT")
                Dim _Udtrpr As Integer = _Fila.Item(_cUdtrpr)
                Dim _Ud As String = "Ud1"

                If _Udtrpr = 1 Then
                    _Ud = "Ud1"
                ElseIf _Udtrpr = 2 Then
                    _Ud = "Ud2"
                Else
                    _Ud = "Ud1"
                End If

                Dim _Prct As Boolean = _Fila.Item(_cPrct)
                Dim _Tipr As String = _Fila.Item(_cTipr)

                If Not _Prct And _Tipr = "FPN" Then

                    _Cantidad += _Fila.Item(_cCantud1)
                    _CantUd1 += _Fila.Item(_cCantud1)
                    _CantUd2 += _Fila.Item(_cCantud2)

                    Dim _Kilos As Double = _Sql.Fx_Trae_Dato("MAEPR", "PESOUBIC", "KOPR = '" & _Codigo & "'", True)

                    If _Kilos = 0 Then _Kilos = 1

                    _Kilos = _Kilos * _Fila.Item(_cCantud1)

                    _Sum_Kilos += _Kilos

                    If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then

                        _Potencia = _Fila.Item("POTENCIA")
                        _Flete += Math.Round(_Potencia * _Fila.Item("CAPRCO1"), 0)

                    End If

                    Dim _Ud1New = _Fila.Item("Ud01PR")
                    Dim _Ud2New = _Fila.Item("Ud02PR")

                    Dim _Rtu = _Fila.Item(_cRtu)

                    If String.IsNullOrEmpty(_Ud1) Then

                        _Ud1 = _Ud1New
                        _Ud2 = _Ud2New

                    Else

                        If _Rtu <> 1 Then

                            If _Ud1New <> _Ud1 Then _Ud1 = "UD1"
                            If _Ud2New <> _Ud2 Then _Ud2 = "UD2"

                        End If

                    End If

                End If

            Next

            If CBool(_Flete) Then
                _Suma_Flete = ", Suma de flete: " & FormatNumber(_Flete, 0)
            End If

        End If

        Dim _Dec1 = Math.Round(_CantUd1, 2) - Math.Round(_CantUd1, 0)
        Dim _Dec2 = Math.Round(_CantUd1, 2) - Math.Round(_CantUd1, 0)
        Dim _DecT = Math.Round(_Cantidad, 2) - Math.Round(_Cantidad, 0)

        Dim _DecimT, _Decim1, _Decim2 As Integer

        If _Dec1 <> 0 Then _Decim1 = 2
        If _Dec2 <> 0 Then _Decim2 = 2
        If _DecT <> 0 Then _DecimT = 2

        '_Ud1 = "UN1"
        '_Ud2 = "UN2"

        If _Ud1 = _Ud2 And _CantUd1 = _CantUd2 Then
            Lbl_Totaliza_Cantidades.Text = "Kilos: " & FormatNumber(_Sum_Kilos, 2) & ", Total Cantidades, " & _Ud1 & ": " & FormatNumber(_CantUd1, _Decim1) & _Suma_Flete
        Else
            Lbl_Totaliza_Cantidades.Text = "Kilos: " & FormatNumber(_Sum_Kilos, 2) & ", Total Cantidades, " & _Ud1 & ": " & FormatNumber(_CantUd1, _Decim1) & ", " & _Ud2 & ": " & FormatNumber(_CantUd2, _Decim2) & _Suma_Flete
        End If

        If Btn_Archivos_Adjuntos.Visible Then Sb_Revisar_Si_Hay_Archivos_Adjuntos()



        Me.Refresh()

        If Global_Thema = Enum_Themas.Oscuro Or Global_Thema = Enum_Themas.Oscuro_Ligth Then
            Lbl_Tido.ForeColor = Color.White
        End If

        Sb_Color_Botones_Barra(Bar2)

        Me.Cursor = Cursors.Default

        VerSoloEntidadesDelVendedor = Fx_TienePermiso_EnDoc(Me, "NO00021", _Idmaeedo, False)

        If Not VerSoloEntidadesDelVendedor Then
            VerSoloEntidadesDelVendedor = Fx_TienePermiso_EnDoc(Me, "NO00022", _Idmaeedo, False)
        End If

        If Not String.IsNullOrEmpty(_Codigo_Marcar) Then
            BuscarDatoEnGrilla(_Codigo_Marcar, "KOPRCT", GrillaDetalleDoc)
        End If

        If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then

            Dim _Tido = Trim(_TblEncabezado.Rows(0).Item("TIDO"))
            Dim _Nudo = Trim(_TblEncabezado.Rows(0).Item("NUDO"))

            If _Tido = "NVV" AndAlso
                _Global_Row_Configuracion_General.Item("HabilitarNVVConProdCustomizables") AndAlso
                _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then

                _Customizable = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Docu_Ent", "Customizable", "Idmaeedo = " & _Idmaeedo)

                Lbl_CusNVV.Visible = _Customizable
                Btn_CusNVV.Visible = _Customizable

                If _Customizable Then
                    Btn_CusNVV.Text = "Ver información del producto Customizado"
                    Me.Text += " *** CUSTOMIZABLE ***"
                Else
                    Btn_MarcarNVVCustomizable.Visible = True
                End If

            End If

            Chk_Pickear.Visible = _Tido = "NVV"
            Chk_Pickear.Checked = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Docu_Ent", "Pickear", "Idmaeedo = " & _Idmaeedo, True, False)

            _Cl_Contenedor.Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_Idmaeedo, _Tido, _Nudo)

            Btn_Contenedor.Visible = (_Tido = "OCC")

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Sub Sb_Abrir_Documento_Desde_Random_SQL()

        _Class_Referencias_DTE = New Class_Referencias_DTE(_Idmaeedo)
        Dim Tbl_Referencias As DataTable = _Class_Referencias_DTE.Tbl_Referencias

        Consulta_sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random,
                       "#Idmaeedo#", _Idmaeedo)
        _Datos_Documento = _Sql.Fx_Get_DataSet(Consulta_sql)

        _TblEncabezado = _Datos_Documento.Tables(0)
        _TblDetalle = _Datos_Documento.Tables(1)
        _TblObservaciones = _Datos_Documento.Tables(2)
        _Maeven = _Datos_Documento.Tables(4)

        Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIPODOCUMENTO")
        Dim _Nudo As String = _TblEncabezado.Rows(0).Item("NUDO")
        Dim _Modo As String = _TblEncabezado.Rows(0).Item("MODO")
        Dim _Nudonodefi As Boolean = _TblEncabezado.Rows(0).Item("NUDONODEFI")

        _Configuracion_Regional_(_Modo)

        _Datos_Documento.Dispose()

        GrillaEncabezado.DataSource = _TblEncabezado
        GrillaDetalleDoc.DataSource = _TblDetalle

        If _TblObservaciones.Rows.Count = 0 Then

            Consulta_sql = "Insert Into MAEEDOOB (IDMAEEDO) Values (" & _Idmaeedo & ")" & vbCrLf &
                           "Select top 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo
            _TblObservaciones = _Sql.Fx_Get_DataTable(Consulta_sql)

        End If

        Dim _Vanedo As Double = _TblEncabezado.Rows(0).Item("VANEDO")
        Dim _Vaivdo As Double = _TblEncabezado.Rows(0).Item("VAIVDO")
        Dim _Vaimdo As Double = _TblEncabezado.Rows(0).Item("VAIMDO")
        Dim _Vabrdo As Double = _TblEncabezado.Rows(0).Item("VABRDO")
        Dim _Vaabdo As Double = _TblEncabezado.Rows(0).Item("VAABDO")
        Dim _Saldo As Double = _Vabrdo - _Vaabdo

        Dim _Timodo As String = _TblEncabezado.Rows(0).Item("TIMODO")

        Dim _Decimales As Integer = 0

        If _Timodo = "E" Then
            _Decimales = 2
        End If

        LblTotalNeto.Text = FormatNumber(_Vanedo, _Decimales)
        LblTotalIva.Text = FormatNumber(_Vaivdo, _Decimales)
        LblTotalImpuestos.Text = FormatNumber(_Vaimdo, _Decimales)
        LblTotalBruto.Text = FormatNumber(_Vabrdo, _Decimales)

        Btn_Ver_Pagos.Enabled = CBool(_Vaabdo)

        If _Sql.Fx_Exite_Campo("MAEEDO", "LISACTIVA") Then
            _TblEncabezado.Rows(0).Item("LISACTIVA") = _Sql.Fx_Trae_Dato("MAEEDO", "LISACTIVA", "IDMAEEDO = " & _Idmaeedo)
        End If

        If Btn_Ver_Pagos.Enabled Then

            Dim _Error_Maeven = False

            If _Vabrdo = _Vaabdo Then

                For Each _Fila As DataRow In _Maeven.Rows

                    Dim _Espgve As String = _Fila.Item("ESPGVE").ToString.Trim
                    Dim _Vave As Double = _Fila.Item("VAVE")
                    Dim _Vaabve As Double = _Fila.Item("VAABVE")

                    If _Vaabve <> _Vave Or _Espgve <> "C" Then
                        _Error_Maeven = True
                        Exit For
                    End If

                Next

                Dim _Espgdo As String = _TblEncabezado.Rows(0).Item("ESPGDO")

                If _Espgdo <> "C" Or _Error_Maeven Then
                    Btn_Ver_Pagos.Image = ImageList_16x16.Images.Item("money-error.png")
                End If

            End If

        End If

        LblTotalAbonado.Text = FormatNumber(_Vaabdo, _Decimales)
        LblTotalSaldo.Text = FormatNumber(_Saldo, _Decimales)

        Txt_Nombre_Entidad.Text = Space(1) & _TblEncabezado.Rows(0).Item("RAZON").ToString.Trim
        Lbl_Nombre_Entidad_Fisica.Text = Space(1) & _TblEncabezado.Rows(0).Item("RAZON_FISICA").ToString.Trim
        Txt_Responsable.Text = Space(1) & _TblEncabezado.Rows(0).Item("FUNCIONARIO")

        Txt_Contacto.Text = Space(1) & NuloPorNro(_TblEncabezado.Rows(0).Item("NOKOCON").ToString.Trim, "")

        Dim _Hora As String = _TblEncabezado.Rows(0).Item("HORA")

        Me.Text = Trim(_Tido) & " Nro: " & _Nudo & " (Idmaeedo: " & _Idmaeedo & ")" ', Hora: " & _Hora & ")"
        Lbl_Tido.Text = _Tido.Trim

        _Tido = Trim(_TblEncabezado.Rows(0).Item("TIDO"))

        Btn_Marcar_Baja_Rotacion.Visible = _Marcar_Stock_VS_Cantidad
        Btn_Cierre_Reactivacion_Documento.Visible = False

        Dim _Esdo = _TblEncabezado.Rows(0).Item("ESDO")

        Select Case _Tido
            Case "FCC"
                Btn_Marcar_Baja_Rotacion.Visible = True
            Case "OCC", "OCI", "NVV", "COV", "NVI"
                Btn_Cierre_Reactivacion_Documento.Visible = True
            Case "BLV", "BLX", "BSV", "COV", "ESC", "FCV", "FDB", "FDE", "FDV", "FDX", "FDZ", "FEE",
                 "FEV", "FVL", "FVT", "FVX", "FVZ", "FXV", "FYV", "NVV", "PRO", "RES", "RIN"
                Btn_Revisar_Situacion_Comercial.Visible = True
        End Select

        Dim _Tidoelec As Boolean = _TblEncabezado.Rows(0).Item("TIDOELEC") 'Fx_Es_Electronico(_Tido)

        Btn_Firmar_Documento_DTE.Visible = _Tidoelec

        If _Tidoelec Then

            If _Tido = "BLV" Then
                _Tidoelec = False
            ElseIf _Tido = "NCV" Then

                Consulta_sql = "SELECT IDEVENTO,ARCHIRVE,IDRVE,KOFU," &
                               "Isnull((Select top 1 NOKOFU From TABFU Tf Where Tf.KOFU = Mv.KOFU),'') As 'Funcionario'," & vbCrLf &
                               "FEVENTO,HORAGRAB,Convert(nvarchar, convert(datetime, (HORAGRAB*1.0/3600)/24), 108) As Hora,FECHAREF," & vbCrLf &
                               "KOTABLA,KOCARAC,(CASE WHEN LINK = '' THEN NOKOCARAC ELSE '(*) '+ NOKOCARAC END) AS 'NOKOCARAC'" & vbCrLf &
                               ",ISNULL(ARCHIRSE,'')AS ARCHIRSE,ISNULL(IDRSE,0) AS IDRSE,LINK,KOFUDEST" & vbCrLf &
                               "FROM MEVENTO Mv" & vbCrLf &
                               "WHERE ARCHIRVE='MAEEDO' AND IDRVE = " & _Idmaeedo & vbCrLf &
                               "ORDER BY FEVENTO,HORAGRAB"

                _Tbl_Mevento_Edo = _Sql.Fx_Get_DataTable(Consulta_sql)

                If Not Convert.ToBoolean(Tbl_Referencias.Rows.Count) Then

                    For Each _FlRow As DataRow In _Tbl_Mevento_Edo.Rows

                        Dim _Kocarac = Trim(_FlRow.Item("KOCARAC"))

                        Consulta_sql = "Select Isnull(KOTABLA,'??') As KOTABLA,Isnull(KOCARAC,'??') As KOCARAC,Isnull(NOKOCARAC,'??') As NOKOCARAC,Z1.* 
                                        From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Z1
                                        Inner Join TABCARAC 
                                        On Equiv_Kotabla = KOTABLA And Equiv_Kocarac = KOCARAC
                                        Where Tabla = 'CODREF_SII_NCV' And Equiv_Kotabla = 'SET-FE' And Equiv_Kocarac = '" & _Kocarac & "'"

                        Dim _Row_RefCarac As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If Not IsNothing(_Row_RefCarac) Then

                            Dim _Idrse = _FlRow.Item("IDRSE")
                            Dim _Kotabla = Trim(_Row_RefCarac.Item("KOTABLA")) '"SET-FE"
                            Dim _Nokocarac = Trim(_Row_RefCarac.Item("NOKOCARAC"))

                            Consulta_sql = "Select TIDO,NUDO,FEEMDO From MAEEDO Where IDMAEEDO = " & _Idrse
                            Dim _FlRef As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            Dim _Nudopa = String.Empty
                            Dim _NroLinRef = Tbl_Referencias.Rows.Count + 1
                            Dim _TpoDocRef = Fx_Tipo_DTE_VS_TIDO(_FlRef.Item("TIDO"))

                            Dim _FolioRef

                            Try
                                _FolioRef = Convert.ToInt32(_FlRef.Item("NUDO"))
                            Catch ex As Exception
                                _FolioRef = _FlRef.Item("NUDO").ToString.Trim
                            End Try

                            Dim _RUTOt = String.Empty
                            Dim _IdAdicOtr = String.Empty
                            Dim _FchRef = _FlRef.Item("FEEMDO")
                            Dim _CodRef = _Row_RefCarac.Item("CodigoTabla")
                            Dim _RazonRef = _Nokocarac

                            _Class_Referencias_DTE.Fx_Row_Nueva_Referencia(0, _Idmaeedo, "", "",
                                                             _NroLinRef, _TpoDocRef, _FolioRef, _RUTOt, _IdAdicOtr, _FchRef, _CodRef, _RazonRef)

                            Dim _FchRef_Str = Format(_FlRef.Item("FEEMDO"), "yyyyMMdd")

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Referencias_Dte " &
                                           "(Id_Doc,Tido,Nudo,NroLinRef,TpoDocRef,FolioRef,RUTOt,IdAdicOtr,FchRef,CodRef,RazonRef, Kasi)
                               Values
                               (" & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "'," & _NroLinRef & "," & _TpoDocRef &
                                           ",'" & _FolioRef & "','" & _RUTOt & "','" & _IdAdicOtr & "','" & _FchRef_Str & "'," & _CodRef & ",'" & _RazonRef & "',0)"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    Next

                End If

            End If

        End If

        _NombreFormato_Modalidad = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                      "NombreFormato", "Empresa = '" & Mod_Empresa & "' And Modalidad = '" & Mod_Modalidad & "' And TipoDoc = '" & _Tido & "'")

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad", "NombreFormato_PDF") Then

            _NombreFormato_PDF_Modalidad = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                      "NombreFormato_PDF", "Empresa = '" & Mod_Empresa & "' And Modalidad = '" & Mod_Modalidad & "' And TipoDoc = '" & _Tido & "'")


        End If

        If String.IsNullOrEmpty(_NombreFormato_Modalidad) Then
            Btn_Mnu_Imprimir_Formato_Modalidad.Text = "No existe formato para esta modalidad (" & Mod_Modalidad & ")"
            Btn_Mnu_Vista_Previa_Formato_Modalidad.Text = "No existe formato para esta modalidad (" & Mod_Modalidad & ")"
        Else
            Btn_Mnu_Imprimir_Formato_Modalidad.Text = "Imprimir en formato de la modalidad (" & _NombreFormato_Modalidad.Trim & ")"
            Btn_Mnu_Vista_Previa_Formato_Modalidad.Text = "Vista previa en formato de la modalidad (" & _NombreFormato_Modalidad.Trim & ")"
        End If

        If String.IsNullOrEmpty(_NombreFormato_PDF_Modalidad) Then
            Btn_Mnu_Imprimir_PDF_Formato_Modalidad.Text = "No existe formato para esta modalidad (" & Mod_Modalidad & ")"
        Else
            Btn_Mnu_Imprimir_PDF_Formato_Modalidad.Text = "Imprimir en formato de la modalidad (" & _NombreFormato_PDF_Modalidad.Trim & ")"
        End If

        OcultarCamposDeGrillas()

        Sb_Formato_Grilla_Detalle_RD()
        Sb_Formato_Grilla_EncPie_RD()

        Btn_Ver_Orden_de_despacho.Visible = (_Tido = "FCV" Or _Tido = "BLV" Or _Tido = "GTI" Or _Tido = "NVI" Or _Tido = "NVV" Or _Tido = "GDV")

        Btn_HabilitarFacturacion.Visible = False

        If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Docu_Ent") Then
            Consulta_sql = "Select Dce.*,Isnull(NOKOFU,'') As NomFunHabilita From " & _Global_BaseBk & "Zw_Docu_Ent Dce WITH (NOLOCK)" & vbCrLf &
                           "Left Join TABFU On Dce.FunAutorizaFac = KOFU" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo
            _Row_Docu_Ent = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        If Not IsNothing(_Row_Docu_Ent) AndAlso _Tido = "NVV" Then

            Dim _Revisar_HbilitarNVVFAc As Boolean = _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar")

            If _Global_Row_Configuracion_General.Item("HabilitarNVVConProdCustomizables") And Not _Row_Docu_Ent.Item("Customizable") Then
                _Revisar_HbilitarNVVFAc = False
            End If

            If _Revisar_HbilitarNVVFAc Then

                Btn_HabilitarFacturacion.Visible = True

                If _Row_Docu_Ent.Item("HabilitadaFac") Then

                    If Global_Thema = Enum_Themas.Oscuro Then
                        Btn_HabilitarFacturacion.ImageAlt = My.Resources.Recursos_Documento.invoice_ok___copia
                    Else
                        Btn_HabilitarFacturacion.Image = My.Resources.Recursos_Documento.invoice_ok
                    End If
                    Btn_HabilitarFacturacion.Tooltip = "Nota de venta habilitada para ser facturada"
                    Me.Text += " (*** HABILITADA PARA SER FACTURADA ***)"

                Else

                    If Global_Thema = Enum_Themas.Oscuro Then
                        Btn_HabilitarFacturacion.ImageAlt = My.Resources.Recursos_Documento.invoice_forbidden___copia
                    Else
                        Btn_HabilitarFacturacion.Image = My.Resources.Recursos_Documento.invoice_forbidden
                    End If
                    Btn_HabilitarFacturacion.Tooltip = "Habilitar nota de venta para ser facturada"
                    Me.Text += " (*** NO ESTA HABILITADA PARA SER FACTURADA ***)"

                End If

            End If

        End If

        Dim _Ruta_PDF = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Ruta_PDF",
                                              "NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Mod_Modalidad & "' And Tido = '" & _Tido & "'")

        If Not String.IsNullOrEmpty(_Ruta_PDF) Then
            Btn_GuardarRutaPDFAutomatica.Tooltip = _Ruta_PDF
        End If

        If _Esdo = "N" Then

            Btn_Imprimir_Documento.Visible = False
            Btn_Cierre_Reactivacion_Documento.Visible = False
            Btn_Traza_Documento.Visible = False
            Btn_Enviar_documento_por_correo.Visible = False
            Btn_Firmar_Documento_DTE.Visible = False
            Btn_Marcar_Baja_Rotacion.Visible = False
            Btn_Archivos_Adjuntos.Visible = False
            Btn_Ver_Orden_de_despacho.Visible = False
            Btn_Consolidar_Stock.Visible = False
            Btn_Revisar_Situacion_Comercial.Visible = False
            Btn_HabilitarFacturacion.Visible = False

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Docu_Archivos 
                            Where Idmaeedo Not In (Select IDMAEEDO From MAEEDO Where IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Docu_Archivos))"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Me.Text += Space(1) & "NULO."

        Else

            Btn_Eliminar_Anular.Visible = (_Tido = "COV" Or _Tido = "OCC" Or _Nudonodefi)

            If _Nudonodefi Then
                Btn_Mnu_Eliminar_Reciclar.Text = "Eliminar y reciclar"
            End If

        End If

        Me.Refresh()

    End Sub

    Sub Sb_Abrir_Documento_Desde_Archivador_XML()

        Try

            _TblEncabezado = _Datos_Documento.Tables("Maeedo")
            _TblDetalle = _Datos_Documento.Tables("Maeddo")
            _TblObservaciones = _Datos_Documento.Tables("Maeedoob")


            _TblEncabezado.Columns.Add("RAZON", GetType(String))
            _TblEncabezado.Columns.Add("ENT_FISICA", GetType(String))
            _TblEncabezado.Columns.Add("RAZON_FISICA", GetType(String))
            _TblEncabezado.Columns.Add("FUNCIONARIO", GetType(String))
            _TblEncabezado.Columns.Add("ELECTRONICO", GetType(String))
            _TblEncabezado.Columns.Add("ESTADO", GetType(String))
            _TblEncabezado.Columns.Add("HORA", GetType(String))
            _TblEncabezado.Columns.Add("NUMECOM", GetType(String))

            Dim _Koen As String = _TblEncabezado.Rows(0).Item("ENDO")
            Dim _Suen As String = _TblEncabezado.Rows(0).Item("SUENDO")

            Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIDO") ' _TblEncabezado.Rows(0).Item("TIPODOCUMENTO")
            Dim _Nudo As String = _TblEncabezado.Rows(0).Item("NUDO")
            Dim _Modo As String = _TblEncabezado.Rows(0).Item("MODO")

            _Row_Maeen = Fx_Traer_Datos_Entidad(_Koen, _Suen)

            _TblEncabezado.Rows(0).Item("RAZON") = _Row_Maeen.Item("NOKOEN")
            _TblEncabezado.Rows(0).Item("ENT_FISICA") = String.Empty
            _TblEncabezado.Rows(0).Item("RAZON_FISICA") = String.Empty
            _TblEncabezado.Rows(0).Item("FUNCIONARIO") = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _TblEncabezado.Rows(0).Item("KOFUDO") & "'")

            _TblEncabezado.Rows(0).Item("NUMECOM") = String.Empty

            Dim _Tidoelec = _TblEncabezado.Rows(0).Item("TIDOELEC")

            Select Case _Tidoelec
                Case True
                    _TblEncabezado.Rows(0).Item("ELECTRONICO") = "Si"
                Case False
                    _TblEncabezado.Rows(0).Item("ELECTRONICO") = "No"
            End Select

            Dim _Esdo = _TblEncabezado.Rows(0).Item("ESDO").ToString.Trim

            Select Case _Esdo
                Case ""
                    _TblEncabezado.Rows(0).Item("ESTADO") = "Vigente"
                Case "C"
                    _TblEncabezado.Rows(0).Item("ESTADO") = "Cerrado"
                Case "N"
                    _TblEncabezado.Rows(0).Item("ESTADO") = "Nulo"
                Case Else
                    _TblEncabezado.Rows(0).Item("ESTADO") = "Otro"
            End Select


            Dim _Horagrab As String = _TblEncabezado.Rows(0).Item("HORAGRAB")

            _Horagrab = Fx_Decodifica_Horagrab(_Horagrab)

            _TblEncabezado.Rows(0).Item("HORA") = _Horagrab

            _TblDetalle.Columns.Add("CANTIDAD", GetType(Double))
            _TblDetalle.Columns.Add("UD", GetType(String))
            _TblDetalle.Columns.Add("PC_DESC", GetType(Double))

            For Each _Fila As DataRow In _TblDetalle.Rows

                Dim _Udtrpr As Integer = _Fila.Item("UDTRPR")
                Dim _Udn As Integer = 1
                Dim _Ud As String

                Select Case _Udtrpr
                    Case 1
                        _Udn = 1
                    Case 2
                        _Ud = 2
                End Select

                _Fila.Item("UD") = _Fila.Item("UD0" & _Udn & "PR")
                _Fila.Item("CANTIDAD") = _Fila.Item("CAPRCO" & _Udn)

                Dim _Podtglli As Double = _Fila.Item("PODTGLLI")
                Dim _Pc_desc As Double

                If _Podtglli > 0 Then _Pc_desc = _Podtglli / 100

                _Fila.Item("PC_DESC") = _Pc_desc

            Next



            _Configuracion_Regional_(_Modo)

            _Datos_Documento.Dispose()

            GrillaEncabezado.DataSource = _TblEncabezado
            GrillaDetalleDoc.DataSource = _TblDetalle

            If _TblObservaciones.Rows.Count = 0 Then
                'Consulta_sql = "Insert Into MAEEDOOB (IDMAEEDO) Values (" & _Idmaeedo & ")" & vbCrLf &
                '               "Select top 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo
                '_TblObservaciones = _Sql.Fx_Get_Tablas(Consulta_sql)
            End If

            Dim _Vanedo As Double = _TblEncabezado.Rows(0).Item("VANEDO")
            Dim _Vaivdo As Double = _TblEncabezado.Rows(0).Item("VAIVDO")
            Dim _Vaimdo As Double = _TblEncabezado.Rows(0).Item("VAIMDO")
            Dim _Vabrdo As Double = _TblEncabezado.Rows(0).Item("VABRDO")
            Dim _Vaabdo As Double = _TblEncabezado.Rows(0).Item("VAABDO")
            Dim _Saldo As Double = _Vabrdo - _Vaabdo

            LblTotalNeto.Text = FormatNumber(_Vanedo, 0)
            LblTotalIva.Text = FormatNumber(_Vaivdo, 0)
            LblTotalImpuestos.Text = FormatNumber(_Vaimdo, 0)
            LblTotalBruto.Text = FormatNumber(_Vabrdo, 0)

            Btn_Ver_Pagos.Enabled = CBool(_Vaabdo)

            LblTotalAbonado.Text = FormatNumber(_Vaabdo, 0)
            LblTotalSaldo.Text = FormatNumber(_Saldo, 0)

            Lbl_Nombre_Entidad_Fisica.Text = Trim(_TblEncabezado.Rows(0).Item("ENT_FISICA")) & " - " &
                                    Trim(_TblEncabezado.Rows(0).Item("RAZON_FISICA"))
            Txt_Responsable.Text = _TblEncabezado.Rows(0).Item("FUNCIONARIO")


            Dim _Hora As String = _TblEncabezado.Rows(0).Item("HORA")

            Me.Text = Trim(_Tido) & " Nro: " & _Nudo & " (Id: " & _Idmaeedo & ")" ', Hora: " & _Hora & ")"

            _Tido = Trim(_TblEncabezado.Rows(0).Item("TIDO"))

            Btn_Marcar_Baja_Rotacion.Visible = _Marcar_Stock_VS_Cantidad
            Btn_Cierre_Reactivacion_Documento.Visible = False

            Select Case _Tido
                Case "FCC"
                    Btn_Marcar_Baja_Rotacion.Visible = True
                Case "OCC", "OCI", "NVV", "COV", "NVI"
                    Btn_Cierre_Reactivacion_Documento.Visible = True
                Case "BLV", "BLX", "BSV", "COV", "ESC", "FCV", "FDB", "FDE", "FDV", "FDX", "FDZ", "FEE",
                     "FEV", "FVL", "FVT", "FVX", "FVZ", "FXV", "FYV", "NVV", "PRO", "RES", "RIN"
                    Btn_Revisar_Situacion_Comercial.Visible = True
            End Select

            Btn_Firmar_Documento_DTE.Visible = _Tidoelec

            If _Tidoelec Then

                If _Tido = "BLV" Then
                    _Tidoelec = False
                ElseIf _Tido = "NCV" Then

                End If

            End If

            OcultarCamposDeGrillas()

            Sb_Formato_Grilla_Detalle_RD()
            Sb_Formato_Grilla_EncPie_RD()

            If _Esdo = "N" Then

                Btn_Imprimir_Documento.Visible = False
                Btn_Cierre_Reactivacion_Documento.Visible = False
                Btn_Traza_Documento.Visible = False
                Btn_Enviar_documento_por_correo.Visible = False
                Btn_Firmar_Documento_DTE.Visible = False
                Btn_Marcar_Baja_Rotacion.Visible = False

                Me.Text += Space(1) & "NULO."

            End If

            Me.Refresh()

        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Sub

    Sub Sb_Abrir_Documento_Desde_Bakapp_Kasi_SQL()

        '_Class_Referencias_DTE = New Class_Referencias_DTE(_Idmaeedo)
        'Dim Tbl_Referencias As DataTable = _Class_Referencias_DTE.Tbl_Referencias

        AddHandler GrillaDetalleDoc.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler GrillaDetalleDoc.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown

        Consulta_sql = My.Resources.Recursos_Ver_Documento.Traer_Documento_Bakapp
        Consulta_sql = Replace(Consulta_sql, "#Id_DocEnc#", _Id_DocEnc)
        Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)

        _Datos_Documento = _Sql.Fx_Get_DataSet(Consulta_sql)

        _TblEncabezado = _Datos_Documento.Tables(0)
        _TblDetalle = _Datos_Documento.Tables(1)
        _TblObservaciones = _Datos_Documento.Tables(2)

        Dim _Tido As String = _TblEncabezado.Rows(0).Item("TipoDocumento")
        Dim _Nudo As String = _TblEncabezado.Rows(0).Item("NroDocumento")
        Dim _Modo As String = _TblEncabezado.Rows(0).Item("Moneda_Doc")

        _Configuracion_Regional_(_Modo)

        _Datos_Documento.Dispose()

        GrillaEncabezado.DataSource = _TblEncabezado
        GrillaDetalleDoc.DataSource = _TblDetalle

        If _TblObservaciones.Rows.Count = 0 Then

            Consulta_sql = "Insert Into MAEEDOOB (IDMAEEDO) Values (" & _Idmaeedo & ")" & vbCrLf &
                           "Select top 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo
            _TblObservaciones = _Sql.Fx_Get_DataTable(Consulta_sql)

        End If

        Dim _Vanedo As Double = _TblEncabezado.Rows(0).Item("TotalNetoDoc")
        Dim _Vaivdo As Double = _TblEncabezado.Rows(0).Item("TotalIvaDoc")
        Dim _Vaimdo As Double = _TblEncabezado.Rows(0).Item("TotalIlaDoc")
        Dim _Vabrdo As Double = _TblEncabezado.Rows(0).Item("TotalBrutoDoc")
        Dim _Vaabdo As Double = 0 ' _TblEncabezado.Rows(0).Item("VAABDO")
        Dim _Saldo As Double = 0 '_Vabrdo - _Vaabdo

        Dim _Timodo As String = _TblEncabezado.Rows(0).Item("TipoMoneda")

        Dim _Decimales As Integer = 0

        If _Timodo = "E" Then
            _Decimales = 2
        End If

        LblTotalNeto.Text = FormatNumber(_Vanedo, _Decimales)
        LblTotalIva.Text = FormatNumber(_Vaivdo, _Decimales)
        LblTotalImpuestos.Text = FormatNumber(_Vaimdo, _Decimales)
        LblTotalBruto.Text = FormatNumber(_Vabrdo, _Decimales)

        Btn_Ver_Pagos.Enabled = CBool(_Vaabdo)

        LblTotalAbonado.Text = FormatNumber(_Vaabdo, _Decimales)
        LblTotalSaldo.Text = FormatNumber(_Saldo, _Decimales)

        Txt_Nombre_Entidad.Text = Space(1) & _TblEncabezado.Rows(0).Item("Nombre_Entidad").ToString.Trim
        Lbl_Nombre_Entidad_Fisica.Text = Space(1) & _TblEncabezado.Rows(0).Item("Nombre_Entidad_Fisica").ToString.Trim
        Txt_Responsable.Text = Space(1) & _TblEncabezado.Rows(0).Item("NomFuncionario")


        'Dim _Hora As String = _TblEncabezado.Rows(0).Item("HORA")

        Me.Text = Trim(_Tido) & " Nro: " & _Nudo & " (Id: " & _Id_DocEnc & ") DOCUMENTO EN CONSTRUCCION" ', Hora: " & _Hora & ")"
        Lbl_Tido.Text = _Tido.Trim

        _Tido = Trim(_TblEncabezado.Rows(0).Item("TipoDoc"))

        Btn_Marcar_Baja_Rotacion.Visible = _Marcar_Stock_VS_Cantidad
        Btn_Cierre_Reactivacion_Documento.Visible = False

        Dim _Esdo = _TblEncabezado.Rows(0).Item("Estado")

        Select Case _Tido
            Case "FCC"
                Btn_Marcar_Baja_Rotacion.Visible = True
            Case "OCC", "OCI", "NVV", "COV", "NVI"
                Btn_Cierre_Reactivacion_Documento.Visible = True
            Case "BLV", "BLX", "BSV", "COV", "ESC", "FCV", "FDB", "FDE", "FDV", "FDX", "FDZ", "FEE",
                 "FEV", "FVL", "FVT", "FVX", "FVZ", "FXV", "FYV", "NVV", "PRO", "RES", "RIN"
                Btn_Revisar_Situacion_Comercial.Visible = True
        End Select

        Btn_Firmar_Documento_DTE.Visible = False


        OcultarCamposDeGrillas()

        Sb_Formato_Grilla_Detalle_Bakapp()
        Sb_Formato_Grilla_EncPie_Bakapp(_Sector.Encabezado)

        Btn_Imprimir_Documento.Visible = False
        Btn_Cierre_Reactivacion_Documento.Visible = False
        Btn_Traza_Documento.Visible = False
        Btn_Enviar_documento_por_correo.Visible = False
        Btn_Firmar_Documento_DTE.Visible = False
        Btn_Marcar_Baja_Rotacion.Visible = False

        Btn_Contenedor.Visible = (_Tido = "OCC")

        Me.Refresh()

    End Sub

    Sub Sb_Ver_Menu_Linea_Activa_Random()

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)
        Dim _Cabeza = GrillaDetalleDoc.Columns(GrillaDetalleDoc.CurrentCell.ColumnIndex).Name

        Dim _Idmaeedo_pa As Integer = _Fila.Cells("IDMAEEDO_PA").Value
        Dim _Idmaeddo As Integer = _Fila.Cells("IDMAEDDO").Value
        Dim _Tidopa As String = _Fila.Cells("TIDOPA").Value
        Dim _Nudopa As String = _Fila.Cells("NUDOPA").Value

        Dim _Empresa As String = _Fila.Cells("EMPRESA").Value
        Dim _Sulido As String = _Fila.Cells("SULIDO").Value
        Dim _Bosulido As String = _Fila.Cells("BOSULIDO").Value

        Dim _Kofulido As String = _Fila.Cells("KOFULIDO").Value
        Dim _Prct As Boolean = _Fila.Cells("PRCT").Value

        If _Cabeza = "BOSULIDO" Then
            Dim _Bodega As String = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO",
                                              "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sulido & "' And KOBO = '" & _Bosulido & "'")
            Lbl_Bodega.Text = "Bodega: " & Trim(_Bodega)
            ShowContextMenu(Menu_Contextual_Bodega)
        ElseIf _Cabeza = "KOFULIDO" Then
            Dim _Vendedor As String = Trim(_Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Kofulido & "'"))
            Lbl_Vendedor.Text = "Vendedor: " & _Vendedor
            ShowContextMenu(Menu_Contextual_Vendedor)
        Else

            If _Idmaeedo_pa <> 0 Then
                Btn_Ver_documento_origen.Image = ImageList_24x24.Images.Item(0)
                Btn_Ver_documento_origen.Text = "Ver documento " & _Tidopa & "-" & _Nudopa
            Else
                Btn_Ver_documento_origen.Image = ImageList_24x24.Images.Item(1)
                Btn_Ver_documento_origen.Text = "No tiene relación"
            End If

            Btn_Ver_Prod_Asociados_Recargo.Visible = _Prct

            Lbl_OpcProducto.Text = "Opciones del producto (Idmaeddo: " & _Idmaeddo & ")"

            ShowContextMenu(Menu_Contextual_Productos)

        End If


    End Sub

    Sub Sb_Ver_Menu_Linea_Activa_Bakapp()

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)
        Dim _Cabeza = GrillaDetalleDoc.Columns(GrillaDetalleDoc.CurrentCell.ColumnIndex).Name

        Dim _Empresa As String = _Fila.Cells("Empresa").Value
        Dim _Sulido As String = _Fila.Cells("Sucursal").Value
        Dim _Bosulido As String = _Fila.Cells("Bodega").Value

        Dim _Kofulido As String = _Fila.Cells("CodVendedor").Value

        If _Cabeza = "Bodega" Then

            Dim _Bodega As String = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO", "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sulido & "' And KOBO = '" & _Bosulido & "'")

            Lbl_Bodega.Text = "Bodega: " & Trim(_Bodega)

            ShowContextMenu(Menu_Contextual_Bodega)

        ElseIf _Cabeza = "CodVendedor" Then

            Dim _Vendedor As String = Trim(_Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Kofulido & "'"))

            Lbl_Vendedor.Text = "Vendedor: " & _Vendedor

            ShowContextMenu(Menu_Contextual_Vendedor)

        Else

            Btn_Ver_documento_origen.Visible = False
            Lbl_Documento_Origen.Visible = False
            Btn_Anotaciones_a_la_linea.Visible = False

            ShowContextMenu(Menu_Contextual_Productos)

        End If

    End Sub

    Sub Sb_Ver_Documento_Origen()

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)

        Dim _Idmaeedo_pa As Integer = _Fila.Cells("IDMAEEDO_PA").Value
        Dim _Idmaeddo As Integer = _Fila.Cells("IDRST").Value

        If _Idmaeedo_pa <> 0 Then

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo_pa, Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.Btn_Ver_Orden_de_despacho.Visible = Btn_Ver_Orden_de_despacho.Visible
            Fm.Idrst = _Idmaeddo
            Fm.Correr_a_la_derecha = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            Beep()
            ToastNotification.Show(Me, "NO HAY RELACIONES PARA LA LINEA ACTIVA", My.Resources.cross,
                                  1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    Sub Sb_Formato_Grilla_EncPie_RD()

        Dim _Tido = _TblEncabezado.Rows(0).Item("TIDO").ToString.Trim
        Dim _SubTido = _TblEncabezado.Rows(0).Item("SUBTIDO").ToString.Trim

        Dim _Color_Documento = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                 "NombreTabla", "Tabla = 'DOCUMENTOS_COLOR' And CodigoTabla = '" & _Tido & _SubTido & "'", True, False, 0)

        Dim _BackColor_Tido As Color

        If _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion") Then
            _Color_Documento = "235, 81, 13"
            Lbl_Tido.Text = Lbl_Tido.Text & " (Ambiente Certificación SII)"
        End If

        Try

            _Color_Documento = Replace(_Color_Documento, ",", ";").ToString.Trim

            Dim _RGB() = Split(_Color_Documento, ";")

            Dim _R As Integer = _RGB(0)
            Dim _G As Integer = _RGB(1)
            Dim _B As Integer = _RGB(2)

            _BackColor_Tido = Color.FromArgb(_R, _G, _B)

            MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
            Panel_Documento.BackColor = _BackColor_Tido

        Catch ex As Exception

        End Try

        With GrillaEncabezado

            OcultarEncabezadoGrilla(GrillaEncabezado, True)

            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 18

            Dim _DisplayIndex = 0

            .Columns("TIDO").HeaderText = "T.D."
            .Columns("TIDO").Width = 35
            .Columns("TIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TIDO").Visible = True
            '.Columns("TIDO").Frozen = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            .Columns("NUDO").Visible = True
            '.Columns("NUDO").Frozen = True
            _DisplayIndex += 1

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 75
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            .Columns("ENDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("ENDO").Visible = True
            _DisplayIndex += 1

            .Columns("SUENDO").HeaderText = "Dest."
            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            .Columns("SUENDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SUENDO").Visible = True
            _DisplayIndex += 1

            '.Columns("RAZON").HeaderText = "Razón Social"
            '.Columns("RAZON").Width = 260
            '.Columns("RAZON").DisplayIndex = _DisplayIndex
            '.Columns("RAZON").Visible = True
            '_DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            _DisplayIndex += 1

            .Columns("FEULVEDO").HeaderText = "Ult.Venci."
            .Columns("FEULVEDO").Width = 70
            .Columns("FEULVEDO").DisplayIndex = _DisplayIndex
            .Columns("FEULVEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEULVEDO").Visible = True
            _DisplayIndex += 1

            .Columns("KOFUDO").HeaderText = "Resp"
            .Columns("KOFUDO").Width = 35
            .Columns("KOFUDO").DisplayIndex = _DisplayIndex
            .Columns("KOFUDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("KOFUDO").Visible = True
            _DisplayIndex += 1

            .Columns("SUDO").HeaderText = "Suc"
            .Columns("SUDO").Width = 40
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            .Columns("SUDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SUDO").Visible = True
            _DisplayIndex += 1

            .Columns("LUVTDO").HeaderText = "C.C."
            .Columns("LUVTDO").Width = 45
            .Columns("LUVTDO").DisplayIndex = _DisplayIndex
            .Columns("LUVTDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("LUVTDO").Visible = True
            _DisplayIndex += 1

            If _Sql.Fx_Exite_Campo("MAEEDO", "LISACTIVA") Then
                .Columns("LISACTIVA").HeaderText = "L.Precio"
                .Columns("LISACTIVA").Width = 60
                .Columns("LISACTIVA").DisplayIndex = _DisplayIndex
                .Columns("LISACTIVA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("LISACTIVA").Visible = True
                _DisplayIndex += 1
            End If

            .Columns("ELECTRONICO").HeaderText = "Elec"
            .Columns("ELECTRONICO").Width = 25
            .Columns("ELECTRONICO").DisplayIndex = _DisplayIndex
            .Columns("ELECTRONICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("ELECTRONICO").Visible = True
            _DisplayIndex += 1

            .Columns("MODO").HeaderText = "TM"
            .Columns("MODO").Width = 40
            .Columns("MODO").DisplayIndex = _DisplayIndex
            .Columns("MODO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MODO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MODO").Visible = True
            _DisplayIndex += 1

            .Columns("TAMODO").HeaderText = "T.Mon."
            .Columns("TAMODO").Width = 50
            .Columns("TAMODO").DisplayIndex = _DisplayIndex
            .Columns("TAMODO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TAMODO").Visible = True
            _DisplayIndex += 1

            Dim _Feer As String = String.Empty

            Dim _Fiad = _Sql.Fx_Trae_Dato("TABTIDO", "FIAD", "TIDO = '" & _Tido & "'")

            If _Tido = "OCC" Then _Fiad = 1
            If _Tido = "NVV" Then _Fiad = -1

            If _Fiad = -1 Then
                _Feer = "F.Despc"
            ElseIf _Fiad = 1 Then
                _Feer = "F.Recep"
            End If

            If Not String.IsNullOrEmpty(_Feer) Then

                .Columns("FEER").HeaderText = _Feer
                .Columns("FEER").Width = 70
                .Columns("FEER").DisplayIndex = _DisplayIndex
                .Columns("FEER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("FEER").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FEER").Visible = True
                _DisplayIndex += 1

            End If

            Select Case _Tido

                Case "DIN", "FCC", "FCT", "FDC", "NCC", "FCV", "NCV", "BLV", "BLC"

                    .Columns("LIBRO").HeaderText = "Corr.Libro"
                    .Columns("LIBRO").Width = 100
                    .Columns("LIBRO").DisplayIndex = _DisplayIndex
                    .Columns("LIBRO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("LIBRO").Visible = True
                    _DisplayIndex += 1

                    .Columns("NUMECOM").HeaderText = "Comp.Contable"
                    .Columns("NUMECOM").Width = 100
                    .Columns("NUMECOM").DisplayIndex = _DisplayIndex
                    .Columns("NUMECOM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("NUMECOM").Visible = True
                    _DisplayIndex += 1

                Case Else

            End Select

            .Columns("ESTADO").HeaderText = "Estado"
            .Columns("ESTADO").Width = 50
            .Columns("ESTADO").DisplayIndex = _DisplayIndex
            .Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("ESTADO").Visible = True
            _DisplayIndex += 1

            .Columns("HORA").HeaderText = "Hora"
            .Columns("HORA").Width = 50
            .Columns("HORA").DisplayIndex = _DisplayIndex
            .Columns("HORA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("HORA").Visible = True
            _DisplayIndex += 1

            .Columns("IDMAEEDO").HeaderText = "Idmaeedo"
            .Columns("IDMAEEDO").Width = 60
            .Columns("IDMAEEDO").DisplayIndex = _DisplayIndex
            .Columns("IDMAEEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("IDMAEEDO").Visible = True
            _DisplayIndex += 1

            .Columns("KOCRYPT").HeaderText = "Kocrypt"
            .Columns("KOCRYPT").Width = 60
            .Columns("KOCRYPT").DisplayIndex = _DisplayIndex
            .Columns("KOCRYPT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("KOCRYPT").Visible = True
            _DisplayIndex += 1

            .Columns("SUBTIDO").HeaderText = "S.T."
            .Columns("SUBTIDO").Width = 35
            .Columns("SUBTIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SUBTIDO").Visible = True
            .Columns("SUBTIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        GrillaEncabezado.Refresh()

    End Sub

    Sub Sb_Formato_Grilla_Detalle_RD()

        With GrillaDetalleDoc

            OcultarEncabezadoGrilla(GrillaDetalleDoc, True)

            '.Columns("ITEM").HeaderText = "Item"
            '.Columns("ITEM").Visible = True
            '.Columns("ITEM").Width = 30
            '.Columns("ITEM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim _Displayindex = 0
            Dim _Campo As String

            _Campo = "BOSULIDO"
            .Columns(_Campo).HeaderText = "Bod"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Frozen = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "LINCONDESP"
            .Columns(_Campo).HeaderText = "DS"
            .Columns(_Campo).ToolTipText = "Despacha stock"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Frozen = True
            .Columns(_Campo).Width = 30
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "KOFULIDO"
            .Columns(_Campo).HeaderText = "Ven"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Frozen = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "KOPRCT"
            .Columns(_Campo).HeaderText = "Código"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Frozen = True
            .Columns(_Campo).Width = 100
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "NOKOPR"
            .Columns(_Campo).HeaderText = "Descripción"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Frozen = True
            .Columns(_Campo).Width = 190
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "UD"
            .Columns(_Campo).HeaderText = "Ud."
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 30
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "CANTIDAD"
            .Columns(_Campo).HeaderText = "Cant."
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 60
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then

                _Campo = "SALDO"
                .Columns(_Campo).HeaderText = "Saldo"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 50
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

            Else

                .Columns("NOKOPR").Width = 255 + 50

            End If

            Dim _NoPuedeVer As Boolean = Fx_TienePermiso_EnDoc(Me, "NO00001", _Idmaeedo, False, False)

            Dim _Tido As String = GrillaEncabezado.Rows(0).Cells("TIDO").Value

            Dim _Venta As Boolean

            If _Tido = "BLV" Or _Tido = "FCV" Or _Tido = "GDV" Or _Tido = "NVV" Then _Venta = True


            Dim _Campo_Precio, _Campo_Total, _Nom_Campo As String

            Dim _Meardo As String = Trim(_TblEncabezado.Rows(0).Item("MEARDO"))

            If _Meardo = "N" Or String.IsNullOrEmpty(_Meardo) Then
                _Campo_Precio = "PPPRNE"
                _Campo_Total = "VANELI"
                _Nom_Campo = " Neto"
            ElseIf _Meardo = "B" Then
                _Campo_Precio = "PPPRBR"
                _Campo_Total = "VABRLI"
                _Nom_Campo = String.Empty
            End If

            If Not _NoPuedeVer Or _Venta Then

                _Campo = "MOPPPR"
                .Columns(_Campo).HeaderText = "TM."
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 30
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = _Campo_Precio
                .Columns(_Campo).HeaderText = "Precio " & _Nom_Campo ' & _Moneda
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 70
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "PC_DESC"
                .Columns(_Campo).HeaderText = "% Dscto"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 55
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "##,##0.## %"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = _Campo_Total
                .Columns(_Campo).HeaderText = "Valor " & _Nom_Campo
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 80
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "FEERLI"
                .Columns(_Campo).HeaderText = "F.Entrega"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 70
                '.Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "UD01PR"
                .Columns(_Campo).HeaderText = "Ud1"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 30
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "CAPRCO1"
                .Columns(_Campo).HeaderText = "Cant.Ud1"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 60
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "RLUDPR"
                .Columns(_Campo).HeaderText = "Rtu"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 40
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "UD02PR"
                .Columns(_Campo).HeaderText = "Ud2"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 30
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "CAPRCO2"
                .Columns(_Campo).HeaderText = "Cant.Ud2"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 60
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

            End If

            If IsNothing(_Codigo_Marcar) Then
                _Codigo_Marcar = String.Empty
            End If

            ' MARCAR DETALLE DE ORIGEN

            For Each _Fila As DataGridViewRow In GrillaDetalleDoc.Rows

                Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value
                Dim _Koprct = _Fila.Cells("KOPRCT").Value

                If _Idrst = _Idmaeddo Or _Codigo_Marcar.ToString.Trim = _Koprct.ToString.Trim Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                    _Fila.DefaultCellStyle.BackColor = Color.LightGreen
                    _Codigo_Marcar = _Koprct
                End If

            Next


            If _Marcar_Grilla_Pendientes Then

                For Each _Fila As DataGridViewRow In GrillaDetalleDoc.Rows

                    Dim _Saldo = _Fila.Cells("SALDO").Value

                    If _Saldo <= 0 Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Gray
                        _Fila.Cells("SALDO").Style.ForeColor = Verde
                    Else
                        _Fila.Cells("SALDO").Style.ForeColor = Rojo
                    End If

                Next

            End If

        End With

    End Sub

    Sub Sb_Formato_Grilla_EncPie_Bakapp(Tipo As _Sector)

        Dim _Tido = _TblEncabezado.Rows(0).Item("TipoDoc")

        Dim _Color_Documento = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                 "NombreTabla", "Tabla = 'DOCUMENTOS_COLOR' And CodigoTabla = '" & _Tido & "'", True, False, 0)

        Dim _BackColor_Tido As Color

        Try

            _Color_Documento = Replace(_Color_Documento, ",", ";").ToString.Trim

            Dim _RGB() = Split(_Color_Documento, ";")

            Dim _R As Integer = _RGB(0)
            Dim _G As Integer = _RGB(1)
            Dim _B As Integer = _RGB(2)

            _BackColor_Tido = Color.FromArgb(_R, _G, _B)

            MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
            Panel_Documento.BackColor = _BackColor_Tido

        Catch ex As Exception

        End Try


        If Tipo = _Sector.Encabezado Then

            With GrillaEncabezado

                OcultarEncabezadoGrilla(GrillaEncabezado, True)

                Dim _DisplayIndex = 0

                .Columns("TipoDoc").HeaderText = "T.D."
                .Columns("TipoDoc").Width = 35
                .Columns("TipoDoc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("TipoDoc").Visible = True
                .Columns("TipoDoc").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NroDocumento").HeaderText = "Número"
                .Columns("NroDocumento").Width = 70
                .Columns("NroDocumento").DisplayIndex = _DisplayIndex
                .Columns("NroDocumento").Visible = True
                _DisplayIndex += 1

                .Columns("CodEntidad").HeaderText = "Entidad"
                .Columns("CodEntidad").Width = 75
                .Columns("CodEntidad").DisplayIndex = _DisplayIndex
                .Columns("CodEntidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("CodEntidad").Visible = True
                _DisplayIndex += 1

                .Columns("CodSucEntidad").HeaderText = "Dest."
                .Columns("CodSucEntidad").Width = 50
                .Columns("CodSucEntidad").DisplayIndex = _DisplayIndex
                .Columns("CodSucEntidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("CodSucEntidad").Visible = True
                _DisplayIndex += 1

                '.Columns("RAZON").HeaderText = "Razón Social"
                '.Columns("RAZON").Width = 260
                '.Columns("RAZON").DisplayIndex = _DisplayIndex
                '.Columns("RAZON").Visible = True
                '_DisplayIndex += 1

                .Columns("Centro_Costo").HeaderText = "C.C."
                .Columns("Centro_Costo").Width = 50
                .Columns("Centro_Costo").DisplayIndex = _DisplayIndex
                .Columns("Centro_Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Centro_Costo").Visible = True
                _DisplayIndex += 1

                .Columns("FechaEmision").HeaderText = "Emisión"
                .Columns("FechaEmision").Width = 75
                .Columns("FechaEmision").DisplayIndex = _DisplayIndex
                .Columns("FechaEmision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("FechaEmision").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FechaEmision").Visible = True
                _DisplayIndex += 1

                .Columns("FechaUltVencimiento").HeaderText = "Ult.Venci."
                .Columns("FechaUltVencimiento").Width = 75
                .Columns("FechaUltVencimiento").DisplayIndex = _DisplayIndex
                .Columns("FechaUltVencimiento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("FechaUltVencimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FechaUltVencimiento").Visible = True
                _DisplayIndex += 1

                .Columns("CodFuncionario").HeaderText = "Resp"
                .Columns("CodFuncionario").Width = 35
                .Columns("CodFuncionario").DisplayIndex = _DisplayIndex
                .Columns("CodFuncionario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("CodFuncionario").Visible = True
                _DisplayIndex += 1

                .Columns("Sucursal").HeaderText = "Suc"
                .Columns("Sucursal").Width = 40
                .Columns("Sucursal").DisplayIndex = _DisplayIndex
                .Columns("Sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Sucursal").Visible = True
                _DisplayIndex += 1

                .Columns("Electronico").HeaderText = "Elect"
                .Columns("Electronico").Width = 30
                .Columns("Electronico").DisplayIndex = _DisplayIndex
                .Columns("Electronico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Electronico").Visible = True
                _DisplayIndex += 1

                .Columns("Valor_Dolar").HeaderText = "TM."
                .Columns("Valor_Dolar").Width = 50
                .Columns("Valor_Dolar").DisplayIndex = _DisplayIndex
                .Columns("Valor_Dolar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Valor_Dolar").DefaultCellStyle.Format = "###,##0.##"
                .Columns("Valor_Dolar").Visible = True
                _DisplayIndex += 1

                .Columns("Moneda_Doc").HeaderText = "T.Mon."
                .Columns("Moneda_Doc").Width = 50
                .Columns("Moneda_Doc").DisplayIndex = _DisplayIndex
                .Columns("Moneda_Doc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Moneda_Doc").Visible = True
                _DisplayIndex += 1

                Dim _Feer As String = String.Empty

                Dim _Fiad = _Sql.Fx_Trae_Dato("TABTIDO", "FIAD", "TIDO = '" & _Tido & "'")

                If _Tido = "OCC" Then _Fiad = 1
                If _Tido = "NVV" Then _Fiad = -1

                If _Fiad = -1 Then
                    _Feer = "F.Despc"
                ElseIf _Fiad = 1 Then
                    _Feer = "F.Recep"
                End If

                If Not String.IsNullOrEmpty(_Feer) Then

                    .Columns("FechaRecepcion").HeaderText = _Feer
                    .Columns("FechaRecepcion").Width = 75
                    .Columns("FechaRecepcion").DisplayIndex = _DisplayIndex
                    .Columns("FechaRecepcion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("FechaRecepcion").DefaultCellStyle.Format = "dd/MM/yyyy"
                    .Columns("FechaRecepcion").Visible = True
                    _DisplayIndex += 1

                End If

                'Select Case _Tido

                '    Case "DIN", "FCC", "FCT", "FDC", "NCC", "FCV", "NCV", "BLV", "BLC"

                '        .Columns("LIBRO").HeaderText = "Corr.Libro"
                '        .Columns("LIBRO").Width = 100
                '        .Columns("LIBRO").DisplayIndex = _DisplayIndex
                '        .Columns("LIBRO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '        .Columns("LIBRO").Visible = True
                '        _DisplayIndex += 1

                '        .Columns("NUMECOM").HeaderText = "Comp.Contable"
                '        .Columns("NUMECOM").Width = 100
                '        .Columns("NUMECOM").DisplayIndex = _DisplayIndex
                '        .Columns("NUMECOM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '        .Columns("NUMECOM").Visible = True
                '        _DisplayIndex += 1

                '    Case Else

                'End Select

                .Columns("Estado").HeaderText = "Estado"
                .Columns("Estado").Width = 50
                .Columns("Estado").DisplayIndex = _DisplayIndex
                .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Estado").Visible = True
                _DisplayIndex += 1

                .Columns("FechaEmision").HeaderText = "Hora"
                .Columns("FechaEmision").Width = 60
                .Columns("FechaEmision").DisplayIndex = _DisplayIndex
                .Columns("FechaEmision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("FechaEmision").DefaultCellStyle.Format = "hh:mm"
                .Columns("FechaEmision").Visible = True
                _DisplayIndex += 1

                .Columns("Id_DocEnc").HeaderText = "Id."
                .Columns("Id_DocEnc").Width = 60
                .Columns("Id_DocEnc").DisplayIndex = _DisplayIndex
                .Columns("Id_DocEnc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Id_DocEnc").Visible = True
                _DisplayIndex += 1

            End With

        End If

    End Sub

    Sub Sb_Formato_Grilla_Detalle_Bakapp()

        With GrillaDetalleDoc

            OcultarEncabezadoGrilla(GrillaDetalleDoc, True)

            '.Columns("ITEM").HeaderText = "Item"
            '.Columns("ITEM").Visible = True
            '.Columns("ITEM").Width = 30
            '.Columns("ITEM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim _Displayindex = 0
            Dim _Campo As String

            _Campo = "Bodega"
            .Columns(_Campo).HeaderText = "Bod"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "CodVendedor"
            .Columns(_Campo).HeaderText = "Ven"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Codigo"
            .Columns(_Campo).HeaderText = "Código"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 100
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Descripcion"
            .Columns(_Campo).HeaderText = "Descripción"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 250
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "UdTrans"
            .Columns(_Campo).HeaderText = "Ud."
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 30
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Cantidad"
            .Columns(_Campo).HeaderText = "Cant."
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 50
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then

                _Campo = "Saldo"
                .Columns(_Campo).HeaderText = "Saldo"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 50
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

            Else

                .Columns("Descripcion").Width = 255 + 50

            End If

            Dim _NoPuedeVer As Boolean = Fx_TienePermiso_EnDoc(Me, "NO00001", _Idmaeedo, False, False)
            Dim _Tido As String = GrillaEncabezado.Rows(0).Cells("TipoDoc").Value

            Dim _Venta As Boolean

            If _Tido = "BLV" Or _Tido = "FCV" Or _Tido = "GDV" Or _Tido = "NVV" Then _Venta = True


            Dim _Campo_Precio, _Campo_Total, _Nom_Campo As String

            Dim _Meardo As String = Trim(_TblEncabezado.Rows(0).Item("DocEn_Neto_Bruto"))

            If _Meardo = "N" Or String.IsNullOrEmpty(_Meardo) Then
                _Campo_Precio = "PrecioNetoUd"
                _Campo_Total = "ValNetoLinea"
                _Nom_Campo = " Neto"
            ElseIf _Meardo = "B" Then
                _Campo_Precio = "PrecioBrutoUd"
                _Campo_Total = "ValBrutoLinea"
                _Nom_Campo = String.Empty
            End If

            If Not _NoPuedeVer Or _Venta Then

                _Campo = "Moneda"
                .Columns(_Campo).HeaderText = "TM."
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 30
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = _Campo_Precio
                .Columns(_Campo).HeaderText = "Precio " & _Nom_Campo ' & _Moneda
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 70
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = "Pc_Desc"
                .Columns(_Campo).HeaderText = "% Dscto"
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 55
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "##,##0.## %"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

                _Campo = _Campo_Total
                .Columns(_Campo).HeaderText = "Valor " & _Nom_Campo
                .Columns(_Campo).Visible = True
                .Columns(_Campo).Width = 80
                .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
                .Columns(_Campo).DisplayIndex = _Displayindex
                _Displayindex += 1

            End If


            ' MARCAR DETALLE DE ORIGEN

            'For Each _Fila As DataGridViewRow In GrillaDetalleDoc.Rows

            '    Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value

            '    If _Idrst = _Idmaeddo Then
            '        _Fila.DefaultCellStyle.BackColor = Color.LightGreen
            '    End If

            'Next

            'If _Marcar_Grilla_Pendientes Then

            '    For Each _Fila As DataGridViewRow In GrillaDetalleDoc.Rows

            '        Dim _Saldo = _Fila.Cells("SALDO").Value

            '        If _Saldo <= 0 Then
            '            _Fila.DefaultCellStyle.ForeColor = Color.Gray
            '            _Fila.Cells("SALDO").Style.ForeColor = Color.Green
            '        Else
            '            _Fila.Cells("SALDO").Style.ForeColor = Color.Red
            '        End If

            '    Next

            'End If

        End With

    End Sub

    Sub OcultarCamposDeGrillas()

        OcultarEncabezadoGrilla(GrillaEncabezado)
        OcultarEncabezadoGrilla(GrillaDetalleDoc)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Frm_DocumentoTraza_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Configuracion_Regional_()
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Observaciones_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Observaciones.Click

        Dim Fm As New Frm_Ver_Documento_Observaciones(_TblEncabezado.Rows(0), _TblObservaciones.Rows(0),
                                                      (_Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Or
                                                       _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Arcvhivador_XML))

        Fm.Pro_Class_Referencias_DTE = _Class_Referencias_DTE
        Fm.Btn_Editar_Fecha.Visible = (_Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Btn_Editar_Observaciones.Visible = (_Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                  1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()

    End Sub

    Private Sub GrillaEncabezado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaEncabezado.CellDoubleClick

        Dim _Cabeza = GrillaEncabezado.Columns(GrillaEncabezado.CurrentCell.ColumnIndex).Name
        Dim _RowEncabezado As DataRow = _TblEncabezado.Rows(0)


        Select Case _Cabeza
            Case "ENDO"
                Sb_Ver_Entidad()
            Case "FEULVEDO"
                Sb_Ver_Vencimientos()
            Case "FEER"
                Call Btn_Observaciones_Click(Nothing, Nothing)
            Case "ELECTRONICO"

                If Not _RowEncabezado.Item("TIDOELEC") AndAlso _RowEncabezado.Item("TIDO") = "FCC" Then

                    If MessageBoxEx.Show(Me, "¿Confirma dejar el documento como electrónico?", "Cambiar LIBRO",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        If Fx_TienePermiso_EnDoc(Me, "Doc00093", _Idmaeedo) Then
                            Return
                        End If

                        Consulta_sql = "Update MAEEDO Set TIDOELEC = 1 Where IDMAEEDO = " & _Idmaeedo

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                            _TblEncabezado.Rows(0).Item("TIDOELEC") = True
                            _TblEncabezado.Rows(0).Item("ELECTRONICO") = "Si"
                            MessageBoxEx.Show(Me, "El documento ahora es electrónico", "Información",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If

                End If

            Case "LIBRO"

                Dim _Tido As String = _RowEncabezado.Item("TIDO")
                Dim _Libro As String = _RowEncabezado.Item("LIBRO")
                Dim _Empresa As String = _RowEncabezado.Item("EMPRESA")
                Dim _Sucursal As String = _RowEncabezado.Item("SUDO")
                Dim _NroLibro = Convert.ToInt32(Mid(_Libro, 10))

                If _Tido = "FCC" Then

                    If MessageBoxEx.Show(Me, "¿Desea cambiar el correlativo del libro de compras?", "Cambiar LIBRO",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        If Not Fx_TienePermiso_EnDoc(Me, "Doc00065", _Idmaeedo) Then
                            Return
                        End If

                        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el nuevo número del libro", "Cambiar LIBRO", _Libro, False,,, True)

                        If _Aceptar Then

                            Consulta_sql = "Update MAEEDO Set LIBRO = '" & _Libro & "' Where IDMAEEDO = " & _Idmaeedo

                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                                _TblEncabezado.Rows(0).Item("LIBRO") = _Libro
                                MessageBoxEx.Show(Me, "Número de libro cambiado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If

                        End If

                    End If

                End If

        End Select

    End Sub

    Sub Sb_Ver_Entidad()

        If Not Fx_TienePermiso_EnDoc(Me, "CfEnt001", _Idmaeedo) Then
            Return
        End If

        Dim Fm As New Frm_Crear_Entidad_Mt
        Fm.Fx_Llenar_Entidad(_TblEncabezado.Rows(0).Item("ENDO"), _TblEncabezado.Rows(0).Item("SUENDO"))
        Fm.CrearEntidad = False
        Fm.EditarEntidad = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Sub Sb_Ver_Vencimientos()

        Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIDO")

        If _Tido = "FCC" Or
           _Tido = "FCT" Or
           _Tido = "FCV" Or
           _Tido = "FDB" Or
           _Tido = "FDC" Or
           _Tido = "FDV" Or
           _Tido = "FDX" Or
           _Tido = "FDZ" Or
           _Tido = "FEE" Or
           _Tido = "FEV" Or
           _Tido = "FVL" Or
           _Tido = "FVT" Or
           _Tido = "FVX" Or
           _Tido = "FVZ" Or
           _Tido = "BLC" Or
           _Tido = "BLV" Or
           _Tido = "BLX" Or
           _Tido = "BSV" Then

            Dim Fm As New Frm_Cambio_Fecha_Vencimientos(_Idmaeedo)
            Fm.ShowDialog(Me)

            If Fm.Pro_Fechas_Actualizadas Then

                Sb_Abrir_Documento_Desde_Random_SQL()

                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE",
                                      My.Resources.save,
                                      2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If

        Else

            Beep()
            ToastNotification.Show(Me, "NO APLICA VENCIMIENTOS", My.Resources.cross,
                                  1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

    End Sub

    Private Sub Btn_Anotaciones_al_documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anotaciones_al_documento.Click

        Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Idmaeedo, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEEDO)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then
                        Sb_Ver_Menu_Linea_Activa_Random()
                    ElseIf _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Bakapp_Kasi Then
                        Sb_Ver_Menu_Linea_Activa_Bakapp()
                    End If

                End If
            End With
        End If
    End Sub

    Private Sub Sb_Grilla_Encabezado_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Encabezado)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Codigo As String

        If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then
            _Codigo = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index).Cells("KOPRCT").Value
        ElseIf _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Bakapp_Kasi Then
            _Codigo = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index).Cells("Codigo").Value
        End If

        Dim _Tipo_Doc As Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc = Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Ninguno
        Dim _Endo As String = String.Empty
        Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIDO")

        If VerSoloEntidadesDelVendedor Then
            If _Tido = "COV" Or _Tido = "NVV" Or _Tido = "FCV" Or _Tido = "GDV" Or _Tido = "GDP" Or _Tido = "NCV" Then
                _Tipo_Doc = Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta
                _Endo = _RowEntidad.Item("KOEN")
            End If
        End If

        Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt()
        Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo, _Endo, _Tipo_Doc)

    End Sub

    Private Sub GrillaDetalleDoc_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)

        Dim _Tido = Trim(_TblEncabezado.Rows(0).Item("TIDO"))
        Dim _Descripcion As String = Trim(NuloPorNro(_Fila.Cells("NOKOPR").Value, ""))
        Dim _Lista = _Fila.Cells("LISTA").Value
        Dim _Tidopa As String = ", Desde " & Trim(_Fila.Cells("TIDOPA").Value) & "-"
        Dim _Nudopa As String = Trim(_Fila.Cells("NUDOPA").Value)
        Dim _Obs = String.Empty

        Dim _Vaivli As Double = _Fila.Cells("VAIVLI").Value

        If _Tido = "FCC" Then

            Dim _Color As Color = _Fila.DefaultCellStyle.BackColor

            Select Case _Color
                Case Color.Yellow
                    _Obs = vbCrLf & "[Sin venta, Baja Rot. anual y no tiene hermanos con stock]" : _Descripcion = Trim(_Descripcion)
                Case Color.Orange
                    _Obs = vbCrLf & "[Sin venta, Baja Rot. anual y tiene hermanos con stock]" : _Descripcion = Trim(_Descripcion)
                Case Color.Violet
                    _Obs = vbCrLf & "[Sin venta, Rev. stock hermanos]" : _Descripcion = Trim(_Descripcion)
            End Select

        End If

        If String.IsNullOrEmpty(_Nudopa) Then _Tidopa = String.Empty : _Nudopa = String.Empty

        LblDescripcion.Text = _Descripcion & ", Lista [" & _Lista & "]" & _Tidopa & _Nudopa & ", I.V.A. " & FormatNumber(_Vaivli, 2) & _Obs

    End Sub

    Private Sub Btn_Ver_Vencimientos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Vencimientos.Click
        Sb_Ver_Vencimientos()
    End Sub

    Private Sub Btn_Ver_Entidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Entidad.Click
        Sb_Ver_Entidad()
    End Sub

    Private Sub Btn_Enviar_documento_por_correo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Enviar_documento_por_correo.Click
        ShowContextMenu(Menu_Contextual_Correo)
    End Sub

    Private Sub Btn_Observacione_linea_documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Observacione_linea_documento.Click

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)

        If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Random_SQL Then

            Dim _Idmaeddo As Integer = _Fila.Cells("IDMAEDDO").Value
            Dim _Observa As String = _Fila.Cells("OBSERVA").Value
            Dim _Aceptado As Boolean

            _Aceptado = InputBox_Bk(Me, "Máximo 200 caracteres", "Observaciones en la lía del documento",
                                    _Observa,
                                   True, _Tipo_Mayus_Minus.Normal, 200, True, _Tipo_Imagen.Texto, True)

            If _Aceptado Then

                Consulta_sql = "Update MAEDDO Set OBSERVA = '" & Trim(_Observa) & "' Where IDMAEDDO = " & _Idmaeddo

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    _Fila.Cells("OBSERVA").Value = _Observa
                    ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                         1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If

            End If

        ElseIf _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Bakapp_Kasi Then

            Dim _Observa As String = _Fila.Cells("Observa").Value

            MessageBoxEx.Show(Me, _Observa, "Observaciones de la línea", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Anotaciones_a_la_linea_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anotaciones_a_la_linea.Click

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)

        Dim _Idmaeddo As Integer = _Fila.Cells("IDMAEDDO").Value

        Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Idmaeddo, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEDDO)
        Fm.ShowDialog(Me)

        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_documento_origen_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_documento_origen.Click
        Sb_Ver_Documento_Origen()
    End Sub

#Region "REVISAR STOCK"

    Sub Sb_Revisar_Stock_VS_Cantidad()

        Dim _Dejar_Min_Rot_Cero As Boolean
        Dim _Aceptado As Boolean

        If _Min_Rotacion_Anual = 0 Then
            Dim _Valor As String = 5

            _Aceptado = InputBox_Bk(Me, "Digite las ventas mínimas anuales" & vbCrLf &
                                  "para calcular la sospecha",
                                  "Ventas mínimas", _Valor, False, _Tipo_Mayus_Minus.Mayusculas, , True,
                                  _Tipo_Imagen.Texto, False, _Tipo_Caracter.Solo_Numeros_Enteros, False)

            If _Aceptado Then
                _Min_Rotacion_Anual = De_Txt_a_Num_01(_Valor, 0)
                _Dejar_Min_Rot_Cero = True
            Else
                Exit Sub
            End If

        End If

        Beep()
        ToastNotification.Show(Me, "REVISANDO, POR FAVOR ESPERE...", Btn_Marcar_Baja_Rotacion.Image,
                               3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


        Try
            Me.Enabled = False

            Dim _Revisar_Stock_Relacionados As Boolean

            For Each _Fila As DataGridViewRow In GrillaDetalleDoc.Rows
                _Fila.DefaultCellStyle.ForeColor = Color.Black
                _Fila.DefaultCellStyle.BackColor = Color.White
            Next

            For Each _Fila As DataGridViewRow In GrillaDetalleDoc.Rows

                Dim _Codigo As String = _Fila.Cells("KOPRCT").Value
                Dim _Detalle As String = _Fila.Cells("NOKOPR").Value
                Dim _Unidad As Integer = _Fila.Cells("UDTRPR").Value
                Dim _Cantidad_Ud1 As Double = _Fila.Cells("CAPRCO1").Value
                Dim _Cantidad_Ud2 As Double = _Fila.Cells("CAPRCO2").Value

                Dim _Stock_Ud1_Rem As Double
                Dim _Stock_Ud2_Rem As Double

                Consulta_sql = "SELECT ISNULL(SUM(STFI1),0) AS STFI1,ISNULL(SUM(STFI2),0) AS STFI2 FROM MAEST Where KOPR = '" & _Codigo & "'"
                Dim _TblStock As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                GrillaDetalleDoc.CurrentCell = GrillaDetalleDoc.Rows(_Fila.Index).Cells("CANTIDAD")
                System.Windows.Forms.Application.DoEvents()

                Dim Fm As New Frm_EstadisticaProducto(_Codigo)

                Dim _Row_Producto As DataRow = Fm.Pro_Row_Producto

                Fm.Sb_Actualizar_Tbl_Productos_Hermanos()
                Fm.Sb_Actualizar_Estadisticas_Un_Solo_Producto(_Row_Producto) '(_Codigo)
                Fm.Sb_Actualizar_Grafico_Movimiento_Stock(Mod_Empresa)

                Dim _Tbl_Productos_Hermanos As DataTable = Fm.Pro_Tbl_Productos_Hermanos

                Dim _Tbl_Mov As DataTable = Fm.Pro_Tbl_Moviminetos_Acumulados
                Dim _Rot_Anual As Double = _Tbl_Mov.Rows(1).Item("Ult.12 Meses")
                Fm.Dispose()

                Dim _Filtro_Hermanos As String

                If CBool(_Tbl_Productos_Hermanos.Rows.Count) Then

                    _Filtro_Hermanos = Generar_Filtro_IN(_Tbl_Productos_Hermanos, "", "KOPR", False, False, "'")
                    Consulta_sql = "SELECT ISNULL(SUM(STFI1),0) AS STFI1,ISNULL(SUM(STFI2),0) AS STFI2" & vbCrLf &
                                   "FROM MAEST Where KOPR IN " & _Filtro_Hermanos


                    Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    If CBool(_Tbl.Rows.Count) Then
                        _Stock_Ud1_Rem = _Tbl.Rows(0).Item("STFI1")
                        _Stock_Ud2_Rem = _Tbl.Rows(0).Item("STFI2")

                        If CBool(_Stock_Ud1_Rem + _Stock_Ud2_Rem) Then
                            _Revisar_Stock_Relacionados = True
                        Else
                            _Revisar_Stock_Relacionados = False
                        End If

                    End If
                Else
                    _Stock_Ud1_Rem = 0
                    _Stock_Ud2_Rem = 0
                    _Revisar_Stock_Relacionados = False
                End If


                If CBool(_TblStock.Rows.Count) Then

                    Dim _Stock_FiUd1 As Double = _TblStock.Rows(0).Item("STFI1")
                    Dim _Stock_FiUd2 As Double = _TblStock.Rows(0).Item("STFI2")

                    Dim _Stock_Consolidado_Ud1 As Double = _Stock_FiUd1 + _Stock_Ud1_Rem
                    Dim _Stock_Consolidado_Ud2 As Double = _Stock_FiUd2 + _Stock_Ud2_Rem

                    _Fila.DefaultCellStyle.ForeColor = Color.Gray

                    'Amarillo: El producto no se ha vendido y se venden menos que la cantidad mínima de ventas en un año y no tiene hermanos con Stock

                    'Naranja: El producto no se ha vendido y se venden menos que la cantidad mínima de ventas en un año y tiene hermanos con Stock

                    'Violeta: El producto no se ha vendido y tienes más stock en los hermanos

                    If _Unidad = 1 Then
                        If CBool(_Stock_Consolidado_Ud1) Then
                            If _Rot_Anual <= _Min_Rotacion_Anual Then
                                _Fila.DefaultCellStyle.ForeColor = Color.Black
                                'Rotacion anual menor a la cantidad minima vendida en un año
                                If _Revisar_Stock_Relacionados Then
                                    _Fila.DefaultCellStyle.BackColor = Color.Orange
                                    'Tiene productos hermanos
                                Else
                                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                                    'No tiene productos hermanos
                                End If
                            Else
                                If CBool(_Stock_FiUd1) Then
                                    If _Stock_Ud1_Rem > _Stock_FiUd1 Then
                                        _Fila.DefaultCellStyle.ForeColor = Color.Black
                                        _Fila.DefaultCellStyle.BackColor = Color.Violet
                                        'Tienen stock lo hermanos
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If CBool(_Stock_Consolidado_Ud2) Then
                            If _Rot_Anual <= _Min_Rotacion_Anual Then
                                _Fila.DefaultCellStyle.ForeColor = Color.Black
                                _Fila.DefaultCellStyle.BackColor = Color.Yellow

                                If _Revisar_Stock_Relacionados Then
                                    _Fila.DefaultCellStyle.BackColor = Color.Orange
                                Else
                                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                                End If
                            Else
                                If CBool(_Stock_FiUd2) Then
                                    If _Stock_Ud2_Rem > _Stock_FiUd2 Then
                                        _Fila.DefaultCellStyle.ForeColor = Color.Black
                                        _Fila.DefaultCellStyle.BackColor = Color.Violet
                                    End If
                                End If
                            End If
                        End If
                    End If

                End If

            Next

            Beep()
            ToastNotification.Show(Me, "PROCESO TERMINADO", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            If _Dejar_Min_Rot_Cero Then
                _Min_Rotacion_Anual = 0
            End If
            Me.Enabled = True
        End Try

    End Sub

#End Region

    Private Sub Btn_Traza_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Traza_Documento.Click

        Dim _Tido As String = Trim(_TblEncabezado.Rows(0).Item("TIDO"))
        Dim _Nudo As String = Trim(_TblEncabezado.Rows(0).Item("NUDO"))
        Dim _Tipodocumento As String = Trim(_TblEncabezado.Rows(0).Item("TIPODOCUMENTO"))

        Dim Fm As New Frm_Trazabilidad_documento(_Idmaeedo, 0)
        Fm.Text = "TRAZABILIDAD DOCUMENTO " & _Tipodocumento & " (" & _Tido & "-" & _Nudo & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    Function Fx_Origen(_Idmaeedo As Integer)

        Consulta_sql = "Select Distinct IDRST From MAEDDO WITH (NOLOCK)" & vbCrLf &
                       "Where ARCHIDRST = 'MAEDDO' And IDMAEEDO = " & _Idmaeedo
        Dim _TblDetalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblDetalle.Rows.Count) Then

        End If


    End Function

    Private Sub Btn_Marcar_Baja_Rotacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Marcar_Baja_Rotacion.Click
        Sb_Revisar_Stock_VS_Cantidad()
    End Sub

    Private Sub Btn_Ver_Pagos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Pagos.Click

        Dim _Pagos_Actualizados As Boolean

        Dim Fm As New Frm_Ver_Documento_Pagos(_Idmaeedo)
        Fm.ShowDialog(Me)
        _Pagos_Actualizados = Fm.Pagos_Actualizados
        Fm.Dispose()

        If _Pagos_Actualizados Then
            Sb_Abrir_Documento_Desde_Random_SQL()
        End If

    End Sub

    Private Sub Btn_Imprimir_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Documento.Click

        Select Case _Tipo_Apertura
            Case Enum_Tipo_Apertura.Desde_Random_SQL
                Btn_Mnu_Imprimir_Formato_Modalidad.Enabled = Not String.IsNullOrEmpty(_NombreFormato_Modalidad)
                Btn_Mnu_Vista_Previa_Formato_Modalidad.Enabled = Not String.IsNullOrEmpty(_NombreFormato_Modalidad)
                ShowContextMenu(Menu_Contextual_Imprimir_Vista_Previa)
            Case Enum_Tipo_Apertura.Desde_Arcvhivador_XML
                Sb_Imprimir_PDF_Doc_desde_XML()
        End Select

    End Sub

    Private Sub Btn_Firmar_Documento_DTE_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Firmar_Documento_DTE.Click

        Dim _Firma_Bakapp As Boolean
        Dim _Firma_RunMonitor As Boolean
        Dim _Tido As String = Pro_Row_Maeedo.Item("TIDO")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad 
                        Where Empresa = '" & Mod_Empresa & "' And Modalidad = '" & Mod_Modalidad & "' And TipoDoc = '" & _Tido & "'"
        Dim _Row_Formato_Modalidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _RevisarFacElec_Bakapp_Hefesto = False

        Try
            If _Row_Formato_Modalidad.Item("TimbrarXBakapp") Then
                _Firma_Bakapp = True
            Else
                _Firma_RunMonitor = True
            End If
        Catch ex As Exception
            _RevisarFacElec_Bakapp_Hefesto = True
        End Try

        If _RevisarFacElec_Bakapp_Hefesto Then
            Try
                If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                    _Firma_Bakapp = True
                Else
                    _Firma_RunMonitor = True
                End If
            Catch ex As Exception
                _Firma_RunMonitor = True
            End Try
        End If

        If _Firma_RunMonitor Then
            ShowContextMenu(Menu_Contextual_DTE)
        End If

        If _Firma_Bakapp Then
            ShowContextMenu(Menu_Contextual_DTE_Hefesto)
        End If

        'Try
        '    If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
        '        ShowContextMenu(Menu_Contextual_DTE_Hefesto)
        '    Else
        '        ShowContextMenu(Menu_Contextual_DTE)
        '    End If
        'Catch ex As Exception
        '    ShowContextMenu(Menu_Contextual_DTE)
        'End Try

    End Sub

    Private Sub Btn_Revisar_Situacion_Comercial_Click(sender As Object, e As EventArgs) Handles Btn_Revisar_Situacion_Comercial.Click

        If Not Fx_TienePermiso_EnDoc(Me, "Doc00084", _Idmaeedo) Then Return

        Dim Fm As New Frm_Remotas_Analisi_Dscto_X_Documento_Rd(Cadena_ConexionSQL_Server, Nothing, Nothing,
                                                               Frm_Remotas_Analisi_Dscto_X_Documento_Rd.Enum_Tabla.Maeedo, _Idmaeedo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Correo_Outlook_Click(sender As Object, e As EventArgs) Handles Btn_Correo_Outlook.Click

        Dim _Idmaeedo As String = Pro_Row_Maeedo.Item("IDMAEEDO")
        Dim _Koen As String = Pro_Row_Maeedo.Item("ENDO")
        Dim _Suen As String = Pro_Row_Maeedo.Item("SUENDO")
        Dim _Tido As String = Pro_Row_Maeedo.Item("TIDO")
        Dim _Nudo As String = Pro_Row_Maeedo.Item("NUDO")
        Dim _Subtido As String = Pro_Row_Maeedo.Item("SUBTIDO")

        Dim _Asunto As String = _Tido & " Nro:" & _Nudo
        Dim _Para As String '= _Email_Para
        Dim _Cuerpo = String.Empty

        Dim _Email_Para As String = Trim(_Sql.Fx_Trae_Dato("MAEEN", "EMAILCOMER", "KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"))

        Dim _Pregunta = MessageBoxEx.Show(Me, "¿Desea adjuntar archivo PDF?", "Adjuntar archivo PDF", vbYesNoCancel, MessageBoxIcon.Question)

        Dim _Archivo_PDF_Adjunto As String
        Dim _CrearHtml = True

        If _Pregunta = DialogResult.Yes Then

            Dim _NombreFormato As String
            Dim _Formato_Seleccionado As Boolean

            Dim Fm As New Frm_Seleccionar_Formato(_Tido)

            If CBool(Fm.Tbl_Formatos.Rows.Count) Then

                Fm.ShowDialog(Me)
                _Formato_Seleccionado = Fm.Formato_Seleccionado
                Fm.Dispose()

            End If

            If Not Fm.Formato_Seleccionado Then
                MessageBoxEx.Show(Me, "No se selecciono ningún formato", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If


            _Subtido = Fm.Row_Formato_Seleccionado.Item("Subtido")
            _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")

            Dim _Path = AppPath() & "\Data\" & RutEmpresaActiva & "\Tmp"

            If Not Directory.Exists(_Path) Then
                System.IO.Directory.CreateDirectory(_Path)
            End If


            Dim _Doc_Electronico As Boolean = Pro_Row_Maeedo.Item("TIDOELEC")

            Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_Idmaeedo,
                                                                     _Tido,
                                                                     _NombreFormato,
                                                                     _Tido & "-" & _Nudo,
                                                                     _Path, _Tido & "-" & _Nudo, False)
            _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)
            Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error

            Dim _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

            If _Existe_File Then
                _Archivo_PDF_Adjunto = _Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf"
                _CrearHtml = False
            Else
                MessageBoxEx.Show(Me, _Error_Pdf, "Problema al crear PDF", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

        If _CrearHtml Then

            Dim Crea_Htm As New Clase_Crear_Documento_Htm
            Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

            Dim fic As String = _Ruta & "\Documento.Htm"

            Dim _Mostrar_Precios As Boolean

            If MessageBoxEx.Show(Me, "¿Desea mostrar los precios?", "Enviar documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _Mostrar_Precios = True
            End If

            If Crea_Htm.Fx_Crear_Documento_Htm(_Idmaeedo, _Ruta, _Mostrar_Precios) Then

                Dim _Cuerpo_Html = LeeArchivo(fic)

                _Cuerpo_Html = Replace(_Cuerpo_Html, "&aacute", "á")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&eacute", "é")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&iacute", "í")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&oacute", "ó")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&uacute", "ú")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&ntilde", "ñ")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&Ntilde", "Ñ")
                _Cuerpo = _Cuerpo_Html

            End If

        End If

        Dim _Envio_Occ_Mail As New Class_Outlook

        _Para = _Email_Para

        _Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Archivo_PDF_Adjunto, _Asunto, _Cuerpo, True)

    End Sub

    Private Sub Btn_Correo_Diablito_Click(sender As Object, e As EventArgs) Handles Btn_Correo_Diablito.Click

        Dim _Idmaeedo = _TblEncabezado.Rows(0).Item("IDMAEEDO")
        Dim _Koen = _TblEncabezado.Rows(0).Item("ENDO")
        Dim _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        Dim _Kofudo = _TblEncabezado.Rows(0).Item("KOFUDO")

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEENMAIL", "KOEN = '" & _Koen & "' And KOMAIL = '001'"))

        If Not _Reg Then

            MessageBoxEx.Show(Me, "La Entidad que no tiene Email en la tabla de notificaciones por email" & vbCrLf &
                             "Para poder reenviar un correo debe actualizar los datos desde el la ficha de la entidad:" & vbCrLf &
                             "Desde Maestro de entidades -> Ficha entidad -> Notificaciones vía correo",
                             "El documento no fue enviado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Consulta_sql = "Select Distinct TipoDoc,Codigo,Nombre_Funcionario,Impresora,NombreFormato,Nro_Copias_Impresion,Nombre_Correo,
                        Correo_Para,Correo_CC,Correo_Body,Picking, NombreFormato_Correo,Para_Maeenmail
                        From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion
                        Where TipoDoc = '" & _Tido & "' And Codigo = '" & _Kofudo & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl.Rows.Count) Then

            MessageBoxEx.Show(Me, "No se encontró ningún equipo configurado para enviar correos automáticamente." & vbCrLf &
                              "Para poder enviar el correo debe estar configurado el sistema Demonio en algún equipo de la empresa.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Documentos_Enviados = 0

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Nombre_Correo = _Fila.Item("Nombre_Correo")
            Dim _NombreFormato_Correo = _Fila.Item("NombreFormato_Correo")
            Dim _Para_Maeenmail = _Fila.Item("Para_Maeenmail")

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo = '" & _Nombre_Correo & "'"
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Correo) Then

                Dim _Asunto = _Row_Correo.Item("Asunto")
                Dim _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje")

                _CuerpoMensaje = Replace(_CuerpoMensaje, "'", "''")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & Space(1) &
                                "(NombreEquipo,Nombre_Correo,CodFuncionario,Asunto,Para,Cc,Idmaeedo," &
                                "Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Para_Maeenmail) " & vbCrLf &
                                "Select '','" & _Nombre_Correo & "','" & _Kofudo & "','" & _Asunto & "','','',IDMAEEDO,TIDO,NUDO,'" & _NombreFormato_Correo & "',1,0,0,1,'" & _CuerpoMensaje & "',Getdate()," & Convert.ToInt32(_Para_Maeenmail) & vbCrLf &
                                "From MAEEDO Where IDMAEEDO = " & _Idmaeedo
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    _Documentos_Enviados += 1
                End If

            End If

        Next

        If Convert.ToBoolean(_Documentos_Enviados) Then

            MessageBoxEx.Show(Me, "Documento enviado", "Envio de correo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Frm_Ver_Documento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        _Configuracion_Regional_()

        Dim _Cl_Contenedor As New Cl_Contenedor
        _Cl_Contenedor.Fx_Soltar_Contenedor_Tomado()

    End Sub

    Private Sub Btn_Permisos_Asociados_Click(sender As Object, e As EventArgs) Handles Btn_Permisos_Asociados.Click

        Dim Fm As New Frm_Ver_Documentos_Permisos(_Idmaeedo)
        If Convert.ToBoolean(Fm.Pro_Tbl_Remotas.Rows.Count) Then
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "No se encontraron permisos asociados", "Permisos asociados", MessageBoxButtons.OK,
                              MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)
        End If
        Fm.Dispose()

    End Sub

    Private Sub Frm_Ver_Documento_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick

        Dim Copiar = _Idmaeedo
        Clipboard.SetText(Copiar)

    End Sub

    Enum Enum_Tipo_Impresion
        Imprimir
        Vista_Previa
        PDF
    End Enum

    Sub Sb_Imprimir_Documento(_Tipo_Impresion As Enum_Tipo_Impresion, _NombreFormato As String)

        If Not Fx_TienePermiso_EnDoc(Me, "Doc00012", _Idmaeedo) Then
            Return
        End If

        Dim _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        Dim _Subtido = String.Empty

        If _Tido = "GDD" Or _Tido = "GDP" Then
            _Subtido = _TblEncabezado.Rows(0).Item("SUBTIDO")
        End If

        Dim _Vista_Previa As Boolean

        If String.IsNullOrEmpty(_NombreFormato) Then

            If Not Fx_TienePermiso_EnDoc(Me, "Doc00038", _Idmaeedo) Then
                Return
            End If

            Dim _Formato_Seleccionado As Boolean

            Dim Fm As New Frm_Seleccionar_Formato(_Tido)

            If CBool(Fm.Tbl_Formatos.Rows.Count) Then

                Fm.ShowDialog(Me)
                _Formato_Seleccionado = Fm.Formato_Seleccionado
                If Not _Formato_Seleccionado Then Return
                _Subtido = Fm.Row_Formato_Seleccionado.Item("Subtido").ToString.Trim
                _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                Fm.Dispose()

            End If

        End If


        If Not String.IsNullOrEmpty(_NombreFormato) Then

            If _NombreFormato = "" Then
                _NombreFormato = String.Empty
            End If

            Dim _Instance As New PrinterSettings
            Dim _ImpresosaPredt As String = _Instance.PrinterName
            Dim _Seleccionar_Impresora = True

            Select Case _Tipo_Impresion

                Case Enum_Tipo_Impresion.Imprimir, Enum_Tipo_Impresion.Vista_Previa

                    _Vista_Previa = (_Tipo_Impresion = Enum_Tipo_Impresion.Vista_Previa)

                    'Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _Idmaeedo,
                    '                                       True, _Seleccionar_Impresora, _ImpresosaPredt, _Vista_Previa, 1, True, _Subtido)

                    Dim _Mensaje As LsValiciones.Mensajes

                    _Mensaje = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _Idmaeedo,
                                                           True, _Seleccionar_Impresora, _ImpresosaPredt, _Vista_Previa, 1, True, _Subtido)

                    If Not _Mensaje.EsCorrecto Then
                        MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Problemas al Imprimir",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                    '    MessageBox.Show(Me, _Imprime, "Problemas al Imprimir",
                    '       MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'End If


                Case Enum_Tipo_Impresion.PDF

                    Fx_Imprimir_En_PDF(_NombreFormato)

            End Select

        Else

            MessageBoxEx.Show(Me, "No existen formatos de impresión para este documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Function Fx_Imprimir_En_PDF(_NombreFormato As String) As Boolean

        Dim _IdMaeedo = Pro_Row_Maeedo.Item("IDMAEEDO")
        Dim _Tido = Pro_Row_Maeedo.Item("TIDO")
        Dim _Nudo = Pro_Row_Maeedo.Item("NUDO")
        'Dim _Subtido = Pro_Row_Maeedo.Item("SUBTIDO")
        Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"

        Dim _Doc_Electronico As Boolean = Pro_Row_Maeedo.Item("TIDOELEC")
        Dim _Imprimir_Cedible As Boolean

        If _Doc_Electronico Then

            If MessageBoxEx.Show(Me, "¿Desea imprimir la copia CEDIBLE?", "Imprimir CEDIBLE", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, True) = Windows.Forms.DialogResult.Yes Then
                _Imprimir_Cedible = True
            End If

        End If

        Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_IdMaeedo,
                                                         _Tido,
                                                         _NombreFormato,
                                                         _Tido & "-" & _Nudo,
                                                         _Path, _Tido & "-" & _Nudo, _Imprimir_Cedible)

        _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)

        Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error
        Dim _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

        If String.IsNullOrEmpty(_Error_Pdf) Then

            _Pdf_Adjunto.Sb_Abrir_Archivo()

            If _Imprimir_Cedible Then
                _Pdf_Adjunto.Pro_Nombre_Archivo = _Pdf_Adjunto.Pro_Nombre_Archivo & "_Cedible"
                _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")
                _Pdf_Adjunto.Sb_Abrir_Archivo()
            End If

        Else

            MessageBoxEx.Show(Me, _Error_Pdf, "Problemas al crear el archivo", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If


    End Function

    Private Sub Btn_Mnu_Firmar_Documento_DTE_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Firmar_Documento_DTE.Click

        Dim _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        Dim _Tidoelec As Boolean = _TblEncabezado.Rows(0).Item("TIDOELEC") 'Integer = CInt(Fx_Es_Electronico(_Tido)) * -1

        If _Tidoelec Then

            If Not Fx_TienePermiso_EnDoc(Me, "Dte00001", _Idmaeedo) Then
                Return
            End If

            'FIRMA ELECTRONICA 
            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo, Mod_Empresa, Mod_Modalidad)
            Dim _Iddt As Integer = _Class_DTE.Fx_Dte_Genera_Documento(Me, True)
            Dim _Idpet As Integer

            If CBool(_Iddt) Then
                _Idpet = _Class_DTE.Fx_Dte_Firma(Me, _Iddt, True)
            End If

            If Convert.ToBoolean(_Idpet) Then
                MessageBoxEx.Show(Me, "Documento enviado correctamente para su reenvio al SII, falta revisión por RunMonitor", "Reenviar DTE",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)
            Else

                If Convert.ToBoolean(_Class_DTE.Pro_Errores.Count) Then

                    Dim _MsgList As String

                    For Each _Msg As String In _Class_DTE.Pro_Errores
                        _MsgList += _Msg & vbCrLf
                    Next

                    MessageBoxEx.Show(Me, _MsgList, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Else

                    MessageBoxEx.Show(Me, "No fue posible rescatar el IDPET para el RunMonitor" & Environment.NewLine & Environment.NewLine &
                                  "* Revise si tiene instalado el certificado digital" & Environment.NewLine &
                                  "* Recuerde que debe ejecutar el sistema en modo administrador", "Reenviar DTE",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

                End If

            End If

        Else

            MessageBoxEx.Show(Me, "Esta acción no esta permitida para este documento",
                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Mnu_Reenvio_Correo_DTE_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Reenvio_Correo_DTE.Click

        Dim _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        Dim _Nro_Documento As String = Traer_Numero_Documento(_Tido) ' _Class_DTE.Pro_Nro_Documento

        Dim _Tidoelec As Integer = CInt(Fx_Es_Electronico(_Tido)) * -1

        If CBool(_Tidoelec) Then

            Dim _Autorizado As Boolean

            Dim Fm_Pass As New Frm_Clave_Administrador
            Fm_Pass.ShowDialog(Me)
            _Autorizado = Fm_Pass.Pro_Autorizado
            Fm_Pass.Dispose()

            If _Autorizado Then

                'REENVIO DE CORREO AL CLIENTE RECEPTOR ELECTRONICO

                Consulta_sql = "Select Top 1 * From FPASODT Where IDMAEEDO = " & _Idmaeedo
                Dim _Row_Fmaedte As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If _Row_Fmaedte IsNot Nothing Then

                    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo, Mod_Empresa, Mod_Modalidad) ', "C:\Random.dteSIERRALTA")
                    Dim _Iddt As Integer = _Row_Fmaedte.Item("IDDT")
                    Dim _Idpet As Integer = _Class_DTE.Fx_Dte_Enviar_Correo_Cliente(Me, _Iddt)

                    If CBool(_Idpet) Then
                        MessageBoxEx.Show(Me, "Solicitud enviada, RunMonitor debará continuar con la gestión",
                                          "Renvío de mail Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                Else
                    MessageBoxEx.Show(Me, "Este documento no ha sido firmado electronicamente",
                                      "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If
            End If
        Else

            MessageBoxEx.Show(Me, "Esta acción no esta permitida para este documento",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Mnu_Exportar_XML_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Exportar_XML.Click

        If Not Fx_TienePermiso_EnDoc(Me, "Doc00025", _Idmaeedo) Then
            Return
        End If

        Dim SaveFileDialog1 As New SaveFileDialog
        Dim _Archivo_Xml As String
        Dim _Errores As New List(Of String)

        Dim _Xml As New Class_Genera_DTE_RdBk(_Idmaeedo, Mod_Empresa, Mod_Modalidad)
        _Archivo_Xml = _Xml.Fx_Crear_Archivo_XML(Me)
        _Errores = _Xml.Pro_Errores

        Dim _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        Dim _Nudo = _TblEncabezado.Rows(0).Item("NUDO")

        Dim _Td As Integer = Fx_Tipo_DTE_VS_TIDO(_Tido)

        Dim _ID As String = "F" & CInt(_TblEncabezado.Rows(0).Item("NUDO")) & "T" & _Td

        Dim _a1 = "<Documento ID=""" & _ID & """>" '"<Documento ID = " & _ID & ">"

        _Archivo_Xml = Replace(_Archivo_Xml, _a1, "<DTE version=""1.0"">" & vbCrLf & _a1)
        _Archivo_Xml = Replace(_Archivo_Xml, "</Documento>", "</Documento>" & vbCrLf & "</DTE>")

        Dim _Dir As String = AppPath() & "\Data\" & RutEmpresa & "\Temp" '\" & _Nudo & ".xml"

        If Not Directory.Exists(_Dir) Then
            System.IO.Directory.CreateDirectory(_Dir)
        End If


        If Not String.IsNullOrEmpty(_Archivo_Xml) Then

            SaveFileDialog1.FileName = _Tido & "-" & _Nudo & "_DTE"

            SaveFileDialog1.Filter = "XML Files (*.xml)|*.xml"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                'My.Computer.FileSystem.WriteAllText _
                '(SaveFileDialog1.FileName, RichTextBox1.Text, True)

                _Dir = SaveFileDialog1.FileName

                Dim oSW As New System.IO.StreamWriter(_Dir)

                oSW.WriteLine(_Archivo_Xml)
                oSW.Close()

                MessageBoxEx.Show(Me, "Archivo guardado correctamente" & vbCrLf &
                                         "Ruta: " & _Dir, "Exportar a Xml", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            Dim _MsgErrores As String
            If _Errores.Count > 0 Then
                For Each _Er As String In _Errores
                    _MsgErrores += _Er & vbCrLf
                Next
            End If

            MessageBoxEx.Show(Me, "No exiten datos que exportar" & vbCrLf & _MsgErrores,
                                  "Exportar a .csv", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Cierre_Reactivacion_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cierre_Reactivacion_Documento.Click

        Dim _Idmaeedo = _TblEncabezado.Rows(0).Item("IDMAEEDO")

        Dim Fm As New Frm_Cerrar_Abrir_Documentos(_Idmaeedo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Abrir_Documento_Desde_Random_SQL()

    End Sub

    Private Sub Btn_Cambiar_Nro_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cambiar_Nro_Documento.Click

        If Not Fx_TienePermiso_EnDoc(Me, "Doc00020", _Idmaeedo) Then
            Return
        End If

        Dim _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        Dim _Nudo = _TblEncabezado.Rows(0).Item("NUDO")
        Dim _Endo = _TblEncabezado.Rows(0).Item("ENDO")
        Dim _Suendo = _TblEncabezado.Rows(0).Item("SUENDO")
        'Dim _Idmaeedo = _TblEncabezado.Rows(0).Item("IDMAEEDO")
        Dim _Tidoelec = Convert.ToInt32(_TblEncabezado.Rows(0).Item("TIDOELEC"))

        Dim _Aceptado As Boolean

        _Aceptado = InputBox_Bk(Me, "Ingrese nuevo número de documento",
                                "Cambio de folio", _Nudo,
                                False, _Tipo_Mayus_Minus.Normal, 10, True,
                                _Tipo_Imagen.Texto, False,
                                _Tipo_Caracter.Cualquier_caracter, False)

        _Nudo = Fx_Rellena_ceros(_Nudo, 10)

        If _Aceptado Then

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEEDO",
                                 "EMPRESA = '" & Mod_Empresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'" & Space(1) &
                                 "And ENDO = '" & _Endo & "' And SUENDO = '" & _Suendo & "' And TIDOELEC = " & _Tidoelec)

            If Not CBool(_Reg) Then

                Consulta_sql = "Update MAEEDO Set NUDO = '" & _Nudo & "' Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                               "Update MAEDDO Set NUDO = '" & _Nudo & "' Where IDMAEEDO = " & _Idmaeedo

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    _TblEncabezado.Rows(0).Item("NUDO") = _Nudo
                    MessageBoxEx.Show(Me, "Número cambiado correctamente", "Cambio de folio",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Folio_Cambiado = True
                    Me.Close()

                End If

            Else

                MessageBoxEx.Show(Me, "Este folio ya existe en la base de datos", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        If Fx_TienePermiso_EnDoc(Me, "Doc00032", _Idmaeedo) Then

            Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIPODOCUMENTO")
            Dim _Nudo As String = _TblEncabezado.Rows(0).Item("NUDO")

            Dim _Otra_Condicion = String.Empty

            Dim _Filtros_Idmaeedo = Generar_Filtro_IN(_TblDetalle, "", "IDMAEEDO_PA", False, False, "")

            If _Filtros_Idmaeedo <> "()" Then
                _Otra_Condicion = "Or Idmaeedo In " & _Filtros_Idmaeedo
            End If

            Dim Fm As New Frm_Adjuntar_Archivos("Zw_Docu_Archivos", "Idmaeedo", _Idmaeedo)
            Fm.Otra_Condicion = _Otra_Condicion
            Fm.Text = "Archivos adjuntos documento: " & _Tido.Trim & " Nro: " & _Nudo
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Revisar_Si_Hay_Archivos_Adjuntos()

        End If

    End Sub

    Private Sub Btn_Mnu_Imprimir_Otros_Formatos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Imprimir_Otros_Formatos.Click
        Sb_Imprimir_Documento(Enum_Tipo_Impresion.Imprimir, String.Empty)
    End Sub

    Private Sub Btn_Mnu_Imprimir_Formato_Modalidad_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Imprimir_Formato_Modalidad.Click
        Sb_Imprimir_Documento(Enum_Tipo_Impresion.Imprimir, _NombreFormato_Modalidad)
    End Sub

    Private Sub Btn_Mnu_Vista_Previa_Formato_Modalidad_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Vista_Previa_Formato_Modalidad.Click
        Sb_Imprimir_Documento(Enum_Tipo_Impresion.Vista_Previa, _NombreFormato_Modalidad)
    End Sub

    Private Sub Btn_Mnu_Vista_Previa_Otros_Formatos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Vista_Previa_Otros_Formatos.Click
        Sb_Imprimir_Documento(Enum_Tipo_Impresion.Vista_Previa, String.Empty)
    End Sub

    Private Sub Btn_Mnu_Imprimir_PDF_Formato_Modalidad_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Imprimir_PDF_Formato_Modalidad.Click
        Sb_Imprimir_Documento(Enum_Tipo_Impresion.PDF, _NombreFormato_PDF_Modalidad)
    End Sub

    Private Sub Btn_Mnu_Imprimir_PDF_Otros_Formatos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Imprimir_PDF_Otros_Formatos.Click
        Sb_Imprimir_Documento(Enum_Tipo_Impresion.PDF, String.Empty)
    End Sub

    Private Sub Btn_Ver_Orden_de_despacho_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Orden_de_despacho.Click

        Dim _Filtro_Idmaeddo_Dori = Generar_Filtro_IN(_TblDetalle, "", "IDRST", True, False, "")

        If _Filtro_Idmaeddo_Dori = "()" Then
            _Filtro_Idmaeddo_Dori = "(-1)"
        End If

        _Filtro_Idmaeddo_Dori = _Filtro_Idmaeddo_Dori.ToString.Replace("%%", "0")

        Consulta_sql = "Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det 
                        Where Idmaeedo In (Select IDMAEEDO From MAEDDO WITH (NOLOCK) Where IDMAEDDO In " & _Filtro_Idmaeddo_Dori & ") Or Idmaeedo = " & _Idmaeedo
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If IsNothing(_Tbl) Then
            MessageBoxEx.Show(Me, "No existen datos que mostrar", "Buscar Orden de despacho", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Me.Enabled = False

        For Each _Fl As DataRow In _Tbl.Rows

            Dim _Id_Despacho = _Fl.Item("Id_Despacho")

            Dim _Cl_Despacho As New Clas_Despacho_Fx
            _Cl_Despacho.Sb_Actualizar_Despachos(_Id_Despacho)

        Next

        Dim _Filtro_Documento

        Select Case _Tipo_Apertura
            Case Enum_Tipo_Apertura.Desde_Bakapp_Kasi
                _Filtro_Documento = "And Desp.Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc Where Archidrst = 'Zw_Casi_DocEnc' And Idrst = " & _Idmaeedo & ")" & vbCrLf
            Case Enum_Tipo_Apertura.Desde_Random_SQL
                _Filtro_Documento = "And Desp.Nro_Despacho In (Select Nro_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc Where Archidrst = 'MAEEDO' And Idrst = " & _Idmaeedo & ")" & vbCrLf
        End Select

        Dim _Clas_Despacho_Fx As New Clas_Despacho_Fx

        Dim _Ds = _Clas_Despacho_Fx.Fx_Buscar_Ordenes_De_Despacho(Nothing, Nothing, "", Clas_Despacho_Fx.Enum_Ver.Buscar, _Filtro_Documento, False)

        If CBool(_Ds.Tables(0).Rows.Count) Then

            Dim Fm_Fl As New Frm_Despacho_Ordenes(Frm_Despacho_Ordenes.Enum_Ver.Buscar)
            Fm_Fl.Ds = _Ds
            Fm_Fl._Correr_a_la_derecha = True
            Fm_Fl.Btn_Buscar_Despacho.Visible = False
            Fm_Fl.Btn_Nuevo_Despacho.Visible = False
            Fm_Fl.Btn_Actualizar.Visible = False
            Fm_Fl.ShowDialog(Me)
            Fm_Fl.Dispose()

        Else

            Dim Fm As New Frm_DespachoSimple(0, _Idmaeedo)
            If Not IsNothing(Fm.RowDepachoSimple) Then
                Fm.ShowDialog(Me)
            Else
                MessageBoxEx.Show(Me, "No existen datos que mostrar", "Buscar Orden de despacho", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Fm.Dispose()

        End If

        Me.Enabled = True

    End Sub

    Sub Sb_Imprimir_PDF_Doc_desde_XML()

        Dim _Ruta_Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\Temp"

        If Not Directory.Exists(_Ruta_Directorio) Then
            System.IO.Directory.CreateDirectory(_Ruta_Directorio)
        End If

        Try

            Dim Fte_Detalle_Negrita As XFont = New XFont("Arial", 10, XFontStyle.Bold) ' Crea la fuente
            Dim Fte_Detalle_Normal As XFont = New XFont("Arial", 10, XFontStyle.Regular) ' Crea la fuente

            Dim FteNegrita_3 As XFont = New XFont("Arial", 3, XFontStyle.Bold) ' Crea la fuente
            Dim FteNegrita_6 As XFont = New XFont("Arial", 6, XFontStyle.Bold) ' Crea la fuente
            Dim FteNegrita_7 As XFont = New XFont("Arial", 7, XFontStyle.Bold) ' Crea la fuente
            Dim FteNegrita_8 As XFont = New XFont("Arial", 8, XFontStyle.Bold) ' Crea la fuente
            Dim FteNegrita_9 As XFont = New XFont("Arial", 9, XFontStyle.Bold) ' Crea la fuente
            Dim FteNegrita_10 As XFont = New XFont("Arial", 10, XFontStyle.Bold) ' Crea la fuente

            Dim FteNormal_3 As XFont = New XFont("Arial", 3, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_4 As XFont = New XFont("Arial", 4, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_5 As XFont = New XFont("Arial", 5, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_6 As XFont = New XFont("Arial", 6, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_7 As XFont = New XFont("Arial", 7, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_8 As XFont = New XFont("Arial", 8, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_9 As XFont = New XFont("Arial", 9, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_10 As XFont = New XFont("Arial", 10, XFontStyle.Regular) ' Crea la fuente

            Dim FteNormal_C_6 As XFont = New XFont("Courier New", 6, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_C_7 As XFont = New XFont("Courier New", 7, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_C_8 As XFont = New XFont("Courier New", 8, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_C_9 As XFont = New XFont("Courier New", 9, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_C_10 As XFont = New XFont("Courier New", 10, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_C_11 As XFont = New XFont("Courier New", 11, XFontStyle.Regular) ' Crea la fuente
            Dim FteNormal_C_12 As XFont = New XFont("Courier New", 12, XFontStyle.Regular) ' Crea la fuente


            Dim FteNegrilla As XFont = New XFont("Arial", 15, XFontStyle.Bold)  ' Crea la fuente

            Dim Documento As PdfDocument = New PdfDocument                      ' Crea el documento Pdf
            Dim pagina As PdfPage = Documento.AddPage

            pagina.Size = PageSize.Letter
            pagina.Orientation = PageOrientation.Portrait

            Dim pgfx As XGraphics = XGraphics.FromPdfPage(pagina)               ' Crea un Objeto XGraphics para la creacion de los datos
            Dim tf As XTextFormatter                                            ' Objeto para formatear texto

            'Dim Archivo As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _Nombre_Archivo_PDF & ".pdf"

            Dim Fte_Encabezado_Negrita_16 As XFont = New XFont("Arial", 16, XFontStyle.Bold)   ' Crea la fuente
            Dim Fte_Encabezado_Negrita_14 As XFont = New XFont("Arial", 14, XFontStyle.Bold)   ' Crea la fuente
            Dim Fte_Encabezado_Negrita_12 As XFont = New XFont("Arial", 12, XFontStyle.Bold)   ' Crea la fuente
            Dim Fte_Encabezado_Negrita_10 As XFont = New XFont("Arial", 10, XFontStyle.Bold)   ' Crea la fuente
            Dim Fte_Encabezado_Normal_10 As XFont = New XFont("Arial", 10, XFontStyle.Regular)   ' Crea la fuente


            Dim Tbl_Encabezado = _Datos_Documento.Tables("Maeedo")

            Dim _Row_Maeedo As DataRow = Tbl_Encabezado.Rows(0)

            Dim _Tido As String = _Row_Maeedo.Item("TIDO")
            Dim _Nudo As String = _Row_Maeedo.Item("NUDO")

            Dim Archivo As String = _Ruta_Directorio & "\" & _Tido.Trim & "-" & _Nudo.Trim & ".pdf"

            ' Crea una pagina vacia
            Dim _Tipo_Documento As String = "FACTURA ELECTRÓNICA"

            ' EMISOR

            Dim Xpos = 10 ' Columna
            Dim Ypos = 30 ' Fila
            Dim Contador As Integer = 1
            Dim Con As Integer = 1
            Dim Dig As Integer = 50
            Dim Cm As Integer = 1

            'Dim filter As String = String.Format("Id = " & Id)
            'Dim rows() As DataRow = dt.Select(filter)

            'Dim Tbl_IdDoc = _Datos_Documento.Tables("IdDoc") '.Select("Encabezado_Id = 0")

            'Dim _Id_Doc As Integer = Tbl_IdDoc.Rows(_Encabezado_Id).Item("TipoDTE")
            Dim _Nro_Documento As String = _Row_Maeedo.Item("NUDO")

            Dim Tbl_Emisor = _Datos_Documento.Tables("Emisor")

            'With Tbl_Emisor

            Dim _Razon_Emisor As String = RazonEmpresa
            'Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTEmisor")), "-")
            Dim _Rut_Emisor As String = RutEmpresa

            Dim _Giro_Emisor As String = "Giro Empresa" ' Valor_Columna(.Rows(_Encabezado_Id), 0, "GiroEmis") 'Trim(.Rows(0).Item("GiroEmis"))
            Dim _direccion_Emisor As String = "Direccion Emisor" ' Valor_Columna(.Rows(_Encabezado_Id), 0, "DirOrigen") 'Trim(.Rows(0).Item("DirOrigen"))
            Dim _Ciudad_Emisor As String = "Ciudad Emisor" ' Valor_Columna(.Rows(_Encabezado_Id), 0, "CiudadOrigen") 'Trim(.Rows(0).Item("CiudadOrigen"))
            Dim _Comuna_Emisor As String = "Comuna Emisor" ' Valor_Columna(.Rows(_Encabezado_Id), 0, "CmnaOrigen") 'Trim(.Rows(0).Item("CmnaOrigen"))

            Dim _Telefono_Emisor As String = "" '.Rows(0).Item("RUTEmisor")

            _Tipo_Documento = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'").ToString.Trim

            Ypos = 40
            pgfx.DrawString("R.U.T.:" & _Rut_Emisor, Fte_Encabezado_Negrita_16, XBrushes.Red, 410, Ypos)
            Ypos += 10

            '' UTIL PARA ALINEAR IMPRESION
            tf = New XTextFormatter(pgfx)
            tf.Alignment = XParagraphAlignment.Center
            ''

            tf.DrawString(_Tipo_Documento, Fte_Encabezado_Negrita_12, XBrushes.Red, New XRect(375, Ypos, 220, 0))
            Ypos += 15

            Dim _Tidoelec As Boolean = _Row_Maeedo.Item("TIDOELEC")

            If _Tidoelec Then
                tf.DrawString("ELECTRÓNICA", Fte_Encabezado_Negrita_12, XBrushes.Red, New XRect(375, Ypos, 220, 0))
            End If

            Ypos += 20
            tf.DrawString("N° " & _Nro_Documento, Fte_Encabezado_Negrita_16, XBrushes.Red, New XRect(375, Ypos, 220, 0))
            Ypos = 30
            pgfx.DrawString(UCase(_Razon_Emisor), Fte_Encabezado_Negrita_14, XBrushes.Black, 20, Ypos)
            Ypos += 15
            pgfx.DrawString(UCase(_direccion_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
            Ypos += 15
            pgfx.DrawString(UCase(_Giro_Emisor), FteNegrita_7, XBrushes.Black, 20, Ypos)
            Ypos += 15
            pgfx.DrawString(UCase(_Ciudad_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
            Ypos += 15
            pgfx.DrawString(UCase(_Comuna_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
            Ypos += 15
            pgfx.DrawString(_Telefono_Emisor, Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
            Ypos += 15


            'End With

            Dim _Fecha_Emision As Date = _Row_Maeedo.Item("FEEMDO")
            Dim _Fecha_Vencimienti As Date = _Row_Maeedo.Item("FEULVEDO")


            Dim Tbl_Receptor = _Datos_Documento.Tables("Receptor")
            'Dim _FILE_XSD = "D:\Empresas\Agrorama\Documentos DTE\Documentos Ayuda SII\schema_dte\schema_dte\DTE_v10.xsd"
            'Tbl_Receptor.WriteXmlSchema(_FILE_XSD)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''   ENCABEZADO DOCUMENTO
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim _Koen = _Row_Maeedo.Item("ENDO")
            Dim _Suendo = _Row_Maeedo.Item("SUENDO")

            Dim _Row_Maeen As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suendo)

            Dim _Razon_Receptor As String = _Row_Maeen.Item("NOKOEN") '"Razon Social Receptor de documento"
            Dim _Rut_Receptor As String = _Row_Maeen.Item("Rut")

            Dim _Giro_Receptor As String

            Try
                _Giro_Receptor = _Row_Maeen.Item("GIEN").ToString.Trim
            Catch ex As Exception
                _Giro_Receptor = String.Empty
            End Try


            Dim _Direccion_Receptor As String = _Row_Maeen.Item("DIEN").ToString.Trim
            Dim _Ciudad_Receptor As String = _Row_Maeen.Item("CIUDAD").ToString.Trim
            Dim _Comuna_Receptor As String = _Row_Maeen.Item("COMUNA").ToString.Trim
            Dim _Telefono_Receptor As String = _Row_Maeen.Item("FOEN").ToString.Trim

            '
            Ypos = 140
            pgfx.DrawString("RUT", FteNegrita_8, XBrushes.Black, 35, Ypos)
            pgfx.DrawString(": " & _Rut_Receptor, FteNormal_8, XBrushes.Black, 100, Ypos)
            pgfx.DrawString("FECHA EMISION", FteNegrita_8, XBrushes.Black, 380, Ypos)
            pgfx.DrawString(": " & FormatDateTime(_Fecha_Emision, DateFormat.LongDate), FteNormal_8, XBrushes.Black, 450, Ypos)
            Ypos += 20

            pgfx.DrawString("RAZON SOCIAL", FteNegrita_8, XBrushes.Black, 35, Ypos)
            pgfx.DrawString(": " & UCase(_Razon_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
            pgfx.DrawString("COMUNA", FteNegrita_8, XBrushes.Black, 380, Ypos)
            pgfx.DrawString(": " & UCase(_Comuna_Receptor), FteNormal_8, XBrushes.Black, 450, Ypos)
            Ypos += 20

            pgfx.DrawString("DIRECCION", FteNegrita_8, XBrushes.Black, 35, Ypos)
            pgfx.DrawString(": " & UCase(_Direccion_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
            pgfx.DrawString("FECHA VENC.", FteNegrita_8, XBrushes.Black, 380, Ypos)
            pgfx.DrawString(": " & UCase(_Fecha_Vencimienti), FteNormal_8, XBrushes.Black, 450, Ypos)
            Ypos += 20

            pgfx.DrawString("CIUDAD", FteNegrita_8, XBrushes.Black, 35, Ypos)
            pgfx.DrawString(": " & UCase(_Ciudad_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
            pgfx.DrawString("TELEFONO", FteNegrita_8, XBrushes.Black, 380, Ypos)
            pgfx.DrawString(": " & UCase(_Telefono_Receptor), FteNormal_8, XBrushes.Black, 450, Ypos)
            Ypos += 20

            pgfx.DrawString("|", FteNormal_3, XBrushes.Green, 1, 20)
            pgfx.DrawString(Cm, FteNormal_3, XBrushes.Green, 1, 25)

            'Escribimos el titulo
            Dim rect As New XRect(15, 15, 585, 20)

            ' XStringFormat.Center)

            'escribimos el texto
            tf = New XTextFormatter(pgfx)
            tf.Alignment = XParagraphAlignment.Justify
            rect = New XRect(15, 45, 585, 60)
            ' tf.DrawString(txTexto.Text, FteNormal_10, XBrushes.Black, rect)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''   ENCABEZADO DE DETALLE
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Ypos = 245

            pgfx.DrawString("CANTIDAD", FteNegrita_7, XBrushes.Black, 20, Ypos)
            pgfx.DrawString("CODIGO", FteNegrita_7, XBrushes.Black, 80, Ypos)
            pgfx.DrawString("DESCRIPCION", FteNegrita_7, XBrushes.Black, 220, Ypos)
            pgfx.DrawString("PRECIO", FteNegrita_7, XBrushes.Black, 395, Ypos)
            pgfx.DrawString("%D.", FteNegrita_7, XBrushes.Black, 450, Ypos)
            pgfx.DrawString("DSCTO. $", FteNegrita_7, XBrushes.Black, 480, Ypos)
            pgfx.DrawString("TOTAL", FteNegrita_7, XBrushes.Black, 550, Ypos)

            Ypos = 265

            Dim _Valor As String
            Dim _Caracter As String
            Dim _Largo As Integer = 18
            Dim numero As Integer = 10 'Random.Next(1, 4)

            'Inicializar la clase Random  
            Dim Random As New Random()

            Dim Tbl_Detalle = _Datos_Documento.Tables("Maeddo")
            'Dim Tbl_CdgItem = _Datos_Documento.Tables("CdgItem")

            Contador = 0


            Dim _Meardo As String = _Row_Maeedo.Item("MEARDO").ToString.Trim

            Dim _Campo_Precio As String
            Dim _Campo_Total As String
            Dim _Nom_Campo As String


            If _Meardo = "N" Or String.IsNullOrEmpty(_Meardo) Then
                _Campo_Precio = "PPPRNE"
                _Campo_Total = "VANELI"
                _Nom_Campo = " Neto"
            ElseIf _Meardo = "B" Then
                _Campo_Precio = "PPPRBR"
                _Campo_Total = "VABRLI"
                _Nom_Campo = String.Empty
            End If


            For Each Fila As DataRow In Tbl_Detalle.Rows

                Dim _Codigo As String = Fila.Item("KOPRCT")
                Dim _Cantidad As Double = Fila.Item("CANTIDAD")

                Dim _DscItem As String = Fila.Item("PC_DESC")
                Dim _NmbItem As String = numero_(Contador, 2)

                Dim _Descripcion As String = Fila.Item("NOKOPR")

                Dim _Precio As Double = Fila.Item(_Campo_Precio)
                Dim _DecuentoPct As Double = Fila.Item("PC_DESC")
                Dim _DescuentoMonto As Double '= Valor_Columna(Fila, 0, "DescuentoMonto", True)
                Dim _Monto As Double = Fila.Item(_Campo_Total)

                Dim _Decimal As Integer


                If Int(_DecuentoPct) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                Dim _DecuentoPct_ = Rellenar(FormatNumber(_DecuentoPct, _Decimal), 4, " ", False)

                If Int(_DescuentoMonto) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                Dim _DescuentoMonto_ = Rellenar(FormatNumber(_DescuentoMonto, _Decimal), 13, " ", False)

                If Int(_Cantidad) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                Dim _Cantidad_ = Rellenar(FormatNumber(_Cantidad, _Decimal), 9, " ", False)

                If Int(_Precio) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                Dim _Precio_ = Rellenar(FormatNumber(_Precio, _Decimal), 13, " ", False)


                Dim _Monto_ = Rellenar(FormatNumber(_Monto, 0), 13, " ", False)

                pgfx.DrawString(_Cantidad_, FteNormal_C_7, XBrushes.Black, 15, Ypos)
                pgfx.DrawString(_Codigo, FteNormal_C_7, XBrushes.Black, 70, Ypos)

                If Len(_Descripcion) > 50 Then
                    pgfx.DrawString(_Descripcion, FteNormal_C_6, XBrushes.Black, 145, Ypos)
                Else
                    pgfx.DrawString(_Descripcion, FteNormal_C_7, XBrushes.Black, 145, Ypos)
                End If

                pgfx.DrawString(_Precio_, FteNormal_C_7, XBrushes.Black, 380, Ypos)
                pgfx.DrawString(_DecuentoPct_, FteNormal_C_7, XBrushes.Black, 446, Ypos) ' porcentaje descuento
                pgfx.DrawString(_DescuentoMonto_, FteNormal_C_7, XBrushes.Black, 460, Ypos) ' valor descuento
                pgfx.DrawString(_Monto_, FteNormal_C_7, XBrushes.Black, 530, Ypos)

                'If Not String.IsNullOrEmpty(_DscItem) Then
                '    Ypos += 10
                '    pgfx.DrawString(_DscItem, FteNormal_C_6, XBrushes.Black, 145, Ypos)
                'End If

                Ypos += 10
                Contador += 1

            Next



            Dim elipse As XSize
            elipse.Height = 10
            elipse.Width = 10

            rect = New XRect(15, 230, 580, 380)
            pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

            rect = New XRect(15, 250, 580, 320)
            pgfx.DrawRectangle(XPens.Black, rect)


            rect = New XRect(15, 250, 580, 320)
            pgfx.DrawRectangle(XPens.Black, rect)

            rect = New XRect(65, 230, 70, 340)
            pgfx.DrawRectangle(XPens.Black, rect)

            rect = New XRect(135, 230, 240, 340)
            pgfx.DrawRectangle(XPens.Black, rect)

            rect = New XRect(375, 230, 70, 340)
            pgfx.DrawRectangle(XPens.Black, rect)

            rect = New XRect(445, 230, 80, 340)
            pgfx.DrawRectangle(XPens.Black, rect)

            rect = New XRect(465, 230, 60, 340)
            pgfx.DrawRectangle(XPens.Black, rect)

            rect = New XRect(465, 230, 60, 340)
            pgfx.DrawRectangle(XPens.Black, rect)

            Dim pen As XPen = New XPen(XColor.FromArgb(255, 0, 0), 1)
            pgfx.DrawLine(XPens.Red, New XPoint(15, Ypos), New XPoint(595, Ypos)) ' New XPoint(pagina.Width.Point, pagina.Height.Point))
            pgfx.DrawLine(XPens.Red, New XPoint(15, Ypos + 2), New XPoint(595, Ypos + 2)) ' New XPoint(pagina.Width.Point, pagina.Height.Point))

            Ypos += 10


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''   PIE 
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim Tbl_ImptoReten = 0 '_Datos_Documento.Tables("ImptoReten")

            Ypos = 585


            Dim _Impuestos_Ila As Double


            Dim _TasaIVA As Double
            Dim _IVA As Double

            Dim _Descuento As Double
            Dim _Exento As Double
            Dim _MntNeto As Double
            Dim _MntTotal As Double

            'If _Id_Doc <> 34 Then


            _MntNeto = _Row_Maeedo.Item("VANEDO")
            _MntTotal = _Row_Maeedo.Item("VABRDO")

            _IVA = _Row_Maeedo.Item("VAIVDO")

            '_Exento = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntExe"))
            _
            Dim _Total_Palabras As String = Trim(UCase(Letras(_MntTotal))) & " ---------"
            pgfx.DrawString("SON :" & _Total_Palabras, FteNegrita_8, XBrushes.Black, 25, Ypos)
            Ypos += 20

            Dim _Tota_Descuento As String
            _Tota_Descuento = FormatNumber(_Descuento, 0)
            _Tota_Descuento = ": $ " & Rellenar(_Tota_Descuento, 11, " ", False)

            Dim _Tota_Exento As String
            _Tota_Exento = FormatNumber(_Exento, 0)
            _Tota_Exento = ": $ " & Rellenar(_Tota_Exento, 11, " ", False)

            Dim _Total_Neto As String
            _Total_Neto = FormatNumber(_MntNeto, 0)
            _Total_Neto = ": $ " & Rellenar(_Total_Neto, 11, " ", False)

            Dim _Total_Ila As String
            _Total_Ila = FormatNumber(_IVA, 0)
            _Total_Ila = ": $ " & Rellenar(_Impuestos_Ila, 11, " ", False)

            Dim _Total_Iva As String
            _Total_Iva = FormatNumber(_IVA, 0)
            _Total_Iva = ": $ " & Rellenar(_Total_Iva, 11, " ", False)

            Dim _Total_Bruto As String
            _Total_Bruto = FormatNumber(_MntTotal, 0)
            _Total_Bruto = ": $ " & Rellenar(_Total_Bruto, 11, " ", False)

            '655

            Ypos = 635
            pgfx.DrawString("DESCUENTO", FteNegrita_8, XBrushes.Black, 425, Ypos)
            pgfx.DrawString(_Tota_Descuento, FteNormal_C_12, XBrushes.Black, 475, Ypos)
            Ypos += 20
            pgfx.DrawString("EXENTO", FteNegrita_8, XBrushes.Black, 425, Ypos)
            pgfx.DrawString(_Tota_Exento, FteNormal_C_12, XBrushes.Black, 475, Ypos)
            Ypos += 20
            pgfx.DrawString("NETO", FteNegrita_8, XBrushes.Black, 425, Ypos)
            pgfx.DrawString(_Total_Neto, FteNormal_C_12, XBrushes.Black, 475, Ypos)
            Ypos += 20
            pgfx.DrawString("IMPUESTOS", FteNegrita_8, XBrushes.Black, 425, Ypos)
            pgfx.DrawString(_Total_Ila, FteNormal_C_12, XBrushes.Black, 475, Ypos)
            Ypos += 20
            pgfx.DrawString("IVA (" & _TasaIVA & ")", FteNegrita_8, XBrushes.Black, 425, Ypos)
            pgfx.DrawString(_Total_Iva, FteNormal_C_12, XBrushes.Black, 475, Ypos)
            Ypos += 20
            pgfx.DrawString("TOTAL", FteNegrita_8, XBrushes.Black, 425, Ypos)
            pgfx.DrawString(_Total_Bruto, FteNormal_C_12, XBrushes.Black, 475, Ypos)
            Ypos += 20



            'Insertamos un cuadro
            rect = New XRect(50, 200, 100, 50)
            pen = New XPen(XColor.FromArgb(255, 0, 0))
            ' pgfx.DrawRoundedRectangle(XPens.Blue, rect, elipse)

            rect = New XRect(375, 20, 218, 90)
            pen = New XPen(XColor.FromArgb(255, 0, 0), 3)
            pgfx.DrawRectangle(pen, rect)


            rect = New XRect(15, 120, 580, 100)
            pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

            'pgfx.DrawRectangle(XPens.Black, rect)

            rect = New XRect(415, 620, 178, 125)
            pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

            Try
                'si el archivo esta abierto da error
                'para que averiguen como saber si ela rchivo esta abierto y cerrarlo
                ' antes de grabar uno nuevo
                Documento.Save(Archivo)
            Catch ex As Exception
            End Try

            Dim rot(3) As Double
            rot(0) = 1.5
            rot(1) = 2
            rot(2) = 100
            rot(3) = 8
            PoneMarcaAgua(Archivo, "Doc. desde XML", rot)

            'End If

            Process.Start(Archivo)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message & vbCrLf &
                              "Problemas al leer el archivo XML de origen, puede que el archivos no tenga la estructura adecuada", "Problema en DTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Btn_Consolidar_Stock_X_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Consolidar_Stock_X_Producto.Click

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)

        Dim _Codigo As String

        If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Bakapp_Kasi Then
            _Codigo = _Fila.Cells("Codigo").Value
        Else
            _Codigo = _Fila.Cells("KOPRCT").Value
        End If

        If Not String.IsNullOrEmpty(_Codigo) Then

            Dim Fm As New Frm_Consolidacion_Stock_PP("('" & _Codigo & "')")
            Fm.Pro_Ejecutar_Automaticamente = True
            Fm.BtnCancelar.Visible = False
            Fm.Chk_Reservar_Ventas_Pendientes_Bakapp.Enabled = False
            Fm.BtnProcesar.Enabled = False
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Consolidar_Stock_Click(sender As Object, e As EventArgs) Handles Btn_Consolidar_Stock.Click

        If Not Fx_Tiene_Permiso(Me, "Prod055") Then
            Return
        End If

        Dim _Codigo As String

        If _Tipo_Apertura = Enum_Tipo_Apertura.Desde_Bakapp_Kasi Then
            _Codigo = "Codigo"
        Else
            _Codigo = "KOPRCT"
        End If

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblDetalle, "", _Codigo, False, False, "'")

        Dim Fm2 As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
        Fm2.ShowDialog(Me)
        Fm2.Dispose()

    End Sub

    Private Sub Btn_Mnu_Ficha_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Ficha_Entidad.Click
        Sb_Ver_Entidad()
    End Sub

    Private Sub Btn_Ver_Situacion_Cliente_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Situacion_Cliente.Click

        If Fx_TienePermiso_EnDoc(Me, "Inf00018", _Idmaeedo) Then

            Dim Fm As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad, 0, 0, 0, 0, True)
            Fm.Btn_CambCodPago.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Info_Plana_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Info_Plana_Entidad.Click

        If Not (_RowEntidad Is Nothing) Then

            Dim Fm As New Frm_InfoEnt_Informacion_General(_RowEntidad)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else
            MessageBoxEx.Show(Me, "Falta el entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)
        End If

    End Sub

    Private Sub Btn_Ver_Comportamiento_De_Pago_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Comportamiento_De_Pago.Click

        If Fx_TienePermiso_EnDoc(Me, "Inf00018", _Idmaeedo) Then

            Dim Fm As New Frm_Infor_Ent_Comportamiento_De_Pago
            Fm.Pro_RowEntidad = _RowEntidad
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Ver_Documentos_Pendientes_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documentos_Pendientes.Click

        If Fx_TienePermiso_EnDoc(Me, "Inf00018", _Idmaeedo) Then

            Dim _Koen = _RowEntidad.Item("KOEN")
            Dim _Suen = _RowEntidad.Item("SUEN")

            Sb_Ver_Deuda_Pendiente(_Koen, _Suen, False)

        End If

    End Sub

    Public Sub PoneMarcaAgua(FileName As String, Texto As String, rotacion() As Double)

        Dim watermark As String = Texto
        Const emSize As Integer = 75

        ' Crea la fuente
        Dim font As New XFont("Times", emSize, XFontStyle.Italic)

        ' Abre el pdf existente
        Dim document As PdfDocument = PdfReader.Open(FileName)

        ' fija la  version a PDF 1.4 (Acrobat 5) ya que usamos transparencia
        If document.Version < 14 Then
            document.Version = 14
        End If
        For idx As Integer = 0 To document.Pages.Count - 1
            Dim page As PdfPage = document.Pages(idx)

            ' Crea el XGrafics para el dibujo
            Dim gfx As XGraphics = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend)

            Dim size As XSize = gfx.MeasureString(watermark, font)

            gfx.TranslateTransform(gfx.PageSize.Width / rotacion(0), gfx.PageSize.Height / rotacion(1))
            gfx.RotateTransform(-Math.Atan(gfx.PageSize.Height / gfx.PageSize.Width) * 180 / Math.PI)
            gfx.TranslateTransform(-gfx.PageSize.Width / rotacion(2), -gfx.PageSize.Height / rotacion(3))

            Dim path As New XGraphicsPath()
            path.AddString(watermark, font.FontFamily, XFontStyle.Italic, 75, New XPoint((page.Width.Centimeter - size.Width) / 2, (page.Height.Centimeter - size.Height) / 2), XStringFormat.Default)

            Dim pen As New XPen(XColor.FromArgb(128, 255, 150, 150), 2)

            gfx.DrawPath(pen, path)
        Next
        document.Save(FileName)

    End Sub

    Private Sub Btn_Ver_Cheques_En_Cartera_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Cheques_En_Cartera.Click

        If Fx_TienePermiso_EnDoc(Me, "Inf00018", _Idmaeedo) Then

            Dim _Koen = _RowEntidad.Item("KOEN")
            Dim _Suen = _RowEntidad.Item("SUEN")
            Dim _Nokoen = _RowEntidad.Item("NOKOEN")

            Dim Fm As New Frm_Infor_Cheques_En_Cartera_X_Clientes
            Fm.Pro_Filtro_Entidad = _Koen
            Fm.Text = "Cheques en cartera entidad: " & _Nokoen
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Ver_Deuda_Total_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Deuda_Total.Click

        If Fx_TienePermiso_EnDoc(Me, "Inf00018", _Idmaeedo) Then

            Dim _Koen = _RowEntidad.Item("KOEN")
            Dim _Suen = _RowEntidad.Item("SUEN")

            Sb_Ver_Deuda_Pendiente(_Koen, _Suen, True)

        End If

    End Sub

    Private Sub Btn_Imprimir_Diablito_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Diablito.Click

        Dim _Cl_Imprimir As New Cl_Enviar_Impresion_Diablito
        If _Cl_Imprimir.Fx_Enviar_Impresion_Al_Diablito(Mod_Empresa, Mod_Modalidad, _Idmaeedo) Then
            MessageBoxEx.Show(Me, "Documento enviado correctamente a la cola de impresión del diablito", "Imprimir en diablito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, _Cl_Imprimir.Error, "Imprimir en diablito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Btn_Eliminar_Anular_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Anular.Click
        ShowContextMenu(Menu_Contextual_Eliminar_Anular)
    End Sub

    Private Sub Btn_Mnu_Eliminar_Reciclar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Eliminar_Reciclar.Click
        Sb_Crear_Documento_Desde_Otro(Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Eliminar)
    End Sub

    Private Sub Btn_Mnu_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Eliminar.Click
        Sb_Eliminar_Anular(Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Eliminar)
    End Sub

    Private Sub Btn_Mnu_Anular_Reciclar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Anular_Reciclar.Click
        Sb_Crear_Documento_Desde_Otro(Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Anular)
    End Sub

    Private Sub Btn_Mnu_Anular_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Anular.Click
        Sb_Eliminar_Anular(Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Anular)
    End Sub

    Sub Sb_Revisar_Si_Hay_Archivos_Adjuntos()

        Dim _Archivos As Integer

        If CBool(_Idmaeedo) Then

            Dim _Filtros_Idmaeedo = Generar_Filtro_IN(_TblDetalle, "", "IDMAEEDO_PA", False, False, "")
            Dim _Otra_Condicion = String.Empty

            If _Filtros_Idmaeedo <> "()" Then
                _Otra_Condicion = " Or Idmaeedo In " & _Filtros_Idmaeedo
            End If

            _Archivos += _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_Archivos", "Idmaeedo = " & _Idmaeedo & _Otra_Condicion)

        End If

        If _Archivos > 0 Then
            Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento (" & _Archivos & " archivo(s))"
            If _Archivos > 9 Then
                'Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
                'Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
                Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_9_plus
                Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_9_plus___copia
            Else
                Select Case _Archivos
                    Case 0
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.document_attach
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.document_attach___copia
                    Case 1
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_1
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_1___copia
                    Case 2
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_2
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_2___copia
                    Case 3
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_3
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_3___copia
                    Case 4
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_4
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_4___copia
                    Case 5
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_5
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_5___copia
                    Case 6
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_6
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_6___copia
                    Case 7
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_7
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_7___copia
                    Case 8
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_8
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_8___copia
                    Case 9
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_9
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_9___copia
                End Select
            End If
        Else
            Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento"
            Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.document_attach
            Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.document_attach___copia
        End If

        'If _Archivos > 0 Then
        '    Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento (" & _Archivos & " archivo(s))"
        '    If _Archivos > 9 Then
        '        Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
        '        Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
        '    Else
        '        Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item("attach-number-" & _Archivos & ".png")
        '        Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item("attach-number-" & _Archivos & ".png")
        '    End If
        'Else
        '    Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento"
        '    Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item(4)
        '    Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item(15)
        'End If

    End Sub

    Sub Sb_Ver_Deuda_Pendiente(_Koen As String,
                                   _Suen As String,
                                   _Deuda_Efectiva As Boolean)


        Dim _Fx_Fecha_Inicio = "19000101"
        Dim _Fx_Fecha_Fin = "22001231"

        Dim _Filtro_Maeedo = "And EDO.ENDO = '" & _Koen & "' AND EDO.SUENDO = '" & _Suen & "'"
        Dim _Filtro_Maedpce = "And DPCE.ENDP = '" & _Koen & "'"

        Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & Environment.NewLine & Environment.NewLine

        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos(_Koen, _Suen, Consulta_sql,
                                                      _Fx_Fecha_Inicio, _Fx_Fecha_Fin,
                                                      Frm_Inf_Vencimientos_Detalle_Documentos.Accion.Mostrar_todo,
                                                      0, Frm_Inf_Vencimientos_Detalle_Documentos.Tipo_Informe.Ventas)

        Fm.Pro_Mover_Fechas = False
        Fm.Pro_Chk_Deuda_Efectiva = _Deuda_Efectiva ' _Chk_Deuda_Efectiva

        Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
        Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce
        Fm.Pro_Solo_Cheques = True
        Fm.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = False
        Fm.Chk_Mostrar_Pagos_Pendientes.Visible = False
        Fm.Sb_Generar_Informe()

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_Prod_Asociados_Recargo_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Prod_Asociados_Recargo.Click

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.Rows(GrillaDetalleDoc.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value
        Dim _Nulido = _Fila.Cells("NULIDO").Value
        Dim _Codigo = _Fila.Cells("KOPRCT").Value
        Dim _Descricion = _Fila.Cells("NOKOPR").Value

        'Select Case Count(*) From MAEDCR Where IDMAEEDO = 14231735 And NULIDO = '00001'

        Dim _Reg = CBool(_Sql.Fx_Cuenta_Registros("MAEDCR", "IDMAEEDO = " & _Idmaeedo & " And NULIDO = '" & _Nulido & "'"))

        If Not _Reg Then
            MessageBoxEx.Show(Me, "No existen documentos asociados a este recargo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Ver_Documentos_Recargos_Asociados(_Idmaeedo, _Nulido)
        Fm.Text = "Concepto: " & _Codigo.ToString.Trim & " - " & _Descricion.ToString.Trim
        Fm.ShowDialog(Me)

    End Sub

    Private Sub Btn_GuardarRutaPDFAutomatica_Click(sender As Object, e As EventArgs) Handles Btn_GuardarRutaPDFAutomatica.Click
        Sb_ReGuargar_PDF_Automaticamente_Por_Doc_Modalidad(Me, _Idmaeedo)
    End Sub

    Private Sub Btn_Mnu_Firmar_Documento_DTE_Hefesto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Firmar_Documento_DTE_Hefesto.Click

        If Not Fx_TienePermiso_EnDoc(Me, "Dte00001", _Idmaeedo) Then
            Return
        End If

        Dim _AmbienteCertificacion As Integer = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        Dim _Filtro = "And IDMAEEDO = " & _Idmaeedo

        Consulta_sql = My.Resources.Recursos_Dte_Hefesto.SQLQuery_Estado_de_avance_de_envios_de_DTE_vs_Trackid
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Filtros#", _Filtro)
        Consulta_sql = Replace(Consulta_sql, "And FEEMDO Between '#Fecha_Desde#' And '#Fecha_Hasta#'", "")
        Consulta_sql = Replace(Consulta_sql, "#AmbienteCertificacion#", _AmbienteCertificacion)
        Consulta_sql = Replace(Consulta_sql, "#SoloFirmadosPorBakapp#", "")

        Dim _Tbl_Informe As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl_Informe.Rows.Count) Then

            Dim _Fila As DataRow = _Tbl_Informe.Rows(0)

            Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
            Dim _Id_Dte As Integer = _Fila.Item("Id_Dte")
            Dim _Trackid As String = _Fila.Item("Trackid")
            Dim _Procesar As Boolean = _Fila.Item("Procesar")
            Dim _DocFirmado As Boolean = _Fila.Item("DocFirmado")
            Dim _AceptadoSII As Boolean = _Fila.Item("AceptadoSII")
            Dim _InformadoSII As Boolean = _Fila.Item("InformadoSII")
            Dim _RechazadoSII As Boolean = _Fila.Item("RechazadoSII")
            Dim _ReparoSII As Boolean = _Fila.Item("ReparoSII")
            Dim _Estado As String = _Fila.Item("Estado")
            Dim _Glosa As String = _Fila.Item("Glosa")

            If Not _DocFirmado Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Firmar Where Idmaeedo = " & _Idmaeedo & " And AmbienteCertificacion = " & _AmbienteCertificacion
                Dim _RowFirmar As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_RowFirmar) Then

                    If _RowFirmar.Item("Firmar") Then
                        MessageBoxEx.Show(Me, "El documento no fue firmado, pero quedo a la espera de ser firmado por el DTEMonitor" & vbCrLf &
                                      "Informe de esta situación al administrador del sistema para que revise que el DTEMonitor este corriendo en algún equipo",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If

            End If

            If _Procesar Then
                MessageBoxEx.Show(Me, "Este documento esta a la espera de ser procesado por el DTEMonitor" & vbCrLf &
                                  "Debe esperar a que esta situación se concrete", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If _AceptadoSII Or (_InformadoSII And _ReparoSII) Then
                MessageBoxEx.Show(Me, "Este documento ya fue enviado al SII" & vbCrLf &
                              "Respueta SII:" & vbCrLf & vbCrLf &
                              Space(5) & "Estado: " & _Estado & "-" & _Glosa & vbCrLf &
                              Space(5) & "Trackid: " & _Trackid, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _Firmar As Boolean = Not _DocFirmado

            If _DocFirmado And Not String.IsNullOrEmpty(_Trackid) Then
                MessageBoxEx.Show(Me, "Este documento esta a la espera de ser procesado por el DTEMonitor" & vbCrLf &
                                  "Debe esperar a que esta situación se concrete", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Dim _Icono As Image = My.Resources.Recursos_DTE.script_edit
            Dim _Respuesta As String

            Me.Cursor = Cursors.WaitCursor

            Try

                If _Firmar Then

                    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo, Mod_Empresa, Mod_Modalidad)

                    If CBool(_Class_DTE.Fx_FirmarXHefesto()) Then
                        MessageBoxEx.Show(Me, "DOCUMENTO FIRMADO, QUEDARA A LA ESPERA DE SER ENVIADO AL SII ...", "Firmar documento",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBoxEx.Show(Me, "El documento no fue firmado, pero quedo a la espera de ser firmado por el DTEMonitor" & vbCrLf &
                                      "Informe de esta situación al administrador del sistema para que revise que el DTEMonitor este corriendo en algún equipo",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Catch ex As Exception
            Finally
                'CircularProgressItem1.IsRunning = False
                'CircularProgressItem1.Visible = False
                Me.Cursor = Cursors.Default
            End Try

        End If

    End Sub


    Private Sub Btn_Mnu_Exportar_XML_Hefesto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Exportar_XML_Hefesto.Click
        Call Btn_Mnu_Exportar_XML_Click(Nothing, Nothing)
    End Sub

    Function Fx_Eliminar_Anular(_Accion As Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion) As Boolean

        _Row_Maeedo_Doc = _TblEncabezado.Rows(0)

        Dim _Idmaeedo = _Row_Maeedo_Doc.Item("IDMAEEDO")
        Dim _Tido = _Row_Maeedo_Doc.Item("TIDO")
        Dim _Nudo = _Row_Maeedo_Doc.Item("NUDO")

        Dim _Cl_Elimina_Anula As New Clas_Cerrar_Anular_Eliminar_Documento_Origen
        If _Cl_Elimina_Anula.Fx_EliminarAnular_Doc(Me, _Idmaeedo, FUNCIONARIO, _Accion, True, True) Then

            If _Accion = Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Anular Then
                _Anulado = True
                MessageBoxEx.Show(Me, "Documento Anulado", "ANULAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If _Accion = Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Eliminar Then
                _Eliminado = True
                MessageBoxEx.Show(Me, "Documento Eliminado", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True

        End If

    End Function

    Sub Sb_Crear_Documento_Desde_Otro(_Accion As Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion)


        _Row_Maeedo_Doc = _TblEncabezado.Rows(0)

        Dim _Idmaeedo As Integer = _Row_Maeedo_Doc.Item("IDMAEEDO")
        Dim _Tido As String = _Row_Maeedo_Doc.Item("TIDO")
        Dim _Nudo As String = _Row_Maeedo_Doc.Item("NUDO")
        Dim _Koen As String = _Row_Maeedo_Doc.Item("ENDO")
        Dim _Kofudo As String = _Row_Maeedo_Doc.Item("KOFUDO")
        Dim _Suen As String = _Row_Maeedo_Doc.Item("SUENDO")
        Dim _Endofi As String = _Row_Maeedo_Doc.Item("ENDOFI")
        Dim _Nudonodefi As Boolean = _Row_Maeedo_Doc.Item("NUDONODEFI")
        Dim _Tidoelec As Boolean = _Row_Maeedo_Doc.Item("TIDOELEC")
        Dim _Meardo As String = _Row_Maeedo_Doc.Item("MEARDO")

        Dim _Permiso As String

        If _Nudonodefi Then

            If _Kofudo = FUNCIONARIO Then
                _Permiso = "Doc00070"
            Else
                _Permiso = "Doc00071"
            End If

        Else
            _Permiso = "Doc00059"
        End If

        If Not Fx_TienePermiso_EnDoc(Me, _Permiso, _Idmaeedo) Then
            Return
        End If

        If _Tidoelec Then
            MessageBoxEx.Show(Me, "Documentos electrónicos de venta no pueden ser eliminados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Conservar_Nudo As Boolean

        If _Accion = Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Eliminar Then

            _Conservar_Nudo = True

            If _Tido = "OCC" Then

                Dim _Opciones = MessageBoxEx.Show(Me, "¿Desea conservar el mismo número de documento?" & vbCrLf & "Número: " & _Tido & "-" & _Nudo, "Conservar numeración",
                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                'If _Opciones = DialogResult.Yes Then
                '    _Conservar_Nudo = True
                'End If

                If _Opciones = DialogResult.Cancel Then
                    Return
                End If

            End If

        End If

        Dim _Suendofi

        Dim _New_Idmaeedo As Integer

        If Not _Nudonodefi Then
            Dim _Cl_Elimina_Anula As New Clas_Cerrar_Anular_Eliminar_Documento_Origen
            If Not _Cl_Elimina_Anula.Revisar_Si_Se_Puede_Eliminar_El_Documento(Me, _Idmaeedo, _Accion, True) Then
                Return
            End If
        End If

        Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Remotas", "Idmaeedo = " & _Idmaeedo)

        If _Reg Then

            MessageBoxEx.Show(Me, "Este documento tiene permisos asociados" & vbCrLf &
                              "Si elimina o anula se perderan los permisos y debera solicitarlos nuevamente",
                              "Información importante", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer " & _Accion.ToString & " este documento?",
                             _Accion.ToString.ToUpper,
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Return
        End If

        Me.Enabled = False

        Dim _CampoPrecio As String

        If _Tido = "BLV" Or _Meardo = "B" Then
            _CampoPrecio = "PPPRBR"
        Else
            _CampoPrecio = "PPPRNE"
        End If

        '_CampoPrecio = "PPPR" & _Meardo & "E"

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo & "
                                
                                Select MAEDDO.*,CASE WHEN UDTRPR = 1 THEN CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 END AS 'Cantidad',
                                CAPRCO1-CAPREX1 AS 'CantUd1_Dori',CAPRCO2-CAPREX2 AS 'CantUd2_Dori',
                                --CASE WHEN UDTRPR = 1 THEN " & _CampoPrecio & " ELSE " & _CampoPrecio & " END AS 'Precio',
                                " & _CampoPrecio & " As 'Precio',
                                Isnull(Ofer.Id_Oferta,'') As Id_Oferta,
                                Isnull(Ofer.Oferta,'') As Oferta,
                                Isnull(Ofer.Es_Padre_Oferta,0) As Es_Padre_Oferta,
                                Isnull(Ofer.Padre_Oferta,0) As Padre_Oferta,
                                Isnull(Ofer.Hijo_Oferta,0) As Hijo_Oferta,
                                Isnull(Cantidad_Oferta,0) As Cantidad_Oferta,
                                Isnull(Porcdesc_Oferta,0) As Porcdesc_Oferta
                                From MAEDDO WITH ( NOLOCK ) 
                                Left Join " & _Global_BaseBk & "Zw_Linea_Oferta Ofer On Ofer.Idmaeddo = IDMAEDDO
                                Where IDMAEEDO = " & _Idmaeedo & " AND (ESLIDO <> 'C' OR ESFALI='I')
                                Order by IDMAEEDO,IDMAEDDO
                                
                                Select * From MAEIMLI
                                Where IDMAEEDO = " & _Idmaeedo & " 

                                Select * From MAEDTLI
                                Where IDMAEEDO = " & _Idmaeedo & " 

                                Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo

        Dim _Ds_New_Documento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        If IsNothing(_Ds_New_Documento) Then

            MessageBoxEx.Show(Me, "No se encontro el archivo", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End If

        If Not Fx_Eliminar_Anular(_Accion) Then
            Me.Enabled = True
            Return
        End If

        Sb_Eliminar_Despachos()


        Consulta_sql = "Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN" & vbCrLf &
                       "Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN" & vbCrLf &
                       "Where KOEN = '" & _Endofi & "' And SUEN = '" & _Suendofi & "'"
        Dim _Row_Entidad_Fisica As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento

        Select Case _Tido
            Case "OCC"
                _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra
            Case "COV"
                _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Cotizacion
            Case "BLV", "FCV"
                _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta
        End Select

        Dim Fm_Post As New Frm_Formulario_Documento(_Tido, _Tipo_Documento, _Nudonodefi, True, True,,, True)

        Fm_Post.Documento_Reciclado = True
        Fm_Post.Pro_Agrupar_Reemplazos = False
        Fm_Post.Pro_RowEntidad = _Row_Entidad
        Fm_Post.Pro_RowEntidad_Despacho = _Row_Entidad_Fisica
        Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_New_Documento, True, False, Nothing, False, False, _Conservar_Nudo)

        Fm_Post.MinimizeBox = False

        Fm_Post.ShowDialog(Me)
        _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
        Fm_Post.Dispose()

        If _Eliminado Or _Anulado Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        With GrillaDetalleDoc

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End With

    End Sub

    Private Sub Btn_Copiar_Encabezado_Click(sender As Object, e As EventArgs) Handles Btn_Copiar_Encabezado.Click

        With GrillaEncabezado

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End With

    End Sub

    Private Sub Btn_CopiarDocOtrEmpresa_Click(sender As Object, e As EventArgs) Handles Btn_CopiarDocOtrEmpresa.Click

        Dim _New_Idmaeedo = _Idmaeedo
        Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIPODOCUMENTO")
        Dim _Nudo As String = _TblEncabezado.Rows(0).Item("NUDO")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbOCC_Nuevas = 1"
        Dim _Tbl_DnExt As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_DnExt.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen conexiones a otras bases de datos para poder hacer esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        For Each _Fl_Emp As DataRow In _Tbl_DnExt.Rows

            Dim _Id_Conexion = _Fl_Emp.Item("Id")

            Dim _Respuesta As New Bk_ExpotarDoc.Respuesta

            Me.Cursor = Cursors.WaitCursor

            Dim _Cl_ExportarDoc As New Bk_ExpotarDoc.Cl_ExpotarDoc
            _Respuesta = _Cl_ExportarDoc.Fx_Importar_Documento(_New_Idmaeedo, _Id_Conexion, True, Mod_Modalidad)

            Me.Cursor = Cursors.Default

            Dim _Msg As String

            For Each _Inf As String In _Respuesta.Mensajes
                _Msg += vbCrLf & _Inf
            Next

            Dim _Empresa = _Respuesta.RowEmpresa.Item("EMPRESA")
            Dim _Razon = _Respuesta.RowEmpresa.Item("RAZON")

            If _Respuesta.EsCorrecto Then
                MessageBoxEx.Show(Me, "Se grabo correctamente la " & _Tido.Trim & " en la empresa: " & _Empresa & " - " & _Razon & vbCrLf & _Msg, "Grabar OCC",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBoxEx.Show(Me, "Problema al grabar la " & _Tido & " en la empresa: " & _Empresa & " - " & _Razon & vbCrLf & _Msg, "Problema :(",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Next

    End Sub


    Sub Sb_CrearNVVDesdeOCC()

        Dim _New_Idmaeedo = _Idmaeedo
        Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIPODOCUMENTO")
        Dim _Nudo As String = _TblEncabezado.Rows(0).Item("NUDO")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion --Where GrbOCC_Nuevas = 1"
        Dim _Tbl_DnExt As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_DnExt.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen conexiones a otras bases de datos para poder hacer esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Id_Conexion = 1

        Dim _Respuesta As New Bk_ExpotarDoc.Respuesta

        Me.Cursor = Cursors.WaitCursor

        Dim _Cl_ExportarDoc As New Bk_ExpotarDoc.Cl_ExpotarDoc
        _Respuesta = _Cl_ExportarDoc.Fx_CrearNVVDesdeOCC(_Idmaeedo, "", "", _Id_Conexion)

        Me.Cursor = Cursors.Default

        Dim _Msg As String

        For Each _Inf As String In _Respuesta.Mensajes
            _Msg += vbCrLf & _Inf
        Next

        Dim _Empresa = _Respuesta.RowEmpresa.Item("EMPRESA")
        Dim _Razon = _Respuesta.RowEmpresa.Item("RAZON")

        If _Respuesta.EsCorrecto Then
            MessageBoxEx.Show(Me, "Se grabo correctamente el envio a la empresa: " & _Empresa & " - " & _Razon & vbCrLf & _Msg, "Grabar NVV desde OCC",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "Problema al grabar en la empresa: " & _Empresa & " - " & _Razon & vbCrLf & _Msg, "Problema :(",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Btn_VerXMLPDF_Click(sender As Object, e As EventArgs) Handles Btn_VerXMLPDF.Click

        Dim _Tido As String = _TblEncabezado.Rows(0).Item("TIDO")
        Dim _Nudo As String = _TblEncabezado.Rows(0).Item("NUDO")

        Dim _Koen As String = _TblEncabezado.Rows(0).Item("ENDO")
        Dim _Suen As String = _TblEncabezado.Rows(0).Item("SUENDO")

        _Row_Maeen = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        Dim _Rut_Proveedor = Replace(_Row_Maeen.Item("Rut"), ".", "") '_Fila.Cells("Rut_Proveedor").Value

        Dim _Folio = CInt(_Nudo)
        Dim _TipoDoc As Integer

        If _Tido = "FCC" Then
            _TipoDoc = "33"
        ElseIf _Tido = "NCC" Then
            _TipoDoc = "61"
        Else
            _TipoDoc = 0
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_ReccDet" & vbCrLf &
                       "Where TipoDTE = " & _TipoDoc & " And Folio = " & _Folio & " And RutEmisor = '" & _Rut_Proveedor & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            MessageBoxEx.Show(Me, "No se encontro el archivo PDF", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Xml As String = _Row.Item("Xml")

        Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\DTE\Descargas"

        If Not Directory.Exists(_Directorio) Then
            Directory.CreateDirectory(_Directorio)
        End If

        Dim _NombreArchivo As String = _Folio & "_" & _TipoDoc & _Rut_Proveedor '& ".XML"
        Dim _Archivo As String = _Directorio & "\" & _NombreArchivo.Trim

        Dim oSW As New StreamWriter(_Archivo & ".XML")
        oSW.WriteLine(_Xml)
        oSW.Close()

        Dim Ds_Xml As New DataSet
        Ds_Xml.ReadXml(_Archivo & ".XML")

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF")
        End If

        Dim _File As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _NombreArchivo & ".pdf"

        If Not El_Archivo_Esta_Abierto(_File) Then

            Dim _RecepXMLCmp_MarcaAgua As String = _Global_Row_Configuracion_General.Item("RecepXMLCmp_MarcaAgua")
            Dim _RecepXMLCmp_ImpMarcaAgua As Boolean = Not String.IsNullOrEmpty(_RecepXMLCmp_MarcaAgua)

            Dim Cl_Dte2XmlIPDF As New Cl_Dte2XmlPDF
            Cl_Dte2XmlIPDF.Sb_Crear_PDF2XML(Me, Ds_Xml, _NombreArchivo, _RecepXMLCmp_MarcaAgua, _RecepXMLCmp_ImpMarcaAgua, True)
            File.Delete(_Archivo & ".XML")

        Else

            MessageBoxEx.Show(Me, "El Archivo se encuentra abierto", "DTE2PDF", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If


    End Sub

    Private Sub Btn_InfFincred_Click(sender As Object, e As EventArgs) Handles Btn_InfFincred.Click

        Consulta_sql = "Select FResp.*,Isnull(FDoc.Autorizacion,'RECHAZADO') As CodAutorizacion" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Fincred_TramaRespuesta FResp" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Fincred_Documentos FDoc On FResp.Id = FDoc.Id_TR" & vbCrLf &
                        "Where Idmaeedo = " & _Idmaeedo & " And Eliminada = 0"
        Dim _RowFincred As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Codigo_negacion_transaccion = _RowFincred.Item("Codigo_negacion_transaccion")
        Dim _Descripcion_negacion = _RowFincred.Item("Descripcion_negacion")
        Dim _CodAutorizacion = _RowFincred.Item("CodAutorizacion")

        If _Codigo_negacion_transaccion = 0 Then
            MessageBoxEx.Show(Me, "Revisión de parte de FINCRED autorizada" & vbCrLf & vbCrLf &
                              "Código autorización: " & _CodAutorizacion & vbCrLf &
                              "Respuesta Fincred: " & _Descripcion_negacion, "Información FINCRED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, "Revisión de parte de FINCRED RECHAZADA" & vbCrLf & vbCrLf &
                              "Respuesta Fincred: " & _Descripcion_negacion, "Información FINCRED", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_HabilitarFacturacion_Click(sender As Object, e As EventArgs) Handles Btn_HabilitarFacturacion.Click

        If _Row_Docu_Ent.Item("HabilitadaFac") Then

            Dim _FechaHoraAutoriza As String

            If Not IsDBNull(_Row_Docu_Ent.Item("FechaHoraAutoriza")) Then
                _FechaHoraAutoriza = vbCrLf & vbCrLf & "Fecha y hora de habilitación: " & FormatDateTime(_Row_Docu_Ent.Item("FechaHoraAutoriza"), DateFormat.ShortDate) & " - " & FormatDateTime(_Row_Docu_Ent.Item("FechaHoraAutoriza"), DateFormat.ShortTime)
            End If

            MessageBoxEx.Show(Me, "Habilitada por: " & _Row_Docu_Ent.Item("NomFunHabilita").ToString.Trim & _FechaHoraAutoriza, "Nota de venta habilitada para ser facturada.",
                             MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            If _Row_Docu_Ent.Item("Customizable") Then

                If FUNCIONARIO <> _TblEncabezado.Rows(0).Item("KOFUDO") Then
                    If Not Fx_TienePermiso_EnDoc(Me, "Doc00082", _Idmaeedo) Then
                        Return
                    End If
                End If

                Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEDDO",
                                                               "IDMAEDDO Not In " &
                                                               "(Select Idmaeddo From " & _Global_BaseBk & "Zw_Docu_Det_Cust " &
                                                               "Where Idmaeedo = " & _Idmaeedo & ") And IDMAEEDO = " & _Idmaeedo)

                If CBool(_Reg) Then
                    MessageBoxEx.Show(Me, "Faltan productos customizados que confirmar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If MessageBoxEx.Show(Me, "Esta Nota de venta NO esta habilitada para ser facturada." & vbCrLf &
                              "¿Confirma habilitar la nota de venta para su facturación?", "Validación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                    Return
                End If

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Docu_Ent Set HabilitadaFac = 1,FunAutorizaFac = '" & FUNCIONARIO & "'" & vbCrLf &
                               "Where Idmaeedo = " & _Idmaeedo
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    MessageBoxEx.Show(Me, "Nota de venta habilitada para ser facturada", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If

            Else

                MessageBoxEx.Show(Me, "Esta Nota de venta NO esta habilitada para ser facturada." & vbCrLf &
                              "Para habilitar esta nota de ventas debe ir al asistente de habilitación de notas de venta para facturar", "Validación",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

    Sub Sb_Eliminar_Despachos()

        Dim _Filtro_Idmaeddo_Dori = Generar_Filtro_IN(_TblDetalle, "", "IDMAEEDO", True, False, "")

        If _Filtro_Idmaeddo_Dori = "()" Then
            _Filtro_Idmaeddo_Dori = "(-1)"
        End If

        Consulta_sql = "Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det 
                        Where Idmaeedo In (Select IDMAEEDO From MAEDDO WITH (NOLOCK) Where IDMAEDDO In " & _Filtro_Idmaeddo_Dori & ") Or Idmaeedo = " & _Idmaeedo
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Filtro_Id_Despacho As String = Generar_Filtro_IN(_Tbl, "", "Id_Despacho", False, False, "")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho In " & _Filtro_Id_Despacho & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho In " & _Filtro_Id_Despacho & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where Id_Despacho In " & _Filtro_Id_Despacho & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Despachos_Estados Where Id_Despacho In " & _Filtro_Id_Despacho
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Sub

    Private Sub Btn_CusNVV_Click(sender As Object, e As EventArgs) Handles Btn_CusNVV.Click

        Dim _Fila As DataGridViewRow = GrillaDetalleDoc.CurrentRow
        Dim _Idmaeddo As Integer = _Fila.Cells("IDMAEDDO").Value
        Dim _Koprct As String = _Fila.Cells("KOPRCT").Value
        Dim _Koen = _TblEncabezado.Rows(0).Item("ENDO")
        Dim _Cantidad = _Fila.Cells("CANTIDAD").Value

        Dim Fm As New Frm_Ver_Documento_CustomizarDet(_Idmaeedo, _Idmaeddo, _Koen, _Koprct, _Cantidad)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_MarcarNVVCustomizable_Click(sender As Object, e As EventArgs) Handles Btn_MarcarNVVCustomizable.Click

        If Not Fx_TienePermiso_EnDoc(Me, "Doc00099", _Idmaeedo) Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma marcar esta nota de venta como CUSTOMIZABLE?",
                             "Customizable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Docu_Ent Set Customizable = 1 Where Idmaeedo = " & _Idmaeedo
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Nota de venta marcada como CUSTOMIZABLE", "Customizable",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Customizable = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Docu_Ent", "Customizable", "Idmaeedo = " & _Idmaeedo)

            Lbl_CusNVV.Visible = _Customizable
            Btn_CusNVV.Visible = _Customizable

            If _Customizable Then
                Btn_CusNVV.Text = "Ver información del producto Customizado"
                Me.Text += " *** CUSTOMIZABLE ***"
                Btn_MarcarNVVCustomizable.Visible = False
                Btn_HabilitarFacturacion.Visible = True
            Else
                Btn_MarcarNVVCustomizable.Visible = True
            End If

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Contenedor_Click(sender As Object, e As EventArgs) Handles Btn_Contenedor.Click

        Btn_Contenedor_Asociar.Visible = Not CBool(_Cl_Contenedor.Zw_Contenedor.IdCont)
        Btn_Contenedor_Quitar.Visible = CBool(_Cl_Contenedor.Zw_Contenedor.IdCont)
        Btn_Contenedor_Ver.Visible = CBool(_Cl_Contenedor.Zw_Contenedor.IdCont)

        ShowContextMenu(Menu_Contextual_Contenedor)

    End Sub

    Private Sub Btn_Contenedor_Asociar_Click(sender As Object, e As EventArgs) Handles Btn_Contenedor_Asociar.Click

        Dim _IdCont = _Cl_Contenedor.Zw_Contenedor.IdCont

        If CBool(_IdCont) Then
            MessageBoxEx.Show(Me, "Ya hay un contenedor asociado" & vbCrLf &
                              "Contenedor: " & _Cl_Contenedor.Zw_Contenedor.Contenedor & " - " & _Cl_Contenedor.Zw_Contenedor.NombreContenedor,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Contenedores
        Fm.ModoSeleccion = True
        Fm.ShowDialog(Me)
        _Cl_Contenedor.Zw_Contenedor = Fm.Zw_Contenedor
        Fm.Dispose()

        If CBool(_Cl_Contenedor.Zw_Contenedor.IdCont) Then

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_Contenedor.Fx_Relacionar_Contenedor_Documento(_Idmaeedo, _Cl_Contenedor.Zw_Contenedor.IdCont)

            If Not _Mensaje.EsCorrecto Then

                Dim _Tido = Trim(_TblEncabezado.Rows(0).Item("TIDO"))
                Dim _Nudo = Trim(_TblEncabezado.Rows(0).Item("NUDO"))

                _Cl_Contenedor.Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_Idmaeedo, _Tido, _Nudo)
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return

            End If

            MessageBoxEx.Show(Me, "Contenedor asociado correctamente" & vbCrLf &
                                  "Contenedor: " & _Cl_Contenedor.Zw_Contenedor.Contenedor & " - " & _Cl_Contenedor.Zw_Contenedor.NombreContenedor,
                                  "Asociar contenedor", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_CrearNVVdesdeOCCOtraEmpresa_Click(sender As Object, e As EventArgs) Handles Btn_CrearNVVdesdeOCCOtraEmpresa.Click
        Sb_CrearNVVDesdeOCC()
    End Sub

    Private Sub Btn_Contenedor_Ver_Click(sender As Object, e As EventArgs) Handles Btn_Contenedor_Ver.Click

        Dim _IdCont = _Cl_Contenedor.Zw_Contenedor.IdCont

        If Not CBool(_IdCont) Then
            MessageBoxEx.Show(Me, "No hay un contenedor asociado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_CrearContenedor(_IdCont)
        Fm.Btn_Eliminar.Enabled = False
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            _Cl_Contenedor.Zw_Contenedor = Fm.Zw_Contenedor
        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_Nombre_Entidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Nombre_Entidad.ButtonCustomClick
        ShowContextMenu(Menu_Contextual_Info_Entidad)
    End Sub

    Private Sub Btn_Contenedor_Quitar_Click(sender As Object, e As EventArgs) Handles Btn_Contenedor_Quitar.Click

        Dim _IdCont = _Cl_Contenedor.Zw_Contenedor.IdCont
        Dim _Empresa = _Cl_Contenedor.Zw_Contenedor.Empresa
        Dim _Contenedor = _Cl_Contenedor.Zw_Contenedor.Contenedor

        If Not CBool(_IdCont) Then
            MessageBoxEx.Show(Me, "No hay un contenedor asociado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer quitar el contenedor?" & vbCrLf &
                             "Contenedor: " & _Cl_Contenedor.Zw_Contenedor.Contenedor & " - " & _Cl_Contenedor.Zw_Contenedor.NombreContenedor,
                             "Quitar contenedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_Contenedor.Fx_Quitar_Contenedor_De_Documento(_Empresa, _Contenedor, _Idmaeedo)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            _Cl_Contenedor.Zw_Contenedor = New Zw_Contenedor
        End If

    End Sub

    Sub Sb_Eliminar_Anular(_Accion As Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion)

        _Row_Maeedo_Doc = _TblEncabezado.Rows(0)

        Dim _Idmaeedo As Integer = _Row_Maeedo_Doc.Item("IDMAEEDO")
        Dim _Tido As String = _Row_Maeedo_Doc.Item("TIDO")
        Dim _Nudo As String = _Row_Maeedo_Doc.Item("NUDO")
        Dim _Koen As String = _Row_Maeedo_Doc.Item("ENDO")
        Dim _Kofudo As String = _Row_Maeedo_Doc.Item("KOFUDO")
        Dim _Nudonodefi As Boolean = _Row_Maeedo_Doc.Item("NUDONODEFI")

        Dim _Permiso As String

        If _Nudonodefi Then

            If _Kofudo = FUNCIONARIO Then
                _Permiso = "Doc00070"
            Else
                _Permiso = "Doc00071"
            End If

        Else
            _Permiso = "Doc00059"
        End If

        If Not Fx_TienePermiso_EnDoc(Me, _Permiso, _Idmaeedo) Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer " & _Accion.ToString & " este documento?",
                     _Accion.ToString.ToUpper,
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Return
        End If

        If Fx_Eliminar_Anular(_Accion) Then

            Sb_Eliminar_Despachos()

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Referencias_Dte Where Id_Doc = " & _Idmaeedo & vbCrLf & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Casi_DocArc (Nombre_Archivo,Archivo,Fecha,CodFuncionario,NombreEquipo,En_Construccion)" & vbCrLf &
                           "Select Nombre_Archivo,Archivo,Fecha,CodFuncionario,'" & _NombreEquipo & "',1" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Docu_Archivos Where Idmaeedo = " & _Idmaeedo & vbCrLf & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Docu_Archivos Where Idmaeedo = " & _Idmaeedo

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
            End If

            Me.Close()

        End If

    End Sub

End Class
