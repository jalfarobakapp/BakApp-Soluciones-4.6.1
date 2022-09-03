'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_Choferes_Empresa

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowChofer As DataRow
    Dim _CodChofer As String

    Dim _Nuevo_Chofer As Boolean

    Public ReadOnly Property Pro_Nuevo_Chofer() As Boolean
        Get
            Return _Nuevo_Chofer
        End Get
    End Property

    Public Property Pro_RowChofer() As DataRow
        Get
            Return _RowChofer
        End Get
        Set(ByVal value As DataRow)
            _RowChofer = value
        End Set
    End Property

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum


    Public Sub New(ByVal Accion_ As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion_
    End Sub

    Private Sub Frm_Choferes_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Cargar_Pais("")
        Sb_Llenar_Combo_Color_Vehiculo("")

        AddHandler Cmb_Pais.SelectedIndexChanged, AddressOf Sb_Cmb_Pais_SelectedIndexChanged
        AddHandler Cmb_Ciudad.SelectedIndexChanged, AddressOf Sb_Cmb_Ciudad_SelectedIndexChanged


        If _Accion = Accion.Editar Then

            Sb_Editar_Chofer()
            Sb_Botones_Habilitar_Deshabilitar(False)

            Btn_Cancelar.Visible = True
            Btn_Editar.Visible = True
            Btn_Eliminar.Visible = True
            Me.Text = "EDITAR CHOFER"

        Else
            Me.ActiveControl = Txt_NomChofer
            Me.Text = "CREAR CHOFER"
        End If

        AddHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_Habilitado_CheckedChanging

    End Sub

    Sub Sb_Botones_Habilitar_Deshabilitar(ByVal _Editar As Boolean)

        If _Editar Then
            Btn_Editar.Enabled = False
        Else
            Btn_Editar.Enabled = True
        End If

        Grupo_Chofer.Enabled = _Editar
        Btn_Grabar.Enabled = _Editar
        Btn_Eliminar.Enabled = _Editar
        Btn_Cancelar.Enabled = _Editar

    End Sub

    Sub Sb_Editar_Chofer()

        _CodChofer = _RowChofer.Item("CodChofer")
        Txt_NomChofer.Text = _RowChofer.Item("NomChofer")
        Txt_Direccion.Text = _RowChofer.Item("Direccion")
        Txt_Telefono.Text = _RowChofer.Item("Telefono")
        Txt_Email.Text = _RowChofer.Item("Email")

        Cmb_Pais.SelectedValue = _RowChofer.Item("Pais")
        Cmb_Ciudad.SelectedValue = _RowChofer.Item("Ciudad")
        Cmb_Comuna.SelectedValue = _RowChofer.Item("Comuna")

        Cmb_Licencia.SelectedValue = _RowChofer.Item("Licencia")
        Chk_Habilitado.Checked = _RowChofer.Item("Habilitado")

    End Sub


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
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCM AS Padre, NOKOCM AS Hijo FROM TABCM WHERE KOPA = '" & _Pais & "' AND KOCI = '" & _Ciudad & "'"
        Cmb_Comuna.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Comuna.SelectedValue = _Comuna

    End Sub

#End Region

    Function Fx_Nvo_CodChofer() As String

        Dim _NvoNro_CodFuncionario As String

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(CodChofer) As CodChofer " & _
                                          "From " & _Global_BaseBk & "Zw_TblChoferes_Empresa") ' cn1, "MAX(Nro_SOC)", _Global_BaseBk & "ZW_SOC_Encabezado", "Stand_By = " & Stby)

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("CodChofer"), "")

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

    Sub Sb_Llenar_Combo_Color_Vehiculo(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "WHERE Tabla = 'LICENCIA_COND'" & vbCrLf & _
                       "Order by Padre"
        Dim _TblLicencia As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Licencia)
        Cmb_Licencia.DataSource = _TblLicencia
        Cmb_Licencia.SelectedValue = _Codigo

    End Sub

    Private Sub Btn_Tipo_Licencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tipo_Licencia.Click
        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Licencia_Conducir, _
                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla tipos de licencia de conducir"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Combo_Color_Vehiculo(Cmb_Licencia.SelectedValue)
    End Sub

    Function Fx_Revisa_Dato(ByVal _Txt As Object, ByVal _Mensaje As String) As Boolean

        Dim _Msj As String = UCase("Falta " & _Mensaje)

        If String.IsNullOrEmpty(Trim(_Txt.Text)) Then
            Beep()
            ToastNotification.Show(Me, _Msj, _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            _Txt.Focus()
            Return False
        End If

        Return True

    End Function

    Function Fx_Grabar() As Boolean

        If Not Fx_Revisa_Dato(Txt_NomChofer, "NOMBRE DEL CHOFER") Then Return False
        If Not Fx_Revisa_Dato(Txt_Telefono, "TELEFONO DEL CHOFER") Then Return False
        If Not Fx_Revisa_Dato(Txt_Email, "EMAIL DEL CHOFER") Then Return False
        If Not Fx_Revisa_Dato(Txt_Direccion, "DIRECCION DEL CHOFER") Then Return False

        If Not Fx_Revisa_Dato(Cmb_Pais, "PAIS") Then Return False
        If Not Fx_Revisa_Dato(Cmb_Ciudad, "CIUDAD") Then Return False
        If Not Fx_Revisa_Dato(Cmb_Comuna, "COMUNA") Then Return False

        If Not Fx_Revisa_Dato(Cmb_Licencia, "LICENCIA") Then Return False

        If _Accion = Accion.Nuevo Then
            _CodChofer = Fx_Nvo_CodChofer()
        End If
        
        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TblChoferes_Empresa " & _
                       "(CodChofer,NomChofer,Direccion,Telefono,Email,Pais,Ciudad,Comuna,Informacion,Licencia,Habilitado) Values " & _
                       "('" & _CodChofer & "','" & Txt_NomChofer.Text & "','" & Txt_Direccion.Text & "','" & Txt_Telefono.Text & _
                       "','" & Txt_Email.Text & "','" & Cmb_Pais.SelectedValue & "','" & Cmb_Ciudad.SelectedValue & _
                       "','" & Cmb_Comuna.SelectedValue & "','','" & Cmb_Licencia.SelectedValue & _
                       "'," & CInt(Chk_Habilitado.Checked) * -1 & ")"

        If _Accion = Accion.Editar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblChoferes_Empresa Where CodChofer = '" & _CodChofer & "'" & vbCrLf & vbCrLf & _
                           Consulta_sql

        End If

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


    End Function

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If Fx_Grabar() Then

            If _Accion = Accion.Nuevo Then
                _Nuevo_Chofer = True
                Me.Close()
            Else
                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", _
                                       Btn_Grabar.Image, _
                                       1 * 1000, eToastGlowColor.Green, _
                                       eToastPosition.MiddleCenter)
                Sb_Botones_Habilitar_Deshabilitar(False)
            End If

        End If

    End Sub

    Private Sub Frm_Choferes_Empresa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Fx_Tiene_Permiso(Me, "Crv0008") Then
            Sb_Botones_Habilitar_Deshabilitar(True)
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        Dim _Grabar As Boolean

        Consulta_sql = "Select Nro_CRV From " & _Global_BaseBk & "Zw_CRV_Viajes Where CodChofer = '" & _CodChofer & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            MessageBoxEx.Show(Me, "Este registro no puede ser eliminado, ya que tiene gestión en R.C.V." & vbCrLf & _
                              "Se recomienda desahbilitar el chofer", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            If MessageBoxEx.Show(Me, "¿Está seguro de eliminar este chofer?", "Eliminar chofer", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblChoferes_Empresa Where CodChofer = '" & _CodChofer & "'"

                _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            End If

            If _Grabar Then
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Sb_Botones_Habilitar_Deshabilitar(False)
    End Sub

    Private Sub Chk_Habilitado_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        If Not Fx_Tiene_Permiso(Me, "Crv0011") Then
            e.Cancel = True
        End If
    End Sub

End Class