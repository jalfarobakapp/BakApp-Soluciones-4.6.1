Imports DevComponents.DotNetBar
Imports Hefesto.Acuse.Recibo
Imports MySql.Data.Authentication
Imports Org.BouncyCastle.Math.EC

Public Class Frm_Stmp_Listado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Tickets_Stem As DataTable
    Dim _FechaServidor As DateTime

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Stem_Listado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _FechaServidor = FechaDelServidor()

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Tab_Preparacion.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Completadas.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Facturadas.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Cerradas.Click, AddressOf Sb_Actualizar_Grilla

        Super_TabS.SelectedTabIndex = 0

        Sb_Actualizar_Grilla()

    End Sub


    Sub Sb_Actualizar_Grilla()

        'Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty
        Dim _Condicion2 As String = String.Empty

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        'If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
        '_Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        'End If

        Dim _Tbas = Super_TabS.SelectedTab

        Select Case _Tbas.Name
            Case "Tab_Preparacion"
                _Condicion += vbCrLf & "And Estado = 'PREPA'"
            Case "Tab_Completadas"
                _Condicion += vbCrLf & "And Estado = 'COMPL'"
            Case "Tab_Facturadas"
                _Condicion += vbCrLf & "And Estado = 'FACTU'"
            Case "Tab_Cerradas"
                _Condicion += vbCrLf & "And Estado = 'CERRA'"
            Case "Tab_Nulas"
                _Condicion += vbCrLf & "And Estado = 'NULO'"
        End Select

        Btn_FacturarMasivamente.Enabled = (_Tbas.Name = "Tab_Completadas")

        Consulta_sql = "Select Enc.*,Edo.FEEMDO,Edo.SUDO,En.NOKOEN," & vbCrLf &
                       "Case Estado " & vbCrLf &
                       "When 'PREPA' Then 'Preparación...'" & vbCrLf &
                       "When 'COMPL' Then 'Completada.'" & vbCrLf &
                       "When 'HABIL' Then 'Habilitada para ser facturada.'" & vbCrLf &
                       "When 'FACTU' Then Case TipoPago When 'Contado' Then 'Facturada, pase por CAJA...' When 'Credito' Then 'Facturada, pase a DESPACHO EN BODEGA...' End" & vbCrLf &
                       "When 'CERRA' Then 'Cerrada'" & vbCrLf &
                       "When 'NULO' Then 'Nula'" & vbCrLf &
                       "End As 'Estado_Str'," & vbCrLf &
                       "FechaCreacion As 'HoraCreacion'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stmp_Enc Enc" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Enc.Idmaeedo" & vbCrLf &
                       "Left Join MAEEN En On En.KOEN = Enc.Endo And En.SUEN = Enc.Suendo" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Condicion & vbCrLf &
                       "And Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "'"

        If _Tbas.Name = "Tab_Espera" Then

            Consulta_sql = ""

        End If

        _Tbl_Tickets_Stem = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Tickets_Stem

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen_Estado").Width = 50
            .Columns("BtnImagen_Estado").HeaderText = "Est."
            .Columns("BtnImagen_Estado").Visible = True
            .Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Facturar").Visible = (_Tbas.Name = "Tab_Completadas")
            .Columns("Facturar").HeaderText = "Facturar"
            .Columns("Facturar").Width = 60
            .Columns("Facturar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "#Ticket"
            .Columns("Numero").Width = 80
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tido").Visible = True
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Width = 30
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nudo").Visible = True
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Width = 80
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").Visible = True
            .Columns("SUDO").HeaderText = "Suc."
            .Columns("SUDO").ToolTipText = "Sucursal del documento"
            .Columns("SUDO").Width = 60
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Endo").Visible = True
            .Columns("Endo").HeaderText = "Entidad"
            '.Columns("Endo").ToolTipText = "Estado del Ticket"
            .Columns("Endo").Width = 70
            .Columns("Endo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Suendo").Visible = True
            '.Columns("Suendo").HeaderText = "Entidad"
            ''.Columns("Endo").ToolTipText = "Estado del Ticket"
            '.Columns("Suendo").Width = 120
            '.Columns("Suendo").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón Social"
            '.Columns("NOKOEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NOKOEN").Width = 200
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaCreacion").Visible = (_Tbas.Name = "Tab_Completadas")
            .Columns("FechaCreacion").HeaderText = "F.Creación"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaCreacion").Width = 70
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HoraCreacion").Visible = (_Tbas.Name = "Tab_Completadas")
            .Columns("HoraCreacion").HeaderText = "H.Crea"
            .Columns("HoraCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("HoraCreacion").DefaultCellStyle.Format = "HH:mm"
            .Columns("HoraCreacion").Width = 50
            .Columns("HoraCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DocEmitir").Visible = True
            .Columns("DocEmitir").HeaderText = "Doc.Emitir"
            '.Columns("NOKOEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("DocEmitir").Width = 70
            .Columns("DocEmitir").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado_Str").Visible = True
            .Columns("Estado_Str").HeaderText = "Estado"
            '.Columns("NOKOEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado_Str").Width = 300
            .Columns("Estado_Str").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If _Tbas.Name.Contains("Cerradas") Then

                .Columns("FechaCierre").Visible = True
                .Columns("FechaCierre").HeaderText = "Fecha cierre"
                '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
                .Columns("FechaCierre").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FechaCierre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("FechaCierre").Width = 70
                .Columns("FechaCierre").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If


        End With

        Return

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Mesn_Pdte_Ver = _Fila.Cells("Mesn_Pdte_Ver").Value
            Dim _Resp_Pdte_Ver = _Fila.Cells("Resp_Pdte_Ver").Value
            Dim _Estado As String = _Fila.Cells("Estado").Value
            Dim _Aceptado As Boolean = _Fila.Cells("Aceptado").Value
            Dim _Rechazado As Boolean = _Fila.Cells("Rechazado").Value
            Dim _Prioridad As String = _Fila.Cells("Prioridad").Value

            Dim _Icono As Image
            Dim _Nombre_Image As String
            Dim _Num

            'If _Tipo_Tickets = Enum_Tickets.MisTicket Then
            '    _Num = _Resp_Pdte_Ver
            'Else
            '    _Num = _Mesn_Pdte_Ver
            'End If

            Dim _Imagenes_List As ImageList

            If Global_Thema = Enum_Themas.Oscuro Then
                _Imagenes_List = Imagenes_16x16_Dark
            Else
                _Imagenes_List = Imagenes_16x16
            End If

            If _Estado = "NULO" Then
                _Icono = _Imagenes_List.Images.Item("cancel.png")
            Else

                If CBool(_Num) Then
                    _Nombre_Image = "comment-number-" & _Num & ".png"
                    If _Mesn_Pdte_Ver > 9 Then
                        _Nombre_Image = "comment-number-9-plus.png"
                    End If
                    _Icono = _Imagenes_List.Images.Item(_Nombre_Image)

                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Amarillo
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                    End If

                Else
                    _Icono = _Imagenes_List.Images.Item("menu-more.png")
                End If

            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Icono

            If _Aceptado Then _Fila.Cells("NomEstado").Style.ForeColor = Verde
            If _Rechazado Then _Fila.Cells("NomEstado").Style.ForeColor = Rojo

            _Fila.Cells("NomPrioridad").Style.ForeColor = Color.White

            If _Prioridad = "AL" Then
                _Fila.Cells("NomPrioridad").Style.BackColor = Color.Orange
            End If

            If _Prioridad = "BJ" Then
                _Fila.Cells("NomPrioridad").Style.ForeColor = Color.Black
                _Fila.Cells("NomPrioridad").Style.BackColor = Amarillo
            End If

            If _Prioridad = "NR" Then
                _Fila.Cells("NomPrioridad").Style.BackColor = Verde
            End If

            If _Prioridad = "UR" Then
                _Fila.Cells("NomPrioridad").Style.BackColor = Rojo
            End If

        Next

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                       "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Btn_Crear_Ticket_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ticket.Click

        Dim _Row_Documento As DataRow

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado,
                                 "NVV",
                                 "Where TIDO = 'NVV'")
        _Fm.Rdb_Estado_Todos.Enabled = False
        _Fm.Rdb_Estado_Vigente.Checked = True
        _Fm.Rdb_Estado_Cerradas.Enabled = False
        '_Fm.HabilitarNVVParaFacturar = True
        '_Fm.Rdb_Funcionarios_Uno.Checked = True
        _Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True
        _Fm.Chk_Mostrar_Vales_Transitorios.Checked = False
        _Fm.Chk_Mostrar_Vales_Transitorios.Enabled = False
        _Fm.Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc)"
        _Fm.ShowDialog(Me)
        _Row_Documento = _Fm.Pro_Row_Documento_Seleccionado
        _Fm.Dispose()

        If IsNothing(_Row_Documento) Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma el documento " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO") & "?",
                             "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If


        Dim _Facturar As Boolean = _Global_Row_Configuracion_General.Item("Pickear_FacturarAutoCompletas")
        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Dim _Cl_Stmp As New Cl_Stmp
        _Mensaje_Stem = _Cl_Stmp.Fx_Crear_Ticket(_Row_Documento.Item("IDMAEEDO"),
                                 _Row_Documento.Item("TIDO"),
                                 _Row_Documento.Item("NUDO"),
                                 _Facturar,
                                 FechaDelServidor,
                                 "R",
                                 True)

        Dim _Icon As MessageBoxIcon

        If _Mensaje_Stem.EsCorrecto Then
            _Icon = MessageBoxIcon.Information
        Else
            _Icon = MessageBoxIcon.Stop
        End If

        MessageBoxEx.Show(Me, _Mensaje_Stem.Mensaje, _Mensaje_Stem.Detalle, MessageBoxButtons.OK, _Icon)

        Return





        'Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_Ent",
        '                                               "Empresa = '" & _Row_Documento.Item("EMPRESA") & "'" &
        '                                               " And Idmaeedo = " & _Row_Documento.Item("IDMAEEDO") &
        '                                               " And Tido = '" & _Row_Documento.Item("TIDO") & "'" &
        '                                               " And Nudo = '" & _Row_Documento.Item("NUDO") & "'")

        'If _Reg = 0 Then

        '    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        '    Dim _TipoEstacion As String = _Global_Row_EstacionBk.Item("TipoEstacion")

        '    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Ent (Idmaeedo,NombreEquipo,TipoEstacion,Empresa,Modalidad,Tido,Nudo," &
        '                   "FechaHoraGrab,HabilitadaFac,FunAutorizaFac,Pickear)" & vbCrLf &
        '                   "Select IDMAEEDO,'" & _NombreEquipo & "','" & _TipoEstacion & "',EMPRESA,'?',TIDO,NUDO,LAHORA,0,'',1" & vbCrLf &
        '                   "From MAEEDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO") & vbCrLf &
        '                   "Insert Into " & _Global_BaseBk & "Zw_Docu_Det (Idmaeddo,Idmaeedo,Tido,Nudo,Codigo,Descripcion,RtuVariable)" & vbCrLf &
        '                   "Select IDMAEDDO,IDMAEEDO,TIDO,NUDO,KOPRCT,NOKOPR,0" & vbCrLf &
        '                   "From MAEDDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO")
        '    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        'End If

        'Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Row_Documento.Item("ENDO"), _Row_Documento.Item("SUENDO"))
        'Dim _Cl_Stem As New Cl_Stmp

        'Dim _Secueven As String

        'Try
        '    _Secueven = _Row_Entidad.Item("SECUEVEN")
        'Catch ex As Exception
        '    _Secueven = "NFG"
        'End Try

        'With _Cl_Stem.Zw_Stmp_Enc

        '    .Empresa = ModEmpresa
        '    .Sucursal = ModSucursal
        '    .Idmaeedo = _Row_Documento.Item("IDMAEEDO")
        '    .Tido = _Row_Documento.Item("TIDO")
        '    .Nudo = _Row_Documento.Item("NUDO")
        '    .Endo = _Row_Documento.Item("ENDO")
        '    .Suendo = _Row_Documento.Item("SUENDO")
        '    .CodFuncionario_Crea = FUNCIONARIO
        '    .FechaCreacion = _FechaServidor
        '    .Estado = "PREPA"
        '    .Secueven =
        '    .Facturar = _Global_Row_Configuracion_General.Item("Pickear_FacturarAutoCompletas")

        '    Try
        '        .Secueven = _Row_Entidad.Item("SECUEVEN")
        '    Catch ex As Exception
        '        .Secueven = String.Empty
        '    End Try

        'End With

        'Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO") & " And PRCT = 0"
        'Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        'If Not CBool(_Tbl_Detalle.Rows.Count) Then
        '    MessageBoxEx.Show(Me, "No se encontro detalle en el documento, asegurece que tenga productos asociados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'For Each _Fila As DataRow In _Tbl_Detalle.Rows

        '    Dim _Zw_Stmp_Det As New Zw_Stmp_Det

        '    With _Zw_Stmp_Det

        '        .Idmaeedo = _Fila.Item("IDMAEEDO")
        '        .Idmaeddo = _Fila.Item("IDMAEDDO")
        '        .Codigo = _Fila.Item("KOPRCT")
        '        .Descripcion = _Fila.Item("NOKOPR")
        '        .Nulido = _Fila.Item("NULIDO")
        '        .Udtrpr = _Fila.Item("UDTRPR")
        '        .Rludpr = _Fila.Item("RLUDPR")
        '        .Caprco1_Ori = _Fila.Item("CAPRCO1")
        '        .Caprco1_Real = 0
        '        .Udpr = _Fila.Item("UD0" & .Udtrpr & "PR")
        '        .Ud01pr = _Fila.Item("UD01PR")
        '        .Caprco2_Ori = _Fila.Item("CAPRCO2")
        '        .Caprco2_Real = 0
        '        .Ud02pr = _Fila.Item("UD02PR")
        '        .Pickeado = False
        '        .EnProceso = True

        '    End With

        '    _Cl_Stem.Zw_Stmp_Det.Add(_Zw_Stmp_Det)

        'Next

        '_Mensaje_Stem = _Cl_Stem.Fx_Grabar_Nuevo_Tickets

        'If Not _Mensaje_Stem.EsCorrecto Then
        '    MessageBoxEx.Show(Me, _Mensaje_Stem.Mensaje, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'MessageBoxEx.Show(Me, "Ticket Nro. " & _Cl_Stem.Zw_Stmp_Enc.Numero & " creado correctamente." & vbCrLf &
        '                  "El documento ya esta en proceso", "Crear Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_RevisarTicket_Click(sender As Object, e As EventArgs) Handles Btn_RevisarTicket.Click

        Dim _Nudo As String
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el numero de nota de venta a revisar",
                                              "Revisar detalle NVV", _Nudo, False, _Tipo_Mayus_Minus.Normal, 10, True)

        If Not _Aceptar Then
            Return
        End If

        _Nudo = Fx_Rellena_ceros(_Nudo, 10)

        Dim _Cl_Stem As New Cl_Stmp
        Dim _Mensaje_Stem As New LsValiciones.Mensajes
        _Mensaje_Stem = _Cl_Stem.Fx_Revisar_NVV("NVV", _Nudo)

        If _Mensaje_Stem.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje_Stem.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, _Mensaje_Stem.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Idmaeedo As Integer = _Fila.Cells("Idmaeedo").Value

        Dim _Tbas = Super_TabS.SelectedTab

        If _Tbas.Name = "Tab_Preparacion" Then

            Dim _Id_Enc As Integer = _Fila.Cells("Id").Value
            Dim _ConfirmaDespacho As Boolean

            Dim Fm As New Frm_Stmp_IngPickeo(_Id_Enc, FUNCIONARIO)
            Fm.ShowDialog(Me)
            _ConfirmaDespacho = Fm.ConfirmaDespacho
            Fm.Dispose()

            If _ConfirmaDespacho Then
                Sb_Actualizar_Grilla()
            End If

        End If

        If _Tbas.Name = "Tab_Completadas" Then

            _Fila.Cells("Facturar").Value = Not _Fila.Cells("Facturar").Value

        End If

    End Sub

    Private Sub Btn_CargarNVVFechaDespHoy_Click(sender As Object, e As EventArgs) Handles Btn_CargarNVVFechaDespHoy.Click

        Dim Fm As New Frm_Stmp_IncNVVPicking
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Function Fx_Cargar_NVV_FechaDespachoHoy() As List(Of LsValiciones.Mensajes)

        Dim _Lista As New List(Of LsValiciones.Mensajes)
        Dim _FechaHoy As DateTime = FechaDelServidor()

        Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,FEER,Doc.*" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Docu_Ent Doc On Edo.IDMAEEDO = Doc.Idmaeedo" & vbCrLf &
                       "Where TIDO = 'NVV' And FEER = '" & Format(_FechaHoy, "yyyyMMdd") & "' " &
                       "--And Doc.Pickear = 1 --And Edo.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc)"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Mensaje_Stem As New LsValiciones.Mensajes

            _Mensaje_Stem = Fx_Crear_Ticket(_Fila.Item("IDMAEEDO"), False, "R")

            _Lista.Add(_Mensaje_Stem)

        Next

        Return _Lista

    End Function

    Function Fx_Crear_Ticket(_Idmaeedo As Integer,
                             _Facturar As Boolean,
                             _TipoPago As String) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Idmaeedo = " & _Idmaeedo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "El documento ya esta ingresado en el sistema de Ticket Picking (Ticket Nro: " & _Row.Item("Numero") & ")"
            _Mensaje_Stem.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
            Return _Mensaje_Stem
        End If

        Consulta_sql = "Select Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,Edo.SUDO,Doc.Pickear,HabilitadaFac,FunAutorizaFac" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Docu_Ent Doc On Edo.IDMAEEDO = Doc.Idmaeedo" & vbCrLf &
                       "Where IDMAEEDO = " & _Idmaeedo
        Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Documento) Then
            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla MAEEDO, Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
            _Mensaje_Stem.Detalle = "IDMAEEDO " & _Idmaeedo
            Return _Mensaje_Stem
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_Ent",
                                                       "Empresa = '" & _Row_Documento.Item("EMPRESA") & "'" &
                                                       " And Idmaeedo = " & _Row_Documento.Item("IDMAEEDO") &
                                                       " And Tido = '" & _Row_Documento.Item("TIDO") & "'" &
                                                       " And Nudo = '" & _Row_Documento.Item("NUDO") & "'")

        If _Reg = 0 Then

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
            Dim _TipoEstacion As String = _Global_Row_EstacionBk.Item("TipoEstacion")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Ent (Idmaeedo,NombreEquipo,TipoEstacion,Empresa,Modalidad,Tido,Nudo," &
                           "FechaHoraGrab,HabilitadaFac,FunAutorizaFac,Pickear)" & vbCrLf &
                           "Select IDMAEEDO,'" & _NombreEquipo & "','" & _TipoEstacion & "',EMPRESA,'?',TIDO,NUDO,LAHORA,0,'',1" & vbCrLf &
                           "From MAEEDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO") & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Docu_Det (Idmaeddo,Idmaeedo,Tido,Nudo,Codigo,Descripcion,RtuVariable)" & vbCrLf &
                           "Select IDMAEDDO,IDMAEEDO,TIDO,NUDO,KOPRCT,NOKOPR,0" & vbCrLf &
                           "From MAEDDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO")
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

        If Not _Row_Documento.Item("Pickear") Then
            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "Este documento no esta marcado para ser Pickeado en la tabla Zw_Docu_Ent"
            _Mensaje_Stem.Detalle = "Documento: " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
            Return _Mensaje_Stem
        End If


        Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Row_Documento.Item("ENDO"), _Row_Documento.Item("SUENDO"))
        Dim _Cl_Stem As New Cl_Stmp

        With _Cl_Stem.Zw_Stmp_Enc

            .Empresa = ModEmpresa
            .Sucursal = ModSucursal
            .Idmaeedo = _Row_Documento.Item("IDMAEEDO")
            .Tido = _Row_Documento.Item("TIDO")
            .Nudo = _Row_Documento.Item("NUDO")
            .Endo = _Row_Documento.Item("ENDO")
            .Suendo = _Row_Documento.Item("SUENDO")
            .CodFuncionario_Crea = FUNCIONARIO
            .FechaCreacion = _FechaServidor
            .Estado = "PREPA"
            .Facturar = _Facturar
            .TipoPago = _TipoPago

            Try
                .Secueven = _Row_Entidad.Item("SECUEVEN")
            Catch ex As Exception
                .Secueven = String.Empty
            End Try

        End With

        Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO")
        Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Detalle.Rows

            Dim _Stem_Det As New Zw_Stmp_Det

            With _Stem_Det

                .Idmaeedo = _Fila.Item("IDMAEEDO")
                .Idmaeddo = _Fila.Item("IDMAEDDO")
                .Codigo = _Fila.Item("KOPRCT")
                .Descripcion = _Fila.Item("NOKOPR")
                .Nulido = _Fila.Item("NULIDO")
                .Udtrpr = _Fila.Item("UDTRPR")
                .Rludpr = _Fila.Item("RLUDPR")
                .Caprco1_Ori = _Fila.Item("CAPRCO1")
                .Caprco1_Real = 0
                .Udpr = _Fila.Item("UD0" & .Udtrpr & "PR")
                .Ud01pr = _Fila.Item("UD01PR")
                .Caprco2_Ori = _Fila.Item("CAPRCO2")
                .Caprco2_Real = 0
                .Ud02pr = _Fila.Item("UD02PR")
                .Pickeado = False
                .EnProceso = True

            End With

            _Cl_Stem.Zw_Stmp_Det.Add(_Stem_Det)

        Next

        _Mensaje_Stem = _Cl_Stem.Fx_Grabar_Nuevo_Tickets

        Return _Mensaje_Stem

        'If Not _Mensaje_Stem.EsCorrecto Then
        '    MessageBoxEx.Show(Me, _Mensaje_Stem.Mensaje, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'MessageBoxEx.Show(Me, "Ticket Nro. " & _Cl_Stem.Stem_Enc.Numero & " creado correctamente." & vbCrLf &
        '                  "El documento ya esta en proceso", "Crear Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Function

    Private Sub Btn_FacturarMasivamente_Click(sender As Object, e As EventArgs) Handles Btn_FacturarMasivamente.Click

        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Tickets_Stem.Rows

            Dim _Estado = _Fila.RowState

            If _Estado <> DataRowState.Deleted Then

                If _Fila.Item("Facturar") Then
                    _Contador += 1
                End If

            End If

        Next

        If _Contador = 0 Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Lista As New List(Of LsValiciones.Mensajes)

        For Each _Fila As DataRow In _Tbl_Tickets_Stem.Rows

            If _Fila.Item("Facturar") Then

                Dim _Id As Integer = _Fila.Item("Id")
                Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
                Dim _TidoDocEmitir As String = _Fila.Item("DocEmitir")

                Dim _FechaServidor As DateTime = FechaDelServidor()

                Dim _Mensaje As LsValiciones.Mensajes = Fx_Crear_Documento_Desde_Otro_Automaticamente(Me, _TidoDocEmitir, _Idmaeedo, _FechaServidor, "FACEL")

                If _Mensaje.EsCorrecto Then

                    Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Mensaje.Id
                    Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " &
                                   "Estado = 'FACTU',TidoGen = '" & _Row_Maeedo.Item("TIDO") &
                                   "',NudoGen = '" & _Row_Maeedo.Item("NUDO") &
                                   "',IdmaeedoGen = " & _Row_Maeedo.Item("IDMAEEDO") & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                _Lista.Add(_Mensaje)

            End If

        Next

        Dim ListaQr As LsValiciones.Mensajes = _Lista.FirstOrDefault(Function(p) p.EsCorrecto = False)

        If Not IsNothing(ListaQr) Then

            MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Dim Fmv As New Frm_Validaciones
        Fmv.ListaMensajes = _Lista
        Fmv.ShowDialog(Me)
        Fmv.Dispose()

        Sb_Actualizar_Grilla()

    End Sub


    Function Fx_Crear_Documento_Desde_Otro_Automaticamente(_Formulario As Form,
                                                           _TidoDocEmitir As String,
                                                           _Idmaeedo_Origen As Integer,
                                                           _Fecha_Emision As DateTime,
                                                           _Modalidad As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _New_Idmaeedo As Integer

        Try

            If _TidoDocEmitir <> "GDV" And _TidoDocEmitir <> "FCV" Then
                _Mensaje.Mensaje = "Error"
                Throw New System.Exception("El Tido Destino esta vacío o no corresponde: (" & _TidoDocEmitir & "), solo puede ser: FCV y GDV")
            End If

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Modalidad, _TidoDocEmitir, True)

            If Not IsNothing(_RowFormato) Then

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
                Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Documento) Then

                    Dim _Meardo = _Row_Documento.Item("MEARDO")
                    Dim _Tido = _Row_Documento.Item("TIDO")
                    Dim _Nudo = _Row_Documento.Item("NUDO")

                    If Fx_Revisar_Taza_Cambio(_Formulario) Then

                        If Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo_Origen) Then

                            Dim _Empresa As String = ModEmpresa
                            Dim _Sucursal As String = ModSucursal
                            Dim _Bodega As String = ModBodega

                            Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega

                            If Not Fx_Tiene_Permiso(_Formulario, _Permiso, , True) Then

                                Dim _Bod = _Global_Row_Configuracion_Estacion.Item("NOKOBO")
                                'MessageBoxEx.Show(_Formulario, "NO ESTA AUTORIZADO PARA EFECTUAR DOCUMENTOS DESDE LA BODEGA DE ESTA MODALIDAD" & vbCrLf & vbCrLf &
                                '                  "BODEGA: " & _Bodega & " - " & _Bod,
                                '                  "VALIDACION",
                                '                  MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)

                                _Mensaje.Mensaje = "VALIDACION"
                                Throw New System.Exception("NO ESTA AUTORIZADO PARA EFECTUAR DOCUMENTOS DESDE LA BODEGA DE ESTA MODALIDAD" & vbCrLf & vbCrLf &
                                                  "BODEGA: " & _Bodega & " - " & _Bod)

                            End If

                            If Fx_Tiene_Permiso(_Formulario, _Permiso) Then

                                Dim _CampoPrecio As String

                                If _Meardo = "N" Then ' Neto
                                    _CampoPrecio = "PPPRNE"
                                Else ' Bruto
                                    _CampoPrecio = "PPPRBR"
                                End If

                                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                               vbCrLf &
                                               "Select Ddo.*,Det.Cantidad As 'Cantidad'," & vbCrLf &
                                               "Det.Caprco1_Real As 'CantUd1_Pickea',Det.Caprco2_Real As 'CantUd2_Pickea'," & vbCrLf &
                                               "Cast(1 As Bit) As DesdePickeo," & vbCrLf &
                                               "CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori'," & vbCrLf &
                                               "Case WHEN UDTRPR = 1 Then PPPRNE Else PPPRNE*RLUDPR End AS 'Precio'," & vbCrLf &
                                               "0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta," & vbCrLf &
                                               "Det.RtuVariable" & vbCrLf &
                                               "From MAEDDO Ddo With ( NOLOCK )" & vbCrLf &
                                               "Inner Join " & _Global_BaseBk & "Zw_Stmp_Det Det On Ddo.IDMAEDDO = Det.Idmaeddo" & vbCrLf &
                                               "Where IDMAEEDO = " & _Idmaeedo_Origen & " AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''" & vbCrLf &
                                               "Order by IDMAEEDO,IDMAEDDO " & vbCrLf &
                                               vbCrLf &
                                               "Select * From MAEIMLI Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                               vbCrLf &
                                               "Select * From MAEDTLI Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                               vbCrLf &
                                               "Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Origen

                                'Falta revisar el campo SUBTIDO, ya que al parecer se guardan datos dependiendo del tipo de FCC por ejemplo si tiene derecho a credito fiscal
                                'Falta campo FECHATRIB = Fecha de ingreso

                                ' SUBTIDO
                                '-- 001 Sin derecho a credito fiscal y Sin documento contiene activo fijo
                                '-- 000 Documento contiene activo fijo y Sin derecho a credito fiscal
                                '-- 101 Conderecho a credito fiscal y documento contiene activo fijo
                                '-- 100 Con derecho a credito fiscal y sin documento contiene activo fijo
                                '-- '' -- No incluye este documento en el libro de compras 

                                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                                Dim Fm_Post As New Frm_Formulario_Documento(_TidoDocEmitir, csGlobales.Enum_Tipo_Documento.Venta, False)
                                Fm_Post.Sb_Limpiar(_Modalidad)
                                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)
                                Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False)
                                _New_Idmaeedo = Fm_Post.Pro_Idmaeedo

                                If CBool(_New_Idmaeedo) Then
                                    Fm_Post.Sb_Activar_Orden_De_Despacho(_New_Idmaeedo)
                                End If

                                Fm_Post.Dispose()

                                If Not CBool(_New_Idmaeedo) Then
                                    _Mensaje.Detalle = "Error al grabar documento"
                                    Throw New System.Exception("No fue posible realizar la grabación de la Factura.")
                                End If

                                Dim Cerrar_Doc As New Clas_Cerrar_Documento

                                Consulta_sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo_Origen)

                                Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                                Dim _Tbl_Maeddo = _Ds.Tables(1)

                                If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo_Origen, _Tbl_Maeddo) Then

                                End If

                                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _New_Idmaeedo
                                Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                                _Mensaje.EsCorrecto = True
                                _Mensaje.Id = _New_Idmaeedo
                                _Mensaje.Fecha = FechaDelServidor()
                                _Mensaje.Mensaje = "Documento creado correctamente"
                                _Mensaje.Detalle = "Se crea el documento: " & _Row_Maeedo.Item("TIDO") & "-" & _Row_Maeedo.Item("NUDO")

                            End If

                        Else

                            _Mensaje.Mensaje = "Documento cerrado"
                            Throw New System.Exception("Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente")

                        End If

                    End If
                End If
            Else

                _Mensaje.Mensaje = "Información"
                Throw New System.Exception("Debe configurar el formato de salida en la configuración por modalidad de trabajo")

            End If

        Catch ex As Exception
            _Mensaje.Detalle = ex.Message
        End Try

        Return _Mensaje

    End Function

End Class
