Public Class Frm_Cantidades_Selec_Ud

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fila As DataGridViewRow
    Dim _UnTrans As Integer
    Dim _UdTrans As String

    Dim _Seleccionada As Boolean

    Public Property UnTrans As Integer
        Get
            Return _UnTrans
        End Get
        Set(value As Integer)
            _UnTrans = value
        End Set
    End Property

    Public Property UdTrans As String
        Get
            Return _UdTrans
        End Get
        Set(value As String)
            _UdTrans = value
        End Set
    End Property

    Public Property Seleccionada As Boolean
        Get
            Return _Seleccionada
        End Get
        Set(value As Boolean)
            _Seleccionada = value
        End Set
    End Property

    Public Sub New(Fila As DataGridViewRow)

        ' Esta llamada es exigida por el dise�ador.
        InitializeComponent()

        ' Agregue cualquier inicializaci�n despu�s de la llamada a InitializeComponent().

        _Fila = Fila

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.None, False, True, False)

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
            .Columns("Descripcion").HeaderText = "Descripci�n"
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

        _Seleccionada = True
        _UnTrans = _Fila.Cells("UnTrans").Value
        _UdTrans = _Fila.Cells("UdTrans").Value

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