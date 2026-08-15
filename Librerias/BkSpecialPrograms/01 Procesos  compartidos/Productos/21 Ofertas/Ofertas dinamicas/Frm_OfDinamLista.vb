Imports DevComponents.DotNetBar

Public Class Frm_OfDinamLista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Maeeres As DataTable

    ' INSERTAR en las declaraciones del formulario:
    Dim _Dv As New DataView
    Dim _Cargando_Filtros As Boolean
    Dim Fr_Alerta_Stock As DevComponents.DotNetBar.Balloon
    Dim _ProductoAlertaStock As String = String.Empty
    Dim _Aplicando_Cambio_Masivo_Ftoferta As Boolean
    Dim _Actualizando_Oferta_Desde_Ficha As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Recetas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_OfDinamLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_FechaInicio.Value = Nothing
        Dtp_FechaTope.Value = Nothing

        Sb_Actualizar_Grilla_Ofertas()

        AddHandler Grilla_Recetas.MouseDown, AddressOf Sb_Grilla_Recetas_MouseDown
        AddHandler Grilla_Productos.MouseDown, AddressOf Sb_Grilla_Productos_MouseDown

        Txt_BuscaXProducto.ButtonCustom2.Visible = False
        Txt_BuscaXProducto.ButtonCustom.Visible = True

        AddHandler Grilla_Recetas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Recetas.KeyDown, AddressOf Sb_DataGridView_KeyDown_Global
        AddHandler Grilla_Productos.KeyDown, AddressOf Sb_DataGridView_KeyDown_Global

        _Sql.Sb_Parametro_Informe_Sql(Lbl_NroMaxProdXOfertaDinamica, "Ofertas_Dinamincas",
                                      Lbl_NroMaxProdXOfertaDinamica.Name, Class_SQLite.Enum_Type._Tag, Lbl_NroMaxProdXOfertaDinamica.Tag, False,, False, False)

        Lbl_NroMaxProdXOfertaDinamica.Text = Lbl_NroMaxProdXOfertaDinamica.Tag

        AddHandler Dtp_FechaInicio.ValueChanged, AddressOf Dtp_FechaInicio_ValueChanged
        AddHandler Dtp_FechaTope.ValueChanged, AddressOf Dtp_FechaTope_ValueChanged

        Sb_Aplicar_Filtro_Ofertas()

        Me.ActiveControl = Txt_Buscador

    End Sub

    '    Sub Sb_Actualizar_Grilla_Ofertas()

    '        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
    '        Dim _Condicion As String = String.Empty

    '        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

    '        If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
    '            _Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
    '        End If

    '        Consulta_sql = "Select *,DATEDIFF(D,GETDATE(),FTOFERTA) As Dias,CAST(0 As Bit) As Activa,CAST(0 As Int) As 'ProdAsociados'" & vbCrLf &
    '                        "Into #Paso" & vbCrLf &
    '                        "From MAEERES" & vbCrLf &
    '                        "Where TIPORESE = 'din' And CODIGO+DESCRIPTOR Like '%" & _Cadena & "%'" & vbCrLf & _Condicion & vbCrLf &
    '                        "Update #Paso Set Activa = 1 Where GETDATE() Between FIOFERTA And FTOFERTA" & vbCrLf &
    '                        "Update #Paso Set ProdAsociados = (Select COUNT(*) From MAEDRES Where MAEDRES.CODIGO = #Paso.CODIGO)" & vbCrLf &
    '                        "Update #Paso Set Dias = 0 Where Dias < 0" & vbCrLf &
    '                        "Select * From #Paso" & vbCrLf &
    '                        "Drop Table #Paso"

    '        Consulta_sql = $"
    ';WITH Paso2 AS
    '(
    '    SELECT 
    '        Mr.*,
    '        TipoOferta = (
    '            SELECT TOP 1 LTRIM(RTRIM(ISNULL(NOKOCARAC,'')))
    '            FROM TABCARAC 
    '            WHERE KOCARAC = Mr.KOGEN
    '        ),
    '        Dias = CASE WHEN DATEDIFF(D, GETDATE(), Mr.FTOFERTA) < 0 
    '                    THEN 0 
    '                    ELSE DATEDIFF(D, GETDATE(), Mr.FTOFERTA) END,
    '        Activa = CASE WHEN GETDATE() BETWEEN Mr.FIOFERTA AND Mr.FTOFERTA THEN 1 ELSE 0 END,
    '        ProdAsociados = (SELECT COUNT(*) 
    '                         FROM MAEDRES D 
    '                         WHERE D.CODIGO = Mr.CODIGO)
    '    FROM MAEERES Mr
    '    WHERE Mr.TIPORESE = 'din'
    '      AND Mr.CODIGO + Mr.DESCRIPTOR Like '%{_Cadena}%'
    '      {_Condicion}
    ')
    'SELECT *
    'FROM Paso2;"

    '        _Tbl_Maeeres = _Sql.Fx_Get_DataTable(Consulta_sql)

    '        Dim _Codigo As String

    '        If CBool(_Tbl_Maeeres.Rows.Count) Then
    '            _Codigo = _Tbl_Maeeres.Rows(0).Item("CODIGO")
    '        End If

    '        Sb_Actualizar_Grilla_Productos(_Codigo)

    '        With Grilla_Recetas

    '            .DataSource = _Tbl_Maeeres

    '            OcultarEncabezadoGrilla(Grilla_Recetas)

    '            Dim _DisplayIndex = 0

    '            .Columns("CODIGO").Visible = True
    '            .Columns("CODIGO").HeaderText = "Código"
    '            .Columns("CODIGO").Width = 100
    '            .Columns("CODIGO").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            .Columns("DESCRIPTOR").Visible = True
    '            .Columns("DESCRIPTOR").HeaderText = "Nombre del tipo de descuento oferta"
    '            .Columns("DESCRIPTOR").Width = 300
    '            .Columns("DESCRIPTOR").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            .Columns("TipoOferta").Visible = True
    '            .Columns("TipoOferta").HeaderText = "Tipo de oferta"
    '            .Columns("TipoOferta").Width = 100
    '            .Columns("TipoOferta").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            .Columns("FIOFERTA").Visible = True
    '            .Columns("FIOFERTA").HeaderText = "F.Inicia"
    '            .Columns("FIOFERTA").ToolTipText = "Fecha de inicio de la oferta"
    '            .Columns("FIOFERTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .Columns("FIOFERTA").Width = 70
    '            .Columns("FIOFERTA").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            .Columns("FTOFERTA").Visible = True
    '            .Columns("FTOFERTA").HeaderText = "F.Tope"
    '            .Columns("FTOFERTA").ToolTipText = "Fecha de tope de la oferta"
    '            .Columns("FTOFERTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .Columns("FTOFERTA").Width = 70
    '            .Columns("FTOFERTA").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            .Columns("Dias").Visible = True
    '            .Columns("Dias").HeaderText = "Expira."
    '            .Columns("Dias").ToolTipText = "Días que faltan para que termine la oferta"
    '            .Columns("Dias").Width = 50
    '            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '            .Columns("Dias").DefaultCellStyle.Format = "###,##0.##"
    '            .Columns("Dias").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            .Columns("Activa").Visible = True
    '            .Columns("Activa").HeaderText = "Activa"
    '            .Columns("Activa").Width = 40
    '            .Columns("Activa").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            .Columns("ProdAsociados").Visible = True
    '            .Columns("ProdAsociados").HeaderText = "Productos"
    '            .Columns("ProdAsociados").ToolTipText = "Productos asociados a la oferta"
    '            .Columns("ProdAsociados").Width = 70
    '            .Columns("ProdAsociados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '            .Columns("ProdAsociados").DefaultCellStyle.Format = "###,##0.##"
    '            .Columns("ProdAsociados").DisplayIndex = _DisplayIndex
    '            _DisplayIndex += 1

    '            '.Columns("LISTAS").Visible = True
    '            '.Columns("LISTAS").HeaderText = "Listas de precios válidas"
    '            '.Columns("LISTAS").Width = 140
    '            '.Columns("LISTAS").DisplayIndex = 2
    '            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '        End With

    '    End Sub

    Sub Sb_Actualizar_Grilla_Ofertas()

        Dim _Condicion As String = String.Empty

        If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
            _Condicion = " And Mr.CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        End If

        Consulta_sql = Fx_Consulta_Ofertas_Dinamicas(_Condicion)

        _Tbl_Maeeres = _Sql.Fx_Get_DataTable(Consulta_sql)

        _Dv = New DataView(_Tbl_Maeeres)

        Sb_Cargar_Filtro_TipoOferta()
        Sb_Aplicar_Filtro_Ofertas()

        With Grilla_Recetas

            .DataSource = _Dv
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditOnEnter

            OcultarEncabezadoGrilla(Grilla_Recetas)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Width = 30
            .Columns("Chk").DisplayIndex = _DisplayIndex
            .Columns("Chk").ReadOnly = False
            _DisplayIndex += 1

            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").DisplayIndex = _DisplayIndex
            .Columns("CODIGO").ReadOnly = True
            _DisplayIndex += 1

            .Columns("DESCRIPTOR").Visible = True
            .Columns("DESCRIPTOR").HeaderText = "Nombre del tipo de descuento oferta"
            .Columns("DESCRIPTOR").Width = 320
            .Columns("DESCRIPTOR").DisplayIndex = _DisplayIndex
            .Columns("DESCRIPTOR").ReadOnly = True
            _DisplayIndex += 1

            .Columns("TipoOferta").Visible = True
            .Columns("TipoOferta").HeaderText = "Tipo de oferta"
            .Columns("TipoOferta").Width = 160
            .Columns("TipoOferta").DisplayIndex = _DisplayIndex
            .Columns("TipoOferta").ReadOnly = True
            _DisplayIndex += 1

            .Columns("FIOFERTA").Visible = True
            .Columns("FIOFERTA").HeaderText = "F.Inicia"
            .Columns("FIOFERTA").ToolTipText = "Fecha de inicio de la oferta"
            .Columns("FIOFERTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FIOFERTA").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FIOFERTA").Width = 70
            .Columns("FIOFERTA").DisplayIndex = _DisplayIndex
            .Columns("FIOFERTA").ReadOnly = True
            _DisplayIndex += 1

            .Columns("FTOFERTA").Visible = True
            .Columns("FTOFERTA").HeaderText = "F.Tope"
            .Columns("FTOFERTA").ToolTipText = "Fecha de tope de la oferta"
            .Columns("FTOFERTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FTOFERTA").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FTOFERTA").Width = 70
            .Columns("FTOFERTA").DisplayIndex = _DisplayIndex
            .Columns("FTOFERTA").ReadOnly = False
            _DisplayIndex += 1

            .Columns("FTOFERTA_Anterior").Visible = True
            .Columns("FTOFERTA_Anterior").HeaderText = "F.Tope Ant."
            .Columns("FTOFERTA_Anterior").ToolTipText = "Fecha de tope original"
            .Columns("FTOFERTA_Anterior").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FTOFERTA_Anterior").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FTOFERTA_Anterior").Width = 70
            .Columns("FTOFERTA_Anterior").DisplayIndex = _DisplayIndex
            .Columns("FTOFERTA_Anterior").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Dias").Visible = True
            .Columns("Dias").HeaderText = "Expira"
            .Columns("Dias").ToolTipText = "Días que faltan para que termine la oferta"
            .Columns("Dias").Width = 50
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Dias").DisplayIndex = _DisplayIndex
            .Columns("Dias").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Activa").Visible = True
            .Columns("Activa").HeaderText = "Activa"
            .Columns("Activa").Width = 40
            .Columns("Activa").DisplayIndex = _DisplayIndex
            .Columns("Activa").ReadOnly = True
            _DisplayIndex += 1

            .Columns("ProdAsociados").Visible = True
            .Columns("ProdAsociados").HeaderText = "Productos"
            .Columns("ProdAsociados").ToolTipText = "Productos asociados a la oferta"
            .Columns("ProdAsociados").Width = 50
            .Columns("ProdAsociados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ProdAsociados").DefaultCellStyle.Format = "###,##0.##"
            .Columns("ProdAsociados").DisplayIndex = _DisplayIndex
            .Columns("ProdAsociados").ReadOnly = True
            _DisplayIndex += 1

        End With

    End Sub


    Sub Sb_Actualizar_Grilla_Productos(_Codigo As String)

        Consulta_sql = $"
