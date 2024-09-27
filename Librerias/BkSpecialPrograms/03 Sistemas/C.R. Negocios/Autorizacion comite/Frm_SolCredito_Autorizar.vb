Imports DevComponents.DotNetBar

Public Class Frm_SolCredito_Autorizar

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Nro_Negocio As String
    Dim _Grabar As Boolean

    Dim _Puede_Dejar_Ausente_Un_Gerenete As Boolean
    Dim _Estado As String

    Enum _Permiso
        Gerencia_General
        Gerencia_Administracion_Finanza
        Gerencia_Credito_Cobranza
        Autorizacion_Extraordinaria
    End Enum

    Dim _Chk_GG, _Chk_GAF, _Chk_GCC, _Chk_Extra As Boolean
    Dim _Boton As Object
    Dim _Row

    Public Property Pro_Nro_Negocio() As String
        Get
            Return _Nro_Negocio
        End Get
        Set(ByVal value As String)
            _Nro_Negocio = value
        End Set
    End Property

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property


    Public Sub New(ByVal Puede_Dejar_Ausente_Un_Gerenete As Boolean, ByVal Estado As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Puede_Dejar_Ausente_Un_Gerenete = Puede_Dejar_Ausente_Un_Gerenete
        _Estado = Estado
    End Sub

    Private Sub Frm_SolCredito_Autorizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _Nro_Negocio & "'"
        Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblAprobacion.Rows.Count) Then

            For Each _Fila As DataRow In _TblAprobacion.Rows

                Dim _CodAprobacion = _Fila.Item("CodAprobacion")
                Dim _Autorizado = _Fila.Item("Autorizado")
                Dim _Ausente = _Fila.Item("Ausente")

                Dim _Tex_Autorizado

                If _Autorizado Then
                    _Tex_Autorizado = "AUTORIZADO"
                Else
                    _Tex_Autorizado = "RECHAZADO"
                End If

                If _Ausente Then
                    _Tex_Autorizado = "AUSENTE"
                End If

                If _CodAprobacion = "01" Then
                    Btn_Gte_General.Checked = True
                    Btn_Gte_General.TitleText = _Tex_Autorizado
                ElseIf _CodAprobacion = "02" Then
                    Btn_Gte_Admin_Finanzas.Checked = True
                    Btn_Gte_Admin_Finanzas.TitleText = _Tex_Autorizado
                ElseIf _CodAprobacion = "03" Then
                    Btn_Gte_Cto_Cobranza.Checked = True
                    Btn_Gte_Cto_Cobranza.TitleText = _Tex_Autorizado
                ElseIf _CodAprobacion = "Ex" Then
                    Btn_Gte_Extra_Ordinaria.Checked = True
                    Btn_Gte_Extra_Ordinaria.TitleText = _Tex_Autorizado
                End If

            Next

        End If

        _Chk_GG = Btn_Gte_General.Checked
        _Chk_GAF = Btn_Gte_Admin_Finanzas.Checked
        _Chk_GCC = Btn_Gte_Cto_Cobranza.Checked
        _Chk_Extra = Btn_Gte_Extra_Ordinaria.Checked


        AddHandler Btn_Gte_Admin_Finanzas.MouseDown, AddressOf Sb_Btn_MouseDown
        AddHandler Btn_Gte_Cto_Cobranza.MouseDown, AddressOf Sb_Btn_MouseDown
        AddHandler Btn_Gte_General.MouseDown, AddressOf Sb_Btn_MouseDown
        AddHandler Btn_Gte_Extra_Ordinaria.MouseDown, AddressOf Sb_Btn_MouseDown


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Gte_General_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Gte_General.Click

        If Btn_Gte_General.Checked Then

            Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," & _
                   "NomAprobacion as 'Cargo'," & vbCrLf & _
                   "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf & _
                   "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf & _
                   "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf & _
                   "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf & _
                   "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf & _
                   "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _Nro_Negocio & "' And CodAprobacion = '01'"

            Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")
            Dim _Observaciones = _Tbl.Rows(0).Item("Observaciones")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Pro_Nro_Negocio = _Nro_Negocio
                Fm.Text = "Gerencia general"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.ShowDialog(Me)
                Dim _Anular As Boolean = Fm.Pro_Anular
                Fm.Dispose()

                If _Anular Then
                    Sb_Anular_Resolucion(_Nro_Negocio, "01")
                End If
            End If

        Else

            If _Estado = "Cerrado" Or _Estado = "Completado" Then
                MessageBoxEx.Show(Me, "Ya no se puede hacer gestión", "Negocio cerrado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Puede_Dejar_Ausente_Un_Gerenete Then
                _Boton = sender
                ShowContextMenu(Menu_Contextual_01)
            Else
                Sb_Autorizar_Rechazar("Scn00007", _Permiso.Gerencia_General)
            End If
        End If

    End Sub

    Private Sub Btn_Gte_Admin_Finanzas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Gte_Admin_Finanzas.Click

        If _Chk_GAF Then 'Btn_Gte_Admin_Finanzas.Checked Then

            Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," & _
                           "NomAprobacion as 'Cargo'," & vbCrLf & _
                           "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf & _
                           "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf & _
                           "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf & _
                           "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf & _
                           "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf & _
                           "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _Nro_Negocio & "' And CodAprobacion = '02'"

            Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")
            Dim _Observaciones = _Tbl.Rows(0).Item("Observaciones")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Pro_Nro_Negocio = _Nro_Negocio
                Fm.Text = "Gerecnia de administración y finanzas"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.ShowDialog(Me)
                Dim _Anular As Boolean = Fm.Pro_Anular
                Fm.Dispose()

                If _Anular Then
                    Sb_Anular_Resolucion(_Nro_Negocio, "02")
                End If

            End If

        Else

            If _Estado = "Cerrado" Or _Estado = "Completado" Then
                MessageBoxEx.Show(Me, "Ya no se puede hacer gestión", "Negocio cerrado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Puede_Dejar_Ausente_Un_Gerenete Then
                _Boton = sender
                ShowContextMenu(Menu_Contextual_01)
            Else
                Sb_Autorizar_Rechazar("Scn00008", _Permiso.Gerencia_Administracion_Finanza)
            End If
        End If
    End Sub

    Private Sub Btn_Gte_Cto_Cobranza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Gte_Cto_Cobranza.Click

        If Btn_Gte_Cto_Cobranza.Checked Then

            Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," & _
                   "NomAprobacion as 'Cargo'," & vbCrLf & _
                   "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf & _
                   "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf & _
                   "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf & _
                   "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf & _
                   "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf & _
                   "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _Nro_Negocio & "' And CodAprobacion = '03'"
            'Dim _TblAprobacion As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr" & vbCrLf & _
            '               "Where Nro_Negocio = '" & _Nro_Negocio & "' And CodAprobacion = '03'"
            Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")
            Dim _Observaciones = _Tbl.Rows(0).Item("Observaciones")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Pro_Nro_Negocio = _Nro_Negocio
                Fm.Text = "Gerencia de crédito y cobranza"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.ShowDialog(Me)
                Dim _Anular As Boolean = Fm.Pro_Anular
                Fm.Dispose()

                If _Anular Then
                    Sb_Anular_Resolucion(_Nro_Negocio, "03")
                End If

            End If

        Else

            If _Estado = "Cerrado" Or _Estado = "Completado" Then
                MessageBoxEx.Show(Me, "Ya no se puede hacer gestión", "Negocio cerrado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Puede_Dejar_Ausente_Un_Gerenete Then
                _Boton = sender
                ShowContextMenu(Menu_Contextual_01)
            Else
                Sb_Autorizar_Rechazar("Scn00009", _Permiso.Gerencia_Credito_Cobranza)
            End If
        End If

    End Sub

    Sub Sb_Anular_Resolucion(ByVal _Nro_Negocio As String, _
                             ByVal _CodAprobacion As String)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Negocios_03_Apr" & vbCrLf & _
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And CodAprobacion = '" & _CodAprobacion & "'" & vbCrLf & _
                       "Delete " & _Global_BaseBk & "Zw_Negocios_03_Apr" & vbCrLf & _
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And CodFuncionario = 'ZBK'"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            _Grabar = True
            Me.Close()
        End If

    End Sub

    Sub Sb_Autorizar_Rechazar(ByVal _Permiso As String, _
                              ByVal _CodigoPermiso As _Permiso)

        Dim _Permitido As Boolean

        Dim _CodFuncionario = FUNCIONARIO
        Dim _NombreAprueba = Nombre_funcionario_activo
        Dim _CodAutoriza = _CodFuncionario
        Dim _NombreAutoriza = _NombreAprueba

        If Not Fx_Tiene_Permiso(Me, _Permiso, , True) Then

            MensajeSinPermiso(_Permiso, FUNCIONARIO, Nombre_funcionario_activo)

            Dim Fm_ As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, _Permiso, True, False)
            Fm_.ShowDialog(Me)
            If Fm_.Pro_Permiso_Aceptado Then
                _Permitido = Fm_.Pro_Permiso_Aceptado
                _CodAutoriza = Fm_.Pro_RowUsuario.Item("KOFU")
                _NombreAutoriza = Fm_.Pro_RowUsuario.Item("NOKOFU")
            Else
                Return
            End If

        Else
            _Permitido = True
        End If

        Dim _CodAprobacion = String.Empty
        Dim _NomAprobacion = String.Empty

        Select Case _CodigoPermiso
            Case Frm_SolCredito_Autorizar._Permiso.Gerencia_General
                _CodAprobacion = "01"
                _NomAprobacion = "Gerencia general"
            Case Frm_SolCredito_Autorizar._Permiso.Gerencia_Administracion_Finanza
                _CodAprobacion = "02"
                _NomAprobacion = "Gerencia de administración y finanzas"
            Case Frm_SolCredito_Autorizar._Permiso.Gerencia_Credito_Cobranza
                _CodAprobacion = "03"
                _NomAprobacion = "Gerencia de crédito y cobranza"
            Case Frm_SolCredito_Autorizar._Permiso.Autorizacion_Extraordinaria

                _CodAprobacion = "Ex"
                _NomAprobacion = "Autorización Extraordinaria"

                If _Permitido Then

                    MessageBoxEx.Show(Me, "Para realizar esta acción necesitamos confirmar nuevamente su clave de usuario", _
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    Dim Fm_ As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, _Permiso, False, False)
                    Fm_.ShowDialog(Me)
                    If Fm_.Pro_Permiso_Aceptado Then
                        _Permitido = Fm_.Pro_Permiso_Aceptado
                        _CodAutoriza = Fm_.Pro_RowUsuario.Item("KOFU")
                        _NombreAutoriza = Fm_.Pro_RowUsuario.Item("NOKOFU")
                    Else
                        Return
                    End If

                End If

        End Select

        If _Permitido Then

            Dim Fm As New Frm_SolCredito_Autorizar_Formulario
            Fm.Text = _NomAprobacion
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then

                Dim _Chk1 = CInt(Fm.Chk_Documentar_con_cheque_o_letra.Checked) * -1
                Dim _Chk2 = CInt(Fm.Chk_Entrega_de_garantia_real.Checked) * -1
                Dim _Chk3 = CInt(Fm.Chk_Pago_anticipado_de_factura.Checked) * -1
                Dim _Chk4 = CInt(Fm.Chk_Previa_entrega_de_carpeta.Checked) * -1
                Dim _Chk5 = CInt(Fm.Chk_Previa_liberacion_de_fondos.Checked) * -1
                Dim _Autorizado = CInt(Fm.Rdb_Autorizar.Checked) * -1
                Dim _Observacion = Replace(Fm.Txt_Observaciones.Text, "'", "´")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Negocios_03_Apr (Nro_Negocio,CodFuncionario," &
                               "NombreAprueba,Fecha_Hora_Aprueba,Autorizado," &
                               "CodAprobacion,NomAprobacion,Observaciones,Chk_01,Chk_02,Chk_03,Chk_04,Chk_05,CodAutoriza,NombreAutoriza) Values " &
                               "('" & _Nro_Negocio & "','" & _CodFuncionario & "','" & _NombreAprueba &
                               "',Getdate()," & _Autorizado & ",'" & _CodAprobacion & "','" & _NomAprobacion & "','" & _Observacion &
                               "'," & _Chk1 & "," & _Chk2 & "," & _Chk3 & "," & _Chk4 & "," & _Chk5 & ",'" & _CodAutoriza & "','" & _NombreAutoriza & "')"

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    _Grabar = True
                    Me.Close()
                End If

            End If
            Fm.Dispose()
        Else
            MensajeSinPermiso(_Permiso, _CodAutoriza, _NombreAutoriza)
        End If

    End Sub

    Private Sub Frm_SolCredito_Autorizar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Btn_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            _Boton = sender
            ShowContextMenu(Menu_Contextual_01)
        End If
    End Sub

    Private Sub Btn_Mnu_Marcar_Ausente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Marcar_Ausente.Click

        If _Puede_Dejar_Ausente_Un_Gerenete Then

            If Fx_Tiene_Permiso(Me, "Scn00019") Then

                Dim _Name = _Boton.name
                Dim _Aceptado As Boolean

                Dim _Observacion As String

                _Aceptado = InputBox_Bk(Me, "Motivo ausencia", "Dejar miebro del comite como ausente", _Observacion, True,
                                               _Tipo_Mayus_Minus.Mayusculas, 300, True, _Tipo_Imagen.Texto, False,
                                               _Tipo_Caracter.Cualquier_caracter)

                If _Aceptado Then

                    Dim _CodAprobacion = String.Empty
                    Dim _NomAprobacion = String.Empty

                    Select Case _Name
                        Case "Btn_Gte_General"
                            _CodAprobacion = "01"
                            _NomAprobacion = "Gerencia general"
                        Case "Btn_Gte_Admin_Finanzas"
                            _CodAprobacion = "02"
                            _NomAprobacion = "Gerencia de administración y finanzas"
                        Case "Btn_Gte_Cto_Cobranza"
                            _CodAprobacion = "03"
                            _NomAprobacion = "Gerencia de crédito y cobranza"
                    End Select

                    Dim _CodFuncionario = FUNCIONARIO
                    Dim _NombreAprueba = Nombre_funcionario_activo
                    Dim _CodAutoriza = _CodFuncionario
                    Dim _NombreAutoriza = _NombreAprueba

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Negocios_03_Apr (Nro_Negocio,CodFuncionario," &
                                   "NombreAprueba,Fecha_Hora_Aprueba,Autorizado," &
                                   "CodAprobacion,NomAprobacion,Observaciones,Chk_01,Chk_02,Chk_03,Chk_04,Chk_05,CodAutoriza,NombreAutoriza,Ausente) Values " &
                                   "('" & _Nro_Negocio & "','" & _CodFuncionario & "','" & _NombreAprueba &
                                   "',Getdate(),0,'" & _CodAprobacion & "','" & _NomAprobacion & "','" & _Observacion &
                                   "',0,0,0,0,0,'" & _CodAutoriza & "','" & _NombreAutoriza & "',1)"

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        Me.Close()
                    End If

                End If
            End If

        Else
            MessageBoxEx.Show(Me, "Para poder hacer esta gestión el negocio debe estar completado", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Hacer_Gestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Hacer_Gestion.Click

        Dim _Name = _Boton.name

        Select Case _Name
            Case "Btn_Gte_General"
                Call Btn_Gte_General_Click(Nothing, Nothing)
                'Sb_Autorizar_Rechazar("Scn00007", _Permiso.Gerencia_General)
            Case "Btn_Gte_Admin_Finanzas"
                Call Btn_Gte_Admin_Finanzas_Click(Nothing, Nothing)
                'Sb_Autorizar_Rechazar("Scn00008", _Permiso.Gerencia_Administracion_Finanza)
            Case "Btn_Gte_Cto_Cobranza"
                Call Btn_Gte_Cto_Cobranza_Click(Nothing, Nothing)
                'Sb_Autorizar_Rechazar("Scn00009", _Permiso.Gerencia_Credito_Cobranza)
            Case "Btn_Gte_Cto_Cobranza"
                Call Btn_Gte_Extra_Ordinaria_Click(Nothing, Nothing)
                'Sb_Autorizar_Rechazar("Scn00009", _Permiso.Gerencia_Credito_Cobranza)
        End Select

    End Sub

    Private Sub Btn_Gte_General_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Gte_General.MouseUp
        Btn_Gte_General.Checked = _Chk_GG
    End Sub

    Private Sub Btn_Gte_Admin_Finanzas_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Gte_Admin_Finanzas.MouseUp
        Btn_Gte_Admin_Finanzas.Checked = _Chk_GAF
    End Sub

    Private Sub Btn_Gte_Cto_Cobranza_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Gte_Cto_Cobranza.MouseUp
        Btn_Gte_Cto_Cobranza.Checked = _Chk_GCC
    End Sub

    Private Sub Btn_Gte_Extra_Ordinaria_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Gte_Extra_Ordinaria.MouseUp
        Btn_Gte_Extra_Ordinaria.Checked = _Chk_Extra
    End Sub

    Private Sub Btn_Gte_Extra_Ordinaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Gte_Extra_Ordinaria.Click

        If _Chk_Extra Then 'Btn_Gte_Admin_Finanzas.Checked Then

            Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," & _
                           "NomAprobacion as 'Cargo'," & vbCrLf & _
                           "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf & _
                           "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf & _
                           "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf & _
                           "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf & _
                           "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf & _
                           "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _Nro_Negocio & "' And CodAprobacion = 'Ex'"

            Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")
            Dim _Observaciones = _Tbl.Rows(0).Item("Observaciones")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Pro_Nro_Negocio = _Nro_Negocio
                Fm.Text = "Aprobación Extraordinaria"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.ShowDialog(Me)
                Dim _Anular As Boolean = Fm.Pro_Anular
                Fm.Dispose()

                If _Anular Then
                    Sb_Anular_Resolucion(_Nro_Negocio, "Ex")
                End If

            End If

        Else

            If _Estado = "Cerrado" Or _Estado = "Completado" Then
                MessageBoxEx.Show(Me, "Ya no se puede hacer gestión", "Negocio cerrado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Puede_Dejar_Ausente_Un_Gerenete Then
                _Boton = sender
                ShowContextMenu(Menu_Contextual_01)
            Else
                Sb_Autorizar_Rechazar("Scn00025", _Permiso.Autorizacion_Extraordinaria)
            End If
        End If
    End Sub


End Class