'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Seleccionar_Formato

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Formatos As DataTable
    Dim _Row_Tido As DataRow
    Dim _Row_Formato_Seleccionado As DataRow
    Dim _Formato_Seleccionado As Boolean

    Public ReadOnly Property Tbl_Formatos() As DataTable
        Get
            Return _Tbl_Formatos
        End Get
    End Property

    Public Property Row_Formato_Seleccionado As DataRow
        Get
            Return _Row_Formato_Seleccionado
        End Get
        Set(value As DataRow)
            _Row_Formato_Seleccionado = value
        End Set
    End Property

    Public Property Formato_Seleccionado As Boolean
        Get
            Return _Formato_Seleccionado
        End Get
        Set(value As Boolean)
            _Formato_Seleccionado = value
        End Set
    End Property

    Public Sub New(Tido As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Format_01" & Space(1) &
                       "Where TipoDoc = '" & Tido & "'-- And NombreFormato <> 'X Defecto'"
        _Tbl_Formatos = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Consulta_sql = "Select Top 1 * From TABTIDO Where TIDO = '" & Tido & "'"
        _Row_Tido = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Notido = _Row_Tido.Item("NOTIDO")
        Me.Text = _Notido

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Seleccionar_Formato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Seleccione formato de documento"

        With Grilla ' ancho 853

            .DataSource = _Tbl_Formatos

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").Width = 40
            .Columns("TipoDoc").HeaderText = "Tipo"
            .Columns("TipoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Subtido = String.Empty

            If _Row_Tido.Item("TIDO") = "GDD" Or _Row_Tido.Item("TIDO") = "GDP" Then
                .Columns("Subtido").Visible = True
                .Columns("Subtido").Width = 40
                .Columns("Subtido").HeaderText = "SubTD"
                .Columns("Subtido").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1
            End If

            .Columns("NombreFormato").Visible = True
            .Columns("NombreFormato").Width = 280
            .Columns("NombreFormato").HeaderText = "Nombre formato"
            .Columns("NombreFormato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Es_Picking").Visible = True
            .Columns("Es_Picking").Width = 50
            .Columns("Es_Picking").HeaderText = "Picking"
            .Columns("Es_Picking").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Seleccionar_Formato()
    End Sub

    Private Sub Frm_Seleccionar_Formato_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Sb_Seleccionar_Formato()
    End Sub

    Sub Sb_Seleccionar_Formato()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Tido = _Fila.Cells("TipoDoc").Value
        Dim _Subtido = _Fila.Cells("Subtido").Value
        Dim _NombreFormato = _Fila.Cells("NombreFormato").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & Space(1) &
                       "Where TipoDoc = '" & _Tido & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "'"
        _Row_Formato_Seleccionado = _Sql.Fx_Get_DataRow(Consulta_sql)
        _Formato_Seleccionado = True

        Me.Close()

    End Sub

    Private Sub Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{F2}")
            'SendKeys.Send("{LEFT}")
            e.Handled = True
            Sb_Seleccionar_Formato()
        End If
    End Sub

    Private Sub Frm_Seleccionar_Formato_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Formato_Seleccionado = False
        'Row_Formato_Seleccionado = Nothing
    End Sub

End Class
