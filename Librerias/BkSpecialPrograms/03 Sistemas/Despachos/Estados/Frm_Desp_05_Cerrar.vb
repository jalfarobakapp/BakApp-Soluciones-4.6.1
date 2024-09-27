Imports DevComponents.DotNetBar

Public Class Frm_Desp_05_Cerrar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Cerrado As Boolean
    Dim _Cl_Despacho As Clas_Despacho

    Public Property Cerrado As Boolean
        Get
            Return _Cerrado
        End Get
        Set(value As Boolean)
            _Cerrado = value
        End Set
    End Property

    Public Property Despachos As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Desp_05_Cerrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Txt_Nro_Encomienda
        _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If String.IsNullOrEmpty(Txt_Nro_Encomienda.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el número de encomienda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Nro_Encomienda") = Txt_Nro_Encomienda.Text

        Consulta_Sql = "Select Distinct Id_Despacho 
                            From " & _Global_BaseBk & "Zw_Despachos 
                            Where Nro_Despacho = '" & _Cl_Despacho.Nro_Despacho & "' And Estado = 'DPO'"
        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If Not CBool(_Tbl_Despachos.Rows.Count) Then
            Return
        End If

        If _Tbl_Despachos.Rows.Count = 1 Then

            If _Cl_Despacho.Fx_Accion_Cerrar_Despachos(Txt_Observaciones.Text, False) Then
                _Cerrado = True
                Me.Close()
            End If

        Else

            Dim Chk_Solo_Una As New Command
            Chk_Solo_Una.Checked = False
            Chk_Solo_Una.Name = "Chk_Solo_Una"
            Chk_Solo_Una.Text = "Cerrar solo esta Sub-Orden"

            Dim Chk_Todas As New Command
            Chk_Todas.Checked = False
            Chk_Todas.Name = "Chk_Todas"
            Chk_Todas.Text = "Cerrar todas las Sub-Ordenes de la OD: " & _Cl_Despacho.Nro_Despacho

            Dim _Opciones() As Command = {Chk_Todas, Chk_Solo_Una}

            Dim _Info As New TaskDialogInfo("Cerrar Orden de Despacho",
                              eTaskDialogIcon.CheckMark2,
                              "Ingreso N° de Encomienda",
                              "Debe indicar si el número de encomienda corresponde a todos los despachos de la orden o solo a esta sub-orden." & vbCrLf &
                              "Confirme su opción",
                              eTaskDialogButton.Ok + eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

            If _Resultado = eTaskDialogResult.Ok Then

                If Not Chk_Solo_Una.Checked And Not Chk_Todas.Checked Then
                    MessageBoxEx.Show(Me, "Debe seleccionar una opción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Call Btn_Aceptar_Click(Nothing, Nothing)
                    Return
                End If

                If _Cl_Despacho.Fx_Accion_Cerrar_Despachos(Txt_Observaciones.Text, Chk_Todas.Checked) Then
                    _Cerrado = True
                    Me.Close()
                End If

            End If

        End If

    End Sub

    Private Sub Txt_Nro_Encomienda_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Nro_Encomienda.KeyDown
        If e.KeyValue = Keys.Enter Then
            Txt_Observaciones.Focus()
        End If
    End Sub

    Private Sub Frm_Desp_05_Cerrar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Desp_05_Cerrar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
    End Sub
End Class
