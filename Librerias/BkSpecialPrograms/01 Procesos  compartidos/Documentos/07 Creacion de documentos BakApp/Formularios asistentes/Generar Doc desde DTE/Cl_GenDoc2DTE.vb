Imports System.IO
Imports DevComponents.DotNetBar

Namespace Bk_GenDoc2DTE
    Public Class Cl_GenDoc2DTE

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Public Sub New()

        End Sub

        Function Fx_Generar_Documentos_Desde_DTE(_Folio As String,
                                                 _TipoDoc As String,
                                                 _Rut_Proveedor As String) As Bk_GenDoc2DTE.Respuesta

            Dim _Respuesta As New Bk_GenDoc2DTE.Respuesta

            Try

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_ReccDet" & vbCrLf &
                               "Where TipoDTE = " & _TipoDoc & " And Folio = '" & _Folio & "' And RutEmisor = '" & _Rut_Proveedor & "'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                If IsNothing(_Row) Then
                    Throw New System.Exception("No se encontro el archivo en los DTE")
                End If

                Dim _Xml As String = _Row.Item("Xml")

                Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\DTE\Descargas"

                If Not Directory.Exists(_Directorio) Then
                    Directory.CreateDirectory(_Directorio)
                End If

                Dim _NombreArchivo As String = _Folio & "_" & _TipoDoc & _Rut_Proveedor '& ".XML"
                Dim _Archivo As String = _Directorio & "\" & _NombreArchivo.Trim

                Dim oSW As New StreamWriter(_Archivo & ".XML")
                oSW.WriteLine(_Xml)
                oSW.Close()

                Dim _Dset_DTE As New DataSet
                _Dset_DTE.ReadXml(_Archivo & ".XML")

                If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF") Then
                    System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF")
                End If

                Dim _File As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _NombreArchivo & ".pdf"

                If Not El_Archivo_Esta_Abierto(_File) Then

                    _Respuesta = Fx_Revisar_DTE(_Dset_DTE)

                Else

                    MessageBoxEx.Show(Me, "El Archivo se encuentra abierto", "DTE2PDF", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

                _Respuesta.EsCorrecto = True

            Catch ex As Exception
                _Respuesta.Mensaje = ex.Message
            End Try

            Return _Respuesta

        End Function

        Function Fx_Revisar_DTE(_Dset_DTE As DataSet) As Respuesta ' List(Of Detalle)

            Dim _Respuesta As New Respuesta

            Try

                Dim Tbl_Encabezado = _Dset_DTE.Tables("Encabezado")

                For Each _DTE_Fila As DataRow In Tbl_Encabezado.Rows

                    Dim _Documento_Id As Integer = _DTE_Fila.Item("Documento_Id")
                    Dim _Encabezado_Id As Integer = _DTE_Fila.Item("Encabezado_Id")

                    Dim _Tipo_Documento As String = "FACTURA ELECTRÓNICA"

                    Dim Contador As Integer = 1

                    Dim Tbl_IdDoc = _Dset_DTE.Tables("IdDoc") '.Select("Encabezado_Id = 0")

                    Dim _Id_Doc As Integer = Tbl_IdDoc.Rows(_Encabezado_Id).Item("TipoDTE")
                    Dim _Nro_Documento As String = Tbl_IdDoc.Rows(_Encabezado_Id).Item("Folio")

                    Dim Tbl_Emisor = _Dset_DTE.Tables("Emisor")

                    With Tbl_Emisor

                        Dim _Razon_Emisor As String = Trim(.Rows(_Encabezado_Id).Item("RznSoc")) '"Razon Social Emisor de documento"
                        Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTEmisor")), "-")
                        Dim _Rut_Emisor As String = FormatNumber(De_Txt_a_Num_01(_Rt(0), 0), 0) & "-" & _Rt(1)

                        Dim _Giro_Emisor As String = Fx_Valor_Columna(.Rows(_Encabezado_Id), 0, "GiroEmis") 'Trim(.Rows(0).Item("GiroEmis"))
                        Dim _direccion_Emisor As String = Fx_Valor_Columna(.Rows(_Encabezado_Id), 0, "DirOrigen") 'Trim(.Rows(0).Item("DirOrigen"))
                        Dim _Ciudad_Emisor As String = Fx_Valor_Columna(.Rows(_Encabezado_Id), 0, "CiudadOrigen") 'Trim(.Rows(0).Item("CiudadOrigen"))
                        Dim _Comuna_Emisor As String = Fx_Valor_Columna(.Rows(_Encabezado_Id), 0, "CmnaOrigen") 'Trim(.Rows(0).Item("CmnaOrigen"))

                        If _Ciudad_Emisor.Trim = _Comuna_Emisor.Trim Then
                            _Comuna_Emisor = String.Empty
                        End If

                        Dim _Telefono_Emisor As String = "" '.Rows(0).Item("RUTEmisor")

                    End With

                    Dim DD = Tbl_IdDoc

                    Dim _Fecha_Emision As Date = Tbl_IdDoc.Rows(_Encabezado_Id).Item("FchEmis")
                    Dim _Fecha_Vencimiento As Date
                    Dim _TieneFechaVencimiento As Boolean

                    Dim Tbl_Receptor = _Dset_DTE.Tables("Receptor")

                    With Tbl_Receptor

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        '''''''''''''''''   ENCABEZADO DOCUMENTO
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Dim _Razon_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("RznSocRecep")) '"Razon Social Receptor de documento"

                        Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTRecep")), "-")
                        Dim _Rut_Receptor As String = FormatNumber(De_Txt_a_Num_01(_Rt(0), 0), 0) & "-" & _Rt(1)

                        Dim _Giro_Receptor As String

                        Try
                            _Giro_Receptor = Trim(.Rows(_Encabezado_Id).Item("GiroRecep"))
                        Catch ex As Exception
                            _Giro_Receptor = String.Empty
                        End Try

                        Dim _direccion_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("DirRecep"))
                        Dim _Ciudad_Receptor As String = Fx_Valor_Columna(.Rows(_Encabezado_Id), 0, "CiudadRecep") 'Trim(.Rows(0).Item("CiudadRecep"))
                        Dim _Comuna_Receptor As String = Fx_Valor_Columna(.Rows(_Encabezado_Id), 0, "CmnaRecep") 'Trim(.Rows(0).Item("CmnaRecep"))
                        Dim _Telefono_Receptor As String = Fx_Valor_Columna(.Rows(_Encabezado_Id), 0, "Contacto") 'Trim(.Rows(0).Item("RznSocRecep"))

                    End With


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''   ENCABEZADO DE DETALLE
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim _Valor As String
                    Dim _Caracter As String
                    Dim _Largo As Integer = 18
                    Dim numero As Integer = 10 'Random.Next(1, 4)

                    'Inicializar la clase Random  
                    Dim Random As New Random()

                    Dim Tbl_Detalle = _Dset_DTE.Tables("Detalle")
                    Dim Tbl_CdgItem = _Dset_DTE.Tables("CdgItem")

                    Contador = 0

                    Dim _Detalle As New List(Of Detalle)

                    For Each Fila As DataRow In Tbl_Detalle.Rows

                        Dim _Registro = New Detalle

                        Dim Id = Fila.Item("Documento_Id")

                        If Id = _Documento_Id Then

                            Dim _Codigo As String = String.Empty
                            Dim _Detalle_Id As String

                            Try
                                _Detalle_Id = Fila.Item("Detalle_Id")
                            Catch ex As Exception
                                _Detalle_Id = 0
                            End Try

                            If Not (Tbl_CdgItem Is Nothing) Then

                                Try
                                    _Codigo = Tbl_CdgItem.Rows(_Detalle_Id).Item("VlrCodigo").ToString.Trim
                                Catch ex As Exception
                                    _Codigo = String.Empty
                                End Try

                            End If

                            _Registro.Codigo = _Codigo


                            Dim _Cantidad As Double

                            Try
                                _Cantidad = De_Txt_a_Num_01(Fila.Item("QtyItem"))
                            Catch ex As Exception
                                _Cantidad = 1
                            End Try

                            _Registro.Cantidad = _Cantidad

                            Dim _DscItem As String
                            Dim _NmbItem As String

                            Try
                                _DscItem = Trim(Fila.Item("DscItem"))
                            Catch ex As Exception
                                _DscItem = String.Empty
                            End Try

                            Try
                                _NmbItem = Trim(Fila.Item("NmbItem"))
                            Catch ex As Exception
                                _NmbItem = String.Empty
                            End Try

                            Dim _Descripcion As String = _NmbItem

                            Dim _Descripcion_01 = String.Empty
                            Dim _Descripcion_02 = String.Empty

                            If _Descripcion.Length > 63 Then

                                _Descripcion_01 = Mid(_Descripcion, 1, 63)
                                _Descripcion_02 = Mid(_Descripcion, 64, _Descripcion.Length)

                            End If

                            _Registro.Descripcion = _Descripcion

                            Dim _Precio As Double = Fx_Valor_Columna(Fila, 0, "PrcItem", True)
                            Dim _DecuentoPct As Double = Fx_Valor_Columna(Fila, 0, "DescuentoPct", True)
                            Dim _DescuentoMonto As Double = Fx_Valor_Columna(Fila, 0, "DescuentoMonto", True)
                            Dim _Monto As Double = Fx_Valor_Columna(Fila, 0, "MontoItem", True)

                            _Registro.Precio = _Precio
                            _Registro.Dscto1 = _DecuentoPct
                            _Registro.DescuentoMonto = _DescuentoMonto
                            _Registro.Monto = _Monto

                            Dim _Decimal As Integer


                            If Int(_DecuentoPct) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                            Dim _DecuentoPct_ = Rellenar(FormatNumber(_DecuentoPct, _Decimal), 4, " ", False)

                            If Int(_DescuentoMonto) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                            Dim _DescuentoMonto_ = Rellenar(FormatNumber(_DescuentoMonto, _Decimal), 13, " ", False)

                            If Int(_Cantidad) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                            Dim _Cantidad_ = Rellenar(FormatNumber(_Cantidad, _Decimal), 9, " ", False)

                            If Int(_Precio) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                            Dim _Precio_ = Rellenar(FormatNumber(_Precio, _Decimal), 13, " ", False)

                            Dim _Monto_ = Rellenar(FormatNumber(_Monto, 0), 13, " ", False)

                            _Detalle.Add(_Registro)

                            Contador += 1

                        End If

                    Next

                    _Respuesta.Detalle = _Detalle

                    Dim _DscRcgGlobal As New List(Of DscRcgGlobal)

                    Dim Tbl_DscRcgGlobal = _Dset_DTE.Tables("DscRcgGlobal")

                    For Each Fila As DataRow In Tbl_DscRcgGlobal.Rows

                        Dim _Dsctos As New DscRcgGlobal

                        _Dsctos.NroLinDR = Fila.Item("NroLinDR")
                        _Dsctos.TpoMov = Fila.Item("TpoMov")
                        _Dsctos.GlosaDR = Fila.Item("GlosaDR")
                        _Dsctos.TpoValor = Fila.Item("TpoValor")
                        _Dsctos.ValorDR = Fila.Item("ValorDR")

                        _DscRcgGlobal.Add(_Dsctos)

                    Next

                    _Respuesta.DscRcgGlobal = _DscRcgGlobal

                    'TIPO DE DOCUMENTO FOLIO FECHA MOTIVO
                    'Orden de Compra 58 03-10-2014

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''' REFERENCIA 
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Tbl_Referencia = _Dset_DTE.Tables("Referencia")


                    If Not (Tbl_Referencia Is Nothing) Then

                        For Each Fila As DataRow In Tbl_Referencia.Rows

                            Dim ID = Fila.Item("Documento_Id")

                            If ID = _Documento_Id Then

                                Dim _Id_Doc_Ref As String = Fila.Item("TpoDocRef")
                                'Dim _Doc_Ref As String = Tipo_Documento(_Id_Doc_Ref)

                                Dim _Nro_Doc_Ref As String = Fila.Item("FolioRef")
                                Dim _FchRef As Date = Fila.Item("FchRef")

                                Dim _CodRef As String
                                Dim _Motivo As String

                                Try
                                    _CodRef = Fila.Item("CodRef")
                                    _Motivo = Fx_Tipo_Referencia(_CodRef)
                                Catch ex As Exception
                                    _CodRef = String.Empty
                                    _Motivo = String.Empty
                                End Try

                            End If

                        Next

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''   PIE 
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim Tbl_ImptoReten = _Dset_DTE.Tables("ImptoReten")

                    Dim _Impuestos_Ila As Double

                    If Not (Tbl_ImptoReten Is Nothing) Then
                        For Each _Fila_Ila As DataRow In Tbl_ImptoReten.Rows
                            _Impuestos_Ila += Fx_Valor_Columna(_Fila_Ila, 0, "MontoImp", True)
                        Next
                    End If

                    Dim Tbl_Totales = _Dset_DTE.Tables("Totales")

                    If Not (Tbl_Totales Is Nothing) Then

                        Dim _TasaIVA As Double
                        Dim _IVA As Double

                        Dim _Descuento As Double
                        Dim _Exento As Double
                        Dim _MntNeto As Double
                        Dim _MntTotal As Double

                        Try
                            _MntNeto = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntNeto"))
                        Catch ex As Exception
                            _MntNeto = 0
                        End Try

                        _MntTotal = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntTotal"))

                        Try
                            _TasaIVA = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("TasaIVA"))
                        Catch ex As Exception
                            _TasaIVA = 0
                        End Try

                        Try
                            _IVA = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("IVA"))
                        Catch ex As Exception
                            _IVA = 0
                        End Try

                        Try
                            _Exento = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntExe"))
                        Catch ex As Exception
                            _Exento = 0
                        End Try

                        _MntTotal = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntTotal"))

                        Dim _Tota_Descuento As String
                        _Tota_Descuento = FormatNumber(_Descuento, 0)
                        _Tota_Descuento = ": $ " & Rellenar(_Tota_Descuento, 11, " ", False)

                        Dim _Tota_Exento As String
                        _Tota_Exento = FormatNumber(_Exento, 0)
                        _Tota_Exento = ": $ " & Rellenar(_Tota_Exento, 11, " ", False)

                        Dim _Total_Neto As String
                        _Total_Neto = FormatNumber(_MntNeto, 0)
                        _Total_Neto = ": $ " & Rellenar(_Total_Neto, 11, " ", False)

                        Dim _Total_Ila As String
                        _Total_Ila = FormatNumber(_IVA, 0)
                        _Total_Ila = ": $ " & Rellenar(_Impuestos_Ila, 11, " ", False)

                        Dim _Total_Iva As String
                        _Total_Iva = FormatNumber(_IVA, 0)
                        _Total_Iva = ": $ " & Rellenar(_Total_Iva, 11, " ", False)

                        Dim _Total_Bruto As String
                        _Total_Bruto = FormatNumber(_MntTotal, 0)
                        _Total_Bruto = ": $ " & Rellenar(_Total_Bruto, 11, " ", False)

                    End If


                    '********************************************** TIMBRE ELECTRONICO **************************************************
                    '*********************************************************************************************************************


                Next

            Catch ex As Exception
                'MessageBoxEx.Show(_Formulario, ex.Message & vbCrLf &
                '                  "Problemas al leer el archivo XML de origen, puede que el archivos no tenga la estructura adecuada", "Problema en DTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            _Respuesta.EsCorrecto = True

            Return _Respuesta

        End Function

        Private Function Fx_Valor_Columna(_Tabla As DataRow,
                                   Fila As Integer,
                                   _Campo As String,
                                   Optional _EsNro As Boolean = False)

            Dim _Cadena As String
            Dim _Numero As Double

            Try

                If _EsNro Then
                    _Numero = De_Txt_a_Num_01(_Tabla.Item(_Campo), 5)
                    Return _Numero
                Else
                    _Cadena = Trim(_Tabla.Item(_Campo))
                    Return _Cadena
                End If

            Catch ex As Exception

                If _EsNro Then
                    Return 0
                Else
                    Return String.Empty
                End If

            End Try


        End Function

        Private Function Fx_Tipo_Referencia(_Cod_Ref As Integer)
            Select Case _Cod_Ref
                Case 1
                    Return "Anula Documento de Referencia"
                Case 2
                    Return "Corrige Texto Documento de Referencia"
                Case 3
                    Return "Corrige montos"
                Case Else
                    Return String.Empty
            End Select
        End Function

    End Class

    Public Class Respuesta

        Public Property EsCorrecto As Boolean
        Public Property Mensaje As String
        Public Property Detalle As List(Of Detalle)
        Public Property DscRcgGlobal As List(Of DscRcgGlobal)

    End Class

    Public Class Detalle

        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Cantidad As Double
        Public Property Precio As Double
        Public Property Dscto1 As Double
        Public Property Dscto2 As Double
        Public Property Dscto3 As Double
        Public Property DescuentoMonto As Double
        Public Property Monto As Double

    End Class

    Public Class DscRcgGlobal
        Public Property NroLinDR As Integer
        Public Property TpoMov As String
        Public Property GlosaDR As String
        Public Property TpoValor As String
        Public Property ValorDR As Double
    End Class

End Namespace

