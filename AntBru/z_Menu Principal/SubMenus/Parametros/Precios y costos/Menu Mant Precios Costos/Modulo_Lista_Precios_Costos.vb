'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_Lista_Precios_Costos

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
    Private Sub Modulo_Lista_Precios_Costos_Load(sender As Object, e As EventArgs) Handles Me.Load

        MetroTileItem1.Visible = (RutEmpresa = "77458040-9" Or RutEmpresa = "07251245-6" Or RutEmpresa = "77634877-5" Or RutEmpresa = "77634879-1")
        MetroTileItem2.Visible = (RutEmpresa = "77458040-9" Or RutEmpresa = "07251245-6" Or RutEmpresa = "77634877-5" Or RutEmpresa = "77634879-1")

    End Sub

    Private Sub BtnConfListas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfListas.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0009") Then
            Dim Fm As New Frm_MantListas
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Listas_de_precios_Click(sender As Object, e As EventArgs) Handles Btn_Listas_de_precios.Click
        Sb_Listas_Random(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Precio)
    End Sub

    Private Sub Btn_Listas_de_costos_Click(sender As Object, e As EventArgs) Handles Btn_Listas_de_costos.Click
        Sb_Listas_Random(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Costo)
    End Sub

    Sub Sb_Listas_Random(_Lista As Frm_SeleccionarListaPrecios.Enum_Tipo_Lista)

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0012") Then

            Dim _Tbl_Lista_Seleccionada As DataTable

            Dim Fm As New Frm_SeleccionarListaPrecios(_Lista, True, False)
            Fm.ShowDialog(Me)
            _Tbl_Lista_Seleccionada = Fm.Pro_Tbl_Listas_Seleccionadas
            Fm.Dispose()

            If Not (_Tbl_Lista_Seleccionada Is Nothing) Then

                Dim Fm_P As New Frm_MantLista_Precios_Random(_Tbl_Lista_Seleccionada, Nothing, False)
                Fm_P.ShowDialog(Me)
                Fm_P.Dispose()

            End If

        End If

    End Sub

    Private Sub Btn_Listas_Proveedores_Click(sender As Object, e As EventArgs) Handles Btn_Listas_Proveedores.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0013") Then

            Dim _Tbl_Lista_Seleccionada As DataTable
            Dim _CodLista As String = _Global_Row_Configuracion_General.Item("Lista_Precios_Proveedores").ToString.Trim

            If String.IsNullOrEmpty(_CodLista) Then

                MessageBoxEx.Show(Me, "No existe una lista de costos por defecto en la modalidad general" & vbCrLf &
                                  "Deberá escoger en que lista se grabaran los precios del proveedor en Random",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fm As New Frm_SeleccionarListaPrecios(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Costo, False, False)
                Fm.ShowDialog(Me)
                _Tbl_Lista_Seleccionada = Fm.Pro_Tbl_Listas_Seleccionadas
                Fm.Dispose()

                If Not (_Tbl_Lista_Seleccionada Is Nothing) Then
                    _CodLista = _Tbl_Lista_Seleccionada.Rows(0).Item("Lista")
                End If

            End If

            If String.IsNullOrEmpty(_CodLista.Trim) Then
                Return
            End If

            Dim _RowProveedor As DataRow

            Dim Fm_E As New Frm_BuscarEntidad_Mt(False)
            Fm_E.ShowInTaskbar = False
            Fm_E.Text = "Busqueda de proveedores para lista de costos"
            Fm_E.ShowDialog(Me)
            If Fm_E.Pro_Entidad_Seleccionada Then
                _RowProveedor = Fm_E.Pro_RowEntidad
            End If
            Fm_E.Dispose()

            If Not (_RowProveedor Is Nothing) Then

                Dim _BuscarOtroProveedor As Boolean

                Dim Fm_P As New Frm_MantCostosPrecios_LV(_RowProveedor, _CodLista)
                Fm_P.Btn_CambiarProveedor.Visible = True
                Fm_P.ShowDialog(Me)
                _BuscarOtroProveedor = Fm_P.BuscarOtroProveedor
                Fm_P.Dispose()

                If _BuscarOtroProveedor Then
                    Call Btn_Listas_Proveedores_Click(sender, e)
                End If

            Else
                MessageBoxEx.Show(Me, "No se seleccionó ningún proveedor",
                                 "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub MetroTileItem1_Click(sender As Object, e As EventArgs) Handles MetroTileItem1.Click

        Dim Fm As New Frm_PreciosLC_Mt01
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub MetroTileItem2_Click(sender As Object, e As EventArgs) Handles MetroTileItem2.Click

        Dim Fm As New Frm_PreciosLC_InfUltCompras_Mt
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


End Class
