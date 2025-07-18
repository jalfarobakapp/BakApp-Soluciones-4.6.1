Imports System.Net.Sockets
Imports System.Text

Public Class Class_Imprimir_Barras

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Error As String

#Region "VARIABLES DE IMPRESION"

    Dim _Tido
    Dim _Nudo
    Dim _CodEntidad
    Dim _CodSucEntidad
    Dim _RazonSocial

    Dim _Codigo_principal
    Dim _Codigo_tecnico
    Dim _Codigo_rapido
    Dim _Codigo_Alternativo = String.Empty
    Dim _Descripcion
    Dim _Descripcion_Corta
    Dim _Desc0125 As String
    Dim _Desc2650 As String

    Dim _Desc_0135 As String
    Dim _Desc_0235 As String

    Dim _Ubicacion
    Dim _Precio_ud1
    Dim _Precio_ud2
    Dim _PrecioNetoXRtu
    Dim _PrecioBrutoXRtu
    Dim _Rtu
    Dim _Ud1
    Dim _Ud2

    Dim _Marca_Pr
    Dim _Nodim1
    Dim _Nodim2
    Dim _Nodim3
    Dim _PrecioLc1
    Dim _FechaProgramada_Futuro As Date

    Dim _PU01_Neto, _PU02_Neto As Double
    Dim _PU01_Bruto, _PU02_Bruto As Double

    Dim _Cantidad

    Dim _Wms_Ubic_BakApp
    Dim _Wms_Ubicacion_Codigo
    Dim _Wms_Ubicacion_Nombre
    Dim _Wms_Ubicacion_Columna
    Dim _Wms_Ubicacion_Fila
    Dim _Wms_Sector_Codigo
    Dim _Wms_Sector_Nombre
    Dim _Wms_Mapa_Nombre

    Dim _Stock_Minimo_Ubic
    Dim _Stock_Maximo_Ubic

    Dim _Tidopa As String
    Dim _Nudopa As String

    Public Property [Error] As String
        Get
            Return _Error
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

#End Region

