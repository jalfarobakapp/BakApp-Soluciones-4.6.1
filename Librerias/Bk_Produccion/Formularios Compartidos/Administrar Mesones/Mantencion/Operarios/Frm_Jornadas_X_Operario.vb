Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Jornadas_X_Operario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigoob As String
    Dim _Row_Operario As DataRow
    Dim _Tbl_Jornada As DataTable

    Public Property Row_Operario As DataRow
        Get
            Return _Row_Operario
        End Get
        Set(value As DataRow)
            _Row_Operario = value
        End Set
    End Property

    Public Property Tbl_Jornada As DataTable
        Get
            Return _Tbl_Jornada
        End Get
        Set(value As DataTable)
            _Tbl_Jornada = value
        End Set
    End Property

    Public Sub New(_Codigoob As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Consulta_sql = "Select CODIGOOB,RUTOB,NOMBREOB,TIFU,RTFU,CIFU,CMFU,DIFU,FOFU,PWFU,PLANO,VAHROB,CODRELCON,KOJORNADA," &
                        "VAHROBHE,INACTIVO,FECINACTIV,EMPRESA
                        From PMAEOB Where CODIGOOB = '" & _Codigoob & "'"
        _Row_Operario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me._Codigoob = _Codigoob

    End Sub

    Private Sub Frm_Jornadas_X_Operario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim fechahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
        'Dim sesion = "INSERT INTO Sesion VALUES ('" + sesionusr() + "', '" + fechahora + "')"
        '_HoraIni = _Hh + (_Mm / 100)

        Consulta_sql = String.Empty

        For i = 1 To 7

            Dim _Activo = 1
            Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_Jornada_X_Operario", "Codigoob = '" & _Codigoob & "' And Dia = " & i)

            If Not _Reg Then

                If i = 7 Then _Activo = 0

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Pdc_Jornada_X_Operario (Codigoob,Dia,Hora_Entrada,Hora_Salida,Max_HhExtra,Activo) Values " & vbCrLf &
                                "('" & _Codigoob & "'," & i & ",'08:00','18:00',0," & _Activo & ")" & vbCrLf

            End If

        Next

        If Not String.IsNullOrEmpty(Consulta_sql) Then
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Consulta_sql = "Select *,
                        Case Dia 
                           When 1 Then 'Lunes'
                           When 2 Then 'Martes'
                           When 3 Then 'Miércoles'
                           When 4 Then 'Jueves'
                           When 5 Then 'Viernes'
                           When 6 Then 'Sábado'
                           When 7 Then 'Domingo'
                           Else '??' 
                           End As 'Nom_Dia',
                        Hora_Entrada As Hora_Entrada_Old,Hora_Salida As Hora_Salida_Old
                        From " & _Global_BaseBk & "Zw_Pdc_Jornada_X_Operario
                        Where Codigoob = '" & _Codigoob & "'"
        _Tbl_Jornada = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Jornada

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Activo").Visible = True
            .Columns("Activo").HeaderText = "Act."
            .Columns("Activo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Activo").Width = 30
            .Columns("Activo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nom_Dia").Visible = True
            .Columns("Nom_Dia").HeaderText = "Día"
            .Columns("Nom_Dia").Width = 80
            .Columns("Nom_Dia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora_Entrada").Visible = True
            .Columns("Hora_Entrada").HeaderText = "Hora entreda"
            .Columns("Hora_Entrada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora_Entrada").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora_Entrada").Width = 90
            .Columns("Hora_Entrada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora_Salida").Visible = True
            .Columns("Hora_Salida").HeaderText = "Hora entreda"
            .Columns("Hora_Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora_Salida").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora_Salida").Width = 90
            .Columns("Hora_Salida").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Max_HhExtra").Visible = True
            .Columns("Max_HhExtra").HeaderText = "Máx. Hh"
            .Columns("Max_HhExtra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Max_HhExtra").Width = 50
            .Columns("Max_HhExtra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Function Fx_Hora(_Hora) As String

        Dim _LaHora = Split(_Hora, ":")

        Dim _Hh As Integer = _LaHora(0)
        Dim _Mm As Integer = _LaHora(1)

        Dim _Horaini = _Hh + (_Mm / 100)

        Return _Horaini

    End Function

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Dia = _Fila.Cells("Dia").Value

        Dim Fm As New Frm_Edit_Jornada(_Codigoob, _Dia)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If e.KeyValue = Keys.Enter Then

            If _Cabeza = "Hora_Entrada" Or _Cabeza = "Hora_Salida" Or _Cabeza = "Max_HhExtra" Then

                Grilla.Columns(_Cabeza).ReadOnly = False
                Grilla.BeginEdit(True)

                e.SuppressKeyPress = False
                e.Handled = True

            End If

        End If

    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Max_HhExtra As Integer = _Fila.Cells("Max_HhExtra").Value
        Dim _Hora_Entrada As DateTime = _Fila.Cells("Hora_Entrada").Value
        Dim _Hora_Salida As DateTime = _Fila.Cells("Hora_Salida").Value
        Dim _Hora_Entrada_Old As DateTime = _Fila.Cells("Hora_Entrada_Old").Value
        Dim _Hora_Salida_Old As DateTime = _Fila.Cells("Hora_Salida_Old").Value

        If _Cabeza = "Hora_Entrada" Then
            If FormatDateTime(_Hora_Entrada, DateFormat.ShortTime) >= FormatDateTime(_Hora_Salida, DateFormat.ShortTime) Then
                MessageBoxEx.Show(Me, "La hora de entrada no puede ser mayor o igual que la hora de salida", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Fila.Cells("Hora_Entrada").Value = _Hora_Entrada_Old
            End If
        End If

        If _Cabeza = "Hora_Salida" Then
            If FormatDateTime(_Hora_Salida, DateFormat.ShortTime) <= FormatDateTime(_Hora_Entrada, DateFormat.ShortTime) Then
                MessageBoxEx.Show(Me, "La hora de salida no puede ser menor o igual que la hora de entrada", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Fila.Cells("Hora_Salida").Value = _Hora_Salida_Old
            End If
        End If

        If _Cabeza = "Max_HhExtra" Then
            If _Max_HhExtra <= 0 Then
                MessageBoxEx.Show(Me, "No puede ser menor que cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Fila.Cells("Max_HhExtra").Value = 0
            End If
        End If

        _Fila.Cells(_Cabeza).ReadOnly = True

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Codigoob = _Fila.Cells("Codigoob").Value
            Dim _Dia = _Fila.Cells("Dia").Value
            Dim _Max_HhExtra As Integer = _Fila.Cells("Max_HhExtra").Value
            Dim _Hora_Entrada As DateTime = _Fila.Cells("Hora_Entrada").Value
            Dim _Hora_Salida As DateTime = _Fila.Cells("Hora_Salida").Value

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Pdc_Jornada_X_Operario Set 
                             Hora_Entrada = '" & _Hora_Entrada.ToString("hh:mm") & "',
                             Hora_Salida = '" & _Hora_Salida.ToString("hh:mm") & "',
                             Max_HhExtra = " & _Max_HhExtra & " 
                             Where Codigoob = '" & _Codigoob & "' And Dia = " & _Dia & vbCrLf

        Next

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class
