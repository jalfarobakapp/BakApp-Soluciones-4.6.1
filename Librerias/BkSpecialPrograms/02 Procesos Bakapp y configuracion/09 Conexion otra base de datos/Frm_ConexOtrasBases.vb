Imports DevComponents.DotNetBar

Public Class Frm_ConexOtrasBases

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_ConexOtrasBases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select *,'****' As [Password] From " & _Global_BaseBk & "Zw_DbExt_Conexion"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Nombre_Conexion").HeaderText = "Nombre conexión"
            .Columns("Nombre_Conexion").Width = 150
            .Columns("Nombre_Conexion").Visible = True
            .Columns("Nombre_Conexion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Servidor").HeaderText = "Host"
            .Columns("Servidor").Width = 190
            .Columns("Servidor").Visible = True
            .Columns("Servidor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Puerto").HeaderText = "Puerto"
            .Columns("Puerto").Width = 50
            .Columns("Puerto").Visible = True
            .Columns("Puerto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Usuario").HeaderText = "Usuario"
            .Columns("Usuario").Width = 110
            .Columns("Usuario").Visible = True
            .Columns("Usuario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Password").HeaderText = "Password"
            .Columns("Password").Width = 110
            .Columns("Password").Visible = True
            .Columns("Password").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("BaseDeDatos").HeaderText = "BaseDeDatos"
            .Columns("BaseDeDatos").Width = 110
            .Columns("BaseDeDatos").Visible = True
            .Columns("BaseDeDatos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Agregar_Conexion_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Conexion.Click

        Dim Fm As New Frm_DatosConexion(Frm_DatosConexion.Enum_Accion.Nuevo, 0)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        ShowContextMenu(Menu_Contextual_01)

    End Sub

    Private Sub Btn_Editar_Conexion_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Conexion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        Dim Fm As New Frm_DatosConexion(Frm_DatosConexion.Enum_Accion.Editar, _Id)

        Fm.Txt_Nombre_Conexion.Text = _Fila.Cells("Nombre_Conexion").Value
        Fm.Txt_Servidor.Text = _Fila.Cells("Servidor").Value
        Fm.Txt_Puerto.Text = _Fila.Cells("Puerto").Value
        Fm.Txt_Usuario.Text = _Fila.Cells("Usuario").Value
        Fm.Txt_Clave.Text = _Fila.Cells("Clave").Value
        Fm.Txt_BaseDeDatos.Text = _Fila.Cells("BaseDeDatos").Value

        Fm.ShowDialog(Me)
        If Fm.Grabar Then Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub Btn_Quitar_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Eliminar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta conexión?", "Eliminar conexión",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete Zw_DbExt_Conexion Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Conexión eliminada", "Eliminar conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_Actualizar_Grilla()
            End If

        End If

    End Sub

    Private Sub Btn_Importar_Stock_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Stock.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Importar_Stock_OEBD_Selec_Prod(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
