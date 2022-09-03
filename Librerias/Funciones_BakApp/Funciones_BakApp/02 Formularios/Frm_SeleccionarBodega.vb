
Public Class Frm_SeleccionarBodega

    Public Emp, Suc, Bod As String

    Private Sub Frm_SeleccionarBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        caract_combo(Cmbempresa)
        Consulta_sql = "SELECT EMPRESA AS Padre,RAZON AS Hijo FROM CONFIGP" ' WHERE SEMILLA = " & Actividad
        Cmbempresa.DataSource = get_Tablas(Consulta_sql, cn1)
        Cmbempresa.Focus()
    End Sub



    Function CMDempresa()
        Try

            Cmbsucursal.DataSource = Nothing
            Cmbbodega.DataSource = Nothing

            caract_combo(Cmbsucursal)
            Consulta_sql = "SELECT KOSU AS Padre,KOSU+'-'+NOKOSU AS Hijo FROM TABSU WHERE EMPRESA = '" & CodEmpresa & "'"
            Cmbsucursal.DataSource = get_Tablas(Consulta_sql, cn1)

        Catch ex As Exception
            '     Nivel1 = "" : Nivel2 = "" : Nivel3 = ""
            '     Cmbnivel2.DataSource = Nothing
            '     Cmbnivel3.DataSource = Nothing
        End Try

    End Function

    Function CMDsucursal()
        Try
            'Cmbsucursal.DataSource = Nothing
            Cmbbodega.DataSource = Nothing
            caract_combo(Cmbbodega)
            Consulta_sql = "SELECT KOBO AS Padre,KOBO+'-'+NOKOBO AS Hijo FROM TABBO " & _
                           "WHERE EMPRESA = '" & CodEmpresa & "' AND KOSU = '" & CodSucursal & "'"
            Cmbbodega.DataSource = get_Tablas(Consulta_sql, cn1)
        Catch ex As Exception
            '     Nivel1 = "" : Nivel2 = "" : Nivel3 = ""
            '     Cmbnivel2.DataSource = Nothing
            '     Cmbnivel3.DataSource = Nothing
        End Try

    End Function

    Private Sub Cmbempresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbempresa.SelectedIndexChanged
        Try
            CodEmpresa = Cmbempresa.SelectedValue.ToString
            CMDempresa()
        Catch ex As Exception
            CMDempresa()
        End Try
    End Sub

    Private Sub Cmbsucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbsucursal.SelectedIndexChanged
        Try
            CodSucursal = Cmbsucursal.SelectedValue.ToString
            CMDsucursal()
        Catch ex As Exception
            CMDsucursal()
        End Try
    End Sub

    Private Sub Cmbbodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbbodega.SelectedIndexChanged
        Try
            CodBodega = Cmbbodega.SelectedValue.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Emp = ""
        Suc = ""
        Bod = ""
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Emp = Cmbempresa.SelectedValue
        Suc = Cmbsucursal.SelectedValue
        Bod = Cmbbodega.SelectedValue
        Me.Close()
    End Sub
End Class