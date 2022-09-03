Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_CRV

    Dim _Nro_CRV As String

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_CRV As DataRow

    Dim _CodEntidad As String
    Dim _SucEntidad As String
    Dim _Row_Entidad As DataRow

    Dim _Grabar As Boolean
    Dim _Nuevo_CRV As Boolean
    Dim _Cerrar_CRV As Boolean

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Pro_Row_CRV() As DataRow
        Get
            Return _Row_CRV
        End Get
        Set(ByVal value As DataRow)
            _Row_CRV = value
        End Set
    End Property



    Public Sub New(ByVal Accion_ As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion_

        Input_Kilometro_Salida.Value = 0

    End Sub

    Private Sub Frm_CRV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Llenar_Combo_Vehiculos("")
        Sb_Llenar_Combo_Chofer("")

        Sb_Cargar_Pais("")

        AddHandler Cmb_Pais.SelectedIndexChanged, AddressOf Sb_Cmb_Pais_SelectedIndexChanged
        AddHandler Cmb_Ciudad.SelectedIndexChanged, AddressOf Sb_Cmb_Ciudad_SelectedIndexChanged

        AddHandler Cmb_Nuevo_Vehiculo.SelectedIndexChanged, AddressOf Cmb_Nuevo_Vehiculo_SelectedIndexChanged
        AddHandler Cmb_Chofer.SelectedIndexChanged, AddressOf Cmb_Nuevo_Chofer_SelectedIndexChanged


        Dtp_Fecha_Salida.Value = Now.Date
        Dtp_Fecha_Llegada.Value = Now.Date

        Dtp_Hora_Llegada.Value = DateTime.Now
        Dtp_Hora_Salida.Value = DateTime.Now


        If _Accion = Accion.Editar Then

            Btn_Editar.Visible = True
            Btn_Anular.Visible = True
            Btn_Cancelar.Visible = True
            Btn_Imprimir_CRV.Visible = True
            Btn_Cerrar_CRV.Visible = True

            Sb_Botones_Habilitar_Deshabilitar(False)

            Sb_Editar_CRV()
            Layaut_CRV_1.Enabled = False

        Else

            Layaut_Cierre.Visible = False

            Btn_Anular.Visible = False
            Btn_Cancelar.Visible = False
            Btn_Imprimir_CRV.Visible = False

            Input_Kilometro_Llegada.Enabled = False
            Dtp_Fecha_Llegada.Enabled = False
            Dtp_Hora_Llegada.Enabled = False

            Me.ActiveControl = Cmb_Nuevo_Vehiculo

        End If

        Input_Kilometro_Llegada.MinValue = Input_Kilometro_Salida.Value

        'AddHandler Input_Kilometro_Salida.Validating, AddressOf Input_Kilometro_Salida_Validating
        AddHandler Input_Kilometro_Salida.ValueChanged, AddressOf Input_Kilometro_Salida_ValueChanged
        'AddHandler Input_Kilometro_Llegada.Validating, AddressOf Input_Kilometro_Llegada_Validating

    End Sub

    Sub Sb_Editar_CRV()

        'Id_CRV, Nro_CRV, Patente, CodChofer, CodEntidad, SucEntidad, Pais, Ciudad, Comuna, Direccion, " & _
        '"Fecha_Hora_Salida, Fecha_Hora_Llegada, Km_Salida, Km_Llegada, Observacion, 
        'Cerrada
        'FROM         Zw_CRV_Viajes

        With _Row_CRV

            Dim _Estado = .Item("Estado")

            If _Estado = "CE" Then
                Btn_Cerrar_CRV.Visible = False
            End If

            Cmb_Nuevo_Vehiculo.SelectedValue = .Item("Patente")
            Cmb_Chofer.SelectedValue = .Item("CodChofer")

            Dim _CodEntidad = .Item("CodEntidad")
            Dim _SucEntidad = .Item("SucEntidad")

            Consulta_sql = "Select top 1 * From MAEEN Where KOEN = '" & _CodEntidad & "' And SUEN = '" & _SucEntidad & "'"
            Dim _Tbl_Inf_Entidad As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl_Inf_Entidad.Rows.Count) Then
                _Row_Entidad = _Tbl_Inf_Entidad.Rows(0)
                Txt_Razon_Entidad.Text = _Row_Entidad.Item("NOKOEN")
                Cmb_Pais.SelectedValue = .Item("Pais")
                Cmb_Ciudad.SelectedValue = .Item("Ciudad")
                Cmb_Comuna.SelectedValue = .Item("Comuna")
                Txt_Direccion.Text = .Item("Direccion")
                Btn_Limpiar_Entidad.Enabled = True
            Else
                _Row_Entidad = Nothing
                Txt_Razon_Entidad.Text = String.Empty
                Cmb_Pais.SelectedValue = String.Empty
                Cmb_Ciudad.SelectedValue = String.Empty
                Cmb_Comuna.SelectedValue = String.Empty
                Txt_Direccion.Text = String.Empty
                Btn_Limpiar_Entidad.Enabled = False
            End If

            Dtp_Fecha_Salida.Value = .Item("Fecha_Hora_Salida")
            Dtp_Hora_Salida.Value = .Item("Fecha_Hora_Salida")


            If String.IsNullOrEmpty(Trim(_Estado)) Then
                Dtp_Fecha_Llegada.Value = Now.Date
                Dtp_Hora_Llegada.Value = DateTime.Now
            Else
                Dtp_Fecha_Llegada.Value = .Item("Fecha_Hora_Llegada")
                Dtp_Hora_Llegada.Value = .Item("Fecha_Hora_Llegada")
            End If


            Input_Kilometro_Salida.Value = .Item("Km_Salida")
            Input_Kilometro_Llegada.Value = .Item("Km_Llegada")

        End With
    End Sub

    Sub Sb_Botones_Habilitar_Deshabilitar(ByVal _Editar As Boolean)

        Dim _Estado = String.Empty
        Dim _Cerrada As Boolean

        If _Accion = Accion.Editar Then
            _Estado = _Row_CRV.Item("Estado")
            If _Estado = "CE" Then
                _Cerrada = True
            End If
        End If


        If _Editar Then
            Btn_Editar.Enabled = False
            Btn_Imprimir_CRV.Enabled = False
        Else
            Btn_Editar.Enabled = True
            Btn_Imprimir_CRV.Enabled = True
        End If

        If _Cerrar_CRV Then
            Layaut_Cierre.Enabled = _Editar
            'If _Cerrada Then Layaut_CRV_1.Enabled = False
            Layaut_CRV_2.Enabled = False
            Btn_Anular.Enabled = False
        Else
            Layaut_Cierre.Enabled = False
            'If _Cerrada Then Layaut_CRV_1.Enabled = _Editar
            Layaut_CRV_2.Enabled = _Editar
            Btn_Anular.Enabled = _Editar
        End If

        If _Editar Then
            Btn_Cerrar_CRV.Visible = False
            If _Cerrar_CRV Then
                Btn_Grabar.Text = "Grabar Cierre"
            Else
                Btn_Grabar.Text = "Grabar Edición"
            End If
            If _Cerrada Then
                Layaut_Cierre.Enabled = _Editar
            End If
        Else
            Btn_Grabar.Text = ""
            Btn_Cerrar_CRV.Visible = True
        End If

        If _Cerrada Then Btn_Cerrar_CRV.Visible = False

        Btn_Grabar.Enabled = _Editar
        Btn_Cancelar.Enabled = _Editar

        Me.Refresh()

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
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOCM AS Padre, NOKOCM AS Hijo FROM TABCM WHERE KOPA = '" & _Pais & "' AND KOCI = '" & _Ciudad & "'"
        Cmb_Comuna.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Comuna.SelectedValue = _Comuna

    End Sub

