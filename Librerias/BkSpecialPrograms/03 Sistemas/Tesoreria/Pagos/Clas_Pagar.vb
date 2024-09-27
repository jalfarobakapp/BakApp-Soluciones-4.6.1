Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Clas_Pagar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Maedpce As DataRow
    Dim _DocPagados As Integer = 0
    Dim _FechaDelServidor As Date

    Dim _Modp = "$"
    Dim _Timodp = "N"
    Dim _Tamodp = 1



    Public ReadOnly Property Pro_Row_Maedpce() As DataRow
        Get
            Return _Row_Maedpce
        End Get
    End Property
    Public ReadOnly Property Pro_DocPagados() As Integer
        Get
            Return _DocPagados
        End Get
    End Property

    Public Property Modp As Object
        Get
            Return _Modp
        End Get
        Set(value As Object)
            _Modp = value
        End Set
    End Property

    Public Property Timodp As Object
        Get
            Return _Timodp
        End Get
        Set(value As Object)
            _Timodp = value
        End Set
    End Property

    Public Property Tamodp As Object
        Get
            Return _Tamodp
        End Get
        Set(value As Object)
            _Tamodp = value
        End Set
    End Property

#Region "SIGNIFICADO CAMPOS MAEDPCE"

    '_Nucudp = Numero de cheque, deposito o transferencia
    '_Cudp = Numero de cta. cte. del banco 
    '_Emdp = Codigo desde Tabendp, Ej: codigo del banco
    '_Endp = Codigo del proveedor o cliente
    '_Suemdp = Codigo sucursal del cliente o proveedor
    '_Feemdp = Fecha de emisión del pago
    '_Fevedp = Fecha de vencimiento del pago, generalmente fecha de vencimiento de un cheque

    '_Modp = Moneda
    '_Timodp = Tipo moneda (N)acional o (E)xtranjera
    '_Tamodp = Valor de la moneda

    '_Refanti = Observación
    '_Empresa = Empresa
    '_Suredp = Sucursal
    '_Cjredp = Caja

    '_Kotu = Turno
    '_Kofudp = Funcionario

    '_Vadp =  Valor del documento de pago
    '_Vaasdp = Valor asignado al documento de pago, asignado a facturas, boletas, etc..
    '_Vavudp = Vuelto
    '_Esasdp = Estado de asignación de documento de pago (A)signado, (P)endiente 
    '_Vaabdp = Valor abonado al documento de pago

    '_Espgdp = Estado del pago (C)errado, (P)endiente

    '_Cuotas = Cuotas, generalmente para tarjetas de credito
    '_Archirsd = Tabla que indica el documento relacionado
    '_Idrsd = ID de la tabla del documento relacionado

    '_Referencia = ????

