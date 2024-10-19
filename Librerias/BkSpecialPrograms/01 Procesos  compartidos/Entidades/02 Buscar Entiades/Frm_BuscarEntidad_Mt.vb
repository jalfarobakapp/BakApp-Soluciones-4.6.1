Imports DevComponents.DotNetBar

Public Class Frm_BuscarEntidad_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Crear_Editar_Entidad As Boolean
    Dim _TblEntidad As DataTable
    Dim _Tbl_Entidades As DataTable

    Dim _RowEntidad As DataRow

    Dim _Preguntar_Despues_de_seleccionar As Boolean
    Dim _Ent_Seleccionada As Boolean

    Dim _VerTeclado As Boolean

    Dim _Filtro_Extra As String

    Public Property Pro_Filtro_Extra() As String
        Get
            Return _Filtro_Extra
        End Get
        Set(value As String)
            _Filtro_Extra = value
        End Set
    End Property
    Public ReadOnly Property Pro_Entidad_Seleccionada() As Boolean
        Get
            If Not (_RowEntidad Is Nothing) Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property Pro_TblEntidad() As DataTable
        Get
            Return _TblEntidad
        End Get
    End Property
    Public ReadOnly Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
    End Property
    Public Property Pro_Crear_Entidad() As Boolean
        Get
            Return BtnCrearUser.Enabled
        End Get
        Set(value As Boolean)
            BtnCrearUser.Enabled = value
            _Crear_Editar_Entidad = value
        End Set
    End Property
    Public Property Pro_Descripcion() As String
        Get
            Return Txtdescripcion.Text
        End Get
        Set(value As String)
            Txtdescripcion.Text = value
        End Set
    End Property

    Public Property PreguntaClientePuntos As Boolean
    Public Property VerSoloEntidadesDelVendedor As Boolean

    Public Sub New(_Preguntar_Despues_de_seleccionar As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Entidades, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        ' EstiloFormulario(StyleManager1)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_BuscarEntidad_Mt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Fx_Activar_Deactivar_Teclado()

        If VerSoloEntidadesDelVendedor Then
            VerSoloEntidadesDelVendedor = True
            'Chk_Solo_Clientes_Del_Vendedor.Checked = True
            Rdb_Ambos.Enabled = False
            Rdb_Proveedores.Enabled = False
        End If

        BtnEditarUser.Enabled = False
        BtnEliminarUser.Enabled = False

        Consulta_sql = "SELECT TOP (50) IDMAEEN,KOEN,SUEN,NOKOEN,SIEN,DIEN," &
                       "Case TIEN " &
                       "When 'A' Then 'Ambos' " &
                       "When 'P' Then 'Proveedor' When 'C' Then 'Cliente' Else '' End As Tipo_Entidad," & vbCrLf &
                       "SUBSTRING(LCEN,6,3) As LCosto,SUBSTRING(LVEN,6,3) As LVenta," & vbCrLf &
                       "Case BLOQUEADO When 1 Then 'SI' Else '' End As Bloqueado_Venta," & vbCrLf &
                       "Case BLOQENCOM When 1 Then 'SI' Else '' End As Bloqueado_Compra" & vbCrLf &
                       "FROM MAEEN Where 1<0"
        _Tbl_Entidades = _Sql.Fx_Get_DataTable(Consulta_sql)

        Grilla_Entidades.DataSource = _Tbl_Entidades


        Chk_Solo_Clientes_Del_Vendedor.Checked = True

        Sb_Actualizar_Grilla(Txtdescripcion.Text, False)


        Me.ActiveControl = Txtdescripcion

        AddHandler Txtdescripcion.KeyDown, AddressOf Sb_Txtdescripcion_KeyDown
        AddHandler Txtdescripcion.TextChanged, AddressOf Sb_Txtdescripcion_TextChanged
        AddHandler Grilla_Entidades.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Entidades.MouseDown, AddressOf Sb_Grilla_MouseDown

        AddHandler Rdb_Clientes.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Proveedores.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Ambos.CheckedChanged, AddressOf Rdb_CheckedChanged

        AddHandler Chk_Solo_Clientes_Del_Vendedor.CheckedChanged, AddressOf Chk_Solo_Clientes_Del_Vendedor_CheckedChanged

    End Sub

    Private Sub BtnCrearUser_Click(sender As System.Object, e As System.EventArgs) Handles BtnCrearUser.Click

        If Not Fx_Tiene_Permiso(Me, "CfEnt002") Then
            Return
        End If

        Dim _ClientePuntos As Boolean

        If PreguntaClientePuntos Then

            If MessageBoxEx.Show(Me, "¿Crea cliente para puntos?", "Creación de entidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _ClientePuntos = True
            End If

        End If

        Dim Fm As New Frm_Crear_Entidad_Mt
        Fm.CrearEntidad = True
        Fm.EditarEntidad = False
        Fm.ClientePuntos = _ClientePuntos
        Fm.ShowDialog(Me)

        If Fm.CreaNuevaEntidad Then
            Sb_Actualizar_Grilla(Fm.Txt_Koen.Text, True)
            ToastNotification.Show(Me, "ENTIDAD CREADA CORRECTAMENTE", My.Resources.ok_button,
                                      3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Seleccionar_Fila(_Crear_Editar_Entidad As Boolean)

        Dim _Fila As DataGridViewRow = Grilla_Entidades.Rows(Grilla_Entidades.CurrentRow.Index)

        Dim _CodEntidad As String = _Fila.Cells("KOEN").Value
        Dim _SucEntidad As String = _Fila.Cells("SUEN").Value
        Dim _RazonSocial As String = Trim(_Fila.Cells("NOKOEN").Value)

        Me.Enabled = False

        If Grilla_Entidades.RowCount > 0 Then

            If _Crear_Editar_Entidad Then

                If Fx_Tiene_Permiso(Me, "CfEnt003") Then

                    Dim Fm As New Frm_Crear_Entidad_Mt
                    Fm.Fx_Llenar_Entidad(_CodEntidad, _SucEntidad)
                    Fm.CrearEntidad = False
                    Fm.EditarEntidad = True
                    Fm.ShowDialog(Me)

                    If Fm.Elimnar Then
                        Grilla_Entidades.Rows.RemoveAt(Grilla_Entidades.CurrentRow.Index)
                    ElseIf Fm.EditarEntidad Then
                        If Fm.Grabar Then
                            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                          3 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
                        End If
                    End If
                    Fm.Dispose()

                End If

            Else

                If _Preguntar_Despues_de_seleccionar Then

                    If MessageBoxEx.Show(Me, "¿Esta seguro de seleccionar esta entidad?" & vbCrLf &
                                      "Entidad: " & _CodEntidad & " " & Trim(_RazonSocial),
                                      "Seleccionar entidad", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) = DialogResult.No Then
                        Return
                    End If
                End If

                _RowEntidad = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)
                _TblEntidad = Fx_Traer_Datos_Entidad_Tabla(_CodEntidad, _SucEntidad)

                Me.Close()

            End If
        Else
            MessageBoxEx.Show(Me, "No hay ninguna entidad que editar",
                              "Edita Entidad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Me.Enabled = True

    End Sub

    Sub Sb_Formato_Grilla()

        With Grilla_Entidades

            '.DataSource = _Tbl_Entidades

            OcultarEncabezadoGrilla(Grilla_Entidades, True)

            Dim _DisplayIndex = 0

            .Columns("KOEN").Width = 73
            .Columns("KOEN").HeaderText = "Código"
            .Columns("KOEN").Visible = True
            .Columns("KOEN").Frozen = True
            .Columns("KOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUEN").Width = 90
            .Columns("SUEN").HeaderText = "Suc."
            .Columns("SUEN").Visible = True
            .Columns("SUEN").Frozen = True
            .Columns("SUEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Width = 230
            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").Frozen = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SIEN").Width = 85
            .Columns("SIEN").HeaderText = "Sigla"
            .Columns("SIEN").Visible = True
            .Columns("SIEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DIEN").Width = 210
            .Columns("DIEN").HeaderText = "Dirección"
            .Columns("DIEN").Visible = True
            .Columns("DIEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo_Entidad").Width = 60
            .Columns("Tipo_Entidad").HeaderText = "Tipo"
            .Columns("Tipo_Entidad").Visible = True
            .Columns("Tipo_Entidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("LVenta").Width = 30
            .Columns("LVenta").HeaderText = "LV"
            .Columns("LVenta").Visible = True
            .Columns("LVenta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("LCosto").Width = 30
            .Columns("LCosto").HeaderText = "LC"
            .Columns("LCosto").Visible = True
            .Columns("LCosto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bloqueado_Venta").Width = 50
            .Columns("Bloqueado_Venta").HeaderText = "Block. Venta"
            .Columns("Bloqueado_Venta").Visible = True
            .Columns("Bloqueado_Venta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bloqueado_Compra").Width = 50
            .Columns("Bloqueado_Compra").HeaderText = "Block. Compra"
            .Columns("Bloqueado_Compra").Visible = True
            .Columns("Bloqueado_Compra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Function Sb_Actualizar_Grilla(_Texto_Busqueda As String, _Limpiar As Boolean)

        Dim _Condicion_Entidad = String.Empty

        If Rdb_Ambos.Checked Then
            _Condicion_Entidad = String.Empty
        ElseIf Rdb_Clientes.Checked Then
            _Condicion_Entidad = "And (TIEN IN ('C','A'))"
        ElseIf Rdb_Proveedores.Checked Then
            _Condicion_Entidad = "And (TIEN IN ('P','A'))"
        End If

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "KOEN+NOKOEN+SUEN+DIEN LIKE '%")
        Dim _Filtro_Entidades As String = Generar_Filtro_IN(_Tbl_Entidades, "", "IDMAEEN", False, False, "'")

        If _Filtro_Entidades = "()" Then
            _Filtro_Entidades = String.Empty
        Else
            _Filtro_Entidades = "And IDMAEEN Not In " & _Filtro_Entidades
        End If

        Dim _Filtro_Vendedores = String.Empty

        If Not Rdb_Proveedores.Checked Then
            If Chk_Solo_Clientes_Del_Vendedor.Checked Then
                _Filtro_Vendedores = "And KOFUEN = '" & FUNCIONARIO & "'"
            End If
        End If

        If _Limpiar Then
            _Tbl_Entidades.Clear()
            _Filtro_Entidades = String.Empty
        End If

        Consulta_sql = "Select Top (50) IDMAEEN,KOEN,SUEN,NOKOEN,SIEN,DIEN," &
                       "Case TIEN " &
                       "When 'A' Then 'Ambos' " &
                       "When 'P' Then 'Proveedor' When 'C' Then 'Cliente' Else '' End As Tipo_Entidad," & vbCrLf &
                       "SUBSTRING(LCEN,6,3) As LCosto,SUBSTRING(LVEN,6,3) As LVenta," & vbCrLf &
                       "BLOQUEADO,BLOQENCOM," & vbCrLf &
                       "Case BLOQUEADO When 1 Then 'SI' Else '' End As Bloqueado_Venta," & vbCrLf &
                       "Case BLOQENCOM When 1 Then 'SI' Else '' End As Bloqueado_Compra" & vbCrLf &
                       "From MAEEN With (Nolock) " &
                       "Where KOEN+NOKOEN+SUEN+DIEN LIKE '%" & _Cadena & "%'" & vbCrLf &
                       _Condicion_Entidad & vbCrLf &
                       _Filtro_Extra & vbCrLf &
                       _Filtro_Entidades & vbCrLf &
                       _Filtro_Vendedores & vbCrLf &
                       "Order by KOEN"
        Dim _Tmp As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tmp.Rows
            Sb_Nueva_Linea(_Fila)
        Next

        Sb_Formato_Grilla()

    End Function

    Private Sub Sb_Nueva_Linea(_Fila As DataRow)

        Dim NewFila As DataRow
        NewFila = _Tbl_Entidades.NewRow
        With NewFila

            .Item("IDMAEEN") = _Fila.Item("IDMAEEN")
            .Item("KOEN") = _Fila.Item("KOEN")
            .Item("SIEN") = _Fila.Item("SIEN")
            .Item("SUEN") = _Fila.Item("SUEN")
            .Item("NOKOEN") = _Fila.Item("NOKOEN")
            .Item("DIEN") = _Fila.Item("DIEN")
            .Item("LCosto") = _Fila.Item("LCosto")
            .Item("LVenta") = _Fila.Item("LVenta")
            .Item("Tipo_Entidad") = _Fila.Item("Tipo_Entidad")

            _Tbl_Entidades.Rows.Add(NewFila)

        End With

    End Sub

    Function Sb_Actualizar_Grilla_Old(_Texto_Busqueda As String)

        Dim _Condicion_Entidad As String

        If Rdb_Ambos.Checked Then
            _Condicion_Entidad = String.Empty
        ElseIf Rdb_Clientes.Checked Then
            _Condicion_Entidad = "And (TIEN IN ('C','A'))"
        ElseIf Rdb_Proveedores.Checked Then
            _Condicion_Entidad = "And (TIEN IN ('P','A'))"
        End If


        Dim cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "KOEN+NOKOEN+SUEN LIKE '%")

        Consulta_sql = "SELECT TOP (50) KOEN,SUEN,NOKOEN,SIEN,DIEN," &
                       "Case TIEN " &
                       "When 'A' Then 'Cliente/Proveedor' " &
                       "When 'P' Then 'Proveedor' When 'C' Then 'Cliente' Else '' End As Tipo_Entidad" & vbCrLf &
                       "FROM MAEEN WITH (NOLOCK) " &
                       "WHERE KOEN+NOKOEN+SUEN LIKE '%" & cadena & "%'" & vbCrLf & _Condicion_Entidad & vbCrLf &
                       _Filtro_Extra & vbCrLf &
                       "ORDER BY KOEN"

        With Grilla_Entidades
            .DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla_Entidades, True)

            .Columns("KOEN").Width = 80
            .Columns("KOEN").HeaderText = "Código"
            .Columns("KOEN").Visible = True

            .Columns("SUEN").Width = 90
            .Columns("SUEN").HeaderText = "Suc."
            .Columns("SUEN").Visible = True

            .Columns("NOKOEN").Width = 250
            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Visible = True

            .Columns("SIEN").Width = 95 - 10
            .Columns("SIEN").HeaderText = "Sigla"
            .Columns("SIEN").Visible = True

            .Columns("DIEN").Width = 250
            .Columns("DIEN").HeaderText = "Dirección"
            .Columns("DIEN").Visible = True

            .Columns("Tipo_Entidad").Width = 100
            .Columns("Tipo_Entidad").HeaderText = "Tipo Entidad"
            .Columns("Tipo_Entidad").Visible = True

        End With


    End Function
    Function Fx_Activar_Deactivar_Teclado()

        If _Global_Es_Touch Then
            TouchKeyboard1.SetShowTouchKeyboard(Txtdescripcion, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Inline)
        Else
            TouchKeyboard1.SetShowTouchKeyboard(Txtdescripcion, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.No)
            TouchKeyboard1.HideKeyboard()
        End If

        Btn_Bajar.Visible = _Global_Es_Touch
        Btn_Subir.Visible = _Global_Es_Touch
        Btn_Seleccionar.Visible = _Global_Es_Touch

        Me.Refresh()

    End Function

    Private Sub BtnEditarUser_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditarUser.Click
        Sb_Seleccionar_Fila(True)
    End Sub

    Private Sub Frm_BuscarEntidad_Mt_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub AsociarMarcaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AsociarMarcaToolStripMenuItem.Click
        With Grilla_Entidades
            Dim _CodEntidad As String = Trim(.Rows(.CurrentRow.Index).Cells("KOEN").Value)
            Dim _CodSucursal As String = Trim(.Rows(.CurrentRow.Index).Cells("SUEN").Value)
            Dim _RazonEntidad As String = Trim(.Rows(.CurrentRow.Index).Cells("NOKOEN").Value)

            Dim Fm As New Frm_ProveedoresVSMarcas
            Fm.TxtCodigo.Text = _CodEntidad
            Fm.Txtdescripcion.Text = _RazonEntidad
            Fm.ShowDialog(Me)

        End With
    End Sub

    Private Sub Grilla_Entidades_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Entidades.CellDoubleClick
        Sb_Seleccionar_Fila(_Crear_Editar_Entidad)
    End Sub
    Private Sub Grilla_Entidades_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Entidades.KeyDown

        If CBool(Grilla_Entidades.RowCount) Then

            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter

                    SendKeys.Send("{LEFT}")
                    e.Handled = True
                    Sb_Seleccionar_Fila(_Crear_Editar_Entidad)

                Case Keys.Down

                    Dim _Filas As Integer = Grilla_Entidades.Rows.Count - 1
                    Dim _FilaSelect As Integer = Grilla_Entidades.CurrentRow.Index

                    If _Filas = _FilaSelect Then
                        Sb_Actualizar_Grilla(Txtdescripcion.Text, False)
                    End If

            End Select

        End If

    End Sub
    Private Sub BtnEliminarUser_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminarUser.Click
        Call Btn_Mnu_Eliminar_Entidad_Click(Nothing, Nothing)
    End Sub
    Private Sub Grilla_Entidades_Enter(sender As System.Object, e As System.EventArgs) Handles Grilla_Entidades.Enter
        If CBool(Grilla_Entidades.RowCount) Then
            Grilla_Entidades.CurrentCell = Grilla_Entidades.Rows(0).Cells("KOEN")
            BtnEditarUser.Enabled = True
            BtnEliminarUser.Enabled = True
        End If
    End Sub
    Private Sub Grilla_Entidades_Leave(sender As System.Object, e As System.EventArgs) Handles Grilla_Entidades.Leave
        BtnEditarUser.Enabled = False
        BtnEliminarUser.Enabled = False
    End Sub

    Private Sub Sb_Txtdescripcion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = Keys.Down Then

            e.Handled = True
            Grilla_Entidades.Focus()

        ElseIf e.KeyValue = Keys.Space And Not String.IsNullOrEmpty(Trim(Txtdescripcion.Text)) Then

            Sb_Actualizar_Grilla(Txtdescripcion.Text, True)

        ElseIf e.KeyValue = Keys.Enter Then

            Sb_Actualizar_Grilla(Txtdescripcion.Text, True)

            If CBool(Grilla_Entidades.Rows.Count) Then
                Grilla_Entidades.Focus()
            Else
                Beep()
                ToastNotification.Show(Me, "NO SE ENCONTRARON ENTIDADES", My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If

        End If

    End Sub

    Private Sub Sb_Txtdescripcion_TextChanged(sender As System.Object, e As System.EventArgs)

        If Txtdescripcion.Text = "" Then
            Sb_Actualizar_Grilla("", True)
        End If

    End Sub

    Private Sub Btn_Subir_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Subir.Click
        SendKeys.Send("{UP}")
    End Sub
    Private Sub Btn_Bajar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Bajar.Click
        SendKeys.Send("{DOWN}")
    End Sub
    Private Sub Btn_Seleccionar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Seleccionar.Click
        Sb_Seleccionar_Fila(_Crear_Editar_Entidad)
    End Sub

    'Private Sub Grilla_Detalle_RowPostPaint( sender As Object,  e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
    '    Try
    '        'Captura el numero de filas del datagridview
    '        Dim RowsNumber As String = (e.RowIndex + 1).ToString
    '        While RowsNumber.Length < sender.RowCount.ToString.Length
    '            RowsNumber = "0" & RowsNumber
    '        End While
    '        Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
    '        If sender.RowHeadersWidth < CInt(size.Width + 20) Then
    '            sender.RowHeadersWidth = CInt(size.Width + 20)
    '        End If

    '        Dim ob As Brush = SystemBrushes.ControlText

    '        If StyleManager.MetroColorGeneratorParameters.CanvasColor = Color.Black Then
    '            ob = New SolidBrush(Color.White)
    '            'ob = SystemBrushes.ControlDarkDark
    '        End If

    '        e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "vb.net",
    '     MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub Grilla_MouseWheel(sender As Object, e As MouseEventArgs)

        'Return
        ' Si el ratón no tiene rueda, o el sistema operativo no
        ' admite la rueda del ratón de manera nativa, abandonamos
        ' el procedimiento.
        '
        If ((Not (SystemInformation.MouseWheelPresent)) OrElse
         (Not (SystemInformation.NativeMouseWheelSupport))) Then Return

        ' Fila actualmente seleccionada en el control DataGridView.
        '
        Dim currentRow As DataGridViewRow = sender.CurrentRow
        If (currentRow Is Nothing) Then Return

        ' Índice de la fila actual.
        '
        Dim index As Integer = currentRow.Index

        ' Número total de filas.
        '
        Dim count As Integer = sender.Rows.Count

        ' Número de líneas de desplazamiento.
        '
        Dim scrollLines As Integer = 10 'SystemInformation.MouseWheelScrollLines

        If count <= 25 Then scrollLines = 1

        ' ¿Arriba o abajo?
        '
        Dim down As Boolean = (e.Delta < 0)

        If (down) Then
            ' Abajo
            index += scrollLines

            If (index >= count) Then
                ' Es la última fila.
                Sb_Actualizar_Grilla(Txtdescripcion.Text, False)
                Return
            End If

            ' Establecemos el valor de la nueva celda actual.
            '
            'sender.CurrentCell = sender.Rows(index).Cells(0)

        Else
            ' Arriba
            index -= scrollLines

            If (index < 1) Then
                ' Es la primera fila.
                index = 0
            End If

        End If

        ' Establecemos el valor de la nueva celda actual.
        '
        sender.CurrentCell = sender.Rows(index).Cells(1)

    End Sub

    Private Sub Grilla_Entidades_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla_Entidades.DataError
        MsgBox(e.Exception)
    End Sub

    Private Sub Btn_Mnu_Editar_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Editar_Entidad.Click
        Sb_Seleccionar_Fila(True)
    End Sub

    Private Sub Btn_Mnu_Eliminar_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Eliminar_Entidad.Click

        Dim _Fila As DataGridViewRow = Grilla_Entidades.Rows(Grilla_Entidades.CurrentRow.Index)

        Dim _CodEntidad As String = _Fila.Cells("KOEN").Value
        Dim _SucEntidad As String = _Fila.Cells("SUEN").Value

        If Fx_Eliminar_Entidad(_CodEntidad, _SucEntidad, Me) Then
            Sb_Actualizar_Grilla(Txtdescripcion.Text, True)
            BtnEditarUser.Enabled = False
            BtnEliminarUser.Enabled = False
        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Rdb_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs)
        If CType(sender, CheckBoxItem).Checked Then
            Sb_Bucar_Entidades()
        End If
    End Sub

    Sub Sb_Bucar_Entidades()

        Sb_Actualizar_Grilla(Txtdescripcion.Text, True)

        If CBool(Grilla_Entidades.Rows.Count) Then
            Grilla_Entidades.Focus()
        Else
            Beep()
            ToastNotification.Show(Me, "NO SE ENCONTRARON ENTIDADES", My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

    End Sub

    Private Sub Btn_Contactos_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Contactos_Entidad.Click

        Dim _Pueder_Ver As Boolean = Fx_Tiene_Permiso(Me, "CfEnt003",, False)

        If Not _Pueder_Ver Then
            _Pueder_Ver = Fx_Tiene_Permiso(Me, "CfEnt026")
        End If

        If _Pueder_Ver Then

            Dim _Fila As DataGridViewRow = Grilla_Entidades.Rows(Grilla_Entidades.CurrentRow.Index)

            Dim _CodEntidad As String = _Fila.Cells("KOEN").Value
            Dim _SucEntidad As String = _Fila.Cells("SUEN").Value
            Dim _RazonSocial As String = Trim(_Fila.Cells("NOKOEN").Value)

            Dim Fm As New Frm_Crear_Entidad_Mt_Lista_contactos(False)
            Fm.Pro_CodEntidad = _CodEntidad
            Fm.Pro_SucEntidad = _SucEntidad
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Direcciones_Despacho_Click(sender As Object, e As EventArgs) Handles Btn_Direcciones_Despacho.Click

        Dim _Pueder_Ver As Boolean = Fx_Tiene_Permiso(Me, "CfEnt003",, False)

        If Not _Pueder_Ver Then
            _Pueder_Ver = Fx_Tiene_Permiso(Me, "CfEnt027")
        End If

        If _Pueder_Ver Then

            Dim _Fila As DataGridViewRow = Grilla_Entidades.Rows(Grilla_Entidades.CurrentRow.Index)

            Dim _CodEntidad As String = _Fila.Cells("KOEN").Value
            Dim _SucEntidad As String = _Fila.Cells("SUEN").Value
            Dim _RazonSocial As String = Trim(_Fila.Cells("NOKOEN").Value)

            Dim Fm As New Frm_Direc_Cli_Lista(_CodEntidad, _SucEntidad)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Chk_Solo_Clientes_Del_Vendedor_CheckedChanged(sender As Object, e As EventArgs)

        If VerSoloEntidadesDelVendedor Then
            If Not Chk_Solo_Clientes_Del_Vendedor.Checked Then
                If Not Fx_Tiene_Permiso(Me, "CfEnt031") Then
                    Chk_Solo_Clientes_Del_Vendedor.Checked = True
                    Return
                End If
            End If
        End If

        Sb_Bucar_Entidades()

    End Sub

End Class
