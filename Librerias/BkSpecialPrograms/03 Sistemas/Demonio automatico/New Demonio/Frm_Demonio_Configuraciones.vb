Imports DevComponents.DotNetBar

Public Class Frm_Demonio_Configuraciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _NombreEquipo As String
    Dim _Id As Integer
    Dim _Row_ConfEstacion As DataRow

    Dim _Funcionario_Autorizado As String

    Dim EnvioCorreo_Prog As New Cl_NewProgramacion

    Public Property Grabar As Boolean

    Public Sub New(_Id As Integer, _Funcionario_Autorizado As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
        Me._Funcionario_Autorizado = _Funcionario_Autorizado
        Me._Id = _Id

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfXEstacion Where Id = " & _Id
        _Row_ConfEstacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla_AsistenteCompras, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_Demonio_Configuraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Chk_EnvioCorreo.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ColaImpDoc.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ColaImpPick.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_SolProdBod.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Prestashop_Prod.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Prestashop_Order.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Prestashop_Total.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ImporDTESII.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ArchivarDoc.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ConsStock.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Wordpress_Prod.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_Wordpress_Stock.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_CierreDoc.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_FacAuto.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_AsistenteCompras.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        'AddHandler Chk_EnvioCrreo.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged

        AddHandler Sp_EnvioCorreo.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ColaImpDoc.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ColaImpPick.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_SolProdBod.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Prestashop_Prod.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Prestashop_Order.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Prestashop_Total.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ImporDTESII.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ArchivarDoc.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ConsStock.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Wordpress_Prod.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_Wordpress_Stock.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_CierreDoc.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_FacturacionAuto.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_AsistenteCompras.Click, AddressOf Sp_SuperTabItem_Click

        With _Row_ConfEstacion

            Chk_EnvioCorreo.Checked = .Item("EnvioCorreo")
            Chk_ColaImpDoc.Checked = .Item("ColaImpDoc")
            Chk_ColaImpPick.Checked = .Item("ColaImpPick")
            Chk_SolProdBod.Checked = .Item("SolProdBod")
            Chk_Prestashop_Prod.Checked = .Item("Prestashop_Prod")
            Chk_Prestashop_Order.Checked = .Item("Prestashop_Order")
            Chk_Prestashop_Total.Checked = .Item("Prestashop_Total")
            Chk_ImporDTESII.Checked = .Item("ImporDTESII")
            Chk_ArchivarDoc.Checked = .Item("ArchivarDoc")
            Chk_ConsStock.Checked = .Item("ConsStock")
            Chk_Wordpress_Prod.Checked = .Item("Wordpress_Prod")
            Chk_Wordpress_Stock.Checked = .Item("Wordpress_Stock")
            Chk_CierreDoc.Checked = .Item("CierreDoc")

            Chk_COVCerrar.Checked = .Item("COVCerrar")
            Input_DiasCOV.Value = .Item("DiasCOV")

            Chk_NVICerrar.Checked = .Item("NVICerrar")
            Input_DiasNVI.Value = .Item("DiasNVI")

            Chk_NVVCerrar.Checked = .Item("NVVCerrar")
            Input_DiasNVV.Value = .Item("DiasNVV")

            Chk_OCICerrar.Checked = .Item("OCICerrar")
            Input_DiasOCI.Value = .Item("DiasOCI")

            Chk_OCCCerrar.Checked = .Item("OCCCerrar")
            Input_DiasOCC.Value = .Item("DiasOCC")

            Chk_FacAuto.Checked = .Item("FacAuto")

            Txt_FacAuto_Modalidad.Text = .Item("FacAuto_Modalidad")
            Rdb_FacAuto_Dia.Checked = .Item("FacAuto_Dia")
            Rdb_FacAuto_Sem.Checked = .Item("FacAuto_Sem")
            Rdb_FacAuto_Mes.Checked = .Item("FacAuto_Mes")
            Rdb_FacAuto_Todas.Checked = .Item("FacAuto_Todas")

            Chk_AsistenteCompras.Checked = .Item("AsistenteCompras")

            Txt_ImpSolProdBod.Text = .Item("ImpSolProdBod")
            Txt_DirArchivarDoc.Text = .Item("DirArchivarDoc")

        End With

        AddHandler Grilla_AsistenteCompras.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sp_SuperTabItem_Click(Sp_EnvioCorreo, Nothing)

        Sb_Actualizar_Grilla_Acp()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_ConfXEstacion Set" &
                       " EnvioCorreo = " & Convert.ToInt32(Chk_EnvioCorreo.Checked) &
                       ",CantCorreo = 0" &
                       ",ColaImpDoc = " & Convert.ToInt32(Chk_ColaImpDoc.Checked) &
                       ",ColaImpPick = " & Convert.ToInt32(Chk_ColaImpPick.Checked) &
                       ",SolProdBod = " & Convert.ToInt32(Chk_SolProdBod.Checked) &
                       ",ImpSolProdBod = '" & Txt_ImpSolProdBod.Text & "'" &
                       ",Prestashop_Prod = " & Convert.ToInt32(Chk_Prestashop_Prod.Checked) &
                       ",Prestashop_Order = " & Convert.ToInt32(Chk_Prestashop_Order.Checked) &
                       ",Prestashop_Total = " & Convert.ToInt32(Chk_Prestashop_Total.Checked) &
                       ",ImporDTESII = " & Convert.ToInt32(Chk_ImporDTESII.Checked) &
                       ",ArchivarDoc = " & Convert.ToInt32(Chk_ArchivarDoc.Checked) &
                       ",DirArchivarDoc = '" & Txt_DirArchivarDoc.Text & "'" &
                       ",ConsStock = " & Convert.ToInt32(Chk_ConsStock.Checked) &
                       ",ConsStock_Todos = " & Convert.ToInt32(Rdb_Cons_Stock_Todos.Checked) &
                       ",ConsStock_Hoy = " & Convert.ToInt32(Rdb_Cons_Stock_Mov_Hoy.Checked) &
                       ",Wordpress_Prod = " & Convert.ToInt32(Chk_Wordpress_Prod.Checked) &
                       ",Wordpress_Stock = " & Convert.ToInt32(Chk_Wordpress_Stock.Checked) &
                       ",CierreDoc = " & Convert.ToInt32(Chk_CierreDoc.Checked) &
                       ",COVCerrar = " & Convert.ToInt32(Chk_COVCerrar.Checked) &
                       ",DiasCOV = " & Convert.ToInt32(Input_DiasCOV.Value) &
                       ",NVICerrar = " & Convert.ToInt32(Chk_NVICerrar.Checked) &
                       ",DiasNVI = " & Convert.ToInt32(Input_DiasNVI.Value) &
                       ",NVVCerrar = " & Convert.ToInt32(Chk_NVVCerrar.Checked) &
                       ",DiasNVV = " & Convert.ToInt32(Input_DiasNVV.Value) &
                       ",OCICerrar = " & Convert.ToInt32(Chk_OCICerrar.Checked) &
                       ",DiasOCI = " & Convert.ToInt32(Input_DiasOCI.Value) &
                       ",OCCCerrar = " & Convert.ToInt32(Chk_OCCCerrar.Checked) &
                       ",DiasOCC = " & Convert.ToInt32(Input_DiasOCC.Value) &
                       ",FacAuto = " & Convert.ToInt32(Chk_FacAuto.Checked) &
                       ",FacAuto_Modalidad = '" & Txt_FacAuto_Modalidad.Text & "'" &
                       ",FacAuto_Dia = " & Convert.ToInt32(Rdb_FacAuto_Dia.Checked) &
                       ",FacAuto_Sem = " & Convert.ToInt32(Rdb_FacAuto_Sem.Checked) &
                       ",FacAuto_Mes = " & Convert.ToInt32(Rdb_FacAuto_Mes.Checked) &
                       ",FacAuto_Todas = " & Convert.ToInt32(Rdb_FacAuto_Todas.Checked) &
                       ",AsistenteCompras = " & Convert.ToInt32(Chk_AsistenteCompras.Checked) & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Filtro_Doc_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Correo.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Correo)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Filtro_Doc_Impresion_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Impresion.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Filtro_Doc_Impresion_X_Usuario_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Impresion_X_Usuario.Click
        If Not Fx_Tiene_Permiso("Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Dim Fm As New Frm_Demonio_05_FunConecExt(_NombreEquipo, False)
        Fm.Funcionario_Autorizado = _Funcionario_Autorizado
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Txt_ImpSolProdBod_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ImpSolProdBod.ButtonCustomClick
        Dim Fm As New Frm_Seleccionar_Impresoras(Txt_ImpSolProdBod.Text)
        Fm.ShowDialog(Me)

        If Not String.IsNullOrEmpty(Trim(Fm.Pro_Impresora_Seleccionada)) Then

            Txt_ImpSolProdBod.Text = Fm.Pro_Impresora_Seleccionada
            ToastNotification.Show(Me, "IMPRESORA SELECCIONADA [" & Txt_ImpSolProdBod.Text & "]", My.Resources.ok_button,
                                         3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If
        Fm.Dispose()
    End Sub

    Private Sub Txt_ImpSolProdBod_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_ImpSolProdBod.ButtonCustom2Click
        Txt_ImpSolProdBod.Text = String.Empty
    End Sub

    Private Sub Btn_Filtro_Doc_Picking_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Picking.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion_Picking)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Filtro_Doc_Picking_X_Usuario_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Picking_X_Usuario.Click
        If Not Fx_Tiene_Permiso("Doc00057", _Funcionario_Autorizado) Then
            Return
        End If

        Dim Fm As New Frm_Demonio_05_FunConecExt(_NombreEquipo, True)
        Fm.Funcionario_Autorizado = _Funcionario_Autorizado
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Filtro_Doc_Prestashop_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Doc_Prestashop.Click
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Prestashop)
        Fm.Pro_NombreEquipo = _NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
    End Sub

    Private Sub Txt_DirArchivarDoc_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_DirArchivarDoc.ButtonCustomClick

        Dim _Aceptar As Boolean

        Dim _Directorio As String = Txt_DirArchivarDoc.Text

        _Aceptar = InputBox_Bk(Me, "Ingrese la carpeta de destino", "Archivador de documentos",
                               _Directorio, False,,, True, _Tipo_Imagen.Folder,,,,,, True)

        If Not _Aceptar Then
            Return
        End If

        Txt_DirArchivarDoc.Text = _Directorio

    End Sub


    Private Sub Btn_ConfProgramacion_Click(sender As Object, e As EventArgs) Handles Btn_ConfProgramacion.Click

        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Programacion As Cl_NewProgramacion
        Dim _Tab As SuperTabItem = SuperTab.SelectedTab

        Dim _Nombre As String = Replace(_Tab.Name, "Sp_", "")

        Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id & " And Nombre = '" & _Nombre & "'", True)

        If Not CBool(_Id_Prg) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion (Tbl_Padre,Id_Padre,Nombre,FrecuDiaria,SucedeUnaVez) Values ('Diablito'," & _Id & ",'" & _Nombre & "',1,1)"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Prg)
        End If

        _Programacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

        If String.IsNullOrEmpty(_Programacion.Tbl_Padre) Then
            _Programacion.Tbl_Padre = "Diablito"
        End If

        Dim Fm As New Frm_Demonio_ConfProgramacion
        Fm.Programacion = _Programacion
        Fm.Txt_Nombre.ReadOnly = True
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            _Grb_Programacion.Sb_Actualizar_programacion(_Programacion)
            Sp_SuperTabItem_Click(_Tab, Nothing)
        End If
        Fm.Dispose()

    End Sub

    Function Fx_Traer_Progracion_De_Tab(_Nombre As String) As Cl_NewProgramacion

        Dim _Grb_Programacion As New Grb_Programacion

        Dim _Id_Prg = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id & " And Nombre = '" & _Nombre & "'")

        If Not CBool(_Id_Prg) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion (Id_Padre,Nombre) Values (" & _Id & ",'EnvioCorreo')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Prg)
        End If

        Fx_Traer_Progracion_De_Tab = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

    End Function

    Private Sub Chk_Habilitar_CheckedChanged(sender As Object, e As EventArgs)

        Dim _Stab As SuperTabItem = SuperTab.Tabs.Item(CInt(sender.Tag))
        If sender.Checked Then
            _Stab.Image = Imagenes_16X16.Images.Item("symbol-ok.png")
        Else
            _Stab.Image = Nothing
        End If

    End Sub

    Private Sub Sp_SuperTabItem_Click(sender As Object, e As EventArgs)

        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Tab As SuperTabItem = SuperTab.SelectedTab

        Grupo_Resumen.Text = _Tab.Text

        If _Tab.Name = "Sp_SqlQueryEspecial" Or _Tab.Name = "Sp_AsistenteCompras" Or _Tab.Name = "" Then
            Btn_ConfProgramacion.Enabled = False
            Txt_Resumen.Text = "La programación depende de cada registro"
            Return
        End If

        Btn_ConfProgramacion.Enabled = True

        Dim _Nombre As String = Replace(_Tab.Name, "Sp_", "")

        Dim _Resumen As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Resumen", "Id_Padre = " & _Id & " And Nombre = '" & _Nombre & "'")

        If String.IsNullOrEmpty(_Resumen) Then
            _Resumen = "Sin programación..."
        Else
            _Resumen = "Descripción de la programación:" & vbCrLf & _Resumen
        End If

        Txt_Resumen.Text = _Resumen

    End Sub

    Private Sub Txt_FacAuto_Modalidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FacAuto_Modalidad.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDADES DE LA EMPRESA"

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And MODALIDAD <> '  '",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Modalidad = _Row.Item("Codigo").ToString.Trim

            Txt_FacAuto_Modalidad.Tag = _Modalidad
            Txt_FacAuto_Modalidad.Text = _Modalidad

        End If

    End Sub

    Private Sub Btn_AgregarConfAsisCompra_Click(sender As Object, e As EventArgs) Handles Btn_AgregarConfAsisCompra.Click

        Dim Fm As New Frm_Demonio_ConfAsisCompra(0)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla_Acp()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Actualizar_Grilla_Acp()

        Consulta_sql = "Select AcpA.Id,AcpA.NombreEquipo,AcpA.Modalidad,AcpA.Tido," & vbCrLf &
                       "Case AcpA.Tido When 'NVI' Then 'NVI - Sol. interna' When 'OC1' Then 'OCC - Prov.Estrella' When 'OC2' Then 'OCC - Prov.Regular' End As 'Tipo',Prog.Resumen" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto AcpA" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Prog On AcpA.Id = Prog.Id_Padre And Prog.Tbl_Padre = 'AcoAuto'" & vbCrLf &
                       "Where AcpA.NombreEquipo = '" & _NombreEquipo & "'" & vbCrLf &
                       "Order by Modalidad,Tido"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_AsistenteCompras

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_AsistenteCompras, True)

            Dim _DisplayIndex = 0

            .Columns("Modalidad").Width = 50
            .Columns("Modalidad").HeaderText = "Mod."
            .Columns("Modalidad").ToolTipText = "Modalidad"
            .Columns("Modalidad").Visible = True
            .Columns("Modalidad").Frozen = True
            .Columns("Modalidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Width = 120
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Visible = True
            .Columns("Tipo").Frozen = True
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Resumen").Width = 200
            .Columns("Resumen").HeaderText = "Resumen"
            .Columns("Resumen").Visible = True
            .Columns("Resumen").Frozen = True
            .Columns("Resumen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_AsistenteCompras_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_AsistenteCompras.CellEnter

        Dim _Fila As DataGridViewRow = Grilla_AsistenteCompras.CurrentRow

        Txt_Resumen.Text = _Fila.Cells("Resumen").Value

    End Sub

    Private Sub Grilla_AsistenteCompras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_AsistenteCompras.CellDoubleClick

        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Fila As DataGridViewRow = Grilla_AsistenteCompras.CurrentRow

        Dim _Id_Padre As Integer = _Fila.Cells("Id").Value

        Dim _Id As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id",
                                                   "Id_Padre = " & _Id_Padre & " And NombreEquipo = '" & _NombreEquipo & "' And Tbl_Padre = 'AcoAuto'", True)

        Dim _Programacion As Cl_NewProgramacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id)

        Dim Fm As New Frm_Demonio_ConfAsisCompra(_Id_Padre)
        Fm.Programacion = _Programacion
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla_Acp()
        End If
        Fm.Dispose()

    End Sub


End Class