#End Region

    Public Sub New()

        _FechaDelServidor = FechaDelServidor()

        Consulta_sql = "Select Top 1 * From MAEMO Where KOMO = 'US$' And FEMO = '" & Format(_FechaDelServidor, "yyyyMMdd") & "' Order By IDMAEMO Desc"
        Dim _RowMoneda_USdolar = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowMoneda_USdolar) Then
            _Tamodp = _RowMoneda_USdolar.Item("VAMO")
        Else
            _Tamodp = 1
        End If

    End Sub

    Function Fx_Crear_Pago_y_Pagar(_Tidp As String,
                                   _Endp As String,
                                   _Suemdp As String,
                                   _Empresa As String,
                                   _Suredp As String,
                                   _Cjredp As String,
                                   _Emdp As String,
                                   _Cudp As String,
                                   _Nucudp As String,
                                   _Feemdp As Date,
                                   _Fevedp As Date,
                                   _Modp As String,
                                   _Timodp As String,
                                   _Tamodp As Double,
                                   _Refanti As String,
                                   _Kotu As Integer,
                                   _Kofudp As String,
                                   _Vadp As Double,
                                   _Vaasdp As Double,
                                   _Vavudp As Double,
                                   _Esasdp As String,
                                   _Vaabdp As Double,
                                   _Espgdp As String,
                                   _Cuotas As Integer,
                                   _Archirsd As String,
                                   _Idrsd As Integer,
                                   _Referencia As Integer,
                                   ByRef _Tbl_Documentos_a_pagar As DataTable) As Integer

        Dim _Sql1, _Sql2 As String
        Dim _Idmaedpce As Integer

        Dim _Nudp As String = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

        Dim _Kotndp As String = RutEmpresa 'Codigo tenedor documento de pago, por defecto el rut de la empresa 
        Dim _Sutndp As String = _Cjredp 'Sucursal tenerdo documento de pago, generalmente se pone el código de la caja

        Dim _Tuvoprotes = 0 'Tuvo protestos True o False

        Dim _Horagrab = Hora_Grab_fx(False)
        Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")

        Dim _Fecha_Emision As String = Format(_Feemdp, "yyyyMMdd")
        Dim _Fecha_Vencimiento As String = Format(_Fevedp, "yyyyMMdd")

        _Endp = _Tbl_Documentos_a_pagar.Rows(0).Item("ENDO")

        _Sql1 = "INSERT INTO MAEDPCE (EMPRESA,TIDP,NUDP,ENDP,NUCUDP,CUDP,EMDP,SUEMDP,FEEMDP,FEVEDP,MODP,TIMODP,TAMODP," &
                "REFANTI,SUREDP,CJREDP,KOTU,KOFUDP,KOTNDP,SUTNDP,TUVOPROTES,VADP,VAASDP,VAVUDP,ESASDP,VAABDP,ESPGDP," &
                "CUOTAS,HORAGRAB,LAHORA,ARCHIRSD,IDRSD,REFERENCIA) VALUES " &
                "('" & _Empresa & "','" & _Tidp & "','" & _Nudp & "','" & _Endp & "','" & _Nucudp & "','" & Trim(_Cudp) & "','" & Trim(_Emdp) &
                "','" & _Suemdp & "','" & _Fecha_Emision & "','" & _Fecha_Vencimiento & "','" & _Modp & "','" & _Timodp &
                "'," & De_Num_a_Tx_01(_Tamodp, False, 5) & ",'" & _Refanti & "','" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp &
                "','" & _Kotndp & "','" & _Sutndp & "'," & _Tuvoprotes &
                "," & De_Num_a_Tx_01(_Vadp, False, 5) &
                "," & De_Num_a_Tx_01(_Vaasdp, False, 5) &
                "," & De_Num_a_Tx_01(_Vavudp, False, 5) &
                ",'" & _Esasdp &
                "'," & De_Num_a_Tx_01(_Vaabdp, False, 5) &
                ",'" & _Espgdp &
                "'," & _Cuotas & "," & _Horagrab & ",'" & _Lahora & "','" & _Archirsd & "'," & _Idrsd & "," & _Referencia & ")"


        For Each _Fila As DataRow In _Tbl_Documentos_a_pagar.Rows

            Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
            Dim _Idmaeven As Integer = _Fila.Item("IDMAEVEN")
            Dim _Abono As String = De_Num_a_Tx_01(_Fila.Item("SALDO"), False, 5)
            Dim _Tido As String = _Fila.Item("TIDO")

            Dim _Chk As Boolean = _Fila.Item("Chk")

            If _Chk Then

                _Sql2 += "UPDATE MAEEDO SET VAABDO= COALESCE(VAABDO,0) +" & _Abono & "  WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                         "UPDATE MAEEDO SET " &
                         "ESPGDO=CASE WHEN ROUND(VABRDO,2)-ROUND(VAABDO,2)-COALESCE(ROUND(VAIVARET,2),0) <= 0 THEN 'C' " &
                         "ELSE ESPGDO END  WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf & vbCrLf &
                         "UPDATE MAEVEN SET VAABVE= COALESCE(VAABVE,0.0)+" & _Abono & "  WHERE IDMAEVEN=" & _Idmaeven & vbCrLf &
                         "UPDATE MAEVEN SET " &
                         "ESPGVE=CASE WHEN ROUND(VAVE,2)-ROUND(VAABVE,2) <= 0 THEN 'C' ELSE ESPGVE END  WHERE IDMAEVEN=" & _Idmaeven & vbCrLf & vbCrLf &
                         "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                         "CJASDP,HORAGRAB,LAHORA) VALUES " &
                         "(@_Idmaedpce," & _Abono & ",'" & _Fecha_Emision & "'," & _Idmaeedo & ",'" & _Tido &
                         "','MAEEDO',0.00000," & _Referencia & ",'" & _Kofudp & "','" & _Suemdp & "','" & _Cjredp & "'," & _Horagrab &
                         ",'" & _Lahora & "')" & vbCrLf & vbCrLf

                _DocPagados += 1

            End If

        Next


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try

            myTrans = cn2.BeginTransaction()

            'CREA EL DOCUMENTO DE PAGO EN LA TABLA MAEDPCE, DOCUMENTO 'PTB'"

            Consulta_sql = _Sql1
            Comando = New SqlClient.SqlCommand(_Sql1, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idmaedpce = dfd1("Identity")
            End While
            dfd1.Close()


            'SELECT TOP 1 IDMAEEDO,EMPRESA,ENDO,TIDO,NUDO,VAPIDO,VAABDO,TIMODO,BLOQUEAPAG FROM MAEEDO WITH ( NOLOCK ) WHERE IDMAEEDO=392530
            'SELECT VAVE,VAABVE,IDMAEVEN  FROM MAEVEN WITH ( NOLOCK )  WHERE IDMAEEDO=392530 AND ESPGVE<>'C' 

            _Sql2 = Replace(_Sql2, "@_Idmaedpce", _Idmaedpce)

            Consulta_sql = _Sql2

            Comando = New SqlClient.SqlCommand(_Sql2, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            '_Referencia = _Sql.Fx_Trae_Dato(, "IDMAEDPCD", "MAEDPCD", "IDMAEDPCE = " & _Idmaedpce)

            Consulta_sql = "Declare @Referencia Int" & vbCrLf &
                           "Set @Referencia = (Select top 1 IDMAEDPCD From MAEDPCD Where IDMAEDPCE = " & _Idmaedpce & ")" & vbCrLf &
                           "UPDATE MAEDPCE SET REFERENCIA = @Referencia WHERE IDMAEDPCE = " & _Idmaedpce & vbCrLf &
                           "UPDATE MAEDPCD SET REFERENCIA = @Referencia WHERE IDMAEDPCE = " & _Idmaedpce

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Consulta_sql = "Select * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
            _Row_Maedpce = _Sql.Fx_Get_DataRow(Consulta_sql)

            'MessageBoxEx.Show(_Formulario, "Transacción realizada correctamente" & vbCrLf & vbCrLf & _
            '                  "Número interno: " & _Tidp & "-" & _Nudp & vbCrLf & " Documentos pagados: " & _DocPagados, "Proceso terminado", _
            '                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return _Idmaedpce

        Catch ex As Exception

            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return 0

        End Try


    End Function

    Function Fx_Crear_Pago_Anticipo(_Tidp As String,
                                    _Endp As String,
                                    _Suemdp As String,
                                    _Empresa As String,
                                    _Suredp As String,
                                    _Cjredp As String,
                                    _Emdp As String,
                                    _Cudp As String,
                                    _Nucudp As String,
                                    _Feemdp As Date,
                                    _Fevedp As Date,
                                    _Modp As String,
                                    _Timodp As String,
                                    _Tamodp As Double,
                                    _Refanti As String,
                                    _Kotu As Integer,
                                    _Kofudp As String,
                                    _Vadp As Double,
                                    _Vaasdp As Double,
                                    _Vavudp As Double,
                                    _Esasdp As String,
                                    _Vaabdp As Double,
                                    _Espgdp As String,
                                    _Cuotas As Integer,
                                    _Archirsd As String,
                                    _Idrsd As Integer,
                                    _Referencia As Integer) As Integer

        Dim _Sql1 As String
        Dim _Idmaedpce As Integer

        Dim _Nudp As String = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

        Dim _Kotndp As String = RutEmpresa 'Codigo tenedor documento de pago, por defecto el rut de la empresa 
        Dim _Sutndp As String = _Cjredp 'Sucursal tenerdo documento de pago, generalmente se pone el código de la caja

        Dim _Tuvoprotes = 0 'Tuvo protestos True o False

        Dim _Horagrab = Hora_Grab_fx(False)
        Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")

        Dim _Fecha_Emision As String = Format(_Feemdp, "yyyyMMdd")
        Dim _Fecha_Vencimiento As String = Format(_Fevedp, "yyyyMMdd")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try

            myTrans = cn2.BeginTransaction()

            Comando = New SqlCommand("Select Max(IDMAEDPCD)+1 As Referencia From MAEDPCD", cn2)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Referencia = dfd("Referencia")
            End While
            dfd.Close()

            Consulta_sql = "INSERT INTO MAEDPCE (EMPRESA,TIDP,NUDP,ENDP,NUCUDP,CUDP,EMDP,SUEMDP,FEEMDP,FEVEDP,MODP,TIMODP,TAMODP," &
                           "REFANTI,SUREDP,CJREDP,KOTU,KOFUDP,KOTNDP,SUTNDP,TUVOPROTES,VADP,VAASDP,VAVUDP,ESASDP,VAABDP,ESPGDP," &
                           "CUOTAS,HORAGRAB,LAHORA,ARCHIRSD,IDRSD,REFERENCIA) VALUES " &
                           "('" & _Empresa & "','" & _Tidp & "','" & _Nudp & "','" & _Endp & "','" & _Nucudp & "','" & Trim(_Cudp) & "','" & Trim(_Emdp) &
                           "','" & _Suemdp & "','" & _Fecha_Emision & "','" & _Fecha_Vencimiento & "','" & _Modp & "','" & _Timodp &
                           "'," & _Tamodp & ",'" & _Refanti & "','" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp &
                           "','" & _Kotndp & "','" & _Sutndp & "'," & _Tuvoprotes &
                           "," & De_Num_a_Tx_01(_Vadp, False, 5) &
                           "," & De_Num_a_Tx_01(_Vaasdp, False, 5) &
                           "," & De_Num_a_Tx_01(_Vavudp, False, 5) &
                           ",'" & _Esasdp &
                           "'," & De_Num_a_Tx_01(_Vaabdp, False, 5) &
                           ",'" & _Espgdp &
                           "'," & _Cuotas & "," & _Horagrab & ",'" & _Lahora & "','" & _Archirsd & "'," & _Idrsd & "," & _Referencia & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idmaedpce = dfd1("Identity")
            End While
            dfd1.Close()

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return _Idmaedpce

        Catch ex As Exception

            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return 0

        End Try


    End Function

    Function Fx_Crear_Pago_Anticipo(_Row_Maedpce As DataRow) As Integer

        Dim _Idmaedpce As Integer

        Dim _Tidp As String = _Row_Maedpce.Item("TIDP")
        Dim _Endp As String = _Row_Maedpce.Item("ENDP")
        Dim _Suemdp As String = _Row_Maedpce.Item("SUEMDP")
        Dim _Empresa As String = _Row_Maedpce.Item("EMPRESA")
        Dim _Suredp As String = _Row_Maedpce.Item("SUREDP")
        Dim _Cjredp As String = _Row_Maedpce.Item("CJREDP")
        Dim _Emdp As String = _Row_Maedpce.Item("EMDP")
        Dim _Cudp As String = _Row_Maedpce.Item("CUDP")
        Dim _Nucudp As String = _Row_Maedpce.Item("NUCUDP")
        Dim _Feemdp As String = Format(_Row_Maedpce.Item("FEEMDP"), "yyyyMMdd")
        Dim _Fevedp As String = Format(_Row_Maedpce.Item("FEVEDP"), "yyyyMMdd")
        Dim _Modp As String = _Row_Maedpce.Item("MODP")
        Dim _Timodp As String = _Row_Maedpce.Item("TIMODP")
        Dim _Tamodp As String = De_Num_a_Tx_01(_Row_Maedpce.Item("TAMODP"), False, 5)
        Dim _Refanti As String = _Row_Maedpce.Item("REFANTI")
        Dim _Kotu As Integer = _Row_Maedpce.Item("KOTU")
        Dim _Kofudp As String = _Row_Maedpce.Item("KOFUDP")
        Dim _Vadp As String = De_Num_a_Tx_01(_Row_Maedpce.Item("VADP"), False, 5)
        Dim _Vaasdp As String = De_Num_a_Tx_01(_Row_Maedpce.Item("VAASDP"), False, 5)
        Dim _Vavudp As String = De_Num_a_Tx_01(_Row_Maedpce.Item("VAVUDP"), False, 5)
        Dim _Esasdp As String = _Row_Maedpce.Item("ESASDP")
        Dim _Vaabdp As String = De_Num_a_Tx_01(_Row_Maedpce.Item("VAABDP"), False, 5)
        Dim _Espgdp As String = _Row_Maedpce.Item("ESPGDP")
        Dim _Cuotas As Integer = _Row_Maedpce.Item("CUOTAS")
        Dim _Archirsd As String = _Row_Maedpce.Item("ARCHIRSD")
        Dim _Idrsd As Integer = _Row_Maedpce.Item("IDRSD")
        Dim _Referencia As Integer '= _Row_Maedpce.Item("REFERENCIA")

        Dim _Nudp As String = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

        Dim _Kotndp As String = RutEmpresa 'Codigo tenedor documento de pago, por defecto el rut de la empresa 
        Dim _Sutndp As String = _Cjredp 'Sucursal tenerdo documento de pago, generalmente se pone el código de la caja
        Dim _Tuvoprotes = 0 'Tuvo protestos True o False

        Dim _Horagrab = Hora_Grab_fx(False)
        Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try

            myTrans = cn2.BeginTransaction()

            Comando = New SqlCommand("Select Max(IDMAEDPCD)+1 As Referencia From MAEDPCD", cn2)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Referencia = dfd("Referencia")
            End While
            dfd.Close()

            Consulta_sql = "INSERT INTO MAEDPCE (EMPRESA,TIDP,NUDP,ENDP,NUCUDP,CUDP,EMDP,SUEMDP,FEEMDP,FEVEDP,MODP,TIMODP,TAMODP," &
                           "REFANTI,SUREDP,CJREDP,KOTU,KOFUDP,KOTNDP,SUTNDP,TUVOPROTES,VADP,VAASDP,VAVUDP,ESASDP,VAABDP,ESPGDP," &
                           "CUOTAS,HORAGRAB,LAHORA,ARCHIRSD,IDRSD,REFERENCIA) VALUES " &
                           "('" & _Empresa & "','" & _Tidp & "','" & _Nudp & "','" & _Endp & "','" & _Nucudp & "','" & _Cudp & "','" & _Emdp &
                           "','" & _Suemdp & "','" & _Feemdp & "','" & _Fevedp & "','" & _Modp & "','" & _Timodp &
                           "'," & _Tamodp & ",'" & _Refanti & "','" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp &
                           "','" & _Kotndp & "','" & _Sutndp & "'," & _Tuvoprotes &
                           "," & _Vadp & "," & _Vaasdp & "," & _Vavudp & ",'" & _Esasdp & "'," & _Vaabdp &
                           ",'" & _Espgdp &
                           "'," & _Cuotas & "," & _Horagrab & ",'" & _Lahora & "','" & _Archirsd & "'," & _Idrsd & "," & _Referencia & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idmaedpce = dfd1("Identity")
            End While
            dfd1.Close()

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return _Idmaedpce

        Catch ex As Exception

            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return 0

        End Try


    End Function

    Function Fx_Crear_Pago_MAEDPCE(_Formulario As Form,
                                   _Idmaeedo As Integer,
                                   _Tbl_Pagos As DataTable,
                                   _Fecha_Asignacion_Pago As Date) As Integer


        Dim _Row_Maeedo As DataRow
        Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Idmaedpce As Integer

        Dim _Empresa As String
        Dim _Endp As String
        Dim _Nucudp As String
        Dim _Cudp As String
        Dim _Emdp As String
        Dim _Suemdp As String

        Dim _Feemdp As String '= Format(_Feemdp, "yyyyMMdd") Fecha Emision
        Dim _Fevedp As String '= Format(_Fevedp, "yyyyMMdd") Fecha Vencimiento

        Dim _Modp As String
        Dim _Timodp As String

        Dim _Tamodp As String
        Dim _Refanti As String
        Dim _Suredp As String
        Dim _Kotu As String
        Dim _Kofudp As String

        Dim _Cjredp As String
        Dim _Tidp As String

        Dim _Nudp As String '= Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

        Dim _Kotndp As String = RutEmpresa 'Codigo tenedor documento de pago, por defecto el rut de la empresa 
        Dim _Sutndp As String  'Sucursal tenerdo documento de pago, generalmente se pone el código de la caja "_Cjredp"

        Dim _Tuvoprotes = 0 'Tuvo protestos True o False

        Dim _Horagrab = Hora_Grab_fx(False)
        Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")

        Dim _Vadp As Double
        Dim _Vaasdp As Double
        Dim _Vavudp As Double
        Dim _Vaabdp As Double

        Dim _Docuenanti
        Dim _Nutransmi

        Dim _Esasdp As String
        Dim _Espgdp As String

        Dim _Cuotas As Integer

        Dim _Archirsd As String
        Dim _Idrsd As Integer

        Dim _Referencia As String
        Dim _Idmaeven As Integer

        'Dim _Lista_Idmaedpce As New List(Of String)

        Try

            Consulta_sql = "SELECT VAVE,VAABVE,IDMAEVEN FROM MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & " AND ESPGVE<>'C'"
            Dim _Tbl_Maeven As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Convert.ToBoolean(_Tbl_Maeven.Rows.Count) Then
                _Idmaeven = _Tbl_Maeven.Rows(0).Item("IDMAEVEN")
            Else
                _Idmaeven = 0
            End If

        Catch ex As Exception
            MessageBoxEx.Show(_Formulario, ex.Message, "Problema En tabla MAEVEN!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return 0
        End Try

        Consulta_sql = "Select * From CONFIEST WITH (NOLOCK) Where MODALIDAD = '  '"
        Dim _Row_Confiest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cuotacomer As Boolean = _Row_Confiest.Item("CUOTACOMER")
        Dim _Cuotacanti As Integer = _Row_Confiest.Item("CUOTACANTI")


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        myTrans = cn2.BeginTransaction()


        Try

            Dim _Abono As Double = 0
            Dim _Abono_Cuotas As Double = 0

            Consulta_sql = "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                           "CJASDP,HORAGRAB,LAHORA) VALUES " &
                           "(" & _Idmaedpce & "," & _Vaasdp & ",'19990101'," & _Idmaeedo & ",'','MAEEDO',0,'','','',''," & _Horagrab & ",'" & _Lahora & "')" & vbCrLf & vbCrLf

            Consulta_sql = Consulta_sql
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Referencia = dfd("Identity")
            End While
            dfd.Close()

            Consulta_sql = "Delete MAEDPCD Where IDMAEDPCD = " & _Referencia
            Consulta_sql = Consulta_sql
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Dim _Tidopa As String = _Row_Maeedo.Item("TIDO")
            Dim _Feasdp As String = Format(_Fecha_Asignacion_Pago, "yyyyMMdd")


            For Each _Fila As DataRow In _Tbl_Pagos.Rows

                _Idmaedpce = _Fila.Item("IDMAEDPCE")
                _Empresa = _Fila.Item("EMPRESA")
                _Tidp = _Fila.Item("TIDP")

                If Not String.IsNullOrEmpty(_Tidp) Then

                    _Endp = NuloPorNro(_Fila.Item("ENDP"), "")
                    _Emdp = NuloPorNro(_Fila.Item("EMDP"), "")
                    _Suemdp = _Fila.Item("SUEMDP")
                    _Cudp = _Fila.Item("CUDP")
                    _Nucudp = _Fila.Item("NUCUDP")

                    _Feemdp = Format(_Fila.Item("FEEMDP"), "yyyyMMdd")
                    _Fevedp = Format(_Fila.Item("FEVEDP"), "yyyyMMdd")
                    _Modp = _Fila.Item("MODP")
                    _Timodp = _Fila.Item("TIMODP")
                    _Tamodp = De_Num_a_Tx_01(_Fila.Item("TAMODP"), False, 5)
                    _Refanti = _Fila.Item("REFANTI")
                    _Suredp = _Fila.Item("SUREDP")
                    _Cjredp = _Fila.Item("CJREDP")
                    _Kotu = _Fila.Item("KOTU")
                    _Kofudp = _Fila.Item("KOFUDP")
                    _Kotndp = _Fila.Item("KOTNDP")
                    _Sutndp = _Fila.Item("SUTNDP")

                    _Docuenanti = _Fila.Item("DOCUENANTI")
                    _Nutransmi = _Fila.Item("NUTRANSMI")

                    _Tuvoprotes = 0

                    _Vadp = _Fila.Item("VADP")
                    _Vaasdp = _Fila.Item("VAASDP")
                    _Vavudp = _Fila.Item("VAVUDP")
                    _Esasdp = _Fila.Item("ESASDP")
                    _Vaabdp = _Fila.Item("VAABDP")
                    _Espgdp = _Fila.Item("ESPGDP")
                    _Cuotas = _Fila.Item("CUOTAS")

                    If CBool(_Idmaedpce) Then

                        Consulta_sql = "UPDATE MAEDPCE SET VAASDP = ROUND(" & _Vaasdp & "+VAASDP,0),
                                        ESASDP=CASE WHEN ROUND( VADP-VAVUDP-(" & _Vaasdp & "+VAASDP),0) <= 0 THEN 'A' ELSE 'P' END WHERE IDMAEDPCE = " & _Idmaedpce

                        Consulta_sql = Consulta_sql
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Consulta_sql = "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                                       "CJASDP,HORAGRAB,LAHORA) VALUES " &
                                       "(" & _Idmaedpce & "," & _Vaasdp & ",'" & _Feasdp & "'," & _Idmaeedo & ",'" & _Tidopa &
                                       "','MAEEDO'," & _Tamodp & ",'" & _Referencia & "','" & _Kofudp & "','" & _Suredp & "','" & _Cjredp & "'," & _Horagrab &
                                       ",'" & _Lahora & "')" & vbCrLf & vbCrLf

                        Consulta_sql = Consulta_sql
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        _Abono += _Vaasdp

                    Else

                        If _Tidp = "TJV" And _Cuotas > 1 Then

                            If _Cuotacomer Then

                                If _Cuotas > _Cuotacanti Then

                                    _Cuotas = 1

                                End If

                            End If

                        Else

                            _Cuotas = 1

                        End If

                        _Nudp = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

                        Dim _Valor_Cuota As Double
                        Dim _Valor_Vadp As Double = _Vadp
                        Dim _Suma_Valores_Cuotas As Double = 0
                        Dim _Fecha_Fevedp As Date = FormatDateTime(_Fila.Item("FEVEDP"), DateFormat.ShortDate)

                        Dim _Cuota As Integer

                        For i = 1 To _Cuotas

                            If _Cuotas <> 1 Then

                                Dim _Decimal As Double = 0

                                _Valor_Cuota = _Valor_Vadp / _Cuotas

                                Dim _Decimales = Split(_Valor_Cuota, ",")

                                If _Decimales.Length > 1 Then
                                    _Decimal = _Decimales(1)
                                    _Valor_Cuota = _Decimales(0)
                                End If

                                If i = _Cuotas Then
                                    _Valor_Cuota = _Valor_Vadp - _Abono_Cuotas
                                End If

                                _Vadp = _Valor_Cuota
                                _Vaasdp = _Valor_Cuota

                                If i <> 1 Then

                                    _Nudp = Fx_Proximo_NroDocumento(_Nudp, 10)

                                    _Fecha_Fevedp = DateAdd(DateInterval.Day, 30, _Fecha_Fevedp)
                                    _Fevedp = Format(_Fecha_Fevedp, "yyyyMMdd")

                                End If

                            End If

                            If _Tidp = "TJV" Then
                                _Cuota = i
                            Else
                                _Cuota = 0
                            End If


                            Consulta_sql =
                                    "INSERT INTO MAEDPCE (EMPRESA,TIDP,NUDP,ENDP,NUCUDP,CUDP,EMDP,SUEMDP,FEEMDP,FEVEDP,MODP,TIMODP,TAMODP," &
                                    "REFANTI,SUREDP,CJREDP,KOTU,KOFUDP,KOTNDP,SUTNDP,TUVOPROTES,VADP,VAASDP,VAVUDP,ESASDP,VAABDP,ESPGDP," &
                                    "CUOTAS,HORAGRAB,LAHORA,REFERENCIA,DOCUENANTI,NUTRANSMI) VALUES " &
                                    "('" & _Empresa & "','" & _Tidp & "','" & _Nudp & "','" & _Endp & "','" & _Nucudp & "','" & Trim(_Cudp) &
                                    "','" & Trim(_Emdp) &
                                    "','" & _Suemdp & "','" & _Feemdp & "','" & _Fevedp & "','" & _Modp & "','" & _Timodp &
                                    "'," & _Tamodp & ",'" & _Refanti & "','" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp &
                                    "','" & _Kotndp & "','" & _Sutndp & "'," & _Tuvoprotes &
                                    "," & De_Num_a_Tx_01(_Vadp, False, 5) &
                                    "," & De_Num_a_Tx_01(_Vaasdp, False, 5) &
                                    "," & De_Num_a_Tx_01(_Vavudp, False, 5) &
                                    ",'" & _Esasdp &
                                    "'," & De_Num_a_Tx_01(_Vaabdp, False, 5) &
                                    ",'" & _Espgdp &
                                    "'," & _Cuota & "," & _Horagrab & ",'" & _Lahora & "','" & _Referencia & "','" & _Docuenanti & "','" & _Nutransmi & "')"

                            Consulta_sql = Consulta_sql
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                            Comando.Transaction = myTrans
                            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Idmaedpce = dfd1("Identity")
                            End While
                            dfd1.Close()

                            Consulta_sql =
                                    "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                                    "CJASDP,HORAGRAB,LAHORA) VALUES " &
                                    "(" & _Idmaedpce & "," & _Vaasdp & ",'" & _Feasdp & "'," & _Idmaeedo & ",'" & _Tidopa &
                                    "','MAEEDO'," & _Tamodp & ",'" & _Referencia & "','" & _Kofudp & "','" & _Suredp & "','" & _Cjredp & "'," & _Horagrab &
                                    ",'" & _Lahora & "')" & vbCrLf & vbCrLf

                            Consulta_sql = Consulta_sql
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            _Abono += _Vaasdp

                            If _Tidp = "TJV" Then
                                _Abono_Cuotas += _Vaasdp
                            End If

                        Next

                    End If

                End If

            Next

            If _Abono = 0 Then
                myTrans.Rollback()
                Return 0
            End If

            Consulta_sql = "UPDATE MAEEDO SET VAABDO=ROUND( VAABDO+" & _Abono & ",0)," &
                           "ESPGDO=CASE WHEN ROUND( VABRDO-VAABDO-" & _Abono & ",0) <= 0.0 THEN 'C' ELSE ESPGDO END" & Space(1) &
                           "WHERE IDMAEEDO=" & _Idmaeedo '&

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo & " And VAVE <> VAABVE Order By IDMAEVEN", cn2)
            Comando.Transaction = myTrans

            Dim _Vave As Double
            Dim _Vaabve As Double
            Dim _Saldo_Abono As Double = _Abono

            Dim dfd2 As SqlDataReader = Comando.ExecuteReader()

            Dim _Lista As New List(Of String)

            While dfd2.Read()

                _Idmaeven = dfd2("IDMAEVEN")
                _Vave = dfd2("VAVE")
                _Vaabve = dfd2("VAABVE")

                Dim _Saldo As Double = _Vave - _Vaabve

                If _Saldo > _Saldo_Abono Then
                    _Saldo = _Saldo_Abono
                End If

                If _Saldo >= 0 Then
                    If _Saldo_Abono > 0 Then
                        _Lista.Add(_Idmaeven & ";" & De_Num_a_Tx_01(_Saldo, False, 5))
                        _Saldo_Abono -= _Saldo
                    End If
                End If

            End While

            dfd2.Close()

            For Each _Fl_Maeven As String In _Lista

                Dim _Valores = Split(_Fl_Maeven, ";")

                _Idmaeven = _Valores(0)
                Dim _Vaasdp_Str As String = _Valores(1)

                Consulta_sql = "Update MAEVEN Set VAABVE=VAABVE+Round(" & _Vaasdp_Str & ",0)," &
                               "ESPGVE=Case When ROUND(VAVE,2)-ROUND(VAABVE+" & _Vaasdp_Str & ",0) <= 0 THEN 'C' Else '' End Where IDMAEVEN = " & _Idmaeven
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            Next

            'Throw New System.Exception("An exception has occurred.")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Consulta_sql = "Select * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
            _Row_Maedpce = _Sql.Fx_Get_DataRow(Consulta_sql)

            Return _Idmaedpce

        Catch ex As Exception

            Try
                myTrans.Rollback()
            Catch ex2 As Exception

            End Try

            MessageBoxEx.Show(_Formulario, "Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return 0

        End Try

    End Function

    Function Fx_Crear_Pago_MAEDPCE2(_Formulario As Form,
                                    _Idmaeedo As Integer,
                                    _Tbl_Maedpce As DataTable,
                                    _Fecha_Asignacion_Pago As Date) As Integer


        Dim _Row_Maeedo As DataRow
        Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Idmaedpce As Integer

        Dim _Empresa As String
        Dim _Endp As String
        Dim _Nucudp As String
        Dim _Cudp As String
        Dim _Emdp As String
        Dim _Suemdp As String

        Dim _Feemdp As String '= Format(_Feemdp, "yyyyMMdd") Fecha Emision
        Dim _Fevedp As String '= Format(_Fevedp, "yyyyMMdd") Fecha Vencimiento

        Dim _Modp As String
        Dim _Timodp As String

        Dim _Tamodp As String
        Dim _Refanti As String
        Dim _Suredp As String
        Dim _Kotu As String
        Dim _Kofudp As String

        Dim _Cjredp As String
        Dim _Tidp As String

        Dim _Nudp As String '= Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

        Dim _Kotndp As String = RutEmpresa 'Codigo tenedor documento de pago, por defecto el rut de la empresa 
        Dim _Sutndp As String  'Sucursal tenerdo documento de pago, generalmente se pone el código de la caja "_Cjredp"

        Dim _Tuvoprotes = 0 'Tuvo protestos True o False

        Dim _Horagrab = Hora_Grab_fx(False)
        Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")

        Dim _Vadp As Double
        Dim _Vaasdp As Double
        Dim _Vavudp As Double
        Dim _Vaabdp As Double

        Dim _Docuenanti
        Dim _Nutransmi

        Dim _Esasdp As String
        Dim _Espgdp As String

        Dim _Cuotas As Integer

        Dim _Archirsd As String
        Dim _Idrsd As Integer

        Dim _Referencia As String
        Dim _Idmaeven As Integer
        Dim _Ley20956 As Integer


        Try

            Consulta_sql = "SELECT VAVE,VAABVE,IDMAEVEN FROM MAEVEN WHERE IDMAEEDO = " & _Idmaeedo & " AND ESPGVE<>'C'"
            Dim _Tbl_Maeven As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Convert.ToBoolean(_Tbl_Maeven.Rows.Count) Then
                _Idmaeven = _Tbl_Maeven.Rows(0).Item("IDMAEVEN")
            Else
                _Idmaeven = 0
            End If

        Catch ex As Exception
            MessageBoxEx.Show(_Formulario, ex.Message, "Problema En tabla MAEVEN!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return 0
        End Try

        Consulta_sql = "Select * From CONFIEST WITH (NOLOCK) Where MODALIDAD = '  '"
        Dim _Row_Confiest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cuotacomer As Boolean = _Row_Confiest.Item("CUOTACOMER")
        Dim _Cuotacanti As Integer = _Row_Confiest.Item("CUOTACANTI")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        myTrans = cn2.BeginTransaction()


        Try

            Dim _Abono As Double = 0
            Dim _Abono_Cuotas As Double = 0

            Consulta_sql = "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                           "CJASDP,HORAGRAB,LAHORA) VALUES " &
                           "(" & _Idmaedpce & "," & _Vaasdp & ",'19990101'," & _Idmaeedo & ",'','MAEEDO',0,'','','',''," & _Horagrab & ",'" & _Lahora & "')" & vbCrLf & vbCrLf

            Consulta_sql = Consulta_sql
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Referencia = dfd("Identity")
            End While
            dfd.Close()

            Consulta_sql = "Delete MAEDPCD Where IDMAEDPCD = " & _Referencia
            Consulta_sql = Consulta_sql
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Dim _Tidopa As String = _Row_Maeedo.Item("TIDO")
            Dim _Feasdp As String = Format(_Fecha_Asignacion_Pago, "yyyyMMdd")

            For Each _Fila As DataRow In _Tbl_Maedpce.Rows

                _Idmaedpce = _Fila.Item("IDMAEDPCE")
                _Empresa = _Fila.Item("EMPRESA")
                _Tidp = _Fila.Item("TIDP")

                If Not String.IsNullOrEmpty(_Tidp) Then

                    _Endp = NuloPorNro(_Fila.Item("ENDP"), "")
                    _Emdp = NuloPorNro(_Fila.Item("EMDP"), "")
                    _Suemdp = _Fila.Item("SUEMDP")
                    _Cudp = _Fila.Item("CUDP")
                    _Nucudp = _Fila.Item("NUCUDP")

                    _Feemdp = Format(_Fila.Item("FEEMDP"), "yyyyMMdd")
                    _Fevedp = Format(_Fila.Item("FEVEDP"), "yyyyMMdd")
                    _Modp = _Fila.Item("MODP")
                    _Timodp = _Fila.Item("TIMODP")
                    _Tamodp = De_Num_a_Tx_01(_Fila.Item("TAMODP"), False, 5)
                    _Refanti = _Fila.Item("REFANTI")
                    _Suredp = _Fila.Item("SUREDP")
                    _Cjredp = _Fila.Item("CJREDP")
                    _Kotu = _Fila.Item("KOTU")
                    _Kofudp = _Fila.Item("KOFUDP")
                    _Kotndp = _Fila.Item("KOTNDP")
                    _Sutndp = _Fila.Item("SUTNDP")

                    _Docuenanti = _Fila.Item("DOCUENANTI")
                    _Nutransmi = _Fila.Item("NUTRANSMI")

                    _Tuvoprotes = 0

                    _Vadp = _Fila.Item("VADP")
                    _Vaasdp = _Fila.Item("VAASDP")
                    _Vavudp = _Fila.Item("VAVUDP")
                    _Esasdp = _Fila.Item("ESASDP")
                    _Vaabdp = _Fila.Item("VAABDP")
                    _Espgdp = _Fila.Item("ESPGDP")
                    _Cuotas = _Fila.Item("CUOTAS")


                    If CBool(_Idmaedpce) Then

                        Consulta_sql = "UPDATE MAEDPCE SET VAASDP = ROUND(" & _Vaasdp & "+VAASDP,0),
                                        ESASDP=CASE WHEN ROUND( VADP-VAVUDP-(" & _Vaasdp & "+VAASDP),0) <= 0 THEN 'A' ELSE 'P' END WHERE IDMAEDPCE = " & _Idmaedpce

                        Consulta_sql = Consulta_sql
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Consulta_sql = "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                                       "CJASDP,HORAGRAB,LAHORA) VALUES " &
                                       "(" & _Idmaedpce & "," & _Vaasdp & ",'" & _Feasdp & "'," & _Idmaeedo & ",'" & _Tidopa &
                                       "','MAEEDO'," & _Tamodp & ",'" & _Referencia & "','" & _Kofudp & "','" & _Suredp & "','" & _Cjredp & "'," & _Horagrab &
                                       ",'" & _Lahora & "')" & vbCrLf & vbCrLf

                        Consulta_sql = Consulta_sql
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        _Abono += _Vaasdp

                    Else

                        _Ley20956 = _Fila.Item("LEY20956")
                        '_Archirsd = "MAEEDO"
                        '_Idrsd = _Row_Maeedo.Item("IDMAEEDO")

                        If _Tidp = "TJV" And _Cuotas > 1 Then

                            If _Cuotacomer Then

                                If _Cuotas > _Cuotacanti Then

                                    _Cuotas = 1

                                End If

                            End If

                        Else

                            _Cuotas = 1

                        End If

                        _Nudp = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

                        Dim _Valor_Cuota As Double
                        Dim _Valor_Vadp As Double = _Vadp
                        Dim _Suma_Valores_Cuotas As Double = 0
                        Dim _Fecha_Fevedp As Date = FormatDateTime(_Fila.Item("FEVEDP"), DateFormat.ShortDate)

                        Dim _Cuota As Integer

                        For i = 1 To _Cuotas

                            If _Cuotas <> 1 Then

                                Dim _Decimal As Double = 0

                                _Valor_Cuota = _Valor_Vadp / _Cuotas

                                Dim _Decimales = Split(_Valor_Cuota, ",")

                                If _Decimales.Length > 1 Then
                                    _Decimal = _Decimales(1)
                                    _Valor_Cuota = _Decimales(0)
                                End If

                                If i = _Cuotas Then
                                    _Valor_Cuota = _Valor_Vadp - _Abono_Cuotas
                                End If

                                _Vadp = _Valor_Cuota
                                _Vaasdp = _Valor_Cuota

                                _Suma_Valores_Cuotas += _Vadp

                                If i <> 1 Then

                                    _Nudp = Fx_Proximo_NroDocumento(_Nudp, 10)

                                    _Fecha_Fevedp = DateAdd(DateInterval.Day, 30, _Fecha_Fevedp)
                                    _Fevedp = Format(_Fecha_Fevedp, "yyyyMMdd")

                                End If

                                If i = _Cuotas Then

                                    Dim _SaldoPesos As Double = _Valor_Vadp - _Suma_Valores_Cuotas

                                    'If (_Valor_Vadp - _Suma_Valores_Cuotas) = 1 Then
                                    _Vadp += _SaldoPesos
                                    _Vaasdp += _SaldoPesos
                                    'End If

                                End If

                            End If

                            If _Tidp = "TJV" Then
                                _Cuota = i
                            Else
                                _Cuota = 0
                            End If


                            Consulta_sql =
                                "INSERT INTO MAEDPCE (EMPRESA,TIDP,NUDP,ENDP,NUCUDP,CUDP,EMDP,SUEMDP,FEEMDP,FEVEDP,MODP,TIMODP,TAMODP," &
                                "REFANTI,SUREDP,CJREDP,KOTU,KOFUDP,KOTNDP,SUTNDP,TUVOPROTES,VADP,VAASDP,VAVUDP,ESASDP,VAABDP,ESPGDP," &
                                "CUOTAS,HORAGRAB,LAHORA,REFERENCIA,DOCUENANTI,NUTRANSMI,LEY20956) VALUES " &
                                "('" & _Empresa & "','" & _Tidp & "','" & _Nudp & "','" & _Endp & "','" & _Nucudp & "','" & Trim(_Cudp) &
                                "','" & Trim(_Emdp) &
                                "','" & _Suemdp & "','" & _Feemdp & "','" & _Fevedp & "','" & _Modp & "','" & _Timodp &
                                "'," & _Tamodp & ",'" & _Refanti & "','" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp &
                                "','" & _Kotndp & "','" & _Sutndp & "'," & _Tuvoprotes &
                                "," & De_Num_a_Tx_01(_Vadp, False, 5) &
                                "," & De_Num_a_Tx_01(_Vaasdp, False, 5) &
                                "," & De_Num_a_Tx_01(_Vavudp, False, 5) &
                                ",'" & _Esasdp &
                                "'," & De_Num_a_Tx_01(_Vaabdp, False, 5) &
                                ",'" & _Espgdp &
                                "'," & _Cuota & "," & _Horagrab & ",'" & _Lahora & "','" & _Referencia & "','" & _Docuenanti & "','" & _Nutransmi & "'," & _Ley20956 & ")"

                            Consulta_sql = Consulta_sql
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                            Comando.Transaction = myTrans
                            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Idmaedpce = dfd1("Identity")
                            End While
                            dfd1.Close()

                            Consulta_sql =
                                "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                                "CJASDP,HORAGRAB,LAHORA) VALUES " &
                                "(" & _Idmaedpce & "," & _Vaasdp & ",'" & _Feasdp & "'," & _Idmaeedo & ",'" & _Tidopa &
                                "','MAEEDO'," & _Tamodp & ",'" & _Referencia & "','" & _Kofudp & "','" & _Suredp & "','" & _Cjredp & "'," & _Horagrab &
                                ",'" & _Lahora & "')" & vbCrLf & vbCrLf

                            Consulta_sql = Consulta_sql
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            _Abono += _Vaasdp

                            If _Tidp = "TJV" Then
                                _Abono_Cuotas += _Vaasdp
                            End If

                        Next

                    End If

                End If

            Next

            If _Abono = 0 Then
                myTrans.Rollback()
                Return 0
            End If

            Consulta_sql = "UPDATE MAEEDO SET VAABDO=ROUND( VAABDO+" & _Abono & ",0)," &
                           "ESPGDO=CASE WHEN ROUND( VABRDO-VAABDO-" & _Abono & ",0) <= 0.0 THEN 'C' ELSE ESPGDO END" & Space(1) &
                           "WHERE IDMAEEDO=" & _Idmaeedo '&

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo & " And VAVE <> VAABVE Order By IDMAEVEN", cn2)
            Comando.Transaction = myTrans

            Dim _Vave As Double
            Dim _Vaabve As Double
            Dim _Saldo_Abono As Double = _Abono

            Dim dfd2 As SqlDataReader = Comando.ExecuteReader()

            Dim _Lista As New List(Of String)

            While dfd2.Read()

                _Idmaeven = dfd2("IDMAEVEN")
                _Vave = dfd2("VAVE")
                _Vaabve = dfd2("VAABVE")

                Dim _Saldo As Double = _Vave - _Vaabve

                If _Saldo > _Saldo_Abono Then
                    _Saldo = _Saldo_Abono
                End If

                If _Saldo >= 0 Then
                    If _Saldo_Abono > 0 Then
                        _Lista.Add(_Idmaeven & ";" & De_Num_a_Tx_01(_Saldo, False, 5))
                        _Saldo_Abono -= _Saldo
                    End If
                End If

            End While

            dfd2.Close()

            For Each _Fl_Maeven As String In _Lista

                Dim _Valores = Split(_Fl_Maeven, ";")

                _Idmaeven = _Valores(0)
                Dim _Vaasdp_Str As String = _Valores(1)

                Consulta_sql = "Update MAEVEN Set VAABVE=VAABVE+Round(" & _Vaasdp_Str & ",0)," &
                               "ESPGVE=Case When ROUND(VAVE,2)-ROUND(VAABVE+" & _Vaasdp_Str & ",0) <= 0 THEN 'C' Else '' End Where IDMAEVEN = " & _Idmaeven
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Consulta_sql = "Select * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
            _Row_Maedpce = _Sql.Fx_Get_DataRow(Consulta_sql)

            Return _Idmaedpce

        Catch ex As Exception

            myTrans.Rollback()

            MessageBoxEx.Show(_Formulario, "Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return 0

        End Try

    End Function

    Function Fx_Crear_Pago_MAEDPCE_Generales(_Formulario As Form,
                                             ByRef _Tbl_Maedpce As DataTable,
                                             _Tbl_Cta_Entidad As DataTable,
                                             _Fecha_Asig_Fecha_Actual As Boolean,
                                             _Fecha_Asignacion_Pago As Date,
                                             _Aplica_Ley_20956 As Boolean) As Boolean


        Dim _Idmaedpce As Integer

        Dim _Empresa As String
        Dim _Endp As String
        Dim _Nucudp As String
        Dim _Cudp As String
        Dim _Emdp As String
        Dim _Suemdp As String

        Dim _Feemdp As String '= Format(_Feemdp, "yyyyMMdd") Fecha Emision
        Dim _Fevedp As String '= Format(_Fevedp, "yyyyMMdd") Fecha Vencimiento

        Dim _Modp As String
        Dim _Timodp As String

        Dim _Tamodp As String
        Dim _Refanti As String
        Dim _Suredp As String
        Dim _Kotu As String
        Dim _Kofudp As String

        Dim _Cjredp As String
        Dim _Tidp As String

        Dim _Nudp As String '= Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

        Dim _Kotndp As String = RutEmpresa 'Codigo tenedor documento de pago, por defecto el rut de la empresa 
        Dim _Sutndp As String  'Sucursal tenerdo documento de pago, generalmente se pone el código de la caja "_Cjredp"

        Dim _Tuvoprotes = 0 'Tuvo protestos True o False

        Dim _Horagrab = Hora_Grab_fx(False)
        Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")

        Dim _Vadp As Double
        Dim _Vaasdp As Double
        Dim _Vavudp As Double
        Dim _Vaabdp As Double

        Dim _Docuenanti
        Dim _Nutransmi

        Dim _Esasdp As String
        Dim _Espgdp As String

        Dim _Cuotas As Integer

        Dim _Archirsd As String
        Dim _Idrsd As Integer

        Dim _Referencia As String
        Dim _Idmaeven As Integer
        Dim _Ley20956 As Integer

        'Consulta_sql = "Select * From CONFIEST Where MODALIDAD = '" & Modalidad & "'"
        'Dim _Row_Confiest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Dim _Cuotacomer As Boolean = _Row_Confiest.Item("CUOTACOMER")
        'Dim _Cuotacanti As Integer = _Row_Confiest.Item("CUOTACANTI")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        myTrans = cn2.BeginTransaction()


        Try

            'Dim _Abono As Double = 0

            Dim _Feasdp As String = Format(_Fecha_Asignacion_Pago, "yyyyMMdd")

            Dim _IdPago As Integer
            Dim _Nueva_Linea As Boolean

#Region "Rescatamos el numero del campo Referencia"

            Consulta_sql = "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                               "CJASDP,HORAGRAB,LAHORA) VALUES " &
                               "(" & _Idmaedpce & "," & _Vaasdp & ",'19990101',0,'','MAEEDO',0,'','','',''," & _Horagrab & ",'" & _Lahora & "')" & vbCrLf & vbCrLf

            Consulta_sql = Consulta_sql
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            _Referencia = 0

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Referencia = dfd("Identity")
            End While
            dfd.Close()

            Consulta_sql = "Delete MAEDPCD Where IDMAEDPCD = " & _Referencia
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

