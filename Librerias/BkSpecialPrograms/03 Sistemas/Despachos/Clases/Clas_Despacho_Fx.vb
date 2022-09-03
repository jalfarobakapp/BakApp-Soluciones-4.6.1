Imports System.Data.SqlClient

Public Class Clas_Despacho_Fx

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Error As String

    Public Property [Error] As String
        Get
            Return _Error
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

    Sub Sb_Actualizar_Despachos()

        ' Actualiza despachos que se han facturado y aun estan en estado Ingresado

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos 
                        Where Estado = 'ING' And Confirmado = 1 And Nro_Sub = '000'"

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Id_Despacho_Padre = Id_Despacho Where Id_Despacho_Padre = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Distinct Id_Despacho,Id_Despacho_Padre As Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
                        Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc " &
                        "Where CantC > CantD+CantE+CantR And Archidrst = 'MAEEDO') 
                        And Estado In ('ING')--And Reasignado = 0)"

        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Despacho = _Fila.Item("Id_Despacho")
            Dim _Id_Despacho_Padre = _Fila.Item("Id_Despacho")

            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            If Not _Cl_Despacho.Fx_Insertar_Facturas_VS_Notas_De_Venta_Facturadas Then
                Fx_Insertar_Facturas_Boletas_Desde_Vales_Transitorios(_Id_Despacho, _Id_Despacho_Padre)
            End If

        Next

    End Sub

    Sub Sb_Actualizar_Despachos(_Id_Despacho As Integer)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Id_Despacho_Padre = Id_Despacho Where Id_Despacho_Padre = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Cl_Despacho As New Clas_Despacho(False)
        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        Dim _Id_Despacho_Padre = _Cl_Despacho.Id_Despacho_Padre

        If Not _Cl_Despacho.Fx_Insertar_Facturas_VS_Notas_De_Venta_Facturadas Then
            If Fx_Insertar_Facturas_Boletas_Desde_Vales_Transitorios(_Id_Despacho, _Id_Despacho_Padre) Then
                Dim _Cldespacho_Fx As New Clas_Despacho_Fx
                _Cldespacho_Fx.Fx_Enviar_Correo_Al_Diablito(_Id_Despacho) ', Row_Despacho)
            End If
        End If

    End Sub

    Function Fx_Insertar_Facturas_Boletas_Desde_Vales_Transitorios(_Id_Despacho As Integer, _Id_Despacho_Padre As Integer) As Boolean

        Consulta_sql = "Select Top 1 IDMAEEDO,NUDO,NUDONODEFI 
                        From MAEEDO Edo 
                        Inner Join " & _Global_BaseBk & "Zw_Despachos_Doc Doc On Doc.Archidrst = 'MAEEDO' And Doc.Idrst = Edo.IDMAEEDO 
                        Where Id_Despacho = " & _Id_Despacho & " And TIDO In ('BLV','FCV') And Doc.Nudonodefi = 1"

        Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Documento) Then
            Return False
        End If

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Nudo As String = _Row_Documento.Item("NUDO")
        Dim _Nudonodefi As Boolean = _Row_Documento.Item("NUDONODEFI")

        If Not _Nudonodefi Then


            Dim _Nro_Despacho As String = Fx_Nuevo_Nro_Despacho(True)

            'Dim _Id_Despacho_Padre = _Id_Despacho

            Dim _myTrans As SqlClient.SqlTransaction
            Dim _Comando As SqlClient.SqlCommand

            Dim _Sql2 As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim _Cn As New SqlConnection

            Try

                _Sql2.Sb_Abrir_Conexion(_Cn)
                _myTrans = _Cn.BeginTransaction()

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Nro_Despacho = '" & _Nro_Despacho & "',Confirmado = 1,Estado = 'PRE'
                                Where Id_Despacho_Padre = " & _Id_Despacho_Padre & "
                                Update " & _Global_BaseBk & "Zw_Despachos_Doc Set Nro_Despacho = '" & _Nro_Despacho & "',Nudo = '" & _Nudo & "',Nudonodefi = 0
                                Where Idrst = " & _Idmaeedo & "
                                Update " & _Global_BaseBk & "Zw_Despachos_Doc_Det Set Nro_Despacho = '" & _Nro_Despacho & "',Nudo = '" & _Nudo & "'
                                Where Idmaeedo = " & _Idmaeedo

                _Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                _Comando.Transaction = _myTrans
                _Comando.ExecuteNonQuery()


                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho_Padre = " & _Id_Despacho_Padre

                _Comando = New SqlCommand(Consulta_sql, _Cn)
                _Comando.Transaction = _myTrans
                Dim dfd As SqlDataReader = _Comando.ExecuteReader()

                Consulta_sql = String.Empty
                Dim _Nro_Sub = 1

                While dfd.Read()

                    _Id_Despacho = dfd("Id_Despacho")

                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_Despachos Set Nro_Sub = '" & numero_(_Nro_Sub, 3) & "' 
                                     Where Id_Despacho = " & _Id_Despacho & vbCrLf &
                                    "Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) 
                                     Values (" & _Id_Despacho & ",'CON','" & FUNCIONARIO & "','Confirmación automatica, desde vale transitorio',Getdate())" & vbCrLf

                    _Nro_Sub += 1

                End While
                dfd.Close()

                _Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                _Comando.Transaction = _myTrans
                _Comando.ExecuteNonQuery()

                'Throw New System.Exception("An exception has occurred.")

                _myTrans.Commit()
                _Sql2.Sb_Cerrar_Conexion(_Cn)

                Return True

            Catch ex As Exception

                MsgBox(ex.Message)
                _myTrans.Rollback()

            End Try

        End If

    End Function

    Function Fx_Nuevo_Nro_Despacho(_Confirmado As Boolean) As String

        Dim _NvoNro_Despacho As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Nro_Despacho) As Ult_Nro_Despacho" & Space(1) &
                                          "From " & _Global_BaseBk & "Zw_Despachos Where Confirmado = " & Convert.ToInt32(_Confirmado))

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Ult_Nro_Despacho"), "")

            _NvoNro_Despacho = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Else

            _NvoNro_Despacho = numero_(1, 10)

            If Not _Confirmado Then
                _NvoNro_Despacho = ""
            End If

        End If

        If Not _Confirmado And _NvoNro_Despacho = "0000000001" Then
            _NvoNro_Despacho = "P000000001"
        End If

        Return _NvoNro_Despacho

    End Function


#Region "Envio de correos"

    Sub Sb_Preparacion_Correo_Por_Ordenes_De_Despacho()

