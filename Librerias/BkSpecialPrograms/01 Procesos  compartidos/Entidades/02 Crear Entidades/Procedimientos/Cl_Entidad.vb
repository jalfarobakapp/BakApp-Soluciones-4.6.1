
Public Class Cl_Entidades

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

    End Sub

    Function Fx_Llenar_Maeen(_Koen As String, _Suen As String) As Tablas_Entidades.Maeen

        Dim _Maeen As New Tablas_Entidades.Maeen

        Consulta_sql = "Select * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Return Nothing
        End If

        With _Maeen

            .IDMAEEN = _Row.Item("IDMAEEN")
            .KOEN = _Row.Item("KOEN")
            .TIEN = _Row.Item("TIEN")
            .RTEN = _Row.Item("RTEN")
            .SUEN = _Row.Item("SUEN")
            .SUEN = _Row.Item("SUEN")
            .TIPOSUC = _Row.Item("TIPOSUC")
            .NOKOEN = _Row.Item("NOKOEN")
            .SIEN = _Row.Item("SIEN")
            .GIEN = _Row.Item("GIEN")
            .PAEN = _Row.Item("PAEN")
            .CIEN = _Row.Item("CIEN")
            .CMEN = _Row.Item("CMEN")
            .DIEN = _Row.Item("DIEN")
            .ZOEN = _Row.Item("ZOEN")
            .FOEN = _Row.Item("FOEN")
            .FAEN = _Row.Item("FAEN")
            .CNEN = _Row.Item("CNEN")
            .KOFUEN = _Row.Item("KOFUEN")
            .LCEN = _Row.Item("LCEN")
            .LVEN = _Row.Item("LVEN")
            .CRSD = _Row.Item("CRSD")
            .CRCH = _Row.Item("CRCH")
            .CRLT = _Row.Item("CRLT")
            .CRPA = _Row.Item("CRPA")
            .CRTO = _Row.Item("CRTO")
            .CREN = _Row.Item("CREN")
            .FEVECREN = NuloPorNro(_Row.Item("FEVECREN"), Nothing)
            .FEULTR = NuloPorNro(_Row.Item("FEULTR"), Nothing)
            .NUVECR = _Row.Item("NUVECR")
            .DCCR = _Row.Item("DCCR")
            .INCR = _Row.Item("INCR")
            .POPICR = _Row.Item("POPICR")
            .KOPLCR = _Row.Item("KOPLCR")
            .CONTAB = _Row.Item("CONTAB")
            .SUBAUXI = _Row.Item("SUBAUXI")
            .CONTABVTA = _Row.Item("CONTABVTA")
            .SUBAUXIVTA = _Row.Item("SUBAUXIVTA")
            .CODCC = _Row.Item("CODCC")
            .NUTRANSMI = _Row.Item("NUTRANSMI")
            .RUEN = _Row.Item("RUEN")
            .CPEN = _Row.Item("CPEN")
            .OBEN = _Row.Item("OBEN")
            .DIPRVE = _Row.Item("DIPRVE")
            .EMAIL = _Row.Item("EMAIL")
            .CNEN2 = _Row.Item("CNEN2")
            .COBRADOR = _Row.Item("COBRADOR")
            .PROTEACUM = _Row.Item("PROTEACUM")
            .PROTEVIGE = _Row.Item("PROTEVIGE")
            .CPOSTAL = _Row.Item("CPOSTAL")
            .HABILITA = _Row.Item("HABILITA")
            .CODCONVE = _Row.Item("CODCONVE")
            .NOTRAEDEUD = _Row.Item("NOTRAEDEUD")
            .NOKOENAMP = _Row.Item("NOKOENAMP")
            .BLOQUEADO = _Row.Item("BLOQUEADO")
            .DIMOPER = _Row.Item("DIMOPER")
            .PREFEN = _Row.Item("PREFEN")
            .BLOQENCOM = _Row.Item("BLOQENCOM")
            .TIPOEN = _Row.Item("TIPOEN")
            .ACTIEN = _Row.Item("ACTIEN")
            .TAMAEN = _Row.Item("TAMAEN")
            .PORPREFEN = _Row.Item("PORPREFEN")
            .CLAVEEN = _Row.Item("CLAVEEN")
            .NVVPIDEPIE = _Row.Item("NVVPIDEPIE")
            .RECEPELECT = _Row.Item("RECEPELECT")
            .ACTECO = NuloPorNro(_Row.Item("ACTECO"), "")
            .DIASVENCI = NuloPorNro(_Row.Item("DIASVENCI"), 0)
            .CATTRIB = NuloPorNro(_Row.Item("CATTRIB"), "")
            .AGRETIVA = _Row.Item("AGRETIVA")
            .AGRETIIBB = _Row.Item("AGRETIIBB")
            .AGRETGAN = _Row.Item("AGRETGAN")
            .AGPERIVA = _Row.Item("AGPERIVA")
            .AGPERIIBB = _Row.Item("AGPERIIBB")
            .TRANSPOEN = _Row.Item("TRANSPOEN")
            .FECREEN = NuloPorNro(_Row.Item("FECREEN"), Nothing)
            .FIRMA = _Row.Item("FIRMA")
            .MOCTAEN = _Row.Item("MOCTAEN")
            .Ctasdelaen = _Row.Item("CTASDELAEN")
            .NACIONEN = NuloPorNro(_Row.Item("NACIONEN"), "")
            .DIRPAREN = NuloPorNro(_Row.Item("DIRPAREN"), "")
            .FECNACEN = NuloPorNro(_Row.Item("FECNACEN"), Nothing)
            .ESTCIVEN = NuloPorNro(_Row.Item("ESTCIVEN"), "")
            .PROFECEN = NuloPorNro(_Row.Item("PROFECEN"), "")
            .CONYUGEN = NuloPorNro(_Row.Item("CONYUGEN"), "")
            .RUTCONEN = NuloPorNro(_Row.Item("RUTCONEN"), "")
            .RUTSOCEN = NuloPorNro(_Row.Item("RUTSOCEN"), "")
            .SEXOEN = NuloPorNro(_Row.Item("SEXOEN"), "")
            .RELACIEN = NuloPorNro(_Row.Item("RELACIEN"), "")
            .ANEXEN1 = NuloPorNro(_Row.Item("ANEXEN1"), "")
            .ANEXEN2 = NuloPorNro(_Row.Item("ANEXEN2"), "")
            .ANEXEN3 = NuloPorNro(_Row.Item("ANEXEN3"), "")
            .ANEXEN4 = NuloPorNro(_Row.Item("ANEXEN4"), "")
            .OCCOBLI = _Row.Item("OCCOBLI")
            .VALIVENPAG = _Row.Item("VALIVENPAG")
            .EMAILCOMER = NuloPorNro(_Row.Item("EMAILCOMER"), "")
            .TIPOCONTR = NuloPorNro(_Row.Item("TIPOCONTR"), "")
            .FEREFAUTO = _Row.Item("FEREFAUTO")
            .DIACOBRA = NuloPorNro(_Row.Item("DIACOBRA"), "")
            .CUENTABCO = NuloPorNro(_Row.Item("CUENTABCO"), "")
            .KOENDPEN = NuloPorNro(_Row.Item("KOENDPEN"), "")
            .SUENDPEN = NuloPorNro(_Row.Item("SUENDPEN"), "")
            .RUTALUN = NuloPorNro(_Row.Item("RUTALUN"), 0)
            .RUTAMAR = NuloPorNro(_Row.Item("RUTAMAR"), 0)
            .RUTAMIE = NuloPorNro(_Row.Item("RUTAMIE"), 0)
            .RUTAJUE = NuloPorNro(_Row.Item("RUTAJUE"), 0)
            .RUTAVIE = NuloPorNro(_Row.Item("RUTAVIE"), 0)
            .RUTASAB = NuloPorNro(_Row.Item("RUTASAB"), 0)
            .RUTADOM = NuloPorNro(_Row.Item("RUTADOM"), 0)
            .CATLEGRET = NuloPorNro(_Row.Item("CATLEGRET"), "")
            .IMPTORET = NuloPorNro(_Row.Item("IMPTORET"), 0)
            .ENTILIGA = NuloPorNro(_Row.Item("ENTILIGA"), "")
            .PORCELIGA = NuloPorNro(_Row.Item("PORCELIGA"), 0)
            .ACTECOBCO = NuloPorNro(_Row.Item("ACTECOBCO"), "")

        End With

        Return _Maeen

    End Function

    Function Fx_Llenar_Zw_Entidades(_CodEntidad As String, _CodSucEntidad As String) As Tablas_Entidades.Zw_Entidades

        Dim _Zw_Entidades As New Tablas_Entidades.Zw_Entidades

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Return Nothing
        End If

        With _Zw_Entidades

            .CodEntidad = _Row.Item("CodEntidad")
            .CodSucEntidad = _Row.Item("CodSucEntidad")
            .Libera_NVV = _Row.Item("Libera_NVV")
            .AG_AgenciaxDefDespachos = _Row.Item("AG_AgenciaxDefDespachos")
            .AG_Transportista = _Row.Item("AG_Transportista")
            .AG_Nombre_Contacto = _Row.Item("AG_Nombre_Contacto")
            .RT_Transportista = _Row.Item("RT_Transportista")
            .EntregaPaletizada = _Row.Item("EntregaPaletizada")
            .Metodo_Abastecer_Dias_Meses = _Row.Item("Metodo_Abastecer_Dias_Meses")
            .Dias_a_Abastecer = _Row.Item("Dias_a_Abastecer")
            .Tiempo_Reposicion_Dias_Meses = _Row.Item("Tiempo_Reposicion_Dias_Meses")
            .Tiempo_Reposicion = _Row.Item("Tiempo_Reposicion")
            .FacAuto = _Row.Item("FacAuto")
            .RevFincred = _Row.Item("RevFincred")
            .EmailCompras = _Row.Item("EmailCompras")
            .MontoMinCompra = _Row.Item("MontoMinCompra")
            .NoResMtoMinComAsCompraAuto = _Row.Item("NoResMtoMinComAsCompraAuto")
            .JuntaPuntos = _Row.Item("JuntaPuntos")
            .EmailPuntos = _Row.Item("EmailPuntos")
            .FechaInscripPuntos = NuloPorNro(_Row.Item("FechaInscripPuntos"), Nothing)

        End With

        Return _Zw_Entidades

    End Function

