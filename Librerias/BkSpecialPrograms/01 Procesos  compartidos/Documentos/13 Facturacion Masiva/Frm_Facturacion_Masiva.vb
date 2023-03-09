Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_Facturacion_Masiva

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tido = "FCV"

    Dim _Cl_Facturacion As New Clas_Facturacion_Masiva
    Dim _Dv As New DataView

    Dim _RowEntidadBuscar As DataRow

    Public Property Cl_Facturacion As Clas_Facturacion_Masiva
        Get
            Return _Cl_Facturacion
        End Get
        Set(value As Clas_Facturacion_Masiva)
            _Cl_Facturacion = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

    End Sub

    Private Sub Frm_Facturacion_Masiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_Fecha_Emision.Value = FechaDelServidor()

        Input_Monto_Max_CRV_FacMasiva.Value = _Global_Row_Configuracion_General.Item("Monto_Max_CRV_FacMasiva")
        Input_Monto_Max_CRV_FacMasiva.Visible = False
        Chk_Pagar_Saldos_CRV.Visible = False

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint


        Dim _Arr_Tipo_Entidad(,) As String = {{"", "Todas"},
                                             {"Contado", "Contado"},
                                             {"Credito", "Crédito"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, ComboBoxEx1)
        ComboBoxEx1.SelectedValue = ""

        Dtp_BuscaXFechaEmision.Value = #1/1/0001 12:00:00 AM#
        Dtp_BuscaXFechaVencimiento.Value = #1/1/0001 12:00:00 AM#

        Sb_Llenar_Grilla()

        Circular_Progres_Run.IsRunning = True

        Sb_Color_Botones_Barra(Bar1)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'"
        Dim _RowFormato_Mod As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Guardar_PDF_Auto As Boolean = _RowFormato_Mod.Item("Guardar_PDF_Auto")

        Dim _Ruta_PDF = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Ruta_PDF",
                                      "Empresa = '" & ModEmpresa & "' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "'")

        If _Guardar_PDF_Auto Then

            If String.IsNullOrEmpty(_Ruta_PDF) Or Not Directory.Exists(_Ruta_PDF) Then

                MessageBoxEx.Show(Me, "Esta configurada la grabación de PDF automático para esta modalidad," & vbCrLf &
                              "sin embargo falta la configuración de la carpeta de salida para grabar estos PDF." & vbCrLf & vbCrLf &
                              "Para configurar esta operación debe hacer lo siguiente:" & vbCrLf & vbCrLf &
                              "-> Clic en OK o cerrar" & vbCrLf &
                              "-> En el formulario de facturación masiva debe presionar el botón de la AMPOLLETA (Opciones especiales)" & vbCrLf &
                              "-> Configuración impresora de salida" & vbCrLf &
                              "-> Directorio de salida para PDF automático", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        End If

        Me.ActiveControl = Txt_BuscaXNudoNVV

    End Sub

    Public Sub Sb_Llenar_Grilla()

        _Dv.Table = _Cl_Facturacion.Ds_Doc_Facturar.Tables("Table")

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 25
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").HeaderText = "SD"
            .Columns("SUDO").Width = 35
            .Columns("SUDO").Visible = True
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 70
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 60
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFUDO").HeaderText = "Resp"
            .Columns("KOFUDO").Width = 35
            .Columns("KOFUDO").Visible = True
            .Columns("KOFUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Width = 40
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 200
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VABRDO").Width = 70
            .Columns("VABRDO").HeaderText = "Monto"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VADP").Width = 70
            .Columns("VADP").HeaderText = "Abonado"
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VADP").Visible = True
            .Columns("VADP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OBDO").HeaderText = "Observaciones"
            .Columns("OBDO").Width = 200
            .Columns("OBDO").Visible = True
            .Columns("OBDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TipoVenta").HeaderText = "T.Venta"
            .Columns("TipoVenta").Width = 60
            .Columns("TipoVenta").Visible = True
            .Columns("TipoVenta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("CRV").HeaderText = "Usar CRV"
            '.Columns("CRV").Width = 35
            '.Columns("CRV").Visible = True
            '.Columns("CRV").ReadOnly = False
            '.Columns("CRV").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("SALDO_CRV").Width = 80
            '.Columns("SALDO_CRV").HeaderText = "Saldo CRV"
            '.Columns("SALDO_CRV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("SALDO_CRV").DefaultCellStyle.Format = "$ ###,##0.##"
            '.Columns("SALDO_CRV").Visible = True
            '.Columns("SALDO_CRV").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEER").HeaderText = "F.Despacho"
            .Columns("FEER").Width = 70
            .Columns("FEER").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEER").Visible = True
            .Columns("FEER").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEULVEDO").HeaderText = "F.Vencimiento"
            .Columns("FEULVEDO").Width = 70
            .Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HORA").HeaderText = "Hora"
            .Columns("HORA").Width = 50
            .Columns("HORA").Visible = True
            .Columns("HORA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Facturado").HeaderText = "Fac.?"
            .Columns("Facturado").Width = 35
            .Columns("Facturado").Visible = True
            .Columns("Facturado").ReadOnly = False
            .Columns("Facturado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO_FCV").HeaderText = "Nro. Factura"
            .Columns("NUDO_FCV").Width = 90
            .Columns("NUDO_FCV").Visible = True
            .Columns("NUDO_FCV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VAABDO_FCV").Width = 70
            .Columns("VAABDO_FCV").HeaderText = "Abonado a FCV"
            .Columns("VAABDO_FCV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABDO_FCV").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VAABDO_FCV").Visible = True
            .Columns("VAABDO_FCV").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Call Grilla_CellEnter(Nothing, Nothing)

    End Sub

    Private Sub Btn_Facturar_Click(sender As Object, e As EventArgs) Handles Btn_Facturar.Click
        Sb_Facturar_Masivamente()
    End Sub

    Sub Sb_Facturar_Masivamente()

        Dim _Contador = 0
        _Cancelar_Proceso = False

        Dim _FechaEmision As Date = Dtp_Fecha_Emision.Value

        If Not Fx_Revisar_Taza_Cambio(Me, _FechaEmision) Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma la fecha de las facturas?" & vbCrLf & vbCrLf &
                             "Fecha: " & FormatDateTime(_FechaEmision, DateFormat.ShortDate), "Confirmar fecha de emisión",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try

            Sb_Habilitar_Controles(False)

            For Each _Fila As DataRow In _Cl_Facturacion.Ds_Doc_Facturar.Tables(0).Rows

                Dim _Estado = _Fila.RowState

                If _Estado <> DataRowState.Deleted Then

                    If _Fila.Item("Chk") Then
                        _Contador += 1
                    End If

                End If

            Next

            If _Contador = 0 Then
                MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Circular_Progres_Porcentaje.Visible = True
            Circular_Progres_Contador.Visible = True
            Circular_Progres_Run.Visible = True

            Circular_Progres_Porcentaje.Maximum = 100
            Circular_Progres_Contador.Maximum = _Contador

            Circular_Progres_Porcentaje.Value = 0
            Circular_Progres_Contador.Value = 0

            _Contador = 0

            For Each _Fila As DataRow In _Cl_Facturacion.Ds_Doc_Facturar.Tables(0).Rows

                Dim _Estado = _Fila.RowState

                If _Estado <> DataRowState.Deleted Then

                    If _Fila.Item("Chk") Then

                        Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
                        Dim _Fecha_Emision As Date = _FechaEmision
                        Dim _Idmaeedo_Fcv As Integer

                        Dim _Nudo_Nvv As String = _Fila.Item("NUDO")

                        Lbl_Status.Text = "Facturando Nota de venta Nro: " & _Nudo_Nvv

                        System.Windows.Forms.Application.DoEvents()

                        If _Cancelar_Proceso Then
                            Throw New System.Exception("Acción cancelada por el usuario")
                        End If

                        _Idmaeedo_Fcv = Fx_Crear_Documento_Desde_Otro_Automaticamente(Me, "FCV", _Idmaeedo, _Fecha_Emision)

                        If CBool(_Idmaeedo_Fcv) Then

                            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Fcv
                            Dim _Row_Factura As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            _Fila.Item("Facturado") = True
                            _Fila.Item("IDMAEEDO_FCV") = _Row_Factura.Item("IDMAEEDO")
                            _Fila.Item("NUDO_FCV") = _Row_Factura.Item("NUDO")
                            _Fila.Item("Fecha_Emision") = _Row_Factura.Item("FEEMDO")
                            _Fila.Item("VABRDO_FCV") = _Row_Factura.Item("VABRDO")

                            Dim _Idmaeedo_NVV As Integer = _Fila.Item("IDMAEEDO")
                            Dim _Idmaedpce As Integer = _Fila.Item("IDMAEDPCE")
                            Dim _Crv As Boolean = _Fila.Item("CRV")
                            Dim _Saldo_Crv As Double = _Fila.Item("SALDO_CRV")

                            If CBool(_Idmaeedo_Fcv) And Chk_Pagar_Documentos.Checked Then

                                Consulta_sql = "Select *,VADP-VAASDP As SALDO From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
                                Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                                If Not IsNothing(_Row_Maedpce) Then

                                    Dim _Tidp As String = _Row_Maedpce.Item("TIDP")
                                    Dim _Saldo_Pago As Double = _Row_Maedpce.Item("SALDO")

                                    _Fila.Item("IDMAEDPCE") = _Idmaedpce
                                    _Fila.Item("VADP") = _Row_Maedpce.Item("VADP")
                                    _Fila.Item("VAASDP") = _Row_Maedpce.Item("VAASDP")
                                    _Fila.Item("SALDO") = _Saldo_Pago

                                    Dim _Tido = "FCV"
                                    Dim _Nudo = _Fila.Item("NUDO_FCV")

                                    Lbl_Status.Text = "Pagando Factura Nro: " & _Nudo
                                    System.Windows.Forms.Application.DoEvents()

                                    ' Pago con documento asociado a NVV

                                    Dim Fm As New Frm_Pagos_Documentos("")
                                    Fm.Sb_Nuevo_Documento()

                                    If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                                        Dim _FilaPg As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                                        _FilaPg.Cells("TIDP").Value = _Tidp
                                        _FilaPg.Cells("VADP").Value = _Saldo_Pago

                                        _FilaPg.Cells("IDMAEDPCE").Value = _Row_Maedpce.Item("IDMAEDPCE")
                                        _FilaPg.Cells("EMDP").Value = _Row_Maedpce.Item("EMDP")
                                        _FilaPg.Cells("SUEMDP").Value = _Row_Maedpce.Item("SUEMDP")
                                        _FilaPg.Cells("CUDP").Value = _Row_Maedpce.Item("CUDP")
                                        _FilaPg.Cells("NUCUDP").Value = _Row_Maedpce.Item("NUCUDP")
                                        _FilaPg.Cells("CUOTAS").Value = _Row_Maedpce.Item("CUOTAS")

                                        _FilaPg.Cells("FEEMDP").Value = _Row_Maedpce.Item("FEEMDP")
                                        _FilaPg.Cells("FEVEDP").Value = _Row_Maedpce.Item("FEVEDP")

                                        Fm.Sb_Sumar_Totales()
                                        Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                                        _Fila.Item("VAABDO_FCV") += _Saldo_Pago

                                    End If

                                    If _Cancelar_Proceso Then
                                        Throw New System.Exception("Acción cancelada por el usuario")
                                    End If

                                    If Chk_Pagar_Saldos_CRV.Checked And _Crv And _Saldo_Crv <= Input_Monto_Max_CRV_FacMasiva.Value Then

                                        Lbl_Status.Text = "Pagando Saldo de Factura Nro: " & _Nudo & " con CRV"
                                        System.Windows.Forms.Application.DoEvents()

                                        Dim _Idmaedpce_Crv = 0

                                        Fm.Sb_Nuevo_Documento()

                                        If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                                            Dim _FilaPg As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                                            _FilaPg.Cells("TIDP").Value = "CRV"
                                            _FilaPg.Cells("VADP").Value = _Saldo_Crv

                                            _FilaPg.Cells("IDMAEDPCE").Value = 0
                                            _FilaPg.Cells("EMDP").Value = _Row_Maedpce.Item("EMDP")
                                            _FilaPg.Cells("SUEMDP").Value = _Row_Maedpce.Item("SUEMDP")
                                            _FilaPg.Cells("CUDP").Value = _Row_Maedpce.Item("CUDP")
                                            _FilaPg.Cells("NUCUDP").Value = 0
                                            _FilaPg.Cells("CUOTAS").Value = 0

                                            _FilaPg.Cells("FEEMDP").Value = _Row_Maedpce.Item("FEEMDP")
                                            _FilaPg.Cells("FEVEDP").Value = _Row_Maedpce.Item("FEVEDP")

                                            Fm.Sb_Sumar_Totales()
                                            Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce_Crv)

                                            _Fila.Item("VAABDO_FCV") += _Saldo_Crv

                                        End If

                                    End If

                                    Fm.Dispose()

                                End If

                            End If

                            If Chk_Imprimir.Checked Then
                                Sb_Imprimir_Documento(Me, _Idmaeedo_Fcv, False, Modalidad)
                            End If

                            Dim _Error_PDF As String

                            _Error_PDF = Fx_Guargar_PDF_Automaticamente_Por_Doc_Modalidad(_Idmaeedo_Fcv)

                        End If

                        _Contador += 1
                        Circular_Progres_Porcentaje.Value = ((_Contador * 100) / Circular_Progres_Contador.Maximum) 'Mas
                        Circular_Progres_Contador.Value += 1

                        System.Windows.Forms.Application.DoEvents()

                    End If

                End If

                If _Cancelar_Proceso Then
                    Throw New System.Exception("Acción cancelada por el usuario")
                End If

            Next

            MessageBoxEx.Show(Me, "Fin Proceso", "Facturación Masiva", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBoxEx.Show(Me, ex.Message, "Bakapp", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Finally

            Circular_Progres_Porcentaje.Visible = False
            Circular_Progres_Contador.Visible = False
            Circular_Progres_Run.Visible = False
            Lbl_Status.Text = "Status"

            Sb_Habilitar_Controles(True)

            Me.Refresh()

        End Try

    End Sub

    Sub Sb_Habilitar_Controles(_Habilitar As Boolean)

        Btn_Facturar.Enabled = _Habilitar
        Btn_Opciones_Especiales.Enabled = _Habilitar
        Btn_Cancelar.Visible = Not _Habilitar

        Chk_Imprimir.Enabled = _Habilitar
        Chk_Marcar_todo.Enabled = _Habilitar
        Chk_Pagar_Documentos.Enabled = _Habilitar
        Chk_Pagar_Saldos_CRV.Enabled = _Habilitar

        Dtp_Fecha_Emision.Enabled = _Habilitar
        Grilla.Enabled = _Habilitar

        Me.ControlBox = _Habilitar

        Me.Refresh()

    End Sub

    Function Fx_Crear_Documento_Desde_Otro_Automaticamente(_Formulario As Form,
                                                           _Tido_Destino As String,
                                                           _Idmaeedo_Origen As Integer,
                                                           _Fecha_Emision As DateTime) As Integer

        Dim _New_Idmaeedo As Integer

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, Modalidad, _Tido_Destino, True)

        If Not IsNothing(_RowFormato) Then

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Documento) Then

                Dim _Meardo = _Row_Documento.Item("MEARDO")
                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                If Fx_Revisar_Taza_Cambio(_Formulario) Then

                    If Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo_Origen) Then

                        Dim _Empresa As String = ModEmpresa
                        Dim _Sucursal As String = ModSucursal
                        Dim _Bodega As String = ModBodega

                        Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega

                        If Not Fx_Tiene_Permiso(_Formulario, _Permiso, , True) Then

                            Dim _Bod = _Global_Row_Configuracion_Estacion.Item("NOKOBO")
                            MessageBoxEx.Show(_Formulario, "NO ESTA AUTORIZADO PARA EFECTUAR DOCUMENTOS DESDE LA BODEGA DE ESTA MODALIDAD" & vbCrLf & vbCrLf &
                                              "BODEGA: " & _Bodega & " - " & _Bod,
                                              "VALIDACION",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)
                            Return 0

                        End If

                        If Fx_Tiene_Permiso(_Formulario, _Permiso) Then

                            Dim _CampoPrecio As String

                            If _Meardo = "N" Then ' Neto
                                _CampoPrecio = "PPPRNE"
                            Else ' Bruto
                                _CampoPrecio = "PPPRBR"
                            End If

                            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen & "
                                            Select *,CAse When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End As 'Cantidad',
                                            CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori',
                                            Case WHEN UDTRPR = 1 Then " & _CampoPrecio & " Else " & _CampoPrecio & "*RLUDPR End AS 'Precio',
                                            0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                                            From MAEDDO  With ( NOLOCK ) 
                                            Where IDMAEEDO = " & _Idmaeedo_Origen & "  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                                            Order by IDMAEEDO,IDMAEDDO 
                                            Select * From MAEIMLI
                                            Where IDMAEEDO = " & _Idmaeedo_Origen & " 
                                            Select * From MAEDTLI
                                            Where IDMAEEDO = " & _Idmaeedo_Origen & " 
                                            Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Origen

                            'Falta revisar el campo SUBTIDO, ya que al parecer se guardan datos dependiendo del tipo de FCC por ejemplo si tiene derecho a credito fiscal
                            'Falta campo FECHATRIB = Fecha de ingreso

                            ' SUBTIDO
                            '-- 001 Sin derecho a credito fiscal y Sin documento contiene activo fijo
                            '-- 000 Documento contiene activo fijo y Sin derecho a credito fiscal
                            '-- 101 Conderecho a credito fiscal y documento contiene activo fijo
                            '-- 100 Con derecho a credito fiscal y sin documento contiene activo fijo
                            '-- '' -- No incluye este documento en el libro de compras 

                            Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                            Dim Fm_Post As New Frm_Formulario_Documento("FCV", csGlobales.Enum_Tipo_Documento.Venta, False)
                            Fm_Post.Sb_Limpiar(Modalidad)
                            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)
                            Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False)
                            _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
                            Fm_Post.Sb_Activar_Orden_De_Despacho(_New_Idmaeedo)
                            Fm_Post.Dispose()

                        End If

                    Else

                        MessageBoxEx.Show(_Formulario, "Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente", "Documento cerrado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)

                    End If

                End If

            End If

        Else

            MessageBoxEx.Show(_Formulario, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                          "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        Return _New_Idmaeedo

    End Function

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Sb_Ver_Documento()

    End Sub

    Sub Sb_Ver_Documento()

        Me.Enabled = False

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Idmaeedo As Integer
            Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

            If _Cabeza = "VADP" Then

                If CBool(_Idmaedpce) Then
                    Dim Fm_P As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
                    Fm_P.ShowDialog(Me)
                    Fm_P.Dispose()
                    Return
                End If

            End If

            If _Cabeza = "NUDO" Then
                _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
            End If

            If _Cabeza = "NUDO_FCV" Then
                _Idmaeedo = _Fila.Cells("IDMAEEDO_FCV").Value
            End If

            If CBool(_Idmaeedo) Then

                Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Chk_Marcar_todo_Click(sender As Object, e As EventArgs) Handles Chk_Marcar_todo.Click

        Lbl_Total_Facturar.Tag = 0

        Dim _Tbl As DataTable = _Dv.Table

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Not Chk_Marcar_todo.Checked
            If _Fila.Cells("Chk").Value Then
                Lbl_Total_Facturar.Tag += _Fila.Cells("VABRDO").Value
            End If
        Next

        'For Each _Fila As DataRow In _Cl_Facturacion.Ds_Doc_Facturar.Tables(0).Rows
        '    _Fila.Item("Chk") = Not Chk_Marcar_todo.Checked
        '    If _Fila.Item("Chk") Then
        '        Lbl_Total_Facturar.Tag += _Fila.Item("VABRDO")
        '    End If
        'Next

        Lbl_Total_Facturar.Text = FormatCurrency(Lbl_Total_Facturar.Tag, 0)

    End Sub

    Private Sub Btn_Traer_Pago_CtaCte_Click(sender As Object, e As EventArgs) Handles Btn_Traer_Pago_CtaCte.Click

        Dim _Contador = 0

        For Each _Fila As DataRow In _Cl_Facturacion.Ds_Doc_Facturar.Tables(0).Rows

            If _Fila.Item("Chk") Then
                _Contador += 1
            End If

        Next

        If _Contador = 0 Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Circular_Progres_Porcentaje.Visible = True
        Circular_Progres_Contador.Visible = True
        Circular_Progres_Run.Visible = True

        Circular_Progres_Porcentaje.Maximum = 100
        Circular_Progres_Contador.Maximum = _Contador

        Circular_Progres_Porcentaje.Value = 0
        Circular_Progres_Contador.Value = 0

        For Each _Fila As DataRow In _Cl_Facturacion.Ds_Doc_Facturar.Tables(0).Rows

            Dim _Idmaeedo_NVV As Integer = _Fila.Item("IDMAEEDO")
            Dim _Idmaeedo_Fcv As Integer = _Fila.Item("IDMAEEDO_FCV")
            Dim _Idmaedpce As Integer = _Fila.Item("IDMAEDPCE")
            Dim _Crv As Boolean = _Fila.Item("CRV")
            Dim _Saldo_Crv As Double = _Fila.Item("SALDO_CRV")

            If CBool(_Idmaeedo_Fcv) Then

                Consulta_sql = "Select *,VADP-VAASDP As SALDO From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
                Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Maedpce) Then

                    'Dim _Idmaedpce As Integer = _Row_Maedpce.Item("IDMAEDPCE")
                    Dim _Tidp As String = _Row_Maedpce.Item("TIDP")
                    Dim _Saldo_Pago As Double = _Row_Maedpce.Item("SALDO")

                    _Fila.Item("IDMAEDPCE") = _Idmaedpce
                    _Fila.Item("VADP") = _Row_Maedpce.Item("VADP")
                    _Fila.Item("VAASDP") = _Row_Maedpce.Item("VAASDP")
                    _Fila.Item("SALDO") = _Saldo_Pago

                    Dim _Tido = "FCV"
                    Dim _Nudo = _Fila.Item("NUDO_FCV")

                    Lbl_Status.Text = "Pagando Factura Nro: " & _Nudo

                    System.Windows.Forms.Application.DoEvents()

                    ' Pago con documento asociado a NVV

                    Dim Fm As New Frm_Pagos_Documentos("")
                    Fm.Sb_Nuevo_Documento()

                    If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                        Dim _FilaPg As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                        _FilaPg.Cells("TIDP").Value = _Tidp
                        _FilaPg.Cells("VADP").Value = _Saldo_Pago

                        _FilaPg.Cells("IDMAEDPCE").Value = _Row_Maedpce.Item("IDMAEDPCE")
                        _FilaPg.Cells("EMDP").Value = _Row_Maedpce.Item("EMDP")
                        _FilaPg.Cells("SUEMDP").Value = _Row_Maedpce.Item("SUEMDP")
                        _FilaPg.Cells("CUDP").Value = _Row_Maedpce.Item("CUDP")
                        _FilaPg.Cells("NUCUDP").Value = _Row_Maedpce.Item("NUCUDP")
                        _FilaPg.Cells("CUOTAS").Value = _Row_Maedpce.Item("CUOTAS")

                        _FilaPg.Cells("FEEMDP").Value = _Row_Maedpce.Item("FEEMDP")
                        _FilaPg.Cells("FEVEDP").Value = _Row_Maedpce.Item("FEVEDP")

                        Fm.Sb_Sumar_Totales()
                        Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                    End If

                    If _Crv And CBool(_Saldo_Crv) Then

                        Dim _Idmaedpce_Crv = 0

                        Fm.Sb_Nuevo_Documento()

                        If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                            Dim _FilaPg As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                            _FilaPg.Cells("TIDP").Value = "CRV"
                            _FilaPg.Cells("VADP").Value = _Saldo_Crv

                            _FilaPg.Cells("IDMAEDPCE").Value = 0
                            _FilaPg.Cells("EMDP").Value = _Row_Maedpce.Item("EMDP")
                            _FilaPg.Cells("SUEMDP").Value = _Row_Maedpce.Item("SUEMDP")
                            _FilaPg.Cells("CUDP").Value = _Row_Maedpce.Item("CUDP")
                            _FilaPg.Cells("NUCUDP").Value = 0
                            _FilaPg.Cells("CUOTAS").Value = 0

                            _FilaPg.Cells("FEEMDP").Value = _Row_Maedpce.Item("FEEMDP")
                            _FilaPg.Cells("FEVEDP").Value = _Row_Maedpce.Item("FEVEDP")

                            Fm.Sb_Sumar_Totales()
                            Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce_Crv)

                            '_Contador += 1
                            'Circular_Progres_Porcentaje.Value = ((_Contador * 100) / Circular_Progres_Contador.Maximum) 'Mas
                            'Circular_Progres_Contador.Value += 1

                            'System.Windows.Forms.Application.DoEvents()

                        End If

                    End If

                    _Contador += 1
                    Circular_Progres_Porcentaje.Value = ((_Contador * 100) / Circular_Progres_Contador.Maximum) 'Mas
                    Circular_Progres_Contador.Value += 1

                    System.Windows.Forms.Application.DoEvents()

                    ' Pago Saldo CRV

                    Fm.Dispose()

                End If

            End If

        Next

        Circular_Progres_Porcentaje.Visible = False
        Circular_Progres_Contador.Visible = False
        Circular_Progres_Run.Visible = False

        Lbl_Status.Text = "Status"

        MessageBoxEx.Show(Me, "Fin Proceso", "Facturación Masiva", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        If MessageBoxEx.Show(Me, "¿Desea cancelar esta accíón?", "Cancelar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _Cancelar_Proceso = True
            Btn_Cancelar.Enabled = False
            Me.Refresh()
        End If

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Nokoen As String = _Fila.Cells("NOKOEN").Value.ToString.Trim
            Dim _Obdo As String = Replace(_Fila.Cells("OBDO").Value.ToString.Trim, vbCrLf, " ")
            Txt_Observaciones.Text = "Razón social: " & _Nokoen & ", Observaciones: " & _Obdo
        Catch ex As Exception
            Txt_Observaciones.Text = String.Empty
        End Try
    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Delete Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _IsNewRow As Boolean = _Fila.IsNewRow

            If Not _IsNewRow Then

                If MessageBoxEx.Show(Me, "¿Confirma quitar la nota de venta del tratamiento?", "Quitar nota de venta",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Config_Impresora_Local_Click(sender As Object, e As EventArgs) Handles Btn_Config_Impresora_Local.Click

        If Fx_Tiene_Permiso(Me, "Doc00058") Then

            Dim _Ruta_Impresora = AppPath() & "\Data\" & RutEmpresa & "\Configuracion_Local"

            If Not Directory.Exists(_Ruta_Impresora) Then
                System.IO.Directory.CreateDirectory(_Ruta_Impresora)
            End If

            Dim Fm As New Frm_Seleccionar_Impresoras("")  'Frm_Impresoras
            Dim Archivo As String

            Archivo = _Ruta_Impresora & "\Imp_" & _Tido & ".xml"

            If System.IO.File.Exists(Archivo) Then
                Kill(Archivo)
            End If

            Fm.ShowDialog(Me)

            Dim _DtsConfig As New DatosBakApp

            Dim NewFila As DataRow

            NewFila = _DtsConfig.Tables("Conf_Impresora_Local").NewRow
            NewFila.Item("Modulo") = "Bkpost"
            NewFila.Item("Impresora") = Fm.Pro_Impresora_Seleccionada
            _DtsConfig.Tables("Conf_Impresora_Local").Rows.Add(NewFila)

            _DtsConfig.WriteXml(Archivo)
            _DtsConfig.Clear()

            If Not String.IsNullOrEmpty(Fm.Pro_Impresora_Seleccionada) Then
                MessageBoxEx.Show(Me, "Impresora seleccionada: " & Fm.Pro_Impresora_Seleccionada, "Impresora",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Config_Impresora_Diablito_Click(sender As Object, e As EventArgs) Handles Btn_Config_Impresora_Diablito.Click

        Dim Fm As New Frm_Imp_Diablito_X_Est(FUNCIONARIO, True)
        Fm.Tido = _Tido
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Impresion_PDF_Click(sender As Object, e As EventArgs) Handles Btn_Impresion_PDF.Click
        Sb_Configuracion_Salida_PDF(Me, _Tido)
    End Sub

    Private Sub Btn_Opciones_Especiales_Click(sender As Object, e As EventArgs) Handles Btn_Opciones_Especiales.Click
        ShowContextMenu(Menu_Contextual_Opciones_Especiales)
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Lbl_Total_Facturar.Tag = 0

        For Each _Fila As DataRow In _Cl_Facturacion.Ds_Doc_Facturar.Tables(0).Rows

            If _Fila.Item("Chk") Then
                Lbl_Total_Facturar.Tag += _Fila.Item("VABRDO")
            End If

        Next

        Lbl_Total_Facturar.Text = FormatCurrency(Lbl_Total_Facturar.Tag, 0)

    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click

        Dim _Condicion_Campos, _Condicion_Valores As String

        _Condicion_Campos = "NUDO Like '%{0}%'"

        If Not String.IsNullOrEmpty(Txt_BuscaXEntidad.Text) Then
            _Condicion_Campos += " And ENDO+SUENDO = '{1}'"
        End If

        Dim _Entidad = String.Empty

        If Not IsNothing(_RowEntidadBuscar) Then
            _Entidad = _RowEntidadBuscar.Item("KOEN") & _RowEntidadBuscar.Item("SUEN")
        End If

        If Dtp_BuscaXFechaEmision.Value <> #1/1/0001 12:00:00 AM# Then
            _Condicion_Campos += " And FEEMDO = '{2}'"
        End If

        If Dtp_BuscaXFechaVencimiento.Value <> #1/1/0001 12:00:00 AM# Then
            _Condicion_Campos += " And FEULVEDO = '{3}'"
        End If

        If Not String.IsNullOrEmpty(ComboBoxEx1.SelectedValue) Then
            _Condicion_Campos += " And TipoVenta = '{4}'"
        End If

        _Dv.RowFilter = String.Format(_Condicion_Campos,
                                      Txt_BuscaXNudoNVV.Text,
                                      _Entidad,
                                      Dtp_BuscaXFechaEmision.Value,
                                      Dtp_BuscaXFechaVencimiento.Value,
                                      ComboBoxEx1.SelectedValue)

    End Sub

    Private Sub Txt_BuscaXEntidad_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXEntidad.ButtonCustom2Click
        _RowEntidadBuscar = Nothing
        Txt_BuscaXEntidad.Text = String.Empty
        Call Btn_Buscar_Click(Nothing, Nothing)
    End Sub

    Private Sub Txt_BuscaXEntidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscaXEntidad.ButtonCustomClick

        Dim _CodEntidad = Txt_BuscaXEntidad.Text.Trim

        If String.IsNullOrEmpty(Txt_BuscaXEntidad.Text) Then
            _RowEntidadBuscar = Nothing
        End If

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.Rdb_Clientes.Checked = True
        Fm.Txtdescripcion.Text = _CodEntidad
        Fm.ShowDialog(Me)
        _RowEntidadBuscar = Fm.Pro_RowEntidad

        Fm.Dispose()

        If Not IsNothing(_RowEntidadBuscar) Then
            Txt_BuscaXEntidad.Text = _RowEntidadBuscar.Item("KOEN").ToString.Trim & "-" & _RowEntidadBuscar.Item("NOKOEN").ToString.Trim
            Call Btn_Buscar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Txt_BuscaXNudoNVV_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscaXNudoNVV.ButtonCustomClick
        Txt_BuscaXNudoNVV.Text = String.Empty
        Call Btn_Buscar_Click(Nothing, Nothing)
    End Sub

    Private Sub Txt_BuscaXNudoNVV_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_BuscaXNudoNVV.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Buscar_Click(Nothing, Nothing)
        End If
    End Sub

End Class
