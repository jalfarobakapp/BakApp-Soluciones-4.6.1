Imports DevComponents.DotNetBar
Imports Bk_Produccion
Imports BkSpecialPrograms

Public Class Produccion

    Private Sub Produccion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Sb_Actualizar_Estados_BD_Produccion()
    End Sub

    Private Sub Btn_DFA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_DFA.Click
        Dim Fm As New Frm_DFA_Ingreso
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Imprimir_Hoja_Ruta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Hoja_Ruta.Click
        Dim Fm As New Frm_Impresion_Pruebas_SubOT
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Informes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informes.Click
        Dim NewPanel As Produccion_Informes = Nothing
        NewPanel = New Produccion_Informes
        Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Mesones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mesones.Click
        Dim NewPanel As Produccion_Mesones = Nothing
        NewPanel = New Produccion_Mesones
        Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub MetroTileItem1_Click(sender As Object, e As EventArgs) Handles MetroTileItem1.Click

        MessageBoxEx.Show(Me, "En construcción", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return

        Dim NewPanel As Servicio_Tecnico_Mesones = Nothing
        NewPanel = New Servicio_Tecnico_Mesones
        Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Sub Sb_Actualizar_Estados_BD_Produccion()

        ' ACA HAY QUE PONER LOS TIPOS DE DAATOS PARA EL SISTEMA

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Dim _Tabla = "PD_MAQ_ESTADOS"
        Dim _DescripcionTabla = "Estados de las maquinas en producción"

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','EMQ','En maquinaEn maquina')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','FMQ','Fuera de maquina')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)


        _Tabla = "PD_MESON_ESTADOS"
        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','FZ','Finalizado enviado otro meson')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','MQ ','En maquina')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','PD','Pendiente')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','TE','Fabricado Pdte. envio otro meson')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)


    End Sub


End Class
