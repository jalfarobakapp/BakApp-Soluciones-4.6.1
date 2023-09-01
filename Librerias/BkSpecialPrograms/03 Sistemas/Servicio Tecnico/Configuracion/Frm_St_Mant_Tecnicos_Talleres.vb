Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms

Public Class Frm_St_Mant_Tecnicos_Talleres

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CodFuncionario As String
    Dim _Row_Tecnico As DataRow
    Dim _Grabado As Boolean
    Dim _Eliminado As Boolean

    Dim _Tiene_OT As Boolean

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum

    Dim _CodPais As String
    Dim _CodCiudad As String
    Dim _CodComuna As String
    Dim _Pais As String
    Dim _Ciudad As String
    Dim _Comuna As String

#Region "PROPIEDADES"

    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabado
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Pro_Eliminado() As Boolean
        Get
            Return _Eliminado
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Pro_Row_Tecnico() As DataRow
        Get
            Return _Row_Tecnico
        End Get
        Set(value As DataRow)
            _Row_Tecnico = value
        End Set
    End Property

    Public Property CodPais As String
        Get
            Return _CodPais
        End Get
        Set(value As String)
            _CodPais = value
        End Set
    End Property

    Public Property CodCiudad As String
        Get
            Return _CodCiudad
        End Get
        Set(value As String)
            _CodCiudad = value
        End Set
    End Property

    Public Property CodComuna As String
        Get
            Return _CodComuna
        End Get
        Set(value As String)
            _CodComuna = value
        End Set
    End Property

    Public Property Pais As String
        Get
            Return _Pais
        End Get
        Set(value As String)
            _Pais = value
        End Set
    End Property

    Public Property Ciudad As String
        Get
            Return _Ciudad
        End Get
        Set(value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property Comuna As String
        Get
            Return _Comuna
        End Get
        Set(value As String)
            _Comuna = value
        End Set
    End Property

#End Region

    Public Sub New(Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Mant_Tecnicos_Talleres_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Rdb_Chk_Taller_Externo.CheckedChanged, AddressOf Chk_Taller_Externo_CheckedChanged

        Txt_Email.CharacterCasing = CharacterCasing.Lower

        If _Accion = Accion.Nuevo Then

            Fx_Habilitar_Objetos(True)

        ElseIf _Accion = Accion.Editar Then

            _CodFuncionario = _Row_Tecnico.Item("CodFuncionario")

            Txt_NomFuncionario.Text = _Row_Tecnico.Item("NomFuncionario")
            Txt_Direccion.Text = _Row_Tecnico.Item("Direccion")
            Txt_Email.Text = _Row_Tecnico.Item("Email")
            Txt_Informacion.Text = _Row_Tecnico.Item("Informacion")
            Txt_Telefono.Text = _Row_Tecnico.Item("Telefono")
            Txt_PwTecnico.Text = _Row_Tecnico.Item("PwTecnico")

            Rating_Star.Rating = _Row_Tecnico.Item("Star")

            _CodPais = _Row_Tecnico.Item("Pais")
            _CodCiudad = _Row_Tecnico.Item("Ciudad")
            _CodComuna = _Row_Tecnico.Item("Comuna")

            Sb_Llenar_Ciudad_Comuna()

            Rdb_Chk_Taller_Externo.Checked = _Row_Tecnico.Item("Chk_Taller_Externo")
            Rdb_EsTecnico.Checked = _Row_Tecnico.Item("EsTecnico")
            Rdb_EsTaller.Checked = _Row_Tecnico.Item("EsTaller")

            Chk_Habilitado.Checked = _Row_Tecnico.Item("Chk_Habilitado")
            Chk_Supervisor.Checked = _Row_Tecnico.Item("Chk_Supervisor")
            Chk_Domicilio.Checked = _Row_Tecnico.Item("Chk_Domicilio")

            Btn_Editar.Visible = True
            Btn_Eliminar.Visible = True

            _Tiene_OT = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Encabezado",
                                        "CodTecnico_Asignado = '" & _CodFuncionario & "' Or" & Space(1) &
                                        "CodTecnico_Repara = '" & _CodFuncionario & "' And CodEstado <> 'N'"))

            Fx_Habilitar_Objetos(False)

        End If

    End Sub

    Sub Sb_Llenar_Ciudad_Comuna()

        Consulta_sql = "Select Pa.KOPA,Pa.NOKOPA,Ci.KOCI,Ci.NOKOCI,Cm.KOCM,Cm.NOKOCM,
                        Rtrim(Ltrim(Pa.NOKOPA))+' - '+Rtrim(Ltrim(Ci.NOKOCI))+' - '+Rtrim(Ltrim(Cm.NOKOCM)) As Localidad	
                        From TABCM Cm 
                        Inner Join TABCI Ci On Ci.KOPA = Cm.KOPA And Ci.KOCI = Cm.KOCI
                        Inner Join TABPA Pa On Pa.KOPA = Cm.KOPA
                        Where Pa.KOPA = '" & _CodPais & "' And Ci.KOCI = '" & _CodCiudad & "' And Cm.KOCM = '" & _CodComuna & "'"

        Dim _Row_Localidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Localidad) Then
            _Pais = _Row_Localidad.Item("NOKOPA")
            _Ciudad = _Row_Localidad.Item("NOKOCI")
            _Comuna = _Row_Localidad.Item("NOKOCM")
            Txt_Comuna.Text = _Comuna.Trim & ", " & _Ciudad.Trim
        End If

    End Sub

    Private Function Fx_Habilitar_Objetos(_Habilitar As Boolean)

        Dim _ReadOnly As Boolean

        If Not _Habilitar Then
            _ReadOnly = True
        End If

        If _Habilitar Then

            RemoveHandler Rdb_Chk_Taller_Externo.CheckedChanging, AddressOf Chk_CheckedChanging
            RemoveHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_CheckedChanging
            AddHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_Habilitar_CheckedChanging
            RemoveHandler Chk_Supervisor.CheckedChanging, AddressOf Chk_CheckedChanging
            RemoveHandler Chk_Domicilio.CheckedChanging, AddressOf Chk_CheckedChanging

        Else

            _ReadOnly = True
            AddHandler Rdb_Chk_Taller_Externo.CheckedChanging, AddressOf Chk_CheckedChanging
            AddHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_CheckedChanging
            RemoveHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_Habilitar_CheckedChanging
            AddHandler Chk_Supervisor.CheckedChanging, AddressOf Chk_CheckedChanging
            AddHandler Chk_Domicilio.CheckedChanging, AddressOf Chk_CheckedChanging

        End If

        Rdb_Chk_Taller_Externo.Enabled = Not _Tiene_OT
        Chk_Supervisor.Enabled = Not _Tiene_OT
        Chk_Domicilio.Enabled = Not _Tiene_OT

        Txt_NomFuncionario.ReadOnly = _ReadOnly
        Txt_Direccion.ReadOnly = _ReadOnly
        Txt_Email.ReadOnly = _ReadOnly
        Txt_Informacion.ReadOnly = _ReadOnly
        Txt_Telefono.ReadOnly = _ReadOnly

        'Txt_NomFuncionario.FocusHighlightEnabled = _Habilitar
        'Txt_Direccion.FocusHighlightEnabled = _Habilitar
        'Txt_Email.FocusHighlightEnabled = _Habilitar
        'Txt_Informacion.FocusHighlightEnabled = _Habilitar
        'Txt_Telefono.FocusHighlightEnabled = _Habilitar

        'Txt_NomFuncionario.BackColor = _Color
        'Txt_Direccion.BackColor = _Color
        'Txt_Email.BackColor = _Color
        'Txt_Informacion.BackColor = _Color
        'Txt_Telefono.BackColor = _Color

        Rating_Star.IsEditable = _Habilitar

        Btn_Buscar_Comuna.Enabled = _Habilitar

        If _Accion = Accion.Editar Then
            Btn_Editar.Enabled = _ReadOnly
            Btn_Grabar.Enabled = _Habilitar
            Btn_Eliminar.Enabled = _Habilitar
            Me.ControlBox = _ReadOnly
            Btn_Cancelar.Visible = _Habilitar
        End If

        If Rdb_Chk_Taller_Externo.Checked Then
            Chk_Domicilio.Enabled = False
            Chk_Supervisor.Enabled = False
        Else
            Chk_Domicilio.Enabled = True
            Chk_Supervisor.Enabled = True
        End If

        Me.Refresh()

    End Function


    Private Sub Chk_CheckedChanging(sender As System.Object,
                                                   e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        e.Cancel = True
    End Sub

    Private Sub Chk_Habilitar_CheckedChanging(sender As System.Object,
                                                   e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        If Not Fx_Tiene_Permiso(Me, "Stec0009") Then
            e.Cancel = True
        End If
    End Sub

#Region "PROCEDIMIENTOS"

    Function Fx_Nvo_CodFuncionario() As String

        Dim _NvoNro_CodFuncionario As String


        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(CodFuncionario) As CodFuncionario " &
                                          "From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller") ' cn1, "MAX(Nro_SOC)", _Global_BaseBk & "ZW_SOC_Encabezado", "Stand_By = " & Stby)

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("CodFuncionario"), "")

            If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
                _Ult_Nro_OT = 1
            Else
                _Ult_Nro_OT += 1
            End If
            _NvoNro_CodFuncionario = numero_(Val(_Ult_Nro_OT), 3)
        Else
            _NvoNro_CodFuncionario = numero_(1, 3)
        End If

        Return _NvoNro_CodFuncionario

    End Function

