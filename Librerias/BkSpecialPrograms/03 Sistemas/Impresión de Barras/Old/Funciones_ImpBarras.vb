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
    Dim _Desc0125
    Dim _Desc2650
    Dim _Ubicacion
    Dim _Precio_ud1
    Dim _Precio_ud2
    Dim _PrecioNetoXRtu
    Dim _PrecioBrutoXRtu
    Dim _Rtu

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
                             _Id_PrecioFuturo As Integer)

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

                Sb_Imprimir_PRN(_Texto, _Puerto)

            Next

        Else

            Dim _RowProducto As DataRow = Fx_DatosProducto(_Codigo,
                                                           _CodLista,
                                                           _Empresa,
                                                           _Sucursal,
                                                           _Bodega,,
                                                           _CodUbicacion,
                                                           _ImprimirDesdePrecioFuturo, _Id_PrecioFuturo)

            _Codigo_principal = _Codigo
            _Codigo_tecnico = _RowProducto.Item("KOPRTE")
            _Codigo_rapido = _RowProducto.Item("KOPRRA")
            _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
            _Descripcion_Corta = _RowProducto.Item("NOKOPRRA").ToString.Trim

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

            _PrecioLc1 = (_Precio_ud1 / _Dim1) * _Dim2

            Dim _RowEtiqueta As DataRow = Fx_TraeEtiqueta(_NombreEtiqueta)

            Dim _Texto = _RowEtiqueta.Item("FUNCION")

            Sb_Imprimir_PRN(_Texto, _Puerto)

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

        Fx_Producto_Ubicaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Function

#End Region

#Region "IMPRIMIR DESDE DOCUMENTO"

    Sub Sb_Imprimir_Documento(_NombreEtiqueta As String,
                              _Puerto As String,
                              _Idmaeedo As String,
                              _Idmaeddo As String)

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

        For Each _Fila As DataRow In _TblDetalle.Rows

            Dim _Id = _Fila.Item("IDMAEDDO")

            If _Idmaeddo = _Id Then

                _Codigo_principal = _Fila.Item("KOPRCT")

                Dim _Lista = _Fila.Item("LISTA")
                Dim _Empresa = _Fila.Item("EMPRESA")
                Dim _Sucursal = _Fila.Item("SULIDO")
                Dim _Bodega = _Fila.Item("BOSULIDO")

                _RowProducto = Fx_DatosProducto(_Codigo_principal, _Lista, _Empresa, _Sucursal, _Bodega, _CodEntidad)

                Exit For

            End If

        Next



        _Tido = _TblEncabezado.Rows(0).Item("TIDO")
        _Nudo = _TblEncabezado.Rows(0).Item("NUDO")

        _Codigo_tecnico = _RowProducto.Item("KOPRTE")
        _Codigo_rapido = _RowProducto.Item("KOPRRA")
        _Codigo_Alternativo = _RowProducto.Item("Codigo_Alternativo")

        _Descripcion = _RowProducto.Item("NOKOPR")
        _Desc0125 = Mid(_Descripcion, 1, 25)
        _Desc2650 = Mid(_Descripcion, 26, 50)

        _Ubicacion = _RowProducto.Item("Ubic_Random")
        '_Ubic_BakApp = _RowProducto.Item("Ubic_BakApp")

        _Precio_ud1 = _RowProducto.Item("Precio_ud1")
        _Precio_ud2 = _RowProducto.Item("Precio_ud2")

        _Stock_Minimo_Ubic = _RowProducto.Item("Stock_Minimo_Ubic")
        _Stock_Maximo_Ubic = _RowProducto.Item("Stock_Maximo_Ubic")



        Sb_Imprimir_PRN(_Texto, _Puerto)

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

#Region "PROCEDIMIENTOS PRIVADOS"

#Region "TRAER ETIQUETA"
    Private Function Fx_TraeEtiqueta(_NombreEtiqueta As String) As DataRow

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Where NombreEtiqueta = '" & _NombreEtiqueta & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Row As DataRow

        If CBool(_Tbl.Rows.Count) Then
            _Row = _Tbl.Rows(0)
        End If

        Return _Row

    End Function
#End Region

