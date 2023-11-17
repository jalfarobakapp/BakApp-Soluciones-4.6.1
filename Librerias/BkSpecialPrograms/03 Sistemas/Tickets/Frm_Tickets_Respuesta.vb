Imports System.Security.Cryptography
Imports DevComponents.DotNetBar
Public Class Frm_Tickets_Respuesta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_TicketAc As Integer
    Dim _Funcionario As String
    Public Property Grabar As Boolean

    Public Sub New(_Id_TicketAc As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._Id_TicketAc = _Id_TicketAc

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Respuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrWhiteSpace(Txt_Descripcion.Text) Then
            MessageBoxEx.Show(Me, "La descripción no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        Grabar = True
        Me.Close()
    End Sub

    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        Dim Fm As New Frm_Adjuntar_Archivos("Zw_Stk_Tickets_Archivos", "Id_TicketAc", _Id_TicketAc)
        'Fm.Text = "Archivos adjuntos documento en construcción: " & _Tido.Trim & " Nro: " & _Nudo
        Fm.Pedir_Permiso = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Dim _Archivos As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets_Archivos",
                                                            "Id_TicketAc = " & _Id_TicketAc)

        If _Archivos > 0 Then
            Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento (" & _Archivos & " archivo(s))"
            If _Archivos > 9 Then
                Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_9_plus
                Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_9_plus___copia
            Else
                Select Case _Archivos
                    Case 0
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.document_attach
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.document_attach___copia
                    Case 1
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_1
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_1___copia
                    Case 2
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_2
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_2___copia
                    Case 3
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_3
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_3___copia
                    Case 4
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_4
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_4___copia
                    Case 5
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_5
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_5___copia
                    Case 6
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_6
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_6___copia
                    Case 7
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_7
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_7___copia
                    Case 8
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_8
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_8___copia
                    Case 9
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_9
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_9___copia
                End Select
            End If
        Else
            Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento"
            Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.document_attach
            Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.document_attach___copia
        End If

    End Sub

End Class
