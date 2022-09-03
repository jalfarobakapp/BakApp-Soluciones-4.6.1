'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Control_Pago
    Inherits System.Windows.Forms.UserControl

    Dim m_Expanded As Boolean = False
    Dim m_ExpandedHeight As Integer = 0

    Dim _RowPago As DataRow
    Public _Idmaeedo As Integer

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

            _Idmaedpce = _RowPago.Item("IDMAEDPCE")

            Lbl_Numero.Text = _RowPago.Item("NUCUDP")
            Lbl_Codigo.Text = _RowPago.Item("TIDP") & " - " & _RowPago.Item("NUDP")

            Lbl_Fecha_Emision.Text = _RowPago.Item("FEEMDP")
            Dim _Moneda As String = Trim(_RowPago.Item("MODP"))
            Dim _Monto As Double = De_Txt_a_Num_01(_RowPago.Item("VADP"), 5)
            Dim _Abonado As Double = De_Txt_a_Num_01(_RowPago.Item("VAASDPDET"), 5)

            Dim _Tidp As String = _RowPago.Item("TIDP")

            Dim _Decimales = 0

            If _Moneda <> "$" Then _Decimales = 2

            Lbl_Monto.Text = _Moneda & FormatNumber(_Monto, _Decimales)
            Lbl_Abonado.Text = _Moneda & FormatNumber(_Abonado, _Decimales)

            Select Case _Tidp.ToString
                Case "EFV", "EFC"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(0)
                Case "TJV", "TJC"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(2)
                Case "CHV", "CHC"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(1)
                Case "LTV", "LTC"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(4)
                Case "PAV", "PAC"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(4)
                Case "DEP"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(6)
                Case "ATB", "PTB"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(3)
                Case "ncv", "ncc", "ncx", "nev", "blv", "fcv", "fcc"
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(5)
                    Btn_Ver_docuemnto_asignado.Visible = True
                Case Else
                    Imagen.Image = Lista_Imagnes_Pago_64.Images.Item(7)
            End Select


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
                size.Height = 170 'm_ExpandedHeight
                Size.Width = 295
            Else
                Size.Height = 19 'labelName.Height
                Size.Width = 120
            End If
            Me.Size = Size
        End Set
    End Property

#End Region

    Private Sub labelName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labelName.Click
        Me.Expanded = Not Me.Expanded
    End Sub

    Private Sub Btn_Ver_docuemnto_asignado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_docuemnto_asignado.Click
        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Info_doc_pagados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Info_doc_pagados.Click
        Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub
End Class
