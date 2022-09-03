Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports System.Drawing

Public Module Mod_Alertas

    Public Sub ShowLoadAlert(ByVal m_AlertOnLoad As DevComponents.DotNetBar.Balloon,
                             ByVal _Formulario As Form,
                             Optional ByVal _AutoClose As Boolean = False,
                             Optional ByVal _AutoClose_TiempoOut As Integer = 7,
                             Optional ByVal _Agrupar_por_asociados As Boolean = False)


        ' Dim _m_AlertOnLoad = New AlertCustom() = m_AlertOnLoad 'As DevComponents.DotNetBar.Balloon

        Dim _Mostrar_Stock_Fisico As Boolean = Not (Fx_Tiene_Permiso("NO00004", FUNCIONARIO))
        Dim _Mostrar_Stock_Comprometido As Boolean = Not (Fx_Tiene_Permiso("NO00005", FUNCIONARIO))
        Dim _Mostrar_Stock_Devengado As Boolean = Not (Fx_Tiene_Permiso("NO00006", FUNCIONARIO))
        Dim _Mostrar_Stock_Pedido As Boolean = Not (Fx_Tiene_Permiso("NO00007", FUNCIONARIO))
        Dim _Mostrar_Stock_Disponible As Boolean = Not (Fx_Tiene_Permiso("NO00008", FUNCIONARIO))

        Dim r As Rectangle = Screen.GetWorkingArea(_Formulario)

        With CType(m_AlertOnLoad, AlertCustom)

            .TopMost = True
            .Width = 766

            If Not _Mostrar_Stock_Fisico Then .Width -= 85
            If Not _Mostrar_Stock_Comprometido Then .Width -= 65 + 65
            If Not _Mostrar_Stock_Devengado Then .Width -= 65
            If Not _Mostrar_Stock_Disponible Then .Width -= 65
            If Not _Mostrar_Stock_Pedido Then .Width -= 65

            .Mostrar_Stock_Comprometido = _Mostrar_Stock_Comprometido
            .Mostrar_Stock_Devengado = _Mostrar_Stock_Devengado
            .Mostrar_Stock_Disponible = _Mostrar_Stock_Disponible
            .Mostrar_Stock_Fisico = _Mostrar_Stock_Fisico
            .Mostrar_Stock_Pedido = _Mostrar_Stock_Pedido

            .Location = New Point(r.Right - m_AlertOnLoad.Width, r.Bottom - m_AlertOnLoad.Height)
            If _AutoClose Then
                .AutoClose = _AutoClose
                .AutoCloseTimeOut = _AutoClose_TiempoOut
            End If
            .AlertAnimation = eAlertAnimation.BottomToTop
            .AlertAnimationDuration = 300
            .Pro_Agrupar_Asociados = _Agrupar_por_asociados

            If Not IsNothing(.Pro_RowProducto) Then
                .Show()
            End If

        End With

    End Sub

End Module
