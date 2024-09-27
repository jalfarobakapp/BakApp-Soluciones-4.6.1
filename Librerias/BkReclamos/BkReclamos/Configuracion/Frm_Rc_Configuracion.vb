Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Rc_Configuracion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Email As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Correos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Correos.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Rc_Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Correos.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla_Correos.RowPostPaint, AddressOf Sb_Grilla_RowsPostPaint
        AddHandler Cmb_Estados.SelectedIndexChanged, AddressOf Sb_Cmb_Estados_SelectedIndexChanged
        'AddHandler Cmb_Tipo_Reclamos.SelectedIndexChanged, AddressOf Sb_Cmb_Tipo_Reclamos_SelectedIndexChanged

        Sb_Llenar_Combo_Estados()
        Sb_Actualizar_Grilla()
        Sb_Llenar_Combo_Tipo_Reclamos("RVE")
        'Sb_Llenar_Combo_Sub_Tipo_Reclamos("")

    End Sub

    Sub Sb_Llenar_Combo_Estados()

        Consulta_Sql = "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'SIS_RECLAMOS_ESTADO' And CodigoTabla In ('RVE','RCI','RSL','VAL','AVI') Order by Orden"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        caract_combo(Cmb_Estados)
        Cmb_Estados.DataSource = _Tbl
        Cmb_Estados.SelectedValue = "RVE"

    End Sub
    Sub Sb_Llenar_Combo_Tipo_Reclamos(_Codigo As String)

        Consulta_Sql = "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'SIS_RECLAMOS_TIPO' Order by Orden"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        caract_combo(Cmb_Tipo_Reclamos)
        Cmb_Tipo_Reclamos.DataSource = _Tbl
        Cmb_Tipo_Reclamos.SelectedValue = _Codigo

    End Sub

    'Sub Sb_Llenar_Combo_Sub_Tipo_Reclamos(ByVal _Codigo As String)

    '    Consulta_Sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf &
    '                   "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
    '                   "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
    '                   "WHERE Tabla = 'SIS_RECLAMOS_SUBTIPO' And Padre_Tabla = 'SIS_RECLAMOS_TIPO' And Padre_CodigoTabla = '" & Cmb_Tipo_Reclamos.SelectedValue & "'" & vbCrLf &
    '                   "Order by Padre"
    '    Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

    '    caract_combo(Cmb_Sub_Tipo_Reclamos)
    '    Cmb_Sub_Tipo_Reclamos.DataSource = _Tbl
    '    Cmb_Sub_Tipo_Reclamos.SelectedValue = _Codigo

    'End Sub
    'Sub Sb_Llenar_Combo_Preguntas(ByVal _Codigo As String)

    '    Consulta_Sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf &
    '                   "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
    '                   "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
    '                   "WHERE Tabla = 'SIS_RECLAMOS_PREG' And Padre_Tabla = 'SIS_RECLAMOS_TIPO' And Padre_CodigoTabla = '" & Cmb_Tipo_Reclamos.SelectedValue & "'" & vbCrLf &
    '                   "Order by Padre"
    '    Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

    '    caract_combo(Cmb_Preguntas)
    '    Cmb_Preguntas.DataSource = _Tbl
    '    Cmb_Preguntas.SelectedValue = _Codigo

    'End Sub
    Sub Sb_Actualizar_Grilla()

        Dim _Estado As String = Cmb_Estados.SelectedValue

        Consulta_Sql = "Select Zw_Est.Tabla,Zw_Est.CodigoTabla As Estado, Zw_Est.NombreTabla As NomEstado, Zw_Est.Orden, Zw_Tipo.Tabla AS Tbl_Tipo, 
                        Zw_Tipo.CodigoTabla AS Codigo_Tipo,Zw_Tipo.NombreTabla AS Tipo_Reclamo
                        ,Isnull(Zw_Mail.Id_Correo,0) As Id_Correo
                        ,Isnull(Zw_Mail.Nombre_Correo,'') As Nombre_Correo,Isnull(Zw_Mail.Para,'') As Para
                        From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones AS Zw_Est Cross Join
                        " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones AS Zw_Tipo
		                Left Join " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso Zw_Mail On Zw_Mail.Estado = Zw_Est.CodigoTabla And Zw_Mail.Tipo_Reclamo = Zw_Tipo.CodigoTabla
                        Where (Zw_Est.Tabla = 'SIS_RECLAMOS_ESTADO') AND (Zw_Tipo.Tabla = 'SIS_RECLAMOS_TIPO')
                        And Zw_Est.CodigoTabla = '" & _Estado & "'--In ('RVE','RCI','RSL','VAL','AVI','GES')
                        Order by Zw_Est.Orden,Zw_Tipo.Orden"

        Consulta_Sql = "Select Id_Correo, Estado, Tipo_Reclamo,Zw_Est.NombreTabla, Accion, Zw_Est.NombreTabla+' '+Accion As Nombre_Tipo_Reclamo,Nombre_Correo, Para
                        From " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso Zw_Mail
                        Inner Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Zw_Est On Zw_Mail.Tipo_Reclamo = Zw_Est.CodigoTabla
                        Where (Zw_Est.Tabla = 'SIS_RECLAMOS_TIPO') 
                        And Zw_Mail.Estado = '" & _Estado & "'--In ('RVE','RCI','RSL','VAL','AVI','GES')
                        Order by Zw_Est.NombreTabla,Accion"

        _Tbl_Email = _Sql.Fx_Get_DataTable(Consulta_Sql)

        With Grilla_Correos

            .DataSource = _Tbl_Email

            OcultarEncabezadoGrilla(Grilla_Correos)

            .Columns("Nombre_Tipo_Reclamo").Visible = True
            .Columns("Nombre_Tipo_Reclamo").HeaderText = "Tipo Reclamo"
            .Columns("Nombre_Tipo_Reclamo").Width = 150

            .Columns("Nombre_Correo").Visible = True
            .Columns("Nombre_Correo").HeaderText = "Correo relacionado"
            .Columns("Nombre_Correo").Width = 220

            '.Columns("Para").Visible = True
            '.Columns("Para").HeaderText = "Para"
            '.Columns("Para").Width = 40

        End With

    End Sub

    Private Sub Sb_Cmb_Estados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Estado As String = Cmb_Estados.SelectedValue

        Dim _Habilitado As Boolean = (_Estado = "GES")

        Sb_Actualizar_Grilla()

    End Sub
    'Private Sub Sb_Cmb_Tipo_Reclamos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Sb_Llenar_Combo_Sub_Tipo_Reclamos("")
    'End Sub

    Private Sub Grilla_Correos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Correos.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)
        Dim _Nombre_Correo = _Fila.Cells("Nombre_Correo").Value
        Dim _Para = NuloPorNro(_Fila.Cells("Para").Value, "")

        Btn_Para.Visible = (Cmb_Estados.SelectedValue <> "AVI")
        Btn_Para.Enabled = (Not String.IsNullOrEmpty(_Nombre_Correo))
        Btn_Para.Text = "Para: " & Trim(Mid(_Para, 1, 100)) & "..."
        ShowContextMenu(Menu_Contextual)

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Call Grilla_Correos_CellDoubleClick(Nothing, Nothing)
                End If
            End With
        End If
    End Sub

    Sub Sb_Grilla_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
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

    Private Sub Btn_Mnu_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Correo.Click

        Dim _Row_Email As DataRow

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)
        _Row_Email = Fm.Pro_Row_Fila_Seleccionada
        Fm.Dispose()

        If Not IsNothing(_Row_Email) Then

            Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)
            Dim _Id_Correo = _Fila.Cells("Id_Correo").Value
            Dim _Estado = _Fila.Cells("Estado").Value
            Dim _Tipo_Reclamo = _Fila.Cells("Tipo_Reclamo").Value
            Dim _Nombre_Correo = _Row_Email.Item("Nombre_Correo")
            Dim _Confirmado As Boolean

            If CBool(_Id_Correo) Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso Set Nombre_Correo = '" & _Nombre_Correo & "' 
                                Where Id_Correo = " & _Id_Correo
                _Confirmado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

            Else

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso (Estado,Tipo_Reclamo,Nombre_Correo) Values 
                                ('" & _Estado & "','" & _Tipo_Reclamo & "','" & _Nombre_Correo & "')"
                _Confirmado = _Sql.Ej_Insertar_Trae_Identity(Consulta_Sql, _Id_Correo)

            End If

            If _Confirmado Then

                _Fila.Cells("Id_Correo").Value = _Id_Correo
                _Fila.Cells("Nombre_Correo").Value = _Nombre_Correo

                If Btn_Para.Visible Then
                    MessageBoxEx.Show(Me, "Ahora debe confirmar a los destinatarios", "Enviar correos",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Call Btn_Para_Click(Nothing, Nothing)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Quitar_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Quitar_Correo.Click

        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)

        Dim _Id_Correo = _Fila.Cells("Id_Correo").Value

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso Set Nombre_Correo = '',Para = '' 
                        Where Id_Correo = " & _Id_Correo

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            _Fila.Cells("Nombre_Correo").Value = String.Empty
            _Fila.Cells("Para").Value = String.Empty
        End If

    End Sub

    Private Sub Btn_Tipo_Reclamos_Click(sender As Object, e As EventArgs) Handles Btn_Tipo_Reclamos.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Reclamos_Tipos,
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Tipos de reclamos (Sis. Reclamos)"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Llenar_Combo_Tipo_Reclamos(Cmb_Tipo_Reclamos.SelectedValue)

    End Sub

    Private Sub Btn_Sub_Tipo_Reclamos_Click(sender As Object, e As EventArgs) Handles Btn_Sub_Tipo_Reclamos.Click

        If Not String.IsNullOrEmpty(Cmb_Tipo_Reclamos.SelectedValue) Then

            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Reclamos_Sub_Tipos,
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "Tabla Sub-Tipos de reclamos (Sis. Reclamos) (" & Cmb_Tipo_Reclamos.Text & ")"
            Fm.Pro_Padre_Tabla = "SIS_RECLAMOS_TIPO"
            Fm.Pro_Padre_CodigoTabla = Cmb_Tipo_Reclamos.SelectedValue
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            MessageBoxEx.Show(Me, "Debe seleccionar el tipo de reclamo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Correos_Click(sender As Object, e As EventArgs) Handles Btn_Correos.Click

        If Fx_Tiene_Permiso(Me, "Mail0001") Then
            Dim Fm As New Frm_Correos_SMTP
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_Para_Click(sender As Object, e As EventArgs) Handles Btn_Para.Click

        Dim _Fila As DataGridViewRow = Grilla_Correos.Rows(Grilla_Correos.CurrentRow.Index)

        Dim _Id_Correo = _Fila.Cells("Id_Correo").Value
        Dim _Nombre_Correo = _Fila.Cells("Nombre_Correo").Value
        Dim _Para = _Fila.Cells("Para").Value

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Puede ingresar varios correos" & vbCrLf & "separados por "","" o "";""" & vbCrLf & vbCrLf &
                                              "Ejemplo:" & vbCrLf & "Cr1@mail.com,Cr2@mail.cl, etc...", "Ingrese los destinatarios",
                                             _Para, True,, 1000, True, _Tipo_Imagen.Correo)

        If _Aceptar Then

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso Set Para = '" & _Para & "' 
                            Where Id_Correo = " & _Id_Correo
            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                _Fila.Cells("Para").Value = _Para
            End If

        End If

    End Sub

    Private Sub Btn_Preguntas_Click(sender As Object, e As EventArgs) Handles Btn_Preguntas.Click

        If Not String.IsNullOrEmpty(Cmb_Tipo_Reclamos.SelectedValue) Then

            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Reclamos_Preguntas,
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "Preguntas por tipo de reclamo (Sis. Reclamos) (" & Cmb_Tipo_Reclamos.Text & ")"
            Fm.Pro_Padre_Tabla = "SIS_RECLAMOS_TIPO"
            Fm.Pro_Padre_CodigoTabla = Cmb_Tipo_Reclamos.SelectedValue
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            MessageBoxEx.Show(Me, "Debe seleccionar el tipo de reclamo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
End Class