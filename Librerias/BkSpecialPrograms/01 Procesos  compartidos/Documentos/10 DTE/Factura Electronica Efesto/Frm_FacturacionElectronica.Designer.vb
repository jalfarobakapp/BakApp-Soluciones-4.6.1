<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FacturacionElectronica
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_Consumo_Folios = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Enviar_Documento_SII = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Idmaeedo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Trackid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Notificacion_Correo = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_CAF = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_FirmarYEnviarAlSII = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Id_Trackid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Firmar_Documento = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_AmbienteCertificacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Enviar_Boleta = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Trackid2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Id_Dte = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Consultar_Boleta = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'Btn_Consumo_Folios
        '
        Me.Btn_Consumo_Folios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Consumo_Folios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Consumo_Folios.Location = New System.Drawing.Point(26, 12)
        Me.Btn_Consumo_Folios.Name = "Btn_Consumo_Folios"
        Me.Btn_Consumo_Folios.Size = New System.Drawing.Size(135, 23)
        Me.Btn_Consumo_Folios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Consumo_Folios.TabIndex = 0
        Me.Btn_Consumo_Folios.Text = "Consumo de folios"
        '
        'Btn_Enviar_Documento_SII
        '
        Me.Btn_Enviar_Documento_SII.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Enviar_Documento_SII.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Enviar_Documento_SII.Location = New System.Drawing.Point(26, 115)
        Me.Btn_Enviar_Documento_SII.Name = "Btn_Enviar_Documento_SII"
        Me.Btn_Enviar_Documento_SII.Size = New System.Drawing.Size(135, 23)
        Me.Btn_Enviar_Documento_SII.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Enviar_Documento_SII.TabIndex = 1
        Me.Btn_Enviar_Documento_SII.Text = "Enviar documento al SII"
        '
        'Txt_Idmaeedo
        '
        Me.Txt_Idmaeedo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Idmaeedo.Border.Class = "TextBoxBorder"
        Me.Txt_Idmaeedo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Idmaeedo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Idmaeedo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Idmaeedo.Location = New System.Drawing.Point(98, 59)
        Me.Txt_Idmaeedo.Name = "Txt_Idmaeedo"
        Me.Txt_Idmaeedo.PreventEnterBeep = True
        Me.Txt_Idmaeedo.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Idmaeedo.TabIndex = 3
        '
        'Txt_Trackid
        '
        Me.Txt_Trackid.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Trackid.Border.Class = "TextBoxBorder"
        Me.Txt_Trackid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Trackid.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Trackid.ForeColor = System.Drawing.Color.Black
        Me.Txt_Trackid.Location = New System.Drawing.Point(264, 59)
        Me.Txt_Trackid.Name = "Txt_Trackid"
        Me.Txt_Trackid.PreventEnterBeep = True
        Me.Txt_Trackid.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Trackid.TabIndex = 6
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(212, 59)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 5
        Me.LabelX2.Text = "Trackid"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(26, 144)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(135, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 4
        Me.ButtonX1.Text = "Consultar Trackid"
        '
        'Btn_Notificacion_Correo
        '
        Me.Btn_Notificacion_Correo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Notificacion_Correo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Notificacion_Correo.Location = New System.Drawing.Point(26, 173)
        Me.Btn_Notificacion_Correo.Name = "Btn_Notificacion_Correo"
        Me.Btn_Notificacion_Correo.Size = New System.Drawing.Size(135, 23)
        Me.Btn_Notificacion_Correo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Notificacion_Correo.TabIndex = 7
        Me.Btn_Notificacion_Correo.Text = "Enviar notificacion correo"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(26, 59)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(66, 23)
        Me.LabelX3.TabIndex = 8
        Me.LabelX3.Text = "Idmaeedo"
        '
        'Btn_CAF
        '
        Me.Btn_CAF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_CAF.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_CAF.Location = New System.Drawing.Point(26, 202)
        Me.Btn_CAF.Name = "Btn_CAF"
        Me.Btn_CAF.Size = New System.Drawing.Size(135, 23)
        Me.Btn_CAF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_CAF.TabIndex = 9
        Me.Btn_CAF.Text = "Subir folios CAF"
        '
        'Btn_FirmarYEnviarAlSII
        '
        Me.Btn_FirmarYEnviarAlSII.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_FirmarYEnviarAlSII.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_FirmarYEnviarAlSII.Location = New System.Drawing.Point(26, 231)
        Me.Btn_FirmarYEnviarAlSII.Name = "Btn_FirmarYEnviarAlSII"
        Me.Btn_FirmarYEnviarAlSII.Size = New System.Drawing.Size(135, 23)
        Me.Btn_FirmarYEnviarAlSII.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_FirmarYEnviarAlSII.TabIndex = 10
        Me.Btn_FirmarYEnviarAlSII.Text = "Enviar documento al SII"
        '
        'Txt_Id_Trackid
        '
        Me.Txt_Id_Trackid.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Id_Trackid.Border.Class = "TextBoxBorder"
        Me.Txt_Id_Trackid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Id_Trackid.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Id_Trackid.ForeColor = System.Drawing.Color.Black
        Me.Txt_Id_Trackid.Location = New System.Drawing.Point(422, 59)
        Me.Txt_Id_Trackid.Name = "Txt_Id_Trackid"
        Me.Txt_Id_Trackid.PreventEnterBeep = True
        Me.Txt_Id_Trackid.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Id_Trackid.TabIndex = 12
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(370, 59)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 11
        Me.LabelX1.Text = "Id Trackid"
        '
        'Btn_Firmar_Documento
        '
        Me.Btn_Firmar_Documento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Firmar_Documento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Firmar_Documento.Location = New System.Drawing.Point(26, 295)
        Me.Btn_Firmar_Documento.Name = "Btn_Firmar_Documento"
        Me.Btn_Firmar_Documento.Size = New System.Drawing.Size(135, 23)
        Me.Btn_Firmar_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Firmar_Documento.TabIndex = 13
        Me.Btn_Firmar_Documento.Text = "Firmar documentos"
        '
        'Chk_AmbienteCertificacion
        '
        Me.Chk_AmbienteCertificacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_AmbienteCertificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_AmbienteCertificacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_AmbienteCertificacion.Location = New System.Drawing.Point(184, 295)
        Me.Chk_AmbienteCertificacion.Name = "Chk_AmbienteCertificacion"
        Me.Chk_AmbienteCertificacion.Size = New System.Drawing.Size(322, 23)
        Me.Chk_AmbienteCertificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AmbienteCertificacion.TabIndex = 14
        Me.Chk_AmbienteCertificacion.Text = "Ambiente Certificación"
        '
        'Btn_Enviar_Boleta
        '
        Me.Btn_Enviar_Boleta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Enviar_Boleta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Enviar_Boleta.Location = New System.Drawing.Point(26, 324)
        Me.Btn_Enviar_Boleta.Name = "Btn_Enviar_Boleta"
        Me.Btn_Enviar_Boleta.Size = New System.Drawing.Size(135, 23)
        Me.Btn_Enviar_Boleta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Enviar_Boleta.TabIndex = 15
        Me.Btn_Enviar_Boleta.Text = "Enviar Boleta..."
        '
        'Txt_Trackid2
        '
        Me.Txt_Trackid2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Trackid2.Border.Class = "TextBoxBorder"
        Me.Txt_Trackid2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Trackid2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Trackid2.ForeColor = System.Drawing.Color.Black
        Me.Txt_Trackid2.Location = New System.Drawing.Point(244, 352)
        Me.Txt_Trackid2.Name = "Txt_Trackid2"
        Me.Txt_Trackid2.PreventEnterBeep = True
        Me.Txt_Trackid2.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Trackid2.TabIndex = 17
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(172, 353)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(66, 23)
        Me.LabelX4.TabIndex = 16
        Me.LabelX4.Text = "Trackid"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(172, 324)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(66, 23)
        Me.LabelX5.TabIndex = 19
        Me.LabelX5.Text = "Id Dte"
        '
        'Txt_Id_Dte
        '
        Me.Txt_Id_Dte.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Id_Dte.Border.Class = "TextBoxBorder"
        Me.Txt_Id_Dte.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Id_Dte.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Id_Dte.ForeColor = System.Drawing.Color.Black
        Me.Txt_Id_Dte.Location = New System.Drawing.Point(244, 324)
        Me.Txt_Id_Dte.Name = "Txt_Id_Dte"
        Me.Txt_Id_Dte.PreventEnterBeep = True
        Me.Txt_Id_Dte.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Id_Dte.TabIndex = 18
        '
        'Btn_Consultar_Boleta
        '
        Me.Btn_Consultar_Boleta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Consultar_Boleta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Consultar_Boleta.Location = New System.Drawing.Point(26, 352)
        Me.Btn_Consultar_Boleta.Name = "Btn_Consultar_Boleta"
        Me.Btn_Consultar_Boleta.Size = New System.Drawing.Size(135, 23)
        Me.Btn_Consultar_Boleta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Consultar_Boleta.TabIndex = 20
        Me.Btn_Consultar_Boleta.Text = "Consultar Boleta..."
        '
        'Frm_FacturacionElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 436)
        Me.Controls.Add(Me.Btn_Consultar_Boleta)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.Txt_Id_Dte)
        Me.Controls.Add(Me.Txt_Trackid2)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Btn_Enviar_Boleta)
        Me.Controls.Add(Me.Chk_AmbienteCertificacion)
        Me.Controls.Add(Me.Btn_Firmar_Documento)
        Me.Controls.Add(Me.Txt_Id_Trackid)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Btn_FirmarYEnviarAlSII)
        Me.Controls.Add(Me.Btn_CAF)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Btn_Notificacion_Correo)
        Me.Controls.Add(Me.Txt_Trackid)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.Txt_Idmaeedo)
        Me.Controls.Add(Me.Btn_Enviar_Documento_SII)
        Me.Controls.Add(Me.Btn_Consumo_Folios)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_FacturacionElectronica"
        Me.Text = "MetroForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Consumo_Folios As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Enviar_Documento_SII As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Idmaeedo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Trackid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Notificacion_Correo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_CAF As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_FirmarYEnviarAlSII As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Id_Trackid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Firmar_Documento As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_AmbienteCertificacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Enviar_Boleta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Trackid2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Id_Dte As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Consultar_Boleta As DevComponents.DotNetBar.ButtonX
End Class
