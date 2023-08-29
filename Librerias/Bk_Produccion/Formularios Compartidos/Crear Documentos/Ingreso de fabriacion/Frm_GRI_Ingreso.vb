Imports BkSpecialPrograms

Public Class Frm_GRI_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_GRI_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Ingresar_GRI_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_GRI.Click

        Dim Fm As New Frm_GRI_FabXProducto
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_ImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirEtiquetas.Click

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "GRI")
        _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
        _Fm.Rdb_Tipo_Documento_Algunos.Enabled = False

        _Fm.Rdb_Fecha_Emision_Cualquiera.Checked = False
        _Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True

        _Fm.Rdb_Tipo_Documento_Algunos.Checked = False
        _Fm.Rdb_Tipo_Documento_Uno.Checked = True

        _Fm.ShowDialog(Me)
        Dim _RowDocumento As DataRow = _Fm.Pro_Row_Documento_Seleccionado
        _Fm.Dispose()

        If Not (_RowDocumento Is Nothing) Then

            Dim _Cerrar As Boolean

            Dim _Idmaeedo As Integer = _RowDocumento.Item("IDMAEEDO")
            Dim Fm As New Frm_ImpBarras_PorDocumento(_Idmaeedo)
            Fm.CantidadCero = True
            Fm.ShowDialog(Me)
            _Cerrar = Fm.CerrarPorConfigurar
            Fm.Dispose()

            If _Cerrar Then
                Me.Close()
            End If

        End If

    End Sub

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
End Class
