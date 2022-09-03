Imports Funciones_BakApp
Imports BkSpecialPrograms
Public Class Frm_MenuBarras

    Public TablaDePaso As String
    Private Sub Btnbuscardocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnbuscardocumento.Click

        Dim Nro As String = "7Brr0004"
        If TienePermiso(Nro) Then
            BuscaDoc()
            If IDdocumentoSeleccionado <> "" Then
                If CrearDetalleParaGenerarEtiquetasDeBarra(IDdocumentoSeleccionado, FUNCIONARIO, CodEntidadDocumento) > 0 Then
                    Frm_ImpBarrasPorDocumento.MdiParent = Me
                    Frm_ImpBarrasPorDocumento.Show()
                End If
            End If
        Else
            MensajeSinPermiso(Nro)
        End If

    End Sub

    Function BuscaDoc()
        IDdocumentoSeleccionado = ""
        Dim Frm_Buscar_Doc As New Frm_BuscarDocumento
        Frm_Buscar_Doc.ShowDialog(Me)

    End Function



    Private Sub BtnImprimirBarra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirBarra.Click
        Dim Nro As String = "7Brr0003"
        If TienePermiso(Nro) Then
            Frm_ImpBarrasDisenoDeFormatos2.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If


    End Sub

    Private Sub Frm_MenuBarras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Puerto = LTrim$(RTrim$(Ruta_conexion(AppPath(True) & "Barras\Puerto.txt")))
        'Dim Rutaimage As String = AppPath(True) & "Logo Bakapp-01.jpg"

        Cmbpuerto.Text = Trim(Puerto)
    End Sub

    Private Sub PegarToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarToolStripButton.Click
        Dim Nro As String = "7Brr0002"
        If TienePermiso(Nro) Then
        Frm_ImpBarrasDisenoDeFormatos1.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If

    End Sub

    Private Sub ToolStripButtonGrabarPuerto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonGrabarPuerto.Click
        Dim fic As String = AppPath(True) & "Barras\Puerto.txt"

        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine(Cmbpuerto.Text)
        sw.Close()
        MsgBox("Puerto " & Cmbpuerto.Text & " configurado correctamente", MsgBoxStyle.Information, "Cambio de Puerto de Salida")
        Puerto = Cmbpuerto.Text
    End Sub

   
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        Me.BackgroundImage = Procedures.Bakapp___Pantalla_Inicio

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class