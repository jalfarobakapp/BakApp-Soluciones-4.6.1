Imports DevComponents.DotNetBar

Public Class Frm_PuertosXEtiquetaXEstacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Registros As DataTable
    Dim _NombreEquipo As String
    Public Property Grabar As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Sb_Formato_Generico_Grilla(Grilla, 17, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, True, False, False)

    End Sub

    Private Sub Frm_PuertosXEtiquetaXEstacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Semilla,NombreEtiqueta,TIPO,CAMPO,FUNCION,CantPorLinea,Isnull(Est.Id,0) As Id_Est,Isnull(Est.Puerto,'') As Puerto" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Tbl_DisenoBarras" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Tbl_DisenoBarras_SalPtoxEstacion Est On Semilla_Padre = Semilla And NombreEquipo = '" & _NombreEquipo & "'"

        _Tbl_Registros = _Sql.Fx_Get_DataTable(Consulta_sql)

        Try

            With Grilla

                .DataSource = _Tbl_Registros

                OcultarEncabezadoGrilla(Grilla)

                .Columns("NombreEtiqueta").Width = 420 + 60
                .Columns("NombreEtiqueta").HeaderText = "Nombre etiqueta"
                .Columns("NombreEtiqueta").Visible = True

                .Columns("Puerto").Width = 60
                .Columns("Puerto").HeaderText = "Puerto"
                .Columns("Puerto").Visible = True

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "PUEROS DE SALIDA DE IMPRESION"

        Dim _FiltroExtra As String = "And Tabla = 'SALIDAS_LPT'"

        Dim _Tbl As DataTable

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _FiltroExtra, Nothing, False, True) Then

            _Fila.Cells("Puerto").Value = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl_Registros.Rows

            If Not String.IsNullOrEmpty(_Fila.Item("Puerto")) Then
                If CBool(_Fila.Item("Id_Est")) Then
                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_Tbl_DisenoBarras_SalPtoxEstacion Set Puerto = '" & _Fila.Item("Puerto") & "' Where Id = " & _Fila.Item("Id_Est") & vbCrLf
                Else
                    Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Tbl_DisenoBarras_SalPtoxEstacion (Semilla_Padre,NombreEquipo,Puerto) Values " &
                                    "(" & _Fila.Item("Semilla") & ",'" & _NombreEquipo & "','" & _Fila.Item("Puerto") & "')" & vbCrLf
                End If
            End If

        Next

        If Not String.IsNullOrEmpty(Consulta_sql) Then

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Grabar = True
                Me.Close()
            End If

        End If

    End Sub

End Class
