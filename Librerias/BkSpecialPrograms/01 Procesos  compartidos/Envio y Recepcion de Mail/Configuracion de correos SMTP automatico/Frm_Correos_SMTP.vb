Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Correos_SMTP

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Seleccionar As Boolean
    Dim _Seleccionado As Boolean
    Dim _Row_Fila_Seleccionada As DataRow
    Dim _Filtro_Extra As String

    Public Property Pro_Seleccionar() As Boolean
        Get
            Return _Seleccionar
        End Get
        Set(ByVal value As Boolean)
            _Seleccionar = value
        End Set
    End Property
    Public Property Pro_Seleccionado() As Boolean
        Get
            Return _Seleccionado
        End Get
        Set(ByVal value As Boolean)
            _Seleccionado = value
        End Set
    End Property
    Public Property Pro_Row_Fila_Seleccionada() As DataRow
        Get
            Return _Row_Fila_Seleccionada
        End Get
        Set(ByVal value As DataRow)
            _Row_Fila_Seleccionada = value
        End Set
    End Property
    Public Property Pro_Filtro_Extra() As String
        Get
            Return _Filtro_Extra
        End Get
        Set(ByVal value As String)
            _Filtro_Extra = value
        End Set
    End Property
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub
    Private Sub Frm_Correos_SMTP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Ab_Actualizar_Grilla()
        Grilla.ContextMenuStrip = MenuContextual

    End Sub
    Private Sub Btn_CrearCorreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CrearCorreo.Click
        If Fx_Tiene_Permiso(Me, "Mail0002") Then
            Dim Fm As New Frm_Correos_Conf
            Fm._Accion = Frm_Correos_Conf.Accion.Nuevo
            Fm.ShowDialog(Me)
            If Fm.Pro_Grabar Then
                Ab_Actualizar_Grilla()
            End If
        End If
    End Sub

    Sub Ab_Actualizar_Grilla()

        Consulta_sql = "SELECT *,Tipo = Case Envio_Automatico When 1 Then 'Automático' Else 'Manual' End " &
                       "From " & _Global_BaseBk & "Zw_Correos" & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _Filtro_Extra &
                       "Order by Nombre_Correo"

        Dim _Tbl_Correos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Correos

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Id").Visible = True
            .Columns("Id").HeaderText = "Id"
            .Columns("Id").Width = 30
            .Columns("Id").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Correo").Visible = True
            .Columns("Nombre_Correo").HeaderText = "Nombre correo"
            .Columns("Nombre_Correo").Width = 290
            .Columns("Nombre_Correo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Remitente").Visible = True
            .Columns("Remitente").HeaderText = "Correo remitente"
            .Columns("Remitente").Width = 190
            .Columns("Remitente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Host").Visible = True
            .Columns("Host").HeaderText = "Host (SMTP)"
            .Columns("Host").Width = 100
            .Columns("Host").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Puerto").Visible = True
            .Columns("Puerto").HeaderText = "Puerto"
            .Columns("Puerto").Width = 45
            .Columns("Puerto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo envío"
            .Columns("Tipo").Width = 80
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub


    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If _Seleccionar Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Id = _Fila.Cells("Id").Value
            Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Correos Where Id = " & _Id

            _Row_Fila_Seleccionada = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Seleccionado = True
            Me.Close()
        Else
            Sb_Ver_Remitente()
        End If

    End Sub

    Sub Sb_Ver_Remitente()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        'Nombre_Correo, Remitente, Contrasena, Host, Puerto, Asunto, Auto_Asunto, Para, CC, CuerpoMensaje, Firma, SSL

        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _Nombre_Correo As String = _Fila.Cells("Nombre_Correo").Value
        Dim _Remitente As String = _Fila.Cells("Remitente").Value
        Dim _Contrasena As String = _Fila.Cells("Contrasena").Value
        Dim _Host_SMTP As String = _Fila.Cells("Host").Value
        Dim _Puerto As String = _Fila.Cells("Puerto").Value

        Dim _Asunto As String = _Fila.Cells("Asunto").Value
        Dim _Auto_Asunto As Boolean = _Fila.Cells("Auto_Asunto").Value
        Dim _Para As String = _Fila.Cells("Para").Value
        Dim _CC As String = _Fila.Cells("CC").Value
        Dim _CuerpoMensaje As String = _Fila.Cells("CuerpoMensaje").Value

        Dim _Firma As Boolean = _Fila.Cells("Firma").Value
        Dim _SSL As Boolean = _Fila.Cells("SSL").Value
        Dim _Envio_Automatico As Boolean = _Fila.Cells("Envio_Automatico").Value
        Dim _Es_Html As Boolean = _Fila.Cells("Es_Html").Value


        Dim Fm As New Frm_Correos_Conf
        With Fm
            ._Accion = Frm_Correos_Conf.Accion.Editar
            .Pro_Id = _Id
            .Txt_Nombre_Correo.Text = _Nombre_Correo
            .Txt_Remitente.Text = _Remitente
            .Txt_Contrasena.Text = _Contrasena
            .Txt_Host_SMTP.Text = _Host_SMTP
            .Txt_Puerto.Text = _Puerto
            .Txt_Asunto.Text = _Asunto
            .Chk_Auto_Asunto.Checked = _Auto_Asunto
            .Txt_Para.Text = _Para
            .Txt_CC.Text = _CC
            .Txt_Cuerpo.Text = _CuerpoMensaje

            .Chk_Firma.Checked = _Firma
            .Chk_SSL.Checked = _SSL
            .Chk_Es_Html.Checked = _Es_Html

            If _Envio_Automatico Then
                .Rdb_Envio_Automatico.Checked = True
                .Rdb_Envio_Manual.Checked = False
            Else
                .Rdb_Envio_Automatico.Checked = False
                .Rdb_Envio_Manual.Checked = True
            End If

            .ShowDialog(Me)
            If .Pro_Grabar Then
                Ab_Actualizar_Grilla()
            End If
        End With
    End Sub

    Private Sub Frm_Correos_SMTP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub



    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    MenuContextual.Enabled = True
                Else
                    MenuContextual.Enabled = False
                End If
            End With
        End If
    End Sub

    Private Sub EditarCorreoSMTPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarCorreoSMTPToolStripMenuItem.Click
        Sb_Ver_Remitente()
    End Sub

    Private Sub Btn_Cuentas_Click(sender As Object, e As EventArgs) Handles Btn_Cuentas.Click
        Dim Fm As New Frm_Correos_Conf_SMTP_Lista(Frm_Correos_Conf_SMTP_Lista.Enum_Accion.Nuevo)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

End Class
