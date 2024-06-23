Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_TrabMaq_Sin_Cerrar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Maquina As DataTable
    Dim _Codigoob As String
    Dim _Codmeson As String
    Dim _Fecha As String = FechaDelServidor.ToString("yyyyMMdd")
    Public Property Tbl_Maquina As DataTable
        Get
            Return _Tbl_Maquina
        End Get
        Set(value As DataTable)
            _Tbl_Maquina = value
        End Set
    End Property

    Public Sub New(_Codigoob As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigoob = _Codigoob

        Sb_Formato_Generico_Grilla(Grilla_Maquinas_Meson, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_TrabMaq_Sin_Cerrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Cmb_Mesones()
        Sb_Actualizar_Grilla_Maquinas()

    End Sub

    Sub Sb_Actualizar_Cmb_Mesones()

        Consulta_sql = "Select Distinct Mq.Codmeson As Padre,Isnull(Ms.Nommeson,'???') As Hijo 
                        From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Mq
                        Inner Join POTE ON Idpote=IDPOTE
                        Left Join Zw_Pdc_Mesones Ms On Mq.Codmeson = Ms.Codmeson
                        Where Estado='EMQ' And POTE.ESTADO = 'V' And Fecha_Hora_Inicio < '" & _Fecha & "' And Obrero = '" & _Codigoob & "' "

        Dim _Tbl_Mesones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Convert.ToBoolean(_Tbl_Mesones.Rows.Count) Then

            _Codmeson = _Tbl_Mesones.Rows(0).Item("Padre")

            caract_combo(Cmb_Mesones)
            Cmb_Mesones.DataSource = _Tbl_Mesones
            Cmb_Mesones.SelectedValue = _Codmeson

        End If

    End Sub

    Sub Sb_Actualizar_Grilla_Maquinas()

        Consulta_sql = "Select Cast(0 As Bit) As Chk,
                        (Select Top 1 Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2 Where Z1.Idpotpr = Z2.Idpotpr) As SubOt,
                        *,REFERENCIA As Referencia,(Select Top 1 NOMBREMAQ From PMAQUI where CODMAQ = CodMaq) As Nombremaq," &
                       "(Select Top 1 NOMBREOP From POPER where Operacion = OPERACION) As Nombreop," &
                       "Fecha_Hora_Inicio as Fecha, Fecha_Hora_Inicio as Hora," & vbCrLf &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60) / 24)) As Dias_En_Maquina," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60)%24)) As Horas_En_Maquina," &
                       "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Hora_Inicio, GETDATE())%60) As Minutos_En_Maquina," &
                       "Cast('' As Varchar) As Tiempo_En_Maquina" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z1" & vbCrLf &
                       "Inner Join POTE On Idpote=IDPOTE
                        Where Codmeson = '" & _Codmeson & "' And Obrero = '" & _Codigoob & "' And Estado='EMQ'  And POTE.ESTADO = 'V' And Fecha_Hora_Inicio < '" & _Fecha & "' ORDER BY Fecha_Hora_Inicio ASC"
        _Tbl_Maquina = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Maquinas_Meson

            .DataSource = _Tbl_Maquina

            OcultarEncabezadoGrilla(Grilla_Maquinas_Meson, True)

            Dim _DisplayIndex = 1

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Numot").Width = 50
            .Columns("Numot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubOt").Visible = True
            .Columns("SubOt").HeaderText = "Sub-OT"
            .Columns("SubOt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SubOt").Width = 65
            .Columns("SubOt").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Idpotpr").Visible = True
            .Columns("Idpotpr").HeaderText = "Id"
            .Columns("Idpotpr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Idpotpr").Width = 50
            .Columns("Idpotpr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombremaq").Visible = True
            .Columns("Nombremaq").HeaderText = "Maquina"
            .Columns("Nombremaq").Width = 160
            .Columns("Nombremaq").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Referencia").Visible = True
            .Columns("Referencia").HeaderText = "Referencia / Cliente"
            .Columns("Referencia").Width = 240
            .Columns("Referencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 280
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 80
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 40
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").HeaderText = "Fab."
            .Columns("Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricar").Width = 50
            .Columns("Fabricar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tiempo_En_Maquina").Visible = True
            .Columns("Tiempo_En_Maquina").HeaderText = "Tiempo en Maquina"
            .Columns("Tiempo_En_Maquina").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tiempo_En_Maquina").Width = 100
            .Columns("Tiempo_En_Maquina").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Sb_InsertarBotonenGrilla(Grilla_Maquinas_Meson, "Btn_Accion", "Cerrar", "Gest.", 0, _Tipo_Boton.Boton)

        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Maquinas_Meson, "Fecha_Hora_Inicio", "Tiempo_En_Maquina")

    End Sub

    Sub Sb_Tiempo_En_Mesones_y_Maquinas(Grilla As DataGridView, _Campo_Fecha As String, _Campo_Tiempo As String)

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Fecha_Hora_Inicio = _Row.Cells(_Campo_Fecha).Value
            Dim _Estado_Pote = _Row.Cells("ESTADO").Value

            If _Estado_Pote = "S" Then

                _Row.Cells(_Campo_Tiempo).Value = "EN PAUSA..."

            Else

                Dim ts As TimeSpan = Fx_Fecha_y_Hora_del_Servidor.Subtract(_Fecha_Hora_Inicio)

                Dim _Dias_Espera As Int32 = ts.Days
                Dim _Horas_Espera As Int32 = ts.Hours
                Dim _Minutos_Espera As Int32 = ts.Minutes
                Dim _Segundos_Espera As Int32 = ts.Seconds

                Dim _Dias = String.Empty
                Dim _Horas = String.Empty
                Dim _Minutos = String.Empty

                If _Dias_Espera > 0 Then

                    If _Dias_Espera = 1 Then
                        _Dias = "D "
                    Else
                        _Dias = "D "
                    End If

                    _Dias = _Dias_Espera & _Dias ' & "."

                End If

                If _Horas_Espera > 0 Then
                    _Horas = _Horas_Espera & "H "
                End If

                If _Minutos_Espera > 0 Then
                    _Minutos = _Minutos_Espera & "M "
                End If

                Dim _Tiempo_En_Maquina As String

                _Tiempo_En_Maquina = _Dias & _Horas & _Minutos

                If String.IsNullOrEmpty(_Tiempo_En_Maquina) Then _Tiempo_En_Maquina = " - 1 Min"

                _Row.Cells(_Campo_Tiempo).Value = _Tiempo_En_Maquina

            End If

        Next

    End Sub

    Private Sub Grilla_Maquinas_Meson_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maquinas_Meson.CellClick

        Dim _Cabeza = Grilla_Maquinas_Meson.Columns(Grilla_Maquinas_Meson.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maquinas_Meson.Rows(Grilla_Maquinas_Meson.CurrentRow.Index)

        If _Cabeza = "Btn_Accion" Then

            ShowContextMenu(Menu_Contextual_Maquina)

            'Dim Fm As New Frm_TrabMaq_Opciones_Cierre
            'Fm.ShowDialog(Me)

            'If Fm.Hacer_Gestion Then

            '    Select Case Fm.Accion_Gestion
            '        Case Frm_TrabMaq_Opciones_Cierre.Enum_Accion.Trabajo_Terminado
            '            Sb_Trabajo_Terminado(_Fila)
            '        Case Frm_TrabMaq_Opciones_Cierre.Enum_Accion.Dejar_Pendiente
            '            Fx_Ingreso_Fabricacion_Porcentaje(_Fila, False)
            '        Case Frm_TrabMaq_Opciones_Cierre.Enum_Accion.Continuar
            '            Fx_Ingreso_Fabricacion_Porcentaje(_Fila, True)
            '    End Select

            'End If

            'Fm.Dispose()

        End If

        'Sb_Actualizar_Cmb_Mesones()
        'Sb_Actualizar_Grilla_Maquinas()

    End Sub

    Sub Sb_Trabajo_Terminado(_Fila As DataGridViewRow)

        Dim _Aceptar As Boolean

        Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
        Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
        Dim _Codmeson As String = _Fila.Cells("Codmeson").Value.ToString.Trim

        Dim _Fecha_Ingreso As Date = _Fila.Cells("Fecha_Hora_Inicio").Value
        Dim _Fecha_Cierre As Date
        Dim _Hora_Ingreso As DateTime = _Fila.Cells("Fecha_Hora_Inicio").Value
        Dim _Hora_Cierre As DateTime

        Dim _Dias As Integer = DateDiff(DateInterval.Day, _Fecha_Ingreso, Date.Now)

        If _Dias >= 2 Then

            Dim Chk_Terminado_Mismo_Dia As New Command
            Chk_Terminado_Mismo_Dia.Checked = True
            Chk_Terminado_Mismo_Dia.Name = "Chk_Terminado_Mismo_Dia"
            Chk_Terminado_Mismo_Dia.Text = "El trabajo se termino el mismo día"

            Dim Chk_Termino_Otro_Dia As New Command
            Chk_Termino_Otro_Dia.Checked = False
            Chk_Termino_Otro_Dia.Name = "Chk_Termino_Otro_Dia"
            Chk_Termino_Otro_Dia.Text = "El trabajo se termino, pero otro día." & vbCrLf & " -se necesito más de un día para realizarlo"

            Dim _Opciones() As Command = {Chk_Terminado_Mismo_Dia, Chk_Termino_Otro_Dia}

            Dim _Info As New TaskDialogInfo("Producto con mas de un día en la maquina",
                      eTaskDialogIcon.Users,
                      "ya han pasado " & _Dias & " días desde el ingreso de ese producto a la maquina",
                      "Confirme su opción",
                      eTaskDialogButton.Ok + eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

            If _Resultado <> eTaskDialogResult.Ok Then
                Return
            End If

            If Chk_Termino_Otro_Dia.Checked Then

                Fx_Ingreso_Fabricacion_Porcentaje(_Fila, True, True)
                Return

            End If

        End If

        Dim Fm_C As New Frm_DFA_Cierre_Atrasado

        Fm_C.Pro_Fecha_Ingreso = _Fecha_Ingreso
        Fm_C.Pro_Hora_Ingreso = _Hora_Ingreso
        Fm_C.Pro_Fecha_Cierre = _Fecha_Ingreso
        Fm_C.Dtp_Fecha_Ingreso.Enabled = False
        Fm_C.Dtp_Hora_Ingreso.Enabled = False

        Fm_C.ShowDialog(Me)

        _Aceptar = Fm_C.Pro_Aceptar
        _Fecha_Ingreso = Fm_C.Pro_Fecha_Ingreso
        _Fecha_Cierre = Fm_C.Pro_Fecha_Cierre
        _Hora_Ingreso = Fm_C.Pro_Hora_Ingreso
        _Hora_Cierre = Fm_C.Pro_Hora_Cierre

        Fm_C.Dispose()

        If Not _Aceptar Then
            Return
        End If

        Dim _HHi = FormatDateTime(_Hora_Ingreso, DateFormat.ShortTime)
        Dim _HHc = FormatDateTime(_Hora_Cierre, DateFormat.ShortTime)

        ' SE DEBE ACTUALIZAR LA FECHA DE TERMINO DEL TRABAJO.

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set 
                        Fecha_Hora_Inicio = '" & Format(_Fecha_Ingreso, "yyyyMMdd") & " " & _HHi & "' 
                        Where IdMaquina = " & _IdMaquina
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Cast(0 As Bit) As Chk,
                                   (Select Top 1 Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2 Where Z1.Idpotpr = Z2.Idpotpr) As SubOt,
                                    *,REFERENCIA As Referencia,(Select Top 1 NOMBREMAQ From PMAQUI where CODMAQ = CodMaq) As Nombremaq," &
                        "(Select Top 1 NOMBREOP From POPER where Operacion = OPERACION) As Nombreop," &
                        "Fecha_Hora_Inicio as Fecha, Fecha_Hora_Inicio as Hora," & vbCrLf &
                        "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60) / 24)) As Dias_En_Maquina," &
                        "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60)%24)) As Horas_En_Maquina," &
                        "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Hora_Inicio, GETDATE())%60) As Minutos_En_Maquina," &
                        "Cast('' As Varchar) As Tiempo_En_Maquina" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z1" & vbCrLf &
                        "INNER JOIN POTE ON Idpote=IDPOTE" & vbCrLf &
                        "Where IdMaquina = " & _IdMaquina

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Fx_Producto_Fabricado4(_Row, _Fecha_Cierre, _Hora_Cierre, False) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Ingreso DFA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Sb_Actualizar_Cmb_Mesones()
        Sb_Actualizar_Grilla_Maquinas()

    End Sub

    Private Function Fx_Ingreso_Fabricacion_Porcentaje(_Fila As DataGridViewRow, _Dejar_En_Meson As Boolean, _Otro_Dia As Boolean) As Boolean

        Try

            Dim _Numot As String = _Fila.Cells("Numot").Value
            Dim _Subot As String = _Fila.Cells("Subot").Value
            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

            Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
            Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
            Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
            Dim _Idpotl As Integer = _Fila.Cells("Idpotl").Value
            Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
            Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
            Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value
            Dim _Fabricando As Double = 0

            Dim _Fecha_Ingreso_Reproceso As Date
            Dim _Hora_Ingreso_Reproceso As Date

            Dim _Fecha_Ingreso As Date = _Fila.Cells("Fecha_Hora_Inicio").Value
            Dim _Fecha_Cierre As Date
            Dim _Hora_Ingreso As DateTime = _Fila.Cells("Fecha_Hora_Inicio").Value
            Dim _Hora_Cierre As DateTime

            Dim _Aceptar As Boolean

            MessageBoxEx.Show(Me, "Debe ingresar la hora de finilización del trabajo para la fecha: " & FormatDateTime(_Fecha_Ingreso, DateFormat.ShortDate), "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim Fm_Ca As New Frm_DFA_Cierre_Atrasado

            Fm_Ca.Pro_Fecha_Ingreso = _Fecha_Ingreso
            Fm_Ca.Pro_Hora_Ingreso = _Hora_Ingreso
            Fm_Ca.Pro_Fecha_Cierre = _Fecha_Ingreso
            Fm_Ca.Dtp_Fecha_Ingreso.Enabled = False
            Fm_Ca.Dtp_Hora_Ingreso.Enabled = False

            Fm_Ca.ShowDialog(Me)

            _Aceptar = Fm_Ca.Pro_Aceptar
            _Fecha_Ingreso = Fm_Ca.Pro_Fecha_Ingreso
            _Fecha_Cierre = Fm_Ca.Pro_Fecha_Cierre
            _Hora_Ingreso = Fm_Ca.Pro_Hora_Ingreso
            _Hora_Cierre = Fm_Ca.Pro_Hora_Cierre

            Fm_Ca.Dispose()

            If Not _Aceptar Then
                Return False
            End If

            If _Dejar_En_Meson Then

                Dim _Fecha_Ingreso_Nuevo As Date = FechaDelServidor()
                Dim _Hora_Ingreso_Nuevo As DateTime

                If _Otro_Dia Then
                    MessageBoxEx.Show(Me, "A continuación debera ingresar la fecha y la hora de inicio del trabajo que dejo pendiente",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBoxEx.Show(Me, "A continuación debera ingresar la hora de inicio del trabajo para el día de hoy",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Dim Fm_C As New Frm_DFA_Cierre_Atrasado

                Fm_C.Pro_Fecha_Ingreso = _Fecha_Ingreso
                Fm_C.Pro_Hora_Ingreso = Nothing
                Fm_C.Dtp_Fecha_Ingreso.Enabled = True
                Fm_C.Dtp_Hora_Ingreso.Enabled = True
                Fm_C.Dtp_Fecha_Ingreso.Enabled = _Otro_Dia
                Fm_C.Dtp_Fecha_Termino.Enabled = False
                Fm_C.Dtp_Fecha_Termino.Value = Nothing
                Fm_C.Dtp_Hora_Termino.Enabled = False
                Fm_C.Dtp_Hora_Termino.Value = Nothing
                Fm_C.No_Validar_Hora_Ingreso = True
                Fm_C.Validar_Fecha_Ingreso_Minima = True
                Fm_C.Fecha_Ingreso_Minima = _Fecha_Ingreso
                Fm_C.Validar_Fecha_Ingreso_Maxima = True
                Fm_C.Fecha_Ingreso_Maxima = FechaDelServidor()
                If _Otro_Dia Then Fm_C.Text = "Indique el día y la hora en que siguió con este trabajo"
                Fm_C.ShowDialog(Me)

                _Aceptar = Fm_C.Pro_Aceptar
                _Fecha_Ingreso_Reproceso = Fm_C.Pro_Fecha_Ingreso
                _Hora_Ingreso_Reproceso = Fm_C.Pro_Hora_Ingreso

                Fm_C.Dispose()

                If Not _Aceptar Then

                    MessageBoxEx.Show(Me, "Debe ingresar la hora de inicio del trabajo para el " & FormatDateTime(_Fecha_Ingreso, DateFormat.ShortDate),
                                      "Validación",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Return False

                End If

            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
            Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Saldo_Fabricar As Double = _Row_Meson.Item("Saldo_Fabricar")
            Dim _Porc_SvsF As Double = Math.Round(_Fabricar / _Saldo_Fabricar, 2)

            Dim _Porc_Avance_Saldo_Fab As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                                             "Porc_Avance_Saldo_Fab", "Idpotpr = " & _Idpotpr)
            Dim _Porc_Avance_MQ As Double
            Dim _Grabar As Boolean
            Dim _Enviar_Al_Meson_Siguiente As Boolean

            If _Otro_Dia Then
                _Porc_Avance_Saldo_Fab = 0.05
                _Porc_Avance_MQ = 0.05
                _Grabar = True
            Else

                Dim Fm As New Frm_Meson_Operario_Avance(_Porc_Avance_Saldo_Fab, _Codigo, _Descripcion, _Numot, _Subot)
                Fm.ShowDialog(Me)
                _Grabar = Fm.Pro_Grabar
                _Porc_Avance_Saldo_Fab = Fm.Pro_Porc_Avance
                _Porc_Avance_MQ = Fm.Pro_Porc_Avance_MQ
                Fm.Dispose()

            End If

            If _Dejar_En_Meson And _Porc_Avance_Saldo_Fab = 1 Then
                MessageBoxEx.Show(Me, "No puede ingresar un 100% de la fabricación, ya que el producto seguirá quedando en la maquina",
                                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            If _Grabar Then

                Dim _HHi = FormatDateTime(_Hora_Ingreso, DateFormat.ShortTime)
                Dim _HHc = FormatDateTime(_Hora_Cierre, DateFormat.ShortTime)

                ' SE DEBE ACTUALIZAR LA FECHA DE TERMINO DEL TRABAJO.

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set 
                        Fecha_Hora_Termino = '" & Format(_Fecha_Cierre, "yyyyMMdd") & " " & _HHc & "' 
                        Where IdMaquina = " & _IdMaquina
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Dim _Estado As String
                Dim _Fabricado = _Fabricar

                If _Porc_Avance_Saldo_Fab = 1 Then

                    If _Porc_SvsF = 1 Then
                        _Estado = "TE" 'Terminado, fabricado 100%
                    Else
                        _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF
                        _Estado = "PD"
                    End If

                    _Enviar_Al_Meson_Siguiente = True

                Else

                    _Estado = "PD" 'Falta por fabricar
                    _Fabricado = 0
                    _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF

                End If

                Dim _Observacion As String = String.Empty
                Dim _Input_box As Boolean = InputBox_Bk(Me, "INGRESE OBSERVACION", "OBSERVACION",
                                                                _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)

                Dim _Cl_Fabricar As New Class_Fabricar

                If _Enviar_Al_Meson_Siguiente Then

                    ' ACA DEBO COLOCAR LA OPCION DE GRABAR ALERTAS...!!!!!

                    Consulta_sql = "Select *,Cast('' As Varchar(5)) As Subot From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
                    Dim _FilaMaquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _FilaMaquina.Item("Subot") = _Subot
                    _FilaMaquina.Item("Fabricado") = _Fabricado
                    _FilaMaquina.Item("Observacion") = _Observacion

                    _Grabar = _Cl_Fabricar.Fx_Producto_Fabricado(Me, _FilaMaquina, True)

                Else

                    _Fila.Cells("Fabricado").Value = _Fabricado
                    _Fila.Cells("Estado").Value = _Estado
                    _Fila.Cells("Observacion").Value = _Observacion
                    _Fila.Cells("Porc_Avance_Saldo_Fab").Value = _Porc_Avance_Saldo_Fab

                    _Grabar = _Cl_Fabricar.Fx_Agregar_Fabricacion_Con_Porcentaje_Pistoleo(_Codigoob, _Fila, _Porc_Avance_MQ, _Porc_Avance_Saldo_Fab)

                End If

                If _Grabar Then

                    Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

                    If _Dejar_En_Meson Then

                        Sb_Volver_a_dejar_en_meson(_IdMeson, _Fabricar, _Fecha_Ingreso_Reproceso, _Hora_Ingreso_Reproceso)

                    End If

                End If

            End If

            Return _Grabar

        Catch ex As Exception

        Finally
            Sb_Actualizar_Cmb_Mesones()
            Sb_Actualizar_Grilla_Maquinas()
        End Try

    End Function

    Function Fx_Producto_Fabricado3(_Fila As DataGridViewRow, _Fabricar_Todo As Boolean)

        Dim _Numot As String = _Fila.Cells("Numot").Value
        Dim _Subot As String = _Fila.Cells("Subot").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
        Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
        Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
        Dim _Idpotl As Integer = _Fila.Cells("Idpotl").Value
        Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
        Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
        Dim _Operacion As String = _Fila.Cells("Operacion").Value

        Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value
        Dim _Fabricado As Double = _Fila.Cells("Fabricado").Value
        Dim _Saldo_Fabricar As Double = _Fabricar - _Fabricado
        Dim _Grabar As Boolean

        If _Fabricar_Todo Then

            _Fabricado = _Saldo_Fabricar
            _Grabar = True

        Else

            Dim Fm As New Frm_Meson_Operario_Cantidad_Fabricada(_Saldo_Fabricar, _Codigo, _Descripcion, _Numot, _Subot)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar
            _Fabricado += Fm.Pro_Fabricados
            Fm.Dispose()

        End If


        If _Grabar Then

            Dim _Texto_Centro = "INGRESE OBSERVACION" & vbCrLf & vbCrLf &
                                "OT: " & _Numot & " (" & _Subot & ")" & vbCrLf & vbCrLf &
                                "Código: " & _Codigo & vbCrLf &
                                _Descripcion

            Dim _Observacion As String = String.Empty
            Dim _Input_box As Boolean = InputBox_Bk(Me, _Texto_Centro, "OBSERVACION", _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)

            Consulta_sql = "Select *,Cast('' As Varchar(5)) As Subot From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
            Dim _FilaMaquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _FilaMaquina.Item("Subot") = _Subot
            _FilaMaquina.Item("Fabricado") = _Fabricado
            _FilaMaquina.Item("Observacion") = NuloPorNro(_Observacion, "")

            Dim _Cl_Fabricar As New Class_Fabricar

            _Grabar = _Cl_Fabricar.Fx_Producto_Fabricado(Me, _FilaMaquina, True)

            If _Grabar Then

                Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

            End If

        End If

        Return _Grabar

    End Function

    Function Fx_Producto_Fabricado4(_Fila As DataRow,
                                    _Fecha_Termino As Date,
                                    _Hora_Termino As DateTime,
                                    _Fabricar_Todo As Boolean)

        Dim _Numot As String = _Fila.Item("Numot")
        Dim _Subot As String = _Fila.Item("Subot")
        Dim _Codigo As String = _Fila.Item("Codigo")
        Dim _Descripcion As String = _Fila.Item("Descripcion")

        Dim _IdMaquina As Integer = _Fila.Item("IdMaquina")
        Dim _IdMeson As Integer = _Fila.Item("IdMeson")
        Dim _Idpote As Integer = _Fila.Item("Idpote")
        Dim _Idpotl As Integer = _Fila.Item("Idpotl")
        Dim _Idpotpr As Integer = _Fila.Item("Idpotpr")
        Dim _Codmeson As String = _Fila.Item("Codmeson")
        Dim _Operacion As String = _Fila.Item("Operacion")

        Dim _Fabricar As Double = _Fila.Item("Fabricar")
        Dim _Fabricado As Double = _Fila.Item("Fabricado")
        Dim _Saldo_Fabricar As Double = _Fabricar - _Fabricado
        Dim _Grabar As Boolean

        If _Fabricar_Todo Then

            _Fabricado = _Saldo_Fabricar
            _Grabar = True

        Else

            Dim Fm As New Frm_Meson_Operario_Cantidad_Fabricada(_Saldo_Fabricar, _Codigo, _Descripcion, _Numot, _Subot)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar
            _Fabricado += Fm.Pro_Fabricados
            Fm.Dispose()

        End If


        If _Grabar Then

            Dim _Texto_Centro = "INGRESE OBSERVACION" & vbCrLf & vbCrLf &
                                "OT: " & _Numot & " (" & _Subot & ")" & vbCrLf & vbCrLf &
                                "Código: " & _Codigo & vbCrLf &
                                _Descripcion

            Dim _Observacion As String = String.Empty
            Dim _Input_box As Boolean = InputBox_Bk(Me, _Texto_Centro, "OBSERVACION", _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)


            Dim _HHc = FormatDateTime(_Hora_Termino, DateFormat.ShortTime)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                           "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
                           ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
                           ",Porc_Avance_Saldo_Fab = 1" & vbCrLf &
                           ",Fecha_Hora_Termino = '" & Format(_Fecha_Termino, "yyyyMMdd") & " " & _HHc & "'" &
                           ",Observacion = '" & _Observacion & "'" & vbCrLf &
                           "Where IdMaquina = " & _IdMaquina
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Select *,Cast('' As Varchar(5)) As Subot From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
            Dim _FilaMaquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _FilaMaquina.Item("Subot") = _Subot


            Dim _Cl_Fabricar As New Class_Fabricar

            _Grabar = _Cl_Fabricar.Fx_Producto_Fabricado(Me, _FilaMaquina, True)

            If _Grabar Then

                Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

            End If

        End If

        Return _Grabar

    End Function

    Sub Sb_Crear_DFA(_Idpote As Integer, _Idpotl As Integer, _IdMaquina As Integer)

        Dim _Idpdatfae As Integer

        Dim _DFA As New Clas_Crear_DFA_Desde_Meson(_Idpote, _Idpotl)
        _DFA.Sb_Crear_Dfa()
        _Idpdatfae = _DFA.Fx_Crear_Documento()

        If CBool(_Idpdatfae) Then

            Dim _Tbl_Fabricacion As DataTable = _DFA.Pro_Tbl_Fabricacion

            Dim _Id_Maquinas As String = Generar_Filtro_IN(_Tbl_Fabricacion, "", "IdMaquina", False, False, "")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set Idpdatfae = " & _Idpdatfae & "
                            Where IdMaquina In " & _Id_Maquinas
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Sub Sb_Volver_a_dejar_en_meson(_IdMeson As Integer, _A_Fabricar As Integer, _Fecha_Ingreso_Reproceso As Date, _Hora_Ingreso_Reproceso As Date)

        Dim _Fila As DataGridViewRow = Grilla_Maquinas_Meson.Rows(Grilla_Maquinas_Meson.CurrentRow.Index)
        Dim _CodMaq = _Fila.Cells("CodMaq").Value
        Dim _Operacion = _Fila.Cells("Operacion").Value

        Consulta_sql = "Select *,'" & _CodMaq & "' As CODMAQOT" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
        Dim _RowMeson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cl_Fabricar As New Class_Fabricar

        Dim _IdMaquina = _Cl_Fabricar.Fx_Agregar_Producto_a_la_Maquina(_Codigoob, _RowMeson, _A_Fabricar)

        Dim _FFi As String = Format(_Fecha_Ingreso_Reproceso, "yyyyMMdd")
        Dim _HHi As String = FormatDateTime(_Hora_Ingreso_Reproceso, DateFormat.ShortTime)

        ' SE DEBE ACTUALIZAR LA FECHA DE TERMINO DEL TRABAJO.

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set 
                        Fecha_Hora_Inicio = '" & _FFi & " " & _HHi & "' 
                        Where IdMaquina = " & _IdMaquina
        _Sql.Ej_consulta_IDU(Consulta_sql)

        MessageBoxEx.Show(Me, "La herramienta volvió a la maquina el día " & FormatDateTime(_Fecha_Ingreso_Reproceso, DateFormat.ShortDate) & ", Hora: " & _HHi, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Sb_Actualizar_Cmb_Mesones()
        Sb_Actualizar_Grilla_Maquinas()

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click

        Sb_Actualizar_Cmb_Mesones()
        Sb_Actualizar_Grilla_Maquinas()

    End Sub

    Private Sub Btn_Poducto_Fabricado_Click(sender As Object, e As EventArgs) Handles Btn_Trabajo_Terminado.Click
        Dim _Fila As DataGridViewRow = Grilla_Maquinas_Meson.Rows(Grilla_Maquinas_Meson.CurrentRow.Index)
        Sb_Trabajo_Terminado(_Fila)
        Sb_Revisar_Trabajos_Prendientes()
    End Sub

    Private Sub Btn_Dejar_Pendiente_Avence_Porcentaje_Click(sender As Object, e As EventArgs) Handles Btn_Dejar_Pendiente_Avence_Porcentaje.Click

        Try

            Dim _Fila As DataGridViewRow = Grilla_Maquinas_Meson.Rows(Grilla_Maquinas_Meson.CurrentRow.Index)
            Dim _Fecha_Ingreso As Date = _Fila.Cells("Fecha_Hora_Inicio").Value
            Dim _Dias As Integer = DateDiff(DateInterval.Day, _Fecha_Ingreso, Date.Now)

            If _Dias >= 2 Then

                Dim Chk_Dejo_Solo_Un_Dia As New Command
                Chk_Dejo_Solo_Un_Dia.Checked = True
                Chk_Dejo_Solo_Un_Dia.Name = "Chk_Dejo_Solo_Un_Dia"
                Chk_Dejo_Solo_Un_Dia.Text = "El trabajo solo se realizo ese día y se deja % de avance"

                Dim Chk_Dejo_Mas_De_Un_Dia As New Command
                Chk_Dejo_Mas_De_Un_Dia.Checked = False
                Chk_Dejo_Mas_De_Un_Dia.Name = "Chk_Dejo_Mas_De_Un_Dia"
                Chk_Dejo_Mas_De_Un_Dia.Text = "El trabajo se dejo en más de un día." & vbCrLf & " - otro día se avanzo, pero tambien en %"

                Dim _Opciones() As Command = {Chk_Dejo_Solo_Un_Dia, Chk_Dejo_Mas_De_Un_Dia}

                Dim _Info As New TaskDialogInfo("Producto con más de un día en la maquina",
                          eTaskDialogIcon.Users,
                          "ya han pasado " & _Dias & " días desde el ingreso de ese producto a la maquina",
                          "Confirme su opción",
                          eTaskDialogButton.Ok + eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

                Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                If _Resultado <> eTaskDialogResult.Ok Then
                    Return
                End If

                If Chk_Dejo_Solo_Un_Dia.Checked Then
                    Fx_Ingreso_Fabricacion_Porcentaje(_Fila, False, False)
                End If

                If Chk_Dejo_Mas_De_Un_Dia.Checked Then
                    Fx_Ingreso_Fabricacion_Porcentaje(_Fila, True, True)
                End If

                Return

            End If

            Fx_Ingreso_Fabricacion_Porcentaje(_Fila, False, False)

        Catch ex As Exception
        Finally
            Sb_Revisar_Trabajos_Prendientes()
        End Try

    End Sub

    Private Sub Btn_Continuar_Trabajo_Click(sender As Object, e As EventArgs) Handles Btn_Continuar_Trabajo.Click

        Try

            Dim _Fila As DataGridViewRow = Grilla_Maquinas_Meson.Rows(Grilla_Maquinas_Meson.CurrentRow.Index)
            Dim _Fecha_Ingreso As Date = _Fila.Cells("Fecha_Hora_Inicio").Value
            Dim _Dias As Integer = DateDiff(DateInterval.Day, _Fecha_Ingreso, Date.Now)

            If _Dias >= 2 Then

                Dim Chk_Dejo_Solo_Un_Dia As New Command
                Chk_Dejo_Solo_Un_Dia.Checked = True
                Chk_Dejo_Solo_Un_Dia.Name = "Chk_Dejo_Solo_Un_Dia"
                Chk_Dejo_Solo_Un_Dia.Text = "El trabajo se dejo solo ese día y hoy tambien se deja"

                Dim Chk_Dejo_Mas_De_Un_Dia As New Command
                Chk_Dejo_Mas_De_Un_Dia.Checked = False
                Chk_Dejo_Mas_De_Un_Dia.Name = "Chk_Dejo_Mas_De_Un_Dia"
                Chk_Dejo_Mas_De_Un_Dia.Text = "El se dejo en más de un día." & vbCrLf & " - se necesito más de un día para realizarlo"

                Dim _Opciones() As Command = {Chk_Dejo_Solo_Un_Dia, Chk_Dejo_Mas_De_Un_Dia}

                Dim _Info As New TaskDialogInfo("Producto con más de un día en la maquina",
                          eTaskDialogIcon.Users,
                          "ya han pasado " & _Dias & " días desde el ingreso de ese producto a la maquina",
                          "Confirme su opción",
                          eTaskDialogButton.Ok + eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

                Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                If _Resultado <> eTaskDialogResult.Ok Then
                    Return
                End If

                If Chk_Dejo_Solo_Un_Dia.Checked Then
                    Fx_Ingreso_Fabricacion_Porcentaje(_Fila, True, False)
                End If

                If Chk_Dejo_Mas_De_Un_Dia.Checked Then
                    Fx_Ingreso_Fabricacion_Porcentaje(_Fila, True, True)
                End If

                Return

            End If

            Fx_Ingreso_Fabricacion_Porcentaje(_Fila, True, True)

        Catch ex As Exception
        Finally
            Sb_Revisar_Trabajos_Prendientes()
        End Try

    End Sub

    Sub Sb_Revisar_Trabajos_Prendientes()

        Dim _Clas_Alerta_Trab_Sin_Cerrar As New Clas_Alerta_Trab_Sin_Cerrar
        Dim _Trabajos_Pendientes = _Clas_Alerta_Trab_Sin_Cerrar.Fx_Tiene_Trabajos_Abiertos(_Codigoob)
        If Not CBool(_Trabajos_Pendientes) Then
            Me.Close()
        End If

    End Sub

End Class
