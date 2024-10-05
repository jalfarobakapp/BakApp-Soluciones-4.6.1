'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Schedule
Imports DevComponents.Schedule.Model
Imports DevComponents.DotNetBar.Rendering

Public Class Frm_Inf_Vencimientos_Mes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fecha_Inicio, _Fecha_Fin As Date

    Dim _Valor_Maximo_Marca As Double
    Dim _Tbl_Informe As DataTable
    Dim _Tbl_Marca_Calendario As DataTable

    Dim _Id_Correo As Integer
    Dim _Chk_Deuda_Efectiva As Boolean

    Dim _Informe As Tipo_Informe

    Dim _Filtro_Maeedo,
        _Filtro_Maedpce,
        _Filtro_Entidades_Excluidas,
        _Filtro_Adicional As String

    Dim _Marcar_Dias_Revision_Pago As Boolean

    Enum Tipo_Informe
        Compras
        Ventas
    End Enum

#Region "PROPIEDADES"

    Public Property Pro_Tbl_Informe()
        Get

            'If CBool(_Tbl_Informe.Rows.Count) Then
            'Sb_Actualizar_Calendario(Progreso_Cont, Progreso_Porc)
            'End If
            Return _Tbl_Informe

        End Get
        Set(value)
            _Tbl_Informe = value
        End Set
    End Property
    Public Property Pro_Chk_Deuda_Efectiva()
        Get
            Return _Chk_Deuda_Efectiva
        End Get
        Set(value)
            _Chk_Deuda_Efectiva = value
        End Set
    End Property
    Public Property Pro_Filtro_Maeedo() As String
        Get
            Return _Filtro_Maeedo
        End Get
        Set(value As String)
            _Filtro_Maeedo = value
        End Set
    End Property
    Public Property Pro_Filtro_Maedpce() As String
        Get
            Return _Filtro_Maedpce
        End Get
        Set(value As String)
            _Filtro_Maedpce = value
        End Set
    End Property
    Public Property Pro_Filtro_Adicional() As String
        Get
            Return _Filtro_Adicional
        End Get
        Set(value As String)
            _Filtro_Adicional = value
        End Set
    End Property

