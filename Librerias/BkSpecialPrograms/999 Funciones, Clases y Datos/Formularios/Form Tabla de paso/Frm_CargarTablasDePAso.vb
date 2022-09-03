
Imports System.Windows.Forms
Imports System.Drawing

Public Class Frm_CargarTablasDePaso

    Public _Tabla_de_Paso As DataTable

    Private Sub Frm_CargarTablasDePAso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Grilla.DataSource = _Tabla_de_Paso
        Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

End Class
