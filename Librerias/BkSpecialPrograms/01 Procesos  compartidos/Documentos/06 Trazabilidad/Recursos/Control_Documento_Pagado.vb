'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Control_Documento_Pagado

    Inherits System.Windows.Forms.UserControl


    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Dim m_Expanded As Boolean = False
    Dim m_ExpandedHeight As Integer = 0

    Dim _RowPago As DataRow

    Dim _Archirst As String
    Dim _Idrst As Integer

    Dim _Idmaedpce As Integer


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
            Return _RowPago
        End Get
        Set(ByVal _Fila As DataRow)

            _RowPago = _Fila

            Lbl_Fecha.Text = _RowPago.Item("FEASDP")

            _Archirst = Trim(_RowPago.Item("ARCHIRST"))
            _Idrst = _RowPago.Item("IDRST")


            If _Archirst = "MAEEDO" Then
                Btn_Ver_documento.Visible = True
            End If

            _Idmaedpce = _RowPago.Item("IDMAEDPCE")


            Dim _Moneda As String = _Sql.Fx_Trae_Dato("MAEDPCE", "MODP", "IDMAEDPCE = " & _Idmaedpce)
            Dim _Tidp As String = _Sql.Fx_Trae_Dato("MAEDPCE", "TIDP", "IDMAEDPCE = " & _Idmaedpce)

            Dim _Abonado As Double = De_Txt_a_Num_01(_RowPago.Item("VAASDP"), 5)

            Dim _Decimales = 0

            If _Moneda <> "$" Then _Decimales = 2

            Lbl_Abonado.Text = _Moneda & FormatNumber(_Abonado, _Decimales)

            ' Select _Tidp.ToString
            '   Case "EFV", "EFC"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(0)
            '    Case "TJV"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(2)
            '    Case "CHV", "CHC"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(1)
            '    Case "LTV"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(4)
            '    Case "PAV"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(4)
            '    Case "DEP"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(6)
            '    Case "ATB"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(3)
            '    Case "ncv", "ncc", "ncx", "nev", "blv", "fcv", "fcc"
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(5)
            'Btn_Ver_docuemnto_asignado.Visible = True
            '    Case Else
            'Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(7)
            'End Select


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
            'Size = CType(Me.Parent, DevComponents.Tree.TreeGX).GetLayoutRectangle(Me.Bounds).Size
            'End If

            If (m_Expanded) Then
                size.Height = 124 'm_ExpandedHeight
                size.Width = 244
            Else
                size.Height = 19 'labelName.Height
                size.Width = 120
            End If
            Me.Size = size
        End Set
    End Property

#End Region

    Private Sub Btn_Ver_docuemnto_asignado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_documento.Click

        Dim Fm As New Frm_Ver_Documento(_Idrst, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
