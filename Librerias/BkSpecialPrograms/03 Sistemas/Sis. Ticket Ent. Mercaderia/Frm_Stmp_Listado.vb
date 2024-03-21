Imports DevComponents.DotNetBar

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
        'AddHandler Tab_Cerradas.Click, AddressOf Sb_Actualizar_Grilla

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

        Consulta_sql = "Select Enc.*,Edo.FEEMDO,Edo.SUDO,En.NOKOEN," & vbCrLf &
                       "Case Estado " & vbCrLf &
                       "When 'PREPA' Then 'Preparación...'" & vbCrLf &
                       "When 'COMPL' Then 'Completada.'" & vbCrLf &
                       "When 'HABIL' Then 'Habilitada para ser facturada.'" & vbCrLf &
                       "When 'FACTU' Then Case TipoPago When 'Contado' Then 'Facturada, pase por CAJA...' When 'Credito' Then 'Facturada, pase a DESPACHO EN BODEGA...' End" & vbCrLf &
                       "When 'CERRA' Then 'Cerrada'" & vbCrLf &
                       "When 'NULO' Then 'Nula'" & vbCrLf &
                       "End As 'Estado_Str'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stmp_Enc Enc" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Enc.Idmaeedo" & vbCrLf &
                       "Left Join MAEEN En On En.KOEN = Enc.Endo And En.SUEN = Enc.Suendo" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Condicion

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
            .Columns("SUDO").Width = 80
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Endo").Visible = True
            .Columns("Endo").HeaderText = "Entidad"
            '.Columns("Endo").ToolTipText = "Estado del Ticket"
            .Columns("Endo").Width = 120
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

            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").HeaderText = "F.Creación"
            '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").Width = 100
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
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

        Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Row_Documento.Item("ENDO"), _Row_Documento.Item("SUENDO"))
        Dim _Cl_Stem As New Cl_Stmp

        With _Cl_Stem.Stem_Enc

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

            Try
                .Secueven = _Row_Entidad.Item("SECUEVEN")
            Catch ex As Exception
                .Secueven = String.Empty
            End Try

        End With

        Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO")
        Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Detalle.Rows

            Dim _Stem_Det As New Stmp_BD.Stmp_Det

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

            _Cl_Stem.Stem_Det.Add(_Stem_Det)

        Next

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem = _Cl_Stem.Fx_Grabar_Nuevo_Tickets

        If Not _Mensaje_Stem.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje_Stem.Mensaje, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, "Ticket Nro. " & _Cl_Stem.Stem_Enc.Numero & " creado correctamente." & vbCrLf &
                          "El documento ya esta en proceso", "Crear Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_RevisarTicket_Click(sender As Object, e As EventArgs) Handles Btn_RevisarTicket.Click

        Dim _Nudo As String
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el numero de nota de venta a recisar",
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

        Dim _Tbas = Super_TabS.SelectedTab

        If _Tbas.Name = "Tab_Preparacion" Then

            Dim _Id_Enc As Integer = _Fila.Cells("Id").Value

            Dim Fm As New Frm_Stmp_IngPickeo(_Id_Enc, FUNCIONARIO)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Actualizar_Grilla()

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

        If Not _Row_Documento.Item("Pickear") Then
            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "Este documento no esta marcado para ser Pickeado en la tabla Zw_Docu_Ent"
            _Mensaje_Stem.Detalle = "Documento: " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
            Return _Mensaje_Stem
        End If


        Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Row_Documento.Item("ENDO"), _Row_Documento.Item("SUENDO"))
        Dim _Cl_Stem As New Cl_Stmp

        With _Cl_Stem.Stem_Enc

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

            Dim _Stem_Det As New Stmp_BD.Stmp_Det

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

            _Cl_Stem.Stem_Det.Add(_Stem_Det)

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



End Class
