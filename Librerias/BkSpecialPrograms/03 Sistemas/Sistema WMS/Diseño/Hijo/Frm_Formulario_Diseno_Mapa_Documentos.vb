Imports System.Drawing.Color
Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.PowerPacks
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Formulario_Diseno_Mapa_Documentos

#Region "VARIABLES"

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private DX, DY As Integer
    Public ObjetoActivo As Object
    Dim _Nombre_Objeto_Copiado As String
    Dim _Tipo_Objeto_Copiado As String

    Dim PosicionX, PosicionY As Integer
    Dim FilaPosicionSeleccionada As Object = LineaDetalle
    Dim PanelActivo As Control

    Dim _Objeto_Copiado As Object

    Dim TipoDos As String
    Dim NombreFormato As String

    'Public _TipoDoc, _NombreFormato As String
    'Public _Editar_Documento As Boolean
    'Public _Nuevo_Formato As Boolean


    Dim _Line_Aj_1, _Line_Aj_2 As Object
    Dim _Alto_Caja, _Ancho_Caja As Integer

    Dim _RowMapa As DataRow

    Dim _Id_Mapa As Integer
    Dim _Nombre_Mapa As String
    Dim _Codigo_Sector_Activo As String
    Dim _Configuracion_Diseno As _TipoDiseno
    'Dim _Ancho_Mapa, _Largo_Mapa As Integer
    'Dim _Escala_Mapa As Integer

    Public _RowBodega As DataRow
    Dim _Empresa
    Dim _Sucursal
    Dim _Bodega

    Dim Fm_Propiedades As New Frm_Mapa_Diseno_Elementos

    Public _RowProducto As DataRow
    Public _FormPadre As Object

    Dim _Imprimir_Cod_Barras_Ubicaciones As Boolean

    Dim _Cerrar_Formulario As Boolean

    Dim _Sectores(1000, 2) As String

    Public ReadOnly Property Pro_Sectores() As String(,)
        Get
            Return _Sectores
        End Get
    End Property

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

    Dim _Clas_Formato As New Clas_Formato_Herramientas_Mapa

#End Region

    Public Property Pro_Imprimir_Cod_Barras_Ubicaciones() As Boolean
        Get
            Return _Imprimir_Cod_Barras_Ubicaciones
        End Get
        Set(ByVal value As Boolean)
            _Imprimir_Cod_Barras_Ubicaciones = value
        End Set
    End Property

    Public ReadOnly Property Pro_Id_Mapa() As Integer
        Get
            Return _Id_Mapa
        End Get
    End Property

    Public ReadOnly Property Pro_Row_Mapa()
        Get
            Return _RowMapa
        End Get
    End Property

    Public Property Pro_Cerrar_Formulario() As Boolean
        Get
            Return _Cerrar_Formulario
        End Get
        Set(ByVal value As Boolean)
            _Cerrar_Formulario = value
        End Set
    End Property

    Public Sub New(ByVal RowMapa As DataRow,
                   ByVal Configuracion_Diseno As _TipoDiseno)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _RowMapa = RowMapa

        _Id_Mapa = _RowMapa.Item("Id_Mapa")
        _Nombre_Mapa = _RowMapa.Item("Nombre_Mapa")

        _Empresa = _RowMapa.Item("Empresa")
        _Sucursal = _RowMapa.Item("Sucursal")
        _Bodega = _RowMapa.Item("Bodega")

        _Configuracion_Diseno = Configuracion_Diseno

    End Sub

    Private Sub Frm_Formulario_Diseno_Mapa_Documentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '_FormPadre = Me.Parent

        ' Dim _Escala As Double = 100 / (_Tamano_Escala * 100)

        _Tamano_Escala = 3

        Dim _Largo_Mapa = 3000
        Dim _Ancho_Mapa = 3000

        '_Empresa = _RowBodega.Item("EMPRESA")
        '_Sucursal = _RowBodega.Item("KOSU")
        '_Bodega = _RowBodega.Item("KOBO")

        'RotarElementoToolStripMenuItem.Visible = True
        'VerTamañoDelElementoEnEscalaToolStripMenuItem.Visible = True
        'ClonarElementoToolStripMenuItem.Visible = False

        ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(LineaDetalle.Name))
        ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(LineaPie.Name))

        Documento.Width = _Largo_Mapa '_Escala * _Largo_Mapa
        Documento.Height = _Ancho_Mapa '_Escala * _Ancho_Mapa

        LineaDetalle.Y1 = 100 : LineaDetalle.Y2 = 100
        LineaDetalle.X1 = 1 : LineaDetalle.X2 = 1000

        Documento.BackColor = White

        With Me
            .BackColor = White
            .ForeColor = Black
            .Text = _Nombre_Mapa
            '.Size = New System.Drawing.Size(1161, 644)
            .MinimumSize = New System.Drawing.Size(700, 0)
            '.VerticalScroll.Value = 100
            '.HorizontalScroll.Value = 100
            '.StartPosition = FormStartPosition.CenterScreen
        End With

        'Panel1.HorizontalScroll.Value = 300
        'Panel1.VerticalScroll.Value = 200

        Sb_Abrir_Mapas()

        If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then

            'Documento.ContextMenuStrip = Cmnu_Herramientas_diseno_mapa

            AddHandler Btn_Mnu_Agregar_Escalera.Click, AddressOf Cmnu_Herramientas_diseno_mapa_Click
            AddHandler Btn_Mnu_Agregar_Muro.Click, AddressOf Cmnu_Herramientas_diseno_mapa_Click
            AddHandler Btn_Mnu_Agregar_Pilar.Click, AddressOf Cmnu_Herramientas_diseno_mapa_Click
            AddHandler Btn_Mnu_Agregar_Puerta.Click, AddressOf Cmnu_Herramientas_diseno_mapa_Click
            AddHandler Btn_Mnu_Agregar_Ventana.Click, AddressOf Cmnu_Herramientas_diseno_mapa_Click

            AddHandler Btn_Mnu_Agregar_Sector.Click, AddressOf Mnu_Crear_Sector_Click


            AddHandler Btn_Mnu_Sector_Editar_Fuente.Click, AddressOf Btn_Mnu_Objeto_Editar_Fuente_Click
            AddHandler Btn_Mnu_Sector_Editar_Color_Fuente.Click, AddressOf Btn_Mnu_Objeto_Editar_Color_Fuente_Click
            AddHandler Btn_Mnu_Sector_Editar_Color_Fondo.Click, AddressOf Btn_Mnu_Objeto_Editar_Color_Fondo_Click
            AddHandler Btn_Mnu_Sector_Copiar.Click, AddressOf Btn_Mnu_Objeto_Copiar_Click
            AddHandler Btn_Mnu_Sector_Rotar.Click, AddressOf Btn_Mnu_Objeto_Rotar_Click
            AddHandler Btn_Mnu_Sector_Eliminar.Click, AddressOf Btn_Mnu_Objeto_Eliminar_Click

            AddHandler Btn_Mnu_Etiqueta_Editar_Fuente.Click, AddressOf Btn_Mnu_Objeto_Editar_Fuente_Click
            AddHandler Btn_Mnu_Etiqueta_Editar_Color_Fuente.Click, AddressOf Btn_Mnu_Objeto_Editar_Color_Fuente_Click
            AddHandler Btn_Mnu_Etiqueta_Editar_Color_Fondo.Click, AddressOf Btn_Mnu_Objeto_Editar_Color_Fondo_Click
            AddHandler Btn_Mnu_Etiqueta_Copiar.Click, AddressOf Btn_Mnu_Objeto_Copiar_Click
            AddHandler Btn_Mnu_Etiqueta_Rotar.Click, AddressOf Btn_Mnu_Objeto_Rotar_Click
            AddHandler Btn_Mnu_Etiqueta_Eliminar.Click, AddressOf Btn_Mnu_Objeto_Eliminar_Click


            ' AddHandler Btn_nu_Sector_Eliminar.Click, AddressOf Sb_MnuEliminar_Elemento_Click

            AddHandler Btn_Mnu_Agregar_Etiqueta.Click, AddressOf Sb_Crear_EtiquetaComentario_click
            AddHandler Btn_Mnu_Sector_Ubicaciones.Click, AddressOf Control_Ubicacion_Asignar_Productos_Clic
            AddHandler Btn_Mnu_Pegar.Click, AddressOf Btn_Mnu_Objeto_Pegar_Click

        ElseIf _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Crear_Ubicaciones Then

            'AddHandler Btn_Mnu_Objeto_Sector_Ubicaciones.Click, AddressOf Control_Ubicacion_Asignar_Productos_Clic
            'AddHandler Btn_Grabar.Click, AddressOf Sb_Btn_Grabar_Click

        ElseIf _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Asignar_Ubicaciones Then

            ' AddHandler Btn_Grabar.Click, AddressOf Sb_Btn_Grabar_Click
        ElseIf _Configuracion_Diseno = _TipoDiseno.Mapa_Ver_Mapa Then


            For Each ctr As Control In Documento.Controls
                Dim _Texto = ctr.Text 'CType(ctr, Control).Name

                If _Texto = _Codigo_Sector_Activo Then
                    ObjetoActivo = ctr
                End If
            Next

            Timer1.Enabled = True
        End If

        'Regla_X.Width = Documento.Width
        'Regla_Y.Height = Documento.Height

    End Sub

    Public Property Pro_Codigo_Sector_Activo() As String
        Get
            Return _Codigo_Sector_Activo
        End Get
        Set(ByVal value As String)
            _Codigo_Sector_Activo = value
        End Set
    End Property