#Region "IMPRIMIR CODIGO"

    Sub Sb_Imprimir_Producto(_NombreEtiqueta As String,
                             _Puerto As String,
                             _Codigo As String,
                             _CodLista As String,
                             _Empresa As String,
                             _Sucursal As String,
                             _Bodega As String,
                             _CodUbicacion As String,
                             _Imprimir_Todas_Las_Ubicaciones As Boolean,
                             _ImprimirDesdePrecioFuturo As Boolean,
                             _Id_PrecioFuturo As Integer,
                             _CodAlternativo As String,
                             _ImprimirAIP As Boolean)

        If _Imprimir_Todas_Las_Ubicaciones Then

            Dim _TblProducto As DataTable = Fx_Producto_Ubicaciones(_Codigo, _CodLista, _Empresa, _Sucursal, _Bodega)

            For Each _RowProducto As DataRow In _TblProducto.Rows

                Sb_Incorporar_Precios(_RowProducto, _CodLista, _ImprimirDesdePrecioFuturo, _Id_PrecioFuturo)

                _Codigo_principal = _Codigo
                _Codigo_tecnico = _RowProducto.Item("KOPRTE")
                _Codigo_rapido = _RowProducto.Item("KOPRRA")
                _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
                _Descripcion_Corta = _RowProducto.Item("NOKOPRRA").ToString.Trim

                _Marca_Pr = _RowProducto.Item("Marca").ToString.Trim

                _Wms_Ubicacion_Codigo = _RowProducto.Item("Codigo_Ubic")
                _Wms_Ubicacion_Columna = _RowProducto.Item("Columna")
                _Wms_Ubicacion_Fila = _RowProducto.Item("Fila")

                _Wms_Sector_Codigo = _RowProducto.Item("Codigo_Sector")
                _Wms_Sector_Nombre = _RowProducto.Item("Nombre_Sector")

                _Wms_Mapa_Nombre = _RowProducto.Item("Nombre_Mapa")
                _Wms_Ubicacion_Nombre = _RowProducto.Item("Descripcion_Ubic")

                _Ubicacion = _RowProducto.Item("Codigo_Ubic")

                _Precio_ud1 = _RowProducto.Item("Precio_ud1")
                _Precio_ud2 = _RowProducto.Item("Precio_ud2")

                _Ud1 = _RowProducto.Item("UD01PR").ToString.Trim
                _Ud2 = _RowProducto.Item("UD02PR").ToString.Trim

                _PU01_Neto = _RowProducto.Item("PU01_Neto")
                _PU02_Neto = _RowProducto.Item("PU02_Neto")
                _PU01_Bruto = _RowProducto.Item("PU01_Bruto")
                _PU02_Bruto = _RowProducto.Item("PU02_Bruto")

                _Stock_Minimo_Ubic = _RowProducto.Item("Stock_Minimo_Ubic")
                _Stock_Maximo_Ubic = _RowProducto.Item("Stock_Maximo_Ubic")

                _Descripcion = Replace(_Descripcion, Chr(34), "")
                _Desc0125 = Mid(_Descripcion, 1, 25)
                _Desc2650 = Mid(_Descripcion, 26, 50)

                Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

                Dim _Texto = _RowEtiqueta.Item("FUNCION")

                Sb_Imprimir_PRN(_Texto, _Puerto, _ImprimirAIP)

            Next

        Else

            Dim _RowProducto As DataRow = Fx_DatosProducto(_Codigo,
                                                           _CodLista,
                                                           _Empresa,
                                                           _Sucursal,
                                                           _Bodega,,
                                                           _CodUbicacion,
                                                           _ImprimirDesdePrecioFuturo,
                                                           _Id_PrecioFuturo)

            _Codigo_principal = _Codigo
            _Codigo_tecnico = _RowProducto.Item("KOPRTE")
            _Codigo_rapido = _RowProducto.Item("KOPRRA")
            _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
            _Descripcion_Corta = _RowProducto.Item("NOKOPRRA").ToString.Trim

            If Not String.IsNullOrEmpty(_CodAlternativo) Then
                _Codigo_Alternativo = _CodAlternativo.ToString.Trim
            Else
                _Codigo_Alternativo = _RowProducto.Item("Codigo_Alternativo").ToString.Trim
            End If

            _Ud1 = _RowProducto.Item("UD01PR").ToString.Trim
            _Ud2 = _RowProducto.Item("UD02PR").ToString.Trim

            _Marca_Pr = _RowProducto.Item("Marca").ToString.Trim

            _Ubicacion = _RowProducto.Item("Ubic_Random")

            _Precio_ud1 = _RowProducto.Item("Precio_ud1")
            _Precio_ud2 = _RowProducto.Item("Precio_ud2")

            _PU01_Neto = _RowProducto.Item("PU01_Neto")
            _PU02_Neto = _RowProducto.Item("PU02_Neto")
            _PU01_Bruto = _RowProducto.Item("PU01_Bruto")
            _PU02_Bruto = _RowProducto.Item("PU02_Bruto")

            _Rtu = _RowProducto.Item("RLUD")
            _PrecioNetoXRtu = _RowProducto.Item("PrecioNetoXRtu")
            _PrecioBrutoXRtu = _RowProducto.Item("PrecioBrutoXRtu")

            _Stock_Minimo_Ubic = _RowProducto.Item("Stock_Minimo_Ubic")
            _Stock_Maximo_Ubic = _RowProducto.Item("Stock_Maximo_Ubic")

            _Descripcion = Replace(_Descripcion, Chr(34), "")
            _Desc0125 = Mid(_Descripcion, 1, 25)
            _Desc2650 = Mid(_Descripcion, 26, 50)

            Dim _Descri25_Aju = Fx_AjustarTexto(_Descripcion, 35)

            Dim _Desc_Aju = Split(_Descri25_Aju, vbCrLf, 2)

            If _Desc_Aju.Length > 1 Then 'AndAlso _Desc_Aju(1).ToString.Replace(vbCrLf, " ").ToString.Length <= 25 Then

                _Desc_0135 = _Desc_Aju(0)
                _Desc_0235 = _Desc_Aju(1)

            Else

                _Desc_0135 = _Desc_Aju(0)
                _Desc_0235 = String.Empty

            End If

            _Nodim1 = _RowProducto.Item("NODIM1").ToString.Trim
            _Nodim2 = _RowProducto.Item("NODIM2").ToString.Trim
            _Nodim3 = _RowProducto.Item("NODIM3").ToString.Trim

            Dim _Dim1, _Dim2 As Double

            If IsNumeric(_Nodim1) Then
                _Dim1 = Val(_Nodim1)
            End If

            If IsNumeric(_Nodim2) Then
                _Dim2 = Val(_Nodim2)
            End If

            _FechaProgramada_Futuro = _RowProducto.Item("FechaProgramada")

            If _Dim1 = 0 Then _Dim1 = 1
            If _Dim2 = 0 Then _Dim2 = 1

            _PrecioLc1 = (_Precio_ud1 / _Dim1) * _Dim2

            Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)
            Dim _Texto = _RowEtiqueta.Item("FUNCION")

            Sb_EtiquetasEspecialMayorista(_Codigo, _Texto)
            Sb_Imprimir_PRN(_Texto, _Puerto, _ImprimirAIP)

        End If

    End Sub

    Function Fx_Producto_Ubicaciones(_Codigo As String,
                                     _Lista As String,
                                     _Empresa As String,
                                     _Sucursal As String,
                                     _Bodega As String) As DataTable

        Consulta_sql = "Select MAEPR.*,Isnull((Select top 1 DATOSUBIC From TABBOPR
                        Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'),'') As 'Ubic_Random',
                        Isnull((Select Top 1 PP01UD From TABPRE Where KOLT = '" & _Lista & "' And KOPR = '" & _Codigo & "'),0) As Precio_ud1,
                        Isnull((Select Top 1 PP02UD From TABPRE Where KOLT = '" & _Lista & "' And KOPR = '" & _Codigo & "'),0) As Precio_ud2,
                        Isnull((Select top 1 PM From MAEPREM Where EMPRESA = '" & _Empresa & "' And KOPR = '" & _Codigo & "'),0) As 'PM',
                        Isnull((Select top 1 PPUL01 From MAEPREM Where EMPRESA = '" & _Empresa & "' And KOPR = '" & _Codigo & "'),0) As 'PU01',
                        Isnull((Select top 1 PPUL02 From MAEPREM Where EMPRESA = '" & _Empresa & "' And KOPR = '" & _Codigo & "'),0) As 'PU02',
                        Isnull((Select top 1 KOPRAL From TABCODAL Where KOEN = '' And KOPR = '" & _Codigo & "'),'') As Codigo_Alternativo,
                        Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = MRPR),'') As Marca,
                        Cast(0 As Float) As PU01_Neto,Cast(0 As Float) As PU02_Neto,Cast(0 As Float) As PU01_Bruto,Cast(0 As Float) As PU02_Bruto,
                        Mapa.Nombre_Mapa,isnull(Sector.Nombre_Sector,'') As Nombre_Sector,Isnull(Ubic.Descripcion_Ubic,'') As Descripcion_Ubic,
                        Isnull(Ubic.Columna,'') As Columna,Isnull(Ubic.NomColumna,'') As NomColumna,
                        Isnull(Ubic.Fila,'') As Fila,Isnull(Ubic.Alto,0) As Alto,Isnull(Ubic.Ancho,0) As Ancho,Isnull(Ubic.Peso_Max,0) As Peso_Max,
                        PrUbic.*
                        From MAEPR 
                        Inner Join " & _Global_BaseBk & "Zw_Prod_Ubicacion PrUbic On PrUbic.Empresa = '01' And PrUbic.Sucursal = '" & _Empresa & "' And PrUbic.Codigo = KOPR
                        Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Ubic On Ubic.Empresa = PrUbic.Empresa And Ubic.Sucursal = PrUbic.Sucursal And Ubic.Codigo_Ubic = PrUbic.Codigo_Ubic
	                    Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Mapa On Mapa.Id_Mapa = PrUbic.Id_Mapa
		                Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Sector On Sector.Id_Mapa = PrUbic.Id_Mapa And Sector.Codigo_Sector = PrUbic.Codigo_Sector

                        Where KOPR = '" & _Codigo & "'
                        Order By Primaria Desc"

        Fx_Producto_Ubicaciones = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Function

    Public Sub EnviarEtiqueta(ZPL As String)

        Dim bmp1 As Bitmap = Nothing
        Dim fechaActual As String = DateTime.Now.ToString("dd/MM/yyyy") ' Formato de fecha como en B4A
        Dim printerIP As String = "192.168.1.166" ' IP de tu impresora Ferreteria
        Dim printerPort As Integer = 9100         ' Puerto típico para Zebra
        Dim cliente As TcpClient = Nothing

        printerIP = "192.168.1.178" ' Supermercado

        Try
            ' Crear ZPL dinámicamente

            ' Conectar a la impresora
            cliente = New TcpClient()
            cliente.Connect(printerIP, printerPort)

            If cliente.Connected Then
                Using stream As NetworkStream = cliente.GetStream()
                    ' Limpiar memoria de la impresora (opcional)
                    Dim limpiarMemoria As String = "^XA^IDR:*.*^XZ"
                    Dim bytesLimpiar As Byte() = Encoding.UTF8.GetBytes(limpiarMemoria)
                    stream.Write(bytesLimpiar, 0, bytesLimpiar.Length)

                    ' Enviar ZPL
                    Dim bytesZPL As Byte() = Encoding.UTF8.GetBytes(ZPL)
                    stream.Write(bytesZPL, 0, bytesZPL.Length)

                    'MessageBox.Show("Se ha impreso la etiqueta correctamente", "Impresión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            Else
                MessageBox.Show("No se pudo conectar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al imprimir: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar conexión
            If cliente IsNot Nothing AndAlso cliente.Connected Then
                cliente.Close()
            End If
        End Try
    End Sub

    Sub Sb_EtiquetasEspecialMayorista(_Codigo As String, ByRef _Texto As String)

        Consulta_sql = "Select KOPR,NOKOPR,RLUD,NODIM1,NODIM2,NODIM3 From MAEPR Where KOPR = '" & _Codigo & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Dim1, _Dim2 As Double
        Dim _Dim3 As String = "X " & _Nodim3

        If IsNumeric(_Nodim1) Then
            _Dim1 = Val(_Nodim1)
        End If

        If IsNumeric(_Nodim2) Then
            _Dim2 = Val(_Nodim2)
        End If

        Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = 'PB1') As MELT" & vbCrLf &
                       "From TABPRE" & vbCrLf &
                       "Where KOLT = 'PB1' And KOPR = '" & _Codigo & "'"
        Dim _RowPrecios_PB1 As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = 'PB3') As MELT" & vbCrLf &
                       "From TABPRE" & vbCrLf &
                       "Where KOLT = 'PB3' And KOPR = '" & _Codigo & "'"
        Dim _RowPrecios_PB3 As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Precio_1 As Double = Fx_Funcion_Ecuacion_Random(Nothing, "", "", _Codigo, 1, _RowPrecios_PB1, 0, 0, 0)
        Dim _Precio_2 As Double = Fx_Funcion_Ecuacion_Random(Nothing, "", "", _Codigo, 1, _RowPrecios_PB3, 0, 0, 0)

        Dim _PrecioXKilo1 As Double = 0
        Dim _PrecioXKilo2 As Double = 0

        _PrecioXKilo1 = Math.Round((_Dim2 / _Dim1) * _Precio_1, 0)
        _PrecioXKilo2 = Math.Round((_Dim2 / _Dim1) * _Precio_2, 0)

        Dim _May_Hasta As String = _Rtu - 1
        Dim _May_Desde As String = _Rtu

        If _Dim1 = 0 Then _Dim1 = 1
        If _Dim2 = 0 Then _Dim2 = 1

        Dim _Descripcion_May = Fx_DividirDescripcionEn2Palabras(_Descripcion)
        Dim _May_Descripcion_1 As String = _Descripcion_May(0)
        Dim _May_Descripcion_2 As String = _Descripcion_May(1)

        Dim _May_Precio_1, _May_Precio_2 As String
        Dim _May_Precioxkilo1, _May_Precioxkilo2 As String
        Dim _May_dim3 As String

        Try
            _May_Precio_1 = Fx_Formato_Numerico(_Precio_1, "$ 999.999", False)
        Catch ex As Exception
            _May_Precio_1 = "?"
        End Try

        Try
            _May_Precio_2 = Fx_Formato_Numerico(_Precio_2, "$ 999.999", False)
        Catch ex As Exception
            _May_Precio_2 = "?"
        End Try

        Try
            _May_Precioxkilo1 = Fx_Formato_Numerico(_May_Precioxkilo1, "$ 999.999", False)
        Catch ex As Exception
            _May_Precioxkilo1 = "?"
        End Try

        Try
            _May_Precioxkilo2 = Fx_Formato_Numerico(_May_Precioxkilo2, "$ 999.999", False)
        Catch ex As Exception
            _May_Precioxkilo2 = "?"
        End Try

        _May_dim3 = _Dim3.ToString.Trim

        _Texto = Replace(_Texto, "<MAY_PRECIO1>", _May_Precio_1)
        _Texto = Replace(_Texto, "<MAY_PRECIO2>", _May_Precio_1)
        _Texto = Replace(_Texto, "<MAY_PRECIOXKILO1>", _May_Precioxkilo1)
        _Texto = Replace(_Texto, "<MAY_PRECIOXKILO2>", _May_Precioxkilo2)

        _Texto = Replace(_Texto, "<MAY_DIM3>", _May_dim3)
        _Texto = Replace(_Texto, "<MAY_HASTA>", _May_Hasta)
        _Texto = Replace(_Texto, "<MAY_DESDE>", _May_Desde)

        _Texto = Replace(_Texto, "<MAY_DESCRIPCION_1>", _May_Descripcion_1)
        _Texto = Replace(_Texto, "<MAY_DESCRIPCION_2>", _May_Descripcion_2)

    End Sub

    ''' <summary>
    ''' Divide una descripción en dos partes: la primera palabra y el resto.
    ''' </summary>
    ''' <param name="descripcion">Texto a dividir</param>
    ''' <returns>Array de 2 strings: palabra1, resto</returns>
    Function Fx_DividirDescripcionEn2Palabras(descripcion As String) As String()
        Dim resultado(1) As String
        If String.IsNullOrWhiteSpace(descripcion) Then
            resultado(0) = ""
            resultado(1) = ""
            Return resultado
        End If

        Dim partes As String() = descripcion.Trim().Split(New Char() {" "c}, 2, StringSplitOptions.RemoveEmptyEntries)
        If partes.Length = 1 Then
            resultado(0) = partes(0)
            resultado(1) = ""
        Else
            resultado(0) = partes(0)
            resultado(1) = partes(1)
        End If
        Return resultado
    End Function

#End Region

#Region "IMPRIMIR DESDE DOCUMENTO"

    Sub Sb_Imprimir_Documento(_NombreEtiqueta As String,
                              _Puerto As String,
                              _Idmaeedo As String,
                              _Idmaeddo As String,
                              _Kopral As String)

        Dim _Fecha_impresion As Date = Now
        Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

        'Dim fic As String = texto '"C:\Ejemplo1.prn"
        Dim _Texto = _RowEtiqueta.Item("FUNCION")


        Consulta_sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random,
                       "#Idmaeedo#", _Idmaeedo)

        Dim Datos_Documento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _TblEncabezado As DataTable = Datos_Documento.Tables(0)
        Dim _TblDetalle As DataTable = Datos_Documento.Tables(1)
        Dim _TblObservaciones As DataTable = Datos_Documento.Tables(2)

        Dim _CodEntidad = String.Empty

        If CBool(_TblEncabezado.Rows.Count) Then
            _CodEntidad = _TblEncabezado.Rows(0).Item("ENDO")
        End If

        Datos_Documento.Dispose()

        Dim _RowProducto As DataRow
        Dim _RowDetalle As DataRow

        For Each _Fila As DataRow In _TblDetalle.Rows

            Dim _Id = _Fila.Item("IDMAEDDO")

            If _Idmaeddo = _Id Then

                _Codigo_principal = _Fila.Item("KOPRCT")

                Dim _Lista = _Fila.Item("LISTA")
                Dim _Empresa = _Fila.Item("EMPRESA")
                Dim _Sucursal = _Fila.Item("SULIDO")
                Dim _Bodega = _Fila.Item("BOSULIDO")

                _Tidopa = _Fila.Item("TIDOPA")
                _Nudopa = _Fila.Item("NUDOPA")

                _RowProducto = Fx_DatosProducto(_Codigo_principal, _Lista, _Empresa, _Sucursal, _Bodega, _CodEntidad)

                _RowDetalle = _Fila

                Exit For

            End If

        Next

        _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        _Nudo = _TblEncabezado.Rows(0).Item("NUDO")

        _Codigo_tecnico = _RowProducto.Item("KOPRTE")
        _Codigo_rapido = _RowProducto.Item("KOPRRA")

        If String.IsNullOrEmpty(_Kopral) Then
            _Codigo_Alternativo = _RowProducto.Item("Codigo_Alternativo")
        Else
            _Codigo_Alternativo = _Kopral
        End If

        _Descripcion = _RowProducto.Item("NOKOPR")
        _Desc0125 = Mid(_Descripcion, 1, 25)
        _Desc2650 = Mid(_Descripcion, 26, 50)

        _Ubicacion = _RowProducto.Item("Ubic_Random")
        '_Ubic_BakApp = _RowProducto.Item("Ubic_BakApp")

        _Precio_ud1 = _RowProducto.Item("Precio_ud1")
        _Precio_ud2 = _RowProducto.Item("Precio_ud2")

        _Stock_Minimo_Ubic = _RowProducto.Item("Stock_Minimo_Ubic")
        _Stock_Maximo_Ubic = _RowProducto.Item("Stock_Maximo_Ubic")

        _Marca_Pr = _RowProducto.Item("Marca").ToString.Trim

        _Codigo_tecnico = _RowProducto.Item("KOPRTE")
        _Codigo_rapido = _RowProducto.Item("KOPRRA")
        _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
        _Descripcion_Corta = _RowProducto.Item("NOKOPRRA").ToString.Trim

        _Marca_Pr = _RowProducto.Item("Marca").ToString.Trim

        _Ubicacion = _RowProducto.Item("Ubic_Random")

        _Precio_ud1 = _RowProducto.Item("Precio_ud1")
        _Precio_ud2 = _RowProducto.Item("Precio_ud2")

        _Ud1 = _RowProducto.Item("UD01PR").ToString.Trim
        _Ud2 = _RowProducto.Item("UD02PR").ToString.Trim

        _PU01_Neto = _RowProducto.Item("PU01_Neto")
        _PU02_Neto = _RowProducto.Item("PU02_Neto")
        _PU01_Bruto = _RowProducto.Item("PU01_Bruto")
        _PU02_Bruto = _RowProducto.Item("PU02_Bruto")

        _Rtu = _RowProducto.Item("RLUD")
        _PrecioNetoXRtu = _RowProducto.Item("PrecioNetoXRtu")
        _PrecioBrutoXRtu = _RowProducto.Item("PrecioBrutoXRtu")

        _Stock_Minimo_Ubic = _RowProducto.Item("Stock_Minimo_Ubic")
        _Stock_Maximo_Ubic = _RowProducto.Item("Stock_Maximo_Ubic")

        _Descripcion = Replace(_Descripcion, Chr(34), "")
        _Desc0125 = Mid(_Descripcion, 1, 25)
        _Desc2650 = Mid(_Descripcion, 26, 50)

        _Nodim1 = _RowProducto.Item("NODIM1").ToString.Trim
        _Nodim2 = _RowProducto.Item("NODIM2").ToString.Trim
        _Nodim3 = _RowProducto.Item("NODIM3").ToString.Trim

        _PrecioLc1 = 0

        If _RowDetalle.Item("ARCHIRST").ToString.Trim = "POTL" Then

            Dim _Idpotl As Integer = _RowDetalle.Item("IDRST")

            Sb_Etiquetas_OT(_Texto, _Idpotl, _Kopral)

        End If

        Consulta_sql = "Select Top 1 Id,Enc.Id_Lote,Enc.NroLote,Enc.NroLote As 'NROLOTE_BK',NomTabla,IdTabla,Enc.FechaVenci,Enc.FechaVenci As 'FECHAVENCI_LOTE_BK'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Lotes_Det Det" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Lotes_Enc Enc On Enc.Id_Lote = Det.Id_Lote" & vbCrLf &
                       "Where Det.NomTabla = 'MAEDDO' And Det.IdTabla = " & _RowDetalle.Item("IDMAEDDO")
        Dim _Row_Lote As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Lote) Then

            _Texto = Replace(_Texto, "<NroLote>", _Row_Lote.Item("NroLote"))
            _Texto = Replace(_Texto, "<FechaVenci>", Format(_Row_Lote.Item("FechaVenci"), "dd-MM-yyyy"))

            _Texto = Replace(_Texto, "<NROLOTE_BK>", _Row_Lote.Item("NroLote"))
            _Texto = Replace(_Texto, "<FECHAVENCI_LOTE_BK>", Format(_Row_Lote.Item("FechaVenci"), "dd-MM-yyyy"))

        End If

        Sb_Imprimir_PRN(_Texto, _Puerto)

    End Sub

    Sub Sb_Etiquetas_OT(ByRef _Texto As String, _Idpotl As Integer, _Kopral As String)

        Dim _Idpote As Integer

        Consulta_sql = "Select POTL.*,Ltd.NroLote,Lte.FechaVenci,'" & _Kopral & "' As ALTERNAT,'" & _Kopral & "' As CODIGO_ALT" & vbCrLf &
               "From POTL" & vbCrLf &
               "Left Join " & _Global_BaseBk & "Zw_Lotes_Det Ltd On IDPOTL = IdTabla" & vbCrLf &
               "Left Join " & _Global_BaseBk & "Zw_Lotes_Enc Lte On Ltd.Id_Lote = Lte.Id_Lote" & vbCrLf &
               "Where IDPOTL = " & _Idpotl

        Consulta_sql = "Select * From POTL Where IDPOTL = " & _Idpotl

        Dim _Row_Potl As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Potl) Then
            _Error = "No existe registro de OT Tabla POTL"
            Return
        End If

        _Idpote = _Row_Potl.Item("IDPOTE")

        Dim _Fecha_impresion As Date = Now

        '_Texto = Replace(_Texto, "<NUMOT_INT>", _NumotInt)

        Dim _Funciones As New List(Of String)
        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        Consulta_sql = "Select * From POTE Where IDPOTE = " & _Idpote
        Dim _Row_Pote As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Pote) Then
            _Error = "No existe registro de OT Tabla POTE"
            Return
        End If

        ' Encabezado
        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Row_Pote.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row_Pote)

                    If _Funcion_Buscar = "<barcode>" Then
                        Dim _New_Valor_Funcion = Mid(_Valor_Funcion, 1, 22) & ">6" & Mid(_Valor_Funcion, 23, 1)
                        _Valor_Funcion = _New_Valor_Funcion
                        '60503035247121012939710
                    End If
                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

        ' Descripcion

        _Funciones.Clear()

        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Row_Potl.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row_Potl)

                    If _Funcion_Buscar = "<barcode>" Then
                        Dim _New_Valor_Funcion = Mid(_Valor_Funcion, 1, 22) & ">6" & Mid(_Valor_Funcion, 23, 1)
                        _Valor_Funcion = _New_Valor_Funcion
                        '60503035247121012939710
                    End If
                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

    End Sub

#End Region

#Region "IMPRIMIR UBICACION"

    Sub Sb_Imprimir_Ubicacion(_NombreEtiqueta As String,
                              _Puerto As String,
                              _Empresa As String,
                              _Sucursal As String,
                              _Bodega As String,
                              _Id_Mapa As Integer,
                              _Codigo_Sector As String,
                              _Codigo_Ubic As String,
                              _ImpSubSectorSinPuntitos As Boolean)


        Consulta_sql = "Select Mapa.Nombre_Mapa,Sector.Nombre_Sector,Ubic.*
                        From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Ubic
                        Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Mapa On Mapa.Id_Mapa = Ubic.Id_Mapa
                        Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Sector On Sector.Id_Mapa = Ubic.Id_Mapa And Sector.Codigo_Sector = Ubic.Codigo_Sector
                        Where Ubic.Empresa = '" & _Empresa & "' And Ubic.Sucursal = '" & _Sucursal & "' And Ubic.Bodega = '" & _Bodega &
                        "' And Ubic.Id_Mapa = " & _Id_Mapa & " And Ubic.Codigo_Sector = '" & _Codigo_Sector & "' And Ubic.Codigo_Ubic = '" & _Codigo_Ubic & "'"

        Dim _RowUbicacion = _Sql.Fx_Get_DataRow(Consulta_sql) ' Fx_Datos_Ubicacion(_Empresa, _Sucursal, _Bodega, _Id_Mapa, _Codigo_Sector, _CodUbicacion)

        If Not IsNothing(_RowUbicacion) Then

            _Wms_Ubicacion_Codigo = _RowUbicacion.Item("Codigo_Ubic")
            _Wms_Ubicacion_Columna = _RowUbicacion.Item("Columna")
            _Wms_Ubicacion_Fila = _RowUbicacion.Item("Fila")

            _Wms_Sector_Codigo = _RowUbicacion.Item("Codigo_Sector")
            _Wms_Sector_Nombre = _RowUbicacion.Item("Nombre_Sector")

            _Wms_Mapa_Nombre = _RowUbicacion.Item("Nombre_Mapa")
            _Wms_Ubicacion_Nombre = _RowUbicacion.Item("Descripcion_Ubic")

            If _ImpSubSectorSinPuntitos Then
                _Wms_Sector_Codigo = Replace(_Wms_Sector_Codigo, "...", "")
                _Wms_Sector_Nombre = Replace(_Wms_Sector_Nombre, "...", "")
            End If

        End If

        Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

        Dim _Texto = _RowEtiqueta.Item("FUNCION")

        Sb_Imprimir_PRN(_Texto, _Puerto)

    End Sub

#End Region

#Region "IMPRIMIR ORDEN DESPACHO"

    Sub Sb_Imprimir_Orden_Despacho_Letrero(_NombreEtiqueta As String,
                                           _Puerto As String,
                                           _Id_Despacho As Integer)

        Dim _Fecha_impresion As Date = Now
        Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

        Dim _Cl_Despacho As New Clas_Despacho(False)

        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        Dim _Texto = _RowEtiqueta.Item("FUNCION")

        Dim _Nro_Despacho = _Cl_Despacho.Row_Despacho.Item("Nro_Despacho").ToString.Trim
        Dim _Nro_Sub = _Cl_Despacho.Row_Despacho.Item("Nro_Sub").ToString.Trim

        Dim _Nombre_Cliente = _Cl_Despacho.Row_Entidad.Item("NOKOEN")
        Dim _Rut = _Cl_Despacho.Row_Despacho.Item("Rut")

        Dim _Nom_Tipo_Envio = _Cl_Despacho.Row_Despacho.Item("Nom_Tipo_Envio")
        Dim _Direccion = _Cl_Despacho.Row_Despacho.Item("Direccion")
        Dim _Comuna = _Cl_Despacho.Row_Despacho.Item("Comuna")
        Dim _Telefono = _Cl_Despacho.Row_Despacho.Item("Telefono")

        Dim _Nombre_Transportista = _Cl_Despacho.Row_Despacho.Item("Nombre_Transportista").ToString.Trim
        Dim _Transpor_Por_Pagar = _Cl_Despacho.Row_Despacho.Item("Transpor_Por_Pagar")

        If _Transpor_Por_Pagar Then
            _Nombre_Transportista = _Nombre_Transportista.ToString.Trim & " (POR PAGAR)"
        End If

        Dim _Email = _Cl_Despacho.Row_Despacho.Item("Email")

        Dim _Contador = 0
        Dim _Documentos As String

        For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

            Dim _Idmaeedo = _Fila.Item("Idrst")
            Dim _Vabrdo As Double = _Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

            _Documentos += _Fila.Item("Tido") & "-" & _Fila.Item("Nudo") & " (" & FormatCurrency(_Vabrdo, 0) & ")"
            _Contador += 1

            If _Contador <> _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count Then
                _Documentos += ", "
            End If

        Next

        Dim _Funciones As New List(Of String)
        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        'ExportarTabla_JetExcel_Tabla(_Cl_Despacho.Row_Despacho.Table, Nothing, "Orden_Despacho")

        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Cl_Despacho.Row_Despacho.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Cl_Despacho.Row_Despacho)

                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

        _Texto = Replace(_Texto, "0123456789>6-999", _Nro_Despacho & ">6-" & _Nro_Sub)
        _Texto = Replace(_Texto, "<DOCUMENTOS>", _Documentos)

        _Texto = Replace(_Texto, "ñ", "n")
        _Texto = Replace(_Texto, "Ñ", "N")
        _Texto = Replace(_Texto, "á", "a")
        _Texto = Replace(_Texto, "é", "e")
        _Texto = Replace(_Texto, "í", "i")
        _Texto = Replace(_Texto, "ó", "o")
        _Texto = Replace(_Texto, "ú", "u")

        _Texto = Replace(_Texto, "Á", "A")
        _Texto = Replace(_Texto, "É", "E")
        _Texto = Replace(_Texto, "Í", "I")
        _Texto = Replace(_Texto, "Ó", "O")
        _Texto = Replace(_Texto, "Ú", "U")

        _Texto = Replace(_Texto, "|", " ")
        _Texto = Replace(_Texto, "°", " ")
        _Texto = Replace(_Texto, "¨", " ")
        _Texto = Replace(_Texto, "´", " ")

        Dim fic As String = AppPath(True) & "Barra.prn"

        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine(_Texto)
        sw.Close()

        System.IO.File.Copy("Barra.prn", _Puerto)

    End Sub

    Sub Sb_Imprimir_Etiqueta_Chilexpress(_Puerto As String, _Id_Despacho As Integer)

        _Error = String.Empty

        Dim _Clas_CliexpressAPI As New Clas_CliexpressAPI()
        Dim _Row_Envio As DataRow = _Clas_CliexpressAPI.Fx_Trae_Row_Envio(0, _Id_Despacho)

        If IsNothing(_Row_Envio) Then
            _Error = "No existe registro de envio Chilexpress IdDespacho: " & _Id_Despacho
            Return
        End If

        Dim _Idenvio = _Row_Envio.Item("Idenvio")

        Dim _Row_Respuesta As DataRow = _Clas_CliexpressAPI.Fx_Trae_Row_Respuesta(_Idenvio)

        If IsNothing(_Row_Respuesta) Then
            _Error = "No existe registro de respuesta Chilexpress para el Idenvio: " & _Idenvio
            Return
        End If

        Dim _NombreEtiqueta As String = _Clas_CliexpressAPI.NombreEtiqueta

        '_NombreEtiqueta = "Etiqueta 10x15 Letrero Orden Despacho"

        Dim _Fecha_impresion As Date = Now
        Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

        Dim _Texto = _RowEtiqueta.Item("FUNCION")


        Dim _Funciones As New List(Of String)
        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Row_Respuesta.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row_Respuesta)

                    If _Funcion_Buscar = "<barcode>" Then
                        Dim _New_Valor_Funcion = Mid(_Valor_Funcion, 1, 22) & ">6" & Mid(_Valor_Funcion, 23, 1)
                        _Valor_Funcion = _New_Valor_Funcion
                        '60503035247121012939710
                    End If
                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

        _Texto = Replace(_Texto, "ñ", "n")
        _Texto = Replace(_Texto, "Ñ", "N")
        _Texto = Replace(_Texto, "á", "a")
        _Texto = Replace(_Texto, "é", "e")
        _Texto = Replace(_Texto, "í", "i")
        _Texto = Replace(_Texto, "ó", "o")
        _Texto = Replace(_Texto, "ú", "u")

        _Texto = Replace(_Texto, "Á", "A")
        _Texto = Replace(_Texto, "É", "E")
        _Texto = Replace(_Texto, "Í", "I")
        _Texto = Replace(_Texto, "Ó", "O")
        _Texto = Replace(_Texto, "Ú", "U")

        _Texto = Replace(_Texto, "|", " ")
        _Texto = Replace(_Texto, "°", " ")
        _Texto = Replace(_Texto, "¨", " ")
        _Texto = Replace(_Texto, "´", " ")

        Dim fic As String = AppPath(True) & "Barra.prn"

        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine(_Texto)
        sw.Close()

        System.IO.File.Copy("Barra.prn", _Puerto)

    End Sub

#End Region

#Region "IMPRIMIR DESDE OT"
    Sub Sb_Imprimir_Etiqueta_OT(_Puerto As String, _NombreEtiqueta As String, _Idpote As Integer, _Kopral As String, _Idpotl As Integer)

        _Error = String.Empty

        Consulta_sql = "Select * From POTE Where IDPOTE = " & _Idpote
        Dim _Row_Pote As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Pote) Then
            _Error = "No existe registro de OT Tabla POTE"
            Return
        End If

        Consulta_sql = "Select POTL.*,Ltd.NroLote,Lte.FechaVenci,'" & _Kopral & "' As ALTERNAT,'" & _Kopral & "' As CODIGO_ALT" & vbCrLf &
                       "From POTL" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Lotes_Det Ltd On IDPOTL = IdTabla" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Lotes_Enc Lte On Ltd.Id_Lote = Lte.Id_Lote" & vbCrLf &
                       "Where IDPOTL = " & _Idpotl

        Dim _Row_Potl As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Potl) Then
            _Error = "No existe registro de OT Tabla POTL"
            Return
        End If

        Dim _Fecha_impresion As Date = Now
        Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

        Dim _Texto = _RowEtiqueta.Item("FUNCION")

        Dim _NumotInt As Integer = CInt(_Row_Pote.Item("NUMOT"))
        _Texto = Replace(_Texto, "<NUMOT_INT>", _NumotInt)

        Dim _Funciones As New List(Of String)
        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        ' Encabezado
        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Row_Pote.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row_Pote)

                    If _Funcion_Buscar = "<barcode>" Then
                        Dim _New_Valor_Funcion = Mid(_Valor_Funcion, 1, 22) & ">6" & Mid(_Valor_Funcion, 23, 1)
                        _Valor_Funcion = _New_Valor_Funcion
                        '60503035247121012939710
                    End If
                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

        ' Descripcion

        _Funciones.Clear()

        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Row_Potl.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row_Potl)

                    If _Funcion_Buscar = "<barcode>" Then
                        Dim _New_Valor_Funcion = Mid(_Valor_Funcion, 1, 22) & ">6" & Mid(_Valor_Funcion, 23, 1)
                        _Valor_Funcion = _New_Valor_Funcion
                        '60503035247121012939710
                    End If
                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

        _Texto = Replace(_Texto, "ñ", "n")
        _Texto = Replace(_Texto, "Ñ", "N")
        _Texto = Replace(_Texto, "á", "a")
        _Texto = Replace(_Texto, "é", "e")
        _Texto = Replace(_Texto, "í", "i")
        _Texto = Replace(_Texto, "ó", "o")
        _Texto = Replace(_Texto, "ú", "u")

        _Texto = Replace(_Texto, "Á", "A")
        _Texto = Replace(_Texto, "É", "E")
        _Texto = Replace(_Texto, "Í", "I")
        _Texto = Replace(_Texto, "Ó", "O")
        _Texto = Replace(_Texto, "Ú", "U")

        _Texto = Replace(_Texto, "|", " ")
        _Texto = Replace(_Texto, "°", " ")
        _Texto = Replace(_Texto, "¨", " ")
        _Texto = Replace(_Texto, "´", " ")

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Row_Potl.Item("CODIGO") & "'"
        Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Codigo_principal = _RowProducto.Item("KOPR")
        _Codigo_tecnico = _RowProducto.Item("KOPRTE")
        _Codigo_rapido = _RowProducto.Item("KOPRRA")
        _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
        _Descripcion_Corta = _RowProducto.Item("NOKOPRRA").ToString.Trim

        '_Marca_Pr = _RowProducto.Item("Marca").ToString.Trim

        '_Wms_Ubicacion_Codigo = _RowProducto.Item("Codigo_Ubic")
        '_Wms_Ubicacion_Columna = _RowProducto.Item("Columna")
        '_Wms_Ubicacion_Fila = _RowProducto.Item("Fila")

        '_Wms_Sector_Codigo = _RowProducto.Item("Codigo_Sector")
        '_Wms_Sector_Nombre = _RowProducto.Item("Nombre_Sector")

        '_Wms_Mapa_Nombre = _RowProducto.Item("Nombre_Mapa")
        '_Wms_Ubicacion_Nombre = _RowProducto.Item("Descripcion_Ubic")

        '_Ubicacion = _RowProducto.Item("Codigo_Ubic")

        '_Precio_ud1 = _RowProducto.Item("Precio_ud1")
        '_Precio_ud2 = _RowProducto.Item("Precio_ud2")

        '_PU01_Neto = _RowProducto.Item("PU01_Neto")
        '_PU02_Neto = _RowProducto.Item("PU02_Neto")
        '_PU01_Bruto = _RowProducto.Item("PU01_Bruto")
        '_PU02_Bruto = _RowProducto.Item("PU02_Bruto")

        '_Stock_Minimo_Ubic = _RowProducto.Item("Stock_Minimo_Ubic")
        '_Stock_Maximo_Ubic = _RowProducto.Item("Stock_Maximo_Ubic")

        _PrecioNetoXRtu = 0
        _PrecioBrutoXRtu = 0

        _PrecioLc1 = 0

        _Descripcion = Replace(_Descripcion, Chr(34), "")
        _Desc0125 = Mid(_Descripcion, 1, 25)
        _Desc2650 = Mid(_Descripcion, 26, 50)

        Sb_Imprimir_PRN(_Texto, _Puerto)

        'Dim fic As String = AppPath(True) & "Barra.prn"

        'Dim sw As New System.IO.StreamWriter(fic)
        'sw.WriteLine(_Texto)
        'sw.Close()

        'System.IO.File.Copy("Barra.prn", _Puerto)

    End Sub

#End Region

#Region "IMPRIMIR TARJA"

    Sub Sb_Imprimir_Tarja(_NombreEtiqueta As String,
                          _Puerto As String,
                          _Empresa As String,
                          _Id_Tarja As Integer)


        Consulta_sql = "Select Trj.*,Isnull(Tf.NOKOFU,'') As 'Analista_Str'" & vbCrLf &
                       ",Isnull(Plt.NombreTabla,'') As 'Planta_Str'" &
                       ",Isnull(Trn.NombreTabla,'') As 'Turno_Str'" & vbCrLf &
                       ",Isnull(Tol.NombreTabla,'') As 'Tolva_Str'" & vbCrLf &
                       ",Substring(Lote,1,3) As Lote3,Substring(Lote,1,4) As Lote4,Substring(Lote,1,5) As Lote5,Substring(Trj.Lote,1,6) As Lote6,Substring(Trj.Lote,1,7) As Lote7" & vbCrLf &
                       ",'' As 'Nro_Tipo','' As 'Nro','' As 'Nro_Pallet','' As 'Max_Nro_Tipo'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja Trj" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Analista" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Plt On Plt.Tabla = 'TARJA_PLANTA' And Plt.CodigoTabla = Planta" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Trn On Trn.Tabla = 'TARJA_TURNO' And Trn.CodigoTabla = Turno" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tol On Tol.Tabla = 'TARJA_TOLVA' And Tol.CodigoTabla = Tolva" & vbCrLf &
                       "Where Id = " & _Id_Tarja

        Dim _Row_Tarja As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql) ' Fx_Datos_Ubicacion(_Empresa, _Sucursal, _Bodega, _Id_Mapa, _Codigo_Sector, _CodUbicacion)

        Dim _Fecha_impresion As Date = Now
        Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

        Dim _Texto = _RowEtiqueta.Item("FUNCION")

        Dim _FechaStr As String = _Fecha_impresion.ToString("yyMMdd_HHmmss") ' Format(_Fecha_impresion, "yyMMdd:hhmmss")

        Dim _TRJ_ETQ_Nro_CPT As String = "<TRJ>" & _Row_Tarja.Item("Nro_CPT") & "</TRJ><END>"
        Dim _TRJ_ETQ_Nro_CPT_FFHH1 As String = "<TRJ>" & _Row_Tarja.Item("Nro_CPT") & "</TRJ>" & _FechaStr.ToString.Trim & "<END>"
        Dim _TRJ_FechaElab2 As String = FormatDateTime(_Row_Tarja.Item("FechaElab"), DateFormat.ShortDate)

        _Texto = Replace(_Texto, "<TRJ_ETQ_Nro_CPT>", _TRJ_ETQ_Nro_CPT.Trim)
        _Texto = Replace(_Texto, "<TRJ_ETQ_Nro_CPT_FFHH1>", _TRJ_ETQ_Nro_CPT_FFHH1.Trim)
        _Texto = Replace(_Texto, "<TRJ_FechaElab2>", _TRJ_FechaElab2.Trim)

        Dim _Funciones As New List(Of String)
        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        ' Encabezado
        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Row_Tarja.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    '_Funcion = "TRJ_" & _Funcion

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row_Tarja, "TRJ_")

                    If _Funcion_Buscar = "<barcode>" Then
                        Dim _New_Valor_Funcion = Mid(_Valor_Funcion, 1, 22) & ">6" & Mid(_Valor_Funcion, 23, 1)
                        _Valor_Funcion = _New_Valor_Funcion
                        '60503035247121012939710
                    End If
                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

        _Codigo_principal = _Row_Tarja.Item("Codigo")
        _Codigo_Alternativo = _Row_Tarja.Item("CodAlternativo")

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo_principal & "'"
        Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Codigo_tecnico = _RowProducto.Item("KOPRTE")
        _Codigo_rapido = _RowProducto.Item("KOPRRA")
        _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
        _Descripcion_Corta = _RowProducto.Item("NOKOPRRA").ToString.Trim

        _Ud1 = _RowProducto.Item("UD01PR").ToString.Trim
        _Ud2 = _RowProducto.Item("UD02PR").ToString.Trim

        _Descripcion = Replace(_Descripcion, Chr(34), "")
        _Desc0125 = Mid(_Descripcion, 1, 25)
        _Desc2650 = Mid(_Descripcion, 26, 50)

        Sb_Imprimir_PRN(_Texto, _Puerto)

    End Sub

    Sub Sb_Imprimir_Tarja_Detalle_Pallet(_NombreEtiqueta As String,
                                         _Puerto As String,
                                         _Empresa As String,
                                         _Id_Tarja As Integer,
                                         _Nro As Integer)

        Consulta_sql = "Select Trj.*,Isnull(Tf.NOKOFU,'') As 'Analista_Str'" &
                       ",Isnull(Plt.NombreTabla,'') As 'Planta_Str'" & vbCrLf &
                       ",Isnull(Trn.NombreTabla,'') As 'Turno_Str'" & vbCrLf &
                       ",Isnull(Tol.NombreTabla,'') As 'Tolva_Str'" & vbCrLf &
                       ",Substring(Trj.Lote,1,3) As Lote3,Substring(Trj.Lote,1,4) As Lote4,Substring(Trj.Lote,1,5) As Lote5,Substring(Trj.Lote,1,6) As Lote6,Substring(Trj.Lote,1,7) As Lote7," & vbCrLf &
                       "Det.Nro_Tipo,Det.Nro,Det.Nro As 'Nro_Pallet',(Select MAX(Nro) From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja_Det Dt Where Dt.Lote = Trj.Lote) As 'Max_Nro_Tipo'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja Trj" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja_Det Det On Trj.Id = Det.Id_CPT And Nro = " & _Nro & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Analista" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Plt On Plt.Tabla = 'TARJA_PLANTA' And Plt.CodigoTabla = Planta" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Trn On Trn.Tabla = 'TARJA_TURNO' And Trn.CodigoTabla = Turno" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tol On Tol.Tabla = 'TARJA_TOLVA' And Tol.CodigoTabla = Tolva" & vbCrLf &
                       "Where Trj.Id = " & _Id_Tarja

        Dim _Row_Tarja As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Fecha_impresion As Date = Now
        Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

        Dim _Texto = _RowEtiqueta.Item("FUNCION")

        Dim _FechaStr As String = _Fecha_impresion.ToString("yyMMdd_HHmmss")

        Dim _TRJ_ETQ_Nro_CPT As String = "<TRJ>" & _Row_Tarja.Item("Nro_CPT") & "</TRJ><END>"
        Dim _TRJ_ETQ_Nro_CPT_FFHH1 As String = "<TRJ>" & _Row_Tarja.Item("Nro_CPT") & "</TRJ>" & _FechaStr.ToString.Trim & "<END>"
        Dim _TRJ_FechaElab2 As String = FormatDateTime(_Row_Tarja.Item("FechaElab"), DateFormat.ShortDate)

        _Texto = Replace(_Texto, "<TRJ_ETQ_Nro_CPT>", _TRJ_ETQ_Nro_CPT.Trim)
        _Texto = Replace(_Texto, "<TRJ_ETQ_Nro_CPT_FFHH1>", _TRJ_ETQ_Nro_CPT_FFHH1.Trim)
        _Texto = Replace(_Texto, "<TRJ_FechaElab2>", _TRJ_FechaElab2.Trim)

        Dim _Funciones As New List(Of String)
        Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

        ' Encabezado
        For Each _Funcion As String In _Funciones

            For Each _Columna As DataColumn In _Row_Tarja.Table.Columns

                If _Funcion.Contains(_Columna.ColumnName) Then

                    Dim _Funcion_Buscar = "<" & _Funcion & ">"
                    Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row_Tarja, "TRJ_")

                    If _Funcion_Buscar = "<barcode>" Then
                        Dim _New_Valor_Funcion = Mid(_Valor_Funcion, 1, 22) & ">6" & Mid(_Valor_Funcion, 23, 1)
                        _Valor_Funcion = _New_Valor_Funcion

                    End If
                    _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                    Exit For

                End If

            Next

        Next

        _Codigo_principal = _Row_Tarja.Item("Codigo")
        _Codigo_Alternativo = _Row_Tarja.Item("CodAlternativo")

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo_principal & "'"
        Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Codigo_tecnico = _RowProducto.Item("KOPRTE")
        _Codigo_rapido = _RowProducto.Item("KOPRRA")
        _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
        _Descripcion_Corta = _RowProducto.Item("NOKOPRRA").ToString.Trim

        _Ud1 = _RowProducto.Item("UD01PR").ToString.Trim
        _Ud2 = _RowProducto.Item("UD02PR").ToString.Trim

        _Descripcion = Replace(_Descripcion, Chr(34), "")
        _Desc0125 = Mid(_Descripcion, 1, 25)
        _Desc2650 = Mid(_Descripcion, 26, 50)

        Sb_Imprimir_PRN(_Texto, _Puerto)

    End Sub

#End Region


#Region "PROCEDIMIENTOS PRIVADOS"

#Region "TRAER ETIQUETA"
    Private Function Fx_TraeEtiqueta(_NombreEtiqueta As String) As DataRow

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Where NombreEtiqueta = '" & _NombreEtiqueta & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Row As DataRow

        If CBool(_Tbl.Rows.Count) Then
            _Row = _Tbl.Rows(0)
        End If

        Return _Row

    End Function
#End Region

#Region "IMPRIMIR EL ARCHIVO"
    Private Sub Sb_Imprimir_PRN(_Texto As String,
                                _Puerto As String,
                                Optional _ImprimirAIP As Boolean = False)

        Dim _TextoOri As String = _Texto
        Dim _Fecha_impresion As Date = Now

        _Error = String.Empty

        'Try

        _Texto = Replace(_Texto, "<CODIGO_PR>", _Codigo_principal.ToString.Trim)
        _Texto = Replace(_Texto, "<CODIGO_TC>", _Codigo_tecnico.ToString.Trim)
        _Texto = Replace(_Texto, "<CODIGO_RA>", _Codigo_rapido.ToString.Trim)
        _Texto = Replace(_Texto, "<CODIGO_ALT>", _Codigo_Alternativo.ToString.Trim)

        _Texto = Replace(_Texto, "<UD1_PR>", _Ud1.ToString.Trim)
        _Texto = Replace(_Texto, "<UD2_PR>", _Ud2.ToString.Trim)

        Dim _Descripcion_cortamr As String

        If Not String.IsNullOrEmpty(_Marca_Pr) Then
            _Descripcion_cortamr = _Descripcion_Corta.ToString.Replace(_Marca_Pr, "").Trim
        End If

        _Texto = Replace(_Texto, "<DESCRIPCION_CORTASMR>", _Descripcion_cortamr)

        _Texto = Replace(_Texto, "<DESCRIPCION_PR>", _Descripcion)
        _Texto = Replace(_Texto, "<DESCRIPCION_CORTA>", _Descripcion_Corta)

        Dim _Desc0125mr As String
        Dim _Desc2650mr As String

        If Not String.IsNullOrEmpty(_Marca_Pr) Then
            _Desc0125mr = _Desc0125.ToString.Replace(_Marca_Pr, "").Trim
            _Desc2650mr = _Desc2650.ToString.Replace(_Marca_Pr, "").Trim
        End If

        _Texto = Replace(_Texto, "<DESCRIPCION_1-25MR>", _Desc0125mr)
        _Texto = Replace(_Texto, "<DESCRIPCION_26-50MR>", _Desc2650mr)

        _Texto = Replace(_Texto, "<DESCRIPCION_1-25>", _Desc0125)
        _Texto = Replace(_Texto, "<DESCRIPCION_26-50>", _Desc2650)

        _Texto = Replace(_Texto, "<DESCRIPCION_1-35>", _Desc_0135)
        _Texto = Replace(_Texto, "<DESCRIPCION_2-35>", _Desc_0235)

        _Texto = Replace(_Texto, "<UBICACION_PR>", _Ubicacion)
        _Texto = Replace(_Texto, "<UBICACION>", _Ubicacion)
        _Texto = Replace(_Texto, "<MARCA_PR>", _Marca_Pr)
        _Texto = Replace(_Texto, "<NODIM1>", _Nodim1)
        _Texto = Replace(_Texto, "<NODIM2>", _Nodim2)
        _Texto = Replace(_Texto, "<NODIM3>", _Nodim3)
        _Texto = Replace(_Texto, "<FECHAPROGRFUTURO>", Format(_FechaProgramada_Futuro, "dd-MM-yyyy"))
        _Texto = Replace(_Texto, "<RTU>", _Rtu)

        '_Texto = Replace(_Texto, "<UBIC_BAKAPP>", _Ubic_BakApp)
        _Texto = Replace(_Texto, "<WMS_UBIC_COLUMNA>", _Wms_Ubicacion_Columna)
        _Texto = Replace(_Texto, "<WMS_UBIC_FILA>", _Wms_Ubicacion_Fila)
        _Texto = Replace(_Texto, "<WMS_UBIC_CODIGO>", _Wms_Ubicacion_Codigo)
        _Texto = Replace(_Texto, "<WMS_UBIC_DESCR>", _Wms_Ubicacion_Nombre)

        _Texto = Replace(_Texto, "<WMS_SECTOR_CODIGO> ", _Wms_Sector_Codigo)
        _Texto = Replace(_Texto, "<WMS_SECTOR_DESC>", _Wms_Sector_Nombre)

        _Texto = Replace(_Texto, "<WMS_MAPA_NOMBRE> ", _Wms_Mapa_Nombre)

        _Texto = Replace(_Texto, "<STOCK_MIN_UBIC>", _Stock_Minimo_Ubic)
        _Texto = Replace(_Texto, "<STOCK_MAX_UBIC>", _Stock_Maximo_Ubic)

        _Texto = Replace(_Texto, "<PRECIO_UD1>", _Precio_ud1)
        _Texto = Replace(_Texto, "<PRECIO_UD2>", _Precio_ud2)

        Dim _vPrecioNetoXRtu As String
        Dim _vPrecioBrutoXRtu As String

        Try
            _vPrecioNetoXRtu = Fx_Formato_Numerico(_PrecioNetoXRtu, "9", False)
        Catch ex As Exception
            _vPrecioNetoXRtu = "?"
        End Try

        Try
            _vPrecioBrutoXRtu = Fx_Formato_Numerico(_PrecioBrutoXRtu, "9", False)
        Catch ex As Exception
            _vPrecioBrutoXRtu = "?"
        End Try

        If _Texto.Contains("PBRUTOUD1X6") Or _Texto.Contains("PBRUTOUD1XMULTIPLO") Or _Texto.Contains("PBRUTOUD2XMULTIPLO") Then

            Consulta_sql = "Select Top 1 * From TABCODAL Where KOPRAL = '" & _Codigo_Alternativo & "' And KOPR = '" & _Codigo_principal & "'"
            Dim _Row_Kopral As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Kopral) Then

                Dim _Unimulti As Integer = 1
                Dim _Multiplo As Integer = _Row_Kopral.Item("MULTIPLO")

                Dim _PrecioMulti As Double

                If _Texto.Contains("PBRUTOUD2XUNIMULTI2") Then
                    _Unimulti = 2
                End If

                If _Unimulti = 1 Then : _PrecioMulti = _PU01_Bruto : Else : _PrecioMulti = _PU02_Bruto : End If

                _PrecioBrutoXRtu = _Multiplo * _PrecioMulti

                _vPrecioBrutoXRtu = Fx_Formato_Numerico(_PrecioBrutoXRtu, "9", False)

                _Texto = Replace(_Texto, "<PBRUTOUD1X6>", _vPrecioBrutoXRtu)

            End If

        End If

        'If _Texto.Contains("PBRUTOUD1X6") Then
        '    _PrecioBrutoXRtu = 6 * _PU01_Bruto
        '    _vPrecioBrutoXRtu = Fx_Formato_Numerico(_PrecioBrutoXRtu, "9", False)
        '    '_Texto = Replace(_Texto, "<PNETOXRTU_UD1>", _vPrecioNetoXRtu)
        '    _Texto = Replace(_Texto, "<PBRUTOUD1X6>", _vPrecioBrutoXRtu)
        'End If

        Dim _St_PU01_Neto As String = Fx_Formato_Numerico(_PU01_Neto, "9", False)
        Dim _St_PU02_Neto As String = Fx_Formato_Numerico(_PU02_Neto, "9", False)
        Dim _St_PU01_Bruto As String = Fx_Formato_Numerico(_PU01_Bruto, "9", False)
        Dim _St_PU02_Bruto As String = Fx_Formato_Numerico(_PU02_Bruto, "9", False)

        Dim _St_PU01_Neto_d1 As String = Fx_Formato_Numerico(_PU01_Neto, "9,9", False)
        Dim _St_PU02_Neto_d1 As String = Fx_Formato_Numerico(_PU02_Neto, "9,9", False)
        Dim _St_PU01_Bruto_d1 As String = Fx_Formato_Numerico(_PU01_Bruto, "9,9", False)
        Dim _St_PU02_Bruto_d1 As String = Fx_Formato_Numerico(_PU02_Bruto, "9,9", False)

        Dim _St_PU01_Neto_d2 As String = Fx_Formato_Numerico(_PU01_Neto, "9,99", False)
        Dim _St_PU02_Neto_d2 As String = Fx_Formato_Numerico(_PU02_Neto, "9,99", False)
        Dim _St_PU01_Bruto_d2 As String = Fx_Formato_Numerico(_PU01_Bruto, "9,99", False)
        Dim _St_PU02_Bruto_d2 As String = Fx_Formato_Numerico(_PU02_Bruto, "9,99", False)

        Dim _St_PU01_Neto2 As String = Fx_Formato_Numerico(_PU01_Neto, "99.999", False)
        Dim _St_PU02_Neto2 As String = Fx_Formato_Numerico(_PU02_Neto, "99.999", False)
        Dim _St_PU01_Bruto2 As String = Fx_Formato_Numerico(_PU01_Bruto, "99.999", False)
        Dim _St_PU02_Bruto2 As String = Fx_Formato_Numerico(_PU02_Bruto, "99.999", False)

        Dim _St_PU01_Neto3 As String = Fx_Formato_Numerico(_PU01_Neto, "999.999", False)
        Dim _St_PU02_Neto3 As String = Fx_Formato_Numerico(_PU02_Neto, "999.999", False)
        Dim _St_PU01_Bruto3 As String = Fx_Formato_Numerico(_PU01_Bruto, "999.999", False)
        Dim _St_PU02_Bruto3 As String = Fx_Formato_Numerico(_PU02_Bruto, "999.999", False)

        Dim _Lc_PrecioEspLC1 As String
        Dim _Lc_PrecioEspLC2 As String

        Try
            _Lc_PrecioEspLC1 = Fx_Formato_Numerico(_PrecioLc1, "9", False)
        Catch ex As Exception
            _Lc_PrecioEspLC1 = "?"
        End Try

        Try
            _Lc_PrecioEspLC2 = Fx_Formato_Numerico(_PrecioLc1, "9.999.999", False)
        Catch ex As Exception
            _Lc_PrecioEspLC2 = "?"
        End Try


        Dim _St_PU01_Neto4 As String = Fx_Formato_Numerico(_PU01_Neto, "9.999.999", False)
        Dim _St_PU02_Neto4 As String = Fx_Formato_Numerico(_PU02_Neto, "9.999.999", False)
        Dim _St_PU01_Bruto4 As String = Fx_Formato_Numerico(_PU01_Bruto, "9.999.999", False)
        Dim _St_PU02_Bruto4 As String = Fx_Formato_Numerico(_PU02_Bruto, "9.999.999", False)

        _Texto = Replace(_Texto, "<PNETO_UD1>", _St_PU01_Neto)
        _Texto = Replace(_Texto, "<PNETO_UD2>", _St_PU02_Neto)

        ' Neto reserva 4 espacios a la derecha
        _Texto = Replace(_Texto, "<PNETO_UD1_2>", _St_PU01_Neto2)
        _Texto = Replace(_Texto, "<PNETO_UD2_2>", _St_PU02_Neto2)
        ' Neto reserva 5 espacios a la derecha
        _Texto = Replace(_Texto, "<PNETO_UD1_3>", _St_PU01_Neto3)
        _Texto = Replace(_Texto, "<PNETO_UD2_3>", _St_PU02_Neto3)
        ' Neto reserva 6 espacios a la derecha para millones
        _Texto = Replace(_Texto, "<PNETO_UD1_4>", _St_PU01_Neto4)
        _Texto = Replace(_Texto, "<PNETO_UD2_4>", _St_PU02_Neto4)

        _Texto = Replace(_Texto, "<PBRUTO_UD1>", _St_PU01_Bruto)
        _Texto = Replace(_Texto, "<PBRUTO_UD2>", _St_PU02_Bruto)

        _Texto = Replace(_Texto, "<PBRUTO_UD1_2>", _St_PU01_Bruto2)
        _Texto = Replace(_Texto, "<PBRUTO_UD2_2>", _St_PU02_Bruto2)

        _Texto = Replace(_Texto, "<PBRUTO_UD1_3>", _St_PU01_Bruto3)
        _Texto = Replace(_Texto, "<PBRUTO_UD2_3>", _St_PU02_Bruto3)

        _Texto = Replace(_Texto, "<PBRUTO_UD1_4>", _St_PU01_Bruto4)
        _Texto = Replace(_Texto, "<PBRUTO_UD2_4>", _St_PU02_Bruto4)

        'Precios especiales La Colchaguina
        _Texto = Replace(_Texto, "<PBRUTO_LCESP1>", _Lc_PrecioEspLC1)
        _Texto = Replace(_Texto, "<PBRUTO_LCESP2>", _Lc_PrecioEspLC2)

        _Texto = Replace(_Texto, "<FECHA_IMPRESION>", _Fecha_impresion)
        _Texto = Replace(_Texto, "<FECHA_IMPRESION2>", _Fecha_impresion.ToShortDateString)
        _Texto = Replace(_Texto, "<FECHA_IMPRESION3>", Format(_Fecha_impresion, "dd-MM-yyyy"))

        _Texto = Replace(_Texto, "<TIDO>", _Tido)
        _Texto = Replace(_Texto, "<NUDO>", _Nudo)

        _Texto = Replace(_Texto, "<TIDOPA>", _Tidopa)
        _Texto = Replace(_Texto, "<NUDOPA>", _Nudopa)

        _Texto = Replace(_Texto, "<NOMBRE_EMPRESA>", RazonEmpresa.ToString.Trim)

        Dim _PU01_BrutoCtdo As String
        Dim _PU02_BrutoCtdo As String

        _PU01_BrutoCtdo = Fx_FormatearValorCentrado(_PU01_Bruto, 12)
        _PU02_BrutoCtdo = Fx_FormatearValorCentrado(_PU02_Bruto, 12)

        _Texto = Replace(_Texto, "<PBRUTO_UD1_CENT>", _PU01_BrutoCtdo)
        _Texto = Replace(_Texto, "<PBRUTO_UD2_CENT>", _PU02_BrutoCtdo)

        Dim _Nudopa_Sc As String

        Try
            _Nudopa_Sc = CInt(_Nudopa)
        Catch ex As Exception
            _Nudopa_Sc = _Nudopa
        End Try

        _Texto = Replace(_Texto, "<NUDOPA_SC>", _Nudopa_Sc.Trim)

        If _ImprimirAIP Then
            EnviarEtiqueta(_Texto)
        Else

            Dim fic As String = AppPath(True) & "Barra.prn"

            Dim sw As New System.IO.StreamWriter(fic)
            sw.WriteLine(_Texto)
            sw.Close()

            System.IO.File.Copy(fic, _Puerto)

        End If

    End Sub

    Function Fx_FormatearValorCentrado(valor As String, Optional largo As Integer = 12) As String
        ' Intenta convertir a número y dar formato con puntos como separador de miles
        Dim valorNumerico As Decimal
        If Decimal.TryParse(valor, valorNumerico) Then
            valor = valorNumerico.ToString("#,##0") ' Ej: 9.999.999
        End If

        ' Agrega el símbolo $
        Dim valorFormateado As String = "$ " & valor

        ' Si el resultado es mayor que el largo, recorta
        If valorFormateado.Length > largo Then
            valorFormateado = valorFormateado.Substring(0, largo)
        End If

        ' Centrado visual: calcula espacios a la izquierda y derecha
        Dim espaciosTotales As Integer = largo - valorFormateado.Length
        Dim espaciosIzquierda As Integer = espaciosTotales \ 2
        Dim espaciosDerecha As Integer = espaciosTotales - espaciosIzquierda

        ' Devuelve el valor con espacios a ambos lados
        Return New String(" "c, espaciosIzquierda) & valorFormateado & New String(" "c, espaciosDerecha)
    End Function

#End Region

#Region "TRAER DATOS DEL PRODUCTO"

    Private Function Fx_DatosProducto(_Codigo As String,
                                      _CodLista As String,
                                      _Empresa As String,
                                      _Sucursal As String,
                                      _Bodega As String,
                                      Optional _CodEntidad As String = "",
                                      Optional _Codigo_Ubic As String = "",
                                      Optional _ImprimirDesdePrecioFuturo As Boolean = False,
                                      Optional _Id_PrecioFuturo As Integer = 0) As DataRow

        If String.IsNullOrEmpty(_Codigo_Ubic) Then

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Codigo = '" & _Codigo & "' And Primaria = 1"

        Else

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Ubicacion 
                            Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) &
                            "And Bodega = '" & _Bodega & "' And Codigo_Ubic = '" & _Codigo_Ubic & "' And Codigo = '" & _Codigo & "'"

        End If

        Dim _TblUbicacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Ubic_BakApp As String
        Dim _Stock_Minimo_Ubic As Double
        Dim _Stock_Maximo_Ubic As Double

        If CBool(_TblUbicacion.Rows.Count) Then

            _Ubic_BakApp = _TblUbicacion.Rows(0).Item("Codigo_Ubic")
            _Stock_Minimo_Ubic = _TblUbicacion.Rows(0).Item("Stock_Minimo_Ubic")
            _Stock_Maximo_Ubic = _TblUbicacion.Rows(0).Item("Stock_Maximo_Ubic")

        End If

        Consulta_sql = "Select TOP 1 *,Isnull((Select top 1 DATOSUBIC From TABBOPR" & vbCrLf &
                       "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal &
                       "' AND KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'),'') As 'Ubic_Random'," & vbCrLf &
                       "'" & _Ubic_BakApp & "' As 'Ubic_BakApp'," & vbCrLf &
                       "Cast(" & De_Num_a_Tx_01(_Stock_Minimo_Ubic, False, 5) & " As Float) As 'Stock_Minimo_Ubic'," & vbCrLf &
                       "Cast(" & De_Num_a_Tx_01(_Stock_Maximo_Ubic, False, 5) & " As Float) As 'Stock_Maximo_Ubic'," & vbCrLf &
                       "Isnull((Select Top 1 PP01UD From TABPRE Where KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'),0) As Precio_ud1," & vbCrLf &
                       "Isnull((Select Top 1 PP02UD From TABPRE Where KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'),0) As Precio_ud2," & vbCrLf &
                       "Cast(0 As Float) As 'PrecioNetoXRtu',Cast(0 As Float) As 'PrecioBrutoXRtu'," & vbCrLf &
                       "Isnull((Select top 1 PM From MAEPREM Where EMPRESA = '" & Mod_Empresa & "' And KOPR = '" & _Codigo & "'),0) As 'PM'," & vbCrLf &
                       "Isnull((Select top 1 PPUL01 From MAEPREM Where EMPRESA = '" & Mod_Empresa & "' And KOPR = '" & _Codigo & "'),0) As 'PU01'," & vbCrLf &
                       "Isnull((Select top 1 PPUL02 From MAEPREM Where EMPRESA = '" & Mod_Empresa & "' And KOPR = '" & _Codigo & "'),0) As 'PU02'," & vbCrLf &
                       "Isnull((Select top 1 KOPRAL From TABCODAL Where KOEN = '" & _CodEntidad & "' And KOPR = '" & _Codigo & "'),'') As Codigo_Alternativo," & vbCrLf &
                       "Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = MRPR),'') As Marca," & vbCrLf &
                       "Cast(0 As Float) As PU01_Neto,Cast(0 As Float) As PU02_Neto,Cast(0 As Float) As PU01_Bruto,Cast(0 As Float) As PU02_Bruto,Getdate() As FechaProgramada" & vbCrLf &
                       "From MAEPR Where KOPR = '" & _Codigo & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _RowProducto As DataRow = _Tbl.Rows(0)

            Sb_Incorporar_Precios(_RowProducto, _CodLista, _ImprimirDesdePrecioFuturo, _Id_PrecioFuturo)

            Return _RowProducto

        Else
            Return Nothing
        End If

    End Function

    Sub Sb_Incorporar_Precios(ByRef _RowProducto As DataRow,
                              _CodLista As String,
                              _ImprimirDesdePrecioFuturo As Boolean,
                              _Id_PrecioFuturo As Integer)

        'Dim _RowProducto As DataRow = _Tbl.Rows(0)
        Dim _Codigo As String = _RowProducto.Item("KOPR")

        Consulta_sql = "Select Isnull(Sum(POIM),0) As Impuesto From TABIM" & Space(1) &
                       "Where KOIM In (Select KOIM From TABIMPR Where KOPR = '" & _Codigo & "')"
        Dim _RowImpuestos As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _PorIva As Double = _RowProducto.Item("POIVPR")
        Dim _PorIla As Double = _RowImpuestos.Item("Impuesto")

        Dim _Iva = _PorIva / 100
        Dim _Ila = _PorIla / 100

        Dim _Impuestos As Double = 1 + (_Iva + _Ila)


        Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = '" & _CodLista & "') As MELT" & vbCrLf &
                       "From TABPRE" & vbCrLf &
                       "Where KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'"
        Dim _RowPrecios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Ecuacion As String
        Dim _Ecuacionu2 As String

        Dim _PrecioListaUd1 As Double
        Dim _PrecioListaUd2 As Double

        Dim _Melt As String = _RowPrecios.Item("MELT")

        If Not IsNothing(_RowPrecios) Then

            _Ecuacion = NuloPorNro(_RowPrecios.Item("ECUACION").ToString.Trim, "")
            _Ecuacionu2 = NuloPorNro(_RowPrecios.Item("ECUACIONU2").ToString.Trim, "")

            _PrecioListaUd1 = Fx_Funcion_Ecuacion_Random(Nothing, _CodEntidad, _Ecuacion, _Codigo, 1, _RowPrecios, 0, 0, 0)
            _PrecioListaUd2 = Fx_Funcion_Ecuacion_Random(Nothing, _CodEntidad, _Ecuacionu2, _Codigo, 2, _RowPrecios, 0, 0, 0)

            If _PrecioListaUd1 = 0 Then _PrecioListaUd1 = NuloPorNro(_RowPrecios.Item("PP01UD"), 0)
            If _PrecioListaUd2 = 0 Then _PrecioListaUd2 = NuloPorNro(_RowPrecios.Item("PP02UD"), 0)

        End If

        If _ImprimirDesdePrecioFuturo Then

            If CBool(_Id_PrecioFuturo) Then
                Consulta_sql = "Select Top 1 LEnc.Codigo, NombreProgramacion, FechaCreacion, FechaProgramada, Funcionario, Activo,LDet.*" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_ListaLC_Programadas LEnc" & vbCrLf &
                               "Inner Join " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles LDet On LEnc.Id = LDet.Id_Enc" & vbCrLf &
                               "Where LDet.Id = " & _Id_PrecioFuturo
            Else
                Consulta_sql = "Select Top 1 LEnc.Codigo, NombreProgramacion, FechaCreacion, FechaProgramada, Funcionario, Activo,LDet.*" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_ListaLC_Programadas LEnc" & vbCrLf &
                               "Inner Join " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles LDet On LEnc.Id = LDet.Id_Enc" & vbCrLf &
                               "Where LEnc.Codigo = '" & _Codigo & "' And LDet.Lista = '" & _CodLista & "' Order by LEnc.Id"
            End If


            Dim _Row_PrecioFuturo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_PrecioFuturo) Then

                _PrecioListaUd1 = _Row_PrecioFuturo.Item("PrecioUd1")
                _PrecioListaUd2 = _Row_PrecioFuturo.Item("PrecioUd2")

                _RowProducto.Item("Precio_ud1") = _PrecioListaUd1
                _RowProducto.Item("Precio_ud2") = _PrecioListaUd2
                _RowProducto.Item("FechaProgramada") = _Row_PrecioFuturo.Item("FechaProgramada")

            End If

        End If


        Dim _PU01_Neto, _PU02_Neto As Double
        Dim _PU01_Bruto, _PU02_Bruto As Double

        If _Melt = "N" Then
            _PU01_Neto = _PrecioListaUd1
            _PU02_Neto = _PrecioListaUd2
            _PU01_Bruto = Math.Round(_PU01_Neto * _Impuestos, 0)
            _PU02_Bruto = Math.Round(_PU02_Neto * _Impuestos, 0)
        End If

        If _Melt = "B" Then
            _PU01_Bruto = _PrecioListaUd1
            _PU02_Bruto = _PrecioListaUd2
            _PU01_Neto = Math.Round(_PU01_Bruto / _Impuestos, 2)
            _PU02_Neto = Math.Round(_PU02_Bruto / _Impuestos, 2)
        End If

        _RowProducto.Item("PU01_Neto") = _PU01_Neto
        _RowProducto.Item("PU02_Neto") = _PU02_Neto

        _RowProducto.Item("PU01_Bruto") = _PU01_Bruto
        _RowProducto.Item("PU02_Bruto") = _PU02_Bruto

        _RowProducto.Item("PrecioNetoXRtu") = _RowProducto.Item("RLUD") * _PU01_Neto
        _RowProducto.Item("PrecioBrutoXRtu") = _RowProducto.Item("RLUD") * _PU01_Bruto

    End Sub

#End Region

#Region "TRAER DATOS DE UBICACION"

    Private Function Fx_Datos_Ubicacion(_Empresa As String,
                                        _Sucursal As String,
                                        _Bodega As String,
                                        _Id_Mapa As Integer,
                                        _Codigo_Sector As String,
                                        _Codigo_Ubic As String) As DataRow

        Consulta_sql = "Select Mapa.Nombre_Mapa,Sector.Nombre_Sector,Ubic.*
                        From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Ubic
                        Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Mapa On Mapa.Id_Mapa = Ubic.Id_Mapa
                        Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Sector On Sector.Id_Mapa = Ubic.Id_Mapa And Sector.Codigo_Sector = Ubic.Codigo_Sector
                        Where Ubic.Empresa = '" & _Empresa & "' And Ubic.Sucursal = '" & _Sucursal & "' And Ubic.Bodega = '" & _Bodega &
                        "' And Ubic.Id_Mapa = " & _Id_Mapa & " And Ubic.Codigo_Sector = '" & _Codigo_Sector & "' And Ubic.Codigo_Ubic = '" & _Codigo_Ubic & "'"

        Dim _RowUbicacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Return _RowUbicacion

    End Function

#End Region

#End Region

End Class

