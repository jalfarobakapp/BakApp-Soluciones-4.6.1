Imports Microsoft.Office.Interop
Imports System.IO

Public Class Frm_Archivo_TXT

    Dim _Nombre_Archivo As String = "Informacion.txt"
    Dim _Directorio_Destino As String = AppPath() & "\Data\" & RutEmpresa & "\Temp\"
    Dim _Grabar_En_Archivo As Boolean = True
    Dim _Grabar As Boolean
    Dim _Texto_Chico As Boolean
    Dim _Ancho As Integer
    Dim _Alto As Integer

    Public Property Pro_Nombre_Archivo() As String
        Get
            Return _Nombre_Archivo
        End Get
        Set(ByVal value As String)
            _Nombre_Archivo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Directorio_Destino() As String
        Get
            Return _Directorio_Destino
        End Get
    End Property
    Public Property Pro_Texto_Log() As String
        Get
            Return Replace(Txt_Texto.Text, "'", "''")
        End Get
        Set(ByVal value As String)
            Txt_Texto.Text = Replace(value, "''", "'")
        End Set
    End Property
    Public Property ThisApplication As Object
    Public Property Pro_Grabar_En_Archivo As Boolean
        Get
            Return _Grabar_En_Archivo
        End Get
        Set(value As Boolean)
            _Grabar_En_Archivo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Texto_Chico As Boolean
        Get
            Return _Texto_Chico
        End Get
        Set(value As Boolean)
            _Texto_Chico = value
        End Set
    End Property

    Public Property Ancho As Integer
        Get
            Return _Ancho
        End Get
        Set(value As Integer)
            _Ancho = value
        End Set
    End Property

    Public Property Alto As Integer
        Get
            Return _Alto
        End Get
        Set(value As Integer)
            _Alto = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Ancho = 800
        _Alto = 600

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Archivo_TXT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Size = New Size(_Ancho, _Alto)

        If _Texto_Chico Then
            Txt_Texto.Font = New System.Drawing.Font("Courier New", 8, System.Drawing.FontStyle.Regular)
        End If

        Svf_Directorio.FileName = _Directorio_Destino

        Txt_Texto.Select(Txt_Texto.TextLength, 0)

    End Sub

    Private Sub Frm_Archivo_TXT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If _Grabar_En_Archivo Then

            Svf_Directorio.FileName = _Nombre_Archivo

            If Svf_Directorio.ShowDialog = DialogResult.OK Then

                _Nombre_Archivo = Path.GetFileNameWithoutExtension(Svf_Directorio.FileName)
                _Directorio_Destino = Path.GetDirectoryName(Svf_Directorio.FileName)

                CrearArchivoTxt(_Directorio_Destino, _Nombre_Archivo & ".txt", Txt_Texto.Text)
                Process.Start("explorer.exe", _Directorio_Destino)

            End If
        Else
            _Grabar = True
        End If

        Me.Close()

    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        If Txt_Texto.Text.Length > 0 Then

            If False Then
                Dim appWord As New Word.Application '.Dreclaras un objeto de Word 
                Dim Word As Object
                'Declaras una cadena String Temporal
                Dim Texto As String
                'Creas el objeto tipo Word.Basic
                Word = CreateObject("Word.Basic")
                'Creas un archivo nuevo de word  
                Word.FileNew()
                'Insertas el texto temporal de tu area de texto en word
                Word.Insert(Txt_Texto.Text)
                On Error Resume Next
                Word.Visible = False
                Word.ToolsSpelling()
                Word.Close(SaveChanges:=False)
                Word.EditSelectAll()
                'Word.Document.Close(SaveChanges:=False)
                Word.Quit()
                Word.SetDocumentVar("MyVar", Word.Selection)
                Texto = Word.GetDocumentVar("MyVar")
                Txt_Texto.Text = Microsoft.VisualBasic.Left(Texto, Len(Texto) - 1)
                'MsgBox("Se termino de verificar la ortografia en 'Quien llamó'")

            End If

        End If

    End Sub

End Class
