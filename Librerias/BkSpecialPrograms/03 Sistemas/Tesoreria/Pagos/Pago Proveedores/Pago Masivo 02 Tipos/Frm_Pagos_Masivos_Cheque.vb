'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Masivos_Cheque

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Entidad As DataRow
    Dim _Pagado As Boolean
    Dim _Vadp As Double

    Dim _DsDocumentos As DataSet
    Dim _Documentos_a_Pagar As DataTable
    Dim _Refanti As String
    Dim _Fecha_Vencimiento As Date

    Dim _Bloquear_Fecha_Vencimiento As Boolean

    Dim _Tbl_Documentos_a_Pagar As DataTable

    Dim _Row_New_Maedpce As DataRow


    Public ReadOnly Property Pro_New_Maedpce() As DataRow
        Get
            Return _Row_New_Maedpce
        End Get
    End Property
    Public ReadOnly Property Pro_Pagado() As Boolean
        Get
            Return _Pagado
        End Get
    End Property
    Public Property Pro_Fecha_Vencimiento() As Date
        Get
            Return Dtp_Fecha_Vencimiento.Value
        End Get
        Set(ByVal value As Date)
            _Fecha_Vencimiento = value
            Dtp_Fecha_Vencimiento.Value = value
        End Set
    End Property
    Public Property Pro_Referencia() As String
        Get
            Return _Refanti
        End Get
        Set(ByVal value As String)
            _Refanti = Mid(value, 1, 80)
        End Set
    End Property
    Public Property Pro_Bloquear_Fecha_Vencimiento() As Boolean
        Get
            Return _Bloquear_Fecha_Vencimiento
        End Get
        Set(ByVal value As Boolean)
            _Bloquear_Fecha_Vencimiento = value
        End Set
    End Property


    Public Sub New(ByVal DsDocumentos As DataSet)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _DsDocumentos = DsDocumentos

        caract_combo(Cmb_Emdp)
        Dim Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf
        Consulta_sql = Union & "SELECT KOENDP AS Padre,KOENDP+NOKOENDP+CTACTE AS Hijo FROM TABENDP" & vbCrLf & _
                      "WHERE CTACTE <> ''" & vbCrLf & _
                      "ORDER BY Hijo"
        Cmb_Emdp.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Emdp.SelectedValue = ""

        Dtp_Fecha_Emision.Value = FechaDelServidor()
        Dtp_Fecha_Vencimiento.Value = FechaDelServidor()

        _Row_Entidad = _DsDocumentos.Tables(2).Rows(0)

        Txt_Proveedor.Text = FormatNumber(_Row_Entidad.Item("RTEN"), 0) & "-" & RutDigito(_Row_Entidad.Item("RTEN")) & " - " & _
                             _Row_Entidad.Item("NOKOEN")

        _Tbl_Documentos_a_Pagar = DsDocumentos.Tables(0)

        _Vadp = DsDocumentos.Tables(4).Rows(0).Item("SALDO")
        Txt_Total_a_pagar.Text = FormatCurrency(_Vadp, 0)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Pagar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Pagos_Masivos_Cheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dtp_Fecha_Emision.Value = FechaDelServidor()

        AddHandler Dtp_Fecha_Emision.ValueChanged, AddressOf Sb_Dtp_Fecha_Emision_ValueChanged
        AddHandler Dtp_Fecha_Vencimiento.ValueChanged, AddressOf Sb_Dtp_Fecha_Vencimiento_ValueChanged

    End Sub


    Private Sub Btn_Pagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pagar.Click

        Dim _Emdp As String = Trim(Cmb_Emdp.SelectedValue)

        If String.IsNullOrEmpty(Trim(_Emdp)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA DOCUMENTO EMISOR", My.Resources.cross, _
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Cmb_Emdp.Focus()
            Return
        End If


        If String.IsNullOrEmpty(Trim(Txt_Nro_Cheque.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA NUMERO DE CHEQUE", My.Resources.cross, _
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Txt_Nro_Cheque.Focus()
            Return
        End If

        Dim _Nucudp As String = Trim(Txt_Nro_Cheque.Text)
        
        Consulta_sql = "Select Top 1 * From TABENDP" & vbCrLf & _
                       "Where EMPRESA = '" & ModEmpresa & "' And KOENDP = '" & _Emdp & "'"
        Dim _Row_Endp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


        Dim _Cudp As String = Trim(_Row_Endp.Item("CTACTE"))
        Dim _Nokoendp As String = Trim(_Row_Endp.Item("NOKOENDP"))


        Dim _Endp As String = _Row_Entidad.Item("KOEN")
        Dim _Suendp As String = _Row_Entidad.Item("SUEN")

        Consulta_sql = "SELECT TOP 1 IDMAEMO,KOMO,TIMO,NOKOMO,VAMO,FEMO,VAMOCOM" & vbCrLf & _
                       "FROM MAEMO" & vbCrLf & _
                       "WHERE KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "'" & vbCrLf & _
                       "ORDER BY IDMAEMO DESC"
        Dim _Row_Maemo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Vamo As Double = _Row_Maemo.Item("VAMO")

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEDPCE", _
                             "TIDP = 'CHC' And EMDP = '" & _Emdp & "' And CUDP = '" & _Cudp & "' And NUCUDP = '" & Trim(_Nucudp) & "'")

        If CBool(_Reg) Then
            If MessageBoxEx.Show(Me, "El número del cheque ya existe el sistema" & vbCrLf & vbCrLf & _
                                 "Banco: " & _Nokoendp & vbCrLf & _
                                 "Cta. Cte.: " & _Cudp & vbCrLf & _
                                 "Cheque Nro: " & _Nucudp & vbCrLf & vbCrLf & _
                                 "¿Desea seguir con la grabación?", "Pago con cheque", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then
                Txt_Nro_Cheque.SelectAll()
                Txt_Nro_Cheque.Focus()
                Return
            End If
        End If

        Dim _Pagar As New Clas_Pagar
        _Pagado = _Pagar.Fx_Crear_Pago_y_Pagar("CHC", _Endp, "", ModEmpresa, ModSucursal, ModCaja, _Emdp,
                                               _Cudp, _Nucudp,
                                               FormatDateTime(Dtp_Fecha_Emision.Value, DateFormat.ShortDate),
                                               FormatDateTime(Dtp_Fecha_Vencimiento.Value, DateFormat.ShortDate), "$", "N",
                                               De_Num_a_Tx_01(_Vamo, False, 5),
                                               _Refanti, 1,
                                               FUNCIONARIO, _Vadp,
                                               _Vadp, 0, "A", 0, "P", 0, "", 0, 123456, _Tbl_Documentos_a_Pagar)

        If CBool(_Pagado) Then

            _Row_New_Maedpce = _Pagar.Pro_Row_Maedpce
            Dim _Tidp = _Row_New_Maedpce.Item("TIDP")
            Dim _Nudp = _Row_New_Maedpce.Item("NUDP")
            Dim _DocPagados = _Pagar.Pro_DocPagados

            MessageBoxEx.Show(Me, "Transacción realizada correctamente" & vbCrLf & vbCrLf & _
                              "Número interno: " & _Tidp & "-" & _Nudp & vbCrLf & " Documentos pagados: " & _DocPagados, _
                              "Proceso terminado", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
        End If

    End Sub

    Private Sub Frm_Pagos_Masivos_Cheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Dtp_Fecha_Vencimiento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FormatDateTime(_Fecha_Vencimiento, DateFormat.ShortDate) <> FormatDateTime(Dtp_Fecha_Vencimiento.Value, DateFormat.ShortDate) Then
            If _Bloquear_Fecha_Vencimiento Then
                If Not Fx_Tiene_Permiso(Me, "Ppro0005") Then
                    Dtp_Fecha_Vencimiento.Value = _Fecha_Vencimiento
                End If
            End If
        End If
    End Sub

    Private Sub Sb_Dtp_Fecha_Emision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FormatDateTime(_Fecha_Vencimiento, DateFormat.ShortDate) > FormatDateTime(FechaDelServidor, DateFormat.ShortDate) Then
            MessageBoxEx.Show(Me, "La fecha de emisión no puede ser mayor a la fecha de hoy", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Emision.Value = FechaDelServidor()
        End If
    End Sub

    Private Sub Btn_Trae_Ultimo_Nro_Cheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Trae_Ultimo_Nro_Cheque.Click

        Dim _Emdp As String = Trim(Cmb_Emdp.SelectedValue)
        Consulta_sql = "Select Top 1 * From TABENDP" & vbCrLf & _
                       "Where EMPRESA = '" & ModEmpresa & "' And KOENDP = '" & _Emdp & "'"
        Dim _Row_Endp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cudp As String = Trim(_Row_Endp.Item("CTACTE"))

        Consulta_sql = "Select Max(NUCUDP) As NUCUDP From MAEDPCE" & vbCrLf & _
        "Where TIDP = 'CHC' And EMDP = '" & _Emdp & "' And CUDP = '" & _Cudp & "'"

        Dim _Nucudp As String = _Sql.Fx_Trae_Dato("MAEDPCE", "NUCUDP", _
                                                  "TIDP = 'CHC' And EMDP = '" & _Emdp & "' And CUDP = '" & _Cudp & "'" & vbCrLf & _
                                                  "Order By IDMAEDPCE Desc")

        Txt_Nro_Cheque.Text = Trim(_Nucudp)
        Txt_Nro_Cheque.SelectAll()
        Txt_Nro_Cheque.Focus()

    End Sub

    
End Class