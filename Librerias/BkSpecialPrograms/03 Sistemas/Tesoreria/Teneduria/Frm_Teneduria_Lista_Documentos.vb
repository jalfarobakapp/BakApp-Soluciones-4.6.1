'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_Teneduria_Lista_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Tbl_Informe As DataTable
    Dim _Seleccionar As Boolean
    Dim _Row_Documento As DataRow

    Public Property Pro_Tbl_Informe() As DataTable
        Get
            Return _Tbl_Informe
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Informe = value
        End Set
    End Property
    Public Property Pro_Row_Documento() As DataRow
        Get
            Return _Row_Documento
        End Get
        Set(ByVal value As DataRow)
            _Row_Documento = value
        End Set
    End Property

    Public Sub New(ByVal Solo_Seleccionar As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Text = "DOCUMENTOS DE PAGO"
        _Seleccionar = Solo_Seleccionar

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Seleccionar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Teneduria_Lista_Documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If _Seleccionar Then
            AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Documento
        Else
            AddHandler Grilla.CellDoubleClick, AddressOf Btn_Ver_Documento_Click
        End If


        If Not (_Tbl_Informe Is Nothing) Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Public Sub Sb_Actualizar_Grilla()


        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, True)


            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 30
            .Columns("TIDP").Visible = True
            .Columns("TIDP").DisplayIndex = 0

            .Columns("NUDP").HeaderText = "Número"
            .Columns("NUDP").Width = 80
            .Columns("NUDP").Visible = True
            .Columns("NUDP").DisplayIndex = 1

            .Columns("FEEMDP").HeaderText = "Emisión"
            .Columns("FEEMDP").Width = 80
            .Columns("FEEMDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").DisplayIndex = 2

            .Columns("FEVEDP").HeaderText = "Vencim."
            .Columns("FEVEDP").Width = 80
            .Columns("FEVEDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DisplayIndex = 3

            .Columns("MODP").HeaderText = "M."
            .Columns("MODP").Width = 20
            .Columns("MODP").Visible = True
            .Columns("MODP").DisplayIndex = 4

            .Columns("VADP").Width = 90
            .Columns("VADP").HeaderText = "Valor"
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VADP").Visible = True
            .Columns("VADP").DisplayIndex = 5

            .Columns("ESTADO").Width = 90
            .Columns("ESTADO").HeaderText = "Estado"
            .Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ESTADO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("ESTADO").Visible = True
            .Columns("ESTADO").DisplayIndex = 6

            .Columns("NUCUDP").HeaderText = "Nro. doc. pago"
            .Columns("NUCUDP").Width = 90
            '.Columns("NUCUDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").DisplayIndex = 7

            '.Columns("CTACTE").HeaderText = "Nro Cta.Cte."
            '.Columns("CTACTE").Width = 100
            '.Columns("CTACTE").Visible = True
            '.Columns("CTACTE").DisplayIndex = 8

            .Columns("SUREDP").HeaderText = "Suc."
            .Columns("SUREDP").Width = 30
            .Columns("SUREDP").Visible = True
            .Columns("SUREDP").DisplayIndex = 9

            .Columns("CJREDP").HeaderText = "Caja"
            .Columns("CJREDP").Width = 30
            .Columns("CJREDP").Visible = True
            .Columns("CJREDP").DisplayIndex = 10

        End With

        Lbl_Entidad.DataBindings.Add(New System.Windows.Forms.Binding("Text", _Tbl_Informe, "NOKOEN", True))

    End Sub

    Private Sub Btn_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

        Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Imprimir_Cheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Cheque.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

        Dim _Tidp = _Fila.Cells("TIDP").Value
        Dim _Nudp = _Fila.Cells("NUDP").Value
        Dim _Emdp = _Fila.Cells("EMDP").Value

        Consulta_sql = "Select Top 1 * From TABENDP WHERE TIDPEN = 'CH' AND KOENDP = '" & _Emdp & "'"
        Dim _Row_Tabendp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf & _
                       "Where TipoDoc = 'CHC' And Emdp = '" & _Emdp & "'"
        Dim _Row_Formato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _NombreFormato = Trim("Cta.Cte: " & _Row_Tabendp.Item("CTACTE")) '000069764215


        Dim _Imprimir As New Clas_Imprimir_Documento(_Idmaedpce,
                                                     "CHC",
                                                     _NombreFormato,
                                                     _Tidp & "-" & _Nudp,
                                                     False, _Emdp, "")

        If Not _Imprimir.Fx_seleccionar_Impresora(True) Then
            Return
        End If

        _Imprimir.Fx_Imprimir_Documento(Nothing, False)

        Dim _LogError = _Imprimir.Pro_Ultimo_Error

        If Not String.IsNullOrEmpty(_LogError) Then
            MessageBoxEx.Show(Me, _LogError, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Tidp = _Fila.Cells("TIDP").Value

                    Btn_Imprimir_Cheque.Visible = False

                    If Not _Seleccionar Then
                        If _Tidp = "CHC" Then
                            Btn_Imprimir_Cheque.Visible = True
                        End If
                    End If

                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Frm_Teneduria_Lista_Documentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Seleccionar_Documento()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

        Consulta_sql = "Select * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
        _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me.Close()

    End Sub

    Private Sub Btn_Seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccionar.Click
        Sb_Seleccionar_Documento()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        ShowContextMenu(Menu_Contextual_02)
    End Sub

    Private Sub Btn_Exportar_Excel_Conciliacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel_Conciliacion.Click

        Dim _Tbl As DataTable
        Dim _Filtro_Idmaedpce = Generar_Filtro_IN(_Tbl_Informe, "", "IDMAEDPCE", True, False)

        Consulta_sql = My.Resources.Recursos_Teneduria_Pagos.SQLQuery_Excel_Conciliacion_01
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Idmaedpce#", _Filtro_Idmaedpce)
        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Conciliacion")

    End Sub

    Private Sub Btn_Exportar_Excel_Vista_Todo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel_Vista_Todo.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Teneduria")
    End Sub

End Class
