'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Sistema_CodBarras

    Dim _TieneConfiguracion As Boolean

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub Sistema_CodBarras_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")
        _TieneConfiguracion = Fm.TieneConfiguracion
        Fm.Dispose()

        AddHandler BtnConfiguracion.Click, AddressOf Sb_Configuracion_Local
        AddHandler BtnImpBarras_Producto.Click, AddressOf Sb_ImpBarras_Producto
        AddHandler BtnImpBarras_Documento.Click, AddressOf Sb_ImpBarras_Documento
        AddHandler BtnCrearCodigosBarra.Click, AddressOf Sb_Crear_codigos_de_Barra

    End Sub


#Region "PROCEDIMIENTOS"

#Region "BARRAS POR PRODUCTO"


    Sub Sb_ImpBarras_Producto()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "7Brr0003") Then

            If Fx_TieneConfiguracion() Then

                Dim Fm As New Frm_ImpBarras_PorProducto
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

        End If

    End Sub


#End Region

#Region "BARRAS POR DOCUMENTO"

    Sub Sb_ImpBarras_Documento()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "7Brr0004") Then
            Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "OCC")
            _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
            _Fm.Rdb_Tipo_Documento_Algunos.Enabled = False
            '_Fm.PRO_Imprimir_Codigos_Barra = True

            _Fm.Rdb_Fecha_Emision_Cualquiera.Checked = False
            _Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True

            _Fm.Rdb_Tipo_Documento_Algunos.Checked = False
            _Fm.Rdb_Tipo_Documento_Uno.Checked = True

            _Fm.ShowDialog(Me)
            Dim _RowDocumento As DataRow = _Fm.Pro_Row_Documento_Seleccionado
            _Fm.Dispose()

            If Not (_RowDocumento Is Nothing) Then
                Dim _Idmaeedo As Integer = _RowDocumento.Item("IDMAEEDO")
                Dim Fm As New Frm_ImpBarras_PorDocumento(_Idmaeedo)
                Fm.ShowDialog(Me)
                Fm.Dispose()
            End If


        End If

    End Sub

#End Region

#Region "IMPRIMIR BARRAS DE UBICACIONES"

    Sub Sb_ImpBarras_Ubicaciones(_BuscarUbicGrilla As Boolean, _Codigo_Sector As String)

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "7Brr0005") Then

            Dim _RowSector As DataRow

            Dim Fm As New Frm_Ubicaciones_Buscar
            Fm.BuscarUbicGrilla = _BuscarUbicGrilla
            Fm.Codigo_Sector = _Codigo_Sector
            Fm.ShowDialog(Me)
            _RowSector = Fm.Pro_RowSector
            Fm.Dispose()

            If Not (_RowSector Is Nothing) Then

                Dim Fm_B As New Frm_ImpBarras_Ubicaciones(_RowSector)
                Fm_B.ShowDialog(Me)
                Fm_B.Dispose()

                Sb_ImpBarras_Ubicaciones(True, _RowSector.Item("Codigo_Sector"))

            End If

        End If

        '        Public Property BuscarUbicGrilla As Boolean
        'Public Property Codigo_Sector As String

    End Sub

#End Region

#Region "FUNCION TIENE CONFIGURACION"
    Private Function Fx_TieneConfiguracion() As Boolean

        If _TieneConfiguracion Then
            Return True
        Else
            MessageBoxEx.Show(Me, "  Faltan datos de con figuración de estación de trabajo",
                              "Falta configuración", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function
#End Region

#Region "CONFIGURACION"

    Sub Sb_Configuracion_Local()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "7Brr0006") Then
            Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")
            Fm.ShowDialog(Me)
            _TieneConfiguracion = Fm.Grabar
            Fm.Dispose()
        End If

    End Sub

#End Region

#Region "CREAR CODIGOS DE BARRA"

    Sub Sb_Crear_codigos_de_Barra()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "7Brr0002") Then

            Dim Fm As New Frm_ImpBarras_ListaEtiquetas
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

#End Region

#End Region

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnImpBarras_Ubicaciones_Click(sender As Object, e As EventArgs) Handles BtnImpBarras_Ubicaciones.Click
        Sb_ImpBarras_Ubicaciones(False, "")
    End Sub
End Class
