Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Tipos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Area As Integer
    Dim _Row_Area As DataRow
    Dim _Tbl_Tipos As DataTable

    Public Sub New(_Id_Area As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Area = _Id_Area
        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Areas Where Id = " & _Id_Area
        _Row_Area = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla_Tipos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Tickets_Tipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Area.Text = "AREA: " & _Row_Area.Item("AREA")

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Tipos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        'Dim _Condicion As String = String.Empty

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        'If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
        '_Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        'End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos" & vbCrLf &
                       "Where Id_Area = " & _Id_Area
        _Tbl_Tipos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl_Tipos

            OcultarEncabezadoGrilla(Grilla_Tipos)

            Dim _DisplayIndex = 0

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo de requerimiento"
            .Columns("Tipo").Width = 340
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ExigeProducto").Visible = True
            .Columns("ExigeProducto").HeaderText = "Exige producto"
            .Columns("ExigeProducto").ToolTipText = "Si esta tickeado, el Ticket exgira la incorporación de un producto para la gestión"
            .Columns("ExigeProducto").Width = 110
            .Columns("ExigeProducto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ''.Columns("Dias").Visible = True
            ''.Columns("Dias").HeaderText = "Días expira."
            ''.Columns("Dias").ToolTipText = "Días que faltan para que termine la oferta"
            ''.Columns("Dias").Width = 70
            ''.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ''.Columns("Dias").DefaultCellStyle.Format = "###,##0.##"
            ''.Columns("Dias").DisplayIndex = _DisplayIndex
            ''_DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_CrearTipo_Click(sender As Object, e As EventArgs) Handles Btn_CrearTipo.Click

        Dim _Aceptar As Boolean
        Dim _Tipo As String
        Dim _Chk As New Controls.CheckBoxX

        _Chk.Checked = False
        _Chk.Text = "EXIGE INCORPORACION DE PRODUCTO"
        _Chk.Visible = True

        _Aceptar = InputBox_Bk(Me, "Ingrese el nombre del tipo de requerimiento",
                               "Crear Tipo", _Tipo, False, _Tipo_Mayus_Minus.Mayusculas, 50, True,,,,,, _Chk)

        If Not _Aceptar Then
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tipos", "Id_Area = " & _Id_Area & " And Tipo = '" & _Tipo & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "El Tipo de requerimiento ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_CrearTipo_Click(Nothing, Nothing)
            Return
        End If

        Dim _Id_Tipo As Integer

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tipos (Id_Area,Tipo,ExigeProducto) Values " &
                       "(" & _Id_Area & ",'" & _Tipo.Trim & "'," & Convert.ToInt32(_Chk.Checked) & ")"
        If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Tipo) Then

            Me.Sb_Actualizar_Grilla()
            BuscarDatoEnGrilla(_Tipo, "Tipo", Grilla_Tipos)

        End If

    End Sub

    Private Sub Btn_Mnu_EditarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarTipo.Click

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow

        Dim _Id_Tipo As Integer = _Fila.Cells("Id").Value
        Dim _Tipo As String = _Fila.Cells("Tipo").Value
        Dim _Tipo_Old As String = _Fila.Cells("ExigeProducto").Value

        Dim _Chk As New Controls.CheckBoxX

        _Chk.Checked = _Fila.Cells("Tipo").Value
        _Chk.Text = "EXIGE INCORPORACION DE PRODUCTO"
        _Chk.Visible = True

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Ingrese el nombre del Tipo de requerimiento", "Editar nombre de Tipo de requerimiento", _Tipo, False,
                               _Tipo_Mayus_Minus.Mayusculas, 50, True)

        If Not _Aceptar Then
            Return
        End If

        If _Tipo.Trim = _Tipo_Old.Trim Then
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo = '" & _Tipo & "' And Id <> " & _Id_Tipo)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Al nombre del Tipo de requerimiento ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Mnu_EditarTipo_Click(Nothing, Nothing)
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tipos Set Tipo = '" & _Tipo.Trim & "' Where Id = " & _Id_Tipo
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            _Fila.Cells("Area").Value = _Tipo
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_Mnu_EliminarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EliminarTipo.Click

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Confirma eliminar este Tipo de requerimiento?", "Eliminar tipo de requerimiento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Tipos.Rows.Remove(_Fila)
        End If

    End Sub

End Class
