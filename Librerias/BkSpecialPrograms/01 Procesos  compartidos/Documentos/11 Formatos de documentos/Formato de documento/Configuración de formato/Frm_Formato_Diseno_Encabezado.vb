Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.PowerPacks

Public Class Frm_Formato_Diseno_Encabezado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Private DX, DY As Integer
    Dim ObjetoActivo As Object
    Dim _Nombre_Objeto_Copiado As String

    Dim PosicionX, PosicionY As Integer
    Dim FilaPosicionSeleccionada As Object = XLineaDetalle
    Dim PanelActivo As Control

    Dim TipoDos As String
    Dim NombreFormato As String

    Dim _TipoDoc, _NombreFormato, _Emdp, _Subtido As String
    Dim _Editar_Documento As Boolean
    Dim _Nuevo_Formato As Boolean

    Dim _Row_Documento As DataRow

    Dim _Line_Aj_1, _Line_Aj_2 As Object
    Dim _Alto_Caja, _Ancho_Caja As Integer

    Dim _Empresa
    Dim _Sucursal
    Dim _Bodega

    Dim _Funciones(1000, 4) As String

    Dim Fm_Propiedades As New Frm_Mapa_Diseno_Elementos

    Dim _Row_Formato As DataRow

    Dim _NroLineaXPag As Integer

    Dim _FormPadre As Object

    Dim _Dir_Ruta_Imagenes As String

    Dim _Tbl_Zw_Format_02 As DataTable

    Enum _TipoDiseno
        Documento
        Mapa_Bodega_Crear_Ubicaciones
        Mapa_Bodega_Diseño
        Mapa_Bodega_Asignar_Ubicaciones
        Mapa_Ver_Mapa
    End Enum

    Enum _TipoElemento
        VENTANA
        PUERTA
        MURO
        PILAR
        ESCALERA
        ETIQUETA
        SECTOR
    End Enum

    Enum _Escala
        Uno
        Dos
        Tres
        Cuatro
        Cinco
        Seis
        Siete
        Ocho
        Nueve
        Diez
    End Enum

    Public _Tamano_Escala

    Public Property Pro_NroLineaXPag() As Integer
        Get
            Return _NroLineaXPag
        End Get
        Set(ByVal value As Integer)
            _NroLineaXPag = value
        End Set
    End Property

    Public ReadOnly Property Pro_ObjetoActivo()
        Get
            Return ObjetoActivo
        End Get
    End Property

    Public Property Tbl_Zw_Format_02 As DataTable
        Get
            Return _Tbl_Zw_Format_02
        End Get
        Set(value As DataTable)
            _Tbl_Zw_Format_02 = value
        End Set
    End Property

    Dim _Clas_Formato As New Clas_Formato_De_Documento

    Public Sub New(FormPadre As Object,
                   Row_Formato As DataRow,
                   NuevoDocumento As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Row_Formato = Row_Formato

        _FormPadre = FormPadre
        _TipoDoc = _Row_Formato.Item("TipoDoc")
        _NombreFormato = _Row_Formato.Item("NombreFormato")
        _Emdp = _Row_Formato.Item("Emdp")
        _Subtido = _Row_Formato.Item("Subtido")

        If Not NuevoDocumento Then
            _Editar_Documento = True
        End If

        _Dir_Ruta_Imagenes = AppPath() & "\Data\" & RutEmpresa & "\Temp" '\" & _Nudo & ".xml"

        If Not System.IO.Directory.Exists(_Dir_Ruta_Imagenes) Then
            System.IO.Directory.CreateDirectory(_Dir_Ruta_Imagenes)
        End If

    End Sub

    Private Sub Frm_Formato_Diseno_Encabezado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _TblDocumento As DataTable
        Consulta_Sql = "Select top 1 * From TABTIDO Where TIDO = '" & _TipoDoc & "'"
        _TblDocumento = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If String.IsNullOrEmpty(_Emdp) Then
            Me.Text = Trim(_Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _TipoDoc & "'")) & ", Formato: " & _NombreFormato
        Else
            Me.Text = Trim(_Sql.Fx_Trae_Dato("TABENDP", "NOKOENDP", "KOENDP = '" & _Emdp & "'")) & ", Formato: " & _NombreFormato
        End If

        Dim _Fila_InicioDetalle = _Row_Formato.Item("Fila_InicioDetalle") 'LineaDetalle.Y1
        Dim _Fila_FinDetalle = _Row_Formato.Item("Fila_FinDetalle") 'LineaPie.Y1

        Dim _Carta_Alto = 27.94
        Dim _Carta_Ancho = 21.59

        Documento.Width = _Carta_Ancho * 39.37 '38.5
        Documento.Height = _Carta_Alto * 39.37 '38.5

        XLineaDetalle.Y1 = _Fila_InicioDetalle : XLineaDetalle.Y2 = _Fila_InicioDetalle
        XLineaDetalle.X1 = 1 : XLineaDetalle.X2 = 1000

        XLineaPie.Y1 = _Fila_FinDetalle : XLineaPie.Y2 = _Fila_FinDetalle
        XLineaPie.X1 = 1 : XLineaPie.X2 = 1000


        XLineaDetalle.Y1 = 100 : XLineaDetalle.Y2 = 100
        XLineaDetalle.X1 = 1 : XLineaDetalle.X2 = 1000

        Documento.BackColor = Color.White

        With Me
            .BackColor = Color.White
            .ForeColor = Color.Black
            '.Size = New System.Drawing.Size(1161, 644)
            .MinimumSize = New System.Drawing.Size(700, 0)
            '.StartPosition = FormStartPosition.CenterScreen
        End With


        ' CREAR REGLAS
        Dim _Centimetro As Double
        Dim _Milimetro As Double

        'Regla Ancho
        Fx_Crear_Numero_Regla(0, 20, Regla_X, 0)

        For i = 0 To 30 * 2
            _Centimetro += 38.5
            Fx_Crear_Linea_Regla(2, 40, _Centimetro, Regla_X, True)
            Fx_Crear_Numero_Regla(_Centimetro, 20, Regla_X, i + 1)
        Next

        For i = 0 To 300 * 2
            _Milimetro += 3.85
            Fx_Crear_Linea_Regla(2, 20, _Milimetro, Regla_X, True)
        Next

        'Regla alto
        _Centimetro = 0
        Fx_Crear_Numero_Regla(10, 0, Regla_Y, 0)
        For i = 0 To 30 * 5
            _Centimetro += 38.5 '41.5
            Fx_Crear_Linea_Regla(2, 20, _Centimetro, Regla_Y, False)
            Fx_Crear_Numero_Regla(7, _Centimetro, Regla_Y, i + 1)
        Next

        _Milimetro = 0
        For i = 0 To 300 * 5
            _Milimetro += 4.15
            Fx_Crear_Linea_Regla(2, 5, _Milimetro, Regla_Y, False)
        Next

        If _Editar_Documento Then
            PanelActivo = Documento
            Sb_Abrir_Documento(Documento, _TipoDoc, _NombreFormato, _Subtido)
        End If

        Regla_X.Width = Documento.Width
        Regla_Y.Height = Documento.Height

        AddHandler Btn_Mnu_Txt_Eliminar.Click, AddressOf Sb_Eliminar_Objeto
        AddHandler Btn_Mnu_Caja_Eliminar.Click, AddressOf Sb_Eliminar_Objeto
        AddHandler Btn_Mnu_Imagen_Eliminar.Click, AddressOf Sb_Eliminar_Objeto
        AddHandler Btn_Mnu_Funcion_Eliminar.Click, AddressOf Sb_Eliminar_Objeto

        AddHandler Btn_Copiar_Objeto_Texto_Libre.Click, AddressOf Sb_Copiar_Objeto
        AddHandler Btn_Copiar_Objeto_Box.Click, AddressOf Sb_Copiar_Objeto
        AddHandler Btn_Copiar_Objeto_Imagen.Click, AddressOf Sb_Copiar_Objeto
        AddHandler Btn_Copiar_Objeto_Funcion.Click, AddressOf Sb_Copiar_Objeto

        AddHandler Btn_Posicion_Objeto_Texto_Libre.Click, AddressOf Sb_Editar_Posicion_Manualmente
        AddHandler Btn_Posicion_Objeto_Box.Click, AddressOf Sb_Editar_Posicion_Manualmente
        AddHandler Btn_Posicion_Objeto_Imagen.Click, AddressOf Sb_Editar_Posicion_Manualmente
        AddHandler Btn_Posicion_Objeto_Funcion.Click, AddressOf Sb_Editar_Posicion_Manualmente

        AddHandler Rdb_Formato_01.Click, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Formato_02.Click, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Formato_03.Click, AddressOf Sb_Rdb_Clic

        AddHandler Rdb_Formato_04.Click, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Formato_05.Click, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Formato_06.Click, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Formato_07.Click, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Formato_08.Click, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Formato_09.Click, AddressOf Sb_Rdb_Clic

        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                                         {Me.XLineaPie, Me.XLineaDetalle})


        Control_Fin_Detalle(Nothing, Nothing)


        If Global_Thema = Enum_Themas.Oscuro Then
            Lbl_Lineas_x_Pagina.BackColor = Color.White
            Lbl_Lineas_x_Pagina.ForeColor = Color.Black
        End If

        Try

            Dim _Lineas = ShapeContainer1.Shapes.Count - 1
            Dim _Arr(_Lineas) As String
            Dim _i = 0
            Dim _Con_Lineas = False

            For Each _Ctrl In ShapeContainer1.Shapes
                'Insertamos objetos de diseño, muros, puertas, etc...
                If Mid(_Ctrl.Name, 1, 3) = "Lin" Then
                    _Arr(_i) = _Ctrl.name
                    _i += 1
                    _Con_Lineas = True
                    'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Ctrl.name))
                End If
            Next

            If _Con_Lineas Then

                For _i = 0 To _Lineas
                    Try
                        Me.ShapeContainer1.Shapes.RemoveAt(Me.ShapeContainer1.Shapes.IndexOfKey(_Arr(_i)))
                    Catch ex As Exception

                    End Try

                Next

            End If

            'Me.Refresh()
        Catch ex As Exception
            'Me.Refresh()
        End Try


    End Sub

#Region "PROCEDIMIENTOS"

#Region "DISEÑO DE DOCUMENTOS"

#Region "CREAR OBJETOS PARA DISEÑO DE DOCUMENTOS"

#Region "CREAR TXT"

    Function Fx_Crear_Txt(_Nombre_Objeto As String,
                          _PosicionX As Integer,
                          _PosicionY As Integer,
                          _Texto As String,
                          _Nuevo_Objeto As Boolean)

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
        Dim _VerticalScroll = Panel1.VerticalScroll.Value

        Dim X = _PosicionX
        Dim Y = _PosicionY

        Dim Objeto = PanelActivo

        Dim Contador = 1

        With Objeto

            For Each ctr As Control In .Controls

                Dim Tipo = ctr.Name
                Dim Nom = Mid(Tipo, 1, 3)

                If Nom = "Txt" Then
                    Contador += 1
                End If

            Next

            If Contador = 0 Then Contador = 1

            Dim NewTxt As New Label

            With NewTxt

                .Name = _Nombre_Objeto '"TxtBox" & Contador
                .BorderStyle = BorderStyle.None
                .AutoSize = True

                If String.IsNullOrEmpty(_Texto) Then
                    .Text = "TxtBox" & Contador
                Else
                    .Text = _Texto
                End If

                .BackColor = Color.WhiteSmoke
                .ForeColor = Color.Black
                .Enabled = True

                Dim blankContextMenu = New ContextMenuStrip()
                .ContextMenuStrip = blankContextMenu

                .Location = New System.Drawing.Point(X, Y)
                .Size() = New System.Drawing.Size(200, 20)

                AddHandler .MouseDown, AddressOf Me.Control_MouseDown
                AddHandler .MouseMove, AddressOf Me.Control_MouseMove
                AddHandler .Click, AddressOf Me.Control_Clic
                AddHandler .MouseUp, AddressOf Me.Control_MouseUP
                AddHandler .MouseLeave, AddressOf Me.Control_MouseUP
                AddHandler .DoubleClick, AddressOf Me.Control_Double_Clic

            End With

            Panel1.HorizontalScroll.Value = _HorizontalScroll
            Panel1.VerticalScroll.Value = _VerticalScroll

            PanelActivo.Controls.Add(NewTxt)

            If _Nuevo_Objeto Then

                Dim _Row As DataRow = Fx_Nueva_Linea(NewTxt.Name)
                Sb_Editar_Objeto(NewTxt)

            End If

            Return NewTxt

        End With

    End Function

#End Region

#Region "CREAR FUNIONES"

    Enum Enum_Seccion
        Encabezado
        Detalle
        Pie
    End Enum

    Function Fx_Crear_Funcion(_Nombre_Objeto As String,
                              _PosicionX As Integer,
                              _PosicionY As Integer,
                              _Texto As String,
                              _Nombre_Funcion As String,
                              _TipoDato As String,
                              _Seccion As Enum_Seccion,
                              _Borde_Variable As Boolean,
                              _Orden_Detalle As Integer,
                              _Nuevo_Objeto As Boolean,
                              _Mostrar_En_Concepto As Boolean)

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
        Dim _VerticalScroll = Panel1.VerticalScroll.Value

        Dim _RowFuncion As DataRow

        If String.IsNullOrEmpty(_Nombre_Funcion) Or _Nuevo_Objeto Then

            Dim Fm As New Frm_Formato_Sel_Funciones(_Seccion, _TipoDoc, Frm_Formato_Sel_Funciones._Enum_Accion.Seleccionar)
            Fm.ShowDialog(Me)
            _RowFuncion = Fm.Pro_RowFormato
            Fm.Dispose()

            If (_RowFuncion Is Nothing) Then

                Return Nothing

            Else

                _Texto = _RowFuncion.Item("Formato")
                _Nombre_Funcion = _RowFuncion.Item("Nombre_Funcion")
                _TipoDato = _RowFuncion.Item("Tipo_de_dato")
                _Borde_Variable = _RowFuncion.Item("Borde_Variable")

            End If

        End If

        Dim X = _PosicionX
        Dim Y = _PosicionY

        Dim _Label_funcion As New Label
        Dim Objeto = PanelActivo
        Dim _NewLbl As New Label 'TextBox()

        _Label_funcion.Name = _Nombre_Objeto '"LblFx" & Contador
        _Label_funcion.BackColor = Color.Khaki
        _Label_funcion.ForeColor = Color.Black

        If _Borde_Variable Then
            _Label_funcion.AutoSize = False
            _Label_funcion.BorderStyle = BorderStyle.FixedSingle
        Else
            _Label_funcion.BorderStyle = BorderStyle.None
            _Label_funcion.AutoSize = True
        End If

        If _Texto = "" Then
            _Label_funcion.Text = _Nombre_Objeto '"Lbl_Fx" & Contador
        Else
            _Label_funcion.Text = _Texto
        End If

        Dim blankContextMenu = New ContextMenuStrip()

        _Label_funcion.ContextMenuStrip = blankContextMenu
        _Label_funcion.Location = New System.Drawing.Point(X, Y)

        Me.ToolTip1.SetToolTip(_Label_funcion, "Función: " & UCase(_Nombre_Funcion))

        AddHandler _Label_funcion.MouseDown, AddressOf Me.Control_MouseDown
        AddHandler _Label_funcion.MouseMove, AddressOf Me.Control_MouseMove
        AddHandler _Label_funcion.Click, AddressOf Me.Control_Clic
        AddHandler _Label_funcion.MouseUp, AddressOf Me.Control_MouseUP
        AddHandler _Label_funcion.MouseLeave, AddressOf Me.Control_MouseUP
        AddHandler _Label_funcion.DoubleClick, AddressOf Me.Control_Double_Clic

        If _Nuevo_Objeto Then

            Dim _Row As DataRow = Fx_Nueva_Linea(_Label_funcion.Name)

            _Row.Item("Funcion") = _Nombre_Funcion
            _Row.Item("TipoDato") = _TipoDato
            _Row.Item("Borde_Variable") = _Borde_Variable
            _Row.Item("Orden_Detalle") = _Orden_Detalle
            _Row.Item("Mostrar_En_Concepto") = _Mostrar_En_Concepto

            Sb_Editar_Objeto(_Label_funcion)

        End If

        PanelActivo.Controls.Add(_Label_funcion)
        Panel1.HorizontalScroll.Value = _HorizontalScroll
        Panel1.VerticalScroll.Value = _VerticalScroll

        Return _Label_funcion

    End Function

    Function Fx_Existe_Nombre_Ctrl(ByRef _Nombre_Ctrl As String) As Boolean

        Dim _Existe = True

        Do While _Existe

            For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

                Dim _Name = _Fila.Item("Name")
                If _Nombre_Ctrl = _Name Then
                    _Existe = True
                End If

            Next

            If _Existe Then
                '_Nombre_Ctrl
            End If

        Loop


    End Function

    Function Fx_Nueva_Linea(_Name As String) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl_Zw_Format_02.NewRow
        With NewFila

            .Item("Name") = _Name
            .Item("Contador") = _Tbl_Zw_Format_02.Rows.Count + 1
            .Item("Mostrar_En_Concepto") = False
            ''.Item("NombreObjeto") = _Seccion
            ''.Item("Seccion") = _Seccion
            '.Item("TipoDato") = _TipoDato
            '.Item("Funcion") = _Funcion
            ''.Item("Formato") = _Formato
            ''.Item("CantDecimales") = _CantDecimales
            ''.Item("Fuente") = _Fuente
            ''.Item("Tamano") = _Tamano
            ''.Item("Alto") = _Alto
            ''.Item("Ancho") = _Ancho
            ''.Item("Estilo") = _Estilo
            ''.Item("Color") = _Color
            ''.Item("Fila_Y") = _Y
            ''.Item("Columna_X") = _Columna_X
            ''.Item("Texto") = _Texto
            ''.Item("RutaImagen") = _RutaImagen
            '.Item("Borde_Variable") = _Borde_Variable
            '.Item("Orden_Detalle") = _Orden_Detalle

            _Tbl_Zw_Format_02.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

