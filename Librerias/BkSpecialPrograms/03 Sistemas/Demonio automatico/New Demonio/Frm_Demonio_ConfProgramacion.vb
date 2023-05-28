Imports DevComponents.DotNetBar
Public Class Frm_Demonio_ConfProgramacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Programacion As Cl_NewProgramacion
    Public Property Grabar As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim _Arr_Tido(,) As String = {{"", ""}, {"HH", "Hora"}, {"MM", "Minutos"}, {"SS", "Segundos"}}
        Sb_Llenar_Combos(_Arr_Tido, Cmb_TipoIntervaloCada)
        Cmb_TipoIntervaloCada.SelectedValue = ""

    End Sub

    Private Sub Frm_Demonio_ConfProgramacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IsNothing(Programacion) Then
            Programacion = New Cl_NewProgramacion
            Programacion.FrecuDiaria = True
            Programacion.SucedeUnaVez = True
            Programacion.HoraUnaVez = "01-01-1900 00:00"
        End If

        Txt_Nombre.Text = Programacion.Nombre
        Rdb_FrecuDiaria.Checked = Programacion.FrecuDiaria
        Rdb_FrecuSemanal.Checked = Programacion.FrecuSemanal

        Chk_Lunes.Checked = Programacion.Lunes
        Chk_Martes.Checked = Programacion.Martes
        Chk_Miercoles.Checked = Programacion.Miercoles
        Chk_Jueves.Checked = Programacion.Jueves
        Chk_Viernes.Checked = Programacion.Viernes
        Chk_Sabado.Checked = Programacion.Sabado
        Chk_Domingo.Checked = Programacion.Domingo

        Rdb_SucedeUnaVez.Checked = Programacion.SucedeUnaVez
        Rdb_SucedeCada.Checked = Programacion.SucedeCada

        Input_IntervaloCada.Value = Programacion.IntervaloCada
        Cmb_TipoIntervaloCada.SelectedValue = Programacion.TipoIntervaloCada

        Dtp_ApartirDeCada.Value = Programacion.ApartirDeCada
        Dtp_HoraUnaVez.Value = Programacion.HoraUnaVez

        AddHandler Rdb_FrecuDiaria.CheckedChanged, AddressOf Rdb_Frecuencia_CheckedChanged
        AddHandler Rdb_FrecuSemanal.CheckedChanged, AddressOf Rdb_Frecuencia_CheckedChanged

        AddHandler Rdb_SucedeUnaVez.CheckedChanged, AddressOf Chk_Sucede_CheckedChanged
        AddHandler Rdb_SucedeCada.CheckedChanged, AddressOf Chk_Sucede_CheckedChanged

        Rdb_Frecuencia_CheckedChanged(Nothing, Nothing)
        Chk_Sucede_CheckedChanged(Nothing, Nothing)

        Sb_Crear_Resumen()

        If Rdb_FrecuDiaria.Checked Then
            Grupo_Frecuencia.Location = New System.Drawing.Point(Grupo_Frecuencia.Location.X, 91)
            Grupo_Resumen.Location = New System.Drawing.Point(Grupo_Frecuencia.Location.X, 212)
            Me.Height = 382
            Grupo_Semanal.Visible = Rdb_FrecuSemanal.Checked
        End If

    End Sub

    Private Sub Rdb_Frecuencia_CheckedChanged(sender As Object, e As EventArgs)
        Grupo_Semanal.Enabled = Rdb_FrecuSemanal.Checked
    End Sub

    Private Sub Chk_Sucede_CheckedChanged(sender As Object, e As EventArgs)

        Dtp_HoraUnaVez.Enabled = Rdb_SucedeUnaVez.Checked

        Input_IntervaloCada.Enabled = Rdb_SucedeCada.Checked
        Cmb_TipoIntervaloCada.Enabled = Rdb_SucedeCada.Checked
        LabelX1.Enabled = Rdb_SucedeCada.Checked
        LabelX2.Enabled = Rdb_SucedeCada.Checked
        Dtp_ApartirDeCada.Enabled = Rdb_SucedeCada.Checked
        Dtp_FinalizaCada.Enabled = Rdb_SucedeCada.Checked

    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        Programacion.Nombre = Txt_Nombre.Text
        Programacion.FrecuDiaria = Rdb_FrecuDiaria.Checked
        Programacion.FrecuSemanal = Rdb_FrecuSemanal.Checked

        Programacion.Lunes = Chk_Lunes.Checked
        Programacion.Martes = Chk_Martes.Checked
        Programacion.Miercoles = Chk_Miercoles.Checked
        Programacion.Jueves = Chk_Jueves.Checked
        Programacion.Viernes = Chk_Viernes.Checked
        Programacion.Sabado = Chk_Sabado.Checked
        Programacion.Domingo = Chk_Domingo.Checked

        Programacion.SucedeUnaVez = Rdb_SucedeUnaVez.Checked
        Programacion.SucedeCada = Rdb_SucedeCada.Checked

        Programacion.IntervaloCada = Input_IntervaloCada.Value
        Programacion.TipoIntervaloCada = Cmb_TipoIntervaloCada.SelectedValue

        Programacion.ApartirDeCada = Dtp_ApartirDeCada.Value
        Programacion.HoraUnaVez = Dtp_HoraUnaVez.Value
        Programacion.Resumen = Txt_Resumen.Text.Trim

        Grabar = True

        Me.Close()

    End Sub

    Sub Sb_Crear_Resumen()

        Dim _Sucede As String

        If Rdb_FrecuDiaria.Checked Then
            _Sucede = "Sucede cada día "
        End If

        Dim _DiaAnterior = String.Empty

        If Rdb_FrecuSemanal.Checked Then
            _Sucede = "Sucede el "
            If Chk_Lunes.Checked Then
                _Sucede += "lunes"
                _DiaAnterior = ", "
            End If
            If Chk_Martes.Checked Then
                _Sucede += _DiaAnterior & "martes"
                _DiaAnterior = ", "
            End If
            If Chk_Miercoles.Checked Then
                _Sucede += _DiaAnterior & "miercoles"
                _DiaAnterior = ", "
            End If
            If Chk_Jueves.Checked Then
                _Sucede += _DiaAnterior & "jueves"
                _DiaAnterior = ", "
            End If
            If Chk_Viernes.Checked Then
                _Sucede += _DiaAnterior & "viernes"
                _DiaAnterior = ", "
            End If
            If Chk_Sabado.Checked Then
                _Sucede += _DiaAnterior & "sabádo"
                _DiaAnterior = ", "
            End If
            If Chk_Domingo.Checked Then
                _Sucede += _DiaAnterior & "domingo"
            End If

            _Sucede += " de cada semana "

        End If

        If Rdb_SucedeUnaVez.Checked Then _Sucede += "a las " & Dtp_HoraUnaVez.Value.ToShortTimeString & " "
        If Rdb_SucedeCada.Checked Then _Sucede += "cada " & Input_IntervaloCada.Value & " " & Cmb_TipoIntervaloCada.Text.ToLower & " entre las " & Dtp_ApartirDeCada.Value.ToShortTimeString & " y las " & Dtp_FinalizaCada.Value.ToShortTimeString

        Txt_Resumen.Text = _Sucede

    End Sub

    Private Sub Rdb_FrecuDiaria_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_FrecuDiaria.CheckedChanged
        If Rdb_FrecuDiaria.Checked Then
            Sb_Crear_Resumen()
            Grupo_Frecuencia.Location = New System.Drawing.Point(Grupo_Frecuencia.Location.X, 91)
            Grupo_Resumen.Location = New System.Drawing.Point(Grupo_Frecuencia.Location.X, 212)
            Me.Height = 382
            Grupo_Semanal.Visible = Rdb_FrecuSemanal.Checked
        End If
    End Sub

    Private Sub Rdb_FrecuSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_FrecuSemanal.CheckedChanged
        If Rdb_FrecuSemanal.Checked Then
            Sb_Crear_Resumen()
            Grupo_Frecuencia.Location = New System.Drawing.Point(Grupo_Frecuencia.Location.X, 164)
            Grupo_Resumen.Location = New System.Drawing.Point(Grupo_Frecuencia.Location.X, 285)
            Me.Height = 455
            Grupo_Semanal.Visible = Rdb_FrecuSemanal.Checked
        End If
    End Sub

    Private Sub Chk_Lunes_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Lunes.CheckedChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Chk_Martes_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Martes.CheckedChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Chk_Miercoles_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Miercoles.CheckedChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Chk_Jueves_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Jueves.CheckedChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Chk_Viernes_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Viernes.CheckedChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Chk_Sabado_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Sabado.CheckedChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Chk_Domingo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Domingo.CheckedChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Rdb_SucedeUnaVez_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_SucedeUnaVez.CheckedChanged
        If Rdb_SucedeUnaVez.Checked Then Sb_Crear_Resumen()
    End Sub

    Private Sub Rdb_SucedeCada_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_SucedeCada.CheckedChanged
        If Rdb_SucedeCada.Checked Then Sb_Crear_Resumen()
    End Sub

    Private Sub Input_IntervaloCada_ValueChanged(sender As Object, e As EventArgs) Handles Input_IntervaloCada.ValueChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Cmb_TipoIntervaloCada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_TipoIntervaloCada.SelectedIndexChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Dtp_HoraUnaVez_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_HoraUnaVez.ValueChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Dtp_ApartirDeCada_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_ApartirDeCada.ValueChanged
        Sb_Crear_Resumen()
    End Sub

    Private Sub Dtp_FinalizaCada_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FinalizaCada.ValueChanged
        Sb_Crear_Resumen()
    End Sub

End Class
