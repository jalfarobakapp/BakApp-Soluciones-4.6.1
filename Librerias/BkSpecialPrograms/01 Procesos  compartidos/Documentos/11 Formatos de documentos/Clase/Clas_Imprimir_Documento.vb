Imports System.Drawing.Printing
Imports System.IO
Imports System.Xml.XPath
Imports DevComponents.DotNetBar
Imports Gma.QrCodeNet.Encoding.Windows.Forms

Public Class Clas_Imprimir_Documento

#Region "VARIABLES"

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _IdDoc As Integer
    Dim _Emdp As String

    Dim _Row_Encabezado As DataRow

    Dim _Tbl_Encabezado As DataTable
    Dim _Tbl_Detalle As DataTable
    Dim _Tbl_Detalle_Agrupado As DataTable
    Dim _Tbl_Referencias As DataTable           ' Documentos de referencia asociados 
    Dim _Tbl_Doc_Asociados_Recargos As DataTable    ' Documentos asociados al recargo

    Dim _Row_Servicio_Tecnico_Enc As DataRow

    Dim _Tbl_Fx_Encabezado As DataTable  ' Formato del detalle
    Dim _Tbl_Fx_Detalle As DataTable     ' Formato del detalle

    'Dim _Fx As Frm_Formato_Creador_Funciones

    Dim _TipoDoc As String
    Dim _Subtido As String
    Dim _NombreFormato As String
    Dim _Impresora As String

    Dim _Ds_Documento_Imprimir As DataSet
    Dim _NombreDocumento As String

    Dim _PrtSettings As New PrinterSettings

    Dim _Imprimir_Cedible As Boolean
    Dim _Paginas As Integer

    Dim _Ultimo_Error As String
    Dim _Es_Picking As Boolean
    Dim _Texto_Prod_Otras_Bodegas As String

    Dim _QrCodeImgControl As New QrCodeImgControl

    Enum _Tipo_impresion
        Documento
        Vale
        Vale_direccion
        Solicitud
        Solicitud_direccion
        Solicitar_Producto
    End Enum

    Dim _Timbre_Falso As Boolean

    Dim printPreviewDialog1 As New PrintPreviewDialog()
    Dim printDoc As New PrintDocument

    Dim _Doc_AnchoDoc As Integer
    Dim _Doc_LargoDoc As Integer

    Dim _Fila_Y As Integer
    Dim _Columna_X As Integer

    Dim _TblEncForm As DataTable
    Dim _Fila_InicioDetalle As Double
    Dim _Fila_FinDetalle As Double

    Dim _DtFont As New Font("Arial", 9, FontStyle.Regular)

    ' Fuente del detalle
    'Dim _PrFont As New Font("Arial", 9, FontStyle.Bold)
    'Dim _FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
    'Dim _FontCon As New Font("Times New Roman", 11, FontStyle.Bold)

    'Dim _FteCourier_New_C_6 As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente
    'Dim _FteCourier_New_C_7 As New Font("Courier New", 7, FontStyle.Bold) ' Crea la fuente
    'Dim _FteCourier_New_C_8 As New Font("Courier New", 8, FontStyle.Regular) ' Crea la fuente
    'Dim _FteCourier_New_C_9 As New Font("Courier New", 9, FontStyle.Regular) ' Crea la fuente
    'Dim _FteCourier_New_C_10 As New Font("Courier New", 10, FontStyle.Bold) ' Crea la fuente
    'Dim _FteCourier_New_C_11 As New Font("Courier New", 11, FontStyle.Bold) ' Crea la fuente
    'Dim _FteCourier_New_C_12 As New Font("Courier New", 12, FontStyle.Bold) ' Crea la fuente
    'Dim _FteCourier_New_C_13 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente
    'Dim _FteCourier_New_C_14 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente

    Dim _Documento_Impreso As Boolean

#End Region

    Dim _Es_Cheque As Boolean
    Dim _Es_Solicitud_Prod_Bodega As Boolean

    Public Property Pro_Impresora() As String
        Get
            Return _Impresora
        End Get
        Set(value As String)
            _Impresora = value
            _PrtSettings.PrinterName = _Impresora
        End Set
    End Property

    Public ReadOnly Property Pro_Ultimo_Error() As String
        Get
            Return _Ultimo_Error
        End Get
    End Property

    Public ReadOnly Property Pro_Documento_Impreso() As Boolean
        Get
            Return _Documento_Impreso
        End Get
    End Property

    Public Property PrintDoc1 As PrintDocument
        Get
            Return printDoc
        End Get
        Set(value As PrintDocument)
            printDoc = value
        End Set
    End Property

    Public Property Tbl_Fx_Encabezado As DataTable
        Get
            Return _Tbl_Fx_Encabezado
        End Get
        Set(value As DataTable)
            _Tbl_Fx_Encabezado = value
        End Set
    End Property

    Public Property Tbl_Fx_Detalle As DataTable
        Get
            Return _Tbl_Fx_Detalle
        End Get
        Set(value As DataTable)
            _Tbl_Fx_Detalle = value
        End Set
    End Property

    Public Property Tbl_Encabezado As DataTable
        Get
            Return _Tbl_Encabezado
        End Get
        Set(value As DataTable)
            _Tbl_Encabezado = value
        End Set
    End Property

    Public Property Tbl_Detalle As DataTable
        Get
            Return _Tbl_Detalle
        End Get
        Set(value As DataTable)
            _Tbl_Detalle = value
        End Set
    End Property

    Public Sub New(_IdDoc As Integer,
                   _TipoDoc As String,
                   _NombreFormato As String,
                   _NombreDocumento As String,
                   _Imprimir_Cedible As Boolean,
                   _Emdp As String,
                   _Subtido As String)

        Me._IdDoc = _IdDoc 'IDMAEEDO
        Me._TipoDoc = _TipoDoc
        Me._Subtido = _Subtido
        Me._NombreFormato = _NombreFormato
        Me._Imprimir_Cedible = _Imprimir_Cedible
        Me._Emdp = _Emdp

        If _NombreFormato = "Solicitud_PrBd" Then

            _Es_Solicitud_Prod_Bodega = True
            _Imprimir_Cedible = False
            _Emdp = String.Empty
            _TipoDoc = "SPB"
            _NombreFormato = "X Defecto"
            Sb_Traer_Datos_Para_Impresion_De_Productos_Solicitados_A_Bodega(_IdDoc)

        Else

            If _NombreDocumento <> "Regleta" Then

                If Not String.IsNullOrEmpty(_Emdp) Then
                    _Es_Cheque = True
                End If

                If _Es_Cheque Then
                    Sb_Traer_Datos_Para_Impresion_De_Cheques()
                Else
                    Sb_Traer_Datos_Para_Impresion_De_Documentos_Venta_Compra()
                End If

                If _Imprimir_Cedible Then
                    printDoc.DocumentName = _NombreDocumento & " Cedible"
                Else
                    printDoc.DocumentName = _NombreDocumento
                End If

            End If

        End If

    End Sub

    Sub Sb_Traer_Datos_Para_Impresion_De_Documentos_Venta_Compra()

        If _Imprimir_Cedible Then
            printDoc.DocumentName = _NombreDocumento & " Cedible"
        Else
            printDoc.DocumentName = _NombreDocumento
        End If

        ' Llena Formato del Encabezado
        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And NombreFormato = '" & _NombreFormato & "' And Subtido = '" & _Subtido & "'"
        _TblEncForm = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Es_Picking = _TblEncForm.Rows(0).Item("Es_Picking")

        Dim _Condicion_Extra_Maeddo As String
        Dim _Filtro_Productos As String
        Dim _Orden_Detalle As String

        If _Es_Picking Then
            _Condicion_Extra_Maeddo = "And SULIDO = '" & ModSucursal & "' And BOSULIDO = '" & ModBodega & "' Order By UBICACION"
            _Orden_Detalle = "Order By UBICACION"
        Else
            _Condicion_Extra_Maeddo = "Order By IDMAEDDO"
            _Orden_Detalle = "Order By IDMAEDDO"
        End If

        Dim _Reg As Boolean = CInt(_Sql.Fx_Cuenta_Registros("MAEEDOOB", "IDMAEEDO = " & _IdDoc))

        If Not _Reg Then
            Consulta_sql = "Insert Into MAEEDOOB (IDMAEEDO,OBDO,CPDO,OCDO) VALUES (" & _IdDoc & ",'','','')"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Dim _Detalle_Doc_Incluye = _TblEncForm.Rows(0).Item("Detalle_Doc_Incluye")

        If _Detalle_Doc_Incluye = "SP" Then _Filtro_Productos = "Where TICT = ''" '_Imprimir_Fila = (_Tict = "")
        If _Detalle_Doc_Incluye = "PD" Then _Filtro_Productos = "Where TICT In ('','D')" '_Imprimir_Fila = (_Tict = "D")
        If _Detalle_Doc_Incluye = "PR" Then _Filtro_Productos = "Where TICT In ('','R')" '_Imprimir_Fila = (_Tict = "R")
        If _Detalle_Doc_Incluye = "TD" Then _Filtro_Productos = String.Empty ' _Imprimir_Fila = True

        Consulta_sql = My.Resources.Recursos_Formato_Documento.SQLQuery_Traer_Documento_Para_Imprimir
        Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _IdDoc)
        Consulta_sql = Replace(Consulta_sql, "#Condicion_Extra_Maeddo#", _Condicion_Extra_Maeddo)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Orden_Detalle#", _Orden_Detalle)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Row_Encabezado = _Ds.Tables(0).Rows(0)

        _Tbl_Encabezado = _Ds.Tables(0)
        _Tbl_Detalle = _Ds.Tables(1)
        _Tbl_Referencias = _Ds.Tables(2)
        _Tbl_Detalle_Agrupado = _Ds.Tables(3)
        _Tbl_Doc_Asociados_Recargos = _Ds.Tables(4)

        For Each _Fl As DataRow In _Tbl_Detalle.Rows
            Dim _Ficha As String = String.Empty
            Consulta_sql = "Select * From MAEFICHD Where KOPR = '" & _Fl.Item("KOPR") & "'"
            Dim _Tbl_Maefichd As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            For Each _Fichas As DataRow In _Tbl_Maefichd.Rows
                _Ficha += _Fichas.Item("FICHA")
            Next
            _Ficha = NuloPorNro(_Ficha, "")
            _Ficha = Replace(_Ficha, Chr(13), " ")
            _Ficha = Replace(_Ficha, vbLf, " ")
            _Ficha = Replace(_Ficha, vbCrLf, " ")
            Try
                _Fl.Item("MAEFICHD") = _Ficha.Trim
            Catch ex As Exception
                _Fl.Item("MAEFICHD") = String.Empty
            End Try
        Next

        _Row_Encabezado = Fx_New_Inserta_Funciones_Bk_En_Encabezado(_Row_Encabezado)

        Consulta_sql = "Select Fdt.*,
	                       Isnull(Fx.Funcion_Bk,'') As Funcion_Bk,
	                       Isnull(Fx.Formato,'') As Formato_Fx,
	                       Isnull(Fx.Campo,'') As Campo,
	                       Isnull(Fx.Codigo_De_Barras,'') As Codigo_De_Barras,
                           Isnull(Fx.CodigoQR,'') As CodigoQR,
	                       Isnull(Fx.Es_Descuento,0) As Es_Descuento,
	                       Isnull(Fx.SqlQuery,'') As SqlQuery, 
	                       Isnull(Fx.SQL_Personalizada,0) As SQL_Personalizada
                    From " & _Global_BaseBk & "Zw_Format_02 Fdt
                    Left Join " & _Global_BaseBk & "Zw_Format_Fx Fx On Fdt.Funcion = Fx.Nombre_Funcion
                    Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Fdt.Seccion In ('E','P')"

        _Tbl_Fx_Encabezado = _Sql.Fx_Get_Tablas(Consulta_sql)

        ' Llena formato del detalle
        Consulta_sql = "Select Fdt.*,
	                       Isnull(Fx.Funcion_Bk,'') As Funcion_Bk,
	                       Isnull(Fx.Formato,'') As Formato_Fx,
	                       Isnull(Fx.Campo,'') As Campo,
	                       Isnull(Fx.Codigo_De_Barras,'') As Codigo_De_Barras,
                           Isnull(Fx.CodigoQR,'') As CodigoQR,
	                       Isnull(Fx.Es_Descuento,0) As Es_Descuento,
	                       Isnull(Fx.SqlQuery,'') As SqlQuery, 
	                       Isnull(Fx.SQL_Personalizada,0) As SQL_Personalizada
                    From " & _Global_BaseBk & "Zw_Format_02 Fdt
                    Left Join " & _Global_BaseBk & "Zw_Format_Fx Fx On Fdt.Funcion = Fx.Nombre_Funcion
                    Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Fdt.Seccion = 'D'" & vbCrLf &
                    "Order by Fdt.Orden_Detalle"

        _Tbl_Fx_Detalle = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _TipoDoc.Contains("GRP") Or _TipoDoc.Contains("GDP") Then

            Consulta_sql = "Declare @Id_Ot Int 

                            Set @Id_Ot = (Select Distinct Id_Ot_Padre From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Idmaeedo_" & _TipoDoc & "_PRE = " & _IdDoc & ")

                            Select ZEnc.Id_Ot, ZEnc.Nro_Ot,Empresa,ZEnc.Sucursal,ZEnc.Bodega,ZEnc.CodEntidad,ZEnc.SucEntidad,ZEnc.Rten,ZEnc.Rut, 
                            NOKOEN As Cliente,ZEnc.Fecha_Ingreso,ZEnc.Fecha_Compromiso,ZEnc.Fecha_Entrega,ZEnc.Fecha_Cierre,ZEnc.CodEstado, 
                            IsNull(ZCarac1.NombreTabla,'') As 'Estado',ZEnc.CodMaquina,ZEnc.CodMarca,ZEnc.CodModelo,ZEnc.CodCategoria,ZEnc.NroSerie,ZEnc.Chk_Serv_Domicilio,
	                        ZEnc.Pais,ZEnc.Ciudad,ZEnc.Comuna,ZEnc.Direccion,ZEnc.Nombre_Contacto,ZEnc.Telefono_Contacto,ZEnc.Email_Contacto,ZEnc.Chk_Serv_Reparacion_Stock,
	                        ZEnc.Chk_Serv_Mantenimiento_Correctivo,ZEnc.Chk_Serv_Presupuesto_Pre_Aprobado,ZEnc.Chk_Serv_Recoleccion,ZEnc.Chk_Serv_Mantenimiento_Preventivo,ZEnc.Chk_Serv_Garantia,
                            ZEnc.Chk_Serv_Demostracion_Maquina,ZEnc.CodTecnico_Asignado,Isnull(ZTecAsig.NomFuncionario,'') As Tecnico_Asignado,
                            ZEnc.CodTecnico_Repara,Isnull(ZTecRep.NomFuncionario,'') As Tecnico_Repara,IsNull(ZCarac2.NombreTabla,'') As Estado_Entrega, 
                            Chk_Equipo_Abandonado_Por_El_Cliente,Chk_No_Existe_COV_Ni_NVV,Codigo,Descripcion,Idmaeedo_GRP_PRE,Idmaeedo_GDP_PRE,
	                        Defecto_segun_cliente, Reparacion_a_realizar, Defecto_encontrado, Reparacion_Realizada, Chk_no_se_pudo_reparar, 
                            Motivo_no_reparo,Nota_Etapa_01,Nota_Etapa_02,Nota_Etapa_03,Nota_Etapa_04,Nota_Etapa_05,Nota_Etapa_06,Nota_Etapa_07,Nota_Etapa_08
                            From " & _Global_BaseBk & "Zw_St_OT_Encabezado ZEnc
	                            Inner Join " & _Global_BaseBk & "Zw_St_OT_Notas ZNotas On ZEnc.Id_Ot = ZNotas.Id_Ot
		                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones ZCarac1 On ZCarac1.Tabla = 'ESTADOS_ST' And ZCarac1.CodigoTabla = CodEstado
			                            Left Join " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller ZTecAsig On ZTecAsig.CodFuncionario = ZEnc.CodTecnico_Asignado
				                            Left Join " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller ZTecRep On ZTecRep.CodFuncionario = ZEnc.CodTecnico_Asignado
					                            Left Join MAEEN On KOEN = ZEnc.CodEntidad And SUEN = ZEnc.SucEntidad
						                                Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones ZCarac2 On ZCarac2.Tabla = 'ES_ENTREGA_ST' And ZCarac2.CodigoTabla =  Cod_Estado_Entrega
                            Where ZEnc.Id_Ot = @Id_Ot"

            _Row_Servicio_Tecnico_Enc = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

    End Sub

    Sub Sb_Traer_Datos_Para_Impresion_De_Cheques()

        printDoc.DocumentName = _NombreDocumento

        Consulta_sql = My.Resources.Recursos_Formato_Documento.SQLQuery_Traer_Cheque_Letra_Para_Imprimir
        Consulta_sql = Replace(Consulta_sql, "#Idmaedpce#", _IdDoc)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Row_Encabezado = _Ds.Tables(0).Rows(0)
        _Tbl_Detalle = _Ds.Tables(1)

        _Row_Encabezado = Fx_New_Inserta_Funciones_Bk_En_Encabezado_Cheque(_Row_Encabezado)

        ' Llena Formato del Encabezado
        Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And _Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Emdp = '" & _Emdp & "'"
        _TblEncForm = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = "SELECT *," &
                                     "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                     "Where Nombre_Funcion = Funcion),0) As Funcion_Bk," & vbCrLf &
                                     "Isnull((Select Formato From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                     "Where Nombre_Funcion = Funcion),0) As Formato_Fx," & vbCrLf &
                                     "Isnull((Select Campo From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                     "Where Nombre_Funcion = Funcion),0) As Campo," & vbCrLf &
                                     "Isnull((Select Codigo_De_Barras From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                     "Where Nombre_Funcion = Funcion),0) As Codigo_De_Barras," & vbCrLf &
                                     "Isnull((Select Es_Descuento From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                     "Where Nombre_Funcion = Funcion),0) As Es_Descuento" & vbCrLf &
                                     "FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                                     "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Emdp = '" & _Emdp & "' And Seccion In ('E','P')"

        _Tbl_Fx_Encabezado = _Sql.Fx_Get_Tablas(Consulta_sql)

        ' Llena formato del detalle
        Consulta_sql = "SELECT *," &
                          "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Funcion_Bk," & vbCrLf &
                          "Isnull((Select Formato From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Formato_Fx," & vbCrLf &
                          "Isnull((Select Campo From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Campo," & vbCrLf &
                          "Isnull((Select Codigo_De_Barras From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Codigo_De_Barras," & vbCrLf &
                          "Isnull((Select Es_Descuento From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Es_Descuento" & vbCrLf &
                          "FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                          "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion = 'D'" & vbCrLf &
                          "Order by Orden_Detalle"
        _Tbl_Fx_Detalle = _Sql.Fx_Get_Tablas(Consulta_sql)

        '_Fx = New Frm_Formato_Creador_Funciones(_IdMaeedo)

    End Sub

    Sub Sb_Traer_Datos_Para_Impresion_De_Productos_Solicitados_A_Bodega(_IdDoc As Integer)

        printDoc.DocumentName = _NombreDocumento

        Dim _Nokosu = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", "EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "'")
        Dim _Nokobo = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO", "EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "'")

        Dim _numAleatorio As New Random()
        Dim valorAleatorio As Integer = _numAleatorio.Next(1000, 100000)

        Dim _CodSolicitud As String = numero_(valorAleatorio, 10)

        If CBool(_IdDoc) Then
            Consulta_sql = My.Resources.Recursos_Formato_Documento.SQLQuery_Traer_Prod_Sol_Bodega
            Consulta_sql = Replace(Consulta_sql, "#Id#", _IdDoc)
            Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)
        Else
            Consulta_sql = "Select FLOOR(RAND()*(999-1)+1) As Id,'" & _CodSolicitud & "' As CodSolicitud,'PRB' As Estado," &
                                   "'" & FUNCIONARIO & "' As Funcionario,'" & Nombre_funcionario_activo & "' As Nokofu," &
                                   "'CODIGOXXXXXYZ' As Codigo," &
                                   "'DESCRIPCION DEL PRODUCTO CINCUENTA CARACTERES..XYZ' As Descripcion," &
                                   "'" & ModEmpresa & "' As Empresa,'" & ModSucursal & "' As Sucursal,'" & ModBodega & "' As Bodega," &
                                   "'" & RazonEmpresa & "' As Razon,'" & _Nokosu & "' As Nokosu,'" & _Nokobo & "' As Nokobo," &
                                   "'UBICACION Z-1' As Ubicacion," &
                                   "FLOOR(RAND()*(999-1)+1) As StockUd1," &
                                   "FLOOR(RAND()*(999-1)+1) As StockUd2," &
                                   "Convert(Date, Getdate()) As Fecha," &
                                   "CONVERT(VARCHAR, Getdate(), 108) As Hora," &
                                   "Cast(1 As Bit) As Impreso"
        End If

        _Row_Encabezado = _Sql.Fx_Get_DataRow(Consulta_sql)

        ' Llena Formato del Encabezado
        Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "'"
        _TblEncForm = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = "SELECT *," &
                                    "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                    "Where Nombre_Funcion = Funcion),0) As Funcion_Bk," & vbCrLf &
                                    "Isnull((Select Formato From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                    "Where Nombre_Funcion = Funcion),0) As Formato_Fx," & vbCrLf &
                                    "Isnull((Select Campo From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                    "Where Nombre_Funcion = Funcion),0) As Campo," & vbCrLf &
                                    "Isnull((Select Codigo_De_Barras From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                    "Where Nombre_Funcion = Funcion),0) As Codigo_De_Barras," & vbCrLf &
                                    "Isnull((Select Es_Descuento From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                    "Where Nombre_Funcion = Funcion),0) As Es_Descuento" & vbCrLf &
                                    "FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                                    "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion In ('E','P')"

        _Tbl_Fx_Encabezado = _Sql.Fx_Get_Tablas(Consulta_sql)

        ' Llena formato del detalle
        Consulta_sql = "SELECT *," &
                          "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Funcion_Bk," & vbCrLf &
                          "Isnull((Select Formato From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Formato_Fx," & vbCrLf &
                          "Isnull((Select Campo From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Campo," & vbCrLf &
                          "Isnull((Select Codigo_De_Barras From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Codigo_De_Barras," & vbCrLf &
                          "Isnull((Select Es_Descuento From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                          "Where Nombre_Funcion = Funcion),0) As Es_Descuento" & vbCrLf &
                          "FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                          "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion = 'D'" & vbCrLf &
                          "Order by Orden_Detalle"
        _Tbl_Fx_Detalle = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Public Function Fx_Imprimir_Documento(_Ds_Datos As DataSet,
                                          _EsPreview As Boolean,
                                          Optional _Mostrar_Error As Boolean = True)


        Try

            _Documento_Impreso = False

            If String.IsNullOrEmpty(_Impresora) Then
                If _Mostrar_Error Then MsgBox("Falta seleccionar impresora", MsgBoxStyle.Critical, "Falta Impresora")
            End If


            Dim _Largo_Variable As Boolean

            _NombreFormato = Trim(_NombreFormato)



            If CBool(_TblEncForm.Rows.Count) Then

                Dim FilaEnc = _TblEncForm.Rows(0)

                Dim _Doc_NrolineasXpag = FilaEnc.Item("NrolineasXpag")
                Dim _Doc_Fila_InicioDetalle = FilaEnc.Item("Fila_InicioDetalle")
                Dim _Doc_Fila_FinDetalle = FilaEnc.Item("Fila_FinDetalle")
                Dim _Doc_Col_InicioDetalle = FilaEnc.Item("Col_InicioDetalle")
                Dim _Doc_Col_FinDetalle = FilaEnc.Item("Col_FinDetalle")


                _Largo_Variable = FilaEnc.Item("Largo_Variable")

                _Doc_AnchoDoc = Math.Round(FilaEnc.Item("AnchoDoc"), 2) * 39.37 '38.5 '39 '38.5
                _Doc_LargoDoc = Math.Round(FilaEnc.Item("LargoDoc"), 2) * 39.37 '38.5 '42 '41.5

                Dim _Agrupar_CodDescripcion As Boolean = FilaEnc.Item("Agrupar_CodDescripcion")

                If _Agrupar_CodDescripcion Then
                    _Tbl_Detalle = _Tbl_Detalle_Agrupado
                End If

                If _Largo_Variable Then

                    Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                                   "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "'" & vbCrLf &
                                   "Order by Fila_Y Desc" & vbCrLf &
                                   "Select Distinct Orden_Detalle,Max(Alto) As Alto From " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                                   "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion = 'D'" & vbCrLf &
                                   "Group By Orden_Detalle"

                    Dim _Ds_Format_02 As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                    Dim _RowUltimaFila As DataRow = _Ds_Format_02.Tables(0).Rows(0) '_Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Fila_Y = _RowUltimaFila.Item("Fila_Y") + _RowUltimaFila.Item("Alto")

                    _Doc_LargoDoc = _Doc_Fila_InicioDetalle

                    'Dim _Funcion As String

                    Dim _Suma = 0

                    If Not IsNothing(_Tbl_Detalle) Then

                        For Each _Fila As DataRow In _Tbl_Detalle.Rows

                            For Each _Fm As DataRow In _Ds_Format_02.Tables(1).Rows

                                Dim _Alto As Double = _Fm.Item("Alto")
                                _Suma += _Alto '15

                            Next

                        Next

                        _Es_Picking = _TblEncForm.Rows(0).Item("Es_Picking")

                        If _Es_Picking Then

                            Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEDDO", "IDMAEEDO = " & _IdDoc)

                            If _Reg > _Tbl_Detalle.Rows.Count Then

                                _Suma += 30
                                _Texto_Prod_Otras_Bodegas = "*** DOCUMENTO CON PROD. OTRAS BODEGAS"

                            Else

                                Dim _Sudo As String = _Row_Encabezado.Item("SUDO").ToString.Trim

                                If _Sudo <> ModSucursal.Trim Then

                                    _Suma += 30
                                    _Texto_Prod_Otras_Bodegas = "*** DOCUMENTO DESDE OTRA SUC: " & _Sudo

                                End If

                            End If

                        End If

                    End If

                    Dim Dif As Double

                    Dif = _Doc_LargoDoc - _Fila_Y

                    If Dif < 0 Then

                        _Doc_LargoDoc = _Fila_Y + _Suma '+ 200

                    Else

                        _Doc_LargoDoc = (_Doc_LargoDoc - _Fila_Y) + _Doc_LargoDoc + 50

                    End If


                    If _Es_Solicitud_Prod_Bodega Then

                        AddHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Solicitud_Prod_Bodega

                    Else

                        If (_Es_Cheque) Then

                            AddHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Cheque_Largo_Variable

                        Else

                            AddHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Documento_Largo_Variable

                        End If

                    End If

                Else

                    If _Es_Solicitud_Prod_Bodega Then

                        AddHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Solicitud_Prod_Bodega

                    Else

                        If (_Es_Cheque) Then

                            AddHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Cheque

                        Else

                            AddHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Documento

                        End If

                    End If

                End If


                _Fila_InicioDetalle = FilaEnc.Item("Fila_InicioDetalle")
                _Fila_FinDetalle = FilaEnc.Item("Fila_FinDetalle")

                '' Esto muestra el tamaño del papel y los margenes...
                'Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Letter, 850, 1100)

                'Dim PageSetupDialog1 As New PageSetupDialog

                'PageSetupDialog1.Document = printDoc
                'PageSetupDialog1.PageSettings.Landscape = False

                'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
                ''PageSetupDialog1.PageSettings.Margins.Left = 2
                ''PageSetupDialog1.PageSettings.Margins.Right = 2

                'PageSetupDialog1.ShowDialog()
                '' Fin,,

                Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc + 2)

                ' Asignamos la impresora seleccionada
                printDoc.PrinterSettings = _PrtSettings
                'printDoc.DefaultPageSettings.Margins.Left = 0
                'printDoc.DefaultPageSettings.Margins.Right = 0

                ' Asignamos el tamaño personalizado de papel
                printDoc.DefaultPageSettings.PaperSize = _TamañoPersonal

                'Dim Ancho = Short.Parse(_Ancho)
                'Dim Alto = Short.Parse(_Largo)

                'End If

            Else

                Return False

            End If

            If _EsPreview Then

                Dim prtPrev As New PrintPreviewDialog
                With prtPrev

                    .StartPosition = FormStartPosition.CenterScreen
                    .Document = printDoc
                    .Width = 600
                    .Height = 800
                    .Text = "Previsualizar documento"
                    .ShowDialog()

                End With

            Else

                printDoc.PrinterSettings.PrinterName = _Impresora
                printDoc.Print()
                printDoc.Dispose()

            End If

            Return True

        Catch ex As Exception
            _Ultimo_Error = ex.Message
            If _Mostrar_Error Then
                MessageBoxEx.Show(ex.Message)
            End If
        Finally

            RemoveHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Documento_Largo_Variable
            RemoveHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Documento

        End Try

    End Function

    Public Function Fx_Imprimir_Regleta()

        Dim printDoc As New PrintDocument

        Fx_seleccionar_Impresora(True)

        AddHandler printDoc.PrintPage, AddressOf Sb_Imprimir_Regleta

        If Not String.IsNullOrEmpty(_Impresora) Then
            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()
        End If

    End Function

    Public Function Fx_seleccionar_Impresora(_Seleccionar_Impresora As Boolean) As Boolean

        Dim prtDialog As New PrintDialog

        If _PrtSettings Is Nothing Then
            _PrtSettings = New PrinterSettings
        End If

        If Not _Seleccionar_Impresora Then
            If _Impresora = String.Empty Then
                _Seleccionar_Impresora = True
            End If
        End If

        With prtDialog

            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True

            .PrinterSettings = _PrtSettings
            .PrinterSettings.Copies = 1


            If _Seleccionar_Impresora Then

                If .ShowDialog() = DialogResult.OK Then
                    _PrtSettings = .PrinterSettings
                    _Impresora = _PrtSettings.PrinterName
                Else
                    _Impresora = String.Empty
                    Return False
                End If

            End If

        End With

        Return True

    End Function

    Private Sub Sb_Imprimir_Documento_Largo_Variable(sender As Object,
                                                     e As PrintPageEventArgs)

        _Paginas += 1

        Dim FilaEnc = _TblEncForm.Rows(0)

        Dim _Doc_NrolineasXpag = FilaEnc.Item("NrolineasXpag")
        Dim _Doc_Fila_InicioDetalle = FilaEnc.Item("Fila_InicioDetalle")
        Dim _Doc_Fila_FinDetalle = FilaEnc.Item("Fila_FinDetalle")
        Dim _Doc_Col_InicioDetalle = FilaEnc.Item("Col_InicioDetalle")
        Dim _Doc_Col_FinDetalle = FilaEnc.Item("Col_FinDetalle")

        Dim _NombreObjeto As String
        Dim _Funcion As String
        Dim _TipoDato As String
        Dim _Seccion As String

        Dim _Formato As String
        Dim _CantDecimales
        Dim _Fuente As String
        Dim _Tamano As Single
        Dim _Alto As Single
        Dim _Ancho As Single
        Dim _Estilo
        Dim _Color

        Dim _Texto
        Dim _RutaImagen As String
        Dim _Orden_Detalle As Integer

        Dim _Fte_Usar
        Dim _Style As FontStyle = FontStyle.Underline
        Dim Imagen As New PictureBox

        Dim _Funcion_Bk As Boolean
        Dim _Formato_Fx As String
        Dim _Campo As String
        Dim _Codigo_De_Barras As Boolean
        Dim _CodigoQR As Boolean
        Dim _Es_Descuento As Boolean

        Dim _Hora_Pc = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
        Dim _Fecha_Pc = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

        Dim _SQL_Personalizada As Boolean
        Dim _SqlQuery As String

        Dim _FteCourier_New As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente

        Dim _Filas_Y_Suma As Integer = 0

        Try

