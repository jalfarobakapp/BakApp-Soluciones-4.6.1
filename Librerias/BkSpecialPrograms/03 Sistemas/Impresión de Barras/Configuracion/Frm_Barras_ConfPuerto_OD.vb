Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Barras_ConfPuerto_OD

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Barras\Configuracion_local_Orden_Despacho.xml"
    Dim _Ds_ConfBarras As DataSet = New Ds_Barras
    Dim _TieneConfiguracion As Boolean
    Dim _Grabar As Boolean

    Public Property Ds_ConfBarras As DataSet
        Get
            Return _Ds_ConfBarras
        End Get
        Set(value As DataSet)
            _Ds_ConfBarras = value
        End Set
    End Property

    Public Property TieneConfiguracion As Boolean
        Get
            Return _TieneConfiguracion
        End Get
        Set(value As Boolean)
            _TieneConfiguracion = value
        End Set
    End Property

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Barras") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\Barras")
        End If

        _Ds_ConfBarras.Clear()
        Dim exists = System.IO.File.Exists(_Path)

        If Not exists Then

            Dim NewFila As DataRow
            NewFila = _Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").NewRow

            With NewFila
                .Item("Puerto") = String.Empty
                .Item("Etiqueta") = String.Empty
                .Item("Imp_Barras") = False
                .Item("Imp_Laser") = True
                .Item("Imp_Termica") = False
                .Item("Imp_Termica") = False
                .Item("Impresora") = String.Empty
                .Item("Imprimir_Automaticamente") = False
            End With

            Rdb_Imp_Laser.Checked = True
            Grupo_Barras.Enabled = False

            _Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows.Add(NewFila)

            _Ds_ConfBarras.WriteXml(_Path)

        Else
            _TieneConfiguracion = True
            _Ds_ConfBarras.ReadXml(_Path)
        End If

        Dim _Arr_Puertos(,) As String = {{"", ""},
                                     {"LPT1", "Puerto LPT1"},
                                     {"LPT2", "Puerto LPT2"},
                                     {"LPT3", "Puerto LPT3"},
                                     {"LPT4", "Puerto LPT4"}}
        Sb_Llenar_Combos(_Arr_Puertos, Cmb_Puerto)
        Cmb_Puerto.SelectedValue = ""

        Consulta_sql = "select NombreEtiqueta As Padre,NombreEtiqueta As Hijo from " & _Global_BaseBk & "Zw_Tbl_DisenoBarras"
        Dim _TblEtiquetas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmb_Etiqueta)
        Cmb_Etiqueta.DataSource = Nothing
        Cmb_Etiqueta.DataSource = _TblEtiquetas

    End Sub

    Private Sub Frm_Barras_ConfPuerto_OD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Puerto = _Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Puerto")
        Dim _Etiqueta = _Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Etiqueta")

        Dim _Imp_Barras As Boolean = _Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Barras")
        Dim _Imp_Laser As Boolean = _Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Laser")
        Dim _Imp_Termica As Boolean = _Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Termica")

        Dim _Impresora As String = NuloPorNro(_Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Impresora"), "")
        Dim _Imprimir_Automaticamente As Boolean = NuloPorNro(_Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imprimir_Automaticamente"), False)

        Cmb_Puerto.SelectedValue = _Puerto
        Cmb_Etiqueta.SelectedValue = _Etiqueta

        Rdb_Imp_Barras.Checked = _Imp_Barras
        Rdb_Imp_Laser.Checked = _Imp_Laser
        Rdb_Imp_Termica.Checked = _Imp_Termica

        Lbl_Impresora_Predeterminada.Text = _Impresora
        Chk_Imprimir_Automaticamente.Checked = _Imprimir_Automaticamente

        AddHandler Rdb_Imp_Barras.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Imp_Laser.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Imp_Termica.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged

        Grupo_Barras.Enabled = Rdb_Imp_Barras.Checked

    End Sub

    Private Sub Sb_Rdb_CheckedChanged(sender As Object, e As EventArgs)

        Grupo_Barras.Enabled = Rdb_Imp_Barras.Checked

    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        If Chk_Imprimir_Automaticamente.Checked Then

            If Rdb_Imp_Laser.Checked Or Rdb_Imp_Termica.Checked Then
                If String.IsNullOrEmpty(Lbl_Impresora_Predeterminada.Text.Trim) Then
                    MessageBoxEx.Show(Me, "Falta impresora", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

        End If

        If Rdb_Imp_Barras.Checked Then
            If String.IsNullOrEmpty(Cmb_Puerto.SelectedValue) Or String.IsNullOrEmpty(Cmb_Puerto.SelectedValue) Then
                MessageBoxEx.Show(Me, "Falta configuración de salidad de impresora de barras (Puerto/Etiqueta)", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        _Ds_ConfBarras.Clear()
        With _Ds_ConfBarras

            Dim NewFila As DataRow
            NewFila = .Tables("Tbl_Conf_Orden_Despacho").NewRow

            With NewFila
                .Item("Puerto") = Cmb_Puerto.SelectedValue
                .Item("Etiqueta") = Cmb_Etiqueta.Text
                .Item("Imp_Barras") = Rdb_Imp_Barras.Checked
                .Item("Imp_Laser") = Rdb_Imp_Laser.Checked
                .Item("Imp_Termica") = Rdb_Imp_Termica.Checked
                .Item("Impresora") = Lbl_Impresora_Predeterminada.Text
                .Item("Imprimir_Automaticamente") = Chk_Imprimir_Automaticamente.Checked
            End With

            .Tables("Tbl_Conf_Orden_Despacho").Rows.Add(NewFila)

            .WriteXml(_Path)

            _Grabar = True

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End With

        Me.Close()

    End Sub

    Private Sub Btn_Cambiar_Impresora_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Impresora.Click

        Dim Fm As New Frm_Seleccionar_Impresoras(Lbl_Impresora_Predeterminada.Text)
        Fm.ShowDialog(Me)
        If Fm.Pro_Aceptar Then
            Lbl_Impresora_Predeterminada.Text = Fm.Pro_Impresora_Seleccionada.ToString.Trim
        End If
        Fm.Dispose()

    End Sub
End Class
