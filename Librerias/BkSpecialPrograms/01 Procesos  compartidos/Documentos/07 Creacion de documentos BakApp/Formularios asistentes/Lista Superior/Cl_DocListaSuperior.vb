
Imports BkSpecialPrograms.DocumentoListaSuperior

Public Class Cl_DocListaSuperior

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property LsDetalle As New List(Of Cl_LsDetalle)
    Public Property UsarVencListaPrecios As Boolean
    Public Property MesesVenListaPrecios As Integer

    Public Sub New()

        Try
            UsarVencListaPrecios = _Global_Row_Configuracion_General.Item("UsarVencListaPrecios")
            MesesVenListaPrecios = _Global_Row_Configuracion_General.Item("MesesVenListaPrecios")
        Catch ex As Exception
            UsarVencListaPrecios = False
            MesesVenListaPrecios = 0
        End Try

    End Sub

    Sub Sb_Insertar_NuevaLinea(_Id As Integer, _Codigo As String, _Lista As String, _UnTrans As Integer)

        Dim _Cl_LsDetalle As Cl_LsDetalle = Fx_Insertar_NuevaLinea(_Id, _Codigo, _Lista, _UnTrans)
        LsDetalle.Add(_Cl_LsDetalle)

    End Sub

    Function Fx_Insertar_NuevaLinea(_Id As Integer, _Codigo As String, _Lista As String, _UnTrans As Integer) As Cl_LsDetalle

        Dim _Cl_LsDetalle As New Cl_LsDetalle

        Dim _ListaSuperior As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaPreGlobal", "ListaSuperior", "Lista = '" & _Lista & "'")

        If String.IsNullOrWhiteSpace(_ListaSuperior) Then
            Return Nothing
        End If

        Consulta_sql = "Select Top 1 Lp.KOPR,Lp.DTMA01UD,Lp.KOLT,Lp.PP01UD,Lp.PP02UD,Lp.ECUACION,Lp.ECUACIONU2,Lpp.MELT As MELT,Pgl.ListaSuperior" & vbCrLf &
                       "From TABPRE Lp" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_ListaPreGlobal Pgl On Pgl.Lista = KOLT" & vbCrLf &
                       "Inner Join TABPP Lpp On Lp.KOLT = Lpp.KOLT" & vbCrLf &
                       "Where Lp.KOLT = '" & _ListaSuperior & "' And KOPR = '" & _Codigo & "'"
        Dim _RowPrecios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _DescMaximo As Double = NuloPorNro(_RowPrecios.Item("DTMA01UD"), 0)
        Dim _Ecuacion As String = NuloPorNro(_RowPrecios.Item("ECUACION").ToString.Trim, "")
        Dim _Ecuacionu2 As String = NuloPorNro(_RowPrecios.Item("ECUACIONU2").ToString.Trim, "")

        Dim _ListaSuperior2 As String = NuloPorNro(_RowPrecios.Item("ListaSuperior").ToString.Trim, "")

        Dim _PrecioListaUd1 As Double = Fx_Funcion_Ecuacion_Random(Nothing, "", _Ecuacion, _Codigo, 1, _RowPrecios, 0, 0, 0)
        Dim _PrecioListaUd2 As Double = Fx_Funcion_Ecuacion_Random(Nothing, "", _Ecuacionu2, _Codigo, 2, _RowPrecios, 0, 0, 0)

        With _Cl_LsDetalle
            .Id = _Id
            .Codigo = _Codigo
            .Lista = _ListaSuperior
            .ListaSuperior = _ListaSuperior2
            .Cantidad = 0
            .UnTrans = _UnTrans
            .CantUd1 = 0
            .CantUd2 = 0

            .PrecioListaUd1 = _PrecioListaUd1
            .PrecioListaUd2 = _PrecioListaUd2

            If _UnTrans = 1 Then
                .Precio = _PrecioListaUd1
            Else
                .Precio = _PrecioListaUd2
            End If

            .Total = 0
        End With

        Return _Cl_LsDetalle

    End Function

    Public Sub Sb_EditarRegistro(_Id As Integer, _Cantidad As Double, _CantUd1 As Double, _CantUd2 As Double)
        Dim registro As Cl_LsDetalle = LsDetalle.FirstOrDefault(Function(r) r.Id = _Id)
        If registro IsNot Nothing Then

            With registro
                .Cantidad = _Cantidad
                .CantUd1 = _CantUd1
                .CantUd2 = _CantUd2
                .Total = _Cantidad * .Precio
            End With

        End If
    End Sub

    Public Sub Sb_EliminarRegistro(_Id As Integer)
        Dim registro As Cl_LsDetalle = LsDetalle.FirstOrDefault(Function(r) r.Id = _Id)
        If registro IsNot Nothing Then
            LsDetalle.Remove(registro)
        End If
    End Sub

    Public Sub Sb_EliminarTodos()
        LsDetalle.Clear()
    End Sub

    Public Function ObtenerSumaTotales() As Double
        Dim suma As Double = 0
        For Each detalle As Cl_LsDetalle In LsDetalle
            suma += detalle.Total
        Next
        Return suma
    End Function

    Public Function Fx_RevisarVentasDelMes(_Endo As String, _VentaMinima As Double, _Meses As Integer, _VentaEnCurso As Double) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = My.Resources.Recuros_ListaSuperior.RevisarSumpliminetoDeMinoristaMayorista
            Consulta_sql = Replace(Consulta_sql, "{VentaMinima}", _VentaMinima)
            Consulta_sql = Replace(Consulta_sql, "{Endo}", _Endo)
            Consulta_sql = Replace(Consulta_sql, "{Meses}", _Meses)
            Consulta_sql = Replace(Consulta_sql, "{VentaEnCurso}", _VentaEnCurso)

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim _Row As DataRow = _Ds.Tables(3).Rows(0)
            Dim _Cumple As String = _Row.Item("Cumple")

            If _Cumple = "Cumple" Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Revisar minorista mayorista"
                _Mensaje.Mensaje = "Cliente cumple con pertenecer a la lista superior"
                _Mensaje.Icono = MessageBoxIcon.Information
            Else
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "Revisar minorista mayorista"
                _Mensaje.Mensaje = "Cliente no cumple con pertenecer a la lista superior"
                _Mensaje.Icono = MessageBoxIcon.Warning
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Revisar minorista mayorista"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

End Class

Namespace DocumentoListaSuperior
    Public Class Cl_LsDetalle
        Public Property Id As Integer
        Public Property Codigo As String
        Public Property Lista As String
        Public Property ListaSuperior As String
        Public Property Cantidad As Double
        Public Property UnTrans As Integer
        Public Property CantUd1 As Double
        Public Property CantUd2 As Double
        Public Property Precio As Double
        Public Property PrecioListaUd1 As Double
        Public Property PrecioListaUd2 As Double
        Public Property Total As Double
    End Class

End Namespace
