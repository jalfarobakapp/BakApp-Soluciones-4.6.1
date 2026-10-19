Imports System.Linq

Public Class Cl_TipoCarga_Documentos

    Private _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private _Error As String

    Public ReadOnly Property Pro_Error As String
        Get
            Return _Error
        End Get
    End Property

    Public Function Fx_Traer_Tbl_Detalles_Desde_Nvv(_Idmaeedo_Nvv As Integer) As DataTable

        _Error = String.Empty

        Dim Consulta_sql As String

        Consulta_sql = "DECLARE @IdmaeedoNVV INT = " & _Idmaeedo_Nvv & vbCrLf &
                       vbCrLf &
                       ";WITH CTE_Detalles As (" & vbCrLf &
                       "    SELECT" & vbCrLf &
                       "        D.IDMAEDDO," & vbCrLf &
                       "        D.IDMAEEDO," & vbCrLf &
                       "        D.IDRST," & vbCrLf &
                       "        D.ARCHIRST," & vbCrLf &
                       "        0 As Nivel" & vbCrLf &
                       "    FROM MAEDDO D WITH (NOLOCK)" & vbCrLf &
                       "    WHERE D.IDMAEEDO = @IdmaeedoNVV" & vbCrLf &
                       vbCrLf &
                       "    UNION ALL" & vbCrLf &
                       vbCrLf &
                       "    SELECT" & vbCrLf &
                       "        H.IDMAEDDO," & vbCrLf &
                       "        H.IDMAEEDO," & vbCrLf &
                       "        H.IDRST," & vbCrLf &
                       "        H.ARCHIRST," & vbCrLf &
                       "        C.Nivel + 1 As Nivel" & vbCrLf &
                       "    FROM MAEDDO H WITH (NOLOCK)" & vbCrLf &
                       "    INNER JOIN CTE_Detalles C On H.ARCHIRST = 'MAEDDO' And H.IDRST = C.IDMAEDDO" & vbCrLf &
                       ")" & vbCrLf &
                       "SELECT DISTINCT" & vbCrLf &
                       "       C.IDMAEDDO," & vbCrLf &
                       "       C.IDMAEEDO," & vbCrLf &
                       "       C.IDRST," & vbCrLf &
                       "       C.ARCHIRST," & vbCrLf &
                       "       C.Nivel," & vbCrLf &
                       "       E.TIDO," & vbCrLf &
                       "       E.NUDO" & vbCrLf &
                       "FROM CTE_Detalles C" & vbCrLf &
                       "LEFT JOIN MAEEDO E WITH (NOLOCK) On E.IDMAEEDO = C.IDMAEEDO" & vbCrLf &
                       "ORDER BY C.Nivel, C.IDMAEEDO, C.IDMAEDDO" & vbCrLf &
                       "OPTION (MAXRECURSION 32767)"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

        If IsNothing(_Tbl) Then
            _Error = _Sql.Pro_Error
            Return Nothing
        End If

        Return _Tbl

    End Function

    Public Function Fx_Traer_Lista_Idmaeddo_Desde_Nvv(_Idmaeedo_Nvv As Integer) As List(Of Integer)

        _Error = String.Empty

        Dim _Lista_Idmaeddo As New List(Of Integer)
        Dim _Tbl As DataTable = Fx_Traer_Tbl_Detalles_Desde_Nvv(_Idmaeedo_Nvv)

        If IsNothing(_Tbl) Then
            Return _Lista_Idmaeddo
        End If

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Idmaeddo As Integer = Convert.ToInt32(_Fila.Item("IDMAEDDO"))

            If Not _Lista_Idmaeddo.Contains(_Idmaeddo) Then
                _Lista_Idmaeddo.Add(_Idmaeddo)
            End If

        Next

        Return _Lista_Idmaeddo

    End Function

    Public Function Fx_Actualizar_TipoCarga_Desde_Nvv(_Idmaeedo_Nvv As Integer,
                                                      _Nuevo_Tipo_Carga As Integer,
                                                      ByRef _Lista_Idmaeddo As List(Of Integer),
                                                      Optional ByRef _Registros_Actualizados As Integer = 0) As Boolean

        _Error = String.Empty
        _Registros_Actualizados = 0
        _Lista_Idmaeddo = New List(Of Integer)

        If _Nuevo_Tipo_Carga <> 0 AndAlso
           _Nuevo_Tipo_Carga <> 1 AndAlso
           _Nuevo_Tipo_Carga <> 2 Then

            _Error = "El valor de TipoCarga debe ser 0, 1 o 2"
            Return False
        End If

        _Lista_Idmaeddo = Fx_Traer_Lista_Idmaeddo_Desde_Nvv(_Idmaeedo_Nvv)

        If IsNothing(_Lista_Idmaeddo) OrElse Not _Lista_Idmaeddo.Count > 0 Then
            _Error = "No se encontraron IDMAEDDO relacionados a la NVV raíz"
            Return False
        End If

        Dim _Filtro_Idmaeddo As String = Fx_Lista_A_Filtro_In(_Lista_Idmaeddo)

        If String.IsNullOrWhiteSpace(_Filtro_Idmaeddo) Then
            _Error = "No fue posible construir el filtro de IDMAEDDO"
            Return False
        End If

        Dim Consulta_sql As String

        _Registros_Actualizados = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_Det", "Idmaeddo In (" & _Filtro_Idmaeddo & ")")

        '        Consulta_sql = $"
        'Select Count(*) As Registros
        'From {_Global_BaseBk}Zw_Docu_Det
        'Where Idmaeddo In (" & _Filtro_Idmaeddo & ")"

        '        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        '        If IsNothing(_Row) Then
        '            _Error = "No fue posible obtener la cantidad de registros a actualizar"
        '            Return False
        '        End If

        '        _Registros_Actualizados = Convert.ToInt32(_Row.Item("Registros"))

        Consulta_sql = $"
Update {_Global_BaseBk}Zw_Docu_Ent Set 
TipoCarga = {_Nuevo_Tipo_Carga} 
Where Idmaeedo = {_Idmaeedo_Nvv}

Update {_Global_BaseBk}Zw_Docu_Det Set
    TipoCarga = {_Nuevo_Tipo_Carga}
Where Idmaeddo In ({_Filtro_Idmaeddo})"

        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
            _Error = _Sql.Pro_Error
            Return False
        End If

        Return True

    End Function

    Private Function Fx_Lista_A_Filtro_In(_Lista_Idmaeddo As List(Of Integer)) As String

        If IsNothing(_Lista_Idmaeddo) Then
            Return String.Empty
        End If

        If Not _Lista_Idmaeddo.Count > 0 Then
            Return String.Empty
        End If

        Return String.Join(",", _Lista_Idmaeddo.Distinct().OrderBy(Function(_Id) _Id).Select(Function(_Id) _Id.ToString()).ToArray())

    End Function

End Class
