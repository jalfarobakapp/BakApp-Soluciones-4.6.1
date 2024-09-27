'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Threading

Public Class Frm_Cashdro_Ingreso_Documento

    Dim _Impresora As String

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_CashDro As DataRow
    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

    Dim _Tiempo_Espera_Configuracion = 0

    Dim _Posicion_X As Integer = Location.X
    Dim _Posicion_Y As Integer = Location.Y

    Dim _Fase_Prueba_Efectivo As Boolean
    Dim _Fase_Prueba_Tarjeta As Boolean
    Dim _Fase_Prueba_Nota_De_Credito As Boolean

    Dim _Teclado As Boolean

    Dim _Tiempo As Integer

    Dim _Volver_A_Cargar As Boolean

    Dim _Ypos As Integer
    Dim _Xpos As Integer
    Dim _Ult_Idmaeedo As Integer

    Dim _Ncv_Memoria As String
    Dim _OperationId_Transbank As String
    'Dim _Version_Transbank As Integer

    Dim _Post_Integrado, _Post_Autoservicio As Boolean

    Dim _Cl_Pago_Cashdro As Cl_Pago_Cashdro

    Public ReadOnly Property Pro_Volver_A_Cargar() As Boolean
        Get
            Return _Volver_A_Cargar
        End Get
    End Property
    Public Property Pro_Row_CashDro() As DataRow
        Get
            Return _Row_CashDro
        End Get
        Set(ByVal value As DataRow)
            _Row_CashDro = value
        End Set
    End Property
    Public ReadOnly Property Pro_Ult_Idmaeedo() As Integer
        Get
            Return _Ult_Idmaeedo
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "SELECT NombreEquipo,Funcionario,Modalidad,Ip_CashDro,Usuario_CashDro,Contrasena_CashDro," &
                       "EFV,TJV,NCV,Tiempo_Espera,Fase_Prueba" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_CashDro = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Fase_Prueba_Efectivo = _Row_CashDro.Item("Fase_Prueba")
        _Fase_Prueba_Tarjeta = _Row_CashDro.Item("Fase_Prueba_Tarjeta")
        _Fase_Prueba_Nota_De_Credito = _Row_CashDro.Item("Fase_Prueba_Nota_De_Credito")

        '_Version_Transbank = 3 '_Row_CashDro.Item("Version_Transbank")

        _Post_Autoservicio = _Row_CashDro.Item("Post_Autoservicio")
        _Post_Integrado = _Row_CashDro.Item("Post_Integrado")

        Btn_Teclado.Visible = _Fase_Prueba_Efectivo
        Btn_Transbak_Pruebas.Visible = _Fase_Prueba_Tarjeta

        Tiempo_Tocar_Pantalla.Interval = 600

    End Sub

    Private Sub Frm_Cashdro_Ingreso_Documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterToScreen()
        _Ypos = Location.Y
        _Xpos = Location.X

        CircularProgress1.IsRunning = True

        _Impresora = String.Empty
        _Impresora = _Row_CashDro.Item("Impresora_Predeterminada")

        If String.IsNullOrEmpty(_Impresora) Then
            Dim Fm As New Frm_Seleccionar_Impresoras("")
            Fm.ShowDialog(Me)
            If (String.IsNullOrEmpty(Fm.Pro_Impresora_Seleccionada)) Then
                _Impresora = String.Empty
            Else
                _Impresora = Fm.Pro_Impresora_Seleccionada
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Estaciones_CashDro Set Impresora_Predeterminada = '" & _Impresora & "'" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If
            Fm.Dispose()
        End If


        Dim _Pr_EFV, _Pr_TJV, _Pr_NCV As String

        If _Fase_Prueba_Efectivo Then _Pr_EFV = "[Efectivo]"
        If _Fase_Prueba_Tarjeta Then _Pr_TJV = "[Tarjeta]"
        If _Fase_Prueba_Nota_De_Credito Then _Pr_NCV = "[Nota de crédito]"


        Me.Text = "CAJERO AUTOMATICO. Modalidad: " & Modalidad & ", Caja: " & ModCaja & ", Usuario: " & "(" & FUNCIONARIO & ") - " & Nombre_funcionario_activo & ", Equipo: " & _NombreEquipo
        Lbl_Version.Text = "Versión: " & _Global_Version_BakApp

        If _Fase_Prueba_Efectivo Or _Fase_Prueba_Tarjeta Or _Fase_Prueba_Nota_De_Credito Then
            Lbl_Version.Text += " (Pruebas: " & _Pr_EFV & _Pr_TJV & _Pr_NCV & ")"
        End If

        '_Cl_Pago_Cashdro = New Cl_Pago_Cashdro(_NombreEquipo)

        Me.ActiveControl = Txt_Documento_Venta
        RfLbl_Informacion.Visible = False

    End Sub

    Private Sub Frm_Cashdro_Ingreso_Documento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not _Volver_A_Cargar Then

            If Not _Fase_Prueba_Efectivo And Not _Fase_Prueba_Tarjeta Then

                Dim _Validar As Boolean

                Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Cdro0003", True, False)
                Fm.Pro_Cerrar_Automaticamente = True
                Fm.ShowDialog(Me)
                _Validar = Fm.Pro_Permiso_Aceptado
                Fm.Dispose()

                If Not _Validar Then
                    e.Cancel = True
                End If

            End If

        End If

    End Sub

    Private Sub Frm_Cashdro_Ingreso_Documento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

        Tiempo_Label.Interval = 1000
        Tiempo_Label.Start()

    End Sub

    Private Sub Txt_Documento_Venta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Documento_Venta.KeyDown

        Dim _Row_Operacion_NCV As DataRow
        Dim _Row_Maeedo_NCV As DataRow

        If e.KeyValue = Keys.Enter Then

            Try

                Tiempo_Label.Stop()
                Me.Enabled = False

                Txt_Documento_Venta.Text = UCase(Txt_Documento_Venta.Text)

                If Not String.IsNullOrEmpty(Trim(Txt_Documento_Venta.Text)) Then

                    If Txt_Documento_Venta.Text.Contains("NCV") Then

                        _Ncv_Memoria = String.Empty

                        Dim _Nudo = Replace(Txt_Documento_Venta.Text, "NCV", "")

                        Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,FEEMDO,VABRDO,VAABDO,VAIVARET," &
                                       "VABRDO-VAABDO AS SALDO,ESPGDO,MODO From MAEEDO" & vbCrLf &
                                       "Where TIDO = 'NCV' And NUDO = '" & _Nudo & "'"
                        _Row_Maeedo_NCV = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If Not _Row_Maeedo_NCV Is Nothing Then

                            Dim _Saldo As Double = _Row_Maeedo_NCV.Item("SALDO")

                            If _Saldo > 10 Then

                                Dim _Devolucion_Efectivo As Boolean
                                Dim _Usar_Nota_de_credito As Boolean

                                Dim Fm_NCV As New Frm_Cashdro_Pago_Nota_de_credito(_Row_Maeedo_NCV)
                                Fm_NCV.ShowDialog(Me)
                                _Row_Operacion_NCV = Fm_NCV.Pro_Row_Operacion_NCV
                                _Devolucion_Efectivo = Fm_NCV.Pro_Devolucion_Efectivo
                                _Usar_Nota_de_credito = Fm_NCV.Pro_Usar_Nota_de_credito
                                Fm_NCV.Dispose()

                                If _Usar_Nota_de_credito Then

                                    _Ncv_Memoria = _Row_Maeedo_NCV.Item("NUDO")
                                    Return

                                ElseIf _Devolucion_Efectivo Then

                                    If Not (_Row_Operacion_NCV Is Nothing) Then

                                        Sb_Pago_Vuelto(_Row_Operacion_NCV)
                                        Sb_Pagar_Pendientes_Vuelto_Casdro()

                                        _Volver_A_Cargar = True
                                        Me.Close()

                                        Return

                                    End If

                                Else

                                    Return

                                End If

                            Else
                                Beep()
                                ToastNotification.Show(Me, "DOCUMENTO SIN SALDO A FAVOR",
                                          My.Resources.cross,
                                          2 * 1000, eToastGlowColor.Red,
                                          eToastPosition.MiddleCenter)
                                Return

                            End If

                        End If

                    End If

                    ' ACA VALIDAR QUE SI HAY NOTA DE CREDITO ESTA PERTENESCA AL MISMO RUT DEL DOCUMENTO DE VENTA

                    Dim _Row_Documento As DataRow = Fx_Row_Documento(Txt_Documento_Venta.Text)

                    If (_Row_Documento Is Nothing) Then

                        Txt_Documento_Venta.Text = String.Empty
                        Txt_Documento_Venta.Focus()
                        Tiempo_Label.Start()

                    Else

                        Dim _Tido = _Row_Documento.Item("TIDO")
                        Dim _Nudo = _Row_Documento.Item("NUDO")
                        Dim _Nudonodefi = _Row_Documento.Item("NUDONODEFI")

                        If Not CBool(_Nudonodefi) Then

                            MessageBoxEx.Show(Me, "SOLO SE ACEPTAN VALES TRANSITORIOS" & vbCrLf & vbCrLf &
                                              "EL DOCUMENTO QUE ESTA QUERIENDO PAGAR ESTA COMO DEFINITIVO EN EL SISTEMA",
                                              "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return

                        End If

                        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")
                        Dim _Nro_Documento As String = Traer_Numero_Documento(_Tido, , Modalidad)
                        Dim _Tidoelec As Integer = CInt(Fx_Es_Electronico(_Tido)) * -1

                        Dim _Mensaje As New LsValiciones.Mensajes

                        _Mensaje = Fx_Revisar_Expiracion_Folio_SII(Me, _Tido, _Nro_Documento, False)

                        If Not _Mensaje.EsCorrecto Then
                            Return
                        End If

                        Dim _Tipo_De_Pago As String = "EFV"

                        Dim _EFV As Boolean = _Row_CashDro.Item("EFV")
                        Dim _TJV As Boolean = _Row_CashDro.Item("TJV")
                        Dim _NCV As Boolean = _Row_CashDro.Item("NCV")
                        Dim _Pago_con_nota_de_credito As Boolean

                        ' ESTO HACE QUE SOLO SE PUEDA PAGARA EN EFECTIVO, PARA HABILITAR LAS DEMAS OPCIONES 
                        ' SE DEBE ACTIVAR EL FORMULARIO Frm_Cashdro_Forma_de_Pago

                        If _TJV Or _NCV Then

                            Dim Fm As New Frm_Cashdro_Forma_de_Pago(_Nudo, _Monto, _Row_Documento)
                            Fm.Pro_EFV = _EFV
                            Fm.Pro_TJV = _TJV
                            Fm.Pro_NCV = _NCV

                            If Not _Row_Maeedo_NCV Is Nothing Then
                                Fm.Sb_Pago_Nota_De_Credito(_Row_Maeedo_NCV)
                            End If

                            Fm.ShowDialog(Me)

                            _Tipo_De_Pago = Fm.Pro_Tipo_De_Pago
                            _Pago_con_nota_de_credito = Fm.Pro_Pago_con_nota_de_credito
                            _Row_Operacion_NCV = Fm.Pro_Row_Operacion_Vuelto
                            Fm.Dispose()

                        Else

                            _Tipo_De_Pago = "EFV"

                        End If

                        Dim _Pagado As Boolean
                        Dim _Pago_EFV, _Pago_TJV, _Pago_NCV As Boolean

                        Dim _Imprimir_Voucher_Transbank As Boolean

                        If Not String.IsNullOrEmpty(_Tipo_De_Pago) Then

                            Select Case _Tipo_De_Pago

                                Case "EFV"

                                    _Pagado = Fx_Pago_Efectivo(_Row_Documento)
                                    _Pago_EFV = _Pagado

                                Case "TJV"

                                    'If _Version_Transbank = 1 Then
                                    '    _Pagado = Fx_Pago_Tarjeta_Version_1(_Row_Documento, False)
                                    'ElseIf _Version_Transbank = 2 Then
                                    '    _Pagado = Fx_Pago_Tarjeta_Version_2(_Row_Documento, False)
                                    'ElseIf _Version_Transbank = 3 Then
                                    '    _Pagado = Fx_Pago_Tarjeta_Version_3(_Row_Documento, False)
                                    'End If

                                    If _Post_Autoservicio Then _Pagado = Fx_Pago_Tarjeta_Version_3(_Row_Documento, True)
                                    If _Post_Integrado Then _Pagado = Fx_Pago_Tarjeta_Post_Integrado(_Row_Documento, True)

                                    'MessageBoxEx.Show(Me, "Pagado = " & CInt(_Pagado), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    If _Pagado Then
                                        _Imprimir_Voucher_Transbank = True
                                        _Pago_TJV = _Pagado
                                        'If _Pago_con_nota_de_credito Then Sb_Pagar_Pendientes_Nota_De_Credito()
                                    End If

                                Case "NCV"

                                    _Pagado = Fx_Pago_Nota_De_Credito(_Row_Documento)
                                    _Pago_NCV = _Pagado

                                    If Not (_Row_Operacion_NCV Is Nothing) Then Sb_Pago_Vuelto(_Row_Operacion_NCV)

                                Case "EFV_TJV"

                                    _Pagado = Fx_Pago_Efectivo_Tarjeta(_Row_Documento)

                                    If _Pagado Then

                                        _Pago_EFV = _Pagado
                                        _Pago_TJV = _Pagado
                                        _Imprimir_Voucher_Transbank = True

                                    End If

                            End Select

                        End If

                        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")

                        'IMPRIMIR DOCUMENTO Y VOUCHER

                        If _Pagado Then

                            Sb_Imprimir_Documento(_Idmaeedo)

                            If _Imprimir_Voucher_Transbank Then
                                Sb_Imprimir_Voucher_Tarjeta_Bakapp(Me, _Idmaeedo, _Impresora)
                            End If

                            Dim _Cl_Pago_Cashdro As New Cl_Pago_Cashdro(_NombreEquipo)

                            If _Pago_EFV Then _Cl_Pago_Cashdro.Sb_Pagar_Pendientes_Efectivo(True) 'Sb_Pagar_Pendientes_Efectivo(False)
                            If _Pago_TJV Then _Cl_Pago_Cashdro.Sb_Pagar_Pendientes_Tarjeta(True) 'Sb_Pagar_Pendientes_Tarjeta(False)
                            If _Pago_con_nota_de_credito Then _Cl_Pago_Cashdro.Sb_Pagar_Pendientes_Nota_De_Credito() ' Sb_Pagar_Pendientes_Nota_De_Credito()

                            ' 5 Segundos de demora
                            Thread.Sleep(5000)

                            _Volver_A_Cargar = True
                            Me.Close()

                        Else

                            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                                           "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Tiempo_Label.Start()

                        End If

                    End If

                End If

            Catch ex As Exception
                'MessageBoxEx.Show(Me, ex.Message, "Error en Lectura", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally

                Me.Enabled = True
                Txt_Documento_Venta.Text = String.Empty
                Txt_Documento_Venta.Focus()

            End Try

        End If

    End Sub

    Function Fx_Pago_Efectivo(ByVal _Row_Documento As DataRow) As Boolean

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")

        Dim _OperationId As String
        Dim _Pagado As Boolean
        Dim _Cancelado As Boolean
        Dim _Tiempo_Caducado As Boolean
        Dim _Error As String

        Dim _Ult_Digito As Integer = Mid(_Monto, Len(Str(_Monto)) - 1, 1)
        Dim _Ajuste_Sencillo As Integer = 0

        If CBool(_Ult_Digito) Then
            If _Ult_Digito < 5 Then
                _Monto -= _Ult_Digito
                _Ajuste_Sencillo = -_Ult_Digito
            Else
                _Monto = _Monto + (10 - _Ult_Digito)
                _Ajuste_Sencillo = 10 - _Ult_Digito
            End If
        End If

        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones", "COALESCE(MAX(Numero),'0000000000')")

        If String.IsNullOrEmpty(_Numero) Then _Numero = "0000000000"

        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _Id As Integer = 0

        If _Fase_Prueba_Efectivo Then

            _Pagado = True

            Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
            Dim _posuser As String = FUNCIONARIO

            _OperationId = String.Empty

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser," &
                           "Tipo_De_Pago,Monto,Ajuste_Sencillo,Modalidad,Empresa,Sucursal,Bodega,Caja,Idmaeedo_H) Values " & vbCrLf &
                           "('" & _Numero & "','" & _OperationId & "',GetDate(),'" & _posid & "','" & _posuser & "','EFV'," & _Monto & "," & _Ajuste_Sencillo &
                           ",'" & Modalidad & "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "'," & _Idmaeedo & ")"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

        Else

            Dim Fm As New Frm_Cashdro_Pago_Efectivo(_Monto, _Row_CashDro, _Idmaeedo)

            If String.IsNullOrEmpty(Fm.Pro_Error) Then

                Fm.ShowDialog(Me)
                _OperationId = Fm.Pro_Operation_Id
                _Pagado = Fm.Pro_Pagado
                _Cancelado = Fm.Pro_Cancelado
                _Tiempo_Caducado = Fm.Pro_Tiempo_Caducado
                _Numero = Fm.Pro_Numero
                _Id = Fm.Pro_Id

            End If

            _Error = Fm.Pro_Error

            Fm.Dispose()

        End If

        If Not String.IsNullOrEmpty(_Error) Then

            MessageBoxEx.Show(Me, _Error & vbCrLf & vbCrLf &
                              "Todos los pagos seran reversados", "Problema",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            If _Pagado Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Ajuste_Sencillo = " & _Ajuste_Sencillo & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Sb_Transformar_Vale_Transitorio_En_Documento(_Row_Documento, _Id, "EFV")

            ElseIf _Cancelado Then

                Beep()

                If _Tiempo_Caducado Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Cancelado_Por_Tiempo = 1,FechaHora_Fin = Getdate()" & vbCrLf &
                                  "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    ToastNotification.Show(Me, "TIEMPO DE ESPERA TERMINO",
                                           My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Cancelado_Por_Usuario = 1,FechaHora_Fin = Getdate()" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    ToastNotification.Show(Me, "CANCELADO POR EL USUARIO",
                                                           My.Resources.cross,
                                                           2 * 1000, eToastGlowColor.Red,
                                                           eToastPosition.MiddleCenter)
                End If

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                               "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

        If _Pagado Then
            'Sb_Pagar_Pendientes_Efectivo(False)
        Else
            'Borramos los pagos generados por Notas de credito
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Txt_Documento_Venta.Text = String.Empty
        Txt_Documento_Venta.Focus()
        Me.Refresh()

        Return _Pagado

    End Function

    Function Fx_Pago_Tarjeta_Version_1(ByVal _Row_Documento As DataRow,
                                       ByVal _Pago_Efectivo_Tarjeta As Boolean) As Boolean

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")

        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")

        Dim _Id As Integer = 0

        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones",
                                                 "COALESCE(MAX(Numero),'0000000000')")
        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _posuser As String = FUNCIONARIO

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Monto,Modalidad,Empresa,Sucursal,Bodega,Caja) Values " & vbCrLf &
                       "('" & _Numero & "','',GetDate(),'" & _posid & "','" & _posuser & "'," & De_Num_a_Tx_01(_Monto, False, 5) & ",'" & Modalidad & "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "')"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

        If _Pago_Efectivo_Tarjeta Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Idmaeedo = " & _Idmaeedo & vbCrLf &
                           "Where Id =" & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Dim _Pagado As Boolean
        Dim _Respuesta As String
        Dim _Status As String

        If _Fase_Prueba_Tarjeta Then

            _Pagado = True
            _Respuesta = "0260|00|597033825196|E1100455|00000000000000661800|609091|" & numero_(_Monto, 10) & "|3445|000882|CR|||MC|04082018|130342|0"
            _Status = "APROBADO"

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                           "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia) Values" & Space(1) &
                           "(Getdate(),'" & _Respuesta &
                           "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ")"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, _Idmaeedo, _Monto,
                                                           Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Transaccion_Venta, False)
            Fm.ShowDialog(Me)

            _Pagado = Fm.Pro_Pagado
            _Respuesta = Fm.Pro_Respuesta_Decodificada
            _Status = Fm.Pro_Status

            Fm.Dispose()

            Dim _Log_Datos_Ultima_Venta_Transbank As String

            Dim Fm_Log As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, "0", 0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Datos_Ultima_Venta, False)
            Fm_Log.ShowDialog(Me)
            _Log_Datos_Ultima_Venta_Transbank = Fm_Log.Pro_Respuesta_Decodificada
            Fm_Log.Dispose()

            _Log_Datos_Ultima_Venta_Transbank = Replace(_Log_Datos_Ultima_Venta_Transbank, "'", "")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                           "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia) Values" & Space(1) &
                           "(Getdate(),'" & _Log_Datos_Ultima_Venta_Transbank &
                           "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ")"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        If _Pagado Then
            Sb_Transformar_Vale_Transitorio_En_Documento(_Row_Documento, _Id, "TJV")
        End If

        _Respuesta = Replace(_Respuesta, "'", "")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                       "Pagado_Transbank = " & CInt(_Pagado) * -1 & "," &
                       "Status_Tarjeta = '" & _Status & "'," &
                       "Respuesta_Tarjeta = '" & _Respuesta & "'," &
                       "FechaHora_Fin = Getdate()" & vbCrLf &
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Pagado Then
            'Sb_Pagar_Pendientes_Tarjeta(True)
        Else
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Return _Pagado

    End Function

    Function Fx_Pago_Tarjeta_Version_2(ByVal _Row_Documento As DataRow,
                                       ByVal _Pago_Efectivo_Tarjeta As Boolean) As Boolean

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")

        Dim _Id As Integer = 0

        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones",
                                                  "COALESCE(MAX(Numero),'0000000000')")
        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _posuser As String = FUNCIONARIO

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Monto,Modalidad,Empresa,Sucursal,Bodega,Caja) Values " & vbCrLf &
                       "('" & _Numero & "','',GetDate(),'" & _posid & "','" & _posuser & "'," & De_Num_a_Tx_01(_Monto, False, 5) & ",'" & Modalidad & "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "')"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

        If _Pago_Efectivo_Tarjeta Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Idmaeedo = " & _Idmaeedo & vbCrLf &
                           "Where Id =" & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Dim _Pagado As Boolean
        Dim _Respuesta As String = String.Empty
        Dim _Status As String = String.Empty

        Dim _1R_Pagado As Boolean
        Dim _1R_Respuesta As String = String.Empty
        Dim _1R_Status As String = String.Empty

        Dim _Puerto_Serial_Bloqueado As Boolean

        Dim Fm_Espera As New Frm_Form_Esperar

        If _Fase_Prueba_Tarjeta Then

            _Pagado = True
            _Respuesta = "0260|00|555444333222|E1100455|00000000000000661800|609091|" & numero_(_Monto, 10) & "|3445|000882|CR|||MC|04082018|130342|0"
            _Status = "APROBADO"
            Dim _Id_Log_Transbank = 0

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                           "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia) Values" & Space(1) &
                           "(Getdate(),'" & _Respuesta &
                           "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ")"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)

            _Respuesta = "Nro. Tarjeta: ****************9999,Nro. Operación: Prueba Bakapp,Cód.Autorización: 888888," &
                         "Terminal Id: UX000000,Cód.Comercio: 555444333222 Id_Log_Transbank = " & _Id_Log_Transbank

        Else

            Dim _Cerrado_por_usuario_o_tiempo As Boolean
            Dim _Commando_Transbank As String

            Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, _Idmaeedo, _Monto,
                                   Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Transaccion_Venta, True)
            Fm.Btn_Cancelar.Visible = False
            Fm.ShowDialog(Me)
            _Puerto_Serial_Bloqueado = Fm.Pro_Puerto_Bloqueado

            If _Puerto_Serial_Bloqueado Then
                ToastNotification.Show(Me, "PROBLEMAS DE COMUNICACION CON PUERTO SERIAL", My.Resources.cross,
                                           8 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                ' 3 Segundos de demora
                Thread.Sleep(3000)
                Return False
            End If

            _Pagado = Fm.Pro_Pagado
            _Respuesta = Fm.Pro_Respuesta_Decodificada
            _Status = Fm.Pro_Status
            _1R_Pagado = _Pagado
            _1R_Respuesta = _Respuesta
            _1R_Status = _Status
            _Cerrado_por_usuario_o_tiempo = Fm.Pro_Cierra_Usuario
            _Commando_Transbank = Fm.Pro_Comando_Transaccion
            Fm.Dispose()


            If _Cerrado_por_usuario_o_tiempo Then Return False

            Dim _Log_Datos_Ultima_Venta_Transbank As String

            '3 Segundos de demora
            'Thread.Sleep(3000)

            Dim _Datos_Respuesta = Split(_Respuesta, "|")

            Dim _Cod_Respuesta = _Datos_Respuesta(1)
            Dim _Respuesta_Status = UCase(Fx_Tabla1_Respuestas(_Cod_Respuesta))


            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                           "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia,Comando_Transbank,Respuesta_Transbank,Respuesta_Inicial) Values" & Space(1) &
                           "(Getdate(),'" & _Respuesta & "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ",'" & _Commando_Transbank & "','" & _1R_Respuesta & "',1)"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            If _Cod_Respuesta <> "00" Then
                Beep()
                ToastNotification.Show(Me, _Respuesta_Status,
                                           My.Resources.cross,
                                           3 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)

                'Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                '               "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia,Comando_Transbank,Respuesta_Transbank) Values" & Space(1) &
                '               "(Getdate(),'Fallo!!!'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ",'" & _Commando_Transbank & "','" & _1R_Respuesta & "')"
                '_Sql.Ej_consulta_IDU(Consulta_sql)

                _Pagado = False
                Return False
            End If

            Dim _Intentos = 3

            Dim _Documento As String

            If _Row_Documento.Item("TIDO") = "BLV" Then
                _Documento = "BOLETA"
            ElseIf _Row_Documento.Item("TIDO") = "FCV" Then
                _Documento = "FACTURA"
            End If

            Fm_Espera.Pro_Texto = "RESCATANDO DATOS DESDE DISPOSITIVO TRANSBANK, ESPERE SU " & _Documento & " POR FAVOR..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()

            For _in = 1 To _Intentos
                Dim Fm_Log As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, "0", 0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Datos_Ultima_Venta, True)
                Fm_Log.WindowState = FormWindowState.Minimized
                Fm_Log.ShowDialog(Me)
                _Puerto_Serial_Bloqueado = Fm_Log.Pro_Puerto_Bloqueado
                _Log_Datos_Ultima_Venta_Transbank = Fm_Log.Pro_Respuesta_Decodificada
                Fm_Log.Dispose()
                If Not _Puerto_Serial_Bloqueado Then Exit For
            Next

            _Log_Datos_Ultima_Venta_Transbank = Replace(_Log_Datos_Ultima_Venta_Transbank, "'", "")

            Dim _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
            Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

            Try

                Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
                Dim _Numero_Ticket_Boleta_IDMAEEDO = CInt(_Datos_Tarjeta(4))
                Dim _Ultimo_Status = Fx_Tabla1_Respuestas(_Codigo_Respuesta)

                If _Numero_Ticket_Boleta_IDMAEEDO = _Idmaeedo Then

                    _Respuesta = _Log_Datos_Ultima_Venta_Transbank
                    _Status = UCase(_Ultimo_Status)

                    If _Codigo_Respuesta = "00" Then

                        _Pagado = True

                        'Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set 
                        'Respuesta_Tarjeta = '" & _Respuesta & "' Where Tipo_De_Pago = 'TJV' And Idmaeedo = " & _Idmaeedo
                        '_Sql.Ej_consulta_IDU(Consulta_sql)

                        Dim _Comando As String
                        Dim _Codigo_de_comercio = String.Empty
                        Dim _Terminal_ID = String.Empty
                        'Dim _Numero_Ticket_Boleta = String.Empty
                        Dim _Codigo_Autorizacion = String.Empty
                        Dim _Ultimos_4_Digitos_Tarjeta = String.Empty
                        Dim _Numero_Operacion = String.Empty
                        'Dim _Tipo_de_Tarjeta = String.Empty
                        Dim _Voucher = String.Empty

                        _Comando = _Datos_Tarjeta(0)
                        _Codigo_Respuesta = _Datos_Tarjeta(1)
                        _Codigo_de_comercio = _Datos_Tarjeta(2)
                        _Terminal_ID = _Datos_Tarjeta(3)
                        '_Numero_Ticket_Boleta = _Datos_Tarjeta(4)
                        _Codigo_Autorizacion = _Datos_Tarjeta(5)
                        _Ultimos_4_Digitos_Tarjeta = Rellenar(_Datos_Tarjeta(7), 20, "*", False)
                        '_Numero_Operacion = _Datos_Tarjeta(8)
                        '_Tipo_de_Tarjeta = _Datos_Tarjeta(9)
                        _Voucher = _Datos_Tarjeta(15)

                        _Voucher = Replace(_Voucher, "*** DUPLICADO ***", Space(17))

                        Dim _Id_Log_Transbank As Integer

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                                       "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia) Values" & Space(1) &
                                       "(Getdate(),'" & _Log_Datos_Ultima_Venta_Transbank &
                                       "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ")"
                        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)

                        _Respuesta = "Nro. Tarjeta: " & _Ultimos_4_Digitos_Tarjeta & "," &
                                     "Nro. Operación: " & _Numero_Operacion & "," &
                                     "Cód.Autorización: " & _Codigo_Autorizacion & "," &
                                     "Terminal Id: " & _Terminal_ID & "," &
                                     "Cód.Comercio: " & _Codigo_de_comercio & " Id_Log_Transbank = " & _Id_Log_Transbank

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set 
                                        Voucher = '" & _Voucher & "',
                                        Comando_Transbank = '" & _Commando_Transbank & "', 
                                        Respuesta_Transbank = '" & _1R_Respuesta & "' Where Id = " & _Id_Log_Transbank
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    ElseIf _Codigo_Respuesta = "01" Then
                        Beep()
                        ToastNotification.Show(Me, "RECHAZADO",
                                           My.Resources.cross,
                                           3 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                        _Pagado = False
                    Else
                        _Pagado = False
                    End If

                End If

            Catch ex As Exception

            End Try

        End If

        If Not _Pagado And _1R_Pagado Then
            _Pagado = _1R_Pagado
            _Status = _1R_Status
            _Respuesta = _1R_Respuesta
        End If

        If _Pagado Then
            Sb_Transformar_Vale_Transitorio_En_Documento(_Row_Documento, _Id, "TJV")
        End If

        _Respuesta = Replace(_Respuesta, "'", "")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                       "Pagado_Transbank = " & CInt(_Pagado) * -1 & "," &
                       "Status_Tarjeta = '" & _Status & "'," &
                       "Respuesta_Tarjeta = '" & _Respuesta & "'," &
                       "FechaHora_Fin = Getdate()" & vbCrLf &
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Pagado Then
            'Sb_Pagar_Pendientes_Tarjeta(False)
        Else
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Fm_Espera.Dispose()

        Return _Pagado

    End Function

    Function Fx_Pago_Tarjeta_Version_3(ByVal _Row_Documento As DataRow,
                                       ByVal _Pago_Efectivo_Tarjeta As Boolean) As Boolean

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")
        Dim _Log_Error As String

        Dim _Id As Integer = 0

        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones",
                                                  "COALESCE(MAX(Numero),'0000000000')")
        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _posuser As String = FUNCIONARIO

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Monto,Modalidad,Empresa,Sucursal,Bodega,Caja,Idmaeedo_H) Values " & vbCrLf &
                       "('" & _Numero & "','',GetDate(),'" & _posid & "','" & _posuser & "'," & De_Num_a_Tx_01(_Monto, False, 5) & ",'" & Modalidad & "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "'," & _Idmaeedo & ")"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

        If _Pago_Efectivo_Tarjeta Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Idmaeedo = " & _Idmaeedo & vbCrLf &
                           "Where Id =" & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Dim _Pagado As Boolean
        Dim _Respuesta As String = String.Empty
        Dim _Status As String = String.Empty

        Dim _1R_Pagado As Boolean
        Dim _1R_Respuesta As String = String.Empty
        Dim _1R_Status As String = String.Empty

        Dim _Puerto_Serial_Bloqueado As Boolean

        Dim _Cerrado_por_usuario_o_tiempo As Boolean
        Dim _Commando_Transbank As String
        Dim _Id_Log_Transbank = 0

        Dim Fm_Espera As New Frm_Form_Esperar

        If _Fase_Prueba_Tarjeta Then

            Dim _Accion = MessageBoxEx.Show(Me, "Yes = Pagar" & vbCrLf &
                                 "No = Cancelar" & vbCrLf &
                                 "Cancelar = Cancelado por el usuario en Transbank o tiempo",
                                 "Pruebas Transbank", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If _Accion = DialogResult.Yes Then

                Dim _Random As New Random()
                Dim _Fecha = FechaDelServidor()

                Dim _Cod_Autorizacion = _Random.Next(10000, 99999)
                Dim _Nro_Tarjeta = Rellenar(_Random.Next(1000, 9999), 20, "*", False)
                Dim _Nro_Operacion = _Random.Next(10000, 99999)
                Dim _Tj = _Random.Next(-10, 10)
                Dim _Tarjeta As String

                If _Tj <= 0 Then
                    _Tarjeta = "CR"
                ElseIf _Tj > 0 Then
                    _Tarjeta = "DB"
                End If

                _Pagado = True
                _Respuesta = "0260|00|555444333222|E1100455" &
                             "|" & _Idmaeedo &
                             "|" & _Cod_Autorizacion &
                             "|" & numero_(_Monto, 10) &
                             "|" & _Nro_Tarjeta &
                             "|" & _Nro_Operacion &
                             "|" & _Tarjeta &
                             "|||MC|" & Format(_Fecha, "ddMMyyyy") & "|" & FormatDateTime(_Fecha, DateFormat.ShortTime) & "|0"
                'Dim _Datos_Respuesta_Prb = Split(_Respuesta, "|")

                _Status = "APROBADO"
                _1R_Pagado = True
                _1R_Respuesta = _Respuesta
                _1R_Status = _Status
                _Cerrado_por_usuario_o_tiempo = False
                _Commando_Transbank = "Prueba manual Bakapp"

            ElseIf _Accion = DialogResult.No Then

                Return False

            ElseIf _Accion = DialogResult.Cancel Then

                _Cerrado_por_usuario_o_tiempo = True

            End If

        Else

            Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, _Idmaeedo, _Monto,
                                   Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Transaccion_Venta, True)
            Fm.Btn_Cancelar.Visible = False
            Fm.ShowDialog(Me)
            _Puerto_Serial_Bloqueado = Fm.Pro_Puerto_Bloqueado

            If _Puerto_Serial_Bloqueado Then

                ToastNotification.Show(Me, "PROBLEMAS DE COMUNICACION CON PUERTO SERIAL", My.Resources.cross,
                                           8 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                ' 2 Segundos de demora
                Thread.Sleep(3000)
                Return False

            End If

            _Pagado = Fm.Pro_Pagado
            _Respuesta = Fm.Pro_Respuesta_Decodificada
            _Status = Fm.Pro_Status
            _1R_Pagado = _Pagado
            _1R_Respuesta = _Respuesta
            _1R_Status = _Status
            _Cerrado_por_usuario_o_tiempo = Fm.Pro_Cierra_Usuario
            _Commando_Transbank = Fm.Pro_Comando_Transaccion
            Fm.Dispose()

        End If

        'If _Cerrado_por_usuario_o_tiempo Then Return False

        Dim _Log_Datos_Ultima_Venta_Transbank As String
        Dim _Datos_Respuesta = Split(_Respuesta, "|")
        Dim _Cod_Respuesta

        Try
            _Cod_Respuesta = _Datos_Respuesta(1)
        Catch ex As Exception
            _Cod_Respuesta = "??"
        End Try


        Dim _Respuesta_Status = UCase(Fx_Tabla1_Respuestas(_Cod_Respuesta))

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                       "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia,Comando_Transbank,Respuesta_Transbank,Respuesta_Inicial) Values" & Space(1) &
                       "(Getdate(),'" & _Respuesta & "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ",'" & _Commando_Transbank & "','" & _1R_Respuesta & "',1)"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)


        If _Cod_Respuesta <> "??" And _Cod_Respuesta <> "00" Then

            Beep()
            ToastNotification.Show(Me, _Respuesta_Status,
                                   My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            _Pagado = False
            Return False

        End If

        Dim _Datos_Tarjeta = _Datos_Respuesta
        Dim _Datos_Desde_Ul_Venta_Por_Transbank As Boolean

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set " &
                       "Log_Datos_Ultima_Venta_Transbank = Log_Datos_Ultima_Venta_Transbank+' [" & _Datos_Tarjeta.Length & "]'" & vbCrLf &
                       "Where Id = " & _Id_Log_Transbank
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Buscar_Datos_Ult_Venta_Transbank As Boolean

        If _Datos_Tarjeta.Length >= 10 Then
            _Buscar_Datos_Ult_Venta_Transbank = False
        Else
            _Buscar_Datos_Ult_Venta_Transbank = True
        End If

        If _Buscar_Datos_Ult_Venta_Transbank Then

            Sb_Datos_Ult_Venta_Por_Transbank(_Log_Datos_Ultima_Venta_Transbank, _Row_Documento.Item("TIDO"))
            _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
            _Datos_Desde_Ul_Venta_Por_Transbank = True

        End If


        Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

        Try

            Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
            Dim _Numero_Ticket_Boleta_IDMAEEDO = CInt(_Datos_Tarjeta(4))
            Dim _Ultimo_Status = Fx_Tabla1_Respuestas(_Codigo_Respuesta)

            If _Numero_Ticket_Boleta_IDMAEEDO = _Idmaeedo Then

                _Respuesta = _Log_Datos_Ultima_Venta_Transbank
                _Status = UCase(_Ultimo_Status)

                If _Datos_Tarjeta(1) = "00" Then

                    _Pagado = True

                    Try

                        Dim _Comando = _Datos_Tarjeta(0)
                        Dim _Codigo_de_comercio = _Datos_Tarjeta(2)
                        Dim _Terminal_ID = _Datos_Tarjeta(3)
                        Dim _Numero_Ticket_Boleta = _Datos_Tarjeta(4)
                        Dim _Cod_Autorizacion = _Datos_Tarjeta(5)
                        Dim _Nro_Tarjeta = Rellenar(_Datos_Tarjeta(7), 20, "*", False)
                        Dim _Nro_Operacion = _Datos_Tarjeta(8)
                        Dim _Tipo_de_Tarjeta = _Datos_Tarjeta(9)
                        Dim _Marca As String

                        Try
                            _Marca = _Datos_Tarjeta(12)
                        Catch ex As Exception
                            _Marca = String.Empty
                        End Try

                        Dim _Voucher As String
                        Dim _Crear_Voucher_Bakapp = False

                        If _Datos_Desde_Ul_Venta_Por_Transbank Then

                            Try
                                _Voucher = _Datos_Tarjeta(15)
                                _Voucher = Replace(_Voucher, "*** DUPLICADO ***", Space(17))
                            Catch ex As Exception
                                _Crear_Voucher_Bakapp = True
                            End Try

                        Else

                            _Crear_Voucher_Bakapp = True

                        End If


                        If _Crear_Voucher_Bakapp Then

                            Dim _Fecha = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
                            Dim _Hora = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

                            _Voucher = Fx_Crear_Voucher_Transbank(_Tipo_de_Tarjeta, _Fecha, _Hora, _Nro_Tarjeta, _Monto,
                                                              _Numero_Ticket_Boleta, _Nro_Operacion, _Cod_Autorizacion, _Marca)

                        End If

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                                       "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia) Values" & Space(1) &
                                       "(Getdate(),'" & _Log_Datos_Ultima_Venta_Transbank & "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ")"
                        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set 
                                        Voucher = '" & _Voucher & "',
                                        Comando_Transbank = '" & _Commando_Transbank & "', 
                                        Respuesta_Transbank = '" & _1R_Respuesta & "' Where Id = " & _Id_Log_Transbank
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        _Respuesta = "Nro. Tarjeta: " & _Nro_Tarjeta & "," &
                                     "Nro. Operación: " & _Nro_Operacion & "," &
                                     "Cód.Autorización: " & _Cod_Autorizacion & "," &
                                     "Terminal Id: " & _Terminal_ID & "," &
                                     "Cód.Comercio: " & _Codigo_de_comercio & " Id_Log_Transbank = " & _Id_Log_Transbank

                    Catch ex As Exception

                        _Log_Error = "Revisar [Zw_CashDro_Transbank_Log], Id_Log_Transbank = " & _Id_Log_Transbank
                        _Respuesta = String.Empty

                    End Try

                ElseIf _Codigo_Respuesta = "01" Then

                    Beep()
                    ToastNotification.Show(Me, "RECHAZADO",
                                   My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
                    _Pagado = False

                Else

                    _Pagado = False

                End If

            End If

        Catch ex As Exception
            _Log_Error = ex.Message & " Error al recibir la respuesta desde la Máquina Transbank"
            _Respuesta = String.Empty
            _Id_Log_Transbank = 0
        End Try



        If Not _Pagado And _1R_Pagado Then
            _Pagado = _1R_Pagado
            _Status = _1R_Status
            _Respuesta = _1R_Respuesta
        End If

        If _Pagado Then
            Sb_Transformar_Vale_Transitorio_En_Documento(_Row_Documento, _Id, "TJV")
        End If

        _Respuesta = Replace(_Respuesta, "'", "")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                       "Pagado_Transbank = " & CInt(_Pagado) * -1 & "," &
                       "Log_Error = '" & _Log_Error & "'," &
                       "Status_Tarjeta = '" & _Status & "'," &
                       "Respuesta_Tarjeta = '" & _Respuesta & "'," &
                       "FechaHora_Fin = Getdate()," &
                       "Id_Log_Transbank = " & _Id_Log_Transbank & vbCrLf &
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Pagado Then
            'Sb_Pagar_Pendientes_Tarjeta(False)
        Else
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Fm_Espera.Dispose()

        Return _Pagado

    End Function

    Function Fx_Pago_Tarjeta_Post_Integrado(_Row_Documento As DataRow, _Pago_Efectivo_Tarjeta As Boolean) As Boolean

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")
        Dim _Log_Error As String

        Dim _Id As Integer = 0

        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones",
                                                  "COALESCE(MAX(Numero),'0000000000')")
        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _posuser As String = FUNCIONARIO

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Monto,Modalidad,Empresa,Sucursal,Bodega,Caja,Idmaeedo_H) Values " & vbCrLf &
                       "('" & _Numero & "','',GetDate(),'" & _posid & "','" & _posuser & "'," & De_Num_a_Tx_01(_Monto, False, 5) & ",'" & Modalidad & "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "'," & _Idmaeedo & ")"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

        If _Pago_Efectivo_Tarjeta Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Idmaeedo = " & _Idmaeedo & vbCrLf &
                           "Where Id =" & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Dim _Pagado As Boolean
        Dim _Respuesta As String = String.Empty
        Dim _Status As String = String.Empty

        Dim _1R_Pagado As Boolean
        Dim _1R_Respuesta As String = String.Empty
        Dim _1R_Status As String = String.Empty

        Dim _Puerto_Serial_Bloqueado As Boolean

        Dim _Cerrado_por_usuario_o_tiempo As Boolean
        Dim _Commando_Transbank As String
        Dim _Id_Log_Transbank = 0

        Dim Fm_Espera As New Frm_Form_Esperar

        If _Fase_Prueba_Tarjeta Then

            Dim _Accion = MessageBoxEx.Show(Me, "Yes = Pagar" & vbCrLf &
                                 "No = Cancelar" & vbCrLf &
                                 "Cancelar = Cancelado por el usuario en Transbank o tiempo",
                                 "Pruebas Transbank", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If _Accion = DialogResult.Yes Then

                Dim _Random As New Random()
                Dim _Fecha = FechaDelServidor()

                Dim _Cod_Autorizacion = _Random.Next(10000, 99999)
                Dim _Nro_Tarjeta = Rellenar(_Random.Next(1000, 9999), 20, "*", False)
                Dim _Nro_Operacion = _Random.Next(10000, 99999)
                Dim _Tj = _Random.Next(-10, 10)
                Dim _Tarjeta As String

                If _Tj <= 0 Then
                    _Tarjeta = "CR"
                ElseIf _Tj > 0 Then
                    _Tarjeta = "DB"
                End If

                _Pagado = True
                _Respuesta = "0260|00|555444333222|E1100455" &
                             "|" & _Idmaeedo &
                             "|" & _Cod_Autorizacion &
                             "|" & numero_(_Monto, 10) &
                             "|" & _Nro_Tarjeta &
                             "|" & _Nro_Operacion &
                             "|" & _Tarjeta &
                             "|||MC|" & Format(_Fecha, "ddMMyyyy") & "|" & FormatDateTime(_Fecha, DateFormat.ShortTime) & "|0"
                'Dim _Datos_Respuesta_Prb = Split(_Respuesta, "|")

                _Status = "APROBADO"
                _1R_Pagado = True
                _1R_Respuesta = _Respuesta
                _1R_Status = _Status
                _Cerrado_por_usuario_o_tiempo = False
                _Commando_Transbank = "Prueba manual Bakapp"

            ElseIf _Accion = DialogResult.No Then

                Return False

            ElseIf _Accion = DialogResult.Cancel Then

                _Cerrado_por_usuario_o_tiempo = True

            End If

        Else

            Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, _Idmaeedo, _Monto,
                                   Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Transaccion_Venta, True)
            Fm.Btn_Cancelar.Visible = False
            Fm.ShowDialog(Me)
            _Puerto_Serial_Bloqueado = Fm.Pro_Puerto_Bloqueado

            If _Puerto_Serial_Bloqueado Then

                ToastNotification.Show(Me, "PROBLEMAS DE COMUNICACION CON PUERTO SERIAL", My.Resources.cross,
                                           8 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                ' 2 Segundos de demora
                Thread.Sleep(3000)
                Return False

            End If

            _Pagado = Fm.Pro_Pagado
            _Respuesta = Fm.Pro_Respuesta_Decodificada
            _Status = Fm.Pro_Status
            _1R_Pagado = _Pagado
            _1R_Respuesta = _Respuesta
            _1R_Status = _Status
            _Cerrado_por_usuario_o_tiempo = Fm.Pro_Cierra_Usuario
            _Commando_Transbank = Fm.Pro_Comando_Transaccion
            Fm.Dispose()

        End If

        'If _Cerrado_por_usuario_o_tiempo Then Return False

        Dim _Log_Datos_Ultima_Venta_Transbank As String
        Dim _Datos_Respuesta = Split(_Respuesta, "|")
        Dim _Cod_Respuesta

        Try
            _Cod_Respuesta = _Datos_Respuesta(1)
        Catch ex As Exception
            _Cod_Respuesta = "??"
        End Try


        Dim _Respuesta_Status = UCase(Fx_Tabla1_Respuestas(_Cod_Respuesta))

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                       "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia,Comando_Transbank,Respuesta_Transbank,Respuesta_Inicial) Values" & Space(1) &
                       "(Getdate(),'" & _Respuesta & "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ",'" & _Commando_Transbank & "','" & _1R_Respuesta & "',1)"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)


        If _Cod_Respuesta <> "??" And _Cod_Respuesta <> "00" Then

            Beep()
            ToastNotification.Show(Me, _Respuesta_Status,
                                   My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            _Pagado = False
            Return False

        End If

        Dim _Datos_Tarjeta = _Datos_Respuesta
        Dim _Datos_Desde_Ul_Venta_Por_Transbank As Boolean

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set " &
                       "Log_Datos_Ultima_Venta_Transbank = Log_Datos_Ultima_Venta_Transbank+' [" & _Datos_Tarjeta.Length & "]'" & vbCrLf &
                       "Where Id = " & _Id_Log_Transbank
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Buscar_Datos_Ult_Venta_Transbank As Boolean

        If _Datos_Tarjeta.Length >= 10 Then
            _Buscar_Datos_Ult_Venta_Transbank = False
        Else
            _Buscar_Datos_Ult_Venta_Transbank = True
        End If

        If _Buscar_Datos_Ult_Venta_Transbank Then

            Sb_Datos_Ult_Venta_Por_Transbank(_Log_Datos_Ultima_Venta_Transbank, _Row_Documento.Item("TIDO"))
            _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
            _Datos_Desde_Ul_Venta_Por_Transbank = True

        End If


        Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

        Try

            Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
            Dim _Numero_Ticket_Boleta_IDMAEEDO = CInt(_Datos_Tarjeta(4))
            Dim _Ultimo_Status = Fx_Tabla1_Respuestas(_Codigo_Respuesta)

            If _Numero_Ticket_Boleta_IDMAEEDO = _Idmaeedo Then

                _Respuesta = _Log_Datos_Ultima_Venta_Transbank
                _Status = UCase(_Ultimo_Status)

                If _Datos_Tarjeta(1) = "00" Then

                    _Pagado = True

                    Try

                        Dim _Comando = _Datos_Tarjeta(0)
                        Dim _Codigo_de_comercio = _Datos_Tarjeta(2)
                        Dim _Terminal_ID = _Datos_Tarjeta(3)
                        Dim _Numero_Ticket_Boleta = _Datos_Tarjeta(4)
                        Dim _Cod_Autorizacion = _Datos_Tarjeta(5)
                        Dim _Nro_Tarjeta = Rellenar(_Datos_Tarjeta(9), 20, "*", False)
                        Dim _Nro_Operacion = _Datos_Tarjeta(10)
                        Dim _Tipo_de_Tarjeta = _Datos_Tarjeta(11)
                        Dim _Marca As String

                        Try
                            _Marca = _Datos_Tarjeta(14)
                        Catch ex As Exception
                            _Marca = String.Empty
                        End Try

                        Dim _Voucher As String
                        Dim _Crear_Voucher_Bakapp = False

                        'If _Datos_Desde_Ul_Venta_Por_Transbank Then

                        '    Try
                        '        _Voucher = _Datos_Tarjeta(15)
                        '        _Voucher = Replace(_Voucher, "*** DUPLICADO ***", Space(17))
                        '    Catch ex As Exception
                        '        _Crear_Voucher_Bakapp = True
                        '    End Try

                        'Else

                        _Crear_Voucher_Bakapp = True

                        'End If

                        If _Crear_Voucher_Bakapp Then

                            Dim _Fecha = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
                            Dim _Hora = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

                            _Voucher = Fx_Crear_Voucher_Transbank(_Tipo_de_Tarjeta, _Fecha, _Hora, _Nro_Tarjeta, _Monto,
                                                              _Numero_Ticket_Boleta, _Nro_Operacion, _Cod_Autorizacion, _Marca)

                        End If

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                                       "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia) Values" & Space(1) &
                                       "(Getdate(),'" & _Log_Datos_Ultima_Venta_Transbank & "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ")"
                        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set 
                                        Voucher = '" & _Voucher & "',
                                        Comando_Transbank = '" & _Commando_Transbank & "', 
                                        Respuesta_Transbank = '" & _1R_Respuesta & "' Where Id = " & _Id_Log_Transbank
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        _Respuesta = "Nro. Tarjeta: " & _Nro_Tarjeta & "," &
                                     "Nro. Operación: " & _Nro_Operacion & "," &
                                     "Cód.Autorización: " & _Cod_Autorizacion & "," &
                                     "Terminal Id: " & _Terminal_ID & "," &
                                     "Cód.Comercio: " & _Codigo_de_comercio & " Id_Log_Transbank = " & _Id_Log_Transbank

                    Catch ex As Exception

                        _Log_Error = "Revisar [Zw_CashDro_Transbank_Log], Id_Log_Transbank = " & _Id_Log_Transbank
                        _Respuesta = String.Empty

                    End Try

                ElseIf _Codigo_Respuesta = "01" Then

                    Beep()
                    ToastNotification.Show(Me, "RECHAZADO",
                                   My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
                    _Pagado = False

                Else

                    _Pagado = False

                End If

            End If

        Catch ex As Exception
            _Log_Error = ex.Message & " Error al recibir la respuesta desde la Máquina Transbank"
            _Respuesta = String.Empty
            _Id_Log_Transbank = 0
        End Try



        If Not _Pagado And _1R_Pagado Then
            _Pagado = _1R_Pagado
            _Status = _1R_Status
            _Respuesta = _1R_Respuesta
        End If

        If _Pagado Then
            Sb_Transformar_Vale_Transitorio_En_Documento(_Row_Documento, _Id, "TJV")
        End If

        _Respuesta = Replace(_Respuesta, "'", "")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                       "Pagado_Transbank = " & CInt(_Pagado) * -1 & "," &
                       "Log_Error = '" & _Log_Error & "'," &
                       "Status_Tarjeta = '" & _Status & "'," &
                       "Respuesta_Tarjeta = '" & _Respuesta & "'," &
                       "FechaHora_Fin = Getdate()," &
                       "Id_Log_Transbank = " & _Id_Log_Transbank & vbCrLf &
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Pagado Then
            'Sb_Pagar_Pendientes_Tarjeta(False)
        Else
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Fm_Espera.Dispose()

        Return _Pagado

    End Function

    Function Fx_Extraer_Datos_Desde_Transbank(_Log_Datos_Ultima_Venta_Transbank As String,
                                              _Idmaeedo As Integer) As Boolean

        _Log_Datos_Ultima_Venta_Transbank = Replace(_Log_Datos_Ultima_Venta_Transbank, "'", "")

        Dim _Respuesta As String
        Dim _Status As String

        Dim _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
        Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

        Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
        Dim _Numero_Ticket_Boleta_IDMAEEDO = CInt(_Datos_Tarjeta(4))
        Dim _Ultimo_Status = Fx_Tabla1_Respuestas(_Codigo_Respuesta)

        If _Numero_Ticket_Boleta_IDMAEEDO = _Idmaeedo Then

            _Respuesta = _Log_Datos_Ultima_Venta_Transbank
            _Status = UCase(_Ultimo_Status)

            If _Codigo_Respuesta = "00" Then

                Dim _Comando As String
                Dim _Codigo_de_comercio = String.Empty
                Dim _Terminal_ID = String.Empty
                'Dim _Numero_Ticket_Boleta = String.Empty
                Dim _Codigo_Autorizacion = String.Empty
                Dim _Ultimos_4_Digitos_Tarjeta = String.Empty
                Dim _Numero_Operacion = String.Empty

                Try

                    _Comando = _Datos_Tarjeta(0)
                    _Codigo_Respuesta = _Datos_Tarjeta(1)
                    _Codigo_de_comercio = _Datos_Tarjeta(2)
                    _Terminal_ID = _Datos_Tarjeta(3)
                    '_Numero_Ticket_Boleta = _Datos_Tarjeta(4)
                    _Codigo_Autorizacion = _Datos_Tarjeta(5)
                    _Ultimos_4_Digitos_Tarjeta = Rellenar(_Datos_Tarjeta(7), 20, "*", False)


                    Return True

                Catch ex As Exception
                    Return False
                End Try

            End If

        End If

    End Function

    Sub Sb_Datos_Ult_Venta_Por_Transbank(ByRef _Log_Datos_Ultima_Venta_Transbank As String, _Tido As String)

        Dim _Intentos = 3

        Dim _Documento As String
        Dim _Puerto_Serial_Bloqueado As Boolean

        If _Tido = "BLV" Then
            _Documento = "BOLETA"
        ElseIf _Tido = "FCV" Then
            _Documento = "FACTURA"
        End If

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.Pro_Texto = "RESCATANDO DATOS DESDE DISPOSITIVO TRANSBANK, ESPERE POR FAVOR..."
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        For _in = 1 To _Intentos
            Dim Fm_Log As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, "0", 0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Datos_Ultima_Venta, True)
            Fm_Log.WindowState = FormWindowState.Minimized
            Fm_Log.ShowDialog(Me)
            _Puerto_Serial_Bloqueado = Fm_Log.Pro_Puerto_Bloqueado
            _Log_Datos_Ultima_Venta_Transbank = Fm_Log.Pro_Respuesta_Decodificada
            Fm_Log.Dispose()
            If Not _Puerto_Serial_Bloqueado Then Exit For
        Next

        Fm_Espera.Dispose()

    End Sub

    Function Fx_Pago_Nota_De_Credito(ByVal _Row_Documento As DataRow) As Boolean

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
        Dim _Row_Operaciones As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id As Integer = _Row_Operaciones.Item("Id")
        Dim _Numero As String = _Row_Operaciones.Item("Numero")

        Sb_Transformar_Vale_Transitorio_En_Documento(_Row_Documento, _Id, "ncv")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"

        Dim _TblNCV As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _TblNCV.Rows

            Dim _Idmaeedo_NCV As Integer = _Fila.Item("Idmaeedo_NCV")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                           "FechaHora_Fin = Getdate(),Venta_Generada = 1," &
                           "Tipo_De_Pago = 'ncv',Pagado_CashDro = 1," &
                           "Idmaeedo = " & _Idmaeedo & vbCrLf &
                           "Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Next

        Return True

    End Function

    Function Fx_Pago_Efectivo_Tarjeta(ByVal _Row_Documento As DataRow) As Boolean

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")

        Dim _OperationId As String
        Dim _Pagado As Boolean
        Dim _Cancelado As Boolean
        Dim _Tiempo_Caducado As Boolean
        Dim _Error As String

        Dim _Monto_Efectivo As Double

        Dim _Ult_Digito As Integer = Mid(_Monto, Len(Str(_Monto)) - 1, 1)
        Dim _Ajuste_Sencillo As Integer = 0

        If CBool(_Ult_Digito) Then
            If _Ult_Digito < 5 Then
                _Monto -= _Ult_Digito
                _Ajuste_Sencillo = -_Ult_Digito
            Else
                _Monto = _Monto + (10 - _Ult_Digito)
                _Ajuste_Sencillo = 10 - _Ult_Digito
            End If
        End If


        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones",
                                                  "COALESCE(MAX(Numero),'0000000000')")

        If String.IsNullOrEmpty(_Numero) Then _Numero = "0000000000"

        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _Id As Integer = 0

        Dim _Aceptar As Boolean

        Dim Fm_ET As New Frm_Cashdro_Pago_Efectivo_y_Tarjeta(_Monto)
        Fm_ET.ShowDialog(Me)
        _Aceptar = Fm_ET.Pro_Aceptar
        If _Aceptar Then _Monto_Efectivo = Fm_ET.Pro_Monto
        Fm_ET.Dispose()

        If Not _Aceptar Then
            Return False
        End If

        If _Fase_Prueba_Efectivo Then

            _Pagado = True

            Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
            Dim _posuser As String = FUNCIONARIO

            _OperationId = String.Empty

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Idmaeedo," &
                           "Tipo_De_Pago,Monto,Ajuste_Sencillo,Modalidad,Empresa,Sucursal,Bodega,Caja,Idmaeedo_H) Values " & vbCrLf &
                           "('" & _Numero & "','" & _OperationId & "',GetDate(),'" & _posid & "','" & _posuser & "'," & _Idmaeedo &
                           ",'EFV'," & _Monto_Efectivo & "," & _Ajuste_Sencillo &
                           ",'" & Modalidad & "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "'," & _Idmaeedo & ")"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

        Else

            Dim Fm As New Frm_Cashdro_Pago_Efectivo(_Monto_Efectivo, _Row_CashDro, _Idmaeedo)

            If String.IsNullOrEmpty(Fm.Pro_Error) Then
                Fm.ShowDialog(Me)
                _OperationId = Fm.Pro_Operation_Id
                _Pagado = Fm.Pro_Pagado
                _Cancelado = Fm.Pro_Cancelado
                _Tiempo_Caducado = Fm.Pro_Tiempo_Caducado
                _Numero = Fm.Pro_Numero
                _Id = Fm.Pro_Id
            End If

            _Error = Fm.Pro_Error

            Fm.Dispose()
        End If

        If Not String.IsNullOrEmpty(_Error) Then
            MessageBoxEx.Show(Me, _Error & vbCrLf & vbCrLf &
                              "Todos los pagos seran reversados", "Problema",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If _Pagado Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Idmaeedo = " & _Idmaeedo & ",Ajuste_Sencillo = " & _Ajuste_Sencillo & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)


                Dim _Saldo As Double = _Row_Documento.Item("SALDO_ANTERIOR")
                _Saldo = _Saldo - _Monto_Efectivo
                _Row_Documento.Item("SALDO_ANTERIOR") = _Saldo

            ElseIf _Cancelado Then

                Beep()

                If _Tiempo_Caducado Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Cancelado_Por_Tiempo = 1,FechaHora_Fin = Getdate()" & vbCrLf &
                                  "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    ToastNotification.Show(Me, "TIEMPO DE ESPERA TERMINO",
                                           My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Cancelado_Por_Usuario = 1,FechaHora_Fin = Getdate()" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    ToastNotification.Show(Me, "CANCELADO POR EL USUARIO",
                                                           My.Resources.cross,
                                                           2 * 1000, eToastGlowColor.Red,
                                                           eToastPosition.MiddleCenter)
                End If

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                               "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If
        End If

        If _Pagado Then

            'If _Version_Transbank = 1 Then
            '    _Pagado = Fx_Pago_Tarjeta_Version_1(_Row_Documento, True)
            'ElseIf _Version_Transbank = 2 Then
            '    _Pagado = Fx_Pago_Tarjeta_Version_2(_Row_Documento, True)
            'ElseIf _Version_Transbank = 3 Then
            '    _Pagado = Fx_Pago_Tarjeta_Version_3(_Row_Documento, True)
            'End If

            If _Post_Autoservicio Then _Pagado = Fx_Pago_Tarjeta_Version_3(_Row_Documento, True)
            If _Post_Integrado Then _Pagado = Fx_Pago_Tarjeta_Post_Integrado(_Row_Documento, True)

            If _Pagado Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Pagado_CashDro = 1" & vbCrLf &
                               "Where Idmaeedo = " & _Idmaeedo
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                Else

                    'Devolucion de efectivo
                    If Not _Fase_Prueba_Efectivo Then

                        Dim Fm As New Frm_Cashdro_Devolucion_Efectivo(_Monto_Efectivo, _Row_CashDro, Nothing)

                        If String.IsNullOrEmpty(Fm.Pro_Error) Then
                            Fm.ShowDialog(Me)
                        End If
                        _Error = Fm.Pro_Error
                        Fm.Dispose()

                    End If

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Log_Error = '" & _Error & "',Vuelto = " & _Monto_Efectivo & vbCrLf &
                               "Where Idmaeedo = " & _Idmaeedo & " And Tipo_De_Pago = 'EFV'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

            If Not _Pagado Then

            'Borramos los pagos generados por Notas de credito, Efectivo y Tarjeta de este documento
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                           "Idmaeedo = 0,FechaHora_Fin = Getdate(),Log_Error = Case Tipo_De_Pago When 'EFV' Then 'Transacción cancelada en Transbank... Se reversan los pagos' Else '' End" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Txt_Documento_Venta.Text = String.Empty
        Txt_Documento_Venta.Focus()
        Me.Refresh()

        Return _Pagado

    End Function

    Sub Sb_Pago_Vuelto(ByVal _Row_Operacion_NCV As DataRow)

        'Dim _Padre_OperationId = _Row_Operacion_NCV.Item("OperationId")
        Dim _Padre_Id = _Row_Operacion_NCV.Item("Id")
        Dim _Idmaeedo_NCV As Integer = _Row_Operacion_NCV.Item("Idmaeedo_NCV")
        Dim _Nudo_NCV As String = _Row_Operacion_NCV.Item("Nudo_NCV")
        Dim _Monto As Double = _Row_Operacion_NCV.Item("Vuelto")
        Dim _Vuelto As Double = _Row_Operacion_NCV.Item("Vuelto")

        Dim _Ult_Digito As Integer = Mid(_Monto, Len(Str(_Monto)) - 1, 1)
        Dim _Ajuste_Sencillo As Integer = 0

        If CBool(_Ult_Digito) Then
            If _Ult_Digito < 5 Then
                _Monto -= _Ult_Digito
                _Ajuste_Sencillo = -_Ult_Digito
            Else
                _Monto = _Monto + (10 - _Ult_Digito)
                _Ajuste_Sencillo = 10 - _Ult_Digito
            End If
        End If

        _Ajuste_Sencillo = _Ajuste_Sencillo * -1

        Dim _Modalidad = _Row_Operacion_NCV.Item("Modalidad")
        Dim _Empresa = _Row_Operacion_NCV.Item("Empresa")
        Dim _Sucursal = _Row_Operacion_NCV.Item("Sucursal")
        Dim _Bodega = _Row_Operacion_NCV.Item("Bodega")
        Dim _Caja = _Row_Operacion_NCV.Item("Caja")

        Dim _OperationId As String
        Dim _Pagado As Boolean
        Dim _Cancelado As Boolean
        Dim _Tiempo_Caducado As Boolean
        Dim _Error As String

        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones",
                                                 "COALESCE(MAX(Numero),'0000000000')")
        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _Id As Integer

        If _Fase_Prueba_Nota_De_Credito Or _Fase_Prueba_Efectivo Then

            _Pagado = True

            Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
            Dim _posuser As String = FUNCIONARIO

            _OperationId = String.Empty 'Fx_Proximo_NroDocumento(_OperationId, 5)

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser," &
                           "Tipo_De_Pago,Idmaeedo,Tido,Nudo,Modalidad,Empresa,Sucursal,Bodega,Caja,Monto,Padre_Id,Vuelto) Values " & vbCrLf &
                           "('" & _Numero & "','" & _OperationId & "',GetDate(),'" & _posid & "','" & _posuser & "','EFC'," & _Idmaeedo_NCV &
                           ",'NCV','" & _Nudo_NCV &
                           "','" & _Modalidad & "','" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Caja &
                           "'," & De_Num_a_Tx_01(_Monto, False, 5) & ",'" & _Padre_Id &
                           "'," & De_Num_a_Tx_01(_Vuelto, False, 5) & ")"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)
            ' _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            Dim Fm As New Frm_Cashdro_Devolucion_Efectivo(_Monto, _Row_CashDro, _Row_Operacion_NCV)

            If String.IsNullOrEmpty(Fm.Pro_Error) Then
                Fm.ShowDialog(Me)
                _OperationId = Fm.Pro_Operation_Id
                _Pagado = Fm.Pro_Pagado
                _Cancelado = Fm.Pro_Cancelado
                _Tiempo_Caducado = Fm.Pro_Tiempo_Caducado
                _Id = Fm.Pro_Id
                _Numero = Fm.Pro_Numero
            End If

            _Error = Fm.Pro_Error

            Fm.Dispose()
        End If

        If Not String.IsNullOrEmpty(_Error) Then
            MessageBoxEx.Show(Me, _Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If _Pagado Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Pagado_CashDro = 1,FechaHora_Fin = Getdate(),Ajuste_Sencillo = " & _Ajuste_Sencillo & vbCrLf &
                               "Where Id = " & _Id &
                               vbCrLf &
                               vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Vuelto_Entregado = 1" & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

            ElseIf _Cancelado Then

                Beep()

                If _Tiempo_Caducado Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Cancelado_Por_Tiempo = 1,FechaHora_Fin = Getdate()" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    ToastNotification.Show(Me, "TIEMPO DE ESPERA TERMINO",
                                           My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Cancelado_Por_Usuario = 1,FechaHora_Fin = Getdate()" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    ToastNotification.Show(Me, "CANCELADO POR EL USUARIO",
                                                           My.Resources.cross,
                                                           2 * 1000, eToastGlowColor.Red,
                                                           eToastPosition.MiddleCenter)
                End If


            End If

        End If

        Txt_Documento_Venta.Text = String.Empty
        Txt_Documento_Venta.Focus()
        Me.Refresh()

    End Sub

    Sub Sb_Nuevo_Pago(ByVal _Tido_Nudo As String, ByVal _Monto As Double)

        Dim Fm As New Frm_Pagos_Documentos(_Impresora)
        Fm.Sb_Nuevo_Documento()

        If Fm.Fx_Buscar_Documento(_Tido_Nudo, False) Then

            Dim _Fila As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

            _Fila.Cells("TIDP").Value = "EFV"
            _Fila.Cells("ESPGDP").Value = "C"
            _Fila.Cells("VADP").Value = _Monto
            'Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("VADP")

            Fm.Sb_Sumar_Totales()
            Fm.Sb_Grabar_Pago_A_Documento(False)

        End If
        Fm.Dispose()

    End Sub

    Function Fx_Row_Documento(ByVal _Nro_Documento As String) As DataRow

        Dim _Tido = Mid(_Nro_Documento, 1, 3)
        Dim _Nudo = Mid(_Nro_Documento, 4, 10)

        Consulta_sql = "SELECT top 1 EMPRESA,IDMAEEDO,TIDO,NUDO,ENDO,SUDO,TIMODO,MODO,NUVEDO," &
                       "FE01VEDO,VABRDO,VABRDO-VAABDO AS SALDO_ANTERIOR,VAABDO," &
                       "CAST(0 AS FLOAT) AS PAGO_ACTUAL," &
                       "CAST(0 AS FLOAT) AS PAGO_CHEQUE," &
                       "CAST(0 AS FLOAT) AS SALDO_ACTUAL," &
                       "CAST(0 AS FLOAT) AS ABONADO_NCV," &
                       "NUDONODEFI,VAPIDO,SUENDO,FEULVEDO,HORAGRAB," &
                       "MAEEN.NOKOEN,ESPGDO,ESDO" & vbCrLf &
                       "FROM MAEEDO AS EDO WITH ( NOLOCK ) LEFT OUTER JOIN MAEEN ON ENDO=MAEEN.KOEN AND" & Space(1) &
                       "SUENDO=MAEEN.SUEN" & vbCrLf &
                       "WHERE EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' AND NUDO = '" & _Nudo & "'" & vbCrLf &
                       "AND TIDO IN ( 'BLV','BSV','FCV','FDV','NCV' )"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not (_Tbl Is Nothing) Then

            If CBool(_Tbl.Rows.Count) Then

                If _Tbl.Rows(0).Item("ESPGDO") <> "P" Then
                    'Beep()
                    'ToastNotification.Show(Me, "SOLO DOUCMENTOS PENDIENTES DE PAGO", _
                    '                       My.Resources.cross, _
                    '                       1 * 1000, eToastGlowColor.Red, _
                    '                       eToastPosition.MiddleCenter)

                    Beep()
                    ToastNotification.Show(Me, "DOCUMENTO PAGADO",
                                           My.Resources.cross,
                                           1 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)

                    Return Nothing
                End If

            Else
                If Not String.IsNullOrEmpty(_Nro_Documento) Then
                    Beep()
                    ToastNotification.Show(Me, "DOCUMENTO NO EXISTE",
                                           My.Resources.cross,
                                           1 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                    Return Nothing
                End If
            End If

            Return _Tbl.Rows(0)

        End If


    End Function

    Private Sub Frm_Cashdro_Ingreso_Documento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Dim _Key As Keys = e.KeyValue

        If _Key = Keys.Escape Then
            Me.Close()
        Else
            Txt_Documento_Venta.Focus()
            Me.Refresh()
        End If

    End Sub

    Private Sub Tiempo_Label_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Label.Tick

        'If RfLbl_Informacion.Visible Then
        '    RfLbl_Informacion.Visible = False
        '    RfImg_Flecha.Visible = False
        'Else
        '    RfLbl_Informacion.Visible = True
        'End If

        RfLbl_Informacion.Visible = Not RfLbl_Informacion.Visible
        RfImg_Flecha.Visible = Not RfImg_Flecha.Visible

        _Tiempo += 1

        Me.ActiveControl = Txt_Documento_Venta
        Txt_Documento_Venta.Select()
        Txt_Documento_Venta.Focus()
        Txt_Documento_Venta.SelectionStart = Txt_Documento_Venta.Text.Length

        Me.Refresh()

        If _Tiempo = 60 Then

            '    Me.WindowState = FormWindowState.Minimized

            '    Tiempo_Label.Stop()
            '    Sb_Pagar_Pendientes_Nota_De_Credito()
            '    Sb_Pagar_Pendientes_Vuelto_Casdro()
            '    Sb_Pagar_Pendientes_Efectivo(False)
            '    Sb_Pagar_Pendientes_Tarjeta(False)
            '    Tiempo_Label.Start()
            '    _Tiempo = 0
            _Volver_A_Cargar = True
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Teclado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Teclado.Click
        If _Teclado Then
            Fx_Activar_Deactivar_Teclado(False)
            _Teclado = False
        Else
            Fx_Activar_Deactivar_Teclado(True)
            _Teclado = True
        End If
    End Sub

    Function Fx_Activar_Deactivar_Teclado(ByVal _Teclado As Boolean)

        Dim _x = Me.Location.X
        Dim _Y = Me.Location.Y

        Dim _H = Me.Height

        Dim _Ancho_Teclado = TouchKeyboard1.Size.Width

        Dim _Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Dim _Left = (Screen.PrimaryScreen.WorkingArea.Width - _Ancho_Teclado) / 2

        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(_Left, _Y) ' _H)
        If _Teclado Then
            TouchKeyboard1.SetShowTouchKeyboard(Txt_Documento_Venta, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Floating)
        Else
            TouchKeyboard1.SetShowTouchKeyboard(Txt_Documento_Venta, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.No)
            TouchKeyboard1.HideKeyboard()
        End If

        Txt_Documento_Venta.Focus()

    End Function

    Private Sub Frm_Cashdro_Ingreso_Documento_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        Sb_Pagar()

    End Sub

    Private Sub Frm_Cashdro_Ingreso_Documento_Move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Move

        If (_Xpos > 0) Then
            Location = New Point(_Xpos, _Ypos)
        End If

    End Sub

    Sub Sb_Transformar_Vale_Transitorio_En_Documento(ByVal _Row_Documento As DataRow,
                                                     ByVal _Id As Integer,
                                                     ByVal _Tipo_De_Pago As String)

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Tido As String = _Row_Documento.Item("TIDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")
        Dim _Nudonodefi As Boolean = _Row_Documento.Item("NUDONODEFI")

        If _Tipo_De_Pago <> "ncv" Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                           "FechaHora_Fin = Getdate(),Venta_Generada = 1," &
                           "Tipo_De_Pago = '" & _Tipo_De_Pago & "',Pagado_CashDro = 1," &
                           "Idmaeedo = " & _Idmaeedo & vbCrLf &
                           "Where Id = " & _Id

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        If _Nudonodefi Then

            Dim _Iddt As Integer

            Dim _Nro_Documento As String = Traer_Numero_Documento(_Tido, , Modalidad)

            Dim _Tidoelec As Integer = CInt(Fx_Es_Electronico(_Tido)) * -1

            Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _Tido & "' And NUDO = '" & _Nro_Documento & "' And IDMAEEDO <> " & _Idmaeedo)

            If CBool(_Reg) Then
                _Nro_Documento = Traer_Numero_Documento(_Tido, , Modalidad) ' _Class_DTE.Pro_Nro_Documento
            End If

            Consulta_sql = "UPDATE MAEEDO SET NUDO='" & _Nro_Documento & "',NUDONODEFI=0,TIDOELEC=" & _Tidoelec & " WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                           "UPDATE MAEDDO SET NUDO='" & _Nro_Documento & "' WHERE IDMAEEDO=" & _Idmaeedo

            Consulta_sql = "UPDATE MAEEDO SET NUDO='" & _Nro_Documento & "',NUDONODEFI=0,TIDOELEC=" & _Tidoelec & " WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                           "UPDATE MAEDDO SET NUDO='" & _Nro_Documento & "' WHERE IDMAEEDO=" & _Idmaeedo

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                Fx_Cambiar_Numeracion_Modalidad(_Tido, Modalidad)

                ''FIRMA ELECTRONICA 

                If CBool(_Tidoelec) Then

                    Sb_Firmar_Documento_Electronico(Me, _Idmaeedo, _Tido)

                    'Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
                    'Dim _Firma_Bakapp As Boolean
                    'Dim _Firma_RunMonitor As Boolean

                    'Try
                    '    If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                    '        _Firma_Bakapp = True
                    '    Else
                    '        _Firma_RunMonitor = True
                    '    End If
                    'Catch ex As Exception
                    '    _Firma_RunMonitor = True
                    'End Try

                    'If _Firma_RunMonitor Then
                    '    _Iddt = _Class_DTE.Fx_Dte_Genera_Documento(Me, False)
                    '    If CBool(_Iddt) Then
                    '        _Class_DTE.Fx_Dte_Firma(Me, _Iddt, False)
                    '    End If
                    'End If

                    'If _Firma_Bakapp Then

                    '    Dim _Id_Dte As Integer
                    '    Dim _Icono As Image = My.Resources.Recursos_DTE.script_edit
                    '    Me.Cursor = Cursors.WaitCursor

                    '    Try
                    '        Lbl_Version.Text = "Versión: " & _Global_Version_BakApp & "... Firmando documento electrónico DTE"
                    '        Me.Refresh()

                    '        If CBool(_Class_DTE.Fx_FirmarXHefesto()) Then
                    '            ToastNotification.Show(Me, "FIRMADO...", _Icono, 3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                    '        End If

                    '    Catch ex As Exception
                    '    Finally
                    '        Me.Enabled = True
                    '        Application.DoEvents()
                    '        Me.Cursor = Cursors.Default
                    '    End Try

                    'End If

                End If

            End If

        End If


        ' ACTIVACION DE ORDENES DE DESPACHO *---------------------------------------------------------

        Consulta_sql = "Select IDRST From MAEDDO Where IDMAEEDO = " & _Idmaeedo
        Dim _TblDetalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Dim _Filtro_Idmaeddo_Dori = Generar_Filtro_IN(_TblDetalle, "", "IDRST", True, False, "")

        Consulta_sql = "Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det 
                            Where Idmaeedo In (Select IDMAEEDO From MAEDDO Where IDMAEDDO In " & _Filtro_Idmaeddo_Dori & ") Or Idmaeedo = " & _Idmaeedo
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fl As DataRow In _Tbl.Rows

            Dim _Id_Despacho = _Fl.Item("Id_Despacho")
            Dim _Cl_Despacho As New Clas_Despacho_Fx
            _Cl_Despacho.Sb_Actualizar_Despachos(_Id_Despacho)

        Next

        '************************************************************************************************

        ' IMPRIMIR EN DIABLITO

        If _Nudonodefi Then

            Dim _Cl_Imprimir As New Cl_Enviar_Impresion_Diablito
            _Cl_Imprimir.Fx_Enviar_Impresion_Al_Diablito(Modalidad, _Idmaeedo)

        End If

        '***********************************************************************************************

        _Ult_Idmaeedo = _Idmaeedo

    End Sub

    Sub Sb_Pagar_Pendientes_Efectivo(ByVal _Cerrar As Boolean)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Pagado_CashDro = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And Tipo_De_Pago = 'EFV'" & Space(1) &
                       "And posid = '" & _NombreEquipo & "' Order By Id Desc"
        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


        If CBool(_Tbl_Pagos_Pendientes.Rows.Count) Then

            Dim _Row_CashDro_Operaciones As DataRow = _Tbl_Pagos_Pendientes.Rows(0)
            Dim _Id = _Row_CashDro_Operaciones.Item("Id")
            Dim _OperationId = _Row_CashDro_Operaciones.Item("OperationId")
            Dim _Idmaeedo = _Row_CashDro_Operaciones.Item("Idmaeedo")
            Dim _Monto = _Row_CashDro_Operaciones.Item("Monto")
            Dim _Ajuste_Sencillo = _Row_CashDro_Operaciones.Item("Ajuste_Sencillo")

            _Monto -= _Ajuste_Sencillo

            Dim _Fecha_Pago As Date = FormatDateTime(_Row_CashDro_Operaciones.Item("FechaHora_Inicio"), DateFormat.ShortDate)
            Dim _Idmaedpce As Integer

            Consulta_sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                           "From MAEEDO" & vbCrLf &
                           "Where IDMAEEDO = " & _Idmaeedo
            Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_Row_Maeedo Is Nothing) Then

                Dim _Tido = _Row_Maeedo.Item("TIDO")
                Dim _Nudo = _Row_Maeedo.Item("NUDO")

                Dim Fm As New Frm_Pagos_Documentos(_Impresora)
                Fm.Sb_Nuevo_Documento()

                If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                    Dim _Fila As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                    _Fila.Cells("TIDP").Value = "EFV"
                    _Fila.Cells("ESPGDP").Value = "C"
                    _Fila.Cells("VADP").Value = _Monto
                    _Fila.Cells("FEEMDP").Value = _Fecha_Pago
                    _Fila.Cells("FEVEDP").Value = _Fecha_Pago

                    Fm.Sb_Sumar_Totales()
                    Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                End If
                Fm.Dispose()

                Consulta_sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                              "From MAEEDO" & vbCrLf &
                              "Where IDMAEEDO = " & _Idmaeedo
                _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_Row_Maeedo Is Nothing) Then

                    Dim _Espgdo = _Row_Maeedo.Item("ESPGDO")
                    Dim _Saldo = _Row_Maeedo.Item("SALDO")

                    If _Espgdo = "C" Or _Saldo = 0 Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                       "Tido = '" & _Tido & "'," &
                                       "Nudo = '" & _Nudo & "'," &
                                       "Pagado_Random = 1," &
                                       "FechaHora_Fin = Getdate()," &
                                       "Idmaedpce = " & _Idmaedpce & "," &
                                       "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                       "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    Else

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                       "Tido = '" & _Tido & "'," &
                                       "Nudo = '" & _Nudo & "'," &
                                       "Pagado_CashDro = 1," &
                                       "Pagado_Random = " & CInt(CBool(_Idmaedpce)) * -1 & "," &
                                       "FechaHora_Fin = Getdate()," &
                                       "Idmaedpce = " & _Idmaedpce & "," &
                                       "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                      "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                End If

                If _Cerrar Then
                    _Volver_A_Cargar = True
                    Me.Close()
                End If

            Else

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Idmaeedo = 0" & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

    End Sub

    Sub Sb_Pagar_Pendientes_Tarjeta(ByVal _Cerrar As Boolean)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Pagado_Transbank = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And" & Space(1) &
                       "Tipo_De_Pago = 'TJV' And Error_Extraccion_Respuesta_Transbank = 0" & Space(1) &
                       "And posid = '" & _NombreEquipo & "' Order By Id Desc"
        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Datos_Tarjeta
        Dim _Error_Extraccion_Respuesta_Transbank As Boolean

        Dim _Row_Maeedo As DataRow


        If CBool(_Tbl_Pagos_Pendientes.Rows.Count) Then

            Dim _Respuesta_Tarjeta As String

            Dim _Row_CashDro_Operaciones As DataRow = _Tbl_Pagos_Pendientes.Rows(0)

            Dim _Id = _Row_CashDro_Operaciones.Item("Id")
            Dim _OperationId = _Row_CashDro_Operaciones.Item("OperationId")
            Dim _Idmaeedo = _Row_CashDro_Operaciones.Item("Idmaeedo")
            Dim _Monto = _Row_CashDro_Operaciones.Item("Monto")
            Dim _Fecha_Pago As Date = FormatDateTime(_Row_CashDro_Operaciones.Item("FechaHora_Inicio"), DateFormat.ShortDate)


            _Respuesta_Tarjeta = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Transbank_Log", "Log_Datos_Ultima_Venta_Transbank",
                                                   "Idmaeedo_Referencia = " & _Idmaeedo & " Order By Id Desc")
            '_Row_CashDro_Operaciones.Item("Respuesta_Tarjeta")

            Dim _Comando = String.Empty
            Dim _Codigo_Respuesta = String.Empty
            Dim _Codigo_de_comercio = String.Empty
            Dim _Terminal_ID = String.Empty
            Dim _Numero_Ticket_Boleta = String.Empty
            Dim _Codigo_Autorizacion = String.Empty
            'Dim _Monto = _Datos_Tarjeta(6)
            Dim _Ultimos_4_Digitos_Tarjeta = String.Empty
            Dim _Numero_Operacion = String.Empty
            Dim _Tipo_de_Tarjeta = String.Empty
            Dim _Fecha_Contable = String.Empty
            Dim _Numero_de_Cuenta = String.Empty
            Dim _Emdp As String
            Dim _Idmaedpce As Integer

            Dim _Cod_Tarjeta = String.Empty


            Consulta_sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                           "From MAEEDO" & vbCrLf &
                           "Where IDMAEEDO = " & _Idmaeedo
            _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Tido = "???"
            Dim _Nudo = "???"

            If Not (_Row_Maeedo Is Nothing) Then
                _Tido = _Row_Maeedo.Item("TIDO")
                _Nudo = _Row_Maeedo.Item("NUDO")
            End If


            If Not String.IsNullOrEmpty(Trim(_Respuesta_Tarjeta)) Then

                _Datos_Tarjeta = Split(_Respuesta_Tarjeta, "|")

                Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

                Try

                    _Comando = _Datos_Tarjeta(0)
                    _Codigo_Respuesta = _Datos_Tarjeta(1)
                    _Codigo_de_comercio = _Datos_Tarjeta(2)
                    _Terminal_ID = _Datos_Tarjeta(3)
                    _Numero_Ticket_Boleta = _Datos_Tarjeta(4)
                    _Codigo_Autorizacion = _Datos_Tarjeta(5)
                    'Dim _Monto = _Datos_Tarjeta(6)
                    _Ultimos_4_Digitos_Tarjeta = Rellenar(_Datos_Tarjeta(7), 20, "*", False)
                    _Numero_Operacion = _Datos_Tarjeta(8)
                    _Tipo_de_Tarjeta = _Datos_Tarjeta(9)
                    _Emdp = _Datos_Tarjeta(12)
                    _Cod_Tarjeta = _Emdp
                    _Fecha_Contable = _Datos_Tarjeta(10)
                    _Numero_de_Cuenta = Trim(_Datos_Tarjeta(11))

                    If _Tipo_de_Tarjeta = "DB" Then _Emdp = "DB"

                    _Emdp = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla",
                                              "Tabla = 'TRANSBANK' And CodigoTabla = '" & _Emdp & "'")

                    If String.IsNullOrEmpty(_Emdp) Then
                        If _Tipo_de_Tarjeta = "CR" Then _Emdp = "CR"
                    End If

                Catch ex As Exception

                    _Error_Extraccion_Respuesta_Transbank = True

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Tido = '" & _Tido & "'," &
                                   "Nudo = '" & _Nudo & "'," &
                                   "Error_Extraccion_Respuesta_Transbank = 1," &
                                   "Log_Error = 'Revisar estado de cuentas en Transbank'," &
                                   "FechaHora_Fin = Getdate()" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                    Exit Sub

                End Try

            End If

            'Dim _Abreviacion_Tarjeta = _Datos_Tarjeta(12)
            'Dim _Fecha_Transaccion = _Datos_Tarjeta(13)
            'Dim _Hora_Transaccion = _Datos_Tarjeta(14)

            If Not (_Row_Maeedo Is Nothing) Then

                Dim Fm As New Frm_Pagos_Documentos(_Impresora)
                Fm.Sb_Nuevo_Documento()

                If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                    Dim _Fila As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                    _Fila.Cells("TIDP").Value = "TJV"
                    _Fila.Cells("ESPGDP").Value = "C"
                    _Fila.Cells("VADP").Value = _Monto

                    _Fila.Cells("EMDP").Value = _Emdp
                    _Fila.Cells("CUDP").Value = _Codigo_Autorizacion
                    _Fila.Cells("NUCUDP").Value = _Numero_Operacion

                    _Fila.Cells("REFANTI").Value = _Ultimos_4_Digitos_Tarjeta

                    _Fila.Cells("NUTRANSMI").Value = _Cod_Tarjeta
                    _Fila.Cells("DOCUENANTI").Value = _Terminal_ID
                    _Fila.Cells("FEEMDP").Value = _Fecha_Pago
                    _Fila.Cells("FEVEDP").Value = _Fecha_Pago

                    Fm.Sb_Sumar_Totales()
                    Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                End If
                Fm.Dispose()

                If CBool(_Idmaedpce) Then

                    Consulta_sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                          "From MAEEDO" & vbCrLf &
                          "Where IDMAEEDO = " & _Idmaeedo
                    _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)


                    If Not (_Row_Maeedo Is Nothing) Then

                        Dim _Espgdo = _Row_Maeedo.Item("ESPGDO")
                        Dim _Saldo = _Row_Maeedo.Item("SALDO")

                        If _Espgdo = "C" Or _Saldo = 0 Then

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                       "Tido = '" & _Tido & "'," &
                                       "Nudo = '" & _Nudo & "'," &
                                       "Pagado_Random = 1," &
                                       "FechaHora_Fin = Getdate()," &
                                       "Idmaedpce = " & _Idmaedpce & "," &
                                       "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                       "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        Else

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                       "Tido = '" & _Tido & "'," &
                                       "Nudo = '" & _Nudo & "'," &
                                       "Pagado_Random = 1," &
                                       "FechaHora_Fin = Getdate()," &
                                       "Idmaedpce = " & _Idmaedpce & "," &
                                       "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                       "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    End If

                    If _Cerrar Then
                        _Volver_A_Cargar = True
                        Me.Close()
                    End If

                End If

            Else

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                           "Idmaeedo = 0" & vbCrLf &
                           "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

    End Sub

    Sub Sb_Pagar_Pendientes_Nota_De_Credito()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Tipo_De_Pago in ('ncv','NCV') And" & Space(1) &
                       "Pagado_Nota_de_credito = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And posid = '" & _NombreEquipo & "' And Vuelto_Entregado = 0 Order By Id Desc"
        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


        If CBool(_Tbl_Pagos_Pendientes.Rows.Count) Then

            For Each _Row_Operacion_NCV As DataRow In _Tbl_Pagos_Pendientes.Rows

                Dim _Id = _Row_Operacion_NCV.Item("Id")
                Dim _OperationId = _Row_Operacion_NCV.Item("OperationId")
                Dim _Idmaeedo_DOC As Integer = _Row_Operacion_NCV.Item("Idmaeedo")
                Dim _Idmaeedo_NCV As Integer = _Row_Operacion_NCV.Item("Idmaeedo_NCV")
                Dim _Pagado_Nota_de_credito As Boolean = _Row_Operacion_NCV.Item("Pagado_Nota_de_credito")

                Dim _Monto As Double = _Row_Operacion_NCV.Item("Monto")
                Dim _Fecha_Pago As Date = FormatDateTime(_Row_Operacion_NCV.Item("FechaHora_Inicio"), DateFormat.ShortDate)
                Dim _Idmaedpce As Integer

                Dim _Vuelto = _Row_Operacion_NCV.Item("Vuelto")
                Dim _Saldo As Double

                Consulta_sql = "Select Top 1 IDMAEEDO,TIDO,NUDO,ENDO,ESPGDO,VAABDO,VABRDO,VABRDO - VAABDO AS SALDO" & vbCrLf &
                               "From MAEEDO" & vbCrLf &
                               "Where IDMAEEDO = " & _Idmaeedo_DOC
                Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


                If Not (_Row_Documento Is Nothing) Then

                    Dim _Tido = _Row_Documento.Item("TIDO")
                    Dim _Nudo = _Row_Documento.Item("NUDO")
                    Dim _Endo = _Row_Documento.Item("ENDO")
                    _Saldo = _Row_Documento.Item("SALDO")

                    If _Saldo > 0 Then

                        Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_NCV
                        Dim _Row_NCV As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Tido_NCV = _Row_NCV.Item("TIDO")
                        Dim _Nudo_NCV = _Row_NCV.Item("NUDO")
                        Dim _Endo_NCV = _Row_NCV.Item("ENDO")


                        Dim Fm As New Frm_Pagos_Documentos(_Impresora)
                        Fm.Sb_Nuevo_Documento()

                        If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                            Dim _Fila As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                            _Fila.Cells("TIDP").Value = "ncv"
                            _Fila.Cells("ESPGDP").Value = "C"
                            _Fila.Cells("VADP").Value = _Monto

                            Dim _Koen = _Endo
                            Dim _Rut = RutEmpresa

                            _Fila.Cells("ENDP").Value = _Rut
                            _Fila.Cells("EMDP").Value = _Koen
                            _Fila.Cells("FEEMDP").Value = _Fecha_Pago
                            _Fila.Cells("FEVEDP").Value = _Fecha_Pago

                            _Fila.Cells("REFANTI").Value = _Tido_NCV & "-" & _Nudo_NCV & "-" & _Endo_NCV
                            _Fila.Cells("IDMAEEDO").Value = _Idmaeedo_NCV
                            _Fila.Cells("SALDO").Value = _Monto

                            Fm.Sb_Sumar_Totales()
                            Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                        End If
                        Fm.Dispose()


                        Consulta_sql = "Select Top 1 TIDO,NUDO,ENDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                                      "From MAEEDO" & vbCrLf &
                                      "Where IDMAEEDO = " & _Idmaeedo_DOC
                        _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_sql)



                        If Not (_Row_Documento Is Nothing) Then

                            Dim _Espgdo = _Row_Documento.Item("ESPGDO")
                            _Saldo = _Row_Documento.Item("SALDO")

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                           "Tido = '" & _Tido & "'," &
                                           "Nudo = '" & _Nudo & "'," &
                                           "Pagado_Random = 1," &
                                           "FechaHora_Fin = Getdate()," &
                                           "Idmaedpce = " & _Idmaedpce & "," &
                                           "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                           "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    End If

                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Idmaeedo = 0" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Next

        End If

    End Sub

    Sub Sb_Pagar_Pendientes_Vuelto_Casdro()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Pagado_CashDro = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And Tipo_De_Pago = 'EFC'" & Space(1) &
                       "And posid = '" & _NombreEquipo & "' Order by Id Desc"
        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Row_Operacion As DataRow In _Tbl_Pagos_Pendientes.Rows

            Dim _Id = _Row_Operacion.Item("Id")
            Dim _OperationId = _Row_Operacion.Item("OperationId")
            Dim _Empresa = _Row_Operacion.Item("Empresa")
            Dim _Sucursal = _Row_Operacion.Item("Sucursal")
            Dim _Caja = _Row_Operacion.Item("Caja")

            Dim _Fecha_Emision As Date = FormatDateTime(_Row_Operacion.Item("FechaHora_Inicio"), DateFormat.ShortDate)
            Dim _Vuelto As Double = _Row_Operacion.Item("Vuelto")
            Dim _Monto As Double = _Row_Operacion.Item("Monto")

            Dim _Idmaeedo = _Row_Operacion.Item("Idmaeedo")

            Consulta_sql = "Select Top 1 *,Cast(1 As Bit) As Chk,Cast(" & De_Num_a_Tx_01(_Monto, False, 5) & " As Float) As SALDO,VABRDO-VAABDO As SALDO2" & vbCrLf &
                           "FROM MAEVEN AS VEN WITH ( NOLOCK )" & vbCrLf &
                           "INNER JOIN MAEEDO AS EDO ON EDO.IDMAEEDO=VEN.IDMAEEDO" & vbCrLf &
                           "LEFT JOIN MAEEN WITH (NOLOCK) ON MAEEN.KOEN=EDO.ENDO AND MAEEN.SUEN=EDO.SUENDO" & vbCrLf &
                           "LEFT JOIN TABSU ON TABSU.KOSU=EDO.SUDO" & vbCrLf &
                           "LEFT JOIN TABFU ON TABFU.KOFU=EDO.KOFUDO" & vbCrLf &
                           "LEFT JOIN TABLUG ON TABLUG.LUVT=EDO.LUVTDO" & vbCrLf &
                           "Where EDO.IDMAEEDO = " & _Idmaeedo

            Dim _Tbl_NCV As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Endo = _Tbl_NCV.Rows(0).Item("ENDO")
            Dim _Nudo = _Tbl_NCV.Rows(0).Item("NUDO")
            Dim _Vadp As Double

            If _Monto > _Vuelto Then
                _Vadp = _Monto
            Else
                _Vadp = _Vuelto
            End If

            ' 30 - 28
            ' 31 - 30

            If _Vadp > _Tbl_NCV.Rows(0).Item("SALDO") Then
                _Vadp = _Tbl_NCV.Rows(0).Item("SALDO")
            Else
                _Tbl_NCV.Rows(0).Item("SALDO") = _Vadp
            End If

            Consulta_sql = "SELECT TOP 1 * FROM MAEMO WHERE KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "' ORDER BY IDMAEMO DESC"
            Dim _RowMoneda_USdolar = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Tamodp As Double

            If Not IsNothing(_RowMoneda_USdolar) Then
                _Tamodp = _RowMoneda_USdolar.Item("VAMO")
            Else
                _Tamodp = 1
            End If

            Dim _Pagar As New Clas_Pagar
            Dim _Idmaedpce As Integer = _Pagar.Fx_Crear_Pago_y_Pagar("EFC", _Endo, "", _Empresa, _Sucursal, _Caja, "", "", "",
                                                                     _Fecha_Emision, _Fecha_Emision, "$", "N", _Tamodp,
                                                                     "Vuelto Cashdro NCV: " & _Nudo, 1,
                                                                     FUNCIONARIO, _Vadp,
                                                                     _Vadp, 0, "A", _Vadp, "C", 0, "", 0, 123456, _Tbl_NCV)


            If CBool(_Idmaedpce) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Pagado_Random = 1," &
                               "FechaHora_Fin = Getdate()," &
                               "Idmaedpce = " & _Idmaedpce & "," &
                               "Vuelto = 0," &
                               "Valor_Asignado = " & De_Num_a_Tx_01(_Vadp, False, 5) & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        Next

    End Sub

    Sub Sb_Pagar_NCV(ByVal _Row_CashDro_Operaciones As DataRow)


        Dim _Idmaeedo_DOC As Integer = _Row_CashDro_Operaciones.Item("Idmaeedo")
        Dim _Idmaeedo_NCV As Integer = _Row_CashDro_Operaciones.Item("Idmaeedo_NCV")
        Dim _Monto As Double = _Row_CashDro_Operaciones.Item("Monto")

        Dim _Clas_Pagar As New Clas_Pagar


        Consulta_sql = "SELECT TOP 1 IDMAEDPCE,EMPRESA,SUREDP,CJREDP,TIDP,NUDP,ENDP,EMDP,SUEMDP,CUDP,NUCUDP,FEEMDP,FEVEDP,MODP," & vbCrLf &
                       "TIMODP,TAMODP,VADP,VAABDP,VAASDP,VAVUDP,ESPGDP,REFANTI,KOTU,NUTRANSMI,DOCUENANTI,KOFUDP,KOTNDP,SUTNDP,ESASDP,ESPGDP,CUOTAS" & vbCrLf &
                       "FROM MAEDPCE WITH ( NOLOCK ) " & vbCrLf &
                       "WHERE 1 = 0"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = "Select TIDO,NUDO,ENDO From MAEEDO Where IDMAEEDO = " & _Idmaeedo_DOC
        Dim _Row_NewMaeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido_Pago = _Row_NewMaeedo.Item("TIDO")
        Dim _Nudo_Pago = _Row_NewMaeedo.Item("NUDO")
        Dim _Endo_Pago = _Row_NewMaeedo.Item("ENDO")

        _Tbl.Rows.Add(Fx_Nueva_Linea_De_Pago(_Tbl))

        Dim _Fila As DataRow = _Tbl.Rows(0)

        Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_NCV
        Dim _Row_NCV As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido_NCV = _Row_NCV.Item("TIDO")
        Dim _Nudo_NCV = _Row_NCV.Item("NUDO")
        Dim _Endo_NCV = _Row_NCV.Item("ENDO")

        _Fila.Item("ESPGDP") = "C"

        Dim _Koen = Trim(_Endo_Pago)
        Dim _Rut = RutEmpresa

        _Fila.Item("TIDP") = LCase(_Tido_Pago)
        _Fila.Item("ENDP") = _Rut
        _Fila.Item("EMDP") = _Koen
        _Fila.Item("REFANTI") = _Tido_Pago & "-" & _Nudo_Pago & "-" & _Koen
        _Fila.Item("VADP") = _Monto
        _Fila.Item("VAABDP") = _Monto
        _Fila.Item("VAASDP") = _Monto
        _Fila.Item("VAABDP") = _Monto

        Dim _Idmaedpce As Integer = _Clas_Pagar.Fx_Crear_Pago_MAEDPCE(Me, _Idmaeedo_NCV, _Tbl, FechaDelServidor)

    End Sub

    Private Function Fx_Nueva_Linea_De_Pago(ByVal _Tbl As DataTable) As DataRow

        Dim _Modp = "$"
        Dim _Timodp = "N"
        Dim _Tamodp = 1

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow

        With NewFila

            .Item("IDMAEDPCE") = 0
            .Item("EMPRESA") = ModEmpresa
            .Item("SUREDP") = ModSucursal
            .Item("CJREDP") = ModCaja

            .Item("TIDP") = String.Empty
            .Item("NUDP") = String.Empty

            .Item("ENDP") = String.Empty
            .Item("EMDP") = String.Empty   ' CODIGO EMISOR DE DOCUMENTO, BANCO, TIPO TARJETA, ETC.
            .Item("SUEMDP") = String.Empty ' ??
            .Item("CUDP") = String.Empty   ' NRO CTA. CTE.
            .Item("NUCUDP") = String.Empty ' NRO DEL CHEQUE
            .Item("FEEMDP") = FechaDelServidor()
            .Item("FEVEDP") = FechaDelServidor()

            .Item("MODP") = _Modp
            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp

            .Item("VADP") = 0
            .Item("VAABDP") = 0
            .Item("VAASDP") = 0
            .Item("VAVUDP") = 0
            .Item("ESPGDP") = String.Empty
            .Item("REFANTI") = String.Empty
            .Item("KOTU") = 1
            .Item("KOFUDP") = FUNCIONARIO
            .Item("KOTNDP") = RutEmpresa
            .Item("SUTNDP") = ModCaja

            .Item("NUTRANSMI") = ""
            .Item("DOCUENANTI") = ""

            .Item("ESASDP") = "A" ' ESTADO ASIGNACION DEL PAGO A = ASIGNADO A UN DOCUMENTO, P = NO ASIGNADO O PARCIALMENTE ASIGNADO, ES DECIR, 
            .Item("ESPGDP") = ""
            .Item("CUOTAS") = 0

        End With

        Return NewFila

    End Function

    Sub Sb_Imprimir_Documento(ByVal _Idmaeedo As Integer)

        If String.IsNullOrEmpty(_Impresora) Then
            Dim Fm As New Frm_Seleccionar_Impresoras("")
            Fm.ShowDialog(Me)
            If (String.IsNullOrEmpty(Fm.Pro_Impresora_Seleccionada)) Then
                Return
            Else
                _Impresora = Fm.Pro_Impresora_Seleccionada
            End If
            Fm.Dispose()
        End If

        Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _RowEncabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido = _RowEncabezado.Item("TIDO")

        Consulta_sql = "SELECT Top 1 Modalidad, TipoDoc, NombreFormato" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoDoc = '" & _Tido & "' And Modalidad = '" & Modalidad & "'"

        Dim _RowNombreFormato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Dim _NombreFormato = _RowNombreFormato.Item("NombreFormato")

        Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _Idmaeedo,
                                                                False, False, _Impresora, False, 0, False, "")

        If String.IsNullOrEmpty(Trim(_Imprime)) Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Impreso = 1" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo
        Else
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Impreso = 0,Log_Error = '" & _Imprime & "'" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo
        End If

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Transbak_Pruebas.Click

        Tiempo_Label.Stop()

        Try

            Dim _Aceptar As Boolean
            Dim _StrMonto As String

            _Aceptar = InputBox_Bk(Me, "Ingrese Valor", "Prueba venta Transbank", _StrMonto, False,
                                                  _Tipo_Mayus_Minus.Normal, , True, _Tipo_Imagen.Texto, False,
                                                  _Tipo_Caracter.Moneda, False)

            If _Aceptar Then
                Dim _Monto As Double = De_Txt_a_Num_01(_StrMonto, 3)

                If CBool(_Monto) Then

                    Dim _Traer_Voucher As Boolean

                    If MessageBoxEx.Show(Me, "¿Desea traer datos del Voucher desde el dispositivo?", "Traer Voucher",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        _Traer_Voucher = True
                    End If

                    Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, "0", _Monto,
                                                           Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Transaccion_Venta, _Traer_Voucher)
                    Fm.ShowDialog(Me)

                    Dim _Pagado As Boolean = Fm.Pro_Pagado
                    Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
                    Dim _Status As String = Fm.Pro_Status

                    Fm.Dispose()

                    MessageBoxEx.Show(Me, _Respuesta, _Status)

                End If
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Tiempo_Label.Start()
        End Try



    End Sub

    Private Sub ButtonX1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones Where Id = 4873"

        Dim _Row_Operacion_NCV As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Sb_Pago_Vuelto(_Row_Operacion_NCV)

        Return
        Dim _CashDro As Clas_Chasdro
        Dim _operationId = InputBox("Ingrese Id", "Ingrese Id")

        Dim _Ip_CashDro As String = "192.168.1.20"
        Dim _Usuario As String = "admin"
        Dim _Contraseña As String = "12345"


        _CashDro = New Clas_Chasdro(_Ip_CashDro, _Usuario, _Contraseña)

        _CashDro.Sb_Cancelar_Operacion(_operationId, Clas_Chasdro.Enum_Type_Cancelar_Operacion.Cancela_La_Operacion)

    End Sub

    Private Function Fx_Tabla1_Respuestas(ByVal _Respuesta As String) As String

        Select Case _Respuesta
            Case "00"
                Return "Aprobado"
            Case "01"
                Return "Rechazado"
            Case "02"
                Return "Autorizador no Responde"
            Case "03"
                Return "Fallo Conexión"
            Case "04"
                Return "Transacción ya fue Anulada"
            Case "05"
                Return "No existe transacción para Anular"
            Case "06"
                Return "Tarjeta no Soportada"
            Case "07"
                Return "Transacción Cancelada"
            Case "08"
                Return "No puede Anular Transacción Debito"
            Case "09"
                Return "Error Lectura de Tarjeta"
            Case "10"
                Return "Monto menor al mínimo permitido"
            Case "11"
                Return "No existe venta"
            Case "12"
                Return "Transacción no soportada"
            Case "13"
                Return "Debe ejecutar cierre"
            Case "14"
                Return "Error Encriptando PAN (BCYCLE)"
            Case "15"
                Return "Error Operando con Debito (BCYCLE)"
            Case "80"
                Return "Confirme el Monto"
            Case "81"
                Return "Ingrese Clave (PIN)"
            Case "82"
                Return "Procesando Transaccion"
            Case "90"
                Return "Inicialización Exitosa"
            Case "91"
                Return "Inicialización Fallida"
            Case "92"
                Return "Lector no conectado"

        End Select

    End Function

    Sub Sb_Datos_Ultima_Venta()

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, "0",
                                                   0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Datos_Ultima_Venta, True)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)


        Dim _Log_Datos_Ultima_Venta_Transbank = Replace(_Respuesta, "'", "")

        Dim _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
        Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

        Try

            Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
            Dim _Voucher As String

            If _Codigo_Respuesta = "00" Then
                _Voucher = _Datos_Tarjeta(15)
                'If MessageBoxEx.Show(Me, "¿Desea imprimir el voucher?", "Imprimir Voucher", MessageBoxButtons.YesNo,
                'MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim _Cl_Voucher As New Clas_Imprimir_Voucher()
                _Cl_Voucher.Fx_Imprimir_Voucher2(Me, _Voucher, _Impresora)
                'End If
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Lbl_Datos_Ult_Venta_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_Datos_Ult_Venta.DoubleClick
        Sb_Datos_Ultima_Venta()
        _Volver_A_Cargar = True
        Me.Close()
    End Sub

    Private Sub RfLbl_Informacion_Click(sender As Object, e As EventArgs) Handles RfLbl_Informacion.Click
        Sb_Pagar()
    End Sub

    Private Sub RfImg_Flecha_Click(sender As Object, e As EventArgs) Handles RfImg_Flecha.Click
        Sb_Pagar()
    End Sub

    Sub Sb_Pagar()

        Lbl_1.Visible = False
        Lbl_2.Visible = False
        PcImg_Dedo.Visible = False

        Rfl_Imagen.Visible = True
        Tiempo_Tocar_Pantalla.Enabled = False

        Tiempo_Label.Enabled = True
        Tiempo_Label.Start()
        Txt_Documento_Venta.Visible = True
        Txt_Documento_Venta.Focus()
        Me.Refresh()

    End Sub

    Private Sub Lbl_1_Click(sender As Object, e As EventArgs) Handles Lbl_1.Click
        Sb_Pagar()
    End Sub

    Private Sub Lbl_2_Click(sender As Object, e As EventArgs) Handles Lbl_2.Click
        Sb_Pagar()
    End Sub

    Private Sub Tiempo_Tocar_Pantalla_Tick(sender As Object, e As EventArgs) Handles Tiempo_Tocar_Pantalla.Tick

        Lbl_1.Visible = Not Lbl_1.Visible
        Lbl_2.Visible = Not Lbl_2.Visible

    End Sub

    Private Sub PcImg_Dedo_Click(sender As Object, e As EventArgs) Handles PcImg_Dedo.Click
        Sb_Pagar()
    End Sub

    Private Sub PcImg_Dedo_DoubleClick(sender As Object, e As EventArgs) Handles PcImg_Dedo.DoubleClick
        Sb_Pagar()
    End Sub

End Class