#End Region

            For Each _Fila As DataRow In _Tbl_Maedpce.Rows

                _Idmaedpce = _Fila.Item("IDMAEDPCE")
                _Empresa = _Fila.Item("EMPRESA")
                _Tidp = _Fila.Item("TIDP")

                _IdPago = _Fila.Item("ID")
                _Nueva_Linea = _Fila.Item("Nueva_Linea")

                _Vaasdp = _Fila.Item("VAASDP") - NuloPorNro(_Fila.Item("VAASDP_ORI"), 0)

                Dim _Usar As Boolean = _Fila.Item("Usar")

                If _Usar Then

                    If _Nueva_Linea Or CBool(_Vaasdp) Then

                        _Endp = NuloPorNro(_Fila.Item("ENDP"), "")
                        _Emdp = NuloPorNro(_Fila.Item("EMDP"), "")
                        _Suemdp = _Fila.Item("SUEMDP")
                        _Cudp = _Fila.Item("CUDP")
                        _Nucudp = _Fila.Item("NUCUDP")

                        If _Fecha_Asig_Fecha_Actual Then
                            _Feemdp = Format(_Fecha_Asignacion_Pago, "yyyyMMdd")
                        Else
                            _Feemdp = Format(_Fila.Item("FEEMDP"), "yyyyMMdd")
                        End If

                        _Fevedp = Format(_Fila.Item("FEVEDP"), "yyyyMMdd")
                        _Modp = _Fila.Item("MODP")
                        _Timodp = _Fila.Item("TIMODP")
                        _Tamodp = De_Num_a_Tx_01(_Fila.Item("TAMODP"), False, 5)
                        _Refanti = _Fila.Item("REFANTI")
                        _Suredp = _Fila.Item("SUREDP")
                        _Cjredp = _Fila.Item("CJREDP")
                        _Kotu = _Fila.Item("KOTU")
                        _Kofudp = _Fila.Item("KOFUDP")
                        _Kotndp = _Fila.Item("KOTNDP")
                        _Sutndp = _Fila.Item("SUTNDP")

                        _Docuenanti = _Fila.Item("DOCUENANTI")
                        _Nutransmi = _Fila.Item("NUTRANSMI")

                        _Tuvoprotes = 0

                        _Vadp = _Fila.Item("VADP")
                        '_Vaasdp = _Fila.Item("VAASDP")
                        _Vavudp = _Fila.Item("VAVUDP")
                        _Esasdp = _Fila.Item("ESASDP")
                        _Vaabdp = _Fila.Item("VAABDP")
                        _Espgdp = _Fila.Item("ESPGDP")
                        _Cuotas = _Fila.Item("CUOTAS")

                        If _Tidp <> "JTV" Then
                            _Cuotas = 0
                        End If

                        _Archirsd = NuloPorNro(_Fila.Item("ARCHIRSD"), "")
                        If Not String.IsNullOrEmpty(_Archirsd.ToString.Trim) Then _Idrsd = _Fila.Item("IDRSD")

                        _Ley20956 = _Fila.Item("LEY20956")

                        If Not _Nueva_Linea Then

                            Consulta_sql = "UPDATE MAEDPCE SET VAASDP = ROUND(" & De_Num_a_Tx_01(_Vaasdp, False, 5) & "+VAASDP,0),
                                            ESASDP=CASE WHEN ROUND( VADP-VAVUDP-(" & De_Num_a_Tx_01(_Vaasdp, False, 5) & "+VAASDP),0) <= 0 THEN 'A' ELSE 'P' END 
                                            WHERE IDMAEDPCE = " & _Idmaedpce

                            Consulta_sql = Consulta_sql
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        Else

                            '_Ley20956 = _Fila.Item("LEY20956")

                            _Nudp = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)

                            If _Tidp = "ncv" Then
                                _Vadp = _Vaasdp
                                _Vaabdp = _Vaasdp
                            End If

                            Consulta_sql =
                                    "INSERT INTO MAEDPCE (EMPRESA,TIDP,NUDP,ENDP,NUCUDP,CUDP,EMDP,SUEMDP,FEEMDP,FEVEDP,MODP,TIMODP,TAMODP," &
                                    "REFANTI,SUREDP,CJREDP,KOTU,KOFUDP,KOTNDP,SUTNDP,TUVOPROTES,VADP,VAASDP,VAVUDP,ESASDP,VAABDP,ESPGDP," &
                                    "CUOTAS,HORAGRAB,LAHORA,REFERENCIA,DOCUENANTI,NUTRANSMI,ARCHIRSD,IDRSD) VALUES " &
                                    "('" & _Empresa & "','" & _Tidp & "','" & _Nudp & "','" & _Endp & "','" & _Nucudp & "','" & Trim(_Cudp) &
                                    "','" & Trim(_Emdp) &
                                    "','" & _Suemdp & "','" & _Feemdp & "','" & _Fevedp & "','" & _Modp & "','" & _Timodp &
                                    "'," & _Tamodp & ",'" & _Refanti & "','" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp &
                                    "','" & _Kotndp & "','" & _Sutndp & "'," & _Tuvoprotes &
                                    "," & De_Num_a_Tx_01(_Vadp, False, 5) &
                                    "," & De_Num_a_Tx_01(_Vaasdp, False, 5) &
                                    "," & De_Num_a_Tx_01(_Vavudp, False, 5) &
                                    ",'" & _Esasdp &
                                    "'," & De_Num_a_Tx_01(_Vaabdp, False, 5) &
                                    ",'" & _Espgdp &
                                    "'," & _Cuotas & "," & _Horagrab & ",'" & _Lahora & "','" & _Referencia & "','" & _Docuenanti &
                                    "','" & _Nutransmi & "','" & _Archirsd & "'," & _Idrsd & ")"

                            Consulta_sql = Consulta_sql
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            _Fila.Item("NUDP") = _Nudp

                            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                            Comando.Transaction = myTrans
                            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                            While dfd1.Read()
                                _Idmaedpce = dfd1("Identity")
                            End While
                            dfd1.Close()

                            _Fila.Item("IDMAEDPCE") = _Idmaedpce

                            If _Aplica_Ley_20956 Then

                                Consulta_sql = "Update MAEDPCE Set LEY20956 = " & _Ley20956 & " Where IDMAEDPCE = " & _Idmaedpce

                                Consulta_sql = Consulta_sql
                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If


                        End If

                        For Each _Fila_Pagada As DataRow In _Tbl_Cta_Entidad.Rows

                            Dim _Id_Pago As Integer = _Fila_Pagada.Item("ID_PAGO")
                            Dim _DP As String = _Fila_Pagada.Item("DP")

                            Dim _Idrst As Integer = _Fila_Pagada.Item("IDRST")
                            Dim _Archirst As String = _Fila_Pagada.Item("ARCHIRST")
                            Dim _Tidopa As String = _Fila_Pagada.Item("DP")
                            Dim _Tcasig As Double = _Fila_Pagada.Item("TCASIG")

                            Dim _Abono As Double = _Fila_Pagada.Item("ABONO")

                            If _IdPago = _Id_Pago Then

                                Consulta_sql = "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                                           "CJASDP,HORAGRAB,LAHORA) VALUES " &
                                           "(" & _Idmaedpce & "," & De_Num_a_Tx_01(_Abono, False, 5) & ",'" & _Feasdp & "'," & _Idrst & ",'" & _Tidopa &
                                           "','" & _Archirst & "'," & De_Num_a_Tx_01(_Tcasig, False, 5) & ",'" & _Referencia & "','" & _Kofudp & "','" & _Suredp & "','" & _Cjredp & "'," & _Horagrab &
                                           ",'" & _Lahora & "')" & vbCrLf & vbCrLf

                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                If _Archirst = "MAEEDO" Then

                                    Dim _Idmaeedo As Integer = _Idrst
                                    _Idmaeven = 0

                                    Comando = New SqlCommand("Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo & " Order By IDMAEVEN", cn2)
                                    Comando.Transaction = myTrans

                                    Dim _Vave As Double
                                    Dim _Vaabve As Double
                                    Dim _Saldo_Abono As Double = _Abono

                                    Dim dfd2 As SqlDataReader = Comando.ExecuteReader()

                                    Dim _Lista As New List(Of String)

                                    While dfd2.Read()

                                        _Idmaeven = dfd2("IDMAEVEN")
                                        _Vave = dfd2("VAVE")
                                        _Vaabve = dfd2("VAABVE")

                                        Dim _Saldo As Double = _Vave - _Vaabve

                                        If _Saldo > _Saldo_Abono Then
                                            _Saldo = _Saldo_Abono
                                        End If

                                        If _Saldo >= 0 Then
                                            If _Saldo_Abono > 0 Then
                                                _Lista.Add(_Idmaeven & ";" & De_Num_a_Tx_01(_Saldo, False, 5))
                                                _Saldo_Abono -= _Saldo
                                            End If
                                        End If

                                    End While

                                    dfd2.Close()

                                    For Each _Fl_Maeven As String In _Lista

                                        Dim _Valores = Split(_Fl_Maeven, ";")

                                        _Idmaeven = _Valores(0)
                                        Dim _Vaasdp_Str As String = _Valores(1)

                                        Consulta_sql = "Update MAEVEN Set VAABVE=VAABVE+Round(" & _Vaasdp_Str & ",0)," &
                                                        "ESPGVE=Case When ROUND(VAVE,2)-ROUND(" & _Vaasdp_Str & ",0) <= 0 THEN 'C' Else '' End Where IDMAEVEN = " & _Idmaeven
                                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                        Comando.Transaction = myTrans
                                        Comando.ExecuteNonQuery()

                                    Next

                                    Consulta_sql = "SELECT VAVE,VAABVE,IDMAEVEN FROM MAEVEN WHERE IDMAEEDO = " & _Idmaeedo & " AND ESPGVE<>'C'"
                                    Comando = New SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Dim dfd_ven As SqlDataReader = Comando.ExecuteReader()
                                    While dfd_ven.Read()
                                        _Idmaeven = dfd_ven("IDMAEVEN")
                                    End While
                                    dfd_ven.Close()

                                    Consulta_sql = "UPDATE MAEEDO SET VAABDO=ROUND( VAABDO+" & De_Num_a_Tx_01(_Abono, False, 5) & ",0)," &
                                                   "ESPGDO=CASE WHEN ROUND( VABRDO-VAABDO-" & De_Num_a_Tx_01(_Abono, False, 5) & ",0) <= 0.0 THEN 'C' ELSE ESPGDO END" & Space(1) &
                                                   "WHERE IDMAEEDO=" & _Idrst

                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()


                                    'Consulta_sql = "UPDATE MAEVEN SET VAABVE= COALESCE(VAABVE,0.0)+" & De_Num_a_Tx_01(_Abono, False, 5) & vbCrLf &
                                    '                "WHERE IDMAEVEN=" & _Idmaeven

                                    'Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    'Comando.Transaction = myTrans
                                    'Comando.ExecuteNonQuery()

                                    'Consulta_sql = "UPDATE MAEVEN SET ESPGVE=CASE WHEN ROUND(VAVE,2)-ROUND(VAABVE,2) <= 0 THEN 'C' ELSE ESPGVE END" & vbCrLf &
                                    '               "WHERE IDMAEVEN=" & _Idmaeven

                                    'Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    'Comando.Transaction = myTrans
                                    'Comando.ExecuteNonQuery()

                                End If

                            End If

                        Next

                    End If

                End If

            Next

            If False Then
                Throw New System.Exception("An exception has occurred.")
            End If

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return True

        Catch ex As Exception

            myTrans.Rollback()

            MessageBoxEx.Show(_Formulario, "Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return 0

        End Try

    End Function

    Function Fx_Crear_Pago_MAEDPCD(_Formulario As Form,
                                           _Idmaeedo As Integer,
                                           _Idmaedpce As Integer,
                                           _Vaabdo As Double) As Integer

        Try

            Dim _Row_Maeedo As DataRow
            Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Row_Maedpcde As DataRow
            Consulta_sql = "Select top 1 * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
            _Row_Maedpcde = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Feasdp As String = Format(_Row_Maedpcde.Item("FEEMDP"), "yyyyMMdd")
            Dim _Tidopa As String = _Row_Maeedo.Item("TIDO")
            Dim _Referencia As String = 0
            Dim _Kofudp As String = _Row_Maedpcde.Item("KOFUDP")
            Dim _Suemdp As String = _Row_Maedpcde.Item("SUREDP")
            Dim _Cjredp As String = _Row_Maedpcde.Item("CJREDP")

            Dim _Horagrab = Hora_Grab_fx(False)
            Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")

            Consulta_sql = "SELECT VAVE,VAABVE,IDMAEVEN FROM MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & " AND ESPGVE<>'C'"
            Dim _Tbl_Maeven As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            'Dim _Idmaeven As Integer = _Tbl_Maeven.Rows(0).Item("IDMAEVEN")

            Dim _Abono As String = De_Num_a_Tx_01(_Vaabdo, False, 5)

            Consulta_sql =
                     "UPDATE MAEEDO SET VAABDO= COALESCE(VAABDO,0) +" & _Abono &
                     ",ESPGDO=CASE WHEN ROUND(VABRDO,2)-ROUND(VAABDO+" & _Abono & ",2)-COALESCE(ROUND(VAIVARET,2),0) <= 0 THEN 'C' " &
                     "ELSE ESPGDO END WHERE IDMAEEDO=" & _Idmaeedo &
                     vbCrLf &
                     vbCrLf &
                     "UPDATE MAEVEN SET VAABVE= COALESCE(VAABVE,0.0)+" & _Abono &
                     ",ESPGVE=CASE WHEN ROUND(VAVE,2)-ROUND(VAABVE+" & _Abono & ",2) <= 0 THEN 'C' ELSE ESPGVE END WHERE IDMAEEDO=" & _Idmaeedo &
                     vbCrLf &
                     vbCrLf &
                     "INSERT INTO MAEDPCD (IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP," &
                     "CJASDP,HORAGRAB,LAHORA) VALUES " &
                     "(" & _Idmaedpce & "," & _Abono & ",'" & _Feasdp & "'," & _Idmaeedo & ",'" & _Tidopa &
                     "','MAEEDO',0.00000," & _Referencia & ",'" & _Kofudp & "','" & _Suemdp & "','" & _Cjredp & "'," & _Horagrab &
                     ",'" & _Lahora & "')" & vbCrLf & vbCrLf

            'UPDATE MAEVEN SET VAABVE=ROUND( VAABVE+28940.000000,0),ESPGVE=CASE WHEN ROUND( VAVE-VAABVE-28940.000000,0) <= 0.0 THEN 'C'  ELSE ESPGVE  END  WHERE IDMAEVEN=246276

        Catch ex As Exception
            Return 0
        End Try

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            'CREA EL DOCUMENTO DE PAGO EN LA TABLA MAEDPCE, DOCUMENTO 'PTB'"

            Consulta_sql = Consulta_sql
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            '_Referencia = _Sql.Fx_Trae_Dato(, "IDMAEDPCD", "MAEDPCD", "IDMAEDPCE = " & _Idmaedpce)

            Consulta_sql = "Declare @Referencia Int" & vbCrLf &
                           "Set @Referencia = (Select top 1 IDMAEDPCD From MAEDPCD Where IDMAEDPCE = " & _Idmaedpce & ")" & vbCrLf &
                           "UPDATE MAEDPCE SET REFERENCIA = @Referencia WHERE IDMAEDPCE = " & _Idmaedpce & vbCrLf &
                           "UPDATE MAEDPCD SET REFERENCIA = @Referencia WHERE IDMAEDPCE = " & _Idmaedpce

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            Return _Idmaedpce

        Catch ex As Exception

            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            Return 0

        End Try

    End Function

    Function Fx_Nro_NUDP(_Empresa As String,
                         _Endp As String,
                         _Cjredp As String,
                         _Tidp As String)

        ' ACA RESCATA EL NUMERO QUE CORRESPONDA AL CAMPO NUDP, LLAVE TIDP
        Dim _Nudp As String = _Sql.Fx_Trae_Dato("MAEDPCE", "COALESCE(MAX(NUDP),'0000000000')",
                                        "EMPRESA='" & _Empresa & "' AND CJREDP='" & _Cjredp & "' AND TIDP='" & _Tidp & "' And NUDP Like '" & _Cjredp & "%'")

        Dim _Existe As Boolean

        Do

            Dim _Nro = Mid(_Nudp, 3, 8)
            _Nudp = _Cjredp & numero_(Val(_Nro) + 1, 8)

            _Existe = _Sql.Fx_Cuenta_Registros("MAEDPCE",
                      "EMPRESA='" & _Empresa & "' AND TIDP='" & _Tidp & "' AND NUDP='" & _Nudp & "' AND ENDP='" & _Endp & "'")

        Loop While _Existe

        Return _Nudp

    End Function

    Function Fx_Pagar_NCV(_Formulario As Form, _Tbl_Maedpce As DataTable, _Idmaeedo_FcvBlv As Integer) As Boolean

        Dim _Suma_Idmaedpce As Integer

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            Dim _Tidp = _Fila.Item("TIDP")

            If _Tidp = "ncv" Then

                Consulta_sql = "Select Top 1 IDMAEDPCE,EMPRESA,SUREDP,CJREDP,TIDP,NUDP,ENDP,EMDP,SUEMDP,CUDP,NUCUDP,FEEMDP,FEVEDP,MODP," & vbCrLf &
                       "TIMODP,TAMODP,VADP,VAABDP,VAASDP,VAVUDP,ESPGDP,REFANTI,KOTU,NUTRANSMI,DOCUENANTI,KOFUDP,KOTNDP,SUTNDP,ESASDP,ESPGDP,CUOTAS" & vbCrLf &
                       "From MAEDPCE With ( Nolock ) " & vbCrLf &
                       "Where 1 = 0"

                Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                Dim NewFila As DataRow
                NewFila = _Tbl.NewRow

                With NewFila

                    .Item("IDMAEDPCE") = 0
                    .Item("EMPRESA") = ModEmpresa
                    .Item("SUREDP") = ModSucursal
                    .Item("CJREDP") = ModCaja

                    .Item("TIDP") = String.Empty
                    .Item("NUDP") = String.Empty

                    .Item("ENDP") = String.Empty
                    .Item("EMDP") = String.Empty
                    .Item("SUEMDP") = String.Empty
                    .Item("CUDP") = String.Empty
                    .Item("NUCUDP") = String.Empty
                    .Item("FEEMDP") = _FechaDelServidor
                    .Item("FEVEDP") = _FechaDelServidor

                    .Item("MODP") = _Modp
                    .Item("TIMODP") = _Timodp
                    .Item("TAMODP") = _Tamodp

                    .Item("VADP") = 0
                    .Item("VAABDP") = 0
                    .Item("VAASDP") = 0
                    .Item("VAVUDP") = 0
                    .Item("ESPGDP") = String.Empty
                    .Item("REFANTI") = String.Empty
                    .Item("KOTU") = 1
                    .Item("KOFUDP") = FUNCIONARIO
                    .Item("KOTNDP") = RutEmpresa
                    .Item("SUTNDP") = ModCaja

                    .Item("NUTRANSMI") = ""
                    .Item("DOCUENANTI") = ""

                    .Item("ESASDP") = "A"
                    .Item("ESPGDP") = ""
                    .Item("CUOTAS") = 0

                End With

                _Tbl.Rows.Add(NewFila)

                Consulta_sql = "Select TIDO,NUDO,ENDO From MAEEDO Where IDMAEEDO = " & _Idmaeedo_FcvBlv
                Dim _Row_NewMaeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Tido_Pago = _Row_NewMaeedo.Item("TIDO")
                Dim _Nudo_Pago = _Row_NewMaeedo.Item("NUDO")
                Dim _Endo_Pago = _Row_NewMaeedo.Item("ENDO")

                Dim _Tido_Nudo = Split(_Fila.Item("REFANTI"), "-")
                Dim _Tido_NCV = _Tido_Nudo(0)
                Dim _Nudo_NCV = _Tido_Nudo(1)
                Dim _Endo_NCV = _Tido_Nudo(2)

                Dim _Idmaeedo_NCV As Integer = _Fila.Item("IDMAEEDO")

                _Tbl.Rows(0).Item("ESPGDP") = "C"

                Dim _Koen = Trim(_Endo_Pago)
                Dim _Rut = RutEmpresa

                _Tbl.Rows(0).Item("TIDP") = LCase(_Tido_Pago)
                _Tbl.Rows(0).Item("ENDP") = _Koen
                _Tbl.Rows(0).Item("EMDP") = _Rut

                _Tbl.Rows(0).Item("REFANTI") = _Tido_Pago & "-" & _Nudo_Pago & "-" & _Koen

                _Tbl.Rows(0).Item("VADP") = _Fila.Item("VADP")
                _Tbl.Rows(0).Item("VAABDP") = _Fila.Item("VADP")
                _Tbl.Rows(0).Item("VAASDP") = _Fila.Item("VADP")
                _Tbl.Rows(0).Item("VAABDP") = _Fila.Item("VADP")

                _Suma_Idmaedpce += Fx_Crear_Pago_MAEDPCE(_Formulario, _Idmaeedo_NCV, _Tbl, FechaDelServidor)

            End If

        Next

        Return CBool(_Suma_Idmaedpce)

    End Function

    Function Fx_Eliminar_Pago(_Idmaedpce As Integer) As String

        Dim _Error = String.Empty

        Consulta_sql = My.Resources.Recursos_pagos.SQLQuery_Revisar_Data_Eliminar_Pago
        Consulta_sql = Replace(Consulta_sql, "#Idmaedpce#", _Idmaedpce)

        Dim _Ds_Pago As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Pago.Tables(10).TableName = "Maedpce"
        _Ds_Pago.Tables(11).TableName = "Maedpcd"
        _Ds_Pago.Tables(12).TableName = "Doc_Pagados"
        '_Ds_Pago.Tables(1).TableName = "Zw_Despachos_Doc"
        '_Ds_Pago.Tables(2).TableName = "Zw_Despachos_Doc_Det"

        Dim _Maedpce As DataTable = _Ds_Pago.Tables("Maedpce")
        Dim _Maedpcd As DataTable = _Ds_Pago.Tables("Maedpcd")
        Dim _Tbl_Doc_Pagados As DataTable = _Ds_Pago.Tables("Doc_Pagados")

        If _Maedpce.Rows.Count = 0 Then
            _Error = "Ya no existe el documento a eliminar"
            Return _Error
        End If

        For i = 0 To 9

            If CBool(_Ds_Pago.Tables(i).Rows.Count) Then
                If i = "2" Then
                    _Error = "El registro es sustentatorio del comprobante" & vbCrLf &
                             "Nro: " & _Ds_Pago.Tables(i).Rows(0).Item("NUMECOM") & " Fecha: " & FormatDateTime(_Ds_Pago.Tables(i).Rows(0).Item("FECHCOM"), DateFormat.ShortDate)
                Else
                    _Error = "Existen datos sustentartorios en Contabilidad"
                End If
                Exit For
            End If

        Next

        If String.IsNullOrEmpty(_Error) Then

            Dim myTrans As SqlClient.SqlTransaction
            Dim Comando As SqlClient.SqlCommand

            Dim Cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            Try

                myTrans = Cn2.BeginTransaction()

                For Each _Fmaedpcd As DataRow In _Maedpcd.Rows

                    Dim _Idmaedpcd As Integer = _Fmaedpcd.Item("IDMAEDPCE")
                    Dim _Archirst As String = _Fmaedpcd.Item("ARCHIRST").ToString.Trim
                    Dim _Idrst As Integer = _Fmaedpcd.Item("IDRST")
                    Dim _Vaasdp As Double = _Fmaedpcd.Item("VAASDP")

                    If _Archirst = "MAEEDO" Then

                        Dim _Idmaeven As Integer = 0
                        Dim _Vaabve As Double = 0

                        Comando = New SqlCommand("Select * From MAEVEN Where IDMAEEDO = " & _Idrst & " Order By IDMAEVEN Desc", Cn2)
                        Comando.Transaction = myTrans

                        Dim dfd1 As SqlDataReader = Comando.ExecuteReader()

                        Dim _Lista As New List(Of String)

                        While dfd1.Read()
                            _Idmaeven = dfd1("IDMAEVEN")
                            _Vaabve = dfd1("VAABVE")
                            If _Vaasdp >= _Vaasdp Then
                                _Lista.Add(_Idmaeven & ";" & De_Num_a_Tx_01(_Vaabve, False, 5))
                            End If
                        End While
                        dfd1.Close()

                        Dim _Suma_Asignado As Double = 0

                        For Each _Eli_Maeven As String In _Lista

                            Dim _Eliminar As Boolean = False
                            Dim _Valores = Split(_Eli_Maeven, ";")

                            _Idmaeven = _Valores(0)
                            Dim _Vaasdp_Str As String = _Valores(1)
                            Dim _Vaabve_Val As Double = De_Txt_a_Num_01(_Valores(1), 5)

                            Dim _Saldo As Double = _Vaasdp - _Suma_Asignado - _Vaabve_Val

                            If _Saldo >= 0 Then
                                _Eliminar = True
                            Else
                                _Saldo = _Vaasdp - _Suma_Asignado

                                If _Saldo > 0 Then
                                    _Vaabve_Val = _Saldo
                                    _Vaasdp_Str = De_Num_a_Tx_01(_Vaabve_Val, False, 5)
                                    _Eliminar = True
                                End If

                            End If

                            If _Eliminar Then

                                Consulta_sql = "Update MAEVEN Set VAABVE=VAABVE-Round(" & _Vaasdp_Str & ",0),ESPGVE = '' Where IDMAEVEN = " & _Idmaeven
                                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                'Consulta_sql = "Update MAEVEN Set ESPGVE = '' Where IDMAEVEN = " & _Idmaeven
                                'Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                                'Comando.Transaction = myTrans
                                'Comando.ExecuteNonQuery()

                                Consulta_sql = "Update MAEEDO Set VAABDO=VAABDO-ROUND(" & _Vaasdp_Str & ",0)," &
                                                "ESPGDO=Case When VABRDO-VAABDO-VAIVARET-Round(" & _Vaasdp_Str & ",0)<>0.0 THEN 'P' Else 'C' End Where IDMAEEDO = " & _Idrst
                                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                            _Suma_Asignado += _Vaabve_Val

                            If _Suma_Asignado = _Vaasdp Then
                                Exit For
                            End If

                        Next

                    End If

                    Consulta_sql = "Delete From MAEDPCD Where IDMAEDPCE = " & _Idmaedpcd
                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

                Consulta_sql = "Delete MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim _Empresa = _Maedpce.Rows(0).Item("EMPRESA")
                Dim _Tidp = _Maedpce.Rows(0).Item("TIDP")
                Dim _Nudp = _Maedpce.Rows(0).Item("NUDP")
                Dim _Endp = _Maedpce.Rows(0).Item("ENDP")
                Dim _Feemdo = _Maedpce.Rows(0).Item("FEEMDP")
                Dim _Feelido = _FechaDelServidor
                Dim _Kofudo = _Maedpce.Rows(0).Item("KOFUDP")
                Dim _Vadp = _Maedpce.Rows(0).Item("VADP")
                Dim _LaHora = Hora_Grab_fx(False)

                Consulta_sql = "Insert Into MAEELIMI (EMPRESA,TIDO,NUDO,ENDO,FEEMDO,FEELIDO,KOFUDO,VANEDO,VABRDO,TRANSMASI) VALUES " &
                                "('" & _Empresa & "','" & _Tidp & "','" & _Nudp & "','" & _Endp & "','" & Format(_Feemdo, "yyyyMMdd") & "','" & Format(_Feelido, "yyyyMMdd") & "'" &
                                ",'" & _Kofudo & "'," & De_Num_a_Tx_01(_Vadp, False, 5) & "," & De_Num_a_Tx_01(_Vadp, False, 5) & "," & _LaHora & ") "
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                'Throw New System.Exception("An exception has occurred.")

                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

                'Return _Idmaedpce

            Catch ex As Exception

                Try
                    myTrans.Rollback()
                Catch ex2 As Exception

                End Try

                MessageBoxEx.Show("Transaccion desecha" & vbCrLf &
                              ex.Message & vbCrLf & vbCrLf &
                              "SQLQuery: " & Consulta_sql, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

                Return ex.Message

            End Try

        End If

        Return _Error

    End Function

    Function Fx_Crear_Pago_Liquidacion_Tarjetas_Credito(_Row_ATB As DataRow, _Row_PTB As DataRow, _TblTarjetas As DataTable) As Boolean

#Region "VARIABLES"

        Dim _Idmaedpce As Integer
        Dim _Empresa As String
        Dim _Endp As String
        Dim _Nucudp As String
        Dim _Cudp As String
        Dim _Emdp As String
        Dim _Suemdp As String
        Dim _Feemdp As String '= Format(_Feemdp, "yyyyMMdd") Fecha Emision
        Dim _Fevedp As String '= Format(_Fevedp, "yyyyMMdd") Fecha Vencimiento
        Dim _Modp As String
        Dim _Timodp As String
        'Dim _Tamodp As String
        Dim _Refanti As String
        Dim _Suredp As String
        Dim _Kotu As String
        Dim _Kofudp As String
        Dim _Cjredp As String
        Dim _Tidp As String
        Dim _Nudp As String '= Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, _Tidp)
        Dim _Kotndp As String = RutEmpresa 'Codigo tenedor documento de pago, por defecto el rut de la empresa 
        Dim _Sutndp As String  'Sucursal tenerdo documento de pago, generalmente se pone el código de la caja "_Cjredp"
        Dim _Tuvoprotes = 0 'Tuvo protestos True o False
        Dim _Horagrab = Hora_Grab_fx(False)
        Dim _Lahora = Format(FechaDelServidor, "yyyyMMdd")
        Dim _Vadp As Double
        Dim _Vaasdp As Double
        Dim _Vavudp As Double
        Dim _Vaabdp As Double
        Dim _Docuenanti
        Dim _Nutransmi
        Dim _Esasdp As String
        Dim _Espgdp As String
        Dim _Cuotas As Integer
        Dim _Archirsd As String
        Dim _Idrsd As Integer
        Dim _Referencia As String
        Dim _Idmaeven As Integer
        Dim _Ley20956 As Integer

        Dim _Feasdp As String
        Dim _Tidopa As String
        Dim _Archirst As String
        Dim _Idrst As Integer
        Dim _Tcasig As Double
        Dim _Kofuasdp As String
        Dim _Suasdp As String
        Dim _Cjasdp As String


#End Region

        _Tidp = "ATB"
        _Empresa = _Row_ATB.Item("EMPRESA")
        _Emdp = _Row_ATB.Item("EMDP")
        _Suemdp = _Row_ATB.Item("SUEMDP")
        _Cudp = _Row_ATB.Item("CUDP")
        _Nucudp = _Row_ATB.Item("NUCUDP")
        _Nudp = _Row_ATB.Item("NUDP")
        _Endp = _Row_ATB.Item("ENDP")
        _Feemdp = Format(_Row_ATB.Item("FEEMDP"), "yyyyMMdd")
        _Fevedp = Format(_Row_ATB.Item("FEVEDP"), "yyyyMMdd")
        _Modp = _Row_ATB.Item("MODP")
        _Timodp = _Row_ATB.Item("TIMODP")
        '_Tamodp = _Row_ATB.Item("TAMODP")
        _Suredp = _Row_ATB.Item("SUREDP")
        _Cjredp = _Row_ATB.Item("CJREDP")
        _Kotu = _Row_ATB.Item("KOTU")
        _Kofudp = _Row_ATB.Item("KOFUDP")
        _Esasdp = _Row_ATB.Item("ESASDP") '"A"
        _Kotndp = _Row_ATB.Item("KOTNDP")
        _Sutndp = _Row_ATB.Item("SUTNDP")
        _Espgdp = _Row_ATB.Item("ESPGDP")
        _Vadp = _Row_ATB.Item("VADP")
        _Vaabdp = _Row_ATB.Item("VAABDP")
        _Vaasdp = _Row_ATB.Item("VAASDP")

        Dim _Nudp_ATB = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, "ATB")
        Dim _Nudp_PTB = Fx_Nro_NUDP(ModEmpresa, _Endp, _Cjredp, "PTB")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            _Nudp = _Nudp_ATB

            Consulta_sql = "Insert Into MAEDPCE (EMPRESA,HORAGRAB,LAHORA,TIDP,EMDP,SUEMDP,CUDP,NUCUDP,NUDP,ENDP,FEEMDP,FEVEDP,VAVUDP,MODP,TIMODP,TAMODP,SUREDP," &
                       "CJREDP,KOTU,KOFUDP,ESASDP,KOTNDP,SUTNDP,ESPGDP,VADP,VAABDP,VAASDP) VALUES " &
                       "('" & _Empresa & "'," & _Horagrab & ",'" & _Lahora & "','" & _Tidp & "','" & _Emdp & "','" & _Suemdp & "','" & _Cudp & "','" & _Nucudp & "'" &
                       ",'" & _Nudp & "','" & _Endp & "','" & _Feemdp & "','" & _Fevedp & "'," & _Vavudp & ",'" & _Modp & "','" & _Timodp & "'," & De_Num_a_Tx_01(_Tamodp, False, 5) &
                       ",'" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp & "','" & _Esasdp & "','" & _Kotndp & "','" & _Sutndp & "'" &
                       ",'" & _Espgdp & "'," & _Vadp & "," & _Vaabdp & "," & _Vaasdp & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("Select @@IDENTITY As 'Identity'", Cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idmaedpce = dfd1("Identity")
            End While
            dfd1.Close()

            _Feasdp = _Feemdp

            For Each _Fila As DataRow In _TblTarjetas.Rows

                _Vaasdp = _Fila.Item("VADP")
                _Tidp = _Fila.Item("TIDP")
                _Kofuasdp = FUNCIONARIO
                _Suasdp = _Suredp
                _Cjasdp = _Cjredp
                _Idrst = _Fila.Item("IDMAEDPCE")

                Consulta_sql = "Insert Into MAEDPCD (IDMAEDPCE,FEASDP,VAASDP,TIDOPA,ARCHIRST,IDRST,TCASIG,KOFUASDP,SUASDP,CJASDP,HORAGRAB,LAHORA) VALUES " &
                               "(" & _Idmaedpce & ",'" & _Feasdp & "'," & De_Num_a_Tx_01(_Vaasdp, False, 5) & ",'" & _Tidp & "','MAEDPCE '," & _Idrst &
                               "," & De_Num_a_Tx_01(_Tcasig, False, 5) & ",'" & _Kofuasdp & "','" & _Suasdp & "','" & _Cjasdp & "'," & _Horagrab & ",'" & _Lahora & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_sql = "Update MAEDPCE Set VAABDP=VADP,ESPGDP='C' Where IDMAEDPCE=" & _Idrst

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            Next

            _Tidp = "PTB"
            _Empresa = _Row_PTB.Item("EMPRESA")
            _Emdp = _Row_PTB.Item("EMDP")
            _Suemdp = _Row_PTB.Item("SUEMDP")
            _Cudp = _Row_PTB.Item("CUDP")
            _Nucudp = _Row_PTB.Item("NUCUDP")
            _Nudp = _Nudp_PTB
            _Endp = _Row_PTB.Item("ENDP")
            _Feemdp = Format(_Row_PTB.Item("FEEMDP"), "yyyyMMdd")
            _Fevedp = Format(_Row_PTB.Item("FEVEDP"), "yyyyMMdd")
            _Modp = _Row_PTB.Item("MODP")
            _Timodp = _Row_PTB.Item("TIMODP")
            '_Tamodp = _Row_PTB.Item("TAMODP")
            _Suredp = _Row_PTB.Item("SUREDP")
            _Cjredp = _Row_PTB.Item("CJREDP")
            _Kotu = _Row_PTB.Item("KOTU")
            _Kofudp = _Row_PTB.Item("KOFUDP")
            _Esasdp = "P" '_Row_PTB.Item("ESASDP")
            _Kotndp = _Row_PTB.Item("KOTNDP")
            _Sutndp = _Row_PTB.Item("SUTNDP")
            _Espgdp = _Row_PTB.Item("ESPGDP")
            _Vadp = _Row_PTB.Item("VADP")
            _Vaabdp = 0 '_Row_PTB.Item("VAABDP")
            _Vaasdp = 0 '_Row_PTB.Item("VAASDP")
            _Refanti = _Row_PTB.Item("REFANTI")

            Consulta_sql = "Insert Into MAEDPCE (EMPRESA,HORAGRAB,LAHORA,TIDP,EMDP,SUEMDP,CUDP,NUCUDP,NUDP,ENDP,FEEMDP,FEVEDP,VAVUDP,MODP,TIMODP,TAMODP,SUREDP," &
                           "CJREDP,KOTU,KOFUDP,ESASDP,KOTNDP,SUTNDP,ESPGDP,VADP,VAABDP,VAASDP) VALUES " &
                           "('" & _Empresa & "'," & _Horagrab & ",'" & _Lahora & "','" & _Tidp & "','" & _Emdp & "','" & _Suemdp & "','" & _Cudp & "','" & _Nucudp & "'" &
                           ",'" & _Nudp & "','" & _Endp & "','" & _Feemdp & "','" & _Fevedp & "'," & _Vavudp & ",'" & _Modp & "','" & _Timodp & "'," & De_Num_a_Tx_01(_Tamodp, False, 5) &
                           ",'" & _Suredp & "','" & _Cjredp & "','" & _Kotu & "','" & _Kofudp & "','" & _Esasdp & "','" & _Kotndp & "','" & _Sutndp & "'" &
                           ",'" & _Espgdp & "'," & _Vadp & "," & _Vaabdp & "," & _Vaasdp & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Throw New System.Exception("An exception has occurred.")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            Try
                myTrans.Rollback()
            Catch ex2 As Exception

            End Try

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                Consulta_sql = vbCrLf & vbCrLf & "SQLQuery: " & Consulta_sql
            End If

            MessageBoxEx.Show("Transaccion desecha" & vbCrLf & ex.Message & Consulta_sql, "Problema",
                          Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            Return False

        End Try

        Return True

    End Function

End Class
