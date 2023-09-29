Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_PorProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsDocumento As DataSet
    Dim _Tbl_Productos As DataTable
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Puerto, _Etiqueta As String
    Dim _Cantidad_Uno As Boolean
    Dim _Codigo_Ubic As String
    Dim _CerrarPorConfigurar As Boolean

    Public Property Pro_Tbl_Filtro_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Productos = value
        End Set
    End Property
    Public Property Pro_Chk_Imprimir_Todas_Las_Ubicaciones() As Boolean
        Get
            Return Chk_Imprimir_Todas_Las_Ubicaciones.Checked
        End Get
        Set(value As Boolean)
            Chk_Imprimir_Todas_Las_Ubicaciones.Checked = value
        End Set
    End Property
    Public Property Pro_Cantidad_Uno() As Boolean
        Get
            Return _Cantidad_Uno
        End Get
        Set(value As Boolean)
            _Cantidad_Uno = value
        End Set
    End Property

    Public Property Codigo_Ubic As String
        Get
            Return _Codigo_Ubic
        End Get
        Set(value As String)
            _Codigo_Ubic = value
        End Set
    End Property

    Public Property ImprimirDesdePrecioFuturo As Boolean
    Public Property ListaPrecios As String
    Public Property Id_PrecioFuturo As Integer
    Public Property LimpiarCantidadesDespuesDeImprimir As Boolean
    Public Property EstacionBR1 As Boolean
    Public Property LimpiarListadoDeCodigosDespuesDeImprimir As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub
    Private Sub Frm_ImpBarras_PorProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        BtnConfiguracion.Visible = EstacionBR1
        Chk_LimpiarListadoDeCodigosDespuesDeImprimir.Checked = LimpiarListadoDeCodigosDespuesDeImprimir

        Txt_Codigo.ButtonCustom2.Visible = False

        Sb_Llenar_Combos()

        If Not IsNothing(ListaPrecios) Then CmbLista.SelectedValue = ListaPrecios

        Chk_ImprimiPrecioFuturo.Checked = ImprimirDesdePrecioFuturo


        'AddHandler BtnImprimirEtiqueta.Click, AddressOf Sb_Imprimir_Etiquetas
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Txt_Codigo.ReadOnly = False
        ActiveControl = Txt_Codigo

        AddHandler Cmbetiquetas.SelectedIndexChanged, AddressOf Sb_Cmbetiquetas_SelectedIndexChanged

        Call Sb_Cmbetiquetas_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Sub Sb_Llenar_Combos()

        caract_combo(CmbPuerto)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "LPT1" : dr("Hijo") = "Puerto LPT1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT2" : dr("Hijo") = "Puerto LPT2" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT3" : dr("Hijo") = "Puerto LPT3" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT4" : dr("Hijo") = "Puerto LPT4" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With CmbPuerto
            .DataSource = Nothing
            .DataSource = dt
        End With

        Consulta_sql = "Select NombreEtiqueta As Padre,NombreEtiqueta As Hijo from " & _Global_BaseBk & "Zw_Tbl_DisenoBarras"
        Dim _TblEtiquetas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbetiquetas)
        With Cmbetiquetas
            .DataSource = Nothing
            .DataSource = _TblEtiquetas
        End With


        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        CmbPuerto.SelectedValue = _Puerto
        Cmbetiquetas.SelectedValue = _Etiqueta

        caract_combo(CmbBodega)
        Consulta_sql = "SELECT EMPRESA+';'+KOSU+';'+KOBO AS Padre,NOKOBO AS Hijo FROM TABBO" ' WHERE SEMILLA = " & Actividad
        CmbBodega.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        CmbBodega.SelectedValue = ModEmpresa & ";" & ModSucursal & ";" & ModBodega

        caract_combo(CmbLista)
        Consulta_sql = "Select 'PM' As Padre,'PM' As Hijo Union" & vbCrLf &
                       "Select 'UC' As Padre,'ULTIMA COMPRA' As Hijo Union" & vbCrLf &
                       "SELECT KOLT As Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP"
        CmbLista.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        CmbLista.SelectedValue = ModListaPrecioVenta

    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Filtro_Productos As String

        If IsNothing(_Tbl_Filtro_Productos) Then
            _Filtro_Productos = "And 1=2"
        Else
            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "", "Codigo", False, False, "'")
            _Filtro_Productos = "And Z1.KOPR In " & _Filtro_Productos
        End If

        Consulta_sql = "Select Z1.KOPR AS 'Codigo',RLUD,Z1.NOKOPR As 'Descripcion',0 As Cantidad," &
                       "Isnull((Select Top 1 Rtrim(Ltrim(KOPRAL)) From TABCODAL Z2 Where Z1.KOPR = Z2.KOPR And KOEN = '' Order By UNIMULTI),'') As CodAlternativo " & vbCrLf &
                       "From MAEPR Z1" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Filtro_Productos

        _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            Grilla.DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodAlternativo").Width = 110
            .Columns("CodAlternativo").HeaderText = "Cód. Alternativo"
            .Columns("CodAlternativo").Visible = True
            .Columns("CodAlternativo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Width = 70
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").ReadOnly = False
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If Not (_Tbl_Productos Is Nothing) Then

                For Each _Row As DataGridViewRow In .Rows

                    Dim _CodigoDg As String = _Row.Cells("Codigo").Value

                    For Each _Fila As DataRow In _Tbl_Productos.Rows

                        Dim _CodigoTb As String = _Fila.Item("Codigo")

                        If _CodigoDg = _CodigoTb Then

                            _Row.Cells("Cantidad").Value = _Fila.Item("Cantidad")

                        End If

                    Next

                Next

            End If

        End With

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress

    End Sub

    Private Sub validar_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener el nombre de la columna
        Dim _Columna = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Columna = "Cantidad" Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) And
            (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub


#Region "PROCEDIMIENTOS"


#Region "IMPRIMIR ETIQUETAS"

    Sub Sb_Imprimir_Etiquetas()

        Try

            _Puerto = CmbPuerto.SelectedValue
            Dim _CantPorLinea As Integer

            If IsNothing(Cmbetiquetas.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            If String.IsNullOrEmpty(Cmbetiquetas.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            _CantPorLinea = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "CantPorLinea",
                                      "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'")

            If _CantPorLinea = 0 Then _CantPorLinea = 1

            Dim _TblDetalle As DataTable = Grilla.DataSource


            Dim _Suma As Double = NuloPorNro(_TblDetalle.Compute("Sum(Cantidad)", "1>0"), 0)

            If Not CBool(_Suma) Then

                Beep()
                ToastNotification.Show(Me, "NO HAY DATOS QUE IMPRIMIR",
                                      My.Resources.cross,
                                     1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return

            End If


            For Each _Fila As DataRow In _TblDetalle.Rows

                Dim CanXlinea As Double = _CantPorLinea
                Dim Veces As Double = _Fila("Cantidad").ToString()

                If CBool(Veces) Then

                    If CanXlinea = Veces Or CanXlinea > Veces Then
                        Veces = 1
                    Else
                        Dim _ModVeces = Veces Mod 2
                        Dim _ModCanXlinea = CanXlinea Mod 2

                        If CanXlinea <> 1 Then

                            If CBool(_ModVeces) Or CBool(_ModCanXlinea) Then

                                Veces = Math.Round((Veces / CanXlinea), 5)
                                Dim _Des = Split(Veces, ",")

                                If _Des.Length = 2 Then
                                    Veces = _Des(0) + 1
                                End If

                            Else
                                Veces = Math.Round((Veces / CanXlinea), 0)
                            End If
                        End If
                    End If

                    If Veces < 1 Then Veces = 1

                    Dim _Codigo = _Fila.Item("Codigo")
                    Dim _CodAlternativo = _Fila.Item("CodAlternativo")
                    Dim _Lista = CmbLista.SelectedValue

                    Dim _Empresa, _Sucursal, _Bodega As String
                    Dim _ESB() = Split(CmbBodega.SelectedValue, ";")

                    _Empresa = _ESB(0)
                    _Sucursal = _ESB(1)
                    _Bodega = _ESB(2)

                    For w = 1 To Veces

                        Dim _Imp As New Class_Imprimir_Barras

                        _Imp.Sb_Imprimir_Producto(Cmbetiquetas.SelectedValue,
                                                  _Puerto,
                                                  _Codigo,
                                                  _Lista,
                                                  _Empresa,
                                                  _Sucursal,
                                                  _Bodega,
                                                  _Codigo_Ubic,
                                                  Chk_Imprimir_Todas_Las_Ubicaciones.Checked,
                                                  Chk_ImprimiPrecioFuturo.Checked,
                                                  Id_PrecioFuturo,
                                                  _CodAlternativo)

                        If Not String.IsNullOrEmpty(_Imp.Error) Then
                            If MessageBoxEx.Show(Me, _Imp.Error, "Problema al imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) <> DialogResult.OK Then
                                Return
                            End If
                        End If

                    Next

                End If

                If LimpiarCantidadesDespuesDeImprimir Then
                    _Fila("Cantidad") = 0
                End If

            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            If Chk_LimpiarListadoDeCodigosDespuesDeImprimir.Checked Then
                Call BtnLimpiar_Click(Nothing, Nothing)
            End If
        End Try

    End Sub

#End Region

#End Region

    Private Sub Frm_ImpBarras_PorProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        _Tbl_Filtro_Productos = Nothing
        Sb_Actualizar_Grilla()
        Txt_Codigo.Focus()
    End Sub

    Private Sub BtnBuscarProducto_Click(sender As Object, e As EventArgs) Handles BtnBuscarProducto.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro

        End If

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub BtnImprimirEtiqueta_Click(sender As Object, e As EventArgs) Handles BtnImprimirEtiqueta.Click
        Sb_Imprimir_Etiquetas()
    End Sub

    Function Fx_Buscar_Producto(_Codigo As String) As DataRow

        Dim _Kopr As String = _Codigo
        Dim _Kopral As String = String.Empty

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Kopr & " '")

        If Not CBool(_Reg) Then

            _Kopral = _Codigo
            _Kopr = _Sql.Fx_Trae_Dato("TABCODAL", "KOPR", "KOEN = '' And KOPRAL = '" & _Kopral & "'")

            If String.IsNullOrEmpty(_Kopr) Then
                _Kopr = _Sql.Fx_Trae_Dato("TABCODAL", "KOPR", "KOPRAL = '" & _Kopral & "'")
            End If

            If String.IsNullOrEmpty(_Kopr) Then
                _Kopral = String.Empty
            End If

        End If

        If Not String.IsNullOrEmpty(_Kopral) Then
            Consulta_sql = "Select Top 1 *,'" & _Kopral & "' As CodAlternativo From MAEPR Where KOPR = '" & _Kopr & "'"
        Else
            Consulta_sql = "Select Top 1 Z1.KOPR,RLUD,Z1.NOKOPR," &
                           "Isnull((Select Top 1 KOPRAL From TABCODAL Z2 Where Z1.KOPR = Z2.KOPR And KOEN = '' Order By UNIMULTI),'') As CodAlternativo " & vbCrLf &
                           "From MAEPR Z1" & vbCrLf &
                           "Where KOPR = '" & _Kopr & "'"
        End If

        Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowProducto) Then
            Return _RowProducto
        Else

            If Not Fx_Tiene_Permiso(Me, "7Brr0009") Then
                Return Nothing
            End If

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_CodSucEntidad = String.Empty
            Fm.Pro_Tipo_Lista = "P"
            Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_Sucursal_Busqueda = ModSucursal
            Fm.Pro_Bodega_Busqueda = ModBodega
            Fm.Txtdescripcion.Text = _Codigo
            Fm.Pro_Mostrar_Info = True
            Fm.Pro_Actualizar_Precios = True

            Codigo_abuscar = String.Empty
            Fm.Pro_Mostrar_Clasificaciones = True
            Fm.Pro_Mostrar_Imagenes = True

            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then

                Dim _Row As DataRow = Fm.Pro_RowProducto

                ' Supongamos que tienes un DataRow llamado "row" y deseas agregar una columna llamada "NuevaColumna"
                Dim dataTable As DataTable = _Row.Table
                Dim nuevaColumna As New DataColumn("CodAlternativo", GetType(String)) ' Aquí especifica el tipo de datos de la columna

                ' Agregar la columna a la colección de columnas de la tabla
                dataTable.Columns.Add(nuevaColumna)

                ' Asignar un valor a la nueva columna en el DataRow
                _Row("CodAlternativo") = Fm.Txt_CodAlternativo.Text.Trim ' Aquí asigna el valor deseado a la nueva columna

                Return _Row '_TblProducto.Rows(0)
            Else
                Return Nothing
            End If

        End If

    End Function

    Private Sub Btn_imprimir_Archivo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_imprimir_Archivo.Click

        Dim _Filas_X_Documento As String = 10

        Try
            Dim _Aceptado As Boolean

            _Aceptado = InputBox_Bk(Me, "Indique la cantidad de productos por hoja", "Códigos por pagina",
                                         _Filas_X_Documento, False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Barra,
                                         False, _Tipo_Caracter.Solo_Numeros_Enteros, False)

            If Not _Aceptado Or _Filas_X_Documento = 0 Then
                Exit Sub
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End Try

        Dim _TblDetalle As DataTable = Grilla.DataSource

        If CBool(_TblDetalle.Rows.Count) Then

            Dim _Codigos = Generar_Filtro_IN(_TblDetalle, "", "Codigo", False, False, "'")

            Consulta_sql = "Select CAST( 0 AS bit) AS Impreso,1 As Contador,* From MAEPR WHERE KOPR IN " & _Codigos
            _TblDetalle = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _ClaImprimir_Barras As New Clas_Imprimir_Barras

            Dim _ESB() = Split(CmbBodega.SelectedValue, ";")

            _ClaImprimir_Barras._Empresa = _ESB(0)
            _ClaImprimir_Barras._Sucursal = _ESB(1)
            _ClaImprimir_Barras._Bodega = _ESB(2)
            _ClaImprimir_Barras._Filas_X_Documento = _Filas_X_Documento
            _ClaImprimir_Barras._TblProductos = _TblDetalle
            _ClaImprimir_Barras.Fx_Imprimir_Archivo(Me, "Productos_Barras", "")

        Else

            Beep()
            ToastNotification.Show(Me, "NO HAY DATOS QUE IMPRIMIR",
                                  My.Resources.cross,
                                 1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Txtcodigo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Codigo.ButtonCustomClick

        Try

            Txt_Codigo.Enabled = False

            Dim _Codigo As String = Txt_Codigo.Text
            Dim _Row_Producto As DataRow = Fx_Buscar_Producto(_Codigo)

            If IsNothing(_Row_Producto) Then
                Txt_Codigo.Text = String.Empty
                Return
            End If


            Dim _Rows As DataRow() = _Tbl_Productos.Select("Codigo = '" & _Row_Producto.Item("KOPR") & "'")

            If CBool(_Rows.Count) Then
                MessageBoxEx.Show(Me, "Este producto ya esta en el listado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                BuscarDatoEnGrilla(_Codigo, "Codigo", Grilla)
                Txt_Codigo.Text = String.Empty
                Return
            End If

            Dim _FechaHoy As DateTime = FechaDelServidor()

            Consulta_sql = "Select Dres.CODIGO,Dres.NREG,Dres.ELEMENTO,NOKOPR,Eres.LISTAS" & vbCrLf &
                       "From MAEDRES Dres" & vbCrLf &
                       "Inner Join MAEERES Eres On Eres.CODIGO = Dres.CODIGO" & vbCrLf &
                       "Left Join MAEPR On KOPR = Dres.ELEMENTO" & vbCrLf &
                       "Where '" & Format(_FechaHoy, "yyyyMMdd") & "' Between Eres.FIOFERTA And Eres.FTOFERTA --And Eres.LISTAS Like '%PB7%'" & vbCrLf &
                       "And Dres.ELEMENTO = '" & Txt_Codigo.Text & "' "
            Dim _TblOfertas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_TblOfertas.Rows.Count) Then

                Dim info As New TaskDialogInfo("Información",
                                eTaskDialogIcon.ShieldStop, "¡ *** Producto En OFERTA *** !",
                                vbCrLf & vbCrLf & "Código: " & _Row_Producto.Item("KOPR").ToString.Trim & vbCrLf &
                                "Descripción: " & _Row_Producto.Item("NOKOPR").ToString.Trim,
                                 eTaskDialogButton.Ok _
                                 , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)

                Dim result As eTaskDialogResult = TaskDialog.Show(info)

            End If


            Dim _Cantidad = 0
            If _Cantidad_Uno Then _Cantidad = 1
            Sb_Agregar_Producto(_Tbl_Productos, _Row_Producto.Item("KOPR"), _Row_Producto.Item("NOKOPR"), _Cantidad, _Row_Producto.Item("CodAlternativo"))

            Txt_Codigo.Text = String.Empty
            Txt_Codigo.ButtonCustom.Visible = False
            Txt_Codigo.ButtonCustom2.Visible = True

            'End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            If String.IsNullOrEmpty(Txt_Codigo.Text) Then
                Txt_Codigo.ButtonCustom.Visible = True
                Txt_Codigo.ButtonCustom2.Visible = False
            End If

            Txt_Codigo.Enabled = True
            Txt_Codigo.Focus()
        End Try

    End Sub

    Private Sub Txtcodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Codigo.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrEmpty(Txt_Codigo.Text) Then
                Return
            End If
            Call Txtcodigo_ButtonCustomClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub Txt_Codigo_ButtonCustom2Click_1(sender As Object, e As EventArgs) Handles Txt_Codigo.ButtonCustom2Click
        Txt_Codigo.Text = String.Empty
        Txt_Codigo.ButtonCustom.Visible = True
        Txt_Codigo.ButtonCustom2.Visible = False
    End Sub

    Private Sub Btn_Conf_ConfEstacion_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfEstacion.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then

            Dim _Grabar As Boolean

            Dim _Id = _Global_Row_EstacionBk.Item("Id")
            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Editar, _Id, False)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            Dim _Mod As New Clas_Modalidades

            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _NombreEquipo & "'"
            _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _Grabar Then
                _CerrarPorConfigurar = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_Conf_PuertoEtiqueta_Click(sender As Object, e As EventArgs) Handles Btn_Conf_PuertoEtiqueta.Click

        If Not Fx_Tiene_Permiso(Me, "7Brr0006") Then Return

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            CmbPuerto.SelectedValue = Fm.Puerto
            Cmbetiquetas.SelectedValue = Fm.Etiqueta
        End If
        Fm.Dispose()

    End Sub

    Private Sub Frm_ImpBarras_PorProducto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If EstacionBR1 And Not _CerrarPorConfigurar Then
            If Not Fx_Tiene_Permiso(Me, "7Brr0007") Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Btn_ConfPuertoXEtiquetaXEquipo_Click(sender As Object, e As EventArgs) Handles Btn_ConfPuertoXEtiquetaXEquipo.Click

        If Not Fx_Tiene_Permiso(Me, "7Brr0008") Then Return

        Dim _Grabar As Boolean

        Dim Fm As New Frm_PuertosXEtiquetaXEstacion
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Call Sb_Cmbetiquetas_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub Sb_Cmbetiquetas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Semilla As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "Semilla",
                                                    "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'", True)
        Dim _Puerto As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras_SalPtoxEstacion", "Puerto",
                                                  "Semilla_Padre = " & _Semilla & " And NombreEquipo = '" & _NombreEquipo & "'")

        If Not String.IsNullOrEmpty(_Puerto) Then
            CmbPuerto.SelectedValue = _Puerto
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "CodAlternativo" Then

            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value.ToString.Trim

            Dim _Rtu As Double = _Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & _Codigo & "'")
            Dim _RowTabcodal As DataRow

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo & "'")

            If _Reg = 0 Then
                MessageBoxEx.Show(Me, "Este producto no tiene códigos alternativos asociados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _Codigo
            Fm.Txtdescripcion.Text = _Descripcion
            Fm.TxtRTU.Text = _Rtu
            Fm.ModoSeleccion = True
            Fm.ShowDialog(Me)
            _RowTabcodal = Fm.RowTabcodalSeleccionado
            Fm.Dispose()

            If Not IsNothing(_RowTabcodal) Then
                _Fila.Cells("CodAlternativo").Value = _RowTabcodal.Item("KOPRAL")
            End If

        End If

    End Sub

    Sub Sb_Agregar_Producto(ByRef _Tbl As DataTable,
                             _Codigo As String,
                             _Descripcion As String,
                             _Cantidad As Integer,
                             _CodAlternativo As String)
        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Codigo") = _Codigo.Trim
            .Item("Descripcion") = _Descripcion.Trim
            .Item("Cantidad") = _Cantidad
            .Item("CodAlternativo") = _CodAlternativo.Trim

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

End Class
