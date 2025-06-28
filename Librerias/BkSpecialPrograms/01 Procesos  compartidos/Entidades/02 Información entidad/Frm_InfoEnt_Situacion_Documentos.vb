
Public Class Frm_InfoEnt_Situacion_Documentos

    Dim _Tabla As DataTable
    Dim _TipoDocumentos As _TipoDoc

    Public Property Tabla As DataTable
        Get
            Return _Tabla
        End Get
        Set(value As DataTable)
            _Tabla = value
        End Set
    End Property

    Public Property TipoDocumentos As _TipoDoc
        Get
            Return _TipoDocumentos
        End Get
        Set(value As _TipoDoc)
            _TipoDocumentos = value
        End Set
    End Property

    Enum _TipoDoc
        Doc_Venta
        Doc_Pago
    End Enum
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Documentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        AddHandler Grilla_Documentos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Color_Botones_Barra(Bar2)

    End Sub


    Private Sub Frm_InfoEnt_Situacion_Documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _TipoDocumentos = _TipoDoc.Doc_Pago Then
            Sb_Actualizar_Grilla_Documentos_Pago()
        ElseIf _TipoDocumentos = _TipoDoc.Doc_Venta Then
            Sb_Actualizar_Grilla_Documentos_Venta()
            AddHandler Grilla_Documentos.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        End If

    End Sub
    Sub Sb_Actualizar_Grilla_Documentos_Venta()

        With Grilla_Documentos

            .DataSource = _Tabla

            OcultarEncabezadoGrilla(Grilla_Documentos, True)

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 0

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 1

            .Columns("DEFOTRANS").HeaderText = "Estado documento"
            .Columns("DEFOTRANS").Width = 200
            .Columns("DEFOTRANS").Visible = True
            .Columns("DEFOTRANS").DisplayIndex = 2

            .Columns("FEULVEDO").HeaderText = "Ult. Vencimiento"
            .Columns("FEULVEDO").Width = 90
            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEULVEDO").DisplayIndex = 3

            .Columns("VABRDO").HeaderText = "Bruto"
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = 4

            .Columns("VAABDO").HeaderText = "Abonado"
            .Columns("VAABDO").Width = 80
            .Columns("VAABDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAABDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = 5

            .Columns("SALDO").HeaderText = "Saldo"
            .Columns("SALDO").Width = 80
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DisplayIndex = 6

            For Each _Fila As DataGridViewRow In .Rows
                If _Fila.Cells("NUDONODEFI").Value Then
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Documentos_Pago()

        With Grilla_Documentos

            .DataSource = _Tabla

            OcultarEncabezadoGrilla(Grilla_Documentos, True)

            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 30
            .Columns("TIDP").Visible = True
            .Columns("TIDP").DisplayIndex = 0

            .Columns("NUDP").HeaderText = "N° Interno"
            .Columns("NUDP").Width = 80
            .Columns("NUDP").Visible = True
            .Columns("NUDP").DisplayIndex = 1

            .Columns("BANCO").HeaderText = "Banco"
            .Columns("BANCO").Width = 180
            .Columns("BANCO").Visible = True
            .Columns("BANCO").DisplayIndex = 2

            .Columns("NUCUDP").HeaderText = "N° Documento"
            .Columns("NUCUDP").Width = 90
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").DisplayIndex = 3

            .Columns("FEVEDP").HeaderText = "Vencimiento"
            .Columns("FEVEDP").Width = 90
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEVEDP").DisplayIndex = 4

            .Columns("VADP").HeaderText = "Valor"
            .Columns("VADP").Width = 80
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").Visible = True
            .Columns("VADP").DisplayIndex = 5

        End With

    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Me.Enabled = False

        Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Tido = _Fila.Cells("TIDO").Value
        Dim _Nudonodefi As Boolean = _Fila.Cells("NUDONODEFI").Value

        Dim Fm As Frm_Ver_Documento

        If _Tido = "NVV" And _Nudonodefi Then
            Fm = New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Bakapp_Kasi)
        Else
            Fm = New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        End If

        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub Frm_InfoEnt_Situacion_Documentos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub
End Class
