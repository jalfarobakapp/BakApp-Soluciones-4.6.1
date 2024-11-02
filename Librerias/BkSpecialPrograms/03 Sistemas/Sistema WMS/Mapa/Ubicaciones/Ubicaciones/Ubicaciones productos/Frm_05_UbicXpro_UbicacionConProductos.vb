Imports DevComponents.DotNetBar

Public Class Frm_05_UbicXpro_UbicacionConProductos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String
    Dim _Id_Mapa As String
    Dim _Codigo_Sector As String
    Dim _Codigo_Ubic As String

    Dim _Tbl_UbicXpro As DataTable
    Dim _Row_Bodega As DataRow
    Dim _Row_Ubicacion As DataRow

    Dim _Producto_Op As New Frm_BkpPostBusquedaEspecial_Mt

    Public Sub New(RowBodega As DataRow,
                   Id_Mapa As Integer,
                   Codigo_Sector As String,
                   Codigo_Ubic As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Bodega = RowBodega
        _Id_Mapa = Id_Mapa
        _Codigo_Sector = Codigo_Sector
        _Codigo_Ubic = Codigo_Ubic

        _Empresa = _Row_Bodega.Item("EMPRESA")
        _Sucursal = _Row_Bodega.Item("KOSU")
        _Bodega = _Row_Bodega.Item("KOBO")

        If Global_Thema = 2 Then
            Btn_Buscar_Producto.ForeColor = Color.White
            Btn_Seleccion_Multiple.ForeColor = Color.White
            Btn_Imprimir_Etiquetas.ForeColor = Color.White
        End If

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_05_UbicXpro_UbicacionConProductos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        LblEmpresa.Text = _Row_Bodega.Item("RAZON")
        LblSucursal.Text = _Row_Bodega.Item("NOKOSU")
        LblBodega.Text = _Row_Bodega.Item("NOKOBO")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                       "Where Codigo_Ubic = '" & _Codigo_Ubic & "' And Empresa = '" & ModEmpresa & "' And Codigo_Sector = '" & _Codigo_Sector & "'"
        _Row_Ubicacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Actualizar_Grilla_Ubic()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.CellDoubleClick, AddressOf Grilla_CellDoubleClick
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

        AddHandler Rdb_Ud1.CheckedChanged, AddressOf Rdb_Ud_CheckedChanged
        AddHandler Rdb_Ud2.CheckedChanged, AddressOf Rdb_Ud_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla_Ubic()

        _Tbl_UbicXpro = Nothing

        Dim _Ud As Integer

        If Rdb_Ud1.Checked Then
            _Ud = 1
        Else
            _Ud = 2
        End If

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Zu.Semilla,Zu.Id_Mapa,Zu.Empresa,Zu.Sucursal,Zu.Bodega,Zu.Codigo,Zu.Codigo_Sector,Zu.Codigo_Ubic," & vbCrLf &
                       "Isnull((Select Top 1 KOPRAL From TABCODAL Td Where Td.KOPR = Zu.Codigo And KOEN = ''),'') As CodBarra," & vbCrLf &
                       "NOKOPR As Descripcion,Primaria,Isnull(Mt.STFI1,0) As 'STFI1',Isnull(Mt.STFI2,0) As 'STFI2',Stock_Ubic_Ud1,Stock_Ubic_Ud2," & vbCrLf &
                       "Isnull(InSa.CodFuncionario_Ing,'') As 'CodFuncionario_Ing',Isnull(Tis.NOKOFU,'') As 'NomFuncionario_Ing',InSa.FechaIngreso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Ubicacion Zu" & vbCrLf &
                       "Left Join MAEPR Mp On Codigo = KOPR" & vbCrLf &
                       "Left Join MAEST Mt On Mt.EMPRESA = Zu.Empresa And Mt.KOSU = Zu.Sucursal And Mt.KOBO = Zu.Bodega And Mt.KOPR = Zu.Codigo" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal InSa On InSa.Id_Mapa = Zu.Id_Mapa And Zu.Semilla = InSa.Semilla" & vbCrLf &
                       "Left Join TABFU Tis On Tis.KOFU = InSa.CodFuncionario_Ing" & vbCrLf &
                       "Where Zu.Empresa = '" & _Empresa & "' " & vbCrLf &
                       "And Zu.Sucursal = '" & _Sucursal & "' " & vbCrLf &
                       "And Zu.Bodega = '" & _Bodega & "' " & vbCrLf &
                       "And Zu.Id_Mapa = " & _Id_Mapa & vbCrLf &
                       "And Zu.Codigo_Sector = '" & _Codigo_Sector & "' " & vbCrLf &
                       "And Zu.Codigo_Ubic = '" & _Codigo_Ubic & "'"


        Consulta_sql = "Select Cast(0 As Bit) As Chk,Zu.Semilla,Zu.Id_Mapa,Zu.Empresa,Zu.Sucursal,Zu.Bodega,Zu.Codigo,Zu.Codigo_Sector,Zu.Codigo_Ubic," & vbCrLf &
                       "Isnull((Select Top 1 KOPRAL From TABCODAL Td Where Td.KOPR = Zu.Codigo And KOEN = ''),'') As CodBarra," & vbCrLf &
                       "NOKOPR As Descripcion,Primaria,Isnull(Mt.STFI1,0) As 'STFI1',Isnull(Mt.STFI2,0) As 'STFI2',Stock_Ubic_Ud1,Stock_Ubic_Ud2" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Ubicacion Zu" & vbCrLf &
                       "Left Join MAEPR Mp On Codigo = KOPR" & vbCrLf &
                       "Left Join MAEST Mt On Mt.EMPRESA = Zu.Empresa And Mt.KOSU = Zu.Sucursal And Mt.KOBO = Zu.Bodega And Mt.KOPR = Zu.Codigo" & vbCrLf &
                       "Where Zu.Empresa = '" & _Empresa & "' " & vbCrLf &
                       "And Zu.Sucursal = '" & _Sucursal & "' " & vbCrLf &
                       "And Zu.Bodega = '" & _Bodega & "' " & vbCrLf &
                       "And Zu.Id_Mapa = " & _Id_Mapa & vbCrLf &
                       "And Zu.Codigo_Sector = '" & _Codigo_Sector & "' " & vbCrLf &
                       "And Zu.Codigo_Ubic = '" & _Codigo_Ubic & "'"

        _Tbl_UbicXpro = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_UbicXpro
            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex As Integer = 0

            '.Columns("Chk").Width = 30
            '.Columns("Chk").HeaderText = "Sel."
            '.Columns("Chk").Visible = True
            '.Columns("Chk").ReadOnly = False
            '.Columns("Chk").Visible = True
            '.Columns("Chk").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Codigo").Width = 90
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodBarra").Width = 130
            .Columns("CodBarra").HeaderText = "Código de Barras"
            .Columns("CodBarra").Visible = True
            .Columns("CodBarra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 330
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Stock_Ubic_Ud" & _Ud).Width = 120
            .Columns("Stock_Ubic_Ud" & _Ud).HeaderText = "Stock en ubicación Ud" & _Ud
            .Columns("Stock_Ubic_Ud" & _Ud).Visible = True
            .Columns("Stock_Ubic_Ud" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Ubic_Ud" & _Ud).DefaultCellStyle.Format = "###,##.##"
            .Columns("Stock_Ubic_Ud" & _Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Public Function Fx_Agregar_producto_ubicacion(_Formulario As Form,
                                                   _Codigo As String,
                                                  Optional _Ver_Mensaje As Boolean = True,
                                                  Optional _EsPrimaria As Boolean = False) As Boolean

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                   "Empresa = '" & _Empresa & "' and Sucursal = '" & _Sucursal &
                                                 "' And Bodega = '" & _Bodega &
                                                 "' And Id_Mapa = " & _Id_Mapa &
                                                 "  And Codigo_Sector = '" & _Codigo_Sector &
                                                 "' And Codigo_Ubic = '" & _Codigo_Ubic &
                                                 "' And Codigo = '" & _Codigo & "'"))

        If Not _Reg Then

            _Reg = CBool((_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                             "Empresa = '" & _Empresa & "' and Sucursal = '" & _Sucursal &
                                           "' And Bodega = '" & _Bodega &
                                           "' And Codigo = '" & _Codigo & "'")))

            Dim _Primaria As Integer = 0

            If Not _Reg Then _Primaria = 1

            If _EsPrimaria Then _Primaria = 1

            Dim _Semilla As Integer

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion(Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo,Primaria) Values" & vbCrLf &
                           "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','" & _Codigo_Ubic & "','" & _Codigo & "'," & _Primaria & ")"

            If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Semilla) Then

                Dim _TipoMov = "Ingreso"
                Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Semilla,Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo," &
                               "CodFuncionario_Ing,NombreEquipo,Ingreso,FechaIngreso) Values " & vbCrLf &
                               "(" & _Semilla & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','" & _Codigo_Ubic & "'" &
                               ",'" & _Codigo & "','" & FUNCIONARIO & "','" & _NombreEquipo & "',1,Getdate())"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If _Global_Row_Configuracion_General.Item("Utilizar_Ubicaciones_WCM") Then

                    If CBool(_Primaria) Then

                        Consulta_sql = "Update TABBOPR Set DATOSUBIC = '" & _Codigo_Ubic & "'" & vbCrLf &
                                       "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' AND KOPR = '" & _Codigo & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                End If

                If _Ver_Mensaje Then

                    Beep()
                    ToastNotification.Show(_Formulario, "DATOS GUARDADOS CORRECTAMENTE",
                                       My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                End If

                Return True

            End If

        Else
            If _Ver_Mensaje Then
                Beep()
                ToastNotification.Show(_Formulario, "¡Este producto ya esta asociado a esta ubicación!",
                                       My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If
        End If

    End Function

    Private Sub BtnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles BtnExportarExcel.Click
        Dim _Nombre = _Codigo_Sector
        ExportarTabla_JetExcel_Tabla(_Tbl_UbicXpro, Me, _Nombre)
    End Sub

    Private Sub Frm_05_UbicXpro_UbicacionConProductos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F2 Then
            Sb_Asociar_Producto()
        ElseIf e.KeyValue = Keys.F3 Then
            Sb_Asociar_Productos_Masivamente()
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Buscar_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Producto.Click
        Sb_Asociar_Producto()
    End Sub

    Private Sub Sb_Asociar_Producto()

        'Asociar ubicación al producto
        If Fx_Tiene_Permiso(Me, "Ubic0004") Then

            Dim _Codigo As String
            Dim _Descripcion As String
            Dim _RowProducto As DataRow
            Dim _Aceptar As Boolean

            Dim _Asociar As Boolean

            _Aceptar = InputBox_Bk(Me,
                                  "Ingrese el código principal o de barras para asociar",
                                  "Asociar código a la ubicación",
                                  _Codigo,
                                  False,
                                  _Tipo_Mayus_Minus.Normal,
                                  22,
                                  True,
                                  _Tipo_Imagen.Barra,
                                  True)

            If _Aceptar Then

                If String.IsNullOrEmpty(_Codigo.Trim) Then
                    _RowProducto = Fx_Buscar_Producto(_Codigo)
                End If

                If Not (_RowProducto Is Nothing) Then

                    _Codigo = _RowProducto.Item("KOPR")
                    _Descripcion = _RowProducto.Item("NOKOPR")
                    _Asociar = True

                Else

                    Dim _CodAlternativo = _Codigo

                    Consulta_sql = "Select top 1 KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigo & "'"
                    _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_RowProducto Is Nothing) Then

                        _Codigo = _RowProducto.Item("KOPR")
                        _Descripcion = _RowProducto.Item("NOKOPR")
                        _Asociar = True

                    Else

                        Consulta_sql = "Select Top 1 Mp.KOPR,Mp.NOKOPR 
                                        From TABCODAL Td Inner Join MAEPR Mp On Mp.KOPR = Td.KOPR 
                                        Where Td.KOPRAL = '" & _CodAlternativo & "' And Td.KOEN = ''"
                        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If Not (_RowProducto Is Nothing) Then

                            If Not (_RowProducto Is Nothing) Then
                                _Codigo = _RowProducto.Item("KOPR")
                                _Descripcion = _RowProducto.Item("NOKOPR")
                                _Asociar = True
                            End If

                        Else

                            MessageBoxEx.Show(Me, "Código no encontrado", "Asociar producto", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        End If

                    End If

                End If

            End If

            If _Asociar Then

                _Codigo = _Codigo.Trim

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                  "Empresa = '" & _Empresa & "' and Sucursal = '" & _Sucursal &
                                                "' And Bodega = '" & _Bodega &
                                                "' And Id_Mapa = '" & _Id_Mapa &
                                                "' And Codigo_Sector = '" & _Codigo_Sector &
                                                "' And Codigo_Ubic = '" & _Codigo_Ubic &
                                                "' And Codigo = '" & _Codigo & "'"))

                If Not _Reg Then

                    If Fx_Agregar_producto_ubicacion(Me, _Codigo, False) Then

                        MessageBoxEx.Show(Me, "Producto asociado correctamente" & vbCrLf & vbCrLf &
                                                              "Código: " & _Codigo & ", " & _Descripcion, "Asociar producto",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                Else

                    MessageBoxEx.Show(Me, "Este producto ya esta asociado" & vbCrLf & vbCrLf &
                                      "Código: " & _Codigo & ", " & _Descripcion, "Asociar producto",
                                       MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

                Sb_Actualizar_Grilla_Ubic()
                'Sb_Asociar_Producto()

            End If

        End If

    End Sub

    Private Function Fx_Buscar_Producto(_Codigo As String) As DataRow

        Dim _RowProducto As DataRow

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt 'Frm_BuscarXProducto_Mt
        With Fm
            .Pro_Empresa = _Empresa
            .Pro_Sucursal = _Sucursal
            .Pro_Bodega = _Bodega
            .Pro_Actualizar_Precios = False
            .Pro_Mostrar_Info = False
            .BtnBuscarAlternativos.Visible = True
            .Pro_Mostrar_Imagenes = True
            .BtnExportaExcel.Visible = True
            .Pro_Tipo_Lista = "P"
            .Pro_Sucursal_Busqueda = ModSucursal
            .Pro_Bodega_Busqueda = ModBodega
            .Pro_Lista_Busqueda = ModListaPrecioVenta
            '.CambiarCodigoToolStripMenuItem.Visible = True
            .ShowDialog(Me)

            If .Pro_Seleccionado Then
                _RowProducto = .Pro_RowProducto
            End If
            .Dispose()

            Return _RowProducto
        End With

    End Function

    Sub Sb_Asociar_Productos_Masivamente()

        Try

            Me.Enabled = False

            Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"
            Dim _Filtrar As New Clas_Filtros_Random(Me)
            Dim _Tbl_Productos As DataTable
            Dim _Filtrar_Pr As Boolean

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                                   False, False) Then

                _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    _Tbl_Productos = Nothing
                End If
                _Filtrar_Pr = True
            End If

            Dim _Contador = 0

            If _Filtrar_Pr Then

                For Each _Fila As DataRow In _Tbl_Productos.Rows

                    Dim _Codigo As String = _Fila.Item("Codigo")

                    If Fx_Agregar_producto_ubicacion(Me, _Codigo, False) Then
                        _Contador += 1
                    End If

                Next

            End If

            If CBool(_Contador) Then

                Beep()
                ToastNotification.Show(Me, "DATOS GUARDADOS CORRECTAMENTE (" & _Contador & ")",
                                       My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                Sb_Actualizar_Grilla_Ubic()
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Seleccion_Multiple_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Seleccion_Multiple.Click
        Sb_Asociar_Productos_Masivamente()
    End Sub

    Sub Sb_Quitar_Productos_Masivamente()

        If Not Fx_Tiene_Permiso(Me, "Ubic0006") Then
            Return
        End If

        Try

            Me.Enabled = False

            Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN' And KOPR In " &
                                              "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion Where " &
                                              "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic = '" & _Codigo_Ubic & "')"
            Dim _Filtrar As New Clas_Filtros_Random(Me)
            Dim _Tbl_Productos As DataTable
            Dim _Filtrar_Pr As Boolean

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                                   False, False) Then

                _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
                _Filtrar_Pr = True

            End If

            Dim _Contador = 0
            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = String.Empty

            If _Filtrar_Pr Then

                For Each _Fila As DataRow In _Tbl_Productos.Rows

                    Dim _Codigo As String = _Fila.Item("Codigo")

                    Dim _Semilla = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_Ubicacion", "Semilla",
                                                      "Id_Mapa = " & _Id_Mapa &
                                                      " And Codigo_Sector = '" & _Codigo_Sector &
                                                      "' And Codigo_Ubic = '" & _Codigo_Ubic &
                                                      "' And Codigo = '" & _Codigo & "'")


                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Set " & vbCrLf &
                                    "Empresa = '" & _Empresa & "'" &
                                    ",Sucursal = '" & _Sucursal & "'" &
                                    ",Bodega = '" & _Bodega & "'" &
                                    ",Id_Mapa = " & _Id_Mapa &
                                    ",Codigo_Sector = '" & _Codigo_Sector & "'" &
                                    ",Codigo_Ubic = '" & _Codigo_Ubic & "'" &
                                    ",Codigo = '" & _Codigo & "'" &
                                    ",CodFuncionario_Sal = '" & FUNCIONARIO & "'" &
                                    ",NombreEquipo = '" & _NombreEquipo & "'" &
                                    ",Salida = 1" &
                                    ",FechaSalida = GetDate()" & vbCrLf &
                                    "Where Semilla = " & _Semilla & vbCrLf

                    Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Semilla = " & _Semilla & vbCrLf

                    If _Global_Row_Configuracion_General.Item("Utilizar_Ubicaciones_WCM") Then

                        Consulta_sql += "Update TABBOPR Set DATOSUBIC = ''" & vbCrLf &
                                       "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' AND KOPR = '" & _Codigo & "'" & vbCrLf

                    End If

                    _Contador += 1

                Next


            End If

            If CBool(_Contador) Then

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Beep()
                ToastNotification.Show(Me, "Productos quitados correctamente (" & _Contador & ")",
                                       My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                Sb_Actualizar_Grilla_Ubic()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub


#Region "ENUMERAR FILAS"

    Private Sub Btn_Imprimir_Etiquetas_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Etiquetas.Click

        If CBool(_Tbl_UbicXpro.Rows.Count) Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(0)

            Dim _Id_Mapa = _Fila.Cells("Id_Mapa").Value
            Dim _Codigo_Sector = _Fila.Cells("Codigo_Sector").Value
            Dim _Primaria = _Fila.Cells("Primaria").Value
            Dim _Codigo_Ubic = _Fila.Cells("Codigo_Ubic").Value

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_UbicXpro, "", "KOPR", False, False, "'")

            Consulta_sql = "Select Cast(1 as Bit) As Chk,KOPR As Codigo,NOKOPR As Descripcion From MAEPR Where KOPR In " & _Filtro_Productos
            Dim _TblProductos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim Fm As New Frm_ImpBarras_PorProducto
            Fm.Codigo_Ubic = _Codigo_Ubic
            Fm.Chk_Imprimir_Todas_Las_Ubicaciones.Visible = False
            Fm.Pro_Tbl_Filtro_Productos = _TblProductos
            Fm.Pro_Cantidad_Uno = True
            Fm.BtnBuscarProducto.Visible = False
            Fm.BtnLimpiar.Visible = False
            Fm.Grupo_Ubicaciones.Enabled = False
            Fm.Grupo_Lista_Precios.Enabled = True
            Fm.Btn_imprimir_Archivo.Visible = False
            Fm.Text = Fm.Text & " - Ubicación(" & _Codigo_Ubic & ")"
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            MessageBoxEx.Show(Me, "No hay productos para las etiquetas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

#End Region

    Private Sub Rdb_Ud_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If sender.Checked = True Then
            Sb_Actualizar_Grilla_Ubic()
        End If
    End Sub


    Private Sub Btn_Mnu_Ver_Ubicaciones_Del_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ver_Ubicaciones_Del_Producto.Click
        If Fx_Tiene_Permiso(Me, "Ubic0002") Then

            Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
            Dim _Descripcion As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value

            If Not String.IsNullOrEmpty(_Codigo) Then

                Dim Fr As New Frm_01_UbicXpro(_Codigo)
                Fr.BtnAgregarUbicXProdBuscar.Visible = False
                Fr.BtnAgregarUbicXProdDirecto.Visible = False
                Fr.ShowDialog(Me)
                Fr.Dispose()
                Sb_Actualizar_Grilla_Ubic()

            End If
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Call Btn_Mnu_Ver_Ubicaciones_Del_Producto_Click(Nothing, Nothing)
    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = CType(sender, DataGridView).Rows(CType(sender, DataGridView).CurrentRow.Index)
                    Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

                    ShowContextMenu(Menu_Contextual_Ubicacion)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Mnu_Eliminar_Ubicacion_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Eliminar_Ubicacion.Click

        If Not Fx_Tiene_Permiso(Me, "Ubic0006") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Semilla = _Fila.Cells("Semilla").Value
            Dim _Id_Mapa As Integer = _Fila.Cells("Id_Mapa").Value
            Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
            Dim _Codigo_Ubic As String = _Fila.Cells("Codigo_Ubic").Value
            Dim _Empresa As String = _Fila.Cells("Empresa").Value
            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value
            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            'If Grilla.Rows.Count > 1 Then

            '    MessageBoxEx.Show(Me, "¡Esta es la ubicación por defecto del producto" & vbCrLf &
            '                      "no se puede eliminar antes que las demás!", "Validación",
            '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Return

            'End If

            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                 "Eliminar fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion_IngSal", "Semilla = " & _Semilla)

            Consulta_sql = String.Empty

            If CBool(_Reg) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Set " & vbCrLf &
                               "Empresa = '" & _Empresa & "'" &
                               ",Sucursal = '" & _Sucursal & "'" &
                               ",Bodega = '" & _Bodega & "'" &
                               ",Id_Mapa = " & _Id_Mapa &
                               ",Codigo_Sector = '" & _Codigo_Sector & "'" &
                               ",Codigo_Ubic = '" & _Codigo_Ubic & "'" &
                               ",Codigo = '" & _Codigo & "'" &
                               ",CodFuncionario_Sal = '" & FUNCIONARIO & "'" &
                               ",NombreEquipo = '" & _NombreEquipo & "'" &
                               ",Salida = 1" &
                               ",FechaSalida = GetDate()" & vbCrLf &
                               "Where Semilla = " & _Semilla & vbCrLf
            Else
                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Semilla,Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo," &
                               "CodFuncionario_Sal,NombreEquipo,Salida,FechaSalida) Values " & vbCrLf &
                               "(" & _Semilla & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','" & _Codigo_Ubic & "'" &
                               ",'" & _Codigo & "','" & FUNCIONARIO & "','" & _NombreEquipo & "',1,Getdate())" & vbCrLf
            End If

            Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Semilla = " & _Semilla

            If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Global_Row_Configuracion_General.Item("Utilizar_Ubicaciones_WCM") Then

                Consulta_sql = "Update TABBOPR Set DATOSUBIC = ''" & vbCrLf &
                               "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' AND KOPR = '" & _Codigo & "'"
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            End If

            Grilla.Rows.RemoveAt(_Fila.Index)


    End Sub

    Private Sub Mnu_Btn_Ver_Informacion_de_producto_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Ver_Informacion_de_producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)
            Dim _FechaIng As Date = _Fila.Cells("FechaIngreso").Value
            Lbl_InfoFechaIngUbic.Text = "Fecha de ingreso: " & FormatDateTime(_FechaIng, DateFormat.ShortDate)
            Lbl_InfoFechaIngUbic.Visible = True
        Catch ex As Exception
            Lbl_InfoFechaIngUbic.Visible = False
        End Try
        Me.Refresh()
    End Sub

    Private Sub Grilla_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla.DataError

    End Sub

    Private Sub Btn_Seleccion_MultipleQuitar_Click(sender As Object, e As EventArgs) Handles Btn_Seleccion_MultipleQuitar.Click
        Sb_Quitar_Productos_Masivamente()
    End Sub
End Class
