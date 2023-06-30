Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Cl_Prestashop_Web

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Procesando As Boolean
    Dim _Fecha_Revision As Date
    Dim _Nombre_Equipo As String
    Dim _Ejecucion_Total As Boolean
    Dim _Prestashop_Total_Ejecudato As Boolean

    Dim _Etiqueta2 As New LabelX

    Public Property Procesando As Boolean
        Get
            Return _Procesando
        End Get
        Set(value As Boolean)
            _Procesando = value
        End Set
    End Property

    Public Property Fecha_Revision As Date
        Get
            Return _Fecha_Revision
        End Get
        Set(value As Date)
            _Fecha_Revision = value
        End Set
    End Property

    Public Property Lbl_Estado As String
        Get
            Return _Etiqueta2.Text
        End Get
        Set(value As String)
            _Etiqueta2.Text = value
        End Set
    End Property

    Public Property Nombre_Equipo As String
        Get
            Return _Nombre_Equipo
        End Get
        Set(value As String)
            _Nombre_Equipo = value
        End Set
    End Property

    Public Property Prestashop_Total_Ejecudato As Boolean
        Get
            Return _Prestashop_Total_Ejecudato
        End Get
        Set(value As Boolean)
            _Prestashop_Total_Ejecudato = value
        End Set
    End Property

    Public Property Etiqueta2 As LabelX
        Get
            Return _Etiqueta2
        End Get
        Set(value As LabelX)
            _Etiqueta2 = value
        End Set
    End Property

    Public Property Log_Registro As String
    Public Property Ejecutar As Boolean
    Public Sub New()

        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True

    End Sub

    Sub Sb_Iniciar(Ejecucion_Total As Boolean)

        _Procesando = True
        _Ejecucion_Total = Ejecucion_Total
        _BackgroundWorker.RunWorkerAsync()

    End Sub

    Sub Sb_Detener()

        If _BackgroundWorker.IsBusy Then
            _BackgroundWorker.CancelAsync()
        End If

    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        Try
            If _Ejecucion_Total Then
                Sb_Procedimiento_Prestashop2(True)
                _Prestashop_Total_Ejecudato = True
            Else
                Sb_Procedimiento_Prestashop()
                Sb_Procedimiento_Prestashop2(False)
                _Prestashop_Total_Ejecudato = False
            End If

        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged
        'Lbl_Progreso.Text = (e.ProgressPercentage.ToString() & "%")
        'ProgressBarItem1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

        If e.Cancelled = True Then
            'Lbl_Progreso.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            'Lbl_Progreso.Text = "Error: " & e.[Error].Message
        Else
            'Lbl_Progreso.Text = "Done!"
            'If _BackgroundWorker.IsBusy <> True Then
            '_BackgroundWorker.RunWorkerAsync()
            'End If
        End If

        _Procesando = False
        _Ejecucion_Total = False
        _Etiqueta2.Text = "Prestashop"
        '_CirProgress.Visible = False

    End Sub

    Sub Sb_Procedimiento_Prestashop()

        Log_Registro = String.Empty
        Dim _Consulta_sql = String.Empty

        Dim _Fecha = Format(_Fecha_Revision, "yyyyMMdd")

        Dim Dia_1 As String = numero_(_Fecha_Revision.Day, 2)
        Dim Mes_1 As String = numero_(_Fecha_Revision.Month, 2)
        Dim Ano_1 As String = _Fecha_Revision.Year

        _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Prestashop" & vbCrLf &
                        "Where 1 > 0 " & vbCrLf &
                        "And ((Revisado = 0 And NombreEquipo = '" & _Nombre_Equipo & "' And Fecha = '" & _Fecha & "')" & vbCrLf &
                        "Or (Revisado = 0 And Peticion_Manual = 1 And Fecha = '" & _Fecha & "'))"
        Dim _Tbl_Productos_Prestashop As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        If CBool(_Tbl_Productos_Prestashop.Rows.Count) Then

            Dim _Filtro_Codigos As String = Generar_Filtro_IN(_Tbl_Productos_Prestashop, "", "Id", True, False, "")

            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Prestashop" & Space(1) &
                           "Where NombreEquipo = '" & _Nombre_Equipo & "' And Codigo = 'Error!!'" & vbCrLf & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Demonio_Prestashop Set Log_Error = '' Where Id In " & _Filtro_Codigos
            If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                Log_Registro += _Sql.Pro_Error
            End If

            Dim _Cadena_Conexion_MySql As String
            Dim _Clas_Ps As Class_MySQL

            System.Windows.Forms.Application.DoEvents()

            Consulta_Sql = "Select Codigo_Pagina,Nombre_Pagina,Host,Usuario,Clave,Puerto_X_Defecto,Puerto,Base_Datos,Cod_Lista" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_PrestaShop" & vbCrLf &
                           "Where Conexion_Activa = 1"
            Dim _Tbl_Prestashop As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

            Dim _Cont_Conexion = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Demonio_Prestashop", "1>0") + 1

            For Each _Fila As DataRow In _Tbl_Prestashop.Rows

                Dim _Codigo_Pagina = _Fila.Item("Codigo_Pagina")
                Dim _Nombre_Pagina = _Fila.Item("NOmbre_Pagina")

                Dim _Host = _Fila.Item("Host")
                Dim _Usuario = _Fila.Item("Usuario")
                Dim _Clave = _Fila.Item("Clave")
                Dim _Puerto_X_Defecto = _Fila.Item("Puerto_X_Defecto")
                Dim _Puerto = _Fila.Item("Puerto")
                Dim _Base_Datos = _Fila.Item("Base_Datos")
                Dim _Cod_Lista = _Fila.Item("Cod_Lista")

                _Cadena_Conexion_MySql = "Host=" & _Host & ";Database=" & _Base_Datos & ";Uid=" & _Usuario & ";Password=" & _Clave & ";"
                _Clas_Ps = New Class_MySQL(_Cadena_Conexion_MySql)

                _Clas_Ps.Sb_Abrir_Conexion()

                Dim _Log_Error As String = _Clas_Ps.Pro_Error


                If String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then

                    Dim _Contador = 1

                    For Each _Row_Doc As DataRow In _Tbl_Productos_Prestashop.Rows

                        Dim _Codigo = _Row_Doc.Item("Codigo")
                        Dim _Id As Integer = _Row_Doc.Item("Id")

                        _Etiqueta2.Text = _Nombre_Pagina & ", Prod.: " & _Contador & " de " & _Tbl_Productos_Prestashop.Rows.Count

                        _Contador += 1

                        _Log_Error = String.Empty

                        Consulta_Sql = "Select Top 1 * From TABCODAL" & vbCrLf &
                                       "Where KOEN = '" & _Codigo_Pagina & "' AND KOPR = '" & _Codigo & "'"
                        Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        Dim _Error_Stock = String.Empty
                        Dim _Error_Precios = String.Empty
                        Dim _Error_active = String.Empty

                        _Error_Stock = Fx_Prestashop_Actualizar_Stock(_Cadena_Conexion_MySql, _Nombre_Pagina, _Codigo, _Row_Tabcodal, 50) & " - "
                        _Error_Precios = Fx_Prestashop_Actualizar_Precios(_Cadena_Conexion_MySql, _Nombre_Pagina, _Codigo, _Cod_Lista, _Row_Tabcodal)

                        Dim _Error As Boolean
                        _Log_Error = _Nombre_Pagina & ", " & _Error_Stock & ", " & _Error_Precios

                        If _Error_Stock = "Error!! al insertar Stock" Or _Error_Precios = "Error!! al insertar Precio" Then
                            _Error = True
                        Else
                            _Error = False
                        End If

                        Log_Registro += _Error & vbCrLf

                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Prestashop Set Revisado = 1," & vbCrLf &
                                       "Log_Error = '(" & _Log_Error & ") '+Log_Error," & Space(1) &
                                       "Error = " & CInt(_Error) * -1 & vbCrLf &
                                       "Where Id = " & _Id
                        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                            Log_Registro += _Sql.Pro_Error
                        End If

                    Next

                Else

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Prestashop (NombreEquipo,Idmaeddo,Codigo,Descripcion,Fecha,Revisado,Log_Error,Error) Values " & vbCrLf &
                                   "('" & _Nombre_Equipo & "'," & _Cont_Conexion & ",'Error!!','" & _Nombre_Pagina &
                                   "','" & _Fecha & "',1,'Error: " & _Nombre_Pagina & ", Descripción Error: " & _Log_Error & "',1)"
                    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += _Sql.Pro_Error
                    End If

                End If

                _Cont_Conexion += 1

            Next

        End If

    End Sub

    Sub Sb_Procedimiento_Prestashop2(_Procesar_Todo As Boolean)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop"
        Dim _Tbl_Sitios_Prestashops As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql, False)

        Dim _Sitio As String
        Dim _Stock_Maximo As Double

        Dim _Tbl_Productos As DataTable

        For Each _Row_Prestashop As DataRow In _Tbl_Sitios_Prestashops.Rows

            _Sitio = _Row_Prestashop.Item("Nombre_Pagina")
            _Stock_Maximo = _Row_Prestashop.Item("Stock_Maximo")

            If _Procesar_Todo Then

                Consulta_Sql = "Select *,Cast(0 As Float) As Stock_Actual,Cast(0 As Bit) As Mostrar
                                From " & _Global_BaseBk & "Zw_Prod_PrestaShop
                                Where Sitio = '" & _Sitio & "'"

            Else

                Consulta_Sql = "Select *,Cast(0 As Float) As Stock_Actual,Cast(0 As Bit) As Mostrar
                                Into #Paso
                                From " & _Global_BaseBk & "Zw_Prod_PrestaShop
                                Where Sitio = '" & _Sitio & "' 

                                Update #Paso Set Stock_Actual = (Select Isnull(Sum(STFI1),0) From MAEST Where KOPR = Codigo)
                                
                                Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo From #Paso Where Stock_Actual <> Stock_Rd And Stock_Actual < " & De_Txt_a_Num_01(_Stock_Maximo, 5) & ")
						        Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo_Padre From " & _Global_BaseBk & "Zw_Prod_Padres Where Carpeta = '" & _Sitio & "' And Codigo_Hijo In (Select Codigo From #Paso Where Mostrar = 1))
						        Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo_Hijo From " & _Global_BaseBk & "Zw_Prod_Padres Z2 Where Carpeta = '" & _Sitio & "' And Codigo_Padre In (Select Codigo From #Paso Where Mostrar = 1))

                                Select * From #Paso Where Mostrar = 1
                                Drop Table #Paso"

            End If

            _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_Sql)

            If CBool(_Tbl_Productos.Rows.Count) Then

                Dim _Class_Prestashop = New Class_Prestashop(_Sitio)

                If Not IsNothing(_Tbl_Productos) Then
                    _Tbl_Productos = _Class_Prestashop.Fx_Tbl_Productos_Prestashop(_Class_Prestashop.Sitio, _Tbl_Productos, "Codigo")
                End If

                Dim _Progress_Canti As New CircularProgress

                _Class_Prestashop.Progress_Canti = _Progress_Canti
                _Class_Prestashop.Etiqueta2 = _Etiqueta2

                _Class_Prestashop.Sb_Insertar_Nuevos_Productos_Desde_Prestashop_Hacia_Tabla_Prod_PrestaShop(False)

                _Class_Prestashop.Sb_Actualizar_Tabla_Prod_PrestaShop(_Tbl_Productos)
                _Class_Prestashop.Sb_Actualizar_Datos_En_Prestashop(_Tbl_Productos, True)
                _Class_Prestashop.Sb_Activar_Desactivar_Datos_En_Prestashop()

            End If

        Next

    End Sub

    Sub Sb_Procedimiento_Prestashop3()

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop"
        Dim _Tbl_Sitios_Prestashops As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql, False)

        For Each _Row_Prestashop As DataRow In _Tbl_Sitios_Prestashops.Rows

            Dim _Sitio = _Row_Prestashop.Item("Nombre_Pagina")
            Dim _Class_Prestashop = New Class_Prestashop(_Sitio)
            Dim _Progress_Canti As New CircularProgress

            _Class_Prestashop.Progress_Canti = _Progress_Canti
            _Class_Prestashop.Etiqueta2 = _Etiqueta2

            _Class_Prestashop.Sb_Insertar_Nuevos_Productos_Desde_Prestashop_Hacia_Tabla_Prod_PrestaShop(False)

            _Class_Prestashop.Sb_Actualizar_Tabla_Prod_PrestaShop(Nothing)
            _Class_Prestashop.Sb_Actualizar_Datos_En_Prestashop(Nothing, False)
            _Class_Prestashop.Sb_Activar_Desactivar_Datos_En_Prestashop()

        Next

    End Sub

    Function Fx_Prestashop_Actualizar_Precios(ByVal _Cadena_Conexion_MySql As String,
                                              ByVal _Nombre_Pagina As String,
                                              ByVal _Codigo As String,
                                              ByVal _Cod_Lista As String,
                                              ByVal _Row_Tabcodal As DataRow) As String

        Try

            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)
            Dim _Cant_Encontrados As Long = 0
            Dim Contador As Long = 0

            Dim _Mensaje As String

            If Not (_Row_Tabcodal Is Nothing) Then

                Dim _ID_Producto As String = Trim(_Row_Tabcodal.Item("KOPRAL"))

                Dim _Row_Precios As DataRow
                Dim _Row_Lista As DataRow

                Consulta_Sql = "Select Top 1 * From TABPRE Where KOLT = '" & _Cod_Lista & "' And KOPR = '" & _Codigo & "'"
                _Row_Precios = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Consulta_Sql = "Select Top 1 * From TABPP Where KOLT = '" & _Cod_Lista & "'"
                _Row_Lista = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Valor As Double = _Row_Precios.Item("PP01UD")
                Dim _Ecuacion As String = _Row_Precios.Item("ECUACION")
                Dim _Melt As String = _Row_Lista.Item("MELT")

                If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

                    Dim _Tiene_C As Boolean = InStr(1, _Ecuacion, "<")
                    Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

                    If Not _Tiene_C Then

                        If Not _Tiene_Cor Then

                            Dim _Campo_Precio
                            Dim _Campo_Ecuacion

                            'If _UnTrans = 1 Then
                            _Campo_Precio = "PP01UD"
                            _Campo_Ecuacion = "ECUACION"
                            'Else
                            '_Campo_Precio = "PP02UD"
                            '_Campo_Ecuacion = "ECUACIONU2"
                            'End If

                            _Valor = Fx_Precio_Formula_Random(_Row_Precios, _Campo_Precio, _Campo_Ecuacion, Nothing, True, "", 1, 1)

                            If _Melt = "B" Then
                                _Valor = Math.Round(_Valor / 1.19, 6)
                            End If

                        End If
                    End If
                End If

                '_Valor = 3000

                Consulta_Sql = "Update ps_product_shop set price = " & De_Num_a_Tx_01(_Valor, False, 8) & vbCrLf &
                               "Where id_product = " & _ID_Producto.Trim
                If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_Sql, False) Then

                    _Mensaje = "Tabla [ps_product] OK,"

                    Consulta_Sql = "Update ps_product set price = " & De_Num_a_Tx_01(_Valor, False, 8) & vbCrLf &
                                   "Where id_product = " & _ID_Producto.Trim & vbCrLf
                    If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_Sql, False) Then
                        _Mensaje += "Tabla [ps_product_shop] OK."
                    Else
                        _Mensaje = "Error!! al insertar Precio"
                    End If
                Else
                    _Mensaje = "Error!! al insertar Precio"
                End If

                _Mensaje = "Lista: " & _Cod_Lista & ", Precio: $ " & De_Num_a_Tx_01(_Valor, False, 6) & ", " & _Mensaje
            Else
                Return "No Aplica"
            End If

            Return _Mensaje
        Catch ex As Exception
            Return "Error!! al insertar Precio"
        End Try

    End Function

    Function Fx_Prestashop_Actualizar_Stock(_Cadena_Conexion_MySql As String,
                                            _Nombre_Pagina As String,
                                            _Codigo As String,
                                            _Row_Tabcodal As DataRow,
                                            _Max_Stock As Double) As String

        Try
            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

            If Not (_Row_Tabcodal Is Nothing) Then

                Dim _ID_Producto As String = _Row_Tabcodal.Item("KOPRAL")
                Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "SUM(STFI1-STDV1)", "KOPR = '" & _Codigo & "'")
                Dim _Stock_Total = _Stock

                If _Stock > _Max_Stock Then _Stock = _Max_Stock

                ' _Cadena_Conexion_MySql = "Host=" '& _Host & ".;Database=" & _Base_Datos & ";Uid=" & _Usuario & ";Password=" & _Clave & ";"

                Consulta_Sql = "Update ps_stock_available set quantity= " & De_Num_a_Tx_01(_Stock) & vbCrLf &
                               "Where id_product = " & _ID_Producto.Trim & vbCrLf

                If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_Sql, False) Then
                    Return "Stock en Bodega: " & De_Num_a_Tx_01(_Stock_Total, False, 0) &
                           ", Stock grabado: " & De_Num_a_Tx_01(_Stock, 0) & "."
                Else
                    Return "Error!! al insertar Stock" '_Clas_Ps.Pro_Error & ". "
                End If
            Else
                Return "No Aplica."
            End If
        Catch ex As Exception
            Return "Error!! al insertar Stock"
        End Try

    End Function

    Function Fx_Prestashop_Activar_Desactivar_Producto(_Cadena_Conexion_MySql As String,
                                                       _Codigo As String,
                                                       _Koen As String) As String

        'Dim _Error As String

        Try

            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

            Dim _Tbl_Productos_Hermanos As DataTable = Fx_Tbl_Productos_Hermanos(_Codigo)

            For Each _Fila As DataRow In _Tbl_Productos_Hermanos.Rows

                Dim _Codigo2 As String = _Fila.Item("Codigo")
                'Dim _Stock As Double = _Fila.Item("Stock")
                'Dim _Importados As Boolean = _Fila.Item("Importados")
                Dim _active As Boolean = _Fila.Item("active")

                Consulta_Sql = "Select Top 1 * From TABCODAL Where KOEN = '" & _Koen & "' And KOPR = '" & _Codigo2 & "'"
                Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                If Not (_Row_Tabcodal Is Nothing) Then

                    Dim _id_product As String = _Row_Tabcodal.Item("KOPRAL")

                    Consulta_Sql = "Update ps_product set active = b'" & Convert.ToInt32(_active) & "'" & vbCrLf &
                                   "Where id_product = " & _id_product.Trim

                    If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_Sql, False) Then

                        Consulta_Sql = "Update ps_product_shop set active = b'" & Convert.ToInt32(_active) & "'" & vbCrLf &
                                                           "Where id_product = " & _id_product.Trim

                        If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_Sql, False) Then
                            'Return ""
                        Else
                            Return "Error!! al insertar Stock" '_Clas_Ps.Pro_Error & ". "
                        End If

                    Else
                        Return "Error!! al insertar Stock" '_Clas_Ps.Pro_Error & ". "
                    End If

                Else
                    Return "No Aplica."
                End If

            Next

        Catch ex As Exception
            Return "Error!! al insertar Stock"
        End Try

    End Function

    Function Fx_Tbl_Productos_Hermanos(_Codigo As String) As DataTable

        Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where (Codigo = '" & _Codigo & "') AND (Para_filtro = 1)" & vbCrLf &
                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")"

        Dim _Row_Nodo_Clasificaciones As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Codigo_Nodo As Integer

        If _Row_Nodo_Clasificaciones Is Nothing Then
            _Codigo_Nodo = 0
        Else
            _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
        End If

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_Sql)

        'Consulta_sql = "Select KOPR As Codigo,Cast(0 As Bit) As Importado,Cast(0 As Float) As Stock,Cast(0 As Bit) As active 
        '                From MAEPR Where KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
        '               "Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0)"

        Consulta_Sql = "Select Codigo,Cast(0 As Bit) As Importado,Cast(0 As Float) As Stock,Cast(0 As Bit) As active,Hermano 
                        From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                        Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0"

        Dim _Tbl_Productos_Hermanos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Codigo_Nodo_Importados = 30106 ' Codigo_Nodo 04 IMPORTADOS

        For Each _Fila As DataRow In _Tbl_Productos_Hermanos.Rows

            Dim _Codigo2 As String = _Fila.Item("Codigo")
            Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "SUM(STFI1)", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo2 & "'")
            Dim _Importado = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                                      "Codigo_Nodo = " & _Codigo_Nodo_Importados & " And Codigo = '" & _Codigo2 & "'")

            _Fila.Item("Stock") = _Stock
            _Fila.Item("Importado") = Convert.ToBoolean(_Importado)

        Next

        For Each _Fila3 As DataRow In _Tbl_Productos_Hermanos.Rows

            Dim _Codigo3 As String = _Fila3.Item("Codigo")
            Dim _Importado3 As Boolean = _Fila3.Item("Importado")
            Dim _Stock3 As Boolean = (_Fila3.Item("Stock") > 0)
            Dim _Hermano3 As String = _Fila3.Item("Hermano")

            If _Importado3 And _Stock3 Then

                _Fila3.Item("active") = True

            Else

                _Fila3.Item("active") = True

                If Not String.IsNullOrEmpty(_Hermano3.Trim) Then

                    For Each _Fila4 As DataRow In _Tbl_Productos_Hermanos.Rows

                        Dim _Codigo4 As String = _Fila4.Item("Codigo")
                        Dim _Hermano4 As String = _Fila3.Item("Hermano")

                        If _Codigo3 <> _Codigo4 And _Hermano3 = _Codigo4 Then

                            Dim _Importado4 As Boolean = _Fila4.Item("Importado")
                            Dim _Stock4 As Boolean = (_Fila4.Item("Stock") > 0)

                            If _Importado4 And _Stock4 Then
                                _Fila3.Item("active") = False
                            End If

                        End If

                    Next

                End If

            End If

        Next

        Return _Tbl_Productos_Hermanos

    End Function

End Class
