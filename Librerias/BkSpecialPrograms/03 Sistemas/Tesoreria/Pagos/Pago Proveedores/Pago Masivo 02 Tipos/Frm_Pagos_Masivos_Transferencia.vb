'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Masivos_Transferencia

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsDocumentos As DataSet

    Dim _Documentos_a_Pagar As DataTable
    Dim _Transferencias As DataTable

    Dim _Vadp As Double

    Public _Pagado As Boolean

    Dim _Row_New_Maedpce As DataRow


    Public ReadOnly Property Pro_New_Maedpce() As DataRow
        Get
            Return _Row_New_Maedpce
        End Get
    End Property

    Public Sub New(ByVal DsDocumentos As DataSet)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        caract_combo(Cmb_Emdp)
        Dim Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf
        Consulta_sql = Union & "SELECT KOENDP AS Padre,KOENDP+NOKOENDP+CTACTE AS Hijo FROM TABENDP" & vbCrLf &
                      "WHERE CTACTE <> ''" & vbCrLf &
                      "ORDER BY Hijo"
        Cmb_Emdp.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Emdp.SelectedValue = ""

        Dtp_Fecha_Emision.Value = FechaDelServidor()
        _Documentos_a_Pagar = DsDocumentos.Tables(0)
        _Transferencias = DsDocumentos.Tables(1)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Generar_Archivo.ForeColor = Color.White
            Btn_Pagar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Pagos_Masivos_Transferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For Each _Fila As DataRow In _Documentos_a_Pagar.Rows
            If _Fila.Item("Chk") Then
                _Vadp += _Fila.Item("SALDO")
            End If
        Next

        Txt_Total_a_pagar.Tag = _Vadp
        Txt_Total_a_pagar.Text = FormatCurrency(_Vadp, 0)

    End Sub

    Private Sub Btn_Pagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pagar.Click

        Dim _Emdp As String = Trim(Cmb_Emdp.SelectedValue)

        If String.IsNullOrEmpty(Trim(_Emdp)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA DOCUMENTO EMISOR", My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Cmb_Emdp.Focus()
            Return
        End If


        If String.IsNullOrEmpty(Trim(Txt_NroTransferencia.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA NUMERO DE TRANSFERENCIA", My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Txt_NroTransferencia.Focus()
            Return
        End If

        Dim _Aceptado As Boolean
        Dim _NroDocumento As String

        _Aceptado = InputBox_Bk(Me, "Confirmar el número de documento", "Ingrese nuevamente el número", _NroDocumento,
                                                 False, _Tipo_Mayus_Minus.Mayusculas, 10, True,
                                                 _Tipo_Imagen.Transferencia_bancaria, False, _Tipo_Caracter.Cualquier_caracter)

        If _Aceptado Then
            If _NroDocumento <> Txt_NroTransferencia.Text Then
                MessageBoxEx.Show(Me, "Los números de transferencia son dintintos", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NroTransferencia.Focus()
                Return
            End If

            Dim _Cudp As String = _Sql.Fx_Trae_Dato("TABENDP", "CTACTE",
                                                "EMPRESA = '" & ModEmpresa & "' And KOENDP = '" & _Emdp & "'")

            Dim _Pagar As New Clas_Pagar
            _Pagado = _Pagar.Fx_Crear_Pago_y_Pagar("PTB", "", "", ModEmpresa, ModSucursal, ModCaja, Cmb_Emdp.SelectedValue, _Cudp,
                                               _NroDocumento,
                                               Dtp_Fecha_Emision.Value, Dtp_Fecha_Emision.Value, "$", "N", 1,
                                               "Pago masivo BakApp", 1,
                                               FUNCIONARIO, _Vadp,
                                               _Vadp, 0, "A", 0, "P", 0, "", 0, 123456, _Documentos_a_Pagar)

            If CBool(_Pagado) Then

                _Row_New_Maedpce = _Pagar.Pro_Row_Maedpce
                Dim _Tidp = _Row_New_Maedpce.Item("TIDP")
                Dim _Nudp = _Row_New_Maedpce.Item("NUDP")
                Dim _DocPagados = _Pagar.Pro_DocPagados

                MessageBoxEx.Show(Me, "Transacción realizada correctamente" & vbCrLf & vbCrLf &
                              "Número interno: " & _Tidp & "-" & _Nudp & vbCrLf & " Documentos pagados: " & _DocPagados,
                              "Proceso terminado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)


                Me.Close()
            End If
        End If

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Frm_Pagos_Masivos_Transferencia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Function Fx_Crear_Archivo_Exportacion_a_Banco(_CodBanco As String,
                                                  _Cta_Origen As String,
                                                  _Transferencias As DataTable) As DataTable
        Try

            Dim _Dt As New DataTable("Transferencias")
            Dim _Dr As DataRow
            Dim _Rs As New DataSet("Ds")

            Consulta_sql = String.Empty

            If _CodBanco = "001" Then ' Banco de Chile

                'creamos las mismas columnas que hay en el dataset
                _Dt.Columns.Add("Tipo_de_Operacion", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Rut_Cliente", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Cuenta_de_Cargo", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Rut_Beneficiario", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Nombre_de_Beneficiario", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Cuenta_del_Beneficiario", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Rut_Banco_Beneficiario", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Monto_de_Transferencia", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Abono_Inmediato", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Motivo_de_la_Transferencia", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Notificacion_via_email", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Asunto_email", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Direccion_emil", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Tipo_de_Cuenta", System.Type.[GetType]("System.String"))
                ',,,,,,

                For Each _Fila As DataRow In _Transferencias.Rows

                    Dim _Endo = _Fila.Item("ENDO").ToString.Trim
                    Dim _Suendo = _Fila.Item("SUENDO").ToString.Trim
                    Dim _Mto_Total = _Fila.Item("SALDO")

                    Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
                    Dim _TblEntidad As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    If CBool(_TblEntidad.Rows.Count) Then

                        Dim _Tipo_de_Operacion As String = _TblEntidad.Rows(0).Item("SUENDPEN").ToString.Trim
                        Dim _Rut_Cliente As String = Rellenar2(Replace(RutEmpresa, "-", "").ToString.Trim, 10, "0", Enum_Relleno.Izquierda)
                        Dim _Cuenta_de_Cargo As String = Rellenar2(_Cta_Origen, 12, "0", Enum_Relleno.Izquierda)

                        Dim _Rut_Beneficiario As String = _TblEntidad.Rows(0).Item("RTEN").ToString.Trim : _Rut_Beneficiario = Rellenar2(Trim(_Rut_Beneficiario & RutDigito(_Rut_Beneficiario)), 10, "0", Enum_Relleno.Izquierda)
                        Dim _Nombre_de_Beneficiario As String = Rellenar2(Mid(_TblEntidad.Rows(0).Item("NOKOEN").ToString.Trim, 1, 30), 30, " ", Enum_Relleno.Derecha)
                        Dim _Cuenta_del_Beneficiario As String

                        _Cuenta_del_Beneficiario = Rellenar2(_TblEntidad.Rows(0).Item("CUENTABCO").ToString.Trim, 18, " ", Enum_Relleno.Derecha)

                        If String.IsNullOrEmpty(_Cuenta_del_Beneficiario.Trim) Then
                            _Cuenta_del_Beneficiario = "falta_cta_bnco_ben"
                        End If

                        Dim _Rut_Banco_Beneficiario As String = _TblEntidad.Rows(0).Item("KOENDPEN").ToString.Trim

                        Try
                            _Rut_Banco_Beneficiario = Rellenar2(Trim(_Rut_Banco_Beneficiario & RutDigito(_Rut_Banco_Beneficiario)), 10, "0", Enum_Relleno.Izquierda)
                        Catch ex As Exception
                            _Rut_Banco_Beneficiario = "sinrutbanc"
                        End Try


                        Dim _Monto_de_Transferencia As String = Rellenar2(_Mto_Total, 11, "0", Enum_Relleno.Izquierda)


                        Dim _Asunto_email As String = Mid("PAGO " & UCase(RazonEmpresa), 1, 30).ToString.Trim
                        Dim _Direccion_emil As String = Mid(_TblEntidad.Rows(0).Item("EMAILCOMER").ToString.Trim, 1, 50).ToString.Trim
                        Dim _Tipo_de_Cuenta As String = _TblEntidad.Rows(0).Item("ACTECOBCO").ToString.Trim

                        _Dr = _Dt.NewRow()

                        _Dr("Tipo_de_Operacion") = _Tipo_de_Operacion
                        _Dr("Rut_Cliente") = _Rut_Cliente
                        _Dr("Cuenta_de_Cargo") = _Cuenta_de_Cargo
                        _Dr("Rut_Beneficiario") = _Rut_Beneficiario
                        _Dr("Nombre_de_Beneficiario") = _Nombre_de_Beneficiario
                        _Dr("Cuenta_del_Beneficiario") = _Cuenta_del_Beneficiario
                        _Dr("Rut_Banco_Beneficiario") = _Rut_Banco_Beneficiario
                        _Dr("Monto_de_Transferencia") = _Monto_de_Transferencia
                        _Dr("Abono_Inmediato") = " "
                        _Dr("Motivo_de_la_Transferencia") = Rellenar2("PAGO A PROVEEDORES", 30, " ", Enum_Relleno.Derecha)
                        _Dr("Notificacion_via_email") = 1
                        _Dr("Asunto_email") = Rellenar2(_Asunto_email, 30, " ", Enum_Relleno.Derecha)
                        _Dr("Direccion_emil") = Rellenar2(_Direccion_emil, 50, " ", Enum_Relleno.Derecha)
                        _Dr("Tipo_de_Cuenta") = _Tipo_de_Cuenta
                        _Dt.Rows.Add(_Dr)

                    End If

                Next

                _Rs.Tables.Add(_Dt)

                Return _Dt

                'ExportarTabla_JetExcel_Tabla(_Dt, Me, "Pago transferencia Banco Santander")

            End If

            If _CodBanco = "037" Then ' Banco Santander

                'creamos las mismas columnas que hay en el dataset
                _Dt.Columns.Add("Cta_Origen", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Mon_Origen", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Cta_Destino", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Mon_Destino", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Cod_Banco", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("RUT_Benef", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Nombre_Benef", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Mto_Total", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Glosa_TEF", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Correo", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Glosa_Correo", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Glosa_Cartola_Cliente", System.Type.[GetType]("System.String"))
                _Dt.Columns.Add("Glosa_Cartola_Beneficiario", System.Type.[GetType]("System.String"))
                ',,,,,,


                'dr = dt.NewRow() : dr("Padre") = "P" : dr("Hijo") = "Proveedor" : dt.Rows.Add(dr)
                'dr = dt.NewRow() : dr("Padre") = "A" : dr("Hijo") = "Ambos" : dt.Rows.Add(dr)
                'cerramos el datareader y la conexión
                'añadimos la tabla al dataset

                For Each _Fila As DataRow In _Transferencias.Rows


                    Dim _Endo = Trim(_Fila.Item("ENDO"))
                    Dim _Suendo = Trim(_Fila.Item("SUENDO"))
                    Dim _Mto_Total = _Fila.Item("SALDO")

                    Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
                    Dim _TblEntidad As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    If CBool(_TblEntidad.Rows.Count) Then

                        Dim _Rten As String = Trim(_TblEntidad.Rows(0).Item("RTEN"))
                        Dim _Nombre_Benef As String = Trim(_TblEntidad.Rows(0).Item("NOKOEN"))
                        Dim _Cta_Destino As String = Trim(_TblEntidad.Rows(0).Item("CUENTABCO"))
                        Dim _Cod_Banco As String = Trim(_TblEntidad.Rows(0).Item("KOENDPEN"))
                        Dim _Email As String = Trim(_TblEntidad.Rows(0).Item("EMAILCOMER"))

                        _Rten = Trim(_Rten & RutDigito(_Rten))

                        'Consulta_sql = Replace(Consulta_sql, "#CUENTABCO#", Txt_Cta_NroCtaCte.Text)
                        'Consulta_sql = Replace(Consulta_sql, "#KOENDPEN#", Txt_Cta_Codigo_Banco.Text)
                        'Consulta_sql = Replace(Consulta_sql, "#SUENDPEN#", Txt_Cta_Plaza_Sucursal.Text)
                        'Consulta_sql = Replace(Consulta_sql, "#ACTECOBCO#", Txt_Cta_Codigo_Act_Economica.Text)

                        _Dr = _Dt.NewRow()

                        _Dr("Cta_Origen") = _Cta_Origen
                        _Dr("Mon_Origen") = "CLP"
                        _Dr("Cta_Destino") = _Cta_Destino
                        _Dr("Mon_Destino") = "CLP"
                        _Dr("Cod_Banco") = _Cod_Banco
                        _Dr("RUT_Benef") = _Rten
                        _Dr("Nombre_Benef") = _Nombre_Benef
                        _Dr("Mto_Total") = _Mto_Total
                        _Dr("Glosa_TEF") = "PAGO " & UCase(_Nombre_Benef)
                        _Dr("Correo") = _Email
                        _Dr("Glosa_Correo") = "PAGO " & UCase(RazonEmpresa)
                        _Dr("Glosa_Cartola_Cliente") = "PAGO " & _Nombre_Benef
                        _Dr("Glosa_Cartola_Beneficiario") = "PAGO " & UCase(RazonEmpresa)

                        _Dt.Rows.Add(_Dr)

                    End If

                Next

                _Rs.Tables.Add(_Dt)

                Return _Dt

                'ExportarTabla_JetExcel_Tabla(_Dt, Me, "Pago transferencia Banco Santander")

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Function

    Private Sub Btn_Generar_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Generar_Archivo.Click

        Dim _Emdp As String = Trim(Cmb_Emdp.SelectedValue)

        If String.IsNullOrEmpty(Trim(_Emdp)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA DOCUMENTO EMISOR", My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Cmb_Emdp.Focus()
            Return
        End If

        Consulta_sql = "Select top 1 *  From TABENDP Where EMPRESA = '" & ModEmpresa & "' And KOENDP = '" & _Emdp & "'"
        Dim _TblCtaCte As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblCtaCte.Rows.Count) Then

            Dim _CodBanco As String = _TblCtaCte.Rows(0).Item("KOENDP").ToString.Trim
            Dim _Banco As String = _TblCtaCte.Rows(0).Item("NOKOENDP").ToString.Trim
            Dim _Ctacte As String = _TblCtaCte.Rows(0).Item("CTACTE").ToString.Trim

            'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
            'Where Tabla = 'BANCOTRANSFERENCIA' And CodigoTabla = '" & _CodBanco & "'"
            'Dim _Row_Bancos_Transferencia As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _CodBanco = "001" Then

                Dim Cl_BcoChile_F400 As New Clas_Pago_Banco_De_Chile_F400

                Dim _Codigo_Convenio = 2

                Dim Fm_Espera As New Frm_Form_Esperar
                Fm_Espera.BarraCircular.IsRunning = True
                Fm_Espera.Show()

                If Cl_BcoChile_F400.Fx_CreaTXT_Banco_de_Chile_F400(_Codigo_Convenio, "PAGO A PROVEEDORES",
                                                                   Dtp_Fecha_Emision.Value, Txt_Total_a_pagar.Tag, _Transferencias) Then

                    Fm_Espera.Close()
                    MessageBoxEx.Show(Me, "Archivo para levantamiento de pago Banco de Chile fue creado correctamente" & vbCrLf &
                                      "Nombre y ruta del archivo: " & Cl_BcoChile_F400.Directorio_Destino & "\" & Cl_BcoChile_F400.Nombre_Archivo,
                                      "Banco de Chile", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Process.Start("explorer.exe", Cl_BcoChile_F400.Directorio_Destino)

                Else
                    Fm_Espera.Close()
                    MessageBoxEx.Show(Me, Cl_BcoChile_F400.StrError, "Probrema al armar el archivo " & Cl_BcoChile_F400.Nombre_Archivo & ".txt",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

                Return

            End If

            Dim _Tbl_Transferencia As DataTable = Fx_Crear_Archivo_Exportacion_a_Banco(_CodBanco, _Ctacte, _Transferencias)

            If Not IsNothing(_Tbl_Transferencia) Then

                ExportarTabla_JetExcel_Tabla(_Tbl_Transferencia, Me, "PAGO TRANSFERENCIA " & _Banco)

            Else

                MessageBoxEx.Show(Me, "Este banco no tiene diseñada esta opción" & vbCrLf & vbCrLf &
                                   _Banco, "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

End Class
