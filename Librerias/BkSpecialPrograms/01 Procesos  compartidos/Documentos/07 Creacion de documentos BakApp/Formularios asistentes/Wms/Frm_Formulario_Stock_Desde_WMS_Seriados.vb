Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Formulario_Stock_Desde_WMS_Seriados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Matriz_Documentos As DataSet

    Dim _Id As Integer
    Dim _Codigo As String
    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _Row_Producto As DataRow

    Dim _Tbl_Series_WMS As DataTable

    Dim _Aceptar As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property
    Public Property Pro_Tbl_Series_WMS() As DataTable
        Get
            Return _Tbl_Series_WMS
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Series_WMS = value
        End Set
    End Property
    Public Property Pro_Cant_Ud1() As Double
        Get
            Return Txt_Cantidad.Text
        End Get
        Set(ByVal value As Double)
            Txt_Cantidad.Text = value
        End Set
    End Property

    Dim _Fila As DataGridViewRow

    Public Sub New(ByVal Ds_Matriz_Documentos As DataSet, _
                   ByVal Fila As DataGridViewRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Fila = Fila

        _Id = _Fila.Cells("Id").Value
        _Empresa = _Fila.Cells("Empresa").Value
        _Sucursal = _Fila.Cells("Sucursal").Value
        _Bodega = _Fila.Cells("Bodega").Value
        _Codigo = _Fila.Cells("Codigo").Value

        Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Ds_Matriz_Documentos = Ds_Matriz_Documentos

        Lbl_Producto.Text = "Producto: [" & _Row_Producto.Item("KOPR") & "] - " & _Row_Producto.Item("NOKOPR")

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Formulario_Stock_Desde_WMS_Seriados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Ds_Matriz_Documentos.Tables("Tbl_Wms"), "Id = " & _Id, "Id_Wms")

        Dim _Filtro_Id_Wms As String = Generar_Filtro_IN(_Tbl, "", "Id_Wms", True, False, "")
        Dim _Condicion As String = String.Empty

        If CBool(_Tbl.Rows.Count) Then
            _Condicion = "Update #Paso1 Set Chk = 1 Where Id_Movimiento In " & _Filtro_Id_Wms
        End If

        _Tbl_Series_WMS = Fx_Crear_Tabla_Series_WMS(_Condicion)
        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Llenar_Tabla_Paso(ByVal _Id As Integer, ByVal _Tbl_Series_WMS As DataTable)

        Eliminar_Campos(_Ds_Matriz_Documentos.Tables("Tbl_Wms"), _Id)

        For Each _Fila As DataRow In _Tbl_Series_WMS.Rows ' Tbl_Wms.Rows

            Dim _Chk As Boolean = _Fila.Item("Chk")
            Dim _Id_Wms = _Fila.Item("Id_Movimiento")
            Dim _Empresa = _Fila.Item("Empresa")
            Dim _Sucursal = _Fila.Item("Sucursal")
            Dim _Bodega = _Fila.Item("Bodega")
            Dim _Codigo = _Fila.Item("Codigo")
            Dim _NroSerie_01 = _Fila.Item("NroSerie_01")
            Dim _NroSerie_02 = _Fila.Item("NroSerie_02")

            If _Chk Then

                Dim NewFila As DataRow
                NewFila = _Ds_Matriz_Documentos.Tables("Tbl_Wms").NewRow
                With NewFila
                    .Item("Id") = _Id
                    .Item("Id_Wms") = _Id_Wms
                    .Item("Empresa") = _Empresa
                    .Item("Sucursal") = _Sucursal
                    .Item("Bodega") = _Bodega
                    .Item("Codigo") = _Codigo
                    .Item("NroSerie_01") = _NroSerie_01
                    .Item("NroSerie_02") = _NroSerie_02
                    _Ds_Matriz_Documentos.Tables("Tbl_Wms").Rows.Add(NewFila)
                End With

            End If
        Next

    End Sub

    Function Fx_Crear_Tabla_Series_WMS(Optional ByVal _Condicion As String = "") As DataTable

        '"Update #Paso1 Set Chk = 1 Where Id_Movimiento In (2,3)"

        _Sql.Sb_Eliminar_Tabla_De_Paso("#Paso1")

        Consulta_sql = "SELECT Id_Movimiento,Cast(0 As Bit) As Chk,Empresa,Sucursal,Bodega,Codigo,NroSerie_01,NroSerie_02,Stock_Ud1,Stock_Ud2," & _
                       "Peso_Kg,Fecha_Movimiento,Idmaeddo_Reserva" & vbCrLf & _
                       "Into #Paso1" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto" & vbCrLf & _
                       "Where" & vbCrLf & _
                       "Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' and Bodega = '" & _Bodega & "'" & Space(1) & _
                       "And Codigo = '" & _Codigo & "' And Reservado = 0" & vbCrLf & _
                       "And" & vbCrLf & _
                       "(Codigo+NroSerie_01+NroSerie_02 Not In (Select Codigo+NroSerie_01+NroSerie_02" & Space(1) & _
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto Where Tipo_Movimiento = 'S'))" & vbCrLf & _
                       "Order By Fecha_Movimiento" & vbCrLf & vbCrLf & _
                       _Condicion & vbCrLf & _
                       "Select * From #Paso1" & vbCrLf & _
                       "Drop Table #Paso1"

        Dim _Tbl_Series_WMS As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _Tbl_Series_WMS

    End Function

    Sub Sb_Actualizar_Grilla()

        If _Tbl_Series_WMS Is Nothing Then _Tbl_Series_WMS = Fx_Crear_Tabla_Series_WMS()
       
        With Grilla

            .DataSource = _Tbl_Series_WMS

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Chk"
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = 0

            .Columns("NroSerie_01").Visible = True
            .Columns("NroSerie_01").HeaderText = "Nro Serie 1"
            .Columns("NroSerie_01").Width = 100
            .Columns("NroSerie_01").DisplayIndex = 1

            .Columns("NroSerie_02").Visible = True
            .Columns("NroSerie_02").HeaderText = "Nro Serie 2"
            .Columns("NroSerie_02").Width = 100
            .Columns("NroSerie_02").DisplayIndex = 2

            .Columns("Stock_Ud1").Visible = True
            .Columns("Stock_Ud1").HeaderText = "Stock Ud1"
            .Columns("Stock_Ud1").Width = 80
            .Columns("Stock_Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Ud1").DefaultCellStyle.Format = "###,##.##"
            .Columns("Stock_Ud1").DisplayIndex = 3

            .Columns("Stock_Ud2").Visible = True
            .Columns("Stock_Ud2").HeaderText = "Stock Ud2"
            .Columns("Stock_Ud2").Width = 80
            .Columns("Stock_Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Ud2").DefaultCellStyle.Format = "###,##.##"
            .Columns("Stock_Ud2").DisplayIndex = 4

            .Columns("Fecha_Movimiento").Visible = True
            .Columns("Fecha_Movimiento").HeaderText = "Fecha Ingreso"
            .Columns("Fecha_Movimiento").Width = 80
            '.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fecha_Movimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Movimiento").DisplayIndex = 5

        End With

        Call Grilla_CellEndEdit(Nothing, Nothing)

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        _Aceptar = True
        Sb_Llenar_Tabla_Paso(_Id, _Tbl_Series_WMS)
        Me.Close()
    End Sub

    Private Sub Grilla_Detalle_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Suma As Double

        For Each _Fila As DataRow In _Tbl_Series_WMS.Rows
            If _Fila.Item("Chk") Then
                _Suma += _Fila.Item("Stock_Ud1")
            End If
        Next

        Txt_Cantidad.Text = _Suma

    End Sub

End Class