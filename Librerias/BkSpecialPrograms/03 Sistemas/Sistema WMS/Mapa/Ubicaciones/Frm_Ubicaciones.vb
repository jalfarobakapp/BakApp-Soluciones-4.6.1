Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Frm_Ubicaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowBodega As DataRow
    Dim _Empresa
    Dim _Sucursal
    Dim _Bodega

    Dim _Id_Mapa As Integer
    Dim _Nombre_Mapa As String
    Dim _Codigo_Sector As String

    Dim dt As New DataTable("TblEstante")
    Dim dr As DataRow
    Dim rs As New DataSet("Ds")

    Dim _RowMapa As DataRow

    Dim _TblUbicacion,
        _TblColumnas,
        _TblFilas,
        _TblEstante As DataTable

    Dim _RowProducto As DataRow
    Dim _Mantencion_Ubicaciones As Boolean
    Dim _Grabar As Boolean

    Dim _EsSubSector As Boolean
    Private _Row_Sector As DataRow

    Public ReadOnly Property Pro_Grabar()
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Pro_RowProducto() As DataRow
        Get
            Return _RowProducto
        End Get
        Set(value As DataRow)
            _RowProducto = value

            Dim _Enable As Boolean = (_RowProducto Is Nothing)

            Btn_Agregar_Columna.Visible = _Enable
            Btn_Agregar_Nivel.Visible = _Enable
            Btn_Imprir.Visible = _Enable

        End Set
    End Property

    Public Property Pro_Chk_Modificar_Sector() As Boolean
        Get
            Return Chk_Modificar_Sector.Checked
        End Get
        Set(value As Boolean)
            Chk_Modificar_Sector.Checked = value
            Chk_Modificar_Sector.Enabled = False
        End Set
    End Property

    Public Sub New(RowBodega As DataRow,
                   Id_Mapa As Integer,
                   Codigo_Sector As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _RowBodega = RowBodega

        _Id_Mapa = Id_Mapa
        _Codigo_Sector = Codigo_Sector

        _Empresa = _RowBodega.Item("EMPRESA")
        _Sucursal = _RowBodega.Item("KOSU")
        _Bodega = _RowBodega.Item("KOBO")

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Where Id_Mapa = " & _Id_Mapa & vbCrLf &
                       "Select top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = " & _Id_Mapa & " And Codigo_Ubic = '" & _Codigo_Sector & "'"
        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)


        If CBool(_Ds.Tables(0).Rows.Count) Then
            _RowMapa = _Ds.Tables(0).Rows(0)
            _Nombre_Mapa = _RowMapa.Item("Nombre_Mapa")
        End If

        If CBool(_Ds.Tables(1).Rows.Count) Then
            _EsSubSector = _Ds.Tables(1).Rows(0).Item("Es_SubSector")
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " and Codigo_Sector = '" & _Codigo_Sector & "'"
        _Row_Sector = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Ubicaciones_01_Filas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        TxtCodigo_Ubic.Text = _Codigo_Sector
        TxtDescripcion_Ubic.Text = _Nombre_Mapa

        TxtCodigo_Ubic.ReadOnly = True
        TxtDescripcion_Ubic.ReadOnly = True

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, False, False, False)
        Grilla.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect

        _Mantencion_Ubicaciones = (_RowProducto Is Nothing)

        Btn_Agregar_Columna.Visible = _Mantencion_Ubicaciones
        Btn_Agregar_Nivel.Visible = _Mantencion_Ubicaciones
        Btn_Imprir.Visible = _Mantencion_Ubicaciones

        Sb_Crear_Estanteria()

        If (_RowProducto Is Nothing) Then '_Mantencion_Ubicaciones Then

            Me.Text = "DISEÑO Y MODIFICACION DE UBICACIONES DEL SECTOR"
            AddHandler Btn_Agregar_Columna.Click, AddressOf Sb_Agregar_Columna
            AddHandler Btn_Agregar_Nivel.Click, AddressOf Sb_Agregar_Nivel
            'AddHandler Btn_Grabar.Click, AddressOf Sb_Grabar_Ubicaciones
            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
            AddHandler Btn_Imprir.Click, AddressOf Sb_Imprimir_Ubicaciones
            Btn_Imprir.Visible = True

            Btn_Grabar.Enabled = False
            Btn_Agregar_Columna.Enabled = False
            Btn_Agregar_Nivel.Enabled = False

            AddHandler Chk_Modificar_Sector.CheckedChanging, AddressOf Sb_Chk_Modificar_Sector_ValueChanging
            AddHandler Chk_Modificar_Sector.CheckedChanged, AddressOf Sb_Chk_Modificar_Sector_ValueChange
            AddHandler Grilla.DoubleClick, AddressOf Sb_Grilla_Doble_Clic_en_celda_Ver_Productos_en_ubicacion

            Sb_Chk_Modificar_Sector_ValueChange()
        Else
            Me.Text = "PRODUCTO: " & Trim(_RowProducto.Item("KOPR")) & ", " & _RowProducto.Item("NOKOPR")

            AddHandler Grilla.CellDoubleClick, AddressOf Sb_Grilla_Doble_Clic_en_celda_Asocia_Ubicacion_Por_Producto
            'AddHandler Btn_Grabar.Click, AddressOf Sb_Grabar_ProductosXUbic

            Grilla.ContextMenuStrip = Nothing
            Chk_Modificar_Sector.Enabled = False

        End If

        AddHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter
        AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing
        AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
        AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit

        If _EsSubSector Then
            Me.Text = "DISEÑO Y MODIFICACION DE UBICACIONES DEL SUB-SECTOR"
            Me.Top += 30
            Me.Left += 30
        End If

        If _EsSubSector Then
            TxtCodigo_Ubic.Text = Replace(TxtCodigo_Ubic.Text, "...", "")
        End If

        Sb_Autoajustar_Ancho_Columnas(Grilla)

        Wbox_Cabecera.Visible = _Row_Sector.Item("EsCabecera")

        If _Row_Sector.Item("EsCabecera") Then
            Grilla.Focus()
            Grilla.CurrentCell = Grilla.Rows(0).Cells(6)
            'Sb_Grilla_Doble_Clic_en_celda_Ver_Productos_en_ubicacion()
        End If

    End Sub

    Private Sub Sb_Grilla_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        Dim Hitest As DataGridView.HitTestInfo = Grilla.HitTest(e.X, e.Y)

        If Hitest.Type = DataGridViewHitTestType.Cell Then
            Grilla.CurrentCell = Grilla.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
            Me.Cursor = Cursors.Hand
        Else
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

#Region "PROCEDIMIENTOS"

