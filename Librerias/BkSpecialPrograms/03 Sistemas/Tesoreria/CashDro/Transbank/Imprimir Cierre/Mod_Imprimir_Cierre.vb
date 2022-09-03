'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Module Mod_Imprimir_Cierre

    Sub Sb_Imprirmir_Cierre(ByVal _Formulario As Form, _
                            ByVal _NombreEquipo As String, _
                            ByVal _Fecha_Cierre As Date, _
                            ByVal _Impresora As String)

        Dim _Imp_Cierre As New Clas_Imprimir_Cierre(_NombreEquipo, _Fecha_Cierre)

        If _Imp_Cierre.Pro_Tbl_Detalle_Terminal.Rows.Count Then

            _Imp_Cierre.Fx_Imprimir_Archivo(_Formulario, "Detalle Terminal " & FormatDateTime(_Fecha_Cierre, DateFormat.ShortDate), _
                                            "", Clas_Imprimir_Cierre._Enum_Tipo_Impresion.Detalle_Terminal)

            If Not (_Imp_Cierre.Pro_Row_Cierre Is Nothing) Then
                _Impresora = _Imp_Cierre.Pro_Impresora
                If Not String.IsNullOrEmpty(_Impresora) Then
                    _Imp_Cierre.Fx_Imprimir_Archivo(_Formulario, "Cierre Terminal " & FormatDateTime(_Fecha_Cierre, DateFormat.ShortDate), _
                                                    _Impresora, Clas_Imprimir_Cierre._Enum_Tipo_Impresion.Cierre_Caja)
                End If
            End If
        Else
            MessageBoxEx.Show(_Formulario, "No existe información para la fecha: " & _Fecha_Cierre, "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

End Module
