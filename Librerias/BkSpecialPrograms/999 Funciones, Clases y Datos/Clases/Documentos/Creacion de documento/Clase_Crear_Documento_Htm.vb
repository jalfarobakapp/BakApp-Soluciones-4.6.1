Imports DevComponents.DotNetBar

Public Class Clase_Crear_Documento_Htm

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Function Fx_Crear_Documento_Htm(_IdMaeedo As Integer,
                                    _Ruta_Archivo As String,
                                    Optional _Mostrar_Precios As Boolean = True) As Boolean
        Try

            ' Acento en Html
            'a = &aacute;
            'é = &eacute;
            'í = &iacute;
            'ó = &oacute;
            'ú = &uacute;
            'ñ = &ntilde;
            'Ñ = &Ntilde;


            Consulta_sql = My.Resources.Rc_ConsultasSQL.Traer_Datos_Documento
            Consulta_sql = Replace(Consulta_sql, "#IdMaeedo#", _IdMaeedo)

            Dim Ds_ As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim Encabezado_tb As DataTable = Ds_.Tables(0)
            Dim Detalle_tb As DataTable = Ds_.Tables(1)
            Dim Detalle_Impuestos_tb As DataTable = Ds_.Tables(2)
            Dim Detalle_Descuentos_tb As DataTable = Ds_.Tables(3)

            Dim Vencimientos_tb As DataTable = Ds_.Tables(4)
            Dim Observaciones_tb As DataTable = Ds_.Tables(5)
            Dim Suma_SubTotales_tb As DataTable = Ds_.Tables(6)


            Dim Documento_Htm As String


            If _Mostrar_Precios Then
                Documento_Htm = My.Resources.Rc_ConsultasSQL.Crear_Htm_document
            Else
                Documento_Htm = My.Resources.Rc_ConsultasSQL.Crear_Htm_document_Sp
            End If


            Documento_Htm = Replace(Documento_Htm, "#Emisor#", UCase(RazonEmpresa))
            Documento_Htm = Replace(Documento_Htm, "#RUT_Emisor#", RutEmpresa)
            Documento_Htm = Replace(Documento_Htm, "#Direccion_Emisor#", DireccionEmpresa)
            Documento_Htm = Replace(Documento_Htm, "#Tipo_de_Documento#", Encabezado_tb.Rows(0).Item("Tipo_de_Documento"))
            Documento_Htm = Replace(Documento_Htm, "#Tido#", Encabezado_tb.Rows(0).Item("TIDO"))
            Documento_Htm = Replace(Documento_Htm, "#Numero_de_Documento#", Encabezado_tb.Rows(0).Item("NUDO"))

            Dim _Koen = Encabezado_tb.Rows(0).Item("ENDO")
            Dim _Suen = Encabezado_tb.Rows(0).Item("SUENDO")

            Dim _TblEntidad As DataTable = Fx_Traer_Datos_Entidad_Tabla(_Koen, _Suen)


            Dim _Rut As String = _TblEntidad.Rows(0).Item("RTEN")
            _Rut = Replace(FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut), ",", ".")

            Documento_Htm = Replace(Documento_Htm, "#Proveedor#", _TblEntidad.Rows(0).Item("NOKOEN"))
            Documento_Htm = Replace(Documento_Htm, "#Rut_Proveedor#", _Rut)
            Documento_Htm = Replace(Documento_Htm, "#Direccion_Proveedor#", _TblEntidad.Rows(0).Item("DIEN"))
            Documento_Htm = Replace(Documento_Htm, "#Fecha_de_Emision#", Encabezado_tb.Rows(0).Item("FEEMDO"))
            Documento_Htm = Replace(Documento_Htm, "#Fecha_Ult.Vencimiento#", Encabezado_tb.Rows(0).Item("FEULVEDO"))
            Documento_Htm = Replace(Documento_Htm, "#Compromiso_de_Despacho#", NuloPorNro(Encabezado_tb.Rows(0).Item("FEER"), ""))

            Dim _Endofi = Trim(Encabezado_tb.Rows(0).Item("ENDOFI"))
            Dim _NomEntFisica = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _Endofi & "'")

            _Rut = String.Empty

            If Not String.IsNullOrEmpty(_Endofi) Then
                _Rut = _Sql.Fx_Trae_Dato("MAEEN", "RTEN", "KOEN = '" & _Endofi & "'")
                _Rut = Replace(FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut), ",", ".")
            End If


            Documento_Htm = Replace(Documento_Htm, "#Entidad_fisica#", _NomEntFisica)
            Documento_Htm = Replace(Documento_Htm, "#Rut_Entidad_fisica#", _Rut)

            Consulta_sql = "Select Distinct TIDOPA+'-'+NUDOPA As Codigo,'' As Descripcion From MAEDDO Where IDMAEEDO = " & _IdMaeedo
            Dim _TblDocPrevios As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim _Doc_Previos = String.Empty

            If CBool(_TblDocPrevios.Rows.Count) Then
                _Doc_Previos = Generar_Filtro_IN(_TblDocPrevios, "", "Codigo", False, False, "")
                _Doc_Previos = Replace(_Doc_Previos, "(", "")
                _Doc_Previos = Replace(_Doc_Previos, ")", "")
            End If

            Documento_Htm = Replace(Documento_Htm, "#Doc_Previos#", _Doc_Previos)

            Dim _Kofu = Encabezado_tb.Rows(0).Item("KOFUDO")
            Dim _Responzable = Trim(_Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Kofu & "'"))

            Documento_Htm = Replace(Documento_Htm, "#Responsable#", _Responzable & "(" & _Kofu & ")")
            Documento_Htm = Replace(Documento_Htm, "#Sucursal#", Encabezado_tb.Rows(0).Item("SUDO"))

            Dim _Observaciones As String

            Try
                _Observaciones = Replace(UCase(Observaciones_tb.Rows(0).Item("OBDO")), "Ñ", "&Ntilde")
            Catch ex As Exception
                _Observaciones = String.Empty
            End Try

            Documento_Htm = Replace(Documento_Htm, "#Observaciones#", _Observaciones)

            Dim _Linea_Detalle As String

            For Each _Detalle As DataRow In Detalle_tb.Rows

                Dim _CodPrincipal As String = _Detalle.Item("KOPRCT")

                Dim _CodAlternativo As String

                If String.IsNullOrEmpty(_Endofi) Then
                    _CodAlternativo = _Detalle.Item("Alternativo_1")
                Else
                    _CodAlternativo = _Detalle.Item("Alternativo_2")
                End If


                Dim _Descripcion As String = UCase(_Detalle.Item("NOKOPR"))
                Dim _Cant_Trans As String = _Detalle.Item("Cant_Trans")
                Dim _UnTrans As String = _Detalle.Item("UnTrans")
                Dim _Cant2Ud As String = _Detalle.Item("CAPRCO2")
                Dim _Ud2 As String = _Detalle.Item("UD02PR")
                Dim _PrecioNeto As String = FormatCurrency(_Detalle.Item("PPPRNE"))
                Dim _Dscto As String = _Detalle.Item("PODTGLLI")
                Dim _TotalNeto As String = FormatCurrency(_Detalle.Item("VANELI"))
                Dim _Fecha As String = _Detalle.Item("FEEMLI")

                Dim _Detalle_Precio As String =
                                  "<td align=" & Chr(34) & "right" & Chr(34) & "><font size=2>" & _PrecioNeto & "</font></td>" & vbCrLf &
                                  "<td align=" & Chr(34) & "center" & Chr(34) & "><font size=2>" & _Dscto & "</font></td>" & vbCrLf &
                                  "<td align=" & Chr(34) & "right" & Chr(34) & "><font size=2>" & _TotalNeto & "</font></td>" & vbCrLf

                If Not _Mostrar_Precios Then _Detalle_Precio = String.Empty


                _Linea_Detalle += "<tr>" & vbCrLf &
                                  "<td><font size=3>" & _CodPrincipal & "</font></td>" & vbCrLf &
                                  "<td><font size=3>" & _CodAlternativo & "</font></td>" & vbCrLf &
                                  "<td><font size=2>" & _Descripcion & "</font></td>" & vbCrLf &
                                  "<td align=" & Chr(34) & "right" & Chr(34) & "><font size=2>" & _Cant_Trans & "</font></td>" & vbCrLf &
                                  "<td align=" & Chr(34) & "center" & Chr(34) & "><font size=2>" & _UnTrans & "</font></td>" & vbCrLf &
                                  _Detalle_Precio &
                                  "</tr>" & vbCrLf

                '"<td><font size=2>" & _Cant2Ud & "</font></td>" & vbCrLf & _
                '"<td><font size=2>" & _Ud2 & "</font></td>" & vbCrLf & _
                '"<td><font size=2>" & _Fecha & "</font></td>" & vbCrLf & _

            Next

            Documento_Htm = Replace(Documento_Htm, "#Detalle#", _Linea_Detalle)

            Dim _Sub_Total As String = FormatCurrency(Suma_SubTotales_tb.Rows(0).Item("SUB_NETO"), 0)
            Dim _Descuentos As String = FormatCurrency(Suma_SubTotales_tb.Rows(0).Item("SUM_DESCUENTOS"), 0)
            Dim _Neto As String = FormatCurrency(Encabezado_tb.Rows(0).Item("VANEDO"), 0)
            Dim _Ila As String = FormatCurrency(Encabezado_tb.Rows(0).Item("VAIMDO"), 0)
            Dim _Iva As String = FormatCurrency(Encabezado_tb.Rows(0).Item("VAIVDO"), 0)
            Dim _Bruto As String = FormatCurrency(Encabezado_tb.Rows(0).Item("VABRDO"), 0)

            Documento_Htm = Replace(Documento_Htm, "#Total_Venta#", _Sub_Total)
            Documento_Htm = Replace(Documento_Htm, "#Total_Descuento#", _Descuentos)
            Documento_Htm = Replace(Documento_Htm, "#Total_Neto#", _Neto)
            Documento_Htm = Replace(Documento_Htm, "#Impuestos_Adic.#", _Ila)
            Documento_Htm = Replace(Documento_Htm, "#I.V.A.#", _Iva)
            Documento_Htm = Replace(Documento_Htm, "#TOTAL#", _Bruto)

            Documento_Htm = Replace(Documento_Htm, "á", "&aacute;")
            Documento_Htm = Replace(Documento_Htm, "é", "&eacute;")
            Documento_Htm = Replace(Documento_Htm, "í", "&iacute;")
            Documento_Htm = Replace(Documento_Htm, "ó", "&oacute;")
            Documento_Htm = Replace(Documento_Htm, "ú", "&uacute;")
            Documento_Htm = Replace(Documento_Htm, "ñ", "&ntilde;")
            Documento_Htm = Replace(Documento_Htm, "Ñ", "&Ntilde;")

            ' Acento en Html
            'a = &aacute;
            'é = &eacute;
            'í = &iacute;
            'ó = &oacute;
            'ú = &uacute;
            'ñ = &ntilde;
            'Ñ = &Ntilde;

            CrearArchivoTxt(_Ruta_Archivo & "\", "Documento.Htm", Documento_Htm, False)

            ' Set license key to use GemBox.Document in a Free mode.

            ' Html_Pdf(_Ruta_Archivo & "\Documento.Htm", _Ruta_Archivo & "\Documento.Pdf")
            ' Continue to use the component in a Trial mode when free limit is reached.


            Return True
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try

    End Function


    'Shared Sub Html_Pdf(Ruta_Html As String, _
    '             Ruta_Pdf As String)

    '    ComponentInfo.SetLicense("FREE-LIMITED-KEY")


    ' Note: Single-line Sub Lambdas are supported from Visual Basic 10 compiler. See: http://msdn.microsoft.com/en-us/library/ff637436.aspx#code-snippet-5
    ' If you are using Visual Basic 9 or older Visual Basic compiler, then you must extract event handler to a method and assign it as an event handler.

    ' Here goes your application specific code.

    'DocumentModel.Load(_Ruta_Archivo & "\Documento.Htm").Save(_Ruta_Archivo & "\Documento.pdf")
    ' If using Professional version, put your serial key below.
    '
    'Dim document As DocumentModel = DocumentModel.Load(Ruta_Html)
    'FreeLimitReachedAction()
    '    document.Save(Ruta_Pdf)
    'End Sub
    ' Sub xx(sender, e)
    '    e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial
    'End Sub


    'Public Sub New()
    '    AddHandler ComponentInfo.FreeLimitReached, AddressOf xx
    'End Sub
End Class