End Class

Namespace Tablas_Entidades

    Public Class Maeen

        Public Property IDMAEEN As Integer
        Public Property KOEN As String
        Public Property TIEN As String
        Public Property RTEN As String
        Public Property SUEN As String
        Public Property TIPOSUC As String
        Public Property NOKOEN As String
        Public Property SIEN As String
        Public Property GIEN As String
        Public Property PAEN As String
        Public Property CIEN As String
        Public Property CMEN As String
        Public Property DIEN As String
        Public Property ZOEN As String
        Public Property FOEN As String
        Public Property FAEN As String
        Public Property CNEN As String
        Public Property KOFUEN As String
        Public Property LCEN As String
        Public Property LVEN As String
        Public Property CRSD As Double
        Public Property CRCH As Double
        Public Property CRLT As Double
        Public Property CRPA As Double
        Public Property CRTO As Double
        Public Property CREN As String
        Public Property FEVECREN As DateTime?
        Public Property FEULTR As DateTime?
        Public Property NUVECR As Double
        Public Property DCCR As Double
        Public Property INCR As Double
        Public Property POPICR As Double
        Public Property KOPLCR As String
        Public Property CONTAB As String
        Public Property SUBAUXI As String
        Public Property CONTABVTA As String
        Public Property SUBAUXIVTA As String
        Public Property CODCC As String
        Public Property NUTRANSMI As String
        Public Property RUEN As String
        Public Property CPEN As String
        Public Property OBEN As String
        Public Property DIPRVE As Double
        Public Property EMAIL As String
        Public Property CNEN2 As String
        Public Property COBRADOR As String
        Public Property PROTEACUM As Double
        Public Property PROTEVIGE As Double
        Public Property CPOSTAL As String
        Public Property HABILITA As Boolean
        Public Property CODCONVE As String
        Public Property NOTRAEDEUD As Boolean
        Public Property NOKOENAMP As String
        Public Property BLOQUEADO As Boolean
        Public Property DIMOPER As Double
        Public Property PREFEN As Boolean
        Public Property BLOQENCOM As Boolean
        Public Property TIPOEN As String
        Public Property ACTIEN As String
        Public Property TAMAEN As String
        Public Property PORPREFEN As Double
        Public Property CLAVEEN As String
        Public Property NVVPIDEPIE As Boolean
        Public Property RECEPELECT As Boolean
        Public Property ACTECO As String
        Public Property DIASVENCI As Integer
        Public Property CATTRIB As String
        Public Property AGRETIVA As Boolean
        Public Property AGRETIIBB As Boolean
        Public Property AGRETGAN As Boolean
        Public Property AGPERIVA As Boolean
        Public Property AGPERIIBB As Boolean
        Public Property TRANSPOEN As String
        Public Property FECREEN As DateTime?
        Public Property FIRMA As String
        Public Property MOCTAEN As String
        Public Property CTASDELAEN As String
        Public Property NACIONEN As String
        Public Property DIRPAREN As String
        Public Property FECNACEN As DateTime?
        Public Property ESTCIVEN As String
        Public Property PROFECEN As String
        Public Property CONYUGEN As String
        Public Property RUTCONEN As String
        Public Property RUTSOCEN As String
        Public Property SEXOEN As String
        Public Property RELACIEN As String
        Public Property ANEXEN1 As String
        Public Property ANEXEN2 As String
        Public Property ANEXEN3 As String
        Public Property ANEXEN4 As String
        Public Property OCCOBLI As Boolean
        Public Property VALIVENPAG As Boolean
        Public Property EMAILCOMER As String
        Public Property TIPOCONTR As String
        Public Property FEREFAUTO As Boolean
        Public Property DIACOBRA As String
        Public Property CUENTABCO As String
        Public Property KOENDPEN As String
        Public Property SUENDPEN As String
        Public Property RUTALUN As Integer
        Public Property RUTAMAR As Integer
        Public Property RUTAMIE As Integer
        Public Property RUTAJUE As Integer
        Public Property RUTAVIE As Integer
        Public Property RUTASAB As Integer
        Public Property RUTADOM As Integer
        Public Property CATLEGRET As String
        Public Property IMPTORET As Double
        Public Property ENTILIGA As String
        Public Property PORCELIGA As Double
        Public Property ACTECOBCO As String

    End Class

    Public Class Zw_Entidades

        Public Property CodEntidad As String
        Public Property CodSucEntidad As String
        Public Property Libera_NVV As Boolean
        Public Property AG_AgenciaxDefDespachos As Boolean
        Public Property AG_Transportista As String
        Public Property AG_Nombre_Contacto As String
        Public Property RT_Transportista As String
        Public Property EntregaPaletizada As Boolean
        Public Property Metodo_Abastecer_Dias_Meses As Integer
        Public Property Dias_a_Abastecer As Integer
        Public Property Tiempo_Reposicion_Dias_Meses As Integer
        Public Property Tiempo_Reposicion As Integer
        Public Property FacAuto As Boolean
        Public Property RevFincred As Boolean
        Public Property EmailCompras As String
        Public Property MontoMinCompra As Double
        Public Property NoResMtoMinComAsCompraAuto As Boolean
        Public Property JuntaPuntos As Boolean
        Public Property EmailPuntos As String
        Public Property FechaInscripPuntos As DateTime?
        Public Property CodFuncionario_Enrola As String

    End Class

End Namespace

