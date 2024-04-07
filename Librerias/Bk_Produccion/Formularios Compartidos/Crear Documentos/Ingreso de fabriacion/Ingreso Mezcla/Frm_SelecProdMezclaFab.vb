Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_SelecProdMezclaFab

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_ProductosFab As DataTable

    Public Property Cl_Mezcla As Cl_Mezcla
    Public Property RowNomenclatura As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_SelecMezcla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Factor As Double = Cl_Mezcla.MzEnc.CantFabricar / Cl_Mezcla.MzEnc.Cantnomen
        Dim _Fab As String = De_Num_a_Tx_01(_Factor,, 5)

        Consulta_sql = "Select PNPD.*," & _Fab & "*PNPD.CANTIDAD As 'Fabricar',MAEPR.NOKOPR,MAEPR.UD01PR,MAEPR.UD02PR,MAEPR.TIPR,MAEPR.DIVISIBLE,MAEPR.LOMIFA," &
                       "MAEPR.LOMAFA,MAEPR.MUDEFA,MAEPR.KOPRDIM,MAEPR.NODIM1,MAEPR.NODIM2,PCOMODI.COMODIN AS XXCOMODIN" & vbCrLf &
                       "From PNPD" & vbCrLf &
                       "Left Join MAEPR On PNPD.ELEMENTO=MAEPR.KOPR" & vbCrLf &
                       "Left Join PCOMODI On PNPD.ELEMENTO=PCOMODI.KOCOMO" & vbCrLf &
                       "Where PNPD.CODIGO = '" & Cl_Mezcla.MzEnc.Codnomen & "' And PNPD.ELEMENTO In (Select CODIGO From PRELA)"

        _Tbl_ProductosFab = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_ProductosFab

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            'Sb_InsertarBotonenGrilla(Grilla, "Btn_Opciones", "Opciones...", "Opciones", 0, _Tipo_Boton.Boton)

            .Columns("ELEMENTO").Width = 100
            .Columns("ELEMENTO").HeaderText = "Código"
            .Columns("ELEMENTO").Visible = True
            .Columns("ELEMENTO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 350
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UDAD").Width = 30
            .Columns("UDAD").HeaderText = "Udad"
            .Columns("UDAD").Visible = True
            .Columns("UDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").HeaderText = "Fabricar"
            .Columns("Fabricar").Width = 60
            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricar").DefaultCellStyle.Format = "###,###.##"
            .Columns("Fabricar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Btn_Edit").DisplayIndex = True

        End With

        'If MarcarFilasSinSaldo Then

        '    For Each row As DataGridViewRow In Grilla.Rows

        '        Dim _Saldo As Double = row.Cells("SALDO").Value

        '        If _Saldo = 0 Then
        '            row.DefaultCellStyle.ForeColor = Color.Gray
        '        End If

        '    Next

        'End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _RowNomenclatura As DataRow
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Codigo As String = _Fila.Cells("ELEMENTO").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Where Id_Enc = 0 And Codigo = '" & _Codigo & "'"
        Dim _RowMzDet As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowMzDet) Then

            Dim _Codnomen As String = _RowMzDet.Item("Codnomen")

            Consulta_sql = "Select * From PNPE Where CODIGO = '" & _Codnomen & "'"
            RowNomenclatura = _RowNomenclatura
            Me.Close()
            Return

        End If

        Dim FmNom As New Frm_Select_Nomenclatura(_Codigo)
        FmNom.ShowDialog(Me)
        _RowNomenclatura = FmNom.RowNomenclatura
        FmNom.Dispose()

        If IsNothing(_RowNomenclatura) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una nomeclatura para poder crear la Orden de fabricación", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        RowNomenclatura = _RowNomenclatura
        Me.Close()

    End Sub

End Class