#End Region

#Region "CREAR IMAGEN"

    Function Fx_Crear_Imagen(_Nombre_Objeto As String,
                             _PosicionX As Integer,
                             _PosicionY As Integer,
                             _RutaImagen As String,
                             _Nuevo_Objeto As Boolean)

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
        Dim _VerticalScroll = Panel1.VerticalScroll.Value

        Dim X = _PosicionX
        Dim Y = _PosicionY

        Dim PicBox As New PictureBox

        Dim Objeto = PanelActivo
        'Dim Contador = 0

        With Objeto '.Controls

            ''For Each ctr As Control In .Controls
            ''    Dim Tipo = PanelActivo.Name 'CType(ctr, Control).Name
            ''    If Mid(Tipo, 1, 3) = "Pic" Then
            ''        Contador += 1
            ''    End If
            ''Next

            'If Contador = 0 Then Contador = 1

            With PicBox

                .Name = _Nombre_Objeto '"PictBox" & Contador
                '.BorderStyle = BorderStyle.FixedSingle
                .BorderStyle = BorderStyle.None
                .BackColor = Color.WhiteSmoke
                .SizeMode = PictureBoxSizeMode.StretchImage
                .Location = New System.Drawing.Point(X, Y)
                .Size() = New System.Drawing.Size(97, 63)
                .ImageLocation = _RutaImagen

                AddHandler .MouseDown, AddressOf Me.Control_MouseDown
                AddHandler .MouseMove, AddressOf Me.Control_MouseMove
                AddHandler .Click, AddressOf Me.Control_Clic

            End With

            PanelActivo.Controls.Add(PicBox)

            Panel1.HorizontalScroll.Value = _HorizontalScroll
            Panel1.VerticalScroll.Value = _VerticalScroll

            If _Nuevo_Objeto Then

                Dim _Row As DataRow = Fx_Nueva_Linea(PicBox.Name)
                Sb_Editar_Objeto(PicBox)

            End If

            Return PicBox

        End With

    End Function
#End Region

#Region "CREAR CAJA"

    Function Fx_Crear_Caja(_Nombre_Objeto As String,
                           _PosicionX As Integer,
                           _PosicionY As Integer,
                           _Nuevo_Objeto As Boolean)

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
        Dim _VerticalScroll = Panel1.VerticalScroll.Value

        Dim _Caja As New RectangleShape

        Dim Objeto = PanelActivo
        'Dim Contador = 0

        With Objeto

            'For Each ctr In ShapeContainer1.Shapes

            '    Dim Tipo = ctr.Name
            '    Dim Nom = Mid(Tipo, 1, 3)

            '    If Mid(Tipo, 1, 3) = "Box" Then
            '        Contador += 1
            '    End If

            'Next

            'If Contador = 0 Then Contador = 1

            _Caja.Name = _Nombre_Objeto '"BoxRec" & Contador

            _Caja.Location = New System.Drawing.Point(_PosicionX, _PosicionY)
            _Caja.Size() = New System.Drawing.Size(30, 30)

            Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                                       {_Caja, Me.XLineaPie, Me.XLineaDetalle})

            AddHandler _Caja.MouseDown, AddressOf Me.Control_MouseDown
            AddHandler _Caja.MouseMove, AddressOf Me.Control_MouseMove
            AddHandler _Caja.Click, AddressOf Me.Control_Clic

            _Caja.BringToFront()

            If _Nuevo_Objeto Then

                Dim _Row As DataRow = Fx_Nueva_Linea(_Caja.Name)
                Sb_Editar_Objeto(_Caja)

            End If

            Panel1.HorizontalScroll.Value = _HorizontalScroll
            Panel1.VerticalScroll.Value = _VerticalScroll

            Return _Caja

        End With

    End Function

#End Region

#Region "CREAR LINEA"

    Function Fx_Crear_Linea(ByVal _PosicionX As Integer,
                            ByVal _PosicionXX As Integer,
                            ByVal _PosicionY As Integer,
                            Optional ByVal _Menu As Boolean = True,
                            Optional ByVal _Vertical As Boolean = False)

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
        Dim _VerticalScroll = Panel1.VerticalScroll.Value


        'Dim GruBox As  New GroupBox
        Dim _Linea As New LineShape

        '_Rectangulo.Location = New System.Drawing.Point(2, 2)
        '_Rectangulo.Name = "RectangleShape1"
        '_Rectangulo.Size = New System.Drawing.Size(600, 800)


        Dim Contador = 0

        With Documento '.Controls

            For Each ctr As Control In .Controls
                Dim Tipo = .Name 'CType(ctr, Control).Name
                If Mid(Tipo, 1, 3) = "Lin" Then
                    Contador += 1
                End If
            Next
            If Contador = 0 Then Contador = 1

            With _Linea

                .Name = "Linea" & Contador
                '.Text = ""

                .Y1 = _PosicionY
                .Y2 = _PosicionY

                .X1 = _PosicionX
                .X2 = .X1 + _PosicionXX

                If _Menu Then

                    '.ContextMenuStrip = ContextMenuStrip1
                    .BorderColor = System.Drawing.Color.Black

                Else

                    If _Vertical Then
                        .Y1 = 0
                        .Y2 = Documento.Height

                        .X1 = _PosicionX
                        .X2 = _PosicionX
                    End If

                    .BorderColor = System.Drawing.Color.Purple
                    .BorderStyle = Drawing2D.DashStyle.Dash

                End If


                'Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                '                           {_Linea, Me.LineaPie, Me.LineaDetalle})

                CType(_Linea, LineShape).BringToFront()

                Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                                          {_Linea})

                'Me.ShapeContainer1.Shapes.Remove(_Caja)

                AddHandler .MouseDown, AddressOf Me.Control_MouseDown
                'AddHandler .MouseMove, AddressOf Me.Control_MouseMove
                AddHandler .Click, AddressOf Me.Control_Clic
                'AddHandler .MouseLeave, AddressOf Me.Control_MouseLeave

            End With

            Panel1.HorizontalScroll.Value = _HorizontalScroll
            Panel1.VerticalScroll.Value = _VerticalScroll
            'PanelActivo.Controls.Add(_Caja)
            Return _Linea
        End With
    End Function
#End Region

#End Region

#Region "ABRIR DOCUMENTO"

    Function Sb_Abrir_Documento(_PanelAct As Control,
                                _TipoDoc As String,
                                _NombreFormato As String,
                                _Subtido As String)

        ShapeContainer1.Shapes.Clear()

        Dim Xx, Yy As Integer

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "' And Subtido = '" & _Subtido & "'"
        Dim TblEncForm = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If TblEncForm.Rows.Count > 0 Then

            Dim FilaEnc = TblEncForm.Rows(0)

            Dim _LargoDoc As Double = FilaEnc.Item("LargoDoc")
            Dim _AnchoDoc As Double = FilaEnc.Item("AnchoDoc")

            _NroLineaXPag = FilaEnc.Item("NrolineasXpag")

            Dim _Fila_InicioDetalle = FilaEnc.Item("Fila_InicioDetalle")
            Dim _Fila_FinDetalle = FilaEnc.Item("Fila_FinDetalle")
            Dim _Col_InicioDetalle = FilaEnc.Item("Col_InicioDetalle")
            Dim _Col_FinDetalle = FilaEnc.Item("Col_FinDetalle")
            Dim _Largo_Variable As Boolean = FilaEnc.Item("Largo_Variable")
            Dim _Es_Picking As Boolean = FilaEnc.Item("Es_Picking")
            Dim _Agrupar_CodDescripcion As Boolean = FilaEnc.Item("Agrupar_CodDescripcion")
            Dim _IncluyePickWms As Boolean = FilaEnc.Item("IncluyePickWms")
            Dim _ImprimirDocAdjuntos As Boolean = FilaEnc.Item("ImprimirDocAdjuntos")

            Dim _Copias As Integer = FilaEnc.Item("Copias")

            Dim _Detalle_Doc_Incluye As String = FilaEnc.Item("Detalle_Doc_Incluye")

            Select Case _Detalle_Doc_Incluye
                Case "SP", ""
                    CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_SP_Prod.Checked = True
                Case "TD"
                    CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_TD_Prod_Desc_Reca.Checked = True
                Case "PD"
                    CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_PD_Prod_Desc.Checked = True
                Case "PR"
                    CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_PR_Prod_Reca.Checked = True
                Case "SP2"
                    CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_SP2_Prod.Checked = True
            End Select


            'Dim _Doc_AnchoDoc As Integer = Math.Round(FilaEnc.Item("AnchoDoc"), 2) * 39 '38.5
            'Dim _Doc_LargoDoc As Integer = Math.Round(FilaEnc.Item("LargoDoc"), 2) * 42 '41.5

            Documento.Width = _AnchoDoc * 39.37 '38.5
            Documento.Height = _LargoDoc * 39.37 '38.5 '41 '41.5

            'Dim _Carta_Alto = 27.94
            'Dim _Carta_Ancho = 21.59

            'Documento.Width = _Carta_Ancho * 38.5
            'Documento.Height = _Carta_Alto * 38.5


            _FormPadre.Sld_Tam_Alto.Maximum = Documento.Height
            _FormPadre.Sld_Tam_Ancho.Maximum = Documento.Width

            _FormPadre.Sld_Ubicacion_Y.Maximum = Documento.Height
            _FormPadre.Sld_Ubicacion_X.Maximum = Documento.Width


            XLineaDetalle.Y1 = _Fila_InicioDetalle
            XLineaDetalle.Y2 = _Fila_InicioDetalle

            XLineaPie.Y1 = _Fila_FinDetalle
            XLineaPie.Y2 = _Fila_FinDetalle

            _FormPadre.Sld_detalle_Inicio.Value = XLineaDetalle.Y1
            _FormPadre.Sld_detalle_Fin.Value = XLineaPie.Y1

            _FormPadre.Sld_detalle_Inicio.Maximum = XLineaPie.Y1 - 5
            _FormPadre.Sld_detalle_Fin.Minimum = XLineaDetalle.Y1 + 5
            _FormPadre.Sld_detalle_Fin.Maximum = Documento.Height - 5

            _FormPadre.Sld_detalle_Inicio.Value = XLineaDetalle.Y1
            _FormPadre.Sld_detalle_Fin.Value = XLineaPie.Y1


            'Handles Chk_Largo_Variable.CheckedChanged

            CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_Largo_Variable.Checked = _Largo_Variable
            CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_Es_Picking.Checked = _Es_Picking
            CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_Agrupar_CodDescripcion.Checked = _Agrupar_CodDescripcion
            CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_IncluyePickWms.Checked = _IncluyePickWms
            CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_ImprimirDocAdjuntos.Checked = _ImprimirDocAdjuntos


            _FormPadre.Input_Max_Lienas.Enabled = _Largo_Variable
            _FormPadre.Input_Max_Lienas.value = _NroLineaXPag
            _FormPadre.Input_Copias.value = _Copias

            AddHandler CType(_FormPadre.Sld_detalle_Inicio, SliderItem).ValueChanged, AddressOf Control_Inicio_Detalle
            AddHandler CType(_FormPadre.Sld_detalle_Fin, SliderItem).ValueChanged, AddressOf Control_Fin_Detalle

            AddHandler CType(_FormPadre.Chk_Largo_Variable, CheckBoxItem).CheckedChanged, AddressOf Control_Chk_Largo_Variable_CheckedChanged


            Consulta_Sql = "Select Cast('' As Varchar(30)) As Name,Cast(0 As Bit) As Eliminado,Cast(0 As Int) As Contador,*" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' And NombreFormato = '" & _NombreFormato & "' And Subtido = '" & _Subtido & "'" & vbCrLf &
                           "Order by Funcion"
            _Tbl_Zw_Format_02 = _Sql.Fx_Get_DataTable(Consulta_Sql)

            Dim _Contador = 1

            For Each Fila As DataRow In _Tbl_Zw_Format_02.Rows 'TblForm.Rows

                Dim _NombreObjeto = Fila.Item("NombreObjeto")
                Dim _Seccion = Fila.Item("Seccion")
                Dim _TipoDato = Fila.Item("TipoDato")
                Dim _Funcion = Fila.Item("Funcion")
                Dim _Formato = Fila.Item("Formato")

                Dim _Alto = Fila.Item("Alto")
                Dim _Ancho = Fila.Item("Ancho")

                Dim _CantDecimales = Fila.Item("CantDecimales")
                Dim _Texto = Fila.Item("Texto")
                Dim _RutaImagen = Fila.Item("RutaImagen")

                Dim _Fila_Y = Fila.Item("Fila_Y")
                Dim _Columna_X = Fila.Item("Columna_X")

                Dim _Borde_Variable As Boolean = Fila.Item("Borde_Variable")

                Dim _Fuente As String
                Dim _Tamano As Single

                Dim _Estilo As FontStyle
                Dim _NroColor As String

                Dim _Orden_Detalle = Fila.Item("Orden_Detalle")
                Dim _Mostrar_En_Concepto = Fila.Item("Mostrar_En_Concepto")

                If _NombreObjeto = "Texto_libre" Then

                    Dim _Nombre_Objeto = "TxtBox" & _Contador
                    Dim Objeto = Fx_Crear_Txt(_Nombre_Objeto, _Columna_X, _Fila_Y, _Texto, False)

                    _Fuente = Fila.Item("Fuente")
                    _Tamano = Fila.Item("Tamano")
                    _Estilo = Fila.Item("Estilo")

                    Xx = _Columna_X
                    Yy = _Fila_Y

                    Objeto.Font = New System.Drawing.Font(_Fuente, _Tamano, _Estilo)

                    _NroColor = Fila.Item("Color")
                    Objeto.ForeColor = Color.FromArgb(_NroColor) 'Color

                    Dim exitLocation As New System.Drawing.Point(Xx, Yy)
                    Objeto.Location = exitLocation

                    Objeto.Size() = New System.Drawing.Size(_Ancho, _Alto)
                    CType(Objeto, Label).BringToFront()

                    Fila.Item("Name") = CType(Objeto, Label).Name

                ElseIf _NombreObjeto = "Funcion" Then

                    Dim _Nombre_Objeto = "LblFx" & _Contador
                    Dim Objeto = Fx_Crear_Funcion(_Nombre_Objeto, _Columna_X, _Fila_Y, _Texto, _Funcion,
                                                  _TipoDato, Enum_Seccion.Encabezado, _Borde_Variable, _Orden_Detalle, False, _Mostrar_En_Concepto)

                    _Fuente = Fila.Item("Fuente")
                    _Tamano = Fila.Item("Tamano")
                    _Estilo = Fila.Item("Estilo")

                    Xx = _Columna_X
                    Yy = _Fila_Y

                    Objeto.Font = New System.Drawing.Font(_Fuente, _Tamano, _Estilo)
                    CType(Objeto, Label).BringToFront()

                    _NroColor = Fila.Item("Color")
                    Objeto.ForeColor = Color.FromArgb(_NroColor) 'Color

                    Dim exitLocation As New System.Drawing.Point(Xx, Yy)
                    Objeto.Location = exitLocation

                    Objeto.Size() = New System.Drawing.Size(_Ancho, _Alto)
                    Fila.Item("Name") = CType(Objeto, Label).Name

                ElseIf _NombreObjeto = "Imagen" Then

                    Dim _Nombre_Objeto = "PictBox" & _Contador
                    Dim Objeto = Fx_Crear_Imagen(_Nombre_Objeto, PosicionX, PosicionY, _RutaImagen, False)
                    Xx = _Columna_X
                    Yy = _Fila_Y

                    Dim exitLocation As New System.Drawing.Point(Xx, Yy)
                    Objeto.Location = exitLocation

                    Objeto.Size() = New System.Drawing.Size(_Ancho, _Alto)

                    CType(Objeto, PictureBox).BringToFront()
                    Fila.Item("Name") = CType(Objeto, PictureBox).Name

                ElseIf _NombreObjeto = "Caja" Then

                    _Tamano = Fila.Item("Tamano")

                    Dim _Nombre_Objeto = "BoxRec" & _Contador
                    Dim Objeto = Fx_Crear_Caja(_Nombre_Objeto, _Columna_X, _Fila_Y, False)
                    Xx = _Columna_X
                    Yy = _Fila_Y

                    If Fila.Item("Estilo") = 1 Then
                        CType(Objeto, RectangleShape).CornerRadius = 15
                    Else
                        CType(Objeto, RectangleShape).CornerRadius = 0
                    End If

                    _NroColor = Fila.Item("Color")
                    CType(Objeto, RectangleShape).BorderColor = Color.FromArgb(_NroColor)
                    CType(Objeto, RectangleShape).BorderWidth = _Tamano

                    CType(Objeto, RectangleShape).Location = New System.Drawing.Point(Xx, Yy)
                    CType(Objeto, RectangleShape).Size = New System.Drawing.Size(_Ancho, _Alto)
                    Fila.Item("Name") = CType(Objeto, RectangleShape).Name

                ElseIf _NombreObjeto = "Linea" Then

                    _Tamano = Fila.Item("Tamano")

                    Dim Objeto = Fx_Crear_Linea(_Columna_X, _Ancho, _Fila_Y)

                    _NroColor = Fila.Item("Color")
                    CType(Objeto, LineShape).BorderColor = Color.FromArgb(_NroColor)
                    CType(Objeto, LineShape).BorderWidth = _Tamano
                    Fila.Item("Name") = CType(Objeto, LineShape).Name

                End If

                Fila.Item("Contador") = _Contador
                _Contador += 1

            Next

        Else
            MsgBox("Documento no existe")
        End If
        Me.Refresh()

    End Function

