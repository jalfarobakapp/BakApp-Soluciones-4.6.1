Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_CiasSeguro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodEntidad As String
    Dim _CodSucEntidad As String
    Dim _MontoCreditoTotal As Double
    Dim _SumMontoAsignado As Double

    Public Property ModoSeleccion As Boolean
    Public Property MontoAUtilizar As Double
    Public Property Row_CiaSeguro As DataRow

    Public Sub New(_CodEntidad As String, _CodSucEntidad As String, _MontoCreditoTotal As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._CodEntidad = _CodEntidad
        Me._CodSucEntidad = _CodSucEntidad
        Me._MontoCreditoTotal = _MontoCreditoTotal

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_CiasSeguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Formato_Generico_Grilla(Grilla_CisSeguros, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, ModoSeleccion, False)

        Btn_AsociarCiaSeguro.Enabled = Not ModoSeleccion
        Btn_VenderSinUsarCiaSeguro.Visible = ModoSeleccion

        If ModoSeleccion Then
            Sb_Actualizar_Grilla_ModoSeleccion()
        Else
            Sb_Actualizar_Grilla()
            AddHandler Grilla_CisSeguros.MouseDown, AddressOf Sb_Grilla_Cuentas_MouseDown
        End If

        AddHandler Grilla_CisSeguros.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = $"
Select Cia.*, EN.NOKOEN From {_Global_BaseBk}Zw_Entidad_CiaSeguro Cia
Inner Join MAEEN EN On EN.KOEN = Cia.CodEntidad_Cia And Cia.CodSucEntidad_Cia = EN.SUEN
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        ' Calcular la suma de MontoAsignado y asignarla a la variable de instancia
        Dim _ObjSuma As Object = Nothing
        Try
            _ObjSuma = _Tbl.Compute("SUM(MontoAsignado)", "")
        Catch ex As Exception
            _ObjSuma = Nothing
        End Try

        If IsDBNull(_ObjSuma) OrElse _ObjSuma Is Nothing Then
            _SumMontoAsignado = 0
        Else
            _SumMontoAsignado = Convert.ToDouble(_ObjSuma)
        End If

        With Grilla_CisSeguros

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_CisSeguros, True)

            Dim _DisplayIndex As Integer = 0

            .Columns("CodEntidad_Cia").HeaderText = "Código Cia"
            .Columns("CodEntidad_Cia").Width = 100
            .Columns("CodEntidad_Cia").Visible = True
            .Columns("CodEntidad_Cia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodSucEntidad_Cia").HeaderText = "Suc."
            .Columns("CodSucEntidad_Cia").Width = 50
            .Columns("CodSucEntidad_Cia").Visible = True
            .Columns("CodSucEntidad_Cia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").HeaderText = "Nombre compañia de seguros"
            .Columns("NOKOEN").Width = 400
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MontoAsignado").HeaderText = "Monto Asignado"
            .Columns("MontoAsignado").Width = 100
            .Columns("MontoAsignado").Visible = True
            .Columns("MontoAsignado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MontoAsignado").DefaultCellStyle.Format = "###,##0"
            .Columns("MontoAsignado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Grilla_CisSeguros.Focus()

    End Sub

    Sub Sb_Actualizar_Grilla_ModoSeleccion()

        Dim _Cl_Entidad As New Cl_Entidad

        Dim _Msj_CiaSeguro As LsValiciones.Mensajes = _Cl_Entidad.Fx_Llenar_Entidad_CiaSeguros(_CodEntidad, _CodSucEntidad)
        Dim _Tbl As DataTable = _Msj_CiaSeguro.Tag


        ' Eliminar el último registro de la tabla si existe (por ejemplo, fila de totales)
        If _Tbl IsNot Nothing AndAlso _Tbl.Rows.Count > 0 Then
            Try
                Dim _NombreCia As String = _Tbl.Rows(_Tbl.Rows.Count - 1).Item("NombreCia")
                If _NombreCia = "SIN COMPAÑÍA" Then
                    _Tbl.Rows.RemoveAt(_Tbl.Rows.Count - 1)
                End If
            Catch ex As Exception
                ' Si falla la eliminación (tabla de solo lectura u otro error) continuar sin eliminar.
            End Try
        End If

        With Grilla_CisSeguros

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_CisSeguros, True)

            Dim _DisplayIndex As Integer = 0

            '.Columns("CodEntidad_Cia").HeaderText = "Código Cia"
            '.Columns("CodEntidad_Cia").Width = 100
            '.Columns("CodEntidad_Cia").Visible = True
            '.Columns("CodEntidad_Cia").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("CodSucEntidad_Cia").HeaderText = "Suc."
            '.Columns("CodSucEntidad_Cia").Width = 50
            '.Columns("CodSucEntidad_Cia").Visible = True
            '.Columns("CodSucEntidad_Cia").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NombreCia").HeaderText = "Nombre compañia de seguros"
            .Columns("NombreCia").Width = 250
            .Columns("NombreCia").Visible = True
            .Columns("NombreCia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MontoAsignado").HeaderText = "M.Asignado"
            .Columns("MontoAsignado").Width = 75
            .Columns("MontoAsignado").Visible = True
            .Columns("MontoAsignado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MontoAsignado").DefaultCellStyle.Format = "###,##0"
            .Columns("MontoAsignado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CHV").HeaderText = "CHV"
            .Columns("CHV").Width = 75
            .Columns("CHV").Visible = True
            .Columns("CHV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CHV").DefaultCellStyle.Format = "###,##0"
            .Columns("CHV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FCV").HeaderText = "FCV"
            .Columns("FCV").Width = 75
            .Columns("FCV").Visible = True
            .Columns("FCV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FCV").DefaultCellStyle.Format = "###,##0"
            .Columns("FCV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NVV").HeaderText = "NVV"
            .Columns("NVV").Width = 75
            .Columns("NVV").Visible = True
            .Columns("NVV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NVV").DefaultCellStyle.Format = "###,##0"
            .Columns("NVV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NVVSOL").HeaderText = "NVVSOL"
            .Columns("NVVSOL").Width = 75
            .Columns("NVVSOL").Visible = True
            .Columns("NVVSOL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NVVSOL").DefaultCellStyle.Format = "###,##0"
            .Columns("NVVSOL").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalUtilizado").HeaderText = "T.Utilizado"
            .Columns("TotalUtilizado").Width = 75
            .Columns("TotalUtilizado").Visible = True
            .Columns("TotalUtilizado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalUtilizado").DefaultCellStyle.Format = "###,##0"
            .Columns("TotalUtilizado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SaldoDisponible").HeaderText = "TDisponible"
            .Columns("SaldoDisponible").Width = 75
            .Columns("SaldoDisponible").Visible = True
            .Columns("SaldoDisponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SaldoDisponible").DefaultCellStyle.Format = "###,##0"
            .Columns("SaldoDisponible").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Grilla_CisSeguros.Focus()

    End Sub

    Private Sub Btn_AsociarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_AsociarCiaSeguro.Click

        Dim _CreditoDisponible As Double = _MontoCreditoTotal - _SumMontoAsignado

        If _CreditoDisponible <= 0 Then
            MessageBoxEx.Show(Me, "El cliente no cuenta con crédito disponible." & vbCrLf &
                              "Para asignar una nueva compañía de seguros, primero debe aumentar el crédito total asociado al cliente.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Entidades", "EsCiaSeguro = 1")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen compañias de seguro asociadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Row As DataRow

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.VerSoloCiaSeguro = True
        Fm.ShowDialog(Me)
        _Row = Fm.Pro_RowEntidad
        Fm.Dispose()

        If IsNothing(_Row) Then
            Return
        End If

        Dim _CodEntidad_Cia As String = _Row.Item("KOEN")
        Dim _CodSucEntidad_Cia As String = _Row.Item("SUEN")

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Entidad_CiaSeguro",
                                        $"CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}' " &
                                        $"And CodEntidad_Cia = '{_CodEntidad_Cia}' And CodSucEntidad_Cia = '{_CodSucEntidad_Cia}'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Esta compañia de seguros ya esta asociada a la entidad", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_AsociarCiaSeguro_Click(Nothing, Nothing)
            Return
        End If

        Dim _MontoAsignado As Double

        _MontoAsignado = Fx_Asignar_Monto(_MontoAsignado, _CreditoDisponible)

        If _MontoAsignado = 0 Then
            MessageBoxEx.Show(Me, "La compañia de seguros no fue agregada a la lista del cliente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_Sql = $"
Insert Into {_Global_BaseBk}Zw_Entidad_CiaSeguro (CodEntidad,CodSucEntidad,CodEntidad_Cia,CodSucEntidad_Cia,MontoAsignado) 
Values ('{_CodEntidad}','{_CodSucEntidad}','{_CodEntidad_Cia}','{_CodSucEntidad_Cia}',{De_Num_a_Tx_01(_MontoAsignado, False, 5)})"
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Compañia de seguros asociada correctamente", "Agregar compañía de seguros",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Function Fx_Asignar_Monto(_MontoAsignado As Double, _CreditoDisponible As Double) As Double

        Dim _CerradoPorX As Boolean
        Dim _Cancelado As Boolean

        Do
            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Crédito total disponible del cliente: " & FormatNumber(_CreditoDisponible, 0) & vbCrLf &
                                                  "Ingrese el monto a asignar", "Monto asignado",
                                                  _MontoAsignado, False, _Tipo_Mayus_Minus.Normal, 10,
                                                  True, _Tipo_Imagen.Money1,, _Tipo_Caracter.Moneda, False,,,,,
                                                  _CerradoPorX, _Cancelado)

            If Not _Aceptar Then
                Return 0
            End If

            ' Validar que la suma actual más el monto ingresado no supere el monto de crédito total.
            If _MontoAsignado > _CreditoDisponible Then
                MessageBoxEx.Show(Me, "El monto asignado no puede ser mayor al monto de crédito total disponible" & vbCrLf &
                                  "Crédito total disponible del cliente: " & FormatNumber(_CreditoDisponible, 0), "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' Volver a pedir el monto
            Else
                Return _MontoAsignado
            End If
        Loop

    End Function


    Private Sub Sb_Grilla_Cuentas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_01)

                End If
            End With
        End If
    End Sub

    Private Sub Btn_EditarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_EditarCiaSeguro.Click

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow
        Dim _CodEntidad_Cia As String = _Fila.Cells("CodEntidad_Cia").Value
        Dim _CodSucEntidad_Cia As String = _Fila.Cells("CodSucEntidad_Cia").Value
        Dim _MontoAsignado As Double = _Fila.Cells("MontoAsignado").Value

        Dim _CreditoDisponible As Double = _MontoCreditoTotal - _SumMontoAsignado + _MontoAsignado

        Dim _NuevoMontoAsignado As Double = Fx_Asignar_Monto(_MontoAsignado, _CreditoDisponible)

        If _NuevoMontoAsignado = 0 Then
            MessageBoxEx.Show(Me, "El monto asignado a la compañia de seguros no fue modificado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_Sql = $"
Update {_Global_BaseBk}Zw_Entidad_CiaSeguro Set MontoAsignado = {De_Num_a_Tx_01(_NuevoMontoAsignado, False, 5)} 
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}' And CodEntidad_Cia = '{_CodEntidad_Cia}' And CodSucEntidad_Cia = '{_CodSucEntidad_Cia}'"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Compañia de seguros actualizada correctamente", "Editar compañía de seguros",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_QuitarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_QuitarCiaSeguro.Click

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow
        Dim _CodEntidad_Cia As String = _Fila.Cells("CodEntidad_Cia").Value
        Dim _CodSucEntidad_Cia As String = _Fila.Cells("CodSucEntidad_Cia").Value

        If MessageBoxEx.Show(Me, "¿Confirma que desea quitar esta compañía de seguros de la lista del cliente?", "Quitar compañía de seguros",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_Sql = $"
Delete From {_Global_BaseBk}Zw_Entidad_CiaSeguro 
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}' And CodEntidad_Cia = '{_CodEntidad_Cia}' And CodSucEntidad_Cia = '{_CodSucEntidad_Cia}'"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Compañia de seguros quitada correctamente", "Quitar compañía de seguros",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Grilla_CisSeguros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_CisSeguros.CellDoubleClick

        If Not ModoSeleccion Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow
        Dim _SaldoDisponible As Double = _Fila.Cells("SaldoDisponible").Value

        If MontoAUtilizar > _SaldoDisponible Then
            MessageBoxEx.Show(Me, "El monto a utilizar es mayor al saldo disponible de la compañía de seguros seleccionada." & vbCrLf &
                              "Monto a utilizar: " & FormatNumber(MontoAUtilizar, 0) & vbCrLf &
                              "Saldo disponible: " & FormatNumber(_SaldoDisponible, 0), "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Grilla_CisSeguros.CurrentRow IsNot Nothing AndAlso Grilla_CisSeguros.CurrentRow.DataBoundItem IsNot Nothing Then
            Dim drv As DataRowView = TryCast(Grilla_CisSeguros.CurrentRow.DataBoundItem, DataRowView)
            If drv IsNot Nothing Then
                Row_CiaSeguro = drv.Row
            Else
                ' Si no es DataRowView, intentar obtener directamente del DataTable (con precaución)
                Dim dt As DataTable = TryCast(Grilla_CisSeguros.DataSource, DataTable)
                If dt IsNot Nothing Then
                    Row_CiaSeguro = dt.Rows(Grilla_CisSeguros.CurrentRow.Index)
                Else
                    Row_CiaSeguro = Nothing
                End If
            End If
        Else
            Row_CiaSeguro = Nothing
        End If

        If IsNothing(Row_CiaSeguro) Then
            MessageBoxEx.Show(Me, "No se pudo obtener la información de la compañía de seguros seleccionada.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma utilizar esta compañia de seguros?" & vbCrLf &
                             "Compañia: " & Row_CiaSeguro.Item("NombreCia").ToString.Trim, "Seleccionar compañia de seguros",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Btn_VenderSinUsarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_VenderSinUsarCiaSeguro.Click

        If MessageBoxEx.Show(Me, "¿Confirma vender sin usar compañia de seguros?", "Vender sin usar CIA de seguros",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Me.DialogResult = DialogResult.No
        Me.Close()

    End Sub
End Class
