Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Edit_Jornada

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigoob As String
    Dim _Row_Jornada As DataRow
    Dim _Row_Operario As DataRow

    Public Property Row_Jornada As DataRow
        Get
            Return _Row_Jornada
        End Get
        Set(value As DataRow)
            _Row_Jornada = value
        End Set
    End Property

    Public Property Row_Operario As DataRow
        Get
            Return _Row_Operario
        End Get
        Set(value As DataRow)
            _Row_Operario = value
        End Set
    End Property

    Public Sub New(_Codigoob As String, _Dia As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim _Arr_Tipo_Entidad(,) As String = {{1, "Lunes"},
                                              {2, "Martes"},
                                              {3, "Miércoles"},
                                              {4, "Jueves"},
                                              {5, "Viernes"},
                                              {6, "Sábado"},
                                              {7, "Domingo"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Dia)
        Cmb_Dia.SelectedValue = _Dia

        Consulta_sql = "Select * From PMAEOB Where CODIGOOB = '" & _Codigoob & "'"
        _Row_Operario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me._Codigoob = _Codigoob

    End Sub

    Private Sub Frm_Edit_Jornada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Jornada Operario: " & _Row_Operario.Item("CODIGOOB").ToString.Trim & " - " & _Row_Operario.Item("NOMBREOB").ToString.Trim

        Sb_Cargar_Jornada(_Row_Operario.Item("CODIGOOB"), Cmb_Dia.SelectedValue)

        AddHandler Cmb_Dia.SelectedIndexChanged, AddressOf Cmb_Dia_SelectedIndexChanged

    End Sub

    Sub Sb_Cargar_Jornada(_Codigoob As String, _Dia As Integer)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Jornada_X_Operario Where Codigoob = '" & _Codigoob & "' And Dia = " & _Dia
        _Row_Jornada = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Hora_Entrada = _Row_Jornada.Item("Hora_Entrada")
        Dim _Hora_Salida = _Row_Jornada.Item("Hora_Salida")
        Dim _Max_HhExtra = _Row_Jornada.Item("Max_HhExtra")

        Cmb_Dia.SelectedValue = _Dia
        Dtp_Hora_Entrada.Value = _Hora_Entrada
        Dtp_Hora_Salida.Value = _Hora_Salida
        Input_Max_HhExtra.Value = _Max_HhExtra

    End Sub

    Private Sub Cmb_Dia_SelectedIndexChanged(sender As Object, e As EventArgs)
        Sb_Cargar_Jornada(_Codigoob, Cmb_Dia.SelectedValue)
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdc_Jornada_X_Operario Set 
                        Hora_Entrada = '" & Dtp_Hora_Entrada.Value.ToString("hh:mm") & "',
                        Hora_Salida = '" & Dtp_Hora_Salida.Value.ToString("hh:mm") & "',
                        Max_HhExtra = " & Input_Max_HhExtra.Value & " 
                        Where Codigoob = '" & _Codigoob & "' And Dia = " & Cmb_Dia.SelectedValue

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Jornada día " & Cmb_Dia.Text)
        End If

    End Sub

End Class
