'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_Crear_Contactos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public _CodEntidad As String
    Public _DatosActualizados As Boolean
    Public _Crear As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Act_Combos()

        AddHandler TxtRut.KeyPress, AddressOf PresionaEnter
        AddHandler TxtRazonSocial.KeyPress, AddressOf PresionaEnter
        AddHandler TxtTelefono.KeyPress, AddressOf PresionaEnter
        AddHandler TxtFax.KeyPress, AddressOf PresionaEnter
        AddHandler TxtEmail.KeyPress, AddressOf PresionaEnter

        _DatosActualizados = False

        If Global_Thema = Enum_Themas.Oscuro Then

            TxtEmail.FocusHighlightEnabled = False
            TxtFax.FocusHighlightEnabled = False
            TxtRazonSocial.FocusHighlightEnabled = False
            TxtRut.FocusHighlightEnabled = False
            TxtTelefono.FocusHighlightEnabled = False
            CmbActividad.FocusHighlightEnabled = False
            CmbCargo.FocusHighlightEnabled = False

        End If

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Sub Sb_Act_Combos()
        caract_combo(CmbActividad)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'ACTIVIDADE' ORDER BY Hijo"
        CmbActividad.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(CmbCargo)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'CARGOS' ORDER BY Hijo"
        CmbCargo.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
    End Sub

    Private Sub BtnxGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxGrabar.Click

        If _Crear Then

            If String.IsNullOrEmpty(Trim(TxtRut.Text)) Then

                Beep()
                ToastNotification.Show(Me, "FALTA RUT (CODIGO) DEL CONTACTO",
                                       My.Resources.button_rounded_red_delete,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                TxtRut.Focus()
                Return
            End If

            Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros("MAEENCON", "KOEN = '" & _CodEntidad & "' AND RUTCONTACT = '" & TxtRut.Text & "'")

            If _Reg Then

                MessageBoxEx.Show(Me, "¡El Rut(código) del contacto ya existe!" & vbCrLf &
                                     "No puede guardar 2 contactos con el mismo código", "Validación",
                                     MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtRut.Focus()
                Return

            End If

            If String.IsNullOrEmpty(Trim(TxtRazonSocial.Text)) Then

                Beep()
                ToastNotification.Show(Me, "FALTA NOMBRE DEL CONTACTO",
                                       My.Resources.button_rounded_red_delete,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                TxtRazonSocial.Focus()
                Return
            End If

            If String.IsNullOrEmpty(Trim(TxtTelefono.Text)) Then

                Beep()
                ToastNotification.Show(Me, "FALTA TELEFONO",
                                       My.Resources.button_rounded_red_delete,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                TxtTelefono.Focus()
                Return
            End If

            'If String.IsNullOrEmpty(Trim(CmbCargo.Text)) Then

            'Beep()
            'ToastNotification.Show(Me, "FALTA CARGO", _
            '                       My.Resources.button_rounded_red_delete, _
            '                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            'CmbCargo.Focus()
            'Return
            'End If

            If String.IsNullOrEmpty(Trim(TxtEmail.Text)) Then

                Beep()
                ToastNotification.Show(Me, "FALTA EMAIL",
                                       My.Resources.button_rounded_red_delete,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                CmbCargo.Focus()
                Return
            End If


        End If

        Consulta_sql = "DELETE MAEENCON WHERE KOEN = '" & _CodEntidad & "' AND RUTCONTACT = '" & TxtRut.Text & "'" & vbCrLf &
                       "INSERT INTO MAEENCON (KOEN,RUTCONTACT,NOKOCON,FONOCON,FAXCON,EMAILCON,AREACON,CARGOCON)" & vbCrLf &
                       "VALUES ('" & _CodEntidad & "','" & TxtRut.Text & "','" & TxtRazonSocial.Text &
                       "','" & TxtTelefono.Text & "','" & TxtFax.Text & "','" & TxtEmail.Text &
                       "','" & CmbActividad.SelectedValue & "','" & CmbCargo.SelectedValue & "')"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            MessageBoxEx.Show(Me, "Contacto guardado correctamente",
                              "Contacto de entidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _DatosActualizados = True
            Me.Close()

        End If

    End Sub


    Public Sub Sb_Llenar_Contacto(ByVal _RutContacto As String)

        Consulta_sql = "Select * From MAEENCON Where KOEN = '" & _CodEntidad &
                       "' AND RUTCONTACT = '" & _RutContacto & "'"
        Dim _TblContacto As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        TxtRut.Text = _TblContacto.Rows(0).Item("RUTCONTACT")
        TxtRazonSocial.Text = _TblContacto.Rows(0).Item("NOKOCON")
        TxtTelefono.Text = _TblContacto.Rows(0).Item("FONOCON")
        TxtFax.Text = _TblContacto.Rows(0).Item("FAXCON")
        TxtEmail.Text = _TblContacto.Rows(0).Item("EMAILCON")
        CmbActividad.SelectedValue = _TblContacto.Rows(0).Item("AREACON")
        CmbCargo.SelectedValue = _TblContacto.Rows(0).Item("CARGOCON")

        TxtRazonSocial.Focus()
        TxtRut.Enabled = False
        BtnEliminarContacto.Enabled = True

    End Sub

    Sub PresionaEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub BtnEliminarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarContacto.Click
        If Fx_Eliminar_Contacto(_CodEntidad, TxtRut.Text) Then
            _DatosActualizados = True
            Me.Close()
        End If
    End Sub

    Public Function Fx_Eliminar_Contacto(ByVal _CodEntidad As String,
                                         ByVal _RutContac As String) As Boolean
        If Fx_Tiene_Permiso(Me, "CfEnt013") Then
            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar este contacto?", "Eliminar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Consulta_sql = "Delete MAEENCON Where KOEN = '" & _CodEntidad & "' AND RUTCONTACT = '" & _RutContac & "'" & vbCrLf &
                               "Update MAEEDO Set RUTCONTACT = ''" & vbCrLf &
                               "Where ENDO = '" & _CodEntidad & "' And RUTCONTACT = '" & _RutContac & "'"
                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    Return True
                End If
            End If
        End If

    End Function


    Private Sub Btn_Cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cargo.Click
        If Fx_Tiene_Permiso(Me, "Tbl00019") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Cargos,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "CARGOS EMPRESARIALES"
            Fm.ShowDialog(Me)
            Sb_Act_Combos()
        End If
    End Sub

    Private Sub Btn_Area_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Area.Click
        If Fx_Tiene_Permiso(Me, "Tbl00014") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Areasactiv,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "AREAS DE ACTIVIDAD"
            Fm.ShowDialog(Me)
            Fm.Dispose()
            Sb_Act_Combos()
        End If
    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Crear_Contactos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _DatosActualizados = False
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Crear_Contactos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
