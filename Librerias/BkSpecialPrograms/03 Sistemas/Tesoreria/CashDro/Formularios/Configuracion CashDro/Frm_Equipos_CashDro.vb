'Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Equipos_CashDro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Informe As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Agregar_Equipo.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Equipos_CashDro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Public Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select NombreEquipo,Funcionario," &
                       "Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = Funcionario),'') As Nom_Funcionario," &
                       "Modalidad,Ip_CashDro,Usuario_CashDro,Contrasena_CashDro,EFV,TJV,NCV," &
                       "Tiempo_Espera,Fase_Prueba,Directorio_Demonio,Tbk_Puerto,Tbk_Tasa_de_baudios,Tbk_Paridad," &
                       "Tbk_Bits_de_parada,Tbk_Bits_de_datos,Tbk_Hexadecimal,Tbk_Texto" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Estaciones_CashDro"

        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, True)


            .Columns("NombreEquipo").HeaderText = "Nombre Equipo"
            .Columns("NombreEquipo").Width = 200
            .Columns("NombreEquipo").Visible = True
            '.Columns("TIDP").DisplayIndex = 0

            .Columns("Funcionario").HeaderText = "Func."
            .Columns("Funcionario").Width = 30
            .Columns("Funcionario").Visible = True
            '.Columns("NUDP").DisplayIndex = 1

            .Columns("Nom_Funcionario").HeaderText = "Nombre funcionario"
            .Columns("Nom_Funcionario").Width = 130
            .Columns("Nom_Funcionario").Visible = True
            '.Columns("FEVEDP").DisplayIndex = 3

            .Columns("Modalidad").HeaderText = "Modalidad"
            .Columns("Modalidad").Width = 80
            .Columns("Modalidad").Visible = True
            '.Columns("FEEMDP").DisplayIndex = 2

            '.Columns("Ip_CashDro").HeaderText = "Vencim."
            '.Columns("Ip_CashDro").Width = 80
            '.Columns("Ip_CashDro").Visible = True
            '.Columns("FEVEDP").DisplayIndex = 3

            '.Columns("Usuario_CashDro").HeaderText = "M."
            '.Columns("Usuario_CashDro").Width = 20
            '.Columns("Usuario_CashDro").Visible = True
            '.Columns("MODP").DisplayIndex = 4

            '.Columns("EFV").Width = 90
            '.Columns("EFV").HeaderText = "Valor"
            '.Columns("EFV").Visible = True
            '.Columns("VADP").DisplayIndex = 5

            '.Columns("TJV").Width = 90
            '.Columns("TJV").HeaderText = "Valor"
            '.Columns("TJV").Visible = True
            '.Columns("VADP").DisplayIndex = 5

            '.Columns("NCV").Width = 90
            '.Columns("NCV").HeaderText = "Valor"
            '.Columns("NCV").Visible = True
            '.Columns("VADP").DisplayIndex = 5

            '.Columns("Tiempo_Espera").Width = 90
            '.Columns("Tiempo_Espera").HeaderText = "Estado"
            '.Columns("Tiempo_Espera").Visible = True
            '.Columns("ESTADO").DisplayIndex = 6

            '.Columns("Fase_Prueba").HeaderText = "Nro. doc. pago"
            '.Columns("Fase_Prueba").Width = 90
            '.Columns("Fase_Prueba").Visible = True
            '.Columns("NUCUDP").DisplayIndex = 7

            '.Columns("Directorio_Demonio").HeaderText = "Nro Cta.Cte."
            '.Columns("Directorio_Demonio").Width = 100
            '.Columns("Directorio_Demonio").Visible = True
            '.Columns("CTACTE").DisplayIndex = 8

            '.Columns("Tbk_Puerto").HeaderText = "Suc."
            '.Columns("Tbk_Puerto").Width = 30
            '.Columns("Tbk_Puerto").Visible = True
            '.Columns("SUREDP").DisplayIndex = 9

            '.Columns("Tbk_Tasa_de_baudios").HeaderText = "Suc."
            '.Columns("Tbk_Tasa_de_baudios").Width = 30
            '.Columns("Tbk_Tasa_de_baudios").Visible = True
            '.Columns("SUREDP").DisplayIndex = 9

            '.Columns("Tbk_Paridad").HeaderText = "Suc."
            '.Columns("Tbk_Paridad").Width = 30
            '.Columns("Tbk_Paridad").Visible = True
            '.Columns("SUREDP").DisplayIndex = 9

            '.Columns("Tbk_Bits_de_parada").HeaderText = "Suc."
            '.Columns("Tbk_Bits_de_parada").Width = 30
            '.Columns("Tbk_Bits_de_parada").Visible = True
            '.Columns("SUREDP").DisplayIndex = 9

            '.Columns("Tbk_Bits_de_datos").HeaderText = "Suc."
            '.Columns("Tbk_Bits_de_datos").Width = 30
            '.Columns("Tbk_Bits_de_datos").Visible = True
            '.Columns("SUREDP").DisplayIndex = 9

            '.Columns("Tbk_Modo").HeaderText = "Suc."
            '.Columns("Tbk_Modo").Width = 30
            '.Columns("Tbk_Modo").Visible = True
            '.Columns("SUREDP").DisplayIndex = 9

        End With

        'Lbl_Entidad.DataBindings.Add(New System.Windows.Forms.Binding("Text", _Tbl_Informe, "NOKOEN", True))

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _NombreEquipo As String = Trim(_Fila.Cells("NombreEquipo").Value)

        Dim Fm As New Frm_Equipos_CashDro_Equipo(_NombreEquipo)
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Agregar_Equipo_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Equipo.Click

        'Dim _Row_Estacion As DataRow
        'Dim Fm As New Frm_RegistrarEquipo_Listado(False)
        'Fm.ShowDialog(Me)
        '_Row_Estacion = Fm.Pro_Row_Estacion_Seleccionada
        'Fm.Dispose()

        'If Not IsNothing(_Row_Estacion) Then
        'End If

        Dim _Tbl_Estaciones As DataTable

        Dim _Sql_Filtro_Condicion_Extra = "And NombreEquipo Not In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_CashDro)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        _Filtrar.Ver_Codigo = False
        Dim _SqlQuery = String.Empty

        If _Filtrar.Fx_Filtrar(_Tbl_Estaciones,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Estaciones_Bk, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Estaciones = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                _SqlQuery = "Insert Into " & _Global_BaseBk & "Zw_Estaciones_CashDro (NombreEquipo) " &
                            "Select NombreEquipo From " & _Global_BaseBk & "Zw_EstacionesBkp" & Space(1) &
                            "Where NombreEquipo Not In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_CashDro) "
            Else
                Dim _Filtro_Id As String = Generar_Filtro_IN(_Tbl_Estaciones, "Chk", "Codigo", False, False, "")
                _SqlQuery = "Insert Into " & _Global_BaseBk & "Zw_Estaciones_CashDro (NombreEquipo) " &
                            "Select NombreEquipo From " & _Global_BaseBk & "Zw_EstacionesBkp" & Space(1) &
                            "Where Id In " & _Filtro_Id
            End If

            If Not String.IsNullOrEmpty(_SqlQuery) Then
                _Sql.Ej_consulta_IDU(_SqlQuery)
                Sb_Actualizar_Grilla()
            End If

        End If

    End Sub

    Private Sub Grilla_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla.MouseDown
        Return
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_01)

                End If
            End With
        End If

    End Sub

    Private Sub Btn_Editar_Equipo_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Equipo.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Quitar_Equipo_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Equipo.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _NombreEquipo As String = Trim(_Fila.Cells("NombreEquipo").Value)


    End Sub

End Class
