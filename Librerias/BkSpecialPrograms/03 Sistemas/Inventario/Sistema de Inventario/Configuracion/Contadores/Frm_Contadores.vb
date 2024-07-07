Imports DevComponents.DotNetBar

Public Class Frm_Contadores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Contadores As DataTable
    Dim _Dv As New DataView

    Public Property ModoSeleccion As Boolean
    Public Property Seleccionado As Boolean
    Public Property Cl_Contador As New Cl_Contador

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Sb_Frm_Contadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Chk_Ver_Solo_Habilitados.CheckedChanged, AddressOf Chk_Ver_Solo_Habilitados_CheckedChanged
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        If Not ModoSeleccion Then AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

        Btn_CrearContador.Visible = Not ModoSeleccion
        Chk_Ver_Solo_Habilitados.Enabled = Not ModoSeleccion

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        If Chk_Ver_Solo_Habilitados.Checked Then
            _Condicion = "Where Activo = 1"
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Contador" & vbCrLf & _Condicion

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_Contadores = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            '.Columns("Id").Visible = True
            '.Columns("Id").HeaderText = "Id"
            '.Columns("Id").Width = 40
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Rut").Visible = True
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Width = 80
            .Columns("Rut").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre").Visible = True
            .Columns("Nombre").HeaderText = "Nombre"
            .Columns("Nombre").Width = 200
            .Columns("Nombre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Telefono").Visible = True
            .Columns("Telefono").HeaderText = "Nombre"
            .Columns("Telefono").Width = 90
            .Columns("Telefono").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Email").Visible = True
            .Columns("Email").HeaderText = "Email"
            .Columns("Email").Width = 160
            .Columns("Email").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Activo").Visible = True
            .Columns("Activo").HeaderText = "Act."
            .Columns("Activo").Width = 40
            .Columns("Activo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Operador_Click(sender As Object, e As EventArgs) Handles Btn_CrearContador.Click

        Dim _Grabar As Boolean = False

        Dim Fm As New Frm_CrearContador(0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If ModoSeleccion Then

            Cl_Contador.Fx_Llenar_Zw_Inv_Contador(_Id)
            Seleccionado = True
            Me.Close()
            Return

        End If

        Call Btn_EditarContador_Click(Nothing, Nothing)

    End Sub

    Private Sub Btn_EditarContador_Click(sender As Object, e As EventArgs) Handles Btn_EditarContador.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _Grabar As Boolean = False
        Dim _Eliminado As Boolean = False

        Dim Cl_Contador As New Cl_Contador

        Dim Fm As New Frm_CrearContador(_Id)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Eliminado = Fm.Eliminado
        Cl_Contador = Fm.Cl_Contador
        Fm.Dispose()

        If _Grabar Then
            _Fila.Cells("Rut").Value = Cl_Contador.Zw_Inv_Contador.Rut
            _Fila.Cells("Nombre").Value = Cl_Contador.Zw_Inv_Contador.Nombre
            _Fila.Cells("Telefono").Value = Cl_Contador.Zw_Inv_Contador.Telefono
            _Fila.Cells("Email").Value = Cl_Contador.Zw_Inv_Contador.Email
            _Fila.Cells("Activo").Value = Cl_Contador.Zw_Inv_Contador.Activo
        End If

        If _Eliminado Then
            Grilla.Rows.Remove(_Fila)
        End If

    End Sub

    Private Sub Btn_EliminarContador_Click(sender As Object, e As EventArgs) Handles Btn_EliminarContador.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar este contador?", "Eliminar contador",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim Cl_Contador As New Cl_Contador
        Cl_Contador.Fx_Llenar_Zw_Inv_Contador(_Id)
        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Cl_Contador.Fx_Eliminar_Contador(Cl_Contador.Zw_Inv_Contador)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Grilla.Rows.Remove(_Fila)

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Txt_Filtrar.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            If Chk_Ver_Solo_Habilitados.Checked Then
                _Dv.RowFilter = String.Format("Rut+Nombre Like '%{0}%' And Activo = 1", Txt_Filtrar.Text.Trim)
            Else
                _Dv.RowFilter = String.Format("Rut+Nombre Like '%{0}%'", Txt_Filtrar.Text.Trim)
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If Txt_Filtrar.Text.Trim.Length > 0 Then
            If e.KeyCode = Keys.Enter Then
                Sb_Filtrar()
            End If
        End If
    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If Txt_Filtrar.Text.Trim.Length = 0 Then
            _Dv.RowFilter = String.Empty
        End If
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        Txt_Filtrar.Text = String.Empty
        _Dv.RowFilter = String.Empty
    End Sub

    Sub Sb_Grilla_MouseDown(sender As Object, e As MouseEventArgs)

        If e.Button = MouseButtons.Right Then

            Dim _Hti As DataGridView.HitTestInfo = Grilla.HitTest(e.X, e.Y)

            If _Hti.RowIndex >= 0 Then

                Grilla.Rows(_Hti.RowIndex).Selected = True

                ShowContextMenu(Menu_Contextual_Contadores)

            End If

        End If

    End Sub

    Private Sub Chk_Ver_Solo_Habilitados_CheckedChanged(sender As Object, e As EventArgs)
        Txt_Filtrar.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_Contadores_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
