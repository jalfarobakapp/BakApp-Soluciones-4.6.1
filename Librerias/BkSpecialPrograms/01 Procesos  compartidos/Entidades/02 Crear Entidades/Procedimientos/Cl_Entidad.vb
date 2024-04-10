
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

            .Idmaeen = _Row.Item("IDMAEEN")
            .Koen = _Row.Item("KOEN")
            .Tien = _Row.Item("TIEN")
            .Rten = _Row.Item("RTEN")
            .Suen = _Row.Item("SUEN")
            .Suen = _Row.Item("SUEN")
            .Tiposuc = _Row.Item("TIPOSUC")
            .Nokoen = _Row.Item("NOKOEN")
            .Sien = _Row.Item("SIEN")
            .Gien = _Row.Item("GIEN")
            .Paen = _Row.Item("PAEN")
            .Cien = _Row.Item("CIEN")
            .Cmen = _Row.Item("CMEN")
            .Dien = _Row.Item("DIEN")
            .Zoen = _Row.Item("ZOEN")
            .Foen = _Row.Item("FOEN")
            .Faen = _Row.Item("FAEN")
            .Cnen = _Row.Item("CNEN")
            .Kofuen = _Row.Item("KOFUEN")
            .Lcen = _Row.Item("LCEN")
            .Lven = _Row.Item("LVEN")
            .Crsd = _Row.Item("CRSD")
            .Crch = _Row.Item("CRCH")
            .Crlt = _Row.Item("CRLT")
            .Crpa = _Row.Item("CRPA")
            .Crto = _Row.Item("CRTO")
            .Cren = _Row.Item("CREN")
            .Fevecren = _Row.Item("FEVECREN")
            .Feultr = _Row.Item("FEULTR")
            .Nuvecr = _Row.Item("NUVECR")
            .Dccr = _Row.Item("DCCR")
            .Incr = _Row.Item("INCR")
            .Popicr = _Row.Item("POPICR")
            .Koplcr = _Row.Item("KOPLCR")
            .Contab = _Row.Item("CONTAB")
            .Subauxi = _Row.Item("SUBAUXI")
            .Contabvta = _Row.Item("CONTABVTA")
            .Subauxivta = _Row.Item("SUBAUXIVTA")
            .Codcc = _Row.Item("CODCC")
            .Nutransmi = _Row.Item("NUTRANSMI")
            .Ruen = _Row.Item("RUEN")
            .Cpen = _Row.Item("CPEN")
            .Oben = _Row.Item("OBEN")
            .Diprve = _Row.Item("DIPRVE")
            .Email = _Row.Item("EMAIL")
            .Cnen2 = _Row.Item("CNEN2")
            .Cobrador = _Row.Item("COBRADOR")
            .Proteacum = _Row.Item("PROTEACUM")
            .Protevige = _Row.Item("PROTEVIGE")
            .Cpostal = _Row.Item("CPOSTAL")
            .Habilita = _Row.Item("HABILITA")
            .Codconve = _Row.Item("CODCONVE")
            .Notraedeud = _Row.Item("NOTRAEDEUD")
            .Nokoenamp = _Row.Item("NOKOENAMP")
            .Bloqueado = _Row.Item("BLOQUEADO")
            .Dimoper = _Row.Item("DIMOPER")
            .Prefen = _Row.Item("PREFEN")
            .Bloqencom = _Row.Item("BLOQENCOM")
            .Tipoen = _Row.Item("TIPOEN")
            .Actien = _Row.Item("ACTIEN")
            .Tamaen = _Row.Item("TAMAEN")
            .Porprefen = _Row.Item("PORPREFEN")
            .Claveen = _Row.Item("CLAVEEN")
            .Nvvpidepie = _Row.Item("NVVPIDEPIE")
            .Recepelect = _Row.Item("RECEPELECT")
            .Acteco = _Row.Item("ACTECO")
            .Diasvenci = NuloPorNro(_Row.Item("DIASVENCI"), 0)
            .Cattrib = _Row.Item("CATTRIB")
            .Agretiva = _Row.Item("AGRETIVA")
            .Agretiibb = _Row.Item("AGRETIIBB")
            .Agretgan = _Row.Item("AGRETGAN")
            .Agperiva = _Row.Item("AGPERIVA")
            .Agperiibb = _Row.Item("AGPERIIBB")
            .Transpoen = _Row.Item("TRANSPOEN")
            .Fecreen = _Row.Item("FECREEN")
            .Firma = _Row.Item("FIRMA")
            .Moctaen = _Row.Item("MOCTAEN")
            .Ctasdelaen = _Row.Item("CTASDELAEN")
            .Nacionen = _Row.Item("NACIONEN")
            .Dirparen = _Row.Item("DIRPAREN")
            .Fecnacen = NuloPorNro(_Row.Item("FECNACEN"), Nothing)
            .Estciven = _Row.Item("ESTCIVEN")
            .Profecen = _Row.Item("PROFECEN")
            .Conyugen = _Row.Item("CONYUGEN")
            .Rutconen = _Row.Item("RUTCONEN")
            .Rutsocen = _Row.Item("RUTSOCEN")
            .Sexoen = _Row.Item("SEXOEN")
            .Relacien = _Row.Item("RELACIEN")
            .Anexen1 = _Row.Item("ANEXEN1")
            .Anexen2 = _Row.Item("ANEXEN2")
            .Anexen3 = _Row.Item("ANEXEN3")
            .Anexen4 = _Row.Item("ANEXEN4")
            .Occobli = _Row.Item("OCCOBLI")
            .Valivenpag = _Row.Item("VALIVENPAG")
            .Emailcomer = _Row.Item("EMAILCOMER")
            .Tipocontr = _Row.Item("TIPOCONTR")
            .Ferefauto = _Row.Item("FEREFAUTO")
            .Diacobra = NuloPorNro(_Row.Item("DIACOBRA"), "")
            .Cuentabco = _Row.Item("CUENTABCO")
            .Koendpen = _Row.Item("KOENDPEN")
            .Suendpen = _Row.Item("SUENDPEN")
            .Rutalun = NuloPorNro(_Row.Item("RUTALUN"), 0)
            .Rutamar = NuloPorNro(_Row.Item("RUTAMAR"), 0)
            .Rutamie = NuloPorNro(_Row.Item("RUTAMIE"), 0)
            .Rutajue = NuloPorNro(_Row.Item("RUTAJUE"), 0)
            .Rutavie = NuloPorNro(_Row.Item("RUTAVIE"), 0)
            .Rutasab = NuloPorNro(_Row.Item("RUTASAB"), 0)
            .Rutadom = NuloPorNro(_Row.Item("RUTADOM"), 0)
            .Catlegret = _Row.Item("CATLEGRET")
            .Imptoret = _Row.Item("IMPTORET")
            .Entiliga = _Row.Item("ENTILIGA")
            .Porceliga = _Row.Item("PORCELIGA")
            .Actecobco = _Row.Item("ACTECOBCO")

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

        Public Property Idmaeen As Integer
        Public Property Koen As String
        Public Property Tien As String
        Public Property Rten As String
        Public Property Suen As String
        Public Property Tiposuc As String
        Public Property Nokoen As String
        Public Property Sien As String
        Public Property Gien As String
        Public Property Paen As String
        Public Property Cien As String
        Public Property Cmen As String
        Public Property Dien As String
        Public Property Zoen As String
        Public Property Foen As String
        Public Property Faen As String
        Public Property Cnen As String
        Public Property Kofuen As String
        Public Property Lcen As String
        Public Property Lven As String
        Public Property Crsd As Double
        Public Property Crch As Double
        Public Property Crlt As Double
        Public Property Crpa As Double
        Public Property Crto As Double
        Public Property Cren As String
        Public Property Fevecren As DateTime?
        Public Property Feultr As DateTime?
        Public Property Nuvecr As Double
        Public Property Dccr As Double
        Public Property Incr As Double
        Public Property Popicr As Double
        Public Property Koplcr As String
        Public Property Contab As String
        Public Property Subauxi As String
        Public Property Contabvta As String
        Public Property Subauxivta As String
        Public Property Codcc As String
        Public Property Nutransmi As String
        Public Property Ruen As String
        Public Property Cpen As String
        Public Property Oben As String
        Public Property Diprve As Double
        Public Property Email As String
        Public Property Cnen2 As String
        Public Property Cobrador As String
        Public Property Proteacum As Double
        Public Property Protevige As Double
        Public Property Cpostal As String
        Public Property Habilita As Boolean
        Public Property Codconve As String
        Public Property Notraedeud As Boolean
        Public Property Nokoenamp As String
        Public Property Bloqueado As Boolean
        Public Property Dimoper As Double
        Public Property Prefen As Boolean
        Public Property Bloqencom As Boolean
        Public Property Tipoen As String
        Public Property Actien As String
        Public Property Tamaen As String
        Public Property Porprefen As Double
        Public Property Claveen As String
        Public Property Nvvpidepie As Boolean
        Public Property Recepelect As Boolean
        Public Property Acteco As String
        Public Property Diasvenci As Integer
        Public Property Cattrib As String
        Public Property Agretiva As Boolean
        Public Property Agretiibb As Boolean
        Public Property Agretgan As Boolean
        Public Property Agperiva As Boolean
        Public Property Agperiibb As Boolean
        Public Property Transpoen As String
        Public Property Fecreen As DateTime?
        Public Property Firma As String
        Public Property Moctaen As String
        Public Property Ctasdelaen As String
        Public Property Nacionen As String
        Public Property Dirparen As String
        Public Property Fecnacen As DateTime?
        Public Property Estciven As String
        Public Property Profecen As String
        Public Property Conyugen As String
        Public Property Rutconen As String
        Public Property Rutsocen As String
        Public Property Sexoen As String
        Public Property Relacien As String
        Public Property Anexen1 As String
        Public Property Anexen2 As String
        Public Property Anexen3 As String
        Public Property Anexen4 As String
        Public Property Occobli As Boolean
        Public Property Valivenpag As Boolean
        Public Property Emailcomer As String
        Public Property Tipocontr As String
        Public Property Ferefauto As Boolean
        Public Property Diacobra As String
        Public Property Cuentabco As String
        Public Property Koendpen As String
        Public Property Suendpen As String
        Public Property Rutalun As Integer
        Public Property Rutamar As Integer
        Public Property Rutamie As Integer
        Public Property Rutajue As Integer
        Public Property Rutavie As Integer
        Public Property Rutasab As Integer
        Public Property Rutadom As Integer
        Public Property Catlegret As String
        Public Property Imptoret As Double
        Public Property Entiliga As String
        Public Property Porceliga As Double
        Public Property Actecobco As String

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

    End Class

End Namespace

