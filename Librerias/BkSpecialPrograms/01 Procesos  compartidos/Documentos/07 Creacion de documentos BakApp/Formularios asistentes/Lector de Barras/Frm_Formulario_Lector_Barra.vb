Imports BkSpecialPrograms.CodigosDeBarra
Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Lector_Barra

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Lector_Barra As DataTable
    Dim _Tbl_Detalle_Doc As DataTable
    Dim _TblPermisos As DataTable

    Dim _Faltan As Double
    Dim _Sobran As Double

    Dim _Permitir_Despachar_Menos As Boolean

    Dim _Documento_Aceptado As Boolean
    Dim _ListaCodQRUnicosLeidos As List(Of CodigosDeBarra.CodigosQRLeidos)
    Dim _ListaCodConDocLeidos As List(Of CodigosDeBarra.CodigosConDocLeidos)

    Public Property Pro_Documento_Aceptado As Boolean
        Get
            Return _Documento_Aceptado
        End Get
        Set(value As Boolean)
            _Documento_Aceptado = value
        End Set
    End Property

    Public Property Permitir_Despachar_Menos As Boolean
        Get
            Return _Permitir_Despachar_Menos
        End Get
        Set(value As Boolean)
            _Permitir_Despachar_Menos = value
        End Set
    End Property

    Public Property Faltan As Double
        Get
            Return _Faltan
        End Get
        Set(value As Double)
            _Faltan = value
        End Set
    End Property

    Public Property Sobran As Double
        Get
            Return _Sobran
        End Get
        Set(value As Double)
            _Sobran = value
        End Set
    End Property

    Public Property ListaCodQRUnicosLeidos As List(Of CodigosDeBarra.CodigosQRLeidos)
        Get
            Return _ListaCodQRUnicosLeidos
        End Get
        Set(value As List(Of CodigosDeBarra.CodigosQRLeidos))
            _ListaCodQRUnicosLeidos = value
        End Set
    End Property

    Public Property ListaCodConDocLeidos As List(Of CodigosConDocLeidos)
        Get
            Return _ListaCodConDocLeidos
        End Get
        Set(value As List(Of CodigosConDocLeidos))
            _ListaCodConDocLeidos = value
        End Set
    End Property

    Public Sub New(ByRef _Tbl_Lector_Barra As DataTable,
                   ByRef _Tbl_Detalle_Doc As DataTable,
                   ByRef _TblPermisos As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        '_Ds_Matriz_Documentos = Ds_Matriz_Documentos

        Me._Tbl_Lector_Barra = _Tbl_Lector_Barra
        Me._Tbl_Detalle_Doc = _Tbl_Detalle_Doc
        Me._TblPermisos = _TblPermisos

        Grilla.DataSource = _Tbl_Lector_Barra
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
            Txt_Codigo_Barras.FocusHighlightEnabled = False
            Image_Barcode.Image = My.Resources.Recursos_Documento.barcode___copia
            Image_QRCode.Image = My.Resources.Recursos_Documento.label_qrcode___copia
        End If

        Txt_Codigo_Barras.ShortcutsEnabled = False

        Chk_LeerSoloUnaVezCodBarra.Checked = _Global_Row_Configuracion_General.Item("LeerSoloUnaVezCodBarra")
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Formulario_Lector_Barra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _ListaCodQRUnicosLeidos = New List(Of CodigosDeBarra.CodigosQRLeidos)
        _ListaCodConDocLeidos = New List(Of CodigosDeBarra.CodigosConDocLeidos)

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Chk_LeerSoloUnaVezCodBarra.CheckedChanged, AddressOf Chk_LeerSoloUnaVezCodBarra_CheckedChanged
        AddHandler Chk_LeerSoloUnaVezCodBarra.CheckedChanging, AddressOf Chk_LeerSoloUnaVezCodBarra_CheckedChanging

        If _Global_Row_Configuracion_Estacion.Item("Utilizar_Lectura_Codigo_QR") Then
            Image_QRCode.Visible = True
        End If

        Txt_Codigo_Barras.MaxLength = 300

        Sb_Llenar_Tabla_Barras()
        Sb_Formato_Grilla_Detalle()
        Me.ActiveControl = Txt_Codigo_Barras

        Btn_VerCodigosLeidos.Visible = Chk_LeerSoloUnaVezCodBarra.Checked

    End Sub

    Private Sub Sb_Formato_Grilla_Detalle()

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Codigo_Barras").ReadOnly = True
            .Columns("Codigo_Barras").Width = 120
            .Columns("Codigo_Barras").HeaderText = "Código de barra"
            .Columns("Codigo_Barras").Visible = True
            .Columns("Codigo_Barras").DisplayIndex = 0

            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DisplayIndex = 1

            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Width = 280
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = 2

            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Cód. Principal"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = 3

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows
            Dim _Codigo_Barras = _Fila.Cells("Codigo_Barras").Value
            If String.IsNullOrEmpty(_Codigo_Barras) Then
                _Fila.Visible = False
            Else
                _Fila.Visible = True
            End If
        Next

    End Sub

    Sub Sb_Llenar_Tabla_Barras()

        For Each _Fila As DataRow In _Tbl_Detalle_Doc.Rows

            Dim _Codigo As String = _Fila.Item("Codigo")
            Dim _Descripcion As String = _Fila.Item("Descripcion")
            Dim _Cantidad_Documento As Double = _Fila.Item("Cantidad")
            Dim _Tipr As String = _Fila.Item("Tipr")
            Dim _Prct As Boolean = _Fila.Item("Prct")
            Dim _UnTrans As Integer = _Fila.Item("UnTrans")
            Dim _Ud01PR As String = _Fila.Item("Ud01PR")
            Dim _Ud02PR As String = _Fila.Item("Ud02PR")
            Dim _Rtu As Double = _Fila.Item("Rtu")

            If Not _Prct Then
                If _Tipr = "FPN" Then
                    If Not Fx_Existe_Producto(_Codigo) Then
                        Sb_Insertar_Fila(_Codigo, _Descripcion, _Cantidad_Documento, _UnTrans, _Ud01PR, _Ud02PR, _Rtu)
                    End If
                End If
            End If

        Next

        For Each _Fila As DataRow In _Tbl_Lector_Barra.Rows

            Dim _Codigo As String = _Fila.Item("Codigo")
            Dim _Cantidad_Documento As Double = 0

            For Each _Filad As DataRow In _Tbl_Detalle_Doc.Rows

                Dim _Codigod = _Filad.Item("Codigo")

                If _Codigo = _Codigod Then
                    Dim _Cantidad = _Filad.Item("Cantidad")
                    _Cantidad_Documento += _Cantidad
                End If

            Next

            _Fila.Item("Cantidad_Documento") = _Cantidad_Documento

        Next

    End Sub

    Sub Sb_Insertar_Fila(_Codigo As String,
                         _Descripcion As String,
                         _Cantidad_Documento As Double,
                         _UnTrans As Integer,
                         _Ud01PR As String,
                         _Ud02PR As String,
                         _Rtu As Double)

        Dim NewFila As DataRow
        NewFila = _Tbl_Lector_Barra.NewRow
        With NewFila

            .Item("Codigo_Barras") = Txt_Codigo_Barras.Text
            .Item("Codigo") = _Codigo
            .Item("Descripcion") = _Descripcion
            .Item("Cantidad") = 0
            .Item("Cantidad_Documento") = _Cantidad_Documento
            .Item("Problema") = String.Empty
            .Item("Es_Correcto") = False
            .Item("UnTrans") = _UnTrans
            .Item("Ud01PR") = _Ud01PR
            .Item("Ud02PR") = _Ud02PR
            .Item("Rtu") = _Rtu

        End With

        _Tbl_Lector_Barra.Rows.Add(NewFila)

    End Sub

    Function Fx_Existe_Producto(_Codigo As String) As Boolean

        Dim _Existe As Boolean
        _Codigo = Trim(_Codigo)

        For Each _Fila As DataRow In _Tbl_Lector_Barra.Rows

            Dim _Kopr = Trim(_Fila.Item("Codigo"))
            Dim _Kopral = Trim(_Fila.Item("Codigo_Barras"))

            If _Codigo = _Kopr Or _Codigo = _Kopral Then
                _Existe = True : Exit For
            End If

        Next

        Return _Existe

    End Function

    Private Sub Txt_Codigo_Barras_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Codigo_Barras.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Leer_Codigo()
        End If
    End Sub

    Sub Sb_Leer_Codigo()

        Dim _Codigo As String
        Dim _CodLeido As String
        Dim _Cantidad As Integer = 1
        Dim _Unimulti As Integer = 1
        Dim _Conmultiplo As Boolean
        Dim _Multiplo As Integer

        Dim _EsTarjar_Bk = False
        Dim _EsLote_Bk = False

        Dim _Nro_Tarja = String.Empty
        Dim _Lote = String.Empty
        Dim _Tido = String.Empty
        Dim _Nudo = String.Empty

        Dim _CodigoQr As String
        Dim _Kopral As String

        _CodLeido = Txt_Codigo_Barras.Text

        If _Global_Row_Configuracion_Estacion.Item("Utilizar_Lectura_Codigo_QR") Then

            If Txt_Codigo_Barras.Text.Contains("<STX>") And Txt_Codigo_Barras.Text.Contains("<ETX>") Or
               Txt_Codigo_Barras.Text.Contains("<TXS>") And Txt_Codigo_Barras.Text.Contains("<TXE>") Then

                Dim _CodigoLeido As String = Txt_Codigo_Barras.Text
                Dim _Inicio, _Fin As String

                If Txt_Codigo_Barras.Text.Contains("<ETX>") Then
                    _Inicio = "<STX>" : _Fin = "<ETX>"
                Else
                    _Inicio = "<TXS>" : _Fin = "<TXE>"
                End If

                Dim _CodPaso As String = Replace(Txt_Codigo_Barras.Text, _Inicio, "")
                Dim _Cola As String
                Dim _SeparaCod() As String = Split(_CodPaso, _Fin, 2)

                _CodigoQr = _SeparaCod(0)
                _Cola = _SeparaCod(1)

                If Not String.IsNullOrEmpty(_Cola) Then

                    Dim _NoContieneEtx = False

                    If Not _Cola.Contains("<END>") Then
                        _NoContieneEtx = True
                    Else
                        Dim _Etx = Split(_Cola, "<", 2)
                        If _Etx(1) <> "END>" Then
                            _NoContieneEtx = True
                        End If
                    End If

                    If _NoContieneEtx Then
                        Txt_Codigo_Barras.Text = String.Empty
                        Sb_Confirmar_Lectura("La etiqueta no contiene la finalización <END>" & vbCrLf &
                                             "Revise el código o vuelva a leerlo nuevamente", "Validación", eTaskDialogIcon.Stop, Nothing)
                        Return
                    End If

                End If

                _Kopral = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_CodQR", "Kopral", "CodigoQR = '" & _CodigoQr & "'")
                _CodLeido = _CodigoLeido

            Else

                _CodigoQr = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_CodQR", "Kopral", "CodigoQR = '" & Txt_Codigo_Barras.Text & "'")

            End If

        End If

        If Txt_Codigo_Barras.Text.Contains("<TRJ>") AndAlso Txt_Codigo_Barras.Text.Contains("<END>") Then

            _EsTarjar_Bk = True

            'Asi debe quedar una etiqueta asociada a una OT para que el sistema la reconozca
            '01TER04P25000-36<OTD>36459<END>

            If Not Txt_Codigo_Barras.Text.Contains("<END>") Then
                Txt_Codigo_Barras.Text = String.Empty
                Sb_Confirmar_Lectura("La etiqueta no contiene la finalización <END>" & vbCrLf &
                                     "Revise el código o vuelva a leerlo nuevamente", "Validación", eTaskDialogIcon.Stop, Nothing)
                Return
            End If

            Dim _CodigoLeido As String = Txt_Codigo_Barras.Text

            Dim _CodPaso As String = Txt_Codigo_Barras.Text
            Dim _SeparaCod() As String = Split(_CodPaso, "<END>", 2)
            Dim _Nro_CPT As String

            _Nro_CPT = _SeparaCod(0).Replace("<TRJ>", "")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja Where Nro_CPT = '" & _Nro_CPT & "'"
            Dim _CPT_Tarja As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_CPT_Tarja) Then
                Sb_Confirmar_Lectura("No se encuentra la Tarja Nro: " & _Nro_CPT, "Validación", eTaskDialogIcon.Stop, Nothing)
                Return
            End If

            _Nro_Tarja = _Nro_CPT
            _Lote = _CPT_Tarja.Item("Lote")
            _Kopral = _CPT_Tarja.Item("CodAlternativo_Pallet")

        End If

        If String.IsNullOrEmpty(_Kopral) Then

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Lotes_Enc Where NroLote = '" & _CodLeido & "'"
            Dim _Row_Lote As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Lote) Then

                _EsLote_Bk = True

                _Kopral = _Row_Lote.Item("CodAlternativo")
                _Lote = _CodLeido
                _CodLeido = _Kopral

            End If

        End If

        If Chk_LeerSoloUnaVezCodBarra.Checked Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_CodQRLogDoc" & vbCrLf &
                           "--Inner Join MAEDDO On IDMAEEDO = Idmaeedo" & vbCrLf &
                           "Where CodLeido = '" & _CodLeido & "' And Tido = 'GRI'"
            Dim _TblQrDoc As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If _TblQrDoc.Rows.Count Then

                Dim _Msg = String.Empty
                Txt_Codigo_Barras.Text = String.Empty
                Dim _Cnt = 0

                For Each _Fl As DataRow In _TblQrDoc.Rows
                    _Msg += _Fl.Item("Tido") & "-" & _Fl.Item("Nudo")
                    _Cnt += 1
                    If _Cnt < _TblQrDoc.Rows.Count Then
                        _Msg += "; "
                    End If
                Next

                Sb_Confirmar_Lectura("El código ya fue leído en otro(s) documento(s) GRI",
                                         "No puede leer mas de una vez el mismo código en otro documento" & vbCrLf & vbCrLf &
                                         "Documento(s): " & _Msg, eTaskDialogIcon.Stop, Nothing)
                Return

            End If

            Dim ListaQr As CodigosDeBarra.CodigosQRLeidos = _ListaCodQRUnicosLeidos.FirstOrDefault(Function(p) p.CodLeido = _CodLeido)

            If Not IsNothing(ListaQr) Then
                Txt_Codigo_Barras.Text = String.Empty
                Sb_Confirmar_Lectura("El código ya fue leído", "No puede leer mas de una vez el mismo código para esta lista", eTaskDialogIcon.Stop, Nothing)
                Return
            End If

        End If

        _Codigo = Txt_Codigo_Barras.Text.Trim

        If Not String.IsNullOrEmpty(_Kopral) Then
            _Codigo = _Kopral
        End If

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Producto) Then

            _Codigo = _Sql.Fx_Trae_Dato("TABCODAL", "KOPR",
                                                "(KOPRAL = '" & _Codigo & "' And KOEN = '') Or " & vbCrLf &
                                                "(KOPR = '" & _Codigo & "')").ToString.Trim

            If String.IsNullOrEmpty(_Codigo) Then

                _Codigo = Txt_Codigo_Barras.Text

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & Txt_Codigo_Barras.Text & "' And KOEN <> ''"))

                If _Reg Then
                    MessageBoxEx.Show(Me, "El código de barras leido esta asociado a un proveedor." & vbCrLf &
                                      "Los códigos de barras para estos efectos no tienen que estar asociados a ningún proveedor",
                                      "Validación",
                                         MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Sb_Formato_Grilla_Detalle()
                    Txt_Codigo_Barras.Text = String.Empty
                    Txt_Codigo_Barras.Focus()
                    Return
                End If

            Else

                Dim _Row_Tabcodal As DataRow

                If Txt_Codigo_Barras.Text <> _Codigo Then

                    If String.IsNullOrEmpty(_Kopral) Then
                        _Kopral = Txt_Codigo_Barras.Text
                    End If

                    Consulta_sql = "Select * From TABCODAL Where (KOPRAL = '" & _Kopral & "' And KOEN = '') Or " & vbCrLf & "(KOPR = '" & _Kopral & "')"
                    '_Cantidad = _Sql.Fx_Trae_Dato("TABCODAL", "MULTIPLO",
                    '                            "(KOPRAL = '" & _Kopral & "' And KOEN = '') Or " & vbCrLf & "(KOPR = '" & _Kopral & "')")

                Else

                    Consulta_sql = "Select * From TABCODAL Where (KOPRAL = '" & _Codigo & "' And KOEN = '') Or " & vbCrLf & "(KOPR = '" & _Codigo & "') And CONMULTI = 1"
                    '_Cantidad = _Sql.Fx_Trae_Dato("TABCODAL", "MULTIPLO",
                    '                            "(KOPRAL = '" & _Codigo & "' And KOEN = '') Or " & vbCrLf & "(KOPR = '" & _Codigo & "') And CONMULTI = 1")

                End If

                _Row_Tabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)
                _Conmultiplo = _Row_Tabcodal.Item("CONMULTI")

                If _Conmultiplo Then
                    _Multiplo = _Row_Tabcodal.Item("MULTIPLO")
                    _Unimulti = _Row_Tabcodal.Item("UNIMULTI")
                End If

                _Cantidad = _Multiplo

                If _Cantidad = 0 Then
                    _Cantidad = 1
                End If

            End If

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        Dim _Ingresar_Cantidad As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_Asociacion", "Lect_Barras_IngrxCantidad",
                                                   "Codigo = '" & _Codigo & "' And Codigo_Nodo = 0 And Para_filtro = 0 And Nodo_origen = 0 And Clas_unica = 0 And Producto = 1",,,, True)

        If Not IsNothing(_Row_Producto) Then

            If Fx_Existe_Producto(_Codigo) Then

                For Each _Fila As DataGridViewRow In Grilla.Rows

                    Dim _Kopr = _Fila.Cells("Codigo").Value.ToString.Trim
                    Dim _Codigo_Barras = _Fila.Cells("Codigo_Barras").Value.ToString.Trim
                    Dim _UnTrans As Integer = _Fila.Cells("UnTrans").Value
                    Dim _Rtu As Double = _Fila.Cells("Rtu").Value

                    If _Codigo = _Kopr Or _Codigo = _Codigo_Barras Then

                        If _Ingresar_Cantidad Then

                            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese la cantidad", "Producto X Cantidad",
                                                                  _Cantidad, False, ,, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Moneda, 0)

                            If Not _Aceptar Then
                                Sb_Formato_Grilla_Detalle()
                                Txt_Codigo_Barras.Text = String.Empty
                                Txt_Codigo_Barras.Focus()
                                Return
                            End If

                        End If

                        _Fila.Cells("Codigo_Barras").Value = _CodLeido

                        If _Conmultiplo Then
                            If _Unimulti <> _UnTrans Then
                                _Cantidad = _Rtu * _Cantidad
                            End If
                        End If

                        _Fila.Cells("Cantidad").Value += _Cantidad

                        Dim _CodigosDeBarra As New CodigosDeBarra.CodigosQRLeidos

                        If Chk_LeerSoloUnaVezCodBarra.Checked Then

                            _CodigosDeBarra.CodLeido = _CodLeido
                            _CodigosDeBarra.Codigo = _Codigo
                            _CodigosDeBarra.CodigoQR = _CodigoQr
                            _CodigosDeBarra.CodigoAlternativo = _Kopral

                            _ListaCodQRUnicosLeidos.Add(_CodigosDeBarra)

                        End If

                        Dim _CodigosDeBarraTido As New CodigosDeBarra.CodigosConDocLeidos

                        If _EsTarjar_Bk Or _EsLote_Bk Then 'Not String.IsNullOrEmpty(_Tido) Then

                            Dim ListaQr As CodigosDeBarra.CodigosConDocLeidos = _ListaCodConDocLeidos.FirstOrDefault(Function(p) p.CodLeido = _CodLeido)

                            If IsNothing(ListaQr) Then

                                _CodigosDeBarraTido.CodLeido = _CodLeido
                                _CodigosDeBarraTido.Codigo = _Codigo
                                _CodigosDeBarraTido.Kopral = _Kopral
                                _CodigosDeBarraTido.Nro_Tarja = _Nro_Tarja
                                _CodigosDeBarraTido.Lote = _Lote
                                _CodigosDeBarraTido.Tido = _Tido
                                _CodigosDeBarraTido.Nudo = _Nudo

                                _ListaCodConDocLeidos.Add(_CodigosDeBarraTido)

                            End If

                        End If

                    End If

                Next

            Else

                Sb_Confirmar_Lectura("Este producto no corresponde al despacho",
                                     vbCrLf & _Row_Producto.Item("KOPR").ToString.Trim & vbCrLf & _Row_Producto.Item("NOKOPR").ToString.Trim,
                                     eTaskDialogIcon.Stop, Nothing)

            End If

        End If

        Sb_Formato_Grilla_Detalle()
        Txt_Codigo_Barras.Text = String.Empty
        Txt_Codigo_Barras.Focus()

    End Sub



    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        _Documento_Aceptado = Fx_Revisar_Pistoleo_Vs_Documento(True)

        If Not _Documento_Aceptado Then

            Sb_Formato_Grilla_Detalle()

            MessageBoxEx.Show(Me, "Existen productos con problemas que debe corregir antes de grabar", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Lector_Barra, "Es_Correcto = False", "Codigo")
            Dim Fm As New Frm_Formulario_Lector_Barra_Alerta(_Tbl_Lector_Barra)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Txt_Codigo_Barras.Text = String.Empty
            Txt_Codigo_Barras.Focus()

        Else
            Me.Close()
        End If

    End Sub

    Function Fx_Revisar_Pistoleo_Vs_Documento(_Preguntar As Boolean) As Boolean

        Dim _Valido As Boolean '= True

        Dim _Despachados As Double
        Dim _Total_Cantidad As Double

        _Faltan = 0
        _Sobran = 0

        For Each _Fila As DataRow In _Tbl_Lector_Barra.Rows

            Dim _Kopr = _Fila.Item("Codigo")
            Dim _Kopral = _Fila.Item("Codigo_Barras")
            Dim _Cantidad = _Fila.Item("Cantidad")
            Dim _Cantidad_Documento = _Fila.Item("Cantidad_Documento")

            Dim _Problema As String = String.Empty

            Dim _Es_Correcto As Boolean
            Dim _Diferencia As Double

            _Total_Cantidad += _Cantidad_Documento
            _Despachados += _Cantidad

            Dim _Saldo As Double = _Cantidad - _Cantidad_Documento

            If _Saldo > 0 Then ' *** SOBRAN ----  _Cantidad > _Cantidad_Documento Then

                _Diferencia = _Saldo '_Cantidad_Documento - _Cantidad
                _Problema = "Sobran productos -> Cantidad: " & FormatNumber(_Diferencia, 0)
                _Sobran += _Diferencia

                _Es_Correcto = False
                _Valido = False

            ElseIf _Saldo < 0 Then ' *** FALTAN     _Cantidad < _Cantidad_Documento Then

                _Diferencia = _Cantidad_Documento - _Cantidad
                _Problema = "Fantan productos -> Cantidad: " & FormatNumber(_Diferencia, 0)
                _Faltan += _Diferencia

                _Es_Correcto = False
                '_Valido = _Permitir_Despachar_Menos

            ElseIf _Saldo = 0 Then

                _Es_Correcto = True

            End If

            'End If

            _Fila.Item("Problema") = _Problema
            _Fila.Item("Es_Correcto") = _Es_Correcto

        Next

        If CBool(_Despachados) Then

            If Not CBool(_Sobran + _Faltan) Then

                _Valido = True

            Else

                If Not CBool(_Sobran) Then

                    If _Faltan Then

                        If _Permitir_Despachar_Menos Then

                            If _Preguntar Then

                                If MessageBoxEx.Show(Me, "¿Confirma el documento?", "Faltan productos por revisar",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                                    _Valido = True

                                End If

                            Else

                                _Valido = _Permitir_Despachar_Menos

                            End If

                        End If

                    End If

                End If

            End If

        End If

        Return _Valido

    End Function

    Private Sub Frm_Formulario_Lector_Barra_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Delete Then

            If Grilla.RowCount = 0 Then
                Beep()
                Return
            End If

            Try
                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                Dim _Codigo_Barras = _Fila.Cells("Codigo_Barras").Value
                Dim _ListaBorrar As New List(Of CodigosDeBarra.CodigosQRLeidos)
                Dim _ListaBorrarLeidos As New List(Of CodigosDeBarra.CodigosConDocLeidos)

                For Each _CodQr As CodigosDeBarra.CodigosQRLeidos In _ListaCodQRUnicosLeidos
                    If _CodQr.CodigoQR.Contains(_Codigo_Barras) Then
                        _ListaBorrar.Add(_CodQr)
                    End If
                Next

                For Each _CodQrBorrar As CodigosDeBarra.CodigosQRLeidos In _ListaBorrar
                    _ListaCodQRUnicosLeidos.Remove(_CodQrBorrar)
                Next

                For Each _CodTido As CodigosDeBarra.CodigosConDocLeidos In _ListaCodConDocLeidos
                    If _CodTido.CodLeido.Contains(_Codigo_Barras) Then
                        _ListaBorrarLeidos.Add(_CodTido)
                    End If
                Next

                For Each _CodQrBorrar2 As CodigosDeBarra.CodigosConDocLeidos In _ListaBorrarLeidos
                    _ListaCodConDocLeidos.Remove(_CodQrBorrar2)
                Next

                _Fila.Cells("Codigo_Barras").Value = String.Empty
                _Fila.Cells("Cantidad").Value = 0
                _Fila.Cells("Problema").Value = String.Empty
                _Fila.Cells("Es_Correcto").Value = False
            Catch ex As Exception
                Beep()
            End Try

        End If
        Sb_Formato_Grilla_Detalle()
    End Sub

    Private Sub Btn_Autorizar_Permiso_Click(sender As Object, e As EventArgs) Handles Btn_Autorizar_Permiso.Click

        If Fx_Agregar_Permiso_Otorgado_Al_Documento(Me, _TblPermisos, "Doc00022", Nothing, "", "") Then
            Pro_Documento_Aceptado = True
            Me.Close()
        End If

    End Sub

    Private Sub Frm_Formulario_Lector_Barra_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Fx_Revisar_Pistoleo_Vs_Documento(False)

        If CBool(_Sobran) Then
            _Documento_Aceptado = False
        End If

    End Sub

    Private _TiempoInicial As DateTime
    Private _TiempoFinal As DateTime
    Private _Evaluando As Boolean = False

    Private Sub Txt_Codigo_Barras_TextChanged(sender As Object, e As EventArgs) Handles Txt_Codigo_Barras.TextChanged

        If Not Chk_Teclear.Checked Then

            Dim largo As Long = Txt_Codigo_Barras.Text.Length

            If _Evaluando = False And largo >= 1 Then
                _TiempoInicial = Now
                _Evaluando = True
            Else
                If largo >= 1 Then 'evaluamos el tiempo
                    _TiempoFinal = Now
                    Dim segundos As Long = DateDiff(DateInterval.Second, _TiempoInicial, _TiempoFinal)
                    If segundos >= 1 Then
                        MessageBoxEx.Show(Me, "Entrada no permitida por teclado" & vbCrLf &
                                          "Si necesita digitar un código debe marcar la casilla <Ingresar código con el TECLADO> ",
                                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Txt_Codigo_Barras.Text = ""
                        _Evaluando = False
                    End If
                End If
            End If

            If largo = 0 Then
                _Evaluando = False
            End If

        End If

    End Sub

    Private Sub Chk_Teclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Teclear.CheckedChanged

        If Chk_Teclear.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Doc00051") Then
                Chk_Teclear.Checked = False
            End If
        End If

        Txt_Codigo_Barras.ShortcutsEnabled = Chk_Teclear.Checked

        Txt_Codigo_Barras.Text = ""
        Txt_Codigo_Barras.Focus()

    End Sub

    Private Sub Chk_LeerSoloUnaVezCodBarra_CheckedChanged(sender As Object, e As EventArgs)

        MessageBoxEx.Show(Me, "Debera volver a ingresar nuevamente los productos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If CBool(_Tbl_Lector_Barra.Rows.Count) Then

            Dim _ListaRows As New List(Of DataGridViewRow)

            For Each _Rs As DataGridViewRow In Grilla.Rows
                _ListaRows.Add(_Rs)
            Next

            For Each _Fila As DataGridViewRow In _ListaRows
                _Fila.Cells("Codigo_Barras").Value = String.Empty
                _Fila.Cells("Cantidad").Value = 0
                _Fila.Cells("Problema").Value = String.Empty
                _Fila.Cells("Es_Correcto").Value = False
            Next

            If CBool(_ListaRows.Count) Then
                _ListaCodQRUnicosLeidos = New List(Of CodigosDeBarra.CodigosQRLeidos)
            End If

        End If

        Btn_VerCodigosLeidos.Visible = Chk_LeerSoloUnaVezCodBarra.Checked
        Txt_Codigo_Barras.Text = ""
        Txt_Codigo_Barras.Focus()

    End Sub

    Private Sub Chk_LeerSoloUnaVezCodBarra_CheckedChanging(sender As Object, e As Controls.CheckBoxXChangeEventArgs)
        If Not Fx_Tiene_Permiso(Me, "Doc00078") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Btn_VerCodigosLeidos_Click(sender As Object, e As EventArgs) Handles Btn_VerCodigosLeidos.Click

        If Not CBool(_ListaCodQRUnicosLeidos.Count) Then
            MessageBoxEx.Show(Me, "No hay registros leídos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Texto As String

        For Each _CodigoLeido As CodigosDeBarra.CodigosQRLeidos In _ListaCodQRUnicosLeidos
            _Texto += "Código:" & _CodigoLeido.Codigo & ", CodAlternativo: " & _CodigoLeido.CodigoAlternativo & ", CodQR: " & _CodigoLeido.CodigoQR & vbCrLf
        Next

        Dim Fm As New Frm_Archivo_TXT
        Fm.Pro_Texto_Log = _Texto
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click

        Txt_Codigo_Barras.Text = String.Empty

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Codigo_Barras").Value = String.Empty
            _Fila.Cells("Cantidad").Value = 0
            _Fila.Cells("Problema").Value = String.Empty
            _Fila.Cells("Es_Correcto").Value = False
        Next

        _ListaCodQRUnicosLeidos = New List(Of CodigosDeBarra.CodigosQRLeidos)
        _ListaCodConDocLeidos = New List(Of CodigosDeBarra.CodigosConDocLeidos)
        Sb_Formato_Grilla_Detalle()

        MessageBoxEx.Show(Me, "Lista limpia", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class

Namespace CodigosDeBarra
    Public Class CodigosQRLeidos

        Public Property Codigo As String
        Public Property CodigoQR As String
        Public Property CodigoAlternativo As String
        Public Property CodLeido As String

    End Class

    Public Class CodigosConDocLeidos

        Public Property Codigo As String
        Public Property Tido As String
        Public Property Nudo As String
        Public Property CodLeido As String
        Public Property Kopral As String
        Public Property Nro_Tarja As String
        Public Property Lote As String

    End Class


End Namespace
