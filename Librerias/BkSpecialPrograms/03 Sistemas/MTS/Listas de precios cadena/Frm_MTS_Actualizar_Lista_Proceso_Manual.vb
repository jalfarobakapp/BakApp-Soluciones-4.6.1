'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient

Public Class Frm_MTS_Actualizar_Lista_Proceso_Manual

    Public _Ejecutar As Boolean
    Public _CodProveedor As String

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnActualizarInformacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizarInformacion.Click

        If Chk_Proveedor.Checked Then

            If String.IsNullOrEmpty(_CodProveedor) Then
                MessageBoxEx.Show(Me, "Falta seleccionar el proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        If String.IsNullOrEmpty(Trim(TxtCodLista.Text)) Then
            MessageBoxEx.Show(Me, "Debe ingresar lista de costos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Ejecutar = True
        Me.Close()

    End Sub

    Private Sub BtnRutaDirectorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRutaDirectorio.Click
        With Dir_Buscar
            .Reset() ' resetea  
            ' leyenda  
            .Description = "Seleccionar carpeta de archivos DBF MTS"
            ' Path " Mis documentos "  

            Dim UltCarpeta As String = TxtRutaArchivosDBF.Text

            If String.IsNullOrEmpty(Trim(UltCarpeta)) Then _
            UltCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer).ToString
            .SelectedPath = UltCarpeta ' Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)

            ' deshabilita el botón " crear nueva carpeta "  
            .ShowNewFolderButton = False
            '.RootFolder = Environment.SpecialFolder.Desktop  
            '.RootFolder = Environment.SpecialFolder.StartMenu  

            Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

            ' si se presionó el botón aceptar ...  
            If ret = Windows.Forms.DialogResult.OK Then
                TxtRutaArchivosDBF.Text = .SelectedPath
            End If

            .Dispose()

        End With
    End Sub

    Private Sub BtnListaCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListaCostos.Click

        Dim _Lista_Seleccionada As DataTable

        Dim Fm As New Frm_SeleccionarListaPrecios(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Costo, False, False) 'Frm_MantListas
        Fm.ShowDialog(Me)
        _Lista_Seleccionada = Fm.Pro_Tbl_Listas_Seleccionadas
        Fm.Dispose()

        If Not (_Lista_Seleccionada Is Nothing) Then

            TxtCodLista.Text = _Lista_Seleccionada.Rows(0).Item("Lista")
            TxtNomLista.Text = _Lista_Seleccionada.Rows(0).Item("Nombre_Lista")
        End If

    End Sub

    Private Sub BtnBuscarEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarEntidad.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then
            TxtProveedor.Text = Fm.Pro_RowEntidad.Item("NOKOEN") '_Sql.Fx_Trae_Dato(, "NOKOEN", "MAEEN", "KOEN = '" & ENTIDAD & "' AND SUEN = '" & SUCURSAL & "'")
            _CodProveedor = Fm.Pro_RowEntidad.Item("KOEN") 'ENTIDAD
        Else
            TxtProveedor.Text = String.Empty
            _CodProveedor = String.Empty
        End If

        Fm.Dispose()

    End Sub
End Class
