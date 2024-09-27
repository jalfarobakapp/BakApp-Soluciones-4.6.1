'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Masivos_Detalle

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Fecha_Inicio As Date
    Dim _Fecha_Fin As Date

    Dim _Filtro_Adicional As String

    Dim _Ds_Informe As DataSet
    Dim _TblInforme As DataTable

    Dim _Total_a_Pagar As Double
    Dim _Reprocesar_Informe As Boolean

    Dim _Row_Pago_Autorizado As DataRow

    Enum Enum_Tipo_Pago
        Clientes
        Proveedores
    End Enum

    Dim _Tipo_Pago As Enum_Tipo_Pago

    Dim _Id_Correo As Integer

    Public Property Pro_Mostrar_Solo_Por_Pagar() As Boolean
        Get
            Return Chk_Mostrar_Solo_Por_Pagar.Checked
        End Get
        Set(ByVal value As Boolean)
            Chk_Mostrar_Solo_Por_Pagar.Checked = value
        End Set
    End Property
    Public Property Pro_Row_Pago_Autorizado() As DataRow
        Get
            Return _Row_Pago_Autorizado
        End Get
        Set(ByVal value As DataRow)
            _Row_Pago_Autorizado = value
        End Set
    End Property
    Public ReadOnly Property Pro_Reprocesar_Informe() As Boolean
        Get
            Return _Reprocesar_Informe
        End Get
    End Property
    Public Property Pro_Filtro_Adicional() As String
        Get
            Return _Filtro_Adicional
        End Get
        Set(ByVal value As String)
            _Filtro_Adicional = value
        End Set
    End Property

    Public Sub New(ByVal Tipo_Pago As Enum_Tipo_Pago,
                   ByVal Fecha_Inicio As Date,
                   ByVal Fecha_Fin As Date, ByVal Id_Correo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Tipo_Pago = Tipo_Pago
        _Fecha_Inicio = Fecha_Inicio
        _Fecha_Fin = Fecha_Fin

        _Id_Correo = Id_Correo

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Encabezado, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Pagos_Masivo_Entidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        AddHandler Grilla.CellBeginEdit, AddressOf Sb_Grilla_CellBeginEdit
        AddHandler Grilla.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick

        AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
        AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Sb_Grilla_ColumnHeaderMouseClick

        AddHandler Chk_Marcar_todo.CheckedChanged, AddressOf Sb_Chk_Marcar_todo_CheckedChanged
        AddHandler Chk_Mostrar_Solo_Por_Pagar.CheckedChanged, AddressOf Sb_Actualizar_Grilla

        Sb_Actualizar_Grilla()

        Btn_Pagar_Con_Efectivo.Enabled = False

    End Sub

    Sub Sb_Actualizar_Grilla()

        If _Tipo_Pago = Enum_Tipo_Pago.Proveedores Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        ElseIf _Tipo_Pago = Enum_Tipo_Pago.Clientes Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf
        End If


        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", Format(_Fecha_Fin, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional", _Filtro_Adicional)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)

        If Not Chk_Mostrar_Solo_Por_Pagar.Checked Then
            Consulta_sql = Replace(Consulta_sql, "AND VEN.ESPGVE <> 'C'", "")
        End If

        Consulta_sql += vbCrLf & vbCrLf & "Delete #INFVEN Where Deuda = 'Pagos'" & vbCrLf & vbCrLf

        Dim _Sql_Actualiza_Chk = "Update #INFVEN Set Chk = Isnull((Select Autorizado" & Space(1) &
                                 "From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where IDMAEVEN = Idmaeven),0) Where SALDO > 0" & vbCrLf

        'CAST(Isnull((Select Autorizado From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where IDMAEVEN = Idmaeven),0) AS bit) AS Chk,

        Consulta_sql += _Sql_Actualiza_Chk & vbCrLf &
                        "SELECT *" & vbCrLf &
                        "From #INFVEN" & vbCrLf &
                        "Order By RTEN,FEVE,FEEMDO" & vbCrLf &
                        "Select IDMAEVEN,ENDO,SUENDO,RTEN,NOKOEN," &
                        "Cast('" & Format(_Fecha_Inicio, "yyyyMMdd") & "' As Date) As FECHA_INICIO," &
                        "Cast('" & Format(_Fecha_Inicio, "yyyyMMdd") & "' As Date) As FECHA_HASTA" & vbCrLf &
                        "From #INFVEN" & vbCrLf &
                        "Drop Table #INFVEN"

        _Ds_Informe = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Informe.Relations.Add("Rel_Proveedor",
                                  _Ds_Informe.Tables("Table").Columns("IDMAEVEN"),
                                  _Ds_Informe.Tables("Table1").Columns("IDMAEVEN"), False)


        Grilla.DataSource = _Ds_Informe
        Grilla.DataMember = "Table"

        Grilla_Encabezado.DataSource = _Ds_Informe
        Grilla_Encabezado.DataMember = "Table.Rel_Proveedor"

        _TblInforme = _Ds_Informe.Tables(0)

        Lbl_Total_Saldos.Text = FormatCurrency(_Total_a_Pagar, 0)

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _Menos = 10

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Visible = True
            .Columns("Chk").DisplayIndex = 0
            .Columns("Chk").ReadOnly = False

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = 1
            .Columns("ENDO").ReadOnly = True

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "Tipo"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 2
            .Columns("TIDO").ReadOnly = True

            .Columns("Tipo").Width = 200
            .Columns("Tipo").HeaderText = "Tipo Doc."
            .Columns("Tipo").Visible = True
            .Columns("Tipo").DisplayIndex = 3
            .Columns("Tipo").ReadOnly = True

            .Columns("NUDO").Width = 70
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 4
            .Columns("NUDO").ReadOnly = True

            .Columns("FEVE").Width = 80
            .Columns("FEVE").HeaderText = "Vencimiento"
            .Columns("FEVE").Visible = True
            .Columns("FEVE").DisplayIndex = 6
            .Columns("FEVE").ReadOnly = True

            .Columns("VAVE").HeaderText = "Vencimiento" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAVE").Width = 80
            .Columns("VAVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAVE").Visible = True
            .Columns("VAVE").DisplayIndex = 11
            .Columns("VAVE").ReadOnly = True

            .Columns("VAABVE").HeaderText = "Abonado" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAABVE").Width = 80
            .Columns("VAABVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAABVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABVE").Visible = True
            .Columns("VAABVE").DisplayIndex = 11
            .Columns("VAABVE").ReadOnly = True

            .Columns("SALDO").HeaderText = "Saldo" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("SALDO").Width = 80
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DisplayIndex = 11
            .Columns("SALDO").ReadOnly = True

        End With

        With Grilla_Encabezado

            OcultarEncabezadoGrilla(Grilla_Encabezado, True)

            .Columns("RTEN").HeaderText = "Entidad"
            .Columns("RTEN").Width = 80
            .Columns("RTEN").Visible = True

            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Width = 300
            .Columns("NOKOEN").Visible = True

            .Columns("FECHA_INICIO").HeaderText = "Fecha Desde"
            .Columns("FECHA_INICIO").Width = 100
            .Columns("FECHA_INICIO").Visible = True

            .Columns("FECHA_HASTA").HeaderText = "Fecha Hasta"
            .Columns("FECHA_HASTA").Width = 100
            .Columns("FECHA_HASTA").Visible = True

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Tido = _Fila.Cells("TIDO").Value
            Dim _Dias_Atraso As Integer = _Fila.Cells("DIAS_ATRASO").Value
            Dim _Saldo As Double = _Fila.Cells("SALDO").Value

            Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value

            If _Idmaeven = 0 Then
                _Fila.DefaultCellStyle.BackColor = Color.Pink
            End If

            If _Tido = "NCV" Or _Tido = "NCC" Then
                _Fila.DefaultCellStyle.BackColor = Color.Yellow
            End If

            Dim _Color As Color

            If _Dias_Atraso < 0 Then
                _Color = Color.Red
            ElseIf _Dias_Atraso = 0 Then
                _Color = Color.Blue
            ElseIf _Dias_Atraso > 0 Then
                _Color = Color.Green
            End If

            _Fila.Cells("DIAS_ATRASO").Style.ForeColor = _Color
            If _Saldo = 0 Then
                _Fila.DefaultCellStyle.BackColor = Color.Khaki
            End If

        Next

        Call Sb_Grilla_CellEndEdit(Nothing, Nothing)

    End Sub

    Private Sub Sb_Grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        _Total_a_Pagar = 0

        For Each _Fila As DataRow In _TblInforme.Rows
            If _Fila.Item("Chk") Then
                _Total_a_Pagar += _Fila.Item("SALDO")
            End If
        Next

        Lbl_Total_Saldos.Text = FormatCurrency(_Total_a_Pagar, 0)
    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        ShowContextMenu(Menu_Contextual_01_Opciones_Documento) 'Sb_Ver_Documento()
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

    Private Sub Sb_Grilla_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        ' Sb_Formato_Grilla()
    End Sub

    Private Sub Sb_Grilla_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Grilla.EndEdit()
    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    Dim _Saldo = _Fila.Cells("SALDO").Value
                    Btn_Quitar_Permiso.Visible = CBool(_Saldo)

                    ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Ver_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_documento.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value

        If CBool(_Idmaeven) Then
            Sb_Ver_Documento()
        Else

            Dim _Idmaedpce = _Fila.Cells("IDMAEEDO").Value

            Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Sub Sb_Ver_Documento()

        Dim _Mostrar_leyenda

        'If _Reprocesar_Informe Then
        '_Mostrar_leyenda = False
        'Else
        _Mostrar_leyenda = True
        'End If

        Dim _Cambio As Boolean

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value
        Dim _Feve = _Fila.Cells("FEVE").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Consulta_sql = "Select top 1 * From MAEVEN Where IDMAEVEN = " & _Idmaeven

        Dim _TblMaeven As DataTable = _SQL.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblMaeven.Rows.Count) Then

            Dim _Fecha_vencimiento = _TblMaeven.Rows(0).Item("FEVE")

            If _Fecha_vencimiento <> _Feve Then
                _Cambio = True
            End If

        Else

            _Cambio = True

        End If

        If _Cambio Then

            _Fila.DefaultCellStyle.BackColor = Color.Gray

            If _Mostrar_leyenda Then
                MessageBoxEx.Show(Me, "Este documento ya no tiene los mismos vencimientos" & vbCrLf &
                                  "por lo tanto ya no es posible seguir haciendo gestión, debe actualizar el listado para continuar",
                                  "Cambio de fechas en tiempo de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Btn_Enviar_correo.Visible = False
                'Btn_Exportar_Excel.Visible = False
                'Btn_Mover.Visible = False
                'Btn_Pagar_Transferencia.Visible = False
                'Btn_Autorizar_Pago_De_Documentos_Proveedores.Visible = False
                'Btn_Actualizar_Informacion.Visible = False
                _Reprocesar_Informe = True
                'Me.Refresh()
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_Pago_Proveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pago_Proveedores.Click

        If Fx_Revisar_Chequeados() Then

            If (_Row_Pago_Autorizado Is Nothing) Then
                ShowContextMenu(Menu_Contextual_04_Como_Pagar)
            Else

                Dim _Tipo_Pago As String = _Row_Pago_Autorizado.Item("Tipo_Pago")

                Select Case _Tipo_Pago
                    Case "CHC"
                        Call Btn_Pagar_Con_Cheques_Click(Nothing, Nothing)
                    Case "PTB"
                        Call Btn_Pagar_Con_Transferencia_Click(Nothing, Nothing)
                    Case Else
                        ShowContextMenu(Menu_Contextual_04_Como_Pagar)
                End Select

            End If

        Else
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_TblInforme, Me, "Detalle_de_documentos")
    End Sub


    Function Fx_Revisar_Chequeados() As Boolean

        Dim _CtaChequeados As Integer = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows
            If _Fila.Cells("Chk").Value Then
                _CtaChequeados += 1
            End If
        Next

        If Not CBool(_Total_a_Pagar) Then
            _CtaChequeados = 0
        End If

        Return CBool(_CtaChequeados)

    End Function

    Private Sub Btn_Pagar_Con_Transferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pagar_Con_Transferencia.Click

        If _Tipo_Pago = Enum_Tipo_Pago.Proveedores Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        ElseIf _Tipo_Pago = Enum_Tipo_Pago.Clientes Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf
        End If

        Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_TblInforme, "Chk", "IDMAEEDO", True, True)
        Dim _Filtro_Idmaeven As String = Generar_Filtro_IN(_TblInforme, "Chk", "IDMAEVEN", True, True)

        ' Consulta_sql = _SqlConsulta_informe 'My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Inicio)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Fin)

        'If String.IsNullOrEmpty(_CodEntidad) Then
        Consulta_sql += "Update #INFVEN Set Chk = 1 Where IDMAEVEN In " & _Filtro_Idmaeven & vbCrLf &
                        "Select *" & vbCrLf &
                        "From #INFVEN" & vbCrLf &
                        "Where Chk = 1" & vbCrLf &
                        "Order By FEVE" & vbCrLf & vbCrLf &
                        "Select ENDO,SUENDO,SUM(SALDO) As SALDO" & vbCrLf &
                        "From #INFVEN" & vbCrLf &
                        "Where Chk = 1" & vbCrLf &
                        "Group By ENDO,SUENDO" & vbCrLf & vbCrLf &
                        "Select CAST( 1 AS bit) AS Chk,* From MAEEN" & vbCrLf &
                        "Where KOEN+SUEN in (Select Distinct ENDO+SUENDO From #INFVEN Where Chk = 1)" & vbCrLf & vbCrLf &
                        "SELECT SUBSTRING(MC.REFANTI,1,3) As Tido,SUBSTRING(MC.REFANTI,5,10) As Nudo," & vbCrLf &
                        "(Select top 1 TIDO From MAEEDO Where IDMAEEDO = MD.IDRST) As Tidp_P," & vbCrLf &
                        "(Select top 1 NUDO From MAEEDO Where IDMAEEDO = MD.IDRST) As Nudo_P," & vbCrLf &
                        "MC.VAASDP" & vbCrLf &
                        "FROM MAEDPCD MD WITH ( NOLOCK ) INNER JOIN MAEDPCE MC ON MD.IDMAEDPCE = MC.IDMAEDPCE " & vbCrLf &
                        "WHERE IDRST IN (Select IDMAEEDO From #INFVEN) AND ARCHIRST = 'MAEEDO' AND TIDP in ('ncv','ncc','ncx')" & vbCrLf &
                        "Select SUM(SALDO) As SALDO From #INFVEN Where Chk = 1" & vbCrLf &
                        "Drop Table #INFVEN"
        'End If
        ' DEBO SUMAR EL SALDO Y COMPRARALO NUEVAMENTE CON EL SALDO ACTUAL
        ' SI ES DISTINTO SIGNIFICA QUE ALGUIEN PAGO ALGUNO DE ESTOS DOCUMENTOS DESPUES QUE YO
        Consulta_sql = Replace(Consulta_sql, "SELECT EDO.IDMAEEDO", "SELECT CAST( 0 AS Float) AS Chk,EDO.IDMAEEDO")

        Dim _DsInforme As DataSet = Fx_Ds_Informe_Pagos("") ' _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Vadp As Double = _DsInforme.Tables(4).Rows(0).Item("SALDO")

        If _Total_a_Pagar = _Vadp Then
            Dim _Pagar As New Frm_Pagos_Masivos_Transferencia(_DsInforme)
            _Pagar.ShowDialog(Me)

            If _Pagar._Pagado Then

                Dim _TblInf As DataTable = _DsInforme.Tables(0)
                Dim _TblEnt As DataTable = _DsInforme.Tables(2)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Set Pagado = 1" & vbCrLf &
                               "Where Idmaeven In " & _Filtro_Idmaeven
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Dim _Row_New_Maedpce As DataRow = _Pagar.Pro_New_Maedpce
                Dim _Idmaedpce As Integer = _Row_New_Maedpce.Item("IDMAEDPCE")

                Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
                Fm.ShowDialog(Me)
                Fm.Dispose()


                Sb_Actualizar_Grilla()
                'Sb_Generar_Informe()
                _Reprocesar_Informe = True

                _Reprocesar_Informe = True
                Sb_Actualizar_Grilla()

                Call Sb_Grilla_CellEndEdit(Nothing, Nothing)

                If Not CBool(_Total_a_Pagar) Then
                    If MessageBoxEx.Show(Me, "Todos los documentos marcados ya están pagados" & vbCrLf & vbCrLf &
                                         "¿Desea cerrar este formulario?", "Pago masivo",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Close()
                    End If
                End If

            End If
        Else
            Dim info As New TaskDialogInfo("Validación de seguridad",
                                    eTaskDialogIcon.ShieldStop,
                                    "El total del saldo calculado es distinto al total a pagar",
                                    "Saldo a pagar según la lista: " & FormatCurrency(_Total_a_Pagar, 0) & vbCrLf &
                                    "Total a pagar según saldo real: " & FormatCurrency(_Vadp, 0) & vbCrLf &
                                    "Diferencia: " & FormatCurrency(_Total_a_Pagar - _Vadp, 0) & vbCrLf & vbCrLf &
                                    "Esto pudo haber ocurrido porque alguien pago algún documento de la lista fuera de este tratamiento." & vbCrLf & vbCrLf &
                                    "Deberar correr nuevamente el proceso de analisis de pago" & vbCrLf,
                                    eTaskDialogButton.Ok _
                                    , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            _Reprocesar_Informe = True
            Me.Close()

        End If

    End Sub

    Private Sub Sb_Chk_Marcar_todo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim chk As Boolean = Chk_Marcar_todo.Checked

        For Each _Fila As DataGridViewRow In Grilla.Rows
            Dim _Saldo As Double = _Fila.Cells("SALDO").Value
            If CBool(_Saldo) Then
                _Fila.Cells("Chk").Value = chk
            End If
        Next

        Call Sb_Grilla_CellEndEdit(Nothing, Nothing)
    End Sub

    Private Sub Btn_Pagar_Con_Cheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pagar_Con_Cheques.Click

        Dim _DsInforme As DataSet = Fx_Ds_Informe_Pagos(_Filtro_Adicional) ' _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Vadp As Double = _DsInforme.Tables(4).Rows(0).Item("SALDO")

        If _Total_a_Pagar = _Vadp Then

            Dim _Referencia As String = "Pago masivo BakApp"

            Dim _Pagar As New Frm_Pagos_Masivos_Cheque(_DsInforme)

            If Not (_Row_Pago_Autorizado Is Nothing) Then
                _Pagar.Pro_Referencia = _Referencia & Space(1) & "según asignación Nro: " & _Row_Pago_Autorizado.Item("Id_Autoriza")
                _Pagar.Pro_Bloquear_Fecha_Vencimiento = True
                _Pagar.Pro_Fecha_Vencimiento = _Row_Pago_Autorizado.Item("Fecha_Pago")
            End If

            _Pagar.ShowDialog(Me)

            If _Pagar.Pro_Pagado Then

                Dim _TblInf As DataTable = _DsInforme.Tables(0)
                Dim _TblEnt As DataTable = _DsInforme.Tables(2)
                Dim _Filtro_Idmaeven = Generar_Filtro_IN(_TblInforme, "Chk", "IDMAEVEN", True, True)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Set Pagado = 1" & vbCrLf &
                               "Where Idmaeven In " & _Filtro_Idmaeven
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Dim _Row_New_Maedpce As DataRow = _Pagar.Pro_New_Maedpce
                Dim _Idmaedpce As Integer = _Row_New_Maedpce.Item("IDMAEDPCE")

                Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

            _Reprocesar_Informe = True
            Sb_Actualizar_Grilla()

            Call Sb_Grilla_CellEndEdit(Nothing, Nothing)

            If Not CBool(_Total_a_Pagar) Then
                If MessageBoxEx.Show(Me, "Todos los documentos marcados ya están pagados" & vbCrLf & vbCrLf &
                                     "¿Desea cerrar este formulario?", "Pago masivo",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Close()
                End If
            End If

        Else
            Dim info As New TaskDialogInfo("Validación de seguridad",
                                    eTaskDialogIcon.ShieldStop,
                                    "El total del saldo calculado es distinto al total a pagar",
                                    "Saldo a pagar según la lista: " & FormatCurrency(_Total_a_Pagar, 0) & vbCrLf &
                                    "Total a pagar según saldo real: " & FormatCurrency(_Vadp, 0) & vbCrLf &
                                    "Diferencia: " & FormatCurrency(_Total_a_Pagar - _Vadp, 0) & vbCrLf & vbCrLf &
                                    "Esto pudo haber ocurrido porque alguien pago algún documento de la lista fuera de este tratamiento." & vbCrLf & vbCrLf &
                                    "Deberar correr nuevamente el proceso de analisis de pago" & vbCrLf,
                                    eTaskDialogButton.Ok _
                                    , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            Sb_Actualizar_Grilla()
        End If



    End Sub

    Function Fx_Ds_Informe_Pagos(ByVal _Filtro_Adicional As String) As DataSet

        If _Tipo_Pago = Enum_Tipo_Pago.Proveedores Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        ElseIf _Tipo_Pago = Enum_Tipo_Pago.Clientes Then
            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf
        End If

        Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_TblInforme, "Chk", "IDMAEEDO", True, True)
        Dim _Filtro_Idmaeven As String = Generar_Filtro_IN(_TblInforme, "Chk", "IDMAEVEN", True, True)

        ' Consulta_sql = _SqlConsulta_informe 'My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Inicio)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Fin)

        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional", _Filtro_Adicional)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)


        Consulta_sql += "Update #INFVEN Set Chk = 1 Where IDMAEVEN In " & _Filtro_Idmaeven & vbCrLf &
                        "Select *" & vbCrLf &
                        "From #INFVEN" & vbCrLf &
                        "Where Chk = 1" & vbCrLf &
                        "Order By FEVE" & vbCrLf & vbCrLf &
                        "Select ENDO,SUENDO,SUM(SALDO) As SALDO" & vbCrLf &
                        "From #INFVEN" & vbCrLf &
                        "Where Chk = 1" & vbCrLf &
                        "Group By ENDO,SUENDO" & vbCrLf & vbCrLf &
                        "Select CAST( 1 AS bit) AS Chk,* From MAEEN" & vbCrLf &
                        "Where KOEN+SUEN in (Select Distinct ENDO+SUENDO From #INFVEN Where Chk = 1)" & vbCrLf & vbCrLf &
                        "SELECT SUBSTRING(MC.REFANTI,1,3) As Tido,SUBSTRING(MC.REFANTI,5,10) As Nudo," & vbCrLf &
                        "(Select top 1 TIDO From MAEEDO Where IDMAEEDO = MD.IDRST) As Tidp_P," & vbCrLf &
                        "(Select top 1 NUDO From MAEEDO Where IDMAEEDO = MD.IDRST) As Nudo_P," & vbCrLf &
                        "MC.VAASDP" & vbCrLf &
                        "FROM MAEDPCD MD WITH ( NOLOCK ) INNER JOIN MAEDPCE MC ON MD.IDMAEDPCE = MC.IDMAEDPCE " & vbCrLf &
                        "WHERE IDRST IN (Select IDMAEEDO From #INFVEN) AND ARCHIRST = 'MAEEDO' AND TIDP in ('ncv','ncc','ncx')" & vbCrLf &
                        "Select Isnull(SUM(SALDO),0) As SALDO From #INFVEN Where Chk = 1" & vbCrLf &
                        "Drop Table #INFVEN"

        Consulta_sql = Replace(Consulta_sql, "SELECT EDO.IDMAEEDO", "SELECT CAST( 0 AS Float) AS Chk,EDO.IDMAEEDO")

        Dim _DsInforme As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Return _DsInforme

    End Function

    Private Sub Btn_Pagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If (_Row_Pago_Autorizado Is Nothing) Then

        Else

        End If

    End Sub

    Private Sub Frm_Pagos_Masivos_Detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Ver_Pagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Pagos.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento_Pagos(_Idmaeedo)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Quitar_Permiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Permiso.Click

        If Fx_Tiene_Permiso(Me, "Ppro0006") Then

            'SELECT     TOP (200) Id_Autoriza, Idmaeedo, Idmaeven, Revisado, Sospecha_Stock, Sospecha_Devolucion, Autorizado, Funcionario_Autoriza, Saldo, Pagado, Idmaedpce, Tidp, Nudp
            'FROM         Zw_Pago_Prov_Autoriza_02_Det

            If MessageBoxEx.Show(Me, "¿Confirma quitar este registro del tratamiento?",
                                 "Confirmación", MessageBoxButtons.YesNoCancel,
                                 MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & vbCrLf &
                               "Where Idmaeven = " & _Idmaeven
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Sb_Actualizar_Grilla()
                End If

            End If

        End If

    End Sub


    Private Sub Sb_Grilla_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Saldo As Double = _Fila.Cells("SALDO").Value

            If _Saldo = 0 Then
                e.Cancel = True
                Beep()
            End If
        Catch ex As Exception

        End Try

    End Sub


End Class
