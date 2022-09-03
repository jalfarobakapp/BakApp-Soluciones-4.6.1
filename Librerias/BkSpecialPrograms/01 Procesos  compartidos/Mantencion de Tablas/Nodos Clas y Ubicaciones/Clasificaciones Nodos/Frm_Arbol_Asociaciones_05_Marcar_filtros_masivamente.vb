Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblFiltroProductos As DataTable
    Dim _Procesar_toda_la_matriz As Boolean
    Dim _Codigo_Nodo As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnGenerar.ForeColor = Color.White
        End If

    End Sub

    Public Property Pro_TblFiltroProductos As DataTable
        Get
            Return _TblFiltroProductos
        End Get
        Set(value As DataTable)
            _TblFiltroProductos = value
        End Set
    End Property

    Public Property Pro_Procesar_toda_la_matriz As Boolean
        Get
            Return _Procesar_toda_la_matriz
        End Get
        Set(value As Boolean)
            _Procesar_toda_la_matriz = value
        End Set
    End Property

    Public Property Pro_Codigo_Nodo As Integer
        Get
            Return _Codigo_Nodo
        End Get
        Set(value As Integer)
            _Codigo_Nodo = value
        End Set
    End Property

    Public Sub Sb_Generar_matriz_clasificacion(ByVal _TblFiltroProductos As DataTable,
                                               ByVal _Codigo_Nodo As Integer,
                                               ByVal Progreso_Porc As Object,
                                               ByVal Progreso_Cont As Object,
                                               ByVal LblEstado As Object)

        Dim _Descripcion_Nodo As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion", "Codigo_Nodo = " & _Codigo_Nodo)

        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = _TblFiltroProductos.Rows.Count

        Sb_AddToLog("Iniciando Analisis", "-----------------------------------------", TxtLog, False)

        Dim Contador As Integer = 0

        For Each _Fila As DataRow In _TblFiltroProductos.Rows

            If _Fila.RowState <> DataRowState.Deleted Then
                System.Windows.Forms.Application.DoEvents()

                Dim _Codigo As String = _Fila.Item("Codigo")
                Dim _Descripcion As String = _Fila.Item("Descripcion")

                LblEstado.Text = "Procesando " & Contador & " de " & _TblFiltroProductos.Rows.Count & ",Producto: " & _Descripcion
                _Sql.Ej_consulta_IDU(Consulta_sql)

                'Dim Fm As New Frm_Arbol_Asociacion_03_buscar(_Codigo)
                'Fm.Sb_Llenar_Arbol_completo(_Codigo)

                Consulta_sql = "SELECT * FROM Zw_Prod_Asociacion Zw_Pr Where Codigo = '" & _Codigo & "'"
                Dim _Tbl_Clasificaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                'Fm.Sb_Crear_Descrip_busqueda(_Codigo, _Descripcion, _Tbl_Clasificaciones)
                'Fm.Dispose()

                Sb_AddToLog("Producto: " & _Codigo & "," & _Descripcion, "Listo", TxtLog, False)

                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / _TblFiltroProductos.Rows.Count) 'Mas
                Progreso_Cont.Value += 1

            End If

        Next

        'Exit Function
        LblEstado.Text = "Proceso terminado"
        Sb_AddToLog("Proceso terminado", "-----------------------------------------", TxtLog, False)

        System.Windows.Forms.Application.DoEvents()

        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0


    End Sub



    Function Fx_Raiz_Clasificacion_FullPath(ByVal _Codigo_Nodo As String)

        Dim _Full As String = String.Empty
        Dim _CodPadre As String

        Consulta_sql = "Select * From Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")

        Do While (_CodPadre <> 0)

            Consulta_sql = "Select * From Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _CodPadre
            _Tbl = _SQL.Fx_Get_Tablas(Consulta_sql)

            _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")
            _Full = "\" & _Tbl.Rows(0).Item("Descripcion") & _Full

        Loop

        Return _Full

    End Function

    Private Sub Btn_ImportarClasificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ImportarListado.Click

        Dim _OpenFile As New OpenFileDialog
        Dim _Lista_Productos_Arr

        With _OpenFile
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            '.ShowDialog(Me)
            Dim _Resultado = .ShowDialog(Me)
            Dim _Nombre_Archivo As String

            If _Resultado = Windows.Forms.DialogResult.OK Then
                _Nombre_Archivo = .SafeFileName
                _Nombre_Archivo = .FileName
            Else
                Return
            End If

            Dim _ImpEx As New Class_Importar_Excel
            Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")

            _Lista_Productos_Arr = _ImpEx.Importar_Excel_Array(_Nombre_Archivo, _Extencion, 0)

        End With


        If _Lista_Productos_Arr Is Nothing Then
            Return
        Else
            Bar2.Enabled = False
            Sb_Clasificar_filtros_masivamente_x_producto(_Lista_Productos_Arr)
            Bar2.Enabled = True
        End If


    End Sub


    Sub Sb_Clasificar_filtros_masivamente_x_producto(ByVal _Lista_Productos_Arr As Object)

        Dim Filas = _Lista_Productos_Arr.GetUpperBound(0)
        Dim RegInsert As Long = 0

        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = Filas
        Dim Contador As Integer = 0

        Consulta_sql = String.Empty

        Sb_AddToLog("Iniciando proceso paso 1 de 3", "Insertando productos  -----------------------------------------", TxtLog, True)

        Dim _SQl_ As String = String.Empty

        Dim _Filas_Buenas = 0
        Dim _Filas_Malas = 0

        For i = 1 To Filas

            System.Windows.Forms.Application.DoEvents()
            Dim _Mala As Boolean = False

            Dim _Codigo = _Lista_Productos_Arr(i, 0)
            Dim _Descripcion_clas = _Lista_Productos_Arr(i, 1)


            Consulta_sql = "Select NOKOPR From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _TblProducto As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)
            Dim _Descripcion_pro As String = "Producto no existe"

            If CBool(_TblProducto.Rows.Count) Then
                _Descripcion_pro = _TblProducto.Rows(0).Item("NOKOPR")
            Else
                _Mala = True
                Sb_AddToLog("Fila : " & i & ",Código: " & _Codigo,
                            "Producto no existe", TxtLog, False)
            End If


            Dim _Codigo_Nodo As String

            Consulta_sql = "Select Codigo_Nodo From Zw_TblArbol_Asociaciones" & vbCrLf &
                           "Where Descripcion = '" & _Descripcion_clas & "'"
            Dim _TblClass As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)


            If CBool(_TblClass.Rows.Count) Then
                _Codigo_Nodo = _TblClass.Rows(0).Item("Codigo_Nodo")
            Else
                _Mala = True
                Sb_AddToLog("Producto: " & _Codigo & "," & _Descripcion_pro,
                            "Clasificación: No existe Clasificación, " & _Descripcion_clas, TxtLog, False)
            End If


            If _Mala Then
                _Filas_Malas += 1
            Else

                _SQl_ += "Delete Zw_Prod_Asociacion Where Codigo = '" & _Codigo & "' And Codigo_Nodo =" & _Codigo_Nodo & vbCrLf &
                         "Insert Into Zw_Prod_Asociacion " &
                         "(Codigo,Codigo_Nodo,DescripcionBusqueda) Values " & vbCrLf &
                         "('" & _Codigo & "'," & _Codigo_Nodo & ",'" & _Descripcion_clas & "')" & vbCrLf

                _Filas_Buenas += 1

            End If


            LblEstado_1.Text = "Procesando " & Contador & " de " & Filas &
                               ", Filas buenas: " & _Filas_Buenas & ", Filas malas: " & _Filas_Malas
            LblEstado_1.Text = "Producto " & Contador & " de " & Filas & ",Producto: " & _Descripcion_pro

            Contador += 1
            Progreso_Porc.Value = ((Contador * 100) / Filas)
            Progreso_Cont.Value += 1

        Next

        LblEstado_1.Text = "Proceso terminado paso 1"
        LblEstado_2.Text = String.Empty
        Sb_AddToLog("Proceso terminado paso 1", "-----------------------------------------", TxtLog, True)

        System.Windows.Forms.Application.DoEvents()

        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0

        If CBool(_Filas_Malas) Then


            MessageBoxEx.Show(Me, "Existen " & _Filas_Malas & " filas con problemas" & vbCrLf &
                                 "a continuación la lista de ellas, pero el sistema igualmente continuara" & vbCrLf &
                                 "trabajando con las filas buenas " & _Filas_Buenas, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Warning)




            CrearArchivoTxt(AppPath() & "\Data\" & RutEmpresa & "\Clasificaciones_prod\",
                            "Error_LevClasificaciones.txt", TxtLog.Text, False)

            TxtLog.Text = String.Empty
            Process.Start("notepad.exe",
                          AppPath() & "\Data\" & RutEmpresa & "\Clasificaciones_prod\Error_LevClasificaciones.txt")


        End If

        If CBool(_Filas_Buenas) Then

            MessageBoxEx.Show(Me, "Ahora se procederá a levantar la información" & vbCrLf &
                                  "Este proceso puede ser demoroso, ya que se levantaran las clasificaciones por cada producto" & vbCrLf &
                                  "y luego se creara el árbol correspondiente a la clasificación de cada articulo" & vbCrLf &
                                  "y también el algoritmo de búsqueda independiente de cada uno",
                                  "Levantar clasificación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            System.Windows.Forms.Application.DoEvents()
            Sb_AddToLog("Iniciando proceso paso 2 de 3", "Levantar clasificaciones -----------------------------------------", TxtLog, True)
            Sb_AddToLog("Paso 2", "Insertando información en la base de datos ...", TxtLog, False)

            _Sql.Ej_consulta_IDU(Consulta_sql)


            Sb_AddToLog("Iniciando proceso paso 3 de 3", "Crear árbol y clasificación de búsqueda por producto-------------", TxtLog, True)
            Sb_AddToLog("Paso 3", "Insertando información en la base de datos ...", TxtLog, False)

            Sb_Generar_Arbol_completo()

            'Sb_Recrear_todo_el_arbol_de_productos(LblEstado_2)


        End If


    End Sub


    Sub Sb_Recrear_todo_el_arbol_de_productos(ByVal LblEstado As Object)

        Consulta_sql = "Select Codigo_Nodo,Descripcion From Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Es_Padre = 0" & vbCrLf &
                       "Order by Descripcion"

        Dim _TblClass As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)
        Dim _Descripcion_Nodo As String

        Dim _i = 1
        For Each _Fila As DataRow In _TblClass.Rows

            _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
            _Descripcion_Nodo = _Fila.Item("Descripcion")
            System.Windows.Forms.Application.DoEvents()
            Consulta_sql = "SELECT  Codigo,Isnull((Select Top 1 NOKOPR From MAEPR Where KOPR = Codigo),'') as Descripcion" & vbCrLf &
                     "FROM Zw_Prod_Asociacion" & vbCrLf &
                     "Where Codigo_Nodo = " & _Codigo_Nodo & " And Para_filtro = 0 And Clas_unica = 0" & vbCrLf &
                     "Order by Codigo"
            Dim _TblProducto As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

            Sb_AddToLog("Paso 3", "Analizando Claisficación: " & _Descripcion_Nodo & vbCrLf &
                        "Productos encontrados: " & _TblProducto.Rows.Count, TxtLog, True)
            LblEstado.Text = "Revisando Clasificación: " & _Descripcion_Nodo & ", Fila: " & _i & " de " & _TblClass.Rows.Count
            If CBool(_TblProducto.Rows.Count) Then
                Sb_Generar_matriz_clasificacion(_TblProducto, _Codigo_Nodo, Progreso_Porc, Progreso_Cont, LblEstado_1)
            End If

            _i += 1

        Next
        Sb_AddToLog("Paso 3", "Proceso terminado completamente...", TxtLog, True)
    End Sub


    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Sb_Generar_Arbol_completo()
    End Sub

    Sub Sb_Generar_Arbol_completo()

        Dim _TblNodos As DataTable

        Consulta_sql = "SELECT Distinct Zw1.Codigo_Nodo," &
                       "(Select Descripcion" & vbCrLf &
                       "From Zw_TblArbol_Asociaciones Zw2 Where Zw2.Codigo_Nodo = Zw1.Codigo_Nodo) As Descripcion" & vbCrLf &
                       "FROM Zw_Prod_Asociacion Zw1" & vbCrLf &
                       "Where Zw1.Codigo_Nodo in (Select Codigo_Nodo from Zw_TblArbol_Asociaciones Where Es_Padre = 0)"
        _TblNodos = _SQL.Fx_Get_Tablas(Consulta_sql)


        'Barra_Progreso_.Maximum = 100

        Dim Contador As Integer = 0

        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = _TblNodos.Rows.Count

        For Each _Fila As DataRow In _TblNodos.Rows

            Dim _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
            Dim _Descripcion = _Fila.Item("Descripcion")

            Dim _TblProductos As DataTable
            Consulta_sql = "SELECT Distinct Codigo FROM Zw_Prod_Asociacion" & vbCrLf &
                           "Where Codigo_Nodo = " & _Codigo_Nodo

            _TblProductos = _SQL.Fx_Get_Tablas(Consulta_sql)

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", "Codigo", False, False, "'")
            Dim _Descripcion_Busqueda As String = Fx_Raiz_Clasificacion_FullPath(_Codigo_Nodo) & "\" & _Descripcion

            LblEstado_1.Text = "Creando árbol de: " & _Descripcion
            LblEstado_2.Text = "Directorio: " & _Descripcion_Busqueda & "\" & _TblProductos.Rows.Count & " productos"

            Sb_Guardar(Me, _TblProductos, _Codigo_Nodo, _Descripcion, Barra_Progreso_)
            Sb_AddToLog(LblEstado_2.Text, "Creando árbol", TxtLog, False)

            Contador += 1
            Progreso_Porc.Value = ((Contador * 100) / _TblNodos.Rows.Count)
            Progreso_Cont.Value += 1

        Next

        Beep()
        ToastNotification.Show(Me, "DATOS GUARDADOS CORRECTAMENTE",
                                    My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0

    End Sub

    Function Fx_Borrar_Registro(ByVal _Codigo As String,
                                ByVal _Codigo_Nodo As String,
                                ByVal _Sql_Borra As String) As String


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                       "Where Codigo = '" & _Codigo & "' And Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Row_Producto Is Nothing) Then

            _Sql_Borra = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                          "Where Codigo = '" & _Codigo & "' And Codigo_Nodo = " & _Codigo_Nodo & vbCrLf

            Dim _Nodo_Padre As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                           "Identificacdor_NodoPadre", "Codigo_Nodo = " & _Codigo_Nodo, True)

            If CBool(_Nodo_Padre) Then

                Consulta_sql = "Select *" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo = '" & _Codigo & "' And Codigo_Nodo In (Select Codigo_Nodo" & Space(1) &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                               "Where Codigo_Nodo <> " & _Codigo_Nodo & " And Identificacdor_NodoPadre = " & _Nodo_Padre & ")"
                Dim _TblPadres As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If Not CBool(_TblPadres.Rows.Count) Then
                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & _Codigo & "'"
                    _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)
                    _Sql_Borra += Fx_Borrar_Registro(_Codigo, _Nodo_Padre, "")
                End If

            End If

        End If

        Return _Sql_Borra

    End Function

    Public Sub Sb_Guardar(ByVal _Formulario As Form,
                          ByVal _TblFiltroProductos As DataTable,
                          ByVal _Codigo_Nodo As String,
                          ByVal _Descripcion_Nodo As String,
                          Optional ByVal _Barra_Progreso_ As Object = Nothing,
                          Optional ByVal _Mostrar_Notificacion As Boolean = False,
                          Optional ByVal _Pedir_Permiso As Boolean = True)


        Dim _Filtro_Productos As String

        If _TblFiltroProductos.Rows.Count Then
            _Filtro_Productos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")
            _Filtro_Productos = "And Codigo Not In " & _Filtro_Productos
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where Codigo_Nodo = " & _Codigo_Nodo & Space(1) & _Filtro_Productos

        Dim _TblAsociaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Sql_Query = String.Empty

        If _TblAsociaciones.Rows.Count Then
            For Each _Fila As DataRow In _TblAsociaciones.Rows
                Dim _Codigo = _Fila.Item("Codigo")
                _Sql_Query += Fx_Borrar_Registro(_Codigo, _Codigo_Nodo, "")
            Next
        End If

        If Not String.IsNullOrEmpty(_Sql_Query) Then
            _Sql.Ej_consulta_IDU(_Sql_Query)
        End If





        If _TblFiltroProductos.Rows.Count Then
            _Filtro_Productos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")

            Consulta_sql = "Select KOPR As Codigo,NOKOPR From MAEPR Where KOPR In " & _Filtro_Productos & vbCrLf &
                           "And KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = " & _Codigo_Nodo & ")"

            _TblFiltroProductos = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

        If _TblFiltroProductos.Rows.Count Then

            _Filtro_Productos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")
            '_Filtro_Productos = "And Codigo Not In " & _Filtro_Productos

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro)" & vbCrLf &
                           "Select KOPR,'" & _Codigo_Nodo & "','" & _Descripcion_Nodo & "',1" & vbCrLf &
                           "From MAEPR " & vbCrLf &
                           "WHERE KOPR IN " & _Filtro_Productos & vbCrLf & vbCrLf

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Consulta_sql = "Select distinct Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "WHERE Codigo IN " & _Filtro_Productos & vbCrLf &
                               "And Codigo_Nodo in (Select Codigo_Nodo from " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Padre = 0)"

                Dim _TblNodos As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

                Dim _Sql2 As String = String.Empty

                If Not _Barra_Progreso_ Is Nothing Then
                    _Barra_Progreso_.Maximum = 100
                End If

                Dim Contador As Integer = 0


                For Each _Fila As DataRow In _TblNodos.Rows

                    System.Windows.Forms.Application.DoEvents()
                    Dim _Cod_Nodo As String = _Fila.Item("Codigo_Nodo")
                    Dim _Identificacdor_NodoPadre As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                             "Identificacdor_NodoPadre", "Codigo_Nodo = " & _Cod_Nodo)

                    _Sql2 += Fx_Crear_Arbol_de_productos(_Cod_Nodo, _Cod_Nodo) & vbCrLf & vbCrLf &
                             "-------------------" & vbCrLf & vbCrLf

                    Contador += 1
                    If Not _Barra_Progreso_ Is Nothing Then
                        _Barra_Progreso_.Value = ((Contador * 100) / _TblNodos.Rows.Count)
                        _Barra_Progreso_.Text = Barra_Progreso_.Value
                    End If
                Next

                If Not _Barra_Progreso_ Is Nothing Then
                    _Barra_Progreso_.Value = 0
                End If

                _Sql.Ej_consulta_IDU(_Sql2)

            End If

        End If


        If _Mostrar_Notificacion Then
            Beep()
            ToastNotification.Show(_Formulario, "DATOS GUARDADOS CORRECTAMENTE",
                                        My.Resources.ok_button,
                                       2 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
        End If

    End Sub

    Function Fx_Crear_Arbol_de_productos(ByVal _Cod_Nodo_Origen As String,
                                         ByVal _Codigo_Nodo As String,
                                         Optional ByVal _Consulta_Sql As String = "")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _TblNodo As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Dim _Identificacdor_NodoPadre = _TblNodo.Rows(0).Item("Identificacdor_NodoPadre")
        Dim _Descripcion_Nodo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion", "Codigo_Nodo = " & _Identificacdor_NodoPadre)

        If CBool(_Identificacdor_NodoPadre) Then
            _Consulta_Sql += "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro)" & vbCrLf &
                        "Select KOPR,'" & _Identificacdor_NodoPadre & "','" & _Descripcion_Nodo & "',1" & vbCrLf &
                        "From MAEPR" & vbCrLf &
                        "WHERE KOPR IN" & vbCrLf &
                        "(SELECT Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion " & vbCrLf &
                        "Where Codigo_Nodo = '" & _Codigo_Nodo & "' and " & vbCrLf &
                        "Codigo not in (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = '" & _Identificacdor_NodoPadre & "' ))" & vbCrLf & vbCrLf
        End If

        If CBool(_TblNodo.Rows.Count) Then

            _Codigo_Nodo = _TblNodo.Rows(0).Item("Identificacdor_NodoPadre")

            Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Codigo_Nodo = " & _Codigo_Nodo)

            If _Reg Then
                _Consulta_Sql = Fx_Crear_Arbol_de_productos(_Cod_Nodo_Origen,
                                                            _Codigo_Nodo, _Consulta_Sql)

            End If

        End If

        Return _Consulta_Sql

    End Function

    Private Sub Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
