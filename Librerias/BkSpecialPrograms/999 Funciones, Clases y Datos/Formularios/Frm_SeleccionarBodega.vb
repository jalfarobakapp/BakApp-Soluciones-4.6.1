Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_SeleccionarBodega

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _Pedir_Permiso As Boolean
    Dim _RowBodega As DataRow

    Dim _Seleccionado As Boolean

    Dim _Accion As Accion

    Enum Accion
        Empresa
        Sucursal
        Bodega
    End Enum

#Region "PROPIEDADES"

    Public Property Pro_Empresa() As String
        Get
            Return Cmbempresa.SelectedValue
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property
    Public Property Pro_Sucursal() As String
        Get
            Return Cmbsucursal.SelectedValue
        End Get
        Set(ByVal value As String)
            _Sucursal = value
        End Set
    End Property
    Public Property Pro_Bodega() As String
        Get
            Return Cmbbodega.SelectedValue
        End Get
        Set(ByVal value As String)
            _Bodega = value
        End Set
    End Property
    Public Property Pro_RowBodega() As DataRow
        Get
            _RowBodega = Fx_Trar_Datos_De_Bodega_Seleccionada(_Empresa, _Sucursal, _Bodega)
            Return _RowBodega
        End Get
        Set(ByVal value As DataRow)

        End Set
    End Property
    Public Property Pro_Nombre_Empresa() As String
        Get
            Return Cmbempresa.Text
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property Pro_Nombre_Sucursal() As String
        Get
            Return Cmbempresa.Text
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property Pro_Nombre_Bodega() As String
        Get
            Return Cmbempresa.Text
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property Pro_Seleccionado() As Boolean
        Get
            Return _Seleccionado
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property Pedir_Permiso As Boolean
        Get
            Return _Pedir_Permiso
        End Get
        Set(value As Boolean)
            _Pedir_Permiso = value
        End Set
    End Property

#End Region

    Public Sub New(ByVal Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion

        Consulta_sql = "Delete " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega'" & vbCrLf & _
                      "Insert Into " & _Global_BaseBk & "ZW_Permisos " & _
                      "(CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso)" & vbCrLf & _
                      "SELECT 'Bo'+EMPRESA+KOSU+KOBO,'BODEGA: '+NOKOBO,'Bodega','Bodegas'" & vbCrLf & _
                      "FROM TABBO"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

        _Pedir_Permiso = True

    End Sub

    Private Sub Frm_SeleccionarBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Empresa Is Nothing Then
            _Empresa = ModEmpresa
        End If

        Sb_Cargar_Empresa(_Empresa)

        Cmbempresa.Enabled = False

        If (_Sucursal Is Nothing) Then _Sucursal = String.Empty
        If (_Bodega Is Nothing) Then _Bodega = String.Empty

        'If Not (_Sucursal Is Nothing) Then
        Sb_Cargar_Sucursales(_Empresa, _Sucursal)
        'End If

        'If Not (_Bodega Is Nothing) Then
        Sb_Cargar_Bodegas(_Empresa, _Sucursal, _Bodega)
        'End If

        AddHandler Cmbempresa.SelectedIndexChanged, AddressOf Cmbempresa_SelectedIndexChanged
        AddHandler Cmbsucursal.SelectedIndexChanged, AddressOf Cmbsucursal_SelectedIndexChanged
        ' AddHandler Cmbbodega.SelectedIndexChanged, AddressOf Cmbbodega_SelectedIndexChanged

        Select Case _Accion

            Case Accion.Empresa
                Cmbsucursal.Enabled = False
                Cmbbodega.Enabled = False
            Case Accion.Sucursal
                Cmbbodega.Enabled = False
            Case Accion.Bodega

        End Select

    End Sub

    Sub Sb_Cargar_Empresa(ByVal _Empresa As String)

        caract_combo(Cmbempresa)
        Consulta_sql = "SELECT EMPRESA AS Padre,RAZON AS Hijo FROM CONFIGP" ' WHERE SEMILLA = " & Actividad
        Cmbempresa.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmbempresa.Focus()
        Cmbempresa.SelectedValue = _Empresa

    End Sub

    Sub Sb_Cargar_Sucursales(ByVal _Empresa As String, ByVal _Sucursal As String)

        Cmbsucursal.DataSource = Nothing
        Cmbbodega.DataSource = Nothing

        caract_combo(Cmbsucursal)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOSU AS Padre,KOSU+'-'+NOKOSU AS Hijo FROM TABSU WHERE EMPRESA = '" & _Empresa & "'"
        Cmbsucursal.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmbsucursal.SelectedValue = _Sucursal

    End Sub

    Sub Sb_Cargar_Bodegas(ByVal _Empresa As String, ByVal _Sucursal As String, ByVal _Bodega As String)

        Cmbbodega.DataSource = Nothing
        caract_combo(Cmbbodega)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOBO AS Padre,KOBO+'-'+NOKOBO AS Hijo FROM TABBO " & _
                       "WHERE EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "'"
        Cmbbodega.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmbbodega.SelectedValue = _Bodega

    End Sub

    Private Sub Cmbempresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Empresa = Cmbempresa.SelectedValue.ToString
        Sb_Cargar_Sucursales(_Empresa, "")
    End Sub

    Private Sub Cmbsucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Sucursal = Cmbsucursal.SelectedValue.ToString
        Cmbbodega.DataSource = Nothing
        Sb_Cargar_Bodegas(_Empresa, _Sucursal, "")
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Dim _Campo As String

        Select Case _Accion

            Case Accion.Empresa
                If Not String.IsNullOrEmpty(_Empresa) Then
                    _Seleccionado = True
                End If
            Case Accion.Sucursal
                If Not String.IsNullOrEmpty(_Sucursal) Then
                    _Seleccionado = True
                End If
            Case Accion.Bodega

                _Bodega = Cmbbodega.SelectedValue.ToString

                If Not String.IsNullOrEmpty(_Bodega) Then

                    Dim _Permiso As String

                    If _Pedir_Permiso Then
                        _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega
                        _Seleccionado = Fx_Tiene_Permiso(Me, _Permiso)
                    Else
                        _Seleccionado = True
                    End If

                    If Not _Seleccionado Then
                        Return
                    End If

                End If
        End Select

        If _Seleccionado Then
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "Debe seleccionar una " & _Accion.ToString, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub Frm_SeleccionarBodega_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub






End Class