#Region "DETALLE"

            Dim _Detalle_Y = _Fila_InicioDetalle

            Dim _Salir_del_For As Boolean
            Dim _Paso_Fila_2 As Boolean

            For Each _Fila_D As DataRow In _Tbl_Detalle.Rows

                Dim _DrawBrush As New SolidBrush(Color.Black)

                Dim _Es_Picking As Boolean = _TblEncForm.Rows(0).Item("Es_Picking")

                _Paso_Fila_2 = False

                For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                    _NombreObjeto = _Fila.Item("NombreObjeto")
                    _Funcion = _Fila.Item("Funcion")
                    _TipoDato = _Fila.Item("TipoDato")
                    _Seccion = _Fila.Item("Seccion")

                    _Formato = _Fila.Item("Formato")
                    _CantDecimales = _Fila.Item("CantDecimales")
                    _Fuente = _Fila.Item("Fuente")
                    _Tamano = _Fila.Item("Tamano")
                    _Alto = _Fila.Item("Alto")
                    _Ancho = _Fila.Item("Ancho")
                    _Estilo = _Fila.Item("Estilo")
                    _Color = _Fila.Item("Color")
                    _Fila_Y = _Fila.Item("Fila_Y")
                    _Columna_X = _Fila.Item("Columna_X")
                    _Texto = _Fila.Item("Texto")
                    _RutaImagen = _Fila.Item("RutaImagen")
                    _Orden_Detalle = _Fila.Item("Orden_Detalle")

                    If _Orden_Detalle = 2 Then

                        If Not _Paso_Fila_2 Then

                            _Detalle_Y += 15
                            _Filas_Y_Suma += 15
                            _Paso_Fila_2 = True

                        End If

                    End If

                    Select Case _Estilo
                        Case 0
                            _Style = FontStyle.Regular
                        Case 1
                            _Style = FontStyle.Bold
                        Case 2
                            _Style = FontStyle.Italic
                        Case 4
                            _Style = FontStyle.Underline
                        Case 8
                            _Style = FontStyle.Strikeout
                        Case Else
                            _Style = FontStyle.Regular
                    End Select

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    Dim _Prct As Boolean = _Fila_D.Item("PRCT")
                    Dim _Mostrar_En_Concepto As Boolean = _Fila.Item("Mostrar_En_Concepto")

                    Dim _Imprimir_Detalle As Boolean = True

                    If _Prct And Not _Mostrar_En_Concepto Then
                        _Imprimir_Detalle = False
                    End If

                    If CBool(_IdDoc) Then

                        If _NombreObjeto = "Texto_libre" Then

                            e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                        ElseIf _NombreObjeto = "Funcion" Then

                            Dim _Idmaeddo = _Fila_D.Item("IDMAEDDO")

                            If _Funcion_Bk Then

                                If Fx_Imprimir_Funciones_Detalle(_Funcion,
                                                                _Texto,
                                                                _Tbl_Detalle,
                                                                e,
                                                                _Fila_Y,
                                                                _Columna_X,
                                                                _Fte_Usar,
                                                                _DrawBrush, _Imprimir_Detalle) Then
                                    _Salir_del_For = True
                                    Exit For

                                End If

                            Else

                                If _Imprimir_Detalle Then

                                    _Texto = Fx_New_Trae_Valor_Detalle_Row(_Campo, _TipoDato, _Es_Descuento, _Fila_D, _Formato_Fx)
                                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                                End If


                            End If

                        End If

                    Else

                    End If

                    'Sigue:

                Next

                _Detalle_Y += 15
                _Filas_Y_Suma += 15

                If _Salir_del_For Then
                    Exit For
                End If

                _Fila_FinDetalle = _Detalle_Y

            Next

            Dim _Mas_Alto As Integer

            For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                _Alto = _Fila.Item("Alto")

                If _Mas_Alto < _Alto Then

                    _Mas_Alto = _Alto

                End If

                _NombreObjeto = _Fila.Item("NombreObjeto")

            Next

            Dim _Salto_Linea As Integer = 15 '_Mas_Alto + 2
            _Detalle_Y = _Fila_FinDetalle + _Salto_Linea

            If _Es_Picking Then

                Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEDDO", "IDMAEEDO = " & _IdDoc)

                If _Reg > _Tbl_Detalle.Rows.Count Then

                    Dim _DrawBrush As New SolidBrush(Color.Black)
                    _Fte_Usar = New Font("Courier New", 8.25, FontStyle.Bold)

                    e.Graphics.DrawString("*** IMPORTANTE, DOCUMENTO CON PRODUCTOS", _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                    _Detalle_Y += _Salto_Linea
                    e.Graphics.DrawString("*** EN OTRAS BODEGAS....               ", _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                    _Detalle_Y += _Salto_Linea

                End If

            End If

#End Region

#Region "REFERENCIAS"

            If _Tbl_Referencias.Rows.Count Then
                _Detalle_Y += _Salto_Linea + 5
            End If

            For Each _Fila_D As DataRow In _Tbl_Referencias.Rows

                Dim _Referencia = _Fila_D.Item("Referencia").ToString

                Try

                    Dim _Ref = Split(_Referencia, " - ")

                    Dim _TidoRef = _Ref(0)
                    Dim _NumRef = CInt(_Ref(1))
                    Dim _FechaRef = _Ref(2)

                    _Referencia = _TidoRef & " - " & _NumRef & " - " & _FechaRef

                Catch ex As Exception

                    _Referencia = _Fila_D.Item("Referencia").ToString

                End Try

                Dim _Contador = 0

                For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                    _NombreObjeto = _Fila.Item("NombreObjeto")
                    _Funcion = _Fila.Item("Funcion")
                    _TipoDato = _Fila.Item("TipoDato")
                    _Seccion = _Fila.Item("Seccion")

                    _Formato = _Fila.Item("Formato")
                    _CantDecimales = _Fila.Item("CantDecimales")
                    _Fuente = _Fila.Item("Fuente")
                    _Tamano = _Fila.Item("Tamano")
                    _Alto = _Fila.Item("Alto")
                    _Ancho = _Fila.Item("Ancho")
                    _Estilo = _Fila.Item("Estilo")
                    _Color = _Fila.Item("Color")
                    _Fila_Y = _Fila.Item("Fila_Y")
                    _Columna_X = _Fila.Item("Columna_X")
                    _Texto = _Fila.Item("Texto")
                    _RutaImagen = _Fila.Item("RutaImagen")

                    Select Case _Estilo
                        Case 0
                            _Style = FontStyle.Regular
                        Case 1
                            _Style = FontStyle.Bold
                        Case 2
                            _Style = FontStyle.Italic
                        Case 4
                            _Style = FontStyle.Underline
                        Case 8
                            _Style = FontStyle.Strikeout
                        Case Else
                            _Style = FontStyle.Regular
                    End Select

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    _Color = Color.FromArgb(_Color)
                    Dim _DrawBrush As New SolidBrush(_Color)

                    If _NombreObjeto = "Funcion" Then

                        If _Funcion_Bk Then

                            If _Funcion = "Referencia DTE" Then

                                If _Contador = 0 Then
                                    e.Graphics.DrawString("------------- Referencias -------------",
                                                          _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                    _Detalle_Y += _Salto_Linea
                                End If

                                e.Graphics.DrawString(_Referencia, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                            End If

                        End If

                    End If

                Next
                _Contador += 1
                _Detalle_Y += _Salto_Linea

            Next

            _Fila_FinDetalle = _Detalle_Y

            ' FIN REFERENCIA

#End Region

#Region "DOCUMENTOS ASOCIADOS A RECARGOS"

            For Each _Fila_D As DataRow In _Tbl_Doc_Asociados_Recargos.Rows

                Dim _DRA As String

                Dim _Tido_Dra = _Fila_D.Item("TIDO")
                Dim _Nudo_Dra = _Fila_D.Item("NUDO")
                Dim _Feemdo_Dra = FormatDateTime(_Fila_D.Item("FEEMDO"), DateFormat.ShortDate)

                _DRA = _Tido_Dra & " - " & _Nudo_Dra & " - " & _Feemdo_Dra

                Dim _Contador = 0

                For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                    _NombreObjeto = _Fila.Item("NombreObjeto")
                    _Funcion = _Fila.Item("Funcion")
                    _TipoDato = _Fila.Item("TipoDato")
                    _Seccion = _Fila.Item("Seccion")

                    _Formato = _Fila.Item("Formato")
                    _CantDecimales = _Fila.Item("CantDecimales")
                    _Fuente = _Fila.Item("Fuente")
                    _Tamano = _Fila.Item("Tamano")
                    _Alto = _Fila.Item("Alto")
                    _Ancho = _Fila.Item("Ancho")
                    _Estilo = _Fila.Item("Estilo")
                    _Color = _Fila.Item("Color")
                    _Fila_Y = _Fila.Item("Fila_Y")
                    _Columna_X = _Fila.Item("Columna_X")
                    _Texto = _Fila.Item("Texto")
                    _RutaImagen = _Fila.Item("RutaImagen")

                    Select Case _Estilo
                        Case 0
                            _Style = FontStyle.Regular
                        Case 1
                            _Style = FontStyle.Bold
                        Case 2
                            _Style = FontStyle.Italic
                        Case 4
                            _Style = FontStyle.Underline
                        Case 8
                            _Style = FontStyle.Strikeout
                        Case Else
                            _Style = FontStyle.Regular
                    End Select

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    _Color = Color.FromArgb(_Color)
                    Dim _DrawBrush As New SolidBrush(_Color)

                    If _NombreObjeto = "Funcion" Then

                        If _Funcion_Bk Then

                            If _Funcion = "Documentos Recargos Asociados (DRA)" Then

                                If _Contador = 0 Then
                                    e.Graphics.DrawString("------------- Referencias -------------",
                                                          _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                    _Detalle_Y += _Salto_Linea
                                End If

                                e.Graphics.DrawString(_DRA, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                            End If

                        End If

                    End If

                Next
                _Contador += 1
                _Detalle_Y += _Salto_Linea

            Next

            _Fila_FinDetalle = _Detalle_Y

            ' FIN REFERENCIA

#End Region

#Region "ENCABEZADO Y PIE"

            Dim _Tido = _Row_Encabezado.Item("TIDO")
            Dim _Nudo = _Row_Encabezado.Item("NUDO")

            For Each _Fila As DataRow In _Tbl_Fx_Encabezado.Rows

                Dim _Imagen As New PictureBox

                _NombreObjeto = _Fila.Item("NombreObjeto")
                _Funcion = _Fila.Item("Funcion")
                _TipoDato = _Fila.Item("TipoDato")
                _Seccion = _Fila.Item("Seccion")

                _Formato = _Fila.Item("Formato")
                _CantDecimales = _Fila.Item("CantDecimales")
                _Fuente = _Fila.Item("Fuente")
                _Tamano = _Fila.Item("Tamano")
                _Alto = _Fila.Item("Alto")
                _Ancho = _Fila.Item("Ancho")
                _Estilo = _Fila.Item("Estilo")
                _Color = _Fila.Item("Color")
                _Fila_Y = _Fila.Item("Fila_Y")
                _Columna_X = _Fila.Item("Columna_X")
                _Texto = _Fila.Item("Texto")
                _RutaImagen = _Fila.Item("RutaImagen")

                _Funcion_Bk = _Fila.Item("Funcion_Bk")
                _Formato_Fx = _Fila.Item("Formato_Fx")
                _Campo = _Fila.Item("Campo")
                _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                _CodigoQR = _Fila.Item("CodigoQR")
                _Es_Descuento = _Fila.Item("Es_Descuento")

                If _Fila_Y > _Doc_Fila_FinDetalle Then

                    Dim _Dif = (_Fila_Y - _Doc_Fila_FinDetalle)

                    If _Dif > 0 Then
                        _Fila_Y = _Dif + _Fila_FinDetalle '_Doc_Fila_FinDetalle
                    End If

                End If

                Select Case _Estilo
                    Case 0
                        _Style = FontStyle.Regular
                    Case 1
                        _Style = FontStyle.Bold
                    Case 2
                        _Style = FontStyle.Italic
                    Case 4
                        _Style = FontStyle.Underline
                    Case 8
                        _Style = FontStyle.Strikeout
                    Case Else
                        _Style = FontStyle.Regular
                End Select

                _Fte_Usar = New Font(_Fuente, _Tamano, _Style)
                _Color = Color.FromArgb(_Color)
                Dim _DrawBrush As New SolidBrush(_Color)

                _SQL_Personalizada = _Fila.Item("SQL_Personalizada")
                _SqlQuery = _Fila.Item("SqlQuery")

                If _NombreObjeto = "Texto_libre" Then

                    'Objeto.Font = NewFont(_Fuente, _Tamano, _Estilo)
                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Funcion" And _Seccion <> "D" Then

                    Dim bm As Bitmap = Nothing
                    Dim CodBarras As New PictureBox

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    If CBool(_IdDoc) Then

                        If _Funcion_Bk Then

                            Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion,
                                                                 _Texto,
                                                                 _Formato,
                                                                 e,
                                                                 _Fila_Y,
                                                                 _Columna_X,
                                                                 _Fte_Usar,
                                                                 _DrawBrush,
                                                                 _Ancho,
                                                                 _Alto,
                                                                 _Campo,
                                                                 _TipoDato,
                                                                 _Es_Descuento,
                                                                 _Codigo_De_Barras,
                                                                 _CodigoQR)


                        Else

                            Dim _Row As DataRow = _Row_Encabezado

                            If _SQL_Personalizada Then

                                Dim _Error As String
                                _Row = Fx_Funcion_SQL_Personalizada_Enc_Pie(_SqlQuery, _IdDoc, _Error)

                                If String.IsNullOrEmpty(_Error) Then
                                    _Campo = "CAMPO"
                                Else
                                    _Campo = "_Error"
                                End If

                            End If

                            Dim _Formato_Texto As String = _Texto
                            Dim _Formatext = Split(_Formato_Texto, vbCrLf)

                            If _Campo.Contains("STEC_") Then
                                _Campo = Replace(_Campo, "STEC_", "")
                                _Row = _Row_Servicio_Tecnico_Enc
                            End If

                            If String.IsNullOrEmpty(_Campo) Then
                                MsgBox("aca")
                            End If

                            _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                                          _TipoDato,
                                                                          _Es_Descuento,
                                                                          _Row,
                                                                          _Texto)


                            If _Formatext.Length > 1 Then

                                Dim _Caracteres = _Formato_Texto.Length

                                Dim _i = 0
                                Dim _Contador_Carac

                                _Texto = Replace(_Texto, vbCrLf, " ")

                                If IsNothing(_Texto) Then
                                    _Texto = String.Empty
                                End If

                                Dim _Fy = _Fila_Y

                                For Each _Texto1 As String In _Formatext

                                    Dim _Desde = _i + 1
                                    Dim _Hasta = _Texto1.Length

                                    Dim _Txt = Mid(_Texto, _Desde, _Hasta)
                                    _i += _Texto1.Length

                                    If _Texto.Length > _Contador_Carac Then

                                        e.Graphics.DrawString(_Txt.Trim, _Fte_Usar, _DrawBrush, _Columna_X, _Fy)
                                        _Fy += (_Alto / _Formatext.Length) + 2
                                        _Txt = String.Empty

                                    End If

                                    _Contador_Carac += _Texto1.Length

                                Next

                            Else

                                e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                            End If

                            'e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Fila_Y)

                        End If

                    End If


                ElseIf _NombreObjeto = "Imagen" Then

                    Try
                        _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                        e.Graphics.DrawImage(_Imagen.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)
                    Catch ex As Exception
                    End Try

                ElseIf _NombreObjeto = "Caja" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)


                    If CBool(_Estilo) Then
                        DrawRoundedRectangle(e.Graphics, _Pen, _Columna_X, _Fila_Y, _Ancho, _Alto, 30)
                    Else
                        e.Graphics.DrawRectangle(_Pen, New Rectangle(_Columna_X, _Fila_Y, _Ancho, _Alto))
                    End If

                ElseIf _NombreObjeto = "" Then

                    _Color = Color.FromArgb(_Color)
                    Dim drawBrush As New SolidBrush(_Color)

                    Dim _Pen As New Pen(drawBrush, _Tamano)

                    ' e.Graphics.DrawLine(_Pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

                End If

            Next

#End Region


            e.HasMorePages = False

            _Documento_Impreso = True

        Catch ex As Exception
            _Ultimo_Error = ex.Message
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Imprimir_Cheque_Largo_Variable(sender As Object,
                                                     e As PrintPageEventArgs)

        _Paginas += 1

        Dim FilaEnc = _TblEncForm.Rows(0)

        Dim _Doc_NrolineasXpag = FilaEnc.Item("NrolineasXpag")
        Dim _Doc_Fila_InicioDetalle = FilaEnc.Item("Fila_InicioDetalle")
        Dim _Doc_Fila_FinDetalle = FilaEnc.Item("Fila_FinDetalle")
        Dim _Doc_Col_InicioDetalle = FilaEnc.Item("Col_InicioDetalle")
        Dim _Doc_Col_FinDetalle = FilaEnc.Item("Col_FinDetalle")

        Dim _NombreObjeto As String
        Dim _Funcion As String
        Dim _TipoDato As String
        Dim _Seccion As String

        Dim _Formato As String
        Dim _CantDecimales
        Dim _Fuente As String
        Dim _Tamano As Single
        Dim _Alto As Single
        Dim _Ancho As Single
        Dim _Estilo
        Dim _Color

        Dim _Texto
        Dim _RutaImagen As String
        Dim _Orden_Detalle As Integer

        Dim _Fte_Usar
        Dim _Style As FontStyle = FontStyle.Underline
        Dim Imagen As New PictureBox

        Dim _Funcion_Bk As Boolean
        Dim _Formato_Fx As String
        Dim _Campo As String
        Dim _Codigo_De_Barras As Boolean
        Dim _CodigoQR As Boolean
        Dim _Es_Descuento As Boolean

        Dim _Hora_Pc = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
        Dim _Fecha_Pc = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

        Dim _FteCourier_New As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente

        Dim _Filas_Y_Suma As Integer = 0


        Try

            Dim _Detalle_Y = _Fila_InicioDetalle

            Dim _Salir_del_For As Boolean
            Dim _Paso_Fila_2 As Boolean

            For Each _Fila_D As DataRow In _Tbl_Detalle.Rows

                For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                    _NombreObjeto = _Fila.Item("NombreObjeto")
                    _Funcion = _Fila.Item("Funcion")
                    _TipoDato = _Fila.Item("TipoDato")
                    _Seccion = _Fila.Item("Seccion")

                    _Formato = _Fila.Item("Formato")
                    _CantDecimales = _Fila.Item("CantDecimales")
                    _Fuente = _Fila.Item("Fuente")
                    _Tamano = _Fila.Item("Tamano")
                    _Alto = _Fila.Item("Alto")
                    _Ancho = _Fila.Item("Ancho")
                    _Estilo = _Fila.Item("Estilo")
                    _Color = _Fila.Item("Color")
                    _Fila_Y = _Fila.Item("Fila_Y")
                    _Columna_X = _Fila.Item("Columna_X")
                    _Texto = _Fila.Item("Texto")
                    _RutaImagen = _Fila.Item("RutaImagen")

                    Select Case _Estilo
                        Case 0
                            _Style = FontStyle.Regular
                        Case 1
                            _Style = FontStyle.Bold
                        Case 2
                            _Style = FontStyle.Italic
                        Case 4
                            _Style = FontStyle.Underline
                        Case 8
                            _Style = FontStyle.Strikeout
                        Case Else
                            _Style = FontStyle.Regular
                    End Select

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    _Color = Color.FromArgb(_Color)
                    Dim _DrawBrush As New SolidBrush(_Color)

                    If _Orden_Detalle = 2 Then
                        If Not _Paso_Fila_2 Then
                            _Detalle_Y += 15
                            _Filas_Y_Suma += 15
                            _Paso_Fila_2 = True
                        End If
                    End If




                    If CBool(_IdDoc) Then

                        If _NombreObjeto = "Texto_libre" Then

                            Dim _Y_Texto = _Fila_InicioDetalle

                            e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Detalle_Y) '_Y_Texto)

                        ElseIf _NombreObjeto = "Funcion" Then

                            If _Funcion_Bk Then

                                If Fx_Imprimir_Funciones_Detalle(_Funcion,
                                                                _Texto,
                                                                _Tbl_Detalle,
                                                                e,
                                                                _Fila_Y,
                                                                _Columna_X,
                                                                _Fte_Usar,
                                                                _DrawBrush, True) Then
                                    _Salir_del_For = True
                                    Exit For
                                End If

                            Else

                                _Texto = Fx_New_Trae_Valor_Detalle_Row(_Campo,
                                                                       _TipoDato,
                                                                       _Es_Descuento,
                                                                       _Fila_D,
                                                                       _Texto)


                                e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                            End If

                        End If

                    End If


                Next

                _Detalle_Y += 15
                _Filas_Y_Suma += 15

                If _Salir_del_For Then
                    Exit For
                End If

                _Fila_FinDetalle = _Detalle_Y

            Next


            For Each _Fila As DataRow In _Tbl_Fx_Encabezado.Rows

                Dim _Imagen As New PictureBox

                _NombreObjeto = _Fila.Item("NombreObjeto")
                _Funcion = _Fila.Item("Funcion")
                _TipoDato = _Fila.Item("TipoDato")
                _Seccion = _Fila.Item("Seccion")

                _Formato = _Fila.Item("Formato")
                _CantDecimales = _Fila.Item("CantDecimales")
                _Fuente = _Fila.Item("Fuente")
                _Tamano = _Fila.Item("Tamano")
                _Alto = _Fila.Item("Alto")
                _Ancho = _Fila.Item("Ancho")
                _Estilo = _Fila.Item("Estilo")
                _Color = _Fila.Item("Color")
                _Fila_Y = _Fila.Item("Fila_Y")
                _Columna_X = _Fila.Item("Columna_X")
                _Texto = _Fila.Item("Texto")
                _RutaImagen = _Fila.Item("RutaImagen")

                _Funcion_Bk = _Fila.Item("Funcion_Bk")
                _Formato_Fx = _Fila.Item("Formato_Fx")
                _Campo = _Fila.Item("Campo")
                _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                _CodigoQR = _Fila.Item("CodigoQR")
                _Es_Descuento = _Fila.Item("Es_Descuento")

                If _Fila_Y > _Doc_Fila_FinDetalle Then

                    Dim _Dif = (_Fila_Y - _Doc_Fila_FinDetalle)

                    If _Dif > 0 Then
                        _Fila_Y = _Dif + _Fila_FinDetalle '_Doc_Fila_FinDetalle
                    End If

                End If

                Select Case _Estilo
                    Case 0
                        _Style = FontStyle.Regular
                    Case 1
                        _Style = FontStyle.Bold
                    Case 2
                        _Style = FontStyle.Italic
                    Case 4
                        _Style = FontStyle.Underline
                    Case 8
                        _Style = FontStyle.Strikeout
                    Case Else
                        _Style = FontStyle.Regular
                End Select

                _Fte_Usar = New Font(_Fuente, _Tamano, _Style)
                _Color = Color.FromArgb(_Color)
                Dim _DrawBrush As New SolidBrush(_Color)

                If _NombreObjeto = "Texto_libre" Then

                    'Objeto.Font = NewFont(_Fuente, _Tamano, _Estilo)
                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Funcion" And _Seccion <> "D" Then

                    Dim bm As Bitmap = Nothing
                    Dim CodBarras As New PictureBox

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    If CBool(_IdDoc) Then

                        If _Funcion_Bk Then

                            Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion,
                                                                 _Texto,
                                                                 _Formato,
                                                                 e,
                                                                 _Fila_Y,
                                                                 _Columna_X,
                                                                 _Fte_Usar,
                                                                 _DrawBrush,
                                                                 _Ancho,
                                                                 _Alto,
                                                                 _Campo,
                                                                 _TipoDato,
                                                                 _Es_Descuento,
                                                                 _Codigo_De_Barras,
                                                                 _CodigoQR)


                        Else

                            'Dim _Fx As New Frm_Formato_Creador_Funciones(_IdMaeedo)
                            '_Texto = _Fx.Fx_Trae_Valor(_IdMaeedo, _Funcion, _Texto)

                            If String.IsNullOrEmpty(_Campo) Then
                                MsgBox("aca")
                            End If

                            _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                                          _TipoDato,
                                                                          _Es_Descuento,
                                                                          _Row_Encabezado,
                                                                          _Texto)

                            e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Fila_Y)

                        End If
                    End If


                ElseIf _NombreObjeto = "Imagen" Then

                    Try
                        _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                        e.Graphics.DrawImage(_Imagen.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)
                    Catch ex As Exception
                    End Try

                ElseIf _NombreObjeto = "Caja" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)


                    If CBool(_Estilo) Then
                        DrawRoundedRectangle(e.Graphics, _Pen, _Columna_X, _Fila_Y, _Ancho, _Alto, 30)
                    Else
                        e.Graphics.DrawRectangle(_Pen, New Rectangle(_Columna_X, _Fila_Y, _Ancho, _Alto))
                    End If

                ElseIf _NombreObjeto = "" Then

                    _Color = Color.FromArgb(_Color)
                    Dim drawBrush As New SolidBrush(_Color)

                    Dim _Pen As New Pen(drawBrush, _Tamano)

                    ' e.Graphics.DrawLine(_Pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

                End If

            Next

            e.HasMorePages = False

            _Documento_Impreso = True

        Catch ex As Exception
            _Ultimo_Error = ex.Message
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Function Fx_Imprimir_Funciones_Detalle(_Funcion As String,
                                           _Texto As String,
                                           _Tbl_Detalle As DataTable,
                                           e As PrintPageEventArgs,
                                           _yPos As Integer,
                                           _xPos As Integer,
                                           _Fte_Usar As Font,
                                           _DrawBrush As Brush,
                                           _Imprimir_Detalle As Boolean) As Boolean


        Select Case _Funcion

            Case "Imprimir Detalle Tipo Vale 01" ' Neto Con Linea, Código y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, True, False, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 02" ' Neto Sin Linea, Código y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, False, False, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 03" ' Bruto Con Linea, Código y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, True, False, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 04" ' Bruto Sin Linea, Código y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, False, False, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 05" ' Neto Con Linea Solo Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, True, True, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 06" ' Neto Sin Linea Solo Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, False, True, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 07" ' Bruto Con Linea Solo Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, True, True, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 08" ' Bruto Sin Linea Solo Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, False, True, False, False, False, False)

            Case "Imprimir Detalle Tipo Vale 09" ' Neto Sin Linea, Código y Descripcion Con Observaciones por documento
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, True, False, True, True, False, False)

            Case "Imprimir Detalle Tipo Vale 10" ' Bruto Sin Linea, Código y Descripcion Con Observaciones por documento
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, True, False, True, True, False, False)

            Case "Imprimir Detalle Tipo Vale 11" ' Neto Con Linea, Código, Sucursal, Bodega, Ud y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, True, False, False, False, True, True)

            Case "Imprimir Detalle Tipo Vale 12" ' Neto Con Linea, Código, Bodega, Ud y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, True, False, False, False, False, True)

            Case "Imprimir Detalle Tipo Vale 13" ' Bruto Con Linea, Código, Sucursal, Bodega, Ud y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, True, False, False, False, True, True)

            Case "Imprimir Detalle Tipo Vale 14" ' Bruto Con Linea, Código, Bodega, Ud y Descripcion
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, True, False, False, False, False, True)

            Case "Imprimir Detalle Tipo Vale 15" ' Codigo, Descripcion, Cantidad
                Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, True, True)

            Case "Imprimir Detalle Picking 01" ' - CON STOCK FISICO"

                Sb_Funcion_Imprimir_Detalle_Picking_Tipo_Vale(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, False, True, False)

            Case "Imprimir Detalle Picking 02" ' - CON STOCK TEORICO"

                Sb_Funcion_Imprimir_Detalle_Picking_Tipo_Vale(_Tbl_Detalle,
                                                                       e,
                                                                       _Fila_Y,
                                                                       _Columna_X,
                                                                       _Fte_Usar,
                                                                       _DrawBrush, False, False, True, True)

            Case "Texto Libre En Detalle"

                If _Imprimir_Detalle Then
                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                End If

            Case Else
                Return False
        End Select

        Return True

    End Function

    Function Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion As String,
                                                  _Texto As String,
                                                  _Formato_Fx As String,
                                                  e As PrintPageEventArgs,
                                                  _yPos As Integer,
                                                  _xPos As Integer,
                                                  _Fte_Usar As Font,
                                                  _DrawBrush As Brush,
                                                  _Ancho As Single,
                                                  _Alto As Single,
                                                  _Campo As String,
                                                  _Tipo_de_dato As String,
                                                  _Es_Decuento As Boolean,
                                                  _Codigo_De_Barras As Boolean,
                                                  _CodigoQr As Boolean) As Boolean

        Dim _Tido As String
        Dim _Nudo As String

        Dim _Cant_Caracteres As Integer
        Dim _Cant_Caracteres_Texto As Integer

        Try
            _Tido = _Row_Encabezado.Item("TIDO")
            _Nudo = _Row_Encabezado.Item("NUDO")
        Catch ex As Exception
            _Tido = String.Empty
            _Nudo = String.Empty
        End Try

        Dim bm As Bitmap = Nothing
        Dim CodBarras As New PictureBox

        Select Case _Funcion

            Case "Timbre Electronico"

