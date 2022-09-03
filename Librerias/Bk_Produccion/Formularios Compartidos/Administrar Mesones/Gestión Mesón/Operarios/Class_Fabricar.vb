Imports System.Data.SqlClient
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Class_Fabricar

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Error As String
    Dim _CodSigMeson As String
    Dim _RowSigMeson As DataRow
    Public Sub New()
        CodSigMeson = String.Empty
    End Sub

    Public Property [Error] As String
        Get
            Return _Error
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

    Public Property CodSigMeson As String
        Get
            Return _CodSigMeson
        End Get
        Set(value As String)
            _CodSigMeson = value
        End Set
    End Property

    Public Property RowSigMeson As DataRow
        Get

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _CodSigMeson & "'"
            _RowSigMeson = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Return _RowSigMeson
        End Get
        Set(value As DataRow)
            _RowSigMeson = value
        End Set
    End Property

    Function Fx_Agregar_Producto_a_la_Maquina(_Codigoob As String, _FilaMeson As DataRow, _Cant_Fabricar As Double) As Integer

        Dim _IdMeson As Integer = _FilaMeson.Item("IdMeson")
        Dim _Idpotpr As String = _FilaMeson.Item("Idpotpr")
        Dim _Idpotl As String = _FilaMeson.Item("Idpotl")
        Dim _Idpote As String = _FilaMeson.Item("Idpote")

        Dim _Numot As Integer = Convert.ToInt32(_FilaMeson.Item("Numot"))
        Dim _Subot As String = _FilaMeson.Item("Nreg")
        Dim _Codmeson As String = _FilaMeson.Item("Codmeson")
        Dim _Operacion As String = _FilaMeson.Item("OPERACION")
        Dim _CodMaq As String = _FilaMeson.Item("CODMAQOT")
        Dim _Obrero As String = _Codigoob
        Dim _Codigo As String = _FilaMeson.Item("Codigo")
        Dim _Descripcion As String = _FilaMeson.Item("Glosa")
        Dim _Fabricar As Double = _FilaMeson.Item("Fabricar")
        Dim _Fabricando As Double = _FilaMeson.Item("Fabricando")
        Dim _Saldo_Fabricar As Double = _FilaMeson.Item("Saldo_Fabricar")

        'Dim _Saldo_Fabricar_New As Double = _FilaMeson.Item("Saldo_Fabricar_New")
        'Dim _Cant_Reproceso As Double = _FilaMeson.Item("Cant_Reproceso")

        Dim _Id_Maquina As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(cn2)

            myTrans = cn2.BeginTransaction()


            Consulta_Sql = "INSERT INTO " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos" & vbCrLf &
                              "(IdMeson,Idpotpr,Idpotl,Idpote,Numot,Codmeson,Operacion,CodMaq,Obrero,Codigo,Descripcion," &
                              "Fecha_Hora_Inicio,Fabricar,Estado) VALUES" & vbCrLf &
                              "(" & _IdMeson & "," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & _Numot & "','" & _Codmeson & "','" & _Operacion &
                              "','" & _CodMaq & "','" & _Codigoob & "','" & _Codigo & "'," &
                              "'" & _Descripcion & "',Getdate()," & De_Num_a_Tx_01(_Cant_Fabricar, False, 5) & ",'EMQ');"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Id_Maquina = dfd1("Identity")
            End While
            dfd1.Close()


            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
                           "Estado='MQ',Fabricando = Fabricando +" & De_Num_a_Tx_01(_Cant_Fabricar, False, 5) & " WHERE IdMeson = " & _IdMeson

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
                           "Estado='PD' Where Saldo_Fabricar - Fabricando > 0 And IdMeson = " & _IdMeson

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Throw New System.Exception("Error a proposito!!!")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return _Id_Maquina

        Catch ex As Exception

            _Error = ex.Message
            'Throw New System.Exception("Error a proposito!!!")
            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "TRANSACCION DESECHA" & vbCrLf & "EL PRODUCTO NO FUE ENVIADO AL MESON INTENTE NUEVAMENTE", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

            myTrans.Rollback()
            Return 0

        End Try

    End Function

    Function Fx_Producto_Fabricado(_Formulario As Form, _FilaMaquina As DataRow,
                                   _Enviar_Sig_Meson As Boolean)

        Dim _Numot As String
        Dim _Subot As String
        Dim _Estado As String
        Dim _Codigo As String
        Dim _Descripcion As String
        Dim _Glosa As String
        Dim _Nreg As String

        Dim _Codigoob As String

        Dim _Fabricar_OT As Double
        Dim _Fabricado_OT As Double
        Dim _Saldo_Fabricar_OT As Double
        Dim _Porc_Fabricacion As Double

        Dim _Fabricar As Double
        Dim _Fabricado As Double
        Dim _Saldo_Fabricar As Double

        Dim _Codmeson_MQ As String
        Dim _Fabricado_Completamente As Boolean
        Dim _Row_Meson_En_Pausa As DataRow

        Dim _Codmeson As String
        Dim _Idpote As Integer
        Dim _Idpotpr As Integer
        Dim _Idpotl As String
        Dim _Idpotl_Padre As String
        Dim _Orden_Meson As Integer
        Dim _Orden_Potpr As Integer
        Dim _Nivel As Integer
        Dim _Reproceso As Boolean
        Dim _IdMeson_Reproceso As Integer

        Dim _IdMaquina As Integer
        Dim _IdMeson As Integer

        Dim _Operacion As String
        Dim _Nombreop As String

        Dim _Observacion As String

        Dim _Row_Potpr As DataRow

        Dim _Virtual As Boolean
        Dim _Maestro As Boolean
        Dim _Row_Next_Operacion As DataRow
        Dim _Alerta = String.Empty

        Dim _AsignadoAlPrincipio As Boolean
        Dim _CodMesonManda As String

        _CodSigMeson = String.Empty

        Try

            '_Numot = _FilaMaquina.Item("Numot")
            _Subot = _FilaMaquina.Item("Subot")
            '_Codigo = _FilaMaquina.Item("Codigo")
            _Descripcion = _FilaMaquina.Item("Descripcion")

            _IdMaquina = _FilaMaquina.Item("IdMaquina")
            _IdMeson = _FilaMaquina.Item("IdMeson")
            '_Idpote = _FilaMaquina.Item("Idpote")
            '_Idpotl = _FilaMaquina.Item("Idpotl")
            '_Idpotpr = _FilaMaquina.Item("Idpotpr")
            _Codmeson_MQ = _FilaMaquina.Item("Codmeson")
            '_Operacion = _FilaMaquina.Item("Operacion")
            _Codigoob = _FilaMaquina.Item("Obrero")
            _Fabricar = _FilaMaquina.Item("Fabricar")
            _Fabricado = _FilaMaquina.Item("Fabricado")
            '_Saldo_Fabricar = _Fabricar - _Fabricado
            _Observacion = _FilaMaquina.Item("Observacion")


            Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
            Dim _Fila As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            _Numot = _Fila.Item("NUMOT")
            _Estado = _Fila.Item("Estado")
            _Codigo = _Fila.Item("Codigo")
            _Glosa = _Fila.Item("Glosa")
            _Nreg = _Fila.Item("Nreg")

            _Fabricar_OT = _Fila.Item("Fabricar_OT")
            _Fabricado_OT = _Fila.Item("Fabricado_OT")
            _Saldo_Fabricar_OT = _Fila.Item("Saldo_Fabricar_OT")
            _Porc_Fabricacion = _Fila.Item("Porc_Fabricacion")

            '_Fabricar = _Fila.Item("Fabricar")
            '_Fabricado = _Fila.Item("Fabricado")
            _Saldo_Fabricar = _Fila.Item("Saldo_Fabricar")

            _Codmeson = _Fila.Item("Codmeson")
            _Idpote = _Fila.Item("Idpote")
            _Idpotpr = _Fila.Item("Idpotpr")
            _Idpotl = _Fila.Item("Idpotl")
            _Idpotl_Padre = _Fila.Item("Idpotl")
            _Orden_Meson = _Fila.Item("Orden_Meson")
            _Orden_Potpr = _Fila.Item("Orden_Potpr")
            _Nivel = _Fila.Item("Nivel")
            _Reproceso = _Fila.Item("Reproceso")
            _IdMeson_Reproceso = _Fila.Item("IdMeson_Reproceso")

            _AsignadoAlPrincipio = _Fila.Item("AsignadoAlPrincipio")
            _CodMesonManda = _Fila.Item("CodMesonManda")

            Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                           "Where Idpotl = " & _Idpotl & " And CodMesonManda = '" & _Codmeson_MQ & "' And AsignadoAlPrincipio = 1 And Estado = 'PS'"
            _Row_Meson_En_Pausa = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not _Reproceso Then

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'"
                Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Operacion_Equivalente As String = Trim(_Row_Meson.Item("Operacion_Equivalente"))

                _Virtual = _Row_Meson.Item("Virtual")
                _Maestro = _Row_Meson.Item("Maestro")

                Consulta_Sql = "Select * From POTPR Where IDPOTL = " & _Idpotl & " And IDPOTPR <> " & _Idpotpr & " And ORDEN > " & _Orden_Potpr & " ORDER BY ORDEN"
                Dim _Tbl_Potpr As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                For Each _Fila_Potpr As DataRow In _Tbl_Potpr.Rows

                    Dim _Oper = _Fila_Potpr.Item("OPERACION")

                    If _Oper <> _Operacion_Equivalente Then

                        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Operacion = '" & _Oper & "'"

                        Dim _Row_Meson_NOp As DataRow

                        _Row_Meson_NOp = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        If IsNothing(_Row_Meson_NOp) Then
                            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Operacion_Reproceso = '" & _Oper & "'"
                            _Row_Meson_NOp = _Sql.Fx_Get_DataRow(Consulta_Sql)
                        End If

                        Dim _Virtua_Nop As Boolean = _Row_Meson_NOp.Item("Virtual")
                        Dim _Seleccionar_Meson As Boolean

                        If Not _Virtual Then
                            If Not _Virtua_Nop Then _Seleccionar_Meson = True
                        Else
                            _Seleccionar_Meson = True
                        End If

                        If _Seleccionar_Meson Then
                            _Row_Potpr = _Fila_Potpr
                            Exit For
                        End If

                    End If

                Next

                If Not _Virtual Then

                    If Not IsNothing(_Row_Potpr) Then

                        Dim _Codmaq = _Row_Potpr.Item("CODMAQOT")
                        _Codmeson = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_MesonVsMaquina", "Codmeson", "Codmaq = '" & _Codmaq & "'")

                        _Idpotl = _Row_Potpr.Item("IDPOTL")
                        _Idpotpr = _Row_Potpr.Item("IDPOTPR")

                        _Operacion = _Row_Potpr.Item("OPERACION")
                        _Nombreop = _Sql.Fx_Trae_Dato("POPER", "NOMBREOP", "OPERACION = '" & _Operacion & "'")

                        _Orden_Potpr = _Row_Potpr.Item("ORDEN")

                        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
                                                Where Codmeson = '" & _Codmeson & "' And Idpotpr = " & _Idpotpr & " And Estado <> 'RP'"
                        _Row_Next_Operacion = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    End If

                End If

            End If

            'Throw New System.Exception("Error a proposito!!!")

        Catch ex As Exception

            _Error = ex.Message

            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "TRANSACCION DESECHA" & vbCrLf & "EL PRODUCTO NO FUE ENVIADO AL MESON INTENTE NUEVAMENTE (1)", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)


            Return 0

        End Try

        ' Tiene siguiente mesón
        ' Preguntar si quiere ingresar una Alerta

        If Not IsNothing(_Row_Potpr) Then

            Dim _Solicita_Alerta As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_Mesones", "Solicita_Alerta", "Codmeson = '" & _Codmeson & "'")

            If _Solicita_Alerta Then

                If MessageBoxEx.Show(_Formulario, "¿DESEA INCORPORAR UNA ALERTA PARA EL SIGUIENTE MESÓN?", "ALERTAS",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                    Dim _Input_box = InputBox_Bk(_Formulario, "INGRESE ALERTA PARA EL SIGUIENTE MESON", "ALERTA",
                                                 _Alerta,, _Tipo_Mayus_Minus.Mayusculas,, True, _Tipo_Imagen.Alerta, False)

                    _Alerta = _Alerta.Trim

                End If

            End If

        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(cn2)

            myTrans = cn2.BeginTransaction()

            Dim _Fecha_Hora_Temino As String = String.Empty

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
                               "Fabricado = Fabricado + " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                               ",Fabricando = 0 --Fabricando - " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                               ",Porc_Avance_Saldo_Fab = 0" & vbCrLf &
                               "WHERE IdMeson = " & _IdMeson &
                               vbCrLf &
                               vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                               "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
                               ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
                               ",Porc_Avance_Saldo_Fab = 1" & vbCrLf &
                               ",Fecha_Hora_Termino = (Case When Fecha_Hora_Termino Is Null Then Getdate() Else Fecha_Hora_Termino End)" & vbCrLf &
                               ",Observacion = '" & _Observacion & "'" & vbCrLf &
                               "WHERE IdMaquina = " & _IdMaquina

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                           "Where IdMeson = " & _IdMeson

            Comando = New SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Dim dfd3 As SqlDataReader = Comando.ExecuteReader()
            While dfd3.Read()

                Dim _Fabricar2 = dfd3("Fabricar")
                Dim _Fabricado2 = dfd3("Fabricado")

                If _Fabricado2 = _Fabricar2 Then
                    _Fabricado_Completamente = True
                End If

            End While
            dfd3.Close()

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                               "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                               "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                               "Where IdMeson = " & _IdMeson

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                           "Where IdMeson = " & _IdMeson

            Comando = New SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            dfd3 = Comando.ExecuteReader()
            While dfd3.Read()

                Dim _Fabricar2 = dfd3("Fabricar")
                Dim _Fabricado2 = dfd3("Fabricado")

                If _Fabricado2 = _Fabricar2 Then
                    _Fabricado_Completamente = True
                End If

            End While
            dfd3.Close()

            Dim _Cant_Fabricada As Double = _Fabricado

            Dim _Id_MesonVsEnvioRecibe As Integer

            If Not IsNothing(_Row_Meson_En_Pausa) Then

                ' Envio de Alerta al siguiente meson

                If Not String.IsNullOrEmpty(_Alerta.Trim) Then

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas (Empresa,Idpotpr,Idpotl,Idpote,Numot,Operacion,Codigoob_Envia,Alerta,Id_Padre_Edit) Values 
                                                    ('" & ModEmpresa & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & numero_(_Numot, 10) &
                                                    "','" & _Operacion & "','" & _Codigoob & "','" & _Alerta & "',0)"

                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

                If Not _Maestro Then

                    Dim _IdMeson_Recibe = _Row_Meson_En_Pausa.Item("IdMeson")

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD'" & vbCrLf &
                                   "Where IdMeson = " & _IdMeson_Recibe
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob) Values " &
                                   "(" & _IdMaquina & "," & _IdMeson & "," & _IdMeson_Recibe & ",'" & _Codigo & "'," & _Cant_Fabricada & ",Getdate(),'" & _Codigoob & "')"
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                    Comando.Transaction = myTrans
                    Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                    While dfd1.Read()
                        _Id_MesonVsEnvioRecibe = dfd1("Identity")
                    End While
                    dfd1.Close()

                End If

                _Enviar_Sig_Meson = False

            Else

            End If

            '--------------------
            ' ENVIAR EL PRODUCTO AL SIGUIENTE MESON

            If _Enviar_Sig_Meson Then

                If _Reproceso Then

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Cant_Reproceso = Cant_Reproceso - " & _Cant_Fabricada & "
                                    Where IdMeson = " & _IdMeson_Reproceso

                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Dim _IdMeson_Recibe As Integer = _IdMeson_Reproceso

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,EsReproceso,Codigoob) Values " &
                                   "(" & _IdMaquina & "," & _IdMeson & "," & _IdMeson_Recibe & ",'" & _Codigo & "'," & _Cant_Fabricada & ",Getdate(),1,'" & _Codigoob & "')"
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Else

                    If Not IsNothing(_Row_Potpr) Then

                        If _Virtual Then

                            If Not _Maestro Then

                                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob,EsMesonVirtual) Values " &
                                                "(" & _IdMaquina & "," & _IdMeson & ",0,'" & _Codigo & "'," & _Cant_Fabricada & ",Getdate(),'" & _Codigoob & "',1)"
                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                                Comando.Transaction = myTrans
                                Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                                While dfd1.Read()
                                    _Id_MesonVsEnvioRecibe = dfd1("Identity")
                                End While
                                dfd1.Close()

                            End If

                        Else

                            If Not IsNothing(_Row_Next_Operacion) Then

                                Dim _Nex_IdMeson = _Row_Next_Operacion.Item("IdMeson")
                                Dim _Nex_AsignadoAlPrincipio As Boolean = _Row_Next_Operacion.Item("AsignadoAlPrincipio")

                                If Not _Nex_AsignadoAlPrincipio Then

                                    Dim _Fabricando_ = _Row_Next_Operacion.Item("Fabricando")

                                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set 
                                    Estado = 'PD',Fabricar = Fabricar + " & _Cant_Fabricada & ", 
                                    Saldo_Fabricar = Saldo_Fabricar + " & _Cant_Fabricada & "
                                    Where IdMeson = " & _Nex_IdMeson

                                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                    Dim _IdMeson_Recibe As Integer = _Nex_IdMeson

                                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob) Values " &
                                                   "(" & _IdMaquina & "," & _IdMeson & "," & _IdMeson_Recibe & ",'" & _Codigo & "'," & _Cant_Fabricada & ",Getdate(),'" & _Codigoob & "')"
                                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                                               "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                                               "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                                               "Where IdMeson = " & _Nex_IdMeson

                                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                End If

                            Else


                                ' Envio de Alerta al siguiente meson

                                If Not String.IsNullOrEmpty(_Alerta.Trim) Then

                                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas (Empresa,Idpotpr,Idpotl,Idpote,Numot,Operacion,Codigoob_Envia,Alerta,Id_Padre_Edit) Values 
                                                    ('" & ModEmpresa & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & numero_(_Numot, 10) &
                                                    "','" & _Operacion & "','" & _Codigoob & "','" & _Alerta & "',0)"

                                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                End If

                                _CodSigMeson = _Codmeson

                                Dim _Enviar_Al_Sig_Meson = True
                                Dim _ActivaAlPrincipio As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_Mesones", "ActivaAlPrincipio", "Codmeson = '" & _CodSigMeson & "'")
                                Dim _NewEstado = "PD"

                                If _AsignadoAlPrincipio Then

                                    If Not _ActivaAlPrincipio Then

                                        Comando = New SqlCommand("Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where Idpotl = " & _Idpotl & " And Codmeson = '" & _CodMesonManda & "'", cn2)
                                        Comando.Transaction = myTrans
                                        Dim dfd2 As SqlDataReader = Comando.ExecuteReader()
                                        Dim _Tiene_Filas = dfd2.HasRows

                                        If Not _Tiene_Filas Then
                                            _Enviar_Sig_Meson = False
                                            _NewEstado = "PS"
                                        End If

                                        While dfd2.Read()
                                            Dim _vFabricar As Double = dfd2("Fabricar")
                                            Dim _vFabricado As Double = dfd2("Fabricar")

                                            If _vFabricar <> _vFabricado Then
                                                _Enviar_Sig_Meson = False
                                                _NewEstado = "PS"
                                            End If

                                        End While
                                        dfd2.Close()

                                    End If

                                End If

                                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote," &
                                                   "Empresa,Numot,Nreg,Estado,Desde,Operacion,Nombreop,Codigo,Glosa,Asignado_Por," &
                                                   "Fecha_Asignacion,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT," &
                                                   "Fabricar,Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Potpr,Orden_Meson,Nivel,AsignadoAlPrincipio,CodMesonManda) " &
                                                   "VALUES('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & ModEmpresa &
                                                   "','" & _Numot & "','" & _Nreg & "','" & _NewEstado & "','MS'" &
                                                   ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                                   "','" & FUNCIONARIO & "',Getdate()," & _Fabricar_OT & "," & _Fabricado_OT & "," & _Saldo_Fabricar_OT &
                                                   "," & _Fabricado & ",0," & _Fabricado & ",'" & FUNCIONARIO & "'," & _Orden_Potpr &
                                                   "," & _Orden_Meson & "," & _Nivel & "," & Convert.ToInt32(_AsignadoAlPrincipio) & ",'" & _CodMesonManda & "')"

                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                If _Enviar_Al_Sig_Meson Then

                                    Dim _IdMeson_Recibe As Integer

                                    Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                                    Comando.Transaction = myTrans
                                    Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                                    While dfd1.Read()
                                        _IdMeson_Recibe = dfd1("Identity")
                                    End While
                                    dfd1.Close()

                                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob) Values " &
                                               "(" & _IdMaquina & "," & _IdMeson & "," & _IdMeson_Recibe & ",'" & _Codigo & "'," & _Fabricado & ",Getdate(),'" & _Codigoob & "')"
                                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                End If

                            End If

                        End If

                    Else

                        If _Nivel = 0 Then

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET Estado = 'PT' WHERE IdMeson=" & _IdMeson

                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob,EsMesonFinal) Values " &
                                           "(" & _IdMaquina & "," & _IdMeson & ",0,'" & _Codigo & "'," & _Cant_Fabricada & ",Getdate(),'" & _Codigoob & "',1)"
                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        Else

                            'SE CREA LA DFA DEFINITIVA EN RANDOM PRODUCCION A PARTIR DE LOS DATOS RESCADOS

                            Consulta_Sql = "Select Top 1 * From POTD" & vbCrLf &
                                           "Where NUMOT = '" & _Numot & "' And CODIGO = '" & _Codigo & "' And PERTENECE <> ''"

                            Dim _Pertenece As String

                            Comando = New SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Idpotl_Padre = dfd1("IDPOTL")
                                _Pertenece = dfd1("PERTENECE")
                            End While
                            dfd1.Close()

                            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob,EsMesonFinal,Idpotl_Padre) Values " &
                                           "(" & _IdMaquina & "," & _IdMeson & ",0,'" & _Codigo & "'," & _Cant_Fabricada & ",Getdate(),'" & _Codigoob & "',1," & _Idpotl_Padre & ")"
                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Pertenece = '" & _Pertenece & "'" & vbCrLf &
                                           "Where IdMeson = " & _IdMeson

                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()


                            Dim _Componentes_Pertenece As Integer

                            Consulta_Sql = "Select Count(*) As Cuenta From POTD" & vbCrLf &
                                           "Where NUMOT = '" & _Numot & "' And NREG = '" & _Pertenece & "' and PERTENECE <> '' AND MARCANOM <> ''"

                            Comando = New SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            dfd1 = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Componentes_Pertenece = dfd1("Cuenta")
                            End While
                            dfd1.Close()

                            Dim _Componetes_Fabricados As Integer

                            Consulta_Sql = "Select Count(*) As Cuenta From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                                           "Where Idpote = " & _Idpote & " And Pertenece = '" & _Pertenece & "'"
                            Comando = New SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            dfd1 = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Componetes_Fabricados = dfd1("Cuenta")
                            End While
                            dfd1.Close()

                            If _Componentes_Pertenece = _Componetes_Fabricados Then

                                Consulta_Sql = "Select * From POTL Where IDPOTE = " & _Idpote & " And NREG = '" & _Pertenece & "'"

                                Comando = New SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                dfd1 = Comando.ExecuteReader()
                                While dfd1.Read()
                                    _Idpotl = dfd1("IDPOTL")
                                End While
                                dfd1.Close()

                                Consulta_Sql = "Select " & _Idpote & " As Idpote,IDPOTPR As Idpotpr,Pt.IDPOTL As Idpotl,Pt.NUMOT As Numot," &
                                               "Pt.CODIGO As Codigo,Pl.GLOSA As Glosa,NREGOTL As Nreg,Pt.OPERACION As Operacion,Pp.NOMBREOP As Nombreop," &
                                               "ORDEN As Orden_Potpr,Pt.FABRICAR As Fabricar,Pt.REALIZADO As Fabricado," &
                                               "Pt.FABRICAR-Pt.REALIZADO AS Saldo_Fabricar,0 As Nivel," &
                                               "(Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina Where Codmaq = CODMAQOT) As CodMeson" &
                                               vbCrLf &
                                               "Into #Paso" & vbCrLf &
                                               "From POTPR Pt" & vbCrLf &
                                               "Inner Join PMAQUI Mq ON Mq.CODMAQ=Pt.CODMAQOT" & vbCrLf &
                                               "Inner Join POPER Pp On Pp.OPERACION=Pt.OPERACION" & vbCrLf &
                                               "Inner Join POTL Pl ON Pl.IDPOTL=Pt.IDPOTL" & vbCrLf &
                                               "WHERE Pt.IDPOTL = " & _Idpotl & vbCrLf &
                                               "Order By ORDEN" & vbCrLf &
                                               vbCrLf &
                                               "Select Top 1 * From #Paso" & vbCrLf &
                                               "Where CodMeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0)" & vbCrLf &
                                               "Drop Table #Paso"

                                Comando = New SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                dfd1 = Comando.ExecuteReader()
                                While dfd1.Read()

                                    _Codmeson = dfd1("CodMeson")
                                    _Idpote = dfd1("Idpote")
                                    _Idpotl = dfd1("Idpotl")
                                    _Idpotpr = dfd1("Idpotpr")
                                    _Numot = dfd1("Numot")
                                    _Nreg = dfd1("Nreg")
                                    _Operacion = dfd1("Operacion")
                                    _Nombreop = dfd1("Nombreop")
                                    _Codigo = dfd1("Codigo")
                                    _Glosa = dfd1("Glosa")
                                    _Fabricar = dfd1("Fabricar")
                                    _Fabricado = dfd1("Fabricado")
                                    _Saldo_Fabricar = dfd1("Saldo_Fabricar")
                                    _Nivel = dfd1("Nivel")
                                    _Orden_Potpr = dfd1("Orden_Potpr")

                                End While
                                dfd1.Close()

                                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote," &
                                               "Empresa,Numot,Nreg,Estado,Desde,Operacion,Nombreop,Codigo,Glosa,Asignado_Por," &
                                               "Fecha_Asignacion,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT," &
                                               "Fabricar,Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Potpr,Orden_Meson,Nivel) " &
                                               "Values('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & ModEmpresa &
                                               "','" & _Numot & "','" & _Nreg & "','PD','MS'" &
                                               ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                               "','" & FUNCIONARIO & "',Getdate()," & _Fabricar & "," & _Fabricado & "," & _Saldo_Fabricar &
                                               "," & _Fabricar & ",0," & _Fabricar & ",'" & FUNCIONARIO & "'," & _Orden_Potpr &
                                               "," & _Orden_Meson & "," & _Nivel & ")"

                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                Dim _IdMeson_Recibe As Integer

                                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                                Comando.Transaction = myTrans
                                dfd1 = Comando.ExecuteReader()
                                While dfd1.Read()
                                    _IdMeson_Recibe = dfd1("Identity")
                                End While
                                dfd1.Close()

                                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob) Values " &
                                               "(" & _IdMaquina & "," & _IdMeson & "," & _IdMeson_Recibe & ",'" & _Codigo & "'," & _Fabricar & ",Getdate(),'" & _Codigoob & "')"
                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                        End If

                    End If

                End If

            End If

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'FZ'" & vbCrLf &
                           "Where IdMeson = " & _IdMeson & " And Fabricar = Fabricado And Estado <> 'PT'"
            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            ' El mesón maestro es el encargado de activas los mesones que estan en pausa una vez que genero su trabajo.
            ' El mesón de diseño es el mesón maestro en Ingemad

            If _Maestro Then

                ' Hay que poner aca una funcion que llene todos los productos que se envian desde el mesón maestro hacia los mesones que estan em Pausa.

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                               "Where Idpotl_Padre = " & _Idpotl & " And IdMeson <> " & _IdMeson & Space(1) &
                               "And Codmeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0 And Estado = 'PS')"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim _IdMeson_Recibe_List As New List(Of String)

                Dim dfd As SqlDataReader = Comando.ExecuteReader()
                While dfd.Read()

                    _IdMeson_Recibe_List.Add(dfd("IdMeson"))

                End While
                dfd.Close()

                For Each _IdMeson_Recibe In _IdMeson_Recibe_List

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,Codigoob) Values " &
                                    "(" & _IdMaquina & "," & _IdMeson & "," & _IdMeson_Recibe & ",'" & _Codigo & "'," & _Fabricar & ",Getdate(),'" & _Codigoob & "')"
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()
                Next

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson

                Comando = New SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                dfd = Comando.ExecuteReader()
                While dfd.Read()
                    _Porc_Fabricacion = dfd("Porc_Fabricacion")
                End While
                dfd.Close()

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set " & vbCrLf &
                               "Fabricar = Fabricar_OT * " & De_Num_a_Tx_01(_Porc_Fabricacion, False, 5) & "," &
                               "Fecha_Asignacion = Getdate(),Estado = 'PD'" & vbCrLf &
                               "Where Idpotl_Padre = " & _Idpotl & " And IdMeson <> " & _IdMeson & Space(1) &
                               "And Codmeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0 And Estado = 'PS')"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()




                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                               "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                               "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                               "Where Idpotl_Padre = " & _Idpotl & " And IdMeson <> " & _IdMeson & Space(1) &
                               "And Codmeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0 And Estado = 'PS')"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD' Where IdMeson = " & _IdMeson & " And Saldo_Fabricar > 0"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            '--- CREAR DFA

            'Throw New System.Exception("Error a proposito!!!")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return True

        Catch ex As Exception

            _Error = ex.Message

            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "TRANSACCION DESECHA" & vbCrLf & "EL PRODUCTO NO FUE ENVIADO AL MESON INTENTE NUEVAMENTE (2)", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

            If Not IsNothing(myTrans) Then
                Try
                    myTrans.Rollback()
                Catch ex2 As Exception

                End Try
            End If

            Return 0

        End Try

    End Function

    Function Fx_Producto_Fabricado_ServTecnico(_Formulario As Form, _FilaMaquina As DataRow, _Enviar_Sig_Meson As Boolean, _TblMesones As DataTable)

        Dim _Numot As String
        Dim _Subot As String
        Dim _Estado As String
        Dim _Codigo As String
        Dim _Descripcion As String
        Dim _Glosa As String
        Dim _Nreg As String

        Dim _Codigoob As String

        Dim _Fabricar_OT As Double
        Dim _Fabricado_OT As Double
        Dim _Saldo_Fabricar_OT As Double
        Dim _Porc_Fabricacion As Double

        Dim _Fabricar As Double
        Dim _Fabricado As Double
        Dim _Saldo_Fabricar As Double

        Dim _Codmeson As String
        Dim _Idpote As Integer
        Dim _Idpotpr As Integer
        Dim _Idpotl As String
        Dim _Idpotl_Padre As String
        Dim _Orden_Meson As Integer
        Dim _Orden_Potpr As Integer
        Dim _Nivel As Integer
        Dim _Reproceso As Boolean
        Dim _IdMeson_Reproceso As Integer

        Dim _IdMaquina As Integer
        Dim _IdMeson As Integer

        Dim _Operacion As String
        Dim _Nombreop As String

        Dim _Observacion As String

        Dim _Row_Potpr As DataRow

        Dim _Virtual As Boolean
        Dim _Maestro As Boolean
        Dim _Row_Next_Operacion As DataRow
        Dim _Alerta = String.Empty

        _CodSigMeson = String.Empty

        Try

            _Subot = _FilaMaquina.Item("Subot")
            _Descripcion = _FilaMaquina.Item("Descripcion")
            _IdMaquina = _FilaMaquina.Item("IdMaquina")
            _IdMeson = _FilaMaquina.Item("IdMeson")
            _Codigoob = _FilaMaquina.Item("Obrero")
            _Fabricar = _FilaMaquina.Item("Fabricar")
            _Fabricado = _FilaMaquina.Item("Fabricado")
            _Observacion = _FilaMaquina.Item("Observacion")

            Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
            Dim _Fila As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            _Numot = _Fila.Item("NUMOT")
            _Estado = _Fila.Item("Estado")
            _Codigo = _Fila.Item("Codigo")
            _Glosa = _Fila.Item("Glosa")
            _Nreg = _Fila.Item("Nreg")

            _Fabricar_OT = _Fila.Item("Fabricar_OT")
            _Fabricado_OT = _Fila.Item("Fabricado_OT")
            _Saldo_Fabricar_OT = _Fila.Item("Saldo_Fabricar_OT")
            _Porc_Fabricacion = _Fila.Item("Porc_Fabricacion")

            _Saldo_Fabricar = _Fila.Item("Saldo_Fabricar")

            _Codmeson = _Fila.Item("Codmeson")
            _Idpote = _Fila.Item("Idpote")
            _Idpotpr = _Fila.Item("Idpotpr")
            _Idpotl = _Fila.Item("Idpotl")
            _Idpotl_Padre = _Fila.Item("Idpotl")
            _Orden_Meson = _Fila.Item("Orden_Meson")
            _Orden_Potpr = _Fila.Item("Orden_Potpr")
            _Nivel = _Fila.Item("Nivel")
            _Reproceso = _Fila.Item("Reproceso")
            _IdMeson_Reproceso = _Fila.Item("IdMeson_Reproceso")

            If Not _Reproceso Then

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'"
                Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Operacion_Equivalente As String = Trim(_Row_Meson.Item("Operacion_Equivalente"))

                _Virtual = _Row_Meson.Item("Virtual")
                _Maestro = _Row_Meson.Item("Maestro")

                Consulta_Sql = "Select * From POTPR Where IDPOTL = " & _Idpotl & " And IDPOTPR <> " & _Idpotpr & " And ORDEN > " & _Orden_Potpr & " ORDER BY ORDEN"
                Dim _Tbl_Potpr As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                For Each _Fila_Potpr As DataRow In _Tbl_Potpr.Rows

                    Dim _Oper = _Fila_Potpr.Item("OPERACION")

                    If _Oper <> _Operacion_Equivalente Then

                        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Operacion = '" & _Oper & "'"

                        Dim _Row_Meson_NOp As DataRow

                        _Row_Meson_NOp = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        If IsNothing(_Row_Meson_NOp) Then
                            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Operacion_Reproceso = '" & _Oper & "'"
                            _Row_Meson_NOp = _Sql.Fx_Get_DataRow(Consulta_Sql)
                        End If

                        Dim _Virtua_Nop As Boolean = _Row_Meson_NOp.Item("Virtual")
                        Dim _Seleccionar_Meson As Boolean

                        If Not _Virtual Then
                            If Not _Virtua_Nop Then _Seleccionar_Meson = True
                        Else
                            _Seleccionar_Meson = True
                        End If

                        If _Seleccionar_Meson Then
                            _Row_Potpr = _Fila_Potpr
                            Exit For
                        End If

                    End If

                Next

                If Not _Virtual Then

                    If Not IsNothing(_Row_Potpr) Then

                        Dim _Codmaq = _Row_Potpr.Item("CODMAQOT")
                        _Codmeson = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_MesonVsMaquina", "Codmeson", "Codmaq = '" & _Codmaq & "'")

                        _Idpotl = _Row_Potpr.Item("IDPOTL")
                        _Idpotpr = _Row_Potpr.Item("IDPOTPR")

                        _Operacion = _Row_Potpr.Item("OPERACION")
                        _Nombreop = _Sql.Fx_Trae_Dato("POPER", "NOMBREOP", "OPERACION = '" & _Operacion & "'")

                        _Orden_Potpr = _Row_Potpr.Item("ORDEN")

                        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
                                                Where Codmeson = '" & _Codmeson & "' And Idpotpr = " & _Idpotpr & " And Estado <> 'RP'"
                        _Row_Next_Operacion = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    End If

                End If

            End If

            'Throw New System.Exception("Error a proposito!!!")

        Catch ex As Exception

            _Error = ex.Message

            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "TRANSACCION DESECHA" & vbCrLf & "EL PRODUCTO NO FUE ENVIADO AL MESON INTENTE NUEVAMENTE (1)", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)


            Return 0

        End Try

        ' Tiene siguiente mesón
        ' Preguntar si quiere ingresar una Alerta

        If Not IsNothing(_Row_Potpr) Then

            Dim _Solicita_Alerta As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_Mesones", "Solicita_Alerta", "Codmeson = '" & _Codmeson & "'")

            If _Solicita_Alerta Then

                If MessageBoxEx.Show(_Formulario, "¿DESEA INCORPORAR UNA ALERTA PARA EL SIGUIENTE MESÓN?", "ALERTAS",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                    Dim _Input_box = InputBox_Bk(_Formulario, "INGRESE ALERTA PARA EL SIGUIENTE MESON", "ALERTA",
                                                 _Alerta,, _Tipo_Mayus_Minus.Mayusculas,, True, _Tipo_Imagen.Alerta, False)

                    _Alerta = _Alerta.Trim

                End If

            End If

        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(cn2)

            myTrans = cn2.BeginTransaction()

            Dim _Fecha_Hora_Temino As String = String.Empty

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
                               "Fabricado = Fabricado + " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                               ",Fabricando = 0 --Fabricando - " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                               ",Porc_Avance_Saldo_Fab = 0" & vbCrLf &
                               "WHERE IdMeson = " & _IdMeson &
                               vbCrLf &
                               vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                               "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
                               ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
                               ",Porc_Avance_Saldo_Fab = 1" & vbCrLf &
                               ",Fecha_Hora_Termino = (Case When Fecha_Hora_Termino Is Null Then Getdate() Else Fecha_Hora_Termino End)" & vbCrLf &
                               ",Observacion = '" & _Observacion & "'" & vbCrLf &
                               "WHERE IdMaquina = " & _IdMaquina

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                           "Where IdMeson = " & _IdMeson

            Comando = New SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Dim dfd3 As SqlDataReader = Comando.ExecuteReader()
            While dfd3.Read()

                Dim _Fabricar2 = dfd3("Fabricar")
                Dim _Fabricado2 = dfd3("Fabricado")

            End While
            dfd3.Close()

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                               "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                               "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                               "Where IdMeson = " & _IdMeson

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                           "Where IdMeson = " & _IdMeson

            Comando = New SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            dfd3 = Comando.ExecuteReader()
            While dfd3.Read()

                Dim _Fabricar2 = dfd3("Fabricar")
                Dim _Fabricado2 = dfd3("Fabricado")

            End While
            dfd3.Close()

            Dim _Cant_Fabricada As Double = _Fabricado

            '--------------------

            ' ENVIAR EL PRODUCTO AL SIGUIENTE MESON

            If _Enviar_Sig_Meson Then

                If _Reproceso Then

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Cant_Reproceso = Cant_Reproceso - " & _Cant_Fabricada & "
                                    Where IdMeson = " & _IdMeson_Reproceso

                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Else

                    If Not IsNothing(_Row_Potpr) Then

                        If Not _Virtual Then

                            If Not IsNothing(_Row_Next_Operacion) Then

                                Dim _Nex_IdMeson = _Row_Next_Operacion.Item("IdMeson")

                                Dim _Fabricando_ = _Row_Next_Operacion.Item("Fabricando")

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set 
                                    Estado = 'PD',Fabricar = Fabricar + " & _Cant_Fabricada & ", 
                                    Saldo_Fabricar = Saldo_Fabricar + " & _Cant_Fabricada & "
                                    Where IdMeson = " & _Nex_IdMeson

                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                                           "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                                           "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                                           "Where IdMeson = " & _Nex_IdMeson

                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            Else

                                ' Envio de Alerta al siguiente meson

                                If Not String.IsNullOrEmpty(_Alerta.Trim) Then

                                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas (Empresa,Idpotpr,Idpotl,Idpote,Numot,Operacion,Codigoob_Envia,Alerta,Id_Padre_Edit) Values 
                                                    ('" & ModEmpresa & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & numero_(_Numot, 10) &
                                                    "','" & _Operacion & "','" & _Codigoob & "','" & _Alerta & "',0)"

                                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                End If

                                _CodSigMeson = _Codmeson

                                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote," &
                                               "Empresa,Numot,Nreg,Estado,Desde,Operacion,Nombreop,Codigo,Glosa,Asignado_Por," &
                                               "Fecha_Asignacion,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT," &
                                               "Fabricar,Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Potpr,Orden_Meson,Nivel) " &
                                               "VALUES('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & ModEmpresa &
                                               "','" & _Numot & "','" & _Nreg & "','PD','MS'" &
                                               ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                               "','" & FUNCIONARIO & "',Getdate()," & _Fabricar_OT & "," & _Fabricado_OT & "," & _Saldo_Fabricar_OT &
                                               "," & _Fabricado & ",0," & _Fabricado & ",'" & FUNCIONARIO & "'," & _Orden_Potpr &
                                               "," & _Orden_Meson & "," & _Nivel & ")"

                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                        End If

                    Else

                        If _Nivel = 0 Then

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET Estado = 'PT' WHERE IdMeson=" & _IdMeson

                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        Else

                            'SE CREA LA DFA DEFINITIVA EN RANDOM PRODUCCION A PARTIR DE LOS DATOS RESCADOS

                            Consulta_Sql = "Select Top 1 * From POTD" & vbCrLf &
                                           "Where NUMOT = '" & _Numot & "' And CODIGO = '" & _Codigo & "' And PERTENECE <> ''"

                            Dim _Pertenece As String

                            Comando = New SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Idpotpr = dfd1("IDPOLT")
                                _Pertenece = dfd1("PERTENECE")
                            End While
                            dfd1.Close()

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Pertenece = '" & _Pertenece & "'" & vbCrLf &
                                           "Where IdMeson = " & _IdMeson

                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()


                            Dim _Componentes_Pertenece As Integer

                            Consulta_Sql = "Select Count(*) As Cuenta From POTD" & vbCrLf &
                                           "Where NUMOT = '" & _Numot & "' And NREG = '" & _Pertenece & "' and PERTENECE <> '' AND MARCANOM <> ''"

                            Comando = New SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            dfd1 = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Componentes_Pertenece = dfd1("Cuenta")
                            End While
                            dfd1.Close()

                            Dim _Componetes_Fabricados As Integer

                            Consulta_Sql = "Select Count(*) As Cuenta From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
                                           "Where Idpote = " & _Idpote & " And Pertenece = '" & _Pertenece & "'"
                            Comando = New SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            dfd1 = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Componetes_Fabricados = dfd1("Cuenta")
                            End While
                            dfd1.Close()


                            If _Componentes_Pertenece = _Componetes_Fabricados Then

                                'Nota 10-03-20222
                                ' Falta incorporar aca el envio de los productos hacia la tabla de envio y recibo de productos desde un meson a otro
                                ' aca se debe enviar el producto terminado al meson que corresponde...

                                Consulta_Sql = "Select * From POTL Where IDPOTE = " & _Idpote & " And NREG = '" & _Pertenece & "'"

                                Comando = New SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                dfd1 = Comando.ExecuteReader()
                                While dfd1.Read()
                                    _Idpotl = dfd1("IDPOTL")
                                End While
                                dfd1.Close()


                                Consulta_Sql = "Select " & _Idpote & " As Idpote,IDPOTPR As Idpotpr,Pt.IDPOTL As Idpotl,Pt.NUMOT As Numot," &
                                               "Pt.CODIGO As Codigo,Pl.GLOSA As Glosa,NREGOTL As Nreg,Pt.OPERACION As Operacion,Pp.NOMBREOP As Nombreop," &
                                               "ORDEN As Orden_Potpr,Pt.FABRICAR As Fabricar,Pt.REALIZADO As Fabricado," &
                                               "Pt.FABRICAR-Pt.REALIZADO AS Saldo_Fabricar,0 As Nivel," &
                                               "(Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina Where Codmaq = CODMAQOT) As CodMeson" &
                                               vbCrLf &
                                               "Into #Paso" & vbCrLf &
                                               "From POTPR Pt" & vbCrLf &
                                               "Inner Join PMAQUI Mq ON Mq.CODMAQ=Pt.CODMAQOT" & vbCrLf &
                                               "Inner Join POPER Pp On Pp.OPERACION=Pt.OPERACION" & vbCrLf &
                                               "Inner Join POTL Pl ON Pl.IDPOTL=Pt.IDPOTL" & vbCrLf &
                                               "WHERE Pt.IDPOTL = " & _Idpotl & vbCrLf &
                                               "Order By ORDEN" & vbCrLf &
                                               vbCrLf &
                                               "Select Top 1 * From #Paso" & vbCrLf &
                                               "Where CodMeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0)" & vbCrLf &
                                               "Drop Table #Paso"


                                Comando = New SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                dfd1 = Comando.ExecuteReader()
                                While dfd1.Read()

                                    _Codmeson = dfd1("CodMeson")
                                    _Idpote = dfd1("Idpote")
                                    _Idpotl = dfd1("Idpotl")
                                    _Idpotpr = dfd1("Idpotpr")
                                    _Numot = dfd1("Numot")
                                    _Nreg = dfd1("Nreg")
                                    _Operacion = dfd1("Operacion")
                                    _Nombreop = dfd1("Nombreop")
                                    _Codigo = dfd1("Codigo")
                                    _Glosa = dfd1("Glosa")
                                    _Fabricar = dfd1("Fabricar")
                                    _Fabricado = dfd1("Fabricado")
                                    _Saldo_Fabricar = dfd1("Saldo_Fabricar")
                                    _Nivel = dfd1("Nivel")
                                    _Orden_Potpr = dfd1("Orden_Potpr")


                                End While
                                dfd1.Close()

                                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote," &
                                               "Empresa,Numot,Nreg,Estado,Desde,Operacion,Nombreop,Codigo,Glosa,Asignado_Por," &
                                               "Fecha_Asignacion,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT," &
                                               "Fabricar,Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Potpr,Orden_Meson,Nivel) " &
                                               "Values('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & ModEmpresa &
                                               "','" & _Numot & "','" & _Nreg & "','PD','MS'" &
                                               ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                               "','" & FUNCIONARIO & "',Getdate()," & _Fabricar & "," & _Fabricado & "," & _Saldo_Fabricar &
                                               "," & _Fabricar & ",0," & _Fabricar & ",'" & FUNCIONARIO & "'," & _Orden_Potpr &
                                               "," & _Orden_Meson & "," & _Nivel & ")"

                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                        End If

                    End If

                End If

            End If

            'Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos" & vbCrLf &
            '               "Where IdMeson = " & _IdMeson

            'Comando = New SqlCommand(Consulta_Sql, cn2)
            'Comando.Transaction = myTrans
            'Dim dfd2 As SqlDataReader = Comando.ExecuteReader()
            'While dfd2.Read()

            '    Dim _Fabricar2 = dfd2("Fabricar")
            '    Dim _Fabricado2 = dfd2("Fabricado")

            'End While
            'dfd2.Close()

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'FZ'" & vbCrLf &
                           "Where IdMeson = " & _IdMeson & " And Fabricar = Fabricado And Estado <> 'PT'"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            ' El mesón maestro es el encargado de activas los mesones que estan en pausa una vez que genero su trabajo.
            ' El mesón de diseño es el mesón maestro en Ingemad

            If _Maestro Then

                'Nota 10-03-20222
                ' Falta incorporar aca el envio de los productos hacia la tabla de envio y recibo de productos desde un meson a otro

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson

                Comando = New SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Dim dfd As SqlDataReader = Comando.ExecuteReader()
                While dfd.Read()
                    _Porc_Fabricacion = dfd("Porc_Fabricacion")
                End While
                dfd.Close()

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set " & vbCrLf &
                               "Fabricar = Fabricar_OT * " & De_Num_a_Tx_01(_Porc_Fabricacion, False, 5) & "," &
                               "Fecha_Asignacion = Getdate(),Estado = 'PD'" & vbCrLf &
                               "Where Idpotl_Padre = " & _Idpotl & " And IdMeson <> " & _IdMeson & Space(1) &
                               "And Codmeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0 And Estado = 'PS')"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                               "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                               "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                               "Where Idpotl_Padre = " & _Idpotl & " And IdMeson <> " & _IdMeson & Space(1) &
                               "And Codmeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0 And Estado = 'PS')"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD' Where IdMeson = " & _IdMeson & " And Saldo_Fabricar > 0"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            '--- CREAR DFA

            'Throw New System.Exception("Error a proposito!!!")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return True

        Catch ex As Exception

            _Error = ex.Message

            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "TRANSACCION DESECHA" & vbCrLf & "EL PRODUCTO NO FUE ENVIADO AL MESON INTENTE NUEVAMENTE (2)", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            Return 0

        End Try

    End Function

    Function Fx_Agregar_Fabricacion_Con_Porcentaje_Pistoleo(_Codigoob As String,
                                                            _Fila_Mq As DataGridViewRow,
                                                            _Porc_Avance_MQ As Double,
                                                            _Porc_Avance_Saldo_Fab As Double) As Boolean
        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim _Numot As String = _Fila_Mq.Cells("Numot").Value
            Dim _Subot As String = _Fila_Mq.Cells("Subot").Value
            Dim _Codigo As String = _Fila_Mq.Cells("Codigo").Value
            Dim _Descripcion As String = _Fila_Mq.Cells("Descripcion").Value

            Dim _IdMaquina As Integer = _Fila_Mq.Cells("IdMaquina").Value
            Dim _IdMeson As Integer = _Fila_Mq.Cells("IdMeson").Value
            Dim _Idpote As Integer = _Fila_Mq.Cells("Idpote").Value
            Dim _Idpotl As Integer = _Fila_Mq.Cells("Idpotl").Value
            Dim _Idpotpr As Integer = _Fila_Mq.Cells("Idpotpr").Value
            Dim _Codmeson As String = _Fila_Mq.Cells("Codmeson").Value
            Dim _Fabricar As Double = _Fila_Mq.Cells("Fabricar").Value
            Dim _Fabricado As Double = _Fila_Mq.Cells("Fabricado").Value
            Dim _Fabricando As Double = 0

            Dim _Estado As String = _Fila_Mq.Cells("Estado").Value
            Dim _Observacion As String = _Fila_Mq.Cells("Observacion").Value

            'Dim _Porc_Avance_Saldo_Fab As Double = _Fila_Mq_Mq.Item("Porc_Avance_Saldo_Fab")
            'Dim _Porc_Avance_MQ As Double = _Fila_Mq_Mq.Item("Porc_Avance_MQ")

            'Throw New System.Exception("Error a proposito!!!")

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(cn2)

            myTrans = cn2.BeginTransaction()

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & vbCrLf &
                           "Estado='PD'," & vbCrLf &
                           "Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_Saldo_Fab, False, 5) & vbCrLf &
                           ",Fabricando = Fabricando - " & De_Num_a_Tx_01(_Fabricar, False, 5) & vbCrLf &
                           "WHERE IdMeson = " & _IdMeson &
                           vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                           "Estado = 'FMQ',Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_MQ, False, 5) &
                           ",Kocaudet = 'AVANCE',Fecha_Hora_Termino = (Case When Fecha_Hora_Termino Is Null Then Getdate() Else Fecha_Hora_Termino End),Observacion = '" & _Observacion & "'" & vbCrLf &
                           "WHERE IdMaquina = " & _IdMaquina

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Throw New System.Exception("Error a proposito!!!")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return True

        Catch ex As Exception

            _Error = ex.Message
            'Throw New System.Exception("Error a proposito!!!")
            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "TRANSACCION DESECHA" & vbCrLf & "EL PRODUCTO NO FUE ENVIADO AL MESON INTENTE NUEVAMENTE", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            Return False

        End Try

    End Function

    Function Fx_Agregar_Fabricacion_Con_Porcentaje_Manual(_Codigoob As String,
                                                          _Fila_Mq As DataRow,
                                                          _Porc_Avance_MQ As Double,
                                                          _Porc_Avance_Saldo_Fab As Double) As Boolean

        Dim _Numot As String = _Fila_Mq.Item("Numot")
        Dim _Subot As String = _Fila_Mq.Item("Subot")
        Dim _Codigo As String = _Fila_Mq.Item("Codigo")
        Dim _Descripcion As String = _Fila_Mq.Item("Descripcion")

        Dim _IdMaquina As Integer = _Fila_Mq.Item("IdMaquina")
        Dim _IdMeson As Integer = _Fila_Mq.Item("IdMeson")
        Dim _Idpote As Integer = _Fila_Mq.Item("Idpote")
        Dim _Idpotl As Integer = _Fila_Mq.Item("Idpotl")
        Dim _Idpotpr As Integer = _Fila_Mq.Item("Idpotpr")
        Dim _Codmeson As String = _Fila_Mq.Item("Codmeson")
        Dim _Fabricar As Double = _Fila_Mq.Item("Fabricar")
        Dim _Fabricado As Double = _Fila_Mq.Item("Fabricado")
        Dim _Fabricando As Double = 0

        Dim _Estado As String = _Fila_Mq.Item("Estado")
        Dim _Observacion As String = _Fila_Mq.Item("Observacion")

        'Dim _Porc_Avance_Saldo_Fab As Double = _Fila_Mq_Mq.Item("Porc_Avance_Saldo_Fab")
        'Dim _Porc_Avance_MQ As Double = _Fila_Mq_Mq.Item("Porc_Avance_MQ")


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(cn2)

            myTrans = cn2.BeginTransaction()

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & vbCrLf &
                           "Estado='PD'," & vbCrLf &
                           "Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_Saldo_Fab, False, 5) & vbCrLf &
                           ",Fabricando = Fabricando - " & De_Num_a_Tx_01(_Fabricar, False, 5) & vbCrLf &
                           "WHERE IdMeson = " & _IdMeson &
                           vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                           "Estado = 'FMQ',Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_MQ, False, 5) &
                           ",Kocaudet = 'AVANCE',Fecha_Hora_Termino = (Case When Fecha_Hora_Termino Is Null Then Getdate() Else Fecha_Hora_Termino End),Observacion = '" & _Observacion & "'" & vbCrLf &
                           "WHERE IdMaquina = " & _IdMaquina

            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Throw New System.Exception("Error a proposito!!!")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return True

        Catch ex As Exception

            _Error = ex.Message
            'Throw New System.Exception("Error a proposito!!!")
            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "TRANSACCION DESECHA" & vbCrLf & "EL PRODUCTO NO FUE ENVIADO AL MESON INTENTE NUEVAMENTE", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

            myTrans.Rollback()
            Return False

        End Try

    End Function

End Class
