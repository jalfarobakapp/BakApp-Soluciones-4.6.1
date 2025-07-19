Imports System.IO
Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Modulo_Ventas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

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

        If Global_Thema = Enum_Themas.Oscuro Then
            Sb_Color_Botones_Barra(Bar2)
        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnPostVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPostVenta.Click

        'If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Bkp00027",,, False,,,, False, False) Then

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Bkp00027") Then

            Dim _RowFormato_BLV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Mod_Empresa, Mod_Modalidad, "BLV", True)
            Dim _RowFormato_FCV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Mod_Empresa, Mod_Modalidad, "FCV", True)
            Dim _RowFormato_COV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Mod_Empresa, Mod_Modalidad, "COV", True)
            'Dim _RowFormato_NVV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Modalidad, "NVV", True)

            If (_RowFormato_BLV Is Nothing) Or
               (_RowFormato_BLV Is Nothing) Or
               (_RowFormato_COV Is Nothing) Then
                'Or _
                '(_RowFormato_NVV Is Nothing) Then

                MessageBoxEx.Show(_Fm_Menu_Padre, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Exit Sub

            End If

            Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

            If Not _Msj_Tsc.EsCorrecto Then
                Return
            End If

            Dim _Koen_Xdefecto = _Global_Row_Configuracion_Estacion.Item("Vnta_EntidadXdefecto")
            Dim _Suen_Xdefecto = _Global_Row_Configuracion_Estacion.Item("Vnta_SucEntXdefecto")

            If String.IsNullOrEmpty(_Koen_Xdefecto.ToString.Trim) Then

                MessageBoxEx.Show(_Fm_Menu_Padre, "Falta la entidad por defecto en esta modalidad: " & Mod_Modalidad, "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            Dim Fm_Post As New Frm_Formulario_Documento("BLV", csGlobales.Enum_Tipo_Documento.Venta, True)
            If Not Fm_Post.Pro_No_puede_Acceder_Al_Documento Then
                Fm_Post.ShowDialog(Me)
            End If
            Fm_Post.Dispose()

        End If

    End Sub

    Private Sub Btn_ProductoSolicitadosBodega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ProductoSolicitadosBodega.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Bkp00031") Then

            Dim Fm As New Frm_Sol_Pro_Bodega_ListaPendientes
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Pago_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pago_Documentos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pcli0001") Then

            Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

            If Not _Msj_Tsc.EsCorrecto Then
                Return
            End If

            Dim _Directorio_GenDTE As String = _Global_Row_EstacionBk.Item("Directorio_GenDTE")
            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            If Fx_Datos_Directorio_GenDTE(_Directorio_GenDTE, _NombreEquipo) Then

                Dim _TblFormato_Mod As DataTable

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & vbCrLf &
                               "Where Modalidad = '" & Mod_Modalidad & "' And TipoDoc In ('BLV','FCV')"
                _TblFormato_Mod = _Sql.Fx_Get_DataTable(Consulta_sql)

                Dim _Msg = String.Empty

                For Each _Fila As DataRow In _TblFormato_Mod.Rows

                    Dim _TipoDoc = _Fila.Item("TipoDoc")
                    Dim _Guardar_PDF_Auto As Boolean = _Fila.Item("Guardar_PDF_Auto")

                    If _Guardar_PDF_Auto Then

                        Dim _Ruta_PDF = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Ruta_PDF",
                                      "NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Mod_Modalidad & "' And Tido = '" & _TipoDoc & "'")

                        If String.IsNullOrEmpty(_Ruta_PDF) Or Not Directory.Exists(_Ruta_PDF) Then
                            If Not String.IsNullOrEmpty(_Msg) Then _Msg += " y "
                            _Msg += _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _TipoDoc & "'").ToString.Trim
                        End If

                    End If


                Next

                If Not String.IsNullOrEmpty(_Msg) Then

                    MessageBoxEx.Show(Me, "Esta configurada la grabación de PDF automático para esta modalidad," & vbCrLf &
                          "sin embargo falta la configuración de la carpeta de salida para grabar estos PDF." & vbCrLf & vbCrLf &
                          "Para configurar esta operación debe hacer lo siguiente:" & vbCrLf & vbCrLf &
                          "-> Clic en OK o cerrar" & vbCrLf &
                          "-> En el formulario de pagos a documentos presionar el botón de configuración (computador con engranajes)" & vbCrLf &
                          "-> Directorio de salida para PDF automático" & vbCrLf &
                          "-> Configurar " & _Msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

                Dim _Aplica_Ley_20956 As Boolean = _Sql.Fx_Exite_Campo("MAEDPCE", "LEY20956")

                Dim Fm As New Frm_Pagos_Documentos
                Fm.Aplica_Ley_20956 = _Aplica_Ley_20956
                Fm.MinimizeBox = False
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

        End If

    End Sub

    Private Sub BtnBuscarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarDocumento.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Doc00015") Then
            Dim _Fm As New Frm_BusquedaDocumento_Filtro(True)
            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "")
            _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
            _Fm.ShowDialog(Me)
            _Fm.Dispose()
        End If

    End Sub

    Private Sub BtnCambiarDeUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarDeUsuario.Click

        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)

    End Sub

    Private Sub Btn_Conf_CashDro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Conf_CashDro.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Cdro0004") Then
            Return
        End If

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Estaciones_CashDro", "TJV_Emdp_Credito") And
           _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Estaciones_CashDro", "TJV_Emdp_Debito") Then

            Dim NewPanel As Modulo_CashDro = Nothing
            NewPanel = New Modulo_CashDro(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        Else

            MessageBoxEx.Show(Me, "Faltan campos en la tabla (Zw_Estaciones_CashDro)" & vbCrLf &
                              "Informe al administrador del sistema", "Validación Versión Bakapp", MessageBoxButtons.OK, MessageBoxIcon.Stop)


        End If

    End Sub

    Private Sub Btn_Documentos_Venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Documentos_Venta.Click

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim NewPanel As Modulo_Documentos_Venta = Nothing
        NewPanel = New Modulo_Documentos_Venta(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Pagos_Generales_Cliente_Click(sender As Object, e As EventArgs) Handles Btn_Pagos_Generales_Cliente.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ppro0011") Then

            Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

            If Not _Msj_Tsc.EsCorrecto Then
                Return
            End If

            Dim Fm As New Frm_Pagos_Generales(Frm_Pagos_Generales.Enum_Tipo_Pago.Clientes)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class
