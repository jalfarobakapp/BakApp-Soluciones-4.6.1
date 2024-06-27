Imports System.Windows.Forms
Imports DevComponents.DotNetBar
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
        Key
        Money1
        Money2
        Product
        Storage
        Folder
        Fecha
    End Enum

    Enum _Tipo_Caracter
        Cualquier_caracter
        Solo_Numeros_Enteros
        Moneda
        Fecha
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
                                Optional _Permitir_Valor_Cero As Boolean = True,
                                Optional _PasswordChar As String = "",
                                Optional ByRef _Chk As Controls.CheckBoxX = Nothing,
                                Optional _BuscarCarpeta As Boolean = False,
                                Optional _NoPermitirEntradaDeTeclado As Boolean = False,
                                Optional ByRef _CerradoPorX As Boolean = False) As Boolean

        Dim _Aceptado As Boolean

        Dim Fm As New Frm_InpunBox_Bk

        Fm.BtnCancelar.Visible = _Mostrar_Cancelar
        Fm.TxtDescripcion.Text = _TextoDescripcion
        Fm.TxtDescripcion.PasswordChar = _PasswordChar
        Fm.LblComentario_Centro.Text = _TextoCentro
        Fm.Text = _TextoEncabezado
        Fm.TxtDescripcion.Multiline = _Multilinea
        Fm.Pro_Permitir_En_Blanco = _Permitir_En_Blanco
        Fm.Pro_Permitir_Valor_Cero = _Permitir_Valor_Cero
        Fm.Pro_Tipo_de_Caracter = _Tipo_de_caracter
        Fm.Pro_Imagen = _Imagen.ToString
        Fm.Chk = _Chk
        Fm.BuscarCarpeta = _BuscarCarpeta
        Fm.NoPermitirEntradaDeTeclado = _NoPermitirEntradaDeTeclado

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
        _CerradoPorX = Fm.CerradoPorX

        Fm.Dispose()

        If _Aceptado Then

            _TextoDescripcion = Fm.Pro_Nueva_Descripcion

            If _Tipo_de_caracter = _Tipo_Caracter.Moneda Then
                _TextoDescripcion = De_Txt_a_Num_01(Fm.Pro_Nueva_Descripcion, 5)
            End If

        End If

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

    Public Function InputBox_Bk_Fecha(Frm_Origen As Form,
                                      _TextoCentro As String,
                                      _TextoEncabezado As String,
                                      ByRef _TextoDescripcion As DateTime,
                                      Optional _FechaMinima As Date = Nothing,
                                      Optional _Mostrar_Cancelar As Boolean = False,
                                      Optional ByRef _Chk As Controls.CheckBoxX = Nothing) As Boolean

        Dim _Aceptado As Boolean

        Dim Fm As New Frm_InpunBox_Bk

        Fm.BtnCancelar.Visible = _Mostrar_Cancelar
        Fm.TxtDescripcion.Text = String.Empty
        Fm.LblComentario_Centro.Text = _TextoCentro
        Fm.Text = _TextoEncabezado
        Fm.TxtDescripcion.Multiline = False
        Fm.Pro_Permitir_En_Blanco = False
        Fm.Pro_Tipo_de_Caracter = _Tipo_Caracter.Fecha
        Fm.Pro_Imagen = Fm.Pro_Imagen = _Tipo_Imagen.Fecha
        Fm.Chk = _Chk

        Dim _ConFechaMinima As Boolean = True

        If _FechaMinima = #1/1/0001 12:00:00 AM# Then
            _ConFechaMinima = False
        End If

        Fm.ConFechaMinima = _ConFechaMinima
        Fm.FechaMinima = _FechaMinima

        Fm.FormBorderStyle = FormBorderStyle.FixedDialog
        Fm.TopMost = Frm_Origen.TopMost
        Fm.ShowDialog(Frm_Origen)

        _Aceptado = Fm.Pro_Aceptado

        Fm.Dispose()

        If _Aceptado Then _TextoDescripcion = Convert.ToDateTime(Fm.Pro_Nueva_Descripcion)

        Return _Aceptado

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
