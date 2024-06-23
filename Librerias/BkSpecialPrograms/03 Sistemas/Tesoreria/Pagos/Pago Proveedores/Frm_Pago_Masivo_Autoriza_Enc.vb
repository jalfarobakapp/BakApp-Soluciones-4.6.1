'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pago_Masivo_Autoriza_Enc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Grabar As Boolean
    Dim _Eliminar As Boolean

    Dim _Total As Double

    Enum Enum_Accion
        Editar
        Crear
    End Enum

    Dim _Accion As Enum_Accion
    Dim _Row_Autorizacion As DataRow

    Public Property Pro_Row_Autorizacion() As DataRow
        Get
            Return _Row_Autorizacion
        End Get
        Set(ByVal value As DataRow)
            _Row_Autorizacion = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public ReadOnly Property Pro_Tipo_Pago() As String
        Get
            Return Cmb_Tipo_Pago.SelectedValue
        End Get
    End Property
    Public ReadOnly Property Pro_Fecha_Pago() As Date
        Get
            Return Dtp_Fecha_Asignacion_Pago.Value
        End Get
    End Property
    Public ReadOnly Property Pro_Referencia() As String
        Get
            Return Txt_Referencia.Text
        End Get
    End Property
    Public ReadOnly Property Pro_Eliminar() As Boolean
        Get
            Return _Eliminar
        End Get
    End Property
    Public Property Pro_Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property

    Public Sub New(ByVal Accion As Enum_Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Referencia.FocusHighlightEnabled = False
            Dtp_Fecha_Asignacion_Pago.FocusHighlightEnabled = False
            Cmb_Tipo_Pago.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Pago_Masivo_Autoriza_Enc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Txt_Total.Text = FormatCurrency(_Total, 0)
        Dtp_Fecha_Asignacion_Pago.Value = FechaDelServidor()
        Sb_Llena_Combo_Tipo_Pago()

        If _Accion = Enum_Accion.Editar Then

            Dim _Id_Autoriza = _Row_Autorizacion.Item("Id_Autoriza")
            Txt_Total.Text = FormatCurrency(_Row_Autorizacion.Item("Total"), 0)
            Dtp_Fecha_Asignacion_Pago.Value = _Row_Autorizacion.Item("Fecha_Pago")
            Cmb_Tipo_Pago.SelectedValue = _Row_Autorizacion.Item("Tipo_Pago")
            Txt_Referencia.Text = _Row_Autorizacion.Item("Referencia")

            If CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det",
               "Pagado = 1 And Id_Autoriza = " & _Id_Autoriza)) Then
                Dtp_Fecha_Asignacion_Pago.Enabled = False
                Cmb_Tipo_Pago.Enabled = False
            End If

        End If

    End Sub

    Private Sub Btn_Grabar_Autorizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar_Autorizacion.Click

        If _Accion = Enum_Accion.Crear Then
            Sb_Crear()
        ElseIf _Accion = Enum_Accion.Editar Then
            Sb_Editar()
        End If
    End Sub

    Sub Sb_Crear()

        If Not String.IsNullOrEmpty(Trim(Txt_Referencia.Text)) Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc" & vbCrLf &
                           "Where Fecha_Pago = '" & Format(Dtp_Fecha_Asignacion_Pago.Value, "yyyyMMdd") & "'"
            Dim _Tbl_Pagos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            _Grabar = True

            If (_Tbl_Pagos.Rows.Count) Then
                If MessageBoxEx.Show(Me, "Ya existe una autorización de pago para el " &
                                     FormatDateTime(Dtp_Fecha_Asignacion_Pago.Value, DateFormat.LongDate) & vbCrLf & vbCrLf &
                                     "¿Desea crear la autorización de todos modos?", "Validación",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then
                    _Grabar = False
                End If
            End If

            If _Grabar Then Me.Close()

        Else
            MessageBoxEx.Show(Me, "Falta referencia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Referencia.Focus()
        End If

    End Sub

    Sub Sb_Editar()

        If Not String.IsNullOrEmpty(Trim(Txt_Referencia.Text)) Then

            'Id_Autoriza, Referencia, FUNCIONARIO, Fecha_Autoriza, Fecha_Pago, Tipo_Pago, Total
            Dim _Id_Autoriza = _Row_Autorizacion.Item("Id_Autoriza")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Set" & vbCrLf &
                            "Referencia = '" & Txt_Referencia.Text & "'," & vbCrLf &
                            "Fecha_Pago = '" & Format(Dtp_Fecha_Asignacion_Pago.Value, "yyyyMMdd") & "'," & vbCrLf &
                            "Tipo_Pago = '" & Cmb_Tipo_Pago.SelectedValue & "'" & vbCrLf &
                            "Where Id_Autoriza = " & _Id_Autoriza
            _Grabar = _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Grabar Then Me.Close()

        Else
            MessageBoxEx.Show(Me, "Falta referencia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Referencia.Focus()
        End If

    End Sub

    Sub Sb_Llena_Combo_Tipo_Pago()

        caract_combo(Cmb_Tipo_Pago)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "CHC" : dr("Hijo") = "CHEQUE" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "PTB" : dr("Hijo") = "TRANSFERENCIA" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With Cmb_Tipo_Pago
            .DataSource = Nothing
            .DataSource = dt
        End With

        Cmb_Tipo_Pago.SelectedValue = "CHC"

    End Sub

    Private Sub Frm_Pago_Masivo_Autoriza_Enc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
