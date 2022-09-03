'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.Strings

Public Class Frm_Vales_Listado_Espera_Filtro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CodEntidad, _
        _SucEntidad, _
        _Razon As String

    Dim _CodProducto, _Descripcion_Producto As String
    Dim _Tido, _Nudo As String

    Public _Filtrar As Boolean
    Public _Filtro_SQL As String
    Public _SoloBuscar As Boolean


    Private Sub Frm_Vales_Listado_Espera_Filtro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _CodEntidad = String.Empty
        _CodProducto = String.Empty

        caract_combo(CmbTipoDoc)
        Consulta_sql = "SELECT TIDO as Padre,SUBSTRING(NOTIDO,1,7) as Hijo From TABTIDO Where TIDO In ('BLV','FCV')"
        CmbTipoDoc.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
        CmbTipoDoc.SelectedValue = "BLV"


        Consulta_sql = "SELECT KOFU AS Padre,KOFU+' - '+NOKOFU AS Hijo FROM TABFU ORDER BY KOFU"
        caract_combo(Cmb_Func_Marca)

        Cmb_Func_Marca.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
        Cmb_Func_Marca.SelectedValue = FUNCIONARIO


        Consulta_sql = "SELECT KOFU AS Padre,KOFU+' - '+NOKOFU AS Hijo FROM TABFU ORDER BY KOFU"
        caract_combo(Cmb_Func_Activa)

        Cmb_Func_Activa.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
        Cmb_Func_Activa.SelectedValue = FUNCIONARIO






        AddHandler Rdb_Vale_todos.CheckedChanged, AddressOf Sb_NroVale
        AddHandler Rdb_Vale_Uno.CheckedChanged, AddressOf Sb_NroVale

        AddHandler Rdb_Tipo_doc_todos.CheckedChanged, AddressOf Sb_Documento_Boleta_Factura
        AddHandler Rdb_Tipo_doc_Uno.CheckedChanged, AddressOf Sb_Documento_Boleta_Factura

        AddHandler Rdb_Func_Marca_Todos.CheckedChanged, AddressOf Sb_Funcionario_Marca
        AddHandler Rdb_Func_Marca_Uno.CheckedChanged, AddressOf Sb_Funcionario_Marca

        AddHandler Rdb_Func_Activa_Todos.CheckedChanged, AddressOf Sb_Funcionario_Activa
        AddHandler Rdb_Func_Activa_Uno.CheckedChanged, AddressOf Sb_Funcionario_Activa

        AddHandler Rdb_Fecha_Emision_Todas.CheckedChanged, AddressOf Sb_Fecha_Emision
        AddHandler Rdb_Fecha_Emision_Desde_Hasta.CheckedChanged, AddressOf Sb_Fecha_Emision

        AddHandler Rdb_Cliente_Todas.CheckedChanged, AddressOf Sb_Cliente
        AddHandler Rdb_Cliente_Uno.CheckedChanged, AddressOf Sb_Cliente

        AddHandler Rdb_Producto_Todos.CheckedChanged, AddressOf Sb_Producto
        AddHandler Rdb_Producto_Uno.CheckedChanged, AddressOf Sb_Producto

        Sb_Documento_Boleta_Factura()
        Sb_Funcionario_Marca()
        Sb_Funcionario_Activa()
        Sb_Fecha_Emision()
        Sb_Cliente()
        Sb_Producto()
        Sb_NroVale()

        If _SoloBuscar Then
            Me.ActiveControl = Txt_NroVale
        End If

    End Sub

