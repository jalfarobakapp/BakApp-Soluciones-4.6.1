
Imports BkSpecialPrograms.Stem_BD
Imports BkSpecialPrograms.Tickets_Db
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Cl_Stem

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Stem_Enc As New Stem_BD.Stem_Enc
    Public Property Stem_Det As New List(Of Stem_BD.Stem_Det)

    Public Sub New()

    End Sub

    Function Fx_Grabar_Nuevo_Tickets() As Mensaje_Stem

        Dim _Mensaje_Stem As New Mensaje_Stem

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Stem_Enc

                .Numero = Fx_NvoNro_Stem()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stem_Enc (Empresa,Sucursal,Numero,CodFuncionario_Crea,Idmaeedo,Tido," &
                               "Nudo,Endo,Suendo,FechaCreacion,Estado) Values " &
                       "('" & .Empresa & "','" & .Sucursal & "','" & .Numero & "','" & .CodFuncionario_Crea & "'," & .Idmaeedo &
                       ",'" & .Tido & "','" & .Nudo & "','" & .Endo & "','" & .Suendo & "','" & Format(.FechaCreacion, "yyyyMMdd hh:mm") & "','" & .Estado & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                'Imports System.Data
                'Imports System.Data.SqlClient

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            For Each _Fila As Stem_BD.Stem_Det In _Stem_Det

                With _Fila

                    .Id_Enc = _Stem_Enc.Id

                    If Not String.IsNullOrEmpty(.Codigo) Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stem_Det (Id_Enc,Idmaeedo,Idmaeddo,Codigo,Nulido,Udtrpr,Rludpr" &
                                       ",Caprco1_Ori,Caprco1_Real,Ud01pr,Caprco2_Ori,Caprco2_Real,Ud02pr,Pickeado,EnProceso) Values " &
                                       "(" & .Id_Enc & "," & .Idmaeedo & "," & .Idmaeddo & ",'" & .Codigo & "'" &
                                       ",'" & .Nulido & "'," & .Udtrpr & "," & De_Num_a_Tx_01(.Rludpr, False, 5) &
                                       "," & De_Num_a_Tx_01(.Caprco1_Ori, False, 5) &
                                       "," & De_Num_a_Tx_01(.Caprco1_Real, False, 5) &
                                       ",'" & .Ud01pr & "'" &
                                       "," & De_Num_a_Tx_01(.Caprco2_Ori, False, 5) &
                                       "," & De_Num_a_Tx_01(.Caprco2_Real, False, 5) &
                                       ",'" & .Ud02pr & "'" &
                                       ",0,0)"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                End With

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Documento grabado correctamente"

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Stem_Enc.Id = 0

            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_NvoNro_Stem() As String

        Dim _NvoNro_Stem As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Numero) As Numero From " & _Global_BaseBk & "Zw_Stem_Enc")

        Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

        If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
            _Ult_Nro_OT = "#T00000000"
        End If

        _NvoNro_Stem = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Return _NvoNro_Stem

    End Function

End Class

Namespace Stem_BD

    Public Enum EnumAcciones
        <Description("Defaul sin valor")>
        Defaul = 0

        <Description("Acepta Contenido del Documento")>
        ACD_AceptaContenidoDocumento = 1

        <Description("Reclamo al Contenido del Documento")>
        RCD_ReclamoContenidoDocumento = 2

        <Description("Otorga Recibo de Mercaderías o Servicios")>
        ERM_OtorgaReciboMercaderiasServicios = 3

        <Description("Reclamo por Falta Parcial de Mercaderías")>
        RFP_ReclamoFaltaParcialMercaderias = 4

        <Description("Reclamo por Falta Total de Mercaderías")>
        RFT_ReclamoFaltaTotalMercaderias = 5
    End Enum

    Public Class Stem_Enc

        Public Property Id As Integer
        Public Property Empresa As String
        Public Property Sucursal As String
        Public Property Numero As String
        Public Property CodFuncionario_Crea As String
        Public Property Idmaeedo As Integer
        Public Property Tido As String
        Public Property Nudo As String
        Public Property Endo As String
        Public Property Suendo As String
        Public Property FechaCreacion As DateTime
        Public Property Estado As String
        Public Property Completado As Boolean
        Public Property FechaCierre As DateTime

    End Class

    Public Class Stem_Det

        Public Property Id As Integer
        Public Property Id_Enc As Integer
        Public Property Idmaeedo As Integer
        Public Property Idmaeddo As Integer
        Public Property Codigo As String
        Public Property Nulido As String
        Public Property Udtrpr As Integer
        Public Property Rludpr As Double
        Public Property Caprco1_Ori As Double
        Public Property Caprco1_Real As Double
        Public Property Ud01pr As String
        Public Property Caprco2_Ori As Double
        Public Property Caprco2_Real As Double
        Public Property Ud02pr As String
        Public Property Pickeado As Boolean
        Public Property EnProceso As Boolean

    End Class

    Public Class Mensaje_Stem

        Public Property EsCorrecto As Boolean
        Public Property Mensaje As String

    End Class

End Namespace
