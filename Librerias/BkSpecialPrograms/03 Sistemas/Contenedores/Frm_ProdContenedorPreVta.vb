Public Class Frm_ProdContenedorPreVta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Empresa As String
    Private _IdCont As Integer
    Private _Contenedor As String

    Dim _Cl_Contenedor As New Cl_Contenedor

    Public Property Seleccionado As Boolean
    Public Property RowProducto As DataRow

    Public Property Cl_PreVenta As New PreVenta.Cl_PreVenta

    Public Sub New(_Empresa As String, _IdCont As Integer, _Contenedor As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Empresa = _Empresa
        Me._IdCont = _IdCont
        Me._Contenedor = _Contenedor

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Contenedores, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

        _Cl_Contenedor.Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_IdCont)

    End Sub

    Private Sub Frm_ProdContenedorPreVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "CONTENEDOR: " & _Cl_Contenedor.Zw_Contenedor.Contenedor & " - " & _Cl_Contenedor.Zw_Contenedor.NombreContenedor

        AddHandler Grilla_Contenedores.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Contenedores.KeyDown, AddressOf Sb_Grilla_KeyDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        'If Chk_Abierto.Checked Then
        '    _Condicion = " And Estado = 'Abierto'"
        'End If

        Consulta_sql = "Select Id,Empresa,IdCont,Contenedor,Codigo,NOKOPR,CLALIBPR,StcfiDisponibleUd1,StcfiDisponibleUd2," &
                       "StcCompUd1,StcCompUd2,StcfiDisponibleUd1-StcCompUd1 As StDispUd1,FormatoPqte,Ud1XPqte,CantMinFormato,Moneda,PrecioXUd1" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Contenedor_StockProd p" & vbCrLf &
                       "Inner Join MAEPR m On m.KOPR = p.Codigo" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And IdCont = " & _IdCont & " And Contenedor = '" & _Contenedor & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Contenedores

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Contenedores, True)

            '.Columns("Id").Width = 40
            '.Columns("Id").HeaderText = "ID"
            '.Columns("Id").Visible = True
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Empresa").Width = 30
            '.Columns("Empresa").HeaderText = "Emp"
            '.Columns("Empresa").Visible = True
            '.Columns("Empresa").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 310
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("FormatoPqte").Width = 80
            '.Columns("FormatoPqte").HeaderText = "Form.Vnta"
            '.Columns("FormatoPqte").Visible = True
            '.Columns("FormatoPqte").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Ud1XPqte").Width = 60
            .Columns("Ud1XPqte").HeaderText = "Ud1XPallet"
            .Columns("Ud1XPqte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud1XPqte").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Ud1XPqte").Visible = True
            .Columns("Ud1XPqte").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantMinFormato").Width = 60
            .Columns("CantMinFormato").HeaderText = "Cant.Min.Vta XForm."
            .Columns("CantMinFormato").ToolTipText = "Cantidad Minima de venta por Pallet."
            .Columns("CantMinFormato").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantMinFormato").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantMinFormato").Visible = True
            .Columns("CantMinFormato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StDispUd1").Width = 70
            .Columns("StDispUd1").HeaderText = "Disponible Ud1"
            .Columns("StDispUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StDispUd1").DefaultCellStyle.Format = "##,###0.##"
            .Columns("StDispUd1").Visible = True
            .Columns("StDispUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Contenedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Contenedores.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow
        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        With Cl_PreVenta

            .Id = _Fila.Cells("Id").Value
            .IdCont = _IdCont
            .Contenedor = _Fila.Cells("Contenedor").Value
            .CantMinFormato = _Fila.Cells("CantMinFormato").Value
            .FormatoPqte = _Fila.Cells("FormatoPqte").Value
            .StDispUd1 = _Fila.Cells("StDispUd1").Value
            .Ud1XPqte = _Fila.Cells("Ud1XPqte").Value
            .Cantidad = _Fila.Cells("CantMinFormato").Value
            .CantMinFormato = _Fila.Cells("CantMinFormato").Value
            .PrecioXUd1 = _Fila.Cells("PrecioXUd1").Value

        End With

        Seleccionado = True
        Me.Close()

    End Sub

    Private Sub Sb_Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        Try

            Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow
            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            If e.KeyValue = Keys.Enter Then

                SendKeys.Send("{LEFT}")
                e.Handled = True

                Call Grilla_Contenedores_CellDoubleClick(Nothing, Nothing)

            End If

        Catch ex As Exception
            Beep()
        End Try

    End Sub

    Private Sub Frm_ProdContenedorPreVta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