#Region "CREAR TABLA"

    Sub Sb_Crear_Estanteria()

        'dt.Clear() ' = New DataTable("TblEstante")
        'dr = Nothing
        'rs = New DataSet("Ds")

        Dim _DsEstante As DataSet


        Consulta_sql = "Declare @Id_Mapa Int = " & _Id_Mapa & "," & vbCrLf &
                      "@Nombre_Mapa Varchar(100)," & vbCrLf &
                      "@Codigo_Sector Varchar(13) = '" & _Codigo_Sector & "'" & vbCrLf &
                      "Set @Nombre_Mapa = (Select top 1 Nombre_Mapa From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Where Id_Mapa = @Id_Mapa)" & vbCrLf &
                      vbCrLf &
                      vbCrLf &
                      "SELECT Distinct Zb.Empresa,Zb.Sucursal,Zb.Bodega,Zb.Id_Mapa,Zb.Codigo_Sector,@Nombre_Mapa+' '+Zd.Nombre_Sector As 'Descripcion'" & vbCrLf &
                      "FROM " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Zb" & vbCrLf &
                      "Left Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Zd On Zb.Id_Mapa = Zd.Id_Mapa And Zb.Codigo_Sector = Zd.Codigo_Sector" & vbCrLf &
                      "WHERE Zb.Id_Mapa = @Id_Mapa" & vbCrLf &
                      "And Zb.Codigo_Sector = @Codigo_Sector" & vbCrLf &
                      "ORDER BY Zb.Codigo_Sector" &
                      vbCrLf &
                      vbCrLf &
                      "Select Distinct Columna,NomColumna From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                      "Where Id_Mapa = @Id_Mapa And Codigo_Sector = @Codigo_Sector" & vbCrLf &
                      "Order by Columna,NomColumna" &
                      vbCrLf &
                      vbCrLf &
                      "Select Distinct Fila From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                      "Where Id_Mapa = @Id_Mapa And Codigo_Sector = @Codigo_Sector" & vbCrLf &
                      "Order by Fila Desc" &
                      vbCrLf &
                      vbCrLf &
                      "Select *,Codigo_Ubic As Codigo_Ubic_Old From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                      "Where Id_Mapa = @Id_Mapa And Codigo_Sector = @Codigo_Sector" & vbCrLf &
                      "Order by Columna,Fila Desc"

        _DsEstante = _Sql.Fx_Get_DataSet(Consulta_sql)

        _TblUbicacion = _DsEstante.Tables(0)
        _TblColumnas = _DsEstante.Tables(1)
        _TblFilas = _DsEstante.Tables(2)
        _TblEstante = _DsEstante.Tables(3)

        If CBool(_TblUbicacion.Rows.Count) Then
            TxtCodigo_Ubic.Text = _TblUbicacion.Rows(0).Item("Codigo_Sector")
            TxtDescripcion_Ubic.Text = NuloPorNro(_TblUbicacion.Rows(0).Item("Descripcion").ToString, "")
        End If

        Dim _Contador = 1

        dt.Columns.Add("Alto", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Largo", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Ancho", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Peso_Max", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Desc_Ubicacion", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Fila", System.Type.[GetType]("System.String"))

        If Not CBool(_TblColumnas.Rows.Count) Then
            Dim _Columna As String = "C01"
            dr = _TblColumnas.NewRow()
            dr("Columna") = _Columna
            dr("NomColumna") = _Columna
            _TblColumnas.Rows.Add(dr)
        End If

        Me.Cursor = Cursors.WaitCursor

        For Each _Fila As DataRow In _TblColumnas.Rows
            'creamos las mismas columnas que hay en el dataset
            Dim _Columna As String = Trim(_Fila.Item("Columna"))

            Dim _Col As New DataColumn

            Try
                dt.Columns.Add(_Columna, System.Type.[GetType]("System.String"))
            Catch ex As Exception
                dt.Columns.Add(_Columna & "." & dt.Columns.Count + 1, System.Type.[GetType]("System.String"))
            End Try

        Next

        If CBool(_TblFilas.Rows.Count) Then
            For Each _Fila As DataRow In _TblFilas.Rows
                'creamos las mismas columnas que hay en el dataset
                Dim _Fila_ As String = _Fila.Item("Fila")
                dr = dt.NewRow()
                dr("Fila") = _Fila_
                dt.Rows.Add(dr)

            Next
        Else
            dr = dt.NewRow()
            dr("Fila") = "01"
            dt.Rows.Add(dr)
        End If

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With Grilla
            .DataSource = Nothing
            .DataSource = dt

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Fila").HeaderText = "NIVEL"
            .Columns("Fila").Width = 50
            .Columns("Fila").Visible = True
            .Columns("Fila").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fila").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fila").DisplayIndex = 0
            .Columns("Fila").Frozen = True

            _Contador = 1
            For Each _Fila As DataRow In _TblColumnas.Rows
                'creamos las mismas columnas que hay en el dataset
                Dim _Columna As String = _Fila.Item("Columna") '"C" & numero_(_Contador, 2) 
                Dim _NomColumna As String = _Fila.Item("NomColumna")

                .Columns(_Columna).HeaderText = _NomColumna

                .Columns(_Columna).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(_Columna).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(_Columna).Width = 50
                .Columns(_Columna).Visible = True
                .Columns(_Columna).DisplayIndex = _Contador
                _Contador += 1
            Next

        End With

        With Grilla
            Dim NCol As Integer = .ColumnCount
            For i As Integer = 0 To NCol - 1
                Dim _Columna = .Columns(i).Name.ToString()
                If .Columns(i).Visible Then
                    If _Columna <> "Fila" Then

                        For Each _Fila As DataGridViewRow In .Rows
                            'Dim _Id = _Fila.Cells("Id").Value
                            Dim _Nivel = _Fila.Cells("Fila").Value
                            'Dim _NomColumna = trae_dato(tb, cn1, "Descripcion_Ubic", _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega", _
                            '                            "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' And" & vbCrLf & _
                            '                            "Columna = '" & _Columna & "' And Fila = '" & _Nivel & "'")

                            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                                            "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' And" & vbCrLf &
                                            "Columna = '" & _Columna & "' And Fila = '" & _Nivel & "'"

                            Dim _TblUbic As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                            If CBool(_TblUbic.Rows.Count) Then
                                Dim _Descripcion_Ubic = _TblUbic.Rows(0).Item("Descripcion_Ubic")
                                Dim _Nombre_SubSector = _TblUbic.Rows(0).Item("Nombre_SubSector")
                                _Fila.Cells(_Columna).Value = _Descripcion_Ubic
                                _Fila.Cells(_Columna).ToolTipText = _Nombre_SubSector
                            End If

                        Next
                        'Dim _Cod = .Columns(i)'_Columna & " " & _Cod_Nivel 'TxtCodigo_Ubic.Text & "-" & _Columna & _Cod_Nivel
                        'dr(_Columna) = _Cod
                    End If
                End If
            Next
        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Fila").Style.BackColor = Color.Gray
        Next


        ' MARCAR LAS UBICACIONES QUE CORRESPONDAN AL PRODUCTO 

        If Not _Mantencion_Ubicaciones Then

            Sb_Marcar_Celdas_Sin_Productos_Asignados()

            Consulta_sql = "Select Codigo_Ubic From " & _Global_BaseBk & "Zw_Prod_Ubicacion" & vbCrLf &
                           "Where Codigo = '" & _RowProducto.Item("KOPR") & "' And Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'"

            Dim _TblUbicProd As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_TblUbicProd.Rows.Count) Then

                With Grilla
                    Dim NCol As Integer = .ColumnCount
                    For i As Integer = 0 To NCol - 1
                        Dim _Columna = .Columns(i).Name.ToString()
                        For Each _Fila As DataGridViewRow In Grilla.Rows

                            Dim _Nivel = _Fila.Cells("Fila").Value
                            Dim _Codigo_Ubic = TxtCodigo_Ubic.Text & NuloPorNro(_Fila.Cells(_Columna).Value, "")
                            Dim _NomColumna As String = .Columns(i).HeaderText.ToString()

                            If _Fila.Visible Then
                                If _Columna <> "Fila" And
                                   _Columna <> "Alto" And
                                   _Columna <> "Largo" And
                                   _Columna <> "Ancho" And
                                   _Columna <> "Peso_Max" And
                                   _Columna <> "Desc_Ubicacion" Then

                                    For Each _Ubic_Pro As DataRow In _TblUbicProd.Rows
                                        Dim _UbProd As String = _Ubic_Pro.Item("Codigo_Ubic")
                                        If _UbProd = _Codigo_Ubic Then
                                            _Fila.Cells(_Columna).Style.ForeColor = Color.White
                                            _Fila.Cells(_Columna).Style.BackColor = Color.Green
                                            'Else
                                            '_Fila.Cells(_Columna).Style.ForeColor = Color.Black
                                            '_Fila.Cells(_Columna).Style.BackColor = Color.White
                                        End If
                                    Next

                                End If
                            End If
                        Next
                    Next
                End With
            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "AGREGAR NIVEL"
    Sub Sb_Agregar_Nivel()

        If Fx_Tiene_Permiso(Me, "Ubic0017") Then
            Try
                If Not String.IsNullOrEmpty(Trim(TxtCodigo_Ubic.Text)) Then

                    Dim _Cod_Nivel = numero_(Grilla.RowCount + 1, 2) 'InputBox_Bk(Me, "Debe crear un código para la ubicación" & vbCrLf & _
                    '                "Se sugiere un correlativo", "AGREGAR COLUMNA", "", False, _Tipo_Mayus_Minus.Mayusculas, 12, True, _Imagen.Texto)

                    If String.IsNullOrEmpty(_Cod_Nivel) Then
                        MessageBoxEx.Show(Me, "El código no puede estar vacío", "Validación")
                        Return
                    ElseIf _Cod_Nivel = "@@Accion_Cancelada##" Then
                        Return
                    Else
                        dr = dt.NewRow()
                        dr("Fila") = _Cod_Nivel

                        With Grilla
                            Dim NCol As Integer = .ColumnCount
                            For i As Integer = 0 To NCol - 1
                                Dim _Columna = .Columns(i).Name.ToString()
                                If .Columns(i).Visible Then
                                    If _Columna <> "Fila" Then
                                        Dim _Cod = _Columna & " " & _Cod_Nivel 'TxtCodigo_Ubic.Text & "-" & _Columna & _Cod_Nivel
                                        dr(_Columna) = _Cod
                                    End If
                                End If
                            Next
                        End With

                        dt.Rows.Add(dr)

                        Dim Ch As DataGridViewColumn = Grilla.Columns.Item("Fila")
                        Grilla.Sort(Ch, ListSortDirection.Descending)
                        Grilla.Rows(0).DefaultCellStyle.BackColor = Color.Pink
                        'Sb_Grabar_Ubicaciones()

                    End If
                Else
                    MessageBoxEx.Show(Me, "FALTA EL CODIGO DE LA UBICACION", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    TxtCodigo_Ubic.Focus()
                End If
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub
#End Region

#Region "AGREGAR COLUMNA"

    'dt.Columns.Add(_Columna, System.Type.[GetType]("System.String"))
    Sub Sb_Agregar_Columna()

        Try

            If Fx_Tiene_Permiso(Me, "Ubic0016") Then

                Dim _CantColumnas = Grilla.ColumnCount - 6
                Dim _C As String ' = Grilla.ColumnCount - 6

                Dim _Existe As Boolean
                Do
                    _C = "C" & numero_(Val(_CantColumnas) + 1, 2)
                    _Existe = (Grilla.Columns(_C) Is Nothing)
                    _CantColumnas += 1
                Loop Until _Existe




                Dim Obj As New DataGridViewColumn
                Dim Col As New DataGridViewTextBoxColumn
                Obj = Col
                With Obj
                    .HeaderText = _C ' el texto que ira en la cabecera
                    .Name = _C ' Nombre de la Columna de la Grilla
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Width = 50
                End With
                Grilla.Columns.Add(Obj)
                Dim c = Grilla.ColumnCount

                For Each _Fila As DataGridViewRow In Grilla.Rows
                    _Fila.Cells(_C).Style.BackColor = Color.Pink
                Next

                'Dim _Col As New DataColumn
                '_Col.ColumnName = _C
                '_Col.DataType = System.Type.[GetType]("System.String")
                'dt.Columns.Add(_Col)

                'Sb_Grabar_Ubicaciones()
                'dt.Columns.Add()
                Btn_Agregar_Nivel.Enabled = False
                Exit Sub


                'Grilla.Columns(Grilla.Columns.Count - 1).DisplayIndex = 0 ' Es para que la columna sea la primera en la grilla
                'Dim _Col As New DataColumn
                '_Col.Namespace = "C" & numero_(_Contador, 2)
                'Dim _C As String = Grilla.ColumnCount - 6
                '_C = "C" & numero_(Val(_C) + 1, 2)
                '_Col.ColumnName = _C
                '_Col.DataType = System.Type.[GetType]("System.String")

                'dt.Columns.Add(_Cod_Columna, System.Type.[GetType]("System.String"))
                'dt.Columns.Add(_Col)


                'Grilla.Refresh()
                'Grilla.Columns(_C).HeaderText = _C '_Cod_Columna
                'Grilla.Columns(_C).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Grilla.Columns(_C).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Grilla.Columns(_C).SortMode = DataGridViewColumnSortMode.NotSortable
                'Grilla.Columns(_C).Width = 50
                'Grilla.Columns(_C).DisplayIndex = 1
                'rs.Tables.Add(dt)
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "GRABAR UBICACIONES"
    Sub Sb_Grabar_Ubicaciones()

        Dim _Grabo As Boolean

        If Fx_Tiene_Permiso(Me, "Ubic0013") Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega " & vbCrLf &
                           "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega &
                           "' And Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'" & vbCrLf & vbCrLf

            With Grilla

                Dim NCol As Integer = .ColumnCount

                For i As Integer = 0 To NCol - 1

                    Dim _Columna = .Columns(i).Name.ToString()

                    For Each _Fila As DataGridViewRow In Grilla.Rows

                        Dim _Nivel = _Fila.Cells("Fila").Value
                        Dim _Codigo_Ubic = TxtCodigo_Ubic.Text & NuloPorNro(_Fila.Cells(_Columna).Value, "")
                        Dim _Descripcion_Ubic = NuloPorNro(_Fila.Cells(_Columna).Value, "")
                        Dim _NomColumna As String = .Columns(i).HeaderText.ToString()
                        Dim _Nombre_SubSector As String

                        Dim _Es_SubSector = 0

                        Dim _Sub = Split(_Codigo_Ubic, ".", 2)
                        Dim _Sql_SubSector = String.Empty

                        If False Then '_EsSubSector Then
                            _Codigo_Ubic = Replace(_Codigo_Ubic, "...", "")
                        Else
                            If _Sub.Length = 2 Then
                                If _Sub(1) = ".." Then

                                    _Nombre_SubSector = _Fila.Cells(_Columna).ToolTipText

                                    _Es_SubSector = 1

                                    _Sql_SubSector = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                                                     "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal &
                                                     "' And Bodega = '" & _Bodega & "' And Id_Mapa = " & _Id_Mapa &
                                                     " And Codigo_Ubic = '" & _Codigo_Ubic & "' And Es_SubSector = 1"
                                    Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(_Sql_SubSector)

                                    If Not CBool(_Tbl.Rows.Count) Then

                                        _Sql_SubSector = "-- AGREGAMOS UN SUB SECTOR ..." & vbCrLf &
                                                         "Insert Into " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det(Empresa,Sucursal,Bodega,Id_Mapa,Tipo_Objeto,Codigo_Sector,Nombre_Sector) Values " &
                                                         "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'SUB-SECTOR','" & _Codigo_Ubic & "','" & _Nombre_SubSector & "')" & vbCrLf &
                                                         "Insert Into " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega (Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Columna,NomColumna,Fila,Codigo_Ubic,Descripcion_Ubic) Values " &
                                                         "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Ubic & "','C01','C01','01','','')" & vbCrLf & vbCrLf

                                    End If
                                End If
                            End If
                        End If

                        If _Fila.Visible Then

                            If _Columna <> "Fila" And
                               _Columna <> "Alto" And
                               _Columna <> "Largo" And
                               _Columna <> "Ancho" And
                               _Columna <> "Peso_Max" And
                               _Columna <> "Desc_Ubicacion" Then

                                Dim _Codigo_Ubic_Old = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega", "Codigo_Ubic",
                                                                         "Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' And Fila = '" & _Nivel & "' And Columna = '" & _Columna & "'")

                                If _Codigo_Ubic_Old <> _Codigo_Ubic Then
                                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set Codigo_Ubic = '" & _Codigo_Ubic & "'" & Space(1) &
                                                    "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' " &
                                                    "And Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' " &
                                                    "And Codigo_Ubic = '" & _Codigo_Ubic_Old & "'" & vbCrLf
                                End If

                                Consulta_sql +=
                                "Insert Into " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega (Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector," &
                                "Columna,NomColumna,Fila,Es_SubSector,Codigo_Ubic,Descripcion_Ubic,Nombre_SubSector) Values " &
                                "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector &
                                "','" & _Columna & "','" & _NomColumna & "','" & _Nivel &
                                "'," & _Es_SubSector & ",'" & _Codigo_Ubic & "','" & _Descripcion_Ubic & "','" & _Nombre_SubSector & "')" & vbCrLf & _Sql_SubSector & vbCrLf

                            End If

                        End If

                    Next

                Next

            End With

            _Grabo = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Sb_Marcar_Celdas_Sin_Productos_Asignados()

        If _Grabo Then
            MessageBoxEx.Show(Me, "Datos guardados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub


#End Region

#Region "GRABAR UBICACION POR PRODUCTO"
    Sub Sb_Grabar_ProductosXUbic()

        Try

            Dim _Codigo = _RowProducto.Item("KOPR")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Ubicacion" & vbCrLf &
                            "Where Empresa = '" & _Empresa &
                            "' And Sucursal = '" & _Sucursal &
                            "' And Bodega = '" & _Bodega &
                            "' And Codigo = '" & _Codigo & "' And Primaria = 1"

            Dim _RowUbicacion_pri As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Arreglo(0) As String
            Dim _i = 0

            With Grilla
                Dim NCol As Integer = .ColumnCount
                For i As Integer = 0 To NCol - 1
                    Dim _Columna = .Columns(i).Name.ToString()
                    For Each _Fila As DataGridViewRow In Grilla.Rows

                        Dim _Nivel = _Fila.Cells("Fila").Value
                        Dim _Codigo_Ubic = TxtCodigo_Ubic.Text & NuloPorNro(_Fila.Cells(_Columna).Value, "")
                        Dim _NomColumna As String = .Columns(i).HeaderText.ToString()

                        If _Fila.Visible Then
                            If _Columna <> "Fila" And
                               _Columna <> "Alto" And
                               _Columna <> "Largo" And
                               _Columna <> "Ancho" And
                               _Columna <> "Peso_Max" And
                               _Columna <> "Desc_Ubicacion" Then
                                If _Fila.Cells(_Columna).Style.BackColor = Color.Green Then
                                    If (_Arreglo Is Nothing) Then
                                        _Arreglo(_i) = _Codigo_Ubic
                                        _i += 1
                                        ReDim Preserve _Arreglo(_i)
                                    Else
                                        If PosicionEnArray(_Arreglo, _Codigo_Ubic) = -1 Then
                                            _Arreglo(_i) = _Codigo_Ubic
                                            _i += 1
                                            ReDim Preserve _Arreglo(_i)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Ubicacion" & vbCrLf &
                                          "Where Empresa = '" & _Empresa &
                                          "' And Sucursal = '" & _Sucursal &
                                          "' And Bodega = '" & _Bodega &
                                          "' And Id_Mapa = " & _Id_Mapa &
                                          "  And Codigo_Sector = '" & _Codigo_Sector &
                                          "' And Codigo = '" & _Codigo & "'" & vbCrLf & vbCrLf
                _Sql.Ej_consulta_IDU(Consulta_sql)


                If CBool(_i) Then
                    For Each _Ubicaciones As String In _Arreglo
                        If Not (_Ubicaciones Is Nothing) Then
                            Dim _CodUbicacion = _Ubicaciones

                            Dim Fm As New Frm_05_UbicXpro_UbicacionConProductos(_RowBodega,
                                                                                _Id_Mapa, _Codigo_Sector, _CodUbicacion)
                            Fm.Fx_Agregar_producto_ubicacion(Me, _Codigo, False)

                        End If
                    Next

                    Dim _Id_Mapa_Pri, _Codigo_Sector_Pri, _Codigo_Ubic_Pri As String

                    ' ACA QUEDA HAY QUE CONFIGURAR LA UBICACION PRIMARIA DEL PRODUCTO.

                    If Not CBool(_RowUbicacion_pri.Rows.Count) Then
                        If Not (_Arreglo Is Nothing) Then
                            _Codigo_Ubic_Pri = _Arreglo(0)
                            _Id_Mapa_Pri = _Id_Mapa
                            _Codigo_Sector_Pri = _Codigo_Sector
                        End If
                    Else
                        _Id_Mapa_Pri = _RowUbicacion_pri.Rows(0).Item("Id_Mapa")
                        _Codigo_Sector_Pri = _RowUbicacion_pri.Rows(0).Item("Codigo_Sector")
                        _Codigo_Ubic_Pri = _RowUbicacion_pri.Rows(0).Item("Codigo_Ubic")
                    End If

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set Primaria = 0" & vbCrLf &
                                   "Where Empresa = '" & _Empresa &
                                   "' And Sucursal = '" & _Sucursal &
                                   "' And Bodega = '" & _Bodega &
                                   "' And Codigo = '" & _Codigo & "'" & vbCrLf & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set Primaria = 1" & vbCrLf &
                                   "Where" & vbCrLf &
                                   "  Id_Mapa = '" & _Id_Mapa_Pri &
                                   "' And Codigo_Sector = '" & _Codigo_Sector_Pri &
                                   "' And Codigo_Ubic = '" & _Codigo_Ubic_Pri &
                                   "' And Codigo = '" & _Codigo & "'" & vbCrLf & vbCrLf &
                                   "Update TABBOPR Set DATOSUBIC = '" & _Codigo_Ubic_Pri & "'" & vbCrLf &
                                   "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal &
                                   "' AND KOBO = '" & _Bodega & "' AND KOPR = '" & _Codigo & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End With

            _Grabar = True
            Me.Close()

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        End Try

    End Sub

    Private Function PosicionEnArray(Matriz() As String, Buscamos As String) As Single
        Dim Elemento As Single
        For Elemento = LBound(Matriz) To UBound(Matriz)
            If Matriz(Elemento) = Buscamos Then
                PosicionEnArray = Elemento
                Exit Function
            End If
        Next
        PosicionEnArray = -1
    End Function


#End Region

#Region "CLIC DERECHO EN GRILLA"

    Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        'Menu_Contextual.Enabled = False

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.ColumnHeader Then

                    Dim _Cabeza = Grilla.Columns(Hitest.ColumnIndex).Name
                    .CurrentCell = .Rows(0).Cells(Hitest.ColumnIndex)

                    If _Cabeza <> "Fila" Then
                        If Chk_Modificar_Sector.Checked Then
                            ShowContextMenu(Menu_Contextual_Columna)
                        End If
                    End If

                ElseIf Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)


                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

                    If _Cabeza = "Fila" Then
                        If Chk_Modificar_Sector.Checked Then
                            If Grilla.Rows.Count = 1 Then
                                Btn_Mnu_Eliminar_Fila.Enabled = False
                            Else
                                Btn_Mnu_Eliminar_Fila.Enabled = True
                            End If
                            ShowContextMenu(Menu_Contextual_Fila)
                        End If
                    Else

                        Dim _Codigo_Ubic = NuloPorNro(_Fila.Cells(_Cabeza).Value, "")

                        Dim _Sql_SubSector = String.Empty
                        Dim _Es_SubSector As Boolean = Fx_Es_SubSector(_Codigo_Ubic, _Codigo_Ubic)

                        If _Es_SubSector Then

                            ShowContextMenu(Menu_Contextual_Sub_Sector)

                        Else
                            If _Codigo_Ubic = "." Then
                                If Chk_Modificar_Sector.Checked Then
                                    Btn_Mnu_Ver_Productos_Ubicacion.Enabled = False
                                    Btn_Mnu_Dejar_Ubacion_Sub_Sector.Enabled = False
                                    Btn_Mnu_Bloquear_Ubicacion.Visible = False
                                    Btn_Mnu_Desbloquear_Ubicacion.Visible = True
                                    ShowContextMenu(Menu_Contextual_Ubicacion)
                                Else
                                    Beep()
                                    ToastNotification.Show(Me, "UBICACION BLOQUEADA",
                                                          My.Resources.delete,
                                                         1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                                End If
                            Else

                                Btn_Mnu_Desbloquear_Ubicacion.Visible = False
                                Btn_Mnu_Ver_Productos_Ubicacion.Enabled = True

                                If Chk_Modificar_Sector.Checked Then
                                    Btn_Mnu_Dejar_Ubacion_Sub_Sector.Enabled = True
                                    Btn_Mnu_Bloquear_Ubicacion.Visible = True
                                Else
                                    Btn_Mnu_Dejar_Ubacion_Sub_Sector.Enabled = False
                                    Btn_Mnu_Bloquear_Ubicacion.Visible = False
                                End If

                                ShowContextMenu(Menu_Contextual_Ubicacion)

                            End If

                        End If

                    End If

                End If

            End With
        End If

    End Sub
#End Region

#Region "DOBLE CLIC GRILLA PRODUCTOS X UBICACION"

    Sub Sb_Grilla_Doble_Clic_en_celda_Ver_Productos_en_ubicacion()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo_Ubic As String = NuloPorNro(_Fila.Cells(_Cabeza).Value, "")

        'Dim _Sub = Split(_Codigo_Ubic, ".", 2)
        Dim _Sql_SubSector = String.Empty
        Dim _Es_SubSector As Boolean = Fx_Es_SubSector(_Codigo_Ubic, _Codigo_Ubic)

        'If _Sub.Length = 2 Then
        '    If _Sub(1) = ".." Then

        '        _Codigo_Ubic = _TblUbicacion.Rows(0).Item("Codigo_Sector") & _Codigo_Ubic
        '        _Es_SubSector = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega",
        '                        "Id_Mapa = " & _Id_Mapa & " And Codigo_Ubic = '" & _Codigo_Ubic & "' And Es_SubSector = 1"))
        '    End If
        'End If

        If _Es_SubSector Then

            Dim Fm As New Frm_Ubicaciones(_RowBodega, _Id_Mapa, _Codigo_Ubic)
            Fm.Pro_RowProducto = _RowProducto
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else
            If Chk_Modificar_Sector.Checked Then
                Grilla.BeginEdit(True)
            Else
                Sb_Ver_Productos_En_La_Ubicacion(_Fila)
            End If
        End If

    End Sub

    Sub Sb_Grilla_Doble_Clic_en_celda_Asocia_Ubicacion_Por_Producto()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Valor = _Fila.Cells(_Cabeza).Value

        Dim _CodUbicacion = TxtCodigo_Ubic.Text & _Valor




        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                     "Codigo = '" & _RowProducto.Item("KOPR") &
                                                     "' And Empresa = '" & _Empresa & "' And Codigo_Ubic = '" & _CodUbicacion & "'"))

        If _Reg Then
            Beep()
            ToastNotification.Show(Me, "ESTA UBICACION YA ESTA GRABADA" & vbCrLf &
                                   "NO SE PUEDE QUITAR DESDE ACA",
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        Else

            If _Valor = "." Then
                Beep()
                ToastNotification.Show(Me, "UBICACION BLOQUEADA",
                                      My.Resources.delete,
                                     1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Else
                If _Fila.Cells(_Cabeza).Style.BackColor = Color.Green Then
                    _Fila.Cells(_Cabeza).Style.ForeColor = Color.Black
                    _Fila.Cells(_Cabeza).Style.BackColor = Color.White
                Else
                    _Fila.Cells(_Cabeza).Style.ForeColor = Color.White
                    _Fila.Cells(_Cabeza).Style.BackColor = Color.Green
                    Beep()
                    ToastNotification.Show(Me, "UBICACION SELECCIONADA",
                                           My.Resources.ok_button,
                                           1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If
            End If

        End If

        Grilla.CurrentCell = _Fila.Cells("Fila")

    End Sub

#End Region

#Region "IMPRIMIR UBICACIONES"

    Sub Sb_Imprimir_Ubicaciones()

        If Fx_Tiene_Permiso(Me, "7Brr0005") Then

            Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Where Codigo_Sector = '" & _Codigo_Sector & "'"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                Dim Fm As New Frm_ImpBarras_Ubicaciones(_Tbl.Rows(0))
                Fm.Pro_Btn_Buscar_Sectores_Enable = False
                Fm.ShowDialog(Me)
                Fm.Dispose()
            End If

        End If

    End Sub

#End Region

#End Region

    Private Sub Frm_Ubicaciones_01_Filas_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo_Ubic = NuloPorNro(_Fila.Cells(_Cabeza).Value, "")

        Dim _Es_SubSector = Fx_Es_SubSector(_Codigo_Ubic, _Codigo_Ubic)

        'Dim _Row_Ubicacion As DataRow = Fx_Row_Ubicacion(_Codigo_Ubic)

        If _Cabeza = "Fila" Or Not _Mantencion_Ubicaciones Then
            e.Cancel = True
        End If

        If _Es_SubSector Then
            e.Cancel = True
        End If

    End Sub


    Private Sub Mnu_CambiarNombreDeLaColumnaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).HeaderText

        Dim _Cod_Columna As String = _Cabeza

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Debe crear un código para la ubicación", "Cambiar nombre de la columna", _Cod_Columna,
                                     False, _Tipo_Mayus_Minus.Mayusculas, 12, True, _Tipo_Imagen.Texto.Texto)


        If _Aceptar Then

            Grilla.Columns(Grilla.CurrentCell.ColumnIndex).HeaderText = _Cod_Columna

            If MessageBoxEx.Show(Me, "¿Desea cambiar los nombres de las celdas?", "Cambiar nombre de celdas",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                For Each _Fila As DataGridViewRow In Grilla.Rows

                    Dim _Nivel As String = _Fila.Cells("Fila").Value

                    _Nivel = _Cod_Columna & _Nivel

                    Dim _Nombre_Ubicacion = _Fila.Cells(Grilla.CurrentCell.ColumnIndex).Value

                    If _Nombre_Ubicacion <> "..." Then
                        _Fila.Cells(Grilla.CurrentCell.ColumnIndex).Value = _Nivel
                    End If

                Next

            End If

        End If

    End Sub


    Sub Sb_Ver_Productos_En_La_Ubicacion(_FilaR As DataGridViewRow)

        Dim _Columna = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Descripcion_Ubic = NuloPorNro(_FilaR.Cells(_Columna).Value, "")
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Fila" Then Return

        If _Descripcion_Ubic = "." Then
            Beep()
            ToastNotification.Show(Me, "UBICACION BLOQUEADA",
                                  My.Resources.delete,
                                 1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Return
        End If

        Dim _CodUbicacion As String

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                       "Where Empresa = '" & _Empresa &
                       "' And Sucursal = '" & _Sucursal &
                       "' And Bodega = '" & _Bodega &
                       "' And Id_Mapa = " & _Id_Mapa &
                       "  And Codigo_Sector = '" & _Codigo_Sector &
                       "' AND Columna = '" & _Columna &
                       "' AND Descripcion_Ubic = '" & _Descripcion_Ubic & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _Codigo_Ubic = Replace(_Codigo_Sector, "...", "") & _Descripcion_Ubic

            _CodUbicacion = _Codigo_Ubic '_Tbl.Rows(0).Item("Codigo_Ubic")

            If Not String.IsNullOrEmpty(_Descripcion_Ubic) Then
                _Descripcion_Ubic = " -> " & _Descripcion_Ubic
            End If

            Dim Fm As New Frm_05_UbicXpro_UbicacionConProductos(_RowBodega, _Id_Mapa, _Codigo_Sector, _CodUbicacion)
            Fm.TxtUbicacion.Text = _CodUbicacion.Trim & ": " & TxtDescripcion_Ubic.Text & _Descripcion_Ubic
            Fm.Text = "Productos en la ubicación -> " & _CodUbicacion
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Marcar_Celdas_Sin_Productos_Asignados()
        Else
            MessageBoxEx.Show(Me, "Esta ubicación aun no existe en la base de datos" & vbCrLf &
                               "debe grabar para poder hacer gestión sobre esta celda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Sub Sb_Chk_Modificar_Sector_ValueChanging(sender As System.Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

        If Not Fx_Tiene_Permiso(Me, "Ubic0018") Then
            Chk_Modificar_Sector.Checked = False
            e.Cancel = True
        End If

    End Sub

    Sub Sb_Chk_Modificar_Sector_ValueChange()

        Dim _Habilitar As Boolean = Chk_Modificar_Sector.Checked

        Btn_Agregar_Columna.Enabled = _Habilitar
        Btn_Agregar_Nivel.Enabled = _Habilitar
        Btn_Grabar.Enabled = _Habilitar
        ' Btn_Imprir.Enabled = _Habilitar
        Panel_Ayuda.Enabled = _Habilitar

        Btn_Mnu_Dejar_Ubacion_Sub_Sector.Enabled = _Habilitar
        Btn_Mnu_Quitar_Sub_Sector.Enabled = _Habilitar

        Btn_Mnu_Bloquear_Ubicacion.Enabled = _Habilitar
        Btn_Mnu_Desbloquear_Ubicacion.Enabled = _Habilitar

        'If _EsSubSector Then
        '    Btn_Mnu_Dejar_Ubacion_Sub_Sector.Visible = False
        'End If

        Sb_Marcar_Celdas_Sin_Productos_Asignados()
        Return

        For Each _Fila As DataGridViewTextBoxColumn In Grilla.Columns

            Dim _NombreColumna = _Fila.Name
            Dim _Visible = _Fila.Visible

            If _Visible Then
                If _NombreColumna <> "Fila" Then
                    If _Habilitar Then
                        _Fila.ReadOnly = False
                    Else
                        _Fila.ReadOnly = True
                    End If
                End If
            End If
        Next




    End Sub


    Private Sub Btn_Ver_Mapa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Mapa.Click

        Consulta_sql = "SELECT Id_Mapa,Empresa,Sucursal,Bodega,Nombre_Mapa" & vbCrLf &
                      "FROM " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc" & vbCrLf &
                      "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega &
                      "' And Id_Mapa = " & _Id_Mapa

        Dim _TblMapa As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblMapa.Rows.Count) Then

            Dim Fm As New Frm_Formulario_Diseno_Mapa_Documentos(_TblMapa.Rows(0),
                                                                Frm_Formulario_Diseno_Mapa_Documentos._TipoDiseno.Mapa_Ver_Mapa)
            Fm.Pro_Codigo_Sector_Activo = _Codigo_Sector
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Sub Sb_Marcar_Celdas_Sin_Productos_Asignados()

        Dim _Es_SubSector As Boolean

        With Grilla

            Dim NCol As Integer = .ColumnCount

            For i As Integer = 0 To NCol - 1

                Dim _Columna = .Columns(i).Name.ToString()

                If .Columns(i).Visible Then

                    If _Columna <> "Fila" Then

                        For Each _Fila As DataGridViewRow In .Rows

                            _Es_SubSector = False

                            Dim _NomColumna = NuloPorNro(_Fila.Cells(_Columna).Value, "")
                            Dim _Codigo_Ubic = _Codigo_Sector & _NomColumna

                            _Es_SubSector = Fx_Es_SubSector(_NomColumna, _Codigo_Ubic)

                            If _NomColumna = "." Then
                                _Fila.Cells(_Columna).Style.ForeColor = Color.Black
                                _Fila.Cells(_Columna).Style.BackColor = Color.Gray
                            Else


                                'Dim _Sub = Split(_Codigo_Ubic, ".", 2)
                                'Dim _Sql_SubSector = String.Empty


                                'If _Sub.Length = 2 Then
                                '    If _Sub(1) = ".." Then
                                '        _Es_SubSector = True
                                '    End If
                                'End If

                                If _Es_SubSector Then

                                    _Fila.Cells(_Columna).Style.ForeColor = Color.Black
                                    _Fila.Cells(_Columna).Style.BackColor = Color.Khaki

                                Else

                                    _Codigo_Ubic = Replace(_Codigo_Ubic, "...", "")

                                    Dim _Cant_Producto_Asignados As Double = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                                                                  "Codigo_Ubic = '" & _Codigo_Ubic & "'")
                                    If Not CBool(_Cant_Producto_Asignados) Then
                                        _Fila.Cells(_Columna).Style.ForeColor = Color.Red
                                        _Fila.Cells(_Columna).Style.BackColor = Color.White
                                    Else
                                        _Fila.Cells(_Columna).Style.ForeColor = Color.Black
                                        _Fila.Cells(_Columna).Style.BackColor = Color.White
                                        'End If
                                    End If
                                End If

                            End If

                            If Global_Thema = 2 Then
                                _Fila.Cells("Fila").Style.ForeColor = Color.White
                            Else
                                _Fila.Cells("Fila").Style.BackColor = Color.LightGray
                            End If

                        Next

                    End If

                End If

            Next

        End With


        For Each _Fila As DataGridViewTextBoxColumn In Grilla.Columns

            Dim _NombreColumna = _Fila.Name
            Dim _Visible = _Fila.Visible

            If _Visible Then
                If _NombreColumna <> "Fila" Then
                    _Fila.ReadOnly = True
                End If
            End If
        Next

    End Sub

    Enum _Enum_Marcar_Sub_Sector
        Marcar
        Desmarcar
    End Enum

    Sub Sb_Marcar_Celdas_Sub_Sector(_Accion As _Enum_Marcar_Sub_Sector,
                                    _Valor_Celda As String,
                                    _Nombre_SubSector As String)


        With Grilla

            Dim NCol As Integer = .ColumnCount

            For i As Integer = 0 To NCol - 1

                Dim _Columna = .Columns(i).Name.ToString()

                If .Columns(i).Visible Then

                    If _Columna <> "Fila" Then

                        For Each _Fila As DataGridViewRow In .Rows

                            Dim _NomColumna = _Fila.Cells(_Columna).Value
                            Dim _Codigo_Ubic = _Codigo_Sector & _NomColumna

                            If _Accion = _Enum_Marcar_Sub_Sector.Marcar Then

                                If _NomColumna = _Valor_Celda Then
                                    _Fila.Cells(_Columna).Value = _NomColumna & "..."
                                    _Fila.Cells(_Columna).ToolTipText = _Nombre_SubSector
                                End If

                            ElseIf _Accion = _Enum_Marcar_Sub_Sector.Desmarcar Then

                                If _NomColumna = _Valor_Celda Then
                                    _Fila.Cells(_Columna).Value = Replace(_NomColumna, "...", "")
                                    _Fila.Cells(_Columna).ToolTipText = String.Empty
                                End If

                            End If

                        Next

                    End If

                End If

            Next

        End With

    End Sub

    Private Sub Sb_Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            If _Cabeza = "Fila" Then

                Lbl_Estatus_Ubicacion.Text = String.Empty
                Btn_Ver.Enabled = False

            Else

                Dim _NomColumna = _Fila.Cells(_Cabeza).Value

                If _NomColumna = "." Then

                    Lbl_Estatus_Ubicacion.Text = String.Empty
                    Btn_Ver.Enabled = False

                Else

                    Dim _Codigo_Ubic = Replace(_Codigo_Sector, "...", "") & _NomColumna
                    Dim _Cant_Producto_Asignados = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                                    "Codigo_Ubic = '" & _Codigo_Ubic & "'")

                    Dim _Es_SubSector As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega",
                                                                          "Id_Mapa = " & _Id_Mapa & " And Codigo_Ubic = '" & _Codigo_Ubic & "' And Es_SubSector = 1"))
                    If _Es_SubSector Then

                        Lbl_Estatus_Ubicacion.Text = "Está ubicación es un Sub-Sector : <b> " & _Codigo_Ubic & "</b>"
                        Btn_Ver.Enabled = False

                    Else

                        Lbl_Estatus_Ubicacion.Text = "Ubicación : <b> " & _Codigo_Ubic & "</b>, Productos asociados : <b> " & _Cant_Producto_Asignados & "</b>"
                        Btn_Ver.Enabled = True
                        Btn_Ver.Enabled = Chk_Modificar_Sector.Checked

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Btn_Ver.Refresh()
        End Try

    End Sub

    Private Sub Btn_Ver_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Ver_Productos_En_La_Ubicacion(_Fila)
    End Sub

    Private Sub Grilla_MouseLeave(sender As Object, e As System.EventArgs) Handles Grilla.MouseLeave
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Btn_Imprimir_Toma_Inventario_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Toma_Inventario.Click

        Dim _Tiene_SubSectores As Boolean

        For Each _Fila As DataRow In _TblEstante.Rows

            Dim _Es_SubSector As Boolean = _Fila.Item("Es_SubSector")

            If _Es_SubSector Then
                _Tiene_SubSectores = True
                Exit For
            End If

        Next

        Dim _Filtro_Sectores As String

        If _Tiene_SubSectores Then
            If MessageBoxEx.Show(Me, "Esta ubicación tiene Sub-Sectores." & vbCrLf &
                   "¿Desea incorporar estos productos al informe tambien?",
                     "Existente Sub-Sectores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                _Tiene_SubSectores = False
            End If
        End If

        If _Tiene_SubSectores Then
            _Filtro_Sectores = Generar_Filtro_IN(_TblEstante, "Es_SubSector", "Codigo_Ubic", False, True, "'")
            _Filtro_Sectores = Replace(_Filtro_Sectores, ")", ",'" & _Codigo_Sector & "')")
        Else
            _Filtro_Sectores = "('" & _Codigo_Sector & "')"
        End If

        Consulta_sql = "Select Zw_Ub.Empresa,Zw_Ub.Sucursal,Zw_Ub.Bodega,Zw_Ub.Codigo_Sector,Zw_Ub.Codigo_Ubic," &
                       "Zw_Ub.Codigo,Mp.NOKOPR,Zw_Ub.Primaria,Mp.UD01PR,Mp.UD02PR,Mp.RLUD,Mst.STFI1,Mst.STFI2" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Ubicacion AS Zw_Ub " & vbCrLf &
                       "Left Outer Join MAEST AS Mst ON Zw_Ub.Codigo = Mst.KOPR AND Zw_Ub.Empresa = Mst.EMPRESA AND " & vbCrLf &
                       "Zw_Ub.Sucursal = Mst.KOSU AND Zw_Ub.Bodega = Mst.KOBO Left Outer Join MAEPR AS Mp ON Zw_Ub.Codigo = Mp.KOPR" & vbCrLf &
                       "Where Zw_Ub.Id_Mapa = '" & _Id_Mapa & "' And " & vbCrLf &
                       "Zw_Ub.Codigo_Sector In " & _Filtro_Sectores & "--'" & _Codigo_Sector & "'"

        Dim _TblUbicaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_TblUbicaciones, Me, "Inventario_" & _Codigo_Sector)

    End Sub


    Private Sub Btn_Mnu_Eliminar_Columnas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Eliminar_Columnas.Click

        If Fx_Tiene_Permiso(Me, "Ubic0015") Then

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            If _Cabeza <> "Fila" Then

                Dim _Hay_Producto As Boolean

                For Each _Fila As DataGridViewRow In Grilla.Rows

                    Dim _Codigo_Ubic = _Codigo_Sector & _Fila.Cells(_Cabeza).Value

                    If _Codigo_Ubic.Contains("...") Then
                        _Hay_Producto = Fx_Tiene_Productos_El_Sector(_Id_Mapa, _Codigo_Ubic)
                    Else
                        _Hay_Producto = Fx_Tiene_Productos_La_Ubicacion(_Id_Mapa, _Codigo_Ubic)
                    End If

                    If _Hay_Producto Then
                        MessageBoxEx.Show(Me, "No se puede eliminar esta columna, ya que existen productos asociados a sus ubicaciones" & vbCrLf &
                                           "Debe quitar los productos y luego eliminar la ubicaciones", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                Next

                If Not _Hay_Producto Then Grilla.Columns.RemoveAt(Grilla.CurrentCell.ColumnIndex)

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Eliminar_Fila_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Eliminar_Fila.Click

        If Fx_Tiene_Permiso(Me, "Ubic0015") Then

            Dim _NroFila = Grilla.CurrentRow.Index
            Dim _CantFilas = Grilla.Rows.Count
            Dim _Hay_Producto As Boolean

            If _NroFila = 0 Then

                Dim NCol As Integer = Grilla.ColumnCount

                For i As Integer = 0 To NCol - 1

                    Dim _NomColumna = Grilla.Columns(i).Name.ToString()
                    Dim _Codigo_Ubic = _Codigo_Sector & Grilla.Rows(Grilla.CurrentRow.Index).Cells(_NomColumna).Value

                    If _Codigo_Ubic.Contains("...") Then
                        _Hay_Producto = Fx_Tiene_Productos_El_Sector(_Id_Mapa, _Codigo_Ubic)
                    Else
                        _Hay_Producto = Fx_Tiene_Productos_La_Ubicacion(_Id_Mapa, _Codigo_Ubic)
                    End If

                    If _Hay_Producto Then
                        MessageBoxEx.Show(Me, "No se puede eliminar esta fila, ya que existen productos asociados a sus ubicaciones" & vbCrLf &
                                           "Debe quitar los productos y luego eliminar la ubicaciones", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                Next

                If Not _Hay_Producto Then Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)

            Else

                MessageBoxEx.Show(Me, "Esta Fila no puede ser eliminada" & vbCrLf &
                                  "Debe eliminar de arriba hacia abajo", "Eliminar fila",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Cambiar_Nombre_Columna_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Cambiar_Nombre_Columna.Click

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Hay_Producto As Boolean

        If _Cabeza <> "Fila" Then

            For Each _Fila As DataGridViewRow In Grilla.Rows

                Dim _Codigo_Ubic = _Codigo_Sector & _Fila.Cells(_Cabeza).Value

                If _Codigo_Ubic.Contains("...") Then
                    _Hay_Producto = Fx_Tiene_Productos_El_Sector(_Id_Mapa, _Codigo_Ubic)
                Else
                    _Hay_Producto = Fx_Tiene_Productos_La_Ubicacion(_Id_Mapa, _Codigo_Ubic)
                End If

                If _Hay_Producto Then
                    Exit For
                End If

            Next

        End If

        _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).HeaderText


        If _Hay_Producto Then

            MessageBoxEx.Show(Me, "No es posible cambiar el nombre de esta columna, " &
                              "ya que existen productos asignados a sus ubicaciones." & vbCrLf &
                              "Para cambiar el nombre de las ubicaciones debe primero quitar los productos",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            Dim _Cod_Columna As String = _Cabeza

            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Debe crear un código para la ubicación", "Cambiar nombre de la columna", _Cod_Columna,
                                                 False, _Tipo_Mayus_Minus.Mayusculas, 12, True, _Tipo_Imagen.Texto.Texto)


            If _Aceptar Then

                Grilla.Columns(Grilla.CurrentCell.ColumnIndex).HeaderText = _Cod_Columna

                If MessageBoxEx.Show(Me, "¿Desea cambiar los nombres de las celdas?", "Cambiar nombre de celdas",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    For Each _Fila As DataGridViewRow In Grilla.Rows

                        Dim _Nivel As String = _Fila.Cells("Fila").Value

                        _Nivel = _Cod_Columna & _Nivel

                        Dim _Nombre_Ubicacion = NuloPorNro(_Fila.Cells(Grilla.CurrentCell.ColumnIndex).Value, "")

                        If Not _Nombre_Ubicacion.Contains(".") Then
                            _Fila.Cells(Grilla.CurrentCell.ColumnIndex).Value = _Nivel
                        End If

                    Next

                End If

            End If
        End If



    End Sub

    Private Sub Btn_Mnu_Objeto_Propiedades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Objeto_Propiedades.Click

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).HeaderText
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Cod_Fila As String = _Fila.Cells("Fila").Value

        If InputBox_Bk(Me, "Debe crear un código para la ubicación", "Cambiar nombre de la columna", _Cod_Fila,
                                     False, _Tipo_Mayus_Minus.Mayusculas, 12, True, _Tipo_Imagen.Texto.Texto) Then

            _Fila.Cells("Fila").Value = _Cod_Fila

        End If

    End Sub

    Private Sub Btn_Mnu_Ver_Productos_Ubicacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ver_Productos_Ubicacion.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Ver_Productos_En_La_Ubicacion(_Fila)
    End Sub

    Private Sub Btn_Mnu_Dejar_Ubacion_Sub_Sector_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Dejar_Ubacion_Sub_Sector.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo_Ubic = NuloPorNro(_Fila.Cells(_Cabeza).Value, "")
        Dim _Codigo_Sector = _Codigo_Ubic
        Dim _Nombre_SubSector As String = _Fila.Cells(_Cabeza).ToolTipText
        Dim _EsCabecera As Boolean

        Dim _Row_Ubicacion As DataRow = Fx_Row_Ubicacion(_Codigo_Ubic)

        If Not IsNothing(_Row_Ubicacion) Then
            _Codigo_Ubic = _Row_Ubicacion.Item("Codigo_Ubic")
        End If

        If _EsCabecera Then
            MessageBoxEx.Show(Me, "No se puede dejar este sector como Sub-Sector, ya que está ubicación es CABECERA", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Cant_Producto_Asignados As Double = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion", "Codigo_Ubic = '" & _Codigo_Ubic & "'")

        If CBool(_Cant_Producto_Asignados) Then
            MessageBoxEx.Show(Me, "No se puede dejar este sector como Sub-Sector, ya que existente productos asignados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_Nombre_SubSector) Then
            _Nombre_SubSector = "SUB-SECTOR " & _Fila.Cells(_Cabeza).Value
        End If

        Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa, Frm_Formulario_Diseno_Mapa_Crear_Sector._Enum_Accion.Editar)
        Fm.Codigo_Sector = _Codigo_Sector
        Fm.Nombre_Sector = _Nombre_SubSector
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then

            If String.IsNullOrEmpty(_Nombre_SubSector) Then
                MessageBoxEx.Show(Me, "El nombre no puede estar vacío", "Validación")
            Else

                Sb_Marcar_Celdas_Sub_Sector(_Enum_Marcar_Sub_Sector.Marcar, _Codigo_Sector, _Nombre_SubSector)

                _Row_Ubicacion.Item("Es_SubSector") = True
                _Row_Ubicacion.Item("Codigo_Ubic") += "..."
                _Row_Ubicacion.Item("Descripcion_Ubic") += "..."
                _Row_Ubicacion.Item("Codigo_Ubic_Old") += "..."
                _Row_Ubicacion.Item("Nombre_SubSector") = _Nombre_SubSector

                Sb_Grabar_Ubicaciones()

                Chk_Modificar_Sector.Checked = True

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Ver_Sub_Sector_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ver_Sub_Sector.Click
        Sb_Grilla_Doble_Clic_en_celda_Ver_Productos_en_ubicacion()
    End Sub

    Private Sub Btn_Mnu_Quitar_Sub_Sector_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Quitar_Sub_Sector.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Descripcion_Ubic = NuloPorNro(_Fila.Cells(_Cabeza).Value, "")

        Dim _Codigo_Sector = TxtCodigo_Ubic.Text & _Descripcion_Ubic
        _Descripcion_Ubic = Replace(_Descripcion_Ubic, "...", "")

        If Not Fx_Tiene_Productos_El_Sector(_Id_Mapa, _Codigo_Sector) Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'" &
                           vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector &
                           "' And Tipo_Objeto = 'SUB-SECTOR'"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                Sb_Marcar_Celdas_Sub_Sector(_Enum_Marcar_Sub_Sector.Desmarcar, _Descripcion_Ubic & "...", "")
                Sb_Grabar_Ubicaciones()

            End If


        Else
            MessageBoxEx.Show(Me, "No se puede quitar este sub sector, ya que contiene productos asociados a sus celdas",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Function Fx_Tiene_Productos_La_Ubicacion(_Id_Mapa As Integer, _Codigo_Ubic As String) As Boolean

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Prod_Ubicacion" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Ubic = '" & _Codigo_Ubic & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return CBool(_Tbl.Rows.Count)

    End Function

    Public Function Fx_Tiene_Productos_El_Sector(_Id_Mapa As Integer, _Cod_Sector As String) As Boolean

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Prod_Ubicacion" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Cod_Sector & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return CBool(_Tbl.Rows.Count)

    End Function

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        'If Cabeza = "CantComprar" Then
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf Validar_Keypress_Punto_En_Grilla
        'End If
    End Sub

    Public Sub Validar_Keypress_Punto_En_Grilla(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)

        ' evento Keypress  
        Dim caracter As Char = e.KeyChar

        If e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            'e.Handled = True
            SendKeys.Send(".")
            e.KeyChar = "."c
            caracter = "."
        End If


        ' referencia a la celda  
        Dim txt As TextBox = CType(sender, TextBox)

        ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
        ' es el separador decimal, y que no contiene ya el separador  
        'If (Char.IsNumber(caracter)) Or _
        '(caracter = ChrW(Keys.Back)) Or _
        '(caracter = ",") And _
        '(txt.Text.Contains(",") = False) Then
        'e.Handled = False
        'Else
        'e.Handled = True
        'End If
        'If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890,.-", Chr(Keyascii)) = 0 Then

        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890",
                 caracter) Or (caracter = ChrW(Keys.Back)) Then 'Or (caracter = ".") And (txt.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub


    Private Sub Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        If Chk_Modificar_Sector.Checked Then

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Tecla As Keys = e.KeyValue
            If _Cabeza <> "Fila" Then

                Select Case _Tecla

                    Case Keys.Enter

                        Grilla.Columns(_Cabeza).ReadOnly = False
                        Grilla.BeginEdit(True)

                        e.SuppressKeyPress = False
                        e.Handled = True

                End Select

            End If
        End If


    End Sub

    Private Sub Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Grilla.Columns(_Cabeza).ReadOnly = True

    End Sub

    Private Sub Btn_Mnu_Sector_Cambiar_Codigo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Sector_Cambiar_Codigo.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo_Ubic = NuloPorNro(_Fila.Cells(_Cabeza).Value, "")

        Dim _Sql_SubSector = String.Empty

        Dim _Row_Ubicacion As DataRow = Fx_Row_Ubicacion(_Codigo_Ubic)

        Dim _Id_Ubicacion = _Row_Ubicacion.Item("Id_Ubicacion")
        Dim _Codigo_Sector = _Row_Ubicacion.Item("Codigo_Ubic")
        Dim _Cod_Celda = _Codigo_Sector
        Dim _Codigo_Sector_Old = _Codigo_Sector
        Dim _Nombre_Sector = _Row_Ubicacion.Item("Nombre_SubSector")
        Dim _Es_SubSector = _Row_Ubicacion.Item("Es_SubSector")

        Dim _Tiene_Prod As Boolean
        Dim Fm_ As New Frm_Ubicaciones(_RowBodega, _Id_Mapa, _Codigo_Sector_Old)
        _Tiene_Prod = Fm_.Fx_Tiene_Productos_El_Sector(_Id_Mapa, _Codigo_Sector_Old)
        Fm_.Dispose()

        If _Tiene_Prod Then

            If MessageBoxEx.Show(Me, "Existen productos asociados a estas ubicaciones" & vbCrLf &
                                 "¿Esta seguro de cambiar el código del sector?", "Confirmación",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                Return
            End If

        End If

        '_Nombre_Sector = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det", "Nombre_Sector",
        '                           "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'")

        Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa, Frm_Formulario_Diseno_Mapa_Crear_Sector._Enum_Accion.Editar_Codigo)
        Fm.Codigo_Sector = _Codigo_Ubic
        Fm.Nombre_Sector = _Nombre_Sector
        Fm.Es_SubSector = True
        Fm.ShowDialog(Me)

        Dim _Grabar = Fm.Grabar
        _Codigo_Sector = Fm.Codigo_Sector
        _Nombre_Sector = Fm.Nombre_Sector
        Fm.Dispose()

        If _Grabar Then

            _Cod_Celda = _Codigo_Sector & "..."
            _Nombre_Sector = "SUB-SECTOR " & _Codigo_Sector
            _Codigo_Sector = _TblUbicacion.Rows(0).Item("Codigo_Sector") & _Codigo_Sector & "..."

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Set Codigo_Ubic = '" & _Codigo_Sector & "',Descripcion_Ubic = '" & _Cod_Celda & "',Nombre_SubSector = '" & _Nombre_Sector & "'" & vbCrLf &
                           "Where Id_Ubicacion = " & _Id_Ubicacion & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & Space(1) &
                           "Set Codigo_Sector = '" & _Codigo_Sector & "', Nombre_Sector = '" & _Nombre_Sector & "'" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'" &
                           vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Set Codigo_Sector = '" & _Codigo_Sector & "'" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'" &
                           vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Set Codigo_Ubic = Codigo_Sector+Descripcion_Ubic" & Space(1) &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'" &
                           vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set Codigo_Sector = '" & _Codigo_Sector & "'," &
                           "Codigo_Ubic = REPLACE(Codigo_Ubic,'" & _Codigo_Sector_Old & "','" & _Codigo_Sector & "')" &
                           vbCrLf &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector_Old & "'"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                _Fila.Cells(_Cabeza).Value = _Cod_Celda
                _Fila.Cells(_Cabeza).ToolTipText = _Nombre_Sector

                _Row_Ubicacion.Item("Codigo_Ubic") = _Codigo_Sector
                _Row_Ubicacion.Item("Codigo_Ubic_Old") = _Codigo_Sector
                _Row_Ubicacion.Item("Nombre_SubSector") = _Nombre_Sector
                _Row_Ubicacion.Item("Descripcion_Ubic") = _Cod_Celda

                Beep()
                ToastNotification.Show(Me, "CODIGO CAMBIADO CORRECTAMENTE",
                                       My.Resources.save,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Bloquear_Ubicacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Bloquear_Ubicacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo_Ubic As String = _Fila.Cells(_Cabeza).Value
        Dim _Row_Ubicacion As DataRow = Fx_Row_Ubicacion(_Codigo_Ubic)

        _Codigo_Ubic = _Row_Ubicacion.Item("Codigo_Ubic")

        Dim _Cant_Producto_Asignados As Double = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion", "Codigo_Ubic = '" & _Codigo_Ubic & "'")

        If CBool(_Cant_Producto_Asignados) Then
            MessageBoxEx.Show(Me, "No se puede bloquear esta ubicación, ya que existente productos asignados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Fila.Cells(_Cabeza).Value = "."
        _Fila.Cells(_Cabeza).Style.BackColor = Color.Gray

    End Sub

    Private Sub Btn_Mnu_Desbloquear_Ubicacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Desbloquear_Ubicacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Columna = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).HeaderText

        Dim _Nivel = _Fila.Cells("Fila").Value

        _Fila.Cells(_Cabeza).Value = _Columna & "" & _Nivel
        _Fila.Cells(_Cabeza).Style.BackColor = Color.White

    End Sub

    Sub Sb_Autoajustar_Ancho_Columnas(Grilla As DataGridView)

        ' Resize the master DataGridView columns to fit the newly loaded data.
        Grilla.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If (_RowProducto Is Nothing) Then
            Sb_Grabar_Ubicaciones()
        Else
            Sb_Grabar_ProductosXUbic()
        End If

    End Sub

    Private Sub Wbox_Cabecera_OptionsClick(sender As Object, e As EventArgs) Handles Wbox_Cabecera.OptionsClick

        Dim _Msj As String = "Esto significa que es una ubicación especial que actúa como cabecera de una estantería."
        _Msj = Fx_AjustarTexto(_Msj, 50)
        MessageBoxEx.Show(Me, _Msj, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Function Fx_Es_SubSector(Descripcion_Ubic As String, ByRef _Codigo_Ubic As String) As Boolean

        Dim _Es_SubSector As Boolean
        Dim _RowFlPer As DataRow() = _TblEstante.Select("Descripcion_Ubic = '" & Descripcion_Ubic & "'")

        If Convert.ToBoolean(_RowFlPer.Count) Then

            Dim _FlPer2 As DataRow = _RowFlPer(0)

            _Codigo_Ubic = _FlPer2.Item("Codigo_Ubic")
            _Es_SubSector = _FlPer2.Item("Es_SubSector")

        End If

        Return _Es_SubSector

    End Function

    Function Fx_Row_Ubicacion(_Descripcion_Ubic As String) As DataRow

        Dim _Condicion As String

        If String.IsNullOrWhiteSpace(_Descripcion_Ubic) Then
            _Condicion = "Descripcion_Ubic = '" & _Descripcion_Ubic & "' OR Descripcion_Ubic IS NULL"
        Else
            _Condicion = "Descripcion_Ubic = '" & _Descripcion_Ubic & "'"
        End If

        Dim _RowFlPer As DataRow() = _TblEstante.Select(_Condicion)
        Dim _FlPer2 As DataRow

        If Convert.ToBoolean(_RowFlPer.Count) Then
            _FlPer2 = _RowFlPer(0)
        End If

        Return _FlPer2

    End Function

    Function Fx_Row_Ubicacion(_Codigo_Ubic As String, _Descripcion_Ubic As String) As DataRow

        Dim _RowFlPer As DataRow() = _TblEstante.Select("Codigo_Ubic = '" & _Codigo_Ubic & "' And Descripcion_Ubic = '" & _Descripcion_Ubic & "'")
        Dim _FlPer2 As DataRow

        If Convert.ToBoolean(_RowFlPer.Count) Then
            _FlPer2 = _RowFlPer(0)
        End If

        Return _FlPer2

    End Function

End Class
