Imports DevComponents.DotNetBar

Public Class Frm_OperacionesXServicio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CodReceta As String
    Dim _RowReceta As DataRow
    Dim _Tbl_Operaciones As DataTable
    Public Property TblOperaciones As DataTable
        Get
            Return _Tbl_Operaciones
        End Get
        Set(value As DataTable)
            _Tbl_Operaciones = New DataTable
            _Tbl_Operaciones = value
        End Set
    End Property

    Public Property RowReceta As DataRow
        Get
            Return _RowReceta
        End Get
        Set(value As DataRow)
            _RowReceta = value
        End Set
    End Property

    Public Property SoloLectura As Boolean
    Public Property Grabar As Boolean

    Public Sub New(_CodReceta As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._CodReceta = _CodReceta

        Consulta_sql = "Select Rec.*" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_Recetas_Enc Rec" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod Prod On Rec.CodReceta = Prod.CodReceta And Rec.Activo = 1" & vbCrLf &
                       "Where Rec.CodReceta = '" & _CodReceta & "'"
        _RowReceta = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Serv.Id,Serv.Id_Ot,Serv.Semilla,Serv.Codigo,Isnull(Oper.Descripcion,'') As Descripcion," & vbCrLf &
                       "Serv.CodReceta,Serv.Operacion,Serv.Orden,Serv.CantMayor1,Serv.Cantidad,Serv.CantidadRealizada,Serv.Precio," &
                       "Serv.Total,Serv.Realizado,Serv.Externa,Cast(1 As Bit) As Chk" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_OpeXServ Serv" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On Serv.Operacion = Oper.Operacion" & vbCrLf &
                       "Where CodReceta = '" & _CodReceta & "'"
        _Tbl_Operaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        'Consulta_sql = "SELECT CAST(0 As Bit) As Chk, ReOpe.Id, ReOpe.Id_Rec,ReOpe.CodReceta,ReOpe.Operacion,Oper.Descripcion,Orden,Oper.Valor" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_St_OT_Recetas_Ope ReOpe" & vbCrLf &
        '               "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On ReOpe.Operacion = Oper.Operacion" & vbCrLf &
        '               "Where CodReceta = '" & _CodReceta & "'"
        '_TblOperaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_OperacionesXServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If IsNothing(_RowReceta) Then
            Txt_Receta.Text = "SIN RECETA..."
        Else
            Txt_Receta.Text = _RowReceta.Item("CodReceta").ToString.Trim & "-" & _RowReceta.Item("Descripcion").ToString.Trim
        End If

        Sb_Actualizar_Grilla()

        Me.ActiveControl = Bar2

        Btn_Grabar.Enabled = Not SoloLectura
        Btn_Agregar_Producto.Enabled = Not SoloLectura

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_Operaciones

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 30
            .Columns("Chk").DisplayIndex = _DisplayIndex
            .Columns("Chk").ReadOnly = SoloLectura ' False
            _DisplayIndex += 1

            .Columns("Operacion").Visible = True
            .Columns("Operacion").HeaderText = "Código"
            .Columns("Operacion").Width = 60
            .Columns("Operacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 80
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Tickeados = False
        For Each _Fila As DataRow In _Tbl_Operaciones.Rows
            If _Fila.Item("Chk") Then
                _Tickeados = True
                Exit For
            End If
        Next

        If Not _Tickeados Then
            MessageBoxEx.Show(Me, "Debe seleccionar alguna operación para realizar el presupuesto", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Cantidad As Integer = _Fila.Cells("Cantidad").Value
        Dim _CantMayor1 As Boolean = _Fila.Cells("CantMayor1").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        If _Cabeza = "Chk" Then

            If Not _Fila.Cells("Chk").Value Then
                _Fila.Cells("Cantidad").Value = 0
                Return
            End If

            _Fila.Cells("Cantidad").Value = 1

            If _CantMayor1 Then

                Dim _Aceptar As Boolean

                _Aceptar = InputBox_Bk(Me, "Debe indicar la cantidad a reparar", _Descripcion, _Cantidad,
                                           False, _Tipo_Mayus_Minus.Normal,, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

                If _Aceptar Then
                    _Fila.Cells("Cantidad").Value = _Cantidad
                Else
                    _Fila.Cells("Chk").Value = False
                    _Fila.Cells("Cantidad").Value = 0
                End If

            End If

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Cantidad As Integer = _Fila.Cells("Cantidad").Value
        Dim _CantMayor1 As Boolean = _Fila.Cells("CantMayor1").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        If _Cabeza = "Cantidad" Then

            If Not _Fila.Cells("Chk").Value Then
                Return
            End If

            If _CantMayor1 Then

                If SoloLectura Then
                    MessageBoxEx.Show(Me, "Documento de solo lectura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Dim _Aceptar As Boolean

                _Aceptar = InputBox_Bk(Me, "Debe indicar la cantidad a reparar", _Descripcion, _Cantidad,
                                       False, _Tipo_Mayus_Minus.Normal,, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

                If _Aceptar Then
                    _Fila.Cells("Cantidad").Value = _Cantidad
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Agregar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Producto.Click
        Fx_Agregar_Operacion(Nothing, "")
    End Sub

    Private Sub Btn_Mnu_AsociarProductos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_AsociarProductos.Click
        Fx_Agregar_Operacion(Nothing, "")
    End Sub

    Function Fx_Agregar_Operacion(_Fila As DataGridViewRow, _Operacion As String) As Boolean

        If SoloLectura Then
            MessageBoxEx.Show(Me, "Documento de solo lectura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim _Descripcion As String

        If _Operacion Is Nothing Then Return False

        Dim _RowOperacion As DataRow = Fx_Buscar_Operacion(_Operacion)

        '_Fila.Cells("Operacion").Value = String.Empty

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

            Dim _Id_Rec As Integer

            If Not IsNothing(_RowReceta) Then _Id_Rec = _RowReceta.Item("Id")

            Sb_Agregar_Operacion(_Tbl_Operaciones,
                                 _Id_Rec, "",
                                 _CodReceta,
                                 _RowOperacion.Item("Operacion"),
                                 _RowOperacion.Item("Descripcion"),
                                 _RowOperacion.Item("CantMayor1"),
                                 1,
                                 _RowOperacion.Item("Precio"),
                                 _RowOperacion.Item("Externa"))

            _Fila = Grilla.Rows(Grilla.Rows.Count - 1)

            If _RowOperacion.Item("CantMayor1") Then

                Dim _Aceptar As Boolean
                Dim _Cantidad As Integer

                _Aceptar = InputBox_Bk(Me, "Debe indicar la cantidad a reparar", _RowOperacion.Item("Descripcion"), _Cantidad,
                                           False, _Tipo_Mayus_Minus.Normal,, True, _Tipo_Imagen.Texto,,
                                           _Tipo_Caracter.Solo_Numeros_Enteros, False)

                If _Aceptar Then
                    _Fila.Cells("Cantidad").Value = _Cantidad
                Else
                    _Fila.Cells("Chk").Value = False
                    _Fila.Cells("Cantidad").Value = 0
                End If

            End If

        End If

        Return True

    End Function

    Function Fx_Buscar_Operacion(_CodReceta As String) As DataRow

        Dim _Row_Operacion As DataRow

        Dim _Condicion As String

        If Not String.IsNullOrEmpty(_CodReceta) Then
            _Condicion = "Where CodReceta = '" & _CodReceta & "'"
        End If

        Dim Fm As New Frm_St_Operaciones
        Fm.ModoSeleccion = True
        Fm.ShowDialog(Me)
        _Row_Operacion = Fm.Row_Operacion
        Fm.Dispose()

        Return _Row_Operacion

    End Function

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

            Try
                .Item("Id_Rec") = _Id_Rec
            Catch ex As Exception

            End Try

            Try
                .Item("Semilla") = 0
                .Item("Id_Ot") = 0
                .Item("CantidadRealizada") = 0
                .Item("Codigo") = String.Empty
                .Item("Total") = _Precio
                .Item("Realizado") = False
            Catch ex As Exception

            End Try

            .Item("CodReceta") = _CodReceta
            .Item("Operacion") = _Operacion
            .Item("Descripcion") = _Descripcion
            .Item("CantMayor1") = _CantMayor1
            .Item("Cantidad") = _Cantidad
            .Item("Precio") = _Precio
            .Item("Orden") = 0
            .Item("Externa") = _Externa
            .Item("Chk") = True

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

End Class
