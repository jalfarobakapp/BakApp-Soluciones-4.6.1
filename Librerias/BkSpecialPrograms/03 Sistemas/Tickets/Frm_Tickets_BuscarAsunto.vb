Imports BkSpecialPrograms.Frm_Tickets_Lista

Public Class Frm_Tickets_BuscarAsunto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Asuntos As DataTable
    Dim _CodFuncionario As String

    Public Property AreaXDefecto As New AreaXDefecto.AreaXDefecto

    Public Sub New(_CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodFuncionario = _CodFuncionario

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Tickets_BuscarAsunto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Def.Id, CodFuncionario, Asunto, Def.Id_Area,Area, Id_Tipo,Tipo, Prioridad," & vbCrLf &
                       "Case Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'UR' Then 'Urgente' Else '??' End As PrioridadStr" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_PorDefecto Def" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Def.Id_Area = Ar.Id" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Stk_Tipos Tp On Def.Id_Tipo = Tp.Id" & vbCrLf &
                       "Where CodFuncionario = '" & _CodFuncionario & "'"

        _Tbl_Asuntos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Asuntos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Nombre de asunto"
            .Columns("Asunto").Width = 200
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Area").Visible = True
            .Columns("Area").HeaderText = "Area"
            .Columns("Area").Width = 150
            .Columns("Area").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 150
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PrioridadStr").Visible = True
            .Columns("PrioridadStr").HeaderText = "Prioridad"
            .Columns("PrioridadStr").Width = 80
            .Columns("PrioridadStr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            With AreaXDefecto

                .Id = _Fila.Cells("Id").Value
                .Asunto = _Fila.Cells("Asunto").Value
                .Id_Area = _Fila.Cells("Id_Area").Value
                .Area = _Fila.Cells("Area").Value
                .Id_Tipo = _Fila.Cells("Id_Tipo").Value
                .Tipo = _Fila.Cells("Tipo").Value
                .Prioridad = _Fila.Cells("Prioridad").Value
                .PrioridadStr = _Fila.Cells("PrioridadStr").Value

            End With

            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_SeleccionarRegistro_Click(sender As Object, e As EventArgs) Handles Btn_SeleccionarRegistro.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub
End Class

Namespace AreaXDefecto
    Public Class AreaXDefecto

        Public Property Id As Integer
        Public Property CodFuncionario As String
        Public Property Asunto As String
        Public Property Id_Area As Integer
        Public Property Area As String
        Public Property Id_Tipo As Integer
        Public Property Tipo As String
        Public Property Prioridad As String
        Public Property PrioridadStr As String

    End Class

End Namespace
