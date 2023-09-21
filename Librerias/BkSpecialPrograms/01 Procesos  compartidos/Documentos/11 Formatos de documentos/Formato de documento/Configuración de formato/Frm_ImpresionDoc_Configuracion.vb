Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.PowerPacks

Public Class Frm_ImpresionDoc_Configuracion
    'Inherits System.Windows.Forms.Form
    'Controls

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private btnAdd As New Button()
    Private lstBox As New ListBox()
    Private chkBox As New CheckBox()
    Private lblCount As New Label()

    Private DX, DY As Integer
    Dim ObjetoActivo As Object

    Dim PosicionX, PosicionY As Integer
    'Dim FilaPosicionSeleccionada As Object = LineaDetalle
    Dim PanelActivo As Control

    Dim _Objeto_Copiado As Object

    Dim TipoDos As String
    Dim NombreFormato As String

    'Public _TipoDoc, _NombreFormato As String
    Public _Editar_Documento As Boolean
    Public _Nuevo_Formato As Boolean

    Dim _Line_Aj_1, _Line_Aj_2 As Object
    Dim _Alto_Caja, _Ancho_Caja As Integer

    Dim _Impresora = String.Empty

    Dim _Row_Formato As DataRow

    Dim _RowDocumento_Pruebas As DataRow

    Dim _TipoDoc As String
    Dim _Subtido As String
    Dim _NombreFormato As String
    Dim _Emdp As String

    Public Property Pro_Impresora() As String
        Get
            Return _Impresora
        End Get
        Set(ByVal value As String)
            _Impresora = value
        End Set
    End Property

    Public Sub New(_TipoDoc As String,
                   _NombreFormato As String,
                   _Emdp As String,
                   _Subtido As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And " &
                            "NombreFormato = '" & _NombreFormato & "' And " &
                            "Emdp = '" & _Emdp & "' And " &
                            "Subtido = '" & _Subtido & "'"
        _Row_Formato = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me._TipoDoc = _Row_Formato.Item("TipoDoc")
        Me._NombreFormato = _Row_Formato.Item("NombreFormato")
        Me._Emdp = _Emdp
        Me._Subtido = _Subtido

        Me.Text = "DISEÑO DE DOCUMENTO"

        Sld_detalle_Inicio.TextColor = Rojo
        Sld_detalle_Fin.TextColor = Azul

    End Sub

    Private Sub Frm_ImpresionDoc_Configuracion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Fm As New Frm_Formato_Diseno_Encabezado(Me, _Row_Formato, False)
        Fm.WindowState = FormWindowState.Maximized
        Fm.MdiParent = Me
        Fm.Show()


        AddHandler CType(Sld_Tam_Alto, SliderItem).ValueChanged, AddressOf Control_Tamano_Obj_Alto_ValueChanged
        AddHandler CType(Sld_Tam_Ancho, SliderItem).ValueChanged, AddressOf Control_Tamano_Obj_Ancho_ValueChanged

        AddHandler CType(Sld_Ubicacion_X, SliderItem).ValueChanged, AddressOf Control_Ubicacion_Obj_X_ValueChanged
        AddHandler CType(Sld_Ubicacion_Y, SliderItem).ValueChanged, AddressOf Control_Ubicacion_Obj_Y_ValueChanged

    End Sub


    Private Sub Control_Tamano_Obj_Alto_ValueChanged(
                                              ByVal sender As Object,
                                              ByVal e As System.EventArgs)

        Try

            Dim _FrmActivo As Frm_Formato_Diseno_Encabezado =
                 TryCast(Me.ActiveMdiChild, Frm_Formato_Diseno_Encabezado)

            Dim _Tbl_Zw_Format_02 As DataTable = _FrmActivo.Tbl_Zw_Format_02

            Dim _Limite_Derecha = _FrmActivo.Documento.Width
            Dim _Limite_Abajo = _FrmActivo.Documento.Height

            Dim _ObjetoActivo = _FrmActivo.Pro_ObjetoActivo

            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3) '  
            Dim _Alto As Integer

            If _Tipo <> "Box" Then

                Dim ff = CType(_ObjetoActivo, Control).Text
                CType(_ObjetoActivo, Control).Height = sender.Value

            ElseIf _Tipo = "Box" Then

                Dim _Size = CType(_ObjetoActivo, RectangleShape).Size
                CType(_ObjetoActivo, RectangleShape).Size = New System.Drawing.Size(_Size.Width, sender.Value)

            End If

            _Alto = sender.Value
            sender.Tooltip = sender.value

            'For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

            '    Dim _Name = _Fila.Item("Name")
            '    Dim _Name_Objet = _ObjetoActivo.Name

            '    If _Name = _Name_Objet Then

            '        _Fila.Item("Ancho") = _Alto
            '        Exit For

            '    End If

            'Next
            _FrmActivo.Sb_Editar_Objeto(_ObjetoActivo)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_Tamano_Obj_Ancho_ValueChanged(
                                               ByVal sender As System.Object,
                                               ByVal e As System.EventArgs)
        Try

            Dim _FrmActivo As Frm_Formato_Diseno_Encabezado =
                  TryCast(Me.ActiveMdiChild, Frm_Formato_Diseno_Encabezado)

            Dim _Tbl_Zw_Format_02 As DataTable = _FrmActivo.Tbl_Zw_Format_02

            Dim _Limite_Derecha = _FrmActivo.Documento.Width
            Dim _Limite_Abajo = _FrmActivo.Documento.Height

            Dim _ObjetoActivo = _FrmActivo.Pro_ObjetoActivo

            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3)
            Dim _Ancho As Integer

            If _Tipo = "Txt" Or _Tipo = "Pic" Or _Tipo = "Lbl" Then

                CType(_ObjetoActivo, Control).Width = sender.Value
                _Ancho = CType(_ObjetoActivo, Control).Width

            ElseIf _Tipo = "Lin" Then

                CType(_ObjetoActivo, LineShape).X2 = CType(_ObjetoActivo, LineShape).X1 + sender.Value
                _Ancho = CType(_ObjetoActivo, LineShape).X2

            ElseIf _Tipo = "Box" Then

                Dim _Size = CType(_ObjetoActivo, RectangleShape).Size
                CType(_ObjetoActivo, RectangleShape).Size = New System.Drawing.Size(sender.Value, _Size.Height)
                _Ancho = sender.Value

            End If

            'For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

            '    Dim _Name = _Fila.Item("Name")
            '    Dim _Name_Objet = _ObjetoActivo.Name

            '    If _Name = _Name_Objet Then

            '        _Fila.Item("Ancho") = _Ancho
            '        Exit For

            '    End If

            'Next

            _FrmActivo.Sb_Editar_Objeto(_ObjetoActivo)

            sender.Tooltip = sender.value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_Ubicacion_Obj_X_ValueChanged(
                                              ByVal sender As Object,
                                              ByVal e As System.EventArgs)

        Dim _FrmActivo As Frm_Formato_Diseno_Encabezado =
                   TryCast(Me.ActiveMdiChild, Frm_Formato_Diseno_Encabezado)

        Dim _Tbl_Zw_Format_02 As DataTable = _FrmActivo.Tbl_Zw_Format_02

        Dim _Limite_Derecha = _FrmActivo.Documento.Width
        Dim _Limite_Abajo = _FrmActivo.Documento.Height

        Dim _ObjetoActivo = _FrmActivo.Pro_ObjetoActivo

        Try

            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3)
            Dim _Columna_X As Integer

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
            _Columna_X = sender.value

            'For Each _Fila As DataRow In _Tbl_Zw_Format_02.Rows

            '    Dim _Name = _Fila.Item("Name")
            '    Dim _Name_Objet = _ObjetoActivo.Name

            '    If _Name = _Name_Objet Then

            '        _Fila.Item("Columna_X") = _Columna_X
            '        Exit For

            '    End If

            'Next

            _FrmActivo.Sb_Editar_Objeto(_ObjetoActivo)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_Ubicacion_Obj_Y_ValueChanged(
                                              ByVal sender As Object,
                                              ByVal e As System.EventArgs)

        Try

            Dim _FrmActivo As Frm_Formato_Diseno_Encabezado =
                   TryCast(Me.ActiveMdiChild, Frm_Formato_Diseno_Encabezado)

            Dim _Tbl_Zw_Format_02 As DataTable = _FrmActivo.Tbl_Zw_Format_02

            Dim _Limite_Derecha = _FrmActivo.Documento.Width
            Dim _Limite_Abajo = _FrmActivo.Documento.Height

            Dim _ObjetoActivo = _FrmActivo.Pro_ObjetoActivo

            Dim _Tipo = Mid(_ObjetoActivo.Name, 1, 3) '

            Dim _Sld = Mid(sender.name, 1, 3)

            Dim _Fila_Y As Integer

            If _Tipo <> "Box" And _Tipo <> "Lin" Then

                Dim _Y = CType(_ObjetoActivo, Control).Location.Y

                Dim _Y_Avanza = sender.value - _Y

                Dim X = CType(_ObjetoActivo, Control).Location.X
                CType(_ObjetoActivo, Control).Location = New System.Drawing.Point(X, sender.value)

                If _Sld = "Sld" Then

                    If Chk_Mover_Abajo_Tambien.Checked Then

                        For Each Ctrl In _FrmActivo.Documento.Controls
                            ' No asignar estos evento al botón salir
                            If Ctrl.Name <> "ShapeContainer1" And Ctrl.Name <> "LblVersion" And Ctrl.Name <> "Lbl_Lineas_x_Pagina" Then
                                ' Curiosamente un control GroupBox en apariencia
                                ' no tiene estos eventos, pero... se le asigna y...
                                ' ¡funciona!

                                If Ctrl.Name <> "Lbl_Lineas_x_Pagina" And Ctrl.Name <> _ObjetoActivo.Name Then

                                    X = CType(Ctrl, Control).Location.X
                                    Dim Y = CType(Ctrl, Control).Location.Y

                                    If Y > _Y Then
                                        CType(Ctrl, Control).Location = New System.Drawing.Point(X, Y + _Y_Avanza)
                                        _FrmActivo.Sb_Editar_Objeto(Ctrl)
                                    End If

                                End If

                            End If

                        Next

                    End If

                End If

            ElseIf _Tipo = "Box" Then

                Dim _Largo_Obj = CType(_ObjetoActivo, RectangleShape).Height
                Dim _Y_Limite = CType(_ObjetoActivo, RectangleShape).Location.Y + _Largo_Obj

                Dim _NewY = sender.Value

                If _Y_Limite > _Limite_Abajo Then
                    _NewY = _Limite_Abajo - _Largo_Obj - 5
                End If

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
            _Fila_Y = sender.value

            _FrmActivo.Sb_Editar_Objeto(_ObjetoActivo)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabPage2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        PosicionX = e.X.ToString
        PosicionY = e.Y.ToString
    End Sub

    Private Sub TabPage3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        PosicionX = e.X.ToString
        PosicionY = e.Y.ToString
    End Sub

    Private Sub Documento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PanelActivo = sender
    End Sub

    Private Sub Documento_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        PosicionX = e.X.ToString
        PosicionY = e.Y.ToString
        Lbl_X.Text = "X : " & PosicionX
        Lbl_Y.Text = "Y : " & PosicionY
    End Sub

    Private Sub Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Arrow
        ObjetoActivo = Nothing ' = String.Empty
    End Sub

    Private Sub Documento_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Arrow
        _Objeto_Copiado = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Control_Encima_Slp(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.Tooltip = sender.value
    End Sub

    Sub Sb_Traer_Documento_Para_Imprimir(ByVal _Vista_Previa As Boolean, _Exportar_a_PDF As Boolean, _Imprimir_Excel As Boolean)

        Dim _Imprimir As Boolean
        Dim _Es_Sol_Bodega As Boolean
        Dim _Se_Puede_Exportar_PDF As Boolean

        Dim _TipoDoc As String = _Row_Formato.Item("TipoDoc")

        If _TipoDoc = "SPB" Then

            _Es_Sol_Bodega = True
            _Imprimir = True

        ElseIf _TipoDoc = "CHC" Or _TipoDoc = "CPG" Or _TipoDoc = "TJV" Then

            If Not (_RowDocumento_Pruebas Is Nothing) Then

                Dim _Tidp = _RowDocumento_Pruebas.Item("TIDP")
                Dim _Nudp = _RowDocumento_Pruebas.Item("NUDP")
                Dim _Nucudp = _RowDocumento_Pruebas.Item("NUCUDP")

                Dim _Consulta = MessageBoxEx.Show(Me, "¿Desea utilizar el mismo documento para imprimir?" & vbCrLf &
                                     "Documento: " & _Tidp & "-" & _Nudp & " - Número: " & _Nucudp,
                                     "Imprimir", MessageBoxButtons.YesNoCancel)

                If _Consulta = Windows.Forms.DialogResult.Yes Then
                    _Imprimir = True
                ElseIf _Consulta = Windows.Forms.DialogResult.No Then
                    _RowDocumento_Pruebas = Nothing
                Else
                    Return
                End If

            End If

            If (_RowDocumento_Pruebas Is Nothing) Then

                Dim _Tipo_Pago As Integer

                If _TipoDoc = "CHC" Or _TipoDoc = "CPG" Then
                    _Tipo_Pago = 0
                ElseIf _TipoDoc = "TJV" Then
                    _Tipo_Pago = 1
                End If

                Dim _Fm_Chc As New Frm_Tenerduria_Buscar_Documento_Pago(_Tipo_Pago, True) ' (Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Proveedores, True)
                _Fm_Chc.ShowDialog(Me)
                _RowDocumento_Pruebas = _Fm_Chc.Pro_Row_Documento_Seleccionado
                _Fm_Chc.Dispose()

                If Not (_RowDocumento_Pruebas Is Nothing) Then
                    _Imprimir = True
                End If

            End If

            _Imprimir = True

        Else

            If Not (_RowDocumento_Pruebas Is Nothing) Then

                Dim _Tido = _RowDocumento_Pruebas.Item("TIDO")
                Dim _Nudo = _RowDocumento_Pruebas.Item("NUDO")

                Dim _Consulta = MessageBoxEx.Show(Me, "¿Desea utilizar el mismo documento para imprimir?" & vbCrLf &
                                     "Documento: " & _Tido & "-" & _Nudo, "Imprimir", MessageBoxButtons.YesNoCancel)

                If _Consulta = Windows.Forms.DialogResult.Yes Then
                    _Imprimir = True
                ElseIf _Consulta = Windows.Forms.DialogResult.No Then
                    _RowDocumento_Pruebas = Nothing
                Else
                    Return
                End If

            End If

            If (_RowDocumento_Pruebas Is Nothing) Then

                Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
                _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, _TipoDoc)
                _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

                _Fm.Rdb_Tipo_Documento_Algunos.Checked = False
                _Fm.Rdb_Tipo_Documento_Uno.Checked = True

                _Fm.ShowDialog(Me)
                _RowDocumento_Pruebas = _Fm.Pro_Row_Documento_Seleccionado
                _Fm.Dispose()

                If Not (_RowDocumento_Pruebas Is Nothing) Then
                    _Imprimir = True
                End If

            End If

            _Se_Puede_Exportar_PDF = _Imprimir

        End If

        If _Imprimir_Excel Then

            If IsNothing(_RowDocumento_Pruebas) Then
                Return
            End If

            Dim _Doc_Electronico As Boolean = _Row_Formato.Item("Doc_Electronico") 'Fx_Es_Electronico(_TipoDoc)
            Dim _Copias As Integer = _Row_Formato.Item("Copias")

            Dim _IdDoc As Integer = _RowDocumento_Pruebas.Item("IDMAEEDO")

            Dim _Tido = _RowDocumento_Pruebas.Item("TIDO")
            Dim _Nudo = _RowDocumento_Pruebas.Item("NUDO")
            Dim _Subtido = String.Empty

            If _Tido = "GDD" Or _Tido = "GDP" Then
                _Subtido = _RowDocumento_Pruebas.Item("SUBTIDO")
            End If

            Dim _Imp_Excel As New Clas_Imprimir_Documento(_IdDoc,
                                                          _TipoDoc,
                                                          _NombreFormato,
                                                          _Tido & "-" & _Nudo,
                                                          False, _Emdp, _Subtido)

            ExportarTabla_JetExcel_Tabla(_Imp_Excel.Tbl_Encabezado, Me, "Encabezado")
            ExportarTabla_JetExcel_Tabla(_Imp_Excel.Tbl_Detalle, Me, "Detalle")

        ElseIf _Imprimir Then

            If _Exportar_a_PDF Then

                Fx_Imprimir_En_PDF()

            Else

                Fx_Imprimir_Vista_Previa(Me, _RowDocumento_Pruebas, _Vista_Previa, True, True, False, True, _Es_Sol_Bodega)

            End If

        End If

    End Sub

    Sub Sb_Traer_Documento_Para_Exportar_Imprimir(ByVal _Vista_Previa As Boolean)

        Dim _Imprimir As Boolean
        Dim _Es_Sol_Bodega As Boolean

        Dim _TipoDoc As String = _Row_Formato.Item("TipoDoc")

        If _TipoDoc = "SPB" Then

            _Es_Sol_Bodega = True
            _Imprimir = True

        ElseIf _TipoDoc = "CHC" Or _TipoDoc = "CPG" Or _TipoDoc = "TJV" Then

            If Not (_RowDocumento_Pruebas Is Nothing) Then

                Dim _Tidp = _RowDocumento_Pruebas.Item("TIDP")
                Dim _Nudp = _RowDocumento_Pruebas.Item("NUDP")
                Dim _Nucudp = _RowDocumento_Pruebas.Item("NUCUDP")

                Dim _Consulta = MessageBoxEx.Show(Me, "¿Desea utilizar el mismo documento para imprimir?" & vbCrLf &
                                     "Documento: " & _Tidp & "-" & _Nudp & " - Número: " & _Nucudp,
                                     "Imprimir", MessageBoxButtons.YesNoCancel)

                If _Consulta = Windows.Forms.DialogResult.Yes Then
                    _Imprimir = True
                ElseIf _Consulta = Windows.Forms.DialogResult.No Then
                    _RowDocumento_Pruebas = Nothing
                Else
                    Return
                End If

            End If

            If (_RowDocumento_Pruebas Is Nothing) Then

                Dim _Tipo_Pago As Integer

                If _TipoDoc = "CHC" Or _TipoDoc = "CPG" Then
                    _Tipo_Pago = 0
                ElseIf _TipoDoc = "TJV" Then
                    _Tipo_Pago = 1
                End If

                Dim _Fm_Chc As New Frm_Tenerduria_Buscar_Documento_Pago(_Tipo_Pago, True) ' (Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Proveedores, True)
                _Fm_Chc.ShowDialog(Me)
                _RowDocumento_Pruebas = _Fm_Chc.Pro_Row_Documento_Seleccionado
                _Fm_Chc.Dispose()

                If Not (_RowDocumento_Pruebas Is Nothing) Then
                    _Imprimir = True
                End If

            End If

            _Imprimir = True
        Else
            If Not (_RowDocumento_Pruebas Is Nothing) Then

                Dim _Tido = _RowDocumento_Pruebas.Item("TIDO")
                Dim _Nudo = _RowDocumento_Pruebas.Item("NUDO")

                Dim _Consulta = MessageBoxEx.Show(Me, "¿Desea utilizar el mismo documento para imprimir?" & vbCrLf &
                                     "Documento: " & _Tido & "-" & _Nudo, "Imprimir", MessageBoxButtons.YesNoCancel)

                If _Consulta = Windows.Forms.DialogResult.Yes Then
                    _Imprimir = True
                ElseIf _Consulta = Windows.Forms.DialogResult.No Then
                    _RowDocumento_Pruebas = Nothing
                Else
                    Return
                End If

            End If

            If (_RowDocumento_Pruebas Is Nothing) Then
                Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
                _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, _TipoDoc)
                _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

                _Fm.Rdb_Tipo_Documento_Algunos.Enabled = False
                _Fm.Rdb_Fecha_Emision_Cualquiera.Checked = False
                _Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True

                _Fm.Rdb_Tipo_Documento_Algunos.Checked = False
                _Fm.Rdb_Tipo_Documento_Uno.Checked = True

                _Fm.ShowDialog(Me)
                _RowDocumento_Pruebas = _Fm.Pro_Row_Documento_Seleccionado
                _Fm.Dispose()

                If Not (_RowDocumento_Pruebas Is Nothing) Then
                    _Imprimir = True
                End If
            End If
        End If

        If _Imprimir Then
            Fx_Imprimir_Vista_Previa(Me, _RowDocumento_Pruebas, _Vista_Previa, True, True, False, True, _Es_Sol_Bodega)
        End If

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Dim _FrmActivo As Frm_Formato_Diseno_Encabezado =
                  TryCast(Me.ActiveMdiChild, Frm_Formato_Diseno_Encabezado)

        _FrmActivo.Sb_Grabar_Movimientos()

    End Sub

    Private Sub Btn_Copiar_Formato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar_Formato.Click

        Dim Fm As New Frm_Formato_Diseno_Copiar_Formato(_TipoDoc, _NombreFormato, _Subtido)
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            Me.Close()
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Imprimir_Regleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Regleta.Click

        Dim _Imprimir As New Clas_Imprimir_Documento(0, _TipoDoc, _NombreFormato, "Regleta", False, "", _Subtido)
        _Imprimir.Fx_Imprimir_Regleta()

    End Sub

    Private Sub Btn_Mnu_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Imprimir.Click
        Sb_Traer_Documento_Para_Imprimir(False, False, False)
    End Sub

    Private Sub Btn_Mnu_Imprimir_PDF_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Imprimir_PDF.Click
        Sb_Traer_Documento_Para_Imprimir(False, True, False)
    End Sub

    Private Sub Btn_Detalle_Doc_Incluye_Click(sender As Object, e As EventArgs) Handles Btn_Detalle_Doc_Incluye.Click
        ShowContextMenu(Menu_Contextual_Detalle_Incluye)
    End Sub

    Private Sub Btn_Mnu_Vista_Previa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Vista_Previa.Click
        Sb_Traer_Documento_Para_Imprimir(True, False, False)
    End Sub

    Function Fx_Imprimir_Vista_Previa(_Formulario As Form,
                                      _RowDocumento As DataRow,
                                      _Vista_Previa As Boolean,
                                      _Preguntar_Cedible As Boolean,
                                      _Seleccionar_Impresora As Boolean,
                                      _Imprimir_Cedible As Boolean,
                                      _Mostrar_Mensaje_Error As Boolean,
                                      _Es_Sol_Bodega As Boolean) As Boolean

        Dim _Documento_Impreso As Boolean
        Dim _Campo_Id As String

        Dim _Campo_Tido As String
        Dim _Campo_Nudo As String

        If _Es_Sol_Bodega Then

            _Campo_Id = "Id"
            _NombreFormato = "Solicitud_PrBd"

            _Documento_Impreso = Fx_Imprimir(_TipoDoc,
                                             _NombreFormato,
                                             0,
                                             "",
                                             "", False, _Seleccionar_Impresora, _Impresora, _Vista_Previa, _Emdp, _Subtido)

        Else
            If String.IsNullOrEmpty(_Emdp) Then
                _Campo_Id = "IDMAEEDO"
                _Campo_Tido = "TIDO"
                _Campo_Nudo = "NUDO"
            Else
                _Campo_Id = "IDMAEDPCE"
                _Campo_Tido = "TIDP"
                _Campo_Nudo = "NUDP"
            End If
        End If

        If Not (_RowDocumento Is Nothing) Then

            If Not (_Row_Formato Is Nothing) Then

                Dim _Doc_Electronico As Boolean = _Row_Formato.Item("Doc_Electronico") 'Fx_Es_Electronico(_TipoDoc)
                Dim _Copias As Integer = _Row_Formato.Item("Copias")

                Dim _IdDoc As Integer = _RowDocumento.Item(_Campo_Id)

                Dim _Tido = _RowDocumento.Item(_Campo_Tido)
                Dim _Nudo = _RowDocumento.Item(_Campo_Nudo)

                If _Seleccionar_Impresora Then
                    _Impresora = String.Empty
                End If

                If _Vista_Previa Then _Copias = 1

                For i = 1 To _Copias
                    _Documento_Impreso = Fx_Imprimir(_TipoDoc, _NombreFormato, _IdDoc, _Tido, _Nudo, False, _Seleccionar_Impresora,
                                                     _Impresora, _Vista_Previa, _Emdp, _Subtido)
                Next

                If _Doc_Electronico Then

                    If Not _Imprimir_Cedible Then
                        If _Preguntar_Cedible Then
                            If MessageBoxEx.Show(Me, "¿Desea imprimir la copia CEDIBLE?", "Imprimir CEDIBLE",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, True) = Windows.Forms.DialogResult.Yes Then
                                _Imprimir_Cedible = True
                            End If
                        End If
                    End If

                    If _Imprimir_Cedible Then

                        Fx_Imprimir(_TipoDoc, _NombreFormato, _IdDoc, _Tido, _Nudo, _Imprimir_Cedible, _Seleccionar_Impresora,
                                    _Impresora, _Vista_Previa, _Emdp, _Subtido)

                    End If

                End If

            Else
                If _Mostrar_Mensaje_Error Then
                    MessageBoxEx.Show(_Formulario, "El formato de documento [" & _NombreFormato & "] No existe en la base de datos",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If

        Return _Documento_Impreso


    End Function

    Private Sub Btn_Imprimir_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Excel.Click
        Sb_Traer_Documento_Para_Imprimir(False, False, True)
    End Sub

    Function Fx_Imprimir(_TipoDoc As String,
                         _NombreFormato As String,
                         _IdDoc As Integer,
                         _Tido As String,
                         _Nudo As String,
                         _Imprimir_Cedible As Boolean,
                         _Seleccionar_Impresora As Boolean,
                         _Impresora As String,
                         _Vista_Previa As Boolean,
                         _Emdp As String,
                         _Subtido As String) As Boolean

        Dim _Imprimir As New Clas_Imprimir_Documento(_IdDoc,
                                                     _TipoDoc,
                                                     _NombreFormato,
                                                     _Tido & "-" & _Nudo,
                                                     _Imprimir_Cedible,
                                                     _Emdp,
                                                     _Subtido)
        Dim _Documento_Impreso As Boolean


        If Not String.IsNullOrEmpty(_Impresora) Then
            _Imprimir.Pro_Impresora = _Impresora
        End If

        If _Seleccionar_Impresora Then
            If Not _Imprimir.Fx_seleccionar_Impresora(_Seleccionar_Impresora) Then
                Return False
            End If
        End If

        ' _Imprimir.Pro_Idmaeedo = _Idmaeedo
        _Imprimir.Fx_Imprimir_Documento(Nothing, _Vista_Previa)

        Dim _LogError = _Imprimir.Pro_Ultimo_Error

        _Impresora = _Imprimir.Pro_Impresora
        _Documento_Impreso = _Imprimir.Pro_Documento_Impreso

        Return _Documento_Impreso

    End Function

    Function Fx_Imprimir_En_PDF() As Boolean

        Dim _IdMaeedo = _RowDocumento_Pruebas.Item("IDMAEEDO")
        Dim _Tido = _RowDocumento_Pruebas.Item("TIDO")
        Dim _Nudo = _RowDocumento_Pruebas.Item("NUDO")
        'Dim _Subtido = _RowDocumento_Pruebas.Item("SUBTIDO")
        Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"

        Dim _Doc_Electronico As Boolean = _Row_Formato.Item("Doc_Electronico")
        Dim _Imprimir_Cedible As Boolean

        If _Doc_Electronico Then

            If MessageBoxEx.Show(Me, "¿Desea imprimir la copia CEDIBLE?", "Imprimir CEDIBLE", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, True) = Windows.Forms.DialogResult.Yes Then
                _Imprimir_Cedible = True
            End If

        End If

        Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_IdMaeedo,
                                                         _Tido,
                                                         _NombreFormato,
                                                         _Tido & "-" & _Nudo,
                                                         _Path, _Tido & "-" & _Nudo, _Imprimir_Cedible)

        _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)

        Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error
        Dim _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

        If String.IsNullOrEmpty(_Error_Pdf) Then

            _Pdf_Adjunto.Sb_Abrir_Archivo()

            If _Imprimir_Cedible Then
                _Pdf_Adjunto.Pro_Nombre_Archivo = _Pdf_Adjunto.Pro_Nombre_Archivo & "_Cedible"
                _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")
                _Pdf_Adjunto.Sb_Abrir_Archivo()
            End If

        Else

            MessageBoxEx.Show(Me, _Error_Pdf, "Problemas al crear el archivo", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If


    End Function

    Function Fx_Imprimir_Excel()



    End Function
    Private Sub Btn_VistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_VistaPrevia.Click
        ShowContextMenu(Menu_Contextual_Imprimir_Vista_Previa)
    End Sub

End Class
