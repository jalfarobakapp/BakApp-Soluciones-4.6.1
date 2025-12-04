Imports DevComponents.DotNetBar

Public Class Frm_CruceAntiNoVinculados_Filtro

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Private _Tbl_Filtro_Entidad As DataTable

    ' Campo para guardar la lista de códigos extraídos desde _Tbl_Filtro_Entidad
    Public Property Lista_Entidades As List(Of CodigoDescripcionItem)

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_CruceAntiNoVinculados_Filtro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cmb_MayorMenorQue.Enabled = False
        Input_MayorMenorQue.Enabled = False

        Dim _Arr_MayorMenorQue(,) As String = {{"", ""},
                                              {"MYQ", "Mayor o igual que ->"},
                                              {"MNQ", "Menor o igual que ->"}}
        Sb_Llenar_Combos(_Arr_MayorMenorQue, Cmb_MayorMenorQue)
        Cmb_MayorMenorQue.SelectedValue = ""

        Dim _Fecha As Date = FechaDelServidor()

        'Dim _PrimerDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha), 1)
        'Dim _UltimoDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha) + 1, 0)

        Dtp_FechaDesde.Value = Primerdiadelmes(_Fecha)
        Dtp_FechaHasta.Value = ultimodiadelmes(_Fecha)

    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click


        If Chk_MayorMenorQue.Checked AndAlso Cmb_MayorMenorQue.SelectedValue.ToString = "" Then
            MessageBoxEx.Show(Me, "Debe seleccionar una opción en el filtro 'Mayor/Menor que'", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Procesar_Informe()

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_CruceAntiNoVinculados(_Mensaje.Tag)
        'Fm.Lista_Idmaedpce = CType(_Mensaje.Tag, List(Of Integer))
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True
        Barra_Progreso.Visible = True
        Barra_Progreso.Value = 0
        Barra_Progreso.Minimum = 0
        Me.Refresh()

    End Sub

    Private Sub Rdb_Entidades_Algunas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Entidades_Algunas.CheckedChanged

        If Not Rdb_Entidades_Algunas.Checked Then
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, "", Nothing, False) Then

            _Tbl_Filtro_Entidad = _Filtrar.Pro_Tbl_Filtro

            ' Crear y llenar la lista de códigos desde _Tbl_Filtro_Entidad (columna "Codigo")

            Lista_Entidades = _Filtrar.Pro_Lista_CodigoDescripcion

            ' _Lista_Codigos_Entidad ahora contiene los códigos; usar según necesidad más abajo

        Else
            Rdb_Entidades_Todas.Checked = True
        End If

    End Sub

    ' Plan (pseudocódigo detallado):
    ' 1) Preparar variables y construir el SQL como antes.
    ' 2) Antes de ejecutar la consulta, deshabilitar el formulario (Me.Enabled = False),
    '    mostrar la barra de progreso (Me.Barra_Progreso.Visible = True), poner valor 0,
    '    y actualizar el Lbl_Status con "Cargando registros...".
    ' 3) Ejecutar la consulta que devuelve un DataTable.
    ' 4) Si el DataTable tiene filas:
    '    - Inicializar la lista de ids.
    '    - Configurar Barra_Progreso.Maximum = número de filas y Value = 0.
    '    - Recorrer cada fila:
    '        * Extraer y convertir IDMAEDPCE a Integer si es posible.
    '        * Agregarlo a la lista.
    '        * Incrementar Barra_Progreso.Value y actualizar Lbl_Status con progreso (por ejemplo "Procesando X / Y").
    '        * Llamar Application.DoEvents() para que la UI responda.
    '    - Al finalizar fijar Mensaje.EsCorrecto = True y mensaje de información.
    ' 5) Si no hay filas, asignar Mensaje.EsCorrecto = False y texto correspondiente.
    ' 6) En Catch capturar error y asignar Mensaje.EsCorrecto = False.
    ' 7) En Finally siempre:
    '    - Ocultar la barra de progreso, limpiar Lbl_Status y volver a habilitar el formulario.
    '    - Asegurar que la barra quede en 0.
    ' 8) Devolver _Mensaje con la lista en Tag.
    '
    ' Nota: se usa Application.DoEvents() para actualizar la UI ya que no se está usando un hilo en segundo plano.
    Function Fx_Procesar_Informe() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Lista_Idmaedpce As List(Of Integer)

        Try

            _Lista_Idmaedpce = New List(Of Integer)

            Dim _Filtro_Entidad As String = String.Empty
            Dim _SoloClienteConDocPendientesPago As String = String.Empty
            Dim _SinCruceAutomatico As String = String.Empty
            Dim _SoloPagosPesos As String = String.Empty
            Dim _SoloMayorMenorQue As String = String.Empty

            If Rdb_Entidades_Algunas.Checked AndAlso Lista_Entidades IsNot Nothing AndAlso Lista_Entidades.Count > 0 Then
                _Filtro_Entidad = Generar_Filtro_IN_Lista(Lista_Entidades, False, "'")
                _Filtro_Entidad = "And DPCE.ENDP In " & _Filtro_Entidad
            End If

            If Chk_SoloClienteConDocPendientesPago.Checked Then
                _SoloClienteConDocPendientesPago = $"And ENTIDAD In (Select ENDO From MAEEDO Where EMPRESA = '{Mod_Empresa}' AND TIDO In ('FCV','BLV') And ESPGDO = 'P' And ENDO In (Select ENTIDAD From #INFANTIC))"
            End If

            If Chk_SinCruceAutomatico.Checked Then
                _SinCruceAutomatico = "And DPCE.IDRSD = 0"
            End If

            If Chk_SoloPagosPesos.Checked Then
                _SoloPagosPesos = "And DPCE.MODP = '$'"
            End If

            If Chk_MayorMenorQue.Checked Then
                Dim _Valor As Double = NuloPorNro(Input_MayorMenorQue.Value, 0)
                If Cmb_MayorMenorQue.SelectedValue.ToString = "MYQ" Then
                    _SoloMayorMenorQue = $"And (CASE DPCE.TIMODP WHEN 'E' THEN 0 ELSE DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP END) >= {_Valor}"
                ElseIf Cmb_MayorMenorQue.SelectedValue.ToString = "MNQ" Then
                    _SoloMayorMenorQue = $"And (CASE DPCE.TIMODP WHEN 'E' THEN 0 ELSE DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP END) <= {_Valor}"
                End If
            End If

            Consulta_Sql = $"Select IDMAEDPCE,ESASDP,VAVUDP,'TIPO'=DPCE.TIDP,'NUMERO'=DPCE.NUDP,'ENTIDAD'=DPCE.ENDP,'EMISION'=DPCE.FEEMDP,'VENCIM'=DPCE.FEVEDP,'GLOSA'=DPCE.REFANTI,DPCE.TIMODP,DPCE.TAMODP AS TC,
				DPCE.MODP,DPCE.VADP,DPCE.VAASDP,'VALOR' =CASE DPCE.TIMODP WHEN 'E' THEN 0 ELSE DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP END,
				'VALORD'=CASE DPCE.TIMODP WHEN 'E' THEN DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP ELSE 0 END--,
				--'NOMBRE'=( Select TOP 1 EN.NOKOEN FROM MAEEN EN WITH ( NOLOCK ) WHERE EN.KOEN=DPCE.ENDP AND EN.TIPOSUC='P' ), NUCUDP
				INTO #INFANTIC  
				FROM MAEDPCE DPCE WITH ( NOLOCK )  
				WHERE DPCE.TIDP IN ('EFV','CHV','TJV','LTV','PAV','DEP','CRV','ATB') -- ,'ncv','fcv','fdv')
				AND DPCE.FEEMDP BETWEEN '{ Format(Dtp_FechaDesde.Value, "yyyyMMdd")}' And '{ Format(Dtp_FechaHasta.Value, "yyyyMMdd")}'
				AND DPCE.EMPRESA='{Mod_Empresa}' AND DPCE.ESASDP='P' AND ROUND(DPCE.VADP,2)-ROUND(DPCE.VAASDP,2)-ROUND(DPCE.VAVUDP,2)<>0.0  
				{_SinCruceAutomatico}      
                {_SoloPagosPesos}
                {_Filtro_Entidad}
                {_SoloMayorMenorQue}
                
				DELETE FROM #INFANTIC WHERE VALOR = 0.0 AND VALORD = 0.0 

				Select * From #INFANTIC
				Where 1>0
                {_SoloClienteConDocPendientesPago}                
                Order By ENTIDAD
				Drop Table #INFANTIC"
            ' Preparar UI para proceso largo
            Try
                Me.Enabled = False
                If Me.Lbl_Status IsNot Nothing Then
                    Me.Lbl_Status.Text = "Cargando registros..."
                End If
                If Me.Barra_Progreso IsNot Nothing Then
                    Me.Barra_Progreso.Visible = True
                    Me.Barra_Progreso.Value = 0
                    Me.Barra_Progreso.Minimum = 0
                End If
                Application.DoEvents()
            Catch exui As Exception
                ' Si por alguna razón los controles no existen, continuar sin bloquear
            End Try

            Me.Refresh()

            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            If _Tbl IsNot Nothing AndAlso _Tbl.Rows.Count > 0 Then

                _Lista_Idmaedpce = New List(Of Integer)

                ' Configurar progreso
                If Me.Barra_Progreso IsNot Nothing Then
                    Me.Barra_Progreso.Maximum = _Tbl.Rows.Count
                    If Me.Barra_Progreso.Maximum < 1 Then
                        Me.Barra_Progreso.Maximum = 1
                    End If
                    Me.Barra_Progreso.Value = 0
                End If

                Dim _Contador As Integer = 0

                For Each _Row As DataRow In _Tbl.Rows

                    If Not IsDBNull(_Row("IDMAEDPCE")) Then
                        Dim _IdStr As String = _Row("IDMAEDPCE").ToString
                        Dim _Id As Integer
                        If Integer.TryParse(_IdStr, _Id) Then
                            _Lista_Idmaedpce.Add(_Id)
                        End If
                    End If

                    _Contador += 1

                    ' Actualizar barra y estado
                    Try
                        If Me.Barra_Progreso IsNot Nothing Then
                            Me.Barra_Progreso.Value = Math.Min(Me.Barra_Progreso.Maximum, _Contador)
                        End If
                        If Me.Lbl_Status IsNot Nothing Then
                            Me.Lbl_Status.Text = $"Cargando registros... {_Contador} / {_Tbl.Rows.Count}"
                        End If
                        Application.DoEvents()
                    Catch exui As Exception
                        ' Ignorar errores de UI
                    End Try

                Next

                Lbl_Status.Text = "Preparando filtros para el informe, por favor espere..."
                Me.Barra_Progreso.Visible = True
                Me.Refresh()

                Dim _Filtro_Idmaedpce As String = Generar_Filtro_IN_Lista(_Lista_Idmaedpce, True, "", Me.Barra_Progreso)

                _Mensaje.Tag = _Filtro_Idmaedpce

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Procesar informe"
                _Mensaje.Mensaje = "Se encontraron " & _Lista_Idmaedpce.Count & " registros"
                _Mensaje.Icono = MessageBoxIcon.Information

            Else
                ' No hay registros: _Lista_Idmaedpce queda como lista vacía
                _Mensaje.Detalle = "Procesar informe"
                Throw New InvalidOperationException("No hay registros que mostrar")
            End If

            '_Mensaje.Tag = _Lista_Idmaedpce

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        Finally
            ' Restaurar UI siempre
            Try
                If Me.Barra_Progreso IsNot Nothing Then
                    Me.Barra_Progreso.Value = 0
                    'Me.Barra_Progreso.Visible = False
                End If
                If Me.Lbl_Status IsNot Nothing Then
                    Me.Lbl_Status.Text = String.Empty
                End If
                Me.Enabled = True
                Application.DoEvents()
            Catch exui As Exception
                ' Ignorar errores al restaurar UI
            End Try
        End Try

        Return _Mensaje

    End Function

    Private Sub Chk_MayorMenorQue_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_MayorMenorQue.CheckedChanged
        Cmb_MayorMenorQue.Enabled = Chk_MayorMenorQue.Checked
        Input_MayorMenorQue.Enabled = Chk_MayorMenorQue.Checked
    End Sub
End Class
