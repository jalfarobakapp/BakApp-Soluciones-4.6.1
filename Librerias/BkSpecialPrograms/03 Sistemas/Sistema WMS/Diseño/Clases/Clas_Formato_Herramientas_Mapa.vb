Imports System.Drawing

Public Class Clas_Formato_Herramientas_Mapa

    Dim _FontName As String
    Dim _FontSize As Single
    Dim _FontStyle As FontStyle

    Dim _Color As Color
    Dim _NroColor As String
    Dim _RutaImagen As String

    Function Fx_Editar_Color() As Boolean

        Dim dlg As New ColorDialog

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            _NroColor = dlg.Color.ToArgb
            _Color = dlg.Color

            Return True
            'CType(ControlActivo, Control).ForeColor = Color.FromArgb(str)
        End If

    End Function

    Function Fx_Editar_Fuente(ByVal _Objeto As Object) As Boolean

        _FontName = CType(_Objeto, Control).Font.Name
        _FontSize = CType(_Objeto, Control).Font.Size
        _FontStyle = CType(_Objeto, Control).Font.Style

        Dim dlg As New FontDialog
        dlg.Font = New System.Drawing.Font(_FontName, _FontSize, _FontStyle)

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            _FontName = dlg.Font.Name
            _FontSize = dlg.Font.Size
            _FontStyle = dlg.Font.Style

            _Objeto.Font = New System.Drawing.Font(_FontName, _FontSize, _FontStyle)
            Return True
        End If

    End Function

    Function Fx_Editar_Imagen() As Boolean

        Using OpenFileDialog1 As New OpenFileDialog()

            With OpenFileDialog1
                .CheckFileExists = True
                .ShowReadOnly = False
                .Filter = "All Files|*.*|Bitmap Files (*)|*.bmp;*.gif;*.jpg;*.png"
                .FilterIndex = 2

                If .ShowDialog = DialogResult.OK Then
                    ' Mostramos la imagen en el control PictureBox
                    _RutaImagen = .FileName
                    Return True
                End If
            End With

        End Using

    End Function

    Public ReadOnly Property Pro_FontName()
        Get
            Return _FontName
        End Get
    End Property

    Public ReadOnly Property Pro_FontSize()
        Get
            Return _FontSize
        End Get
    End Property

    Public ReadOnly Property Pro_FontStyle()
        Get
            Return _FontStyle
        End Get
    End Property

    Public ReadOnly Property Pro_Color()
        Get
            Return _Color
        End Get
    End Property

    Public ReadOnly Property Pro_NroColor()
        Get
            Return _NroColor
        End Get
    End Property

    Public ReadOnly Property Pro_RutaImagen()
        Get
            Return _RutaImagen
        End Get
    End Property

End Class
