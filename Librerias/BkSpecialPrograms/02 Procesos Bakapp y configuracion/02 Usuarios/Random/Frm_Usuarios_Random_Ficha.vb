Imports DevComponents.DotNetBar
Imports Microsoft.Office.Interop.Outlook


Public Class Frm_Usuarios_Random_Ficha

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Kofu As String

    Dim _Pais As String
    Dim _Ciudad As String
    Dim _Comuna As String

    Dim _Row_Tabfu As DataRow
    Dim _Row_Usuario As DataRow
    Dim _Tbl_Grupos As DataTable
    'Dim _Tbl_KofuGrupos As DataTable

    Public Property Grabar As Boolean
    Public Property ModoEdicionComoFuncionario As Boolean

    ' Paso a paso:
    ' 1. Crear una clase para almacenar los cambios (nombre del campo, valor anterior, valor nuevo).
    ' 2. Al momento de grabar, comparar los valores actuales del formulario con los valores originales del DataRow.
    ' 3. Guardar en una lista solo los campos que han cambiado.
    ' 4. Usar esa lista para registrar los cambios en el log.

    ' 1. Clase para cambios
    Public Class CambioParametro
        Public Property Campo As String
        Public Property ValorAnterior As Object
        Public Property ValorNuevo As Object
    End Class

    ' 2. Método para comparar y obtener cambios
    Private Function ObtenerCambios() As List(Of CambioParametro)
        Dim cambios As New List(Of CambioParametro)

        If Not IsNothing(_Row_Tabfu) Then
            If _Row_Tabfu.Item("NOKOFU").ToString.Trim <> Txt_Nombre.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "NOKOFU", .ValorAnterior = _Row_Tabfu.Item("NOKOFU"), .ValorNuevo = Txt_Nombre.Text.Trim})
            End If
            If _Row_Tabfu.Item("RTFU").ToString.Trim <> Txt_Rut.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "RTFU", .ValorAnterior = _Row_Tabfu.Item("RTFU"), .ValorNuevo = Txt_Rut.Text.Trim})
            End If
            If _Row_Tabfu.Item("DIFU").ToString.Trim <> Txt_Direccion.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "DIFU", .ValorAnterior = _Row_Tabfu.Item("DIFU"), .ValorNuevo = Txt_Direccion.Text.Trim})
            End If
            If _Row_Tabfu.Item("CIFU").ToString <> _Ciudad Then
                cambios.Add(New CambioParametro With {.Campo = "CIFU", .ValorAnterior = _Row_Tabfu.Item("CIFU"), .ValorNuevo = _Ciudad})
            End If
            If _Row_Tabfu.Item("CMFU").ToString <> _Comuna Then
                cambios.Add(New CambioParametro With {.Campo = "CMFU", .ValorAnterior = _Row_Tabfu.Item("CMFU"), .ValorNuevo = _Comuna})
            End If
            If _Row_Tabfu.Item("MODALIDAD").ToString <> Txt_Modalidad.Text Then
                cambios.Add(New CambioParametro With {.Campo = "MODALIDAD", .ValorAnterior = _Row_Tabfu.Item("MODALIDAD"), .ValorNuevo = Txt_Modalidad.Text})
            End If
            If _Row_Tabfu.Item("EMAIL").ToString.Trim <> Txt_Email.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "EMAIL", .ValorAnterior = _Row_Tabfu.Item("EMAIL"), .ValorNuevo = Txt_Email.Text.Trim})
            End If
            If _Row_Tabfu.Item("EMAILSUP").ToString.Trim <> Txt_EmailSup.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "EMAILSUP", .ValorAnterior = _Row_Tabfu.Item("EMAILSUP"), .ValorNuevo = Txt_EmailSup.Text.Trim})
            End If
            If _Row_Tabfu.Item("CODEXTERN").ToString.Trim <> Txt_Cod_Ext.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "CODEXTERN", .ValorAnterior = _Row_Tabfu.Item("CODEXTERN"), .ValorNuevo = Txt_Cod_Ext.Text.Trim})
            End If
            If _Row_Tabfu.Item("FOFU").ToString.Trim <> Txt_Telefono.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "FOFU", .ValorAnterior = _Row_Tabfu.Item("FOFU"), .ValorNuevo = Txt_Telefono.Text.Trim})
            End If
            If DecryptClaveRD(_Row_Tabfu.Item("PWFU")) <> Txt_Password.Text Then
                cambios.Add(New CambioParametro With {.Campo = "PWFU", .ValorAnterior = DecryptClaveRD(_Row_Tabfu.Item("PWFU")), .ValorNuevo = Txt_Password.Text})
            End If
            If CBool(_Row_Tabfu.Item("INACTIVO")) <> Chk_Inactivo.Checked Then
                cambios.Add(New CambioParametro With {.Campo = "INACTIVO", .ValorAnterior = _Row_Tabfu.Item("INACTIVO"), .ValorNuevo = Chk_Inactivo.Checked})
            End If
            If (_Row_Tabfu.Item("PARAFIRMA").ToString = "N") <> Chk_Parafirma.Checked Then
                cambios.Add(New CambioParametro With {.Campo = "PARAFIRMA", .ValorAnterior = _Row_Tabfu.Item("PARAFIRMA"), .ValorNuevo = If(Chk_Parafirma.Checked, "N", "F")})
            End If
        End If

        If Not IsNothing(_Row_Usuario) Then
            If _Row_Usuario.Item("Kogru_Ventas").ToString.Trim <> Txt_Kogru_Ventas.Text.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "Kogru_Ventas", .ValorAnterior = _Row_Usuario.Item("Kogru_Ventas"), .ValorNuevo = Txt_Kogru_Ventas.Text.Trim})
            End If
            If _Row_Usuario.Item("Kofu_Kogru").ToString.Trim <> Txt_Kofu_Kogru.Tag.ToString.Trim Then
                cambios.Add(New CambioParametro With {.Campo = "Kofu_Kogru", .ValorAnterior = _Row_Usuario.Item("Kofu_Kogru"), .ValorNuevo = Txt_Kofu_Kogru.Tag.ToString.Trim})
            End If
            If _Row_Usuario.Item("PedirConfirmacionModalidad") <> Chk_PedirConfirmacionModalidad.Checked Then
                cambios.Add(New CambioParametro With {.Campo = "PedirConfirmacionModalidad", .ValorAnterior = _Row_Usuario.Item("PedirConfirmacionModalidad"), .ValorNuevo = Chk_PedirConfirmacionModalidad.Checked})
            End If
        End If

        Return cambios
    End Function

    Public Sub New(_Kofu As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Kofu = _Kofu

        Consulta_sql = "Select * From TABFU Where KOFU = '" & _Kofu & "'"
        _Row_Tabfu = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Usuarios Where CodFuncionario = '" & _Kofu & "'"
        _Row_Usuario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Usuarios_Ficha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Txt_Kogru_Ventas.Tag = Nothing

        Txt_Password.PasswordChar = "●"
        Txt_Password.MaxLength = 5
        Txt_Password.ButtonCustom.Visible = True
        Txt_Password.ButtonCustom2.Visible = False

        If Not IsNothing(_Row_Tabfu) Then

            Txt_Codigo.Enabled = False
            Txt_Codigo.Text = _Kofu

            Txt_Nombre.Text = _Row_Tabfu.Item("NOKOFU").ToString.Trim
            Txt_Rut.Text = _Row_Tabfu.Item("RTFU").ToString.Trim
            Txt_Direccion.Text = _Row_Tabfu.Item("DIFU").ToString.Trim
            _Ciudad = _Row_Tabfu.Item("CIFU")
            _Comuna = _Row_Tabfu.Item("CMFU")
            Txt_Modalidad.Text = _Row_Tabfu.Item("MODALIDAD")
            Txt_Email.Text = _Row_Tabfu.Item("EMAIL").ToString.Trim
            Txt_EmailSup.Text = _Row_Tabfu.Item("EMAILSUP").ToString.Trim
            Txt_Cod_Ext.Text = _Row_Tabfu.Item("CODEXTERN").ToString.Trim
            Txt_Telefono.Text = _Row_Tabfu.Item("FOFU").ToString.Trim
            Txt_Password.Text = DecryptClaveRD(_Row_Tabfu.Item("PWFU"))

            _Pais = "CHI"

            Consulta_sql = "Select Pa.KOPA,Pa.NOKOPA,Ci.KOCI,Ci.NOKOCI,Cm.KOCM,Cm.NOKOCM,
                        Rtrim(Ltrim(Pa.NOKOPA))+' - '+Rtrim(Ltrim(Ci.NOKOCI))+' - '+Rtrim(Ltrim(Cm.NOKOCM)) As Localidad	
                        From TABCM Cm 
                        Inner Join TABCI Ci On Ci.KOPA = Cm.KOPA And Ci.KOCI = Cm.KOCI
                        Inner Join TABPA Pa On Pa.KOPA = Cm.KOPA
                        Where Pa.KOPA = '" & _Pais & "' And Ci.KOCI = '" & _Ciudad & "' And Cm.KOCM = '" & _Comuna & "'"

            Dim _Row_Localidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _NPais As String
            Dim _NCiudad As String
            Dim _NComuna As String

            If Not IsNothing(_Row_Localidad) Then
                _NPais = _Row_Localidad.Item("NOKOPA").ToString.Trim
                _NCiudad = _Row_Localidad.Item("NOKOCI").ToString.Trim
                _NComuna = _Row_Localidad.Item("NOKOCM").ToString.Trim
            End If

            Txt_Comuna.Text = _NComuna & ", " & _NCiudad & " - " & _NPais

            Chk_Inactivo.Checked = _Row_Tabfu.Item("INACTIVO")

            If _Row_Tabfu.Item("PARAFIRMA") = "N" Then
                Chk_Parafirma.Checked = True
            End If

            Chk_PedirConfirmacionModalidad.Checked = _Row_Usuario.Item("PedirConfirmacionModalidad")

            Me.ActiveControl = Txt_Nombre

            Dim _Grupos As String = _Row_Usuario.Item("Kogru_Ventas").ToString.Trim
            Dim _KogruList As List(Of String) = _Row_Usuario.Item("Kogru_Ventas").ToString.Split(","c).ToList()

            _Grupos = NuloPorNro(Replace(_Grupos, "''", "'"), "")

            If _KogruList.Count = 1 Then
                If Not String.IsNullOrWhiteSpace(_Grupos) AndAlso Not _Grupos.Contains("'") Then
                    _Grupos = "'" & _Grupos & "'"
                End If
            End If

            If Not String.IsNullOrWhiteSpace(_Grupos) Then

                Consulta_sql = "Select KOGRU As 'Codigo',NOKOGRU As 'Descripcion' From TABFUGE Where KOGRU In (" & _Grupos & ")"
                _Tbl_Grupos = _Sql.Fx_Get_DataTable(Consulta_sql)

                Txt_Kogru_Ventas.Tag = _Tbl_Grupos
                Txt_Kogru_Ventas.Text = _Grupos

            End If

            ''Kofu_Kogru

            Txt_Kofu_Kogru.Tag = _Row_Usuario.Item("Kofu_Kogru").ToString.Trim
            If Not String.IsNullOrEmpty(Txt_Kofu_Kogru.Tag) Then
                Txt_Kofu_Kogru.Text = _Row_Usuario.Item("Kofu_Kogru").ToString.Trim & " - " & _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & Txt_Kofu_Kogru.Tag & "'")
            End If

        Else

            Me.ActiveControl = Txt_Codigo

        End If

        If ModoEdicionComoFuncionario Then

            Txt_Modalidad.Enabled = False
            Txt_EmailSup.Enabled = False
            Txt_Cod_Ext.Enabled = False
            Chk_Parafirma.Enabled = False
            Chk_Inactivo.Enabled = False
            Chk_PedirConfirmacionModalidad.Enabled = False
            Txt_Kogru_Ventas.Enabled = False

            Lbl_Modalidad.Enabled = False
            Lbl_EmailSup.Enabled = False
            lbl_Cod_Ext.Enabled = False
            Lbl_Kogru_Ventas.Enabled = False

        End If

    End Sub
    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Trim(Txt_Nombre.Text)) Then
            MessageBoxEx.Show(Me, "Nombre no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not String.IsNullOrWhiteSpace(Txt_Email.Text) Then
            If Not Fx_Validar_Email(Txt_Email.Text) Then
                MessageBoxEx.Show(Me, "Email incorrecto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Email.Focus()
                Return
            End If
        End If

        If Chk_Inactivo.Checked Then

            If MessageBoxEx.Show(Me, "¡Al inactivar, todos los permisos asignados a este usuario se perderan!" & vbCrLf & vbCrLf &
                                 "¿Confirma dejar al usuario inactivo?", "Inactivar usuario",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                Return
            End If

        End If

        If String.IsNullOrEmpty(Txt_Kogru_Ventas.Text.Trim) AndAlso Fx_Tiene_Permiso("NO00022", Kofu) Then

            Dim _Msg As String = "Este usuario tiene activa la restricción NO00022, que depende de un grupo de vendedores asociado. Como no tiene grupo asignado, la restricción no puede aplicarse correctamente."
            _Msg = Fx_AjustarTexto(_Msg, 80)

            If MessageBoxEx.Show(Me, _Msg & vbCrLf & vbCrLf & "¿Confirma continuar sin grupo de vendedores?", "Validación",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                Return
            End If

        End If

        If IsNothing(_Row_Tabfu) Then

            Kofu = Fx_CrearFuncionario(Txt_Codigo.Text)

            If String.IsNullOrWhiteSpace(_Kofu) Then
                Return
            End If

        End If

        Sb_EditarFuncionario()

    End Sub

    Private Function Fx_CrearFuncionario(_Kofu As String) As String

        Dim Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABFU", "KOFU = '" & _Kofu & "'"))

        If Reg Then
            MessageBoxEx.Show(Me, "El código del usuario ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return ""
        End If

        Consulta_sql = "Insert Into TABFU (KOFU) Values ('" & _Kofu & "')"

        If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Return ""
        End If

        Return _Kofu

    End Function

    Private Sub Sb_CrearFuncionario()

        Dim _Rut As String = Txt_Rut.Text
        Dim _Codigo As String = Txt_Codigo.Text
        Dim _Nombre As String = Txt_Nombre.Text
        Dim _Direccion As String = Txt_Direccion.Text
        Dim _Ciudad As String = Me._Ciudad
        Dim _Comuna As String = Me._Comuna
        Dim _Telefono As String = Txt_Telefono.Text
        Dim _Email As String = Txt_Email.Text
        Dim _EmailSup As String = Txt_EmailSup.Text
        Dim _Modalidad As String = Txt_Modalidad.Text
        Dim _CodigoExt As String = Txt_Cod_Ext.Text
        Dim _Password As String = TraeClaveRD(Txt_Password.Text)

        Dim Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABFU", "KOFU = '" & _Codigo & "'"))

        If Reg Then
            MessageBoxEx.Show(Me, "El código del usuario ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Insert Into TABFU (KOFU,NOKOFU,RTFU,DIFU,CIFU,CMFU,PLANO,MODALIDAD,INACTIVO,PARAFIRMA,EMAIL,EMAILSUP,CODEXTERN,FOFU,PWFU)" & vbCrLf &
                        "Values ('" & _Codigo & "','" & _Nombre & "','" & _Rut & "','" & _Direccion & "','" & _Ciudad & "','" & _Comuna & "'," &
                        "'SINFOTOF','" & _Modalidad & "',0,'F','" & _Email & "','" & _EmailSup & "','" & _CodigoExt & "','" & _Telefono & "','" & _Password & "')"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            _Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Sb_EditarFuncionario()

        Kofu = Txt_Codigo.Text

        Dim _Rut As String = Txt_Rut.Text
        Dim _Nokofu As String = Txt_Nombre.Text.Trim
        Dim _Difu As String = Txt_Direccion.Text.Trim
        Dim _Cifu As String = _Ciudad
        Dim _Cmfu As String = _Comuna
        Dim _Fofu As String = Txt_Telefono.Text
        Dim _Email As String = Txt_Email.Text
        Dim _EmailSup As String = Txt_EmailSup.Text
        Dim _Modalidad As String = Txt_Modalidad.Text
        Dim _Codextern As String = Txt_Cod_Ext.Text
        Dim _Pwfu As String = TraeClaveRD(Txt_Password.Text)

        Dim _Parafirma = String.Empty

        If Chk_Parafirma.Checked Then
            _Parafirma = "N"
        Else
            _Parafirma = "F"
        End If

        Consulta_sql = "Update TABFU Set " & vbCrLf &
                       "NOKOFU = '" & _Nokofu & "'" &
                       ",RTFU = '" & _Rut & "'" &
                       ",DIFU = '" & _Difu & "'" &
                       ",CIFU = '" & _Cifu & "'" &
                       ",CMFU = '" & _Cmfu & "'" &
                       ",PLANO = 'SINFOTOF'" &
                       ",MODALIDAD = '" & _Modalidad & "'" &
                       ",INACTIVO = " & Convert.ToInt32(Chk_Inactivo.Checked) &
                       ",PARAFIRMA = '" & _Parafirma & "'" &
                       ",EMAIL = '" & _Email & "'" &
                       ",EMAILSUP = '" & _EmailSup & "'" &
                       ",CODEXTERN = '" & _Codextern & "'" &
                       ",FOFU = '" & _Fofu & "'" &
                       ",PWFU = '" & _Pwfu & "'" & vbCrLf &
                       "Where KOFU='" & _Kofu & "'" & vbCrLf

        If Chk_Inactivo.Checked Then
            Consulta_sql += "Delete MAEUS Where KOUS='" & _Kofu & "'" & vbCrLf &
                            "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodUsuario = '" & _Kofu & "'" & vbCrLf
        End If

        Dim _Kogru_Ventas As String = String.Empty

        _Kogru_Ventas = Replace(Txt_Kogru_Ventas.Text, "'", "''")

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_Usuarios Set " &
                        "Kogru_Ventas = '" & _Kogru_Ventas & "'" &
                        ",Kofu_Kogru = '" & Txt_Kofu_Kogru.Tag & "'" &
                        ",PedirConfirmacionModalidad = " & Convert.ToInt32(Chk_PedirConfirmacionModalidad.Checked) &
                        vbCrLf & "Where CodFuncionario = '" & _Kofu & "'"

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim listaCambios As List(Of CambioParametro) = ObtenerCambios()

        If listaCambios.Count And Not ModoEdicionComoFuncionario Then
            Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "", 0,
                               "EditFuncionario", "Bajo la clave de Administrador se edita perfil de: " & Kofu, "", "", "", "", False, "", False, 0, "")
        End If

        ' Aquí puedes guardar en el log solo los cambios de listaCambios
        ' Ejemplo simple de log (puedes adaptar a tu sistema de log):
        For Each cambio In listaCambios
            ' Guardar en log: cambio.Campo, cambio.ValorAnterior, cambio.ValorNuevo
            Dim _Accion As String = "Campo: " & cambio.Campo & ", Valor Anterior : """ & cambio.ValorAnterior & """, Valor Nuevo: """ & cambio.ValorNuevo & ""
            Fx_Add_Log_Gestion(Kofu, Mod_Modalidad, "", 0, "EditFuncionario", _Accion, "", "", "", "", False, FUNCIONARIO, False, 0, "")
        Next

        Grabar = True
        Me.Close()

    End Sub


    Private Sub Frm_Usuarios_Bk_Ficha_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Buscar_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Comuna.Click

        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)

        If Not IsNothing(Fm.Row_Localidad) Then

            _Pais = Fm.Row_Localidad.Item("KOPA")
            _Ciudad = Fm.Row_Localidad.Item("KOCI")
            _Comuna = Fm.Row_Localidad.Item("KOCM")

            Dim _NPais = Fm.Row_Localidad.Item("NOKOPA")
            Dim _NCiudad = Fm.Row_Localidad.Item("NOKOCI")
            Dim _NComuna = Fm.Row_Localidad.Item("NOKOCM")

            Txt_Comuna.Text = _NComuna.Trim & ", " & _NCiudad.Trim & " - " & _NPais

        End If

        Fm.Dispose()

    End Sub

    Private Sub Txt_Modalidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Modalidad.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        Dim _Sql = "And MODALIDAD <> '  '" & vbCrLf &
                   "--And MODALIDAD In (Select SUBSTRING(KOOP,4,5) As Modalidad From MAEUS Where KOUS = '" & Txt_Codigo.Text & "' And KOOP Like 'MO-%')"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And EMPRESA = '" & Mod_Empresa & "' " & _Sql,
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Modalidad.Tag = _Codigo
            Txt_Modalidad.Text = _Descripcion

        End If

    End Sub

    Private Sub Txt_Kogru_Ventas_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Kogru_Ventas.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Sql_Filtro_Condicion_Extra As String = String.Empty

        _Filtrar.Tabla = "TABFUGE"
        _Filtrar.Campo = "KOGRU"
        _Filtrar.Descripcion = "NOKOGRU"

        If _Filtrar.Fx_Filtrar(_Tbl_Grupos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra, False, False, False, True) Then

            _Tbl_Grupos = _Filtrar.Pro_Tbl_Filtro

            Dim _Grupos As String = String.Join(",", _Tbl_Grupos.AsEnumerable().[Select](Function(row) "'" & row.Field(Of String)("Codigo").ToString.Trim & "'"))

            Txt_Kogru_Ventas.Tag = _Tbl_Grupos
            Txt_Kogru_Ventas.Text = _Grupos

        End If

    End Sub

    Private Sub Txt_Kogru_Ventas_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Kogru_Ventas.ButtonCustom2Click
        Txt_Kogru_Ventas.Text = String.Empty
        Txt_Kogru_Ventas.Tag = Nothing
    End Sub

    Private Sub Txt_Kofu_Kogru_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Kofu_Kogru.ButtonCustomClick

        If String.IsNullOrEmpty(Txt_Kogru_Ventas.Text.Trim) Then
            MessageBoxEx.Show(Me, "No tiene grupo de vendedores asociados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Sql_Filtro_Condicion_Extra As String = "And KOFU <> '" & Kofu & "'"

        '_Filtrar.Tabla = "TABFUGE"
        '_Filtrar.Campo = "KOGRU"
        '_Filtrar.Descripcion = "NOKOGRU"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               False, False, True, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)
            Txt_Kofu_Kogru.Tag = _Row.Item("Codigo").ToString.Trim
            Txt_Kofu_Kogru.Text = _Row.Item("Codigo").ToString.Trim & " - " & _Row.Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Txt_Kofu_Kogru_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Kofu_Kogru.ButtonCustom2Click
        Txt_Kofu_Kogru.Tag = String.Empty
        Txt_Kofu_Kogru.Text = String.Empty
    End Sub

    Private Sub Txt_Password_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Password.ButtonCustomClick
        Txt_Password.PasswordChar = ""
        Txt_Password.ButtonCustom.Visible = False
        Txt_Password.ButtonCustom2.Visible = True
    End Sub

    Private Sub Txt_Password_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Password.ButtonCustom2Click
        Txt_Password.PasswordChar = "●"
        Txt_Password.ButtonCustom.Visible = True
        Txt_Password.ButtonCustom2.Visible = False
    End Sub
End Class
