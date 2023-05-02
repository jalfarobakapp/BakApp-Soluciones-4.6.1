Imports DevComponents.DotNetBar

Public Class Frm_PrecioLCFuturoListaXProd

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowProducto As DataRow
    Dim _Tbl_ListaLC_Programadas As DataTable
    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, True, True, False)

    End Sub

    Private Sub Frm_PrecioLCFuturoListaXProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Txtcodigo.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim
        Sb_Actualizar_Datos_Grilla()

        AddHandler Rdb_MostrarTodas.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_MostrarSoloActivas.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged

        Btn_ImprimirCodBarras.Visible = False

    End Sub

    Sub Sb_Actualizar_Datos_Grilla()

        Dim _Codigo = _RowProducto.Item("KOPR")

        Dim _Conficion_Adicional As String

        If Rdb_MostrarSoloActivas.Checked Then
            _Conficion_Adicional = "And Activo = 1"
        End If


        Consulta_sql = "Select Lts.*,Isnull(NOKOFU,'') As NOKOFU," &
                       "(Select Count(*) From " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Z1 Where Z1.Id_Enc = Lts.Id) As Listas" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_ListaLC_Programadas Lts" & vbCrLf &
                       "Left Join TABFU On KOFU = Lts.Funcionario" & vbCrLf &
                       "Where Codigo = '" & _Codigo & "' And Eliminada = 0" & vbCrLf &
                       _Conficion_Adicional & vbCrLf &
                       "Order By FechaProgramada"
        _Tbl_ListaLC_Programadas = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            Grilla.DataSource = _Tbl_ListaLC_Programadas

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("FechaProgramada").Width = 80
            .Columns("FechaProgramada").HeaderText = "F.Activación"
            .Columns("FechaProgramada").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaProgramada").Visible = True
            .Columns("FechaProgramada").ReadOnly = True
            .Columns("FechaProgramada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Activo").Width = 60
            .Columns("Activo").HeaderText = "Activa"
            .Columns("Activo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Activo").Visible = True
            .Columns("Activo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Aplicado").Width = 60
            .Columns("Aplicado").HeaderText = "Aplicado"
            .Columns("Aplicado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Aplicado").Visible = True
            .Columns("Aplicado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Width = 280 + 80
            .Columns("NOKOFU").HeaderText = "Creada por..."
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").ReadOnly = True
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("FechaCreacion").Width = 80
            '.Columns("FechaCreacion").HeaderText = "F.Creación"
            '.Columns("FechaCreacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            '.Columns("FechaCreacion").Visible = True
            '.Columns("FechaCreacion").ReadOnly = True
            '.Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Refresh()

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Codigo = _RowProducto.Item("KOPR")
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Enc As Integer = _Fila.Cells("Id").Value
        Dim _FechaProgramada As DateTime = _Fila.Cells("FechaProgramada").Value
        Dim _Grabar As Boolean

        Consulta_sql = "Select Cast(0 As bit) As Chk,* From " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles" & vbCrLf &
                       "Where Id_Enc = " & _Id_Enc & " And Eliminada = 0"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_PrecioLCFuturoGrabar(_Codigo, _Tbl, 0)
        Fm.Id_Enc = _Id_Enc
        Fm.Editar = True
        Fm.Dtp_FechaProgramada.Value = _FechaProgramada
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Datos_Grilla()
            If Not CBool(_Tbl_ListaLC_Programadas.Rows.Count) Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Frm_PrecioLCFuturoListaXProd_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Datos_Grilla()
        If Not CBool(_Tbl_ListaLC_Programadas.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existe información", "Listas programadas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Sub Sb_Rdb_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Datos_Grilla()
        If Not CBool(_Tbl_ListaLC_Programadas.Rows.Count) And CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            MessageBoxEx.Show(Me, "No existe información", "Listas programadas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Btn_ImprimirCodBarras_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirCodBarras.Click

        Consulta_sql = "Select Cast(1 As Bit) As Chk,'" & _RowProducto.Item("KOPR") & "' As Codigo,'" & _RowProducto.Item("KOPR") & "' As Descripcion"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_ImpBarras_PorProducto
        Fm.Pro_Tbl_Filtro_Productos = _Tbl
        Fm.ImprimirDesdePrecioFuturo = True
        Fm.ListaPrecios = "PB7"
        Fm.Pro_Cantidad_Uno = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
