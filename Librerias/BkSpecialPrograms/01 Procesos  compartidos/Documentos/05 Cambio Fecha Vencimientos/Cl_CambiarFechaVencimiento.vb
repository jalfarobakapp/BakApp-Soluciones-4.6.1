Imports DevComponents.DotNetBar

Public Class Cl_CambiarFechaVencimiento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowMaeedo As DataRow
    Dim _TblMaeven As DataTable
    Dim _TblNewMaeven As DataTable
    Public Property TblNewMaeven As DataTable
        Get
            Return _TblNewMaeven
        End Get
        Set(value As DataTable)
            _TblNewMaeven = value
        End Set
    End Property

    Public Property TblMaeven As DataTable
        Get
            Return _TblMaeven
        End Get
        Set(value As DataTable)
            _TblMaeven = value
        End Set
    End Property

    Public Property RowMaeedo As DataRow
        Get
            Return _RowMaeedo
        End Get
        Set(value As DataRow)
            _RowMaeedo = value
        End Set
    End Property

    Public Sub New(_Idmaeedo As Integer)

        Consulta_sql = "SELECT TOP 1 *,DATEDIFF(DD,FEEMDO,FE01VEDO) AS Dias_1er_Vencimiento From MAEEDO WITH ( NOLOCK ) " &
                       "WHERE IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "SELECT *,FEVE AS FECHA_OLD,Cast(0 As Int) As Id_Autoriza_Nomina From MAEVEN WHERE IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "SELECT *,FEVE AS FECHA_OLD,Cast(0 As Int) As Id_Autoriza_Nomina From MAEVEN WHERE 0>1"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, False)

        _RowMaeedo = _Ds.Tables(0).Rows(0)
        _TblMaeven = _Ds.Tables(1)
        _TblNewMaeven = _Ds.Tables(2)

    End Sub

    Sub Actualizar_Vencimientos(_Agregar_Fila As Boolean,
                                _Fecha_1er_Vencimiento As Date,
                                _Cuotas As Integer,
                                _Dias_Entre_Vencimiento As Integer,
                                _CalcularDias As Boolean,
                                _Observa As String)

        _Observa = Mid(_Observa, 1, 50)

        Dim _Idmaeedo As Integer = _RowMaeedo.Item("IDMAEEDO")
        Dim _TotalBrutoDoc As Double = _RowMaeedo.Item("VABRDO")

        Dim _FechaEmision As Date = _RowMaeedo.Item("FEEMDO")

        If _Cuotas = 0 Then _Cuotas = 1

        If _CalcularDias Then
            _Dias_Entre_Vencimiento = DateDiff(DateInterval.Day, _FechaEmision, _Fecha_1er_Vencimiento)
        End If

        Dim Cuotas_(_Cuotas - 1) As Date
        Cuotas_(0) = _Fecha_1er_Vencimiento

        Dim _FechasVenci As Date = _FechaEmision
        Dim _dias As Integer

        Dim _Resultado As Double = _TotalBrutoDoc / _Cuotas
        Dim _Vave As Double = Math.Round(_TotalBrutoDoc / _Cuotas, 0)

        _dias = _Dias_Entre_Vencimiento

        For i = 1 To _Cuotas

            _FechasVenci = DateAdd(DateInterval.Day, _dias, _FechasVenci)
            Cuotas_(i - 1) = _FechasVenci
            _dias = _Dias_Entre_Vencimiento

            If _Agregar_Fila Then

                Dim NewFila As DataRow
                NewFila = _TblNewMaeven.NewRow
                With NewFila

                    If i = _Cuotas Then
                        Dim rS = _Vave * _Cuotas
                        rS = _TotalBrutoDoc - rS
                        rS = _Vave + rS
                        _Vave = rS
                    End If

                    .Item("IDMAEVEN") = 0
                    .Item("IDMAEEDO") = _Idmaeedo
                    .Item("VAVE") = _Vave
                    .Item("ESPGVE") = ""

                    If i = 1 Then
                        .Item("FEVE") = _Fecha_1er_Vencimiento
                    Else
                        .Item("FEVE") = _FechasVenci
                    End If

                    .Item("VAABVE") = 0
                    .Item("OBSERVA") = _Observa
                    .Item("FECHA_OLD") = _FechasVenci

                    _TblNewMaeven.Rows.Add(NewFila)

                End With

            End If

        Next

        'Dtp_FechaUltVencimiento.Value = _FechasVenci

    End Sub

    Function Fx_Grabar_Vencimientos(_Formulario As Form,
                                    _Idmaeedo As Integer,
                                    _TblVencimientos As DataTable,
                                    _RowEncDocumento As DataRow) As Boolean

        Dim _Valor_Bruto_Doc As Double = _RowEncDocumento.Item("VABRDO")
        Dim _Valor_Bruto_Ven As Double = _TblVencimientos.Compute("Sum(VAVE)", "1>0")

        If _Valor_Bruto_Doc <> _Valor_Bruto_Ven Then
            MessageBoxEx.Show(_Formulario, "La sumatoria de los vencimientos no corresponde al total del documento" & vbCrLf &
                              "Modificaciones no serán incorporadas",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Consulta_sql = String.Empty
        Dim _Delete = False

        For Each _Fila As DataRow In _TblVencimientos.Rows

            Dim _Idmaeven = _Fila.Item("IDMAEVEN")
            Dim _Vave = _Fila.Item("VAVE")
            Dim _Espegve = _Fila.Item("ESPGVE")
            Dim _Feve = Format(_Fila.Item("FEVE"), "yyyyMMdd")
            Dim _Vaabve = _Fila.Item("VAABVE")
            Dim _Fecha_old = _Fila.Item("FECHA_OLD")
            Dim _Observa = Trim(_Fila.Item("OBSERVA"))
            Dim _Id_Autoriza_Nomina = NuloPorNro(_Fila.Item("Id_Autoriza_Nomina"), 0)

            If _Vave = _Vaabve Then
                _Espegve = "C"
            End If

            If CBool(_Idmaeven) Then

                Consulta_sql += "Update MAEVEN SET" & Space(1) &
                                "VAVE = " & _Vave & ",ESPGVE = '" & _Espegve & "'," &
                                "FEVE = '" & _Feve & "',VAABVE = " & _Vaabve & ",OBSERVA = '" & _Observa & "'" & vbCrLf &
                                "Where IDMAEVEN = " & _Idmaeven & vbCrLf & vbCrLf

            Else

                If Not _Delete Then
                    Consulta_sql += "Delete MAEVEN Where IDMAEEDO = " & _Idmaeedo & vbCrLf & vbCrLf
                End If

                _Delete = True

                Consulta_sql += "Insert Into MAEVEN (IDMAEEDO,FEVE,ESPGVE,VAVE,VAABVE,ARCHIRST,PORESTPAG,OBSERVA)" & vbCrLf &
                                "values (" & _Idmaeedo & ",'" & _Feve & "',''," & De_Num_a_Tx_01(_Vave, False, 5) & ",0,'',0,'" & _Observa & "')" & vbCrLf & vbCrLf

            End If

            If Not String.IsNullOrEmpty(_Observa) Then

                Dim _HoraGrab = Hora_Grab_fx(False)

                Consulta_sql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                "('MAEEDO'," & _Idmaeedo & ",'',0,'" & FUNCIONARIO &
                                "',GetDate(),'FECHA_VENC','CAMBIO','" & _Observa &
                                "','" & Format(_Fecha_old, "yyyyMMdd") & "'," & _HoraGrab & ")" & vbCrLf & vbCrLf
            End If

            If CBool(_Id_Autoriza_Nomina) Then

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det_Eli (Id_Autoriza,Idmaeedo,Idmaeven,Saldo,Observacion)
                                 Select Id_Autoriza,Idmaeedo,Idmaeven,Saldo,'Se modifica fecha de vencimento desde Bakapp por (" & FUNCIONARIO & ")' 
                                 From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det
                                 Where Id_Autoriza = " & _Id_Autoriza_Nomina & " And Idmaeven = " & _Idmaeven & vbCrLf &
                                "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Id_Autoriza = " & _Id_Autoriza_Nomina & " And Idmaeven = " & _Idmaeven & vbCrLf & vbCrLf

            End If

        Next

        Consulta_sql += vbCrLf &
                       "Update MAEEDO SET FE01VEDO = (Select Min(FEVE) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                       "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "Update MAEEDO SET FEULVEDO = (Select Max(FEVE) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                       "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "Update MAEEDO SET NUVEDO = (Select Count(*) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                       "Where IDMAEEDO = " & _Idmaeedo

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Return True
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Return True

    End Function


    Function Fx_CambioFechaConFincred() As Boolean

        Dim _IdmaeedoFCV = _RowMaeedo.Item("IDMAEEDO")

        Consulta_sql = "Select Top 1 IDMAEEDO From MAEEDO Where IDMAEEDO In (Select IDMAEEDO From MAEDDO Where IDMAEDDO In " &
                       "(Select IDRST From MAEDDO Where IDMAEEDO = " & _IdmaeedoFCV & "))"
        Dim _RowNVV As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_RowNVV) Then
            Return False
        End If

        Dim _IdmaeedoNVV As Integer = _RowNVV.Item("IDMAEEDO")

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Fincred_TramaRespuesta", "Idmaeedo = " & _IdmaeedoNVV)

        If CBool(_Reg) Then

            Consulta_sql = "Select Tresp.Nudo,Tresp.Json," & vbCrLf &
               "Case When TDoc.Fecha_vencimiento Is not null Then " &
               "CAST(''+Substring(TDoc.Fecha_vencimiento,1,2)+'/'+Substring(TDoc.Fecha_vencimiento,3,2)+'/'+Substring(TDoc.Fecha_vencimiento,5,4)+'' As datetime) Else Null End As Fecha_vencimiento" & vbCrLf &
               ",Isnull(TDoc.Autorizacion,'Rechazado') As Autorizacion" & vbCrLf &
               "From " & _Global_BaseBk & "Zw_Fincred_TramaRespuesta Tresp" & vbCrLf &
               "Inner Join " & _Global_BaseBk & "Zw_Fincred_Documentos TDoc On TDoc.Id_TR = Tresp.Id" & vbCrLf &
               "Where Tresp.Idmaeedo = " & _IdmaeedoNVV

            Dim _RowFincred As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
            Dim _Fecha_vencimiento As Date
            Dim _Autorizacion As String

            If Not IsNothing(_RowFincred) Then

                _Autorizacion = _RowFincred.Item("Autorizacion")

                If _Autorizacion <> "Rechazado" Then

                    _Fecha_vencimiento = _RowFincred.Item("Fecha_vencimiento")

                    Actualizar_Vencimientos(True, _Fecha_vencimiento, 1, 0, True, "Restablecida por Fincred: " & _Autorizacion)

                    If Fx_Grabar_Vencimientos(Nothing, _IdmaeedoFCV, TblNewMaeven, RowMaeedo) Then
                        Return True
                    End If

                End If

            End If

        End If

    End Function

End Class
