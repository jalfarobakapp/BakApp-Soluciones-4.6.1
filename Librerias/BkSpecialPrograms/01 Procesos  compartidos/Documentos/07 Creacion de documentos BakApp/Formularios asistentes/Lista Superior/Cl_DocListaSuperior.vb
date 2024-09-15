
Imports BkSpecialPrograms.DocumentoListaSuperior

Public Class Cl_DocListaSuperior

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property LsDetalleLpEntidad As New List(Of Cl_LsDetalle)
    Public Property LsDetalleLpSuperior As New List(Of Cl_LsDetalle)
    Public Property Zw_ListaActCliente As New Zw_ListaPreGlobal
    Public Property UsarVencListaPrecios As Boolean
    Public Property MesesVenListaPrecios As Integer
    Public Property ListaEntidad As String
    Public Property ListaSuperiorUtilizada As Boolean

    Public Sub New()

        Try
            UsarVencListaPrecios = _Global_Row_Configuracion_General.Item("UsarVencListaPrecios")
            MesesVenListaPrecios = _Global_Row_Configuracion_General.Item("MesesVenListaPrecios")
        Catch ex As Exception
            UsarVencListaPrecios = False
            MesesVenListaPrecios = 0
        End Try

    End Sub

    Sub Sb_Insertar_NuevaLineaLpSuperior(_Id As Integer,
                                         _Codigo As String,
                                         _Lista As String,
                                         _UnTrans As Integer,
                                         _Impuestos As Double,
                                         _Valor_desde_Lista As csGlobales.Enum_Neto_Bruto)

        Dim _ListaSuperior As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaPreGlobal", "ListaSuperior", "Lista = '" & _Lista & "'")

        If String.IsNullOrWhiteSpace(_ListaSuperior) Then
            Return
        End If

        Dim _Cl_LsDetalle As Cl_LsDetalle = Fx_Insertar_NuevaLinea(_Id, _Codigo, _ListaSuperior, _UnTrans, _Impuestos, _Valor_desde_Lista)
        LsDetalleLpSuperior.Add(_Cl_LsDetalle)

    End Sub

    Sub Sb_Insertar_NuevaLineaLpEntidad(_Id As Integer,
                                        _Codigo As String,
                                        _Lista As String,
                                        _UnTrans As Integer,
                                        _Impuestos As Double,
                                        _Valor_desde_Lista As csGlobales.Enum_Neto_Bruto)

        Dim _Cl_LsDetalle As Cl_LsDetalle = Fx_Insertar_NuevaLinea(_Id, _Codigo, _Lista, _UnTrans, _Impuestos, _Valor_desde_Lista)
        LsDetalleLpEntidad.Add(_Cl_LsDetalle)

    End Sub

    Function Fx_Insertar_NuevaLinea(_Id As Integer,
                                    _Codigo As String,
                                    _Lista As String,
                                    _UnTrans As Integer,
                                    _Impuestos As Double,
                                    _Valor_desde_Lista As csGlobales.Enum_Neto_Bruto) As Cl_LsDetalle

        Dim _Cl_LsDetalle As New Cl_LsDetalle

        'Dim _ListaSuperior As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaPreGlobal", "ListaSuperior", "Lista = '" & _Lista & "'")

        'If String.IsNullOrWhiteSpace(_ListaSuperior) Then
        '    Return Nothing
        'End If

        Consulta_sql = "Select Top 1 Lp.KOPR,Lp.DTMA01UD,Lp.MG01UD,Lp.DTMA02UD,Lp.MG02UD,Lp.KOLT,Lp.PP01UD,Lp.PP02UD,Lp.ECUACION,Lp.ECUACIONU2,Lpp.MELT As MELT,Pgl.ListaSuperior" & vbCrLf &
                       "From TABPRE Lp" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_ListaPreGlobal Pgl On Pgl.Lista = KOLT" & vbCrLf &
                       "Inner Join TABPP Lpp On Lp.KOLT = Lpp.KOLT" & vbCrLf &
                       "Where Lp.KOLT = '" & _Lista & "' And KOPR = '" & _Codigo & "'"
        Dim _RowPrecios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Dim _DescMaximo As Double = NuloPorNro(_RowPrecios.Item("DTMA01UD"), 0)
        Dim _Ecuacion As String = NuloPorNro(_RowPrecios.Item("ECUACION").ToString.Trim, "")
        Dim _Ecuacionu2 As String = NuloPorNro(_RowPrecios.Item("ECUACIONU2").ToString.Trim, "")

        Dim _ListaSuperior As String = NuloPorNro(_RowPrecios.Item("ListaSuperior").ToString.Trim, "")

        Dim _PrecioListaUd1 As Double = Fx_Funcion_Ecuacion_Random(Nothing, "", _Ecuacion, _Codigo, 1, _RowPrecios, 0, 0, 0)
        Dim _PrecioListaUd2 As Double = Fx_Funcion_Ecuacion_Random(Nothing, "", _Ecuacionu2, _Codigo, 2, _RowPrecios, 0, 0, 0)


        With _Cl_LsDetalle

            .Id = _Id
            .Codigo = _Codigo
            .Lista = _Lista
            .ListaSuperior = _ListaSuperior
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

            .Impuestos = _Impuestos

            Select Case _Valor_desde_Lista

                Case csGlobales.Enum_Neto_Bruto.Neto

                    .PrecioNetoUdLista = .Precio
                    .PrecioBrutoUdLista = Math.Round(.PrecioNetoUdLista * _Impuestos, 5)

                Case csGlobales.Enum_Neto_Bruto.Bruto

                    .PrecioNetoUdLista = Math.Round(.Precio / _Impuestos, 5)
                    .PrecioBrutoUdLista = .Precio

            End Select

            .Total = 0

        End With

        Return _Cl_LsDetalle

    End Function

    Public Sub Sb_EditarRegistro(_Id As Integer,
                                 _Cantidad As Double,
                                 _CantUd1 As Double,
                                 _CantUd2 As Double,
                                 _Precio As Double)

        Dim _Registro As Cl_LsDetalle

        _Registro = LsDetalleLpSuperior.FirstOrDefault(Function(r) r.Id = _Id)

        If _Registro IsNot Nothing Then

            With _Registro

                .Cantidad = _Cantidad
                .CantUd1 = _CantUd1
                .CantUd2 = _CantUd2

                If ListaSuperiorUtilizada Then
                    .Precio = _Precio
                End If

                .Total = _Cantidad * .Precio

            End With

        End If

        _Registro = LsDetalleLpEntidad.FirstOrDefault(Function(r) r.Id = _Id)

        If _Registro IsNot Nothing Then

            With _Registro

                .Cantidad = _Cantidad
                .CantUd1 = _CantUd1
                .CantUd2 = _CantUd2

                If Not ListaSuperiorUtilizada Then
                    .Precio = _Precio
                End If

                .Total = _Cantidad * .Precio

            End With

        End If

    End Sub

    Public Sub Sb_EliminarRegistro(_Id As Integer)

        Dim _Registro As Cl_LsDetalle

        _Registro = LsDetalleLpSuperior.FirstOrDefault(Function(r) r.Id = _Id)

        If _Registro IsNot Nothing Then
            LsDetalleLpSuperior.Remove(_Registro)
        End If

        _Registro = LsDetalleLpEntidad.FirstOrDefault(Function(r) r.Id = _Id)
        If _Registro IsNot Nothing Then
            LsDetalleLpEntidad.Remove(_Registro)
        End If

    End Sub

    Public Sub Sb_EliminarTodos()
        LsDetalleLpSuperior.Clear()
        LsDetalleLpEntidad.Clear()
    End Sub

    Public Function ObtenerSumaTotales() As Double
        Dim suma As Double = 0
        For Each detalle As Cl_LsDetalle In LsDetalleLpSuperior
            suma += detalle.Total
        Next
        Return suma
    End Function

    Function Fx_Llenar_ListaActualCliente(_Lista As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where Lista = '" & _Lista & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_ListaPreGlobal con la Lista = '" & _Lista & "'"

            Return _Mensaje

        End If

        With Zw_ListaActCliente

            .Tipo = _Row.Item("Tipo")
            .Moneda = _Row.Item("Moneda")
            .Permiso = _Row.Item("Permiso")
            .Lista = _Row.Item("Lista")
            .Nombre_Lista = _Row.Item("Nombre_Lista")
            .FormulaPrecio = _Row.Item("FormulaPrecio")
            .Redondear = _Row.Item("Redondear")
            .FormulaGrabarRD = _Row.Item("FormulaGrabarRD")
            .ListaCostoxDefecto = _Row.Item("ListaCostoxDefecto")
            .TipoValor = _Row.Item("TipoValor")
            .ValoresNetos = _Row.Item("ValoresNetos")
            .Margen_Ud1 = _Row.Item("Margen_Ud1")
            .Margen_Ud2 = _Row.Item("Margen_Ud2")
            .FormulaPrecio2 = _Row.Item("FormulaPrecio2")
            .Ej_Fx_documento = _Row.Item("Ej_Fx_documento")
            .Ej_Fx_documento2 = _Row.Item("Ej_Fx_documento2")
            .DsctoMax = _Row.Item("DsctoMax")
            .Flete = _Row.Item("Flete")
            .ListaSuperior = _Row.Item("ListaSuperior")
            .ListaInferior = _Row.Item("ListaInferior")
            .VentaMinVencLP = _Row.Item("VentaMinVencLP")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registro encontrado."
        _Mensaje.Tag = Zw_ListaActCliente

        Return _Mensaje

    End Function

    Public Function Fx_RevisarVentasDelMes(_Endo As String,
                                           _VentaEnCursoLsup As Double) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Row As DataRow
        Dim _VentaMinVencLP As Double

        Try

            Dim _FechaActual As Date = FechaDelServidor()
            Dim _PrimerDiaDelMes As Date = Primerdiadelmes(_FechaActual)
            Dim _UltimoDiaDelMes As Date = ultimodiadelmes(_FechaActual)

            Consulta_sql = "SELECT  CASE" & vbCrLf &
                           "WHEN TIDO = 'NVV' THEN SUM(PPPRNE * (CAPRCO1 - (CAPREX1 + CAPRAD1)))" & vbCrLf &
                           "WHEN TIDO = 'NCV' THEN SUM(VANELI) * -1" & vbCrLf &
                           "ELSE SUM(VANELI)" & vbCrLf &
                           "END AS VentaMesEnCurso" & vbCrLf &
                           "INTO #MesEnCurso" & vbCrLf &
                           "FROM MAEDDO " & vbCrLf &
                           "WHERE ENDO = '" & _Endo & "' " & vbCrLf &
                           "AND FEEMLI between '" & Format(_PrimerDiaDelMes, "yyyyMMdd") & "' And '" & Format(_UltimoDiaDelMes, "yyyyMMdd") & "'" & vbCrLf &
                           "AND TIDO IN ('NVV', 'FCV', 'NCV')" & vbCrLf &
                           "GROUP BY YEAR(FEEMLI), MONTH(FEEMLI), TIDO;" & vbCrLf &
                           "SELECT ISNULL(SUM(VentaMesEnCurso),0) AS 'VentaMesEnCurso'" & vbCrLf &
                           "FROM #MesEnCurso;" & vbCrLf &
                           "DROP TABLE #MesEnCurso;"

            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _VentaMesEnCurso As Double = NuloPorNro(_Row.Item("VentaMesEnCurso"), 0)

            If LsDetalleLpSuperior.Count = 0 Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "Revisar minorista mayorista"
                _Mensaje.Mensaje = "No se ha ingresado ningun producto"
                _Mensaje.Icono = MessageBoxIcon.Warning
                _Mensaje.Tag = _VentaMesEnCurso
                Return _Mensaje
            End If

            If LsDetalleLpSuperior.Count > 0 Then

                Dim _ListaSuperior = LsDetalleLpSuperior(0).Lista
                Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_ListaPreGlobal WHERE Lista = '" & _ListaSuperior & "'"
                _Row = _Sql.Fx_Get_DataRow(Consulta_sql)
                _VentaMinVencLP = _Row.Item("VentaMinVencLP")

            End If

            Dim _VtaMesCursoMasVtaLsup As Double = _VentaEnCursoLsup + _VentaMesEnCurso

            If _VtaMesCursoMasVtaLsup >= _VentaMinVencLP Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Revisar minorista mayorista"
                _Mensaje.Mensaje = "Cliente cumple con pertenecer a la lista superior"
                _Mensaje.Tag = _VentaMesEnCurso
                _Mensaje.Icono = MessageBoxIcon.Information
            Else
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "Revisar minorista mayorista"
                _Mensaje.Mensaje = "Cliente no cumple con pertenecer a la lista superior"
                _Mensaje.Tag = _VentaMesEnCurso
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
        Public Property Iva As Double
        Public Property Ila As Double
        Public Property Impuestos As Double
        Public Property PrecioListaUd1 As Double
        Public Property PrecioListaUd2 As Double
        Public Property PrecioNetoUdLista As Double
        Public Property PrecioBrutoUdLista As Double
        Public Property Total As Double
    End Class

End Namespace