#Region "Timbre Electronico"

                If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                    CodBarras = Fx_Timbre_Electronico_Hefesto(_IdDoc, _Tido, _Nudo)
                Else
                    CodBarras = Fx_Timbre_Electronico(_IdDoc, _Tido, _Nudo)
                End If

                If Not (CodBarras Is Nothing) Then
                    If _Timbre_Falso Then
                        e.Graphics.DrawImage(CodBarras.Image, _Columna_X, _Fila_Y, _Ancho, _Alto / 3)
                    Else
                        e.Graphics.DrawImage(CodBarras.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)
                    End If
                End If

#End Region

            Case "Texto CEDIBLE"

#Region "Texto CEDIBLE"

                If _Imprimir_Cedible Then
                    If _Tido = "GDV" Or _Tido = "GDP" Then
                        e.Graphics.DrawString("CEDIBLE CON SU FACTURA", _Fte_Usar, Brushes.Black, _Columna_X, _Fila_Y)
                    Else
                        e.Graphics.DrawString("CEDIBLE", _Fte_Usar, Brushes.Black, _Columna_X, _Fila_Y)
                    End If
                End If
#End Region

            Case "Documentos Relacionados"

#Region "Documentos Relacionados"

                _Formato_Fx = _Texto
                _Texto = String.Empty
                Dim _TblDoc_Relacionados As DataTable

                Consulta_sql = "Select Distinct TIDOPA+'-'+NUDOPA From MAEDDO Where IDMAEEDO = " & _IdDoc
                _TblDoc_Relacionados = _Sql.Fx_Get_Tablas(Consulta_sql)

                For Each _Fila As DataRow In _TblDoc_Relacionados.Rows
                    _Texto += _Fila.Item(0)
                Next

                _Cant_Caracteres = _Formato_Fx.Length
                _Cant_Caracteres_Texto = _Texto.ToString.Length

                _Texto = Trim(Mid(_Texto, 1, _Cant_Caracteres))

                If _Cant_Caracteres_Texto > _Cant_Caracteres Then _Texto += "..."

                e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