#End Region

    Sub Sb_Llenar_Combo_Chofer(ByVal _Codigo As String)

        Dim _Nro_CRV = String.Empty

        If _Accion = Accion.Editar Then
            _Nro_CRV = _Row_CRV.Item("Nro_CRV")
        End If


        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodChofer As Padre,NomChofer As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TblChoferes_Empresa" & vbCrLf & _
                       "WHERE Habilitado = 1" & vbCrLf & _
                       "Order by Padre"
        Dim _TblChofer = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Chofer)
        Cmb_Chofer.DataSource = _TblChofer
        Cmb_Chofer.SelectedValue = _Codigo

    End Sub

    Sub Sb_Llenar_Combo_Vehiculos(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT Patente As Padre,Nombre_Vehiculo As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TblVehiculos_Empresa" & vbCrLf & _
                       "WHERE Habilitado = 1" & vbCrLf & _
                       "Order by Padre"
        Dim _TblVehiculo = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Nuevo_Vehiculo)
        Cmb_Nuevo_Vehiculo.DataSource = _TblVehiculo
        Cmb_Nuevo_Vehiculo.SelectedValue = _Codigo

    End Sub


    Private Sub Cmb_Nuevo_Vehiculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        RemoveHandler Cmb_Nuevo_Vehiculo.SelectedIndexChanged, AddressOf Cmb_Nuevo_Vehiculo_SelectedIndexChanged

        Dim _Limpia As Boolean
        Txt_Patente.Text = Cmb_Nuevo_Vehiculo.SelectedValue

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_CRV_Viajes Where Patente = '" & Txt_Patente.Text & "' And Estado = ''" & vbCrLf & _
                       "Select top 1 * From " & _Global_BaseBk & "Zw_TblVehiculos_Empresa Where Patente = '" & Txt_Patente.Text & "'"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _TblViajes As DataTable = _Ds.Tables(0)
        Dim _TblVehiculo As DataTable = _Ds.Tables(1) '_Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblViajes.Rows.Count) Then

            If _Accion = Accion.Editar Then
                If Not (_Row_CRV Is Nothing) Then
                    If _Row_CRV.Item("Patente") <> Txt_Patente.Text Then
                        _Limpia = True
                    End If
                End If
            Else
                MessageBoxEx.Show(Me, "Este vehiculo tiene un viaje en curso. Nro Viaje (" & _TblViajes.Rows(0).Item("Nro_CRV") & ")" & vbCrLf & _
                                             "Debe cerrar ese viaje antes de poder utilizar nuevamente este vehiculo", _
                                             "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Limpia = True
            End If



        Else
            If CBool(_TblVehiculo.Rows.Count) Then
                Input_Kilometro_Salida.Value = _TblVehiculo.Rows(0).Item("Kilometraje")
            Else
                _Limpia = True
            End If
        End If

        If _Limpia Then
            Cmb_Nuevo_Vehiculo.SelectedValue = ""
            Txt_Patente.Text = String.Empty
            Input_Kilometro_Salida.Value = 0
        End If

        AddHandler Cmb_Nuevo_Vehiculo.SelectedIndexChanged, AddressOf Cmb_Nuevo_Vehiculo_SelectedIndexChanged

    End Sub

    Private Sub Cmb_Nuevo_Chofer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        RemoveHandler Cmb_Chofer.SelectedIndexChanged, AddressOf Cmb_Nuevo_Chofer_SelectedIndexChanged

        Dim _Limpia As Boolean
        'Txt_Patente.Text = Cmb_Nuevo_Vehiculo.SelectedValue

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_CRV_Viajes Where CodChofer = '" & Cmb_Chofer.SelectedValue & "' And Estado = ''" & vbCrLf & _
                       "Select top 1 * From " & _Global_BaseBk & "Zw_TblChoferes_Empresa Where CodChofer = '" & Cmb_Chofer.SelectedValue & "'"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _TblViajes As DataTable = _Ds.Tables(0)
        Dim _TblChofer As DataTable = _Ds.Tables(1) '_Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblViajes.Rows.Count) Then

            If _Accion = Accion.Editar Then
                If Not (_Row_CRV Is Nothing) Then
                    If _Row_CRV.Item("CodChofer") <> Cmb_Chofer.SelectedValue Then
                        _Limpia = True
                    End If
                End If
            Else
                MessageBoxEx.Show(Me, "Este Chofer tiene un viaje en curso. Nro Viaje (" & _TblViajes.Rows(0).Item("Nro_CRV") & ")" & vbCrLf & _
                                  "Debe cerrar ese viaje antes de poder utilizar nuevamente a este chofer", _
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Limpia = True
            End If
            'Else
            'If CBool(_TblChofer.Rows.Count) Then
            'Input_Kilometro_Salida.Value = _TblChofer.Rows(0).Item("Kilometraje")
            'Else
            '_Limpia = True
            'End If
        End If

        If _Limpia Then
            Cmb_Chofer.SelectedValue = ""
        End If

        AddHandler Cmb_Chofer.SelectedIndexChanged, AddressOf Cmb_Nuevo_Chofer_SelectedIndexChanged

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub


    Private Sub Btn_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Vehiculos.Click
        Dim Fm As New Frm_Vehiculos_Empresa_Lista
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Llenar_Combo_Vehiculos(Cmb_Nuevo_Vehiculo.SelectedValue)
    End Sub

    Private Sub Btn_Chofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Chofer.Click
        Dim Fm As New Frm_Choferes_Empresa_Lista
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Llenar_Combo_Chofer(Cmb_Chofer.SelectedValue)
    End Sub

    Private Sub Btn_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Entidad.Click

        'Dim _RowEntidad As DataRow
        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
        Fm_Ent.Text = "SELECCIONE LA ENTIDAD CLIENTE"
        Fm_Ent.ShowDialog(Me)

        If Fm_Ent.Pro_Entidad_Seleccionada Then
            _Row_Entidad = Fm_Ent.Pro_RowEntidad
            Txt_Razon_Entidad.Text = _Row_Entidad.Item("NOKOEN")
            Cmb_Pais.SelectedValue = _Row_Entidad.Item("PAEN")
            Cmb_Ciudad.SelectedValue = _Row_Entidad.Item("CIEN")
            Cmb_Comuna.SelectedValue = _Row_Entidad.Item("CMEN")
            Txt_Direccion.Text = _Row_Entidad.Item("DIEN")
            Btn_Limpiar_Entidad.Enabled = True
            Txt_Direccion.Focus()
        Else
            Return
        End If
        Fm_Ent.Dispose()

    End Sub



    Private Sub Btn_Limpiar_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar_Entidad.Click

        _Row_Entidad = Nothing
        Txt_Razon_Entidad.Text = String.Empty
        Cmb_Pais.SelectedValue = String.Empty
        Cmb_Ciudad.SelectedValue = String.Empty
        Cmb_Comuna.SelectedValue = String.Empty
        Txt_Direccion.Text = String.Empty
        Btn_Limpiar_Entidad.Enabled = False

    End Sub


    Private Sub Input_Kilometro_Salida_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Input_Kilometro_Llegada.MinValue = Input_Kilometro_Salida.Value
    End Sub

    Private Sub Dtp_Fecha_Llegada_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtp_Fecha_Llegada.ValueChanged
        If Dtp_Fecha_Llegada.Value < Dtp_Fecha_Salida.Value Then
            Dtp_Fecha_Llegada.Value = Now.Date
            MessageBoxEx.Show(Me, "La fecha de llegada no puede ser menor a la fecha de salida", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
    End Sub

   
    Private Sub Dtp_Hora_Llegada_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtp_Hora_Llegada.ValueChanged
        If Dtp_Fecha_Llegada.Value = Dtp_Fecha_Salida.Value Then
            If Dtp_Hora_Llegada.Value < Dtp_Hora_Salida.Value Then
                Dtp_Hora_Llegada.Value = DateTime.Now
                MessageBoxEx.Show(Me, "La hora no puede ser menor a la hora de salida", "Validación", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub Btn_Editar_Km_Salida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Km_Salida.Click
        If Fx_Tiene_Permiso(Me, "Crv0020") Then
            Input_Kilometro_Salida.Enabled = True
        End If
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click

        Dim _Estado = String.Empty
        Dim _Cerrada As Boolean

        If _Accion = Accion.Editar Then
            _Estado = _Row_CRV.Item("Estado")
            If _Estado <> "CE" Then
                If Fx_Tiene_Permiso(Me, "Crv0015") Then
                    Sb_Botones_Habilitar_Deshabilitar(True)
                End If
            Else
                If Fx_Tiene_Permiso(Me, "Crv0016") Then
                    Sb_Botones_Habilitar_Deshabilitar(True)
                End If
            End If
        End If

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


        If Not Fx_Revisa_Dato(Cmb_Nuevo_Vehiculo, "Patente") Then Return False
        If Not Fx_Revisa_Dato(Txt_Patente, "Patente") Then Return False
        If Not Fx_Revisa_Dato(Cmb_Chofer, "Chofer") Then Return False
        If Not Fx_Revisa_Dato(Txt_Razon_Entidad, "Cliente / Proveedor") Then Return False
        If Not Fx_Revisa_Dato(Cmb_Pais, "Pais") Then Return False
        If Not Fx_Revisa_Dato(Cmb_Ciudad, "Ciudad") Then Return False
        If Not Fx_Revisa_Dato(Cmb_Comuna, "Comuna") Then Return False

        If Not Fx_Revisa_Dato(Txt_Direccion, "Dirección") Then Return False

        If _Accion = Accion.Editar Then
            If _Cerrar_CRV Then
                If Input_Kilometro_Salida.Value = Input_Kilometro_Llegada.Value Then
                    Beep()
                    ToastNotification.Show(Me, "KM SALIDA NO PUEDE SER IGUAL A KM LLEGADA", _
                                           Imagenes_32x32.Images.Item("warning.png"), _
                                           2 * 1000, eToastGlowColor.Red, _
                                           eToastPosition.MiddleCenter)
                    Input_Kilometro_Llegada.Focus()
                    Return False
                End If
            End If
        End If

        ' Dim _Nro_CRV As String
        Dim _Estado = String.Empty

        If _Accion = Accion.Nuevo Then
            _Nro_CRV = Fx_Nvo_CRV()
        Else

            If _Cerrar_CRV Then

                Dim _Fecha_Salida As Date = Format(Dtp_Fecha_Salida.Value, "dd/MM/yyyy")
                Dim _Fecha_Llegada As Date = Format(Dtp_Fecha_Llegada.Value, "dd/MM/yyyy")


                If _Fecha_Llegada < _Fecha_Salida Then
                    Dtp_Fecha_Llegada.Value = Now.Date
                    MessageBoxEx.Show(Me, "La fecha de llegada no puede ser menor a la fecha de salida", "Validación", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                If _Fecha_Llegada = _Fecha_Salida Then
                    If Dtp_Hora_Llegada.Value <= Dtp_Hora_Salida.Value Then
                        Dtp_Hora_Llegada.Value = DateTime.Now
                        MessageBoxEx.Show(Me, "La hora no puede ser menor o igual a la hora de salida", "Validación", _
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If
                End If
                _Estado = "CE"
            Else
                _Estado = _Row_CRV.Item("Estado")
            End If

            _Nro_CRV = _Row_CRV.Item("Nro_CRV")

        End If

        Dim _Patente = Txt_Patente.Text
        Dim _CodChofer = Cmb_Chofer.SelectedValue
        Dim _CodEntidad = _Row_Entidad.Item("KOEN")
        Dim _SucEntidad = _Row_Entidad.Item("SUEN")

        Dim _Pais = Cmb_Pais.SelectedValue
        Dim _Ciudad = Cmb_Ciudad.SelectedValue
        Dim _Comuna = Cmb_Comuna.SelectedValue

        Dim _Direccion = Txt_Direccion.Text
        Dim _Fecha_Hora_Salida = Format(Dtp_Fecha_Salida.Value, "yyyyMMdd") & " " & Format(Dtp_Hora_Salida.Value, "HH:mm")
        Dim _Fecha_Hora_Llegada = Format(Dtp_Fecha_Llegada.Value, "yyyyMMdd") & " " & Format(Dtp_Hora_Llegada.Value, "HH:mm")

        Dim _Km_Salida = Input_Kilometro_Salida.Value
        Dim _Km_Llegada = Input_Kilometro_Llegada.Value

        'Dim _Habilitado = CInt(Chk_Habilitado.Checked) * -1

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CRV_Viajes Where Nro_CRV = '" & _Nro_CRV & "'" & vbCrLf & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_CRV_Viajes (Nro_CRV,Patente,CodChofer,CodEntidad,SucEntidad,Pais,Ciudad,Comuna,Direccion," & _
                       "Fecha_Hora_Salida,Fecha_Hora_Llegada,Km_Salida,Km_Llegada,Observacion,Estado) Values " & vbCrLf & _
                       "('" & _Nro_CRV & "','" & _Patente & "','" & _CodChofer & "','" & _CodEntidad & "','" & _SucEntidad & _
                       "','" & _Pais & "','" & _Ciudad & "','" & _Comuna & "','" & _Direccion & "'," & _
                       "'" & _Fecha_Hora_Salida & "','" & _Fecha_Hora_Llegada & "'," & _Km_Salida & "," & _Km_Llegada & _
                       ",'','" & _Estado & "')" & vbCrLf & vbCrLf

        If _Cerrar_CRV Then

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_TblVehiculos_Empresa Set Kilometraje = " & _Km_Llegada & Space(1) & _
                            "Where Patente = '" & _Patente & "'"

        End If

        Dim _Grabar As Boolean

        _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        If _Accion = Accion.Editar Then _Row_CRV.Item("Estado") = _Estado

        If _Grabar Then
            Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_CRV_Viajes Where Nro_CRV = '" & _Nro_CRV & "'"
            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            _Row_CRV = _Tbl.Rows(0)
        End If

        Return _Grabar

    End Function

    Function Fx_Nvo_CRV() As String

        Dim _Nvo_CRV As String

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Nro_CRV) As Nro_CRV " & _
                                          "From " & _Global_BaseBk & "Zw_CRV_Viajes") ' cn1, "MAX(Nro_SOC)", _Global_BaseBk & "ZW_SOC_Encabezado", "Stand_By = " & Stby)

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Nro_CRV"), "")

            If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
                _Ult_Nro_OT = 1
            Else
                _Ult_Nro_OT += 1
            End If
            _Nvo_CRV = numero_(Val(_Ult_Nro_OT), 10)
        Else
            _Nvo_CRV = numero_(1, 10)
        End If

        Return _Nvo_CRV

    End Function

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        _Grabar = Fx_Grabar()

        If _Grabar Then

            'Dim _Nro_CRV = _Row_CRV.Item("Nro_CRV")

            If _Accion = Accion.Nuevo Then
                If MessageBoxEx.Show(Me, "Control Ruta Vehículo Nro " & _Nro_CRV & " Creada correctamente" & vbCrLf & _
                                       "¿Desea imprimir reporte?", "Cierre de C.R.V.", _
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    
                    Sb_Imprimir_Reporte_RCV()
                End If
                Me.Close()
            Else
                If _Cerrar_CRV Then


                    'If MessageBoxEx.Show(Me, "Control Ruta Vehículo Nro " & _Nro_CRV & " Cerrada correctamente" & vbCrLf & _
                    '                   "¿Desea imprimir reporte?", "Cierre de C.R.V.", _
                    '                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'Sb_Imprimir_Reporte_RCV()
                    MessageBoxEx.Show(Me, "Control Ruta Vehículo Nro " & _Nro_CRV & " Cerrada correctamente" & vbCrLf & _
                                       "¿Desea imprimir reporte?", "Cierre de C.R.V.", _
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                    'End If
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
        End If

    End Sub

    Private Sub Btn_Fecha_Actual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fecha_Actual.Click
        Dtp_Fecha_Llegada.Value = Now.Date
    End Sub

    Private Sub Btn_Hora_Actual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Hora_Actual.Click
        Dtp_Hora_Llegada.Value = DateTime.Now
    End Sub

  
    Private Sub Btn_Cerrar_CRV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cerrar_CRV.Click
        If Fx_Tiene_Permiso(Me, "Crv0021") Then
            _Cerrar_CRV = True
            Sb_Botones_Habilitar_Deshabilitar(True)
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cerrar_CRV = False
        Sb_Botones_Habilitar_Deshabilitar(False)
    End Sub

    Private Sub Btn_Imprimir_CRV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_CRV.Click
        If Fx_Tiene_Permiso(Me, "Crv0023") Then
            Sb_Imprimir_Reporte_RCV()
        End If
    End Sub


    Sub Sb_Imprimir_Reporte_RCV()

        Dim _Nro_CRV As String = _Row_CRV.Item("Nro_CRV")
        Dim _Estado As String = Trim(_Row_CRV.Item("Estado"))
       
        Dim _Nombre_Vehiculo = Trim(Cmb_Nuevo_Vehiculo.Text)
        Dim _Patente = Trim(Txt_Patente.Text)
        Dim _NomChofer = Trim(Cmb_Chofer.Text)



        Dim _Rt = _Row_Entidad.Item("RTEN")
        Dim _Rut_Cliente As String = FormatNumber(_Rt, 0) & "-" & RutDigito(_Rt)

        Dim _Razon_Social = Txt_Razon_Entidad.Text

        Dim _Pais = Trim(Cmb_Pais.Text)
        Dim _Ciudad = Trim(Cmb_Ciudad.Text)
        Dim _Comuna = Trim(Cmb_Comuna.Text)
        Dim _Direccion = Trim(Txt_Direccion.Text)

        Dim _Fecha_Salida = FormatDateTime(Dtp_Fecha_Salida.Value, DateFormat.ShortDate)
        Dim _Hora_Salida = FormatDateTime(Dtp_Hora_Salida.Value, DateFormat.ShortTime)

        Dim _Fecha_Llegada = FormatDateTime(Dtp_Fecha_Llegada.Value, DateFormat.ShortDate)
        Dim _Hora_Llegada = FormatDateTime(Dtp_Hora_Llegada.Value, DateFormat.ShortTime)


        Dim _Km_Salida = Input_Kilometro_Salida.Value
        Dim _Km_Llegada = Input_Kilometro_Llegada.Value

        If String.IsNullOrEmpty(_Estado) Then
            _Fecha_Llegada = String.Empty
            _Hora_Llegada = String.Empty
            _Km_Llegada = 0
        End If


        Try



            'iniciamos el form y el reporte
            Dim form As New Frm_VerReportes
            Dim report As New CRV

            report.SetParameterValue("Nro_CRV", _Nro_CRV)

            'le indicamos el datasource al report, que sera el recordset
            'que hemos llenado
            'report.SetDataSource(_Tbl_Informe)

            'le indicamos el reportsource al crviewer del segundo form
            'que sera el report que creamos

            report.SetParameterValue("Rut_Cliente", _Rut_Cliente)
            report.SetParameterValue("Razon_Social", _Razon_Social)
            report.SetParameterValue("Fecha_Emision", FormatDateTime(Now.Date, DateFormat.ShortDate))
            report.SetParameterValue("Direccion", _Comuna & " - " & _Direccion)

            report.SetParameterValue("NomChofer", _NomChofer)


            report.SetParameterValue("Nombre_Vehiculo", _Nombre_Vehiculo)
            report.SetParameterValue("Patente", _Patente)

            report.SetParameterValue("Fecha_Salida", _Fecha_Salida)
            report.SetParameterValue("Hora_Salida", _Hora_Salida)

            report.SetParameterValue("Fecha_Llegada", _Fecha_Llegada)
            report.SetParameterValue("Hora_Llegada", _Hora_Llegada)

            report.SetParameterValue("Km_Salida", _Km_Salida)
            report.SetParameterValue("Km_Llegada", _Km_Llegada)


            form.CrystalReportViewer1.ReportSource = report
            form.ShowInTaskbar = True
            form.Show()

            form = Nothing


            'MessageBoxEx.Show(Me, "No hay datos en la tabla de aprobación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub Btn_Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anular.Click
        If Fx_Tiene_Permiso(Me, "Crv0022") Then
            Dim _Nro_CRV = _Row_CRV.Item("Nro_CRV")
            If MessageBoxEx.Show(Me, "¿Está seguro de querer anular esta C.R.V. Nro: " & _Nro_CRV & "?", "Anular C.R.V.", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_CRV_Viajes Set Estado = 'N' Where Nro_CRV = '" & _Nro_CRV & "'" & vbCrLf & vbCrLf
                _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                If _Grabar Then
                    MessageBoxEx.Show(Me, "C.R.V. Anulado correctamente", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If

            End If
        End If
    End Sub
End Class