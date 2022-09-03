Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Rc_02_Revision_Cam_Tipo_Reclamo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id_Reclamo As Integer
    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Grabar As Boolean
    Dim _Aceptado As Boolean
    Dim _Rechazado As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub Frm_Rc_02_Revision_Cam_Tipo_Reclamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Id_Reclamo = _Cl_Reclamo.Id_Reclamo

        caract_combo(Cmb_Tipo_Reclamo)
        Consulta_Sql = "Select '' As Padre,'' As Hijo,0 As Orden Union
                        SELECT CodigoTabla AS Padre,NombreTabla AS Hijo,Orden
                        FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones
                        WHERE Tabla = 'SIS_RECLAMOS_TIPO' ORDER BY Orden"
        Cmb_Tipo_Reclamo.DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)
        Cmb_Tipo_Reclamo.SelectedValue = String.Empty

        AddHandler Cmb_Tipo_Reclamo.SelectedIndexChanged, AddressOf Sb_Cmb_Tipo_Reclamos_SelectedIndexChanged

        Cmb_Tipo_Reclamo.SelectedValue = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")
        Sb_Llenar_Combo_Sub_Tipo_Reclamos(Cmb_Tipo_Reclamo.SelectedValue)
        Cmb_Sub_Tipo_Reclamos.SelectedValue = _Cl_Reclamo.Pro_Row_Reclamo.Item("Sub_Tipo_Reclamo")

    End Sub

    Private Sub Btn_Rechazar_Click(sender As Object, e As EventArgs) Handles Btn_Rechazar.Click

        MessageBoxEx.Show(Me, "Debera indicar a que departamente enviara el reclamo", "Cambiar tipo de reclamo",
                         MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim Sql_Filtro_Condicion_Extra = "And Tabla = 'SIS_RECLAMOS_TIPO' 
                                          And CodigoTabla <> '" & _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo") & "'"

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra, False)
        'Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        Fm.Pro_Campo = "CodigoTabla"
        Fm.Pro_Descripcion = "NombreTabla"
        Fm.Pro_Sql_Filtro_Condicion_Extra = Sql_Filtro_Condicion_Extra
        Fm.Pro_Seleccionar_Todo = False
        Fm.Pro_Seleccionar_Solo_Uno = True
        Fm.Text = "TIPO DE RECLAMO"
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            Dim _Tbl_Filtro = Fm.Pro_Tbl_Filtro
            Dim _Tipo_Reclamo = _Tbl_Filtro.Rows(0).Item("Codigo")

            Dim _Observacion = "Se cambia de estado. Estado anterior: " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_De_Reclamo")

            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Reclamo_Estados Where Id_Reclamo = " & _Id_Reclamo & " And Estado = 'RVE'
                            Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values " &
                            "(" & _Id_Reclamo & ",'RVE','" & FUNCIONARIO & "','" & _Observacion & "')
                            Update " & _Global_BaseBk & "Zw_Reclamo Set Tipo_Reclamo = '" & _Tipo_Reclamo & "' 
                            Where Id_Reclamo = " & _Id_Reclamo
            _Rechazado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

            If _Rechazado Then
                ' ENVIAR CORREO
                _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                _Cl_Reclamo.Sb_Enviar_Correo(Me, "RVE", _Tipo_Reclamo, True)
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Sb_Cmb_Tipo_Reclamos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Llenar_Combo_Sub_Tipo_Reclamos("")
    End Sub

    Sub Sb_Llenar_Combo_Sub_Tipo_Reclamos(ByVal _Codigo As String)

        Consulta_Sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf &
                       "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'SIS_RECLAMOS_SUBTIPO' And Padre_Tabla = 'SIS_RECLAMOS_TIPO' And Padre_CodigoTabla = '" & Cmb_Tipo_Reclamo.SelectedValue & "'" & vbCrLf &
                       "Order by Padre"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        caract_combo(Cmb_Sub_Tipo_Reclamos)
        Cmb_Sub_Tipo_Reclamos.DataSource = _Tbl
        Cmb_Sub_Tipo_Reclamos.SelectedValue = _Codigo

    End Sub


End Class