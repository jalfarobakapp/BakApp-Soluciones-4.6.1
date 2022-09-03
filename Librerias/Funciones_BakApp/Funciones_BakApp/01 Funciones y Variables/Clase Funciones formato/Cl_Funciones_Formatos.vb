Imports Lib_Bakapp_VarClassFunc

Public Class Cl_Funciones_Formatos

#Region "Funciones"

#Region "Encabezado Doc."

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Function Fx_Trae_valor_Fx(ByVal _Row_Funcion As DataRow, _
                                     ByVal _IdMaeedo As Integer)

        Dim _Valor As String

        With _Row_Funcion

            Dim _Uso As String = .Item("Uso")
            Dim _Seccion As String = .Item("Seccion")
            Dim _Funcion As String = .Item("Funcion")
            Dim _Filtro As String = .Item("Filtro")
            Dim _Descripcion As String = .Item("Descripcion")
            Dim _Tipo_de_Dato As String = .Item("Tipo_de_Dato")


            Dim _Tbl As DataTable

            Select Case _Filtro

                Case "Documento"

                    Consulta_sql = My.Resources.Rs_fx_SQL.SQLQuery_Documento_Enc & vbCrLf &
                                   "Where IDMAEEDO = " & _IdMaeedo

                    _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
                    _Valor = Fx_Formatos_Datos_Documento(_Funcion, _Tbl)

                Case "Entidad"

                    Dim _CodEntidad = _Sql.Fx_Trae_Dato("MAEEDO", "ENDO", "IDMAEEDO = " & _IdMaeedo)
                    Dim _SucEntidad = _Sql.Fx_Trae_Dato("MAEEDO", "SUENDO", "IDMAEEDO = " & _IdMaeedo)

                    Consulta_sql = My.Resources.Rs_fx_SQL.SQLQuery_Datos_Entidad & vbCrLf & _
                                   "Where KOEN = '" & _CodEntidad & "' And SUEN = '" & _SucEntidad & "'"

                    _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
                    _Valor = Fx_Formatos_Datos_Entidad(_Funcion, _Tbl)

                Case "Entidad Fisica"

                    Dim _CodEntidad = _Sql.Fx_Trae_Dato("MAEEDO", "ENDOFI", "IDMAEEDO = " & _IdMaeedo)

                    Consulta_sql = My.Resources.Rs_fx_SQL.SQLQuery_Datos_Entidad & vbCrLf &
                                   "Where KOEN = '" & _CodEntidad & "'"

                    _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
                    _Valor = Fx_Formatos_Datos_Entidad(_Funcion, _Tbl)

                Case "Entidad Contacto"

                    Dim _CodEntidad = _Sql.Fx_Trae_Dato("MAEEDO", "ENDOFI", "IDMAEEDO = " & _IdMaeedo)

                    Consulta_sql = "Select top 1 * From MAEENCON Where KOEN = '" & _CodEntidad & "'"
                    _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Fx_Formatos_Contacto_Entidad(_Funcion, _Tbl)

                Case "Sistema"

                Case "Detalle"

                Case Else

                    Return "No Exite Fx()"

            End Select

            

        End With
    End Function


    Private Function Fx_Formatos_Datos_Entidad(ByVal _Funcion As String, _
                                               ByVal _Tbl_Datos As DataTable)

        'Uso, Seccion, Funcion, Filtro, Descripcion, Tipo_de_dato

        Select Case _Funcion

            Case "_Tbl_Datos_Ciudad"
                Return _Tbl_Datos.Rows(0).Item("Ciudad")
            Case "_Tbl_Datos_Comuna"
                Return _Tbl_Datos.Rows(0).Item("Comuna")
            Case "_Tbl_Datos_Cond_Pago"
                Return _Tbl_Datos.Rows(0).Item("Cod_Pago")
            Case "_Tbl_Datos_Direccion"
                Return _Tbl_Datos.Rows(0).Item("Direccion")
            Case "_Tbl_Datos_Razon_Social"
                Return _Tbl_Datos.Rows(0).Item("Razon_Social")
            Case "_Tbl_Datos_Fax"
                Return _Tbl_Datos.Rows(0).Item("Fax")
            Case "_Tbl_Datos_Giro"
                Return _Tbl_Datos.Rows(0).Item("Giro")
            Case "_Tbl_Datos_Obs_Pago"
                Return _Tbl_Datos.Rows(0).Item("Obs_Pago")
            Case "_Tbl_Datos_Pais"
                Return _Tbl_Datos.Rows(0).Item("Pais")
            Case "_Tbl_Datos_Rut"
                Return _Tbl_Datos.Rows(0).Item("Rut")
            Case "_Tbl_Datos_Sigla"
                Return _Tbl_Datos.Rows(0).Item("Sigla")
            Case "_Tbl_Datos_Vendedor"
                Return _Tbl_Datos.Rows(0).Item("Vendedor")
            Case "_Tbl_Datos_Razon_Ampliada"
                Return _Tbl_Datos.Rows(0).Item("Razon_Ampliada")
            Case "_Tbl_Datos_Email1"
                Return _Tbl_Datos.Rows(0).Item("Email1")
            Case "_Tbl_Datos_Email2"
                Return _Tbl_Datos.Rows(0).Item("Email2")
            Case "_Tbl_Datos_Codigo_Postal"
                Return _Tbl_Datos.Rows(0).Item("Codigo_postal")
            Case "_Tbl_Datos_Zona"
                Return _Tbl_Datos.Rows(0).Item("Zona")
            Case "_Tbl_Datos_Codigo"
                Return _Tbl_Datos.Rows(0).Item("Codigo_Tbl_Datos")
            Case "_Tbl_Datos_Sucursal"
                Return _Tbl_Datos.Rows(0).Item("Sucursal")
            Case Else
                Return ""
        End Select


    End Function

    Public Function Fx_Formatos_Contacto_Entidad(ByVal _Funcion As String, _
                                                 ByVal _Tabla_Valores As DataTable) As String

        Select Case _Funcion
            Case "_Contacto_Nombre"
                Return _Tabla_Valores.Rows(0).Item("NOKOCON")
            Case "_Contacto_Telefono"
                Return _Tabla_Valores.Rows(0).Item("FONOCON")
            Case "_Contacto_Fax"
                Return _Tabla_Valores.Rows(0).Item("FAXCON")
            Case "_Contacto_Email"
                Return _Tabla_Valores.Rows(0).Item("EMAILCON")
            Case "_Contacto_Cargo"
                Return _Tabla_Valores.Rows(0).Item("CARGOCON")
            Case "_Contacto_Area"
                Return _Tabla_Valores.Rows(0).Item("AREACON")
            Case Else
                Return ""
        End Select
      
    End Function

    Public Function Fx_Formatos_Datos_Documento(ByVal _Funcion As String, _
                                                ByVal _Tbl_Datos_entidad As DataTable) As String

        Select Case _Funcion

            Case "_Entidad_Codigo"
                Return _Tbl_Datos_entidad.Rows(0).Item("CodEntidad")
            Case "_Entidad_Rut"
                Return _Tbl_Datos_entidad.Rows(0).Item("Rut")
            Case "_Entidad_Sucursal"
                Return _Tbl_Datos_entidad.Rows(0).Item("SucEntidad")
            Case "_Entidad_Razon_Social"
                Return _Tbl_Datos_entidad.Rows(0).Item("Razon_Social")
            Case "_Entidad_Sigla"
                Return _Tbl_Datos_entidad.Rows(0).Item("Sigla")
            Case "_Entidad_Giro"
                Return _Tbl_Datos_entidad.Rows(0).Item("Giro")
            Case "_Entidad_Pais"
                Return _Tbl_Datos_entidad.Rows(0).Item("Pais")
            Case "_Entidad_Ciudad"
                Return _Tbl_Datos_entidad.Rows(0).Item("Ciudad")
            Case "_Entidad_Comuna"
                Return _Tbl_Datos_entidad.Rows(0).Item("Comuna")
            Case "_Entidad_Direccion"
                Return _Tbl_Datos_entidad.Rows(0).Item("Direccion")
            Case "_Entidad_Zona"
                Return _Tbl_Datos_entidad.Rows(0).Item("Zona")
            Case "_Entidad_Telefono"
                Return _Tbl_Datos_entidad.Rows(0).Item("Telefono")
            Case "_Entidad_Fax"
                Return _Tbl_Datos_entidad.Rows(0).Item("Fax")
            Case "_Entidad_Cond_Pago"
                Return _Tbl_Datos_entidad.Rows(0).Item("Cod_Pago")
            Case "_Entidad_Vendedor"
                Return _Tbl_Datos_entidad.Rows(0).Item("Vendedor")
            Case "_Entidad_Razon_Ampliada"
                Return _Tbl_Datos_entidad.Rows(0).Item("Razon_Ampliada")
            Case "_Entidad_Email1"
                Return _Tbl_Datos_entidad.Rows(0).Item("Email_1")
            Case "_Entidad_Email2"
                Return _Tbl_Datos_entidad.Rows(0).Item("Email_2")
            Case "_Entidad_Codigo_Postal"
                Return _Tbl_Datos_entidad.Rows(0).Item("CodPostal")
            Case "_Entidad_Obs_Pago"
                Return _Tbl_Datos_entidad.Rows(0).Item("Obs_Pago")
            Case Else
                Return ""
        End Select


    End Function

#End Region

#End Region
End Class
