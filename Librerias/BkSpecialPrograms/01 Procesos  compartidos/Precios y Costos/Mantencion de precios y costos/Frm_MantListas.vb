'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_MantListas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblListas As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_ListaPreGlobal " &
                       "(Tipo,Permiso,Lista,Nombre_Lista,ListaCostoxDefecto,TipoValor,ValoresNetos)" & vbCrLf &
                       "Select TILT,'Lp-'+KOLT,KOLT,NOKOLT,'02C' as ListaCostoxDefecto,MELT," &
                       "Case MELT When 'N' Then 1 Else 0 End As ValoresNetos" & vbCrLf &
                       "From TABPP Where KOLT Not In (Select Lista From " & _Global_BaseBk & "Zw_ListaPreGlobal)"

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnCrearLista.ForeColor = Color.White
            Btn_MantFxGlobal.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_MantListas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Sb_Llenar_Grilla()
    End Sub

    Sub Sb_Llenar_Grilla()

        'Consulta_sql = "SELECT Tipo,Permiso,Lista,Nombre_Lista,FormulaPrecio,FormulaPrecio2," & _
        '               "Ej_Fx_documento,Ej_Fx_documento2,Redondear,FormulaGrabarRD,ListaCostoxDefecto," & _
        '               "TipoValor,ValoresNetos,Margen_Ud1, Margen_Ud2, DsctoMax" & vbCrLf & _
        '               "FROM " & _Global_BaseBk & "Zw_ListaPreGlobal"

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


    'Sub Sb_Mantencion_Fx_Actualizar_Random()

    'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
    'Dim _Formula As String = _Fila.Cells("FormulaGrabarRD").Value
    'Dim _Lista As String = _Fila.Cells("Lista").Value

    'If Fx_Tiene_Permiso(Me, "Pre0010") Then

    'Dim Fm As New Frm_PreciosLCEditorFormulas(_Formula)

    'Fm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
    'Fm.ShowInTaskbar = False
    'Fm.ShowDialog(Me)

    'If Fm._Grabar Then
    '_Formula = Replace(LTrim(RTrim(Fm.TxtFormulaFx.Text)), "'", "''")

    'Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreGlobal Set FormulaGrabarRD = '" & _Formula & "'" & vbCrLf & _
    '               "Where Lista = '" & _Lista & "'"
    ' _Sql.Ej_consulta_IDU(Consulta_Sql)

    '_Fila.Cells("FormulaGrabarRD").Value = _Formula
    'End If

    'Fm.Dispose()

    'End If
    'End Sub


    Private Sub GrillaPC_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Kolt As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOLT").Value

        Consulta_sql = "Select Top 1 * From TABPP Where KOLT = '" & _Kolt & "'"
        Dim _RowLista As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_MantListas_Crear(Frm_MantListas_Crear.Accion.Editar, _RowLista)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    Private Sub GrillaPC_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
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
