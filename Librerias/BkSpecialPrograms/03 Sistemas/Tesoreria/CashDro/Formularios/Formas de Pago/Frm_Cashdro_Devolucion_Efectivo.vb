Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_Cashdro_Devolucion_Efectivo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Consulta_CashDro As String
    Dim _operationId As String

    Dim _CashDro As Clas_Chasdro

    Dim _Row_Operacion_NCV As DataRow
    Dim _Id As Integer
    Dim _Numero As String

    Dim _Tiempo_Espera As Integer = 0
    Dim _Tiempo_Maximo As Integer = 30
    Dim _Esperando As Integer

    Dim _Monto As Double

    Dim _Pagado As Boolean
    Dim _Cancelado As Boolean
    Dim _Tiempo_Caducado As Boolean
    Dim _Error As String

    Dim _Luz As Integer = 1

    Public ReadOnly Property Pro_Operation_Id() As String
        Get
            Return _operationId
        End Get
    End Property
    Public ReadOnly Property Pro_Pagado() As Boolean
        Get
            Return _Pagado
        End Get
    End Property
    Public ReadOnly Property Pro_Cancelado() As Boolean
        Get
            Return _Cancelado
        End Get
    End Property
    Public ReadOnly Property Pro_Tiempo_Caducado() As Boolean
        Get
            Return _Tiempo_Caducado
        End Get
    End Property
    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property
    Public ReadOnly Property Pro_Numero() As String
        Get
            Return _Numero
        End Get
    End Property
    Public ReadOnly Property Pro_Id() As Integer
        Get
            Return _Id
        End Get
    End Property

    Public Sub New(ByVal Monto As Double, _
                   ByVal Row_CashDro As DataRow, _
                   ByVal Row_Operacion_NCV As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Monto = Monto

        _Error = String.Empty

        Dim _Ip_CashDro As String = Row_CashDro.Item("Ip_CashDro") ' = "192.168.1.20"
        Dim _Usuario As String = Row_CashDro.Item("Usuario_CashDro") ' = "admin"
        Dim _Contraseña As String = Row_CashDro.Item("Contrasena_CashDro") ' = "12345"

        _Tiempo_Maximo = Row_CashDro.Item("Tiempo_Espera")

        _CashDro = New Clas_Chasdro(_Ip_CashDro, _Usuario, _Contraseña)

        '_CashDro.Sb_Peticion_Venta(_Monto)
        _CashDro.Sb_Peticion_Pago(_Monto)

        If _CashDro.Pro_WithError Then
            _Error = _CashDro.Pro_Respuesta
        Else
            _operationId = _CashDro.Pro_OperationId

            If _operationId = 0 Then
                _Error = "¡No se puede obtener ""OperationId desde CashDro!"""
            End If

        End If

        _Row_Operacion_NCV = Row_Operacion_NCV

    End Sub

    Private Sub Frm_Cashdro_Devolucion_Efectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Lbl_Total_A_Pagar.Text = "<b><font color=" & Chr(34) & "#ED1C24" & Chr(34) & ">TOTAL </font></b>  <b>" & FormatCurrency(_Monto, 0) & "</b>"

        If CBool(_operationId) Then

            Tiempo_Vuelto_Efectivo.Enabled = True

            If Not IsNothing(_Row_Operacion_NCV) Then

                Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
                Dim _posuser As String = FUNCIONARIO

                Dim _Padre_Id = _Row_Operacion_NCV.Item("Id")
                Dim _Idmaeedo_NCV = _Row_Operacion_NCV.Item("Idmaeedo_NCV")
                Dim _Nudo_NCV = _Row_Operacion_NCV.Item("Nudo_NCV")

                Dim _Modalidad = _Row_Operacion_NCV.Item("Modalidad")
                Dim _Empresa = _Row_Operacion_NCV.Item("Empresa")
                Dim _Sucursal = _Row_Operacion_NCV.Item("Sucursal")
                Dim _Bodega = _Row_Operacion_NCV.Item("Bodega")
                Dim _Caja = _Row_Operacion_NCV.Item("Caja")

                Dim _Vuelto As Double = _Row_Operacion_NCV.Item("Vuelto")

                '_operationId = "D" & _operationId

                _Numero = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones", "COALESCE(MAX(Numero),'0000000000')")
                _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser," &
                               "Tipo_De_Pago,Idmaeedo,Tido,Nudo,Modalidad,Empresa,Sucursal,Bodega,Caja,Monto,Padre_Id,Vuelto) Values " & vbCrLf &
                               "('" & _Numero & "','" & _operationId & "',GetDate(),'" & _posid & "','" & _posuser & "','EFC'," & _Idmaeedo_NCV &
                               ",'NCV','" & _Nudo_NCV &
                               "','" & _Modalidad & "','" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Caja &
                               "'," & De_Num_a_Tx_01(_Monto, False, 5) & ",'" & _Padre_Id &
                               "'," & De_Num_a_Tx_01(_Vuelto, False, 5) & ")"
                _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

            End If

        End If

        Btn_Cancelar_Operacion.Focus()

        Pbox_01.Visible = True : Pbox_02.Visible = False : Pbox_03.Visible = False

    End Sub

    Private Sub Tiempo_Vuelto_Efectivo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Vuelto_Efectivo.Tick

        Tiempo_Vuelto_Efectivo.Stop() '.Enabled = False

        With _CashDro

            If _Tiempo_Espera = _Tiempo_Maximo Then
                _Tiempo_Espera = 0

                .Sb_Cancelar_Operacion(_operationId, Clas_Chasdro.Enum_Type_Cancelar_Operacion.Cancela_La_Operacion)

                If .Pro_Code_Respuesta Then
                    _Pagado = False
                    _Cancelado = True
                    _Tiempo_Caducado = True
                    Me.Close()
                End If

            End If

            .Sb_Consultar_Estado_Operacion(_operationId)

            Dim _State As String = .Pro_State
            Dim _WithError As Boolean = .Pro_WithError


            If _WithError Then

                .Sb_Cancelar_Operacion(_operationId, Clas_Chasdro.Enum_Type_Cancelar_Operacion.Cancela_La_Operacion)

                If .Pro_Code_Respuesta Then

                    _Error = "ERROR EN CAJERO, DEBE REVISAR LA MAQUINA MANUALMENTE" & vbCrLf & _
                             "OPERACION CANCELADA"

                    Me.Close()

                End If

            Else
                Select Case _State
                    Case "I"
                        Me.Text = "la operación no existe"
                    Case "Q"
                        Me.Text = "la operación está en cola"
                        'Tiempo_Vuelto_Efectivo.Enabled = True
                    Case "E"
                        Me.Text = "la operación está en ejecución"
                        'Tiempo_Vuelto_Efectivo.Enabled = True
                    Case "F"

                        .Sb_Consultar_Estado_Operacion(_operationId)

                        Dim _Total As Double = .Pro_Total
                        Dim _Total_In As Double = .Pro_Total_In
                        Dim _Total_Out As Double = .Pro_Total_Out
                        Dim _Amountchangenotavailable As Double = .Pro_Amountchangenotavailable

                        _Pagado = True
                        Me.Close()

                    Case Else
                        Me.Text = "Estado desconocido!!!"
                End Select
            End If
        End With

        _Tiempo_Espera += 1

        _Esperando = _Tiempo_Maximo - _Tiempo_Espera

        Lbl_Esperando.Text = "Esperando pago... " & _Esperando


        If _Luz = 4 Then
            _Luz = 1
        End If

        Select Case _Luz
            Case 1
                Pbox_01.Visible = True : Pbox_02.Visible = False : Pbox_03.Visible = False
            Case 2
                Pbox_01.Visible = False : Pbox_02.Visible = True : Pbox_03.Visible = False
            Case 3
                Pbox_01.Visible = False : Pbox_02.Visible = False : Pbox_03.Visible = True
        End Select

        _Luz += 1

        Tiempo_Vuelto_Efectivo.Start()


    End Sub
End Class