#End Region

            Case "Docs. que lo Pagan (1)", "Docs. que lo Pagan (2)", "Docs. que lo Pagan (3)"

#Region "Documentos que lo pagan"

                _Formato_Fx = _Texto
                _Texto = String.Empty
                Dim _TblDoc_Relacionados As DataTable

                Consulta_sql = "SELECT CE.TIDP,CE.NUDP,CE.EMDP,CE.CUDP,CE.NUCUDP,CE.FEEMDP,CE.FEVEDP,CE.VADP,CD.VAASDP  
                                FROM MAEDPCD AS CD  WITH ( NOLOCK )   
                                LEFT JOIN MAEDPCE AS CE ON CD.IDMAEDPCE=CE.IDMAEDPCE WHERE TIDOPA='" & _Tido & "' AND ARCHIRST='MAEEDO' AND IDRST=" & _IdDoc

                _TblDoc_Relacionados = _Sql.Fx_Get_Tablas(Consulta_sql)

                If Convert.ToBoolean(_TblDoc_Relacionados.Rows.Count) Then

                    Dim _Contador_Filas = 1

                    For Each _Fila As DataRow In _TblDoc_Relacionados.Rows

                        Dim _Tidp = _Fila.Item("TIDP")
                        Dim _Nudp = _Fila.Item("NUDP")
                        Dim _Emdp = _Fila.Item("EMDP")
                        Dim _Cudp = _Fila.Item("CUDP")
                        Dim _Nucudp = _Fila.Item("NUCUDP")
                        Dim _Feemdp = _Fila.Item("FEEMDP")
                        Dim _Fevedp = _Fila.Item("FEVEDP")
                        Dim _Vadp = _Fila.Item("VADP")
                        Dim _Vaasdp = _Fila.Item("VAASDP")

                        'XXX XXXXXXXXXX,Nro: XXXXXXXX $99.999.999
                        If _Funcion = "Docs. que lo Pagan (1)" Then
                            _Texto += Trim(_Tidp & " " & _Nudp & ",Nro: " & Trim(_Nucudp) & " " & FormatCurrency(_Vaasdp))
                        End If

                        If _Funcion = "Docs. que lo Pagan (2)" Then
                            _Texto += Trim(_Tidp & " " & _Nudp & " " & FormatCurrency(_Vaasdp, 0))
                        End If

                        If _Funcion = "Docs. que lo Pagan (3)" Then

                            Dim _Nokoendp As String = _Sql.Fx_Trae_Dato("TABENDP", "NOKOENDP", "TIDPEN = '" & Mid(_Tidp, 1, 2) & "' And KOENDP = '" & _Emdp & "'").ToString.Trim
                            _Texto += Trim(_Tidp & " " & Mid(_Nokoendp, 1, 20) & " " & FormatCurrency(_Vaasdp, 0))

                        End If

                        If _Contador_Filas <> _TblDoc_Relacionados.Rows.Count Then
                            _Texto += "/"
                        End If

                        _Contador_Filas += 1

                    Next

                    _Cant_Caracteres = _Formato_Fx.Length
                    _Cant_Caracteres_Texto = _Texto.ToString.Length

                    _Texto = Trim(Mid(_Texto, 1, _Cant_Caracteres))
                    If _Cant_Caracteres_Texto > _Cant_Caracteres Then _Texto += "..."

                Else

                    _Texto = "** NO REGISTRA PAGOS O ABONOS **"

                End If

                e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

#End Region

            Case "Observaciones Largas(50)"

#Region " Observaciones Largas (50)"

                Dim _Obdo = NuloPorNro(_Row_Encabezado.Item("OBDO"), "")

                _Texto = Replace(_Obdo, vbCrLf, " ")

                Dim _Textos(4) As String

                _Textos(0) = Mid(_Texto, 1, 50)
                _Textos(1) = Mid(_Texto, 51, 100)
                _Textos(2) = Mid(_Texto, 101, 150)
                _Textos(3) = Mid(_Texto, 151, 200)
                _Textos(4) = Mid(_Texto, 201, 250)

                e.Graphics.DrawString(_Textos(0), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                e.Graphics.DrawString(_Textos(1), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 12)
                e.Graphics.DrawString(_Textos(2), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 24)
                e.Graphics.DrawString(_Textos(3), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 36)
                e.Graphics.DrawString(_Textos(4), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 48)
#End Region

            Case "Observaciones Largas(100)"

#Region " Observaciones Largas (100)"

                Dim _Obdo = NuloPorNro(_Row_Encabezado.Item("OBDO"), "")

                _Texto = Replace(_Obdo, vbCrLf, " ")

                Dim _Textos(4) As String

                _Textos(0) = Mid(_Texto, 1, 100)
                _Textos(1) = Mid(_Texto, 101, 200)
                _Textos(2) = Mid(_Texto, 201, 250)

                e.Graphics.DrawString(_Textos(0), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                e.Graphics.DrawString(_Textos(1), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 12)
                e.Graphics.DrawString(_Textos(2), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 24)

#End Region

            Case "Autorizadores Orden De Compra 01", "Autorizadores Orden De Compra 02", "Autorizadores Orden De Compra 03"

#Region "Autorizadores Orden De Compra"

                _Formato_Fx = _Texto
                _Texto = String.Empty

                Consulta_sql = "Select CodFuncionario_Autoriza,NOKOFU, Fecha_Otorga
                                From " & _Global_BaseBk & "Zw_Remotas
                                Inner Join TABFU ON KOFU = CodFuncionario_Autoriza
                                Where Idmaeedo = " & _IdDoc

                Dim _Tbl_Aurotizadores As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Dim _Contador_Filas = 1

                For Each _Fila As DataRow In _Tbl_Aurotizadores.Rows

                    Dim _CodFuncionario_Autoriza = _Fila.Item("CodFuncionario_Autoriza")
                    Dim _Nokofu = _Fila.Item("NOKOFU")
                    Dim _Fecha_Otorga = _Fila.Item("Fecha_Otorga")

                    If _Funcion = "Autorizadores Orden De Compra 01" Then
                        _Texto += Trim(_Nokofu)
                    End If

                    If _Funcion = "Autorizadores Orden De Compra 02" Then
                        _Texto += Trim(_Nokofu) & " (" & FormatDateTime(_Fecha_Otorga, DateFormat.ShortDate) & ")"
                    End If

                    If _Funcion = "Autorizadores Orden De Compra 03" Then
                        _Texto += Trim(_Nokofu) & " (" & Format(_Fecha_Otorga, "dd/MM/yyyy hh:mm") & ")"
                    End If

                    If _Contador_Filas <> _Tbl_Aurotizadores.Rows.Count Then
                        _Texto += ", "
                    End If

                    _Contador_Filas += 1

                Next

                _Cant_Caracteres = _Formato_Fx.Length
                _Cant_Caracteres_Texto = _Texto.ToString.Length

                _Texto = Trim(Mid(_Texto, 1, _Cant_Caracteres))
                If _Cant_Caracteres_Texto > _Cant_Caracteres Then _Texto += "..."

                e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
#End Region

            Case "Referencias DTE Rd"

#Region "Referencias DTE Rd"

                _Formato_Fx = _Texto
                _Texto = String.Empty

                For Each _Fila As DataRow In _Tbl_Referencias.Rows
                    _Texto += _Fila.Item("Referencia") & Space(1)
                Next

                _Cant_Caracteres = _Formato_Fx.Length
                _Cant_Caracteres_Texto = _Texto.ToString.Length

                _Texto = Trim(Mid(_Texto, 1, _Cant_Caracteres))

                If _Cant_Caracteres_Texto > _Cant_Caracteres Then _Texto += "..."

                e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

#End Region

            Case Else

                _Formato_Fx = _Texto

                Dim _Text2 As String = _Texto

                _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                              _Tipo_de_dato,
                                                              _Es_Decuento,
                                                              _Row_Encabezado,
                                                              _Formato_Fx)

                'IMPRIME CODIGO DE BARRAS
                If _Codigo_De_Barras Then

                    Dim iType As BarCode.Code128SubTypes =
                    DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                    'bm = BarCode.Code128(UCase(_Tido & _Nudo), iType, False)
                    bm = BarCode.Code128(_Texto, iType, False)
                    If Not IsNothing(bm) Then
                        CodBarras.Image = bm
                    End If

                    e.Graphics.DrawImage(CodBarras.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)

                ElseIf _CodigoQr Then

                    _QrCodeImgControl.Text = _Text2
                    e.Graphics.DrawImage(_QrCodeImgControl.Image, _Columna_X, _Fila_Y, _Alto, _Alto)

                Else
                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                End If

        End Select

    End Function

    Private Sub Sb_Imprimir_Documento(sender As Object,
                                      e As PrintPageEventArgs)

        Dim _Hora_Pc = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
        Dim _Fecha_Pc = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

        Dim _NroLineasXpag = _TblEncForm.Rows(0).Item("NroLineasXpag")

        Dim _FteCourier_New As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente

        _Fila_Y = 0
        _Columna_X = 0

        Dim _Tido As String = _Row_Encabezado.Item("TIDO")
        Dim _Nudo As String = _Row_Encabezado.Item("NUDO")

        Try

            Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion In ('E','P')"

            Consulta_sql = "SELECT *," &
                           "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                           "Where Nombre_Funcion = Funcion),0) As Funcion_Bk FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion  In ('E','P')"


            Dim _NombreObjeto As String
            Dim _Funcion As String
            Dim _TipoDato As String
            Dim _Seccion As String

            Dim _Formato As String
            Dim _CantDecimales
            Dim _Fuente As String
            Dim _Tamano As Single
            Dim _Alto As Single
            Dim _Ancho As Single
            Dim _Estilo
            Dim _Color

            Dim _Texto
            Dim _RutaImagen As String

            Dim _Fte_Usar
            Dim _Style As FontStyle = FontStyle.Underline
            Dim Imagen As New PictureBox

            Dim _Funcion_Bk As Boolean
            Dim _Formato_Fx As String
            Dim _Campo As String
            Dim _Codigo_De_Barras As Boolean
            Dim _CodigoQR As Boolean
            Dim _Es_Descuento As Boolean

            Dim _SQL_Personalizada As Boolean
            Dim _SqlQuery As String

            Dim _Mostrar_En_Concepto As Boolean

