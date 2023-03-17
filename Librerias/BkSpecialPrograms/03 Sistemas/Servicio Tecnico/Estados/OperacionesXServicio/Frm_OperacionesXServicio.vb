Imports DevComponents.DotNetBar

Public Class Frm_OperacionesXServicio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CodReceta As String
    Dim _RowReceta As DataRow
    Dim _TblOperaciones As DataTable
    Public Property TblOperaciones As DataTable
        Get
            Return _TblOperaciones
        End Get
        Set(value As DataTable)
            _TblOperaciones = New DataTable
            _TblOperaciones = value
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

        Consulta_sql = "SELECT Serv.Id,Serv.Id_Ot,Serv.Semilla,Serv.Codigo,Isnull(Oper.Descripcion,'') As Descripcion," & vbCrLf &
               "Serv.CodReceta,Serv.Operacion,Serv.Orden,Serv.CantMayor1,Serv.Cantidad,Serv.CantidadRealizada,Serv.Precio,Serv.Total,Serv.Realizado,Cast(1 As Bit) As Chk" & vbCrLf &
               "FROM   " & _Global_BaseBk & "Zw_St_OT_OpeXServ Serv" & vbCrLf &
               "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On Serv.Operacion = Oper.Operacion" & vbCrLf &
               "Where CodReceta = '" & _CodReceta & "'"
        _TblOperaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        'Consulta_sql = "SELECT CAST(0 As Bit) As Chk, ReOpe.Id, ReOpe.Id_Rec,ReOpe.CodReceta,ReOpe.Operacion,Oper.Descripcion,Orden,Oper.Valor" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_St_OT_Recetas_Ope ReOpe" & vbCrLf &
        '               "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On ReOpe.Operacion = Oper.Operacion" & vbCrLf &
        '               "Where CodReceta = '" & _CodReceta & "'"
        '_TblOperaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Private Sub Frm_OperacionesXServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_Receta.Text = _RowReceta.Item("CodReceta").ToString.Trim & "-" & _RowReceta.Item("Descripcion").ToString.Trim

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _TblOperaciones

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 30
            .Columns("Chk").DisplayIndex = _DisplayIndex
            .Columns("Chk").ReadOnly = False
            _DisplayIndex += 1

            .Columns("Operacion").Visible = True
            .Columns("Operacion").HeaderText = "Código"
            .Columns("Operacion").Width = 100
            .Columns("Operacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 320
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 80
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            '.Columns("Cantidad").ReadOnly = False
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Tickeados = False
        For Each _Fila As DataRow In _TblOperaciones.Rows
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

                Dim _Aceptar As Boolean

                _Aceptar = InputBox_Bk(Me, "Debe indicar la cantidad a reparar", _Descripcion, _Cantidad,
                                       False, _Tipo_Mayus_Minus.Normal,, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

                If _Aceptar Then
                    _Fila.Cells("Cantidad").Value = _Cantidad
                End If

            End If

        End If

    End Sub

End Class
