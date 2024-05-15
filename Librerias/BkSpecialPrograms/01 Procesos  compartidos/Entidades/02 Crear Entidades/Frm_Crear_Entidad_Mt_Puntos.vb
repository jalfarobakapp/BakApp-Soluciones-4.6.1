Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_Puntos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Aceptar As Boolean

    Private _CodEntidad As String
    Private _CodSucEntidad As String

    Public Sub New(_CodEntidad As String, _CodSucEntidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodEntidad = _CodEntidad
        Me._CodSucEntidad = _CodSucEntidad

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Puntos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_EmailPuntos

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If Not Fx_Validar_Email(Txt_EmailPuntos.Text.Trim) Then
            MessageBoxEx.Show(Me, "Correo invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_EmailPuntos.Focus()
            Return
        End If

        Dim _CodFuncionario_Enrola As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodFuncionario_Enrola",
                                                                 "CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'")

        If String.IsNullOrWhiteSpace(_CodFuncionario_Enrola) Then
            _CodFuncionario_Enrola = ",FechaInscripPuntos = '" & Format(Dtp_FechaInscripPuntos.Value, "yyyyMMdd") & "'" & vbCrLf &
                                     ",CodFuncionario_Enrola = '" & FUNCIONARIO & "'" & vbCrLf
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                       "JuntaPuntos = " & Convert.ToInt32(Chk_JuntaPuntos.Checked) & vbCrLf &
                       ",EmailPuntos = '" & Txt_EmailPuntos.Text.Trim & "'" & vbCrLf &
                       _CodFuncionario_Enrola &
                       "Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'"
        If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Return
        End If

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Aceptar = True
        Me.Close()

    End Sub

End Class
