Imports DevComponents.DotNetBar

Public Class Frm_Pocket_Dispositivos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Dv As New DataView

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Pocket_Dispositivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Revisar_Fila
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Estaciones_Poswi (NombreEquipo,Usuario,Modalidad,Impresion_X_BakApp," &
                       "Enviar_Mail_X_BakApp,Impresion_X_Poswi,Enviar_Mail_X_Poswi)" & vbCrLf &
                       "Select NombreEquipo,'','',0,0,1,1" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_EstacionesBkp" & vbCrLf &
                       "Where TipoEstacion = 'P' And NombreEquipo Not In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_Poswi)" &
                       vbCrLf &
                       vbCrLf &
                       "SELECT NombreEquipo,Usuario," &
                       "Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = Usuario),'') As Nombre_Usuario," &
                       "Modalidad,Impresion_X_BakApp,Enviar_Mail_X_BakApp,Impresion_X_Poswi,Enviar_Mail_X_Poswi" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Estaciones_Poswi" & vbCrLf &
                       "Where NombreEquipo In (Select NombreEquipo From " & _Global_BaseBk & "Zw_EstacionesBkp" & Space(1) &
                       "Where TipoEstacion = 'P')" & vbCrLf &
                       "Order By NombreEquipo"

        Dim _Ds As New DataSet
        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Dv.Table = _Ds.Tables(0)


        'Grilla.DataSource
        With Grilla ' ancho 853

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("NombreEquipo").Visible = True
            .Columns("NombreEquipo").Width = 150
            .Columns("NombreEquipo").HeaderText = "Equipo"
            '.Columns("NombreEquipo").DisplayIndex = 0

            .Columns("Usuario").Visible = True
            .Columns("Usuario").Width = 50
            .Columns("Usuario").HeaderText = "User"
            '.Columns("Usuario").DisplayIndex = 1

            .Columns("Nombre_Usuario").Visible = True
            .Columns("Nombre_Usuario").Width = 200
            .Columns("Nombre_Usuario").HeaderText = "Nombre Usuario"
            '.Columns("Nombre_Usuario").DisplayIndex = 2

            .Columns("Modalidad").Visible = True
            .Columns("Modalidad").Width = 80
            .Columns("Modalidad").HeaderText = "Modalidad"
            '.Columns("Modalidad").DisplayIndex = 3

            .Columns("Impresion_X_BakApp").Visible = True
            .Columns("Impresion_X_BakApp").Width = 80
            .Columns("Impresion_X_BakApp").HeaderText = "Impresión por BakApp"
            .Columns("Impresion_X_BakApp").ReadOnly = False
            '.Columns("Impresion_X_BakApp").DisplayIndex = 4

            .Columns("Enviar_Mail_X_BakApp").Visible = True
            .Columns("Enviar_Mail_X_BakApp").Width = 80
            .Columns("Enviar_Mail_X_BakApp").HeaderText = "Mail por BakApp"
            .Columns("Enviar_Mail_X_BakApp").ReadOnly = False
            '.Columns("Enviar_Mail_X_BakApp").DisplayIndex = 4

            .Columns("Impresion_X_Poswi").Visible = True
            .Columns("Impresion_X_Poswi").Width = 80
            .Columns("Impresion_X_Poswi").HeaderText = "Impresión por Poswi"
            .Columns("Impresion_X_Poswi").ReadOnly = False
            '.Columns("Impresion_X_Poswi").DisplayIndex = 4

            .Columns("Enviar_Mail_X_Poswi").Visible = True
            .Columns("Enviar_Mail_X_Poswi").Width = 80
            .Columns("Enviar_Mail_X_Poswi").HeaderText = "Mail pro Poswii"
            .Columns("Enviar_Mail_X_Poswi").ReadOnly = False
            '.Columns("Enviar_Mail_X_Poswi").DisplayIndex = 4

        End With

        _Dv.RowFilter = String.Format("NombreEquipo+Usuario+Nombre_Usuario Like '%{0}%'", Txt_Buscar.Text)

    End Sub

    Sub Sb_Revisar_Fila()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _NombreEquipo As String = _Fila.Cells("NombreEquipo").Value

        Dim Fm As New Frm_Pocket_Equipos(_NombreEquipo)
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            Txt_Buscar.Text = String.Empty
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Grilla_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
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

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar.TextChanged
        _Dv.RowFilter = String.Format("NombreEquipo+Usuario+Nombre_Usuario Like '%{0}%'", Txt_Buscar.Text)
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_Pocket_Dispositivos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Actualizar_Grilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Grilla.Click
        Txt_Buscar.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

End Class
