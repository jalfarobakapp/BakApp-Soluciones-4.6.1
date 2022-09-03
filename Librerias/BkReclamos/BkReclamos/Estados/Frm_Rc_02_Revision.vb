Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Public Class Frm_Rc_02_Revision

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id_Reclamo As Integer
    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Grabar As Boolean
    Dim _Aceptado As Boolean
    Dim _Rechazado As Boolean

    Public Property Pro_Cl_Reclamo As Cl_Reclamo
        Get
            Return _Cl_Reclamo
        End Get
        Set(value As Cl_Reclamo)
            _Cl_Reclamo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public ReadOnly Property Pro_Aceptado As Boolean
        Get
            Return _Aceptado
        End Get
    End Property
    Public ReadOnly Property Pro_Rechazado As Boolean
        Get
            Return _Rechazado
        End Get
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Rc_02_Revision_Load(sender As Object, e As EventArgs) Handles Me.Load

        _Id_Reclamo = _Cl_Reclamo.Id_Reclamo

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")

        Dim _Permiso = "RclRes" & _Tipo_Reclamo

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'RCI' 
                            Where Id_Reclamo = " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo") & vbCrLf &
                            "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario) Values " &
                            "(" & _Id_Reclamo & ",'RCI','" & FUNCIONARIO & "')"

            _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

            If _Grabar Then

                _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                _Aceptado = True
                Me.Close()

            End If

        End If

    End Sub
    Private Sub Btn_Rechazar_Click(sender As Object, e As EventArgs) Handles Btn_Rechazar.Click

        If Fx_Tiene_Permiso(Me, "Rcl00019") Then

            Dim _Sql_Filtro_Condicion_Extra = "And Tabla = 'SIS_RECLAMOS_TIPO' 
                                           And CodigoTabla <> '" & _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo") & "'"

            Dim _Tipo_Reclamo As String
            Dim _Sub_Tipo_Reclamo As String

            MessageBoxEx.Show(Me, "Debera indicar a que departamento enviara el reclamo", "Cambiar tipo de reclamo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            If Fx_Trae_Tipo_Reclamo(_Tipo_Reclamo, _Sql_Filtro_Condicion_Extra, "TIPO RECLAMO") Then

                MessageBoxEx.Show(Me, "Debera indicar el Sub-Tipo de reclamo", "Cambiar tipo de reclamo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Sql_Filtro_Condicion_Extra = "And Tabla = 'SIS_RECLAMOS_SUBTIPO' 
                                           And Padre_Tabla = 'SIS_RECLAMOS_TIPO' And Padre_CodigoTabla ='" & _Tipo_Reclamo & "'"

                If Fx_Trae_Tipo_Reclamo(_Sub_Tipo_Reclamo, _Sql_Filtro_Condicion_Extra, "SUB-TIPO RECLAMO") Then

                    Dim _Observacion = "Se cambia de estado. Estado anterior: " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_De_Reclamo")

                    Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Reclamo_Estados Where Id_Reclamo = " & _Id_Reclamo & " And Estado = 'RVE'
                                Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values " &
                                    "(" & _Id_Reclamo & ",'RVE','" & FUNCIONARIO & "','" & _Observacion & "')
                                Update " & _Global_BaseBk & "Zw_Reclamo Set Tipo_Reclamo = '" & _Tipo_Reclamo & "',Sub_Tipo_Reclamo = '" & _Sub_Tipo_Reclamo & "' 
                                Where Id_Reclamo = " & _Id_Reclamo
                    _Rechazado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

                    If _Rechazado Then

                        ' ENVIAR CORREO
                        _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                        _Cl_Reclamo.Sb_Enviar_Correo(Me, "RVE", _Tipo_Reclamo, True)
                        Me.Close()

                    End If

                End If

            End If

        End If

    End Sub

    Function Fx_Trae_Tipo_Reclamo(ByRef _Codigo As String,
                                  _Sql_Filtro_Condicion_Extra As String,
                                  _Form_Text As String) As Boolean

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra, False)
        Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        Fm.Pro_Campo = "CodigoTabla"
        Fm.Pro_Descripcion = "NombreTabla"
        Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
        Fm.Pro_Seleccionar_Todo = False
        Fm.Pro_Seleccionar_Solo_Uno = True
        Fm.Text = _Form_Text '"TIPO DE RECLAMO"

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            Dim _Tbl_Filtro = Fm.Pro_Tbl_Filtro
            _Codigo = _Tbl_Filtro.Rows(0).Item("Codigo")
            Return True

        End If

    End Function


End Class