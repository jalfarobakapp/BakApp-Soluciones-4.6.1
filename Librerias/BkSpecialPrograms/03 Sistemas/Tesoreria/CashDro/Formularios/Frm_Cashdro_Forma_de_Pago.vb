Imports DevComponents.DotNetBar


Public Class Frm_Cashdro_Forma_de_Pago

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tipo_De_Pago As String
    Dim _Contador = 0
    Dim _Tiempo_De_Espera = 60

    Dim _Row_Operacion_Vuelto As DataRow

    Public ReadOnly Property Pro_Tipo_De_Pago() As String
        Get
            Return _Tipo_De_Pago
        End Get
    End Property
    Public Property Pro_EFV() As Boolean
        Get
            Return Btn_Efectivo.Enabled
        End Get
        Set(ByVal value As Boolean)
            Btn_Efectivo.Enabled = value
        End Set
    End Property
    Public Property Pro_TJV() As Boolean
        Get
            Return Btn_Tarjeta.Enabled
        End Get
        Set(ByVal value As Boolean)
            Btn_Tarjeta.Enabled = value
        End Set
    End Property
    Public Property Pro_NCV() As Boolean
        Get
            Return Btn_Nota_De_Credito.Enabled
        End Get
        Set(ByVal value As Boolean)
            Btn_Nota_De_Credito.Enabled = value
        End Set
    End Property
    Public ReadOnly Property Pro_Row_Operacion_Vuelto() As DataRow
        Get
            Return _Row_Operacion_Vuelto
        End Get
    End Property

    Dim _Pago_con_nota_de_credito As Boolean

    Public Property Pro_Pago_con_nota_de_credito() As Boolean
        Get
            Return _Pago_con_nota_de_credito
        End Get
        Set(ByVal value As Boolean)
            _Pago_con_nota_de_credito = value
        End Set
    End Property

    Dim _Row_Documento As DataRow

    Public Sub New(ByVal Nudo As String,
                   ByVal Monto As Double,
                   Optional ByRef Row_Documento As DataRow = Nothing)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Lbl_Nro_Documento.Text = Nudo
        Lbl_Documento.Text = "<b><font color=" & Chr(34) & "#ED1C24" & Chr(34) & ">DOCUMENTO</font></b>  <b>" & Nudo & "</b>"
        _Row_Documento = Row_Documento

        Sb_Actualizar_Valor_A_Pagar()

    End Sub

    Sub Sb_Actualizar_Valor_A_Pagar()

        Dim _Total_Doc As Double = _Row_Documento.Item("VABRDO")
        Dim _Saldo As Double = _Row_Documento.Item("SALDO_ANTERIOR")
        Dim _Abonado_Ncv As Double = _Row_Documento.Item("ABONADO_NCV")

        If _Pago_con_nota_de_credito Then

            Lbl_Abonado_Con_NCV.Visible = True
            Lbl_Abonado_Con_NCV.Text = "Abonado con Nota de crédito: " & FormatCurrency(_Abonado_Ncv, 0)

        End If

        Lbl_Total_A_Pagar.Text = "<b><font color=" & Chr(34) & "#ED1C24" & Chr(34) &
                                 ">TOTAL A PAGAR</font></b>  <b>" & FormatCurrency(_Saldo, 0) & "</b>"

        Lbl_Total_Documento.Text = FormatCurrency(_Total_Doc, 0)
        Lbl_Abonado_Con_Nota_De_Credito.Text = FormatCurrency(_Abonado_Ncv, 0)
        Lbl_Saldo_A_Pagar.Text = FormatCurrency(_Saldo, 0)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Cashdro_Forma_de_Pago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Tiempo_Espera.Enabled = True
        Me.ActiveControl = Txt
        Txt.Focus()

        Sb_Actualizar_Valor_A_Pagar()

    End Sub

    Private Sub Btn_Efectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Efectivo.Click
        _Tipo_De_Pago = "EFV"
        Me.Close()
    End Sub

    Private Sub Btn_Tarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tarjeta.Click
        _Tipo_De_Pago = "TJV"
        Me.Close()
    End Sub

    Private Sub Btn_Efectivo_Tarjeta_Click(sender As Object, e As EventArgs) Handles Btn_Efectivo_Tarjeta.Click

        Dim _Saldo As Double = _Row_Documento.Item("SALDO_ANTERIOR")

        If _Saldo < 2000 Then
            Beep()

            ToastNotification.Show(Me, "EL MONTO DEBE SER SUPERIOR A $2.000",
                      My.Resources.cross,
                       2 * 1000, eToastGlowColor.Red,
                       eToastPosition.MiddleCenter)
        Else
            _Tipo_De_Pago = "EFV_TJV"
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Nota_De_Credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nota_De_Credito.Click

        Dim _Tiempo_Espera_Caducado As Boolean
        Dim _Endo = _Row_Documento.Item("ENDO")
        Dim _Row_Maeedo_NCV As DataRow
        Dim _Cerrar As Boolean

        Dim Fm As New Frm_Pagos_Trae_NCV(_Endo, True)
        Fm.Btn_Buscar_Documento.Visible = False
        Fm.Pro_Activar_Tiempo_Espera = True
        Fm.Pro_Segundos_Tiempo_Espera_Cierre = 60

        Dim _Tiene_NCV_Pendientes As Boolean = Fm.Pro_Tiene_NCV_Pendientes

        If _Tiene_NCV_Pendientes Then
            Fm.ShowDialog(Me)
            _Row_Maeedo_NCV = Fm.Pro_RowMaeedo
            _Tiempo_Espera_Caducado = Fm.Pro_Tiempo_Espera_Caducado
            Fm.Dispose()

            If Not _Tiempo_Espera_Caducado Then
                Tiempo_Espera.Enabled = False

                Sb_Pago_Nota_De_Credito(_Row_Maeedo_NCV, _Cerrar)

                If _Cerrar Then
                    _Tipo_De_Pago = "NCV"
                    Me.Close()
                End If

                Tiempo_Espera.Enabled = True

            Else
                _Tipo_De_Pago = String.Empty
                Sb_Cancelar_Notas_de_credito(True, False)
                Me.Close()
            End If

        Else

            Fm.Dispose()

            Beep()

            ToastNotification.Show(Me, "NO TIENE NOTAS DE CREDITO A FAVOR",
                      My.Resources.cross,
                       3 * 1000, eToastGlowColor.Red,
                       eToastPosition.MiddleCenter)
        End If


        Sb_Actualizar_Valor_A_Pagar()

    End Sub

    Sub Sb_Pago_Nota_De_Credito(ByVal _Row_Maeedo_NCV As DataRow,
                                Optional ByRef _Cerrar As Boolean = False)

        Tiempo_Espera.Enabled = False

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")

        Dim _Monto As Double = _Row_Documento.Item("SALDO_ANTERIOR")
        Dim _Saldo_Doc As Double

        Dim _Idmaeedo_NCV As Integer
        Dim _Nudo_NCV As String

        Dim _Id As Integer
        Dim _Numero As String

        If Not (_Row_Maeedo_NCV Is Nothing) Then

            _Idmaeedo_NCV = _Row_Maeedo_NCV.Item("IDMAEEDO")
            _Nudo_NCV = _Row_Maeedo_NCV.Item("NUDO")


            Dim _Uso_NCV As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_CashDro_Operaciones",
                                     "Idmaeedo_NCV = " & _Idmaeedo_NCV & " And Idmaeedo = " & _Idmaeedo)


            If Not CBool(_Uso_NCV) Then

                Dim _Saldo_Ncv As Double = _Row_Maeedo_NCV.Item("SALDO")

                _Saldo_Doc = _Monto - _Saldo_Ncv

                If _Saldo_Doc <= 0 Then
                    _Monto = _Row_Documento.Item("SALDO_ANTERIOR")
                    _Row_Documento.Item("SALDO_ANTERIOR") = 0
                    _Cerrar = True
                Else
                    _Monto = _Saldo_Ncv
                    _Row_Documento.Item("SALDO_ANTERIOR") = _Saldo_Doc
                    _Row_Documento.Item("ABONADO_NCV") += _Saldo_Ncv
                End If

                Dim _OperationId_NCV As String

                _Numero = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones", "COALESCE(MAX(Numero),'0000000000')")
                _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

                Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
                Dim _posuser As String = FUNCIONARIO
                Dim _Vuelto As Double

                If _Saldo_Doc < 0 Then
                    _Vuelto = _Saldo_Doc * -1
                End If

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Modalidad,Empresa,Sucursal,Bodega,Caja) Values " & vbCrLf &
                               "('" & _Numero & "','" & _OperationId_NCV & "',GetDate(),'" & _posid & "','" & _posuser & "','" & Modalidad &
                               "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "')"
                _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)


                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Idmaeedo = " & _Idmaeedo & "," &
                               "Tipo_De_Pago = 'NCV'," &
                               "Pagado_Nota_de_credito = 1," &
                               "Monto = " & De_Num_a_Tx_01(_Monto, False, 5) & "," &
                               "Idmaeedo_NCV = " & _Idmaeedo_NCV & "," &
                               "Nudo_NCV = '" & _Nudo_NCV & "'," &
                               "Vuelto = " & De_Num_a_Tx_01(_Vuelto, False, 5) & "," &
                               "FechaHora_Fin = Getdate()" & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Pago_con_nota_de_credito = True

                If CBool(_Vuelto) Then
                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                                   "Where Id = " & _Id
                    _Row_Operacion_Vuelto = _Sql.Fx_Get_DataRow(Consulta_sql)
                End If

            Else

                ToastNotification.Show(Me, "EL DOCUMENTO YA ESTA ASOCIADO",
                                       Nothing,
                                       3 * 1000, eToastGlowColor.Green,
                                       eToastPosition.MiddleCenter)

            End If

        End If

        _Contador = 0

        Tiempo_Espera.Enabled = True

    End Sub

    Private Sub Btn_Cancelar_Operacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar_Operacion.Click
        _Tipo_De_Pago = String.Empty
        Sb_Cancelar_Notas_de_credito(False, True)
        Me.Close()
    End Sub

    Private Sub Tiempo_Espera_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Espera.Tick

        If Lbl_Seleccion_Pago.Visible Then
            Lbl_Seleccion_Pago.Visible = False
        Else
            Lbl_Seleccion_Pago.Visible = True
        End If

        _Contador += 1

        If _Tiempo_De_Espera = _Contador Then
            _Tipo_De_Pago = String.Empty
            Sb_Cancelar_Notas_de_credito(True, False)
            Me.Close()
        End If

    End Sub

    Sub Sb_Cancelar_Notas_de_credito(ByVal _Cancelado_por_tiempo As Boolean,
                                     ByVal _Cancelado_por_usuario As Boolean)

        If _Pago_con_nota_de_credito Then

            Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones Where Idmaeedo = " & _Idmaeedo
            Dim _Tbl_Operaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Row_Operacion As DataRow In _Tbl_Operaciones.Rows

                Dim _Id = _Row_Operacion.Item("Id")
                Dim _Idmaeedo_NCV = _Row_Operacion.Item("Idmaeedo_NCV")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Cancelado_Por_Tiempo = " & CInt(_Cancelado_por_tiempo) * -1 & "," &
                               "Cancelado_Por_Usuario = " & CInt(_Cancelado_por_usuario) * -1 & "," &
                               "Pagado_Nota_de_credito = 0," &
                               "FechaHora_Fin = Getdate()," &
                               "Monto = 0," & vbCrLf &
                               "Idmaeedo = 0," & vbCrLf &
                               "Idmaeedo_NCV = 0," & vbCrLf &
                               "Nudo_NCV = ''" & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Update MAEEDO Set ESPGDO = 'P' Where IDMAEEDO = " & _Idmaeedo_NCV
                _Sql.Ej_consulta_IDU(Consulta_sql)

            Next

            _Pago_con_nota_de_credito = False

        End If

    End Sub


End Class
