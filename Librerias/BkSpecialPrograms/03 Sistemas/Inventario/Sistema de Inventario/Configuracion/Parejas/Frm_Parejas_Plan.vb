Imports DevComponents.DotNetBar

Public Class Frm_Parejas_Plan

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer
    Dim _Id_Pareja As Integer
    Dim _Row_Inventario As DataRow

    Public Sub New(_Id_Inventario As Integer, _Id_Pareja As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Pareja = _Id_Pareja
        Me._Id_Inventario = _Id_Inventario

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Inventario Inv" & vbCrLf &
                       "Where Id_Inventario = " & _Id_Inventario
        _Row_Inventario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Parejas_Plan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")
        Dim _Bodega = _Sql.Fx_Trae_Dato("TABBO", "KOBO", "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'")

        Cmb_Bodegas.DataSource = Nothing
        caract_combo(Cmb_Bodegas)
        Consulta_sql = "Select KOBO AS Padre,KOBO+'-'+NOKOBO AS Hijo FROM TABBO " &
                       "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "'"
        Cmb_Bodegas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Bodegas.SelectedValue = _Bodega

        Dim _Tb = Tabs.Tabs(Tabs.SelectedTabIndex)

        Sb_Actualizar_Grilla(_Tb.Tag)
    End Sub

    Sub Sb_Actualizar_Grilla(_TipoPareja As String)

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")
        Dim _Bodega = Cmb_Bodegas.SelectedValue

        Consulta_sql = "Select Pln.*,St.Nombre_Sector" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Inv_Plan Pln" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Inv_Sector St On Pln.Id_Inventario = St.Id_Inventario And St.Codigo_Sector = Pln.Codigo_Sector" & vbCrLf &
                        "Where Pln.Id_Pareja = " & _Id_Pareja & " And Pln.Empresa = '" & _Empresa & "' And Pln.Sucursal = '" & _Sucursal &
                        "' And Pln.Bodega = '" & _Bodega & "' And Pln.TipoPareja = '" & _TipoPareja & "'" & vbCrLf &
                        "Order By Codigo_Sector,Codigo_Ubic"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo_Sector").Visible = True
            .Columns("Codigo_Sector").HeaderText = "Sector"
            .Columns("Codigo_Sector").Width = 100
            .Columns("Codigo_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Sector").Visible = True
            .Columns("Nombre_Sector").HeaderText = "Nombre del sector"
            .Columns("Nombre_Sector").Width = 350
            .Columns("Nombre_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo_Ubic").Visible = True
            .Columns("Codigo_Ubic").HeaderText = "Ubicación"
            .Columns("Codigo_Ubic").Width = 100
            .Columns("Codigo_Ubic").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaActivacion").Visible = True
            .Columns("FechaActivacion").HeaderText = "Fecha"
            .Columns("FechaActivacion").Width = 100
            .Columns("FechaActivacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaActivacion").Visible = True
            .Columns("FechaActivacion").HeaderText = "Hora"
            .Columns("FechaActivacion").Width = 100
            .Columns("FechaActivacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Contado").Visible = True
            .Columns("Contado").HeaderText = "Contado"
            .Columns("Contado").Width = 70
            .Columns("Contado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Btn_Agregar_Ubicaciones.Tooltip = "Agregar ubicacione para (" & _TipoPareja & ")"
        Btn_Quitar_Ubicaciones.Tooltip = "Quitar ubicaciones para (" & _TipoPareja & ")"

        Consulta_sql = "Select 
                        (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pln
                        Where Pln.Id_Inventario = " & _Id_Inventario & " And Pln.Id_Pareja = " & _Id_Pareja & " And Pln.Empresa = '" & _Empresa & "' And Pln.Sucursal = '" & _Sucursal & "' And Pln.Bodega = '" & _Bodega & " ' And Pln.TipoPareja = '" & _TipoPareja & "') As Total_Ubicaciones,

                        (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pln
                        Where Pln.Id_Inventario = " & _Id_Inventario & " And Pln.Id_Pareja = " & _Id_Pareja & " And Pln.Empresa = '" & _Empresa & "' And Pln.Sucursal = '" & _Sucursal & "' And Pln.Bodega = '" & _Bodega & " ' And Pln.TipoPareja = '" & _TipoPareja & "' And Contado = 1) As Contadas,

                        (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pln
                        Where Pln.Id_Inventario = " & _Id_Inventario & " And Pln.Id_Pareja = " & _Id_Pareja & " And Pln.Empresa = '" & _Empresa & "' And Pln.Sucursal = '" & _Sucursal & "' And Pln.Bodega = '" & _Bodega & " ' And Pln.TipoPareja = '" & _TipoPareja & "' And Contado = 0) As Pendientes,
                        Cast(0 As Float) As Porc_Avence
                        Into #paso

                        Update #paso Set Porc_Avence = Case When Total_Ubicaciones > 0 Then Contadas/(Total_Ubicaciones*1.0) Else 0 End

                        Select * From #paso

                        Drop Table #paso"

        Dim _Row_Resultado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Total_Ubicaciones As Double = _Row_Resultado.Item("Total_Ubicaciones")
        Dim _Contadas As Double = _Row_Resultado.Item("Contadas")
        Dim _Pendientes As Double = _Row_Resultado.Item("Pendientes")

        Txt_UbicAsignadas.Text = _Total_Ubicaciones
        Txt_UbicContadas.Text = _Contadas

        Txt_PorcAvance.Tag = _Row_Resultado.Item("Porc_Avence")
        Txt_PorcAvance.Text = FormatPercent(Txt_PorcAvance.Tag, 0)

    End Sub


    Private Sub Btn_Agregar_Ubicaciones_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Ubicaciones.Click

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")
        Dim _Bodega = Cmb_Bodegas.SelectedValue

        Dim _Tb = Tabs.Tabs(Tabs.SelectedTabIndex)

        Consulta_sql = "SELECT Id,Id_Inventario,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector,Cerrado," &
                        "Cast(0 As Float) As Ubicaciones,Cast(0 As Float) As Asignadas,Cast(0 As Float) As AsignadasOt,Cast(0 As Float) As SumUbic
                        Into #Paso
                        FROM " & _Global_BaseBk & "Zw_Inv_Sector
                        Where Id_Inventario = " & _Id_Inventario & " And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'

                        Update #Paso Set Ubicaciones = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones Ubic Where #Paso.Id_Inventario = Ubic.Id_Inventario And #Paso.Codigo_Sector = Ubic.Codigo_Sector)
                        Update #Paso Set Asignadas = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pl 
								                        Where #Paso.Id_Inventario = Pl.Id_Inventario And #Paso.Empresa = Pl.Empresa And #Paso.Sucursal = Pl.Sucursal And #Paso.Bodega = Pl.Bodega 
									                        And #Paso.Codigo_Sector = Pl.Codigo_Sector And Pl.TipoPareja = '" & _Tb.Tag & "')
	                    Update #Paso Set AsignadasOt = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pl 
								                        Where #Paso.Id_Inventario = Pl.Id_Inventario And #Paso.Empresa = Pl.Empresa And #Paso.Sucursal = Pl.Sucursal And #Paso.Bodega = Pl.Bodega 
									                        And #Paso.Codigo_Sector = Pl.Codigo_Sector And Pl.TipoPareja <> '" & _Tb.Tag & "') --And Pl.Id_Pareja = " & _Id_Pareja & ")
                        
                        Update #Paso Set SumUbic = Asignadas+AsignadasOt
                        --Select * From #Paso Where (Asignadas+AsignadasOt) <> Ubicaciones -- Ubicaciones <> Asignadas Or Ubicaciones <> AsignadasOt
                        Select * From #Paso Where SumUbic <> (Ubicaciones*2) And Ubicaciones <> Asignadas

                        Drop Table #Paso"

        Consulta_sql = "SELECT Id,Id_Inventario,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector,Cerrado,
	   Cast(0 As Float) As Ubicaciones,
	   Cast(0 As Float) As Asignadas_Mi,
	   Cast(0 As Float) As Asignadas_Otros,
	   Cast(0 As Float) As Asignadas_Mi2,
	   Cast(0 As Float) As Asignadas_Otros2,
	   Cast(0 As Float) As SumUbic
                        Into #Paso
                        FROM " & _Global_BaseBk & "Zw_Inv_Sector
                        Where Id_Inventario = " & _Id_Inventario & " And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'
						--LEVANTE
						--TOMA
                        Update #Paso Set Ubicaciones = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones Ubic Where #Paso.Id_Inventario = Ubic.Id_Inventario And #Paso.Codigo_Sector = Ubic.Codigo_Sector)
                        Update #Paso Set Asignadas_Mi = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pl 
								                        Where #Paso.Id_Inventario = Pl.Id_Inventario And #Paso.Empresa = Pl.Empresa And #Paso.Sucursal = Pl.Sucursal And #Paso.Bodega = Pl.Bodega 
									                        And #Paso.Codigo_Sector = Pl.Codigo_Sector And Pl.TipoPareja = '" & _Tb.Tag & "' And Pl.Id_Pareja = " & _Id_Pareja & ")
                        
						Update #Paso Set Asignadas_Otros = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pl 
								                        Where #Paso.Id_Inventario = Pl.Id_Inventario And #Paso.Empresa = Pl.Empresa And #Paso.Sucursal = Pl.Sucursal And #Paso.Bodega = Pl.Bodega 
									                        And #Paso.Codigo_Sector = Pl.Codigo_Sector And Pl.TipoPareja = '" & _Tb.Tag & "' And Pl.Id_Pareja <> " & _Id_Pareja & ")

	                    Update #Paso Set Asignadas_Mi2 = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pl 
								                        Where #Paso.Id_Inventario = Pl.Id_Inventario And #Paso.Empresa = Pl.Empresa And #Paso.Sucursal = Pl.Sucursal And #Paso.Bodega = Pl.Bodega 
									                        And #Paso.Codigo_Sector = Pl.Codigo_Sector And Pl.TipoPareja <> '" & _Tb.Tag & "' And Pl.Id_Pareja = " & _Id_Pareja & ")

	                    Update #Paso Set Asignadas_Otros2 = (Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Pl 
								                        Where #Paso.Id_Inventario = Pl.Id_Inventario And #Paso.Empresa = Pl.Empresa And #Paso.Sucursal = Pl.Sucursal And #Paso.Bodega = Pl.Bodega 
									                        And #Paso.Codigo_Sector = Pl.Codigo_Sector And Pl.TipoPareja <> '" & _Tb.Tag & "' And Pl.Id_Pareja <> " & _Id_Pareja & ")
                        
                        --Update #Paso Set SumUbic = Asignadas+AsignadasOt
                        --Select * From #Paso Where (Asignadas+AsignadasOt) <> Ubicaciones -- Ubicaciones <> Asignadas Or Ubicaciones <> AsignadasOt
                        --Select * From #Paso
						Delete #Paso Where Asignadas_Mi2 = Ubicaciones 
						--Delete #Paso Where (Asignadas_Ot_Mi+NoAsignadas_Ot_Mi) = Ubicaciones
						Select * From #Paso Where (Asignadas_Mi+Asignadas_Otros) <> Ubicaciones

                        Drop Table #Paso"


        Dim _Tbl_Sectores_Disponbles As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro_Sectores As String = Generar_Filtro_IN(_Tbl_Sectores_Disponbles, "", "Codigo_Sector", False, False, "'")


        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Inv_Sector"
        _Filtrar.Campo = "Codigo_Sector"
        _Filtrar.Descripcion = "Nombre_Sector"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "SECTORES DISPONIBLES"

        Dim _FiltroSql = String.Empty

        If CBool(_Tbl_Sectores_Disponbles.Rows.Count) Then
            _FiltroSql = "And Codigo_Sector In " & _Filtro_Sectores
        End If

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _FiltroSql,
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo_Sector = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Dim _FiltrarUbic As New Clas_Filtros_Random(Me)

            _FiltrarUbic.Tabla = _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones"
            _FiltrarUbic.Campo = "Codigo_Ubic"
            _FiltrarUbic.Descripcion = "Codigo_Ubic"

            _FiltrarUbic.Pro_Nombre_Encabezado_Informe = "UBICACIONES SECTOR " & _Codigo_Sector & " - " & _Descripcion

            _FiltroSql = "And Id_Inventario = " & _Id_Inventario & " And Codigo_Sector = '" & _Codigo_Sector & "'" & vbCrLf &
                         "And Codigo_Ubic Not In (Select Codigo_Ubic From " & _Global_BaseBk & "Zw_Inv_Plan " &
                         "Where Codigo_Sector = '" & _Codigo_Sector & "' And Id_Pareja = " & _Id_Pareja & " And TipoPareja = '" & _Tb.Tag & "')" & vbCrLf &
                         "And Codigo_Ubic Not In (Select Codigo_Ubic From " & _Global_BaseBk & "Zw_Inv_Plan " &
                         "Where Codigo_Sector = '" & _Codigo_Sector & "' And Id_Pareja = " & _Id_Pareja & " And TipoPareja <> '" & _Tb.Tag & "')" & vbCrLf &
                         "And Codigo_Ubic Not In (Select Codigo_Ubic From " & _Global_BaseBk & "Zw_Inv_Plan " &
                         "Where Codigo_Sector = '" & _Codigo_Sector & "' And TipoPareja = '" & _Tb.Tag & "')"

            If _FiltrarUbic.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _FiltroSql,
                                   Nothing, False, False) Then

                Dim _TblSectores As DataTable = _FiltrarUbic.Pro_Tbl_Filtro
                Dim _Todas As Boolean = _FiltrarUbic.Pro_Filtro_Todas

                'If _Todas Then

                '    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Plan (Id_Inventario,Empresa,Sucursal,Bodega,Codigo_Sector,Codigo_Ubic,FechaActivacion,TipoPareja,Id_Pareja) " & vbCrLf &
                '                    "Select " & _Id_Inventario & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo_Sector & "',Codigo_Ubic,Getdate(),'" & _Tb.Tag & "'," & _Id_Pareja & vbCrLf &
                '                    "From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones" & vbCrLf &
                '                    "Where Codigo_Sector = '" & _Codigo_Sector & "' And " &
                '         "Codigo_Ubic Not In (Select Codigo_Ubic From " & _Global_BaseBk & "Zw_Inv_Plan " &
                '        "Where Id_Inventario = " & _Id_Inventario & " And Codigo_Sector = '" & _Codigo_Sector & "' And Id_Pareja = " & _Id_Pareja & " And TipoPareja = '" & _Tb.Tag & "')"

                'Else

                Dim _Filtro_Ubicaciones As String = Generar_Filtro_IN(_TblSectores, "Chk", "Codigo", False, True, "'")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Plan (Id_Inventario,Empresa,Sucursal,Bodega,Codigo_Sector,Codigo_Ubic,FechaActivacion,TipoPareja,Id_Pareja) " & vbCrLf &
                        "Select " & _Id_Inventario & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo_Sector & "',Codigo_Ubic,Getdate(),'" & _Tb.Tag & "'," & _Id_Pareja & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones Where Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic In " & _Filtro_Ubicaciones

                'End If

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    MessageBoxEx.Show(Me, "Ubicaciones incorporadas correctamente", "Plan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Sb_Actualizar_Grilla(_Tb.Tag)
                End If

            End If

        End If

    End Sub

    Private Sub TabToma_Click(sender As Object, e As EventArgs) Handles TabToma.Click
        Sb_Actualizar_Grilla("TOMA")
    End Sub

    Private Sub TabLevante_Click(sender As Object, e As EventArgs) Handles TabLevante.Click
        Sb_Actualizar_Grilla("LEVANTE")
    End Sub

    Private Sub Btn_Quitar_Ubicaciones_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Ubicaciones.Click

        Dim _Empresa = _Row_Inventario.Item("Empresa")
        Dim _Sucursal = _Row_Inventario.Item("Sucursal")
        Dim _Bodega = Cmb_Bodegas.SelectedValue

        Dim _Tb = Tabs.Tabs(Tabs.SelectedTabIndex)

        Consulta_sql = "Select Codigo_Sector From " & _Global_BaseBk & "Zw_Inv_Plan" & vbCrLf &
                       "Where Id_Inventario = " & _Id_Inventario & " And Id_Pareja = " & _Id_Pareja & " And TipoPareja = '" & _Tb.Tag & "'"

        Dim _Tbl_Sectores_Disponbles As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_Sectores_Disponbles.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay ubicaciones que quitar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtro_Sectores As String = Generar_Filtro_IN(_Tbl_Sectores_Disponbles, "", "Codigo_Sector", False, False, "'")

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Inv_Sector"
        _Filtrar.Campo = "Codigo_Sector"
        _Filtrar.Descripcion = "Nombre_Sector"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "SECTORES ASOCIADOS AL PLAN"

        Dim _FiltroSql = String.Empty

        If CBool(_Tbl_Sectores_Disponbles.Rows.Count) Then
            _FiltroSql = "And Codigo_Sector In " & _Filtro_Sectores
        End If

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _FiltroSql,
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo_Sector = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Dim _FiltrarUbic As New Clas_Filtros_Random(Me)

            _FiltrarUbic.Tabla = _Global_BaseBk & "Zw_Inv_Plan"
            _FiltrarUbic.Campo = "Codigo_Ubic"
            _FiltrarUbic.Descripcion = "Codigo_Ubic"

            _FiltrarUbic.Pro_Nombre_Encabezado_Informe = "UBICACIONES SECTOR " & _Codigo_Sector & " - " & _Descripcion

            _FiltroSql = "And Id_Inventario = " & _Id_Inventario & " And Id_Pareja = " & _Id_Pareja & " And TipoPareja = '" & _Tb.Tag & "' " &
                         "And Codigo_Sector = '" & _Codigo_Sector & "'"

            If _FiltrarUbic.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _FiltroSql,
                                   Nothing, False, False) Then

                Dim _TblSectores As DataTable = _FiltrarUbic.Pro_Tbl_Filtro
                Dim _Todas As Boolean = _FiltrarUbic.Pro_Filtro_Todas

                If _Todas Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Plan" & vbCrLf &
                                   "Where Id_Inventario = " & _Id_Inventario & " And Codigo_Sector = '" & _Codigo_Sector & "' " &
                                   "And Id_Pareja = " & _Id_Pareja & " And TipoPareja = '" & _Tb.Tag & "'"

                Else

                    Dim _Filtro_Ubicaciones As String = Generar_Filtro_IN(_TblSectores, "Chk", "Codigo", False, True, "'")

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Plan" & vbCrLf &
                                   "Where Id_Inventario = " & _Id_Inventario & " And Codigo_Sector = '" & _Codigo_Sector & "' " &
                                   "And Id_Pareja = " & _Id_Pareja & " And TipoPareja = '" & _Tb.Tag & "' And Codigo_Ubic In " & _Filtro_Ubicaciones

                End If

                If MessageBoxEx.Show(Me, "¿Confirma quitar esta ubicaciones del plan de trabajo de esta pareja?", "Quitar ubicaciones",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        Sb_Actualizar_Grilla(_Tb.Tag)
                        MessageBoxEx.Show(Me, "Ubicaciones quitadas correctamente", "Plan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            End If

        End If


    End Sub

End Class