#Region "Preparacion Correo ORDENDES De DESPACHO"

#Region "Procesos antes del cierre"

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Email_Envios (Nro_Despacho,Estado,Para) 
                        Select Distinct Nro_Despacho,Estado,Email From " & _Global_BaseBk & "Zw_Despachos Where Estado In (Select Distinct Estado From " & _Global_BaseBk & "Zw_Despachos_Email_Aviso)
                        And Nro_Despacho+Estado Not In (Select Nro_Despacho+Estado From " & _Global_BaseBk & "Zw_Despachos_Email_Envios Where Enviar = 0) --And Enviado = 1)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Distinct Id_Email,Desp.Nro_Despacho,Desp.Estado,Email_Env.Para,Email_Env.Cc,Tipo_Envio,Tipo_Venta 
                        From " & _Global_BaseBk & "Zw_Despachos Desp
                        Left Join " & _Global_BaseBk & "Zw_Despachos_Email_Envios Email_Env On 
                                    Email_Env.Nro_Despacho = Desp.Nro_Despacho And Email_Env.Estado = Desp.Estado
                        Where Email_Env.Enviar = 1 And Email_Env.Estado <> 'CIE'"

        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Row_Despacho As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Email = _Row_Despacho.Item("Id_Email")
            Dim _Nro_Despacho = _Row_Despacho.Item("Nro_Despacho")
            Dim _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")
            Dim _Tipo_Venta = _Row_Despacho.Item("Tipo_Venta")
            Dim _Estado = _Row_Despacho.Item("Estado")

            Consulta_sql = "Select Top 1 Eaviso.Id,Tipo_Envio,Tipo_Venta,Estado,Id_Correo,Adjuntar_Documentos,Zc.*
                            From " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso
                            Inner Join " & _Global_BaseBk & "Zw_Correos Zc On Eaviso.Id_Correo = Zc.Id
                            Where Tipo_Envio = '" & _Tipo_Envio & "' And Tipo_Venta = '" & _Tipo_Venta & "' And Estado = '" & _Estado & "'"

            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Correo) Then

                Dim _Id_Correo As String = _Row_Correo.Item("Id_Correo")
                Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
                Dim _Adjuntar_Documentos As Boolean = _Row_Correo.Item("Adjuntar_Documentos")

                Dim _Doc_Adjuntos As String = String.Empty

                If _Adjuntar_Documentos Then

                    Consulta_sql = "Select Distinct Idrst,Tido,Nudo From " & _Global_BaseBk & "Zw_Despachos_Doc 
                                    Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
                                    Where Nro_Despacho = '" & _Nro_Despacho & "' And Estado = '" & _Estado & "')"

                    Dim _Tbl_Adjunto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    For Each _FlAdj As DataRow In _Tbl_Adjunto.Rows

                        Dim _Idmaeedo = _FlAdj.Item("Idrst")
                        Dim _Tido = _FlAdj.Item("Tido")
                        Dim _Nudo = _FlAdj.Item("Nudo")

                        If String.IsNullOrEmpty(_Doc_Adjuntos) Then
                            _Doc_Adjuntos += _Tido & "-" & _Nudo
                        Else
                            _Doc_Adjuntos += ";" & _Tido & "-" & _Nudo
                        End If

                    Next

                End If

                Dim _Para As String = _Row_Despacho.Item("Para")
                Dim _Cc As String = _Row_Despacho.Item("Cc")
                Dim _Asunto As String = _Row_Correo.Item("Asunto")
                Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

                If String.IsNullOrEmpty(_Asunto) Then
                    _Asunto = "Correo de notificación de pedido " & RazonEmpresa
                End If

                Dim _Id_Despacho As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos", "Id_Despacho", "Nro_Despacho = '" & _Nro_Despacho & "'")

                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Asunto, _Id_Despacho)
                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Mensaje, _Id_Despacho)
                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(_Mensaje, _Id_Despacho)

                If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                   "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos)" &
                                   vbCrLf &
                                   "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                                   "',0,'','','',1,'" & _Mensaje & "',Getdate()," & Convert.ToInt32(_Adjuntar_Documentos) & ",'" & _Doc_Adjuntos & "')" & vbCrLf & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Despachos_Email_Envios Set 
                                    Enviar = 0,Enviado = 1,Fecha_Envio = Getdate(),Asunto = '" & _Asunto & "',Mensaje = '" & _Mensaje & "',Doc_Adjuntos = '" & _Doc_Adjuntos & "' 
                                    Where Id_Email = " & _Id_Email

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Else

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Email_Envios Set 
                                    Enviar = 0,Enviado = 0,Fecha_Envio = Getdate(),Log_Informacion = 'No existe correo en configuración...' 
                                    Where Id_Email = " & _Id_Email
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        Next

#End Region

#Region "CIERRE"

        Consulta_sql = "Select Distinct Id_Despacho,Nro_Encomienda,Id_Email,Desp.Nro_Despacho,Desp.Estado,Email_Env.Para,Email_Env.Cc,Tipo_Envio,Tipo_Venta 
                        From " & _Global_BaseBk & "Zw_Despachos Desp
                        Left Join " & _Global_BaseBk & "Zw_Despachos_Email_Envios Email_Env On 
                                    Email_Env.Nro_Despacho = Desp.Nro_Despacho And Email_Env.Estado = Desp.Estado
                        Where Email_Env.Enviar = 1 And Email_Env.Estado = 'CIE'"

        _Tbl_Despachos = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Row_Despacho As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Email = _Row_Despacho.Item("Id_Email")
            Dim _Id_Despacho = _Row_Despacho.Item("Id_Despacho")

            Dim _Nro_Despacho = _Row_Despacho.Item("Nro_Despacho")
            Dim _Nro_Encomienda = _Row_Despacho.Item("Nro_Encomienda")
            Dim _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")
            Dim _Tipo_Venta = _Row_Despacho.Item("Tipo_Venta")
            Dim _Estado = _Row_Despacho.Item("Estado")

            Consulta_sql = "Select Eaviso.Id, Tipo_Envio, Tipo_Venta, Estado, Id_Correo, Adjuntar_Documentos,Zc.*
                            From " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso
                            Inner Join " & _Global_BaseBk & "Zw_Correos Zc On Eaviso.Id_Correo = Zc.Id
                            Where Tipo_Envio = '" & _Tipo_Envio & "' And Tipo_Venta = '" & _Tipo_Venta & "' And Estado = '" & _Estado & "'"

            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Correo) Then

                Dim _Id_Correo As String = _Row_Correo.Item("Id_Correo")
                Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")

                Dim _Para As String = _Row_Despacho.Item("Para")
                Dim _Cc = String.Empty
                Dim _Asunto As String = _Row_Correo.Item("Asunto")
                Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

                If String.IsNullOrEmpty(_Asunto) Then
                    _Asunto = "Correo de notificación de pedido " & RazonEmpresa
                End If

                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Ordenes_Cerradas_Documentos_Y_Detalles(_Asunto, _Id_Despacho, _Nro_Encomienda)
                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Ordenes_Cerradas_Documentos_Y_Detalles(_Mensaje, _Id_Despacho, _Nro_Encomienda)

                If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                   "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha)" &
                                   vbCrLf &
                                   "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                                   "',0,'','','',1,'" & _Mensaje & "',Getdate())" & vbCrLf & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Despachos_Email_Envios Set 
                                    Enviar = 0,Enviado = 1,Fecha_Envio = Getdate(),Asunto = '" & _Asunto & "',Mensaje = '" & _Mensaje & "' 
                                    Where Id_Email = " & _Id_Email
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        Next

