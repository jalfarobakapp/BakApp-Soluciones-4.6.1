﻿Imports DevComponents.DotNetBar

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
    Dim _RowBodega As DataRow

    Dim _Producto_Op As New Frm_BkpPostBusquedaEspecial_Mt

    Public Sub New(ByVal RowBodega As DataRow,
                   ByVal Id_Mapa As Integer,
                   ByVal Codigo_Sector As String,
                   ByVal Codigo_Ubic As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _RowBodega = RowBodega
        _Id_Mapa = Id_Mapa
        _Codigo_Sector = Codigo_Sector
        _Codigo_Ubic = Codigo_Ubic

        _Empresa = _RowBodega.Item("EMPRESA")
        _Sucursal = _RowBodega.Item("KOSU")
        _Bodega = _RowBodega.Item("KOBO")

        If Global_Thema = 2 Then
            Btn_Buscar_Producto.ForeColor = Color.White
            Btn_Seleccion_Multiple.ForeColor = Color.White
            Btn_Imprimir_Etiquetas.ForeColor = Color.White
        End If

        'Label3.Text += ": " & _Codigo_Ubic

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_05_UbicXpro_UbicacionConProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LblEmpresa.Text = _RowBodega.Item("RAZON")
        LblSucursal.Text = _RowBodega.Item("NOKOSU")
        LblBodega.Text = _RowBodega.Item("NOKOBO")

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

        Dim _Condicion_Maest = "Where EMPRESA = '" & _Empresa & "'" & vbCrLf &
                               "AND KOSU = '" & _Sucursal & "'" & vbCrLf &
                               "AND KOBO = '" & _Bodega & "'" & vbCrLf &
                               "AND KOPR = Codigo"

        Consulta_sql = "SELECT *," &
                       "Isnull((Select Top 1 KOPRAL From TABCODAL Td Where Td.KOPR = Codigo And KOEN = ''),'') As CodBarra," &
                       "NOKOPR As Descripcion,Primaria," &
                       "Isnull((Select Sum(STFI1) From MAEST " & _Condicion_Maest & "),0) As STFI1," &
                       "Isnull((Select Sum(STFI2) From MAEST " & _Condicion_Maest & "),0) As STFI2," & vbCrLf &
                       "Isnull((Select Top 1 Stock_Ud1 From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto Zsu " & vbCrLf &
                       "Where Zsu.Empresa = Zu.Empresa And " & vbCrLf &
                       "Zsu.Sucursal = Zu.Sucursal And " & vbCrLf &
                       "Zsu.Bodega= Zu.Bodega and Zsu.Codigo_Ubic = Zu.Codigo_Ubic And Zsu.Codigo = Zu.Codigo),0) As Stock_Ubic_Ud1," & vbCrLf &
                       "Isnull((Select Top 1 Stock_Ud2 From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto Zsu " & vbCrLf &
                       "Where Zsu.Empresa = Zu.Empresa And " & vbCrLf &
                       "Zsu.Sucursal = Zu.Sucursal And " & vbCrLf &
                       "Zsu.Bodega= Zu.Bodega and Zsu.Codigo_Ubic = Zu.Codigo_Ubic And Zsu.Codigo = Zu.Codigo),0) As Stock_Ubic_Ud2" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Prod_Ubicacion Zu LEFT OUTER JOIN" & vbCrLf &
                       "MAEPR On Codigo = KOPR" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' and Sucursal = '" & _Sucursal & "' 
                        And Bodega = '" & _Bodega & "' --And Id_Mapa = " & _Id_Mapa & "
                        And Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic = '" & _Codigo_Ubic & "'"

        _Tbl_UbicXpro = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_UbicXpro
            OcultarEncabezadoGrilla(Grilla)

            .Columns("Codigo").Width = 90
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = 0

            .Columns("CodBarra").Width = 130
            .Columns("CodBarra").HeaderText = "Código de Barras"
            .Columns("CodBarra").Visible = True
            .Columns("CodBarra").DisplayIndex = 1

            .Columns("Descripcion").Width = 310
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = 2

            .Columns("Stock_Ubic_Ud" & _Ud).Width = 140
            .Columns("Stock_Ubic_Ud" & _Ud).HeaderText = "Stock en ubicación Ud" & _Ud
            .Columns("Stock_Ubic_Ud" & _Ud).Visible = True
            .Columns("Stock_Ubic_Ud" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Ubic_Ud" & _Ud).DefaultCellStyle.Format = "###,##.##"
            .Columns("Stock_Ubic_Ud" & _Ud).DisplayIndex = 3

            '.Columns("STFI" & _Ud).Width = 80
            '.Columns("STFI" & _Ud).HeaderText = "Stock en bodega Ud" & _Ud
            '.Columns("STFI" & _Ud).Visible = True
            '.Columns("STFI" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("STFI" & _Ud).DefaultCellStyle.Format = "###,##.##"
            '.Columns("STFI" & _Ud).DisplayIndex = 4

        End With



    End Sub

    Public Function Fx_Agregar_producto_ubicacion(ByVal _Formulario As Form,
                                                  ByVal _Codigo As String,
                                                  Optional ByVal _Ver_Mensaje As Boolean = True,
                                                  Optional ByVal _EsPrimaria As Boolean = False) As Boolean



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

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion(Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo,Primaria) Values" & vbCrLf &
                           "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','" & _Codigo_Ubic & "','" & _Codigo & "'," & _Primaria & ")"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

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

                'MessageBoxEx.Show(_Formulario, "¡Este producto ya esta asociado a esta ubicación!", _
                '                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If


    End Function

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        Dim _Nombre = _Codigo_Sector
        ExportarTabla_JetExcel_Tabla(_Tbl_UbicXpro, Me, _Nombre)
    End Sub




    Private Sub Frm_05_UbicXpro_UbicacionConProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F2 Then
            Sb_Asociar_Producto()
        ElseIf e.KeyValue = Keys.F3 Then
            Sb_Asociar_Productos_Masivamente()
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Buscar_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Producto.Click
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

    Private Function Fx_Buscar_Producto(ByVal _Codigo As String) As DataRow

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

    End Sub

    Private Sub Btn_Seleccion_Multiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccion_Multiple.Click
        Sb_Asociar_Productos_Masivamente()
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
            Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

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

    Private Sub Rdb_Ud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            Sb_Actualizar_Grilla_Ubic()
        End If
    End Sub


    Private Sub Btn_Mnu_Ver_Ubicaciones_Del_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ver_Ubicaciones_Del_Producto.Click
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

    Private Sub Btn_Mnu_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Estadisticas_Producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Call Btn_Mnu_Ver_Ubicaciones_Del_Producto_Click(Nothing, Nothing)
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

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

End Class
