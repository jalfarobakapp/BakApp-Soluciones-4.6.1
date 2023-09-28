Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Meson_ObsXMaq

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idpotpr As Integer

    Public Sub New(_Idpotpr As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Idpotpr = _Idpotpr

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Meson_ObsXMaq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_ActualizarGrilla()
    End Sub

    Sub Sb_ActualizarGrilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpotpr = " & _Idpotpr
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            Grilla.DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla)

            .Columns("Obrero").Visible = True
            .Columns("Obrero").HeaderText = "Leído por"
            .Columns("Obrero").Width = 100
            .Columns("Obrero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Hora_Inicio").Visible = True
            .Columns("Fecha_Hora_Inicio").HeaderText = "F.H. Inicio"
            .Columns("Fecha_Hora_Inicio").ToolTipText = "Fecha hora Inicio"
            .Columns("Fecha_Hora_Inicio").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm"
            .Columns("Fecha_Hora_Inicio").Width = 100
            .Columns("Fecha_Hora_Inicio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Hora_Termino").Visible = True
            .Columns("Fecha_Hora_Termino").HeaderText = "F.H. Termino"
            .Columns("Fecha_Hora_Termino").ToolTipText = "Fecha hora termino"
            .Columns("Fecha_Hora_Termino").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm"
            .Columns("Fecha_Hora_Termino").Width = 100
            .Columns("Fecha_Hora_Termino").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Observacion").Visible = True
            .Columns("Observacion").HeaderText = "Observación"
            .Columns("Observacion").Width = 630
            .Columns("Observacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub

End Class
