'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.Drawing
Imports System.Drawing.Printing

Module Modulo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


#Region "Variables de la solución"

    Dim IdBodega As Integer

    Public AccInv As Integer

    Public Enum AccionInv As Integer
        Grabar
        Editar
        Eliminar
    End Enum

    Public CorregirProducto As Integer
    Public Enum ProdCorregir As Integer
        Rapido
        Tecnico
        Principal
    End Enum


    Public CorrigeInventario As Boolean
    Public SemillaProductoaCorregir As String
    Public CodigoNoEncontrado As String
    Public CodigoPrincipalCorregido As String
    Public CodigoRapidoCorregido As String
    Public CodigoTecnicoCorregido As String
    Public CodigoLeidoCorregido As String
    Public DescripcionCorregido As String

    Public DescripcionInvActivo As String = ""

    Public Ano_Inv_Seleccionado As String
    Public Mes_Inv_Seleccionado As String
    Public Dia_Inv_Seleccionado As String


    Public InventarioCreado As Boolean

    Public Inventario_AnoActivo As String = ""
    Public Inventario_MesActivo As String = ""
    Public inventario_DiaActivo As String = ""

    Public FechaInv As String

    Public Enum TipoGri As Integer
        GRI_C1 'Cargar información para ajuste de inventario
        GRI_C2 'Cargar Guias de ingreso de inventario
    End Enum

    Public TieneUbicaciones As Boolean

    Public AcctionInv As Integer

    Public Enum AccionInventario As Integer
        Contar_Productos
        Imprimir_Sectores
    End Enum


    Public SemillaUbicacion_Inv As String
    Public NombreBodegaInventarioActual As String

    Public SectorActivo As String

