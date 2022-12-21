Imports DevComponents.DotNetBar

Public Class Frm_Dte_Configuracion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Correo As Integer
    Dim _AmbienteCertificacion As Integer
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Dte_Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _AmbienteCertificacion = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        Txt_Empresa.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'Empresa' And AmbienteCertificacion = " & _AmbienteCertificacion)
        Txt_RutEmisor.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'RutEmisor' And AmbienteCertificacion = " & _AmbienteCertificacion)
        Txt_RutEnvia.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'RutEnvia' And AmbienteCertificacion = " & _AmbienteCertificacion)
        Txt_RutReceptor.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'RutReceptor' And AmbienteCertificacion = " & _AmbienteCertificacion)

        If CBool(_AmbienteCertificacion) Then
            Txt_NroResol.Enabled = False
            Txt_NroResol.Text = 0
        Else
            Txt_NroResol.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'NroResol' And AmbienteCertificacion = " & _AmbienteCertificacion)
        End If

        Txt_FchResol.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                              "Empresa = '" & ModEmpresa & "' And Campo = 'FchResol' And AmbienteCertificacion = " & _AmbienteCertificacion)
        Txt_Cn.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'Cn' And AmbienteCertificacion = " & _AmbienteCertificacion)

        _Id_Correo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion",
                                       "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'Id_Correo' And AmbienteCertificacion = " & _AmbienteCertificacion, True,, 0)
        Txt_Id_Correo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Correos", "Nombre_Correo", "Id = " & _Id_Correo)

        Txt_NombreFormato_PDF_BLV.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'NombreFormato_PDF_BLV' And AmbienteCertificacion = " & _AmbienteCertificacion)
        Txt_NombreFormato_PDF_FCV.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'NombreFormato_PDF_FCV' And AmbienteCertificacion = " & _AmbienteCertificacion)
        Txt_NombreFormato_PDF_NCV.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'NombreFormato_PDF_NCV' And AmbienteCertificacion = " & _AmbienteCertificacion)
        Txt_MailContactoSIIPruebas.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'MailContactoSIIPruebas' And AmbienteCertificacion = " & _AmbienteCertificacion)

        'If String.IsNullOrEmpty(Txt_Empresa.Text) Then Txt_Empresa.Text = _Global_Row_Configp.Item("EMPRESA")
        'If String.IsNullOrEmpty(Txt_RutEnvia.Text) Then Txt_RutEnvia.Text = _Global_Row_Configp.Item("FIRMAELEC")
        'If String.IsNullOrEmpty(Txt_RutEmisor.Text) Then Txt_RutEmisor.Text = _Global_Row_Configp.Item("RUT")
        'If String.IsNullOrEmpty(Txt_RutReceptor.Text) Then Txt_RutReceptor.Text = "60803000-K"
        'If String.IsNullOrEmpty(Txt_NroResol.Text) Then Txt_NroResol.Text = _Global_Row_Configp.Item("NRORESOL")
        'If String.IsNullOrEmpty(Txt_FchResol.Text) Then Txt_FchResol.Text = Format(_Global_Row_Configp.Item("FECHRESOL"), "yyyy-MM-dd")

        If CBool(_AmbienteCertificacion) Then
            Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
            MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
            Lbl_Etiqueta.Text = "Ambiente de Certificación y Prueba"
        End If

        Txt_MailContactoSIIPruebas.Visible = CBool(_AmbienteCertificacion)
        LabelX13.Visible = CBool(_AmbienteCertificacion)

    End Sub

    Sub Sb_Llenar_Valor_Campo(_Fila As DataRow, _Objeto As Object)
        If _Fila.Item("Campo") = _Objeto.Tag Then _Objeto.Text = _Fila.Item("Valor")
    End Sub

    Private Sub Btn_Buscar_Cn_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Cn.Click

    End Sub

    Private Sub Btn_Buscar_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Correo.Click

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            _Id_Correo = Fm.Pro_Row_Fila_Seleccionada.Item("Id")
            Txt_Id_Correo.Text = Fm.Pro_Row_Fila_Seleccionada.Item("Nombre_Correo")
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Buscar_Formato_FCV_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Formato_FCV.Click
        Sb_Buscar_Formato("FCV", Txt_NombreFormato_PDF_FCV)
    End Sub

    Private Sub Btn_Buscar_Formato_NCV_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Formato_NCV.Click
        Sb_Buscar_Formato("NCV", Txt_NombreFormato_PDF_NCV)
    End Sub

    Private Sub Btn_Buscar_Formato_BLV_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Formato_BLV.Click
        Sb_Buscar_Formato("BLV", Txt_NombreFormato_PDF_BLV)
    End Sub

    Sub Sb_Buscar_Formato(_Tido As String, _Txt As Object)

        Dim Fm As New Frm_Seleccionar_Formato(_Tido)

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)
            If Fm.Formato_Seleccionado Then
                _Txt.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            End If
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Empresa.Text) Then
            MessageBoxEx.Show(Me, "Falta la empresa", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_RutEmisor.Text) Then
            MessageBoxEx.Show(Me, "Falta Rut Emisor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_RutEnvia.Text) Then
            MessageBoxEx.Show(Me, "Falta Rut envia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_RutReceptor.Text) Then
            MessageBoxEx.Show(Me, "Falta Rut Receptor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_NroResol.Text) Then
            MessageBoxEx.Show(Me, "Falta Nro Resol", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_FchResol.Text) Then
            MessageBoxEx.Show(Me, "Falta Fecha Resol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Cn.Text) Then
            MessageBoxEx.Show(Me, "Falta el nombre del certificado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Id_Correo.Text) Then
            MessageBoxEx.Show(Me, "Falta el correo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If CBool(_AmbienteCertificacion) Then
            If String.IsNullOrEmpty(Txt_MailContactoSIIPruebas.Text) Then
                MessageBoxEx.Show(Me, "Falta el correo de contacto para las pruebas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        'If String.IsNullOrEmpty(Txt_NombreFormato_PDF_BLV.Text) Then
        '    MessageBoxEx.Show(Me, "Falta el formato para BLV", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'If String.IsNullOrEmpty(Txt_NombreFormato_PDF_BLV.Text) Then
        '    MessageBoxEx.Show(Me, "Falta el formato para FCV", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'If String.IsNullOrEmpty(Txt_NombreFormato_PDF_BLV.Text) Then
        '    MessageBoxEx.Show(Me, "Falta el formato para NCV", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion " &
                       "In ('ConfEmpresa','ConfCorreoSalida','ConfFormatoDoc') And AmbienteCertificacion = " & _AmbienteCertificacion & vbCrLf & vbCrLf

        Consulta_sql += Fx_Llenar_Input_Configuracion("Empresa", Txt_Empresa.Text, "String", "ConfEmpresa", _AmbienteCertificacion)
        Consulta_sql += Fx_Llenar_Input_Configuracion("RutEmisor", Txt_RutEmisor.Text, "String", "ConfEmpresa", _AmbienteCertificacion)
        Consulta_sql += Fx_Llenar_Input_Configuracion("RutEnvia", Txt_RutEnvia.Text, "String", "ConfEmpresa", _AmbienteCertificacion)
        Consulta_sql += Fx_Llenar_Input_Configuracion("RutReceptor", Txt_RutReceptor.Text, "String", "ConfEmpresa", _AmbienteCertificacion)

        If CBool(_AmbienteCertificacion) Then
            Consulta_sql += Fx_Llenar_Input_Configuracion("MailContactoSIIPruebas", Txt_MailContactoSIIPruebas.Text, "String", "ConfEmpresa", _AmbienteCertificacion)
        Else
            Consulta_sql += Fx_Llenar_Input_Configuracion("NroResol", Txt_NroResol.Text, "Date", "ConfEmpresa", _AmbienteCertificacion)
        End If

        Consulta_sql += Fx_Llenar_Input_Configuracion("FchResol", Txt_FchResol.Text, "Date", "ConfEmpresa", _AmbienteCertificacion)
        Consulta_sql += Fx_Llenar_Input_Configuracion("Cn", Txt_Cn.Text, "String", "ConfEmpresa", _AmbienteCertificacion)

        Consulta_sql += Fx_Llenar_Input_Configuracion("Id_Correo", _Id_Correo, "Numerico", "ConfCorreoSalida", _AmbienteCertificacion)

        Consulta_sql += Fx_Llenar_Input_Configuracion("NombreFormato_PDF_BLV", Txt_NombreFormato_PDF_BLV.Text, "String", "ConfFormatoDoc", _AmbienteCertificacion)
        Consulta_sql += Fx_Llenar_Input_Configuracion("NombreFormato_PDF_FCV", Txt_NombreFormato_PDF_FCV.Text, "String", "ConfFormatoDoc", _AmbienteCertificacion)
        Consulta_sql += Fx_Llenar_Input_Configuracion("Txt_NombreFormato_PDF_NCV", Txt_NombreFormato_PDF_NCV.Text, "String", "ConfFormatoDoc", _AmbienteCertificacion)

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Function Fx_Llenar_Input_Configuracion(_Campo As String,
                                           _Valor As String,
                                           _TipoCampo As String,
                                           _TipoConfiguracion As String,
                                           _AmbienteCertificacion As Integer) As String

        Dim _Insert = "Insert Into " & _Global_BaseBk & "Zw_DTE_Configuracion (Empresa, Campo, Valor, FechaMod, TipoCampo, TipoConfiguracion,AmbienteCertificacion) Values " &
                        "('" & ModEmpresa & "','" & _Campo & "','" & _Valor.Trim & "',Getdate(),'" & _TipoCampo & "','" & _TipoConfiguracion & "'," & _AmbienteCertificacion & ")" & vbCrLf

        Return _Insert

    End Function

    Private Sub Btn_Quitar_Formato_FCV_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Formato_FCV.Click
        Txt_NombreFormato_PDF_FCV.Text = String.Empty
    End Sub

    Private Sub Btn_Quitar_Formato_NCV_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Formato_NCV.Click
        Txt_NombreFormato_PDF_NCV.Text = String.Empty
    End Sub

    Private Sub Btn_Quitar_Formato_BLV_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Formato_BLV.Click
        Txt_NombreFormato_PDF_BLV.Text = String.Empty
    End Sub

    Private Sub Btn_Importar_Datos_Random_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Datos_Random.Click

        If MessageBoxEx.Show(Me, "¿Confirma importar los datos desde el CONFIG de Random?", "Importar datos",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Txt_Empresa.Text = _Global_Row_Configp.Item("EMPRESA").ToString.Trim
        Txt_RutEnvia.Text = _Global_Row_Configp.Item("FIRMAELEC").ToString.Trim
        Txt_RutEmisor.Text = _Global_Row_Configp.Item("RUT").ToString.Trim
        Txt_RutReceptor.Text = "60803000-K".ToString.Trim
        Txt_NroResol.Text = _Global_Row_Configp.Item("NRORESOL").ToString.Trim
        Txt_FchResol.Text = Format(_Global_Row_Configp.Item("FECHRESOL"), "yyyy-MM-dd").ToString.Trim

        MessageBoxEx.Show(Me, "Datos importados correctamente", "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class
