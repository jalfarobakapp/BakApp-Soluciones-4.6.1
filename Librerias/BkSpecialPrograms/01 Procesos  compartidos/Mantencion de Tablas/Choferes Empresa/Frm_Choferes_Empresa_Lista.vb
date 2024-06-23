'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_Choferes_Empresa_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Choferes As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Choferes_Empresa_Lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Chk_Mostrar_Solo_Habilitados.CheckedChanging, AddressOf Chk_Mostrar_Solo_Habilitados_CheckedChanging

    End Sub


#Region "PROCEDIMIENTO"

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        If Not Chk_Mostrar_Solo_Habilitados.Checked Then
            _Condicion = "And Habilitado = 1"
        End If

        Consulta_sql = "SELECT CodChofer,NomChofer,Direccion,Telefono,Email,Pais,Ciudad,Comuna,Informacion,Licencia,Habilitado" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_TblChoferes_Empresa" & vbCrLf & _
                       "Where 1 > 0" & vbCrLf & _Condicion


        _Tbl_Choferes = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Choferes

            OcultarEncabezadoGrilla(Grilla, True)


            .Columns("CodChofer").Visible = True
            .Columns("CodChofer").HeaderText = "Código interno"
            .Columns("CodChofer").Width = 60
            .Columns("CodChofer").DisplayIndex = 0

            .Columns("NomChofer").Visible = True
            .Columns("NomChofer").HeaderText = "Nombre chofer"
            .Columns("NomChofer").Width = 250
            .Columns("NomChofer").DisplayIndex = 1

            .Columns("Telefono").Visible = True
            .Columns("Telefono").HeaderText = "Teléfono"
            .Columns("Telefono").Width = 100
            .Columns("Telefono").DisplayIndex = 2
            '.Columns("Telefono").DefaultCellStyle.Format = "###,##"
            '.Columns("Telefono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

        Sb_Marcar_Grilla()

    End Sub

    Private Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Habilitado = _Fila.Cells("Habilitado").Value

            If _Habilitado Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            Else
                _Fila.DefaultCellStyle.ForeColor = Color.Red
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

        Next

    End Sub


#End Region

    Private Sub Chk_Mostrar_Solo_Habilitados_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)
        If Not Fx_Tiene_Permiso(Me, "") Then
            e.Cancel = True
        Else
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Frm_Choferes_Empresa_Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Crear_Chofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Chofer.Click

        Dim Fm As New Frm_Choferes_Empresa(Frm_Choferes_Empresa.Accion.Nuevo)
        Fm.ShowDialog(Me)

        If Fm.Pro_Nuevo_Chofer Then
            Sb_Actualizar_Grilla()
            Beep()
            ToastNotification.Show(Me, "CHOFER CREADO CORRECTAMENTE", _
                                   Btn_Crear_Chofer.Image, _
                                   1 * 1000, eToastGlowColor.Green, _
                                   eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()


    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _CodChofer = _Fila.Cells("CodChofer").Value

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_TblChoferes_Empresa Where CodChofer = '" & _CodChofer & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim Fm As New Frm_Choferes_Empresa(Frm_Choferes_Empresa.Accion.Editar)
            Fm.Pro_RowChofer = _Tbl.Rows(0)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Actualizar_Grilla()

        End If

    End Sub
End Class