#Region "Procedimientos"

    Sub Sb_NroVale()

        Grupo_Documentos.Enabled = Rdb_Vale_todos.Checked
        Grupo_Fecha.Enabled = Rdb_Vale_todos.Checked

        If _SoloBuscar Then
            Grupo_Cliente.Enabled = False
            Grupo_TipoEntrega.Enabled = False
            Grupo_Estado.Enabled = False
            Grupo_Func_Activa.Enabled = False
            Grupo_Func_Marca.Enabled = False
            Grupo_Productos.Enabled = False
        Else
            Grupo_Cliente.Enabled = Rdb_Vale_todos.Checked
            Grupo_TipoEntrega.Enabled = Rdb_Vale_todos.Checked
            Grupo_Estado.Enabled = Rdb_Vale_todos.Checked
            Grupo_Func_Activa.Enabled = Rdb_Vale_todos.Checked
            Grupo_Func_Marca.Enabled = Rdb_Vale_todos.Checked
            Grupo_Productos.Enabled = Rdb_Vale_todos.Checked
        End If

        LblNroVale.Enabled = Rdb_Vale_Uno.Checked
        Txt_NroVale.Enabled = Rdb_Vale_Uno.Checked

        If Rdb_Vale_Uno.Checked Then
            Txt_NroVale.Focus()
        Else
            Txt_NroVale.Text = String.Empty
        End If


    End Sub

    Sub Sb_Documento_Boleta_Factura()


        Grupo_NroVale.Enabled = Rdb_Tipo_doc_todos.Checked
        Grupo_Fecha.Enabled = Rdb_Tipo_doc_todos.Checked

        If Not _SoloBuscar Then
            Grupo_Cliente.Enabled = Rdb_Vale_todos.Checked
            Grupo_TipoEntrega.Enabled = Rdb_Vale_todos.Checked
            Grupo_Estado.Enabled = Rdb_Vale_todos.Checked
            Grupo_Func_Activa.Enabled = Rdb_Vale_todos.Checked
            Grupo_Func_Marca.Enabled = Rdb_Vale_todos.Checked
            Grupo_Productos.Enabled = Rdb_Vale_todos.Checked
        End If


        CmbTipoDoc.Enabled = Rdb_Tipo_doc_Uno.Checked
        Btn_Tipo_doc_Buscasr.Enabled = Rdb_Tipo_doc_Uno.Checked
        Txt_Documento.Enabled = Rdb_Tipo_doc_Uno.Checked

        If Rdb_Tipo_doc_Uno.Checked Then
            Txt_Documento.Focus()
        Else
            Txt_Documento.Text = String.Empty
        End If


    End Sub

    Sub Sb_Funcionario_Marca()
        Cmb_Func_Marca.Enabled = Rdb_Func_Marca_Uno.Checked
    End Sub

    Sub Sb_Funcionario_Activa()
        Cmb_Func_Activa.Enabled = Rdb_Func_Activa_Uno.Checked
    End Sub

    Sub Sb_Fecha_Emision()
        LblFecha1.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
        LblFecha2.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
        DtpFecha_desde.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
        DtpFecha_hasta.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
    End Sub

    Sub Sb_Cliente()
        Btn_Entidad_Una.Enabled = Rdb_Cliente_Uno.Checked
        Txt_Entidad.Enabled = Rdb_Cliente_Uno.Checked
    End Sub

    Sub Sb_Producto()
        Btn_Producto.Enabled = Rdb_Producto_Uno.Checked
        TxtProductoFiltro.Enabled = Rdb_Producto_Uno.Checked
    End Sub


    Sub Sb_Buscar_Vales()

        Dim _Filtro_Consulta As String

        Dim _Filtro_NroVale = String.Empty
        Dim _Filtro_Documento = String.Empty
        Dim _Filtro_FuncMarca = String.Empty
        Dim _Filtro_FuncActiva = String.Empty
        Dim _Filtro_Tipo_Entrega = String.Empty
        Dim _Filtro_Fechas = String.Empty
        Dim _Filtro_Clientes = String.Empty
        Dim _Filtro_Productos = String.Empty

        Dim _Filtro_Estados = String.Empty




        Consulta_sql = "Update Zw_Vales_Enc Set Estado = 'C' " & vbCrLf &
                        "Where (Select Case " & vbCrLf &
                        "When Id_Doc_As <> 0 Then (Select Case When CAPREX > 0 Then CAPREX/CAPRCO Else 0 End From MAEEDO" & vbCrLf &
                        "Where IDMAEEDO = Id_Doc_As)" & vbCrLf &
                        "Else 0" & vbCrLf &
                        "End ) = 1"

        _Sql.Ej_consulta_IDU(Consulta_Sql)


        ' FILTRO NRO VALE
        Dim _NroVale As String
        If Rdb_Vale_Uno.Checked And Rdb_Tipo_doc_todos.Checked Then
            _NroVale = numero_(Txt_NroVale.Text, 10)
            _Filtro_Documento = "And NroVale = '" & _NroVale & "'"
            GoTo Filtrar
        End If

        Txt_Documento.Text = Fx_Rellena_ceros(Txt_Documento.Text, 10)
        _Tido = CmbTipoDoc.SelectedValue
        _Nudo = Trim(Txt_Documento.Text)

        ' FILTRO TIPO DOCUMENTO
        If Rdb_Tipo_doc_Uno.Checked Then
            If Not String.IsNullOrEmpty(Trim(Txt_Documento.Text)) Then

                If CBool(_Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'")) Then
                    _Filtro_Documento = "And Tipo_Doc_As = '" & _Tido & "' And NroDoc_Doc_As = '" & _Nudo & "'"
                Else
                    Beep()
                    ToastNotification.Show(Me, CmbTipoDoc.Text & " NO EXISTE", My.Resources.cross, 2 * 1000, _
                                           eToastGlowColor.Red, eToastPosition.MiddleCenter)
                    Return
                End If

            Else
                _Filtro_Documento = "And Tipo_Doc_As = '" & _Tido & "'"
            End If
                GoTo Filtrar
            End If



        ' FILTRO ESTADO
        Dim _Estados(3) As String

        If Chk_VerMarcadas.Checked Then _Estados(0) = "M" Else _Estados(0) = String.Empty
        If Chk_VerActivas.Checked Then _Estados(1) = "A" Else _Estados(1) = String.Empty
        If Chk_VerCerradas.Checked Then _Estados(2) = "C" Else _Estados(2) = String.Empty
        If Chk_VerNulas.Checked Then _Estados(3) = "N" Else _Estados(3) = String.Empty

        'M' -- Marcada en caja para ser trabajada, aun no rebaja stock
        'A' Then 'Activo'  -- Marcada por Despacho, devuelve el stock del documento a la bodega para hacer GDV
        'C' Then 'Cerrado' -- Completa con todos los productos despachados, sin saldo
        'N' Then 'Nulo'    -- Nula, no se puede volver a usar el vale, se debe crear otro para el documento.


        _Filtro_Estados = Generar_Filtro_IN_Arreglo(_Estados, False)

        If _Filtro_Estados = "()" Then
            _Filtro_Estados = "''"
            _Filtro_Estados = "And Estado = 'X'"
        Else
            _Filtro_Estados = "And Estado In " & _Filtro_Estados
        End If







        ' FILTRO FUNCIONARIO MARCA
        If Rdb_Func_Marca_Uno.Checked Then
            _Filtro_FuncMarca = "And Funcionario_Marca = '" & Cmb_Func_Marca.SelectedValue & "'" & vbCrLf
        End If


        ' FILTRO FUNCIONARIO ACTIVA VALE
        If Rdb_Func_Activa_Uno.Checked Then
            _Filtro_FuncActiva = "And Funcionario_Activa = '" & Cmb_Func_Activa.SelectedValue & "'" & vbCrLf
        End If


        ' FILTRO TIPO DE ENTREGA
        If Rdb_Retira_Cliente.Checked Then
            _Filtro_Tipo_Entrega = "And Tipo_Entrega = 'C'" & vbCrLf
        ElseIf Rdb_Despacho_Domicilio.Checked Then
            _Filtro_Tipo_Entrega = "And Tipo_Entrega = 'D'" & vbCrLf
        ElseIf Rdb_Ambos.Checked Then
            _Filtro_Tipo_Entrega = String.Empty
        End If

        ' FILTRO RANGO DE FECHAS
        Dim _Fecha_Desde = DtpFecha_desde.Value
        Dim _Fecha_Hasta = DtpFecha_hasta.Value

        Dim _Ano_1 = _Fecha_Desde.Year
        Dim _Mes_1 = _Fecha_Desde.Month
        Dim _Dia_1 = _Fecha_Desde.Day

        Dim _Ano_2 = _Fecha_Hasta.Year
        Dim _Mes_2 = _Fecha_Hasta.Month
        Dim _Dia_2 = _Fecha_Hasta.Day

        If Rdb_Fecha_Emision_Desde_Hasta.Checked Then
            _Filtro_Fechas = "And Fecha_Emision BETWEEN CONVERT(DATETIME, '" & _Ano_1 & "-" & _Mes_1 & "-" & _Dia_1 & " 00:00:00', 102)" & vbCrLf & _
                             "And CONVERT(DATETIME, '" & _Ano_2 & "-" & _Mes_2 & "-" & _Dia_2 & " 23:59:59', 102)" & vbCrLf
        End If

        ' FILTRO CLIENTES
        If Rdb_Cliente_Uno.Checked Then
            If Not String.IsNullOrEmpty(Trim(_CodEntidad)) Then
                _Filtro_Clientes = "And CodEntidad = '" & _CodEntidad & "' And SucEntidad = '" & _SucEntidad & "'" & vbCrLf
            Else
                Beep()
                ToastNotification.Show(Me, "DEBE SELECCIONAR UN CLIENTE", My.Resources.cross, 2 * 1000, _
                                       eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        End If

            ' FILTRO TIPO DE PRODUCTO
            If Rdb_Producto_Uno.Checked Then
                If Not String.IsNullOrEmpty(_CodProducto) Then
                    _Filtro_Productos = "And Id_Doc_As in (Select Distinct IDMAEEDO From MAEDDO Where KOPRCT = '" & _CodProducto & "')" & vbCrLf
                Else
                    Beep()
                    ToastNotification.Show(Me, "DEBE SELECCIONAR UN PRODUCTO", My.Resources.cross, 2 * 1000, _
                                           eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If

            End If



Filtrar:
        _Filtro_Consulta = _Filtro_NroVale & _
                           _Filtro_Documento & _
                           _Filtro_Tipo_Entrega & _
                           _Filtro_Fechas & _
                           _Filtro_FuncMarca & _
                           _Filtro_FuncActiva & _
                           _Filtro_Productos & _
                           _Filtro_Clientes & _
                           _Filtro_Estados


            Consulta_sql = My.Resources.Rsc_Vales.Sql_Query_Vales_Listado
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Consulta#", _Filtro_Consulta)

            Dim Tbl_ As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

            If CBool(Tbl_.Rows.Count) Then
            _Filtro_SQL = Consulta_sql
            _Filtrar = True
            Me.Close()
            ' MessageBoxEx.Show(Me, "documentos encontaros " & Tbl_.Rows.Count)
            Else
                Beep()
                ToastNotification.Show(Me, "NO EXISTEN DATOS QUE MOSTRAR", My.Resources.cross, 2 * 1000, _
                                       eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If


    End Sub

#End Region



    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        _Filtrar = False
        Me.Close()
    End Sub

    Private Sub Btn_Tipo_doc_Buscasr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tipo_doc_Buscasr.Click
        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        With _Fm

            .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
            .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "BLV", "WHERE TIDO IN ('BLV','FCV')")
            .Rdb_Tipo_Documento_Uno.Checked = True
            .CmbTipoDeDocumentos.SelectedValue = CmbTipoDoc.SelectedValue

            .ShowDialog(Me)


            If Not (.Pro_Row_Documento_Seleccionado Is Nothing) Then

                CmbTipoDoc.SelectedValue = .Pro_Row_Documento_Seleccionado.Item("TIDO")
                Txt_Documento.Text = .Pro_Row_Documento_Seleccionado.Item("NUDO")

                Dim Fm_b As New Frm_Vales_Caja_01_MarcarDoc

                Txt_Documento.Focus()
                'If Not Fm_b.Fx_BuscarSiExiste_Vale(_Id_Doc_As) Then
                'MessageBoxEx.Show(Me, "El documento no tiene vale de entraga asociado", "Buscar documento", _
                '                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                'End If

            End If
        End With

    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Sb_Buscar_Vales()
    End Sub

    Private Sub Txt_Documento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Documento.KeyDown
        If e.KeyValue = Keys.Delete Then
            Txt_Documento.Text = String.Empty
        ElseIf e.KeyValue = Keys.Enter Then
            Sb_Buscar_Vales()
        End If
    End Sub

   

    Private Sub Btn_Entidad_Una_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Entidad_Una.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        'Fm._Crear_Editar_Entidad = False
        Fm.BtnCrearUser.Visible = False
        Fm.BtnEditarUser.Visible = False
        Fm.BtnEliminarUser.Visible = False

        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then

            _CodEntidad = Fm.Pro_RowEntidad.Item("KOEN")
            _SucEntidad = Fm.Pro_RowEntidad.Item("SUEN")

            Txt_Entidad.Text = "Entidad: " & Trim(_CodEntidad) & ", " & Fm.Pro_RowEntidad.Item("NOKOEN")

        End If
    End Sub

    Private Sub Btn_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Producto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        With Fm
            .Pro_Mostrar_Clasificaciones = False
            .Pro_Mostrar_Editar = False
            .Pro_Mostrar_Eliminar = False
            .Pro_Mostrar_Imagenes = False
            .BtnCrearProductos.Visible = False
            .Pro_Actualizar_Precios = False
            .Pro_Mostrar_Info = False
            .Pro_Tipo_Lista = "C"
            .ShowDialog(Me)

            If .Pro_Seleccionado Then

                _CodProducto = .Pro_RowProducto.Item("KOPR")
                _Descripcion_Producto = .Pro_RowProducto.Item("NOKOPR")

                TxtProductoFiltro.Text = "Código: " & _CodProducto & " - " & _Descripcion_Producto

            End If
            .Dispose()
        End With

    End Sub

    Private Sub Txt_NroVale_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_NroVale.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Buscar_Vales()
        End If
    End Sub

    Private Sub Frm_Vales_Listado_Espera_Filtro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class