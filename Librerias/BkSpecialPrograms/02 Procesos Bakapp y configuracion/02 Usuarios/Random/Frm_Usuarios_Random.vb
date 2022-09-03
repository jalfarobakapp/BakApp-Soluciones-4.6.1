Imports DevComponents.DotNetBar

Public Class Frm_Usuarios_Random

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Usuarios_Random_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Cadena As String = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "KOFU+NOKOFU LIKE '%")

        Consulta_sql = "Select *,Cast('' As Varchar(5)) As ClaveDC From TABFU" & vbCrLf &
                       "Where KOFU+NOKOFU LIKE '%" & _Cadena & "%'" & vbCrLf &
                       "Order By KOFU"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("KOFU").Width = 80
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").Visible = True
            .Columns("KOFU").Frozen = True
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Width = 400
            .Columns("NOKOFU").HeaderText = "Nombre funcionario"
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").Frozen = True
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ClaveDC").Width = 80
            .Columns("ClaveDC").HeaderText = "Clave"
            .Columns("ClaveDC").Visible = True
            .Columns("ClaveDC").Frozen = True
            .Columns("ClaveDC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1
        End With

        For Each Fila As DataRow In _Tbl.Rows
            Fila.Item("ClaveDC") = DecryptClaveRD(NuloPorNro(Fila.Item("PWFU"), ""))
        Next

    End Sub

    Private Sub Frm_Usuarios_Random_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Config_Impresora_Diablito_Click(sender As Object, e As EventArgs) Handles Btn_Config_Impresora_Diablito.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _CodFuncionario = _Fila.Cells("KOFU").Value

        If Fx_Tiene_Permiso(Me, "Doc00057") Then

            Dim Fm As New Frm_Imp_Diablito_X_Est(_CodFuncionario, True)
            'Fm.Modalidad = Modalidad
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        ShowContextMenu(Menu_Contextual_01)
    End Sub
    Private Sub Grilla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellClick
        Btn_Editar.Visible = True
        Me.Refresh()
    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Crear_Click(sender As Object, e As EventArgs) Handles Btn_Crear.Click

        Dim Fm As New Frm_Usuarios_Random_Ficha(Frm_Usuarios_Random_Ficha.Enum_Accion.Crear, "")
        Fm.ShowDialog()
        Fm.Dispose()

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Grabar As Boolean

        Dim Frm As New Frm_Usuarios_Random_Ficha(Frm_Usuarios_Random_Ficha.Enum_Accion.Editar, _Kofu)
        Frm.ShowDialog()
        _Grabar = Frm.Grabar
        Frm.Dispose()

        If _Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sb_Actualizar_Grilla()
        End If

    End Sub


End Class
