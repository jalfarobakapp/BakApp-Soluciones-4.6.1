Imports System.Security.Cryptography

Public Class Frm_Cms_Periodos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Periodos As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Cms_Periodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Enc" & vbCrLf &
                       "Order By Mes,Ano"
        _Tbl_Periodos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_Periodos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Periodo").Width = 100
            .Columns("Periodo").HeaderText = "Periodo"
            .Columns("Periodo").Visible = True
            .Columns("Periodo").ReadOnly = False
            .Columns("Periodo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre").Width = 380
            .Columns("Nombre").HeaderText = "Nombre comisiones"
            .Columns("Nombre").Visible = True
            .Columns("Nombre").ReadOnly = False
            .Columns("Nombre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Width = 100
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = True
            .Columns("Estado").ReadOnly = False
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_NuevoPeriodo_Click(sender As Object, e As EventArgs) Handles Btn_NuevoPeriodo.Click

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Cms_Periodos_Crear(0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Call Btn_RevisarPeriodo_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_RevisarPeriodo_Click(sender As Object, e As EventArgs) Handles Btn_RevisarPeriodo.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Cms(_Id)
        Fm.Text = "MANTENCION DE COMISIONES POR PERIODO"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_EditarPeriodo_Click(sender As Object, e As EventArgs) Handles Btn_EditarPeriodo.Click

        Dim _Grabar As Boolean

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Cms_Periodos_Crear(_Id)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub


    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub
End Class
