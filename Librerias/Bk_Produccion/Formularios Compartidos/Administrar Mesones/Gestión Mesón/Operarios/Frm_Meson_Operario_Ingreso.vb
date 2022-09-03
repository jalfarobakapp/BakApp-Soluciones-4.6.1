Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Meson_Operario_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Pedir_Clave_Para_Salir As Boolean

    Public Sub New(Pedir_Clave_Para_Salir)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Pedir_Clave_Para_Salir = Pedir_Clave_Para_Salir

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Ingresar_Manualmente.ForeColor = Color.White
            Btn_Buscar_OT.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Meson_Operario_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdc_Mesones Set Abierto = 0,NombreEquipo_Abierto = '',Abierto_FechaHora = Null,Codigoob_Abierto = '' 
                        Where NombreEquipo_Abierto = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Frm_Meson_Operario_Ingreso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If _Pedir_Clave_Para_Salir Then

            Dim _Validar As Boolean

            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pdc00003", True, False)
            Fm.Text = "CERRAR SIS. MESONES"
            Fm.Pro_Cerrar_Automaticamente = True
            Fm.ShowDialog(Me)
            _Validar = Fm.Pro_Permiso_Aceptado
            Fm.Dispose()

            If Not _Validar Then
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub Btn_Ingresar_DFA_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_DFA.Click

        Try

            Me.Enabled = False

            Dim _Row_Operario As DataRow

            Dim Fm_Pw As New Frm_Buscar_Pistoleando(Frm_Buscar_Pistoleando.Enum_Tipo_Busqueda.Operario_Clave)
            Fm_Pw.Pro_Cerrar_automaticamente = True
            Fm_Pw.ShowDialog(Me)
            _Row_Operario = Fm_Pw.Pro_Row_Fila
            Fm_Pw.Dispose()

            If Not IsNothing(_Row_Operario) Then

                Dim _Codigoob = _Row_Operario.Item("CODIGOOB")
                Dim _Nombreob = _Row_Operario.Item("NOMBREOB").ToString.Trim

                Dim _Clas_Alerta_Trab_Sin_Cerrar As New Clas_Alerta_Trab_Sin_Cerrar
                Dim _Puede_Acceder_A_Los_Mesones = True

                Dim _Trabajos_Pendientes = _Clas_Alerta_Trab_Sin_Cerrar.Fx_Tiene_Trabajos_Abiertos(_Codigoob)

                If _Trabajos_Pendientes > 0 Then

                    MessageBoxEx.Show(Me, "Usted tiene trabajos pendientes sin cerrar" & vbCrLf &
                                      "Para poder seguir con la gestión primero debe cerrar los trabajos pendiente", "ALERTA",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Dim Fm1 As New Frm_TrabMaq_Sin_Cerrar(_Codigoob)
                    Fm1.Text = "Operario: " & _Codigoob.Trim & "-" & _Nombreob
                    Fm1.ShowDialog(Me)
                    Fm1.Dispose()

                    _Puede_Acceder_A_Los_Mesones = Not CBool(_Clas_Alerta_Trab_Sin_Cerrar.Fx_Tiene_Trabajos_Abiertos(_Codigoob))

                End If

                If Not _Puede_Acceder_A_Los_Mesones Then
                    MessageBoxEx.Show(Me, "No puede seguir con la gestión, primero debe cerrar los trabjos pendientes", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Dim Fm_Ms As New Frm_Meson_Operario(_Codigoob, True)
                Fm_Ms.Pro_Cerrar_automaticamente = True

                If Convert.ToBoolean(Fm_Ms.Pro_Tbl_Mesones.Rows.Count) Then

                    Dim _Codmeson As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_MesonVsOperario", "Codmeson", "Codigoob = '" & _Codigoob & "' And Por_Defecto = 1")

                    If Not String.IsNullOrEmpty(Trim(_Codmeson)) Then
                        Fm_Ms.Cmb_Mesones.SelectedValue = _Codmeson
                    End If

                    Fm_Ms.ShowDialog(Me)

                Else
                    MessageBoxEx.Show(Me, "NO TIENE MESONES ASIGNADOS PARA TRABAJAR", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Fm_Ms.Dispose()

            End If

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try


    End Sub

    Private Sub Frm_Meson_Operario_Ingreso_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Enter Then
            Call Btn_Ingresar_DFA_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Btn_Ingresar_Manualmente_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_Manualmente.Click

        Dim _Permitir_Ing_DFA_Directo As Boolean

        If _Pedir_Clave_Para_Salir Then

            Dim Fm_p As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pdc00007", True, False)
            Fm_p.Text = "INGRESE CLAVE DE AUTORIZACION"
            Fm_p.Pro_Cerrar_Automaticamente = True
            Fm_p.TopMost = Me.TopMost
            Fm_p.ShowDialog(Me)
            _Permitir_Ing_DFA_Directo = Fm_p.Pro_Permiso_Aceptado
            Fm_p.Dispose()

        Else

            _Permitir_Ing_DFA_Directo = True

        End If


        If _Permitir_Ing_DFA_Directo Then

            Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"

            Dim _Filtrar As New Clas_Filtros_Random(Me)
            Dim _Codigoob As String
            Dim _Nombreob As String

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operarios, _Sql_Filtro_Condicion_Extra,
                                   Nothing, False, True) Then

                Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

                Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

                _Codigoob = Trim(_Row.Item("Codigo"))
                _Nombreob = Trim(_Row.Item("Descripcion"))


                Dim _Clas_Alerta_Trab_Sin_Cerrar As New Clas_Alerta_Trab_Sin_Cerrar
                Dim _Puede_Acceder_A_Los_Mesones = True

                Dim _Trabajos_Pendientes = _Clas_Alerta_Trab_Sin_Cerrar.Fx_Tiene_Trabajos_Abiertos(_Codigoob)

                If _Trabajos_Pendientes > 0 Then

                    MessageBoxEx.Show(Me, "Usted tiene trabajos pendientes sin cerrar" & vbCrLf &
                                      "Para poder seguir con la gestión primero debe cerrar los trabajos pendiente", "ALERTA",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Dim Fm1 As New Frm_TrabMaq_Sin_Cerrar(_Codigoob)
                    Fm1.Text = "Operario: " & _Codigoob.Trim & "-" & _Nombreob
                    Fm1.ShowDialog(Me)
                    Fm1.Dispose()

                    _Puede_Acceder_A_Los_Mesones = Not CBool(_Clas_Alerta_Trab_Sin_Cerrar.Fx_Tiene_Trabajos_Abiertos(_Codigoob))

                End If

                If Not _Puede_Acceder_A_Los_Mesones Then
                    MessageBoxEx.Show(Me, "No puede seguir con la gestión, primero debe cerrar los trabjos pendientes", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If


                Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_MesonVsOperario", "Codigoob = '" & _Codigoob & "'")

                If CBool(_Reg) Then

                    Dim _Codmeson As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_MesonVsOperario", "Codmeson", "Codigoob = '" & _Codigoob & "' And Por_Defecto = 1")

                    Dim Fm As New Frm_Meson_Operario(_Codigoob, True)
                    If Not String.IsNullOrEmpty(Trim(_Codmeson)) Then
                        Fm.Cmb_Mesones.SelectedValue = _Codmeson
                    End If
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                Else

                    MessageBoxEx.Show(Me, "No existen mesones asiganados a este usuario" & vbCrLf &
                                      "Código: " & Trim(_Codigoob) & " - " & _Nombreob, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Buscar_OT_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_OT.Click

        Dim _Permitir_Ing_DFA_Directo As Boolean

        If _Pedir_Clave_Para_Salir Then

            Dim Fm_p As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pdc00007", True, False)
            Fm_p.Text = "INGRESE CLAVE DE AUTORIZACION"
            Fm_p.Pro_Cerrar_Automaticamente = True
            Fm_p.TopMost = Me.TopMost
            Fm_p.ShowDialog(Me)
            _Permitir_Ing_DFA_Directo = Fm_p.Pro_Permiso_Aceptado
            Fm_p.Dispose()

        Else

            _Permitir_Ing_DFA_Directo = True

        End If


        If _Permitir_Ing_DFA_Directo Then

            Dim Fm As New Frm_Meson_Asignar_Productos(Frm_Meson_Asignar_Productos.Enum_Tipo_OT.Fabricacion)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class
