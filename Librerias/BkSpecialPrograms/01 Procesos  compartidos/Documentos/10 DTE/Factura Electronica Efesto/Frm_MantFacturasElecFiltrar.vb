Imports DevComponents.DotNetBar

Public Class Frm_MantFacturasElecFiltrar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fecha_Desde As DateTime
    Dim _Fecha_Hasta As DateTime
    Dim _Tbl_Documentos As DataTable
    Dim _Tbl_Sucursales As DataTable
    Dim _Tbl_Responsables As DataTable
    Dim _Tbl_Entidades As DataTable

    Dim _Documentos_Todos As Boolean
    Dim _Sucursales_Todas As Boolean
    Dim _Responsables_Todos As Boolean
    Dim _Entidades_Todas As Boolean

    Dim _Aceptar As Boolean
    Dim _AmbienteCertificacion As Integer

#Region "PROPIEDADES"

    Public Property Fecha_Desde As Date
        Get
            Return _Fecha_Desde
        End Get
        Set(value As Date)
            _Fecha_Desde = value
        End Set
    End Property

    Public Property Fecha_Hasta As Date
        Get
            Return _Fecha_Hasta
        End Get
        Set(value As Date)
            _Fecha_Hasta = value
        End Set
    End Property

    Public Property Tbl_Documentos As DataTable
        Get
            Return _Tbl_Documentos
        End Get
        Set(value As DataTable)
            _Tbl_Documentos = value
        End Set
    End Property

    Public Property Tbl_Sucursales As DataTable
        Get
            Return _Tbl_Sucursales
        End Get
        Set(value As DataTable)
            _Tbl_Sucursales = value
        End Set
    End Property

    Public Property Tbl_Responsables As DataTable
        Get
            Return _Tbl_Responsables
        End Get
        Set(value As DataTable)
            _Tbl_Responsables = value
        End Set
    End Property

    Public Property Tbl_Entidades As DataTable
        Get
            Return _Tbl_Entidades
        End Get
        Set(value As DataTable)
            _Tbl_Entidades = value
        End Set
    End Property

    Public Property Documentos_Todos As Boolean
        Get
            Return _Documentos_Todos
        End Get
        Set(value As Boolean)
            _Documentos_Todos = value
        End Set
    End Property

    Public Property Sucursales_Todas As Boolean
        Get
            Return _Sucursales_Todas
        End Get
        Set(value As Boolean)
            _Sucursales_Todas = value
        End Set
    End Property

    Public Property Responsables_Todos As Boolean
        Get
            Return _Responsables_Todos
        End Get
        Set(value As Boolean)
            _Responsables_Todos = value
        End Set
    End Property

    Public Property Entidades_Todas As Boolean
        Get
            Return _Entidades_Todas
        End Get
        Set(value As Boolean)
            _Entidades_Todas = value
        End Set
    End Property

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Property Class_MantFacturasElect As Class_MantFacturasElect
        Get
            Return _Cl_MFElec
        End Get
        Set(value As Class_MantFacturasElect)
            _Cl_MFElec = value
        End Set
    End Property

