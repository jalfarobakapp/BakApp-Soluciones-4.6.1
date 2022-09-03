Imports DevComponents.DotNetBar

Public Class Frm_Dimensiones_Pr

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Row_Producto As DataRow
    Dim _Grabar As Boolean
    Dim _Nuevo As Boolean
    Dim _Tbl_Productos As DataTable
    Dim _Editar As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(_Codigo As String, _Nuevo As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigo = _Codigo
        Me._Nuevo = _Nuevo

        Consulta_sql = "Select MAEPR.*,Isnull(Zdm.Peso,0) As Peso,Isnull(Zdm.Alto,0) As Alto,Isnull(Zdm.Largo,0) As Largo,Isnull(Zdm.Ancho,0) As Ancho
                        From MAEPR 
                        Left Join " & _Global_BaseBk & "Zw_Prod_Dimensiones Zdm On KOPR = Zdm.Codigo 
                        Where KOPR = '" & _Codigo & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Dimensiones_Pr_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Txt_Peso.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Largo.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Ancho.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Alto.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        Txt_Peso.Text = _Row_Producto.Item("Peso")
        Txt_Largo.Text = _Row_Producto.Item("Largo")
        Txt_Ancho.Text = _Row_Producto.Item("Ancho")
        Txt_Alto.Text = _Row_Producto.Item("Alto")

        Me.Text = _Codigo.Trim & " - " & _Row_Producto.Item("NOKOPR").ToString.Trim

        Btn_Duplicar_Dimensiones.Visible = Not _Nuevo

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Not _Nuevo Then
            If Not Fx_Tiene_Permiso(Me, "Prod065") Then
                Txt_Peso.Text = _Row_Producto.Item("Peso")
                Txt_Largo.Text = _Row_Producto.Item("Largo")
                Txt_Ancho.Text = _Row_Producto.Item("Ancho")
                Txt_Alto.Text = _Row_Producto.Item("Alto")
                Return
            End If
        End If

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Dimensiones Where Codigo = '" & _Codigo & "'"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Dimensiones (Codigo,Peso,Alto,Largo,Ancho) Values " &
                                    "('" & _Codigo & "'," &
                                    De_Num_a_Tx_01(Txt_Peso.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Alto.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Largo.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Ancho.Text, False, 5) & ")"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Grabar = True
                If Not _Nuevo Then
                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Frm_Dimensiones_Pr_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Duplicar_Dimensiones_Click(sender As Object, e As EventArgs) Handles Btn_Duplicar_Dimensiones.Click

        If Not Fx_Tiene_Permiso(Me, "Prod066") Then
            Return
        End If

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro

            Consulta_sql = String.Empty

            If _Filtrar.Pro_Filtro_Todas Then

                If MessageBoxEx.Show(Me, "¿Esta seguro de cargar todos los productos con esta clasificación?",
                                     "Cargar todos los productos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                    Return
                End If

                _Tbl_Productos = Nothing
                Consulta_sql = "Truncate Table " & _Global_BaseBk & "Zw_Prod_Dimensiones" & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_Prod_Dimensiones (Codigo,Peso,Alto,Largo,Ancho)  
                                Select KOPR," & De_Num_a_Tx_01(Txt_Peso.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Alto.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Largo.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Ancho.Text, False, 5) & vbCrLf &
                                    "From MAEPR Where TIPR = 'FPN'"
            Else

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "Chk", "Codigo", False, True, "'")

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Dimensiones Where Codigo In " & _Filtro_Productos & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_Prod_Dimensiones (Codigo,Peso,Alto,Largo,Ancho)  
                                Select KOPR," & De_Num_a_Tx_01(Txt_Peso.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Alto.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Largo.Text, False, 5) & "," &
                                    De_Num_a_Tx_01(Txt_Ancho.Text, False, 5) & vbCrLf &
                                    "From MAEPR Where KOPR In " & _Filtro_Productos

            End If

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    MessageBoxEx.Show(Me, "Datos actualizados correcatmente", "Copiar dimensiones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        End If

    End Sub
End Class
