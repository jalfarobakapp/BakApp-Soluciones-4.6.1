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
    End Enum

    Enum _Tipo_Caracter
        Cualquier_caracter
        Solo_Numeros_Enteros
        Moneda
    End Enum

    Public Function InputBox_Bk(ByVal Frm_Origen As Form, _
                                Optional ByVal _TextoCentro As String = "...", _
                                Optional ByVal _TextoEncabezado As String = "Ingrese texto", _
                                Optional ByVal _TextoDescripcion As String = "", _
                                Optional ByVal _Multilinea As Boolean = True, _
                                Optional ByVal _TipoMN As _Tipo_Mayus_Minus = _Tipo_Mayus_Minus.Normal, _
                                Optional ByVal _Max_Cant_Caracteres As Integer = 0, _
                                Optional ByVal _Mostrar_Cancelar As Boolean = False, _
                                Optional ByVal _Imagen As _Tipo_Imagen = _Tipo_Imagen.Texto, _
                                Optional ByVal _Permitir_En_Blanco As Boolean = False, _
                                Optional ByVal _Tipo_de_caracter As _Tipo_Caracter = _Tipo_Caracter.Cualquier_caracter, _
                                Optional ByVal _Permitir_Valor_Cero As Boolean = True, _
                                Optional ByRef _Cancelado As Boolean = False) As String


        Dim Fm As New Frm_InpunBox_Bk

        Fm.BtnCancelar.Visible = _Mostrar_Cancelar
        Fm.TxtDescripcion.Text = _TextoDescripcion
        Fm.LblComentario_Centro.Text = _TextoCentro
        Fm.Text = _TextoEncabezado
        Fm.TxtDescripcion.Multiline = _Multilinea
        Fm._Permitir_En_Blanco = _Permitir_En_Blanco
        Fm._Permitir_Valor_Cero = _Permitir_Valor_Cero
        Fm._Tipo_de_Caracter = _Tipo_de_caracter
        Fm._Imagen = _Imagen.ToString
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

        Dim _Texto As String

        If Fm._Cancelado Then
            _Cancelado = Fm._Cancelado
            _Texto = "@@Accion_Cancelada##"
        Else
            _Texto = Fm._Nueva_Descripcion
        End If

        Return _Texto
        Fm.Dispose()


    End Function

    Public Class MyNode

        Private _text As String
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

        Private _tag As String
        Public Property Tag() As String
            Get
                Return _tag
            End Get
            Set(ByVal value As String)
                _tag = value
            End Set
        End Property

        Private _nodes As List(Of MyNode)
        Public Property Nodes() As List(Of MyNode)
            Get
                Return _nodes
            End Get
            Set(ByVal value As List(Of MyNode))
                _nodes = value
            End Set
        End Property

        Public Sub New()
            _nodes = New List(Of MyNode)
        End Sub

        Public Sub New(ByVal text As String, ByVal tag As String)
            Me.New()
            _text = text
            _tag = tag
        End Sub

    End Class


End Module
