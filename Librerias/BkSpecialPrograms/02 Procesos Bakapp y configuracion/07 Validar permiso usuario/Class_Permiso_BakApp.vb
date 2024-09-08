Imports DevComponents.DotNetBar

Public Class Class_Permiso_BakApp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Rows_Info_Remota As DataRow
    Dim _Rows_Usuario_Autoriza As DataRow

    Public ReadOnly Property Pro_Rows_Info_Remota() As DataRow
        Get
            Return _Rows_Info_Remota
        End Get
    End Property
    Public ReadOnly Property Pro_Rows_Usuario_Autoriza() As DataRow
        Get
            Return _Rows_Usuario_Autoriza
        End Get
    End Property

    Public Sub New()

    End Sub

    Function Fx_Tiene_Permiso(_Codpermiso As String,
                              Optional _Func As String = "",
                              Optional _Mostrar_Permiso As Boolean = False,
                              Optional _Mostrar_Boton_BtnIngresarClave As Boolean = True,
                              Optional _Descripcion_Permiso As String = "",
                              Optional _CodEntidad As String = "",
                              Optional _CodSucEntidad As String = "",
                              Optional _Mostrar_Boton_BtnPermisoRemoto As Boolean = True,
                              Optional _Mostrar_Boton_BtnOtorgarPermisoPermanente As Boolean = True) As Boolean

        Dim _Permiso As Boolean = False

        If String.IsNullOrEmpty(_Func) Then _Func = FUNCIONARIO

        _Codpermiso = Trim(_Codpermiso)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodUsuario = '" & _Func & "' AND CodPermiso = '" & _Codpermiso & "'"
        Dim _Row_PermisosVsUsuarios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_PermisosVsUsuarios) Then

            Dim _Llave = _Row_PermisosVsUsuarios.Item("Llave")
            Dim _Llave_Scrip As String = UCase(_Codpermiso & "@" & _Func)
            _Llave_Scrip = Encripta_md5(_Llave_Scrip)

            _Permiso = (_Llave = _Llave_Scrip)

            If Not _Permiso Then
                Consulta_sql = "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where Semilla = " & _Row_PermisosVsUsuarios.Item("Semilla")
                _Sql.Ej_consulta_IDU(Consulta_sql)
                Return False
            End If

        End If

        If Not _Mostrar_Permiso Then

            If Not _Permiso Then

                Beep()

                Dim NombrePermiso As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos",
                                                                "DescripcionPermiso",
                                                                "CodPermiso = '" & _Codpermiso & "'")

                If String.IsNullOrEmpty(_Descripcion_Permiso) Then
                    _Descripcion_Permiso = NombrePermiso
                End If


                Dim _NombreUsuario As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Func & "'")

                Dim Fm As New Frm_ValidarPermisoUsuario(_CodEntidad, _CodSucEntidad)

                Fm.ShowInTaskbar = False
                Fm.Pro_Cod_Permiso = _Codpermiso
                Fm.Pro_Nombre_Permiso = _Descripcion_Permiso
                Fm.Text = "Permiso de usuario: " & _NombreUsuario
                Fm.Pro_Funcionario = _Func
                Fm.Btn_Autorizar_Permiso.Visible = _Mostrar_Boton_BtnIngresarClave
                Fm.Btn_Permiso_Remoto.Visible = _Mostrar_Boton_BtnPermisoRemoto
                Fm.BtnOtorgarPermisoPermanente.Visible = _Mostrar_Boton_BtnOtorgarPermisoPermanente

                Fm.ShowDialog()

                _Rows_Info_Remota = Fm.Pro_Rows_Info_Remota
                _Rows_Usuario_Autoriza = Fm.Pro_Rows_Usuario_Autoriza
                _Permiso = Fm.Pro_Permiso_Aceptado

                Fm.Dispose()
                'ToastNotification.Show(Me, message.Text, IIf(checkBoxX1.Checked, My.Resources.win, Nothing), slider1.Value * 1000, glow, pos)

            End If

        End If

        Return _Permiso

    End Function

    Function Fx_Tiene_Permiso_Random(_Codpermiso As String,
                                     Optional _Func As String = "",
                                     Optional _Mostrar_Permiso As Boolean = False,
                                     Optional _Mostrar_Boton_BtnIngresarClave As Boolean = True,
                                     Optional _Descripcion_Permiso As String = "",
                                     Optional _CodEntidad As String = "",
                                     Optional _CodSucEntidad As String = "",
                                     Optional _Mostrar_Boton_BtnPermisoRemoto As Boolean = True,
                                     Optional _Mostrar_Boton_BtnOtorgarPermisoPermanente As Boolean = True) As Boolean

        Dim Permiso As Boolean = False
        If String.IsNullOrEmpty(_Func) Then _Func = FUNCIONARIO

        Dim Condicion As String
        Condicion = "CodUsuario = '" & _Func & "' AND CodPermiso = '" & _Codpermiso & "'"

        Dim Tiene As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "ZW_PermisosVsUsuarios", Condicion)
        If Tiene > 0 Then Permiso = True

        If _Mostrar_Permiso = False Then
            If Permiso = False Then
                Beep()


                Dim _Row_Permiso As DataRow = Fx_Row_Traer_Permiso_Sistema(_Codpermiso)

                If Not IsNothing(_Row_Permiso) Then

                    Dim NombrePermiso As String = _Row_Permiso.Item("DescripcionPermiso")
                    '= _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos",
                    '                    "DescripcionPermiso",
                    '                    "CodPermiso = '" & _Codpermiso & "'")

                    If String.IsNullOrEmpty(_Descripcion_Permiso) Then
                        _Descripcion_Permiso = NombrePermiso
                    End If

                    Sb_Existe_Permiso_En_BakApp(_Codpermiso)

                    Dim _NombreUsuario As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Func & "'")

                    Dim Fm As New Frm_ValidarPermisoUsuario(_CodEntidad, _CodSucEntidad)

                    Fm.ShowInTaskbar = False
                    Fm.Pro_Cod_Permiso = _Codpermiso
                    Fm.Pro_Nombre_Permiso = _Descripcion_Permiso
                    Fm.Text = "Permiso de usuario: " & _NombreUsuario
                    Fm.Pro_Funcionario = _Func
                    Fm.Btn_Autorizar_Permiso.Visible = _Mostrar_Boton_BtnIngresarClave
                    Fm.Btn_Permiso_Remoto.Visible = _Mostrar_Boton_BtnPermisoRemoto
                    Fm.BtnOtorgarPermisoPermanente.Visible = _Mostrar_Boton_BtnOtorgarPermisoPermanente

                    Fm.ShowDialog()

                    _Rows_Info_Remota = Fm.Pro_Rows_Info_Remota
                    _Rows_Usuario_Autoriza = Fm.Pro_Rows_Usuario_Autoriza
                    Permiso = Fm.Pro_Permiso_Aceptado

                    Fm.Dispose()
                    'ToastNotification.Show(Me, message.Text, IIf(checkBoxX1.Checked, My.Resources.win, Nothing), slider1.Value * 1000, glow, pos)


                Else
                    MsgBox("No existe este permiso, Código: " & _Codpermiso, MsgBoxStyle.Critical, "Bakapp")
                    Return False
                End If


            End If
        End If

        Return Permiso

    End Function

    Sub Sb_Existe_Permiso_En_BakApp(_CodPermiso As String)

        Consulta_sql = "SELECT CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso,Descuento
                        FROM " & _Global_BaseBk & "ZW_Permisos
                        Where CodPermiso = ''"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Fx_Insertar_Permiso(_CodPermiso, Nothing, Nothing)
        End If

    End Sub

    Enum Enum_Familias_Permisos
        BARRAS
        COMPRAS
        CONFIGURACION_ENTIDAD
        CONTROL_RUTA_VEHICULOS
        CORREO
        DEMONIO_AUTOMATICO
        DOCUMENTOS
        ESPECIALES
        FACTURA_ELECTRONICA
        FORMATOS
        INFORMES_DE_COMPRA
        INFORMES_DE_STOCK
        INFORMES_DE_VENTA
        INVENTARIO_PARCIALIZADO
        INVENTARIO
        LISTA_PRECIOS_Y_COSTOS
        NOTIFICACIONES
        PAGO_CLIENTES
        PAGO_PROVEEDORES
        POCKET_PC_WCE
        PRESTASHOP
        PRODUCTOS
        RESTRICCIONES
        REVISION_COMPRAS_SII
        SERVICIO_TECNICO
        SOLICITUD_NEGOCIO_CLIENTE
        SQL_CONSULTAS
        TABLAS_SISTEMA
        UBICACIONES
        USUARIOS
        PRODUCCION
        RECLAMOS
        CASHDRO
        DESPACHOS
        ADMINISTRADOR
        COMISIONES
        OFERTAS
        CONTABILIDAD
        STEM
    End Enum

    Sub Sb_Actualizar_Base_De_Permisos(_Formulario As Form, ByRef _Objeto As Object)

        Dim _SqlQuery = String.Empty

        _Formulario.Cursor = Cursors.WaitCursor
        _Formulario.Refresh()

        _SqlQuery = "Truncate Table " & _Global_BaseBk & "ZW_Permisos" & vbCrLf & vbCrLf

