
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Crear_Meson

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Grabar As Boolean
    Dim _Eliminar As Boolean
    Dim _Orden As Integer

    Dim _Row_Meson As DataRow

    Public ReadOnly Property Pro_Grabar()
        Get
            Return _Grabar
        End Get
    End Property
    Public ReadOnly Property Pro_Eliminar()
        Get
            Return _Eliminar
        End Get
    End Property
    Public Property Pro_Row_Meson() As DataRow
        Get
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & Txt_Codmeson.Text & "'"
            _Row_Meson = _Sql.Fx_Get_DataRow(Consulta_sql)
            Return _Row_Meson
        End Get
        Set(ByVal value As DataRow)
            _Row_Meson = value
        End Set
    End Property

    Enum Enum_Accion
        Nuevo
        Editar
    End Enum
    Dim _Accion As Enum_Accion

    Public Sub New(Optional ByVal _Codmeson As String = "")

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'"
        _Row_Meson = _Sql.Fx_Get_DataRow(Consulta_sql)

        If (_Row_Meson Is Nothing) Then
            _Accion = Enum_Accion.Nuevo
            Btn_Eliminar.Enabled = False
        Else
            Txt_Codmeson.Text = _Row_Meson.Item("Codmeson")
            Txt_Nommeson.Text = _Row_Meson.Item("Nommeson")
            _Orden = _Row_Meson.Item("Orden_Meson")
            Chk_Solicita_Alerta.CheckValue = _Row_Meson.Item("Solicita_Alerta")

            Txt_Operacion.Tag = _Row_Meson.Item("Operacion")

            Dim _Operacion As String = Txt_Operacion.Tag.ToString.Trim & " - " & Trim(_Sql.Fx_Trae_Dato("POPER", "NOMBREOP", "OPERACION = '" & Txt_Operacion.Tag & "'"))
            Txt_Operacion.Text = _Operacion

            Txt_Operacion_Equivalente.Tag = _Row_Meson.Item("Operacion_Equivalente")

            _Operacion = Txt_Operacion_Equivalente.Tag.ToString.Trim & " - " & Trim(_Sql.Fx_Trae_Dato("POPER", "NOMBREOP", "OPERACION = '" & Txt_Operacion_Equivalente.Tag & "'"))
            Txt_Operacion_Equivalente.Text = _Operacion

            Txt_Operacion_Reproceso.Tag = _Row_Meson.Item("Operacion_Reproceso")

            _Operacion = Txt_Operacion_Reproceso.Tag.ToString.Trim & " - " & Trim(_Sql.Fx_Trae_Dato("POPER", "NOMBREOP", "OPERACION = '" & Txt_Operacion_Reproceso.Tag & "'"))
            Txt_Operacion_Reproceso.Text = _Operacion

            _Accion = Enum_Accion.Editar

            Txt_Codmeson.Enabled = False
            Chk_Meson_Virtual.Checked = _Row_Meson.Item("Virtual")
            Chk_Maestro.Checked = _Row_Meson.Item("Maestro")
            Chk_SolicitaConfOperaciones.Checked = _Row_Meson.Item("SolicitaConfOperaciones")
            Chk_ActivaAlPrincipio.Checked = _Row_Meson.Item("ActivaAlPrincipio")

        End If

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Codmeson.FocusHighlightEnabled = False
            Txt_Nommeson.FocusHighlightEnabled = False
            Txt_Operacion.FocusHighlightEnabled = False
            Txt_Operacion_Equivalente.FocusHighlightEnabled = False
            Txt_Operacion_Reproceso.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Crear_Meson_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case _Accion
            Case Enum_Accion.Nuevo
                Me.ActiveControl = Txt_Codmeson
            Case Enum_Accion.Editar
                Me.ActiveControl = Txt_Nommeson
        End Select
    End Sub

    Sub Sb_Grabar()

        If Not Me.Fx_Revisar_Meson_Maestro(Txt_Codmeson.Text) Then
            Return
        End If

        Select Case _Accion

            Case Enum_Accion.Nuevo

                Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_Mesones", "Codmeson = '" & Txt_Codmeson.Text & "'")

                If CBool(_Reg) Then
                    MessageBoxEx.Show(Me, "El código del mesón ya existe en el sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Txt_Codmeson.Focus()
                    Return
                End If

                _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_Mesones", "Nommeson = '" & Txt_Nommeson.Text & "'")

                If CBool(_Reg) Then
                    MessageBoxEx.Show(Me, "El nombre del mesón ya existe en el sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Txt_Nommeson.Focus()
                    Return
                End If

                _Orden = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_Mesones", "Max(Orden_Meson)") + 1

            Case Enum_Accion.Editar

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & Txt_Codmeson.Text & "'" & vbCrLf & vbCrLf
                _Sql.Ej_consulta_IDU(Consulta_sql)

        End Select

        Dim _Virtual As Integer = CInt(Chk_Meson_Virtual.Checked) * -1

        Consulta_sql = String.Empty

        If Chk_Maestro.Checked Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdc_Mesones Set Maestro = 0" & vbCrLf
        End If

        Consulta_sql = Consulta_sql &
                       "Insert Into " & _Global_BaseBk & "Zw_Pdc_Mesones (Codmeson,Nommeson,Virtual,Operacion,Orden_Meson,Operacion_Equivalente," &
                       "Operacion_Reproceso,Solicita_Alerta,Maestro,SolicitaConfOperaciones,ActivaAlPrincipio)
                       Values ('" & Txt_Codmeson.Text & "','" & Txt_Nommeson.Text & "'," & _Virtual & ",'" & Txt_Operacion.Tag & "',
                       " & _Orden & ",'" & Txt_Operacion_Equivalente.Tag &
                       "','" & Txt_Operacion_Reproceso.Tag &
                       "'," & Convert.ToInt32(Chk_Solicita_Alerta.Checked) &
                       "," & Convert.ToInt32(Chk_Maestro.Checked) &
                       "," & Convert.ToInt32(Chk_SolicitaConfOperaciones.Checked) &
                       "," & Convert.ToInt32(Chk_ActivaAlPrincipio.Checked) & ")"

        If Not String.IsNullOrEmpty(Txt_Operacion_Equivalente.Tag) Then

            Consulta_sql += vbCrLf & vbCrLf &
                            "Update " & _Global_BaseBk & "Zw_Pdc_Mesones Set Operacion_Equivalente = '" & Txt_Operacion.Tag & "' 
                             Where Operacion = '" & Txt_Operacion_Equivalente.Tag & "'"

        End If

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Grabar = True
            Me.Close()

        End If

    End Sub

    Function Fx_Revisar_Meson_Maestro(_Codmeson As String) As Boolean

        Dim _Maestro = Convert.ToInt32(Chk_Maestro.Checked)
        Dim _Habilitado = True

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Maestro = 1"
        Dim _Row_Meson_Maestro As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Chk_Maestro.Checked Then
            If Not IsNothing(_Row_Meson_Maestro) Then
                If _Row_Meson_Maestro.Item("Codmeson").ToString.Trim <> _Codmeson.Trim Then
                    If MessageBoxEx.Show(Me, "Ya existe un mesón maestro, no puede haber 2 mesones maestros" & vbCrLf &
                              "Mesón maestro: " & _Row_Meson_Maestro.Item("Codmeson").ToString.Trim & " - " & _Row_Meson_Maestro.Item("Nommeson") & vbCrLf & vbCrLf &
                              "¿Confirma dejar el mesón " & Txt_Codmeson.Text.Trim & " - " & Txt_Nommeson.Text.Trim & " como mesón maestro?",
                              "Validación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                        Return False
                    End If
                End If
            End If
        Else
            If Not IsNothing(_Row_Meson_Maestro) Then
                If _Row_Meson_Maestro.Item("Codmeson").ToString.Trim = _Codmeson.Trim Then
                    MessageBoxEx.Show(Me, "Este es el mesón maestro, no puede dejar la fabrica sin un mesón maestro" & vbCrLf &
                              "Para cambiar al mesón maestro debe ir a la ficha del mesón y asignarlo como maestro",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Chk_Maestro.Checked = True
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click
        Sb_Grabar()
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_MesonVsOperario", "Codmeson = '" & Txt_Codmeson.Text & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Este mesón tiene trabajos asociados, no se puede eliminar el registro", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_MesonVsMaquina", "Codmeson = '" & Txt_Codmeson.Text & "'")

        Dim _MsgMaq As String

        If _Reg Then
            _MsgMaq = "Existen maquinas asociadas a este mesón, se quitaran todas la maquinas al eliminar el mesón." & vbCrLf & vbCrLf
        End If

        If MessageBoxEx.Show(Me, _MsgMaq & "¿Está seguro de eliminar este registro?", "Eliminar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            _Eliminar = True
            Me.Close()
        End If


    End Sub

    Private Sub Btn_Buscar_Operacion_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Operacion.Click

        Dim _Sql_Filtro_Condicion_Extra = "And OPERACION Not In (Select Operacion From " & _Global_BaseBk & "Zw_Pdc_Mesones)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operaciones, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then
            Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro
            Consulta_sql = String.Empty

            Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

            Dim _Operacion = Trim(_Row.Item("Codigo"))
            Dim _Nombremop = Trim(_Row.Item("Descripcion"))

            Txt_Operacion.Tag = _Operacion
            Txt_Operacion.Text = _Operacion & " - " & _Nombremop

        End If

    End Sub

    Private Sub Btn_Bucasr_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Bucasr_Operacion_Equiv.Click

        Dim _Sql_Filtro_Condicion_Extra = "And OPERACION In (Select Operacion From " & _Global_BaseBk & "Zw_Pdc_Mesones) 
                                           And OPERACION <> '" & Txt_Operacion.Tag & "'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operaciones, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then
            Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro
            Consulta_sql = String.Empty

            Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

            Dim _Operacion = Trim(_Row.Item("Codigo"))
            Dim _Nombremop = Trim(_Row.Item("Descripcion"))

            Txt_Operacion_Equivalente.Tag = _Operacion
            Txt_Operacion_Equivalente.Text = _Operacion & " - " & _Nombremop

        End If

    End Sub

    Private Sub Buscar_Operacion_Reproceso_Click(sender As Object, e As EventArgs) Handles Buscar_Operacion_Reproceso.Click

        Dim _Sql_Filtro_Condicion_Extra = "And OPERACION Not In ('" & Txt_Operacion.Tag & "','" & Txt_Operacion_Equivalente.Tag & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operaciones, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then
            Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro
            Consulta_sql = String.Empty

            Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

            Dim _Operacion = Trim(_Row.Item("Codigo"))
            Dim _Nombremop = Trim(_Row.Item("Descripcion"))

            Txt_Operacion_Reproceso.Tag = _Operacion
            Txt_Operacion_Reproceso.Text = _Operacion & " - " & _Nombremop

        End If

    End Sub

    Private Sub Chk_SolicitaConfOperaciones_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Chk_SolicitaConfOperaciones.HelpRequested
        MessageBoxEx.Show(Me, "Hola mundo...", "Help!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