#End Region

    Function ActualizarGrillaFotoXproducto(ByVal Grilla As DataGridView,
                                  ByVal IdBodega As String,
                                  ByVal CodigoBuscar As String,
                                  ByVal SemillaUbicacion As String)

        Dim Filtrar As String = ""

        Try

            Dim Pie As String


            Consulta_sql = "SELECT dbo.ZW_TmpInvProductosInventariados.Semilla, dbo.ZW_TmpInvUbicacionesBodega.UbicacionBodega, " & vbCrLf &
                           "Isnull(dbo.ZW_TmpInvProductosInventariados.Nro_Hoja,'') as Nro_Hoja, " & vbCrLf &
                           "Isnull(dbo.ZW_TmpInvProductosInventariados.Item_Hoja,'') as Item_Hoja,  dbo.ZW_TmpInvProductosInventariados.Fila, " & vbCrLf &
                           "dbo.ZW_TmpInvProductosInventariados.Columna, dbo.ZW_TmpInvProductosInventariados.CodBarras, CONVERT(Char(8), " & vbCrLf &
                           "dbo.ZW_TmpInvProductosInventariados.FechaInventario, 105) AS Fecha, CONVERT(Char(8), dbo.ZW_TmpInvProductosInventariados.FechaInventario, 108) AS Hora, " & vbCrLf &
                           "dbo.ZW_TmpInvProductosInventariados.CantidadInventariada, ISNULL(dbo.TABFU.NOKOFU, '') AS Contador, " & vbCrLf &
                           "dbo.ZW_TmpInvProductosInventariados.Observaciones" & vbCrLf &
                           "FROM         dbo.ZW_TmpInvProductosInventariados LEFT OUTER JOIN" & vbCrLf &
                           "dbo.ZW_TmpInvUbicacionesBodega ON " & vbCrLf &
                           "dbo.ZW_TmpInvProductosInventariados.SemillaUbicacion = dbo.ZW_TmpInvUbicacionesBodega.Semilla" & vbCrLf &
                           "LEFT OUTER JOIN dbo.TABFU ON dbo.ZW_TmpInvProductosInventariados.Contador = dbo.TABFU.KOFU" & vbCrLf &
                           "WHERE     (dbo.ZW_TmpInvProductosInventariados.IdBodega = " & IdBodega & ") " & vbCrLf &
                           "AND (dbo.ZW_TmpInvProductosInventariados.Codproducto = '" & CodigoBuscar & "')"

            Consulta_sql = "SELECT Semilla,UbicacionBodega,Isnull(Nro_Hoja,'') as Nro_Hoja," & vbCrLf &
                           "Isnull(Item_Hoja,'') as Item_Hoja,Fila,Columna," & vbCrLf &
                           "CONVERT(Char(8),FechaInventario, 105) AS Fecha," & vbCrLf &
                           "CONVERT(Char(8), FechaInventario, 108) AS Hora," & vbCrLf &
                           "CantidadInventariada,Contador_1,Contador_2, Observaciones," & vbCrLf &
                           "Actualizado_por,Obs_Actualizacion" & vbCrLf &
                           "FROM dbo.ZW_TmpInvProductosInventariados" & vbCrLf &
                           "WHERE     (IdBodega = " & IdBodega & ") " & vbCrLf &
                           "AND (Codproducto = '" & CodigoBuscar & "')"

            'ActualizaLaGrilla(Grilla, tb, Consulta_sql, cn1, True)

            If Grilla.RowCount > 0 Then
                Grilla.Columns(0).Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function


    Function CrearArchivoTxtGRI(ByVal Ruta As String, _
                                ByVal Empresa As String, _
                                ByVal Sucursal As String, _
                                ByVal Bodega As String, _
                                ByVal Bar As Object, _
                                ByVal Estado As Object, _
                                ByVal TipoGuia As Integer)

        Dim Detalle As String = ""

        Try

            Empresa = Rellenar(Empresa, 2, " ")
            Sucursal = Rellenar(Sucursal, 3, " ")
            Bodega = Rellenar(Bodega, 3, " ")

            'Consulta_sql = Replace(Procedures.Select_ProductosInvetariadosFotoStock_Paso, "@Funcionario", FUNCIONARIO)
            Consulta_sql = Replace(Consulta_sql, "@Codigo", "")
            Consulta_sql = Replace(Consulta_sql, "@IdBodega", IdBodega)
            Consulta_sql = Replace(Consulta_sql, "@Ano", Inventario_AnoActivo)
            Consulta_sql = Replace(Consulta_sql, "@Mes", Inventario_MesActivo)
            Consulta_sql = Replace(Consulta_sql, "@Dia", inventario_DiaActivo)

             _Sql.Ej_consulta_IDU(Consulta_Sql)

            'Consulta_sql = Procedures.Select_ProductosInvetariadosArchivoTxt

            Consulta_sql = Replace(Consulta_sql, "@Top", "")
            Consulta_sql = Replace(Consulta_sql, "@Funcionario", FUNCIONARIO)
            Consulta_sql = Replace(Consulta_sql, "@Codigo", Codigo_abuscar)
            Consulta_sql = Replace(Consulta_sql, "@IdBodega", IdBodega)

            Consulta_sql = Replace(Consulta_sql, "@Ano", Inventario_AnoActivo)
            Consulta_sql = Replace(Consulta_sql, "@Mes", Inventario_MesActivo)
            Consulta_sql = Replace(Consulta_sql, "@Dia", inventario_DiaActivo)
            'Consulta_sql = Replace(Consulta_sql, "@SemillaUbicacion", Inventario_AnoActivo)



            Consulta_sql = Consulta_sql & vbCrLf & "and dbo.ZW_TmpInvPs01MSC.TotalInv > 0"

            Estado.text = "Buscando Información..."



            Dim Tabla As New DataTable
            Tabla = _SQL.Fx_Get_Tablas(Consulta_sql)

            If Tabla.Rows.Count > 0 Then
                Dim Fila As DataRow

                Dim CodigoPrincipal As String
                Dim Descripcion As String
                Dim StockUd1 As String
                Dim StockUd2 As String
                Dim Costo As String
                Dim Rtu As Double

                Bar.Maximum = Tabla.Rows.Count
                Bar.Value = 0

                For i = 0 To Tabla.Rows.Count - 1

                    System.Windows.Forms.Application.DoEvents()
                    Bar.Value += 1



                    Fila = Tabla.Rows(i)
                    CodigoPrincipal = Fila.Item("CodigoPR").ToString


                    
                    Descripcion = Fila.Item("DescripcionPR").ToString

                    Estado.text = "Total:" & Tabla.Rows.Count & _
                                  ", Insertando " & i + 1 & ", " & _
                                  CodigoPrincipal & ", " & Descripcion

                    StockUd1 = De_Num_a_Tx_01(Fila.Item("TotalInv").ToString, False, 5)
                    Costo = De_Num_a_Tx_01(Fila.Item("PPP").ToString, False, 5)

                    Rtu = De_Txt_a_Num_01(_Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & CodigoPrincipal & "'"), 5)

                    If Rtu = 1 Then
                        StockUd2 = StockUd1
                    Else
                        StockUd2 = De_Num_a_Tx_01(De_Txt_a_Num_01(StockUd1, 5) * Rtu, True, 3)
                    End If

                    If TipoGuia = TipoGri.GRI_C1 Then

                        Detalle = Detalle & Trim(CodigoPrincipal) & "," & StockUd1 & "," & StockUd2 & _
                                  "," & Empresa & "," & Sucursal & "," & Bodega & vbCrLf

                    ElseIf TipoGuia = TipoGri.GRI_C2 Then

                        Detalle = Detalle & Trim(CodigoPrincipal) & "," & StockUd1 & "," & StockUd2 & "," & Costo & _
                                  "," & Empresa & "," & Sucursal & "," & Bodega & vbCrLf

                    End If
                Next

                CrearArchivoTxt(Ruta, "", Detalle)

            End If

            Bar.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    


#Region "INFORMES"

    





    






#End Region

End Module
