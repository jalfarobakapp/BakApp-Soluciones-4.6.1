Public Class Clas_Facturacion_Masiva

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Ds_Doc_Facturar As DataSet
    Private _Tbl_Doc_Facturar As DataTable
    Public Property Tbl_Doc_Facturar As DataTable
        Get
            Return _Tbl_Doc_Facturar
        End Get
        Set(value As DataTable)
            _Tbl_Doc_Facturar = value
        End Set
    End Property

    Public Property Ds_Doc_Facturar As DataSet
        Get
            Return _Ds_Doc_Facturar
        End Get
        Set(value As DataSet)
            _Ds_Doc_Facturar = value
        End Set
    End Property

    Public Property Errores As String

    Public Sub New()

    End Sub

    Function Fx_Cargar_Tabla_Facturacion(_Condicion As String) As String

        Dim _Error = String.Empty

        _Condicion = Replace(_Condicion, "IDMAEEDO", "Edo.IDMAEEDO")

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Edo.IDMAEEDO,TIDO,Edo.NUDO,Cast(ENDO As Varchar(10)) As ENDO,Cast(SUENDO As Varchar(10)) As SUENDO," &
                       "Cast('' As Varchar(15)) As Rut,NOKOEN,SUDO,FEEMDO,FEER,FE01VEDO,FEULVEDO,Case When FEEMDO < FE01VEDO Then 'Credito' Else 'Contado' End As TipoVenta," &
                       "CONVERT(NVARCHAR, CONVERT(datetime, (Edo.HORAGRAB*1.0/3600)/24), 108) AS HORA,VANEDO,VAIVDO,VAIMDO,VABRDO,VAABDO,KOFUDO,NOKOFU,
                        Cast(0 As Bit) As Facturado,Cast(0 As Int) As IDMAEEDO_FCV,Cast('' As Varchar(10)) As NUDO_FCV,FEEMDO AS Fecha_Emision,Edo.FEER AS Fecha_Despacho," &
                       "Cast(0 As Float) As VABRDO_FCV,Cast(0 As Float) As VAABDO_FCV,Cast(0 As Bit) As FCV_PAGADA,Cast(0 As Bit) As FCV_IMPRESA,
                        Cast(0 As Int) As IDMAEDPCE,Cast(0 As Float) As VADP,Cast(0 As Float) As VAASDP,Cast(0 As Float) As SALDO," &
                       "Cast(0 As Bit) As CRV, Cast(0 as Float) SALDO_CRV,Isnull(OBDO,'') As OBDO,Cast(0 As Float) As 'SALDOAFAVOR'
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

        _Tbl_Doc_Facturar = _Sql.Fx_Get_DataTable(Consulta_sql)

        _Error = _Sql.Pro_Error

        Return _Error

    End Function

    Function Fx_Cargar_Ds_Facturacion(_Condicion As String) As Boolean

        Errores = String.Empty

        _Condicion = Replace(_Condicion, "IDMAEEDO", "Edo.IDMAEEDO")

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Edo.IDMAEEDO,TIDO,Edo.NUDO,Cast(ENDO As Varchar(10)) As ENDO,Cast(SUENDO As Varchar(10)) As SUENDO," &
                       "Cast('' As Varchar(15)) As Rut,NOKOEN,SUDO,FEEMDO,FEER,FE01VEDO,FEULVEDO,Case When FEEMDO < FE01VEDO Then 'Credito' Else 'Contado' End As TipoVenta," &
                       "CONVERT(NVARCHAR, CONVERT(datetime, (Edo.HORAGRAB*1.0/3600)/24), 108) AS HORA,VANEDO,VAIVDO,VAIMDO,VABRDO,VAABDO,KOFUDO,NOKOFU,
                        Cast(0 As Bit) As Facturado,Cast(0 As Int) As IDMAEEDO_FCV,Cast('' As Varchar(10)) As NUDO_FCV,FEEMDO AS Fecha_Emision,Edo.FEER AS Fecha_Despacho," &
                       "Cast(0 As Float) As VABRDO_FCV,Cast(0 As Float) As VAABDO_FCV,Cast(0 As Bit) As FCV_PAGADA,Cast(0 As Bit) As FCV_IMPRESA,
                        Cast(0 As Int) As IDMAEDPCE,Cast(0 As Float) As VADP,Cast(0 As Float) As VAASDP,Cast(0 As Float) As SALDO," &
                       "Cast(0 As Bit) As CRV, Cast(0 as Float) SALDO_CRV,Isnull(OBDO,'') As OBDO,
                       Isnull(DocE.HabilitadaFac,1) As HabilitadaFac,Isnull(DocE.Pickear,1) As Pickear,Cast(0 As Float) As 'SALDOAFAVOR'
                        Into #Informe
                        From MAEEDO Edo
                        Left Join MAEEDOOB Obs On Obs.IDMAEEDO = Edo.IDMAEEDO
                        Left Join MAEEN On KOEN = ENDO And SUENDO = SUEN
                        Left Join TABFU On KOFU = KOFUEN" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Docu_Ent DocE On DocE.Idmaeedo = Edo.IDMAEEDO And DocE.Tido = Edo.TIDO And DocE.Nudo = Edo.NUDO" & vbCrLf &
                        _Condicion & vbCrLf &
                       "Order By HORAGRAB
                        Update #Informe Set IDMAEDPCE = Isnull((Select Top 1 IDMAEDPCE From MAEDPCE Where IDRSD = IDMAEEDO),0)
                        Update #Informe Set VADP = Isnull((Select VADP From MAEDPCE Mp Where Mp.IDMAEDPCE = #Informe.IDMAEDPCE),0)
                        Update #Informe Set HORA = SUBSTRING(HORA,1,5),ENDO = Ltrim(Rtrim(ENDO)),SUENDO = Ltrim(Rtrim(SUENDO))

                        Update #Informe Set SALDO_CRV = VABRDO-VADP Where VADP > 0

