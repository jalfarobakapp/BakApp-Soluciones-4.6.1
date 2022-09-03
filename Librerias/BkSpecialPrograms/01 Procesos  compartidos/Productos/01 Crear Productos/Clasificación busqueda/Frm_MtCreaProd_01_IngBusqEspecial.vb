Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Frm_MtCreaProd_01_IngBusqEspecial

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Clasificaciones As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Clasificaciones, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub


    Private Sub Frm_MtCreaProd_01_IngBusqEspecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        If Fx_Tiene_Permiso(Me, "Prod014", , False) Then
            TxtDescripcion.ReadOnly = False
        Else
            TxtDescripcion.ReadOnly = True
        End If

        BtnAsociaciones_arbol.Visible = False

        'AddHandler Grilla_Clasificaciones.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Clasificaciones.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Clas_Arbol_Asociaciones As New Clas_Arbol_Asociaciones(Me)

        Consulta_sql = "Select *" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where Codigo = '" & TxtCodigo.Text & "' And Producto = 0" & vbCrLf &
                       "And (Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Seleccionable = 1)" & vbCrLf &
                       "Or Clas_unica = 1)"
        Dim _TblClass As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _SqlQuery = "Select *,Cast('' As Varchar(500)) As Full_Path,
                         Cast(Isnull((Select Top 1 Clas_Unica_X_Producto From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Z2 Where Z1.Codigo_Nodo = Z2.Codigo_Nodo ),0) As Bit) As Clas_Unica_X_Producto" & vbCrLf &
                        "Into #Paso" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Prod_Asociacion Z1" & vbCrLf &
                        "Where Codigo = '" & TxtCodigo.Text & "' And Producto = 0" & vbCrLf &
                        "And (Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Seleccionable = 1)" & vbCrLf &
                        "Or Clas_unica = 1)" & vbCrLf & vbCrLf

        For Each _Fila As DataRow In _TblClass.Rows

            Dim _Id = _Fila.Item("Id")
            Dim _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
            Dim _Descripcion As String = _Fila.Item("DescripcionBusqueda")
            Dim _Full_Path As String
            Dim _Clas_unica As Boolean = CBool(_Fila.Item("Clas_unica"))

            If _Clas_unica Then
                _Full_Path = _Descripcion
            Else
                _Full_Path = Fx_Raiz_Clasificacion_FullPath(_Codigo_Nodo) & "\" & _Descripcion ' _Clas_Arbol_Asociaciones.Fx_Raiz_Clasificacion_New(_Codigo_Nodo, "")
            End If

            _SqlQuery += "Update #Paso Set Full_Path = '" & _Full_Path & "' Where Id = " & _Id & vbCrLf

        Next

        Consulta_sql = _SqlQuery & vbCrLf &
                        "Select * From #Paso" & vbCrLf &
                        "Order by Clas_unica,Full_Path" & vbCrLf &
                        "Drop Table #Paso"

        _TblClass = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Clasificaciones

            .DataSource = _TblClass
            OcultarEncabezadoGrilla(Grilla_Clasificaciones, True)

            .Columns("Full_Path").Width = 740
            .Columns("Full_Path").HeaderText = "Descripción de clasificación"
            .Columns("Full_Path").Visible = True

        End With

        For Each _Fila As DataGridViewRow In Grilla_Clasificaciones.Rows

            Dim _Clas_unica As Boolean = _Fila.Cells("Clas_unica").Value
            Dim _Clas_Unica_X_Producto As Boolean = _Fila.Cells("Clas_Unica_X_Producto").Value

            If _Clas_unica Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
                _Fila.DefaultCellStyle.BackColor = Color.Yellow
            End If

            If _Clas_Unica_X_Producto Then

                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Color.FromArgb(174, 132, 213)
                Else
                    _Fila.DefaultCellStyle.ForeColor = Color.Purple
                End If

            End If

        Next

    End Sub

    Function Fx_Raiz_Clasificacion_FullPath(ByVal _Codigo_Nodo As String)

        Dim _Full As String = String.Empty
        Dim _CodPadre As String

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")

        Do While (_CodPadre <> 0)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _CodPadre
            _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

            _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")
            _Full = "\" & _Tbl.Rows(0).Item("Descripcion") & _Full

        Loop

        Return _Full

    End Function

    Private Sub BtnAsociaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsociaciones.Click

        Dim _Aceptar As Boolean

        Try
            Me.Enabled = False

            If Fx_Tiene_Permiso(Me, "Tbl00002") Then

                Dim _Tbl As DataTable

                Consulta_sql = "Select Cast(1 As Bit) As Chk, Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo = '" & TxtCodigo.Text & "' And Producto = 0"
                _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

                Dim Fm As New Frm_Arbol_Asociacion_05_Busqueda(
                Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos, True) 'Frm_Arbol_Asociacion_03_buscar("")
                'Fm.Pro_Seleccion_Solo_Seleccionables = True
                Fm.Pro_Seleccionar_Todo = False
                Fm.Pro_Tbl_Nodos_Seleccionados = _Tbl
                Fm.Text = "Busqueda de carpetas"

                Fm.ShowDialog(Me)
                Dim _Row_Nodo_Seleccionado As DataRow = Fm.Pro_Row_Nodo_Seleccionado ' = Fm._Tbl_Nodo_Seleccionado
                Dim _Tbl_Nodos_Seleccionados As DataTable = Fm.Pro_Tbl_Nodos_Seleccionados
                _Aceptar = Fm.Pro_Aceptar
                Fm.Dispose()

                If _Aceptar Then

                    Sb_Grabar_Arbol(_Tbl_Nodos_Seleccionados)

                    'Dim _Nodos As String = Generar_Filtro_IN(_Tbl_Nodos_Seleccionados, "Chk", "Codigo_Nodo", False, True, "")

                    'If _Nodos = "()" Then
                    '    _Tbl_Nodos_Seleccionados = Nothing
                    'Else
                    '    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo In " & _Nodos
                    '    _Tbl_Nodos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)
                    'End If

                    'Dim _Sql_Crear_Arbol = String.Empty

                    'If _Tbl_Nodos_Seleccionados Is Nothing Then

                    '    _Sql_Crear_Arbol = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf & _
                    '                       "Where Codigo = '" & TxtCodigo.Text & "'" & vbCrLf & _
                    '                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Clas_Unica_X_Producto = 0) And Clas_unica = 0"

                    'Else
                    '    Consulta_sql = "Select KOPR As Codigo, NOKOPR as Descripcion From MAEPR Where KOPR = '" & TxtCodigo.Text & "'"
                    '    Dim _Tbl_Producto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    '    Dim _Clas_Nodo As New Clas_Arbol_Asociaciones(Me)


                    '    _Sql_Crear_Arbol = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf & _
                    '                       "Where Codigo = '" & TxtCodigo.Text & "'" & vbCrLf & _
                    '                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Clas_Unica_X_Producto = 0) And Clas_unica = 0" & _
                    '                       vbCrLf & _
                    '                       vbCrLf & _
                    '                       "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro)" & vbCrLf & _
                    '                       "Select '" & TxtCodigo.Text & "',Codigo_Nodo,Descripcion,1" & vbCrLf & _
                    '                       "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf & _
                    '                       "Where Codigo_Nodo IN " & _Nodos & vbCrLf & vbCrLf

                    '    For Each _Fila As DataRow In _Tbl_Nodos_Seleccionados.Rows

                    '        Dim _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
                    '        Dim _Descripcion = _Fila.Item("Descripcion")

                    '        _Sql_Crear_Arbol += _Clas_Nodo.Fx_Crear_Arbol_de_productos(_Codigo_Nodo, _Codigo_Nodo) & vbCrLf

                    '    Next

                    'End If

                    '_Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Sql_Crear_Arbol)

                End If

            End If

        Catch ex As Exception

        Finally
            If _Aceptar Then Sb_Actualizar_Grilla()
            Me.Enabled = True
        End Try

    End Sub

    Sub Sb_Grabar_Arbol(_Tbl_Nodos_Seleccionados As DataTable)

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim _Cn As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Nodos As String = Generar_Filtro_IN(_Tbl_Nodos_Seleccionados, "Chk", "Codigo_Nodo", False, True, "")

        If _Nodos = "()" Then
            _Tbl_Nodos_Seleccionados = Nothing
        Else
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo In " & _Nodos
            _Tbl_Nodos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If


        If _Tbl_Nodos_Seleccionados Is Nothing Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo = '" & TxtCodigo.Text & "'" & vbCrLf &
                            "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Clas_Unica_X_Producto = 0) And Clas_unica = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        Else

            Consulta_sql = "Select KOPR As Codigo, NOKOPR as Descripcion From MAEPR Where KOPR = '" & TxtCodigo.Text & "'"
            Dim _Tbl_Producto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Clas_Nodo As New Clas_Arbol_Asociaciones(Me)

            Try

                Me.Cursor = Cursors.WaitCursor

                _Sql.Sb_Abrir_Conexion(_Cn)
                myTrans = _Cn.BeginTransaction()

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo = '" & TxtCodigo.Text & "'" & vbCrLf &
                               "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Clas_Unica_X_Producto = 0) And Clas_unica = 0" &
                               vbCrLf &
                               vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro)" & vbCrLf &
                               "Select '" & TxtCodigo.Text & "',Codigo_Nodo,Descripcion,1" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                               "Where Codigo_Nodo IN " & _Nodos & vbCrLf & vbCrLf


                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()


                For Each _Fila As DataRow In _Tbl_Nodos_Seleccionados.Rows

                    Dim _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
                    Dim _Descripcion = _Fila.Item("Descripcion")

                    Consulta_sql = _Clas_Nodo.Fx_Crear_Arbol_de_productos(_Codigo_Nodo, _Codigo_Nodo) & vbCrLf

                    Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next


                '**********************************'**********************************

                myTrans.Commit()
                _Sql.Sb_Cerrar_Conexion(_Cn)

            Catch ex As Exception
                myTrans.Rollback()
                MsgBox(ex.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If

    End Sub



    Private Sub BtnAsociaciones_arbol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsociaciones_arbol.Click

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where Codigo = '" & TxtCodigo.Text & "' And Producto = 0" & vbCrLf &
                       "And Codigo_Nodo In" & Space(1) &
                       "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Seleccionable = 1)"

        Dim _TblNodos_Hijos_Asociados As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _TblNodos_Hijos_Asociados.Rows.Count Then

            Dim _Clas_Nodo As New Clas_Arbol_Asociaciones(Me)

            'Consulta_sql = "Select Top 1 KOPR as Codigo From MAEPR Where KOPR = '" & TxtCodigo.Text & "'"
            'Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Sql_Crear_Arbol = String.Empty

            For Each _Fila As DataRow In _TblNodos_Hijos_Asociados.Rows

                Dim _Codigo_Nodo = _Fila.Item("Codigo_Nodo")

                _Sql_Crear_Arbol += "Delete BAKAPP_SG.dbo.Zw_Prod_Asociacion" & vbCrLf &
                                    "Where Codigo = '" & TxtCodigo.Text & "'" & vbCrLf &
                                    "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                                    "Where Es_Seleccionable = 0) And Clas_unica = 0" & vbCrLf & vbCrLf

                _Sql_Crear_Arbol += _Clas_Nodo.Fx_Crear_Arbol_de_productos(_Codigo_Nodo, _Codigo_Nodo) & vbCrLf

            Next

            Sb_Actualizar_Grilla()

        End If
    End Sub

    Private Sub Btn_VerArbol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_VerArbol.Click

        Consulta_sql = "Select Codigo_Nodo,Identificacdor_NodoPadre,Descripcion" & vbCrLf &
                            "FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                            "Where Codigo_Nodo in (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo = '" & TxtCodigo.Text & "' And Nodo_origen <> 0)"


        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                                    "Codigo = '" & TxtCodigo.Text & "' And Para_filtro = 1"))

        If _Reg Then

            Dim Fm As New Frm_Arbol_Asociacion_01
            Fm.Pro_CheckBoxes_Nodos = False
            Fm.Pro_Codigo_Producto = Trim(TxtCodigo.Text)
            Fm.Chk_Ver_Clas_Unicas.Checked = True
            Fm.ShowDialog(Me)
            Sb_Actualizar_Grilla()

        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISTE INFORMACION", My.Resources.cross,
                                 2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If
    End Sub

    Private Sub Btn_Copiar_Arbol_Hijos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar_Arbol_Hijos.Click

        If CBool(Grilla_Clasificaciones.Rows.Count) Then

            If MessageBoxEx.Show(Me, "Esto cambiara las clasificaciones de los productos seleccionados." & vbCrLf &
                                 "Se borraran las clasificaciones (*) que estos tienen y seran" & vbCrLf &
                                 "reemplazadas por las clasificaciones el producto activo" & vbCrLf & vbCrLf &
                                 "¿Desea seguir adelante con la gestión?" & vbCrLf & vbCrLf &
                                 "(*) NO APLICA PARA CLASIFICACIONES UNICAS",
                                 "Información importante",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                Dim _TblProductos_Hnos As DataTable


                Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'And ATPR = '' And KOPR <> '" & TxtCodigo.Text & "'"

                Dim _Filtrar As New Clas_Filtros_Random(Me)

                If _Filtrar.Fx_Filtrar(Nothing,
                                       Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                                       False, False) Then

                    If _Filtrar.Pro_Filtro_Todas Then
                        MessageBoxEx.Show(Me, "No puede seleccionar todos los productos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        _TblProductos_Hnos = _Filtrar.Pro_Tbl_Filtro
                    End If

                End If


                'Dim Fm_fl As New Frm_Filtro_Tabla_Seleccion

                'Fm_fl.Pro_Tabla_Filtro = Frm_Filtro_Tabla_Seleccion._Select_Tabla._Maestro_Productos
                ''Fm_fl.Pro_TablaG2 = Nothing '_Tbl_Productos_En_Carpeta
                ' Fm_fl.Text = "SELECCIONAR PRODUCTOS"
                'Fm_fl.Pro_Condicion_Adicional = "And KOPR <> '" & TxtCodigo.Text & "'"
                'Fm_fl.ShowDialog(Me)



                If Not (_TblProductos_Hnos Is Nothing) Then

                    '_TblProductos_Hnos = Fm_fl.Pro_TablaG2
                    Consulta_sql = String.Empty

                    For Each _Fila As DataRow In _TblProductos_Hnos.Rows

                        Dim _CodigoReemplazo = _Fila.Item("Codigo")

                        If Trim(TxtCodigo.Text) <> Trim(_CodigoReemplazo) Then
                            Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & _CodigoReemplazo & "'  And Producto = 0" & vbCrLf &
                                            "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Clas_Unica_X_Producto = 0)" & vbCrLf & vbCrLf &
                                            "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro,Nodo_origen,Clas_unica,Producto)" & vbCrLf &
                                            "Select '" & _CodigoReemplazo & "',Codigo_Nodo,DescripcionBusqueda,Para_filtro,Nodo_origen,Clas_unica,Producto" & vbCrLf &
                                            "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                            "Where Codigo = '" & TxtCodigo.Text & "' And Producto = 0" & vbCrLf &
                                            "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Clas_Unica_X_Producto = 0)" & vbCrLf & vbCrLf
                        End If

                    Next

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        MessageBoxEx.Show(Me, "Datos actualizados correctamente",
                                          "Copiar clasificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If
            End If
        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISTE INFORMACION", My.Resources.cross,
                                 2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Btn_Agregar_Clas_Especial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Clas_Especial.Click

        Dim _Aceptado As Boolean
        Dim _Nueva_Clasificacion As String

        _Aceptado = InputBox_Bk(Me, "Ej. código de articulo, etc...",
                                "Ingrese una nueva clasificación.", _Nueva_Clasificacion, False, _Tipo_Mayus_Minus.Mayusculas, , True,
                                _Tipo_Imagen.Texto)

        If _Aceptado Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion " &
                           "(Codigo,Codigo_Nodo,DescripcionBusqueda,Clas_unica) Values " & vbCrLf &
                           "('" & TxtCodigo.Text & "',0,'" & UCase(_Nueva_Clasificacion) & "',1)"

            _Sql.Ej_consulta_IDU(Consulta_sql)
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Mnu_Btn_Eliminar_Clas_Especial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Btn_Eliminar_Clas_Especial.Click

        Dim _Pregunta_Elimina As Boolean = True

        'If Fx_Tiene_Permiso(Me, "Prod023") Then

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta clasificación?", "Eliminar clasificación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim _Fila As DataGridViewRow = Grilla_Clasificaciones.Rows(Grilla_Clasificaciones.CurrentRow.Index)

            Dim _Id = _Fila.Cells("Id").Value
            Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Grilla_Clasificaciones.Rows.RemoveAt(Grilla_Clasificaciones.CurrentRow.Index)

            ToastNotification.Show(Me, "CLASIFICACION ELIMINADA CORRECTAMENTE", My.Resources.ok_button,
                          1 * 1000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Grilla_Clasificaciones.Focus()

        End If
        'End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla_Clasificaciones.Rows(Grilla_Clasificaciones.CurrentRow.Index)

                    Dim _Clas_unica As Boolean = CBool(_Fila.Cells("Clas_unica").Value)

                    If _Clas_unica Then
                        ShowContextMenu(Menu_Contextual_01)
                    End If

                End If
            End With
        End If
    End Sub

    Private Sub Mnu_Btn_Editar_Clas_Especial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Btn_Editar_Clas_Especial.Click

        Dim _Fila As DataGridViewRow = Grilla_Clasificaciones.Rows(Grilla_Clasificaciones.CurrentRow.Index)
        Dim _Full_Path = _Fila.Cells("Full_Path").Value
        Dim _Id = _Fila.Cells("Id").Value
        Dim _Aceptado As Boolean

        Dim _Nueva_Clasificacion As String = _Full_Path

        _Aceptado = InputBox_Bk(Me, "Ej. código de articulo, etc...",
                               "Ingrese una nueva clasificación.", _Nueva_Clasificacion, False,
                               _Tipo_Mayus_Minus.Mayusculas, , True, _Tipo_Imagen.Texto)

        If _Aceptado Then
            If _Full_Path <> _Nueva_Clasificacion Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Asociacion " &
                               "Set DescripcionBusqueda = '" & _Nueva_Clasificacion & "' Where Id = " & _Id
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    _Fila.Cells("Full_Path").Value = _Nueva_Clasificacion
                    ToastNotification.Show(Me, "Datos actualizados correctamente", My.Resources.ok_button,
                             1 * 1000, eToastGlowColor.Green, eToastPosition.TopCenter)
                End If
            End If
        End If

    End Sub

    Private Sub Btn_Asociaciones_Unicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Asociaciones_Unicas.Click
        If Fx_Tiene_Permiso(Me, "Tbl00002") Then

            Clipboard.SetText(TxtCodigo.Text)
            Dim Fm As New Frm_Arbol_Asociacion_02(False, 0, False, Frm_Arbol_Asociacion_02.Enum_Clasificacion.Unica, 0)
            Fm.Pro_Identificador_NodoPadre = 0
            Fm.Pro_Codigo_Heredado = TxtCodigo.Text
            Fm.ShowDialog(Me)
            Fm.Dispose()
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Sub Sb_VerProductos_X_Class(ByVal _Fila As DataRow,
                                Optional ByVal _Mostrar_Productos_Sin_Asociacion_En_Nodo As Boolean = False)

        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Identificador_NodoPadre As Integer = _Fila.Item("Identificacdor_NodoPadre")
        Dim _Es_Padre = _Fila.Item("Es_Padre")
        Dim _Es_Seleccionable = _Fila.Item("Es_Seleccionable")
        Dim _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
        Dim _Descripcion = _Fila.Item("Descripcion")

        Dim Fm As New Frm_Arbol_Asociacion_04_Productos_x_class(_Identificador_NodoPadre,
                                                                _Codigo_Nodo,
                                                                _Descripcion,
                                                                "...\" & _Descripcion,
                                                                _Es_Seleccionable,
                                                                True,
                                                                _Mostrar_Productos_Sin_Asociacion_En_Nodo)

        Fm.Text = "Clasificación: (Cod. " & _Codigo_Nodo & ") " & _Descripcion

        If _Es_Padre Then
            Fm.Btn_AgregarProductos.Enabled = False
            Fm.Btn_Reparar_Arbol.Enabled = False
        End If

        Fm.ShowDialog(Me)

        '_Fila.Cells("Prod_Ass").Value = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", _
        '                                                         "Codigo_Nodo = " & _Codigo_Nodo)

        If Fm.Pro_Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Frm_MtCreaProd_01_IngBusqEspecial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If String.IsNullOrEmpty(Trim(TxtDescripcion.Text)) Then

            Beep()
            ToastNotification.Show(Me, "LA DESCRIPCION NO PUEDE ESTAR VACIA", My.Resources.cross,
                                 2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            TxtDescripcion.Focus()
            e.Cancel = True

        Else

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set DescripcionBusqueda = " &
                            "'" & TxtCodigo.Text & " " & TxtDescripcion.Text & "'" & vbCrLf &
                            "Where Codigo = '" & TxtCodigo.Text & "' And Producto = 1" & vbCrLf &
                            "Update MAEPR Set NOKOPR = '" & TxtDescripcion.Text & "' Where KOPR = '" & TxtCodigo.Text & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub


End Class