#Region "ENCABEZADO"

            For Each _Fila As DataRow In _Tbl_Fx_Encabezado.Rows

                Dim _Imagen As New PictureBox

                _NombreObjeto = _Fila.Item("NombreObjeto")
                _Funcion = _Fila.Item("Funcion")
                _TipoDato = _Fila.Item("TipoDato")
                _Seccion = _Fila.Item("Seccion")

                _Formato = _Fila.Item("Formato")
                _CantDecimales = _Fila.Item("CantDecimales")
                _Fuente = _Fila.Item("Fuente")
                _Tamano = _Fila.Item("Tamano")
                _Alto = _Fila.Item("Alto")
                _Ancho = _Fila.Item("Ancho")
                _Estilo = _Fila.Item("Estilo")
                _Color = _Fila.Item("Color")
                _Fila_Y = _Fila.Item("Fila_Y")
                _Columna_X = _Fila.Item("Columna_X")
                _Texto = _Fila.Item("Texto")
                _RutaImagen = _Fila.Item("RutaImagen")

                _Funcion_Bk = _Fila.Item("Funcion_Bk")
                _Formato_Fx = _Fila.Item("Formato_Fx")
                _Campo = _Fila.Item("Campo")
                _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                _CodigoQR = _Fila.Item("CodigoQR")
                _Es_Descuento = _Fila.Item("Es_Descuento")

                _SQL_Personalizada = _Fila.Item("SQL_Personalizada")
                _SqlQuery = _Fila.Item("SqlQuery")

                Select Case _Estilo
                    Case 0
                        _Style = FontStyle.Regular
                    Case 1
                        _Style = FontStyle.Bold
                    Case 2
                        _Style = FontStyle.Italic
                    Case 4
                        _Style = FontStyle.Underline
                    Case 8
                        _Style = FontStyle.Strikeout
                    Case Else
                        _Style = FontStyle.Regular
                End Select


                _Fte_Usar = New Font(_Fuente, _Tamano, _Style)
                _Color = Color.FromArgb(_Color)
                Dim _DrawBrush As New SolidBrush(_Color)

                If _NombreObjeto = "Texto_libre" Then

                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Funcion" And _Seccion <> "D" Then

                    Dim bm As Bitmap = Nothing
                    Dim CodBarras As New PictureBox

                    If CBool(_IdDoc) Then

                        If _Funcion_Bk Then

                            Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion,
                                                                 _Texto,
                                                                 _Formato,
                                                                 e,
                                                                 _Fila_Y,
                                                                 _Columna_X,
                                                                 _Fte_Usar,
                                                                 _DrawBrush,
                                                                 _Ancho,
                                                                 _Alto,
                                                                 _Campo,
                                                                 _TipoDato,
                                                                 _Es_Descuento,
                                                                 _Codigo_De_Barras,
                                                                 _CodigoQR)


                        Else

                            Dim _Row As DataRow = _Row_Encabezado

                            If _SQL_Personalizada Then

                                Dim _Error As String
                                _Row = Fx_Funcion_SQL_Personalizada_Enc_Pie(_SqlQuery, _IdDoc, _Error)

                                If String.IsNullOrEmpty(_Error) Then
                                    _Campo = "CAMPO"
                                Else
                                    _Campo = "_Error"
                                End If

                            End If

                            Dim _Formato_Texto As String = _Texto
                            Dim _Formatext = Split(_Formato_Texto, vbCrLf)

                            If _Campo.Contains("STEC_") Then
                                _Campo = Replace(_Campo, "STEC_", "")
                                _Row = _Row_Servicio_Tecnico_Enc
                            End If

                            _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                                          _TipoDato,
                                                                          _Es_Descuento,
                                                                          _Row,
                                                                          _Texto)

                            If _Formatext.Length > 1 Then

                                Dim _Caracteres = _Formato_Texto.Length

                                Dim _i = 0
                                Dim _Contador_Carac

                                _Texto = Replace(_Texto, vbCrLf, " ")

                                If IsNothing(_Texto) Then
                                    _Texto = String.Empty
                                End If

                                Dim _Fy = _Fila_Y

                                For Each _Texto1 As String In _Formatext

                                    Dim _Desde = _i + 1
                                    Dim _Hasta = _Texto1.Length

                                    Dim _Txt = Mid(_Texto, _Desde, _Hasta)
                                    _i += _Texto1.Length

                                    If _Texto.Length > _Contador_Carac Then

                                        e.Graphics.DrawString(_Txt.Trim, _Fte_Usar, _DrawBrush, _Columna_X, _Fy)
                                        _Fy += (_Alto / _Formatext.Length) + 2
                                        _Txt = String.Empty

                                    End If

                                    _Contador_Carac += _Texto1.Length

                                Next

                            Else

                                _Texto = Replace(_Texto, vbCrLf, " ")
                                e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                            End If

                        End If

                    End If

                ElseIf _NombreObjeto = "Imagen" Then

                    Try
                        _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                        e.Graphics.DrawImage(_Imagen.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)
                    Catch ex As Exception
                    End Try

                ElseIf _NombreObjeto = "Caja" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)

                    If CBool(_Estilo) Then
                        DrawRoundedRectangle(e.Graphics, _Pen, _Columna_X, _Fila_Y, _Ancho, _Alto, 30)
                    Else
                        e.Graphics.DrawRectangle(_Pen, New Rectangle(_Columna_X, _Fila_Y, _Ancho, _Alto))
                    End If

                ElseIf _NombreObjeto = "" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)

                End If
            Next

#End Region

#Region "DETALLE NORMAL"

            Dim _Detalle_Y As Integer = _Fila_InicioDetalle

            Dim _Salir_del_For As Boolean
            Dim _Mas_Alto As Integer

            For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                Dim _Es_Codigo_De_Barras As Boolean = _Fila.Item("Codigo_De_Barras")
                _Alto = _Fila.Item("Alto")

                If _Es_Codigo_De_Barras Then
                    _Alto += 6
                End If

                If _Mas_Alto < _Alto Then
                    _Mas_Alto = _Alto
                End If
                _NombreObjeto = _Fila.Item("NombreObjeto")

            Next

            Dim _Salto_Linea As Integer = _Mas_Alto + 2

            Dim _Agrupar_Lineas As Boolean = (_Tbl_Detalle.Rows.Count > _NroLineasXpag)
            Dim _Contador_Lineas = 0

#End Region

#Region "DETALLE AGRUPA LINEAS"

            If _Agrupar_Lineas Then

                For Each _Fila_D As DataRow In _Tbl_Detalle.Rows

                    For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                        _NombreObjeto = _Fila.Item("NombreObjeto")
                        _Funcion = _Fila.Item("Funcion")
                        _TipoDato = _Fila.Item("TipoDato")
                        _Seccion = _Fila.Item("Seccion")

                        _Formato = _Fila.Item("Formato")
                        _CantDecimales = _Fila.Item("CantDecimales")
                        _Fuente = _Fila.Item("Fuente")
                        _Tamano = _Fila.Item("Tamano")
                        _Alto = _Fila.Item("Alto")
                        _Ancho = _Fila.Item("Ancho")
                        _Estilo = _Fila.Item("Estilo")
                        _Color = _Fila.Item("Color")
                        _Fila_Y = _Fila.Item("Fila_Y")
                        _Columna_X = _Fila.Item("Columna_X")
                        _Texto = _Fila.Item("Texto")
                        _RutaImagen = _Fila.Item("RutaImagen")

                        _SQL_Personalizada = _Fila.Item("SQL_Personalizada")
                        _SqlQuery = _Fila.Item("SqlQuery")

                        Dim _Prct As Boolean = _Fila_D.Item("PRCT")
                        _Mostrar_En_Concepto = _Fila.Item("Mostrar_En_Concepto")

                        Dim _Imprimir_Detalle As Boolean = True

                        If _Prct And Not _Mostrar_En_Concepto Then
                            _Imprimir_Detalle = False
                        End If

                        Select Case _Estilo
                            Case 0
                                _Style = FontStyle.Regular
                            Case 1
                                _Style = FontStyle.Bold
                            Case 2
                                _Style = FontStyle.Italic
                            Case 4
                                _Style = FontStyle.Underline
                            Case 8
                                _Style = FontStyle.Strikeout
                            Case Else
                                _Style = FontStyle.Regular
                        End Select

                        _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                        _Funcion_Bk = _Fila.Item("Funcion_Bk")
                        _Formato_Fx = _Fila.Item("Formato_Fx")
                        _Campo = _Fila.Item("Campo")
                        _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                        _Es_Descuento = _Fila.Item("Es_Descuento")

                        _Color = Color.FromArgb(_Color)
                        Dim _DrawBrush As New SolidBrush(_Color)

                        If CBool(_IdDoc) Then

                            If _NombreObjeto = "Texto_libre" Then

                                If _Imprimir_Detalle Then

                                    Dim _Y_Texto = _Fila_InicioDetalle

                                    For Each _Fii As DataRow In _Tbl_Detalle.Rows
                                        e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Y_Texto)
                                        _Y_Texto += _Salto_Linea
                                    Next

                                End If

                            ElseIf _NombreObjeto = "Funcion" Then

                                If _Funcion_Bk Then

                                    If Fx_Imprimir_Funciones_Detalle(_Funcion,
                                                                        _Texto,
                                                                        _Tbl_Detalle,
                                                                        e,
                                                                        _Fila_Y,
                                                                        _Columna_X,
                                                                        _Fte_Usar,
                                                                        _DrawBrush, _Imprimir_Detalle) Then
                                        _Salir_del_For = True
                                        Exit For
                                    End If

                                Else

                                    Dim _Row_Fila_D As DataRow = _Fila_D

                                    If _SQL_Personalizada Then

                                        Dim _Error As String
                                        Dim _Idmaeddo = _Fila_D.Item("IDMAEDDO")

                                        _Row_Fila_D = Fx_Funcion_SQL_Personalizada_Detalle(_SqlQuery, _Idmaeddo, _Error)

                                        If String.IsNullOrEmpty(_Error) Then
                                            _Campo = "CAMPO"
                                        Else
                                            _Campo = "_Error"
                                        End If

                                    End If

                                    _Texto = Fx_New_Trae_Valor_Detalle_Row(_Campo,
                                                                               _TipoDato,
                                                                               _Es_Descuento,
                                                                               _Row_Fila_D,
                                                                               _Texto)

                                    'IMPRIME CODIGO DE BARRAS
                                    If _Codigo_De_Barras Then

                                        Dim bm As Bitmap = Nothing
                                        Dim CodBarras As New PictureBox

                                        Dim iType As BarCode.Code128SubTypes =
                                            DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                                        bm = BarCode.Code128(_Texto, iType, False)
                                        If Not IsNothing(bm) Then
                                            CodBarras.Image = bm
                                        End If
                                        Dim d = _Detalle_Y

                                        If _Imprimir_Detalle Then

                                            e.Graphics.DrawImage(CodBarras.Image, _Columna_X, _Detalle_Y - 3, _Ancho, _Alto - 2)

                                        End If

                                    Else

                                        If _Imprimir_Detalle Then

                                            e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                                        End If

                                    End If

                                End If

                            End If

                        Else

                        End If

                    Next

                    _Detalle_Y += _Salto_Linea - 2

                    _Contador_Lineas += 1

                    If _Contador_Lineas > _NroLineasXpag Then
                        _Salir_del_For = True
                    End If

                    If _Salir_del_For Then
                        Exit For
                    End If

                Next

                'Dim _DrawBrush2 As New SolidBrush(Color.Black)
                e.Graphics.DrawString("--------------------", _Fte_Usar, New SolidBrush(Color.Black), 100, _Detalle_Y)

            Else

                For Each _Fila_D As DataRow In _Tbl_Detalle.Rows

                    For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                        _NombreObjeto = _Fila.Item("NombreObjeto")
                        _Funcion = _Fila.Item("Funcion")
                        _TipoDato = _Fila.Item("TipoDato")
                        _Seccion = _Fila.Item("Seccion")

                        _Formato = _Fila.Item("Formato")
                        _CantDecimales = _Fila.Item("CantDecimales")
                        _Fuente = _Fila.Item("Fuente")
                        _Tamano = _Fila.Item("Tamano")
                        _Alto = _Fila.Item("Alto")
                        _Ancho = _Fila.Item("Ancho")
                        _Estilo = _Fila.Item("Estilo")
                        _Color = _Fila.Item("Color")
                        _Fila_Y = _Fila.Item("Fila_Y")
                        _Columna_X = _Fila.Item("Columna_X")
                        _Texto = _Fila.Item("Texto")
                        _RutaImagen = _Fila.Item("RutaImagen")

                        _SQL_Personalizada = _Fila.Item("SQL_Personalizada")
                        _SqlQuery = _Fila.Item("SqlQuery")

                        Dim _Orden_Detalle = _Fila.Item("Orden_Detalle")

                        Select Case _Estilo
                            Case 0
                                _Style = FontStyle.Regular
                            Case 1
                                _Style = FontStyle.Bold
                            Case 2
                                _Style = FontStyle.Italic
                            Case 4
                                _Style = FontStyle.Underline
                            Case 8
                                _Style = FontStyle.Strikeout
                            Case Else
                                _Style = FontStyle.Regular
                        End Select

                        _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                        _Funcion_Bk = _Fila.Item("Funcion_Bk")
                        _Formato_Fx = _Fila.Item("Formato_Fx")
                        _Campo = _Fila.Item("Campo")
                        _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                        _Es_Descuento = _Fila.Item("Es_Descuento")

                        _Color = Color.FromArgb(_Color)

                        Dim _DrawBrush As New SolidBrush(_Color)

                        Dim _Prct As Boolean = _Fila_D.Item("PRCT")
                        _Mostrar_En_Concepto = _Fila.Item("Mostrar_En_Concepto")

                        Dim _Imprimir_Detalle As Boolean = True

                        If _Prct And Not _Mostrar_En_Concepto Then
                            _Imprimir_Detalle = False
                        End If

                        If CBool(_IdDoc) Then

                            If _NombreObjeto = "Texto_libre" Then

                                If _Imprimir_Detalle Then

                                    Dim _Y_Texto = _Fila_InicioDetalle

                                    For Each _Fii As DataRow In _Tbl_Detalle.Rows
                                        e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Y_Texto)
                                        _Y_Texto += _Salto_Linea
                                    Next

                                End If

                            ElseIf _NombreObjeto = "Funcion" Then

                                If _Funcion_Bk Then

                                    If Fx_Imprimir_Funciones_Detalle(_Funcion,
                                                                        _Texto,
                                                                        _Tbl_Detalle,
                                                                        e,
                                                                        _Fila_Y,
                                                                        _Columna_X,
                                                                        _Fte_Usar,
                                                                        _DrawBrush, _Imprimir_Detalle) Then

                                        _Salir_del_For = True
                                        Exit For

                                    End If

                                Else

                                    Dim _Row_Fila_D As DataRow = _Fila_D

                                    If _SQL_Personalizada Then

                                        Dim _Error As String
                                        Dim _Idmaeddo = _Fila_D.Item("IDMAEDDO")

                                        _Row_Fila_D = Fx_Funcion_SQL_Personalizada_Detalle(_SqlQuery, _Idmaeddo, _Error)

                                        If String.IsNullOrEmpty(_Error) Then
                                            _Campo = "CAMPO"
                                        Else
                                            _Campo = "_Error"
                                        End If

                                    End If

                                    _Texto = Fx_New_Trae_Valor_Detalle_Row(_Campo,
                                                                               _TipoDato,
                                                                               _Es_Descuento,
                                                                               _Row_Fila_D,
                                                                               _Texto)

                                    If _Orden_Detalle = 2 And Not String.IsNullOrEmpty(_Texto) Then

                                        _Detalle_Y += _Alto + 2

                                    End If

                                    'IMPRIME CODIGO DE BARRAS
                                    If _Codigo_De_Barras Then

                                        Dim bm As Bitmap = Nothing
                                        Dim CodBarras As New PictureBox

                                        Dim iType As BarCode.Code128SubTypes =
                                            DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                                        bm = BarCode.Code128(_Texto, iType, False)
                                        If Not IsNothing(bm) Then
                                            CodBarras.Image = bm
                                        End If

                                        If _Imprimir_Detalle Then

                                            e.Graphics.DrawImage(CodBarras.Image, _Columna_X, _Detalle_Y - 3, _Ancho, _Alto - 2)

                                        End If

                                    Else

                                        If _Imprimir_Detalle Then

                                            e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    Next

                    _Detalle_Y += _Salto_Linea

                    If _Salir_del_For Then
                        Exit For
                    End If

                Next

            End If

#End Region

