Imports System.Data.SqlClient
Imports DevComponents.DotNetBar


Public Class Frm_St_RecetaCrear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Rec As Integer
    Dim _CodReceta As String
    Dim _Row_Receta As DataRow
    Dim _Tbl_Operaciones As DataTable

    Dim _Nuevo As Boolean
    Dim _Editar As Boolean

    Public Property Grabar As Boolean
    Public Property Eliminar As Boolean

    Public Property Row_Receta As DataRow
        Get
            Return _Row_Receta
        End Get
        Set(value As DataRow)
            _Row_Receta = value
        End Set
    End Property

    Public Sub New(_CodReceta As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodReceta = _CodReceta

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Recetas_Enc" & vbCrLf &
                       "Where CodReceta = '" & _CodReceta & "'"
        _Row_Receta = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If IsNothing(_Row_Receta) Then
            _Nuevo = True
        Else
            _Editar = True
            _Id_Rec = _Row_Receta.Item("Id")
        End If

    End Sub

    Private Sub Frm_St_RecetaCrear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_CodReceta.Enabled = _Nuevo

        If _Nuevo Then
            ActiveControl = Txt_CodReceta
            Sw_Activo.Value = True
        End If

        If _Editar Then
            Sw_Activo.Value = _Row_Receta.Item("Activo")
            Txt_CodReceta.Text = _CodReceta
            Txt_CodReceta.Enabled = False
            Txt_Descripcion.Text = _Row_Receta.Item("Descripcion")
            ActiveControl = Txt_Descripcion
        End If

        Sb_Actualizar_Grilla()

        Sb_Agregar_Operacion(_Tbl_Operaciones, _Id_Rec, "", _CodReceta, "", "", False, 0, 0, False)

        'AddHandler Grilla.CellEnter, AddressOf Grilla_CellEnter
        AddHandler Grilla.CellBeginEdit, AddressOf Grilla_CellBeginEdit
        AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit
        AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
        AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Cast(0 As Bit) As Nuevo_Item,Rec.*,Isnull(Ope.Descripcion,'') As Descripcion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_Recetas_Ope Rec" & vbCrLf &
                       "Left Join  Zw_St_OT_Operaciones Ope On Ope.Operacion = Rec.Operacion" & vbCrLf &
                       "Where Rec.Id_Rec = " & _Id_Rec & vbCrLf &
                       "Order By Orden"
        _Tbl_Operaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Operaciones

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Operacion").Visible = True
            .Columns("Operacion").HeaderText = "Operación"
            .Columns("Operacion").Width = 100
            .Columns("Operacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Cantidad").Visible = True
            '.Columns("Cantidad").HeaderText = "Cant."
            '.Columns("Cantidad").Width = 70
            '.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            '.Columns("Cantidad").DisplayIndex = _DisplayIndex
            ''.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '_DisplayIndex += 1

            .Columns("Precio").Visible = True
            .Columns("Precio").HeaderText = "Precio"
            .Columns("Precio").Width = 50
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Precio").DisplayIndex = _DisplayIndex
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            _DisplayIndex += 1

            .Columns("CantMayor1").Visible = True
            .Columns("CantMayor1").HeaderText = "M1"
            .Columns("CantMayor1").ToolTipText = "La Cantidad puede ser mayor que 1"
            .Columns("CantMayor1").Width = 30
            .Columns("CantMayor1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Externa").Visible = True
            .Columns("Externa").HeaderText = "Ext."
            .Columns("Externa").ToolTipText = "Operación externa"
            .Columns("Externa").Width = 40
            .Columns("Externa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Agregar_Operacion(ByRef _Tbl As DataTable,
                             _Id_Rec As Integer,
                             _Codigo As String,
                             _CodReceta As String,
                             _Operacion As String,
                             _Descripcion As String,
                             _CantMayor1 As Boolean,
                             _Cantidad As Integer,
                             _Precio As Double,
                             _Externa As Boolean)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id_Rec") = _Id_Rec
            .Item("Nuevo_Item") = True
            .Item("CodReceta") = _CodReceta
            .Item("Operacion") = _Operacion
            .Item("Descripcion") = _Descripcion
            .Item("CantMayor1") = _CantMayor1
            .Item("Cantidad") = _Cantidad
            .Item("Precio") = _Precio
            .Item("Orden") = 0
            .Item("Externa") = _Externa

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter

                    If _Cabeza = "Operacion" Or _Cabeza = "Cantidad" Or _Cabeza = "Precio" Then

                        If _Nuevo_Item Then
                            If _Cabeza = "Cantidad" Or _Cabeza = "Precio" Then
                                Return
                                'Grilla.Columns(_Cabeza).ReadOnly = False
                            End If
                        Else
                            If _Cabeza = "Operacion" Then
                                Return
                                'Grilla.Columns(_Cabeza).ReadOnly = False
                            End If
                        End If

                        'Grilla.Columns(_Cabeza).ReadOnly = False
                        'SendKeys.Send("{F2}")
                        'e.Handled = True
                        'Grilla.BeginEdit(True)
                        Grilla.Columns(_Cabeza).ReadOnly = False
                        Grilla.BeginEdit(True)

                        If Not IsNothing(e) Then
                            e.SuppressKeyPress = False
                            e.Handled = True
                        End If

                    End If

                Case Keys.Delete

                    If Not _Nuevo_Item Then '_Fila.IsNewRow Then

                        If (_Fila.Cells("Cantidad").Value Is DBNull.Value) Then
                            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                            Grilla.Refresh()
                        Else
                            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                                                     "Eliminar fila",
                                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                                Grilla.Refresh()

                                If Grilla.Rows.Count = 0 Then
                                    Grilla.AllowUserToAddRows = True
                                End If

                            End If
                        End If

                    End If

                Case Else
                    Grilla.Columns(_Cabeza).ReadOnly = True
            End Select

        Catch ex As Exception

        Finally
            Bar2.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Bar2.Enabled = False

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Operacion As String = _Fila.Cells("Operacion").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        If _Cabeza = "Operacion" Then
            If _Nuevo_Item Then
                If Not String.IsNullOrEmpty(_Descripcion) Then
                    e.Cancel = True
                End If
            Else
                e.Cancel = True
            End If
        ElseIf _Cabeza = "Cantidad" Then
            If _Fila.IsNewRow Then
                If String.IsNullOrEmpty(_Descripcion) Then
                    e.Cancel = True
                End If
            End If

        End If

    End Sub

    Private Sub Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Operacion As String = _Fila.Cells("Operacion").Value
            'Dim _Descripcion As String

            'Dim _RowOperacion As DataRow

            If _Cabeza = "Operacion" Then

                If (_Fila.Cells("Operacion").Value Is DBNull.Value) Then
                    _Fila.Cells("Operacion").Value = String.Empty
                    Grilla.EndEdit()
                End If

                Fx_Agregar_Operacion(_Fila, _Operacion)

                'If _Operacion Is Nothing Then Return

                '_RowOperacion = Fx_Buscar_Operacion(_Operacion)

                '_Fila.Cells("Operacion").Value = String.Empty

                'If Not (_RowOperacion Is Nothing) Then

                '    For Each _Fl As DataRow In _Tbl_Operaciones.Rows

                '        _Operacion = _RowOperacion.Item("Operacion").ToString.Trim
                '        _Descripcion = _RowOperacion.Item("Descripcion").ToString.Trim

                '        If _Fl.Item("Operacion").ToString.Trim = _Operacion Then
                '            Throw New System.Exception("La Operación: " & _Fl.Item("Operacion").ToString.Trim & "-" & _Descripcion & vbCrLf &
                '                                       "Ya esta en la lista")
                '        End If
                '    Next

                '    _Fila.Cells("Nuevo_Item").Value = False
                '    _Fila.Cells("Operacion").Value = _RowOperacion.Item("Operacion")
                '    _Fila.Cells("Descripcion").Value = _RowOperacion.Item("Descripcion")
                '    _Fila.Cells("Cantidad").Value = 0
                '    _Fila.Cells("CantMayor1").Value = _RowOperacion.Item("CantMayor1")
                '    _Fila.Cells("Externa").Value = _RowOperacion.Item("Externa")

                '    Sb_Agregar_Operacion(_Tbl_Operaciones, _Id_Rec, "", _CodReceta, "", "", False, 0, 0, False)

                'End If

            ElseIf _Cabeza = "Cantidad" Then

                If Grilla.Rows.Count - 1 = _Fila.Index Then
                    SendKeys.Send("{LEFT}")
                    SendKeys.Send("{LEFT}")
                    SendKeys.Send("{LEFT}")
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Bar2.Enabled = True
            Me.Refresh()
        End Try

    End Sub

    Function Fx_Agregar_Operacion(_Fila As DataGridViewRow, _Operacion As String) As Boolean

        Dim _Descripcion As String

        If _Operacion Is Nothing Then Return False

        Dim _RowOperacion As DataRow = Fx_Buscar_Operacion(_Operacion)

        _Fila.Cells("Operacion").Value = String.Empty

        If Not (_RowOperacion Is Nothing) Then

            For Each _Fl As DataRow In _Tbl_Operaciones.Rows

                _Operacion = _RowOperacion.Item("Operacion").ToString.Trim
                _Descripcion = _RowOperacion.Item("Descripcion").ToString.Trim

                If _Fl.Item("Operacion").ToString.Trim = _Operacion Then
                    If MessageBoxEx.Show(Me, "La Operación: " & _Fl.Item("Operacion").ToString.Trim & "-" & _Descripcion & vbCrLf &
                                               "Ya esta en la lista" & vbCrLf & vbCrLf &
                                               "¿Desea agregarla nuevamente?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                        Return False
                    End If
                End If
            Next

            _Fila.Cells("Nuevo_Item").Value = False
            _Fila.Cells("Operacion").Value = _RowOperacion.Item("Operacion")
            _Fila.Cells("Descripcion").Value = _RowOperacion.Item("Descripcion")
            _Fila.Cells("Cantidad").Value = 0
            _Fila.Cells("CantMayor1").Value = _RowOperacion.Item("CantMayor1")
            _Fila.Cells("Externa").Value = _RowOperacion.Item("Externa")

            Sb_Agregar_Operacion(_Tbl_Operaciones, _Id_Rec, "", _CodReceta, "", "", False, 0, 0, False)

        End If

        Return True

    End Function

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim validar As TextBox = CType(e.Control, TextBox)

        If _Cabeza = "Cantidad" Or _Cabeza = "Precio" Then
            AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        Else
            RemoveHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_CodReceta.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el código de la receta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CodReceta.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta la descripción de la receta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        If Grilla.RowCount = 1 And Grilla.Rows(0).Cells("Nuevo_Item").Value Then
            MessageBoxEx.Show(Me, "Debe agregar alguna operación a la receta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        For Each _Flop As DataRow In _Tbl_Operaciones.Rows

            Dim Estado As DataRowState = _Flop.RowState

            If Not Estado = DataRowState.Deleted Then

                If Not _Flop.Item("Nuevo_Item") And _Flop.Item("Precio") = 0 Then
                    MessageBoxEx.Show(Me, "No puede haber operaciones con precio igual a cero" & vbCrLf &
                                      "Operación: " & _Flop.Item("Operacion").ToString.Trim & "-" & _Flop.Item("Descripcion").ToString.Trim,
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

            End If

        Next

        _Id_Rec = Fx_Grabar(_Id_Rec)

        If CBool(_Id_Rec) Then
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Recetas_Enc" & vbCrLf &
                           "Where Id = " & _Id_Rec
            _Row_Receta = _Sql.Fx_Get_DataRow(Consulta_sql)
            Grabar = True
            Me.Close()
        End If

    End Sub

    Function Fx_Grabar(_Id_Rec As Integer) As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _CodReceta As String = Txt_CodReceta.Text.Trim
        Dim _Descripcion As String = Txt_Descripcion.Text.Trim
        Dim _Activo As Integer = Convert.ToInt32(Sw_Activo.Value)

        Dim _Cn As New SqlConnection

        Try

            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            ' INSERTAR ENCABEZADO DE DOCUMENTO

            If _Nuevo Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Recetas_Enc (Empresa,CodReceta,Descripcion,Activo) Values " &
                               "('" & ModEmpresa & "','" & _CodReceta & "','" & _Descripcion & "'," & _Activo & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)
                Comando.Transaction = myTrans
                Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Id_Rec = dfd1("Identity")
                End While
                dfd1.Close()

            End If

            If _Editar Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Recetas_Enc Set Descripcion = '" & _Descripcion & "',Activo = " & _Activo & vbCrLf &
                               "Where Id = " & _Id_Rec
                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Recetas_Ope Where Id_Rec = " & _Id_Rec
                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            ' ----------------------------------------------------- DETALLE PRODUCTOS ------------------------------------------------

            Dim _Orden = 0

            For Each _FlOp As DataRow In _Tbl_Operaciones.Rows

                Dim Estado As DataRowState = _FlOp.RowState

                If Not Estado = DataRowState.Deleted Then

                    Dim _Operacion As String = _FlOp.Item("Operacion")
                    Dim _Cantidad As String = De_Txt_a_Num_01(_FlOp.Item("Cantidad"), 5)
                    Dim _Precio As String = De_Txt_a_Num_01(_FlOp.Item("Precio"), 5)
                    Dim _CantMayor1 As Integer = Convert.ToInt32(_FlOp.Item("CantMayor1"))
                    Dim _Externa As Integer = Convert.ToInt32(_FlOp.Item("Externa"))
                    Dim _Nuevo_Item As Boolean = _FlOp.Item("Nuevo_Item")

                    If Not _Nuevo_Item Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Recetas_Ope (Id_Rec,CodReceta,Operacion,Orden,Cantidad,Precio,CantMayor1,Externa) Values " &
                                   "(" & _Id_Rec & ",'" & _CodReceta & "','" & _Operacion & "'," & _Orden & "," & _Cantidad & "," & _Precio & "," & _CantMayor1 & "," & _Externa & ")"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        'Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)
                        'Comando.Transaction = myTrans
                        'Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                        'While dfd1.Read()
                        '    _NewSemilla = dfd1("Identity")
                        'End While
                        'dfd1.Close()

                    End If

                    _Orden += 1

                End If

            Next

            '**********************************'**********************************

            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

        Catch ex As Exception
            '
            'Consulta_sql = "ROLLBACK TRANSACTION"
            'Ej_consulta_IDU(Consulta_sql, cn1)
            MsgBox(ex.Message)
            myTrans.Rollback()

        End Try

        Return _Id_Rec

    End Function

    Function Fx_Buscar_Operacion(_CodOperacion As String) As DataRow

        Dim _FiltroOperaciones As String
        Dim _RowOperacion As DataRow

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones" & vbCrLf &
                       "Where Operacion = '" & _CodOperacion & "'"
        _RowOperacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowOperacion) Then
            Return _RowOperacion
        End If

        _FiltroOperaciones = Generar_Filtro_IN(_Tbl_Operaciones, "", "Operacion", False, False, "'")
        _FiltroOperaciones = Replace(_FiltroOperaciones, "''", "")

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
        Fm.Pro_Tabla = _Global_BaseBk & " Zw_St_OT_Operaciones"
        Fm.Pro_Campo = "Operacion"
        Fm.Pro_Descripcion = "Descripcion"
        Fm.Text = "OPERACIONES PARA REPARACIO EN SERVICIO TECNICO"
        'If _FiltroOperaciones.Contains("'") Then
        '    Fm.Pro_Sql_Filtro_Condicion_Extra = "And Operacion Not In " & _FiltroOperaciones & vbCrLf
        'End If
        Fm.Pro_Seleccionar_Solo_Uno = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones" & vbCrLf &
                           "Where Operacion = '" & Fm.Pro_Tbl_Filtro.Rows(0).Item("Codigo") & "'"
            _RowOperacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        Return _RowOperacion

    End Function

    Private Sub Btn_Agregar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Producto.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.Rows.Count - 1)

        Fx_Agregar_Operacion(_Fila, "")

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & " Zw_St_OT_OpeXServ", "CodReceta  = '" & Txt_CodReceta.Text & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Esta receta esta asociada a (" & _Reg & ") servicio(s)" & vbCrLf &
                              "No es posible eliminarla, debe dejarla inactiva", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta receta?", "Eliminar receta",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Recetas_Enc Where Id = " & _Id_Rec & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_St_OT_Recetas_Ope Where Id = " & _Id_Rec & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod Where Id = " & _Id_Rec

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                Eliminar = True
                Me.Close()
            End If

        End If

    End Sub
End Class
