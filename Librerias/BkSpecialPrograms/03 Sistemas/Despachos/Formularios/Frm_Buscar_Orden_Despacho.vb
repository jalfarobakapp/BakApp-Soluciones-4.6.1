Imports DevComponents.DotNetBar

Public Class Frm_Buscar_Orden_Despacho

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Filtro As String

    Dim _TblFiltro_Sucursales As DataTable
    Dim _TblFiltro_Clientes As DataTable
    Dim _TblFiltro_Tipo_Envios As DataTable
    Dim _TblFiltro_Tipo_Ventas As DataTable
    Dim _TblFiltro_Estados As DataTable
    Dim _TblFiltro_Productos As DataTable
    Dim _TblFiltro_Transporte As DataTable

    Dim _Ds As DataSet
    Dim _Filtrar As Boolean


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnFiltrar.ForeColor = Color.White
            Txt_Documento.FocusHighlightEnabled = False
            Txt_Nro_Encomienda.FocusHighlightEnabled = False
            Txt_Nro_OD.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Buscar_Orden_Despacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Rdb_Orden_de_despacho_Una.Checked = True
        Me.ActiveControl = Txt_Nro_OD


        Dtp_Fecha_Emision_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Emision_Hasta.Value = FechaDelServidor()

        Dtp_Fecha_Cierre_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Cierre_Hasta.Value = FechaDelServidor()

        AddHandler Rdb_Orden_de_despacho_Una.CheckedChanged, AddressOf Sb_Habilitar_Controles
        Sb_Habilitar_Controles()

    End Sub

    Private Sub Rdb_Sucursal_Algunas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Sucursal_Algunas.CheckedChanged

        If Rdb_Sucursal_Algunas.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_TblFiltro_Sucursales,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, "",
                               False, False) Then

                _TblFiltro_Sucursales = _Filtrar.Pro_Tbl_Filtro

                If _Filtrar.Pro_Filtro_Todas Then

                    Rdb_Sucursal_Todas.Checked = True
                    _TblFiltro_Sucursales = Nothing

                End If

            Else

                Rdb_Sucursal_Todas.Checked = (IsNothing(_Filtrar.Pro_Tbl_Filtro))

            End If

        End If

    End Sub

    Private Sub Rdb_Entidades_Algunas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Entidades_Algunas.CheckedChanged

        If Rdb_Entidades_Algunas.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_TblFiltro_Clientes,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, "",
                               False, False) Then

                _TblFiltro_Clientes = _Filtrar.Pro_Tbl_Filtro

                If _Filtrar.Pro_Filtro_Todas Then

                    Rdb_Entidades_Todas.Checked = True
                    _TblFiltro_Clientes = Nothing

                End If

            Else

                Rdb_Entidades_Todas.Checked = (IsNothing(_Filtrar.Pro_Tbl_Filtro))

            End If

        End If

    End Sub

    Private Sub Rdb_Tipo_de_envio_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Tipo_de_envio_Algunos.CheckedChanged

        If Rdb_Tipo_de_envio_Algunos.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            _Filtrar.Campo = "CodigoTabla"
            _Filtrar.Descripcion = "NombreTabla"

            _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPO DE ENVIO"

            If _Filtrar.Fx_Filtrar(_TblFiltro_Tipo_Envios,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And Tabla = 'SIS_DESPACHO_TIPO_ENVIO'",
                                   Nothing, False) Then

                _TblFiltro_Tipo_Envios = _Filtrar.Pro_Tbl_Filtro

                If _Filtrar.Pro_Filtro_Todas Then

                    Rdb_Tipo_de_envio_Todos.CheckValue = True
                    _TblFiltro_Tipo_Envios = Nothing

                End If

            Else

                Rdb_Tipo_de_envio_Todos.Checked = (IsNothing(_Filtrar.Pro_Tbl_Filtro))

            End If

        End If

    End Sub

    Private Sub Rdb_Tipo_de_venta_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Tipo_de_venta_Algunos.CheckedChanged

        If Rdb_Tipo_de_venta_Algunos.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            _Filtrar.Campo = "CodigoTabla"
            _Filtrar.Descripcion = "NombreTabla"

            _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPO DE VENTA"

            If _Filtrar.Fx_Filtrar(_TblFiltro_Tipo_Ventas,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And Tabla = 'SIS_DESPACHO_TIPO_VENTA'",
                                   Nothing, False) Then

                _TblFiltro_Tipo_Ventas = _Filtrar.Pro_Tbl_Filtro

                If _Filtrar.Pro_Filtro_Todas Then

                    Rdb_Tipo_de_venta_Todos.CheckValue = True
                    _TblFiltro_Tipo_Ventas = Nothing

                End If

            Else

                Rdb_Tipo_de_venta_Todos.Checked = (IsNothing(_Filtrar.Pro_Tbl_Filtro))

            End If

        End If

    End Sub

    Private Sub Rdb_Estados_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Estados_Algunos.CheckedChanged

        If Rdb_Estados_Algunos.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            _Filtrar.Campo = "CodigoTabla"
            _Filtrar.Descripcion = "NombreTabla"

            _Filtrar.Pro_Nombre_Encabezado_Informe = "ESTADOS"

            If _Filtrar.Fx_Filtrar(_TblFiltro_Estados,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And Tabla = 'SIS_DESPACHO_ESTADOS'",
                                   Nothing, False, False) Then

                _TblFiltro_Estados = _Filtrar.Pro_Tbl_Filtro

                If _Filtrar.Pro_Filtro_Todas Then

                    Rdb_Estados_Todas.CheckValue = True
                    _TblFiltro_Estados = Nothing

                End If

            Else

                Rdb_Entidades_Todas.Checked = (IsNothing(_Filtrar.Pro_Tbl_Filtro))

            End If

        End If

    End Sub

    Private Sub Rdb_Productos_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Productos_Algunos.CheckedChanged

        If Rdb_Productos_Algunos.Checked Then

            Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_TblFiltro_Productos,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                                   False, False) Then

                _TblFiltro_Productos = _Filtrar.Pro_Tbl_Filtro

                If _Filtrar.Pro_Filtro_Todas Then

                    Rdb_Productos_Todos.Checked = True
                    _TblFiltro_Productos = Nothing

                End If

            Else

                Rdb_Productos_Todos.Checked = (IsNothing(_Filtrar.Pro_Tbl_Filtro))

            End If

        End If

    End Sub
    Private Sub Rdb_Transporte_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Transporte_Algunos.CheckedChanged

        If Rdb_Transporte_Algunos.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            _Filtrar.Tabla = "TABRETI"
            _Filtrar.Campo = "KORETI"
            _Filtrar.Descripcion = "NORETI"

            _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

            If _Filtrar.Fx_Filtrar(_TblFiltro_Transporte,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And DIRETI <> ''",
                                   Nothing, False, False) Then

                _TblFiltro_Transporte = _Filtrar.Pro_Tbl_Filtro

                If _Filtrar.Pro_Filtro_Todas Then

                    Rdb_Transporte_Todos.Checked = True
                    _TblFiltro_Transporte = Nothing

                End If

            Else

                Rdb_Transporte_Todos.Checked = (IsNothing(_Filtrar.Pro_Tbl_Filtro))

            End If

        End If

    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        Sb_Filtrar()
    End Sub


    Sub Sb_Filtrar()

        Dim _Filtro_OD = String.Empty
        Dim _Filtro_Sucursales = String.Empty
        Dim _Filtro_Entidades = String.Empty
        Dim _Filtro_Tipo_de_envio = String.Empty
        Dim _Filtro_Tipo_de_venta = String.Empty
        Dim _Filtro_Estados = String.Empty
        Dim _Filtro_Fecha_Emision = String.Empty
        Dim _Filtro_Fecha_Cierre = String.Empty
        Dim _Filtro_Productos = String.Empty
        Dim _Filtro_Transporte = String.Empty
        Dim _Filtro_Nro_Encomienda = String.Empty
        Dim _Filtro_Documento = String.Empty

        If Rdb_Orden_de_despacho_Una.Checked Then
            If String.IsNullOrEmpty(Txt_Nro_OD.Text.Trim) Then
                MessageBoxEx.Show(Me, "Número no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Nro_OD.Focus()
                Return
            End If
        End If

        Dim _Filtro_SQl As String

        If Rdb_Orden_de_despacho_Una.Checked Then
            If Not String.IsNullOrEmpty(Txt_Nro_OD.Text.Trim) Then 'Rdb_Orden_de_despacho_Una.Checked Then
                Txt_Nro_OD.Text = Fx_Rellena_ceros(Txt_Nro_OD.Text, 10)
                _Filtro_OD = "And Desp.Nro_Despacho = '" & Txt_Nro_OD.Text & "'" & vbCrLf
            End If
        End If

        If Not String.IsNullOrEmpty(Txt_Nro_Encomienda.Text.Trim) Then
            _Filtro_Nro_Encomienda = "And Desp.Nro_Encomienda Like '" & Txt_Nro_Encomienda.Text & "'" & vbCrLf
        End If

        If Rdb_Orden_de_despacho_Todas.Checked Then

            If Rdb_Sucursal_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Sucursales, "Chk", "Codigo", False, True, "'")
                _Filtro_Sucursales = "And (Desp.Sucursal In " & _Filtro_SQl & ")" & vbCrLf
            End If

            If Rdb_Entidades_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Clientes, "Chk", "Codigo", False, True, "'")
                _Filtro_Entidades = "And (Desp.CodEntidad In " & _Filtro_SQl & ")" & vbCrLf
            End If

            If Rdb_Tipo_de_envio_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Tipo_Envios, "Chk", "Codigo", False, True, "'")
                _Filtro_Tipo_de_envio = "And Desp.Tipo_Envio in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Tipo_de_venta_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Tipo_Ventas, "Chk", "Codigo", False, True, "'")
                _Filtro_Tipo_de_venta = "And Desp.Tipo_Venta in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Estados_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Estados, "Chk", "Codigo", False, True, "'")
                _Filtro_Estados = "And Desp.Estado in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Productos_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Productos, "Chk", "Codigo", False, True, "'")
                _Filtro_Productos = "And Desp.Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det " &
                                    "Where Codigo In " & _Filtro_SQl & ")" & vbCrLf
            End If

            If Rdb_Transporte_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Transporte, "Chk", "Codigo", False, True, "'")
                _Filtro_Transporte = "And Transportista in " & _Filtro_SQl & vbCrLf
            End If

            If Not String.IsNullOrEmpty(Trim(Txt_Nro_Encomienda.Text)) Then
                _Filtro_Nro_Encomienda = "And Desp.Nro_Encomienda Like '" & Txt_Nro_Encomienda.Text & "'" & vbCrLf
            End If


            If Rdb_Fecha_Emision_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Emision_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Emision_Hasta.Value.Year

                _Filtro_Fecha_Emision = "And (Desp.Fecha_Emision BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


            End If

            If Rdb_Fecha_Cierre_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Cierre_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Cierre_Hasta.Value.Year

                _Filtro_Fecha_Cierre = "And (Desp.Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf

            End If

        End If

        If Not String.IsNullOrEmpty(Txt_Documento.Tag) Then
            _Filtro_Documento = "And Desp.Nro_Despacho In (Select Nro_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc Where Archidrst = 'MAEEDO' And Idrst = " & Txt_Documento.Tag & ")" & vbCrLf
        End If

        _Filtro_SQl = _Filtro_OD &
                      _Filtro_Sucursales &
                      _Filtro_Entidades &
                      _Filtro_Tipo_de_envio &
                      _Filtro_Tipo_de_venta &
                      _Filtro_Estados &
                      _Filtro_Fecha_Emision &
                      _Filtro_Fecha_Cierre &
                      _Filtro_Productos &
                      _Filtro_Transporte &
                      _Filtro_Nro_Encomienda &
                      _Filtro_Documento

        Dim _Clas_Despacho_Fx As New Clas_Despacho_Fx

        _Ds = _Clas_Despacho_Fx.Fx_Buscar_Ordenes_De_Despacho(Nothing, Nothing, "Todas", Clas_Despacho_Fx.Enum_Ver.Buscar, _Filtro_SQl, True)

        If CBool(_Ds.Tables(0).Rows.Count) Then

            Dim Fm_Fl As New Frm_Despacho_Ordenes(Frm_Despacho_Ordenes.Enum_Ver.Buscar)
            Fm_Fl.Ds = _Ds
            Fm_Fl._Correr_a_la_derecha = True
            Fm_Fl.Btn_Buscar_Despacho.Visible = False
            Fm_Fl.Btn_Nuevo_Despacho.Visible = False
            Fm_Fl.Btn_Actualizar.Visible = False
            Fm_Fl.ShowDialog(Me)
            Fm_Fl.Dispose()

        Else
            MessageBoxEx.Show(Me, "No existen datos que mostrar", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Buscar_documento_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_documento.Click

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)

        With _Fm

            .Grupo_Funcionario.Enabled = False
            .Rdb_Funcionarios_Uno.Checked = True
            .Pro_Sql_Filtro_Otro_Filtro = String.Empty
            .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
            .Rdb_Tipo_Documento_Uno.Checked = True

            Dim _Condicion As String = "WHERE TIDO IN ('BLV','FCV','NVV','GTI')" & vbCrLf &
                                       "Union" & vbCrLf &
                                       "SELECT '' As Padre,'Cualquiera...' as Hijo"


            .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "", _Condicion)
            .Rdb_Funcionarios_Uno.Checked = True
            .Grupo_Funcionario.Enabled = False
            .Rdb_FEmision_EmitidosEntre.Checked = True
            .Pro_Pago_a_Documento = True
            .Rdb_Funcionarios_Todos.Checked = True

            .ShowDialog(Me)

            If Not (.Pro_Row_Documento_Seleccionado Is Nothing) Then

                Dim _Idmaeedo = .Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")
                Dim _Tido = .Pro_Row_Documento_Seleccionado.Item("TIDO")
                Dim _Nudo = .Pro_Row_Documento_Seleccionado.Item("NUDO")
                Dim _Nro_Documento As String = _Tido & "-" & _Nudo

                Txt_Documento.Tag = _Idmaeedo
                Txt_Documento.Text = _Nro_Documento

                Btn_Quitar_Filtro_Documento.Enabled = True

            End If

            .Dispose()

        End With

    End Sub

    Private Sub Txt_Documento_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Documento.KeyDown

        Select Case e.KeyValue
            Case Keys.Enter
                If Not String.IsNullOrEmpty(Txt_Documento.Text) Then
                    Call BtnFiltrar_Click(Nothing, Nothing)
                Else
                    Call Btn_Buscar_documento_Click(Nothing, Nothing)
                End If
            Case Keys.Escape
                Btn_Quitar_Filtro_Documento.Enabled = False
                Txt_Documento.Tag = String.Empty
                Txt_Documento.Text = String.Empty
        End Select

    End Sub

    Private Sub Btn_Quitar_Filtro_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Filtro_Documento.Click
        Btn_Quitar_Filtro_Documento.Enabled = False
        Txt_Documento.Tag = String.Empty
        Txt_Documento.Text = String.Empty
    End Sub

    Private Sub Txt_Nro_OD_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Nro_OD.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call BtnFiltrar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Txt_Nro_Encomienda_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Nro_Encomienda.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call BtnFiltrar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub Sb_Habilitar_Controles()

        Grupo_Filtros.Enabled = Rdb_Orden_de_despacho_Todas.Checked
        Grupo_Fechas.Enabled = Rdb_Orden_de_despacho_Todas.Checked

        Txt_Nro_OD.Enabled = Rdb_Orden_de_despacho_Una.Checked

    End Sub

    Private Sub Rdb_Fecha_Emision_Rango_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Fecha_Emision_Rango.CheckedChanged

        Lbl_FE_desde.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Dtp_Fecha_Emision_Desde.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Lbl_FE_hasta.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Dtp_Fecha_Emision_Hasta.Enabled = Rdb_Fecha_Emision_Rango.Checked

    End Sub

    Private Sub Rdb_Fecha_Cierre_Rango_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Fecha_Cierre_Rango.CheckedChanged

        Lbl_FC_desde.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Dtp_Fecha_Cierre_Desde.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Lbl_FC_hasta.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Dtp_Fecha_Cierre_Hasta.Enabled = Rdb_Fecha_Cierre_Rango.Checked

    End Sub
End Class