#End Region


    Private Sub Btn_Eliminar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Eliminar.Click

        If Fx_Tiene_Permiso(Me, "Stec0010") Then

            If _Tiene_OT Then
                MessageBoxEx.Show(Me, "Este registro no se puede eliminar, ya que esta presente en algunas Ordenes de servicio" & vbCrLf &
                                  "Puede dejar el registro deshabilitado si no quiere que se utilice mas",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If MessageBoxEx.Show(Me, "¿Está seguro de eliminar este registro?", "Eliminar registro",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & Space(1) &
                                   "Where CodFuncionario = '" & _CodFuncionario & "'"

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                        _Eliminado = True
                        Me.Close()
                    End If

                End If
            End If
        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Editar.Click

        If Fx_Tiene_Permiso(Me, "Stec0008") Then
            Fx_Habilitar_Objetos(True)
            Beep()
            ToastNotification.Show(Me, "AHORA ES POSIBLE ACTUALIZAR EL DOCUMENTO",
                                   Btn_Editar.Image,
                                   1 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click

        _CodFuncionario = _Row_Tecnico.Item("CodFuncionario")

        Txt_NomFuncionario.Text = _Row_Tecnico.Item("NomFuncionario")
        Txt_Direccion.Text = _Row_Tecnico.Item("Direccion")
        Txt_Email.Text = _Row_Tecnico.Item("Email")
        Txt_Informacion.Text = _Row_Tecnico.Item("Informacion")
        Txt_Telefono.Text = _Row_Tecnico.Item("Telefono")

        Rating_Star.Rating = _Row_Tecnico.Item("Star")

        CodPais = _Row_Tecnico.Item("Pais")
        CodCiudad = _Row_Tecnico.Item("Ciudad")
        CodComuna = _Row_Tecnico.Item("Comuna")

        Sb_Llenar_Ciudad_Comuna()

        Rdb_Chk_Taller_Externo.Checked = _Row_Tecnico.Item("Chk_Taller_Externo")
        Chk_Habilitado.Checked = _Row_Tecnico.Item("Chk_Habilitado")
        Chk_Supervisor.Checked = _Row_Tecnico.Item("Chk_Supervisor")
        Chk_Domicilio.Checked = _Row_Tecnico.Item("Chk_Domicilio")

        Btn_Editar.Visible = True
        Btn_Eliminar.Visible = True
        Fx_Habilitar_Objetos(False)

        Beep()
        ToastNotification.Show(Me, "NO SE EFECTURON MODIFICACIONES",
                               Btn_Editar.Image,
                               1 * 1000, eToastGlowColor.Green,
                               eToastPosition.MiddleCenter)

    End Sub

    Private Sub Btn_Direccion_Servicio_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Direccion_Servicio.Click

        If String.IsNullOrEmpty(_CodPais.Trim) Or
            String.IsNullOrEmpty(_CodCiudad.Trim) Or
            String.IsNullOrEmpty(_CodComuna.Trim) Or
            String.IsNullOrEmpty(Txt_Direccion.Text.Trim) Then

            MessageBoxEx.Show(Me, "Falta la dirección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return

        End If

        Sb_Ver_Direccion_En_Mapa(_Pais.Trim, _Ciudad.Trim, _Comuna.Trim, Txt_Direccion.Text.Trim)

    End Sub

    Private Sub Chk_Taller_Externo_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Rdb_Chk_Taller_Externo.Checked Then
            Chk_Domicilio.Enabled = False
            Chk_Supervisor.Enabled = False
        Else
            Chk_Domicilio.Enabled = True
            Chk_Supervisor.Enabled = True
        End If
    End Sub

    Private Sub Btn_Buscar_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Comuna.Click
        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)

        If Not IsNothing(Fm.Row_Localidad) Then

            _CodPais = Fm.Row_Localidad.Item("KOPA")
            _CodCiudad = Fm.Row_Localidad.Item("KOCI")
            _CodComuna = Fm.Row_Localidad.Item("KOCM")

            _Pais = Fm.Row_Localidad.Item("NOKOPA")
            _Ciudad = Fm.Row_Localidad.Item("NOKOCI")
            _Comuna = Fm.Row_Localidad.Item("NOKOCM")

            Txt_Comuna.Text = _Comuna.Trim & ", " & _Ciudad.Trim

        End If

        Txt_Direccion.Focus()

        Fm.Dispose()
    End Sub

    Private Sub Txt_ClaveFuncionario_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_PwTecnico.ButtonCustomClick

        If Txt_PwTecnico.PasswordChar = "*" Then
            Txt_PwTecnico.PasswordChar = ""
        Else
            Txt_PwTecnico.PasswordChar = "*"
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_NomFuncionario.Text) Then
            MessageBoxEx.Show(Me, "Falta el nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NomFuncionario.Focus()
            Return
        End If

        If String.IsNullOrEmpty(CodPais) Or
           String.IsNullOrEmpty(CodCiudad) Or
           String.IsNullOrEmpty(CodComuna) Or
           String.IsNullOrEmpty(Txt_Direccion.Text) Then
            MessageBoxEx.Show(Me, "Falta la dirección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Direccion.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Telefono.Text) Then
            MessageBoxEx.Show(Me, "Falta el teléfono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Telefono.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Email.Text) Then
            MessageBoxEx.Show(Me, "Falta el email", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Email.Focus()
            Return
        End If

        If Not Fx_Validar_Email(Txt_Email.Text) Then
            MessageBoxEx.Show(Me, "Email con formato incorrecto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Email.Focus()
            Return
        End If

        If Not Rdb_EsTecnico.Checked And Not Rdb_EsTaller.Checked And Not Rdb_Chk_Taller_Externo.Checked Then
            MessageBoxEx.Show(Me, "Debe marcar una opción de tipo de taller o técnico", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_PwTecnico.Text) And Rdb_EsTecnico.Checked Then
            MessageBoxEx.Show(Me, "Falta la clave del técnico", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_PwTecnico.Focus()
            Return
        End If

        If String.IsNullOrEmpty(_CodFuncionario) Then
            _CodFuncionario = Fx_Nvo_CodFuncionario()
        End If

        Dim _Chk_Taller_Externo As Integer = Convert.ToInt32(Rdb_Chk_Taller_Externo.Checked)
        Dim _Chk_Habilitado As Integer = Convert.ToInt32(Chk_Habilitado.Checked)
        Dim _Chk_Supervisor As Integer = Convert.ToInt32(Chk_Supervisor.Checked)
        Dim _Chk_Domicilio As Integer = Convert.ToInt32(Chk_Domicilio.Checked)
        Dim _EsTecnico As Integer = Convert.ToInt32(Rdb_EsTecnico.Checked)
        Dim _EsTaller As Integer = Convert.ToInt32(Rdb_EsTaller.Checked)

        If Rdb_Chk_Taller_Externo.Checked Then
            _Chk_Supervisor = 0
            _Chk_Domicilio = 0
        End If

        Dim _Star = Rating_Star.Rating
        Dim _Informacion = Trim(Txt_Informacion.Text)

        For _i = 0 To 31
            _Informacion = Replace(_Informacion, Chr(_i), " ")
        Next

        Consulta_sql = String.Empty

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller", "PwTecnico = '" & Txt_PwTecnico.Text.Trim & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "La clave de usuario ya esta registrada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Accion = Accion.Editar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & Space(1) &
                           "Where CodFuncionario = '" & _CodFuncionario & "'" & vbCrLf & vbCrLf
        End If

        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller (CodFuncionario,NomFuncionario,Direccion," &
                       "Telefono,Email,Pais,Ciudad,Comuna,Star," &
                       "Chk_Taller_Externo,Chk_Habilitado,Chk_Supervisor,Chk_Domicilio,Informacion,EsTecnico,PwTecnico,EsTaller,Empresa,Sucursal) Values " &
                       "('" & _CodFuncionario & "','" & Txt_NomFuncionario.Text.Trim & "','" & Txt_Direccion.Text.Trim &
                       "','" & Txt_Telefono.Text.Trim & "','" & Txt_Email.Text.Trim &
                       "','" & _CodPais & "','" & _CodCiudad & "','" & _CodComuna & "'," & _Star &
                       "," & _Chk_Taller_Externo & "," & _Chk_Habilitado & "," & _Chk_Supervisor & "," & _Chk_Domicilio &
                       ",'" & _Informacion & "'," & _EsTecnico & ",'" & Txt_PwTecnico.Text & "'," & _EsTaller & ",'" & ModEmpresa & "','" & ModSucursal & "')"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            _Grabado = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
End Class
