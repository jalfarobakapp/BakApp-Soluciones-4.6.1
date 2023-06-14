Public Class Frm_Dem_Imprimir

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Imprimir_Documentos As New Cl_Dem_Imprimir

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Dem_Imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Me.Text = "Demonio para acciones automatizadas, V: [" & _Version_BkSpecialPrograms & "]"
        Lbl_Nombre_Equipo.Text = "Nombre equipo: " & _NombreEquipo
        Lbl_Modalidad.Text = "Modalidad: " & Modalidad & ", Sucursal: " & ModSucursal & ", Bodega: " & ModBodega

        _Cl_Imprimir_Documentos.Txt_Log = Txt_Log
        _Cl_Imprimir_Documentos.NombreEquipo = _NombreEquipo

        CircularPgrs.IsRunning = True

        Timer_Clear.Interval = (60 * 1000) * 2 ' 2 Minutos

        Lbl_Estatus.Text = "Empresa: " & ModEmpresa & ", Modalidad: " & Modalidad & ", Usuario: " & FUNCIONARIO & ", Equipo: " & _NombreEquipo

        Sb_Color_Botones_Barra(Bar1)

        Sb_Parametros_Informe_Sql(False)

    End Sub

    Private Sub Timer_Segundos_Tick(sender As Object, e As EventArgs) Handles Timer_Segundos.Tick

        Timer_Segundos.Stop()
        Btn_Configurar.Enabled = False

        _Cl_Imprimir_Documentos.Fecha_Revision = DtpFecharevision.Value

        If Chk_ImprimirDocumentos.Checked Then
            _Cl_Imprimir_Documentos.Sb_Procedimiento_Cola_Impresion()
        End If

        If Chk_ImprimirPicking.Checked Then
            _Cl_Imprimir_Documentos.Sb_Procedimiento_Picking()
        End If

        Btn_Configurar.Enabled = True
        Timer_Segundos.Start()
        Me.Refresh()

    End Sub

    Private Sub Btn_Configurar_Click(sender As Object, e As EventArgs) Handles Btn_Configurar.Click

        Timer_Segundos.Stop()
        Timer_Clear.Stop()

        Dim Fm As New Frm_Dem_Imprimir_Conf
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Parametros_Informe_Sql(False)

    End Sub

    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Timer_Segundos.Stop()
        Timer_Clear.Stop()

        _Sql.Sb_Parametro_Informe_Sql(Chk_ImprimirDocumentos, "Demonio_Impresion",
                                      Chk_ImprimirDocumentos.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ImprimirDocumentos.Checked, _Actualizar, "Demonio")

        _Sql.Sb_Parametro_Informe_Sql(Chk_ImprimirPicking, "Demonio_Impresion",
                                      Chk_ImprimirPicking.Name, Class_SQLite.Enum_Type._Boolean,
                                      Chk_ImprimirPicking.Checked, _Actualizar, "Demonio")

        _Sql.Sb_Parametro_Informe_Sql(Input_SegundosImpresion, "Demonio_Impresion",
                                      Input_SegundosImpresion.Name, Class_SQLite.Enum_Type._Double,
                                      Input_SegundosImpresion.Value, _Actualizar, "Demonio")

        DtpFecharevision.Enabled = False

        Timer_Segundos.Interval = Input_SegundosImpresion.Value * 1000

        Timer_Segundos.Start()
        Timer_Clear.Start()

    End Sub

    Private Sub Timer_Clear_Tick(sender As Object, e As EventArgs) Handles Timer_Clear.Tick
        Txt_Log.Text = String.Empty
    End Sub

    Private Sub Frm_Dem_Imprimir_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Chk_ImprimirDocumentos.Checked Or Chk_ImprimirPicking.Checked Then

            Dim _Validar As Boolean

            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
            Fm.Pro_Cerrar_Automaticamente = True
            Fm.ShowDialog(Me)
            _Validar = Fm.Pro_Permiso_Aceptado
            Fm.Dispose()

            If Not _Validar Then
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub BtnCambFecha_Click(sender As Object, e As EventArgs) Handles BtnCambFecha.Click
        If Fx_Tiene_Permiso(Me, "Pick0007") Then
            DtpFecharevision.Enabled = True
        End If
    End Sub

    Sub Sb_Actualizar_Fecha()

        Dim _Fecha_Computador As Date = FormatDateTime(Now.Date, DateFormat.ShortDate)
        Dim _Fecha_Dtp As Date = FormatDateTime(DtpFecharevision.Value, DateFormat.ShortDate)

        If _Fecha_Computador <> _Fecha_Dtp Then
            DtpFecharevision.Value = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)
        End If

        DtpFecharevision.Enabled = False

    End Sub

    Private Sub Timer_Minimizar_Tick(sender As Object, e As EventArgs) Handles Timer_Minimizar.Tick

        If Timer_Minimizar.Interval = 1000 Then
            Timer_Minimizar.Interval = (60 * 1000) * 6
        End If

        Sb_Actualizar_Fecha()
        Me.WindowState = FormWindowState.Minimized

    End Sub

End Class
