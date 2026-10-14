Public Class Cl_Ferias

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

    End Sub

    Private Function Fx_Es_Nota_De_Venta(_Tido As String) As Boolean
        Return _Tido = "NVV"
    End Function

    Private Function Fx_Es_Factura_De_Venta(_Tido As String) As Boolean
        Return _Tido = "FCV" OrElse
               _Tido = "FDB" OrElse
               _Tido = "FDV" OrElse
               _Tido = "FEV" OrElse
               _Tido = "FVL" OrElse
               _Tido = "FVT" OrElse
               _Tido = "FVX" OrElse
               _Tido = "FVZ"
    End Function

    Private Function Fx_Traer_Documento(_Idmaeedo As Integer) As DataRow

        Consulta_sql = "Select Top 1 IDMAEEDO,TIDO,NUDO From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Return _Sql.Fx_Get_DataRow(Consulta_sql)

    End Function

    Private Function Fx_Documento_Esta_Cerrado(_Idmaeedo As Integer) As Boolean

        Consulta_sql = "Select Top 1 1 As Abierta" & vbCrLf &
                       "From MAEDDO" & vbCrLf &
                       "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "And (Isnull(ESLIDO,'') <> 'C' Or Round(Isnull(CAPRAD1,0) + Isnull(CAPREX1,0),5) <> Round(Isnull(CAPRCO1,0),5))"

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Return IsNothing(_Row)

    End Function

    Private Function Fx_Traer_Factura_Asociada_A_NVV(_Idmaeedo_Nvv As Integer) As DataRow

        Consulta_sql = "Select Top 1 H.IDMAEEDO,H.TIDO,H.NUDO" & vbCrLf &
                       "From MAEDDO D_Fac With (Nolock)" & vbCrLf &
                       "Inner Join MAEEDO H On H.IDMAEEDO = D_Fac.IDMAEEDO" & vbCrLf &
                       "Where D_Fac.ARCHIRST = 'MAEDDO'" & vbCrLf &
                       "And D_Fac.IDRST In (Select IDMAEDDO From MAEDDO With (Nolock) Where IDMAEEDO = " & _Idmaeedo_Nvv & ")" & vbCrLf &
                       "And H.TIDO In ('FCV','FDB','FDV','FEV','FVL','FVT','FVX','FVZ')"

        Return _Sql.Fx_Get_DataRow(Consulta_sql)

    End Function

    Private Function Fx_Traer_NCV_Asociadas_A_Factura(_Idmaeedo_Factura As Integer) As DataTable

        Consulta_sql = "Select Distinct H_Ncv.IDMAEEDO,H_Ncv.TIDO,H_Ncv.NUDO" & vbCrLf &
                       "From MAEDDO D_Ncv With (Nolock)" & vbCrLf &
                       "Inner Join MAEEDO H_Ncv On H_Ncv.IDMAEEDO = D_Ncv.IDMAEEDO" & vbCrLf &
                       "Where D_Ncv.ARCHIRST = 'MAEDDO'" & vbCrLf &
                       "And D_Ncv.IDRST In (Select IDMAEDDO From MAEDDO With (Nolock) Where IDMAEEDO = " & _Idmaeedo_Factura & ")" & vbCrLf &
                       "And H_Ncv.TIDO = 'NCV'"

        Return _Sql.Fx_Get_DataTable(Consulta_sql)

    End Function

    Public Function Fx_Validar_Documento_Para_Asociar_Feria(_Idmaeedo As Integer,
                                                            ByRef _Mensaje As String) As Boolean

        Dim _Row_Documento As DataRow = Fx_Traer_Documento(_Idmaeedo)

        If IsNothing(_Row_Documento) Then
            _Mensaje = "No se encontró el documento."
            Return False
        End If

        Dim _Tido As String = _Row_Documento.Item("TIDO").ToString.Trim
        Dim _Nudo As String = _Row_Documento.Item("NUDO").ToString.Trim

        If Fx_Documento_Esta_Cerrado(_Idmaeedo) Then
            _Mensaje = "No es posible asociar una feria al documento " & _Tido & "-" & _Nudo &
                       " porque el documento está completamente cerrado."
            Return False
        End If

        If Fx_Es_Nota_De_Venta(_Tido) Then

            Dim _Row_Factura As DataRow = Fx_Traer_Factura_Asociada_A_NVV(_Idmaeedo)

            If Not IsNothing(_Row_Factura) Then

                Dim _Tido_Fac As String = _Row_Factura.Item("TIDO").ToString.Trim
                Dim _Nudo_Fac As String = _Row_Factura.Item("NUDO").ToString.Trim

                _Mensaje = "La nota de venta " & _Tido & "-" & _Nudo &
                           " ya está asociada a la factura " & _Tido_Fac & "-" & _Nudo_Fac & "." & vbCrLf & vbCrLf &
                           "Debe asociar la feria a la factura y no a la nota de venta."

                Return False

            End If

        End If

        _Mensaje = String.Empty
        Return True

    End Function

    Public Function Fx_Traer_Documentos_Para_Asociar_Feria(_Idmaeedo As Integer) As DataTable

        Dim _Tbl As New DataTable

        _Tbl.Columns.Add("Idmaeedo", GetType(Integer))
        _Tbl.Columns.Add("Tido", GetType(String))
        _Tbl.Columns.Add("Nudo", GetType(String))

        Dim _Row_Documento As DataRow = Fx_Traer_Documento(_Idmaeedo)

        If IsNothing(_Row_Documento) Then
            Return _Tbl
        End If

        Dim _Tido As String = _Row_Documento.Item("TIDO").ToString.Trim
        Dim _Nudo As String = _Row_Documento.Item("NUDO").ToString.Trim

        _Tbl.Rows.Add(_Idmaeedo, _Tido, _Nudo)

        If Fx_Es_Factura_De_Venta(_Tido) Then

            Dim _Tbl_Ncv As DataTable = Fx_Traer_NCV_Asociadas_A_Factura(_Idmaeedo)

            For Each _Fila As DataRow In _Tbl_Ncv.Rows

                Dim _Idmaeedo_Ncv As Integer = Convert.ToInt32(_Fila.Item("IDMAEEDO"))

                If _Tbl.Select("Idmaeedo = " & _Idmaeedo_Ncv).Length = 0 Then
                    _Tbl.Rows.Add(_Idmaeedo_Ncv,
                                  _Fila.Item("TIDO").ToString.Trim,
                                  _Fila.Item("NUDO").ToString.Trim)
                End If

            Next

        End If

        Return _Tbl

    End Function

End Class
