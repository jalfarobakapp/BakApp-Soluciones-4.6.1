Imports System.Drawing.Color
Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Windows.Forms
Imports System.Linq
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_Diseno_Doc_y_Ubic

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private DX, DY As Integer

    Dim ObjetoActivo As Object
    Dim PosicionX, PosicionY As Integer
    Dim PanelActivo As Control
    Dim _Objeto_Copiado As Object
    Dim TipoDos As String
    Dim NombreFormato As String

    Dim _TipoDoc As String
    Dim _NombreFormato As String
    Dim _Editar_Documento As Boolean
    Dim _Nuevo_Formato As Boolean

    Dim _Line_Aj_1, _Line_Aj_2 As Object
    Dim _Alto_Caja, _Ancho_Caja As Integer

    Dim _Nombre_Mapa As String
    Dim _Configuracion_Diseno As _TipoDiseno
    Dim _Ancho_Mapa, _Largo_Mapa As Integer
    Dim _Escala_Mapa As Integer

    Dim _RowBodega As DataRow
    Dim _Empresa
    Dim _Sucursal
    Dim _Bodega

    Dim Fm_Propiedades As New Frm_Mapa_Diseno_Elementos

    Dim _RowProducto As DataRow
    Dim _TblMapas As DataTable

    Enum _TipoDiseno
        Documento
        Mapa_Bodega_Crear_Ubicaciones
        Mapa_Bodega_Diseño
        Mapa_Bodega_Asignar_Ubicaciones
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

    Dim _Imprimir_Cod_Barras_Ubicaciones As Boolean

    Public Property Pro_Imprimir_Cod_Barras_Ubicaciones() As Boolean
        Get
            Return _Imprimir_Cod_Barras_Ubicaciones
        End Get
        Set(ByVal value As Boolean)
            _Imprimir_Cod_Barras_Ubicaciones = value
        End Set
    End Property
    Public Property Pro_Nuevo_Formato As Boolean
        Get
            Return _Nuevo_Formato
        End Get
        Set(value As Boolean)
            _Nuevo_Formato = value
        End Set
    End Property
    Public Property Pro_TipoDoc As String
        Get
            Return _TipoDoc
        End Get
        Set(value As String)
            _TipoDoc = value
        End Set
    End Property
    Public Property Pro_NombreFormato As String
        Get
            Return _NombreFormato
        End Get
        Set(value As String)
            _NombreFormato = value
        End Set
    End Property
    Public Property Pro_RowBodega As DataRow
        Get
            Return _RowBodega
        End Get
        Set(value As DataRow)
            _RowBodega = value
        End Set
    End Property
    Public Property Pro_RowProducto As DataRow
        Get
            Return _RowProducto
        End Get
        Set(value As DataRow)
            _RowProducto = value
        End Set
    End Property
    Public Property Pro_Configuracion_Diseno As _TipoDiseno
        Get
            Return _Configuracion_Diseno
        End Get
        Set(value As _TipoDiseno)
            _Configuracion_Diseno = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "ABRIR FORMULARIOS"







