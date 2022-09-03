Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_BuscarXProducto_Mt_Listas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _CodProveedor, _SucProveedor As String
    Public _CodLista, _NomLista As String
    Public _TblProd_Seleccionado As DataTable
    Public _Seleccionado As Boolean
    Public _Seleccionar_y_cerrar As Boolean = True

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Seleccionado = False
        Me.Close()
    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        If String.IsNullOrEmpty(Trim(Txtdescripcion.Text)) Then
            Sb_Buscar()
            Grilla.ClearSelection()
            'GrillaBusquedaOtros.ClearSelection()
        End If
    End Sub

    Sub Sb_Buscar()

        Dim _Condicion_Proveedor As String = String.Empty

        If Not String.IsNullOrEmpty(Trim(_CodProveedor)) Then
            _Condicion_Proveedor = "And Proveedor = '" & _CodProveedor & "'"
        End If

        Dim _Condicion_Codigos, _Condicion_Descripcion As String

        _Condicion_Codigos = CADENA_A_BUSCAR(RTrim$(TxtCodigo.Text), _
                               "CodAlternativo+Codigo" & " LIKE '%")

        _Condicion_Descripcion = CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text), _
                               "Descripcion+Descripcion_Alt" & " LIKE '%")


       
        Consulta_sql = "Select top 500 Id,CodAlternativo," & _
                       "Case When Codigo = '' Then '* Por definir' Else Codigo End as Codigo," & _
                       "Descripcion_Alt,Descripcion,CostoUd1,Un_Compra," & _
                       "Case when DescSuma > 0 then CostoUd1- (CostoUd1 * (DescSuma/100)) else CostoUd1 End as 'Mcosto',Un_MinCompra," & vbCrLf & _
                       "Proveedor,Sucursal,IsNull((Select top 1 NOKOEN From MAEEN Where KOEN = Proveedor),'* P/D') as Razon_Proveedor," & vbCrLf & _
                       "Case When (Select Count(*) From ZW_SOC_Ent_Cadena Where CodProveedor = Proveedor) > 0 then 'SI' Else 'NO' End As Cadena" & vbCrLf & _
                       "From Zw_ListaPreCosto" & vbCrLf & _
                       "Where CodAlternativo+Codigo LIKE '%" & _Condicion_Codigos & "%'" & vbCrLf & _
                       "And Descripcion+Descripcion_Alt LIKE '%" & _Condicion_Descripcion & "%'" & vbCrLf & _
                       "And Lista = '" & _CodLista & "'" & vbCrLf & _
                       _Condicion_Proveedor & vbCrLf & _
                       "Order by Descripcion_Alt"


        With Grilla
            .DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla)

            '.Columns("Item").Width = 35
            '.Columns("Item").HeaderText = "Item"
            '.Columns("Item").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Item").Visible = True

            .Columns("Proveedor").Width = 70
            .Columns("Proveedor").HeaderText = "Cód. Prov."
            .Columns("Proveedor").Visible = True

            .Columns("Razon_Proveedor").Width = 140
            .Columns("Razon_Proveedor").HeaderText = "Proveedor"
            .Columns("Razon_Proveedor").Visible = True

            .Columns("CodAlternativo").Width = 100
            .Columns("CodAlternativo").HeaderText = "Código P.P."
            .Columns("CodAlternativo").ToolTipText = "Código del producto del proveedor"
            .Columns("CodAlternativo").Visible = True

            .Columns("Codigo").Width = 90
            .Columns("Codigo").HeaderText = "Cód. Relación"
            .Columns("Codigo").ToolTipText = "Código principal del producto"
            .Columns("Codigo").Visible = True

            .Columns("Descripcion_Alt").Width = 320
            .Columns("Descripcion_Alt").HeaderText = "Descripcion"
            .Columns("Descripcion_Alt").ToolTipText = "Descripción del producto (del proveedor)"
            .Columns("Descripcion_Alt").Visible = True

            .Columns("CostoUd1").Width = 80
            .Columns("CostoUd1").HeaderText = "Precio Lista"
            .Columns("CostoUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("CostoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CostoUd1").Visible = True

            .Columns("Un_Compra").Width = 40
            .Columns("Un_Compra").HeaderText = "UM"
            .Columns("Un_Compra").DefaultCellStyle.Format = "###,##"
            .Columns("Un_Compra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Un_Compra").ToolTipText = "Unidad de medida"
            .Columns("Un_Compra").Visible = True

            .Columns("Mcosto").Width = 80
            .Columns("Mcosto").HeaderText = "Mejor precio"
            .Columns("Mcosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Mcosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Mcosto").Visible = True

            .Columns("Un_MinCompra").Width = 40
            .Columns("Un_MinCompra").HeaderText = "MC"
            .Columns("Un_MinCompra").DefaultCellStyle.Format = "###,##"
            .Columns("Un_MinCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Un_MinCompra").ToolTipText = "Unidad mínima de compra"
            .Columns("Un_MinCompra").Visible = True


            '.Columns("PP01UD").Width = 80
            '.Columns("PP01UD").HeaderText = "Precio"
            '.Columns("PP01UD").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("PP01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
        Sb_Marcar_Grilla()
        'MS.Codigo+MS.Descripcion+MS.DescripcionBusqueda

    End Sub


    Sub Sb_Marcar_Grilla()
        With Grilla
            For Each row As DataGridViewRow In .Rows

                Dim _Codigo As String = NuloPorNro(row.Cells("Codigo").Value, "")

                'Grilla.Rows.Item(i).DefaultCellStyle.BackColor = Color.White ' Color.Coral
                'Grilla.Rows(i).DefaultCellStyle.ForeColor = Color.Black


                'If Not String.IsNullOrEmpty(__ESTADO) Then
                'Grilla.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                'End If

                If _Codigo = "* Por definir" Then
                    'Grilla.Rows.Item(row.Index).DefaultCellStyle.BackColor = Color.LightGreen
                    'Else
                    'Grilla.Rows.Item(row.Index).DefaultCellStyle.BackColor = Color.LightYellow
                    'Else
                    'Grilla.Rows.Item(row.Index).DefaultCellStyle.BackColor = Color.Silver
                    Grilla.Rows(row.Index).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        End With
    End Sub

    Private Sub Txtdescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtdescripcion.KeyDown
        If e.KeyValue = Keys.Down Then
            Grilla.Focus()
            Me.ActiveControl = Grilla ' Txtdescripcion
        End If

        If e.KeyValue = Keys.Return Then
            SendKeys.Send("{RIGHT}")
            e.Handled = True
            Sb_Buscar()
            'Actualizar_Precio_BkRandom(ListaBusq)
            'BUSCA()
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
       Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Grilla_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter
        With Grilla

            TxtDescripcion_RD.Text = String.Empty

            Dim _xCodProveedor As String = .Rows(.CurrentRow.Index).Cells("Proveedor").Value
            Dim _xCodSucursal As String = .Rows(.CurrentRow.Index).Cells("Sucursal").Value
            Dim _xRazonProveedor As String = Trim(.Rows(.CurrentRow.Index).Cells("Razon_Proveedor").Value)
            Dim _xCadena As String = .Rows(.CurrentRow.Index).Cells("Cadena").Value

            If String.IsNullOrEmpty(Trim(_CodProveedor)) Then
                TxtDescripcion_RD.Text = Trim(.Rows(.CurrentRow.Index).Cells("Descripcion").Value) & _
                                         ", Proveedor: " & _xRazonProveedor & ", Compra por cadena: " & _xCadena
            Else
                TxtDescripcion_RD.Text = Trim(.Rows(.CurrentRow.Index).Cells("Descripcion").Value) & ", Compra por cadena: " & _xCadena
            End If

        End With
    End Sub


    Private Sub TxtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown

        If e.KeyValue = Keys.Down Then
            Grilla.Focus()
            Me.ActiveControl = Grilla ' Txtdescripcion
        End If

        If e.KeyValue = Keys.Return Then
            SendKeys.Send("{RIGHT}")
            e.Handled = True
            Sb_Buscar()
            'Actualizar_Precio_BkRandom(ListaBusq)
            'BUSCA()
        End If

    End Sub

    Private Sub Frm_BuscarXProducto_Mt_Listas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Consulta_sql = "update Zw_ListaPreCosto Set DescSuma = " & vbCrLf & _
                       "100 * (1 - ((1 - (Desc1 / 100.0)) * " & vbCrLf & _
                                    "(1 - (Desc2 / 100.0)) * " & vbCrLf & _
                                    "(1 - (Desc3 / 100.0)) * " & vbCrLf & _
                                    "(1 - (Desc4 / 100.0)) * " & vbCrLf & _
                                    "(1 - (Desc5 / 100.0))))"
         _Sql.Ej_consulta_IDU(Consulta_Sql)

        Sb_Buscar()
        Me.ActiveControl = Txtdescripcion
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        If _Seleccionar_y_cerrar Then
            With Grilla

                Dim _Id As String = .Rows(.CurrentRow.Index).Cells("Id").Value

                Consulta_sql = "Select *," & _
                               "Case when DescSuma > 0 then CostoUd1- (CostoUd1 * (DescSuma/100)) else CostoUd1 End as 'Mcosto'" & vbCrLf & _
                               "From Zw_ListaPreCosto" & vbCrLf & _
                               "Where Id = " & _Id

                _TblProd_Seleccionado = _SQL.Fx_Get_Tablas(Consulta_sql)

                _Seleccionado = True
                Me.Close()

            End With
        End If
    End Sub


    Private Sub Mnu_VerEstadisticas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_VerEstadisticas.Click

        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()


    End Sub

   
    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Codigo As String = Grilla.Rows(Hitest.RowIndex).Cells("Codigo").Value
                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'"))

                    If _Reg Then
                        MenuContextual.Enabled = True
                    Else
                        MenuContextual.Enabled = False
                    End If
                Else
                    MenuContextual.Enabled = False
                End If


            End With
        End If
    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click


        If String.IsNullOrEmpty(Trim(_CodProveedor)) Then

            Dim _Tbl As DataTable = Grilla.DataSource

            ExportarTabla_JetExcel_Tabla(_Tbl, Me, "LCosto")

            Return

            Dim Fm As New Frm_BuscarEntidad_Mt(False)
            Fm.ShowDialog(Me)

            If Not (Fm.Pro_RowEntidad Is Nothing) Then

                Dim _Koen = Fm.Pro_RowEntidad.Item("KOEN")
                Dim _Nokoen = Fm.Pro_RowEntidad.Item("NOKOEN")

                Consulta_sql = "Select * From Zw_ListaPreCosto Where Lista = '" & _CodLista & _
                            "' And Proveedor = '" & _Koen & "'" ' And Sucursal = '" & Fm._Tbl_Inf_Entidad.Rows(0).Item("SUEN") & "'"

                ExportarTabla_JetExcel(Consulta_sql, Me, "LCosto " & _Nokoen)
            End If

        Else

            Consulta_sql = "Select * From Zw_ListaPreCosto Where Lista = '" & _CodLista & "' And Proveedor = '" & _CodProveedor & "'" '_
            '"' And Sucursal = '" & _SucProveedor & "'"

            Dim _Razon As String = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _CodProveedor & "' And SUEN = '" & _SucProveedor & "'")

            ExportarTabla_JetExcel(Consulta_sql, Me, "LCosto " & _Razon)

        End If


    End Sub

    Private Sub VerAsocicaciónDelProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerAsocicaciónDelProductoToolStripMenuItem.Click

        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim _Descripcion As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value

        'Dim Fm As New Frm_Arbol_Asociacion_01
        'Fm._Marcar_Nodos = False
        'Fm._Mostrar_arbol_producto = True
        'Fm._Codigo = _Codigo
        'Fm._Descripcion = _Descripcion
        'Fm.ShowDialog(Me)

        Dim Fm As New Frm_Arbol_Asociacion_01
        Fm.Pro_CheckBoxes_Nodos = False
        Fm.Pro_Codigo_Producto = _Codigo
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.ColumnHeaderMouseClick
        Sb_Marcar_Grilla()
    End Sub

    Private Sub BtnActualizarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizarLista.Click

        If Fx_Tiene_Permiso(Me, "CfEnt014") Then
            Consulta_sql = My.Resources.Sql_Entidad.SqlQuery_Actualizar_Lista_Entidad
            Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodProveedor)
            Consulta_sql = Replace(Consulta_sql, "#Lista#", _CodLista)

             _Sql.Ej_consulta_IDU(Consulta_Sql)

            Sb_Buscar()
        End If

    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If _Seleccionar_y_cerrar Then
            If e.KeyValue = Keys.Enter Then
                SendKeys.Send("{F2}")
                'SendKeys.Send("{LEFT}")
                e.Handled = True

                With Grilla

                    Dim _Id As String = .Rows(.CurrentRow.Index).Cells("Id").Value

                    Consulta_sql = "Select *," & _
                                   "Case when DescSuma > 0 then CostoUd1- (CostoUd1 * (DescSuma/100)) else CostoUd1 End as 'Mcosto'" & vbCrLf & _
                                   "From Zw_ListaPreCosto" & vbCrLf & _
                                   "Where Id = " & _Id

                    _TblProd_Seleccionado = _SQL.Fx_Get_Tablas(Consulta_sql)

                    _Seleccionado = True
                    Me.Close()

                End With
            End If
        End If

    End Sub
End Class