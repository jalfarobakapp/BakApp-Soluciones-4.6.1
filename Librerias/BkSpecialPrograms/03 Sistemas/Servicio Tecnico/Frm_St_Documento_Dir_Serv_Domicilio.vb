Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_St_Documento_Dir_Serv_Domicilio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsDocumento As DataSet
    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Tbl_Accesorios As DataTable
    Dim _Row_Notas As DataRow

    Dim _Grabar As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_St_Documento_Dir_Serv_Domicilio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Cmb_Pais.SelectedIndexChanged, AddressOf Sb_Cmb_Pais_SelectedIndexChanged
        AddHandler Cmb_Ciudad.SelectedIndexChanged, AddressOf Sb_Cmb_Ciudad_SelectedIndexChanged
        
        Dim _Pais = _Row_Encabezado.Item("Pais")
        Dim _Ciudad = _Row_Encabezado.Item("Ciudad")
        Dim _Comuna = _Row_Encabezado.Item("Comuna")

        Sb_Cargar_Pais(_Pais)
        Sb_Cargar_Ciudades(_Pais, _Ciudad)
        Sb_Cargar_Comunas(_Pais, _Ciudad, _Comuna)

        Txt_Direccion.Text = _Row_Encabezado.Item("Direccion")

    End Sub


#Region "PROCEDIMIENTOS PAIS, CIUDAD Y COMUNA"

    Private Sub Sb_Cmb_Pais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Pais = Cmb_Pais.SelectedValue

        Cmb_Ciudad.DataSource = Nothing
        Cmb_Comuna.DataSource = Nothing

        Sb_Cargar_Ciudades(_Pais, "")


    End Sub

    Private Sub Sb_Cmb_Ciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Pais = Cmb_Pais.SelectedValue
        Dim _Ciudad = Cmb_Ciudad.SelectedValue

        Cmb_Comuna.DataSource = Nothing

        Sb_Cargar_Comunas(_Pais, _Ciudad, "")

    End Sub

    Sub Sb_Cargar_Pais(ByVal _Pais As String)

        caract_combo(Cmb_Pais)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOPA AS Padre,NOKOPA AS Hijo FROM TABPA ORDER BY Padre" ' WHERE SEMILLA = " & Actividad
        Cmb_Pais.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Pais.SelectedValue = _Pais
        
    End Sub

    Sub Sb_Cargar_Ciudades(ByVal _Pais As String, ByVal _Ciudad As String)

        caract_combo(Cmb_Ciudad)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOCI AS Padre,' '+RTRIM(LTRIM(KOCI))+' -'+NOKOCI AS Hijo FROM TABCI WHERE KOPA = '" & _Pais & "'"
        Cmb_Ciudad.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Ciudad.SelectedValue = _Ciudad

    End Sub

    Sub Sb_Cargar_Comunas(ByVal _Pais As String, ByVal _Ciudad As String, ByVal _Comuna As String)

        caract_combo(Cmb_Comuna)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOCM AS Padre, NOKOCM AS Hijo FROM TABCM WHERE KOPA = '" & _Pais & "' AND KOCI = '" & _Ciudad & "'"
        Cmb_Comuna.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Comuna.SelectedValue = _Comuna

    End Sub

#End Region

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(ByVal value As DataSet)
            _DsDocumento = value

            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Tbl_ChekIn = _DsDocumento.Tables(2)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_Accesorios = _DsDocumento.Tables(5)

        End Set
    End Property

    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
        Set(ByVal value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Editar() As Boolean
        Get
            'Return _Grabar
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Txt_Direccion.BackColor = Color.White
                Txt_Direccion.ReadOnly = False
            Else
                Txt_Direccion.BackColor = Color.LightGray
                Txt_Direccion.ReadOnly = True
            End If
            Cmb_Pais.Enabled = value
            Cmb_Ciudad.Enabled = value
            Cmb_Comuna.Enabled = value
            Txt_Direccion.FocusHighlightEnabled = value
            Btn_Trasladar_Datos.Visible = value
        End Set
    End Property

    
#End Region

    Private Sub Btn_Fijar_Estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Trasladar_Datos.Click

        _Row_Encabezado.Item("Pais") = Cmb_Pais.SelectedValue
        _Row_Encabezado.Item("Ciudad") = Cmb_Ciudad.SelectedValue
        _Row_Encabezado.Item("Comuna") = Cmb_Comuna.SelectedValue

        _Row_Encabezado.Item("Direccion") = Txt_Direccion.Text

        Me.Close()

    End Sub

    Private Sub Btn_Ver_Mapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Mapa.Click
        Dim Fm As New Frm_Mapas("", "", "", Txt_Direccion.Text)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

End Class