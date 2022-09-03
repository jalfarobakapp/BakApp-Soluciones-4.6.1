Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports System.Drawing

Public Module Mod_Alertas

    Public Sub ShowLoadAlert(ByVal m_AlertOnLoad As DevComponents.DotNetBar.Balloon, _
                              ByVal _Formulario As Form, _
                              Optional ByVal _AutoClose As Boolean = False, _
                              Optional ByVal _AutoClose_TiempoOut As Integer = 7)

        'm_AlertOnLoad = New AlertCustom() 'As DevComponents.DotNetBar.Balloon
        Dim r As Rectangle = Screen.GetWorkingArea(_Formulario)
        With m_AlertOnLoad
            .TopMost = True
            .Location = New Point(r.Right - m_AlertOnLoad.Width, r.Bottom - m_AlertOnLoad.Height)
            If _AutoClose Then
                .AutoClose = _AutoClose
                .AutoCloseTimeOut = _AutoClose_TiempoOut
            End If
            .AlertAnimation = eAlertAnimation.BottomToTop
            .AlertAnimationDuration = 300
            .Show()
        End With
    End Sub

End Module
