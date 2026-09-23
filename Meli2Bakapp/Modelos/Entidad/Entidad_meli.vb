Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones

Public Class Entidad_meli

#Region "Clases Internas (Estructuras de Datos)"
    Public Class CLIENTES
        Public Property ID As Integer
        Public Property ID_MP As Integer?
        Public Property NICK As String
        Public Property KOEN As String
        Public Property RTEN As String
        Public Property DV As String
        Public Property NOKOEN As String
        Public Property GIRO As String
        Public Property CIUDAD As String
        Public Property STATE As String
        Public Property CALLE As String
        Public Property NUMERO As String
        Public Property EMAIL As String
        Public Property ESTADO As Integer?

    End Class
    Public Class Maeen_Data
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

    Public Class Zw_Entidades_Data
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
        Public Property FechaVencLista As DateTime?
        Public Property CodHolding As String
        Public Property PreMayMinXHolding As Boolean
        Public Property CodPagador As String
        Public Property NoCobrarPallet As Boolean
        Public Property ImpNoCobraVta As Boolean
        Public Property ImpNoCobraVtaStr As String
        Public Property NoUsaListasModalidad As Boolean
        Public Property EsCiaSeguro As Boolean
        Public Property Pais As String
        Public Property Ciudad As String
        Public Property Comuna As String
    End Class

#End Region

#Region "Propiedades Principales"
    Public Property Entidad_Random As New Maeen_Data()
        Public Property Entidad_Bakapp As New Zw_Entidades_Data()
#End Region

