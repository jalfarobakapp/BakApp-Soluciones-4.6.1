Imports Funciones_BakApp
Module Funciones_ImpBarras
    Dim TablaDePaso As String

    Function CrearDetalleParaGenerarEtiquetasDeBarra(ByVal IDMAEEDO As String, _
                                                     ByVal FUNCIONARIO As String, _
                                                     ByVal CodEntidad As String) As Long

        TablaDePaso = "Zw_TmpTblDocBarras" & FUNCIONARIO
        CrearTablaDePaso(TablaDePaso)

        'Dim Empresa As String = trae_dato(tb, cn1, "EMPRESA", "MAEEDO", "IDMAEEDO = " & IDMAEEDO)
        'Dim Sucursal As String = trae_dato(tb, cn1, "SUENDO", "MAEEDO", "IDMAEEDO = " & IDMAEEDO)
        'Dim Bodega As String = trae_dato(tb, cn1, "EMPRESA", "MAEEDO", "IDMAEEDO = " & IDMAEEDO)

        'Dim Ubicacion As String = trae_dato(tb, cn1, "DATOSUBIC", "TABBOPR", "EMPRESA = '" & Empresa & "'" & _
        '                                            " AND KOSU = '" & Sucursal & "' AND KOBO = '" & Bodega & "' AND KOPR = '" & CodProducto & "'")

        Consulta_sql = "INSERT INTO " & TablaDePaso & "(Empresa,Sucursal,Bodega,CodProducto,Descripcion,Cantidad) " & _
                       "SELECT EMPRESA,SULIDO,BOSULIDO,KOPRCT,NOKOPR,CAPRCO1 FROM MAEDDO WHERE IDMAEEDO = " & IDMAEEDO
        Ej_consulta_IDU(Consulta_sql, cn1)

        Consulta_sql = "UPDATE " & TablaDePaso & " SET " & TablaDePaso & ".Ubicacion = ISNULL(TABBOPR.DATOSUBIC,'')" & _
                       "FROM " & TablaDePaso & " LEFT OUTER JOIN" & vbCrLf & _
                       "TABBOPR ON " & TablaDePaso & ".Empresa = TABBOPR.EMPRESA AND " & TablaDePaso & ".Sucursal = TABBOPR.KOSU AND " & _
                       "" & TablaDePaso & ".Bodega = TABBOPR.KOBO AND " & TablaDePaso & ".CodProducto = TABBOPR.KOPR"
        Ej_consulta_IDU(Consulta_sql, cn1)

        Consulta_sql = "UPDATE dbo." & TablaDePaso & " SET dbo." & TablaDePaso & ".CodProductoProveedor = dbo.TABCODAL.KOPRAL" & vbCrLf & _
                       "FROM dbo." & TablaDePaso & " LEFT OUTER JOIN" & vbCrLf & _
                       "dbo.TABCODAL ON dbo." & TablaDePaso & ".CodProducto = dbo.TABCODAL.KOPR" & vbCrLf & _
                       "WHERE (dbo.TABCODAL.KOEN = '" & CodEntidad & "')"
        Ej_consulta_IDU(Consulta_sql, cn1)


        Return Cuenta_registros(TablaDePaso, "CodProducto <> ''")

    End Function

    Function CrearDetalleParaGenerarEtiquetasDeBarraPorProducto(ByVal EMPRESA As String, _
                                                                ByVal SUCURSAL As String, _
                                                                ByVal BODEGA As String, _
                                                                ByVal Codigo As String, _
                                                                ByVal TablaDePaso As String) As Long


        Dim Ubicacion As String = trae_dato(tb, cn1, "DATOSUBIC", "TABBOPR", "EMPRESA = '" & EMPRESA & "'" & _
                                                    " AND KOSU = '" & SUCURSAL & _
                                                    "' AND KOBO = '" & BODEGA & "' AND KOPR = '" & Codigo & "'")


        Consulta_sql = "INSERT INTO " & TablaDePaso & "(Empresa,Sucursal,Bodega,CodProducto,Descripcion,Cantidad,Ubicacion) " & _
                       "SELECT '" & EMPRESA & "','" & SUCURSAL & "','" & BODEGA & "',KOPR,NOKOPR,0,'" & Ubicacion & "' FROM MAEPR WHERE KOPR = '" & Codigo & "'"
        Ej_consulta_IDU(Consulta_sql, cn1)

        'Return Cuenta_registros(TablaDePaso, "CodProducto <> ''")


    End Function

    Function CrearTablaDePaso(ByVal TablaDePaso As String)
        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='" & TablaDePaso & "') BEGIN " & _
                               "DROP TABLE " & TablaDePaso & " End"
        Ej_consulta_IDU(Consulta_sql, cn1)

        Consulta_sql = "CREATE TABLE [dbo].[" & TablaDePaso & "](" & vbCrLf & _
                       "[Idmaeddo] [int] IDENTITY(1,1) NOT NULL," & vbCrLf & _
                       "[Seleccion] [bit]," & vbCrLf & _
                       "[Empresa] [varchar](2) NULL," & vbCrLf & _
                       "[Sucursal] [varchar](3) NULL," & vbCrLf & _
                       "[Bodega] [varchar](3) NULL," & vbCrLf & _
                       "[CodProducto] [varchar](13) NULL," & vbCrLf & _
                       "[CodProductoProveedor] [varchar](20) NULL," & vbCrLf & _
                       "[Descripcion] [varchar](50) NULL," & vbCrLf & _
                       "[Cantidad] [float] NULL," & vbCrLf & _
                       "[Ubicacion] [Varchar] (20) NULL," & vbCrLf & _
                       "CONSTRAINT [PK" & TablaDePaso & "] PRIMARY KEY CLUSTERED ([Idmaeddo] Asc)" & vbCrLf & _
                       "WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & vbCrLf & _
                       ") ON [PRIMARY]" ' & vbCrLf & "GO" & vbCrLf & "SET ANSI_PADDING OFF" & vbCrLf & "GO"

        Ej_consulta_IDU(Consulta_sql, cn1)
    End Function

    Function EliminarDatosTblBarras()

        TablaDePaso = "Zw_TmpTblDocBarras" & FUNCIONARIO
        Consulta_sql = "TRUNCATE TABLE " & TablaDePaso
        Ej_consulta_IDU(Consulta_sql, cn1)

    End Function



    Function BuscarDatoEnGrilla(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView) As Boolean
        Dim encontrado As Boolean = False
        If TextoABuscar = String.Empty Then Return False
        If grid.RowCount = 0 Then Return False
        grid.ClearSelection()
        If Columna = String.Empty Then
            For Each row As DataGridViewRow In grid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Value.ToString() = TextoABuscar Then
                        row.Selected = True
                        Return True
                    End If
                Next
            Next
        Else
            Dim Descripcion As String
            For Each row As DataGridViewRow In grid.Rows
                If row.IsNewRow Then Return False
                Descripcion = Trim(row.Cells(Columna).Value.ToString())

                If BuscarTextoGrilla(Descripcion, TextoABuscar) = True Then
                    grid.ClearSelection()
                    grid.CurrentCell = grid.Rows(row.Index.ToString).Cells(1)
                    grid.Refresh()
                    row.Selected = True
                    Return True
                End If

            Next
        End If
        Return encontrado
    End Function


    Private Function BuscarTextoGrilla(ByVal Texto As String, ByVal Busqueda As String) As Boolean
        Dim i As Integer
        i = InStr(1, Texto, Busqueda)
        If i > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
