Public Class Control_Producto

    Dim m_Expanded As Boolean = False
    Dim m_ExpandedHeight As Integer = 0
    Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt
    Dim _Form As Form
    Dim _RowProducto As DataRow

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        m_ExpandedHeight = Me.Height
        Me.Height = labelName.Height
    End Sub

    Public Property Formulario() As Form
        Get
            Return _Form
        End Get
        Set(ByVal _Formulario As Form)
            _Form = _Formulario
        End Set
    End Property

    Public Property _Documento() As String
        Get
            Return labelName.Text
        End Get
        Set(ByVal Value As String)
            labelName.Text = Value
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
            'size = CType(Me.Parent, DevComponents.Tree.TreeGX).GetLayoutRectangle(Me.Bounds).Size
            'End If

            If (m_Expanded) Then
                size.Height = 164 'm_ExpandedHeight
                size.Width = 380
            Else
                size.Height = 19 'labelName.Height
                size.Width = 100
            End If
            Me.Size = size
        End Set
    End Property

    Private Sub labelName_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles labelName.LinkClicked
        Me.Expanded = Not Me.Expanded
    End Sub

    Public Property _Fila_Producto() As DataRow
        Get
            Return _RowProducto
        End Get
        Set(ByVal _Fila As DataRow)

            _RowProducto = _Fila
            Lbl_Descripcion.Text = _RowProducto.Item("NOKOPR")
            Lbl_Rtu.Text = _RowProducto.Item("RLUDPR")
            Dim _Udtrpr As String = _RowProducto.Item("UDTRPR")

            If _Udtrpr = 2 Then
                Lbl_Unidad.Text = Trim(_Fila.Item("UD02PR"))
                Lbl_Cantidad.Text = FormatNumber(Trim(_Fila.Item("CAPREX2"))) 'FormatNumber(Trim(_Fila.Item("CAPRCO2")))
            Else
                Lbl_Unidad.Text = Trim(_Fila.Item("UD01PR"))
                Lbl_Cantidad.Text = Trim(_Fila.Item("CAPREX1")) 'Trim(_Fila.Item("CAPRCO1"))
            End If

            Dim _Estado As String = Trim(_Fila.Item("ESLIDO"))

            Select Case _Estado
                Case "C"
                    Imagen.Image = Lista_Imagnes_Producto_64.Images.Item(1)
                    Lbl_Estado.Text = "Cerrado"
                Case ""
                    Imagen.Image = Lista_Imagnes_Producto_64.Images.Item(2)
                    Lbl_Estado.Text = "Abierto"
                Case Else
                    Imagen.Image = Lista_Imagnes_Producto_64.Images.Item(0)
                    Lbl_Estado.Text = "??"
            End Select


        End Set
    End Property

    Private Sub Btn_Estadisticas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas.Click
        Dim _Codigo As String = _RowProducto.Item("KOPRCT")
        Fm_Producto.Sb_Ver_Informacion_Adicional_producto(_Form, _Codigo)
    End Sub

    Private Sub Btn_Anotacion_a_la_linea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anotacion_a_la_linea.Click

        Dim _Idmaeedo As Integer = _RowProducto.Item("IDMAEEDO")
        Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Idmaeedo, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEDDO)
        Fm.ShowDialog(Me)

        Fm.Dispose()
    End Sub
End Class
