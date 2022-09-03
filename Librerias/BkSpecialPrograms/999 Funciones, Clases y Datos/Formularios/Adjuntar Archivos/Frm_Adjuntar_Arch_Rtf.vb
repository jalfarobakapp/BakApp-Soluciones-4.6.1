Imports System.IO
Imports DevComponents.DotNetBar
Imports System.Drawing.Imaging
Imports Spire.Doc
Imports Spire.Doc.Documents

Public Class Frm_Adjuntar_Arch_Rtf

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Grabar As Boolean
    Dim _Nombre_Archivo As String
    Dim _Tabla As String
    Dim _Campo As String
    Dim _Codigo_Id As String
    Dim _Id As Integer

    Dim _Ruta_y_Archivo As String
    Dim _Nombre_Archivo_Ext As String

    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Descargas_BakApp"
    Dim _Dir_Temp As String

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Nombre_Archivo As String
        Get
            Return _Nombre_Archivo
        End Get
        Set(value As String)
            _Nombre_Archivo = value
        End Set
    End Property

    Public Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property Dir_Temp As String
        Get
            Return _Dir_Temp
        End Get
        Set(value As String)
            _Dir_Temp = value
        End Set
    End Property

    Public Property Campo As String
        Get
            Return _Campo
        End Get
        Set(value As String)
            _Campo = value
        End Set
    End Property

    Public Property Codigo_Id As String
        Get
            Return _Codigo_Id
        End Get
        Set(value As String)
            _Codigo_Id = value
        End Set
    End Property

    Public Property Ruta_y_Archivo As String
        Get
            Return _Ruta_y_Archivo
        End Get
        Set(value As String)
            _Ruta_y_Archivo = value
        End Set
    End Property

    Public Property Nombre_Archivo_Ext As String
        Get
            Return _Nombre_Archivo_Ext
        End Get
        Set(value As String)
            _Nombre_Archivo_Ext = value
        End Set
    End Property

    Public Sub New(_Tabla As String, _Campo As String, _Codigo_Id As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not Directory.Exists(_Path) Then
            System.IO.Directory.CreateDirectory(_Path)
        End If

        Tabla = _Tabla
        Campo = _Campo
        Codigo_Id = _Codigo_Id

        _Dir_Temp = _Path

    End Sub

    Private Sub Frm_Adjuntar_Arch_Rtf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Global_Thema = Enum_Themas.Oscuro Then
            Rtf_Observaciones.ForeColor = Color.FromArgb(37, 136, 213)
        End If

        If Not Btn_Grabar.Visible Then
            Rtf_Observaciones.ContextMenu = Nothing
            Btn_Pegar.Visible = False
        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Nombre del archivo", "Adjuntar imagen", _Nombre_Archivo, False,, 30, True, _Tipo_Imagen.Texto)

        If _Aceptar Then

            Dim _Id As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & _Tabla,
                                                              _Campo & " = '" & _Codigo_Id & "'" &
                                                              " And (Nombre_Archivo = '" & _Nombre_Archivo & ".rtf' Or Nombre_Archivo Like '" & _Nombre_Archivo & "%')")

            If CBool(_Id) Then
                _Nombre_Archivo += "(" & _Id & ")"
            End If

            '_Nombre_Archivo += ".rtf"

            Dim _Ruta As String = _Dir_Temp & "\" & _Nombre_Archivo & ".rtf"

            Rtf_Observaciones.SaveFile(_Ruta)

            Dim _Ext = ".jpg"
            _Grabar = True

            Try

                Dim document As New Document()

                document.LoadFromFile(_Ruta, FileFormat.Rtf)

                'Save to Image
                Dim image As Image = document.SaveToImages(0, ImageType.Bitmap)
                image.Save(_Dir_Temp & "\" & _Nombre_Archivo & _Ext, ImageFormat.Jpeg)

            Catch ex As Exception

                If ex.Message = "This is not a structured storage file." Then
                    MessageBoxEx.Show(Me, "No se pueden grabar archivos que provengan desde un recorte de pantalla desde Paint." & vbCrLf &
                                          "Recomendamos crear los recortes con la 'Herramienta Recortes' y luego pegar y grabar",
                                          "Este no es un archivo de almacenamiento estructurado. (Error Paint!)",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Rtf_Observaciones.Clear()
                    Rtf_Observaciones.Update()

                    _Grabar = False

                Else
                    _Ext = ".rtf"
                End If

            End Try

            If _Grabar Then

                _Ruta_y_Archivo = _Dir_Temp & "\" & _Nombre_Archivo & _Ext
                _Nombre_Archivo_Ext = _Nombre_Archivo & _Ext

                Me.Close()

            End If

        End If

    End Sub

    Private Sub Frm_Adjuntar_Arch_Rtf_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Mnu_Tex_CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_CopiarToolStripMenuItem.Click
        Rtf_Observaciones.Copy()
    End Sub

    Private Sub Mnu_Tex_PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_PegarToolStripMenuItem.Click
        Rtf_Observaciones.Paste()
    End Sub

    Private Sub Mnu_Tex_CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_CortarToolStripMenuItem.Click
        Rtf_Observaciones.Cut()
    End Sub

    Private Sub Btn_Pegar_Click(sender As Object, e As EventArgs) Handles Btn_Pegar.Click
        Rtf_Observaciones.Paste()
    End Sub
End Class
