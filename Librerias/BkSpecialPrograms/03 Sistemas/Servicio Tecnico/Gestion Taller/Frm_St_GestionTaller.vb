Public Class Frm_St_GestionTaller

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_OT As DataTable
    Dim _CodFuncionario_Activo As String
    Dim _Row_Funcionario As DataRow
    Dim _DsDocumento As DataSet


    Public Sub New(_CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _CodFuncionario_Activo = _CodFuncionario

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller Where CodFuncionario = '" & _CodFuncionario_Activo & "'"
        _Row_Funcionario = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Lbl_Sesion.Text = "Sesion: " & _CodFuncionario_Activo & " - " & _Row_Funcionario.Item("NomFuncionario").ToString.Trim

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        'Sb_Color_Botones_Barra(bar)

    End Sub

    Private Sub Frm_St_Presupuestos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        'A  - ASIGNADO
        'C  - COTIZACION
        'CE - CERRADO 
        'E  - ENTREGADO
        'F  - FACTURADO / GDI
        'I  - INGRESADO
        'N  - NULA
        'P  - PRESUPUESTO 
        'R	- REPARACION Y CIERRE
        'V(AVISO)

        'Dim Fm_Espera As New Frm_Form_Esperar
        'Fm_Espera.BarraCircular.IsRunning = True
        'Fm_Espera.Show()

        Dim _Fecha As Date = FechaDelServidor()

        Dim Dia_1 As String = numero_(_Fecha.Day, 2)
        Dim Mes_1 As String = numero_(_Fecha.Month, 2)
        Dim Ano_1 As String = _Fecha.Year

        Dim _Filtro_Fecha = "Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                            "And CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)" & vbCrLf

        Select Case Super_TabS.SelectedTabIndex

            Case 0 ' Asignadas tecnico
                GroupPanel1.Text = "Ordenes de trabajo asignadas a algún técnico, a la espera de una evaluación."
                _Condicion = "And CodEstado In ('A')" & vbCrLf
            Case 1 ' En Reparacion
                GroupPanel1.Text = "Ordenes de trabajo en reparación"
                _Condicion = "And CodEstado In ('R')" & vbCrLf

        End Select

        _Condicion += "And Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "'" & vbCrLf

        Consulta_Sql = My.Resources.Recursos_Locales.SqlQuery_Lista_OT
        Consulta_Sql = Replace(Consulta_Sql, "#Db_BakApp#", _Global_BaseBk)
        Consulta_Sql = Replace(Consulta_Sql, "#Condicion#", _Condicion)

        _Tbl_OT = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Sb_Marcar_Grilla()

        Timer_Cerrar_Sesion.Stop()
        Timer_Cerrar_Sesion.Interval = 60 * 1000
        Timer_Cerrar_Sesion.Start()

    End Sub

    Sub Sb_Marcar_Grilla()

        With Grilla

            .DataSource = _Tbl_OT

            Dim _Mas = 0

            If Super_TabS.SelectedTabIndex <> 0 Then
                _Mas = 120
            End If

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Nro_Ot").Visible = True
            .Columns("Nro_Ot").HeaderText = "Número OT"
            .Columns("Nro_Ot").Width = 80
            .Columns("Nro_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sub_Ot").Visible = True
            .Columns("Sub_Ot").HeaderText = "Sub OT"
            .Columns("Sub_Ot").Width = 30
            .Columns("Sub_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rut").Visible = True
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Width = 80
            .Columns("Rut").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cliente").Visible = True
            .Columns("Cliente").HeaderText = "Cliente"
            .Columns("Cliente").Width = 300
            .Columns("Cliente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Lugar").Visible = True
            .Columns("Lugar").HeaderText = "lugar"
            .Columns("Lugar").Width = 50
            .Columns("Lugar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 70
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").Width = 50
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Dias").Visible = True
            .Columns("Dias").HeaderText = "Dias"
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias").DefaultCellStyle.Format = "###,##"
            .Columns("Dias").Width = 40
            .Columns("Dias").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = (Super_TabS.SelectedTabIndex = 0)
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 120
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Producto"
            .Columns("Producto").Width = 250 + _Mas - 30
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        If CBool(Grilla.RowCount) Then
            Grilla.FirstDisplayedScrollingRowIndex = Grilla.RowCount - 1
            Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells("Nro_Ot")
        End If

        Me.Refresh()

    End Sub

    Private Sub Tab_03_Asignadas_Click(sender As Object, e As EventArgs) Handles Tab_03_Asignadas.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Tab_04_Presupuesto_Click(sender As Object, e As EventArgs) Handles Tab_04_Presupuesto.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Timer_Cerrar_Sesion.Stop()

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id_Ot As Integer = _Fila.Cells("Id_Ot").Value

        Consulta_Sql = My.Resources.Recursos_Locales.SqlQuery_Traer_OT
        Consulta_Sql = Replace(Consulta_Sql, "#Id_Ot#", _Id_Ot)
        Consulta_Sql = Replace(Consulta_Sql, "#Db_BakApp#", _Global_BaseBk)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _DsDocumento As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)


        Dim _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
        Dim _Tbl_DetProd = _DsDocumento.Tables(1)
        Dim _Tbl_ChekIn = _DsDocumento.Tables(2)
        Dim _Row_Notas = _DsDocumento.Tables(3).Rows(0)
        Dim _Tbl_Estado = _DsDocumento.Tables(4)
        Dim _Tbl_Accesorios = _DsDocumento.Tables(5)

        Dim _CodEntidad = _Row_Encabezado.Item("CodEntidad")
        Dim _SucEntidad = _Row_Encabezado.Item("SucEntidad")

        Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)


        Select Case Super_TabS.SelectedTabIndex

            Case 0 ' Asignadas tecnico

                Dim Fm0 As New Frm_St_Estado_03_Presupuesto2(_Id_Ot, Frm_St_Estado_03_Presupuesto.Accion.Nuevo)
                Fm0.Pro_DsDocumento = _DsDocumento
                Fm0.CodTecnico_Presupuesta = _CodFuncionario_Activo
                Fm0.ShowDialog(Me)
                If Fm0.Pro_Grabar Then
                    Sb_Actualizar_Grilla()
                End If
                Fm0.Dispose()

            Case 1 ' En Reparacion

                Dim Fm1 As New Frm_St_Estado_05_Reparacion(Frm_St_Estado_05_Reparacion.Accion.Nuevo)
                Fm1.Pro_RowEntidad = _RowEntidad
                Fm1.Pro_Id_Ot = _Id_Ot
                Fm1.Pro_DsDocumento = _DsDocumento
                Fm1.CodTecnico_Repara = _CodFuncionario_Activo
                Fm1.ShowDialog(Me)
                If Fm1.Pro_Fijar_Estado Then
                    Sb_Actualizar_Grilla()
                End If
                Fm1.Dispose()

        End Select


        Timer_Cerrar_Sesion.Interval = 60 * 2000
        Timer_Cerrar_Sesion.Start()

    End Sub

    Private Sub Timer_Cerrar_Sesion_Tick(sender As Object, e As EventArgs) Handles Timer_Cerrar_Sesion.Tick
        Me.Close()
    End Sub

End Class
