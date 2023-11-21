Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_Tarja

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Puerto, _Etiqueta As String
    Dim _Row_Tarja As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_ImpBarras_Tarja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        Dim _Arr_Filtro(,) As String

        _Arr_Filtro = {{"LPT1", "Puerto LPT1"},
                       {"LPT2", "Puerto LPT2"},
                       {"LPT3", "Puerto LPT3"},
                       {"LPT4", "Puerto LPT4"}}
        Sb_Llenar_Combos(_Arr_Filtro, CmbPuerto)
        CmbPuerto.SelectedValue = "LPT1"

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT NombreEtiqueta AS Padre,NombreEtiqueta+', Cantidad de etiquetas por fila '+RTRIM(LTRIM(STR(CantPorLinea))) AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Tbl_DisenoBarras order by NombreEtiqueta"
        Cmbetiquetas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmbetiquetas.SelectedValue = _Etiqueta

        AddHandler Cmbetiquetas.SelectedIndexChanged, AddressOf Sb_Cmbetiquetas_SelectedIndexChanged

        Call Sb_Cmbetiquetas_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Private Sub Txt_Nro_CPT_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Nro_CPT.ButtonCustomClick

        Dim _Nro_CPT As String = Txt_Nro_CPT.Text

        _Nro_CPT = "0000000003"

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja Where Nro_CPT = '" & _Nro_CPT & "'"
        _Row_Tarja = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_NroLote.Text = _Row_Tarja.Item("Lote")

    End Sub

    Private Sub BtnImprimirEtiqueta_Click(sender As Object, e As EventArgs) Handles BtnImprimirEtiqueta.Click
        Sb_Imprimir_Etiquetas()
    End Sub

    Private Sub Sb_Cmbetiquetas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Semilla As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "Semilla",
                                                    "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'", True)
        Dim _Puerto As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras_SalPtoxEstacion", "Puerto",
                                                  "Semilla_Padre = " & _Semilla & " And NombreEquipo = '" & _NombreEquipo & "'")

        If Not String.IsNullOrEmpty(_Puerto) Then
            CmbPuerto.SelectedValue = _Puerto
        End If

    End Sub

    Sub Sb_Imprimir_Etiquetas()

        Try

            _Puerto = CmbPuerto.SelectedValue
            Dim _CantPorLinea As Integer

            If IsNothing(Cmbetiquetas.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            If String.IsNullOrEmpty(Cmbetiquetas.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            _CantPorLinea = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "CantPorLinea",
                                      "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'")

            If _CantPorLinea = 0 Then _CantPorLinea = 1

            Dim CanXlinea As Double = _CantPorLinea
            Dim Veces As Double = 1 '_Fila("Cantidad").ToString()

            If CBool(Veces) Then

                If CanXlinea = Veces Or CanXlinea > Veces Then
                    Veces = 1
                Else
                    Dim _ModVeces = Veces Mod 2
                    Dim _ModCanXlinea = CanXlinea Mod 2

                    If CanXlinea <> 1 Then

                        If CBool(_ModVeces) Or CBool(_ModCanXlinea) Then

                            Veces = Math.Round((Veces / CanXlinea), 5)
                            Dim _Des = Split(Veces, ",")

                            If _Des.Length = 2 Then
                                Veces = _Des(0) + 1
                            End If

                        Else
                            Veces = Math.Round((Veces / CanXlinea), 0)
                        End If
                    End If
                End If

                If Veces < 1 Then Veces = 1

                'Dim _Codigo = _Fila.Item("Codigo")
                'Dim _CodAlternativo = _Fila.Item("CodAlternativo")
                'Dim _Lista = CmbLista.SelectedValue

                'Dim _Empresa, _Sucursal, _Bodega As String
                'Dim _ESB() = Split(CmbBodega.SelectedValue, ";")

                '_Empresa = _ESB(0)
                '_Sucursal = _ESB(1)
                '_Bodega = _ESB(2)

                For w = 1 To Veces

                    Dim _Imp As New Class_Imprimir_Barras

                    _Imp.Sb_Imprimir_Tarja(Cmbetiquetas.SelectedValue, _Puerto, ModEmpresa, _Row_Tarja.Item("Id"))

                    If Not String.IsNullOrEmpty(_Imp.Error) Then
                        If MessageBoxEx.Show(Me, _Imp.Error, "Problema al imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) <> DialogResult.OK Then
                            Return
                        End If
                    End If

                Next

            End If


        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

        End Try

    End Sub

End Class
