'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Filtro_Especial_Funcionarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Tbl_Filtro_Responzables As DataTable
    Dim _Tbl_Filtro_Vendedores As DataTable
    
    Dim _Filtro_Extra_Responzables, _
        _Filtro_Extra_Vendedores As String

    Dim _Aceptar As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property


    Public Property Pro_Tbl_Filtro_Responzables() As DataTable
        Get
            Return _Tbl_Filtro_Responzables
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Responzables = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Vendedores() As DataTable
        Get
            Return _Tbl_Filtro_Vendedores
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Vendedores = value
        End Set
    End Property


    Public Property Pro_Filtro_Responzables_Todos() As Boolean
        Get
            Return Rdb_Responzables_Todos.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Responzables_Todos.Checked = True
            Else
                Rdb_Responzables_Algunos.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Vendedores_Todos() As Boolean
        Get
            Return Rdb_Vendedores_Todos.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Vendedores_Todos.Checked = True
            Else
                Rdb_Vendedores_Algunos.Checked = True
            End If
        End Set
    End Property


    Public Property Pro_Filtro_Extra_Responzables()
        Get
            Return _Filtro_Extra_Responzables
        End Get
        Set(ByVal value)
            _Filtro_Extra_Responzables = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Vendedores()
        Get
            Return _Filtro_Extra_Vendedores
        End Get
        Set(ByVal value)
            _Filtro_Extra_Vendedores = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Filtro_Especial_Funcionarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Rdb_Responzables_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Vendedores_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
    End Sub

    Private Sub Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Control As DevComponents.DotNetBar.Controls.CheckBoxX = sender
        Dim _Control_Todas As DevComponents.DotNetBar.Controls.CheckBoxX

        Dim _Tabla_Fl As Enum_Tabla_Fl
        Dim _Nombre_Control = CType(sender, Control).Name
        Dim _Tbl_Filtro As Object
        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Select Case _Nombre_Control

            Case "Rdb_Responzables_Algunos"
                _Tbl_Filtro = _Tbl_Filtro_Responzables
                _Tabla_Fl = Enum_Tabla_Fl._Funcionarios_Random
                _Control_Todas = Rdb_Responzables_Todos
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Responzables
            Case "Rdb_Vendedores_Algunos"
                _Tbl_Filtro = _Tbl_Filtro_Vendedores
                _Tabla_Fl = Enum_Tabla_Fl._Funcionarios_Random
                _Control_Todas = Rdb_Vendedores_Todos
                _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Vendedores
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

                            Case "Rdb_Responzables_Algunos"
                                _Tbl_Filtro_Responzables = _Tbl_Filtro
                            Case "Rdb_Vendedores_Algunos"
                                _Tbl_Filtro_Vendedores = _Tbl_Filtro
                        End Select
                    End If
                End If

            End If

        End If

        If (_Tbl_Filtro Is Nothing) Then
            _Control_Todas.Checked = True
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