#End Region

#End Region

    End Sub

    Function Fx_Reenviar_Correo_Al_Diablito(_Id_Despacho As Integer, _Row_Despacho As DataRow, _Estado As String, _Para As String, _Cc As String) As String

        Dim _Error = String.Empty

        Try

            Dim _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")
            Dim _Nro_Despacho = _Row_Despacho.Item("Nro_Despacho")
            Dim _Tipo_Venta = _Row_Despacho.Item("Tipo_Venta")

            Consulta_sql = "Select Top 1 Aviso.Id, Tipo_Envio, Tipo_Venta, Estado, Id_Correo, Adjuntar_Documentos,Corr.Nombre_Correo,Corr.Asunto,Corr.CuerpoMensaje,
                            Aviso.Format_BLV,Aviso.Format_FCV,Aviso.Format_GDV,Aviso.Format_GTI
                            From " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Aviso
                            Inner Join " & _Global_BaseBk & "Zw_Correos Corr On Corr.Id = Aviso.Id_Correo
                            Where Tipo_Envio = '" & _Tipo_Envio & "' And Estado = '" & _Estado & "' And Tipo_Venta = '" & _Tipo_Venta & "'"
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Correo) Then
                Return "No existe configuración para el envio de correos"
            End If

            Dim _Id_Correo As String = _Row_Correo.Item("Id_Correo")
            Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
            Dim _Adjuntar_Documentos As Boolean = _Row_Correo.Item("Adjuntar_Documentos")

            Dim _Asunto As String = _Row_Correo.Item("Asunto")
            Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Correo de notificación de pedido " & RazonEmpresa
            End If

            _Mensaje = Replace(_Mensaje, "&lt;", "<")
            _Mensaje = Replace(_Mensaje, "&gt;", ">")
            _Mensaje = Replace(_Mensaje, "&quot;", """")

            _Mensaje = Replace(_Mensaje, "</span><span class=""st2"">", "")
            _Mensaje = Replace(_Mensaje, "</span><span class=""st1"">", "")

            _Mensaje = Replace(_Mensaje, "'", "''")

            Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(_Asunto, _Id_Despacho)
            Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(_Mensaje, _Id_Despacho)

            If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                Dim _Doc_Adjuntos As String = String.Empty

                If _Adjuntar_Documentos Then

                    Consulta_sql = "Select Distinct Idrst,Tido,Nudo From " & _Global_BaseBk & "Zw_Despachos_Doc 
                                    Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
                                    Where Nro_Despacho = '" & _Nro_Despacho & "' And Estado = '" & _Estado & "')"

                    Dim _Tbl_Adjunto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    For Each _FlAdj As DataRow In _Tbl_Adjunto.Rows

                        Dim _Idmaeedo = _FlAdj.Item("Idrst")
                        Dim _Tido = _FlAdj.Item("Tido")
                        Dim _Nudo = _FlAdj.Item("Nudo")
                        Dim _NombreFormato = _Row_Correo.Item("Format_" & _Tido)

                        _Doc_Adjuntos += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos (Id_Padre,Idmaeedo,Tido,Nudo,NombreFormato) Values " &
                                             "(@Id_Despacho," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _NombreFormato & "')" & vbCrLf

                    Next

                End If

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                               "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos)" &
                                vbCrLf &
                                "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                                "',0,'','','',1,'" & _Mensaje & "',Getdate()," & Convert.ToInt32(_Adjuntar_Documentos) & ",'')

                                Declare @Id_Despacho Int
                                Select @Id_Despacho = @@IDENTITY 

                                " & _Doc_Adjuntos & ""

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                _Error = _Sql.Pro_Error

                If Not String.IsNullOrEmpty(_Error) Then
                    Throw New System.Exception(_Error)
                End If

            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Function Fx_Enviar_Correo_Al_Diablito(_Id_Despacho As Integer)

        Dim _Error = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = " & _Id_Despacho
        Dim _Row_Despacho As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Try

            Dim _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")
            Dim _Estado = _Row_Despacho.Item("Estado")
            Dim _Nro_Despacho = _Row_Despacho.Item("Nro_Despacho")
            Dim _Tipo_Venta = _Row_Despacho.Item("Tipo_Venta")

            Consulta_sql = "Select Top 1 Aviso.Id,Tipo_Envio,Tipo_Venta,Estado,Id_Correo,Adjuntar_Documentos,Corr.Nombre_Correo,Corr.Asunto," &
                           "Corr.CuerpoMensaje,Aviso.Enviar_al_otro_dia,Aviso.Format_BLV,Aviso.Format_FCV,Aviso.Format_GDV,Aviso.Format_GTI
                            From " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Aviso
                            Inner Join " & _Global_BaseBk & "Zw_Correos Corr On Corr.Id = Aviso.Id_Correo
                            Where Tipo_Envio = '" & _Tipo_Envio & "' And Estado = '" & _Estado & "' And Tipo_Venta = '" & _Tipo_Venta & "'"
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Correo) Then
                Return "No existe configuración para el envio de correos"
            End If

            Dim _Id_Correo As String = _Row_Correo.Item("Id_Correo")
            Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
            Dim _Adjuntar_Documentos As Boolean = _Row_Correo.Item("Adjuntar_Documentos")
            Dim _Enviar_al_otro_dia As Boolean = _Row_Correo.Item("Enviar_al_otro_dia")

            Dim _Para As String = _Row_Despacho.Item("Email")
            Dim _Cc As String = String.Empty
            Dim _Asunto As String = _Row_Correo.Item("Asunto")
            Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Correo de notificación de pedido " & RazonEmpresa
            End If

            _Mensaje = Replace(_Mensaje, "&lt;", "<")
            _Mensaje = Replace(_Mensaje, "&gt;", ">")
            _Mensaje = Replace(_Mensaje, "&quot;", """")

            _Mensaje = Replace(_Mensaje, "'", "''")

            Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(_Asunto, _Id_Despacho)
            Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(_Mensaje, _Id_Despacho)

            If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Despachos_Email_Envios 
                                Where Nro_Despacho = '" & _Nro_Despacho & "' And Estado = '" & _Estado & "'"
                Dim _Row_Aviso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_Row_Aviso) Or _Estado = "CIE" Then

                    Dim _Doc_Adjuntos As String = String.Empty

                    If _Adjuntar_Documentos Then

                        Consulta_sql = "Select Distinct Idrst,Tido,Nudo From " & _Global_BaseBk & "Zw_Despachos_Doc 
                                Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
                                Where Nro_Despacho = '" & _Nro_Despacho & "' And Estado = '" & _Estado & "')"

                        Dim _Tbl_Adjunto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        For Each _FlAdj As DataRow In _Tbl_Adjunto.Rows

                            Dim _Idmaeedo = _FlAdj.Item("Idrst")
                            Dim _Tido = _FlAdj.Item("Tido")
                            Dim _Nudo = _FlAdj.Item("Nudo")
                            Dim _NombreFormato = _Row_Correo.Item("Format_" & _Tido)

                            _Doc_Adjuntos += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos (Id_Padre,Idmaeedo,Tido,Nudo,NombreFormato) Values " &
                                             "(@Id_Despacho," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _NombreFormato & "')" & vbCrLf

                        Next

                    End If

                    Dim _Fecha = "Getdate()"

                    If _Enviar_al_otro_dia Then
                        _Fecha = "DATEADD(D,1,Getdate())"
                    End If

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Email_Envios (Nro_Despacho,Estado,Fecha_Envio,Enviar,Enviado,Para,Cc,Asunto,Mensaje,Doc_Adjuntos,Log_Informacion) Values
                                    ('" & _Nro_Despacho & "','" & _Estado & "',Getdate(),1,1,'" & _Para & "','" & _Cc & "','" & _Asunto & "','" & _Mensaje & "','','')

                                    Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                    "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos)" &
                                    vbCrLf &
                                    "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                                    "',0,'','','',1,'" & _Mensaje & "'," & _Fecha & "," & Convert.ToInt32(_Adjuntar_Documentos) & ",'')

                                    Declare @Id_Despacho Int
                                    Select @Id_Despacho = @@IDENTITY 

                                    " & _Doc_Adjuntos & ""

                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                    _Error = _Sql.Pro_Error

                    If Not String.IsNullOrEmpty(_Error) Then
                        Throw New System.Exception(_Error)
                    End If

                End If

            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(ByRef _Texto As String, _Id_Despacho As Integer)

        If Convert.ToBoolean(_Id_Despacho) Then

            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            Dim _Row_Despacho = _Cl_Despacho.Row_Despacho

            _Texto = Replace(_Texto, "<Despacho_Nro_Despacho>", Fx_Parametro_Vs_Variable("<Despacho_Nro_Despacho>", _Row_Despacho))
            _Texto = Replace(_Texto, "<Despacho_Nombre_Entidad>", Fx_Parametro_Vs_Variable("<Despacho_Nombre_Entidad>", _Row_Despacho))

            _Texto = Replace(_Texto, "<Despacho_Transportista > ", Fx_Parametro_Vs_Variable("<Despacho_Transportista>", _Row_Despacho))
            _Texto = Replace(_Texto, "<Despacho_Nro_Encomienda > ", Fx_Parametro_Vs_Variable("<Despacho_Nro_Encomienda>", _Row_Despacho))

        End If

    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(ByRef _Texto As String, _Nro_Despacho As String)

        Dim _Id_Despacho As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos", "Id_Despacho", "Nro_Despacho = '" & _Nro_Despacho & "'")

        If Convert.ToBoolean(_Id_Despacho) Then

            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            Dim _Row_Despacho = _Cl_Despacho.Row_Despacho

            _Texto = Replace(_Texto, "<Despacho_Nro_Despacho>", Fx_Parametro_Vs_Variable("<Despacho_Nro_Despacho>", _Row_Despacho))
            _Texto = Replace(_Texto, "<Despacho_Nombre_Entidad>", Fx_Parametro_Vs_Variable("<Despacho_Nombre_Entidad>", _Row_Despacho))

            _Texto = Replace(_Texto, "<Despacho_Transportista>", Fx_Parametro_Vs_Variable("<Despacho_Transportista>", _Row_Despacho))
            _Texto = Replace(_Texto, "<Despacho_Nro_Encomienda>", Fx_Parametro_Vs_Variable("<Despacho_Nro_Encomienda>", _Row_Despacho))

        End If

    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(ByRef _Texto As String, _Id_Despacho As Integer)

        If Convert.ToBoolean(_Id_Despacho) Then

            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            Dim _Row_Despacho = _Cl_Despacho.Row_Despacho

            Dim _Documentos = String.Empty
            Dim _Documentos2 = String.Empty
            Dim _Contador = 0

            For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")

                _Documentos += _Tido & "-" & _Nudo

                Dim _Nom_Doc = String.Empty

                Select Case _Tido
                    Case "BLV"
                        _Nom_Doc = "Boleta"
                    Case "FCV"
                        _Nom_Doc = "Factura"
                    Case "GDV", "GTI"
                        _Nom_Doc = "Guía"
                    Case Else
                        _Nom_Doc = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Fila.Item("Tido") & "'")
                End Select

                _Documentos2 += _Nom_Doc & " " & _Fila.Item("Nudo")

                _Contador += 1

                If _Contador <> _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count Then
                    _Documentos += ", "
                End If

            Next

            Dim _Detalle_Despacho = String.Empty
            Dim _Nro_Despacho = _Row_Despacho.Item("Nro_Despacho").ToString.Trim
            Dim _Nro_Encomienda = _Row_Despacho.Item("Nro_Encomienda").ToString.Trim

            If Not String.IsNullOrEmpty(_Nro_Encomienda) Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos_Doc_Det " &
                               "Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos " &
                               "Where Nro_Despacho = '" & _Nro_Despacho & "' And Nro_Encomienda = '" & _Nro_Encomienda & "' And CantDUd1 > 0)"

                Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                For Each _FilaD As DataRow In _Tbl_Productos.Rows

                    Dim _Tido_Nudo = _FilaD.Item("Tido") & "-" & _FilaD.Item("Nudo")
                    Dim _Idmaeedo = _FilaD.Item("Idrst")

                    Dim _IdmaeedoD = _FilaD.Item("Idmaeedo")
                    Dim _Codigo = _FilaD.Item("Codigo")
                    Dim _Descripcion = _FilaD.Item("Descripcion").ToString.Trim

                    Dim _DespUd1 = _FilaD.Item("CantDUd1")
                    Dim _DespUd2 = _FilaD.Item("CantDUd2")

                    _Detalle_Despacho += vbTab & " * " & _Codigo & " - " & _Descripcion & ". Cant.: " & _DespUd1 & vbCrLf

                Next

            End If

            _Texto = Replace(_Texto, "<Documentos>", _Documentos)
            _Texto = Replace(_Texto, "<Documentos2>", _Documentos2)
            _Texto = Replace(_Texto, "<Detalle_Despacho>", _Detalle_Despacho)

            Dim _Funciones As New List(Of String)

            '_Texto = Replace(_Texto, "<img src=""cid:", "")
            '_Texto = Replace(_Texto, """>", "")
            '_Texto = Replace(_Texto, "<span class=""st", "")
            '_Texto = Replace(_Texto, "</span>", "")
            '_Texto = Replace(_Texto, "</p>", "")
            '_Texto = Replace(_Texto, "<p style=", "")
            '_Texto = Replace(_Texto, "<br/>", "")

            Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

            'ExportarTabla_JetExcel_Tabla(_Cl_Despacho.Row_Despacho.Table, Nothing, "Orden_Despacho")

            For Each _Funcion As String In _Funciones

                For Each _Columna As DataColumn In _Cl_Despacho.Row_Despacho.Table.Columns

                    If _Funcion.Contains(_Columna.ColumnName) Then

                        Dim _Funcion_Buscar = "<" & _Funcion & ">"
                        Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Cl_Despacho.Row_Despacho)

                        _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                        Exit For

                    End If

                Next

            Next

        End If

        _Texto = Replace(_Texto, "@Img_Ini", "<img src=""cid:")
        _Texto = Replace(_Texto, "@Img_Fin", """>")

        '@Img_Ini
        '@Img_Fin

        _Texto = Replace(_Texto, "", "")

    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Ordenes_Cerradas_Documentos_Y_Detalles(ByRef _Texto As String,
                                                                                                 _Nro_Despacho As String,
                                                                                                 _Nro_Encomienda As String)

        Dim _Documentos As String
        Dim _Detalle_Despacho As String


        Consulta_sql = "Select Distinct Id_Despacho 
                        From " & _Global_BaseBk & "Zw_Despachos
                        Where Nro_Despacho = '" & _Nro_Despacho & "' And Nro_Encomienda = '" & _Nro_Encomienda & "'"
        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Despacho As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Despacho As Integer = _Despacho.Item("Id_Despacho")

            Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Texto, _Id_Despacho)

            If Convert.ToBoolean(_Id_Despacho) Then

                Dim _Cl_Despacho As New Clas_Despacho(False)
                _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
                Dim _Row_Despacho As DataRow = _Cl_Despacho.Row_Despacho

                _Row_Despacho = _Cl_Despacho.Row_Despacho

                Dim _Contador = 0

                If Not String.IsNullOrEmpty(_Documentos) Then
                    _Documentos += ", "
                End If

                For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                    _Documentos += _Fila.Item("Tido") & "-" & _Fila.Item("Nudo")

                    _Contador += 1

                    If _Contador <> _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count Then
                        _Documentos += ", "
                    End If

                Next

                For Each _FilaE As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                    Dim _Tido_Nudo = _FilaE.Item("Tido") & "-" & _FilaE.Item("Nudo")
                    Dim _Idmaeedo = _FilaE.Item("Idrst")

                    For Each _FilaD As DataRow In _Cl_Despacho.Tbl_Despacho_Doc_Det.Rows

                        Dim _IdmaeedoD = _FilaD.Item("Idmaeedo")
                        Dim _Codigo = _FilaD.Item("Codigo")
                        Dim _Descripcion = _FilaD.Item("Descripcion")

                        Dim _DespUd1 = _FilaD.Item("DespUd1")
                        Dim _DespUd2 = _FilaD.Item("DespUd2")

                        If _Idmaeedo = _IdmaeedoD Then

                            _Detalle_Despacho += Space(5) & " * (" & _Tido_Nudo & "), " & _Codigo & " - " & _Descripcion & " X " & _DespUd1 & vbCrLf

                        End If

                    Next

                Next

            End If

        Next

        _Texto = Replace(_Texto, "<Despacho_Documentos>", _Documentos)
        _Texto = Replace(_Texto, "<Despacho_Detalle_Despacho>", _Detalle_Despacho)

    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Ordenes_Cerradas_Documentos_Y_Detalles(ByRef _Texto As String,
                                                                            _Id_Despacho_Padre As Integer,
                                                                            _Nro_Encomienda As String)

        Dim _Documentos As String
        Dim _Detalle_Despacho As String


        Consulta_sql = "Select Distinct Id_Despacho 
                        From " & _Global_BaseBk & "Zw_Despachos
                        Where (Id_Despacho_Padre = " & _Id_Despacho_Padre & " Or Id_Despacho = " & _Id_Despacho_Padre & ")" &
                        " And Nro_Encomienda = '" & _Nro_Encomienda & "'"
        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Despacho As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Despacho As Integer = _Despacho.Item("Id_Despacho")


            Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Texto, _Id_Despacho)


            If Convert.ToBoolean(_Id_Despacho) Then

                Dim _Cl_Despacho As New Clas_Despacho(False)
                _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
                Dim _Row_Despacho As DataRow = _Cl_Despacho.Row_Despacho

                _Row_Despacho = _Cl_Despacho.Row_Despacho

                Dim _Contador = 0

                If Not String.IsNullOrEmpty(_Documentos) Then
                    _Documentos += ", "
                End If

                For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                    _Documentos += _Fila.Item("Tido") & "-" & _Fila.Item("Nudo")

                    _Contador += 1

                    If _Contador <> _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count Then
                        _Documentos += ", "
                    End If

                Next

                For Each _FilaE As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                    Dim _Tido_Nudo = _FilaE.Item("Tido") & "-" & _FilaE.Item("Nudo")
                    Dim _Idmaeedo = _FilaE.Item("Idrst")

                    For Each _FilaD As DataRow In _Cl_Despacho.Tbl_Despacho_Doc_Det.Rows

                        Dim _IdmaeedoD = _FilaD.Item("Idmaeedo")
                        Dim _Codigo = _FilaD.Item("Codigo")
                        Dim _Descripcion = _FilaD.Item("Descripcion")

                        Dim _CantCUd1 = _FilaD.Item("CantCUd1")
                        Dim _CantCUd2 = _FilaD.Item("CantCUd2")

                        If _Idmaeedo = _IdmaeedoD Then

                            _Detalle_Despacho += Space(5) & " * (" & _Tido_Nudo & "), " & _Codigo & " - " & _Descripcion & " X " & _CantCUd1 & vbCrLf

                        End If

                    Next

                Next

            End If

        Next

        _Texto = Replace(_Texto, "<Despacho_Documentos>", _Documentos)
        _Texto = Replace(_Texto, "<Despacho_Detalle_Despacho>", _Detalle_Despacho)

    End Sub

    Private Function Fx_Parametro_Vs_Variable(_Parametro As String, _Row As DataRow) As String

        Dim _Valor
        Dim _Valor_Devuelto = String.Empty
        Dim _Type As String

        Try

            Dim _Vl = Split(Replace(Replace(_Parametro, "<", ""), ">", ""), ",")

            Dim _Campo As String = _Vl(0)
            Dim _Formato As String
            Dim _Rango_Desde As Integer
            Dim _Rango_Hasta As Integer

            If _Parametro.Contains(",") Then
                If _Vl.Length = 3 Then
                    Try
                        _Rango_Desde = _Vl(1)
                        _Rango_Hasta = _Vl(2)
                    Catch ex As Exception
                        Throw New System.Exception(ex.Message)
                    End Try
                End If
                If _Vl.Length = 2 Then
                    _Formato = _Vl(1).ToUpper
                End If
            End If

            _Campo = Replace(_Campo.ToUpper, "DOC_", "").ToUpper
            _Campo = Replace(_Campo.ToUpper, "DESPACHO_", "").ToUpper

            Try

                _Type = _Row.Item(_Campo).GetType.ToString

                Select Case _Parametro

                    Case "<Doc_Vanedo,0>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                    Case "<Doc_Vanedo,1>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 1)

                    Case "<Doc_Vanedo,2>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 2)

                    Case "<Doc_Vabrdo>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                    Case "<Doc_Feemdo>", "<Doc_Feemdo,1>"

                        _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.ShortDate)

                    Case "<Doc_Feemdo,2>"

                        _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.LongDate)

                    Case Else

                        _Valor = _Row.Item(_Campo)

                End Select


                If _Type.Contains("Double") Or _Type.Contains("Int") Then

                    If Not IsNothing(_Formato) Then
                        If _Formato.ToUpper.Contains("C") Then
                            Select Case _Formato
                                Case "C1"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 1)
                                Case "C2"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 2)
                                Case "C3"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 3)
                                Case Else
                                    _Valor_Devuelto = FormatCurrency(_Valor, 0)
                            End Select
                        End If

                        If _Formato.ToUpper.Contains("N") Then
                            Select Case _Formato
                                Case "N1"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 1)
                                Case "N2"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 2)
                                Case "N3"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 3)
                                Case Else
                                    _Valor_Devuelto = FormatCurrency(_Valor, 0)
                            End Select
                        End If
                    End If

                ElseIf _Type.Contains("Date") Then

                    If Not IsNothing(_Formato) Then

                        Try
                            Select Case _Formato
                                Case "DD/MM/AAAA"
                                    _Valor_Devuelto = Format(_Valor, "dd/MM/yyyy")
                                Case "DD-MM-AAAA"
                                    _Valor_Devuelto = Format(_Valor, "dd-MM-yyyy")
                                Case "LONGDATE"
                                    _Valor_Devuelto = FormatDateTime(_Valor, DateFormat.LongDate)
                                Case Else
                                    _Valor_Devuelto = FormatDateTime(_Valor, DateFormat.ShortDate)
                            End Select
                        Catch ex As Exception
                            Throw New System.Exception(ex.Message)
                        End Try

                    End If

                ElseIf _Type.Contains("Boolean") Then
                    _Valor_Devuelto = NuloPorNro(_Valor, 0)
                Else

                    _Valor_Devuelto = NuloPorNro(_Valor.ToString.Trim, "")

                    If _Rango_Hasta > _Rango_Desde Then
                        _Valor_Devuelto = Mid(_Valor_Devuelto, _Rango_Desde, _Rango_Hasta)
                    End If

                End If

            Catch ex As Exception
                _Valor_Devuelto = _Campo & " -> Función desconocida"
            End Try

        Catch ex As Exception
            _Valor_Devuelto = ex.Message & "... Error en función: " & _Parametro
        End Try

        Return _Valor_Devuelto

    End Function

#End Region

    Enum Enum_Ver
        Todas
        Proceso
        Buscar
    End Enum

    Function Fx_Buscar_Ordenes_De_Despacho(_Fecha_Emision_Desde As Date,
                                           _Fecha_Emision_Hasta As Date,
                                           _Sucursal As String,
                                           _Ver As Enum_Ver,
                                           _Condicion_Buscar As String,
                                           _Solo_Confirmados As Boolean) As DataSet

        Dim _Condicion As String

        Dim _Fecha_Desde = Format(_Fecha_Emision_Desde, "yyyy-MM-dd")
        Dim _Fecha_Hasta = Format(_Fecha_Emision_Hasta, "yyyy-MM-dd")

        Dim _Filtro_Sucursal = String.Empty

        If _Sucursal <> "Todas" Then
            _Filtro_Sucursal = " And Desp.Empresa+Desp.Sucursal = '" & _Sucursal & "' "
        End If

        Select Case _Ver

            Case Enum_Ver.Todas
                _Condicion = "And (Desp.Estado In ('CIN','ING','CON','PRE','DPR','DPO','CIE') " & _Filtro_Sucursal & ")
						      Or Desp.Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
						      Where Estado = 'CIE' And Nro_Sub <> '000' And Fecha_Cierre Between Convert(Datetime, '" & _Fecha_Desde & " 00:00:00',102) " &
                              "And Convert(Datetime, '" & _Fecha_Hasta & " 23:59:59',102)" & _Filtro_Sucursal & ")"
            Case Enum_Ver.Proceso
                _Condicion = "And (Desp.Estado In ('CIN','CON','PRE','DPR','DPO') " & _Filtro_Sucursal & ")
						      Or Desp.Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
						      Where Estado = 'CIE' And Nro_Sub <> '000' And Fecha_Cierre Between Convert(Datetime, '" & _Fecha_Desde & " 00:00:00',102) " &
                              "And Convert(Datetime, '" & _Fecha_Hasta & " 23:59:59',102)" & _Filtro_Sucursal & ")"
            Case Enum_Ver.Buscar
                _Condicion = _Condicion_Buscar

        End Select

        Dim _Filtro_Solo_Confirmados = String.Empty

        If _Solo_Confirmados Then
            _Filtro_Solo_Confirmados = Space(1) & "And Desp.Confirmado In (1)" & Space(1)
        End If

        Consulta_sql = "Select Doc2.CodFuncionario As CodFuncionario_Crea,Tf2.NOKOFU As Nombre_Crea,Desp.*,Case When Est_Desp.Fecha_Fijacion Is Null Then DATEDIFF(D,Desp.Fecha_Emision,Getdate()) Else DATEDIFF(D,Est_Desp.Fecha_Fijacion,Getdate()) End As Dias," &
                       "--Case When Est_Desp.Fecha_Fijacion Is Null Then 0 Else DATEDIFF(D,Est_Desp.Fecha_Fijacion,Getdate()) End As Dias," &
                       "--DATEDIFF(D,Fecha_Ingreso,Getdate()) AS Dias," & vbCrLf &
                       "Tdesp.NombreTabla As Nom_Tipo_Despacho," &
                       "Case When Desp.Sucursal_Retiro = '' Then Tenvi.NombreTabla Else Tenvi.NombreTabla+' -> '+Ltrim(Rtrim(Desp.Sucursal_Retiro)) End As Nom_Tipo_Envio," &
                       "Tventa.NombreTabla As Nom_Tipo_Venta" &
                       ",Testa.NombreTabla As Nom_Estado" &
                       ",Rtrim(Ltrim(Desp.Ciudad))+', '+Rtrim(Ltrim(Desp.Comuna)) As Ciudad_Comuna" &
                       ",Tf1.NOKOFU As Responsable,
                        Cast(0 As Int) As Pdte_Preparacion,Cast(0 As Int) As Pdte_Despacho,Cast(0 As Int) As Pdte_Cierre
                        Into #Paso_Desp
                        From " & _Global_BaseBk & "Zw_Despachos Desp
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Testa On Testa.Tabla = 'SIS_DESPACHO_ESTADOS' And Desp.Estado = Testa.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tdesp On Tdesp.Tabla = 'SIS_DESPACHO_TIPO_DESPACHO' And Desp.Tipo_Despacho = Tdesp.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tenvi On Tenvi.Tabla = 'SIS_DESPACHO_TIPO_ENVIO' And Desp.Tipo_Envio = Tenvi.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tventa On Tventa.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Desp.Tipo_Venta = Tventa.CodigoTabla                         
                        Left Join TABFU Tf1 On Tf1.KOFU = CodFuncionario    
                        Left Join " & _Global_BaseBk & "Zw_Despachos_Estados Est_Desp On Desp.Id_Despacho = Est_Desp.Id_Despacho And Est_Desp.Estado = 'DPR'
                        Left Join " & _Global_BaseBk & "Zw_Despachos Doc2 On Doc2.Id_Despacho = Desp.Id_Despacho_Padre
                        Left Join TABFU Tf2 On Tf2.KOFU = Doc2.CodFuncionario
                        Where 1 > 0 " & vbCrLf &
                        _Filtro_Solo_Confirmados & vbCrLf & _Condicion & vbCrLf &
                       "Select Doc.*,Edo.FEEMDO,Edo.FEER,Edo.ESPGDO,Ent.NOKOEN As Razon,
                        Rtrim(Ltrim(Str(Doc.Id_Despacho)))+Rtrim(Ltrim(Str(Doc.Idrst))) As IdD         
                        Into #Paso_Doc
                        From " & _Global_BaseBk & "Zw_Despachos_Doc Doc
                        Left Join MAEEDO Edo On Edo.IDMAEEDO = Doc.Idrst And Doc.Archidrst = 'MAEEDO'
                        Left Join MAEEN Ent On Edo.ENDO = Ent.KOEN And Edo.SUENDO = Ent.SUEN 
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Desp) And Activo = 1

                        Select Det.*,
                        Case Untrans When 1 Then CantCUd1 Else CantCUd2 End As Cantidad,
						Case Untrans When 1 Then CantDUd1 Else CantDUd2 End As Despachado,
						Case Untrans When 1 Then CantEUd1 Else CantEUd2 End As DespachadoE,
						Case Untrans When 1 Then CantRUd1 Else CantRUd2 End As Reasignado,
						Case Untrans When 1 Then CantCUd1-(CantDUd1+CantEUd1+CantRUd1) Else CantCUd2-(CantDUd2+CantEUd2+CantRUd1) End As Saldo,
                        Rtrim(Ltrim(Str(Det.Id_Despacho)))+Rtrim(Ltrim(Str(Det.Idmaeedo))) As IdD,
                        Cast(0 As Int) As Id_Despacho_Hijo,	
						Cast('' As Varchar(3)) As Nro_Sub_Hijo
                        Into #Paso_Det
                        From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Det
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Desp)

                        Update #Paso_Det Set Id_Despacho_Hijo = Isnull((Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Desp 
										 Where Desp.Archirst = 'Id_Detalle' And Desp.Idrst = #Paso_Det.Id_Detalle),0)
                        From #Paso_Det

                        Update #Paso_Det Set Nro_Sub_Hijo = (Select Nro_Sub From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = Id_Despacho_Hijo)

                        Select Distinct Nro_Despacho,Confirmado,Empresa,Cast(Null As Datetime) As Fecha_Emision,
							   Tipo_Despacho,Nom_Tipo_Despacho,CodEntidad,CodSucEntidad,Rut,Nombre_Entidad,
                               Cast('' As Varchar(3)) As Sucursal,Cast('' As Varchar(30)) As Nom_Sucursal,
                               Nom_Tipo_Venta,Cast(0 As Bit) As Marcar  
                        Into #Paso_Orden
						From #Paso_Desp Desp
                              Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
											  Where Id_Despacho_Padre In (Select Id_Despacho_Padre From #Paso_Desp)" & _Filtro_Solo_Confirmados & ")
						Order By Nro_Despacho,Fecha_Emision

                        Update #Paso_Orden Set Fecha_Emision = Floor(Cast((Select Min(Fecha_Emision) From " & _Global_BaseBk & "Zw_Despachos ZDesp Where ZDesp.Nro_Despacho = #Paso_Orden.Nro_Despacho) As Float))
                        Update #Paso_Orden Set Sucursal = (Select Top 1 Sucursal From " & _Global_BaseBk & "Zw_Despachos ZDesp 
															Where ZDesp.Nro_Despacho = #Paso_Orden.Nro_Despacho And ZDesp.Id_Despacho = ZDesp.Id_Despacho_Padre)
						Update #Paso_Orden Set Nom_Sucursal = (Select NOKOSU From TABSU Where EMPRESA = Empresa And KOSU = Sucursal)                        


                        Update #Paso_Desp Set Pdte_Preparacion = 1 Where Dias > 0 And Estado = 'PRE'    
                        Update #Paso_Desp Set Pdte_Despacho = 1 Where Dias > 0 And Estado = 'DPR'
                        Update #Paso_Desp Set Pdte_Preparacion = 1 Where Dias > 0 And Estado = 'DPO'    
                        
                        Update #Paso_Orden Set Marcar = 1 
                        Where Nro_Despacho In (Select Nro_Despacho From #Paso_Desp Where Pdte_Preparacion+Pdte_Despacho+Pdte_Preparacion > 0)

                        Select * From #Paso_Orden --Where Nro_Despacho In (Select Nro_Despacho From #Paso_Desp Where Estado <> 'CIN')
                        Select * From #Paso_Desp Where Estado <> 'CIN' And Nro_Encomienda <> 'XXX'
                        Select * From #Paso_Doc
                        Select * From #Paso_Det

                        Select Isnull(Sum(Pdte_Preparacion),0) As Pdte_Preparacion,Isnull(Sum(Pdte_Despacho),0) As Pdte_Despacho,Isnull(Sum(Pdte_Cierre),0) As Pdte_Cierre
                        From #Paso_Desp
    
                        Drop table #Paso_Orden
                        Drop table #Paso_Desp
                        Drop table #Paso_Doc
                        Drop table #Paso_Det"

        Dim _Ds As DataSet

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds.Tables(0).TableName = "Ordenes"
        _Ds.Tables(1).TableName = "SubOrdenes"
        _Ds.Tables(2).TableName = "Detalle"
        _Ds.Tables(3).TableName = "Productos"
        _Ds.Tables(4).TableName = "Pendientes"

        Return _Ds

    End Function


    Function Fx_Eliminar_Ordenes_Con_Doc_Eliminados_En_Random()

        Consulta_sql = "Select Id_Despacho
                        Into #Paso_Eliminar
                        From " & _Global_BaseBk & "Zw_Despachos_Doc_Det 
                        Where Idmaeedo Not In (Select IDMAEEDO From MAEEDO Where IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det))

                        Update " & _Global_BaseBk & "Zw_Despachos Set Estado = 'NUL', Observaciones = 'Anulado porque el documento de origen ya no existen en la base de datos'
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Eliminar) 

                        Delete " & _Global_BaseBk & "Zw_Despachos_Doc
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Eliminar)

                        Delete " & _Global_BaseBk & "Zw_Despachos_Doc_Det
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Eliminar)

                        Delete " & _Global_BaseBk & "Zw_Despachos_Email_Envios
                        Where Nro_Despacho In (Select Nro_Despacho From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho In (Select Id_Despacho From #Paso_Eliminar))

                        Delete " & _Global_BaseBk & "Zw_Despachos_Estados
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Eliminar)

                        Delete " & _Global_BaseBk & "Zw_Despachos_Tom
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Eliminar)

                        Drop Table #Paso_Eliminar"

        Return _Sql.Ej_consulta_IDU(Consulta_sql)

    End Function


    Function Fx_Enviar_Despacho_Chilexpress(_Id_Despacho As Integer) As Boolean

        'Dim _Id_Despacho = 10880

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Env Where IdDespacho = " & _Id_Despacho
        Dim _Row_Chilexpress As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Chilexpress) Then
            Return False
        End If

        Dim _Idenvio = _Row_Chilexpress.Item("Idenvio")
        Dim _Json = _Row_Chilexpress.Item("Json")
        Dim _Estatusenvio = _Row_Chilexpress.Item("Estatusenvio")

        If _Estatusenvio <> "EN REVISION" Then
            Return False
        End If

        Dim _Referencia = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos_Doc", "Ltrim(Rtrim(Substring(Tido, 1, 1)))+'-'+Ltrim(Str(Nudo))", "Id_Despacho = " & _Id_Despacho)

        _Json = Replace(_Json, "En construccion...", _Referencia)

        '_Json = Replace(_Json, "96756430", "79514800")
        '_Json = Replace(_Json, """serviceDeliveryCode"": ""5""", """serviceDeliveryCode"": ""3""")

        Dim _Clas_CliexpressAPI As New Clas_CliexpressAPI()

        If Not _Clas_CliexpressAPI.Fx_Realizar_Envio(_Idenvio, _Json) Then
            _Error = _Clas_CliexpressAPI.Errors
            Return False
        End If

        'If _Clas_CliexpressAPI.Fx_Realizar_Envio(_Idenvio, _Json) Then

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Env Where Idenvio = " & _Idenvio
        _Row_Chilexpress = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Etiqueta = _Row_Chilexpress.Item("Etiqueta")
        Dim _Etiqueta_Img As Image = _Clas_CliexpressAPI.Fx_Generar_Etiqueta(_Etiqueta)
        Dim _Ruta_Etiqueta As String
        Dim _Nombre_Etiqueta As String

        If _Clas_CliexpressAPI.Fx_CrearPDF(_Etiqueta_Img) Then

            _Ruta_Etiqueta = _Clas_CliexpressAPI.Ruta_Etiqueta
            _Nombre_Etiqueta = _Clas_CliexpressAPI.Nombre_Etiqueta

            Consulta_sql = "Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho
            Dim _Tbl_Docs As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Docs.Rows

                Dim _Idmaeedo = _Fila.Item("Idrst")

                Dim Fm As New Frm_Adjuntar_Archivos("Zw_Docu_Archivos", "Idmaeedo", _Idmaeedo)
                Fm.Fx_Grabar_Observacion_Adjunta(_Ruta_Etiqueta & "\" & _Nombre_Etiqueta, _Nombre_Etiqueta, False)
                'MessageBoxEx.Show(Me, "Etiqueta adjunta al documento correctamente", "Chilexpress", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Next

        End If

        'End If

        Return True

    End Function

End Class
