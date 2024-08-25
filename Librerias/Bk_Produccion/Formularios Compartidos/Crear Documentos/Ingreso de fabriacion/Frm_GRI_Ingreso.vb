Imports BkSpecialPrograms

Public Class Frm_GRI_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _VersionBakappExe As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_GRI_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Btn_FabMezcla.Visible = True
        Btn_FabMezcla.Enabled = True

        Dim _elPath = AppPath() & "\BakApp_Soluciones.exe"

        Try
            Dim fvi As System.Diagnostics.FileVersionInfo =
        System.Diagnostics.FileVersionInfo.GetVersionInfo(_elPath)

            _VersionBakappExe = "Versión BakApp: " & fvi.FileVersion & ", "
        Catch ex As Exception
            _VersionBakappExe = String.Empty
        End Try

        Lbl_Estatus.Text = _VersionBakappExe

    End Sub

    Private Sub Btn_Ingresar_GRI_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_GRI.Click

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(Me)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim _Old_Funcionario = FUNCIONARIO
        Dim _Aceptar As Boolean

        Dim Fml As New Frm_Login
        Fml.ValidarPermiso = True
        Fml.Permiso = "Doc00086"
        Fml.ShowDialog()
        _Aceptar = Fml.Aceptar
        Fml.Dispose()

        If Not _Aceptar Then
            Return
        End If

        Dim Frm_Modalidad As New Frm_Modalidades(False)
        Frm_Modalidad.ShowDialog()
        Frm_Modalidad.Dispose()

        Dim Fm As New Frm_GRI_FabXProducto
        Fm.ShowDialog(Me)
        Fm.Dispose()

        FUNCIONARIO = _Old_Funcionario

    End Sub

    Private Sub Btn_ImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirEtiquetas.Click

        Dim Fm As New Frm_ImpBarras_Tarja
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Function Fx_Buscar_Potl(_Idpote As Integer) As DataRow

        Dim _Row_Potl As DataRow

        Consulta_sql = "Select *,(FABRICAR-REALIZADO) As SALDO From POTL" & vbCrLf &
                       "Where IDPOTE = " & _Idpote & " And LILG <> 'IM'"

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_GRI_ProductosOT
        Fm.Tbl_Productos = _Tbl_Productos
        Fm.ShowDialog(Me)
        _Row_Potl = Fm.FilaSeleccionada
        Fm.Dispose()

        Return _Row_Potl

    End Function

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles BtnConfiguracion.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then

            Dim _Grabar As Boolean

            Dim _Id = _Global_Row_EstacionBk.Item("Id")
            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Editar, _Id, False)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            Dim _Mod As New Clas_Modalidades

            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _NombreEquipo & "'"
            _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _Grabar Then
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Frm_GRI_Ingreso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Fx_Tiene_Permiso(Me, "7Brr0007") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Btn_FabMezcla_Click(sender As Object, e As EventArgs) Handles Btn_FabMezcla.Click

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(Me)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim _Old_Funcionario = FUNCIONARIO
        Dim _Aceptar As Boolean

        Dim Fml As New Frm_Login
        Fml.ValidarPermiso = True
        Fml.Permiso = "Doc00086"
        Fml.ShowDialog()
        _Aceptar = Fml.Aceptar
        Fml.Dispose()

        If Not _Aceptar Then
            Return
        End If

        Consulta_sql = "Select * From TABFU Where KOFU = '" & FUNCIONARIO & "'"
        Dim _Row_Usuario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not String.IsNullOrWhiteSpace(_Row_Usuario.Item("MODALIDAD")) Then

            Modalidad = _Row_Usuario.Item("MODALIDAD")

            Consulta_sql = "Select top 1 Cest.*,Cfgp.RAZON  
                            From CONFIEST Cest WITH (NOLOCK) Inner Join CONFIGP Cfgp On Cest.EMPRESA = Cfgp.EMPRESA  
                            Where MODALIDAD = '" & Modalidad & "'"
            _Global_Row_Modalidad = _Sql.Fx_Get_DataRow(Consulta_sql)

            ModEmpresa = _Global_Row_Modalidad.Item("EMPRESA")
            ModSucursal = _Global_Row_Modalidad.Item("ESUCURSAL")
            ModBodega = _Global_Row_Modalidad.Item("EBODEGA")
            ModCaja = _Global_Row_Modalidad.Item("ECAJA")
            ModListaPrecioVenta = Mid(_Global_Row_Modalidad.Item("ELISTAVEN"), 6, 3)
            ModListaPrecioCosto = Mid(_Global_Row_Modalidad.Item("ELISTACOM"), 6, 3)

            If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Empresas") Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
                _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_Global_Row_Empresa) Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Empresas (Empresa,Rut,Razon,Ncorto,Direccion,Pais,Ciudad,Giro)" & vbCrLf &
                                           "Select EMPRESA,RUT,RAZON,NCORTO,DIRECCION,PAIS,CIUDAD,GIRO From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
                    _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_sql)

                End If

                RazonEmpresa = _Global_Row_Empresa.Item("Razon").ToString.Trim
                DireccionEmpresa = _Global_Row_Empresa.Item("Direccion").ToString.Trim
                RutEmpresaActiva = _Global_Row_Empresa.Item("Rut").ToString.Trim
                RutEmpresa = RutEmpresaActiva

            End If

        Else

            Dim Frm_Modalidad As New Frm_Modalidades(False)
            Frm_Modalidad.ShowDialog()
            Frm_Modalidad.Dispose()

        End If

        Dim Fm As New Frm_ListaMezclas
        Fm.Text = "INGRESO DE DATOS DE FABRICACION DE MEZCLAS, Usuario activo: (" & FUNCIONARIO & ") " & Nombre_funcionario_activo.ToString.Trim
        Fm.ShowDialog(Me)
        Fm.Dispose()

        FUNCIONARIO = _Old_Funcionario

    End Sub

End Class
