'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Filtro_Especial_Entidades

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Tbl_Filtro_Entidad As DataTable
    Dim _Tbl_Filtro_Ciudad As DataTable
    Dim _Tbl_Filtro_Comunas As DataTable
    Dim _Tbl_Filtro_Rubro_Entidad As DataTable
    Dim _Tbl_Filtro_Zonas_Entidad As DataTable

    Dim _Filtro_Extra_Entidad, _
        _Filtro_Extra_Ciudad, _
        _Filtro_Extra_Comunas, _
        _Filtro_Extra_Rubro_Entidad, _
        _Filtro_Extra_Zonas_Entidad As String

    Dim _Aceptar As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Property Pro_Tbl_Filtro_Entidades() As DataTable
        Get
            Return _Tbl_Filtro_Entidad
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Entidad = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Ciudad() As DataTable
        Get
            Return _Tbl_Filtro_Ciudad
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Ciudad = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Comuna() As DataTable
        Get
            Return _Tbl_Filtro_Comunas
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Comunas = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Rubro_Entidad() As DataTable
        Get
            Return _Tbl_Filtro_Rubro_Entidad
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Rubro_Entidad = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Zonas_Entidad() As DataTable
        Get
            Return _Tbl_Filtro_Zonas_Entidad
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Zonas_Entidad = value
        End Set
    End Property



    Public Property Pro_Filtro_Entidad_Todas() As Boolean
        Get
            Return Rdb_Entidades_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Entidades_Todas.Checked = True
            Else
                Rdb_Entidades_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Ciudades_Todas() As Boolean
        Get
            Return Rdb_Ciudad_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Ciudad_Todas.Checked = True
            Else
                Rdb_Ciudad_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Comunas_Todas() As Boolean
        Get
            Return Rdb_Comunas_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Comunas_Todas.Checked = True
            Else
                Rdb_Comunas_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Rubro_Entidad_Todas() As Boolean
        Get
            Return Rdb_Rubros_Todos.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Rubros_Todos.Checked = True
            Else
                Rdb_Rubros_Algunos.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Zonas_Entidad_Todas() As Boolean
        Get
            Return Rdb_Zonas_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Zonas_Todas.Checked = True
            Else
                Rdb_Zonas_Algunas.Checked = True
            End If
        End Set
    End Property



    Public Property Pro_Filtro_Extra_Entidad()
        Get
            Return _Filtro_Extra_Entidad
        End Get
        Set(ByVal value)
            _Filtro_Extra_Entidad = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Ciudad()
        Get
            Return _Filtro_Extra_Ciudad
        End Get
        Set(ByVal value)
            _Filtro_Extra_Ciudad = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Comunas()
        Get
            Return _Filtro_Extra_Comunas
        End Get
        Set(ByVal value)
            _Filtro_Extra_Comunas = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Rubro_Entidad()
        Get
            Return _Filtro_Extra_Rubro_Entidad
        End Get
        Set(ByVal value)
            _Filtro_Extra_Rubro_Entidad = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Zonas_entidad()
        Get
            Return _Filtro_Extra_Zonas_Entidad
        End Get
        Set(ByVal value)
            _Filtro_Extra_Zonas_Entidad = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Filtro_Especial_Entidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Rdb_Entidades_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Ciudad_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Comunas_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Rubros_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Zonas_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged

    End Sub

    Private Sub Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Control As DevComponents.DotNetBar.Controls.CheckBoxX = sender
        Dim _Control_Todas As DevComponents.DotNetBar.Controls.CheckBoxX

        Dim _Tabla_Fl As Enum_Tabla_Fl
        Dim _Nombre_Control = CType(sender, Control).Name
        Dim _Tbl_Filtro As Object
        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Select Case _Nombre_Control

            Case "Rdb_Entidades_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Entidad
                _Tabla_Fl = Enum_Tabla_Fl._Entidades
                _Control_Todas = Rdb_Entidades_Todas
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Entidad
            Case "Rdb_Ciudad_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Ciudad
                _Tabla_Fl = Enum_Tabla_Fl._Ciudades
                _Control_Todas = Rdb_Ciudad_Todas
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Ciudad
            Case "Rdb_Comunas_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Comunas
                _Tabla_Fl = Enum_Tabla_Fl._Comunas
                _Control_Todas = Rdb_Comunas_Todas

                Dim _Fl_Extra = String.Empty

                If Rdb_Ciudad_Algunas.Checked Then
                    _Fl_Extra = Generar_Filtro_IN(_Tbl_Filtro_Ciudad, "Chk", "Codigo", False, True, "'")
                    _Fl_Extra = "And KOPA+KOCI In " & _Fl_Extra
                End If

                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Comunas & vbCrLf & _Fl_Extra
            Case "Rdb_Rubros_Algunos"
                _Tbl_Filtro = _Tbl_Filtro_Rubro_Entidad
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Rubros
                _Control_Todas = Rdb_Rubros_Todos
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Rubro_Entidad
            Case "Rdb_Zonas_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Zonas_Entidad
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Zonas
                _Control_Todas = Rdb_Zonas_Todas
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Zonas_Entidad
        End Select


        If _Control.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(_Tabla_Fl, False)
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

                            Case "Rdb_Entidades_Algunas"
                                _Tbl_Filtro_Entidad = _Tbl_Filtro
                            Case "Rdb_Ciudad_Algunas"
                                _Tbl_Filtro_Ciudad = _Tbl_Filtro
                            Case "Rdb_Comunas_Algunas"
                                _Tbl_Filtro_Comunas = _Tbl_Filtro
                            Case "Rdb_Rubros_Algunos"
                                _Tbl_Filtro_Rubro_Entidad = _Tbl_Filtro
                            Case "Rdb_Zonas_Algunas"
                                _Tbl_Filtro_Zonas_Entidad = _Tbl_Filtro
                        End Select
                    End If
                End If

            End If

            If (_Tbl_Filtro Is Nothing) Then
                _Control_Todas.Checked = True
            End If

        End If

    End Sub

    Private Sub Frm_Filtro_Especial_Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        _Aceptar = True
        Me.Close()
    End Sub


End Class