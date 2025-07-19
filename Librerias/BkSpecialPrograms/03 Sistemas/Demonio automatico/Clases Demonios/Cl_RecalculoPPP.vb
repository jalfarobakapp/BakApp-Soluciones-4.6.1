Public Class Cl_RecalculoPPP

    Public Property Ejecutar As Boolean
    Public Property Procesando As Boolean
    Public Property Log_Registro As String
    Public Sub New()

    End Sub

    Sub Sb_RecalcularPPP(_Formulario As Form)
        If Not Ejecutar Then
            Return
        End If
        Procesando = True

        Dim Fm As New Frm_Recalculo_PPPxProd
        Fm.EjecutarProcesoTodosLosProductos = True
        Fm.ModoPruebas = True
        Fm.ShowDialog(_Formulario)
        Log_Registro = Fm.MensajeFinal
        Fm.Dispose()

        System.Threading.Thread.Sleep(2000)
        Procesando = False
    End Sub

End Class