#End Region

    Private Sub AgregarTextoLibreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Fx_Crear_Txt(PosicionX, PosicionY)
    End Sub







    Private Sub TabPage2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        PosicionX = e.X.ToString
        PosicionY = e.Y.ToString
    End Sub

    Private Sub TabPage3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        PosicionX = e.X.ToString
        PosicionY = e.Y.ToString
    End Sub



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Control_Encima_Slp(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.Tooltip = sender.value
    End Sub

    Private Sub LineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Fx_Crear_Linea(PosicionX, 200, PosicionY)
    End Sub


    Private Sub Frm_Diseno_Doc_y_Ubic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Condicion As String

        If _Configuracion_Diseno = _TipoDiseno.Documento Then

        Else

            Dim _Es_Es_Sub_Mapa As Integer

            If _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Diseño Then
                RibbonControl1.Expanded = True
            ElseIf _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Asignar_Ubicaciones Or _Configuracion_Diseno = _TipoDiseno.Mapa_Bodega_Crear_Ubicaciones Then
                RibbonTabItem1.Enabled = False
                _Condicion = "And Es_Sub_Mapa = 0"
            End If

            _Empresa = _RowBodega.Item("EMPRESA")
            _Sucursal = _RowBodega.Item("KOSU")
            _Bodega = _RowBodega.Item("KOBO")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc" & vbCrLf &
                           "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf &
                           _Condicion & vbCrLf &
                           "Order by Orden"
            _TblMapas = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila_Mapa As DataRow In _TblMapas.Rows
                Sb_Crear_Form_Mapa(_Fila_Mapa)
            Next

        End If


        AddHandler CType(Sld_Tam_Alto, SliderItem).ValueChanged, AddressOf Control_Tamano_Obj_Alto_ValueChanged
        AddHandler CType(Sld_Tam_Ancho, SliderItem).ValueChanged, AddressOf Control_Tamano_Obj_Ancho_ValueChanged

        AddHandler CType(Sld_Ubicacion_X, SliderItem).ValueChanged, AddressOf Control_Ubicacion_Obj_X_ValueChanged
        AddHandler CType(Sld_Ubicacion_Y, SliderItem).ValueChanged, AddressOf Control_Ubicacion_Obj_Y_ValueChanged

        AddHandler Btn_Grabar.Click, AddressOf Sb_Btn_Grabar_Click

    End Sub

    Sub Sb_Crear_Form_Mapa(ByVal _Nombre_Mapa As String,
                           ByVal _Largo As Integer,
                           ByVal _Ancho As Integer,
                           ByVal _Escala As Integer)

        'Dim Fm As New Frm_Formulario_Diseno_Mapa_Documentos
        'Fm.Text = _Nombre_Mapa
        'Fm._TipoDoc = "MAPA"
        'Fm._Nombre_Mapa = _Nombre_Mapa
        'Fm._Editar_Documento = True
        'Fm._Configuracion_Diseno = _Configuracion_Diseno
        'Fm._RowBodega = _RowBodega
        'Fm._RowProducto = _RowProducto
        'Fm._Tamano_Escala = _Escala
        'Fm._Largo_Mapa = _Largo
        'Fm._Ancho_Mapa = _Ancho
        'Fm.WindowState = FormWindowState.Maximized
        'Fm.IsMdiChild = True
        'Fm._FormPadre = Me
        'Fm.MdiParent = Me
        'Fm.Pro_Imprimir_Cod_Barras_Ubicaciones = _Imprimir_Cod_Barras_Ubicaciones
        'Fm.Show()

    End Sub


    Sub Sb_Crear_Form_Mapa(ByVal _RowMapa As DataRow)

        Dim Fm As New Frm_Formulario_Diseno_Mapa_Documentos(_RowMapa, _Configuracion_Diseno)
        'Fm.Text = _Nombre_Mapa
        'Fm._TipoDoc = "MAPA"
        'Fm._Nombre_Mapa = _Nombre_Mapa
        'Fm._Editar_Documento = True
        'Fm._Configuracion_Diseno = _Configuracion_Diseno
        Fm._RowBodega = _RowBodega
        Fm._RowProducto = _RowProducto
        'Fm._Tamano_Escala = _Escala
        'Fm._Largo_Mapa = _Largo
        'Fm._Ancho_Mapa = _Ancho
        'Fm.WindowState = FormWindowState.Maximized
        'Fm.IsMdiChild = True
        Fm._FormPadre = Me
        Fm.MdiParent = Me
        Fm.Pro_Imprimir_Cod_Barras_Ubicaciones = _Imprimir_Cod_Barras_Ubicaciones
        Fm.Show()

    End Sub

    Private Sub Control_Tamano_Obj_Alto_ValueChanged(
                                             ByVal sender As Object,
                                             ByVal e As System.EventArgs)

        Try

            Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                 TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

            Dim _Limite_Derecha = _FrmActivo.Documento.Width
            Dim _Limite_Abajo = _FrmActivo.Documento.Height

            Dim _ObjetoActivo = _FrmActivo.ObjetoActivo


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

            Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                  TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

            Dim _Limite_Derecha = _FrmActivo.Documento.Width
            Dim _Limite_Abajo = _FrmActivo.Documento.Height

            Dim _ObjetoActivo = _FrmActivo.ObjetoActivo

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

        Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                   TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

        Dim _Limite_Derecha = _FrmActivo.Documento.Width
        Dim _Limite_Abajo = _FrmActivo.Documento.Height

        Dim _ObjetoActivo = _FrmActivo.ObjetoActivo


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


            Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                   TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

            Dim _Limite_Derecha = _FrmActivo.Documento.Width
            Dim _Limite_Abajo = _FrmActivo.Documento.Height

            Dim _ObjetoActivo = _FrmActivo.ObjetoActivo

            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3) '

            If _Tipo <> "Box" And _Tipo <> "Lin" Then
                Dim X = CType(_ObjetoActivo, Control).Location.X
                CType(_ObjetoActivo, Control).Location = New System.Drawing.Point(X, sender.value)
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


