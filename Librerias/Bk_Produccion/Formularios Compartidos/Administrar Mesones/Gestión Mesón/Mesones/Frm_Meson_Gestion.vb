
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Busqueda_OT

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Dim _FilaProductos As DataGridViewRow
    Dim _OrdenProducto As Integer
    Dim _Codmeson As String
    Dim _Numot As String
    Dim _IdOrden As Integer

    Dim _Tbl_Mesones As DataTable
    Dim _Tbl_Prod_Meson As DataTable
    Dim _Tbl_Prod_Maquinas As DataTable
    Dim _Tbl_Oper_Meson As DataTable

    Dim _RowIndex As Integer

    Public Property Codemeson As String
        Get
            Return _Codmeson
        End Get
        Set(value As String)
            _Codmeson = value
        End Set
    End Property

    Public Property Numot As String
        Get
            Return _Numot
        End Get
        Set(value As String)
            _Numot = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Mesones, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Operarios_Meson, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos_En_Meson, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos_En_Meson_Detalle_X_Fila, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Maquinas_Meson, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Bar2.BackColor = Color.FromArgb(44, 44, 44)
        End If

    End Sub

    Private Sub Frm_Meson_Gestion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'AddHandler Grilla_Mesones.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Operarios_Meson.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Productos_En_Meson.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Maquinas_Meson.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Rdb_Ver_SubOT.CheckedChanged, AddressOf Rdb_Ver_SubOT_CheckedChanged
        AddHandler Rdb_Ver_CantProd.CheckedChanged, AddressOf Rdb_Ver_SubOT_CheckedChanged

        Sb_Actualizar_Grillas(_codmeson)
        Tiempo_Actualizacion.Interval = 1000 * 60

    End Sub

    Sub Sb_Actualizar_Grillas(_Codmeson As String)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where Idpotpr Not IN (Select IDPOTPR From POTPR)" & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpotpr Not IN (Select IDPOTPR From POTPR)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select *,Replace(Nommeson,'MESON ','') As NombreMeson,
                        (Select Count(*) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2
                            Inner Join POTE On IDPOTE = Idpote
                                Where Z1.Codmeson = Z2.Codmeson And Z2.Estado In ('PD','MQ','TE') And ESTADO = 'V') As Productos,
                        (Select Count(*) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2
                            Inner Join POTE On IDPOTE = Idpote
                                Where Z1.Codmeson = Z2.Codmeson And Z2.Estado In ('PD','TE') And ESTADO = 'V') As ProductosMeson,
                        (Select Count(*) From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z2
                            Inner Join POTE On IDPOTE = Idpote
                                Where Z1.Codmeson = Z2.Codmeson And Z2.Estado = 'EMQ' And ESTADO = 'V') As ProductosMq,
                        (Select Isnull(Sum(Fabricar),0) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2
                            Inner Join POTE On IDPOTE = Idpote
                                Where Z1.Codmeson = Z2.Codmeson And Z2.Estado In ('PD','MQ','TE') And ESTADO = 'V') As CantProductos,
                        (Select Isnull(Sum(Fabricar),0) From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Z2
                            Inner Join POTE On IDPOTE = Idpote
                                Where Z1.Codmeson = Z2.Codmeson And Z2.Estado In ('PD') And ESTADO = 'V') As CantProductosMeson,
                        (Select Isnull(Sum(Fabricar),0) From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z2
                            Inner Join POTE On IDPOTE = Idpote
                                Where Z1.Codmeson = Z2.Codmeson And Z2.Estado = 'EMQ' And ESTADO = 'V') As CantProductosMq
                        From " & _Global_BaseBk & "Zw_Pdc_Mesones Z1 Where Activo = 1
                        Order By Nommeson"

        _Tbl_Mesones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Mesones

            .DataSource = _Tbl_Mesones

            OcultarEncabezadoGrilla(Grilla_Mesones)

            Dim _Cant = "Cant"
            Dim _ToolCant = "productos"
            Dim _CmpCant = "Pr"

            If Rdb_Ver_SubOT.Checked Then
                _Cant = String.Empty
                _ToolCant = "sub OT"
                _CmpCant = "SO"
            End If

            Dim _DisplayIndex = 0

            .Columns("Codmeson").Visible = True
            .Columns("Codmeson").HeaderText = "Cód."
            .Columns("Codmeson").Width = 65
            .Columns("Codmeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreMeson").Visible = True
            .Columns("NombreMeson").HeaderText = "Nombre mesón"
            .Columns("NombreMeson").Width = 210
            .Columns("NombreMeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns(_Cant & "Productos").Visible = True
            .Columns(_Cant & "Productos").HeaderText = "Tot." & _CmpCant
            .Columns(_Cant & "Productos").ToolTipText = "Total de productos asignados al mesón"
            .Columns(_Cant & "Productos").Width = 50
            .Columns(_Cant & "Productos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Cant & "Productos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns(_Cant & "ProductosMeson").Visible = True
            .Columns(_Cant & "ProductosMeson").HeaderText = _CmpCant & ".Esp"
            .Columns(_Cant & "ProductosMeson").ToolTipText = "Productos a la esperaen el mesón"
            .Columns(_Cant & "ProductosMeson").Width = 50
            .Columns(_Cant & "ProductosMeson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Cant & "ProductosMeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns(_Cant & "ProductosMq").Visible = True
            .Columns(_Cant & "ProductosMq").HeaderText = _CmpCant & ".Maq."
            .Columns(_Cant & "ProductosMq").ToolTipText = "Productos en las maquinas del mesón"
            .Columns(_Cant & "ProductosMq").Width = 50
            .Columns(_Cant & "ProductosMq").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Cant & "ProductosMq").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        If Not String.IsNullOrEmpty(_Codmeson) Then
            BuscarDatoEnGrilla(_Codmeson.ToString.Trim, "Codmeson", Grilla_Mesones)
        End If

    End Sub

    Sub Sb_Actualizar_Grillas_Operarios_En_Meson(_Codmeson As String)

        Consulta_sql = "Select Codigoob,Nombreob,Codmeson,Fecha_Hora_Asig As Fecha, Fecha_Hora_Asig As Hora" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario" & vbCrLf &
                       "Where Codmeson = '" & _Codmeson & "' And Codigoob In (Select CODIGOOB From PMAEOB Where INACTIVO = 0)"

        _Tbl_Oper_Meson = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Operarios_Meson

            .DataSource = _Tbl_Oper_Meson

            OcultarEncabezadoGrilla(Grilla_Operarios_Meson)

            .Columns("Codigoob").Visible = True
            .Columns("Codigoob").HeaderText = "Código"
            .Columns("Codigoob").Width = 100
            .Columns("Codigoob").DisplayIndex = 0

            .Columns("Nombreob").Visible = True
            .Columns("Nombreob").HeaderText = "Nombre operario"
            .Columns("Nombreob").Width = 285
            .Columns("Nombreob").DisplayIndex = 1

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Productos_En_Meson(_Codmeson As String)

        Consulta_sql = "Select Tbl.*,Fecha_Asignacion As Fecha,Fecha_Asignacion As Hora,POTE.FIOT,POTE.ESTADO," &
                       "Case Tbl.Reproceso When 1 Then Rtrim(Ltrim(POTE.REFERENCIA)) + ' (Reproceso...)' Else POTE.REFERENCIA End As Referencia_OT," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, POTE.FIOT, GETDATE()) / 60) / 24)) As Dias_OT," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Asignacion, GETDATE()) / 60) / 24)) As Dias_En_Meson," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Asignacion, GETDATE()) / 60)%24)) As Horas_En_Meson," &
                       "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Asignacion, GETDATE())%60) As Minutos_En_Meson," &
                       "Cast('' As Varchar) As Tiempo_En_Meson,Isnull(Pd.Grado,0) AS Grado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Tbl" & vbCrLf &
                       "Inner Join POTE ON POTE.IDPOTE = Tbl.Idpote" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Pdp_OT_Prioridad Pd ON Pd.Idpote=IDPOTE" & vbCrLf &
                       "WHERE Tbl.Codmeson='" & _Codmeson & "' AND Tbl.Estado In ('PD','TE') And POTE.ESTADO In ('V','S') ORDER BY Orden_Meson" &
                       vbCrLf & vbCrLf &
                       "Select Tbl.*,Fecha_Asignacion As Fecha,Fecha_Asignacion As Hora,POTE.FIOT,POTE.ESTADO,POTE.REFERENCIA As Referencia_OT," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, POTE.FIOT, GETDATE()) / 60) / 24)) As Dias_OT," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Asignacion, GETDATE()) / 60) / 24)) As Dias_En_Meson," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Asignacion, GETDATE()) / 60)%24)) As Horas_En_Meson," &
                       "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Asignacion, GETDATE())%60) As Minutos_En_Meson," &
                       "Cast('' As Varchar) As Tiempo_En_Meson" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Tbl" & vbCrLf &
                       "INNER JOIN POTE ON POTE.IDPOTE = Tbl.Idpote" & vbCrLf &
                       "WHERE Tbl.Codmeson='" & _Codmeson & "' AND Tbl.Estado In ('PD','TE') And POTE.ESTADO In ('V','S') ORDER BY Orden_Meson -- ('PD','TE','PT')"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds.Relations.Add("Rel_IdMeson_x_IdMeson",
                         _Ds.Tables("Table").Columns("IdMeson"),
                         _Ds.Tables("Table1").Columns("IdMeson"), False)

        Grilla_Productos_En_Meson.DataSource = _Ds
        Grilla_Productos_En_Meson.DataMember = "Table"

        Grilla_Productos_En_Meson_Detalle_X_Fila.DataSource = _Ds
        Grilla_Productos_En_Meson_Detalle_X_Fila.DataMember = "Table.Rel_IdMeson_x_IdMeson"


        With Grilla_Productos_En_Meson

            OcultarEncabezadoGrilla(Grilla_Productos_En_Meson, True)

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").Width = 80
            .Columns("Numot").DisplayIndex = 0

            .Columns("Nreg").Visible = True
            .Columns("Nreg").HeaderText = "Sub-OT"
            .Columns("Nreg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nreg").Width = 60
            .Columns("Nreg").DisplayIndex = 1

            .Columns("Referencia_OT").Visible = True
            .Columns("Referencia_OT").HeaderText = "Referencia OT"
            .Columns("Referencia_OT").Width = 330
            .Columns("Referencia_OT").DisplayIndex = 2

            .Columns("FIOT").Visible = True
            .Columns("FIOT").HeaderText = "Fecha OT"
            .Columns("FIOT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FIOT").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FIOT").Width = 70
            .Columns("FIOT").DisplayIndex = 3

            .Columns("Dias_OT").Visible = True
            .Columns("Dias_OT").HeaderText = "Días OT"
            .Columns("Dias_OT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias_OT").Width = 50
            .Columns("Dias_OT").DisplayIndex = 4

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha Asig"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 70
            .Columns("Fecha").DisplayIndex = 5

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora Asig"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 50
            .Columns("Hora").DisplayIndex = 6

            .Columns("Tiempo_En_Meson").Visible = True
            .Columns("Tiempo_En_Meson").HeaderText = "Tiempo en Mesón"
            .Columns("Tiempo_En_Meson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tiempo_En_Meson").Width = 90
            .Columns("Tiempo_En_Meson").DisplayIndex = 7

        End With

        For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows

            Dim _Grado = _Fila.Cells("Grado").Value
            Dim _Estado = _Fila.Cells("Estado").Value
            Dim _Reproceso = _Fila.Cells("Reproceso").Value

            Dim _Estado_Pote = _Fila.Cells("ESTADO").Value

            If _Estado_Pote = "S" Then
                _Fila.DefaultCellStyle.BackColor = Color.Gray
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

            If _Estado = "MQ" Then
                _Fila.DefaultCellStyle.ForeColor = Color.LightGray
            End If

            If _Grado = 1 Then
                _Fila.DefaultCellStyle.BackColor = Color.Red 'LightCoral
                _Fila.DefaultCellStyle.ForeColor = Color.White
            ElseIf _Grado = 2 Then
                _Fila.DefaultCellStyle.BackColor = Color.Yellow 'LightYellow
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

            If _Reproceso Then
                _Fila.DefaultCellStyle.BackColor = Color.Green
                _Fila.DefaultCellStyle.ForeColor = Color.White
            End If

        Next

        With Grilla_Productos_En_Meson_Detalle_X_Fila

            OcultarEncabezadoGrilla(Grilla_Productos_En_Meson_Detalle_X_Fila, True)

            .Columns("Nreg").Visible = True
            .Columns("Nreg").HeaderText = "Sub-OT"
            .Columns("Nreg").Width = 60
            .Columns("Nreg").DisplayIndex = 0

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = 1

            .Columns("Glosa").Visible = True
            .Columns("Glosa").HeaderText = "Descripción"
            .Columns("Glosa").Width = 300
            .Columns("Glosa").DisplayIndex = 2

            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").HeaderText = "Fabricar"
            .Columns("Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricar").Width = 60
            .Columns("Fabricar").DisplayIndex = 3

            .Columns("Fabricado").Visible = True
            .Columns("Fabricado").HeaderText = "Fabricado"
            .Columns("Fabricado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricado").Width = 60
            .Columns("Fabricado").DisplayIndex = 4

            .Columns("Porc_Fabricacion").Visible = True
            .Columns("Porc_Fabricacion").HeaderText = "%"
            .Columns("Porc_Fabricacion").DefaultCellStyle.Format = "% ##.##"
            .Columns("Porc_Fabricacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Fabricacion").Width = 40
            .Columns("Porc_Fabricacion").DisplayIndex = 5

            .Columns("Saldo_Fabricar").Visible = True
            .Columns("Saldo_Fabricar").HeaderText = "Saldo Fabricar"
            .Columns("Saldo_Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo_Fabricar").Width = 90
            .Columns("Saldo_Fabricar").DisplayIndex = 6

            .Columns("Porc_Avance_Saldo_Fab").Visible = True
            .Columns("Porc_Avance_Saldo_Fab").HeaderText = "% Avance"
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Format = "% ##.##"
            .Columns("Porc_Avance_Saldo_Fab").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Avance_Saldo_Fab").Width = 90
            .Columns("Porc_Avance_Saldo_Fab").DisplayIndex = 7

        End With

        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Productos_En_Meson, "Fecha_Asignacion", "Tiempo_En_Meson")

        If Not String.IsNullOrEmpty(_Numot) Then
            BuscarDatoEnGrilla(_Numot, "Numot", Grilla_Productos_En_Meson)
        End If

    End Sub

    Sub Sb_Actualizar_Grilla_Maquinas(_Codmeson As String)

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Mq.*,POTL.NREG As Nreg,POTE.ESTADO,(Select Top 1 NOMBREMAQ From PMAQUI where CODMAQ = CodMaq) As Nombremaq," &
                       "(Select Top 1 NOMBREOP From POPER where Operacion = OPERACION) As Nombreop," &
                       "Fecha_Hora_Inicio as Fecha, Fecha_Hora_Inicio as Hora," & vbCrLf &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60) / 24)) As Dias_En_Maquina," &
                       "Convert(VARCHAR(200), ((DateDiff(Minute, Fecha_Hora_Inicio, GETDATE()) / 60)%24)) As Horas_En_Maquina," &
                       "Convert(VARCHAR(200), DateDiff(Minute, Fecha_Hora_Inicio, GETDATE())%60) As Minutos_En_Maquina," &
                       "Cast('' As Varchar) As Tiempo_En_Maquina" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Mq
                        Inner Join POTE On POTE.IDPOTE = Mq.Idpote
                        Left Join POTL On POTL.IDPOTL = Mq.Idpotl
                        WHERE Codmeson='" & _Codmeson & "' AND Estado='EMQ' ORDER BY Fecha_Hora_Inicio ASC"

        _Tbl_Prod_Maquinas = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Maquinas_Meson

            .DataSource = _Tbl_Prod_Maquinas

            OcultarEncabezadoGrilla(Grilla_Maquinas_Meson, True)

            Dim _DisplayIndex = 0

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").Width = 40
            .Columns("Numot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nreg").Visible = True
            .Columns("Nreg").HeaderText = "Sub"
            .Columns("Nreg").Width = 40
            .Columns("Nreg").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodMaq").Visible = True
            .Columns("CodMaq").HeaderText = "CodMaq"
            .Columns("CodMaq").Width = 75
            .Columns("CodMaq").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombremaq").Visible = True
            .Columns("Nombremaq").HeaderText = "Maquina"
            .Columns("Nombremaq").Width = 150
            .Columns("Nombremaq").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Codigo"
            .Columns("Codigo").Width = 95
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 210
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 65
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").HeaderText = "Fab."
            .Columns("Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricar").Width = 40
            .Columns("Fabricar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tiempo_En_Maquina").Visible = True
            .Columns("Tiempo_En_Maquina").HeaderText = "Tiempo en Maquina"
            .Columns("Tiempo_En_Maquina").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tiempo_En_Maquina").Width = 80
            .Columns("Tiempo_En_Maquina").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Maquinas_Meson, "Fecha_Hora_Inicio", "Tiempo_En_Maquina")

    End Sub

    Sub Sb_Tiempo_En_Mesones_y_Maquinas(Grilla As DataGridView, _Campo_Fecha As String, _Campo_Tiempo As String)

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Fecha_Hora_Inicio = _Row.Cells(_Campo_Fecha).Value

            Dim _Estado_Pote = _Row.Cells("ESTADO").Value

            If _Estado_Pote = "S" Then

                _Row.Cells(_Campo_Tiempo).Value = "EN PAUSA..."

            Else

                Dim ts As TimeSpan = DateTime.Now.Subtract(_Fecha_Hora_Inicio)

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

    Private Sub Grilla_Mesones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Mesones.CellEnter

        Dim _Fila As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)

        Dim _Codmeson As String = _Fila.Cells("Codmeson").Value
        Dim _Productos As Integer = _Fila.Cells("Productos").Value

        Btn_Reordenar_Meson.Enabled = CBool(_Productos)

        Sb_Actualizar_Grilla_Productos_En_Meson(_Codmeson)
        Sb_Actualizar_Grilla_Maquinas(_Codmeson)
        Sb_Actualizar_Grillas_Operarios_En_Meson(_Codmeson)

    End Sub

    Private Sub Btn_Reordenar_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Reordenar_Meson.Click

        Dim _FilaMeson As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)
        Dim _Codmeson As String = _FilaMeson.Cells("Codmeson").Value
        Dim _Actualizado As Boolean

        Dim Fm As New Frm_Meson_Reordenar_Productos(_Codmeson)
        Fm.ShowDialog(Me)
        _Actualizado = Fm.Pro_Actualizado
        Fm.Dispose()

        If _Actualizado Then
            Sb_Actualizar_Grilla_Productos_En_Meson(_Codmeson)
            Sb_Actualizar_Grilla_Maquinas(_Codmeson)
            Sb_Actualizar_Grillas_Operarios_En_Meson(_Codmeson)
        End If

    End Sub

    Private Sub Grilla_Operarios_Meson_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Operarios_Meson.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Operarios_Meson.Rows(Grilla_Operarios_Meson.CurrentRow.Index)
        Dim _Fila_Meson As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)

        Dim _Codigoob As String = _Fila.Cells("Codigoob").Value
        Dim _Codmeson As String = _Fila.Cells("Codmeson").Value

        Dim Fm1 As New Frm_Meson_Operario(_Codigoob, False)
        Fm1.Cmb_Mesones.SelectedValue = _Codmeson
        Fm1.ShowDialog(Me)
        Fm1.Dispose()

        Sb_Actualizar_Grillas(_Codmeson)

    End Sub

    Private Sub Tiempo_Actualizacion_Tick(sender As Object, e As EventArgs) Handles Tiempo_Actualizacion.Tick
        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Productos_En_Meson, "Fecha_Asignacion", "Tiempo_En_Meson")
        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla_Maquinas_Meson, "Fecha_Hora_Inicio", "Tiempo_En_Maquina")
    End Sub

    Private Sub Btn_Cambiar_Productos_Otro_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Productos_Otro_Meson.Click

        Dim _FilaMeson As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)
        Dim _Codmeson As String = _FilaMeson.Cells("Codmeson").Value
        Dim _Actualizado As Boolean

        Dim Fm As New Frm_Meson_Operario_Cambio_Mesones(_Codmeson)
        If Not IsNothing(Fm.Pro_Row_Meson_Der) Then
            Fm.ShowDialog(Me)
            _Actualizado = Fm.Pro_Actualizado
        Else
            MessageBoxEx.Show(Me, "Este mesón no tiene mesones equivalentes", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Fm.Dispose()

        If _Actualizado Then
            Sb_Actualizar_Grillas(_Codmeson)
        End If

    End Sub

    Private Sub Btn_Cambiar_Productos_Meson_Anterior_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Productos_Meson_Anterior.Click

        Dim _FilaMeson As DataGridViewRow = Grilla_Productos_En_Meson.Rows(Grilla_Productos_En_Meson.CurrentRow.Index)
        Dim _Codmeson As String = _FilaMeson.Cells("Codmeson").Value

        Dim _Idpotpr = _FilaMeson.Cells("Idpotpr").Value
        Dim _Idpotl = _FilaMeson.Cells("Idpotl").Value
        Dim _Operacion_Origen = _FilaMeson.Cells("Operacion")

        Dim _Orden_Potpr = _Sql.Fx_Trae_Dato("POTPR", "ORDEN", "IDPOTPR = " & _Idpotpr) '_FilaMeson.Cells("Orden_Potpr").Value

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Orden_Potpr = " & _Orden_Potpr & vbCrLf &
                       "Where Idpotpr = " & _Idpotpr
        _Sql.Ej_consulta_IDU(Consulta_sql)

        _FilaMeson.Cells("Orden_Potpr").Value = _Orden_Potpr

        Dim _Actualizado As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'"
        Dim _Row_Meson_Der As DataRow
        Dim _Row_Meson_Izq As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Operacion_Equivalente = Trim(_Row_Meson_Izq.Item("Operacion_Equivalente"))

        Consulta_sql = "Select * From POTPR Where IDPOTL = " & _Idpotl & " And ORDEN < " & _Orden_Potpr & "
                        And OPERACION <> '" & _Operacion_Equivalente & "' 
                        Order by ORDEN Desc"
        Dim _Tbl_Potpr As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _New_Idpotpr As Integer

        For Each _Fila_Potpr As DataRow In _Tbl_Potpr.Rows
            Dim _Oper = _Fila_Potpr.Item("OPERACION")
            If _Oper <> _Operacion_Equivalente Then
                _New_Idpotpr = _Fila_Potpr.Item("IDPOTPR")
                _Row_Meson_Der = _Fila_Potpr
                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdc_Mesones 
                                Where Operacion = '" & _Oper & "'"
                _Row_Meson_Der = _Sql.Fx_Get_DataRow(Consulta_sql)
                _Row_Meson_Izq.Item("Operacion_Equivalente") = _Oper
                Exit For
            End If
        Next

        Dim Fm As New Frm_Meson_Operario_Cambio_Mesones(_Codmeson)
        Fm.Pro_Condicion_Adicional_Meson_Izquierda = "And Idpotpr = " & _Idpotpr
        Fm.Btn_Cambiar_de_Derecha_a_izquierda.Enabled = False
        Fm.Pro_Row_Meson_Der = _Row_Meson_Der
        Fm.Pro_Row_Meson_Izq = _Row_Meson_Izq
        Fm.ShowDialog(Me)
        _Actualizado = Fm.Pro_Actualizado

        Fm.Dispose()

        If _Actualizado Then
            Sb_Actualizar_Grillas(_Codmeson)
        End If
    End Sub

    Private Sub Rdb_Ver_SubOT_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grillas(_Codmeson)
    End Sub
End Class