#Region "REFERENCIAS"

            '' REFERENCIAS *****

            For Each _Fila_D As DataRow In _Tbl_Referencias.Rows

                Dim _Referencia = _Fila_D.Item("Referencia")
                Dim _Contador = 0

                For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                    _NombreObjeto = _Fila.Item("NombreObjeto")
                    _Funcion = _Fila.Item("Funcion")
                    _TipoDato = _Fila.Item("TipoDato")
                    _Seccion = _Fila.Item("Seccion")

                    _Formato = _Fila.Item("Formato")
                    _CantDecimales = _Fila.Item("CantDecimales")
                    _Fuente = _Fila.Item("Fuente")
                    _Tamano = _Fila.Item("Tamano")
                    _Alto = _Fila.Item("Alto")
                    _Ancho = _Fila.Item("Ancho")
                    _Estilo = _Fila.Item("Estilo")
                    _Color = _Fila.Item("Color")
                    _Fila_Y = _Fila.Item("Fila_Y")
                    _Columna_X = _Fila.Item("Columna_X")
                    _Texto = _Fila.Item("Texto")
                    _RutaImagen = _Fila.Item("RutaImagen")

                    Select Case _Estilo
                        Case 0
                            _Style = FontStyle.Regular
                        Case 1
                            _Style = FontStyle.Bold
                        Case 2
                            _Style = FontStyle.Italic
                        Case 4
                            _Style = FontStyle.Underline
                        Case 8
                            _Style = FontStyle.Strikeout
                        Case Else
                            _Style = FontStyle.Regular
                    End Select

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    _Color = Color.FromArgb(_Color)
                    Dim _DrawBrush As New SolidBrush(_Color)

                    If _NombreObjeto = "Funcion" Then

                        If _Funcion_Bk Then

                            If _Funcion = "Referencia DTE" Then

                                If _Contador = 0 Then
                                    e.Graphics.DrawString("------------------  Referencias ------------------------",
                                                          _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                    _Detalle_Y += _Salto_Linea
                                End If

                                e.Graphics.DrawString(_Referencia, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                            End If

                        End If

                    End If

                Next

                _Contador += 1
                _Detalle_Y += _Salto_Linea

            Next

            '' ********
#End Region

#Region "DOCUMENTOS ASOCIADOS A RECARGOS"

            Dim _Contador_Dra = 0

            For Each _Fila_D As DataRow In _Tbl_Doc_Asociados_Recargos.Rows

                Dim _DRA As String

                Dim _Tido_Dra = _Fila_D.Item("TIDO")
                Dim _Nudo_Dra = _Fila_D.Item("NUDO")
                Dim _Feemdo_Dra = FormatDateTime(_Fila_D.Item("FEEMDO"), DateFormat.ShortDate)

                _DRA = _Tido_Dra & " - " & _Nudo_Dra & " - " & _Feemdo_Dra

                For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                    _NombreObjeto = _Fila.Item("NombreObjeto")
                    _Funcion = _Fila.Item("Funcion")
                    _TipoDato = _Fila.Item("TipoDato")
                    _Seccion = _Fila.Item("Seccion")

                    _Formato = _Fila.Item("Formato")
                    _CantDecimales = _Fila.Item("CantDecimales")
                    _Fuente = _Fila.Item("Fuente")
                    _Tamano = _Fila.Item("Tamano")
                    _Alto = _Fila.Item("Alto")
                    _Ancho = _Fila.Item("Ancho")
                    _Estilo = _Fila.Item("Estilo")
                    _Color = _Fila.Item("Color")
                    _Fila_Y = _Fila.Item("Fila_Y")
                    _Columna_X = _Fila.Item("Columna_X")
                    _Texto = _Fila.Item("Texto")
                    _RutaImagen = _Fila.Item("RutaImagen")

                    Select Case _Estilo
                        Case 0
                            _Style = FontStyle.Regular
                        Case 1
                            _Style = FontStyle.Bold
                        Case 2
                            _Style = FontStyle.Italic
                        Case 4
                            _Style = FontStyle.Underline
                        Case 8
                            _Style = FontStyle.Strikeout
                        Case Else
                            _Style = FontStyle.Regular
                    End Select

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    _Color = Color.FromArgb(_Color)
                    Dim _DrawBrush As New SolidBrush(_Color)

                    If _NombreObjeto = "Funcion" Then

                        If _Funcion_Bk Then

                            If _Funcion = "Documentos Recargos Asociados (DRA)" Then

                                If _Contador_Dra = 0 Then
                                    e.Graphics.DrawString("------------- Documentos asociados a recargos -------------",
                                                          _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                    _Detalle_Y += _Salto_Linea
                                End If

                                e.Graphics.DrawString(_DRA, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                            End If

                        End If

                    End If

                Next
                _Contador_Dra += 1
                _Detalle_Y += _Salto_Linea

            Next

            _Fila_FinDetalle = _Detalle_Y

            ' FIN REFERENCIA

#End Region


#Region "ORDENES DE SERVICIO, OPERACIONES Y OT"

            Dim _Idmaeedo = _Tbl_Encabezado.Rows(0).Item("IDMAEEDO")

            Consulta_sql = "Select Ot.Nro_Ot,Ot.Sub_Ot,Det.Codigo,Det.Descripcion,Det.Idmaeddo_Cov" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_St_OT_DetProd Det" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_St_OT_Encabezado Ot On Ot.Id_Ot = Det.Id_Ot" & vbCrLf &
                           "Where Idmaeedo_Cov = " & _Idmaeedo

            Dim _Tbl_Ot As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _FlOt As DataRow In _Tbl_Ot.Rows

                Dim _DatosOT As String = "OT: " & _FlOt.Item("Nro_Ot")

                If Not String.IsNullOrEmpty(_FlOt.Item("Sub_Ot")) Then
                    _DatosOT += ", SubOt: " & _FlOt.Item("Sub_Ot")
                End If

                Dim _Idmaeddo_Cov As Integer = _FlOt.Item("Idmaeddo_Cov")

                Consulta_sql = "Select OpxS.Id, OpxS.Id_Ot, OpxS.Semilla, OpxS.Codigo,OpxS.CodReceta,OpxS.Operacion,Oper.Descripcion," &
               "OpxS.Orden,OpxS.CantMayor1,OpxS.Cantidad, CantidadRealizada, OpxS.Precio, Total, Realizado, OpxS.Externa" & vbCrLf &
               "From " & _Global_BaseBk & "Zw_St_OT_OpeXServ OpxS" & vbCrLf &
               "Inner Join " & _Global_BaseBk & "Zw_St_OT_DetProd Stdet On Stdet.Semilla = OpxS.Semilla" & vbCrLf &
               "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On Oper.Operacion = OpxS.Operacion" & vbCrLf &
               "Where Idmaeddo_Cov = " & _Idmaeddo_Cov

                Dim _Tbl_Operaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Dim _EncImpreso As Boolean

                Dim _DrawBrush As SolidBrush

                For Each _Fila_D As DataRow In _Tbl_Operaciones.Rows

                    Dim _Operacion = _Fila_D.Item("Operacion").ToString.Trim
                    Dim _DescOperacion = _Fila_D.Item("Descripcion").ToString.Trim 'Rellenar(_Fila_D.Item("Descripcion").ToString.Trim, 50, " ")
                    Dim _Cantidad = _Fila_D.Item("Cantidad")
                    Dim _Precio = _Fila_D.Item("Precio")
                    Dim _Total = _Fila_D.Item("Total")

                    Dim _DetalleOperacion1 = Space(5) & " - " & _Operacion & ":" & _DescOperacion & " - Cant.: " & FormatNumber(_Cantidad, 0) & " X " & FormatCurrency(_Precio, 0) & " = " & FormatCurrency(_Total, 0)
                    Dim _DetalleOperacion2 = Space(5) & " - " & _DescOperacion & " - Cant.: " & FormatNumber(_Cantidad, 0) & " X " & FormatCurrency(_Precio, 0) & " = " & FormatCurrency(_Total, 0)
                    Dim _DetalleOperacion3 = Space(5) & " - " & _DescOperacion & " - Cant.: " & FormatNumber(_Cantidad, 0)

                    Dim _Contador = 0

                    For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                        _NombreObjeto = _Fila.Item("NombreObjeto")
                        _Funcion = _Fila.Item("Funcion")
                        _TipoDato = _Fila.Item("TipoDato")
                        _Seccion = _Fila.Item("Seccion")

                        _Formato = _Fila.Item("Formato")
                        _CantDecimales = _Fila.Item("CantDecimales")
                        _Fuente = _Fila.Item("Fuente")
                        _Tamano = _Fila.Item("Tamano")
                        _Alto = _Fila.Item("Alto")
                        _Ancho = _Fila.Item("Ancho")
                        _Estilo = _Fila.Item("Estilo")
                        _Color = _Fila.Item("Color")
                        _Fila_Y = _Fila.Item("Fila_Y")
                        _Columna_X = _Fila.Item("Columna_X")
                        _Texto = _Fila.Item("Texto")
                        _RutaImagen = _Fila.Item("RutaImagen")

                        Select Case _Estilo
                            Case 0
                                _Style = FontStyle.Regular
                            Case 1
                                _Style = FontStyle.Bold
                            Case 2
                                _Style = FontStyle.Italic
                            Case 4
                                _Style = FontStyle.Underline
                            Case 8
                                _Style = FontStyle.Strikeout
                            Case Else
                                _Style = FontStyle.Regular
                        End Select

                        _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                        _Funcion_Bk = _Fila.Item("Funcion_Bk")
                        _Formato_Fx = _Fila.Item("Formato_Fx")
                        _Campo = _Fila.Item("Campo")
                        _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                        _Es_Descuento = _Fila.Item("Es_Descuento")

                        _Color = Color.FromArgb(_Color)
                        _DrawBrush = New SolidBrush(_Color)

                        If _NombreObjeto = "Funcion" Then

                            If _Funcion_Bk Then

                                If _Funcion.Contains("Orden de servicio") Then

                                    Dim _DetalleOperacion As String

                                    If _Funcion = "Orden de servicio1" Then _DetalleOperacion = _DetalleOperacion1
                                    If _Funcion = "Orden de servicio2" Then _DetalleOperacion = _DetalleOperacion2
                                    If _Funcion = "Orden de servicio3" Then _DetalleOperacion = _DetalleOperacion3

                                    If Not _EncImpreso Then
                                        e.Graphics.DrawString("* " & _DatosOT, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                        _Detalle_Y += _Salto_Linea
                                        e.Graphics.DrawString("* DETALLE DE TRABAJOS:", _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                        _Detalle_Y += _Salto_Linea
                                        _EncImpreso = True
                                    End If

                                    e.Graphics.DrawString(_DetalleOperacion, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                                End If

                            End If

                        End If

                    Next

                    _Contador += 1
                    _Detalle_Y += _Salto_Linea

                Next

                e.Graphics.DrawString("-------------------------------------------------------------------------------------------", _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                _Detalle_Y += _Salto_Linea

                _EncImpreso = False

            Next

#End Region

            _Documento_Impreso = True

        Catch ex As Exception
            _Ultimo_Error = ex.Message
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Imprimir_Cheque(sender As Object,
                                      e As PrintPageEventArgs)


        Dim FilaEnc = _TblEncForm.Rows(0)

        Dim _Doc_NrolineasXpag = FilaEnc.Item("NrolineasXpag")
        Dim _Doc_Fila_InicioDetalle = FilaEnc.Item("Fila_InicioDetalle")
        Dim _Doc_Fila_FinDetalle = FilaEnc.Item("Fila_FinDetalle")
        Dim _Doc_Col_InicioDetalle = FilaEnc.Item("Col_InicioDetalle")
        Dim _Doc_Col_FinDetalle = FilaEnc.Item("Col_FinDetalle")

        Dim _Hora_Pc = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
        Dim _Fecha_Pc = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

        Dim _FteCourier_New As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente

        _Fila_Y = 0
        _Columna_X = 0

        'Dim _Tido As String = _Row_Encabezado.Item("TIDO")
        'Dim _Nudo As String = _Row_Encabezado.Item("NUDO")


        Try

            Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion In ('E','P')"

            Consulta_sql = "SELECT *," &
                           "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                           "Where Nombre_Funcion = Funcion),0) As Funcion_Bk FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "' And Seccion  In ('E','P')"


            Dim _NombreObjeto As String
            Dim _Funcion As String
            Dim _TipoDato As String
            Dim _Seccion As String

            Dim _Formato As String
            Dim _CantDecimales
            Dim _Fuente As String
            Dim _Tamano As Single
            Dim _Alto As Single
            Dim _Ancho As Single
            Dim _Estilo
            Dim _Color

            Dim _Texto
            Dim _RutaImagen As String

            Dim _Fte_Usar
            Dim _Style As FontStyle = FontStyle.Underline
            Dim Imagen As New PictureBox

            Dim _Funcion_Bk As Boolean
            Dim _Formato_Fx As String
            Dim _Campo As String
            Dim _Codigo_De_Barras As Boolean
            Dim _CodigoQR As Boolean
            Dim _Es_Descuento As Boolean


            For Each _Fila As DataRow In _Tbl_Fx_Encabezado.Rows

                Dim _Imagen As New PictureBox

                _NombreObjeto = _Fila.Item("NombreObjeto")
                _Funcion = _Fila.Item("Funcion")
                _TipoDato = _Fila.Item("TipoDato")
                _Seccion = _Fila.Item("Seccion")

                _Formato = _Fila.Item("Formato")
                _CantDecimales = _Fila.Item("CantDecimales")
                _Fuente = _Fila.Item("Fuente")
                _Tamano = _Fila.Item("Tamano")
                _Alto = _Fila.Item("Alto")
                _Ancho = _Fila.Item("Ancho")
                _Estilo = _Fila.Item("Estilo")
                _Color = _Fila.Item("Color")
                _Fila_Y = _Fila.Item("Fila_Y")
                _Columna_X = _Fila.Item("Columna_X")
                _Texto = _Fila.Item("Texto")
                _RutaImagen = _Fila.Item("RutaImagen")

                _Funcion_Bk = _Fila.Item("Funcion_Bk")
                _Formato_Fx = _Fila.Item("Formato_Fx")
                _Campo = _Fila.Item("Campo")
                _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                _CodigoQR = _Fila.Item("CodigoQR")
                _Es_Descuento = _Fila.Item("Es_Descuento")


                Select Case _Estilo
                    Case 0
                        _Style = FontStyle.Regular
                    Case 1
                        _Style = FontStyle.Bold
                    Case 2
                        _Style = FontStyle.Italic
                    Case 4
                        _Style = FontStyle.Underline
                    Case 8
                        _Style = FontStyle.Strikeout
                    Case Else
                        _Style = FontStyle.Regular
                End Select


                _Fte_Usar = New Font(_Fuente, _Tamano, _Style)
                _Color = Color.FromArgb(_Color)
                Dim _DrawBrush As New SolidBrush(_Color)

                If _NombreObjeto = "Texto_libre" Then

                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Funcion" And _Seccion <> "D" Then

                    Dim bm As Bitmap = Nothing
                    Dim CodBarras As New PictureBox

                    If CBool(_IdDoc) Then

                        If _Funcion_Bk Then

                            Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion,
                                                                 _Texto,
                                                                 _Formato,
                                                                 e,
                                                                 _Fila_Y,
                                                                 _Columna_X,
                                                                 _Fte_Usar,
                                                                 _DrawBrush,
                                                                 _Ancho,
                                                                 _Alto,
                                                                 _Campo,
                                                                 _TipoDato,
                                                                 _Es_Descuento,
                                                                 _Codigo_De_Barras,
                                                                 _CodigoQR)


                        Else

                            'Dim _Fx As New Frm_Formato_Creador_Funciones(_IdMaeedo)
                            _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                                          _TipoDato,
                                                                          _Es_Descuento,
                                                                          _Row_Encabezado,
                                                                          _Texto)

                            e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                        End If

                    End If

                ElseIf _NombreObjeto = "Imagen" Then

                    Try
                        _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                        e.Graphics.DrawImage(_Imagen.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)
                    Catch ex As Exception
                    End Try

                ElseIf _NombreObjeto = "Caja" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)


                    If CBool(_Estilo) Then
                        DrawRoundedRectangle(e.Graphics, _Pen, _Columna_X, _Fila_Y, _Ancho, _Alto, 30)
                    Else
                        e.Graphics.DrawRectangle(_Pen, New Rectangle(_Columna_X, _Fila_Y, _Ancho, _Alto))
                    End If

                ElseIf _NombreObjeto = "" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)

                End If

            Next


            Dim _Detalle_Y As Integer = _Fila_InicioDetalle

            Dim _Salir_del_For As Boolean
            Dim _Mas_Alto As Integer

            For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                _Alto = _Fila.Item("Alto")

                If _Mas_Alto < _Alto Then
                    _Mas_Alto = _Alto
                End If
                _NombreObjeto = _Fila.Item("NombreObjeto")

            Next

            Dim _Salto_Linea As Integer = _Mas_Alto + 2

            Dim _Contador = 1

            For Each _Fila_D As DataRow In _Tbl_Detalle.Rows

                For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                    _NombreObjeto = _Fila.Item("NombreObjeto")
                    _Funcion = _Fila.Item("Funcion")
                    _TipoDato = _Fila.Item("TipoDato")
                    _Seccion = _Fila.Item("Seccion")

                    _Formato = _Fila.Item("Formato")
                    _CantDecimales = _Fila.Item("CantDecimales")
                    _Fuente = _Fila.Item("Fuente")
                    _Tamano = _Fila.Item("Tamano")
                    _Alto = _Fila.Item("Alto")
                    _Ancho = _Fila.Item("Ancho")
                    _Estilo = _Fila.Item("Estilo")
                    _Color = _Fila.Item("Color")
                    _Fila_Y = _Fila.Item("Fila_Y")
                    _Columna_X = _Fila.Item("Columna_X")
                    _Texto = _Fila.Item("Texto")
                    _RutaImagen = _Fila.Item("RutaImagen")

                    Select Case _Estilo
                        Case 0
                            _Style = FontStyle.Regular
                        Case 1
                            _Style = FontStyle.Bold
                        Case 2
                            _Style = FontStyle.Italic
                        Case 4
                            _Style = FontStyle.Underline
                        Case 8
                            _Style = FontStyle.Strikeout
                        Case Else
                            _Style = FontStyle.Regular
                    End Select

                    _Fte_Usar = New Font(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    _Color = Color.FromArgb(_Color)
                    Dim _DrawBrush As New SolidBrush(_Color)

                    If CBool(_IdDoc) Then

                        If _NombreObjeto = "Texto_libre" Then

                            Dim _Y_Texto = _Fila_InicioDetalle

                            If _TipoDoc = "CHC" Then
                                If _Contador = _Doc_NrolineasXpag Then _Texto = "..."
                                If _Contador <= _Doc_NrolineasXpag Then
                                    e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Detalle_Y) '_Y_Texto)
                                End If
                            Else
                                e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Detalle_Y) '_Y_Texto)
                            End If

                        ElseIf _NombreObjeto = "Funcion" Then

                            If _Funcion_Bk Then

                                If Fx_Imprimir_Funciones_Detalle(_Funcion,
                                                                _Texto,
                                                                _Tbl_Detalle,
                                                                e,
                                                                _Fila_Y,
                                                                _Columna_X,
                                                                _Fte_Usar,
                                                                _DrawBrush, True) Then
                                    _Salir_del_For = True
                                    Exit For
                                End If

                            Else

                                _Texto = Fx_New_Trae_Valor_Detalle_Row(_Campo,
                                                                       _TipoDato,
                                                                       _Es_Descuento,
                                                                       _Fila_D,
                                                                       _Texto)

                                'IMPRIME CODIGO DE BARRAS
                                If _Codigo_De_Barras Then

                                    Dim bm As Bitmap = Nothing
                                    Dim CodBarras As New PictureBox

                                    Dim iType As BarCode.Code128SubTypes =
                                    DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                                    bm = BarCode.Code128(_Texto, iType, False)
                                    If Not IsNothing(bm) Then
                                        CodBarras.Image = bm
                                    End If
                                    Dim d = _Detalle_Y

                                    If _TipoDoc = "CHC" Then
                                        If _Contador = _Doc_NrolineasXpag Then _Texto = "..."
                                        If _Contador <= _Doc_NrolineasXpag Then
                                            e.Graphics.DrawImage(CodBarras.Image, _Columna_X, _Detalle_Y - 3, _Ancho, _Alto - 2)
                                        End If
                                    Else
                                        e.Graphics.DrawImage(CodBarras.Image, _Columna_X, _Detalle_Y - 3, _Ancho, _Alto - 2)
                                    End If

                                Else

                                    If _Contador > _Doc_NrolineasXpag Then
                                        _Salir_del_For = True
                                        Exit For
                                    End If

                                    If _TipoDoc = "CHC" Then
                                        If _Contador = _Doc_NrolineasXpag Then _Texto = "..."
                                        If _Contador <= _Doc_NrolineasXpag Then
                                            e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                        End If
                                    Else
                                        e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                    End If

                                End If

                            End If

                        End If

                    Else

                    End If

                Next

                _Contador += 1

                _Detalle_Y += _Salto_Linea

                If _Salir_del_For Then
                    Exit For
                End If

            Next


            _Documento_Impreso = True

        Catch ex As Exception
            _Ultimo_Error = ex.Message
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Imprimir_Solicitud_Prod_Bodega(sender As Object,
                                                  e As PrintPageEventArgs)


        Dim _Hora_Pc = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
        Dim _Fecha_Pc = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

        Dim _FteCourier_New As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente

        _Fila_Y = 0
        _Columna_X = 0

        Try

            Dim _NombreObjeto As String
            Dim _Funcion As String
            Dim _TipoDato As String
            Dim _Seccion As String

            Dim _Formato As String
            Dim _CantDecimales
            Dim _Fuente As String
            Dim _Tamano As Single
            Dim _Alto As Single
            Dim _Ancho As Single
            Dim _Estilo
            Dim _Color

            Dim _Texto
            Dim _RutaImagen As String

            Dim _Fte_Usar
            Dim _Style As FontStyle = FontStyle.Underline
            Dim Imagen As New PictureBox

            Dim _Funcion_Bk As Boolean
            Dim _Formato_Fx As String
            Dim _Campo As String
            Dim _Codigo_De_Barras As Boolean
            Dim _CodigoQR As Boolean
            Dim _Es_Descuento As Boolean


            For Each _Fila As DataRow In _Tbl_Fx_Encabezado.Rows

                Dim _Imagen As New PictureBox

                _NombreObjeto = _Fila.Item("NombreObjeto")
                _Funcion = _Fila.Item("Funcion")
                _TipoDato = _Fila.Item("TipoDato")
                _Seccion = _Fila.Item("Seccion")

                _Formato = _Fila.Item("Formato")
                _CantDecimales = _Fila.Item("CantDecimales")
                _Fuente = _Fila.Item("Fuente")
                _Tamano = _Fila.Item("Tamano")
                _Alto = _Fila.Item("Alto")
                _Ancho = _Fila.Item("Ancho")
                _Estilo = _Fila.Item("Estilo")
                _Color = _Fila.Item("Color")
                _Fila_Y = _Fila.Item("Fila_Y")
                _Columna_X = _Fila.Item("Columna_X")
                _Texto = _Fila.Item("Texto")
                _RutaImagen = _Fila.Item("RutaImagen")

                _Funcion_Bk = _Fila.Item("Funcion_Bk")
                _Formato_Fx = _Fila.Item("Formato_Fx")
                _Campo = _Fila.Item("Campo")
                _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                _CodigoQR = _Fila.Item("CodigoQR")
                _Es_Descuento = _Fila.Item("Es_Descuento")


                Select Case _Estilo
                    Case 0
                        _Style = FontStyle.Regular
                    Case 1
                        _Style = FontStyle.Bold
                    Case 2
                        _Style = FontStyle.Italic
                    Case 4
                        _Style = FontStyle.Underline
                    Case 8
                        _Style = FontStyle.Strikeout
                    Case Else
                        _Style = FontStyle.Regular
                End Select


                _Fte_Usar = New Font(_Fuente, _Tamano, _Style)
                _Color = Color.FromArgb(_Color)
                Dim _DrawBrush As New SolidBrush(_Color)

                If _NombreObjeto = "Texto_libre" Then

                    e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Funcion" And _Seccion <> "D" Then

                    Dim bm As Bitmap = Nothing
                    Dim CodBarras As New PictureBox

                    'If CBool(_IdDoc) Then

                    If _Funcion_Bk Then

                        Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion,
                                                             _Texto,
                                                             _Formato,
                                                             e,
                                                             _Fila_Y,
                                                             _Columna_X,
                                                             _Fte_Usar,
                                                             _DrawBrush,
                                                             _Ancho,
                                                             _Alto,
                                                             _Campo,
                                                             _TipoDato,
                                                             _Es_Descuento,
                                                             _Codigo_De_Barras,
                                                             _CodigoQR)


                    Else

                        _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                                      _TipoDato,
                                                                      _Es_Descuento,
                                                                      _Row_Encabezado,
                                                                      _Texto)

                        e.Graphics.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

                    End If

                    'End If

                ElseIf _NombreObjeto = "Imagen" Then

                    Try
                        _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                        e.Graphics.DrawImage(_Imagen.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)
                    Catch ex As Exception
                    End Try

                ElseIf _NombreObjeto = "Caja" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)

                    If CBool(_Estilo) Then
                        DrawRoundedRectangle(e.Graphics, _Pen, _Columna_X, _Fila_Y, _Ancho, _Alto, 30)
                    Else
                        e.Graphics.DrawRectangle(_Pen, New Rectangle(_Columna_X, _Fila_Y, _Ancho, _Alto))
                    End If

                ElseIf _NombreObjeto = "" Then

                    Dim _Pen As New Pen(_DrawBrush, _Tamano)

                End If

            Next

            _Documento_Impreso = True

        Catch ex As Exception
            _Ultimo_Error = ex.Message
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Public Sub DrawRoundedRectangle(objGraphics As Graphics,
                                    _Pen As Pen,
                                    m_intxAxis As Integer,
                                    m_intyAxis As Integer,
                                    m_intWidth As Integer,
                                    m_intHeight As Integer,
                                    m_diameter As Integer)



        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))

        'top left Arc
        objGraphics.DrawArc(_Pen, ArcRect, 180, 90)
        objGraphics.DrawLine(_Pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(_Pen, ArcRect, 270, 90)
        objGraphics.DrawLine(_Pen, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(_Pen, ArcRect, 0, 90)
        objGraphics.DrawLine(_Pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(_Pen, ArcRect, 90, 90)
        objGraphics.DrawLine(_Pen, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

    End Sub

    Private Sub Sb_Imprimir_Regleta(sender As Object,
                                      e As PrintPageEventArgs)

        Dim FteNormal_3 As Font = New Font("Arial", 3, FontStyle.Regular) ' Crea la fuente
        Dim FteNormal_4 As Font = New Font("Arial", 4, FontStyle.Regular) ' Crea la fuente
        Dim FteNormal_5 As Font = New Font("Arial", 5, FontStyle.Regular) ' Crea la fuente
        Dim FteNormal_6 As Font = New Font("Arial", 6, FontStyle.Regular) ' Crea la fuente
        Dim FteNormal_7 As Font = New Font("Arial", 7, FontStyle.Regular) ' Crea la fuente
        Dim FteNormal_8 As Font = New Font("Arial", 8, FontStyle.Regular) ' Crea la fuente
        Dim FteNormal_9 As Font = New Font("Arial", 9, FontStyle.Regular) ' Crea la fuente
        Dim FteNormal_10 As Font = New Font("Arial", 10, FontStyle.Regular) ' Crea la fuente

        Dim Xpos = 10 ' Columna
        Dim Ypos = 30 ' Fila
        Dim Contador As Integer = 1
        Dim Con As Integer = 1
        Dim Dig As Integer = 50
        Dim Cm As Integer = 1
        'e.Graphics.DrawString(_Texto, _Fte_Usar, drawBrush, _Columna_X, _Fila_Y)

        For x As Integer = 1 To 1000
            If Con < 50 Then

                If Contador = 5 Or Contador = 10 Then

                    Dim y_ As Integer = 40

                    If Contador = 5 Then y_ = 35

                    ' e.Graphics.DrawString(_Texto, _Fte_Usar, drawBrush, _Columna_X, _Fila_Y)

                    e.Graphics.DrawString("|", FteNormal_3, Brushes.Green, x, 30)
                    e.Graphics.DrawString(Contador, FteNormal_3, Brushes.Green, x, y_)
                    e.Graphics.DrawString("|", FteNormal_3, Brushes.Green, x, 200)
                    e.Graphics.DrawString(Contador, FteNormal_3, Brushes.Green, x, 200 - y_ + 20)
                    e.Graphics.DrawString("|", FteNormal_3, Brushes.Green, x, 400)
                    e.Graphics.DrawString(Contador, FteNormal_3, Brushes.Green, x, 400 - y_ + 20)
                    e.Graphics.DrawString("|", FteNormal_3, Brushes.Green, x, 600)
                    e.Graphics.DrawString(Contador, FteNormal_3, Brushes.Green, x, 600 - y_ + 20)
                    e.Graphics.DrawString("|", FteNormal_3, Brushes.Green, x, 800)
                    e.Graphics.DrawString(Contador, FteNormal_3, Brushes.Green, x, 800 - y_ + 20)
                    Cm += 5
                    If Contador = 10 Then
                        Contador = 0
                    End If
                Else
                    e.Graphics.DrawString(" ", FteNormal_10, Brushes.Green, x, 20)
                    e.Graphics.DrawString(" ", FteNormal_10, Brushes.Green, x, 210)
                    e.Graphics.DrawString(" ", FteNormal_10, Brushes.Green, x, 410)
                    e.Graphics.DrawString(" ", FteNormal_10, Brushes.Green, x, 610)
                    e.Graphics.DrawString(" ", FteNormal_10, Brushes.Green, x, 810)
                    'Cm = 5
                End If
            Else
                e.Graphics.DrawString(Dig, FteNormal_8, Brushes.Green, x, 20)
                e.Graphics.DrawString(Dig, FteNormal_8, Brushes.Green, x, 210)
                e.Graphics.DrawString(Dig, FteNormal_8, Brushes.Green, x, 410)
                e.Graphics.DrawString(Dig, FteNormal_8, Brushes.Green, x, 610)
                e.Graphics.DrawString(Dig, FteNormal_8, Brushes.Green, x, 810)

                e.Graphics.DrawString("|", FteNormal_10, Brushes.Green, x, 30)
                e.Graphics.DrawString("|", FteNormal_10, Brushes.Green, x, 200)
                e.Graphics.DrawString("|", FteNormal_10, Brushes.Green, x, 400)
                e.Graphics.DrawString("|", FteNormal_10, Brushes.Green, x, 600)
                e.Graphics.DrawString("|", FteNormal_10, Brushes.Green, x, 800)

                Dig += 50
                Con = 1
                Contador = 0
            End If

            Con += 1
            Contador += 1
        Next

        Contador = 1
        Con = 1
        Dig = 50

        e.Graphics.DrawString("__", FteNormal_3, Brushes.Green, 25, 1)

        For y As Integer = 1 To 1000
            If Con < 50 Then
                If Contador = 5 Then
                    e.Graphics.DrawString("______ " & y, FteNormal_4, Brushes.Green, 25, y)
                    e.Graphics.DrawString("__", FteNormal_3, Brushes.Green, 25, y)
                    e.Graphics.DrawString(y & " ______", FteNormal_4, Brushes.Green, 580, y)
                    e.Graphics.DrawString("__", FteNormal_3, Brushes.Green, 590, y)
                    Contador = 0
                Else
                    e.Graphics.DrawString(" ", FteNormal_10, Brushes.Green, 25, y)
                    e.Graphics.DrawString(" ", FteNormal_10, Brushes.Green, 590, y)
                End If
            Else
                e.Graphics.DrawString(Dig, FteNormal_8, Brushes.Green, 8, y)
                e.Graphics.DrawString(Dig, FteNormal_8, Brushes.Green, 573, y)

                e.Graphics.DrawString("____________", FteNormal_3, Brushes.Green, 8, y)
                e.Graphics.DrawString("____________", FteNormal_3, Brushes.Green, 590, y)
                Dig += 50
                Con = 1
                Contador = 0
            End If
            Con += 1
            Contador += 1
        Next


    End Sub

    Sub Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle As DataTable,
                                               e As PrintPageEventArgs,
                                               _yPos As Integer,
                                               _xPos As Integer,
                                               _Fuente As Font,
                                               _DrawBrush As Brush,
                                               _Neto As Boolean,
                                               _Incluye_Linea As Boolean,
                                               _Solo_Descripcion As Boolean,
                                               _Imp_Observacion As Boolean,
                                               _CodAlternativo As Boolean,
                                               _ImpSucursal As Boolean,
                                               _ImpBodega As Boolean)


        Dim _Codigo As String
        Dim _Descripcion As String
        Dim _Cantidades As String
        Dim _Cantidad As String
        Dim _Precio As String
        Dim _DsctoLinea
        Dim _Total As String
        Dim _Descuento As String
        Dim _TotalDescuentoDocumentos As String
        Dim _SubTotalDocumentos As String
        Dim _TotalDocumentos As Double
        Dim _Sucursal As String
        Dim _Bodega As String

        Dim _Size = _Fuente.Size

        Dim Contador = 1

        Dim _Udtrpr As Integer
        Dim _Ud0xpr As String

        Dim _Campo_Precio, _Campo_Descuento, _Campo_Total As String

        If _Neto Then
            _Campo_Precio = "PPPRNE"
            _Campo_Descuento = "VADTNELI"
            _Campo_Total = "VANELI"
        Else
            _Campo_Precio = "PPPRBR"
            _Campo_Descuento = "VADTBRLI"
            _Campo_Total = "VABRLI"
        End If

        ' imprimimos la cadena
        For Each Fila As DataRow In _Tbl_Detalle.Rows

            Dim Ttipo As String = Trim(Fila.Item("TICT"))

            If String.IsNullOrEmpty(Ttipo) Then

                _Udtrpr = Fila.Item("UDTRPR")
                _Codigo = Fila.Item("KOPR")
                _Sucursal = Fila.Item("SULIDO")
                _Bodega = Fila.Item("BOSULIDO")

                _Ud0xpr = Fila.Item("UD0" & _Udtrpr & "PR")

                If _Solo_Descripcion Then
                    _Descripcion = Mid(Fila.Item("NOKOPR_Edd"), 1, 40) ' & vbCrLf & _
                Else
                    _Descripcion = Mid(Fila.Item("NOKOPR_Edd"), 1, 35) ' & vbCrLf & _
                End If


                _Cantidad = Math.Round(De_Txt_a_Num_01(Fila.Item("CAPRCO" & _Udtrpr), 0), 0)
                _Precio = Fila.Item(_Campo_Precio)

                _Descuento = De_Txt_a_Num_01(Fila.Item(_Campo_Descuento), 0)
                _TotalDescuentoDocumentos += _Descuento

                If _Descuento > 0 Then
                    _DsctoLinea = " - " & FormatCurrency(_Descuento, 0)
                Else
                    _DsctoLinea = ""
                End If

                _Total = FormatCurrency(De_Txt_a_Num_01(Fila.Item(_Campo_Total), 0), 0)
                _TotalDocumentos += _Total

                _Cantidades = _Cantidad & " X " & _Precio & _DsctoLinea & " = " & _Total

                'FteCourier_New_C_6

                Dim _Cantidad_Imp = FormatNumber(_Cantidad, 0)
                _Cantidad_Imp = Rellenar(_Cantidad_Imp, 4, " ", False)

                Dim _Precio_Imp = FormatNumber(_Precio, 0)
                _Precio_Imp = Rellenar(_Precio_Imp, 8, " ", False)

                Dim _DsctoLinea_Imp = FormatNumber(_Descuento * -1, 0)
                _DsctoLinea_Imp = Rellenar(_DsctoLinea_Imp, 6, " ", False)

                Dim _Total_Imp = FormatNumber(_Total, 0)
                _Total_Imp = Rellenar(_Total_Imp, 9, " ", False)

                If _Solo_Descripcion Then
                    e.Graphics.DrawString(_Descripcion, _Fuente, _DrawBrush, _xPos, _yPos)
                Else

                    Dim _CodigoAlt = Trim(Mid(Fila.Item("ALTERNAT").ToString, 1, 40))

                    If _ImpSucursal Then _Codigo += "  " & _Sucursal
                    If _ImpBodega Then _Codigo += "  " & _Bodega & "  " & _Ud0xpr

                    e.Graphics.DrawString(_Codigo, _Fuente, _DrawBrush, _xPos, _yPos)

                    If _CodAlternativo Then
                        e.Graphics.DrawString(_CodigoAlt, _Fuente, Brushes.Black, _xPos + 140, _yPos)
                    End If

                    _yPos += _Size + 2
                    e.Graphics.DrawString(_Descripcion, _Fuente, _DrawBrush, _xPos, _yPos)

                End If

                If _Imp_Observacion Then

                    Dim _Observa As String = Trim(Mid(Fila.Item("OBSERVA").ToString, 1, 40))

                    If Not String.IsNullOrEmpty(_Observa) Then
                        _yPos += _Size + 2
                        e.Graphics.DrawString(_Observa, _Fuente, Brushes.Black, _xPos, _yPos)
                    End If

                End If

                _yPos += _Size + 2

                e.Graphics.DrawString(_Cantidad_Imp & " X ", _Fuente, _DrawBrush, _xPos, _yPos)
                e.Graphics.DrawString(_Precio_Imp, _Fuente, _DrawBrush, _xPos + 45, _yPos)
                e.Graphics.DrawString(_DsctoLinea_Imp, _Fuente, _DrawBrush, _xPos + 140, _yPos)
                e.Graphics.DrawString(_Total_Imp, _Fuente, _DrawBrush, _xPos + 200, _yPos)

                If _Incluye_Linea Then
                    If _Size > 6 Then _yPos += 2
                    e.Graphics.DrawString("_____________________________________________", _DtFont, Brushes.Black, _xPos, _yPos)
                End If

                _yPos += (_Size * 2) + 2

            ElseIf Ttipo = "D" Then

                _Descripcion = Mid(Fila.Item("Descripcion").ToString, 1, 40) ' & vbCrLf & _
                e.Graphics.DrawString(_Descripcion, _Fuente, _DrawBrush, _xPos, _yPos + 5)
                ' _yPos += 5
                ' e.Graphics.DrawString("=============================================", _Fuente, _DrawBrush, 0, _yPos)
                _yPos += _Size + 2

                If _Incluye_Linea Then
                    ' _yPos += 1
                    e.Graphics.DrawString("_____________________________________________", _DtFont, Brushes.Black, _xPos, _yPos)
                End If

                _yPos += (_Size * 2) + 3

            End If

            Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc + 15)

            ' Asignamos la impresora seleccionada
            'printDoc.PrinterSettings = _PrtSettings
            ' Asignamos el tamaño personalizado de papel
            printDoc.DefaultPageSettings.PaperSize = _TamañoPersonal

        Next
        '  End If
        '_yPos += 5
        'e.Graphics.DrawString("=============================================", _Fuente, _DrawBrush, 0, _yPos)
        '_yPos += 5

        _Fila_FinDetalle = _yPos

    End Sub

    Sub Sb_Funcion_Imprimir_Detalle_Tipo_Vale_(_Tbl_Detalle As DataTable,
                                               e As PrintPageEventArgs,
                                               _yPos As Integer,
                                               _xPos As Integer,
                                               _Fuente As Font,
                                               _DrawBrush As Brush,
                                               _Incluye_Linea As Boolean,
                                               _Incluir_NomCampo As Boolean)


        Dim _Codigo As String
        Dim _Descripcion As String
        Dim _Cantidades As String
        Dim _Cantidad As String
        Dim _Precio As String
        Dim _DsctoLinea
        Dim _Total As String
        Dim _Descuento As String
        Dim _TotalDescuentoDocumentos As String
        Dim _TotalDocumentos As Double
        Dim _Sucursal As String
        Dim _Bodega As String

        Dim _Size = _Fuente.Size

        Dim Contador = 1

        Dim _Udtrpr As Integer
        Dim _Ud0xpr As String

        Dim _Campo_Precio, _Campo_Descuento, _Campo_Total As String

        ' imprimimos la cadena
        For Each Fila As DataRow In _Tbl_Detalle.Rows

            Dim Ttipo As String = Trim(Fila.Item("TICT"))

            If String.IsNullOrEmpty(Ttipo) Then

                _Udtrpr = Fila.Item("UDTRPR")
                _Codigo = Fila.Item("KOPR")
                _Sucursal = Fila.Item("SULIDO")
                _Bodega = Fila.Item("BOSULIDO")

                _Ud0xpr = Fila.Item("UD0" & _Udtrpr & "PR")

                _Descripcion = Mid(Fila.Item("NOKOPR_Edd"), 1, 35) ' & vbCrLf & _


                _Cantidad = Math.Round(De_Txt_a_Num_01(Fila.Item("CAPRCO" & _Udtrpr), 0), 0)

                Dim _Cantidad_Imp = FormatNumber(_Cantidad, 0)
                _Cantidad_Imp = Rellenar(_Cantidad_Imp, 4, " ", False)

                Dim _Precio_Imp = FormatNumber(_Precio, 0)
                _Precio_Imp = Rellenar(_Precio_Imp, 8, " ", False)

                Dim _CodigoAlt = Trim(Mid(Fila.Item("ALTERNAT").ToString, 1, 40))

                If _Incluir_NomCampo Then

                    Dim _Fte_Campo As Font = New Font(_Fuente.Name, _Fuente.Size, FontStyle.Bold)

                    e.Graphics.DrawString("Código  : ", _Fte_Campo, _DrawBrush, _xPos, _yPos)
                    e.Graphics.DrawString(_Codigo, _Fuente, _DrawBrush, _xPos + 100, _yPos)
                    _yPos += _Size + 3
                    e.Graphics.DrawString("Ítems   : " & numero_(Contador, 2), _Fte_Campo, _DrawBrush, _xPos, _yPos)
                    _yPos += _Size + 3
                    e.Graphics.DrawString(Mid(_Descripcion, 1, 40), _Fuente, _DrawBrush, _xPos, _yPos)
                    _yPos += _Size + 3
                    If Not String.IsNullOrEmpty(Mid(_Descripcion, 41, 25).ToString.Trim) Then
                        e.Graphics.DrawString(Mid(_Descripcion, 41, 25), _Fuente, _DrawBrush, _xPos, _yPos)
                        _yPos += _Size + 3
                    End If
                    e.Graphics.DrawString("Cantidad: ", _Fte_Campo, _DrawBrush, _xPos, _yPos)
                    e.Graphics.DrawString(_Cantidad_Imp, _Fuente, _DrawBrush, _xPos + 100, _yPos)

                Else
                    e.Graphics.DrawString(_Codigo, _Fuente, _DrawBrush, _xPos, _yPos)
                    _yPos += _Size + 3
                    e.Graphics.DrawString(Mid(_Descripcion, 1, 40), _Fuente, _DrawBrush, _xPos, _yPos)
                    _yPos += _Size + 3
                    e.Graphics.DrawString(Mid(_Descripcion, 41, 40), _Fuente, _DrawBrush, _xPos, _yPos)
                    _yPos += _Size + 3
                    e.Graphics.DrawString(_Cantidad_Imp, _Fuente, _DrawBrush, _xPos, _yPos)
                End If

                If _Incluye_Linea Then
                    If _Size > 6 Then _yPos += 2
                    e.Graphics.DrawString("_____________________________________________", _DtFont, Brushes.Black, _xPos, _yPos)
                End If

                _yPos += (_Size * 2) + 2

            ElseIf Ttipo = "D" Then

                _Descripcion = Mid(Fila.Item("Descripcion").ToString, 1, 40) ' & vbCrLf & _
                e.Graphics.DrawString(_Descripcion, _Fuente, _DrawBrush, _xPos, _yPos + 5)
                ' _yPos += 5
                ' e.Graphics.DrawString("=============================================", _Fuente, _DrawBrush, 0, _yPos)
                _yPos += _Size + 2

                If _Incluye_Linea Then
                    ' _yPos += 1
                    e.Graphics.DrawString("_____________________________________________", _DtFont, Brushes.Black, _xPos, _yPos)
                End If

                _yPos += (_Size * 2) + 3

            End If

            Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc + 15)

            ' Asignamos la impresora seleccionada
            'printDoc.PrinterSettings = _PrtSettings
            ' Asignamos el tamaño personalizado de papel
            printDoc.DefaultPageSettings.PaperSize = _TamañoPersonal

        Next
        '  End If
        '_yPos += 5
        'e.Graphics.DrawString("=============================================", _Fuente, _DrawBrush, 0, _yPos)
        '_yPos += 5

        _Fila_FinDetalle = _yPos

    End Sub
    Sub Sb_Funcion_Imprimir_Detalle_Picking_Tipo_Vale(_Tbl_Detalle As DataTable,
                                                       e As PrintPageEventArgs,
                                                       _yPos As Integer,
                                                       _xPos As Integer,
                                                       _Fuente As Font,
                                                       _DrawBrush As Brush,
                                                       _Neto As Boolean,
                                                       _Incluye_Linea As Boolean,
                                                       _Solo_Descripcion As Boolean,
                                                       _MostrarStockTeorico As Boolean)


        Dim _Codigo As String
        Dim _Descripcion As String
        Dim _Cantidades As String
        Dim _Cantidad As String
        Dim _Precio As String
        Dim _DsctoLinea
        Dim _Total As String
        Dim _Descuento As String
        Dim _TotalDescuentoDocumentos As String
        Dim _SubTotalDocumentos As String
        Dim _TotalDocumentos As Double

        Dim _Size = _Fuente.Size

        Dim Contador = 1

        Dim _Udtrpr As Integer
        Dim _Ud As String
        Dim _Ubicacion As String
        Dim _Stock As String

        ' imprimimos la cadena
        For Each Fila As DataRow In _Tbl_Detalle.Rows

            Dim Ttipo As String = Trim(Fila.Item("TICT"))

            If String.IsNullOrEmpty(Ttipo) Then

                _Codigo = Trim(Mid(Fila.Item("KOPR").ToString, 1, 40))
                _Descripcion = Trim(Mid(Fila.Item("NOKOPR_Edd").ToString, 1, 40))
                _Cantidad = Mid(Fila.Item("Bk_Cant_Trans").ToString, 1, 40)
                _Ud = Mid(Fila.Item("Bk_Un_Trans").ToString, 1, 40)
                _Ubicacion = Trim(Mid(Fila.Item("UBICACION").ToString, 1, 40))

                _Udtrpr = Fila.Item("UDTRPR")

                Dim _StockFisico As Double = Fila.Item("StockUd" & _Udtrpr)
                Dim _StockDevengado As Double = Fila.Item("StockdvUd" & _Udtrpr)
                Dim _StockComprometido As Double = Fila.Item("StockncUd" & _Udtrpr)

                Dim _StockTeorico As Double = _StockFisico

                If _MostrarStockTeorico Then
                    _StockTeorico = _StockFisico - (_StockDevengado + _StockComprometido)
                End If

                _Stock = FormatNumber(_StockTeorico, 0)
                '_Stock = Mid(Fila.Item("STOCK").ToString, 1, 40)

                e.Graphics.DrawString(_Codigo, _Fuente, _DrawBrush, _xPos, _yPos)
                _yPos += _Size + 2
                e.Graphics.DrawString(_Descripcion, _Fuente, _DrawBrush, _xPos, _yPos)
                _yPos += _Size + 2

                e.Graphics.DrawString(_Ud, _Fuente, _DrawBrush, _xPos, _yPos)
                e.Graphics.DrawString(_Cantidad, _Fuente, _DrawBrush, _xPos + 40, _yPos)
                e.Graphics.DrawString(_Stock, _Fuente, _DrawBrush, _xPos + 100, _yPos)
                e.Graphics.DrawString(_Ubicacion, _Fuente, _DrawBrush, _xPos + 160, _yPos)
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(_xPos + 270, _yPos, 10, 12))
                _yPos += 1
                e.Graphics.DrawString("_____________________________________________", _Fuente, _DrawBrush, _xPos, _yPos)

                _yPos += (_Size * 2) + 3

            End If

        Next

        _Fila_FinDetalle = _yPos

    End Sub

    Function Fx_Timbre_Electronico(_Idmaeedo As Integer,
                                   _Tido As String,
                                   _Nudo As String) As PictureBox


        Dim _Timbre As String

        Dim _Archivo_Xml As String
        Dim _Dset_DTE As New DataSet

        Dim _bm As Bitmap = Nothing
        Dim _CodBarras As New PictureBox

        Dim _Dir As String = AppPath() & "\Data\" & RutEmpresa & "\Temp" '\" & _Nudo & ".xml"
        _Archivo_Xml = _Sql.Fx_Trae_Dato("FMAEDTE", "XML", "IDMAEEDO = " & _Idmaeedo)


        If String.IsNullOrEmpty(_Archivo_Xml) Then
            _Timbre_Falso = True
            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo) ', _Dir)
            _Timbre = _Class_DTE.Fx_Crear_Timbre_Electronico
        Else

            Dim _Dte As XDocument
            Dim _Nodo_Firma As XElement

            If Not Directory.Exists(_Dir) Then
                System.IO.Directory.CreateDirectory(_Dir)
            End If

            Dim _Nombre_Archivo As String

            If Not String.IsNullOrEmpty(_Archivo_Xml) Then

                _Nombre_Archivo = _Tido & "-" & _Nudo

                _Dir = _Dir & "\" & _Nombre_Archivo '& ".xml"

                Dim oSW As New System.IO.StreamWriter(_Dir)

                oSW.WriteLine(_Archivo_Xml)
                oSW.Close()

                'Dim _Dte As New XmlDocument()
                '_Dte.PreserveWhitespace = True
                '_Dte.LoadXml(_Archivo_Xml)

                _Dte = XDocument.Load(_Dir, LoadOptions.None) ' LoadOptions.PreserveWhitespace)
                _Nodo_Firma = _Dte.XPathSelectElement("DTE/Documento/TED")

                If _Nodo_Firma IsNot Nothing Then
                    _Timbre = _Nodo_Firma.ToString
                Else
                    _Timbre_Falso = True
                End If

                _Timbre = _Timbre.Replace(vbCrLf, "")
                _Timbre = _Timbre.Replace("      ", "")
                _Timbre = _Timbre.Replace("     ", "")
                _Timbre = _Timbre.Replace("    ", "")
                _Timbre = _Timbre.Replace("   ", "")
                _Timbre = _Timbre.Replace("  ", "")
                '_Timbre = _Timbre.Replace(" ", "")

                File.Delete(_Dir)
                '_Dset_DTE.ReadXml(_Dir)

            End If

            'Dim Tbl_Encabezado = _Dset_DTE.Tables("Encabezado")
            'Dim _Documento_Id As Integer = Tbl_Encabezado.Rows(0).Item("Documento_Id")

            '********************************************** TIMBRE ELECTRONICO **************************************************

            'If _Timbre_Falso Then

            'Else


            'Dim _TED = _Dset_DTE.Tables("TED")
            'Dim _DD = _Dset_DTE.Tables("DD")
            'Dim _CAF = _Dset_DTE.Tables("CAF")
            'Dim _DA = _Dset_DTE.Tables("DA")
            'Dim _RNG = _Dset_DTE.Tables("RNG")
            'Dim _RSAPK = _Dset_DTE.Tables("RSAPK")
            'Dim _FRMA = _Dset_DTE.Tables("FRMA")

            '_Timbre = "<TED version=" & Chr(34) & "1.0" & Chr(34) & ">" & vbCrLf & _
            '          "<DD><RE>" & _DD.Rows(_Documento_Id).Item("RE") & "</RE><TD>" & _DD.Rows(_Documento_Id).Item("TD") & "</TD><F>" & _DD.Rows(_Documento_Id).Item("F") & _
            '          "</F><FE>" & _DD.Rows(_Documento_Id).Item("FE") & "</FE><RR>" & _DD.Rows(_Documento_Id).Item("RR") & "</RR><RSR>" & _DD.Rows(_Documento_Id).Item("RSR") & "</RSR>" & _
            '          "<MNT>" & _DD.Rows(_Documento_Id).Item("MNT") & "</MNT><IT1>" & _DD.Rows(_Documento_Id).Item("IT1") & "</IT1>" & _
            '          "<CAF version=" & Chr(34) & _CAF.Rows(_Documento_Id).Item("version") & Chr(34) & "><DA>" & _
            '          "<RE>" & _DA.Rows(_Documento_Id).Item("RE") & "</RE><RS>" & _DA.Rows(_Documento_Id).Item("RS") & "</RS>" & _
            '          "<TD>" & _DA.Rows(_Documento_Id).Item("TD") & "</TD><RNG><D>" & _RNG.Rows(_Documento_Id).Item("D") & "</D><H>" & _RNG.Rows(_Documento_Id).Item("H") & "</H>" & _
            '          "</RNG><FA>" & _DA.Rows(_Documento_Id).Item("FA") & "</FA>" & _
            '          "<RSAPK><M>" & _RSAPK.Rows(_Documento_Id).Item("M") & "</M><E>" & _RSAPK.Rows(_Documento_Id).Item("E") & "</E></RSAPK>" & _
            '          "<IDK>" & _DA.Rows(_Documento_Id).Item("IDK") & "</IDK></DA>" & _
            '          "<FRMA algoritmo=" & Chr(34) & _FRMA.Rows(_Documento_Id).Item("algoritmo") & Chr(34) & _
            '          ">" & _FRMA.Rows(_Documento_Id).Item("FRMA_Text") & "</FRMA></CAF><TSTED>" & _DD.Rows(_Documento_Id).Item("TSTED") & "</TSTED></DD>" & vbCrLf & _
            '          "<FRMT algoritmo=" & Chr(34) & "SHA1withRSA" & Chr(34) & "></FRMT>" & vbCrLf & _
            '          "</TED>"

            'End If

        End If

        '_Timbre_Falso = False
        'Dim iType As BarCode.Code128SubTypes = _
        ' DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
        _bm = BarCode.PDF417(_Timbre, 1, 8)

        'Image as XImage = XImage.FromFile(jpegSamplePath)
        'Dim x As Double = ((250 - Image.PixelWidth * 72 / Image.HorizontalResolution) / 2)
        'GFX.DrawImage(Image, x, 0)

        If Not IsNothing(_bm) Then
            _CodBarras.Image = _bm
        End If

        Return _CodBarras


    End Function

    Function Fx_Timbre_Electronico_Hefesto(_Idmaeedo As Integer,
                                           _Tido As String,
                                           _Nudo As String) As PictureBox


        Dim _Timbre As String

        Dim _Archivo_Xml As String
        Dim _Dset_DTE As New DataSet

        Dim _bm As Bitmap = Nothing
        Dim _CodBarras As New PictureBox

        Dim _Dir As String = AppPath() & "\Data\" & RutEmpresa & "\Temp"
        _Archivo_Xml = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "Xml", "Idmaeedo = " & _Idmaeedo)

        If String.IsNullOrEmpty(_Archivo_Xml) Then

            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
            _Timbre = _Class_DTE.Fx_Crear_Timbre_Electronico
            _Timbre_Falso = True

        Else

            Dim _Dte As XDocument
            Dim _Nodo_Firma As XElement

            If Not Directory.Exists(_Dir) Then
                System.IO.Directory.CreateDirectory(_Dir)
            End If

            Dim _Nombre_Archivo As String

            If Not String.IsNullOrEmpty(_Archivo_Xml) Then

                _Nombre_Archivo = _Tido & "-" & _Nudo

                _Dir = _Dir & "\" & _Nombre_Archivo

                Dim oSW As New System.IO.StreamWriter(_Dir)

                oSW.WriteLine(_Archivo_Xml)
                oSW.Close()

                _Dte = XDocument.Load(_Dir, LoadOptions.None)

                Dim ns = _Dte.Root.GetDefaultNamespace
                Dim _nsManager = New XmlNamespaceManager(New NameTable())

                _nsManager.AddNamespace("d", "http://www.sii.cl/SiiDte")
                _Nodo_Firma = _Dte.XPathSelectElement("/d:DTE/d:Documento/d:TED", _nsManager)

                If IsNothing(_Nodo_Firma) Then

                    Try
                        _Nodo_Firma = _Dte.XPathSelectElement("DTE/Documento/TED")
                    Catch ex As Exception
                        Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
                        _Timbre = _Class_DTE.Fx_Crear_Timbre_Electronico
                        _Timbre_Falso = True
                    End Try

                End If

                If _Nodo_Firma IsNot Nothing Then
                    _Timbre = _Nodo_Firma.ToString
                Else
                    _Timbre_Falso = True
                End If

                _Timbre = _Timbre.Replace(vbCrLf, "")
                _Timbre = _Timbre.Replace("      ", "")
                _Timbre = _Timbre.Replace("     ", "")
                _Timbre = _Timbre.Replace("    ", "")
                _Timbre = _Timbre.Replace("   ", "")
                _Timbre = _Timbre.Replace("  ", "")

                File.Delete(_Dir)

            End If

        End If

        _bm = BarCode.PDF417(_Timbre, 1, 8)

        If Not IsNothing(_bm) Then
            _CodBarras.Image = _bm
        End If

        Return _CodBarras

    End Function

End Class
