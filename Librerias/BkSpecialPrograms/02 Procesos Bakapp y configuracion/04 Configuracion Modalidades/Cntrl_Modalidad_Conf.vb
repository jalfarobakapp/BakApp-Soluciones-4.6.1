'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Cntrl_Modalidad_Conf

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public FmPrincipal As Metro.MetroAppForm
    Dim _TblModalidades As DataTable

    Sub Sb_Actualizar_Grilla_Conf()

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Configuracion (Modalidad) 
                        Select MODALIDA From CONFIEST Where MODALIDAD Not In (Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion)"
        '_Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = "Select MODALIDAD,(Select NOKOSU FROM TABSU Z2 " & _
                       "WHERE Z2.EMPRESA = Z1.EMPRESA AND Z2.KOSU = Z1.ESUCURSAL) AS Sucursal," & _
                       "EBODEGA as Bodega" & vbCrLf & _
                       "From CONFIEST Z1 Where EMPRESA = '" & ModEmpresa & "'" & vbCrLf & _
                       "And MODALIDAD <> '  '"

        With Grilla

            .DataSource = _SQL.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Modalidad").Width = 80
            .Columns("Modalidad").HeaderText = "Modalidad"
            .Columns("Modalidad").Visible = True
            .Columns("Modalidad").DisplayIndex = 0

            .Columns("Sucursal").Width = 250
            .Columns("Sucursal").HeaderText = "Sucursal"
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").DisplayIndex = 1

            .Columns("Bodega").Width = 60
            .Columns("Bodega").HeaderText = "Bodega"
            .Columns("Bodega").Visible = True
            .Columns("Bodega").DisplayIndex = 2

        End With

    End Sub

    Private Sub Cntrl_Modalidad_Conf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla_Conf()
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Ver_Modalidad()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        FmPrincipal.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        Me.Dispose()
    End Sub


    Private Sub Btn_Ver_Modalidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Modalidad.Click
        If CBool(Grilla.SelectedRows.Count) Then
            Sb_Ver_Modalidad()
        Else
            MessageBoxEx.Show(FmPrincipal, "No hay ninguna empresa seleccionada", "Conectar empresa", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Sub Sb_Ver_Modalidad()

        Dim _Modalidad = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Modalidad").Value

        Dim _Clas_Mod As New Clas_Modalidades
        Dim _RowModalidad As DataRow = _Clas_Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, _Modalidad)

        Dim _Fila As DataRow = _SQL.Fx_Get_DataTable(Consulta_sql).Rows(0)

        If Not IsNothing(_Fila) Then

            Dim NewPanel As Cntrl_Configuracion_General = Nothing
            NewPanel = New Cntrl_Configuracion_General(FmPrincipal, _RowModalidad, False)
            FmPrincipal.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        Else

            MessageBoxEx.Show(Me, "Cierre el sistema y vuelva a ingresar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

End Class
