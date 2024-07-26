Imports DevComponents.DotNetBar

Public Class Frm_Adjuntar_Imagen

    Public Property Nombre_Archivo As String
    Public Property Grabar As Boolean
    Public Property Ruta_y_Archivo As String

    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Descargas_BakApp"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Adjuntar_Imagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Pegar_Click(sender As Object, e As EventArgs) Handles Btn_Pegar.Click
        If Clipboard.ContainsImage() Then
            Pc_Imagen.Image = Clipboard.GetImage()
        End If
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Pc_Imagen.Image Is Nothing Then
            MessageBoxEx.Show(Me, "No hay imagen para grabar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Nombre del archivo", "Adjuntar imagen", Nombre_Archivo, False,, 30, True, _Tipo_Imagen.Texto)

        If _Aceptar Then

            Try

                Dim _Ruta As String = _Path & "\" & _Nombre_Archivo & ".jpg"

                ' Guarda la imagen en el formato deseado, por ejemplo, JPEG
                Pc_Imagen.Image.Save(_Ruta, System.Drawing.Imaging.ImageFormat.Jpeg)

                Ruta_y_Archivo = _Ruta
                Grabar = True
                Me.Close()

            Catch ex As Exception

                If ex.Message = "This is not a structured storage file." Then
                    MessageBoxEx.Show(Me, "No se pueden grabar archivos que provengan desde un recorte de pantalla desde Paint." & vbCrLf &
                                          "Recomendamos crear los recortes con la 'Herramienta Recortes' y luego pegar y grabar",
                                          "Este no es un archivo de almacenamiento estructurado. (Error Paint!)",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Grabar = False
                Else
                    MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End Try

        End If

    End Sub

    Private Sub Mnu_Tex_CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_CortarToolStripMenuItem.Click
        If Not Pc_Imagen.Image Is Nothing Then
            Clipboard.SetImage(Pc_Imagen.Image)
            Pc_Imagen.Image = Nothing
        End If
    End Sub

    Private Sub Mnu_Tex_CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_CopiarToolStripMenuItem.Click
        If Not Pc_Imagen.Image Is Nothing Then
            Clipboard.SetImage(Pc_Imagen.Image)
        End If
    End Sub

    Private Sub Mnu_Tex_PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_PegarToolStripMenuItem.Click
        If Clipboard.ContainsImage() Then
            Pc_Imagen.Image = Clipboard.GetImage()
        End If
    End Sub

    Private Sub Frm_Adjuntar_Imagen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Contex_Menu1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Contex_Menu1.Opening
        ' Verificar si el portapapeles contiene una imagen
        Mnu_Tex_PegarToolStripMenuItem.Enabled = Clipboard.ContainsImage()

        ' Verificar si el PictureBox tiene una imagen para habilitar Cortar y Copiar
        Dim tieneImagen As Boolean = Not Pc_Imagen.Image Is Nothing
        Mnu_Tex_CortarToolStripMenuItem.Enabled = tieneImagen
        Mnu_Tex_CopiarToolStripMenuItem.Enabled = tieneImagen
    End Sub
End Class
