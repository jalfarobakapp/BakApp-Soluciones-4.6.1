'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_AsisCompra_Proyeccion_Detalle

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ud As Integer
    Dim _TblInforme As DataTable
    Dim _Tbl_Detalle As DataTable
    Dim _Tbl_Filtro_Detalle As DataTable

    Dim _Ds_Proyecto As DataSet
    Dim _Rotacion_Diaria As Double
    Dim _Stock_Critico As Double

    Private _dv As New DataView

    Public Sub New(ByVal Ds_Proyecto As DataSet, _
                   ByVal Ud As Integer, _
                   ByVal Rotacion_Diaria As Double, _
                   ByVal Stock_Critico As Double) 'ByVal TblInforme As DataTable, ByVal Ud As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Ud = Ud
        _Ds_Proyecto = Ds_Proyecto
        _Rotacion_Diaria = Rotacion_Diaria
        _Stock_Critico = Stock_Critico

       Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
       Sb_Formato_Generico_Grilla(Grilla_OCC_Pendientes, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_AsisCompra_Proyeccion_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
        AddHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Duracion As String

        Me.Text = "Informe de proyección de compras a nivel: " & _Duracion

        _TblInforme = _Ds_Proyecto.Tables(0)
        _Tbl_Detalle = _Ds_Proyecto.Tables(2)

        With Grilla

            .DataMember = "Table"
            .DataSource = _Ds_Proyecto

            OcultarEncabezadoGrilla(Grilla, False)

            Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True

            .Columns("Descripcion").Width = 280
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

            .Columns("Ud" & _Ud).Width = 30
            .Columns("Ud" & _Ud).HeaderText = "UN"
            .Columns("Ud" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ud" & _Ud).Visible = True

            .Columns("StockUd" & _Ud).Width = 60
            .Columns("StockUd" & _Ud).HeaderText = "Stock"
            .Columns("StockUd" & _Ud).DefaultCellStyle.Format = "##,###"
            .Columns("StockUd" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StockUd" & _Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("StockUd" & _Ud).Visible = True

            .Columns("StockPedidoUd" & _Ud).Width = 60
            .Columns("StockPedidoUd" & _Ud).HeaderText = "Stock Pedido"
            .Columns("StockPedidoUd" & _Ud).DefaultCellStyle.Format = "##,###"
            .Columns("StockPedidoUd" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockPedidoUd" & _Ud).Visible = True

            .Columns("StockFacSinRecepUd" & _Ud).Width = 60
            .Columns("StockFacSinRecepUd" & _Ud).HeaderText = "Stock F/S Recep."
            .Columns("StockFacSinRecepUd" & _Ud).DefaultCellStyle.Format = "##,###"
            .Columns("StockFacSinRecepUd" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockFacSinRecepUd" & _Ud).Visible = True

            .Columns("RotDiariaUd" & _Ud).Width = 60
            .Columns("RotDiariaUd" & _Ud).HeaderText = "Rotación diaria"
            .Columns("RotDiariaUd" & _Ud).DefaultCellStyle.Format = "##,### "
            .Columns("RotDiariaUd" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotDiariaUd" & _Ud).Visible = True

            .Columns("RotEfectivaUd" & _Ud).Width = 60
            .Columns("RotEfectivaUd" & _Ud).HeaderText = "Rotación efectiva"
            .Columns("RotEfectivaUd" & _Ud).DefaultCellStyle.Format = "##,### "
            .Columns("RotEfectivaUd" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotEfectivaUd" & _Ud).Visible = True

            '.Columns("Duracion_Dias").Width = 60
            '.Columns("Duracion_Dias").HeaderText = "Duración días"
            '.Columns("Duracion_Dias").DefaultCellStyle.Format = "##,###"
            '.Columns("Duracion_Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Duracion_Dias").Visible = True

            .Columns("Duracion_Proyeccion").Width = 60
            .Columns("Duracion_Proyeccion").HeaderText = "Duración " & _Duracion
            .Columns("Duracion_Proyeccion").DefaultCellStyle.Format = "##,###"
            .Columns("Duracion_Proyeccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Duracion_Proyeccion").Visible = True

            '.Columns("Cant_Comprar").Width = 60
            '.Columns("Cant_Comprar").HeaderText = "Cant. necesaria" '"Cant. Comprar"
            '.Columns("Cant_Comprar").DefaultCellStyle.Format = "##,###"
            '.Columns("Cant_Comprar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Cant_Comprar").Visible = True

            .Columns("Cant_Comprar_Sug").Width = 60
            .Columns("Cant_Comprar_Sug").HeaderText = "Cant. Sugerida comprar"
            .Columns("Cant_Comprar_Sug").DefaultCellStyle.Format = "##,###"
            .Columns("Cant_Comprar_Sug").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .Columns("Cant_Comprar_Sug").Frozen = True
            .Columns("Cant_Comprar_Sug").Visible = True

            .Refresh()

        End With


        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        With _Ds_Proyecto
            .Relations.Add("mi_Relacion", _
                          .Tables("Table").Columns("Codigo"), _
                          .Tables("Table2").Columns("Codigo"))
        End With


        _Tbl_Filtro_Detalle = Fx_Crea_Tabla_Con_Filtro(_Tbl_Detalle, "TIDO = 'XXX'", "IDMAEEDO")

        ' Establecer el DataSource y el DataMember para el DataGridview Detalle  
        With Grilla_OCC_Pendientes

            .DataSource = _Tbl_Filtro_Detalle ' _Ds_Proyecto

            OcultarEncabezadoGrilla(Grilla_OCC_Pendientes, False)

            Grilla_OCC_Pendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True

            .Columns("NUDO").Width = 90
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Visible = True

            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Visible = True

            .Columns("Razon").Width = 260
            .Columns("Razon").HeaderText = "Nombre Proveedor"
            .Columns("Razon").Visible = True

            .Columns("UD0" & _Ud & "PR").Width = 30
            .Columns("UD0" & _Ud & "PR").HeaderText = "UD"
            .Columns("UD0" & _Ud & "PR").Visible = True

            .Columns("CAPRCO" & _Ud).Width = 60
            .Columns("CAPRCO" & _Ud).HeaderText = "Cantidad"
            .Columns("CAPRCO" & _Ud).DefaultCellStyle.Format = "##,###"
            .Columns("CAPRCO" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StockUd" & _Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("CAPRCO" & _Ud).Visible = True

            .Columns("CAPREX" & _Ud).Width = 60
            .Columns("CAPREX" & _Ud).HeaderText = "Cant. Recep."
            .Columns("CAPREX" & _Ud).DefaultCellStyle.Format = "##,###"
            .Columns("CAPREX" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StockUd" & _Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("CAPREX" & _Ud).Visible = True

            .Columns("Saldo").Width = 60
            .Columns("Saldo").HeaderText = "Saldo"
            .Columns("Saldo").DefaultCellStyle.Format = "##,###"
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StockUd" & _Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("Saldo").Visible = True

            .Columns("FEERLI").Width = 100
            .Columns("FEERLI").HeaderText = "F. Recepción"
            .Columns("FEERLI").Visible = True

        End With

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Frm_AsisCompra_Proyeccion_Detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    ShowContextMenu(Menu_Contextual_Productos)

                End If
            End With
        End If
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)

        Fm.Chk_Agrupar_Asociados.Checked = 1
        Fm.Input_Stock_Minimo.Value = _Stock_Critico
        Fm.Pro_Tbl_Productos_Hermanos = _TblInforme
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_OCC_Pendientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_OCC_Pendientes.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(e.ColumnIndex).Name

        Dim _Idmaeedo = Grilla_OCC_Pendientes.Rows(Grilla_OCC_Pendientes.CurrentRow.Index).Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Call Sb_Grilla_CellEnter(Nothing, Nothing)
        
    End Sub

    Private Sub Sb_Grilla_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Tido As String

        Select Case _Cabeza
            Case "StockPedidoUd1", "StockPedidoUd2"
                _Tido = "OCC"
            Case "StockFacSinRecepUd1", "StockFacSinRecepUd2"
                _Tido = "FCC"
            Case Else
                _Tido = "XXX"
        End Select

        Dim _CodTido = _Tido & _Codigo

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select KOPRCT As Codigo,IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,(Select Top 1 NOKOEN From MAEEN Where KOEN+SUEN = ENDO+SUENDO) As Razon," & _
                       "UD0" & _Ud & "PR,CAPRCO" & _Ud & ",CAPREX" & _Ud & ",(CAPRCO" & _Ud & "-(CAPRAD" & _Ud & "+CAPREX" & _Ud & ")) As Saldo, FEERLI " & vbCrLf & _
                       "From MAEDDO" & vbCrLf & _
                       "Where KOPRCT = '" & _Codigo & "' And " & vbCrLf & _
                       "TIDO = '" & _Tido & "' And ESLIDO = ''" & vbCrLf & _
                       "Order By NUDO "

        _Tbl_Filtro_Detalle = _Sql.Fx_Get_DataTable(Consulta_sql) 'Fx_Crea_Tabla_Con_Filtro(_Tbl_Detalle, "TIDO+Codigo = '" & _CodTido & "'", "IDMAEEDO")

        Grilla_OCC_Pendientes.DataSource = _Tbl_Filtro_Detalle

        Dim _Fecha_Servidor As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

        For Each _Row As DataGridViewRow In Grilla_OCC_Pendientes.Rows

            Dim _Feerli As Date = FormatDateTime(_Row.Cells("FEERLI").Value, DateFormat.ShortDate)

            If _Feerli < _Fecha_Servidor Then
                '_Fila.DefaultCellStyle.ForeColor = Color.Gray
                _Row.Cells("FEERLI").Style.ForeColor = Color.Red
            Else
                '_Fila.DefaultCellStyle.BackColor = Color.Yellow
                _Row.Cells("FEERLI").Style.ForeColor = Color.Black
            End If

        Next

    End Sub


End Class