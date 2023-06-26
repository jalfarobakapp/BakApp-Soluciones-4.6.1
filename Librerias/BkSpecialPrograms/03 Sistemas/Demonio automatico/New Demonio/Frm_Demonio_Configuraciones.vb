Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_Demonio_Configuraciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _NombreEquipo As String
    Dim _Id As Integer
    Dim _Row_ConfEstacion As DataRow

    Dim _Funcionario_Autorizado As String

    Dim EnvioCorreo_Prog As New Cl_NewProgramacion

    Dim _Directorio = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
    Dim _Dir_Correo_Imagenes = _Directorio & "\Correo\Imagenes"

    Public Property Grabar As Boolean
    Public Property Cambiar_Usuario_X_Defecto As Boolean

    Public Sub New(_Id As Integer, _Funcionario_Autorizado As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
        Me._Funcionario_Autorizado = _Funcionario_Autorizado
        Me._Id = _Id

        Sb_Color_Botones_Barra(Bar1)

        Sb_Formato_Generico_Grilla(Grilla_AsistenteCompras, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

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
        AddHandler Chk_SqlQueryEspecial.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged
        AddHandler Chk_ListasProgramadas.CheckedChanged, AddressOf Chk_Habilitar_CheckedChanged

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
        AddHandler Sp_FacAuto.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_SqlQueryEspecial.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_AsistenteCompras.Click, AddressOf Sp_SuperTabItem_Click
        AddHandler Sp_ListasProgramadas.Click, AddressOf Sp_SuperTabItem_Click


        Sb_Parametros_Informe_Sql(False)
        Sp_SuperTabItem_Click(Sp_EnvioCorreo, Nothing)
        Sb_Actualizar_Grilla_Acp()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        For Each _Tab As SuperTabItem In SuperTab.Tabs

            If Not IsNothing(_Tab.Image) Then

                Dim _Nombre As String = Replace(_Tab.Name, "Sp_", "")

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion" & vbCrLf &
                               "Where Id_Padre = " & _Id & " And NombreEquipo = '" & _NombreEquipo & "' And Nombre = '" & _Nombre & "'"
                Dim _Row_Programacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _RevisarProgramacion = False

                If IsNothing(_Row_Programacion) Then
                    _RevisarProgramacion = True
                Else
                    _RevisarProgramacion = String.IsNullOrEmpty(_Row_Programacion.Item("Resumen"))
                End If

                If _Nombre = "AsistenteCompras" Then
                    _RevisarProgramacion = Not CBool(Grilla_AsistenteCompras.RowCount)
                End If

                If _RevisarProgramacion Then
                    MessageBoxEx.Show(Me, "Falta la programación para " & _Tab.Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    SuperTab.SelectedTab = _Tab
                    Sp_SuperTabItem_Click(Nothing, Nothing)
                    Return
                End If

            End If

        Next

        If Chk_SolProdBod.Checked AndAlso String.IsNullOrWhiteSpace(Txt_ImpSolProdBod.Text) Then
            MessageBoxEx.Show(Me, "Falta la impresora en solicitud de productos a bodega", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_FacAuto.Checked AndAlso String.IsNullOrWhiteSpace(Txt_FacAuto_Modalidad.Text) Then
            MessageBoxEx.Show(Me, "Falta la modalidad para la facturación automática", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_ArchivarDoc.Checked AndAlso String.IsNullOrWhiteSpace(Txt_DirArchivarDoc.Text) Then
            MessageBoxEx.Show(Me, "Falta la carpeta de destino de los archivos en el archivador de documentos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_ArchivarDoc.Checked Then
            If Not Directory.Exists(Txt_DirArchivarDoc.Text) Then
                MessageBoxEx.Show(Me, "No existe el directorio " & Txt_DirArchivarDoc.Text, "Validación archivador de documentos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Chk_CierreDoc.Checked AndAlso
            Not Chk_COVCerrar.Checked AndAlso
            Not Chk_NVICerrar.Checked AndAlso
            Not Chk_NVVCerrar.Checked AndAlso
            Not Chk_OCCCerrar.Checked AndAlso
            Not Chk_OCICerrar.Checked Then
            MessageBoxEx.Show(Me, "Debe indicar algún documento para cerrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            SuperTab.SelectedTabIndex = 12
            Return
        End If

        Sb_Parametros_Informe_Sql(True)
        Grabar = True
        Me.Close()

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

        Dim _Ruta_Archivador As String = AppPath() & "\Data\" & RutEmpresa & "\Archivador"

        If MessageBoxEx.Show(Me, "¿Desea dejar la carpeta de destino por defecto?" & vbCrLf & vbCrLf &
                             "[Si] deja carpeta por defecto" & vbCrLf &
                             "[No] selecciona otro directorio", "Carpeta de destino de archivador",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If Not Directory.Exists(_Ruta_Archivador) Then
                System.IO.Directory.CreateDirectory(_Ruta_Archivador)
            End If

            Txt_DirArchivarDoc.Text = _Ruta_Archivador
            Return

        End If

        Dim _Aceptar As Boolean

        _Ruta_Archivador = Txt_DirArchivarDoc.Text

        _Aceptar = InputBox_Bk(Me, "Ingrese la carpeta de destino", "Archivador de documentos",
                               _Ruta_Archivador, False,,, True, _Tipo_Imagen.Folder,,,,,, True)

        If Not _Aceptar Then
            Return
        End If

        Txt_DirArchivarDoc.Text = _Ruta_Archivador

    End Sub


    Private Sub Btn_ConfProgramacion_Click(sender As Object, e As EventArgs) Handles Btn_ConfProgramacion.Click

        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Programacion As Cl_NewProgramacion
        Dim _Tab As SuperTabItem = SuperTab.SelectedTab

        Dim _Nombre As String = Replace(_Tab.Name, "Sp_", "")

        Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion",
                                                   "Id", "Id_Padre = " & _Id & " And NombreEquipo = '" & _NombreEquipo & "' And Nombre = '" & _Nombre & "'", True)

        If Not CBool(_Id_Prg) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion (NombreEquipo,Tbl_Padre,Id_Padre,Nombre,FrecuDiaria,SucedeUnaVez) " &
                           "Values ('" & _NombreEquipo & "','Diablito'," & _Id & ",'" & _Nombre & "',1,1)"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Prg)
        End If

        _Programacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

        If String.IsNullOrEmpty(_Programacion.Tbl_Padre) Then
            _Programacion.Tbl_Padre = "Diablito"
        End If

        Dim _Diariamente As Boolean
        Dim _Semanalmente As Boolean
        Dim _SucedeCada As Boolean
        Dim _SucedeUnaVez As Boolean
        Dim _TipoIntervalo As String = String.Empty
        Dim _TIValorDefecto As String
        Dim _TISegundos As Boolean
        Dim _TIMinutos As Boolean
        Dim _TIHoras As Boolean

        Dim _MinIntervalo As Integer
        Dim _MaxIntevalo As Integer

        Sb_Tipo_Configuracion(_Nombre, _Diariamente, _Semanalmente, _SucedeCada, _SucedeUnaVez, _TIValorDefecto, _TISegundos, _TIMinutos, _TIHoras, _TipoIntervalo, _MinIntervalo, _MaxIntevalo)

        Dim Fm As New Frm_Demonio_ConfProgramacion(_TISegundos, _TIMinutos, _TIHoras, _TIValorDefecto)
        Fm.Text = "Configuración de programación de " & _Tab.Text.ToUpper

        Fm.Rdb_FrecuDiaria.Enabled = _Diariamente
        Fm.Rdb_FrecuSemanal.Enabled = _Semanalmente
        Fm.Rdb_SucedeCada.Enabled = _SucedeCada
        Fm.Rdb_SucedeUnaVez.Enabled = _SucedeUnaVez
        Fm.Input_IntervaloCada.MinValue = _MinIntervalo
        Fm.Input_IntervaloCada.MaxValue = _MaxIntevalo

        Fm.TIMinutos = _TIMinutos
        Fm.TIHoras = _TIHoras

        Fm.Programacion = _Programacion
        Fm.Txt_Nombre.ReadOnly = True
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            _Grb_Programacion.Sb_Actualizar_programacion(_Programacion)
            Sp_SuperTabItem_Click(_Tab, Nothing)
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Tipo_Configuracion(_Nombre As String,
                              ByRef _Diariamente As Boolean,
                              ByRef _Semanalmente As Boolean,
                              ByRef _SucedeCada As Boolean,
                              ByRef _SucedeUnaVez As Boolean,
                              ByRef _TIValorDefecto As String,
                              ByRef _TISegundos As Boolean,
                              ByRef _TIMinutos As Boolean,
                              ByRef _TIHoras As Boolean,
                              ByRef _TipoIntervalo As String,
                              ByRef _MinIntervalo As Integer,
                              ByRef _MaxIntevalo As Integer)

        _MinIntervalo = 1
        _MaxIntevalo = 60

        Select Case _Nombre
            Case "EnvioCorreo", "Prestashop_Prod", "Wordpress_Prod", "Wordpress_Stock", "FacAuto", "ImporDTESII", "ListasProgramadas"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 1 : _MaxIntevalo = 59 : _TIMinutos = True : _TIValorDefecto = "MM"
            Case "ColaImpDoc"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 3 : _MaxIntevalo = 3 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "ColaImpPick"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 4 : _MaxIntevalo = 4 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "SolProdBod"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 5 : _MaxIntevalo = 5 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "Prestashop_Order"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 2 : _MaxIntevalo = 2 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "ArchivarDoc"
                _Diariamente = True : _SucedeCada = True : _MinIntervalo = 30 : _MaxIntevalo = 30 : _TISegundos = True : _TIValorDefecto = "SS"
            Case "ConsStock", "CierreDoc", "Prestashop_Total"
                _Diariamente = True : _Semanalmente = True : _SucedeUnaVez = True : _SucedeCada = False
                _MinIntervalo = 5 : _MaxIntevalo = 59 : _TIMinutos = True : _TIValorDefecto = ""
            Case Else
                Dim A = 1
        End Select


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

        'Dim _Stab As SuperTabItem = SuperTab.Tabs.Item(CInt(sender.Tag))
        'If sender.Checked Then
        '    _Stab.Image = Imagenes_16X16.Images.Item("symbol-ok.png")
        'Else
        '    _Stab.Image = Nothing
        'End If

        Dim _NombreChk As String = CType(sender, Controls.CheckBoxX).Name.Replace("Chk_", "")

        For Each _Stab As SuperTabItem In SuperTab.Tabs

            Dim _NombreTab As String = Replace(_Stab.Name, "Sp_", "")

            If _NombreTab = _NombreChk Then
                If sender.Checked Then
                    _Stab.Image = Imagenes_16X16.Images.Item("symbol-ok.png")
                Else
                    _Stab.Image = Nothing
                End If
                Exit For
            End If

        Next

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

        Consulta_sql = "Select AcpA.Id,AcpA.NombreEquipo,AcpA.Modalidad,AcpA.NVI,AcpA.OCC_Star,AcpA.OCC_Prov,Prog.Resumen" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto AcpA" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Prog On AcpA.Id = Prog.Id_Padre And Prog.Tbl_Padre = 'AcoAuto'" & vbCrLf &
                       "Where AcpA.NombreEquipo = '" & _NombreEquipo & "'" & vbCrLf &
                       "Order by Modalidad,NVI,OCC_Star,OCC_Prov"

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

            .Columns("NVI").Width = 40
            .Columns("NVI").HeaderText = "NVI"
            .Columns("NVI").Visible = True
            .Columns("NVI").Frozen = True
            .Columns("NVI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OCC_Star").Width = 40
            .Columns("OCC_Star").HeaderText = "OCC PE"
            .Columns("OCC_Star").ToolTipText = "Ordenes de compra al proveedor estrella"
            .Columns("OCC_Star").Visible = True
            .Columns("OCC_Star").Frozen = True
            .Columns("OCC_Star").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OCC_Prov").Width = 40
            .Columns("OCC_Prov").HeaderText = "OCC OP"
            .Columns("OCC_Prov").ToolTipText = "Ordenes de compra a otros proveedores"
            .Columns("OCC_Prov").Visible = True
            .Columns("OCC_Prov").Frozen = True
            .Columns("OCC_Prov").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Resumen").Width = 200
            .Columns("Resumen").HeaderText = "Resumen"
            .Columns("Resumen").Visible = True
            .Columns("Resumen").Frozen = False
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


    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _Actualizar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                           "Where Informe = 'Demonio' And NombreEquipo = '" & _NombreEquipo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        'correo
        _Sql.Sb_Parametro_Informe_Sql(Chk_EnvioCorreo, "Demonio",
                                      Chk_EnvioCorreo.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_EnvioCorreo.Checked, _Actualizar, "Correo",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_CantCorreo, "Demonio",
                                      Input_CantCorreo.Name, Class_SQLite.Enum_Type._Double,
                                      Input_CantCorreo.Value, _Actualizar, "Correo",, False)

        'Impresiones
        _Sql.Sb_Parametro_Informe_Sql(Chk_ColaImpDoc, "Demonio",
                                      Chk_ColaImpDoc.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ColaImpDoc.Checked, _Actualizar, "Impresion",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_ColaImpPick, "Demonio",
                                      Chk_ColaImpPick.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ColaImpPick.Checked, _Actualizar, "Impresion",, False)

        'Prestashop
        _Sql.Sb_Parametro_Informe_Sql(Chk_Prestashop_Prod, "Demonio",
                                      Chk_Prestashop_Prod.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Prestashop_Prod.Checked, _Actualizar, "Prestashop",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Prestashop_Order, "Demonio",
                                      Chk_Prestashop_Order.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Prestashop_Order.Checked, _Actualizar, "Prestashop",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Prestashop_Total, "Demonio",
                                      Chk_Prestashop_Total.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Prestashop_Total.Checked, _Actualizar, "Prestashop",, False)

        'Importar correos y actualizar libro de compras DTESII
        _Sql.Sb_Parametro_Informe_Sql(Chk_ImporDTESII, "Demonio",
                                      Chk_ImporDTESII.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ImporDTESII.Checked, _Actualizar, "ImporDTESII",, False)
        'Archivar documentos
        _Sql.Sb_Parametro_Informe_Sql(Chk_ArchivarDoc, "Demonio",
                                      Chk_ArchivarDoc.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ArchivarDoc.Checked, _Actualizar, "ArchivarDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_DirArchivarDoc, "Demonio",
                                      Txt_DirArchivarDoc.Name, Class_SQLite.Enum_Type._String,
                                      Txt_DirArchivarDoc.Text, _Actualizar, "ArchivarDoc",, False)

        'Consolidar stock
        _Sql.Sb_Parametro_Informe_Sql(Chk_ConsStock, "Demonio",
                                      Chk_ConsStock.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ConsStock.Checked, _Actualizar, "ConsolidarStock",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Cons_Stock_Todos, "Demonio",
                                      Rdb_Cons_Stock_Todos.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_Cons_Stock_Todos.Checked, _Actualizar, "ConsolidarStock",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Cons_Stock_Mov_Hoy, "Demonio",
                                      Rdb_Cons_Stock_Mov_Hoy.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_Cons_Stock_Mov_Hoy.Checked, _Actualizar, "ConsolidarStock",, False)

        'Wordpress
        _Sql.Sb_Parametro_Informe_Sql(Chk_Wordpress_Prod, "Demonio",
                                      Chk_Wordpress_Prod.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Wordpress_Prod.Checked, _Actualizar, "Wordpress",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Wordpress_Stock, "Demonio",
                                      Chk_Wordpress_Stock.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Wordpress_Stock.Checked, _Actualizar, "Wordpress",, False)

        'Cierre de documentos
        _Sql.Sb_Parametro_Informe_Sql(Chk_CierreDoc, "Demonio",
                                      Chk_CierreDoc.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_CierreDoc.Checked, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_COVCerrar, "Demonio",
                                      Chk_COVCerrar.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_COVCerrar.Checked, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_DiasCOV, "Demonio",
                                      Input_DiasCOV.Name, Class_SQLite.Enum_Type._Double,
                                      Input_DiasCOV.Value, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_NVICerrar, "Demonio",
                                      Chk_NVICerrar.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_NVICerrar.Checked, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_DiasNVI, "Demonio",
                                      Input_DiasNVI.Name, Class_SQLite.Enum_Type._Double,
                                      Input_DiasNVI.Value, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_NVVCerrar, "Demonio",
                                      Chk_NVVCerrar.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_NVVCerrar.Checked, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_DiasNVV, "Demonio",
                                      Input_DiasNVV.Name, Class_SQLite.Enum_Type._Double,
                                      Input_DiasNVV.Value, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_OCICerrar, "Demonio",
                                      Chk_OCICerrar.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_OCICerrar.Checked, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_DiasOCI, "Demonio",
                                      Input_DiasOCI.Name, Class_SQLite.Enum_Type._Double,
                                      Input_DiasOCI.Value, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Chk_OCCCerrar, "Demonio",
                                      Chk_OCCCerrar.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_OCCCerrar.Checked, _Actualizar, "CierreDoc",, False)
        _Sql.Sb_Parametro_Informe_Sql(Input_DiasOCC, "Demonio",
                                      Input_DiasOCC.Name, Class_SQLite.Enum_Type._Double,
                                      Input_DiasOCC.Value, _Actualizar, "CierreDoc",, False)

        'Facturación automatica
        _Sql.Sb_Parametro_Informe_Sql(Chk_FacAuto, "Demonio",
                                      Chk_FacAuto.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_FacAuto.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_FacAuto_Modalidad, "Demonio",
                                      Txt_FacAuto_Modalidad.Name, Class_SQLite.Enum_Type._String,
                                      Txt_FacAuto_Modalidad.Text, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Dia, "Demonio",
                                      Rdb_FacAuto_Dia.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Dia.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Sem, "Demonio",
                                      Rdb_FacAuto_Sem.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Sem.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Mes, "Demonio",
                                      Rdb_FacAuto_Mes.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Mes.Checked, _Actualizar, "FacAuto",, False)
        _Sql.Sb_Parametro_Informe_Sql(Rdb_FacAuto_Todas, "Demonio",
                                      Rdb_FacAuto_Todas.Name, Class_SQLite.Enum_Type._Boolean,
                                      Rdb_FacAuto_Todas.Checked, _Actualizar, "FacAuto",, False)

        'Solicitud de productos a bodega
        _Sql.Sb_Parametro_Informe_Sql(Chk_SolProdBod, "Demonio",
                                      Chk_SolProdBod.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_SolProdBod.Checked, _Actualizar, "SolProdBod",, False)
        _Sql.Sb_Parametro_Informe_Sql(Txt_ImpSolProdBod, "Demonio",
                                      Txt_ImpSolProdBod.Name, Class_SQLite.Enum_Type._String,
                                      Txt_ImpSolProdBod.Text, _Actualizar, "SolProdBod",, False)

        'Asistente de compras
        _Sql.Sb_Parametro_Informe_Sql(Chk_AsistenteCompras, "Demonio",
                                      Chk_AsistenteCompras.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_AsistenteCompras.Checked, _Actualizar, "SolProdBod",, False)

        'Listas Programadas
        _Sql.Sb_Parametro_Informe_Sql(Chk_ListasProgramadas, "Demonio",
                                      Chk_ListasProgramadas.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ListasProgramadas.Checked, _Actualizar, "ListasProgramadas",, False)

    End Sub

    Private Sub Btn_Carpeta_Imagenes_Click(sender As Object, e As EventArgs) Handles Btn_Carpeta_Imagenes.Click
        Process.Start("explorer.exe", _Dir_Correo_Imagenes)
    End Sub

    Private Sub BtnCambiarDeUsuario_Click(sender As Object, e As EventArgs) Handles BtnCambiarDeUsuario.Click

        Dim _Old_Funcionario = FUNCIONARIO

        Dim Fml As New Frm_Login
        Fml.ShowDialog()
        Fml.Dispose()

        If _Old_Funcionario <> FUNCIONARIO Then

            Dim Frm_Modalidad As New Frm_Modalidades(False)
            Frm_Modalidad.ShowDialog()
            Frm_Modalidad.Dispose()

            If MessageBoxEx.Show(Me, "¿Desea dejar a este funcionario permanentemente como usuario por defecto para la estación de trabajo?" & vbCrLf & vbCrLf &
                                         "Usuario: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim & " Modalidad: " & Modalidad,
                                         "Usuario por defecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set " &
                               "Usuario_X_Defecto = '" & FUNCIONARIO & "', Modalidad_X_Defecto = '" & Modalidad & "'" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Nombre de usuario por defecto cambiado correctamente", "Cambio de usuario",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

            Cambiar_Usuario_X_Defecto = True
            Me.Close()

        End If

    End Sub

    Private Sub Txt_DirArchivarDoc_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_DirArchivarDoc.ButtonCustom2Click

        If Not Directory.Exists(Txt_DirArchivarDoc.Text) Then
            MessageBoxEx.Show(Me, "No existe el directorio " & Txt_DirArchivarDoc.Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Process.Start("explorer.exe", Txt_DirArchivarDoc.Text)

    End Sub
End Class
