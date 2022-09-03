'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Tablas_Clasificaciones_Pro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub Btn_Marcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marcas.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00016") Then

            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Marcas,
                                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "MARCAS"
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub BtnTablasFamilias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTablasFamilias.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00001") Then
            Dim Fm As New Frm_Familias_Lista(Frm_Familias_Lista.Enum_Tipo_Vista_Familias.Super_Familias)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Clasificacion_Libre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Clasificacion_Libre.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00020") Then

            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Claslibre, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "CLASIFICACION LIBRE"
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Zonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Zonas.Click
        MessageBoxEx.Show(Me, "En desarrollo")
        Return
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00018") Then
            'Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado
            'Fm._CodTablaClass = "ZONAS"
            'Fm.Text = "ZONAS"
            'Fm.ShowDialog(Me)
        End If
    End Sub

    Private Sub Btn_Rubros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rubros.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00017") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Rubros, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "RUBROS"
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Arbol_Clasificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Arbol_Clasificaciones.Click

        Dim NewPanel As Arbol_Clasificaciones = Nothing
        NewPanel = New Arbol_Clasificaciones(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Actualizar_Tablas_BakApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Tablas_BakApp.Click

        Dim _Sql_Class As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "Where Tabla In ('ARTICULO','COLOR','MEDIDA','MARCAS','RUBROS','CLALIBPR','CLASLIBRE'," & _
                       "'ACTIVIDADE','TIPOENTIDA','TAMA¥OEMPR','CARGOS','AREASACTIV','TRANSPORTE')" & vbCrLf & vbCrLf & _
                       "-- ARTICULO" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'ARTICULO','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'ARTICULO'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- COLOR" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'COLOR','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'COLOR'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- MEDIDA" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'MEDIDA','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'MEDIDA'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- MARCAS" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "Select 'MARCAS','', KOMR, NOKOMR,rank() OVER (ORDER BY KOMR) as Orden,0,0,0 " & _
                       "From TABMR Order By Orden" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- RUBROS" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "Select 'RUBROS','', KORU, NOKORU,rank() OVER (ORDER BY KORU) as Orden,0,0,0 " & _
                       "From TABRU Order By Orden" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- ACTIVIDAD ECONOMICA ENTIDAD" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'ACTIVIDADE','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'ACTIVIDADE'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- CLASIFICACION LIBRE" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'CLALIBPR','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'CLALIBPR'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- TIPO ENTIDAD" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'TIPOENTIDA','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'TIPOENTIDA'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- TAMAÑO EMPRESA" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'TAMA¥OEMPR','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'TAMA¥OEMPR'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- CARGOS" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'CARGOS','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'CARGOS'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- AREAS ACTIVIDAD ENTIDADES" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'AREASACTIV','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'AREASACTIV'" & _
                       vbCrLf & _
                       vbCrLf & _
                       "-- TRANSPORTE" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo)" & vbCrLf & _
                       "SELECT 'TRANSPORTE','',KOCARAC,NOKOCARAC,rank() OVER (ORDER BY KOTABLA,KOCARAC) as Orden,0,0,0  FROM TABCARAC " & _
                       "WHERE KOTABLA = 'TRANSPORTE'"

        If _Sql_Class.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar tablas del sistema", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBoxEx.Show(Me, "Transacción desecha", "SQL-Trans", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

End Class
