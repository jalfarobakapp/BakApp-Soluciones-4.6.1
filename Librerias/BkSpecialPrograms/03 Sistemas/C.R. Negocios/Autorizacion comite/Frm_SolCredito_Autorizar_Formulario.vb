Imports DevComponents.DotNetBar

Public Class Frm_SolCredito_Autorizar_Formulario

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Nro_Negocio As String
    Dim _Grabar As Boolean
    Dim _RowAprobacion As DataRow

    Dim _Anular As Boolean

    Public ReadOnly Property Pro_Anular()
        Get
            Return _Anular
        End Get
    End Property

    Public Property Pro_Nro_Negocio As String
        Get
            Return _Nro_Negocio
        End Get
        Set(value As String)
            _Nro_Negocio = value
        End Set
    End Property

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_RowAprobacion As DataRow
        Get
            Return _RowAprobacion
        End Get
        Set(value As DataRow)
            _RowAprobacion = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_SolCredito_Autorizar_Formulario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Grupo_Chequeados.Enabled = False
        Grupo_Texto.Enabled = False

        AddHandler Rdb_Autorizar.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Rechazar.CheckedChanged, AddressOf Rdb_CheckedChanged


        If Not (_RowAprobacion Is Nothing) Then
            With _RowAprobacion

                Chk_Documentar_con_cheque_o_letra.Checked = .Item("Chk_01")
                Chk_Entrega_de_garantia_real.Checked = .Item("Chk_02")
                Chk_Pago_anticipado_de_factura.Checked = .Item("Chk_03")
                Chk_Previa_entrega_de_carpeta.Checked = .Item("Chk_04")
                Chk_Previa_liberacion_de_fondos.Checked = .Item("Chk_05")

                Txt_Observaciones.Text = UCase(.Item("Observaciones_Chk") & vbCrLf & .Item("Observaciones"))

                If .Item("Autorizado") Then
                    Imagen_AR.Image = Imagenes_32.Images.Item("Autorizado")
                    Rdb_Autorizar.Checked = True : Rdb_Rechazar.Checked = False
                Else
                    Imagen_AR.Image = Imagenes_32.Images.Item("Rechazado")
                    Rdb_Autorizar.Checked = False : Rdb_Rechazar.Checked = True
                End If

                Txt_Observaciones.ReadOnly = True

                Grupo_Autorizar_Rechazar.Enabled = False
                Grupo_Chequeados.Enabled = False
                Btn_Grabar.Visible = False

                Me.Text += Space(1) & "(" & Trim(_RowAprobacion.Item("NombreAutoriza")) & ")"

            End With
        Else
            Btn_Anular_Autorizacion.Visible = False
        End If

        Me.Refresh()

    End Sub

    Private Sub Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Grupo_Texto.Enabled = True

        If Rdb_Autorizar.Checked Then
            Grupo_Texto.Text = "ANTECENDENTES PARA AUTORIZAR"
            Grupo_Chequeados.Enabled = True
        ElseIf Rdb_Rechazar.Checked Then
            Grupo_Texto.Text = "MOTIVOS DEL RECHAZO"
            Chk_Documentar_con_cheque_o_letra.Checked = False
            Chk_Entrega_de_garantia_real.Checked = False
            Chk_Pago_anticipado_de_factura.Checked = False
            Chk_Previa_entrega_de_carpeta.Checked = False
            Chk_Previa_liberacion_de_fondos.Checked = False
            Grupo_Chequeados.Enabled = False
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If Not Rdb_Autorizar.Checked And Not Rdb_Rechazar.Checked Then
            MessageBoxEx.Show(Me, "AUTORIZAR O RECHAZAR", "Debe marcar una opción", MessageBoxButtons.OK, _
                              MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Trim(Txt_Observaciones.Text)) Then
            MessageBoxEx.Show(Me, "Debe ingresar alguna observación", "Falta observación", MessageBoxButtons.OK, _
                              MessageBoxIcon.Stop)
            Txt_Observaciones.Focus()
            Return
        End If

        _Grabar = True
        Me.Close()
    End Sub


    Private Sub Frm_SolCredito_Autorizar_Formulario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click

        Grupo_Autorizar_Rechazar.Enabled = True
        Btn_Anular_Autorizacion.Visible = True
        Btn_Grabar.Visible = True

        Me.Refresh()

    End Sub

    Private Sub Btn_Anular_Autorizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anular_Autorizacion.Click

        ' IN, CO, AN,PR,CM   Se puede anular resolucion
        ' C1,C2, C3,NL  No se puede anular resolucion

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Negocios_01_Enc" & vbCrLf & _
                       "Where Nro_Negocio = '" & _Nro_Negocio & "'"

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Row Is Nothing) Then

            Dim _Estado = _Row.Item("Estado")

            Select Case _Estado
                Case "IN", "CO", "AN", "PR", "CM"
                    If MessageBoxEx.Show(Me, "¿Esta seguro de anular esta resolución?", "Validación", _
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        _Anular = True
                        Me.Close()
                    End If
                Case Else
                    MessageBoxEx.Show(Me, "No es posible anular esta resolución, ya que el documento está cerrado", _
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End Select

        End If

    End Sub
End Class