SELECT DPCE.ENDP,
DPCE.TIDP AS TIDP,
DPCE.NUDP AS NUDP,
DPCE.NUCUDP AS NUCUDP,
DPCE.FEVEDP AS FEVEDP,
DPCE.ENDP AS ENTIDAD,
convert(char(10),DPCE.FEEMDP,103) AS EMISION,
convert(char(10),DPCE.FEVEDP,103) AS VENCIM,
DPCE.REFANTI AS GLOSA,DPCE.VADP,DPCE.VAASDP,
Isnull((Select Top 1 NOKOENDP From TABENDP Where KOENDP = EMDP),'????') AS BANCO,
DPCE.ESPGDP,
'VALOR' =CASE DPCE.TIMODP WHEN 'E' THEN 0 ELSE DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP END,
'VALORD'=CASE DPCE.TIMODP WHEN 'E' THEN DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP ELSE 0 END,
'NOMBRE'=( SELECT TOP 1 EN.NOKOEN FROM MAEEN EN WITH ( NOLOCK ) WHERE EN.KOEN=DPCE.ENDP ) 
Into #Paso
FROM MAEDPCE DPCE WITH ( NOLOCK ) 

WHERE DPCE.TIDP IN ( 'EFV','CHV','TJV','LTV','PAV','ncv','fcv','fdv','DEP','CRV','ATB' )
AND DPCE.EMPRESA='" & Mod_Empresa & "'  AND DPCE.ESASDP='P' 
AND ROUND(DPCE.VADP,2)-ROUND(DPCE.VAASDP,2)-ROUND(DPCE.VAVUDP,2)<>0.0 
AND DPCE.ENDP In (Select ENDO From #Informe)

Update #Informe Set SALDOAFAVOR = (Select Isnull(Sum(VALOR),0) From #Paso Where ENDP = ENDO)

Select * From #Informe
Order By ENDO,SUENDO,NUDO

Drop Table #Paso
Drop Table #Informe"

        _Ds_Doc_Facturar = _Sql.Fx_Get_DataSet(Consulta_sql)

        Errores = _Sql.Pro_Error

        If Not String.IsNullOrEmpty(Errores) Then
            Return False
        End If

        Return True

    End Function

End Class
