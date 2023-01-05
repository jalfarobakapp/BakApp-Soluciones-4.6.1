Imports DevComponents.DotNetBar

Public Class Frm_FincredTokens

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Dim _RowToken As DataRow
    Dim _Tbl_Tokens As DataTable
    Public Property Seleccionar As Boolean

    Public Property RowToken As DataRow
        Get
            Return _RowToken
        End Get
        Set(value As DataRow)
            _RowToken = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub
    Private Sub Frm_FincredTokens_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        If Not Seleccionar Then
            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        End If

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Agregar.Enabled = Not Seleccionar

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Id,Token,Usuario,Clave,NombreSucursal,AmbientePruebas From " & _Global_BaseBk & "Zw_Fincred_Config"
        _Tbl_Tokens = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_Tokens

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Id").Visible = True
            .Columns("Id").HeaderText = "ID"
            .Columns("Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Id").Width = 30
            .Columns("Id").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Token").Visible = True
            .Columns("Token").HeaderText = "PG"
            .Columns("Token").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Token").Width = 250
            .Columns("Token").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreSucursal").Visible = True
            .Columns("NombreSucursal").HeaderText = "Nom. Sucursal"
            .Columns("NombreSucursal").Width = 150
            .Columns("NombreSucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("AmbientePruebas").Visible = True
            .Columns("AmbientePruebas").HeaderText = "A.P."
            .Columns("AmbientePruebas").ToolTipText = "¿Es Ambiente de pruebas?"
            .Columns("AmbientePruebas").Width = 30
            .Columns("AmbientePruebas").DisplayIndex = _DisplayIndex


        End With

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_03)

                End If
            End With
        End If
    End Sub

    Private Sub Frm_Conceptos_ObliXDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Fincred(0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Fincred_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Fincred_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _RowToken As DataRow

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Fincred(_Id)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _RowToken = Fm.RowToken
        Fm.Dispose()

        If _Grabar Then
            _Fila.Cells("NombreSucursal").Value = _RowToken.Item("NombreSucursal")
            _Fila.Cells("AmbientePruebas").Value = _RowToken.Item("AmbientePruebas")
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If Seleccionar Then
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Fincred_Config Where Id = " & _Id
            _RowToken = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Fincred_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Fincred_Eliminar.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id = _Fila.Cells("Id").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Configuracion", "Fincred_Id_Token = " & _Id)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No es posible eliminar este Token, ya que hay modalidades asociadas a el." & vbCrLf &
                              "Para eliminarlo debe quitar el Token de todas las modalidades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación del Token?", "Eliminar cuenta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Fincred_Config Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            End If

        End If

    End Sub
End Class
