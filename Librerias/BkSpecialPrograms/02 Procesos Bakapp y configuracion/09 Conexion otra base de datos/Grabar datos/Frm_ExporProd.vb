Imports DevComponents.DotNetBar

Public Class Frm_ExporProd

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Public Property Tbl_Bodegas As DataTable
    Public Property Tbl_Listas As DataTable
    'Public Property Tbl_Empresas As DataTable

    Public Property Bodegas_Todas As Boolean
    Public Property Listas_Todas As Boolean
    'Public Property Empresas_Todas As Boolean

    Dim _Cadena_ConexionSQL_Server_BodExterna As String
    Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
    Dim _Row_DbExt_Conexion As DataRow

    Public Sub New(_Cadena_ConexionSQL_Server_BodExterna As String, _Row_DbExt_Conexion As DataRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

        Me._Cadena_ConexionSQL_Server_BodExterna = _Cadena_ConexionSQL_Server_BodExterna
        Me._Row_DbExt_Conexion = _Row_DbExt_Conexion

    End Sub

    Private Sub Frm_ExporProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Chk_GrbProd_Nuevos.Checked = _Row_DbExt_Conexion.Item("GrbProd_Nuevos")
        Chk_GrbEnti_Nuevas.Checked = _Row_DbExt_Conexion.Item("GrbEnti_Nuevas")
        Chk_GrbOCC_Nuevas.Checked = _Row_DbExt_Conexion.Item("GrbOCC_Nuevas")

        Dim _Sql2 As New Class_SQL(_Cadena_ConexionSQL_Server_BodExterna)

        Try
            Consulta_Sql = "Select Cast(1 As Bit) As Chk,EMPRESA+KOSU+KOBO As Codigo, NOKOBO as Descripcion" & vbCrLf &
                           "From TABBO Where EMPRESA+KOSU+KOBO In " & _Row_DbExt_Conexion.Item("GrbProd_Bodegas")
            Tbl_Bodegas = _Sql2.Fx_Get_Tablas(Consulta_Sql, False)
            Lbl_Bodegas.Text = "Bodegas seleccionadas: " & Tbl_Bodegas.Rows.Count
        Catch ex As Exception
            Tbl_Bodegas = Nothing
            Lbl_Bodegas.Text = "Bodegas seleccionadas: 0"
        End Try

        Try
            Consulta_Sql = "Select Cast(1 As Bit) As Chk,KOLT As Codigo,NOKOLT As Descripcion" & vbCrLf &
                       "From TABPP Where KOLT In " & _Row_DbExt_Conexion.Item("GrbProd_Listas")
            Tbl_Listas = _Sql2.Fx_Get_Tablas(Consulta_Sql, False)
            Lbl_Listas.Text = "Listas seleccionadas: " & Tbl_Listas.Rows.Count
        Catch ex As Exception
            Tbl_Listas = Nothing
            Lbl_Listas.Text = "Listas seleccionadas: 0"
        End Try

    End Sub

    Sub Sb_Seleccionar(_Nombre_Control As String)

        Dim _Tabla_Fl As Enum_Tabla_Fl
        Dim _Tbl_Filtro As Object
        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Tabla = String.Empty
        Dim _Campo = String.Empty
        Dim _Descripcion = String.Empty

        Select Case _Nombre_Control

            Case "Rdb_Bodegas_Algunas"
                _Tbl_Filtro = Tbl_Bodegas
                _Tabla_Fl = Enum_Tabla_Fl._Bodegas
            Case "Rdb_Listas_Algunas"
                _Tbl_Filtro = Tbl_Listas
                _Tabla_Fl = Enum_Tabla_Fl._Otra
                _Tabla = "TABPP"
                _Campo = "KOLT"
                _Descripcion = "NOKOLT"
        End Select

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_BodExterna

        Dim Fm As New Frm_Filtro_Especial_Informes(_Tabla_Fl, False,, _Tabla, _Campo, _Descripcion)
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _Tbl_Filtro = Fm.Pro_Tbl_Filtro

            Select Case _Nombre_Control

                Case "Rdb_Bodegas_Algunas"
                    Tbl_Bodegas = _Tbl_Filtro
                Case "Rdb_Listas_Algunas"
                    Tbl_Listas = _Tbl_Filtro

            End Select

        End If

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Id = _Row_DbExt_Conexion.Item("Id")
        Dim _GrbProd_Nuevos As Integer = Convert.ToInt32(Chk_GrbProd_Nuevos.Checked)
        Dim _GrbEnti_Nuevas As Integer = Convert.ToInt32(Chk_GrbEnti_Nuevas.Checked)
        Dim _GrbOCC_Nuevas As Integer = Convert.ToInt32(Chk_GrbOCC_Nuevas.Checked)
        Dim _GrbProd_BodTodas As Integer = Convert.ToInt32(Bodegas_Todas)
        Dim _GrbProd_LisTodas As Integer = Convert.ToInt32(Listas_Todas)
        Dim _GrbProd_Bodegas As String
        Dim _GrbProd_Listas As String

        If Chk_GrbProd_Nuevos.Checked Then
            If IsNothing(Tbl_Bodegas) Then
                MessageBoxEx.Show(Me, "Debe seleccionar las bodegas para la grabación de los productos",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
            If IsNothing(Tbl_Listas) Then
                MessageBoxEx.Show(Me, "Debe seleccionar las listas para la grabación de los productos",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Not Bodegas_Todas Then _GrbProd_Bodegas = Generar_Filtro_IN(Tbl_Bodegas, "", "Codigo", False, False, "'")
        If Not Listas_Todas Then _GrbProd_Listas = Generar_Filtro_IN(Tbl_Listas, "", "Codigo", False, False, "'")

        _GrbProd_Bodegas = Replace(_GrbProd_Bodegas, "'", "''")
        _GrbProd_Listas = Replace(_GrbProd_Listas, "'", "''")

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_DbExt_Conexion Set " &
                       " GrbProd_Nuevos = " & _GrbProd_Nuevos &
                       ",GrbEnti_Nuevas = " & _GrbEnti_Nuevas &
                       ",GrbOCC_Nuevas = " & _GrbOCC_Nuevas &
                       ",GrbProd_Bodegas = '" & _GrbProd_Bodegas & "'" &
                       ",GrbProd_Listas = '" & _GrbProd_Listas & "'" & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Bodegas_Click(sender As Object, e As EventArgs) Handles Btn_Bodegas.Click
        Sb_Seleccionar("Rdb_Bodegas_Algunas")
        Try
            Lbl_Bodegas.Text = "Bodegas seleccionadas: " & Tbl_Bodegas.Rows.Count
        Catch ex As Exception
            Lbl_Bodegas.Text = "Bodegas seleccionadas: 0"
        End Try
    End Sub

    Private Sub Btn_Listas_Click(sender As Object, e As EventArgs) Handles Btn_Listas.Click
        Sb_Seleccionar("Rdb_Listas_Algunas")
        Try
            Lbl_Listas.Text = "Listas seleccionadas: " & Tbl_Listas.Rows.Count
        Catch ex As Exception
            Lbl_Listas.Text = "Listas seleccionadas: 0"
        End Try
    End Sub

End Class