#Region "IMPRIMIR EL ARCHIVO"
    Private Sub Sb_Imprimir_PRN(_Texto As String, _Puerto As String)

        Dim _Fecha_impresion As Date = Now

        _Error = String.Empty

        'Try

        _Texto = Replace(_Texto, "<CODIGO_PR>", Trim(_Codigo_principal))
        _Texto = Replace(_Texto, "<CODIGO_TC>", Trim(_Codigo_tecnico))
        _Texto = Replace(_Texto, "<CODIGO_RA>", Trim(_Codigo_rapido))
        _Texto = Replace(_Texto, "<CODIGO_ALT>", Trim(_Codigo_Alternativo))

        Dim _Descripcion_cortamr As String = _Descripcion_Corta.ToString.Replace(_Marca_Pr, "").Trim
        _Texto = Replace(_Texto, "<DESCRIPCION_CORTASMR>", _Descripcion_cortamr)

        _Texto = Replace(_Texto, "<DESCRIPCION_PR>", _Descripcion)
        _Texto = Replace(_Texto, "<DESCRIPCION_CORTA>", _Descripcion_Corta)

        Dim _Desc0125mr As String = _Desc0125.ToString.Replace(_Marca_Pr, "").Trim
        Dim _Desc2650mr As String = _Desc2650.ToString.Replace(_Marca_Pr, "").Trim

        _Texto = Replace(_Texto, "<DESCRIPCION_1-25MR>", _Desc0125mr)
        _Texto = Replace(_Texto, "<DESCRIPCION_26-50MR>", _Desc2650mr)

        _Texto = Replace(_Texto, "<DESCRIPCION_1-25>", _Desc0125)
        _Texto = Replace(_Texto, "<DESCRIPCION_26-50>", _Desc2650)


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

        Dim _vPrecioNetoXRtu As String = Fx_Formato_Numerico(_PrecioNetoXRtu, "9", False)
        Dim _vPrecioBrutoXRtu As String = Fx_Formato_Numerico(_PrecioBrutoXRtu, "9", False)

        If _Texto.Contains("PBRUTOUD1X6") Then
            _PrecioBrutoXRtu = 6 * _PU01_Bruto
            _vPrecioBrutoXRtu = Fx_Formato_Numerico(_PrecioBrutoXRtu, "9", False)
            '_Texto = Replace(_Texto, "<PNETOXRTU_UD1>", _vPrecioNetoXRtu)
            _Texto = Replace(_Texto, "<PBRUTOUD1X6>", _vPrecioBrutoXRtu)
        End If

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

        Dim _Lc_PrecioEspLC1 As String = Fx_Formato_Numerico(_PrecioLc1, "9", False)
        Dim _Lc_PrecioEspLC2 As String = Fx_Formato_Numerico(_PrecioLc1, "9.999.999", False)

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

        Dim fic As String = AppPath(True) & "Barra.prn"

        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine(_Texto)
        sw.Close()

        'MsgBox("Aca" & vbCrLf & fic)

        'System.IO.File.Copy("Barra.prn", _Puerto)
        System.IO.File.Copy(fic, _Puerto)

        'Catch ex As Exception
        '    _Error = ex.Message
        'End Try

    End Sub
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

        Dim _TblUbicacion As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

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
                       "Isnull((Select top 1 PM From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'),0) As 'PM'," & vbCrLf &
                       "Isnull((Select top 1 PPUL01 From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'),0) As 'PU01'," & vbCrLf &
                       "Isnull((Select top 1 PPUL02 From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'),0) As 'PU02'," & vbCrLf &
                       "Isnull((Select top 1 KOPRAL From TABCODAL Where KOEN = '" & _CodEntidad & "' And KOPR = '" & _Codigo & "'),'') As Codigo_Alternativo," & vbCrLf &
                       "Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = MRPR),'') As Marca," & vbCrLf &
                       "Cast(0 As Float) As PU01_Neto,Cast(0 As Float) As PU02_Neto,Cast(0 As Float) As PU01_Bruto,Cast(0 As Float) As PU02_Bruto,Getdate() As FechaProgramada" & vbCrLf &
                       "From MAEPR Where KOPR = '" & _Codigo & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

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


        Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = '" & _CodLista & "') As MELT From TABPRE
                            Where KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'"
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

