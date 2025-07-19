'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Cashdro_Pago_Nota_de_credito

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Maeedo_NCV As DataRow
    Dim _Row_Operacion_NCV As DataRow

    Dim _Devolucion_Efectivo As Boolean
    Dim _Usar_Nota_de_credito As Boolean

    Dim _Numero As String
    Dim _Id As Integer

    Public ReadOnly Property Pro_Devolucion_Efectivo() As Boolean
        Get
            Return _Devolucion_Efectivo
        End Get
    End Property
    Public ReadOnly Property Pro_Usar_Nota_de_credito() As Boolean
        Get
            Return _Usar_Nota_de_credito
        End Get
    End Property
    Public ReadOnly Property Pro_Row_Operacion_NCV() As DataRow
        Get
            Return _Row_Operacion_NCV
        End Get
    End Property
    Public ReadOnly Property Pro_Numero() As String
        Get
            Return _Numero
        End Get
    End Property
    Public ReadOnly Property Pro_Id() As Integer
        Get
            Return _Id
        End Get
    End Property

    Public Sub New(ByVal Row_Maeedo_NCV As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Maeedo_NCV = Row_Maeedo_NCV

    End Sub

    Private Sub Frm_Cashdro_Pago_Nota_de_credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Nudo = _Row_Maeedo_NCV.Item("NUDO")
        Dim _Monto = _Row_Maeedo_NCV.Item("SALDO")

        Lbl_Documento.Text = "<b><font color=" & Chr(34) & "#ED1C24" & Chr(34) & ">DOCUMENTO</font></b>  <b>" & _Nudo & "</b>"
        Lbl_Total_A_Pagar.Text = "<b><font color=" & Chr(34) & "#ED1C24" & Chr(34) & _
                                 ">SALDO A FAVOR</font></b>  <b>" & FormatCurrency(_Monto, 0) & "</b>"

    End Sub

    Private Sub Btn_Efectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Efectivo.Click

        _Devolucion_Efectivo = True

        Dim _Idmaeedo_NCV = _Row_Maeedo_NCV.Item("IDMAEEDO")
        Dim _Nudo_NCV = _Row_Maeedo_NCV.Item("NUDO")

        _Numero = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones", "COALESCE(MAX(Numero),'0000000000')")
        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)


        Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _posuser As String = FUNCIONARIO
        Dim _Vuelto As Double
        Dim _Saldo_Doc As Double = _Row_Maeedo_NCV.Item("SALDO")

        If _Saldo_Doc < 0 Then
            _Vuelto = _Saldo_Doc * -1
        End If

        _Vuelto = _Saldo_Doc

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Modalidad,Empresa,Sucursal,Bodega,Caja) Values " & vbCrLf & _
                       "('" & _Numero & "','',GetDate(),'" & _posid & "','" & _posuser & "','" & Mod_Modalidad & _
                       "','" & Mod_Empresa & "','" & Mod_Sucursal & "','" & Mod_Bodega & "','" & Mod_Caja & "')"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)


        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) & _
                       "Idmaeedo = 0," & _
                       "Tipo_De_Pago = 'NCV'," & _
                       "Pagado_Nota_de_credito = 1," & _
                       "Monto = 0," & _
                       "Idmaeedo_NCV = " & _Idmaeedo_NCV & "," & _
                       "Nudo_NCV = '" & _Nudo_NCV & "'," & _
                       "Vuelto = " & De_Num_a_Tx_01(_Vuelto, False, 5) & "," & _
                       "FechaHora_Fin = Getdate()," & _
                       "Log_Error = 'Devolución de dinero en efectivo'" & vbCrLf & _
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = "Update MAEEDO Set ESPGDO = 'C' Where IDMAEEDO = " & _Idmaeedo_NCV
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf & _
                       "Where Id = " & _Id
        _Row_Operacion_NCV = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me.Close()

    End Sub

    Private Sub Btn_Tarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Usar_NCV.Click
        _Usar_Nota_de_credito = True
        Me.Close()
    End Sub

    Private Sub Btn_Cancelar_Operacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar_Operacion.Click
        Me.Close()
    End Sub

End Class