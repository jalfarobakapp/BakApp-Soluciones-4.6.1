Public Class Frm_InfoEnt_Protestos

    Dim _Tabla As DataTable
    Public Sub New(_Tabla As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tabla = _Tabla

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_InfoEnt_Protestos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Sb_Actualizar_Grilla_Documentos_Pago()
    End Sub

    Sub Sb_Actualizar_Grilla_Documentos_Pago()

        'TIDO,NUDO,NUCUDO,MODO,VABRDO,FEEMDO

        With Grilla

            .DataSource = _Tabla

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").HeaderText = "N° Interno"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUCUDO").HeaderText = "N° Propio"
            .Columns("NUCUDO").Width = 90
            .Columns("NUCUDO").Visible = True
            .Columns("NUCUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VABRDO").HeaderText = "Valor"
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "Vencimiento"
            .Columns("FEEMDO").Width = 90
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_InfoEnt_Protestos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
