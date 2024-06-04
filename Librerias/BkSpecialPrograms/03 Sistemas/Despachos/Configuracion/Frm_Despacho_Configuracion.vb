Imports DevComponents.DotNetBar

Public Class Frm_Despacho_Configuracion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Email As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Correos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Correos.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Despacho_Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Txt_Valor_Min_Despacho.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        Txt_Valor_Min_Despacho.Tag = 0

        Sb_Llenar_Combo_Estados()
        Sb_Llenar_Tipo_Venta("")

        Consulta_Sql = "Select ZConf.*,
                            Isnull(Tvta.NombreTabla,'') As Nom_Tipo_Venta,Isnull(NORETI,'') As Nom_Transportista
                            From " & _Global_BaseBk & "Zw_Despachos_Configuracion ZConf
                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tvta On Tvta.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Tvta.CodigoTabla = Tipo_Venta_X_Defecto
                            Left Join TABRETI On KORETI = Transportista_X_Defecto
                            Where Empresa = '" & ModEmpresa & "'"
        Dim _Row_Conf_Despacho As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Conf_Despacho) Then

            Chk_Pedir_Sucursal_Retiro.Checked = _Row_Conf_Despacho.Item("Pedir_Sucursal_Retiro")

            Txt_Tipo_Venta.Tag = _Row_Conf_Despacho.Item("Tipo_Venta_X_Defecto")
            Txt_Tipo_Venta.Text = _Row_Conf_Despacho.Item("Nom_Tipo_Venta")

            Txt_Transportista.Tag = _Row_Conf_Despacho.Item("Transportista_X_Defecto")
            Txt_Transportista.Text = _Row_Conf_Despacho.Item("Nom_Transportista")

            Chk_Transpor_Por_Pagar.Checked = _Row_Conf_Despacho.Item("Transpor_Por_Pagar")
            Txt_Valor_Min_Despacho.Tag = _Row_Conf_Despacho.Item("Valor_Min_Despacho")

            Chk_Mostrar_RetiraTransportista.Checked = _Row_Conf_Despacho.Item("Mostrar_RetiraTransportista")
            Chk_Mostrar_Agencia.Checked = _Row_Conf_Despacho.Item("Mostrar_Agencia")

            Chk_ConfirmarLecturaDespacho.Checked = _Row_Conf_Despacho.Item("ConfirmarLecturaDespacho")

        End If

        Txt_Valor_Min_Despacho.Text = FormatNumber(Txt_Valor_Min_Despacho.Tag, 0)

        Sb_Actualizar_Grilla()

        AddHandler Cmb_Estados.SelectedIndexChanged, AddressOf Sb_Actualizar_Grilla
        AddHandler Cmb_Tipo_Venta.SelectedIndexChanged, AddressOf Sb_Actualizar_Grilla

        AddHandler Btn_Formato_BLV.Click, AddressOf Sb_Buscar_Formato
        AddHandler Btn_Formato_FCV.Click, AddressOf Sb_Buscar_Formato
        AddHandler Btn_Formato_GTI.Click, AddressOf Sb_Buscar_Formato
        AddHandler Btn_Formato_GDV.Click, AddressOf Sb_Buscar_Formato

        Sb_Contar_Transportistas()

    End Sub

    Sub Sb_Llenar_Combo_Estados()

        Consulta_Sql = "Select CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = 'SIS_DESPACHO_ESTADOS' Order by Orden"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        caract_combo(Cmb_Estados)
        Cmb_Estados.DataSource = _Tbl

        Cmb_Estados.SelectedValue = "ING"

    End Sub

    Sub Sb_Llenar_Tipo_Venta(_Codigo As String)

        Consulta_Sql = "Select '' As Padre,'' As Hijo Union" & vbCrLf &
                       "Select CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = 'SIS_DESPACHO_TIPO_VENTA' Order by Padre"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        caract_combo(Cmb_Tipo_Venta)
        Cmb_Tipo_Venta.DataSource = _Tbl

        Cmb_Tipo_Venta.SelectedValue = _Codigo

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Estado As String = Cmb_Estados.SelectedValue
        Dim _Tipo_Venta As String = Cmb_Tipo_Venta.SelectedValue

        Consulta_Sql = "Select Isnull(Temail.Id,0) As Id,Tabla, DescripcionTabla, CodigoTabla As Tipo_Envio,Temail.Tipo_Venta,Temail.Estado, NombreTabla, 
		                Isnull(Temail.Id_Correo,0) As Id_Correo,Isnull(Tcorreos.Nombre_Correo,'') AS Nombre_Correo,
                        Isnull(Temail.Adjuntar_Documentos,0) As Adjuntar_Documentos,
                        Isnull(Temail.Enviar_al_otro_dia,0) As Enviar_al_otro_dia,
                        Isnull(Temail.Format_BLV,'') As Format_BLV,
						Isnull(Temail.Format_FCV,'') As Format_FCV,
						Isnull(Temail.Format_GDV,'') As Format_GDV,
						Isnull(Temail.Format_GTI,'') As Format_GTI
                        From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tc
                        Left Join " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Temail On Tc.CodigoTabla = Temail.Tipo_Envio And Temail.Tipo_Venta = '" & _Tipo_Venta & "' And Temail.Estado = '" & _Estado & "'
                        Left Join " & _Global_BaseBk & "Zw_Correos Tcorreos On Temail.Id_Correo = Tcorreos.Id
                        Where (Tabla LIKE 'SIS_DESPACHO_TIPO_ENVIO') "

        _Tbl_Email = _Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla_Correos

            .DataSource = _Tbl_Email

            OcultarEncabezadoGrilla(Grilla_Correos)

            .Columns("NombreTabla").Visible = True
            .Columns("NombreTabla").HeaderText = "Tipo envío"
            .Columns("NombreTabla").Width = 60

            .Columns("Nombre_Correo").Visible = True
            .Columns("Nombre_Correo").HeaderText = "Correo relacionado"
            .Columns("Nombre_Correo").Width = 240

            .Columns("Adjuntar_Documentos").Visible = True
            .Columns("Adjuntar_Documentos").HeaderText = "Adj. Doc."
            .Columns("Adjuntar_Documentos").ToolTipText = "Adjuntar documentos"
            .Columns("Adjuntar_Documentos").Width = 50

            .Columns("Enviar_al_otro_dia").Visible = True
            .Columns("Enviar_al_otro_dia").HeaderText = "Env.OD"
            .Columns("Enviar_al_otro_dia").ToolTipText = "Enviar correo al otro día"
            .Columns("Enviar_al_otro_dia").Width = 50

        End With

    End Sub

    Private Sub Btn_Mnu_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Correo.Click

        Dim _Row_Email As DataRow

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)
        _Row_Email = Fm.Pro_Row_Fila_Seleccionada
        Fm.Dispose()

        If Not IsNothing(_Row_Email) Then

            Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)

            Dim _Id = _Fila.Cells("Id").Value
            Dim _Tipo_Envio = _Fila.Cells("Tipo_Envio").Value
            Dim _Estado = Cmb_Estados.SelectedValue
            Dim _Tipo_Venta = Cmb_Tipo_Venta.SelectedValue
            Dim _Id_Correo = _Row_Email.Item("Id")
            Dim _Nombre_Correo = _Row_Email.Item("Nombre_Correo")
            Dim _Confirmado As Boolean

            Dim _Adjuntar_Documentos As Boolean

            If MessageBoxEx.Show(Me, "¿Desea adjuntar documentos al envio?" & vbCrLf & "(facturas,boletas,guías,etc.)", "Adjuntar documentos",
                                 vbYesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _Adjuntar_Documentos = True
            End If

            If CBool(_Id) Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Set Id_Correo = '" & _Id_Correo & "', Adjuntar_Documentos = " & Convert.ToInt32(_Adjuntar_Documentos) & "
                                Where Id= " & _Id
                _Confirmado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

            Else

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Email_Aviso (Estado,Tipo_Envio,Tipo_Venta,Id_Correo,Adjuntar_Documentos) Values 
                                ('" & _Estado & "','" & _Tipo_Envio & "','" & _Tipo_Venta & "','" & _Id_Correo & "'," & Convert.ToInt32(_Adjuntar_Documentos) & ")"
                _Confirmado = _Sql.Ej_Insertar_Trae_Identity(Consulta_Sql, _Id)

            End If

            If _Confirmado Then

                _Fila.Cells("Id").Value = _Id
                _Fila.Cells("Id_Correo").Value = _Id_Correo
                _Fila.Cells("Nombre_Correo").Value = _Nombre_Correo
                _Fila.Cells("Adjuntar_Documentos").Value = _Adjuntar_Documentos

            End If

        End If

    End Sub

    Private Sub Grilla_Correos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Correos.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        Dim _Format_BLV = _Fila.Cells("Format_BLV").Value
        Dim _Format_FCV = _Fila.Cells("Format_FCV").Value
        Dim _Format_GDV = _Fila.Cells("Format_GDV").Value
        Dim _Format_GTI = _Fila.Cells("Format_GTI").Value

        If CBool(_Id) Then

            Dim _Nombre_Correo = _Fila.Cells("Nombre_Correo").Value

            Chk_Adjuntar_Archivo.Enabled = CBool(_Id)
            Btn_Mnu_Quitar_Correo.Enabled = CBool(_Id)
            Chk_Adjuntar_Archivo.Checked = _Fila.Cells("Adjuntar_Documentos").Value

            Btn_Formato_BLV.Text = "Formato BLV: " & _Format_BLV
            Btn_Formato_FCV.Text = "Formato FCV: " & _Format_FCV
            Btn_Formato_GDV.Text = "Formato GDV: " & _Format_GDV
            Btn_Formato_GTI.Text = "Formato GTI: " & _Format_GTI

            ShowContextMenu(Menu_Contextual)

        Else
            Call Btn_Mnu_Correo_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Chk_Adjuntar_Archivo_Click(sender As Object, e As EventArgs) Handles Chk_Adjuntar_Archivo.Click

        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Adjuntar_Documentos = Convert.ToInt32(Chk_Adjuntar_Archivo.Checked)

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Set Adjuntar_Documentos = " & _Adjuntar_Documentos & "
                        Where Id= " & _Id

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            _Fila.Cells("Adjuntar_Documentos").Value = Chk_Adjuntar_Archivo.Checked
        End If

    End Sub

    Private Sub Chk_Adjuntar_Archivo_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs) Handles Chk_Adjuntar_Archivo.CheckedChanged

    End Sub

    Private Sub Btn_Mnu_Quitar_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Quitar_Correo.Click

        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Where Id = " & _Id

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            _Fila.Cells("Id").Value = 0
            _Fila.Cells("Id_Correo").Value = 0
            _Fila.Cells("Nombre_Correo").Value = String.Empty
            _Fila.Cells("Adjuntar_Documentos").Value = False

        End If

    End Sub

    Private Sub Btn_Correos_Click(sender As Object, e As EventArgs) Handles Btn_Correos.Click

        If Fx_Tiene_Permiso(Me, "Mail0001") Then

            Dim Fm As New Frm_Correos_SMTP
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Tipo_Venta_Click(sender As Object, e As EventArgs)

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Despachos_Tipo_Venta,
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Tipos de venta/traslado (Sis. Despacho)"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Tipo_Venta(Cmb_Tipo_Venta.SelectedValue)

    End Sub

    Private Sub Frm_Despacho_Configuracion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Conf_Imp_Letrero_Click(sender As Object, e As EventArgs) Handles Btn_Conf_Imp_Letrero.Click

        Dim Fm As New Frm_Barras_ConfPuerto_OD
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Chk_Enviar_al_otro_dia_Click(sender As Object, e As EventArgs) Handles Chk_Enviar_al_otro_dia.Click

        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Enviar_al_otro_dia = Convert.ToInt32(Chk_Enviar_al_otro_dia.Checked)

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Set Enviar_al_otro_dia = " & _Enviar_al_otro_dia & "
                        Where Id= " & _Id

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            _Fila.Cells("Adjuntar_Documentos").Value = Chk_Adjuntar_Archivo.Checked
        End If

    End Sub

    Private Sub Grilla_Correos_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla_Correos.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Call Grilla_Correos_CellDoubleClick(Nothing, Nothing)

                End If
            End With
        End If
    End Sub

    Sub Sb_Buscar_Formato(sender As Object, e As EventArgs)

        Dim _Boton = CType(sender, ButtonItem)
        Dim _Tido As String = _Boton.Tag
        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)
        Dim _Id = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Seleccionar_Formato(_Tido)

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)

            If Fm.Formato_Seleccionado Then

                If MessageBoxEx.Show(Me, "¿Confirma quitar el formato para " & _Tido & "?", "Quitar formato",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return
                End If

            End If

            Dim _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Set Format_" & _Tido & " = '" & _NombreFormato & "'
                            Where Id= " & _Id
            _Sql.Ej_consulta_IDU(Consulta_Sql)

            _Fila.Cells("Format_" & _Tido).Value = _NombreFormato
            _Boton.Text = "Formato " & _Tido & ": " & _NombreFormato
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Grabar_Configuracion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Configuracion.Click

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Configuracion Where Empresa = '" & ModEmpresa & "'" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Despachos_Configuracion (Empresa,Pedir_Sucursal_Retiro,Tipo_Venta_X_Defecto," &
                       "Transportista_X_Defecto,Transpor_Por_Pagar,Valor_Min_Despacho,Mostrar_RetiraTransportista,Mostrar_Agencia,ConfirmarLecturaDespacho) Values " &
                       "('" & ModEmpresa & "'" &
                       "," & Convert.ToInt32(Chk_Pedir_Sucursal_Retiro.Checked) &
                       ",'" & Txt_Tipo_Venta.Tag & "'" &
                       ",'" & Txt_Transportista.Tag &
                       "'," & Convert.ToInt32(Chk_Transpor_Por_Pagar.Checked) &
                       "," & De_Txt_a_Num_01(Txt_Valor_Min_Despacho.Tag, 5) &
                       "," & Convert.ToInt32(Chk_Mostrar_RetiraTransportista.Checked) &
                       "," & Convert.ToInt32(Chk_Mostrar_Agencia.Checked) &
                       "," & Convert.ToInt32(Chk_ConfirmarLecturaDespacho.Checked) & ")"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

            Dim _Cl As New Clas_Despacho(True)

            MessageBoxEx.Show(Me, "Datos de configuración actualizados correctamente", "Grabar configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Buscar_Tipo_Venta_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Tipo_Venta_x_Defecto.Click
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPO DE VENTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And Tabla = 'SIS_DESPACHO_TIPO_VENTA'",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Tipo_Venta.Tag = _Codigo
            Txt_Tipo_Venta.Text = _Descripcion

        End If
    End Sub

    Private Sub Btn_Buscar_Transportista_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Transportista_x_Defecto.Click

        Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Transportistas", "")

        If Not _Reg Then
            MessageBoxEx.Show(Me, "No existen transportistas asignados" & vbCrLf & vbCrLf &
                              "Los tranportistas seran asociados desde la tabla TABRETI hacia Bakapp" & vbCrLf &
                              "Debe hacer esa asociación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And KORETI In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas)",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Koreti = _Row.Item("Codigo").ToString.Trim
            Dim _Noreti = _Row.Item("Descripcion").ToString.Trim

            Txt_Transportista.Tag = _Koreti
            Txt_Transportista.Text = _Noreti

        End If

    End Sub

    Private Sub Btn_Transportistas_Click(sender As Object, e As EventArgs) Handles Btn_Mant_Transportistas.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                               Nothing, False, True,, True) Then
        End If

        Sb_Contar_Transportistas()

    End Sub

    Private Sub Tabs_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles Tabs.SelectedTabChanged
        Btn_Grabar_Configuracion.Enabled = (Tabs.SelectedTabIndex = 0)
    End Sub

    Private Sub Btn_Mant_Tipo_Venta_Click(sender As Object, e As EventArgs) Handles Btn_Mant_Tipo_Venta.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Despachos_Tipo_Venta,
                                          Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Tipos de venta/traslado (Sis. Despacho)"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Tipo_Venta(Cmb_Tipo_Venta.SelectedValue)

    End Sub

    Sub Sb_Ver_Transportistas(_Asociados As Boolean)

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Transportistas", "Mostrar = " & Convert.ToInt32(_Asociados)))

        If Not _Reg Then
            MessageBoxEx.Show(Me, "No hay datos que mostrar", "Transportistas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               " And KORETI In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas " &
                               "Where Mostrar = " & Convert.ToInt32(_Asociados) & ")",
                               Nothing, False, True,, Not _Asociados) Then
        End If

        Sb_Contar_Transportistas()

    End Sub

    Private Sub Btn_Transportistas_Asociados_Click(sender As Object, e As EventArgs) Handles Btn_Transportistas_Asociados.Click
        Sb_Ver_Transportistas(True)
    End Sub

    Private Sub Btn_Transportistas_Sin_Asociar_Click(sender As Object, e As EventArgs) Handles Btn_Transportistas_Sin_Asociar.Click
        Sb_Ver_Transportistas(False)
    End Sub

    Sub Sb_Contar_Transportistas()

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Transportistas Where CodTransportista Not In (Select KORETI From TABRETI)" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Despachos_Transportistas (CodTransportista,Mostrar,Cant_Minima)" & vbCrLf &
                       "Select KORETI,0,0 From TABRETI Where KORETI Not In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas)"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        Dim _Asociados = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Transportistas", "Mostrar = 1")
        Dim _NoAsociados = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Transportistas", "Mostrar = 0")

        Btn_Transportistas_Asociados.Text = "Asociados (" & _Asociados & ")"
        Btn_Transportistas_Sin_Asociar.Text = "Sin asociar (" & _NoAsociados & ")"

    End Sub

    Private Sub Txt_Valor_Min_Despacho_Validated(sender As Object, e As EventArgs) Handles Txt_Valor_Min_Despacho.Validated
        Txt_Valor_Min_Despacho.Tag = Txt_Valor_Min_Despacho.Text
        Txt_Valor_Min_Despacho.Text = FormatNumber(Txt_Valor_Min_Despacho.Tag, 0)
    End Sub

    Private Sub Txt_Valor_Min_Despacho_Enter(sender As Object, e As EventArgs) Handles Txt_Valor_Min_Despacho.Enter
        Txt_Valor_Min_Despacho.Text = Txt_Valor_Min_Despacho.Tag
    End Sub

    Private Sub Btn_Conf_Chilexpress_Click(sender As Object, e As EventArgs) Handles Btn_Conf_Chilexpress.Click


        Dim Chk_Chilexpress_Real As New Command
        Chk_Chilexpress_Real.Checked = False
        Chk_Chilexpress_Real.Name = "Chk_Chilexpress_Real"
        Chk_Chilexpress_Real.Text = "Configuración Real"

        Dim Chk_Chilexpress_Test As New Command
        Chk_Chilexpress_Test.Checked = False
        Chk_Chilexpress_Test.Name = "Chk_Chilexpress_Test"
        Chk_Chilexpress_Test.Text = "Configuración de pruebas (Test)"

        Dim _Opciones() As Command

        _Opciones = {Chk_Chilexpress_Real, Chk_Chilexpress_Test}

        Dim _Icono As New eTaskDialogIcon

        Dim _Info As New TaskDialogInfo("Configuración Chilexpress",
                                        eTaskDialogIcon.BlueFlag,
                                        "Selección de tipo de configuración",
                                        "Marque su opción",
                                        eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                                        , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado <> eTaskDialogResult.Ok Then
            Return
        End If

        If Not Chk_Chilexpress_Test.Checked And Not Chk_Chilexpress_Real.Checked Then
            MessageBoxEx.Show(Me, "Debe seleccionar una opción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Chilexpress_Conf(Chk_Chilexpress_Test.Checked)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