Select Mprod.*,Mp.NOKOPR From MAEDRES Mprod
Left Join MAEPR Mp On Mp.KOPR = Mprod.ELEMENTO
Where CODIGO = '{_Codigo}'"
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, True)

            .Columns("ELEMENTO").Visible = True
            .Columns("ELEMENTO").HeaderText = "Código"
            .Columns("ELEMENTO").Width = 150
            .Columns("ELEMENTO").DisplayIndex = 0

            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 810
            .Columns("NOKOPR").DisplayIndex = 1

        End With

        If Not CBool(Grilla_Productos.RowCount) Then
            Sb_Cerrar_Alerta_Stock()
        Else
            Grilla_Productos.CurrentCell = Grilla_Productos.Rows(0).Cells("ELEMENTO")
            Sb_Actualizar_Alerta_Stock_Producto_Actual(Grilla_Productos.Rows(0))
        End If

    End Sub

    Private Sub Grilla_Recetas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellDoubleClick

        If IsNothing(Grilla_Recetas.CurrentRow) Then
            Return
        End If

        If Not Fx_Tiene_Permiso(Me, "Ofer0003") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow

        Dim _Codigo As String = _Fila.Cells("CODIGO").Value
        Dim _Grabar As Boolean
        Dim _Eliminado As Boolean
        Dim _Row_Maeeres As DataRow

        Dim _Resultado As DialogResult

        Dim Fm As New Frm_OfDinamFicha(_Codigo)
        Fm.ShowDialog(Me)
        _Resultado = Fm.DialogResult
        '_Grabar = Fm.Grabar
        '_Eliminado = Fm.Eliminado
        _Row_Maeeres = Fm.Row_Maeeres
        Fm.Dispose()

        ' Editado
        If _Resultado = DialogResult.OK Then

            _Actualizando_Oferta_Desde_Ficha = True

            Try

                Consulta_sql = Fx_Consulta_Ofertas_Dinamicas(" And Mr.CODIGO = '" & _Codigo & "'")

                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Fila.Cells("DESCRIPTOR").Value = _Row.Item("DESCRIPTOR")
                _Fila.Cells("TipoOferta").Value = _Row.Item("TipoOferta")
                _Fila.Cells("FIOFERTA").Value = _Row.Item("FIOFERTA")
                _Fila.Cells("FTOFERTA").Value = _Row.Item("FTOFERTA")
                _Fila.Cells("LISTAS").Value = _Row.Item("LISTAS")
                _Fila.Cells("Dias").Value = _Row.Item("Dias")
                _Fila.Cells("Activa").Value = _Row.Item("Activa")
                _Fila.Cells("ProdAsociados").Value = _Row.Item("ProdAsociados")

                If Not IsNothing(_Fila.DataBoundItem) AndAlso TypeOf _Fila.DataBoundItem Is DataRowView Then
                    CType(_Fila.DataBoundItem, DataRowView).Row.Item("EditadoGrabadoSesion") = True
                End If

            Finally
                _Actualizando_Oferta_Desde_Ficha = False
            End Try

            Sb_Cargar_Filtro_TipoOferta()
            Sb_Aplicar_Filtro_Ofertas()
            Sb_Actualizar_Txt_Listas(_Fila)

        End If

        ' Eliminado
        If _Resultado = DialogResult.No Then
            Sb_Actualizar_Grilla_Ofertas()
        End If

        'If _Grabar Then

        '    If _Eliminado Then
        '        Sb_Actualizar_Grilla_Ofertas()
        '    Else

        '        Consulta_sql = Fx_Consulta_Ofertas_Dinamicas(" And Mr.CODIGO = '" & _Codigo & "'")

        '        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        '        _Fila.Cells("DESCRIPTOR").Value = _Row.Item("DESCRIPTOR")
        '        _Fila.Cells("TipoOferta").Value = _Row.Item("TipoOferta")
        '        _Fila.Cells("FIOFERTA").Value = _Row.Item("FIOFERTA")
        '        _Fila.Cells("FTOFERTA").Value = _Row.Item("FTOFERTA")
        '        _Fila.Cells("Dias").Value = _Row.Item("Dias")
        '        _Fila.Cells("Activa").Value = _Row.Item("Activa")
        '        _Fila.Cells("ProdAsociados").Value = _Row.Item("ProdAsociados")

        '        Sb_Aplicar_Filtro_Ofertas()

        '    End If
        'End If

    End Sub

    Private Sub Grilla_Recetas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellEnter

        If IsNothing(Grilla_Recetas.CurrentRow) Then
            Txt_Listas.Text = String.Empty
            Sb_Actualizar_Grilla_Productos(String.Empty)
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow
        Dim _Codigo As String = _Fila.Cells("CODIGO").Value

        Sb_Actualizar_Txt_Listas(_Fila)
        Sb_Actualizar_Grilla_Productos(_Codigo)

    End Sub

    Private Sub Btn_Crear_Receta_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Receta.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0002") Then
            Return
        End If

        Txt_Buscador.Text = String.Empty
        Txt_BuscaXProducto.Text = String.Empty

        Dim _Row_Maeeres As DataRow
        Dim _Resultado As DialogResult

        Dim Fm As New Frm_OfDinamFicha("")
        Fm.ShowDialog(Me)
        _Resultado = Fm.DialogResult
        _Row_Maeeres = Fm.Row_Maeeres
        Fm.Dispose()

        If _Resultado = DialogResult.OK Then
            Sb_Actualizar_Grilla_Ofertas()
            BuscarDatoEnGrilla(_Row_Maeeres.Item("CODIGO"), "CODIGO", Grilla_Recetas)
        End If

    End Sub

    Private Sub Btn_Mnu_EditarOferta_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarOferta.Click
        Call Grilla_Recetas_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Mnu_AsociarProductos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_AsociarProductos.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0005") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow

        Dim _Codigo As String = _Fila.Cells("CODIGO").Value
        Dim _Listas As String = _Fila.Cells("LISTAS").Value

        Consulta_sql = "Select Cast(1 As Bit) As Chk,ELEMENTO As Codigo,NOKOPR As Descripcion,NREG" & vbCrLf &
                       "From MAEDRES" & vbCrLf &
                       "Left Join MAEPR On KOPR = ELEMENTO" & vbCrLf &
                       "Where CODIGO In (Select CODIGO From MAEERES Res Where TIPORESE = 'din' And Res.CODIGO = '" & _Codigo & "')" & vbCrLf &
                       "Order By NREG Desc"
        Dim _TblProductos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _FiltroProdExc As String = Generar_Filtro_IN(_TblProductos, "Chk", "Codigo", False, True, "'")

        Dim _FechaServidor As Date = FechaDelServidor()

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR <> 'SSN' And KOPR Not In " &
                                          "(Select ELEMENTO From MAEDRES Where CODIGO In " &
                                          "(Select CODIGO From MAEERES Res Where TIPORESE = 'din' And FTOFERTA >= '" & Format(_FechaServidor, "yyyyMMdd") & "'))"

        _Sql_Filtro_Condicion_Extra = Fx_SqlProductosNoAsociadosAListas(_Listas)

        Dim _Nreg = 0

        If CBool(_TblProductos.Rows.Count) Then
            _Sql_Filtro_Condicion_Extra += " And KOPR Not In " & _FiltroProdExc
            _Nreg = _TblProductos.Rows(0).Item("NREG")
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Filtro_Todas = False
        _Filtrar.Pro_Nombre_Encabezado_Informe = "SELECCIONAR PRODUCTOS (NO MUESTRA PRODUCTOS EN OFERTAS ACTIVAS)"

        If _Filtrar.Fx_Filtrar(_TblProductos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False,, False,, False) Then

            Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

            _TblProductos = _Filtrar.Pro_Tbl_Filtro

            If Not _Filtrar.Pro_Filtro_Todas Then

                Dim _FiltroProductos As String = Generar_Filtro_IN(_TblProductos, "Chk", "Codigo", False, True, "'")

                Consulta_sql = String.Empty

                If _TblProductos.Rows.Count > CInt(Lbl_NroMaxProdXOfertaDinamica.Tag) Then
                    If Not Fx_Tiene_Permiso(Me, "Ofer0007",,,,,,,,,,,,,,,, vbCrLf & "MAXIMO DE PRODUCTOS A SELECCIONAR DE UNA SOLA VEZ: " & Lbl_NroMaxProdXOfertaDinamica.Tag) Then
                        Return
                    End If

                    Dim _Msg1 = "Esta tratando de incorporar de una sola vez " & _TblProductos.Rows.Count & " productos a la oferta" & vbCrLf &
                                "El máximo sugerido es de " & CInt(Lbl_NroMaxProdXOfertaDinamica.Tag) & " productos."
                    Dim _Msg2 = "¿DESEA SEGUIR CON LA GRABACION A PESAR DE LA ADVERTENCIA?" & vbCrLf & vbCrLf

                    If Not Fx_Confirmar_Lectura(_Msg1, _Msg2, eTaskDialogIcon.Stop) Then
                        Return
                    End If

                End If

                If Not IsNothing(_TblProductos) Then

                    For Each _Flprod As DataRow In _TblProductos.Rows

                        _Nreg += 1
                        Dim _Elemento As String = _Flprod.Item("Codigo")

                        Consulta_sql += "Insert Into MAEDRES (CODIGO,NREG,ELEMENTO) Values " &
                                        "('" & _Codigo & "'," & _Nreg & ",'" & _Elemento & "')" & vbCrLf

                    Next

                End If

                If String.IsNullOrEmpty(Consulta_sql) Then
                    Return
                End If

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Sb_Actualizar_Grilla_Productos(_Codigo)

                _Fila.Cells("ProdAsociados").Value = Grilla_Productos.RowCount

            End If

        End If

    End Sub

    Private Function Fx_SqlProductosNoAsociadosAListas(Listas As String) As String

        ' Separar las listas por "_"
        Dim partes As String() = Listas.Split("_"c)
        Dim filtros As New List(Of String)

        ' Construir los filtros LIKE dinámicos
        For Each lista In partes
            Dim l As String = lista.Trim()
            If l <> "" Then
                filtros.Add("E.LISTAS LIKE '%" & l & "%'")
            End If
        Next

        ' Unir los filtros con OR
        Dim filtroListas As String = String.Join(" OR ", filtros)

        ' Construir el SQL final
        Dim sql As String =
        "SELECT CAST(0 AS bit) AS Chk, P.KOPR AS Codigo, P.NOKOPR AS Descripcion" & vbCrLf &
        "FROM MAEPR P WITH (NOLOCK)" & vbCrLf &
        "WHERE P.TIPR <> 'SSN'" & vbCrLf &
        "  AND NOT EXISTS (" & vbCrLf &
        "        SELECT 1" & vbCrLf &
        "        FROM MAEDRES D WITH (NOLOCK)" & vbCrLf &
        "        JOIN MAEERES E WITH (NOLOCK) ON E.CODIGO = D.CODIGO" & vbCrLf &
        "        WHERE D.ELEMENTO = P.KOPR" & vbCrLf &
        "          AND E.TIPORESE = 'din'" & vbCrLf &
        "          AND (" & filtroListas & ")" & vbCrLf &
        "  )" & vbCrLf &
        "ORDER BY P.KOPR"

        sql = $"
