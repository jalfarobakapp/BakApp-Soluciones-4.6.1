Imports System.Windows.Forms
Public Module Mod_Fx

    Enum _Tipo_Mayus_Minus
        Normal
        Mayusculas
        Minusculas
    End Enum

    Enum _Tipo_Imagen
        Barra
        Texto
        Ubicacion
        Transferencia_bancaria
        Buscar_documento
        Correo
        Cheque_Numero
        Alerta
        CodQR
        Imagen1
        Imagen2
    End Enum

    Enum _Tipo_Caracter
        Cualquier_caracter
        Solo_Numeros_Enteros
        Moneda
    End Enum

    Public Function InputBox_Bk(Frm_Origen As Form,
                                _TextoCentro As String,
                                _TextoEncabezado As String,
                                ByRef _TextoDescripcion As String,
                                Optional _Multilinea As Boolean = True,
                                Optional _TipoMN As _Tipo_Mayus_Minus = _Tipo_Mayus_Minus.Normal,
                                Optional _Max_Cant_Caracteres As Integer = 0,
                                Optional _Mostrar_Cancelar As Boolean = False,
                                Optional _Imagen As _Tipo_Imagen = _Tipo_Imagen.Texto,
                                Optional _Permitir_En_Blanco As Boolean = False,
                                Optional _Tipo_de_caracter As _Tipo_Caracter = _Tipo_Caracter.Cualquier_caracter,
                                Optional _Permitir_Valor_Cero As Boolean = True) As Boolean

        Dim _Aceptado As Boolean

        Dim Fm As New Frm_InpunBox_Bk

        Fm.BtnCancelar.Visible = _Mostrar_Cancelar
        Fm.TxtDescripcion.Text = _TextoDescripcion
        Fm.LblComentario_Centro.Text = _TextoCentro
        Fm.Text = _TextoEncabezado
        Fm.TxtDescripcion.Multiline = _Multilinea
        Fm.Pro_Permitir_En_Blanco = _Permitir_En_Blanco
        Fm.Pro_Permitir_Valor_Cero = _Permitir_Valor_Cero
        Fm.Pro_Tipo_de_Caracter = _Tipo_de_caracter
        Fm.Pro_Imagen = _Imagen.ToString

        If CBool(_Max_Cant_Caracteres) Then
            Fm.TxtDescripcion.MaxLength = _Max_Cant_Caracteres
        End If

        Fm.FormBorderStyle = FormBorderStyle.FixedDialog
        If _Multilinea Then Fm.TxtDescripcion.ScrollBars = ScrollBars.Vertical

        Select Case _TipoMN
            Case _Tipo_Mayus_Minus.Mayusculas
                Fm.TxtDescripcion.CharacterCasing = CharacterCasing.Upper
            Case _Tipo_Mayus_Minus.Minusculas
                Fm.TxtDescripcion.CharacterCasing = CharacterCasing.Lower
            Case _Tipo_Mayus_Minus.Normal
                Fm.TxtDescripcion.CharacterCasing = CharacterCasing.Normal
        End Select

        Fm.TopMost = Frm_Origen.TopMost
        Fm.ShowDialog(Frm_Origen)
        _Aceptado = Fm.Pro_Aceptado
        Fm.Dispose()

        If _Aceptado Then _TextoDescripcion = Fm.Pro_Nueva_Descripcion

        If IsNothing(_TextoDescripcion) Then

            Select Case _Tipo_de_caracter
                Case _Tipo_Caracter.Cualquier_caracter
                    _TextoDescripcion = String.Empty
                Case _Tipo_Caracter.Moneda, _Tipo_Caracter.Solo_Numeros_Enteros
                    _TextoDescripcion = 0
            End Select

        End If

        Return _Aceptado

    End Function

    Public Function InputBox_Bk_Old(Frm_Origen As Form,
                                Optional _TextoCentro As String = "...",
                                Optional _TextoEncabezado As String = "Ingrese texto",
                                Optional _TextoDescripcion As String = "",
                                Optional _Multilinea As Boolean = True,
                                Optional _TipoMN As _Tipo_Mayus_Minus = _Tipo_Mayus_Minus.Normal,
                                Optional _Max_Cant_Caracteres As Integer = 0,
                                Optional _Mostrar_Cancelar As Boolean = False,
                                Optional _Imagen As _Tipo_Imagen = _Tipo_Imagen.Texto,
                                Optional _Permitir_En_Blanco As Boolean = False,
                                Optional _Tipo_de_caracter As _Tipo_Caracter = _Tipo_Caracter.Cualquier_caracter,
                                Optional _Permitir_Valor_Cero As Boolean = True,
                                Optional ByRef _Aceptado As Boolean = False) As String


        Dim Fm As New Frm_InpunBox_Bk

        Fm.BtnCancelar.Visible = _Mostrar_Cancelar
        Fm.TxtDescripcion.Text = _TextoDescripcion
        Fm.LblComentario_Centro.Text = _TextoCentro
        Fm.Text = _TextoEncabezado
        Fm.TxtDescripcion.Multiline = _Multilinea
        Fm.Pro_Permitir_En_Blanco = _Permitir_En_Blanco
        Fm.Pro_Permitir_Valor_Cero = _Permitir_Valor_Cero
        Fm.Pro_Tipo_de_Caracter = _Tipo_de_caracter
        Fm.Pro_Imagen = _Imagen.ToString
        If CBool(_Max_Cant_Caracteres) Then
            Fm.TxtDescripcion.MaxLength = _Max_Cant_Caracteres
        End If

        Fm.FormBorderStyle = FormBorderStyle.FixedDialog
        If _Multilinea Then Fm.TxtDescripcion.ScrollBars = ScrollBars.Vertical

        Select Case _TipoMN
            Case _Tipo_Mayus_Minus.Mayusculas
                Fm.TxtDescripcion.CharacterCasing = CharacterCasing.Upper
            Case _Tipo_Mayus_Minus.Minusculas
                Fm.TxtDescripcion.CharacterCasing = CharacterCasing.Lower
            Case _Tipo_Mayus_Minus.Normal
                Fm.TxtDescripcion.CharacterCasing = CharacterCasing.Normal
        End Select

        Fm.ShowDialog(Frm_Origen)
        Fm.Dispose()

    End Function

    Public Class MyNode

        Private _text As String
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(value As String)
                _text = value
            End Set
        End Property

        Private _tag As String
        Public Property Tag() As String
            Get
                Return _tag
            End Get
            Set(value As String)
                _tag = value
            End Set
        End Property

        Private _nodes As List(Of MyNode)
        Public Property Nodes() As List(Of MyNode)
            Get
                Return _nodes
            End Get
            Set(value As List(Of MyNode))
                _nodes = value
            End Set
        End Property

        Public Sub New()
            _nodes = New List(Of MyNode)
        End Sub

        Public Sub New(text As String, tag As String)
            Me.New()
            _text = text
            _tag = tag
        End Sub

    End Class


End Module
