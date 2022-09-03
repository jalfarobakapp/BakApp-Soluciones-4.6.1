Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Rotacion_Selec_Prod_Parametros

    Dim _SQL As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos_Madre As DataTable
    Dim _Tbl_Productos_Seleccionados As DataTable
    Dim _Tbl_Productos_A_Procesar As DataTable

    Dim _Informe_Procesado As Boolean

    Public Property Pro_Tbl_Productos_Seleccionados() As DataTable
        Get
            Return _Tbl_Productos_Seleccionados
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Productos_Seleccionados = value

            Grupo_Seleccion.Enabled = False
            Rdb_Productos_Seleccionados.Checked = True
            'Grupo_Advertir_Rotacion.Enabled = False

        End Set
    End Property

    Public ReadOnly Property Pro_Informe_Procesado() As Boolean
        Get
            Return _Informe_Procesado
        End Get
    End Property

    Public Property Pro_Input_Dias_Advertencia_Rotacion() As Integer
        Get
            Return Input_Dias_Advertencia_Rotacion.Value
        End Get
        Set(ByVal value As Integer)
            Input_Dias_Advertencia_Rotacion.Value = value
        End Set
    End Property
    Public Property Pro_Chk_Advertir_Rotacion() As Boolean
        Get
            Return Chk_Traer_Prod_Rotacion_Desactualizada.Checked
        End Get
        Set(ByVal value As Boolean)
            Chk_Traer_Prod_Rotacion_Desactualizada.Checked = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dtp_Fecha_Estudio_Desde.Value = DateSerial(Year(FechaDelServidor), 1, 1)
        Dtp_Fecha_Estudio_Hasta.Value = ultimodiadelmes(FechaDelServidor)

        'Chk_Desde_Principio_Tiempo.Checked = True

    End Sub

    Private Sub Frm_07_AsisCompra_Selec_Prod_Rotacion_Parametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Consulta_sql = "Select EMPRESA,KOSU,KOBO From TABBO"
        'Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        'Consulta_sql = String.Empty

        'If CBool(_Tbl.Rows.Count) Then

        'For Each _Fila As DataRow In _Tbl.Rows

        'Dim _Empresa = _Fila.Item("EMPRESA")
        'Dim _Sucursal = _Fila.Item("KOSU")
        'Dim _Bodega = _Fila.Item("KOBO")

        'Consulta_sql += "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas)" & vbCrLf & _
        '                "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',KOPR,NOKOPR,0 FROM MAEPR" & vbCrLf & _
        '                "WHERE KOPR NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
        '                "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
        '                "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 0)" & _
        '                vbCrLf & _
        '                "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas)" & vbCrLf & _
        '                "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',KOPR,NOKOPR,1 FROM MAEPR" & vbCrLf & _
        '                "WHERE KOPR NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
        '                "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
        '                "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 1)"

        'Next

        '_SQL.Ej_consulta_IDU(Consulta_sql)

        'Consulta_sql = String.Empty

        'End If

        'Sb_Actualizar_Listado_Productos_A_Estudiar()

        AddHandler Rdb_Productos_Todos.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB
        AddHandler Rdb_Productos_Seleccionados.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB
        AddHandler Rdb_Productos_Con_Movimineto_Desde_Hasta.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB

        Sb_Habilitar_Deshabilitar_RDB()

    End Sub

    Sub Sb_Actualizar_Listado_Productos_A_Estudiar()

        Dim _Nodo_Raiz_Asociados = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        Consulta_sql = "Select EMPRESA,KOSU,KOBO From TABBO"
        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Empresa = _Fila.Item("EMPRESA")
            Dim _Sucursal = _Fila.Item("KOSU")
            Dim _Bodega = _Fila.Item("KOBO")

            Consulta_sql += "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas,Es_Asociador)" & vbCrLf & _
                            "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',Codigo_Nodo,Substring(Descripcion,1,50),0,1 FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf & _
                            "WHERE Codigo_Nodo NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
                            "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                            "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 0 And Es_Asociador = 1) And Es_Padre = 0" & vbCrLf & _
                            "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")" & _
                            vbCrLf & _
                            vbCrLf & _
                            "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas,Es_Asociador)" & vbCrLf & _
                            "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',Codigo_Nodo,Substring(Descripcion,1,50),1,1 FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf & _
                            "WHERE Codigo_Nodo NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
                            "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                            "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 1 And Es_Asociador = 1) And Es_Padre = 0" & vbCrLf & _
                            "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")" & vbCrLf & vbCrLf

        Next

        _SQL.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Empresa = _Fila.Item("EMPRESA")
            Dim _Sucursal = _Fila.Item("KOSU")
            Dim _Bodega = _Fila.Item("KOBO")

            Consulta_sql += "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas,Es_Asociador)" & vbCrLf & _
                            "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',KOPR,NOKOPR,0,1 FROM MAEPR" & vbCrLf & _
                            "WHERE KOPR NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
                            "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                            "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 0 And Es_Asociador = 1)" & _
                            vbCrLf & _
                            "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas,Es_Asociador)" & vbCrLf & _
                            "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',KOPR,NOKOPR,1,1 FROM MAEPR" & vbCrLf & _
                            "WHERE KOPR NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
                            "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                            "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 1 And Es_Asociador = 1)"

        Next

        _SQL.Ej_consulta_IDU(Consulta_sql)

    End Sub


    Function Fx_Productos_Todos() As DataTable

        Consulta_sql = "Select KOPR As Codigo From MAEPR" & vbCrLf & _
                       "Where TIPR IN ('FPN','FPS','FUN','FUS')"

        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Productos_Entre_Fechas() As DataTable

        Dim _F1 = Format(Dtp_Fecha_Movimientos_Desde.Value, "yyyyMMdd")
        Dim _F2 = Format(Dtp_Fecha_Movimientos_Hasta.Value, "yyyyMMdd")

        Consulta_sql = "Select KOPR As Codigo From MAEPR" & vbCrLf & _
                       "Where KOPR IN (SELECT DISTINCT KOPRCT FROM MAEDDO " & _
                       "WHERE FEEMLI BETWEEN '" & _F1 & "' AND '" & _F2 & "' AND TIPR IN ('FPN','FPS','FUN','FUS'))" 'KOPR IN (SELECT KOPR FROM MAEPR WHERE TIPR IN ('FPN','FPS','FUN','FUS')))"
        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

        '{{"FIN", "Insumo productivo"}, _
        '                                       {"FLN", "Artículo multiproposito"}, _
        '                                       {"FPN", "Articulo estándar"}, _
        '                                       {"FPS", "Articulo seriado"}, _
        '                                       {"FUN", "Herramienta estándar"}, _
        '                                       {"FUS", "Herramienta seriada"}, _
        '                                       {"GEN", "Génerico o agrupador de artículos"}, _
        '                                       {"SSN", "Servicios y similares"}}

    End Function

    Function Fx_Productos_Seleccionados() As DataTable

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos_Seleccionados, "", "Codigo", False, False, "'")

        If _Filtro_Productos = "()" Then
            Consulta_sql = "Select KOPR As Codigo From MAEPR" & vbCrLf & _
                                   "Where 1 < 0"
        Else
            Consulta_sql = "Select KOPR As Codigo From MAEPR" & vbCrLf & _
                                   "Where KOPR IN " & _Filtro_Productos
        End If



        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function


    Function Fx_Traer_Genericos(ByVal _TblProductos As DataTable) As DataTable

        Dim _Fl = Generar_Filtro_IN(_TblProductos, "", "Codigo", False, False, "'")

        Consulta_sql = "Select KOPR As Codigo From MAEPR" & vbCrLf & _
                       "Where KOPR In " & _Fl & vbCrLf & _
                       "Union" & vbCrLf & _
                       "Select KOPR As Codigo From MAEPR" & vbCrLf & _
                       "Where KOPR IN (SELECT KOPRREM FROM TABREMP " & _
                       "WHERE KOPR IN " & _Fl & " AND KOPR <> KOPRREM)"

        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Traer_Asociados_Hermanos(ByVal _TblProductos_Madre As DataTable, ByVal _TblProductos As DataTable) As DataTable

        Dim _Fl = Generar_Filtro_IN(_TblProductos, "", "Codigo", False, False, "'")
        Dim _F2 = Generar_Filtro_IN(_TblProductos_Madre, "", "Codigo", False, False, "'")

        Consulta_sql = "Select Distinct Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf & _
                       "Where Codigo_Nodo In " & _F2 & " And Codigo Not In " & _Fl & vbCrLf & _
                       "Union" & vbCrLf & _
                       "Select KOPR As Codigo From MAEPR Where KOPR IN " & _Fl

        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Private Sub BtnSeleccionarProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionarProductos.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Productos_Seleccionados,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Productos_Seleccionados = _Filtrar.Pro_Tbl_Filtro

        End If

    End Sub

    Sub Sb_Habilitar_Deshabilitar_RDB()

        Dim _Enable_Mov As Boolean
        Dim _Enable_Rot As Boolean

        If Rdb_Productos_Todos.Checked Then
            _Enable_Mov = False
            _Enable_Rot = True
            BtnSeleccionarProductos.Enabled = False
        ElseIf Rdb_Productos_Seleccionados.Checked Then
            BtnSeleccionarProductos.Enabled = True
            _Enable_Rot = False
            _Enable_Mov = False
        ElseIf Rdb_Productos_Con_Movimineto_Desde_Hasta.Checked Then
            _Enable_Mov = True
            _Enable_Rot = True
            BtnSeleccionarProductos.Enabled = False
        End If

        Lbl_Desde.Enabled = _Enable_Mov
        Lbl_Hasta.Enabled = _Enable_Mov
        Dtp_Fecha_Movimientos_Desde.Enabled = _Enable_Mov
        Dtp_Fecha_Movimientos_Hasta.Enabled = _Enable_Mov

        Chk_Traer_Prod_Rotacion_Desactualizada.Enabled = _Enable_Rot
        Input_Dias_Advertencia_Rotacion.Enabled = _Enable_Rot
        Lbl_Dias.Enabled = _Enable_Rot

    End Sub

    Private Sub Btn_Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Procesar.Click

        If Rdb_Productos_Todos.Checked Then
            _Tbl_Productos_A_Procesar = Fx_Productos_Todos()
        ElseIf Rdb_Productos_Seleccionados.Checked Then

            If _Tbl_Productos_Seleccionados Is Nothing Then
                MessageBoxEx.Show(Me, "No hay productos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _Tbl_Productos_A_Procesar = Fx_Productos_Seleccionados()

        ElseIf Rdb_Productos_Con_Movimineto_Desde_Hasta.Checked Then
            _Tbl_Productos_A_Procesar = Fx_Productos_Entre_Fechas()
        End If


        If _Tbl_Productos_Seleccionados Is Nothing Then _Tbl_Productos_Seleccionados = _Tbl_Productos_A_Procesar

        'Consulta_sql = "Select EMPRESA,KOSU,KOBO From TABBO"
        'Dim _Tbl_Bodegas As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        'Dim _Filtro_Productos_Madre = Generar_Filtro_IN(_Tbl_Productos_A_Procesar, "", "Codigo", False, False, "'")

        'Consulta_sql = String.Empty

        'For Each _Fila As DataRow In _Tbl_Bodegas.Rows

        'Dim _Empresa = _Fila.Item("EMPRESA")
        'Dim _Sucursal = _Fila.Item("KOSU")
        'Dim _Bodega = _Fila.Item("KOBO")

        'Consulta_sql += "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas,Es_Asociador)" & vbCrLf & _
        '                "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',KOPR,NOKOPR,0,1 FROM MAEPR" & vbCrLf & _
        '                "WHERE KOPR NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
        '                "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
        '                "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 0 And Es_Asociador = 1)" & vbCrLf & _
        '                "And KOPR In " & _Filtro_Productos_Madre & _
        '                vbCrLf & _
        '                vbCrLf & _
        '                "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Empresa,Sucursal,Bodega,Codigo, Descripcion,Con_Ent_Excluidas,Es_Asociador)" & vbCrLf & _
        '                "SELECT '" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "',KOPR,NOKOPR,1,1 FROM MAEPR" & vbCrLf & _
        '                "WHERE KOPR NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
        '                "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
        '                "And Bodega = '" & _Bodega & "' And Con_Ent_Excluidas = 1 And Es_Asociador = 1)" & vbCrLf & _
        '                "And KOPR In " & _Filtro_Productos_Madre & vbCrLf & vbCrLf

        'Next

        '_SQL.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = String.Empty

        Dim _Nodo_Raiz_Asociados = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")


        If CBool(_Tbl_Productos_A_Procesar.Rows.Count) Then

            If Chk_Traer_Productos_Asociados.Checked And Not Rdb_Productos_Todos.Checked Then
                Dim _Fl = Generar_Filtro_IN(_Tbl_Productos_A_Procesar, "", "Codigo", False, False, "'")

                Consulta_sql = "SELECT Codigo_Nodo As Codigo" & vbCrLf & _
                               "FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf & _
                               "Where Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo In " & _Fl & ")" & Space(1) & _
                               "And Es_Seleccionable = 1 And Nodo_Raiz = " & _Nodo_Raiz_Asociados & ""
                Dim _TblProductos_Madre As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)
                ''_Tbl_Productos_A_Procesar = Fx_Traer_Genericos(_Tbl_Productos_A_Procesar)
                _Tbl_Productos_A_Procesar = Fx_Traer_Asociados_Hermanos(_TblProductos_Madre, _Tbl_Productos_A_Procesar)
            End If

            'If Chk_Traer_Prod_Rotacion_Desactualizada.Checked And Not Rdb_Productos_Seleccionados.Checked Then
            '_Tbl_Productos_A_Procesar = Fx_Traer_Productos_Definitivos(_Tbl_Productos_A_Procesar)
            'End If

            Dim _Fecha_Desde As Date
            Dim _Fecha_Hasta As Date

            If Rdb_Rango_Fechas.Checked Then
                _Fecha_Desde = Dtp_Fecha_Estudio_Desde.Value
                _Fecha_Hasta = Dtp_Fecha_Estudio_Hasta.Value
            ElseIf Rdb_Rango_Meses.Checked Then
                _Fecha_Hasta = FechaDelServidor()
                _Fecha_Desde = DateAdd(DateInterval.Month, -Input_Ultimos_Meses.Value, _Fecha_Hasta) '#1/1/1900#
                '_Fecha_Desde = Primerdiadelmes(_Fecha_Desde)
            End If

            If MessageBoxEx.Show(Me, "¿Desea procesar estos productos?", _
                                 FormatNumber(_Tbl_Productos_A_Procesar.Rows.Count, 0) & " Productos encontrados", _
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                Dim Fm As New Frm_Rotacion_Procesar_Productos("", "", "", _Tbl_Productos_A_Procesar)
                Fm.Chk_Incluir_Ventas_Entidades_Excluidas.Checked = Chk_Incluir_Ventas_Entidades_Excluidas.Checked
                'Fm.Pro_TblProductos = _Tbl_Productos_A_Procesar
                Fm.Pro_TblPasoInforme = _Global_BaseBk & "Zw_Prod_Rotacion"

                Fm.Pro_Fecha_Estudio_Desde = FormatDateTime(_Fecha_Desde, DateFormat.ShortDate) 'Dtp_Fecha_Estudio_Desde.Value
                Fm.Pro_Fecha_Estudio_Hasta = FormatDateTime(_Fecha_Hasta, DateFormat.ShortDate) 'Dtp_Fecha_Estudio_Hasta.Value
                'Fm.Pro_Principio_Vida = Chk_Desde_Principio_Tiempo.Checked
                Fm.Pro_TblProductos_Madre = Nothing '_TblProductos_Madre
                Fm.ShowDialog(Me)
                _Informe_Procesado = Fm.Pro_Informe_Procesado
                Fm.Dispose()

                If _Informe_Procesado Then
                    Me.Close()
                End If

            End If
        Else
            _Tbl_Productos_Seleccionados = Nothing
            MessageBoxEx.Show(Me, "No hay productos seleccionados", _
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnEntidadesExcluidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEntidadesExcluidas.Click
        Dim Fm As New Frm_EntExcluidas
        Fm.ShowInTaskbar = False
        Fm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Function Fx_Traer_Productos_Definitivos(ByVal _Tbl As DataTable) As DataTable

        Dim _Dias_Advertencia_Rotacion = Input_Dias_Advertencia_Rotacion.Value
        Dim _Fecha As Date = DateAdd(DateInterval.Day, -_Dias_Advertencia_Rotacion, FechaDelServidor)

        Dim _Fl = Generar_Filtro_IN(_Tbl, "", "Codigo", False, False, "'")

        Consulta_sql = "Select KOPR As Codigo From MAEPR" & vbCrLf & _
                       "Where KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & vbCrLf & _
                       "Where Fecha_Ultima_Ejecucion < '" & Format(_Fecha, "yyyyMMdd") & "' or Fecha_Ultima_Ejecucion is null" & vbCrLf & _
                       "And Codigo Not in (Select KOPR From MAEPR Where TIPR = 'SSN') And Con_Ent_Excluidas = " & CInt(Chk_Incluir_Ventas_Entidades_Excluidas.Checked) * -1 & ")" & Space(1) & _
                       "And KOPR In " & _Fl

        _Tbl = _SQL.Fx_Get_Tablas(Consulta_sql)
        Return _Tbl

    End Function

    Private Sub Btn_Stock_History_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Rdb_Productos_Todos.Checked Then
            _Tbl_Productos_A_Procesar = Fx_Productos_Todos()
        ElseIf Rdb_Productos_Seleccionados.Checked Then

            If _Tbl_Productos_Seleccionados Is Nothing Then
                MessageBoxEx.Show(Me, "No hay productos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _Tbl_Productos_A_Procesar = Fx_Productos_Seleccionados()
        ElseIf Rdb_Productos_Con_Movimineto_Desde_Hasta.Checked Then
            _Tbl_Productos_A_Procesar = Fx_Productos_Entre_Fechas()
        End If


        If CBool(_Tbl_Productos_A_Procesar.Rows.Count) Then

            If Chk_Traer_Productos_Asociados.Checked And Not Rdb_Productos_Todos.Checked Then
                _Tbl_Productos_A_Procesar = Fx_Traer_Genericos(_Tbl_Productos_A_Procesar)
            End If


            If Chk_Traer_Prod_Rotacion_Desactualizada.Checked And Not Rdb_Productos_Seleccionados.Checked Then
                _Tbl_Productos_A_Procesar = Fx_Traer_Productos_Definitivos(_Tbl_Productos_A_Procesar)
            End If


            If MessageBoxEx.Show(Me, "¿Desea procesar estos productos?", _
                                 FormatNumber(_Tbl_Productos_A_Procesar.Rows.Count, 0) & " Productos encontrados", _
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                Dim Fm As New Frm_Stock_History(_Tbl_Productos_A_Procesar)
                Fm.ShowDialog(Me)
                Fm.Dispose()


            End If
        Else
            _Tbl_Productos_Seleccionados = Nothing
            MessageBoxEx.Show(Me, "No hay productos seleccionados", _
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    
End Class