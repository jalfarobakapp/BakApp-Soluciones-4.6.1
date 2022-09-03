Imports DevComponents.DotNetBar

Public Class Frm_AsisCompra_Proyeccion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String = "Zw_InfCompras01" & FUNCIONARIO

    Dim _RowParametros As DataRow

    Dim _Identificador_NodoPadre As Integer
    Dim _Porc_Creciminto As Double
    Dim _Dias_Proyeccion As Double ' EX Dias_Mes
    Dim _Dias_Abastecer As Integer
    Dim _Marca_Proyeccion As Integer ' EX Mes_Marca

    Dim _Clas_Asistente_Compras As Clas_Asistente_Compras

    Dim _Sql_Consulta_Actualiza_Stock As String

    Dim _Tbl_Nodos As DataTable
    Dim _Ud As Integer

    Public ReadOnly Property Pro_Ud() As Integer
        Get
            Return _Ud
        End Get
    End Property


    Public Property Pro_Porc_Crecimiento() As Integer
        Get
            Return Input_Porc_Crecimiento.Value
        End Get
        Set(ByVal value As Integer)
            Input_Porc_Crecimiento.Value = value
        End Set
    End Property

    Public ReadOnly Property Pro_RowParametros() As DataRow
        Get
            Return _RowParametros
        End Get
    End Property

    Public Sub New(Sql_Consulta_Actualiza_Stock As String,
                   Clas_Asistente_Compras As Clas_Asistente_Compras)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Clas_Asistente_Compras = Clas_Asistente_Compras
        _Sql_Consulta_Actualiza_Stock = Sql_Consulta_Actualiza_Stock

        Sb_Cargar_Combo()

        Sb_Color_Botones_Barra(Bar1)

    End Sub


    Private Sub Frm_AsisCompra_Proyeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Cmb_Proyeccion.SelectedIndexChanged, AddressOf Cmb_Proyeccion_SelectedIndexChanged
        AddHandler Cmb_Metodo_Abastecer_Dias_Meses.SelectedIndexChanged, AddressOf Cmb_Dias_Abastecer_SelectedIndexChanged

        Cmb_Tiempo_Reposicion_Dias_Meses.Enabled = False

        Sb_Parametros_Informe_Conf_Local(True)

        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub BtnProcesarInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesarInf.Click

        If Rdb_Ud1_Compra.Checked Then
            _Ud = 1
        ElseIf Rdb_Ud2_Compra.Checked Then
            _Ud = 2
        End If

        Dim _Padre_Asociacion_Productos = Txt_Padre_Asociacion_Productos.Tag

        If Not String.IsNullOrEmpty(Txt_Padre_Asociacion_Productos.Text) Then

            Dim _Filtro_Nodos As String

            Consulta_sql = "Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                           "Where Identificacdor_NodoPadre = " & _Padre_Asociacion_Productos
            _Tbl_Nodos = _Sql.Fx_Get_Tablas(Consulta_sql)

            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Nodos, "", "Codigo_Nodo", False, False, "'")


            _Identificador_NodoPadre = _Padre_Asociacion_Productos

            Dim _Tiempo_Reposicion = Input_Tiempo_Reposicion.Value * Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue
            _Dias_Abastecer = Input_Dias_a_Abastecer.Value * Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue + _Tiempo_Reposicion


            Dim _Fecha_Fin = DateAdd(DateInterval.Day, _Dias_Abastecer, Now.Date)

            _Dias_Abastecer = Fx_Cuenta_Dias(Now.Date, _Fecha_Fin, Opcion_Dias.Habiles)
            Dim _Sabados As Integer = Fx_Cuenta_Dias(Now.Date, _Fecha_Fin, Opcion_Dias.Sabado)
            Dim _Domingos As Integer = Fx_Cuenta_Dias(Now.Date, _Fecha_Fin, Opcion_Dias.Domingo)

            _Dias_Proyeccion = _Dias_Abastecer


            Dim _Campos As Integer

            Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                Case 1
                    _Dias_Proyeccion = 1 : _Campos = 60 '_Dias_Abastecer
                Case 7
                    _Dias_Proyeccion = 5 : _Campos = 20
                Case 30
                    _Dias_Proyeccion = 22 : _Campos = 12
            End Select

            If Chk_Sabado.Checked Then
                _Dias_Abastecer += _Sabados
                Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                    Case 7
                        _Dias_Proyeccion += 1
                    Case 30
                        _Dias_Proyeccion += 2
                End Select
            End If

            If Chk_Domingo.Checked Then
                _Dias_Abastecer += _Domingos
                Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                    Case 7
                        _Dias_Proyeccion += 1
                    Case 30
                        _Dias_Proyeccion += 2
                End Select
            End If

            _Marca_Proyeccion = _Tiempo_Reposicion / Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue ' _Valor '_Dias_Proyeccion '_Mes_Marca = _Tiempo_Reposicion / _Dias_Mes

            _Porc_Creciminto = Input_Porc_Crecimiento.Value

            Dim _RotCalculo As String

            If Rdb_Rot_Mediana.Checked Then
                _RotCalculo = "D"
            End If

            If Rdb_Rot_Promedio.Checked Then
                _RotCalculo = "P"
            End If

            Me.Enabled = False

            Dim Fm As New Frm_AsisCompra_Proyeccion_Informe(_Tabla_Paso,
                                                            _Identificador_NodoPadre,
                                                            _Ud,
                                                            _Filtro_Nodos,
                                                            _Porc_Creciminto,
                                                            _Dias_Proyeccion,
                                                            _Marca_Proyeccion,
                                                            _Dias_Abastecer,
                                                            _Campos,
                                                            _RotCalculo,
                                                            _Sql_Consulta_Actualiza_Stock,
                                                            _Clas_Asistente_Compras)

            Fm.Pro_Input_Redondeo = Input_Proyeccion_Redondeo.Value
            Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                Case 1
                    Fm.Pro_Proyeccion = Frm_AsisCompra_Proyeccion_Informe.Enum_Proyeccion.Diaria
                Case 7
                    Fm.Pro_Proyeccion = Frm_AsisCompra_Proyeccion_Informe.Enum_Proyeccion.Semanal
                Case 30
                    Fm.Pro_Proyeccion = Frm_AsisCompra_Proyeccion_Informe.Enum_Proyeccion.Mensual
            End Select

            Fm.Rdb_Proyeccion_Promedio_Diario.Checked = Rdb_Rot_Promedio.Checked
            Fm.Rdb_Proyeccion_Rotacion_Diaria.Checked = Rdb_Rot_Mediana.Checked

            Fm.ShowDialog(Me)
            Input_Proyeccion_Redondeo.Value = Fm.Pro_Input_Redondeo
            Fm.Dispose()

        Else
            MessageBoxEx.Show(Me, "Debe indicar la agrupación de asociación de productos", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Me.Enabled = True

    End Sub

    Sub Sb_Cargar_Combo()

        caract_combo(Cmb_Padre_Asociacion_Productos)
        Consulta_sql = "Select '' As Padre,'' As Hijo Union" & vbCrLf &
                       "Select Codigo_Nodo AS Padre,Descripcion AS Hijo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Es_Padre = 1 And Codigo_Nodo In (Select Distinct Identificacdor_NodoPadre" & Space(1) &
                       "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Padre = 0 And Clas_Unica_X_Producto = 1)" & vbCrLf &
                       "Order By Hijo"
        Cmb_Padre_Asociacion_Productos.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Padre_Asociacion_Productos.SelectedValue = ""

        caract_combo(Cmb_Proyeccion)

        Sb_Cargar_Combo_Dias(Cmb_Metodo_Abastecer_Dias_Meses)
        Sb_Cargar_Combo_Dias(Cmb_Tiempo_Reposicion_Dias_Meses)
        Sb_Cargar_Combo_Dias(Cmb_Proyeccion)

    End Sub

    Sub Sb_Cargar_Combo_Dias(ByVal Cmb As DevComponents.DotNetBar.Controls.ComboBoxEx)

        caract_combo(Cmb)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = 1 : dr("Hijo") = "Dias" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Padre") = 7 : dr("Hijo") = "Semanas" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = 30 : dr("Hijo") = "Meses" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        Cmb.DataSource = dt
        Cmb.SelectedValue = 1

    End Sub

    'Sub Sb_Parametros_Informe_Sql(ByVal _Actualizar As Boolean)

    '    Dim _FechaHoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
    '    Dim _Fecha_Hoy = Format(_FechaHoy, "dd-MM-yyyy")


    '    '   Tiempo para aprobicionamiento
    '    _Sql.Sb_Parametro_Informe_Sql(Cmb_Metodo_Abastecer_Dias_Meses, "Compras_Asistente", Cmb_Metodo_Abastecer_Dias_Meses.Name,
    '                                             Class_SQLite.Enum_Type._ComboBox, Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue, _Actualizar)
    '    _Sql.Sb_Parametro_Informe_Sql(Input_Dias_a_Abastecer, "Compras_Asistente",
    '                                             Input_Dias_a_Abastecer.Name, Class_SQLite.Enum_Type._Double, Input_Dias_a_Abastecer.Value, _Actualizar)

    '    '   Tiempo de reposición (Lead Time, _Actualizar)
    '    _Sql.Sb_Parametro_Informe_Sql(Cmb_Tiempo_Reposicion_Dias_Meses, "Compras_Asistente",
    '                                             Cmb_Tiempo_Reposicion_Dias_Meses.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue, _Actualizar)
    '    _Sql.Sb_Parametro_Informe_Sql(Input_Tiempo_Reposicion, "Compras_Asistente",
    '                                             Input_Tiempo_Reposicion.Name, Class_SQLite.Enum_Type._Double, Input_Tiempo_Reposicion.Value, _Actualizar)

    '    '   Considera Sabado
    '    _Sql.Sb_Parametro_Informe_Sql(Chk_Sabado, "Compras_Asistente",
    '                                             Chk_Sabado.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sabado.Checked, _Actualizar)
    '    '   Considera Domingo
    '    _Sql.Sb_Parametro_Informe_Sql(Chk_Domingo, "Compras_Asistente",
    '                                             Chk_Domingo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Domingo.Checked, _Actualizar)

    '    '   Unidad de compra UD1
    '    _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud1_Compra, "Compras_Asistente",
    '                                             Rdb_Ud1_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud1_Compra.Checked, _Actualizar)
    '    '   Unidad de compra UD1
    '    _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud2_Compra, "Compras_Asistente",
    '                                             Rdb_Ud2_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud2_Compra.Checked, _Actualizar)

    '    '   Ticket Solo Stock critico
    '    _Sql.Sb_Parametro_Informe_Sql(Chk_Mostrar_Solo_Stock_Critico, "Compras_Asistente",
    '                                             Chk_Mostrar_Solo_Stock_Critico.Name, Class_SQLite.Enum_Type._Boolean, Chk_Mostrar_Solo_Stock_Critico.Checked, _Actualizar)


    '    '  Redondeo
    '    _Sql.Sb_Parametro_Informe_Sql(Input_Proyeccion_Redondeo, "Compras_Asistente",
    '                                             Input_Proyeccion_Redondeo.Name, Class_SQLite.Enum_Type._Double, Input_Proyeccion_Redondeo.Value, _Actualizar)


    '    '  Redondeo
    '    _Sql.Sb_Parametro_Informe_Sql(Txt_Padre_Asociacion_Productos, "Compras_Asistente",
    '                                             Txt_Padre_Asociacion_Productos.Name, Class_SQLite.Enum_Type._String, Txt_Padre_Asociacion_Productos.Tag, _Actualizar)

    '    Txt_Padre_Asociacion_Productos.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
    '                                                            "Descripcion", "Codigo_Nodo = " & Txt_Padre_Asociacion_Productos.Tag)


    'End Sub

    Sub Sb_Parametros_Informe_Conf_Local(_Abrir As Boolean)

        With My.Settings

            If _Abrir Then

                'Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = .Asis_Compra_Metodo_Abastecer_Dias_Meses
                'Input_Dias_a_Abastecer.Value = .Asis_Compra_Dias_a_Abastecer
                'Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = .Asis_Compra_Tiempo_Reposicion_Dias_Meses
                'Input_Tiempo_Reposicion.Value = .Asis_Compra_Tiempo_Reposicion
                'Chk_Sabado.Checked = .Asis_Compra_Sabado
                'Chk_Domingo.Checked = .Asis_Compra_Domingo
                'Rdb_Ud1_Compra.Checked = .Asis_Compra_Ud1_Compra
                'Rdb_Ud2_Compra.Checked = .Asis_Compra_Ud2_Compra
                Input_Proyeccion_Redondeo.Value = .Asis_Compra_Proyeccion_Redondeo
                Txt_Padre_Asociacion_Productos.Tag = .Asis_Compra_Padre_Asociacion_Productos

                Txt_Padre_Asociacion_Productos.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                        "Descripcion", "Codigo_Nodo = " & Txt_Padre_Asociacion_Productos.Tag)

            Else

                '.Asis_Compra_Metodo_Abastecer_Dias_Meses = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                '.Asis_Compra_Dias_a_Abastecer = Input_Dias_a_Abastecer.Value
                '.Asis_Compra_Tiempo_Reposicion_Dias_Meses = Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue
                '.Asis_Compra_Tiempo_Reposicion = Input_Tiempo_Reposicion.Value
                '.Asis_Compra_Sabado = Chk_Sabado.Checked
                '.Asis_Compra_Domingo = Chk_Domingo.Checked
                '.Asis_Compra_Ud1_Compra = Rdb_Ud1_Compra.Checked
                '.Asis_Compra_Ud2_Compra = Rdb_Ud2_Compra.Checked
                '.Asis_Compra_Mostrar_Solo_Stock_Critico = Chk_Mostrar_Solo_Stock_Critico.Checked
                .Asis_Compra_Proyeccion_Redondeo = Input_Proyeccion_Redondeo.Value
                .Asis_Compra_Padre_Asociacion_Productos = Txt_Padre_Asociacion_Productos.Tag

                .Save()

            End If

        End With

    End Sub


    Private Sub Frm_AsisCompra_Proyeccion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Arbol_Asociaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Arbol_Asociaciones.Click
        If Fx_Tiene_Permiso(Me, "Tbl00002") Then
            Dim Fm As New Frm_Arbol_Asociacion_02(False, 0, False, Frm_Arbol_Asociacion_02.Enum_Clasificacion.Unica, 0)
            Fm.Pro_Identificador_NodoPadre = 0
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Cmb_Proyeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Proyeccion.SelectedValue

        Select Case _Valor

            Case 1
                Input_Cant_Campos.MaxValue = 60
                Input_Cant_Campos.Value = 30
            Case 7
                Input_Cant_Campos.MaxValue = 40
                Input_Cant_Campos.Value = 12
            Case 15
                Input_Cant_Campos.MaxValue = 24
                Input_Cant_Campos.Value = 12
            Case 30
                Input_Cant_Campos.MaxValue = 12
                Input_Cant_Campos.Value = 12
            Case Else

        End Select

    End Sub

    Private Sub Cmb_Dias_Abastecer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue

        Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = _Valor

        Select Case _Valor

            Case 1
                Input_Dias_a_Abastecer.MaxValue = 60
                Input_Dias_a_Abastecer.Value = 7
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 1
            Case 7
                Input_Dias_a_Abastecer.MaxValue = 4
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Dias_a_Abastecer.MaxValue = 6
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub

    Private Sub Cmb_Tiempo_Reposicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue

        Select Case _Valor

            Case 1
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 7
            Case 7
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub


    Private Sub Btn_Padre_Asociacion_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Padre_Asociacion_Productos.Click

        Dim _Identificacdor_NodoPadre As Integer
        Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        Dim Fm As New Frm_Arbol_Asociacion_05_Busqueda(
        Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Unica_Padres_Seleccion, False)
        Fm.Pro_Identificacdor_NodoPadre = _Nodo_Raiz_Asociados
        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            Txt_Padre_Asociacion_Productos.Tag = Fm.Pro_Row_Nodo_Seleccionado.Item("Codigo_Nodo")
            Txt_Padre_Asociacion_Productos.Text = Trim(Fm.Pro_Row_Nodo_Seleccionado.Item("Descripcion"))

        End If
        Fm.Dispose()

    End Sub

    Private Sub Frm_AsisCompra_Proyeccion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Parametros_Informe_Conf_Local(False)
    End Sub

End Class