#Region "PROCEDIMIENTOS"

#Region "CREAR OBJETOS PARA DISEÑO DE MAPA DE BODEGA"



#Region "CREAR NUEVO ELEMENTO"

    Private Sub Cmnu_Herramientas_diseno_mapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _NomObjet As String = sender.Name
        Dim _Elemento As _TipoElemento

        Select Case _NomObjet

            Case "Btn_Mnu_Agregar_Escalera"
                _Elemento = _TipoElemento.ESCALERA
            Case "Btn_Mnu_Agregar_Muro"
                _Elemento = _TipoElemento.MURO
            Case "Btn_Mnu_Agregar_Pilar"
                _Elemento = _TipoElemento.PILAR
            Case "Btn_Mnu_Agregar_Puerta"
                _Elemento = _TipoElemento.PUERTA
            Case "Btn_Mnu_Agregar_Ventana"
                _Elemento = _TipoElemento.VENTANA
                ' Case "Mnu_Estanteria"
                '     _Elemento = _TipoElemento.b_Estanteria
                ' Case "Mnu_Ganchos"
                '     _Elemento = _TipoElemento.b_Ganchos
                ' Case "Mnu_Mueble"
                '     _Elemento = _TipoElemento.b_Mueble
                ' Case "Mnu_Vitrina"
                '     _Elemento = _TipoElemento.b_Vitrina
            Case "Mnu_Sector"
        End Select

        Dim _NuevoObjeto As Object

        _NuevoObjeto = Fx_Crear_Elemento(PosicionX, PosicionY, White, Black, _Elemento)

        If Not (_NuevoObjeto Is Nothing) Then

            Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {_NuevoObjeto})

            _NuevoObjeto.focus()
            _NuevoObjeto.BringToFront()
            ObjetoActivo = _NuevoObjeto
            'Sb_Ver_Propiedad_de_Objeto_Mapa()

        End If

    End Sub




#End Region

#Region "CREAR SECTOR DE BODEGA"

    Sub Mnu_Crear_Sector_Click()

        Dim _NuevoObjeto As LabelX = Fx_Crear_Sector(PosicionX, PosicionY, Green, White, _TipoElemento.SECTOR, , , ,
                                                     "Courier New", 10, FontStyle.Regular)

        If Not (_NuevoObjeto Is Nothing) Then

            _NuevoObjeto.BackColor = LightSteelBlue 'WhiteSmoke 'White '_BackColor
            _NuevoObjeto.ForeColor = Black '

            Documento.Controls.Add(_NuevoObjeto)

            _NuevoObjeto.Focus()
            _NuevoObjeto.BringToFront()
            ObjetoActivo = _NuevoObjeto
            'Sb_Ver_Propiedad_de_Objeto_Mapa()
        End If

    End Sub


    'Private Function Fx_Crear_Sector(ByVal _X_Columna As Integer, _
    '                                 ByVal _Y_Fila As Integer, _
    '                                 ByVal _BackColor As Color, _
    '                                ByVal _ForeColor As Color, _
    '                                 ByVal _Tipo_Objeto As _TipoElemento, _
    '                                 Optional ByVal _Nombre_Objeto As String = "", _
    '                                 Optional ByVal _Codigo_Sector As String = "", _
    '                                 Optional ByVal _Texto As String = "", _
    '                                 Optional ByVal _Font_Nombre As String = "", _
    '                                 Optional ByVal _Font_Tamano As Integer = 10, _
    '                                 Optional ByVal _Font_Negrita As Boolean = False, _
    '                                 Optional ByVal _Font_Italic As Boolean = False, _
    '                                 Optional ByVal _Font_Tachado As Boolean = False, _
    '                                 Optional ByVal _Font_Subrayado As Boolean = False, _
    '                                 Optional ByVal _Alto_H As Integer = 0, _
    '                                 Optional ByVal _Ancho_W As Integer = 0, _
    '                                 Optional ByVal _Relleno As Boolean = False, _
    '                                 Optional ByVal _Orientacion As Boolean = False, _
    '                                 Optional ByVal _Mapa As _TipoDiseno = _TipoDiseno.Mapa_Bodega_Diseño, _
    '                                 Optional ByVal _Nombre_Sector As String = "")

    Private Function Fx_Crear_Sector(ByVal _X_Columna As Integer,
                                     ByVal _Y_Fila As Integer,
                                     ByVal _BackColor As Color,
                                     ByVal _ForeColor As Color,
                                     ByVal _Tipo_Objeto As _TipoElemento,
                                     Optional ByVal _Nombre_Objeto As String = "",
                                     Optional ByVal _Codigo_Sector As String = "",
                                     Optional ByVal _Texto As String = "",
                                     Optional ByVal _Font_Nombre As String = "",
                                     Optional ByVal _Font_Tamano As Integer = 8.25,
                                     Optional ByVal _Font_Estilo As FontStyle = FontStyle.Regular,
                                     Optional ByVal _Alto_H As Integer = 0,
                                     Optional ByVal _Ancho_W As Integer = 0,
                                     Optional ByVal _Relleno As Boolean = False,
                                     Optional ByVal _Orientacion As Boolean = False,
                                     Optional ByVal _Mapa As _TipoDiseno = _TipoDiseno.Mapa_Bodega_Diseño,
                                     Optional ByVal _Nombre_Sector As String = "")


        Dim _LblSector As New LabelX

        Dim _Cont = 0


        If String.IsNullOrEmpty(_Nombre_Objeto) Then
            _Nombre_Objeto = Fx_Crear_Nombre_Nuevo_Objeto(_Tipo_Objeto)
        End If

        With _LblSector

            .Name = _Nombre_Objeto
            Dim _Aceptado As Boolean

            If String.IsNullOrEmpty(_Codigo_Sector) Then
                If _Tipo_Objeto = _TipoElemento.ETIQUETA Then

                    If String.IsNullOrEmpty(_Texto) Then

                        _Codigo_Sector = "COMENTARIO " & _Cont

                        _Aceptado = InputBox_Bk(Me, "DESCRIPCION DE ETIQUETA COMENTARIO", "CREAR COMENTARIO",
                                                _Codigo_Sector,
                                                True, _Tipo_Mayus_Minus.Normal, 50,
                                                True, _Tipo_Imagen.Ubicacion, False)
                    Else
                        _Codigo_Sector = _Texto
                        _Aceptado = True
                    End If

                ElseIf _Tipo_Objeto = _TipoElemento.SECTOR Then

                    Dim _Grabar As Boolean

                    Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa, Frm_Formulario_Diseno_Mapa_Crear_Sector._Enum_Accion.Nuevo)
                    Fm.ShowDialog(Me)
                    _Grabar = Fm.Pro_Grabar
                    _Codigo_Sector = Fm.Pro_Codigo_Sector
                    _Nombre_Sector = Fm.Pro_Nombre_Sector
                    Fm.Dispose()

                    If Not _Grabar Then
                        Return Nothing
                    End If
                    _Aceptado = _Grabar

                End If
            Else
                _Aceptado = True
            End If

            If Not _Aceptado Then
                Return Nothing
            Else
                _Texto = _Codigo_Sector
            End If

            Dim _Escala As Double = 100 / (3 * 100)

            If Not CBool(_Alto_H) And Not CBool(_Ancho_W) Then
                _Alto_H = 70 * _Escala
                _Ancho_W = 300 * _Escala
            End If

            .Text = _Texto
            .Location = New System.Drawing.Point(_X_Columna, _Y_Fila)

            .BackColor = _BackColor 'LightSteelBlue 'WhiteSmoke 'White '_BackColor
            .ForeColor = _ForeColor 'Black '

            .TextAlignment = StringAlignment.Center
            .Size() = New System.Drawing.Size(_Ancho_W, _Alto_H)
            .BorderType = eBorderType.SingleLine

            If Mid(.Name, 1, 5) = "LblFx" Then
                .Cursor = Cursors.Hand
            End If

            If _Orientacion Then
                .TextOrientation = eOrientation.Vertical
            Else
                .TextOrientation = eOrientation.Horizontal
            End If

            If _Tipo_Objeto = _TipoElemento.ETIQUETA Then
                .AutoSize = True
                .BorderType = eBorderType.None
                .BackColor = Transparent
                .ForeColor = Blue 'Black '
            End If

            If _Mapa = _TipoDiseno.Mapa_Bodega_Diseño Then
                AddHandler .MouseDown, AddressOf Me.Control_MouseDown
                AddHandler .MouseMove, AddressOf Me.Control_MouseMove
                AddHandler .Click, AddressOf Me.Control_Clic
                AddHandler .DoubleClick, AddressOf Me.Control_Double_Clic
                AddHandler .MouseUp, AddressOf Me.Control_MouseUP
                '.ContextMenuStrip = ContextMenuStrip1
            ElseIf _Mapa = _TipoDiseno.Mapa_Bodega_Crear_Ubicaciones Then
                AddHandler .Click, AddressOf Me.Control_Ubicacion_Diseño_Clic
                .ContextMenuStrip = Nothing
            ElseIf _Mapa = _TipoDiseno.Mapa_Bodega_Asignar_Ubicaciones Then
                AddHandler .Click, AddressOf Me.Control_Ubicacion_Asignar_Productos_Clic
                .ContextMenuStrip = Nothing
            End If


            _LblSector.Font = New System.Drawing.Font(_Font_Nombre, _Font_Tamano, _Font_Estilo)


            If _Tipo_Objeto = _TipoElemento.SECTOR Then

                With Documento
                    For Each ctr As Control In .Controls

                        Dim Tipo = ctr.Name 'CType(ctr, Control).Name
                        Dim Nom = Mid(Tipo, 1, 5)
                        If Nom = "LblFx" Then
                            _Cont += 1
                        End If
                    Next
                End With

                'Me.ToolTip1.SetToolTip(_LblSector, UCase(_Nombre_Sector))

                _Sectores(_Cont, 0) = .Name
                _Sectores(_Cont, 1) = _Texto
                _Sectores(_Cont, 2) = _Nombre_Sector
                _Sectores(_Cont + 1, 0) = "#Fin#"

            End If


            Return _LblSector
        End With
    End Function

