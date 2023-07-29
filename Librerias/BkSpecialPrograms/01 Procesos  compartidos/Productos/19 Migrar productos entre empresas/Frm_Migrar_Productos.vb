Public Class Frm_Migrar_Productos

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _Sql2 As Class_SQL

    Dim _Ds_Producto_Local As DataSet
    Dim _Ds_Producto_Ext As DataSet
    Dim _TablasRandom As List(Of String)
    Dim _TablasBakapp As List(Of String)
    Dim _CancelarTablas As Boolean
    Dim _CancelarCampos As Boolean

    Dim _Cadena_ConexionSQL_Server_Ext As String

    Public Sub New(_Cadena_ConexionSQL_Server_Ext As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Cadena_ConexionSQL_Server_Ext = _Cadena_ConexionSQL_Server_Ext

        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_KOPR.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Usuarios_Random_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ObtenerServExt()
        _Ds_Producto_Local = BuscarProducto(Txt_KOPR.Text, _Global_BaseBk, _Sql)
        Grilla_Productos.DataSource = _Ds_Producto_Local.Tables(0)

        _Sql2 = New Class_SQL(_Cadena_ConexionSQL_Server_Ext)

        'Obtener bd bakapp de servidor externo
        Dim BdBakappExt As String = _Sql2.Fx_Obtener_Valores("SELECT NOKOCARAC FROM TABCARAC WHERE KOTABLA = 'BAKAPP';", 1)(0) & ".dbo."

    End Sub

    Public Sub ObtenerServExt()

        '      Dim ServExt = _Sql.Fx_Obtener_Valores("SELECT T2.Nombre_Conexion
        'FROM " & _Global_BaseBk & "[Zw_DbExt_Conexion_Prods] as T1 INNER JOIN " & _Global_BaseBk & "[Zw_DbExt_Conexion] as T2 ON T1.id_conexion=T2.Id WHERE T1.Id=1;", 1)(0)
        '      Txt_Server.Text = ServExt
        '      If Txt_Server.Text = "" Then

        '          MsgBox("No existen conexiones externas configuradas.")

        '      End If


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Activo = 1"
        Dim _Row_DbExtMaest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_DbExtMaest) Then
            Return
        End If

        Dim _Id_Conexion = _Row_DbExtMaest.Item("Id_Conexion")

        'Dim _Empresa_Ori = _Row_DbExtMaest.Item("Empresa_Ori")
        'Dim _Sucursal_Ori = _Row_DbExtMaest.Item("Sucursal_Ori")
        'Dim _Bodega_Ori = _Row_DbExtMaest.Item("Bodega_Ori")

        'Dim _Empresa_Des = _Row_DbExtMaest.Item("Empresa_Des")
        'Dim _Sucursal_Des = _Row_DbExtMaest.Item("Sucursal_Des")
        'Dim _Bodega_Des = _Row_DbExtMaest.Item("Bodega_Des")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where Id = " & _Id_Conexion
        Dim _Row_DnExt As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Servidor = _Row_DnExt.Item("Servidor")
        Dim _Puerto = _Row_DnExt.Item("Puerto")
        Dim _Usuario = _Row_DnExt.Item("Usuario")
        Dim _Clave = _Row_DnExt.Item("Clave")
        Dim _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")

        Dim _ServidorPuerto As String = _Servidor

        If Not String.IsNullOrEmpty(_Puerto) Then
            _ServidorPuerto = _Servidor & "," & _Puerto
        End If

        _Cadena_ConexionSQL_Server_Ext = "data " &
                                        "source = " & _ServidorPuerto & "; " &
                                        "initial catalog = " & _BaseDeDatos & "; " &
                                        "user id = " & _Usuario & "; " &
                                        "password = " & _Clave

    End Sub


    Private Sub Frm_Usuarios_Random_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        _Ds_Producto_Local = BuscarProducto(Txt_KOPR.Text, _Global_BaseBk, _Sql)
        Grilla_Productos.DataSource = _Ds_Producto_Local.Tables(0)
        If Grilla_Productos.Rows.Count > 0 Then
            MsgBox("Producto Encontrado en BD Local")
        Else
            MsgBox("No existen productos con este codigo")
        End If
    End Sub

    Function BuscarProducto(codigo As String, BaseBk As String, Conn As Class_SQL)
        'incluir un select con los nombres de las tablas que se van a incluir

        _TablasRandom = New List(Of String)
        _TablasRandom.Add("MAEPR;KOPR")
        _TablasRandom.Add("MAEPREM;KOPR")
        _TablasRandom.Add("TABBOPR;KOPR")
        _TablasRandom.Add("TABPRE;KOPR")
        _TablasRandom.Add("PDIMEN;CODIGO")
        _TablasRandom.Add("MAEPROBS;KOPR")
        _TablasRandom.Add("MAEFICHA;KOPR")
        _TablasRandom.Add("MAEFICHD;KOPR")
        _TablasRandom.Add("TABIMPR;KOPR")
        _TablasRandom.Add("MPROENVA;KOPR")
        _TablasRandom.Add("TABCODAL;KOPR")

        _TablasBakapp = New List(Of String)
        _TablasBakapp.Add("Zw_ListaPreCosto;Codigo")
        _TablasBakapp.Add("Zw_ListaPreProducto;Codigo")
        _TablasBakapp.Add("Zw_Prod_Asociacion;Codigo")

        Dim _Ds_Producto As New DataSet

        For Each _TblNameCod As String In _TablasRandom
            Dim _TbCb() = Split(_TblNameCod, ";", 2)
            Dim _Tbl2 As DataTable = Fx_Tabla(_TbCb(0), _TbCb(1), codigo, Conn)
            _Ds_Producto.Tables.Add(_Tbl2)
        Next

        For Each _TblNameCod As String In _TablasBakapp
            Dim _TbCb() = Split(_TblNameCod, ";", 2)
            Dim _Tbl2 As DataTable = Fx_Tabla(BaseBk & _TbCb(0), _TbCb(1), codigo, Conn)
            _Ds_Producto.Tables.Add(_Tbl2)
        Next

        Return _Ds_Producto

    End Function

    Function Fx_Tabla(_Nomtabla As String, _Campo As String, _Codigo As String) As DataTable
        Dim _ConsultaSql = "SELECT * FROM " & _Nomtabla & " WHERE " & _Campo & "='" & _Codigo & "';"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_ConsultaSql)
        _Tbl.TableName = _Nomtabla '.Replace(_Global_BaseBk, "")
        Return _Tbl
    End Function

    Function Fx_Tabla(_Nomtabla As String, _Campo As String, _Codigo As String, Conexion As Class_SQL) As DataTable
        Dim _ConsultaSql = "SELECT * FROM " & _Nomtabla & " WHERE " & _Campo & "='" & _Codigo & "';"
        Dim _Tbl As DataTable = Conexion.Fx_Get_Tablas(_ConsultaSql)
        _Tbl.TableName = _Nomtabla '.Replace(_Global_BaseBk, "")
        Return _Tbl
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_Configurar.Click
        'Dim Frm As New Frm_Migrar_Productos_Config
        'Frm.ShowDialog()
        'If Frm.Grabar Then
        '    Txt_Server.Text = Frm.NombreConexion
        'End If
        'Frm.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Btn_Migrar.Click

        ''Obtener datos de conexion a bd ext desde config
        'Dim DatosConexionExt As String() = _Sql.Fx_Obtener_Valores("SELECT Servidor, Puerto, BaseDeDatos, Usuario, Clave FROM " & _Global_BaseBk & "[Zw_DbExt_Conexion] WHERE Nombre_Conexion='" & Txt_Server.Text & "';", 5)
        'Dim CadenaConexionExt As String = "Server=" & DatosConexionExt(0) & "," & DatosConexionExt(1) & ";Database=" & DatosConexionExt(2) & ";User Id=" & DatosConexionExt(3) & ";Password=" & DatosConexionExt(3) & ";"

        '_Sql2 = New Class_SQL(CadenaConexionExt)

        'Obtener bd bakapp de servidor externo
        Dim BdBakappExt As String = _Sql2.Fx_Obtener_Valores("SELECT NOKOCARAC FROM TABCARAC WHERE KOTABLA = 'BAKAPP';", 1)(0) & ".dbo."
        'Busca el producto
        _Ds_Producto_Ext = BuscarProducto(Txt_KOPR.Text, BdBakappExt, _Sql2)
        'Prueba de generacion de consulta migrar producto Dim ConsultaPR = GenerarConsultaMigracion(_Ds_Producto_Local, BdBakappExt)
        If _Ds_Producto_Ext.Tables(0).Rows.Count > 0 Then
            Consulta_sql = "INSERT INTO " & _Global_BaseBk & "[Zw_Migrar_Productos_Log] (Fecha, Kopr, Funcionario, Log) VALUES ('" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Txt_KOPR.Text & "', '" & FUNCIONARIO & "', 'El Producto ya existe en la base de datos externa.');"
            _Sql.Fx_Ejecutar_Consulta(Consulta_sql)
            MsgBox("El producto a migrar ya existe en la BD Externa")
            Exit Sub
        Else

            ' Crear consulta migracion
            Consulta_sql = GenerarConsultaMigracion(_Ds_Producto_Local, BdBakappExt)

            If _Sql2.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                Consulta_sql = "INSERT INTO " & _Global_BaseBk & "[Zw_Migrar_Productos_Log] (Fecha, Kopr, Funcionario, Log) VALUES ('" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Txt_KOPR.Text & "', '" & FUNCIONARIO & "', 'Producto migrado correctamente');"
                _Sql.Fx_Ejecutar_Consulta(Consulta_sql)
                MsgBox("El producto fue migrado satisfactoriamente")
            Else
                MsgBox(_Sql2.Pro_Error)
            End If
            '_Sql2.Fx_Ejecutar_Consulta(Consulta)

        End If


    End Sub
    Function GenerarConsultaMigracion(_Ds_Producto As DataSet, BdBakappExt As String) As String

        Dim Consulta = String.Empty

        For table = 0 To _Ds_Producto.Tables.Count - 1

            If _Ds_Producto.Tables(table).Rows.Count > 0 Then

                Dim _NombreTabla As String = _Ds_Producto.Tables(table).TableName

                If _Ds_Producto.Tables(table).TableName.Contains(_Global_BaseBk) Then
                    Consulta &= "SET IDENTITY_INSERT " & _Ds_Producto.Tables(table).TableName & " ON;" & "INSERT INTO " & _Ds_Producto.Tables(table).TableName & "("
                Else
                    Consulta &= "INSERT INTO " & _NombreTabla & "("
                End If

                Dim _CantColumnas As Integer = _Ds_Producto.Tables(table).Columns.Count - 1

                If _NombreTabla = "TABPRE" Then
                    _CantColumnas = 27
                End If

                For column = 0 To _CantColumnas
                    Consulta &= _Ds_Producto.Tables(table).Columns(column).ColumnName & ","
                Next
                Consulta &= ")"
                Consulta = Consulta.Replace(",)", ")")

                Consulta &= " VALUES "

                For row = 0 To _Ds_Producto.Tables(table).Rows.Count - 1
                    Consulta &= "("
                    For column = 0 To _CantColumnas
                        Consulta &= "'"
                        Consulta &= _Ds_Producto.Tables(table).Rows(row)(column).ToString().Replace(",", ".") & "',"
                    Next
                    Consulta &= ")"
                    Consulta = Consulta.Replace(",)", ")")
                    Consulta &= ","
                Next
                Consulta &= ";"
                If _Ds_Producto.Tables(table).TableName.Contains(_Global_BaseBk) Then
                    Consulta = Consulta.Replace("),;", ");SET IDENTITY_INSERT " & _Ds_Producto.Tables(table).TableName & " OFF;")
                Else
                    Consulta = Consulta.Replace("),;", ");")
                End If

            End If

        Next

        Consulta = Consulta.Replace(_Global_BaseBk, BdBakappExt)
        Return Consulta

    End Function

    Function RevisarTablas(_Ds_Producto As DataSet, BdBakappExt As String) As List(Of String)

        Dim _Nueva_Lista As New List(Of String)
        Dim NombreTabla = String.Empty

        Lbl_Progreso_Tablas.Text = "Progreso: Calculando..."

        Application.DoEvents()

        Dim Paso As Integer = 100 / _Ds_Producto.Tables.Count

        Progreso_Tablas.Step = Paso
        Lbl_Progreso_Tablas.Text = "Progreso: 0%"

        Application.DoEvents()

        For table = 0 To _Ds_Producto.Tables.Count - 1

            If _CancelarTablas Then

                Progreso_Tablas.Value = 0
                Lbl_Progreso_Tablas.Text = "Progreso: Cancelado"
                _CancelarTablas = False
                Return _Nueva_Lista

            End If

            NombreTabla = _Ds_Producto.Tables(table).TableName.ToString().Replace(_Global_BaseBk, BdBakappExt)

            If Not _Sql2.Fx_Existe_Tabla(NombreTabla, BdBakappExt) Then
                _Nueva_Lista.Add("" & NombreTabla)
            End If

            Progreso_Tablas.PerformStep()
            Lbl_Progreso_Tablas.Text = "Progreso: " & Progreso_Tablas.Value & "%"
            Application.DoEvents()

        Next

        Progreso_Tablas.Value = 100
        Lbl_Progreso_Tablas.Text = "Progreso: " & Progreso_Tablas.Value & "%"

        Application.DoEvents()

        Return _Nueva_Lista

    End Function
    Function RevisarCampos(_Ds_Producto As DataSet, BdBakappExt As String) As List(Of String)

        Dim _Nueva_Lista As New List(Of String)
        Dim NombreTabla As String = ""
        Dim NombreColumna As String = ""

        Lbl_Progreso_Campos.Text = "Progreso: Calculando..."

        Application.DoEvents()

        Dim ColumnasTotal As Integer = 0

        For table = 0 To _Ds_Producto.Tables.Count - 1
            For column = 0 To _Ds_Producto.Tables(table).Columns.Count - 1
                ColumnasTotal += 1
            Next
        Next

        Dim Paso As Double = 100 / ColumnasTotal
        Dim ValorProgreso As Double = 0

        Lbl_Progreso_Campos.Text = "Progreso: 0%"
        Application.DoEvents()

        For table = 0 To _Ds_Producto.Tables.Count - 1

            NombreTabla = _Ds_Producto.Tables(table).TableName.ToString().Replace(_Global_BaseBk, BdBakappExt)

            For column = 0 To _Ds_Producto.Tables(table).Columns.Count - 1

                If _CancelarCampos Then

                    Progreso_Campos.Value = 0
                    Lbl_Progreso_Campos.Text = "Progreso: Cancelado"
                    _CancelarCampos = False
                    Return _Nueva_Lista

                End If

                NombreColumna = _Ds_Producto.Tables(table).Columns(column).ColumnName

                If Not _Sql2.Fx_Exite_Campo(NombreTabla, NombreColumna, BdBakappExt) Then
                    _Nueva_Lista.Add("Tabla: " & NombreTabla & ", Campo: " & NombreColumna)
                End If

                ValorProgreso += Paso
                Progreso_Campos.Value = CInt(ValorProgreso)
                Lbl_Progreso_Campos.Text = "Progreso: " & Progreso_Campos.Value & "%"
                Application.DoEvents()

            Next

        Next

        Progreso_Campos.Value = 100
        Lbl_Progreso_Campos.Text = "Progreso: " & Progreso_Campos.Value & "%"

        Return _Nueva_Lista

    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Btn_Productos_Local.Click

        'Dim DatosConexionExt As String() = _Sql.Fx_Obtener_Valores("SELECT Servidor, Puerto, BaseDeDatos, Usuario, Clave FROM " & _Global_BaseBk & "[Zw_DbExt_Conexion] WHERE Nombre_Conexion='" & Txt_Server.Text & "';", 5)
        'Dim CadenaConexionExt As String = "Server=" & DatosConexionExt(0) & "," & DatosConexionExt(1) & ";Database=" & DatosConexionExt(2) & ";User Id=" & DatosConexionExt(3) & ";Password=" & DatosConexionExt(3) & ";"
        '_Sql2 = New Class_SQL(CadenaConexionExt)

        Dim consulta As String = "SELECT KOPR, NOKOPR FROM MAEPR;"
        Dim Tabla2 As DataTable = _Sql.Fx_Get_Tablas(consulta)
        Dim Tabla1 As DataTable = _Sql2.Fx_Get_Tablas(consulta)
        Dim idsNotInB = Tabla1.AsEnumerable().Select(Function(r) r.Field(Of String)("KOPR")).Except(Tabla2.AsEnumerable().[Select](Function(r) r.Field(Of String)("KOPR")))
        Dim TableC As DataTable = (From row In Tabla1.AsEnumerable() Join id In idsNotInB On row.Field(Of String)("KOPR") Equals id Select row).CopyToDataTable()
        ExportarTabla_JetExcel_Tabla(TableC, Me, "MAEPR")

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Btn_Productos_Ext.Click

        'Dim DatosConexionExt As String() = _Sql.Fx_Obtener_Valores("SELECT Servidor, Puerto, BaseDeDatos, Usuario, Clave FROM " & _Global_BaseBk & "[Zw_DbExt_Conexion] WHERE Nombre_Conexion='" & Txt_Server.Text & "';", 5)
        'Dim CadenaConexionExt As String = "Server=" & DatosConexionExt(0) & "," & DatosConexionExt(1) & ";Database=" & DatosConexionExt(2) & ";User Id=" & DatosConexionExt(3) & ";Password=" & DatosConexionExt(3) & ";"
        '_Sql2 = New Class_SQL(CadenaConexionExt)

        Dim consulta As String = "SELECT KOPR, NOKOPR FROM MAEPR;"
        Dim Tabla1 As DataTable = _Sql.Fx_Get_Tablas(consulta)
        Dim Tabla2 As DataTable = _Sql2.Fx_Get_Tablas(consulta)

        Dim idsNotInB = Tabla1.AsEnumerable().Select(Function(r) r.Field(Of String)("KOPR")).Except(Tabla2.AsEnumerable().[Select](Function(r) r.Field(Of String)("KOPR")))
        Dim TableC As DataTable = (From row In Tabla1.AsEnumerable() Join id In idsNotInB On row.Field(Of String)("KOPR") Equals id Select row).CopyToDataTable()
        ExportarTabla_JetExcel_Tabla(TableC, Me, "MAEPR")

    End Sub
    Private Sub ActivarBotones(Proceso As Boolean)

        Btn_Buscar.Enabled = Proceso
        Btn_Configurar.Enabled = Proceso
        Btn_Tablas.Enabled = Proceso
        Btn_Campos.Enabled = Proceso
        Btn_Productos_Ext.Enabled = Proceso
        Btn_Productos_Local.Enabled = Proceso
        Btn_Migrar.Enabled = Proceso
        Me.ControlBox = Proceso

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Btn_Tablas.Click
        'Bloquear botones

        ActivarBotones(False)
        Btn_Cancelar_Tablas.Visible = True
        'Obtener datos de conexion a bd ext desde config
        'Dim DatosConexionExt As String() = _Sql.Fx_Obtener_Valores("SELECT Servidor, Puerto, BaseDeDatos, Usuario, Clave FROM " & _Global_BaseBk & "[Zw_DbExt_Conexion] WHERE Nombre_Conexion='" & Txt_Server.Text & "';", 5)
        'Dim CadenaConexionExt As String = "Server=" & DatosConexionExt(0) & "," & DatosConexionExt(1) & ";Database=" & DatosConexionExt(2) & ";User Id=" & DatosConexionExt(3) & ";Password=" & DatosConexionExt(3) & ";"
        '_Sql2 = New Class_SQL(CadenaConexionExt)

        'Obtener bd bakapp de servidor externo
        Dim BdBakappExt As String = _Sql2.Fx_Obtener_Valores("SELECT NOKOCARAC FROM TABCARAC WHERE KOTABLA = 'BAKAPP';", 1)(0) & ".dbo."
        ' Probar integridad de tablas entre BD

        Dim TablasFaltantes As List(Of String) = RevisarTablas(_Ds_Producto_Local, BdBakappExt)
        Dim MensajeTablas As String = ""

        If TablasFaltantes.Count > 0 Then

            For Each TablaFaltante As String In TablasFaltantes
                MensajeTablas &= TablaFaltante & vbCrLf
            Next

            MsgBox("Las siguientes tablas no existen en la BD externa:" & vbCrLf & MensajeTablas)
            Progreso_Tablas.Value = 0
            Lbl_Progreso_Tablas.Text = "Progreso: Completado"
            ActivarBotones(True)
            Btn_Cancelar_Tablas.Visible = False
            Return

        Else

            MsgBox("No existen tablas faltantes en la BD externa.")
            Progreso_Tablas.Value = 0
            Lbl_Progreso_Tablas.Text = "Progreso: Completado"
            ActivarBotones(True)
            Btn_Cancelar_Tablas.Visible = False
            Return

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Btn_Campos.Click

        ActivarBotones(False)
        Btn_Cancelar_Campos.Visible = True
        'Obtener datos de conexion a bd ext desde config
        'Dim DatosConexionExt As String() = _Sql.Fx_Obtener_Valores("SELECT Servidor, Puerto, BaseDeDatos, Usuario, Clave FROM " & _Global_BaseBk & "[Zw_DbExt_Conexion] WHERE Nombre_Conexion='" & Txt_Server.Text & "';", 5)
        'Dim CadenaConexionExt As String = "Server=" & DatosConexionExt(0) & "," & DatosConexionExt(1) & ";Database=" & DatosConexionExt(2) & ";User Id=" & DatosConexionExt(3) & ";Password=" & DatosConexionExt(3) & ";"

        '_Sql2 = New Class_SQL(CadenaConexionExt)

        'Obtener bd bakapp de servidor externo
        Dim BdBakappExt As String = _Sql2.Fx_Obtener_Valores("SELECT NOKOCARAC FROM TABCARAC WHERE KOTABLA = 'BAKAPP';", 1)(0) & ".dbo."

        ' Probar integridad de columnas entre BD
        Dim ColumnasFaltantes As List(Of String) = RevisarCampos(_Ds_Producto_Local, BdBakappExt)
        Dim MensajeColumnas As String = ""

        If ColumnasFaltantes.Count > 0 Then

            For Each ColumnaFaltante As String In ColumnasFaltantes
                MensajeColumnas &= ColumnaFaltante & vbCrLf
            Next

            Progreso_Campos.Value = 0
            Lbl_Progreso_Campos.Text = "Progreso: Completado"
            MsgBox("Las siguientes Columnas no existen en la BD externa:" & vbCrLf & MensajeColumnas)
            ActivarBotones(True)
            Btn_Cancelar_Campos.Visible = False
            Return

        Else

            Progreso_Campos.Value = 0
            Lbl_Progreso_Campos.Text = "Progreso: Completado"
            MsgBox("No existen columnas faltantes en la BD externa.")
            ActivarBotones(True)
            Btn_Cancelar_Campos.Visible = False
            Return

        End If

    End Sub

    Private Sub Btn_Cancelar_Tablas_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar_Tablas.Click
        _CancelarTablas = True
    End Sub

    Private Sub Btn_Cancelar_Campos_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar_Campos.Click
        _CancelarCampos = True
    End Sub
End Class