#Region "GRABAR"

    Sub Sb_Btn_Grabar_Click()

        If _Configuracion_Diseno = _TipoDiseno.Documento Then
            ' GrabarMovimientos()
        Else
            Sb_Sql_Crear_Mapa()
        End If

    End Sub

#Region "PROCEDIMIENTO PARA GRABAR MAPA EN BASE DE DATOS"

#Region "GRABAR MAPA"

    Sub Sb_Sql_Crear_Mapa()
        Try

            Dim Ctrl As Control

            Dim Sql1 = String.Empty
            Dim Sql2 = String.Empty

            Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                  TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

            '_Nombre_Mapa = _FrmActivo.Text
            Dim _Id_Mapa As Integer = _FrmActivo.Pro_Id_Mapa
            Dim _Documento = _FrmActivo.Documento
            Dim _Sectores(,) = _FrmActivo.Pro_Sectores

            Dim _i = 1
            For Each Ctrl In _Documento.Controls
                'Insertamos las Etiquetas y Sectores
                If Mid(Ctrl.Name, 1, 3) = "Lbl" Then ' <> "ShapeContainer1" And Ctrl.Name <> "LblVersion" Then
                    Sql1 += "-- " & _i & vbCrLf & Fx_Sql_Crear_Detalle_X_Objeto_Mapa(Ctrl, _Id_Mapa, _Sectores)
                    _i += 1
                End If

            Next

            Dim _Contenedor_Figuras = _FrmActivo.ShapeContainer1

            For Each _Ctrl In _Contenedor_Figuras.Shapes
                'Insertamos objetos de diseño, muros, puertas, etc...
                If Mid(_Ctrl.Name, 1, 3) = "Box" Then
                    Sql1 += "-- " & _i & vbCrLf & Fx_Sql_Crear_Detalle_X_Objeto_Mapa(_Ctrl, _Id_Mapa, Nothing)
                    _i += 1
                End If
            Next

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & vbCrLf &
                           "Where Id_Mapa = " & _Id_Mapa & " And Tipo_Objeto <> 'SUB-SECTOR'" & vbCrLf & vbCrLf &
                           Sql1 & vbCrLf & Sql2

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                Consulta_sql = "SELECT  DISTINCT Empresa, Sucursal, Bodega, Id_Mapa, Tipo_Objeto, Codigo_Sector" & vbCrLf &
                               "FROM " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & vbCrLf &
                               "WHERE Tipo_Objeto = 'SECTOR'" & vbCrLf &
                               "And Codigo_Sector Not in (Select Codigo_Sector From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega)" & vbCrLf &
                               "And Id_Mapa = " & _Id_Mapa & vbCrLf &
                               "ORDER BY Id_Mapa,Codigo_Sector"

                Dim _TblSectores As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblSectores.Rows.Count) Then

                    Dim _SqlQuery = String.Empty

                    For Each _SectorRow As DataRow In _TblSectores.Rows

                        Dim _Codigo_Sector = _SectorRow.Item("Codigo_Sector")

                        _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega (Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Columna," &
                                     "NomColumna,Fila,Codigo_Ubic,Descripcion_Ubic) Values " &
                                     "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','C01','C01','01','','')" & vbCrLf & vbCrLf

                    Next

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
                        MessageBoxEx.Show(Me, "Se agregarón " & _TblSectores.Rows.Count & " sectores" & vbCrLf & vbCrLf &
                               _FrmActivo.Text, "Guardar Mapa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                               "Where Codigo_Sector Not In" & vbCrLf &
                               "(Select Codigo_Sector From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det where Tipo_Objeto = 'SECTOR')" & vbCrLf &
                               "And Codigo_Sector not In (Select Distinct Codigo_Ubic From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Es_SubSector = 1)"

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                MessageBoxEx.Show(Me, "Datos guardados correctamente" & vbCrLf & vbCrLf &
                                  _FrmActivo.Text, "Guardar Mapa", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        End Try
    End Sub

#End Region


#Region "FUNCION CREA LINEA DE DETALLE POR OBJETO"

    Function Fx_Sql_Crear_Detalle_X_Objeto_Mapa(ByVal _Ctrl As Object,
                                                ByVal _Id_Mapa As Integer,
                                                ByVal _Sectores(,) As String) As String

        Dim SQl_Query = String.Empty


        Dim _Tipo_Objeto
        Dim _Nombre_Objeto As String
        Dim _Codigo_Sector
        Dim _Nombre_Sector
        Dim _Texto

        Dim _Font_Nombre
        Dim _Font_Tamano
        Dim _Font_Negrita
        Dim _Font_Italic
        Dim _Font_Tachado
        Dim _Font_Subrayado
        Dim _Font_Estilo

        Dim _Alto_H
        Dim _Ancho_W

        'Dim _Estilo
        Dim _BackColor As Integer
        Dim _ForeColor As Integer
        Dim _Relleno = 0

        Dim _Y_Fila
        Dim _X_Columna

        Dim _Orientacion = 0


        Dim Tipo = Mid(_Ctrl.Name, 1, 3)

        If Tipo = "Lbl" Then

            With CType(_Ctrl, LabelX)

                _Nombre_Objeto = .Name

                If Mid(.Name, 1, 5) = "LblFx" Then
                    _Tipo_Objeto = "SECTOR"
                    _Codigo_Sector = .Text
                    _Texto = .Text

                    For i = 0 To 1000
                        Dim _N = _Sectores(i, 1)
                        If _Codigo_Sector = _N Then
                            _Nombre_Sector = _Sectores(i, 2)
                            Exit For
                        End If
                    Next


                Else
                    _Tipo_Objeto = "ETIQUETA"
                    _Codigo_Sector = String.Empty
                    _Texto = .Text
                End If

                _Font_Nombre = .Font.Name
                _Font_Tamano = .Font.Size
                _Font_Negrita = 0 'CInt(.Font.Bold) * -1
                _Font_Italic = 0 'CInt(.Font.Italic) * -1
                _Font_Tachado = 0 'CInt(.Font.Strikeout) * -1
                _Font_Subrayado = 0 'CInt(.Font.Underline) * -1
                _Font_Estilo = .Font.Style

                _ForeColor = .ForeColor.ToArgb
                _BackColor = .BackColor.ToArgb

                _Alto_H = .Height
                _Ancho_W = .Width

                _Y_Fila = .Location.Y
                _X_Columna = .Location.X

                _Orientacion = CInt(.TextOrientation)

            End With

        ElseIf Tipo = "Box" Then

            With CType(_Ctrl, RectangleShape)

                _Nombre_Objeto = .Name

                Dim _Nm = Split(_Nombre_Objeto, "_")

                _Tipo_Objeto = _Nm(1)
                _Codigo_Sector = String.Empty
                _Texto = String.Empty

                _Font_Nombre = String.Empty '.Font.Name
                _Font_Tamano = 0 '.Font.Size
                _Font_Estilo = 0
                _Font_Negrita = 0 '.Font.Bold
                _Font_Italic = 0 '.Font.Italic
                _Font_Tachado = 0 '.Font.Strikeout
                _Font_Subrayado = 0 '.Font.Underline

                Dim _Color As Color

                _Color = .FillColor
                _ForeColor = _Color.ToArgb

                _Color = .BackColor
                _BackColor = _Color.ToArgb

                _Alto_H = .Height
                _Ancho_W = .Width

                _Relleno = CInt(.FillStyle)

                _Y_Fila = .Location.Y
                _X_Columna = .Location.X


            End With
        Else
            Return SQl_Query
        End If



        SQl_Query = "Insert Into " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det(Empresa,Sucursal,Bodega,Id_Mapa,Tipo_Objeto,Nombre_Objeto," &
                    "Codigo_Sector,Nombre_Sector,Texto," &
                    "Font_Nombre,Font_Tamano,Font_Estilo,Font_Negrita,Font_Italic,Font_Tachado,Font_Subrayado," &
                    "Alto_H,Ancho_W,BackColor,ForeColor,Relleno,Y_Fila,X_Columna,Orientacion) Values " & vbCrLf &
                    "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Tipo_Objeto & "'," &
                    "'" & _Nombre_Objeto & "','" & _Codigo_Sector & "','" & _Nombre_Sector & "','" & _Texto & "','" & _Font_Nombre & "'," &
                    De_Num_a_Tx_01(_Font_Tamano, , 5) & "," & _Font_Estilo & "," & _Font_Negrita & "," & _Font_Italic & "," &
                    _Font_Tachado & "," & _Font_Subrayado & "," & _Alto_H & "," & _Ancho_W & "," &
                    _BackColor & "," & _ForeColor & "," & _Relleno & "," & _Y_Fila & "," & _X_Columna & "," & _Orientacion & ")"


        Return SQl_Query


    End Function

#End Region




#End Region

#End Region

    Private Sub Btn_NuevoMapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NuevoMapa.Click

        Dim Fm As New Frm_Mapa_Encabezado(_RowBodega)
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then

            Dim _RowMapa As DataRow = Fm.Pro_RowMapa
            Sb_Crear_Form_Mapa(_RowMapa)

        End If

        Fm.Dispose()

    End Sub

    Private Sub tabStrip1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabStrip1.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ShowContextMenu(Menu_Contextual_Opciones_Mapa)
        End If
    End Sub

    Private Sub Btn_Mnu_Editar_Mapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Editar_Mapa.Click

        If Fx_Tiene_Permiso(Me, "Ubic0019") Then

            Dim _Nombre_Mapa As String
            Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                      TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

            Dim _Id_Mapa As Integer = _FrmActivo.Pro_Id_Mapa
            Dim _RowMapa As DataRow = _FrmActivo.Pro_Row_Mapa

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Where Id_Mapa = " & _Id_Mapa
            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Aceptado As Boolean
            _Nombre_Mapa = _Tbl.Rows(0).Item("Nombre_Mapa")

            _Aceptado = InputBox_Bk(Me, "Ingrese el nombre del mapa", "Nombre de mapa Ubicaciones WMS", _Nombre_Mapa,
                                       False, _Tipo_Mayus_Minus.Mayusculas, 100, True, _Tipo_Imagen.Ubicacion, False,
                                       _Tipo_Caracter.Cualquier_caracter)

            If _Aceptado Then

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc",
                                      "Empresa = '" & _Empresa & "' And " &
                                      "Sucursal = '" & _Sucursal & "' And " &
                                      "Bodega = '" & _Bodega & "' And " &
                                      "Nombre_Mapa = '" & Trim(_Nombre_Mapa) & "' And " &
                                      "Id_Mapa <> " & _Id_Mapa))

                If _Reg Then
                    MessageBoxEx.Show(Me, "El nombre de este mapa ya existe",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Set Nombre_Mapa = '" & _Nombre_Mapa & "'" & vbCrLf &
                                   "Where Id_Mapa = " & _Id_Mapa
                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                        _FrmActivo.Text = _Nombre_Mapa
                        Beep()
                        ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE",
                                              Btn_Mnu_Editar_Mapa.Image,
                                             2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Eliminar_Mapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Eliminar_Mapa.Click

        If Fx_Tiene_Permiso(Me, "Ubic0020") Then
            Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                      TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

            Dim _Id_Mapa As Integer = _FrmActivo.Pro_Id_Mapa
            Dim _RowMapa As DataRow = _FrmActivo.Pro_Row_Mapa

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Id_Mapa = " & _Id_Mapa
            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                MessageBoxEx.Show(Me, "No se puede eliminar este mapa, ya que existen productos asociados en ubicaciones",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar este mapa, todos los sectores y ubicaciones se perderan?",
                                     "Eliminar mapa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = " & _Id_Mapa & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Where Id_Mapa = " & _Id_Mapa & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Where Id_Mapa = " & _Id_Mapa

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                        If Not _FrmActivo Is Nothing Then
                            _FrmActivo.Pro_Cerrar_Formulario = True
                            _FrmActivo.Close()
                        End If

                        Beep()
                        ToastNotification.Show(Me, "MAPA ELIMINADO",
                                              Btn_Mnu_Eliminar_Mapa.Image,
                                             2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)


                    End If

                End If
            End If
        End If


    End Sub


    Private Sub Btn_Exportar_Excel_Sectores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel_Sectores.Click


        Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                  TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

        Dim _Id_Mapa As Integer = _FrmActivo.Pro_Id_Mapa
        Dim _RowMapa As DataRow = _FrmActivo.Pro_Row_Mapa
        Dim _Nombre_Mapa As String = _RowMapa.Item("Nombre_Mapa")

        Consulta_sql = "Select '" & _Nombre_Mapa & "' as Mapa,* From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Where Id_Mapa = " & _Id_Mapa
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Sectores Mapa")

    End Sub

    Private Sub Btn_Exportar_Excel_Ubicaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel_Ubicaciones.Click

        Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                 TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

        Dim _Id_Mapa As Integer = _FrmActivo.Pro_Id_Mapa
        Dim _RowMapa As DataRow = _FrmActivo.Pro_Row_Mapa
        Dim _Nombre_Mapa As String = _RowMapa.Item("Nombre_Mapa")

        Consulta_sql = "Select '" & _Nombre_Mapa & "' as Mapa,* From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = " & _Id_Mapa
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Ubicaciones Mapa")

    End Sub

    Private Sub Btn_Exportar_Excel_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel_Productos.Click
        'Zw_Prod_Ubicacion

        Dim _FrmActivo As Frm_Formulario_Diseno_Mapa_Documentos =
                 TryCast(Me.ActiveMdiChild, Frm_Formulario_Diseno_Mapa_Documentos)

        Dim _Id_Mapa As Integer = _FrmActivo.Pro_Id_Mapa
        Dim _RowMapa As DataRow = _FrmActivo.Pro_Row_Mapa
        Dim _Nombre_Mapa As String = _RowMapa.Item("Nombre_Mapa")

        Consulta_sql = "Select '" & _Nombre_Mapa & "' as Mapa,*,Isnull((Select Top 1 NOKOPR From MAEPR Where KOPR = Codigo),'') as Descripcion From " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Id_Mapa = " & _Id_Mapa
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Productos Mapa")

    End Sub


End Class
