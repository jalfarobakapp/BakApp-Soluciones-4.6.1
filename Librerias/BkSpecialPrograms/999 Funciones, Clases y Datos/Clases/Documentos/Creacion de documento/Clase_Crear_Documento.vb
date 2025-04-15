Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Clase_Crear_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

#Region "VARIABLES ENCABEZADO"

    Public _Nudo As String 'NUDO
    Dim _Idmaeedo As Integer

    Dim _Empresa As String
    Dim _Sudo As String         ' Sucursal documento -SUDO

    Dim _Tido As String         ' Tipo de documento TIDO
    Dim _Endo As String         ' Codigo Entidad -ENDO
    Dim _Suendo As String       ' Sucursal Entidad -SUENDO
    Dim _Endofi As String
    Dim _Tigedo As String       ' Tipo de generacion del documento E o I, desde TABTIDO

    Dim _Feemdo As String       ' Fecha emisión - FEEMDO
    Dim _Kofudo As String       ' Responsable del documento
    Dim _Luvtdo As String      ' Centro de Costo

    Dim _Caprco As String       ' Cantidad total productos del documento
    Dim _Caprad As String       ' Cantidad despachada Encabezado 
    Dim _Caprex As String       ' Cantidad total de productos externamente documentada

    Dim _Meardo As String       ' Tipo Moneda del documento NETO o BRUTO
    Dim _Modo As String         ' Código moneda del documento
    Dim _Timodo As String       ' Tipo Moneda del documento: Nacional/Extranjera
    Dim _Tamodo As String       ' Valor de la moneda del documento "Dolar"
    Dim _Vaivdo As String       ' Iva 
    Dim _Vaimdo As String
    Dim _Vanedo As String       ' Neto
    Dim _Vabrdo As String       ' Bruto

    Dim _Fe01vedo As String     ' Fecha 1er Vencimiento Fecha_1er_Vencimiento 
    Dim _Feulvedo As String     ' Fecha Ultimo Vencimiento FEULVEDO FechaUltVencimiento

    Dim _Nuvedo As String       ' Numero de vencimientos
    Dim _Feer As String         ' Fecha esperada de recepcion --
    Dim _Subtido As String      ' AJU si es ajuste
    Dim _Marca As String        ' 1 si es ajuste
    Dim _Esdoimp As String      ' I si es importaciones, SUBTIDO = 'IMP'
    Dim _Lisactiva As String    ' Lista de precios del documento

    Dim _Libro As String        ' Numero de libro de compra
    Dim _Fecha_Tributaria As String ' Fecha Tributaria

    'TipoDoc
    'NroDocumento
    'Nombre_Entidad
    'Dias_1er_Vencimiento
    'Dias_Vencimiento
    'ListaPrecios
    'CodSucEntidadFisica
    'Nombre_Entidad_Fisica
    'Contacto_Ent
    'CodFuncionario
    'NomFuncionario
    'Centro_Costo
    'Moneda_Doc
    'Valor_Dolar
    'TotalNetoDoc
    'TotalIvaDoc
    'TotalIlaDoc
    'TotalBrutoDoc
    'CantTotal
    'CantDesp
    'DocEn_Neto_Bruto
    'TipoMoneda
#End Region

#Region "VARIABLES DETALLE DEL DOCUMENTO"

    Dim Id_Linea As Integer

    Dim _Archirst As String
    Dim _Idrst As String

    Dim _Nulido As String
    Dim _Bosulido As String
    Dim _Sulido As String
    Dim _Koprct As String
    Dim _Nokopr As String
    Dim _Rludpr As String
    Dim _Kofulido As String
    Dim _Udtrpr As Integer
    Dim _Ud01pr As String
    Dim _Ud02pr As String

    Dim _Caprco1 As String
    Dim _Caprco2 As String
    Dim _Caprad1 As String
    Dim _Caprad2 As String
    Dim _Caprex1 As String
    Dim _Caprex2 As String
    Dim _Caprnc1 As String
    Dim _Caprnc2 As String
    Dim _Cafaco As String

    Dim _Alternat As String

    Dim _Mopppr As String
    Dim _Timopppr As String
    Dim _Tamopppr As String

    Dim _Mgltpr As String

    Dim _Koltpr As String
    Dim _Tipr As String
    Dim _Prct As Boolean
    Dim _Tict As String
    Dim _Nudtli As Integer
    Dim _Nuimli As Integer

    Dim _HoraGrab As String

    Dim _Ppprnelt As String
    Dim _Ppprne As String
    Dim _Ppprbrlt As String
    Dim _Ppprbr As String
    Dim _Ppprnere1 As String
    Dim _Ppprnere2 As String
    Dim _Poimglli As String
    Dim _Vaimli As String
    Dim _Podtglli As String
    Dim _Vadtneli As String
    Dim _Vadtbrli As String
    Dim _Poivli As String
    Dim _Vaivli As String
    Dim _Vaneli As String
    Dim _Vabrli As String

    Dim _Tigeli As String

    Dim _Ppprpm As String
    Dim _Ppprmsuc As String
    Dim _Ppprpmifrs As String

    Dim _Feemli As String
    Dim _Feerli As String

    Dim _Operacion As String
    Dim _Potencia As String

    Dim _Eslido As String
    Dim _Lincondesp As Boolean
    Dim _Kofuaulido As String
    Dim _Observa As String

    Dim _Emprepa As String
    Dim _Tidopa As String
    Dim _Subtidopa As String
    Dim _Nudopa As String
    Dim _Endopa As String
    Dim _Nulidopa As String

    Dim _Luvtlido As String
    Dim _Proyecto As String
    Dim _Bodesti As String

    Dim _RtuVariable As Boolean

    Dim _Codmaq As String
    Dim _Nuliprod As String

    Dim _Customizable As Boolean
    Dim _PreVenta As Boolean

#End Region

#Region "VARIABLES PIE DEL DOCUMENTO,OBSERVACIONES"

    Dim _Obdo As String         ' Observacion al documento --
    Dim _Cpdo As String         ' Condiciones de pago del documento
    Dim _Diendesp As String     ' Dirección entidad de despacho 
    Dim _Ocdo As String         ' Orden de compra del documento
    Dim _Motivo As String       ' Motivo de nota de credito
    Dim Obs(34) As String       ' Textos del 1 al 35

#End Region

