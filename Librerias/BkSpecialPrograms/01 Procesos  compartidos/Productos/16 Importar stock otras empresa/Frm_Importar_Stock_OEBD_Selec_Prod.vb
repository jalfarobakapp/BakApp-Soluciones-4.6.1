Imports DevComponents.DotNetBar

Public Class Frm_Importar_Stock_OEBD_Selec_Prod

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos As DataTable
    Dim _Consolidar As Boolean

    Dim _Servidor, _Puerto, _Usuario, _Clave, _BaseDeDatos As String

    Dim _Empresa_Ori, _Sucursal_Ori, _Bodega_Ori As String
    Dim _Empresa_Des, _Sucursal_Des, _Bodega_Des As String

    Dim _Id_Conexion As Integer
    Dim _Cadena_ConexionSQL_Server_Origen As String
    Dim _Row_DnExt As DataRow
    Dim _Row_DbExtMaest As DataRow

    Public Sub New(_Id_Conexion As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Conexion = _Id_Conexion

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where Id = " & _Id_Conexion
        _Row_DnExt = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Empresa_Ori = _Row_DnExt.Item("Empresa")

        _Servidor = _Row_DnExt.Item("Servidor")
        _Puerto = _Row_DnExt.Item("Puerto")
        _Usuario = _Row_DnExt.Item("Usuario")
        _Clave = _Row_DnExt.Item("Clave")
        _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Id_Conexion = " & _Id_Conexion
        _Row_DbExtMaest = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_DbExtMaest) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DbExt_Maest (Id_Conexion,Empresa_Ori) Values (" & _Id_Conexion & ",'" & _Empresa_Ori & "')"
            _Sql.Ej_consulta_IDU(Consulta_sql)
            Grupo_Seleccion_Productos.Enabled = False
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Id_Conexion = " & _Id_Conexion
        _Row_DbExtMaest = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Importar_Stock_OEBD_Selec_Prod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Cargar_Datos_Conexion()

        Dtp_Fecha_Movimientos_Desde.Value = FechaDelServidor()
        Dtp_Fecha_Movimientos_Hasta.Value = Dtp_Fecha_Movimientos_Desde.Value

        AddHandler Rdb_Productos_Todos.CheckedChanged, AddressOf Sb_Enable_Botones
        AddHandler Rdb_Productos_Con_Movimientos.CheckedChanged, AddressOf Sb_Enable_Botones
        AddHandler Rdb_Productos_Seleccionar.CheckedChanged, AddressOf Sb_Enable_Botones

        Sb_Enable_Botones()

    End Sub
    Private Sub Btn_Grabar_Configuracion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Configuracion.Click

        Dim _Id = _Row_DbExtMaest.Item("Id")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DbExt_Maest Set " &
                       "Activo = 1," &
                       "Empresa_Ori = '" & _Empresa_Ori & "'," &
                       "Sucursal_Ori = '" & _Sucursal_Ori & "'," &
                       "Bodega_Ori = '" & _Bodega_Ori & "'," &
                       "Empresa_Des = '" & _Empresa_Des & "'," &
                       "Sucursal_Des = '" & _Sucursal_Des & "'," &
                       "Bodega_Des = '" & _Bodega_Des & "'," & vbCrLf &
                       "NombreBod_Ori = '" & _Row_DbExtMaest.Item("NombreBod_Ori") & "'," & vbCrLf &
                       "NombreBod_Des = '" & _Row_DbExtMaest.Item("NombreBod_Des") & "'" & vbCrLf &
                       "Where Id = " & _Id

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Sb_Cargar_Datos_Conexion()
            Btn_Grabar_Configuracion.Enabled = False
            Btn_Bodega_Origen.Enabled = False
            Btn_Bodega_Destino.Enabled = False

        End If

    End Sub

    Sub Sb_Cargar_Datos_Conexion()

        Dim _Activo As Boolean = _Row_DbExtMaest.Item("Activo")

        Lbl_Nombre_Conexion.Text = _Row_DnExt.Item("Nombre_Conexion")

        _Empresa_Ori = _Row_DbExtMaest.Item("Empresa_Ori")
        _Sucursal_Ori = _Row_DbExtMaest.Item("Sucursal_Ori")
        _Bodega_Ori = _Row_DbExtMaest.Item("Bodega_Ori")

        _Empresa_Des = _Row_DbExtMaest.Item("Empresa_Des")
        _Sucursal_Des = _Row_DbExtMaest.Item("Sucursal_Des")
        _Bodega_Des = _Row_DbExtMaest.Item("Bodega_Des")

        Lbl_Bodega_Origen.Text = "Empresa: " & _Empresa_Ori & ", Sucursal: " & _Sucursal_Ori & ", Bodega: " & _Bodega_Ori
        Lbl_Bodega_Destino.Text = "Empresa: " & _Empresa_Des & ", Sucursal: " & _Sucursal_Des & ", Bodega: " & _Bodega_Des

        Btn_Grabar_Configuracion.Enabled = True
        Grupo_Seleccion_Productos.Enabled = _Activo
        Btn_Aceptar.Enabled = _Activo

        Dim _ServidorPuerto As String = _Servidor

        If Not String.IsNullOrEmpty(_Puerto) Then
            _ServidorPuerto += "," & _Puerto
        End If

        _Cadena_ConexionSQL_Server_Origen = "data " &
                                            "source = " & _ServidorPuerto & "; " &
                                            "initial catalog = " & _BaseDeDatos & "; " &
                                            "user id = " & _Usuario & "; " &
                                            "password = " & _Clave

    End Sub

    Private Sub Btn_Seleccionar_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccionar_Productos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                Rdb_Productos_Todos.Checked = True
                _Tbl_Productos = Nothing
            End If

        End If

    End Sub

    Sub Sb_Enable_Botones()

        Lbl_Desde.Enabled = Rdb_Productos_Con_Movimientos.Checked
        Lbl_Hasta.Enabled = Rdb_Productos_Con_Movimientos.Checked
        Dtp_Fecha_Movimientos_Desde.Enabled = Rdb_Productos_Con_Movimientos.Checked
        Dtp_Fecha_Movimientos_Hasta.Enabled = Rdb_Productos_Con_Movimientos.Checked

        Btn_Seleccionar_Productos.Enabled = Rdb_Productos_Seleccionar.Checked

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        Dim _Aceptar = False

        If Rdb_Productos_Todos.Checked Then

            Consulta_sql = "SELECT KOPR AS 'Codigo', NOKOPR AS 'Descripcion' FROM MAEPR WHERE ATPR = '' AND TIPR = 'FPN'"
            _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        ElseIf Rdb_Productos_Con_Movimientos.Checked Then

            Consulta_sql = "SELECT KOPR AS 'Codigo', NOKOPR AS 'Descripcion' FROM MAEPR" & vbCrLf &
                           "WHERE ATPR = '' AND TIPR = 'FPN' AND" & Space(1) &
                           "KOPR IN (SELECT Distinct KOPRCT FROM MAEDDO" & Space(1) &
                           "WHERE FEEMLI BETWEEN '" & Format(Dtp_Fecha_Movimientos_Desde.Value, "yyyyMMdd") & "'" & Space(1) &
                           "AND '" & Format(Dtp_Fecha_Movimientos_Hasta.Value, "yyyyMMdd") & "')"
            _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

        If Not (_Tbl_Productos Is Nothing) Then
            If CBool(_Tbl_Productos.Rows.Count) Then
                _Aceptar = True
            End If
        End If

        If _Aceptar Then

            Dim _Cadena_ConexionSQL_Server_Origen = "data " &
                                                    "source = " & _Servidor & "; " &
                                                    "initial catalog = " & _BaseDeDatos & "; " &
                                                    "user id = " & _Usuario & "; " &
                                                    "password = " & _Clave

            Dim Fm As New Frm_Importar_Stock_OEBD(_Tbl_Productos, _Cadena_ConexionSQL_Server_Origen, "Codigo")
            Fm.Empresa_Ori = _Empresa_Ori
            Fm.Sucursal_Ori = _Sucursal_Ori
            Fm.Bodega_Ori = _Bodega_Ori
            Fm.Empresa_Des = _Empresa_Des
            Fm.Sucursal_Des = _Sucursal_Des
            Fm.Bodega_Des = _Bodega_Des
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else
            MessageBoxEx.Show(Me, "No exiten datos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Bodega_Origen_Click(sender As Object, e As EventArgs) Handles Btn_Bodega_Origen.Click

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Origen

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = _Empresa_Ori
        Fm_b.Pro_Sucursal = ModSucursal
        Fm_b.Pro_Bodega = ModBodega
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Row_DbExtMaest.Item("Empresa_Ori") = Fm_b.Pro_RowBodega.Item("EMPRESA")
            _Row_DbExtMaest.Item("Sucursal_Ori") = Fm_b.Pro_RowBodega.Item("KOSU")
            _Row_DbExtMaest.Item("Bodega_Ori") = Fm_b.Pro_RowBodega.Item("KOBO")
            _Row_DbExtMaest.Item("NombreBod_Ori") = Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

        Sb_Cargar_Datos_Conexion()

    End Sub

    Private Sub Btn_Bodega_Destino_Click(sender As Object, e As EventArgs) Handles Btn_Bodega_Destino.Click

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = ModEmpresa
        Fm_b.Pro_Sucursal = ModSucursal
        Fm_b.Pro_Bodega = ModBodega
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Row_DbExtMaest.Item("Empresa_Des") = Fm_b.Pro_RowBodega.Item("EMPRESA")
            _Row_DbExtMaest.Item("Sucursal_Des") = Fm_b.Pro_RowBodega.Item("KOSU")
            _Row_DbExtMaest.Item("Bodega_Des") = Fm_b.Pro_RowBodega.Item("KOBO")
            _Row_DbExtMaest.Item("NombreBod_Des") = Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

        Sb_Cargar_Datos_Conexion()

    End Sub

End Class
