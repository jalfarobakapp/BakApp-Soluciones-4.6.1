Imports System.IO

Public Class Frm_Barras_ConfPuerto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Path As String '= AppPath() & "\Data\" & RutEmpresa & "\Barras\Configuracion_local.xml"
    Public Ds_ConfBarras As DataSet = New Ds_Barras

    Dim _TieneConfiguracion As Boolean
    Dim _Grabar As Boolean
    Dim _Nombre_Archivo_Xml As String

    Public Property TieneConfiguracion As Boolean
        Get
            Return _TieneConfiguracion
        End Get
        Set(value As Boolean)
            _TieneConfiguracion = value
        End Set
    End Property

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Puerto As String
    Public Property Etiqueta As String

    Public Sub New(_Nombre_Archivo_Xml As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        '_Nombre_Archivo_Xml = "Configuracion_local.xml"
        Me._Nombre_Archivo_Xml = _Nombre_Archivo_Xml
        '_Path = AppPath() & "\Data\" & RutEmpresa & "\Barras\Configuracion_local.xml"

        _Path = AppPath() & "\Data\" & RutEmpresa & "\Barras\" & _Nombre_Archivo_Xml

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Barras") Then
            Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\Barras")
        End If

        Ds_ConfBarras.Clear()
        Dim exists = File.Exists(_Path)

        If Not exists Then

            Dim NewFila As DataRow
            NewFila = Ds_ConfBarras.Tables("Tbl_Configuracion").NewRow

            With NewFila
                .Item("Puerto") = String.Empty
                .Item("Etiqueta") = String.Empty
            End With

            Ds_ConfBarras.Tables("Tbl_Configuracion").Rows.Add(NewFila)
            Ds_ConfBarras.WriteXml(_Path)

        Else
            _TieneConfiguracion = True
            Ds_ConfBarras.ReadXml(_Path)
        End If

    End Sub

    Private Sub Frm_Barras_ConfPuerto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Ds_ConfBarras.Clear()
        Dim exists = File.Exists(_Path)

        If Not exists Then

            Dim NewFila As DataRow
            NewFila = Ds_ConfBarras.Tables("Tbl_Configuracion").NewRow

            With NewFila
                .Item("Puerto") = String.Empty
                .Item("Etiqueta") = String.Empty
            End With

            Ds_ConfBarras.Tables("Tbl_Configuracion").Rows.Add(NewFila)
            Ds_ConfBarras.WriteXml(_Path)

        Else
            _TieneConfiguracion = True
            Ds_ConfBarras.ReadXml(_Path)
        End If

        Sb_Llenar_Puertos()
        AddHandler BtnGrabar.Click, AddressOf Sb_Grabar
    End Sub

#Region "PROCEDIMIENTOS"

#Region "LLENAR COMBOS"

    Sub Sb_Llenar_Puertos()

        caract_combo(CmbPuerto)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "LPT1" : dr("Hijo") = "Puerto LPT1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT2" : dr("Hijo") = "Puerto LPT2" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT3" : dr("Hijo") = "Puerto LPT3" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT4" : dr("Hijo") = "Puerto LPT4" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With CmbPuerto
            .DataSource = Nothing
            .DataSource = dt
        End With

        Consulta_sql = "select NombreEtiqueta As Padre,NombreEtiqueta As Hijo from " & _Global_BaseBk & "Zw_Tbl_DisenoBarras"
        Dim _TblEtiquetas As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(CmbEtiqueta)
        With CmbEtiqueta
            .DataSource = Nothing
            .DataSource = _TblEtiquetas
        End With


        Puerto = Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        Etiqueta = Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        CmbPuerto.SelectedValue = _Puerto
        CmbEtiqueta.SelectedValue = _Etiqueta

    End Sub

#End Region

#Region "GRABAR"

    Sub Sb_Grabar()

        Ds_ConfBarras.Clear()
        With Ds_ConfBarras

            Dim NewFila As DataRow
            NewFila = .Tables("Tbl_Configuracion").NewRow

            With NewFila

                .Item("Puerto") = CmbPuerto.SelectedValue
                .Item("Etiqueta") = NuloPorNro(CmbEtiqueta.SelectedValue, "")

                Puerto = .Item("Puerto")
                Etiqueta = .Item("Etiqueta")

            End With
            .Tables("Tbl_Configuracion").Rows.Add(NewFila)

            .WriteXml(_Path)
            _Grabar = True
        End With



        Me.Close()

    End Sub

#End Region

#End Region

    Private Sub Frm_Barras_ConfPuerto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