#End Region

#Region "CREAR COMENTARIO"


    Sub Sb_Crear_EtiquetaComentario_click()

        Dim _NuevoObjeto As New LabelX
        _NuevoObjeto = Fx_Crear_Etiqueta()

        'Dim _NuevoObjeto As Object = Fx_Crear_Sector(PosicionX, PosicionY, Green, White, _TipoElemento.Sector)

        If Not (_NuevoObjeto Is Nothing) Then

            Documento.Controls.Add(_NuevoObjeto)

            _NuevoObjeto.Focus()
            _NuevoObjeto.BringToFront()
            ObjetoActivo = _NuevoObjeto
            'Sb_Ver_Propiedad_de_Objeto_Mapa()
        End If

        Documento.Controls.Add(_NuevoObjeto)


    End Sub

    Private Function Fx_Crear_Etiqueta()

        Dim _LblEtiqueta As New LabelX

        _LblEtiqueta = Fx_Crear_Sector(PosicionX, PosicionY, Transparent, Yellow, _TipoElemento.ETIQUETA, , , ,
                                       "Microsoft Sans Serif", 8.25, FontStyle.Regular)

        If Not (_LblEtiqueta Is Nothing) Then
            _LblEtiqueta.BackColor = Transparent 'LightSteelBlue 'WhiteSmoke 'White '_BackColor
            _LblEtiqueta.ForeColor = Blue 'Black '
        End If

        Return _LblEtiqueta

    End Function
#End Region

#Region "CLONAR ELEMENTO"

    Sub Sb_Clonar_Elemento_Mapa()

        Dim _Objeto_Clonado As New RectangleShape

        Dim Contador = 0

        With Documento '.Controls
            ' For Each _Ctrl In ShapeContainer1.Shapes
            For Each ctr In ShapeContainer1.Shapes
                Dim Tipo = ctr.Name 'CType(ctr, Control).Name
                Dim Nom = Mid(Tipo, 1, 3)

                If Mid(Tipo, 1, 3) = "Box" Then
                    Contador += 1
                End If
            Next
            If Contador = 0 Then Contador = 1
        End With


        Dim _Ancho_Obj ' = CType(ObjetoActivo, RectangleShape).Width
        Dim _Largo_Obj ' = CType(ObjetoActivo, RectangleShape).Height

        Dim _Y '= CType(ObjetoActivo, RectangleShape).Location.Y
        Dim _X '= CType(ObjetoActivo, RectangleShape).Location.X

        Dim _Relleno As FillStyle
        Dim _Color As Color
        Dim _Color_Borde As Color


        With CType(ObjetoActivo, RectangleShape)

            .Name = "BoxRec" & Contador
            '.Location = New System.Drawing.Point(PosicionX + 20, PosicionY + 20)
            _Y = Documento.Width / 2
            _X = Documento.Height / 2 '20 '.Location.X + 20
            _Ancho_Obj = .Width
            _Largo_Obj = .Height

            _Relleno = .FillStyle 'CType(_Objeto, RectangleShape).FillStyle = _Relleno
            _Color = .FillColor 'CType(_Objeto, RectangleShape).FillColor = _Color
            _Color_Borde = .BorderColor
            .Size() = New System.Drawing.Size(Math.Round(_Ancho_Obj), Math.Round(_Largo_Obj))

        End With


        With _Objeto_Clonado

            .Name = "BoxRec" & Contador
            .Location = New System.Drawing.Point(_Y, _X)
            .FillStyle = _Relleno
            .FillColor = _Color
            .BorderColor = _Color_Borde
            .Size() = New System.Drawing.Size(Math.Round(_Ancho_Obj), Math.Round(_Largo_Obj))
            '.ContextMenuStrip = ContextMenuStrip1

            Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                                   {_Objeto_Clonado})

            AddHandler CType(_Objeto_Clonado, RectangleShape).MouseDown, AddressOf Me.Control_MouseDown
            AddHandler CType(_Objeto_Clonado, RectangleShape).MouseMove, AddressOf Me.Control_MouseMove
            AddHandler CType(_Objeto_Clonado, RectangleShape).Click, AddressOf Me.Control_Clic
        End With



    End Sub

#End Region

#Region "FUNCION EXISTE ELEMENTO MAPA"
    Private Function Fx_Exite_Objeto(ByVal _Nombre_Objeto As String)
        For Each ctr In ShapeContainer1.Shapes
            Dim _Name = ctr.Name 'CType(ctr, Control).Name

            If _Name = _Nombre_Objeto Then
                Return True
            End If

        Next
    End Function
#End Region

