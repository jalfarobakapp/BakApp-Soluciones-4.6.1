
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar


Public Class Frm_Meson_Operario_Cambio_Mesones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Meson_Izquierda As DataTable
    Dim _Tbl_Meson_Derecha As DataTable

    Dim _Row_Meson_Izq, _Row_Meson_Der As DataRow

    Dim _Actualizado As Boolean
    Dim _Condicion_Adicional_Meson_Izquierda As String
    Dim _Condicion_Adicional_Meson_Derecha As String

    Public Property Pro_Actualizado As Boolean
        Get
            Return _Actualizado
        End Get
        Set(value As Boolean)
            _Actualizado = value
        End Set
    End Property

    Public Property Pro_Row_Meson_Izq As DataRow
        Get
            Return _Row_Meson_Izq
        End Get
        Set(value As DataRow)
            _Row_Meson_Izq = value
        End Set
    End Property

    Public Property Pro_Row_Meson_Der As DataRow
        Get
            Return _Row_Meson_Der
        End Get
        Set(value As DataRow)
            _Row_Meson_Der = value
        End Set
    End Property

    Public Property Pro_Condicion_Adicional_Meson_Izquierda As String
        Get
            Return _Condicion_Adicional_Meson_Izquierda
        End Get
        Set(value As String)
            _Condicion_Adicional_Meson_Izquierda = value
        End Set
    End Property

    Public Property Pro_Condicion_Adicional_Meson_Derecha As String
        Get
            Return _Condicion_Adicional_Meson_Derecha
        End Get
        Set(value As String)
            _Condicion_Adicional_Meson_Derecha = value
        End Set
    End Property

    Public Sub New(CodMeson As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & CodMeson & "'"
        _Row_Meson_Izq = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Meson_Izq) Then

            Dim _Operacion = _Row_Meson_Izq.Item("Operacion")
            Dim _Operacion_Equivalente = _Row_Meson_Izq.Item("Operacion_Equivalente")

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdc_Mesones 
                            Where Operacion = '" & _Operacion_Equivalente & "' And Operacion_Equivalente = '" & _Operacion & "'"
            _Row_Meson_Der = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        Sb_Formato_Generico_Grilla(Grilla_Izquierda, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Derecha, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Meson_Operario_Cambio_Mesones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla_Meson_Espera(_Row_Meson_Izq.Item("Codmeson"), Grilla_Izquierda, _Condicion_Adicional_Meson_Izquierda)
        Sb_Actualizar_Grilla_Meson_Espera(_Row_Meson_Der.Item("Codmeson"), Grilla_Derecha, _Condicion_Adicional_Meson_Derecha)

        Dim _Nommeson_Izq = _Row_Meson_Izq.Item("Nommeson")
        Dim _Nommeson_Der = _Row_Meson_Der.Item("Nommeson")

        Grupo_Izquierda.Text = _Nommeson_Izq
        Grupo_Derecha.Text = _Nommeson_Der

        AddHandler Grilla_Izquierda.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Derecha.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla_Meson_Espera(_Codmeson As String, Grilla As DataGridView,
                                          _Condicion_Adicional As String)

        Consulta_sql = "Select Cast(0 As Bit) As Chk,IdMeson, Codmeson,Estado,Idpote,Idpotpr,Substring(Numot,6,10) As Numot,Nreg,
                        Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) As SubOt,REFERENCIA As Referencia,Codigo,Operacion,Nombreop,Glosa,Fecha_Asignacion As Fecha,
                        DATEDIFF(DD,FIOT,GETDATE()) As Dias,DATEDIFF(DD,Fecha_Asignacion,GETDATE()) As Dias_En_Meson,Fecha_Asignacion As Hora,
	                    Orden_Meson,Orden_Potpr,Fabricar,Fabricar-Fabricando As Fabricar_New,Fabricado,Fabricando,Saldo_Fabricar,Porc_Avance_Saldo_Fab,
                        Saldo_Fabricar-Fabricando As Saldo_Fabricar_New,Idpotl,Idpotpr,CODMAQOT,Cast('' As Varchar) As Tiempo_En_Meson" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos " & vbCrLf &
                        "INNER JOIN POTPR ON Idpotpr=IDPOTPR" & vbCrLf &
                        "INNER JOIN POTE ON Idpote=IDPOTE" & vbCrLf &
                        "WHERE Codmeson='" & _Codmeson & "' AND Estado In ('PD','MQ') And POTE.ESTADO = 'V'" & vbCrLf &
                        _Condicion_Adicional & vbCrLf &
                        "ORDER BY Orden_Meson"

        Dim _Tbl_Productos_En_Meson As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Productos_En_Meson

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").Width = 40
            .Columns("Numot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Numot").DisplayIndex = 1

            .Columns("SubOt").Visible = True
            .Columns("SubOt").HeaderText = "Sub-OT"
            .Columns("SubOt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SubOt").Width = 55
            .Columns("SubOt").DisplayIndex = 2

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Est."
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").Width = 25
            .Columns("Estado").DisplayIndex = 4

            .Columns("Referencia").Visible = True
            .Columns("Referencia").HeaderText = "Referencia / Cliente"
            .Columns("Referencia").Width = 190
            .Columns("Referencia").DisplayIndex = 5

            .Columns("Saldo_Fabricar_New").Visible = True
            .Columns("Saldo_Fabricar_New").HeaderText = "Fab."
            .Columns("Saldo_Fabricar_New").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo_Fabricar_New").Width = 40
            .Columns("Saldo_Fabricar_New").DisplayIndex = 12

            .Columns("Porc_Avance_Saldo_Fab").Visible = True
            .Columns("Porc_Avance_Saldo_Fab").HeaderText = "%"
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Format = "% ##.##"
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Avance_Saldo_Fab").Width = 40
            .Columns("Porc_Avance_Saldo_Fab").DisplayIndex = 13

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Fabricar = _Fila.Cells("Fabricar").Value
            Dim _Fabricado = _Fila.Cells("Fabricado").Value

            If _Fabricar = _Fabricado Then
                _Fila.DefaultCellStyle.ForeColor = Color.Red
            End If

            Dim _Estado = _Fila.Cells("Estado").Value
            If _Estado = "MQ" Then
                _Fila.DefaultCellStyle.ForeColor = Color.LightGray
            End If

        Next

    End Sub

    Private Sub Btn_Cambiar_de_Izquierda_a_derecha_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_de_Izquierda_a_derecha.Click

        Dim _Fila As DataGridViewRow

        Try

            _Fila = Grilla_Izquierda.Rows(Grilla_Izquierda.CurrentRow.Index)

        Catch ex As Exception

            If CBool(Grilla_Izquierda.Rows.Count) Then

                Beep()
                ToastNotification.Show(Me, "DEBE SELECCIONAR UNA FILA", Nothing,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return

            End If

        End Try

        If CBool(Grilla_Izquierda.Rows.Count) Then

            Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
            Dim _New_Codmeson = _Row_Meson_Der.Item("Codmeson")
            Dim _Operacion_Equivalente = _Row_Meson_Izq.Item("Operacion_Equivalente")

            Sb_Cambiar_Producto_De_Meson(_IdMeson, _Operacion_Equivalente, _New_Codmeson)

        Else
            Beep()
        End If

    End Sub

    Private Sub Btn_Cambiar_de_Derecha_a_izquierda_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_de_Derecha_a_izquierda.Click

        Dim _Fila As DataGridViewRow

        Try

            _Fila = Grilla_Derecha.Rows(Grilla_Derecha.CurrentRow.Index)

        Catch ex As Exception

            If CBool(Grilla_Derecha.Rows.Count) Then

                Beep()
                ToastNotification.Show(Me, "DEBE SELECCIONAR UNA FILA", Nothing,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return

            End If

        End Try

        If CBool(Grilla_Derecha.Rows.Count) Then

            Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
            Dim _New_Codmeson = _Row_Meson_Izq.Item("Codmeson")
            Dim _Operacion_Equivalente = _Row_Meson_Der.Item("Operacion_Equivalente")

            Sb_Cambiar_Producto_De_Meson(_IdMeson, _Operacion_Equivalente, _New_Codmeson)

        Else
            Beep()
        End If

    End Sub

    Sub Sb_Cambiar_Producto_De_Meson(_IdMeson As Integer, _Operacion_Equivalente As String, _New_Codmeson As String)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where IdMeson = " & _IdMeson
        Dim _Fila As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Try

            'Dim _IdMeson = _Fila.Item("IdMeson")
            Dim _Idpote = _Fila.Item("Idpote")
            Dim _Idpotl = _Fila.Item("Idpotl")
            Dim _Orden_Potpr = _Fila.Item("Orden_Potpr")
            Dim _Estado = _Fila.Item("Estado")

            Dim _Row_Potpr As DataRow

            Select Case _Estado

                Case "PD"

                    If Not String.IsNullOrEmpty(_Operacion_Equivalente) Then

                        Consulta_sql = "Select * From POTPR Where IDPOTL = " & _Idpotl & "-- And ORDEN > " & _Orden_Potpr
                        Dim _Tbl_Potpr As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                        For Each _Fila_Potpr As DataRow In _Tbl_Potpr.Rows

                            Dim _Oper = _Fila_Potpr.Item("OPERACION")

                            If _Oper = _Operacion_Equivalente Then
                                _Row_Potpr = _Fila_Potpr
                                Exit For
                            End If

                        Next

                    End If

                    If Not IsNothing(_Row_Potpr) Then

                        Dim _New_Idpotpr = _Row_Potpr.Item("IDPOTPR")
                        Dim _New_Idpotl = _Row_Potpr.Item("IDPOTL")
                        Dim _New_Operacion = _Row_Potpr.Item("OPERACION")
                        Dim _New_Nombreop As String = _Sql.Fx_Trae_Dato("POPER", "NOMBREOP", "OPERACION = '" & _New_Operacion & "'")
                        Dim _New_Orden_Potpr = _Row_Potpr.Item("ORDEN")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set 
                        Codmeson = '" & _New_Codmeson & "',Idpotl = " & _New_Idpotl & ",Idpotpr = " & _New_Idpotpr & ",
                        Operacion = '" & _New_Operacion & "',Nombreop = '" & _New_Nombreop & "',Orden_Potpr = " & _New_Orden_Potpr & ",
                        Fecha_Asignacion = Getdate(),Asignado_Por = '" & FUNCIONARIO & "' 
                        Where IdMeson = " & _IdMeson
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    Else

                        MessageBoxEx.Show(Me, "No se encontro la opreción " & _Operacion_Equivalente & " en las opreaciones de la Sub OT",
                                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If

                Case "MQ"

                    MessageBoxEx.Show(Me, "Este producto ya se encuentra en la maquina" & vbCrLf &
                                      "No se puede mover el producto de mesón." & vbCrLf &
                                      "El operario debe finalizar el proceso para que puede hacer el cambio", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Case "DM"

                    MessageBoxEx.Show(Me, "Este producto ya no esta en este mesón" & vbCrLf &
                                      "Los datos fueron actualizados mientras usted hacia el cambio", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End Select


        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Dim _Codmeson_Izq = Trim(_Row_Meson_Izq.Item("Codmeson"))
            Dim _Codmeson_Der = Trim(_Row_Meson_Der.Item("Codmeson"))

            _Actualizado = True
            Sb_Actualizar_Grilla_Meson_Espera(_Codmeson_Izq, Grilla_Izquierda, _Condicion_Adicional_Meson_Izquierda)
            Sb_Actualizar_Grilla_Meson_Espera(_Codmeson_Der, Grilla_Derecha, _Condicion_Adicional_Meson_Derecha)

        End Try

    End Sub

    Private Sub Frm_Meson_Operario_Cambio_Mesones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyValue
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                Btn_Actualizar_Click(Nothing, Nothing)
        End Select

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click

        Sb_Actualizar_Grilla_Meson_Espera(_Row_Meson_Izq.Item("Codmeson"), Grilla_Izquierda, _Condicion_Adicional_Meson_Izquierda)
        Sb_Actualizar_Grilla_Meson_Espera(_Row_Meson_Der.Item("Codmeson"), Grilla_Derecha, _Condicion_Adicional_Meson_Derecha)

    End Sub

    Private Sub Grilla_Izquierda_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Izquierda.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla_Izquierda.Rows(Grilla_Izquierda.CurrentRow.Index)
            Lbl_Producto_Izquierda.Text = _Fila.Cells("Codigo").Value & " - " & _Fila.Cells("Glosa").Value
        Catch ex As Exception
            Lbl_Producto_Izquierda.Text = String.Empty
        End Try

    End Sub

    Private Sub Grilla_Derecha_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Derecha.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla_Derecha.Rows(Grilla_Derecha.CurrentRow.Index)
            Lbl_Producto_Derecha.Text = _Fila.Cells("Codigo").Value & " - " & _Fila.Cells("Glosa").Value
        Catch ex As Exception
            Lbl_Producto_Derecha.Text = String.Empty
        End Try

    End Sub

    Sub Sb_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)

        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
