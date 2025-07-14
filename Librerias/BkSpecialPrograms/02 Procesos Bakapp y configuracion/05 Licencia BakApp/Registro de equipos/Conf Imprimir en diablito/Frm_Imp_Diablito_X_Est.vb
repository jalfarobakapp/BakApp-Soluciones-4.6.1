Imports DevComponents.DotNetBar

Public Class Frm_Imp_Diablito_X_Est

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CodFuncionario As String
    Dim _Desde_Documento As Boolean
    Dim _Funcionario_Autorizado As String
    Dim _Copia_Otros_Usuarios As Boolean

    Dim _Editar_Configuraciones As Boolean
    Public Property Tido As String
        Get
            Return Cmb_Tido.SelectedValue
        End Get
        Set(value As String)
            Cmb_Tido.SelectedValue = value
        End Set
    End Property

    Public Property Funcionario_Autorizado As String
        Get
            Return _Funcionario_Autorizado
        End Get
        Set(value As String)
            _Funcionario_Autorizado = value
        End Set
    End Property

    Public Property Copia_Otros_Usuarios As Boolean
        Get
            Return _Copia_Otros_Usuarios
        End Get
        Set(value As Boolean)
            _Copia_Otros_Usuarios = value
        End Set
    End Property

    Public Property Editar_Configuraciones As Boolean
        Get
            Return _Editar_Configuraciones
        End Get
        Set(value As Boolean)
            _Editar_Configuraciones = value
        End Set
    End Property

    Public Sub New(_CodFuncionario As String, _Desde_Documento As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodFuncionario = _CodFuncionario
        Me._Desde_Documento = _Desde_Documento
        Me._Funcionario_Autorizado = _CodFuncionario

        Txt_Funcionario.Tag = _CodFuncionario
        Txt_Funcionario.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _CodFuncionario & "'")

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

        Consulta_sql = "SELECT '000' As Padre,'Mostrar todas...' as Hijo" & vbCrLf & "Union" & vbCrLf &
                       "SELECT TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo FROM TABTIDO ORDER BY Padre"
        caract_combo(Cmb_Tido)

        Cmb_Tido.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Tido.SelectedValue = "000"

    End Sub

    Private Sub Frm_Imp_Diablito_X_Est_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select Top 1 * From TABFU Where KOFU = '" & _CodFuncionario & "'"
        Dim _Row_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me.Text = "Funcionario: " & _CodFuncionario & " - " & _Row_Funcionario.Item("NOKOFU")

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Cmb_Tido.SelectedIndexChanged, AddressOf Cmb_Tido_SelectedIndexChanged

        Btn_Usar_Configuracion.Enabled = Not _Desde_Documento

        If Global_Thema = Enum_Themas.Oscuro Then
            Refle1.Image = Imagenes_32x32.Images.Item(2) ' computador
            Refle2.Image = Imagenes_32x32.Images.Item(4) ' Flecha
            Refle3.Image = Imagenes_32x32.Images.Item(3) ' Emoji
        End If

        Sb_Editar_Configuraciones()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion_Tido = String.Empty
        Dim _Condicion_Modalidad = String.Empty

        If Cmb_Tido.SelectedValue <> "000" Then
            _Condicion_Tido = "And Tido = '" & Cmb_Tido.SelectedValue & "' And SubTido = '" & Txt_SubTido.Tag & "'"
        End If

        Consulta_sql = "Select Cast(0 As Bit) As Chk, EImp.*,
		                Case When EImp.Imprimir_Voucher_TJV_No_Imprimir = 1 Then 'NO' 
		                Else 
			                Case When EImp.Imprimir_Voucher_TJV = 1 Then 'Voucher TJV Bakapp' 
			                Else 
				                Case When EImp.Imprimir_Voucher_TJV_No_Imprimir = 1 then 'Voucher original (Transbank)'
				                Else 'NO'
				                End
			                End
                        End As 'Voucher',
                        Case When Imp_Todas_Modalidades = 1 Then 'Todas' Else Modalidad End As Lbl_Modalidad,
		                Rtrim(Ltrim(EImp.Tido))+' - '+Isnull(Tt.NOTIDO,'Formato desconocido!!!') As Lbl_Tido,
		                Case When EImp.Activo = 1 Then 'SI' Else 'NO' End As Lbl_Activo,
		                Rtrim(LTrim(Isnull(Tt.NOTIDO,'Formato desconocido!!!'))) As Notido,
                        Case When Zes.Alias = '' Then Zes.NombreEquipo Else Zes.Alias End As Alias
                        From " & _Global_BaseBk & "Zw_Usuarios_Impresion EImp
                        Left Join TABTIDO Tt On Tt.TIDO = EImp.Tido
                        Left Join " & _Global_BaseBk & "Zw_EstacionesBkp Zes On Zes.NombreEquipo = EImp.NombreEquipo_Imprime
                        Where EImp.CodFuncionario = '" & _CodFuncionario & "' And EImp.Empresa = '" & Mod_Empresa & "'" & vbCrLf &
                        _Condicion_Modalidad & vbCrLf &
                        _Condicion_Tido & vbCrLf &
                        "Order By Alias,Tido,SubTido,Tipo"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        'CodFuncionario, Empresa, Modalidad, Tido, Tipo, NombreEquipo_Imprime, NombreFormato, Nro_Copias


        With Grilla

            .DataSource = _Ds
            .DataMember = "table"

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = True
            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").DisplayIndex = _DisplayIndex
            .Columns("Chk").ReadOnly = False
            _DisplayIndex += 1

            .Columns("Empresa").Visible = True
            .Columns("Empresa").Width = 30
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            .Columns("Empresa").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Alias").Visible = True
            .Columns("Alias").Width = 140
            .Columns("Alias").HeaderText = "Equipo que imprime"
            .Columns("Alias").DisplayIndex = _DisplayIndex
            .Columns("Alias").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Lbl_Modalidad").Visible = True
            .Columns("Lbl_Modalidad").Width = 50
            .Columns("Lbl_Modalidad").HeaderText = "Mod."
            .Columns("Lbl_Modalidad").ToolTipText = "Modalidad(es) en la cuale(s) se aplicara el envio a imprimir"
            .Columns("Lbl_Modalidad").DisplayIndex = _DisplayIndex
            .Columns("Lbl_Modalidad").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Tido").Visible = True
            .Columns("Tido").Width = 40
            .Columns("Tido").HeaderText = "Tido"
            .Columns("Tido").DisplayIndex = _DisplayIndex
            .Columns("Tido").ReadOnly = True
            _DisplayIndex += 1

            .Columns("SubTido").Visible = True
            .Columns("SubTido").Width = 40
            .Columns("SubTido").HeaderText = "SubT"
            .Columns("SubTido").DisplayIndex = _DisplayIndex
            .Columns("SubTido").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Notido").Visible = True
            .Columns("Notido").Width = 130
            .Columns("Notido").HeaderText = "Documento"
            .Columns("Notido").DisplayIndex = _DisplayIndex
            .Columns("Notido").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").Width = 60
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            .Columns("Tipo").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Sucursal_Picking").Visible = True
            .Columns("Sucursal_Picking").Width = 60
            .Columns("Sucursal_Picking").HeaderText = "Suc.P"
            .Columns("Sucursal_Picking").DisplayIndex = _DisplayIndex
            .Columns("Sucursal_Picking").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Bodega_Picking").Visible = True
            .Columns("Bodega_Picking").Width = 60
            .Columns("Bodega_Picking").HeaderText = "Bob.P"
            .Columns("Bodega_Picking").DisplayIndex = _DisplayIndex
            .Columns("Bodega_Picking").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Nro_Copias").Visible = True
            .Columns("Nro_Copias").Width = 45
            .Columns("Nro_Copias").HeaderText = "copias"
            .Columns("Nro_Copias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_Copias").DisplayIndex = _DisplayIndex
            .Columns("Nro_Copias").ReadOnly = True
            _DisplayIndex += 1

        End With

        Lbl_Modalidad.DataBindings.Clear()
        Lbl_Tido.DataBindings.Clear()
        Lbl_SubTido.DataBindings.Clear()
        Lbl_NombreFormato.DataBindings.Clear()
        LabelX14.DataBindings.Clear()
        Lbl_NombreEquipo_Imprime.DataBindings.Clear()
        Lbl_Impresora.DataBindings.Clear()
        Lbl_Copias.DataBindings.Clear()
        Lbl_Impr_Voucher_TJV.DataBindings.Clear()
        Lbl_Activo.DataBindings.Clear()

        Lbl_Modalidad.DataBindings.Add("text", _Ds, "table.Lbl_Modalidad")
        Lbl_Tido.DataBindings.Add("text", _Ds, "table.Lbl_Tido")
        Lbl_SubTido.DataBindings.Add("text", _Ds, "table.SubTido")
        Lbl_NombreFormato.DataBindings.Add("text", _Ds, "table.NombreFormato")
        LabelX14.DataBindings.Add("text", _Ds, "table.Tipo")
        Lbl_NombreEquipo_Imprime.DataBindings.Add("text", _Ds, "table.Alias")
        Lbl_Impresora.DataBindings.Add("text", _Ds, "table.Impresora")
        Lbl_Copias.DataBindings.Add("text", _Ds, "table.Nro_Copias")
        Lbl_Impr_Voucher_TJV.DataBindings.Add("text", _Ds, "table.Voucher")
        Lbl_Activo.DataBindings.Add("text", _Ds, "table.Lbl_Activo")

    End Sub

    Private Sub Btn_Crear_Click(sender As Object, e As EventArgs) Handles Btn_Crear.Click

        If Not Fx_Tiene_Permiso(Me, "Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Dim Fm As New Frm_Imp_Diablito_X_Est_Crear(Txt_Funcionario.Tag)
        If Not String.IsNullOrEmpty(Tido) And Tido <> "000" Then
            Fm.Txt_Tido.Tag = Cmb_Tido.SelectedValue
            Fm.Txt_Tido.Text = Cmb_Tido.Text
            Fm.Btn_Buscar_Tido.Enabled = False
        End If
        Fm.ShowDialog(Me)
        If Fm.Grabar Then Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Try
            Me.Enabled = False
            If Not Fx_Tiene_Permiso(Me, "Doc00057", _Funcionario_Autorizado) Then
                Return
            End If

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Id = _Fila.Cells("Id").Value

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Usuarios_Impresion Where Id = " & _Id
            Dim _Row_Impresion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim Fm As New Frm_Imp_Diablito_X_Est_Crear(_Row_Impresion.Item("CodFuncionario"))
            Fm.Row_Impresion = _Row_Impresion
            Fm.ShowDialog(Me)
            If Fm.Grabar Then Sb_Actualizar_Grilla()
            Fm.Dispose()

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Debe seleccionar un registro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Call Btn_Editar_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_Usar_Configuracion_Click(sender As Object, e As EventArgs) Handles Btn_Usar_Configuracion.Click

        If Not Fx_Tiene_Permiso(Me, "Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _CodFuncioanrio = Txt_Funcionario.Tag
            Dim _Tido = _Fila.Cells("Tido").Value
            Dim _Notido = _Fila.Cells("Notido").Value
            Dim _SubTido = _Fila.Cells("SubTido").Value
            Dim _Tipo = _Fila.Cells("Tipo").Value
            Dim _Modalidad = _Fila.Cells("Modalidad").Value
            Dim _NombreEquipo_Imprime = _Fila.Cells("NombreEquipo_Imprime").Value
            Dim _Alias = _Fila.Cells("Alias").Value
            Dim _NombreFormato = _Fila.Cells("NombreFormato").Value
            Dim _Nro_Copias = _Fila.Cells("Nro_Copias").Value
            Dim _Impresora = _Fila.Cells("Impresora").Value

            Dim _Imprimir_Voucher_TJV_No_Imprimir = _Fila.Cells("Imprimir_Voucher_TJV_No_Imprimir").Value
            Dim _Imprimir_Voucher_TJV = _Fila.Cells("Imprimir_Voucher_TJV").Value
            Dim _Imprimir_Voucher_TJV_Original = _Fila.Cells("Imprimir_Voucher_TJV_Original").Value

            Dim _Imp_Todas_Modalidades = _Fila.Cells("Imp_Todas_Modalidades").Value


            Dim Fm As New Frm_Imp_Diablito_X_Est_Crear(_CodFuncionario)
            Fm.Txt_Tido.Tag = _Tido
            Fm.Txt_Tido.Text = _Notido
            Fm.Txt_SubTido.Text = _SubTido
            Fm.Txt_Modalidad.Tag = _Modalidad
            Fm.Txt_Modalidad.Text = _Modalidad
            Fm.Txt_NombreEquipo_Imprime.Tag = _NombreEquipo_Imprime
            Fm.Txt_NombreEquipo_Imprime.Text = _Alias
            Fm.Txt_Impresora.Text = _Impresora
            Fm.Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked = _Imprimir_Voucher_TJV_No_Imprimir
            Fm.Rdb_Imprimir_Voucher_TJV.Checked = _Imprimir_Voucher_TJV
            Fm.Rdb_Imprimir_Voucher_TJV_Original_Transbak.Checked = _Imprimir_Voucher_TJV_Original
            Fm.Sw_Imp_Todas_Modalidades.Value = _Imp_Todas_Modalidades
            Fm.Cmb_Tipo.SelectedValue = _Tipo
            Fm.ShowDialog(Me)
            If Fm.Grabar Then Sb_Actualizar_Grilla()
            Fm.Dispose()

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Debe seleccionar un registro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With Grilla

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

                    ShowContextMenu(Menu_Contextual_01)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Buscar_Modalidad_Click(sender As Object, e As EventArgs)

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        Dim _Sql = "And MODALIDAD In (Select SUBSTRING(KOOP,4,5) As Modalidad From MAEUS Where KOUS = '" & _CodFuncionario & "' And KOOP Like 'MO-%')"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And EMPRESA = '" & Mod_Empresa & "' " & _Sql,
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Txt_SubTido_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_SubTido.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Cmb_Tido_SelectedIndexChanged(sender As Object, e As EventArgs)
        Txt_SubTido.Text = String.Empty
        Me.Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

    End Sub

    Private Sub Btn_Copiar_Otros_Click(sender As Object, e As EventArgs) Handles Btn_Copiar_Otros.Click

        If Not Fx_Tiene_Permiso(Me, "Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        If Not Fx_Rev_Tickeados() Then Return

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
        Fm.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0 And KOFU <> '" & _CodFuncionario & "'"
        Fm.Text = "SELECCIONE USUARIOS"
        Fm.ShowDialog(Me)
        Dim _Tbl_Funcionarios_Seleccionados As DataTable = Fm.Pro_Tbl_Filtro
        Fm.Dispose()

        If _Tbl_Funcionarios_Seleccionados.Rows.Count = 0 Then
            MessageBoxEx.Show(Me, "No se selecciono ningún funcionario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "Las configuraciones en los usuarios de destino se reemplazaran por estas" & vbCrLf & vbCrLf &
                             "¿Confirma su decisión?" & vbCrLf & vbCrLf,
                             "Copiar configuración", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Contador = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Fila.Cells("Chk").Value Then

                For Each _FilaUs As DataRow In _Tbl_Funcionarios_Seleccionados.Rows

                    If _FilaUs.Item("Chk") Then

                        Dim _Id = _Fila.Cells("Id").Value
                        Dim _CodFuncionario_Destino = _FilaUs.Item("Codigo")

                        If String.IsNullOrEmpty(Fx_Replicar_Otro_Usuario(_CodFuncionario_Destino, _Id)) Then
                            _Contador += 1
                        End If

                    End If

                Next

            End If

        Next

        If CBool(_Contador) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente a otros usuarios",
                              "Copiar configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Copia_Otros_Usuarios = True
            Me.Close()
        End If

    End Sub

    Private Function Fx_Replicar_Otro_Usuario(_CodFuncionario_Destino As String, _Id As Integer) As String

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Usuarios_Impresion Where Id = " & _Id
        Dim _Row_Configuracion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Configuracion) Then
            Return "No existe configuración con Id " & _Id
        End If

        Dim _Empresa As String = _Row_Configuracion.Item("Empresa")
        Dim _Modalidad As String = _Row_Configuracion.Item("Modalidad")
        Dim _Tido As String = _Row_Configuracion.Item("Tido")
        Dim _Tipo As String = _Row_Configuracion.Item("Tipo")
        Dim _NombreEquipo_Imprime As String = _Row_Configuracion.Item("NombreEquipo_Imprime")
        Dim _NombreFormato As String = _Row_Configuracion.Item("NombreFormato")
        Dim _Impresora As String = _Row_Configuracion.Item("Impresora")
        Dim _Nro_Copias As Integer = _Row_Configuracion.Item("Nro_Copias")
        Dim _Activo As Integer = Convert.ToInt32(_Row_Configuracion.Item("Activo"))
        Dim _Imprimir_Voucher_TJV_No_Imprimir = Convert.ToInt32(_Row_Configuracion.Item("Imprimir_Voucher_TJV_No_Imprimir"))
        Dim _Imprimir_Voucher_TJV = Convert.ToInt32(_Row_Configuracion.Item("Imprimir_Voucher_TJV"))
        Dim _Imprimir_Voucher_TJV_Original = Convert.ToInt32(_Row_Configuracion.Item("Imprimir_Voucher_TJV_Original"))
        Dim _Imp_Todas_Modalidades = Convert.ToInt32(_Row_Configuracion.Item("Imp_Todas_Modalidades"))
        Dim _Sucursal_Picking As String = _Row_Configuracion.Item("Sucursal_Picking")
        Dim _Bodega_Picking As String = _Row_Configuracion.Item("Bodega_Picking")

        If _Imprimir_Voucher_TJV = 0 And _Imprimir_Voucher_TJV_Original = 0 Then
            _Imprimir_Voucher_TJV_No_Imprimir = 1
        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Usuarios_Impresion",
                                                "CodFuncionario = '" & _CodFuncionario_Destino & "' And " &
                                                "Empresa = '" & Mod_Empresa & "' And " &
                                                "Modalidad = '" & _Modalidad & "' And " &
                                                "Tido = '" & _Tido & "' And " &
                                                "Tipo = '" & _Tipo & "' And " &
                                                "NombreEquipo_Imprime = '" & _NombreEquipo_Imprime & "' And " &
                                                "NombreFormato = '" & _NombreFormato & "' And " &
                                                "Impresora = '" & _Impresora & "'")

        If CBool(_Reg) Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_Impresion " & vbCrLf &
                            "Where CodFuncionario = '" & _CodFuncionario_Destino & "' And " &
                            "Empresa = '" & Mod_Empresa & "' And " &
                            "Modalidad = '" & _Modalidad & "' And " &
                            "Tido = '" & _Tido & "' And " &
                            "Tipo = '" & _Tipo & "' And " &
                            "NombreEquipo_Imprime = '" & _NombreEquipo_Imprime & "' And " &
                            "NombreFormato = '" & _NombreFormato & "' And " &
                            "Impresora = '" & _Impresora & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Usuarios_Impresion (CodFuncionario,Empresa,Modalidad,Tido,Tipo,NombreEquipo_Imprime," &
                           "NombreFormato,Impresora,Nro_Copias,Activo,Imprimir_Voucher_TJV_No_Imprimir,Imprimir_Voucher_TJV," &
                           "Imprimir_Voucher_TJV_Original,Imp_Todas_Modalidades,Sucursal_Picking,Bodega_Picking) Values " &
                           "('" & _CodFuncionario_Destino & "','" & Mod_Empresa & "','" & _Modalidad & "','" & _Tido & "','" & _Tipo &
                           "','" & _NombreEquipo_Imprime & "','" & _NombreFormato & "','" & _Impresora & "'," & _Nro_Copias & "," & _Activo &
                           "," & _Imprimir_Voucher_TJV_No_Imprimir & "," & _Imprimir_Voucher_TJV &
                           "," & _Imprimir_Voucher_TJV_Original & "," & _Imp_Todas_Modalidades & ",'" & _Sucursal_Picking & "','" & _Bodega_Picking & "')"

        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Return _Sql.Pro_Error

    End Function

    Private Function Fx_Rev_Tickeados() As Boolean

        Dim _Tickeados = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows
            If _Fila.Cells("Chk").Value Then _Tickeados += 1
        Next

        If _Tickeados = 0 Then
            MessageBoxEx.Show(Me, "No hay datos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True

    End Function

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        If Not Fx_Rev_Tickeados() Then Return

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar esta(s) configuración(es)?", "Eliminar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = String.Empty

            For Each _Fila As DataGridViewRow In Grilla.Rows
                If _Fila.Cells("Chk").Value Then
                    Dim _Id = _Fila.Cells("Id").Value
                    Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Usuarios_Impresion Where Id = " & _Id & vbCrLf
                End If
            Next

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Me.Sb_Actualizar_Grilla()
                MessageBoxEx.Show(Me, "Configuracion(es) eliminada(s) correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub Btn_Editar_Configuracion_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Configuracion.Click

        Dim _Row_Usuario_Autoriza As DataRow

        If Not Fx_Tiene_Permiso(Me, "Doc00057", _Funcionario_Autorizado,,,,,,,, _Row_Usuario_Autoriza) Then
            Return
        End If

        _Funcionario_Autorizado = _Row_Usuario_Autoriza.Item("KOFU")
        _Editar_Configuraciones = True

        Sb_Editar_Configuraciones()

    End Sub

    Sub Sb_Editar_Configuraciones()

        Btn_Copiar_Otros.Enabled = _Editar_Configuraciones
        Btn_Crear.Enabled = _Editar_Configuraciones
        Btn_Crear.Enabled = _Editar_Configuraciones
        Btn_Eliminar.Enabled = _Editar_Configuraciones
        Btn_Copiar_Otros.Enabled = _Editar_Configuraciones
        Btn_Editar.Enabled = _Editar_Configuraciones
        Btn_Usar_Configuracion.Enabled = _Editar_Configuraciones
        Btn_Editar_Configuracion.Visible = Not _Editar_Configuraciones

    End Sub


End Class
