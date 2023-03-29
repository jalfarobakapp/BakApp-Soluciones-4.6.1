Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_PorProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsDocumento As DataSet
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Puerto, _Etiqueta As String
    Dim _Cantidad_Uno As Boolean
    Dim _Codigo_Ubic As String

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
    Public Property IdPrecioFuturo As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_imprimir_Archivo.ForeColor = Color.White
            BtnImprimirEtiqueta.ForeColor = Color.White
        End If

    End Sub
    Private Sub Frm_ImpBarras_PorProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        caract_combo(CmbBodega)
        Consulta_sql = "SELECT EMPRESA+';'+KOSU+';'+KOBO AS Padre,NOKOBO AS Hijo FROM TABBO" ' WHERE SEMILLA = " & Actividad
        CmbBodega.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        CmbBodega.SelectedValue = ModEmpresa & ";" & ModSucursal & ";" & ModBodega

        caract_combo(CmbLista)
        Consulta_sql = "Select 'PM' As Padre,'PM' As Hijo Union" & vbCrLf &
                       "Select 'UC' As Padre,'ULTIMA COMPRA' As Hijo Union" & vbCrLf &
                       "SELECT KOLT As Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP"
        CmbLista.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        CmbLista.SelectedValue = ListaPrecios

        Chk_ImprimiPrecioFuturo.Checked = ImprimirDesdePrecioFuturo

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT NombreEtiqueta AS Padre,NombreEtiqueta+', Cantidad de etiquetas '+RTRIM(LTRIM(STR(CantPorLinea))) AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Tbl_DisenoBarras order by NombreEtiqueta"
        Cmbetiquetas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        Cmbetiquetas.SelectedValue = _Etiqueta

        'AddHandler BtnImprimirEtiqueta.Click, AddressOf Sb_Imprimir_Etiquetas
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

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
            _Filtro_Productos = "And KOPR In " & _Filtro_Productos
        End If

        Consulta_sql = "Select KOPR AS 'Codigo',NOKOPR as 'Descripcion'," & Convert.ToInt32(_Cantidad_Uno) & " As Cantidad From MAEPR" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Filtro_Productos

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            Grilla.DataSource = _Tbl

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            '.Columns("Codigo").DefaultCellStyle.Format = "###,##"
            .Columns("Codigo").ReadOnly = True

            .Columns("Descripcion").Width = 340
            .Columns("Descripcion").HeaderText = "Descripción"
            '.Columns("Descripcion").DefaultCellStyle.Format = "###,##"
            .Columns("Descripcion").ReadOnly = True

            .Columns("Cantidad").Width = 70
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            If Not (_Tbl Is Nothing) Then

                For Each _Row As DataGridViewRow In .Rows

                    Dim _CodigoDg As String = _Row.Cells("Codigo").Value

                    For Each _Fila As DataRow In _Tbl.Rows

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
                                                  Chk_ImprimiPrecioFuturo.Checked)


                    Next

                End If

            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'MsgBox("Error inesperado", MsgBoxStyle.Exclamation, "Barras")
            'MsgBox(ex.Message)
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


End Class
