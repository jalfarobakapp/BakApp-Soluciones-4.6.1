Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Seleccionar_1_Regitstro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Registro As DataRow
    Dim _Seleccionada As Boolean

    Dim _Tabla As String
    Dim _Campos As String
    Dim _Descripcion As String
    Dim _Condicion_Adicional As String

    Dim _Tbl_Registros As DataTable

    Enum Enum_Tabla_Busqueda
        Funcionarios
        Empresa
        Sucursal
        Bodega
    End Enum

    Dim _Tabla_Busqueda As Enum_Tabla_Busqueda

    Public Property Pro_Condicion_Adicional() As String
        Get
            Return _Condicion_Adicional
        End Get
        Set(ByVal value As String)
            _Condicion_Adicional = value
        End Set
    End Property
    Public ReadOnly Property Pro_Row_Registro() As DataRow
        Get
            Return _Row_Registro
        End Get
    End Property
    Public ReadOnly Property Pro_Seleccionada() As Boolean
        Get
            Return _Seleccionada
        End Get
    End Property

    Public Sub New(ByVal Tabla_Busqueda As Enum_Tabla_Busqueda)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        _Tabla_Busqueda = Tabla_Busqueda

    End Sub

    Private Sub Frm_Seleccionar_1_Regitstro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler BtnAceptar.Click, AddressOf Sb_Seleccionar_Registro
        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Registro
        AddHandler Grilla.RowPostPaint, AddressOf Sb_RowsPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Select Case _Tabla_Busqueda
            Case Enum_Tabla_Busqueda.Empresa
            Case Enum_Tabla_Busqueda.Sucursal
            Case Enum_Tabla_Busqueda.Bodega
            Case Enum_Tabla_Busqueda.Funcionarios
                _Tabla = "TABFU"
                _Campos = "KOFU"
                _Descripcion = "NOKOFU"
        End Select

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Trim(Txt_Filtro_Busqueda.Text)), _Campos & "+" & _Descripcion & " LIKE '%")
        Dim _Filtro_Busqueda As String = vbCrLf & "And " & _Campos & "+" & _Descripcion & " Like '%" & _Cadena & "%'"


        Consulta_sql = "Select " & _Campos & " As Codigo," & _Descripcion & " As Descripcion" & vbCrLf & _
                       "From " & _Tabla & vbCrLf & _
                       "Where 1 > 0" & vbCrLf & _
                       _Condicion_Adicional & vbCrLf & _
                       _Filtro_Busqueda

        _Tbl_Registros = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Registros

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True

            .Columns("Descripcion").Width = 430
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

        End With

    End Sub

    Sub Sb_Seleccionar_Registro()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("Codigo").Value

        Consulta_sql = "Select top 1 * FROM " & _Tabla & vbCrLf & _
                       "Where " & _Campos & " = '" & _Codigo & "'"

        _Row_Registro = _Sql.Fx_Get_DataRow(Consulta_sql)
        _Seleccionada = True
        Me.Close()

    End Sub

    Sub Sb_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < Grilla.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If Grilla.RowHeadersWidth < CInt(size.Width + 20) Then
                Grilla.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net", _
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Txt_Filtro_Busqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Filtro_Busqueda.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Filtro_Busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Filtro_Busqueda.TextChanged
        If String.IsNullOrEmpty(Txt_Filtro_Busqueda.Text) Then Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_Seleccionar_1_Regitstro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{F2}")
            'SendKeys.Send("{LEFT}")
            e.Handled = True
            Sb_Seleccionar_Registro()
        End If
    End Sub
End Class