#End Region

    Public Sub New(New_Tipo_Informe As Tipo_Informe,
                   New_Valor_Marca_Maximo As Double,
                   New_Id_Correo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _Informe = New_Tipo_Informe
        _Valor_Maximo_Marca = New_Valor_Marca_Maximo
        _Id_Correo = New_Id_Correo
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Inf_Vencimientos_Mes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Sb_Actualizar_Calendario()
    End Sub

    Sub Sb_Actualizar_Calendario(Progreso_Cont As Object, Progreso_Porc As Object)

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Do While Calendario_Mes.CalendarModel.Appointments.Count > 0
                Dim _Apoint = Calendario_Mes.CalendarModel.Appointments.Item(Calendario_Mes.CalendarModel.Appointments.Count - 1)
                Calendario_Mes.CalendarModel.Appointments.Remove(_Apoint)
            Loop

            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = _Tbl_Informe.Rows.Count


            For Each _Fila As DataRow In _Tbl_Informe.Rows

                System.Windows.Forms.Application.DoEvents()
                Dim _Fecha As Date = _Fila.Item("FEVE")
                Dim _Saldo As Double = _Fila.Item("Saldo")
                Dim _Deuda As String = _Fila.Item("Deuda")

                'Dim _Revisado_Pago As Boolean = CBool(_Fila.Item("Revisado_Pago"))

                Dim _Tipo_Deuda As Tipo_Deuda
                Dim _Tooltip As String

                If _Deuda = "Documentos" Then

                    _Tipo_Deuda = Tipo_Deuda.Documentos
                    If _Saldo > 0 Then
                        _Tooltip = "Documentos de " & _Informe.ToString & ": Facturas, Notas de débito, Boletas, Etc."
                    Else
                        _Tooltip = "Notas de crédito"
                    End If

                ElseIf _Deuda = "Pagos" Then

                    _Tipo_Deuda = Tipo_Deuda.Pagos
                    _Tooltip = "Documentos de pago: Cheques, Letras, Pagares, Etc."

                End If

                Sb_Agregar_Valor(_Saldo, _Fecha, _Valor_Maximo_Marca, _Tipo_Deuda, _Tooltip)

                System.Windows.Forms.Application.DoEvents()
                Progreso_Cont.Value += 1
                Progreso_Porc.Value = ((Progreso_Cont.Value * 100) / _Tbl_Informe.Rows.Count) 'Mas

            Next

            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = _Tbl_Marca_Calendario.Rows.Count

            If _Informe = Tipo_Informe.Compras Then

                For Each _fila As DataRow In _Tbl_Marca_Calendario.Rows
                    Dim _Fecha As Date = _fila.Item("FEVE")
                    Sb_Agregar_Marca("R...", _Fecha, "Día revisado para pagar documento")

                    System.Windows.Forms.Application.DoEvents()
                    Progreso_Porc.Value = ((Progreso_Cont.Value * 100) / _Tbl_Marca_Calendario.Rows.Count) 'Mas
                    Progreso_Cont.Value += 1
                Next

                Progreso_Porc.Value = 0
                Progreso_Cont.Value = 0

            End If

            Calendario_Mes.SelectedView = eCalendarView.Month
            Calendario_Mes.DateSelectionStart = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            Calendario_Mes.DateSelectionEnd = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate) 'DateAdd(DateInterval.Day, 1, FechaDelServidor)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Me.Refresh()

    End Sub

    Sub Sb_Ejecutar_Informe(_Fx_Fecha_Inicio As Date,
                            _Fx_Fecha_Fin As Date)


        If _Informe = Tipo_Informe.Compras Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        ElseIf _Informe = Tipo_Informe.Ventas Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf
        End If

        _Fecha_Inicio = _Fx_Fecha_Inicio
        _Fecha_Fin = _Fx_Fecha_Fin

        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", Format(_Fecha_Fin, "yyyyMMdd"))

        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maeedo#", _Filtro_Maeedo)
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maedpce#", _Filtro_Maedpce)
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional#", _Filtro_Adicional)

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)

        '--#Filtro_Adicional_Maeedo#
        '--#Filtro_Adicional_Maedpce#


        If _Chk_Deuda_Efectiva Then

            Consulta_sql += "SELECT DISTINCT F1.FEVE," & vbCrLf &
                             "Round((select SUM(COALESCE(VAVE-VAABVE ,0.0)) " &
                             "From #INFVEN F2 Where F2.FEVE = F1.FEVE And F2.Deuda = 'Documentos'),2) As Saldo,F1.Deuda" & vbCrLf &
                             "From #INFVEN F1" & vbCrLf &
                             "Where Deuda = 'Documentos'" & vbCrLf &
                             "Union" & vbCrLf &
                             "SELECT DISTINCT F1.FEVE," & vbCrLf &
                             "Round((select SUM(COALESCE(VAVE-VAABVE ,0.0)) " &
                             "From #INFVEN F2 Where F2.FEVE = F1.FEVE And F2.Deuda = 'Pagos'),2) As Saldo,F1.Deuda" & vbCrLf &
                             "From #INFVEN F1" & vbCrLf &
                             "Where Deuda = 'Pagos'" & vbCrLf &
                             "Order by FEVE" & vbCrLf & vbCrLf &
                             "Drop Table #INFVEN"

        Else

            Consulta_sql += "SELECT DISTINCT F1.FEVE," & vbCrLf &
                             "Round((select SUM(COALESCE(VAVE-VAABVE ,0.0)) " &
                             "From #INFVEN F2 Where F2.FEVE = F1.FEVE And F2.Deuda = 'Documentos'),2) As Saldo,F1.Deuda" &
                             "--(Select COUNT(*) From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Idmaeven = IDMAEVEN) As Revisado_Pago" & vbCrLf &
                             "From #INFVEN F1" & vbCrLf &
                             "Where Deuda = 'Documentos'" & vbCrLf & vbCrLf &
                             "Drop Table #INFVEN"

        End If

        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = "SELECT DISTINCT FEVE FROM MAEVEN WHERE IDMAEVEN IN " & vbCrLf &
                       "(Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det)"
        _Tbl_Marca_Calendario = _Sql.Fx_Get_DataTable(Consulta_sql)


        Me.Text = "Informe de vencimientos de " & _Informe.ToString & ", Fecha desde: " & _Fecha_Inicio & " Hasta " & _Fecha_Fin

    End Sub

    Enum Tipo_Deuda
        Documentos
        Pagos
    End Enum

    Private Sub Sb_Agregar_Valor(_Valor As Double,
                                 _Fecha As DateTime,
                                 _Valor_Tope_Maximo As Double,
                                 _Tipo_Deuda As Tipo_Deuda,
                                 _Tooltip As String)

        'Dim appointment As Appointment = NewHoliday(title, New DateTime(2010, Month, Day), _Valor)

        'appointment.Recurrence.Yearly.RepeatOnMonth = Month
        'appointment.Recurrence.Yearly.RepeatOnDayOfMonth = Day

        ' Add appointment to the model
        Try

            Dim appointment As New Appointment()

            appointment.Subject = FormatCurrency(_Valor, 0)
            appointment.Tooltip = _Tooltip 'FormatCurrency(_Valor, 0)

            If _Valor > _Valor_Tope_Maximo Then

                If _Tipo_Deuda = Tipo_Deuda.Documentos Then
                    appointment.CategoryColor = Appointment.CategoryRed
                ElseIf _Tipo_Deuda = Tipo_Deuda.Pagos Then
                    appointment.CategoryColor = Appointment.CategoryYellow
                End If

            Else
                appointment.CategoryColor = Appointment.CategoryGreen
            End If

            appointment.TimeMarkedAs = Appointment.TimerMarkerBusy
            appointment.Locked = True

            Dim _Mes = _Fecha.Month
            Dim _Dia = _Fecha.Day
            Dim _Ano = _Fecha.Year

            Dim _Fecha_Inicial As Boolean

            Try
                appointment.StartTime = _Fecha
                _Fecha_Inicial = True
            Catch ex As Exception
                appointment.StartTime = _Fecha.AddDays(-1).AddHours(13)
                'appointment.EndTime = _Fecha.AddDays(1) '#8/14/2017 12:01:59 AM#
                appointment.Subject = "Revisa este día" ' & _Dia
            End Try

            Try
                appointment.EndTime = _Fecha.AddDays(1) '_Fecha
            Catch ex As Exception
                If _Fecha_Inicial Then
                    appointment.EndTime = _Fecha.AddHours(12)
                Else
                    appointment.EndTime = _Fecha.AddDays(1)
                End If
            End Try

            'If _Mes = 8 And _Dia = 13 Then

            'appointment.StartTime = _Fecha.AddDays(-1).AddHours(13)
            'appointment.EndTime = _Fecha.AddDays(1) '#8/14/2017 12:01:59 AM#
            'appointment.Subject = "Revisa el día 13"

            'Else
            'appointment.StartTime = _Fecha

            'If _Mes = 8 And _Dia = 12 Then
            'appointment.EndTime = _Fecha.AddHours(12)
            'Else
            'appointment.EndTime = _Fecha.AddDays(1)
            'End If

            'End If


            appointment.Recurrence = New AppointmentRecurrence()

            appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Yearly
            appointment.Recurrence.RangeLimitType = eRecurrenceRangeLimitType.RangeEndDate
            'appointment.Recurrence.RangeEndDate = DateTime.Today.AddYears(0) ' AÑOS EN LOS CUALES REPETIRA LA ACCION

            Calendario_Mes.CalendarModel.Appointments.Add(appointment)



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Sb_Agregar_Marca(_Marca As String,
                                 _Fecha As DateTime,
                                 _Tooltip As String)

        Try

            Dim appointment As New Appointment()

            appointment.Subject = _Marca ''FormatCurrency(_Valor, 0)
            appointment.Tooltip = _Tooltip 'FormatCurrency(_Valor, 0)
            appointment.CategoryColor = Appointment.CategoryYellow


            appointment.TimeMarkedAs = Appointment.TimerMarkerBusy
            appointment.Locked = True

            Dim _Mes = _Fecha.Month
            Dim _Dia = _Fecha.Day
            Dim _Ano = _Fecha.Year

            Dim _Fecha_Inicial As Boolean

            Try
                appointment.StartTime = _Fecha.AddHours(14)
                _Fecha_Inicial = True
            Catch ex As Exception
                appointment.StartTime = _Fecha.AddDays(-1).AddHours(1)
                'appointment.EndTime = _Fecha.AddDays(1) '#8/14/2017 12:01:59 AM#
                appointment.Subject = "Revisa este día" ' & _Dia
            End Try

            Try
                appointment.EndTime = _Fecha.AddHours(15) '_Fecha
            Catch ex As Exception
                If _Fecha_Inicial Then
                    appointment.EndTime = _Fecha.AddHours(2)
                Else
                    appointment.EndTime = _Fecha.AddDays(1)
                End If
            End Try

            appointment.Recurrence = New AppointmentRecurrence()

            appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Yearly
            appointment.Recurrence.RangeLimitType = eRecurrenceRangeLimitType.RangeEndDate
            Calendario_Mes.CalendarModel.Appointments.Add(appointment)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Calendario_Mes_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Calendario_Mes.MouseUp
        If e.Button = MouseButtons.Left Then
            Calendario_Mes.SelectedView = eCalendarView.Month
        End If
    End Sub

    Private Sub Btn_Ver_Ano_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Ano.Click
        Calendario_Mes.SelectedView = eCalendarView.Year
    End Sub

    Private Sub Btn_Informe_Seleccion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_Seleccion.Click

        Try

            If _Informe = Tipo_Informe.Compras Then
                Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
            ElseIf _Informe = Tipo_Informe.Ventas Then
                Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf
            End If

            Dim _F_Inicio As Date = Calendario_Mes.DateSelectionStart.GetValueOrDefault()
            Dim _F_Fin As Date = DateAdd(DateInterval.Day, -1, Calendario_Mes.DateSelectionEnd.GetValueOrDefault())

            If _F_Inicio = Calendario_Mes.DateSelectionEnd.GetValueOrDefault() Then
                _F_Fin = _F_Inicio
            End If

            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional#", _Filtro_Adicional)

            Dim Fm As New Frm_Inf_Vencimientos_Mes_Detalle_Diario(Consulta_sql,
                                                                  _F_Inicio,
                                                                  _F_Fin,
                                                                  _Valor_Maximo_Marca,
                                                                  _Id_Correo,
                                                                  _Informe)
            Fm.Text = "Informe de vencimientos " & _Informe.ToString
            Fm.Pro_Chk_Deuda_Efectiva = _Chk_Deuda_Efectiva

            Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
            Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce

            Fm.ShowDialog(Me)

            If Fm.Pro_Reprocesar_Informe Then '_Vencimientos_Cambiados Then
                Sb_Ejecutar_Informe(_Fecha_Inicio, _Fecha_Fin)
                Sb_Actualizar_Calendario(Progreso_Cont, Progreso_Porc)
            End If

            Fm.Dispose()
        Catch ex As Exception

        End Try

    End Sub



    Private Sub Frm_Inf_Vencimientos_Mes_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Inf_Vencimientos_Mes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBoxEx.Show(Me, "¿Esta seguro de cerrar el formulario?",
                             "Cerrar formulario",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Btn_Informe_Por_Entidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_Por_Entidad.Click

        Try
            Me.Enabled = False
            If _Informe = Tipo_Informe.Compras Then
                Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
            ElseIf _Informe = Tipo_Informe.Ventas Then
                Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf
            End If

            Dim Fm As New Frm_Inf_Vencimientos_Mes_Detalle_Diario(Consulta_sql,
                                                                  _Fecha_Inicio,
                                                                  _Fecha_Fin,
                                                                  _Valor_Maximo_Marca,
                                                                  _Id_Correo,
                                                                  _Informe)

            Fm.Text = "Informe de vencimientos " & _Informe.ToString
            Fm._Tipo_Informe = Frm_Inf_Vencimientos_Mes_Detalle_Diario.Tipo_Informe.Mensual
            Fm.Pro_Chk_Deuda_Efectiva = _Chk_Deuda_Efectiva

            Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
            Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce

            Fm.ShowDialog(Me)

            If Fm.Pro_Reprocesar_Informe Then '_Vencimientos_Cambiados Then
                Sb_Ejecutar_Informe(_Fecha_Inicio, _Fecha_Fin)
                Sb_Actualizar_Calendario(Progreso_Cont, Progreso_Porc)
            End If

            Fm.Dispose()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Informe_Consolidado_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_Consolidado.Click

        Try

            If _Informe = Tipo_Informe.Compras Then
                Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
            ElseIf _Informe = Tipo_Informe.Ventas Then
                Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf
            End If

            Dim _F_Inicio As Date = Calendario_Mes.DateSelectionStart.GetValueOrDefault()
            Dim _F_Fin As Date = DateAdd(DateInterval.Day, -1, Calendario_Mes.DateSelectionEnd.GetValueOrDefault())

            If _F_Inicio = Calendario_Mes.DateSelectionEnd.GetValueOrDefault() Then
                _F_Fin = _F_Inicio
            End If


            Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documento_Consolidado(Consulta_sql, _Chk_Deuda_Efectiva)
            Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce
            Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo

            Fm.Sb_Generar_Informe(_Fecha_Inicio, _Fecha_Fin)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Calendario_Mes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Calendario_Mes.DoubleClick
        Call Btn_Informe_Seleccion_Click(Nothing, Nothing)
    End Sub



End Class
