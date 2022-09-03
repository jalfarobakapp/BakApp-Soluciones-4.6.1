Imports DevComponents.DotNetBar
Imports Funciones_BakApp

Public Class Frm_AsociarUbicXprod

    Public _TblUbicaciones As DataTable

    Public _Ubicacion_Asociada As Boolean

    Private Sub Frm_AsociarUbicXprod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Grilla

            'Empresa, Sucursal, Bodega, Nombre_Mapa, Codigo_Sector, Columna, NomColumna, 
            'Fila, Alto, Largo, Ancho, Peso_Max, Codigo_Ubic, Descripcion_Ubic

            .DataSource = _TblUbicaciones

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Empresa").Width = 30
            .Columns("Empresa").HeaderText = "Emp."
            .Columns("Empresa").Visible = True

            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").HeaderText = "Suc."
            .Columns("Sucursal").Visible = True

            .Columns("Bodega").Width = 30
            .Columns("Bodega").HeaderText = "Bod."
            .Columns("Bodega").Visible = True

            .Columns("Nombre_Mapa").Width = 300
            .Columns("Nombre_Mapa").HeaderText = "Mapa"
            '.Columns("Nombre_Mapa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nombre_Mapa").Visible = True

            .Columns("Codigo_Sector").Width = 120
            .Columns("Codigo_Sector").HeaderText = "Sector"
            .Columns("Codigo_Sector").Visible = True

            .Columns("Descripcion_Ubic").Width = 80
            .Columns("Descripcion_Ubic").HeaderText = "Ubicación"
            .Columns("Descripcion_Ubic").Visible = True
            .Columns("Descripcion_Ubic").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '.Columns("Fila").Width = 60
            '.Columns("Fila").HeaderText = "Fila"
            '.Columns("Fila").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Fila").Visible = True

        End With
    End Sub

    Private Sub Grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellContentClick

        _Ubicacion_Asociada = True
        Me.Close()

    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.PaleGoldenrod, ScrollBars.Vertical, False, False, False)
    End Sub
End Class