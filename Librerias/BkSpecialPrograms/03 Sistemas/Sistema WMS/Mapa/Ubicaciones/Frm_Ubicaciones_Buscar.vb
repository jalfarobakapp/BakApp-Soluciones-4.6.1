Imports DevComponents.DotNetBar
Imports Funciones_BakApp

Public Class Frm_Ubicaciones_Buscar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblSectores As DataTable
    Dim _RowSector As DataRow

    Public Property BuscarUbicGrilla As Boolean
    Public Property Codigo_Sector As String

    Public ReadOnly Property Pro_RowSector() As DataRow
        Get
            Return _RowSector
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion_Ubicacion.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Ubicaciones_Buscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Buscar_Ubicacion(Txt_Descripcion_Ubicacion.Text)

        If BuscarUbicGrilla Then
            BuscarDatoEnGrilla(Codigo_Sector, "Codigo_Sector", Grilla)
        End If

    End Sub

    Sub Sb_Buscar_Ubicacion(ByVal _Sector As String)

        '"KOPR+NOKOPR LIKE '%", "And"))
        Dim _Cadena As String = CADENA_A_BUSCAR(_Sector, "BS Like '%")

        Consulta_sql = "Select Distinct Empresa,Sucursa,Bodega,Codigo_Sector,Nombre_Sector," & vbCrLf &
                       "(Select COUNT(Distinct Fila) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Zu Where Zu.Codigo_Sector = Zs.Codigo_Sector) As Filas," & vbCrLf &
                       "(Select COUNT(Distinct Columna) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Zu Where Zu.Codigo_Sector = Zs.Codigo_Sector) As Columnas" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Zs" & vbCrLf &
                       "Where Tipo_Objeto = 'SECTOR' And Codigo_Sector+Nombre_Sector Like '%" & _Cadena & "%'" & vbCrLf &
                       "Order By Codigo_Sector"

        Consulta_sql = "Select Distinct Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Nombre_Sector," & vbCrLf &
                       "(Select Top 1 Nombre_Mapa " &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Zm Where Zm.Id_Mapa = Zs.Id_Mapa) As Nombre_Mapa," & vbCrLf &
                       "(Select Top 1 Nombre_Mapa " &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Zm Where Zm.Id_Mapa = Zs.Id_Mapa)+' '+Nombre_Sector+' '+Codigo_Sector as BS," & vbCrLf &
                       "(Select COUNT(Distinct Fila) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Zu Where Zu.Codigo_Sector = Zs.Codigo_Sector) As Filas," & vbCrLf &
                       "(Select COUNT(Distinct Columna) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Zu Where Zu.Codigo_Sector = Zs.Codigo_Sector) As Columnas" & vbCrLf &
                       "Into #Paso_Ub" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Zs" & vbCrLf &
                       "Where Tipo_Objeto = 'SECTOR'" & vbCrLf &
                       "And Nombre_Sector <> ''" & vbCrLf &
                       "Order By Codigo_Sector" & vbCrLf &
                       vbCrLf &
                       "Select * From #Paso_Ub" & vbCrLf &
                       "Where BS Like '%" & _Cadena & "%'" & vbCrLf &
                       "Drop table #Paso_Ub"

        _TblSectores = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _TblSectores

            OcultarEncabezadoGrilla(Grilla, False, , False)

            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Width = 30
            .Columns("Empresa").Visible = True

            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").Visible = True

            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Width = 30
            .Columns("Bodega").Visible = True

            .Columns("Codigo_Sector").HeaderText = "Código"
            .Columns("Codigo_Sector").Width = 100
            .Columns("Codigo_Sector").Visible = True

            .Columns("Nombre_Sector").HeaderText = "Sector"
            .Columns("Nombre_Sector").Width = 250
            .Columns("Nombre_Sector").Visible = True

            '.Columns("BS").HeaderText = "Sector"
            '.Columns("BS").Width = 250
            '.Columns("BS").Visible = True

            .Columns("Filas").HeaderText = "Filas"
            .Columns("Filas").Width = 50
            .Columns("Filas").Visible = True

            .Columns("Columnas").HeaderText = "Columnas"
            .Columns("Columnas").Width = 50
            .Columns("Columnas").Visible = True

        End With

    End Sub

    Private Sub Txt_Descripcion_Ubicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Descripcion_Ubicacion.TextChanged
        If String.IsNullOrWhiteSpace(Txt_Descripcion_Ubicacion.Text) Then
            Sb_Buscar_Ubicacion(Trim(Txt_Descripcion_Ubicacion.Text))
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Codigo_Secto = _Fila.Cells("Codigo_Sector").Value

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Where Codigo_Sector = '" & _Codigo_Secto & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then
            _RowSector = _Tbl.Rows(0)
            Me.Close()
        End If

    End Sub

    Private Sub Frm_Ubicaciones_Buscar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txt_Descripcion_Ubicacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion_Ubicacion.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Space Then
            Sb_Buscar_Ubicacion(Trim(Txt_Descripcion_Ubicacion.Text))
        End If
    End Sub
End Class
