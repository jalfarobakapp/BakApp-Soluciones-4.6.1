
Public Class Frm_PrecioLC_ImpFleje

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Sub LlenarDatos(ByVal Codigo As String,
                    ByVal Lista As String)

        TxtCodigo.Text = Codigo
        TxtDescripcion.Text = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & Codigo & "'")
        TxtRtu.Text = _Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & Codigo & "'")

    End Sub

    Private Sub CmbLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLista.SelectedIndexChanged
        LlenarPrecios(TxtCodigo.Text, CmbLista.SelectedValue)
    End Sub


    Sub LlenarPrecios(ByVal Codigo As String, ByVal Lista As String)
        TxtPrecioUd1.Text = _Sql.Fx_Trae_Dato("TABPRE", "PP01UD",
                                     "KOLT = '" & Lista & "' AND KOPR = '" & Codigo & "'")
        TxtPrecioUd2.Text = _Sql.Fx_Trae_Dato("TABPRE", "PP02UD",
                                      "KOLT = '" & Lista & "' AND KOPR = '" & Codigo & "'")
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        caract_combo(CmbLista)
        Consulta_sql = "SELECT KOLT AS Padre,KOLT+'-'+LTRIM(RTRIM(NOKOLT))+ CASE TILT WHEN 'C' THEN ' -  Costo' else ' - Precio' end  AS Hijo FROM TABPP WHERE KOLT IN (" & vbCrLf &
                       "SELECT SUBSTRING(KOOP, 4, 3) " & vbCrLf &
                       "FROM  MAEUS WHERE (KOOP LIKE '%LI%') AND (KOUS = '" & FUNCIONARIO & "'))" & vbCrLf &
                       "ORDER BY TILT,NOKOLT"
        CmbLista.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT Semilla AS Padre,NombreEtiqueta AS Hijo FROM Zw_Tbl_DisenoBarras order by Semilla"
        Cmbetiquetas.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        If RevisarProducto(TxtCodigo.Text) = True Then

            Dim Diseno As String = _Sql.Fx_Trae_Dato("Zw_Tbl_DisenoBarras", "FUNCION", "Semilla = " & Cmbetiquetas.SelectedValue.ToString)

            'Dim Puerto = Trim(trae_datoAccess(tb, "Impresora", "Tmp_Conf_Local", "Modulo = 'Pto_Serial_Barras'"))

            'imprimir_Codigo_de_barras(Puerto, True, Diseno, TxtCodigo.Text, "", CmbLista.SelectedValue, 0, "", "", ModEmpresa, ModSucursal, ModBodega, "", "")

        Else
            MsgBox("Código de producto no existe", MsgBoxStyle.Critical, "Imprimir Fleje")
            TxtCodigo.SelectAll()
            TxtCodigo.Focus()
        End If


    End Sub

    Private Sub BtnxBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxBuscarProducto.Click

        Codigo_abuscar = ""

        Dim Frm_BuscarXProducto_Mt As New Frm_BuscarXProducto_Mt
        Frm_BuscarXProducto_Mt.ShowDialog(Me)

        If Codigo_abuscar <> "" Then
            TxtCodigo.Text = Codigo_abuscar
            LlenarDatos(TxtCodigo.Text, CmbLista.SelectedValue)
        End If


    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If RevisarProducto(TxtCodigo.Text) = False Then
                Codigo_abuscar = ""

                Dim Frm_BuscarXProducto_Mt As New Frm_BuscarXProducto_Mt
                Frm_BuscarXProducto_Mt.ShowDialog(Me)

                If Codigo_abuscar <> "" Then
                    TxtCodigo.Text = Codigo_abuscar
                    LlenarDatos(TxtCodigo.Text, CmbLista.SelectedValue)
                End If
            Else
                LlenarDatos(TxtCodigo.Text, CmbLista.SelectedValue)
            End If
        End If
    End Sub

    Public Function RevisarProducto(ByVal Codigo As String) As Boolean

        If _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & Codigo & "'") > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


End Class