AND TIPR <> 'SSN'
AND NOT EXISTS (
SELECT 1
FROM MAEDRES D WITH (NOLOCK)
JOIN MAEERES E WITH (NOLOCK) ON E.CODIGO = D.CODIGO
WHERE D.ELEMENTO = KOPR
AND E.TIPORESE = 'din'
AND ({filtroListas}))
"

        Return sql

    End Function


    Private Sub Btn_Mnu_QuitarProducto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_QuitarProducto.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0006") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
        Dim _Codigo As String = _Fila.Cells("CODIGO").Value
        Dim _Elemento As String = _Fila.Cells("ELEMENTO").Value

        If MessageBoxEx.Show(Me, "¿Confirma quitar este producto de la oferta?", "Quitar productos",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete From MAEDRES Where ELEMENTO = '" & _Elemento & "' AND CODIGO = '" & _Codigo & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Productos.Rows.Remove(_Fila)
        End If

        Consulta_sql = "Select *,DATEDIFF(D,GETDATE(),FTOFERTA) As Dias,CAST(0 As Bit) As Activa,CAST(0 As Int) As 'ProdAsociados'" & vbCrLf &
        "Into #Paso" & vbCrLf &
        "From MAEERES" & vbCrLf &
        "Where TIPORESE = 'din' And CODIGO = '" & _Codigo & "'" & vbCrLf &
        "Update #Paso Set Activa = 1 Where GETDATE() Between FIOFERTA And FTOFERTA" & vbCrLf &
        "Update #Paso Set ProdAsociados = (Select COUNT(*) From MAEDRES Where MAEDRES.CODIGO = #Paso.CODIGO)" & vbCrLf &
        "Update #Paso Set Dias = 0 Where Dias < 0" & vbCrLf &
        "Select * From #Paso" & vbCrLf &
        "Drop Table #Paso"

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _FilaR As DataGridViewRow = Grilla_Recetas.CurrentRow

        _FilaR.Cells("ProdAsociados").Value = _Row.Item("ProdAsociados")

    End Sub

    Private Sub Sb_Grilla_Recetas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Sb_Grilla_Productos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_02)
                End If
            End With
        End If
    End Sub

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Aplicar_Filtro_Ofertas()
            If Not String.IsNullOrWhiteSpace(Txt_Buscador.Text) AndAlso Not CBool(Grilla_Recetas.RowCount) Then
                MessageBoxEx.Show(Me, "No se encontraron registros", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustomClick

        Txt_BuscaXProducto.Enabled = False

        Dim _RowProducto As DataRow = Fx_Buscar_Producto("")

        If Not IsNothing(_RowProducto) Then

            Txt_BuscaXProducto.ButtonCustom.Visible = False
            Txt_BuscaXProducto.ButtonCustom2.Visible = True

            Txt_BuscaXProducto.Text = _RowProducto.Item("KOPR")
            Sb_Actualizar_Grilla_Ofertas()
            If Not CBool(Grilla_Recetas.RowCount) Then
                MessageBoxEx.Show(Me, "No se encontraron registros", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

        Txt_BuscaXProducto.Enabled = True

    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustom2Click

        If String.IsNullOrEmpty(Txt_BuscaXProducto.Text.Trim) Then Return
        Txt_BuscaXProducto.Text = String.Empty
        Sb_Actualizar_Grilla_Ofertas()

        Txt_BuscaXProducto.ButtonCustom2.Visible = False
        Txt_BuscaXProducto.ButtonCustom.Visible = True

    End Sub

    Function Fx_Buscar_Producto(_Codigo As String) As DataRow

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_CodSucEntidad = String.Empty
        Fm.Pro_Tipo_Lista = "P"

        Fm.Pro_Sucursal_Busqueda = Mod_Sucursal
        Fm.Pro_Bodega_Busqueda = Mod_Bodega
        Fm.Txtdescripcion.Text = _Codigo
        Fm.Pro_Mostrar_Info = True
        Fm.Pro_Actualizar_Precios = True

        Codigo_abuscar = String.Empty
        Fm.Pro_Mostrar_Clasificaciones = True
        Fm.Pro_Mostrar_Imagenes = True

        Fm.Pro_Filtro_Sql_Extra = "And TIPR <> 'SSN'"

        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            Return Fm.Pro_RowProducto
        Else
            Return Nothing
        End If

    End Function

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla_Ofertas()
    End Sub

    Private Sub Btn_EditarNroMaxProductos_Click(sender As Object, e As EventArgs) Handles Btn_EditarNroMaxProductos.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0008") Then
            Return
        End If

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Ingrese la cantidad máxima de productos para seleccionar y asociar a una oferta de una vez",
                               "Editar máx. selección de productos", Lbl_NroMaxProdXOfertaDinamica.Tag, False,, 3, True,
                               _Tipo_Imagen.Product,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

        If Not _Aceptar Then
            Return
        End If

        _Sql.Sb_Parametro_Informe_Sql(Lbl_NroMaxProdXOfertaDinamica, "Ofertas_Dinamincas",
                                      Lbl_NroMaxProdXOfertaDinamica.Name, Class_SQLite.Enum_Type._Tag, Lbl_NroMaxProdXOfertaDinamica.Tag, True,, False, False)

        Lbl_NroMaxProdXOfertaDinamica.Text = Lbl_NroMaxProdXOfertaDinamica.Tag

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar máx. selección de productos", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Function Fx_Escape_RowFilter(_Texto As String) As String

        If String.IsNullOrEmpty(_Texto) Then
            Return String.Empty
        End If

        _Texto = _Texto.Replace("'", "''")
        _Texto = _Texto.Replace("[", "[[]")
        _Texto = _Texto.Replace("%", "[%]")
        _Texto = _Texto.Replace("*", "[*]")

        Return _Texto

    End Function

    Private Sub Sb_Cargar_Filtro_TipoOferta()

        Dim _TipoSeleccionado As String = String.Empty

        If Not IsNothing(Cmb_TipoOferta.SelectedValue) Then
            _TipoSeleccionado = Cmb_TipoOferta.SelectedValue.ToString.Trim
        ElseIf Not String.IsNullOrWhiteSpace(Cmb_TipoOferta.Text) Then
            _TipoSeleccionado = Cmb_TipoOferta.Text.Trim
        End If

        _Cargando_Filtros = True

        Dim _TblTipos As New DataTable
        Dim _Fila As DataRow

        _TblTipos.Columns.Add("TipoOferta", GetType(String))

        _Fila = _TblTipos.NewRow()
        _Fila("TipoOferta") = String.Empty
        _TblTipos.Rows.Add(_Fila)

        If Not IsNothing(_Tbl_Maeeres) Then

            Dim _TblTiposDistinct As DataTable = _Tbl_Maeeres.DefaultView.ToTable(True, "TipoOferta")

            For Each _Row As DataRow In _TblTiposDistinct.Rows

                Dim _TipoOferta As String = _Row.Item("TipoOferta").ToString.Trim

                If Not String.IsNullOrWhiteSpace(_TipoOferta) Then
                    _Fila = _TblTipos.NewRow()
                    _Fila("TipoOferta") = _TipoOferta
                    _TblTipos.Rows.Add(_Fila)
                End If

            Next

        End If

        Cmb_TipoOferta.DataSource = _TblTipos
        Cmb_TipoOferta.DisplayMember = "TipoOferta"
        Cmb_TipoOferta.ValueMember = "TipoOferta"

        If Not String.IsNullOrWhiteSpace(_TipoSeleccionado) Then
            Cmb_TipoOferta.SelectedValue = _TipoSeleccionado
        Else
            Cmb_TipoOferta.SelectedIndex = 0
        End If

        _Cargando_Filtros = False

    End Sub

    Private Sub Sb_Aplicar_Filtro_Ofertas()

        If _Cargando_Filtros Then
            Return
        End If

        If IsNothing(_Tbl_Maeeres) Then
            Return
        End If

        If IsNothing(_Dv.Table) OrElse Not Object.ReferenceEquals(_Dv.Table, _Tbl_Maeeres) Then
            _Dv.Table = _Tbl_Maeeres
        End If

        Dim _Filtro As String = String.Empty
        Dim _Texto As String = Fx_Escape_RowFilter(Txt_Buscador.Text.Trim)
        Dim _TipoOferta As String = Fx_Escape_RowFilter(Cmb_TipoOferta.Text.Trim)
        Dim _Desde As String = String.Empty
        Dim _Hasta As String = String.Empty
        Dim _TieneFechaIni As Boolean = Fx_Tiene_Fecha_Filtro(Dtp_FechaInicio.Value, Dtp_FechaInicio.Text)
        Dim _TieneFechaFin As Boolean = Fx_Tiene_Fecha_Filtro(Dtp_FechaTope.Value, Dtp_FechaTope.Text)

        If Not String.IsNullOrWhiteSpace(_Texto) Then
            _Filtro += "(CODIGO LIKE '%" & _Texto & "%' OR DESCRIPTOR LIKE '%" & _Texto & "%' OR TipoOferta LIKE '%" & _Texto & "%')"
        End If

        If Not String.IsNullOrWhiteSpace(_TipoOferta) Then
            If Not String.IsNullOrWhiteSpace(_Filtro) Then
                _Filtro += " And "
            End If
            _Filtro += "(TipoOferta = '" & _TipoOferta & "')"
        End If

        If _TieneFechaIni Then
            If Not String.IsNullOrWhiteSpace(_Filtro) Then
                _Filtro += " And "
            End If

            Dim _FechaIni As Date = CDate(Dtp_FechaInicio.Value).Date
            _Filtro += Fx_Crear_Filtro_Fecha_Exacta("FIOFERTA", _FechaIni)
        End If

        If _TieneFechaFin Then
            If Not String.IsNullOrWhiteSpace(_Filtro) Then
                _Filtro += " And "
            End If

            Dim _FechaFin As Date = CDate(Dtp_FechaTope.Value).Date
            _Filtro += Fx_Crear_Filtro_Fecha_Exacta("FTOFERTA", _FechaFin)
        End If

        _Dv.RowFilter = _Filtro
        Grilla_Recetas.DataSource = _Dv

        Dim _Codigo As String = String.Empty
        Txt_Listas.Text = String.Empty

        If CBool(_Dv.Count) Then
            _Codigo = _Dv.Item(0).Item("CODIGO").ToString()
            Txt_Listas.Text = _Dv.Item(0).Item("LISTAS").ToString()
        End If

        Sb_Actualizar_Grilla_Productos(_Codigo)

    End Sub

    Private Sub Txt_Buscador_TextChanged(sender As Object, e As EventArgs) Handles Txt_Buscador.TextChanged
        Txt_Buscador.ButtonCustom2.Visible = Not String.IsNullOrWhiteSpace(Txt_Buscador.Text)
        Sb_Aplicar_Filtro_Ofertas()
    End Sub

    Private Sub Cmb_TipoOferta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_TipoOferta.SelectedIndexChanged
        Sb_Aplicar_Filtro_Ofertas()
    End Sub

    Private Function Fx_Consulta_Ofertas_Dinamicas(_Condicion As String) As String

        Return "
;WITH Paso2 AS
(
    SELECT 
        Cast(0 As Bit) As 'Chk',
        Cast(0 As Bit) As EditadoGrabadoSesion,
        Mr.*,
        Cast(Mr.FTOFERTA As DateTime) As FTOFERTA_Anterior,
        Cast(0 As Bit) As FTOFERTA_Modificada,
        TipoOferta = (
            SELECT TOP 1 LTRIM(RTRIM(ISNULL(NOKOCARAC,'')))
            FROM TABCARAC
            WHERE KOCARAC = Mr.KOGEN
        ),
        Dias = CASE WHEN DATEDIFF(D, GETDATE(), Mr.FTOFERTA) < 0
                    THEN 0
                    ELSE DATEDIFF(D, GETDATE(), Mr.FTOFERTA) END,
        Activa = CASE WHEN GETDATE() BETWEEN Mr.FIOFERTA AND Mr.FTOFERTA THEN 'Si' ELSE 'No' END,
        ProdAsociados = (
            SELECT COUNT(*)
            FROM MAEDRES D
            WHERE D.CODIGO = Mr.CODIGO
        )
    FROM MAEERES Mr
    WHERE Mr.TIPORESE = 'din'
    " & _Condicion & "
)
SELECT *
FROM Paso2;"

    End Function

    Private Sub Sb_Configurar_Rango_Fechas_Ofertas()

        Dim _FechaInicio As Date = New Date(Now.Year, 1, 1)
        Dim _FechaTope As Date = New Date(Now.Year, 12, 31)

        If Not IsNothing(_Tbl_Maeeres) AndAlso CBool(_Tbl_Maeeres.Rows.Count) Then

            Dim _MinFioferta As Object = _Tbl_Maeeres.Compute("Min(FIOFERTA)", String.Empty)
            Dim _MaxFtoferta As Object = _Tbl_Maeeres.Compute("Max(FTOFERTA)", String.Empty)

            If Not IsDBNull(_MinFioferta) Then
                _FechaInicio = CDate(_MinFioferta).Date
            End If

            If Not IsDBNull(_MaxFtoferta) Then
                _FechaTope = CDate(_MaxFtoferta).Date
            End If

        End If

        Dtp_FechaInicio.Value = _FechaInicio
        Dtp_FechaTope.Value = _FechaTope

    End Sub

    'Private Function Fx_Tiene_Fecha_Filtro(_Valor As Object, _Texto As String) As Boolean

    '    If IsNothing(_Valor) Or _Valor = #1/1/0001 12:00:00 AM# Then
    '        Return False
    '    End If

    '    Return Not String.IsNullOrWhiteSpace(_Texto)

    'End Function
    Private Function Fx_Tiene_Fecha_Filtro(_Valor As Object, _Texto As String) As Boolean

        Dim _Fecha As Date

        If Not IsNothing(_Valor) AndAlso Not IsDBNull(_Valor) Then

            If TypeOf _Valor Is Date Then
                _Fecha = CDate(_Valor)
                Return (_Fecha <> Date.MinValue)
            End If

            Dim _ValorTexto As String = _Valor.ToString().Trim()

            If Not String.IsNullOrWhiteSpace(_ValorTexto) AndAlso Date.TryParse(_ValorTexto, _Fecha) Then
                Return (_Fecha <> Date.MinValue)
            End If

        End If

        If Not String.IsNullOrWhiteSpace(_Texto) AndAlso Date.TryParse(_Texto.Trim(), _Fecha) Then
            Return (_Fecha <> Date.MinValue)
        End If

        Return False

    End Function

    Private Function Fx_Crear_Filtro_Fecha_Exacta(_Campo As String, _Fecha As Date) As String

        Dim _FechaDesde As Date = _Fecha.Date
        Dim _FechaHasta As Date = _FechaDesde.AddDays(1)

        Return "(" & _Campo & " >= #" & Format(_FechaDesde, "MM\/dd\/yyyy") & "# And " &
               _Campo & " < #" & Format(_FechaHasta, "MM\/dd\/yyyy") & "#)"

    End Function

    Private Sub Dtp_FechaInicio_ValueChanged(sender As Object, e As EventArgs)
        Sb_Aplicar_Filtro_Ofertas()
    End Sub

    Private Sub Dtp_FechaTope_ValueChanged(sender As Object, e As EventArgs)
        Sb_Aplicar_Filtro_Ofertas()
    End Sub

    Private Sub Dtp_FechaInicio_ButtonClearClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Dtp_FechaInicio.ButtonClearClick
        Sb_Aplicar_Filtro_Ofertas()
    End Sub

    Private Sub Dtp_FechaTope_ButtonClearClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Dtp_FechaTope.ButtonClearClick
        Dtp_FechaTope.Text = String.Empty
        Sb_Aplicar_Filtro_Ofertas()
    End Sub

    Private Sub Btn_InfoKardex_Click(sender As Object, e As EventArgs) Handles Btn_InfoKardex.Click

        If IsNothing(Grilla_Productos.CurrentRow) Then
            Return
        End If

        Dim _Elemento As String = Grilla_Productos.CurrentRow.Cells("ELEMENTO").Value

        If IsNothing(Fr_Alerta_Stock) OrElse Not Fr_Alerta_Stock.Visible Then
            Sb_Mostrar_Alerta_Stock_Producto(_Elemento)
        Else
            Sb_Cerrar_Alerta_Stock()
        End If

    End Sub

    Private Sub Sb_Cerrar_Alerta_Stock()

        If Not IsNothing(Fr_Alerta_Stock) Then

            If Fr_Alerta_Stock.Visible Then
                Fr_Alerta_Stock.Close()
            End If

            Fr_Alerta_Stock = Nothing

        End If

        _ProductoAlertaStock = String.Empty

    End Sub

    Private Sub Sb_Mostrar_Alerta_Stock_Producto(_Elemento As String)

        If String.IsNullOrWhiteSpace(_Elemento) Then
            Sb_Cerrar_Alerta_Stock()
            Return
        End If

        Sb_Cerrar_Alerta_Stock()

        Fr_Alerta_Stock = New AlertCustom(_Elemento, 1)
        _ProductoAlertaStock = _Elemento

        ShowLoadAlert(Fr_Alerta_Stock, Me, True, 10)

    End Sub

    Private Sub Sb_Actualizar_Alerta_Stock_Producto_Actual()

        If IsNothing(Fr_Alerta_Stock) OrElse Not Fr_Alerta_Stock.Visible Then
            Return
        End If

        If IsNothing(Grilla_Productos.CurrentRow) Then
            Sb_Cerrar_Alerta_Stock()
            Return
        End If

        Dim _Elemento As String = Grilla_Productos.CurrentRow.Cells("ELEMENTO").Value.ToString.Trim

        If String.IsNullOrWhiteSpace(_Elemento) Then
            Sb_Cerrar_Alerta_Stock()
            Return
        End If

        If _ProductoAlertaStock = _Elemento Then
            Return
        End If

        Sb_Mostrar_Alerta_Stock_Producto(_Elemento)

    End Sub

    Private Sub Sb_Actualizar_Alerta_Stock_Producto_Actual(_Fila As DataGridViewRow)

        If IsNothing(Fr_Alerta_Stock) OrElse Not Fr_Alerta_Stock.Visible Then
            Return
        End If

        If IsNothing(_Fila) Then
            Sb_Cerrar_Alerta_Stock()
            Return
        End If

        Dim _Elemento As String = _Fila.Cells("ELEMENTO").Value.ToString.Trim

        If String.IsNullOrWhiteSpace(_Elemento) Then
            Sb_Cerrar_Alerta_Stock()
            Return
        End If

        If _ProductoAlertaStock = _Elemento Then
            Return
        End If

        Sb_Mostrar_Alerta_Stock_Producto(_Elemento)

    End Sub

    Private Sub Grilla_Productos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.RowEnter

        If e.RowIndex < 0 Then
            Return
        End If

        Sb_Actualizar_Alerta_Stock_Producto_Actual(Grilla_Productos.Rows(e.RowIndex))

    End Sub

    Private Sub Sb_Actualizar_Estado_Row_Oferta(_Row As DataRow)

        If IsNothing(_Row) Then
            Return
        End If

        If IsNothing(_Row.Table) Then
            Return
        End If

        If Not _Row.Table.Columns.Contains("FIOFERTA") OrElse
       Not _Row.Table.Columns.Contains("FTOFERTA") OrElse
       Not _Row.Table.Columns.Contains("FTOFERTA_Anterior") OrElse
       Not _Row.Table.Columns.Contains("Dias") OrElse
       Not _Row.Table.Columns.Contains("Activa") OrElse
       Not _Row.Table.Columns.Contains("FTOFERTA_Modificada") Then
            Return
        End If

        If IsDBNull(_Row.Item("FIOFERTA")) OrElse
       IsDBNull(_Row.Item("FTOFERTA")) OrElse
       IsDBNull(_Row.Item("FTOFERTA_Anterior")) Then
            Return
        End If

        Dim _FechaServidor As Date = FechaDelServidor().Date
        Dim _FechaInicio As Date = CDate(_Row.Item("FIOFERTA")).Date
        Dim _FechaTope As Date = CDate(_Row.Item("FTOFERTA")).Date
        Dim _FechaTopeAnterior As Date = CDate(_Row.Item("FTOFERTA_Anterior")).Date
        Dim _OfertaActiva As Boolean = (_FechaServidor >= _FechaInicio AndAlso _FechaServidor <= _FechaTope)

        Dim _Dias As Integer = DateDiff(DateInterval.Day, _FechaServidor, _FechaTope)
        If _Dias < 0 Then
            _Dias = 0
        End If

        _Row.Item("Dias") = _Dias
        _Row.Item("Activa") = If(_OfertaActiva, "Si", "No")
        _Row.Item("FTOFERTA_Modificada") = (_FechaTope <> _FechaTopeAnterior)

    End Sub

    Private Sub Sb_Actualizar_Estado_Fila_Oferta(_Fila As DataGridViewRow)

        If IsNothing(_Fila) Then
            Return
        End If

        If IsNothing(_Fila.DataGridView) OrElse _Fila.Index < 0 Then
            Return
        End If

        Dim _Grid As DataGridView = _Fila.DataGridView

        If Not _Grid.Columns.Contains("FIOFERTA") OrElse
           Not _Grid.Columns.Contains("FTOFERTA") OrElse
           Not _Grid.Columns.Contains("FTOFERTA_Anterior") OrElse
           Not _Grid.Columns.Contains("Dias") OrElse
           Not _Grid.Columns.Contains("Activa") OrElse
           Not _Grid.Columns.Contains("FTOFERTA_Modificada") Then
            Return
        End If

        If Not IsNothing(_Fila.DataBoundItem) AndAlso TypeOf _Fila.DataBoundItem Is DataRowView Then
            Sb_Actualizar_Estado_Row_Oferta(CType(_Fila.DataBoundItem, DataRowView).Row)
            Return
        End If

        If IsNothing(_Fila.Cells("FTOFERTA").Value) OrElse IsDBNull(_Fila.Cells("FTOFERTA").Value) Then
            Return
        End If

        If IsNothing(_Fila.Cells("FTOFERTA_Anterior").Value) OrElse IsDBNull(_Fila.Cells("FTOFERTA_Anterior").Value) Then
            Return
        End If

        Dim _FechaServidor As Date = FechaDelServidor().Date
        Dim _FechaInicio As Date = CDate(_Fila.Cells("FIOFERTA").Value).Date
        Dim _FechaTope As Date = CDate(_Fila.Cells("FTOFERTA").Value).Date
        Dim _FechaTopeAnterior As Date = CDate(_Fila.Cells("FTOFERTA_Anterior").Value).Date
        Dim _OfertaActiva As Boolean = (_FechaServidor >= _FechaInicio AndAlso _FechaServidor <= _FechaTope)

        Dim _Dias As Integer = DateDiff(DateInterval.Day, _FechaServidor, _FechaTope)
        If _Dias < 0 Then
            _Dias = 0
        End If

        _Fila.Cells("Dias").Value = _Dias
        _Fila.Cells("Activa").Value = If(_OfertaActiva, "Si", "No")
        _Fila.Cells("FTOFERTA_Modificada").Value = (_FechaTope <> _FechaTopeAnterior)

    End Sub

    Private Sub Sb_Aplicar_Fecha_Tope_A_Filas_Marcadas(_FechaTope As Date)

        If IsNothing(_Tbl_Maeeres) Then
            Return
        End If

        _Aplicando_Cambio_Masivo_Ftoferta = True

        Try

            Grilla_Recetas.EndEdit()

            If Not IsNothing(_Dv) Then
                Dim _CurrencyManager As CurrencyManager = CType(BindingContext(_Dv), CurrencyManager)
                _CurrencyManager.EndCurrentEdit()
            End If

            For Each _Row As DataRow In _Tbl_Maeeres.Rows

                If IsDBNull(_Row.Item("Chk")) OrElse Not CBool(_Row.Item("Chk")) Then
                    Continue For
                End If

                If IsDBNull(_Row.Item("FTOFERTA")) OrElse
                   CDate(_Row.Item("FTOFERTA")).Date <> _FechaTope.Date Then

                    _Row.Item("FTOFERTA") = _FechaTope.Date
                End If

                Sb_Actualizar_Estado_Row_Oferta(_Row)

            Next

        Finally
            _Aplicando_Cambio_Masivo_Ftoferta = False
        End Try

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Grilla_Recetas.EndEdit()

        If Not IsNothing(_Dv) Then
            Dim _CurrencyManager As CurrencyManager = CType(BindingContext(_Dv), CurrencyManager)
            _CurrencyManager.EndCurrentEdit()
        End If

        Dim _HayCambiosDescripcion As Boolean = Fx_Hay_Cambios_Descripciones_Ofertas()
        Dim _HayCambiosFecha As Boolean = Fx_Hay_Cambios_Fechas_Ofertas()

        If Not _HayCambiosDescripcion And Not _HayCambiosFecha Then
            MessageBoxEx.Show(Me, "No hay cambios pendientes por grabar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim _FilasModificadas As DataRow() = _Tbl_Maeeres.Select("Chk = True Or FTOFERTA_Modificada = True")

        Dim _SqlQuery As New System.Text.StringBuilder

        For Each _Row As DataRow In _FilasModificadas

            Dim _Codigo As String = _Row.Item("CODIGO").ToString.Trim.Replace("'", "''")
            Dim _Ftoferta As Date = CDate(_Row.Item("FTOFERTA")).Date
            Dim _FtofertaSql As String = Format(_Ftoferta, "yyyyMMdd")

            _SqlQuery.AppendLine("Update MAEERES Set FTOFERTA = '" & _FtofertaSql & "'")
            _SqlQuery.AppendLine("Where CODIGO = '" & _Codigo & "' And TIPORESE = 'din'")
            _SqlQuery.AppendLine()

        Next

        Consulta_sql = _SqlQuery.ToString

        If String.IsNullOrWhiteSpace(Consulta_sql) Then
            MessageBoxEx.Show(Me, "No se generó ninguna actualización para grabar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _FilasEditadasEnSesion As DataRow() = _Tbl_Maeeres.Select("FTOFERTA_Modificada = True")

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            For Each _Row As DataRow In _FilasEditadasEnSesion
                _Row.Item("EditadoGrabadoSesion") = True
            Next

            For Each _Row As DataRow In _FilasModificadas
                _Row.Item("FTOFERTA_Anterior") = _Row.Item("FTOFERTA")
                _Row.Item("FTOFERTA_Modificada") = False
            Next

            Sb_Desmarcar_Todas_Las_Filas()

            _Tbl_Maeeres.AcceptChanges()
            Sb_Aplicar_Filtro_Ofertas()

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function Fx_Hay_Cambios_Descripciones_Ofertas() As Boolean

        If IsNothing(_Tbl_Maeeres) Then
            Return False
        End If

        For Each _Row As DataRow In _Tbl_Maeeres.Rows
            If CBool(_Row.Item("Chk")) Then
                Return True
            End If
        Next

        Return False

    End Function

    Private Function Fx_Hay_Cambios_Fechas_Ofertas() As Boolean

        If IsNothing(_Tbl_Maeeres) Then
            Return False
        End If

        For Each _Row As DataRow In _Tbl_Maeeres.Rows
            If CBool(_Row.Item("FTOFERTA_Modificada")) Then
                Return True
            End If
        Next

        Return False

    End Function

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged

        If IsNothing(Grilla_Recetas.DataSource) Then
            Return
        End If

        If Not CBool(Grilla_Recetas.RowCount) Then
            Return
        End If

        Grilla_Recetas.EndEdit()

        For Each _Fila As DataGridViewRow In Grilla_Recetas.Rows

            If _Fila.IsNewRow Then
                Continue For
            End If

            _Fila.Cells("Chk").Value = Chk_Marcar_Todas.Checked

        Next

        If Not IsNothing(_Dv) Then
            Dim _CurrencyManager As CurrencyManager = CType(BindingContext(_Dv), CurrencyManager)
            _CurrencyManager.EndCurrentEdit()
        End If

        Grilla_Recetas.Refresh()

    End Sub

    Private Sub Grilla_Recetas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles Grilla_Recetas.CurrentCellDirtyStateChanged

        If Not Grilla_Recetas.IsCurrentCellDirty Then
            Return
        End If

        If IsNothing(Grilla_Recetas.CurrentCell) Then
            Return
        End If

        Dim _NombreColumna As String = Grilla_Recetas.Columns(Grilla_Recetas.CurrentCell.ColumnIndex).Name

        If _NombreColumna = "Chk" Then
            Grilla_Recetas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    Private Sub Grilla_Recetas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla_Recetas.DataError

        e.ThrowException = False
        e.Cancel = False

    End Sub
    Private Function Fx_Cantidad_Filas_Marcadas(_FilaOmitir As DataGridViewRow) As Integer

        Dim _Cantidad As Integer = 0

        For Each _Fila As DataGridViewRow In Grilla_Recetas.Rows

            If _Fila.IsNewRow Then
                Continue For
            End If

            If Not IsNothing(_FilaOmitir) AndAlso _Fila.Index = _FilaOmitir.Index Then
                Continue For
            End If

            If Not IsNothing(_Fila.Cells("Chk").Value) AndAlso CBool(_Fila.Cells("Chk").Value) Then
                _Cantidad += 1
            End If

        Next

        Return _Cantidad

    End Function

    Private Sub Grilla_Recetas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellValueChanged

        If _Actualizando_Oferta_Desde_Ficha Then
            Return
        End If

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        Dim _NombreColumna As String = Grilla_Recetas.Columns(e.ColumnIndex).Name

        If _NombreColumna = "FTOFERTA" Then

            Dim _Fila As DataGridViewRow = Grilla_Recetas.Rows(e.RowIndex)

            Sb_Actualizar_Estado_Fila_Oferta(_Fila)

            If _Aplicando_Cambio_Masivo_Ftoferta Then
                Return
            End If

            Dim _CantidadFilasMarcadas As Integer = Fx_Cantidad_Filas_Marcadas(_Fila)

            If Not CBool(_CantidadFilasMarcadas) Then
                Return
            End If

            Dim _FechaTope As Date = CDate(_Fila.Cells("FTOFERTA").Value).Date

            If MessageBoxEx.Show(Me,
                                 "Hay " & _CantidadFilasMarcadas & " oferta(s) marcada(s)." & vbCrLf & vbCrLf &
                                 "¿Desea cambiar también la fecha de tope en todas las filas marcadas?",
                                 "Cambio masivo de fecha de tope",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = DialogResult.Yes Then

                Sb_Aplicar_Fecha_Tope_A_Filas_Marcadas(_FechaTope)

            End If

        End If

    End Sub
    Private Sub Grilla_Recetas_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles Grilla_Recetas.CellValidating

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        Dim _NombreColumna As String = Grilla_Recetas.Columns(e.ColumnIndex).Name

        If _NombreColumna <> "FTOFERTA" Then
            Return
        End If

        Dim _Texto As String = e.FormattedValue.ToString.Trim
        Dim _NuevaFecha As Date
        Dim _FechaServidor As Date = FechaDelServidor().Date
        Dim _Fila As DataGridViewRow = Grilla_Recetas.Rows(e.RowIndex)
        Dim _FechaInicio As Date = CDate(_Fila.Cells("FIOFERTA").Value).Date
        Dim _FechaOriginal As Date = CDate(_Fila.Cells("FTOFERTA_Anterior").Value).Date
        Dim _Cultura As System.Globalization.CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("es-ES")
        Dim _Formatos() As String = {
        "d/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/MM/yy",
        "d-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy"
    }

        If String.IsNullOrWhiteSpace(_Texto) Then
            MessageBoxEx.Show(Me,
                          "Debe ingresar una fecha de tope válida.",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        _Texto = _Texto.Replace(".", "/").Replace("-", "/").Trim

        If Not Date.TryParseExact(_Texto,
                              _Formatos,
                              _Cultura,
                              Globalization.DateTimeStyles.None,
                              _NuevaFecha) Then
            MessageBoxEx.Show(Me,
                          "La fecha ingresada no es válida." & vbCrLf & vbCrLf &
                          "Ejemplo correcto: 31/12/2026",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        _NuevaFecha = _NuevaFecha.Date

        If _NuevaFecha = _FechaOriginal Then
            Return
        End If

        If _NuevaFecha < _FechaInicio Then
            MessageBoxEx.Show(Me,
                          "La fecha de tope no puede ser menor a la fecha de inicio de la oferta.",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        'If _NuevaFecha <= _FechaServidor Then
        '    MessageBoxEx.Show(Me,
        '                  "La fecha de tope debe ser posterior a la fecha actual.",
        '                  "Validación",
        '                  MessageBoxButtons.OK,
        '                  MessageBoxIcon.Stop)
        '    e.Cancel = True
        'End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0004") Then
            Return
        End If

        Grilla_Recetas.EndEdit()

        If Not IsNothing(_Dv) Then
            Dim _CurrencyManager As CurrencyManager = CType(BindingContext(_Dv), CurrencyManager)
            _CurrencyManager.EndCurrentEdit()
        End If

        If IsNothing(_Tbl_Maeeres) Then
            MessageBoxEx.Show(Me,
                              "No hay datos para eliminar.",
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
            Return
        End If

        Dim _FilasMarcadas As DataRow() = _Tbl_Maeeres.Select("Chk = True")

        If Not CBool(_FilasMarcadas.Length) Then
            MessageBoxEx.Show(Me,
                              "Debe marcar al menos una oferta para eliminar.",
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
            Return
        End If

        If _FilasMarcadas.Length > 1 Then

            Dim _FilasBloqueadas As DataRow() = _Tbl_Maeeres.Select("Chk = True And EditadoGrabadoSesion = True")

            If CBool(_FilasBloqueadas.Length) Then
                MessageBoxEx.Show(Me,
                              "No se permite eliminar registros que fueron editados y grabados en esta sesión." & vbCrLf & vbCrLf &
                              "Al cerrar y volver a abrir el formulario, esta restricción se libera.",
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
                Return
            End If

        End If

        Dim _Mensaje As String

        If _FilasMarcadas.Length = 1 Then
            _Mensaje = "¿Confirma eliminar la oferta marcada?"
        Else
            _Mensaje = "¿Confirma eliminar las " & _FilasMarcadas.Length & " ofertas marcadas?"
        End If

        If MessageBoxEx.Show(Me,
                             _Mensaje,
                             "Eliminar ofertas",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _ListaCodigos As New List(Of String)

        For Each _Row As DataRow In _FilasMarcadas
            Dim _Codigo As String = _Row.Item("CODIGO").ToString.Trim.Replace("'", "''")
            _ListaCodigos.Add("'" & _Codigo & "'")
        Next

        If Not CBool(_ListaCodigos.Count) Then
            Return
        End If

        Dim _FiltroCodigos As String = String.Join(",", _ListaCodigos)
        Dim _SqlQuery As New System.Text.StringBuilder

        If _Sql.Fx_Existe_Tabla("MAEERES_Hist") Then

            _SqlQuery.AppendLine("Insert Into MAEERES_Hist (CODIGO,CANTIDAD,UDAD,DESCRIPTOR,ESTARESE,TIPORESE,CONCEPTO,LISTAS,FIOFERTA,FTOFERTA,APLICAUT,PORDESC,ECUPORDESC,DESC_LUN,DESC_MAR,DESC_MIE,")
            _SqlQuery.AppendLine("DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,VALDESC,ECUVALDESC,KOGEN,CANTMIN,TIPOTRAT,RANGOS,INCLUYENVV,TGRANEL,FGRABACION,KOFUGRABA,OFERTAELIMINADA,ELIMINAMASIVA)")
            _SqlQuery.AppendLine("Select CODIGO,CANTIDAD,UDAD,DESCRIPTOR,ESTARESE,TIPORESE,CONCEPTO,LISTAS,FIOFERTA,FTOFERTA,APLICAUT,PORDESC,ECUPORDESC,DESC_LUN,DESC_MAR,DESC_MIE,")
            _SqlQuery.AppendLine("DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,VALDESC,ECUVALDESC,KOGEN,CANTMIN,TIPOTRAT,RANGOS,INCLUYENVV,TGRANEL,GETDATE(),'" & FUNCIONARIO & "',1,1")
            _SqlQuery.AppendLine("From MAEERES")
            _SqlQuery.AppendLine("Where CODIGO In (" & _FiltroCodigos & ")")
            _SqlQuery.AppendLine()

        End If

        _SqlQuery.AppendLine("Delete From MAEDRES Where CODIGO In (" & _FiltroCodigos & ")")
        _SqlQuery.AppendLine("Delete From MAEERES Where CODIGO In (" & _FiltroCodigos & ")")

        Consulta_sql = _SqlQuery.ToString()

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me,
                              _Sql.Pro_Error,
                              "Problema al eliminar",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
            Return
        End If

        Sb_Actualizar_Grilla_Ofertas()

        MessageBoxEx.Show(Me,
                          "Ofertas eliminadas correctamente.",
                          "Eliminar ofertas",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)

    End Sub

    Private Sub Sb_Desmarcar_Todas_Las_Filas()

        If IsNothing(_Tbl_Maeeres) Then
            Chk_Marcar_Todas.Checked = False
            Return
        End If

        For Each _Row As DataRow In _Tbl_Maeeres.Rows
            _Row.Item("Chk") = False
        Next

        Chk_Marcar_Todas.Checked = False

        If Not IsNothing(_Dv) Then
            Dim _CurrencyManager As CurrencyManager = CType(BindingContext(_Dv), CurrencyManager)
            _CurrencyManager.EndCurrentEdit()
        End If

        Grilla_Recetas.Refresh()

    End Sub

    Private Sub Mnu_Btn_CopiarOf_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_CopiarOf.Click
        With Grilla_Recetas

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Mnu_Btn_CopiarOf.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


        End With
    End Sub

    Private Sub Mnu_Btn_CopiarPr_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_CopiarPr.Click
        With Grilla_Productos

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Mnu_Btn_CopiarPr.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


        End With
    End Sub

    Private Sub Sb_Actualizar_Txt_Listas(_Fila As DataGridViewRow)

        Txt_Listas.Text = String.Empty

        If IsNothing(_Fila) Then
            Return
        End If

        If IsNothing(_Fila.Cells("LISTAS").Value) OrElse IsDBNull(_Fila.Cells("LISTAS").Value) Then
            Return
        End If

        Txt_Listas.Text = _Fila.Cells("LISTAS").Value.ToString()

    End Sub

End Class
