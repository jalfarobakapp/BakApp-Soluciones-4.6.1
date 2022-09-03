Imports System.Drawing.Printing
Public Class Frm_Impresoras

    Public ImpresoraSeleccionada As String
    Public impresora_predeterminada As String


    Private Sub Frm_Impresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obtener_impresoras(ListBox1)

    End Sub


    Public Sub obtener_impresoras(ByVal sender As Object)
        'Sender es el objeto donde se veran las impresoras
        'en este caso yo utilizo un ListBox pero podria tambien ser un ComboBox
        'un List, entre otros que sean de tipo collections
        Dim pd As New PrintDocument
        'Se define el print Document.

        '”Todo muy claro pero en ingles, se asigna en una variable el nombre
        'de la impresora predeterminada.
        If impresora_predeterminada = "" Then
            impresora_predeterminada = pd.PrinterSettings.PrinterName
        End If

        For i = 1 To PrinterSettings.InstalledPrinters.Count '– 1
            'Por todas las impresoras instaladas ir agregandolas al objeto sender
            sender.Items.Add(PrinterSettings.InstalledPrinters.Item(i - 1).ToString)
        Next
        For i = 1 To sender.Items.Count '– 1
            If sender.Items.Item(i - 1).ToString = impresora_predeterminada Then
                'La impresora de la lista que posea el nombre de la predeterminada
                'sera la seleccionada
                sender.SelectedIndex = i - 1
            End If
        Next
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        ImpresoraSeleccionada = ListBox1.SelectedItem.ToString
        Me.Close()
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        ImpresoraSeleccionada = ""
        Me.Close()
    End Sub
End Class