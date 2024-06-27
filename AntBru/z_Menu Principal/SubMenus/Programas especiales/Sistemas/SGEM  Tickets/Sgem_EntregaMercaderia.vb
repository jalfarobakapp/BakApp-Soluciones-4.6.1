Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Sgem_EntregaMercaderia

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Dst_Lic As Object
    Dim NotifyIcon1 As NotifyIcon '= _Fm_Menu_Padre.Notify_Demonio
    Dim _Huella As String

    Dim _Fm_Menu_Padre As Metro.MetroAppForm
    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

        If Global_Thema = Enum_Themas.Oscuro Then
            Sb_Color_Botones_Barra(Bar2)
        End If

    End Sub

    Private Sub Btn_MisTicket_Click(sender As Object, e As EventArgs) Handles Btn_MisTicket.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stem0001") Then Return

        Dim Fm As New Frm_Stmp_Listado
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_TicketListaEspera_Click(sender As Object, e As EventArgs) Handles Btn_TicketListaEspera.Click

        Dim Fm As New Frm_Stmp_SalaEspera
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Sgem_EntregarMercaderia_Click(sender As Object, e As EventArgs) Handles Btn_Sgem_EntregarMercaderia.Click

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Fx_Entregar(FUNCIONARIO, "")

        If Not _Mensaje.EsCorrecto And Not _Mensaje.Cancelado Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
        End If

        If Not _Mensaje.Cerrar Then
            Call Btn_Sgem_EntregarMercaderia_Click(Nothing, Nothing)
        End If

    End Sub

    Function Fx_Entregar(_CodFuncionario_Entrega As String, _Numero As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Aceptar As Boolean

            If Not String.IsNullOrEmpty(_Numero) Then
                _Aceptar = True
            End If

            Dim _CerradPorX As Boolean = False

            If Not _Aceptar Then
                _Aceptar = InputBox_Bk(_Fm_Menu_Padre, "Ingrese el número de documento que ya ha sido entregado." & vbCrLf & "El formato debe ser Ejemplo: FCV2365",
                                       "Entregar mercadería", _Numero, False, _Tipo_Mayus_Minus.Normal, 15, True, _Tipo_Imagen.Barra,,,,,,, False, _CerradPorX)
            End If

            If Not _Aceptar Then
                _Mensaje.Detalle = "Acción cancelada"
                _Mensaje.Cancelado = True
                _Mensaje.Cerrar = _CerradPorX
                Throw New System.Exception("An exception has occurred.")
            End If

            If Not _Numero.Contains("FCV") And Not _Numero.Contains("GDV") And Not _Numero.Contains("GDP") And Not _Numero.Contains("BLV") Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception("Debe indicar si el documento es BLV, FCV o (GDV/GDP)")
            End If

            Dim _Tido As String = Mid(_Numero, 1, 3)
            Dim _Nudo As String = Mid(_Numero, 4, 10)

            _Nudo = Fx_Rellena_ceros(_Nudo, 10)

            Consulta_sql = "Select IDMAEEDO,TIDO,NUDO From MAEEDO Where TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If IsNothing(_Row) Then

                _Mensaje.Detalle = "Validación"

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                Else
                    Throw New System.Exception("No existe documento " & _Tido & " - " & _Nudo & " En el sistema de Ticket de entrega")
                End If

            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where IdmaeedoGen = " & _Row.Item("IDMAEEDO")
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Documento) Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception("No existe documento " & _Tido & " - " & _Nudo & " En el sistema de Ticket de entrega")
            End If

            If MessageBoxEx.Show(Me, "¿Confirma el documento " & _Tido & "-" & _Nudo & "?",
                                 "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                _Mensaje.Detalle = "Validación"
                _Mensaje.Cancelado = True
                Throw New System.Exception("Acción cancelada por el usuario")
            End If

            Dim _Id_Enc As Integer = _Row_Documento.Item("Id")

            Dim _Cl_Stmp As New Cl_Stmp
            _Cl_Stmp.Fx_Llenar_Encabezado(_Id_Enc)

            _Cl_Stmp.Zw_Stmp_Enc.Estado = "ENTRE"
            _Cl_Stmp.Zw_Stmp_Enc.CodFuncionario_Entrega = _CodFuncionario_Entrega

            _Mensaje = _Cl_Stmp.Fx_Entregar_Mercaderia

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        Finally
            'If Chk_Monitorear.Checked Then
            '    Timer_Monitoreo.Start()
            'End If
        End Try

        If Not _Mensaje.EsCorrecto And Not _Mensaje.Cancelado Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
            _Mensaje = Fx_Entregar(_CodFuncionario_Entrega, "")
        End If

        Return _Mensaje

    End Function

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
