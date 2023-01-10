Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Tabla_Caracterizaciones_01_Listado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Rd As String ' Nombre de la tabla en Random
    Dim _Campo_Id, _Campo_Descripcion As String ' Campos para llenar la tabla en Random 

    Dim _Caracteres_Codigo As Integer
    Dim _CodTablaClass As String
    Dim _CodClass As String
    Dim _DesClassOrigen As String
    Dim _DesClassAltern As String

    Dim FilaSeleccionada As Integer

    Dim _ConsultaSQLlocal As String

    Dim _DsTablas As New DsTablas

    Dim _TblTablaCaracterizaciones As DataTable

    Dim _Tabla As Enum_Tablas_Random
    Dim _RowFilaSeleccionada As DataRow

    Dim _Seleccion As Boolean
    Dim _TblFilasSeleccionadas As DataTable

    Private _dv As New DataView

    Dim _Cerrar_al_grabar As Boolean

    Dim _Arr_Info_Tabla(2) As String

    Dim _Padre_Tabla, _Padre_CodigoTabla As String
    Dim _Ano_Feriados As Integer


    Dim _Accion As Accion

    Enum Accion
        Seleccionar
        Mantencion_Tabla
        Multiseleccion
    End Enum

    Enum Enum_Tablas_Random
        Articulo
        Color
        Medida
        Modelo
        Marcas
        Rubros
        Claslibre
        Super_Familia
        Familia
        Sub_Familia
        Tipoentidad
        Actividade
        Tamanoempr
        Cargos
        Areasactiv
        Transporte
        Maquina_ST
        Categorias_ST
        Modelos_ST
        Check_in_ST
        Accesorios_ST
        Estado_Entrega_ST
        Vehiculo_Tipo
        Vehiculo_Marca
        Vehiculo_Modelo
        Licencia_Conducir 'LICENCIA_COND
        Feriados_Anuales
        Sql_Command
        Reclamos_Tipos
        Reclamos_Sub_Tipos
        Reclamos_Estados
        Reclamos_Sub_Estados
        Reclamos_Accion
        Reclamos_Preguntas
        Despachos_Tipo_Venta
        Despachos_Tipo_Envio
        ZonaProducto
    End Enum

    Public Property Pro_Ano_Feriados() As Integer
        Get
            Return _Ano_Feriados
        End Get
        Set(value As Integer)
            _Ano_Feriados = value
        End Set
    End Property

    Public Sub New(Tabla As Enum_Tablas_Random,
                   Accion_Fm As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Tabla = Tabla
        _Arr_Info_Tabla = Fx_Info_Tabla(Tabla)

        _CodTablaClass = _Arr_Info_Tabla(1)
        _Caracteres_Codigo = _Arr_Info_Tabla(0)

        _Ano_Feriados = FechaDelServidor.Year

        _Accion = Accion_Fm

    End Sub

    Private Sub Frm_Tabla_Caracterizaciones_01_Listado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If _Accion = Accion.Mantencion_Tabla Then
            Me.Top += 30
            Me.Left += 30
            AddHandler TxtDescripcion.KeyDown, AddressOf TxtDescripcion_KeyDown_Filtro_Mantencion
        Else
            AddHandler TxtDescripcion.KeyDown, AddressOf TxtDescripcion_KeyDown_Filtro_Seleccion
            Grilla.AllowUserToAddRows = False
            Grilla.AllowUserToDeleteRows = False
        End If

        Sb_Actualizar_Grilla("")

        Dim instance As DataGridViewTextBoxColumn
        instance = Grilla.Columns("CodigoTabla")
        instance.MaxInputLength = _Arr_Info_Tabla(0)
        instance = Grilla.Columns("NombreTabla")
        instance.MaxInputLength = _Arr_Info_Tabla(3)

    End Sub

    Sub Sb_Actualizar_Grilla(Descripcion As String)

        If Not String.IsNullOrEmpty(TxtDescripcion.Text) Then
            If _Accion = Accion.Seleccionar Then
                _dv.RowFilter = String.Format("NombreTabla Like '%{0}%'", TxtDescripcion.Text)
            Else
                BuscarDatoEnGrilla(TxtDescripcion.Text, "NombreTabla", Grilla)
            End If
        End If

        Btn_Seleccionar.Visible = False


        Dim _Condicion_Padre

        If Not String.IsNullOrEmpty(_Padre_Tabla) And Not String.IsNullOrEmpty(_Padre_CodigoTabla) Then
            _Condicion_Padre = "And Padre_Tabla = '" & _Padre_Tabla & "' And Padre_CodigoTabla = '" & _Padre_CodigoTabla & "'" & vbCrLf
        End If

        Dim Condicion =
               CADENA_A_BUSCAR(Descripcion,
                               "CodigoTabla+NombreTabla LIKE '%")

        Dim _Orden As String

        If _Tabla = Enum_Tablas_Random.Feriados_Anuales Then
            Consulta_sql = "SELECT Cast(0 as Bit) as Nuevo_Item,*" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _CodTablaClass & "'" & vbCrLf &
                       "And CodigoTabla+NombreTabla like '%" & Condicion & "%'" & vbCrLf &
                       _Condicion_Padre &
                       "And Fecha Between '" & _Ano_Feriados & "0101' And '" & _Ano_Feriados & "1231'" & vbCrLf &
                       "Order By Fecha"
        Else

            Consulta_sql = "SELECT Cast(0 as Bit) as Nuevo_Item,*" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _CodTablaClass & "'" & vbCrLf &
                       "And CodigoTabla+NombreTabla like '%" & Condicion & "%'" & vbCrLf &
                       _Condicion_Padre &
                       "Order By Orden"
        End If

        _ConsultaSQLlocal = Consulta_sql

        _DsTablas.Clear()
        _dv.Table = _Sql.Fx_Get_DataSet(Consulta_sql, _DsTablas, "Zw_TablaDeCaracterizaciones").Tables("Zw_TablaDeCaracterizaciones")

        With Grilla

            If _Accion = Accion.Seleccionar Or _Accion = Accion.Multiseleccion Then
                .DataSource = _dv
            ElseIf _Accion = Accion.Mantencion_Tabla Then
                .DataSource = _DsTablas
                .DataMember = _DsTablas.Tables("Zw_TablaDeCaracterizaciones").TableName
            End If

            OcultarEncabezadoGrilla(Grilla, False, , False)

            Dim _Largo = 0

            If _Accion = Accion.Multiseleccion Then
                _Largo = 30
                .Columns("Chk").HeaderText = "Sel."
                .Columns("Chk").Width = _Largo
                .Columns("Chk").Visible = True
            End If

            .Columns("CodigoTabla").HeaderText = "Código"
            .Columns("CodigoTabla").Width = 130 - _Largo
            .Columns("CodigoTabla").Visible = True

            .Columns("NombreTabla").HeaderText = "Descripción"
            .Columns("NombreTabla").Width = 320 - _Largo
            .Columns("NombreTabla").Visible = True

            If _Accion = Accion.Seleccionar Then
                .Columns("CodigoTabla").ReadOnly = True
                .Columns("NombreTabla").ReadOnly = True
            End If

            '.Columns("NombreTabla").HeaderText = "Descripción alternativa"
            '.Columns("NombreTabla").Width = 250
            '.Columns("NombreTabla").Visible = True

            .Columns("ApColor").HeaderText = "Color"
            .Columns("ApColor").Width = 60

            .Columns("ApModelo").HeaderText = "Modelo"
            .Columns("ApModelo").Width = 60

            .Columns("ApMedida").HeaderText = "Medida"
            .Columns("ApMedida").Width = 60

            If _CodTablaClass = "ARTICULO" Then
                .Columns("ApColor").Visible = True
                .Columns("ApModelo").Visible = True
                .Columns("ApMedida").Visible = True
            End If

            If CBool(.RowCount) Then
                .FirstDisplayedScrollingRowIndex = .RowCount - 1
                .CurrentCell = .Rows(.RowCount - 1).Cells("CodigoTabla")
            End If

        End With

        Sb_Actualizar_Seleccion()
        Me.Refresh()

    End Sub

    Sub Sb_Actualizar_Seleccion()

        Select Case _Accion

            Case Accion.Seleccionar

                Btn_Grabar.Visible = False
                Grilla.ContextMenuStrip = Nothing
                AddHandler Grilla.CellDoubleClick, AddressOf Grilla_CellDoubleClick
                Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

            Case Accion.Multiseleccion

                Btn_Seleccionar.Visible = True
                Btn_Grabar.Visible = False
                Grilla.ContextMenuStrip = Nothing
                Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, True)

                If Not (_TblFilasSeleccionadas Is Nothing) Then

                    For Each _Fila As DataRow In _TblFilasSeleccionadas.Rows
                        Dim _Codigo As String = NuloPorNro(_Fila.Item("Codigo"), "")

                        For Each _Row As DataRow In _dv.Table.Rows 'Grilla.Rows

                            If _Row.RowState <> DataRowState.Deleted Then
                                Dim _CodigoTabla As String = NuloPorNro(_Row.Item("CodigoTabla"), "")

                                If Not String.IsNullOrEmpty(_CodigoTabla) Then
                                    If _CodigoTabla = _Codigo Then
                                        _Row.Delete() 'Cells("Chk").Value = True
                                    End If
                                End If
                            End If
                        Next
                    Next
                End If

            Case Accion.Mantencion_Tabla

                Me.ActiveControl = Grilla
                With Grilla
                    .Focus()
                    If CBool(.RowCount) Then
                        .FirstDisplayedScrollingRowIndex = .RowCount - 1
                        .CurrentCell = .Rows(.RowCount - 1).Cells("NombreTabla")
                        .BeginEdit(True)
                    End If
                End With

                Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        End Select

    End Sub

    Private Sub BtnCrear_Click(sender As System.Object, e As System.EventArgs) Handles BtnCrear.Click

        If _Accion = Accion.Seleccionar Or _Accion = Accion.Multiseleccion Then

            If Fx_Tiene_Permiso(Me, "Tbl00016") Then

                Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(_Tabla, Accion.Mantencion_Tabla)
                Fm.Text = "Mantención de " & _Tabla.ToString
                Fm.Pro_Cerrar_al_grabar = True
                Fm.ShowDialog(Me)

                TxtDescripcion.Text = String.Empty
                Sb_Actualizar_Grilla("")

            End If

        ElseIf _Accion = Accion.Mantencion_Tabla Then
            With Grilla
                If CBool(.RowCount) Then
                    .FirstDisplayedScrollingRowIndex = .RowCount - 1
                    .CurrentCell = .Rows(.RowCount - 1).Cells("CodigoTabla")
                    .BeginEdit(True)
                End If
            End With
        End If

    End Sub



    Private Sub Frm_Tabla_Caracterizaciones_01_Listado_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Sb_Salir()
        ElseIf e.KeyValue = Keys.Down Then
            Return
            Dim _X As Integer = Grilla.CurrentCellAddress.X
            Dim _Y As Integer = Grilla.CurrentCellAddress.Y

            Dim _Nuevo_Item As Boolean = Grilla.Rows(_Y).Cells("Nuevo_Item").Value

            Dim _Filas As Integer = Grilla.Rows.Count - 1

            If Not _Nuevo_Item Then

                If _Y = _Filas Then
                    Try
                        Sb_Nueva_Linea()
                        Grilla.CurrentCell = Grilla.Rows(_Y + 1).Cells("CodigoTabla")
                    Catch ex As Exception

                    End Try

                End If

            End If

        End If
    End Sub

    Private Sub Grilla_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Nuevo_Item As Boolean = NuloPorNro(_Fila.Cells("Nuevo_Item").Value, False)

        If _Accion = Accion.Multiseleccion Then
            If _Cabeza = "CodigoTabla" Or _Cabeza = "NombreTabla" Then
                e.Cancel = True
            End If
        ElseIf _Accion = Accion.Mantencion_Tabla Then
            If _Cabeza = "CodigoTabla" Then
                If Not _Fila.IsNewRow Then
                    If Not _Nuevo_Item Then
                        Beep()
                        e.Cancel = True
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Eliminar_Fila As Boolean

        Dim _CodigoTabla As String = NuloPorNro(_Fila.Cells("CodigoTabla").Value, "")
        Dim _NombreTabla As String = NuloPorNro(_Fila.Cells("NombreTabla").Value, "")

        If _Tabla = Enum_Tablas_Random.Feriados_Anuales Then

            If _Cabeza = "CodigoTabla" Then
                Dim _Fecha = _Fila.Cells("CodigoTabla").Value

                If Not (_Fecha Is Nothing) Then
                    Dim _Fecha_Dig As Date

                    Try
                        _Fecha_Dig = Convert.ToDateTime(_Fecha)

                        If _Fecha_Dig.Year = _Ano_Feriados Then
                            _Fila.Cells("Fecha").Value = _Fecha_Dig
                            _Fila.Cells("CodigoTabla").Value = FormatDateTime(_Fecha_Dig, DateFormat.ShortDate)
                        Else
                            MessageBoxEx.Show(Me, "Las fecha deben ser del año " & _Ano_Feriados,
                                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            _CodigoTabla = String.Empty
                            _Eliminar_Fila = True
                        End If

                    Catch ex As Exception
                        MessageBoxEx.Show(Me, "El formato de la fecha no corresponde" & vbCrLf &
                                          "El formato debe ser el siguiente dd/mm/aaaa", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        _CodigoTabla = String.Empty
                        _Eliminar_Fila = True
                    End Try
                Else
                    _CodigoTabla = String.Empty
                    _Eliminar_Fila = True
                End If

            End If

            If _Cabeza = "CodigoTabla" Then

                If Not String.IsNullOrEmpty(_CodigoTabla) Then

                    Dim _Aceptado As Boolean
                    _Aceptado = InputBox_Bk(Me, "Ingrese la descripción de la fila",
                                            "Descripción", _NombreTabla, False,
                                            _Tipo_Mayus_Minus.Normal, 50,
                                            False,
                                            _Tipo_Imagen.Texto,
                                            False,
                                            _Tipo_Caracter.Cualquier_caracter, True)

                    If _Aceptado Then
                        _Fila.Cells("NombreTabla").Value = _NombreTabla
                    Else
                        _Eliminar_Fila = True
                    End If
                End If
            End If


            If _Eliminar_Fila Then
                Try
                    Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                Catch ex As Exception

                End Try
            End If

        End If

    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    MenuContextual.Enabled = True
                Else
                    MenuContextual.Enabled = False
                End If
            End With
        End If
    End Sub

    Private Sub EditarDescripciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditarDescripciónToolStripMenuItem.Click
        Grilla.BeginEdit(True)
    End Sub

    Private Sub TxtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDescripcion.TextChanged

        If _Accion = Accion.Seleccionar Then
            _dv.RowFilter = String.Format("NombreTabla Like '%{0}%'", TxtDescripcion.Text)
        ElseIf _Accion = Accion.Mantencion_Tabla Then
            BuscarDatoEnGrilla(TxtDescripcion.Text, "DescripcionTabla", Grilla)
        End If

    End Sub


    Sub Sb_Salir()

        If _Accion = Accion.Mantencion_Tabla Then

            ' Dim _TblFiltroProductos As DataTable = _TblTablaCaracterizaciones
            Dim _Modificado As Boolean = _Global_Fx_Cambio_en_la_Grilla(_DsTablas.Tables("Zw_TablaDeCaracterizaciones"))

            If _Modificado Then

                If MessageBoxEx.Show(Me, "¿Desea guardar los cambios?", "Salir",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Sb_Grabar()
                End If

            End If
        End If

        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

        Sb_Grabar()

        If _Cerrar_al_grabar Then
            Me.Close()
        End If

    End Sub

    Sub Sb_Grabar()

        Dim _TblTablaCaracterizaciones As DataTable = _DsTablas.Tables("Zw_TablaDeCaracterizaciones")
        Dim Contado = 1
        Dim _Nuevas, _Modificadas, _Eliminadas, _SinCambios As Integer
        Dim _Codigo, _Descripcion As String
        Dim _Chk_Color, _Chk_Medida, _Chk_Modelo As Integer

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _TblTablaCaracterizaciones.Rows

            Select Case _Fila.RowState

                Case DataRowState.Added

                    Dim _Grabo As Boolean

                    _Codigo = _Fila.Item("CodigoTabla")
                    _Descripcion = _Fila.Item("NombreTabla")

                    Dim Nro As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "MAX(Orden)",
                                                   "Tabla = '" & _CodTablaClass & "'", True) + 1

                    If _Tabla = Enum_Tablas_Random.Feriados_Anuales Then

                        Dim _Fecha As String

                        If _Fila.Item("Fecha") Is DBNull.Value Then
                            _Fila.Item("Fecha") = FormatDateTime(Convert.ToDateTime(_Codigo), DateFormat.ShortDate)
                        End If

                        _Fecha = Format(_Fila.Item("Fecha"), "yyyyMMdd")

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones " & vbCrLf &
                                   "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo," &
                                   "Padre_Tabla,Padre_CodigoTabla,Fecha) Values " & vbCrLf &
                                   "('" & _CodTablaClass & "'," &
                                   "''," &
                                   "'" & _Codigo & "'," &
                                   "'" & _Descripcion &
                                   "'," & Nro &
                                   ",0,0,0,'" & _Padre_Tabla &
                                   "','" & _Padre_CodigoTabla &
                                   "','" & _Fecha & "')" & vbCrLf

                    Else
                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones " & vbCrLf &
                                    "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo," &
                                    "Padre_Tabla,Padre_CodigoTabla) Values " & vbCrLf &
                                    "('" & _CodTablaClass & "'," &
                                    "''," &
                                    "'" & _Codigo & "'," &
                                    "'" & _Descripcion & "'," & Nro & ",0,0,0,'" & _Padre_Tabla & "','" & _Padre_CodigoTabla & "')" & vbCrLf
                    End If

                    _Grabo = _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    _Nuevas += 1

                Case DataRowState.Modified

                    _Codigo = _Fila.Item("CodigoTabla")
                    _Descripcion = _Fila.Item("NombreTabla")

                    If _Tabla = Enum_Tablas_Random.Feriados_Anuales Then

                        Dim _Fecha As String

                        If _Fila.Item("Fecha") Is DBNull.Value Then
                            _Fila.Item("Fecha") = FormatDateTime(Convert.ToDateTime(_Codigo), DateFormat.ShortDate)
                        End If

                        _Fecha = Format(_Fila.Item("Fecha"), "yyyyMMdd")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Set " &
                                   "NombreTabla = '" & _Descripcion & "',Fecha = '" & _Fecha & "'" & vbCrLf &
                                   "Where Tabla = '" & _CodTablaClass & "' And CodigoTabla = '" & _Codigo & "'"

                    Else
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Set " &
                                   "NombreTabla = '" & _Descripcion & "'" & vbCrLf &
                                   "Where Tabla = '" & _CodTablaClass & "' And CodigoTabla = '" & _Codigo & "'"
                    End If

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    _Modificadas += 1
                Case DataRowState.Unchanged ' Sin cambios
                    _SinCambios += 1
                Case DataRowState.Detached ' ???
                    _Nuevas += 1
                Case DataRowState.Deleted ' Eliminadas
                    _Eliminadas += 1
            End Select

            Contado += 1

        Next


        If CBool(_Eliminadas) Then

            Dim _Filtro_Elimina As String = Generar_Filtro_IN(_TblTablaCaracterizaciones, "", "CodigoTabla", False, False, "'")
            Dim _CondiCodigos = "And CodigoTabla Not In " & _Filtro_Elimina

            If _Filtro_Elimina = "()" Then _CondiCodigos = String.Empty

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                           "Where Tabla = '" & _CodTablaClass & "'" & vbCrLf & _CondiCodigos

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Consulta_sql = _Arr_Info_Tabla(2)

        If Not String.IsNullOrEmpty(Trim(Consulta_sql)) Then
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Sb_Actualizar_Grilla("")


        ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

    End Sub

    Private Sub EliminarFilaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        Try
            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_ExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_ExportarExcel.Click

        Dim _TblFiltroProductos As DataTable = _DsTablas.Tables("Zw_TablaDeCaracterizaciones") '_Ds_Caract.Tables("Tbl_Caracterizaciones")
        Dim _Modificado As Boolean = _Global_Fx_Cambio_en_la_Grilla(_TblFiltroProductos)

        If _Modificado Then
            MessageBoxEx.Show(Me, "SE EXOPOTARAN A EXCEL SOLO LAS FILAS QUE ESTAN GRABADAS EN LA BASE DE DATOS",
                              "EXPORTAR A EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Consulta_sql = "SELECT CodigoTabla as 'Codigo',DescripcionTabla as 'Descripcion tabla',NombreTabla as 'Nombre tabla'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _CodTablaClass & "'" & vbCrLf &
                       "Order by NombreTabla"

        ExportarTabla_JetExcel(Consulta_sql, Me, _CodTablaClass)

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        With Grilla

            Dim _CodigoTabla As String = Trim(.Rows(.CurrentRow.Index).Cells("CodigoTabla").Value)

            If Not String.IsNullOrEmpty(_CodigoTabla) Then

                Dim _Tbl As DataTable

                Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "Where Tabla = '" & _CodTablaClass & "' and CodigoTabla = '" & _CodigoTabla & "'"

                _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_Tbl.Rows.Count) Then
                    _RowFilaSeleccionada = _Tbl.Rows(0)
                    Me.Close()
                Else
                    Beep()
                    ToastNotification.Show(Me, "ESTA FILA NO ESTA GRABADA EN LA BASE DE DATOS" & vbCrLf &
                                           "NO SE PUEDE SELECCIONAR", My.Resources.button_rounded_red_delete,
                                             2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                    Sb_Actualizar_Grilla("")
                End If

            End If

        End With


    End Sub

    Private Sub TxtDescripcion_KeyDown_Filtro_Mantencion(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Enter Then
            '_dv.RowFilter = "NombreTabla Like '%" & TxtDescripcion.Text & "%'"
            BuscarDatoEnGrilla(TxtDescripcion.Text, "NombreTabla", Grilla)
        End If
    End Sub

    Private Sub TxtDescripcion_KeyDown_Filtro_Seleccion(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyValue = Keys.Enter Then
        _dv.RowFilter = "NombreTabla Like '%" & TxtDescripcion.Text & "%'"
        'BuscarDatoEnGrilla(TxtDescripcion.Text, "NombreTabla", Grilla)
        'End If
    End Sub

    Private Sub Sb_Nueva_Linea()

        Dim NewFila As DataRow
        NewFila = _DsTablas.Tables("Zw_TablaDeCaracterizaciones").NewRow
        With NewFila

            .Item("Nuevo_Item") = True
            .Item("Tabla") = _CodTablaClass
            .Item("DescripcionTabla") = String.Empty
            .Item("CodigoTabla") = String.Empty
            .Item("NombreTabla") = String.Empty

            _DsTablas.Tables("Zw_TablaDeCaracterizaciones").Rows.Add(NewFila)

        End With

    End Sub



    Function Fx_Info_Tabla(_Tabla_Random As Enum_Tablas_Random) As String()

        Dim _Tabla As String
        Dim _Arrgeglo(3) As String

        Consulta_sql = String.Empty

        Select Case _Tabla_Random

            Case Enum_Tablas_Random.Articulo
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "ARTICULO"
                _Arrgeglo(2) = ""
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Color
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "COLOR"
                _Arrgeglo(2) = ""
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Medida
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "MEDIDA"
                _Arrgeglo(2) = ""
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Modelo
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "MODELO"
                _Arrgeglo(2) = ""
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Marcas
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "MARCAS"
                _Arrgeglo(2) = "Truncate table TABMR" & vbCrLf &
                               "Insert Into TABMR (KOMR,NOKOMR)" & vbCrLf &
                               "Select DISTINCT CodigoTabla,SUBSTRING(NombreTabla,1,30)" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'MARCAS'" & vbCrLf &
                               "And NombreTabla <> ''"
                _Arrgeglo(3) = 30

                Consulta_sql = "-- MARCAS" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "Select 'MARCAS','', KOMR, NOKOMR,rank() OVER (ORDER BY KOMR) as Orden,0,0,0 " &
                               "From TABMR Order By Orden"

            Case Enum_Tablas_Random.Rubros
                _Arrgeglo(0) = 3
                _Arrgeglo(1) = "RUBROS"
                _Arrgeglo(2) = "Truncate table TABRU" & vbCrLf &
                               "Insert Into TABRU (KORU,NOKORU) Select CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'RUBROS'"
                _Arrgeglo(3) = 30

                Consulta_sql = "-- RUBROS" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "Select 'RUBROS','', KORU, NOKORU,rank() OVER (ORDER BY KORU) as Orden,0,0,0 " &
                               "From TABRU Order By Orden"

            Case Enum_Tablas_Random.Claslibre
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "CLALIBPR"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'CLALIBPR'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'CLALIBPR'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- CLASIFICACION LIBRE" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'CLALIBPR','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'CLALIBPR'"

            Case Enum_Tablas_Random.Actividade
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "ACTIVIDADE"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'ACTIVIDADE'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'ACTIVIDADE'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- ACTIVIDAD ECONOMICA ENTIDAD" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'ACTIVIDADE','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'ACTIVIDADE'"


            Case Enum_Tablas_Random.Tipoentidad
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "TIPOENTIDA"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'TIPOENTIDA'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'TIPOENTIDA'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- TIPO ENTIDAD" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'TIPOENTIDA','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'TIPOENTIDA'"

            Case Enum_Tablas_Random.Tamanoempr
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "TAMA¥OEMPR"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'TAMA¥OEMPR'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'TAMA¥OEMPR'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- TAMAÑO EMPRESA" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'TAMA¥OEMPR','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'TAMA¥OEMPR'"

            Case Enum_Tablas_Random.Cargos
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "CARGOS"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'CARGOS'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'CARGOS'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- CARGOS" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'CARGOS','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'CARGOS'"

            Case Enum_Tablas_Random.Areasactiv
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "AREASACTIV"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'AREASACTIV'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'AREASACTIV'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- AREAS ACTIVIDAD ENTIDADES" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'AREASACTIV','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'AREASACTIV'"

            Case Enum_Tablas_Random.Transporte
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "TRANSPORTE"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'TRANSPORTE'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'TRANSPORTE'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- TRANSPORTE" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'TRANSPORTE','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'TRANSPORTE'"

            Case Enum_Tablas_Random.Maquina_ST
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "MAQUINA_ST"
                _Arrgeglo(2) = String.Empty
                '"Delete TABCARAC Where KOTABLA = 'ACCESORIOS_ST'" & vbCrLf & _
                '"Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                '"From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'ACCESORIOS_ST'"
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Categorias_ST
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "CATEGOR_ST"
                _Arrgeglo(2) = String.Empty
                '"Delete TABCARAC Where KOTABLA = 'CATEGOR_ST'" & vbCrLf & _
                '"Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                '"From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'CATEGOR_ST'"
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Modelos_ST
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "MODELOS_ST"
                _Arrgeglo(2) = String.Empty
                '"Delete TABCARAC Where KOTABLA = 'MODELOS_ST'" & vbCrLf & _
                '"Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                '"From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'MODELOS_ST'"
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Check_in_ST
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "CHECK_IN_ST"
                _Arrgeglo(2) = String.Empty
                '"Delete TABCARAC Where KOTABLA = 'CHECK_IN_ST'" & vbCrLf & _
                '"Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                '"From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'CHECK_IN_ST'"
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Accesorios_ST
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "ACCESORIOS_ST"
                _Arrgeglo(2) = String.Empty
                '"Delete TABCARAC Where KOTABLA = 'ACCESORIOS_ST'" & vbCrLf & _
                '"Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                '"From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'ACCESORIOS_ST'"
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Estado_Entrega_ST
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "ES_ENTREGA_ST"
                _Arrgeglo(2) = String.Empty
                '"Delete TABCARAC Where KOTABLA = 'ACCESORIOS_ST'" & vbCrLf & _
                '"Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                '"From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'ACCESORIOS_ST'"
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Vehiculo_Tipo
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "VEHIC_TIPO"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Vehiculo_Marca
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "VEHIC_MARCA"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Vehiculo_Modelo
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "VEHIC_MODELO"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Licencia_Conducir
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "LICENCIA_COND"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Feriados_Anuales
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "FERIADOS"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Sql_Command
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "SQL_COMMAND"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Reclamos_Tipos
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "SIS_RECLAMOS_TIPO"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Reclamos_Sub_Tipos
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "SIS_RECLAMOS_SUBTIPO"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Reclamos_Accion
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "SIS_RECLAMOS_ACCION"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Reclamos_Preguntas
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "SIS_RECLAMOS_PREG"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Reclamos_Estados
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "SIS_RECLAMOS_ESTADO"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Reclamos_Sub_Estados
                _Arrgeglo(0) = 20
                _Arrgeglo(1) = "SIS_RECLAMOS_SUBESTADOS"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50

            Case Enum_Tablas_Random.Despachos_Tipo_Venta
                _Arrgeglo(0) = 5
                _Arrgeglo(1) = "SIS_DESPACHO_TIPO_VENTA"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50
            Case Enum_Tablas_Random.Despachos_Tipo_Envio
                _Arrgeglo(0) = 2
                _Arrgeglo(1) = "SIS_DESPACHO_TIPO_ENVIO"
                _Arrgeglo(2) = String.Empty
                _Arrgeglo(3) = 50

            Case Enum_Tablas_Random.ZonaProducto
                _Arrgeglo(0) = 10
                _Arrgeglo(1) = "ZONAPRODUC"
                _Arrgeglo(2) = "Delete TABCARAC Where KOTABLA = 'ZONAPRODUC'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'ZONAPRODUC'"
                _Arrgeglo(3) = 50

                Consulta_sql = "-- CLASIFICACION LIBRE" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                               "SELECT 'ZONAPRODUC','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                               "WHERE KOTABLA = 'ZONAPRODUC'"

        End Select

        If Not String.IsNullOrEmpty(Consulta_sql) Then

            Dim _Sql_Class As New Class_SQL(Cadena_ConexionSQL_Server)


            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                           "Where Tabla = '" & _Arrgeglo(1) & "'" & vbCrLf & vbCrLf &
                           Consulta_sql

            _Sql_Class.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If


        Return _Arrgeglo

        '---------------------------------------------------------------------------------------------------------------------

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla In ('ARTICULO','COLOR','MEDIDA','MARCAS','RUBROS','CLALIBPR','CLASLIBRE'," &
                       "'ACTIVIDADE','TIPOENTIDA','TAMA¥OEMPR','CARGOS','AREASACTIV','TRANSPORTE','ZONAPRODUC')" & vbCrLf &
                       vbCrLf &
                       "-- ARTICULO" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                       "SELECT 'ARTICULO','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                       "WHERE KOTABLA = 'ARTICULO'" &
                       vbCrLf &
                       vbCrLf &
                       "-- COLOR" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                       "SELECT 'COLOR','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                       "WHERE KOTABLA = 'COLOR'" &
                       vbCrLf &
                       vbCrLf &
                       "-- MEDIDA" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf &
                       "SELECT 'MEDIDA','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " &
                       "WHERE KOTABLA = 'MEDIDA'" &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf &
                       vbCrLf






    End Function

    Private Sub Btn_Seleccionar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Seleccionar.Click
        _Seleccion = True
        Me.Close()
    End Sub

    Public Property Pro_RowFilaSeleccionada() As DataRow
        Get
            Return _RowFilaSeleccionada
        End Get
        Set(value As DataRow)
            _RowFilaSeleccionada = value
        End Set
    End Property

    Public Property Pro_TblFilasSeleccionadas() As DataTable
        Get
            Return _dv.Table
        End Get
        Set(value As DataTable)
            _TblFilasSeleccionadas = value
        End Set
    End Property

    Public Property Pro_Seleccion_Realizada() As Boolean
        Get
            Return _Seleccion
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Pro_Cerrar_al_grabar() As Boolean
        Get
            Return _Cerrar_al_grabar
        End Get
        Set(value As Boolean)
            _Cerrar_al_grabar = value
        End Set
    End Property

    Public Property Pro_Padre_Tabla()
        Get
            Return _Padre_Tabla
        End Get
        Set(value)
            _Padre_Tabla = value
        End Set
    End Property

    Public Property Pro_Padre_CodigoTabla()
        Get
            Return _Padre_CodigoTabla
        End Get
        Set(value)
            _Padre_CodigoTabla = value
        End Set
    End Property

    Private Sub Grilla_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Function Fx_Permiso() As String

        Dim _Permiso As String

        Select Case _Tabla
            Case Enum_Tablas_Random.Accesorios_ST
                _Permiso = "Tbl00037"
            Case Enum_Tablas_Random.Estado_Entrega_ST
                _Permiso = "Tbl00038"
            Case Enum_Tablas_Random.Categorias_ST
                _Permiso = "Tbl00024"
            Case Enum_Tablas_Random.Check_in_ST
                _Permiso = "Tbl00039"
            Case Enum_Tablas_Random.Maquina_ST
                _Permiso = "Tbl00040"
            Case Enum_Tablas_Random.Modelos_ST
                _Permiso = "Tbl00023"

            Case Enum_Tablas_Random.Actividade
                _Permiso = "Tbl00020"
            Case Enum_Tablas_Random.Areasactiv
                _Permiso = "Tbl00014"
            Case Enum_Tablas_Random.Articulo
                _Permiso = ""
            Case Enum_Tablas_Random.Cargos
                _Permiso = "Tbl00019"
            Case Enum_Tablas_Random.Tamanoempr
                _Permiso = "Tbl00013"
            Case Enum_Tablas_Random.Tipoentidad
                _Permiso = "Tbl00015"
            Case Enum_Tablas_Random.Transporte
                _Permiso = ""
            Case Enum_Tablas_Random.Claslibre
                _Permiso = "Tbl00020"

            Case Enum_Tablas_Random.Super_Familia
                _Permiso = "Tbl00041"
            Case Enum_Tablas_Random.Familia
                _Permiso = "Tbl00042"
            Case Enum_Tablas_Random.Sub_Familia
                _Permiso = "Tbl00043"
            Case Enum_Tablas_Random.Feriados_Anuales
                _Permiso = "Tbl00036"
            Case Enum_Tablas_Random.Licencia_Conducir
                _Permiso = ""
            Case Enum_Tablas_Random.Marcas
                _Permiso = "Tbl00016"

            Case Enum_Tablas_Random.Color
                _Permiso = ""
            Case Enum_Tablas_Random.Medida
                _Permiso = ""
            Case Enum_Tablas_Random.Modelo
                _Permiso = ""
            Case Enum_Tablas_Random.Rubros
                _Permiso = "Tbl00017"
            Case Enum_Tablas_Random.Sql_Command
                _Permiso = ""

            Case Enum_Tablas_Random.Vehiculo_Marca
                _Permiso = "Tbl00026"
            Case Enum_Tablas_Random.Vehiculo_Modelo
                _Permiso = "Tbl00027"
            Case Enum_Tablas_Random.Vehiculo_Tipo
                _Permiso = "Tbl00025"




        End Select


    End Function


End Class
