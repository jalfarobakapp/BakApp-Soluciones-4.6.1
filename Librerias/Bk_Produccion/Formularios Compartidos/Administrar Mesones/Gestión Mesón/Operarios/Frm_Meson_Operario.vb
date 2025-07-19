
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Meson_Operario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigoob As String
    Dim _CodMeson As String
    Dim _CodMeson_Anterior As String

    Dim _Gestion_Operario As Boolean

    Dim _Tbl_Mesones As DataTable
    Dim _Tbl_Maquina As DataTable

    Dim _Cerrar_automaticamente As Boolean

    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
    Dim _MesonAbierto As String

    Public Property Pro_Cerrar_automaticamente As Boolean
        Get
            Return _Cerrar_automaticamente
        End Get
        Set(value As Boolean)
            _Cerrar_automaticamente = value

            If _Cerrar_automaticamente Then
                Tiempo_Cierre_Automatico.Enabled = True
                Tiempo_Cierre_Automatico.Interval = (1000 * 5) * 60
            End If

        End Set
    End Property

    Public Property Pro_Gestion_Operario As Boolean
        Get
            Return _Gestion_Operario
        End Get
        Set(value As Boolean)
            _Gestion_Operario = value
        End Set
    End Property

    Public Property Pro_Tbl_Mesones As DataTable
        Get
            Return _Tbl_Mesones
        End Get
        Set(value As DataTable)
            _Tbl_Mesones = value
        End Set
    End Property

    Public Sub New(Codigoob As String,
                   Gestion_Operario As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Productos_En_Meson, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Maquinas_Meson, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Codigoob = Codigoob
        _Gestion_Operario = Gestion_Operario

        Tiempo_Actualizacion.Interval = 1000 * 60
        'Tiempo_Actualizacion.Stop()

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Stx_Etx.FocusHighlightEnabled = False
        End If

        Dim pantalla As System.Windows.Forms.Screen = System.Windows.Forms.Screen.PrimaryScreen

        If pantalla.Bounds.Width <= 1024 Then

            'Me.Size = New System.Drawing.Size(CInt(pantalla.Bounds.Width.ToString()), CInt(Me.Bounds.Height.ToString()))
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Size = New System.Drawing.Size(1000, CInt(Me.Bounds.Height.ToString()))

            Sb_Formato_Generico_Grilla(Grilla_Productos_En_Meson, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Both, True, False, False)
            Sb_Formato_Generico_Grilla(Grilla_Maquinas_Meson, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Both, True, False, False)

        End If

        Sb_Actualizar_Cmb_Mesones()

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdc_Mesones Set Abierto = 0,NombreEquipo_Abierto = '',Abierto_FechaHora = Null,Codigoob_Abierto = '' 
                        Where NombreEquipo_Abierto = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Meson_Gestion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Lbl_Fin_Trabajos.Visible = _Gestion_Operario
        Txt_Stx_Etx.Visible = _Gestion_Operario
        Imagen_Barra.Visible = _Gestion_Operario

        AddHandler Grilla_Productos_En_Meson.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Maquinas_Meson.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Productos_En_Meson.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Maquinas_Meson.MouseDown, AddressOf Sb_Grilla_Maquinas_Meson_MouseDown

        Sb_InsertarBotonenGrilla(Grilla_Productos_En_Meson, "Btn_Ico", "Ico", "Inf.", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grillas()

        AddHandler Cmb_Mesones.SelectedIndexChanged, AddressOf Sb_Cmb_Mesones_SelectedIndexChanged

        Consulta_sql = "Select * From PMAEOB Where CODIGOOB = '" & _Codigoob & "'"
        Dim _Row_Operario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me.Text = "OPERARIO: " & _Codigoob & " - " & UCase(_Row_Operario.Item("NOMBREOB"))
        Tiempo_Actualizacion.Start()

        Me.ActiveControl = Txt_Stx_Etx

    End Sub

    Sub Sb_Reorganizar_Indicies()

        Consulta_sql = "
                    ALTER INDEX [PK_Zw_Pdp_MaquinaVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos_1] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos_2] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos_6] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)

                    ALTER INDEX [PK_Zw_Pdp_MaquinaVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos_1] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos_2] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MaquinaVsProductos_6] ON " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )

                    ALTER INDEX [PK_Zw_Pdc_MesonVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos_1] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos_2] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos_3] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)

                    ALTER INDEX [PK_Zw_Pdc_MesonVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos_1] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos_2] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )
                    ALTER INDEX [IX_Zw_Pdp_MesonVsProductos_3] ON " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos REORGANIZE  WITH ( LOB_COMPACTION = ON )"

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_Actualizar_Cmb_Mesones()

        Consulta_sql = "Select Tabla1.Codmeson As Padre, Tabla1.Nommeson As Hijo,Tabla1.*,Isnull(NOMBREOB,'') As Nombreob " & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdc_Mesones as Tabla1" & vbTab &
                       "Inner Join " & _Global_BaseBk & "[Zw_Pdc_MesonVsOperario] as Tabla2 ON Tabla2.Codmeson=Tabla1.Codmeson" & vbCrLf &
                       "Left Join PMAEOB On CODIGOOB = Codigoob_Abierto" & vbCrLf &
                       "Where Activo = 1 AND Codigoob = '" & _Codigoob & "'" & vbCrLf &
                       "Order by Nommeson"

        _Tbl_Mesones = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Convert.ToBoolean(_Tbl_Mesones.Rows.Count) Then

            caract_combo(Cmb_Mesones)
            Cmb_Mesones.DataSource = _Tbl_Mesones
            _CodMeson = _Tbl_Mesones.Rows(0).Item("Padre")
            Cmb_Mesones.SelectedValue = _CodMeson

        End If

    End Sub

    Sub Sb_Actualizar_Grilla_Mesones_Espera(_Codmeson As String)

        Consulta_sql = "Select Cast(0 As Bit) As Chk,IdMeson, Codmeson,POTE.ESTADO,Estado,Ms.Idpote,Idpotpr,Substring(Ms.Numot,6,10) As Numot,Nreg,
                        Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) As SubOt,
                        --REFERENCIA As Referencia,
                        Case Ms.Reproceso When 1 Then Rtrim(Ltrim(REFERENCIA)) + ' (Reproceso...)' Else REFERENCIA End As Referencia,
                        Codigo,Operacion,Nombreop,Glosa,Fecha_Asignacion As Fecha,
                        DATEDIFF(DD,FIOT,GETDATE()) As Dias,DATEDIFF(DD,Fecha_Asignacion,GETDATE()) As Dias_En_Meson,Fecha_Asignacion As Hora,
	                    Orden_Meson,Orden_Potpr,Fabricar,Fabricar-Fabricando As Fabricar_New,Fabricado,Fabricando,Saldo_Fabricar,Porc_Avance_Saldo_Fab,
                        (Saldo_Fabricar-Fabricando)-Cant_Reproceso As Saldo_Fabricar_New,Idpotl,Idpotpr,CODMAQOT,Cast('' As Varchar) As Tiempo_En_Meson,
                        Isnull(Pd.Grado,0) AS Grado,Case Grado When 0 Then 3 Else Grado End Orden,Reproceso,Cant_Reproceso,
						POTL.NIVELSUP,
						Potl2.CODIGO As Codigo_Padre,Potl2.IDPOTL As Idpotl_Padre,
					    Isnull(Plcom.ARCHIRST,'') As Archirst_Doc_Comercial,
						Isnull(Plcom.IDRST,0) As Id_Doc_Comerial,
						Isnull(Plcom.DESDE,'') As Tido_Doc_Comercial,
						Isnull(Plcom.NUMECOTI,'') As Nudo_Doc_Comercial,
						Isnull(Ddo.KOFULIDO,'') As Cod_Vendedor,
						Isnull(NOKOFU,'') As Vendedor

                        From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Ms
	                        Inner Join POTPR ON Idpotpr=IDPOTPR
		                        Inner Join POTE ON Idpote=IDPOTE
			                        Left Join " & _Global_BaseBk & "Zw_Pdp_OT_Prioridad Pd ON Pd.Idpote=IDPOTE
				                        Left Join POTL On Idpotl = POTL.IDPOTL
					                        Left Join POTL Potl2 On POTL.NIVELSUP = Potl2.NREG And POTL.NUMOT = Potl2.NUMOT
						                        Left Join POTLCOM Plcom On Potl2.IDPOTL = Plcom.IDPOTL
							                        Left Join MAEDDO Ddo On Ddo.IDMAEDDO = Plcom.IDRST
								                        Left Join TABFU On KOFU = Ddo.KOFULIDO 

                        Where Ms.Codmeson='" & _Codmeson & "' And Ms.Estado In ('PD','DM') And POTE.ESTADO In ('V','S')
                        Order By Orden_Meson"


        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Me.Cursor = Cursors.WaitCursor

        Dim _Tbl_Productos_En_Meson As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Fm_Espera.Dispose()
        Me.Cursor = Cursors.Default

        With Grilla_Productos_En_Meson


            .DataSource = _Tbl_Productos_En_Meson

            OcultarEncabezadoGrilla(Grilla_Productos_En_Meson, True)

            Dim _DisplayIndex = 0

            .Columns("Btn_Ico").Visible = True
            .Columns("Btn_Ico").HeaderText = "A."
            .Columns("Btn_Ico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Btn_Ico").Width = 30
            .Columns("Btn_Ico").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").Width = 45
            .Columns("Numot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Numot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubOt").Visible = True
            .Columns("SubOt").HeaderText = "Sub-OT"
            .Columns("SubOt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("SubOt").Width = 65
            .Columns("SubOt").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Idpotpr").Visible = True
            .Columns("Idpotpr").HeaderText = "Id"
            .Columns("Idpotpr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Idpotpr").Width = 45
            .Columns("Idpotpr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Est."
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").Width = 30
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cod_Vendedor").Visible = True
            .Columns("Cod_Vendedor").HeaderText = "Ven."
            .Columns("Cod_Vendedor").Width = 35
            .Columns("Cod_Vendedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Referencia").Visible = True
            .Columns("Referencia").HeaderText = "Referencia / Cliente"
            .Columns("Referencia").Width = 240
            .Columns("Referencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 110
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Glosa").Visible = True
            .Columns("Glosa").HeaderText = "Descripción"
            .Columns("Glosa").Width = 250
            .Columns("Glosa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "F.llegada"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 80
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tiempo_En_Meson").Visible = True
            .Columns("Tiempo_En_Meson").HeaderText = "Tiempo en Mesón"
            .Columns("Tiempo_En_Meson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tiempo_En_Meson").Width = 100
            .Columns("Tiempo_En_Meson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Saldo_Fabricar_New").Visible = True
            .Columns("Saldo_Fabricar_New").HeaderText = "Fab."
            .Columns("Saldo_Fabricar_New").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo_Fabricar_New").Width = 40
            .Columns("Saldo_Fabricar_New").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Avance_Saldo_Fab").Visible = True
            .Columns("Porc_Avance_Saldo_Fab").HeaderText = "% Av."
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Format = "% ##.##"
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Avance_Saldo_Fab").Width = 50
            .Columns("Porc_Avance_Saldo_Fab").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows

            Dim _Fabricar = _Fila.Cells("Fabricar").Value
            Dim _Fabricado = _Fila.Cells("Fabricado").Value
            Dim _Grado = _Fila.Cells("Grado").Value
            Dim _Estado = _Fila.Cells("Estado").Value
            Dim _Estado_Pote = _Fila.Cells("ESTADO").Value
            Dim _Reproceso = _Fila.Cells("Reproceso").Value

            If _Fabricar = _Fabricado Then
                _Fila.DefaultCellStyle.ForeColor = Rojo
            End If

            If _Estado = "MQ" Then
                _Fila.DefaultCellStyle.ForeColor = Color.LightGray
            End If

            If _Grado = 1 Then
                _Fila.DefaultCellStyle.BackColor = Rojo 'LightCoral
                _Fila.DefaultCellStyle.ForeColor = Color.White
            ElseIf _Grado = 2 Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
                _Fila.DefaultCellStyle.BackColor = Amarillo 'LightYellow
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

            If _Estado_Pote = "S" Then
                _Fila.DefaultCellStyle.ForeColor = Color.Gray
            End If

            If _Reproceso Then
                _Fila.DefaultCellStyle.BackColor = Verde
                _Fila.DefaultCellStyle.ForeColor = Color.White
            End If


            Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
            Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
            Dim _Operacion As String = _Fila.Cells("Operacion").Value

            Dim _Reg_Alertas = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MesonVsAlertas",
                                                        "Idpote = " & _Idpote & " And Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Editada = 0 And Eliminada = 0")

            _Fila.Cells("Btn_Ico").Value = Imagenes2_16x16.Images.Item(0)

            If CBool(_Reg_Alertas) Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.Cells("Btn_Ico").Value = Imagenes2_16x16.Images.Item(2)
                Else
                    _Fila.Cells("Btn_Ico").Value = Imagenes2_16x16.Images.Item(1)
                End If
            End If

        Next

        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Productos_En_Meson, "Fecha", "Tiempo_En_Meson")

    End Sub

    Sub Sb_Actualizar_Grilla_Maquinas(_Codmeson As String)

        Dim _Condicion_Operario As String = String.Empty

        If _Gestion_Operario Then
            _Condicion_Operario = "And Obrero = '" & _Codigoob & "'"
        End If

        Consulta_sql = "Select Cast(0 As Bit) As Chk,
                        (Select Top 1 Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2 Where Z1.Idpotpr = Z2.Idpotpr) As SubOt,
                        *,REFERENCIA As Referencia,(Select Top 1 NOMBREMAQ From PMAQUI where CODMAQ = CodMaq) As Nombremaq," &
                       "(Select Top 1 NOMBREOP From POPER where Operacion = OPERACION) As Nombreop," &
                       "Fecha_Hora_Inicio as Fecha, Fecha_Hora_Inicio as Hora," & vbCrLf &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60) / 24)) As Dias_En_Maquina," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60)%24)) As Horas_En_Maquina," &
                       "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Hora_Inicio, GETDATE())%60) As Minutos_En_Maquina," &
                       "Cast('' As Varchar) As Tiempo_En_Maquina" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z1" & vbCrLf &
                       "INNER JOIN POTE ON Idpote=IDPOTE
                        WHERE Codmeson='" & _Codmeson & "' AND Estado='EMQ'  And POTE.ESTADO = 'V'" & Space(1) & _Condicion_Operario & Space(1) & " ORDER BY Fecha_Hora_Inicio ASC"
        _Tbl_Maquina = _Sql.Fx_Get_DataTable(Consulta_sql) ' _Ds_3 = _Sql.Fx_Get_DataSet(Consulta_sql)


        With Grilla_Maquinas_Meson

            .DataSource = _Tbl_Maquina

            OcultarEncabezadoGrilla(Grilla_Maquinas_Meson, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1
            '.Columns("Chk").Frozen = True

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Numot").Width = 50
            .Columns("Numot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1
            '.Columns("Numot").Frozen = True

            .Columns("SubOt").Visible = True
            .Columns("SubOt").HeaderText = "Sub-OT"
            .Columns("SubOt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SubOt").Width = 65
            .Columns("SubOt").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1
            '.Columns("SubOt").Frozen = True

            .Columns("Idpotpr").Visible = True
            .Columns("Idpotpr").HeaderText = "Id"
            .Columns("Idpotpr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Idpotpr").Width = 50
            .Columns("Idpotpr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1
            '.Columns("Idpotpr").Frozen = True

            '.Columns("CodMaq").Visible = True
            '.Columns("CodMaq").HeaderText = "CodMaq"
            '.Columns("CodMaq").Width = 80
            '.Columns("CodMaq").DisplayIndex = 4

            .Columns("Nombremaq").Visible = True
            .Columns("Nombremaq").HeaderText = "Maquina"
            .Columns("Nombremaq").Width = 160
            .Columns("Nombremaq").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1
            '.Columns("Nombremaq").Frozen = True

            '.Columns("Codigo").Visible = True
            '.Columns("Codigo").HeaderText = "Codigo"
            '.Columns("Codigo").Width = 100
            '.Columns("Codigo").DisplayIndex = 6

            .Columns("Referencia").Visible = True
            .Columns("Referencia").HeaderText = "Referencia / Cliente"
            .Columns("Referencia").Width = 240
            .Columns("Referencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 280
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 80
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 40
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").HeaderText = "Fab."
            .Columns("Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricar").Width = 50
            .Columns("Fabricar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Fabricado").Visible = True
            '.Columns("Fabricado").HeaderText = "Fabricado"
            '.Columns("Fabricado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Fabricado").Width = 60
            '.Columns("Fabricado").DisplayIndex = 10

            .Columns("Tiempo_En_Maquina").Visible = True
            .Columns("Tiempo_En_Maquina").HeaderText = "Tiempo en Maquina"
            .Columns("Tiempo_En_Maquina").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tiempo_En_Maquina").Width = 100
            .Columns("Tiempo_En_Maquina").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Maquinas_Meson, "Fecha_Hora_Inicio", "Tiempo_En_Maquina")

    End Sub

    Private Sub Sb_SuperTabItem_Click(sender As Object, e As EventArgs)

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = False

        Dim _TabMeson = CType(sender, SuperTabItem)
        _CodMeson = _TabMeson.Tag
        Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
        Sb_Actualizar_Grilla_Maquinas(_CodMeson)

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = True

    End Sub

    Sub Sb_Enviar_Producto_Al_Meson_Siguiente(_IdMeson As Integer, _Cant_Fabricada As Double)

        Tiempo_Actualizacion.Stop()

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
        Dim _Fila As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Enviar As Boolean
        Dim _Numot As String = _Fila.Item("NUMOT")
        Dim _Estado As String = _Fila.Item("Estado")
        Dim _Codigo As String = _Fila.Item("Codigo")
        Dim _Glosa As String = _Fila.Item("Glosa")
        Dim _Nreg As String = _Fila.Item("Nreg")

        Dim _Fabricar_OT = _Fila.Item("Fabricar_OT")
        Dim _Fabricado_OT = _Fila.Item("Fabricado_OT")
        Dim _Saldo_Fabricar_OT = _Fila.Item("Saldo_Fabricar_OT")
        Dim _Porc_Fabricacion = _Fila.Item("Porc_Fabricacion")

        Dim _Fabricar = _Fila.Item("Fabricar")
        Dim _Fabricado = _Fila.Item("Fabricado")
        Dim _Saldo_Fabricar = _Fila.Item("Saldo_Fabricar")

        Dim _Codmeson As String = _Fila.Item("Codmeson")
        Dim _Idpote As Integer = _Fila.Item("Idpote")
        Dim _Idpotpr As Integer = _Fila.Item("Idpotpr")
        Dim _Idpotl As String = _Fila.Item("Idpotl")
        Dim _Orden_Meson As Integer = _Fila.Item("Orden_Meson")
        Dim _Orden_Potpr As Integer = _Fila.Item("Orden_Potpr")
        Dim _Nivel As Integer = _Fila.Item("Nivel")
        Dim _Reproceso As Boolean = _Fila.Item("Reproceso")
        Dim _IdMeson_Reproceso As Integer = _Fila.Item("IdMeson_Reproceso")

        If _Fabricar < _Fabricado Then
            _Enviar = Fx_Tiene_Permiso(Me, "")
        Else
            _Enviar = True
        End If

        If _Enviar Then

            'If MessageBoxEx.Show(Me, "¿Desea enviar este trabajo al mesón siguiente?", "BakApp Ingemad",
            'MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

            If _Reproceso Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Cant_Reproceso = Cant_Reproceso - " & _Cant_Fabricada & "
                                Where IdMeson = " & _IdMeson_Reproceso
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If _Fabricado = _Fabricar Then
                    Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET Estado='FZ' WHERE IdMeson=" & _IdMeson
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

                Beep()
                ToastNotification.Show(Me, "EL PRODUCTO SE FUE AL SIGUIENTE MESON", Nothing,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            Else

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'"
                Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Operacion_Equivalente As String = Trim(_Row_Meson.Item("Operacion_Equivalente"))
                Dim _Virtual As Boolean = _Row_Meson.Item("Virtual")

                Dim _Row_Potpr As DataRow

                Consulta_sql = "Select * From POTPR Where IDPOTL = " & _Idpotl & " And IDPOTPR <> " & _Idpotpr & " And ORDEN > " & _Orden_Potpr & " ORDER BY ORDEN"
                Dim _Tbl_Potpr As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila_Potpr As DataRow In _Tbl_Potpr.Rows

                    Dim _Oper = _Fila_Potpr.Item("OPERACION")

                    If _Oper <> _Operacion_Equivalente Then

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Operacion = '" & _Oper & "'"
                        Dim _Row_Meson_NOp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Virtua_Nop As Boolean = _Row_Meson_NOp.Item("Virtual")
                        Dim _Seleccionar_Meson As Boolean

                        If Not _Virtual Then
                            If Not _Virtua_Nop Then _Seleccionar_Meson = True
                        Else
                            _Seleccionar_Meson = True
                        End If

                        If _Seleccionar_Meson Then
                            _Row_Potpr = _Fila_Potpr
                            Exit For
                        End If

                    End If

                Next


                If Not IsNothing(_Row_Potpr) Then

                    If _Fabricado = _Fabricar Then
                        Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET Estado='FZ' WHERE IdMeson=" & _IdMeson
                        _Sql.Ej_consulta_IDU(Consulta_sql)
                    End If

                    If Not _Virtual Then

                        Dim _Codmaq = _Row_Potpr.Item("CODMAQOT")
                        _Codmeson = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_MesonVsMaquina", "Codmeson", "Codmaq = '" & _Codmaq & "'")

                        _Idpotl = _Row_Potpr.Item("IDPOTL")
                        _Idpotpr = _Row_Potpr.Item("IDPOTPR")

                        Dim _Operacion As String = _Row_Potpr.Item("OPERACION")
                        Dim _Nombreop As String = _Sql.Fx_Trae_Dato("POPER", "NOMBREOP", "OPERACION = '" & _Operacion & "'")

                        _Orden_Potpr = _Row_Potpr.Item("ORDEN")

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
                                    Where Codmeson = '" & _Codmeson & "' And Idpotpr = " & _Idpotpr & " And Estado <> 'RP'"
                        Dim _Row_Next_Operacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If Not IsNothing(_Row_Next_Operacion) Then

                            _IdMeson = _Row_Next_Operacion.Item("IdMeson")
                            Dim _Fabricando_ = _Row_Next_Operacion.Item("Fabricando")

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set 
                                    Estado = 'PD',Fabricar = Fabricar + " & _Cant_Fabricada & ", 
                                    Saldo_Fabricar = Saldo_Fabricar + " & _Cant_Fabricada & "
                                    Where IdMeson = " & _IdMeson
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                                   "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                                   "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                                   "WHERE IdMeson = " & _IdMeson
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        Else

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote," &
                                   "Empresa,Numot,Nreg,Estado,Desde,Operacion,Nombreop,Codigo,Glosa,Asignado_Por," &
                                   "Fecha_Asignacion,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT," &
                                   "Fabricar,Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Potpr,Orden_Meson,Nivel) " &
                                   "VALUES('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & Mod_Empresa &
                                   "','" & _Numot & "','" & _Nreg & "','PD','MS'" &
                                   ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                   "','" & FUNCIONARIO & "',Getdate()," & _Fabricar_OT & "," & _Fabricado_OT & "," & _Saldo_Fabricar_OT &
                                   "," & _Fabricado & ",0," & _Fabricado & ",'" & FUNCIONARIO & "'," & _Orden_Potpr &
                                   "," & _Orden_Meson & "," & _Nivel & ")"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                        Beep()
                        ToastNotification.Show(Me, "EL PRODUCTO SE FUE AL SIGUIENTE MESON", Nothing,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    End If

                Else

                    If _Nivel = 0 Then

                        Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET Estado='PT' WHERE IdMeson=" & _IdMeson
                        _Sql.Ej_consulta_IDU(Consulta_sql)
                        MessageBoxEx.Show(Me, "Producto terminado", "Fabricación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        'SE CREA LA DFA DEFINITIVA EN RANDOM PRODUCCION A PARTIR DE LOS DATOS RESCADOS

                        Consulta_sql = "SELECT * FROM POTD" & vbCrLf &
                                   "WHERE NUMOT = '" & _Numot & "' And CODIGO = '" & _Codigo & "' And PERTENECE <> ''"
                        Dim _Row_Potd = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Pertenece As String = _Row_Potd.Item("PERTENECE")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'FZ',Pertenece = '" & _Pertenece & "'" & vbCrLf &
                                           "Where IdMeson = " & _IdMeson
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Dim _Componentes_Pertenece As Integer = _Sql.Fx_Cuenta_Registros("POTD",
                                                                "NUMOT = '" & _Numot & "' And NREG = '" & _Pertenece & "' and PERTENECE <> '' AND MARCANOM <> ''")

                        Dim _Componetes_Fabricados As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                                "Idpote = " & _Idpote & " And Pertenece = '" & _Pertenece & "'")

                        If _Componentes_Pertenece = _Componetes_Fabricados Then

                            Consulta_sql = "SELECT * FROM POTL" & vbCrLf &
                                               "WHERE IDPOTE = " & _Idpote & " And NREG = '" & _Pertenece & "'"
                            Dim _Row_Potl_Pertenece As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            _Idpotl = _Row_Potl_Pertenece.Item("IDPOTL")

                            Consulta_sql = "SELECT " & _Idpote & " As Idpote,IDPOTPR As Idpotpr,Pt.IDPOTL As Idpotl,Pt.NUMOT As Numot," &
                                       "Pt.CODIGO As Codigo,Pl.GLOSA As Glosa,NREGOTL As Nreg,Pt.OPERACION As Operacion,Pp.NOMBREOP As Nombreop," &
                                       "ORDEN As Orden_Potpr,Pt.FABRICAR As Fabricar,Pt.REALIZADO As Fabricado," &
                                       "Pt.FABRICAR-Pt.REALIZADO AS Saldo_Fabricar,0 As Nivel," &
                                       "(Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina Where Codmaq = CODMAQOT) As CodMeson" &
                                       vbCrLf &
                                       "Into #Paso" & vbCrLf &
                                       "FROM POTPR Pt" & vbCrLf &
                                       "INNER JOIN PMAQUI Mq ON Mq.CODMAQ=Pt.CODMAQOT" & vbCrLf &
                                       "INNER JOIN POPER Pp On Pp.OPERACION=Pt.OPERACION" & vbCrLf &
                                       "INNER JOIN POTL Pl ON Pl.IDPOTL=Pt.IDPOTL" & vbCrLf &
                                       "WHERE Pt.IDPOTL = " & _Idpotl & vbCrLf &
                                       "Order By ORDEN" & vbCrLf &
                                       vbCrLf &
                                       "Select Top 1 * From #Paso" & vbCrLf &
                                       "Where CodMeson In (Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0)" & vbCrLf &
                                       "Drop Table #Paso"

                            _Row_Potpr = _Sql.Fx_Get_DataRow(Consulta_sql)

                            Fx_Enviar_Producto_Al_Siguiente_Meson(_Row_Potpr, 1)
                            Beep()
                            ToastNotification.Show(Me, "EL PRODUCTO SE FUE AL SIGUIENTE MESON", Nothing,
                                           1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                        End If

                    End If

                End If

            End If

        End If

        Tiempo_Actualizacion.Start()

    End Sub

    Sub Sb_Enviar_Producto_Al_Meson_Siguiente_Old(_IdMeson As Integer) '_Fila As DataGridViewRow)

        Tiempo_Actualizacion.Stop()

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
        Dim _Fila As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Enviar As Boolean
        Dim _Numot As String = _Fila.Item("NUMOT")
        Dim _Estado As String = _Fila.Item("Estado")
        Dim _Codigo As String = _Fila.Item("Codigo")
        Dim _Nreg As String = _Fila.Item("Nreg")

        Dim _Fabricar_Origen = _Fila.Item("Fabricar")
        Dim _Fabricado_Origen = _Fila.Item("Fabricado")

        Dim _Codmeson_Origen As String = _Fila.Item("Codmeson")
        Dim _Idpote_Origen As Integer = _Fila.Item("Idpote")
        Dim _Idpotrp_Origen As Integer = _Fila.Item("Idpotpr")
        Dim _Idpotl_Origen As String = _Fila.Item("Idpotl")
        Dim _Orden_Meson_Origen As Integer = _Fila.Item("Orden_Meson")
        Dim _Orden_Potpr_Origen As Integer = _Fila.Item("Orden_Potpr")
        Dim _Nivel As Integer = _Fila.Item("Nivel")

        If _Fabricar_Origen < _Fabricado_Origen Then
            _Enviar = Fx_Tiene_Permiso(Me, "")
        Else
            _Enviar = True
        End If

        If _Enviar Then

            If MessageBoxEx.Show(Me, "¿Desea enviar este trabajo al mesón siguiente?", "BakApp Ingemad",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

                Consulta_sql = "SELECT IDPOTPR,Pt.IDPOTL,Pt.NUMOT,Pt.CODIGO,Pl.GLOSA,NREGOTL,Pt.OPERACION,Pp.NOMBREOP,ORDEN,Pt.FABRICAR," &
                               "Pt.REALIZADO,Pt.FABRICAR-Pt.REALIZADO AS Saldo_Fabricar,CODMAQOT,Mq.NOMBREMAQ," &
                               "(Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina Where Codmaq = CODMAQOT) As CodMeson" &
                               vbCrLf &
                               "FROM POTPR Pt" & vbCrLf &
                               "INNER JOIN PMAQUI Mq ON Mq.CODMAQ=Pt.CODMAQOT" & vbCrLf &
                               "INNER JOIN POPER Pp On Pp.OPERACION=Pt.OPERACION" & vbCrLf &
                               "INNER JOIN POTL Pl ON Pl.IDPOTL=Pt.IDPOTL" & vbCrLf &
                               "WHERE Pt.IDPOTL = " & _Idpotl_Origen & " And ORDEN = " & _Orden_Potpr_Origen + 1 & vbCrLf &
                               "Order By ORDEN"

                Dim _Row_Potpr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Potpr) Then

                    Dim _Codmeson As String = _Row_Potpr.Item("CodMeson")
                    Dim _Idpotpr As Integer = _Row_Potpr.Item("Idpotpr")
                    Dim _Idpotl As Integer = _Row_Potpr.Item("Idpotl")
                    Dim _Idpote As Integer = _Idpote_Origen

                    Dim _Operacion As String = _Row_Potpr.Item("OPERACION")
                    Dim _Nombreop As String = _Row_Potpr.Item("NOMBREOP")
                    Dim _Glosa As String = _Row_Potpr.Item("GLOSA")
                    Dim _Fabricar As String = _Row_Potpr.Item("FABRICAR")
                    Dim _Fabricado As String = _Row_Potpr.Item("REALIZADO")
                    Dim _Saldo_Fabricar As String = _Row_Potpr.Item("Saldo_Fabricar")
                    Dim _Orden_Potpr As Integer = _Row_Potpr.Item("ORDEN")
                    Dim _Orden_Meson As Integer = _Orden_Meson_Origen + 1

                    'MsgBox("Este producto no tiene más operaciones disponibles.")


                    'INSERT:insercion de nuevo registro a la tabla mesonvsprod para mostrarse en espera en otro meson
                    'UPDATE:se actualiza el estado del producto en la tabla mesonvsprod para que ya no se muestre en espera en ese meson

                    Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET Estado='FZ' WHERE IdMeson=" & _IdMeson &
                                   vbCrLf &
                                   "INSERT INTO " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote," &
                                   "Empresa,Numot,Nreg,Estado,Desde,Operacion,Nombreop,Codigo,Glosa,Asignado_Por," &
                                   "Fecha_Asignacion,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT," &
                                   "Fabricar,Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Potpr,Orden_Meson,Nivel) " &
                                   "VALUES('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & Mod_Empresa &
                                   "','" & _Numot & "','" & _Nreg & "','PD','MS'" &
                                   ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                   "','" & FUNCIONARIO & "',Getdate()," & _Fabricar & "," & _Fabricado & "," & _Saldo_Fabricar &
                                   "," & _Fabricar & ",0," & _Fabricar & ",'" & FUNCIONARIO & "'," & _Orden_Potpr &
                                   "," & _Orden_Meson & "," & _Nivel & ")"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Beep()
                    ToastNotification.Show(Me, "EL PRODUCTO SE FUE AL SIGUIENTE MESON", Nothing,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                Else

                    If _Nivel = 0 Then
                        Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET Estado='FZ' WHERE IdMeson=" & _IdMeson
                        _Sql.Ej_consulta_IDU(Consulta_sql)
                        MessageBoxEx.Show(Me, "Producto terminado", "Fabricación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Consulta_sql = "SELECT * FROM POTD" & vbCrLf &
                                       "WHERE NUMOT = '" & _Numot & "' And CODIGO = '" & _Codigo & "' And PERTENECE <> ''"
                        Dim _Row_Potd = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Pertenece As String = _Row_Potd.Item("PERTENECE")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'FZ',Pertenece = '" & _Pertenece & "'" & vbCrLf &
                                       "Where IdMeson = " & _IdMeson
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Dim _Componentes_Pertenece As Integer = _Sql.Fx_Cuenta_Registros("POTD",
                                                                "NUMOT = '" & _Numot & "' And NREG = '" & _Pertenece & "' and PERTENECE <> ''")

                        Dim _Componetes_Fabricados As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                                "Idpote = " & _Idpote_Origen & " And Pertenece = '" & _Pertenece & "'")

                        If _Componentes_Pertenece = _Componetes_Fabricados Then

                            Consulta_sql = "SELECT * FROM POTL" & vbCrLf &
                                           "WHERE IDPOT = " & _Idpote_Origen & " And NREG = '" & _Pertenece & "'"
                            Dim _Row_Potl_Pertenece As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        End If

                    End If

                End If

                _CodMeson = Cmb_Mesones.SelectedValue 'Cmb_Mesones.SelectedValue
                Consulta_sql = String.Empty
                Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
                Sb_Actualizar_Grilla_Maquinas(_CodMeson)

            End If

        End If


        Tiempo_Actualizacion.Start()

    End Sub

    Function Fx_Enviar_Producto_Al_Siguiente_Meson(_Row_Potpr As DataRow, _Orden_Meson As Integer) As Boolean

        If Not IsNothing(_Row_Potpr) Then

            Dim _Codmeson As String = _Row_Potpr.Item("CodMeson")
            Dim _Idpote As Integer = _Row_Potpr.Item("Idpote")
            Dim _Idpotl As Integer = _Row_Potpr.Item("Idpotl")
            Dim _Idpotpr As Integer = _Row_Potpr.Item("Idpotpr")
            Dim _Numot As String = _Row_Potpr.Item("Numot")
            Dim _Nreg As String = _Row_Potpr.Item("Nreg")
            Dim _Operacion As String = _Row_Potpr.Item("Operacion")
            Dim _Nombreop As String = _Row_Potpr.Item("Nombreop")
            Dim _Codigo As String = _Row_Potpr.Item("Codigo")
            Dim _Glosa As String = _Row_Potpr.Item("Glosa")
            Dim _Fabricar As String = _Row_Potpr.Item("Fabricar")
            Dim _Fabricado As String = _Row_Potpr.Item("Fabricado")
            Dim _Saldo_Fabricar As String = _Row_Potpr.Item("Saldo_Fabricar")
            Dim _Nivel As Integer = _Row_Potpr.Item("Nivel")
            Dim _Orden_Potpr As Integer = _Row_Potpr.Item("Orden_Potpr")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote," &
                           "Empresa,Numot,Nreg,Estado,Desde,Operacion,Nombreop,Codigo,Glosa,Asignado_Por," &
                           "Fecha_Asignacion,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT," &
                           "Fabricar,Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Potpr,Orden_Meson,Nivel) " &
                           "VALUES('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & Mod_Empresa &
                           "','" & _Numot & "','" & _Nreg & "','PD','MS'" &
                           ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                           "','" & FUNCIONARIO & "',Getdate()," & _Fabricar & "," & _Fabricado & "," & _Saldo_Fabricar &
                           "," & _Fabricar & ",0," & _Fabricar & ",'" & FUNCIONARIO & "'," & _Orden_Potpr &
                           "," & _Orden_Meson & "," & _Nivel & ")"

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Function

    Private Sub Grilla_Productos_En_Meson_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos_En_Meson.CellClick

        Dim _Cabeza = sender.Columns(sender.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)
        Dim _Estado = _Fila.Cells("Estado").Value

        If _Cabeza = "Btn_Acciones" Then

            If _Estado <> "MQ" Then

                Dim _Fabricar = _Fila.Cells("Fabricar").Value
                Dim _Fabricado = _Fila.Cells("Fabricado").Value

                ShowContextMenu(Menu_Contextual_Meson)

            Else

                Beep()
                ToastNotification.Show(Me, "ESTE PRODUCTO ESTA SIENDO PROCESADO EN UNA MAQUINA", Nothing,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            End If

        End If

    End Sub

    Private Sub Grilla_Maquinas_Meson_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maquinas_Meson.CellClick

        Try
            Dim _Cabeza = sender.Columns(sender.CurrentCell.ColumnIndex).Name

            If _Cabeza = "Btn_Acciones" Then
                ShowContextMenu(Menu_Contextual_Maquina)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Enviar_Meson_Siguiente_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Meson_Siguiente.Click
        'Dim _Fila As DataGridViewRow = Grilla_Productos_En_Meson.Rows(Grilla_Productos_En_Meson.CurrentRow.Index)
        'Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
        'Sb_Enviar_Producto_Al_Meson_Siguiente(_IdMeson)
    End Sub

    Private Sub Btn_Agregar_Observaciones_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Observaciones.Click

        Dim _Fila As DataGridViewRow = Grilla_Productos_En_Meson.Rows(Grilla_Productos_En_Meson.CurrentRow.Index)

        Dim _Idrve = _Fila.Cells("Idpotl").Value
        Dim _Nueva_Anotacion As String
        Dim _Aceptado As Boolean = InputBox_Bk(Me, "", "Nueva observación simple", _Nueva_Anotacion, True,
                                               _Tipo_Mayus_Minus.Normal, 50, True, _Tipo_Imagen.Texto)

        If _Aceptado Then

            Dim _HoraGrab = Hora_Grab_fx(False)

            If Convert.ToBoolean(_Idrve) Then

                Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                               "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                               "('POTL'," & _Idrve & ",'',0,'" & FUNCIONARIO &
                               "','" & Format(FechaDelServidor, "yyyyMMdd") & "','','','" & _Nueva_Anotacion & "',GetDate()," & _HoraGrab & ")"


                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Beep()
                    ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", Nothing,
                                           1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If

            End If

        End If

    End Sub

    Private Sub Tiempo_Actualizacion_Tick(sender As Object, e As EventArgs) Handles Tiempo_Actualizacion.Tick
        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Productos_En_Meson, "Fecha", "Tiempo_En_Meson")
        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Maquinas_Meson, "Fecha_Hora_Inicio", "Tiempo_En_Maquina")
    End Sub

    Sub Sb_Tiempo_En_Mesones_y_Maquinas(Grilla As DataGridView, _Campo_Fecha As String, _Campo_Tiempo As String)

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Fecha_Hora_Inicio = _Row.Cells(_Campo_Fecha).Value
            Dim _Estado_Pote = _Row.Cells("ESTADO").Value

            If _Estado_Pote = "S" Then

                _Row.Cells(_Campo_Tiempo).Value = "EN PAUSA..."

            Else

                Dim ts As TimeSpan = Fx_Fecha_y_Hora_del_Servidor.Subtract(_Fecha_Hora_Inicio)

                Dim _Dias_Espera As Int32 = ts.Days
                Dim _Horas_Espera As Int32 = ts.Hours
                Dim _Minutos_Espera As Int32 = ts.Minutes
                Dim _Segundos_Espera As Int32 = ts.Seconds

                Dim _Dias = String.Empty
                Dim _Horas = String.Empty
                Dim _Minutos = String.Empty

                If _Dias_Espera > 0 Then

                    If _Dias_Espera = 1 Then
                        _Dias = "D "
                    Else
                        _Dias = "D "
                    End If

                    _Dias = _Dias_Espera & _Dias ' & "."

                End If

                If _Horas_Espera > 0 Then
                    _Horas = _Horas_Espera & "H "
                End If

                If _Minutos_Espera > 0 Then
                    _Minutos = _Minutos_Espera & "M "
                End If

                Dim _Tiempo_En_Maquina As String

                _Tiempo_En_Maquina = _Dias & _Horas & _Minutos

                If String.IsNullOrEmpty(_Tiempo_En_Maquina) Then _Tiempo_En_Maquina = " - 1 Min"

                _Row.Cells(_Campo_Tiempo).Value = _Tiempo_En_Maquina

            End If

        Next

    End Sub

    Private Sub Btn_Poducto_Fabricado_Click(sender As Object, e As EventArgs) Handles Btn_Poducto_Fabricado.Click

        Dim _Cont = 0
        Dim _Cont_Ok = 0

        For Each _Fila As DataGridViewRow In Grilla_Maquinas_Meson.Rows
            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            If _Chk Then
                _Cont += 1
            End If
        Next

        Dim _Fabricar_Todo As Boolean
        Dim _Finalizar_Trabajo As Boolean

        If CBool(_Cont) Then

            If _Cont <> 1 Then

                If MessageBoxEx.Show(Me, "¿Confirma la fabricación total de todos los productos?", "Finalizar fabricación",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _Fabricar_Todo = True
                    _Finalizar_Trabajo = True
                End If
            Else
                _Finalizar_Trabajo = True
            End If

            If _Finalizar_Trabajo Then

                For Each _Fila As DataGridViewRow In Grilla_Maquinas_Meson.Rows

                    Dim _Chk As Boolean = _Fila.Cells("Chk").Value

                    If _Chk Then

                        If Fx_Producto_Fabricado3(_Fila, _Fabricar_Todo) Then
                            _Cont_Ok += 1
                        End If

                    End If

                Next

                If CBool(_Cont_Ok) Then

                    _CodMeson = Cmb_Mesones.SelectedValue
                    Consulta_sql = String.Empty
                    Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
                    Sb_Actualizar_Grilla_Maquinas(_CodMeson)

                End If

            End If

        Else

            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                               2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

        Dim _Prod_Meson As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                                   "Estado In ('MQ','PD') And Codmeson = '" & _CodMeson & "'")
        Lbl_Productos_En_Meson.Text = "Productos en mesón: " & _Prod_Meson

    End Sub

    Function Fx_Producto_Fabricado(_Fila As DataGridViewRow, _Fabricar_Todo As Boolean)

        Dim _Numot As String = _Fila.Cells("Numot").Value
        Dim _Subot As String = _Fila.Cells("Subot").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
        Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
        Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
        Dim _Idpotl As Integer = _Fila.Cells("Idpotl").Value
        Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
        Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
        Dim _Operacion As String = _Fila.Cells("Operacion").Value

        Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value
        Dim _Fabricado As Double = _Fila.Cells("Fabricado").Value
        Dim _Saldo_Fabricar As Double = _Fabricar - _Fabricado
        Dim _Grabar As Boolean

        If _Fabricar_Todo Then

            _Fabricado = _Saldo_Fabricar
            _Grabar = True

        Else

            Dim Fm As New Frm_Meson_Operario_Cantidad_Fabricada(_Saldo_Fabricar, _Codigo, _Descripcion, _Numot, _Subot)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar
            _Fabricado += Fm.Pro_Fabricados
            Fm.Dispose()

        End If


        If _Grabar Then

            Dim _Texto_Centro = "INGRESE OBSERVACION" & vbCrLf & vbCrLf &
                                "OT: " & _Numot & " (" & _Subot & ")" & vbCrLf & vbCrLf &
                                "Código: " & _Codigo & vbCrLf &
                                _Descripcion

            Dim _Observacion As String = String.Empty
            Dim _Input_box As Boolean = InputBox_Bk(Me, _Texto_Centro, "OBSERVACION", _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)

            Dim _Estado As String

            'If _Fabricado = _Fabricar Then
            '_Estado = "TE" 'Terminado, fabricado 100%
            'Else
            '_Estado = "PD" 'Falta por fabricar
            'End If

            'INSERT:insercion de nuevo registro a la tabla maquinasvsprod para mostrarse en tabla maq
            'UPDATE:se actualiza el estado del producto en la tabla mesonvsprod para que ya no se muestre en espera

            Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
                           "--Estado='" & _Estado & "'," & vbCrLf &
                           "Fabricado = Fabricado + " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                           ",Fabricando = 0 --Fabricando - " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                           ",Porc_Avance_Saldo_Fab = 0" & vbCrLf &
                           "WHERE IdMeson = " & _IdMeson &
                           vbCrLf &
                           vbCrLf &
                           "UPDATE " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                           "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
                           ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
                           ",Porc_Avance_Saldo_Fab = 1" & vbCrLf &
                           ",Fecha_Hora_Termino = Getdate()" & vbCrLf &
                           ",Observacion = '" & _Observacion & "'" & vbCrLf &
                           "WHERE IdMaquina = " & _IdMaquina
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                               "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                               "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                               "WHERE IdMeson = " & _IdMeson
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD' Where IdMeson = " & _IdMeson & " And Saldo_Fabricar > 0"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

            End If

            Sb_Enviar_Producto_Al_Meson_Siguiente(_IdMeson, _Fabricado)

        End If

    End Function

    Function Fx_Producto_Fabricado3(_Fila As DataGridViewRow, _Fabricar_Todo As Boolean)

        Dim _Numot As String = _Fila.Cells("Numot").Value
        Dim _Subot As String = _Fila.Cells("Subot").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
        Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
        Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
        Dim _Idpotl As Integer = _Fila.Cells("Idpotl").Value
        Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
        Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
        Dim _Operacion As String = _Fila.Cells("Operacion").Value

        Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value
        Dim _Fabricado As Double = _Fila.Cells("Fabricado").Value
        Dim _Saldo_Fabricar As Double = _Fabricar - _Fabricado
        Dim _Grabar As Boolean

        If _Fabricar_Todo Then

            _Fabricado = _Saldo_Fabricar
            _Grabar = True

        Else

            Dim Fm As New Frm_Meson_Operario_Cantidad_Fabricada(_Saldo_Fabricar, _Codigo, _Descripcion, _Numot, _Subot)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar
            _Fabricado += Fm.Pro_Fabricados
            Fm.Dispose()

        End If


        If _Grabar Then

            'Dim _Tipoot As String = _Sql.Fx_Trae_Dato("POTE", "TIPOOT", "IDPOTE = " & _Idpote).ToString.Trim

            Dim _Texto_Centro = "INGRESE OBSERVACION" & vbCrLf & vbCrLf &
                                "OT: " & _Numot & " (" & _Subot & ")" & vbCrLf & vbCrLf &
                                "Código: " & _Codigo & vbCrLf &
                                _Descripcion

            Dim _Observacion As String = String.Empty
            Dim _Input_box As Boolean = InputBox_Bk(Me, _Texto_Centro, "OBSERVACION", _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)

            Consulta_sql = "Select *,Cast('' As Varchar(5)) As Subot From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
            Dim _FilaMaquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _FilaMaquina.Item("Subot") = _Subot
            _FilaMaquina.Item("Fabricado") = _Fabricado
            _FilaMaquina.Item("Observacion") = NuloPorNro(_Observacion, "")

            Dim _Cl_Fabricar As New Class_Fabricar

            If Not Fx_Revisar_Meson(_Idpotl, _Idpotpr) Then
                Return False
            End If

            _Grabar = _Cl_Fabricar.Fx_Producto_Fabricado(Me, _FilaMaquina, True)

            If _Grabar Then

                Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

                If Not String.IsNullOrEmpty(_Cl_Fabricar.CodSigMeson.Trim) Then
                    Beep()
                    ToastNotification.Show(Me, "SIG. MESON:" & _Cl_Fabricar.RowSigMeson.Item("Nommeson").ToString.Trim, Imagenes_32_32.Images.Item("button-ok.png"),
                                       10 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If

            End If

        End If

        Return _Grabar

    End Function

    Function Fx_Revisar_Meson(_Idpotl As Integer, _Idpotpr As Integer) As Boolean

        Dim _SolicitaConfOperaciones As Boolean = _Sql.Fx_Trae_Dato("Zw_Pdc_Mesones", "SolicitaConfOperaciones", "Codmeson = '" & _CodMeson & "'")

        If Not _SolicitaConfOperaciones Then
            Return True
        End If

        Dim _TblMesones As DataTable
        Dim _Enviar As Boolean

        Dim Fm As New Frm_Meson_Operario_QuitarOperaciones(_Codigoob, _Idpotl, _Idpotpr)
        Fm.ShowDialog(Me)
        _Enviar = Fm.Enviar
        _TblMesones = Fm.TblMesones
        Fm.Dispose()

        Return _Enviar

    End Function

    Function Fx_Producto_Fabricado4(_Fila As DataRow,
                                    _Fecha_Termino As Date,
                                    _Hora_Termino As DateTime,
                                    _Fabricar_Todo As Boolean)

        Dim _Numot As String = _Fila.Item("Numot")
        Dim _Subot As String = _Fila.Item("Subot")
        Dim _Codigo As String = _Fila.Item("Codigo")
        Dim _Descripcion As String = _Fila.Item("Descripcion")

        Dim _IdMaquina As Integer = _Fila.Item("IdMaquina")
        Dim _IdMeson As Integer = _Fila.Item("IdMeson")
        Dim _Idpote As Integer = _Fila.Item("Idpote")
        Dim _Idpotl As Integer = _Fila.Item("Idpotl")
        Dim _Idpotpr As Integer = _Fila.Item("Idpotpr")
        Dim _Codmeson As String = _Fila.Item("Codmeson")
        Dim _Operacion As String = _Fila.Item("Operacion")

        Dim _Fabricar As Double = _Fila.Item("Fabricar")
        Dim _Fabricado As Double = _Fila.Item("Fabricado")
        Dim _Saldo_Fabricar As Double = _Fabricar - _Fabricado
        Dim _Grabar As Boolean

        If _Fabricar_Todo Then

            _Fabricado = _Saldo_Fabricar
            _Grabar = True

        Else

            Dim Fm As New Frm_Meson_Operario_Cantidad_Fabricada(_Saldo_Fabricar, _Codigo, _Descripcion, _Numot, _Subot)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar
            _Fabricado += Fm.Pro_Fabricados
            Fm.Dispose()

        End If


        If _Grabar Then

            Dim _Texto_Centro = "INGRESE OBSERVACION" & vbCrLf & vbCrLf &
                                "OT: " & _Numot & " (" & _Subot & ")" & vbCrLf & vbCrLf &
                                "Código: " & _Codigo & vbCrLf &
                                _Descripcion

            Dim _Observacion As String = String.Empty
            Dim _Input_box As Boolean = InputBox_Bk(Me, _Texto_Centro, "OBSERVACION", _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)


            Dim _HHc = FormatDateTime(_Hora_Termino, DateFormat.ShortTime)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                           "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
                           ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
                           ",Porc_Avance_Saldo_Fab = 1" & vbCrLf &
                           ",Fecha_Hora_Termino = '" & Format(_Fecha_Termino, "yyyyMMdd") & " " & _HHc & "'" &
                           ",Observacion = '" & _Observacion & "'" & vbCrLf &
                           "Where IdMaquina = " & _IdMaquina
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Select *,Cast('' As Varchar(5)) As Subot From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
            Dim _FilaMaquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _FilaMaquina.Item("Subot") = _Subot


            Dim _Cl_Fabricar As New Class_Fabricar

            _Grabar = _Cl_Fabricar.Fx_Producto_Fabricado(Me, _FilaMaquina, True)

            If _Grabar Then

                Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

                If Not String.IsNullOrEmpty(_Cl_Fabricar.CodSigMeson.Trim) Then
                    Beep()
                    ToastNotification.Show(Me, "SIG. MESON:" & _Cl_Fabricar.RowSigMeson.Item("Nommeson").ToString.Trim, Imagenes_32_32.Images.Item("button-ok.png"),
                                       10 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If

            End If

        End If

        Return _Grabar

    End Function

    Function Fx_Producto_Fabricado2(_Fila As DataRow,
                                    _Fabricar_Todo As Boolean,
                                    _Fecha_Termino As Date,
                                    _Hora_Termino As DateTime,
                                    ByRef _Cant_Fabricado As Double) As Boolean

        Try

            Dim _Numot As String = _Fila.Item("Numot")
            Dim _Subot As String = _Fila.Item("Subot")
            Dim _Codigo As String = _Fila.Item("Codigo")
            Dim _Descripcion As String = _Fila.Item("Descripcion")

            Dim _IdMaquina As Integer = _Fila.Item("IdMaquina")
            Dim _IdMeson As Integer = _Fila.Item("IdMeson")
            Dim _Idpote As Integer = _Fila.Item("Idpote")
            Dim _Idpotl As Integer = _Fila.Item("Idpotl")
            Dim _Idpotpr As Integer = _Fila.Item("Idpotpr")
            Dim _Codmeson As String = _Fila.Item("Codmeson")
            Dim _Fabricar As Double = _Fila.Item("Fabricar")
            Dim _Fabricado As Double = _Fila.Item("Fabricado")
            Dim _Saldo_Fabricar As Double = _Fabricar - _Fabricado
            Dim _Grabar As Boolean


            If _Fabricar_Todo Then
                _Fabricado = _Saldo_Fabricar
                _Grabar = True
            Else
                Dim Fm As New Frm_Meson_Operario_Cantidad_Fabricada(_Saldo_Fabricar, _Codigo, _Descripcion, _Numot, _Subot)
                Fm.ShowDialog(Me)
                _Grabar = Fm.Pro_Grabar
                _Fabricado += Fm.Pro_Fabricados
                Fm.Dispose()
            End If


            If _Grabar Then

                Dim _HHc = FormatDateTime(_Hora_Termino, DateFormat.ShortTime)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                               "Fabricado = Fabricado + " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                               ",Fabricando = 0 --Fabricando - " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                               ",Porc_Avance_Saldo_Fab = 0" & vbCrLf &
                               "Where IdMeson = " & _IdMeson &
                               vbCrLf &
                               vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
                               "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
                               ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
                               ",Porc_Avance_Saldo_Fab = 1" & vbCrLf &
                               ",Fecha_Hora_Termino = '" & Format(_Fecha_Termino, "yyyyMMdd") & " " & _HHc & "'" & vbCrLf &
                               "Where IdMaquina = " & _IdMaquina

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
                                   "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
                                   "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
                                   "Where IdMeson = " & _IdMeson
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD' Where IdMeson = " & _IdMeson & " And Saldo_Fabricar > 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

                    _Cant_Fabricado = _Fabricado

                    Return True

                End If

            End If

        Catch ex As Exception

        End Try

    End Function

    Private Sub Btn_Avence_Porcentaje_Click(sender As Object, e As EventArgs) Handles Btn_Avence_Porcentaje.Click

        Dim _Cont_Ok As Integer

        For Each _Fila As DataGridViewRow In Grilla_Maquinas_Meson.Rows

            Dim _Chk As Boolean = _Fila.Cells("Chk").Value

            If _Chk Then
                If Fx_Ingreso_Fabricacion_Porcentaje2(_Fila) Then
                    _Cont_Ok += 1
                End If
            End If

        Next

        If CBool(_Cont_Ok) Then

            Consulta_sql = String.Empty
            _CodMeson = Cmb_Mesones.SelectedValue
            Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
            Sb_Actualizar_Grilla_Maquinas(_CodMeson)

        Else

            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                               2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    'Private Function Fx_Ingreso_Fabricacion_Porcentaje(_Fila As DataGridViewRow) As Boolean

    '    Try

    '        Dim _Numot As String = _Fila.Cells("Numot").Value
    '        Dim _Subot As String = _Fila.Cells("Subot").Value
    '        Dim _Codigo As String = _Fila.Cells("Codigo").Value
    '        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

    '        Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
    '        Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
    '        Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
    '        Dim _Idpotl As Integer = _Fila.Cells("Idpotl").Value
    '        Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
    '        Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
    '        Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value
    '        Dim _Fabricando As Double = 0

    '        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
    '        Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '        Dim _Saldo_Fabricar As Double = _Row_Meson.Item("Saldo_Fabricar")
    '        Dim _Porc_SvsF As Double = Math.Round(_Fabricar / _Saldo_Fabricar, 2)

    '        Dim _Porc_Avance_Saldo_Fab As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
    '                                                                         "Porc_Avance_Saldo_Fab", "Idpotpr = " & _Idpotpr)
    '        Dim _Porc_Avance_MQ As Double
    '        Dim _Grabar As Boolean
    '        Dim _Enviar_Al_Meson_Siguiente As Boolean

    '        Dim Fm As New Frm_Meson_Operario_Avance(_Porc_Avance_Saldo_Fab, _Codigo, _Descripcion, _Numot, _Subot)
    '        Fm.ShowDialog(Me)
    '        _Grabar = Fm.Pro_Grabar
    '        _Porc_Avance_Saldo_Fab = Fm.Pro_Porc_Avance
    '        _Porc_Avance_MQ = Fm.Pro_Porc_Avance_MQ
    '        Fm.Dispose()

    '        If _Grabar Then

    '            Dim _Estado As String
    '            Dim _Fabricado = _Fabricar

    '            If _Porc_Avance_Saldo_Fab = 1 Then

    '                If _Porc_SvsF = 1 Then
    '                    _Estado = "TE" 'Terminado, fabricado 100%
    '                Else
    '                    _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF
    '                    _Estado = "PD"
    '                End If

    '                _Enviar_Al_Meson_Siguiente = True

    '            Else

    '                _Estado = "PD" 'Falta por fabricar
    '                _Fabricado = 0
    '                _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF

    '            End If

    '            Dim _Observacion As String = String.Empty
    '            Dim _Input_box As Boolean = InputBox_Bk(Me, "INGRESE OBSERVACION", "OBSERVACION",
    '                                                            _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)


    '            Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
    '                                   "Estado='" & _Estado & "'" &
    '                                   ",Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_Saldo_Fab, False, 5) & vbCrLf &
    '                                   ",Fabricando = Fabricando - " & De_Num_a_Tx_01(_Fabricar, False, 5) & vbCrLf &
    '                                   "WHERE IdMeson = " & _IdMeson &
    '                                   vbCrLf &
    '                                   "UPDATE " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
    '                                   "Estado = 'FMQ',Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_MQ, False, 5) &
    '                                   ",Fecha_Hora_Termino = Getdate(),Observacion = '" & _Observacion & "'" & vbCrLf &
    '                                   "WHERE IdMaquina = " & _IdMaquina
    '            _Sql.Ej_consulta_IDU(Consulta_sql)

    '            If CBool(_Fabricado) Then

    '                Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
    '                              "Estado='" & _Estado & "'" &
    '                              ",Fabricado = Fabricado + " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
    '                              "--,Fabricando = Fabricando - " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
    '                              "WHERE IdMeson = " & _IdMeson &
    '                              vbCrLf &
    '                              vbCrLf &
    '                              "UPDATE " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
    '                              "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
    '                              ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
    '                              ",Fecha_Hora_Termino = Getdate()" & vbCrLf &
    '                              "WHERE IdMaquina = " & _IdMaquina
    '                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

    '                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
    '                                       "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
    '                                       "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
    '                                       "WHERE IdMeson = " & _IdMeson
    '                    _Sql.Ej_consulta_IDU(Consulta_sql)

    '                End If

    '            Else

    '                Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
    '                                   "Kocaudet = 'AVANCE'
    '                            WHERE IdMaquina = " & _IdMaquina
    '                _Sql.Ej_consulta_IDU(Consulta_sql)
    '                Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

    '            End If

    '            If _Enviar_Al_Meson_Siguiente Then '_Estado = "TE" Then
    '                Sb_Enviar_Producto_Al_Meson_Siguiente(_IdMeson, _Fabricado)
    '            End If

    '        End If

    '        Return True

    '    Catch ex As Exception

    '    End Try

    'End Function

    'Private Function Fx_Ingreso_Fabricacion_Porcentaje(_Fila As DataRow) As Boolean

    '    Try

    '        Dim _Numot As String = _Fila.Item("Numot")
    '        Dim _Subot As String = _Fila.Item("Subot")
    '        Dim _Codigo As String = _Fila.Item("Codigo")
    '        Dim _Descripcion As String = _Fila.Item("Descripcion")

    '        Dim _IdMaquina As Integer = _Fila.Item("IdMaquina")
    '        Dim _IdMeson As Integer = _Fila.Item("IdMeson")
    '        Dim _Idpote As Integer = _Fila.Item("Idpote")
    '        Dim _Idpotl As Integer = _Fila.Item("Idpotl")
    '        Dim _Idpotpr As Integer = _Fila.Item("Idpotpr")
    '        Dim _Codmeson As String = _Fila.Item("Codmeson")
    '        Dim _Fabricar As Double = _Fila.Item("Fabricar")
    '        Dim _Fabricando As Double = 0

    '        Dim _Porc_Avance_Saldo_Fab As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
    '                                                                         "Porc_Avance_Saldo_Fab", "Idpotpr = " & _Idpotpr)
    '        Dim _Porc_Avance_MQ As Double
    '        Dim _Grabar As Boolean

    '        Dim Fm As New Frm_Meson_Operario_Avance(_Porc_Avance_Saldo_Fab, _Codigo, _Descripcion, _Numot, _Subot)
    '        Fm.ShowDialog(Me)
    '        _Grabar = Fm.Pro_Grabar
    '        _Porc_Avance_Saldo_Fab = Fm.Pro_Porc_Avance
    '        _Porc_Avance_MQ = Fm.Pro_Porc_Avance_MQ
    '        Fm.Dispose()

    '        If _Grabar Then

    '            Dim _Estado As String
    '            Dim _Fabricado = _Fabricar

    '            If _Porc_Avance_Saldo_Fab = 1 Then
    '                _Estado = "TE" 'Terminado, fabricado 100%
    '            Else
    '                _Estado = "PD" 'Falta por fabricar
    '                _Fabricado = 0
    '            End If

    '            Dim _Observacion As String = String.Empty
    '            Dim _Input_box As Boolean = InputBox_Bk(Me, "INGRESE OBSERVACION", "OBSERVACION",
    '                                                            _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)

    '            Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & vbCrLf &
    '                           "--Estado='" & _Estado & "'" & vbCrLf &
    '                           "Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_Saldo_Fab, False, 5) & vbCrLf &
    '                           ",Fabricando = Fabricando - " & De_Num_a_Tx_01(_Fabricar, False, 5) & vbCrLf &
    '                           "WHERE IdMeson = " & _IdMeson &
    '                           vbCrLf &
    '                           "UPDATE " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
    '                           "Estado = 'FMQ',Porc_Avance_Saldo_Fab = " & De_Num_a_Tx_01(_Porc_Avance_MQ, False, 5) &
    '                           ",Fecha_Hora_Termino = (Case When Fecha_Hora_Termino Is Null Then Getdate() Else Fecha_Hora_Termino End)," &
    '                           "Observacion = '" & _Observacion & "'" & vbCrLf &
    '                           "WHERE IdMaquina = " & _IdMaquina
    '            _Sql.Ej_consulta_IDU(Consulta_sql)

    '            If CBool(_Fabricado) Then

    '                Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos SET" & Space(1) &
    '                              "Estado='" & _Estado & "'" &
    '                              ",Fabricado = Fabricado + " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
    '                              "--,Fabricando = Fabricando - " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
    '                              "WHERE IdMeson = " & _IdMeson &
    '                              vbCrLf &
    '                              vbCrLf &
    '                              "UPDATE " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET" & Space(1) &
    '                              "Estado = 'FMQ',Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) &
    '                              ",Porc_Fabricacion = Round(" & De_Num_a_Tx_01(_Fabricado, False, 5) & "/Fabricar,2)" &
    '                              ",Fecha_Hora_Termino = (Case When Fecha_Hora_Termino Is Null Then Getdate() Else Fecha_Hora_Termino End)" & vbCrLf &
    '                              "WHERE IdMaquina = " & _IdMaquina

    '                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

    '                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set" & Space(1) &
    '                                       "Saldo_Fabricar = Fabricar - Fabricado," & Space(1) &
    '                                       "Porc_Fabricacion = Round(Fabricado/Fabricar,2)" & Space(1) &
    '                                       "WHERE IdMeson = " & _IdMeson
    '                    _Sql.Ej_consulta_IDU(Consulta_sql)

    '                End If

    '            Else

    '                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos SET Kocaudet = 'AVANCE' Where IdMaquina = " & _IdMaquina
    '                _Sql.Ej_consulta_IDU(Consulta_sql)
    '                Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

    '            End If

    '            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD' Where IdMeson = " & _IdMeson & " And Saldo_Fabricar > 0"
    '            _Sql.Ej_consulta_IDU(Consulta_sql)

    '            If _Estado = "TE" Then
    '                Sb_Enviar_Producto_Al_Meson_Siguiente(_IdMeson, _Fabricado)
    '            End If

    '        End If

    '        Return True

    '    Catch ex As Exception

    '    End Try

    'End Function

    Private Function Fx_Ingreso_Fabricacion_Porcentaje2(_Fila As DataGridViewRow) As Boolean

        Try

            Dim _Numot As String = _Fila.Cells("Numot").Value
            Dim _Subot As String = _Fila.Cells("Subot").Value
            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

            Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
            Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
            Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
            Dim _Idpotl As Integer = _Fila.Cells("Idpotl").Value
            Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
            Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
            Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value
            Dim _Fabricando As Double = 0

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
            Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Saldo_Fabricar As Double = _Row_Meson.Item("Saldo_Fabricar")
            Dim _Porc_SvsF As Double = Math.Round(_Fabricar / _Saldo_Fabricar, 2)

            Dim _Porc_Avance_Saldo_Fab As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                                             "Porc_Avance_Saldo_Fab", "Idpotpr = " & _Idpotpr)
            Dim _Porc_Avance_MQ As Double
            Dim _Grabar As Boolean
            Dim _Enviar_Al_Meson_Siguiente As Boolean

            Dim Fm As New Frm_Meson_Operario_Avance(_Porc_Avance_Saldo_Fab, _Codigo, _Descripcion, _Numot, _Subot)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar
            _Porc_Avance_Saldo_Fab = Fm.Pro_Porc_Avance
            _Porc_Avance_MQ = Fm.Pro_Porc_Avance_MQ
            Fm.Dispose()

            If _Grabar Then

                Dim _Estado As String
                Dim _Fabricado = _Fabricar

                If _Porc_Avance_Saldo_Fab = 1 Then

                    If _Porc_SvsF = 1 Then
                        _Estado = "TE" 'Terminado, fabricado 100%
                    Else
                        _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF
                        _Estado = "PD"
                    End If

                    _Enviar_Al_Meson_Siguiente = True

                Else

                    _Estado = "PD" 'Falta por fabricar
                    _Fabricado = 0
                    _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF

                End If

                Dim _Observacion As String = String.Empty
                Dim _Input_box As Boolean = InputBox_Bk(Me, "INGRESE OBSERVACION", "OBSERVACION",
                                                                _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)

                Dim _Cl_Fabricar As New Class_Fabricar

                If _Enviar_Al_Meson_Siguiente Then

                    ' ACA DEBO COLOCAR LA OPCION DE GRABAR ALERTAS...!!!!!

                    Consulta_sql = "Select *,Cast('' As Varchar(5)) As Subot From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
                    Dim _FilaMaquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _FilaMaquina.Item("Subot") = _Subot
                    _FilaMaquina.Item("Fabricado") = _Fabricado
                    _FilaMaquina.Item("Observacion") = _Observacion

                    _Grabar = _Cl_Fabricar.Fx_Producto_Fabricado(Me, _FilaMaquina, True)

                Else

                    _Fila.Cells("Fabricado").Value = _Fabricado
                    _Fila.Cells("Estado").Value = _Estado
                    _Fila.Cells("Observacion").Value = _Observacion
                    _Fila.Cells("Porc_Avance_Saldo_Fab").Value = _Porc_Avance_Saldo_Fab

                    _Grabar = _Cl_Fabricar.Fx_Agregar_Fabricacion_Con_Porcentaje_Pistoleo(_Codigoob, _Fila, _Porc_Avance_MQ, _Porc_Avance_Saldo_Fab)

                End If

                If _Grabar Then

                    Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

                    If Not String.IsNullOrEmpty(_Cl_Fabricar.CodSigMeson.Trim) Then
                        Beep()
                        ToastNotification.Show(Me, "SIG. MESON:" & _Cl_Fabricar.RowSigMeson.Item("Nommeson").ToString.Trim, Imagenes_32_32.Images.Item("button-ok.png"),
                                       10 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                    End If

                End If

            End If

            Return _Grabar

        Catch ex As Exception

        End Try

    End Function

    Private Function Fx_Ingreso_Fabricacion_Porcentaje3(_Fila As DataRow) As Boolean

        Try

            Dim _Numot As String = _Fila.Item("Numot")
            Dim _Subot As String = _Fila.Item("Subot")
            Dim _Codigo As String = _Fila.Item("Codigo")
            Dim _Descripcion As String = _Fila.Item("Descripcion")

            Dim _IdMaquina As Integer = _Fila.Item("IdMaquina")
            Dim _IdMeson As Integer = _Fila.Item("IdMeson")
            Dim _Idpote As Integer = _Fila.Item("Idpote")
            Dim _Idpotl As Integer = _Fila.Item("Idpotl")
            Dim _Idpotpr As Integer = _Fila.Item("Idpotpr")
            Dim _Codmeson As String = _Fila.Item("Codmeson")
            Dim _Fabricar As Double = _Fila.Item("Fabricar")
            Dim _Fabricando As Double = 0

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
            Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Saldo_Fabricar As Double = _Row_Meson.Item("Saldo_Fabricar")
            Dim _Porc_SvsF As Double = Math.Round(_Fabricar / _Saldo_Fabricar, 2)

            Dim _Porc_Avance_Saldo_Fab As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                                             "Porc_Avance_Saldo_Fab", "Idpotpr = " & _Idpotpr)
            Dim _Porc_Avance_MQ As Double
            Dim _Grabar As Boolean
            Dim _Enviar_Al_Meson_Siguiente As Boolean

            Dim Fm As New Frm_Meson_Operario_Avance(_Porc_Avance_Saldo_Fab, _Codigo, _Descripcion, _Numot, _Subot)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar
            _Porc_Avance_Saldo_Fab = Fm.Pro_Porc_Avance
            _Porc_Avance_MQ = Fm.Pro_Porc_Avance_MQ
            Fm.Dispose()

            If _Grabar Then

                Dim _Estado As String
                Dim _Fabricado = _Fabricar

                If _Porc_Avance_Saldo_Fab = 1 Then

                    If _Porc_SvsF = 1 Then
                        _Estado = "TE" 'Terminado, fabricado 100%
                    Else
                        _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF
                        _Estado = "PD"
                    End If

                    _Enviar_Al_Meson_Siguiente = True

                Else

                    _Estado = "PD" 'Falta por fabricar
                    _Fabricado = 0
                    _Porc_Avance_Saldo_Fab = _Porc_Avance_Saldo_Fab * _Porc_SvsF

                End If

                Dim _Observacion As String = String.Empty
                Dim _Input_box As Boolean = InputBox_Bk(Me, "INGRESE OBSERVACION", "OBSERVACION",
                                                                _Observacion,, _Tipo_Mayus_Minus.Mayusculas,,,, True)

                Dim _Cl_Fabricar As New Class_Fabricar

                Consulta_sql = "Select *,Cast('' As Varchar(5)) As Subot From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
                Dim _FilaMaquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If _Enviar_Al_Meson_Siguiente Then

                    _FilaMaquina.Item("Subot") = _Subot
                    _FilaMaquina.Item("Fabricado") = _Fabricado
                    _FilaMaquina.Item("Observacion") = _Observacion

                    _Grabar = _Cl_Fabricar.Fx_Producto_Fabricado(Me, _FilaMaquina, True)

                Else

                    _FilaMaquina.Item("Fabricado") = _Fabricado
                    '_FilaMaquina.Item("Estado") = _Estado
                    _FilaMaquina.Item("Observacion") = _Observacion
                    '_FilaMaquina.Item("Porc_Avance_Saldo_Fab") = _Porc_Avance_Saldo_Fab '_Porc_Avance_MQ

                    _Grabar = _Cl_Fabricar.Fx_Agregar_Fabricacion_Con_Porcentaje_Manual(_Codigoob, _FilaMaquina, _Porc_Avance_MQ, _Porc_Avance_Saldo_Fab)

                End If

                If _Grabar Then

                    Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

                    If Not String.IsNullOrEmpty(_Cl_Fabricar.CodSigMeson.Trim) Then
                        Beep()
                        ToastNotification.Show(Me, "SIG. MESON:" & _Cl_Fabricar.RowSigMeson.Item("Nommeson").ToString.Trim, Imagenes_32_32.Images.Item("button-ok.png"),
                                       10 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                    End If

                End If

            End If

            Return _Grabar

        Catch ex As Exception

        End Try

    End Function

    Function Fx_Agregar_Productos_Maquina(_FilaMeson As DataGridViewRow, _Algunos As Boolean, Optional ByRef _Id_Maquina As Integer = 0) As Boolean

        Dim _IdMeson As Integer = _FilaMeson.Cells("IdMeson").Value
        Dim _Idpotpr As String = _FilaMeson.Cells("Idpotpr").Value
        Dim _Idpotl As String = _FilaMeson.Cells("Idpotl").Value
        Dim _Idpote As String = _FilaMeson.Cells("Idpote").Value

        Dim _Numot As String = _FilaMeson.Cells("Numot").Value
        Dim _Subot As String = _FilaMeson.Cells("Nreg").Value
        Dim _Codmeson As String = _FilaMeson.Cells("Codmeson").Value
        Dim _Operacion As String = _FilaMeson.Cells("OPERACION").Value
        Dim _CodMaq As String = _FilaMeson.Cells("CODMAQOT").Value
        Dim _Obrero As String = _Codigoob
        Dim _Codigo As String = _FilaMeson.Cells("Codigo").Value
        Dim _Descripcion As String = _FilaMeson.Cells("Glosa").Value
        Dim _Fabricar As Double = _FilaMeson.Cells("Fabricar").Value
        Dim _Fabricando As Double = _FilaMeson.Cells("Fabricando").Value
        Dim _Saldo_Fabricar As Double = _FilaMeson.Cells("Saldo_Fabricar").Value
        Dim _Saldo_Fabricar_New As Double = _FilaMeson.Cells("Saldo_Fabricar_New").Value
        Dim _Cant_Reproceso As Double = _FilaMeson.Cells("Cant_Reproceso").Value

        'INSERT:insercion de nuevo registro a la tabla maquinasvsprod para mostrarse en tabla maq
        'UPDATE:se actualiza el estado del producto en la tabla mesonvsprod para que ya no se muestre en espera

        Dim _Tbl_Alertas As DataTable

        If Not Fx_Lectura_Alertas(_FilaMeson, _Tbl_Alertas) Then
            Return False
        End If

        Consulta_sql = "Select Distinct * From PMAQUI 
                        Where CODMAQ IN (Select CODMAQ From POPER Where OPERACION = '" & _Operacion & "') OR
                        CODMAQ IN (Select CODMAQAL From PMAQALT Where CODMAQPR In
                        (Select CODMAQ From POPER Where OPERACION = '" & _Operacion & "'))"

        Dim _Tbl_Maquinas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Dim _Row_Maquina As DataRow

        If _Tbl_Maquinas.Rows.Count > 1 Then

            Dim Fm_m = New Frm_Seleccionar_Op_SubOt_Maq_Etc("CODMAQ", "NOMBREMAQ", _Tbl_Maquinas)
            Fm_m.GroupPanel4.Text = "SELECCIONE LA MAQUINA"
            Fm_m.Text = "OT: " & _Numot & " (" & _Subot & "), " & Trim(_Codigo) & " - " & _Descripcion
            Fm_m.ShowDialog(Me)
            _Row_Maquina = Fm_m.Pro_Row
            Fm_m.Dispose()

            If IsNothing(_Row_Maquina) Then
                Return False
            End If

            _CodMaq = _Row_Maquina.Item("CODMAQ")

        End If

        Dim _A_Fabricar = _Saldo_Fabricar - _Fabricando
        Dim _Grabar As Boolean

        Dim Chk_Confirmar_Lectura As New Command
        Chk_Confirmar_Lectura.Checked = False
        Chk_Confirmar_Lectura.Name = "Chk_Confirmar_Lectura"
        Chk_Confirmar_Lectura.Text = "CONFIRMAR LECTURA DE LA ALERTA"

        If CBool(_Saldo_Fabricar_New) Then

            If _Algunos Then

                Dim Fm As New Frm_Meson_Operario_Cantidad_A_Fabricar(Val(_A_Fabricar), _Codigo, _Descripcion, _Numot, _Subot)
                Fm.ShowDialog(Me)
                _Grabar = Fm.Pro_Grabar
                _A_Fabricar = Fm.Pro_Fabricar
                Fm.Dispose()
            Else
                _Fabricando = _Saldo_Fabricar
                _Grabar = True
            End If

            If _Grabar Then

                If Not IsNothing(_Tbl_Alertas) Then

                    For Each _Row_Alerta As DataRow In _Tbl_Alertas.Rows

                        If Not IsNothing(_Row_Alerta) Then

                            Dim _Id_Alertas = _Row_Alerta.Item("Id_Alertas").ToString.ToUpper
                            Dim _Alerta As String = _Row_Alerta.Item("Alerta").ToString.ToUpper
                            Dim _Operario_Envia As String = _Row_Alerta.Item("Operario_Envia").ToString.Trim

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas_Lectura (Id_Alertas,Leida,Codigoob_Lee,Fecha_Leida) Values " &
                                   "(" & _Id_Alertas & ",1,'" & _Codigoob & "',Getdate())"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    Next

                End If

                Consulta_sql = "Select *,Cast('' As Varchar(30)) As CODMAQOT,Cast('' As Varchar(30)) As OPERACION From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
                Dim _RowMeson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _RowMeson.Item("CODMAQOT") = _CodMaq
                _RowMeson.Item("OPERACION") = _Operacion

                Dim _Cl_Fabricar As New Class_Fabricar

                _Id_Maquina = _Cl_Fabricar.Fx_Agregar_Producto_a_la_Maquina(_Codigoob, _RowMeson, _A_Fabricar)

                _Grabar = CBool(_Id_Maquina)

            Else

                _Id_Maquina = 0

            End If

        Else

            MessageBoxEx.Show(Me, "No es posible enviar estos productos a fabricar, ya que estan siendo reprocesados", "Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

        End If

        Return _Grabar

    End Function

    Function Fx_Lectura_Alertas(_FilaMeson As DataGridViewRow, ByRef _Tbl_Alertas As DataTable) As Boolean

        Dim _IdMeson As Integer = _FilaMeson.Cells("IdMeson").Value
        Dim _Idpotpr As String = _FilaMeson.Cells("Idpotpr").Value
        Dim _Idpotl As String = _FilaMeson.Cells("Idpotl").Value
        Dim _Idpote As String = _FilaMeson.Cells("Idpote").Value

        Dim _Numot As String = _FilaMeson.Cells("Numot").Value
        Dim _Subot As String = _FilaMeson.Cells("Nreg").Value
        Dim _Codmeson As String = _FilaMeson.Cells("Codmeson").Value
        Dim _Operacion As String = _FilaMeson.Cells("OPERACION").Value
        Dim _CodMaq As String = _FilaMeson.Cells("CODMAQOT").Value

        Dim _Codigo As String = _FilaMeson.Cells("Codigo").Value
        Dim _Descripcion As String = _FilaMeson.Cells("Glosa").Value
        Dim _Fabricar As Double = _FilaMeson.Cells("Fabricar").Value
        Dim _Fabricando As Double = _FilaMeson.Cells("Fabricando").Value
        Dim _Saldo_Fabricar As Double = _FilaMeson.Cells("Saldo_Fabricar").Value
        Dim _Saldo_Fabricar_New As Double = _FilaMeson.Cells("Saldo_Fabricar_New").Value
        Dim _Cant_Reproceso As Double = _FilaMeson.Cells("Cant_Reproceso").Value

        Dim Chk_Confirmar_Lectura As New Command
        Chk_Confirmar_Lectura.Checked = False
        Chk_Confirmar_Lectura.Name = "Chk_Confirmar_Lectura"
        Chk_Confirmar_Lectura.Text = "CONFIRMAR LECTURA DE LA ALERTA"


        Consulta_sql = "Select Aler.*,Isnull(NOMBREOB,'?????') As Operario_Envia 
                        From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas Aler Left Join PMAEOB On CODIGOOB = Codigoob_Envia
                        Where Idpote = " & _Idpote & " And Idpotl = " & _Idpotl & " And Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Eliminada = 0 And Editada = 0"

        _Tbl_Alertas = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Row_Alerta As DataRow In _Tbl_Alertas.Rows

            If Not IsNothing(_Row_Alerta) Then

                Dim _Alerta As String = _Row_Alerta.Item("Alerta").ToString.ToUpper
                Dim _Operario_Envia As String = _Row_Alerta.Item("Operario_Envia").ToString.Trim

                '_Alerta = "Enviada por: " & _Operario_Envia & vbCrLf & vbCrLf & _Alerta

                Dim _Opciones As Command = Chk_Confirmar_Lectura

                Dim _Info As New TaskDialogInfo("Alerta",
                          eTaskDialogIcon.Shield,
                          "Información importante OT: " & _Numot & vbCrLf & vbCrLf & _Alerta,
                           "Enviada por: " & _Operario_Envia & vbCrLf & _Descripcion & vbCrLf & vbCrLf,
                          eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, Nothing, Nothing,
                          _Opciones, Nothing, Nothing)

                Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                If Not Chk_Confirmar_Lectura.Checked Then

                    MessageBoxEx.Show(Me, "DEBE CONFIRMAR LA LECTURA DEL MENSAJE PARA PODER CONTINUAR CON LA GESTION DE ESTA OT: " & _Numot & vbCrLf &
                                  "EL PRODUCTO NO SERA INGRESADO A LA MAQUINA",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Return False

                End If

                Chk_Confirmar_Lectura.Checked = False

            End If

        Next

        Return True

    End Function

    Private Sub Btn_Mnu_Agregar_Producto_Maquina_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Agregar_Producto_Maquina.Click
        'Sb_Agregar_Productos_Maquina(False)
    End Sub

    Private Sub Btn_Buscar_Pistoleando_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = False
        _CodMeson = Cmb_Mesones.SelectedValue

        Consulta_sql = String.Empty
        Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
        Sb_Actualizar_Grilla_Maquinas(_CodMeson)
        Txt_Stx_Etx.Focus()
        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = True
    End Sub

    Private Sub Frm_Meson_Operario_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            Call Btn_Buscar_Pistoleando_Click(Nothing, Nothing)
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Problemas_Maquina_Click(sender As Object, e As EventArgs) Handles Btn_Problemas_Maquina.Click

        Dim _Contador As Integer

        For Each _Fila As DataGridViewRow In Grilla_Maquinas_Meson.Rows

            If _Fila.Cells("Chk").Value Then


                Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
                Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
                Dim _Idpote As Integer = _Fila.Cells("Idpote").Value
                Dim _Idpotl As Integer = _Fila.Cells("Idpotl").Value
                Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
                Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
                Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value

                Dim _Numot As String = _Fila.Cells("Numot").Value
                Dim _SubOt As String = _Fila.Cells("SubOt").Value

                Dim _Codigo As String = _Fila.Cells("Codigo").Value
                Dim _Descripcion As String = _Fila.Cells("Descripcion").Value


                Dim _Fabricando As Double = 0

                If MessageBoxEx.Show(Me, "¿Esta seguro de quitar el producto de la maquina, se devolvera al mesón sin hacer ninguna gestión?" & vbCrLf &
                                     "Si quita el producto debe indicar la causa del retiro del producto o la falla" & vbCrLf & vbCrLf &
                                     "OT: " & _Numot & " (" & _SubOt & ")" & vbCrLf &
                                     "Código: " & Trim(_Codigo) & " - " & _Descripcion,
                                     "Quitar producto",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                    Dim _Sql_Filtro_Condicion_Extra = "And KOCAUDET <> 'AVANCE'"
                    Dim _Tbl_Filtro As DataTable
                    Dim _Filtrar As Boolean

                    Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra, False)
                    Fm.Text = "CAUSAS DE BAJO RENDIMIENTO O FALLA EN MAQUINA"
                    Fm.Pro_Tabla = "TCAUDET"
                    Fm.Pro_Campo = "KOCAUDET"
                    Fm.Pro_Descripcion = "NOCAUDET"
                    Fm.Pro_Tbl_Filtro = Nothing
                    Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
                    Fm.Pro_Seleccionar_Todo = False
                    Fm.Pro_Seleccionar_Solo_Uno = True
                    Fm.ShowDialog(Me)
                    _Filtrar = Fm.Pro_Filtrar
                    _Tbl_Filtro = Fm.Pro_Tbl_Filtro
                    Fm.Dispose()


                    If _Filtrar Then

                        Dim _Kocaudet = Trim(_Tbl_Filtro.Rows(0).Item("Codigo"))

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set 
                                Estado = 'FMQ',Kocaudet = '" & _Kocaudet & "',Fecha_Hora_Termino=Getdate() 
                                Where IdMaquina = " & _IdMaquina & "
                                Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD', Fabricando = Fabricando - " & _Fabricar & "
                                Where IdMeson = " & _IdMeson
                        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                            Sb_Crear_DFA(_Idpote, _Idpotl, _IdMaquina)

                            Beep()
                            ToastNotification.Show(Me, "PRODUCTO QUITADO DE LA MAQUINA", Nothing,
                                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                            _Contador += 1
                        End If

                    Else

                        Beep()
                        ToastNotification.Show(Me, "DEBE INGRESAR UNA CAUSA" & vbCrLf &
                                               "EL PRODUCTO NO FUE QUITADO DE LA MAQUINA", Nothing,
                                               3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                    End If

                End If

            End If

        Next

        If CBool(_Contador) Then

            _CodMeson = Cmb_Mesones.SelectedValue
            Consulta_sql = String.Empty
            Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
            Sb_Actualizar_Grilla_Maquinas(_CodMeson)

        Else

            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                               2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Btn_Solo_Quitar_Prod_Maquina_Click(sender As Object, e As EventArgs) Handles Btn_Solo_Quitar_Prod_Maquina.Click

        Dim _Contador As Integer

        For Each _Fila As DataGridViewRow In Grilla_Maquinas_Meson.Rows

            If _Fila.Cells("Chk").Value Then

                Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value
                Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
                Dim _Idpotpr As Integer = _Fila.Cells("Idpotpr").Value
                Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
                Dim _Fabricar As Double = _Fila.Cells("Fabricar").Value

                If MessageBoxEx.Show(Me, "¿Esta seguro de quitar el producto de la maquina, se devolvera al mesón sin hacer ninguna gestión?", "Quitar producto",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina & "
                            Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD',Fabricando = Fabricando - " & _Fabricar & "
                            Where IdMeson = " & _IdMeson
                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                        Beep()
                        ToastNotification.Show(Me, "PRODUCTO QUITADO DE LA MAQUINA", Nothing,
                                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                        _Contador += 1
                    End If

                End If

            End If

        Next

        If CBool(_Contador) Then

            _CodMeson = Cmb_Mesones.SelectedValue
            Consulta_sql = String.Empty
            Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
            Sb_Actualizar_Grilla_Maquinas(_CodMeson)

        Else

            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                               2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Grilla_Productos_En_Meson_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla_Productos_En_Meson.MouseUp
        Grilla_Productos_En_Meson.EndEdit()
    End Sub

    Private Sub Grilla_Maquinas_Meson_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla_Maquinas_Meson.MouseUp
        Grilla_Maquinas_Meson.EndEdit()
    End Sub

    Private Sub Btn_Enviar_Sel_Maquina_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Sel_Maquina.Click

        If Not Fx_Revisar_Meson_Abierto_En_Otro_Equipo() Then
            Return
        End If

        Dim _Cont = 0
        Dim _Cont_Ok = 0

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = False

        Dim _Reg As Integer = CType(Grilla_Productos_En_Meson.DataSource, DataTable).Select("Chk = True").Length
        Dim _Enviar_Todos_Fabricar As Boolean = Chk_Preguntar_Cuantos_Fabricar.Checked

        For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows
            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            If _Chk Then
                If Fx_Agregar_Productos_Maquina(_Fila, _Enviar_Todos_Fabricar) Then
                    _Cont_Ok += 1
                Else
                    _Fila.Cells("Chk").Value = False
                End If
                _Cont += 1
            End If
        Next

        If CBool(_Cont) Then
            If CBool(_Cont_Ok) Then
                Beep()
                ToastNotification.Show(Me, "PRODUCTO(S) EN LA MAQUINA OK.", Nothing,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                _CodMeson = Cmb_Mesones.SelectedValue
                Consulta_sql = String.Empty
                Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
                Sb_Actualizar_Grilla_Maquinas(_CodMeson)
            End If
        Else
            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = True

    End Sub

    Private Sub Btn_Finalizar_Trabajo_Click(sender As Object, e As EventArgs) Handles Btn_Finalizar_Trabajo.Click

        If Not Fx_Revisar_Meson_Abierto_En_Otro_Equipo() Then
            Return
        End If

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = False

        Dim _Cont = 0

        For Each _Fila As DataGridViewRow In Grilla_Maquinas_Meson.Rows
            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            If _Chk Then
                _Cont += 1
            End If
        Next

        If CBool(_Cont) Then
            If _Cont > 1 Then
                Btn_Avence_Porcentaje.Enabled = False
                Btn_Problemas_Maquina.Enabled = False
                Btn_Solo_Quitar_Prod_Maquina.Enabled = False
            Else
                Btn_Avence_Porcentaje.Enabled = True
                Btn_Problemas_Maquina.Enabled = True
                Btn_Solo_Quitar_Prod_Maquina.Enabled = True
            End If

            Dim _Accion

            Dim Fm As New Frm_Meson_Operario_Finalizar_Trabajo_Maquina
            Fm.ShowDialog(Me)
            If Fm.Pro_Hacer_Gestion Then
                _Accion = Fm.Pro_Accion_Gestion
            End If

            If Fm.Pro_Hacer_Gestion Then
                Select Case _Accion
                    Case Fm.Enum_Accion.Fabricados_Completamente
                        Call Btn_Poducto_Fabricado_Click(Nothing, Nothing)
                    Case Fm.Enum_Accion.Solo_Un_Porcentaje
                        Call Btn_Avence_Porcentaje_Click(Nothing, Nothing)
                    Case Fm.Enum_Accion.Quitar_Productos_Problemas
                        Call Btn_Problemas_Maquina_Click(Nothing, Nothing)
                    Case Fm.Enum_Accion.Quitar_Productos_Por_Error_Solo_Quitar
                        Call Btn_Solo_Quitar_Prod_Maquina_Click(Nothing, Nothing)
                End Select
            End If
            Fm.Dispose()
        Else
            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = True

    End Sub

    Private Sub Txt_Stx_Etx_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Stx_Etx.KeyDown

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = False

        If e.KeyValue = Keys.Enter Then

            Dim _Lectura As String = Txt_Stx_Etx.Text
            Dim _Row_Ot As DataRow
            Dim _Row_SubOt As DataRow
            Dim _Row_MesonVsProducto As DataRow
            Dim _Row_Operacion As DataRow
            Dim _Es_Inicio As Boolean
            Dim _Es_Fin As Boolean

            Fx_Lectura_Codigo_Operacion_X_Tarea_En_Hoja_de_Ruta(_Lectura, _Row_Ot, _Row_SubOt, _Row_MesonVsProducto, _Row_Operacion, _Es_Inicio, _Es_Fin)

        End If

        If _Cerrar_automaticamente Then Tiempo_Cierre_Automatico.Enabled = True

    End Sub

    Sub Fx_Lectura_Codigo_Operacion_X_Tarea_En_Hoja_de_Ruta(ByVal _Lectura As String,
                                                            ByRef _Row_Ot As DataRow,
                                                            ByRef _Row_SubOt As DataRow,
                                                            ByRef _Row_MesonVsProducto As DataRow,
                                                            ByRef _Row_Operacion As DataRow,
                                                            ByRef _Es_Inicio As Boolean,
                                                            ByRef _Es_Fin As Boolean)


        If Not Fx_Revisar_Meson_Abierto_En_Otro_Equipo() Then
            Return
        End If

        Dim _Error_Formato_Lectura As Boolean
        Dim _Mesones = Generar_Filtro_IN(_Tbl_Mesones, "", "Padre", False, False, "'")

        Try

            If _Lectura.Contains(";") Then

                If _Lectura.Contains("stx") Then _Es_Inicio = True
                If _Lectura.Contains("etx") Then _Es_Fin = True

                If _Es_Inicio Then

                    Dim _Cadena = Split(_Lectura, ";")
                    Dim _Idotpr As Integer = _Cadena(1)

                    Consulta_sql = "Select Top 1 Zw.*,ESTADO As Estado_Pote From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Zw
                                    Inner Join POTE On IDPOTE = Zw.Idpote
                                    Where Idpotpr = " & _Idotpr & " And Codmeson In " & _Mesones
                    _Row_MesonVsProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_Row_MesonVsProducto Is Nothing) Then

                        Dim _Estado_Pote = _Row_MesonVsProducto.Item("Estado_Pote")
                        Dim _IdMeson = _Row_MesonVsProducto.Item("IdMeson")
                        Dim _Estado = _Row_MesonVsProducto.Item("Estado")

                        If _Estado_Pote = "S" Then
                            MessageBoxEx.Show(Me, "Orden de trabajo en suspención." & Environment.NewLine &
                                              "No se puede hacer gestión sobre ella.", "OT EN PAUSA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                        Select Case _Estado

                            Case "PD"

                                _CodMeson = Trim(_Row_MesonVsProducto.Item("Codmeson"))

                                For Each _Row_Meson As DataRow In _Tbl_Mesones.Rows 'i = 1 To TabStrip_Mesones.Tabs.Count
                                    'Dim _Tabs = TabStrip_Mesones.Tabs.Item(i)
                                    Dim _Meson = Trim(_Row_Meson.Item("Padre")) 'Trim(_Tabs.Tag)

                                    If _Meson = _CodMeson Then

                                        'TabStrip_Mesones.SelectedTabIndex = i
                                        'Consulta_sql = String.Empty
                                        'Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
                                        'Sb_Actualizar_Grilla_Maquinas(_CodMeson)

                                        Cmb_Mesones.SelectedValue = _CodMeson
                                        Sb_Actualizar_Grillas()

                                        For Each _Fila_Meson As DataGridViewRow In Grilla_Productos_En_Meson.Rows

                                            Dim _IdMeson_ As Integer = _Fila_Meson.Cells("IdMeson").Value

                                            If _IdMeson = _IdMeson_ Then

                                                _Fila_Meson.Cells("Chk").Value = True
                                                Call Btn_Enviar_Sel_Maquina_Click(Nothing, Nothing)
                                                Exit For

                                            End If

                                        Next

                                        Exit For

                                    End If

                                Next

                            Case "FZ"
                                'Beep()
                                'ToastNotification.Show(Me, "ESTA OPERACION YA FUE REALIZADA COMPLETAMENTE", Nothing,
                                '2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                                MessageBoxEx.Show(Me, "ESTA OPERACION YA FUE REALIZADA COMPLETAMENTE", "Validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Case "MQ"
                                'Beep()
                                'ToastNotification.Show(Me, "EL PRODUCTO SE ENCUENTRA EN MAQUINA", Nothing,
                                '2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                                MessageBoxEx.Show(Me, "EL PRODUCTO SE ENCUENTRA EN MAQUINA", "Validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Case Else

                        End Select

                    Else
                        _Es_Inicio = False : _Es_Fin = False
                        'Beep()
                        'ToastNotification.Show(Me, "REGISTRO DESCONOCIDO", Nothing,
                        '           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                        MessageBoxEx.Show(Me, "ESTE REGISTRO PERTENECE A OTRO MESON", "Validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                ElseIf _Es_Fin Then

                    Dim _Cadena = Split(_Lectura, ";")
                    Dim _Idotpr As Integer = _Cadena(1)

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos
                                    Where Idpotpr = " & _Idotpr & " And Estado = 'EMQ' And Obrero = '" & _Codigoob & "' Order by Fecha_Hora_Inicio"
                    Dim _Row_MaquinaVsProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_Row_MaquinaVsProducto Is Nothing) Then

                        Dim _IdMaquina = _Row_MaquinaVsProducto.Item("IdMaquina")
                        Dim _Estado = _Row_MaquinaVsProducto.Item("Estado")

                        Select Case _Estado
                            Case "EMQ"

                                _CodMeson = Trim(_Row_MaquinaVsProducto.Item("Codmeson"))

                                For Each _Row_Meson As DataRow In _Tbl_Mesones.Rows 'For i = 1 To TabStrip_Mesones.Tabs.Count
                                    'Dim _Tabs = TabStrip_Mesones.Tabs.Item(i)
                                    Dim _Meson = Trim(_Row_Meson.Item("Padre")) 'Trim(_Tabs.Tag)

                                    If _Meson = _CodMeson Then

                                        ''TabStrip_Mesones.SelectedTabIndex = i
                                        'Consulta_sql = String.Empty
                                        'Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
                                        'Sb_Actualizar_Grilla_Maquinas(_CodMeson)

                                        Cmb_Mesones.SelectedValue = _CodMeson
                                        Sb_Actualizar_Grillas()

                                        For Each _Fila_Maquina As DataGridViewRow In Grilla_Maquinas_Meson.Rows

                                            Dim _IdMaquina_ As Integer = _Fila_Maquina.Cells("IdMaquina").Value

                                            If _IdMaquina = _IdMaquina_ Then

                                                _Fila_Maquina.Cells("Chk").Value = True
                                                Call Btn_Finalizar_Trabajo_Click(Nothing, Nothing)
                                                Exit For

                                            End If

                                        Next

                                        Exit For

                                    End If

                                Next

                            Case "FMQ"
                                'Beep()
                                'ToastNotification.Show(Me, "ESTA OPERACION YA FUE REALIZADA COMPLETAMENTE", Nothing,
                                '           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                                MessageBoxEx.Show(Me, "ESTA OPERACION YA FUE REALIZADA COMPLETAMENTE", "Validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Case "MQ"
                                'Beep()
                                'ToastNotification.Show(Me, "EL PRODUCTO SE ENCUENTRA EN MAQUINA", Nothing,
                                '           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                                MessageBoxEx.Show(Me, "EL PRODUCTO SE ENCUENTRA EN MAQUINA", "Validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Case Else

                        End Select

                    Else
                        _Es_Inicio = False : _Es_Fin = False
                        'Beep()
                        'ToastNotification.Show(Me, "REGISTRO DESCONOCIDO", Nothing,
                        '           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                        MessageBoxEx.Show(Me, "ESTE PROCESO AUN NO HA SIDO INICIALIZADO O EL REGISTRO PERTENECE A OTRO MESON", "Validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Else
                    _Error_Formato_Lectura = True
                End If
            Else
                Throw New System.Exception("NO SE RECONOCE EL COMANDO")
            End If

        Catch ex As Exception
            _Es_Inicio = False : _Es_Fin = False
            Beep()
            ToastNotification.Show(Me, ex.Message, Nothing,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            'MessageBoxEx.Show(Me, ex.Message, "Validación",
            'MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Txt_Stx_Etx.Text = String.Empty
            Txt_Stx_Etx.Focus()
        End Try

    End Sub

    Sub Sb_Crear_DFA(_Idpote As Integer, _Idpotl As Integer, _IdMaquina As Integer)

        Dim _Idpdatfae As Integer

        Dim _DFA As New Clas_Crear_DFA_Desde_Meson(_Idpote, _Idpotl)
        _DFA.Sb_Crear_Dfa()
        _Idpdatfae = _DFA.Fx_Crear_Documento()

        If CBool(_Idpdatfae) Then

            Dim _Tbl_Fabricacion As DataTable = _DFA.Pro_Tbl_Fabricacion

            Dim _Id_Maquinas As String = Generar_Filtro_IN(_Tbl_Fabricacion, "", "IdMaquina", False, False, "")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set Idpdatfae = " & _Idpdatfae & "
                            Where IdMaquina In " & _Id_Maquinas
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Private Sub Tiempo_Cierre_Automatico_Tick(sender As Object, e As EventArgs) Handles Tiempo_Cierre_Automatico.Tick
        Me.Close()
    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    If Not Fx_Revisar_Meson_Abierto_En_Otro_Equipo() Then
                        Return
                    End If

                    Dim _Fila As DataGridViewRow = Grilla_Productos_En_Meson.Rows(Grilla_Productos_En_Meson.CurrentRow.Index)

                    Dim _Tiempo_En_Meson = _Fila.Cells("Tiempo_En_Meson").Value

                    If _Tiempo_En_Meson = "EN PAUSA..." Then
                        Beep()
                        ToastNotification.Show(Me, "OT EN PAUSA...", Nothing,
                                           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                    Else
                        ShowContextMenu(Menu_Contextual_Meson)
                    End If

                End If

            End With

        End If

    End Sub

    Private Sub Sb_Grilla_Maquinas_Meson_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    If Not Fx_Revisar_Meson_Abierto_En_Otro_Equipo() Then
                        Return
                    End If

                    ShowContextMenu(Menu_Contextual_Maquina)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Ingresar_DFA_Manualmente_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_DFA_Manualmente.Click

        If Not Fx_Revisar_Meson_Abierto_En_Otro_Equipo() Then
            Return
        End If

        Dim _Cont = 0

        For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows
            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            If _Chk Then
                _Cont += 1
            End If
        Next

        If Not CBool(_Cont) Then

            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                               2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Return

        End If

        _CodMeson = Cmb_Mesones.SelectedValue

        Dim _Permitir_Ing_DFA_Directo As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_Mesones",
                                                                     "Permitir_Ing_DFA_Directo", "Codmeson = '" & _CodMeson & "'")

        If Not _Permitir_Ing_DFA_Directo Then

            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pdc00007", True, False)
            Fm.Text = "INGRESE CLAVE DE AUTORIZACION"
            Fm.Pro_Cerrar_Automaticamente = True
            Fm.ShowDialog(Me)
            _Permitir_Ing_DFA_Directo = Fm.Pro_Permiso_Aceptado
            Fm.Dispose()

        End If


        If _Permitir_Ing_DFA_Directo Then

            Dim _Aceptar As Boolean

            Dim _Fecha_Ingreso As Date
            Dim _Fecha_Cierre As Date
            Dim _Hora_Ingreso As DateTime
            Dim _Hora_Cierre As DateTime

            Dim Fm_C As New Frm_DFA_Cierre_Atrasado
            Fm_C.Pro_Fecha_Ingreso = Now.Date
            Fm_C.Pro_Fecha_Cierre = Now.Date

            Fm_C.ShowDialog(Me)
            _Aceptar = Fm_C.Pro_Aceptar
            _Fecha_Ingreso = Fm_C.Pro_Fecha_Ingreso
            _Fecha_Cierre = Fm_C.Pro_Fecha_Cierre
            _Hora_Ingreso = Fm_C.Pro_Hora_Ingreso
            _Hora_Cierre = Fm_C.Pro_Hora_Cierre
            Fm_C.Dispose()

            If _Aceptar Then

                Dim _Contador_Fabricados = 0

                For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows

                    Dim _Chk As Boolean = _Fila.Cells("Chk").Value

                    If _Chk Then

                        Dim _IdMaquina = 0
                        Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
                        Dim _Codmeson As String = Trim(_Fila.Cells("Codmeson").Value)

                        Dim _HHi = FormatDateTime(_Hora_Ingreso, DateFormat.ShortTime)
                        Dim _HHc = FormatDateTime(_Hora_Cierre, DateFormat.ShortTime)

                        Fx_Agregar_Productos_Maquina(_Fila, Chk_Preguntar_Cuantos_Fabricar.Checked, _IdMaquina)

                        If CBool(_IdMaquina) Then

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set 
                                            Fecha_Hora_Inicio = '" & Format(_Fecha_Ingreso, "yyyyMMdd") & " " & _HHi & "' 
                                            Where IdMaquina = " & _IdMaquina
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Consulta_sql = "Select Cast(0 As Bit) As Chk,
                                   (Select Top 1 Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2 Where Z1.Idpotpr = Z2.Idpotpr) As SubOt,
                                    *,REFERENCIA As Referencia,(Select Top 1 NOMBREMAQ From PMAQUI where CODMAQ = CodMaq) As Nombremaq," &
                                            "(Select Top 1 NOMBREOP From POPER where Operacion = OPERACION) As Nombreop," &
                                            "Fecha_Hora_Inicio as Fecha, Fecha_Hora_Inicio as Hora," & vbCrLf &
                                            "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60) / 24)) As Dias_En_Maquina," &
                                            "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60)%24)) As Horas_En_Maquina," &
                                            "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Hora_Inicio, GETDATE())%60) As Minutos_En_Maquina," &
                                            "Cast('' As Varchar) As Tiempo_En_Maquina" & vbCrLf &
                                            "From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z1" & vbCrLf &
                                            "INNER JOIN POTE ON Idpote=IDPOTE" & vbCrLf &
                                            "Where IdMaquina = " & _IdMaquina


                            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            Dim _Fabricar_Todo As Boolean = Not Chk_Preguntar_Cuantos_Fabricar.Checked

                            If Fx_Producto_Fabricado4(_Row, _Fecha_Cierre, _Hora_Cierre, _Fabricar_Todo) Then

                                _Contador_Fabricados += 1

                            Else

                                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                        End If

                    End If

                Next

                If CBool(_Contador_Fabricados) Then

                    _CodMeson = Cmb_Mesones.SelectedValue
                    Consulta_sql = String.Empty
                    Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
                    Sb_Actualizar_Grilla_Maquinas(_CodMeson)

                    Beep()
                    ToastNotification.Show(Me, "DATOS DE FABRICACION INGRESADOS CORRECTAMENTE", Nothing,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Ingresar_DFA_Manualmente_Porcentaje_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_DFA_Manualmente_Porcentaje.Click

        Dim _Cont = 0

        For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows
            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            If _Chk Then
                _Cont += 1
            End If
        Next

        If Not CBool(_Cont) Then
            Beep()
            ToastNotification.Show(Me, "NO HAY PRODUCTOS SELECCIONADOS", Nothing,
                               2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Return
        End If


        Dim _IdMaquina As Integer
        Dim _Codmeson = Cmb_Mesones.SelectedValue

        Dim _Permitir_Ing_DFA_Directo As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_Mesones",
                                                                     "Permitir_Ing_DFA_Directo", "Codmeson = '" & _Codmeson & "'")

        If Not _Permitir_Ing_DFA_Directo Then

            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pdc00007", True, False)
            Fm.Text = "INGRESE CLAVE DE AUTORIZACION"
            Fm.Pro_Cerrar_Automaticamente = True
            Fm.ShowDialog(Me)
            _Permitir_Ing_DFA_Directo = Fm.Pro_Permiso_Aceptado
            Fm.Dispose()

        End If

        If _Permitir_Ing_DFA_Directo Then

            Dim _Aceptar As Boolean

            Dim _Fecha_Ingreso As Date
            Dim _Fecha_Cierre As Date
            Dim _Hora_Ingreso As DateTime
            Dim _Hora_Cierre As DateTime

            Dim Fm_C As New Frm_DFA_Cierre_Atrasado
            Fm_C.Pro_Fecha_Ingreso = Now.Date
            Fm_C.Pro_Fecha_Cierre = Now.Date

            Fm_C.ShowDialog(Me)
            _Aceptar = Fm_C.Pro_Aceptar
            _Fecha_Ingreso = Fm_C.Pro_Fecha_Ingreso
            _Fecha_Cierre = Fm_C.Pro_Fecha_Cierre
            _Hora_Ingreso = Fm_C.Pro_Hora_Ingreso
            _Hora_Cierre = Fm_C.Pro_Hora_Cierre
            Fm_C.Dispose()

            If _Aceptar Then

                Dim _Contador_Fabricados = 0

                For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows

                    Dim _Chk As Boolean = _Fila.Cells("Chk").Value

                    If _Chk Then

                        Dim _HHi = FormatDateTime(_Hora_Ingreso, DateFormat.ShortTime)
                        Dim _HHc = FormatDateTime(_Hora_Cierre, DateFormat.ShortTime)

                        Fx_Agregar_Productos_Maquina(_Fila, Chk_Preguntar_Cuantos_Fabricar.Checked, _IdMaquina)

                        If CBool(_IdMaquina) Then

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set" & Space(1) &
                                           "Fecha_Hora_Inicio = '" & Format(_Fecha_Ingreso, "yyyyMMdd") & " " & _HHi & "'," &
                                           "Fecha_Hora_Termino = '" & Format(_Fecha_Cierre, "yyyyMMdd") & " " & _HHc & "'" & vbCrLf &
                                           "Where IdMaquina = " & _IdMaquina
                            _Sql.Ej_consulta_IDU(Consulta_sql)


                            Consulta_sql = "Select Cast(0 As Bit) As Chk,
                                            (Select Top 1 Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2 Where Z1.Idpotpr = Z2.Idpotpr) As SubOt,
                                            *,REFERENCIA As Referencia,(Select Top 1 NOMBREMAQ From PMAQUI where CODMAQ = CodMaq) As Nombremaq," &
                                            "(Select Top 1 NOMBREOP From POPER where Operacion = OPERACION) As Nombreop," &
                                            "Fecha_Hora_Inicio as Fecha, Fecha_Hora_Inicio as Hora," & vbCrLf &
                                            "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60) / 24)) As Dias_En_Maquina," &
                                            "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60)%24)) As Horas_En_Maquina," &
                                            "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Hora_Inicio, GETDATE())%60) As Minutos_En_Maquina," &
                                            "Cast('' As Varchar) As Tiempo_En_Maquina" & vbCrLf &
                                            "From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z1" & vbCrLf &
                                            "INNER JOIN POTE ON Idpote=IDPOTE" & vbCrLf &
                                            "Where IdMaquina = " & _IdMaquina
                            Dim _Row_Maquina As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            If Fx_Ingreso_Fabricacion_Porcentaje3(_Row_Maquina) Then ' Fx_Ingreso_Fabricacion_Porcentaje(_Row_Maquina) Then

                                Consulta_sql = String.Empty
                                _Contador_Fabricados += 1

                            Else

                                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where IdMaquina = " & _IdMaquina
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                        End If

                    End If

                Next

                If CBool(_Contador_Fabricados) Then

                    _Codmeson = Cmb_Mesones.SelectedValue
                    Sb_Actualizar_Grilla_Mesones_Espera(_Codmeson)
                    Sb_Actualizar_Grilla_Maquinas(_Codmeson)

                End If

            End If

        End If

    End Sub

    Private Sub Sb_Cmb_Mesones_SelectedIndexChanged(sender As Object, e As EventArgs)

        Sb_Actualizar_Grillas()

    End Sub

    Sub Sb_Actualizar_Grillas()

        _CodMeson = Cmb_Mesones.SelectedValue

        Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
        Sb_Actualizar_Grilla_Maquinas(_CodMeson)

        Dim _Prod_Meson As Integer
        '= _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MesonVsProductos Inner Join POTE On IDPOTE = Idpote",
        '                                                   "Estado In ('MQ','PD') And Codmeson = '" & _CodMeson & "' And POTE.ESTADO = 'V'")

        Consulta_sql = "Select Count(*) As Cuenta From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos WITH (NOLOCK) Inner Join POTE WITH (NOLOCK) On IDPOTE = Idpote" & vbCrLf &
                       "Where Estado In ('MQ','PD') And Codmeson = '" & _CodMeson & "' And POTE.ESTADO = 'V'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Prod_Meson = _Row.Item("Cuenta")

        Lbl_Productos_En_Meson.Text = "Productos en mesón: " & _Prod_Meson

        Sb_Ingresar_Al_Meson_Abrir()

    End Sub

    Private Sub Btn_Impirmir_ProdMeson_Click(sender As Object, e As EventArgs) Handles Btn_Impirmir_ProdMeson.Click

        Dim _Clas_Imp As New Clas_Impirmir_Operaciones_OT_Barras()
        _Clas_Imp.Pro_Filas_X_Documento = 30
        _Clas_Imp.Fx_Imprimir_Productos_En_Meson(Me, "", "", Cmb_Mesones.SelectedValue)

    End Sub

    Private Sub Grilla_Productos_En_Meson_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla_Productos_En_Meson.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla_Productos_En_Meson.Rows(Grilla_Productos_En_Meson.CurrentRow.Index)

        Dim _Tiempo_En_Meson = _Fila.Cells("Tiempo_En_Meson").Value

        If _Tiempo_En_Meson = "EN PAUSA..." Then
            Beep()
            ToastNotification.Show(Me, "OT EN PAUSA...", Nothing,
                                           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            e.Cancel = True
        End If

    End Sub

    Private Sub Btn_Info_Comercial_Click(sender As Object, e As EventArgs) Handles Btn_Info_Comercial.Click

        Dim _Fila As DataGridViewRow = Grilla_Productos_En_Meson.Rows(Grilla_Productos_En_Meson.CurrentRow.Index)

        Dim _Idmaeddo = _Fila.Cells("Id_Doc_Comerial").Value
        Dim _Tido = _Fila.Cells("Tido_Doc_Comercial").Value
        Dim _Nudo = _Fila.Cells("Nudo_Doc_Comercial").Value
        Dim _Cod_Vendedor = _Fila.Cells("Cod_Vendedor").Value
        Dim _Vendedor = _Fila.Cells("Vendedor").Value
        Dim _TipoDoc = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'")

        Dim _Numot = _Fila.Cells("NUMOT").Value
        Dim _Subot = _Fila.Cells("SubOT").Value
        Dim _Referencia = _Fila.Cells("SubOT").Value
        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Glosa = _Fila.Cells("Glosa").Value


        Consulta_sql = "Select TIDO,NUDO,ENDO,SUENDO,NOKOEN 
                        From MAEDDO 
                        Inner Join MAEEN On KOEN = ENDO And SUENDO = SUEN 
                        Where IDMAEDDO = " & _Idmaeddo

        Dim _Row_Maeddo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Maeddo) Then

            Dim _Nokoen = _Row_Maeddo.Item("NOKOEN")

            Dim _Informacion As String

            _Informacion = "Orden de trabajo Nro: " & _Numot & vbCrLf &
                           "Sub-Ot: " & _Subot & vbCrLf & vbCrLf &
                           "Producto: " & _Codigo & " - " & _Glosa & vbCrLf & vbCrLf &
                           "Documento: " & _Tido & "-" & _Nudo & vbCrLf &
                           "Razón social: " & _Nokoen & vbCrLf &
                           "Vendedor: " & _Cod_Vendedor & "-" & _Vendedor & vbCrLf & vbCrLf

            Dim info As New TaskDialogInfo("Info. mesón",
                                            eTaskDialogIcon.Information2,
                                            "Información comercial",
                                            _Informacion,
                                            eTaskDialogButton.Ok _
                                            , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

        Else

            MessageBoxEx.Show(Me, "No existe información comercial, no esta asociado a ningún documento", "Info. mesón",
                              MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)

        End If

    End Sub

    Private Sub Btn_Cambiar_Hora_Ingreso_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Hora_Ingreso.Click

        Dim _Permitir As Boolean

        Dim Fm1 As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pdc00008", True, False)
        Fm1.Text = "INGRESE CLAVE DE AUTORIZACION"
        Fm1.Pro_Cerrar_Automaticamente = True
        Fm1.ShowDialog(Me)
        _Permitir = Fm1.Pro_Permiso_Aceptado
        Fm1.Dispose()

        If _Permitir Then

            Dim _Fila As DataGridViewRow = Grilla_Maquinas_Meson.Rows(Grilla_Maquinas_Meson.CurrentRow.Index)
            Dim _Fecha_Hora_Inicio As DateTime = _Fila.Cells("Fecha_Hora_Inicio").Value
            Dim _IdMaquina As Integer = _Fila.Cells("IdMaquina").Value

            Dim _Aceptar As Boolean

            Dim Fm As New Frm_DFA_Cierre_Atrasado
            Fm.Text = "ACTUALIZAR HORA DE INGRESO"
            Fm.Dtp_Fecha_Ingreso.Enabled = False
            Fm.Lbl_Hora_Termino.Visible = False
            Fm.Dtp_Hora_Termino.Visible = False
            Fm.Dtp_Hora_Ingreso.Value = _Fecha_Hora_Inicio
            Fm.ShowDialog(Me)
            _Aceptar = Fm.Pro_Aceptar
            _Fecha_Hora_Inicio = Fm.Dtp_Hora_Ingreso.Value
            Dim _HHi = FormatDateTime(_Fecha_Hora_Inicio, DateFormat.ShortTime)
            Fm.Dispose()

            If _Aceptar Then

                If _Fecha_Hora_Inicio > Date.Now Then

                    MessageBoxEx.Show(Me, "La hora de inicio no puede ser mayor a la hora actual", "El cambio no fue realizado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return

                End If

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos " & Space(1) &
                               "Set Fecha_Hora_Inicio = '" & Format(_Fecha_Hora_Inicio, "yyyyMMdd") & " " & _HHi & "'" & vbCrLf &
                                "Where IdMaquina = " & _IdMaquina

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    _Fila.Cells("Fecha_Hora_Inicio").Value = _Fecha_Hora_Inicio
                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Cambio de hora", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                Sb_Actualizar_Grillas()

            End If

        End If

    End Sub

    Private Sub Sb_Ingresar_Al_Meson_Abrir()

        Consulta_sql = "Select Codmeson,Nommeson,Activo,Abierto,NombreEquipo_Abierto, Abierto_FechaHora 
                        From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson  = '" & _CodMeson & "'"

        Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Abierto As Boolean = _Row_Meson.Item("Abierto")
        Dim _NombreEquipo_Abierto As String = _Row_Meson.Item("NombreEquipo_Abierto")

        If _Abierto And _NombreEquipo = _NombreEquipo_Abierto Then
            _Abierto = False
        End If

        If _Abierto Then

            Fx_Revisar_Meson_Abierto_En_Otro_Equipo()

        Else

            Dim Abierto_FechaHora As DateTime = FechaDelServidor()

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdc_Mesones Set Abierto = 0,NombreEquipo_Abierto = '',Abierto_FechaHora = Null,Codigoob_Abierto = '' Where NombreEquipo_Abierto = '" & _NombreEquipo & "'" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Pdc_Mesones Set Abierto = 1,NombreEquipo_Abierto = '" & _NombreEquipo & "',Codigoob_Abierto = '" & _Codigoob & "',Abierto_FechaHora = Getdate()" & vbCrLf &
                           "Where Codmeson = '" & _CodMeson & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Function Fx_Revisar_Meson_Abierto_En_Otro_Equipo() As Boolean

        Consulta_sql = "Select Codmeson,Nommeson,Activo,Abierto,NombreEquipo_Abierto,Abierto_FechaHora,Codigoob_Abierto,Isnull(NOMBREOB,'') As Nombreob 
                        From " & _Global_BaseBk & "Zw_Pdc_Mesones 
                            Left Join PMAEOB On CODIGOOB = Codigoob_Abierto
                        Where Codmeson  = '" & _CodMeson & "'"

        Dim _Row_Meson As DataRow = _Tbl_Mesones.AsEnumerable().FirstOrDefault(Function(row) row.Field(Of String)("Padre") = _CodMeson)

        'Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Abierto As Boolean = _Row_Meson.Item("Abierto")
        Dim _NombreEquipo_Abierto As String = _Row_Meson.Item("NombreEquipo_Abierto")
        Dim _Nombreob As String = _Row_Meson.Item("Nombreob").ToString.Trim

        If _Abierto And _NombreEquipo = _NombreEquipo_Abierto Then
            _Abierto = False
        End If

        If _Abierto Then

            MessageBoxEx.Show(Me, "El mesón " & Cmb_Mesones.Text.Trim & " se encuentra abierto en el equipo: " & _NombreEquipo_Abierto & vbCrLf &
                              "Con el operario: " & _Nombreob & vbCrLf & vbCrLf &
                              "No es posible hacer gestión desde este equipo hasta que ese mesón haya cerrado su sesión",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows
                _Fila.Cells("Chk").Value = False
            Next

            For Each _Fila As DataGridViewRow In Grilla_Maquinas_Meson.Rows
                _Fila.Cells("Chk").Value = False
            Next

            Txt_Stx_Etx.Text = String.Empty

            Dim _FlMs As DataGridViewRow = Grilla_Productos_En_Meson.CurrentRow
            Dim _Numot As String = _FlMs.Cells("Numot").Value

            Sb_Actualizar_Grilla_Mesones_Espera(_CodMeson)
            Sb_Actualizar_Grilla_Maquinas(_CodMeson)

            BuscarDatoEnGrilla(_Numot, "Numot", Grilla_Productos_En_Meson)

            Return False

        End If

        Return True

    End Function

    Private Sub Frm_Meson_Operario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdc_Mesones Set Abierto = 0,NombreEquipo_Abierto = '',Abierto_FechaHora = Null,Codigoob_Abierto = '' 
                        Where NombreEquipo_Abierto = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Grilla_Productos_En_Meson_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos_En_Meson.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla_Productos_En_Meson.Rows(Grilla_Productos_En_Meson.CurrentRow.Index)

            Dim _Idmaeddo = _Fila.Cells("Id_Doc_Comerial").Value
            Dim _Tido = _Fila.Cells("Tido_Doc_Comercial").Value
            Dim _Nudo = _Fila.Cells("Nudo_Doc_Comercial").Value
            Dim _Cod_Vendedor = _Fila.Cells("Cod_Vendedor").Value
            Dim _Vendedor = _Fila.Cells("Vendedor").Value

            Dim _Numot = _Fila.Cells("NUMOT").Value
            Dim _Subot = _Fila.Cells("SubOT").Value
            Dim _Referencia = _Fila.Cells("SubOT").Value
            Dim _Codigo = _Fila.Cells("Codigo").Value
            Dim _Glosa = _Fila.Cells("Glosa").Value
            Dim _Descripcion = _Fila.Cells("Glosa").Value

            Lbl_Info_Linea.Text = "Producto: " & _Descripcion.ToString.Trim & ", Vendedor: " & _Cod_Vendedor.ToString.Trim & " - " & _Vendedor.ToString.Trim
        Catch ex As Exception
            Lbl_Info_Linea.Text = String.Empty
        End Try

    End Sub
End Class
