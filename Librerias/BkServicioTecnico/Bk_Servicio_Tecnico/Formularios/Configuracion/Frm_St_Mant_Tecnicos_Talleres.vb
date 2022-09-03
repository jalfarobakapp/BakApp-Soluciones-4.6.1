Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms

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

    Public Sub New(ByVal Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion

    End Sub

    Private Sub Frm_St_Mant_Tecnicos_Talleres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Cargar_Pais("")

        AddHandler Cmb_Pais.SelectedIndexChanged, AddressOf Sb_Cmb_Pais_SelectedIndexChanged
        AddHandler Cmb_Ciudad.SelectedIndexChanged, AddressOf Sb_Cmb_Ciudad_SelectedIndexChanged
        AddHandler Btn_Grabar.Click, AddressOf Sb_Grabar_Nuevo_Tecnico_o_Taller

        AddHandler Chk_Taller_Externo.CheckedChanged, AddressOf Chk_Taller_Externo_CheckedChanged

        Txt_Email.CharacterCasing = CharacterCasing.Lower

        If _Accion = Accion.Nuevo Then

            'Chk_Habilitado.Checked = True
            Fx_Habilitar_Objetos(True)

        ElseIf _Accion = Accion.Editar Then

            _CodFuncionario = _Row_Tecnico.Item("CodFuncionario")

            Txt_NomFuncionario.Text = _Row_Tecnico.Item("NomFuncionario")
            Txt_Direccion.Text = _Row_Tecnico.Item("Direccion")
            Txt_Email.Text = _Row_Tecnico.Item("Email")
            Txt_Informacion.Text = _Row_Tecnico.Item("Informacion")
            Txt_Telefono.Text = _Row_Tecnico.Item("Telefono")

            Rating_Star.Rating = _Row_Tecnico.Item("Star")

            Cmb_Pais.SelectedValue = _Row_Tecnico.Item("Pais")
            Cmb_Ciudad.SelectedValue = _Row_Tecnico.Item("Ciudad")
            Cmb_Comuna.SelectedValue = _Row_Tecnico.Item("Comuna")

            Chk_Taller_Externo.Checked = _Row_Tecnico.Item("Chk_Taller_Externo")
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


    Private Function Fx_Habilitar_Objetos(ByVal _Habilitar As Boolean)

        Dim _ReadOnly As Boolean
        Dim _Color As Color

        If Not _Habilitar Then
            _ReadOnly = True
        End If


        If _Habilitar Then

            RemoveHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_CheckedChanging
            RemoveHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_CheckedChanging
            AddHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_Habilitar_CheckedChanging
            RemoveHandler Chk_Supervisor.CheckedChanging, AddressOf Chk_CheckedChanging
            RemoveHandler Chk_Domicilio.CheckedChanging, AddressOf Chk_CheckedChanging

            _Color = Color.White
        Else

            _ReadOnly = True
            AddHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_CheckedChanging
            AddHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_CheckedChanging
            RemoveHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_Habilitar_CheckedChanging
            AddHandler Chk_Supervisor.CheckedChanging, AddressOf Chk_CheckedChanging
            AddHandler Chk_Domicilio.CheckedChanging, AddressOf Chk_CheckedChanging
            _Color = Color.LightGray

        End If

        If _Tiene_OT Then
            Chk_Taller_Externo.Enabled = False
            Chk_Supervisor.Enabled = False
            Chk_Domicilio.Enabled = False
        Else
            Chk_Taller_Externo.Enabled = True
            Chk_Supervisor.Enabled = True
            Chk_Domicilio.Enabled = True
        End If


        Txt_NomFuncionario.ReadOnly = _ReadOnly
        Txt_Direccion.ReadOnly = _ReadOnly
        Txt_Email.ReadOnly = _ReadOnly
        Txt_Informacion.ReadOnly = _ReadOnly
        Txt_Telefono.ReadOnly = _ReadOnly

        Txt_NomFuncionario.FocusHighlightEnabled = _Habilitar
        Txt_Direccion.FocusHighlightEnabled = _Habilitar
        Txt_Email.FocusHighlightEnabled = _Habilitar
        Txt_Informacion.FocusHighlightEnabled = _Habilitar
        Txt_Telefono.FocusHighlightEnabled = _Habilitar

        Txt_NomFuncionario.BackColor = _Color
        Txt_Direccion.BackColor = _Color
        Txt_Email.BackColor = _Color
        Txt_Informacion.BackColor = _Color
        Txt_Telefono.BackColor = _Color

        Rating_Star.IsEditable = _Habilitar

        Cmb_Pais.Enabled = _Habilitar
        Cmb_Ciudad.Enabled = _Habilitar
        Cmb_Comuna.Enabled = _Habilitar

        If _Accion = Accion.Editar Then
            Btn_Editar.Visible = _ReadOnly
            Btn_Grabar.Visible = _Habilitar
            Btn_Eliminar.Visible = _Habilitar
            Btn_Salir.Visible = _ReadOnly
            Btn_Cancelar.Visible = _Habilitar
        End If

        If Chk_Taller_Externo.Checked Then
            Chk_Domicilio.Enabled = False
            Chk_Supervisor.Enabled = False
        Else
            Chk_Domicilio.Enabled = True
            Chk_Supervisor.Enabled = True
        End If

        Me.Refresh()

    End Function


    Private Sub Chk_CheckedChanging(ByVal sender As System.Object, _
                                                   ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        e.Cancel = True
    End Sub

    Private Sub Chk_Habilitar_CheckedChanging(ByVal sender As System.Object, _
                                                   ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        If Not TienePermiso("Stec0009") Then
            e.Cancel = True
        End If
    End Sub

#Region "PROCEDIMIENTOS"

    Sub Sb_Grabar_Nuevo_Tecnico_o_Taller()

        If String.IsNullOrEmpty(Txt_NomFuncionario.Text) Then
            Beep()
            ToastNotification.Show(Me, "NOMBRE DEL TALLER / TECNICO", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Txt_NomFuncionario.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Cmb_Pais.Text) Or _
           String.IsNullOrEmpty(Cmb_Ciudad.Text) Or _
           String.IsNullOrEmpty(Cmb_Comuna.Text) Or _
           String.IsNullOrEmpty(Txt_Direccion.Text) Then

            Beep()
            ToastNotification.Show(Me, "FALTA DIRECCION" & vbCrLf & _
                                   "Revise: Pais, Ciudad, Comuna y Dirección", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Txt_Direccion.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Telefono.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA TELEFONO", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Txt_Telefono.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Email.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA EMAIL", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Txt_Email.Focus()
            Return
        End If

        If Not Fx_Validar_Email(Txt_Email.Text) Then
            Beep()
            ToastNotification.Show(Me, "VALIDACION DE EMAIL" & vbCrLf & _
                                   "Formato Ej: micorreo@correo.com", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Txt_Email.Focus()
            Return
        End If

        If String.IsNullOrEmpty(_CodFuncionario) Then
            _CodFuncionario = Fx_Nvo_CodFuncionario()
        End If

        Dim _Pais = Cmb_Pais.SelectedValue
        Dim _Ciudad = Cmb_Ciudad.SelectedValue
        Dim _Comuna = Cmb_Comuna.SelectedValue

        Dim _Chk_Taller_Externo As Integer = CInt(Chk_Taller_Externo.Checked) * -1
        Dim _Chk_Habilitado As Integer = CInt(Chk_Habilitado.Checked) * -1
        Dim _Chk_Supervisor As Integer = CInt(Chk_Supervisor.Checked) * -1
        Dim _Chk_Domicilio As Integer = CInt(Chk_Domicilio.Checked) * -1

        If Chk_Taller_Externo.Checked Then
            _Chk_Supervisor = 0
            _Chk_Domicilio = 0
        End If

        Dim _Star = Rating_Star.Rating

        Dim _Informacion = Trim(Txt_Informacion.Text)
        For _i = 0 To 31
            _Informacion = Replace(_Informacion, Chr(_i), " ")
        Next

        Consulta_sql = String.Empty

        If _Accion = Accion.Editar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & Space(1) & _
                           "Where CodFuncionario = '" & _CodFuncionario & "'" & vbCrLf & vbCrLf
        End If

        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller (CodFuncionario,NomFuncionario,Direccion," & _
                       "Telefono,Email,Pais,Ciudad,Comuna,Star," & _
                       "Chk_Taller_Externo,Chk_Habilitado,Chk_Supervisor,Chk_Domicilio,Informacion) Values " & _
                       "('" & _CodFuncionario & "','" & Trim(Txt_NomFuncionario.Text) & "','" & Trim(Txt_Direccion.Text) & _
                       "','" & Txt_Telefono.Text & "','" & Txt_Email.Text & _
                       "','" & _Pais & "','" & _Ciudad & "','" & _Comuna & "'," & _Star & _
                       "," & _Chk_Taller_Externo & "," & _Chk_Habilitado & "," & _Chk_Supervisor & "," & _Chk_Domicilio & _
                       ",'" & _Informacion & "')"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            _Grabado = True
            Me.Close()
        End If

    End Sub

    Function Fx_Nvo_CodFuncionario() As String

        Dim _NvoNro_CodFuncionario As String


        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(CodFuncionario) As CodFuncionario " & _
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

#Region "PROCEDIMIENTOS PAIS, CIUDAD Y COMUNA"

    Private Sub Sb_Cmb_Pais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Pais = Cmb_Pais.SelectedValue

        Cmb_Ciudad.DataSource = Nothing
        Cmb_Comuna.DataSource = Nothing

        Sb_Cargar_Ciudades(_Pais, "")

    End Sub

    Private Sub Sb_Cmb_Ciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Pais = Cmb_Pais.SelectedValue
        Dim _Ciudad = Cmb_Ciudad.SelectedValue

        Cmb_Comuna.DataSource = Nothing

        Sb_Cargar_Comunas(_Pais, _Ciudad, "")

    End Sub

    Sub Sb_Cargar_Pais(ByVal _Pais As String)

        caract_combo(Cmb_Pais)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOPA AS Padre,NOKOPA AS Hijo FROM TABPA ORDER BY Padre" ' WHERE SEMILLA = " & Actividad
        Cmb_Pais.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Pais.SelectedValue = _Pais

    End Sub

    Sub Sb_Cargar_Ciudades(ByVal _Pais As String, ByVal _Ciudad As String)

        caract_combo(Cmb_Ciudad)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOCI AS Padre,' '+RTRIM(LTRIM(KOCI))+' -'+NOKOCI AS Hijo FROM TABCI WHERE KOPA = '" & _Pais & "'"
        Cmb_Ciudad.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Ciudad.SelectedValue = _Ciudad

    End Sub

    Sub Sb_Cargar_Comunas(ByVal _Pais As String, ByVal _Ciudad As String, ByVal _Comuna As String)

        caract_combo(Cmb_Comuna)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOCM AS Padre, NOKOCM AS Hijo FROM TABCM WHERE KOPA = '" & _Pais & "' AND KOCI = '" & _Ciudad & "'"
        Cmb_Comuna.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Comuna.SelectedValue = _Comuna

    End Sub

#End Region

#Region "PROPIEDADES"

    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabado
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property Pro_Eliminado() As Boolean
        Get
            Return _Eliminado
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property Pro_Row_Tecnico() As DataRow
        Get
            Return _Row_Tecnico
        End Get
        Set(ByVal value As DataRow)
            _Row_Tecnico = value
        End Set
    End Property

#End Region

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        If TienePermiso("Stec0010") Then

            If _Tiene_OT Then
                MessageBoxEx.Show(Me, "Este registro no se puede eliminar, ya que este presente en algunas Ordenes de trabajo" & vbCrLf & _
                                  "Puede dejar el registro deshabilitado si no quiere que se utilice mas", _
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If MessageBoxEx.Show(Me, "¿Está seguro de eliminar este registro?", "Eliminar registro", _
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & Space(1) & _
                                   "Where CodFuncionario = '" & _CodFuncionario & "'"

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                        _Eliminado = True
                        Me.Close()
                    End If

                End If
            End If
        End If

    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click

        If TienePermiso("Stec0008") Then
            Fx_Habilitar_Objetos(True)
            Beep()
            ToastNotification.Show(Me, "AHORA ES POSIBLE ACTUALIZAR EL DOCUMENTO", _
                                   Btn_Editar.Image, _
                                   1 * 1000, eToastGlowColor.Green, _
                                   eToastPosition.MiddleCenter)
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _CodFuncionario = _Row_Tecnico.Item("CodFuncionario")

        Txt_NomFuncionario.Text = _Row_Tecnico.Item("NomFuncionario")
        Txt_Direccion.Text = _Row_Tecnico.Item("Direccion")
        Txt_Email.Text = _Row_Tecnico.Item("Email")
        Txt_Informacion.Text = _Row_Tecnico.Item("Informacion")
        Txt_Telefono.Text = _Row_Tecnico.Item("Telefono")

        Rating_Star.Rating = _Row_Tecnico.Item("Star")

        Cmb_Pais.SelectedValue = _Row_Tecnico.Item("Pais")
        Cmb_Ciudad.SelectedValue = _Row_Tecnico.Item("Ciudad")
        Cmb_Comuna.SelectedValue = _Row_Tecnico.Item("Comuna")

        Chk_Taller_Externo.Checked = _Row_Tecnico.Item("Chk_Taller_Externo")
        Chk_Habilitado.Checked = _Row_Tecnico.Item("Chk_Habilitado")
        Chk_Supervisor.Checked = _Row_Tecnico.Item("Chk_Supervisor")
        Chk_Domicilio.Checked = _Row_Tecnico.Item("Chk_Domicilio")

        Btn_Editar.Visible = True
        Btn_Eliminar.Visible = True
        Fx_Habilitar_Objetos(False)

        Beep()
        ToastNotification.Show(Me, "NO SE EFECTURON MODIFICACIONES", _
                               Btn_Editar.Image, _
                               1 * 1000, eToastGlowColor.Green, _
                               eToastPosition.MiddleCenter)

    End Sub

    Private Sub Btn_Direccion_Servicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Direccion_Servicio.Click

        If String.IsNullOrEmpty(Cmb_Pais.Text) Or _
           String.IsNullOrEmpty(Cmb_Ciudad.Text) Or _
           String.IsNullOrEmpty(Cmb_Comuna.Text) Or _
           String.IsNullOrEmpty(Txt_Direccion.Text) Then

            Beep()
            ToastNotification.Show(Me, "FALTA DIRECCION" & vbCrLf & _
                                   "Revise: Pais, Ciudad, Comuna y Dirección", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Txt_Direccion.Focus()

        Else
            Dim Fm As New Frm_Mapas("", "", "", Txt_Direccion.Text)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Chk_Taller_Externo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Chk_Taller_Externo.Checked Then
            Chk_Domicilio.Enabled = False
            Chk_Supervisor.Enabled = False
        Else
            Chk_Domicilio.Enabled = True
            Chk_Supervisor.Enabled = True
        End If
    End Sub

   
End Class