Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_Servicio_Tecnico

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub
    Private Sub Modulo_Servicio_Tecnico_Load(sender As Object, e As EventArgs) Handles Me.Load
        Sb_Actualizar_Estados_BD_Servicio_Tecnico()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Sis_Serv_Tecnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sis_Serv_Tecnico.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0001") Then
            Dim Fm As New Frm_St_Ordenes_de_trabajo
            Fm.Pro_Tbl_Informe = Nothing
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub


    Private Sub Btn_CRV_Control_Ruta_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CRV_Control_Ruta_Vehiculos.Click
        Dim NewPanel As CRV_Control_Ruta_Vehiculos = Nothing
        NewPanel = New CRV_Control_Ruta_Vehiculos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub

    Sub Sb_Actualizar_Estados_BD_Servicio_Tecnico()

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Dim _Tabla = "ESTADOS_ST"
        Dim _DescripcionTabla = "Datos de estado para Sis.Serv. Tecnico"

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','I','INGRESADO')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','A','ASIGNADO')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','P','PRESUPUESTO')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','C','COTIZACION')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','R','REPARACION Y CIERRE')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','V','AVISO')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','F','FACTURADO / GDI')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','E','ENTREGADO')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','CE','CERRADO')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','N','NULA')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

    End Sub


End Class
