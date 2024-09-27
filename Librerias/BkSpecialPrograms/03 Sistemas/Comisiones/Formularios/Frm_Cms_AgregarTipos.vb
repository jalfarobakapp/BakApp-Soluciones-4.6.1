Imports System.Security.Cryptography
Imports DevComponents.DotNetBar

Public Class Frm_Cms_AgregarTipos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodFuncionario As String
    Dim _TblBodega As DataTable
    Dim _TblSucursales As DataTable
    Dim _TblVendedores As DataTable

    Dim _Id_Mis As Integer
    Dim _Row_Comisiones_Mis As DataRow

    Dim _Tbl_Filtro_Entidad As DataTable
    Dim _Tbl_Filtro_SucursalDoc As DataTable
    Dim _Tbl_Filtro_Sucursales As DataTable
    Dim _Tbl_Filtro_Bodegas As DataTable
    Dim _Tbl_Filtro_Ciudad As DataTable
    Dim _Tbl_Filtro_Comunas As DataTable
    Dim _Tbl_Filtro_Rubro_Entidades As DataTable
    Dim _Tbl_Filtro_Zonas_Entidades As DataTable
    Dim _Tbl_Filtro_Responzables As DataTable
    Dim _Tbl_Filtro_Vendedores As DataTable
    Dim _Tbl_Filtro_Vendedores_Asignados As DataTable
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Familias As DataTable
    Dim _Tbl_Filtro_Sub_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro_Productos As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas_Productos As DataTable
    Dim _Tbl_Filtro_Tipo_Entidad As DataTable
    Dim _Tbl_Filtro_Act_Economica As DataTable
    Dim _Tbl_Filtro_Tama_Empresa As DataTable
    Dim _Tbl_Filtro_Clas_BakApp As DataTable
    Dim _Tbl_Filtro_Lista_Precio_Asig As DataTable
    Dim _Tbl_Filtro_Lista_Precio_Docu As DataTable
    Dim _Tbl_Filtro_EntidadExcluidas As DataTable
    Dim _Tbl_Filtro_ProductosExcluidos As DataTable

    Dim _Filtro_Entidad_Todas As Boolean
    Dim _Filtro_SucursalDoc_Todas As Boolean
    Dim _Filtro_Sucursales_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean
    Dim _Filtro_Ciudad_Todas As Boolean
    Dim _Filtro_Comunas_Todas As Boolean
    Dim _Filtro_Rubro_Entidades_Todas As Boolean
    Dim _Filtro_Zonas_Entidades_Todas As Boolean
    Dim _Filtro_Responzables_Todas As Boolean
    Dim _Filtro_Vendedores_Todas As Boolean
    Dim _Filtro_Vendedores_Asignados_Todas As Boolean
    Dim _Filtro_Productos_Todos As Boolean
    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Familias_Todas As Boolean
    Dim _Filtro_Sub_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Productos_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Productos_Todas As Boolean
    Dim _Filtro_Lista_Precio_Asig_Todas As Boolean
    Dim _Filtro_Lista_Precio_Docu_Todas As Boolean
    Dim _Filtro_Tipo_Entidad_Todas As Boolean
    Dim _Filtro_Act_Economica_Todas As Boolean
    Dim _Filtro_Tama_Empresa_Todas As Boolean


    Public Property Grabar As Boolean

    Public Sub New(_Id_Mis As Integer, _CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Me._CodFuncionario = _CodFuncionario
        Me._Id_Mis = _Id_Mis

        If CBool(_Id_Mis) Then

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Mis Where Id = " & _Id_Mis
            _Row_Comisiones_Mis = _Sql.Fx_Get_DataRow(Consulta_Sql)

        End If

    End Sub

    Private Sub Frm_Cms_AgregarTipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Filtro_Entidad_Todas = True
        _Filtro_SucursalDoc_Todas = True
        _Filtro_Sucursales_Todas = True
        _Filtro_Bodegas_Todas = True
        _Filtro_Ciudad_Todas = True
        _Filtro_Comunas_Todas = True
        _Filtro_Rubro_Entidades_Todas = True
        _Filtro_Zonas_Entidades_Todas = True
        _Filtro_Responzables_Todas = True
        _Filtro_Vendedores_Todas = True
        _Filtro_Vendedores_Asignados_Todas = True
        _Filtro_Productos_Todos = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Familias_Todas = True
        _Filtro_Sub_Familias_Todas = True
        _Filtro_Marcas_Todas = True
        _Filtro_Rubro_Productos_Todas = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Zonas_Productos_Todas = True
        _Filtro_Tipo_Entidad_Todas = True
        _Filtro_Act_Economica_Todas = True
        _Filtro_Tama_Empresa_Todas = True
        _Filtro_Lista_Precio_Asig_Todas = True
        _Filtro_Lista_Precio_Docu_Todas = True

        Btn_Eliminar.Visible = False

        If Not IsNothing(_Row_Comisiones_Mis) Then

            With _Row_Comisiones_Mis
                Txt_Descripcion.Text = .Item("Descripcion")
                Txt_PorcComision.Text = .Item("PorcComision")
                Chk_TieneSC.Checked = .Item("TieneSC")
                Chk_MisVentas.Checked = .Item("MisVentas")
            End With

            _Tbl_Filtro_Entidad = Fx_Cargar_TblFiltro("Tbl_Filtro_Entidad")
            _Tbl_Filtro_SucursalDoc = Fx_Cargar_TblFiltro("Tbl_Filtro_SucursalDoc")
            _Tbl_Filtro_Sucursales = Fx_Cargar_TblFiltro("Tbl_Filtro_Sucursales")
            _Tbl_Filtro_Bodegas = Fx_Cargar_TblFiltro("Tbl_Filtro_Bodegas")
            _Tbl_Filtro_Ciudad = Fx_Cargar_TblFiltro("Tbl_Filtro_Ciudad")
            _Tbl_Filtro_Comunas = Fx_Cargar_TblFiltro("Tbl_Filtro_Comunas")
            _Tbl_Filtro_Rubro_Entidades = Fx_Cargar_TblFiltro("Tbl_Filtro_Rubro_Entidades")
            _Tbl_Filtro_Zonas_Entidades = Fx_Cargar_TblFiltro("Tbl_Filtro_Zonas_Entidades")
            _Tbl_Filtro_Responzables = Fx_Cargar_TblFiltro("Tbl_Filtro_Responzables")
            _Tbl_Filtro_Vendedores = Fx_Cargar_TblFiltro("Tbl_Filtro_Vendedores")
            _Tbl_Filtro_Vendedores_Asignados = Fx_Cargar_TblFiltro("Tbl_Filtro_Vendedores_Asignados")
            _Tbl_Filtro_Productos = Fx_Cargar_TblFiltro("Tbl_Filtro_Productos")
            _Tbl_Filtro_Super_Familias = Fx_Cargar_TblFiltro("Tbl_Filtro_Super_Familias")
            _Tbl_Filtro_Familias = Fx_Cargar_TblFiltro("Tbl_Filtro_Familias")
            _Tbl_Filtro_Sub_Familias = Fx_Cargar_TblFiltro("Tbl_Filtro_Sub_Familias")
            _Tbl_Filtro_Marcas = Fx_Cargar_TblFiltro("Tbl_Filtro_Marcas")
            _Tbl_Filtro_Rubro_Productos = Fx_Cargar_TblFiltro("Tbl_Filtro_Rubro_Productos")
            _Tbl_Filtro_Clalibpr = Fx_Cargar_TblFiltro("Tbl_Filtro_Clalibpr")
            _Tbl_Filtro_Zonas_Productos = Fx_Cargar_TblFiltro("Tbl_Filtro_Zonas_Productos")
            _Tbl_Filtro_Tipo_Entidad = Fx_Cargar_TblFiltro("Tbl_Filtro_Tipo_Entidad")
            _Tbl_Filtro_Act_Economica = Fx_Cargar_TblFiltro("Tbl_Filtro_Act_Economica")
            _Tbl_Filtro_Tama_Empresa = Fx_Cargar_TblFiltro("Tbl_Filtro_Tama_Empresa")

            _Tbl_Filtro_Lista_Precio_Asig = Fx_Cargar_TblFiltro("Tbl_Filtro_Lista_Precio_Asig")
            _Tbl_Filtro_Lista_Precio_Docu = Fx_Cargar_TblFiltro("Tbl_Filtro_Lista_Precio_Docu")
            _Tbl_Filtro_EntidadExcluidas = Fx_Cargar_TblFiltro("Tbl_Filtro_EntidadExcluidas")
            _Tbl_Filtro_ProductosExcluidos = Fx_Cargar_TblFiltro("Tbl_Filtro_ProductosExcluidos")

            _Filtro_Entidad_Todas = Not CBool(_Tbl_Filtro_Entidad.Rows.Count)
            _Filtro_SucursalDoc_Todas = Not CBool(_Tbl_Filtro_SucursalDoc.Rows.Count)
            _Filtro_Sucursales_Todas = Not CBool(_Tbl_Filtro_Sucursales.Rows.Count)
            _Filtro_Bodegas_Todas = Not CBool(_Tbl_Filtro_Bodegas.Rows.Count)
            _Filtro_Ciudad_Todas = Not CBool(_Tbl_Filtro_Ciudad.Rows.Count)
            _Filtro_Comunas_Todas = Not CBool(_Tbl_Filtro_Comunas.Rows.Count)
            _Filtro_Rubro_Entidades_Todas = Not CBool(_Tbl_Filtro_Rubro_Entidades.Rows.Count)
            _Filtro_Zonas_Entidades_Todas = Not CBool(_Tbl_Filtro_Zonas_Entidades.Rows.Count)
            _Filtro_Responzables_Todas = Not CBool(_Tbl_Filtro_Responzables.Rows.Count)
            _Filtro_Vendedores_Todas = Not CBool(_Tbl_Filtro_Vendedores.Rows.Count)
            _Filtro_Vendedores_Asignados_Todas = Not CBool(_Tbl_Filtro_Vendedores_Asignados.Rows.Count)
            _Filtro_Productos_Todos = Not CBool(_Tbl_Filtro_Productos.Rows.Count)
            _Filtro_Super_Familias_Todas = Not CBool(_Tbl_Filtro_Super_Familias.Rows.Count)
            _Filtro_Familias_Todas = Not CBool(_Tbl_Filtro_Familias.Rows.Count)
            _Filtro_Sub_Familias_Todas = Not CBool(_Tbl_Filtro_Sub_Familias.Rows.Count)
            _Filtro_Marcas_Todas = Not CBool(_Tbl_Filtro_Marcas.Rows.Count)
            _Filtro_Rubro_Productos_Todas = Not CBool(_Tbl_Filtro_Rubro_Productos.Rows.Count)
            _Filtro_Clalibpr_Todas = Not CBool(_Tbl_Filtro_Clalibpr.Rows.Count)
            _Filtro_Zonas_Productos_Todas = Not CBool(_Tbl_Filtro_Zonas_Productos.Rows.Count)
            _Filtro_Tipo_Entidad_Todas = Not CBool(_Tbl_Filtro_Tipo_Entidad.Rows.Count)
            _Filtro_Act_Economica_Todas = Not CBool(_Tbl_Filtro_Act_Economica.Rows.Count)
            _Filtro_Tama_Empresa_Todas = Not CBool(_Tbl_Filtro_Tama_Empresa.Rows.Count)

            _Filtro_Lista_Precio_Asig_Todas = Not CBool(_Tbl_Filtro_Lista_Precio_Asig.Rows.Count)
            _Filtro_Lista_Precio_Docu_Todas = Not CBool(_Tbl_Filtro_Lista_Precio_Docu.Rows.Count)

            Btn_Eliminar.Visible = True

        End If

        Sb_Imagenes_Filtros()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el nombre de la comisión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        Dim _PorcComsion As Double = De_Txt_a_Num_01(Txt_PorcComision.Text, 5)

        If _PorcComsion = 0 Then
            If MessageBoxEx.Show(Me, "Porcentaje de comisión en cero" & vbCrLf &
                                 "¿Confirma dejar el valor en cero?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                Txt_PorcComision.Text = 0
                Txt_PorcComision.Focus()
                Return
            End If
        End If

        If Not CBool(_Id_Mis) Then
            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Comisiones_Mis (CodFuncionario,Descripcion) Values " &
                           "('" & _CodFuncionario & "','" & Txt_Descripcion.Text & "')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_Sql, _Id_Mis)
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Comisiones_Mis Set" &
                       " Descripcion = '" & Txt_Descripcion.Text.Trim & "'" &
                       ",PorcComision = " & De_Num_a_Tx_01(_PorcComsion, False, 5) &
                       ",Empresa = " & ModEmpresa &
                       ",TieneSC = " & Convert.ToInt32(Chk_TieneSC.Checked) &
                       ",MisVentas = " & Convert.ToInt32(Chk_MisVentas.Checked) &
                       "Where Id = " & _Id_Mis &
                       vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl" & vbCrLf &
                       "Where Id_Mis = " & _Id_Mis

        Dim _SqlQuery As String

        _SqlQuery = Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Entidad)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_SucursalDoc)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Sucursales)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Bodegas)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Ciudad)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Comunas)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Rubro_Entidades)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Zonas_Entidades)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Responzables)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Vendedores)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Vendedores_Asignados)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Productos)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Super_Familias)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Familias)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Sub_Familias)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Marcas)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Rubro_Productos)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Clalibpr)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Zonas_Productos)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Tipo_Entidad)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Act_Economica)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Tama_Empresa)

        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Lista_Precio_Asig)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_Lista_Precio_Docu)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_EntidadExcluidas)
        _SqlQuery += Fx_Actualizar_Filtro_Tmp(_Tbl_Filtro_ProductosExcluidos)

        Consulta_Sql = Consulta_Sql & vbCrLf & _SqlQuery

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Grabar = True
            Me.Close()

        End If

    End Sub


    Private Sub Txt_Vendedores_ButtonCustomClick(sender As Object, e As EventArgs)

        Dim _Sql_Filtro_Condicion_Extra '= "And KOFU Not In (Select CodFuncionario From " & _Global_BaseBk & "Zw_Comisiones_Fun)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblVendedores,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _TblVendedores = _Filtrar.Pro_Tbl_Filtro

        End If

    End Sub

    Private Sub Txt_PorcComision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PorcComision.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

    Private Sub Txt_Bodegas_ButtonCustomClick(sender As Object, e As EventArgs)


    End Sub


    Function Fx_Cargar_TblFiltro(_NombreTblFiltro As String) As DataTable

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Tbl As DataTable

        Consulta_Sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl" & vbCrLf &
                       "Where Id_Mis = " & _Id_Mis & " And NombreTblFiltro = '" & _NombreTblFiltro & "'"
        _Tbl = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If CBool(_Tbl.Rows.Count) Then
            _Tbl.TableName = _NombreTblFiltro
        End If

        Return _Tbl

    End Function

    Function Fx_Actualizar_Filtro_Tmp(_Tbl As DataTable) As String

        If IsNothing(_Tbl) Then
            Return ""
        End If

        Dim _NombreTblFiltro As String = _Tbl.TableName
        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _SqlQuery As String = String.Empty

        If Not _Tbl Is Nothing Then

            If _Tbl.Rows.Count Then

                For Each _Fila As DataRow In _Tbl.Rows

                    Dim _Chk As Boolean = _Fila.Item("Chk")

                    If _Chk Then

                        Dim _Codigo = _Fila.Item("Codigo")
                        Dim _Descripcion = _Fila.Item("Descripcion")

                        _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl (Id_Mis,Chk,Codigo,Descripcion,NombreTblFiltro) VALUES" & Space(1) &
                                        "(" & _Id_Mis & ",1,'" & _Codigo & "','" & _Descripcion & "','" & _NombreTblFiltro & "')" & vbCrLf

                    End If

                Next

            End If

        End If

        Return _SqlQuery

    End Function

    Private Sub Btn_Filtro_Ent_Entidades_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Entidades.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, "",
                               _Filtro_Entidad_Todas, False,,,,, "Tbl_Filtro_Entidad") Then

            _Tbl_Filtro_Entidad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Entidad_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Entidad_Todas Then
                _Tbl_Filtro_Entidad = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Ciudades_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Ciudades.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Ciudad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Ciudades, "",
                               _Filtro_Ciudad_Todas, False,,,,, "Tbl_Filtro_Ciudad") Then

            _Tbl_Filtro_Ciudad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Ciudad_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Ciudad_Todas Then
                _Tbl_Filtro_Ciudad = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Comunas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Comunas.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Comunas = String.Empty

        If Not _Filtro_Ciudad_Todas Then
            If Not (_Tbl_Filtro_Ciudad Is Nothing) Then
                If _Tbl_Filtro_Ciudad.Rows.Count Then
                    Dim _Fl_Ciudad = Generar_Filtro_IN(_Tbl_Filtro_Ciudad, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Comunas = vbCrLf & "And KOPA+KOCI In " & _Fl_Ciudad
                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Comunas

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Comunas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Comunas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Comunas_Todas, False,,,,, "Tbl_Filtro_Comunas") Then

            _Tbl_Filtro_Comunas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Comunas_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Comunas_Todas Then
                _Tbl_Filtro_Comunas = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Rubros_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Rubros.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Rubro_Entidades,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Rubros, "",
                               _Filtro_Rubro_Entidades_Todas, True,,,,, "Tbl_Filtro_Rubro_Entidades") Then

            _Tbl_Filtro_Rubro_Entidades = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Rubro_Entidades_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Rubro_Entidades_Todas Then
                _Tbl_Filtro_Rubro_Entidades = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtrar_Entidades_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Entidades.Click
        ShowContextMenu(Menu_Contextual_Filtros_Entidades)
    End Sub

    Private Sub Btn_Filtro_Ent_Zonas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Zonas.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Zonas_Entidades,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Zonas, "",
                               _Filtro_Zonas_Entidades_Todas, True,,,,, "Tbl_Filtro_Zonas_Entidades") Then

            _Tbl_Filtro_Zonas_Entidades = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Zonas_Entidades_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Zonas_Entidades_Todas Then
                _Tbl_Filtro_Zonas_Entidades = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Tipo_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Tipo_Entidad.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Tipo_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, "",
                               _Filtro_Tipo_Entidad_Todas,,,,,, "Tbl_Filtro_Tipo_Entidad") Then

            _Tbl_Filtro_Tipo_Entidad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Tipo_Entidad_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Tipo_Entidad_Todas Then
                _Tbl_Filtro_Tipo_Entidad = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Act_Economica_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Act_Economica.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Act_Economica,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, "",
                               _Filtro_Act_Economica_Todas,,,,,, "Tbl_Filtro_Act_Economica") Then

            _Tbl_Filtro_Act_Economica = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Act_Economica_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Act_Economica_Todas Then
                _Tbl_Filtro_Act_Economica = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Tamano_Empresa_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Tamano_Empresa.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Tama_Empresa,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, "",
                               _Filtro_Tama_Empresa_Todas,,,,,, "Tbl_Filtro_Tama_Empresa") Then

            _Tbl_Filtro_Tama_Empresa = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Tama_Empresa_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Tama_Empresa_Todas Then
                _Tbl_Filtro_Tama_Empresa = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Lista_Precio_Asig_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Lista_Precio_Asig.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPP"
        _Filtrar.Campo = "'TABPP'+KOLT"
        _Filtrar.Descripcion = "NOKOLT"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Lista_Precio_Asig,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                               _Filtro_Lista_Precio_Asig_Todas, True) Then

            _Tbl_Filtro_Lista_Precio_Asig = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Lista_Precio_Asig_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Lista_Precio_Asig_Todas Then
                _Tbl_Filtro_Lista_Precio_Asig = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Lista_Precio_Doc_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Lista_Precio_Doc.Click
        'Dim _SqlFiltro_Fechas As String

        '_SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
        '                    Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        'Dim _Sql_Filtro_Condicion_Extra = "And TILT = 'P' And KOLT In (Select Distinct SUBSTRING(KOLTPR,6,3) From " &
        '                                  _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPP"
        _Filtrar.Campo = "'TABPP'+KOLT"
        _Filtrar.Descripcion = "NOKOLT"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Lista_Precio_Docu,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                               _Filtro_Lista_Precio_Asig_Todas, False) Then

            _Tbl_Filtro_Lista_Precio_Docu = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Lista_Precio_Docu_Todas = _Filtrar.Pro_Filtro_Todas
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_EntidadesExcluidas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_EntidadesExcluidas.Click
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_EntidadExcluidas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, "",
                               False, False,, False,, False) Then

            _Tbl_Filtro_EntidadExcluidas = _Filtrar.Pro_Tbl_Filtro
            _Tbl_Filtro_EntidadExcluidas.TableName = "Tbl_Filtro_EntidadExcluidas"
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Sub Sb_Imagenes_Filtros()

        Btn_Filtro_Responzables.Image = Fx_Imagen_Filtro(_Filtro_Responzables_Todas)
        Btn_Filtro_Vendedores.Image = Fx_Imagen_Filtro(_Filtro_Vendedores_Todas)
        Btn_Filtro_Vendedor_Asignado_Entidad.Image = Fx_Imagen_Filtro(_Filtro_Vendedores_Asignados_Todas)

        If Not _Filtro_Vendedores_Todas Or Not _Filtro_Responzables_Todas Or Not _Filtro_Vendedores_Asignados_Todas Then
            Btn_Filtrar_Funcionarios.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Funcionarios.Image = Nothing
        End If

        Btn_Filtro_Ent_Entidades.Image = Fx_Imagen_Filtro(_Filtro_Entidad_Todas)
        Btn_Filtro_Ent_EntidadesExcluidas.Image = Fx_Imagen_Filtro(Not (Not IsNothing(_Tbl_Filtro_EntidadExcluidas) AndAlso CBool(_Tbl_Filtro_EntidadExcluidas.Rows.Count)))
        Btn_Filtro_Ent_Ciudades.Image = Fx_Imagen_Filtro(_Filtro_Ciudad_Todas)
        Btn_Filtro_Ent_Comunas.Image = Fx_Imagen_Filtro(_Filtro_Comunas_Todas)
        Btn_Filtro_Ent_Rubros.Image = Fx_Imagen_Filtro(_Filtro_Rubro_Entidades_Todas)
        Btn_Filtro_Ent_Zonas.Image = Fx_Imagen_Filtro(_Filtro_Zonas_Entidades_Todas)
        Btn_Filtro_Ent_Act_Economica.Image = Fx_Imagen_Filtro(_Filtro_Act_Economica_Todas)
        Btn_Filtro_Ent_Tipo_Entidad.Image = Fx_Imagen_Filtro(_Filtro_Tipo_Entidad_Todas)
        Btn_Filtro_Ent_Tamano_Empresa.Image = Fx_Imagen_Filtro(_Filtro_Tama_Empresa_Todas)
        Btn_Filtro_Ent_Lista_Precio_Asig.Image = Fx_Imagen_Filtro(_Filtro_Lista_Precio_Asig_Todas)
        Btn_Filtro_Ent_Lista_Precio_Doc.Image = Fx_Imagen_Filtro(_Filtro_Lista_Precio_Docu_Todas)


        If Not _Filtro_Entidad_Todas Or
           Not _Filtro_Ciudad_Todas Or
           Not _Filtro_Comunas_Todas Or
           Not _Filtro_Rubro_Entidades_Todas Or
           Not _Filtro_Zonas_Entidades_Todas Or
           Not _Filtro_Act_Economica_Todas Or
           Not _Filtro_Tipo_Entidad_Todas Or
           Not _Filtro_Tama_Empresa_Todas Or
           Not _Filtro_Lista_Precio_Asig_Todas Or
           Not _Filtro_Lista_Precio_Docu_Todas Or
           (Not IsNothing(_Tbl_Filtro_EntidadExcluidas) AndAlso CBool(_Tbl_Filtro_EntidadExcluidas.Rows.Count)) Then

            Btn_Filtrar_Entidades.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Entidades.Image = Nothing
        End If

        Btn_Filtro_Pro_Productos.Image = Fx_Imagen_Filtro(_Filtro_Productos_Todos)
        Btn_Filtro_Pro_ProductosExcluidos.Image = Fx_Imagen_Filtro(Not (Not IsNothing(_Tbl_Filtro_ProductosExcluidos) AndAlso CBool(_Tbl_Filtro_ProductosExcluidos.Rows.Count)))
        Btn_Filtro_Pro_Super_Familias.Image = Fx_Imagen_Filtro(_Filtro_Super_Familias_Todas)
        Btn_Filtro_Pro_Familias.Image = Fx_Imagen_Filtro(_Filtro_Familias_Todas)
        Btn_Filtro_Pro_Sub_Familias.Image = Fx_Imagen_Filtro(_Filtro_Sub_Familias_Todas)
        Btn_Filtro_Pro_Marcas.Image = Fx_Imagen_Filtro(_Filtro_Marcas_Todas)
        Btn_Filtro_Pro_Clas_Libre.Image = Fx_Imagen_Filtro(_Filtro_Clalibpr_Todas)
        Btn_Filtro_Pro_Rubros.Image = Fx_Imagen_Filtro(_Filtro_Rubro_Productos_Todas)
        Btn_Filtro_Pro_Zonas.Image = Fx_Imagen_Filtro(_Filtro_Zonas_Productos_Todas)

        If Not _Filtro_Productos_Todos Or
           Not _Filtro_Super_Familias_Todas Or
           Not _Filtro_Familias_Todas Or
           Not _Filtro_Sub_Familias_Todas Or
           Not _Filtro_Marcas_Todas Or
           Not _Filtro_Clalibpr_Todas Or
           Not _Filtro_Rubro_Productos_Todas Or
           Not _Filtro_Zonas_Productos_Todas Or
           (Not IsNothing(_Tbl_Filtro_ProductosExcluidos) AndAlso CBool(_Tbl_Filtro_ProductosExcluidos.Rows.Count)) Then
            Btn_Filtrar_Productos.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Productos.Image = Nothing
        End If

        Btn_Filtro_SucursalDoc.Image = Fx_Imagen_Filtro(_Filtro_SucursalDoc_Todas)
        Btn_Filtro_Sucursales.Image = Fx_Imagen_Filtro(_Filtro_Sucursales_Todas)
        Btn_Filtro_Bodegas.Image = Fx_Imagen_Filtro(_Filtro_Bodegas_Todas)

        If Not _Filtro_Sucursales_Todas Or Not _Filtro_Bodegas_Todas Then
            Btn_Filtrar_Suc_Bod.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Suc_Bod.Image = Nothing
        End If

    End Sub

    Function Fx_Imagen_Filtro(_Todas As Boolean) As Image

        If _Todas Then
            Return Nothing
        Else
            Return Imagenes_16x16.Images.Item("filter.png")
        End If

    End Function

    Private Sub Btn_Filtro_Pro_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Productos.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, "",
                               _Filtro_Productos_Todos, False,,,,, "Tbl_Filtro_Productos") Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Productos_Todos = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Productos_Todos Then
                _Tbl_Filtro_Productos = Nothing
            End If
            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtrar_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Productos.Click
        ShowContextMenu(Menu_Contextual_Filtros_Productos)
    End Sub

    Private Sub Btn_Filtrar_Suc_Bod_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Suc_Bod.Click
        ShowContextMenu(Menu_Contextual_Filtros_Suc_Bod)
    End Sub

    Private Sub Btn_Filtrar_Funcionarios_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Funcionarios.Click
        ShowContextMenu(Menu_Contextual_Filtros_Funcionarios)
    End Sub

    Private Sub Btn_Filtro_Pro_Super_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Super_Familias.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Super_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Super_Familia, "",
                               _Filtro_Super_Familias_Todas,,,,,, "Tbl_Filtro_Super_Familias") Then

            _Tbl_Filtro_Super_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Super_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Super_Familias_Todas Then
                _Tbl_Filtro_Super_Familias = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Familias.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And KOFM In " & _Fl_Super_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Familias_Todas,,,,,, "Tbl_Filtro_Familias") Then

            _Tbl_Filtro_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Familias_Todas Then
                _Tbl_Filtro_Familias = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Sub_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Sub_Familias.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And KOFM In " & _Fl_Super_Familias

                End If
            End If
        End If

        If Not _Filtro_Familias_Todas Then
            If Not (_Tbl_Filtro_Familias Is Nothing) Then
                If _Tbl_Filtro_Familias.Rows.Count Then

                    Dim _Fl_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias += vbCrLf & "And KOFM+KOPF In " & _Fl_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sub_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Sub_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Sub_Familias_Todas,,,,,, "Tbl_Filtro_Sub_Familias") Then

            _Tbl_Filtro_Sub_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sub_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Sub_Familias_Todas Then
                _Tbl_Filtro_Sub_Familias = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Marcas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Marcas.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Marcas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Marcas, "",
                               _Filtro_Marcas_Todas,,,,,, "Tbl_Filtro_Marcas") Then

            _Tbl_Filtro_Marcas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Marcas_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Marcas_Todas Then
                _Tbl_Filtro_Marcas = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Clas_Libre_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Clas_Libre.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Clalibpr,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, "",
                               _Filtro_Clalibpr_Todas,,,,,, "Tbl_Filtro_Clalibpr") Then

            _Tbl_Filtro_Clalibpr = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Clalibpr_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Clalibpr_Todas Then
                _Tbl_Filtro_Clalibpr = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Rubros_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Rubros.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Rubro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Rubros, "",
                               _Filtro_Rubro_Productos_Todas, True,,,,, "Tbl_Filtro_Rubro_Productos") Then

            _Tbl_Filtro_Rubro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Rubro_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Rubro_Productos_Todas Then
                _Tbl_Filtro_Rubro_Productos = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Zonas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Zonas.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Zonas_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Zonas, "",
                               _Filtro_Zonas_Productos_Todas, True,,,,, "Tbl_Filtro_Zonas_Productos") Then

            _Tbl_Filtro_Zonas_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Zonas_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Zonas_Productos_Todas Then
                _Tbl_Filtro_Zonas_Productos = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_ProductosExcluidos_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_ProductosExcluidos.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_ProductosExcluidos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, "",
                               False, False,, False,, False, "Tbl_Filtro_ProductosExcluidos") Then

            _Tbl_Filtro_ProductosExcluidos = _Filtrar.Pro_Tbl_Filtro
            Sb_Imagenes_Filtros()
        End If

    End Sub

    Private Sub Btn_Filtro_SucursalDoc_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_SucursalDoc.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_SucursalDoc,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, "",
                               _Filtro_SucursalDoc_Todas, False,,,,, "Tbl_Filtro_SucursalDoc") Then

            _Tbl_Filtro_SucursalDoc = _Filtrar.Pro_Tbl_Filtro
            _Filtro_SucursalDoc_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_SucursalDoc_Todas Then
                _Tbl_Filtro_SucursalDoc = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Sucursales_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Sucursales.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sucursales,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, "",
                               _Filtro_Sucursales_Todas, False, "Tbl_Filtro_Sucursales") Then

            _Tbl_Filtro_Sucursales = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sucursales_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Sucursales_Todas Then
                _Tbl_Filtro_Sucursales = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Bodegas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Bodegas.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Bodegas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Bodegas, "",
                               _Filtro_Bodegas_Todas, False,,,,, "Tbl_Filtro_Bodegas") Then

            _Tbl_Filtro_Bodegas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Bodegas_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Bodegas_Todas Then
                _Tbl_Filtro_Bodegas = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Responzables_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Responzables.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Responzables,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                               _Filtro_Responzables_Todas, False,,,,, "Tbl_Filtro_Responzables") Then

            _Tbl_Filtro_Responzables = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Responzables_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Responzables_Todas Then
                _Tbl_Filtro_Responzables = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Filtro_Vendedores_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Vendedores.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Vendedores,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                               _Filtro_Vendedores_Todas, False,,,,, "Tbl_Filtro_Vendedores") Then

            _Tbl_Filtro_Vendedores = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Vendedores_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Vendedores_Todas Then
                _Tbl_Filtro_Vendedores = Nothing
            End If

            Sb_Imagenes_Filtros()

        End If

    End Sub

    Private Sub Btn_Filtro_Vendedor_Asignado_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Vendedor_Asignado_Entidad.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Vendedores_Asignados,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                               _Filtro_Vendedores_Asignados_Todas, False,,,,, "Tbl_Filtro_Vendedores_Asignados") Then

            _Tbl_Filtro_Vendedores_Asignados = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Vendedores_Asignados_Todas = _Filtrar.Pro_Filtro_Todas

            If _Filtro_Vendedores_Asignados_Todas Then
                _Tbl_Filtro_Vendedores_Asignados = Nothing
            End If
            Sb_Imagenes_Filtros()
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma eliminar esta comisión?",
                             "Eliminar periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Comisiones_Mis Where Id = " & _Id_Mis & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl" & vbCrLf & "Where Id_Mis = " & _Id_Mis
            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                MessageBoxEx.Show(Me, "Regristro eliminado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Grabar = True
                Me.Close()
            End If

        End If

    End Sub

End Class
