Imports DevComponents.DotNetBar

Public Class Frm_Validar_Documento_Detalle

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Preparado As Boolean
    Dim _Cl_Despacho As Clas_Despacho

    Dim _Tbl_Detalle_Documento As DataTable
    Dim _Confirmar As Boolean

    Public Property Tbl_Detalle_Documento As DataTable
        Get
            Return _Tbl_Detalle_Documento
        End Get
        Set(value As DataTable)
            _Tbl_Detalle_Documento = value
        End Set
    End Property

    Public Property Confirmar As Boolean
        Get
            Return _Confirmar
        End Get
        Set(value As Boolean)
            _Confirmar = value
        End Set
    End Property

    Public Sub New(_Cl_Despacho As Clas_Despacho, _Idmaeedo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Cl_Despacho = _Cl_Despacho

        Consulta_Sql = "Select Idmaeedo,Idmaeddo,Empresa,Sucursal,Bodega,Codigo,Descripcion,Rtu,Untrans,UdTrans,
                        Case Untrans When 1 then CantCUd1 else CantCUd2 End As Cantidad,Cast(0 As Float) As Cantidad_Despachada
                        From " & _Global_BaseBk & "Zw_Despachos_Doc_Det
                        Where Id_Despacho = " & _Cl_Despacho.Id_Despacho & " And Idmaeedo = " & _Idmaeedo
        _Tbl_Detalle_Documento = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Validar_Documento_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Btn_Confirmar.Enabled = False

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _DisplayIndex = 0

        With Grilla_Detalle

            .DataSource = Tbl_Detalle_Documento

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            .Columns("Bodega").Width = 40
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Visible = True
            .Columns("Bodega").ReadOnly = False
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 250
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UdTrans").Width = 30
            .Columns("UdTrans").HeaderText = "Ud"
            .Columns("UdTrans").ReadOnly = True
            .Columns("UdTrans").Visible = True
            .Columns("UdTrans").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cant. ori."
            .Columns("Cantidad").ReadOnly = True
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad_Despachada").Width = 100
            .Columns("Cantidad_Despachada").HeaderText = "Cant. Despachar"
            .Columns("Cantidad_Despachada").ReadOnly = True
            .Columns("Cantidad_Despachada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad_Despachada").Visible = True
            .Columns("Cantidad_Despachada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Sub

    Private Sub Frm_Validar_Documento_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Confirmar_Click(sender As Object, e As EventArgs) Handles Btn_Confirmar.Click

        _Confirmar = True
        Me.Close()

    End Sub

    Private Sub Grilla_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Detalle.KeyDown

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        If e.KeyValue = Keys.Enter Then

            If _Cabeza = "Cantidad_Despachada" Then

                SendKeys.Send("{F2}")
                e.Handled = True
                Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                Grilla_Detalle.BeginEdit(True)

            End If

        End If

    End Sub

    Private Sub Grilla_Detalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEndEdit

        'Me.Enabled = False

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)
        Dim _Indice As Integer = Grilla_Detalle.CurrentRow.Index

        Grilla_Detalle.Columns(_Cabeza).ReadOnly = True

        Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value
        Dim _Cantidad_Despachada As Double = _Fila.Cells("Cantidad_Despachada").Value

        If _Cantidad_Despachada > _Cantidad Then
            MessageBoxEx.Show(Me, "No puede despachar una cantidad mayor a la del documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Fila.Cells("Cantidad_Despachada").Value = 0
        End If

        Dim _Suma_Cantiades As Double = 0

        For Each _Fl As DataGridViewRow In Grilla_Detalle.Rows

            _Suma_Cantiades += _Fila.Cells("Cantidad_Despachada").Value

        Next

        Btn_Confirmar.Enabled = CBool(_Suma_Cantiades)
        Me.Refresh()

    End Sub

    Private Sub Btn_Marcar_Todo_Click(sender As Object, e As EventArgs) Handles Btn_Marcar_Todo.Click

        For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows

            Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value

            _Fila.Cells("Cantidad_Despachada").Value = _Cantidad

        Next

        Btn_Confirmar.Enabled = True

    End Sub

End Class