#Region "FUNCION NOMBRE DE NUEVO ELEMENTO MAPA"

    Private Function Fx_Crear_Nombre_Nuevo_Objeto(ByVal _Tipo_Elemento As _TipoElemento)

        Dim _Nombre_Objeto As String
        Dim Contador = 0

        If _Tipo_Elemento = _TipoElemento.ETIQUETA Or _Tipo_Elemento = _TipoElemento.SECTOR Then

            With Documento

                For Each ctr As Control In .Controls

                    Dim Tipo = ctr.Name 'CType(ctr, Control).Name
                    Dim Nom = Mid(Tipo, 1, 3)
                    If Nom = "Lbl" Then
                        Contador += 1
                    End If
                Next

                If Contador = 0 Then Contador = 1

                If _Tipo_Elemento = _TipoElemento.ETIQUETA Then
                    _Nombre_Objeto = "LblCm" & Contador
                ElseIf _Tipo_Elemento = _TipoElemento.SECTOR Then
                    _Nombre_Objeto = "LblFx" & Contador
                End If
            End With

        Else

            For Each ctr In ShapeContainer1.Shapes
                Dim Tipo = ctr.Name 'CType(ctr, Control).Name
                Dim Nom = Mid(Tipo, 1, 3)

                If Mid(Tipo, 1, 3) = "Box" Then
                    Contador += 1
                End If
            Next
            If Contador = 0 Then Contador = 1

            _Nombre_Objeto = "Box_" & UCase(_Tipo_Elemento.ToString) & "_" & Contador
        End If

        Return _Nombre_Objeto

    End Function



#End Region

#Region "CREAR OBJETOS DE MAPA DE BODEGA"


#Region "CREAR NUEVO ELEMENTO PARA EL MAPA"

    Private Function Fx_Crear_Elemento(ByVal _X_Columna As Integer,
                                       ByVal _Y_Fila As Integer,
                                       ByVal _BackColor As Color,
                                       ByVal _ForeColor As Color,
                                       ByVal _Tipo_Objeto As _TipoElemento,
                                       Optional ByVal _Nombre_Objeto As String = "",
                                       Optional ByVal _Codigo_Sector As String = "",
                                       Optional ByVal _Texto As String = "",
                                       Optional ByVal _Font_Nombre As String = "",
                                       Optional ByVal _Font_Tamano As Integer = 8,
                                       Optional ByVal _Font_Negrita As Boolean = False,
                                       Optional ByVal _Font_Italic As Boolean = False,
                                       Optional ByVal _Font_Tachado As Boolean = False,
                                       Optional ByVal _Font_Subrayado As Boolean = False,
                                       Optional ByVal _Alto_H As Integer = 0,
                                       Optional ByVal _Ancho_W As Integer = 0,
                                       Optional ByVal _Relleno As Integer = 0,
                                       Optional ByVal _Orientacion As Boolean = False)

        _Tamano_Escala = 3
        Dim _Objeto As New RectangleShape

        Dim _Escala As Double = 100 / (_Tamano_Escala * 100)
        Dim _H, _W

        Dim _FillStyle As FillStyle

        Select Case _Tipo_Objeto

            Case _Tipo_Objeto.ESCALERA

                _H = 300 * _Escala
                _W = 120 * _Escala
                _ForeColor = DimGray 'Yellow
                _BackColor = DimGray 'White
                _FillStyle = FillStyle.Horizontal

            Case _Tipo_Objeto.MURO

                _H = 400 * _Escala
                _W = 14 * _Escala
                _ForeColor = Red
                _BackColor = Black
                _FillStyle = FillStyle.Solid 'FillStyle.HorizontalBrick

            Case _Tipo_Objeto.PILAR

                _H = 50 * _Escala
                _W = 50 * _Escala
                _ForeColor = Red
                _BackColor = Black 'White
                _FillStyle = FillStyle.HorizontalBrick

            Case _Tipo_Objeto.PUERTA

                _H = 90 * _Escala
                _W = 10 * _Escala
                _ForeColor = DimGray
                _BackColor = Black 'White
                _FillStyle = FillStyle.Solid

            Case _Tipo_Objeto.VENTANA

                _H = 120 * _Escala
                _W = 14 * _Escala
                _ForeColor = DodgerBlue
                _BackColor = Black 'White
                _FillStyle = FillStyle.ForwardDiagonal

        End Select

        If String.IsNullOrEmpty(_Nombre_Objeto) Then
            _Nombre_Objeto = Fx_Crear_Nombre_Nuevo_Objeto(_Tipo_Objeto)
            _Alto_H = _H
            _Ancho_W = _W
        Else
            _FillStyle = _Relleno
        End If

        With _Objeto

            .Location = New System.Drawing.Point(_X_Columna, _Y_Fila)
            .FillStyle = _FillStyle
            .FillColor = _ForeColor
            .BorderColor = _BackColor
            .Size() = New System.Drawing.Size(Math.Round(_Ancho_W), Math.Round(_Alto_H))
            '.ContextMenuStrip = ContextMenuStrip1

            .Name = _Nombre_Objeto

            If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then

                AddHandler CType(_Objeto, RectangleShape).MouseDown, AddressOf Me.Control_MouseDown
                AddHandler CType(_Objeto, RectangleShape).MouseMove, AddressOf Me.Control_MouseMove
                AddHandler CType(_Objeto, RectangleShape).Click, AddressOf Me.Control_Clic
                AddHandler CType(_Objeto, RectangleShape).DoubleClick, AddressOf Me.Control_Double_Clic
                AddHandler CType(_Objeto, RectangleShape).MouseUp, AddressOf Me.Control_MouseUP

            End If

        End With

        Return _Objeto

    End Function

#End Region




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




#Region "ABRIR MAPA"

    Sub Sb_Abrir_Mapas()

        ShapeContainer1.Shapes.Clear()

        Consulta_sql = "SELECT Tipo_Objeto,Nombre_Objeto,Codigo_Sector,Nombre_Sector,Texto," &
                       "Font_Nombre,Font_Tamano,Font_Estilo,Font_Negrita,Font_Italic,Font_Tachado,Font_Subrayado," &
                       "Alto_H,Ancho_W,BackColor,ForeColor,Relleno,Y_Fila,X_Columna,Orientacion" & vbCrLf &
                       "FROM   " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega &
                       "' And Id_Mapa= " & _Id_Mapa & vbCrLf &
                       "Order by Nombre_Objeto"

        Dim _TblDetalle_Mapa = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblDetalle_Mapa.Rows.Count) Then

            For Each _Fila As DataRow In _TblDetalle_Mapa.Rows

                With _Fila

                    Dim _Tipo_Objeto As _TipoElemento

                    Dim _Tobj = .Item("Tipo_Objeto")

                    Select Case _Tobj

                        Case "MURO"
                            _Tipo_Objeto = _TipoElemento.MURO
                        Case "PILAR"
                            _Tipo_Objeto = _TipoElemento.PILAR
                        Case "ESCALERA"
                            _Tipo_Objeto = _TipoElemento.ESCALERA
                        Case "PUERTA"
                            _Tipo_Objeto = _TipoElemento.PUERTA
                        Case "VENTANA"
                            _Tipo_Objeto = _TipoElemento.VENTANA
                        Case "ETIQUETA"
                            _Tipo_Objeto = _TipoElemento.ETIQUETA
                        Case "SECTOR"
                            _Tipo_Objeto = _TipoElemento.SECTOR
                        Case "SUB-SECTOR"
                    End Select

                    Dim _Nombre_Objeto As String = .Item("Nombre_Objeto")
                    Dim _Codigo_Sector As String = .Item("Codigo_Sector")
                    Dim _Nombre_Sector As String = .Item("Nombre_Sector")

                    Dim _Texto As String = .Item("Texto")

                    Dim _Font_Nombre As String = .Item("Font_Nombre")
                    Dim _Font_Tamano As Double = .Item("Font_Tamano")
                    Dim _Font_Estilo As FontStyle = .Item("Font_Estilo")

                    Dim _Font_Negrita As Boolean = .Item("Font_Negrita")
                    Dim _Font_Italic As Boolean = .Item("Font_Italic")
                    Dim _Font_Tachado As Boolean = .Item("Font_Tachado")
                    Dim _Font_Subrayado As Boolean = .Item("Font_Subrayado")

                    Dim _Alto_H As Integer = .Item("Alto_H")
                    Dim _Ancho_W As Integer = .Item("Ancho_W")

                    Dim _BackColor As Color = Color.FromArgb(.Item("BackColor"))
                    Dim _ForeColor As Color = Color.FromArgb(.Item("ForeColor"))
                    Dim _Relleno As Integer = .Item("Relleno")

                    Dim _Y_Fila As Integer = .Item("Y_Fila")
                    Dim _X_Columna As Integer = .Item("X_Columna")

                    Dim _Orientacion As Boolean = .Item("Orientacion")


                    If Mid(_Nombre_Objeto, 1, 3) = "Lbl" Then

                        Dim _LblObjeto As New LabelX

                        _LblObjeto = Fx_Crear_Sector(_X_Columna, _Y_Fila, _BackColor, _ForeColor, _Tipo_Objeto, _Nombre_Objeto,
                                                        _Codigo_Sector, _Texto, _Font_Nombre, _Font_Tamano, _Font_Estilo,
                                                        _Alto_H, _Ancho_W, CBool(_Relleno), _Orientacion,
                                                        _Configuracion_Diseno, _Nombre_Sector)

                        Documento.Controls.Add(_LblObjeto)

                        If Mid(_Nombre_Objeto, 1, 5) = "LblCm" Then
                            If Not IsNothing(_LblObjeto) Then
                                _LblObjeto.BringToFront()
                            End If
                        End If

                    ElseIf _Tobj <> "SUB-SECTOR" Then
                        Dim _BoxElemnto As New RectangleShape
                        _BoxElemnto = Fx_Crear_Elemento(_X_Columna, _Y_Fila, _BackColor, _ForeColor, _Tipo_Objeto, _Nombre_Objeto,
                                                        _Codigo_Sector, _Texto, _Font_Nombre, _Font_Tamano, _Font_Negrita, _Font_Italic,
                                                        _Font_Tachado, _Font_Subrayado, _Alto_H, _Ancho_W, _Relleno, _Orientacion)


                        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {_BoxElemnto})

                    End If

                End With

            Next

        End If

    End Sub

