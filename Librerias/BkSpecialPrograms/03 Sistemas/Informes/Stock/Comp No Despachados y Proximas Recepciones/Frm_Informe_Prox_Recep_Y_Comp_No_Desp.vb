Imports DevComponents.DotNetBar

Public Class Frm_Informe_Prox_Recep_Y_Comp_No_Desp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String
    Dim _SqlFiltro As String

    Dim _Ds_Informes As DataSet
    Dim _Row_Totales As DataRow
    Dim _Tbl_Informe As DataTable

    Dim _Fl_Sucursales = String.Empty
    Dim _Fl_Bodegas = String.Empty
    Dim _Fl_Super_Familias = String.Empty
    Dim _Fl_Entidades = String.Empty
    Dim _Fl_Ciudades = String.Empty
    Dim _Fl_Comunas = String.Empty
    Dim _Fl_Productos_Consolidados = String.Empty
    Dim _Fl_Funcionarios = String.Empty

    Dim _Cp_Codigo, _Cp_Descripcion, _Tx_Descripcion As String

    Dim _Kosu As String

    Private _dv As New DataView
    Dim _Informe As Enum_Informe

    Enum Enum_Informe
        Sucursal
        Bodega
        Super_Familia
        Entidades
        Ciudades
        Comunas
        Productos_Consolidados
        Funcionarios
    End Enum

    Dim _Unidada As Integer

    Dim _Nombre_Excel As String
    Dim _Correr_a_la_derecha As Boolean

    Enum Enum_Informe_Padre
        Informe_Proximas_Recpciones
        Informe_Compromisos_No_Despachados
    End Enum
    Dim _Informe_Padre As Enum_Informe_Padre

    Dim _Top, _Left As Integer

    Public Property Pro_Fl_Sucursales() As String
        Get
            Return _Fl_Sucursales
        End Get
        Set(ByVal value As String)
            _Fl_Sucursales = value
        End Set
    End Property

    Public Property Pro_Fl_Bodegas() As String
        Get
            Return _Fl_Bodegas
        End Get
        Set(ByVal value As String)
            _Fl_Bodegas = value
        End Set
    End Property

    Public Property Pro_Fl_Entidades() As String
        Get
            Return _Fl_Entidades
        End Get
        Set(ByVal value As String)
            _Fl_Entidades = value
        End Set
    End Property

    Public Property Pro_Fl_Super_Familias() As String
        Get
            Return _Fl_Super_Familias
        End Get
        Set(ByVal value As String)
            _Fl_Super_Familias = value
        End Set
    End Property

    Public Property Pro_Fl_Ciudades() As String
        Get
            Return _Fl_Ciudades
        End Get
        Set(ByVal value As String)
            _Fl_Ciudades = value
        End Set
    End Property

    Public Property Pro_Fl_Comunas() As String
        Get
            Return _Fl_Comunas
        End Get
        Set(ByVal value As String)
            _Fl_Comunas = value
        End Set
    End Property

    Public Property Pro_Fl_Productos_Consolidados() As String
        Get
            Return _Fl_Productos_Consolidados
        End Get
        Set(ByVal value As String)
            _Fl_Productos_Consolidados = value
        End Set
    End Property

    Public Property Pro_Fl_Funcionarios() As String
        Get
            Return _Fl_Funcionarios
        End Get
        Set(ByVal value As String)
            _Fl_Funcionarios = value
        End Set
    End Property

    Public Property Pro_Top() As Integer
        Get
            Return Me.Top
        End Get
        Set(ByVal value As Integer)
            _Top = value
        End Set
    End Property

    Public Property Pro_Left() As Integer
        Get
            Return Me.Left
        End Get
        Set(ByVal value As Integer)
            _Left = value
        End Set
    End Property

    Public Sub New(Informe_Padre As Enum_Informe_Padre,
                   Informe As Enum_Informe,
                   Nombre_Tabla_Paso As String,
                   Unidad As Integer,
                   Optional Correr_a_la_derecha As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Informe_Padre = Informe_Padre
        _Unidada = Unidad
        _Tabla_Paso = Nombre_Tabla_Paso
        _Informe = Informe
        _Correr_a_la_derecha = Correr_a_la_derecha

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Informe_Prox_Recep_02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _SqlFiltro = _Fl_Sucursales & vbCrLf &
                     _Fl_Bodegas & vbCrLf &
                     _Fl_Super_Familias & vbCrLf &
                     _Fl_Entidades & vbCrLf &
                     _Fl_Ciudades & vbCrLf &
                     _Fl_Comunas & vbCrLf &
                     _Fl_Productos_Consolidados & vbCrLf &
                     _Fl_Funcionarios


        If _Correr_a_la_derecha Then
            Me.Top = _Top + 5
            Me.Left = _Left + 5
        End If

        Btn_Informe_X_Bodega.Visible = String.IsNullOrEmpty(_Fl_Bodegas)
        Btn_Informe_X_Super_Familia.Visible = String.IsNullOrEmpty(_Fl_Super_Familias)
        Btn_Informe_X_Entidades.Visible = String.IsNullOrEmpty(_Fl_Entidades)
        Btn_Informe_X_Ciudades.Visible = String.IsNullOrEmpty(_Fl_Ciudades)
        Btn_Informe_X_Comunas.Visible = String.IsNullOrEmpty(_Fl_Comunas)
        Btn_Informe_X_Productos_Consolidados.Visible = String.IsNullOrEmpty(_Fl_Productos_Consolidados)
        Btn_Informe_X_Funcionarios.Visible = String.IsNullOrEmpty(_Fl_Funcionarios)

        AddHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown

        Select Case _Informe
            Case Enum_Informe.Sucursal
                _Nombre_Excel = "Inf_X_Sucursal"
                _Cp_Codigo = "SULIDO" : _Cp_Descripcion = "SUCURSAL" : _Tx_Descripcion = "Sucursales"
                RemoveHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown
            Case Enum_Informe.Bodega
                Btn_Informe_X_Bodega.Visible = False
                _Nombre_Excel = "Inf_X_Bodega"
                _Cp_Codigo = "BOSULIDO" : _Cp_Descripcion = "BODEGA" : _Tx_Descripcion = "Bodegas"
            Case Enum_Informe.Super_Familia
                Btn_Informe_X_Super_Familia.Visible = False
                _Nombre_Excel = "Inf_X_Familia"
                _Cp_Codigo = "FMPR" : _Cp_Descripcion = "SUPER_FAMILIA" : _Tx_Descripcion = "Super Familias"
            Case Enum_Informe.Entidades
                Btn_Informe_X_Entidades.Visible = False
                _Nombre_Excel = "Inf_X_Entidades"
                _Cp_Codigo = "ENDO+SUENDO" : _Cp_Descripcion = "NOKOEN" : _Tx_Descripcion = "Razón Social"
            Case Enum_Informe.Ciudades
                Btn_Informe_X_Ciudades.Visible = False
                _Nombre_Excel = "Inf_X_Ciudades"
                _Cp_Codigo = "CIEN" : _Cp_Descripcion = "CIUDAD" : _Tx_Descripcion = "Ciudades-Regiones"
            Case Enum_Informe.Comunas
                Btn_Informe_X_Comunas.Visible = False
                _Nombre_Excel = "Inf_X_Comunas"
                _Cp_Codigo = "CMEN" : _Cp_Descripcion = "COMUNA" : _Tx_Descripcion = "Comunas"
            Case Enum_Informe.Productos_Consolidados
                Btn_Informe_X_Productos_Consolidados.Visible = False
                _Nombre_Excel = "Inf_X_Productos_Cons"
                _Cp_Codigo = "KOPRCT" : _Cp_Descripcion = "NOKOPR" : _Tx_Descripcion = "Productos (Descripción)"
            Case Enum_Informe.Funcionarios
                Btn_Informe_X_Funcionarios.Visible = False
                _Nombre_Excel = "Inf_X_Funcionarios"
                _Cp_Codigo = "KOFULIDO" : _Cp_Descripcion = "FUNCIONARIO"
                If _Informe_Padre = Enum_Informe_Padre.Informe_Compromisos_No_Despachados Then
                    _Tx_Descripcion = "Vendedor"
                ElseIf _Informe_Padre = Enum_Informe_Padre.Informe_Proximas_Recpciones Then
                    _Tx_Descripcion = "Comprador"
                End If
        End Select

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub


    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select " & _Cp_Codigo & " As CODIGO," & _Cp_Descripcion & " As DESCRIPCION," &
                       "Sum(SALDO_Ud" & _Unidada & ") As SALDO_Ud,Sum(TOT_SALDOxPRECIOREAL) As TOT_SALDOxPRECIOREAL" & vbCrLf &
                       "From " & _Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _SqlFiltro & vbCrLf &
                       "Group By " & _Cp_Codigo & "," & _Cp_Descripcion & vbCrLf &
                       "Union" & vbCrLf &
                       "Select 'ZZZ','TOTAL',Sum(SALDO_Ud1),Sum(TOT_SALDOxPRECIOREAL)" & vbCrLf &
                       "From " & _Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _SqlFiltro

        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("CODIGO").Width = 110
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Visible = True

            .Columns("DESCRIPCION").Width = 300
            .Columns("DESCRIPCION").HeaderText = _Tx_Descripcion
            .Columns("DESCRIPCION").Visible = True

            .Columns("SALDO_Ud").Width = 110
            .Columns("SALDO_Ud").HeaderText = "Saldo Cant."
            .Columns("SALDO_Ud").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_Ud").DefaultCellStyle.Format = "###,##"
            .Columns("SALDO_Ud").Visible = True

            .Columns("TOT_SALDOxPRECIOREAL").Width = 120
            .Columns("TOT_SALDOxPRECIOREAL").HeaderText = "Saldo $"
            .Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TOT_SALDOxPRECIOREAL").Visible = True

        End With

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Informe)
                End If
            End With
        End If
    End Sub


    Sub Sb_Revisar_Sub_Informe(_Sub_Informe As Enum_Informe)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells(0).Value
        Dim _Des = UCase(_Informe.ToString)
        _Des = UCase(Trim(_Fila.Cells("DESCRIPCION").Value))

        Dim _Texto_Fm As String

        If _Cod = "ZZZ" Then
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": TODAS"
        Else
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": " & Trim(_Des)
        End If

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Super_Familias = _Fl_Super_Familias
        Dim Fl_Entidades = _Fl_Entidades
        Dim Fl_Ciudades = _Fl_Ciudades
        Dim Fl_Comunas = _Fl_Comunas
        Dim Fl_Productos_Consolidados = _Fl_Productos_Consolidados
        Dim Fl_Funcionarios = _Fl_Funcionarios

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro("SULIDO") 'Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro("BOSULIDO") 'Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Super_Familias = Fx_Traer_Filtro("FMPR") 'Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Entidades
                Fl_Entidades = Fx_Traer_Filtro("ENDO+SUENDO")
            Case Enum_Informe.Ciudades
                Fl_Ciudades = Fx_Traer_Filtro("CIEN")
            Case Enum_Informe.Comunas
                Fl_Comunas = Fx_Traer_Filtro("CMEN")
            Case Enum_Informe.Productos_Consolidados
                Fl_Productos_Consolidados = Fx_Traer_Filtro("KOPRCT")
            Case Enum_Informe.Funcionarios
                Fl_Funcionarios = Fx_Traer_Filtro("KOFULIDO")
        End Select


        Dim Fm As New Frm_Informe_Prox_Recep_Y_Comp_No_Desp(_Informe_Padre,
                                                            _Sub_Informe,
                                                            _Tabla_Paso,
                                                            _Unidada, True)
        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left

        Select Case _Sub_Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fm.Btn_Informe_X_Bodega.Visible = False
            Case Enum_Informe.Super_Familia
                Fm.Btn_Informe_X_Super_Familia.Visible = False
            Case Enum_Informe.Entidades
                Fm.Btn_Informe_X_Entidades.Visible = False
            Case Enum_Informe.Ciudades
                Fm.Btn_Informe_X_Ciudades.Visible = False
            Case Enum_Informe.Comunas
                Fm.Btn_Informe_X_Comunas.Visible = False
            Case Enum_Informe.Productos_Consolidados
                Fm.Btn_Informe_X_Productos_Consolidados.Visible = False
            Case Enum_Informe.Funcionarios
                Fm.Btn_Informe_X_Funcionarios.Visible = False
        End Select

        Fm.Pro_Fl_Sucursales = Fl_Sucursales
        Fm.Pro_Fl_Bodegas = Fl_Bodegas
        Fm.Pro_Fl_Super_Familias = Fl_Super_Familias
        Fm.Pro_Fl_Entidades = Fl_Entidades
        Fm.Pro_Fl_Ciudades = Fl_Ciudades
        Fm.Pro_Fl_Comunas = Fl_Comunas
        Fm.Pro_Fl_Productos_Consolidados = Fl_Productos_Consolidados
        Fm.Pro_Fl_Funcionarios = Fl_Funcionarios

        If _Informe_Padre = Enum_Informe_Padre.Informe_Compromisos_No_Despachados Then
            Fm.Text = "COMP. NO DESPACHADOS, " & _Texto_Fm
        ElseIf _Informe_Padre = Enum_Informe_Padre.Informe_Proximas_Recpciones Then
            Fm.Text = "PROX. RECEPCIONES, " & _Texto_Fm
        End If

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Function Fx_Traer_Filtro(ByVal _Campo As String) As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Filtro As String

        Dim _Codigo = _Fila.Cells("CODIGO").Value

        If _Codigo = "ZZZ" Then
            _Filtro = Generar_Filtro_IN(_Tbl_Informe, "", "CODIGO", False, False, "'")
        Else
            _Filtro = "('" & _Codigo & "')"
        End If

        _Filtro = "And " & _Campo & "  IN " & _Filtro

        Return _Filtro

    End Function

    Function Fx_Traer_Filtro_Sucursales() As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu As String
        Dim _Filtro_Sucursales As String

        Try
            _Kosu = _Fila.Cells("KOSU").Value

            If _Kosu = "ZZZ" Then
                _Kosu = String.Empty 'Generar_Filtro_IN(_Tbl_Informe, "", "KOSU", False, False, "'")
                _Filtro_Sucursales = _Kosu
            Else
                _Kosu = "('" & _Kosu & "')"
                _Filtro_Sucursales = "And KOSU IN " & _Kosu
            End If

        Catch ex As Exception
            _Filtro_Sucursales = String.Empty
        End Try

        Return _Filtro_Sucursales

    End Function

    Function Fx_Traer_Filtro_Bodegas() As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu, _Kobo, _Fmpr, _Cod_Obsolencia, _Sucursal, _Texto_Fm As String
        Dim _Filtro_Bodegas As String

        Try
            _Kobo = _Fila.Cells("KOBO").Value
            Dim _Bodega = Trim(_Fila.Cells("BODEGA").Value)

            If _Kobo = "ZZZ" Then
                _Kobo = Generar_Filtro_IN(_Tbl_Informe, "", "KOBO", False, False, "'")
                _Texto_Fm += ",Bodega : Todas"
            Else
                _Kobo = "('" & _Kobo & "')"
                _Texto_Fm += ",Bodega : " & _Bodega
            End If

            _Filtro_Bodegas = "And BOSULIDO IN " & _Kobo

        Catch ex As Exception
            _Filtro_Bodegas = ""
        End Try

        Return _Filtro_Bodegas

    End Function

    Function Fx_Traer_Filtro_Super_Familias()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu, _Kobo, _Fmpr, _Cod_vnta_entre, _Sucursal, _Texto_Fm As String
        Dim _Filtro_Familias As String

        Try

            _Fmpr = Trim(_Fila.Cells("FMPR").Value)
            Dim _Super_Familia = Trim(_Fila.Cells("SUPER_FAMILIA").Value)

            If _Fmpr = "ZZZ" Then
                _Fmpr = Generar_Filtro_IN(_Tbl_Informe, "", "FMPR", False, False, "'")
                _Texto_Fm += ",Super Familia: Todas"
            Else
                _Fmpr = "('" & _Fmpr & "')"
                _Texto_Fm += ",Super Familia: " & _Super_Familia
            End If

            _Filtro_Familias = "And FMPR IN " & _Fmpr

        Catch ex As Exception
            _Filtro_Familias = String.Empty
        End Try

        Return _Filtro_Familias

    End Function

    Private Sub Sb_Frm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Informe_X_Bodega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Bodega.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Bodega)
    End Sub

    Private Sub Btn_Informe_X_Super_Familia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Super_Familia.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Super_Familia)
    End Sub

    Private Sub Btn_Informe_X_Entidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Entidades.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Entidades)
    End Sub

    Private Sub Btn_Informe_X_Ciudades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Ciudades.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Ciudades)
    End Sub

    Private Sub Btn_Informe_X_Comunas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Comunas.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Comunas)
    End Sub

    Private Sub Btn_Informe_X_Productos_Consolidados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Productos_Consolidados.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Productos_Consolidados)
    End Sub

    Private Sub Btn_Informe_X_Funcionarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Funcionarios.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Funcionarios)
    End Sub

    Private Sub Btn_Informe_X_Entidad_Documentos_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Entidad_Documentos_Productos.Click

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Campo As String = _Fila.Cells("CODIGO").Value

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Super_Familias = _Fl_Super_Familias
        Dim Fl_Entidades = _Fl_Entidades
        Dim Fl_Ciudades = _Fl_Ciudades
        Dim Fl_Comunas = _Fl_Comunas
        Dim Fl_Productos_Consolidados = _Fl_Productos_Consolidados
        Dim Fl_Funcionarios = _Fl_Funcionarios

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro("SULIDO") 'Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro("BOSULIDO") 'Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Super_Familias = Fx_Traer_Filtro("FMPR") 'Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Entidades
                Fl_Entidades = Fx_Traer_Filtro("ENDO+SUENDO")
            Case Enum_Informe.Ciudades
                Fl_Ciudades = Fx_Traer_Filtro("CIEN")
            Case Enum_Informe.Comunas
                Fl_Comunas = Fx_Traer_Filtro("CMEN")
            Case Enum_Informe.Productos_Consolidados
                Fl_Productos_Consolidados = Fx_Traer_Filtro("KOPRCT")
            Case Enum_Informe.Funcionarios
                Fl_Funcionarios = Fx_Traer_Filtro("KOFULIDO")
        End Select

        Dim _Filtro_Sql As String = Fl_Sucursales & vbCrLf &
                                    Fl_Bodegas & vbCrLf &
                                    Fl_Super_Familias & vbCrLf &
                                    Fl_Entidades & vbCrLf &
                                    Fl_Ciudades & vbCrLf &
                                    Fl_Comunas & vbCrLf &
                                    Fl_Productos_Consolidados & vbCrLf &
                                    Fl_Funcionarios

        Dim Fm As New Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Entidades_Documento_X_Productos(_Informe_Padre,
                                                                                _Tabla_Paso,
                                                                                _Filtro_Sql,
                                                                                _Unidada)
        Fm.Sb_Actualizar_Grillas()
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Informe_X_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Documentos.Click

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Campo As String = _Fila.Cells("CODIGO").Value

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Super_Familias = _Fl_Super_Familias
        Dim Fl_Entidades = _Fl_Entidades
        Dim Fl_Ciudades = _Fl_Ciudades
        Dim Fl_Comunas = _Fl_Comunas
        Dim Fl_Productos_Consolidados = _Fl_Productos_Consolidados
        Dim Fl_Funcionarios = _Fl_Funcionarios

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro("SULIDO") 'Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro("BOSULIDO") 'Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Super_Familias = Fx_Traer_Filtro("FMPR") 'Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Entidades
                Fl_Entidades = Fx_Traer_Filtro("ENDO+SUENDO")
            Case Enum_Informe.Ciudades
                Fl_Ciudades = Fx_Traer_Filtro("CIEN")
            Case Enum_Informe.Comunas
                Fl_Comunas = Fx_Traer_Filtro("CMEN")
            Case Enum_Informe.Productos_Consolidados
                Fl_Productos_Consolidados = Fx_Traer_Filtro("KOPRCT")
            Case Enum_Informe.Funcionarios
                Fl_Funcionarios = Fx_Traer_Filtro("KOFULIDO")
        End Select

        Dim _Filtro_Sql As String = Fl_Sucursales & vbCrLf &
                                    Fl_Bodegas & vbCrLf &
                                    Fl_Super_Familias & vbCrLf &
                                    Fl_Entidades & vbCrLf &
                                    Fl_Ciudades & vbCrLf &
                                    Fl_Comunas & vbCrLf &
                                    Fl_Productos_Consolidados & vbCrLf &
                                    Fl_Funcionarios

        Dim Fm As New Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Documento_X_Productos(_Informe_Padre,
                                                                                _Tabla_Paso,
                                                                                _Filtro_Sql,
                                                                                _Unidada)
        Fm.Sb_Actualizar_Grillas()
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Informe_X_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Productos.Click

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Campo As String = _Fila.Cells("CODIGO").Value

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Super_Familias = _Fl_Super_Familias
        Dim Fl_Entidades = _Fl_Entidades
        Dim Fl_Ciudades = _Fl_Ciudades
        Dim Fl_Comunas = _Fl_Comunas
        Dim Fl_Productos_Consolidados = _Fl_Productos_Consolidados
        Dim Fl_Funcionarios = _Fl_Funcionarios

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro("SULIDO") 'Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro("BOSULIDO") 'Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Super_Familias = Fx_Traer_Filtro("FMPR") 'Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Entidades
                Fl_Entidades = Fx_Traer_Filtro("ENDO+SUENDO")
            Case Enum_Informe.Ciudades
                Fl_Ciudades = Fx_Traer_Filtro("CIEN")
            Case Enum_Informe.Comunas
                Fl_Comunas = Fx_Traer_Filtro("CMEN")
            Case Enum_Informe.Productos_Consolidados
                Fl_Productos_Consolidados = Fx_Traer_Filtro("KOPRCT")
            Case Enum_Informe.Funcionarios
                Fl_Funcionarios = Fx_Traer_Filtro("KOFULIDO")
        End Select

        Dim _Filtro_Sql As String = Fl_Sucursales & vbCrLf &
                                    Fl_Bodegas & vbCrLf &
                                    Fl_Super_Familias & vbCrLf &
                                    Fl_Entidades & vbCrLf &
                                    Fl_Ciudades & vbCrLf &
                                    Fl_Comunas & vbCrLf &
                                    Fl_Productos_Consolidados & vbCrLf &
                                    Fl_Funcionarios

        Dim Fm As New Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Productos(_Informe_Padre,
                                                                                _Tabla_Paso,
                                                                                _Filtro_Sql,
                                                                                _Unidada)
        Fm.Sb_Actualizar_Grillas()
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Informe")
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        ShowContextMenu(Menu_Contextual_Informe)
    End Sub

End Class
