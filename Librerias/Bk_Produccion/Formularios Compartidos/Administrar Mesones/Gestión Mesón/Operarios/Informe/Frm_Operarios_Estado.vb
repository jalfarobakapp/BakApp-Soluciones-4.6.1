Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Operarios_Estado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Operarios As DataTable
    Dim _Tbl_Trabajos As DataTable

    Dim _Codigoob As String

    Public Property Codigoob As String
        Get
            Return _Codigoob
        End Get
        Set(value As String)
            _Codigoob = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim pantalla As System.Windows.Forms.Screen = System.Windows.Forms.Screen.PrimaryScreen

        If pantalla.Bounds.Width <= 1024 Then

            'Me.Size = New System.Drawing.Size(CInt(pantalla.Bounds.Width.ToString()), CInt(Me.Bounds.Height.ToString()))
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Size = New System.Drawing.Size(1000, CInt(Me.Bounds.Height.ToString()))

        End If

        Sb_Formato_Generico_Grilla(Grilla_Mesones, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Both, True, False, False)

    End Sub

    Private Sub Frm_Operarios_Estado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_FechaDesde.Value = DateTime.Now
        'Sb_Actualizar_Grillas_Operarios_En_Meson()

        Consulta_sql = "Select CODIGOOB As Padre,NOMBREOB As Hijo From PMAEOB Where CODIGOOB In (Select Codigoob From " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario)"
        _Tbl_Operarios = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Convert.ToBoolean(_Tbl_Operarios.Rows.Count) Then

            If String.IsNullOrEmpty(_Codigoob) Then
                _Codigoob = _Tbl_Operarios.Rows(0).Item("Padre")
            End If

            caract_combo(Cmb_Operarios)
            Cmb_Operarios.DataSource = _Tbl_Operarios
            Cmb_Operarios.SelectedValue = _Codigoob

            Sb_Actualizar_Grillas(_Codigoob, Dtp_FechaDesde.Value)

        End If

        'AddHandler Grilla_Maquinas.DataBindingComplete, AddressOf Sb_Grilla_Maquinas_DataBindingComplete

    End Sub

    Sub Sb_Actualizar_Grillas(_Codigoob As String, _FechaDesde As DateTime)

        Consulta_sql = My.Resources.Recursos_Inf_Operarios.Estado_Trabajos_Operario
        Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Codigoob#", _Codigoob)
        Consulta_sql = Replace(Consulta_sql, "#FechaDesde#", Format(_FechaDesde, "yyyyMMdd"))

        Dim _Ds As DataSet

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        ' Table.Rel_Entidad_Documentos.Rel_Documentos_Detalle

        '_Ds.Relations.Add("Rel_Mesones",
        '                 _Ds.Tables("Table").Columns("NUMOT"),
        '                 _Ds.Tables("Table1").Columns("NUMOT"), False)

        _Ds.Relations.Add("Rel_Meson_vs_Maquina",
                         _Ds.Tables("Table").Columns("Codmeson"),
                         _Ds.Tables("Table1").Columns("Codmeson"), False)

        '_dv.Table = _Sql.Fx_Get_DataSet(Consulta_sql, _Ds_Filtros_Busqueda, "Tbl_Filtro").Tables("Tbl_Filtro")

        Grilla_Mesones.DataSource = _Ds
        Grilla_Mesones.DataMember = "Table"

        Grilla_Maquinas.DataSource = _Ds
        Grilla_Maquinas.DataMember = "Table.Rel_Meson_vs_Maquina"

        '_Tbl_Trabajos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Mesones

            '.DataSource = _Tbl_Trabajos

            OcultarEncabezadoGrilla(Grilla_Mesones, True)

            Dim _DisplayIndex = 0

            .Columns("Codmeson").Visible = True
            .Columns("Codmeson").HeaderText = "Cod. Mesón"
            .Columns("Codmeson").Width = 100
            .Columns("Codmeson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Codmeson").DisplayIndex = _DisplayIndex
            '.Columns("Numot").Frozen = True
            _DisplayIndex += 1

            .Columns("Nommeson").Visible = True
            .Columns("Nommeson").HeaderText = "Mesón"
            .Columns("Nommeson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Nommeson").Width = 350
            .Columns("Nommeson").DisplayIndex = _DisplayIndex
            '.Columns("SubOt").Frozen = True
            _DisplayIndex += 1

            .Columns("NOMBREOP").Visible = True
            .Columns("NOMBREOP").HeaderText = "Operación"
            '.Columns("Estado_Ob").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NOMBREOP").Width = 350
            .Columns("NOMBREOP").DisplayIndex = _DisplayIndex
            '.Columns("Estado").Frozen = True
            _DisplayIndex += 1

            '.Columns("Nommeson").Visible = True
            '.Columns("Nommeson").HeaderText = "Mesón"
            ''.Columns("Nommeson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Nommeson").Width = 250
            '.Columns("Nommeson").DisplayIndex = _DisplayIndex
            ''.Columns("Idpotpr").Frozen = True
            '_DisplayIndex += 1

            '.Columns("NOMBREMAQ").Visible = True
            '.Columns("NOMBREMAQ").HeaderText = "Máquina"
            ''.Columns("NOMBREMAQ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("NOMBREMAQ").Width = 160
            '.Columns("NOMBREMAQ").DisplayIndex = _DisplayIndex
            ''.Columns("Idpotpr").Frozen = True
            '_DisplayIndex += 1

            ''.Columns("Referencia").Visible = True
            ''.Columns("Referencia").HeaderText = "Referencia / Cliente"
            ''.Columns("Referencia").Width = 265
            ''.Columns("Referencia").DisplayIndex = _DisplayIndex
            '''.Columns("Referencia").Frozen = True
            ''_DisplayIndex += 1

            ''.Columns("Codigo").Visible = True
            ''.Columns("Codigo").HeaderText = "Código"
            ''.Columns("Codigo").Width = 100
            ''.Columns("Codigo").DisplayIndex = 4

            '.Columns("Descripcion").Visible = True
            '.Columns("Descripcion").HeaderText = "Descripción"
            '.Columns("Descripcion").Width = 330
            '.Columns("Descripcion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Fecha_Hora_Inicio").Visible = True
            '.Columns("Fecha_Hora_Inicio").HeaderText = "Fecha Inicio"
            '.Columns("Fecha_Hora_Inicio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Fecha_Hora_Inicio").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            '.Columns("Fecha_Hora_Inicio").Width = 120
            '.Columns("Fecha_Hora_Inicio").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Fecha_Hora_Termino").Visible = True
            '.Columns("Fecha_Hora_Termino").HeaderText = "Fecha Termino"
            '.Columns("Fecha_Hora_Termino").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Fecha_Hora_Termino").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            '.Columns("Fecha_Hora_Termino").Width = 120
            '.Columns("Fecha_Hora_Termino").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Tiempo_En_Maquina").Visible = True
            '.Columns("Tiempo_En_Maquina").HeaderText = "Tpo en Mesón"
            '.Columns("Tiempo_En_Maquina").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Tiempo_En_Maquina").Width = 60
            '.Columns("Tiempo_En_Maquina").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            ''.Columns("Hora").Visible = True
            '.Columns("Hora").HeaderText = "Hora"
            '.Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            '.Columns("Hora").Width = 60
            '.Columns("Hora").DisplayIndex = 8

            '.Columns("Dias_En_Meson").Visible = True
            '.Columns("Dias_En_Meson").HeaderText = "Días en mesón"
            '.Columns("Dias_En_Meson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dias_En_Meson").Width = 60
            '.Columns("Dias_En_Meson").DisplayIndex = 8

            '.Columns("Orden2").Visible = False
            '.Columns("Orden2").HeaderText = "Orden2"
            '.Columns("Orden2").Width = 50
            '.Columns("Orden2").DisplayIndex = 6

            '.Columns("Fabricar_New").Visible = True
            '.Columns("Fabricar_New").HeaderText = "Fabricar"
            '.Columns("Fabricar_New").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Fabricar_New").Width = 60
            '.Columns("Fabricar_New").DisplayIndex = 10

            '.Columns("Fabricado").Visible = True
            '.Columns("Fabricado").HeaderText = "Fabricado"
            '.Columns("Fabricado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Fabricado").Width = 60
            '.Columns("Fabricado").DisplayIndex = 11

            '.Columns("Saldo_Fabricar_New").Visible = True
            '.Columns("Saldo_Fabricar_New").HeaderText = "Fabricar"
            '.Columns("Saldo_Fabricar_New").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Saldo_Fabricar_New").Width = 60
            '.Columns("Saldo_Fabricar_New").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Porc_Avance_Saldo_Fab").Visible = True
            '.Columns("Porc_Avance_Saldo_Fab").HeaderText = "% Av."
            '.Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Format = "% ##.##"
            '.Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Porc_Avance_Saldo_Fab").Width = 50
            '.Columns("Porc_Avance_Saldo_Fab").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

        With Grilla_Maquinas

            '.DataSource = _Tbl_Trabajos

            OcultarEncabezadoGrilla(Grilla_Maquinas, True)

            Dim _DisplayIndex = 0

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").Width = 40
            .Columns("Numot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Numot").DisplayIndex = _DisplayIndex
            '.Columns("Numot").Frozen = True
            _DisplayIndex += 1

            .Columns("REFERENCIA").Visible = True
            .Columns("REFERENCIA").HeaderText = "Referencia"
            .Columns("REFERENCIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("REFERENCIA").Width = 200
            .Columns("REFERENCIA").DisplayIndex = _DisplayIndex
            '.Columns("SubOt").Frozen = True
            _DisplayIndex += 1

            .Columns("SubOt").Visible = True
            .Columns("SubOt").HeaderText = "Sub"
            .Columns("SubOt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("SubOt").Width = 40
            .Columns("SubOt").DisplayIndex = _DisplayIndex
            '.Columns("SubOt").Frozen = True
            _DisplayIndex += 1

            .Columns("Estado_Ob").Visible = True
            .Columns("Estado_Ob").HeaderText = "Estado"
            '.Columns("Estado_Ob").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado_Ob").Width = 70
            .Columns("Estado_Ob").DisplayIndex = _DisplayIndex
            '.Columns("Estado").Frozen = True
            _DisplayIndex += 1

            .Columns("NOMBREMAQ").Visible = True
            .Columns("NOMBREMAQ").HeaderText = "Máquina"
            '.Columns("NOMBREMAQ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NOMBREMAQ").Width = 150
            .Columns("NOMBREMAQ").DisplayIndex = _DisplayIndex
            '.Columns("Idpotpr").Frozen = True
            _DisplayIndex += 1

            '.Columns("Referencia").Visible = True
            '.Columns("Referencia").HeaderText = "Referencia / Cliente"
            '.Columns("Referencia").Width = 265
            '.Columns("Referencia").DisplayIndex = _DisplayIndex
            ''.Columns("Referencia").Frozen = True
            '_DisplayIndex += 1

            '.Columns("Codigo").Visible = True
            '.Columns("Codigo").HeaderText = "Código"
            '.Columns("Codigo").Width = 100
            '.Columns("Codigo").DisplayIndex = 4

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 330
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora_Inicio").Visible = True
            .Columns("Hora_Inicio").HeaderText = "Ini."
            .Columns("Hora_Inicio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Hora_Inicio").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            .Columns("Hora_Inicio").Width = 40
            .Columns("Hora_Inicio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora_Termino").Visible = True
            .Columns("Hora_Termino").HeaderText = "Ter."
            .Columns("Hora_Termino").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Hora_Termino").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            .Columns("Hora_Termino").Width = 40
            .Columns("Hora_Termino").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tiempo_En_Maquina").Visible = True
            .Columns("Tiempo_En_Maquina").HeaderText = "Tpo en Mesón"
            .Columns("Tiempo_En_Maquina").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tiempo_En_Maquina").Width = 80
            .Columns("Tiempo_En_Maquina").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Hora").Visible = True
            '.Columns("Hora").HeaderText = "Hora"
            '.Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            '.Columns("Hora").Width = 60
            '.Columns("Hora").DisplayIndex = 8

            '.Columns("Dias_En_Meson").Visible = True
            '.Columns("Dias_En_Meson").HeaderText = "Días en mesón"
            '.Columns("Dias_En_Meson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dias_En_Meson").Width = 60
            '.Columns("Dias_En_Meson").DisplayIndex = 8

            '.Columns("Orden2").Visible = False
            '.Columns("Orden2").HeaderText = "Orden2"
            '.Columns("Orden2").Width = 50
            '.Columns("Orden2").DisplayIndex = 6

            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").HeaderText = "Fabricar"
            .Columns("Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricar").Width = 60
            .Columns("Fabricar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fabricado").Visible = True
            .Columns("Fabricado").HeaderText = "Fabricado"
            .Columns("Fabricado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricado").Width = 60
            .Columns("Fabricado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Porc_Fabricacion").Visible = True
            '.Columns("Porc_Fabricacion").HeaderText = "% Av."
            '.Columns("Porc_Fabricacion").DefaultCellStyle.Format = "% ##.##"
            '.Columns("Porc_Fabricacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Porc_Fabricacion").Width = 50
            '.Columns("Porc_Fabricacion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Porc_Avance_Saldo_Fab").Visible = True
            .Columns("Porc_Avance_Saldo_Fab").HeaderText = "% Av."
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Format = "% ##.##"
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Avance_Saldo_Fab").Width = 50
            .Columns("Porc_Avance_Saldo_Fab").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla_Maquinas.Rows

            Dim _Fabricar As Double = NuloPorNro(_Fila.Cells("Fabricar").Value, 0)
            Dim _Fabricado As Double = NuloPorNro(_Fila.Cells("Fabricado").Value, 0)
            'Dim _Grado = _Fila.Cells("Grado").Value
            Dim _Estado = _Fila.Cells("Estado").Value
            Dim _Estado_Pote = _Fila.Cells("ESTADO").Value
            'Dim _Reproceso = _Fila.Cells("Reproceso").Value

            'If _Fabricar = _Fabricado Then
            '    _Fila.DefaultCellStyle.ForeColor = Color.Red
            'End If

            'If _Estado = "MQ" Then
            '    _Fila.DefaultCellStyle.ForeColor = Color.LightGray
            'End If

            'If _Grado = 1 Then
            '    _Fila.DefaultCellStyle.BackColor = Color.Red 'LightCoral
            '    _Fila.DefaultCellStyle.ForeColor = Color.White
            'ElseIf _Grado = 2 Then
            '    _Fila.DefaultCellStyle.BackColor = Color.Yellow 'LightYellow
            'Else
            '    _Fila.DefaultCellStyle.BackColor = Color.White
            'End If

            'If _Estado_Pote = "S" Then
            '    _Fila.DefaultCellStyle.ForeColor = Color.Gray
            'End If

            'If _Reproceso Then
            '    _Fila.DefaultCellStyle.BackColor = Color.Green
            '    _Fila.DefaultCellStyle.ForeColor = Color.White
            'End If

        Next

        'Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Maquinas, "Tiempo_En_Maquina")
        Sb_Tiempo_En_Mesones_y_Maquinas2(_Ds.Tables(1), "Tiempo_En_Maquina")

    End Sub

    Sub Sb_Tiempo_En_Mesones_y_Maquinas(Grilla As DataGridView, _Campo_Tiempo As String)

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Fecha_Hora_Inicio As DateTime? = NuloPorNro(_Row.Cells("Fecha_Hora_Inicio").Value, Nothing)
            Dim _Fecha_Hora_Termino As DateTime? = NuloPorNro(_Row.Cells("Fecha_Hora_Termino").Value, DateTime.Now)

            Dim _Estado_Pote = NuloPorNro(_Row.Cells("ESTADO").Value, "")

            If _Estado_Pote = "S" Then

                _Row.Cells(_Campo_Tiempo).Value = "EN PAUSA..."

            Else

                If _Fecha_Hora_Inicio.HasValue Then

                    Dim _Fecha_Rev As DateTime = _Fecha_Hora_Termino.Value

                    Dim ts As TimeSpan = _Fecha_Rev.Subtract(_Fecha_Hora_Inicio)
                    'Fx_Fecha_y_Hora_del_Servidor.Subtract(_Fecha_Hora_Inicio)

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

                    Dim _Tiempo As String

                    _Tiempo = _Dias & _Horas & _Minutos

                    If String.IsNullOrEmpty(_Tiempo) Then _Tiempo = " - 1 Min "

                    _Row.Cells(_Campo_Tiempo).Value = _Tiempo

                End If

            End If

        Next

    End Sub

    Sub Sb_Tiempo_En_Mesones_y_Maquinas2(ByRef _Tbl As DataTable, _Campo_Tiempo As String)

        For Each _Row As DataRow In _Tbl.Rows

            Dim _Fecha_Hora_Inicio As DateTime? = NuloPorNro(_Row.Item("Fecha_Hora_Inicio"), Nothing)
            Dim _Fecha_Hora_Termino As DateTime? = NuloPorNro(_Row.Item("Fecha_Hora_Termino"), DateTime.Now)

            Dim _Estado_Pote = NuloPorNro(_Row.Item("ESTADO"), "")

            If _Estado_Pote = "S" Then

                _Row.Item(_Campo_Tiempo) = "EN PAUSA..."

            Else

                If _Fecha_Hora_Inicio.HasValue Then

                    Dim _Fecha_Rev As DateTime = _Fecha_Hora_Termino

                    Dim ts As TimeSpan = _Fecha_Rev.Subtract(_Fecha_Hora_Inicio)

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

                    Dim _Tiempo As String

                    _Tiempo = _Dias & _Horas & _Minutos

                    If String.IsNullOrEmpty(_Tiempo) Then
                        _Tiempo = " - 1 Min "
                    End If

                    _Row.Item(_Campo_Tiempo) = _Tiempo

                End If

            End If

        Next

    End Sub

    Private Sub Cmb_Operarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Operarios.SelectedIndexChanged

        _Codigoob = Cmb_Operarios.SelectedValue
        Sb_Actualizar_Grillas(_Codigoob, Dtp_FechaDesde.Value)

    End Sub

    Private Sub Dtp_FechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaDesde.ValueChanged

        _Codigoob = Cmb_Operarios.SelectedValue
        Sb_Actualizar_Grillas(_Codigoob, Dtp_FechaDesde.Value)

    End Sub

    Private Sub Grilla_Trabajos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Mesones.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)

        Dim _Numot As String = numero_(_Fila.Cells("Numot").Value, 10)

        Dim Fm As New Frm_Inf_Prod_Avance_OT
        Fm.Pro_Numot = _Numot
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    'Private Sub Sb_Grilla_Maquinas_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
    '    Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Maquinas, "Tiempo_En_Maquina")
    'End Sub

End Class
