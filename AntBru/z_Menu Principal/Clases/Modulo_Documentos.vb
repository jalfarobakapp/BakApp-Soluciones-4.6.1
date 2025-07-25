﻿Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Module Modulo_Documentos

    Sub Sb_Generar_Documento(_Fm_Menu_Padre As Metro.MetroAppForm,
                             _Tido As String,
                             _Minimizar As Boolean,
                             _Tipo_Documento As csGlobales.Enum_Tipo_Documento,
                             _SubTido As String)

        Dim _Permiso As String = Fx_PermisoRegistroDoc(_Tido)

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, _Permiso) Then Return
        If Not Fx_Tido_Excluido(_Fm_Menu_Padre, _Tido) Then Return

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Mod_Empresa, Mod_Modalidad, _Tido, True)

        If Not IsNothing(_RowFormato) Then

            Dim _Empresa As String = Mod_Empresa
            Dim _Sucursal As String = Mod_Sucursal
            Dim _Bodega As String = Mod_Bodega

            Dim _PermisoBod = "Bo" & _Empresa & _Sucursal & _Bodega

            If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, _Permiso, , True) Then

                Dim _Bod = _Global_Row_Configuracion_Estacion.Item("NOKOBO")

                MessageBoxEx.Show(_Fm_Menu_Padre, "NO ESTA AUTORIZADO PARA EFECTUAR VENTAS DESDE LA BODEGA DE ESTA MODALIDAD" & vbCrLf & vbCrLf &
                                  "BODEGA: " & _Bodega & " - " & _Bod,
                                  "VALIDACION",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

            If Fx_Tiene_Permiso(_Fm_Menu_Padre, _PermisoBod) Then

                Dim _Revisar_Directorio_GenDTE = True

                Try
                    _Revisar_Directorio_GenDTE = Not _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto")
                Catch ex As Exception
                    _Revisar_Directorio_GenDTE = True
                End Try

                If _Revisar_Directorio_GenDTE Then

                    If Fx_Es_Electronico(_Tido) Then

                        Dim _Directorio_GenDTE As String = _Global_Row_EstacionBk.Item("Directorio_GenDTE")
                        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                        Fx_Datos_Directorio_GenDTE(_Directorio_GenDTE, _NombreEquipo)

                    End If

                End If

                If Fx_Tiene_Permiso_Generar_Documento(_Fm_Menu_Padre, _Tido, _SubTido) Then

                    Dim _Es_Ajuste As Boolean
                    Dim _PreVenta As Boolean

                    If _SubTido = "AJU" Then _Es_Ajuste = True

                    If _Tido = "COV" And _SubTido = "PRE" Then
                        _SubTido = String.Empty
                        _PreVenta = True
                    End If

                    Dim Fm_Post As New Frm_Formulario_Documento(_Tido, _Tipo_Documento, False,,, _Es_Ajuste)
                    If _Fm_Menu_Padre.Name <> "Frm_Menu_Extra" Then Fm_Post.MinimizeBox = True
                    Fm_Post.MinimizeBox = _Minimizar
                    Fm_Post.Pro_SubTido = _SubTido
                    Fm_Post.PreVenta = _PreVenta
                    Fm_Post.ShowDialog(_Fm_Menu_Padre)
                    Fm_Post.Dispose()

                End If

            End If

        Else

            MessageBoxEx.Show(_Fm_Menu_Padre, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Function Fx_Tiene_Permiso_Generar_Documento(_Fm_Menu_Padre As Metro.MetroAppForm, _Tido As String, _SubTido As String) As Boolean

        Dim _CodPermiso As String

        Select Case _Tido
            Case "BLV"
                _CodPermiso = "Doc00037"
            Case "FCV"
                _CodPermiso = "Bkp00054"
            Case "NVV"
                _CodPermiso = "Bkp00041"
            Case "NVI"
                _CodPermiso = "Doc00063"
            Case "COV"
                _CodPermiso = "Bkp00053"
            Case "NCV"
                _CodPermiso = "Bkp00055"
            Case "GDV"
                _CodPermiso = "Bkp00056"
            Case "GRD"
                _CodPermiso = "Doc00069"
            Case "GRI"
                If String.IsNullOrEmpty(_SubTido) Then
                    _CodPermiso = "Doc00086"
                Else
                    _CodPermiso = "Doc00087"
                End If
            Case "GDI"
                If String.IsNullOrEmpty(_SubTido) Then
                    _CodPermiso = "Doc00088"
                Else
                    _CodPermiso = "Doc00089"
                End If
            Case Else
                Return True
        End Select

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, _CodPermiso) Then
            Return True
        End If

    End Function

    Function Fx_Tido_Excluido(_Formulario As Form, _Tido As String) As Boolean

        Dim _Tidoexclu As String = _Global_Row_Configuracion_Estacion.Item("TIDOEXCLU").ToString.Trim

        If Not String.IsNullOrEmpty(_Tidoexclu) Then

            Dim _Tidos = Split(_Tidoexclu, ",")

            For Each _Td As String In _Tidos
                If _Td = _Tido Then
                    MessageBoxEx.Show(_Formulario, "Este documento (" & _Tido & ") no esta permitido en esta modalidad", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
            Next

        End If

        Return True
    End Function

End Module


