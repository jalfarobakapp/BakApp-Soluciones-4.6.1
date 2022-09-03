'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_Ver_Documento_Pagos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idmaeedo As Integer
    Dim _Row_Maeedo As DataRow
    Dim _Pagos_Actualizados As Boolean
    Public Property Pagos_Actualizados As Boolean
        Get
            Return _Pagos_Actualizados
        End Get
        Set(value As Boolean)
            _Pagos_Actualizados = value
        End Set
    End Property

    Public Sub New(ByVal Idmaeedo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Idmaeedo = Idmaeedo
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_DocumentoTraza_Pagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Consulta_sql = "SELECT CD.IDMAEDPCE,CD.TIDOPA,CD.ARCHIRST,CD.IDRST,CD.FEASDP,CD.VAASDP,PROPIO.TIDP,PROPIO.NUDP,PROPIO.ENDP,PROPIO.FEEMDP," &
                       "PROPIO.FEVEDP,PROPIO.VADP,PROPIO.TIMODP,PROPIO.MODP,PROPIO.TAMODP,PROPIO.TIMODP,PROPIO.REFANTI,CD.TCASIG" & vbCrLf &
                       "FROM MAEDPCD AS CD  WITH ( NOLOCK )  " & vbCrLf &
                       "LEFT JOIN MAEDPCE AS PROPIO ON CD.IDMAEDPCE=PROPIO.IDMAEDPCE  " & vbCrLf &
                       "WHERE CD.ARCHIRST='MAEEDO  '  AND CD.IDRST=" & _Idmaeedo & " ORDER BY CD.FEASDP "

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla
            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("TIDP").Width = 30
            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Visible = True
            .Columns("TIDP").DisplayIndex = 0

            .Columns("NUDP").Width = 80
            .Columns("NUDP").HeaderText = "Número"
            .Columns("NUDP").Visible = True
            .Columns("NUDP").DisplayIndex = 1

            .Columns("FEEMDP").Width = 80
            .Columns("FEEMDP").HeaderText = "Fecha Emisión"
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").DisplayIndex = 2

            .Columns("FEVEDP").Width = 80
            .Columns("FEVEDP").HeaderText = "Fecha Vencimiento"
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DisplayIndex = 3

            '.Columns("MODP").Width = 20
            '.Columns("MODP").HeaderText = "M"
            '.Columns("MODP").Visible = True

            .Columns("VADP").Width = 90
            .Columns("VADP").HeaderText = "Valor Documento $"
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VADP").Visible = True
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DisplayIndex = 4

            .Columns("VAASDP").Width = 90
            .Columns("VAASDP").HeaderText = "Valor Asignado $"
            .Columns("VAASDP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAASDP").Visible = True
            .Columns("VAASDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAASDP").DisplayIndex = 5

            .Columns("REFANTI").Width = 280
            .Columns("REFANTI").HeaderText = "Observación"
            .Columns("REFANTI").Visible = True
            .Columns("REFANTI").DisplayIndex = 6

        End With

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Private Sub Frm_DocumentoTraza_Pagos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

        Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub
    Private Sub Btn_Cambiar_3Cuotas_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_3Cuotas.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Koen = _Sql.Fx_Trae_Dato("MAEEDO", "ENDO", "IDMAEEDO = " & _Idmaeedo)

        Dim _Vadp As Double = _Fila.Cells("VADP").Value

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

        Consulta_sql = "Select * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
        Dim _Row_OldMaedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Pago As New Clas_Pagar
        Dim _Eliminar As String = _Pago.Fx_Eliminar_Pago(_Idmaedpce)

        If String.IsNullOrEmpty(_Eliminar) Then

            Dim _Tido = _Row_Maeedo.Item("TIDO")
            Dim _Nudo = _Row_Maeedo.Item("NUDO")

            Dim Fm As New Frm_Pagos_Documentos("")
            Fm.Sb_Nuevo_Documento()

            _Idmaedpce = 0

            If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                Dim _FilaM As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                _FilaM.Cells("TIDP").Value = "TJV"
                _FilaM.Cells("ESPGDP").Value = "P"
                _FilaM.Cells("VADP").Value = _Vadp

                _FilaM.Cells("EMDP").Value = _Row_OldMaedpce.Item("EMDP")
                _FilaM.Cells("CUDP").Value = _Row_OldMaedpce.Item("CUDP")
                _FilaM.Cells("NUCUDP").Value = _Row_OldMaedpce.Item("NUCUDP")
                _FilaM.Cells("CUOTAS").Value = 3

                _FilaM.Cells("REFANTI").Value = _Row_OldMaedpce.Item("REFANTI")

                _FilaM.Cells("NUTRANSMI").Value = _Row_OldMaedpce.Item("NUTRANSMI")
                _FilaM.Cells("DOCUENANTI").Value = _Row_OldMaedpce.Item("DOCUENANTI")
                _FilaM.Cells("FEEMDP").Value = _Row_OldMaedpce.Item("FEEMDP")
                _FilaM.Cells("FEVEDP").Value = _Row_OldMaedpce.Item("FEVEDP")

                Fm.Sb_Sumar_Totales()
                Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

            End If
            Fm.Dispose()

            If CBool(_Idmaedpce) Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Cambiar 3 cuotas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            _Pagos_Actualizados = True
            Me.Close()

        Else

            MessageBoxEx.Show(Me, _Eliminar, "No fue posible convertir el pago", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
    Private Sub Btn_Eliminar_Pago_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Pago.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEDPCD", "IDMAEDPCE = " & _Idmaedpce & " And IDRST <> " & _Idmaeedo)

        If Fx_Eliminar_El_Pago(_Idmaedpce) Then
            MessageBoxEx.Show(Me, "Pago eliminado correctamente", "Eliminar pago", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Pagos_Actualizados = True
            Me.Close()
        End If

    End Sub

    Function Fx_Eliminar_El_Pago(_Idmaedpce As Integer) As Boolean

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación del pago?", "Eliminar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return False
        End If

        Dim _Pago As New Clas_Pagar
        Dim _Eliminar As String = _Pago.Fx_Eliminar_Pago(_Idmaedpce)

        If Not String.IsNullOrEmpty(_Eliminar) Then
            MessageBoxEx.Show(Me, _Eliminar, "No fue posible eliminar el pago", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
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

                    Consulta_sql = "Select * From CONFIEST Where MODALIDAD = '  '"
                    Dim _Row_Confiest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Cuotacomer As Boolean = _Row_Confiest.Item("CUOTACOMER")
                    Dim _Cuotacanti As Integer = _Row_Confiest.Item("CUOTACANTI")

                    If _Cuotacanti > 1 Then

                        Btn_Cambiar_3Cuotas.Text = "Cambiar a " & _Cuotacanti & " cuotas (cuota comercio)"

                        Dim _CuentaTJV = 0

                        For Each _Fila As DataGridViewRow In Grilla.Rows
                            If _Fila.Cells("TIDP").Value = "TJV" Then
                                _CuentaTJV += 1
                            End If
                        Next

                        Btn_Cambiar_3Cuotas.Enabled = (_CuentaTJV = 1)
                        Btn_Cambiar_3Cuotas.Visible = _Cuotacomer
                    Else
                        Btn_Cambiar_3Cuotas.Visible = False
                    End If

                    ShowContextMenu(Menu_Contextual_01)

                End If
            End With
        End If
    End Sub

End Class
