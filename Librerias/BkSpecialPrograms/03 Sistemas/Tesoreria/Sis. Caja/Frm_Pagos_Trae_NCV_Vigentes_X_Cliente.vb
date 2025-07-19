'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Trae_NCV_Vigentes_X_Cliente

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Koen As String
    Dim _Idmaeedo As Integer
    Dim _Numero As String
    Dim _Tbl_Notas_de_credito As DataTable

    Public ReadOnly Property Pro_Tbl_Notas_de_credito() As DataTable
        Get
            Return _Tbl_Notas_de_credito
        End Get
    End Property

    Public ReadOnly Property Pro_Numero() As String
        Get
            Return _Numero
        End Get
    End Property

    Public Property Idmaeedo As Integer
        Get
            Return _Idmaeedo
        End Get
        Set(value As Integer)
            _Idmaeedo = value
        End Set
    End Property

    Public Sub New(ByVal Koen As String, _Condicion_Extra As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Koen = Koen

        Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,FEEMDO,VABRDO,VAABDO,VAIVARET,VABRDO-VAABDO AS SALDO,ESPGDO,MODO From MAEEDO" & vbCrLf &
                       "Where EMPRESA = '" & Mod_Empresa & "' And ENDO = '" & _Koen & "' And TIDO = 'NCV' AND ESPGDO = 'P' And VABRDO > 0" & vbCrLf & _Condicion_Extra
        _Tbl_Notas_de_credito = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Pagos_Trae_NCV_Vigentes_X_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Numero = String.Empty
        Sb_Actualizar_Grilla()
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Btn_Seleccionar.Visible = False

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_Notas_de_credito

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 40
            .Columns("TIDO").Visible = True

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True

            .Columns("FEEMDO").HeaderText = "F.emisión."
            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").Visible = True

            .Columns("VABRDO").HeaderText = "Valor documento"
            .Columns("VABRDO").Width = 110
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##.##"

            .Columns("VAABDO").HeaderText = "Valor utilizado"
            .Columns("VAABDO").Width = 110
            .Columns("VAABDO").Visible = True
            .Columns("VAABDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABDO").DefaultCellStyle.Format = "$ ###,##.##"

            .Columns("SALDO").HeaderText = "Saldo favor"
            .Columns("SALDO").Width = 100
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##.##"


        End With


        For Each _Fila As DataGridViewRow In Grilla.Rows

            _Fila.Cells("VABRDO").Style.ForeColor = Color.Gray
            _Fila.Cells("VAABDO").Style.ForeColor = Color.Gray

            _Fila.Cells("SALDO").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
            _Fila.Cells("SALDO").Style.ForeColor = Color.Green

        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        _Numero = _Fila.Cells("NUDO").Value

        Me.Close()

    End Sub

    Private Sub Btn_Seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccionar.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Frm_Pagos_Trae_NCV_Vigentes_X_Cliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{F2}")
            e.Handled = True
            Call Grilla_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub
End Class
