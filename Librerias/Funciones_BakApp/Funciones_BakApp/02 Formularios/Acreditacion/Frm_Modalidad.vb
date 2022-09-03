Imports Funciones_BakApp
Public Class Frm_Modalidad


    Private Sub Frm_Modalidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        caract_combo(CmbModalidad)
        Consulta_sql = "SELECT MODALIDAD AS Padre,MODALIDAD AS Hijo FROM CONFIEST where EMPRESA = '01'" & vbCrLf & _
                       "and MODALIDAD <> '  '"

        Consulta_sql = "SELECT SUBSTRING(KOOP,4,6) AS Padre ,SUBSTRING(KOOP,4,6) AS Hijo FROM MAEOP WHERE " & vbCrLf & _
                      "KOOP IN (SELECT KOOP FROM MAEUS WHERE KOUS = '" & FUNCIONARIO & "' AND KOOP LIKE 'MO-%')" & vbCrLf & _
                      "AND KOOP <> 'MO-  '"

        CmbModalidad.DataSource = get_Tablas(Consulta_sql, cn1)

        If CmbModalidad.Items.Count > 0 Then
            Modalidad = trae_dato(tb, cn1, "MODALIDAD", "TABFU", "KOFU = '" & FUNCIONARIO & "'")
            CmbModalidad.SelectedValue = Modalidad
            RevModalidad(Modalidad, "01")
        Else
            MsgBox("Usted no posee permiso para trabajar con ninguna modalidad de Random." & vbCrLf & _
                   "Pongase en contacto con el administrador del sistema", MsgBoxStyle.Critical, "Modalidad")
        End If


    End Sub

    Private Sub BtnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresar.Click
        Try

            If CmbModalidad.Text <> "" Then

                Modalidad = CmbModalidad.SelectedValue.ToString
                ModEmpresa = "01"
                ModSucursal = TxtSucursal.Text
                ModBodega = TxtBodega.Text
                ModCaja = TxtCaja.Text
                ModListaPrecioCosto = Mid(TxtLPCompra.Text, 6, 3)
                ModListaPrecioVenta = Mid(TxtLPVenta.Text, 6, 3)

                ListaPrecio_BusquedaPR = ModListaPrecioVenta
                ' MsgBox("Modalidad Fue cambiada", MsgBoxStyle.Information, "Cambiar Modalidad")

                Me.Close()
            Else
                MsgBox("Debe seleccionar una modalidad", MsgBoxStyle.Critical, "Modalidad")
            End If

        Catch ex As Exception
            MsgBox("Debe seleccionar una modalidad", MsgBoxStyle.Critical, "Modalidad")
            MsgBox(ex.Message)
        End Try

    End Sub


    Function RevModalidad(ByVal Modalidad As String, ByVal Empresa As String)

        TxtSucursal.Text = trae_dato(tb, cn1, "ESUCURSAL", "CONFIEST", "EMPRESA = '" & Empresa & _
                                     "' and MODALIDAD = '" & Modalidad & "'")

        TxtBodega.Text = trae_dato(tb, cn1, "EBODEGA", "CONFIEST", "EMPRESA = '" & Empresa & _
                                     "' and MODALIDAD = '" & Modalidad & "'")

        TxtCaja.Text = trae_dato(tb, cn1, "ECAJA", "CONFIEST", "EMPRESA = '" & Empresa & _
                                     "' and MODALIDAD = '" & Modalidad & "'")

        TxtLPCompra.Text = trae_dato(tb, cn1, "ELISTACOM", "CONFIEST", "EMPRESA = '" & Empresa & _
                                     "' and MODALIDAD = '" & Modalidad & "'")
        'SUBSTRING(ELISTAVEN,6,3)
        TxtLPVenta.Text = trae_dato(tb, cn1, "ELISTAVEN", "CONFIEST", "EMPRESA = '" & Empresa & _
                                     "' and MODALIDAD = '" & Modalidad & "'")


    End Function

    Private Sub CmbModalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbModalidad.SelectedIndexChanged
        RevModalidad(CmbModalidad.SelectedValue.ToString, "01")
    End Sub
End Class