#End Region

#End Region

#Region "DISEÑO DE DOCUMENTOS"


    Private Sub Control_Inicio_Detalle(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LineaDetalle.Y1 = _FormPadre.Sld_detalle_Inicio.Value 'LineaDetalle.Y1 - 1
        LineaDetalle.Y2 = _FormPadre.Sld_detalle_Inicio.Value 'LineaDetalle.Y2 - 1

        _FormPadre.Sld_detalle_Inicio.Maximum = LineaPie.Y1 - 5
        _FormPadre.Sld_detalle_Fin.Minimum = LineaDetalle.Y1 + 5

        sender.Tooltip = sender.value

    End Sub

    Private Sub Control_Fin_Detalle(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LineaPie.Y1 = _FormPadre.Sld_detalle_Fin.Value 'LineaDetalle.Y1 - 1
        LineaPie.Y2 = _FormPadre.Sld_detalle_Fin.Value 'LineaDetalle.Y2 - 1

        _FormPadre.Sld_detalle_Inicio.Maximum = LineaPie.Y1 - 5
        _FormPadre.Sld_detalle_Fin.Minimum = LineaDetalle.Y1 + 5

    End Sub


#End Region



#Region "CONTROLES DE EVENTOS PARA OBJETOS"

    Private Sub Control_Double_Clic(
            ByVal sender As Object,
            ByVal e As System.EventArgs)

        'ObjetoActivo = sender
        Sb_Ver_Propiedad_de_Objeto_Mapa()

    End Sub

    Private Sub Control_Ubicacion_Diseño_Clic(ByVal sender As Object, ByVal e As System.EventArgs)

        ObjetoActivo = sender

        With CType(ObjetoActivo, LabelX)

            If Mid(.Name, 1, 5) = "LblFx" Then
                Dim _Codigo_Sector = .Text

                Dim Fm As New Frm_Ubicaciones(_RowBodega, _Id_Mapa, _Codigo_Sector)
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If
        End With
    End Sub

#Region "IMPRIMIR UBICACIONES"

    Sub Sb_Imprimir_Ubicaciones(ByVal _Codigo_Sector As String)
        'If Fx_Tiene_Permiso(Me, "7Brr0005") Then
        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Where Codigo_Sector = '" & _Codigo_Sector & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then
            Dim Fm As New Frm_ImpBarras_Ubicaciones(_Tbl.Rows(0))
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub



#End Region

    Private Sub Control_Ubicacion_Asignar_Productos_Clic(ByVal sender As Object, ByVal e As System.EventArgs)


        If (ObjetoActivo Is Nothing) Then
            ObjetoActivo = sender
        End If

        With CType(ObjetoActivo, LabelX)

            If Mid(.Name, 1, 5) = "LblFx" Then
                Dim _Codigo_Sector = .Text

                If _Imprimir_Cod_Barras_Ubicaciones Then
                    Sb_Imprimir_Ubicaciones(_Codigo_Sector)
                Else

                    Dim _Color_F = CType(ObjetoActivo, LabelX).BackColor
                    CType(ObjetoActivo, LabelX).BackColor = Gold

                    Dim Fm As New Frm_Ubicaciones(_RowBodega, _Id_Mapa, _Codigo_Sector)

                    If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then
                        Fm.Pro_Chk_Modificar_Sector = True
                    End If

                    Fm.Pro_RowProducto = _RowProducto
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                    CType(ObjetoActivo, LabelX).BackColor = _Color_F

                End If


            End If
        End With
    End Sub


    Private Sub Control_Clic(
            ByVal sender As Object,
            ByVal e As System.EventArgs)

        Try

            ObjetoActivo = sender

            If Not (ObjetoActivo Is Nothing) Then

                Dim _Tipo = Mid(ObjetoActivo.Name, 1, 3) '  

                If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then


                    _FormPadre.Sld_Tam_Alto.Value = CType(ObjetoActivo, Control).Height
                    _FormPadre.Sld_Tam_Ancho.Value = CType(ObjetoActivo, Control).Width

                    _FormPadre.Sld_Ubicacion_X.Value = CType(ObjetoActivo, Control).Location.X
                    _FormPadre.Sld_Ubicacion_Y.Value = CType(ObjetoActivo, Control).Location.Y

                    If _Tipo = "Pic" Then
                        CType(ObjetoActivo, PictureBox).BorderStyle = BorderStyle.FixedSingle
                        CType(ObjetoActivo, PictureBox).SendToBack()
                    End If

                    Fx_Marcar_linea(sender)

                ElseIf _Tipo = "Lin" Then

                    _FormPadre.Sld_Tam_Ancho.Value = CType(ObjetoActivo, LineShape).X1 - CType(ObjetoActivo, LineShape).X2

                    _FormPadre.Sld_Ubicacion_X.Value = CType(ObjetoActivo, LineShape).X1
                    _FormPadre.Sld_Ubicacion_Y.Value = CType(ObjetoActivo, LineShape).X1

                ElseIf _Tipo = "Box" Then

                    CType(ObjetoActivo, RectangleShape).BringToFront()
                    Dim _Size = CType(ObjetoActivo, RectangleShape).Size

                    _FormPadre.Sld_Tam_Alto.Value = _Size.Height
                    _FormPadre.Sld_Tam_Ancho.Value = _Size.Width

                    _FormPadre.Sld_Ubicacion_X.Value = CType(ObjetoActivo, RectangleShape).Location.X
                    _FormPadre.Sld_Ubicacion_Y.Value = CType(ObjetoActivo, RectangleShape).Location.Y

                    'Fx_Marcar_linea(sender)

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_MouseDown(
            ByVal sender As Object,
            ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Cuando se pulsa con el ratón
        DX = e.X
        DY = e.Y

        ObjetoActivo = sender
        Dim Tipo = sender.Name
        ObjetoActivo.FOCUS()

        Dim _Codigo_Sector As String = String.Empty

        Btn_Mnu_Etiqueta_Editar_Texto.Visible = True
        Btn_Mnu_Etiqueta_Editar_Fuente.Visible = True
        ButtonItem2.Visible = True

        With CType(_FormPadre, Frm_Diseno_Doc_y_Ubic)

            Dim _Ancho_Obj = ObjetoActivo.Width
            Dim _Largo_Obj = ObjetoActivo.Height

            Dim Y = ObjetoActivo.Location.Y
            Dim X = ObjetoActivo.Location.X

            .Sld_Tam_Alto.Value = _Largo_Obj
            .Sld_Tam_Ancho.Value = _Ancho_Obj

            .Sld_Ubicacion_Y.Value = Y
            .Sld_Ubicacion_X.Value = X

        End With

        If Mid(Tipo, 1, 3) = "Txt" Or Mid(Tipo, 1, 3) = "Lbl" Or Mid(Tipo, 1, 3) = "Pic" Or Mid(Tipo, 1, 3) = "Box" Then

            If Mid(Tipo, 1, 3) = "Txt" Then

                CType(sender, Control).BringToFront()

                CType(sender, TextBox).SelectAll()
                CType(sender, TextBox).ReadOnly = True

            ElseIf Mid(Tipo, 1, 3) = "Lbl" Then

                CType(sender, Control).BringToFront()

                If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then

                    If e.Button = Windows.Forms.MouseButtons.Right Then

                        If Mid(Tipo, 1, 5) = "LblFx" Then

                            _Codigo_Sector = ObjetoActivo.Text

                            Dim _Nombre_Sector As String
                            For i = 0 To 1000
                                Dim _N = _Sectores(i, 1)
                                If _Codigo_Sector = _N Then
                                    _Nombre_Sector = _Sectores(i, 2)
                                    Exit For
                                End If
                            Next

                            Lbl_Sector.Text = "Sector: " & ObjetoActivo.text & " - " & _Nombre_Sector

                            If String.IsNullOrEmpty(_Codigo_Sector) Then
                                Btn_Mnu_Sector_Ubicaciones.Enabled = False
                                Lbl_Sector.Enabled = False
                            Else
                                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                                               "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'"
                                Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                                Btn_Mnu_Sector_Ubicaciones.Enabled = CBool(_Tbl.Rows.Count)
                                Btn_Mnu_Sector_Cambiar_Codigo.Enabled = CBool(_Tbl.Rows.Count)

                                Lbl_Sector.Enabled = True

                            End If

                            ShowContextMenu(Menu_Contextual_Sectores)

                        Else

                            ShowContextMenu(Menu_Contextual_Etiquetas)

                        End If

                    End If

                End If

            ElseIf Mid(Tipo, 1, 3) = "Box" Then

                If e.Button = Windows.Forms.MouseButtons.Right Then

                    Btn_Mnu_Etiqueta_Editar_Texto.Visible = False
                    Btn_Mnu_Etiqueta_Editar_Fuente.Visible = False
                    ButtonItem2.Visible = False

                    ShowContextMenu(Menu_Contextual_Etiquetas)

                End If

            End If

            'Sb_Revisar_Form_Popiedades_Mapa()

        End If

        Me.Refresh()

    End Sub

    Private Sub Control_MouseUP(
                 ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Arrow

        If _Configuracion_Diseno = _TipoDiseno.Documento Then
            sender.BorderStyle = BorderStyle.None
            ' ObjetoActivo = Nothing ' = String.Empty
        End If
        Try
            ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_1.name))
            ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_2.name))
        Catch ex As Exception
        Finally
            Me.ShapeContainer1.Refresh()
            Me.Documento.Refresh()
        End Try

        'Alto.Enabled = False
        'Ancho.Enabled = False
    End Sub

    Private Sub Control_MouseUP(
             ByVal sender As System.Object, ByVal e As PaintEventArgs)
        Me.Cursor = Cursors.Arrow

        If _Configuracion_Diseno = _TipoDiseno.Documento Then
            sender.BorderStyle = BorderStyle.None
            ' ObjetoActivo = Nothing ' = String.Empty
        End If
        Try
            ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_1.name))
            ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_2.name))
        Catch ex As Exception
        Finally
            Me.ShapeContainer1.Refresh()
            Me.Documento.Refresh()
        End Try

        'Alto.Enabled = False
        'Ancho.Enabled = False
    End Sub


    'Private Sub Control_MouseEnter( _
    '       ByVal sender As Object, _
    '       ByVal e As System.Windows.Forms.MouseEventArgs)
    '    Fx_Marcar_linea(sender)
    'End Sub

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

                    'Fx_Marcar_linea(ObjetoActivo)

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

                End If

                Me.Cursor = Cursors.Cross

            End If

        End If

    End Sub
