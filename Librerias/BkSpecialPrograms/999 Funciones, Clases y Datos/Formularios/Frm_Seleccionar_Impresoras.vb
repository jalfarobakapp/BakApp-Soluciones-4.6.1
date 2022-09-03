Imports System.Drawing.Printing
Imports DevComponents.DotNetBar

Public Class Frm_Seleccionar_Impresoras

    Dim _Aceptar As Boolean
    Dim _Impresora_Seleccionada As String
    Dim _Impresora_Predeterminada As String

    Dim pd As New PrintDocument

    Public Property Pro_Impresora_Seleccionada() As String
        Get
            Return _Impresora_Seleccionada
        End Get
        Set(ByVal value As String)
            _Impresora_Seleccionada = value
        End Set
    End Property

    Public ReadOnly Property Pro_Impresora_Predeterminada() As String
        Get
            Return pd.PrinterSettings.PrinterName
        End Get
    End Property
    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Sub New(ByVal Impresora_Predeterminada As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Impresora_Predeterminada = Impresora_Predeterminada

    End Sub

    Private Sub Frm_Seleccionar_Impresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Obtener_impresoras(List_Impresoras)
    End Sub

    Public Sub Sb_Obtener_impresoras(ByVal sender As Object)
        'Sender es el objeto donde se veran las impresoras
        'en este caso yo utilizo un ListBox pero podria tambien ser un ComboBox
        'un List, entre otros que sean de tipo collections

        'Se define el print Document.

        '”Todo muy claro pero en ingles, se asigna en una variable el nombre
        'de la impresora predeterminada.
        If _Impresora_Predeterminada = String.Empty Then
            _Impresora_Predeterminada = pd.PrinterSettings.PrinterName
        End If

        For i = 1 To PrinterSettings.InstalledPrinters.Count '– 1
            'Por todas las impresoras instaladas ir agregandolas al objeto sender
            sender.Items.Add(PrinterSettings.InstalledPrinters.Item(i - 1).ToString)
        Next
        For i = 1 To sender.Items.Count '– 1
            If sender.Items.Item(i - 1).ToString = _Impresora_Predeterminada Then
                'La impresora de la lista que posea el nombre de la predeterminada
                'sera la seleccionada
                sender.SelectedIndex = i - 1
            End If
        Next
    End Sub

    Private Sub Btn_Seleccionar_Impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccionar_Impresora.Click
        _Aceptar = True
        _Impresora_Seleccionada = List_Impresoras.SelectedItem.ToString
        Me.Close()
    End Sub

    Private Sub List_Impresoras_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List_Impresoras.DoubleClick
        _Aceptar = True
        _Impresora_Seleccionada = List_Impresoras.SelectedItem.ToString
        Me.Close()
    End Sub

    Private Sub Btn_Dejar_Sin_Impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Dejar_Sin_Impresora.Click
        If MessageBoxEx.Show(Me, "Se quitaran la impreseora seleccionada." & vbCrLf & vbCrLf &
                             "¿Desea quitar la impresora?", "Quitar impresora",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            _Aceptar = True
            _Impresora_Seleccionada = String.Empty
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Seleccionar_Impresoras_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
