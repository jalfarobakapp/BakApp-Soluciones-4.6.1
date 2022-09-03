Public Module Fuentes_PDF_Manual

    Dim _FontStyle As System.Drawing.FontStyle

    Enum _Enum_Fuentes
        Arial
        Times_New_Roman
        Courier_New
    End Enum

    Private Function Fx_Font(ByVal _Fuente As _Enum_Fuentes) As String

        Dim _Str_Fuente As String = _Fuente.ToString
        _Str_Fuente = Replace(_Str_Fuente, "_", " ")

        Return _Str_Fuente

    End Function

    Function Fx_Fuente(_Fuente As _Enum_Fuentes,
                       _Tamano As Integer,
                       _FontStyle As System.Drawing.FontStyle) As Font

        Dim _Font As String = Fx_Font(_Fuente)

        Dim _New_Fuente As New Font(_Font, _Tamano, _FontStyle)

        Return _New_Fuente

    End Function

    Function Fx_Fuente(_Fuente As _Enum_Fuentes,
                   _Tamano As Integer,
                   _FontStyle As System.Drawing.FontStyle,
                   _Subrayado As Boolean) As Font

        Dim _Font As String = Fx_Font(_Fuente)

        Dim _New_Fuente As Font

        If _Subrayado Then
            _New_Fuente = New Font(_Font, _Tamano, _FontStyle Or FontStyle.Underline)
        Else
            _New_Fuente = New Font(_Font, _Tamano, _FontStyle)
        End If

        Return _New_Fuente

    End Function

End Module
