Imports DevComponents.DotNetBar

Public Class Frm_Imp_Diablito_X_Est_Crear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Grabar As Boolean

    Dim _CodFuncionario As String
    Dim _Row_Impresion As DataRow

    Dim _Sucursal_Picking As String
    Dim _Bodega_Picking As String
    Dim _Row_Bodega_Picking As DataRow

    Public Property Row_Impresion As DataRow
        Get
            Return _Row_Impresion
        End Get
        Set(value As DataRow)
            _Row_Impresion = value
        End Set
    End Property

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Sucursal_Picking As String
        Get
            Return _Sucursal_Picking
        End Get
        Set(value As String)
            _Sucursal_Picking = value
        End Set
    End Property

    Public Property Bodega_Picking As String
        Get
            Return _Bodega_Picking
        End Get
        Set(value As String)
            _Bodega_Picking = value
        End Set
    End Property

    Public Sub New(_CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodFuncionario = _CodFuncionario

        Dim _Arr_Tipo(,) As String = {{"", ""},
                                      {"Normal", "Impresión Normal"},
                                      {"Vale_Transitorio", "Vale Transitorio"},
                                      {"Picking", "Picking"}}
        Sb_Llenar_Combos(_Arr_Tipo, Cmb_Tipo)
        Cmb_Tipo.SelectedValue = ""

        Btn_Eliminar.Visible = False

    End Sub

    Private Sub Frm_Imp_Diablito_X_Est_Crear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Sucursal_Picking = Mod_Sucursal
        _Bodega_Picking = Mod_Bodega

        If Not IsNothing(_Row_Impresion) Then

            With _Row_Impresion

                Txt_Modalidad.Tag = .Item("Modalidad")
                Txt_Tido.Tag = .Item("Tido")
                Txt_SubTido.Tag = .Item("SubTido")
                Cmb_Tipo.SelectedValue = .Item("Tipo")
                Txt_NombreEquipo_Imprime.Tag = .Item("NombreEquipo_Imprime")
                Txt_NombreFormato.Tag = .Item("NombreFormato")
                Input_Nro_Copias.Value = .Item("Nro_Copias")
                Sw_Activo.Value = .Item("Activo")

                Txt_Modalidad.Text = .Item("Modalidad")
                Txt_Tido.Text = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & .Item("Tido") & "'")
                Txt_SubTido.Text = .Item("SubTido")
                Txt_Impresora.Text = .Item("Impresora")

                Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked = .Item("Imprimir_Voucher_TJV_No_Imprimir")
                Rdb_Imprimir_Voucher_TJV.Checked = .Item("Imprimir_Voucher_TJV")
                Rdb_Imprimir_Voucher_TJV_Original_Transbak.Checked = .Item("Imprimir_Voucher_TJV_Original")

                Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked = (Not Rdb_Imprimir_Voucher_TJV.Checked And Not Rdb_Imprimir_Voucher_TJV_Original_Transbak.Checked)

                Txt_NombreEquipo_Imprime.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_EstacionesBkp",
                                                 "Case Alias When '' Then NombreEquipo Else Alias End",
                                                 "NombreEquipo = '" & .Item("NombreEquipo_Imprime") & "'")
                Txt_NombreFormato.Text = .Item("NombreFormato")

                Sw_Imp_Todas_Modalidades.Value = .Item("Imp_Todas_Modalidades")

                _Sucursal_Picking = .Item("Sucursal_Picking")
                _Bodega_Picking = .Item("Bodega_Picking")

                Consulta_sql = "Select * From TABBO Where EMPRESA = '" & Mod_Empresa & "' And KOSU = '" & _Sucursal_Picking & "' And KOBO = '" & _Bodega_Picking & "'"
                _Row_Bodega_Picking = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Bodega_Picking) Then
                    Txt_Bodega_Picking.Text = "Suc: " & _Sucursal_Picking & ", Bod: " & _Bodega_Picking & "-" & _Row_Bodega_Picking.Item("NOKOBO").ToString.Trim
                End If

            End With

            Btn_Eliminar.Visible = True

        End If

        Sb_Habilitar_Voucher()

        Btn_Buscar_Modalidad.Visible = Not Sw_Imp_Todas_Modalidades.Value
        Txt_Modalidad.Visible = Not Sw_Imp_Todas_Modalidades.Value

        AddHandler Cmb_Tipo.SelectedIndexChanged, AddressOf Sb_Habilitar_Voucher
        AddHandler Cmb_Tipo.SelectedIndexChanged, AddressOf Cmb_Tipo_SelectedIndexChanged

        Lbl_Bodega_Picking.Enabled = (Cmb_Tipo.SelectedValue = "Picking")
        Txt_Bodega_Picking.Enabled = (Cmb_Tipo.SelectedValue = "Picking")
        Btn_Buscar_Bodega.Enabled = (Cmb_Tipo.SelectedValue = "Picking")

    End Sub

    Private Sub Btn_Buscar_Modalidad_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Modalidad.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        Dim _Caja_Habilitada As Boolean = _Global_Row_EstacionBk.Item("Caja_Habilitada")
        Dim _Modalidad_Caja As String = _Global_Row_EstacionBk.Item("Modalidad_Caja")

        Dim _Sql = "And MODALIDAD In (Select SUBSTRING(KOOP,4,5) As Modalidad From MAEUS Where KOUS = '" & _CodFuncionario & "' And KOOP Like 'MO-%')"

        If _Caja_Habilitada Then
            _Sql += vbCrLf & "Or MODALIDAD = '" & _Modalidad_Caja & "'"
        End If

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

    Private Sub Btn_Buscar_Tido_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Tido.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIDO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Documentos, "",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Tido.Tag = _Codigo
            Txt_Tido.Text = _Descripcion

            Sb_Habilitar_Voucher()

        End If

    End Sub

    Sub Sb_Habilitar_Voucher()

        If Cmb_Tipo.SelectedValue = "Normal" Then
            If Txt_Tido.Tag = "FCV" Or Txt_Tido.Tag = "BLV" Then
                Layaut_Voucher.Enabled = True
            Else
                Layaut_Voucher.Enabled = False
                Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked = True
            End If
        Else
            Layaut_Voucher.Enabled = False
            Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked = True
        End If

    End Sub

    Private Sub Btn_Buscar_Formato_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Formato.Click

        If String.IsNullOrEmpty(Txt_Tido.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar un tipo de documento (TIDO)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Seleccionar_Formato(Txt_Tido.Tag)

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)
            If Fm.Formato_Seleccionado Then
                Txt_NombreFormato.Tag = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                Txt_NombreFormato.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            End If
            Fm.Dispose()

        Else

            MessageBoxEx.Show(Me, "No existen formtados de impresión para el documento " & Txt_Modalidad.Tag & "-" & Txt_Modalidad.Text,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_NombreEquipo_Imprime_Click(sender As Object, e As EventArgs) Handles Btn_NombreEquipo_Imprime.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "DESDE DONDE SE IMPRIMIRAN LOS DOCUMENTOS (Solo estaciones con Diablito)"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_EstacionesBkp"
        _Filtrar.Campo = "NombreEquipo"
        _Filtrar.Descripcion = "Alias"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo In (Select Distinct NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_Impresoras)",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_NombreEquipo_Imprime.Tag = _Codigo
            If String.IsNullOrEmpty(_Descripcion.ToString.Trim) Then
                Txt_NombreEquipo_Imprime.Text = _Codigo
            Else
                Txt_NombreEquipo_Imprime.Text = _Descripcion
            End If

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Modalidad As String = Txt_Modalidad.Tag
        Dim _Tido As String = Txt_Tido.Tag
        Dim _Tipo As String = Cmb_Tipo.SelectedValue
        Dim _NombreEquipo_Imprime As String = Txt_NombreEquipo_Imprime.Tag
        Dim _NombreFormato As String = Txt_NombreFormato.Tag
        Dim _Impresora As String = Txt_Impresora.Text
        Dim _Nro_Copias As Integer = Input_Nro_Copias.Value
        Dim _Activo As Integer = Convert.ToInt32(Sw_Activo.Value)

        Dim _Id As Integer

        If Not Sw_Imp_Todas_Modalidades.Value And String.IsNullOrEmpty(_Modalidad) Then
            MessageBoxEx.Show(Me, "Falta la modalidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_Tido) Then
            MessageBoxEx.Show(Me, "Falta el documento (Tido)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_NombreFormato) Then
            MessageBoxEx.Show(Me, "Falta el formato", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_Impresora) Then
            MessageBoxEx.Show(Me, "Falta el nombre de la impresora", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_Tipo) Then
            MessageBoxEx.Show(Me, "Falta el tipo de impresión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_NombreEquipo_Imprime) Then
            MessageBoxEx.Show(Me, "Falta el nombre del equipo que imprime", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If (Txt_Tido.Tag <> "FCV" And Txt_Tido.Tag <> "BLV") Or Cmb_Tipo.SelectedValue <> "Normal" Then
            Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked = True
        End If

        If Cmb_Tipo.SelectedValue = "Picking" And (String.IsNullOrEmpty(_Sucursal_Picking.Trim) Or String.IsNullOrEmpty(_Bodega_Picking.Trim)) Then
            MessageBoxEx.Show(Me, "Falta la bodega para el envio del picking", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Imprimir_Voucher_TJV_No_Imprimir = Convert.ToInt32(Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked)
        Dim _Imprimir_Voucher_TJV = Convert.ToInt32(Rdb_Imprimir_Voucher_TJV.Checked)
        Dim _Imprimir_Voucher_TJV_Original = Convert.ToInt32(Rdb_Imprimir_Voucher_TJV_Original_Transbak.Checked)

        Dim _Imp_Todas_Modalidades = Convert.ToInt32(Sw_Imp_Todas_Modalidades.Value)

        If Sw_Imp_Todas_Modalidades.Value Then
            _Modalidad = String.Empty
        End If

        If Cmb_Tipo.SelectedValue <> "Picking" Then
            _Sucursal_Picking = String.Empty
            _Bodega_Picking = String.Empty
        End If

        If IsNothing(_Row_Impresion) Then

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Usuarios_Impresion",
                                                "CodFuncionario = '" & _CodFuncionario & "' And " &
                                                "Empresa = '" & Mod_Empresa & "' And " &
                                                "Modalidad = '" & _Modalidad & "' And " &
                                                "Tido = '" & _Tido & "' And " &
                                                "Tipo = '" & _Tipo & "' And " &
                                                "NombreEquipo_Imprime = '" & _NombreEquipo_Imprime & "' And " &
                                                "NombreFormato = '" & _NombreFormato & "' And " &
                                                "Impresora = '" & _Impresora & "'")

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Esta cónfiguración ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Usuarios_Impresion (CodFuncionario,Empresa,Modalidad,Tido,Tipo,NombreEquipo_Imprime," &
                           "NombreFormato,Impresora,Nro_Copias,Activo,Imprimir_Voucher_TJV_No_Imprimir,Imprimir_Voucher_TJV," &
                           "Imprimir_Voucher_TJV_Original,Imp_Todas_Modalidades,Sucursal_Picking,Bodega_Picking) Values " &
                           "('" & _CodFuncionario & "','" & Mod_Empresa & "','" & _Modalidad & "','" & _Tido & "','" & _Tipo &
                           "','" & _NombreEquipo_Imprime & "','" & _NombreFormato & "','" & _Impresora & "'," & _Nro_Copias & "," & _Activo &
                           "," & _Imprimir_Voucher_TJV_No_Imprimir & "," & _Imprimir_Voucher_TJV &
                           "," & _Imprimir_Voucher_TJV_Original & "," & _Imp_Todas_Modalidades & ",'" & _Sucursal_Picking & "','" & _Bodega_Picking & "')"
            If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id) Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Usuarios_Impresion Where Id = " & _Id
                _Row_Impresion = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Grabar = True

            End If

        Else

            _Id = _Row_Impresion.Item("Id")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Usuarios_Impresion Set " & vbCrLf &
                           "Modalidad = '" & _Modalidad & "'," &
                           "Imp_Todas_Modalidades = '" & _Imp_Todas_Modalidades & "'," &
                           "Tido = '" & _Tido & "'," &
                           "Tipo = '" & _Tipo & "'," &
                           "NombreEquipo_Imprime = '" & _NombreEquipo_Imprime & "'," &
                           "NombreFormato = '" & _NombreFormato & "'," &
                           "Impresora = '" & _Impresora & "'," &
                           "Imprimir_Voucher_TJV_No_Imprimir = '" & _Imprimir_Voucher_TJV_No_Imprimir & "'," &
                           "Imprimir_Voucher_TJV = '" & _Imprimir_Voucher_TJV & "'," &
                           "Imprimir_Voucher_TJV_Original = '" & _Imprimir_Voucher_TJV_Original & "'," &
                           "Nro_Copias = " & _Nro_Copias & "," & vbCrLf &
                           "Activo = " & _Activo & "," & vbCrLf &
                           "Sucursal_Picking = '" & _Sucursal_Picking & "'," & vbCrLf &
                           "Bodega_Picking = '" & _Bodega_Picking & "'" & vbCrLf &
                           "Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Grabar = True
            End If

        End If

        If _Grabar Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Id = _Row_Impresion.Item("Id")

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar esta configuración?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_Impresion Where Id = " & _Id
            _Grabar = _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        If _Grabar Then

            MessageBoxEx.Show(Me, "Configuración eliminada correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Buscar_Impresora_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Impresora.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "IMPRESORAS DISPONIBLES"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Estaciones_Impresoras"
        _Filtrar.Campo = "Impresora"
        _Filtrar.Descripcion = "Impresora"
        _Filtrar.Ver_Codigo = False

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo = '" & Txt_NombreEquipo_Imprime.Tag & "'",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Impresora.Tag = _Codigo
            Txt_Impresora.Text = _Descripcion

        End If

    End Sub

    Private Sub Sw_Imp_Todas_Modalidades_ValueChanged(sender As Object, e As EventArgs) Handles Sw_Imp_Todas_Modalidades.ValueChanged
        Btn_Buscar_Modalidad.Visible = Not Sw_Imp_Todas_Modalidades.Value
        Txt_Modalidad.Visible = Not Sw_Imp_Todas_Modalidades.Value
    End Sub

    Private Sub Cmb_Tipo_SelectedIndexChanged(sender As Object, e As EventArgs)

        Lbl_Bodega_Picking.Enabled = (Cmb_Tipo.SelectedValue = "Picking")
        Txt_Bodega_Picking.Enabled = (Cmb_Tipo.SelectedValue = "Picking")
        Btn_Buscar_Bodega.Enabled = (Cmb_Tipo.SelectedValue = "Picking")

    End Sub

    Private Sub Btn_Buscar_Bodega_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Bodega.Click

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = Mod_Empresa
        Fm_b.Pro_Sucursal = _Sucursal_Picking
        Fm_b.Pro_Bodega = _Bodega_Picking
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Sucursal_Picking = Fm_b.Pro_RowBodega.Item("KOSU")
            _Bodega_Picking = Fm_b.Pro_RowBodega.Item("KOBO")

            Consulta_sql = "Select * From TABBO Where EMPRESA = '" & Mod_Empresa & "' And KOSU = '" & _Sucursal_Picking & "' And KOBO = '" & _Bodega_Picking & "'"
            _Row_Bodega_Picking = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Bodega_Picking.Text = "Suc: " & _Sucursal_Picking & ", Bod: " & _Bodega_Picking & "-" & _Row_Bodega_Picking.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

    End Sub

End Class
