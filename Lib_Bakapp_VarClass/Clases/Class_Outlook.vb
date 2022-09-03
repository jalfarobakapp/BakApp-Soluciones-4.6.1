Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Reflection

Public Class Class_Outlook

    Public Sub Sb_Crear_Correo_Outlook(ByVal _Mail_Destino As String, _
                                       ByVal _Archivo_Adjunto As String, _
                                       ByVal _Asunto As String, _
                                       ByVal _Cuerpo As String, _
                                       ByVal _Es_Html As Boolean)

        Try

            ' Create an Outlook application.
            Dim oApp As Outlook.Application = New Outlook.Application()

            ' Crear un nuevo elemento de correo. 
            Dim oMsg As Outlook._MailItem
            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)

            oMsg.Subject = _Asunto

            If _Es_Html Then
                oMsg.HTMLBody = _Cuerpo
            Else
                oMsg.Body = _Cuerpo '"Saludos," & vbCr & vbCr
            End If

            oMsg.To = _Mail_Destino


            'datos adjuntos
            If Not String.IsNullOrEmpty(NuloPorNro(_Archivo_Adjunto, "")) Then
                Dim sSource As String = _Archivo_Adjunto
                Dim sBodyLen As String = oMsg.Body.Length
                Dim oAttachs As Outlook.Attachments = oMsg.Attachments
                Dim oAttach As Outlook.Attachment
                oAttach = oAttachs.Add(sSource, , sBodyLen + 1, )
            End If

            oMsg.Display()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



End Class
