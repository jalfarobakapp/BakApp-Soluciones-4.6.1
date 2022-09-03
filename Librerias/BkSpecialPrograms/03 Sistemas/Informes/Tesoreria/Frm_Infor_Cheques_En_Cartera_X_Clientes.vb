'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Infor_Cheques_En_Cartera_X_Clientes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _dv As New DataView

    Dim _Filtro_Entidad = String.Empty

    Public Property Pro_Filtro_Entidad() As String
        Get
            Return _Filtro_Entidad
        End Get
        Set(ByVal value As String)
            _Filtro_Entidad = "And Mdc.ENDP = '" & value & "'"
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 7.5), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Infor_Cheques_En_Cartera_X_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualiar_Grilla()

        AddHandler TxtDescripcion.TextChanged, AddressOf TxtDescripcion_TextChanged
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If Not String.IsNullOrEmpty(TxtDescripcion.Text) Then
            Call TxtDescripcion_TextChanged(Nothing, Nothing)
        End If

    End Sub

    Sub Sb_Actualiar_Grilla()

        Consulta_sql = My.Resources.Recursos_Inf_Tesoreria.SQLQuery_Informe_de_cheques_en_cartera_por_clientes
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidad#", _Filtro_Entidad)
        ',,,CUENTA
        ',,,,,,,
        ',,,,

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _dv.Table = _Ds.Tables(0)

        With Grilla

            .DataSource = _dv

            OcultarEncabezadoGrilla(Grilla, True)


            .Columns("TIPO_DOC").HeaderText = "TD"
            .Columns("TIPO_DOC").Width = 30
            .Columns("TIPO_DOC").Visible = True

            .Columns("COD_BANCO").HeaderText = "Cód."
            .Columns("COD_BANCO").Width = 30
            .Columns("COD_BANCO").Visible = True

            .Columns("NOM_BANCO").HeaderText = "Banco"
            .Columns("NOM_BANCO").Width = 190
            .Columns("NOM_BANCO").Visible = True

            .Columns("N_DOC").HeaderText = "Nro. Cheque"
            .Columns("N_DOC").Width = 60
            .Columns("N_DOC").Visible = True

            .Columns("KOEN").HeaderText = "Entidad"
            .Columns("KOEN").Width = 65
            .Columns("KOEN").Visible = True

            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 200
            .Columns("NOKOEN").Visible = True

            .Columns("FEVEDP").HeaderText = "Fecha Venc."
            .Columns("FEVEDP").Width = 55
            .Columns("FEVEDP").Visible = True

            .Columns("MONTO").HeaderText = "Valor"
            .Columns("MONTO").Width = 80
            .Columns("MONTO").Visible = True
            .Columns("MONTO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("MONTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("CUENTA").HeaderText = "Nro. Cta."
            .Columns("CUENTA").Width = 80
            .Columns("CUENTA").Visible = True

            'For Each _Fila As DataGridViewRow In .Rows

            'Dim _TipoCredito As String = _Fila.Cells("TipoCredito").Value
            'Dim _Disponible As Double = _Fila.Cells("Disponible").Value

            'If _Disponible < 0 Then
            '_Fila.Cells("Disponible").Style.ForeColor = Color.Red
            'Else
            'If _TipoCredito = "Max. crédito" Then
            '_Fila.Cells("Disponible").Style.ForeColor = Color.DarkGreen
            'End If
            'End If

            'Next

        End With

        Dim _Total As Double = NuloPorNro(_dv.Table.Compute("SUM(MONTO)", "1>0"), 0)
        Lbl_Total.Text = FormatCurrency(_Total, 0)

    End Sub

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Descripcion As String = Trim(TxtDescripcion.Text)

        If String.IsNullOrEmpty(_Descripcion) Then
            Sb_Actualiar_Grilla()
            Return
        End If

        _dv.RowFilter = String.Format("KOEN+NOKOEN+NOM_BANCO+MONTO+N_DOC+FEVEDP Like '%{0}%'", _Descripcion)

        Dim _Total As Double = NuloPorNro(_dv.Table.Compute("SUM(MONTO)",
                                                 "KOEN+NOKOEN+NOM_BANCO+MONTO+N_DOC+FEVEDP Like '%" & _Descripcion & "%'"), 0)
        Lbl_Total.Text = FormatCurrency(_Total, 0)

    End Sub

    Private Sub Frm_Infor_Cheques_En_Cartera_X_Clientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click

        Dim _TblExcel As DataTable
        _TblExcel = Fx_Crea_Tabla_Con_Filtro(_dv.Table,
                                             "KOEN+NOKOEN+NOM_BANCO+MONTO+N_DOC+FEVEDP Like '%" & TxtDescripcion.Text & "%'",
                                             "FEVEDP")

        ExportarTabla_JetExcel_Tabla(_TblExcel, Me, "Cheques en cartera")
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaedpce = _Fila.Cells("IDMAEDPCE").Value

        Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
