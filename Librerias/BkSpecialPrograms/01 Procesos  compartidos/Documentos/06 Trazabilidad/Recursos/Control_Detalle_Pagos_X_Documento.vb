'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Control_Detalle_Pagos_X_Documento

    Dim m_Expanded As Boolean = False
    Dim m_ExpandedHeight As Integer = 0

    Dim _RowEncabezado As DataRow

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        m_ExpandedHeight = Me.Height
        Me.Height = labelName.Height
    End Sub

#Region "PROPIEDADES BAKAPP"

    Public Property _Documento() As String
        Get
            Return labelName.Text
        End Get
        Set(ByVal Value As String)
            labelName.Text = Value
        End Set
    End Property

    Public Property _Fila_pago() As DataRow
        Get
            Return _RowEncabezado
        End Get
        Set(ByVal _Fila As DataRow)

            _RowEncabezado = _Fila
           
            Dim _Moneda As String = Trim(_RowEncabezado.Item("MODO"))
            Dim _Monto As Double = De_Txt_a_Num_01(_RowEncabezado.Item("VABRDO"), 5)
            Dim _Abonado As Double = De_Txt_a_Num_01(_RowEncabezado.Item("VAABDO"), 5)
            Dim _Saldo As Double = _Monto - _Abonado

            Dim _Decimales = 0
            If _Moneda <> "$" Then _Decimales = 2
            'Dim _Tidp As String = _RowEncabezado.Item("TIDP")

            Lbl_Monto.Text = _Moneda & " " & FormatNumber(_Monto, _Decimales)
            Lbl_Abonado.Text = _Moneda & " " & FormatNumber(_Abonado, _Decimales)
            Lbl_Saldo.Text = _Moneda & " " & FormatNumber(_Saldo, _Decimales)

        End Set

    End Property

    Public Property Expanded() As Boolean
        Get
            Return m_Expanded
        End Get
        Set(ByVal Value As Boolean)
            m_Expanded = Value
            Dim size As Size = Me.Size
            'If TypeOf (Me.Parent) Is DevComponents.Tree.TreeGX Then
            ' Size = CType(Me.Parent, DevComponents.Tree.TreeGX).GetLayoutRectangle(Me.Bounds).Size
            ' End If

            If (m_Expanded) Then
                Size.Height = 129 'm_ExpandedHeight
                Size.Width = 246
            Else
                Size.Height = 19 'labelName.Height
                Size.Width = 50
            End If
            Me.Size = Size
        End Set
    End Property

#End Region


   
    Private Sub labelName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labelName.Click
        Me.Expanded = Not Me.Expanded
    End Sub

    Private Sub Btn_Ver_Vencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Vencimientos.Click

        Dim _Idmaeedo As Integer = Trim(_RowEncabezado.Item("IDMAEEDO"))

        Dim Fm As New Frm_Cambio_Fecha_Vencimientos(_Idmaeedo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
