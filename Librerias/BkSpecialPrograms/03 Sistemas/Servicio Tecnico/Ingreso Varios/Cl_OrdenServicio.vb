Imports System.Data.SqlClient

Public Class Cl_OrdenServicio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property DsDocumento As DataSet
    Public Property RowEntidad As DataRow
    Public Property OrdenGrabada As Boolean

    Public Sub New()

    End Sub


    Sub Sb_New_OT_Nueva_OT()

        Consulta_sql = My.Resources.Recursos_Locales.SqlQuery_Traer_OT
        Consulta_sql = Replace(Consulta_sql, "#Id_Ot#", 0)
        Consulta_sql = Replace(Consulta_sql, "#Db_BakApp#", _Global_BaseBk)

        _DsDocumento = _Sql.Fx_Get_DataSet(Consulta_sql, False)

        Sb_New_OT_Agregar_Filas(1)

    End Sub

    Sub Sb_New_OT_Agregar_Filas(_Id_Ot As Integer)

        'Dim _Id_Ot As Integer = _DsDocumento.Tables(0).Rows.Count + 1

        Dim NewFila As DataRow
        NewFila = _DsDocumento.Tables(0).NewRow
        With NewFila

            .Item("Id_Ot") = _Id_Ot
            .Item("Nro_Ot") = "En proceso..."
            .Item("Fecha_Ingreso") = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            .Item("Empresa") = ModEmpresa
            .Item("Sucursal") = ModSucursal
            .Item("Bodega") = ModBodega

            .Item("CodEntidad") = _RowEntidad.Item("KOEN")
            .Item("SucEntidad") = _RowEntidad.Item("SUEN")
            .Item("Rten") = _RowEntidad.Item("RTEN")

            Dim _Rt = _RowEntidad.Item("RTEN")
            Dim _Rut As String = FormatNumber(_Rt, 0) & "-" & RutDigito(_Rt)
            .Item("Rut") = _Rut

            .Item("Cliente") = _RowEntidad.Item("NOKOEN")

            .Item("CodEstado") = "I"
            .Item("Estado") = "Ingresado"

            .Item("Codigo") = String.Empty
            .Item("Descripcion") = String.Empty

            .Item("Pais") = _RowEntidad.Item("PAEN").ToString.Trim
            .Item("Ciudad") = _RowEntidad.Item("CIEN").ToString.Trim
            .Item("Comuna") = _RowEntidad.Item("CMEN").ToString.Trim
            .Item("Direccion") = _RowEntidad.Item("DIEN").ToString.Trim

            .Item("Chk_Equipo_Reparado") = False
            .Item("Idmaeedo_COV") = 0
            .Item("Nudo_COV") = String.Empty
            .Item("Neto") = 0
            .Item("Iva") = 0
            .Item("Iva") = 0

            _DsDocumento.Tables(0).Rows.Add(NewFila)

        End With

    End Sub

    Sub Sb_Agregar_Producto(_Id_Ot As Integer,
                            _Codigo As String,
                            _Descripcion As String,
                            _Nro_Serie As String,
                            _Chk_Serv_Domicilio As Boolean,
                            _Chk_Serv_Reparacion_Stock As Boolean,
                            _Chk_Serv_Mantenimiento_Correctivo As Boolean,
                            _Chk_Serv_Presupuesto_Pre_Aprobado As Boolean,
                            _Chk_Serv_Recoleccion As Boolean,
                            _Chk_Serv_Mantenimiento_Preventivo As Boolean,
                            _Chk_Serv_Garantia As Boolean,
                            _Chk_Serv_Demostracion_Maquina As Boolean,
                            _Defecto_segun_cliente As String,
                            _Nota_Etapa_01 As String,
                            _Cantidad As Integer)

        For Each _Fila As DataRow In DsDocumento.Tables(0).Rows

            With _Fila

                If .Item("Id_Ot") = _Id_Ot Then

                    .Item("NroSerie") = _Nro_Serie
                    .Item("NroOcc_Cliente") = String.Empty
                    .Item("Codigo") = _Codigo
                    .Item("Descripcion") = _Descripcion
                    .Item("Chk_Serv_Domicilio") = _Chk_Serv_Domicilio
                    .Item("Chk_Serv_Reparacion_Stock") = _Chk_Serv_Reparacion_Stock
                    .Item("Chk_Serv_Mantenimiento_Correctivo") = _Chk_Serv_Mantenimiento_Correctivo
                    .Item("Chk_Serv_Presupuesto_Pre_Aprobado") = _Chk_Serv_Presupuesto_Pre_Aprobado
                    .Item("Chk_Serv_Recoleccion") = _Chk_Serv_Recoleccion
                    .Item("Chk_Serv_Mantenimiento_Preventivo") = _Chk_Serv_Mantenimiento_Preventivo
                    .Item("Chk_Serv_Garantia") = _Chk_Serv_Garantia
                    .Item("Chk_Serv_Demostracion_Maquina") = _Chk_Serv_Demostracion_Maquina
                    .Item("Cantidad") = _Cantidad

                    Dim NewFila = _DsDocumento.Tables(3).NewRow

                    With NewFila

                        .Item("Id_Ot") = _Id_Ot
                        .Item("Defecto_segun_cliente") = _Defecto_segun_cliente
                        .Item("Reparacion_a_realizar") = String.Empty
                        .Item("Defecto_encontrado") = String.Empty
                        .Item("Reparacion_Realizada") = String.Empty
                        .Item("Chk_no_se_pudo_reparar") = False
                        .Item("Motivo_no_reparo") = String.Empty
                        .Item("Nota_Etapa_01") = _Nota_Etapa_01

                        _DsDocumento.Tables(3).Rows.Add(NewFila)

                    End With

                End If

            End With

        Next

    End Sub

    Sub Sb_Agregar_Garantia(_Id_Ot As Integer,
                            _Idmaeedo As Integer,
                            _Tido As String,
                            _Nudo As String,
                            _Fecha_Doc As Date,
                            _Documento_Externo As Boolean)

        Dim NewFila = _DsDocumento.Tables(6).NewRow

        With NewFila

            .Item("Id_Ot") = _Id_Ot
            .Item("Idmaeedo") = _Idmaeedo
            .Item("Tido") = _Tido
            .Item("Nudo") = _Nudo
            .Item("Estado") = "G"
            .Item("Fecha_Doc") = _Fecha_Doc
            .Item("Garantia") = True
            .Item("Documento_Externo") = _Documento_Externo

            _DsDocumento.Tables(6).Rows.Add(NewFila)

        End With

    End Sub

    Function Fx_Trae_Datarow(_Id_Ot As Integer, _IdTbl As Integer) As DataRow

        For Each _Fila As DataRow In DsDocumento.Tables(_IdTbl).Rows

            If _Id_Ot = _Fila.Item("Id_Ot") Then
                Return _Fila
            End If

        Next

    End Function

    Function Fx_Eliminar_SubOrden(_Id_Ot) As Boolean

        If _Id_Ot = 1 Then

            Dim _Row0 As DataRow = Fx_Trae_Datarow(_Id_Ot, 0)

            _Row0.Item("Codigo") = String.Empty
            _Row0.Item("Descripcion") = String.Empty
            _Row0.Item("NroSerie") = String.Empty
            _Row0.Item("Chk_Serv_Domicilio") = False
            _Row0.Item("Chk_Serv_Reparacion_Stock") = False
            _Row0.Item("Chk_Serv_Mantenimiento_Correctivo") = False
            _Row0.Item("Chk_Serv_Presupuesto_Pre_Aprobado") = False
            _Row0.Item("Chk_Serv_Recoleccion") = False
            _Row0.Item("Chk_Serv_Mantenimiento_Preventivo") = False
            _Row0.Item("Chk_Serv_Garantia") = False
            _Row0.Item("Chk_Serv_Demostracion_Maquina") = False

        Else
            Fx_Borrar_Fila(_Id_Ot, 0)
        End If

        Fx_Borrar_Fila(_Id_Ot, 1)
        Fx_Borrar_Fila(_Id_Ot, 2)
        Fx_Borrar_Fila(_Id_Ot, 3)
        Fx_Borrar_Fila(_Id_Ot, 4)
        Fx_Borrar_Fila(_Id_Ot, 5)
        Fx_Borrar_Fila(_Id_Ot, 6)
        Fx_Borrar_Fila(_Id_Ot, 7)
        Fx_Borrar_Fila(_Id_Ot, 8)

        Return True

    End Function

    Function Fx_Borrar_Fila(_Id_Ot As Integer, _IdTbl As Integer) As Boolean

        Dim _FilaBorrar As DataRow

        For Each _Fila In DsDocumento.Tables(_IdTbl).Rows
            If _Fila("Id_Ot") = _Id_Ot Then
                _FilaBorrar = _Fila
                Exit For
            End If
        Next

        If Not IsNothing(_FilaBorrar) Then
            DsDocumento.Tables(_IdTbl).Rows.Remove(_FilaBorrar)
        End If

        Return True

    End Function


    Function Fx_Crear_OT(_Nro_Ot As String,
                         _Id_Ot_Padre As Integer,
                         _Sub_Ot As String,
                         _Pertenece As String,
                         _Row_Encabezado As DataRow,
                         _Row_Notas As DataRow,
                         _Row_Garantia As DataRow) As NuevaOt

        Dim _NuevaOt As New NuevaOt
        Dim _Id_Ot As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        Dim _Tipo_compra As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Cn As New SqlConnection

        Try


            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            ' INSERTAR ENCABEZADO DE DOCUMENTO

            If String.IsNullOrEmpty(_Nro_Ot) Then
                _Nro_Ot = Fx_NvoNro_OT()
            End If


            Dim _Fecha_Ingreso As String = Format("yyyyMMdd", FechaDelServidor)
            Dim _Fecha_Compromiso
            Dim _Fecha_Entrega

            Dim _CodEstado As String = _Row_Encabezado.Item("CodEstado")

            Dim _Empresa As String = _Row_Encabezado.Item("Empresa")
            Dim _Sucursal As String = _Row_Encabezado.Item("Sucursal")
            Dim _Bodega As String = _Row_Encabezado.Item("Bodega")


            Dim _CodEntidad As String = _Row_Encabezado.Item("CodEntidad")
            Dim _SucEntidad As String = _Row_Encabezado.Item("SucEntidad")
            Dim _Rten As String = _Row_Encabezado.Item("Rten")

            Dim _Rut As String = _Row_Encabezado.Item("Rut")
            Dim _CodMaquina As String = NuloPorNro(_Row_Encabezado.Item("CodMaquina"), "")
            Dim _CodMarca As String = NuloPorNro(_Row_Encabezado.Item("CodMarca"), "")
            Dim _CodModelo As String = NuloPorNro(_Row_Encabezado.Item("CodModelo"), "")
            Dim _CodCategoria As String = NuloPorNro(_Row_Encabezado.Item("CodCategoria"), "")
            Dim _NroSerie As String = _Row_Encabezado.Item("NroSerie")
            Dim _NroOcc_Cliente As String = _Row_Encabezado.Item("NroOcc_Cliente")

            Dim _Chk_Serv_Domicilio As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Domicilio")) * -1

            Dim _Pais As String = _Row_Encabezado.Item("Pais")
            Dim _Ciudad As String = _Row_Encabezado.Item("Ciudad")
            Dim _Comuna As String = _Row_Encabezado.Item("Comuna")
            Dim _Direccion As String = _Row_Encabezado.Item("Direccion")

            Dim _Chk_Serv_Reparacion_Stock As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Reparacion_Stock")) * -1
            Dim _Chk_Serv_Mantenimiento_Correctivo As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Mantenimiento_Correctivo")) * -1
            Dim _Chk_Serv_Presupuesto_Pre_Aprobado As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Presupuesto_Pre_Aprobado")) * -1
            Dim _Chk_Serv_Recoleccion As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Recoleccion")) * -1
            Dim _Chk_Serv_Mantenimiento_Preventivo As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Mantenimiento_Preventivo")) * -1
            Dim _Chk_Serv_Garantia As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Garantia")) * -1
            Dim _Chk_Serv_Demostracion_Maquina As Integer = CInt(_Row_Encabezado.Item("Chk_Serv_Demostracion_Maquina")) * -1

            Dim _Nombre_Contacto As String = _Row_Encabezado.Item("Nombre_Contacto").ToString.Trim
            Dim _Telefono_Contacto As String = _Row_Encabezado.Item("Telefono_Contacto").ToString.Trim
            Dim _Email_Contacto As String = _Row_Encabezado.Item("Email_Contacto").ToString.Trim

            Dim _Chk_Equipo_Reparado As Integer = NuloPorNro(_Row_Encabezado.Item("Chk_Equipo_Reparado"), 0)
            Dim _Idmaeedo_COV As String = NuloPorNro(_Row_Encabezado.Item("Idmaeedo_COV"), 0)
            Dim _Nudo_COV As String = NuloPorNro(_Row_Encabezado.Item("Nudo_COV"), "")
            Dim _Neto As String = NuloPorNro(_Row_Encabezado.Item("Neto"), 0)
            Dim _Iva As String = NuloPorNro(_Row_Encabezado.Item("Iva"), 0)
            Dim _Total As String = NuloPorNro(_Row_Encabezado.Item("Total"), 0)

            Dim _Codigo_Pr As String = _Row_Encabezado.Item("Codigo")
            Dim _Descripcion_Pr As String = _Row_Encabezado.Item("Descripcion")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Encabezado (Nro_Ot,Empresa,Sucursal,Bodega,Fecha_Ingreso,Fecha_Compromiso," &
                           "Fecha_Entrega,CodEstado,CodEntidad,SucEntidad,Rten,Rut,CodMarca,CodModelo,CodMaquina,CodCategoria,NroSerie," &
                           "NroOcc_Cliente,Chk_Serv_Domicilio,Pais,Ciudad,Comuna,Direccion,Chk_Serv_Reparacion_Stock,Chk_Serv_Mantenimiento_Correctivo," &
                           "Chk_Serv_Presupuesto_Pre_Aprobado,Chk_Serv_Recoleccion,Chk_Serv_Mantenimiento_Preventivo," &
                           "Chk_Serv_Garantia,Chk_Serv_Demostracion_Maquina,Chk_Equipo_Reparado,Idmaeedo_COV,Nudo_COV,Neto,Iva,Total," &
                           "Nombre_Contacto,Telefono_Contacto,Email_Contacto,Codigo,Descripcion,Sub_Ot,Pertenece) Values " & vbCrLf &
                           "('" & _Nro_Ot & "','" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',GetDate(),Null,Null,'" & _CodEstado &
                           "','" & _CodEntidad & "','" & _SucEntidad & "','" & _Rten & "','" & _Rut & "','" & _CodMarca & "','" & _CodModelo & "','" & _CodMaquina &
                           "','" & _CodCategoria & "','" & _NroSerie & "','" & _NroOcc_Cliente & "'," & _Chk_Serv_Domicilio &
                           ",'" & _Pais & "','" & _Ciudad & "','" & _Comuna & "','" & _Direccion &
                           "'," & _Chk_Serv_Reparacion_Stock & "," & _Chk_Serv_Mantenimiento_Correctivo &
                           "," & _Chk_Serv_Presupuesto_Pre_Aprobado & "," & _Chk_Serv_Recoleccion &
                           "," & _Chk_Serv_Mantenimiento_Preventivo & "," & _Chk_Serv_Garantia &
                           "," & _Chk_Serv_Demostracion_Maquina & "," & _Chk_Equipo_Reparado &
                           ",0,'',0,0,0,'" & _Nombre_Contacto & "','" & _Telefono_Contacto & "','" & _Email_Contacto & "'" &
                           ",'" & _Codigo_Pr & "','" & _Descripcion_Pr & "','" & _Sub_Ot & "','" & _Pertenece & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            ' RESCATAMOS EL ID_OT 
            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Id_Ot = dfd("Identity")
            End While
            dfd.Close()

            If Not CBool(_Id_Ot_Padre) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set Id_Ot_Padre = " & _Id_Ot & vbCrLf &
                               "Where Id_Ot = " & _Id_Ot

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
            End If


            ' --------------------------------------------------- DETALLE CHEK-IN ---------------------------------------

            'If _Tbl_ChekIn.Rows.Count > 0 Then

            '    For Each _Fila As DataRow In _Tbl_ChekIn.Rows

            '        Dim Estado As DataRowState = _Fila.RowState

            '        If Estado <> DataRowState.Deleted Then

            '            Dim _Codigo As String = _Fila.Item("Codigo")
            '            Dim _Check_In As String = _Fila.Item("Check_In")
            '            Dim _Nota As String = _Fila.Item("Nota")

            '            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_CheckIn (Id_Ot,Codigo,Check_In,Nota) Values " &
            '                          "(" & _Id_Ot & ",'" & _Codigo & "','" & _Check_In & "','" & _Nota & "')"

            '            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            '            Comando.Transaction = myTrans
            '            Comando.ExecuteNonQuery()

            '        End If

            '    Next

            'End If


            ' --------------------------------------------------- DETALLE ACCESORIOS ---------------------------------------

            'If _Tbl_Accesorios.Rows.Count > 0 Then

            '    'For i As Integer = 0 To TblDetalle.Rows.Count - 1
            '    For Each _Fila As DataRow In _Tbl_Accesorios.Rows

            '        Dim Estado As DataRowState = _Fila.RowState

            '        If Estado <> DataRowState.Deleted Then

            '            Dim _Codigo As Integer = CInt(_Fila.Item("Codigo")) * -1
            '            Dim _Articulo As String = _Fila.Item("Articulo")
            '            Dim _Cantidad As String = De_Num_a_Tx_01(_Fila.Item("Cantidad"), False, 5)
            '            Dim __NroSerie As String = _Fila.Item("NroSerie")
            '            Dim _Nota As String = _Fila.Item("Nota")

            '            Consulta_sql = "Insert Into " & _Global_BaseBk &
            '                          "Zw_St_OT_Accesorios (Id_Ot,Codigo,Articulo,Cantidad,NroSerie,Nota) Values " &
            '                          "(" & _Id_Ot & ",'" & _Codigo & "','" & _Articulo & "'," & _Cantidad &
            '                          ",'" & __NroSerie & "','" & _Nota & "')"

            '            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            '            Comando.Transaction = myTrans
            '            Comando.ExecuteNonQuery()

            '        End If

            '    Next

            'End If

            ' --------------------------------------------------- NOTAS ---------------------------------------

            Dim _Defecto_segun_cliente As String = _Row_Notas.Item("Defecto_segun_cliente")
            Dim _Nota_Etapa_01 As String = _Row_Notas.Item("Nota_Etapa_01")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Notas (Id_Ot,Defecto_segun_cliente,Nota_Etapa_01) Values " &
                          "(" & _Id_Ot & ",'" & _Defecto_segun_cliente & "','" & _Nota_Etapa_01 & "')"


            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            '**********************************'************************************************************************************


            ' --------------------------------------------------- ESTADO ---------------------------------------

            Consulta_sql = "Insert Into " & _Global_BaseBk &
                           "Zw_St_OT_Estados (Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                           "(" & _Id_Ot & ",'I',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            '**********************************'*************************************************************************************


            ' --------------------------------------------------- GARANTIA ---------------------------------------
            If Not IsNothing(_Row_Garantia) Then ' Chk_Serv_Garantia.Checked Then

                Dim _Idmaeedo = _Row_Garantia.Item("Idmaeedo")
                Dim _Tido = _Row_Garantia.Item("Tido")
                Dim _Nudo = _Row_Garantia.Item("Nudo")
                Dim _Fecha_Doc = Format(_Row_Garantia.Item("Fecha_Doc"), "yyyyMMdd")
                Dim _Documento_Externo = Convert.ToInt32(_Row_Garantia.Item("Documento_Externo"))

                Consulta_sql = "Insert Into " & _Global_BaseBk &
                               "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Asociacion," &
                               "Fecha_Doc,Garantia,Documento_Externo) Values " &
                               "(" & _Id_Ot & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo &
                               "','G',GetDate(),'" & _Fecha_Doc & "',1," & _Documento_Externo & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            '**********************************'**********************************

            _NuevaOt.EsCorrecto = True
            _NuevaOt.Id_Ot = _Id_Ot
            _NuevaOt.Nro_Ot = _Nro_Ot
            _NuevaOt.Sub_Ot = _Sub_Ot

            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

        Catch ex As Exception

            _NuevaOt.EsCorrecto = False
            _NuevaOt.Id_Ot = 0
            _NuevaOt.Nro_Ot = String.Empty
            _NuevaOt.Sub_Ot = String.Empty
            _NuevaOt.ErrorGrabar = ex.Message

            myTrans.Rollback()

        End Try

        Return _NuevaOt

    End Function

    Function Fx_NvoNro_OT() As String

        Dim _NvoNro_OT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Nro_Ot) As Ult_Nro_OT From " & _Global_BaseBk & "Zw_St_OT_Encabezado") ' cn1, "MAX(Nro_SOC)", _Global_BaseBk & "ZW_SOC_Encabezado", "Stand_By = " & Stby)

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Ult_Nro_OT"), "")

            If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
                _Ult_Nro_OT = 1
            Else
                _Ult_Nro_OT += 1
            End If
            _NvoNro_OT = numero_(Val(_Ult_Nro_OT), 10)
        Else
            _NvoNro_OT = numero_(1, 10)
        End If

        Return _NvoNro_OT

    End Function

End Class

Public Class NuevaOt

    Public Property Id_Ot As Integer
    Public Property Nro_Ot As String
    Public Property Sub_Ot As String
    Public Property EsCorrecto As Boolean
    Public Property ErrorGrabar As String

End Class
