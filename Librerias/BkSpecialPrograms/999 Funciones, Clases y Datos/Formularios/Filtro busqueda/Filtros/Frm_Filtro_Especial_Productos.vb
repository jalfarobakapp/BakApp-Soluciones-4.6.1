Imports DevComponents.DotNetBar

Public Class Frm_Filtro_Especial_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas As DataTable

    Dim _Filtro_Extra_Productos,
        _Filtro_Extra_Super_Familias,
        _Filtro_Extra_Marcas,
        _Filtro_Extra_Rubro,
        _Filtro_Extra_Clalibpr,
        _Filtro_Extra_Zonas As String

    Dim _Aceptar As Boolean

    Public Property BuscarSpfmfmsubfm As Boolean = False
    Public Property Ls_SelSuperFamilias As New List(Of SelSuperFamilias)
    Public Property Ls_SelFamilias As New List(Of SelFamilias)
    Public Property Ls_SelSubFamilias As New List(Of SelSubFamilias)

    Public ReadOnly Property Pro_Aceptar() As Boolean

    Public Property Pro_Tbl_Filtro_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Productos = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Super_Familias() As DataTable
        Get
            Return _Tbl_Filtro_Super_Familias
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Super_Familias = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Marcas() As DataTable
        Get
            Return _Tbl_Filtro_Marcas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Marcas = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Rubro() As DataTable
        Get
            Return _Tbl_Filtro_Rubro
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Rubro = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Clalibpr() As DataTable
        Get
            Return _Tbl_Filtro_Clalibpr
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Clalibpr = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Zonas() As DataTable
        Get
            Return _Tbl_Filtro_Zonas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Zonas = value
        End Set
    End Property

    Public Property Pro_Filtro_Marcas_Todas() As Boolean
        Get
            Return Rdb_Marcas_Todas.Checked
        End Get
        Set(value As Boolean)
            If value Then
                Rdb_Marcas_Todas.Checked = True
            Else
                Rdb_Marcas_Algunas.Checked = True
            End If
        End Set
    End Property
    Public Property Pro_Filtro_Productos_Todos() As Boolean
        Get
            Return Rdb_Productos_Todos.Checked
        End Get
        Set(value As Boolean)
            If value Then
                Rdb_Productos_Todos.Checked = True
            Else
                Rdb_Productos_Algunos.Checked = True
            End If
        End Set
    End Property
    Public Property Pro_Filtro_Super_Familias_Todas() As Boolean
        Get
            Return Rdb_Super_Familias_Todas.Checked
        End Get
        Set(value As Boolean)
            If value Then
                Rdb_Super_Familias_Todas.Checked = True
            Else
                Rdb_Super_Familias_Algunas.Checked = True
            End If
        End Set
    End Property
    Public Property Pro_Filtro_Rubro_Todas() As Boolean
        Get
            Return Rdb_Rubros_Todos.Checked
        End Get
        Set(value As Boolean)
            If value Then
                Rdb_Rubros_Todos.Checked = True
            Else
                Rdb_Rubros_Algunos.Checked = True
            End If
        End Set
    End Property
    Public Property Pro_Filtro_Clalibpr_Todas() As Boolean
        Get
            Return Rdb_Clasificacion_Masisa_Todas.Checked
        End Get
        Set(value As Boolean)
            If value Then
                Rdb_Clasificacion_Masisa_Todas.Checked = True
            Else
                Rdb_Clasificacion_Libre_Algunas.Checked = True
            End If
        End Set
    End Property
    Public Property Pro_Filtro_Zonas_Todas() As Boolean
        Get
            Return Rdb_Zonas_Todas.Checked
        End Get
        Set(value As Boolean)
            If value Then
                Rdb_Zonas_Todas.Checked = True
            Else
                Rdb_Zonas_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Productos()
        Get
            Return _Filtro_Extra_Productos
        End Get
        Set(value)
            _Filtro_Extra_Productos = value
        End Set
    End Property
    Public Property Pro_Filtro_Extra_Super_Familias()
        Get
            Return _Filtro_Extra_Super_Familias
        End Get
        Set(value)
            _Filtro_Extra_Super_Familias = value
        End Set
    End Property
    Public Property Pro_Filtro_Extra_Marcas()
        Get
            Return _Filtro_Extra_Marcas
        End Get
        Set(value)
            _Filtro_Extra_Marcas = value
        End Set
    End Property
    Public Property Pro_Filtro_Extra_Rubro_Productos()
        Get
            Return _Filtro_Extra_Rubro
        End Get
        Set(value)
            _Filtro_Extra_Rubro = value
        End Set
    End Property
    Public Property Pro_Filtro_Extra_Clalibpr()
        Get
            Return _Filtro_Extra_Clalibpr
        End Get
        Set(value)
            _Filtro_Extra_Clalibpr = value
        End Set
    End Property
    Public Property Pro_Filtro_Extra_Zonas()
        Get
            Return _Filtro_Extra_Zonas
        End Get
        Set(value)
            _Filtro_Extra_Zonas = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Rdb_Super_Familias_Algunas_DoubleClick(sender As Object, e As EventArgs) Handles Rdb_Super_Familias_Algunas.DoubleClick
        Call Rdb_CheckedChanged(sender, Nothing)
    End Sub

    Private Sub Frm_Filtro_Especial_Productos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Rdb_Productos_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Clasificacion_Libre_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Marcas_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Rubros_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Super_Familias_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Zonas_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged

        Panel_Otros_Filtros.Enabled = Rdb_Productos_Todos.Checked

    End Sub

    Private Sub Rdb_CheckedChanged(sender As System.Object, e As System.EventArgs)

        Dim _Control As DevComponents.DotNetBar.Controls.CheckBoxX = sender
        Dim _Control_Todas As DevComponents.DotNetBar.Controls.CheckBoxX

        Dim _Tabla_Fl As Enum_Tabla_Fl
        Dim _Nombre_Control = CType(sender, Control).Name
        Dim _Tbl_Filtro As Object
        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Panel_Otros_Filtros.Enabled = Rdb_Productos_Todos.Checked

        Select Case _Nombre_Control

            Case "Rdb_Productos_Algunos"

                _Tbl_Filtro = _Tbl_Filtro_Productos
                _Tabla_Fl = Enum_Tabla_Fl._Productos
                _Control_Todas = Rdb_Productos_Todos
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Productos

            Case "Rdb_Clasificacion_Libre_Algunas"

                _Tbl_Filtro = _Tbl_Filtro_Clalibpr
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Tabcarac
                _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'CLALIBPR'"
                _Control_Todas = Rdb_Clasificacion_Masisa_Todas
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Clalibpr

            Case "Rdb_Marcas_Algunas"

                _Tbl_Filtro = _Tbl_Filtro_Marcas
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Marcas
                _Control_Todas = Rdb_Marcas_Todas
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Marcas

            Case "Rdb_Super_Familias_Algunas"

                _Tbl_Filtro = _Tbl_Filtro_Super_Familias
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Super_Familia
                _Control_Todas = Rdb_Super_Familias_Todas
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Super_Familias

            Case "Rdb_Rubros_Algunos"

                _Tbl_Filtro = _Tbl_Filtro_Rubro
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Rubros
                _Control_Todas = Rdb_Rubros_Todos
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Rubro

            Case "Rdb_Zonas_Algunas"

                _Tbl_Filtro = _Tbl_Filtro_Zonas
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Zonas
                _Control_Todas = Rdb_Zonas_Todas
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Zonas

        End Select

        If _Control.Checked Then

            If BuscarSpfmfmsubfm AndAlso _Nombre_Control = "Rdb_Super_Familias_Algunas" Then

                Dim Fm_fm As New Frm_Familias_Lista(Frm_Familias_Lista.Enum_Tipo_Vista_Familias.Super_Familias)
                Fm_fm.Ls_SelSuperFamilias = Ls_SelSuperFamilias
                Fm_fm.Ls_SelFamilias = Ls_SelFamilias
                Fm_fm.Ls_SelSubFamilias = Ls_SelSubFamilias
                Fm_fm.ModoSeleccion = True
                Fm_fm.ShowDialog(Me)

                Ls_SelSuperFamilias = Fm_fm.Ls_SelSuperFamilias
                Ls_SelFamilias = Fm_fm.Ls_SelFamilias
                Ls_SelSubFamilias = Fm_fm.Ls_SelSubFamilias
                Fm_fm.Dispose()

                If Ls_SelSuperFamilias.Count = 0 Then
                    _Control_Todas.Checked = True
                End If

                Return

            End If

            Dim Fm As New Frm_Filtro_Especial_Informes(_Tabla_Fl, True)
            Fm.Pro_Tbl_Filtro = _Tbl_Filtro
            Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then

                _Tbl_Filtro = Fm.Pro_Tbl_Filtro

                If Fm.Pro_Filtrar_Todo Then
                    _Control_Todas.Checked = True
                Else
                    If (_Tbl_Filtro Is Nothing) Then
                        _Control.Checked = True
                    Else
                        Select Case _Nombre_Control
                            Case "Rdb_Productos_Algunos"
                                _Tbl_Filtro_Productos = _Tbl_Filtro
                            Case "Rdb_Clasificacion_Libre_Algunas"
                                _Tbl_Filtro_Clalibpr = _Tbl_Filtro
                            Case "Rdb_Marcas_Algunas"
                                _Tbl_Filtro_Marcas = _Tbl_Filtro
                            Case "Rdb_Super_Familias_Algunas"
                                _Tbl_Filtro_Super_Familias = _Tbl_Filtro
                            Case "Rdb_Rubros_Algunos"
                                _Tbl_Filtro_Rubro = _Tbl_Filtro
                            Case "Rdb_Zonas_Algunas"
                                _Tbl_Filtro_Zonas = _Tbl_Filtro
                        End Select
                    End If
                End If

            End If

        End If

        If _Nombre_Control <> "Rdb_Productos_Algunos" Then
            If (_Tbl_Filtro Is Nothing) Then
                _Control_Todas.Checked = True
            End If
        End If

    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Frm_Filtro_Especial_Productos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim _Faltan_Productos As Boolean

        If Rdb_Productos_Algunos.Checked Then

            If IsNothing(_Tbl_Filtro_Productos) Then
                _Faltan_Productos = True
            Else
                _Faltan_Productos = Not Convert.ToBoolean(_Tbl_Filtro_Productos.Rows.Count)
            End If

            If _Faltan_Productos Then

                MessageBoxEx.Show(Me, "Debe seleccionar algún producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Rdb_CheckedChanged(Rdb_Productos_Algunos, Nothing)
                Return

            End If

        End If

        If Not Rdb_Productos_Algunos.Checked Then
            Pro_Tbl_Filtro_Productos = Nothing
        End If

        _Aceptar = True
        Me.Close()

    End Sub

End Class
