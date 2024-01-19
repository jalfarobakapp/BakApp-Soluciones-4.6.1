Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Permisos_Asociados_New

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Matriz_Documentos As Ds_Matriz_Documentos
    Dim _Tbl_Permisos_Doc As DataTable

    Dim _Row_Entidad As DataRow

    Dim _Tbl_Funcionarios_X_01_Stock As DataTable
    Dim _Tbl_Funcionarios_X_02_Descuentos As DataTable
    Dim _Tbl_Funcionarios_X_03_Morosidad As DataTable
    Dim _Tbl_Funcionarios_X_04_Cupo_Excedido As DataTable
    Dim _Tbl_Funcionarios_X_05_Fecha_Despacho As DataTable
    Dim _Tbl_Funcionarios_X_06_Solcitud_Compra As DataTable
    Dim _Tbl_Funcionarios_X_07_Min_Despacho As DataTable
    Dim _Tbl_Funcionarios_X_08_Min_Venta_NVV As DataTable

    Dim _Id_Enc As Integer
    Dim _Id_DocEnc As Integer
    Dim _Nro_RCadena As String

    Dim _Autorizado_Para_Grabar As Boolean
    Dim _Enviar_Solicitudes As Boolean

    Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento

    Public ReadOnly Property Pro_Id_Enc() As Integer
        Get
            Return _Id_Enc
        End Get
    End Property
    Public ReadOnly Property Pro_Id_DocEnc() As Integer
        Get
            Return _Id_DocEnc
        End Get
    End Property
    Public ReadOnly Property Pro_Nro_RCadena() As String
        Get
            Return _Nro_RCadena
        End Get
    End Property
    Public ReadOnly Property Pro_Autorizado_Para_Grabar() As Boolean
        Get
            Return _Autorizado_Para_Grabar
        End Get
    End Property
    Public ReadOnly Property Pro_Enviar_Solicitudes() As Boolean
        Get
            Return _Enviar_Solicitudes
        End Get
    End Property

    Public Sub New(Ds_Matriz_Documentos As DataSet,
                   RowEntidad As DataRow,
                   Tipo_Documento As csGlobales.Enum_Tipo_Documento)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Ds_Matriz_Documentos = Ds_Matriz_Documentos

        _Tbl_Permisos_Doc = _Ds_Matriz_Documentos.Tables("Permisos_Doc")

        _Row_Entidad = RowEntidad
        _Tipo_Documento = Tipo_Documento

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        If Global_Thema = 2 Then ' Dark
            Btn_Enviar_Solicitudes_Cadenas_Remotas.ForeColor = Color.White
            Btn_Ver_Infor_Morosidad_Cupo.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Formulario_Permisos_Asociados_New_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Formulario_Permisos_Asociados_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra Then
            Btn_Ver_Infor_Morosidad_Cupo.Visible = False
        ElseIf _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta Then
            Btn_Ver_Infor_Morosidad_Cupo.Visible = True
        End If

        Sb_InsertarBotonenGrilla(Grilla, "Btn_Estado", "Est.", "Btn_Estado", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "Btn_Accion", "Opciones...", "Btn_Accion", 1, _Tipo_Boton.Boton)

        Sb_InsertarBotonenGrilla(Grilla, "Txt_Hay_Funcionario", "Hay", "Txt_Hay_Funcionario", 2, _Tipo_Boton.Texto)

        Sb_Acualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dim _Row_Encabezado As DataRow = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)

        Dim _Tido = _Row_Encabezado.Item("TipoDoc")

        Btn_Enviar_Solicitudes_Cadenas_Remotas.Visible = (_Tido = "NVV" Or _Tido = "OCC")

    End Sub

    Sub Sb_Acualizar_Grilla()

        Dim _Row_Encabezado As DataRow = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)

        Dim _Vizado = _Row_Encabezado.Item("Vizado")

        With Grilla

            .DataSource = _Tbl_Permisos_Doc

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Btn_Estado").Width = 50
            .Columns("Btn_Estado").HeaderText = "Est."
            .Columns("Btn_Estado").Visible = True
            .Columns("Btn_Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodPermiso").Visible = True
            .Columns("CodPermiso").HeaderText = "Permiso"
            .Columns("CodPermiso").Width = 70
            .Columns("CodPermiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DescripcionPermiso").Visible = True
            .Columns("DescripcionPermiso").HeaderText = "Descripcion"
            .Columns("DescripcionPermiso").Width = 420
            .Columns("DescripcionPermiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomFuncionario_Autoriza").Visible = True
            .Columns("NomFuncionario_Autoriza").HeaderText = "Autorizado por"
            .Columns("NomFuncionario_Autoriza").Width = 200
            .Columns("NomFuncionario_Autoriza").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Btn_Accion").Width = 100
            .Columns("Btn_Accion").HeaderText = "Acción"
            .Columns("Btn_Accion").Visible = True
            .Columns("Btn_Accion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Btn_Pedir_Permiso").Width = 100
            '.Columns("Btn_Pedir_Permiso").HeaderText = "."
            '.Columns("Btn_Pedir_Permiso").Visible = True
            '.Columns("Btn_Pedir_Permiso").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1


        End With

        'Btn_Reenviar.Visible = False

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _NroRemota = _Fila.Cells("NroRemota").Value
            Dim _CodFuncionario_Autoriza = _Fila.Cells("CodFuncionario_Autoriza").Value
            Dim _NomFuncionario_Autoriza = _Fila.Cells("NomFuncionario_Autoriza").Value
            Dim _Necesita_Permiso = _Fila.Cells("Necesita_Permiso").Value
            Dim _Autorizado = _Fila.Cells("Autorizado").Value
            Dim _PermisoIndependiente = _Fila.Cells("PermisoIndependiente").Value
            Dim _Solicitar_Permiso_Al_Final = _Fila.Cells("Solicitar_Permiso_Al_Final").Value

            Dim _Icono As Image

            If _Autorizado Then
                _Icono = Imagenes_16x16.Images.Item("secure_ok.png")
            Else
                _Icono = Imagenes_16x16.Images.Item("delete_button_error.png")
            End If

            If (_Necesita_Permiso Or _Autorizado) And (Not _PermisoIndependiente Or _Solicitar_Permiso_Al_Final) Then
                _Fila.Visible = True
            Else
                Grilla.CurrentCell = Nothing
                _Fila.Visible = False
            End If

            _Fila.Cells("Btn_Estado").Value = _Icono

        Next

        Me.Refresh()

    End Sub

    Private Sub Grilla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Autorizado = _Fila.Cells("Autorizado").Value

        If _Cabeza = "Btn_Accion" Then

            If Not _Autorizado Then

                Dim _Row_Encabezado As DataRow = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)

                Dim _Tido = _Row_Encabezado.Item("TipoDoc")

                Btn_Seleccionar_Funcionarios.Enabled = ((_Tido = "NVV") Or (_Tido = "OCC"))

                ShowContextMenu(Menu_Contextual_01)

            Else

                MessageBoxEx.Show(Me, "El permiso ya esta otorgado", "Permiso", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)

            End If

        End If

    End Sub

    Private Sub Btn_Enviar_Solicitudes_Cadenas_Remotas_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Solicitudes_Cadenas_Remotas.Click

        Dim _Faltan_Seleccionar_Funcionarios = 0

        'Bkp00015 - Stock
        'Bkp00014 - Descuentos a nivel Global
        'Bkp00019 - Morosidad Cliente
        'Bkp00033 - Cupo Exedido
        'Bkp00057 - Fecha de despacho
        'ODp00017 - Min Kilos y Ventas para despachar

        'Comp0092 -> AUTORIZAR COMPRA (SOC) -> Depende del monto asignado en Campo Valor_Max_Compra de la tabla ZW_PermisosVsUsuarios
        'Bkp00062 - Minimo de venta por documento NVV

        Dim _Cl_Permisos_Asociados As New Cl_Permisos_Asociados(_Ds_Matriz_Documentos)

        For Each _Row As DataRow In _Tbl_Permisos_Doc.Rows

            Dim _Necesita_Permiso = _Row.Item("Necesita_Permiso")
            Dim _Autorizado = _Row.Item("Autorizado")
            Dim _CodPermiso = _Row.Item("CodPermiso")

            Dim _Tbl As DataTable

            Dim _Revisar = True

            Select Case _CodPermiso
                Case "Bkp00015"
                    _Tbl = _Tbl_Funcionarios_X_01_Stock
                Case "Bkp00014", "Bkp00039"
                    _Tbl = _Tbl_Funcionarios_X_02_Descuentos
                Case "Bkp00019"
                    _Tbl = _Tbl_Funcionarios_X_03_Morosidad
                Case "Bkp00033"
                    _Tbl = _Tbl_Funcionarios_X_04_Cupo_Excedido
                Case "Bkp00057"
                    _Tbl = _Tbl_Funcionarios_X_05_Fecha_Despacho
                Case "Comp0092"
                    _Revisar = False
                Case "ODp00017"
                    _Tbl = _Tbl_Funcionarios_X_07_Min_Despacho
                Case "Bkp00062"
                    _Tbl = _Tbl_Funcionarios_X_08_Min_Venta_NVV
            End Select

            If _Revisar Then

                If _Necesita_Permiso Then

                    If Not _Autorizado Then

                        If _Tbl Is Nothing Then
                            _Faltan_Seleccionar_Funcionarios += 1
                        Else

                            If Not CBool(_Tbl.Rows.Count) Then
                                _Faltan_Seleccionar_Funcionarios += 1
                            End If

                        End If

                    End If

                End If

            End If

        Next

        If CBool(_Faltan_Seleccionar_Funcionarios) Then

            MessageBoxEx.Show(Me, "Falta que seleccione funcionarios para algunos permisos pendientes" & vbCrLf &
                              "Para seleccionar los funcionarios debe presionar el botón <Opciones -> Seleccionar funcionarios para enviar permiso y esperar>", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Orden = 0

        Dim _Row_Encabezado As DataRow = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)
        Dim _Tido = _Row_Encabezado.Item("TipoDoc")

        If _Tido = "NVV" Then

            Dim _Revisar_Nuevamente_por_Stock As Boolean

            If IsNothing(_Tbl_Funcionarios_X_01_Stock) Then

                Dim _TblDetalle As DataTable = _Ds_Matriz_Documentos.Tables("Detalle_Doc")

                For Each _Fila As DataRow In _TblDetalle.Rows

                    Dim _Tipr As String = _Fila.Item("Tipr")
                    Dim _Prct As Boolean = _Fila.Item("Prct")
                    Dim _Sucursal As String = _Fila.Item("Sucursal")
                    Dim _Bodega As String = _Fila.Item("Bodega")
                    Dim _ValStock = _Fila.Item("ValVtaStockInf")
                    Dim _UdTrans = _Fila.Item("UdTrans")
                    Dim _UnTrans = _Fila.Item("UnTrans")
                    Dim _Codigo = _Fila.Item("Codigo")
                    Dim _Cantidad = NuloPorNro(_Fila.Item("Cantidad"), 0)

                    If Not _Prct Then

                        If _Tipr = "FPN" Then

                            _Cantidad = 0 ' NuloPorNro(_TblDetalle.Compute("Sum(Cantidad)", "Codigo = '" & _Codigo & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'"), 0)

                            For Each _Fl As DataRow In _TblDetalle.Rows

                                If _Codigo = _Fl.Item("Codigo") And _Sucursal = _Fl.Item("Sucursal") And _Bodega = _Fl.Item("Bodega") Then
                                    _Cantidad += _Fl.Item("Cantidad")
                                End If

                            Next

                            Dim _Revisar_Stock_Disponible As Boolean = True

                            If _Tido = "NVV" Or _Tido = "RES" Or _Tido = "PRO" Or _Tido = "NVI" Then

                                Consulta_sql = "Select Top 1 * From TABTIDO Where TIDO = '" & _Tido & "'"
                                Dim _RowTido As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                                Dim _Campo_Formula_Stock = NuloPorNro(_RowTido.Item("STOCK"), "")

                                _Revisar_Stock_Disponible = Not (String.IsNullOrEmpty(_Campo_Formula_Stock))

                            End If

                            Dim _Stock_Disponible As Double '= Fx_Stock_Disponible(_Tido, ModEmpresa, _Sucursal, _Bodega, _Codigo, _UnTrans, "STFI" & _UnTrans)

                            If _Revisar_Stock_Disponible Then
                                _Stock_Disponible = Fx_Stock_Disponible(_Tido, ModEmpresa, _Sucursal, _Bodega, _Codigo, _UnTrans, "STFI" & _UnTrans)
                            Else
                                _Stock_Disponible = 1 + _Cantidad
                            End If


                            Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "STFI" & _UnTrans, "EMPRESA = '" & ModEmpresa &
                                                                     "' AND KOSU = '" & _Sucursal &
                                                                     "' AND KOBO = '" & _Bodega &
                                                                     "' AND KOPR = '" & _Codigo & "'", True)

                            If _Stock_Disponible < _Cantidad Then

                                _Revisar_Nuevamente_por_Stock = True
                                Exit For

                            End If

                        End If

                    End If

                Next

            End If

            If _Revisar_Nuevamente_por_Stock Then

                Dim _Motivo_Rechazo As String = Environment.NewLine &
                                                "Puede ser que esta validación no fue solicitada en su momento, pero al momento de reevaluar la situación" & vbCrLf &
                                                "se encontro este problema."
                '& vbCrLf & "La solicitud se devolverá al usuario de origen para que vuelva a reenviar el documento."

                Dim _Info As New TaskDialogInfo("Validación del sistema",
                              eTaskDialogIcon.ShieldStop,
                              "Existe(n) producto(s) con Stock insuficiente",
                             UCase(_Motivo_Rechazo),
                              eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red,
                              Nothing,
                              Nothing,
                              Nothing,
                              "BakApp",
                              Nothing)

                Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                Me.Close()
                Return

            End If


            For Each _Row As DataRow In _Tbl_Permisos_Doc.Rows

                Dim _Necesita_Permiso = _Row.Item("Necesita_Permiso")
                Dim _Autorizado = _Row.Item("Autorizado")
                Dim _CodPermiso = _Row.Item("CodPermiso")
                Dim _Solicitado_Por_Cadena = _Row.Item("Solicitado_Por_Cadena")

                Dim _Tbl As New DataTable

                Select Case _CodPermiso
                    Case "Bkp00015"
                        _Tbl = _Tbl_Funcionarios_X_01_Stock
                    Case "Bkp00014", "Bkp00039"
                        _Tbl = _Tbl_Funcionarios_X_02_Descuentos
                    Case "Bkp00019"
                        _Tbl = _Tbl_Funcionarios_X_03_Morosidad
                    Case "Bkp00033"
                        _Tbl = _Tbl_Funcionarios_X_04_Cupo_Excedido
                    Case "Bkp00057"
                        _Tbl = _Tbl_Funcionarios_X_05_Fecha_Despacho
                    Case "ODp00017"
                        _Tbl = _Tbl_Funcionarios_X_07_Min_Despacho
                    Case "Bkp00062"
                        _Tbl = _Tbl_Funcionarios_X_08_Min_Venta_NVV
                End Select

                If _Solicitado_Por_Cadena Then

                    _Orden += 1
                    _Cl_Permisos_Asociados.Fx_Cadena_Remotas_Generar_Detalle(_CodPermiso, _Orden, _Tbl, 0)

                End If

            Next

        ElseIf _Tido = "OCC" Then

            Dim _Row_OCC As DataRow() = _Tbl_Permisos_Doc.Select("CodPermiso = 'Comp0092'")

            If Convert.ToBoolean(_Row_OCC.Count) Then

                Dim _Necesita_Permiso = _Row_OCC(0).Item("Necesita_Permiso")
                Dim _Autorizado = _Row_OCC(0).Item("Autorizado")

                Dim _Total_Bruto As Double = _Row_Encabezado.Item("TotalBrutoDoc")
                Dim _Mi_Valor_Max_Compra As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosVsUsuarios", "Valor_Max_Compra",
                                                                       "CodPermiso = 'Comp0092' And CodUsuario = '" & FUNCIONARIO & "'")

                If _Necesita_Permiso And Not _Autorizado Then

                    Dim _Jefes As New List(Of String)

                    Fx_Insertar_Jefe(FUNCIONARIO, _Jefes)

                    If _Jefes.Count Then

                        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos Where CodPermiso = 'Comp0092'"
                        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        For Each _CodJefe As String In _Jefes

                            _Orden += 1

                            Dim _Descripcion = Trim(_RowPermiso.Item("DescripcionPermiso")) & " (NIVEL " & _Orden & ")"

                            Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios 
                                        Where CodPermiso = 'Comp0092' And CodUsuario = '" & _CodJefe & "'"
                            Dim _Row_Permiso_Jefe As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            If Not IsNothing(_Row_Permiso_Jefe) Then

                                Dim _Valor_Max_Compra As Double = _Row_Permiso_Jefe.Item("Valor_Max_Compra")
                                Dim _Monto_Aprobacion = _Valor_Max_Compra

                                If Not Convert.ToBoolean(_Monto_Aprobacion) Then
                                    _Monto_Aprobacion = _Mi_Valor_Max_Compra + 50000
                                End If

                                If _Orden = _Jefes.Count Then
                                    _Monto_Aprobacion = _Total_Bruto
                                End If

                                Dim _Row_Det As DataRow = _Cl_Permisos_Asociados.Fx_Cadena_Remota_Nueva_Linea_Det("Comp0092",
                                                                                                                  UCase(_Descripcion),
                                                                                                                  _Orden,
                                                                                                                  _Orden,
                                                                                                                  _Monto_Aprobacion)

                                If Not (_Row_Det Is Nothing) Then

                                    Dim _Id_Det = _Row_Det.Item("Id_Det")

                                    _Cl_Permisos_Asociados.Fx_Cadena_Remota_Nueva_Linea_Usu(_Id_Det, _CodJefe, "Comp0092", _Orden)

                                End If

                                If _Valor_Max_Compra >= _Total_Bruto Then
                                    Exit For
                                End If

                            End If

                        Next

                    End If

                End If

            End If

        End If

        _Enviar_Solicitudes = _Cl_Permisos_Asociados.Fx_Enviar_Cadena_Remota()

        If _Enviar_Solicitudes Then

            _Id_DocEnc = _Cl_Permisos_Asociados.Pro_Id_DocEnc
            _Id_Enc = _Cl_Permisos_Asociados.Pro_Id_Enc
            _Nro_RCadena = _Cl_Permisos_Asociados.Pro_Nro_RCadena

            Me.Close()

        End If

    End Sub

    Function Fx_Insertar_Jefe(_Hijo As String, ByRef _Jefes As List(Of String)) As Boolean

        Consulta_sql = "Select CodJefe From " & _Global_BaseBk & "Zw_Usuarios_VS_Jefes Where CodFuncionario = '" & _Hijo & "' And Empresa = '" & ModEmpresa & "'"
        Dim _Row_Jefe As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Jefe) Then

            Dim _CodJefe = Trim(_Row_Jefe.Item("CodJefe"))

            If Not String.IsNullOrEmpty(_CodJefe) Then

                _Jefes.Add(_CodJefe)
                Fx_Insertar_Jefe(_CodJefe, _Jefes)

            End If

        End If

    End Function

    Private Sub Btn_Seleccionar_Funcionarios_Click(sender As Object, e As EventArgs) Handles Btn_Seleccionar_Funcionarios.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _CodPermiso = _Fila.Cells("CodPermiso").Value

        'Bkp00015 - Stock
        'Bkp00014 - Descuentos a nivel Global
        'Bkp00019 - Morosidad Cliente
        'Bkp00033 - Cupo Exedido
        'Bkp00057 - Fecha de despacho
        'ODp00017 - Min Kilos y Ventas para despachar
        'Comp0092 -> AUTORIZAR COMPRA (SOC) -> Depende del monto asignado en Campo Valor_Max_Compra de la tabla ZW_PermisosVsUsuarios

        Dim _Tbl As DataTable

        Select Case _CodPermiso
            Case "Bkp00015"
                _Tbl = _Tbl_Funcionarios_X_01_Stock
            Case "Bkp00014", "Bkp00039"
                _Tbl = _Tbl_Funcionarios_X_02_Descuentos
            Case "Bkp00019"
                _Tbl = _Tbl_Funcionarios_X_03_Morosidad
            Case "Bkp00033"
                _Tbl = _Tbl_Funcionarios_X_04_Cupo_Excedido
            Case "Bkp00057"
                _Tbl = _Tbl_Funcionarios_X_05_Fecha_Despacho
            Case "Comp0092"
                _Tbl = _Tbl_Funcionarios_X_06_Solcitud_Compra
            Case "ODp00017"
                _Tbl = _Tbl_Funcionarios_X_07_Min_Despacho
            Case "Bkp00062"
                _Tbl = _Tbl_Funcionarios_X_08_Min_Venta_NVV
        End Select

        Sb_Llenar_Funcionarios_Destino(_CodPermiso, _Tbl)

        If Not IsNothing(_Tbl) Then

            Select Case _CodPermiso
                Case "Bkp00015"
                    _Tbl_Funcionarios_X_01_Stock = _Tbl
                Case "Bkp00014", "Bkp00039"
                    _Tbl_Funcionarios_X_02_Descuentos = _Tbl
                Case "Bkp00019"
                    _Tbl_Funcionarios_X_03_Morosidad = _Tbl
                Case "Bkp00033"
                    _Tbl_Funcionarios_X_04_Cupo_Excedido = _Tbl
                Case "Bkp00057"
                    _Tbl_Funcionarios_X_05_Fecha_Despacho = _Tbl
                Case "Comp0092"
                    _Tbl_Funcionarios_X_06_Solcitud_Compra = _Tbl
                Case "ODp00017"
                    _Tbl_Funcionarios_X_07_Min_Despacho = _Tbl
                Case "Bkp00062"
                    _Tbl_Funcionarios_X_08_Min_Venta_NVV = _Tbl
            End Select

            _Fila.Cells("Btn_Estado").Value = Imagenes_16x16.Images.Item("secure-user.png")
            _Fila.Cells("Solicitado_Por_Cadena").Value = True

        End If

    End Sub

    Private Sub Sb_Llenar_Funcionarios_Destino(ByVal _Codpermiso As String,
                                               ByRef _Tbl_Usuarios As DataTable)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Descripcion = _RowPermiso.Item("DescripcionPermiso")

        Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _Filtro_Usuarios_NOT_In As String

        If CBool(_Tbl.Rows.Count) Then
            _Filtro_Usuarios_NOT_In = "And KOFU In " & Generar_Filtro_IN(_Tbl, "", "CodUsuario", False, False, "'")
        Else
            MessageBoxEx.Show(Me, "No existen usuarios con el permiso necesario." & vbCrLf &
                              "Informe esta situación a la administración por favor.",
                              "Faltan usuarios con el permiso [" & _Codpermiso & "]",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning,
                              MessageBoxDefaultButton.Button1, Me.TopMost)
            Return
        End If

        Dim Fm_R As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
        Fm_R.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0" & vbCrLf & _Filtro_Usuarios_NOT_In
        Fm_R.Text = "SOLICITUD DE PERMISO: " & _Codpermiso & " - " & _Descripcion
        Fm_R.Pro_Tbl_Filtro = _Tbl_Usuarios
        Fm_R.ShowDialog(Me)

        If Fm_R.Pro_Filtrar Then
            _Tbl_Usuarios = Fm_R.Pro_Tbl_Filtro
        End If

        Fm_R.Dispose()

    End Sub

    Private Sub Btn_Mnu_Reenviar_Evaluacion_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Reenviar_Evaluacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _CodPermiso = _Fila.Cells("CodPermiso").Value

        Dim _Rows_Usuario_Autoriza As DataRow
        Dim _CodFunAutoriza As String = _Fila.Cells("CodFuncionario_Autoriza").Value

        Dim _Solicitar_permiso_y_esperar As Boolean = True
        Dim _Permisos_Remoto = False
        Dim _NroRemota As String

        Dim _Permiso_Presencial As Boolean

        Dim _Permiso_Otorgado = Fx_Tiene_Permiso(Me, _CodPermiso, _CodFunAutoriza, True, , , , , , False, _Rows_Usuario_Autoriza,
                                           _Solicitar_permiso_y_esperar,, _Permiso_Presencial, _Ds_Matriz_Documentos)

        If Not IsNothing(_Rows_Usuario_Autoriza) And _Permiso_Otorgado Then
            _CodFunAutoriza = _Rows_Usuario_Autoriza.Item("KOFU")
        End If

        If String.IsNullOrEmpty(_CodFunAutoriza) And _Permiso_Otorgado And Not _Permiso_Presencial Then
            _Permiso_Otorgado = False
        End If


        If _Permiso_Otorgado Then

            Beep()
            ToastNotification.Show(Me, "PERMISO OTORGADO",
                                   My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)

            _CodFunAutoriza = _Rows_Usuario_Autoriza.Item("KOFU")

        Else

            If _Solicitar_permiso_y_esperar Then

                Dim _Row_Remota As DataRow

                Sb_Solicitar_Permisos_Remoto(_CodPermiso, _Row_Remota)

                If Not _Row_Remota Is Nothing Then

                    _NroRemota = _Row_Remota.Item("NroRemota")
                    _Permiso_Otorgado = _Row_Remota.Item("Permiso_Otorgado")
                    _CodFunAutoriza = _Row_Remota.Item("CodFuncionario_Autoriza")
                    _Permisos_Remoto = _Permiso_Otorgado

                End If

            End If

        End If

        If _Permiso_Otorgado Then

            Select Case _CodPermiso
                Case "Bkp00015"
                    _Tbl_Funcionarios_X_01_Stock = Nothing
                Case "Bkp00014", "Bkp00039"
                    _Tbl_Funcionarios_X_02_Descuentos = Nothing
                Case "Bkp00019"
                    _Tbl_Funcionarios_X_03_Morosidad = Nothing
                Case "Bkp00033"
                    _Tbl_Funcionarios_X_04_Cupo_Excedido = Nothing
                Case "Bkp00057"
                    _Tbl_Funcionarios_X_05_Fecha_Despacho = Nothing
                Case "Odp00017"
                    _Tbl_Funcionarios_X_07_Min_Despacho = Nothing
                Case "Comp0092"
                    _Tbl_Funcionarios_X_06_Solcitud_Compra = Nothing
                Case "Bkp00062"
                    _Tbl_Funcionarios_X_08_Min_Venta_NVV = Nothing
            End Select


            Dim _NomFuncionario_Autoriza = Trim(_Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _CodFunAutoriza & "'"))

            _Fila.Cells("CodFuncionario_Autoriza").Value = _CodFunAutoriza
            _Fila.Cells("NomFuncionario_Autoriza").Value = _NomFuncionario_Autoriza

            _Fila.Cells("Autorizado").Value = True
            _Fila.Cells("NroRemota").Value = NuloPorNro(_NroRemota, "")
            _Fila.Cells("Permiso_Presencial").Value = _Permiso_Presencial
            _Fila.Cells("Solicitado_Por_Cadena").Value = False

            _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0).Item("Vizado") = True

            _Fila.Cells("Btn_Estado").Value = Imagenes_16x16.Images.Item("secure_ok.png")

            Sb_Revisar_Autorizado_Para_Grabar()

        End If

    End Sub

    Sub Sb_Solicitar_Permisos_Remoto(_CodPermiso As String,
                                     ByRef _Row_Remota As DataRow)

        Consulta_sql = "Select Top 1 CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso,Descuento" & vbCrLf &
                       "From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _CodPermiso & "'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _DescripcionPermiso = _RowPermiso.Item("DescripcionPermiso")

        Dim _Crear_Doc As New Clase_Crear_Documento
        Dim _Id_DocEnc As Integer = _Crear_Doc.Fx_Crear_Documento_En_BakApp_Casi(_Ds_Matriz_Documentos, False, False)

        If CBool(_Id_DocEnc) Then

            Dim _NroRemota As String

            Dim _Solicita_Remota As Boolean
            _Solicita_Remota = Fx_Solicitar_Permisos_Remotos(_Id_DocEnc, _CodPermiso, _DescripcionPermiso, _NroRemota, True)

            If _Solicita_Remota Then

                If True Then

                    Dim Fm As New Frm_Remotas_Espera_Permiso_Solicitado(_CodPermiso, _NroRemota)
                    Fm.ShowDialog(Me)

                    Dim _Sql_Elimina_Remota = String.Empty

                    If Fm.Pro_Permiso Then

                        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                                       "Where NroRemota = '" & _NroRemota & "'"
                        _Row_Remota = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocDet Where Id_DocEnc = " & _Id_DocEnc & " Order By NroLinea"
                        Dim _Tbl_Zw_Casi_DocDet As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        For Each _FilaR As DataRow In _Tbl_Zw_Casi_DocDet.Rows

                            Dim _IdR As Integer = _FilaR.Item("IdDet_Ori")

                            For Each _FilaL As DataRow In _Ds_Matriz_Documentos.Tables("Detalle_Doc").Rows

                                Dim _IdL As Integer = _FilaL.Item("Id")

                                If _IdL = _IdR Then
                                    _FilaL.Item("Observa") = _FilaR.Item("Observa")
                                    Exit For
                                End If

                            Next

                        Next

                        'Dim _Permiso_Otorgado As Boolean = _Row_Remota.Item("Permiso_Otorgado")
                        'Dim _CodFunAutoriza As String = _Row_Remota.Item("CodFuncionario_Autoriza")

                        ' Grilla_Encabezado.Rows(0).Cells("Fun_Auto_Deuda_Ven").Value = _CodFunAutoriza
                        ' HACER UN PROCEDIMIENTO PARA ACTUALIZAR LOS DESCUENTOS OTORGADOS REMOTAMENTE

                    Else

                        If Fm.Pro_Cancelar Then
                            _Sql_Elimina_Remota = "Update " & _Global_BaseBk & "Zw_Remotas Set " &
                                                  "Eliminada = 1,Observaciones = 'Acción cancelada por el usuario solicitante',Otorga = 'Cancelada'" & Space(1) &
                                                  "Where NroRemota = '" & _NroRemota & "'" & vbCrLf &
                                                  "Update " & _Global_BaseBk & "Zw_Notificaciones Set Rechazado = 1," &
                                                  "Log_Notificacion = 'Acción cancelada por el usuario solicitante'" & vbCrLf &
                                                  "Where NroRemota = '" & _NroRemota & "'"
                        End If

                    End If

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocDet Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocDsc Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocImp Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocObs Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocPer Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Referencias_Dte Where Id_Doc = " & _Id_DocEnc & " And Kasi = 1" & vbCrLf &
                    _Sql_Elimina_Remota

                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                End If

            End If

        End If

    End Sub

    Function Fx_Solicitar_Permisos_Remotos(ByVal _Id_DocEnc As Integer,
                                           ByVal _Codpermiso As String,
                                           ByVal _Descripcion_Adicional As String,
                                           ByRef _NroRemota As String,
                                           ByVal _Esperar_En_Linea As Boolean) As Boolean
        Dim _Row_Permiso As DataRow
        Dim _Tbl_Usuarios As DataTable

        _NroRemota = String.Empty

        Consulta_sql = "SELECT CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso,Descuento" & vbCrLf &
                       "From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        _Row_Permiso = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _DescripcionPermiso = _Row_Permiso.Item("DescripcionPermiso")

        Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "' And CodUsuario <> '" & FUNCIONARIO & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _Filtro_Usuarios_NOT_In As String

        If CBool(_Tbl.Rows.Count) Then
            _Filtro_Usuarios_NOT_In = "And KOFU In " & Generar_Filtro_IN(_Tbl, "", "CodUsuario", False, False, "'")
        Else
            MessageBoxEx.Show(Me, "No existen usuarios con el permiso necesario en el sistema" & vbCrLf & vbCrLf &
                              "Permiso: " & _Codpermiso & " - " & _DescripcionPermiso, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim Fm_R As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
        Fm_R.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0" & vbCrLf & _Filtro_Usuarios_NOT_In
        Fm_R.Text = "USUARIOS AUTORIZADOS A DAR ESTE PERMISO: " & _Codpermiso
        Fm_R.ShowDialog(Me)

        Dim _Titulo = "PERMISO REMOTO"

        If _Esperar_En_Linea Then
            _Titulo = "PERM. REMOTO ESPERA EN LINEA!"
        End If

        If Fm_R.Pro_Filtrar Then

            _Tbl_Usuarios = Fm_R.Pro_Tbl_Filtro

            'ENVIO DE NOTIFICACIONES A LOS USUARIOS CON PERMISO
            If Not (_Tbl_Usuarios Is Nothing) Then

                _NroRemota = Fx_Solicitar_Remota(FUNCIONARIO, _Codpermiso, _Descripcion_Adicional,
                                                 _Id_DocEnc, _Row_Entidad.Item("KOEN"),
                                                 _Row_Entidad.Item("NOKOEN"), _Esperar_En_Linea)


                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set" & Space(1) &
                               "Crear_Doc_Def_Al_Grabar = 0" & vbCrLf &
                               "Where NroRemota = '" & _NroRemota & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)


                For Each _Fila As DataRow In _Tbl_Usuarios.Rows

                    Dim _CodUsuario = _Fila.Item("Codigo")
                    Dim _Usuario = Trim(_Fila.Item("Descripcion"))
                    Dim _Texto = "Solicitado por: " & FUNCIONARIO & " - " & Mid(Trim(Nombre_funcionario_activo), 1, 13) & vbCrLf &
                                 "Nro Remota:" & _NroRemota & vbCrLf &
                                 _DescripcionPermiso & vbCrLf &
                                 "Cliente: " & Trim(_Row_Entidad.Item("NOKOEN"))

                    csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO,
                                                                           _CodUsuario,
                                                                           _Titulo,
                                                                           _Texto,
                                                                           csNotificaciones.Notificacion.Imagen.Remota,
                                                                           _NroRemota, False, 0, True, _Id_DocEnc, False, "", "", "")
                Next

            End If

        End If

        Fm_R.Dispose()

        If Not String.IsNullOrEmpty(_NroRemota) Then
            Return True
        End If

    End Function

    Sub Sb_Revisar_Autorizado_Para_Grabar()

        _Autorizado_Para_Grabar = True

        For Each _Row As DataRow In _Tbl_Permisos_Doc.Rows

            Dim _Necesita_Permiso = _Row.Item("Necesita_Permiso")
            Dim _Autorizado = _Row.Item("Autorizado")
            Dim _CodPermiso = _Row.Item("CodPermiso")

            If _Necesita_Permiso Then

                If Not _Autorizado Then

                    _Autorizado_Para_Grabar = False
                    Exit For

                End If

            End If

        Next

        If _Autorizado_Para_Grabar Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Ver_Infor_Morosidad_Cupo_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Infor_Morosidad_Cupo.Click

        Dim _Row_Encabezado As DataRow = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)

        With _Row_Encabezado

            Dim _TotalBruto = .Item("TotalBrutoDoc")

            Dim Fm_D As New Frm_InfoEnt_Deudas_Doc_Comerciales(_Row_Entidad, _TotalBruto, 0, 0, 0, True)

            Dim _Fun_Auto_Deuda_Ven = NuloPorNro(.Item("Fun_Auto_Deuda_Ven"), "")
            Dim _Fun_Auto_Cupo_Exe = NuloPorNro(.Item("Fun_Auto_Cupo_Exe"), "")

            Fm_D.Pro_Fun_Auto_Deuda_Ven = _Fun_Auto_Deuda_Ven
            Fm_D.Pro_Fun_Auto_Cupo_Exe = _Fun_Auto_Cupo_Exe

            Fm_D.Pro_FechaEmision = .Item("FechaEmision")
            Fm_D.Pro_Fecha_1er_Vencimiento = .Item("Fecha_1er_Vencimiento")
            Fm_D.Pro_FechaUltVencimiento = .Item("FechaUltVencimiento")
            Fm_D.Pro_Cuotas = .Item("Cuotas")
            Fm_D.Pro_Dias_1er_Vencimiento = .Item("Dias_1er_Vencimiento")
            Fm_D.Pro_Dias_Vencimiento = .Item("Dias_Vencimiento")

            Fm_D.Btn_CambCodPago.Enabled = False

            Fm_D.ShowDialog(Me)
            Fm_D.Dispose()

        End With

    End Sub

End Class