#End Region

#Region "CONTROLES COMPRATIDOS DE TAMAÑO Y UBICACION"


    Function Fx_Marcar_linea(ByVal _Objeto As Object)

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




        If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then

            For Each ctr As Object In Documento.Controls

                Dim Tipo = ctr.Name 'CType(ctr, Control).Name
                Dim Nom = Mid(Tipo, 1, 3)

                If Tipo <> _Objeto.Name Then

                    Dim X_ = CType(ctr, Control).Left
                    Dim Y_ = CType(ctr, Control).Top

                    If X_ = _Lx Then
                        _Line_Aj_2 = Fx_Crear_Linea(X_, 0, Documento.Height, False, True)
                    End If

                    If Y_ = _Ly Then
                        _Line_Aj_1 = Fx_Crear_Linea(0, Documento.Width, Y_, False)
                    End If

                Else
                    If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then

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
                                    ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Arr(_i)))
                                Catch ex As Exception

                                End Try

                            Next
                        End If

                    End If
                    Try
                        ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_1.name))
                        ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Line_Aj_2.name))
                    Catch ex As Exception
                    End Try
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

#Region "CREAR LINEA"
    Function Fx_Crear_Linea(ByVal _PosicionX As Integer,
                            ByVal _PosicionXX As Integer,
                            ByVal _PosicionY As Integer,
                            Optional ByVal _Menu As Boolean = True,
                            Optional ByVal _Vertical As Boolean = False)
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

                    ' .ContextMenuStrip = ContextMenuStrip1
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

                Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() _
                                          {_Linea})

                'Me.ShapeContainer1.Shapes.Remove(_Caja)

                AddHandler .MouseDown, AddressOf Me.Control_MouseDown
                AddHandler .MouseMove, AddressOf Me.Control_MouseMove
                AddHandler .Click, AddressOf Me.Control_Clic
                'AddHandler .MouseLeave, AddressOf Me.Control_MouseLeave

            End With

            'PanelActivo.Controls.Add(_Caja)
            Return _Linea
        End With
    End Function
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




