Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones

Public Class MultiNVV
    Dim Sql As New Class_SQL(Cadena_ConexionSQL_Server)





    Public Function GeneraNVV(Id_Documento_Ori As String, Nudo_NVV As String) As List(Of Mensajes)
        ' Cambiamos el retorno a List(Of Mensajes) porque se pueden generar múltiples documentos


        Dim listaMensajes As New List(Of Mensajes)()

        Dim _Tido = "NVV"
        Dim _CampoPrecio As String
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Dim _Fecha_Emision As DateTime? = DateTime.Now

        If True Then
            _CampoPrecio = "PPPRNE" ' Neto
        Else
            _CampoPrecio = "PPPRBR" ' Bruto
        End If

        ' Validamos si existe el documento de origen
        Consulta_sql = $"Select * From MAEEDO Where IDMAEEDO = {Id_Documento_Ori}"
        Dim _Row_OCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If IsNothing(_Row_OCC) Then
            Dim msgError As New Mensajes
            msgError.EsCorrecto = False
            msgError.Detalle = "No se encontro coincidencia del documento de origen"
            listaMensajes.Add(msgError)
            Return listaMensajes
        End If

        Try
            ' 1. OBTENER LOS TIPOS ÚNICOS DE CLALIBPR PRESENTES EN EL DETALLE DEL DOCUMENTO ORIGEN
            Consulta_sql = $"
                SELECT DISTINCT Mp.CLALIBPR 
                FROM MAEDDO Ddo WITH (NOLOCK)
                INNER JOIN MAEPR Mp On Mp.KOPR = Ddo.KOPRCT
                Where TIDO = 'NVV' And NUDO = '{Nudo_NVV}'
                AND (Ddo.ESLIDO<>'C' OR Ddo.ESFALI='I') 
                AND Ddo.TICT = ''"

            Dim dtClasificaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If dtClasificaciones Is Nothing OrElse dtClasificaciones.Rows.Count = 0 Then
                Dim msgError As New Mensajes With {.EsCorrecto = False, .Detalle = "No hay detalles válidos para procesar."}
                listaMensajes.Add(msgError)
                Return listaMensajes
            End If

            ' 2. ITERAR POR CADA CLASIFICACIÓN DISTINTA Y CREAR UN DOCUMENTO
            For Each rowClasif As DataRow In dtClasificaciones.Rows
                Dim _Clasificacion As String = rowClasif("CLALIBPR").ToString().Trim()
                Dim _Mensaje As New Mensajes

                Try
                    ' 3. ARMAR LA QUERY USANDO EL ID DINÁMICO Y LA CLASIFICACIÓN ACTUAL DEL BUCLE
                    Consulta_sql = $"Declare @Idmaeedo Int = {Id_Documento_Ori}

                    SELECT * FROM MAEEDO Where IDMAEEDO = @Idmaeedo

                    SELECT *, CASE WHEN UDTRPR = 1 THEN CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 END AS 'Cantidad',
                    CAPRCO1-CAPREX1 AS 'CantUd1_Dori', CAPRCO2-CAPREX2 AS 'CantUd2_Dori',
                    PPPRNE AS 'Precio',
                    0 As Id_Oferta, '' As Oferta, 0 As Es_Padre_Oferta, 0 As Padre_Oferta, 0 As Hijo_Oferta,
                    0 As Cantidad_Oferta, 0 As Porcdesc_Oferta
                    FROM MAEDDO WITH (NOLOCK) 
                    Inner Join MAEPR Mp On Mp.KOPR = KOPRCT
                    Where IDMAEEDO = @Idmaeedo AND (ESLIDO<>'C' OR ESFALI='I') AND TICT = ''
                    And Mp.CLALIBPR = '{_Clasificacion}'
                    ORDER BY IDMAEEDO, IDMAEDDO 

                    SELECT * FROM MAEIMLI Where IDMAEEDO = @Idmaeedo 
                    SELECT * FROM MAEDTLI Where IDMAEEDO = @Idmaeedo 
                    SELECT TOP 1 * FROM MAEEDOOB Where IDMAEEDO = @Idmaeedo"

                    ' Obtenemos el Dataset específico para esta clasificación
                    Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, False)

                    ' Instanciamos el formulario y creamos el documento
                    Dim Fm_Post As New Frm_Formulario_Documento(_Tido, csGlobales.Enum_Tipo_Documento.Compra, False, _RevisarListaSuperior:=False)
                    Fm_Post.Sb_Limpiar(Mod_Modalidad)
                    'Fm_Post.Pro_Nudo = Nudo_NVV

                    Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Nothing, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)
                    _Mensaje = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, False, _Mostrar_Mensaje:=False)
                    Fm_Post.Dispose()

                    ' Validar si grabó correctamente
                    If _Mensaje.EsCorrecto Then
                        Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                        Dim _Docummento As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                        _Mensaje.Tag = _Docummento
                    Else
                    End If

                Catch exLoop As Exception
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = exLoop.Message
                End Try

                ' Agregamos el resultado de esta clasificación a la lista maestra
                listaMensajes.Add(_Mensaje)
            Next

        Catch ex As Exception
            Dim msgError As New Mensajes With {.EsCorrecto = False, .Detalle = ex.Message}
            listaMensajes.Add(msgError)
        End Try

        Return listaMensajes
    End Function
End Class




