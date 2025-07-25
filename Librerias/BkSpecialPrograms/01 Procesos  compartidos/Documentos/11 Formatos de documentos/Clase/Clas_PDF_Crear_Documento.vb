﻿Imports PdfSharp
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing
Imports System.Xml.XPath
Imports System.IO
Imports Gma.QrCodeNet.Encoding.Windows.Forms

Public Class Clas_PDF_Crear_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Directorio_Destino As String
    Dim _Nombre_Archivo As String

    Dim _IdMaeedo As Integer

    Dim _RowEncabezado As DataRow
    Dim _TblDetalle As DataTable
    Dim _TblDetalle_Agrupado As DataTable
    Dim _TblReferencias As DataTable

    Dim _Fila_InicioDetalle As Double
    Dim _Fila_FinDetalle As Double

    Dim _TblEncForm As DataTable
    Dim _Tbl_Fx_Encabezado As DataTable  ' Formato del detalle
    Dim _Tbl_Fx_Detalle As DataTable  ' Formato del detalle

    Dim _TipoDoc As String
    Dim _SubTido As String
    Dim _NombreFormato As String

    Dim _Error As String

    Dim _X As Integer
    Dim _Y As Integer

    Dim _Imprimir_Cedible As Boolean

    Dim _QrCodeImgControl As New QrCodeImgControl
    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Public ReadOnly Property Pro_Full_Path_Archivo_PDF() As String
        Get
            Return _Directorio_Destino '& "\" & _Nombre_Archivo & ".pdf"
        End Get
    End Property

    Public Property Pro_Nombre_Archivo As String
        Get
            Return _Nombre_Archivo
        End Get
        Set(value As String)
            _Nombre_Archivo = value
        End Set
    End Property

    Public Sub New(Idmaeedo As Integer,
                   TipoDoc As String,
                   NombreFormato As String,
                   NombreDocumento As String,
                   Directorio_Destino As String,
                   Nombre_Archivo As String,
                   Imprimir_Cedible As Boolean)
        Try

            _Error = String.Empty
            _Imprimir_Cedible = Imprimir_Cedible

            _Directorio_Destino = Directorio_Destino
            _Nombre_Archivo = Replace(Nombre_Archivo, ".pdf", "")

            _IdMaeedo = Idmaeedo
            _TipoDoc = TipoDoc
            _SubTido = _Sql.Fx_Trae_Dato("MAEEDO", "SUBTIDO", "IDMAEEDO = " & _IdMaeedo)
            _NombreFormato = NombreFormato

            ' Llena Formato del Encabezado
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And NombreFormato = '" & _NombreFormato & "' And Subtido = '" & _SubTido & "'"
            _TblEncForm = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Not CBool(_TblEncForm.Rows.Count) Then
                Throw New System.Exception("No existe el formato de documento: " & _NombreFormato)
            End If

            Dim _Es_Picking = _TblEncForm.Rows(0).Item("Es_Picking")

            Dim _Condicion_Extra_Maeddo As String
            Dim _Filtro_Productos As String
            Dim _Orden_Detalle As String

            If _Es_Picking Then
                _Condicion_Extra_Maeddo = "And SULIDO = '" & Mod_Sucursal & "' And BOSULIDO = '" & Mod_Bodega & "' Order By UBICACION"
                _Orden_Detalle = "Order By UBICACION"
            Else
                _Condicion_Extra_Maeddo = "Order By IDMAEDDO"
                _Orden_Detalle = "Order By IDMAEDDO"
            End If

            Dim _Detalle_Doc_Incluye = _TblEncForm.Rows(0).Item("Detalle_Doc_Incluye")

            If _Detalle_Doc_Incluye = "SP" Then _Filtro_Productos = "Where TICT = ''" '_Imprimir_Fila = (_Tict = "")
            If _Detalle_Doc_Incluye = "PD" Then _Filtro_Productos = "Where TICT In ('','D')" '_Imprimir_Fila = (_Tict = "D")
            If _Detalle_Doc_Incluye = "PR" Then _Filtro_Productos = "Where TICT In ('','R')" '_Imprimir_Fila = (_Tict = "R")
            If _Detalle_Doc_Incluye = "TD" Then _Filtro_Productos = String.Empty ' _Imprimir_Fila = True

            Consulta_sql = My.Resources.Recursos_Formato_Documento.SQLQuery_Traer_Documento_Para_Imprimir
            Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _IdMaeedo)
            Consulta_sql = Replace(Consulta_sql, "#Condicion_Extra_Maeddo#", _Condicion_Extra_Maeddo)
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", _Filtro_Productos)
            Consulta_sql = Replace(Consulta_sql, "#Orden_Detalle#", _Orden_Detalle)


            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            _RowEncabezado = _Ds.Tables(0).Rows(0)
            _TblDetalle = _Ds.Tables(1)
            _TblReferencias = _Ds.Tables(2)
            _TblDetalle_Agrupado = _Ds.Tables(3)

            _RowEncabezado = Fx_New_Inserta_Funciones_Bk_En_Encabezado(_RowEncabezado)

            ' Llena Formato del Encabezado
            Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                           "Where TipoDoc = '" & TipoDoc & "' and NombreFormato = '" & NombreFormato & "'"
            _TblEncForm = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Sql_CmSQL_Personalizada = String.Empty

            If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Format_Fx", "SQL_Personalizada") Then
                _Sql_CmSQL_Personalizada = ",Isnull((Select SQL_Personalizada From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
                                           "Where Nombre_Funcion = Funcion),0) As SQL_Personalizada"
            Else
                _Sql_CmSQL_Personalizada = ",Cast(0 As Bit) As SQL_Personalizada"
            End If

            'Consulta_sql = "SELECT *," &
            '                             "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                             "Where Nombre_Funcion = Funcion),0) As Funcion_Bk," & vbCrLf &
            '                             "Isnull((Select Formato From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                             "Where Nombre_Funcion = Funcion),0) As Formato_Fx," & vbCrLf &
            '                             "Isnull((Select Campo From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                             "Where Nombre_Funcion = Funcion),0) As Campo," & vbCrLf &
            '                             "Isnull((Select Codigo_De_Barras From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                             "Where Nombre_Funcion = Funcion),0) As Codigo_De_Barras," & vbCrLf &
            '                             "Isnull((Select Es_Descuento From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                             "Where Nombre_Funcion = Funcion),0) As Es_Descuento," & vbCrLf &
            '                             "Isnull((Select SqlQuery From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                             "Where Nombre_Funcion = Funcion),'') As SqlQuery" & vbCrLf &
            '                             _Sql_CmSQL_Personalizada &
            '                             vbCrLf &
            '                             "FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
            '                             "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "' And Seccion In ('E','P')"

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
                    Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _SubTido & "' And NombreFormato = '" & _NombreFormato & "' And Fdt.Seccion In ('E','P')"


            _Tbl_Fx_Encabezado = _Sql.Fx_Get_DataTable(Consulta_sql)

            ' Llena formato del detalle
            'Consulta_sql = "SELECT *," &
            '                  "Isnull((Select Funcion_Bk From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                  "Where Nombre_Funcion = Funcion),0) As Funcion_Bk," & vbCrLf &
            '                  "Isnull((Select Formato From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                  "Where Nombre_Funcion = Funcion),0) As Formato_Fx," & vbCrLf &
            '                  "Isnull((Select Campo From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                  "Where Nombre_Funcion = Funcion),0) As Campo," & vbCrLf &
            '                  "Isnull((Select Codigo_De_Barras From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                  "Where Nombre_Funcion = Funcion),0) As Codigo_De_Barras," & vbCrLf &
            '                  "Isnull((Select Es_Descuento From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                  "Where Nombre_Funcion = Funcion),0) As Es_Descuento," & vbCrLf &
            '                  "Isnull((Select SqlQuery From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
            '                  "Where Nombre_Funcion = Funcion),'') As SqlQuery" & vbCrLf &
            '                  _Sql_CmSQL_Personalizada &
            '                   vbCrLf &
            '                  "FROM " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
            '                  "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "' And Seccion = 'D'" & vbCrLf &
            '                  "Order by Orden_Detalle"
            '_Tbl_Fx_Detalle = _Sql.Fx_Get_Tablas(Consulta_sql)


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
                    Where TipoDoc = '" & _TipoDoc & "' And Subtido = '" & _SubTido & "' And NombreFormato = '" & _NombreFormato & "' And Fdt.Seccion = 'D'" & vbCrLf &
                        "Order by Fdt.Orden_Detalle"

            _Tbl_Fx_Detalle = _Sql.Fx_Get_DataTable(Consulta_sql)

            'If _TipoDoc.Contains("GRP") Or _TipoDoc.Contains("GDP") Then

            '    Consulta_sql = "Declare @Id_Ot Int 

            '                Set @Id_Ot = (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Idmaeedo_" & _TipoDoc & "_PRE = " & _IdDoc & ")

            '                Select ZEnc.Id_Ot, ZEnc.Nro_Ot,Empresa,ZEnc.Sucursal,ZEnc.Bodega,ZEnc.CodEntidad,ZEnc.SucEntidad,ZEnc.Rten,ZEnc.Rut, 
            '                NOKOEN As Cliente,ZEnc.Fecha_Ingreso,ZEnc.Fecha_Compromiso,ZEnc.Fecha_Entrega,ZEnc.Fecha_Cierre,ZEnc.CodEstado, 
            '                IsNull(ZCarac1.NombreTabla,'') As 'Estado',ZEnc.CodMaquina,ZEnc.CodMarca,ZEnc.CodModelo,ZEnc.CodCategoria,ZEnc.NroSerie,ZEnc.Chk_Serv_Domicilio,
            '             ZEnc.Pais,ZEnc.Ciudad,ZEnc.Comuna,ZEnc.Direccion,ZEnc.Nombre_Contacto,ZEnc.Telefono_Contacto,ZEnc.Email_Contacto,ZEnc.Chk_Serv_Reparacion_Stock,
            '             ZEnc.Chk_Serv_Mantenimiento_Correctivo,ZEnc.Chk_Serv_Presupuesto_Pre_Aprobado,ZEnc.Chk_Serv_Recoleccion,ZEnc.Chk_Serv_Mantenimiento_Preventivo,ZEnc.Chk_Serv_Garantia,
            '                ZEnc.Chk_Serv_Demostracion_Maquina,ZEnc.CodTecnico_Asignado,Isnull(ZTecAsig.NomFuncionario,'') As Tecnico_Asignado,
            '                ZEnc.CodTecnico_Repara,Isnull(ZTecRep.NomFuncionario,'') As Tecnico_Repara,IsNull(ZCarac2.NombreTabla,'') As Estado_Entrega, 
            '                Chk_Equipo_Abandonado_Por_El_Cliente,Chk_No_Existe_COV_Ni_NVV,Codigo,Descripcion,Idmaeedo_GRP_PRE,Idmaeedo_GDP_PRE,
            '             Defecto_segun_cliente, Reparacion_a_realizar, Defecto_encontrado, Reparacion_Realizada, Chk_no_se_pudo_reparar, 
            '                Motivo_no_reparo,Nota_Etapa_01,Nota_Etapa_02,Nota_Etapa_03,Nota_Etapa_04,Nota_Etapa_05,Nota_Etapa_06,Nota_Etapa_07,Nota_Etapa_08
            '                From " & _Global_BaseBk & "Zw_St_OT_Encabezado ZEnc
            '                 Inner Join " & _Global_BaseBk & "Zw_St_OT_Notas ZNotas On ZEnc.Id_Ot = ZNotas.Id_Ot
            '                  Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones ZCarac1 On ZCarac1.Tabla = 'ESTADOS_ST' And ZCarac1.CodigoTabla = CodEstado
            '                   Left Join " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller ZTecAsig On ZTecAsig.CodFuncionario = ZEnc.CodTecnico_Asignado
            '                    Left Join " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller ZTecRep On ZTecRep.CodFuncionario = ZEnc.CodTecnico_Asignado
            '                     Left Join MAEEN On KOEN = ZEnc.CodEntidad And SUEN = ZEnc.SucEntidad
            '                          Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones ZCarac2 On ZCarac2.Tabla = 'ES_ENTREGA_ST' And ZCarac2.CodigoTabla =  Cod_Estado_Entrega
            '                Where ZEnc.Id_Ot = @Id_Ot"

            '    _Row_Servicio_Tecnico_Enc = _Sql.Fx_Get_DataRow(Consulta_sql)

            'End If


        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Sub

    Sub Sb_Crear_PDF(_Marca_Agua As String,
                     _Poner_Marca_Agua As Boolean,
                     _Nombre_Archivo As String)

        Dim _Impresion_CEDIBLE As Boolean = _Imprimir_Cedible

        _Imprimir_Cedible = False

        _Error = Fx_Crear_PDF(_Nombre_Archivo)

        If String.IsNullOrEmpty(_Error) Then

            _Imprimir_Cedible = _Impresion_CEDIBLE

            If _Imprimir_Cedible Then

                _Error = Fx_Crear_PDF(_Nombre_Archivo & "_Cedible")

            End If

        End If

    End Sub

    Function Fx_Crear_PDF(_Nombre_Archivo As String) As String

        Dim _Porc_Alto As Double = 0.73
        Dim _Porc_Ancho As Double = 0.73

        _Fila_InicioDetalle = _TblEncForm.Rows(0).Item("Fila_InicioDetalle") * _Porc_Alto
        _Fila_FinDetalle = _TblEncForm.Rows(0).Item("Fila_FinDetalle") * _Porc_Alto

        Dim _Documento_Pdf As PdfDocument = New PdfDocument ' Crea el documento Pdf
        Dim _Pagina As PdfPage = _Documento_Pdf.AddPage     ' Crea una pagina vacia

        Dim _AnchoDoc = _TblEncForm.Rows(0).Item("AnchoDoc")
        Dim _LargoDoc = _TblEncForm.Rows(0).Item("LargoDoc")

        Dim _NroLineasXpag = _TblEncForm.Rows(0).Item("NroLineasXpag")

        Dim _Format_Page As New PageSize


        _Pagina.Size = PageSize.Letter
        '_Pagina.Width = _AnchoDoc
        '_Pagina.Height = _LargoDoc

        _Pagina.Orientation = PageOrientation.Portrait

        Dim _Pdf_gx As XGraphics = XGraphics.FromPdfPage(_Pagina) ' Crea un Objeto XGraphics para la creacion de los datos
        'Dim tf As XTextFormatter


        Dim _Hora_Pc = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
        Dim _Fecha_Pc = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

        Dim _Fila_Y As Integer = 0
        Dim _Columna_X As Integer = 0

        Dim _Tido As String = _RowEncabezado.Item("TIDO")
        Dim _Nudo As String = _RowEncabezado.Item("NUDO")


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

            Dim _Fte_Usar As XFont
            Dim _Style As XFontStyle = XFontStyle.Underline
            Dim _Imagen As XImage

            Dim _Funcion_Bk As Boolean
            Dim _Formato_Fx As String
            Dim _Campo As String
            Dim _Codigo_De_Barras As Boolean
            Dim _CodigoQr As Boolean
            Dim _Es_Descuento As Boolean

            Dim _SQL_Personalizada As Boolean
            Dim _SqlQuery As String


            For Each _Fila As DataRow In _Tbl_Fx_Encabezado.Rows

                _NombreObjeto = _Fila.Item("NombreObjeto")
                _Funcion = _Fila.Item("Funcion")
                _TipoDato = _Fila.Item("TipoDato")
                _Seccion = _Fila.Item("Seccion")

                _Formato = _Fila.Item("Formato")
                _CantDecimales = _Fila.Item("CantDecimales")
                _Fuente = _Fila.Item("Fuente")
                _Tamano = _Fila.Item("Tamano")
                _Alto = _Fila.Item("Alto") * _Porc_Alto
                _Ancho = _Fila.Item("Ancho") * _Porc_Ancho
                _Estilo = _Fila.Item("Estilo")
                _Color = _Fila.Item("Color")
                _Fila_Y = _Fila.Item("Fila_Y") * _Porc_Alto
                _Columna_X = _Fila.Item("Columna_X") * _Porc_Ancho
                _Texto = _Fila.Item("Texto")
                _RutaImagen = _Fila.Item("RutaImagen")

                _Funcion_Bk = _Fila.Item("Funcion_Bk")
                _Formato_Fx = _Fila.Item("Formato_Fx")
                _Campo = _Fila.Item("Campo")
                _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                _CodigoQr = _Fila.Item("CodigoQr")
                _Es_Descuento = _Fila.Item("Es_Descuento")

                _SQL_Personalizada = _Fila.Item("SQL_Personalizada")
                _SqlQuery = _Fila.Item("SqlQuery")

                Select Case _Estilo
                    Case 0
                        _Style = XFontStyle.Regular
                    Case 1
                        _Style = XFontStyle.Bold
                    Case 2
                        _Style = XFontStyle.Italic
                    Case 4
                        _Style = XFontStyle.Underline
                    Case 8
                        _Style = XFontStyle.Strikeout
                    Case Else
                        _Style = XFontStyle.Regular
                End Select

                _Fte_Usar = New XFont(_Fuente, _Tamano, _Style)
                _Color = Color.FromArgb(_Color)

                Dim _XColor As XColor = XColor.FromArgb(_Color)

                Dim _Xpens = New XPen(_XColor)

                Dim _XDrawBrush As New XSolidBrush(_XColor)

                If _NombreObjeto = "Texto_libre" Then

                    _Pdf_gx.DrawString(_Texto, _Fte_Usar, _XDrawBrush, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Funcion" And _Seccion <> "D" Then

                    Dim bm As Bitmap = Nothing
                    Dim CodBarras As New PictureBox

                    If CBool(_IdMaeedo) Then

                        If _Funcion_Bk Then

                            Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion,
                                                                 _Texto,
                                                                 _Formato,
                                                                 _Pdf_gx,
                                                                 _Columna_X,
                                                                 _Fila_Y,
                                                                 _Fte_Usar,
                                                                 _XDrawBrush,
                                                                 _Ancho,
                                                                 _Alto,
                                                                 _Campo,
                                                                 _TipoDato,
                                                                 _Es_Descuento,
                                                                 _Codigo_De_Barras,
                                                                 _CodigoQr)

                        Else

                            Dim _Row As DataRow = _RowEncabezado

                            If _SQL_Personalizada Then

                                Dim _Error As String
                                _Row = Fx_Funcion_SQL_Personalizada_Enc_Pie(_SqlQuery, _IdMaeedo, _Error)

                                If String.IsNullOrEmpty(_Error) Then
                                    _Campo = "CAMPO"
                                Else
                                    _Campo = "_Error"
                                End If

                            End If

                            Dim _Formato_Texto As String = _Texto
                            Dim _Formatext = Split(_Formato_Texto, vbCrLf)

                            Dim _Moneda_Str As String = _RowEncabezado.Item("MODO").ToString.Trim

                            _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                                          _TipoDato,
                                                                          _Es_Descuento,
                                                                          _Row,
                                                                          _Texto,
                                                                          _Moneda_Str)

                            If _Formatext.Length > 1 Then

                                Dim _Caracteres = _Formato_Texto.Length

                                Dim _i = 0

                                If IsNothing(_Texto) Then _Texto = String.Empty

                                _Texto = Replace(_Texto, vbCrLf, " ")
                                _Texto = Replace(_Texto, vbTab, " ")

                                If IsNothing(_Texto) Then _Texto = String.Empty

                                If Not String.IsNullOrWhiteSpace(_Texto) Then _Texto = Replace(_Texto, "  ", " ")

                                If IsNothing(_Texto) Then
                                    _Texto = String.Empty
                                End If

                                Dim _SubCarac = _Formato_Texto.Split(vbCrLf)
                                Dim _TextoAjustado As String = Fx_AjustarTexto(_Texto, _SubCarac(0).Length)

                                Dim _AltoL = (_Alto / _Formatext.Length) + 2

                                _Formatext = Split(_TextoAjustado, vbCrLf)

                                Dim _Fy = _Fila_Y

                                For Each _Texto1 As String In _Formatext
                                    _Pdf_gx.DrawString(_Texto1.Trim, _Fte_Usar, _XDrawBrush, _Columna_X, _Fy)
                                    _Fy += _AltoL

                                Next

                            Else

                                _Pdf_gx.DrawString(_Texto, _Fte_Usar, _XDrawBrush, _Columna_X, _Fila_Y)

                            End If

                        End If

                    End If

                ElseIf _NombreObjeto = "Imagen" Then

                    Try
                        _Imagen = New System.Drawing.Bitmap(_RutaImagen)
                        _Pdf_gx.DrawImage(_Imagen, _Columna_X, _Fila_Y * 0.95, _Ancho, _Alto)
                    Catch ex As Exception
                    End Try

                ElseIf _NombreObjeto = "Caja" Then

                    Dim _y As Double

                    If _Fila_Y < 500 Then
                        _y = _Fila_Y * 0.95
                    Else
                        _y = _Fila_Y * 0.98
                    End If

                    Dim _Rectangulo As New XRect(_Columna_X, _y, _Ancho, _Alto)
                    _Xpens = New XPen(_XColor, _Tamano)

                    If CBool(_Estilo) Then

                        Dim _Borde As XSize
                        _Borde.Height = 10
                        _Borde.Width = 10

                        _Pdf_gx.DrawRoundedRectangle(_Xpens, _Rectangulo, _Borde)

                    Else
                        _Pdf_gx.DrawRectangle(_Xpens, _Rectangulo)
                    End If

                ElseIf _NombreObjeto = "" Then

                    'Dim _Pen As New Pen(_DrawBrush, _Tamano)

                End If
            Next


            Dim _Detalle_Y As Integer = _Fila_InicioDetalle

            Dim _Salir_del_For As Boolean
            Dim _Mas_Alto As Integer

            For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                Dim _Orden_Detalle As Integer = _Fila.Item("Orden_Detalle")
                _Alto = _Fila.Item("Alto")

                If _Orden_Detalle = 1 Then

                    If _Mas_Alto < _Alto Then
                        _Mas_Alto = _Alto
                    End If

                    _NombreObjeto = _Fila.Item("NombreObjeto")

                End If

            Next

            Dim _Salto_Linea As Integer = (_Mas_Alto + 2) * _Porc_Alto '0.73

            Dim _Agrupar_Lineas As Boolean = (_TblDetalle.Rows.Count > _NroLineasXpag)
            Dim _Contador_Lineas = 0

            Dim _DrawBrush = XBrushes.Black '(_Color)

            If _Agrupar_Lineas Then

                For Each _Fila_D As DataRow In _TblDetalle_Agrupado.Rows

                    Dim _Codigo = _Fila_D.Item("KOPR")

                    For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                        _NombreObjeto = _Fila.Item("NombreObjeto")
                        _Funcion = _Fila.Item("Funcion")
                        _TipoDato = _Fila.Item("TipoDato")
                        _Seccion = _Fila.Item("Seccion")

                        _Formato = _Fila.Item("Formato")
                        _CantDecimales = _Fila.Item("CantDecimales")
                        _Fuente = _Fila.Item("Fuente")
                        _Tamano = _Fila.Item("Tamano")
                        _Alto = _Fila.Item("Alto") * _Porc_Alto
                        _Ancho = _Fila.Item("Ancho") * _Porc_Ancho
                        _Estilo = _Fila.Item("Estilo")
                        _Color = _Fila.Item("Color")
                        _Fila_Y = _Fila.Item("Fila_Y") * _Porc_Alto
                        _Columna_X = _Fila.Item("Columna_X") * _Porc_Ancho
                        _Texto = _Fila.Item("Texto")
                        _RutaImagen = _Fila.Item("RutaImagen")

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

                        _Fte_Usar = New XFont(_Fuente, _Tamano, _Style)

                        _Funcion_Bk = _Fila.Item("Funcion_Bk")
                        _Formato_Fx = _Fila.Item("Formato_Fx")
                        _Campo = _Fila.Item("Campo")
                        _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                        _Es_Descuento = _Fila.Item("Es_Descuento")

                        _Color = Color.FromArgb(_Color)

                        ' Dim _DrawBrush As New SolidBrush(_Color)

                        If CBool(_IdMaeedo) Then

                            If _NombreObjeto = "Texto_libre" Then

                                Dim _Y_Texto = _Fila_InicioDetalle

                                For Each _Fii As DataRow In _TblDetalle_Agrupado.Rows
                                    _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Y_Texto)
                                    _Y_Texto += _Salto_Linea
                                Next

                            ElseIf _NombreObjeto = "Funcion" Then

                                If _Funcion_Bk Then

                                    If Fx_Imprimir_Funciones_Detalle(_Funcion,
                                                                    _Texto,
                                                                    _TblDetalle,
                                                                    _Pdf_gx,
                                                                    _Fila_Y,
                                                                    _Columna_X,
                                                                    _Fte_Usar,
                                                                    _DrawBrush) Then
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

                                    Dim _Moneda_Str As String = _Fila_D.Item("MOPPPR").ToString.Trim

                                    _Texto = Fx_New_Trae_Valor_Detalle_Row(_Campo,
                                                                           _TipoDato,
                                                                           _Es_Descuento,
                                                                           _Row_Fila_D,
                                                                           _Texto,
                                                                           _Moneda_Str)

                                    If _Texto.ToString.Contains("Error_") Then _Texto = String.Empty

                                    'IMPRIME CODIGO DE BARRAS
                                    If _Codigo_De_Barras Then

                                        Dim bm As Bitmap = Nothing
                                        Dim CodBarras As XImage

                                        Dim iType As BarCode.Code128SubTypes =
                                        DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                                        bm = BarCode.Code128(_Texto, iType, False)
                                        If Not IsNothing(bm) Then
                                            CodBarras = bm
                                        End If
                                        Dim d = _Detalle_Y
                                        _Pdf_gx.DrawImage(CodBarras, _Columna_X, _Detalle_Y, _Ancho, _Alto - 2)
                                    Else
                                        _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                    End If

                                End If

                            End If

                        Else

                        End If

                    Next

                    _Detalle_Y += _Salto_Linea - 1

                    _Contador_Lineas += 1

                    If _Contador_Lineas > _NroLineasXpag Then
                        _Salir_del_For = True '_Pdf_gx.DrawString("--------------------", _Fte_Usar, _DrawBrush, 100, _Detalle_Y)
                    End If

                    If _Salir_del_For Then
                        Exit For
                    End If

                Next

                _Pdf_gx.DrawString("--------------------", _Fte_Usar, _DrawBrush, 100, _Detalle_Y)

            Else

                For Each _Fila_D As DataRow In _TblDetalle.Rows

                    Dim _Codigo = _Fila_D.Item("KOPR")

                    For Each _Fila As DataRow In _Tbl_Fx_Detalle.Rows

                        _NombreObjeto = _Fila.Item("NombreObjeto")
                        _Funcion = _Fila.Item("Funcion")
                        _TipoDato = _Fila.Item("TipoDato")
                        _Seccion = _Fila.Item("Seccion")

                        _Formato = _Fila.Item("Formato")
                        _CantDecimales = _Fila.Item("CantDecimales")
                        _Fuente = _Fila.Item("Fuente")
                        _Tamano = _Fila.Item("Tamano")
                        _Alto = _Fila.Item("Alto") * _Porc_Alto
                        _Ancho = _Fila.Item("Ancho") * _Porc_Ancho
                        _Estilo = _Fila.Item("Estilo")
                        _Color = _Fila.Item("Color")
                        _Fila_Y = _Fila.Item("Fila_Y") * _Porc_Alto
                        _Columna_X = _Fila.Item("Columna_X") * _Porc_Ancho
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

                        _Fte_Usar = New XFont(_Fuente, _Tamano, _Style)

                        _Funcion_Bk = _Fila.Item("Funcion_Bk")
                        _Formato_Fx = _Fila.Item("Formato_Fx")
                        _Campo = _Fila.Item("Campo")
                        _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                        _Es_Descuento = _Fila.Item("Es_Descuento")

                        _Color = Color.FromArgb(_Color)

                        ' Dim _DrawBrush As New SolidBrush(_Color)

                        If CBool(_IdMaeedo) Then

                            If _NombreObjeto = "Texto_libre" Then

                                Dim _Y_Texto = _Fila_InicioDetalle

                                For Each _Fii As DataRow In _TblDetalle.Rows
                                    _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Y_Texto)
                                    _Y_Texto += _Salto_Linea
                                Next

                            ElseIf _NombreObjeto = "Funcion" Then

                                If _Funcion_Bk Then

                                    If Fx_Imprimir_Funciones_Detalle(_Funcion,
                                                                    _Texto,
                                                                    _TblDetalle,
                                                                    _Pdf_gx,
                                                                    _Fila_Y,
                                                                    _Columna_X,
                                                                    _Fte_Usar,
                                                                    _DrawBrush) Then
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

                                    Dim _Moneda_Str As String = _Fila_D.Item("MOPPPR").ToString.Trim

                                    Dim _Formato_Texto As String = _Texto
                                    Dim _Formatext = Split(_Formato_Texto, vbCrLf)

                                    _Texto = Fx_New_Trae_Valor_Detalle_Row(_Campo,
                                                                           _TipoDato,
                                                                           _Es_Descuento,
                                                                           _Row_Fila_D,
                                                                           _Texto,
                                                                           _Moneda_Str)

                                    'If _Orden_Detalle = 2 And Not String.IsNullOrEmpty(_Texto) Then

                                    '    _Detalle_Y += _Alto + 2

                                    'End If

                                    If _Orden_Detalle = 2 Then

                                        If Not String.IsNullOrWhiteSpace(_Texto) AndAlso _Formatext.Length > 1 Then

                                            '_Saltar_Linea = False

                                            Dim _Caracteres = _Formato_Texto.Length

                                            Dim _i = 0

                                            If IsNothing(_Texto) Then _Texto = String.Empty

                                            _Texto = Replace(_Texto, vbCrLf, " ")
                                            _Texto = Replace(_Texto, vbTab, " ")

                                            If IsNothing(_Texto) Then
                                                _Texto = String.Empty
                                            End If

                                            If Not String.IsNullOrWhiteSpace(_Texto) Then
                                                _Texto = Replace(_Texto, "  ", " ")
                                            End If

                                            Dim _SubCarac = _Formato_Texto.Split(vbCrLf)
                                            Dim _TextoAjustado As String = Fx_AjustarTexto(_Texto, _SubCarac(0).Length)

                                            Dim _AltoL = (_Alto / _Formatext.Length) + 2

                                            _Formatext = Split(_TextoAjustado, vbCrLf)

                                            '_Detalle_Y += _AltoL + 2

                                            For Each _Texto1 As String In _Formatext

                                                If Not String.IsNullOrWhiteSpace(_Texto1) Then
                                                    _Detalle_Y += _AltoL
                                                    _Pdf_gx.DrawString(_Texto1.Trim, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                                End If

                                            Next

                                        Else

                                            If Not String.IsNullOrEmpty(_Texto) Then

                                                _Detalle_Y += _Alto + 2
                                                _Texto = Replace(_Texto, vbCrLf, " ")
                                                _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                                            End If

                                        End If


                                    Else

                                        'IMPRIME CODIGO DE BARRAS
                                        If _Codigo_De_Barras Then

                                            Dim bm As Bitmap = Nothing
                                            Dim CodBarras As XImage

                                            Dim iType As BarCode.Code128SubTypes =
                                            DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                                            bm = BarCode.Code128(_Texto, iType, False)
                                            If Not IsNothing(bm) Then
                                                CodBarras = bm
                                            End If
                                            Dim d = _Detalle_Y
                                            _Pdf_gx.DrawImage(CodBarras, _Columna_X, _Detalle_Y, _Ancho, _Alto - 2)
                                        Else
                                            _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)
                                        End If

                                    End If

                                End If

                            End If

                        Else

                        End If

                    Next

                    _Detalle_Y += _Salto_Linea

                    If _Salir_del_For Then
                        Exit For
                    End If

                Next

            End If

            '' REFERENCIAS *****

            For Each _Fila_D As DataRow In _TblReferencias.Rows

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

                    _Fte_Usar = New XFont(_Fuente, _Tamano, _Style)

                    _Funcion_Bk = _Fila.Item("Funcion_Bk")
                    _Formato_Fx = _Fila.Item("Formato_Fx")
                    _Campo = _Fila.Item("Campo")
                    _Codigo_De_Barras = _Fila.Item("Codigo_De_Barras")
                    _Es_Descuento = _Fila.Item("Es_Descuento")

                    _Color = Color.FromArgb(_Color)

                    If _NombreObjeto = "Funcion" Then

                        If _Funcion_Bk Then

                            If _Funcion = "Referencia DTE" Then

                                If _Contador = 0 Then
                                    _Pdf_gx.DrawString("------------------  Referencias ------------------------",
                                                       _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                                    _Detalle_Y += _Salto_Linea
                                End If

                                _Pdf_gx.DrawString(_Referencia, _Fte_Usar, _DrawBrush, _Columna_X, _Detalle_Y)

                            End If

                        End If

                    End If

                Next
                _Contador += 1
                _Detalle_Y += _Salto_Linea

            Next

            '' ********

            Dim _Archivo_PDF As String = _Directorio_Destino & "\" & _Nombre_Archivo & ".pdf"
            _Documento_Pdf.Save(_Archivo_PDF)
            _Pagina.Close()
            _Documento_Pdf.Close()
            _Documento_Pdf.Dispose()

            'oPdfWriter.Close()
            Return ""
        Catch ex As Exception
            Return ex.Message
            'My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            'MsgBox(ex.Message)
            'MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Function

    Function Fx_Imprimir_Funciones_Encabezado_Pie(_Funcion As String,
                                                  _Texto As String,
                                                  _Formato_Fx As String,
                                                  _Pdf_gx As XGraphics,
                                                  _Columna_X As Integer,
                                                  _Fila_Y As Integer,
                                                  _Fte_Usar As XFont,
                                                  _DrawBrush As XBrush,
                                                  _Ancho As Single,
                                                  _Alto As Single,
                                                  _Campo As String,
                                                  _Tipo_de_dato As String,
                                                  _Es_Decuento As Boolean,
                                                  _Codigo_De_Barras As Boolean,
                                                  _CodigoQr As Boolean) As Boolean


        Dim _Tido As String = _RowEncabezado.Item("TIDO")
        Dim _Nudo As String = _RowEncabezado.Item("NUDO")

        Dim _Cant_Caracteres As Integer
        Dim _Cant_Caracteres_Texto As Integer

        Dim bm As Bitmap = Nothing
        Dim CodBarras As XImage

        Select Case _Funcion

            Case "Timbre Electronico"

                If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                    CodBarras = Fx_Timbre_Electronico_Hefesto(_IdMaeedo, _Tido, _Nudo)
                Else
                    CodBarras = Fx_Timbre_Electronico(_IdMaeedo, _Tido, _Nudo)
                End If

                If Not (CodBarras Is Nothing) Then
                    _Pdf_gx.DrawImage(CodBarras, _Columna_X, _Fila_Y, _Ancho, _Alto)
                End If

            Case "Texto CEDIBLE"

                If _Imprimir_Cedible Then
                    _Pdf_gx.DrawString("CEDIBLE", _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                End If

            Case "Documentos Relacionados"

                _Formato_Fx = _Texto
                _Texto = String.Empty
                Dim _TblDoc_Relacionados As DataTable

                Consulta_sql = "Select Distinct TIDOPA+'-'+NUDOPA From MAEDDO Where IDMAEEDO = " & _IdMaeedo
                _TblDoc_Relacionados = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila As DataRow In _TblDoc_Relacionados.Rows
                    _Texto += _Fila.Item(0) & Space(1)
                Next

                _Cant_Caracteres = _Formato_Fx.Length
                _Cant_Caracteres_Texto = _Texto.ToString.Length

                _Texto = Trim(Mid(_Texto, 1, _Cant_Caracteres))

                If _Cant_Caracteres_Texto > _Cant_Caracteres Then _Texto += "..."

                _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

            Case "Docs. que lo Pagan (1)", "Docs. que lo Pagan (2)"

                _Formato_Fx = _Texto
                _Texto = String.Empty
                Dim _TblDoc_Relacionados As DataTable

                Consulta_sql = "SELECT CE.TIDP,CE.NUDP,CE.EMDP,CE.CUDP,CE.NUCUDP,CE.FEEMDP,CE.FEVEDP,CE.VADP,CD.VAASDP  
                                FROM MAEDPCD AS CD  WITH ( NOLOCK )   
                                LEFT JOIN MAEDPCE AS CE ON CD.IDMAEDPCE=CE.IDMAEDPCE  WHERE TIDOPA='FCV' AND ARCHIRST='MAEEDO' AND IDRST=" & _IdMaeedo

                _TblDoc_Relacionados = _Sql.Fx_Get_DataTable(Consulta_sql)

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
                            _Texto += Trim(_Tidp & " " & _Nudp & " " & FormatCurrency(_Vaasdp))
                        End If

                        If _Contador_Filas <> _TblDoc_Relacionados.Rows.Count Then
                            _Texto += "/"
                        End If

                        _Contador_Filas += 1

                    Next

                    _Cant_Caracteres = _Formato_Fx.Length ' Len(_Formato_Fx)
                    _Cant_Caracteres_Texto = _Texto.ToString.Length

                    _Texto = Trim(Mid(_Texto, 1, _Cant_Caracteres))
                    If _Cant_Caracteres_Texto > _Cant_Caracteres Then _Texto += "..."

                Else

                    _Texto = "** NO REGISTRA PAGOS O ABONOS **"

                End If

                _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

            Case "Observaciones Largas(50)"

#Region " Observaciones Largas (50)"

                Dim _Obdo = NuloPorNro(_RowEncabezado.Item("OBDO"), "")

                _Texto = Replace(_Obdo, vbCrLf, " ")

                Dim _Textos(4) As String

                _Textos(0) = Mid(_Texto, 1, 50)
                _Textos(1) = Mid(_Texto, 51, 100)
                _Textos(2) = Mid(_Texto, 101, 150)
                _Textos(3) = Mid(_Texto, 151, 200)
                _Textos(4) = Mid(_Texto, 201, 250)

                _Pdf_gx.DrawString(_Textos(0), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                _Pdf_gx.DrawString(_Textos(1), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 12)
                _Pdf_gx.DrawString(_Textos(2), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 24)
                _Pdf_gx.DrawString(_Textos(3), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 36)
                _Pdf_gx.DrawString(_Textos(4), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 48)
#End Region

            Case "Observaciones Largas(100)"

#Region " Observaciones Largas (100)"

                Dim _Obdo = NuloPorNro(_RowEncabezado.Item("OBDO"), "")

                _Texto = Replace(_Obdo, vbCrLf, " ")

                Dim _Textos(4) As String

                _Textos(0) = Mid(_Texto, 1, 100)
                _Textos(1) = Mid(_Texto, 101, 200)
                _Textos(2) = Mid(_Texto, 201, 250)

                _Pdf_gx.DrawString(_Textos(0), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                _Pdf_gx.DrawString(_Textos(1), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 12)
                _Pdf_gx.DrawString(_Textos(2), _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y + 24)

#End Region

            Case "Autorizadores Orden De Compra 01", "Autorizadores Orden De Compra 02", "Autorizadores Orden De Compra 03"

#Region "Autorizadores Orden De Compra"

                _Formato_Fx = _Texto
                _Texto = String.Empty

                Consulta_sql = "Select CodFuncionario_Autoriza,NOKOFU, Fecha_Otorga
                                From " & _Global_BaseBk & "Zw_Remotas
                                Inner Join TABFU ON KOFU = CodFuncionario_Autoriza
                                Where Idmaeedo = " & _IdMaeedo

                Dim _Tbl_Aurotizadores As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

                _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
#End Region

            Case "Referencias DTE Rd"

#Region "Referencias DTE Rd"

                _Formato_Fx = _Texto
                _Texto = String.Empty

                For Each _Fila As DataRow In _TblReferencias.Rows
                    _Texto += _Fila.Item("Referencia") & Space(1)
                Next

                _Cant_Caracteres = _Formato_Fx.Length
                _Cant_Caracteres_Texto = _Texto.ToString.Length

                _Texto = Trim(Mid(_Texto, 1, _Cant_Caracteres))

                If _Cant_Caracteres_Texto > _Cant_Caracteres Then _Texto += "..."

                _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)

#End Region

            Case Else

                _Formato_Fx = _Texto

                Dim _Text2 As String = _Texto

                Dim _Moneda_Str As String = _RowEncabezado.Item("MODO").ToString.Trim

                _Texto = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                              _Tipo_de_dato,
                                                              _Es_Decuento,
                                                              _RowEncabezado,
                                                              _Formato_Fx,
                                                              _Moneda_Str)
                'IMPRIME CODIGO DE BARRAS
                If _Codigo_De_Barras Then

                    Dim iType As BarCode.Code128SubTypes =
                    DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                    bm = BarCode.Code128(_Texto, iType, False)
                    If Not IsNothing(bm) Then
                        CodBarras = bm
                    End If

                    _Pdf_gx.DrawImage(CodBarras, _Columna_X, _Fila_Y, _Ancho, _Alto)

                ElseIf _CodigoQr Then

                    _QrCodeImgControl.Text = _Text2
                    _Pdf_gx.DrawImage(_QrCodeImgControl.Image, _Columna_X, _Fila_Y, _Alto, _Alto)

                Else
                    _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
                End If
                ' _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
        End Select

    End Function

    Function Fx_Imprimir_Funciones_Detalle(_Funcion As String,
                                           _Texto As String,
                                           _TblDetalle As DataTable,
                                           _Pdf_gx As XGraphics,
                                           _Columna_X As Integer,
                                           _Fila_Y As Integer,
                                           _Fte_Usar As XFont,
                                           _DrawBrush As XBrush) As Boolean


        Select Case _Funcion

            Case "Imprimir Detalle Tipo Vale 01" ' Neto Con Linea, Código y Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 02" ' Neto Sin Linea, Código y Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 03" ' Bruto Con Linea, Código y Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 04" ' Bruto Sin Linea, Código y Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 05" ' Neto Con Linea Solo Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 06" ' Neto Sin Linea Solo Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 07" ' Bruto Con Linea Solo Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 08" ' Bruto Sin Linea Solo Descripcion
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 09" ' Neto Sin Linea, Código y Descripcion Con Observaciones por documento
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Tipo Vale 10" ' Bruto Sin Linea, Código y Descripcion Con Observaciones por documento
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case "Imprimir Detalle Picking 01"
                _Texto = "Función: " & _Funcion & " - No disponible en PDF"
            Case Else
                _Texto = String.Empty
                'Case "Texto Libre En Detalle"

        End Select

        If Not String.IsNullOrEmpty(_Texto) Then
            _Pdf_gx.DrawString(_Texto, _Fte_Usar, _DrawBrush, _Columna_X, _Fila_Y)
        End If

    End Function

    Sub Sb_Abrir_Archivo()
        System.Diagnostics.Process.Start(Pro_Full_Path_Archivo_PDF & "\" & _Nombre_Archivo & ".pdf")
    End Sub

    'Sub Sb_Abrir_Archivo_Cedible()
    '    System.Diagnostics.Process.Start(Pro_Full_Path_Archivo_PDF & "\" & _Nombre_Archivo & "_Cedible.pdf")
    'End Sub

    Function Fx_Timbre_Electronico(_Idmaeedo As Integer,
                                   _Tido As String,
                                   _Nudo As String) As XImage

        Dim _Timbre As String

        Dim _Archivo_Xml As String
        Dim _Dset_DTE As New DataSet

        Dim _bm As Bitmap = Nothing
        Dim _CodBarras As XImage
        Dim _Timbre_Falso As Boolean

        Dim _Dir As String = AppPath() & "\Data\" & RutEmpresa & "\Temp"
        _Archivo_Xml = _Sql.Fx_Trae_Dato("FMAEDTE", "XML", "IDMAEEDO = " & _Idmaeedo)

        If String.IsNullOrEmpty(_Archivo_Xml) Then
            _Timbre_Falso = True
            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo, Mod_Empresa, Mod_Modalidad)
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

                _Dir = _Dir & "\" & _Nombre_Archivo

                Dim oSW As New System.IO.StreamWriter(_Dir)

                oSW.WriteLine(_Archivo_Xml)
                oSW.Close()

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
                _Timbre = _Timbre.Replace(" ", "")

                File.Delete(_Dir)

            End If

        End If

        _bm = BarCode.PDF417(_Timbre, 1, 8)

        If Not IsNothing(_bm) Then
            _CodBarras = _bm
        End If

        Return _CodBarras

    End Function

    Function Fx_Timbre_Electronico_Hefesto(_Idmaeedo As Integer,
                                           _Tido As String,
                                           _Nudo As String) As XImage


        Dim _Timbre As String

        Dim _Archivo_Xml As String
        Dim _Dset_DTE As New DataSet
        Dim _Timbre_Falso As Boolean

        Dim _bm As Bitmap = Nothing
        Dim _CodBarras As XImage

        Dim _Dir As String = AppPath() & "\Data\" & RutEmpresa & "\Temp"
        _Archivo_Xml = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "Xml", "Idmaeedo = " & _Idmaeedo)

        If String.IsNullOrEmpty(_Archivo_Xml) Then

            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo, Mod_Empresa, Mod_Modalidad)
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
                        Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo, Mod_Empresa, Mod_Modalidad)
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
            _CodBarras = _bm
        End If

        Return _CodBarras

    End Function

End Class
