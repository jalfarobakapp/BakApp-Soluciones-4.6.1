'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient


Public Class Frm_MTS_Actualizar_Lista_Parametros

    Dim Datos_MTS As New Ds_MTS
    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\MTS\Datos_MTS.xml"
    Public _Grabar As Boolean

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Grabar = False
        Me.Close()
    End Sub

    Private Sub Frm_MTS_Actualizar_Lista_Parametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Grilla

            .DataSource = Nothing
            .DataSource = Datos_MTS
            .DataMember = Datos_MTS.Tables("Conf_Ejecucion").TableName


            .Columns("Hora_Ejecucion").Visible = True
            .Columns("Hora_Ejecucion").HeaderText = "Hora"
            .Columns("Hora_Ejecucion").Width = 60
            .Columns("Hora_Ejecucion").DefaultCellStyle.Format = "hh:mm:ss"

            .Columns("Lunes").Visible = True
            .Columns("Lunes").HeaderText = "Lun"
            .Columns("Lunes").Width = 30

            .Columns("Martes").Visible = True
            .Columns("Martes").HeaderText = "Mar"
            .Columns("Martes").Width = 30

            .Columns("Miercoles").Visible = True
            .Columns("Miercoles").HeaderText = "Mie"
            .Columns("Miercoles").Width = 30

            .Columns("Jueves").Visible = True
            .Columns("Jueves").HeaderText = "Jue"
            .Columns("Jueves").Width = 30

            .Columns("Viernes").Visible = True
            .Columns("Viernes").HeaderText = "Vie"
            .Columns("Viernes").Width = 30

            .Columns("Sabado").Visible = True
            .Columns("Sabado").HeaderText = "Sab"
            .Columns("Sabado").Width = 30

            .Columns("Domingo").Visible = True
            .Columns("Domingo").HeaderText = "Dom"
            .Columns("Domingo").Width = 30

            .Columns("Accion").Visible = True
            .Columns("Accion").HeaderText = "Acción"
            .Columns("Accion").Width = 290

            '.Columns("Lunes").DefaultCellStyle.Format = "hh:mm:ss"

        End With

        TxtArchivoDescuentos.Text = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Archivo_Dsctos")
        TxtRutaArchivosDBF.Text = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Directorio_Ruta")
        TxtCodLista.Text = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Cod_Lista")
        TxtNomLista.Text = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Nom_Lista")
        Chk_GuardarConDsctos.Checked = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Guardar_Con_Dscto_Inc")

    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        
        Datos_MTS.ReadXml(_Path)


    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Archivo_Dsctos") = TxtArchivoDescuentos.Text
        Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Directorio_Ruta") = TxtRutaArchivosDBF.Text
        Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Cod_Lista") = TxtCodLista.Text
        Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Nom_Lista") = TxtNomLista.Text
        Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Guardar_Con_Dscto_Inc") = Chk_GuardarConDsctos.Checked
        Datos_MTS.WriteXml(_Path)

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", _
                          "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        _Grabar = True
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
End Class
