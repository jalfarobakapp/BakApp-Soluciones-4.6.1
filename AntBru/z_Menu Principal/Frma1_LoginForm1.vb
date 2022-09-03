Option Explicit Off
Imports Funciones_BakApp
Imports System.Data.SqlClient
Imports BkCompras
Imports BKpost

Public Class Frma1_iniciosesion


    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If autentificar_usuario(PasswordTextBox.Text, Txtusuario, tb, cn1) = True Then
            Nombre_funcionario_activo = Txtusuario.Text
            sesion = True


            Dim Frm_Modalidad As New Frm_Modalidad
            Frm_Modalidad.ShowDialog(Me)

            'Frm_MenuPrincipal.TimpoEsperaNotificacion.Enabled = True
            AccesoAdministrador = False
            RevisarSiEsPost()



            Me.Close()
        Else
            MsgBox("Clave desconocida", MsgBoxStyle.Critical, "Ingreso Ms_Fichas")
            Sesion = False
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click

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




    Private Function autentificar_usuario(ByVal password_us As String, _
                                          ByVal Txtusuario As TextBox, _
                                          ByVal tb As DataTable, _
                                          ByVal Cnn As SqlConnection) As Boolean
        'Dim ussuario As String = trae_dato(tb, cn1, "NOMBRE", "W_USUARIOS", "CLAVE = '" & _
        '          Encripta_md5(password_us) & "'")

        If Txtusuario.Text <> "" Then
            'Txtusuario.Text = ussuario

            FUNCIONARIO = trae_dato(tb, cn1, "KOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(PasswordTextBox.Text) & "'")
            Nombre_funcionario_activo = trae_dato(tb, cn1, "NOKOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(PasswordTextBox.Text) & "'")
            Dim inactivo As Boolean = trae_dato(tb, cn1, "INACTIVO", "TABFU", "PWFU = '" & _
                  TraeClaveRD(PasswordTextBox.Text) & "'")

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

    Private Sub PasswordTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PasswordTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordTextBox.TextChanged

        If Trim(PasswordTextBox.Text) = "" Then Return
        Txtusuario.Text = trae_dato(tb, cn1, "NOKOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(PasswordTextBox.Text) & "'")
        If Txtusuario.Text <> "" Then
            OK.Enabled = True
        Else
            OK.Enabled = False
        End If
    End Sub



    Function ClaveRandom(ByVal Clave)

    End Function
    
    Private Sub Frma1_iniciosesion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Satelite AntBru, versión " & currentversion
    End Sub


    Sub RevisarSiEsPost()

        Dim EsPost As Boolean = trae_datoAccess(tb, "Es_Post", "Tmp_BkPostValidate")

        If EsPost = True Then
            Dim Frm_FormularioVentas As New Frm_01Ventas
            'Frm_FormularioVentas.WindowState = FormWindowState.Maximized
            Frm_FormularioVentas.ShowDialog(Me)
        End If

    End Sub



    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class