#End Region

#Region "GRABAR DOCUMENTO"

    Public Function Sb_Grabar_Movimientos()

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
        Dim _VerticalScroll = Panel1.VerticalScroll.Value

        If _Nuevo_Formato Then

            _NombreFormato = InputBox_Bk(Me, "Ingrese el nombre del formato...", "Crear formato", "",
                                         False, _Tipo_Mayus_Minus.Mayusculas)

            If String.IsNullOrEmpty(Trim(_NombreFormato)) Then
                MessageBoxEx.Show(_FormPadre, "Falta nombre del formato", "No se realiza grabación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

        End If

        Dim Sql1 = String.Empty
        Dim Sql2 = String.Empty
        Dim _SQl_Query = String.Empty

        For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

            Dim _Eliminado As Boolean = NuloPorNro(_Fila.Item("Eliminado"), True)

            If Not _Eliminado Then

                Dim _TipoDoc = _Fila.Item("TipoDoc")
                Dim _NombreFormato = _Fila.Item("NombreFormato")
                Dim _NombreObjeto = _Fila.Item("NombreObjeto")
                Dim _Seccion = _Fila.Item("Seccion")
                Dim _TipoDato = _Fila.Item("TipoDato")
                Dim _Funcion = _Fila.Item("Funcion")
                Dim _Formato = _Fila.Item("Formato")
                Dim _CantDecimales = _Fila.Item("CantDecimales")
                Dim _Fuente = _Fila.Item("Fuente")
                Dim _Tamano = _Fila.Item("Tamano")
                Dim _Alto = _Fila.Item("Alto")
                Dim _Ancho = _Fila.Item("Ancho")
                Dim _Estilo = _Fila.Item("Estilo")
                Dim _Color = _Fila.Item("Color")
                Dim _Fila_Y = _Fila.Item("Fila_Y")
                Dim _Columna_X = _Fila.Item("Columna_X")
                Dim _Texto = _Fila.Item("Texto")
                Dim _RutaImagen = _Fila.Item("RutaImagen")
                Dim _Imagen = _Fila.Item("Imagen")
                Dim _Borde_Variable = Convert.ToInt32(_Fila.Item("Borde_Variable"))
                Dim _Orden_Detalle = _Fila.Item("Orden_Detalle")
                Dim _Emdp = _Fila.Item("Emdp")
                Dim _Mostrar_En_Concepto = Convert.ToInt32(_Fila.Item("Mostrar_En_Concepto"))

                _SQl_Query += "Insert Into " & _Global_BaseBk & "Zw_Format_02 (TipoDoc,NombreFormato,NombreObjeto,Seccion,TipoDato,Funcion," & vbCrLf &
                              "Formato,CantDecimales,Fuente,Tamano,Alto,Ancho,Estilo,Color,Fila_Y,Columna_X,Texto,RutaImagen,Borde_Variable,Orden_Detalle,Emdp,Mostrar_En_Concepto,Subtido) Values" & vbCrLf &
                              "('" & _TipoDoc & "','" & _NombreFormato & "','" & _NombreObjeto & "','" & _Seccion & "'," & vbCrLf &
                              "'" & _TipoDato & "','" & _Funcion & "','" & _Formato & "'," & _CantDecimales & "," & vbCrLf &
                              "'" & _Fuente & "'," & De_Num_a_Tx_01(_Tamano, , 5) &
                              "," & De_Num_a_Tx_01(_Alto, , 5) & "," & De_Num_a_Tx_01(_Ancho, , 5) & "," & _Estilo & "," & _Color & "," & _Fila_Y & "," & vbCrLf &
                              _Columna_X & ",'" & _Texto & "','" & _RutaImagen & "'," & _Borde_Variable & "," & _Orden_Detalle & ",'" & _Emdp & "'," & _Mostrar_En_Concepto & ",'" & _Subtido & "')" & vbCrLf & vbCrLf

            End If

        Next

        Dim _Fila_InicioDetalle As Integer
        Dim _Fila_FinDetalle As Integer
        Dim _Copias As Integer

        'LineaPie.Y1 = 800 : LineaPie.Y2 = 800
        'LineaPie.X1 = 1 : LineaPie.X2 = 1000

        _Fila_InicioDetalle = XLineaDetalle.Y1
        _Fila_FinDetalle = XLineaPie.Y1

        'LineaDetalle.Y1 = 100 : LineaDetalle.Y2 = 100
        'LineaDetalle.X1 = 1 : LineaDetalle.X2 = 1000

        Dim _Largo_Variable As Integer = CInt(CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_Largo_Variable.Checked) * -1
        Dim _Es_Picking As Integer = CInt(CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_Es_Picking.Checked) * -1
        Dim _Agrupar_CodDescripcion As Integer = CInt(CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_Agrupar_CodDescripcion.Checked) * -1
        Dim _IncluyePickWms As Integer = Convert.ToInt32(CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_IncluyePickWms.Checked)
        Dim _ImprimirDocAdjuntos As Integer = Convert.ToInt32(CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Chk_ImprimirDocAdjuntos.Checked)

        _NroLineaXPag = _FormPadre.Input_Max_Lienas.value
        _Copias = _FormPadre.Input_Copias.value

        Dim _Detalle_Doc_Incluye As String

        If CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_SP_Prod.Checked Then _
            _Detalle_Doc_Incluye = CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_SP_Prod.Tag

        If CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_PD_Prod_Desc.Checked Then _
            _Detalle_Doc_Incluye = CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_PD_Prod_Desc.Tag

        If CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_TD_Prod_Desc_Reca.Checked Then _
            _Detalle_Doc_Incluye = CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_TD_Prod_Desc_Reca.Tag

        If CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_PR_Prod_Reca.Checked Then _
            _Detalle_Doc_Incluye = CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_PR_Prod_Reca.Tag

        If CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_SP2_Prod.Checked Then _
            _Detalle_Doc_Incluye = CType(_FormPadre, Frm_ImpresionDoc_Configuracion).Rdb_SP2_Prod.Tag

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Format_01 Set" & Space(1) &
                       "Fila_InicioDetalle = " & _Fila_InicioDetalle & vbCrLf &
                       ",Fila_FinDetalle = " & _Fila_FinDetalle & vbCrLf &
                       ",NroLineasXpag = " & _NroLineaXPag & vbCrLf &
                       ",Largo_Variable = " & _Largo_Variable & vbCrLf &
                       ",Copias = " & _Copias & vbCrLf &
                       ",Es_Picking = " & _Es_Picking & vbCrLf &
                       ",Agrupar_CodDescripcion = " & _Agrupar_CodDescripcion & vbCrLf &
                       ",Detalle_Doc_Incluye = '" & _Detalle_Doc_Incluye & "'" & vbCrLf &
                       ",IncluyePickWms = '" & _IncluyePickWms & "'" & vbCrLf &
                       ",ImprimirDocAdjuntos = " & _ImprimirDocAdjuntos & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And NombreFormato = '" & _NombreFormato & "' And Subtido = '" & _Subtido & "'" & vbCrLf & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And NombreFormato = '" & _NombreFormato & "' And Subtido = '" & _Subtido & "'" & vbCrLf & vbCrLf &
                       _SQl_Query

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Format_02 Set Seccion = 'E'" & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' And " &
                           "NombreFormato = '" & _NombreFormato & "' And " &
                           "Subtido = '" & _Subtido & "' And " &
                           "NombreObjeto = 'Caja' And " &
                           "Seccion = 'D'"
            _Sql.Ej_consulta_IDU(Consulta_Sql)

            If CBool(_Largo_Variable) Then

                If CBool(_NroLineaXPag) Then
                    MessageBoxEx.Show(Me, "El largo del documento es variable, " &
                                      "pero el máximo de líneas por página será de: " & _NroLineaXPag, "Número de líneas por página",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

            MessageBoxEx.Show(Me, "Datos guardados correctamente", "Guardar", MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
            _Nuevo_Formato = False

        Else

            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Panel1.HorizontalScroll.Value = _HorizontalScroll
        Panel1.VerticalScroll.Value = _VerticalScroll

    End Function


    Function Fx_Crear_Z_Crear_Formato(ByVal Ctrl As Object,
                               ByVal _Tipo_Doc As String,
                               ByVal _Nombre_Formato As String,
                               ByVal _Emdp As String) As String

        Dim SQl_Query = String.Empty
        Dim _Nombre_Etiqueta = Ctrl.Name


        Dim NombreObjeto = ""
        Dim Seccion = ""
        Dim TipoDato
        Dim Funcion
        Dim Formato
        Dim CantDecimales
        Dim Texto
        Dim RutaImagen
        Dim Alto
        Dim Ancho
        Dim Borde_Variable As Integer = 0
        Dim Orden_Detalle As Integer = 0

        Dim Tipo = Mid(_Nombre_Etiqueta, 1, 3)

        If Tipo = "Txt" Then

            NombreObjeto = "Texto_libre"
            TipoDato = "C"
            Funcion = String.Empty
            RutaImagen = String.Empty
            Formato = "CA"
            Texto = Ctrl.Text
            CantDecimales = 0

        ElseIf Tipo = "Lbl" Then

            NombreObjeto = "Funcion"
            TipoDato = "C"
            Funcion = String.Empty

            If Mid(_Nombre_Etiqueta, 1, 5) = "LblFx" Then

                For _i = 0 To 500

                    Dim _Dato = _Funciones(_i, 0)

                    If _Funciones(_i, 0) = "#Fin#" Then
                        Exit For
                    ElseIf _Funciones(_i, 0) = _Nombre_Etiqueta Then
                        Funcion = _Funciones(_i, 1)
                        TipoDato = _Funciones(_i, 2)
                        Borde_Variable = _Funciones(_i, 3)
                        Orden_Detalle = _Funciones(_i, 4)
                        Exit For
                    End If

                Next

            End If

            RutaImagen = String.Empty
            Formato = "CA"
            Texto = Ctrl.Text
            CantDecimales = 0

            If String.IsNullOrEmpty(Funcion) Then
                Return Funcion
            End If

        ElseIf Tipo = "Pic" Then

            NombreObjeto = "Imagen"
            TipoDato = "I"
            Funcion = Ctrl.Text

            Try
                RutaImagen = CType(Ctrl, PictureBox).ImageLocation.ToString
                Dim _Archivo = Split(RutaImagen, "\")

                Dim _II = _Archivo.Length
                Texto = _Archivo(_II - 1)

            Catch ex As Exception
                RutaImagen = String.Empty
                Texto = String.Empty
            End Try

            Formato = "IM"

            CantDecimales = 0

        ElseIf Tipo = "Box" Then

            NombreObjeto = "Caja"
            TipoDato = "B"
            Funcion = String.Empty
            RutaImagen = String.Empty 'CType(Ctrl, PictureBox).ImageLocation.ToString
            Formato = "BX"
            Texto = String.Empty
            CantDecimales = 0

        ElseIf Tipo = "Lin" Then

            NombreObjeto = "Linea"
            TipoDato = "L"
            Funcion = String.Empty
            RutaImagen = String.Empty 'CType(Ctrl, PictureBox).ImageLocation.ToString
            Formato = "LN"
            Texto = String.Empty
            CantDecimales = 0

        Else
            Return SQl_Query
        End If

        Dim Columna_X As Integer
        Dim Fila_Y As Integer

        Dim Fuente As String
        Dim Tamano As Single
        Dim Estilo As String
        Dim Color ' = CType(Ctrl, Control).ForeColor.ToArgb

        If Tipo <> "Box" And Tipo <> "Lin" Then

            Columna_X = CType(Ctrl, Control).Location.X.ToString
            Fila_Y = CType(Ctrl, Control).Location.Y.ToString

            Alto = CType(Ctrl, Control).Height
            Ancho = CType(Ctrl, Control).Width

            Fuente = CType(Ctrl, Control).Font.Name
            Tamano = CType(Ctrl, Control).Font.Size
            Estilo = CType(Ctrl, Control).Font.Style
            Color = CType(Ctrl, Control).ForeColor.ToArgb

        ElseIf Tipo = "Box" Then

            Dim _Locacion = CType(Ctrl, RectangleShape).Location
            Columna_X = _Locacion.X
            Fila_Y = _Locacion.Y

            Dim _Size = CType(Ctrl, RectangleShape).Size
            Alto = _Size.Height
            Ancho = _Size.Width

            Fuente = String.Empty
            Tamano = CType(Ctrl, RectangleShape).BorderWidth

            If CBool(CType(Ctrl, RectangleShape).CornerRadius) Then
                Estilo = 1
            Else
                Estilo = 0
            End If

            Color = CType(Ctrl, RectangleShape).BorderColor.ToArgb

        ElseIf Tipo = "Lin" Then

            Dim _Locacion = CType(Ctrl, LineShape).X1

            Dim _X1 = CType(Ctrl, LineShape).X1
            Dim _X2 = CType(Ctrl, LineShape).X2

            Dim _Y1 = CType(Ctrl, LineShape).Y1
            Dim _Y2 = CType(Ctrl, LineShape).Y2

            Columna_X = _X1 '_Locacion.X

            Fila_Y = _Y1

            Alto = CType(Ctrl, LineShape).BorderWidth
            Ancho = _X2 - _X1

            Fuente = String.Empty
            Tamano = CType(Ctrl, LineShape).BorderWidth

            Estilo = 0
            Color = CType(Ctrl, LineShape).BorderColor.ToArgb

        End If


        If Fila_Y < XLineaDetalle.Y1 Then 'Encabezado
            Seccion = "E"
        ElseIf Fila_Y < XLineaPie.Y1 Then 'Detalle
            Seccion = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Format_Fx", "Seccion", "Nombre_Funcion = '" & Funcion & "'")
            If String.IsNullOrEmpty(Seccion) Then
                Seccion = "D"
                Orden_Detalle = 1
            End If
        Else
            Seccion = "P" 'Pie
        End If

        Dim _Alto_Doc = Documento.Height


        If Fila_Y <= _Alto_Doc Then

            SQl_Query = "Insert Into " & _Global_BaseBk & "Zw_Format_02 (TipoDoc,NombreFormato,NombreObjeto,Seccion,TipoDato,Funcion," & vbCrLf &
                        "Formato,CantDecimales,Fuente,Tamano,Alto,Ancho,Estilo,Color,Fila_Y,Columna_X,Texto,RutaImagen,Borde_Variable,Orden_Detalle,Emdp) Values" & vbCrLf &
                        "('" & _Tipo_Doc & "','" & _Nombre_Formato & "','" & NombreObjeto & "','" & Seccion & "'," & vbCrLf &
                        "'" & TipoDato & "','" & Funcion & "','" & Formato & "'," & CantDecimales & "," & vbCrLf &
                        "'" & Fuente & "'," & De_Num_a_Tx_01(Tamano, , 5) &
                        "," & De_Num_a_Tx_01(Alto, , 5) & "," & De_Num_a_Tx_01(Ancho, , 5) & "," & Estilo & "," & Color & "," & Fila_Y & "," & vbCrLf &
                        Columna_X & ",'" & Texto & "','" & RutaImagen & "'," & Borde_Variable & "," & Orden_Detalle & ",'" & _Emdp & "')" & vbCrLf & vbCrLf
        Else
            SQl_Query = String.Empty
        End If

        Return SQl_Query

    End Function

#End Region

#Region "SUBIR Y BAJAR LINEA DE DETALLE"

    Private Sub Control_Inicio_Detalle(ByVal sender As System.Object, ByVal e As System.EventArgs)

        XLineaDetalle.Y1 = _FormPadre.Sld_detalle_Inicio.Value 'LineaDetalle.Y1 - 1
        XLineaDetalle.Y2 = _FormPadre.Sld_detalle_Inicio.Value 'LineaDetalle.Y2 - 1

        _FormPadre.Sld_detalle_Inicio.Maximum = XLineaPie.Y1 - 5
        _FormPadre.Sld_detalle_Fin.Minimum = XLineaDetalle.Y1 + 5

        sender.Tooltip = sender.value

    End Sub

    Private Sub Control_Fin_Detalle(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Y1 = CType(XLineaPie, LineShape).Y1
        Dim _Y2 = CType(XLineaPie, LineShape).Y2

        XLineaPie.Y1 = _FormPadre.Sld_detalle_Fin.Value 'LineaDetalle.Y1 - 1
        XLineaPie.Y2 = _FormPadre.Sld_detalle_Fin.Value 'LineaDetalle.Y2 - 1

        Dim _Y_Avanza = XLineaPie.Y1 - _Y1

        _FormPadre.Sld_detalle_Inicio.Maximum = XLineaPie.Y1 - 5
        _FormPadre.Sld_detalle_Fin.Minimum = XLineaDetalle.Y1 + 5

        Dim _Lineas_PP = XLineaPie.Y1 - XLineaDetalle.Y1

        Dim _X = 5 'Lbl_Lineas_x_Pagina.Location.X
        Dim _Y = XLineaPie.Y1 - 7

        Lbl_Lineas_x_Pagina.Location = New System.Drawing.Point(_X, _Y)
        Dim _AltoMax = 15

        For Each _Fl As DataRow In _Tbl_Zw_Format_02.Rows

            Dim _Name = _Fl.Item("Name")
            Dim _Alto = _Fl.Item("Alto")
            Dim _Seccion = _Fl.Item("Seccion")

            If _Seccion = "D" Then
                If _Alto > _AltoMax Then
                    _AltoMax = _Alto
                End If
            End If

        Next

        '_AltoMax += 2

        _NroLineaXPag = Math.Round(_Lineas_PP / _AltoMax)

        Dim _Comentario_LPP As String

        If _FormPadre.Chk_Largo_Variable.Checked Then
            _Comentario_LPP = "Largo Variable"
        Else
            _Comentario_LPP = "Líneas por página: " & _NroLineaXPag
            _FormPadre.Input_Max_Lienas.value = _NroLineaXPag
        End If

        '_FormPadre.Lbl_Linieas_PP.Text = _Comentario_LPP
        Lbl_Lineas_x_Pagina.Text = _Comentario_LPP



        If _FormPadre.Chk_Largo_Variable.Checked Then


            For Each Ctrl In Documento.Controls
                ' No asignar estos evento al botón salir
                If Ctrl.Name <> "ShapeContainer1" And Ctrl.Name <> "LblVersion" And Ctrl.Name <> "Lbl_Lineas_x_Pagina" Then
                    ' Curiosamente un control GroupBox en apariencia
                    ' no tiene estos eventos, pero... se le asigna y...
                    ' ¡funciona!

                    If Ctrl.Name <> "Lbl_Lineas_x_Pagina" Then


                        Dim X = CType(Ctrl, Control).Location.X
                        Dim Y = CType(Ctrl, Control).Location.Y

                        If Y > _Y Then
                            CType(Ctrl, Control).Location = New System.Drawing.Point(X, Y + _Y_Avanza)
                        End If

                    End If

                End If

            Next
            Return
            If (sender Is Nothing) Then
                Return
            End If

            Dim _Limite_Abajo = Documento.Height

            For Each _Ctrl In ShapeContainer1.Shapes

                Dim _Tipo As String = Mid(_Ctrl.Name, 1, 3)

                If _Tipo = "Box" Then

                    'Dim _Ancho_Obj = CType(ObjetoActivo, RectangleShape).Width
                    Dim _Largo_Obj = CType(_Ctrl, RectangleShape).Height
                    Dim _Y_Limite = CType(_Ctrl, RectangleShape).Location.Y + _Largo_Obj

                    Dim _NewY = sender.Value

                    If _Y_Limite > _Limite_Abajo Then
                        _NewY = _Limite_Abajo - _Largo_Obj - 5
                    End If


                    Dim X = CType(_Ctrl, RectangleShape).Location.X
                    CType(_Ctrl, RectangleShape).Location = New System.Drawing.Point(X, _NewY)
                ElseIf _Tipo = "Lin" Then


                    Dim X1 = CType(_Ctrl, LineShape).X1
                    Dim X2 = CType(_Ctrl, LineShape).X2

                    Dim _Largo = X2 - X1 '

                    Dim Y1 = CType(_Ctrl, LineShape).Y1
                    Dim Y2 = CType(_Ctrl, LineShape).Y2

                    Dim _YNew = sender.Value

                    CType(_Ctrl, LineShape).Y1 = _YNew
                    CType(_Ctrl, LineShape).Y2 = _YNew


                End If


            Next

        End If

        _FormPadre.Refresh

    End Sub


    Private Sub Control_Chk_Largo_Variable_CheckedChanged(ByVal sender As System.Object,
                                                          ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)

        'Dim _FrmActivo As Frm_Formato_Diseno_Encabezado = _
        ' TryCast(Me.ActiveMdiChild, Frm_Formato_Diseno_Encabezado)

        _FormPadre.Input_Max_Lienas.Enabled = _FormPadre.Chk_Largo_Variable.Checked

        If _FormPadre.Chk_Largo_Variable.Checked Then
            _FormPadre.Input_Max_Lienas.Value = 0 '_FrmActivo.Pro_NroLineaXPag
            MessageBoxEx.Show(Me, "Al definir largo variable tenga en cuenta los siguiente:" & vbCrLf &
                              "Líneas por página Igual a 0, SIN LIMITE DE LINEAS" & vbCrLf &
                              "Líneas por página Mayor que 0, ASUMIRA LAS LINEAS DEFINIDAS",
                              "Detalle de largo variable", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            _FormPadre.Input_Max_Lienas.Value = _NroLineaXPag   'Input_Max_Lienas.Value = 1
        End If

    End Sub

#End Region

#Region "ELIMINAR ELEMENTO"

    Sub Sb_Eliminar_Objeto()

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value '= 300
        Dim _VerticalScroll = Panel1.VerticalScroll.Value 'CType(PanelActivo, Panel).VerticalScroll.Value ' = 200

        If Not (ObjetoActivo Is Nothing) Then

            Dim _Name = ObjetoActivo.name

            If Mid(_Name, 1, 3) = "Txt" Or Mid(_Name, 1, 3) = "Pic" Or Mid(_Name, 1, 3) = "Lbl" Then

                Dim ControlAct As Control = CType(ObjetoActivo, Control)
                Dim Objeto = PanelActivo

                ControlAct.Dispose()

            ElseIf Mid(_Name, 1, 3) = "Box" Or Mid(_Name, 1, 3) = "Lin" Then
                ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Name))
            End If
            _Nombre_Objeto_Copiado = String.Empty

            Panel1.HorizontalScroll.Value = _HorizontalScroll
            Panel1.VerticalScroll.Value = _VerticalScroll

            For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

                Dim _Name_Objet = _Fila.Item("Name")

                If _Name = _Name_Objet Then

                    _Fila.Item("Name") = String.Empty
                    _Fila.Item("Eliminado") = True

                    Exit For

                End If

            Next

        End If

    End Sub


#End Region

#End Region


#Region "CREAR REGLA"

    Function Fx_Crear_Linea_Regla(ByVal _PosicionX As Integer,
                                  ByVal _Tamano As Integer,
                                  ByVal _PosicionY As Integer,
                                  ByVal _Regla As Object,
                                  Optional ByVal _Vertical As Boolean = False)

        Dim _Linea As New LineShape

        Dim Contador = 0

        With _Regla

            For Each ctr As Control In .Controls
                Dim Tipo = .Name 'CType(ctr, Control).Name
                If Mid(Tipo, 1, 3) = "Lin" Then
                    Contador += 1
                End If
            Next
            If Contador = 0 Then Contador = 1

            With _Linea

                .Name = "Linea" & Contador


                If _Vertical Then
                    .Y1 = 0
                    .Y2 = _Tamano

                    .X1 = _PosicionY
                    .X2 = _PosicionY
                Else
                    ' Horizontal
                    .Y1 = _PosicionY
                    .Y2 = _PosicionY

                    .X1 = _PosicionX
                    .X2 = .X1 + _Tamano
                End If

                .BorderColor = System.Drawing.Color.Red
                '.BorderStyle = Drawing2D.DashStyle.Dash

                If _Vertical Then
                    Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                                                              {_Linea})
                Else
                    Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                                                              {_Linea})
                End If



            End With

            Return _Linea
        End With
    End Function


    Function Fx_Crear_Numero_Regla(ByVal _PosicionX As Integer,
                                   ByVal _PosicionY As Integer,
                                   ByVal _Regla As Object,
                                   Optional ByVal Texto As String = "")

        Dim X = _PosicionX
        Dim Y = _PosicionY

        Dim Contador = 1

        With _Regla

            For Each ctr As Control In .Controls

                Dim Tipo = ctr.Name 'CType(ctr, Control).Name
                Dim Nom = Mid(Tipo, 1, 3)
                If Nom = "Txt" Then
                    Contador += 1
                End If
            Next

            If Contador = 0 Then Contador = 1

            Dim NewTxt As New Label 'TextBox

            With NewTxt

                .Name = "Cent_" & Contador
                .BorderStyle = BorderStyle.None
                .AutoSize = True

                .Text = Texto

                If Global_Thema = Enum_Themas.Oscuro Then
                    .ForeColor = Color.White
                Else
                    .ForeColor = Color.Blue
                End If

                .Enabled = True

                .Location = New System.Drawing.Point(X, Y)
                .Size() = New System.Drawing.Size(13, 13)

            End With

            'Lbl_Regla_X
            '
            'Me.Lbl_Regla_X.AutoSize = True
            'Me.Lbl_Regla_X.Location = New System.Drawing.Point(0, 10)
            'Me.Lbl_Regla_X.Name = "Lbl_Regla_X"
            'Me.Lbl_Regla_X.Size = New System.Drawing.Size(13, 13)
            'Me.Lbl_Regla_X.TabIndex = 1
            'Me.Lbl_Regla_X.Text = "0"
            '
            'Lbl_Regla_Y
            '
            'Me.Lbl_Regla_Y.AutoSize = True
            'Me.Lbl_Regla_Y.Location = New System.Drawing.Point(0, 0)
            'Me.Lbl_Regla_Y.Name = "Lbl_Regla_Y"
            'Me.Lbl_Regla_Y.Size = New System.Drawing.Size(13, 13)
            'Me.Lbl_Regla_Y.TabIndex = 2
            'Me.Lbl_Regla_Y.Text = "0"


            'NewTxt = txtBox

            _Regla.Controls.Add(NewTxt)

            Return NewTxt
        End With
    End Function

#End Region


#Region "CONTROLES DE EVENTOS PARA OBJETOS"

    Private Sub Control_Double_Clic(
            ByVal sender As Object,
            ByVal e As System.EventArgs)

        ObjetoActivo = sender

        Dim _Tipo = Mid(ObjetoActivo.Name, 1, 3)

        If _Tipo = "Txt" Or _Tipo = "Lbl" Then
            Sb_Objeto_Editar_Texto()
        End If

        'Sb_Ver_Propiedad_de_Objeto_Mapa()

    End Sub

    Sub Sb_Desmarcar_Objetos()

        For Each Ctrl In Documento.Controls
            ' No asignar estos evento al botón salir
            If Ctrl.Name <> "ShapeContainer1" And Ctrl.Name <> "LblVersion" Then
                Dim _Tipo = Mid(Ctrl.Name, 1, 3) ' 

                If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then
                    If _Tipo = "Pic" Then
                        CType(Ctrl, PictureBox).BorderStyle = BorderStyle.None
                    Else
                        If _Tipo = "Txt" Then
                            CType(Ctrl, Label).BackColor = Color.WhiteSmoke
                        ElseIf _Tipo = "Lbl" Then
                            CType(Ctrl, Label).BackColor = Color.Khaki
                        End If
                    End If
                End If

            End If

        Next


    End Sub


    Private Sub Control_Clic(
            ByVal sender As Object,
            ByVal e As System.EventArgs)

        Try

            ObjetoActivo = sender

            'RemoveHandler CType(_FormPadre.Sld_Tam_Alto, SliderItem).ValueChanged, AddressOf Control_Tamano_Obj_Alto_ValueChanged
            'RemoveHandler CType(_FormPadre.Sld_Tam_Ancho, SliderItem).ValueChanged, AddressOf Control_Tamano_Obj_Ancho_ValueChanged

            'RemoveHandler CType(_FormPadre.Sld_Ubicacion_X, SliderItem).ValueChanged, AddressOf Control_Ubicacion_Obj_X_ValueChanged
            'RemoveHandler CType(_FormPadre.Sld_Ubicacion_Y, SliderItem).ValueChanged, AddressOf Control_Ubicacion_Obj_Y_ValueChanged
            'Sb_Desmarcar_Objetos()


            If Not (ObjetoActivo Is Nothing) Then

                Dim _Tipo = Mid(ObjetoActivo.Name, 1, 3) '  

                If _Tipo = "Txt" Or _Tipo = "Lbl" Then 'Or _Tipo = "Pic"

                    _FormPadre.Sld_Tam_Alto.Value = CType(ObjetoActivo, Control).Height
                    _FormPadre.Sld_Tam_Ancho.Value = CType(ObjetoActivo, Control).Width

                    Dim _X = CType(ObjetoActivo, Control).Location.X
                    Dim _Y = CType(ObjetoActivo, Control).Location.Y

                    _FormPadre.Sld_Ubicacion_X.Value = _X
                    _FormPadre.Sld_Ubicacion_Y.Value = _Y

                    'If _Tipo = "Pic" Then
                    'CType(ObjetoActivo, PictureBox).BorderStyle = BorderStyle.FixedSingle
                    'CType(ObjetoActivo, PictureBox).SendToBack()
                    'Else
                    'CType(ObjetoActivo, Label).BackColor = Color.LightGreen
                    'End If

                    'Fx_Marcar_linea(sender)

                ElseIf _Tipo = "Lin" Then

                    'Sld_Tam_Alto.Value = CType(ObjetoActivo, Control).Height
                    _FormPadre.Sld_Tam_Ancho.Value = CType(ObjetoActivo, LineShape).X1 - CType(ObjetoActivo, LineShape).X2

                    _FormPadre.Sld_Ubicacion_X.Value = CType(ObjetoActivo, LineShape).X1
                    _FormPadre.Sld_Ubicacion_Y.Value = CType(ObjetoActivo, LineShape).X1

                ElseIf _Tipo = "Box" Then
                    CType(ObjetoActivo, RectangleShape).BringToFront()
                    Dim _Size = CType(ObjetoActivo, RectangleShape).Size

                    '_Alto_Caja = _Size.Height
                    '_Ancho_Caja = _Size.Width

                    _FormPadre.Sld_Tam_Alto.Value = _Size.Height
                    _FormPadre.Sld_Tam_Ancho.Value = _Size.Width

                    _FormPadre.Sld_Ubicacion_X.Value = CType(ObjetoActivo, RectangleShape).Location.X
                    _FormPadre.Sld_Ubicacion_Y.Value = CType(ObjetoActivo, RectangleShape).Location.Y



                    'Fx_Marcar_linea(sender)
                End If



            End If


        Catch ex As Exception
        Finally
            Me.Refresh()
        End Try

    End Sub

    Private Sub Control_MouseDown(
            ByVal sender As Object,
            ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Cuando se pulsa con el ratón
        DX = e.X
        DY = e.Y

        'Panel1.AutoScroll = False

        Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
        Dim _VerticalScroll = Panel1.VerticalScroll.Value


        ObjetoActivo = sender
        Dim _Tipo = sender.Name
        ObjetoActivo.FOCUS()

        Sb_Desmarcar_Objetos()

        Dim _Y
        Dim _X

        If Mid(_Tipo, 1, 3) = "Lin" Then

        Else
            With CType(_FormPadre, Frm_ImpresionDoc_Configuracion)

                Dim _Ancho_Obj = ObjetoActivo.Width
                Dim _Largo_Obj = ObjetoActivo.Height

                _Y = ObjetoActivo.Location.Y
                _X = ObjetoActivo.Location.X

                _FormPadre.Sld_Tam_Alto.Value = _Largo_Obj
                _FormPadre.Sld_Tam_Ancho.Value = _Ancho_Obj

                _FormPadre.Sld_Ubicacion_Y.Value = _Y
                _FormPadre.Sld_Ubicacion_X.Value = _X

            End With
        End If



        If Mid(_Tipo, 1, 3) = "Txt" Or Mid(_Tipo, 1, 3) = "Lbl" Or Mid(_Tipo, 1, 3) = "Pic" Then

            CType(sender, Control).BringToFront()

            Dim _Tipo_Objeton As String = Mid(_Tipo, 1, 3)

            Select Case _Tipo_Objeton
                Case "Txt"
                    If e.Button = Windows.Forms.MouseButtons.Right Then
                        Btn_Posicion_Objeto_Texto_Libre.Text = "Editar posicion manualmente (X = " & _X & ",Y = " & _Y & ")"
                        ShowContextMenu(Menu_Contextual_Objeto_Texto_Libre)
                    End If
                Case "Lbl"

                    If Mid(_Tipo, 1, 5) = "LblFx" Then

                        Dim _Nombre_Etiqueta = _Tipo
                        Dim _Funcion
                        Dim _TipoDato
                        Dim _Orden_Detalle
                        Dim _Seccion

                        For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

                            Dim _Name = _Fila.Item("Name")
                            Dim _Name_Objet = CType(ObjetoActivo, Control).Name

                            If _Name = _Name_Objet Then

                                _Seccion = _Fila.Item("Seccion") ' _Funciones(_i, 1)
                                _Funcion = _Fila.Item("Funcion") ' _Funciones(_i, 1)
                                _TipoDato = _Fila.Item("TipoDato") '_Funciones(_i, 2)
                                _Orden_Detalle = _Fila.Item("Orden_Detalle") '_Funciones(_i, 4)

                                Rdb_Orden_Impresion_Fila1_Funcion.Checked = (_Orden_Detalle = 1) ' True
                                Rdb_Orden_Impresion_Fila2_Funcion.Checked = (_Orden_Detalle = 2) 'False

                                Lbl_Orden_Impresion.Visible = (_Seccion = "D")
                                Rdb_Orden_Impresion_Fila1_Funcion.Visible = (_Seccion = "D")
                                Rdb_Orden_Impresion_Fila2_Funcion.Visible = (_Seccion = "D")

                                Lbl_Conceptos.Visible = (_Seccion = "D")
                                Chk_Mostrar_En_Concepto.Visible = (_Seccion = "D")

                                Chk_Mostrar_En_Concepto.Checked = _Fila.Item("Mostrar_En_Concepto")

                                Exit For

                            End If

                        Next

                        Lbl_Nombre_Funcion.Text = "Función: " & _Funcion

                        If e.Button = Windows.Forms.MouseButtons.Right Then
                            Btn_Posicion_Objeto_Funcion.Text = "Editar posicion manualmente (X = " & _X & ",Y = " & _Y & ")"
                            ShowContextMenu(Menu_Contextual_Objeto_Funcion)
                        End If
                    Else
                        If e.Button = Windows.Forms.MouseButtons.Right Then
                            Btn_Posicion_Objeto_Texto_Libre.Text = "Editar posicion manualmente (X = " & _X & ",Y = " & _Y & ")"
                            ShowContextMenu(Menu_Contextual_Objeto_Funcion)
                        End If
                    End If

                Case "Pic"
                    If e.Button = Windows.Forms.MouseButtons.Right Then

                        Dim _Ancho_Obj = ObjetoActivo.Width
                        Dim _Largo_Obj = ObjetoActivo.Height

                        Dim _Ruta_Imagen = "Ruta imagen: " & CType(ObjetoActivo, PictureBox).ImageLocation()

                        Lbl_Ruta_Imagen.Text = _Ruta_Imagen

                        Btn_Posicion_Objeto_Imagen.Text = "Posicion (X = " & _X & ",Y = " & _Y & ") Largo: " & _Largo_Obj & ", Ancho: " & _Ancho_Obj
                        ShowContextMenu(Menu_Contextual_Objeto_Imagen)

                    End If
                Case ""
            End Select

            If Mid(_Tipo, 1, 3) <> "Pic" Then
                CType(ObjetoActivo, Label).BackColor = Color.LightGreen
                Fx_Marcar_linea(ObjetoActivo)
            End If

        ElseIf Mid(_Tipo, 1, 3) = "Box" Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Btn_Posicion_Objeto_Box.Text = "Editar posicion manualmente (X = " & _X & ",Y = " & _Y & ")"
                Btn_Mnu_Cmb_Ancho_Linea.SelectedIndex = CType(ObjetoActivo, RectangleShape).BorderWidth
                Btn_Mnu_Caja_Redondear_Bordes.Checked = CBool(CType(ObjetoActivo, RectangleShape).CornerRadius)
                ShowContextMenu(Menu_Contextual_Objeto_Caja)
            End If
        End If

        'Panel1.HorizontalScroll.Value = _HorizontalScroll
        'Panel1.VerticalScroll.Value = _VerticalScroll

    End Sub

    Private Sub Control_MouseUP(
                 ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Arrow

        'ObjetoActivo = sender
        If Not (ObjetoActivo Is Nothing) Then

            Try
                'Me.ShapeContainer1.Refresh()
                'Me.Documento.Refresh()

                Dim _Lineas = ShapeContainer1.Shapes.Count - 1
                Dim _Arr(_Lineas) As String
                Dim _i = 0
                Dim _Con_Lineas = False

                For Each _Ctrl In ShapeContainer1.Shapes
                    'Insertamos objetos de diseño, muros, puertas, etc...
                    If Mid(_Ctrl.Name, 1, 3) = "Lin" Then
                        _Arr(_i) = _Ctrl.name
                        _i += 1
                        _Con_Lineas = True
                        'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Ctrl.name))
                    End If
                Next

                If _Con_Lineas Then
                    For _i = 0 To _Lineas
                        Try
                            Me.ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Arr(_i)))
                        Catch ex As Exception

                        End Try

                    Next
                End If
                ' Me.Refresh()

            Catch ex As Exception

            End Try
        End If


        'Alto.Enabled = False
        'Ancho.Enabled = False
    End Sub

    Private Sub Control_MouseLeave(
          ByVal sender As Object,
           ByVal e As System.Windows.Forms.MouseEventArgs)

        If Not (ObjetoActivo Is Nothing) Then
            Dim Tipo = ObjetoActivo.Name

            If Mid(Tipo, 1, 3) = "Pic" Then
                ObjetoActivo.BorderStyle = BorderStyle.None
            End If

            Try
                Dim _Lineas = ShapeContainer1.Shapes.Count - 1
                Dim _Arr(_Lineas) As String
                Dim _i = 0
                Dim _Con_Lineas = False

                For Each _Ctrl In ShapeContainer1.Shapes
                    'Insertamos objetos de diseño, muros, puertas, etc...
                    If Mid(_Ctrl.Name, 1, 3) = "Lin" Then
                        _Arr(_i) = _Ctrl.name
                        _i += 1
                        _Con_Lineas = True
                        'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Ctrl.name))
                    End If
                Next

                If _Con_Lineas Then
                    For _i = 0 To _Lineas
                        Try
                            Me.ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Arr(_i)))
                        Catch ex As Exception

                        End Try

                    Next
                End If
                Me.Refresh()
            Catch ex As Exception
                'Me.Refresh()
            End Try

        End If

    End Sub

    Private Sub Control_MouseMove(
           ByVal sender As Object,
           ByVal e As System.Windows.Forms.MouseEventArgs)

        ' Cuando se mueve el ratón y se pulsa el botón izquierdo... mover el control

        Dim _Limite_Derecha = Documento.Width
        Dim _Limite_Abajo = Documento.Height

        If Not (ObjetoActivo Is Nothing) Then

            If e.Button = MouseButtons.Left Then

                Dim _Tipo = Mid(ObjetoActivo.Name, 1, 3)

                If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then

                    Dim _Lx = e.X + CType(ObjetoActivo, Control).Left - DX
                    Dim _Ly = e.Y + CType(ObjetoActivo, Control).Top - DY

                    CType(ObjetoActivo, Control).Left = _Lx
                    CType(ObjetoActivo, Control).Top = _Ly

                    If _Tipo <> "Pic" Then
                        Fx_Marcar_linea(ObjetoActivo)
                    End If

                ElseIf _Tipo = "Lin" Then

                    Dim X1 = CType(ObjetoActivo, LineShape).X1
                    Dim X2 = CType(ObjetoActivo, LineShape).X2

                    Dim _Largo = X2 - X1

                    Dim Y1 = CType(ObjetoActivo, LineShape).Y1
                    Dim Y2 = CType(ObjetoActivo, LineShape).Y2


                    Dim _Lx = e.X + CType(ObjetoActivo, LineShape).X1 - DX
                    Dim _Ly = e.Y + CType(ObjetoActivo, LineShape).Y1 - DY

                    X1 = _Lx
                    X2 = _Lx + _Largo
                    Y1 = _Ly
                    Y2 = _Ly

                    CType(ObjetoActivo, LineShape).X1 = X1
                    CType(ObjetoActivo, LineShape).X2 = X2

                    CType(ObjetoActivo, LineShape).Y1 = Y1
                    CType(ObjetoActivo, LineShape).Y2 = Y2

                ElseIf _Tipo = "Box" Then

                    Dim _HorizontalScroll = Panel1.HorizontalScroll.Value
                    Dim _VerticalScroll = Panel1.VerticalScroll.Value

                    Dim _Ancho_Obj = CType(ObjetoActivo, RectangleShape).Width
                    Dim _Largo_Obj = CType(ObjetoActivo, RectangleShape).Height

                    Dim Y = CType(ObjetoActivo, RectangleShape).Location.Y
                    Dim X = CType(ObjetoActivo, RectangleShape).Location.X

                    Dim _Loca = CType(ObjetoActivo, RectangleShape).Location '= 'e.X + CType(sender, RectangleShape).Left - DX
                    Dim _Lx = e.X + _Loca.X - DX
                    Dim _Ly = e.Y + _Loca.Y - DY

                    If _Ly <= 0 Then _Ly = 1
                    If _Lx <= 0 Then _Lx = 1

                    If _Lx >= _Limite_Derecha - _Ancho_Obj Then

                        _Lx = _Limite_Derecha - _Ancho_Obj - 1
                    End If


                    If _Ly >= _Limite_Abajo - _Largo_Obj Then
                        _Ly = _Limite_Abajo - _Largo_Obj - 1
                    End If


                    CType(ObjetoActivo, RectangleShape).Location = New System.Drawing.Point(_Lx, _Ly)

                    Panel1.HorizontalScroll.Value = _HorizontalScroll
                    Panel1.VerticalScroll.Value = _VerticalScroll

                End If

                Sb_Editar_Objeto(ObjetoActivo)

                Me.Cursor = Cursors.NoMove2D 'Cursors.Cross

            End If

        End If

        'Me.Cursor = Cursors.Arrow

        _FormPadre.Lbl_X.Text = "X : " & e.X.ToString + PosicionX
        _FormPadre.Lbl_Y.Text = "Y : " & e.Y.ToString + PosicionY

    End Sub

