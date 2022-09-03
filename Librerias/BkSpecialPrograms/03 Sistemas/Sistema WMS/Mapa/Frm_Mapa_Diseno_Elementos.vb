Imports System.Drawing.Color
Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.PowerPacks
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Mapa_Diseno_Elementos


    Public _Aceptar As Boolean
    Public _Escala As Double

    Public _Max_X, _Max_Y As Integer

    ' Public _Ancho, _Largo As Integer
    Public _Objeto As Object 'RectangleShape

    Public _Horienta As _Horientacion

    Enum _Horientacion
        Horizontal
        Vertical
    End Enum

    Private Sub Frm_Mapa_Diseno_Elementos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Mapa_Diseno_Elementos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Escala = 3
        'Sb_Cambio_Horienzacion()

        'AddHandler Rdb_Horizontal.CheckedChanged, AddressOf Sb_Cambio_Horienzacion
        'AddHandler Rdb_Vertical.CheckedChanged, AddressOf Sb_Cambio_Horienzacion

        PropiedadesDeObjeto(_Objeto)

        Dim _Ancho_Obj_X = _Objeto.Width
        Dim _Largo_Obj_Y = _Objeto.Height

        Dim _W, _H As Integer

        'If _Largo_Obj_Y < _Ancho_Obj_X Then
        '_Verticar = True
        _W = _Ancho_Obj_X
        _H = _Largo_Obj_Y
        'Else
        '_Horizantal = True
        '_W = _Largo_Obj_Y
        '_H = _Ancho_Obj_X
        'End If


        Dim _X = _W / _Escala
        Dim _y = _H / _Escala


        SL_x.Maximum = _Max_X


        SL_x.Maximum = _Max_X
        SL_y.Maximum = _Max_Y

        SL_x.Value = _Objeto.Location.X
        SL_y.Value = _Max_Y - _Objeto.Location.Y


        AddHandler SL_x.ValueChanged, AddressOf Sb_Cambio_posicion
        AddHandler SL_y.ValueChanged, AddressOf Sb_Cambio_posicion

        Dim _TextoForm As String

        If Mid(_Objeto.NAME, 1, 3) = "Box" Then
            _TextoForm = "Propiedades de Objeto"
        ElseIf Mid(_Objeto.NAME, 1, 3) = "Lbl" Then
            _TextoForm = "Propiedades: " & _Objeto.text
            'ElseIf Mid(_Objeto.NAME, 1, 5) = "LblCm" Then
            '    _TextoForm = "Propiedades de etiqueta"
        End If

        Me.Text = _TextoForm '

        Input_Ancho_X.MaxValue = _Max_X * (10 / _Escala)
        Input_Alto_Y.MaxValue = _Max_Y * (10 / _Escala)

        Input_Ancho_X.Value = _X
        Input_Alto_Y.Value = _y


        AddHandler Input_Ancho_X.ValueChanged, AddressOf Input_XY_ValueChanged
        AddHandler Input_Alto_Y.ValueChanged, AddressOf Input_XY_ValueChanged



    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        ' _Ancho = TxtAncho.Text * _Escala
        ' _Largo = TxtLargo.Text * _Escala
        ' _Aceptar = True

        Me.Close()
    End Sub


    Sub Sb_Cambio_Horienzacion()

        Dim X = Input_Ancho_X.Value
        Dim Y = Input_Alto_Y.Value

        SL_x.Maximum = _Max_X '- Input_Largo.Value
        SL_y.Maximum = _Max_Y '- Input_Ancho.Value

        Dim _Ancho = Input_Ancho_X.Value * _Escala
        Dim _Alto = Input_Alto_Y.Value * _Escala

        _Objeto.Size() = New System.Drawing.Size(Math.Round(_Alto), Math.Round(_Ancho))

        Input_Ancho_X.Value = Y
        Input_Alto_Y.Value = X


        If Mid(_Objeto.name, 1, 3) = "Box" Then

            Dim _Relleno As New FillStyle

            _Relleno = CType(_Objeto, RectangleShape).FillStyle

            If _Relleno = FillStyle.Horizontal Then
                _Relleno = FillStyle.Vertical
            ElseIf _Relleno = FillStyle.Vertical Then
                _Relleno = FillStyle.Horizontal
            End If
            CType(_Objeto, RectangleShape).FillStyle = _Relleno

        ElseIf Mid(_Objeto.name, 1, 3) = "Lbl" Then

            Dim _Horientacion = CType(_Objeto, DevComponents.DotNetBar.LabelX).TextOrientation

            If _Horientacion = eOrientation.Horizontal Then
                CType(_Objeto, DevComponents.DotNetBar.LabelX).TextOrientation = eOrientation.Vertical
            Else
                CType(_Objeto, DevComponents.DotNetBar.LabelX).TextOrientation = eOrientation.Horizontal
            End If

        End If

    End Sub

    Sub PropiedadesDeObjeto(ByVal Objeto As Object)
        Dim _AntiAliasPropertySetting As PropertySettings
        ' Customize AntiAlias property appearance
        _AntiAliasPropertySetting = New PropertySettings("AntiAlias") ' Specifies that this setting is attached to AntiAlias property
        _AntiAliasPropertySetting.Description = "This is custom description, help text, for the AntiAlias property"
        _AntiAliasPropertySetting.DisplayName = "AntiAliasCustomName" ' Change property name that is displayed in property grid

        ' Create new visual style for property
        Dim style As ElementStyle = New ElementStyle()
        style.BackColor = Color.WhiteSmoke
        style.BackColor2 = Color.LightGoldenrodYellow
        style.BackColorGradientAngle = 90
        style.TextColor = Color.Brown
        _AntiAliasPropertySetting.Style = style

        ' Adds property setting to the grid
        Panel_Propiedades.PropertySettings.Add(_AntiAliasPropertySetting)

        ' Set object to display properties for
        Panel_Propiedades.SelectedObject = Objeto
    End Sub

    Private Sub BtnRotar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRotar.Click
        Sb_Cambio_Horienzacion()
    End Sub

    Private Sub Sb_Cambio_posicion(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _X = SL_x.Value
        Dim _y = _Max_Y - SL_y.Value

        'Dim Y = CType(_Objeto, RectangleShape).Location.Y
        _Objeto.Location = New System.Drawing.Point(_X, _y)

    End Sub


    Private Sub Input_XY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Ancho = Input_Ancho_X.Value * _Escala
        Dim _Alto = Input_Alto_Y.Value * _Escala

        _Objeto.Size() = New System.Drawing.Size(Math.Round(_Ancho), Math.Round(_Alto))

    End Sub

   
End Class