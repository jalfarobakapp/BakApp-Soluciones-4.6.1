Imports DevComponents.DotNetBar

Imports BkSpecialPrograms

Public Class Frm_Maquinas_vs_Carga_De_Trabajo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Maquinas As DataTable
    Dim _Tbl_Carga_Trabajo As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Maquinas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Carga_Trabajo, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
    End Sub

    Private Sub Frm_Maquinas_vs_Carga_De_Trabajo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Maquinas.RowPostPaint, AddressOf Sb_Grilla_RowsPostPaint
        AddHandler Grilla_Carga_Trabajo.RowPostPaint, AddressOf Sb_Grilla_RowsPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Table As String

        If Chk_Maquinas_Carga.Checked Then
            _Table = "Table"
        Else
            _Table = "Table1"
        End If

        Consulta_sql = My.Resources.Recursos_Informe_Produccion.SQLQuery_Informe_estado_de_Maquinas_Vs_Avence_y_cola_en_proceso

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        _Ds.Relations.Add("Rel_Detalle_Productos",
                          _Ds.Tables(_Table).Columns("CODMAQOT"),
                          _Ds.Tables("Table2").Columns("CODMAQOT"), False)

        _Tbl_Carga_Trabajo = _Ds.Tables(2)

        Grilla_Maquinas.DataSource = _Ds
        Grilla_Maquinas.DataMember = _Table

        'Muestra segunda relacion
        Grilla_Carga_Trabajo.DataSource = _Ds
        Grilla_Carga_Trabajo.DataMember = _Table & ".Rel_Detalle_Productos"

        OcultarEncabezadoGrilla(Grilla_Maquinas, True)
        OcultarEncabezadoGrilla(Grilla_Carga_Trabajo, True)

        With Grilla_Maquinas

            .Columns("CODMAQOT").Width = 100
            .Columns("CODMAQOT").HeaderText = "Máquina"
            .Columns("CODMAQOT").Visible = True
            .Columns("CODMAQOT").DisplayIndex = 0

            .Columns("MAQUINA").Width = 360
            .Columns("MAQUINA").HeaderText = "Nombre máquina"
            .Columns("MAQUINA").Visible = True
            .Columns("MAQUINA").DisplayIndex = 1

            .Columns("FABRICAR").Width = 80
            .Columns("FABRICAR").HeaderText = "Fabricar"
            .Columns("FABRICAR").Visible = True
            .Columns("FABRICAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns("FABRICAR").DisplayIndex = 2

            .Columns("REALIZADO").Width = 80
            .Columns("REALIZADO").HeaderText = "Realizado"
            .Columns("REALIZADO").Visible = True
            .Columns("REALIZADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("REALIZADO").DisplayIndex = 3

            .Columns("Porc_Fabricado").Width = 80
            .Columns("Porc_Fabricado").HeaderText = "% Fabricado"
            .Columns("Porc_Fabricado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Fabricado").DefaultCellStyle.Format = "% #0.##"
            .Columns("Porc_Fabricado").Visible = True
            .Columns("Porc_Fabricado").DisplayIndex = 4

            .Columns("Porc_Cola").Width = 80
            .Columns("Porc_Cola").HeaderText = "% Cola"
            .Columns("Porc_Cola").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Cola").DefaultCellStyle.Format = "% #0.##"
            .Columns("Porc_Cola").Visible = True
            .Columns("Porc_Cola").DisplayIndex = 4

        End With


        With Grilla_Carga_Trabajo

            .Columns("NUMOT").Width = 70
            .Columns("NUMOT").HeaderText = "Nro OT"
            .Columns("NUMOT").Visible = True
            .Columns("NUMOT").DisplayIndex = 0

            .Columns("NREGOTL").Width = 50
            .Columns("NREGOTL").HeaderText = "Sub-OT"
            .Columns("NREGOTL").Visible = True
            .Columns("NREGOTL").DisplayIndex = 1

            .Columns("REFERENCIA").Width = 240
            .Columns("REFERENCIA").HeaderText = "Referencia"
            .Columns("REFERENCIA").Visible = True
            .Columns("REFERENCIA").DisplayIndex = 2

            '.Columns("CODIGO").Width = 70
            '.Columns("CODIGO").HeaderText = "Código"
            '.Columns("CODIGO").Visible = True
            '.Columns("CODIGO").DisplayIndex = 3

            .Columns("DESCRIPCION_PR").Width = 240
            .Columns("DESCRIPCION_PR").HeaderText = "Articulo a fabricar"
            .Columns("DESCRIPCION_PR").Visible = True
            .Columns("DESCRIPCION_PR").DisplayIndex = 3

            '.Columns("OPERACION").Width = 70
            '.Columns("OPERACION").HeaderText = "Operación"
            '.Columns("OPERACION").Visible = True
            '.Columns("OPERACION").DisplayIndex = 4

            '.Columns("NOMBREOP").Width = 240
            '.Columns("NOMBREOP").HeaderText = "Nombre operación"
            '.Columns("NOMBREOP").Visible = True
            '.Columns("NOMBREOP").DisplayIndex = 2

            .Columns("FABRICAR").Width = 60
            .Columns("FABRICAR").HeaderText = "Fabricar"
            .Columns("FABRICAR").Visible = True
            .Columns("FABRICAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FABRICAR").DisplayIndex = 4

            .Columns("REALIZADO").Width = 60
            .Columns("REALIZADO").HeaderText = "Realizado"
            .Columns("REALIZADO").Visible = True
            .Columns("REALIZADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("REALIZADO").DisplayIndex = 5

            .Columns("AVANCE").Width = 50
            .Columns("AVANCE").HeaderText = "Saldo"
            .Columns("AVANCE").Visible = True
            .Columns("AVANCE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("AVANCE").DisplayIndex = 6

            ' .Columns("Porc_Avance").Width = 60
            ' .Columns("Porc_Avance").HeaderText = "% Avance"
            ' .Columns("Porc_Avance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .Columns("Porc_Avance").DefaultCellStyle.Format = "% #0.##"
            ' .Columns("Porc_Avance").Visible = True
            ' .Columns("Porc_Avance").DisplayIndex = 4

        End With

    End Sub

    Private Sub Btn_Actualizar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Grilla_RowsPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