#End Region

#Region "CONTROLES COMPRATIDOS DE TAMAÑO Y UBICACION"

    Function Fx_Marcar_linea(ByVal _Objeto As Object)

        'Exit Function


        Dim _Tipo = Mid(_Objeto.Name, 1, 3)
        Dim _Lx
        Dim _Ly

        If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then
            _Lx = CType(_Objeto, Control).Left
            _Ly = CType(_Objeto, Control).Top
        ElseIf _Tipo = "Box" Then
            _Lx = CType(_Objeto, RectangleShape).Location.X
            _Ly = CType(_Objeto, RectangleShape).Location.Y
        End If

        ' LIMPIA LAS LINEAS ANTERIORES

        Try
            Dim _Lineas = ShapeContainer1.Shapes.Count - 1
            Dim _Arr(_Lineas) As String
            Dim _i = 0
            Dim _Con_Lineas = False

            For Each _Ctrl In ShapeContainer1.Shapes
                'Insertamos objetos de diseño, muros, puertas, etc...
                If Mid(_Ctrl.Name, 1, 3) = "Lin" Then
                    _Arr(_i) = _Ctrl.name
                    _i += 1
                    _Con_Lineas = True
                    'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Ctrl.name))
                End If
            Next

            If _Con_Lineas Then
                For _i = 0 To _Lineas
                    Try
                        Me.ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Arr(_i)))
                    Catch ex As Exception

                    End Try

                Next
            End If
            'Me.Refresh()
        Catch ex As Exception
            'Me.Refresh()
        End Try
        ' End If


        'CREA LA NUEVA LINEA

        If _Tipo = "Txt" Or _Tipo = "Lbl" Then 'Or _Tipo = "Pic"

            For Each ctr As Object In Documento.Controls

                Dim Tipo = ctr.Name 'CType(ctr, Control).Name
                Dim Nom = Mid(Tipo, 1, 3)

                If Tipo <> _Objeto.Name Then

                    Dim X_ = CType(ctr, Control).Left
                    Dim Y_ = CType(ctr, Control).Top

                    If X_ = _Lx Then
                        _Line_Aj_2 = Fx_Crear_Linea(X_, 0, Documento.Height, False, True)
                        'Else
                        'Try
                        'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_2.name))
                        'Catch ex As Exception
                        'End Try
                    End If

                    If Y_ = _Ly Then
                        _Line_Aj_1 = Fx_Crear_Linea(0, Documento.Width, Y_, False)
                        'Else
                        'Try
                        'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_1.name))
                        'Catch ex As Exception
                        'End Try
                    End If

                Else
                    'Try
                    'Dim _Lineas = ShapeContainer1.Shapes.Count - 1
                    'Dim _Arr(_Lineas) As String
                    'Dim _i = 0
                    'Dim _Con_Lineas = False

                    'For Each _Ctrl In ShapeContainer1.Shapes
                    ''Insertamos objetos de diseño, muros, puertas, etc...
                    'If Mid(_Ctrl.Name, 1, 3) = "Lin" Then
                    '_Arr(_i) = _Ctrl.name
                    '_i += 1
                    '_Con_Lineas = True
                    ''ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Ctrl.name))
                    'End If
                    'Next

                    'If _Con_Lineas Then
                    'For _i = 0 To _Lineas
                    'Try
                    'Me.ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Arr(_i)))
                    'Catch ex As Exception

                    'End Try

                    'Next
                    'End If
                    'Me.Refresh()
                    'Catch ex As Exception
                    'Me.Refresh()
                    'End Try
                    ' End If
                End If
            Next
        End If


        Exit Function

        If _Tipo = "Box" Then
            Try

                For Each _Ctrl In ShapeContainer1.Shapes
                    Dim _Tip As String = Mid(_Ctrl.Name, 1, 3)
                    If _Tip = "Box" Then

                        Dim Tipo = _Ctrl.Name 'CType(ctr, Control).Name

                        If Tipo <> _Objeto.Name Then

                            Dim X_ = CType(_Ctrl, RectangleShape).Location.X
                            Dim Y_ = CType(_Ctrl, RectangleShape).Location.Y

                            If X_ = _Lx Then
                                _Line_Aj_2 = Fx_Crear_Linea(X_, 0, PanelActivo.Height, False, True)
                                'Else
                                'Try
                                'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_2.name))
                                'Catch ex As Exception
                                'End Try
                            End If

                            If Y_ = _Ly Then
                                _Line_Aj_1 = Fx_Crear_Linea(0, PanelActivo.Width, Y_, False)
                                'Else
                                'Try
                                'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_1.name))
                                'Catch ex As Exception
                                'End Try
                            End If

                        Else
                            Try
                                ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_1.name))
                                ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_2.name))
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                Next
            Catch ex As Exception

            End Try

        End If



    End Function

