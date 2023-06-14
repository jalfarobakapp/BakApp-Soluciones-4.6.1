Imports DevComponents.DotNetBar

Public Class Frm_Dem_Imprimir_Conf

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Dem_Imprimir_Conf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Parametros_Informe_Sql(False)
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Sb_Parametros_Informe_Sql(True)
        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _Actualizar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                           "Where Informe = 'Demonio_Impresion' And NombreEquipo = '" & _NombreEquipo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        _Sql.Sb_Parametro_Informe_Sql(Chk_ImprimirDocumentos, "Demonio_Impresion",
                                      Chk_ImprimirDocumentos.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ImprimirDocumentos.Checked, _Actualizar, "Demonio")

        _Sql.Sb_Parametro_Informe_Sql(Chk_ImprimirPicking, "Demonio_Impresion",
                                      Chk_ImprimirPicking.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ImprimirPicking.Checked, _Actualizar, "Demonio")

        _Sql.Sb_Parametro_Informe_Sql(Chk_Ejecutar_Automaticamente, "Demonio_Impresion",
                                      Chk_Ejecutar_Automaticamente.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_Ejecutar_Automaticamente.Checked, _Actualizar, "Demonio")

        _Sql.Sb_Parametro_Informe_Sql(Input_SegundosImpresion, "Demonio_Impresion",
                                      Input_SegundosImpresion.Name, Class_SQLite.Enum_Type._Double,
                                      Input_SegundosImpresion.Value, _Actualizar, "Demonio")

    End Sub

End Class
