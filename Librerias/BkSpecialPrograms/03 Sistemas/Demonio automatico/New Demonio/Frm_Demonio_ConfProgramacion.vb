Imports DevComponents.DotNetBar
Public Class Frm_Demonio_ConfProgramacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Id As Integer
    Public Property Id_Programacion As Integer

    Public Property Row_Programacion As DataRow
        Get
            Return _Row_Programacion
        End Get
        Set(value As DataRow)
            _Row_Programacion = value
        End Set
    End Property

    Dim _Row_Programacion As DataRow
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Demonio_ConfProgramacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Where Id = " & _Id
        Row_Programacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Nombre.Text = _Row_Programacion.Item("Nombre")
        Rdb_FrecuDiaria.Checked = _Row_Programacion.Item("FrecuDiaria")
        Rdb_FrecuSemanal.Checked = _Row_Programacion.Item("FrecuSemanal")

        Chk_Lunes.Checked = _Row_Programacion.Item("Lunes")
        Chk_Martes.Checked = _Row_Programacion.Item("Martes")
        Chk_Miercoles.Checked = _Row_Programacion.Item("Miercoles")
        Chk_Jueves.Checked = _Row_Programacion.Item("Jueves")
        Chk_Viernes.Checked = _Row_Programacion.Item("Viernes")
        Chk_Sabado.Checked = _Row_Programacion.Item("Sabado")
        Chk_Domingo.Checked = _Row_Programacion.Item("Domingo")

        Rdb_SucedeUnaVez.Checked = _Row_Programacion.Item("SucedeUnaVez")
        Rdb_SucedeCada.Checked = _Row_Programacion.Item("SucedeCada")

        Input_IntervaloCada.Value = _Row_Programacion.Item("IntervaloCada")
        Cmb_TipoIntervaloCada.SelectedValue = _Row_Programacion.Item("TipoIntervaloCada")

        Dtp_ApartirDeCada.Value = _Row_Programacion.Item("ApartirDeCada")
        Dtp_HoraUnaVez.Value = _Row_Programacion.Item("HoraUnaVez")

        AddHandler Rdb_FrecuDiaria.CheckedChanged, AddressOf Rdb_Frecuencia_CheckedChanged
        AddHandler Rdb_FrecuSemanal.CheckedChanged, AddressOf Rdb_Frecuencia_CheckedChanged

        AddHandler Rdb_SucedeUnaVez.CheckedChanged, AddressOf Chk_Sucede_CheckedChanged
        AddHandler Rdb_SucedeCada.CheckedChanged, AddressOf Chk_Sucede_CheckedChanged

        Rdb_Frecuencia_CheckedChanged(Nothing, Nothing)
        Chk_Sucede_CheckedChanged(Nothing, Nothing)

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
        Dtp_HoraUnaVez.Enabled = Rdb_SucedeCada.Checked

    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        Dim _Nombre As String = Txt_Nombre.Text
        Dim _FrecuDiaria As Integer = Convert.ToInt32(Rdb_FrecuDiaria.Checked)
        Dim _FrecuSemanal As Integer = Convert.ToInt32(Rdb_FrecuSemanal.Checked)
        Dim _Lunes As Integer = Convert.ToInt32(Chk_Lunes.Checked)
        Dim _Martes As Integer = Convert.ToInt32(Chk_Martes.Checked)
        Dim _Miercoles As Integer = Convert.ToInt32(Chk_Miercoles.Checked)
        Dim _Jueves As Integer = Convert.ToInt32(Chk_Jueves.Checked)
        Dim _Viernes As Integer = Convert.ToInt32(Chk_Viernes.Checked)
        Dim _Sabado As Integer = Convert.ToInt32(Chk_Sabado.Checked)
        Dim _Domingo As Integer = Convert.ToInt32(Chk_Domingo.Checked)
        Dim _SucedeUnaVez As Integer = Convert.ToInt32(Rdb_SucedeUnaVez.Checked)
        Dim _HoraUnaVez As String = Format(Dtp_HoraUnaVez.Value, "yyymmdd HH:MM")
        Dim _SucedeCada As Integer = Convert.ToInt32(Rdb_SucedeCada.Checked)
        Dim _IntervaloCada As Integer = Input_IntervaloCada.Value
        Dim _TipoIntervaloCada As String = Cmb_TipoIntervaloCada.SelectedValue
        Dim _ApartirDeCada As String = Format(Dtp_ApartirDeCada.Value, "yyymmdd HH:MM")
        Dim _FinalizaCada As String = Format(Dtp_FinalizaCada.Value, "yyymmdd HH:MM")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Set " & vbCrLf &
                       " Nombre = ''" &
                       ",FrecuDiaria = " & _FrecuDiaria &
                       ",FrecuSemanal = " & _FrecuSemanal &
                       ",Lunes = " & _Lunes &
                       ",Martes = 1" & _Martes &
                       ",Miercoles = 1" & _Miercoles &
                       ",Jueves = 1" & _Jueves &
                       ",Viernes = 1" & _Viernes &
                       ",Sabado = 1" & _Sabado &
                       ",Domingo = 1" & _Domingo &
                       ",SucedeUnaVez = " & _SucedeUnaVez &
                       ",HoraUnaVez = '" & _HoraUnaVez & "'" &
                       ",SucedeCada = " & _SucedeCada &
                       ",IntervaloCada = " & _IntervaloCada &
                       ",TipoIntervaloCada = '" & _TipoIntervaloCada & "'" &
                       ",ApartirDeCada = '" & _ApartirDeCada & "'" &
                       ",FinalizaCada = '" & _FinalizaCada & "'" & vbCrLf &
                       "Where Id = " & _Id
        _Sql.Fx_Ejecutar_Consulta(Consulta_sql)

    End Sub

End Class
