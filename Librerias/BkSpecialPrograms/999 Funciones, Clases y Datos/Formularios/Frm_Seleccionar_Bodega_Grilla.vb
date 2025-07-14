Imports DevComponents.DotNetBar

Public Class Frm_Seleccionar_Bodega_Grilla

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Row_Bodega As DataRow
    Dim _Seleccionada As Boolean
    Dim _Pedir_Permiso As Boolean = True
    Dim _Solo_Bodegas_Sucursal As Boolean

    Public ReadOnly Property Pro_Row_Bodega() As DataRow
        Get
            Return _Row_Bodega
        End Get
    End Property
    Public ReadOnly Property Pro_Seleccionada() As Boolean
        Get
            Return _Seleccionada
        End Get
    End Property
    Public Property Pro_Pedir_Permiso() As Boolean
        Get
            Return _Pedir_Permiso
        End Get
        Set(value As Boolean)
            _Pedir_Permiso = value
        End Set
    End Property

    Public Property Solo_Bodegas_Sucursal As Boolean
        Get
            Return _Solo_Bodegas_Sucursal
        End Get
        Set(value As Boolean)
            _Solo_Bodegas_Sucursal = value
        End Set
    End Property

    Public Sub New(Codigo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Codigo = Trim(Codigo)
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Seleccionar_Bodega_Grilla_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If String.IsNullOrEmpty(_Codigo) Then
            Sb_Actualizar_Grilla_Solo_Bodegas()
        Else

            Consulta_sql = "Select top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _Tbl_Producto As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl_Producto.Rows.Count) Then
                Me.Text = "Producto: " & _Codigo & ", " & _Tbl_Producto.Rows(0).Item("NOKOPR")
            End If

            Sb_Actualizar_Grilla_Con_Stock_Del_Producto(_Codigo)
        End If

    End Sub

    Sub Sb_Actualizar_Grilla_Solo_Bodegas()

        Dim _Filtro_Sucursal As String

        If _Solo_Bodegas_Sucursal Then
            _Filtro_Sucursal = " And KOSU = '" & Mod_Sucursal & "'"
        End If

        Consulta_sql = "Select EMPRESA,KOSU,KOBO,NOKOBO" & vbCrLf &
                       "From TABBO" & vbCrLf &
                       "Where EMPRESA = '" & Mod_Empresa & "'" & _Filtro_Sucursal

        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOSU").Width = 60
            .Columns("KOSU").HeaderText = "Sucursal"
            .Columns("KOSU").Visible = True

            .Columns("KOBO").Width = 60
            .Columns("KOBO").HeaderText = "Bodega"
            .Columns("KOBO").Visible = True

            .Columns("NOKOBO").Width = 350
            .Columns("NOKOBO").HeaderText = "Nombre bodega"
            .Columns("NOKOBO").Visible = True

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Con_Stock_Del_Producto(_Kopr As String)

        Consulta_sql = "Select EMPRESA,KOSU,KOBO,NOKOBO," &
                       "Isnull((Select Top 1 STFI1 From MAEST Ms" & Space(1) &
                       "Where Ms.EMPRESA = Tb.EMPRESA And Ms.KOSU = Tb.KOSU And Ms.KOBO = Tb.KOBO And" & Space(1) &
                       "Ms.KOPR = '" & _Kopr & "'),0) as STFI1," &
                       "Isnull((Select Top 1 STFI2 From MAEST Ms" & Space(1) &
                       "Where Ms.EMPRESA = Tb.EMPRESA And Ms.KOSU = Tb.KOSU And Ms.KOBO = Tb.KOBO And" & Space(1) &
                       "Ms.KOPR = '" & _Kopr & "'),0) as STFI2" & vbCrLf &
                       "FROM TABBO Tb"

        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOSU").Width = 60
            .Columns("KOSU").HeaderText = "Sucursal"
            .Columns("KOSU").Visible = True

            .Columns("KOBO").Width = 60
            .Columns("KOBO").HeaderText = "Bodega"
            .Columns("KOBO").Visible = True

            .Columns("NOKOBO").Width = 250
            .Columns("NOKOBO").HeaderText = "Nombre bodega"
            .Columns("NOKOBO").Visible = True

            .Columns("STFI1").Width = 50
            .Columns("STFI1").HeaderText = "Stock Ud1"
            .Columns("STFI1").Visible = True
            .Columns("STFI1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI1").DefaultCellStyle.Format = "###,##.##"

            .Columns("STFI2").Width = 50
            .Columns("STFI2").HeaderText = "Stock Ud2"
            .Columns("STFI2").Visible = True
            .Columns("STFI2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI2").DefaultCellStyle.Format = "###,##.##"

        End With

    End Sub

    Private Sub Frm_Seleccionar_Bodega_Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Seleccionar_Bodega()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Empresa = _Fila.Cells("EMPRESA").Value
        Dim _Sucursal = _Fila.Cells("KOSU").Value
        Dim _Bodega = _Fila.Cells("KOBO").Value

        Consulta_sql = "Select top 1 EMPRESA,KOSU,KOBO,NOKOBO FROM TABBO" & vbCrLf &
                       "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            If _Pedir_Permiso Then
                Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega
                _Seleccionada = Fx_Tiene_Permiso(Me, _Permiso)
            Else
                _Seleccionada = True
            End If

            If _Seleccionada Then
                _Row_Bodega = _Tbl.Rows(0)
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click
        Sb_Seleccionar_Bodega()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Seleccionar_Bodega()
    End Sub

    Private Sub Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{F2}")
            'SendKeys.Send("{LEFT}")
            e.Handled = True
            Sb_Seleccionar_Bodega()
        End If
    End Sub

End Class
