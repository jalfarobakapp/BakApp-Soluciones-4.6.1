Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Cl_Permisos_Asociados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsCRemotas As DataSet

    Dim _Ds_Matriz_Documentos As Ds_Matriz_Documentos

    Dim _Row_Entidad As DataRow
    Dim _Row_Encabezado As DataRow
    Dim _Tbl_Detalle As DataTable
    Dim _Row_Observaciones As DataRow
    Dim _Row_PermisosNecesarios As DataRow

    Dim _Enviar_Solicitudes As Boolean

    Dim _Solicitar_Permiso_X_01_Stock As Boolean
    Dim _Solicitar_Permiso_X_02_Descuentos As Boolean
    Dim _Solicitar_Permiso_X_03_Morosidad As Boolean
    Dim _Solicitar_Permiso_X_04_Cupo_Excedido As Boolean
    Dim _Solicitar_Permiso_X_05_Fecha_Despacho As Boolean

    Dim _Id_Enc As Integer
    Dim _Id_DocEnc As Integer
    Dim _Nro_RCadena As String

    Dim _Error As String

    'Dim _Autorizado_Para_Grabar As Boolean

    Public ReadOnly Property Pro_Id_Enc() As Integer
        Get
            Return _Id_Enc
        End Get
    End Property

    Public ReadOnly Property Pro_Id_DocEnc() As Integer
        Get
            Return _Id_DocEnc
        End Get
    End Property

    Public ReadOnly Property Pro_Nro_RCadena() As String
        Get
            Return _Nro_RCadena
        End Get
    End Property

    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Public Sub New(Ds_Matriz_Documentos As Ds_Matriz_Documentos)

        Consulta_sql = "Select *,Cast(0 As Int) As SubPermiso From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det Where 0 > 1" & vbCrLf &
                       "Select *,Cast('' As Varchar(10)) As CodPermiso,Cast(0 As Int) As SubPermiso From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu Where 0 > 1"
        _DsCRemotas = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Matriz_Documentos = Ds_Matriz_Documentos

        _Row_Encabezado = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)

    End Sub

    Function Fx_Enviar_Cadena_Remota() As Boolean

        If Not (_DsCRemotas Is Nothing) Then

            _Nro_RCadena = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc",
                                                           "COALESCE(MAX(Nro_RCadena),'0000000000')")
            If _Nro_RCadena = "0000000000" Then
                _Nro_RCadena = "RC00000000"
            End If

            _Nro_RCadena = Fx_Proximo_NroDocumento(_Nro_RCadena, 10)

            If Not _DsCRemotas Is Nothing Then

                ' CREAMOS EL DOCUMENTO DE PASO
                Dim _Crear_Doc As New Clase_Crear_Documento

                _Id_DocEnc = _Crear_Doc.Fx_Crear_Documento_En_BakApp_Casi(_Ds_Matriz_Documentos, False, False)

                If CBool(_Id_DocEnc) Then

                    ' Creamos la cadena de remotas
                    Sb_Cadena_Remotas_Crear_Cadena(_Nro_RCadena, _Id_DocEnc, _Id_Enc, _DsCRemotas)

                    Fx_Enviar_Cadena_Remota = Convert.ToBoolean(_Id_Enc)

                End If

            End If

        End If

    End Function

    Sub Sb_Cadena_Remotas_Crear_Cadena(_Nro_RCadena As String,
                                       _Id_DocEnc As Integer,
                                       ByRef _Id_Enc As Integer,
                                       _DsCRemotas As DataSet)

        Try

            _Row_Encabezado = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)

            Dim _Tido = _Row_Encabezado.Item("TipoDoc")
            Dim _Empresa = _Row_Encabezado.Item("Empresa")
            Dim _CodEntidad = Trim(_Row_Encabezado.Item("CodEntidad"))
            Dim _CodSucEntidad = Trim(_Row_Encabezado.Item("CodSucEntidad"))
            Dim _Nombre_Entidad = Trim(_Row_Encabezado.Item("Nombre_Entidad"))
            Dim _Total = De_Num_a_Tx_01(_Row_Encabezado.Item("TotalBrutoDoc"), False, 5)

            Dim myTrans As SqlClient.SqlTransaction
            Dim Comando As SqlClient.SqlCommand


            Dim Cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            Try

                myTrans = Cn2.BeginTransaction()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc (Empresa,Nro_RCadena,CodEntidad,CodSucEntidad,Nombre_Entidad,Id_DocEnc," &
                               "Usuario_Solicita,Fecha_Hora,Tido,Total_Original,Total_Documento)" & vbCrLf &
                               "Values ('" & _Empresa & "','" & _Nro_RCadena & "','" & _CodEntidad & "','" & _CodSucEntidad & "','" & _Nombre_Entidad &
                               "'," & _Id_DocEnc & ",'" & FUNCIONARIO & "',Getdate(),'" & _Tido & "'," & _Total & "," & _Total & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                'Imports System.Data
                'Imports System.Data.SqlClient

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Id_Enc = dfd1("Identity")
                End While
                dfd1.Close()

                Dim _Tbl_Det As DataTable = _DsCRemotas.Tables(0)

                Dim Contador As Integer = 1

                For Each _FDet As DataRow In _Tbl_Det.Rows

                    Dim Estado As DataRowState = _FDet.RowState

                    If Not Estado = DataRowState.Deleted Then

                        Dim _SubPermiso As Integer = _FDet.Item("SubPermiso")

                        Dim _Id_Det As Integer
                        Dim _Orden = _FDet.Item("Orden")
                        Dim _CodPermiso = _FDet.Item("CodPermiso")
                        Dim _Descripcion = _FDet.Item("Descripcion")
                        Dim _Monto_Aprobacion = De_Num_a_Tx_01(_FDet.Item("Monto_Aprobacion"), False, 5)

                        Consulta_sql =
                            "INSERT INTO " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det (Id_Enc,Nro_RCadena,Orden,CodPermiso,Descripcion,Monto_Aprobacion)" & vbCrLf &
                            "VALUES (" & _Id_Enc & ",'" & _Nro_RCadena & "'," & _Orden & ",'" & _CodPermiso & "','" & _Descripcion & "'," & _Monto_Aprobacion & ")"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                        Comando.Transaction = myTrans
                        dfd1 = Comando.ExecuteReader()
                        While dfd1.Read()
                            _Id_Det = dfd1("Identity")
                        End While
                        dfd1.Close()

                        For Each _FUsu As DataRow In _DsCRemotas.Tables(1).Rows

                            Dim _CodPermiso_01 = _FUsu.Item("CodPermiso")
                            Dim _SubPermiso_01 = _FUsu.Item("SubPermiso")

                            If _CodPermiso_01 = _CodPermiso And _SubPermiso = _SubPermiso_01 Then

                                Dim _Usuario_Destino = _FUsu.Item("Usuario_Destino")

                                Consulta_sql =
                                    "INSERT INTO " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu (Id_Enc,Id_Det,Usuario_Destino)" & vbCrLf &
                                    "VALUES (" & _Id_Enc & "," & _Id_Det & ",'" & _Usuario_Destino & "')"

                                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                        Next

                        Contador += 1

                    End If

                Next

                ' ====================================================================================================================================

                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)


            Catch ex As Exception

                _Id_Enc = 0
                myTrans.Rollback()

                MessageBoxEx.Show(Me, "Transaccion desecha", "Problema",
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            End Try

        Catch ex As Exception

            MessageBoxEx.Show(Me, "Transaccion desecha", "Problema",
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

        End Try

    End Sub

    Function Fx_Cadena_Remotas_Generar_Detalle(ByVal _CodPermiso As String,
                                               ByVal _Orden As Integer,
                                               ByVal _Tbl_Usuario As DataTable) As Boolean

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _CodPermiso & "'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Descripcion = _RowPermiso.Item("DescripcionPermiso")

        Dim _Row_Det As DataRow = Fx_Cadena_Remota_Nueva_Linea_Det(_DsCRemotas.Tables(0), _CodPermiso, UCase(_Descripcion), _Orden)

        If Not (_Row_Det Is Nothing) Then

            Dim _Id_Det = _Row_Det.Item("Id_Det")

            If Not _Tbl_Usuario Is Nothing Then
                For Each _Fila As DataRow In _Tbl_Usuario.Rows
                    Dim _CodUsuario = _Fila.Item("Codigo")
                    Fx_Cadena_Remota_Nueva_Linea_Usu(_DsCRemotas.Tables(1), _Id_Det, _CodUsuario, _CodPermiso)
                Next
            Else
                Return False
            End If

        End If

        Return True

    End Function

    Private Function Fx_Cadena_Remota_Nueva_Linea_Det(ByRef _Tbl As DataTable,
                                                      ByVal _CodPermiso As String,
                                                      ByVal _Descripcion As String,
                                                      ByVal _Orden As Integer) As DataRow


        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id_Enc") = 0
            .Item("Nro_RCadena") = "XXXXXXXXXX"
            .Item("Orden") = _Orden
            .Item("CodPermiso") = _CodPermiso
            .Item("Descripcion") = _Descripcion
            .Item("NroRemota") = ""
            .Item("New_Id_DocEnc") = 0

        End With

        _Tbl.Rows.Add(NewFila)

        Return NewFila

    End Function

    Private Function Fx_Cadena_Remota_Nueva_Linea_Usu(ByRef _Tbl As DataTable,
                                                      ByVal _Id_Det As Integer,
                                                      ByVal _Usuario_Destino As String,
                                                      ByVal _CodPermiso As String) As DataRow


        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id_Enc") = 0
            .Item("Id_Det") = _Id_Det
            .Item("Usuario_Destino") = _Usuario_Destino
            .Item("CodPermiso") = _CodPermiso

        End With

        _Tbl.Rows.Add(NewFila)

        Return NewFila

    End Function

    Function Fx_Incorporar_Permiso_Al_Documento(ByRef _Ds As DataSet,
                                                _CodPermiso As String,
                                                _Necesita_Permiso As Boolean,
                                                _Autorizado As Boolean,
                                                _CodFuncionario_Autoriza As String,
                                                _NroRemota As String,
                                                _Permiso_Presencial As Boolean,
                                                _PermisoIndependiente As Boolean,
                                                _Solicitar_Permiso_Al_Final As Boolean) As Boolean

        Try

            Dim _DescripcionPermiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos",
                                                        "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")

            Dim _Tbl_Permisos_Doc As DataTable = _Ds.Tables("Permisos_Doc")

            Dim NewFila = _Tbl_Permisos_Doc.NewRow
            With NewFila

                .Item("CodPermiso") = _CodPermiso
                .Item("DescripcionPermiso") = _DescripcionPermiso
                .Item("Necesita_Permiso") = _Necesita_Permiso
                .Item("Autorizado") = _Autorizado
                .Item("CodFuncionario_Autoriza") = _CodFuncionario_Autoriza
                .Item("NroRemota") = _NroRemota
                .Item("Permiso_Presencial") = _Permiso_Presencial
                .Item("Solicitado_Por_Cadena") = False
                .Item("PermisoIndependiente") = _PermisoIndependiente
                .Item("Solicitar_Permiso_Al_Final") = _Solicitar_Permiso_Al_Final

                _Tbl_Permisos_Doc.Rows.Add(NewFila)

                Return True

            End With

        Catch ex As Exception

        End Try

    End Function



    Function Fx_Cadena_Remotas_Generar_Detalle(_CodPermiso As String,
                                               _Orden As Integer,
                                               _Tbl_Usuario As DataTable,
                                               _Monto_Aprobacion As Double) As Boolean

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _CodPermiso & "'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Descripcion = _RowPermiso.Item("DescripcionPermiso")

        Dim _Row_Det As DataRow = Fx_Cadena_Remota_Nueva_Linea_Det(_CodPermiso, UCase(_Descripcion), _Orden, 1, _Monto_Aprobacion)

        If Not (_Row_Det Is Nothing) Then

            Dim _Id_Det = _Row_Det.Item("Id_Det")

            If Not _Tbl_Usuario Is Nothing Then
                For Each _Fila As DataRow In _Tbl_Usuario.Rows
                    Dim _CodUsuario = _Fila.Item("Codigo")
                    Fx_Cadena_Remota_Nueva_Linea_Usu(_Id_Det, _CodUsuario, _CodPermiso, 1)
                Next
            Else
                Return False
            End If

        End If

        Return True

    End Function

    Function Fx_Cadena_Remota_Nueva_Linea_Det(_CodPermiso As String,
                                              _Descripcion As String,
                                              _Orden As Integer,
                                              _SubPermiso As Integer,
                                              _Monto_Aprobacion As Double) As DataRow

        Dim _Tbl As DataTable = _DsCRemotas.Tables(0)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id_Enc") = 0
            .Item("Nro_RCadena") = "XXXXXXXXXX"
            .Item("Orden") = _Orden
            .Item("CodPermiso") = _CodPermiso
            .Item("Descripcion") = _Descripcion
            .Item("NroRemota") = ""
            .Item("New_Id_DocEnc") = 0
            .Item("SubPermiso") = _SubPermiso
            .Item("Monto_Aprobacion") = _Monto_Aprobacion

        End With

        _Tbl.Rows.Add(NewFila)

        Return NewFila

    End Function

    Function Fx_Cadena_Remota_Nueva_Linea_Usu(_Id_Det As Integer,
                                              _Usuario_Destino As String,
                                              _CodPermiso As String,
                                              _SubPermiso As Integer) As DataRow

        Dim _Tbl As DataTable = _DsCRemotas.Tables(1)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id_Enc") = 0
            .Item("Id_Det") = _Id_Det
            .Item("Usuario_Destino") = _Usuario_Destino
            .Item("CodPermiso") = _CodPermiso
            .Item("SubPermiso") = _SubPermiso

        End With

        _Tbl.Rows.Add(NewFila)

        Return NewFila

    End Function

    Sub Sb_Llenar_Funcionarios_Destino(ByVal _Codpermiso As String,
                                               ByRef _Tbl_Usuarios As DataTable)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Descripcion = _RowPermiso.Item("DescripcionPermiso")

        Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Dim _Filtro_Usuarios_NOT_In As String

        If CBool(_Tbl.Rows.Count) Then
            _Filtro_Usuarios_NOT_In = "And KOFU In " & Generar_Filtro_IN(_Tbl, "", "CodUsuario", False, False, "'")
        Else
            MessageBoxEx.Show(Me, "No existen usuarios con el permiso necesario." & vbCrLf &
                              "Informe esta situación a la administración por favor.",
                              "Faltan usuarios con el permiso [" & _Codpermiso & "]", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim Fm_R As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
        Fm_R.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0" & vbCrLf & _Filtro_Usuarios_NOT_In
        Fm_R.Text = "SOLICITUD DE PERMISO: " & _Codpermiso & " - " & _Descripcion
        Fm_R.Pro_Tbl_Filtro = _Tbl_Usuarios
        Fm_R.ShowDialog(Me)

        If Fm_R.Pro_Filtrar Then
            _Tbl_Usuarios = Fm_R.Pro_Tbl_Filtro
        End If

        Fm_R.Dispose()

    End Sub

    Function Fx_Permisos_OCC(_Row_OCC As DataRow,
                             ByRef _Tiene_Jefes As Boolean) As Boolean

        Dim _Orden = 0

        If Not IsNothing(_Row_OCC) Then

            Dim _Necesita_Permiso = _Row_OCC.Item("Necesita_Permiso")
            Dim _Autorizado = _Row_OCC.Item("Autorizado")

            Dim _Total_Bruto As Double = _Row_Encabezado.Item("TotalBrutoDoc")
            Dim _Mi_Valor_Max_Compra As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosVsUsuarios", "Valor_Max_Compra",
                                                                   "CodPermiso = 'Comp0092' And CodUsuario = '" & FUNCIONARIO & "'", True)

            Dim _Contador_Permisos As Integer
            Dim _Jefes As New List(Of String)

            Fx_Insertar_Jefe(FUNCIONARIO, _Jefes)

            _Tiene_Jefes = Convert.ToBoolean(_Jefes.Count)

            _Contador_Permisos = _Jefes.Count

            If Not Fx_Permisos_OCC_Validar_Productos(_Jefes, _Orden, _Necesita_Permiso, _Contador_Permisos) Then
                Return False
            End If

            If _Necesita_Permiso And Not _Autorizado Then

                Dim _Moneda_Doc As String = _Row_Encabezado.Item("Moneda_Doc")
                Dim _Valor_Dolar As Double = _Row_Encabezado.Item("Valor_Dolar")

                If _Moneda_Doc.ToString.Trim <> "$" Then
                    _Total_Bruto = Math.Round(_Total_Bruto * _Valor_Dolar, 0)
                End If

                If _Tiene_Jefes Then

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos Where CodPermiso = 'Comp0092'"
                    Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Ult_Monto_Aprovacion As Double = _Mi_Valor_Max_Compra + 1

                    For Each _CodJefe As String In _Jefes

                        _Orden += 1

                        Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios 
                                        Where CodPermiso = 'Comp0092' And CodUsuario = '" & _CodJefe & "'-- And Valor_Max_Compra > 0"
                        Dim _Row_Permiso_Jefe As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Consulta_sql = "Select * From TABFU Where KOFU = '" & _CodJefe & "'"
                        Dim _Row_Tabfujefe As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If Not IsNothing(_Row_Permiso_Jefe) Then

                            Dim _Valor_Max_Compra As Double = _Row_Permiso_Jefe.Item("Valor_Max_Compra")
                            Dim _Monto_Aprobacion = _Valor_Max_Compra

                            If _Monto_Aprobacion < _Ult_Monto_Aprovacion Then
                                If Not IsNothing(_Row_Tabfujefe) Then
                                    _Error = "El Jefe " & _CodJefe & " - " & Trim(_Row_Tabfujefe.Item("NOKOFU")) & vbCrLf &
                                         "No tiene un valor suficiente como para poder estar en la lista de permisos" & vbCrLf &
                                         "Valor autorizado: " & FormatCurrency(_Monto_Aprobacion, 0)
                                Else
                                    _Error = "No existe el Jefe: " & _CodJefe
                                End If
                                Return False
                            End If

                            If Not Convert.ToBoolean(_Monto_Aprobacion) Then
                                _Monto_Aprobacion = _Mi_Valor_Max_Compra + 50000
                            End If

                            If _Orden = _Contador_Permisos Then '_Jefes.Count Then
                                _Monto_Aprobacion = _Total_Bruto
                            End If

                            Dim _Descripcion = Trim(_RowPermiso.Item("DescripcionPermiso")) & " (NIVEL " & _Orden & ", Valor necesario: " & FormatCurrency(_Monto_Aprobacion, 0) & ")"

                            Dim _Row_Det As DataRow = Fx_Cadena_Remota_Nueva_Linea_Det("Comp0092",
                                                                                    UCase(_Descripcion),
                                                                                    _Orden,
                                                                                    _Orden,
                                                                                    _Monto_Aprobacion)

                            If Not (_Row_Det Is Nothing) Then

                                Dim _Id_Det = _Row_Det.Item("Id_Det")

                                Fx_Cadena_Remota_Nueva_Linea_Usu(_Id_Det, _CodJefe, "Comp0092", _Orden)

                            End If

                            _Ult_Monto_Aprovacion = _Monto_Aprobacion

                            If _Valor_Max_Compra >= _Total_Bruto Then
                                Exit For
                            End If

                        Else

                            If Not IsNothing(_Row_Tabfujefe) Then
                                _Error = "El Jefe " & _CodJefe & " - " & Trim(_Row_Tabfujefe.Item("NOKOFU")) & " no tiene un valor asignado para poder dar permisos" & vbCrLf &
                                         "Revise el permiso: Comp0092" & vbCrLf
                            Else
                                _Error = "No existe el Jefe: " & _CodJefe
                            End If

                            Return False

                        End If

                    Next

                Else

                    _Error = "No se encontraron los permisos necesarios en la jefatura para realizar esta acción"

                End If

            End If

            If Convert.ToBoolean(_DsCRemotas.Tables(0).Rows.Count) And String.IsNullOrEmpty(_Error) Then
                _Enviar_Solicitudes = Fx_Enviar_Cadena_Remota()
            End If

        End If

        Return _Enviar_Solicitudes

    End Function

    Function Fx_Permisos_OCC_Validar_Productos(ByRef _Jefes As List(Of String),
                                               ByRef _Orden As Integer,
                                               ByVal _Necesita_Permiso_Valor As Boolean,
                                               ByRef _Contador_Permisos As Integer) As Boolean

        Dim _Lista_Productos As New List(Of String)

        _Tbl_Detalle = _Ds_Matriz_Documentos.Tables("Detalle_Doc")

        For Each _Fila As DataRow In _Tbl_Detalle.Rows

            Dim _Codigo = _Fila.Item("Codigo")
            Dim _FunValida_Compra = _Fila.Item("FunValida_Compra")

            If String.IsNullOrEmpty(_FunValida_Compra) Then
                _Lista_Productos.Add(_Codigo)
            End If

        Next

        Dim _Filtro_Jefes = String.Empty

        If CBool(_Jefes.Count) And _Necesita_Permiso_Valor Then

            _Filtro_Jefes = Generar_Filtro_IN_Arreglo(_Jefes, False)
            _Filtro_Jefes = " And CodFuncionario Not In " & _Filtro_Jefes

        End If

        Dim _Filtro_Productos = Generar_Filtro_IN_Arreglo(_Lista_Productos, False)

        If Not CBool(_Lista_Productos.Count) Then

            Return True

        End If

        Dim _Tbl_Validadores As DataTable

        Consulta_sql = "Select Distinct CodFuncionario From " & _Global_BaseBk & "Zw_Prod_Usuario_Validador 
                        Where Empresa = '" & ModEmpresa & "' And Codigo In " & _Filtro_Productos & _Filtro_Jefes & " Order By CodFuncionario"
        _Tbl_Validadores = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos Where CodPermiso = 'Comp0095'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        For Each _Fila_Val As DataRow In _Tbl_Validadores.Rows

            _Orden += 1
            _Contador_Permisos += 1

            Dim _CodValidador = _Fila_Val.Item("CodFuncionario")

            Consulta_sql = "Select * From TABFU Where KOFU = '" & _CodValidador & "'"
            Dim _Row_Tabfuvalidador As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Tabfuvalidador) Then

                Dim _Descripcion = "AUTORIZAR COMPRA (SOC) (VALIDAR PROD. A COMPRAR (NIVEL " & _Orden & ")"

                Dim _Row_Det As DataRow = Fx_Cadena_Remota_Nueva_Linea_Det("Comp0095", UCase(_Descripcion), _Orden, _Orden, 0)

                If Not (_Row_Det Is Nothing) Then

                    Dim _Id_Det = _Row_Det.Item("Id_Det")

                    Fx_Cadena_Remota_Nueva_Linea_Usu(_Id_Det, _CodValidador, "Comp0095", _Orden)

                End If

            Else

                If Not IsNothing(_Row_Tabfuvalidador) Then
                    _Error = "El usuario " & _CodValidador & " - " & Trim(_Row_Tabfuvalidador.Item("NOKOFU")) & " no tiene permisos para hacer esta gestión"
                Else
                    _Error = "No existe el usuario: " & _CodValidador
                End If

                Return False

            End If

        Next

        Return True

    End Function

End Class
