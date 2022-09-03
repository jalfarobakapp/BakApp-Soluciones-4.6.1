Imports Funciones_BakApp
Imports BKpost


Public Class Frm_Login


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Text = "BakApp, versión " & currentversion


        'SELECT VAMO FROM MAEMO WITH (NOLOCK)  WHERE KOMO = 'US$' AND FEMO = {d '2014-02-20'} ORDER BY IDMAEMO 
    End Sub

    Private Sub TxtxPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtxPassword.TextChanged
        If Trim(TxtxPassword.Text) = "" Then Return
        Txtxusuario.Text = trae_dato(tb, cn1, "NOKOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(TxtxPassword.Text) & "'")
        If Txtxusuario.Text <> "" Then
            BtnxAceptar.Enabled = True
        Else
            BtnxAceptar.Enabled = False
        End If
    End Sub

    Private Sub BtnxAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxAceptar.Click
        Aceptar()
    End Sub

    Sub Aceptar()
        If autentificar_usuario(TxtxPassword.Text, Txtxusuario) = True Then
            Nombre_funcionario_activo = Txtxusuario.Text
            sesion = True



            Dim Frm_Modalidad As New Frm_Modalidad_Mt
            Frm_Modalidad.ShowDialog(Me)

            'Frm_MenuPrincipal.TimpoEsperaNotificacion.Enabled = True
            AccesoAdministrador = False
            RevisarSiEsPost()



            Me.Close()
        Else
            MsgBox("Clave desconocida", MsgBoxStyle.Critical, "Ingreso Ms_Fichas")
            sesion = False
        End If
    End Sub


    

    Private Function autentificar_usuario(ByVal password_us As String, _
                                          ByVal Txtusuario As TextBox) As Boolean
        'Dim ussuario As String = trae_dato(tb, cn1, "NOMBRE", "W_USUARIOS", "CLAVE = '" & _
        '          Encripta_md5(password_us) & "'")

        If Txtusuario.Text <> "" Then
            'Txtusuario.Text = ussuario

            FUNCIONARIO = trae_dato(tb, cn1, "KOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(TxtxPassword.Text) & "'")
            Nombre_funcionario_activo = trae_dato(tb, cn1, "NOKOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(TxtxPassword.Text) & "'")
            Dim inactivo As Boolean = trae_dato(tb, cn1, "INACTIVO", "TABFU", "PWFU = '" & _
                  TraeClaveRD(TxtxPassword.Text) & "'")

            If inactivo = True Then
                MsgBox("Usuario Inactivo en Sistema", MsgBoxStyle.Critical, "Auntenticación de usuario")
                Return False

            End If

            TablaDePasoBodegas = "ZZW_TblPasoFiltroBodegas" & FUNCIONARIO
            TablaDePasoProEstrellas = "ZZW_TblPasoFiltroProEstrellas" & FUNCIONARIO

            'BkCompras.EliminarTablasDePaso()

            Return True
        Else
            Return False
        End If

    End Function


    Sub RevisarSiEsPost()

        Dim EsPost As Boolean = trae_datoAccess(tb, "Es_Post", "Tmp_BkPostValidate")

        If EsPost = True Then
            Dim Frm_FormularioVentas As New Frm_01Ventas
            'Frm_FormularioVentas.WindowState = FormWindowState.Maximized
            Frm_FormularioVentas.ShowDialog(Me)
        End If

    End Sub

  
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If AccesoAdministrador = False Then
            If sesion = False Then
                End
            Else
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub TxtxPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtxPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            BtnxAceptar.Focus()
            'Aceptar()
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtxPassword.Focus()
    End Sub
End Class