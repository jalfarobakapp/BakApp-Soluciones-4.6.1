Imports DevComponents.DotNetBar

Public Class Frm_Ferias

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property ModoSeleccion As Boolean
    Public Property Zw_Feria As New Zw_Feria
    Public Property Row_Feria As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(BarEdit)

    End Sub

    Private Sub Frm_Ferias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Configurar_Modo()
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        If ModoSeleccion Then
            _Condicion = "Where Activa = 1"
        End If

        Consulta_sql = $"
Select * From {_Global_BaseBk}Zw_Ferias
{_Condicion}
"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla
            .DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("NombreFeria").Width = 350
            .Columns("NombreFeria").HeaderText = "Nombre"
            .Columns("NombreFeria").ToolTipText = "Nombre de la feria"
            .Columns("NombreFeria").Visible = True
            .Columns("NombreFeria").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaFeria").Width = 70
            .Columns("FechaFeria").HeaderText = "Fecha Feria"
            .Columns("FechaFeria").ToolTipText = "Fecha de la feria"
            .Columns("FechaFeria").Visible = True
            .Columns("FechaFeria").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaInicio").HeaderText = "F.Inicio"
            .Columns("FechaInicio").ToolTipText = "Fecha de inicio de las ventas por feria"
            .Columns("FechaInicio").Width = 70
            .Columns("FechaInicio").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaInicio").Visible = True
            .Columns("FechaInicio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaTermino").HeaderText = "F.Termino"
            .Columns("FechaTermino").ToolTipText = "Fecha de termino para las ventas de la feria"
            .Columns("FechaTermino").Width = 70
            .Columns("FechaTermino").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaTermino").Visible = True
            .Columns("FechaTermino").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Activa").Visible = False

            If Not .Columns.Contains("ActivaTexto") Then
                Dim colTexto As New DataGridViewTextBoxColumn()
                colTexto.Name = "ActivaTexto"
                colTexto.HeaderText = "Estado"
                colTexto.ToolTipText = "Estado de la feria"
                colTexto.Width = 70
                colTexto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(colTexto)
            End If

            .Columns("ActivaTexto").DisplayIndex = _DisplayIndex
            .Columns("ActivaTexto").Visible = True
            _DisplayIndex += 1

        End With

        For Each row As DataGridViewRow In Grilla.Rows
            If Not row.IsNewRow Then

                Dim valorActiva = row.Cells("Activa").Value

                If valorActiva IsNot DBNull.Value Then

                    Dim numActiva As Integer = 0

                    If TypeOf valorActiva Is Boolean Then
                        numActiva = If(CBool(valorActiva), 1, 0)
                    ElseIf IsNumeric(valorActiva) Then
                        numActiva = Convert.ToInt32(valorActiva)
                    End If

                    If numActiva = 0 Then
                        row.Cells("ActivaTexto").Value = "Desactivada"
                        row.Cells("ActivaTexto").Style.ForeColor = Rojo
                        row.Cells("ActivaTexto").Style.SelectionForeColor = Rojo
                    ElseIf numActiva = 1 Then
                        row.Cells("ActivaTexto").Value = "Activada"
                        row.Cells("ActivaTexto").Style.ForeColor = Verde
                        row.Cells("ActivaTexto").Style.SelectionForeColor = Verde
                    End If

                End If
            End If
        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If Not ModoSeleccion Then
            Call Btn_Editar_Click(Nothing, Nothing)
            Return
        End If

        If e.RowIndex < 0 Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)

        If _Fila Is Nothing OrElse _Fila.DataBoundItem Is Nothing Then
            Row_Feria = Nothing
            Return
        End If

        Row_Feria = CType(_Fila.DataBoundItem, DataRowView).Row
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    'Private Sub Grilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentDoubleClick
    '    If Not ModoSeleccion Then

    '        If e.RowIndex < 0 Then Return

    '        Dim fila As DataGridViewRow = Grilla.Rows(e.RowIndex)

    '        _Zw_Feria = New Zw_Feria()

    '        _Zw_Feria.Id = Convert.ToInt32(fila.Cells("Id").Value)
    '        _Zw_Feria.NombreFeria = fila.Cells("NombreFeria").Value.ToString()
    '        _Zw_Feria.FechaInicio = Convert.ToDateTime(fila.Cells("FechaInicio").Value)
    '        _Zw_Feria.FechaTermino = Convert.ToDateTime(fila.Cells("FechaTermino").Value)
    '        _Zw_Feria.Activa = Convert.ToBoolean(fila.Cells("Activa").Value)
    '        Dim celdaFecha As Object = fila.Cells("FechaFeria").Value

    '        _Zw_Feria.FechaFeria = If(IsDBNull(celdaFecha) OrElse celdaFecha Is Nothing, Date.Today, Convert.ToDateTime(celdaFecha))

    '        Dim frm As New Frm_MantFeria(_Zw_Feria)
    '        If frm.ShowDialog(Me) = DialogResult.OK Then
    '            Sb_Actualizar_Grilla()
    '        End If
    '    End If
    'End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "Feria0004") Then
            Return
        End If

        If Grilla.CurrentRow Is Nothing Then
            MessageBoxEx.Show("Debe seleccionar una feria de la lista para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Capturar datos de la fila
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Feria As Integer = Convert.ToInt32(_Fila.Cells("Id").Value)
        Dim _NombreFeria As String = _Fila.Cells("NombreFeria").Value.ToString()

        ' 1. Validar si existen documentos
        Consulta_sql = $"SELECT TOP 1 1 FROM {_Global_BaseBk}[Zw_Docu_Ent] WHERE [Id_Feria] = {_Id_Feria}"
        Dim dt As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) ' Reemplaza con tu método para leer datos

        If dt.Rows.Count > 0 Then
            ' Si hay datos, detenemos el proceso y avisamos
            MessageBoxEx.Show("No se puede eliminar la feria porque ya tiene documentos asociados.", "Acción denegada",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return ' Salimos del sub/función
        End If

        ' 3. Mostrar Advertencia Crítica
        Dim _Msj As String = $"¿Está COMPLETAMENTE SEGURO que desea ELIMINAR la feria '{_NombreFeria}'?" & vbCrLf & "Esta acción no se puede deshacer."
        If MessageBoxEx.Show(_Msj, "Advertencia de Eliminación", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            Try

                ' 4. Ejecutar el DELETE
                Consulta_sql = $"DELETE FROM {_Global_BaseBk}[Zw_Ferias] 
                        WHERE [Id] = {_Id_Feria} 
                        AND NOT EXISTS (
                            SELECT 1 
                            FROM {_Global_BaseBk}[Zw_Docu_Ent] 
                            WHERE [Id_Feria] = {_Id_Feria}
                        )"

                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    MessageBoxEx.Show("No se pudo eliminar la feria. Es posible que ya tenga documentos asociados.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBoxEx.Show("Feria eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Sb_Actualizar_Grilla() ' Refrescar la grilla
                End If
                MessageBoxEx.Show("La feria ha sido eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 5. AQUÍ: Llama a tu función para recargar la grilla para que la fila desaparezca
                Sb_Actualizar_Grilla()

            Catch ex As Exception
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub Sb_Configurar_Modo()

        Dim _EsMantencion As Boolean = Not ModoSeleccion

        BarEdit.Visible = _EsMantencion
        Btn_Agregar.Visible = _EsMantencion
        Btn_CambiarEstado.Visible = _EsMantencion
        Btn_Eliminar.Visible = _EsMantencion
        Btn_Editar.Visible = _EsMantencion

        If ModoSeleccion Then
            Me.Text = "Selector de feria"
        Else
            Me.Text = "Mantención de ferias"
        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        If Not Fx_Tiene_Permiso(Me, "Feria0003") Then
            Return
        End If

        If Grilla.CurrentRow Is Nothing Then
            MessageBoxEx.Show("Debe seleccionar una feria de la lista para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Capturar la fila actual
        Dim fila As DataGridViewRow = Grilla.CurrentRow

        ' 3. Llenar el objeto
        Dim miFeria As New Zw_Feria()
        miFeria.Id = Convert.ToInt32(fila.Cells("Id").Value)
        miFeria.NombreFeria = fila.Cells("NombreFeria").Value.ToString()
        miFeria.FechaInicio = Convert.ToDateTime(fila.Cells("FechaInicio").Value)
        miFeria.FechaTermino = Convert.ToDateTime(fila.Cells("FechaTermino").Value)
        miFeria.Activa = Convert.ToBoolean(fila.Cells("Activa").Value)
        miFeria.FechaFeria = Convert.ToDateTime(fila.Cells("FechaFeria").Value)

        ' 4. Abrir el formulario y actualizar la grilla si se guardó
        Dim frm As New Frm_MantFeria(miFeria)
        If frm.ShowDialog(Me) = DialogResult.OK Then
            ' Aquí debes llamar a tu función que carga la grilla para refrescar los datos
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click

        If Not Fx_Tiene_Permiso(Me, "Feria0002") Then
            Return
        End If

        Dim frm As New Frm_MantFeria()
        frm.ShowDialog(Me)
        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_CambiarEstado_Click(sender As Object, e As EventArgs) Handles Btn_CambiarEstado.Click

        If Not Fx_Tiene_Permiso(Me, "Feria0005") Then
            Return
        End If

        ' 1. Validar que exista una fila seleccionada
        If Grilla.CurrentRow Is Nothing Then
            MessageBoxEx.Show("Debe seleccionar una feria de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Capturar datos de la fila
        Dim fila As DataGridViewRow = Grilla.CurrentRow
        Dim idFeria As Integer = Convert.ToInt32(fila.Cells("Id").Value)
        Dim nombreFeria As String = fila.Cells("NombreFeria").Value.ToString()
        Dim estadoActual As Boolean = Convert.ToBoolean(fila.Cells("Activa").Value)

        ' --- NUEVO: Capturar la fecha de término ---
        ' NOTA: Asegúrate de que el nombre de la columna en la grilla coincida (puede ser "FechaHasta" o "FechaTermino")
        Dim fechaHasta As DateTime = Convert.ToDateTime(fila.Cells("FechaTermino").Value)

        ' Determinar la acción a realizar
        Dim nuevoEstado As Integer = If(estadoActual, 0, 1)
        Dim textoAccion As String = If(estadoActual, "Desactivar", "Activar")

        ' --- NUEVO: Validar si se puede activar ---
        ' Si se quiere ACTIVAR (nuevoEstado = 1) y la FechaHasta es menor a la fecha actual (Date.Today)
        If nuevoEstado = 1 AndAlso fechaHasta.Date < Date.Today Then
            MessageBoxEx.Show($"No es posible activar la feria '{nombreFeria}' porque su fecha de término ({fechaHasta.ToString("dd/MM/yyyy")}) ya ha pasado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 3. Mostrar Advertencia
        Dim mensaje As String = $"¿Está seguro que desea {textoAccion.ToUpper()} la feria '{nombreFeria}'?"
        If MessageBoxEx.Show(mensaje, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                ' 4. Ejecutar el UPDATE
                Dim query As String = $"UPDATE {_Global_BaseBk}[Zw_Ferias] SET [Activa] = {nuevoEstado} WHERE [Id] = {idFeria}"

                If Not _Sql.Ej_consulta_IDU(query) Then
                    Throw New System.Exception("Error al cambiar el estado de la feria." & vbCrLf & _Sql.Pro_Error)
                End If

                MessageBoxEx.Show($"La feria se ha {textoAccion.ToLower()}do correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Sb_Actualizar_Grilla()

            Catch ex As Exception
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

End Class