#Region "Métodos"
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Public Sub New()

        End Sub

        Public Function Fx_Generar_Zw_Entidades_Defecto() As Zw_Entidades_Data
            Dim _Zw As New Zw_Entidades_Data()

            With _Zw
                .CodEntidad = Me.Entidad_Random.KOEN
                .CodSucEntidad = Me.Entidad_Random.SUEN

                .Libera_NVV = False
                .AG_AgenciaxDefDespachos = True
                .AG_Transportista = ""
                .AG_Nombre_Contacto = ""
                .RT_Transportista = ""
                .EntregaPaletizada = False
                .Metodo_Abastecer_Dias_Meses = 0
                .Dias_a_Abastecer = 0
                .Tiempo_Reposicion_Dias_Meses = 0
                .Tiempo_Reposicion = 0
                .FacAuto = False
                .RevFincred = False

                .EmailCompras = Me.Entidad_Random.EMAILCOMER

                .MontoMinCompra = 0
                .NoResMtoMinComAsCompraAuto = False
                .JuntaPuntos = False
                .EmailPuntos = ""
                .FechaInscripPuntos = Nothing
                .CodFuncionario_Enrola = ""
                .FechaVencLista = Nothing
                .CodHolding = ""
                .PreMayMinXHolding = False
                .CodPagador = ""
                .NoCobrarPallet = False
                .ImpNoCobraVta = False
                .ImpNoCobraVtaStr = ""
                .NoUsaListasModalidad = False
                .EsCiaSeguro = False
                .Pais = "CHILE"
                .Ciudad = ""
                .Comuna = ""
            End With

            Return _Zw
        End Function

        Function Fx_Trae_Maeen(_Koen As String, _Suen As String) As Entidad_meli
            Consulta_sql = "Select * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Return Nothing
            End If

            With Me.Entidad_Random
                .IDMAEEN = _Row.Item("IDMAEEN")
                .KOEN = _Row.Item("KOEN")
                .TIEN = _Row.Item("TIEN")
                .RTEN = _Row.Item("RTEN")
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
                .CTASDELAEN = _Row.Item("CTASDELAEN")
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

            Return Me
        End Function

        Function Fx_Trae_Zw_Entidades(_CodEntidad As String, _CodSucEntidad As String) As Zw_Entidades_Data
            Dim _Zw As New Zw_Entidades_Data()

            Consulta_sql = "Select TOP (200) CodEntidad, CodSucEntidad, Libera_NVV, AG_AgenciaxDefDespachos, AG_Transportista, " &
                       "AG_Nombre_Contacto, RT_Transportista, EntregaPaletizada, Metodo_Abastecer_Dias_Meses, Dias_a_Abastecer, " &
                       "Tiempo_Reposicion_Dias_Meses, Tiempo_Reposicion, FacAuto, RevFincred, EmailCompras, MontoMinCompra, " &
                       "NoResMtoMinComAsCompraAuto, JuntaPuntos, EmailPuntos, FechaInscripPuntos, CodFuncionario_Enrola, " &
                       "FechaVencLista, CodHolding, PreMayMinXHolding, CodPagador, NoCobrarPallet, ImpNoCobraVta, ImpNoCobraVtaStr, " &
                       "NoUsaListasModalidad, EsCiaSeguro, Pais, Ciudad, Comuna " &
                       "From " & _Global_BaseBk & "Zw_Entidades Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'"

            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Return Nothing
            End If

            With _Zw
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
                .CodFuncionario_Enrola = _Row.Item("CodFuncionario_Enrola")
                .FechaVencLista = NuloPorNro(_Row.Item("FechaVencLista"), Nothing)
                .CodHolding = _Row.Item("CodHolding")
                .PreMayMinXHolding = _Row.Item("PreMayMinXHolding")
                .CodPagador = _Row.Item("CodPagador")
                .NoCobrarPallet = _Row.Item("NoCobrarPallet")
                .ImpNoCobraVta = _Row.Item("ImpNoCobraVta")
                .ImpNoCobraVtaStr = _Row.Item("ImpNoCobraVtaStr")
                .NoUsaListasModalidad = NuloPorNro(_Row.Item("NoUsaListasModalidad"), False)
                .EsCiaSeguro = _Row.Item("EsCiaSeguro")
                .Pais = NuloPorNro(_Row.Item("Pais"), "")
                .Ciudad = NuloPorNro(_Row.Item("Ciudad"), "")
                .Comuna = NuloPorNro(_Row.Item("Comuna"), "")
            End With

            Return _Zw
        End Function

        Public Sub Setear_Entidad(Entidad_Meli As Entidad_meli)
            If Entidad_Meli Is Nothing Then Return

            Dim o As Maeen_Data = Entidad_Meli.Entidad_Random

            With Me.Entidad_Random
                .IDMAEEN = o.IDMAEEN
                .KOEN = o.KOEN
                .TIEN = o.TIEN
                .RTEN = o.RTEN
                .SUEN = o.SUEN
                .TIPOSUC = o.TIPOSUC
                .NOKOEN = o.NOKOEN
                .SIEN = o.SIEN
                .GIEN = o.GIEN
                .PAEN = o.PAEN
                .CIEN = o.CIEN
                .CMEN = o.CMEN
                .DIEN = o.DIEN
                .ZOEN = o.ZOEN
                .FOEN = o.FOEN
                .FAEN = o.FAEN
                .CNEN = o.CNEN
                .KOFUEN = o.KOFUEN
                .LCEN = o.LCEN
                .LVEN = o.LVEN
                .CRSD = o.CRSD
                .CRCH = o.CRCH
                .CRLT = o.CRLT
                .CRPA = o.CRPA
                .CRTO = o.CRTO
                .CREN = o.CREN
                .FEVECREN = o.FEVECREN
                .FEULTR = o.FEULTR
                .NUVECR = o.NUVECR
                .DCCR = o.DCCR
                .INCR = o.INCR
                .POPICR = o.POPICR
                .KOPLCR = o.KOPLCR
                .CONTAB = o.CONTAB
                .SUBAUXI = o.SUBAUXI
                .CONTABVTA = o.CONTABVTA
                .SUBAUXIVTA = o.SUBAUXIVTA
                .CODCC = o.CODCC
                .NUTRANSMI = o.NUTRANSMI
                .RUEN = o.RUEN
                .CPEN = o.CPEN
                .OBEN = o.OBEN
                .DIPRVE = o.DIPRVE
                .EMAIL = o.EMAIL
                .CNEN2 = o.CNEN2
                .COBRADOR = o.COBRADOR
                .PROTEACUM = o.PROTEACUM
                .PROTEVIGE = o.PROTEVIGE
                .CPOSTAL = o.CPOSTAL
                .HABILITA = o.HABILITA
                .CODCONVE = o.CODCONVE
                .NOTRAEDEUD = o.NOTRAEDEUD
                .NOKOENAMP = o.NOKOENAMP
                .BLOQUEADO = o.BLOQUEADO
                .DIMOPER = o.DIMOPER
                .PREFEN = o.PREFEN
                .BLOQENCOM = o.BLOQENCOM
                .TIPOEN = o.TIPOEN
                .ACTIEN = o.ACTIEN
                .TAMAEN = o.TAMAEN
                .PORPREFEN = o.PORPREFEN
                .CLAVEEN = o.CLAVEEN
                .NVVPIDEPIE = o.NVVPIDEPIE
                .RECEPELECT = o.RECEPELECT
                .ACTECO = o.ACTECO
                .DIASVENCI = o.DIASVENCI
                .CATTRIB = o.CATTRIB
                .AGRETIVA = o.AGRETIVA
                .AGRETIIBB = o.AGRETIIBB
                .AGRETGAN = o.AGRETGAN
                .AGPERIVA = o.AGPERIVA
                .AGPERIIBB = o.AGPERIIBB
                .TRANSPOEN = o.TRANSPOEN
                .FECREEN = o.FECREEN
                .FIRMA = o.FIRMA
                .MOCTAEN = o.MOCTAEN
                .CTASDELAEN = o.CTASDELAEN
                .NACIONEN = o.NACIONEN
                .DIRPAREN = o.DIRPAREN
                .FECNACEN = o.FECNACEN
                .ESTCIVEN = o.ESTCIVEN
                .PROFECEN = o.PROFECEN
                .CONYUGEN = o.CONYUGEN
                .RUTCONEN = o.RUTCONEN
                .RUTSOCEN = o.RUTSOCEN
                .SEXOEN = o.SEXOEN
                .RELACIEN = o.RELACIEN
                .ANEXEN1 = o.ANEXEN1
                .ANEXEN2 = o.ANEXEN2
                .ANEXEN3 = o.ANEXEN3
                .ANEXEN4 = o.ANEXEN4
                .OCCOBLI = o.OCCOBLI
                .VALIVENPAG = o.VALIVENPAG
                .EMAILCOMER = o.EMAILCOMER
                .TIPOCONTR = o.TIPOCONTR
                .FEREFAUTO = o.FEREFAUTO
                .DIACOBRA = o.DIACOBRA
                .CUENTABCO = o.CUENTABCO
                .KOENDPEN = o.KOENDPEN
                .SUENDPEN = o.SUENDPEN
                .RUTALUN = o.RUTALUN
                .RUTAMAR = o.RUTAMAR
                .RUTAMIE = o.RUTAMIE
                .RUTAJUE = o.RUTAJUE
                .RUTAVIE = o.RUTAVIE
                .RUTASAB = o.RUTASAB
                .RUTADOM = o.RUTADOM
                .CATLEGRET = o.CATLEGRET
                .IMPTORET = o.IMPTORET
                .ENTILIGA = o.ENTILIGA
                .PORCELIGA = o.PORCELIGA
                .ACTECOBCO = o.ACTECOBCO
            End With

            If Entidad_Meli.Entidad_Bakapp IsNot Nothing Then
                Me.Entidad_Bakapp = Entidad_Meli.Entidad_Bakapp
            End If
        End Sub
        Public Function Fx_Crear_Entidad_Bakapp_Desde_Random() As Zw_Entidades_Data
            Dim _Zw As New Zw_Entidades_Data()
            Dim _EntidadRandom = Entidad_Random
            ' Validamos que el objeto no venga nulo
            If _EntidadRandom Is Nothing Then Return _Zw

            With _Zw
                ' Enlazamos con los códigos de la cabecera MAEEN entregada
                .CodEntidad = _EntidadRandom.KOEN
                .CodSucEntidad = _EntidadRandom.SUEN

                ' Configuraciones de BakApp por defecto
                .Libera_NVV = False
                .AG_AgenciaxDefDespachos = True
                .AG_Transportista = ""
                .AG_Nombre_Contacto = ""
                .RT_Transportista = ""
                .EntregaPaletizada = False
                .Metodo_Abastecer_Dias_Meses = 0
                .Dias_a_Abastecer = 0
                .Tiempo_Reposicion_Dias_Meses = 0
                .Tiempo_Reposicion = 0
                .FacAuto = False
                .RevFincred = False

                ' Heredamos el correo de la entidad Random
                .EmailCompras = _EntidadRandom.EMAILCOMER

                .MontoMinCompra = 0
                .NoResMtoMinComAsCompraAuto = False
                .JuntaPuntos = False
                .EmailPuntos = ""
                .FechaInscripPuntos = Nothing
                .CodFuncionario_Enrola = ""
                .FechaVencLista = Nothing
                .CodHolding = ""
                .PreMayMinXHolding = False
                .CodPagador = ""
                .NoCobrarPallet = False
                .ImpNoCobraVta = False
                .ImpNoCobraVtaStr = ""
                .NoUsaListasModalidad = False
                .EsCiaSeguro = False
                .Pais = ""
                .Ciudad = ""
                .Comuna = ""
            End With

            Return _Zw
        End Function
        Public Function Fx_Crear_Entidad_Nueva() As Mensajes
            Dim MAEEN = Entidad_Random

            Dim _Zw_Entidades = Entidad_Bakapp

            Dim _Msj As New Mensajes


            ' =================================================================
            ' 1. VALIDACIONES DE CREACIÓN
            ' =================================================================
            If String.IsNullOrEmpty(Me.Entidad_Random.KOEN) Then
                _Msj.Mensaje = "Código de entidad vacío, debe completar datos."
                Return _Msj
            End If

            Dim _EncuetraEnt As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Me.Entidad_Random.KOEN & "' And SUEN = '" & Me.Entidad_Random.SUEN & "'"))
            If _EncuetraEnt Then
                _Msj.Mensaje = "¡Entidad ya existe en la base de datos! No es posible crearla."
                Return _Msj
            End If

            If String.IsNullOrEmpty(Me.Entidad_Random.TIPOSUC) Then
                _Msj.Mensaje = "Falta el tipo de entidad (Empresa/Sucursal)."
                Return _Msj
            End If

            If String.IsNullOrEmpty(Me.Entidad_Random.NOKOEN) Then
                _Msj.Mensaje = "Falta la razón social."
                Return _Msj
            End If

            If String.IsNullOrEmpty(Me.Entidad_Random.DIEN) Then
                _Msj.Mensaje = "Falta la dirección."
                Return _Msj
            End If

            If String.IsNullOrEmpty(Me.Entidad_Random.GIEN) Then
                _Msj.Mensaje = "Falta el giro."
                Return _Msj
            End If




        ' Validaciones de Zw_Entidades
        If _Zw_Entidades IsNot Nothing Then
                Dim _Suma As Double = Me.Entidad_Random.CRTO + Me.Entidad_Random.CRSD + Me.Entidad_Random.CRCH + Me.Entidad_Random.CRLT + Me.Entidad_Random.CRPA

                If _Zw_Entidades.Libera_NVV And _Suma > 0 Then
                    _Msj.Mensaje = "No puede dejar Libera NVV en [SI] cuando la entidad tiene créditos asociados."
                    Return _Msj
                End If

                If _Zw_Entidades.ImpNoCobraVta AndAlso String.IsNullOrEmpty(_Zw_Entidades.ImpNoCobraVtaStr) Then
                    _Msj.Mensaje = "Debe indicar el impuesto que no cobra en ventas."
                    Return _Msj
                End If

        End If

            Me.Entidad_Random.RTEN = Replace(Me.Entidad_Random.RTEN, ".", "")
            Dim Rut() As String = Split(Me.Entidad_Random.RTEN, "-")
            Dim _TipoSuc As String = Me.Entidad_Random.TIPOSUC

            If _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Me.Entidad_Random.KOEN & "'") > 0 Then
                _TipoSuc = "S"
            End If

            ' =================================================================
            ' 2. INICIO DE TRANSACCIÓN SQL
            ' =================================================================
            Dim cn2 As New SqlClient.SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim myTrans As SqlClient.SqlTransaction
            Dim Comando As SqlClient.SqlCommand
            Dim Consulta_sql As String

            SQL_ServerClass.Sb_Abrir_Conexion(cn2)
            myTrans = cn2.BeginTransaction()

            Try
                ' -----------------------------------------------------------
                ' INSERTAR CABECERA (MAEEN)
                ' -----------------------------------------------------------
                Consulta_sql = Fx_Obtener_Query_Inserta_MAEEN()

                Consulta_sql = Replace(Consulta_sql, "#KOEN#", Me.Entidad_Random.KOEN)
                Consulta_sql = Replace(Consulta_sql, "#TIEN#", Me.Entidad_Random.TIEN)
                Consulta_sql = Replace(Consulta_sql, "#RTEN#", Trim(numero_(Rut(0), 8)))
                Consulta_sql = Replace(Consulta_sql, "#SUEN#", Me.Entidad_Random.SUEN)
                Consulta_sql = Replace(Consulta_sql, "#TIPOSUC#", _TipoSuc)

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                ' -----------------------------------------------------------
                ' LIMPIAR TABLAS SECUNDARIAS
                ' -----------------------------------------------------------
                Consulta_sql = "DELETE FROM MAEENCON WHERE KOEN='' " & vbCrLf &
                           "DELETE FROM MAEENPRO WHERE KOEN='" & Me.Entidad_Random.KOEN & "' AND SUEN='" & Me.Entidad_Random.SUEN & "' " & vbCrLf &
                           "INSERT INTO MAEENPRO (KOEN,SUEN,PROYECTO) VALUES ('" & Me.Entidad_Random.KOEN & "','" & Me.Entidad_Random.SUEN & "','') " & vbCrLf &
                           "DELETE FROM MAEENCTA WHERE KOEN='" & Me.Entidad_Random.KOEN & "' "
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                ' -----------------------------------------------------------
                ' ACTUALIZAR EL RESTO DE LOS DATOS DE LA ENTIDAD
                ' -----------------------------------------------------------
                Consulta_sql = Fx_Obtener_Query_Actualiza_MAEEN()

                Consulta_sql = Replace(Consulta_sql, "#KOEN#", Me.Entidad_Random.KOEN)
                Consulta_sql = Replace(Consulta_sql, "#TIEN#", UCase(Trim(Me.Entidad_Random.TIEN)))
                Consulta_sql = Replace(Consulta_sql, "#RTEN#", UCase(Trim(numero_(Rut(0), 8))))
                Consulta_sql = Replace(Consulta_sql, "#SUEN#", Me.Entidad_Random.SUEN)
                Consulta_sql = Replace(Consulta_sql, "#TIPOSUC#", _TipoSuc)
                Consulta_sql = Replace(Consulta_sql, "#NOKOEN#", UCase(Trim(Me.Entidad_Random.NOKOEN)))
                Consulta_sql = Replace(Consulta_sql, "#SIEN#", UCase(Trim(Me.Entidad_Random.SIEN)))
                Consulta_sql = Replace(Consulta_sql, "#GIEN#", UCase(Trim(Me.Entidad_Random.GIEN)))
                Consulta_sql = Replace(Consulta_sql, "#EMAIL#", Me.Entidad_Random.EMAIL)
                Consulta_sql = Replace(Consulta_sql, "#EMAILCOMER#", Me.Entidad_Random.EMAILCOMER)
                Consulta_sql = Replace(Consulta_sql, "#PAEN#", Me.Entidad_Random.PAEN)
                Consulta_sql = Replace(Consulta_sql, "#CIEN#", Me.Entidad_Random.CIEN)
                Consulta_sql = Replace(Consulta_sql, "#CMEN#", Me.Entidad_Random.CMEN)
                Consulta_sql = Replace(Consulta_sql, "#DIEN#", UCase(Trim(Me.Entidad_Random.DIEN)))
                Consulta_sql = Replace(Consulta_sql, "#ZOEN#", Me.Entidad_Random.ZOEN)
                Consulta_sql = Replace(Consulta_sql, "#FOEN#", UCase(Trim(Me.Entidad_Random.FOEN)))
                Consulta_sql = Replace(Consulta_sql, "#FAEN#", UCase(Trim(Me.Entidad_Random.FAEN)))
                Consulta_sql = Replace(Consulta_sql, "#CPOSTAL#", Me.Entidad_Random.CPOSTAL)
                Consulta_sql = Replace(Consulta_sql, "#NOKOENAMP#", Me.Entidad_Random.NOKOENAMP)
                Consulta_sql = Replace(Consulta_sql, "#KOFUEN#", Me.Entidad_Random.KOFUEN)
                Consulta_sql = Replace(Consulta_sql, "#COBRADOR#", Me.Entidad_Random.COBRADOR)
                Consulta_sql = Replace(Consulta_sql, "#LCEN#", Me.Entidad_Random.LCEN)
                Consulta_sql = Replace(Consulta_sql, "#LVEN#", Me.Entidad_Random.LVEN)
                Consulta_sql = Replace(Consulta_sql, "#RUEN#", Me.Entidad_Random.RUEN)
                Consulta_sql = Replace(Consulta_sql, "#TIPOEN#", Me.Entidad_Random.TIPOEN)
                Consulta_sql = Replace(Consulta_sql, "#ACTIEN#", Me.Entidad_Random.ACTIEN)
                Consulta_sql = Replace(Consulta_sql, "#TAMAEN#", Me.Entidad_Random.TAMAEN)
                Consulta_sql = Replace(Consulta_sql, "#TRANSPOEN#", Me.Entidad_Random.TRANSPOEN)
                Consulta_sql = Replace(Consulta_sql, "#OBEN#", UCase(Trim(Me.Entidad_Random.OBEN)))

                Consulta_sql = Replace(Consulta_sql, "#CRTO#", De_Num_a_Tx_01(Me.Entidad_Random.CRTO, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#CRSD#", De_Num_a_Tx_01(Me.Entidad_Random.CRSD, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#CRCH#", De_Num_a_Tx_01(Me.Entidad_Random.CRCH, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#CRLT#", De_Num_a_Tx_01(Me.Entidad_Random.CRLT, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#CRPA#", De_Num_a_Tx_01(Me.Entidad_Random.CRPA, False, 5))

                Consulta_sql = Replace(Consulta_sql, "#NUVECR#", De_Num_a_Tx_01(Me.Entidad_Random.NUVECR, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#DIPRVE#", De_Num_a_Tx_01(Me.Entidad_Random.DIPRVE, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#DIASVENCI#", De_Num_a_Tx_01(Me.Entidad_Random.DIASVENCI, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#DIMOPER#", De_Num_a_Tx_01(Me.Entidad_Random.DIMOPER, False, 5))

                Consulta_sql = Replace(Consulta_sql, "#FEULTR#", Format(Now.Date, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#FECREEN#", If(Me.Entidad_Random.FECREEN.HasValue, Format(Me.Entidad_Random.FECREEN.Value, "yyyyMMdd"), Format(Now.Date, "yyyyMMdd")))

                Dim _Fevecren As String = "Null"
                If Me.Entidad_Random.FEVECREN.HasValue Then _Fevecren = "'" & Format(Me.Entidad_Random.FEVECREN.Value, "yyyyMMdd") & "'"
                Consulta_sql = Replace(Consulta_sql, "'#FEVECREN#'", _Fevecren)

                Consulta_sql = Replace(Consulta_sql, "#CPEN#", UCase(Trim(Me.Entidad_Random.CPEN)))
                Consulta_sql = Replace(Consulta_sql, "#NVVPIDEPIE#", Convert.ToInt32(Me.Entidad_Random.NVVPIDEPIE))
                Consulta_sql = Replace(Consulta_sql, "#POPICR#", De_Num_a_Tx_01(Me.Entidad_Random.POPICR, False, 5))
                Consulta_sql = Replace(Consulta_sql, "#BLOQUEADO#", Convert.ToInt32(Me.Entidad_Random.BLOQUEADO))
                Consulta_sql = Replace(Consulta_sql, "#BLOQENCOM#", Convert.ToInt32(Me.Entidad_Random.BLOQENCOM))
                Consulta_sql = Replace(Consulta_sql, "#PREFEN#", Convert.ToInt32(Me.Entidad_Random.PREFEN))
                Consulta_sql = Replace(Consulta_sql, "#NOTRAEDEUD#", Convert.ToInt32(Me.Entidad_Random.NOTRAEDEUD))
                Consulta_sql = Replace(Consulta_sql, "#OCCOBLI#", Convert.ToInt32(Me.Entidad_Random.OCCOBLI))
                Consulta_sql = Replace(Consulta_sql, "#FEREFAUTO#", Convert.ToInt32(Me.Entidad_Random.FEREFAUTO))
                Consulta_sql = Replace(Consulta_sql, "#MOCTAEN#", Me.Entidad_Random.MOCTAEN)

                Consulta_sql = Replace(Consulta_sql, "#DIACOBRA#", Me.Entidad_Random.DIACOBRA)
                Consulta_sql = Replace(Consulta_sql, "#CUENTABCO#", Me.Entidad_Random.CUENTABCO)
                Consulta_sql = Replace(Consulta_sql, "#KOENDPEN#", Me.Entidad_Random.KOENDPEN)
                Consulta_sql = Replace(Consulta_sql, "#SUENDPEN#", Me.Entidad_Random.SUENDPEN)
                Consulta_sql = Replace(Consulta_sql, "#ACTECOBCO#", Me.Entidad_Random.ACTECOBCO)

                Consulta_sql = Replace(Consulta_sql, "#RUTALUN#", Me.Entidad_Random.RUTALUN)
                Consulta_sql = Replace(Consulta_sql, "#RUTAMAR#", Me.Entidad_Random.RUTAMAR)
                Consulta_sql = Replace(Consulta_sql, "#RUTAMIE#", Me.Entidad_Random.RUTAMIE)
                Consulta_sql = Replace(Consulta_sql, "#RUTAJUE#", Me.Entidad_Random.RUTAJUE)
                Consulta_sql = Replace(Consulta_sql, "#RUTAVIE#", Me.Entidad_Random.RUTAVIE)
                Consulta_sql = Replace(Consulta_sql, "#RUTASAB#", Me.Entidad_Random.RUTASAB)
                Consulta_sql = Replace(Consulta_sql, "#RUTADOM#", Me.Entidad_Random.RUTADOM)

                Consulta_sql = Replace(Consulta_sql, "#RECEPELECT#", Convert.ToInt32(Me.Entidad_Random.RECEPELECT))

                Dim _Fecnacen As String = "Null"
                If Me.Entidad_Random.FECNACEN.HasValue Then _Fecnacen = "'" & Format(Me.Entidad_Random.FECNACEN.Value, "yyyyMMdd") & "'"

                Consulta_sql = Replace(Consulta_sql, "#NACIONEN#", Me.Entidad_Random.NACIONEN)
                Consulta_sql = Replace(Consulta_sql, "#PROFECEN#", Me.Entidad_Random.PROFECEN)
                Consulta_sql = Replace(Consulta_sql, "#DIRPAREN#", Me.Entidad_Random.DIRPAREN)
                Consulta_sql = Replace(Consulta_sql, "'#FECNACEN#'", _Fecnacen)
                Consulta_sql = Replace(Consulta_sql, "#ESTCIVEN#", Me.Entidad_Random.ESTCIVEN)
                Consulta_sql = Replace(Consulta_sql, "#SEXOEN#", Me.Entidad_Random.SEXOEN)
                Consulta_sql = Replace(Consulta_sql, "#RELACIEN#", Me.Entidad_Random.RELACIEN)
                Consulta_sql = Replace(Consulta_sql, "#CONYUGEN#", Me.Entidad_Random.CONYUGEN)
                Consulta_sql = Replace(Consulta_sql, "#RUTCONEN#", Me.Entidad_Random.RUTCONEN)
                Consulta_sql = Replace(Consulta_sql, "#RUTSOCEN#", Me.Entidad_Random.RUTSOCEN)
                Consulta_sql = Replace(Consulta_sql, "#ANEXEN1#", Me.Entidad_Random.ANEXEN1)
                Consulta_sql = Replace(Consulta_sql, "#ANEXEN2#", Me.Entidad_Random.ANEXEN2)
                Consulta_sql = Replace(Consulta_sql, "#ANEXEN3#", Me.Entidad_Random.ANEXEN3)

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                ' -----------------------------------------------------------
                ' INSERTAR EN ZW_ENTIDADES
                ' -----------------------------------------------------------
                If _Zw_Entidades IsNot Nothing Then
                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Entidades Where CodEntidad = '" & Me.Entidad_Random.KOEN & "' And CodSucEntidad = '" & Me.Entidad_Random.SUEN & "'" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & Me.Entidad_Random.KOEN & "','" & Me.Entidad_Random.SUEN & "',0)" & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                               "Libera_NVV = " & Convert.ToInt32(_Zw_Entidades.Libera_NVV) & vbCrLf &
                               ",FacAuto = " & Convert.ToInt32(_Zw_Entidades.FacAuto) & vbCrLf &
                               ",RevFincred = " & Convert.ToInt32(_Zw_Entidades.RevFincred) & vbCrLf &
                               ",EmailCompras = '" & _Zw_Entidades.EmailCompras & "'" & vbCrLf &
                               ",MontoMinCompra = " & Replace(_Zw_Entidades.MontoMinCompra, ",", ".") & vbCrLf &
                               ",NoResMtoMinComAsCompraAuto = " & Convert.ToInt32(_Zw_Entidades.NoResMtoMinComAsCompraAuto) & vbCrLf &
                               ",CodHolding = '" & _Zw_Entidades.CodHolding & "'" & vbCrLf &
                               ",PreMayMinXHolding = " & Convert.ToInt32(_Zw_Entidades.PreMayMinXHolding) & vbCrLf &
                               ",CodPagador = '" & _Zw_Entidades.CodPagador & "'" & vbCrLf &
                               ",NoCobrarPallet = " & Convert.ToInt32(_Zw_Entidades.NoCobrarPallet) & vbCrLf &
                               ",ImpNoCobraVta = " & Convert.ToInt32(_Zw_Entidades.ImpNoCobraVta) & vbCrLf &
                               ",ImpNoCobraVtaStr = '" & _Zw_Entidades.ImpNoCobraVtaStr & "'" & vbCrLf &
                               ",NoUsaListasModalidad = " & Convert.ToInt32(_Zw_Entidades.NoUsaListasModalidad) & vbCrLf &
                               ",EsCiaSeguro = " & Convert.ToInt32(_Zw_Entidades.EsCiaSeguro) & vbCrLf &
                               ",Pais = '" & _Zw_Entidades.Pais & "'" & vbCrLf &
                               ",Ciudad = '" & _Zw_Entidades.Ciudad & "'" & vbCrLf &
                               ",Comuna = '" & _Zw_Entidades.Comuna & "'" & vbCrLf &
                               "Where CodEntidad = '" & Me.Entidad_Random.KOEN & "' And CodSucEntidad = '" & Me.Entidad_Random.SUEN & "'"

                    If _Zw_Entidades.JuntaPuntos Then
                        Consulta_sql += vbCrLf & "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                                   "JuntaPuntos = " & Convert.ToInt32(_Zw_Entidades.JuntaPuntos) & vbCrLf &
                                   ",EmailPuntos = '" & _Zw_Entidades.EmailPuntos & "'" & vbCrLf &
                                   ",CodFuncionario_Enrola = '" & _Zw_Entidades.CodFuncionario_Enrola & "'" & vbCrLf &
                                   "Where CodEntidad = '" & Me.Entidad_Random.KOEN & "' And CodSucEntidad = '" & Me.Entidad_Random.SUEN & "'"
                    End If

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()
                End If

                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

                ' =================================================================
                ' 3. RE-CARGAR ENTIDAD Y DEVOLVERLA DENTRO DEL TAG DEL MENSAJE
                ' =================================================================
                Dim _EntidadGuardada As Entidad_meli = Me.Fx_Trae_Maeen(Me.Entidad_Random.KOEN, Me.Entidad_Random.SUEN)
                If _EntidadGuardada IsNot Nothing Then
                    _EntidadGuardada.Entidad_Bakapp = Me.Fx_Trae_Zw_Entidades(Me.Entidad_Random.KOEN, Me.Entidad_Random.SUEN)
                End If

                _Msj.EsCorrecto = True
                _Msj.Mensaje = "Entidad creada correctamente."
                _Msj.Tag = _EntidadGuardada

                Return _Msj

            Catch ex As Exception
                myTrans.Rollback()
                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

                _Msj.EsCorrecto = False
                _Msj.Mensaje = "Error al crear la entidad."
                _Msj.Detalle = ex.Message
                Return _Msj
            End Try

        End Function

#End Region

#Region "Querys"
        Private Function Fx_Obtener_Query_Actualiza_MAEEN() As String
            Dim _Query = <Query>
Declare
@koen char(13),
@tien char(1),
@rten char(13),
@suen char(10),
@tiposuc char(1),
@nokoen varchar(50),
@sien char(15),
@gien varchar(100),
@paen char(3),
@cien char(3),
@cmen char(3),
@dien varchar(50),
@zoen char(3),
@foen varchar(20),
@faen varchar(20),
@cnen varchar(30),
@kofuen char(3),
@lcen char(8),
@lven char(8),
@crsd float,
@crch float,
@crlt float,
@crpa float,
@crto float,
@cren char(10),
@fevecren datetime,
@feultr datetime,
@nuvecr float,
@dccr float,
@incr float,
@popicr float,
@koplcr char(3),
@contab char(8),
@subauxi char(13),
@contabvta char(8),
@subauxivta char(13),
@codcc char(2),
@nutransmi char(13),
@ruen char(3),
@cpen varchar(40),
@oben varchar(100),
@diprve float,
@email varchar(50),
@cnen2 varchar(30),
@cobrador char(3),
@proteacum float,
@protevige float,
@cpostal varchar(25),
@habilita bit,
@codconve char(13),
@notraedeud bit,
@nokoenamp varchar(100),
@bloqueado bit,
@dimoper float,
@prefen bit,
@bloqencom bit,
@tipoen char(10),
@actien char(10),
@tamaen char(10),
@porprefen float,
@claveen char(10),
@nvvpidepie bit,
@recepelect bit,
@acteco char(10),
@diasvenci int,
@cattrib char(3),
@agretiva bit,
@agretiibb bit,
@agretgan bit,
@agperiva bit,
@agperiibb bit,
@transpoen char(10),
@fecreen datetime,
@firma varchar(25),
@moctaen char(3),
@ctasdelaen varchar(96),
@nacionen varchar(25),
@dirparen varchar(50),
@fecnacen datetime,
@estciven char(1),
@profecen varchar(25),
@conyugen varchar(50),
@rutconen varchar(10),
@rutsocen varchar(10),
@sexoen char(1),
@relacien char(1),
@anexen1 varchar(50),
@anexen2 varchar(50),
@anexen3 varchar(50),
@anexen4 varchar(50),
@occobli bit,
@valivenpag bit,
@emailcomer varchar(50),
@tipocontr char(1),
@ferefauto bit,
@diacobra char(7),
@cuentabco char(20),
@koendpen char(13),
@suendpen char(3),
@rutalun int,
@rutamar int,
@rutamie int,
@rutajue int,
@rutavie int,
@rutasab int,
@rutadom int,
@catlegret char(10),
@imptoret float,
@entiliga char(13),
@porceliga float,
@actecobco char(10)

Set @koen='#KOEN#'
Set @tien='#TIEN#'
Set @rten='#RTEN#'
Set @suen='#SUEN#'
Set @tiposuc='#TIPOSUC#'
Set @nokoen='#NOKOEN#'
Set @sien='#SIEN#'
Set @gien='#GIEN#'
Set @paen='#PAEN#'
Set @cien='#CIEN#'
Set @cmen='#CMEN#'
Set @dien='#DIEN#'
Set @zoen='#ZOEN#'
Set @foen='#FOEN#'
Set @faen='#FAEN#'
Set @cnen=''
Set @kofuen='#KOFUEN#'
Set @lcen='#LCEN#'
Set @lven='#LVEN#'
Set @crsd=#CRSD#
Set @crch=#CRCH#
Set @crlt=#CRLT#
Set @crpa=#CRPA#
Set @crto=#CRTO#
Set @cren=''
Set @fevecren='#FEVECREN#'
Set @feultr='#FEULTR#'
Set @nuvecr=#NUVECR#
Set @dccr=0
Set @incr=0
Set @popicr=#POPICR#
Set @koplcr=''
Set @contab=''
Set @subauxi=''
Set @contabvta=''
Set @subauxivta=''
Set @codcc=''
Set @nutransmi=''
Set @ruen='#RUEN#'
Set @cpen='#CPEN#'
Set @oben='#OBEN#'
Set @diprve=#DIPRVE#
Set @email='#EMAIL#'
Set @cnen2=''
Set @cobrador='#COBRADOR#'
Set @proteacum=0
Set @protevige=0
Set @cpostal='#CPOSTAL#'
Set @habilita=0
Set @codconve=''
Set @notraedeud=#NOTRAEDEUD#
Set @nokoenamp='#NOKOENAMP#'
Set @bloqueado=#BLOQUEADO#
Set @dimoper=#DIMOPER#
Set @prefen= #PREFEN#
Set @bloqencom=#BLOQENCOM#
Set @tipoen='#TIPOEN#'
Set @actien='#ACTIEN#'
Set @tamaen='#TAMAEN#'
Set @porprefen= 0
Set @claveen=''
Set @nvvpidepie= #NVVPIDEPIE#
Set @recepelect= #RECEPELECT#
Set @acteco=''
Set @diasvenci=#DIASVENCI#
Set @cattrib='RSI'
Set @agretiva= 0
Set @agretiibb= 0
Set @agretgan= 0
Set @agperiva= 0
Set @agperiibb= 0
Set @transpoen='#TRANSPOEN#'
Set @fecreen='#FECREEN#'
Set @firma=''
Set @moctaen='#MOCTAEN#'
Set @ctasdelaen=''
Set @nacionen='#NACIONEN#'
Set @dirparen='#DIRPAREN#'
Set @fecnacen='#FECNACEN#'
Set @estciven='#ESTCIVEN#'
Set @profecen='#PROFECEN#'
Set @conyugen='#CONYUGEN#'
Set @rutconen='#RUTCONEN#'
Set @rutsocen='#RUTSOCEN#'
Set @sexoen='#SEXOEN#'
Set @relacien='#RELACIEN#'
Set @anexen1='#ANEXEN1#'
Set @anexen2='#ANEXEN2#'
Set @anexen3='#ANEXEN3#'
Set @anexen4=''
Set @occobli= #OCCOBLI#
Set @valivenpag= 0
Set @emailcomer='#EMAILCOMER#'
Set @tipocontr=''
Set @ferefauto= #FEREFAUTO#
Set @diacobra='#DIACOBRA#'
Set @cuentabco='#CUENTABCO#'
Set @koendpen='#KOENDPEN#'
Set @suendpen='#SUENDPEN#'
Set @rutalun=#RUTALUN#
Set @rutamar=#RUTAMAR#
Set @rutamie=#RUTAMIE#
Set @rutajue=#RUTAJUE#
Set @rutavie=#RUTAVIE#
Set @rutasab=#RUTASAB#
Set @rutadom=#RUTADOM#
Set @catlegret=''
Set @imptoret=0
Set @entiliga=''
Set @porceliga=0
Set @actecobco='#ACTECOBCO#'

UPDATE MAEEN SET 
KOEN=@koen,
TIEN=@tien,
RTEN=@rten,
SUEN=@suen,
TIPOSUC=@tiposuc,
NOKOEN=@nokoen,
SIEN=@sien,
GIEN=@gien, 
PAEN=@paen, 
CIEN=@cien,
CMEN=@cmen,
DIEN=@dien,
ZOEN=@zoen,
FOEN=@foen,
FAEN=@faen,
CNEN=@cnen,
KOFUEN=@kofuen,
LCEN=@lcen,
LVEN=@lven,
CRSD=@crsd,
CRCH=@crch,
CRLT=@crlt,
CRPA=@crpa,
CRTO=@crto,
CREN=@cren,
FEVECREN=@fevecren,
FEULTR=@feultr,       
NUVECR=@nuvecr,
DCCR=@dccr,
INCR=@incr,
POPICR=@popicr,
KOPLCR=@koplcr,
CODCC=@codcc,
NUTRANSMI=@nutransmi,
RUEN=@ruen, 
CPEN=@cpen,
OBEN=@oben,
DIPRVE=@diprve,
EMAIL=@email,
CNEN2=@cnen2,
COBRADOR=@cobrador,
PROTEACUM=@proteacum,
PROTEVIGE=@protevige,
CPOSTAL=@cpostal,
HABILITA=@habilita,
CODCONVE=@codconve,
NOTRAEDEUD=@notraedeud,
NOKOENAMP=@nokoenamp,
BLOQUEADO=@bloqueado,
DIMOPER=@dimoper,
PREFEN=@prefen,
BLOQENCOM=@bloqencom,
TIPOEN=@tipoen,
ACTIEN=@actien,
TAMAEN=@tamaen,
PORPREFEN=@porprefen,
CLAVEEN=@claveen,
NVVPIDEPIE=@nvvpidepie,
RECEPELECT=@recepelect,
ACTECO=@acteco,
DIASVENCI=@diasvenci,
CATTRIB=@cattrib,
AGRETIVA=@agretiva,
AGRETIIBB=@agretiibb,
AGRETGAN=@agretgan,
AGPERIVA=@agperiva,
AGPERIIBB=@agperiibb,
TRANSPOEN=@transpoen,
FECREEN=@fecreen,
FIRMA=@firma,
MOCTAEN=@moctaen,
CTASDELAEN=@ctasdelaen,
NACIONEN=@nacionen,
DIRPAREN=@dirparen,
FECNACEN=@fecnacen,
ESTCIVEN=@estciven,
PROFECEN=@profecen,
CONYUGEN=@conyugen,
RUTCONEN=@rutconen,
RUTSOCEN=@rutsocen,
SEXOEN=@sexoen,
RELACIEN=@relacien,
ANEXEN1=@anexen1,
ANEXEN2=@anexen2,
ANEXEN3=@anexen3,
ANEXEN4=@anexen4,
OCCOBLI=@occobli,
VALIVENPAG=@valivenpag,
EMAILCOMER=@emailcomer,
TIPOCONTR=@tipocontr,
FEREFAUTO=@ferefauto,
DIACOBRA=@diacobra,
CUENTABCO=@cuentabco,
KOENDPEN=@koendpen,
SUENDPEN=@suendpen,
ACTECOBCO=@actecobco,
RUTALUN=@rutalun,
RUTAMAR=@rutamar,
RUTAMIE=@rutamie,
RUTAJUE=@rutajue,
RUTAVIE=@rutavie,
RUTASAB=@rutasab,
RUTADOM=@rutadom

WHERE KOEN=@koen AND SUEN=@suen
        </Query>

            Return _Query.Value
        End Function

        Private Function Fx_Obtener_Query_Inserta_MAEEN() As String
            Dim _Query = <Query>
INSERT INTO MAEEN (KOEN,TIEN,RTEN,SUEN,TIPOSUC,NOKOEN,SIEN,GIEN,PAEN,CIEN,CMEN,DIEN,ZOEN,FOEN,FAEN,CNEN,KOFUEN,LCEN,LVEN,CRSD,CRCH,CRLT,CRPA,CRTO,CREN,
FEVECREN,FEULTR,NUVECR,DCCR,INCR,POPICR,KOPLCR,CONTAB,SUBAUXI,CONTABVTA,SUBAUXIVTA,CODCC,NUTRANSMI,RUEN,CPEN,OBEN,DIPRVE,EMAIL,CNEN2,COBRADOR,PROTEACUM,
PROTEVIGE,CPOSTAL,HABILITA,CODCONVE,NOTRAEDEUD,NOKOENAMP,BLOQUEADO,DIMOPER,PREFEN,BLOQENCOM,TIPOEN,ACTIEN,TAMAEN,PORPREFEN,CLAVEEN,NVVPIDEPIE,RECEPELECT,
ACTECO,DIASVENCI,CATTRIB,AGRETIVA,AGRETIIBB,AGRETGAN,AGPERIVA,AGPERIIBB,TRANSPOEN,FECREEN,FIRMA,MOCTAEN,CTASDELAEN,NACIONEN,DIRPAREN,FECNACEN,ESTCIVEN,
PROFECEN,CONYUGEN,RUTCONEN,RUTSOCEN,SEXOEN,RELACIEN,ANEXEN1,ANEXEN2,ANEXEN3,ANEXEN4,OCCOBLI,VALIVENPAG,EMAILCOMER,TIPOCONTR,FEREFAUTO,DIACOBRA,CUENTABCO,
KOENDPEN,SUENDPEN,RUTALUN,RUTAMAR,RUTAMIE,RUTAJUE,RUTAVIE,RUTASAB,RUTADOM,CATLEGRET,IMPTORET,ENTILIGA,PORCELIGA,ACTECOBCO) 
VALUES 
( '#KOEN#','#TIEN#','#RTEN#','#SUEN#','','','','','','','','','','','','','','TABPP02C','TABPP01P',0.000000,0.000000,0.000000,0.000000,
0.000000,'',{d '2000-01-01'},NULL,0.000000,0.000000,0.000000,0.000000,'','','','','','','','','','',0.000000,'','','',0.000000,0.000000,'',0,
'',0,'',0,0.000000,0,0,'','','',0.000000,'',0,0,'',0.000000,'RSI',0,0,0,0,0,'',{d '2013-10-23'},'','$','','','',NULL,'','','','','','','','','','','',0,0,
'','',0,'','','','    ',0,0,0,0,0,0,0,'',0,'',0,'')
        </Query>

            Return _Query.Value
        End Function
#End Region

    End Class
