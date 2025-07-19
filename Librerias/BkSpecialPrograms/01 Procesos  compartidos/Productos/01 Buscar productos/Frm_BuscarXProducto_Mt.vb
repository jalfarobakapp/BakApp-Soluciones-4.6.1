'Imports Lib_Bakapp_VarClassFunc
Imports System.Data
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar


Public Class Frm_BuscarXProducto_Mt


    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim TABLABS As String
    Dim Tipobusqueda As Integer = 0
    Dim Celdaseleccionada As Integer
    Dim OcultarPr As String = ""
    Dim QsqlExcel As String

    Public ListaDePrecio As String

    Public EmpresaPr As String = Mod_Empresa
    Public SucursarPr As String = Mod_Sucursal
    Public BodegaPr As String = Mod_Bodega

    Public CodProducto_Sel As String
    Public DesProductos_sel As String
    Public MostrarOcultos As Boolean = False
    Public SisCompras As Boolean = False

    Public CodProveedor_productos As String
    Public Tipo_Busqueda_Productos As Integer

    Public CodigoPr_Sel As String
    Public CodigoAl_Sel As String

    Public _CodProveedor_Alt, _
           _CodSucProveedor_Alt As String

    Public _Tbl_Inf_Producto As DataTable
    Public _Trabajar_Codigos_Alternativos As Boolean

    Public _CodigosReemplazo As Boolean
    Public _Desde_Maestro As Boolean

    Dim _ListaPrecio_BusquedaPR As String

    Public Property Pro_TABLABS As String
        Get
            Return TABLABS
        End Get
        Set(value As String)
            TABLABS = value
        End Set
    End Property

    Public Property Pro_ListaPrecio_BusquedaPR As String
        Get
            Return _ListaPrecio_BusquedaPR
        End Get
        Set(value As String)
            _ListaPrecio_BusquedaPR = value
        End Set
    End Property

    Public Enum Buscar_En
        Maestro_de_Productos
        Codigos_Alternativos
    End Enum



    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        'Txtcodigo.Focus()
        Codigo_abuscar = String.Empty
        CodigoPr_Sel = String.Empty
        CodigoAl_Sel = String.Empty
        Me.Close()
    End Sub

    Private Sub Txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcodigo.TextChanged
        'BUSCA()
        Proceso_Busqueda()
    End Sub

    Function BUSCA()
        VerTablaBusqueda()
        Dim DESCR As String
        If Radio1.Checked = True Then DESCR = "NOKOPR"
        If Radio2.Checked = True Then
            DESCR = "NOKOPRAL"
        End If

        buscar(RTrim$(Txtcodigo.Text),
               CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text),
                               DESCR & " LIKE '%"), 1, TABLABS, _ListaPrecio_BusquedaPR)

    End Function


    Sub Proceso_Busqueda()

        Dim Campo_B As String
        If Tipo_Busqueda_Productos = Buscar_En.Codigos_Alternativos Then
            Campo_B = "KOPRAL+KOPR+NOKOPRAL"
        ElseIf Tipo_Busqueda_Productos = Buscar_En.Maestro_de_Productos Then
            Campo_B = "MP.KOPR+MP.KOPRTE+MP.NOKOPR"
        End If

        Dim Datos_a_buscar As String
        Datos_a_buscar = CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text), Campo_B & " LIKE '%")

        Buscar_Productos(Datos_a_buscar,
                         Tipo_Busqueda_Productos, _ListaPrecio_BusquedaPR,
                         MostrarOcultos, SisCompras)



    End Sub

    Function VerTablaBusqueda()
        If TABLABS <> "MAEPROCU" Then
            If TABLABS = "ProductosCompra" Then
                Radio1.Visible = False
                Radio2.Visible = False
            Else
                If Radio1.Checked = True Then TABLABS = "MAEPR"
                If Radio2.Checked = True Then TABLABS = "TABCODAL"
            End If
        End If
    End Function

    Function buscar(ByVal codigo As String, _
                    ByVal descripcion As String, _
                    ByVal condi As Integer, _
                    ByVal Tabla As String, _
                    ByVal Lista As String)

        Dim CONDICION As String = ""

        If Tabla = "MAEPR" Then

            If condi = 1 Then
                CONDICION = "WHERE dbo.MAEPR.KOPR LIKE '" & codigo & "%' " & _
                            "AND dbo.MAEPR.NOKOPR  LIKE '%" & descripcion & "%' " & vbCrLf & _
                            "AND (dbo.TABPRE.KOLT = '" & Lista & "')" & vbCrLf & _
                            "AND (dbo.TABBOPR.EMPRESA = '" & EmpresaPr & "') AND " & vbCrLf & _
                            "(dbo.TABBOPR.KOSU = '" & SucursarPr & "') AND (dbo.TABBOPR.KOBO = '" & BodegaPr & "')" & vbCrLf & _
                            OcultarPr & vbCrLf & _
                            "Order by dbo.MAEPR.KOPR OPTION ( FAST 20 )"

                CONDICION = "WHERE MP.KOPR LIKE '" & codigo & "%' AND MP.NOKOPR  LIKE '%" & descripcion & "%'" & vbCrLf & _
                             "Order by MP.KOPR OPTION ( FAST 20 ) "

                'WHERE (dbo.MAEPR.KOPR LIKE '%') AND (dbo.MAEPR.NOKOPR LIKE '%%') AND (dbo.TABPRE.KOLT = '01P')
                ' AND (dbo.TABBOPR.EMPRESA = '01') AND 
                '(dbo.TABBOPR.KOSU = 'CM') AND (dbo.TABBOPR.KOBO = '001')
                'ORDER BY dbo.MAEPR.KOPR

            Else
                CONDICION = "WHERE ATPR = '' ORDER BY KOPR"
            End If

            Consulta_sql = "SELECT TOP (100) dbo.MAEPR.KOPR, dbo.MAEPR.NOKOPR,dbo.MAEST.STFI1, " & _
                           "ISNULL(dbo.TABPRE.PP01UD, 0) AS PP01UD" & vbCrLf & _
                           "FROM dbo.MAEST RIGHT OUTER JOIN dbo.TABBOPR ON dbo.MAEST.KOPR = dbo.TABBOPR.KOPR" & vbCrLf & _
                           "AND dbo.MAEST.EMPRESA = dbo.TABBOPR.EMPRESA AND " & vbCrLf & _
                           "dbo.MAEST.KOBO = dbo.TABBOPR.KOBO RIGHT OUTER JOIN" & vbCrLf & _
                           "dbo.MAEPR WITH (NOLOCK) ON dbo.TABBOPR.KOPR = dbo.MAEPR.KOPR LEFT OUTER JOIN" & vbCrLf & _
                           "dbo.TABPRE ON dbo.MAEPR.KOPR = dbo.TABPRE.KOPR" & vbCrLf & CONDICION

            Consulta_sql = "SELECT TOP (100) MP.KOPR, MP.NOKOPR," & vbCrLf & _
                           "ISNULL((SELECT STFI1 FROM MAEST WHERE EMPRESA = '" & EmpresaPr & _
                           "' AND KOSU = '" & SucursarPr & "' AND KOBO = '" & BodegaPr & _
                           "' AND KOPR = MP.KOPR),0)" & vbCrLf & _
                           "AS STFI1," & vbCrLf & _
                           "ISNULL((SELECT PP01UD FROM TABPRE WHERE KOLT = '" & Lista & "' AND KOPR = MP.KOPR),0)" & vbCrLf & _
                           "AS PP01UD" & vbCrLf & _
                           "FROM MAEPR MP" & vbCrLf & CONDICION

            '"FROM dbo.MAEPR WITH (NOLOCK) LEFT OUTER JOIN dbo.TABPRE ON " & _
            ' "dbo.MAEPR.KOPR = dbo.TABPRE.KOPR" & vbCrLf & CONDICION

        ElseIf Tabla = "MAEPROCU" Then
            If condi = 1 Then

                'CONDICION = "WHERE dbo.MAEPR.KOPR LIKE '" & codigo & "%' " & _
                '            "AND dbo.MAEPR.NOKOPR  LIKE '%" & descripcion & "%' " & vbCrLf & _
                '            "Order by dbo.MAEPR.KOPR OPTION ( FAST 20 )"


                CONDICION = "WHERE dbo.MAEPR.KOPR LIKE '" & codigo & "%' " & _
                            "AND dbo.MAEPR.NOKOPR  LIKE '%" & descripcion & "%' " & vbCrLf & _
                            "AND (dbo.TABPRE.KOLT = '" & Lista & "')" & vbCrLf & _
                            "AND (dbo.TABBOPR.EMPRESA = '" & EmpresaPr & "') AND " & vbCrLf & _
                            "(dbo.TABBOPR.KOSU = '" & SucursarPr & "') AND (dbo.TABBOPR.KOBO = '" & BodegaPr & "')" & vbCrLf & _
                            "OR (dbo.MAEPR.ATPR = 'OCU') AND" & vbCrLf & _
                            "dbo.MAEPR.KOPR LIKE '" & codigo & "%' " & _
                            "AND dbo.MAEPR.NOKOPR  LIKE '%" & descripcion & "%'" & vbCrLf & _
                            "Order by dbo.MAEPR.KOPR OPTION ( FAST 20 )"

            Else
                CONDICION = "ORDER BY KOPR"
            End If


            Consulta_sql = "SELECT DISTINCT TOP (100) dbo.MAEPR.KOPR, dbo.MAEPR.NOKOPR,  ISNULL(dbo.MAEST.STFI1, 0) AS STFI1,dbo.MAEPR.ATPR," & _
                           "ISNULL(dbo.TABPRE.PP01UD, 0) AS PP01UD" & vbCrLf & _
                           "FROM dbo.MAEST RIGHT OUTER JOIN dbo.TABBOPR ON dbo.MAEST.KOPR = dbo.TABBOPR.KOPR" & vbCrLf & _
                           "AND dbo.MAEST.EMPRESA = dbo.TABBOPR.EMPRESA AND " & vbCrLf & _
                           "dbo.MAEST.KOBO = dbo.TABBOPR.KOBO RIGHT OUTER JOIN" & vbCrLf & _
                           "dbo.MAEPR WITH (NOLOCK) ON dbo.TABBOPR.KOPR = dbo.MAEPR.KOPR LEFT OUTER JOIN" & vbCrLf & _
                           "dbo.TABPRE ON dbo.MAEPR.KOPR = dbo.TABPRE.KOPR" & vbCrLf & CONDICION


        ElseIf Tabla = "TABCODAL" Then

            If condi = 1 Then
                CONDICION = "AND KOPRAL LIKE '" & codigo & "%' " & _
                            "AND NOKOPRAL  LIKE '%" & descripcion & "%' order by NOKOPRAL OPTION ( FAST 20 )"
            End If


            Consulta_sql = "SELECT TOP (100) KOPRAL ,KOPR , NOKOPRAL," & vbCrLf & _
                           "ISNULL((SELECT STFI1 FROM MAEST WHERE EMPRESA = '" & Mod_Empresa & "' AND KOSU = 'CM' AND KOBO = '001' AND KOPR = MP.KOPR),0)" & vbCrLf & _
                           "AS STFI1," & vbCrLf & _
                           "ISNULL((SELECT PP01UD FROM TABPRE WHERE KOLT = '" & Mod_ListaPrecioVenta & "' AND KOPR = MP.KOPR),0)" & vbCrLf & _
                           "AS PP01UD" & vbCrLf & _
                           "FROM TABCODAL AS MP WITH (NOLOCK)" & vbCrLf & _
                            "WHERE (KOEN like '%" & _CodProveedor_Alt & "%')" & CONDICION

        ElseIf Tabla = "ProductosCompra" Then

            Dim _CodEntidad

            Consulta_sql = "Select Codigo as KOPR,CodAlternativo as KOPRAL," & vbCrLf &
                           "(Select top 1 NOKOPR From MAEPR Where KOPR = Codigo) as NOKOPRAL," & vbCrLf &
                           "CostoUd1 as PP01UD," & vbCrLf &
                           "ISNULL((SELECT STFI1 FROM MAEST WHERE EMPRESA = '" & EmpresaPr &
                           "' AND KOSU = '" & SucursarPr & "' AND KOBO = '" & BodegaPr & "' AND KOPR = Codigo),0) as STFI1" & vbCrLf &
                           "FROM Zw_ListaPreCosto" & vbCrLf &
                           "Where Proveedor = '" & _CodEntidad & "' and Lista = '" & ListaDePrecio & "'"


        ElseIf Tabla = "TABCODALMAEPR" Then

            Dim Conteo As Long = Val(_Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & codigo & "'"))
            If Conteo = 0 Then

                If condi = 1 Then
                    CONDICION = "WHERE KOPR LIKE '" & codigo & "%' " & _
                                "AND NOKOPR  LIKE '%" & descripcion & "%' AND ATPR = '' order by KOPR OPTION ( FAST 20 )"
                Else
                    CONDICION = "WHERE ATPR = '' ORDER BY KOPR"
                End If
                Consulta_sql = "SELECT TOP (100) KOPR, NOKOPR FROM MAEPR WITH (NOLOCK) " & CONDICION

            Else

                If condi = 1 Then
                    CONDICION = " KOPRAL LIKE '" & codigo & "%' " & _
                                "AND NOKOPRAL  LIKE '%" & descripcion & "%' OPTION ( FAST 20 )"
                End If
                Consulta_sql = "SELECT TOP (100) KOPRAL,KOPR, NOKOPRAL FROM TABCODAL WITH (NOLOCK) " & _
                                "WHERE " & CONDICION

            End If
        End If

        QsqlExcel = Replace(Consulta_sql, "TOP (100)", "")
        Grilla.DataSource = _SQL.Fx_Get_DataTable(Consulta_sql)
        FormatoGrilla(Grilla, Tabla)

    End Function

    Function Buscar_Productos(ByVal Descripcion As String, _
                              ByVal Tipo_Busqueda As String, _
                              ByVal Lista As String, _
                              Optional ByVal Muestra_Ocultos As Boolean = False, _
                              Optional ByVal Compra As Boolean = False)

        Dim CONDICION As String = String.Empty

        If Tipo_Busqueda_Productos = Buscar_En.Maestro_de_Productos Then

            If Not Muestra_Ocultos Then
                CONDICION = "And MP.ATPR = ''"
            End If

            Consulta_sql = "SELECT TOP (1000) MP.KOPR as Codigo,'' as CodAlternativo, LTRIM(RTRIM(MP.NOKOPR)) as Descripcion," & vbCrLf & _
                           "ISNULL((SELECT STFI1 FROM MAEST WHERE EMPRESA = '" & EmpresaPr & "'" & vbCrLf & _
                           "AND KOSU = '" & SucursarPr & "' AND KOBO = '" & BodegaPr & "'" & vbCrLf & _
                           "AND KOPR = MP.KOPR),0) AS StockFiUd1," & vbCrLf & _
                           "ISNULL((SELECT PP01UD FROM TABPRE WHERE KOLT = '" & Lista & "' AND KOPR = MP.KOPR),0)" & vbCrLf & _
                           "AS PrecioUD1,MP.ATPR as Oculto" & vbCrLf & _
                           "FROM MAEPR MP" & vbCrLf & _
                           "WHERE MP.KOPR+MP.KOPRTE+MP.NOKOPR LIKE '%" & Descripcion & "%'" & vbCrLf & _
                           CONDICION & vbCrLf & _
                           "Order by MP.KOPR OPTION ( FAST 20 )"

        ElseIf Tipo_Busqueda_Productos = Buscar_En.Codigos_Alternativos Then

            Consulta_sql = "SELECT TOP (1000) KOPR as Codigo, KOPRAL as CodAlternativo,KOEN, NOKOPRAL as Descripcion," & vbCrLf & _
                           "ISNULL((SELECT STFI1 FROM MAEST WHERE EMPRESA = '" & EmpresaPr & _
                           "' AND KOSU = '" & SucursarPr & "' AND KOBO = '" & BodegaPr & _
                           "' AND KOPR = MP.KOPR),0)" & vbCrLf & _
                           "AS StockFiUd1," & vbCrLf & _
                           "ISNULL((SELECT PP01UD FROM TABPRE WHERE KOLT = '" & Lista & "' AND KOPR = MP.KOPR),0)" & vbCrLf & _
                           "AS PrecioUD1,'' as Oculto," & vbCrLf & _
                           "ISNULL((Select top 1 NOKOEN From MAEEN Where KOEN = MP.KOEN),'') as Proveedor" & vbCrLf & _
                           "FROM TABCODAL AS MP WITH (NOLOCK)" & vbCrLf & _
                           "WHERE (KOEN LIKE '%" & _CodProveedor_Alt & "%')" & vbCrLf & _
                           "AND KOPRAL+KOPR+NOKOPRAL LIKE '%" & Descripcion & "%' order by NOKOPRAL OPTION ( FAST 20 )"

            If Compra Then

                Consulta_sql = "Select Codigo as KOPR,CodAlternativo as KOPRAL," & vbCrLf & _
                               "(Select top 1 NOKOPR From MAEPR Where KOPR = Codigo) as NOKOPRAL," & vbCrLf & _
                               "CostoUd1 as PP01UD," & vbCrLf & _
                               "ISNULL((SELECT STFI1 FROM MAEST WHERE EMPRESA = '" & EmpresaPr & _
                               "' AND KOSU = '" & SucursarPr & "' AND KOBO = '" & BodegaPr & "' AND KOPR = Codigo),0) as STFI1" & vbCrLf & _
                               "FROM Zw_ListaPreCosto" & vbCrLf & _
                               "Where Proveedor = '" & _CodProveedor_Alt & "' and Lista = '" & ListaDePrecio & "'"

            End If

        End If

        QsqlExcel = Replace(Consulta_sql, "TOP (100)", "")

        With Grilla

            .DataSource = _SQL.Fx_Get_DataTable(Consulta_sql)
            OcultarEncabezadoGrilla(Grilla, True)

            Dim LgDescripcion As Integer

            If Tipo_Busqueda_Productos = Buscar_En.Maestro_de_Productos Then
                .Columns("CodAlternativo").Visible = False
                LgDescripcion = 490
            ElseIf Tipo_Busqueda_Productos = Buscar_En.Codigos_Alternativos Then
                .Columns("KOEN").Width = 100
                .Columns("KOEN").HeaderText = "Entidad"
                .Columns("KOEN").Visible = True

                .Columns("CodAlternativo").Width = 100
                .Columns("CodAlternativo").HeaderText = "Cód. Alternativo"
                '.Columns("Proveedor").Visible = False
                .Columns("CodAlternativo").Visible = True

                LgDescripcion = 290
            End If

            .Columns("Oculto").Visible = False
            .Columns("Codigo").Width = 110
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True

            .Columns("Descripcion").Width = LgDescripcion + 60 + 70
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

            '.Columns("StockFiUd1").Width = 60
            '.Columns("StockFiUd1").HeaderText = "Stock " & BodegaPr
            '.Columns("StockFiUd1").DefaultCellStyle.Format = "###,##"
            '.Columns("StockFiUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '.Columns("PrecioUD1").Width = 70
            '.Columns("PrecioUD1").HeaderText = "Precio"
            '.Columns("PrecioUD1").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("PrecioUD1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            Dim i = 0
            For Each row As DataGridViewRow In .Rows
                Dim Pr_Oculto As String = NuloPorNro(row.Cells("Oculto").Value, "")
                If Pr_Oculto = "OCU" Then

                    .Rows.Item(i).DefaultCellStyle.ForeColor = Color.Red
                    '.Rows(i).Cells("Oculto").Style.ForeColor = Color.Red
                End If
                i += 1
            Next


        End With



    End Function


    Private Function FormatoGrilla(ByVal Grilla As DataGridView, _
                                   ByVal Tabla As String)


        With Grilla
            '.Columns("IdDetalle").Visible = False
            Try

                '.RowTemplate.Height = 15
                '.DefaultCellStyle.Font = New Font("Tahoma", 8)
                '.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod


                'Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue)

                If Tabla = "MAEPR" Or Tabla = "MAEPROCU" Then

                    .Columns("KOPR").Width = 100
                    .Columns("KOPR").HeaderText = "Código"

                    .Columns("NOKOPR").Width = 350
                    .Columns("NOKOPR").HeaderText = "Descripción"

                    .Columns("STFI1").Width = 80
                    .Columns("STFI1").HeaderText = "Stock " & BodegaPr
                    .Columns("STFI1").DefaultCellStyle.Format = "###,##"
                    .Columns("STFI1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    If Tabla = "MAEPROCU" Then
                        .Columns("ATPR").Width = 50
                        .Columns("ATPR").HeaderText = "Estado"
                        .Columns("ATPR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If

                    .Columns("PP01UD").Width = 80
                    .Columns("PP01UD").HeaderText = "Precio"
                    .Columns("PP01UD").DefaultCellStyle.Format = "$ ###,##"
                    .Columns("PP01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                ElseIf Tabla = "TABCODALMAEPR" Or Tabla = "TABCODAL" Or Tabla = "ProductosCompra" Then

                    .Columns("KOPR").Width = 100
                    .Columns("KOPR").HeaderText = "Código"

                    .Columns("NOKOPRAL").Width = 370
                    .Columns("NOKOPRAL").HeaderText = "Descripción"

                    .Columns("KOPRAL").Width = 110
                    .Columns("KOPRAL").HeaderText = "Código Alt."

                    .Columns("STFI1").Width = 80
                    .Columns("STFI1").HeaderText = "Stock " & BodegaPr
                    .Columns("STFI1").DefaultCellStyle.Format = "###,##"
                    .Columns("STFI1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    .Columns("PP01UD").Width = 80
                    .Columns("PP01UD").HeaderText = "Precio"
                    .Columns("PP01UD").DefaultCellStyle.Format = "$ ###,##"
                    .Columns("PP01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                End If

                '.Columns("Brutolinea").DefaultCellStyle.Format = "$ ###,##"
                '.Columns("Brutolinea").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'TotalNeto = Math.Round(Val(SumarDatodeGrilla("Netolinea", Grilla)), 2)
                'TotalIva = Math.Round(TotalNeto * 0.19, 0)

            Catch ex As Exception

            End Try


        End With

    End Function

    Private Sub Txtcodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcodigo.KeyDown
        Dim Kode As String
        Kode = e.KeyValue


        If Kode = Keys.Enter.ToString Then ' e.KeyCode = 112 Then                   ' F1
            ' ' Instrucción para ejecutar el código correspondiente a la tecla F1
            e.Handled = True
            Txtdescripcion.Focus()

        ElseIf Kode = Keys.Down Then               ' F2
            ' Instrucción para ejecutar el código correspondiente a la tecla F2
            e.Handled = True
            Grilla.Focus()
        End If
    End Sub

    

    Private Sub Txtdescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtdescripcion.KeyDown
        Dim Kode As String
        Kode = e.KeyValue


        If Kode = Keys.Enter Then ' e.KeyCode = 112 Then                   ' F1
            ' ' Instrucción para ejecutar el código correspondiente a la tecla F1
            e.Handled = True
            If Grilla.RowCount > 0 Then
                Grilla.Focus()
                Grilla.CurrentCell = Grilla.Rows(0).Cells(0)
            End If
        ElseIf Kode = Keys.Down Then               ' F2
            ' Instrucción para ejecutar el código correspondiente a la tecla F2
            e.Handled = True
            Grilla.Focus()
        End If
    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        'BUSCA()
        Proceso_Busqueda()
        Grilla.ClearSelection()
    End Sub

    Sub Sb_Seleccionar_Producto()
        _Tbl_Inf_Producto = Nothing



        If Radio1.Checked = True Then
            Codigo_abuscar = Grilla.Rows(Grilla.CurrentRow.Index).Cells(0).Value
            DesProductos_sel = Grilla.Rows(Grilla.CurrentRow.Index).Cells(2).Value
        Else
            Codigo_abuscar = Grilla.Rows(Grilla.CurrentRow.Index).Cells(1).Value
            DesProductos_sel = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NOKOPRAL").Value
        End If


        CodigoPr_Sel = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value)
        CodigoAl_Sel = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("CodAlternativo").Value)

        CodProducto_Sel = Codigo_abuscar

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & CodigoPr_Sel & "'"
        _Tbl_Inf_Producto = _SQL.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Try

            Sb_Seleccionar_Producto()

            If _Trabajar_Codigos_Alternativos Then

                If Fx_Tiene_Permiso(Me, "Prod020") Then

                    If Not String.IsNullOrEmpty(Trim(CodProducto_Sel)) Then
                        Dim Fm_A As New Frm_CodAlternativo_Ver
                        Fm_A.TxtCodigo.Text = CodProducto_Sel
                        Fm_A.Txtdescripcion.Text = _Tbl_Inf_Producto.Rows(0).Item("NOKOPR")
                        Fm_A.TxtRTU.Text = _Tbl_Inf_Producto.Rows(0).Item("RLUD")
                        Fm_A.ShowDialog(Me)
                    End If

                End If

            ElseIf _CodigosReemplazo Then

                Dim Fm_R As New Frm_ProductosReemplazo(_Tbl_Inf_Producto.Rows(0).Item("KOPR"))
                Fm_R.ShowDialog(Me)
                Fm_R.Dispose()

            ElseIf _Desde_Maestro Then ' EDITAR PRODUCTO
                'Sb_Editar_Producto(_Tbl_Inf_Producto)
            Else
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   

    Private Sub Frm_BuscarXProducto_Mt_Mt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Proceso_Busqueda()
        Me.ActiveControl = Txtdescripcion
        
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'EstiloFormulario(StyleManager1)
       Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)


    End Sub

    Private Sub BtnBusAlternativas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusAlternativas.Click


        Dim Fm As New Frm_BuscarXProducto_Mt
        Fm.CodProveedor_productos = String.Empty
        Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Codigos_Alternativos
        Fm.ListaDePrecio = Mod_ListaPrecioVenta
        Fm.CodProveedor_productos = String.Empty

        Dim Razon As String = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & CodProveedor_productos & "'")

        Fm.Text = "Busqueda de códigos alternativos" & " - " & Razon

        Fm.ShowDialog(Me)
        Codigo_abuscar = Fm.CodigoPr_Sel
        Txtdescripcion.Text = Codigo_abuscar
        Proceso_Busqueda()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter
        If Tipo_Busqueda_Productos = Buscar_En.Codigos_Alternativos Then
            Dim _Proveedor = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Proveedor").Value
            Me.Text = "Busqueda de códigos alternativos" & " - " & NuloPorNro(Trim(_Proveedor), "")
        End If

    End Sub



    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown


        If e.KeyValue = Keys.Tab Then
            Txtdescripcion.SelectAll()
            Txtdescripcion.Focus()

        ElseIf e.KeyValue = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{LEFT}")


            If Radio1.Checked = True Then
                Codigo_abuscar = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value)
            Else
                Codigo_abuscar = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("CodAlternativo").Value)
            End If

            CodigoPr_Sel = Codigo_abuscar
            Consulta_sql = "Select * From MAEPR Where KOPR = '" & CodigoPr_Sel & "'"
            _Tbl_Inf_Producto = _SQL.Fx_Get_DataTable(Consulta_sql)
            Me.Close()

        End If


    End Sub

    Private Sub BtnExportaExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportaExcel.Click
        ExportarTabla_JetExcel(QsqlExcel, Me)
    End Sub


    Private Sub Grilla_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grilla.Leave
        Grilla.ClearSelection()
        BtnEditarProducto.Enabled = False
    End Sub


    Private Sub DddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_VerEstadisticas.Click

        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.ShowDialog(Me)

    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    BtnEditarProducto.Enabled = CBool(Grilla.RowCount)
                    Codigo_abuscar = NuloPorNro(.Rows(.CurrentRow.Index).Cells("Codigo").VALUE, "")
                Else
                    Codigo_abuscar = String.Empty
                End If


                If String.IsNullOrEmpty(Codigo_abuscar) Then
                    MenuContextual.Enabled = False
                Else
                    MenuContextual.Enabled = True
                End If
            End With
        End If
    End Sub

    Private Sub Frm_BuscarXProducto_Mt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Codigo_abuscar = String.Empty
            CodigoPr_Sel = String.Empty
            CodigoAl_Sel = String.Empty
            Me.Close()
        End If
    End Sub

   



    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Seleccionar_Producto()
        'Sb_Editar_Producto(_Tbl_Inf_Producto)
    End Sub

    Private Sub BtnEditarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditarProducto.Click
        Sb_Seleccionar_Producto()
        'Sb_Editar_Producto(_Tbl_Inf_Producto)
    End Sub

   
End Class