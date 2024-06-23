Imports System.IO
'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_Conexion_Web_Prestashop

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\Prestashop"
    Dim _Nombre_Archivo_XML As String = "Conexion_Web_PS.xml"

    'Public _Ds_Filtro As New Ds_Conexion_Web
    Dim _Grabar As Boolean
    Dim _Row_PrestaShop As DataRow

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public Property Pro_Row_PrestaShop() As DataRow
        Get
            Return _Row_PrestaShop
        End Get
        Set(ByVal value As DataRow)
            _Row_PrestaShop = value

            Txt_Codigo_Pagina.Text = _Row_PrestaShop.Item("Codigo_Pagina")
            Txt_Nombre_Pagina.Text = _Row_PrestaShop.Item("Nombre_Pagina")
            Txt_Host.Text = _Row_PrestaShop.Item("Host")
            Txt_Usuario.Text = _Row_PrestaShop.Item("Usuario")
            Txt_Clave.Text = _Row_PrestaShop.Item("Clave")
            Chk_Puerto_X_Defecto.Checked = _Row_PrestaShop.Item("Puerto_X_Defecto")
            Num_Puerto.Value = _Row_PrestaShop.Item("Puerto")
            Txt_Base_Datos.Text = _Row_PrestaShop.Item("Base_Datos")
            Cmb_Lista_Precios.SelectedValue = _Row_PrestaShop.Item("Cod_Lista")
            Num_Stock_Maximo.Value = _Row_PrestaShop.Item("Stock_Maximo")
            Chk_Usar_Stock_Maximo.Checked = _Row_PrestaShop.Item("Usar_Stock_Maximo")
            Chk_Conexion_Activa.Checked = _Row_PrestaShop.Item("Conexion_Activa")

            Txt_Codigo_Pagina.Enabled = False

        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Combo_Lista_Precios("")
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Conexion_Web_Prestashop_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub Sb_Combo_Lista_Precios(ByVal _Cod_Lista As String)

        caract_combo(Cmb_Lista_Precios)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOLT AS Padre,KOLT+' - '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'P' ORDER BY Padre"
        Cmb_Lista_Precios.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Lista_Precios.SelectedValue = _Cod_Lista

    End Sub

    Function Fx_Cadena_Conexion_MySql() As String

        Dim _Port = String.Empty

        If Not Chk_Puerto_X_Defecto.Checked Then
            _Port = ";Port=" & Num_Puerto.Value & ";"
        End If

        Dim _Ruta = "Host=" & Txt_Host.Text & ";Database=" & Txt_Base_Datos.Text & ";Uid=" & Txt_Usuario.Text & ";Password=" & Txt_Clave.Text & ";" & _Port

        _Ruta = "Host=" & Txt_Host.Text & ";Database=" & Txt_Base_Datos.Text & ";user id=" & Txt_Usuario.Text & ";Password=" & Txt_Clave.Text & _Port

        '_Ruta = "server=" & Txt_Host.Text & ";user id=" & Txt_Usuario.Text & ";password=" & Txt_Clave.Text & ";database=" & Txt_Base_Datos.Text & ";"
        Return _Ruta

    End Function

    Sub Sb_Crear_Nueva_Conexion()

        If String.IsNullOrEmpty(Cmb_Lista_Precios.SelectedValue) Then
            MessageBoxEx.Show(Me, "Falta lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Cadena_de_conexion_MySql As String = Fx_Cadena_Conexion_MySql()
        Dim _Sql_MySql As New Class_MySQL(_Cadena_de_conexion_MySql)

        _Sql_MySql.Sb_Abrir_Conexion()
        Dim _Error As String = _Sql_MySql.Pro_Error

        If String.IsNullOrEmpty(_Error) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_PrestaShop" & Space(1) &
                           "(Codigo_Pagina,Nombre_Pagina,Host,Usuario,Clave,Puerto_X_Defecto,Puerto,Base_Datos," &
                           "Cod_Lista,Usar_Stock_Maximo,Stock_Maximo,Grabar_Stock_X_Bodega) Values" & Space(1) &
                           "('" & Txt_Codigo_Pagina.Text & "','" & Txt_Nombre_Pagina.Text & "','" & Txt_Host.Text &
                           "','" & Txt_Usuario.Text & "','" & Txt_Clave.Text &
                           "'," & CInt(Chk_Puerto_X_Defecto.Checked) * -1 & "," & Num_Puerto.Value &
                           ",'" & Txt_Base_Datos.Text & "','" & Cmb_Lista_Precios.SelectedValue & "'," & Convert.ToInt32(Chk_Usar_Stock_Maximo.Checked) &
                           "," & De_Num_a_Tx_01(Num_Stock_Maximo.Value, False, 6) & "," & Convert.ToInt32(Chk_Grabar_Stock_X_Bodega.Checked) & ")"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                _Grabar = True
                MessageBoxEx.Show(Me, "Datos guardados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop Where Codigo_Pagina = '" & Txt_Codigo_Pagina.Text & "'"
                _Row_PrestaShop = _Sql.Fx_Get_DataRow(Consulta_sql)

                Txt_Codigo_Pagina.Enabled = False

            End If

        Else
            MessageBoxEx.Show(Me, "Problemas con la conexión a la base de datos MySQL." & vbCrLf &
                               "Cadena de conexión: " & _Cadena_de_conexion_MySql & vbCrLf & vbCrLf &
                               "Error: " & _Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Sub Sb_Editar_Conexion()

        If String.IsNullOrEmpty(Cmb_Lista_Precios.SelectedValue) Then
            MessageBoxEx.Show(Me, "Falta lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Cadena_de_conexion_MySql As String = Fx_Cadena_Conexion_MySql()
        Dim _Sql_MySql As New Class_MySQL(_Cadena_de_conexion_MySql)

        _Sql_MySql.Sb_Abrir_Conexion()
        Dim _Error As String = _Sql_MySql.Pro_Error

        If Not String.IsNullOrEmpty(_Error) Then

            MessageBoxEx.Show(Me, "Problemas con la conexión a la base de datos MySQL." & vbCrLf &
                              "Cadena de conexión: " & _Cadena_de_conexion_MySql & vbCrLf & vbCrLf &
                              "Error: " & _Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Chk_Conexion_Activa.Checked = False

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_PrestaShop Set" & vbCrLf &
                       "Codigo_Pagina = '" & Txt_Codigo_Pagina.Text & "'," &
                       "Nombre_Pagina = '" & Txt_Nombre_Pagina.Text & "'," &
                       "Host = '" & Txt_Host.Text & "'," &
                       "Usuario = '" & Txt_Usuario.Text & "'," &
                       "Clave = '" & Txt_Clave.Text & "'," &
                       "Puerto_X_Defecto = " & CInt(Chk_Puerto_X_Defecto.Checked) * -1 & "," &
                       "Puerto = " & Num_Puerto.Value & "," &
                       "Base_Datos = '" & Txt_Base_Datos.Text & "'," & vbCrLf &
                       "Conexion_Activa = " & CInt(Chk_Conexion_Activa.Checked) * -1 & "," &
                       "Cod_Lista = '" & Cmb_Lista_Precios.SelectedValue & "'," &
                       "Usar_Stock_Maximo = " & Chk_Usar_Stock_Maximo.Checked * -1 & "," &
                       "Stock_Maximo = " & De_Num_a_Tx_01(Num_Stock_Maximo.Value, False, 6) & "," &
                       "Grabar_Stock_X_Bodega = " & Chk_Grabar_Stock_X_Bodega.Checked * -1 & vbCrLf &
                       "Where Codigo_Pagina = '" & Txt_Codigo_Pagina.Text & "'"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            _Grabar = True
            MessageBoxEx.Show(Me, "Datos guardados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop Where Codigo_Pagina = '" & Txt_Codigo_Pagina.Text & "'"
            _Row_PrestaShop = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Codigo_Pagina.Enabled = False

        End If


    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If (_Row_PrestaShop Is Nothing) Then
            Sb_Crear_Nueva_Conexion()
        Else
            Sb_Editar_Conexion()
        End If

    End Sub

    Private Sub Frm_Conexion_Web_Prestashop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "ARCHIVO XML PARA FILTRO"

    'Function Fx_Conectar_WPS(ByVal _Formulario As Form) As Boolean

    'Dim DaMySql As MySqlDataAdapter
    'Dim DsMySql As New DataSet

    'Dim _Cn_MySql As MySqlConnection

    'Dim _Servidor = Txt_Host.Text '"www.luferco.cl"
    'Dim _Base_De_Datos = Txt_Base_Datos.Text '"luferc59_prst1"
    'Dim _Usuario = Txt_Usuario.Text '"luferc59_bakapp"
    'Dim _Clave = Txt_Clave.Text '"171105"

    'Dim _Port As String

    'If Not String.IsNullOrEmpty(Trim(Txt_Puerto.Text)) Then
    '_Port = "Port=" & Txt_Puerto.Text & ";"
    'End If

    'Dim ruta As String = "Server=" & _Servidor & ":3306; Database=" & _Base_De_Datos _
    '                   & "; User id=" & _Usuario & "; password=" & _Clave & ";" & _Port

    '    ruta = "Server=" & _Servidor & "; Database=" & _Base_De_Datos & "; Uid=" & _Usuario & "; Pwd=" & _Clave

    '    ruta = "Host=" & _Servidor & ";Database=" & _Base_De_Datos & ";Uid=" & _Usuario & ";Password=" & _Clave & ";"


    '    Try
    '        _Cn_MySql = New MySqlConnection(ruta)
    '        _Cn_MySql.Open()
    '        Return True
    '    Catch ex As Exception
    'MessageBoxEx.Show(Me, "No existen datos de conexión para este modulo", "Conexión Web", _
    '                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        MessageBoxEx.Show(_Formulario, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try

    'End Function

    'Public Function Fx_Actualizar_Filtros(ByVal _Formulario As Form)

    'Try

    '_Ds_Filtro.Clear()

    'Dim NewFila As DataRow

    '' OPCIONES DE FILTRO DE DOCUMENTOS
    '        NewFila = _Ds_Filtro.Tables("Tbl_Conexion_Web").NewRow
    '        With NewFila

    '           .Item("Servidor") = Txt_Host.Text
    '           .Item("Puerto") = Txt_Puerto.Text
    '           .Item("usuario") = Txt_Usuario.Text
    '           .Item("Clave") = Txt_Clave.Text
    '           .Item("Base_De_Datos") = Txt_Base_Datos.Text

    '        End With
    '        _Ds_Filtro.Tables("Tbl_Conexion_Web").Rows.Add(NewFila)


    '        _Ds_Filtro.WriteXml(_Directorio & "\" & _Nombre_Archivo_XML)
    '        Return True
    '    Catch ex As Exception
    '        MessageBoxEx.Show(_Formulario, ex.Message)
    '    End Try

    'End Function


#End Region

End Class
