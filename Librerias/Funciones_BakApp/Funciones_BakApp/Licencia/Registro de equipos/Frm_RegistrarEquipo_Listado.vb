Imports System.Drawing
Imports System.Windows.Forms


Public Class Frm_RegistrarEquipo_Listado

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub


    Sub LlenarGrilla()

        Consulta_sql = "SELECT IpEstacion, NombreEquipo," & vbCrLf & _
                       "case TipoEstacion" & vbCrLf & _
                       "when 'C' then 'Consultor de precios'" & vbCrLf & _
                       "when 'N' then 'Estación Normal'" & vbCrLf & _
                       "when 'P' then 'Post-Venta'" & vbCrLf & _
                       "end as TipoEstacion, KeyReg" & vbCrLf & _
                       "FROM Zw_EstacionesBkp"

        With Grilla

            .DataSource = get_Tablas(Consulta_sql, cn1)

            .Columns("KeyReg").Visible = False

            Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.PowderBlue)

            .Columns("IpEstacion").Width = 100
            .Columns("IpEstacion").HeaderText = "Ip Estación"
            .Columns("IpEstacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("NombreEquipo").Width = 250
            .Columns("NombreEquipo").HeaderText = "Nombre estación de trabajo"
            ' .Columns("NombreEquipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("TipoEstacion").Width = 100
            .Columns("TipoEstacion").HeaderText = "Tipo estación"
            '.Columns("TipoEstacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

           

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim KeyReg = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KeyReg").Value
        Dim NomEquipo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreEquipo").Value
        Dim IpRegistrada = Grilla.Rows(Grilla.CurrentRow.Index).Cells("IpEstacion").Value

        Dim Fm As New Frm_RegistrarEquipo
        Fm.Accion = Fm.ListaAccion.Editar
        Fm.Txt1.Text = IpRegistrada
        Fm.LblNombreEquipo.Text = NomEquipo

        Fm.ShowDialog(Me)
        LlenarGrilla()

    End Sub

    Private Sub Frm_RegistrarEquipo_Listado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarGrilla()
    End Sub
End Class