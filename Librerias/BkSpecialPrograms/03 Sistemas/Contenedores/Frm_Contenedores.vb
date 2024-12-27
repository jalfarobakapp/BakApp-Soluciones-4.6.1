Public Class Frm_Contenedores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Public Property ModoSeleccion As Boolean
    Public Property Zw_Contenedor As New Zw_Contenedor

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Contenedores, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Contenedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Contenedores.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        If Chk_Abierto.Checked Then
            _Condicion = " And Estado = 'Abierto'"
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Contenedor" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Contenedores

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Contenedores, True)

            '.Columns("Id").Width = 40
            '.Columns("Id").HeaderText = "ID"
            '.Columns("Id").Visible = True
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Empresa").Width = 30
            '.Columns("Empresa").HeaderText = "Emp"
            '.Columns("Empresa").Visible = True
            '.Columns("Empresa").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Contenedor").Width = 100
            .Columns("Contenedor").HeaderText = "Contenedor"
            .Columns("Contenedor").Visible = True
            .Columns("Contenedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreContenedor").Width = 250
            .Columns("NombreContenedor").HeaderText = "Nombre Contenedor"
            .Columns("NombreContenedor").Visible = True
            .Columns("NombreContenedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Width = 60
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = True
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Contenedor_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Contenedor.Click

        Dim _Grabar As Boolean

        Dim Fm As New Frm_CrearContenedor(0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_Contenedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Contenedores.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow

        Dim _IdCont As Integer = _Fila.Cells("Id").Value

        If ModoSeleccion Then

            Dim _Cl_Contenedor As New Cl_Contenedor

            Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_IdCont)
            Me.Close()
            Return

        End If

        Dim Fm As New Frm_CrearContenedor(_IdCont)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            _Fila.Cells("Contenedor").Value = Fm.Zw_Contenedor.Contenedor
        End If
        If Fm.Eliminar Then
            Grilla_Contenedores.Rows.Remove(_Fila)
        End If
        Fm.Dispose()

    End Sub

End Class