#End Region

    Dim _Cl_MFElec As New Class_MantFacturasElect

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_MantFacturasElecFiltrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_Fecha_Emision_Desde.Value = _Cl_MFElec.Fecha_Desde
        Dtp_Fecha_Emision_Hasta.Value = _Cl_MFElec.Fecha_Hasta

        Rdb_Documentos_Todos.Checked = _Cl_MFElec.Documentos_Todos
        Rdb_Sucursales_Todas.Checked = _Cl_MFElec.Sucursales_Todas
        Rdb_Responsables_Todos.Checked = _Cl_MFElec.Responsables_Todos
        Rdb_Entidades_Todas.Checked = _Cl_MFElec.Entidades_Todas

        AddHandler Rdb_Documentos_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Responsables_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Sucursales_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Entidades_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged

        Sb_Habilitar_Grupos(Rdb_Buscar_Todos.Checked)

        AddHandler Rdb_Buscar_Todos.CheckedChanged, AddressOf Rdb_Buscar_Todos_CheckedChanged
        AddHandler Rdb_Buscar_Uno.CheckedChanged, AddressOf Rdb_Buscar_Todos_CheckedChanged

        'If _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion") Then
        '    Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
        '    MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
        '    Lbl_Etiqueta.Text = "Ambiente de Certificación y Prueba"
        'End If

    End Sub


    Private Sub Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Control As DevComponents.DotNetBar.Controls.CheckBoxX = sender
        Dim _Control_Todas As DevComponents.DotNetBar.Controls.CheckBoxX

        Dim _Tabla_Fl As Enum_Tabla_Fl
        Dim _Nombre_Control = CType(sender, Control).Name
        Dim _Tbl_Filtro As Object
        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Select Case _Nombre_Control

            Case "Rdb_Documentos_Algunos"
                _Tbl_Filtro = _Cl_MFElec.Tbl_Documentos
                _Tabla_Fl = Enum_Tabla_Fl._Documentos
                _Control_Todas = Rdb_Documentos_Todos
                _Sql_Filtro_Condicion_Extra = "And TIDO In ('BLV','FCL','FCT','FCV','FDE','FDV','FDX','FEV','FVX','FXV','FYV','GDD','GDP','GDV','GTI','NCV','NCX','NEV')"
            Case "Rdb_Sucursales_Algunas"
                _Tbl_Filtro = _Cl_MFElec.Tbl_Sucursales
                _Tabla_Fl = Enum_Tabla_Fl._Sucursales
                _Control_Todas = Rdb_Sucursales_Todas
            Case "Rdb_Responsables_Algunos" 'Rdb_Responsables_Algunos
                _Tbl_Filtro = _Cl_MFElec.Tbl_Responsables
                _Tabla_Fl = Enum_Tabla_Fl._Funcionarios_Random
                _Control_Todas = Rdb_Responsables_Todos
            Case "Rdb_Entidades_Algunas"
                _Tbl_Filtro = _Cl_MFElec.Tbl_Entidades
                _Tabla_Fl = Enum_Tabla_Fl._Entidades
                _Control_Todas = Rdb_Entidades_Todas
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

                            Case "Rdb_Documentos_Algunos"
                                _Cl_MFElec.Tbl_Documentos = _Tbl_Filtro
                            Case "Rdb_Sucursales_Algunas"
                                _Cl_MFElec.Tbl_Sucursales = _Tbl_Filtro
                            Case "Rdb_Responsables_Algunos"
                                _Cl_MFElec.Tbl_Responsables = _Tbl_Filtro
                            Case "Rdb_Entidades_Algunas"
                                _Cl_MFElec.Tbl_Entidades = _Tbl_Filtro

                        End Select

                    End If

                End If

            Else
                If IsNothing(_Tbl_Filtro) Then
                    _Control_Todas.Checked = True
                End If
            End If

        End If

    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        _Cl_MFElec.Documentos_Todos = Rdb_Documentos_Todos.Checked
        _Cl_MFElec.Sucursales_Todas = Rdb_Sucursales_Todas.Checked
        _Cl_MFElec.Responsables_Todos = Rdb_Responsables_Todos.Checked
        _Cl_MFElec.Entidades_Todas = Rdb_Entidades_Todas.Checked
        _Cl_MFElec.Fecha_Desde = Dtp_Fecha_Emision_Desde.Value
        _Cl_MFElec.Fecha_Hasta = Dtp_Fecha_Emision_Hasta.Value

        If Rdb_Buscar_Uno.Checked Then
            _Cl_MFElec.Idmaeedo = Txt_Documento.Tag
            If Not CBool(_Cl_MFElec.Idmaeedo) Then
                MessageBoxEx.Show(Me, "Falta el documento a buscar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        Else
            _Cl_MFElec.Idmaeedo = 0
            Txt_Documento.Tag = 0
            Txt_Documento.Text = String.Empty
        End If

        If Rdb_EstadoTodos.Checked Then
            _Cl_MFElec.Estado_Aceptado = False
            _Cl_MFElec.Estado_AceptadoReparos = False
            _Cl_MFElec.Estado_Rechazado = False
            _Cl_MFElec.Estado_SinFirmar = False
        End If

        If Rdb_EstadoExcepciones.Checked Then
            _Cl_MFElec.Estado_Aceptado = Rdb_EstadoAceptados.Checked
            _Cl_MFElec.Estado_AceptadoReparos = Rdb_EstadoAceptadosReparos.Checked
            _Cl_MFElec.Estado_Rechazado = Rdb_EstadoRechazados.Checked
            _Cl_MFElec.Estado_SinFirmar = Rdb_EstadoSinFirmar.Checked
        End If

        _Aceptar = True

        Me.Enabled = False

        Dim Fm2 As New Frm_MantFacturasElectronicas
        Fm2.Cl_MFElec = _Cl_MFElec
        Fm2.Ds = Fm2.Fx_Generar_Informe
        Dim _SinRegistros As Boolean

        If IsNothing(Fm2.Ds) Then _SinRegistros = True

        If Not _SinRegistros Then
            If Fm2.Ds.Tables(0).Rows.Count Then
                Fm2.ShowDialog(Me)
            Else
                _SinRegistros = True
            End If
        End If

        If _SinRegistros Then
            MessageBoxEx.Show(Me, "No hay registros que mostrar", "Buscar documentos DTE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm2.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub Frm_MantFacturasElecFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Habilitar_Grupos(_Habilitar_Todo As Boolean)

        Grupo_Estado.Enabled = _Habilitar_Todo
        Grupo_Fechas.Enabled = _Habilitar_Todo
        Grupo_Filtros.Enabled = _Habilitar_Todo
        Grupo_Uno.Enabled = Not _Habilitar_Todo

    End Sub

    Private Sub Rdb_Buscar_Todos_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Habilitar_Grupos(Rdb_Buscar_Todos.Checked)
    End Sub

    Private Sub Rdb_EstadoExcepciones_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_EstadoExcepciones.CheckedChanged
        Grupo_Excepciones.Enabled = Rdb_EstadoExcepciones.Checked
    End Sub

    Private Sub Txt_Documento_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Documento.ButtonCustomClick

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "NVV",
                                 "Where TIDO In ('BLV','FCL','FCT','FCV','FDE','FDV','FDX','FEV','FVX','FXV','FYV','GDD','GDP','GDV','GTI','NCV','NCX','NEV')")
        _Fm.Rdb_Estado_Todos.Enabled = False
        _Fm.Rdb_Estado_Vigente.Checked = True
        _Fm.ShowDialog(Me)
        Dim _Row_Documento As DataRow = _Fm.Pro_Row_Documento_Seleccionado
        _Fm.Dispose()

        If Not IsNothing(_Row_Documento) Then
            Txt_Documento.Text = _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
            Txt_Documento.Tag = _Row_Documento.Item("IDMAEEDO")
        End If

    End Sub

End Class
