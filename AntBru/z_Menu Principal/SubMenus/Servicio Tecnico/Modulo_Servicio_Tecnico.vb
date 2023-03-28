Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_Servicio_Tecnico

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

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


    Private Sub Btn_CRV_Control_Ruta_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Configuraciones.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0019") Then
            Dim NewPanel As STConfiguracion = Nothing
            NewPanel = New STConfiguracion(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
        End If
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

    Private Sub Btn_Sis_Serv_GestTaller_Click(sender As Object, e As EventArgs) Handles Btn_Sis_Serv_GestTaller.Click

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Dim _Aceptar As Boolean
        Dim _PwTecnico As String

        _Aceptar = InputBox_Bk(_Fm_Menu_Padre, "INGRESE SU CLAVE DE USUARIO", "INGRESAR A GESTION DEL TALLER",
                               _PwTecnico, False, _Tipo_Mayus_Minus.Normal, 5, True, _Tipo_Imagen.Key,, _Tipo_Caracter.Solo_Numeros_Enteros, False, "*")

        If Not _Aceptar Then
            Return
        End If

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller Where PwTecnico = '" & _PwTecnico & "'"
        Dim _Row_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row_Funcionario) Then
            MessageBoxEx.Show(Me, "Clave desconocida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Sis_Serv_GestTaller_Click(Nothing, Nothing)
            Return
        End If

        Dim Fm As New Frm_St_GestionTaller(_Row_Funcionario.Item("CodFuncionario"))
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
