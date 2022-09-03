Module Mod_St

    Function Fx_Trae_Estado(ByVal _CodEstado As String) As String

        'SELECT     Tabla, DescripcionTabla, CodigoTabla, NombreTabla, Orden, ApColor, ApModelo, ApMedida, Porcentaje, Valor
        'FROM(Zw_TablaDeCaracterizaciones)

        Select Case _CodEstado
            Case "I"
                Fx_Trae_Estado = "INGRESADO"
            Case "A"
                Fx_Trae_Estado = "ASIGNADO"
            Case "P"
                Fx_Trae_Estado = "PRESUPUESTO"
            Case "C"
                Fx_Trae_Estado = "COTIZACION"
            Case "R"
                Fx_Trae_Estado = "REPARACION Y CIERRE"
            Case "V"
                Fx_Trae_Estado = "AVISO"
            Case "CE"
                Fx_Trae_Estado = "ORDEN CERRADA"
            Case "F"
                Fx_Trae_Estado = "CERRADO"
            Case "N"
                Fx_Trae_Estado = "NULA"
            Case Else
                Fx_Trae_Estado = "Estado desconocido"
        End Select

    End Function

End Module