#Region "Actualizar permisos"

        _SqlQuery += Fx_Insertar_Permiso("Admin001", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("7Brr0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("7Brr0009", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Comp0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0027", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0028", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0029", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0030", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0031", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0032", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0033", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0034", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0035", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0036", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0037", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0038", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0039", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0040", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0041", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0042", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0043", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0044", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0045", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0046", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0047", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0048", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0049", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0050", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0051", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0052", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0053", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0054", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0055", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0056", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0057", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0058", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0059", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0060", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0061", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0062", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0063", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0064", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0065", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0066", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0067", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0068", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0069", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0070", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0071", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0072", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0073", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0080", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0081", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0082", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0083", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0084", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0085", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0086", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0087", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0088", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0089", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0090", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0091", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0092", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0093", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0094", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0095", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0096", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0097", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0098", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0099", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0100", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Comp0101", _Objeto, _Formulario)


        _SqlQuery += Fx_Insertar_Permiso("CfEnt001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt027", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt028", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt029", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("CfEnt030", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Crv0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Crv0027", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Mail0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Mail0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Mail0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Mail0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Mail0005", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Pick0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pick0015", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Bkp00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00027", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00028", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00029", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00030", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00031", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00032", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00033", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00034", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00035", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00036", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00037", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00038", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00039", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00040", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00041", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00042", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00043", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00044", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00045", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00050", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00051", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00052", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00053", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00054", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00055", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Bkp00056", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00057", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00058", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00059", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00060", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00061", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Bkp00062", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Cont0001", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Doc00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00027", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Doc00028", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00029", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00030", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00031", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00032", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00033", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00034", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Doc00035", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00036", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00037", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Doc00038", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00039", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00040", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00041", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00042", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00043", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00044", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00045", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00046", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00047", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00048", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00049", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00050", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00051", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00052", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00053", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00054", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00055", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00056", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00057", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00058", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00059", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00060", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00061", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00062", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00063", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00064", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00065", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00066", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00067", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00068", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00069", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00070", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00071", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00072", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00073", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00074", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00075", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00076", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00077", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00078", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00079", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00080", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00081", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00082", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00083", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00084", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00085", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00086", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00087", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00088", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00089", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00090", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00091", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00092", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00093", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00094", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Doc00095", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Ope00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ope00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ope00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ope00004", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Espr0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0027", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0028", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0029", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0030", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0031", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0032", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0033", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Espr0034", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Ofer0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ofer0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ofer0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ofer0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ofer0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ofer0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ofer0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ofer0008", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Dte00001", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Fmto0001", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Inc00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inc00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inc00003", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Infst005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Infst010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00030", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00035", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00036", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00037", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00038", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00039", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00040", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00041", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00042", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00043", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00044", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00045", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00046", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00047", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Inf00048", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Invp0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invp0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invp0003", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Invg0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invg0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invg0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invg0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invg0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invg0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invg0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Invg0008", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Pre0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0021", _Objeto, _Formulario)
        '_SqlQuery += Fx_Insertar_Permiso("Pre0022", _Objeto, _Formulario)
        '_SqlQuery += Fx_Insertar_Permiso("Pre0023", _Objeto, _Formulario)
        '_SqlQuery += Fx_Insertar_Permiso("Pre0024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pre0025", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Not0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Not0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Not0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Not0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Not0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Not0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Not0007", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Pcli0001", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Cdro0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Cdro0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Cdro0003", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Ppro0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ppro0012", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Bkw00001", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Pbk00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pbk00040", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Pshop001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pshop002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pshop003", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Prod001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod027", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod028", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod029", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod030", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod031", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod033", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod034", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod035", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod036", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod037", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod038", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod039", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod040", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod041", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod042", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod043", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod045", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod046", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod047", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod050", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod051", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod055", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod056", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod057", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod058", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod060", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod061", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod062", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod063", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod064", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod065", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod066", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod067", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod068", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod069", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod070", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod071", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod072", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod073", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod074", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod075", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Prod076", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("NO00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00012", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("NO00013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("NO00020", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("RSii00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("RSii00002", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Stec0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0027", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0028", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0029", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stec0030", _Objeto, _Formulario)


        _SqlQuery += Fx_Insertar_Permiso("Scn00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Scn00025", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Sql00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Sql00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Sql00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Sql00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Sql00005", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Tbl00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00021", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00022", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00023", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00024", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00025", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00026", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00027", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Tbl00030", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Tbl00035", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00036", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00037", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00038", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00039", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00040", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00041", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00042", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00043", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Tbl00044", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00045", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00046", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Tbl00047", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Tbl00048", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Ubic0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Ubic0020", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("User0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("User0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("User0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("User0004", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Pdc00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Pdc00011", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Rcl00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00019", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Rcl00020", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("ODp00001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00004", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00005", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00006", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00007", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00008", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00009", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00010", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00011", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00012", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00013", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00014", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00015", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00016", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00017", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00018", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("ODp00019", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Com00001", _Objeto, _Formulario)

        _SqlQuery += Fx_Insertar_Permiso("Stem0001", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stem0002", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stem0003", _Objeto, _Formulario)
        _SqlQuery += Fx_Insertar_Permiso("Stem0004", _Objeto, _Formulario)

        _SqlQuery += vbCrLf

#End Region

        _SqlQuery += "Insert Into " & _Global_BaseBk & "ZW_Permisos 
                      (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso)
                      SELECT 'Lp-'+KOLT As CodPermiso,NOKOLT as DescripcionPermiso,'Lp','Listas de precios'
                      FROM TABPP
                      WHERE TILT = 'C'-- KOLT NOT IN (Select SUBSTRING(Zp.CodPermiso,4,3) From " & _Global_BaseBk & "ZW_Permisos Zp Where Zp.CodFamilia = 'Lp') And TILT = 'C'

                      Insert Into " & _Global_BaseBk & "ZW_Permisos 
                      (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso)
                      SELECT 'Lp-'+KOLT As CodPermiso,NOKOLT as DescripcionPermiso,'Lp','Listas de precios'
                      FROM TABPP
                      WHERE TILT = 'P' --KOLT NOT IN (Select SUBSTRING(Zp.CodPermiso,4,3) From " & _Global_BaseBk & "ZW_Permisos Zp Where Zp.CodFamilia = 'Lp')  And TILT = 'P'

                      Insert Into " & _Global_BaseBk & "ZW_Permisos 
                      (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso) 
                      SELECT 'Bo'+EMPRESA+KOSU+KOBO,'BODEGA: '+NOKOBO,'Bodega','Bodegas'
                      FROM TABBO

                      Insert Into " & _Global_BaseBk & "ZW_Permisos 
                      (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso) 
                      SELECT 'BNVI'+EMPRESA+KOSU+KOBO,'BODEGA NVI: '+NOKOBO,'Bodega_NVI','Bodegas NVI'
                      FROM TABBO
                      
                      Insert Into " & _Global_BaseBk & "ZW_Permisos 
                      (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso) 
                      SELECT  'RclRes'+CodigoTabla, 'APROBAR REVISION RECLAMOS DE TIPO ' + NombreTabla,'" &
                      Fx_Rellena_ceros(Enum_Familias_Permisos.RECLAMOS, 6) & "','" & Enum_Familias_Permisos.RECLAMOS.ToString & "'
                      FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones
                      Where Tabla = 'SIS_RECLAMOS_TIPO'
                      ORDER BY Tabla, Orden

                      Insert Into " & _Global_BaseBk & "ZW_Permisos 
                      (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso) 
                      SELECT  'RclVal'+CodigoTabla, 'APROBAR VALIDACION RECLAMOS DE TIPO ' + NombreTabla,'" &
                      Fx_Rellena_ceros(Enum_Familias_Permisos.RECLAMOS, 6) & "','" & Enum_Familias_Permisos.RECLAMOS.ToString & "'
                      FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones
                      Where Tabla = 'SIS_RECLAMOS_TIPO'
                      ORDER BY Tabla, Orden

                      Insert Into " & _Global_BaseBk & "ZW_Permisos 
                      (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso) 
                      SELECT Codigo_Pagina,'UTILIZAR WEB: ' + Nombre_Pagina,'" &
                      Fx_Rellena_ceros(Enum_Familias_Permisos.PRESTASHOP, 6) & "','" & Enum_Familias_Permisos.PRESTASHOP.ToString & "'
                      FROM " & _Global_BaseBk & "Zw_PrestaShop"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
            MessageBoxEx.Show(_Formulario, "Datos actualizados correctamente", "Actualizar permisos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        _Formulario.Cursor = Cursors.Default
        _Formulario.Refresh()

    End Sub

    Function Fx_Insertar_Permiso(_CodPermiso As String, ByRef _Objeto As Object, _Formulario As Form) As String

        Dim _Row As DataRow = Fx_Row_Traer_Permiso_Sistema(_CodPermiso)

        Dim _DescripcionPermiso As String = String.Empty
        Dim _CodFamilia As String
        Dim _NombreFamiliaPermiso As String
        Dim _Descuento As Integer
        Dim _Max_Compra As Integer

        Dim Consulta_sql = String.Empty

        If Not IsNothing(_Row) Then

            _DescripcionPermiso = _Row.Item("DescripcionPermiso")
            _CodFamilia = _Row.Item("CodFamilia")
            _NombreFamiliaPermiso = _Row.Item("NombreFamiliaPermiso")
            _Descuento = Convert.ToInt32(_Row.Item("Descuento"))
            _Max_Compra = Convert.ToInt32(_Row.Item("Max_Compra"))

            Consulta_sql = "Insert Into " & _Global_BaseBk & "ZW_Permisos (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso,Descuento,Max_Compra) Values 
                            ('" & _CodPermiso & "','" & _DescripcionPermiso & "','" & _CodFamilia & "','" & _NombreFamiliaPermiso & "'," & _Descuento & "," & _Max_Compra & ")" & vbCrLf

            Try
                Application.DoEvents()
            Catch ex As Exception

            End Try

            If Not IsNothing(_Objeto) Then _Objeto.text = Trim(_NombreFamiliaPermiso) & ": " & Trim(_CodPermiso) & " - " & _DescripcionPermiso
            If Not IsNothing(_Formulario) Then _Formulario.Refresh()

        End If

        Return Consulta_sql

    End Function

    Function Fx_Row_Traer_Permiso_Sistema(_CodPermiso As String) As DataRow

        Dim _DescripcionPermiso As String = String.Empty
        Dim _CodFamilia As String
        Dim _NombreFamiliaPermiso As String
        Dim _Descuento As Boolean = False
        Dim _Max_Compra As Boolean = False

        Dim _Fml As Enum_Familias_Permisos

#Region "PERMISOS"

#Region "SISTEMA DE CODIGOS DE BARRA"

        Select Case _CodPermiso
            Case "7Brr0001"
                _DescripcionPermiso = "INGRESAR AL SISTEMA DE BARRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0002"
                _DescripcionPermiso = "CONFIGURAR DISEÑO DE CÓDIGOS DE BARRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0003"
                _DescripcionPermiso = "IMPRIMIR BARRAS POR PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0004"
                _DescripcionPermiso = "IMPRIMIR BARRAS POR DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0005"
                _DescripcionPermiso = "IMPRIMIR BARRAS POR UBICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0006"
                _DescripcionPermiso = "CONFIGURACIÓN LOCAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0007"
                _DescripcionPermiso = "CERRAR FORMULARIO DE IMPRESION DE CODIGOS DE BARRA CUANDO ESTA POR DEFECTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0008"
                _DescripcionPermiso = "PERMITIR MODIFICAR PUERTOS DE SALIDA POR ETIQUETA POR EQUIPO DE IMPRESION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString
            Case "7Brr0009"
                _DescripcionPermiso = "PERMITIR BUSCAR PRODUCTOS POR DESCRIPCION EN MODULO DE IMPRESION DE CODIGOS DE BARRA POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.BARRAS, 6)
                _NombreFamiliaPermiso = _Fml.BARRAS.ToString

        End Select

#End Region

#Region "COMPRAS"

        Select Case _CodPermiso
            Case "Comp0001"
                _DescripcionPermiso = "INGRESAR SOLICITUD DE COMPRA "
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0002"
                _DescripcionPermiso = "VER INFORME DE SOLICITUDES DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0003"
                _DescripcionPermiso = "INGRESAR SOLICITUD DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0004"
                _DescripcionPermiso = "INGRESAR AL ASISTENTE DE COMPRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0005"
                _DescripcionPermiso = "MAESTRA COMPRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0006"
                _DescripcionPermiso = "INFORME SOBRE STOCK"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0007"
                _DescripcionPermiso = "ENVIAR SOLICITUS DE CREACIÓN DE PRODUCTOS DESDE SOC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0008"
                _DescripcionPermiso = "EDITAR SOLICITUD DE COMPRA DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0009"
                _DescripcionPermiso = "PERMITIR CREAR ORDEN DESDE SOLICITUD (DIRECTA)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0010"
                _DescripcionPermiso = "PERMITIR CREAR ORDEN DESDE SOLICITUD (VIA CADENA)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0011"
                _DescripcionPermiso = "PODER ACTUALIZAR TIPO DE COMPRA PROVEEDOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0012"
                _DescripcionPermiso = "INCORPORAR ORDEN DE COMPRA EN SOLICITUD (NO ASIGNADAS)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0013"
                _DescripcionPermiso = "QUITAR ORDEN DE COMPRA DE SOLICITUD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0014"
                _DescripcionPermiso = "REVISAR SOLICITUD EN PROCESO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0015"
                _DescripcionPermiso = "REACTIVAR SOLICITUD DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0016"
                _DescripcionPermiso = "LIBERAR SOLICITUDES TOMADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0017"
                _DescripcionPermiso = "CREAR SOC VTA CALZADA VIA CADENA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0018"
                _DescripcionPermiso = "CREAR SOC VTA CALZADA VIA DIRECTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0019"
                _DescripcionPermiso = "CREAR SOC STOCK VIA CADENA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0020"
                _DescripcionPermiso = "CREAR SOC STOCK VIA DIRECTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0021"
                _DescripcionPermiso = "PERMITIR SOLO ACEPTAR (DIRECTA)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0022"
                _DescripcionPermiso = "PERMITIR SOLO ACEPTAR (VIA CADENA)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0023"
                _DescripcionPermiso = "PROCESAR LA ORDEN DE COMPRA DESDE SOC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0024"
                _DescripcionPermiso = "MODIFICAR SOLICITUDES EN STAND-BY DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0025"
                _DescripcionPermiso = "GRABAR SOLICITUDES DE COMPRAS FUERA DEL TURNO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0026"
                _DescripcionPermiso = "ELIMINAR SOLICITUDES EN STAND-BY DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0027"
                _DescripcionPermiso = "CONFIGURAR ESTACIÓN EN SOLICITU DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0028"
                _DescripcionPermiso = "IMPRIMIR DIRECCIÓN DE RETIRO DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0029"
                _DescripcionPermiso = "INCORPORAR ORDEN DE COMPRA EN SOLICITUD YA ASIGNADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0030"
                _DescripcionPermiso = "PERMITIR SOL. CREA. PRODUC. SIN COD. ALTERNATIVO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0031"
                _DescripcionPermiso = "PERMITIR SOL. CREA. PRODUC. SIN MARCA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0032"
                _DescripcionPermiso = "PERMITIR SOL. CREA. PRODUC. SIN RUBRO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0033"
                _DescripcionPermiso = "PERMITIR SOL. CREA. PRODUC. SIN SUPER FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0034"
                _DescripcionPermiso = "PERMITIR SOL. CREA. PRODUC. SIN FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0035"
                _DescripcionPermiso = "PERMITIR SOL. CREA. PRODUC. SIN SUB FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0036"
                _DescripcionPermiso = "PERMITIR CAMBIAR LOS PRECIOS EN COMPRAS DE STOCK"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0037"
                _DescripcionPermiso = "VER SOLICITUDES CON OBSERVACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0038"
                _DescripcionPermiso = "VER SOLICITUDES DE APELACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0039"
                _DescripcionPermiso = "AUTORIZAR SOLICITUD PARA GENERAR OCC... (GERENCIA 2)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0040"
                _DescripcionPermiso = "AUTORIZAR SOC PARA GENERAR OCC... (GERENCIA 2) APELACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0041"
                _DescripcionPermiso = "CHECKEAR AUTORIZACION EN LINEA DE DETALLE SOC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0042"
                _DescripcionPermiso = "APELAR SOLICITUDES DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0043"
                _DescripcionPermiso = "AUTORIZAR SOLICITUD PARA GENERAR OCC... (GERENCIA 1)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0044"
                _DescripcionPermiso = "PERMITIR COMPRAR PRODUCTOS OBJETADOS (CON APELACION)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0045"
                _DescripcionPermiso = "VOLVER A DEJAR EN PROCESO UNA SOLICITUD CON OBSERVACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0046"
                _DescripcionPermiso = "PODER EDITAR SOLICITUD EN PROCESO DE REVISION DE GERENCIA 2"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0047"
                _DescripcionPermiso = "REVISAR ANALISIS DE COMPRA POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0048"
                _DescripcionPermiso = "AUTORIZAR A COMPRAR PRODUCTOS AUN SIN CREAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0049"
                _DescripcionPermiso = "ACEPTAR SOLICITUDES DE COMPRA (EX. 13)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0050"
                _DescripcionPermiso = "RECHAZAR SOLICITUDES DE COMPRA (EX. 14)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0051"
                _DescripcionPermiso = "ACEPTAR ORDEN DE COMPRA (EX. 15)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0052"
                _DescripcionPermiso = "RECHAZAR ORDEN DE COMPRA (EX. 18)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0053"
                _DescripcionPermiso = "INGRESAR AL ASISTENTE DE COMPRAS (EX. 22)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0054"
                _DescripcionPermiso = "ANULAR SOLICITUD DE COMPRA (EX. 29)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0055"
                _DescripcionPermiso = "EDITAR SOC DE OTROS USUARIOS (EX. 4)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0056"
                _DescripcionPermiso = "VER INFORME SOLICITUD DE COMPRA (EX. 5)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0057"
                _DescripcionPermiso = "VER INFORMES DE ORDENES DE COMPRA GENERADAS (EX. 6)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0058"
                _DescripcionPermiso = "CERRAR SOLICITUD, ENVIO DE OCC AL PROVEEDOR POR MAIL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0059"
                _DescripcionPermiso = "CERRAR SOLICITUD, VIA CADENA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0060"
                _DescripcionPermiso = "CERRAR SOLICITUD, OTRA GESTION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0061"
                _DescripcionPermiso = "INGRESAR CANTIDAD SUGERIDA (APELACIONES)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0062"
                _DescripcionPermiso = "INGRESAR CANTIDAD APELACION (APELACIONES)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0063"
                _DescripcionPermiso = "INGRESAR CANTIDAD DEFINITIVA COMPRA (APELACIONES)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0064"
                _DescripcionPermiso = "INGRESAR CANT. MAYOR A LA CANTIDAD ORIGINAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0065"
                _DescripcionPermiso = "AGREGAR PRODUCTO A SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0066"
                _DescripcionPermiso = "MODIFICAR CANTIDADES. SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0067"
                _DescripcionPermiso = "MODIFICAR PRECIOS. SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0068"
                _DescripcionPermiso = "MODIFICAR PRECIO Y CANTIDADES. SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0069"
                _DescripcionPermiso = "CAMBIAR PROVEEDOR. SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0070"
                _DescripcionPermiso = "CAMBIAR PROVEEDOR. SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0071"
                _DescripcionPermiso = "ELIMINAR FILA. SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0072"
                _DescripcionPermiso = "REEMPLAZAR CODIGO POR OTRO. SOC EN PROCESO DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0073"
                _DescripcionPermiso = "VER HISTORIAL DE LA SOLICITUD DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0080"
                _DescripcionPermiso = "PODER CORRER PROCESO DE COMPRAS INCLUYENDO LAS ROTACIONES DE ENT. EXCLUIDAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0081"
                _DescripcionPermiso = "INGRESAR SOLICITUD DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0082"
                _DescripcionPermiso = "EDITAR SOLICITUD DE COMPRA DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0083"
                _DescripcionPermiso = "VER INFORME DE SOLICITUDES DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0084"
                _DescripcionPermiso = "VER INFORMES DE ORDENES DE COMPRA GENERADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0085"
                _DescripcionPermiso = "ACEPTAR SOLICITUDES DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0086"
                _DescripcionPermiso = "RECHAZAR SOLICITUDES DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0087"
                _DescripcionPermiso = "ACEPTAR ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0088"
                _DescripcionPermiso = "RECHAZAR ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0089"
                _DescripcionPermiso = "INGRESAR AL ASISTENTE DE COMPRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0090"
                _DescripcionPermiso = "ANULAR SOLICITUD DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0091"
                _DescripcionPermiso = "INFORME ROTACIÓN POR PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0092"
                _DescripcionPermiso = "AUTORIZAR COMPRA (SOC)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
                _Max_Compra = True
            Case "Comp0093"
                _DescripcionPermiso = "PODER CORRER PROCESO DE COMPRAS SIN PROCESAR UNO X UNO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0094"
                _DescripcionPermiso = "VER LISTADO DE TODAS LAS SOLICITUDES DE COMPRA, INCLUSO LAS QUE NO PUEDO DAR PERMISO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0095"
                _DescripcionPermiso = "AUTORIZAR COMPRA, VALIDAR PRODUCTO A COMPRAR (SOC)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0096"
                _DescripcionPermiso = "INGRESAR A MANTENEDOR DE FUNCIONARIOS VS PRODUCTOS ASOCIADOS (SOC)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0097"
                _DescripcionPermiso = "GENERAR DOCUMENTO SIN TENER QUE CARGAR LISTA DE COSTOS DEL PROVEEDORES DESDE BAKAPP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0098"
                _DescripcionPermiso = "GENERAR DOCUMENTO CON LISTA DE COSTO DEL PROVEEDOR CADUCADA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0099"
                _DescripcionPermiso = "PODER MODIFICAR EL PADRE DE ASOCIACION DE PRODUCTOS EN ASISTENTE DE COMPRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0100"
                _DescripcionPermiso = "PODER BLOQUEAR O DESBLOQUEAR LA CONFIGURACION DEL ASISTENTE DE COMPRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
            Case "Comp0101"
                _DescripcionPermiso = "MOSTRAR SUGERENCIAS DE CAMBIO DE PRECIOS (ASISTENTE DE COMPRAS)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMPRAS, 6)
                _NombreFamiliaPermiso = _Fml.COMPRAS.ToString
        End Select

#End Region

#Region "CONFIGURACION ENTIDAD"

        Select Case _CodPermiso

            Case "CfEnt001"
                _DescripcionPermiso = "INGRESAR A CREACIÓN DE ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt002"
                _DescripcionPermiso = "CREAR NUEVA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt003"
                _DescripcionPermiso = "EDITAR ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt004"
                _DescripcionPermiso = "ELIMINAR ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt005"
                _DescripcionPermiso = "CREAR ENTIDAD CON CÓDIGO Y RUT DISTINTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt006"
                _DescripcionPermiso = "MODIFICAR VENDEDOR DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt007"
                _DescripcionPermiso = "MODIFICAR COMPRADOR DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt008"
                _DescripcionPermiso = "MODIFICAR LISTAS DE PRECIO Y COSTO ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt009"
                _DescripcionPermiso = "MODIFICAR CREDITOS DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt010"
                _DescripcionPermiso = "ASOCIAR MARCAS A PROVEEDORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt011"
                _DescripcionPermiso = "CREAR CONTACTO DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt012"
                _DescripcionPermiso = "EDITAR CONTACTO DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt013"
                _DescripcionPermiso = "ELIMINAR CONTACTO DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt014"
                _DescripcionPermiso = "ASIGNAR VENDEDOR AL FUNCIONARIO CREADOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt015"
                _DescripcionPermiso = "ASIGNAR COBRADOR AL FUNCIONARIO CREADOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt016"
                _DescripcionPermiso = "EXCLUIR ENTIDADES PARA INFORMES Y OTROS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt017"
                _DescripcionPermiso = "PODER CAMBIAR TIPO DE BUSQUEDA DE ENTIDADES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt020"
                _DescripcionPermiso = "INGRESAR A LA FICHA DE LA COMPAÑIA DE SEGUROS DEL CLIENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt025"
                _DescripcionPermiso = "EDITAR FICHA DE LA COMPAÑIA DE SEGUROS DEL CLIENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt026"
                _DescripcionPermiso = "VER CONTACTOS DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt027"
                _DescripcionPermiso = "VER DIRECCIONES DE DESPACHO DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt028"
                _DescripcionPermiso = "CAMBIAR CONDICION QUE PERMITE DECIDIR SI FACTURA AUTOMATICAMENTE LAS NOTAS DE VENTA DE LA ENTIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt029"
                _DescripcionPermiso = "EDITAR SELECCION DE CREDITO FINCRED"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString
            Case "CfEnt030"
                _DescripcionPermiso = "CREAR/EDITAR/ELIMINAR PRODUCTOS BLOQUEADOS POR PROVEEDORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONFIGURACION_ENTIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONFIGURACION_ENTIDAD.ToString

        End Select

#End Region

#Region "CRV CONTROL RUTA DE VEHICULOS"

        Select Case _CodPermiso
            Case "Crv0001"
                _DescripcionPermiso = "MANTENCION DE VEHICULOS DE LA EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0002"
                _DescripcionPermiso = "CREAR NUEVO VEHICULO DE LA EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0003"
                _DescripcionPermiso = "MOSTRAR VEHICULOS DESHABILIDATOS EN LA LISTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0004"
                _DescripcionPermiso = "EDITAR DATOS DEL VEHICULO DE LA EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0005"
                _DescripcionPermiso = "PODER VER VEHICULOS INHANIBILITADOS EN LISTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0006"
                _DescripcionPermiso = "MANTENCION DE CHOFERES DE LA EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0007"
                _DescripcionPermiso = "CREAR NUEVO CHOFER DE LA EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0008"
                _DescripcionPermiso = "EDITAR DATOS DEL CHOFER DE LA EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0009"
                _DescripcionPermiso = "MOSTRAR CHOFERES INHABILITADOS EN LA LISTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0010"
                _DescripcionPermiso = "INHABILITAR VEHICULO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0011"
                _DescripcionPermiso = "INHABILITAR CHOFER"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0012"
                _DescripcionPermiso = "INGRESAR AL SISTEMA C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0013"
                _DescripcionPermiso = "INGRESAR A CONFIGURACION DE SISTEMA C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0014"
                _DescripcionPermiso = "CREAR NUEVO C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0015"
                _DescripcionPermiso = "EDITAR C.R.V. EN PROCESO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0016"
                _DescripcionPermiso = "EDITAR C.R.V. CERRADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0017"
                _DescripcionPermiso = "BUSCAR C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0018"
                _DescripcionPermiso = "EXPORTAR A EXCEL LISTADO DE C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0019"
                _DescripcionPermiso = "PODER VER C.R.V. SELECCIONADA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0020"
                _DescripcionPermiso = "EDITAR KILOMETRAJE DE SALIDA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0021"
                _DescripcionPermiso = "CERRAR C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0022"
                _DescripcionPermiso = "ANULAR C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0023"
                _DescripcionPermiso = "RE-IMPRIMIR C.R.V."
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0024"
                _DescripcionPermiso = "VER FOTOS DE VEHICULOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0025"
                _DescripcionPermiso = "SUBIR FOTOS, ARCHIVOS DEL VEHICULO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0026"
                _DescripcionPermiso = "DESCARGAR FOTOS, ARCHIVOS DEL VEHICULO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
            Case "Crv0027"
                _DescripcionPermiso = "ELIMINAR ARCHIVOS DEL VEHICULO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTROL_RUTA_VEHICULOS, 6)
                _NombreFamiliaPermiso = _Fml.CONTROL_RUTA_VEHICULOS.ToString
        End Select

#End Region

#Region "CORREO"

        Select Case _CodPermiso

            Case "Mail0001"
                _DescripcionPermiso = "INGRESAR A MANTENCION DE CORREOS SMTP "
                _CodFamilia = Fx_Rellena_ceros(_Fml.CORREO, 6)
                _NombreFamiliaPermiso = _Fml.CORREO.ToString
            Case "Mail0002"
                _DescripcionPermiso = "CREAR CORREO SMTP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CORREO, 6)
                _NombreFamiliaPermiso = _Fml.CORREO.ToString
            Case "Mail0003"
                _DescripcionPermiso = "EDITAR CORREO SMTP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CORREO, 6)
                _NombreFamiliaPermiso = _Fml.CORREO.ToString
            Case "Mail0004"
                _DescripcionPermiso = "ELIMINAR CORREO SMTP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CORREO, 6)
                _NombreFamiliaPermiso = _Fml.CORREO.ToString
            Case "Mail0005"
                _DescripcionPermiso = "INGRESAR AL SISTEMA DE IMPORTAR RECEPCION DE CORREOS DE PROVEEDORES DTE XML"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CORREO, 6)
                _NombreFamiliaPermiso = _Fml.CORREO.ToString
        End Select

#End Region

#Region "DEMONIO AUTOMATICO"

        Select Case _CodPermiso

            Case "Pick0001"
                _DescripcionPermiso = "INGRESAR IMPRESIÓN DE PICKING AUTOMATICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0002"
                _DescripcionPermiso = "ACTIVAR IMPRESIÓN DE PICKING"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0003"
                _DescripcionPermiso = "CONFIGURAR IMPRESIÓN PICKING"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0004"
                _DescripcionPermiso = "REIMPRIMIR PICKING"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0005"
                _DescripcionPermiso = "CONFIGURAR PICKING"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0006"
                _DescripcionPermiso = "ACTIVAR IMPRESIÓN DE SOLICITUD DE PRODUCTOS A BODEGA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0007"
                _DescripcionPermiso = "CAMBIAR FECHA DE RECPCIÓN DE DOCUMENTOS AUTOMATICA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0008"
                _DescripcionPermiso = "CONFIGURAR DOCUMENTOS PARA PICKING Y OTROS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0009"
                _DescripcionPermiso = "ACTIVAR MONITOREO DE DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0010"
                _DescripcionPermiso = "ACTIVAR ENVIO DE CORREOS AUTOMATICOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0011"
                _DescripcionPermiso = "ACTIVAR SWITCH DE ACTIVACIÓN ON - OFF"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
            Case "Pick0015"
                _DescripcionPermiso = "CERRAR DEMONIO "
                _CodFamilia = Fx_Rellena_ceros(_Fml.DEMONIO_AUTOMATICO, 6)
                _NombreFamiliaPermiso = _Fml.DEMONIO_AUTOMATICO.ToString
        End Select

#End Region

#Region "DOCUMENTOS"

        Select Case _CodPermiso

            Case "Ope00001"
                _DescripcionPermiso = "CAMBIAR FECHA DE VENCIMIENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Ope00002"
                _DescripcionPermiso = "PERMITIR SUPERAR LÍMITE DE CRÉDITO EN CHEQUE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Ope00003"
                _DescripcionPermiso = "PERMITIR SUPERAR LÍMITE DE CRÉDITO SIN DOCUMENTAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Ope00004"
                _DescripcionPermiso = "PERMITIR GRABAR DOCUMENTO SIN EXIGIR EL PAGO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString


            Case "Bkp00001"
                _DescripcionPermiso = "INGRESAR AL MODULO DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00002"
                _DescripcionPermiso = "GRABAR BOLETAS TRANSITORIAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00003"
                _DescripcionPermiso = "GRABAR FACTURAS TRANSITORIAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00004"
                _DescripcionPermiso = "GRABAR COTIZACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00005"
                _DescripcionPermiso = "HACER DESCUENTOS POR LÍNEA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00006"
                _DescripcionPermiso = "HACER DESCUENTOS GLOBALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00007"
                _DescripcionPermiso = "REIMPRIMIR VALES TRANSITORIOS (BOLETAS)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00008"
                _DescripcionPermiso = "REIMPRIMIR VALES TRANSITORIOS (FACTURAS)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00009"
                _DescripcionPermiso = "PODER CAMBIAR LISTA DE PRECIOS/COSTO EN TPO. DE OPERACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00010"
                _DescripcionPermiso = "HACER DOCUMENTOS DESDE COV, BLV O FCV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00011"
                _DescripcionPermiso = "MODIFICAR DESCUENTO GLOBAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00012"
                _DescripcionPermiso = "MODIFICAR PRECIO DE VENTA DEL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00013"
                _DescripcionPermiso = "MODIFICAR DESCUENTO EN LA LÍNEA DEL PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00014"
                _DescripcionPermiso = "AUTORIZAR A VENDER CON DESCUENTOS BAJO EL MÁXIMO SEGÚN LISTA DE PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
                _Descuento = True
            Case "Bkp00015"
                _DescripcionPermiso = "AUTORIZAR A VENDER CON STOCK MENOR O IGUAL A CERO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00016"
                _DescripcionPermiso = "PERMITIR INGRESAR MÁS LÍNEAS LUEGO DE UN DESCUENTO GLOBAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00017"
                _DescripcionPermiso = "MODIFICAR PRECIO DE VENTA DEL PRODUCTO (BAJAR EL PRECIO)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00018"
                _DescripcionPermiso = "MODIFICAR PRECIO DE VENTA DEL PRODUCTO (SUBIR EL PRECIO)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00019"
                _DescripcionPermiso = "PERMITIR GENERAR DOCUMENTOS DE VENTA CON DEUDA VENCIDA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00020"
                _DescripcionPermiso = "GRABAR NOTA DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00021"
                _DescripcionPermiso = "PERMITIR VENDER A ENTIDADES BLOQUEADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00022"
                _DescripcionPermiso = "SOLICITAR PRODUCTOS A BODEGA PARA VERLOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00023"
                _DescripcionPermiso = "ENTREGAR PRODUCTOS SOLICITADOS DESDE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00024"
                _DescripcionPermiso = "RECIBIR PRODUCTOS SOLICITADOS DESDE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00025"
                _DescripcionPermiso = "MARCAR PRODUCTO COMO NO ENCONTRADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00026"
                _DescripcionPermiso = "AUTORIZAR A VENDER CON PRODUCTOS SOLICITADOS A BODEGA PENDIENTES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00027"
                _DescripcionPermiso = "REGISTRAR UNA VENTA EN POST-VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00028"
                _DescripcionPermiso = "AUTORIZAR LA CANCELACIÓN DE UNA SOLICITUD DE PRODUCTO A BODEGA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00029"
                _DescripcionPermiso = "EXPORTAR A EXCEL SOLICITUD DE PRODUCTOS A BODEGA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00030"
                _DescripcionPermiso = "LLAMAR UNA SOLICITUD DE PRODUCTOS CON DOBLE CLIC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00031"
                _DescripcionPermiso = "VER LISTA DE PRODUCTOS SOLICITADOS A BODEGA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00032"
                _DescripcionPermiso = "VER INFORMACIÓN DEL PRODUCTO SOLICITADO, VER TRAZA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00033"
                _DescripcionPermiso = "PERMITIR VENDER CON CUPO DE CRÉDITO SUPERADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00034"
                _DescripcionPermiso = "CAMBIAR CONDICIONES DE PAGO (VENCIMIENTOS DEL DOCUMENTO)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00035"
                _DescripcionPermiso = "PERMITIR VENDER A CLIENTES CON LISTA DE PRECIOS DISTINTA A SU LISTA ACTUAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00036"
                _DescripcionPermiso = "PODER VENDER PRODUCTOS FRACCIONADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00037"
                _DescripcionPermiso = "MOSTRAR COSTOS EN SITUACIÓN COMERCIAL DE DOCUMENTO DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00038"
                _DescripcionPermiso = "MOSTRAR LOS MARGENES EN SITUACIÓN COMERCIAL DE DOCUMENTO DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00039"
                _DescripcionPermiso = "SUPERAR DESCUENTO GLOBAL PERMITIDO PARA DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
                _Descuento = True
            Case "Bkp00040"
                _DescripcionPermiso = "CAMBIAR AL VENDEDOR DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00041"
                _DescripcionPermiso = "CREAR (NVV) NOTA DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00042"
                _DescripcionPermiso = "PERMITIR VENDER PRODUCTOS BLOQUEADOS PARA COMPRAS Y VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00043"
                _DescripcionPermiso = "PERMITIR VENDER PRODUCTOS BLOQUEADOS VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00044"
                _DescripcionPermiso = "PERMITIR COMPRAR PRODUCTOS BLOQUEADOS PARA COMPRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00045"
                _DescripcionPermiso = "CAMBIAR LA BODEGA EN LA LINEA DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00050"
                _DescripcionPermiso = "PERMITIR CAMBIAR REDONDEO A CERO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00051"
                _DescripcionPermiso = "PERMITIR CAMBIAR AL RESPONSABLE CUANDO SE GENERE UN DOCUMENTO DESDE OTRO DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00052"
                _DescripcionPermiso = "QUITAR VALIDADOR DE USUARIOS CON HUELLA (PRESTAMOS DE PRODUCTOS DESDE BODEGA)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00053"
                _DescripcionPermiso = "CREAR (COV) COTIZACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00054"
                _DescripcionPermiso = "CREAR (FCV) FACTURA DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00055"
                _DescripcionPermiso = "CREAR (NCV) NOTA DE CREDITO DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Bkp00056"
                _DescripcionPermiso = "CREAR (GDV) GUIA DE DESPACHO DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Bkp00057"
                _DescripcionPermiso = "EXTENDER FECHA DE DESPACHO EN DOCUMENTOS DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Bkp00058"
                _DescripcionPermiso = "EDITAR NOTAS DE VENTA YA GENERADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Bkp00059"
                _DescripcionPermiso = "CAMBIAR LA BODEGA EN LA LINEA DEL DOCUMENTO, EN DOC. VISADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Bkp00060"
                _DescripcionPermiso = "MODIFICAR EL VALOR DEL IVA EN LA LINEA DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Bkp00061"
                _DescripcionPermiso = "EDITAR NUMERO DE DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Bkp00062"
                _DescripcionPermiso = "PERMITIR GENERAR NOTA DE VENTA BAJO EL VALOR MINIMO ASIGNADO AL DOCUMENTO POR MODALIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString




            Case "Doc00001"
                _DescripcionPermiso = "INSERTAR ANOTACIONES/EVENTOS SIMPLES EN DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00002"
                _DescripcionPermiso = "INSERTAR ANOTACIONES/EVENTOS TABULADAS EN DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00003"
                _DescripcionPermiso = "INSERTAR ANOTACIONES/EVENTOS LINK EN DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00004"
                _DescripcionPermiso = "ELIMINAR ANOTACIONES/EVENTOS EN DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00005"
                _DescripcionPermiso = "EDITAR ANOTACIONES/EVENTOS DE DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00006"
                _DescripcionPermiso = "CAMBIAR FECHA DE VENCIMIENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00007"
                _DescripcionPermiso = "EDITAR OBSERVACIONES DE DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00008"
                _DescripcionPermiso = "INSERTAR ANOTACIONES/EVENTOS LIGA TRAZA EXTERNA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00009"
                _DescripcionPermiso = "ELIMINAR ANOTACIONES/EVENTOS EN DOCUMENTOS LIGADOS EXTERNAMENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00010"
                _DescripcionPermiso = "ELIMINAR ANOTACIONES/EVENTOS DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00011"
                _DescripcionPermiso = "CIERRE DE DOCUMENTOS DE COMPROMISO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00012"
                _DescripcionPermiso = "RE-IMPRIMIR DOCUMENTOS GRABADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00015"
                _DescripcionPermiso = "PODER BUSCAR DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00020"
                _DescripcionPermiso = "CAMBIAR FOLIO DE DOCUMENTO DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00021"
                _DescripcionPermiso = "PODER VER DOCUMENTOS DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00022"
                _DescripcionPermiso = "PERMITIR EL MOVIMIENTO DE ARTICULOS SIN VALIDAR CODIGO DE BARRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00023"
                _DescripcionPermiso = "PERMITIR AGREGAR LINEAS CUANDO EXISTEN DOCUMENTOS RELACIONADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00024"
                _DescripcionPermiso = "PERMITIR GENERAR DOCUMENTOS DE VENTA SIN ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00025"
                _DescripcionPermiso = "EXPORTAR DOCUMENTO A XML"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00026"
                _DescripcionPermiso = "CREAR NOTAS DE CREDITO CON DOC. RELACIONADOS FUERA DE PLAZO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00027"
                _DescripcionPermiso = "INGRESAR/EDITAR/ELIMINAR REFERENCIAS DTE XML"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00028"
                _DescripcionPermiso = "AUTORIZA DOC. DE VENTA CON PRECIO IGUAL A CERO (0)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00029"
                _DescripcionPermiso = "AUTORIZA DOC.DE COMPRAS CON PRECIO IGUAL A CERO (0)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00030"
                _DescripcionPermiso = "AUTORIZA DOC. INTERNOS CON PRECIO IGUAL A CERO (0)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00031"
                _DescripcionPermiso = "AUTORIZAR A GRABAR GRC SIN FCC ENCONTRADA EN SII."
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00032"
                _DescripcionPermiso = "VER ARCHIVOS ADJUNTOS DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00033"
                _DescripcionPermiso = "SUBIR ARCHIVOS ADJUNTOS PARA EL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00034"
                _DescripcionPermiso = "ELIMINAR ARCHIVO ADJUNTO DEL DOCUMENTO QUE SUBIERON OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00035"
                _DescripcionPermiso = "PODER CAMBIAR LA MONEDA DEL DOCUMENTO SIN TENER PERMISO A UTILIZAR LISTA DE PRECION CON ESA MONEDA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00036"
                _DescripcionPermiso = "CREAR DOCUMENTOS CON MONEDA DISTINTA A LA MONEDA DE LA LISTA DE PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00037"
                _DescripcionPermiso = "CREAR (BLV) BOLETA NOMINATIVA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString
            Case "Doc00038"
                _DescripcionPermiso = "IMPRIMIR DOCUMENTO EN UN FORMATO DISTINTO AL DE LA MODALIDAD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00039"
                _DescripcionPermiso = "PERMITIR HACER FACTURAS CON GUIA DE MESES ANTERIORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00040"
                _DescripcionPermiso = "PERMITIR CAMBIAR CONDICION DE MOVER O NO STOCK EN LA LINEA DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00041"
                _DescripcionPermiso = "PERMITIR GRABAR BOLETA NOMINATIVA DE VENTA SIN EXIGIR EL PAGO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00042"
                _DescripcionPermiso = "PERMITIR INCORPORAR CONCEPTOS DE DESCUENTO O RECARGO SIN VALOR EN DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00043"
                _DescripcionPermiso = "MODIFICAR CONCEPTOS DE DESCUENTO EN LA LINEA DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00044"
                _DescripcionPermiso = "MODIFICAR CONCEPTOS DE RECARGO EN LA LINEA DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00045"
                _DescripcionPermiso = "CERRAR RESERVA DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00046"
                _DescripcionPermiso = "RE-IMPRIMIR RESERVA DE ORDEN DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00047"
                _DescripcionPermiso = "UTILIZAR RESERVA DE ORDEN DE COMPRA DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00048"
                _DescripcionPermiso = "MOSTRAR COLUMNA DE DESCUENTO MAXIMO DE LA ENTIDAD POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00049"
                _DescripcionPermiso = "PODER GRABAR O VER DOCUMENTOS EN STAND-BY"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00050"
                _DescripcionPermiso = "GRABAR DOCUMENTO SIN EXIGIR HUELLA DIGITAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00051"
                _DescripcionPermiso = "PERMITIR INGRESAR CODIGOS CON EL TECLADO EN VALIDADOR POR CODIGOS DE BARRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00052"
                _DescripcionPermiso = "PERMITIR CAMBIAR LA FECHA DE EMISION EN DOCUMENTOS VISADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00053"
                _DescripcionPermiso = "PERMITIR GRABAR DOCUMENTOS QUE NECESITAN CONCEPTOS OBLIGATORIOS SEGUN TIPO DE PAGO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00054"
                _DescripcionPermiso = "PERMITIR CREAR GUIAS MANTENIENDO LAS BODEGAS ORIGINALES DE LOS DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00055"
                _DescripcionPermiso = "REACTIVACION DE DOCUMENTOS DE COMPROMISO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00056"
                _DescripcionPermiso = "CAMBIAR LAS BODEGAS A LA BODEGA DE LA MODALIDAD DESDE UN DOC. CON OTRAS BODEGAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00057"
                _DescripcionPermiso = "CONFIGURAR SALIDA DE IMPRESION DE DOCUMENTOS HACIA UN DIABLITO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00058"
                _DescripcionPermiso = "CONFIGURAR SALIDA DE IMPRESORA LOCAL/RED"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00059"
                _DescripcionPermiso = "ANULAR/ELIMINAR DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00060"
                _DescripcionPermiso = "PERMITIR GRABAR OCC CON PRODUCTOS QUE TIENEN ORDENES DE COMPRA PRENDIENTES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00061"
                _DescripcionPermiso = "PERMITIR GRABAR OCC CON PRODUCTOS QUE TIENEN DISTINTO COSTO EN LISTA DEL DOCUMENTO VS LISTA DE COSTOS DEL PROVEEDOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00062"
                _DescripcionPermiso = "PERMITIR GRABAR OCC CON CONCEPTOS SIN DISTRIBUCION DE RECARGOS A DOCUMENTOS OBLIGATORIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00063"
                _DescripcionPermiso = "CREAR (NVI) ORDEN DE SOLICITUD INTERNA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00064"
                _DescripcionPermiso = "CAMBIAR CARPETA DE SALIDAD PARA CREACION DE PDF AUTOMATICO POR MODALIDAD, DOCUMENTO Y ESTACION DE TRABAJO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00065"
                _DescripcionPermiso = "CAMBIAR NUMERO DEL LIBRO DE COMPRAS EN FCC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00066"
                _DescripcionPermiso = "PERMITIR GRABAR DOCUMENTOS SIN TRANSPORTISTA EN DOC. QUE LO OBLIGAN A LLEVAR (Retirador de mercadería/Placa patente)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00067"
                _DescripcionPermiso = "PERMITIR VIZUALIZAR EL COSTO DEL PRODUCTO DE SU LISTA OFICIAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00068"
                _DescripcionPermiso = "CAMBIAR CARPETAS PARA CONFIGURACION DE GRI DESDE TXT (ESPECIAL)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00069"
                _DescripcionPermiso = "CREAR (GRD) GUIA DE RECEPCION DE DEVOLUCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00070"
                _DescripcionPermiso = "ELIMINAR Y ANULAR MIS VALES TRANSITORIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00071"
                _DescripcionPermiso = "ELIMINAR Y ANULAR VALES TRANSITORIOS DE OTROS FUNCIONARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00072"
                _DescripcionPermiso = "IMPRIMIR DOCUMENTO EN CONSTRUCCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00073"
                _DescripcionPermiso = "EDITAR NVV CON PERMISO DE EXTENEDER FECHA DE DESPACHO EN DOCUMENTOS DE VENTA YA ASIGNADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00074"
                _DescripcionPermiso = "GRABAR (NCV) NOTA DE CREDITO DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00075"
                _DescripcionPermiso = "MODIFICAR PRECIO DE VENTA DEL PRODUCTO EN COTIZACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00076"
                _DescripcionPermiso = "MODIFICAR DESCUENTO EN LA LÍNEA DEL PRODUCTOS EN COTIZACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00077"
                _DescripcionPermiso = "MODIFICAR OPCION DE FECHAS AL GRABAR GDV PROCEDIENTE DESDE OTRO DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00078"
                _DescripcionPermiso = "CAMBIAR EL PERMISO PARA PODER LEER CODIGOS DE BARRA/QR UNICOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00079"
                _DescripcionPermiso = "PERMITIR CAMBIAR LA DESCRIPCION DE UN CONCEPTO EN UN DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00080"
                _DescripcionPermiso = "PERMITIR GRABAR UN DOCUMENTO QUE NO TENGA RELACION CON OTRO, CUANDO NO TENGO PERMISO PARA REALIZAR ESA ACCION."
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00081"
                _DescripcionPermiso = "CREAR DOCUMENTOS DESDE DTE XML ENVIADO POR PROVEEDORES."
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00082"
                _DescripcionPermiso = "HABILITAR NOTAS DE VENTA PARA SER FACTURADAS DE OTROS USUARIOS/VENDEDORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00083"
                _DescripcionPermiso = "PERMITIR EDITAR NOTAS DE VENTA HABILITADAS PARA SER FACTURADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00084"
                _DescripcionPermiso = "PERMITIR INGRESAR A REVISAR EN SITUACIÓN COMERCIAL DE DOCUMENTOS DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00085"
                _DescripcionPermiso = "PERMITIR GENERAR ORDEN DE COMPRA BAJO EL MINIMO ESTABLECIDO POR PROVEEDOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00085"
                _DescripcionPermiso = "PERMITIR GENERAR ORDEN DE COMPRA BAJO EL MINIMO ESTABLECIDO POR PROVEEDOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00086"
                _DescripcionPermiso = "CREAR (GRI) GUIAS DE RECEPCION INTERNA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00087"
                _DescripcionPermiso = "CREAR (GRI) GUIAS DE RECEPCION INTERNA - AJUSTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00088"
                _DescripcionPermiso = "CREAR (GDI) GUIAS DE DESPACHO INTERNA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00089"
                _DescripcionPermiso = "CREAR (GDI) GUIAS DE DESPACHO INTERNA - AJUSTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00090"
                _DescripcionPermiso = "PERMITIR CAMBIAR LA FECHA DE EMISION EN DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00091"
                _DescripcionPermiso = "PERMITIR DESMARCAR EL CHECK ""NO VOLVER A PREGUNTAR"". EN INGRESO DE PRODUCTO DUPLICADO EN DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00092"
                _DescripcionPermiso = "PERMITIR INGRESAR PRODUCTOS DUPLICADOS EN DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00093"
                _DescripcionPermiso = "CAMBIAR A ELECTRONICO UNA FACTURA DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00094"
                _DescripcionPermiso = "PERMITIR CREAR (GDI) GUIAS DE DESPACHO INTERNA SIN MODO DE TRASPASO INTERNO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

            Case "Doc00095"
                _DescripcionPermiso = "PERMITIR CREAR (GDI) GUIAS DE DESPACHO INTERNA EN MODO DE TRASPASO INTERNO, PERO SIN ASIGNAR UNA BODEGA DE DESTINO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DOCUMENTOS, 6)
                _NombreFamiliaPermiso = _Fml.DOCUMENTOS.ToString

        End Select

#End Region

#Region "ESPECIALES"

        Select Case _CodPermiso

            Case "Espr0001"
                _DescripcionPermiso = "INGRESAR MODULO PRECIOS MTS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0002"
                _DescripcionPermiso = "INGRESAR MODULO PRECIOS FERRETERIA O´HIGGINS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0003"
                _DescripcionPermiso = "INGRESAR AL MODULO CÓDIGOS DE BARRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0004"
                _DescripcionPermiso = "CAMBIAR ENTIDAD DEL DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0005"
                _DescripcionPermiso = "DEJAR GRI COMO DESDE OT"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0006"
                _DescripcionPermiso = "OCULTAR/DESOCULTAR PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0007"
                _DescripcionPermiso = "CAMBIAR FECHAS DE VENCIMIENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0008"
                _DescripcionPermiso = "REAJUSTAR FECHAS DE VENCIMIENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0009"
                _DescripcionPermiso = "INGRESAR A PERMISOS REMOTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0010"
                _DescripcionPermiso = "CAMBIAR DE BASE DE DATOS EN TPO. DE OPERACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0011"
                _DescripcionPermiso = "CAMBIAR ENTIDAD DE COTIZACIÓN"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0015"
                _DescripcionPermiso = "INGRESAR AL MENU DE COMPRAS "
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0016"
                _DescripcionPermiso = "INGRESAR AL MENU DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0017"
                _DescripcionPermiso = "INGRESAR AL MENU LISTA DE PRECIOS/COSTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0018"
                _DescripcionPermiso = "INGRESAR AL MENU DE PARAMETROS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0019"
                _DescripcionPermiso = "INGRESAR AL MENU DE INVENTARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0020"
                _DescripcionPermiso = "INGRESAR AL MENU DE INFORMES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0021"
                _DescripcionPermiso = "INGRESAR MENU PROGRAMAS ESPECIALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0022"
                _DescripcionPermiso = "INGRESAR MENU SERVICIO TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0023"
                _DescripcionPermiso = "INGRESAR MENU DE TESORERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0024"
                _DescripcionPermiso = "CARGAR TABLA DE FAMILIAS CON DESCUENTOS DE MTS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0025"
                _DescripcionPermiso = "CARGAR LISTAS DE COSTO DE UN PROVEEDOR DE MTS A RANDOM"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0026"
                _DescripcionPermiso = "GRABAR LISTA MTS EN LISTA RANDOM"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0027"
                _DescripcionPermiso = "VER ÚLTIMA CARGA DE LISTA MTS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0028"
                _DescripcionPermiso = "LEVANTAR LISTAS DE COSTOS DE PROVEEDORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0029"
                _DescripcionPermiso = "INGRESAR A PERMISOS REMOTOS OCC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0030"
                _DescripcionPermiso = "INGRESAR A PERMISOS REMOTOS NVV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0031"
                _DescripcionPermiso = "INGRESAR AL REGISTRO DE HUELLAS DIGITALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0032"
                _DescripcionPermiso = "DEFINIR TIPOS DE MONEDAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0033"
                _DescripcionPermiso = "ELIMINAR MONEDAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString
            Case "Espr0034"
                _DescripcionPermiso = "EDITAR DATOS DEL DOCUMENTO DE PAGO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ESPECIALES, 6)
                _NombreFamiliaPermiso = _Fml.ESPECIALES.ToString

        End Select

#End Region

#Region "OFERTAS"

        Select Case _CodPermiso

            Case "Ofer0001"
                _DescripcionPermiso = "PERMITIR INGRESAR A OFERTAS DINAMICAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.OFERTAS, 6)
                _NombreFamiliaPermiso = _Fml.OFERTAS.ToString
            Case "Ofer0002"
                _DescripcionPermiso = "CREAR OFERTAS DINAMICAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.OFERTAS, 6)
                _NombreFamiliaPermiso = _Fml.OFERTAS.ToString
            Case "Ofer0003"
                _DescripcionPermiso = "EDITAR OFERTAS DINAMICAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.OFERTAS, 6)
                _NombreFamiliaPermiso = _Fml.OFERTAS.ToString
            Case "Ofer0004"
                _DescripcionPermiso = "ELIMINAR OFERTAS DINAMICAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.OFERTAS, 6)
                _NombreFamiliaPermiso = _Fml.OFERTAS.ToString
            Case "Ofer0005"
                _DescripcionPermiso = "ASOCIAR PRODUCTOS A OFERTAS DINAMICAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.OFERTAS, 6)
                _NombreFamiliaPermiso = _Fml.OFERTAS.ToString
            Case "Ofer0006"
                _DescripcionPermiso = "DESASOCIAR PRODUCTOS DE OFERTAS DINAMICAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.OFERTAS, 6)
                _NombreFamiliaPermiso = _Fml.OFERTAS.ToString
            Case "Ofer0007"
                _DescripcionPermiso = "PERMITIR SELECCIONAR MAS PRODUCTOS QUE LOS RECOMENDADOS A LEVANTAR DE UNA SOLA VEZ EN UNA OFERTA DINAMICA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.OFERTAS, 6)
                _NombreFamiliaPermiso = _Fml.OFERTAS.ToString
            Case "Ofer0008"
                _DescripcionPermiso = "EDITAR CANTIDAD MAXIMA DE SELECCION DE PRODUCTOS PARA ASOCIAR A UNA OFERTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString

        End Select

#End Region

#Region "DTE FACTURA ELECTRONICA"

        Select Case _CodPermiso

            Case "Dte00001"
                _DescripcionPermiso = "REENVIAR DOCUMENTOS DTE AL SII"
                _CodFamilia = Fx_Rellena_ceros(_Fml.FACTURA_ELECTRONICA, 6)
                _NombreFamiliaPermiso = _Fml.FACTURA_ELECTRONICA.ToString

            Case "Dte00002"
                _DescripcionPermiso = "INGRESAR AL SIS. DE ADMINISTRACION DE FACTURA ELECTRONICA BAKAPP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.FACTURA_ELECTRONICA, 6)
                _NombreFamiliaPermiso = _Fml.FACTURA_ELECTRONICA.ToString

            Case "Dte00003"
                _DescripcionPermiso = "CONFIGURAR SIS. FACTURACION ELECTRONICA BAKAPP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.FACTURA_ELECTRONICA, 6)
                _NombreFamiliaPermiso = _Fml.FACTURA_ELECTRONICA.ToString

        End Select

#End Region

#Region "FORMATOS"

        Select Case _CodPermiso

            Case "Fmto0001"
                _DescripcionPermiso = "CONFIGURACION DE FORMATOS DE DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.FORMATOS, 6)
                _NombreFamiliaPermiso = _Fml.FORMATOS.ToString

        End Select

#End Region

#Region "INFORMES DE COMPRAS"

        Select Case _CodPermiso

            Case "Inc00001"
                _DescripcionPermiso = "INFORME DE VENCIMIENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_COMPRA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_COMPRA.ToString
            Case "Inc00002"
                _DescripcionPermiso = "INFORME INDICES DE COMPRAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_COMPRA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_COMPRA.ToString
            Case "Inc00003"
                _DescripcionPermiso = "INFORME DE PRÓXIMAS RECEPCIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_COMPRA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_COMPRA.ToString
        End Select

#End Region

#Region "INFORMES DE STOCK"

        Select Case _CodPermiso

            Case "Infst005"
                _DescripcionPermiso = "INFORME DE STOCK VALORIZADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_STOCK, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_STOCK.ToString
            Case "Infst010"
                _DescripcionPermiso = "MOSTRAR VALORES EN INFORME DE STOCK"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_STOCK, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_STOCK.ToString
        End Select

#End Region

#Region "INFORMES DE VENTAS"

        Select Case _CodPermiso

            Case "Inf00002"
                _DescripcionPermiso = "INFORME MARGENES DEL PERIODO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00003"
                _DescripcionPermiso = "INFORME DOCUMENTOS DE PAGO A PROVEEDORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00004"
                _DescripcionPermiso = "INFORME RANKING DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00005"
                _DescripcionPermiso = "CAMBIAR TABLA DE RANKING DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00006"
                _DescripcionPermiso = "ACEPTAR CLASIFICACIÓN DE RANKING"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00007"
                _DescripcionPermiso = "GRABAR RANKING EN MAESTRO DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00008"
                _DescripcionPermiso = "IR AL PROCESO DE CLASIFICACIÓN DE RANKING DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00009"
                _DescripcionPermiso = "INFORME DE VENCIMIENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00010"
                _DescripcionPermiso = "INFORME DE VENTAS POR VENDEDOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00011"
                _DescripcionPermiso = "MODIFICAR FILTRO INFORME DE VENTA POR VENDEDOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00012"
                _DescripcionPermiso = "INFORME DE COMPROMISOS NO DESPACHADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00013"
                _DescripcionPermiso = "MODIFICAR FILTRO DE COMPROMISOS NO DESPACHADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00014"
                _DescripcionPermiso = "INGRESAR A INFORMES DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00015"
                _DescripcionPermiso = "INGRESAR A INFORMES DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00016"
                _DescripcionPermiso = "INGRESAR A INFORMES DE STOCK"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00017"
                _DescripcionPermiso = "INFORME DE VENTAS POR PERIODO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00018"
                _DescripcionPermiso = "CRÉDITO VIGENTE, COMPORTAMIENTO PAGO, CHEQUES EN CARTERA "
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00019"
                _DescripcionPermiso = "INFORME DE COMPROMISOS NO DESPACHADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00020"
                _DescripcionPermiso = "INGRESAR A INFORME COMPARATIVO DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00025"
                _DescripcionPermiso = "PODER VER INFORME DE VENTAS DE OTROS FUNCIONARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00030"
                _DescripcionPermiso = "INGRESAR AL INFORME DE PROYECCION DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00035"
                _DescripcionPermiso = "EXPORTAR A EXCEL INFORME DE CLIENTES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00036"
                _DescripcionPermiso = "EXPORTAR A EXCEL ENCABEZADO DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00037"
                _DescripcionPermiso = "EXPORTAR A EXCEL DETALLE DE PRODUCTOS DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00038"
                _DescripcionPermiso = "EXPORTAR A EXCEL INFORME COMPARATIVO DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00039"
                _DescripcionPermiso = "EXPORTAR A EXCEL INFORME DE PROYECCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00040"
                _DescripcionPermiso = "EXPORTAR A EXCEL INFORME DETALLE PRODUCTOS VENDIDOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00041"
                _DescripcionPermiso = "EXPORTAR A EXCEL INFORME CLIENTES VS VENTAS POR PERIODO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00042"
                _DescripcionPermiso = "EXPORTAR A EXCEL VENTAS POR PERIODO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00043"
                _DescripcionPermiso = "VER INFORME DE CLIENTES ASOCIADOS A OTRO USUARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00044"
                _DescripcionPermiso = "EXPORTAR A EXCEL DIFERENCIA DE CLIENTES ENTRE RANGO 1 Y RANGO 2 EN INFORME COMPARATIVO DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00045"
                _DescripcionPermiso = "EXPORTAR A EXCEL DIFERENCIA DE PRODUCTOS ENTRE RANGO 1 Y RANGO 2 EN INFORME COMPARATIVO DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00046"
                _DescripcionPermiso = "QUITAR EL TICKET VER SOLO NOTAS DE VENTA HABILITADAS PARA FACTURAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00047"
                _DescripcionPermiso = "VER INFORME DE CUMPLIMIENTO DE CLIENTES VS CARTERA DEL VENDEDOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString
            Case "Inf00048"
                _DescripcionPermiso = "EXPORTAR A EXCEL INFORME CLIENTES VS VENTAS POR PERIODO (NIVEL DETALLE)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INFORMES_DE_VENTA, 6)
                _NombreFamiliaPermiso = _Fml.INFORMES_DE_VENTA.ToString

        End Select

#End Region

#Region "INVENTARIO"

        Select Case _CodPermiso

            Case "Invg0001"
                _DescripcionPermiso = "INGRESAR SISTEMA DE INVENTARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString
            Case "Invg0002"
                _DescripcionPermiso = "CONFIGURAR INVENTARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString
            Case "Invg0003"
                _DescripcionPermiso = "INGRESAR RECONTEO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString
            Case "Invg0004"
                _DescripcionPermiso = "ELIMINAR RECONTEO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString
            Case "Invg0005"
                _DescripcionPermiso = "ABRIR INVENTARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString
            Case "Invg0006"
                _DescripcionPermiso = "CERRAR INVENTARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString
            Case "Invg0007"
                _DescripcionPermiso = "CREAR FOTO STOCK"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString
            Case "Invg0008"
                _DescripcionPermiso = "ELIMINAR FOTO STOCK"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO.ToString


        End Select

#End Region

#Region "INVENTARIO PARCIALIZADO"

        Select Case _CodPermiso

            Case "Invp0001"
                _DescripcionPermiso = "INGRESAR AL SISTEMA INVENTARIO PARCIALIZADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO_PARCIALIZADO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO_PARCIALIZADO.ToString
            Case "Invp0002"
                _DescripcionPermiso = "GRABAR DATOS INVENTARIO PARCIALIZADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO_PARCIALIZADO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO_PARCIALIZADO.ToString
            Case "Invp0003"
                _DescripcionPermiso = "CREAR ARCHIVO .TXT INVENTARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.INVENTARIO_PARCIALIZADO, 6)
                _NombreFamiliaPermiso = _Fml.INVENTARIO_PARCIALIZADO.ToString

        End Select

#End Region

#Region "LISTA PRECIOS Y COSTOS"

        Select Case _CodPermiso

            Case "Pre0001"
                _DescripcionPermiso = "VER ULTIMAS COMPRAS PARA CAMBIAR PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0002"
                _DescripcionPermiso = "CAMBIAR PRECIOS LC_PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0003"
                _DescripcionPermiso = "CONFIGURAR FORMULA DE ACTUALIZACION PARA LAS LISTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0004"
                _DescripcionPermiso = "CONFIGURAR FORMULAS DE LOS RANGOS DE LAS LISTAS DE PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString

            Case "Pre0008"
                _DescripcionPermiso = "MANTENCION DE PRECIOS/COSTOS (BAKAPP)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0009"
                _DescripcionPermiso = "MODIFICAR FORMULA MANT. PRECIOS GLOBAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0010"
                _DescripcionPermiso = "CONSULTA SQL PARA ACTUALIZAR DATOS EN RANDOM"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0011"
                _DescripcionPermiso = "GRABAR DATOS EN LISTAS DE PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0012"
                _DescripcionPermiso = "MANTENCION DE LISTA DE PRECIOS (BAKAPP)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0013"
                _DescripcionPermiso = "MANTENCION DE LISTA DE COSTOS(BAKAPP)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0014"
                _DescripcionPermiso = "MANTENCIÓN PRECIOS WEB (PRESTASHOP)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
            Case "Pre0020"
                _DescripcionPermiso = "PODER USAR TODAS LOS REDONDEDOS CON LISTAS EN BRUTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString

            Case "Pre0021"
                _DescripcionPermiso = "CAMBIAR OPCIONES PARA VER PRODUCTOS BLOQUEADOS O NO EN LA LISTA DE PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
                'Case "Pre0022"
                '    _DescripcionPermiso = "TRAER PRODUCTOS BLOQUEADOS EN VENTA AL TRATAMIENTO DE PRECIOS Y COSTOS"
                '    _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                '    _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
                'Case "Pre0023"
                '    _DescripcionPermiso = "TRAER PRODUCTOS BLOQUEADOS EN COMPRA Y VENTA AL TRATAMIENTO DE PRECIOS Y COSTOS"
                '    _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                '    _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString
                'Case "Pre0024"
                '    _DescripcionPermiso = "TRAER PRODUCTOS BLOQUEADOS EN COMPRA, VENTA Y PRODUCCION AL TRATAMIENTO DE PRECIOS Y COSTOS"
                '    _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                '    _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString

            Case "Pre0025"
                _DescripcionPermiso = "CAMBIAR LISTA DE PRECIOS EN FORMULARIO PARA IMPRIMIR ETIQUETAS DE PRECIO FUTURO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.LISTA_PRECIOS_Y_COSTOS, 6)
                _NombreFamiliaPermiso = _Fml.LISTA_PRECIOS_Y_COSTOS.ToString


        End Select

#End Region

#Region "NOTIFICACIONES"

        Select Case _CodPermiso

            Case "Not0001"
                _DescripcionPermiso = "RECIBIR NOTIFICACIONES DE SOLICITUDES DE COMPRA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.NOTIFICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.NOTIFICACIONES.ToString
            Case "Not0002"
                _DescripcionPermiso = "RECIBIR NOTIFICACIONES DE ORDENES DE COMPRA GENERADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.NOTIFICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.NOTIFICACIONES.ToString
            Case "Not0003"
                _DescripcionPermiso = "RECIBIR NOTIFICACIONES DE ACEPTACION DE SC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.NOTIFICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.NOTIFICACIONES.ToString
            Case "Not0004"
                _DescripcionPermiso = "RECIBIR NOTIFICACIONES DE ORDEN DE COMPRA ACEPTADA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.NOTIFICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.NOTIFICACIONES.ToString
            Case "Not0005"
                _DescripcionPermiso = "RECIBIR NOTIFICACIONES DE ORDEN DE COMPRA RECHAZADA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.NOTIFICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.NOTIFICACIONES.ToString
            Case "Not0006"
                _DescripcionPermiso = "RECIBIR NOTIFICACIONES DE SOLICITUD DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.NOTIFICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.NOTIFICACIONES.ToString
            Case "Not0007"
                _DescripcionPermiso = "RECIBIR CORREOS DE RECEPCIÓN DE GRC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.NOTIFICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.NOTIFICACIONES.ToString
        End Select

#End Region

#Region "PAGO CLIENTES"

        Select Case _CodPermiso

            Case "Pcli0001"
                _DescripcionPermiso = "INGRESAR PAGO A DOCUMENTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_CLIENTES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_CLIENTES.ToString

        End Select

#End Region

#Region "CONTABILIDAD"

        Select Case _CodPermiso

            Case "Cont0001"
                _DescripcionPermiso = "INGRESAR A LIQUIDACION DE TARJETAS DE CREDITO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CONTABILIDAD, 6)
                _NombreFamiliaPermiso = _Fml.CONTABILIDAD.ToString

        End Select

#End Region

#Region "CAJERO AUTOMATICO"

        Select Case _CodPermiso

            Case "Cdro0001"
                _DescripcionPermiso = "INICIAR CASHDRO (CAJA AUTOSERVICIO)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CASHDRO, 6)
                _NombreFamiliaPermiso = _Fml.CASHDRO.ToString

            Case "Cdro0002"
                _DescripcionPermiso = "CONFIGURAR CASHDRO (CAJA AUTOSERVICIO)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CASHDRO, 6)
                _NombreFamiliaPermiso = _Fml.CASHDRO.ToString

            Case "Cdro0003"
                _DescripcionPermiso = "CERRAR INGRESO DE DOCUMENTOS (CAJA AUTOSERVICIO)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.CASHDRO, 6)
                _NombreFamiliaPermiso = _Fml.CASHDRO.ToString

        End Select

#End Region

#Region "PAGO PROVEEDORES"

        Select Case _CodPermiso

            Case "Ppro0001"
                _DescripcionPermiso = "AUTORIZAR A PAGAR DOCUMENTOS SOSPECHOSOS (CON REFLEOS)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0002"
                _DescripcionPermiso = "AUTORIZAR A PAGAR DOCUMENTOS GDD Y SIN NCC (PAGO A PROVEEDORES)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0003"
                _DescripcionPermiso = "AUTORIZAR A MARCAR DOCUMENTOS PARA PAGAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0004"
                _DescripcionPermiso = "PAGAR A PROVEEDORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0005"
                _DescripcionPermiso = "CAMBIAR FECHA DE VENCIMIENTO DEL PAGO PRE-ESTABLECIDA EN ASIGNACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0006"
                _DescripcionPermiso = "QUITAR DOCUMENTOS AUTORIZADOS DEL TRATAMIENTO DE PAGO A PROVEEDORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0007"
                _DescripcionPermiso = "INGRESAR AL MODULO DE TESORERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0008"
                _DescripcionPermiso = "EDITAR ENCABEZADO DE AUTORIZACION DE PAGO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0009"
                _DescripcionPermiso = "ELIMINAR AUTORIZACION DE PAGO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0010"
                _DescripcionPermiso = "EDITAR NRO. CHEQUE O NRO. CTA. CTE."
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0011"
                _DescripcionPermiso = "PAGOS GENERALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
            Case "Ppro0012"
                _DescripcionPermiso = "SUBIR PAGOS MASIVAMENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PAGO_PROVEEDORES, 6)
                _NombreFamiliaPermiso = _Fml.PAGO_PROVEEDORES.ToString
        End Select

#End Region

#Region "Pocket PC WCE"

        Select Case _CodPermiso

            Case "Bkw00001"
                _DescripcionPermiso = "BK_POSWI"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00001"
                _DescripcionPermiso = "CONFIGURAR POST"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00002"
                _DescripcionPermiso = "CODIGOS ALTERNATIVOS (POCKET_PC_WCE)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00003"
                _DescripcionPermiso = "EDITAR DOCUMENTOS DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00004"
                _DescripcionPermiso = "IMPRIMIR DOCUMENTOS DE OTROS USUARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00005"
                _DescripcionPermiso = "ENVIAR DOC. POR CORREO DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00006"
                _DescripcionPermiso = "MODIFICAR PRECIO DE VENTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00007"
                _DescripcionPermiso = "TRANSFORMAR EN NOTA DE VENTA DOC. DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00008"
                _DescripcionPermiso = "RESETEAR BAKAPP POSWI"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00009"
                _DescripcionPermiso = "INGRESAR MENU OPCIONES ESPECIALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00010"
                _DescripcionPermiso = "AUTORIZAR A MANTENER LOS PRECIOS CUANDO LOS DOCUMENTOS VENCEN"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00011"
                _DescripcionPermiso = "CAMBIAR TIPO DE DOCUMENTO EN DESPACHO SIMPLE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
            Case "Pbk00040"
                _DescripcionPermiso = "INGRESAR INVENTARIO DESDE BAKAPP POSWI"
                _CodFamilia = Fx_Rellena_ceros(_Fml.POCKET_PC_WCE, 6)
                _NombreFamiliaPermiso = _Fml.POCKET_PC_WCE.ToString
        End Select

#End Region

#Region "WEB PRESTASHOP"

        Select Case _CodPermiso

            Case "Pshop001"
                _DescripcionPermiso = "INGRESAR AL MODULO DE PRESTASHOP "
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRESTASHOP, 6)
                _NombreFamiliaPermiso = _Fml.PRESTASHOP.ToString
            Case "Pshop002"
                _DescripcionPermiso = "CONFIGURAR CONEXIONES PRESTASHOP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRESTASHOP, 6)
                _NombreFamiliaPermiso = _Fml.PRESTASHOP.ToString
            Case "Pshop003"
                _DescripcionPermiso = "ENVIAR SOLICITUD MANUAL PRESTASHOP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRESTASHOP, 6)
                _NombreFamiliaPermiso = _Fml.PRESTASHOP.ToString

        End Select

#End Region

#Region "PRODUCTOS"

        Select Case _CodPermiso

            Case "Prod001"
                _DescripcionPermiso = "CREAR PRODUCTO DESDE SOLICITUD"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod002"
                _DescripcionPermiso = "VER CARDEX DE INVENTARIO POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod003"
                _DescripcionPermiso = "CAMBIO CÓDIGO DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod004"
                _DescripcionPermiso = "OCULTAR/DESOCULTAR PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod005"
                _DescripcionPermiso = "CREAR/MANT. R.T.U."
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod006"
                _DescripcionPermiso = "UNIFICAR PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod007"
                _DescripcionPermiso = "CREAR PRODUCTO (MATRIZ ESPECIAL)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod008"
                _DescripcionPermiso = "CREAR PRODUCTO SIN CÓDIGO ALTERNATIVO (MATRIZ ESPECIAL)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod009"
                _DescripcionPermiso = "VER ESTADÍSTICAS DEL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod010"
                _DescripcionPermiso = "MANTENCIÓN DE PRODUCTOS DE REEMPLAZO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod011"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN ASIGNAR PRECIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod012"
                _DescripcionPermiso = "MANTENCIÓN DE CREACIÓN DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod013"
                _DescripcionPermiso = "CREAR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod014"
                _DescripcionPermiso = "EDITAR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod015"
                _DescripcionPermiso = "ELIMINAR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod016"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN CLASIFICACIÓN EN ARBOL DE CLASIFICACIONES (BUSQUEDA RAPIDA)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod017"
                _DescripcionPermiso = "CREAR CÓDIGOS ALTERNATIVOS POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod018"
                _DescripcionPermiso = "EDITAR DESCRIPCIÓN DE CÓDIGO ALTERNATIVO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod019"
                _DescripcionPermiso = "ELIMINAR CÓDIGO ALTERNATIVO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod020"
                _DescripcionPermiso = "VER CÓDIGOS ALTERNATIVOS POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod021"
                _DescripcionPermiso = "VER ASOCIACIONES/CLASIFICACIONES DEL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod022"
                _DescripcionPermiso = "INCORPORAR CLASIFICACIÓN AL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod023"
                _DescripcionPermiso = "QUITAR CLASIFICACIÓN AL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod024"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN JEFE DE PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod025"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN ZONA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod026"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN MARCA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod027"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN LISTA DE COSTOS POR DEFECTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod028"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN RUBRO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod029"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN CLASIFICACION LIBRE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod030"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN SUPER FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod031"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod033"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN SUB FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod034"
                _DescripcionPermiso = "CREAR CÓDIGOS ALTERNATIVOS POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod035"
                _DescripcionPermiso = "EDITAR DESCRIPCIÓN DE CÓDIGO ALTERNATIVO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod036"
                _DescripcionPermiso = "ELIMINAR CÓDIGO ALTERNATIVO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod037"
                _DescripcionPermiso = "VER CÓDIGOS ALTERNATIVOS POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod038"
                _DescripcionPermiso = "VER ASOCIACIONES/CLASIFICACIONES DEL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod039"
                _DescripcionPermiso = "INCORPORAR CLASIFICACIÓN AL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod040"
                _DescripcionPermiso = "QUITAR CLASIFICACIÓN AL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod041"
                _DescripcionPermiso = "GRABAR CODIGOS DE REEMPLAZO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod042"
                _DescripcionPermiso = "CAMBIAR CÓDIGOS MASIVAMENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod043"
                _DescripcionPermiso = "CREAR CÓDIGOS ALTERNATIVOS POR PRODUCTO (CÓDIGO DE PRODUCTOS SIN PROVEEDOR)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod045"
                _DescripcionPermiso = "VER ARCHIVOS ADJUNTOS DEL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod046"
                _DescripcionPermiso = "SUBIR ARCHIVOS ADJUNTOS PARA EL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod047"
                _DescripcionPermiso = "ELIMINAR ARCHIVO ADJUNTO DEL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod050"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN CLASIFICACIÓN UNICAS EN ARBOL DE CLASIFICACIONES (CLAS. UNICAS)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod051"
                _DescripcionPermiso = "VER ULTIMAS COMPRAS INFO. PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod055"
                _DescripcionPermiso = "CONSOLIDAR DE STOCK"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod056"
                _DescripcionPermiso = "VER PRODUCTOS ASOCIADOS, DE LA MISMA CLASIFICACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod057"
                _DescripcionPermiso = "VER ESTADÍSTICAS DEL PRODUCTO DE OTRA EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod058"
                _DescripcionPermiso = "CAMBIAR UBICACION DEL PRODUCTO EN RANDOM"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod060"
                _DescripcionPermiso = "GESTIONAR SOLICITUDES DE COMPRA DE PRODUCTOS "
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod061"
                _DescripcionPermiso = "SOLICITAR PRODUCTOS PARA COMPRAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod062"
                _DescripcionPermiso = "ORDENAR BODEGAS EN BUSCADOR DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod063"
                _DescripcionPermiso = "ACTIVAR O DESACTIVAR EL INGRESO DE CANTIDADES AL LEER PRODUCTO EN PISTOLEO DE BARRAS EN DESPACHO/RECEPCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod064"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTOS SIN INCORPORAR DIMENSIONES OBLIGATORIAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod065"
                _DescripcionPermiso = "MODIFICAR LAS DIMENSIONES DE UN PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod066"
                _DescripcionPermiso = "COPIAR LAS DIMENSIONES DE UN PRODUCTO A OTROS PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod067"
                _DescripcionPermiso = "INGRESAR AL MANTENEDOR DE IMAGENES POR PRODUCTO DESDE URL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod068"
                _DescripcionPermiso = "AGREGAR UNA IMAGEN A UN PRODUCTO CON URL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod069"
                _DescripcionPermiso = "ELIMINAR IMAGEN DESDE URL DEL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod070"
                _DescripcionPermiso = "EXPORTAR A EXCEL LISTADO DE URL DE IMAGENES DE LOS PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod071"
                _DescripcionPermiso = "LEVANTAR IMAGENES EN FORMA MASIVA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod072"
                _DescripcionPermiso = "INGRESAR A CONFIGURACION DE IMPRESION ADICIONAL POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod073"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN 1RA. DIMENSION (OBLIGATORIO POR MOD. GENERAL)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod074"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN 2DA. DIMENSION (OBLIGATORIO POR MOD. GENERAL)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod075"
                _DescripcionPermiso = "PERMITIR GRABAR PRODUCTO SIN 3RA. DIMENSION (OBLIGATORIO POR MOD. GENERAL)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString
            Case "Prod076"
                _DescripcionPermiso = "EXPORTAR A EXCEL LISTADO DE PRODUCTOS DESDE EL MAESTRO DE PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCTOS, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCTOS.ToString


        End Select

#End Region

#Region "RESTRICCIONES"

        Select Case _CodPermiso

            Case "NO00001"
                _DescripcionPermiso = "NO PERMITIR VER COSTOS EN TPO. OPERACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00002"
                _DescripcionPermiso = "NO PERMITIR HACER DOCUMENTOS CON LISTAS DISTINTAS A LAS DEL CLIENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00003"
                _DescripcionPermiso = "NO PERMITIR HACER DOCUMENTOS CON ENTIDAD POR DEFECTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00004"
                _DescripcionPermiso = "NO MOSTRAR STOCK FISICO EN FORMULARIO EMERGENTE DE STOCK POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00005"
                _DescripcionPermiso = "NO MOSTRAR STOCK COMPROMETIDO EN FORMULARIO EMERGENTE DE STOCK POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00006"
                _DescripcionPermiso = "NO MOSTRAR STOCK DEVENGADO EN FORMULARIO EMERGENTE DE STOCK POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00007"
                _DescripcionPermiso = "NO MOSTRAR STOCK PEDIDO EN FORMULARIO EMERGENTE DE STOCK POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00008"
                _DescripcionPermiso = "NO MOSTRAR STOCK DISPONIBLE EN FORMULARIO EMERGENTE DE STOCK POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00009"
                _DescripcionPermiso = "NO PERMITIR GRABAR BLV SIN ADJUNTAR ARCHIVOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00010"
                _DescripcionPermiso = "NO PERMITIR GRABAR FCV SIN ADJUNTAR ARCHIVOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00011"
                _DescripcionPermiso = "NO PERMITIR GRABAR NVV SIN ADJUNTAR ARCHIVOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00012"
                _DescripcionPermiso = "SOLO RESCATAR DETALLE DE DOCUMENTOS DE BODEGAS QUE POSEE PERMISO EL USUARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00013"
                _DescripcionPermiso = "NO PERMITIR HACER GRI SIN RELACIONAR A GTI/GDI"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00014"
                _DescripcionPermiso = "NO PERMITIR HACER FCC SIN RELACIONAR A OCC/GRC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00015"
                _DescripcionPermiso = "NO PERMITIR HACER GRC SIN RELACIONAR A OCC/FCC"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00016"
                _DescripcionPermiso = "NO PERMITIR HACER FCV SIN RELACIONAR A NVV/GDV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00017"
                _DescripcionPermiso = "NO PERMITIR HACER GDV SIN RELACIONAR A NVV/FCV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00018"
                _DescripcionPermiso = "NO PERMITIR CREAR NVV SIN RELACIONAR A COV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00019"
                _DescripcionPermiso = "NO PERMITIR CREAR NCV SIN RELACIONAR A FCV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

            Case "NO00020"
                _DescripcionPermiso = "NO PERMITIR CREAR GRD SIN RELACIONAR A NCV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RESTRICCIONES, 6)
                _NombreFamiliaPermiso = _Fml.RESTRICCIONES.ToString

        End Select

#End Region

#Region "SII "

        Select Case _CodPermiso

            Case "RSii00001"
                _DescripcionPermiso = "INGRESAR A REVISION COMPRAS VS SII"
                _CodFamilia = Fx_Rellena_ceros(_Fml.REVISION_COMPRAS_SII, 6)
                _NombreFamiliaPermiso = _Fml.REVISION_COMPRAS_SII.ToString
            Case "RSii00002"
                _DescripcionPermiso = "CARGAR LIBRO DESDE SII"
                _CodFamilia = Fx_Rellena_ceros(_Fml.REVISION_COMPRAS_SII, 6)
                _NombreFamiliaPermiso = _Fml.REVISION_COMPRAS_SII.ToString

        End Select

#End Region

#Region "SERVICIO TECNICO "

        Select Case _CodPermiso

            Case "Stec0001"
                _DescripcionPermiso = "INGRESAR AL SIS. DE SERVICIO TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0002"
                _DescripcionPermiso = "CREAR NUEVA ORDEN DE TRABAJO SERV. TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0003"
                _DescripcionPermiso = "EDITAR ORDENES DE TRABAJO SERV. TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0004"
                _DescripcionPermiso = "ANULAR ORDENES DE TRABAJO SERV. TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0005"
                _DescripcionPermiso = "PODER GRABAR O.T. COMO GARANTIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0006"
                _DescripcionPermiso = "INGRESAR MANTENCION DE TECNICOS/TALLERES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0007"
                _DescripcionPermiso = "CREAR TECNICOS/TALLERES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0008"
                _DescripcionPermiso = "EDITAR TECNICOS/TALLERES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0009"
                _DescripcionPermiso = "HABILITAR/DESHABILITAR TECNICOS/TALLERES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0010"
                _DescripcionPermiso = "ELIMINAR TECNICOS/TALLERES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0011"
                _DescripcionPermiso = "CERRAR ORDEN DE TRABAJO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0012"
                _DescripcionPermiso = "IMPRIMIR ACTA RECEPCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0013"
                _DescripcionPermiso = "IMPRIMIR PRESUPUESTO TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0014"
                _DescripcionPermiso = "IMPRIMIR ACTA DE FINALIZACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0015"
                _DescripcionPermiso = "INGRESAR A CONF. DE NOTAS PRE-ESTABLECIDAS EN INFORMES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0016"
                _DescripcionPermiso = "EDITAR Y GRABAR NOTAS PRE-ESTABLECIDAS EN INFORMES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0017"
                _DescripcionPermiso = "EDITAR CHECK-IN DESPUES DE TENER ESTADOS POSTERIORES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0018"
                _DescripcionPermiso = "EXPORTAR ORDENES DE TRABAJO A EXCEL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0019"
                _DescripcionPermiso = "INGRESAR A CONFIGURACIONES DEL SIS. SERV. TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0020"
                _DescripcionPermiso = "PERMITIR GENERAR ORDENES DE SERVICIO CON DEUDA VENCIDA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0021"
                _DescripcionPermiso = "INGRESAR MANTENCION DE OPERACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0022"
                _DescripcionPermiso = "CREAR NUEVAS OPERACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0023"
                _DescripcionPermiso = "EDITAR OPERACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0024"
                _DescripcionPermiso = "ELIMINAR OPERACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0025"
                _DescripcionPermiso = "INGRESAR MANTENCION DE RECETAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0026"
                _DescripcionPermiso = "CREAR NUEVAS RECETAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0027"
                _DescripcionPermiso = "EDITAR RECETAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0028"
                _DescripcionPermiso = "ELIMINAR RECETAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0029"
                _DescripcionPermiso = "INGRESAR MANTENCION DE FILTRO PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString
            Case "Stec0030"
                _DescripcionPermiso = "INGRESAR MANTENCION DE BODEGAS DE SERVICIO TECNICO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SERVICIO_TECNICO, 6)
                _NombreFamiliaPermiso = _Fml.SERVICIO_TECNICO.ToString


        End Select

#End Region

#Region "NEGOCIOS"

        Select Case _CodPermiso

            Case "Scn00001"
                _DescripcionPermiso = "INGRESAR AL SISTEMA DE NEGOCIOS X CLIENTES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00002"
                _DescripcionPermiso = "INGRESAR A CONFIGURACION LOCAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00003"
                _DescripcionPermiso = "CAMBIAR DIRECTORIO DE CARPETAS PARA NEGOCIOS CONF. LOCAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00004"
                _DescripcionPermiso = "CREAR SOLICITUDES DE CREDITO DE NEGOCIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00005"
                _DescripcionPermiso = "GRABAR SOLICITUD DE CREDITO DE NEGOCIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00006"
                _DescripcionPermiso = "ANULAR SOLICITUD DE CREDITO DE NEGOCIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00007"
                _DescripcionPermiso = "COMITE DE NEGOCIOS SCN [GERENCIA GENERAL]"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00008"
                _DescripcionPermiso = "COMITE DE NEGOCIOS SCN [GERENCIA ADMINISTRACION Y FINANZAS]"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00009"
                _DescripcionPermiso = "COMITE DE NEGOCIOS SCN [GERENCIA CREDITO Y COBRANZA]"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00010"
                _DescripcionPermiso = "INGRESAR A RESOLUCION DE NEGOCIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00011"
                _DescripcionPermiso = "INGRESAR A MIS SOLICITUDES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00012"
                _DescripcionPermiso = "VER SCN DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00013"
                _DescripcionPermiso = "VER ARCHIVOS ADJUNTOS DEL NEGOCIO (FTP)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00014"
                _DescripcionPermiso = "CERRAR NEGOCIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00015"
                _DescripcionPermiso = "IMPRIMIR REPORTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00016"
                _DescripcionPermiso = "CERRAR NEGOCIOS PRE-APROBADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00017"
                _DescripcionPermiso = "GRABAR OBSERVACIONES, JEFE(A) DE CREDITO "
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00018"
                _DescripcionPermiso = "MANDAR A CORREGIR NEGOCIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00019"
                _DescripcionPermiso = "DEJAR UN MIEMBRO DEL COMITE COMO AUSENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00020"
                _DescripcionPermiso = "EXPORTAR A EXCEL INFORME DE NEGOCIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00021"
                _DescripcionPermiso = "EDITAR SCN DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString
            Case "Scn00025"
                _DescripcionPermiso = "COMITE DE NEGOCIOS SCN [AUTORIZACION EXTRAORDINARIA]"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SOLICITUD_NEGOCIO_CLIENTE, 6)
                _NombreFamiliaPermiso = _Fml.SOLICITUD_NEGOCIO_CLIENTE.ToString

        End Select

#End Region

#Region "SQL CONSULTAS"

        Select Case _CodPermiso

            Case "Sql00001"
                _DescripcionPermiso = "INGRESAR A VER CONSULTAS SQL PERSONALIZADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SQL_CONSULTAS, 6)
                _NombreFamiliaPermiso = _Fml.SQL_CONSULTAS.ToString
            Case "Sql00002"
                _DescripcionPermiso = "VER CONSULTAS SQL GLOBALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SQL_CONSULTAS, 6)
                _NombreFamiliaPermiso = _Fml.SQL_CONSULTAS.ToString
            Case "Sql00003"
                _DescripcionPermiso = "ELIMINAR CONSULTAS GLOBALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SQL_CONSULTAS, 6)
                _NombreFamiliaPermiso = _Fml.SQL_CONSULTAS.ToString
            Case "Sql00004"
                _DescripcionPermiso = "PODER CREAR CONSULTAS SQL GLOBALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SQL_CONSULTAS, 6)
                _NombreFamiliaPermiso = _Fml.SQL_CONSULTAS.ToString
            Case "Sql00005"
                _DescripcionPermiso = "PODER CREAR/EDITAR CONSULTAS SQL PERSONALIZADAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.SQL_CONSULTAS, 6)
                _NombreFamiliaPermiso = _Fml.SQL_CONSULTAS.ToString

        End Select

#End Region

#Region "TABLAS DEL SISTEMA"

        Select Case _CodPermiso

            Case "Tbl00001"
                _DescripcionPermiso = "MANTENCIÓN TABLAS DE FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00002"
                _DescripcionPermiso = "MANTENCIÓN DE CLASIFICACIONES (ARBOL)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00003"
                _DescripcionPermiso = "PODER CREAR UNA SUB-CLASIFICACIÓN COMO PADRE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00004"
                _DescripcionPermiso = "GRABAR CLASIFICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00005"
                _DescripcionPermiso = "EDITAR CLASIFICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00006"
                _DescripcionPermiso = "ELIMINAR CLASIFICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00007"
                _DescripcionPermiso = "CREAR CLASIFICACIONES DESDE ÁRBOL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00008"
                _DescripcionPermiso = "ELIMINAR CLASIFICACIONES CON SUB-CLASIFICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00009"
                _DescripcionPermiso = "ELIMINAR CLASIFICACIONES CON PRODUCTOS ASOCIADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00010"
                _DescripcionPermiso = "PODER MARCAR CLASIFICACIÓN COMO SELECCIONABLE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00011"
                _DescripcionPermiso = "PORDER EXPORTAR LAS CLASIFICACIONES A UN ARCHIVO .CSV"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00012"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE ACTIVIDAD ECONÓMICA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00013"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE TAMAÑO EMPRESA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00014"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE AREAS EMPRESARIALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00015"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE TIPOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00016"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE MARCAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00017"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE RUBROS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00018"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE ZONAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00019"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE CARGOS EMPRESARIALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00020"
                _DescripcionPermiso = "MANTENCIÓN DE CLASIFICACIÓN LIBRE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00021"
                _DescripcionPermiso = "PORDER EXPORTAR LAS CLASIFICACIONES A UN ARCHIVO .TXT"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00022"
                _DescripcionPermiso = "CLASIFICACR MASIVAMENTE LOS PRODUCTOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00023"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE MODELOS ST."
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00024"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE CATEGORIAS ST."
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00025"
                _DescripcionPermiso = "MANTENCION DE TABLA DE TIPO DE VEHICULOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00026"
                _DescripcionPermiso = "MANTENCION DE TABLA MARCAS DE VEHICULOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00027"
                _DescripcionPermiso = "MANTENCION DE TABLA MODELOS DE MARCAS DE VEHICULOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString

            Case "Tbl00030"
                _DescripcionPermiso = "EDITAR TABLA DE CLASIFICACIONES BAKAPP"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString

            Case "Tbl00035"
                _DescripcionPermiso = "AGREGAR O QUITAR PRODUCTOS A LAS CLASIFICACIONES MASIVAMENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00036"
                _DescripcionPermiso = "MANTENCIÓN DE FERIADOS ANUALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00037"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE ACCESORIOS ST."
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00038"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE ESTADO DE ENTREGA ST."
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00039"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA CHECK-IN ST."
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00040"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA DE MAQUINAS ST."
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00041"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA SUPER FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00042"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00043"
                _DescripcionPermiso = "MANTENCIÓN DE TABLA SUB-FAMILIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString

            Case "Tbl00044"
                _DescripcionPermiso = "MANTENCION DE RETIRADORES DE MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00045"
                _DescripcionPermiso = "GRABAR/EDITAR RETIRADOR DE MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00046"
                _DescripcionPermiso = "ELIMINAR RETIRADORES DE MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString

            Case "Tbl00047"
                _DescripcionPermiso = "CREAR-EDITAR PAISES, CIUDADES Y COMUNAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString
            Case "Tbl00048"
                _DescripcionPermiso = "ELIMINAR PAISES, CIUDADES Y COMUNAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.TABLAS_SISTEMA, 6)
                _NombreFamiliaPermiso = _Fml.TABLAS_SISTEMA.ToString

        End Select

#End Region

#Region "WMS UBICACIONES"

        Select Case _CodPermiso

            Case "Ubic0001"
                _DescripcionPermiso = "INGRESAR AL MODULO DE UBICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0002"
                _DescripcionPermiso = "VER UBICACIONES POR PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0003"
                _DescripcionPermiso = "MANTENCIÓN DE UBICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0004"
                _DescripcionPermiso = "ASOCIAR UBICACIÓN AL PRODUCTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0005"
                _DescripcionPermiso = "CAMBIAR UBICACIÓN POR DEFECTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0006"
                _DescripcionPermiso = "QUITAR PRODUCTO DE LA UBICACIÓN"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0007"
                _DescripcionPermiso = "CREAR SECTOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0008"
                _DescripcionPermiso = "IMPRIMIR MASIVAMENTE LOS SECTORES DE LA BODEGA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0009"
                _DescripcionPermiso = "VER UBICACIONES DEL SECTOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0010"
                _DescripcionPermiso = "EDITAR DESCRIPCIÓN DEL SECTOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0011"
                _DescripcionPermiso = "ELIMINAR SECTOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0012"
                _DescripcionPermiso = "IMPRIMIR SECTOR SELECCIONADO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0013"
                _DescripcionPermiso = "GRABAR UBICACIONES DEL SECTOR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0014"
                _DescripcionPermiso = "VER PRODUCTOS DE LA UBICACIÓN"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0015"
                _DescripcionPermiso = "ELIMINAR UBICACIÓN"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0016"
                _DescripcionPermiso = "EDITAR CÓDIGO DE UBICACIÓN"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0017"
                _DescripcionPermiso = "CREAR SECTOR COMO UBICACIÓN"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0018"
                _DescripcionPermiso = "PODER EDITAR EL SECTOR Y SUS UBICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0019"
                _DescripcionPermiso = "CAMBIAR NOMBRE DE MAPA DE UBICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString
            Case "Ubic0020"
                _DescripcionPermiso = "ELIMINAR MAPA DE UBICACIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.UBICACIONES, 6)
                _NombreFamiliaPermiso = _Fml.UBICACIONES.ToString

        End Select

#End Region

#Region "USUARIOS"

        Select Case _CodPermiso

            Case "User0001"
                _DescripcionPermiso = "INGRESAR A MANTENCION DE FUNCIONARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.USUARIOS, 6)
                _NombreFamiliaPermiso = _Fml.USUARIOS.ToString
            Case "User0002"
                _DescripcionPermiso = "CREAR NUEVO FUNCIONARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.USUARIOS, 6)
                _NombreFamiliaPermiso = _Fml.USUARIOS.ToString
            Case "User0003"
                _DescripcionPermiso = "EDITAR FUNCIONARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.USUARIOS, 6)
                _NombreFamiliaPermiso = _Fml.USUARIOS.ToString
            Case "User0004"
                _DescripcionPermiso = "ELIMINAR FUNCIONARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.USUARIOS, 6)
                _NombreFamiliaPermiso = _Fml.USUARIOS.ToString

        End Select

#End Region

#Region "PRODUCCION"

        Select Case _CodPermiso

            Case "Pdc00001"
                _DescripcionPermiso = "INGRESAR AL SISTEMA DE MESONES PRODUCCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00002"
                _DescripcionPermiso = "MANTENCION DE MESONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00003"
                _DescripcionPermiso = "CERRAR REGISTRO DE FABRICACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00004"
                _DescripcionPermiso = "ASIGNACION DE ORDENES DE TRABAJO A CADA MESON"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00005"
                _DescripcionPermiso = "VER FORMULARIO DE MESONES ON-LINE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00006"
                _DescripcionPermiso = "VER FORMULARIO DE MESON VS OPERARIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00007"
                _DescripcionPermiso = "INGRESAR DFA DIRECTAMENTE DESDE EL MESON"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00008"
                _DescripcionPermiso = "CAMBIAR HORA DE INICIO DE INGRESO A FABRICACION EN MAQUINA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00009"
                _DescripcionPermiso = "CAMBIAR FECHA DE INGRESO DE FABRICACION EN TARJA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00010"
                _DescripcionPermiso = "ELIMINAR ORDEN DE FABRICACION DE MEZCLA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
            Case "Pdc00011"
                _DescripcionPermiso = "CAMBIAR NOMENCLATURA/RECETA EN PRODUCTOS DE ORDEN DE FABRICACION DE MEZCLA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.PRODUCCION, 6)
                _NombreFamiliaPermiso = _Fml.PRODUCCION.ToString
        End Select

#End Region

#Region "RECLAMOS"

        Select Case _CodPermiso

            Case "Rcl00001"

                _DescripcionPermiso = "INGRESAR AL SISTEMA DE RECLAMOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00002"
                _DescripcionPermiso = "CREAR RECLAMO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00003"
                _DescripcionPermiso = "INGRESAR A RESOLUCION Y REVISION DE RECLAMO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00004"
                _DescripcionPermiso = "INGRESAR A VALIDACION DE RECLAMOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00005"
                _DescripcionPermiso = "EDITAR RESPUESTA AL CLIENTE EN VALIDACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00006"
                _DescripcionPermiso = "ENVIAR CORREO AL CLIENTE"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00007"
                _DescripcionPermiso = "GESTION RECEPCION DE MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00008"
                _DescripcionPermiso = "GESTION, REVISION DE DEVOLUCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00009"
                _DescripcionPermiso = "GESTION, DESTRUCCION MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00010"
                _DescripcionPermiso = "GESTION, REPROCESO DE MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00011"
                _DescripcionPermiso = "GESTION, ENVIO A BODEGA DE VENTAS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00012"
                _DescripcionPermiso = "GESTION, RECEPCION DE ACTA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00013"
                _DescripcionPermiso = "EDITAR RECEPCION DE MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00014"
                _DescripcionPermiso = "EDITAR REVISION DE DEVOLUCION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00015"
                _DescripcionPermiso = "CERRAR RECLAMO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00016"
                _DescripcionPermiso = "BUSCAR DOCUMENTO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00017"
                _DescripcionPermiso = "INGRESAR A LA CONFIGURACION DE RECLAMOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00018"
                _DescripcionPermiso = "INGRESAR A GESTION INTERNA DEL RECLAMO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00019"
                _DescripcionPermiso = "RECHAZAR LA REVISION DEL RECLAMO, ENVIAR A OTRA AREA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

            Case "Rcl00020"
                _DescripcionPermiso = "RECHAZAR LA VALIDACION DEL RECLAMO, REENVIAR A REVISION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.RECLAMOS, 6)
                _NombreFamiliaPermiso = _Fml.RECLAMOS.ToString

        End Select


#End Region

#Region "DESPACHOS"

        Select Case _CodPermiso

            Case "ODp00001"

                _DescripcionPermiso = "INGRESAR AL SISTEMA DE DESPACHOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00002"
                _DescripcionPermiso = "CREAR DESPACHO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00003"
                _DescripcionPermiso = "VER MAESTRO DE DESPACHOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00004"
                _DescripcionPermiso = "GESTIONAR DESPACHOS, CONFIRMACION"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00005"
                _DescripcionPermiso = "GESTIONAR DESPACHOS, PREPARACION (Armar bultos)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00006"
                _DescripcionPermiso = "GESTIONAR DESPACHOS, DESPACHAR (Bulto armado)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00007"
                _DescripcionPermiso = "GESTIONAR DESPACHOS, DESPACHADO (Espera cierre)"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00008"
                _DescripcionPermiso = "GESTIONAR DESPACHOS, CERRAR DESPACHO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00009"
                _DescripcionPermiso = "ANULAR DESPACHO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00010"
                _DescripcionPermiso = "PODER GENERAR DOCUMENTO SIN DESPACHO OBLIGATORIO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00011"
                _DescripcionPermiso = "PODER EDITAR ORDEN DE DESPACHO DE OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00012"
                _DescripcionPermiso = "PODER REIMPRIMIR UN LETRERO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00013"
                _DescripcionPermiso = "CREAR ORDEN DE DESPACHO SIN TRANSPORTE POR PAGAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00014"
                _DescripcionPermiso = "ENTREGAR O DESPACHAR LOS PRODUCTOS DE UNA FORMA DISTINTA A LO IMPUESTO EN LA ORDEN DE DESPACHO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00015"
                _DescripcionPermiso = "CERRAR ORDENES DE DESPACHO DE OTRAS SUCURSALES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00016"
                _DescripcionPermiso = "PODER DESMARCAR TRANSPORTE POR PAGAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00017"
                _DescripcionPermiso = "PODER GRABAR DESPACHO CON PESO O VALOR BAJO EL MINIMO PARA DESPACHO"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00018"
                _DescripcionPermiso = "PODER MODIFICAR HORARIO DE DESPACHOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

            Case "ODp00019"
                _DescripcionPermiso = "PODER MARCAR ENTREGA PALETIZADA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.DESPACHOS, 6)
                _NombreFamiliaPermiso = _Fml.DESPACHOS.ToString

        End Select


#End Region

#Region "ADMINISTRADOR"

        Select Case _CodPermiso

            Case "Admin001"

                _DescripcionPermiso = "SUPERVISOR DEL SISTEMA, PUEDO OTORGAR PERMISOS A OTROS USUARIOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.ADMINISTRADOR, 6)
                _NombreFamiliaPermiso = _Fml.ADMINISTRADOR.ToString

        End Select

#End Region

#Region "COMISIONES"

        Select Case _CodPermiso

            Case "Com00001"

                _DescripcionPermiso = "INGRESAR AL SISTEMA DE COMISIONES"
                _CodFamilia = Fx_Rellena_ceros(_Fml.COMISIONES, 6)
                _NombreFamiliaPermiso = _Fml.COMISIONES.ToString

        End Select

#End Region

#Region "STEM SISTEMA DE TICKET DE ENTREGA DE MERCADERIA"

        Select Case _CodPermiso

            Case "Stem0001"

                _DescripcionPermiso = "INGRESAR AL SISTEMA DE TICKET DE ENTREGA DE MERCADERIA"
                _CodFamilia = Fx_Rellena_ceros(_Fml.STEM, 6)
                _NombreFamiliaPermiso = _Fml.STEM.ToString

            Case "Stem0002"

                _DescripcionPermiso = "AGREGAR ENTREGA DE FORMA MANUAL"
                _CodFamilia = Fx_Rellena_ceros(_Fml.STEM, 6)
                _NombreFamiliaPermiso = _Fml.STEM.ToString

            Case "Stem0003"

                _DescripcionPermiso = "DAR DOCUMENTOS DE ALTA, MARCAR COMO ENTREGADOS"
                _CodFamilia = Fx_Rellena_ceros(_Fml.STEM, 6)
                _NombreFamiliaPermiso = _Fml.STEM.ToString

            Case "Stem0004"

                _DescripcionPermiso = "MARCAR DOCUMENTO FACTURAR AL COMPLETAR"
                _CodFamilia = Fx_Rellena_ceros(_Fml.STEM, 6)
                _NombreFamiliaPermiso = _Fml.STEM.ToString

        End Select

#End Region

#End Region

        If Not String.IsNullOrEmpty(_DescripcionPermiso) Then

            Consulta_sql = "Select CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso,Descuento,Max_Compra
                        From " & _Global_BaseBk & "ZW_Permisos Where 1<0"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim NewFila As DataRow
            NewFila = _Tbl.NewRow
            With NewFila

                .Item("CodPermiso") = _CodPermiso
                .Item("DescripcionPermiso") = _DescripcionPermiso
                .Item("CodFamilia") = _CodFamilia
                .Item("NombreFamiliaPermiso") = _NombreFamiliaPermiso
                .Item("Descuento") = _Descuento
                .Item("Max_Compra") = _Max_Compra

                _Tbl.Rows.Add(NewFila)

            End With

            Fx_Row_Traer_Permiso_Sistema = NewFila

        Else

            If _CodPermiso.Contains("Lc-") Or
               _CodPermiso.Contains("Lp-") Or
               _CodPermiso.Contains("Bo") Or
               _CodPermiso.Contains("RclRes") Or
               _CodPermiso.Contains("RclVal") Or
                _CodPermiso.Contains("Ps_") Or
                _CodPermiso.Contains("BNVI") Then

                Consulta_sql = "Select CodPermiso, DescripcionPermiso, CodFamilia, NombreFamiliaPermiso,Descuento,Max_Compra
                                From " & _Global_BaseBk & "ZW_Permisos Where CodPermiso = '" & _CodPermiso & "'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row) Then
                    Return _Row
                End If

            Else

                Return Nothing

            End If

        End If

    End Function

End Class
