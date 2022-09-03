'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Configuracion_vales

    Public _Datos_Conf As New Ds_Vales
    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Vales_despacho\Config_Estacion.xml"

   

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Vales_despacho") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\Vales_despacho")
        End If

        _Datos_Conf.Clear()
        Dim exists = System.IO.File.Exists(_Path)
        With _Datos_Conf
            If Not exists Then

                Dim NewFila As DataRow
                NewFila = _Datos_Conf.Tables("Tbl_Configuracion").NewRow

                With NewFila

                    .Item("Impresora_pred") = String.Empty
                    .Item("Rdb_Retira_Cliente") = False
                    .Item("Rdb_Despacho_Domicilio") = False
                    .Item("Rdb_Ambos") = False
                    .Item("Chk_VerMarcadas") = False
                    .Item("Chk_VerActivas") = False
                    .Item("Chk_VerCerradas") = False
                    .Item("Chk_VerNulas") = False
                    .Item("Segundos_Actualizacion") = 10

                End With

                .Tables("Tbl_Configuracion").Rows.Add(NewFila)

                .WriteXml(_Path)
            Else
                .ReadXml(_Path)
            End If
        End With
    End Sub

   
    Sub Sb_LlenaCombo_Segundos_Actualiza()
        caract_combo(Cmb_Segundos_Act)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "10" : dr("Hijo") = "10 segundos." : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "20" : dr("Hijo") = "20 segundos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "30" : dr("Hijo") = "30 segundos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "45" : dr("Hijo") = "45 segundos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "1" : dr("Hijo") = "1 minuto" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "15" : dr("Hijo") = "5 minutos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "30" : dr("Hijo") = "10 minutos" : dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With Cmb_Segundos_Act
            .DataSource = Nothing
            .DataSource = dt
        End With

        Cmb_Segundos_Act.SelectedValue = "10"
    End Sub


    Private Sub Frm_Configuracion_vales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_LlenaCombo_Segundos_Actualiza()

        _Datos_Conf.ReadXml(_Path)

        Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)

        Chk_VerMarcadas.Checked = _Fila.Item("Chk_VerMarcadas")
        Chk_VerActivas.Checked = _Fila.Item("Chk_VerActivas")
        Chk_VerCerradas.Checked = _Fila.Item("Chk_VerCerradas")
        Chk_VerNulas.Checked = _Fila.Item("Chk_VerNulas")

        Rdb_Retira_Cliente.Checked = _Fila.Item("Rdb_Retira_Cliente")
        Rdb_Despacho_Domicilio.Checked = _Fila.Item("Rdb_Despacho_Domicilio")
        Rdb_Ambos.Checked = _Fila.Item("Rdb_Ambos")

        Txt_Impresora.Text = _Fila.Item("Impresora_pred")
        Txt_RutaImagen.Text = NuloPorNro(_Fila.Item("Ruta_Imagen"), "")
        Cmb_Segundos_Act.SelectedValue = _Fila.Item("Segundos_Actualizacion")



    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        If Fx_Tiene_Permiso(Me, "Vale0018") Then

            _Datos_Conf.Clear()
            With _Datos_Conf

                Dim NewFila As DataRow
                NewFila = _Datos_Conf.Tables("Tbl_Configuracion").NewRow

                With NewFila

                    .Item("Impresora_pred") = Txt_Impresora.Text
                    .Item("Ruta_Imagen") = Txt_RutaImagen.Text
                    .Item("Rdb_Retira_Cliente") = Rdb_Retira_Cliente.Checked
                    .Item("Rdb_Despacho_Domicilio") = Rdb_Despacho_Domicilio.Checked
                    .Item("Rdb_Ambos") = Rdb_Ambos.Checked
                    .Item("Chk_VerMarcadas") = Chk_VerMarcadas.Checked
                    .Item("Chk_VerActivas") = Chk_VerActivas.Checked
                    .Item("Chk_VerCerradas") = Chk_VerCerradas.Checked
                    .Item("Chk_VerNulas") = Chk_VerNulas.Checked
                    .Item("Segundos_Actualizacion") = Cmb_Segundos_Act.SelectedValue
                End With
                .Tables("Tbl_Configuracion").Rows.Add(NewFila)

                .WriteXml(_Path)

            End With

            ToastNotification.Show(Me, "DATOS GUARDADOS CORRECTAMENTE", My.Resources.ok_button, _
                                         3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Btn_Impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Impresora.Click

        Dim Fm As New Frm_Seleccionar_Impresoras(Txt_Impresora.Text)
        Fm.ShowDialog(Me)

        If Not String.IsNullOrEmpty(Trim(Fm.Pro_Impresora_Seleccionada)) Then

            Txt_Impresora.Text = Fm.Pro_Impresora_Seleccionada
            ToastNotification.Show(Me, "IMPRESORA SELECCIONADA [" & Txt_Impresora.Text & "]", My.Resources.ok_button,
                                         3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If
        Fm.Dispose()

    End Sub

    Private Sub BtnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RutaImagen.Click

        Dim OpenBuscarImagen As New OpenFileDialog
        OpenBuscarImagen.ShowDialog()
        Dim _RutaImagen = OpenBuscarImagen.FileName

        Txt_RutaImagen.Text = _RutaImagen

        
    End Sub

    Private Sub Frm_Configuracion_vales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class