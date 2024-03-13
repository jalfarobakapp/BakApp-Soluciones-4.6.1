'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Masivo_Prov_Autoriza_01_Enc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _TblInforme As DataTable
    Dim _Id_Correo As Integer

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me.Text = "ASISTENTE DE PAGOS MASIVOS A PROVEEDORES AUTORIZADOS"

    End Sub

    Private Sub Frm_Pagos_Masivo_Encabezado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Filtro = String.Empty

        If Chk_Mostrar_Solo_Pagos_Pendientes.Checked Then
            _Filtro = "And SALDO > 0"
        End If

        Consulta_sql = "Select Id_Autoriza,Referencia,Funcionario," & vbCrLf &
                       "(Select NOKOFU FRom TABFU Where KOFU = Funcionario) As Nombre_Funcionario," & vbCrLf &
                       "Fecha_Autoriza,Fecha_Pago,Tipo_Pago," & vbCrLf &
                       "Case Tipo_Pago When 'CHC' Then 'Cheque' Else 'Transferencia' End As Pagar_Con," & vbCrLf &
                       "Isnull((Select Sum(VAVE) From MAEVEN Where IDMAEVEN In (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Z2 Where Z1.Id_Autoriza = Z2.Id_Autoriza)),0) As VAVE," & vbCrLf &
                       "Isnull((Select Sum(VAABVE) From MAEVEN Where IDMAEVEN In (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Z2 Where Z1.Id_Autoriza = Z2.Id_Autoriza)),0) As VAABVE," & vbCrLf &
                       "Isnull((Select Sum(VAVE-VAABVE) From MAEVEN Where IDMAEVEN In (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Z2 Where Z1.Id_Autoriza = Z2.Id_Autoriza)),0) As SALDO," & vbCrLf &
                       "Isnull((Select Count(*) From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Z2 Where Z1.Id_Autoriza = Z2.Id_Autoriza And Z2.Pagado = 1),0) As Pagados," & vbCrLf &
                       "Total" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Z1" & vbCrLf & vbCrLf &
                       "UPDATE " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Set Total = (Select SALDO From #Paso Z2 Where Z2.Id_Autoriza = Z1.Id_Autoriza)" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Z1" & vbCrLf & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _Filtro & vbCrLf &
                       "Order By Fecha_Pago" & vbCrLf &
                       "Drop Table #Paso"

        _TblInforme = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _TblInforme
            OcultarEncabezadoGrilla(Grilla, True)

            Dim _Menos = 10

            .Columns("Id_Autoriza").Width = 40
            .Columns("Id_Autoriza").HeaderText = "Nro."
            .Columns("Id_Autoriza").Visible = True
            .Columns("Id_Autoriza").DisplayIndex = 0

            .Columns("Referencia").Width = 270
            .Columns("Referencia").HeaderText = "Referencia"
            .Columns("Referencia").Visible = True
            .Columns("Referencia").DisplayIndex = 1

            .Columns("Funcionario").Width = 30
            .Columns("Funcionario").HeaderText = "Fun."
            .Columns("Funcionario").Visible = True
            .Columns("Funcionario").DisplayIndex = 2

            .Columns("Fecha_Autoriza").Width = 70
            .Columns("Fecha_Autoriza").HeaderText = "Fecha Aut."
            .Columns("Fecha_Autoriza").DefaultCellStyle.Format = "dd-MM-yyyy"
            .Columns("Fecha_Autoriza").Visible = True
            .Columns("Fecha_Autoriza").DisplayIndex = 3

            .Columns("Fecha_Pago").Width = 80
            .Columns("Fecha_Pago").HeaderText = "Fecha Pago"
            .Columns("Fecha_Pago").Visible = True
            .Columns("Fecha_Pago").DisplayIndex = 4

            .Columns("Pagar_Con").Width = 80
            .Columns("Pagar_Con").HeaderText = "Tipo Pago"
            .Columns("Pagar_Con").Visible = True
            .Columns("Pagar_Con").DisplayIndex = 6

            .Columns("VAVE").HeaderText = "Autorizado" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAVE").Width = 80
            .Columns("VAVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAVE").Visible = True
            .Columns("VAVE").DisplayIndex = 7

            .Columns("VAABVE").HeaderText = "Pagado" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAABVE").Width = 80
            .Columns("VAABVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAABVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABVE").Visible = True
            .Columns("VAABVE").DisplayIndex = 7

            .Columns("SALDO").HeaderText = "Saldo" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("SALDO").Width = 80
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DisplayIndex = 7

        End With

    End Sub

    Private Sub Frm_Pagos_Masivo_Prov_Autoriza_01_Enc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Actualizar_Informacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Informacion.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Informe_Venciminetos_Compras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Venciminetos_Compras.Click
        If Fx_Tiene_Permiso(Me, "Inc00001") Then
            Dim Fm As New Frm_Inf_Vencimientos_Procesar_Informe("DS_Filtro_Informe_vencimientos_compra.xml", "Inc00001")
            Fm._Informe = Frm_Inf_Vencimientos_Procesar_Informe.Tipo_Informe.Compras
            Fm.ShowDialog(Me)
            Fm.Dispose()
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Ingresar_Pago_de_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ingresar_Pago_de_Documentos.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Autoriza As Integer = _Fila.Cells("Id_Autoriza").Value
        Dim _Tipo_Pago As String = _Fila.Cells("Tipo_Pago").Value
        Dim _Pagar_Con As String = _Fila.Cells("Pagar_Con").Value
        Dim _Referencia As String = _Fila.Cells("Referencia").Value
        Dim _Fecha_Pago As Date = _Fila.Cells("Fecha_Pago").Value

        Select Case _Tipo_Pago
            Case "CHC"

                Dim Fm_Chc As New Frm_Pagos_Masivos_Entiades(_Id_Autoriza)
                Fm_Chc.Text = _Referencia & " (" & _Pagar_Con & ") Fecha: " & _Fecha_Pago
                Fm_Chc.ShowDialog(Me)
                Fm_Chc.Dispose()

            Case "PTB"

                Consulta_sql = "SELECT Min(FEVE) As Fecha_Inicio,MAX(FEVE) As Fecha_Fin" & vbCrLf &
                               "FROM MAEVEN WHERE IDMAEVEN IN (Select Idmaeven From " & vbCrLf &
                               _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Id_Autoriza = " & _Id_Autoriza & ")"

                Dim _Row_Fechas As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Fecha_Inicio As Date = _Row_Fechas.Item("Fecha_Inicio")
                Dim _Fecha_Fin As Date = _Row_Fechas.Item("Fecha_Fin")

                Dim _Filtro_Adicional As String = "And IDMAEVEN In (Select Idmaeven" & Space(1) &
                                                  "From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & Space(1) &
                                                  "Where Id_Autoriza = " & _Id_Autoriza & ")"

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Where Id_Autoriza = " & _Id_Autoriza
                Dim _Row_Pago_Autorizado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)



                Dim Fm As New Frm_Pagos_Masivos_Detalle(Frm_Pagos_Masivos_Detalle.Enum_Tipo_Pago.Proveedores,
                                                         _Fecha_Inicio,
                                                         _Fecha_Fin,
                                                         _Id_Correo)
                Fm.Pro_Filtro_Adicional = _Filtro_Adicional
                Fm.Pro_Row_Pago_Autorizado = _Row_Pago_Autorizado
                Fm.ShowDialog(Me)
                Fm.Dispose()

        End Select

        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Editar_Encabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Encabezado.Click

        If Fx_Tiene_Permiso(Me, "Ppro0008") Then
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Id_Autoriza As Integer = _Fila.Cells("Id_Autoriza").Value
            Dim _Saldo = _Fila.Cells("SALDO").Value

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc" & vbCrLf &
                           "Where Id_Autoriza = " & _Id_Autoriza
            Dim _Row_Autorizacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim Fm As New Frm_Pago_Masivo_Autoriza_Enc(Frm_Pago_Masivo_Autoriza_Enc.Enum_Accion.Editar)
            Fm.Pro_Row_Autorizacion = _Row_Autorizacion
            Fm.ShowDialog(Me)
            If Fm.Pro_Grabar Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Sb_Actualizar_Grilla()
            End If
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        If Fx_Tiene_Permiso(Me, "Ppro0009") Then
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Id_Autoriza As Integer = _Fila.Cells("Id_Autoriza").Value

            If MessageBoxEx.Show(Me, "¿Está seguro de eliminar esta autorización?",
                                 "Eliminar autorización completamente", MessageBoxButtons.YesNoCancel,
                                 MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Fx_Se_Puede_Editar_Encabezado(_Id_Autoriza) Then
                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc" & Space(1) & "Where Id_Autoriza = " & _Id_Autoriza & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & Space(1) & "Where Id_Autoriza = " & _Id_Autoriza
                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                        Sb_Actualizar_Grilla()
                    End If
                Else
                    Sb_Actualizar_Grilla()
                End If
            End If
        End If

    End Sub

    Function Fx_Se_Puede_Editar_Encabezado(ByVal _Id_Autoriza As Integer) As Boolean

        If CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det",
           "Pagado = 1 And Id_Autoriza = " & _Id_Autoriza)) Then
            MessageBoxEx.Show(Me, "Existen pagos generados desde está autorización",
                             "Validación", MessageBoxButtons.OK)
        Else
            Return True
        End If

    End Function

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    Dim _Id_Autoriza As Integer = _Fila.Cells("Id_Autoriza").Value
                    Dim _Saldo = _Fila.Cells("SALDO").Value
                    Dim _Pagados = _Fila.Cells("PAGADOS").Value

                    Btn_Editar_Encabezado.Enabled = CBool(_Saldo)
                    If CBool(_Pagados) Then
                        Btn_Eliminar.Enabled = False
                    Else
                        Btn_Eliminar.Enabled = True
                    End If

                    ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Call Btn_Ingresar_Pago_de_Documentos_Click(Nothing, Nothing)
    End Sub

End Class
