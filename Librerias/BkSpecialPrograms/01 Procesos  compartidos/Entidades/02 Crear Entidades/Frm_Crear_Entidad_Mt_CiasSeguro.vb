Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_CiasSeguro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodEntidad As String
    Dim _CodSucEntidad As String
    Dim _SumMontoAsignado As Double

    Public Property MontoCreditoTotal As Double
    Public Property ModoSeleccion As Boolean
    Public Property ModoSoloLectura As Boolean
    Public Property MontoAUtilizar As Double
    Public Property Row_CiaSeguro As DataRow
    Public Property UsarCreditoFINCRED As Boolean

    Public Sub New(_CodEntidad As String, _CodSucEntidad As String, _MontoCreditoTotal As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._CodEntidad = _CodEntidad
        Me._CodSucEntidad = _CodSucEntidad
        Me.MontoCreditoTotal = _MontoCreditoTotal

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_CiasSeguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_DatosCiaSeguros.Text = String.Empty

        Sb_Formato_Generico_Grilla(Grilla_CisSeguros, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, ModoSeleccion, False)

        Btn_AsociarCiaSeguro.Enabled = Not ModoSeleccion
        Btn_VenderSinUsarCiaSeguro.Visible = ModoSeleccion
        Btn_VerFCV.Visible = Not ModoSeleccion
        Btn_InfFincred.Visible = UsarCreditoFINCRED

        If ModoSoloLectura Then
            Btn_AsociarCiaSeguro.Visible = False
            Btn_VenderSinUsarCiaSeguro.Visible = False
            Btn_VerFCV.Visible = True
            Btn_InfFincred.Visible = False
            Sb_Actualizar_Grilla()
        Else
            If ModoSeleccion Then
                Sb_Actualizar_Grilla_ModoSeleccion()
            Else
                Sb_Actualizar_Grilla()
                AddHandler Grilla_CisSeguros.MouseDown, AddressOf Sb_Grilla_Cuentas_MouseDown
            End If
        End If

        AddHandler Grilla_CisSeguros.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    ' Plan / pseudocódigo detallado:
    ' 1) Al actualizar las grillas calcular la suma de "MontoAsignado" considerando solo compañias activas.
    '    - Esto asegura que el crédito disponible se calcula únicamente con compañias activas.
    '    - Guardar la suma en la variable de instancia _SumMontoAsignado.
    ' 2) Validaciones al asignar/editar monto:
    '    - No permitir asignar un monto mayor al crédito disponible.
    '    - No permitir asignar un monto menor que el "TotalUtilizado" de la compañía (minimo permitido).
    ' 3) Modificar Fx_Asignar_Monto para recibir un parámetro opcional _MinimoPermitido y validar que
    '    el monto ingresado sea >= _MinimoPermitido.
    ' 4) En la edición de compañía calcular el crédito disponible considerando que se liberará el monto actual
    '    de la compañía que se edita (es decir: crédito disponible = _MontoCreditoTotal - _SumMontoAsignado + MontoActual).
    ' 5) Implementar sumas seguras leyendo valores DBNull y comprobando campo "Activo".
    ' 6) Aplicar lo anterior tanto en modo normal como en modo selección.
    '
    ' Implementación abajo.

    Sub Sb_Actualizar_Grilla()

        Lbl_DatosCiaSeguros.Text = String.Empty

        Consulta_Sql = $"
Select Cia.*, EN.NOKOEN From {_Global_BaseBk}Zw_Entidad_CiaSeguro Cia
Inner Join MAEEN EN On EN.KOEN = Cia.CodEntidad_Cia And Cia.CodSucEntidad_Cia = EN.SUEN
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}'"

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


        ' Calcular la suma de MontoAsignado solo para compañias activas y asignarla a la variable de instancia
        _SumMontoAsignado = 0
        If _Tbl IsNot Nothing Then
            For Each _rw As DataRow In _Tbl.Rows
                Try
                    Dim _activo As Boolean = False
                    If Not IsDBNull(_rw.Item("Activa")) Then
                        _activo = CBool(_rw.Item("Activa"))
                    End If

                    If _activo Then
                        Dim _monto As Double = 0
                        If Not IsDBNull(_rw.Item("MontoAsignado")) Then
                            Double.TryParse(_rw.Item("MontoAsignado").ToString(), _monto)
                        End If
                        _SumMontoAsignado += _monto
                    End If
                Catch ex As Exception
                    ' ignorar fila problemática
                End Try
            Next
        End If

        MontoCreditoTotal = _SumMontoAsignado

        With Grilla_CisSeguros

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_CisSeguros, True)

            Dim _DisplayIndex As Integer = 0

            .Columns("Activa").HeaderText = "Act."
            .Columns("Activa").ToolTipText = "¿Activa?"
            .Columns("Activa").Width = 30
            .Columns("Activa").Visible = True
            .Columns("Activa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

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
            .Columns("CHV").ToolTipText = "Cheque pendiente de pago"
            .Columns("CHV").Width = 75
            .Columns("CHV").Visible = True
            .Columns("CHV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CHV").DefaultCellStyle.Format = "###,##0"
            .Columns("CHV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FCV").HeaderText = "FCV"
            .Columns("FCV").ToolTipText = "Factura de venta"
            .Columns("FCV").Width = 75
            .Columns("FCV").Visible = True
            .Columns("FCV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FCV").DefaultCellStyle.Format = "###,##0"
            .Columns("FCV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NVV").HeaderText = "NVV"
            .Columns("NVV").ToolTipText = "Nota de venta"
            .Columns("NVV").Width = 75
            .Columns("NVV").Visible = True
            .Columns("NVV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NVV").DefaultCellStyle.Format = "###,##0"
            .Columns("NVV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NVVSOL").HeaderText = "NVVSOL"
            .Columns("NVVSOL").ToolTipText = "Nota de venta (pendiente de permiso remoto)"
            .Columns("NVVSOL").Width = 75
            .Columns("NVVSOL").Visible = True
            .Columns("NVVSOL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NVVSOL").DefaultCellStyle.Format = "###,##0"
            .Columns("NVVSOL").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COVSS").HeaderText = "COVSS"
            .Columns("COVSS").ToolTipText = "Cotización Sobre Stock"
            .Columns("COVSS").Width = 75
            .Columns("COVSS").Visible = True
            .Columns("COVSS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COVSS").DefaultCellStyle.Format = "###,##0"
            .Columns("COVSS").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COVSSPP").HeaderText = "COVSOL"
            .Columns("COVSSPP").ToolTipText = "Cotización Sobre Stock (pendiente de permiso remoto)"
            .Columns("COVSSPP").Width = 75
            .Columns("COVSSPP").Visible = True
            .Columns("COVSSPP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COVSSPP").DefaultCellStyle.Format = "###,##0"
            .Columns("COVSSPP").DisplayIndex = _DisplayIndex
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

        ' Aplicar colores de fila según valor de columna "Activa"
        Sb_Aplicar_Color_Filas(Grilla_CisSeguros)

        Grilla_CisSeguros.Focus()

    End Sub

    Sub Sb_Actualizar_Grilla_ModoSeleccion()

        Lbl_DatosCiaSeguros.Text = String.Empty

        Dim _Cl_Entidad As New Cl_Entidad

        Dim _Msj_CiaSeguro As LsValiciones.Mensajes = _Cl_Entidad.Fx_Llenar_Entidad_CiaSeguros(_CodEntidad, _CodSucEntidad)
        Dim _Tbl As DataTable = _Msj_CiaSeguro.Tag

        ' Crear una tabla que contendrá solo las compañías activas y distintas de "SIN COMPAÑÍA"
        Dim _TblActivas As DataTable = Nothing
        If _Tbl IsNot Nothing Then
            Try
                _TblActivas = _Tbl.Clone()
                For Each _rw As DataRow In _Tbl.Rows
                    Try
                        Dim _NombreCia As String = String.Empty
                        If Not IsDBNull(_rw.Item("NombreCia")) Then
                            _NombreCia = _rw.Item("NombreCia").ToString().Trim()
                        End If

                        Dim _Activa As Boolean = False
                        If Not IsDBNull(_rw.Item("Activa")) Then
                            _Activa = CBool(_rw.Item("Activa"))
                        End If

                        ' Importar solo si está activa y no es la fila de "SIN COMPAÑÍA"
                        If _Activa AndAlso _NombreCia <> "SIN COMPAÑÍA" Then
                            _TblActivas.ImportRow(_rw)
                        End If

                    Catch ex As Exception
                        ' Ignorar fila problemática y continuar
                    End Try
                Next
            Catch ex As Exception
                ' Si la clonación o import falla por ser tabla de solo lectura, intentar crear una tabla manualmente
                Try
                    _TblActivas = New DataTable()
                    For Each col As DataColumn In _Tbl.Columns
                        _TblActivas.Columns.Add(col.ColumnName, col.DataType)
                    Next
                    For Each _rw As DataRow In _Tbl.Rows
                        Try
                            Dim _NombreCia As String = String.Empty
                            If Not IsDBNull(_rw.Item("NombreCia")) Then
                                _NombreCia = _rw.Item("NombreCia").ToString().Trim()
                            End If

                            Dim _Activa As Boolean = False
                            If Not IsDBNull(_rw.Item("Activa")) Then
                                _Activa = CBool(_rw.Item("Activa"))
                            End If

                            If _Activa AndAlso _NombreCia <> "SIN COMPAÑÍA" Then
                                Dim newRow As DataRow = _TblActivas.NewRow()
                                For Each col As DataColumn In _Tbl.Columns
                                    newRow(col.ColumnName) = If(IsDBNull(_rw.Item(col.ColumnName)), DBNull.Value, _rw.Item(col.ColumnName))
                                Next
                                _TblActivas.Rows.Add(newRow)
                            End If
                        Catch
                            ' ignorar fila problemática
                        End Try
                    Next
                Catch
                    ' Si todo falla, dejar _TblActivas como Nothing y proceder sin datos
                    _TblActivas = Nothing
                End Try
            End Try
        End If

        ' Calcular la suma de MontoAsignado solo para las filas activas (tabla ya filtrada)
        _SumMontoAsignado = 0
        If _TblActivas IsNot Nothing Then
            For Each _rw As DataRow In _TblActivas.Rows
                Try
                    Dim _monto As Double = 0
                    If Not IsDBNull(_rw.Item("MontoAsignado")) Then
                        Double.TryParse(_rw.Item("MontoAsignado").ToString(), _monto)
                    End If
                    _SumMontoAsignado += _monto
                Catch ex As Exception
                    ' ignorar fila problemática
                End Try
            Next
        End If

        MontoCreditoTotal = _SumMontoAsignado

        With Grilla_CisSeguros

            .DataSource = _TblActivas

            OcultarEncabezadoGrilla(Grilla_CisSeguros, True)

            Dim _DisplayIndex As Integer = 0

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
            .Columns("CHV").ToolTipText = "Cheque pendiente de pago"
            .Columns("CHV").Width = 75
            .Columns("CHV").Visible = True
            .Columns("CHV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CHV").DefaultCellStyle.Format = "###,##0"
            .Columns("CHV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FCV").HeaderText = "FCV"
            .Columns("FCV").ToolTipText = "Factura de venta"
            .Columns("FCV").Width = 75
            .Columns("FCV").Visible = True
            .Columns("FCV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FCV").DefaultCellStyle.Format = "###,##0"
            .Columns("FCV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NVV").HeaderText = "NVV"
            .Columns("NVV").ToolTipText = "Nota de venta"
            .Columns("NVV").Width = 75
            .Columns("NVV").Visible = True
            .Columns("NVV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NVV").DefaultCellStyle.Format = "###,##0"
            .Columns("NVV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NVVSOL").HeaderText = "NVVSOL"
            .Columns("NVVSOL").ToolTipText = "Nota de venta (pendiente de permiso remoto)"
            .Columns("NVVSOL").Width = 75
            .Columns("NVVSOL").Visible = True
            .Columns("NVVSOL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NVVSOL").DefaultCellStyle.Format = "###,##0"
            .Columns("NVVSOL").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COVSS").HeaderText = "COVSS"
            .Columns("COVSS").ToolTipText = "Cotización Sobre Stock"
            .Columns("COVSS").Width = 75
            .Columns("COVSS").Visible = True
            .Columns("COVSS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COVSS").DefaultCellStyle.Format = "###,##0"
            .Columns("COVSS").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COVSSPP").HeaderText = "COVSOL"
            .Columns("COVSSPP").ToolTipText = "Cotización Sobre Stock (pendiente de permiso remoto)"
            .Columns("COVSSPP").Width = 75
            .Columns("COVSSPP").Visible = True
            .Columns("COVSSPP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COVSSPP").DefaultCellStyle.Format = "###,##0"
            .Columns("COVSSPP").DisplayIndex = _DisplayIndex
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

        ' Aplicar colores de fila según valor de columna "Activa"
        Sb_Aplicar_Color_Filas(Grilla_CisSeguros)

        Grilla_CisSeguros.Focus()

    End Sub

    Private Sub Btn_AsociarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_AsociarCiaSeguro.Click

        If Not Fx_Tiene_Permiso(Me, "CfEnt039") Then
            Return
        End If

        '' Crédito disponible: considerar solo las asignaciones de compañías activas para calcular lo que queda del límite total
        Dim _CreditoDisponible As Double '= _MontoCreditoTotal - _SumMontoAsignado

        'If _CreditoDisponible <= 0 Then
        '    MessageBoxEx.Show(Me, "El cliente no cuenta con crédito disponible." & vbCrLf & _
        '                      "Para asignar una nueva compañía de seguros, primero debe aumentar el crédito total asociado al cliente.",
        '                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

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
        Dim _NombreCia As String = _Row.Item("NOKOEN")

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

        ' Para nueva compañia el mínimo permitidio es 0 (no hay "TotalUtilizado")
        _MontoAsignado = Fx_Asignar_Monto(_MontoAsignado, _CreditoDisponible, _CodEntidad_Cia, _CodSucEntidad_Cia, _NombreCia, 0)

        If _MontoAsignado = 0 Then
            MessageBoxEx.Show(Me, "La compañia de seguros no fue agregada a la lista del cliente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_Sql = $"
Insert Into {_Global_BaseBk}Zw_Entidad_CiaSeguro (CodEntidad,CodSucEntidad,CodEntidad_Cia,CodSucEntidad_Cia,MontoAsignado,Activa) 
Values ('{_CodEntidad}','{_CodSucEntidad}','{_CodEntidad_Cia}','{_CodSucEntidad_Cia}',{De_Num_a_Tx_01(_MontoAsignado, False, 5)},1)"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "", 0, "", $"Incorporación de compañía de seguros: {_NombreCia} ({_CodEntidad_Cia} - {_CodSucEntidad_Cia}). Monto: { FormatNumber(_MontoAsignado)}",
                               "", "", _CodEntidad, _CodSucEntidad, False, "")

            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Compañia de seguros asociada correctamente", "Agregar compañía de seguros",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Function Fx_Asignar_Monto(_MontoAsignado As Double,
                              _CreditoDisponible As Double,
                              _CodEntidad_Cia As String,
                              _CodSucEntidad_Cia As String,
                              _NombreCia As String,
                              Optional _MinimoPermitido As Double = 0) As Double

        Dim _CerradoPorX As Boolean
        Dim _Cancelado As Boolean

        Do
            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el monto a asignar para la compañía de seguros: " & vbCrLf &
                                                  _NombreCia.ToString.Trim & " (" & _CodEntidad_Cia.ToString.Trim & "-" & _CodSucEntidad_Cia.ToString.Trim & ")" & vbCrLf &
                                                  IIf(_MinimoPermitido > 0, "(Mínimo permitido por montos utilizados: " & FormatNumber(_MinimoPermitido, 0) & ")", ""),
                                                  "Monto asignado", _MontoAsignado, False, _Tipo_Mayus_Minus.Normal, 10,
                                                  True, _Tipo_Imagen.Money1,, _Tipo_Caracter.Moneda, False,,,,,
                                                  _CerradoPorX, _Cancelado)

            If Not _Aceptar Then
                Return 0
            End If

            ' Validar que el monto sea al menos el mínimo permitido por montos utilizados
            If _MontoAsignado < _MinimoPermitido Then
                MessageBoxEx.Show(Me, "El monto asignado no puede ser menor al total ya utilizado por la compañía." & vbCrLf &
                                  "Mínimo permitido: " & FormatNumber(_MinimoPermitido, 0), "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' Volver a pedir el monto
                Continue Do
            End If

            Return _MontoAsignado

            '' Validar que la suma actual más el monto ingresado no supere el monto de crédito total disponible.
            'If _MontoAsignado > _CreditoDisponible Then
            '    MessageBoxEx.Show(Me, "El monto asignado no puede ser mayor al monto de crédito total disponible" & vbCrLf & _
            '                      "Crédito total disponible del cliente: " & FormatNumber(_CreditoDisponible, 0), "Validación",
            '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    ' Volver a pedir el monto
            'Else
            '    Return _MontoAsignado
            'End If
        Loop

    End Function


    Private Sub Sb_Grilla_Cuentas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Cabeza As String = Fx_ObtenerTextoCabeceraFila(Grilla_CisSeguros.CurrentRow, Grilla_CisSeguros)

                    LabelItem1.Visible = (_Cabeza = "FCV" Or _Cabeza = "NVV")
                    Btn_MostrarDetalle.Visible = (_Cabeza = "FCV" Or _Cabeza = "NVV")

                    Sb_MenuContextual(Grilla_CisSeguros.CurrentRow)

                End If
            End With
        End If
    End Sub

    Sub Sb_MenuContextual(_Fila As DataGridViewRow)

        Btn_Activar.Visible = Not _Fila.Cells("Activa").Value
        Btn_Desactivar.Visible = _Fila.Cells("Activa").Value

        If _Fila.Cells("Activa").Value Then
            Lbl_DatosCiaSeguros.Text = "Compañia de seguros ACTIVA"
        Else
            Lbl_DatosCiaSeguros.Text = "Compañia de seguros INACTIVA"
        End If

        Btn_EditarCiaSeguro.Enabled = _Fila.Cells("Activa").Value

        ShowContextMenu(Menu_Contextual_01)

    End Sub

    Private Sub Btn_EditarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_EditarCiaSeguro.Click

        If Not Fx_Tiene_Permiso(Me, "CfEnt039") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow
        Dim _CodEntidad_Cia As String = _Fila.Cells("CodEntidad_Cia").Value
        Dim _CodSucEntidad_Cia As String = _Fila.Cells("CodSucEntidad_Cia").Value
        Dim _NombreCia As String = _Fila.Cells("NombreCia").Value.ToString.Trim
        Dim _MontoAsignado As Double = 0
        Double.TryParse(_Fila.Cells("MontoAsignado").Value.ToString(), _MontoAsignado)

        Dim _TotalUtilizado As Double = 0
        If Not IsDBNull(_Fila.Cells("TotalUtilizado").Value) Then
            Double.TryParse(_Fila.Cells("TotalUtilizado").Value.ToString(), _TotalUtilizado)
        End If

        ' Crédito disponible: considerar que al editar se liberará el monto actual de la compañía
        Dim _CreditoDisponible As Double = _MontoCreditoTotal - _SumMontoAsignado + _MontoAsignado

        ' El mínimo permitido al editar es el total ya utilizado por la compañía
        Dim _NuevoMontoAsignado As Double = Fx_Asignar_Monto(_MontoAsignado,
                                                             _CreditoDisponible,
                                                             _CodEntidad_Cia,
                                                             _CodSucEntidad_Cia,
                                                             _NombreCia,
                                                             _TotalUtilizado)

        If _NuevoMontoAsignado = 0 Then
            MessageBoxEx.Show(Me, "El monto asignado a la compañia de seguros no fue modificado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_Sql = $"
Update {_Global_BaseBk}Zw_Entidad_CiaSeguro Set MontoAsignado = {De_Num_a_Tx_01(_NuevoMontoAsignado, False, 5)} 
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}' And CodEntidad_Cia = '{_CodEntidad_Cia}' And CodSucEntidad_Cia = '{_CodSucEntidad_Cia}'"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "", 0, "", $"Edita monto compañía de seguros: {_NombreCia} ({_CodEntidad_Cia} - {_CodSucEntidad_Cia}). Monto anterior: { FormatNumber(_MontoAsignado) }, Nuevo Monto: { FormatNumber(_NuevoMontoAsignado)} ",
                               "", "", _CodEntidad, _CodSucEntidad, False, "")

            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Compañia de seguros actualizada correctamente", "Editar compañía de seguros",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_QuitarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_QuitarCiaSeguro.Click

        If Not Fx_Tiene_Permiso(Me, "CfEnt039") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow
        Dim _CodEntidad_Cia As String = _Fila.Cells("CodEntidad_Cia").Value
        Dim _CodSucEntidad_Cia As String = _Fila.Cells("CodSucEntidad_Cia").Value
        Dim _NombreCia As String = _Fila.Cells("NombreCia").Value.ToString.Trim

        Dim _TotalUtilizado As Double = 0
        If Not IsDBNull(_Fila.Cells("TotalUtilizado").Value) Then
            Double.TryParse(_Fila.Cells("TotalUtilizado").Value.ToString(), _TotalUtilizado)
        End If

        Dim _SaldoDisponible As Double = 0
        If Not IsDBNull(_Fila.Cells("SaldoDisponible").Value) Then
            Double.TryParse(_Fila.Cells("SaldoDisponible").Value.ToString(), _SaldoDisponible)
        End If

        If _TotalUtilizado > 0 Then
            MessageBoxEx.Show(Me, "No se puede eliminar esta compañía, ya que registra monto utilizado.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma que desea quitar esta compañía de seguros de la lista del cliente?", "Quitar compañía de seguros",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_Sql = $"
Delete From {_Global_BaseBk}Zw_Entidad_CiaSeguro 
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}' And CodEntidad_Cia = '{_CodEntidad_Cia}' And CodSucEntidad_Cia = '{_CodSucEntidad_Cia}'"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "", 0, "", $"Eliminación de compañía de seguros: {_NombreCia} ({_CodEntidad_Cia} - {_CodSucEntidad_Cia})",
                               "", "", _CodEntidad, _CodSucEntidad, False, "")

            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Compañia de seguros quitada correctamente", "Quitar compañía de seguros",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Grilla_CisSeguros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_CisSeguros.CellDoubleClick

        If ModoSoloLectura Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow

        If Not ModoSeleccion Then

            Dim _Cabeza As String = Fx_ObtenerTextoCabeceraFila(_Fila, Grilla_CisSeguros)

            LabelItem1.Visible = (_Cabeza = "FCV" Or _Cabeza = "NVV")
            Btn_MostrarDetalle.Visible = (_Cabeza = "FCV" Or _Cabeza = "NVV")

            Sb_MenuContextual(Grilla_CisSeguros.CurrentRow)
            Return

        End If


        Dim _SaldoDisponible As Double = 0
        If Not IsDBNull(_Fila.Cells("SaldoDisponible").Value) Then
            Double.TryParse(_Fila.Cells("SaldoDisponible").Value.ToString(), _SaldoDisponible)
        End If

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

        Dim _CodEntidad_Cia As String = Row_CiaSeguro.Item("CodEntidad_Cia")
        Dim _CodSucEntidad_Cia As String = Row_CiaSeguro.Item("CodSucEntidad_Cia")
        Dim _NombreCia As String = Row_CiaSeguro.Item("NombreCia").ToString.Trim

        'If MessageBoxEx.Show(Me, "¿Confirma utilizar esta compañia de seguros?" & vbCrLf &
        '                     "Compañia: " & Row_CiaSeguro.Item("NombreCia").ToString.Trim, "Seleccionar compañia de seguros",
        '                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
        '    Return
        'End If

        Dim _Msg1 = "CONFIRMAR COMPAÑIA DE SEGUROS"
        Dim _Msg2 = vbCrLf & _NombreCia & vbCrLf

        If Not Fx_Confirmar_Lectura(_Msg1, _Msg2, eTaskDialogIcon.ShieldHelp) Then
            Return
        End If

        Me.DialogResult = DialogResult.OK
        Me.UsarCreditoFINCRED = False
        Me.Close()

    End Sub

    Private Sub Btn_VenderSinUsarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_VenderSinUsarCiaSeguro.Click

        Dim _Msg1 = "Vender sin usar CIA de seguros"
        Dim _Msg2 = vbCrLf & "¿Confirma vender sin usar compañia de seguros?" & vbCrLf

        If Not Fx_Confirmar_Lectura(_Msg1.ToUpper, _Msg2.ToUpper, eTaskDialogIcon.ShieldHelp) Then
            Return
        End If

        'If MessageBoxEx.Show(Me, "¿Confirma vender sin usar compañia de seguros?", "Vender sin usar CIA de seguros",
        '                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
        '    Return
        'End If

        Me.UsarCreditoFINCRED = False
        Me.DialogResult = DialogResult.No
        Me.Close()

    End Sub

    Private Sub Grilla_CisSeguros_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_CisSeguros.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow

            Dim _CodigoCia As String = String.Empty
            Dim _NombreCia As String = String.Empty

            If _Fila IsNot Nothing Then
                Try
                    If _Fila.Cells("CodEntidad_Cia") IsNot Nothing AndAlso _Fila.Cells("CodEntidad_Cia").Value IsNot Nothing Then
                        _CodigoCia = _Fila.Cells("CodEntidad_Cia").Value.ToString().Trim()
                    End If
                Catch ex As Exception
                    _CodigoCia = String.Empty
                End Try

                Try
                    If _Fila.Cells("NombreCia") IsNot Nothing AndAlso _Fila.Cells("NombreCia").Value IsNot Nothing Then
                        _NombreCia = _Fila.Cells("NombreCia").Value.ToString().Trim()
                    End If
                Catch ex As Exception
                    _NombreCia = String.Empty
                End Try
            End If

            If String.IsNullOrWhiteSpace(_CodigoCia) AndAlso String.IsNullOrWhiteSpace(_NombreCia) Then
                Lbl_DatosCiaSeguros.Text = String.Empty
            Else
                Lbl_DatosCiaSeguros.Text = "Código: " & _CodigoCia & " - " & _NombreCia
            End If

        Catch ex As Exception
            ' Ignorar errores no críticos al mostrar datos
        End Try

    End Sub

    Private Sub Btn_Activar_Click(sender As Object, e As EventArgs) Handles Btn_Activar.Click

        Sb_ActivarDesactivar(Grilla_CisSeguros.CurrentRow, True)

    End Sub

    Private Sub Btn_Desactivar_Click(sender As Object, e As EventArgs) Handles Btn_Desactivar.Click

        Sb_ActivarDesactivar(Grilla_CisSeguros.CurrentRow, False)

    End Sub

    Sub Sb_ActivarDesactivar(_Fila As DataGridViewRow, _Activar As Boolean)

        If Not Fx_Tiene_Permiso(Me, "CfEnt039") Then
            Return
        End If

        Dim _CodEntidad_Cia As String = _Fila.Cells("CodEntidad_Cia").Value
        Dim _CodSucEntidad_Cia As String = _Fila.Cells("CodSucEntidad_Cia").Value
        Dim _MontoAsignado As Double = _Fila.Cells("MontoAsignado").Value
        Dim _NombreCia As String = _Fila.Cells("NombreCia").Value.ToString.Trim

        If MessageBoxEx.Show(Me, "¿Confirma que desea " & IIf(_Activar, "activar", "desactivar") & " esta compañía de seguros?" & vbCrLf &
                             "Compañia: " & _NombreCia,
                             IIf(_Activar, "Activar", "Desactivar") & " compañía de seguros",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_Sql = $"
Update {_Global_BaseBk}Zw_Entidad_CiaSeguro Set Activa = {Convert.ToInt32(_Activar)} 
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}' And CodEntidad_Cia = '{_CodEntidad_Cia}' And CodSucEntidad_Cia = '{_CodSucEntidad_Cia}'"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            If _Activar Then
                MontoCreditoTotal = MontoCreditoTotal + _MontoAsignado
            Else
                MontoCreditoTotal = MontoCreditoTotal - _MontoAsignado
            End If

            _Fila.Cells("Activa").Value = _Activar

            Sb_Aplicar_Color_Filas(Grilla_CisSeguros)

            Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "", 0, "", $" {(IIf(_Activar, "Activa", "Desactiva"))} compañía de seguros: {_NombreCia} ({_CodEntidad_Cia} - {_CodSucEntidad_Cia})",
                               "", "", _CodEntidad, _CodSucEntidad, False, "")

            MessageBoxEx.Show(Me, "Compañia de seguros " & IIf(_Activar, "activada", "desactivada") & " correctamente",
                              "Activar compañía de seguros",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ' Nueva rutina: aplica color de texto por fila según columna "Activa"
    Private Sub Sb_Aplicar_Color_Filas(Optional ByVal dgv As DataGridView = Nothing)
        Try
            If dgv Is Nothing Then
                dgv = Grilla_CisSeguros
            End If

            If dgv Is Nothing OrElse dgv.Rows Is Nothing Then
                Return
            End If

            For Each row As DataGridViewRow In dgv.Rows
                Try
                    Dim activaValor As Object = Nothing

                    ' Comprobar existencia de la columna "Activa" de manera segura
                    If row IsNot Nothing AndAlso row.DataGridView IsNot Nothing AndAlso row.DataGridView.Columns.Contains("Activa") Then
                        Dim idxActiva As Integer = row.DataGridView.Columns("Activa").Index
                        If idxActiva >= 0 AndAlso idxActiva < row.Cells.Count Then
                            activaValor = row.Cells(idxActiva).Value
                        End If
                    End If

                    Dim esActiva As Boolean = False
                    If activaValor IsNot Nothing AndAlso Not IsDBNull(activaValor) Then
                        Try
                            esActiva = CBool(activaValor)
                        Catch
                            esActiva = False
                        End Try
                    End If

                    Dim _Color As Color = Color.Black

                    If esActiva Then
                        If Global_Thema = Enum_Themas.Oscuro Then _Color = Color.White
                        'row.DefaultCellStyle.ForeColor = Color.Black
                    Else
                        row.DefaultCellStyle.ForeColor = Color.Gray
                    End If
                Catch
                    ' Ignorar filas problemáticas y continuar
                End Try
            Next
        Catch
            ' Ignorar cualquier error y no bloquear la UI
        End Try
    End Sub

    Private Sub Btn_MostrarDetalle_Click(sender As Object, e As EventArgs) Handles Btn_MostrarDetalle.Click

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow

        Dim _CodEntidad_Cia As String = _Fila.Cells("CodEntidad_Cia").Value
        Dim _CodSucEntidad_Cia As String = _Fila.Cells("CodSucEntidad_Cia").Value
        Dim _NombreCia As String = _Fila.Cells("NombreCia").Value

        Dim _Cabeza As String = Fx_ObtenerTextoCabeceraFila(_Fila, Grilla_CisSeguros)

        If _Cabeza <> "FCV" And _Cabeza <> "NVV" Then
            MessageBoxEx.Show(Me, "Solo se muestran documentos de tipo Factura y Nota de venta", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim _Tbl As DataTable = Fx_Trae_Tbl(_Cabeza, _CodEntidad_Cia, _CodSucEntidad_Cia)

        If Not CBool(_Tbl.Rows.Count) Then
            Beep()
            ToastNotification.Show(Me, "NO EXISTE INFORMACION",
                                  My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Return
        End If

        Dim Fm As New Frm_InfoEnt_Situacion_Documentos
        Fm.Text = "Compañia de seguros: " & _NombreCia
        Fm.TipoDocumentos = Frm_InfoEnt_Situacion_Documentos._TipoDoc.Doc_Venta
        Fm.Tabla = _Tbl
        Fm.Btn_Exportar_Excel.Visible = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Function Fx_Trae_Tbl(_Cabeza As String, _CodEntidad_Cia As String, _CodSucEntidad_Cia As String) As DataTable


        Select Case _Cabeza
            Case "FCV"

                Consulta_Sql = $"
SELECT 
    EDO.IDMAEEDO, EDO.EMPRESA, EDO.TIDO, EDO.NUDO, EDO.ENDO, EDO.SUENDO,
    EDO.MODO, EDO.TIMODO, EDO.TAMODO, EDO.ESPGDO, EDO.FEULVEDO,
    ROUND(EDO.VABRDO,2) AS VABRDO, ROUND(EDO.VAABDO,2) AS VAABDO,
    ROUND(EDO.VABRDO - EDO.VAABDO,2) AS SALDO,
    ROUND(EDO.VAIVARET,2) AS VAIVARET, ROUND(EDO.VAIVDO,2) AS VAIVDO,
    ROUND(EDO.VANEDO,2) AS VANEDO, EDO.BLOQUEAPAG, EDO.NUDONODEFI,
    CASE EDO.NUDONODEFI WHEN 1 THEN 'Documento en Transito' ELSE 'Definitivo' END AS DEFOTRANS,
    D.CodEntidad_Cia,
    D.CodSucEntidad_Cia
FROM MAEEDO AS EDO
INNER JOIN {_Global_BaseBk}Zw_Docu_Ent AS D
        ON D.Idmaeedo = EDO.IDMAEEDO
WHERE EDO.TIDO = 'FCV'
  AND EDO.ENDO = '{_CodEntidad}'
  AND EDO.SUENDO = '{_CodSucEntidad}'
  AND EDO.EMPRESA = {Mod_Empresa}
  AND EDO.ESPGDO = 'P'
  AND D.CodEntidad_Cia = '{_CodEntidad_Cia}'
  AND D.CodSucEntidad_Cia = '{_CodSucEntidad_Cia}';
"
            Case "NVV"

                Consulta_Sql = $"
SELECT 
    EDO.IDMAEEDO, EDO.EMPRESA, EDO.TIDO, EDO.NUDO, EDO.ENDO, EDO.SUENDO,
    EDO.MODO, EDO.TIMODO, EDO.TAMODO, EDO.ESPGDO, EDO.FEULVEDO,
    ROUND(EDO.VABRDO,2) AS VABRDO, ROUND(EDO.VAABDO,2) AS VAABDO,
    ROUND(EDO.VABRDO - EDO.VAABDO,2) AS SALDO,
    ROUND(EDO.VAIVARET,2) AS VAIVARET, ROUND(EDO.VAIVDO,2) AS VAIVDO,
    ROUND(EDO.VANEDO,2) AS VANEDO, EDO.BLOQUEAPAG, EDO.NUDONODEFI,
    CASE EDO.NUDONODEFI WHEN 1 THEN 'Documento en Transito' ELSE 'Definitivo' END AS DEFOTRANS,
    D.CodEntidad_Cia,
    D.CodSucEntidad_Cia
FROM MAEEDO AS EDO
INNER JOIN {_Global_BaseBk}Zw_Docu_Ent AS D
        ON D.Idmaeedo = EDO.IDMAEEDO
WHERE EDO.TIDO = 'NVV'
  AND EDO.ENDO = '{_CodEntidad}'
  AND EDO.SUENDO = '{_CodSucEntidad}'
  AND EDO.EMPRESA = {Mod_Empresa}
  AND EDO.ESDO = ''
  AND D.CodEntidad_Cia = '{_CodEntidad_Cia}'
  AND D.CodSucEntidad_Cia = '{_CodSucEntidad_Cia}';
"

            Case Else

                'NVVSOL — Detalle (sin MAEEDO, no aplica campos extra)
                Consulta_Sql = $"
SELECT 
    C.Id_DocEnc,
    C.TipoDoc,
    C.TotalBrutoDoc AS Monto,
    C.CodEntidad_Cia,
    C.CodSucEntidad_Cia
FROM {_Global_BaseBk}Zw_Casi_DocEnc AS C
INNER JOIN {_Global_BaseBk}Zw_Remotas AS R
        ON C.Id_DocEnc = R.Id_Casi_DocEnc
INNER JOIN {_Global_BaseBk}Zw_Remotas_En_Cadena_01_Enc AS E
        ON R.RCadena_Id_Enc = E.Id_Enc
WHERE C.Empresa = @Empresa
  AND C.CodEntidad = @ENDO
  AND C.CodSucEntidad = @SUENDO
  AND C.Stand_by = 0
  AND C.TipoDoc = 'NVV'
  AND C.UsaCiaSeguro = 1
  AND E.Estado = ''
  AND C.CodEntidad_Cia = @CodEntidad_Cia
  AND C.CodSucEntidad_Cia = @CodSucEntidad_Cia;
"

                'CHV — Detalle (no proviene de MAEEDO, no aplica campos extra)
                Consulta_Sql = $"
SELECT 
    Pce.IDMAEDPCE,
    Pce.FEEMDP,
    Pcd.VAASDP AS Monto,
    De.CodEntidad_Cia,
    De.CodSucEntidad_Cia
FROM MAEDPCE AS Pce
INNER JOIN MAEDPCD AS Pcd 
        ON Pcd.IDMAEDPCE = Pce.IDMAEDPCE
INNER JOIN {_Global_BaseBk}Zw_Docu_Ent AS De 
        ON De.Idmaeedo = Pcd.IDRST
INNER JOIN MAEEDO AS EDO 
        ON EDO.IDMAEEDO = De.Idmaeedo
WHERE Pce.ENDP = @ENDO
  AND Pce.TIDP = 'CHV'
  AND Pce.EMPRESA = @Empresa
  AND (Pce.ESPGDP = 'P' OR Pce.ESPGDP = 'R')
  AND De.Tido = 'FCV'
  AND De.UsaCiaSeguro = 1
  AND EDO.ENDO = @ENDO
  AND EDO.SUENDO = @SUENDO
  AND De.CodEntidad_Cia = @CodEntidad_Cia
  AND De.CodSucEntidad_Cia = @CodSucEntidad_Cia;
"

                'COVSS — Detalle (MAEEDO + campos completos)
                Consulta_Sql = $"
SELECT 
    EDO.IDMAEEDO, EDO.EMPRESA, EDO.TIDO, EDO.NUDO, EDO.ENDO, EDO.SUENDO,
    EDO.MODO, EDO.TIMODO, EDO.TAMODO, EDO.ESPGDO, EDO.FEULVEDO,
    ROUND(EDO.VABRDO,2) AS VABRDO, ROUND(EDO.VAABDO,2) AS VAABDO,
    ROUND(EDO.VABRDO - EDO.VAABDO,2) AS SALDO,
    ROUND(EDO.VAIVARET,2) AS VAIVARET, ROUND(EDO.VAIVDO,2) AS VAIVDO,
    ROUND(EDO.VANEDO,2) AS VANEDO, EDO.BLOQUEAPAG, EDO.NUDONODEFI,
    CASE EDO.NUDONODEFI WHEN 1 THEN 'Documento en Transito' ELSE 'Definitivo' END AS DEFOTRANS,
    BEn.CodEntidad_Cia,
    BEn.CodSucEntidad_Cia,
    Monto_Pesos = ROUND(EDO.VABRDO * M.VAMO,0)
FROM MAEEDO EDO
INNER JOIN {_Global_BaseBk}Zw_Docu_Ent BEn 
        ON BEn.Idmaeedo = EDO.IDMAEEDO
OUTER APPLY (
    SELECT TOP 1 VAMO
    FROM MAEMO
    WHERE KOMO = EDO.MODO
    ORDER BY IDMAEMO DESC
) M
WHERE BEn.Tido = 'COV'
  AND BEn.SobreStock = 1
  AND EDO.ESDO = ''
  AND BEn.UsaCiaSeguro = 1
  AND EDO.ENDO = @ENDO
  AND EDO.SUENDO = @SUENDO
  AND EDO.EMPRESA = @Empresa
  AND BEn.CodEntidad_Cia = @CodEntidad_Cia
  AND BEn.CodSucEntidad_Cia = @CodSucEntidad_Cia;

"

                'COVSSPP — Detalle (con filtro de compañía)
                Consulta_Sql = $"
SELECT 
    C.Id_DocEnc,
    C.TipoDoc,
    C.TotalBrutoDoc,
    C.CodEntidad_Cia,
    C.CodSucEntidad_Cia,
    Monto_Pesos = ROUND(C.TotalBrutoDoc * M.VAMO,0)
FROM {_Global_BaseBk}Zw_Casi_DocEnc AS C
OUTER APPLY (
    SELECT TOP 1 VAMO
    FROM MAEMO
    WHERE KOMO = C.Moneda_Doc
    ORDER BY IDMAEMO DESC
) M
WHERE C.TipoDoc = 'COV'
  AND C.UsaCiaSeguro = 1
  AND C.Stand_by = 0
  AND C.CodEntidad = @ENDO
  AND C.CodSucEntidad = @SUENDO
  AND C.Empresa = @Empresa
  AND C.CodEntidad_Cia = @CodEntidad_Cia
  AND C.CodSucEntidad_Cia = @CodSucEntidad_Cia;
"


                Return Nothing
        End Select

        Dim _Tbl As DataTable

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Return _Tbl

    End Function

    Private Sub Btn_VerFCV_Click(sender As Object, e As EventArgs) Handles Btn_VerFCV.Click

        'If Not CBool(Grilla_CisSeguros.RowCount) Then
        '    MessageBoxEx.Show(Me, "No hay datos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If

        Dim _Fila As DataGridViewRow = Grilla_CisSeguros.CurrentRow

        'Dim _CodEntidad_Cia As String = _Fila.Cells("CodEntidad_Cia").Value
        'Dim _CodSucEntidad_Cia As String = _Fila.Cells("CodSucEntidad_Cia").Value
        'Dim _NombreCia As String = _Fila.Cells("NombreCia").Value

        Dim _Cabeza As String = Fx_ObtenerTextoCabeceraFila(_Fila, Grilla_CisSeguros)

        Consulta_Sql = $"
DECLARE @ENDO     VARCHAR(20) = '{_CodEntidad}'
DECLARE @SUENDO   VARCHAR(20) = '{_CodSucEntidad}'
DECLARE @Empresa  CHAR(2)     = '{Mod_Empresa}'

SELECT 
    EDO.TIDO,
    EDO.NUDO,
    EDO.ENDO,
    EDO.SUENDO,
    EDO.FEULVEDO,
    ROUND(EDO.VABRDO,2) AS VABRDO,
    ROUND(EDO.VABRDO - EDO.VAABDO,2) AS SALDO,

    D.CodEntidad_Cia,
    D.CodSucEntidad_Cia,

    CASE 
        WHEN ISNULL(D.CodEntidad_Cia,'') = '' THEN 'Sin Asignar'
        ELSE 'Asignado'
    END AS Estado_Cia_Seguro,

    -- Nombre de la compañía desde MAEEN
    ISNULL(ME.NOKOEN, 'SIN NOMBRE') AS Nombre_Cia_Seguro

FROM MAEEDO AS EDO
INNER JOIN {_Global_BaseBk}Zw_Docu_Ent AS D
        ON D.Idmaeedo = EDO.IDMAEEDO

LEFT JOIN MAEEN AS ME
       ON ME.KOEN = D.CodEntidad_Cia
      AND ME.SUEN = D.CodSucEntidad_Cia

WHERE EDO.TIDO = 'FCV'
  AND EDO.ENDO = @ENDO
  AND EDO.SUENDO = @SUENDO
  AND EDO.EMPRESA = @Empresa
  AND EDO.ESPGDO = 'P';
"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Detalle_FCV_")

    End Sub

    Private Sub Btn_InfFincred_Click(sender As Object, e As EventArgs) Handles Btn_InfFincred.Click

        Dim _Msg1 = "Vender con crédito FINCRED"
        Dim _Msg2 = vbCrLf & "¿Confirma usar el crédito FINCRED?" & vbCrLf

        If Not Fx_Confirmar_Lectura(_Msg1.ToUpper, _Msg2.ToUpper, eTaskDialogIcon.ShieldHelp) Then
            Return
        End If

        'If MessageBoxEx.Show(Me, "¿Confirma usar el crédito FINCRED?", "Vender con crédito FINCRED",
        '                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
        '    Return
        'End If

        Me.UsarCreditoFINCRED = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub
End Class
