Imports DevComponents.DotNetBar

Public Class Frm_CruceAntiNoVinculados_Filtro

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Private _Tbl_Filtro_Entidad As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_CruceAntiNoVinculados_Filtro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Fecha As Date = FechaDelServidor()

        'Dim _PrimerDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha), 1)
        'Dim _UltimoDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha) + 1, 0)

        Dtp_FechaDesde.Value = Primerdiadelmes(_Fecha)
        Dtp_FechaHasta.Value = ultimodiadelmes(_Fecha)

    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Procesar_Informe()

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_CruceAntiNoVinculados()
        Fm.Lista_Idmaedpce = CType(_Mensaje.Tag, List(Of Integer))
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Rdb_Entidades_Algunas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Entidades_Algunas.CheckedChanged

        If Not Rdb_Entidades_Algunas.Checked Then
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, "", Nothing, False) Then

            _Tbl_Filtro_Entidad = _Filtrar.Pro_Tbl_Filtro

        Else
            Rdb_Entidades_Todas.Checked = True
        End If

    End Sub

    Function Fx_Procesar_Informe() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Lista_Idmaedpce As List(Of Integer)

        Try

            _Lista_Idmaedpce = New List(Of Integer)

            Consulta_Sql = $"SELECT IDMAEDPCE,ESASDP,VAVUDP,'TIPO'=DPCE.TIDP,'NUMERO'=DPCE.NUDP,'ENTIDAD'=DPCE.ENDP,'EMISION'=DPCE.FEEMDP,'VENCIM'=DPCE.FEVEDP,'GLOSA'=DPCE.REFANTI,DPCE.TIMODP,DPCE.TAMODP AS TC,
				DPCE.MODP,DPCE.VADP,DPCE.VAASDP,'VALOR' =CASE DPCE.TIMODP WHEN 'E' THEN 0 ELSE DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP END,
				'VALORD'=CASE DPCE.TIMODP WHEN 'E' THEN DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP ELSE 0 END,
				'NOMBRE'=( SELECT TOP 1 EN.NOKOEN FROM MAEEN EN WITH ( NOLOCK ) WHERE EN.KOEN=DPCE.ENDP AND EN.TIPOSUC='P' ), NUCUDP
				INTO #INFANTIC  
				FROM MAEDPCE DPCE WITH ( NOLOCK )  
				WHERE DPCE.TIDP IN ('EFV','CHV','TJV','LTV','PAV','DEP','CRV','ATB','ncv','fcv','fdv')
				AND DPCE.FEEMDP BETWEEN '{ Format(Dtp_FechaDesde.Value, "yyyyMMdd")}' And '{ Format(Dtp_FechaHasta.Value, "yyyyMMdd")}'
				AND DPCE.EMPRESA='{Mod_Empresa}' AND DPCE.ESASDP='P' AND ROUND(DPCE.VADP,2)-ROUND(DPCE.VAASDP,2)-ROUND(DPCE.VAVUDP,2)<>0.0  
				--AND DPCE.IDRSD = 0
				
				DELETE FROM #INFANTIC WHERE VALOR = 0.0 AND VALORD = 0.0 

				Select * From #INFANTIC
				--Where ENTIDAD = '78074915'
                Where ENTIDAD In (Select ENDO From MAEEDO Where EMPRESA = '{Mod_Empresa}' AND TIDO In ('FCV','BLV') And VAABDO < VABRDO And ENDO In (Select ENTIDAD From #INFANTIC))
				Order By ENTIDAD
				Drop Table #INFANTIC"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            If _Tbl IsNot Nothing AndAlso _Tbl.Rows.Count > 0 Then

                _Lista_Idmaedpce = New List(Of Integer)

                For Each _Row As DataRow In _Tbl.Rows

                    If Not IsDBNull(_Row("IDMAEDPCE")) Then
                        Dim _IdStr As String = _Row("IDMAEDPCE").ToString
                        Dim _Id As Integer
                        If Integer.TryParse(_IdStr, _Id) Then
                            _Lista_Idmaedpce.Add(_Id)
                        End If
                    End If

                Next

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Procesar informe"
                _Mensaje.Mensaje = "Se encontraron " & _Lista_Idmaedpce.Count & " registros"
                _Mensaje.Icono = MessageBoxIcon.Information

                ' Aquí ya tienes _Lista_Idmaedpce con los ID recogidos.
                ' Si necesitas asignarlo a un campo de la clase, hacerlo aquí.
                ' Ejemplo: Me.Pro_Lista_Idmaedpce = _Lista_Idmaedpce

            Else
                ' No hay registros: _Lista_Idmaedpce queda en Nothing.
                ' Si prefieres lista vacía en vez de Nothing, descomenta la siguiente línea:
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No hay registros que mostrar"
                _Mensaje.Detalle = "Procesar informe"
            End If

            _Mensaje.Tag = _Lista_Idmaedpce

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

End Class
