Imports Funciones_BakApp
Imports System.Windows.Forms
Public Class Frm_Inv_CalcPeso


    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        TxtTotalUnidades.Text = Format(CalcularCantidad(), "###,##")
    End Sub

    Private Function CalcularCantidad() As Double
        Try

            Dim Mu, Pm, Pt, Ct, Tr As Double

            Mu = De_Txt_a_Num_01(CmbMuestras.Text, 3)
            Pm = De_Txt_a_Num_01(TxtPesoMuestra.Text, 3)
            Pt = De_Txt_a_Num_01(TxtPesoTotal.Text, 3)
            Tr = De_Txt_a_Num_01(TxtTara.Text, 3)

            'Mu = Pm 
            'Ct = ((Pt * Mu)/Pm) - Tr

            Ct = Math.Round(((Pt * Mu) / Pm) - Tr, 0)

            Return Ct
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0

        End Try


    End Function

    Private Sub ToolsCalculadora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsCalculadora.Click
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "calc.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Private Sub TxtPesoMuestra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPesoMuestra.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            TxtPesoTotal.Focus()
            TxtTotalUnidades.Text = Format(CalcularCantidad(), "###,##")
        End If
    End Sub


    Private Sub TxtPesoTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPesoTotal.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            TxtTara.Focus()
            TxtTotalUnidades.Text = Format(CalcularCantidad(), "###,##")
        End If
    End Sub

    Private Sub TxtTara_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTara.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            TxtTotalUnidades.Text = Format(CalcularCantidad(), "###,##")
        End If
    End Sub

    Private Sub CmbMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMuestras.SelectedIndexChanged
        TxtTotalUnidades.Text = Format(CalcularCantidad(), "###,##")
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        TxtPesoMuestra.Text = 0
        TxtPesoTotal.Text = 0
        TxtTara.Text = 0

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Inv_CalcPeso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtTotalUnidades.Text = 0
    End Sub
End Class
