
Public Module FuncionPassRD
    'Public ArrPassRD(,) As String

    Function TraeClaveRD(ByVal Texto As String) As String

        Dim valorAscii As Integer
        Dim PassEncriptado, Letra As String
        Dim CadenaRD As Long


        Texto = Trim(Texto)
        For x = 1 To Len(Texto)
            Letra = Mid(Texto, x, 1)
            valorAscii = Asc(Letra)
            'txtAscii.Text = valor.ToString

            If x = 1 Then
                CadenaRD = (17225 + valorAscii) * 1
            ElseIf x = 2 Then
                CadenaRD = (1847 + valorAscii) * 8
            ElseIf x = 3 Then
                CadenaRD = (1217 + valorAscii) * 27
            ElseIf x = 4 Then
                CadenaRD = (237 + valorAscii) * 64
            ElseIf x = 5 Then
                CadenaRD = (201 + valorAscii) * 125
            End If

            PassEncriptado = PassEncriptado & CadenaRD
            CadenaRD = 0
        Next

        Return PassEncriptado

    End Function

    Function ConsultaPermisoRD(ByVal Usuario As String, _
                               ByVal Permiso As String) As Boolean

        If Cuenta_registros("MAEUS", "KOUS = '" & FUNCIONARIO & "' AND KOOP = '" & Permiso & "'") > 0 Then
            Return True
        Else
            Dim NombrePermiso As String = trae_dato(tb, cn1, "NOKOOP", "MAEOP", "KOOP = '" & Permiso & "'")
            MsgBox("Permiso denegado Código: " & Permiso) '& " - " & NombrePermiso, MsgBoxStyle.Critical, "Control de Usuario")
            Return False
        End If

    End Function

End Module
