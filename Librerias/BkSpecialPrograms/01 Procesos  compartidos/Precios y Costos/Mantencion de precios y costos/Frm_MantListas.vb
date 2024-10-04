Imports DevComponents.DotNetBar

Public Class Frm_MantListas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblListas As DataTable
    Public Property ModoSeleccion As Boolean
    Public Property RowListaSeleccionada As DataRow
    Public Property ListaSeleccionada As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_ListaPreGlobal " &
                       "(Tipo,Moneda,Permiso,Lista,Nombre_Lista,ListaCostoxDefecto,TipoValor,ValoresNetos)" & vbCrLf &
                       "Select TILT,MOLT,'Lp-'+KOLT,KOLT,NOKOLT,'02C' as ListaCostoxDefecto,MELT," &
                       "Case MELT When 'N' Then 1 Else 0 End As ValoresNetos" & vbCrLf &
                       "From TABPP Where KOLT Not In (Select Lista From " & _Global_BaseBk & "Zw_ListaPreGlobal)"

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_MantListas_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Bar2.Enabled = Not ModoSeleccion

        Sb_Llenar_Grilla()

    End Sub

    Sub Sb_Llenar_Grilla()

        Consulta_sql = "Select * From TABPP Order by KOLT"
        _TblListas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla
            .DataSource = _TblListas

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOLT").Width = 50
            .Columns("KOLT").HeaderText = "LP"
            .Columns("KOLT").ReadOnly = True
            .Columns("KOLT").Visible = True

            .Columns("NOKOLT").Width = 470
            .Columns("NOKOLT").HeaderText = "Nombre lista"
            .Columns("NOKOLT").ReadOnly = True
            .Columns("NOKOLT").Visible = True

        End With

    End Sub

    Private Sub GrillaPC_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Kolt As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOLT").Value

        Consulta_sql = "Select Top 1 * From TABPP Where KOLT = '" & _Kolt & "'"
        Dim _RowLista As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If ModoSeleccion Then
            ListaSeleccionada = True
            RowListaSeleccionada = _RowLista
            Me.Close()
        End If

        Dim Fm As New Frm_MantListas_Crear(Frm_MantListas_Crear.Accion.Editar, _RowLista)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub GrillaPC_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

End Class
