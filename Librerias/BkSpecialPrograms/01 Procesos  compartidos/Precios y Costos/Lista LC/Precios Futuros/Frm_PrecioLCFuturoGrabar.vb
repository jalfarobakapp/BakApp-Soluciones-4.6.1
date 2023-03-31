Imports DevComponents.DotNetBar
Public Class Frm_PrecioLCFuturoGrabar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowProducto As DataRow
    Dim _TblPrecios As DataTable

    Public Property Grabar As Boolean
    Public Property Editar As Boolean
    Public Property Id_Enc As Integer

    Public Sub New(_Codigo As String, _TblPrecios As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me._TblPrecios = _TblPrecios

        Sb_Formato_Generico_Grilla(Grilla_Precios, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_PrecioLCFuturoGrabar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Precios.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Txtcodigo.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim

        Btn_Grabar.Visible = Not Editar
        Dtp_FechaProgramada.Enabled = Not Editar
        Btn_Grabar.Visible = Not Editar
        Btn_EditarFechaProgramacion.Visible = Editar
        Btn_Eliminar_Programa.Visible = Editar

        If Not Editar Then
            Dtp_FechaProgramada.Value = FechaDelServidor()
        End If

        Sb_Actualizar_Datos_Grilla()

        If Editar Then
            If Not CBool(_TblPrecios.Rows.Count) Then
                Chk_Seleccionar_Todo.Enabled = False
                Btn_EditarFechaProgramacion.Visible = False
            End If
        End If

    End Sub

    Private Function Sb_Actualizar_Datos_Grilla()

        Grilla_Precios.DataSource = _TblPrecios

        With Grilla_Precios

            OcultarEncabezadoGrilla(Grilla_Precios, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Lista").Width = 40
            .Columns("Lista").HeaderText = "Lista"
            .Columns("Lista").Visible = True
            .Columns("Lista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreLista").Width = 260
            .Columns("NombreLista").HeaderText = "Descripción lista"
            .Columns("NombreLista").Visible = True
            .Columns("NombreLista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PrecioUd1").Width = 100
            .Columns("PrecioUd1").HeaderText = "Precio Ud1"
            .Columns("PrecioUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioUd1").Visible = True
            .Columns("PrecioUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PrecioUd2").Width = 100
            .Columns("PrecioUd2").HeaderText = "Precio Ud2"
            .Columns("PrecioUd2").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioUd2").Visible = True
            .Columns("PrecioUd2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MargenPorc").Width = 80
            .Columns("MargenPorc").HeaderText = "Margen %"
            .Columns("MargenPorc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("MargenPorc").Visible = True
            .Columns("MargenPorc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Function

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Sb_Grabar_Nueva_Programacion_Futuro()

    End Sub

    Sub Sb_Grabar_Nueva_Programacion_Futuro()

        Dim _FilasSeleccionadas = 0

        For Each _Fila As DataRow In _TblPrecios.Rows
            If _Fila.Item("Chk") Then
                _FilasSeleccionadas += 1
            End If
        Next

        If Not CBool(_FilasSeleccionadas) Then
            MessageBoxEx.Show(Me, "No hay filas seleccionadas" & vbCrLf & vbCrLf &
                              "Debe seleccionar las filas que desea que se graben con precio programado a futuro", "Valdiación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _FechaServidor As Date = FechaDelServidor()

        Dim _FechaProgramada As String = Format(Dtp_FechaProgramada.Value, "yyyyMMdd")
        Dim _FechaHoy As String = Format(_FechaServidor, "yyyyMMdd")


        Dim _FP = Dtp_FechaProgramada.Value.CompareTo(_FechaServidor)
        Dim _FS = _FechaServidor.CompareTo(Dtp_FechaProgramada.Value)
        Dim _FSS = _FechaServidor.CompareTo(_FechaServidor)

        If _FechaHoy = _FechaProgramada Then
            MessageBoxEx.Show(Me, "La fecha de programación no puede ser igual a la fecha de hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _FP <= 0 Then
            MessageBoxEx.Show(Me, "La fecha de programación no puede ser menor a la fecha " & _FechaServidor.ToShortDateString, "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _ReemplazarDatos As Boolean

        Dim _Id_Enc = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaLC_Programadas", "Id",
                                        "Codigo='" & _RowProducto.Item("KOPR") & "' " &
                                        "And FechaProgramada = '" & _FechaProgramada & "' And Eliminada = 0", True)

        If CBool(_Id_Enc) Then
            MessageBoxEx.Show(Me, "Ya hay una lista programada para esta fecha " & Dtp_FechaProgramada.Value.ToShortDateString & vbCrLf & vbCrLf &
                              "Si quiere crear una programación nueva para esta fecha, primero debe eliminar la anterior y grabar una nueva", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma la grabación de la programación para la fecha: " & Dtp_FechaProgramada.Value.ToShortDateString & "?",
                          "Guardar Programado",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Declare @Id_Enc Int" & vbCrLf & vbCrLf &
                "Insert Into " & _Global_BaseBk & "Zw_ListaLC_Programadas
           ([Codigo]
           ,[NombreProgramacion]
           ,[FechaCreacion]
           ,[FechaProgramada]
           ,[Aplicado],[Funcionario],[Activo])
     Values
           ('" & _RowProducto.Item("KOPR") & "'
           ,'" & _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim & " DesdeListaLC'
           ,Getdate()
           ,'" & _FechaProgramada & "'
           ,0,'" & FUNCIONARIO & "','1');" &
           vbCrLf &
           "Set @Id_Enc = (SELECT @@IDENTITY AS Id)" & vbCrLf & vbCrLf &
           "--;DECLARE @Id_Enc AS int;SET @Id_Enc = (SELECT SCOPE_IDENTITY());" & vbCrLf & vbCrLf

            For Each _Fila As DataRow In _TblPrecios.Rows

                Dim _Chk As Boolean = _Fila.Item("Chk")

                If _Chk Then

                    Dim _Lista As String = _Fila.Item("Lista")
                    Dim _NombreLista As String = _Fila.Item("NombreLista")
                    Dim _Codigo As String = _Fila.Item("Codigo")
                    Dim _PrecioUd1 As String = De_Num_a_Tx_01(_Fila.Item("PrecioUd1"), False, 5)
                    Dim _PrecioUd2 As String = De_Num_a_Tx_01(_Fila.Item("PrecioUd2"), False, 5)
                    Dim _EcuacionUd1 As String = _Fila.Item("EcuacionUd1")
                    Dim _EcuacionUd2 As String = _Fila.Item("EcuacionUd2")
                    Dim _Rtu As String = De_Num_a_Tx_01(_Fila.Item("Rtu"), False, 5)
                    Dim _MargenPorc As String = De_Num_a_Tx_01(_Fila.Item("MargenPorc"), False, 5)
                    Dim _VarMcosto As String = De_Num_a_Tx_01(_Fila.Item("VarMcosto"), False, 5)
                    Dim _VarPm As String = De_Num_a_Tx_01(_Fila.Item("VarPm"), False, 5)
                    Dim _VarUc As String = De_Num_a_Tx_01(_Fila.Item("VarUc"), False, 5)
                    Dim _VarFlete As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Item("VarFlete"), 0), False, 5)
                    Dim _VarIva As String = De_Num_a_Tx_01(_Fila.Item("VarIva"), False, 5)
                    Dim _VarIla As String = De_Num_a_Tx_01(_Fila.Item("VarIla"), False, 5)
                    Dim _VarNetoDigit As String = De_Num_a_Tx_01(_Fila.Item("VarNetoDigit"), False, 5)
                    Dim _VarValorDigit As String = De_Num_a_Tx_01(_Fila.Item("VarValorDigit"), False, 5)


                    Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles
           ([Id_Enc]
           ,[Lista]
           ,[NombreLista]
           ,[Codigo]
           ,[PrecioUd1]
           ,[PrecioUd2]
           ,[EcuacionUd1]
           ,[EcuacionUd2]
           ,[Rtu]
           ,[MargenPorc]
           ,[VarMcosto]
           ,[VarPm]
           ,[VarUc]
           ,[VarFlete]
           ,[VarIva]
           ,[VarIla]
           ,[VarNetoDigit]
           ,[VarValorDigit])
     Values
           (@Id_Enc

           ,'" & _Lista & "'
           ,'" & _NombreLista & "'
           ,'" & _Codigo & "'
           ," & _PrecioUd1 & "
           ," & _PrecioUd2 & "
           ,'" & _EcuacionUd1 & "'
           ,'" & _EcuacionUd2 & "'
           ," & _Rtu & "
           ," & _MargenPorc & "
           ," & _VarMcosto & "
           ," & _VarPm & "
           ," & _VarUc & "
           ," & _VarFlete & "
           ," & _VarIva & "
           ," & _VarIla & "
           ," & _VarNetoDigit & "
           ," & _VarValorDigit & ");
"
                End If

            Next

            If _ReemplazarDatos Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaLC_Programadas Where Id = " & _Id_Enc & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Where Id_Enc = " & _Id_Enc &
                               vbCrLf & vbCrLf & Consulta_sql

            End If

            If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            MessageBoxEx.Show(Me, "Actualizacion de Precios Programada Correctamente", "Grabar Precios Programado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            Grabar = True
            Me.Close()

        End If

    End Sub

    Private Sub Btn_EditarFechaProgramacion_Click(sender As Object, e As EventArgs) Handles Btn_EditarFechaProgramacion.Click

        Dim _Grabar As Boolean
        Dim _FechaSeleccionada As DateTime

        Dim Fm As New Frm_Seleccionar_Fecha
        Fm.ExigeFechaMinima = True
        Fm.FechaMinima = FechaDelServidor()
        Fm.SolicitarConfirmacionDeFecha = True
        Fm.FechaDisplay = Dtp_FechaProgramada.Value
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _FechaSeleccionada = Fm.FechaSeleccionada
        Fm.Dispose()

        If _Grabar Then

            If Dtp_FechaProgramada.Value = _FechaSeleccionada Then
                MessageBoxEx.Show(Me, "La nueva fecha es igual a la fecha anterior", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _Reg = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaLC_Programadas", "Id",
                                        "Codigo='" & _RowProducto.Item("KOPR") & "' " &
                                        "And FechaProgramada = '" & Format(_FechaSeleccionada, "yyyyMMdd") & "' And Eliminada = 0", True)

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Ya hay una lista programada para esta fecha " & _FechaSeleccionada.ToShortDateString & vbCrLf & vbCrLf &
                              "Si quiere crear una programación nueva para esta fecha, primero debe eliminar la anterior y grabar una nueva", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql =
"Declare @Id_Enc Int

Insert Into " & _Global_BaseBk & "Zw_ListaLC_Programadas
           ([Codigo]
           ,[NombreProgramacion]
           ,[FechaCreacion]
           ,[FechaProgramada]
           ,[Aplicado],[Funcionario],[Activo],[Id_Padre])
Values
           ('" & _RowProducto.Item("KOPR") & "'
           ,'" & _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim & " DesdeListaLC'
           ,Getdate()
           ,'" & Format(_FechaSeleccionada, "yyyyMMdd") & "'
           ,0,'" & FUNCIONARIO & "','1'," & _Id_Enc & ")
           
           Set @Id_Enc = (SELECT @@IDENTITY AS Id)

Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set Editada = 1,Activo = 0, Aplicado = 0
     Where Id = " & _Id_Enc & " 

Update " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Set Id_Enc = @Id_Enc" & "
     Where Id_Enc = " & _Id_Enc

            If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                Return
            End If

            Dtp_FechaProgramada.Value = _FechaSeleccionada

            MessageBoxEx.Show(Me, "Fecha actualizada correctamente" & vbCrLf &
                              "Los precios cambiaran automaticamente el " & _FechaSeleccionada.ToShortDateString,
                              "Editar fecha programación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Chk_Seleccionar_Todo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleccionar_Todo.CheckedChanged

        For Each _Fila As DataRow In _TblPrecios.Rows
            _Fila.Item("Chk") = Chk_Seleccionar_Todo.Checked
        Next

    End Sub

    Private Sub Grilla_Precios_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla_Precios.MouseUp
        Grilla_Precios.EndEdit()
    End Sub

    Private Sub Btn_Eliminar_Programa_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Programa.Click

        If CBool(_TblPrecios.Rows.Count) Then
            ShowContextMenu(Menu_Contextual)
        Else
            Call Btn_EliminarTodo_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Btn_EliminarMarcados_Click(sender As Object, e As EventArgs) Handles Btn_EliminarMarcados.Click

        Dim _FilasSeleccionadas = 0

        For Each _Fila As DataRow In _TblPrecios.Rows
            If _Fila.Item("Chk") Then
                _FilasSeleccionadas += 1
            End If
        Next

        If Not CBool(_FilasSeleccionadas) Then
            MessageBoxEx.Show(Me, "No hay filas seleccionadas", "Eliminar marcadas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _FilasSeleccionadas = _TblPrecios.Rows.Count Then

            Call Btn_EliminarTodo_Click(Nothing, Nothing)
            Return

        End If

        If MessageBoxEx.Show(Me, "¿confirma la eliminación de estas listas programadas?", "Eliminar marcadas",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _TblPrecios.Rows

            If _Fila.Item("Chk") Then

                Dim _Id = _Fila.Item("Id")

                Consulta_sql += "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Set " &
                                "Eliminada = 1,FuncionarioElimina = '" & FUNCIONARIO & "'" & vbCrLf &
                                "Where Id = " & _Id & vbCrLf

            End If

        Next

        If Not String.IsNullOrEmpty(Consulta_sql) Then
            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Registros eliminados correctamente", "Eliminar marcadas",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub Btn_EliminarTodo_Click(sender As Object, e As EventArgs) Handles Btn_EliminarTodo.Click

        If CBool(_TblPrecios.Rows.Count) Then
            If MessageBoxEx.Show(Me, "¿confirma la eliminación de estas listas programadas?", "Eliminar marcadas",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Where Id_Enc = " & _Id_Enc & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set " &
                       "Activo = 0,Eliminada = 1,FuncionarioElimina = '" & FUNCIONARIO & "',FechaEliminacion = Getdate()" & vbCrLf &
                       "Where Id = " & _Id_Enc
        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Registros eliminados correctamente", "Eliminar programación",
                      MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me._Grabar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Function Fx_Eliminar_Toda_Programacion(_Id_Enc As Integer) As String

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Where Id_enc = " & _Id_Enc & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set " &
                       "Activo = 0,Eliminada = 1,FuncionarioElimina = '" & FUNCIONARIO & "',FechaEliminacion = Getdate()" & vbCrLf &
                       "Where Id = " & _Id_Enc
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        Return _Sql.Pro_Error

    End Function

End Class
