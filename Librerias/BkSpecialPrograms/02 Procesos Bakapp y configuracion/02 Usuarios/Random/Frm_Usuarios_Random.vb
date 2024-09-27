Imports DevComponents.DotNetBar

Public Class Frm_Usuarios_Random

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Usuarios As DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar1)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Usuarios_Random_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Cadena As String = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "KOFU+NOKOFU LIKE '%")

        Consulta_sql = "Select *,Cast('' As Varchar(5)) As ClaveDC,CAST(0 As Int) As Modalidades" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Where KOFU+NOKOFU LIKE '%" & _Cadena & "%'" & vbCrLf &
                       "Order By KOFU" & vbCrLf &
                       vbCrLf &
                       "Select Ce.EMPRESA,Cp.RAZON,'MO-' + MODALIDAD As PERMISO,MODALIDAD" & vbCrLf &
                       "Into #Paso1" & vbCrLf &
                       "From CONFIEST Ce" & vbCrLf &
                       "Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA " & vbCrLf &
                       "Left Join TABSU Ts On Ts.EMPRESA = Ce.EMPRESA And Ts.KOSU = Ce.ESUCURSAL" & vbCrLf &
                       "Left Join TABBO Tb On Tb.EMPRESA = Ce.EMPRESA And Tb.KOSU = Ce.ESUCURSAL And Tb.KOBO = Ce.EBODEGA" & vbCrLf &
                       "Where MODALIDAD <> '  '" & vbCrLf &
                       "Order by Ce.EMPRESA,MODALIDAD" & vbCrLf &
                       vbCrLf &
                       "Update #Paso Set Modalidades = (Select COUNT(*) From MAEUS Where KOOP In (Select PERMISO From #Paso1) And KOUS = #Paso.KOFU)" & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       vbCrLf &
                       "Drop Table #Paso" & vbCrLf &
                       "Drop Table #Paso1"

        _Tbl_Usuarios = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Usuarios

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("KOFU").Width = 60
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").Visible = True
            .Columns("KOFU").Frozen = True
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Width = 300
            .Columns("NOKOFU").HeaderText = "Nombre funcionario"
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").Frozen = True
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("INACTIVO").Width = 50
            .Columns("INACTIVO").HeaderText = "Inactivo"
            .Columns("INACTIVO").Visible = True
            .Columns("INACTIVO").Frozen = True
            .Columns("INACTIVO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ClaveDC").Width = 70
            .Columns("ClaveDC").HeaderText = "Clave"
            .Columns("ClaveDC").Visible = True
            .Columns("ClaveDC").Frozen = True
            .Columns("ClaveDC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Modalidades").Width = 80
            .Columns("Modalidades").HeaderText = "Modalidades"
            .Columns("Modalidades").ToolTipText = "Modalidades asignadas"
            .Columns("Modalidades").Visible = True
            .Columns("Modalidades").Frozen = True
            .Columns("Modalidades").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            _Fila.Cells("ClaveDC").Value = DecryptClaveRD(NuloPorNro(_Fila.Cells("PWFU").Value, ""))

            If _Fila.Cells("INACTIVO").Value Then
                _Fila.DefaultCellStyle.ForeColor = Color.Gray
            End If

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

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Grabar As Boolean

        Dim Frm As New Frm_Usuarios_Random_Ficha(_Kofu)
        Frm.ShowDialog()
        _Grabar = Frm.Grabar
        Frm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
            BuscarDatoEnGrilla(_Kofu, "KOFU", Grilla)
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Crear_Click(sender As Object, e As EventArgs) Handles Btn_Crear.Click

        Dim _Grabar As Boolean
        Dim _Kofu As String

        Dim Fm As New Frm_Usuarios_Random_Ficha("")
        Fm.ShowDialog()
        _Kofu = Fm.Kofu
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Txt_Descripcion.Text = String.Empty
            BuscarDatoEnGrilla(_Kofu, "KOFU", Grilla)
            MessageBoxEx.Show(Me, "Funcionario creado correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Usuarios, Me, "Usuarios")
    End Sub
End Class
