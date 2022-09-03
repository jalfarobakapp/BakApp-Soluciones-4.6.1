Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Formato_Diseno_Copiar_Formato

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TipoDoc_Origen, _NombreFormato_Origen, _Subtido_Origen As String
    Dim _Grabar As Boolean

    Public Sub New(_TipoDoc_Origen As String,
                   _NombreFormato_Origen As String,
                   _Subtido_Origen As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._TipoDoc_Origen = _TipoDoc_Origen.Trim
        Me._NombreFormato_Origen = _NombreFormato_Origen.Trim
        Me._Subtido_Origen = _Subtido_Origen.Trim

        Lbl_Documento_Origen.Text = _TipoDoc_Origen & " - " & _NombreFormato_Origen

    End Sub

    Private Sub Frm_Formato_Diseno_Copiar_Formato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        caract_combo(CmbTipoDeDocumentos)

        '"When TipoDoc IN ('SOC','SOL') Then 'SOLICITUD DE COMPRA'" & vbCrLf & _
        '"When TipoDoc = 'CHC' Then 'CHEQUE '+(SELECT NOKOENDP FROM TABENDP WHERE KOENDP = Emdp)" & vbCrLf & _
        '"When TipoDoc = 'TJV' Then 'TARJETA DEBITO/CREDITO'" & vbCrLf & _
        '"When TipoDoc = 'VAL' Then 'VALE DESPACHO'" & vbCrLf & _
        '"When TipoDoc = 'DIR' Then 'DIRECCION DESPACHO'" & vbCrLf & _
        '"When TipoDoc = 'CPG' Then 'COMPROBANTE DE PAGO'" & vbCrLf & _

        Dim _Filtro As String

        Select Case _TipoDoc_Origen
            Case "CHC", "TJV", "CPG"
                _Filtro = "Where TipoDoc = '" & _TipoDoc_Origen & "' And NombreFormato <> '" & _NombreFormato_Origen & "'"
                Txt_NombreFormato.Enabled = False
                Chk_Copiar_en_formato_por_defecto.Enabled = False
            Case Else
                _Filtro = "Where TipoDoc Not In ('CHC','TJV','CPG')"
        End Select

        Consulta_sql = "SELECT Distinct Ltrim(Rtrim(TipoDoc))+'-'+Ltrim(Rtrim(Subtido)) As Padre, TipoDoc+' - '+Case" & vbCrLf &
                       "When TipoDoc IN ('SOC','SOL') Then 'SOLICITUD DE COMPRA'" & vbCrLf &
                       "When TipoDoc = 'CHC' Then 'CHEQUE '+(SELECT NOKOENDP FROM TABENDP WHERE KOENDP = Emdp)" & vbCrLf &
                       "When TipoDoc = 'TJV' Then NombreFormato" & vbCrLf &
                       "When TipoDoc = 'VAL' Then 'VALE DESPACHO'" & vbCrLf &
                       "When TipoDoc = 'DIR' Then 'DIRECCION DESPACHO'" & vbCrLf &
                       "When TipoDoc = 'SPB' Then 'SOL. PRODUCTOS A BODEGA'" & vbCrLf &
                       "Else LTRIM(RTRIM(Isnull((Select Top 1 NOTIDO From TABTIDO Where TIDO = TipoDoc),'')))" & vbCrLf &
                       "End As Hijo" & vbCrLf &
                       "Into #Paso_Fx" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       _Filtro & vbCrLf &
                       "Update #Paso_Fx Set Hijo = 'GDD_CON - GUIA DESPACHO POR DEVOLUCION CONSIGNACION' Where Padre = 'GDD-CON'
                        Update #Paso_Fx Set Hijo = 'GDD_PRE - GUIA DESPACHO POR DEVOLUCION PRESTAMO' Where Padre = 'GDD-PRE'
                        Select * From #Paso_Fx
                        Drop Table #Paso_Fx"


        Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        CmbTipoDeDocumentos.DataSource = _Tbl_Documentos
        CmbTipoDeDocumentos.SelectedValue = _TipoDoc_Origen '& "," & _NombreFormato_Origen

    End Sub

    Private Sub Chk_Copiar_en_formato_por_defecto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Copiar_en_formato_por_defecto.CheckedChanged

        If Chk_Copiar_en_formato_por_defecto.Checked Then
            Lbl_NombreFormato.Enabled = False
            Txt_NombreFormato.Enabled = False
        Else
            Lbl_NombreFormato.Enabled = True
            Txt_NombreFormato.Enabled = True
            Txt_NombreFormato.Focus()
        End If

    End Sub

    Private Sub Btn_Copiar_Formato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar_Formato.Click

        Dim _NombreFormato As String
        Dim _Emdp As String

        If Chk_Copiar_en_formato_por_defecto.Checked Then
            _NombreFormato = "X Defecto"
        Else
            Select Case _TipoDoc_Origen
                Case "CHC", "TJV", "CPG"
                    Dim _NomFor = Split(Trim(CmbTipoDeDocumentos.Text), "-", 2)
                    _NombreFormato = Trim(_NomFor(1))
                    _Emdp = Trim(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Format_01", "Emdp", "NombreFormato = '" & _NombreFormato & "'"))
                Case Else
                    _NombreFormato = Txt_NombreFormato.Text
            End Select
        End If

        Dim _Formato_Destino = CmbTipoDeDocumentos.SelectedValue
        Dim _TipoDoc_Destino As String
        Dim _Subtido_Destino As String
        Dim _NombreFormato_Destino As String

        Dim _Copia = Split(_Formato_Destino, "-")

        _TipoDoc_Destino = _Copia(0).ToString.Trim
        Try
            _Subtido_Destino = _Copia(1).ToString.Trim
        Catch ex As Exception
            _Subtido_Destino = String.Empty
        End Try

        _NombreFormato_Destino = _NombreFormato

        If _TipoDoc_Origen = _TipoDoc_Destino And _Subtido_Origen = _Subtido_Destino And _NombreFormato_Origen = _NombreFormato_Destino Then

            MessageBoxEx.Show(Me, "No puede copiar el documento con el mismo nombre del formato de origen", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Format_02",
                                            "TipoDoc = '" & _TipoDoc_Destino & "' And NombreFormato = '" & _NombreFormato_Destino & "' And Subtido = '" & _Subtido_Destino & "' And Emdp = '" & _Emdp & "'")

        If CBool(_Reg) Then

            If MessageBoxEx.Show(Me, "EL FORMATO " & _TipoDoc_Destino & " - " & _NombreFormato_Destino & " YA EXISTE" &
                                 vbCrLf & vbCrLf & "¿Desea sobre escribir el formato ya existente?",
                                 "Validación",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                Return
            End If

        End If


        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Format_01" & Space(1) &
                       "Where TipoDoc = '" & _TipoDoc_Destino & "' And NombreFormato = '" & _NombreFormato_Destino & "' And Subtido = '" & _Subtido_Destino & "' And Emdp = '" & _Emdp & "'" &
                       vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Format_02" & Space(1) &
                       "Where TipoDoc = '" & _TipoDoc_Destino & "' And NombreFormato = '" & _NombreFormato_Destino & "' And Subtido = '" & _Subtido_Destino & "' And Emdp = '" & _Emdp & "'" &
                       vbCrLf &
                       vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,NombreFormato,Cod_Pagina,LargoDoc,AnchoDoc,NroLineasXpag," &
                       "Fila_InicioDetalle,Fila_FinDetalle,Col_InicioDetalle,Col_FinDetalle,Largo_Variable,Emdp,Es_Picking,Detalle_Doc_Incluye,Subtido)" &
                       vbCrLf &
                       "Select '" & _TipoDoc_Destino & "','" & _NombreFormato_Destino & "',Cod_Pagina,LargoDoc,AnchoDoc," & Space(1) &
                       "NroLineasXpag,Fila_InicioDetalle,Fila_FinDetalle,Col_InicioDetalle,Col_FinDetalle,Largo_Variable,'" & _Emdp &
                       "',Es_Picking,Detalle_Doc_Incluye,'" & _Subtido_Destino & "'" & Space(1) &
                       "From " & _Global_BaseBk & "Zw_Format_01" &
                       vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc_Origen & "' And Subtido = '" & _Subtido_Origen & "' And NombreFormato = '" & _NombreFormato_Origen & "'" &
                       vbCrLf &
                       vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Format_02 (TipoDoc,NombreFormato,NombreObjeto,Seccion,TipoDato,Funcion,Formato," &
                       "CantDecimales,Fuente,Tamano,Alto,Ancho,Estilo,Color,Fila_Y,Columna_X,Texto,RutaImagen,Borde_Variable,Orden_Detalle,Emdp,Subtido) " & vbCrLf &
                       "Select '" & _TipoDoc_Destino & "','" & _NombreFormato_Destino & "',NombreObjeto,Seccion,TipoDato," &
                       "Funcion,Formato,CantDecimales,Fuente,Tamano,Alto,Ancho,Estilo,Color,Fila_Y,Columna_X,Texto,RutaImagen,Borde_Variable,Orden_Detalle,'" & _Emdp & "','" & _Subtido_Destino & "'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Format_02" &
                       vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc_Origen & "' And Subtido = '" & _Subtido_Origen & "' And NombreFormato = '" & _NombreFormato_Origen & "'"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            _Grabar = True
            MessageBoxEx.Show(Me, "Formato copiado correctamente", "Copiar formato", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If


    End Sub

    Public ReadOnly Property Pro_Grabar()
        Get
            Return _Grabar
        End Get
    End Property

End Class
