Imports DevComponents.DotNetBar

Public Class Frm_Sectores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Cl_WMS_Sectores As New Cl_WMS_Sectores

    Private _Id_Mapa As Integer
    Private _Empresa As String
    Private _Sucursal As String
    Private _Bodega As String

    Private _Dv As DataView
    Private _Tbl_Sectores As DataTable

    Public Property SectorSeleccionado As Zw_WMS_Ubicaciones_Sectores

    Public Sub New(_Id_Mapa As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Mapa = _Id_Mapa

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

        _Cl_WMS_Sectores = New Cl_WMS_Sectores

    End Sub

    Private Sub Frm_Sectores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select *,Cast((Select COUNT(1) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Sh Where Sh.Id_Mapa = Sc.Id_Mapa And Sh.Codigo_Sector = Sc.Codigo_Sector) As bit) As EstaEnMapa" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Sc" & vbCrLf &
                       "Where Sc.Id_Mapa = " & _Id_Mapa & " And Sc.Es_SubSector = 0" & vbCrLf &
                       "Order By Sc.Codigo_Sector"

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_Sectores = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("EstaEnMapa").Width = 60
            .Columns("EstaEnMapa").HeaderText = "En Mapa"
            .Columns("EstaEnMapa").ToolTipText = "Muestra si la ubicación esta actualmente en el Mapa"
            .Columns("EstaEnMapa").Visible = True
            .Columns("EstaEnMapa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Empresa").Visible = True
            .Columns("Empresa").HeaderText = "Emp."
            .Columns("Empresa").Width = 30
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").HeaderText = "Suc."
            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Visible = True
            .Columns("Bodega").HeaderText = "Bod."
            .Columns("Bodega").Width = 30
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Id").Visible = True
            '.Columns("Id").HeaderText = "Id"
            '.Columns("Id").Width = 30
            '.Columns("Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Codigo_Sector").Visible = True
            .Columns("Codigo_Sector").HeaderText = "Sector"
            .Columns("Codigo_Sector").Width = 100
            .Columns("Codigo_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Sector").Visible = True
            .Columns("Nombre_Sector").HeaderText = "Nombre Sector"
            .Columns("Nombre_Sector").Width = 300
            .Columns("Nombre_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Es_SubSector").Visible = True
            '.Columns("Es_SubSector").HeaderText = "SubSector"
            '.Columns("Es_SubSector").Width = 50
            '.Columns("Es_SubSector").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("EsCabecera").Visible = True
            '.Columns("EsCabecera").HeaderText = "Cabecera"
            '.Columns("EsCabecera").Width = 60
            '.Columns("EsCabecera").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Es_SubSector").Width = 30
            '.Columns("Es_SubSector").HeaderText = "S.S."
            '.Columns("Es_SubSector").ToolTipText = "Es Sub-Sector"
            '.Columns("Es_SubSector").Visible = True
            '.Columns("Es_SubSector").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("EsCabecera").Width = 30
            .Columns("EsCabecera").HeaderText = "CBRA"
            .Columns("EsCabecera").ToolTipText = "Es un sector tipo cabecera"
            .Columns("EsCabecera").Visible = True
            .Columns("EsCabecera").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SoloUnaUbicacion").Width = 30
            .Columns("SoloUnaUbicacion").HeaderText = "U.U."
            .Columns("SoloUnaUbicacion").ToolTipText = "Solo acepta una ubicación"
            .Columns("SoloUnaUbicacion").Visible = True
            .Columns("SoloUnaUbicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OblConfimarUbic").Width = 30
            .Columns("OblConfimarUbic").HeaderText = "C.U."
            .Columns("OblConfimarUbic").ToolTipText = "Obliga a confirmar ubicaciones diariamente"
            .Columns("OblConfimarUbic").Visible = True
            .Columns("OblConfimarUbic").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.CurrentRow

                    ShowContextMenu(Menu_Contextual_MantSector)

                End If
            End With
        End If
    End Sub

    Private Sub Btn_EditarUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_EditarUbicacion.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Sector As Integer = _Fila.Cells("Id_Sector").Value

        Dim _Grabar As Boolean
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
        Dim _Nombre_Sector As String = _Fila.Cells("Nombre_Sector").Value
        Dim _EsCabecera As Boolean = _Fila.Cells("EsCabecera").Value
        Dim _SoloUnaUbicacion As Boolean = _Fila.Cells("SoloUnaUbicacion").Value
        Dim _OblConfimarUbic As Boolean = _Fila.Cells("OblConfimarUbic").Value

        Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa, _Id_Sector)
        Fm.Chk_EsCabecera.Enabled = False
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Codigo_Sector = Fm.Codigo_Sector
        _Nombre_Sector = Fm.Nombre_Sector
        _EsCabecera = Fm.EsCabecera
        _SoloUnaUbicacion = Fm.SoloUnaUbicacion
        _OblConfimarUbic = Fm.OblConfimarUbic
        Fm.Dispose()

        If _Grabar Then
            _Fila.Cells("Codigo_Sector").Value = _Codigo_Sector
            _Fila.Cells("Nombre_Sector").Value = _Nombre_Sector
            _Fila.Cells("EsCabecera").Value = _EsCabecera
            _Fila.Cells("SoloUnaUbicacion").Value = _SoloUnaUbicacion
            _Fila.Cells("OblConfimarUbic").Value = _OblConfimarUbic
        End If

    End Sub

    Private Sub Btn_EliminarUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_EliminarUbicacion.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Sector As Integer = _Fila.Cells("Id_Sector").Value
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                       "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar este sector." & vbCrLf &
                              "Existen productos asociados en las ubicaciones", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Desea eliminar el sector seleccionado?", "Eliminar Sector",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Cl_WMS_Sectores.Fx_Eliminar_Sector(_Id_Sector, _Codigo_Sector)

        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click
        With Grilla
            Try
                Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
                Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText
                Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
                Clipboard.SetText(Copiar)

                ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End With
    End Sub

    Private Sub Btn_Crear_Ubicacion_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ubicacion.Click

        Dim _Grabar As Boolean
        Dim _Id_Sector As Integer

        Dim Fm As New Frm_Formulario_Diseno_Mapa_Crear_Sector(_Id_Mapa, 0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Id_Sector = Fm.Id_Sector
        Fm.Dispose()

        If Not _Grabar Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_WMS_Sectores.Fx_Llenar_Sector(_Id_Sector)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        SectorSeleccionado = _Mensaje.Tag

        Me.Close()

        'Sb_Actualizar_Grilla()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Sector As Integer = _Fila.Cells("Id_Sector").Value
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_WMS_Sectores.Fx_Llenar_Sector(_Id_Sector)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        SectorSeleccionado = _Mensaje.Tag

        Me.Close()

    End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            _Dv.RowFilter = String.Format("Codigo_Sector+Nombre_Sector Like '%{0}%'", Txt_Filtrar.Text.Trim)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If Txt_Filtrar.Text.Trim.Length > 0 Then
            _Dv.RowFilter = String.Empty
        End If
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        _Dv.RowFilter = String.Empty
    End Sub
End Class
