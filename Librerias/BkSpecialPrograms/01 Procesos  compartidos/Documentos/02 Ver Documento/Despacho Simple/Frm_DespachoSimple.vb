Public Class Frm_DespachoSimple

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _RowDepachoSimple As DataRow

    Public Property RowDepachoSimple As DataRow
        Get
            Return _RowDepachoSimple
        End Get
        Set(value As DataRow)
            _RowDepachoSimple = value
        End Set
    End Property

    Public Sub New(_Id As Integer, _Idmaeedo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Despacho_Simple" & vbCrLf &
                       "Where Id = " & _Id & " Or Idmaeedo = " & _Idmaeedo
        _RowDepachoSimple = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_DespachoSimple_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_TipoDespacho.Text = _RowDepachoSimple.Item("TipoDespacho")
        Txt_DireccionDesp.Text = _RowDepachoSimple.Item("DireccionDesp")
        Txt_DocDestino.Text = _RowDepachoSimple.Item("DocDestino")
        Txt_TipoPagoDesp.Text = _RowDepachoSimple.Item("TipoPagoDesp")
        Txt_TransporteDesp.Text = _RowDepachoSimple.Item("TransporteDesp")

    End Sub

    Private Sub Frm_DespachoSimple_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
