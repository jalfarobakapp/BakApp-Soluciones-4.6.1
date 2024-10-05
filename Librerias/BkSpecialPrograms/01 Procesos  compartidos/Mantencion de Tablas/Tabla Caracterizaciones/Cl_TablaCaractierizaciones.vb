Public Class Cl_TablaCaractierizaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_TablaDeCaracterizaciones(_Tabla As String, _CodigoTabla As String) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _Tabla & "' And CodigoTabla = '" & _CodigoTabla & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Zw_TablaDeCaracterizaciones As New Zw_TablaDeCaracterizaciones

        With Zw_TablaDeCaracterizaciones

            If IsNothing(_Row) Then

                _Mensaje_Stem.EsCorrecto = False
                _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_TablaDeCaracterizaciones con la tabla = " & _Tabla & " y Código tabla = " & _CodigoTabla

                Return _Mensaje_Stem

            End If

            .Id = _Row.Item("Id")
            .Tabla = _Row.Item("Tabla")
            .DescripcionTabla = _Row.Item("DescripcionTabla")
            .CodigoTabla = _Row.Item("CodigoTabla")
            .NombreTabla = _Row.Item("NombreTabla")
            .Orden = _Row.Item("Orden")
            .ApColor = _Row.Item("ApColor")
            .ApModelo = _Row.Item("ApModelo")
            .ApMedida = _Row.Item("ApMedida")
            .Porcentaje = _Row.Item("Porcentaje")
            .Valor = _Row.Item("Valor")
            .Padre_Tabla = _Row.Item("Padre_Tabla")
            .Padre_CodigoTabla = _Row.Item("Padre_CodigoTabla")
            .Fecha = NuloPorNro(_Row.Item("Fecha"), Nothing)
            .Equiv_Kotabla = _Row.Item("Equiv_Kotabla")
            .Equiv_Kocarac = _Row.Item("Equiv_Kocarac")
            .Emp = _Row.Item("Emp")
            .Suc = _Row.Item("Suc")
            .Bod = _Row.Item("Bod")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registro encontrado."
        _Mensaje_Stem.Tag = Zw_TablaDeCaracterizaciones

        Return _Mensaje_Stem

    End Function

End Class