#Region "FUNCION CREAR DOCUMENTO RANDOM DEFINITIVO"

    Public Property Idmaeedo_Edit As Integer

    Function Fx_Crear_Documento(Tipo_de_documento As String,
                                ByRef Numero_de_documento As String,
                                _Es_ValeTransitorio As Boolean,
                                _Es_Documento_Electronico As Boolean,
                                Bd_Documento As DataSet,
                                Optional EsAjuste As Boolean = False,
                                Optional _Cambiar_NroDocumento As Boolean = True,
                                Optional ByRef _Origen_Modificado_Intertanto As Boolean = False,
                                Optional _Es_TLV As Boolean = False,
                                Optional _HoraAlFinalDelDia As Boolean = False) As LsValiciones.Mensajes

        'Optional _Tbl_Mevento_Edo As DataTable = Nothing,
        'Optional _Tbl_Mevento_Edd As DataTable = Nothing,
        'Optional _Tbl_Referencias_DTE As DataTable = Nothing) As Integer

        Dim _Mensaje As New LsValiciones.Mensajes


        If False Then
            Throw New System.Exception("An exception has occurred.")
        End If

        _Idmaeedo = 0

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Row_Encabezado As DataRow = Bd_Documento.Tables("Encabezado_Doc").Rows(0)
        Dim _Tbl_Detalle As DataTable = Bd_Documento.Tables("Detalle_Doc")

        Dim _Tbl_Mevento_Edo As DataTable = Bd_Documento.Tables("Mevento_Edo")
        Dim _Tbl_Mevento_Edd As DataTable = Bd_Documento.Tables("Mevento_Edd")
        Dim _Tbl_Referencias_DTE As DataTable = Bd_Documento.Tables("Referencias_DTE")

        Dim _Tbl_Maedcr As DataTable = Bd_Documento.Tables("Maedcr")

        Dim _Reserva_NroOCC As Boolean = _Row_Encabezado.Item("Reserva_NroOCC")
        Dim _Reserva_Idmaeedo As Integer = _Row_Encabezado.Item("Reserva_Idmaeedo")

        Dim _Items_RtuVariable As Integer

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Empresa = _Row_Encabezado.Item("EMPRESA")
        Dim _Eliminar_Idmaeedo_Origen As Boolean

        ' Se quita esto porque se repite el proceso mas abajo por producto

        'For Each _Row As DataRow In _Tbl_Detalle.Rows

        '    _Sulido = _Row.Item("Sucursal")
        '    _Koprct = _Row.Item("Codigo")

        '    _Row.Item("PmLinea") = _Sql.Fx_Trae_Dato("MAEPREM", "PM", "KOPR = '" & _Koprct & "' And EMPRESA = '" & _Empresa & "'", True)
        '    _Row.Item("PmSucLinea") = _Sql.Fx_Trae_Dato("MAEPMSUC", "PMSUC", "KOPR = '" & _Koprct & "' AND EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sulido & "'", True)
        '    _Row.Item("PmIFRS") = _Sql.Fx_Trae_Dato("MAEPREM", "PMIFRS", "EMPRESA = '" & _Empresa & "' And KOPR = '" & _Koprct & "'", True)

        'Next

        Dim _DesdeProduccion As Boolean
        Dim _Filtro_Idmaeddo_Dori As String = Generar_Filtro_IN(_Tbl_Detalle, "", "Idmaeddo_Dori", 1, False, "")
        Dim _Tbl_Maeddo_Dori As DataTable

        For Each _Fl As DataRow In _Tbl_Detalle.Rows
            If _Fl.Item("Tidopa") = "OTL" Then
                _Filtro_Idmaeddo_Dori = "()"
                _DesdeProduccion = True
                Exit For
            End If
        Next

        If _Filtro_Idmaeddo_Dori <> "()" Then

            Consulta_sql = "Select IDMAEDDO,TIDO,KOPRCT,ESLIDO,
                            CAPRCO1-CAPREX1 AS 'CantUd1_Dori',CAPRCO2-CAPREX2 AS 'CantUd2_Dori',
                            CASE WHEN TIDO In ('GRD','NCV') THEN CAPRCO1-CAPREX1 ELSE (CAPRAD1+CAPREX1)-CAPRNC1 END AS 'CantUd1_Dori_Ncv',
	                        CASE WHEN TIDO In ('GRD','NCV') THEN CAPRCO2-CAPREX2 ELSE (CAPRAD2+CAPREX2)-CAPRNC2 END AS 'CantUd2_Dori_Ncv'
                            From MAEDDO Where IDMAEDDO In " & _Filtro_Idmaeddo_Dori
            _Tbl_Maeddo_Dori = _Sql.Fx_Get_DataTable(Consulta_sql)

        End If


        Dim Fl As String = Generar_Filtro_IN(_Tbl_Detalle, "", "Idmaeedo_Dori", False, False, "")

        If Fl = "()" Then Fl = "(0)"

        Consulta_sql = "SELECT DISTINCT IDMAEEDO,TIDO FROM MAEDDO WHERE IDMAEEDO IN " & Fl
        Dim _TblOrigen As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try

            With _Row_Encabezado

                Dim _Modalidad As String = .Item("Modalidad")
                _Tido = .Item("TipoDoc")
                _Subtido = .Item("Subtido")

                If _Es_TLV And _Tido = "BLV" Then

                    _Cambiar_NroDocumento = False
                    Numero_de_documento = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = 'BLV' And NUDO Like 'TLV%'")

                    If Numero_de_documento = 0 Then
                        Numero_de_documento = "TLV0000001"
                    Else
                        Numero_de_documento = _Sql.Fx_Trae_Dato("MAEEDO", "COALESCE(MAX(NUDO),'0000000000')",
                                                                "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO Like 'TLV%'")
                        Numero_de_documento = Fx_Proximo_NroDocumento(Numero_de_documento, 10)
                    End If

                    .Item("Subtido") = "TJV"
                    _Subtido = "TJV"

                Else

                    If _Cambiar_NroDocumento And Not _Reserva_NroOCC Then
                        Numero_de_documento = Traer_Numero_Documento(_Tido, .Item("NroDocumento"), _Modalidad)
                    Else
                        Numero_de_documento = .Item("NroDocumento")
                    End If

                End If

                If _Es_Documento_Electronico Then

                    If _Tido = "BLV" Or _Tido = "FCV" Or _Tido = "NCV" Or _Tido = "GDV" Or _Tido = "GDP" Or _Tido = "GTI" Or _Tido = "GDD" Then

                        If Not _Es_ValeTransitorio Then

                            Dim _Msj As New LsValiciones.Mensajes

                            _Msj = Fx_Revisar_Expiracion_Folio_SII(Nothing, _Tido, Numero_de_documento, False)

                            If Not _Msj.EsCorrecto Then 'Not Fx_Revisar_Expiracion_Folio_SII(_Formulario, _Tido, _Nudo, True) Then
                                Throw New System.Exception("El folio del documento electrónico (" & Numero_de_documento & ") ya expiró en el SII." & vbCrLf &
                                                       "Informe al administrador del sistema")
                            End If

                        End If

                    End If

                End If

                If String.IsNullOrEmpty(Numero_de_documento) Then
                    Throw New System.Exception("El folio del documento NO puede estar vacío")
                End If

                .Item("NroDocumento") = Numero_de_documento
                _Nudo = .Item("NroDocumento")

                If String.IsNullOrEmpty(Trim(_Nudo)) Then
                    Throw New System.Exception("El número de documento no puede estar vacío")
                End If

                For Each _Fila As DataRow In _Tbl_Referencias_DTE.Rows
                    _Fila.Item("Tido") = _Tido
                    _Fila.Item("Nudo") = _Nudo
                Next

                _Empresa = .Item("Empresa")
                _Sudo = .Item("Sucursal")
                _Kofudo = .Item("CodFuncionario")
                _Endo = .Item("CodEntidad")
                _Suendo = .Item("CodSucEntidad")
                _Feemdo = Format(.Item("FechaEmision"), "yyyyMMdd")
                _Lisactiva = .Item("ListaPrecios")
                _Caprco = De_Num_a_Tx_01(.Item("CantTotal"), False, 5)
                _Caprad = 0 ' De_Num_a_Tx_01(.Item("CantDesp"), False, 5)
                _Luvtdo = .Item("Centro_Costo")
                _Modo = .Item("Moneda_Doc")
                _Meardo = .Item("DocEn_Neto_Bruto")
                _Tamodo = De_Num_a_Tx_01(.Item("Valor_Dolar"), False, 5)
                _Timodo = .Item("TipoMoneda")

                _Bodesti = .Item("Bodega_Destino")

                Dim _Vanedo_2 = .Item("TotalNetoDoc")
                Dim _Vaivdo_2 = .Item("TotalIvaDoc")
                Dim _Vaimdo_2 = .Item("TotalIlaDoc")
                Dim _Vabrdo_2 = .Item("TotalBrutoDoc")

                _Vanedo = De_Num_a_Tx_01(.Item("TotalNetoDoc"), False, 5)
                _Vaivdo = De_Num_a_Tx_01(.Item("TotalIvaDoc"), False, 5)
                _Vaimdo = De_Num_a_Tx_01(.Item("TotalIlaDoc"), False, 5)
                _Vabrdo = De_Num_a_Tx_01(.Item("TotalBrutoDoc"), False, 5)

                _Fe01vedo = Format(.Item("Fecha_1er_Vencimiento"), "yyyyMMdd")
                _Feulvedo = Format(.Item("FechaUltVencimiento"), "yyyyMMdd")

                _Feer = Format(.Item("FechaRecepcion"), "yyyyMMdd")
                '_Feerli = Format(.Item("FechaRecepcion"), "yyyyMMdd")

                _Libro = .Item("Libro")
                _Fecha_Tributaria = .Item("Fecha_Tributaria")

                If String.IsNullOrEmpty(_Fecha_Tributaria) Then
                    _Fecha_Tributaria = "FECHATRIB = NULL"
                Else
                    _Fecha_Tributaria = "FECHATRIB = '" & _Fecha_Tributaria & "'"
                End If

                '------------------------------------------------------------------------------------------------------------

                _Customizable = NuloPorNro(.Item("Customizable"), False)
                _PreVenta = NuloPorNro(.Item("PreVenta"), False)

            End With

            Consulta_sql = "Select Top 1 * From TABTIDO Where TIDO = '" & _Tido & "'"
            Dim _Row_Tabtido As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Signo = String.Empty
            Dim _Fiad As Integer = _Row_Tabtido.Item("FIAD")
            Dim _Fico As Integer = _Row_Tabtido.Item("FICO")
            _Tigedo = _Row_Tabtido.Item("TIGEDO")

            If CBool(_Fico) Then

                If _Fico = 1 Then
                    _Signo = "+"
                ElseIf _Fico = -1 Then
                    _Signo = "-"
                End If

                _Lincondesp = True

            Else

                If _Fiad = 1 Then
                    _Signo = "+"
                ElseIf _Fiad = -1 Then
                    _Signo = "-"
                Else
                    _Lincondesp = False
                End If

            End If

            myTrans = cn2.BeginTransaction()


            If Not _Cambiar_NroDocumento And _Tido = "COV" Then

                Dim _Idmaeedo_Origen As Integer = _Row_Encabezado.Item("Idmaeedo_Origen")
                Dim _NudoRandom As String

                Dim random As New Random()
                _NudoRandom = Rellenar(random.Next(1000, 10000), 10, "x", False)

                Consulta_sql = "Update MAEEDO Set NUDO = '" & _NudoRandom & "' WHERE IDMAEEDO = " & _Idmaeedo_Origen
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                _Eliminar_Idmaeedo_Origen = True

            End If


            Consulta_sql = "INSERT INTO MAEEDO ( EMPRESA,TIDO,NUDO,ENDO,SUENDO )" & vbCrLf &
                           "VALUES ( '" & _Empresa & "','" & _Tido & "','" & _Nudo &
                           "','" & _Endo & "','" & _Suendo & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            If _Cambiar_NroDocumento Then

                Dim _Modalidad = _Row_Encabezado.Item("Modalidad")

                Consulta_sql = Fx_Cambiar_Numeracion_Modalidad(_Tido, _Nudo, _Modalidad)

                If Not String.IsNullOrEmpty(Consulta_sql) Then

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

            End If

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idmaeedo = dfd1("Identity")
            End While
            dfd1.Close()

            Bd_Documento.Tables("Detalle_Doc").Dispose()

            Dim Contador As Integer = 1

            For Each FDetalle As DataRow In _Tbl_Detalle.Rows

                Dim Estado As DataRowState = FDetalle.RowState

                Consulta_sql = String.Empty

                If Not Estado = DataRowState.Deleted Then

                    With FDetalle

                        Id_Linea = .Item("Id")

                        _Nulido = numero_(Contador, 5)

                        _Sulido = .Item("Sucursal")
                        _Bosulido = .Item("Bodega")
                        _Koprct = .Item("Codigo")
                        _Nokopr = .Item("Descripcion")
                        _Rludpr = De_Num_a_Tx_01(.Item("Rtu"), False, 5)
                        _Kofulido = .Item("CodFuncionario") 'FUNCIONARIO ' Codigo de funcionario
                        _Tict = .Item("Tict")
                        _Prct = .Item("Prct")
                        _Caprco1 = De_Num_a_Tx_01(.Item("CantUd1"), False, 5) ' Cantidad de la primera unidad
                        _Caprco2 = De_Num_a_Tx_01(.Item("CantUd2"), False, 5) ' Cantidad de la segunda unidad
                        _Tipr = .Item("Tipr")
                        _Lincondesp = .Item("Lincondest")

                        'If _Prct Then _Lincondesp = True

                        If _Koprct = "CORT56816" Then
                            Dim AA = 0
                        End If

                        _Tidopa = .Item("Tidopa")

                        If _Lincondesp And Not _Tidopa.Contains("G") Then

                            If _Tido = "GRI" Or (_Tido = "GDI" And _Subtido = "") Then

                                _Caprad1 = _Caprco1 ' Cantidad que mueve Stock Fisico, según el producto.
                                _Caprad2 = _Caprco2 ' Cantidad que mueve Stock Fisico, según el producto.

                            Else

                                If Not CBool(_Fico) Then
                                    _Caprad1 = _Caprco1 ' Cantidad que mueve Stock Fisico, según el producto.
                                    _Caprad2 = _Caprco2 ' Cantidad que mueve Stock Fisico, según el producto.
                                Else
                                    _Caprad1 = 0
                                    _Caprad2 = 0
                                End If

                                If _Fico = 0 And _Fiad = 0 Then
                                    _Caprad1 = 0
                                    _Caprad2 = 0
                                End If

                            End If

                        Else

                            If CBool(_Fiad) Then

                                If Not _Tido.Contains("N") Then ' Si no es Nota de credito

                                    If _Tipr = "SSN" Then

                                        .Item("CDespUd1") = .Item("CantUd1")
                                        .Item("CDespUd2") = .Item("CantUd2")
                                        .Item("Estado") = "C"

                                    End If

                                End If

                            End If

                            _Caprad1 = De_Num_a_Tx_01(NuloPorNro(.Item("CDespUd1"), 0), False, 5) ' Cantidad que mueve Stock Fisico, según el producto.
                            _Caprad2 = De_Num_a_Tx_01(NuloPorNro(.Item("CDespUd2"), 0), False, 5) ' Cantidad que mueve Stock Fisico, según el producto.

                        End If

                        If EsAjuste Then
                            _Eslido = "C"
                        Else

                            _Eslido = NuloPorNro(.Item("Estado"), "")

                            If String.IsNullOrEmpty(_Eslido) Then

                                Select Case _Tido
                                    Case "BLV", "FCV", "FCC", "GRI", "GDI"
                                        If _Caprad1 = _Caprco1 Then
                                            _Eslido = "C"
                                        End If
                                End Select

                            End If

                        End If

                        _Caprex1 = 0 ' Cantidad  
                        _Caprex2 = 0
                        _Caprnc1 = 0 ' Cantidad de Nota de Credito
                        _Caprnc2 = 0

                        _Udtrpr = .Item("UnTrans")  ' Unidad de la transaccion
                        _Ud01pr = .Item("Ud01PR")
                        _Ud02pr = .Item("Ud02PR")
                        _Koltpr = .Item("CodLista") 'LISTADEPRECIO
                        _Mopppr = .Item("Moneda") 'trae_dato(tb, cn1, "KOMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                        _Timopppr = .Item("Tipo_Moneda") 'trae_dato(tb, cn1, "TIMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                        _Tamopppr = De_Num_a_Tx_01(.Item("Tipo_Cambio"), False, 5) 'De_Num_a_Tx_01(trae_dato(tb, cn1, "VAMO", "TABMO", "NOKOMO LIKE '%PESO%'"), False, 5)
                        _Ppprnelt = De_Num_a_Tx_01(.Item("PrecioNetoUd"), False, 5)
                        _Podtglli = De_Num_a_Tx_01(.Item("DescuentoPorc"), False, 5)
                        _Poimglli = De_Num_a_Tx_01(.Item("PorIla"), False, 5)

                        _Operacion = NuloPorNro(.Item("Operacion"), "")
                        _Potencia = De_Num_a_Tx_01(.Item("Potencia"), False, 5)

                        Dim Campo As String = "Precio"

                        _Ppprne = De_Num_a_Tx_01(.Item("PrecioNetoUd"), False, 5)
                        _Ppprbr = De_Num_a_Tx_01(.Item("PrecioBrutoUd"), False, 5)
                        _Ppprnelt = De_Num_a_Tx_01(NuloPorNro(Of Double)(.Item("PrecioNetoUdLista"), 0), False, 5)
                        _Ppprbrlt = De_Num_a_Tx_01(.Item("PrecioBrutoUdLista"), False, 0) ' PRECIO BRUTO DE LA LISTA

                        _Poivli = De_Num_a_Tx_01(.Item("PorIva"), True)
                        _Nudtli = De_Num_a_Tx_01(.Item("NroDscto"), True)

                        _Nuimli = De_Num_a_Tx_01(.Item("NroImpuestos"), True)

                        _Vadtneli = De_Num_a_Tx_01(.Item("DsctoNeto"), False, 5)
                        _Vadtbrli = De_Num_a_Tx_01(.Item("DsctoBruto"), False, 5)

                        _Vaneli = De_Num_a_Tx_01(.Item("ValNetoLinea"), False, 5)
                        _Vaimli = De_Num_a_Tx_01(.Item("ValIlaLinea"), False, 5)
                        _Vaivli = De_Num_a_Tx_01(.Item("ValIvaLinea"), False, 5)
                        _Vabrli = De_Num_a_Tx_01(Math.Round(.Item("ValBrutoLinea"), 5), False, 5)

                        _Feemli = Format(.Item("FechaEmision"), "yyyyMMdd")
                        _Feerli = Format(NuloPorNro(.Item("FechaRecepcion"), _Row_Encabezado.Item("FechaRecepcion")), "yyyyMMdd")

                        _Kofuaulido = Replace(NuloPorNro(.Item("CodFunAutoriza"), ""), "xyz", "")
                        _Observa = NuloPorNro(.Item("Observa"), "")

                        _Luvtlido = .Item("Centro_Costo")
                        _Proyecto = .Item("Proyecto")

                        _Ppprnere1 = De_Num_a_Tx_01(NuloPorNro(.Item("PrecioNetoRealUd1"), 0), False, 5)
                        _Ppprnere2 = De_Num_a_Tx_01(NuloPorNro(.Item("PrecioNetoRealUd2"), 0), False, 5)

                        ' Costos del producto, solo deberia ser efectivo en las ventas
                        _Ppprpm = De_Num_a_Tx_01(NuloPorNro(.Item("PmLinea"), 0), False, 5)
                        _Ppprmsuc = De_Num_a_Tx_01(NuloPorNro(.Item("PmSucLinea"), 0), False, 5)
                        _Ppprpmifrs = De_Num_a_Tx_01(NuloPorNro(.Item("PmIFRS"), 0), False, 5)

                        _Idrst = Val(NuloPorNro(.Item("Idmaeddo_Dori"), ""))
                        _Tigeli = "I"

                        _RtuVariable = .Item("RtuVariable")

                        If _RtuVariable Or .Item("Nmarca") = "¡" Then
                            _Items_RtuVariable += 1
                        End If

                        Dim _MgltprD As Double

                        _Mgltpr = _Sql.Fx_Trae_Dato("TABPRE", "MG0" & _Udtrpr & "UD", "KOLT = '" & _Koltpr & "' And KOPR = '" & _Koprct & "'", True, False, 0)
                        _Mgltpr = De_Num_a_Tx_01(_MgltprD, False, 5)

                        Dim _Tasadorig = De_Num_a_Tx_01(NuloPorNro(.Item("Tasadorig"), 0), False, 5)

                        _Cafaco = 0

                        _Alternat = NuloPorNro(.Item("CodigoProv"), "")

                        Dim _TipoValor As String = NuloPorNro(.Item("TipoValor"), "")

                        If _Prct Then ' ES CONCEPTO

                            If Not String.IsNullOrEmpty(Trim(_Tict)) Then

                                Dim TipoValor = _TipoValor

                                _Caprco2 = 0
                                _Caprad2 = 0
                                _Cafaco = 0
                                _Ppprnelt = 0
                                _Ppprne = 0
                                _Ppprbrlt = 0
                                _Ppprbr = 0
                                _Prct = 1
                                _Ppprpm = 0
                                _Ppprmsuc = 0
                                _Ppprpmifrs = 0
                                _Lincondesp = False
                                _Nudtli = 0
                                _Eslido = String.Empty

                            End If

                        Else

                            If _Tido = "FCC" Then

                                Consulta_sql = "Update MAEPR Set PPUL01 = " & _Ppprnere1 & ",PPUL02 = " & _Ppprnere2 & " Where KOPR = '" & _Koprct & "'" & vbCrLf &
                                               "Update MAEPREM Set PPUL01 = " & _Ppprnere1 & ",PPUL02 = " & _Ppprnere2 & " Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Koprct & "'"
                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                            ' *** RECALCULO DEL PPP

                            '-- DOCINTPPP -  Doc.recep.int afecta PPP
                            '-- EXCLUGRI  -  Excluir GRI por traslado
                            '-- GRPAFEPPP -  GRP se considera para calculo
                            '-- TRANAFEPPP - St en transito interno suma para ppp

                            Dim _RecalcularPPP As Boolean = False

                            Dim _Docintppp As Boolean = _Global_Row_Configp.Item("DOCINTPPP")
                            Dim _Excluri As Boolean = _Global_Row_Configp.Item("EXCLUGRI")
                            Dim _Grpafeppp As Boolean = _Global_Row_Configp.Item("GRPAFEPPP")
                            Dim _Tranafeppp As Boolean = _Global_Row_Configp.Item("TRANAFEPPP")

                            If (_Tido = "GRC") Then _RecalcularPPP = True
                            If (_Docintppp And _Tido = "GRI" And _Tidopa <> "GTI" And _Excluri) Then _RecalcularPPP = True
                            If (_Docintppp And _Tido = "GRI" And _Tidopa = "GTI" And Not _Excluri) Then _RecalcularPPP = True
                            If (_Tido = "FCC" And _Lincondesp) Then _RecalcularPPP = True
                            If (_Tido = "BLC" And _Lincondesp) Then _RecalcularPPP = True
                            If (_Tido = "GDD" And _Subtido = String.Empty) Then _RecalcularPPP = True
                            If (_Tido = "GRP" And _Grpafeppp) Then _RecalcularPPP = True

                            If _RecalcularPPP Then

                                Consulta_sql = "Insert Into MAEPMSUC (EMPRESA,KOSU,KOPR,STFI1,STFI2,PMSUC,FEPMSUC) 
                                                Select '" & _Empresa & "','" & _Sulido & "','" & _Koprct & "',0,0,0,Getdate() 
                                                From MAEPR Where KOPR Not In (Select KOPR From MAEPMSUC" & Space(1) &
                                                "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sulido & "' And KOPR = '" & _Koprct & "')" & vbCrLf &
                                                "And KOPR = '" & _Koprct & "'"
                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                Consulta_sql = "Select Mp.EMPRESA,Mp.KOPR,Isnull(PM,0) As PM,Isnull(PMIFRS,0) As PMIFRS,Isnull(Ms.PMSUC,0) As PMSUC,
                                                Mp.STFI1,Mp.STTR1,Isnull(Ms.STFI1,0) As STFI1_Suc
                                                From MAEPREM Mp
                                                Left Join MAEPMSUC Ms On Mp.EMPRESA = Ms.EMPRESA And Ms.KOSU = '" & _Sulido & "' And Mp.KOPR = Ms.KOPR
                                                Where Mp.EMPRESA = '" & ModEmpresa & "' And Mp.KOPR = '" & _Koprct & "'"

                                Comando = New SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                dfd1 = Comando.ExecuteReader()

                                Dim _Stfi1 As Double
                                Dim _Sttr1 As Double
                                Dim _Stfi1_Suc As Double
                                Dim _Pm As Double
                                Dim _Pmifrs As Double
                                Dim _Pmsuc As Double
                                Dim _Total_Stfi_x_Pm As Double
                                Dim _Total_Stfi_x_Pmifrs As Double
                                Dim _Total_Stfi_x_Pmsuc As Double
                                Dim _Vaneli_Val As Double = De_Txt_a_Num_01(_Vaneli, 5)
                                Dim _Caprco1_Val As Double = De_Txt_a_Num_01(_Caprco1, 5)
                                Dim _Caprco2_Val As Double = De_Txt_a_Num_01(_Caprco2, 5)

                                While dfd1.Read()
                                    _Pm = dfd1("PM")
                                    _Pmifrs = dfd1("PMIFRS")
                                    _Pmsuc = dfd1("PMSUC")
                                    _Stfi1 = dfd1("STFI1")
                                    _Sttr1 = dfd1("STTR1")
                                    _Stfi1_Suc = dfd1("STFI1_Suc")
                                End While
                                dfd1.Close()

                                If Not _Tranafeppp Then _Sttr1 = 0

                                _Total_Stfi_x_Pm = _Pm * (_Stfi1 + _Sttr1)
                                _Total_Stfi_x_Pmifrs = _Pmifrs * (_Stfi1 + _Sttr1)
                                _Total_Stfi_x_Pmsuc = _Pmsuc * _Stfi1_Suc

                                Dim _Sum_Stock As Double = _Stfi1 + _Sttr1 + _Caprco1_Val

                                If CBool(_Sum_Stock) Then
                                    _Pm = (_Vaneli_Val + _Total_Stfi_x_Pm) / _Sum_Stock
                                    _Pmifrs = (_Vaneli_Val + _Total_Stfi_x_Pmifrs) / _Sum_Stock
                                    _Pmsuc = (_Vaneli_Val + _Total_Stfi_x_Pmsuc) / (_Stfi1_Suc + _Caprco1_Val)
                                Else
                                    _Pm = 0
                                    _Pmifrs = 0
                                    _Pmsuc = 0
                                End If

                                _Ppprpm = De_Num_a_Tx_01(_Pm, False, 5)
                                _Ppprpmifrs = De_Num_a_Tx_01(_Pmifrs, False, 5)
                                _Ppprmsuc = De_Num_a_Tx_01(_Pmsuc, False, 5)

                                If _Ppprmsuc.Contains("∞") Or _Ppprmsuc.Contains("NaN") Then
                                    _Ppprmsuc = 0
                                End If

                                If _Koprct = "CORT56816" Then
                                    Dim A = 0
                                End If

                                Consulta_sql = "UPDATE MAEPREM SET PM = " & _Ppprpm & ",PMIFRS = " & _Ppprpmifrs & vbCrLf & Space(1) &
                                               "WHERE EMPRESA='" & _Empresa & "' AND KOPR='" & _Koprct & "'" & vbCrLf &
                                               "UPDATE MAEPR SET PM = " & _Ppprpm & ",PMIFRS = " & _Ppprpmifrs & vbCrLf & Space(1) &
                                               "WHERE KOPR='" & _Koprct & "'" & vbCrLf &
                                               "UPDATE MAEPMSUC SET STFI1 = STFI1+" & _Caprco1 &
                                                                  ",STFI2 = STFI2+" & _Caprco2 &
                                                                  ",PMSUC = " & _Ppprmsuc & Space(1) &
                                               "WHERE EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sulido & "' AND KOPR='" & _Koprct & "'"

                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                'Throw New System.Exception("An exception has occurred.")

                            End If

                            '**************************************************************************************************

                            If _Lincondesp And Not _Tidopa.Contains("G") Or _Tido = "GRI" Then

                                Consulta_sql = "Insert Into MAEST (EMPRESA,KOSU,KOBO,KOPR)" & vbCrLf &
                                           "Select '" & _Empresa & "','" & _Sulido & "','" & _Bosulido & "','" & _Koprct & "'" & vbCrLf &
                                           "From MAEPR" & vbCrLf &
                                           "Where KOPR Not In (Select KOPR From MAEST" & Space(1) &
                                           "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sulido & "' And KOBO = '" & _Bosulido & "' And" & Space(1) &
                                           "KOPR = '" & _Koprct & "') And KOPR = '" & _Koprct & "'"
                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                                Consulta_sql = "UPDATE MAEPREM SET" & vbCrLf &
                                           "STFI1 = STFI1 " & _Signo & " " & _Caprco1 & ",STFI2 = STFI2 " & _Signo & " " & _Caprco2 & vbCrLf &
                                           "WHERE EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Koprct & "'" &
                                           vbCrLf &
                                           vbCrLf &
                                           "UPDATE MAEPR SET  STFI1 = STFI1 " & _Signo & " " & _Caprco1 & ",STFI2 = STFI2 " & _Signo & " " & _Caprco2 & vbCrLf &
                                           "WHERE KOPR = '" & _Koprct & "'" &
                                           vbCrLf &
                                           vbCrLf &
                                           "UPDATE MAEST SET STFI1 = STFI1 " & _Signo & " " & _Caprco1 & ",STFI2 = STFI2 " & _Signo & " " & _Caprco2 & vbCrLf &
                                           "WHERE EMPRESA='" & _Empresa & "' AND KOSU='" & _Sulido &
                                           "' AND KOBO='" & _Bosulido & "' AND KOPR='" & _Koprct & "'" &
                                           vbCrLf &
                                           vbCrLf &
                                           "UPDATE MAEPMSUC SET STFI1 = STFI1 " & _Signo & " 1,STFI2 = STFI2 " & _Signo & " 1" & vbCrLf &
                                           "WHERE EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sulido & "' AND KOPR = '" & _Koprct & "'"

                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            Else

                                If _Tipr <> "SSN" Then

                                    _Caprad1 = 0
                                    _Caprad2 = 0

                                End If

                            End If

                        End If

                        'EMPREPA,TIDOPA,NUDOPA,ENDOPA,NULIDOPA

                        Dim _CantStockAdUd1 = _Caprco1
                        Dim _CantStockAdUd2 = _Caprco2

                        _Emprepa = String.Empty
                        If _Tidopa <> "OTL" Then _Tidopa = String.Empty
                        _Subtidopa = String.Empty
                        _Nudopa = String.Empty
                        _Endopa = String.Empty
                        _Nulidopa = String.Empty


                        If CBool(_Idrst) Then

                            _CantStockAdUd1 = "0"
                            _CantStockAdUd2 = "0"

                            Consulta_sql = "Select Top 1 Ddo.*,Edo.SUBTIDO From MAEDDO Ddo" & vbCrLf &
                                           "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                                           "Where IDMAEDDO = " & _Idrst

                            Dim _Row_Doc_Origen As DataRow

                            If _Tidopa = "OTL" Then

                                If _Tido = "GRI" Then

                                    Consulta_sql = "Select *,'" & _Endo & "' As ENDO,'OTL' As TIDO,NUMOT As NUDO,NREG As NULIDO,'' As SUBTIDO," &
                                               "Isnull((Select Top 1 OPERACION From POTPR Where POTPR.IDPOTL = POTL.IDPOTL Order By ORDEN Desc),'') As OPERACION" & vbCrLf &
                                               "From POTL Where IDPOTL = " & _Idrst
                                End If

                                If _Tido = "GDI" Then

                                    Consulta_sql = "Select *,'" & _Endo & "' As ENDO,'OTL' As TIDO,NUMOT As NUDO,NREG As NULIDO,'' As SUBTIDO" & vbCrLf &
                                                   "From POTD Where IDPOTD = " & _Idrst

                                End If

                                .Item("CantUd1_Dori") = .Item("CantUd1")
                                .Item("CantUd2_Dori") = .Item("CantUd2")

                                _Caprad1 = 0
                                _Caprad2 = 0

                            End If

                            _Row_Doc_Origen = _Sql.Fx_Get_DataRow(Consulta_sql)

                            _Emprepa = _Row_Doc_Origen.Item("EMPRESA")
                            _Tidopa = _Row_Doc_Origen.Item("TIDO")
                            _Subtidopa = _Row_Doc_Origen.Item("SUBTIDO")
                            _Nudopa = _Row_Doc_Origen.Item("NUDO")
                            _Endopa = _Row_Doc_Origen.Item("ENDO")
                            _Nulidopa = _Row_Doc_Origen.Item("NULIDO")

                            Dim _Caprnc1_Ori As Double
                            Dim _Caprnc2_Ori As Double
                            Dim _Caprex1_Ori As Double
                            Dim _Caprex2_Ori As Double

                            If _Tidopa <> "OTL" Then

                                _Caprnc1_Ori = _Row_Doc_Origen.Item("CAPRNC1")
                                _Caprnc2_Ori = _Row_Doc_Origen.Item("CAPRNC2")
                                _Caprex1_Ori = _Row_Doc_Origen.Item("CAPREX1")
                                _Caprex2_Ori = _Row_Doc_Origen.Item("CAPREX2")

                            End If

                            Dim _CantUd1_Dori As Double = .Item("CantUd1_Dori")
                            Dim _CantUd2_Dori As Double = .Item("CantUd2_Dori")

                            Dim _CantUd1 As Double = .Item("CantUd1")
                            Dim _CantUd2 As Double = .Item("CantUd2")

                            If _CantUd1_Dori < _CantUd1 Or _Tidopa = "OTL" Then

                                If _Tido = "NCV" And Not _Tidopa.Contains("G") Then
                                    _Caprnc1 = De_Num_a_Tx_01(_CantUd1_Dori, False, 5)
                                    _Caprnc2 = De_Num_a_Tx_01(_CantUd2_Dori, False, 5)
                                Else
                                    _Caprex1 = De_Num_a_Tx_01(_CantUd1_Dori, False, 5)
                                    _Caprex2 = De_Num_a_Tx_01(_CantUd2_Dori, False, 5)
                                End If

                            Else

                                If (_Tido = "NCV" And Not _Tidopa.Contains("G")) Or (_Tido = "GDD" And _Subtido = String.Empty) Or
                                   (_Tido = "GRD" And _Tidopa = "FCV") Or (_Tido = "GRD" And _Tidopa = "BLV") Then

                                    _Caprnc1 = De_Num_a_Tx_01(_CantUd1, False, 5)
                                    _Caprnc2 = De_Num_a_Tx_01(_CantUd2, False, 5)

                                    If _Lincondesp Then _Eslido = "C"

                                    If (_Tido = "GDD" And _Subtido = String.Empty) Then _Eslido = String.Empty
                                    If (_Tido = "GRD" And _Subtido = String.Empty) Then _Eslido = String.Empty

                                Else

                                    If Not (_Tido = "GDD" And _Subtido = String.Empty) Then
                                        _Caprex1 = De_Num_a_Tx_01(_CantUd1, False, 5)
                                        _Caprex2 = De_Num_a_Tx_01(_CantUd2, False, 5)
                                        _Eslido = "C"
                                    End If

                                End If

                            End If

                            _Archirst = "MAEDDO"
                            _Tigeli = "E"

                            If _Tidopa = "OTL" Then

                                _Operacion = _Row_Doc_Origen.Item("OPERACION")

                                If _Tido = "GRI" Then

                                    Consulta_sql = "Update POTL Set REALIZADO = REALIZADO + (" & _Caprex1 & "),PORENTRAR = PORENTRAR - (" & _Caprex1 & ") WHERE IDPOTL = " & _Idrst
                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                    Consulta_sql = "Update POTL Set INFORABODE = CASE WHEN PORENTRAR - (" & _Caprex1 & ") < 0 THEN 'I' WHEN PORENTRAR-(" & _Caprex1 & ") > 0 THEN 'P'  ELSE ' ' END WHERE IDPOTL=" & _Idrst
                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                    _Archirst = "POTL"

                                End If

                                If _Tido = "GDI" Then

                                    _Archirst = "POTD"
                                    _Tidopa = "OTD"

                                    _Codmaq = _Sql.Fx_Trae_Dato("POPER", "CODMAQ", "OPERACION = '" & _Operacion & "'")
                                    _Nuliprod = _Row_Doc_Origen.Item("SUBNREG")

                                    Consulta_sql = "Update POTD SET CANTIDADR = CANTIDADR + (" & _Caprex1 & ") Where IDPOTD = " & _Idrst
                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                End If

                            End If

                            If (CBool(_Fiad) And _Tido.Contains("N") And Not _Tidopa.Contains("G")) Or
                            (_Tido = "GDD" And _Subtido = String.Empty) Or
                            (_Tido = "GRD" And _Tidopa <> "NCV") Then
                                '_Tido = "NCC" Or _Tido = "NCV" Then

                                Consulta_sql = "UPDATE MAEDDO SET CAPRNC1=CAPRNC1+" & _Caprnc1 &
                                                                ",CAPRNC2=CAPRNC2+" & _Caprnc2 & "," &
                                               "ESLIDO = " & vbCrLf &
                                               "CASE" & vbCrLf &
                                               "WHEN UDTRPR='1' AND CAPRCO1-CAPRAD1-CAPREX1=0 THEN 'C'" & vbCrLf &
                                               "WHEN UDTRPR='2' AND CAPRCO2-CAPRAD2-CAPREX2=0 THEN 'C'" & vbCrLf &
                                               "ELSE ''" & vbCrLf &
                                               "END" & vbCrLf &
                                               "WHERE IDMAEDDO = " & _Idrst

                                Comando = New SqlCommand("SELECT Sum(CAPRNC1) AS 'CAPRNC1',Sum(CAPRNC2) AS 'CAPRNC2'  From MAEDDO Where IDMAEDDO = " & _Idrst, cn2)
                                Comando.Transaction = myTrans
                                dfd1 = Comando.ExecuteReader()

                                While dfd1.Read()
                                    _Caprnc1 = dfd1("CAPRNC1")
                                    _Caprnc2 = dfd1("CAPRNC2")
                                End While
                                dfd1.Close()

                            Else

                                Consulta_sql = "UPDATE MAEDDO SET CAPREX1=CAPREX1+" & _Caprex1 &
                                                                    ",CAPREX2=CAPREX2+" & _Caprex2 & "," &
                                                   "ESLIDO = " &
                                                   "CASE" & vbCrLf &
                                                   "WHEN UDTRPR='1' AND " &
                                                   "ROUND(CAPRCO1-CAPRAD1-(CAPREX1+" & _Caprex1 & "),5)=0 THEN 'C'" & vbCrLf &
                                                   "WHEN UDTRPR='2' AND " &
                                                   "ROUND(CAPRCO2-CAPRAD2-(CAPREX2+" & _Caprex2 & "),5)=0 THEN 'C'" & vbCrLf &
                                                   "Else ''" & vbCrLf &
                                                   "End" & vbCrLf &
                                                   "WHERE IDMAEDDO = " & _Idrst


                            End If

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                        If (_Tido = "GDD" And _Subtido = String.Empty) Then
                            _Caprnc1 = 0
                            _Caprnc2 = 0
                        End If


                        Dim _Campo_StockUd1 As String
                        Dim _Campo_StockUd2 As String

                        Dim _Campos_StockAd_Tido As New List(Of String)
                        Dim _Campos_StockAd_Tidopa As New List(Of String)

                        If Not _Prct And _Tipr <> "SSN" Then

                            _Campos_StockAd_Tido = Fx_Campo_Mov_Stock_Adicional_Suma(_Tido, _Subtido, _Lincondesp, _Tidopa)
                            _Campos_StockAd_Tidopa = Fx_Campo_Mov_Stock_Adicional_Resta(_Tido, _Tidopa)

                            ' ACA SE AUMENTAN LOS STOCK CORRESPONDINTE AL DOCUMENTO DE SALIDA O DE INGRESO

                            If CBool(_Campos_StockAd_Tido.Count) Then

                                _Campo_StockUd1 = _Campos_StockAd_Tido(0)
                                _Campo_StockUd2 = _Campos_StockAd_Tido(1)

                                Consulta_sql = "UPDATE MAEST SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " +" & _Caprco1 & "," &
                                                             _Campo_StockUd2 & " = " & _Campo_StockUd2 & " + " & _Caprco2 & vbCrLf &
                                                           "WHERE EMPRESA='" & _Empresa &
                                                           "' AND KOSU='" & _Sulido &
                                                           "' AND KOBO='" & _Bosulido &
                                                           "' AND KOPR='" & _Koprct & "'" & vbCrLf &
                                           "UPDATE MAEPREM SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " +" & _Caprco1 & "," &
                                                           _Campo_StockUd2 & " = " & _Campo_StockUd2 & " + " & _Caprco2 & vbCrLf &
                                                           "WHERE EMPRESA='" & _Empresa &
                                                           "' AND KOPR='" & _Koprct & "'" & vbCrLf &
                                           "UPDATE MAEPR SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " +" & _Caprco1 & "," &
                                                           _Campo_StockUd2 & " = " & _Campo_StockUd2 & " + " & _Caprco2 & vbCrLf &
                                                           "WHERE KOPR='" & _Koprct & "'"

                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                            ' ACA SE DESCUENTAN LOS STOCK CORRESPONDINTE AL DOCUMENTO DE SALIDA O DE INGRESO CUANDO EL DOCUMENTO
                            ' TIENE UNA RELACION

                            If CBool(_Campos_StockAd_Tidopa.Count) Then

                                _Campo_StockUd1 = _Campos_StockAd_Tidopa(0)
                                _Campo_StockUd2 = _Campos_StockAd_Tidopa(1)

                                Dim _Succ = _Sulido
                                Dim _Bodd = _Bosulido

                                If _Tido = "GRI" And CBool(_Idrst) Then
                                    If _Campo_StockUd1 = "STTR1" Then
                                        Comando = New SqlCommand("SELECT SULIDO,BOSULIDO From MAEDDO Where IDMAEDDO = " & _Idrst, cn2)
                                        Comando.Transaction = myTrans
                                        dfd1 = Comando.ExecuteReader()
                                        While dfd1.Read()
                                            _Succ = dfd1("SULIDO")
                                            _Bodd = dfd1("BOSULIDO")
                                        End While
                                        dfd1.Close()
                                    End If
                                End If

                                Consulta_sql = "UPDATE MAEST SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " -" & _Caprco1 & "," &
                                                             _Campo_StockUd2 & " = " & _Campo_StockUd2 & " - " & _Caprco2 & vbCrLf &
                                                           "WHERE EMPRESA='" & _Empresa &
                                                           "' AND KOSU='" & _Succ &
                                                           "' AND KOBO='" & _Bodd &
                                                           "' AND KOPR='" & _Koprct & "'" & vbCrLf &
                                           "UPDATE MAEPREM SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " -" & _Caprco1 & "," &
                                                           _Campo_StockUd2 & " = " & _Campo_StockUd2 & " - " & _Caprco2 & vbCrLf &
                                                           "WHERE EMPRESA='" & _Empresa &
                                                           "' AND KOPR='" & _Koprct & "'" & vbCrLf &
                                           "UPDATE MAEPR SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " -" & _Caprco1 & "," &
                                                           _Campo_StockUd2 & " = " & _Campo_StockUd2 & " - " & _Caprco2 & vbCrLf &
                                                           "WHERE KOPR='" & _Koprct & "'"

                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                        End If

                        If _Tido = "BLV" Or _Tido = "FCV" Or _Tido = "FCC" Or _Tido = "OCC" Or _Tido = "NVV" Or _Tido = "GDV" Or _Tido = "GRC" Or _Tido = "GTI" Then

                            If _Tidopa = "COV" Or _Tidopa = "NVV" Or _Tidopa = "OCC" Or _Tidopa = "OCI" Or _Tidopa = "NVI" Or _Tido = "GTI" Then

                                _Caprex1 = 0
                                _Caprex2 = 0

                                _Eslido = String.Empty

                                Select Case _Tido
                                    Case "BLV", "FCV", "FCC"
                                        If _Caprad1 = _Caprco1 Then
                                            _Eslido = "C"
                                        End If
                                End Select

                            End If

                        End If

                        If _Tidopa = "COV" And _Tido <> "NVV" Then

                            _Emprepa = String.Empty
                            _Tidopa = String.Empty
                            _Subtidopa = String.Empty
                            _Nudopa = String.Empty
                            _Endopa = String.Empty
                            _Nulidopa = String.Empty
                            _Tigeli = "I"

                        End If

                        _Caprex = De_Num_a_Tx_01(Val(_Caprex1) + Val(_Caprex), False, 5)
                        _Caprad = De_Num_a_Tx_01(Val(_Caprad1) + Val(_Caprad), False, 5)

                        _Kofuaulido = String.Empty

                        _Nokopr = Replace(_Nokopr, "'", "''")

                        Dim _Ppoppr As String = "0"

                        If _Tido = "NVI" Or _Tido = "GRI" Or _Tido = "GDI" Then
                            _Ppoppr = _Ppprpm
                        End If

                        Dim _ExisteProducto As Boolean

                        If _Prct Then
                            Consulta_sql = "Select * From TABCT Where KOCT = '" & _Koprct & "'"
                        Else
                            Consulta_sql = "SELECT * From MAEPR Where KOPR = '" & _Koprct & "'"
                        End If

                        Comando = New SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        dfd1 = Comando.ExecuteReader()

                        While dfd1.Read()
                            _ExisteProducto = True
                        End While

                        dfd1.Close()

                        If Not _ExisteProducto Then
                            If _Prct Then
                                Throw New System.Exception("No se encontro el concepto: " & _Koprct.Trim & " - " & _Nokopr.Trim & vbCrLf &
                                                           "En la tabla TABCT")
                            Else
                                Throw New System.Exception("No se encontro el producto: " & _Koprct.Trim & " - " & _Nokopr.Trim & vbCrLf &
                                                           "En la tabla MAEPR")
                            End If
                        End If

                        If _Tido = "GRI" AndAlso _DesdeProduccion Then
                            _Ppprnelt = _Ppprne
                            _Ppprbrlt = _Ppprbr
                        End If

                        Consulta_sql =
                              "INSERT INTO MAEDDO (IDMAEEDO,ARCHIRST,IDRST,EMPRESA,TIDO,NUDO,ENDO,SUENDO,LILG,NULIDO," & vbCrLf &
                              "SULIDO,BOSULIDO,LUVTLIDO,PROYECTO,KOFULIDO,TIPR,TICT,PRCT,KOPRCT,UDTRPR,RLUDPR,CAPRCO1," & vbCrLf &
                              "UD01PR,CAPRCO2,UD02PR,CAPRAD1,CAPRAD2,CAPREX1,CAPREX2,CAPRNC1,CAPRNC2,KOLTPR,MOPPPR,TIMOPPPR,TAMOPPPR,NUIMLI,NUDTLI," & vbCrLf &
                              "PODTGLLI,POIMGLLI,VAIMLI,VADTNELI,VADTBRLI,POIVLI,VAIVLI,VANELI,VABRLI,TIGELI," & vbCrLf &
                              "EMPREPA,TIDOPA,NUDOPA,ENDOPA,NULIDOPA," & vbCrLf &
                              "FEEMLI,FEERLI,PPPRNELT,PPPRNE,PPPRBRLT,PPPRBR,PPPRPM,PPPRNERE1,PPPRNERE2,CAFACO," & vbCrLf &
                              "FVENLOTE,FCRELOTE,NOKOPR,ALTERNAT,TASADORIG,CUOGASDIF,LINCONDESP,OPERACION,POTENCIA," & vbCrLf &
                              "ESLIDO,OBSERVA,KOFUAULIDO,HUMEDAD,PPOPPR,MGLTPR,CODMAQ,NULIPROD)" & vbCrLf &
                       "VALUES (" & _Idmaeedo & ",'" & _Archirst & "'," & _Idrst & ",'" & _Empresa & "','" & _Tido & "','" & _Nudo & "','" & _Endo &
                              "','" & _Suendo & "','SI','" & _Nulido & "','" & _Sulido & "','" & _Bosulido &
                              "','" & _Luvtlido & "','" & _Proyecto & "','" & _Kofulido & "','" & _Tipr & "','" & _Tict & "'," & CInt(_Prct) & ",'" & _Koprct &
                              "'," & _Udtrpr & "," & _Rludpr & "," & _Caprco1 & ",'" & _Ud01pr & "'," & _Caprco2 &
                              ",'" & _Ud02pr & "'," & _Caprad1 & "," & _Caprad2 & "," & _Caprex1 & "," & _Caprex2 & "," & _Caprnc1 & "," & _Caprnc1 &
                              ",'TABPP" & _Koltpr & "'" &
                              ",'" & _Mopppr & "','" & _Timopppr & "'," & _Tamopppr &
                              "," & _Nuimli & "," & _Nudtli & "," & _Podtglli & "," & _Poimglli & "," & _Vaimli &
                              "," & _Vadtneli & "," & _Vadtbrli & "," & _Poivli & "," & _Vaivli & "," & _Vaneli &
                              "," & _Vabrli & ",'" & _Tigeli & "'," &
                              "'" & _Emprepa & "','" & _Tidopa & "','" & _Nudopa & "','" & _Endopa & "','" & _Nulidopa & "'," &
                              "'" & _Feemli & "','" & _Feerli & "'," & _Ppprnelt & "," & _Ppprne &
                              "," & _Ppprbrlt & "," & _Ppprbr & "," & _Ppprpm & "," & _Ppprnere1 & "," & _Ppprnere2 &
                              "," & _Cafaco & ",NULL,NULL,'" & _Nokopr & "','" & _Alternat & "'," & _Tasadorig & ",0," & CInt(_Lincondesp) * -1 &
                              ",'" & _Operacion & "'," & _Potencia & ",'" & _Eslido & "','" & _Observa & "'," &
                              "'" & _Kofuaulido & "',0," & _Ppoppr & "," & _Mgltpr & ",'" & _Codmaq & "','" & _Nuliprod & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()


                        Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                        Comando.Transaction = myTrans
                        dfd1 = Comando.ExecuteReader()
                        Dim _Idmaeddo As Integer
                        While dfd1.Read()
                            _Idmaeddo = dfd1("Identity")
                        End While
                        dfd1.Close()


                        If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Docu_Det") Then

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Det (Idmaeddo,Idmaeedo,Tido,Nudo,Codigo,Descripcion,RtuVariable) Values " &
                                           "(" & _Idmaeddo & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Koprct & "','" & _Nokopr & "'," & Convert.ToInt32(_RtuVariable) & ")"
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If


                        If _Tidopa = "OTL" Then

                            Consulta_sql = "Update MAEDDO Set PPOPPR = 0,COSTOTRIB = VANELI,COSTOIFRS = VANELI,TAMOPPPR = 0,TASADORIG = 0" & vbCrLf &
                                           "Where IDMAEDDO = " & _Idmaeddo
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If


                        ' **** Insertamos datos en tabla de disribucion de recargos

                        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Maedcr, "Id = " & Id_Linea, "Id")

                        For Each _Fldcr As DataRow In _Tbl.Rows

                            Dim _Recarcalcu = _Fldcr.Item("Recarcalcu")
                            Dim _Idddodcr = _Fldcr.Item("Idddodcr")
                            Dim _Valdcr = De_Num_a_Tx_01(_Fldcr.Item("Valdcr"), False, True)

                            Consulta_sql = "Insert Into MAEDCR (IDMAEEDO,NULIDO,RECARCALCU,IDDDODCR,VALDCR) VALUES " &
                                           "(" & _Idmaeedo & ",'" & _Nulido & "','" & _Koprct & "'," & _Idddodcr & "," & _Valdcr & ")"

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        Next

                        ' *** LINEAS CON OFERTAS EN NVV

                        Dim _Id_Oferta = .Item("Id")
                        Dim _Es_Padre_Oferta = Convert.ToInt32(.Item("Es_Padre_Oferta"))
                        Dim _Oferta = .Item("Oferta")
                        Dim _Padre_Oferta = .Item("Padre_Oferta")
                        Dim _Hijo_Oferta = .Item("Hijo_Oferta")
                        Dim _Aplica_Oferta = .Item("Aplica_Oferta")
                        Dim _Cantidad_Oferta = De_Num_a_Tx_01(.Item("Cantidad_Oferta"), False, 5)
                        Dim _Porcdesc_Oferta = De_Num_a_Tx_01(.Item("Porcdesc_Oferta"), False, 5)

                        If _Aplica_Oferta Then

                            If _Tido = "COV" Or _Tido = "NVV" Then

                                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Linea_Oferta " &
                                               "(Idmaeedo,Tido,Nudo,Idmaeddo,Nulido,Id_Oferta,Es_Padre_Oferta,Oferta,Padre_Oferta,Hijo_Oferta,Cantidad_Oferta,Porcdesc_Oferta) Values " &
                                               "(" & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "'," & _Idmaeddo &
                                               ",'" & _Nulido & "'," & _Id_Oferta & "," & _Es_Padre_Oferta & ",'" & _Oferta & "'," & _Padre_Oferta &
                                               "," & _Hijo_Oferta & "," & _Cantidad_Oferta & "," & _Porcdesc_Oferta & ")"

                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                        End If

                        '******


                        ' *** PM POR SUCURSAL SI ES QUE EXISTE EL CAMPO
                        'Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                        '                                               "COLUMN_NAME LIKE 'PPPRPMSUC' AND TABLE_NAME = 'MAEDDO'")

                        'If CBool(_Reg) Then

                        If _Sql.Fx_Exite_Campo("MAEDDO", "PPPRPMSUC") Then

                            Consulta_sql = "UPDATE MAEDDO SET PPPRPMSUC = " & _Ppprmsuc & vbCrLf &
                                           "WHERE IDMAEDDO = " & _Idmaeddo

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If
                        '*************************************************************************************************

                        ' *** PMIFRS SI ES QUE EXISTE EL CAMPO
                        '_Reg = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                        '                                "COLUMN_NAME LIKE 'PMIFRS' AND TABLE_NAME = 'MAEPREM'")

                        'If CBool(_Reg) Then

                        If _Sql.Fx_Exite_Campo("MAEPREM", "PMIFRS") Then

                            Consulta_sql = "UPDATE MAEDDO SET PPPRPMIFRS = " & _Ppprpmifrs & vbCrLf &
                                           "WHERE IDMAEDDO=" & _Idmaeddo

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                        '*************************************************************************************************

                        If _Sql.Fx_Exite_Campo("MAEDDO", "FEERLIMODI") Then

                            Consulta_sql = "UPDATE MAEDDO SET FEERLIMODI = '" & _Feerli & "'" & vbCrLf &
                                           "WHERE IDMAEDDO=" & _Idmaeddo

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                        ' SERVICIO TECNICO BAKAPP *************************************************************************************************

                        Dim _Id_OtSvr As Integer = .Item("Id_OtSvr")
                        Dim _Semilla_Svr As Integer = .Item("Semilla_Svr")

                        If CBool(_Id_OtSvr) And CBool(_Semilla_Svr) Then

                            Consulta_sql = "Update  " & _Global_BaseBk & "Zw_St_OT_DetProd Set Idmaeedo_Cov = " & _Idmaeedo & ", Idmaeddo_Cov = " & _Idmaeddo & vbCrLf &
                                           "Where Id_Ot = " & _Id_OtSvr & " And Semilla = " & _Semilla_Svr

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End With


                    ' TABLA DE IMPUESTOS

                    Dim Tbl_Impuestos As DataTable = Bd_Documento.Tables("Impuestos_Doc")

                    If Val(_Nuimli) > 0 And String.IsNullOrEmpty(Trim(_Tict)) Then

                        For Each FImpto As DataRow In Tbl_Impuestos.Rows 'Select("Id = " & Id_Linea)

                            Dim _Estado As DataRowState = FImpto.RowState

                            If Not _Estado = DataRowState.Deleted Then

                                Dim _Id = FImpto.Item("Id")

                                If _Id = Id_Linea Then

                                    Dim _Poimli As String = De_Num_a_Tx_01(FImpto.Item("Poimli").ToString, False, 5)
                                    Dim _Koimli As String = FImpto.Item("Koimli").ToString
                                    Dim _Vaimli = De_Num_a_Tx_01(FImpto.Item("Vaimli").ToString, False, 5)

                                    Consulta_sql = "INSERT INTO MAEIMLI(IDMAEEDO,NULIDO,KOIMLI,POIMLI,VAIMLI,LILG) VALUES " & vbCrLf &
                                                   "(" & _Idmaeedo & ",'" & _Nulido & "','" & _Koimli & "'," & _Poimli & "," & _Vaimli & ",'')"

                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                End If

                            End If

                            '-- 3RA TRANSACCION--------------------------------------------------------------------
                        Next

                    End If



                    ' TABLA DE DESCUENTOS
                    Dim Tbl_Descuentos As DataTable = Bd_Documento.Tables("Descuentos_Doc")
                    _Nudtli = Tbl_Descuentos.Rows.Count

                    If Val(_Nudtli) > 0 And String.IsNullOrEmpty(Trim(_Tict)) Then

                        For Each FDscto As DataRow In Tbl_Descuentos.Rows 'Tbl_Descuentos.Select("Id = " & Id_Linea)

                            Dim _Estado As DataRowState = FDscto.RowState

                            If Not _Estado = DataRowState.Deleted Then

                                Dim _Id = FDscto.Item("Id")

                                If _Id = Id_Linea Then

                                    Dim _Podt = De_Num_a_Tx_01(FDscto.Item("Podt").ToString, False, 5)
                                    Dim _Vadt = De_Num_a_Tx_01(FDscto.Item("Vadt").ToString, False, 5)

                                    Consulta_sql = "INSERT INTO MAEDTLI (IDMAEEDO,NULIDO,KODT,PODT,VADT)
                                                Values (" & _Idmaeedo & ",'" & _Nulido & "','D_SIN_TIPO'," & _Podt & "," & _Vadt & ")"


                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                End If

                            End If

                            '-- 4TA TRANSACCION--------------------------------------------------------------------
                        Next

                    End If

                    Contador += 1

                End If

            Next



            'TABLA DE VENCIMIENTOS

            Consulta_sql = String.Empty

            Consulta_sql = Fx_Vencimientos(_Row_Encabezado)

            If Not String.IsNullOrEmpty(Consulta_sql) Then

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            If _Nuvedo = 0 Then _Nuvedo = 1

            'Dim _HoraGrab As String

            'Dim _HH_sistem As Date

            '_HH_sistem = FechaDelServidor()
            '_HoraGrab = _HH_sistem.Hour

            'Dim _HH, _MM, _SS As Double

            '_HH = _HH_sistem.Hour
            '_MM = _HH_sistem.Minute
            '_SS = _HH_sistem.Second

            _Esdoimp = String.Empty

            If EsAjuste Then
                _Marca = "I" '1 ' Generalmente se marcan las GRI o GDI que son por ajuste
                _Subtido = "AJU" ' Generalmente se Marcan las Guias de despacho o recibo
                _Suendo = String.Empty
            Else
                _Marca = String.Empty
                If _Subtido = "IMP" Then
                    _Marca = "I"
                    _Esdoimp = "I"
                End If
            End If

            If _Tido = "GDV" And Not _Es_Documento_Electronico Then

                For Each _Fila As DataRow In _Tbl_Detalle.Rows

                    Dim _Feemdo2 As Date = FormatDateTime(_Row_Encabezado.Item("FechaEmision"), DateFormat.ShortDate)
                    Dim _Feemli2 As Date = FormatDateTime(_Fila.Item("FechaEmision"), DateFormat.ShortDate)

                    If _Feemdo2 > _Feemli2 Then
                        _HoraAlFinalDelDia = True
                    Else
                        _HoraAlFinalDelDia = False
                    End If

                Next

            End If

            _HoraGrab = Hora_Grab_fx(_HoraAlFinalDelDia) 'Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

            'Consulta_sql = "Declare @HoraGrab Int" & vbCrLf & _
            '               "set @HoraGrab = convert(money,substring(convert(varchar(20),getdate(),114),1,2)) * 3600 +" & vbCrLf & _
            '               "convert(money,substring(convert(varchar(20),getdate(),114),4,2)) * 60 + " & vbCrLf & _
            '               "Convert(money, substring(Convert(varchar(20), getdate(), 114), 7, 2))" & vbCrLf & vbCrLf & _

            Dim _Espgdo As String

            Select Case _Tido
                Case "COV", "GAR", "GDD", "GDI", "GDP", "GDV", "GRC", "GRD", "GRI", "GRP", "GTI", "NVV", "OCC", "NVI", "OCI"
                    _Espgdo = "S"
                Case Else
                    _Espgdo = "P"
            End Select

            Dim _Despacho = 2

            Select Case _Tido
                Case "GDV", "GTI", "GDD", "GRI", "GDI", "GDP", "NVI", "GRC"
                    _Despacho = 1
            End Select

            ' HAY QUE PONER EL CAMPO TIPO DE MONEDA  "TIMODO"
            Consulta_sql = "UPDATE MAEEDO SET SUENDO='" & _Suendo & "',TIGEDO='" & _Tigedo & "',SUDO='" & _Sudo &
                           "',FEEMDO='" & _Feemdo & "',KOFUDO='" & _Kofudo & "',ESPGDO='" & _Espgdo & "',CAPRCO=" & _Caprco &
                           ",CAPRAD=" & _Caprad & ",CAPREX=" & _Caprex & ",MEARDO = '" & _Meardo & "',MODO = '" & _Modo &
                           "',TIMODO = '" & _Timodo & "',TAMODO = " & _Tamodo & ",VAIVDO = " & _Vaivdo & ",VAIMDO = " & _Vaimdo & vbCrLf &
                           ",VANEDO = " & _Vanedo & ",VABRDO = " & _Vabrdo & ",FE01VEDO = '" & _Fe01vedo &
                           "',FEULVEDO = '" & _Feulvedo & "',NUVEDO = " & _Nuvedo & ",FEER = '" & _Feer &
                           "',KOTU = '1',LCLV = NULL,LAHORA = GETDATE(), DESPACHO = " & _Despacho & ",HORAGRAB = " & _HoraGrab &
                           "," & _Fecha_Tributaria & ",NUMOPERVEN = 0,FLIQUIFCV = '" & _Feemdo & "',SUBTIDO = '" & _Subtido &
                           "',MARCA = '" & _Marca & "',ESDOIMP = '" & _Esdoimp & "',ESDO = '',NUDONODEFI = " & CInt(_Es_ValeTransitorio) &
                           ",TIDOELEC = " & CInt(_Es_Documento_Electronico) & ",LUVTDO = '" & _Luvtdo &
                           "',LIBRO = '" & _Libro & "',BODESTI = '" & _Bodesti & "',CUOGASDIF = 0" & vbCrLf &
                           "WHERE IDMAEEDO=" & _Idmaeedo

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            Consulta_sql = "UPDATE MAEEDO SET ESDO = CASE WHEN ROUND(CAPRCO-CAPRAD-CAPREX,5)=0 THEN 'C' ELSE '' END WHERE IDMAEEDO = " & _Idmaeedo

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            'Comando = New SqlCommand("SELECT ESDO From MAEEDO Where IDMAEEDO = " & _Idmaeedo, cn2)
            'Comando.Transaction = myTrans
            'dfd1 = Comando.ExecuteReader()

            'Dim _Esdo As String

            'While dfd1.Read()
            '    _Esdo = dfd1("ESDO").ToString.Trim
            'End While
            'dfd1.Close()

            'If String.IsNullOrEmpty(_Esdo) Then

            '    Comando = New SqlCommand("SELECT ESLIDO,CAPRCO1,CAPREX1,CAPRAD1 FROM MAEDDO Where IDMAEEDO = " & _Idmaeedo, cn2)
            '    Comando.Transaction = myTrans
            '    dfd1 = Comando.ExecuteReader()

            '    Dim _Cuenta_Eslido = 0

            '    While dfd1.Read()
            '        _Eslido = dfd1("ESLIDO")
            '        If _Eslido = "C" Then _Cuenta_Eslido += 1
            '    End While
            '    dfd1.Close()

            '    If _Cuenta_Eslido = _Tbl_Detalle.Rows.Count Then

            '        Consulta_sql = "UPDATE MAEEDO SET ESDO = 'C' WHERE IDMAEEDO = " & _Idmaeedo

            '        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            '        Comando.Transaction = myTrans
            '        Comando.ExecuteNonQuery()

            '    End If

            'End If

            Dim Reg As Integer = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                                         "COLUMN_NAME LIKE 'LISACTIVA' AND TABLE_NAME = 'MAEEDO'")

            If CBool(Reg) Then

                Consulta_sql = "UPDATE MAEEDO SET LISACTIVA = 'TABPP" & _Lisactiva & "'" & vbCrLf &
                               "WHERE IDMAEEDO=" & _Idmaeedo

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            '========================================== CERRAR DOCUMENTOS ASOCIADOS ============================================


            If _Filtro_Idmaeddo_Dori <> "()" Then

                If Not IsNothing(_Tbl_Maeddo_Dori) Then

                    For Each _Fila As DataRow In _Tbl_Detalle.Rows

                        Dim _Estado As DataRowState = _Fila.RowState

                        If Not _Estado = DataRowState.Deleted Then

                            Dim _Idmaeddo_Dori = _Fila.Item("Idmaeddo_Dori")
                            Dim _Row_Dori

                            _Row_Dori = _Tbl_Maeddo_Dori.Select("IDMAEDDO = " & _Idmaeddo_Dori)

                            If CBool(_Idmaeddo_Dori) Then

                                Dim _CantUd1 As Double = _Fila.Item("CantUd1_Dori")
                                Dim _CantUd2 As Double = _Fila.Item("CantUd2_Dori")
                                Dim _CantUd1_Dori As Double = _Row_Dori(0).Item("CantUd1_Dori")
                                Dim _CantUd2_Dori As Double = _Row_Dori(0).Item("CantUd2_Dori")
                                Dim _CantUd1_Dori_Ncv As Double = _Row_Dori(0).Item("CantUd1_Dori_Ncv")
                                Dim _CantUd2_Dori_Ncv As Double = _Row_Dori(0).Item("CantUd2_Dori_Ncv")
                                Dim _Eslido_Dori As String = _Row_Dori(0).Item("ESLIDO")

                                If Not IsNothing(_Row_Dori) Then

                                    If _Tido = "NCV" Or _Tido = "GRD" Or (_Tido = "GDD" And _Subtido = String.Empty) Then

                                        If _CantUd1 <> _CantUd1_Dori_Ncv Or _CantUd2 <> _CantUd2_Dori_Ncv Then

                                            _Origen_Modificado_Intertanto = True
                                            Throw New System.Exception("Alguno de los documentos de origen fueron modificados en el intertanto")

                                        End If

                                    Else

                                        If _CantUd1 <> _CantUd1_Dori Or _CantUd2 <> _CantUd2_Dori Or _Eslido_Dori = "C" Then

                                            _Origen_Modificado_Intertanto = True
                                            Throw New System.Exception("Alguno de los documentos de origen fueron modificados en el intertanto")

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    Next

                End If

            End If


            If _Tido <> "COV" Then

                If CBool(_TblOrigen.Rows.Count) Then

                    Dim _Sum_Caprco As Double

                    For Each _Fila_Idmaeedo As DataRow In _TblOrigen.Rows

                        _Sum_Caprco = 0

                        Dim _Idmaeedo_Origen = _Fila_Idmaeedo.Item("IDMAEEDO")
                        _Tidopa = _Fila_Idmaeedo.Item("TIDO")

                        For Each _Fila As DataRow In _Tbl_Detalle.Rows

                            Dim Idmaeedo_Dori = _Fila.Item("Idmaeedo_Dori")

                            If _Idmaeedo_Origen = Idmaeedo_Dori Then

                                _Idrst = Val(_Fila.Item("Idmaeddo_Dori"))

                                If CBool(_Idrst) Then

                                    Dim _CantUd1_Dori As Double = _Fila.Item("CantUd1_Dori")
                                    Dim _CantUd2_Dori As Double = _Fila.Item("CantUd2_Dori")

                                    Dim _Cant_MovUd1_Ext As String
                                    Dim _Cant_MovUd2_Ext As String

                                    Dim _CantUd1 As Double = _Fila.Item("CantUd1")
                                    Dim _CantUd2 As Double = _Fila.Item("CantUd2")

                                    If _CantUd1_Dori < _CantUd1 Then
                                        _Cant_MovUd1_Ext = _CantUd1_Dori
                                        _Cant_MovUd2_Ext = _CantUd2_Dori
                                    Else
                                        _Cant_MovUd1_Ext = _CantUd1
                                        _Cant_MovUd2_Ext = _CantUd2
                                    End If

                                    _Sum_Caprco += _Cant_MovUd1_Ext

                                End If

                            End If

                        Next


                        If CBool(_Sum_Caprco) Then

                            Dim _Sum_Caprco_str As String = De_Num_a_Tx_01(_Sum_Caprco, False, 5)

                            If ((_Tido = "NCV" Or _Tido = "NCC") And Not _Tidopa.Contains("G")) Or
                                (_Tido = "GDD" And _Subtido = String.Empty) Or
                                (_Tido = "GRD" And _Caprex = 0) Then

                                Consulta_sql = "UPDATE MAEEDO SET CAPREX=CAPREX+0,CAPRNC=CAPRNC+" & _Sum_Caprco_str & ",CAPRAD=CAPRAD+0," & vbCrLf &
                                               "ESDO=CASE" & vbCrLf &
                                               "WHEN ROUND(CAPRCO-CAPRAD-CAPREX-(0)-(0),5)=0 THEN 'C'" & vbCrLf & "ELSE ''" & vbCrLf & "END," & vbCrLf &
                                               "ESFADO=CASE" & vbCrLf &
                                               "WHEN CAPRCO-CAPRAD-CAPREX-(0)-(0)=0 THEN 'F'" & vbCrLf & "ELSE ESFADO" & vbCrLf & "END" & vbCrLf &
                                               "WHERE IDMAEEDO= " & _Idmaeedo_Origen
                            Else

                                Consulta_sql = "UPDATE MAEEDO SET CAPREX=CAPREX+" & _Sum_Caprco_str & ",CAPRNC=CAPRNC+0,CAPRAD=CAPRAD+0," & vbCrLf &
                                               "ESDO=CASE " & vbCrLf &
                                               "WHEN ROUND(CAPRCO-CAPRAD-CAPREX-(0)-(" & _Sum_Caprco_str & "),5)=0 THEN 'C'" & vbCrLf & "ELSE ''" & vbCrLf & "END," & vbCrLf &
                                               "ESFADO=" & vbCrLf &
                                               "CASE" & vbCrLf &
                                               "WHEN CAPRCO-CAPRAD-CAPREX-(0)-(" & _Sum_Caprco_str & ")=0 THEN 'F'" & vbCrLf & "ELSE ESFADO" & vbCrLf & "End" & vbCrLf &
                                               "WHERE IDMAEEDO = " & _Idmaeedo_Origen

                            End If

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    Next

                End If

            End If


            Consulta_sql = "UPDATE MAEEDO SET ESFADO=" & vbCrLf &
                           "CASE" & vbCrLf &
                           "WHEN CAPRCO-CAPRAD-CAPREX-(0) = 0 THEN 'F' " & vbCrLf & "ELSE ESFADO" & vbCrLf & "End" & vbCrLf &
                           "WHERE IDMAEEDO = " & _Idmaeedo

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            If _DesdeProduccion Then

                Consulta_sql = "Update MAEEDO Set NUVEDO = 0,ESFADO = '',DESPACHO = 0 Where IDMAEEDO = " & _Idmaeedo
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            '=========================================== OBSERVACIONES ==================================================================

            Dim Tbl_Observaciones As DataTable = Bd_Documento.Tables("Observaciones_Doc")

            With Tbl_Observaciones

                _Obdo = .Rows(0).Item("Observaciones")
                _Cpdo = .Rows(0).Item("Forma_pago")
                _Ocdo = .Rows(0).Item("Orden_compra")
                _Motivo = .Rows(0).Item("Motivo")

                Dim _Placapat As String = .Rows(0).Item("Placa").ToString.Trim
                Dim _Diendesp As String = .Rows(0).Item("CodRetirador").ToString

                For i = 0 To 34

                    Dim Campo As String = "Obs" & i + 1
                    Obs(i) = .Rows(0).Item(Campo)

                Next

                Consulta_sql = "INSERT INTO MAEEDOOB (IDMAEEDO,OBDO,CPDO,OCDO,DIENDESP,TEXTO1,TEXTO2,TEXTO3,TEXTO4,TEXTO5,TEXTO6," & vbCrLf &
                           "TEXTO7,TEXTO8,TEXTO9,TEXTO10,TEXTO11,TEXTO12,TEXTO13,TEXTO14,TEXTO15,CARRIER,BOOKING,LADING,AGENTE," & vbCrLf &
                           "MEDIOPAGO,TIPOTRANS,KOPAE,KOCIE,KOCME,FECHAE,HORAE,KOPAD,KOCID,KOCMD,FECHAD,HORAD,OBDOEXPO,MOTIVO," & vbCrLf &
                           "TEXTO16,TEXTO17,TEXTO18,TEXTO19,TEXTO20,TEXTO21,TEXTO22,TEXTO23,TEXTO24,TEXTO25,TEXTO26,TEXTO27," & vbCrLf &
                           "TEXTO28,TEXTO29,TEXTO30,TEXTO31,TEXTO32,TEXTO33,TEXTO34,TEXTO35,PLACAPAT) VALUES " & vbCrLf &
                           "(" & _Idmaeedo & ",'" & _Obdo & "','" & _Cpdo & "','" & _Ocdo & "','" & _Diendesp & "','" & Obs(0) & "','" & Obs(1) &
                           "','" & Obs(2) & "','" & Obs(3) & "','" & Obs(4) & "','" & Obs(5) & "','" & Obs(6) & "','" & Obs(7) &
                           "','" & Obs(8) & "','" & Obs(9) & "','" & Obs(10) & "','" & Obs(11) & "','" & Obs(12) & "','" & Obs(13) &
                           "','" & Obs(14) & "','','','','','','','','','',GETDATE(),'','','','',GETDATE(),'','','" & _Motivo & "','" & Obs(15) &
                           "','" & Obs(16) & "','" & Obs(17) & "','" & Obs(18) & "','" & Obs(19) &
                           "','" & Obs(20) & "','" & Obs(21) & "','" & Obs(22) & "','" & Obs(23) & "','" & Obs(24) &
                           "','" & Obs(25) & "','" & Obs(26) & "','" & Obs(27) & "','" & Obs(28) & "','" & Obs(29) &
                           "','" & Obs(30) & "','" & Obs(31) & "','" & Obs(32) & "','" & Obs(33) & "','" & Obs(34) &
                           "','" & _Placapat & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            ' ========================================== INCORPORAR EVENTOS =====================================================================

            Consulta_sql = Fx_Mevento(_Idmaeedo, _Tbl_Mevento_Edo)

            If Not String.IsNullOrEmpty(Consulta_sql) Then

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            'Consulta_sql = Fx_Mevento(_Tbl_Mevento_Edd)

            'If Not String.IsNullOrEmpty(Consulta_sql) Then

            '    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            '    Comando.Transaction = myTrans
            '    Comando.ExecuteNonQuery()

            'End If

            Consulta_sql = Fx_Referencias_DTE(_Idmaeedo, _Tbl_Referencias_DTE, False)

            If Not String.IsNullOrEmpty(Consulta_sql) Then

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Consulta_sql = String.Empty

            Consulta_sql = Fx_Referencias_En_Mevento(_Idmaeedo, _Tbl_Referencias_DTE, _Row_Encabezado.Item("FechaEmision"), _HoraGrab)

            If Not String.IsNullOrEmpty(Consulta_sql) Then

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            Consulta_sql = String.Empty

            If _Reserva_NroOCC Then

                Dim _Id_DocEnc As String = _Row_Encabezado.Item("Id_DocEnc")
                Dim _Nudo_Reserva As String = _Sql.Fx_Trae_Dato("MAEEDO", "NUDO", "IDMAEEDO = " & _Reserva_Idmaeedo)

                Consulta_sql = "Delete MAEEDO Where IDMAEEDO = " & _Reserva_Idmaeedo & "
                                Delete MAEDDO Where IDMAEEDO = " & _Reserva_Idmaeedo & "
                                Delete MAEEDOOB Where IDMAEEDO = " & _Reserva_Idmaeedo & "
                                Delete " & _Global_BaseBk & "Zw_Casi_DocEnc Where Reserva_Idmaeedo = " & _Reserva_Idmaeedo & "
                                Delete " & _Global_BaseBk & "Zw_Casi_DocObs Where Id_DocEnc = " & _Id_DocEnc & "
                                Delete " & _Global_BaseBk & "Zw_Casi_DocTom Where Id_DocEnc = " & _Id_DocEnc

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                If Not String.IsNullOrEmpty(_Nudo_Reserva.Trim) Then

                    Consulta_sql = "Update MAEEDO Set NUDO = '" & _Nudo_Reserva & "' Where IDMAEEDO = " & _Idmaeedo & "
                                    Update MAEDDO Set NUDO = '" & _Nudo_Reserva & "' Where IDMAEEDO = " & _Idmaeedo

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

            End If

            If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Docu_Ent") Then

                Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
                Dim _TipoEstacion = _Global_Row_EstacionBk.Item("TipoEstacion")
                Dim _Modalidad As String = _Row_Encabezado.Item("Modalidad")
                Dim _Pickear As Integer

                If _Tido = "NVV" Then

                    _Pickear = Convert.ToInt32(_Row_Encabezado.Item("Pickear")) 'Convert.ToInt32(_Global_Row_Configuracion_General.Item("Pickear_NVVTodas"))

                    'If CBool(_Pickear) AndAlso
                    '    Convert.ToInt32(_Global_Row_Configuracion_General.Item("Pickear_ProdPesoVariable")) AndAlso
                    '    Not CBool(_Items_RtuVariable) Then
                    '    _Pickear = 0
                    'End If

                End If

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Ent (Idmaeedo,NombreEquipo,TipoEstacion,Empresa,Modalidad,Tido,Nudo,FechaHoraGrab," &
                               "HabilitadaFac,FunAutorizaFac,Pickear,Customizable,PreVenta) Values " &
                               "(" & _Idmaeedo & ",'" & _NombreEquipo & "','" & _TipoEstacion & "','" & _Empresa & "','" & _Modalidad & "'" &
                               ",'" & _Tido & "','" & _Nudo & "',Getdate(),0,''," & _Pickear & "," & Convert.ToInt32(_Customizable) & "," & Convert.ToInt32(_PreVenta) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            If _Tido = "COV" Or _Tido = "NVV" Or _Tido = "BLV" Or _Tido = "FCV" Or
               _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "NCV" Or _Tido = "GRI" Or _Tido = "GDI" Then

                Consulta_sql = "Select * From MAEEDO Where TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"
                Comando = New SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()

                Dim _IdmaeedoExiste As Integer
                Dim _ExisteOtraNumeracion As Boolean

                While dfd1.Read()

                    _IdmaeedoExiste = dfd1("IDMAEEDO")
                    If _Idmaeedo <> _IdmaeedoExiste Then
                        _ExisteOtraNumeracion = True
                    End If

                End While
                dfd1.Close()

                If _ExisteOtraNumeracion Then
                    Throw New System.Exception("Ya existe un documento con la misma numeración (" & _Tido & "-" & _Nudo & ")" & vbCrLf &
                                           "Favor intentar nuevamente la grabación")
                End If

            End If

            If _Eliminar_Idmaeedo_Origen Then

                Dim _Idmaeedo_Origen As Integer = _Row_Encabezado.Item("Idmaeedo_Origen")

                Consulta_sql = "Delete From MAEPOSLI" & vbCrLf &
                               "Where MAEPOSLI.IDMAEDDO IN (Select IDMAEDDO From MAEDDO Where IDMAEEDO=" & _Idmaeedo_Origen & ")" & vbCrLf &
                               "Delete From MEVENTO Where ARCHIRVE='MAEEDO' And IDRVE=" & _Idmaeedo_Origen & vbCrLf &
                               "Delete From MAEIMLI Where IDMAEEDO =" & _Idmaeedo_Origen & vbCrLf &
                               "Delete From MAEDTLI Where IDMAEEDO=" & _Idmaeedo_Origen & vbCrLf &
                               "Delete From MEVENTO " &
                               "Where ARCHIRVE='MAEDDO' And IDRVE IN (Select IDMAEDDO From MAEDDO Where IDMAEEDO=" & _Idmaeedo_Origen & ")" & vbCrLf &
                               "Delete From MAEDDO Where IDMAEEDO=" & _Idmaeedo_Origen & vbCrLf &
                               "Delete From MAEVEN Where IDMAEEDO=" & _Idmaeedo_Origen & vbCrLf &
                               "Delete From MAEEDOOB Where IDMAEEDO=" & _Idmaeedo_Origen & vbCrLf &
                               "Delete From TABPERMISO Where IDRST=" & _Idmaeedo_Origen & " And ARCHIRST='MAEEDO'" & vbCrLf &
                               "Delete From MAEDCR Where IDMAEEDO=" & _Idmaeedo_Origen

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            If False Then
                Throw New System.Exception("An exception has occurred.")
            End If

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            _Mensaje.Detalle = "Documento grabado con éxito"
            _Mensaje.Id = _Idmaeedo
            _Mensaje.Mensaje = "Ok"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information

            'Fx_Add_Log_Gestion(_Kofudo, Modalidad, "MAEEDO", _Idmaeedo, "", "CreaDocumento", "", "", "", "", False, "")

            'Return _Idmaeedo

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message & vbCrLf & vbCrLf & "Transaccion desecha"
            _Mensaje.Detalle = "Problema"
            _Mensaje.Id = 0
            _Mensaje.Icono = MessageBoxIcon.Stop

            Dim _Erro_VB As String = ex.Message & vbCrLf & ex.StackTrace & vbCrLf & "Código: " & _Koprct
            Clipboard.SetText(_Erro_VB)

            My.Computer.FileSystem.WriteAllText("ArchivoSalida", ex.Message & vbCrLf & ex.StackTrace, False)
            'MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "Transaccion desecha", "Problema", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

        End Try

        Return _Mensaje

    End Function

    Private Function Fx_Mevento(_Idrve As Integer, _Tbl_Mevento As DataTable) As String

        Dim _SqlQuery = String.Empty

        If Not IsNothing(_Tbl_Mevento) Then

            For Each _Fila As DataRow In _Tbl_Mevento.Rows

                Dim _Archive = _Fila.Item("ARCHIRVE")
                'Dim _Idrve = _Idrve
                Dim _Kofu = _Fila.Item("KOFU")
                Dim _Fevento = _Fila.Item("FEVENTO")
                Dim _Kotabla = _Fila.Item("KOTABLA")
                Dim _Kocarac = _Fila.Item("KOCARAC")
                Dim _Nokocarac = _Fila.Item("NOKOCARAC")
                Dim _Archise = _Fila.Item("ARCHIRSE")
                Dim _Idrse = _Fila.Item("IDRSE")
                Dim _Fecharef = _Fila.Item("FECHAREF")
                Dim _HoraGrab = _Fila.Item("HORAGRAB")
                Dim _Link = _Fila.Item("LINK")
                Dim _Kofudest = _Fila.Item("KOFUDEST")

                _SqlQuery += "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,ARCHIRSE,IDRSE,HORAGRAB,FECHAREF,LINK,KOFUDEST)
                              VALUES 
                              ('" & _Archive & "'," & _Idrve & ",'" & _Kofu & "',Getdate(),'" & _Kotabla & "','" & _Kocarac & "','" & _Nokocarac &
                              "','" & _Archise & "'," & _Idrse & "," & _HoraGrab & ",Null,'" & _Link & "','" & _Kofudest & "')" & Environment.NewLine

            Next

        End If

        Return _SqlQuery

    End Function

    Private Function Fx_Tag_Mevento(_Id_DocEnc As Integer, _Tbl_Mevento As DataTable) As String

        Dim _SqlQuery = String.Empty

        If Not IsNothing(_Tbl_Mevento) Then

            For Each _Fila As DataRow In _Tbl_Mevento.Rows

                Dim _Archirve = _Fila.Item("ARCHIRVE")
                Dim _Kofu = _Fila.Item("KOFU")
                Dim _Fevento = _Fila.Item("FEVENTO")
                Dim _Kotabla = _Fila.Item("KOTABLA")
                Dim _Kocarac = _Fila.Item("KOCARAC")
                Dim _Nokocarac = _Fila.Item("NOKOCARAC")
                Dim _Archise = _Fila.Item("ARCHIRSE")
                Dim _Idrse = _Fila.Item("IDRSE")
                Dim _Fecharef = _Fila.Item("FECHAREF")
                Dim _HoraGrab = _Fila.Item("HORAGRAB")
                Dim _Link = _Fila.Item("LINK")
                Dim _Kofudest = _Fila.Item("KOFUDEST")

                _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Casi_DocTag (Id_DocEnc,Archirve,Idrve,Kofu,Fevento,Kotabla,Kocarac,Nokocarac,Archirse,Idrse,Horagrab,Fecharef,Link,Kofudest)
                              Values 
                              (" & _Id_DocEnc & ",'" & _Archirve & "',0,'" & _Kofu & "',Getdate(),'" & _Kotabla & "','" & _Kocarac & "','" & _Nokocarac &
                              "','" & _Archise & "'," & _Idrse & "," & _HoraGrab & ",Null,'" & _Link & "','" & _Kofudest & "')" & Environment.NewLine

            Next

        End If

        Return _SqlQuery

    End Function

    Private Function Fx_Referencias_DTE(_Id_Doc As Integer,
                                        _Tbl_Referencias_DTE As DataTable,
                                        _Kasi As Boolean) As String

        Dim _SqlQuery = String.Empty

        If Not IsNothing(_Tbl_Referencias_DTE) Then

            For Each _Fila As DataRow In _Tbl_Referencias_DTE.Rows

                Dim _Estado As DataRowState = _Fila.RowState

                If Not _Estado = DataRowState.Deleted Then

                    Dim _Tido = _Fila.Item("Tido")
                    Dim _Nudo = _Fila.Item("Nudo")
                    Dim _NroLinRef = _Fila.Item("NroLinRef")
                    Dim _TpoDocRef = _Fila.Item("TpoDocRef")
                    Dim _FolioRef = _Fila.Item("FolioRef")
                    Dim _FchRef = Format(_Fila.Item("FchRef"), "yyyyMMdd")
                    Dim _CodRef = _Fila.Item("CodRef")
                    Dim _RUTOt = _Fila.Item("RUTOt")
                    Dim _IdAdicOtr = _Fila.Item("IdAdicOtr")
                    Dim _RazonRef = _Fila.Item("RazonRef")

                    _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Referencias_Dte " &
                                 "(Id_Doc,Tido,Nudo,NroLinRef,TpoDocRef,FolioRef,RUTOt,IdAdicOtr,FchRef,CodRef,RazonRef, Kasi)
                              Values
                              (" & _Id_Doc & ",'" & _Tido & "','" & _Nudo & "'," & _NroLinRef & ",'" & _TpoDocRef &
                                  "','" & _FolioRef & "','" & _RUTOt & "','" & _IdAdicOtr & "','" & _FchRef & "'," & _CodRef & ",'" & _RazonRef & "'," & Convert.ToInt32(_Kasi) & ")" & Environment.NewLine

                End If

            Next

        End If

        Return _SqlQuery

    End Function

    Private Function Fx_Referencias_En_Mevento(_Idmaeedo As Integer,
                                               _Tbl_Referencias As DataTable,
                                               _Fecha As Date,
                                               _HoraGrab As String)

        Dim _SqlQuery = String.Empty

        For Each _Filas As DataRow In _Tbl_Referencias.Rows

            Dim _NroLinRef = _Filas.Item("NroLinRef")
            Dim _TpoDocRef = _Filas.Item("TpoDocRef")
            Dim _FolioRef = _Filas.Item("FolioRef")
            Dim _RUTOt = _Filas.Item("RUTOt")
            Dim _IdAdicOtr = _Filas.Item("IdAdicOtr")
            Dim _FchRef As Date = _Filas.Item("FchRef")
            Dim _CodRef = _Filas.Item("CodRef")
            Dim _RazonRef = _Filas.Item("RazonRef")

            Dim _Idrve = _Idmaeedo
            Dim _Kofu = FUNCIONARIO
            Dim _Fevento As String = Format(_Fecha, "yyyyMMdd")
            Dim _Kotabla = "ESPECIAL"
            Dim _Kocarac = _TpoDocRef
            Dim _Nokocarac = _FolioRef
            Dim _Archise = String.Empty
            Dim _Idrse = 0
            Dim _Fecharef As String = Format(_FchRef, "yyyyMMdd")
            'Dim _HoraGrab = _Row_Maeedo.Item("HORAGRAB")
            Dim _Link = String.Empty
            Dim _Kofudest = String.Empty

            _SqlQuery += "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,ARCHIRSE,IDRSE,HORAGRAB,FECHAREF,LINK,KOFUDEST)
                                    VALUES 
                                    ('MAEEDO'," & _Idrve & ",'" & _Kofu & "',Getdate(),'" & _Kotabla & "','" & _Kocarac & "','" & _Nokocarac &
                            "','" & _Archise & "'," & _Idrse & "," & _HoraGrab & ",'" & _Fecharef & "','" & _Link & "','" & _Kofudest & "')" & vbCrLf & vbCrLf

        Next

        'If Not String.IsNullOrEmpty(Consulta_sql) Then
        '    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
        'End If
        Return _SqlQuery

    End Function

    Private Function Fx_Vencimientos(_RowEncabezado As DataRow) As String

        Dim _SqlQuery As String

        Dim _Tido = _RowEncabezado.Item("TipoDoc")
        Dim _TotalBrutoDoc As Double = _RowEncabezado.Item("TotalBrutoDoc")

        Dim _FechaEmision As Date = _RowEncabezado.Item("FechaEmision")
        Dim _Fecha_1er_Vencimiento As Date = _RowEncabezado.Item("Fecha_1er_Vencimiento")
        Dim _Cuotas As Integer = _RowEncabezado.Item("Cuotas")
        Dim _Dias_Vencimiento As Integer = _RowEncabezado.Item("Dias_Vencimiento")

        If _Cuotas = 0 Then _Cuotas = 1
        Dim _Aplica_Vencimientos As Boolean

        Select Case _Tido 'Mid(_Tido, 1, 1)

            Case "NCV", "FCV", "FEV", "FEE", "FXV", "FYV", "FVZ", "FDV", "BLV", "BLX", "FVT", "FDB", "FVX", "FDX", "FVL", "FDZ", "FVZ", "FCC", "BLC"
                _Aplica_Vencimientos = True
            Case Else
                _Aplica_Vencimientos = False

        End Select

        _Nuvedo = _Cuotas

        If _Aplica_Vencimientos Then

            Dim Cuotas_(_Cuotas - 1) As Date
            Cuotas_(0) = _Fecha_1er_Vencimiento

            Dim _FechasVenci As Date = _FechaEmision
            Dim _dias As Integer
            'If Cuotas > 1 Then

            Dim _Resultado As Double = _TotalBrutoDoc / _Cuotas
            Dim _Vave As Double = Math.Round(_TotalBrutoDoc / _Cuotas, 0)

            'If (Resultado Mod 1) = 0 Then
            'Valor_Cuota = Resultado
            'End If

            _dias = _Dias_Vencimiento

            For i = 1 To _Cuotas

                _FechasVenci = DateAdd(DateInterval.Day, _dias, _FechasVenci)
                Cuotas_(i - 1) = _FechasVenci
                _dias = _Dias_Vencimiento


                If i = _Cuotas Then
                    Dim rS = _Vave * _Cuotas
                    rS = _TotalBrutoDoc - rS
                    rS = _Vave + rS
                    _Vave = rS
                End If

                If i = 1 Then
                    _FechasVenci = _Fecha_1er_Vencimiento
                Else
                    _FechasVenci = _FechasVenci
                End If

                Dim _Feve As String = Format(_FechasVenci, "yyyyMMdd")
                Dim _Espgve As String = String.Empty
                Dim _Vaabve As String = 0
                Dim _Archirst As String = String.Empty
                Dim _porestpag As String = 0
                Dim __Observa As String = String.Empty

                _SqlQuery += "INSERT INTO MAEVEN (IDMAEEDO,FEVE,ESPGVE,VAVE,VAABVE,ARCHIRST,PORESTPAG,OBSERVA)" & vbCrLf &
                               "values (" & _Idmaeedo & ",'" & _Feve & "','" & _Espgve & "'," & De_Num_a_Tx_01(_Vave, False, 5) & "," & _Vaabve &
                               ",'" & _Archirst & "'," & _porestpag & ",'" & __Observa & "')" & vbCrLf

            Next

        End If

        Return _SqlQuery

    End Function

#End Region

    Private Function Fx_Cambiar_Numeracion_Modalidad(_Tido As String,
                                                     _Nudo As String,
                                                     _Modalidad As String) As String


        ' _Modalidad = "  "

        Dim _Consulta_sql = "Select Top 1 " & _Tido & " From CONFIEST WITH (NOLOCK) Where MODALIDAD = '" & _Modalidad & "' And EMPRESA = '" & ModEmpresa & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

        Dim _Nudo_Modalidad As String

        _Consulta_sql = String.Empty

        If CBool(_Tbl.Rows.Count) Then

            _Nudo_Modalidad = _Tbl.Rows(0).Item(_Tido).ToString.Trim

            If String.IsNullOrEmpty(_Nudo_Modalidad) Then
                _Consulta_sql = Fx_Cambiar_Numeracion_Modalidad(_Tido, _Nudo, "  ")
            ElseIf _Nudo_Modalidad = "0000000000" Then
                _Consulta_sql = String.Empty
            Else

                Dim Continua As Boolean = True

                If Not String.IsNullOrEmpty(Trim(_Nudo_Modalidad)) Then

                    Dim _ProxNumero = Fx_Proximo_NroDocumento(_Nudo, 10)

                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then

                        _Consulta_sql = "UPDATE CONFIEST SET " &
                                        "GDV = '" & _ProxNumero & "'," & vbCrLf &
                                        "GTI = '" & _ProxNumero & "'," & vbCrLf &
                                        "GDP = '" & _ProxNumero & "'," & vbCrLf &
                                        "GDD = '" & _ProxNumero & "'" & vbCrLf &
                                        "WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    Else
                        _Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                                    "WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    End If

                End If

            End If

        End If

        Return _Consulta_sql

    End Function


#Region "FUNCION CREAR DOCUMENTO RANDOM KASI"

    Function Fx_Crear_Documento_KASI(_Tipo_de_documento As String,
                                     _Numero_de_documento As String,
                                     _Es_Documento_Electronico As Boolean,
                                     _Bd_Documento As DataSet,
                                     Optional _EsAjuste As Boolean = False) As Integer



        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Tbl_Encabezado As DataTable = _Bd_Documento.Tables("Encabezado_Doc")

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try



            With Tbl_Encabezado

                Dim _Modalidad As String = .Rows(0).Item("Modalidad")
                _Tido = .Rows(0).Item("TipoDoc")
                _Numero_de_documento = Traer_Numero_Documento(_Tido, .Rows(0).Item("NroDocumento"), _Modalidad)

                If String.IsNullOrEmpty(_Numero_de_documento) Then
                    Return 0
                End If

                .Rows(0).Item("NroDocumento") = _Numero_de_documento
                _Nudo = .Rows(0).Item("NroDocumento")

                If String.IsNullOrEmpty(Trim(_Nudo)) Then
                    Return 0
                End If

                _Empresa = .Rows(0).Item("Empresa").ToString
                _Sudo = .Rows(0).Item("Sucursal")
                _Kofudo = .Rows(0).Item("CodFuncionario")


                _Endo = .Rows(0).Item("CodEntidad")
                _Suendo = .Rows(0).Item("CodSucEntidad")

                _Feemdo = Format(.Rows(0).Item("FechaEmision"), "yyyyMMdd")
                _Lisactiva = .Rows(0).Item("ListaPrecios")
                _Caprco = De_Num_a_Tx_01(.Rows(0).Item("CantTotal"), 5)
                _Caprad = De_Num_a_Tx_01(.Rows(0).Item("CantDesp"), 5)


                _Luvtdo = .Rows(0).Item("Centro_Costo")
                _Modo = .Rows(0).Item("Moneda_Doc")
                _Meardo = .Rows(0).Item("DocEn_Neto_Bruto")
                _Tamodo = De_Num_a_Tx_01(.Rows(0).Item("Valor_Dolar"), False, 5)
                _Timodo = .Rows(0).Item("TipoMoneda")

                Dim _Vanedo_2 = .Rows(0).Item("TotalNetoDoc")
                Dim _Vaivdo_2 = .Rows(0).Item("TotalIvaDoc")
                Dim _Vaimdo_2 = .Rows(0).Item("TotalIlaDoc")
                Dim _Vabrdo_2 = .Rows(0).Item("TotalBrutoDoc")


                _Vanedo = De_Num_a_Tx_01(.Rows(0).Item("TotalNetoDoc"), False, 5)
                _Vaivdo = De_Num_a_Tx_01(.Rows(0).Item("TotalIvaDoc"), False, 5)
                _Vaimdo = De_Num_a_Tx_01(.Rows(0).Item("TotalIlaDoc"), False, 5)
                _Vabrdo = De_Num_a_Tx_01(.Rows(0).Item("TotalBrutoDoc"), False, 5)

                _Fe01vedo = Format(.Rows(0).Item("Fecha_1er_Vencimiento"), "yyyyMMdd")
                _Feulvedo = Format(.Rows(0).Item("FechaUltVencimiento"), "yyyyMMdd")

                _Feer = Format(.Rows(0).Item("FechaRecepcion"), "yyyyMMdd")
                _Feerli = Format(.Rows(0).Item("FechaRecepcion"), "yyyyMMdd")

                '------------------------------------------------------------------------------------------------------------


            End With


            myTrans = cn2.BeginTransaction()


            Consulta_sql = "INSERT INTO KASIEDO ( EMPRESA,TIDO,NUDO,ENDO,SUENDO )" & vbCrLf &
                           "VALUES ( '" & _Empresa & "','" & _Tido & "','" & _Nudo &
                           "','" & _Endo & "','" & _Suendo & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idmaeedo = dfd1("Identity")
            End While
            dfd1.Close()

            _Bd_Documento.Tables("Detalle_Doc").Dispose()
            Dim Tbl_Detalle As DataTable = _Bd_Documento.Tables("Detalle_Doc")

            Dim Contador As Integer = 1

            For Each FDetalle As DataRow In Tbl_Detalle.Rows
                Dim Estado As DataRowState = FDetalle.RowState
                If Not Estado = DataRowState.Deleted Then

                    With FDetalle



                        Id_Linea = .Item("Id")


                        _Nulido = numero_(Contador, 5)

                        _Bosulido = .Item("Bodega")
                        _Koprct = .Item("Codigo")
                        _Nokopr = .Item("Descripcion")
                        _Rludpr = De_Num_a_Tx_01(.Item("Rtu"), False, 5)
                        _Sulido = .Item("Sucursal")
                        _Kofulido = .Item("CodFuncionario")
                        _Tict = .Item("Tict")
                        _Prct = .Item("Prct")
                        _Caprco1 = De_Num_a_Tx_01(.Item("CantUd1"), False, 5) ' Cantidad de la primera unidad
                        _Caprco2 = De_Num_a_Tx_01(.Item("CantUd2"), False, 5) ' Cantidad de la segunda unidad
                        _Tipr = .Item("Tipr")
                        _Lincondesp = .Item("Lincondest")

                        'CantidadTotal = CantidadTotal + Val(CAPRCO1)
                        If _Lincondesp Then
                            _Caprad1 = _Caprco1 ' Cantidad que mueve Stock Fisico, según el producto.
                            _Caprad2 = _Caprco2 ' Cantidad que mueve Stock Fisico, según el producto.
                        Else
                            _Caprad1 = De_Num_a_Tx_01(NuloPorNro(.Item("CDespUd1"), 0), False, 5) ' Cantidad que mueve Stock Fisico, según el producto.
                            _Caprad2 = De_Num_a_Tx_01(NuloPorNro(.Item("CDespUd2"), 0), False, 5) ' Cantidad que mueve Stock Fisico, según el producto.
                        End If

                        _Eslido = NuloPorNro(.Item("Estado"), "")

                        _Caprex1 = 0 ' Cantidad  
                        _Caprex2 = 0
                        _Caprnc1 = 0 ' Cantidad de Nota de credito
                        _Caprnc2 = 0

                        _Udtrpr = .Item("UnTrans")  ' Unidad de la transaccion
                        _Ud01pr = .Item("Ud01PR")
                        _Ud02pr = .Item("Ud02PR")
                        _Koltpr = .Item("CodLista") 'LISTADEPRECIO
                        _Mopppr = .Item("Moneda") 'trae_dato(tb, cn1, "KOMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                        _Timopppr = .Item("Tipo_Moneda") 'trae_dato(tb, cn1, "TIMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                        _Tamopppr = De_Num_a_Tx_01(.Item("Tipo_Cambio"), False, 5) 'De_Num_a_Tx_01(trae_dato(tb, cn1, "VAMO", "TABMO", "NOKOMO LIKE '%PESO%'"), False, 5)
                        _Ppprnelt = De_Num_a_Tx_01(.Item("PrecioNetoUd"), False, 5)
                        _Podtglli = De_Num_a_Tx_01(.Item("DescuentoPorc"), False, 5)
                        _Poimglli = De_Num_a_Tx_01(.Item("PorIla"), False, 5)

                        _Operacion = .Item("Operacion")
                        _Potencia = De_Num_a_Tx_01(.Item("Potencia"), False, 5)

                        Dim Campo As String = "Precio"

                        _Ppprne = De_Num_a_Tx_01(.Item("PrecioNetoUd"), False, 5)
                        _Ppprbr = De_Num_a_Tx_01(.Item("PrecioBrutoUd"), False, 5)
                        _Ppprnelt = De_Num_a_Tx_01(NuloPorNro(Of Double)(.Item("PrecioNetoUdLista"), 0), False, 5)
                        _Ppprbrlt = De_Num_a_Tx_01(.Item("PrecioBrutoUdLista"), False, 0) ' PRECIO BRUTO DE LA LISTA

                        _Poivli = De_Num_a_Tx_01(.Item("PorIva"), True)
                        _Nudtli = De_Num_a_Tx_01(.Item("NroDscto"), True)

                        _Nuimli = De_Num_a_Tx_01(.Item("NroImpuestos"), True)

                        _Vadtneli = De_Num_a_Tx_01(.Item("DsctoNeto"), False, 5)
                        _Vadtbrli = De_Num_a_Tx_01(.Item("DsctoBruto"), False, 5) 'ValDscto
                        _Vaneli = De_Num_a_Tx_01(.Item("ValNetoLinea"), False, 5)
                        _Vaimli = De_Num_a_Tx_01(.Item("ValIlaLinea"), False, 5)
                        _Vaivli = De_Num_a_Tx_01(.Item("ValIvaLinea"), False, 5)
                        _Vabrli = De_Num_a_Tx_01(Math.Round(.Item("ValBrutoLinea"), 5), False, 5)
                        _Feemli = _Feemdo 'Format(Now.Date, "yyyyMMdd") '""20121127"
                        _Feerli = _Feemdo 'Format(Now.Date, "yyyyMMdd")

                        _Observa = NuloPorNro(.Item("Observa"), "")

                        _Ppprnere1 = De_Num_a_Tx_01(.Item("PrecioNetoRealUd1"), False, 5)
                        _Ppprnere2 = De_Num_a_Tx_01(.Item("PrecioNetoRealUd2"), False, 5)
                        _Ppprpm = De_Num_a_Tx_01(NuloPorNro(.Item("PmLinea"), 0), False, 5)
                        _Ppprmsuc = De_Num_a_Tx_01(NuloPorNro(.Item("PmSucLinea"), 0), False, 5)

                        _Alternat = NuloPorNro(.Item("CodigoProv"), "")

                        Dim _TipoValor As String = NuloPorNro(.Item("TipoValor"), "")



                        If Not String.IsNullOrEmpty(Trim(_Tict)) Then

                            Dim TipoValor = _TipoValor

                            If TipoValor = "N" Then
                                _Caprco1 = _Vadtneli
                                _Vadtbrli = De_Txt_a_Num_01((_Vabrli), 0) * -1
                            Else
                                _Vadtneli = De_Num_a_Tx_01(De_Txt_a_Num_01((_Vaneli), 5) * -1, False, 5)
                                _Caprco1 = _Vadtbrli
                            End If

                            _Caprco2 = 0
                            _Caprad2 = 0
                            _Cafaco = 0
                            _Ppprnelt = 0
                            _Ppprne = 0
                            _Ppprbrlt = 0
                            _Ppprbr = 0
                            _Prct = 1
                            _Ppprpm = 0
                            _Ppprmsuc = 0
                            _Lincondesp = 1
                            _Nudtli = 0
                            _Eslido = "C"

                        Else

                            _Cafaco = _Caprco1

                        End If

                        '_Mopppr = .Item("Moneda") 'trae_dato(tb, cn1, "KOMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                        '_Timopppr = .Item("Tipo_Moneda") 'trae_dato(tb, cn1, "TIMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                        '_Tamopppr = .Item("Tipo_Cambio") 'De_Num_a_Tx_01(trae_dato(tb, cn1, "VAMO", "TABMO", "NOKOMO LIKE '%PESO%'"), False, 5)

                        Dim _Tasadorig = _Tamodo

                        Consulta_sql =
                              "INSERT INTO KASIDDO (IDMAEDDO,IDMAEEDO,ARCHIRST,IDRST,EMPRESA,TIDO,NUDO,ENDO,SUENDO,LILG,NULIDO," & vbCrLf &
                              "SULIDO,BOSULIDO,LUVTLIDO,KOFULIDO,TIPR,TICT,PRCT,KOPRCT,UDTRPR,RLUDPR,CAPRCO1," & vbCrLf &
                              "UD01PR,CAPRCO2,UD02PR,CAPRAD1,CAPRAD2,KOLTPR,MOPPPR,TIMOPPPR,TAMOPPPR,NUIMLI,NUDTLI," & vbCrLf &
                              "PODTGLLI,POIMGLLI,VAIMLI,VADTNELI,VADTBRLI,POIVLI,VAIVLI,VANELI,VABRLI,TIGELI," & vbCrLf &
                              "FEEMLI,FEERLI,PPPRNELT,PPPRNE,PPPRBRLT,PPPRBR,PPPRPM,PPPRNERE1,PPPRNERE2,CAFACO," & vbCrLf &
                              "FVENLOTE,FCRELOTE,NOKOPR,ALTERNAT,TASADORIG,CUOGASDIF,LINCONDESP,OPERACION,POTENCIA,ESLIDO,OBSERVA)" & vbCrLf &
                       "VALUES (0," & _Idmaeedo & ",'',0,'" & _Empresa & "','','','" & _Endo &
                              "','" & _Suendo & "','SI','" & _Nulido & "','" & _Sulido & "','" & _Bosulido &
                              "','" & _Luvtdo & "','" & _Kofudo & "','" & _Tipr & "','" & _Tict & "'," & CInt(_Prct) & ",'" & _Koprct &
                              "'," & _Udtrpr & "," & _Rludpr & "," & _Caprco1 & ",'" & _Ud01pr & "'," & _Caprco2 &
                              ",'" & _Ud02pr & "'," & _Caprad1 & "," & _Caprad2 & ",'TABPP" & _Koltpr & "'" &
                              ",'" & _Mopppr & "','" & _Timopppr & "'," & _Tamopppr &
                              "," & _Nuimli & "," & _Nudtli & "," & _Podtglli & "," & _Poimglli & "," & _Vaimli &
                              "," & _Vadtneli & "," & _Vadtbrli & "," & _Poivli & "," & _Vaivli & "," & _Vaneli &
                              "," & _Vabrli & ",'I','" & _Feemli & "','" & _Feerli & "'," & _Ppprnelt & "," & _Ppprne &
                              "," & _Ppprbrlt & "," & _Ppprbr & "," & _Ppprpm & "," & _Ppprnere1 & "," & _Ppprnere2 &
                              "," & _Cafaco & ",NULL,NULL,'" & _Nokopr & "','" & _Alternat & "'," & _Tasadorig & ",0," & CInt(_Lincondesp) &
                              ",'" & _Operacion & "'," & _Potencia & ",'" & _Eslido & "',' " & _Observa & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                                                      "COLUMN_NAME LIKE 'PPPRPMSUC' AND TABLE_NAME = 'KASIDDO'")

                        If CBool(_Reg) Then

                            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                            Comando.Transaction = myTrans
                            dfd1 = Comando.ExecuteReader()

                            Dim _Idmaeddo As Integer

                            While dfd1.Read()
                                _Idmaeddo = dfd1("Identity")
                            End While

                            dfd1.Close()

                            Consulta_sql = "UPDATE KASIDDO SET PPPRPMSUC = " & _Ppprmsuc & vbCrLf &
                                           "WHERE IDMAEDDO = " & _Idmaeddo

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End With


                    ' TABLA DE IMPUESTOS

                    Dim Tbl_Impuestos As DataTable = _Bd_Documento.Tables("Impuestos_Doc")

                    If Val(_Nuimli) > 0 And String.IsNullOrEmpty(Trim(_Tict)) Then

                        For Each FImpto As DataRow In Tbl_Impuestos.Select("Id = " & Id_Linea)

                            Dim _Poimli As String = De_Num_a_Tx_01(FImpto.Item("Poimli").ToString, False, 5)
                            Dim _Koimli As String = FImpto.Item("Koimli").ToString
                            Dim _Vaimli = De_Num_a_Tx_01(FImpto.Item("Vaimli").ToString, False, 5)

                            Consulta_sql = "INSERT INTO KASIIMLI(IDMAEEDO,NULIDO,KOIMLI,POIMLI,VAIMLI,LILG) VALUES " & vbCrLf &
                                           "(" & _Idmaeedo & ",'" & _Nulido & "','" & _Koimli & "'," & _Poimli & "," & _Vaimli & ",'')"

                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            '-- 3RA TRANSACCION--------------------------------------------------------------------
                        Next
                    End If



                    ' TABLA DE DESCUENTOS
                    Dim Tbl_Descuentos As DataTable = _Bd_Documento.Tables("Descuentos_Doc")
                    _Nudtli = Tbl_Descuentos.Rows.Count

                    If Val(_Nudtli) > 0 And String.IsNullOrEmpty(Trim(_Tict)) Then

                        For Each FDscto As DataRow In Tbl_Descuentos.Select("Id = " & Id_Linea)

                            Dim _Podt = De_Num_a_Tx_01(FDscto.Item("Podt").ToString, False, 5)
                            Dim _Vadt = De_Num_a_Tx_01(FDscto.Item("Vadt").ToString, False, 5)

                            Consulta_sql = "INSERT INTO KASIDTLI (IDMAEEDO,NULIDO,KODT,PODT,VADT)" & vbCrLf &
                                   "values (" & _Idmaeedo & ",'" & _Nulido & "','D_SIN_TIPO'," & _Podt & "," & _Vadt & ")"


                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                            '-- 4TA TRANSACCION--------------------------------------------------------------------
                        Next

                    End If

                    Contador += 1

                End If

            Next



            'TABLA DE VENCIMIENTOS

            'Dim Tbl_Vencimientos As DataTable = _Bd_Documento.Tables("Vencimientos_Doc")

            '_Nuvedo = Tbl_Vencimientos.Rows.Count

            'For Each FVencimientos As DataRow In Tbl_Vencimientos.Rows

            'Dim _Feve As String = Format(FVencimientos.Item("Fecha_Vencimiento"), "yyyyMMdd")
            'Dim _Espgve As String = String.Empty 'FilaX.Item("Estado_Pago").ToString
            'Dim _Vave As String = De_Num_a_Tx_01(FVencimientos.Item("Valor_Vencimiento").ToString, False, 5)
            'Dim _Vaabve As String = De_Num_a_Tx_01(FVencimientos.Item("Valor_Abonado").ToString, False, 5)
            'Dim _Archirst As String = String.Empty 'FilaX.Item("Archirst").ToString
            'Dim _porestpag As String = 0 'De_Num_a_Tx_01(FilaX.Item("Porestpag").ToString, False, 5)
            'Dim __Observa As String = String.Empty 'FilaX.Item("Archirst").ToString

            'Consulta_sql = "INSERT INTO MAEVEN (IDMAEEDO,FEVE,ESPGVE,VAVE,VAABVE,ARCHIRST,PORESTPAG,OBSERVA)" & vbCrLf & _
            '               "values (" & _Idmaeedo & ",'" & _Feve & "','" & _Espgve & "'," & _Vave & "," & _Vaabve & _
            '               ",'" & _Archirst & "'," & _porestpag & ",'" & __Observa & "')"

            'Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            'Comando.Transaction = myTrans
            'Comando.ExecuteNonQuery()

            'Next




            If _Nuvedo = 0 Then _Nuvedo = 1

            If _EsAjuste Then
                _Marca = 1 ' Generalmente se marcan las GRI o GDI que son por ajuste
                _Subtido = "AJU" ' Generalmente se Marcan las Guias de despacho o recibo
                '_HH = 23 : _MM = 59 : _SS = 59
            Else
                _Marca = String.Empty
            End If

            _HoraGrab = Hora_Grab_fx(_EsAjuste) 'Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

            Dim _Espgdo As String = "P"
            If _Tido = "OCC" Then _Espgdo = "S"

            ' HAY QUE PONER EL CAMPO TIPO DE MONEDA  "TIMODO"

            Dim _Despacho As Integer = 2

            Consulta_sql = "UPDATE KASIEDO SET SUENDO='" & _Suendo & "',TIGEDO='I',SUDO='" & _Sudo &
                           "',FEEMDO='" & _Feemdo & "',KOFUDO='" & _Kofudo & "',ESPGDO='" & _Espgdo & "',CAPRCO=" & _Caprco &
                           ",CAPRAD=" & _Caprad & ",MEARDO = '" & _Meardo & "',MODO = '" & _Modo &
                           "',TIMODO = '" & _Timodo & "',TAMODO = " & _Tamodo & ",VAIVDO = " & _Vaivdo & ",VAIMDO = " & _Vaimdo & vbCrLf &
                           ",VANEDO = " & _Vanedo & ",VABRDO = " & _Vabrdo & ",FE01VEDO = '" & _Fe01vedo &
                           "',FEULVEDO = '" & _Feulvedo & "',NUVEDO = " & _Nuvedo & ",FEER = '" & _Feer &
                           "',KOTU = '1',LCLV = NULL,LAHORA = GETDATE(), DESPACHO = " & _Despacho & ",HORAGRAB = " & _HoraGrab &
                           ",FECHATRIB = NULL,NUMOPERVEN = 0,FLIQUIFCV = '" & _Feemdo & "',SUBTIDO = '" & _Subtido &
                           "',MARCA = '" & _Marca & "',ESDO = ''" &
                           ",TIDOELEC = " & CInt(_Es_Documento_Electronico) & ",LUVTDO = '" & _Luvtdo & "'" & vbCrLf &
                           "WHERE IDMAEEDO=" & _Idmaeedo

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Dim Reg As Integer = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                                         "COLUMN_NAME LIKE 'LISACTIVA' AND TABLE_NAME = 'KASIEDO'")

            If CBool(Reg) Then

                Consulta_sql = "UPDATE KASIEDO SET LISACTIVA = 'TABPP" & _Lisactiva & "'" & vbCrLf &
                               "WHERE IDMAEEDO=" & _Idmaeedo

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            '=========================================== OBSERVACIONES ==================================================================

            Dim Tbl_Observaciones As DataTable = _Bd_Documento.Tables("Observaciones_Doc")

            With Tbl_Observaciones

                _Obdo = .Rows(0).Item("Observaciones")
                _Cpdo = .Rows(0).Item("Forma_pago")
                _Ocdo = .Rows(0).Item("Orden_compra")

                For i = 0 To 34

                    Dim Campo As String = "Obs" & i + 1
                    Obs(i) = .Rows(0).Item(Campo)

                Next

            End With

            Consulta_sql = "INSERT INTO KASIEDOB (IDMAEEDO,OBDO,CPDO,OCDO,DIENDESP,TEXTO1,TEXTO2,TEXTO3,TEXTO4,TEXTO5,TEXTO6," & vbCrLf &
                           "TEXTO7,TEXTO8,TEXTO9,TEXTO10,TEXTO11,TEXTO12,TEXTO13,TEXTO14,TEXTO15,CARRIER,BOOKING,LADING,AGENTE," & vbCrLf &
                           "MEDIOPAGO,TIPOTRANS,KOPAE,KOCIE,KOCME,FECHAE,HORAE,KOPAD,KOCID,KOCMD,FECHAD,HORAD,OBDOEXPO,MOTIVO," & vbCrLf &
                           "TEXTO16,TEXTO17,TEXTO18,TEXTO19,TEXTO20,TEXTO21,TEXTO22,TEXTO23,TEXTO24,TEXTO25,TEXTO26,TEXTO27," & vbCrLf &
                           "TEXTO28,TEXTO29,TEXTO30,TEXTO31,TEXTO32,TEXTO33,TEXTO34,TEXTO35,PLACAPAT) VALUES " & vbCrLf &
                           "(" & _Idmaeedo & ",'" & _Obdo & "','" & _Cpdo & "','" & _Ocdo & "','','" & Obs(0) & "','" & Obs(1) &
                           "','" & Obs(2) & "','" & Obs(3) & "','" & Obs(4) & "','" & Obs(5) & "','" & Obs(6) & "','" & Obs(7) &
                           "','" & Obs(8) & "','" & Obs(9) & "','" & Obs(10) & "','" & Obs(11) & "','" & Obs(12) & "','" & Obs(13) &
                           "','" & Obs(14) & "','','','','','','','','','',GETDATE(),'','','','',GETDATE(),'','','','" & Obs(15) &
                           "','" & Obs(16) & "','" & Obs(17) & "','" & Obs(18) & "','" & Obs(19) &
                           "','" & Obs(20) & "','" & Obs(21) & "','" & Obs(22) & "','" & Obs(23) & "','" & Obs(24) &
                           "','" & Obs(25) & "','" & Obs(26) & "','" & Obs(27) & "','" & Obs(28) & "','" & Obs(29) &
                           "','" & Obs(30) & "','" & Obs(31) & "','" & Obs(32) & "','" & Obs(33) & "','" & Obs(34) &
                           "','')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            ' ====================================================================================================================================

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return _Idmaeedo

        Catch ex As Exception

            Dim _Erro_VB As String = ex.Message & vbCrLf & ex.StackTrace & vbCrLf &
                                     "Código: " & _Koprct
            Clipboard.SetText(_Erro_VB)

            My.Computer.FileSystem.WriteAllText("ArchivoSalida", ex.Message & vbCrLf & ex.StackTrace, False)
            MessageBoxEx.Show(ex.Message, "Error",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            Return 0
        End Try

    End Function

#End Region


#Region "FUNCION CREAR DOCUMENTO RANDOM CASI DEFINITIVO"

    Function Fx_Crear_Documento_En_BakApp_Casi(_Bd_Documento As DataSet,
                                               _EsAjuste As Boolean,
                                               _Stand_by As Boolean) As Integer

#Region "Variables"

        Dim _Id_DocEnc As Integer

        Dim _Modalidad As String
        Dim _TipoDoc As String
        Dim _SubTido As String
        Dim _NroDocumento As String
        Dim _Es_ValeTransitorio As Boolean

        Dim _Sucursal_Doc As String

        Dim _CodFuncionario As String
        Dim _CodEntidad As String
        Dim _CodSucEntidad As String
        Dim _FechaEmision As String
        Dim _ListaPrecios As String
        Dim _CantTotal As String
        Dim _CantDesp As String
        Dim _Centro_Costo As String
        Dim _Moneda_Doc As String
        Dim _DocEn_Neto_Bruto As String
        Dim _Valor_Dolar As String

        Dim _TotalNetoDoc As String
        Dim _TotalIvaDoc As String
        Dim _TotalIlaDoc As String
        Dim _TotalBrutoDoc As String
        Dim _Fecha_1er_Vencimiento As String
        Dim _FechaUltVencimiento As String
        Dim _FechaRecepcion As String

        Dim _Nombre_Entidad As String
        Dim _Cuotas As String
        Dim _Dias_1er_Vencimiento As String
        Dim _Dias_Vencimiento As String
        Dim _CodEntidadFisica As String
        Dim _CodSucEntidadFisica As String
        Dim _Nombre_Entidad_Fisica As String
        Dim _Contacto_Ent As String
        Dim _NomFuncionario As String
        Dim _Es_Electronico As String
        Dim _TipoMoneda As String
        Dim _Vizado As String

        Dim _Tasadorig_Doc As String

        Dim _Fun_Auto_Deuda_Ven As String
        Dim _Fun_Auto_Stock_Ins As String
        Dim _Fun_Auto_Cupo_Exe As String
        Dim _Fun_Auto_Sol_Compra As String

        Dim _NroLinea As String

        Dim _Sucursal_Linea As String
        Dim _Bodega_Linea As String

        Dim _Codigo As String
        Dim _Descripcion As String
        Dim _Rtu As String

        Dim _CodVendedor As String
        Dim _Tict As String
        Dim _Prct As String
        Dim _Tipr As String
        Dim _Cantidad As String
        Dim _Precio As String
        Dim _CantUd1 As String
        Dim _CantUd2 As String
        Dim _Lincondest As String
        Dim _CDespUd1 As String
        Dim _CDespUd2 As String
        Dim _Estado As String
        Dim _UnTrans As String
        Dim _UdTrans As String
        Dim _Ud01PR As String
        Dim _Ud02PR As String
        Dim _CodLista As String
        Dim _Moneda As String
        Dim _Tipo_Moneda As String
        Dim _Tipo_Cambio As String
        Dim _DescuentoPorc As String
        Dim _DescuentoValor As String
        Dim _PorIla As String
        Dim _Operacion As String
        Dim _Potencia As String

        Dim _PrecioNetoUd As String
        Dim _PrecioBrutoUd As String
        Dim _PrecioNetoUdLista As String
        Dim _PrecioBrutoUdLista As String
        Dim _PorIva As String
        Dim _NroDscto As String
        Dim _NroImpuestos As String
        Dim _DsctoRealPorc As String
        Dim _DsctoRealValor As String
        Dim _DsctoNeto As String
        Dim _DsctoBruto As String
        Dim _ValSubNetoLinea As String
        Dim _StockBodega As String
        Dim _UbicacionBod As String
        Dim _SubTotal As String
        Dim _ValNetoLinea As String
        Dim _ValIlaLinea As String
        Dim _ValIvaLinea As String
        Dim _ValBrutoLinea As String
        Dim _FechaEmision_Linea As String
        Dim _FechaRecepcion_Linea As String
        Dim _Observa As String
        Dim _PrecioNetoRealUd1 As String
        Dim _PrecioNetoRealUd2 As String
        Dim _PmLinea As String
        Dim _PmSucLinea As String
        Dim _CodigoProv As String
        Dim _TipoValor As String
        Dim _ValVtaDescMax As String
        Dim _ValVtaStockInf As String
        Dim _DescMaximo As String

        Dim _Idmaeedo_Dori As String
        Dim _Idmaeddo_Dori As String
        Dim _CantUd1_Dori As String
        Dim _CantUd2_Dori As String

        Dim _Emprepa As String
        Dim _Tidopa As String
        Dim _NudoPa As String
        Dim _Endopa As String
        Dim _Nulidopa As String

        Dim _DsctoGlobalSuperado As String
        Dim _Tiene_Dscto As String
        Dim _CantidadCalculo As String
        Dim _PrecioCalculo As String
        Dim _OCCGenerada As String
        Dim _Bloqueapr As String
        Dim _CodFunAutoriza As String
        Dim _CodPermiso As String
        Dim _Nuevo_Producto As String
        Dim _Solicitado_bodega As String
        Dim _Centro_Costo_Linea As String
        Dim _Proyecto As String

        Dim _Id_Oferta As Integer
        Dim _Es_Padre_Oferta As Integer
        Dim _Oferta As String
        Dim _Padre_Oferta As Integer
        Dim _Aplica_Oferta As Integer
        Dim _Hijo_Oferta As Integer
        Dim _Cantidad_Oferta As String
        Dim _Porcdesc_Oferta As String

        Dim _Tasadorig As Double

        Dim _Reserva_NroOCC As Integer
        Dim _Reserva_Idmaeedo As Integer

        Dim _RevFincred As Integer
        Dim _IdFincred As Integer
        Dim _MontoFincred As String

        Dim _Nmarca As String
        Dim _RtuVariable As Integer
        Dim _Espuntosvta As Integer
        Dim _ModFechVto As Integer
        Dim _Condicionado As Integer

        Dim _TblTipoVenta As String
        Dim _CodTipoVenta As String

        Dim _Customizable As Integer
        Dim _Pickear As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Tbl_Encabezado As DataTable = _Bd_Documento.Tables("Encabezado_Doc")

        Dim _Tbl_Mevento_Edo As DataTable = _Bd_Documento.Tables("Mevento_Edo")
        Dim _Tbl_Mevento_Edd As DataTable = _Bd_Documento.Tables("Mevento_Edd")
        Dim _Tbl_Referencias_DTE As DataTable = _Bd_Documento.Tables("Referencias_DTE")

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

#End Region

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try

            With Tbl_Encabezado.Rows(0)

                _Modalidad = .Item("Modalidad")

                _TipoDoc = .Item("TipoDoc")
                _SubTido = .Item("Subtido")

                If _TipoDoc = "NVV" Then

                    Dim letras As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                    Dim numeros As String = "0123456789"
                    Dim random As New Random()
                    Dim resultado As New System.Text.StringBuilder()

                    ' Generar 3 letras al azar
                    For i As Integer = 1 To 3
                        Dim indiceLetra As Integer = random.Next(0, letras.Length)
                        resultado.Append(letras(indiceLetra))
                    Next

                    ' Generar 7 números al azar
                    For i As Integer = 1 To 7
                        Dim indiceNumero As Integer = random.Next(0, numeros.Length)
                        resultado.Append(numeros(indiceNumero))
                    Next

                    _NroDocumento = resultado.ToString()

                Else

                    _NroDocumento = Traer_Numero_Documento(_Tido, .Item("NroDocumento"), _Modalidad)

                End If



                If String.IsNullOrEmpty(_NroDocumento) Then
                    Return 0
                End If

                .Item("NroDocumento") = _NroDocumento

                If String.IsNullOrEmpty(Trim(_NroDocumento)) Then
                    Return 0
                End If

                For Each _Fila As DataRow In _Tbl_Referencias_DTE.Rows
                    _Fila.Item("Tido") = _Tido
                    _Fila.Item("Nudo") = _Nudo
                Next

                _Empresa = .Item("Empresa").ToString

                _Sucursal_Doc = .Item("Sucursal")
                _CodFuncionario = .Item("CodFuncionario")

                _CodEntidad = .Item("CodEntidad")
                _CodSucEntidad = .Item("CodSucEntidad")

                _FechaEmision = Format(.Item("FechaEmision"), "yyyyMMdd")
                _ListaPrecios = .Item("ListaPrecios")
                _CantTotal = De_Num_a_Tx_01(.Item("CantTotal"), 5)
                _CantDesp = De_Num_a_Tx_01(.Item("CantDesp"), 5)

                _Centro_Costo = NuloPorNro(.Item("Centro_Costo"), "")
                _Moneda_Doc = .Item("Moneda_Doc")
                _DocEn_Neto_Bruto = .Item("DocEn_Neto_Bruto")
                _Valor_Dolar = De_Num_a_Tx_01(.Item("Valor_Dolar"), False, 5)
                _Tipo_Moneda = .Item("TipoMoneda")

                _Tasadorig_Doc = De_Num_a_Tx_01(.Item("Tasadorig_Doc"), False, 5)

                Dim _TotalNetoDoc_2 = .Item("TotalNetoDoc")
                Dim _TotalIvaDoc_2 = .Item("TotalIvaDoc")
                Dim _TotalIlaDoc_2 = .Item("TotalIlaDoc")
                Dim _TotalBrutoDoc_2 = .Item("TotalBrutoDoc")


                _TotalNetoDoc = De_Num_a_Tx_01(.Item("TotalNetoDoc"), False, 5)
                _TotalIvaDoc = De_Num_a_Tx_01(.Item("TotalIvaDoc"), False, 5)
                _TotalIlaDoc = De_Num_a_Tx_01(.Item("TotalIlaDoc"), False, 5)
                _TotalBrutoDoc = De_Num_a_Tx_01(.Item("TotalBrutoDoc"), False, 5)

                _Fecha_1er_Vencimiento = Format(.Item("Fecha_1er_Vencimiento"), "yyyyMMdd")
                _FechaUltVencimiento = Format(.Item("FechaUltVencimiento"), "yyyyMMdd")

                _FechaRecepcion = Format(.Item("FechaRecepcion"), "yyyyMMdd")

                _Nombre_Entidad = .Item("Nombre_Entidad").ToString
                _Cuotas = .Item("Cuotas").ToString
                _Dias_1er_Vencimiento = .Item("Dias_1er_Vencimiento").ToString
                _Dias_Vencimiento = .Item("Dias_Vencimiento").ToString
                _CodEntidadFisica = NuloPorNro(.Item("CodEntidadFisica").ToString, "")
                _CodSucEntidadFisica = NuloPorNro(.Item("CodSucEntidadFisica").ToString, "")
                _Nombre_Entidad_Fisica = .Item("Nombre_Entidad_Fisica").ToString
                _Contacto_Ent = NuloPorNro(.Item("Contacto_Ent").ToString, "")
                _NomFuncionario = .Item("NomFuncionario").ToString
                _Es_Electronico = Convert.ToInt32(.Item("Es_Electronico"))
                _TipoMoneda = .Item("TipoMoneda").ToString
                _Vizado = Convert.ToInt32(.Item("Vizado"))

                _Fun_Auto_Deuda_Ven = .Item("Fun_Auto_Deuda_Ven").ToString
                _Fun_Auto_Stock_Ins = .Item("Fun_Auto_Stock_Ins").ToString
                _Fun_Auto_Cupo_Exe = .Item("Fun_Auto_Cupo_Exe").ToString
                _Fun_Auto_Sol_Compra = .Item("Fun_Auto_Sol_Compra").ToString

                _Centro_Costo = .Item("Centro_Costo").ToString

                _Reserva_NroOCC = Convert.ToInt32(.Item("Reserva_NroOCC"))
                _Reserva_Idmaeedo = Convert.ToInt32(.Item("Reserva_Idmaeedo"))

                _RevFincred = Convert.ToInt32(.Item("RevFincred"))
                _IdFincred = .Item("IdFincred")
                _MontoFincred = De_Num_a_Tx_01(.Item("MontoFincred"), False, 5)

                _TblTipoVenta = .Item("TblTipoVenta").ToString
                _CodTipoVenta = .Item("CodTipoVenta").ToString

                _Customizable = Convert.ToInt32(.Item("Customizable"))
                _Pickear = Convert.ToInt32(.Item("Pickear"))

            End With

            '------------------------------------------------------------------------------------------------------------

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
            Return 0
        End Try

        Try

            myTrans = cn2.BeginTransaction()

            Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_Casi_DocEnc (Empresa,TipoDoc,NroDocumento,CodEntidad,CodSucEntidad,Stand_by)" & vbCrLf &
                           "VALUES ( '" & _Empresa & "','" & _TipoDoc & "','" & _NroDocumento &
                           "','" & _CodEntidad & "','" & _CodSucEntidad & "'," & Convert.ToInt32(_Stand_by) & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Id_DocEnc = dfd1("Identity")
            End While
            dfd1.Close()

            _Bd_Documento.Tables("Detalle_Doc").Dispose()
            Dim Tbl_Detalle As DataTable = _Bd_Documento.Tables("Detalle_Doc")

            Dim Contador As Integer = 1

            For Each FDetalle As DataRow In Tbl_Detalle.Rows

                Dim Estado As DataRowState = FDetalle.RowState

                Consulta_sql = String.Empty

                If Not Estado = DataRowState.Deleted Then

                    With FDetalle

                        Id_Linea = .Item("Id")

                        _NroLinea = numero_(Contador, 5)

                        _Sucursal_Linea = .Item("Sucursal")
                        _Bodega_Linea = .Item("Bodega")
                        _Codigo = .Item("Codigo")
                        _Descripcion = .Item("Descripcion")
                        _Rtu = De_Num_a_Tx_01(.Item("Rtu"), False, 5)

                        _CodVendedor = .Item("CodFuncionario") ' FUNCIONARIO ' Codigo de funcionario

                        _Tict = .Item("Tict")
                        _Prct = .Item("Prct")
                        _Tipr = .Item("Tipr")

                        _Cantidad = De_Num_a_Tx_01(.Item("Cantidad"), False, 5)
                        _Precio = De_Num_a_Tx_01(.Item("Precio"), False, 5)

                        _CantUd1 = De_Num_a_Tx_01(.Item("CantUd1"), False, 5) ' Cantidad de la primera unidad
                        _CantUd2 = De_Num_a_Tx_01(.Item("CantUd2"), False, 5) ' Cantidad de la segunda unidad

                        _Lincondest = CInt(.Item("Lincondest")) * -1

                        'CantidadTotal = CantidadTotal + Val(CAPRCO1)

                        ' _CDespUd1, _CDespUd2 

                        If CBool(_Lincondesp) Then
                            _CDespUd1 = _CantUd1 ' Cantidad que mueve Stock Fisico, según el producto.
                            _CDespUd2 = _CantUd2 ' Cantidad que mueve Stock Fisico, según el producto.
                        Else
                            _CDespUd1 = De_Num_a_Tx_01(NuloPorNro(.Item("CDespUd1"), 0), False, 5) ' Cantidad que mueve Stock Fisico, según el producto.
                            _CDespUd2 = De_Num_a_Tx_01(NuloPorNro(.Item("CDespUd2"), 0), False, 5) ' Cantidad que mueve Stock Fisico, según el producto.
                        End If

                        _Estado = NuloPorNro(.Item("Estado"), "")

                        Dim _CaprexUd1 = 0 ' Cantidad  
                        Dim _CaprexUd2 = 0
                        Dim _CaprncUd1 = 0 ' Cantidad de Nota de credito
                        Dim _CaprncUd2 = 0

                        _UnTrans = .Item("UnTrans")  ' Unidad de la transaccion
                        _UdTrans = .Item("UdTrans")  ' Unidad de la transaccion

                        _Ud01PR = .Item("Ud01PR")
                        _Ud02PR = .Item("Ud02PR")
                        _CodLista = .Item("CodLista") 'LISTADEPRECIO
                        _Moneda = .Item("Moneda")
                        _Tipo_Moneda = .Item("Tipo_Moneda")
                        _Tipo_Cambio = De_Num_a_Tx_01(.Item("Tipo_Cambio"), False, 5)

                        Dim _Tasadorig_Det As String = De_Num_a_Tx_01(.Item("Tasadorig"), False, 5)

                        _DescuentoPorc = De_Num_a_Tx_01(.Item("DescuentoPorc"), False, 5)
                        _DescuentoValor = De_Num_a_Tx_01(.Item("DescuentoValor"), False, 5)

                        _PorIla = De_Num_a_Tx_01(.Item("PorIla"), False, 5)

                        _Operacion = .Item("Operacion")
                        _Potencia = De_Num_a_Tx_01(.Item("Potencia"), False, 5)

                        Dim Campo = "Precio"

                        _PrecioNetoUd = De_Num_a_Tx_01(.Item("PrecioNetoUd"), False, 5)
                        _PrecioBrutoUd = De_Num_a_Tx_01(NuloPorNro(Of Double)(.Item("PrecioBrutoUd"), 0), False, 5)
                        _PrecioNetoUdLista = De_Num_a_Tx_01(NuloPorNro(Of Double)(.Item("PrecioNetoUdLista"), 0), False, 5)
                        _PrecioBrutoUdLista = De_Num_a_Tx_01(NuloPorNro(Of Double)(.Item("PrecioBrutoUdLista"), 0), False, 0) ' PRECIO BRUTO DE LA LISTA

                        _PorIva = De_Num_a_Tx_01(.Item("PorIva"), True)
                        _NroDscto = De_Num_a_Tx_01(.Item("NroDscto"), True)

                        _NroImpuestos = De_Num_a_Tx_01(.Item("NroImpuestos"), True)

                        _DsctoRealPorc = De_Num_a_Tx_01(.Item("DsctoRealPorc"), False, 5)
                        _DsctoRealValor = De_Num_a_Tx_01(.Item("DsctoRealValor"), False, 5)
                        _DsctoNeto = De_Num_a_Tx_01(.Item("DsctoNeto"), False, 5)
                        _DsctoBruto = De_Num_a_Tx_01(.Item("DsctoBruto"), False, 5) 'ValDscto
                        _ValSubNetoLinea = 0 'De_Num_a_Tx_01(.Item("ValSubNetoLinea"), False, 5)

                        _StockBodega = De_Num_a_Tx_01(.Item("StockBodega"), False, 5)
                        _UbicacionBod = NuloPorNro(.Item("UbicacionBod"), "")

                        _SubTotal = De_Num_a_Tx_01(.Item("SubTotal"), False, 5)

                        _ValNetoLinea = De_Num_a_Tx_01(.Item("ValNetoLinea"), False, 5)
                        _ValIlaLinea = De_Num_a_Tx_01(.Item("ValIlaLinea"), False, 5)
                        _ValIvaLinea = De_Num_a_Tx_01(.Item("ValIvaLinea"), False, 5)
                        _ValBrutoLinea = De_Num_a_Tx_01(.Item("ValBrutoLinea"), False, 5)

                        _FechaEmision_Linea = _Feemdo 'Format(Now.Date, "yyyyMMdd") '""20121127"
                        _FechaRecepcion_Linea = _Feemdo 'Format(Now.Date, "yyyyMMdd")

                        _Observa = NuloPorNro(.Item("Observa"), "")

                        _Centro_Costo_Linea = NuloPorNro(.Item("Centro_Costo"), "")
                        _Proyecto = NuloPorNro(.Item("Proyecto"), "")

                        _PrecioNetoRealUd1 = De_Num_a_Tx_01(.Item("PrecioNetoRealUd1"), False, 5)
                        _PrecioNetoRealUd2 = De_Num_a_Tx_01(.Item("PrecioNetoRealUd2"), False, 5)
                        _PmLinea = De_Num_a_Tx_01(NuloPorNro(.Item("PmLinea"), 0), False, 5)
                        _PmSucLinea = De_Num_a_Tx_01(NuloPorNro(.Item("PmSucLinea"), 0), False, 5)

                        _CodigoProv = NuloPorNro(.Item("CodigoProv"), "")
                        _TipoValor = NuloPorNro(.Item("TipoValor"), "")

                        _ValVtaDescMax = CInt(.Item("ValVtaDescMax")) * -1
                        _ValVtaStockInf = CInt(.Item("ValVtaStockInf")) * -1

                        _DescMaximo = De_Num_a_Tx_01(NuloPorNro(.Item("DescMaximo"), 0), False, 5)

                        _Idmaeedo_Dori = .Item("Idmaeedo_Dori")
                        _Idmaeddo_Dori = .Item("Idmaeddo_Dori")

                        Dim CantUd1_Dori As Double = .Item("CantUd1_Dori")
                        Dim CantUd2_Dori As Double = .Item("CantUd2_Dori")

                        _CantUd1_Dori = De_Num_a_Tx_01(CantUd1_Dori, False, 5)
                        _CantUd2_Dori = De_Num_a_Tx_01(CantUd2_Dori, False, 5)

                        If String.IsNullOrEmpty(_Idmaeddo_Dori) Then _Idmaeddo_Dori = 0

                        _Emprepa = NuloPorNro(.Item("Emprepa"), "")
                        _Tidopa = NuloPorNro(.Item("Tidopa"), "")
                        _NudoPa = NuloPorNro(.Item("NudoPa"), "")
                        _Endopa = NuloPorNro(.Item("Endopa"), "")
                        _Nulidopa = NuloPorNro(.Item("Nulidopa"), "")

                        _DsctoGlobalSuperado = 0
                        _Tiene_Dscto = CInt(.Item("Tiene_Dscto")) * -1
                        _CantidadCalculo = De_Num_a_Tx_01(NuloPorNro(.Item("CantidadCalculo"), 0), False, 5)
                        _PrecioCalculo = De_Num_a_Tx_01(NuloPorNro(.Item("PrecioCalculo"), 0), False, 5)
                        _OCCGenerada = CInt(.Item("Tiene_Dscto")) * -1
                        _Bloqueapr = NuloPorNro(.Item("Bloqueapr"), "")
                        _CodFunAutoriza = NuloPorNro(.Item("CodFunAutoriza"), "")
                        _CodPermiso = NuloPorNro(.Item("CodPermiso"), "")
                        _Nuevo_Producto = CInt(.Item("Nuevo_Producto")) * -1
                        _Solicitado_bodega = CInt(.Item("Nuevo_Producto")) * -1

                        Dim _Crear_CPr = CInt(.Item("Crear_CPr")) * -1
                        Dim _Id_CPr = .Item("Id_CPr")

                        _Id_Oferta = .Item("Id_Oferta")
                        _Es_Padre_Oferta = Convert.ToInt32(.Item("Es_Padre_Oferta"))
                        _Oferta = .Item("Oferta")
                        _Padre_Oferta = .Item("Padre_Oferta")
                        _Aplica_Oferta = Convert.ToInt32(.Item("Aplica_Oferta"))
                        _Hijo_Oferta = .Item("Hijo_Oferta")
                        _Cantidad_Oferta = De_Num_a_Tx_01(.Item("Cantidad_Oferta"), False, 5)
                        _Porcdesc_Oferta = De_Num_a_Tx_01(.Item("Porcdesc_Oferta"), False, 5)

                        _Nmarca = .Item("Nmarca")
                        _RtuVariable = Convert.ToUInt32(.Item("RtuVariable"))
                        _Espuntosvta = Convert.ToUInt32(.Item("Espuntosvta"))
                        _ModFechVto = Convert.ToUInt32(.Item("ModFechVto"))
                        _Condicionado = Convert.ToUInt32(.Item("Condicionado"))

                        If Not String.IsNullOrEmpty(Trim(_Tict)) Then

                            Dim _Uno = 1

                            If _Tict = "D" Then
                                _Uno = -1
                            End If

                            If _TipoValor = "N" Then
                                _CantUd1 = De_Num_a_Tx_01(.Item("ValNetoLinea") * _Uno, False, 5)
                            Else
                                _CantUd1 = De_Num_a_Tx_01(.Item("ValBrutoLinea") * _Uno, 0)
                            End If

                            _CantUd2 = 0
                            _Caprad2 = 0
                            _Cafaco = 0
                            _PrecioNetoUdLista = 0
                            _PrecioNetoUd = 0
                            _PrecioBrutoUdLista = 0
                            _PrecioBrutoUd = 0
                            _Prct = 1
                            _PmLinea = 0
                            _PmSucLinea = 0
                            _Lincondesp = 1
                            _NroDscto = 0
                            _Estado = "C"
                        Else
                            _Cafaco = _CantUd1
                        End If

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock (Empresa,Sucursal,Bodega,Codigo)" & vbCrLf &
                                       "Select '" & _Empresa & "','" & _Sucursal_Linea & "','" & _Bodega_Linea & "','" & _Codigo & "'" & vbCrLf &
                                       "From MAEPR" & vbCrLf &
                                       "Where KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Stock" & Space(1) &
                                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal_Linea & "' And Bodega = '" & _Bodega_Linea & "' And" & Space(1) &
                                       "Codigo = '" & _Codigo & "') And KOPR = '" & _Codigo & "'"
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        If Not _Stand_by Then

                            If _TipoDoc = "NVV" Then

                                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Stock Set" & vbCrLf &
                                               "StComp1 = StComp1 +" & _CantUd1 & "," &
                                               "StComp2 = StComp2 + " & _CantUd2 & vbCrLf &
                                               "Where Empresa ='" & _Empresa & "' And Sucursal ='" & _Sucursal_Linea & "' And Bodega ='" & _Bodega_Linea &
                                               "' And Codigo = '" & _Codigo & "'"

                                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()

                            End If

                        End If

                        _Descripcion = Replace(_Descripcion, "'", "''")

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Casi_DocDet " & vbCrLf &
                                       "(Id_DocEnc,Empresa,Sucursal,Bodega,UnTrans,Lincondest,NroLinea,Codigo,CodigoProv," &
                                       "UdTrans,Cantidad,TipoValor,Precio,DescuentoPorc,DescuentoValor,Descripcion," &
                                       "PrecioNetoUd,PrecioNetoUdLista,PrecioBrutoUd,PrecioBrutoUdLista,Rtu,Ud01PR,CantUd1," &
                                       "CDespUd1,CaprexUd1,CaprncUd1,CodVendedor,Prct,Tict,Tipr,DsctoNeto,DsctoBruto,Ud02PR," &
                                       "CantUd2,CDespUd2,CaprexUd2,CaprncUd12,ValVtaDescMax,ValVtaStockInf,CodLista," &
                                       "DescMaximo,NroDscto,NroImpuestos,PorIva,PorIla,ValIvaLinea,ValIlaLinea,ValSubNetoLinea," &
                                       "ValNetoLinea,ValBrutoLinea,PmLinea,PmSucLinea,PrecioNetoRealUd1,PrecioNetoRealUd2," &
                                       "FechaEmision_Linea,FechaRecepcion_Linea," &
                                       "Idmaeedo_Dori,Idmaeddo_Dori,CantUd1_Dori,CantUd2_Dori,Estado,Emprepa,Tidopa,NudoPa,Endopa,Nulidopa,SubTotal," &
                                       "StockBodega,UbicacionBod,DsctoRealPorc,DsctoRealValor,DsctoGlobalSuperado,Tiene_Dscto,CantidadCalculo," &
                                       "Operacion,Potencia,PrecioCalculo,OCCGenerada,Bloqueapr,Observa,CodFunAutoriza," &
                                       "CodPermiso,Nuevo_Producto,Solicitado_bodega,Moneda,Tipo_Moneda,Tipo_Cambio,Crear_CPr,Id_CPr," &
                                       "Centro_Costo,Proyecto,Tasadorig," &
                                       "Id_Oferta,Es_Padre_Oferta,Oferta,Padre_Oferta,Aplica_Oferta,Hijo_Oferta," &
                                       "Cantidad_Oferta,Porcdesc_Oferta,IdDet_Ori,Nmarca,RtuVariable,Espuntosvta,ModFechVto,Condicionado) Values" & vbCrLf &
                                       "(" & _Id_DocEnc & ",'" & _Empresa & "','" & _Sucursal_Linea & "','" & _Bodega_Linea & "'," & _UnTrans & "," & _Lincondest &
                                       ",'" & _NroLinea & "','" & _Codigo & "','" & _CodigoProv & "','" & _UdTrans &
                                       "'," & _Cantidad & ",'" & _TipoValor & "'," & _Precio & "," & _DescuentoPorc &
                                       "," & _DescuentoValor & ",'" & _Descripcion & "'," & _PrecioNetoUd &
                                       "," & _PrecioNetoUdLista & "," & _PrecioBrutoUd & "," & _PrecioBrutoUdLista &
                                       "," & _Rtu & ",'" & _Ud01PR & "'," & _CantUd1 & "," & _CDespUd1 & "," & _CaprexUd1 &
                                       "," & _CaprncUd1 & ",'" & _CodVendedor & "'," & _Prct & ",'" & _Tict & "','" & _Tipr &
                                       "'," & _DsctoNeto & "," & _DsctoBruto & ",'" & _Ud02PR & "'," & _CantUd2 &
                                       "," & _CDespUd2 & "," & _CaprexUd2 & "," & _CaprncUd2 & "," & _ValVtaDescMax &
                                       "," & _ValVtaStockInf & ",'" & _CodLista & "'," & _DescMaximo & "," & _NroDscto &
                                       "," & _NroImpuestos & "," & _PorIva & "," & _PorIla & "," & _ValIvaLinea &
                                       "," & _ValIlaLinea & "," & _ValSubNetoLinea & "," & _ValNetoLinea &
                                       "," & _ValBrutoLinea & "," & _PmLinea & "," & _PmSucLinea & "," & _PrecioNetoRealUd1 &
                                       "," & _PrecioNetoRealUd2 & ",'" & _FechaEmision & "','" & _FechaRecepcion &
                                       "'," & _Idmaeedo_Dori & "," & _Idmaeddo_Dori & "," & _CantUd1_Dori & "," & _CantUd2_Dori &
                                       ",'" & _Estado & "','" & _Emprepa & "','" & _Tidopa & "','" & _NudoPa & "','" & _Endopa &
                                       "','" & _Nulidopa & "'," & _SubTotal & "," & _StockBodega & ",'" & Trim(_UbicacionBod) & "'," & _DsctoRealPorc &
                                       "," & _DsctoRealValor & "," & _DsctoGlobalSuperado & "," & _Tiene_Dscto & "," & _CantidadCalculo &
                                       ",'" & _Operacion & "'," & _Potencia & "," & _PrecioCalculo & "," & _OCCGenerada &
                                       ",'" & _Bloqueapr & "','" & _Observa & "','" & _CodFunAutoriza & "','" & _CodPermiso &
                                       "'," & _Nuevo_Producto & "," & _Solicitado_bodega & ",'" & _Moneda & "','" & _Tipo_Moneda &
                                       "'," & _Tipo_Cambio & "," & _Crear_CPr & "," & _Id_CPr & ",'" & _Centro_Costo_Linea &
                                       "','" & _Proyecto & "'," & _Tasadorig_Det &
                                       "," & _Id_Oferta & "," & _Es_Padre_Oferta & ",'" & _Oferta & "'," & _Padre_Oferta & "," & _Aplica_Oferta & "," & _Hijo_Oferta &
                                       "," & _Cantidad_Oferta & "," & _Porcdesc_Oferta & "," & Id_Linea &
                                       ",'" & _Nmarca & "'," & _RtuVariable & "," & _Espuntosvta & "," & _ModFechVto & "," & _Condicionado & ")"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Dim _Id_DocDet As Integer

                        Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                        Comando.Transaction = myTrans
                        dfd1 = Comando.ExecuteReader()
                        While dfd1.Read()
                            _Id_DocDet = dfd1("Identity")
                        End While
                        dfd1.Close()

                        If CBool(_Crear_CPr) Then

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolCreapr Set Id_DocDet = " & _Id_DocDet & vbCrLf &
                                           "Where Id_CPr = " & _Id_CPr
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End With


                    ' TABLA DE IMPUESTOS

                    Dim Tbl_Impuestos As DataTable = _Bd_Documento.Tables("Impuestos_Doc")


                    If Val(_NroImpuestos) > 0 And String.IsNullOrEmpty(Trim(_Tict)) Then

                        For Each FImpto As DataRow In Tbl_Impuestos.Rows 'Select("Id = " & Id_Linea)

                            Dim _EstadoImp As DataRowState = FImpto.RowState

                            If Not _EstadoImp = DataRowState.Deleted Then

                                Dim _Id = FImpto.Item("Id")

                                If _Id = Id_Linea Then

                                    Dim _Poimli As String = De_Num_a_Tx_01(FImpto.Item("Poimli").ToString, False, 5)
                                    Dim _Koimli As String = FImpto.Item("Koimli").ToString
                                    Dim _Vaimli = De_Num_a_Tx_01(FImpto.Item("Vaimli").ToString, False, 5)

                                    Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_Casi_DocImp (Id_DocEnc,Nulido,Koimli,Poimli,Vaimli,Lilg) VALUES " & vbCrLf &
                                                   "(" & _Id_DocEnc & ",'" & _Nulido & "','" & _Koimli & "'," & _Poimli & "," & _Vaimli & ",'')"

                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                    '-- 3RA TRANSACCION--------------------------------------------------------------------

                                End If

                            End If

                        Next

                    End If

                    ' TABLA DE DESCUENTOS
                    Dim Tbl_Descuentos As DataTable = _Bd_Documento.Tables("Descuentos_Doc")
                    _Nudtli = Tbl_Descuentos.Rows.Count

                    If Val(_Nudtli) > 0 And String.IsNullOrEmpty(Trim(_Tict)) Then

                        For Each FDscto As DataRow In Tbl_Descuentos.Rows

                            Dim _EstadoDscto As DataRowState = FDscto.RowState

                            If Not _EstadoDscto = DataRowState.Deleted Then

                                Dim _Id = FDscto.Item("Id")

                                If _Id = Id_Linea Then

                                    Dim _Podt = De_Num_a_Tx_01(FDscto.Item("Podt").ToString, False, 5)
                                    Dim _Vadt = De_Num_a_Tx_01(FDscto.Item("Vadt").ToString, False, 5)

                                    Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_Casi_DocDsc (Id_DocEnc,Nulido,Kodt,Podt,Vadt)" & vbCrLf &
                                       "values (" & _Id_DocEnc & ",'" & _NroLinea & "','D_SIN_TIPO'," & _Podt & "," & _Vadt & ")"

                                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                                    Comando.Transaction = myTrans
                                    Comando.ExecuteNonQuery()

                                    '-- 4TA TRANSACCION--------------------------------------------------------------------

                                End If

                            End If

                        Next

                    End If

                    Contador += 1

                End If

            Next

            If _Nuvedo = 0 Then _Nuvedo = 1

            If _EsAjuste Then
                _Marca = 1 ' Generalmente se marcan las GRI o GDI que son por ajuste
                _SubTido = "AJU" ' Generalmente se Marcan las Guias de despacho o recibo
                '_HH = 23 : _MM = 59 : _SS = 59
            Else
                _Marca = String.Empty
            End If

            _HoraGrab = Hora_Grab_fx(_EsAjuste)

            Dim _Espgdo As String = "P"
            If _Tido = "OCC" Then _Espgdo = "S"

            ' HAY QUE PONER EL CAMPO TIPO DE MONEDA  "TIMODO"

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Casi_DocEnc SET" & Environment.NewLine &
                           "Modalidad = '" & _Modalidad & "'" & Environment.NewLine &
                           ",Sucursal = '" & _Sucursal_Doc & "'" & Environment.NewLine &
                           ",Nombre_Entidad = '" & _Nombre_Entidad & "'" & Environment.NewLine &
                           ",FechaEmision = '" & _FechaEmision & "'" & Environment.NewLine &
                           ",Fecha_1er_Vencimiento = '" & _Fecha_1er_Vencimiento & "'" & Environment.NewLine &
                           ",FechaUltVencimiento = '" & _FechaUltVencimiento & "'" & Environment.NewLine &
                           ",FechaRecepcion = '" & _FechaRecepcion & "'" & Environment.NewLine &
                           ",Cuotas = '" & _Cuotas & "'" & Environment.NewLine &
                           ",Dias_1er_Vencimiento = '" & _Dias_1er_Vencimiento & "'" & Environment.NewLine &
                           ",Dias_Vencimiento = '" & _Dias_Vencimiento & "'" & Environment.NewLine &
                           ",ListaPrecios = '" & _ListaPrecios & "'" & Environment.NewLine &
                           ",CodEntidadFisica = '" & _CodEntidadFisica & "'" & Environment.NewLine &
                           ",CodSucEntidadFisica = '" & _CodSucEntidadFisica & "'" & Environment.NewLine &
                           ",Nombre_Entidad_Fisica = '" & _Nombre_Entidad_Fisica & "'" & Environment.NewLine &
                           ",Contacto_Ent = '" & _Contacto_Ent & "'" & Environment.NewLine &
                           ",CodFuncionario = '" & _CodFuncionario & "'" & Environment.NewLine &
                           ",NomFuncionario = '" & _NomFuncionario & "'" & Environment.NewLine &
                           ",Centro_Costo = '" & _Centro_Costo & "'" & Environment.NewLine &
                           ",Moneda_Doc = '" & _Moneda_Doc & "'" & Environment.NewLine &
                           ",Valor_Dolar = " & _Valor_Dolar & Environment.NewLine &
                           ",TotalNetoDoc = " & _TotalNetoDoc & Environment.NewLine &
                           ",TotalIvaDoc = " & _TotalIvaDoc & Environment.NewLine &
                           ",TotalIlaDoc = " & _TotalIlaDoc & Environment.NewLine &
                           ",TotalBrutoDoc = " & _TotalBrutoDoc & Environment.NewLine &
                           ",CantTotal = " & _CantTotal & Environment.NewLine &
                           ",CantDesp = " & _CantDesp & Environment.NewLine &
                           ",DocEn_Neto_Bruto = '" & _DocEn_Neto_Bruto & "'" & Environment.NewLine &
                           ",Es_ValeTransitorio = " & CInt(_Es_ValeTransitorio) & Environment.NewLine &
                           ",Es_Electronico = " & _Es_Electronico & Environment.NewLine &
                           ",TipoMoneda = '" & _TipoMoneda & "'" & Environment.NewLine &
                           ",Vizado = '" & _Vizado & "'" & Environment.NewLine &
                           ",Fun_Auto_Deuda_Ven = '" & _Fun_Auto_Deuda_Ven & "'" & Environment.NewLine &
                           ",Fun_Auto_Stock_Ins = '" & _Fun_Auto_Stock_Ins & "'" & Environment.NewLine &
                           ",Fun_Auto_Cupo_Exe = '" & _Fun_Auto_Cupo_Exe & "'" & Environment.NewLine &
                           ",Fun_Auto_Sol_Compra = '" & _Fun_Auto_Sol_Compra & "'" & Environment.NewLine &
                           ",SubTido = '" & _SubTido & "'" & Environment.NewLine &
                           ",Reserva_NroOCC = " & _Reserva_NroOCC & Environment.NewLine &
                           ",Reserva_Idmaeedo = " & _Reserva_Idmaeedo & Environment.NewLine &
                           ",RevFincred = " & _RevFincred & Environment.NewLine &
                           ",IdFincred = " & _IdFincred & Environment.NewLine &
                           ",MontoFincred = " & _MontoFincred & Environment.NewLine &
                           ",TblTipoVenta = '" & _TblTipoVenta & "'" & Environment.NewLine &
                           ",CodTipoVenta = '" & _CodTipoVenta & "'" & Environment.NewLine &
                           ",Customizable = '" & _Customizable & "'" & Environment.NewLine &
                           ",Pickear = '" & _Pickear & "'" & Environment.NewLine &
                           "Where Id_DocEnc = " & _Id_DocEnc

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            '=========================================== OBSERVACIONES ==================================================================

            Dim Tbl_Observaciones As DataTable = _Bd_Documento.Tables("Observaciones_Doc")

            With Tbl_Observaciones

                Dim _Observaciones As String = .Rows(0).Item("Observaciones").ToString.Trim
                Dim _Forma_pago As String = .Rows(0).Item("Forma_pago").ToString.Trim
                Dim _Orden_compra As String = .Rows(0).Item("Orden_compra").ToString.Trim

                Dim _Placa As String = .Rows(0).Item("Placa").ToString.Trim
                Dim _CodRetirador As String = .Rows(0).Item("CodRetirador").ToString.Trim

                For i = 0 To 34

                    Dim Campo As String = "Obs" & i + 1
                    Obs(i) = .Rows(0).Item(Campo)

                Next

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Casi_DocObs (Id_DocEnc,Observaciones,Forma_pago,Orden_compra,Obs1," &
                               "Obs2,Obs3,Obs4,Obs5,Obs6,Obs7,Obs8,Obs9,Obs10," &
                               "Obs11,Obs12,Obs13,Obs14,Obs15,Obs16,Obs17,Obs18,Obs19,Obs20,Obs21,Obs22,Obs23,Obs24,Obs25,Obs26," &
                               "Obs27,Obs28,Obs29,Obs30,Obs31,Obs32,Obs33,Obs34,Obs35,Placa,CodRetirador) Values " & vbCrLf &
                               "(" & _Id_DocEnc & ",'" & _Observaciones & "','" & _Forma_pago & "','" & _Orden_compra &
                               "','" & Obs(0) & "','" & Obs(1) & "','" & Obs(2) & "','" & Obs(3) & "','" & Obs(4) & "','" & Obs(5) &
                               "','" & Obs(6) & "','" & Obs(7) & "','" & Obs(8) & "','" & Obs(9) & "','" & Obs(10) &
                               "','" & Obs(11) & "','" & Obs(12) & "','" & Obs(13) & "','" & Obs(14) & "','" & Obs(15) &
                               "','" & Obs(16) & "','" & Obs(17) & "','" & Obs(18) & "','" & Obs(19) & "','" & Obs(20) &
                               "','" & Obs(21) & "','" & Obs(22) & "','" & Obs(23) & "','" & Obs(24) & "','" & Obs(25) &
                               "','" & Obs(26) & "','" & Obs(27) & "','" & Obs(28) & "','" & Obs(29) & "','" & Obs(30) &
                               "','" & Obs(31) & "','" & Obs(32) & "','" & Obs(33) & "','" & Obs(34) & "','" & _Placa & "','" & _CodRetirador & "')"


                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With
            ' ====================================================================================================================================

            If Not _Stand_by Then

                Dim _Tbl_Permisos As DataTable = _Bd_Documento.Tables("Permisos_Doc")

                Consulta_sql = String.Empty

                For Each _Fila As DataRow In _Tbl_Permisos.Rows

                    Dim _CodPermiso_ = _Fila.Item("CodPermiso")
                    Dim _DescripcionPermiso = _Fila.Item("DescripcionPermiso")
                    Dim _Necesita_Permiso = Convert.ToInt32(_Fila.Item("Necesita_Permiso"))
                    Dim _Autorizado = Convert.ToInt32(_Fila.Item("Autorizado"))
                    Dim _CodFuncionario_Autoriza = _Fila.Item("CodFuncionario_Autoriza")
                    Dim _NomFuncionario_Autoriza = _Fila.Item("NomFuncionario_Autoriza")
                    Dim _NroRemota = _Fila.Item("NroRemota")
                    Dim _Permiso_Presencial = Convert.ToInt32(_Fila.Item("Permiso_Presencial"))
                    Dim _Solicitado_Por_Cadena = Convert.ToInt32(_Fila.Item("Solicitado_Por_Cadena"))

                    If _Necesita_Permiso Then

                        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Casi_DocPer (Id_DocEnc,CodPermiso,DescripcionPermiso,Necesita_Permiso,Autorizado," &
                                    "CodFuncionario_Autoriza,NomFuncionario_Autoriza,NroRemota,Permiso_Presencial,Solicitado_Por_Cadena) Values 
                                (" & _Id_DocEnc & ",'" & _CodPermiso_ & "','" & _DescripcionPermiso & "'," & _Necesita_Permiso & "," & _Autorizado & "," &
                                    "'" & _CodFuncionario_Autoriza & "','" & _NomFuncionario_Autoriza &
                                    "','" & _NroRemota & "'," & _Permiso_Presencial & "," & _Solicitado_Por_Cadena & ")" & Environment.NewLine

                    End If

                Next

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_sql = Fx_Referencias_DTE(_Id_DocEnc, _Tbl_Referencias_DTE, True)

                If Not String.IsNullOrEmpty(Consulta_sql) Then

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

            End If

            ' ========================================== INCORPORAR EVENTOS =====================================================================

            Consulta_sql = Fx_Tag_Mevento(_Id_DocEnc, _Tbl_Mevento_Edo)

            If Not String.IsNullOrEmpty(Consulta_sql) Then

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Casi_DocArc") Then

                Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Casi_DocArc (Id_DocEnc,Nombre_Archivo,Archivo,Fecha,CodFuncionario,En_Construccion," &
                               "NombreEquipo,Idmaeedo)" & vbCrLf &
                               "Select " & _Id_DocEnc & ",Nombre_Archivo,Archivo,Fecha,CodFuncionario,0,'',Idmaeedo" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Casi_DocArc" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'"
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                'Consulta_sql = "Update " & _Global_BaseBk & "Zw_Casi_DocArc Set Id_DocEnc = " & _Id_DocEnc & ",En_Construccion = 0,NombreEquipo = '' Where NombreEquipo = '" & _NombreEquipo & "'"
                'Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()

            End If

            If _Reserva_NroOCC Then

                Dim _Rs_Id_DocEnc As Integer = Tbl_Encabezado.Rows(0).Item("Id_DocEnc")

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Rs_Id_DocEnc & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Casi_DocObs Where Id_DocEnc = " & _Rs_Id_DocEnc
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            If Tbl_Encabezado.Rows(0).Item("PreVenta") AndAlso Tbl_Encabezado.Rows(0).Item("IdCont") > 0 Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Contenedor_DocTom Set Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                               "Where IdCont = " & Tbl_Encabezado.Rows(0).Item("IdCont")
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            'Throw New System.Exception("An exception has occurred.")

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return _Id_DocEnc

        Catch ex As Exception

            Dim _Erro_VB As String = ex.Message & vbCrLf & ex.StackTrace & vbCrLf &
                                     "Código: " & _Koprct
            Clipboard.SetText(_Erro_VB)

            My.Computer.FileSystem.WriteAllText("ArchivoSalida", ex.Message & vbCrLf & ex.StackTrace, False)
            MessageBoxEx.Show(ex.Message, "Error",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            Return 0
        End Try

    End Function

#End Region

#Region "EDITAR DOCUMENTO"

    Function Fx_Editar_Documento(_Formulario As Form,
                                 _Idmaeedo As Integer,
                                 _Cod_Func_Eliminado As String,
                                 Bd_Documento As DataSet,
                                 ByRef _Origen_Modificado_Intertanto As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        ' Obtengo el tipo y numero de documento que hay que modificar
        Dim _Tipo_de_documento As String = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO", "IDMAEEDO = " & _Idmaeedo)
        Dim _Numero_de_documento As String = _Sql.Fx_Trae_Dato("MAEEDO", "NUDO", "IDMAEEDO = " & _Idmaeedo)

        ' Obtengo la fecha del servidor para poner la fecha de eliminación del documento
        Dim _FechaEliminacion = FechaDelServidor()

        _Mensaje = Fx_Crear_Documento(_Tipo_de_documento,
                                      _Numero_de_documento,
                                      False,
                                      False,
                                      Bd_Documento,
                                      False,, _Origen_Modificado_Intertanto)

        If _Mensaje.EsCorrecto Then

            Dim _Class_E As New Clas_Cerrar_Anular_Eliminar_Documento_Origen

            Dim _Eliminado As Boolean = _Class_E.Fx_EliminarAnular_Doc(_Formulario,
                                                                       _Idmaeedo,
                                                                       _Cod_Func_Eliminado,
                                                                       Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Modificar,
                                                                       False, False)

            If _Eliminado Then

                Consulta_sql = "Update MAEEDO Set NUDO = '" & _Numero_de_documento & "' Where IDMAEEDO = " & _Mensaje.Id & vbCrLf &
                               "Update MAEDDO Set NUDO = '" & _Numero_de_documento & "' Where IDMAEEDO = " & _Mensaje.Id
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    _Mensaje.EsCorrecto = True
                    _Mensaje.Detalle = "Editar documento"
                    _Mensaje.Mensaje = "Documento modificado correctamente"

                    Return _Mensaje

                End If

            Else

                _Class_E.Fx_EliminarAnular_Doc(_Formulario,
                                               _Mensaje.Id,
                                               _Cod_Func_Eliminado,
                                               Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Modificar,
                                               False, False)
            End If

        End If

        Return _Mensaje

    End Function

#End Region

    Function Fx_Campo_Mov_Stock_Adicional_Old(_Tido_Origen As String,
                                              _Tido As String,
                                              _Subtido As String,
                                              _Lincondesp As Boolean,
                                              _Idrst As Integer) As List(Of String)

        Dim _TidoSubtido As String = _Tido.Trim() & _Subtido.Trim
        Dim _Campos As New List(Of String)

        Select Case _TidoSubtido

            Case "FCV", "FDB", "FDV", "FDX", "FEV", "FVL", "FVT", "FVX", "BLV"

                If _Tido_Origen = "GDV" Or _Tido_Origen = "GDP" Then
                    _Campos.Add("DESPNOFAC1")
                    _Campos.Add("DESPNOFAC2")
                Else
                    If (Not _Lincondesp And Not (CBool(_Idrst))) Then
                        _Campos.Add("STDV1")
                        _Campos.Add("STDV2")
                    End If
                End If

            Case "GDV"

                Select Case _Tido_Origen
                    Case "FCV", "FDB", "FDV", "FDX", "FEV", "FVL", "FVT", "FVX", "BLV"
                        _Campos.Add("STDV1")
                        _Campos.Add("STDV2")
                    Case Else
                        _Campos.Add("DESPNOFAC1")
                        _Campos.Add("DESPNOFAC2")
                End Select

            Case "GDPPRE"
                _Campos.Add("PRESALCLI1")
                _Campos.Add("PRESALCLI2")
            Case "OCI", "OCC"
                _Campos.Add("STOCNV1C")
                _Campos.Add("STOCNV2C")
            Case "NVI", "NVV"
                _Campos.Add("STOCNV1")
                _Campos.Add("STOCNV2")

        End Select

        Return _Campos

    End Function

    Function Fx_Campo_Mov_Stock_Adicional_Suma(_Tido As String,
                                               _Subtido As String,
                                               _Lincondesp As Boolean,
                                               _Tidopa As String) As List(Of String)

        Dim _TidoSubtido As String = _Tido.Trim() & _Subtido.Trim
        Dim _Campos As New List(Of String)

        Select Case _Tido

            Case "FCV", "FDB", "FDV", "FDX", "FEV", "FVL", "FVT", "FVX", "BLV"

                If Not _Lincondesp And Not (_Tidopa = "GDV" Or _Tidopa = "GDP") Then
                    _Campos.Add("STDV1")
                    _Campos.Add("STDV2")
                End If

            Case "GDV"

                If String.IsNullOrEmpty(_Tidopa) Or _Tidopa = "NVV" Or _Tidopa = "COV" Then
                    _Campos.Add("DESPNOFAC1")
                    _Campos.Add("DESPNOFAC2")
                End If

            Case "GDP"

                If _Subtido = "PRE" Then
                    _Campos.Add("PRESALCLI1")
                    _Campos.Add("PRESALCLI2")
                End If

                If _Subtido = "CON" Then
                    _Campos.Add("CONSALCLI1")
                    _Campos.Add("CONSALCLI2")
                End If

            Case "OCI", "OCC"

                _Campos.Add("STOCNV1C")
                _Campos.Add("STOCNV2C")

            Case "NVI", "NVV"

                _Campos.Add("STOCNV1")
                _Campos.Add("STOCNV2")

            Case "GRC"

                If _Tidopa <> "FCC" Then
                    _Campos.Add("RECENOFAC1")
                    _Campos.Add("RECENOFAC2")
                End If

            Case "FCC"

                If Not _Lincondesp And _Tidopa <> "GRC" Then
                    _Campos.Add("STDV1C")
                    _Campos.Add("STDV1C")
                End If

            Case "GTI"

                _Campos.Add("STTR1")
                _Campos.Add("STTR2")

            Case "GDI"

                If _Subtido = "GTI" Then
                    _Campos.Add("STTR1")
                    _Campos.Add("STTR2")
                End If

            Case "GDD"

                If _Subtido = String.Empty Then
                    _Campos.Add("DEVSINNCC1")
                    _Campos.Add("DEVSINNCC2")
                End If

                If _Subtido = "PRE" Then
                    _Campos.Add("PRESDEPRO1")
                    _Campos.Add("PRESDEPRO2")
                End If

                If _Subtido = "CON" Then
                    _Campos.Add("CONSDEPRO1")
                    _Campos.Add("CONSDEPRO2")
                End If

            Case "GRD"

                If _Tidopa <> "NCV" Then
                    _Campos.Add("DEVSINNCV1")
                    _Campos.Add("DEVSINNCV2")
                End If

        End Select

        Return _Campos

    End Function

    Function Fx_Campo_Mov_Stock_Adicional_Resta(_Tido As String, _Tidopa As String) As List(Of String)

        Dim _Campos As New List(Of String)

        Select Case _Tidopa

            Case "FCV", "FDB", "FDV", "FDX", "FEV", "FVL", "FVT", "FVX", "BLV"

                If _Tido = "GDV" Or _Tido = "GDP" Then
                    _Campos.Add("STDV1")
                    _Campos.Add("STDV2")
                End If

            Case "GDV"

                Select Case _Tido

                    Case "FCV", "FDB", "FDV", "FDX", "FEV", "FVL", "FVT", "FVX", "BLV"
                        _Campos.Add("DESPNOFAC1")
                        _Campos.Add("DESPNOFAC2")
                    Case Else

                End Select

            Case "GDPPRE"

                _Campos.Add("PRESALCLI1")
                _Campos.Add("PRESALCLI2")

            Case "OCI", "OCC"

                _Campos.Add("STOCNV1C")
                _Campos.Add("STOCNV2C")

            Case "NVI", "NVV"

                _Campos.Add("STOCNV1")
                _Campos.Add("STOCNV2")

            Case "GRC"

                If _Tido = "FCC" Then
                    _Campos.Add("RECENOFAC1")
                    _Campos.Add("RECENOFAC2")
                End If

            Case "FCC"

                If _Tido = "GRC" Then
                    _Campos.Add("STDV1C")
                    _Campos.Add("STDV2C")
                End If

            Case "GTI"

                _Campos.Add("STTR1")
                _Campos.Add("STTR2")

            Case "GTI", "GDI"

                _Campos.Add("STTR1")
                _Campos.Add("STTR2")

            Case "NCV"

                _Campos.Add("DEVENGNCV1")
                _Campos.Add("DEVENGNCV2")

            Case "OTL"

                _Campos.Add("STENFAB1")
                _Campos.Add("STENFAB2")

        End Select

        Return _Campos

    End Function

End Class