#End Region

#Region "VER PROPIEDADES DE OBJETOS DE MAPA"

    Sub Sb_Ver_Propiedad_de_Objeto_Mapa()

        Try
            Dim _Escala As Double = 100 / (_Tamano_Escala * 100)

            Sb_Revisar_Form_Popiedades_Mapa()

            Fm_Propiedades._Objeto = ObjetoActivo
            Fm_Propiedades._Escala = _Escala
            Fm_Propiedades._Max_X = Documento.Width
            Fm_Propiedades._Max_Y = Documento.Height
            Fm_Propiedades.Show()

        Catch ex As Exception

        End Try
        'Fm_Propiedades.Dispose()

    End Sub

#End Region

#Region "REVISA SI LAS PROPIEDADES ESTAN ABIERTAS"

    Sub Sb_Revisar_Form_Popiedades_Mapa()

        'If (Fm_Propiedades.Visible) Then
        'Fm_Propiedades.Close()
        Fm_Propiedades.Dispose()
        Fm_Propiedades = New Frm_Mapa_Diseno_Elementos
        'End If

    End Sub

#End Region

    Function Fx_SQL_Grabar_Imagenes(ByVal _Id As Integer,
                                    ByVal _Ruta_Imagen As String) As Boolean

        Dim blob As Byte()
        Try
            blob = IO.File.ReadAllBytes(_Ruta_Imagen)

            Dim cn As New System.Data.SqlClient.SqlConnection
            Dim sCnn = Cadena_ConexionSQL_Server
            cn.ConnectionString = sCnn

            Dim cmd As System.Data.SqlClient.SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
            ' Crear la consulta T-SQL para insertar un nuevo registro.
            cmd.CommandText = "Update " & _Global_BaseBk & "Zw_Format_02 Set Imagen = @Imagen" & vbCrLf &
                              "Where Id " = _Id
            ' Añadir el único parámetro de entrada existente.

            ' La función ReadBinaryFile tal cual se encuentra implementada no devolverá un valor Nothing,
            ' pero muestro cómo especificar un valor NULL al parámetro de entrada si el valor del campo
            ' binario fuese Nothing. Para insertar un valor NULL, el campo de la tabla lo tiene que permitir.

            cmd.Parameters.AddWithValue("@Imagen", If(blob IsNot Nothing, blob, CObj(DBNull.Value)))
            cn.Open()

            Dim c As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            Dim _Grabar As Integer = cmd.ExecuteNonQuery()
            Me.Cursor = c

            Return True

        Catch ex As Exception
            ' MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Function

    Function Fx_Extrae_Archivo_desde_BD(ByVal _Semilla As Integer,
                                        ByVal _Nombre_Archivo As String) As Boolean

        Dim data As Byte() = Nothing

        Try
            ' Construimos los correspondientes objetos para
            ' conectarnos a la base de datos de SQL Server,
            ' utilizando la seguridad integrada de Windows NT.
            '
            Using cn As New System.Data.SqlClient.SqlConnection
                Dim sCnn = Cadena_ConexionSQL_Server
                cn.ConnectionString = sCnn
                Dim cmd As System.Data.SqlClient.SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
                ' Seleccionamos únicamente el campo que contiene
                ' los documentos, filtrándolo mediante su
                ' correspondiente campo identificador.
                '
                cmd.CommandText = "SELECT Archivo From " & _Global_BaseBk & "Zw_Negocios_04_Doc WHERE Semilla = " & _Semilla
                ' Abrimos la conexión.
                cn.Open()
                ' Creamos un DataReader.
                Dim dr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                ' Leemos el registro.
                dr.Read()
                ' El tamaño del búfer debe ser el adecuado para poder
                ' escribir en el archivo todos los datos leídos.
                '
                ' Si el parámetro 'buffer' lo pasamos como Nothing, obtendremos
                ' la longitud del campo en bytes.
                '
                Dim bufferSize As Integer = Convert.ToInt32(dr.GetBytes(0, 0, Nothing, 0, 0))

                ' Creamos el array de bytes. Como el índice está
                ' basado en cero, la longitud del array será la
                ' longitud del campo menos una unidad.
                '
                data = New Byte(bufferSize - 1) {}

                ' Leemos el campo.
                '
                dr.GetBytes(0, 0, data, 0, bufferSize)

                ' Cerramos el objeto DataReader, e implícitamente la conexión.
                '
                dr.Close()

            End Using

            ' Procedemos a crear el archivo, en el ejemplo
            ' un documento de Microsoft Word.
            '
            ' Sb_WriteBinaryFile(Me, _Dir_Temp & "\" & _Nom_Archivo, data)

            System.IO.File.Delete(_Dir_Ruta_Imagenes & "\" & _Nombre_Archivo)
            Using fs As New IO.FileStream(_Dir_Ruta_Imagenes & "\" & _Nombre_Archivo,
                                          IO.FileMode.CreateNew, IO.FileAccess.Write)

                ' Crea el escritor para la secuencia.
                Dim bw As New IO.BinaryWriter(fs)

                ' Escribir los datos en la secuencia.
                bw.Write(data)

            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function


    Private Shared Sub Sb_WriteBinaryFile(ByVal _Formulario As Form,
                                          ByVal _Ruta_Archivo As String,
                                          ByVal data As Byte())

        ' Comprobación de los valores de los parámetros.
        '
        If (String.IsNullOrEmpty(_Ruta_Archivo)) Then _
            Throw New ArgumentException("No se ha especificado el archivo de destino.", "fileName")

        If (data Is Nothing) Then _
            Throw New ArgumentException("Los datos no son válidos para crear un archivo.", "data")

        ' Crear el archivo. Se producirá una excepción si ya existe
        ' un archivo con el mismo nombre.

        Dim _Existe As Boolean = System.IO.File.Exists(_Ruta_Archivo)

        If _Existe Then
            If MessageBoxEx.Show(_Formulario, "¿Desea reemplazarlo?" & vbCrLf & vbCrLf &
                                _Ruta_Archivo, "Este archivo ya existe",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                System.IO.File.Delete(_Ruta_Archivo)
            Else
                Return
            End If
        End If

        Using fs As New IO.FileStream(_Ruta_Archivo, IO.FileMode.CreateNew, IO.FileAccess.Write)

            ' Crea el escritor para la secuencia.
            Dim bw As New IO.BinaryWriter(fs)

            ' Escribir los datos en la secuencia.
            bw.Write(data)

        End Using

    End Sub

#End Region




    Private Sub Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Documento.Click
        Me.Cursor = Cursors.Arrow
        ObjetoActivo = Nothing ' = String.Empty
    End Sub

    Private Sub Documento_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Documento.MouseLeave

        Me.Cursor = Cursors.Arrow

        _FormPadre.Lbl_X.Text = "X : 0"
        _FormPadre.Lbl_Y.Text = "Y : 0"

        '_FormPadre.Refresh()

    End Sub

    Private Sub Documento_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Documento.MouseMove

        PosicionX = e.X.ToString
        PosicionY = e.Y.ToString
        Me.Cursor = Cursors.Arrow

        _FormPadre.Lbl_X.Text = "X : " & PosicionX
        _FormPadre.Lbl_Y.Text = "Y : " & PosicionY

        '_FormPadre.Refresh()

    End Sub


    Private Sub Frm_Formulario_Diseno_Mapa_Documentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Nombre_Objeto_Copiado = String.Empty
            'Me.Close()
        End If
    End Sub

    Private Sub Frm_Formato_Diseno_Encabezado_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter

        With CType(_FormPadre, Frm_ImpresionDoc_Configuracion)

            .Sld_Tam_Alto.Maximum = Documento.Height
            .Sld_Tam_Ancho.Maximum = Documento.Width

            .Sld_Ubicacion_Y.Maximum = Documento.Height
            .Sld_Ubicacion_X.Maximum = Documento.Width

        End With

    End Sub


    Private Sub Control_Tamano_Obj_Alto_ValueChanged(
                                             ByVal sender As Object,
                                             ByVal e As System.EventArgs)

        Try

            Dim _Limite_Derecha = Documento.Width
            Dim _Limite_Abajo = Documento.Height

            Dim _ObjetoActivo = ObjetoActivo


            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3) '  

            If _Tipo <> "Box" Then
                Dim ff = CType(_ObjetoActivo, Control).Text
                CType(_ObjetoActivo, Control).Height = sender.Value
            ElseIf _Tipo = "Box" Then
                Dim _Size = CType(_ObjetoActivo, RectangleShape).Size
                CType(_ObjetoActivo, RectangleShape).Size = New System.Drawing.Size(_Size.Width, sender.Value)
            End If

            sender.Tooltip = sender.value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_Tamano_Obj_Ancho_ValueChanged(
                                               ByVal sender As System.Object,
                                               ByVal e As System.EventArgs)
        Try


            Dim _Limite_Derecha = Documento.Width
            Dim _Limite_Abajo = Documento.Height

            Dim _ObjetoActivo = ObjetoActivo
            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3) '  

            If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then
                CType(_ObjetoActivo, Control).Width = sender.Value

            ElseIf _Tipo = "Lin" Then

                CType(_ObjetoActivo, LineShape).X2 = CType(_ObjetoActivo, LineShape).X1 + sender.Value

            ElseIf _Tipo = "Box" Then
                Dim _Size = CType(_ObjetoActivo, RectangleShape).Size
                CType(_ObjetoActivo, RectangleShape).Size = New System.Drawing.Size(sender.Value, _Size.Height)
            End If

            sender.Tooltip = sender.value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_Ubicacion_Obj_X_ValueChanged(
                                              ByVal sender As Object,
                                              ByVal e As System.EventArgs)

        Dim _Limite_Derecha = Documento.Width
        Dim _Limite_Abajo = Documento.Height

        Dim _ObjetoActivo = ObjetoActivo


        Try
            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3) '  

            If _Tipo <> "Box" And _Tipo <> "Lin" Then
                Dim Y = CType(_ObjetoActivo, Control).Location.Y
                CType(_ObjetoActivo, Control).Location = New System.Drawing.Point(sender.value, Y)
            ElseIf _Tipo = "Box" Then
                Dim Y = CType(_ObjetoActivo, RectangleShape).Location.Y
                CType(_ObjetoActivo, RectangleShape).Location = New System.Drawing.Point(sender.Value, Y)
            ElseIf _Tipo = "Lin" Then

                Dim X1 = CType(_ObjetoActivo, LineShape).X1
                Dim X2 = CType(_ObjetoActivo, LineShape).X2

                Dim Y1 = CType(_ObjetoActivo, LineShape).Y1
                Dim Y2 = CType(_ObjetoActivo, LineShape).Y2

                Dim _Largo_X = X2 - X1 '
                Dim _Largo_Y = Y2 - Y1 '


                Dim _XNew = sender.Value

                X1 = _XNew
                X2 = _XNew + _Largo_X

                CType(_ObjetoActivo, LineShape).X1 = X1
                CType(_ObjetoActivo, LineShape).X2 = X2

            End If

            sender.Tooltip = sender.value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_Ubicacion_Obj_Y_ValueChanged(
                                              ByVal sender As Object,
                                              ByVal e As System.EventArgs)

        Try

            Dim _Limite_Derecha = Documento.Width
            Dim _Limite_Abajo = Documento.Height

            Dim _ObjetoActivo = ObjetoActivo

            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3) '

            If _Tipo <> "Box" And _Tipo <> "Lin" Then

                Dim X = CType(_ObjetoActivo, Control).Location.X
                Dim _Y = CType(_ObjetoActivo, Control).Location.Y

                Dim _Y_Avanza = _Y - sender.value

                CType(_ObjetoActivo, Control).Location = New System.Drawing.Point(X, sender.value)

                If _FormPadre.Chk_Mover_Abajo_Tambien.Checked Then

                    For Each Ctrl In Documento.Controls
                        ' No asignar estos evento al botón salir
                        If Ctrl.Name <> "ShapeContainer1" And Ctrl.Name <> "LblVersion" And Ctrl.Name <> "Lbl_Lineas_x_Pagina" Then
                            ' Curiosamente un control GroupBox en apariencia
                            ' no tiene estos eventos, pero... se le asigna y...
                            ' ¡funciona!

                            If Ctrl.Name <> "Lbl_Lineas_x_Pagina" Then

                                Dim Y = CType(Ctrl, Control).Location.Y

                                If Y > _Y Then
                                    CType(Ctrl, Control).Location = New System.Drawing.Point(X, Y + _Y_Avanza)
                                End If

                            End If

                        End If

                    Next
                End If

            ElseIf _Tipo = "Box" Then

                'Dim _Ancho_Obj = CType(ObjetoActivo, RectangleShape).Width
                Dim _Largo_Obj = CType(_ObjetoActivo, RectangleShape).Height
                Dim _Y_Limite = CType(_ObjetoActivo, RectangleShape).Location.Y + _Largo_Obj

                Dim _NewY = sender.Value

                If _Y_Limite > _Limite_Abajo Then
                    _NewY = _Limite_Abajo - _Largo_Obj - 5
                End If

                'If _Lx >= _Limite_Derecha - _Ancho_Obj Then

                '_Lx = _Limite_Derecha - _Ancho_Obj - 1
                'End If


                'If _Ly >= _Limite_Abajo - _Largo_Obj Then
                '_Ly = _Limite_Abajo - _Largo_Obj - 1
                'End If

                Dim X = CType(_ObjetoActivo, RectangleShape).Location.X
                CType(_ObjetoActivo, RectangleShape).Location = New System.Drawing.Point(X, _NewY)
            ElseIf _Tipo = "Lin" Then


                Dim X1 = CType(_ObjetoActivo, LineShape).X1
                Dim X2 = CType(_ObjetoActivo, LineShape).X2

                Dim _Largo = X2 - X1 '

                Dim Y1 = CType(_ObjetoActivo, LineShape).Y1
                Dim Y2 = CType(_ObjetoActivo, LineShape).Y2

                Dim _YNew = sender.Value

                CType(_ObjetoActivo, LineShape).Y1 = _YNew
                CType(_ObjetoActivo, LineShape).Y2 = _YNew


            End If

            sender.Tooltip = sender.value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Documento_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Documento.MouseDown

        Me.Cursor = Cursors.Arrow
        ObjetoActivo = Nothing ' = String.Empty

        If e.Button = Windows.Forms.MouseButtons.Right Then

            'Panel1.AutoScroll = False
            'Panel1.HorizontalScroll.Enabled = False
            'Panel1.VerticalScroll.Enabled = False

            If Not String.IsNullOrEmpty(_Nombre_Objeto_Copiado) Then
                Btn_Pegar.Enabled = True
            Else
                Btn_Pegar.Enabled = False
            End If

            ShowContextMenu(Menu_Contextual_Insertar_Nuevos_Objetos)

            'ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

            '    Panel1.AutoScroll = True
            '    Panel1.HorizontalScroll.Enabled = True
            '    Panel1.VerticalScroll.Enabled = True

        End If

        Sb_Desmarcar_Objetos()

    End Sub

    Private Sub Btn_Insertar_Texto_Libre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Insertar_Texto_Libre.Click

        Dim _Nombre_Objeto = Fx_Trae_Nombre_Objeto("TxtBox")
        ObjetoActivo = Fx_Crear_Txt(_Nombre_Objeto, PosicionX, PosicionY, "", True)

        Dim _Aceptado As Boolean
        Dim _Texto As String = CType(ObjetoActivo, Label).Text

        _Aceptado = InputBox_Bk(Me, "Escriba el texto", "TEXTO LIBRE", _Texto, False,
                             _Tipo_Mayus_Minus.Normal, , True, _Tipo_Imagen.Texto, True, _Tipo_Caracter.Cualquier_caracter)

        If _Aceptado Then
            CType(ObjetoActivo, Label).Text = _Texto
            _Clas_Formato.Fx_Editar_Fuente(ObjetoActivo)
            Sb_Editar_Objeto(ObjetoActivo)
        End If

    End Sub

    Function Fx_Trae_Nombre_Objeto(_Sigla As String) As String

        Dim _UltFila As DataRow
        For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows
            _UltFila = _Fila
        Next

        If IsNothing(_UltFila) Then
            _Sigla = _Sigla & 1
        Else
            _Sigla = _Sigla & _UltFila.Item("Contador") + 1
        End If

        Return _Sigla

    End Function

    Private Sub Btn_Insertar_Imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Insertar_Imagen.Click
        If _Clas_Formato.Fx_Editar_Imagen(_Dir_Ruta_Imagenes) Then
            Dim _Nombre_Objeto = Fx_Trae_Nombre_Objeto("PictBox")
            Fx_Crear_Imagen(_Nombre_Objeto, PosicionX, PosicionY, _Clas_Formato.Pro_RutaImagen, True)
        End If
    End Sub

    Private Sub Btn_Insertar_Caja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Insertar_Caja.Click
        Dim _Nombre_Objeto = Fx_Trae_Nombre_Objeto("BoxRec")
        Fx_Crear_Caja(_Nombre_Objeto, PosicionX, PosicionY, True)
    End Sub

    Private Sub Btn_Insertar_Linea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Insertar_Linea.Click
        Fx_Crear_Linea(PosicionX, 200, PosicionY)
    End Sub

    Private Sub Btn_Mnu_Txt_Editar_Texto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Txt_Editar_Texto.Click
        Sb_Objeto_Editar_Texto()
    End Sub

    Sub Sb_Objeto_Editar_Texto()

        Dim _Texto As String = CType(ObjetoActivo, Label).Text
        Dim _Aceptado As Boolean

        _Aceptado = InputBox_Bk(Me, "Escriba el texto", "TEXTO LIBRE", _Texto, False,
                             _Tipo_Mayus_Minus.Normal, , True, _Tipo_Imagen.Texto, True, _Tipo_Caracter.Cualquier_caracter)

        If _Aceptado Then
            CType(ObjetoActivo, Label).Text = _Texto
            Sb_Editar_Objeto(ObjetoActivo)
        End If

    End Sub

    Private Sub Btn_Mnu_Txt_Editar_Fuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Txt_Editar_Fuente.Click
        _Clas_Formato.Fx_Editar_Fuente(ObjetoActivo)
    End Sub

    Private Sub Btn_Mnu_Txt_Editar_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Txt_Editar_Color.Click

        If _Clas_Formato.Fx_Editar_Color Then

            Dim _Color As Color = _Clas_Formato.Pro_Color
            Dim _NroColor = _Clas_Formato.Pro_NroColor

            CType(ObjetoActivo, Label).ForeColor = Color.FromArgb(_NroColor)
            Sb_Editar_Objeto(ObjetoActivo)

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Mnu_Caja_Editar_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Caja_Editar_Color.Click

        If _Clas_Formato.Fx_Editar_Color Then

            Dim _Color As Color = _Clas_Formato.Pro_Color
            CType(ObjetoActivo, RectangleShape).BorderColor = _Color 'Color.FromArgb(Str)
            Sb_Editar_Objeto(ObjetoActivo)

        End If

    End Sub

    Private Sub Btn_Mnu_Cmb_Ancho_Linea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Cmb_Ancho_Linea.SelectedIndexChanged

        Dim _Ancho = Btn_Mnu_Cmb_Ancho_Linea.SelectedIndex
        CType(ObjetoActivo, RectangleShape).BorderWidth = _Ancho
        Sb_Editar_Objeto(ObjetoActivo)

    End Sub

    Private Sub Btn_Mnu_Imagen_Editar_Imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Imagen_Editar_Imagen.Click

        If _Clas_Formato.Fx_Editar_Imagen(_Dir_Ruta_Imagenes) Then

            CType(ObjetoActivo, PictureBox).ImageLocation = _Clas_Formato.Pro_RutaImagen
            Sb_Editar_Objeto(ObjetoActivo)

        End If

    End Sub

    Private Sub Btn_Mnu_Caja_Redondear_Bordes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Caja_Redondear_Bordes.Click

        If Btn_Mnu_Caja_Redondear_Bordes.Checked Then
            CType(ObjetoActivo, RectangleShape).CornerRadius = 15
        Else
            CType(ObjetoActivo, RectangleShape).CornerRadius = 0
        End If

        Sb_Editar_Objeto(ObjetoActivo)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Sb_Copiar_Objeto(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Nombre_Objeto_Copiado = ObjetoActivo.Name
    End Sub

    Private Sub Btn_Pegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pegar.Click

        Dim _Objeto_Copiado As Object
        Dim _Nuevo_Objeto As Object

        Dim _Tipo = Mid(_Nombre_Objeto_Copiado, 1, 3)

        Select Case _Tipo
            Case "Txt", "Lbl", "Pic"
                For Each Ctrl In Documento.Controls
                    ' No asignar estos evento al botón salir
                    If Ctrl.Name <> "ShapeContainer1" And Ctrl.Name <> "LblVersion" Then
                        If Ctrl.Name = _Nombre_Objeto_Copiado Then
                            _Objeto_Copiado = Ctrl
                            Exit For
                        End If
                    End If
                Next
            Case "Box", "Lin"
                For Each _Ctrl In ShapeContainer1.Shapes
                    Dim _Tip As String = Mid(_Ctrl.Name, 1, 3)
                    If _Tip = "Box" Or _Tip = "Lin" Then
                        If _Ctrl.Name = _Nombre_Objeto_Copiado Then
                            _Objeto_Copiado = _Ctrl
                            Exit For
                        End If
                    End If
                Next
        End Select

        Dim _X, _X2 As Integer
        Dim _Y, _Y2 As Integer

        If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then
            _X = CType(_Objeto_Copiado, Control).Left
            _Y = CType(_Objeto_Copiado, Control).Top
        ElseIf _Tipo = "Box" Then
            _X = CType(_Objeto_Copiado, RectangleShape).Location.X
            _Y = CType(_Objeto_Copiado, RectangleShape).Location.Y
        End If

        Dim _Nombre_Objeto As String

        Select Case _Tipo

            Case "Txt"

                _Nombre_Objeto = Fx_Trae_Nombre_Objeto("TxtBox")
                _Nuevo_Objeto = Fx_Crear_Txt(_Nombre_Objeto, PosicionX, PosicionY, "", True)

                Dim _Texto As String = CType(_Objeto_Copiado, Control).Text
                _Nuevo_Objeto.text = _Texto

                Dim _FontName = CType(_Objeto_Copiado, Control).Font.Name
                Dim _FontSize = CType(_Objeto_Copiado, Control).Font.Size
                Dim _FontStyle = CType(_Objeto_Copiado, Control).Font.Style

                _Nuevo_Objeto.Font = New System.Drawing.Font(_FontName, _FontSize, _FontStyle)

                Dim _Color As Color = CType(_Objeto_Copiado, Control).ForeColor
                Dim _NroColor = _Color.ToArgb

                CType(_Nuevo_Objeto, Label).ForeColor = Color.FromArgb(_NroColor)

            Case "Pic"

                Dim _RutaImagen
                _Nombre_Objeto = Fx_Trae_Nombre_Objeto("PictBox")

                Dim _W = CType(_Objeto_Copiado, PictureBox).Width
                Dim _H = CType(_Objeto_Copiado, PictureBox).Height

                _RutaImagen = CType(_Objeto_Copiado, PictureBox).ImageLocation
                CType(_Nuevo_Objeto, PictureBox).Size() = New System.Drawing.Size(_W, _H)

                _Nuevo_Objeto = Fx_Crear_Imagen(_Nombre_Objeto, PosicionX, PosicionY, _RutaImagen, True)

            Case "Box"

                _Nombre_Objeto = Fx_Trae_Nombre_Objeto("BoxRec")
                Dim _Ancho = CType(_Objeto_Copiado, RectangleShape).BorderWidth
                Dim _Ancho_Obj = CType(_Objeto_Copiado, RectangleShape).Width
                Dim _Largo_Obj = CType(_Objeto_Copiado, RectangleShape).Height
                Dim _Esquina = CType(_Objeto_Copiado, RectangleShape).CornerRadius

                _Nuevo_Objeto = Fx_Crear_Caja(_Nombre_Objeto, PosicionX, PosicionY, True)

                CType(_Nuevo_Objeto, RectangleShape).BorderColor = CType(_Objeto_Copiado, RectangleShape).BorderColor
                CType(_Nuevo_Objeto, RectangleShape).Size() = New System.Drawing.Size(Math.Round(_Ancho_Obj), Math.Round(_Largo_Obj))
                CType(_Nuevo_Objeto, RectangleShape).BorderWidth = _Ancho
                CType(_Nuevo_Objeto, RectangleShape).CornerRadius = _Esquina

                'Dim _Color = CType(_Nuevo_Objeto, Control).ForeColor.ToArgb
                'Dim _Estilo As Integer

                'If CBool(CType(_Nuevo_Objeto, RectangleShape).CornerRadius) Then
                '    _Estilo = 1
                'Else
                '    _Estilo = 0
                'End If

                '_Row_NuevaFila.Item("Color") = _Color
                '_Row_NuevaFila.Item("Tamano") = CType(_Nuevo_Objeto, RectangleShape).Size()
                '_Row_NuevaFila.Item("Ancho") = _Color
                '_Row_NuevaFila.Item("Esquina") = _Color

        End Select

        Sb_Editar_Objeto(_Nuevo_Objeto)

    End Sub


    Sub Sb_Editar_Posicion_Manualmente()

        Dim _X = ObjetoActivo.Location.X 'CType(ObjetoActivo, Control).Left
        Dim _Y = ObjetoActivo.Location.Y ' CType(ObjetoActivo, Control).Top

        Dim _Maximo_X = Documento.Width
        Dim _Maximo_Y = Documento.Height

        Dim Fm As New Frm_Formato_Diseno_Editar_Posicion(_Maximo_X, _Maximo_Y, _FormPadre)
        Fm.Pro_X = _X
        Fm.Pro_Y = _Y
        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            _FormPadre.Sld_Ubicacion_X.Value = Fm.Pro_X
            _FormPadre.Sld_Ubicacion_Y.Value = Fm.Pro_Y

            Sb_Editar_Objeto(ObjetoActivo)

        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Funcion_Editar_Fuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Funcion_Editar_Fuente.Click
        _Clas_Formato.Fx_Editar_Fuente(ObjetoActivo)
        Sb_Editar_Objeto(ObjetoActivo)
    End Sub

    Private Sub Btn_Mnu_Funcion_Editar_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Funcion_Editar_Color.Click

        If _Clas_Formato.Fx_Editar_Color Then

            Dim _Color As Color = _Clas_Formato.Pro_Color
            Dim _NroColor = _Clas_Formato.Pro_NroColor

            CType(ObjetoActivo, Label).ForeColor = Color.FromArgb(_NroColor)
            Sb_Editar_Objeto(ObjetoActivo)

        End If

        Me.Refresh()

    End Sub

    Sub Sb_Editar_Objeto(_Objeto As Object)

        Dim _Fila As DataRow

        For Each _Fl As DataRow In _Tbl_Zw_Format_02.Rows

            Dim _Name = _Fl.Item("Name")
            Dim _Name_Objet = _Objeto.Name 'CType(_Objeto, Control).Name

            If _Name = _Name_Objet Then

                _Fila = _Fl
                Exit For

            End If

        Next

        If IsNothing(_Fila) Then
            Return
        End If

        Dim _Nombre_Etiqueta = _Objeto.Name

        Dim _NombreObjeto = ""
        Dim _Seccion = ""
        Dim _TipoDato
        Dim _Funcion
        Dim _Formato
        Dim _CantDecimales
        Dim _Texto
        Dim _RutaImagen
        Dim _Alto
        Dim _Ancho
        Dim _Borde_Variable As Integer = 0
        Dim _Orden_Detalle As Integer = 0
        Dim _Mostrar_En_Concepto As Boolean = True

        Dim Tipo = Mid(_Nombre_Etiqueta, 1, 3)

        If Tipo = "Txt" Then

            _NombreObjeto = "Texto_libre"
            _TipoDato = "C"
            _Funcion = String.Empty
            _RutaImagen = String.Empty
            _Formato = "CA"
            _Texto = _Objeto.Text
            _CantDecimales = 0
            _Mostrar_En_Concepto = NuloPorNro(_Fila.Item("Mostrar_En_Concepto"), False)

        ElseIf Tipo = "Lbl" Then

            _NombreObjeto = "Funcion"
            _TipoDato = "C"
            _Funcion = String.Empty

            If Mid(_Nombre_Etiqueta, 1, 5) = "LblFx" Then

                _Funcion = _Fila.Item("Funcion")
                _TipoDato = _Fila.Item("TipoDato")
                _Borde_Variable = _Fila.Item("Borde_Variable")
                _Orden_Detalle = _Fila.Item("Orden_Detalle")
                _Mostrar_En_Concepto = _Fila.Item("Mostrar_En_Concepto")

            End If

            _RutaImagen = String.Empty
            _Formato = "CA"
            _Texto = _Objeto.Text
            _CantDecimales = 0

        ElseIf Tipo = "Pic" Then

            _NombreObjeto = "Imagen"
            _TipoDato = "I"
            _Funcion = _Objeto.Text

            Try
                _RutaImagen = CType(_Objeto, PictureBox).ImageLocation.ToString
                Dim _Archivo = Split(_RutaImagen, "\")

                Dim _II = _Archivo.Length
                _Texto = _Archivo(_II - 1)

            Catch ex As Exception
                _RutaImagen = String.Empty
                _Texto = String.Empty
            End Try

            _Formato = "IM"
            _CantDecimales = 0

        ElseIf Tipo = "Box" Then

            _NombreObjeto = "Caja"
            _TipoDato = "B"
            _Funcion = String.Empty
            _RutaImagen = String.Empty
            _Formato = "BX"
            _Texto = String.Empty
            _CantDecimales = 0

        ElseIf Tipo = "Lin" Then

            _NombreObjeto = "Linea"
            _TipoDato = "L"
            _Funcion = String.Empty
            _RutaImagen = String.Empty
            _Formato = "LN"
            _Texto = String.Empty
            _CantDecimales = 0

        End If

        Dim _Columna_X As Integer
        Dim _Fila_Y As Integer

        Dim _Fuente As String
        Dim _Tamano As Single
        Dim _Estilo As String
        Dim _Color ' = CType(_Objeto, Control).ForeColor.ToArgb

        If Tipo <> "Box" And Tipo <> "Lin" Then

            _Columna_X = CType(_Objeto, Control).Location.X.ToString
            _Fila_Y = CType(_Objeto, Control).Location.Y.ToString

            _Alto = CType(_Objeto, Control).Height
            _Ancho = CType(_Objeto, Control).Width

            _Fuente = CType(_Objeto, Control).Font.Name
            _Tamano = CType(_Objeto, Control).Font.Size
            _Estilo = CType(_Objeto, Control).Font.Style
            _Color = CType(_Objeto, Control).ForeColor.ToArgb

        ElseIf Tipo = "Box" Then

            Dim _Locacion = CType(_Objeto, RectangleShape).Location
            _Columna_X = _Locacion.X
            _Fila_Y = _Locacion.Y

            Dim _Size = CType(_Objeto, RectangleShape).Size
            _Alto = _Size.Height
            _Ancho = _Size.Width

            _Fuente = String.Empty
            _Tamano = CType(_Objeto, RectangleShape).BorderWidth

            If CBool(CType(_Objeto, RectangleShape).CornerRadius) Then
                _Estilo = 1
            Else
                _Estilo = 0
            End If

            _Color = CType(_Objeto, RectangleShape).BorderColor.ToArgb

        ElseIf Tipo = "Lin" Then

            Dim _Locacion = CType(_Objeto, LineShape).X1

            Dim _X1 = CType(_Objeto, LineShape).X1
            Dim _X2 = CType(_Objeto, LineShape).X2

            Dim _Y1 = CType(_Objeto, LineShape).Y1
            Dim _Y2 = CType(_Objeto, LineShape).Y2

            _Columna_X = _X1

            _Fila_Y = _Y1

            _Alto = CType(_Objeto, LineShape).BorderWidth
            _Ancho = _X2 - _X1

            _Fuente = String.Empty
            _Tamano = CType(_Objeto, LineShape).BorderWidth

            _Estilo = 0
            _Color = CType(_Objeto, LineShape).BorderColor.ToArgb

        End If


        If _Fila_Y < XLineaDetalle.Y1 Then 'Encabezado

            _Seccion = "E"

        ElseIf _Fila_Y < XLineaPie.Y1 Then 'Detalle

            _Seccion = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Format_Fx", "Seccion", "Nombre_Funcion = '" & _Funcion & "'")

            If String.IsNullOrEmpty(_Seccion) Then
                _Seccion = "D"
                _Orden_Detalle = 1
            End If

        Else

            _Seccion = "P" 'Pie

        End If

        Dim _Alto_Doc = Documento.Height

        If _Fila_Y <= _Alto_Doc Then

            _Fila.Item("Eliminado") = False
            _Fila.Item("NombreObjeto") = _NombreObjeto
            _Fila.Item("TipoDoc") = _TipoDoc
            _Fila.Item("NombreFormato") = _NombreFormato
            _Fila.Item("Emdp") = _Emdp

            _Fila.Item("Seccion") = _Seccion
            _Fila.Item("TipoDato") = _TipoDato
            _Fila.Item("Funcion") = _Funcion
            _Fila.Item("Formato") = _Formato
            _Fila.Item("CantDecimales") = _CantDecimales
            _Fila.Item("Fuente") = _Fuente
            _Fila.Item("Tamano") = _Tamano
            _Fila.Item("Alto") = _Alto
            _Fila.Item("Ancho") = _Ancho
            _Fila.Item("Estilo") = _Estilo
            _Fila.Item("Color") = _Color
            _Fila.Item("Fila_Y") = _Fila_Y
            _Fila.Item("Columna_X") = _Columna_X
            _Fila.Item("Texto") = _Texto
            _Fila.Item("RutaImagen") = _RutaImagen
            _Fila.Item("Borde_Variable") = _Borde_Variable
            _Fila.Item("Orden_Detalle") = _Orden_Detalle
            _Fila.Item("Mostrar_En_Concepto") = _Mostrar_En_Concepto

        End If

        Control_Fin_Detalle(Nothing, Nothing)

    End Sub

    Private Sub Btn_Cambiar_Formato_Objeto_Funcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Formato_Objeto_Funcion.Click

        Dim _Nombre_Objeto = CType(ObjetoActivo, Label).Name

        For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

            Dim _Name = _Fila.Item("Name")
            Dim _Name_Objet = ObjetoActivo.Name 'CType(_Objeto, Control).Name

            If _Name = _Name_Objet Then

                Dim _Funcion = _Fila.Item("Funcion")
                Dim _TipoDato = _Fila.Item("TipoDato")

                Select Case _TipoDato

                    Case "C", "N"
                        Sb_Cambiar_Formato(_Funcion)
                    Case "F"

                        Select Case CType(ObjetoActivo, Label).Text
                            Case "DD/MM/AAAA"
                                Rdb_Formato_01.Checked = True
                            Case "DD-MM-AAAA"
                                Rdb_Formato_02.Checked = True
                            Case Else
                                Rdb_Formato_03.Checked = True
                        End Select

                        ShowContextMenu(Menu_Contextual_Funcion_Fecha)

                End Select

                Exit For

            End If

        Next

    End Sub

    Sub Sb_Cambiar_Formato(ByVal _Nombre_Formato As String)

        Consulta_Sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Format_Fx" & vbCrLf &
                       "Where Nombre_Funcion = '" & _Nombre_Formato & "'"

        Dim _Row_Formato As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row_Formato) Then
            MessageBoxEx.Show(Me, "No existe la función: " & _Nombre_Formato, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Formato = CType(ObjetoActivo, Label).Text

        Dim _Formato_Original As String = _Row_Formato.Item("Formato")
        Dim _Tipo_de_dato As String = _Row_Formato.Item("Tipo_de_dato")
        Dim _Max_Carac = Len(_Formato_Original)
        Dim _Aceptado As Boolean

        If _Tipo_de_dato = "N" Then

            Dim Fm As New Frm_Formatos_Numericos(_Formato)
            Fm.Text = "Formato: " & _Nombre_Formato
            Fm.ShowDialog(Me)
            _Aceptado = Fm.Pro_Aceptar
            Fm.Dispose()

            If _Aceptado Then
                _Formato = Fm.Pro_Formato
            End If

        ElseIf _Tipo_de_dato = "C" Then
            _Aceptado = InputBox_Bk(Me, "Ingrese formato", "Formato de la función", _Formato,
                               True, _Tipo_Mayus_Minus.Mayusculas, 0,
                               True, _Tipo_Imagen.Texto, False, _Tipo_Caracter.Cualquier_caracter)
        End If

        If _Aceptado Then
            CType(ObjetoActivo, Label).Text = _Formato
            Me.ToolTip1.SetToolTip(CType(ObjetoActivo, Label), "Función: " & UCase(_Formato))
            Sb_Editar_Objeto(ObjetoActivo)
        End If

    End Sub

    Private Sub Chk_Mostrar_En_Concepto_Click(sender As Object, e As EventArgs) Handles Chk_Mostrar_En_Concepto.Click

        Dim _Nombre_Objeto = CType(ObjetoActivo, Label).Name

        Dim _Fila As DataRow

        For Each _Fl As DataRow In _Tbl_Zw_Format_02.Rows

            Dim _Name = _Fl.Item("Name")

            If _Name = _Nombre_Objeto Then

                _Fila = _Fl
                Exit For

            End If

        Next

        If IsNothing(_Fila) Then
            Return
        End If

        _Fila.Item("Mostrar_En_Concepto") = Chk_Mostrar_En_Concepto.Checked

        Sb_Editar_Objeto(ObjetoActivo)

    End Sub

    Sub Sb_Rdb_Clic()

        Dim _Formato As String

        Dim _Nombre_Objeto = CType(ObjetoActivo, Label).Name

        If Rdb_Formato_01.Checked Then
            _Formato = "DD/MM/AAAA"
        ElseIf Rdb_Formato_02.Checked Then
            _Formato = "DD-MM-AAAA"
        ElseIf Rdb_Formato_03.Checked Then
            _Formato = "LONG DATE"
        ElseIf Rdb_Formato_04.Checked Then
            _Formato = "DD"
        ElseIf Rdb_Formato_05.Checked Then
            _Formato = "MM"
        ElseIf Rdb_Formato_06.Checked Then
            _Formato = "AAAA"
        ElseIf Rdb_Formato_07.Checked Then
            _Formato = "AA"
        ElseIf Rdb_Formato_08.Checked Then
            _Formato = "DIA PALABRA"
        ElseIf Rdb_Formato_09.Checked Then
            _Formato = "MES PALABRA"
        End If

        CType(ObjetoActivo, Label).Text = _Formato
        Me.ToolTip1.SetToolTip(CType(ObjetoActivo, Label), "Función: " & UCase(_Formato))

    End Sub

    Private Sub Btn_Insertar_Funcion_Encabezado_Pie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Insertar_Funcion_Encabezado_Pie.Click
        Dim _Nombre_Objeto = Fx_Trae_Nombre_Objeto("LblFx")
        Fx_Crear_Funcion(_Nombre_Objeto, PosicionX, PosicionY, "", "", "", Enum_Seccion.Encabezado, False, 1, True, False)
    End Sub

    Private Sub Btn_Insertar_Funcion_Detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Insertar_Funcion_Detalle.Click
        Dim _Nombre_Objeto = Fx_Trae_Nombre_Objeto("LblFx")
        Fx_Crear_Funcion(_Nombre_Objeto, PosicionX, PosicionY, "", "", "", Enum_Seccion.Detalle, False, 1, True, True)
    End Sub

    Private Sub Rdb_Orden_Impresion_Fila1_Funcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Orden_Impresion_Fila1_Funcion.Click
        Sb_Rdb_Orden_Impresion_Fila_Funcion()
    End Sub

    Private Sub Rdb_Orden_Impresion_Fila2_Funcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Orden_Impresion_Fila2_Funcion.Click
        Sb_Rdb_Orden_Impresion_Fila_Funcion()
    End Sub

    Sub Sb_Rdb_Orden_Impresion_Fila_Funcion()

        Dim _Nombre_Objeto = CType(ObjetoActivo, Label).Name

        Dim _Fila As DataRow

        For Each _Fl As DataRow In _Tbl_Zw_Format_02.Rows

            Dim _Name = _Fl.Item("Name")

            If _Name = _Nombre_Objeto Then

                _Fila = _Fl
                Exit For

            End If

        Next

        If IsNothing(_Fila) Then
            Return
        End If

        Dim _Orden = 1

        If Rdb_Orden_Impresion_Fila2_Funcion.Checked Then
            _Orden = 2
        End If

        _Fila.Item("Orden_Detalle") = _Orden

        Sb_Editar_Objeto(ObjetoActivo)

    End Sub

End Class
