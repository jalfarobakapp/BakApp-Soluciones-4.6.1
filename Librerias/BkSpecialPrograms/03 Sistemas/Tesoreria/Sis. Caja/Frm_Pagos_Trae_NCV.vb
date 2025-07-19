'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Trae_NCV

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowMaeedo As DataRow
    Dim _RowMaeen As DataRow

    Dim _Endo As String

    Dim _Tiene_NCV_Pendientes As Boolean

    Dim _Contador = 0
    Dim _Segundos_Tiempo_Espera_Cierre As Integer = 30
    Dim _Tiempo_Espera_Caducado As Boolean

    Dim _Considerar_Endofi As Boolean

    Public ReadOnly Property Pro_Tiene_NCV_Pendientes() As Boolean
        Get
            Return _Tiene_NCV_Pendientes
        End Get
    End Property
    Public ReadOnly Property Pro_RowMaeedo() As DataRow
        Get
            Return _RowMaeedo
        End Get
    End Property
    Public ReadOnly Property Pro_RowMaeen() As DataRow
        Get
            Return _RowMaeen
        End Get
    End Property

    Public Property Pro_Segundos_Tiempo_Espera_Cierre() As Integer
        Get
            Return _Segundos_Tiempo_Espera_Cierre
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then value = 1
            _Segundos_Tiempo_Espera_Cierre = value
            Tiempo_Espera_Cierre.Interval = 1000 * _Segundos_Tiempo_Espera_Cierre
        End Set
    End Property
    Public Property Pro_Activar_Tiempo_Espera() As Boolean
        Get
            Return Tiempo_Espera_Cierre.Enabled
        End Get
        Set(ByVal value As Boolean)
            Tiempo_Espera_Cierre.Enabled = value
        End Set
    End Property
    Public ReadOnly Property Pro_Tiempo_Espera_Caducado() As Boolean
        Get
            Return _Tiempo_Espera_Caducado
        End Get
    End Property

    Public Sub New(ByVal Endo As String,
                   ByVal Considerar_Endofi As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Endo = Endo
        _Considerar_Endofi = Considerar_Endofi

        If _Considerar_Endofi Then
            Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,ENDOFI,SUENDO,FEEMDO,VABRDO,VAABDO,VAIVARET,VABRDO-VAABDO AS SALDO,ESPGDO,MODO From MAEEDO" & vbCrLf &
                          "Where 1 > 0 And (" &
                          "(ENDO = '" & _Endo & "' And TIDO = 'NCV' AND ESPGDO = 'P') Or" & Space(1) &
                          "(ENDOFI = '" & _Endo & "' And TIDO = 'NCV' AND ESPGDO = 'P'))"
        Else
            Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,FEEMDO,VABRDO,VAABDO,VAIVARET,VABRDO-VAABDO AS SALDO,ESPGDO,MODO From MAEEDO" & vbCrLf &
                           "Where ENDO = '" & _Endo & "' And TIDO = 'NCV' AND ESPGDO = 'P'"
        End If

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        _Tiene_NCV_Pendientes = CBool(_Tbl.Rows.Count)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Pagos_Trae_NCV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = Txt_Numero
    End Sub

    Private Sub Sb_Traer_Documento(ByVal _Tido As String, ByVal _Nudo As String)

        If Not String.IsNullOrEmpty(Trim(_Nudo)) Then

            _Nudo = Replace(_Nudo, "NCV", "")

            _Nudo = Fx_Rellena_ceros(_Nudo, 10)

            Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,ENDOFI,FEEMDO,VABRDO,VAABDO,VAIVARET," &
                           "VABRDO-VAABDO AS SALDO,ESPGDO,MODO From MAEEDO" & vbCrLf &
                           "Where EMPRESA = '" & Mod_Empresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"
            _RowMaeedo = _Sql.Fx_Get_DataRow(Consulta_sql)


            If _RowMaeedo Is Nothing Then
                'MessageBoxEx.Show(Me, "Documento no existe", "Validación", _
                '                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                ToastNotification.Show(Me, "DOCUMENTO NO EXISTE",
                                          My.Resources.cross,
                                          3 * 1000, eToastGlowColor.Red,
                                          eToastPosition.MiddleCenter)

                Txt_Numero.Text = String.Empty
            Else

                Dim _Endo_NCV = _RowMaeedo.Item("ENDO")
                Dim _Endofi_NCV = String.Empty

                If _Considerar_Endofi Then _Endofi_NCV = _RowMaeedo.Item("ENDOFI")

                If _Endo_NCV = _Endo Or _Endofi_NCV = _Endo Then

                    Dim _Espgdo As String = _RowMaeedo.Item("ESPGDO")
                    Dim _Saldo As Double = _RowMaeedo.Item("SALDO")

                    If _Espgdo = "P" Then

                        Dim _Koen = _RowMaeedo.Item("ENDO")
                        Dim _Suen = _RowMaeedo.Item("SUENDO")

                        _RowMaeen = Fx_Traer_Datos_Entidad(_Koen, _Suen)

                        Me.Close()
                    ElseIf _Espgdo = "C" Then

                        Beep()

                        ToastNotification.Show(Me, "DOCUMENTO BLOQUEADO",
                                          My.Resources.cross,
                                          3 * 1000, eToastGlowColor.Red,
                                          eToastPosition.MiddleCenter)

                        Txt_Numero.Text = String.Empty

                        _RowMaeedo = Nothing
                        _RowMaeen = Nothing
                    End If

                Else
                    MessageBoxEx.Show(Me, "Está nota de crédito no pertenece a este cliente", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _RowMaeedo = Nothing
                    _RowMaeen = Nothing
                    Txt_Numero.Text = String.Empty
                End If

            End If
        Else
            MessageBoxEx.Show(Me, "Falta el número del documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


        Txt_Numero.SelectAll()
        Txt_Numero.Focus()

    End Sub

    Private Sub Txt_Numero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Numero.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Traer_Documento("NCV", Txt_Numero.Text)
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Sb_Traer_Documento("NCV", Txt_Numero.Text)
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_Pagos_Trae_NCV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Buscar_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Documento.Click

        Dim Fm As New Frm_Pagos_Trae_NCV_Vigentes_X_Cliente(_Endo, "")
        Fm.ShowDialog(Me)
        If Not String.IsNullOrEmpty(Fm.Pro_Numero) Then
            Txt_Numero.Text = Fm.Pro_Numero
            Sb_Traer_Documento("NCV", Txt_Numero.Text)
        End If
        Fm.Dispose()

    End Sub

    Private Sub Tiempo_Espera_Cierre_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Espera_Cierre.Tick
        _Tiempo_Espera_Caducado = True
        Me.Close()
    End Sub

End Class
