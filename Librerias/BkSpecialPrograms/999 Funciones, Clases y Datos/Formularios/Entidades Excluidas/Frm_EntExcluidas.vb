Imports DevComponents.DotNetBar
Imports System.Data.SqlClient


Public Class Frm_EntExcluidas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Ds_Entidad_Exc As New Ds_EntExcluidas

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_00_AsisCompra_EntExcluidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_grilla()
    End Sub

    Function Llenar_grilla()

        Ds_Entidad_Exc.Clear()
        Grilla.DataSource = Nothing
        Dim cn1 As New SqlConnection

        Consulta_sql = "SELECT Excluida," &
                       "Codigo,Sucursal," &
                       "IsNull((Select top 1 NOKOEN From MAEEN Where KOEN = Codigo And SUEN = Sucursal),'') as Razon," & vbCrLf &
                       "Case Excluida " & vbCrLf &
                       "When 'C' Then 'COMPRA'" & vbCrLf &
                       "When 'V' Then 'VENTA'" & vbCrLf &
                       "When 'A' Then 'AMBAS'" & vbCrLf &
                       "When 'D' Then 'DESPACHO'" & vbCrLf &
                       "When 'T' Then 'TODAS'" & vbCrLf &
                       "End as Exc" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TblInf_EntExcluidas as Zw" & vbCrLf &
                       "WHERE Funcionario = '" & FUNCIONARIO & "'" ' And Razon LIKE '%" & cadena & "%'"
        Ds_Entidad_Exc = _Sql.Fx_Get_DataSet(Consulta_sql, Ds_Entidad_Exc, "Entidades_Exc")



        With Grilla
            .DataSource = Ds_Entidad_Exc
            .DataMember = Ds_Entidad_Exc.Tables("Entidades_Exc").TableName

            OcultarEncabezadoGrilla(Grilla)

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Entidad"
            .Columns("Codigo").Visible = True

            .Columns("Sucursal").Width = 60
            .Columns("Sucursal").HeaderText = "Suc."
            .Columns("Sucursal").Visible = True

            .Columns("Razon").Width = 250
            .Columns("Razon").HeaderText = "Razon Social"
            .Columns("Razon").Visible = True

            .Columns("Exc").Width = 100
            .Columns("Exc").HeaderText = "Excluida en"
            .Columns("Exc").Visible = True

        End With

    End Function

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    MenuContextual.Enabled = True
                Else
                    MenuContextual.Enabled = False
                    Return
                End If

                Dim _Exc As String = .Rows(.CurrentRow.Index).Cells("Excluida").VALUE
                Select Case _Exc
                    Case "C"
                        Mnucontex_COMRA.Checked = True
                        Mnucontex_VENTA.Checked = False
                        Mnucontex_AMBAS.Checked = False
                        DespachoMercaderiaPendienteToolStripMenuItem.Checked = False
                        TodoToolStripMenuItem.Checked = False
                    Case "V"
                        Mnucontex_COMRA.Checked = False
                        Mnucontex_VENTA.Checked = True
                        Mnucontex_AMBAS.Checked = False
                        DespachoMercaderiaPendienteToolStripMenuItem.Checked = False
                        TodoToolStripMenuItem.Checked = False
                    Case "A"
                        Mnucontex_COMRA.Checked = False
                        Mnucontex_VENTA.Checked = False
                        Mnucontex_AMBAS.Checked = True
                        DespachoMercaderiaPendienteToolStripMenuItem.Checked = False
                        TodoToolStripMenuItem.Checked = False
                    Case "D"
                        Mnucontex_COMRA.Checked = False
                        Mnucontex_VENTA.Checked = False
                        Mnucontex_AMBAS.Checked = False
                        DespachoMercaderiaPendienteToolStripMenuItem.Checked = True
                        TodoToolStripMenuItem.Checked = False
                    Case "T"
                        Mnucontex_COMRA.Checked = False
                        Mnucontex_VENTA.Checked = False
                        Mnucontex_AMBAS.Checked = False
                        DespachoMercaderiaPendienteToolStripMenuItem.Checked = False
                        TodoToolStripMenuItem.Checked = True
                End Select

            End With
        End If

    End Sub

    Private Sub Mnucontex_COMRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnucontex_COMRA.Click
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Excluida").Value = "C"
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Exc").Value = "COMPRA"
    End Sub

    Private Sub Mnucontex_VENTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnucontex_VENTA.Click
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Excluida").Value = "V"
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Exc").Value = "VENTA"
    End Sub

    Private Sub Mnucontex_AMBAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnucontex_AMBAS.Click
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Excluida").Value = "A"
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Exc").Value = "AMBAS"
    End Sub

    Private Sub QuitarEntidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitarEntidadToolStripMenuItem.Click
        If MessageBoxEx.Show(Me, "¿Esta seguro de quitar esta entidad?", "Quitar entidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
        End If
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblInf_EntExcluidas Where Funcionario = '" & FUNCIONARIO & "'"
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            For Each Fila As DataRow In Ds_Entidad_Exc.Tables("Entidades_Exc").Rows

                If Fila.RowState <> DataRowState.Deleted Then

                    Dim _Codigo As String = Fila.Item("Codigo")
                    Dim _Sucursal As String = Fila.Item("Sucursal")
                    Dim _Excluida As String = Fila.Item("Excluida")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TblInf_EntExcluidas (Excluida,Funcionario,Codigo,Sucursal)" & vbCrLf &
                                   "Values ('" & _Excluida & "','" & FUNCIONARIO & "','" & _Codigo & "','" & _Sucursal & "')"
                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            MessageBoxEx.Show(Me, "Datos guardados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error",
                                          Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)
        End Try

    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyValue = Keys.Delete Then
                e.Handled = True
                If MessageBoxEx.Show(Me, "¿Esta seguro de quitar esta entidad?",
                                     "Quitar entidad", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnBuscarEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarEntidad.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(True)
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Entidad_Seleccionada Then

            Rd_Compra.Checked = True
            Dim _Exc, _Excluida As String

            Dim info As New TaskDialogInfo("Excluir entidad",
                          eTaskDialogIcon.Exclamation + eTaskDialogIcon.Information2,
                          "Excluir entidad para:",
                          "Favor marcar una opción",
                          eTaskDialogButton.Ok _
                          , eTaskDialogBackgroundColor.Red, GetRadioButtons, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            If Rd_Compra.Checked Then
                _Exc = "COMPRA" : _Excluida = "C"
            ElseIf Rd_Venta.Checked Then
                _Exc = "VENTA" : _Excluida = "V"
            ElseIf Rd_Ambas.Checked Then
                _Exc = "AMBAS" : _Excluida = "A"
            ElseIf Rd_Despacho.Checked Then
                _Exc = "DESPACHO" : _Excluida = "D"
            ElseIf Rd_Todo.Checked Then
                _Exc = "TODO" : _Excluida = "T"
            End If

            Try
                Dim NewFila As DataRow
                NewFila = Ds_Entidad_Exc.Tables("Entidades_Exc").NewRow

                With NewFila
                    .Item("Exc") = _Exc
                    .Item("Funcionario") = FUNCIONARIO
                    .Item("Codigo") = Fm.Pro_RowEntidad.Item("KOEN")
                    .Item("Sucursal") = Fm.Pro_RowEntidad.Item("SUEN")
                    .Item("Razon") = Fm.Pro_RowEntidad.Item("NOKOEN")
                    .Item("Excluida") = _Excluida
                End With

                Ds_Entidad_Exc.Tables("Entidades_Exc").Rows.Add(NewFila)
                Fm.Dispose()

            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message)
            End Try

        End If

    End Sub

    Private Function GetRadioButtons() As Command()
        Return New Command() {Rd_Compra, Rd_Venta, Rd_Ambas, Rd_Despacho, Rd_Todo}
    End Function

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        ExportarTabla_JetExcel_Tabla(Ds_Entidad_Exc.Tables("Entidades_Exc"), Me, "Entidades excluidas")
    End Sub

    Private Sub DespachoMercaderiaPendienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DespachoMercaderiaPendienteToolStripMenuItem.Click
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Excluida").Value = "D"
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Exc").Value = "DESPACHO"
    End Sub

    Private Sub TodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TodoToolStripMenuItem.Click
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Excluida").Value = "T"
        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Exc").Value = "TODO"
    End Sub

    Private Sub Frm_00_AsisCompra_EntExcluidas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
