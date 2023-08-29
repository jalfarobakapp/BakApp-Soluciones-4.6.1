Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevComponents.DotNetBar

Public Class Frm_Cms_Periodos_Crear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Property Id As Integer
    Public Property Row_Periodo As DataRow
    Public Property Grabar As Boolean

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If CBool(_Id) Then

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Enc Where Id = " & _Id
            _Row_Periodo = _Sql.Fx_Get_DataRow(Consulta_Sql)

        End If

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Cms_Periodos_Crear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Obtener el año actual
        Dim añoActual As Integer = DateTime.Now.Year

        ' Agregar años a la lista del ComboBox
        For i As Integer = añoActual To (añoActual - 10) Step -1
            Cmb_Ano.Items.Add(i)
        Next
        Cmb_Ano.SelectedItem = añoActual

        Dim _Arr_Tipo_Entidad(,) As String = {{"1", "Enero"},
                                             {"2", "Febrero"},
                                             {"3", "Marzo"},
                                             {"4", "Abril"},
                                             {"5", "Mayo"},
                                             {"6", "Junio"},
                                             {"7", "Julio"},
                                             {"8", "Agosto"},
                                             {"9", "Septiembre"},
                                             {"10", "Octubre"},
                                             {"11", "Noviembre"},
                                             {"12", "Diciembre"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Mes)
        Cmb_Mes.SelectedValue = 1

        If Not IsNothing(_Row_Periodo) Then

            Txt_Nombre.Text = _Row_Periodo.Item("Nombre")
            Cmb_Ano.SelectedItem = _Row_Periodo.Item("Ano")
            Cmb_Mes.SelectedValue = _Row_Periodo.Item("Mes")
            Cmb_Ano.Enabled = False
            Cmb_Mes.Enabled = False

            Input_Habiles.Value = _Row_Periodo.Item("Habiles")
            Input_Sabados.Value = _Row_Periodo.Item("Sabados")
            Input_Domingos.Value = _Row_Periodo.Item("Domingos")
            Input_Festivos.Value = _Row_Periodo.Item("Festivos")
            Input_Semanas.Value = _Row_Periodo.Item("Semanas")

        End If

    End Sub

    Private Sub Dtp_FechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaHasta.ValueChanged
        Sb_VerDias()
    End Sub

    Private Sub Dtp_FechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaDesde.ValueChanged
        Sb_VerDias()
    End Sub

    Sub Sb_VerDias()

        Dim _Dias_Habiles = Fx_Cuenta_Dias(Dtp_FechaDesde.Value, Dtp_FechaHasta.Value, Opcion_Dias.Habiles)
        Dim _Dias_Sabado = Fx_Cuenta_Dias(Dtp_FechaDesde.Value, Dtp_FechaHasta.Value, Opcion_Dias.Sabado)
        Dim _Dias_Domingo = Fx_Cuenta_Dias(Dtp_FechaDesde.Value, Dtp_FechaHasta.Value, Opcion_Dias.Domingo)

        Dim _Semanas As Integer = DateDiff(DateInterval.WeekOfYear, Dtp_FechaDesde.Value, Dtp_FechaHasta.Value)

        Input_Habiles.Value = _Dias_Habiles
        Input_Sabados.Value = _Dias_Sabado
        Input_Domingos.Value = _Dias_Domingo
        Input_Semanas.Value = _Semanas

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Periodo = numero_(Cmb_Mes.SelectedValue, 2) & "-" & Cmb_Ano.Text

        If Not CBool(_Id) Then

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Comisiones_Enc", "Periodo = '" & _Periodo & "'")

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Ya existe el periodo: " & _Periodo & " registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Comisiones_Enc (Nombre,Periodo,FechaDesde,FechaHasta," &
                           "Ano,Mes,Habiles,Sabados,Domingos,Festivos,Semanas,Estado) " &
                           "Values ('" & Txt_Nombre.Text.Trim & "','" & _Periodo & "','" & Format(Dtp_FechaDesde.Value, "yyyyMMdd") & "'" &
                           ",'" & Format(Dtp_FechaHasta.Value, "yyyyMMdd") & "'," & Cmb_Ano.Text & "," & Cmb_Mes.SelectedValue &
                           "," & Input_Habiles.Value & "," & Input_Sabados.Value & "," & Input_Domingos.Value &
                           "," & Input_Festivos.Value & "," & Input_Semanas.Value & ",'Abierta')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_Sql, Id)

        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Comisiones_Enc Set" & vbCrLf &
                       "Nombre = '" & Txt_Nombre.Text.Trim & "'" &
                       ",Periodo = '" & _Periodo & "'" &
                       ",FechaDesde = '" & Format(Dtp_FechaDesde.Value, "yyyyMMdd") & "'" &
                       ",FechaHasta = '" & Format(Dtp_FechaHasta.Value, "yyyyMMdd") & "'" &
                       ",Ano = " & Cmb_Ano.Text &
                       ",Mes = " & Cmb_Mes.SelectedValue &
                       ",Habiles = " & Input_Habiles.Value &
                       ",Sabados = " & Input_Sabados.Value &
                       ",Domingos = " & Input_Domingos.Value &
                       ",Festivos = " & Input_Festivos.Value &
                       ",Semanas = " & Input_Semanas.Value & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma eliminar este periodo?", "Eliminar periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Comisiones_Enc Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                MessageBoxEx.Show(Me, "Regristro eliminado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Grabar = True
                Me.Close()
            End If

        End If

    End Sub
End Class
