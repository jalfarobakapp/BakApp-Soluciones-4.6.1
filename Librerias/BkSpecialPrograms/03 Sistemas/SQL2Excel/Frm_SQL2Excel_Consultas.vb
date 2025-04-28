'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_SQL2Excel_Consultas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Private _dv As New DataView

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Crear_Nueva_Consulta.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_SQL2Excel_Consultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Me.ActiveControl = Txt_Buscar_Consulta_SQL

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "SELECT *, Case When Consulta_Personal = 1 Then 'Personal' Else 'Global' End As Tipo_Consulta" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_SQL_Querys" & Space(1) &
                       "WHERE Funcionario = '" & FUNCIONARIO & "' Or Consulta_Global = 1" & vbCrLf &
                       "Order by Nombre_Query"

        Dim _Ds As New DataSet
        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _dv.Table = _Ds.Tables(0)

        With Grilla

            Grilla.DataSource = _dv

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Nombre_Query").HeaderText = "Nombre Consulta"
            .Columns("Nombre_Query").Visible = True
            .Columns("Nombre_Query").Width = 770
            .Columns("Nombre_Query").DisplayIndex = 0

            .Columns("Tipo_Consulta").HeaderText = "Tipo consulta"
            .Columns("Tipo_Consulta").Visible = True
            .Columns("Tipo_Consulta").Width = 100
            .Columns("Tipo_Consulta").DisplayIndex = 1

            For Each _Fila As DataGridViewRow In .Rows

                If Global_Thema = Enum_Themas.Oscuro Then
                    If _Fila.Cells("Consulta_Global").Value Then
                        _Fila.DefaultCellStyle.ForeColor = Color.PaleGoldenrod
                    Else
                        _Fila.DefaultCellStyle.ForeColor = Color.White
                    End If
                Else
                    If _Fila.Cells("Consulta_Global").Value Then
                        _Fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.White
                    End If
                End If

            Next

        End With

    End Sub

    Private Sub Txt_Buscar_Consulta_SQL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar_Consulta_SQL.TextChanged

        _dv.RowFilter = String.Format("Nombre_Query Like '%{0}%'", Txt_Buscar_Consulta_SQL.Text)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If Global_Thema = Enum_Themas.Oscuro Then
                If _Fila.Cells("Consulta_Global").Value Then
                    _Fila.DefaultCellStyle.ForeColor = Color.PaleGoldenrod
                Else
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                End If
            Else
                If _Fila.Cells("Consulta_Global").Value Then
                    _Fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Call Btn_Editar_Consulta_Sql_Click(Nothing, Nothing)

    End Sub

    Private Sub Btn_Crear_Nueva_Consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Nueva_Consulta.Click

        Dim Fm As New Frm_SQL2Excel_Diseno(0)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Frm_SQL2Excel_Consultas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Eliminar_Consulta_Sql_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_Consulta_Sql.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Consulta_Global = _Fila.Cells("Consulta_Global").Value

        If _Consulta_Global Then
            If Not Fx_Tiene_Permiso(Me, "Sql00003") Then
                Return
            End If
        End If

        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar esta consulta?", "Eliminar consulta",
                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim Cl_SQL2Query As New Cl_SQL2Query

            Cl_SQL2Query.Fx_Llenar_Zw_SQL_Querys(_Id)

            Dim _Mensaje As LsValiciones.Mensajes = Cl_SQL2Query.Fx_Eliminar_SqlQuery()

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

            If Not _Mensaje.EsCorrecto Then
                Return
            End If

            Grilla.Rows.RemoveAt(_Fila.Index)

        End If

    End Sub

    Private Sub Btn_Editar_Consulta_Sql_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Consulta_Sql.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Funcionario = _Fila.Cells("FUNCIONARIO").Value
        Dim _Consulta_Global = _Fila.Cells("Consulta_Global").Value

        Dim _Ver_Consulta As Boolean = True

        If _Consulta_Global Then
            _Ver_Consulta = Fx_Tiene_Permiso(Me, "Sql00002")
        End If

        If _Ver_Consulta Then
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_SQL_Querys Where Id = " & _Id
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_Row Is Nothing) Then
                Dim Fm As New Frm_SQL2Excel_Diseno(_Id)
                Fm.ShowDialog(Me)
                If Fm.Grabar Then
                    Sb_Actualizar_Grilla()
                End If
                Fm.Dispose()
            End If
        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Txt_Nota.Text = _Fila.Cells("Nota").Value
    End Sub
End Class
