'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_InvMargenes_

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Ds_Informe As DataSet
    Dim _Dv_Productos As New DataView
    Dim _Dv_Asociaciones As New DataView

    Dim TblMargen As String = "Zw_TblMargen" & FUNCIONARIO
    Dim TblMrgProductos As String = "Zw_TblMrgProductos" & FUNCIONARIO
    Dim TblInfMargenes As String = "TblInfMargenes" & FUNCIONARIO

    Dim _TblFiltroProductos As DataTable
    Dim _TblFiltroDocumentos As DataTable
    Dim _TblFiltroSucursal As DataTable
    Dim _TblFiltroFuncionarios As DataTable

    Dim _FiltroDocumentos As String
    Dim _FiltroFuncionarios As String
    Dim _FiltroSucursales As String
    Dim _FiltroProductos As String
    Dim _FiltroEntExcluidas As String

    Public Datos As New DsFiltros

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Mrg_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Mrg_Asociaciones, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Mrg_Super_Familias, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Mrg_Vendedores, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Mrg_Empresa, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Mrg_Sucursal_Linea, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Mrg_Bodega, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        AddHandler Grilla_Mrg_Asociaciones.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Mrg_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Color_Botones_Barra(Bar1)
        Chk_Solo_Productos_Con_Descuento.Enabled = True

    End Sub

    Private Sub Frm_InvMargenes__Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        caract_combo(CmbListaDeCostos)
        Consulta_Sql = "Select KOLT As Padre,KOLT+'-'+NOKOLT As Hijo From TABPP Where TILT = 'C'"
        CmbListaDeCostos.DataSource = _Sql.Fx_Get_DataTable(Consulta_Sql)

        caract_combo(Cmb_Clasificaciones)
        Consulta_Sql = "Select Codigo_Nodo As Padre,Descripcion As Hijo 
                        From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = 0 And Clas_Unica_X_Producto = 1 "
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Cmb_Clasificaciones.DataSource = _Tbl
        Grupo_Clasificaciones.Enabled = CBool(_Tbl.Rows.Count)
        Chk_Incluye_Clasificaciones.Checked = CBool(_Tbl.Rows.Count)

        If CBool(_Tbl.Rows.Count) Then
            Cmb_Clasificaciones.SelectedValue = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")
        End If


        CmbListaDeCostos.Enabled = False
        DFechaInicio.Value = Primerdiadelmes(Date.Now)
        DFechaTermino.Value = ultimodiadelmes(DFechaInicio.Value)
        BtnFl_Funcionarios.Enabled = True

        _TblFiltroProductos = Datos.Tables("Filtro")

        Tab_ResumenProd.Visible = False
        Tab_Clasificaciones_Bk.Visible = False
        Tab_Vendedores.Visible = False
        Tab_Super_Familias.Visible = False
        Tab_Empresa.Visible = False
        Tab_Sucursal_Detalle.Visible = False
        Tab_Bodega.Visible = False

        Btn_Excel_Detalle.Visible = False
        Btn_Excel_Resumen.Visible = False
        Btn_Estadisticas_Margen.Visible = False

        'Lbl_Nodo_Raiz_Asociados.Tag = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")
        'Lbl_Nodo_Raiz_Asociados.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion", "Codigo_Nodo = " & Lbl_Nodo_Raiz_Asociados.Tag)


        Chk_Excluir_Entidades.Checked = True

        Me.Refresh()

    End Sub

    Private Sub DFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DFechaInicio.ValueChanged
        DFechaTermino.Value = ultimodiadelmes(DFechaInicio.Value)
    End Sub

    'Private Sub BtnExcelResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcelResumen.Click
    '    'Consulta_Sql = "Select Koprct, Nokopr, Documentos, CantidadUd1, TotalCosto, TotalPrecio, " & vbCrLf &
    '    '               "Total_Mrg, cast(Porc_Markup as decimal(10,2)) as Porc_Markup," & vbCrLf &
    '    '               "cast(Porc_Margen as decimal(10,2)) as Porc_Margen," & vbCrLf &
    '    '               "Marca,Nom_Marca,ClasLibre,Nom_ClasLibre,Zona,Nom_Zona,Rubro,Nom_Rubro," & vbCrLf &
    '    '               "SuperFamilia,Familia,SubFamilia,Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia" & vbCrLf &
    '    '               "From " & TblMrgProductos 'Zw_TblMrgProductos" & FUNCIONARIO
    '    'ExportarTabla_JetExcel(Consulta_Sql, Me)
    'End Sub


    Sub Sb_Formato_Grilla_Productos(Grilla As DataGridView)

        With Grilla

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("Koprct").Width = 100
            .Columns("Koprct").HeaderText = "Código"
            .Columns("Koprct").Visible = True

            .Columns("Nokopr").Width = 360
            .Columns("Nokopr").HeaderText = "Descripción"
            .Columns("Nokopr").Visible = True

            .Columns("CantidadUd1").Width = 60
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##"
            .Columns("CantidadUd1").Visible = True

            .Columns("TotalCosto").Width = 90
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True

            .Columns("TotalPrecio").Width = 90
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True

            .Columns("Total_Mrg").Width = 90
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True

            '.Columns("Porc_Margen").Width = 70
            '.Columns("Porc_Margen").HeaderText = "Margen Costo %"
            '.Columns("Porc_Margen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Porc_Margen").DefaultCellStyle.Format = "###,##.##"
            '.Columns("Porc_Margen").Visible = True

        End With

    End Sub

    Sub Sb_Formato_Grilla_Asociaciones()

        With Grilla_Mrg_Asociaciones

            OcultarEncabezadoGrilla(Grilla_Mrg_Asociaciones, False)

            .Columns("Codigo_Madre_Clas").Width = 90
            .Columns("Codigo_Madre_Clas").HeaderText = "Código"
            .Columns("Codigo_Madre_Clas").Visible = True

            .Columns("Descripcion_Clas").Width = 350
            .Columns("Descripcion_Clas").HeaderText = "Descripción"
            .Columns("Descripcion_Clas").Visible = True

            .Columns("CantidadUd1").Width = 80
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantidadUd1").Visible = True

            .Columns("TotalCosto").Width = 90
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True

            .Columns("TotalPrecio").Width = 90
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True

            '.Columns("Porc_Margen").Width = 70
            '.Columns("Porc_Margen").HeaderText = "Margen Costo %"
            '.Columns("Porc_Margen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Porc_Margen").DefaultCellStyle.Format = "###,##.##"
            '.Columns("Porc_Margen").Visible = True

        End With

    End Sub

    Sub Sb_Formato_Grilla_Vendedores()

        With Grilla_Mrg_Vendedores

            OcultarEncabezadoGrilla(Grilla_Mrg_Vendedores, False)

            .Columns("Vendedor").Width = 90
            .Columns("Vendedor").HeaderText = "Código"
            .Columns("Vendedor").Visible = True

            .Columns("Nom_Vendedor").Width = 350
            .Columns("Nom_Vendedor").HeaderText = "Descripción"
            .Columns("Nom_Vendedor").Visible = True

            .Columns("CantidadUd1").Width = 80
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantidadUd1").Visible = True

            .Columns("TotalCosto").Width = 90
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True

            .Columns("TotalPrecio").Width = 90
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True

            '.Columns("Porc_Margen").Width = 70
            '.Columns("Porc_Margen").HeaderText = "Margen Costo %"
            '.Columns("Porc_Margen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Porc_Margen").DefaultCellStyle.Format = "###,##.##"
            '.Columns("Porc_Margen").Visible = True

        End With

    End Sub

    Sub Sb_Formato_Grilla_Super_Familias()

        With Grilla_Mrg_Super_Familias

            OcultarEncabezadoGrilla(Grilla_Mrg_Super_Familias, False)

            .Columns("SuperFamilia").Width = 90
            .Columns("SuperFamilia").HeaderText = "Código"
            .Columns("SuperFamilia").Visible = True

            .Columns("Nom_SuperFamilia").Width = 350
            .Columns("Nom_SuperFamilia").HeaderText = "Descripción"
            .Columns("Nom_SuperFamilia").Visible = True

            .Columns("CantidadUd1").Width = 80
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantidadUd1").Visible = True

            .Columns("TotalCosto").Width = 90
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True

            .Columns("TotalPrecio").Width = 90
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True

            '.Columns("Porc_Margen").Width = 70
            '.Columns("Porc_Margen").HeaderText = "Margen Costo %"
            '.Columns("Porc_Margen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Porc_Margen").DefaultCellStyle.Format = "###,##.##"
            '.Columns("Porc_Margen").Visible = True

        End With

    End Sub

    Sub Sb_Formato_Grilla_Empresa()

        With Grilla_Mrg_Empresa

            OcultarEncabezadoGrilla(Grilla_Mrg_Empresa, False)

            Dim _DisplayIndex = 0

            .Columns("Empresa").Width = 40
            .Columns("Empresa").HeaderText = "Emp."
            .Columns("Empresa").Visible = True
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Razon").Width = 350
            .Columns("Razon").HeaderText = "Empresa"
            .Columns("Razon").Visible = True
            .Columns("Razon").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd1").Width = 80
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantidadUd1").Visible = True
            .Columns("CantidadUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalPrecio").Width = 90
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True
            .Columns("TotalPrecio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalCosto").Width = 90
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True
            .Columns("TotalCosto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True
            .Columns("Total_Mrg").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True
            .Columns("Porc_Markup").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Sub

    Sub Sb_Formato_Grilla_Sucursal_Linea()

        With Grilla_Mrg_Sucursal_Linea

            OcultarEncabezadoGrilla(Grilla_Mrg_Sucursal_Linea, False)

            Dim _DisplayIndex = 0

            .Columns("Sulido").Width = 90
            .Columns("Sulido").HeaderText = "Suc."
            .Columns("Sulido").Visible = True
            .Columns("Sulido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nosulido").Width = 350
            .Columns("Nosulido").HeaderText = "Sucursal"
            .Columns("Nosulido").Visible = True
            .Columns("Nosulido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd1").Width = 80
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantidadUd1").Visible = True
            .Columns("CantidadUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalPrecio").Width = 90
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True
            .Columns("TotalPrecio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalCosto").Width = 90
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True
            .Columns("TotalCosto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True
            .Columns("Total_Mrg").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True
            .Columns("Porc_Markup").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Sub

    Sub Sb_Formato_Grilla_Bodega()

        With Grilla_Mrg_Bodega

            OcultarEncabezadoGrilla(Grilla_Mrg_Bodega, False)

            Dim _DisplayIndex = 0

            .Columns("Sulido").Width = 40
            .Columns("Sulido").HeaderText = "Suc."
            .Columns("Sulido").Visible = True
            .Columns("Sulido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bosulido").Width = 40
            .Columns("Bosulido").HeaderText = "Bod."
            .Columns("Bosulido").Visible = True
            .Columns("Bosulido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nokobo").Width = 350
            .Columns("Nokobo").HeaderText = "Bodega"
            .Columns("Nokobo").Visible = True
            .Columns("Nokobo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd1").Width = 80
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantidadUd1").Visible = True
            .Columns("CantidadUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalPrecio").Width = 90
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True
            .Columns("TotalPrecio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalCosto").Width = 90
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True
            .Columns("TotalCosto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True
            .Columns("Total_Mrg").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True
            .Columns("Porc_Markup").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Sub

    Private Sub GrillaMargenesXproducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Mrg_Productos.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Mrg_Productos.Rows(Grilla_Mrg_Productos.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Koprct").Value
        Dim _Descripcion As String = _Fila.Cells("Nokopr").Value

        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Ds_Informe.Tables("Detalle_Venta"), "Koprct = '" & _Codigo & "'", "Koprct")

        Dim Fm As New Frm_InvMargenesDet_(_Codigo, _Descripcion, _Tbl)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub GrillaMargenesXproducto_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Mrg_Productos.CellEnter
        'With GrillaMargenesXproducto
        '    TxtDescripcion.Text = Convert.ToString(.Rows(.CurrentRow.Index()).Cells("Nokopr").Value)
        'End With
    End Sub

    Private Sub Frm_InvMargenes_Mt_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Consulta_Sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblMargenImp" & FUNCIONARIO & "') BEGIN" & vbCrLf &
                       "DROP TABLE Zw_TblMargenImp" & vbCrLf &
                       "End" & vbCrLf &
                       "IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblMargenProductos" & FUNCIONARIO & "') BEGIN" & vbCrLf &
                       "DROP TABLE Zw_TblMargenProductos" & vbCrLf &
                       "END"

        _Sql.Ej_consulta_IDU(Consulta_Sql)

    End Sub

    Private Sub RdPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdPM.CheckedChanged
        CmbListaDeCostos.Enabled = RdLP.Checked
    End Sub

    Private Sub RdUC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdUC.CheckedChanged
        CmbListaDeCostos.Enabled = RdLP.Checked
    End Sub

    Private Sub RdLP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdLP.CheckedChanged
        CmbListaDeCostos.Enabled = RdLP.Checked
    End Sub

    Private Sub BtnV1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFl_Funcionarios.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblFiltroFuncionarios,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra, False, False) Then

            _TblFiltroFuncionarios = _Filtrar.Pro_Tbl_Filtro

            ChkAll_Funcionarios.Checked = _Filtrar.Pro_Filtro_Todas

            If _Filtrar.Pro_Filtro_Todas Then

                _TblFiltroFuncionarios = Nothing

            End If

        End If

    End Sub

    Private Sub BtnV2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFl_Sucursales.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblFiltroSucursal,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, _Sql_Filtro_Condicion_Extra, False, False) Then

            _TblFiltroSucursal = _Filtrar.Pro_Tbl_Filtro

            ChkAll_Sucursales.Checked = _Filtrar.Pro_Filtro_Todas

            If _Filtrar.Pro_Filtro_Todas Then

                _TblFiltroSucursal = Nothing

            End If

        End If

    End Sub

    Private Sub BtnV3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Documentos_Filtro = "('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL'," & _
        '           "'FVT','FVX','FVZ','GDD','GDP','GDV','NCE','NCV','NCX','NCZ','NEV','RIN')"
        '        CargarFiltro("TABTIDO", "Margen1", "Filtro Documentos", Me, False)
    End Sub

    Private Sub BtnV4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFl_Productos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblFiltroProductos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra, False, False) Then

            _TblFiltroProductos = _Filtrar.Pro_Tbl_Filtro

            ChkAll_Productos.Checked = _Filtrar.Pro_Filtro_Todas

            If _Filtrar.Pro_Filtro_Todas Then

                _TblFiltroProductos = Nothing

            End If

        End If

    End Sub

    Sub Sb_Ejecutar_Proceso()

        Dim Funcionari, Opcion As String

        Dim Fecha1 As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim Fecha2 As String = Format(DFechaTermino.Value, "yyyyMMdd")

        Dim ListaCosto As String = CmbListaDeCostos.SelectedValue.ToString


        ' FILTRO FUNCIONARIOS

        Consulta_Sql = "Drop Tabla " & TblMargen
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)
        Consulta_Sql = "Drop Tabla " & TblMrgProductos
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)
        Consulta_Sql = "Drop Tabla " & TblInfMargenes
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)


        If RdResponzableENC.Checked = True Then
            Funcionari = "EDO.KOFUDO"
            _FiltroFuncionarios = "AND EDO.KOFUDO IN " & _FiltroFuncionarios
        Else
            Funcionari = "DDO.KOFULIDO"
            _FiltroFuncionarios = "AND DDO.KOFULIDO IN " & _FiltroFuncionarios
        End If


        If ChkAll_Funcionarios.Checked Then
            _FiltroFuncionarios = String.Empty
        Else
            _FiltroFuncionarios = HacerFiltro(Funcionari, _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblFiltro_InfxUs", "Filtro",
                                    "Funcionario = '" & FUNCIONARIO &
                                    "' And Informe = 'Margen1' And Tabla = 'TABFU'"))
        End If

        'FILTRO SUCURSALES
        If ChkAll_Sucursales.Checked Then
            _FiltroSucursales = String.Empty
        Else
            _FiltroSucursales = HacerFiltro("DDO.SULIDO", _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblFiltro_InfxUs", "Filtro",
                                "Funcionario = '" & FUNCIONARIO &
                                "' And Informe = 'Margen1' And Tabla = 'TABSU'"))
        End If

        'FILTRO DOCUMENTOS
        If ChkAll_Documentos.Checked Then
            _FiltroDocumentos = "AND EDO.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN')"
        Else
            _FiltroDocumentos = HacerFiltro("EDO.TIDO", _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblFiltro_InfxUs", "Filtro",
                                "Funcionario = '" & FUNCIONARIO &
                                "' And Informe = 'Margen1' And Tabla = 'TABTIDO'"))
        End If

        'FILTRO PRODUCTOS
        If ChkAll_Productos.Checked Then

            _FiltroProductos = String.Empty

        Else

            If (_TblFiltroProductos Is Nothing) Or _TblFiltroProductos.Rows.Count = 0 Then
                MessageBoxEx.Show(Me, "No se seleccionó ningún producto para el informe", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _FiltroProductos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")
            _FiltroProductos = "And DDO.KOPRCT In " & _FiltroProductos

        End If


        If RdPM.Checked = True Then Opcion = "1"
        If RdUC.Checked = True Then Opcion = "2"
        If RdLP.Checked = True Then Opcion = "3"
        If RdPmTrans.Checked = True Then Opcion = "4"

        Consulta_Sql = My.Resources.Rs_InvMargenes.Margenes_de_venta

        Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
        Consulta_Sql = Replace(Consulta_Sql, "#ListaCosto#", ListaCosto)
        Consulta_Sql = Replace(Consulta_Sql, "#Opcion#", Opcion)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha1#", Fecha1)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha2#", Fecha2)
        Consulta_Sql = Replace(Consulta_Sql, "#Funcionario#", Funcionari)
        Consulta_Sql = Replace(Consulta_Sql, "#_Funcionario_Activo#", FUNCIONARIO)

        Consulta_Sql = Replace(Consulta_Sql, "#FiltroFuncionarios#", _FiltroFuncionarios)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroSucursal#", _FiltroSucursales)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroDocumentos#", _FiltroDocumentos)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroProductos#", _FiltroProductos)

        Consulta_Sql = Replace(Consulta_Sql, "Zw_TblMargen", TblMargen)
        Consulta_Sql = Replace(Consulta_Sql, "Zw_TblMrgProductos", TblMrgProductos)
        Consulta_Sql = Replace(Consulta_Sql, "Zw_TblInfMargenes", TblInfMargenes)

        Consulta_Sql = Replace(Consulta_Sql, "#Tbl_EntExcluidas#", _Global_BaseBk & "Zw_TblInf_EntExcluidas")

        _Sql.Ej_consulta_IDU("Drop table " & TblMargen, False)
        _Sql.Ej_consulta_IDU("Drop table " & TblMrgProductos, False)
        _Sql.Ej_consulta_IDU("Drop table " & TblInfMargenes, False)

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            Consulta_Sql = "Select Koprct, Nokopr, Documentos, CantidadUd1, TotalCosto, TotalPrecio, " & vbCrLf &
                           "Total_Mrg, cast(Porc_Markup as decimal(10,2)) as Porc_Markup," & vbCrLf &
                           "cast(Porc_Margen as decimal(10,2)) as Porc_Margen" & vbCrLf &
                           "From " & TblMrgProductos

            Grilla_Mrg_Productos.DataSource = _Sql.Fx_Get_DataTable(Consulta_Sql)

            'LblDescripcion.DataBindings.Clear()
            'LblDescripcion.DataBindings.Add("text", Grilla_Mrg_Productos.DataSource, "Nokopr")

            If CBool(Grilla_Mrg_Productos.RowCount) Then

                Sb_Formato_Grilla_Productos(Grilla_Mrg_Productos)


                MessageBoxEx.Show(Me, "Informe completado correctamente", "Informe Margenes", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                SuperTabControl1.SelectedTabIndex = 1
                Grilla_Mrg_Productos.Focus()

            Else
                ToastNotification.Show(Me, "NO SE ENCONTRO INFORMACION", My.Resources.cross,
                                      1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            End If

        End If
    End Sub

    Sub Sb_Ejecutar_Proceso2()

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        If Chk_Excluir_Entidades.Checked Then
            Me.Text = "Margenes del periodo (¡INFORME GENERADO CON ENTIDADES EXCLUIDAS!)"
        Else
            Me.Text = "Margenes del periodo"
        End If

        Dim _Funcionario, Opcion As String

        Dim _Fecha1 As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim _Fecha2 As String = Format(DFechaTermino.Value, "yyyyMMdd")

        Dim ListaCosto As String = CmbListaDeCostos.SelectedValue.ToString

        If RdResponzableENC.Checked = True Then
            _Funcionario = "EDO.KOFUDO"
            '_FiltroFuncionarios = "AND EDO.KOFUDO IN " & _FiltroFuncionarios
        Else
            _Funcionario = "DDO.KOFULIDO"
            '_FiltroFuncionarios = "AND DDO.KOFULIDO IN " & _FiltroFuncionarios
        End If


        If ChkAll_Funcionarios.Checked Then
            _FiltroFuncionarios = String.Empty
        Else
            _FiltroFuncionarios = Generar_Filtro_IN(_TblFiltroFuncionarios, "", "Codigo", False, False, "'")
            'If RdResponzableENC.Checked = True Then
            '_FiltroFuncionarios = "AND EDO.KOFUDO IN " & _FiltroFuncionarios
            'Else
            _FiltroFuncionarios = "AND DDO.KOFULIDO IN " & _FiltroFuncionarios
            'End If
        End If

        'FILTRO SUCURSALES
        If ChkAll_Sucursales.Checked Then
            _FiltroSucursales = String.Empty
        Else
            _FiltroSucursales = Generar_Filtro_IN(_TblFiltroSucursal, "", "Codigo", False, False, "'")
            _FiltroSucursales = "And DDO.SULIDO In " & _FiltroSucursales
        End If

        'FILTRO DOCUMENTOS
        If ChkAll_Documentos.Checked Then
            _FiltroDocumentos = "AND EDO.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN')"
        Else
            _FiltroDocumentos = Generar_Filtro_IN(_TblFiltroDocumentos, "", "Codigo", False, False, "'")
            _FiltroDocumentos = "And EDO.TIDO In " & _FiltroDocumentos
        End If

        'FILTRO PRODUCTOS
        If ChkAll_Productos.Checked Then
            _FiltroProductos = String.Empty
        Else

            If (_TblFiltroProductos Is Nothing) Or _TblFiltroProductos.Rows.Count = 0 Then
                MessageBoxEx.Show(Me, "No se seleccionó ningún producto para el informe", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _FiltroProductos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")
            _FiltroProductos = "And DDO.KOPRCT In " & _FiltroProductos

        End If

        If Chk_Solo_Productos_Con_Descuento.Checked Then

            _FiltroProductos += "And DDO.KOPRCT In (Select Distinct KOPRCT From MAEDDO 
                                    Where TIDO In ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN') 
                                    And FEEMLI BETWEEN @Fecha1 AND @Fecha2
                                    And PPPRNE < PPPRNELT)" & vbCrLf

        End If

        _FiltroEntExcluidas = String.Empty

        If Chk_Excluir_Entidades.Checked Then

            _FiltroEntExcluidas = "And  LTRIM(RTRIM(EDO.ENDO))+RTRIM(LTRIM(EDO.SUENDO))  
	                               Not IN (Select  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas
	                               Where Funcionario = @Funcionario)"

        End If

        Dim _Filtro_No_SSN_FLN = String.Empty

        If CkNoServicios.Checked Or CkNoMultiproposito.Checked Then

            If CkNoServicios.Checked Then _Filtro_No_SSN_FLN = "('SSN')"
            If CkNoMultiproposito.Checked Then _Filtro_No_SSN_FLN = "('FLN')"

            If CkNoServicios.Checked And CkNoMultiproposito.Checked Then
                _Filtro_No_SSN_FLN = "('SSN','FLN')"
            End If

            _Filtro_No_SSN_FLN = "And MAEPR.TIPR Not In " & _Filtro_No_SSN_FLN & "  -- NO INCLUIR PRODUCTOS TIPO SERVICIO NI MULTIPROPOSITO   "

        End If

        'And DDO.TICT = ''                    -- NO INCLUIR CONCEPTOS  ('R') Recargo,('D') Descuento 

        Dim _Nodo_Raiz = NuloPorNro(Cmb_Clasificaciones.SelectedValue, 0)

        If RdPM.Checked = True Then Opcion = "1"
        If RdUC.Checked = True Then Opcion = "2"
        If RdLP.Checked = True Then Opcion = "3"
        If RdPmTrans.Checked = True Then Opcion = "4"

        Consulta_Sql = My.Resources.Rs_InvMargenes.Margenes_de_venta2

        Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
        Consulta_Sql = Replace(Consulta_Sql, "#ListaCosto#", ListaCosto)
        Consulta_Sql = Replace(Consulta_Sql, "#Opcion#", Opcion)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha1#", _Fecha1)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha2#", _Fecha2)
        Consulta_Sql = Replace(Consulta_Sql, "#Funcionario#", _Funcionario)
        Consulta_Sql = Replace(Consulta_Sql, "#_Funcionario_Activo#", FUNCIONARIO)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroFuncionarios#", _FiltroFuncionarios)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroSucursal#", _FiltroSucursales)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroDocumentos#", _FiltroDocumentos)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroProductos#", _FiltroProductos)
        Consulta_Sql = Replace(Consulta_Sql, "#Filtro_No_SSN_FLN#", _Filtro_No_SSN_FLN)
        Consulta_Sql = Replace(Consulta_Sql, "#Global_Bakapp#", _Global_BaseBk)
        Consulta_Sql = Replace(Consulta_Sql, "#FiltroEntExcluidas#", _FiltroEntExcluidas)
        Consulta_Sql = Replace(Consulta_Sql, "#Global_Bakapp#", _Global_BaseBk)
        Consulta_Sql = Replace(Consulta_Sql, "#Nodo_Raiz#", _Nodo_Raiz)

        _Ds_Informe = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Ds_Informe.Tables(0).TableName = "MargenXProducto"
        _Ds_Informe.Tables(1).TableName = "Excel_MargenXProducto"

        _Ds_Informe.Tables(2).TableName = "MargenXAsociacion"
        _Ds_Informe.Tables(3).TableName = "Excel_MargenXAsociacion"

        _Ds_Informe.Tables(4).TableName = "MargenXVendedor"
        _Ds_Informe.Tables(5).TableName = "Excel_MargenXVendedor"

        _Ds_Informe.Tables(6).TableName = "MargenXSuperFamilia"
        _Ds_Informe.Tables(7).TableName = "Excel_MargenXSuperFamilia"

        _Ds_Informe.Tables(8).TableName = "Detalle_Venta"
        _Ds_Informe.Tables(9).TableName = "Excel_Detalle_Venta"

        _Ds_Informe.Tables(10).TableName = "MargenXEmpresa"
        _Ds_Informe.Tables(11).TableName = "Excel_MargenXEmpresa"

        _Ds_Informe.Tables(12).TableName = "MargenXSucursalLinea"
        _Ds_Informe.Tables(13).TableName = "Excel_MargenXSucursal"

        _Ds_Informe.Tables(14).TableName = "MargenXBodega"
        _Ds_Informe.Tables(15).TableName = "Excel_MargenXBodega"

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  

        _Ds_Informe.Relations.Add("Rl_MargenXAsociacion",
                          _Ds_Informe.Tables("MargenXAsociacion").Columns("Codigo_Nodo_Clas"),
                          _Ds_Informe.Tables("MargenXProducto").Columns("Codigo_Nodo_Clas"), False)

        '_Ds_Informe.Relations.Add("MargenXAsociacion",
        '                  _Ds_Informe.Tables("Despachos").Columns("Id_Despacho"),
        '                  _Ds_Informe.Tables("Detalle").Columns("Id_Despacho"), False)

        '_Ds_Informe.Relations.Add("Rel_Detalle_Productos",
        '                  _Ds_Informe.Tables("Detalle").Columns("IdD"),
        '                  _Ds_Informe.Tables("Productos").Columns("IdD"), False)

        'Grilla_Ordenes.DataSource = _Ds
        'Grilla_Ordenes.DataMember = "Despachos"


        _Dv_Productos.Table = _Ds_Informe.Tables("MargenXProducto")

        Grilla_Mrg_Productos.DataSource = _Dv_Productos
        Grilla_Mrg_Asociaciones.DataSource = _Ds_Informe.Tables("MargenXAsociacion")
        Grilla_Mrg_Vendedores.DataSource = _Ds_Informe.Tables("MargenXVendedor")
        Grilla_Mrg_Super_Familias.DataSource = _Ds_Informe.Tables("MargenXSuperFamilia")
        Grilla_Mrg_Empresa.DataSource = _Ds_Informe.Tables("MargenXEmpresa")
        Grilla_Mrg_Sucursal_Linea.DataSource = _Ds_Informe.Tables("MargenXSucursalLinea")
        Grilla_Mrg_Bodega.DataSource = _Ds_Informe.Tables("MargenXBodega")

        OcultarEncabezadoGrilla(Grilla_Mrg_Productos, True)
        OcultarEncabezadoGrilla(Grilla_Mrg_Asociaciones, True)
        OcultarEncabezadoGrilla(Grilla_Mrg_Vendedores, True)
        OcultarEncabezadoGrilla(Grilla_Mrg_Super_Familias, True)
        OcultarEncabezadoGrilla(Grilla_Mrg_Empresa, True)
        OcultarEncabezadoGrilla(Grilla_Mrg_Sucursal_Linea, True)
        OcultarEncabezadoGrilla(Grilla_Mrg_Bodega, True)

        If CBool(Grilla_Mrg_Productos.RowCount) Then

            Sb_Formato_Grilla_Productos(Grilla_Mrg_Productos)
            Sb_Formato_Grilla_Asociaciones()
            Sb_Formato_Grilla_Vendedores()
            Sb_Formato_Grilla_Super_Familias()
            'Sb_Formato_Grilla_Empresa()
            'Sb_Formato_Grilla_Sucursal_Linea()
            'Sb_Formato_Grilla_Bodega()

            Fm_Espera.Dispose()

            MessageBoxEx.Show(Me, "Informe completado correctamente", "Informe Margenes", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            Tab_ResumenProd.Visible = True
            Tab_Clasificaciones_Bk.Visible = Chk_Incluye_Clasificaciones.Checked
            Tab_Vendedores.Visible = True
            Tab_Super_Familias.Visible = True
            Tab_Empresa.Visible = True
            Tab_Sucursal_Detalle.Visible = True
            Tab_Bodega.Visible = True

            Btn_Excel_Detalle.Visible = True
            Btn_Excel_Resumen.Visible = True
            Btn_Estadisticas_Margen.Visible = True

            SuperTabControl1.SelectedTabIndex = 1
            Grilla_Mrg_Productos.Focus()

            Me.Refresh()

        Else
            Fm_Espera.Dispose()

            ToastNotification.Show(Me, "NO SE ENCONTRO INFORMACION", My.Resources.cross,
                                  1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub BtnProcesarInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesarInf.Click
        Sb_Ejecutar_Proceso2()
        'Sb_Ejecutar_Proceso()
    End Sub


    Private Sub ChkAll_Funcionarios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll_Funcionarios.CheckedChanged
        If ChkAll_Funcionarios.Checked Then
            'MarcarTodosLosFiltro("Margen1", "TABFU")
        Else
            'DesMarcarTodosLosFiltro("Margen1", "TABFU")
        End If
    End Sub

    Private Sub BtnFl_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFl_Documentos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblFiltroDocumentos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Documentos, _Sql_Filtro_Condicion_Extra, False, False) Then

            _TblFiltroDocumentos = _Filtrar.Pro_Tbl_Filtro

            ChkAll_Documentos.Checked = _Filtrar.Pro_Filtro_Todas

            If _Filtrar.Pro_Filtro_Todas Then

                _TblFiltroDocumentos = Nothing

            End If

        End If

    End Sub


    Sub Rev_ChkBtn(ByVal Boton As Object,
                   ByVal Chekeo As Boolean)
        Boton.Checked = Chekeo
        If Chekeo Then
            Boton.Text = "Mostrar Todo"
        Else
            Boton.Text = "Algunas seleccionadas..."
        End If
    End Sub

    Private Sub RdPmTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdPmTrans.CheckedChanged
        ChkCostoDesdeFcc.Enabled = RdPM.Checked
    End Sub
    Function CreaEstadistica(ByVal Grupo As String) As DataTable

        Dim Margen As String

        If Grupo = "Grupo_Mg" Then
            Margen = "Porc_Margen"
        ElseIf Grupo = "Grupo_Mk" Then
            Margen = "Porc_Markup"
        End If

        Consulta_Sql = "Update " & TblMrgProductos & vbCrLf & "Set " & Grupo & " = Round(" & Margen & ",0)"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        Consulta_Sql = "Select Min(" & Margen & ") As Minimo,Max(" & Margen & ") As Maximo From " & TblMrgProductos
        Dim Tbla As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim Menor, Mayor, Maximo As Double
        Menor = Tbla.Rows(0).Item("Minimo")
        Mayor = Tbla.Rows(0).Item("Maximo")
        Maximo = 100

        Consulta_Sql = "Select * From " & TblMrgProductos & " Order by " & Margen
        Tbla = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim Negativos As Integer = 5
        Dim Positivos As Integer = 10
        Dim Listo = True
        Dim Valor As Double
        Dim i As Double = Menor - 1

        Dim Rango As String

        Dim Desde, Hasta As Double
        Dim Cantidad As Double

        Dim Cont As Integer = 0
        Dim Arreglo(0) As Double

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Rango", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Desde", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Hasta", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Cantidad", System.Type.[GetType]("System.Double"))
        ',,,,,,


        Rango = "Margen negativo"
        Desde = CInt(Fix(Menor)) 'Math.Round(i, 1)
        Hasta = -1
        Cantidad = _Sql.Fx_Cuenta_Registros(TblMrgProductos, Grupo & " <0") '= " & Desde & " and Grupo <= " & Hasta)
        dr = dt.NewRow() : dr("Rango") = Rango : dr("Desde") = Desde : dr("Hasta") = Hasta : dr("Cantidad") = Cantidad
        dt.Rows.Add(dr)

        Consulta_Sql = "Update " & TblMrgProductos & vbCrLf &
                       "Set " & Grupo & " = 0 Where " & Grupo & " = -0"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        Rango = "0"
        Desde = 0
        Hasta = 0
        Cantidad = _Sql.Fx_Cuenta_Registros(TblMrgProductos, Grupo & " = 0") '= " & Desde & " and Grupo <= " & Hasta)
        dr = dt.NewRow() : dr("Rango") = Rango : dr("Desde") = Desde : dr("Hasta") = Hasta : dr("Cantidad") = Cantidad
        dt.Rows.Add(dr)

        i = 1
        Do While i < Maximo

            Desde = CInt(Fix(i)) 'Math.Round(i, 1)
            Valor = CInt(Fix(i)) + Positivos - 1 ' Math.Round(i + Positivos, 0)
            Hasta = Valor '+ 1 '0.05
            i = Hasta + 1 'i = i + Positivos

            Rango = Desde & "% a " & Hasta & "%" ' Math.Round(Hasta, 3)
            Cantidad = _Sql.Fx_Cuenta_Registros(TblMrgProductos, Grupo & " >= " & Desde & " and " & Grupo & " <= " & Hasta)

            dr = dt.NewRow()
            dr("Rango") = Rango
            dr("Desde") = Desde
            dr("Hasta") = Hasta
            dr("Cantidad") = Cantidad
            dt.Rows.Add(dr)

        Loop

        Rango = "Más de un 100%"
        Cantidad = _Sql.Fx_Cuenta_Registros(TblMrgProductos, Grupo & " > 100") '= " & Desde & " and Grupo <= " & Hasta)
        dr = dt.NewRow() : dr("Rango") = Rango : dr("Desde") = 101 : dr("Hasta") = Maximo : dr("Cantidad") = Cantidad
        dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        Return dt

    End Function

    Function Fx_CreaEstadistica(ByVal _Grupo As String, _TblMgr As DataTable) As DataTable

        Dim _Margen As String

        If _Grupo = "Grupo_Mg" Then
            _Margen = "Porc_Margen"
        ElseIf _Grupo = "Grupo_Mk" Then
            _Margen = "Porc_Markup"
        End If

        _Margen = _Grupo

        Dim _Menor, _Mayor, _Maximo As Double
        _Menor = _TblMgr.Compute("Min(" & _Margen & ")", "")
        _Mayor = _TblMgr.Compute("Max(" & _Margen & ")", "")
        _Maximo = 100

        Dim Negativos As Integer = 5
        Dim Positivos As Integer = 10
        Dim Listo = True
        Dim i As Double = _Menor - 1

        Dim _Rango As String

        Dim _Desde, _Hasta As Double
        Dim _Cantidad As Double

        Dim Cont As Integer = 0
        Dim Arreglo(0) As Double

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Rango", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Desde", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Hasta", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Cantidad", System.Type.[GetType]("System.Double"))
        ',,,,,,

        _Rango = "Margen negativo"
        _Desde = CInt(Fix(_Menor))
        _Hasta = -1
        For Each _Fila As DataRow In _TblMgr.Rows
            Dim _Valor = CInt(Fix(_Fila.Item(_Margen)))
            If _Valor < 0 Then
                _Cantidad += 1
            End If
        Next
        dr = dt.NewRow() : dr("Rango") = _Rango : dr("Desde") = _Desde : dr("Hasta") = _Hasta : dr("Cantidad") = _Cantidad
        dt.Rows.Add(dr)

        _Cantidad = 0 : _Rango = "0" : _Desde = 0 : _Hasta = 0

        For Each _Fila As DataRow In _TblMgr.Rows
            Dim _Valor = CInt(Fix(_Fila.Item(_Margen)))
            If _Fila.Item(_Margen) = 0 Then
                _Cantidad += 1
            End If
        Next
        dr = dt.NewRow() : dr("Rango") = _Rango : dr("Desde") = _Desde : dr("Hasta") = _Hasta : dr("Cantidad") = _Cantidad
        dt.Rows.Add(dr)

        i = 1

        Do While i < _Maximo

            _Desde = CInt(Fix(i))
            _Hasta = CInt(Fix(i)) + Positivos - 1

            i = _Hasta + 1

            _Rango = _Desde & "% a " & _Hasta & "%"
            _Cantidad = 0

            For Each _Fila As DataRow In _TblMgr.Rows
                Dim _Valor = CInt(Fix(_Fila.Item(_Margen)))
                If _Valor <= _Hasta Then
                    If _Valor >= _Desde Then
                        _Cantidad += 1
                    End If
                End If
            Next

            dr = dt.NewRow()
            dr("Rango") = _Rango
            dr("Desde") = _Desde
            dr("Hasta") = _Hasta
            dr("Cantidad") = _Cantidad
            dt.Rows.Add(dr)

        Loop

        _Cantidad = 0 : _Rango = "Más de un 100%" : _Desde = 101 : _Hasta = _Mayor

        For Each _Fila As DataRow In _TblMgr.Rows
            If _Fila.Item(_Margen) > 100 Then
                _Cantidad += 1
            End If
        Next
        dr = dt.NewRow() : dr("Rango") = _Rango : dr("Desde") = _Desde : dr("Hasta") = _Hasta : dr("Cantidad") = _Cantidad
        dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        Return dt

    End Function

    Private Sub Txt_Buscar_Producto_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscar_Producto.KeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Space Then

            _Dv_Productos.RowFilter = String.Format("Koprct+NOKOPR Like '%{0}%'", Txt_Buscar_Producto.Text)

        End If

    End Sub

    Private Sub Btn_Estadisticas_Margen_Click(sender As Object, e As EventArgs) Handles Btn_Estadisticas_Margen.Click

        Dim _Tbl, _Dt_Mg, _Dt_Mk As DataTable

        If SuperTabControl1.SelectedTabIndex = 1 Then
            _Tbl = _Ds_Informe.Tables("MargenXProducto")
        End If

        If SuperTabControl1.SelectedTabIndex = 2 Then
            _Tbl = _Ds_Informe.Tables("MargenXAsociacion")
        End If

        If SuperTabControl1.SelectedTabIndex = 2 Then
            _Tbl = _Ds_Informe.Tables("MargenXVendedor")
        End If

        'Dt_Mg = CreaEstadistica("Grupo_Mg")
        'Dt_Mk = CreaEstadistica("Grupo_Mk")

        _Dt_Mg = Fx_CreaEstadistica("Grupo_Mg", _Tbl)
        _Dt_Mk = Fx_CreaEstadistica("Grupo_Mk", _Tbl)

        Dim Fm As New Frm_InvMargenes_Grf
        Fm.Tbl_Detalle = _Ds_Informe.Tables("Detalle_Venta")
        Fm.TblMrg_Informe = _Tbl
        Fm.ShowInTaskbar = False
        Fm.TablaGrf_Mg = _Dt_Mg
        Fm.TablaGrf_Mk = _Dt_Mk
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Mrg_Asociaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Mrg_Asociaciones.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Mrg_Asociaciones.Rows(Grilla_Mrg_Asociaciones.CurrentRow.Index)

        Dim _Codigo_Madre_Clas As String = _Fila.Cells("Codigo_Madre_Clas").Value
        Dim _Descripcion_Clas As String = _Fila.Cells("Descripcion_Clas").Value

        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Ds_Informe.Tables("MargenXProducto"), "Codigo_Madre_Clas = '" & _Codigo_Madre_Clas & "'", "Codigo_Madre_Clas")

        Dim Fm As New Frm_InvMargenes_Grf_Res

        Fm.Text = "Productos asociados a: " & _Codigo_Madre_Clas & " - " & _Descripcion_Clas
        Fm.Tbl_Detalle = _Ds_Informe.Tables("Detalle_Venta")
        Fm.Tbl_Informe = _Tbl
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub SuperTabItem1_Click(sender As Object, e As EventArgs) Handles SuperTabItem1.Click

        BtnProcesarInf.Enabled = True
        Btn_Excel_Detalle.Visible = False
        Btn_Excel_Resumen.Visible = False
        Btn_Estadisticas_Margen.Visible = False

    End Sub

    Private Sub SuperTabItem2_Click(sender As Object, e As EventArgs) Handles Tab_ResumenProd.Click
        BtnProcesarInf.Enabled = False
        Btn_Excel_Detalle.Visible = True
        Btn_Excel_Resumen.Visible = True
        Btn_Estadisticas_Margen.Visible = True
        Me.Refresh()
    End Sub

    Private Sub SuperTabItem3_Click(sender As Object, e As EventArgs) Handles Tab_Clasificaciones_Bk.Click
        BtnProcesarInf.Enabled = False
        Btn_Excel_Detalle.Visible = True
        Btn_Excel_Resumen.Visible = True
        Btn_Estadisticas_Margen.Visible = False
        Me.Refresh()
    End Sub

    Private Sub Btn_Excel_Resumen_Click(sender As Object, e As EventArgs) Handles Btn_Excel_Resumen.Click

        Dim _Tbl As DataTable

        Dim _Tab As SuperTabItem = SuperTabControl1.SelectedTab

        If _Tab.Name = "Tab_ResumenProd" Then
            _Tbl = _Ds_Informe.Tables("Excel_MargenXProducto")
        End If

        If _Tab.Name = "Tab_Empresa" Then
            _Tbl = _Ds_Informe.Tables("Excel_MargenXEmpresa")
        End If

        If _Tab.Name = "Tab_Sucursal_Detalle" Then
            _Tbl = _Ds_Informe.Tables("Excel_MargenXSucursal")
        End If

        If _Tab.Name = "Tab_Bodega" Then
            _Tbl = _Ds_Informe.Tables("Excel_MargenXBodega")
        End If

        If _Tab.Name = "Tab_Clasificaciones_Bk" Then
            _Tbl = _Ds_Informe.Tables("Excel_MargenXAsociacion")
        End If

        If _Tab.Name = "Tab_Vendedores" Then
            _Tbl = _Ds_Informe.Tables("Excel_MargenXVendedor")
        End If

        If _Tab.Name = "Tab_Super_Familias" Then
            _Tbl = _Ds_Informe.Tables("Excel_MargenXSuperFamilia")
        End If

        If IsNothing(_Tbl) Then
            MessageBoxEx.Show(Me, "No hay datos que mostrar", "Error al extraer informe", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, _Tab.Name.Replace("Tab_", ""))

    End Sub

    Private Sub Btn_Excel_Detalle_Click(sender As Object, e As EventArgs) Handles Btn_Excel_Detalle.Click
        ExportarTabla_JetExcel_Tabla(_Ds_Informe.Tables("Excel_Detalle_Venta"), Me, "Detalle")
    End Sub

    Private Sub BtnV5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnV5.Click

        Dim Fm As New Frm_EntExcluidas
        Fm.ShowInTaskbar = False
        Fm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Fm.ShowDialog(Me)

    End Sub




    Private Sub BtnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CBool(Grilla_Mrg_Productos.Rows.Count) Then

            Codigo_abuscar = String.Empty

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

            Fm.Pro_Tipo_Lista = "C" '.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
            Fm.Pro_Lista_Busqueda = Mod_ListaPrecioVenta
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_CodSucEntidad = String.Empty
            Fm.Pro_Mostrar_Info = False 'MostrarOcultos = True
            Fm.Pro_Actualizar_Precios = False
            Fm.BtnCrearProductos.Visible = False
            Fm.BtnExportaExcel.Visible = False
            Fm.ShowDialog(Me)
            If Fm.Pro_Seleccionado Then
                If Not (Fm.Pro_RowProducto Is Nothing) Then
                    Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")
                End If

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then
                    If BuscarDatoEnGrilla(Trim(Codigo_abuscar), "Koprct", Grilla_Mrg_Productos) = True Then
                        Grilla_Mrg_Productos.Focus()
                    End If
                End If
            End If
        Else
            MessageBoxEx.Show(Me, "No hay productos que buscar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Grilla_Mrg_Super_Familias_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Mrg_Super_Familias.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Mrg_Super_Familias.Rows(Grilla_Mrg_Super_Familias.CurrentRow.Index)

        Dim _SuperFamilia As String = _Fila.Cells("SuperFamilia").Value
        Dim _Nom_SuperFamilia As String = _Fila.Cells("Nom_SuperFamilia").Value

        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Ds_Informe.Tables("MargenXProducto"), "SuperFamilia = '" & _SuperFamilia & "'", "SuperFamilia")

        Dim Fm As New Frm_InvMargenes_Grf_Res

        Fm.Text = "Productos asociados a: " & _SuperFamilia & " - " & _Nom_SuperFamilia
        Fm.Tbl_Detalle = _Ds_Informe.Tables("Detalle_Venta")
        Fm.Tbl_Informe = _Tbl
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Tab_Empresa_Click(sender As Object, e As EventArgs) Handles Tab_Empresa.Click
        Sb_Formato_Grilla_Empresa()
    End Sub

    Private Sub Tab_Sucursal_Detalle_Click(sender As Object, e As EventArgs) Handles Tab_Sucursal_Detalle.Click
        Sb_Formato_Grilla_Sucursal_Linea()
    End Sub

    Private Sub Tab_Bodega_Click(sender As Object, e As EventArgs) Handles Tab_Bodega.Click
        Sb_Formato_Grilla_Bodega()
    End Sub
End Class
