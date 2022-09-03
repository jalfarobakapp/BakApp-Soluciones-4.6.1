Imports DevComponents.DotNetBar

Public Class Frm_Plan

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer

    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Inventario = _Id_Inventario

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Plan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub


    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Ubic.*,Isnull(Toma.Id_Pareja,0) As 'IdPareja_Toma',Isnull(P1.Nombre_Pareja,'') As 'Pareja_Toma',Toma.FechaActivacion As 'FechaAsigToma',
		  	                          Isnull(Levante.Id_Pareja,0) As 'IdPareja_Levante',Isnull(P2.Nombre_Pareja,'') As 'Pareja_Levante',Levante.FechaActivacion As 'FechaAsigLevante'  
                        From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones Ubic
                        Left Join " & _Global_BaseBk & "Zw_Inv_Plan Toma On Toma.Id_Inventario = Ubic.Id_Inventario 
		                        And Ubic.Empresa = Toma.Empresa And Ubic.Sucursal = Toma.Sucursal And Ubic.Bodega = Toma.Bodega 
			                        And Ubic.Codigo_Sector = Toma.Codigo_Sector And Ubic.Codigo_Ubic = Toma.Codigo_Ubic And Toma.TipoPareja = 'TOMA'
                        Left Join " & _Global_BaseBk & "Zw_Inv_Parejas P1 On P1.Id_Inventario = Toma.Id_Inventario And P1.Id_Pareja = Toma.Id_Pareja
                        Left Join " & _Global_BaseBk & "Zw_Inv_Plan Levante On Toma.Id_Inventario = Ubic.Id_Inventario 
		                        And Ubic.Empresa = Levante.Empresa And Ubic.Sucursal = Levante.Sucursal And Ubic.Bodega = Levante.Bodega 
			                        And Ubic.Codigo_Sector = Levante.Codigo_Sector And Ubic.Codigo_Ubic = Levante.Codigo_Ubic And Levante.TipoPareja = 'LEVANTE'
                        Left Join " & _Global_BaseBk & "Zw_Inv_Parejas P2 On P2.Id_Inventario = Levante.Id_Inventario And P2.Id_Pareja = Levante.Id_Pareja
                        Where Ubic.Id_Inventario = " & _Id_Inventario & "
                        Order By Ubic.Codigo_Sector,Ubic.Codigo_Ubic"

        Dim _Tbl_Parejas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Parejas

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo_Sector").Visible = True
            .Columns("Codigo_Sector").HeaderText = "Sector"
            .Columns("Codigo_Sector").Width = 100
            .Columns("Codigo_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo_Ubic").Visible = True
            .Columns("Codigo_Ubic").HeaderText = "Ubicacion"
            .Columns("Codigo_Ubic").Width = 100
            .Columns("Codigo_Ubic").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Pareja_Toma").Visible = True
            .Columns("Pareja_Toma").HeaderText = "Pareja Toma"
            .Columns("Pareja_Toma").Width = 130
            .Columns("Pareja_Toma").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaAsigToma").Visible = True
            .Columns("FechaAsigToma").HeaderText = "Plan Toma"
            .Columns("FechaAsigToma").Width = 100
            .Columns("FechaAsigToma").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Pareja_Levante").Visible = True
            .Columns("Pareja_Levante").HeaderText = "Pareja Levante"
            .Columns("Pareja_Levante").Width = 130
            .Columns("Pareja_Levante").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaAsigLevante").Visible = True
            .Columns("FechaAsigLevante").HeaderText = "Plan Levante"
            .Columns("FechaAsigLevante").Width = 100
            .Columns("FechaAsigLevante").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

End Class