#End Region



    Private Sub Frm_Formulario_Diseno_Mapa_Documentos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter

        With CType(_FormPadre, Frm_Diseno_Doc_y_Ubic)

            .Sld_Tam_Alto.Maximum = Documento.Height
            .Sld_Tam_Ancho.Maximum = Documento.Width

            .Sld_Ubicacion_Y.Maximum = Documento.Height
            .Sld_Ubicacion_X.Maximum = Documento.Width

        End With

    End Sub




    Private Sub Frm_Formulario_Diseno_Mapa_Documentos_FormClosing(ByVal sender As System.Object,
                                                                  ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If _Configuracion_Diseno <> _TipoDiseno.Documento AndAlso _Configuracion_Diseno <> _TipoDiseno.Mapa_Ver_Mapa Then
            If Not _Cerrar_Formulario Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Documento.Click
        Me.Cursor = Cursors.Arrow
        If _Configuracion_Diseno <> _TipoDiseno.Mapa_Ver_Mapa Then
            ObjetoActivo = Nothing ' = String.Empty
        End If
    End Sub

    Private Sub Documento_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Documento.MouseLeave
        Me.Cursor = Cursors.Arrow
        _Objeto_Copiado = Nothing
    End Sub

    Private Sub Documento_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Documento.MouseMove
        PosicionX = e.X.ToString
        PosicionY = e.Y.ToString
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not (ObjetoActivo Is Nothing) Then
            If ObjetoActivo.visible Then
                ObjetoActivo.Visible = False
            Else
                ObjetoActivo.Visible = True
            End If
            'ObjetoActivo.Refresh()
            'Documento.Refresh()
        End If
    End Sub

    Private Sub Frm_Formulario_Diseno_Mapa_Documentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Mnu_Sector_Propiedades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Ver_Propiedad_de_Objeto_Mapa()
    End Sub

    Private Sub Documento_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Documento.MouseDown
        If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then
            Me.Cursor = Cursors.Arrow
            ObjetoActivo = Nothing ' = String.Empty

            If e.Button = Windows.Forms.MouseButtons.Right Then

                If Not String.IsNullOrEmpty(_Nombre_Objeto_Copiado) Then
                    Btn_Mnu_Pegar.Enabled = True
                Else
                    Btn_Mnu_Pegar.Enabled = False
                End If

                ShowContextMenu(Menu_Contextual_Objeto_Agregar)

            End If
        End If
    End Sub

#Region "PROPIEDADES COMPARTIDAS DE OBJETOS"

    Private Sub Btn_Mnu_Objeto_Editar_Color_Fuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _Clas_Formato.Fx_Editar_Color Then
            Dim _Color As Color = _Clas_Formato.Pro_Color

            Dim _NroColor = _Clas_Formato.Pro_NroColor
            ' Objeto.ForeColor = Color.FromArgb(NroColor) 'Color

            ObjetoActivo.ForeColor = Color.FromArgb(_NroColor)
        End If
        Me.Refresh()
    End Sub

    Private Sub Btn_Mnu_Objeto_Editar_Color_Fondo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _Clas_Formato.Fx_Editar_Color Then
            Dim _Color As Color = _Clas_Formato.Pro_Color

            Dim _NroColor = _Clas_Formato.Pro_NroColor
            ' Objeto.ForeColor = Color.FromArgb(NroColor) 'Color

            ObjetoActivo.BackColor = Color.FromArgb(_NroColor)
        End If
        Me.Refresh()
    End Sub

    Private Sub Btn_Mnu_Objeto_Editar_Fuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Clas_Formato.Fx_Editar_Fuente(ObjetoActivo)
    End Sub

    Private Sub Btn_Mnu_Objeto_Rotar_Click()

        If Not (ObjetoActivo Is Nothing) Then

            Dim _Tipo = ObjetoActivo.name


            'ObjetoActivo.Location = New System.Drawing.Point(_X, _Y)
            If Mid(_Tipo, 1, 3) = "Lbl" Then

                If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then

                    Dim _Ancho = CType(ObjetoActivo, DevComponents.DotNetBar.LabelX).Width
                    Dim _Alto = CType(ObjetoActivo, DevComponents.DotNetBar.LabelX).Height

                    CType(ObjetoActivo, DevComponents.DotNetBar.LabelX).Width = _Alto
                    CType(ObjetoActivo, DevComponents.DotNetBar.LabelX).Height = _Ancho

                    Dim _Horientacion = CType(ObjetoActivo, DevComponents.DotNetBar.LabelX).TextOrientation

                    If _Horientacion = eOrientation.Horizontal Then
                        CType(ObjetoActivo, DevComponents.DotNetBar.LabelX).TextOrientation = eOrientation.Vertical
                    Else
                        CType(ObjetoActivo, DevComponents.DotNetBar.LabelX).TextOrientation = eOrientation.Horizontal
                    End If

                End If

            ElseIf Mid(_Tipo, 1, 3) = "Box" Then

                Dim _Ancho = CType(ObjetoActivo, RectangleShape).Size.Width
                Dim _Alto = CType(ObjetoActivo, RectangleShape).Size.Height

                Dim _Relleno As New FillStyle

                _Relleno = CType(ObjetoActivo, RectangleShape).FillStyle

                If _Relleno = FillStyle.Horizontal Then
                    _Relleno = FillStyle.Vertical
                ElseIf _Relleno = FillStyle.Vertical Then
                    _Relleno = FillStyle.Horizontal
                End If

                ObjetoActivo.Size() = New System.Drawing.Size(Math.Round(_Alto), Math.Round(_Ancho))
                CType(ObjetoActivo, RectangleShape).FillStyle = _Relleno

            ElseIf Mid(_Tipo, 1, 3) = "Box" Or Mid(_Tipo, 1, 3) = "Lin" Then
                'ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Tipo))
            End If
        End If

    End Sub

    Private Sub Btn_Mnu_Objeto_Pegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Objeto_Copiado As Object
        Dim _Nuevo_Objeto As Object
        'Dim Ctrl As Control

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

        Select Case _Tipo

            Case "Lbl"

                Dim _Lbl As Integer
                Dim _Objeto = Mid(_Nombre_Objeto_Copiado, 1, 5)

                Dim _Codigo_Sector As String = CType(_Objeto_Copiado, LabelX).Text
                Dim _Nombre_Sector As String = CType(_Objeto_Copiado, LabelX).Text

                If _Objeto = "LblCm" Then
                    _Lbl = 5 ' ETIQUETA
                ElseIf _Objeto = "LblFx" Then

                    For i = 0 To 1000
                        Dim _N = _Sectores(i, 1)
                        If _Codigo_Sector = _N Then
                            _Nombre_Sector = _Sectores(i, 2)
                            Exit For
                        End If
                    Next

                    Dim _Grabar As Boolean

                    Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa,
                                                        Frm_Formulario_Diseno_Mapa_Crear_Sector._Enum_Accion.Pegar)
                    Fm.Pro_Codigo_Sector = _Codigo_Sector
                    Fm.Pro_Nombre_Sector = _Nombre_Sector
                    Fm.ShowDialog(Me)
                    _Grabar = Fm.Pro_Grabar
                    _Codigo_Sector = Fm.Pro_Codigo_Sector
                    _Nombre_Sector = Fm.Pro_Nombre_Sector
                    Fm.Dispose()

                    If Not _Grabar Then
                        Return
                    End If

                    _Lbl = 6 ' SECTOR

                End If

                _Nuevo_Objeto = Fx_Crear_Sector(PosicionX, PosicionY,
                                                 CType(_Objeto_Copiado, LabelX).BackColor,
                                                 CType(_Objeto_Copiado, LabelX).ForeColor,
                                                 _Lbl, ,
                                                 _Codigo_Sector,
                                                 _Codigo_Sector,
                                                 CType(_Objeto_Copiado, LabelX).Font.Name,
                                                 CType(_Objeto_Copiado, LabelX).Font.Size,
                                                 CType(_Objeto_Copiado, LabelX).Font.Style,
                                                 CType(_Objeto_Copiado, LabelX).Height,
                                                 CType(_Objeto_Copiado, LabelX).Width, ,
                                                 CType(_Objeto_Copiado, LabelX).TextOrientation, ,
                                                 _Nombre_Sector)


                CType(_Nuevo_Objeto, LabelX).AutoSize = CType(_Objeto_Copiado, LabelX).AutoSize
                CType(_Nuevo_Objeto, LabelX).BorderType = CType(_Objeto_Copiado, LabelX).BorderType
                'CType(_Nuevo_Objeto, LabelX).BackColor = CType(_Objeto_Copiado, LabelX).BackColor
                'CType(_Nuevo_Objeto, LabelX).ForeColor = CType(_Objeto_Copiado, LabelX).ForeColor

                Documento.Controls.Add(_Nuevo_Objeto)

                Control_Clic(_Nuevo_Objeto, Nothing)

            Case "Box"

                Dim _Ancho = CType(_Objeto_Copiado, RectangleShape).BorderWidth
                Dim _Ancho_Obj = CType(_Objeto_Copiado, RectangleShape).Width
                Dim _Largo_Obj = CType(_Objeto_Copiado, RectangleShape).Height
                Dim _Esquina = CType(_Objeto_Copiado, RectangleShape).CornerRadius

                _Nuevo_Objeto = Fx_Crear_Elemento(PosicionX, PosicionY,
                                                  CType(_Objeto_Copiado, RectangleShape).BorderColor,
                                                  CType(_Objeto_Copiado, RectangleShape).FillColor,
                                                  _TipoElemento.PILAR, , , , , , , , , ,
                                                  CType(_Objeto_Copiado, RectangleShape).Height,
                                                  CType(_Objeto_Copiado, RectangleShape).Width,
                                                  0, True)

                Dim _Alto_H = CType(_Objeto_Copiado, RectangleShape).Height
                Dim _Ancho_W = CType(_Objeto_Copiado, RectangleShape).Width

                CType(_Nuevo_Objeto, RectangleShape).Size() = New System.Drawing.Size(Math.Round(_Ancho_W),
                                                                                      Math.Round(_Alto_H))

                CType(_Nuevo_Objeto, RectangleShape).FillStyle = CType(_Objeto_Copiado, RectangleShape).FillStyle
                CType(_Nuevo_Objeto, RectangleShape).FillColor = CType(_Objeto_Copiado, RectangleShape).FillColor
                CType(_Nuevo_Objeto, RectangleShape).BackColor = CType(_Objeto_Copiado, RectangleShape).BackColor

                Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {_Nuevo_Objeto})


        End Select

        If Not (_Nuevo_Objeto Is Nothing) Then
            _Nuevo_Objeto.focus()
            _Nuevo_Objeto.BringToFront()
            ObjetoActivo = _Nuevo_Objeto
            _Nombre_Objeto_Copiado = ObjetoActivo.Name
        End If

    End Sub

    Private Sub Btn_Mnu_Objeto_Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Nombre_Objeto_Copiado = ObjetoActivo.Name
    End Sub

    Private Sub Btn_Mnu_Objeto_Eliminar_Click()

        If Not (ObjetoActivo Is Nothing) Then

            Dim _Tipo = ObjetoActivo.name

            If Mid(_Tipo, 1, 3) = "Txt" Or Mid(_Tipo, 1, 3) = "Pic" Or Mid(_Tipo, 1, 3) = "Lbl" Then

                If Mid(_Tipo, 1, 5) = "LblFx" Then

                    Dim _Codigo_Sector = CType(ObjetoActivo, LabelX).Text
                    Dim _Tiene_Prod As Boolean

                    Dim Fm_ As New Frm_Ubicaciones(_RowBodega, _Id_Mapa, _Codigo_Sector)
                    _Tiene_Prod = Fm_.Fx_Tiene_Productos_El_Sector(_Id_Mapa, _Codigo_Sector)
                    Fm_.Dispose()

                    If _Tiene_Prod Then
                        MessageBoxEx.Show(Me, "Existen productos asociados en las ubicaciones", "Validación",
                                           MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If

                Dim ControlAct As Control = CType(ObjetoActivo, Control)
                Dim Objeto = PanelActivo

                ControlAct.Dispose()

            ElseIf Mid(_Tipo, 1, 3) = "Box" Or Mid(_Tipo, 1, 3) = "Lin" Then
                ShapeContainer1.Shapes.RemoveAt(ShapeContainer1.Shapes.IndexOfKey(_Tipo))
            End If

        End If

    End Sub


#End Region

    Private Sub Btn_Cambiar_Nombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Sector_Cambiar_Nombre.Click

        Dim _Codigo_Sector = ObjetoActivo.Text
        Dim _Nombre_Sector

        Dim _Id As Integer

        For i = 0 To 1000
            Dim _N = _Sectores(i, 1)
            If _Codigo_Sector = _N Then
                _Nombre_Sector = _Sectores(i, 2)
                _Id = i
                Exit For
            End If
        Next

        Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa, Frm_Formulario_Diseno_Mapa_Crear_Sector._Enum_Accion.Editar)
        Fm.Pro_Codigo_Sector = _Codigo_Sector
        Fm.Pro_Nombre_Sector = _Nombre_Sector
        Fm.ShowDialog(Me)
        Dim _Grabar = Fm.Pro_Grabar
        _Codigo_Sector = Fm.Pro_Codigo_Sector
        _Nombre_Sector = Fm.Pro_Nombre_Sector
        Fm.Dispose()

        If _Grabar Then
            _Sectores(_Id, 2) = _Nombre_Sector
            Me.ToolTip1.SetToolTip(ObjetoActivo, UCase(_Nombre_Sector))
        End If

    End Sub

    Private Sub Btn_Mnu_Etiqueta_Editar_Texto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Etiqueta_Editar_Texto.Click

        Dim _Descripcion As String = ObjetoActivo.Text
        Dim _Aceptado As Boolean

        _Aceptado = InputBox_Bk(Me, "Ingrese una descripción", "Editar etiqueta", _Descripcion,
                                     True, _Tipo_Mayus_Minus.Mayusculas, 100, True, _Tipo_Imagen.Texto.Texto)

        If _Aceptado Then
            ObjetoActivo.Text = _Descripcion
        End If

    End Sub

    Private Sub Btn_Mnu_Sector_Cambiar_Codigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Sector_Cambiar_Codigo.Click

        Dim _Codigo_Sector = ObjetoActivo.Text
        Dim _Codigo_Sector_Old = _Codigo_Sector
        Dim _Nombre_Sector
        Dim _Id As Integer

        Dim _Tiene_Prod As Boolean
        Dim Fm_ As New Frm_Ubicaciones(_RowBodega, _Id_Mapa, _Codigo_Sector)
        _Tiene_Prod = Fm_.Fx_Tiene_Productos_El_Sector(_Id_Mapa, _Codigo_Sector)
        Fm_.Dispose()

        If _Tiene_Prod Then

            If MessageBoxEx.Show(Me, "Existen productos asociados a estas ubicaciones" & vbCrLf &
                                 "¿Esta seguro de cambiar el código del sector?", "Confirmación",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                Return
            End If

        End If

        'If Not _Tiene_Prod Then

        Dim _Color_F = CType(ObjetoActivo, LabelX).BackColor
        CType(ObjetoActivo, LabelX).BackColor = Gold

        _Nombre_Sector = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det", "Nombre_Sector",
                                   "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'")

        Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa, Frm_Formulario_Diseno_Mapa_Crear_Sector._Enum_Accion.Editar_Codigo)
        Fm.Pro_Codigo_Sector = _Codigo_Sector
        Fm.Pro_Nombre_Sector = _Nombre_Sector
        Fm.ShowDialog(Me)

        Dim _Grabar = Fm.Pro_Grabar
        _Codigo_Sector = Fm.Pro_Codigo_Sector
        _Nombre_Sector = Fm.Pro_Nombre_Sector
        Fm.Dispose()

        If _Grabar Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & Space(1) &
                           "Set Codigo_Sector = '" & _Codigo_Sector & "', Nombre_Sector = '" & _Nombre_Sector & "'" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Set Codigo_Sector = '" & _Codigo_Sector & "'" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Set Codigo_Ubic = Codigo_Sector+Descripcion_Ubic" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set Codigo_Sector = '" & _Codigo_Sector & "'," &
                           "Codigo_Ubic = REPLACE(Codigo_Ubic,'" & _Codigo_Sector_Old & "','" & _Codigo_Sector & "')" & vbCrLf &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                For i = 0 To 1000
                    Dim _N = _Sectores(i, 1)
                    If _Codigo_Sector_Old = _N Then

                        For Each Ctrl In _Documento.Controls
                            'Insertamos las Etiquetas y Sectores
                            If Mid(Ctrl.Name, 1, 5) = "LblFx" Then
                                If Ctrl.Text = _Codigo_Sector_Old Then
                                    Ctrl.Text = _Codigo_Sector
                                    Me.ToolTip1.SetToolTip(Ctrl, UCase(_Nombre_Sector))
                                End If
                            End If
                        Next
                        _Sectores(i, 1) = _Codigo_Sector
                        _Sectores(i, 2) = _Nombre_Sector
                        'Exit For
                    End If
                Next

                Beep()
                ToastNotification.Show(Me, "CODIGO CAMBIADO CORRECTAMENTE",
                                       My.Resources.save,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            End If

        End If
        CType(ObjetoActivo, LabelX).BackColor = _Color_F
        'Else
        '    MessageBoxEx.Show(Me, "Existen productos asociados en las ubicaciones", "Validación",
        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

    End Sub

End Class
