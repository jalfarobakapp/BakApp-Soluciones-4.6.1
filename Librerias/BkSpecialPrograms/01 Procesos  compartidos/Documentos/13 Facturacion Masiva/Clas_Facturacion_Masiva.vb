Public Class Clas_Facturacion_Masiva

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Doc_Facturar As DataTable
    Public Property Tbl_Doc_Facturar As DataTable
        Get
            Return _Tbl_Doc_Facturar
        End Get
        Set(value As DataTable)
            _Tbl_Doc_Facturar = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Function Fx_Cargar_Tabla_Facturacion(_Condicion As String) As String

        Dim _Error = String.Empty

        _Condicion = Replace(_Condicion, "IDMAEEDO", "Edo.IDMAEEDO")

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Edo.IDMAEEDO,TIDO,Edo.NUDO,Cast(ENDO As Varchar(10)) As ENDO,Cast(SUENDO As Varchar(10)) As SUENDO," &
                       "Cast('' As Varchar(15)) As Rut,NOKOEN,SUDO,FEEMDO,FEER,FE01VEDO,FEULVEDO," &
                       "CONVERT(NVARCHAR, CONVERT(datetime, (Edo.HORAGRAB*1.0/3600)/24), 108) AS HORA,VANEDO,VAIVDO,VAIMDO,VABRDO,VAABDO,KOFUDO,NOKOFU,
                        Cast(0 As Bit) As Facturado,Cast(0 As Int) As IDMAEEDO_FCV,Cast('' As Varchar(10)) As NUDO_FCV,FEEMDO AS Fecha_Emision,Edo.FEER AS Fecha_Despacho," &
                       "Cast(0 As Float) As VABRDO_FCV,Cast(0 As Float) As VAABDO_FCV,Cast(0 As Bit) As FCV_PAGADA,Cast(0 As Bit) As FCV_IMPRESA,
                        Cast(0 As Int) As IDMAEDPCE,Cast(0 As Float) As VADP,Cast(0 As Float) As VAASDP,Cast(0 As Float) As SALDO," &
                       "Cast(0 As Bit) As CRV, Cast(0 as Float) SALDO_CRV,Isnull(OBDO,'') As OBDO
                        Into #Paso
                        From MAEEDO Edo
                        Left Join MAEEDOOB Obs On Obs.IDMAEEDO = Edo.IDMAEEDO
                        Left Join MAEEN On KOEN = ENDO And SUENDO = SUEN
                        Left Join TABFU On KOFU = KOFUEN" & vbCrLf &
                        _Condicion & vbCrLf &
                       "Order By HORAGRAB
                        Update #Paso Set IDMAEDPCE = Isnull((Select Top 1 IDMAEDPCE From MAEDPCE Where IDRSD = IDMAEEDO),0)
                        Update #Paso Set VADP = Isnull((Select VADP From MAEDPCE Mp Where Mp.IDMAEDPCE = #Paso.IDMAEDPCE),0)
                        Update #Paso Set HORA = SUBSTRING(HORA,1,5),ENDO = Ltrim(Rtrim(ENDO)),SUENDO = Ltrim(Rtrim(SUENDO))

                        Update #Paso Set SALDO_CRV = VABRDO-VADP Where VADP > 0

                        Select * From #Paso
                        Drop Table #Paso"

        _Tbl_Doc_Facturar = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Error = _Sql.Pro_Error

        Return _Error

    End Function



End Class
