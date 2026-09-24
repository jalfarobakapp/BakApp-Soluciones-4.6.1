Public Class Frm_Ferias

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Dim IsMantencion As Boolean
    Public Property ModoSeleccion As Boolean

    Public Sub New(Optional Mantencion As Boolean = False)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.IsMantencion = Mantencion


        If IsMantencion Then

            BarEdit.Visible = True
            Btn_Agregar.Visible = True
            Btn_CambiarEstado.Visible = True
            Btn_Eliminar.Visible = True
            Btn_Editar.Visible = True
        Else
            Me.Text = "Selector de feria"
        End If

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(BarEdit)

    End Sub

    Private Sub Frm_Ferias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(BarEdit)
    End Sub

    Sub Sb_Actualizar_Grilla()
        Dim _Condicion As String = "Where Activa = 1"

        If IsMantencion Then
            _Condicion  = String.Empty

        End If

        Consulta_sql = $"
Select * From {_Global_BaseBk}Zw_Ferias
{_Condicion}
"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla
            ' Asignar origen de datos una sola vez
            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            ' --- CONFIGURACIÓN DE COLUMNAS NORMALES ---


            .Columns("NombreFeria").Width = 310
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


            ' --- MANEJO DE LA COLUMNA ACTIVA ---
            ' 1. Ocultar la columna original que tiene el CheckBox
            .Columns("Activa").Visible = False

            ' 2. Crear una columna de texto nueva para mostrar las palabras
            If Not .Columns.Contains("ActivaTexto") Then
                Dim colTexto As New DataGridViewTextBoxColumn()
                colTexto.Name = "ActivaTexto"
                colTexto.HeaderText = "Estado"
                colTexto.ToolTipText = "Estado de la feria"
                colTexto.Width = 70
                colTexto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(colTexto)
            End If

            ' Posicionar nuestra columna nueva
            .Columns("ActivaTexto").DisplayIndex = _DisplayIndex
            .Columns("ActivaTexto").Visible = True
            _DisplayIndex += 1

        End With

        ' 3. Ciclo For Each para dar el texto y pintar las filas
        Dim colorRojo = Color.FromArgb(255, 204, 211)
        Dim colorVerde = Color.FromArgb(185, 248, 207)

        For Each row As DataGridViewRow In Grilla.Rows
            If Not row.IsNewRow Then
                ' Leemos el valor de la columna original (la que ocultamos)
                Dim valorActiva = row.Cells("Activa").Value

                If valorActiva IsNot DBNull.Value Then

                    ' Convertimos a 0 o 1 (por si viene como True/False o como número)
                    Dim numActiva As Integer = 0
                    If TypeOf valorActiva Is Boolean Then
                        numActiva = If(CBool(valorActiva), 1, 0)
                    ElseIf IsNumeric(valorActiva) Then
                        numActiva = Convert.ToInt32(valorActiva)
                    End If

                    ' Asignamos el texto a la columna nueva y pintamos el fondo
                    If numActiva = 0 Then
                        row.Cells("ActivaTexto").Value = "Desactivada"
                        row.DefaultCellStyle.BackColor = colorRojo
                    ElseIf numActiva = 1 Then
                        row.Cells("ActivaTexto").Value = "Activada"
                        row.DefaultCellStyle.BackColor = colorVerde
                    End If

                End If
            End If
        Next
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

    End Sub


    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click
        Dim frm As New Frm_MantFeria()
        frm.ShowDialog(Me)
        Sb_Actualizar_Grilla()

    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick

    End Sub

    Private Sub Grilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentDoubleClick
        If IsMantencion Then

            If e.RowIndex < 0 Then Return

            Dim fila As DataGridViewRow = Grilla.Rows(e.RowIndex)

            Dim miFeria As New Zw_Feria()
            miFeria.Id = Convert.ToInt32(fila.Cells("Id").Value)
            miFeria.NombreFeria = fila.Cells("NombreFeria").Value.ToString()
            miFeria.FechaInicio = Convert.ToDateTime(fila.Cells("FechaInicio").Value)
            miFeria.FechaTermino = Convert.ToDateTime(fila.Cells("FechaTermino").Value)
            miFeria.Activa = Convert.ToBoolean(fila.Cells("Activa").Value)
            Dim celdaFecha As Object = fila.Cells("FechaFeria").Value

            miFeria.FechaFeria = If(IsDBNull(celdaFecha) OrElse celdaFecha Is Nothing, Date.Today, Convert.ToDateTime(celdaFecha))

            Dim frm As New Frm_MantFeria(miFeria)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                Sb_Actualizar_Grilla()

            End If
        End If
    End Sub

    Private Sub Btn_Grabar(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        If Grilla.CurrentRow Is Nothing Then
            MessageBox.Show("Debe seleccionar una feria de la lista para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_CambiarEstado.Click
        ' 1. Validar que exista una fila seleccionada
        If Grilla.CurrentRow Is Nothing Then
            MessageBox.Show("Debe seleccionar una feria de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show($"No es posible activar la feria '{nombreFeria}' porque su fecha de término ({fechaHasta.ToString("dd/MM/yyyy")}) ya ha pasado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 3. Mostrar Advertencia
        Dim mensaje As String = $"¿Está seguro que desea {textoAccion.ToUpper()} la feria '{nombreFeria}'?"
        If MessageBox.Show(mensaje, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                ' 4. Ejecutar el UPDATE
                Dim query As String = $"UPDATE {_Global_BaseBk}[Zw_Ferias] SET [Activa] = {nuevoEstado} WHERE [Id] = {idFeria}"

                If Not _Sql.Ej_consulta_IDU(query) Then
                    Throw New System.Exception("Error al cambiar el estado de la feria." & vbCrLf & _Sql.Pro_Error)
                End If

                MessageBox.Show($"La feria se ha {textoAccion.ToLower()}do correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Sb_Actualizar_Grilla()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        If Grilla.CurrentRow Is Nothing Then
            MessageBox.Show("Debe seleccionar una feria de la lista para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Capturar datos de la fila
        Dim fila As DataGridViewRow = Grilla.CurrentRow
        Dim idFeria As Integer = Convert.ToInt32(fila.Cells("Id").Value)
        Dim nombreFeria As String = fila.Cells("NombreFeria").Value.ToString()

        ' 3. Mostrar Advertencia Crítica
        Dim mensaje As String = $"¿Está COMPLETAMENTE SEGURO que desea ELIMINAR la feria '{nombreFeria}'?" & vbCrLf & "Esta acción no se puede deshacer."
        If MessageBox.Show(mensaje, "Advertencia de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            Try
                ' 1. Validar si existen documentos
                Dim sqlCheck As String = $"SELECT TOP 1 1 FROM {_Global_BaseBk}[Zw_Docu_Ent] WHERE [Id_Feria] = {idFeria}"
                Dim dt As DataTable = _Sql.Fx_Get_DataTable(sqlCheck) ' Reemplaza con tu método para leer datos

                If dt.Rows.Count > 0 Then
                    ' Si hay datos, detenemos el proceso y avisamos
                    MessageBox.Show("No se puede eliminar la feria porque ya tiene documentos asociados.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return ' Salimos del sub/función
                End If
                ' 4. Ejecutar el DELETE
                Dim query As String = $"DELETE FROM {_Global_BaseBk}[Zw_Ferias] 
                        WHERE [Id] = {idFeria} 
                        AND NOT EXISTS (
                            SELECT 1 
                            FROM {_Global_BaseBk}[Zw_Docu_Ent] 
                            WHERE [Id_Feria] = {idFeria}
                        )"

                If Not _Sql.Ej_consulta_IDU(query) Then
                    MessageBox.Show("No se pudo eliminar la feria. Es posible que ya tenga documentos asociados.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Feria eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Sb_Actualizar_Grilla() ' Refrescar la grilla
                End If
                MessageBox.Show("La feria ha sido eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 5. AQUÍ: Llama a tu función para recargar la grilla para que la fila desaparezca
                Sb_Actualizar_Grilla()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
End Class
