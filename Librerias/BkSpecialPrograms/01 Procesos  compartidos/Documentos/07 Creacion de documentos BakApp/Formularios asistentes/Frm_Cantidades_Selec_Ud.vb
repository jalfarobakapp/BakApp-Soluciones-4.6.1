Public Class Frm_Cantidades_Selec_Ud

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fila As DataGridViewRow

    Public Property UnTrans As Integer
    Public Property UdTrans As String
    Public Property Seleccionada As Boolean


    Public Sub New(Fila As DataGridViewRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Fila = Fila

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.None, False, True, False)

        'Me.StartPosition = FormStartPosition.Manual
        'Me.Location = New Point(Me.Width + Cursor.Position.X, Cursor.Position.Y)

    End Sub

    Private Sub Frm_Cantidades_Selec_Ud_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim _Ud1 = _Fila.Cells("Ud01PR").Value
        Dim _Ud2 = _Fila.Cells("Ud02PR").Value

        Consulta_sql = "Select 1 As UnTrans,'Primera Unidad' As Descripcion,'" & _Ud1 & "' As UdTrans Union 
                        Select 2 As UnTrnas,'Segunda Unidad' As Descripcion,'" & _Ud2 & "' As UdTrans"

        With Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").Width = 140
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            .Columns("Descripcion").ReadOnly = True
            _DisplayIndex += 1

            .Columns("UdTrans").Visible = True
            .Columns("UdTrans").Width = 40
            .Columns("UdTrans").HeaderText = "Ud."
            .Columns("UdTrans").DisplayIndex = _DisplayIndex
            .Columns("UdTrans").ReadOnly = True
            _DisplayIndex += 1

        End With

        Me.ActiveControl = Grilla

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Seleccionar_Unidad()
    End Sub

    Sub Sb_Seleccionar_Unidad()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Seleccionada = True
        UnTrans = _Fila.Cells("UnTrans").Value
        UdTrans = _Fila.Cells("UdTrans").Value

        Me.Close()

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{F2}")
            'SendKeys.Send("{LEFT}")
            e.Handled = True

            Sb_Seleccionar_Unidad()

        End If

    End Sub

    Private Sub Frm_Cantidades_Selec_Ud_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

    End Sub
End Class
