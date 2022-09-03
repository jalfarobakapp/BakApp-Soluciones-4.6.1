Imports DevComponents.DotNetBar

Public Class Frm_CumplXProveedor

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Koen As String
    Dim _Suen As String
    Dim _Codigo As String
    Dim _Meses As Integer

    Public Sub New(_Koen As String, _Suen As String, _Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Koen = _Koen
        Me._Suen = _Suen
        Me._Codigo = _Codigo

        Sb_Formato_Generico_Grilla(Grilla_Producto, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, False, True, False)
        Sb_Formato_Generico_Grilla(Grilla_OCC, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_GRC_FCC, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Meses = 3

    End Sub

    Private Sub Frm_CumplXProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_OCC.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_GRC_FCC.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dim _Row_Proveedor As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        Txt_Proveedor.Text = _Row_Proveedor.Item("Rut") & " - (" & _Koen.ToString.Trim & " - " & _Suen.ToString.Trim & ") - " & _Row_Proveedor.Item("NOKOEN")

        Sb_Actualizar_Grillas()
        Sb_Formato_Grillas()

        Me.Text = "Información de complimiento de entrega por parte del proveedor últimos " & _Meses & " meses"

    End Sub

    Sub Sb_Actualizar_Grillas()

        Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_Calculo_de_cumplimiento_de_entregas_por_parte_de_un_proveedor_por_Producto
        Consulta_sql = Replace(Consulta_sql, "#Koen#", _Koen)
        Consulta_sql = Replace(Consulta_sql, "#Suen#", _Suen)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Meses#", 3)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        _Ds.Relations.Add("Rel_Occ",
                          _Ds.Tables("Table").Columns("KOPRCT"),
                          _Ds.Tables("Table1").Columns("KOPRCT"), False)

        _Ds.Relations.Add("Rel_Occ_GrcFcc",
                    _Ds.Tables("Table1").Columns("IDMAEDDO"),
                    _Ds.Tables("Table2").Columns("IDMAEDDO_OCC"), False)

        Grilla_Producto.DataSource = _Ds
        Grilla_Producto.DataMember = "Table"

        'Muestra segunda relacion
        Grilla_OCC.DataSource = _Ds
        Grilla_OCC.DataMember = "Table.Rel_Occ"

        'Muestra tercera relacion
        Grilla_GRC_FCC.DataSource = _Ds
        Grilla_GRC_FCC.DataMember = "Table.Rel_Occ.Rel_Occ_GrcFcc"

        'OcultarEncabezadoGrilla(Grilla_Producto, True)
        'OcultarEncabezadoGrilla(Grilla_OCC, True)
        'OcultarEncabezadoGrilla(Grilla_GRC_FCC, True)

    End Sub

    Sub Sb_Formato_Grillas()

        Dim _DisplayIndex = 0

        With Grilla_Producto

            OcultarEncabezadoGrilla(Grilla_Producto, False)

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO1").Width = 60
            .Columns("CAPRCO1").HeaderText = "Cant. Sol"
            .Columns("CAPRCO1").ToolTipText = "Cantidad solicitada"
            .Columns("CAPRCO1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO1").DefaultCellStyle.Format = "###,#0"
            .Columns("CAPRCO1").Visible = True
            .Columns("CAPRCO1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPREX1").Width = 60
            .Columns("CAPREX1").HeaderText = "Cant. Recep"
            .Columns("CAPREX1").ToolTipText = "Cantidad enviada pro el proveedor y recepcionada en bodega"
            .Columns("CAPREX1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX1").DefaultCellStyle.Format = "###,#0"
            .Columns("CAPREX1").Visible = True
            .Columns("CAPREX1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRAD1").Width = 60
            .Columns("CAPRAD1").HeaderText = "Cant.No Recep"
            .Columns("CAPRAD1").ToolTipText = "Cantidad No enviada, documento cerrado."
            .Columns("CAPRAD1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRAD1").DefaultCellStyle.Format = "###,#0"
            .Columns("CAPRAD1").Visible = True
            .Columns("CAPRAD1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Cumplimiento").Width = 60
            .Columns("Porc_Cumplimiento").HeaderText = "% Cumpl."
            .Columns("Porc_Cumplimiento").ToolTipText = "Porcentaje de cumplimiento"
            .Columns("Porc_Cumplimiento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Cumplimiento").DefaultCellStyle.Format = "% ###,##.0#"
            .Columns("Porc_Cumplimiento").Visible = True
            .Columns("Porc_Cumplimiento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_CumpUlt3Pedidos").Width = 60
            .Columns("Porc_CumpUlt3Pedidos").HeaderText = "% C.U.3 Ped."
            .Columns("Porc_CumpUlt3Pedidos").ToolTipText = "Porcentaje de cumplimiento últimos 3 pedidos (OCC)"
            .Columns("Porc_CumpUlt3Pedidos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_CumpUlt3Pedidos").DefaultCellStyle.Format = "% ###,##.0#"
            .Columns("Porc_CumpUlt3Pedidos").Visible = True
            .Columns("Porc_CumpUlt3Pedidos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Dias_Prom_Entrega").Width = 60
            .Columns("Dias_Prom_Entrega").HeaderText = "Días Prom.Ent"
            .Columns("Dias_Prom_Entrega").ToolTipText = "Días que demora en llegar el pedido en promedio"
            .Columns("Dias_Prom_Entrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias_Prom_Entrega").Visible = True
            .Columns("Dias_Prom_Entrega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        _DisplayIndex = 0

        With Grilla_OCC

            OcultarEncabezadoGrilla(Grilla_OCC, False)

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 100
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").Width = 100
            .Columns("FEEMLI").HeaderText = "F.Emisión"
            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD01PR").Width = 40
            .Columns("UD01PR").HeaderText = "UN"
            .Columns("UD01PR").Visible = True
            .Columns("UD01PR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO1").Width = 60
            .Columns("CAPRCO1").HeaderText = "Cant. Sol"
            .Columns("CAPRCO1").ToolTipText = "Cantidad solicitada"
            .Columns("CAPRCO1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO1").DefaultCellStyle.Format = "###,#0"
            .Columns("CAPRCO1").Visible = True
            .Columns("CAPRCO1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPREX1").Width = 60
            .Columns("CAPREX1").HeaderText = "Cant. Recep"
            .Columns("CAPREX1").ToolTipText = "Cantidad enviada pro el proveedor y recepcionada en bodega"
            .Columns("CAPREX1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX1").DefaultCellStyle.Format = "###,#0"
            .Columns("CAPREX1").Visible = True
            .Columns("CAPREX1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRAD1").Width = 60
            .Columns("CAPRAD1").HeaderText = "Cant.No Recep"
            .Columns("CAPRAD1").ToolTipText = "Cantidad No enviada, documento cerrado."
            .Columns("CAPRAD1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRAD1").DefaultCellStyle.Format = "###,#0"
            .Columns("CAPRAD1").Visible = True
            .Columns("CAPRAD1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_CumplimientoUd1").Width = 60
            .Columns("Porc_CumplimientoUd1").HeaderText = "% Cumpl."
            .Columns("Porc_CumplimientoUd1").ToolTipText = "Porcentaje de cumplimiento"
            .Columns("Porc_CumplimientoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_CumplimientoUd1").DefaultCellStyle.Format = "% ###,##.0#"
            .Columns("Porc_CumplimientoUd1").Visible = True
            .Columns("Porc_CumplimientoUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        _DisplayIndex = 0

        With Grilla_GRC_FCC

            OcultarEncabezadoGrilla(Grilla_GRC_FCC, False)

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 100
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").Width = 100
            .Columns("FEEMLI").HeaderText = "F.Emisión"
            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD01PR").Width = 40
            .Columns("UD01PR").HeaderText = "UN"
            .Columns("UD01PR").Visible = True
            .Columns("UD01PR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO1").Width = 60
            .Columns("CAPRCO1").HeaderText = "Cant. Recep"
            .Columns("CAPRCO1").ToolTipText = "Cantidad recepcionada"
            .Columns("CAPRCO1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO1").DefaultCellStyle.Format = "###,#0"
            .Columns("CAPRCO1").Visible = True
            .Columns("CAPRCO1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Dias_Llega").Width = 60
            .Columns("Dias_Llega").HeaderText = "Días Demora"
            .Columns("Dias_Llega").ToolTipText = "Días en que tardo en llegar el producto desde la orden de compra"
            .Columns("Dias_Llega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias_Llega").Visible = True
            .Columns("Dias_Llega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla_OCC.Rows

            Dim _Caprex1 As Double = _Fila.Cells("CAPREX1").Value
            Dim _Caprad1 As Double = _Fila.Cells("CAPRAD1").Value

            If _Caprex1 > 0 Then
                _Fila.Cells("CAPREX1").Style.ForeColor = Verde
            End If

            If _Caprex1 <= 0 Then
                _Fila.Cells("CAPREX1").Style.ForeColor = Rojo
            End If

            If _Caprad1 > 0 Then
                _Fila.Cells("CAPRAD1").Style.ForeColor = Rojo
            End If

        Next

    End Sub



End Class
