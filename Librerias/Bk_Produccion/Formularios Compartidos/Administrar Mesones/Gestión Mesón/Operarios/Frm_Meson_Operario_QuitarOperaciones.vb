Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Meson_Operario_QuitarOperaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigoob As String
    Dim _Idpotl As Integer
    Dim _Idpotpr As Integer
    Dim _TblMesones As DataTable
    Dim _Enviar As Boolean

    Public Property TblMesones As DataTable
        Get
            Return _TblMesones
        End Get
        Set(value As DataTable)
            _TblMesones = value
        End Set
    End Property

    Public Property Enviar As Boolean
        Get
            Return _Enviar
        End Get
        Set(value As Boolean)
            _Enviar = value
        End Set
    End Property

    Public Sub New(_Codigoob As String, _Idpotl As Integer, _Idpotpr As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigoob = _Codigoob
        Me._Idpotl = _Idpotl
        Me._Idpotpr = _Idpotpr

        Sb_Formato_Generico_Grilla(Grilla_Meson, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Both, True, False, False)

    End Sub

    Private Sub Frm_Meson_Operario_SigMesSerTecnico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
        AddHandler Grilla_Meson.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
    End Sub


    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "SELECT IDPOTPR,POTPR.OPERACION,IDPOTL,Cast(0 As Bit) As Hecho,NUMOT, --IDPOTPR,IDPOTL,NUMOT,NREGOTL,CODIGO,CODMAQOT,POTPR.OPERACION,POTPR.ORDEN,FABRICAR,REALIZADO,FABRICAR-REALIZADO AS FALTANTE,
                        COALESCE(ORDEN,'000') As Orden2,
	                    Cast(0 As Bit) As Chk,
	                    " & _Global_BaseBk & "Zw_Pdc_Mesones.Codmeson,
	                    NOMBREOP,Nommeson,Virtual,
	                    Isnull((SELECT Top 1 Estado FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos WHERE Idpotpr=IDPOTPR),'') as Est_Meson,
	                       (SELECT COUNT(*) 
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR) as Activos, 
	                       (SELECT COUNT(*) 
	                        FROM " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos
		                    WHERE Idpotpr=IDPOTPR And Estado <> 'FMQ') as ActivosMaq,
		                    Isnull((SELECT Top 1 Saldo_Fabricar
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Saldo_Fabricar,
			                    Isnull((SELECT Top 1 Porc_Fabricacion
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Porc_Fabricacion,
			                    Isnull((SELECT Top 1 Reproceso
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Reproceso,
			                    Isnull((SELECT Top 1 Cant_Reproceso
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Cant_Reproceso,
                            Cast(0 As Bit) As 'Meson_Actual',
                            Cast('' As Varchar(30)) As ProxMeson
                    Into #Paso_Potpr
		                    FROM POTPR 
			                    INNER JOIN " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina ON 
				                    " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina.Codmaq=POTPR.CODMAQOT 
					                    INNER JOIN " & _Global_BaseBk & "Zw_Pdc_Mesones ON 
						                    " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina.Codmeson=" & _Global_BaseBk & "Zw_Pdc_Mesones.Codmeson 
							                    INNER JOIN POPER ON 
								                    POPER.OPERACION=POTPR.OPERACION 
                    WHERE IDPOTL = " & _Idpotl & "
                    ORDER BY ORDEN
                    
                    Update #Paso_Potpr Set Hecho = 1 Where Est_Meson <> ''
                    Update #Paso_Potpr Set Chk = 1 Where Est_Meson = ''

                    Select * From #Paso_Potpr
                    Drop Table #Paso_Potpr"

        _TblMesones = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _TblMesones.Rows
            If _Fila.Item("IDPOTPR") = _Idpotpr Then
                _Fila.Item("Meson_Actual") = True
                Exit For
            End If
        Next

        Dim _DisplayIndex = 0

        With Grilla_Meson

            .DataSource = _TblMesones

            OcultarEncabezadoGrilla(Grilla_Meson, True)

            '.Columns("Btn_Ico").Visible = True
            '.Columns("Btn_Ico").HeaderText = "A."
            '.Columns("Btn_Ico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Btn_Ico").Width = 30
            '.Columns("Btn_Ico").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nommeson").Visible = True
            .Columns("Nommeson").HeaderText = "OT"
            .Columns("Nommeson").Width = 400
            .Columns("Nommeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ProxMeson").Visible = True
            .Columns("ProxMeson").HeaderText = "..."
            .Columns("ProxMeson").Width = 200
            .Columns("ProxMeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Btn_Accion").Visible = True
            '.Columns("Btn_Accion").HeaderText = "Acción"
            '.Columns("Btn_Accion").Width = 120
            '.Columns("Btn_Accion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

        'InsertarBotonenGrilla(Grilla_Meson, "Btn_Cmb", "Grabar", "Grabar", _DisplayIndex - 1, _Tipo_Boton.Imagen)

        Dim _NextMeson As Boolean

        For Each _Fila As DataGridViewRow In Grilla_Meson.Rows

            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            Dim _Hecho As Boolean = _Fila.Cells("Hecho").Value
            Dim _Meson_Actual As Boolean = _Fila.Cells("Meson_Actual").Value

            If _Chk Then
                _Fila.Cells("Nommeson").Style.ForeColor = Verde
                _Fila.Cells("ProxMeson").Value = "<- Procesar..."
            Else
                _Fila.Cells("Nommeson").Style.ForeColor = Color.Gray
            End If

            'If _Hecho Then
            '    _Fila.Cells("Btn_Cmb").Value = Img_Imagenes.Images("folder_open_false.png")
            'End If

            If _NextMeson Then
                '_Fila.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_True")
                '_Fila.Cells("ProxMeson").Value = "<- Procesar..."
            Else
                If Not _Hecho Then
                    ' _Fila.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_False")
                End If
            End If

            If _Meson_Actual Then
                _NextMeson = True
            Else
                _NextMeson = False
            End If

        Next


    End Sub

    Private Sub Grilla_Meson_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla_Meson.CellMouseDown
        Grilla_Meson.EndEdit()
    End Sub

    Private Sub Grilla_Meson_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla_Meson.CellBeginEdit

        Dim _Cabeza = Grilla_Meson.Columns(Grilla_Meson.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Meson.Rows(Grilla_Meson.CurrentRow.Index)
        Dim _Index = Grilla_Meson.CurrentRow.Index
        Dim _UlIndex = Grilla_Meson.RowCount - 1
        Dim _OrdenFila = _Fila.Cells("Orden2").Value
        Dim _Hecho As Boolean = _Fila.Cells("Hecho").Value
        Dim _Chk As Boolean = _Fila.Cells("Chk").Value

        If _Hecho Then
            e.Cancel = True
            Beep()
            Return
        End If

        If _Index = Grilla_Meson.RowCount - 1 Then
            Beep()
            ToastNotification.Show(Me, "EL ULTIMO MESON NO SE PUEDE QUITAR", Nothing,
                               3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            e.Cancel = True
            Return
        End If

        Return

        'Dim _FilaArriba As DataGridViewRow
        'Dim _FilaAbajo As DataGridViewRow

        'Try
        '    _FilaArriba = Grilla_Meson.Rows(_Index - 1)
        'Catch ex As Exception
        '    _FilaArriba = Nothing
        'End Try

        'Try
        '    _FilaAbajo = Grilla_Meson.Rows(_Index + 1)
        'Catch ex As Exception
        '    _FilaAbajo = Nothing
        'End Try

        'If Not IsNothing(_FilaArriba) Then
        '    If _FilaArriba.Cells("Chk").Value Then
        '        e.Cancel = True
        '        Beep()
        '        Return
        '    End If
        'End If

        'If Not IsNothing(_FilaAbajo) Then
        '    If Not _FilaAbajo.Cells("Chk").Value Then
        '        e.Cancel = True
        '        Beep()
        '        Return
        '    End If
        'End If

    End Sub

    Private Sub Grilla_Meson_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Meson.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla_Meson.Rows(Grilla_Meson.CurrentRow.Index)
        Dim _Index = Grilla_Meson.CurrentRow.Index
        Dim _UlIndex = Grilla_Meson.RowCount - 1

        Dim _FilaArriba As DataGridViewRow
        Dim _FilaAbajo As DataGridViewRow

        Try
            _FilaArriba = Grilla_Meson.Rows(_Index - 1)
        Catch ex As Exception
            _FilaArriba = Nothing
        End Try

        Try
            _FilaAbajo = Grilla_Meson.Rows(_Index + 1)
        Catch ex As Exception
            _FilaAbajo = Nothing
        End Try

        If _Fila.Cells("Chk").Value Then

            '_Fila.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_True")
            _Fila.Cells("Nommeson").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            _Fila.Cells("Nommeson").Style.ForeColor = Verde
            _Fila.Cells("ProxMeson").Value = "<- Procesar..."

            'If Not IsNothing(_FilaAbajo) Then
            '    '_FilaAbajo.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_false")
            '    _FilaAbajo.Cells("ProxMeson").Value = String.Empty
            'End If

        End If

        If Not _Fila.Cells("Chk").Value Then

            '_Fila.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_False")
            _Fila.Cells("Nommeson").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            _Fila.Cells("Nommeson").Style.ForeColor = Rojo
            _Fila.Cells("ProxMeson").Value = String.Empty

            'If Not IsNothing(_FilaAbajo) Then
            '    If _FilaAbajo.Cells("Chk").Value Then
            '        '_FilaAbajo.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_True")
            '        '_FilaAbajo.Cells("ProxMeson").Value = "<- Enviar al proximo mesón"
            '    End If
            'End If

        End If

        Me.Refresh()

    End Sub

    Private Sub Grilla_Meson_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla_Meson.CellMouseUp
        Grilla_Meson.EndEdit()
    End Sub

    Private Sub Frm_Meson_Operario_SigMesSerTecnico_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If MessageBoxEx.Show(Me, "¿CONFIRMA DEJAR SOLO LOS MESONES SELECCIONADOS CON VERDE?", "Quitar operaciones",
                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then

            For Each _Fila As DataRow In _TblMesones.Rows

                Dim _Idpotpr As Integer = _Fila.Item("IDPOTPR")
                Dim _Idpotl As Integer = _Fila.Item("IDPOTL")
                Dim _Operacion As String = _Fila.Item("OPERACION")
                Dim _Orden As Integer = _Fila.Item("Orden2")
                Dim _Chk As Boolean = _Fila.Item("Chk")
                Dim _Hecho As Boolean = _Fila.Item("Hecho")
                Dim _Numot As String = _Fila.Item("NUMOT")

                If Not _Chk And Not _Hecho Then
                    Consulta_sql = "DELETE POTPR WHERE POTPR.IDPOTPR = " & _Idpotpr
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "POTL", _Idpotl, "EliminaOp", "Operario: " & _Codigoob & ", Elimina Operacion: " & _Operacion & ", OT: " & _Numot & " (Item: " & _Orden & ")", "", "", "", "", False, "")
                    End If
                End If

            Next

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Validar operacines", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Enviar = True
            Me.Close()

        End If

    End Sub
End Class
