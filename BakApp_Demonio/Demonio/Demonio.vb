Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering
Imports BkSpecialPrograms
Imports System.IO

Public Class Demonio

    Dim _Fm_Demonio As Frm_Demonio_01

    Public Property Pro_Fm_Demonio() As Frm_Demonio_01
        Get
            Return _Fm_Demonio
        End Get
        Set(ByVal value As Frm_Demonio_01)
            _Fm_Demonio = value
        End Set
    End Property


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Demonio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Global_Version_BakApp = _Version_BakApp
        _Configuracion_Regional_()
        Me.Hide()
        ' Leer los parámetros de la línea de comandos
        ' y mostrarlos en la caja de textos
        '
        ' Para probar, indicar esto en CommandLine arguments en propiedades
        'Prueba1 prueba2 /file:Nombre del fichero
        '
        ' Comprobar si hay más de un parámetro,
        ' el parámetro CERO es el nombre del ejecutable
        If Environment.GetCommandLineArgs.Length > 1 Then
            Cadena_ConexionSQL_Server = Environment.GetCommandLineArgs(0)
            Sb_Demonio(False)
            'Sb_Sistema_Demonio()
        Else
            Tiempo_Alerta.Enabled = True
            'TextBox1.Text = "No se han indicado parámetros en la línea de comandos" & vbCrLf &
            '                "El nombre (y path) del ejecutable es:" & vbCrLf &
            ' Environment.GetCommandLineArgs(0)
        End If

        'Sb_Iniciar_Sistema(False)
        'LvlVersion.Text = "Versión:" & _Version_BakApp & ", Empresa: " & Trim(RazonEmpresa)

    End Sub

    Private Sub Tiempo_Alerta_Tick(sender As Object, e As EventArgs) Handles Tiempo_Alerta.Tick
        Tiempo_Alerta.Enabled = False
        MessageBoxEx.Show(Me, "No se han indicado parámetros en la línea de comandos" & vbCrLf &
                            "El nombre (y path) del ejecutable es:" & vbCrLf &
                            Environment.GetCommandLineArgs(0), "Falta String de conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Me.Close()
    End Sub

    Private Sub Notify_Demonio_DoubleClick(sender As Object, e As EventArgs) Handles Notify_Demonio.DoubleClick
        Sb_Demonio(True)
    End Sub

End Class
