Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Vehiculos_Empresa

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowVehiculo As DataRow

    Dim _Nuevo_Vehiculo As Boolean
    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum


    Dim _TblMarca_Vehiculo, _TblModelo_Vehiculo, _TblTipo_Vehiculo, _TblColo_Vehiculo, _TblChofer As DataTable

    Public Sub New(ByVal Accion_ As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Accion = Accion_

    End Sub

    Public ReadOnly Property Pro_Nuevo_Vehiculo() As Boolean
        Get
            Return _Nuevo_Vehiculo
        End Get
    End Property

    Public Property Pro_RowVehiculo() As DataRow
        Get
            Return _RowVehiculo
        End Get
        Set(ByVal value As DataRow)
            _RowVehiculo = value
        End Set
    End Property

    Private Sub Frm_Vehiculos_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Llenar_Combo_Tipo_Vehiculo("")
        Sb_Llenar_Combo_Marca_Vehiculo("")
        Sb_Llenar_Combo_Modelo_Vehiculo("")
        Sb_Llenar_Combo_Color_Vehiculo("")
        Sb_Llenar_Combo_Chofer("")


        AddHandler Cmb_Marca.SelectedIndexChanged, AddressOf Cmb_Marca_SelectedIndexChanged

        If _Accion = Accion.Editar Then

            Grupo_Vehiculo.Enabled = False
            Sb_Editar_Vehiculo()

            Btn_Editar.Visible = True
            Btn_Eliminar.Visible = True
            Btn_Cancelar.Visible = True
            Btn_Fotos_Vehiculo.Visible = True

            Sb_Botones_Habilitar_Deshabilitar(False)
            Txt_Patente.Enabled = False
            Me.Text = "EDITAR VEHICULO"

        Else

            Chk_Habilitado.Enabled = False
            Me.ActiveControl = Txt_Patente
            Me.Text = "CREACION DE VEHICULO"

        End If

        Btn_Fotos_Vehiculo.Visible = False

        Input_Ano.MaxValue = Year(FechaDelServidor)

        AddHandler Chk_Habilitado.CheckedChanging, AddressOf Chk_Habilitado_CheckedChanging

    End Sub


    Sub Sb_Botones_Habilitar_Deshabilitar(ByVal _Editar As Boolean)

        If _Editar Then
            Btn_Editar.Enabled = False
        Else
            Btn_Editar.Enabled = True
        End If

        Grupo_Vehiculo.Enabled = _Editar
        Btn_Grabar.Enabled = _Editar
        Btn_Eliminar.Enabled = _Editar
        Btn_Cancelar.Enabled = _Editar
        Btn_Fotos_Vehiculo.Enabled = _Editar

    End Sub

    Sub Sb_Editar_Vehiculo()

        Txt_Nombre_Vehiculo.Text = _RowVehiculo.Item("Nombre_Vehiculo")
        Txt_Patente.Text = _RowVehiculo.Item("Patente")

        Cmb_Tipo_Vehiculo.SelectedValue = _RowVehiculo.Item("CodigoTabla_Tipo_Vehiculo")
        Input_Ano.Value = _RowVehiculo.Item("Ano")
        Cmb_Marca.SelectedValue = _RowVehiculo.Item("CodigoTabla_Marca")
        Cmb_Modelo.SelectedValue = _RowVehiculo.Item("CodigoTabla_Modelo")
        Txt_Nro_Motor.Text = _RowVehiculo.Item("Nro_Motor")
        Txt_Nro_Chasis.Text = _RowVehiculo.Item("Nro_Chasis")
        Txt_Nro_Serie.Text = _RowVehiculo.Item("Nro_Serie")
        Txt_Nro_Vin.Text = _RowVehiculo.Item("Nro_Vin")
        Cmb_Color.SelectedValue = _RowVehiculo.Item("CodigoTabla_Color")
        Input_Kilometraje.Value = _RowVehiculo.Item("Kilometraje")
        Cmb_Chofer.SelectedValue = _RowVehiculo.Item("CodChofer")

        Chk_Habilitado.Checked = CBool(_RowVehiculo.Item("Habilitado"))

        Txt_Patente.Enabled = True

    End Sub

    Sub Sb_Actualizar_Variables()


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


        If Not Fx_Revisa_Dato(Txt_Nombre_Vehiculo, Lbl_Nombre_Vehiculo.Text) Then Return False
        If Not Fx_Revisa_Dato(Txt_Patente, Lbl_Patente.Text) Then Return False
        If Not Fx_Revisa_Dato(Cmb_Tipo_Vehiculo, Lbl_Tipo_Vehiculo.Text) Then Return False
        If Not Fx_Revisa_Dato(Cmb_Marca, Lbl_Marca.Text) Then Return False
        If Not Fx_Revisa_Dato(Cmb_Modelo, Lbl_Modelo.Text) Then Return False
        If Not Fx_Revisa_Dato(Txt_Nro_Motor, Lbl_Nro_Motor.Text) Then Return False
        If Not Fx_Revisa_Dato(Txt_Nro_Chasis, Lbl_Chasis.Text) Then Return False
        If Not Fx_Revisa_Dato(Txt_Nro_Serie, Lbl_Nro_Serie.Text) Then Return False

        If Not Fx_Revisa_Dato(Txt_Nro_Vin, Lbl_Nro_Vin.Text) Then Return False
        If Not Fx_Revisa_Dato(Cmb_Color, Lbl_Color.Text) Then Return False
        If Not Fx_Revisa_Dato(Cmb_Chofer, Lbl_Chofer.Text) Then Return False


        Dim _Patente = Txt_Patente.Text
        Dim _Nombre_Vehiculo = Txt_Nombre_Vehiculo.Text
        Dim _CodigoTabla_Tipo_Vehiculo = Cmb_Tipo_Vehiculo.SelectedValue
        Dim _Ano = Input_Ano.Value
        Dim _CodigoTabla_Marca = Cmb_Marca.SelectedValue
        Dim _CodigoTabla_Modelo = Cmb_Modelo.SelectedValue
        Dim _Nro_Motor = Txt_Nro_Motor.Text
        Dim _Nro_Chasis = Txt_Nro_Chasis.Text
        Dim _Nro_Serie = Txt_Nro_Serie.Text
        Dim _Nro_Vin = Txt_Nro_Vin.Text
        Dim _CodigoTabla_Color = Cmb_Color.SelectedValue
        Dim _Kilometraje = Input_Kilometraje.Value
        Dim _CodChofer = Cmb_Chofer.SelectedValue
        Dim _Habilitado = CInt(Chk_Habilitado.Checked) * -1



        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblVehiculos_Empresa Where Patente = '" & _Patente & "'" & vbCrLf & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TblVehiculos_Empresa " & _
                       "(Patente,Nombre_Vehiculo,CodigoTabla_Tipo_Vehiculo,Ano,CodigoTabla_Marca,CodigoTabla_Modelo,Nro_Motor," & _
                       "Nro_Chasis,Nro_Serie,Nro_Vin,CodigoTabla_Color,Kilometraje,CodChofer,Habilitado) Values " & _
                       "('" & _Patente & "','" & _Nombre_Vehiculo & "','" & _CodigoTabla_Tipo_Vehiculo & "'," & _Ano & _
                       ",'" & _CodigoTabla_Marca & "','" & _CodigoTabla_Modelo & "','" & _Nro_Motor & _
                       "','" & _Nro_Chasis & "','" & _Nro_Serie & "','" & _Nro_Vin & "','" & _CodigoTabla_Color & _
                       "'," & _Kilometraje & ",'" & _CodChofer & "'," & _Habilitado & ")"


        Dim _Grabar As Boolean

        _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        Return _Grabar

    End Function

    Sub Sb_Llenar_Combo_Tipo_Vehiculo(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "WHERE Tabla = 'VEHIC_TIPO'" & vbCrLf & _
                       "Order by Padre"
        _TblTipo_Vehiculo = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Tipo_Vehiculo)
        Cmb_Tipo_Vehiculo.DataSource = _TblTipo_Vehiculo
        Cmb_Tipo_Vehiculo.SelectedValue = _Codigo

    End Sub

    Sub Sb_Llenar_Combo_Marca_Vehiculo(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "WHERE Tabla = 'VEHIC_MARCA'" & vbCrLf & _
                       "Order by Padre"
        _TblMarca_Vehiculo = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Marca)
        Cmb_Marca.DataSource = _TblMarca_Vehiculo
        Cmb_Marca.SelectedValue = _Codigo

        If _TblMarca_Vehiculo.Rows.Count = 1 Then
            Cmb_Modelo.Enabled = False
        Else
            Cmb_Modelo.Enabled = True
        End If

    End Sub

    Sub Sb_Llenar_Combo_Modelo_Vehiculo(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "WHERE Tabla = 'VEHIC_MODELO' And Padre_Tabla = 'VEHIC_MARCA' And Padre_CodigoTabla = '" & Cmb_Marca.SelectedValue & "'" & vbCrLf & _
                       "Order by Padre"
        _TblModelo_Vehiculo = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Modelo)
        Cmb_Modelo.DataSource = _TblModelo_Vehiculo
        Cmb_Modelo.SelectedValue = _Codigo

    End Sub

    Sub Sb_Llenar_Combo_Color_Vehiculo(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "WHERE Tabla = 'COLOR'" & vbCrLf & _
                       "Order by Padre"
        _TblColo_Vehiculo = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Color)
        Cmb_Color.DataSource = _TblColo_Vehiculo
        Cmb_Color.SelectedValue = _Codigo

    End Sub

    Sub Sb_Llenar_Combo_Chofer(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodChofer As Padre,NomChofer As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TblChoferes_Empresa" & vbCrLf & _
                       "WHERE Habilitado = 1" & vbCrLf & _
                       "Order by Padre"
        _TblChofer = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Chofer)
        Cmb_Chofer.DataSource = _TblChofer
        Cmb_Chofer.SelectedValue = _Codigo

    End Sub

    Private Sub Cmb_Marca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Llenar_Combo_Modelo_Vehiculo("")
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If Fx_Grabar() Then

            If _Accion = Accion.Nuevo Then
                _Nuevo_Vehiculo = True
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

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Fx_Tiene_Permiso(Me, "Crv0004") Then
            Sb_Botones_Habilitar_Deshabilitar(True)
        End If
    End Sub

    Private Sub Btn_Tipo_Vehiculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tipo_Vehiculo.Click
        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Tipo, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Vehículos"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Combo_Tipo_Vehiculo(Cmb_Tipo_Vehiculo.SelectedValue)

    End Sub

    Private Sub Btn_Marca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca.Click
        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Marca, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Marcas de Vehículos"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Combo_Marca_Vehiculo(Cmb_Marca.SelectedValue)

    End Sub

    Sub Sb_Seleccionar_Marca_Para_Modelos()

        Dim _RowMarca As DataRow

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Marca, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Seleccionar)
        Fm.Text = "SELECCIONE UNA MARCA"
        Fm.ShowDialog(Me)

        _RowMarca = Fm.Pro_RowFilaSeleccionada
        Fm.Dispose()

        If Not (_RowMarca Is Nothing) Then
            Sb_Modelos_Vehiculos(_RowMarca)
        End If

    End Sub

    Sub Sb_Modelos_Vehiculos(ByVal _RowMarca As DataRow)

        Dim _CodMarca = _RowMarca.Item("CodigoTabla")
        Dim _Marca = Trim(_RowMarca.Item("NombreTabla"))

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Modelo, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Pro_Padre_Tabla = "VEHIC_MARCA"
        Fm.Pro_Padre_CodigoTabla = _CodMarca
        Fm.Text = "Tabla Modelos de Vehículos Marca (" & _Marca & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Seleccionar_Marca_Para_Modelos()

    End Sub

    Private Sub Btn_Modelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modelo.Click

        Dim _CodMarca = Cmb_Marca.SelectedValue
        Dim _Marca = Trim(Cmb_Marca.Text)

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Modelo, _
                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Pro_Padre_Tabla = "VEHIC_MARCA"
        Fm.Pro_Padre_CodigoTabla = _CodMarca
        Fm.Text = "Tabla Modelos de Vehículos Marca (" & _Marca & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Combo_Modelo_Vehiculo(Cmb_Modelo.SelectedValue)

    End Sub



    Private Sub Btn_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Color.Click
        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Color, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Colores"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Combo_Color_Vehiculo(Cmb_Color.SelectedValue)

    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Sb_Botones_Habilitar_Deshabilitar(False)
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        Dim _Patente = Txt_Patente.Text
        Dim _Grabar As Boolean

        'SELECT     TOP (200) Id_CRV, Nro_CRV, Patente, CodChofer, CodEntidad, SucEntidad, Pais, Ciudad, Comuna, Direccion, Fecha_Hora_Salida, Fecha_Hora_Llegada, Km_Salida, Km_Llegada, Observacion
        'FROM         Zw_CRV_Viajes

        Consulta_sql = "Select Nro_CRV From " & _Global_BaseBk & "Zw_CRV_Viajes Where Patente = '" & _Patente & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            MessageBoxEx.Show(Me, "Este registro no puede ser eliminado, ya que tiene gestión en R.C.V." & vbCrLf & _
                              "Se recomienda desahbilitar el vehículo", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            If MessageBoxEx.Show(Me, "¿Está seguro de eliminar este vehículo?", "Eliminar vehículo", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblVehiculos_Empresa Where Patente = '" & _Patente & "'"

                _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            End If

            If _Grabar Then
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Chk_Habilitado_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        If Not Fx_Tiene_Permiso(Me, "Crv0010") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Btn_Chofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Chofer.Click
        Dim Fm As New Frm_Choferes_Empresa_Lista
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Llenar_Combo_Chofer(Cmb_Chofer.SelectedValue)
    End Sub
End Class