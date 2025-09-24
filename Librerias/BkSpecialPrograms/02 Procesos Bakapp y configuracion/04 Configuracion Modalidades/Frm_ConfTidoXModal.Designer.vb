<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfTidoXModal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConfTidoXModal))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_ListaPrecioDoc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_ListaPrecioDoc = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nombreformato = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NombreFormato_PDF = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_InfNumeracion = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_AvisoSaldoFolios = New DevComponents.DotNetBar.LabelX()
        Me.Input_AvisoSaldoFolios = New DevComponents.Editors.IntegerInput()
        Me.Lbl_DiasAvisoExpiraFolio = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreFormato_Correo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Id_Correo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Input_DiasAvisoExpiraFolio = New DevComponents.Editors.IntegerInput()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Numero = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Guarda_PDF_Auto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Grabar_Con_Huella = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Obliga_Despacho = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sugiere_Despacho = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Obliga_Despacho_BodDistintas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Obliga_Transportista = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Enviar_Correo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_TimbrarXRandom = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_TimbrarXBakapp = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Deshabilitar_ObsAdicionales = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_AvisoSaldoFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_DiasAvisoExpiraFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_Deshabilitar_ObsAdicionales)
        Me.GroupPanel1.Controls.Add(Me.Txt_NombreFormato_PDF)
        Me.GroupPanel1.Controls.Add(Me.Lbl_AvisoSaldoFolios)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombreformato)
        Me.GroupPanel1.Controls.Add(Me.Txt_ListaPrecioDoc)
        Me.GroupPanel1.Controls.Add(Me.Input_AvisoSaldoFolios)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Rdb_TimbrarXBakapp)
        Me.GroupPanel1.Controls.Add(Me.Lbl_DiasAvisoExpiraFolio)
        Me.GroupPanel1.Controls.Add(Me.Input_DiasAvisoExpiraFolio)
        Me.GroupPanel1.Controls.Add(Me.Lbl_ListaPrecioDoc)
        Me.GroupPanel1.Controls.Add(Me.Rdb_TimbrarXRandom)
        Me.GroupPanel1.Controls.Add(Me.Btn_InfNumeracion)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Chk_Enviar_Correo)
        Me.GroupPanel1.Controls.Add(Me.Txt_NombreFormato_Correo)
        Me.GroupPanel1.Controls.Add(Me.Txt_Numero)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.Chk_Obliga_Transportista)
        Me.GroupPanel1.Controls.Add(Me.Txt_Id_Correo)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Tipo)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Chk_Obliga_Despacho_BodDistintas)
        Me.GroupPanel1.Controls.Add(Me.Chk_Guarda_PDF_Auto)
        Me.GroupPanel1.Controls.Add(Me.Chk_Grabar_Con_Huella)
        Me.GroupPanel1.Controls.Add(Me.Chk_Sugiere_Despacho)
        Me.GroupPanel1.Controls.Add(Me.Chk_Obliga_Despacho)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(564, 543)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 1
        Me.GroupPanel1.Text = "Opciones para el documento"
        '
        'Txt_ListaPrecioDoc
        '
        Me.Txt_ListaPrecioDoc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ListaPrecioDoc.Border.Class = "TextBoxBorder"
        Me.Txt_ListaPrecioDoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ListaPrecioDoc.ButtonCustom.Image = CType(resources.GetObject("Txt_ListaPrecioDoc.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_ListaPrecioDoc.ButtonCustom.Visible = True
        Me.Txt_ListaPrecioDoc.ButtonCustom2.Image = CType(resources.GetObject("Txt_ListaPrecioDoc.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_ListaPrecioDoc.ButtonCustom2.Visible = True
        Me.Txt_ListaPrecioDoc.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ListaPrecioDoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ListaPrecioDoc.ForeColor = System.Drawing.Color.Black
        Me.Txt_ListaPrecioDoc.Location = New System.Drawing.Point(437, 32)
        Me.Txt_ListaPrecioDoc.Name = "Txt_ListaPrecioDoc"
        Me.Txt_ListaPrecioDoc.PreventEnterBeep = True
        Me.Txt_ListaPrecioDoc.ReadOnly = True
        Me.Txt_ListaPrecioDoc.Size = New System.Drawing.Size(100, 22)
        Me.Txt_ListaPrecioDoc.TabIndex = 101
        Me.Txt_ListaPrecioDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_ListaPrecioDoc
        '
        Me.Lbl_ListaPrecioDoc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_ListaPrecioDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_ListaPrecioDoc.ForeColor = System.Drawing.Color.Black
        Me.Lbl_ListaPrecioDoc.Location = New System.Drawing.Point(362, 30)
        Me.Lbl_ListaPrecioDoc.Name = "Lbl_ListaPrecioDoc"
        Me.Lbl_ListaPrecioDoc.Size = New System.Drawing.Size(69, 23)
        Me.Lbl_ListaPrecioDoc.TabIndex = 100
        Me.Lbl_ListaPrecioDoc.Text = "Lista precios"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 89)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(99, 21)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Fomato imp. normal"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 116)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(97, 22)
        Me.LabelX6.TabIndex = 6
        Me.LabelX6.Text = "Fomato imp. PDF"
        '
        'Txt_Nombreformato
        '
        Me.Txt_Nombreformato.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombreformato.Border.Class = "TextBoxBorder"
        Me.Txt_Nombreformato.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombreformato.ButtonCustom.Image = CType(resources.GetObject("Txt_Nombreformato.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Nombreformato.ButtonCustom.Visible = True
        Me.Txt_Nombreformato.ButtonCustom2.Image = CType(resources.GetObject("Txt_Nombreformato.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Nombreformato.ButtonCustom2.Visible = True
        Me.Txt_Nombreformato.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombreformato.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombreformato.Location = New System.Drawing.Point(112, 89)
        Me.Txt_Nombreformato.Name = "Txt_Nombreformato"
        Me.Txt_Nombreformato.PreventEnterBeep = True
        Me.Txt_Nombreformato.ReadOnly = True
        Me.Txt_Nombreformato.Size = New System.Drawing.Size(425, 22)
        Me.Txt_Nombreformato.TabIndex = 9
        '
        'Txt_NombreFormato_PDF
        '
        Me.Txt_NombreFormato_PDF.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_PDF.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_PDF.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_PDF.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato_PDF.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_PDF.ButtonCustom.Visible = True
        Me.Txt_NombreFormato_PDF.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato_PDF.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_PDF.ButtonCustom2.Visible = True
        Me.Txt_NombreFormato_PDF.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_PDF.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_PDF.Location = New System.Drawing.Point(112, 116)
        Me.Txt_NombreFormato_PDF.Name = "Txt_NombreFormato_PDF"
        Me.Txt_NombreFormato_PDF.PreventEnterBeep = True
        Me.Txt_NombreFormato_PDF.ReadOnly = True
        Me.Txt_NombreFormato_PDF.Size = New System.Drawing.Size(425, 22)
        Me.Txt_NombreFormato_PDF.TabIndex = 10
        '
        'Btn_InfNumeracion
        '
        Me.Btn_InfNumeracion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_InfNumeracion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_InfNumeracion.Location = New System.Drawing.Point(204, 32)
        Me.Btn_InfNumeracion.Name = "Btn_InfNumeracion"
        Me.Btn_InfNumeracion.Size = New System.Drawing.Size(103, 22)
        Me.Btn_InfNumeracion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_InfNumeracion.TabIndex = 19
        Me.Btn_InfNumeracion.Text = "<- como funciona?"
        Me.Btn_InfNumeracion.Tooltip = "Información de como funciona la numeración"
        '
        'Lbl_AvisoSaldoFolios
        '
        Me.Lbl_AvisoSaldoFolios.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_AvisoSaldoFolios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_AvisoSaldoFolios.ForeColor = System.Drawing.Color.Black
        Me.Lbl_AvisoSaldoFolios.Location = New System.Drawing.Point(98, 482)
        Me.Lbl_AvisoSaldoFolios.Name = "Lbl_AvisoSaldoFolios"
        Me.Lbl_AvisoSaldoFolios.Size = New System.Drawing.Size(365, 20)
        Me.Lbl_AvisoSaldoFolios.TabIndex = 101
        Me.Lbl_AvisoSaldoFolios.Text = "Número de documentos que quedan para dar aviso por los folios DTE."
        '
        'Input_AvisoSaldoFolios
        '
        '
        '
        '
        Me.Input_AvisoSaldoFolios.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_AvisoSaldoFolios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_AvisoSaldoFolios.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_AvisoSaldoFolios.ForeColor = System.Drawing.Color.Black
        Me.Input_AvisoSaldoFolios.Location = New System.Drawing.Point(6, 480)
        Me.Input_AvisoSaldoFolios.MaxValue = 50
        Me.Input_AvisoSaldoFolios.MinValue = 5
        Me.Input_AvisoSaldoFolios.Name = "Input_AvisoSaldoFolios"
        Me.Input_AvisoSaldoFolios.ShowUpDown = True
        Me.Input_AvisoSaldoFolios.Size = New System.Drawing.Size(66, 22)
        Me.Input_AvisoSaldoFolios.TabIndex = 101
        Me.Input_AvisoSaldoFolios.Value = 10
        '
        'Lbl_DiasAvisoExpiraFolio
        '
        Me.Lbl_DiasAvisoExpiraFolio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_DiasAvisoExpiraFolio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_DiasAvisoExpiraFolio.ForeColor = System.Drawing.Color.Black
        Me.Lbl_DiasAvisoExpiraFolio.Location = New System.Drawing.Point(98, 452)
        Me.Lbl_DiasAvisoExpiraFolio.Name = "Lbl_DiasAvisoExpiraFolio"
        Me.Lbl_DiasAvisoExpiraFolio.Size = New System.Drawing.Size(248, 20)
        Me.Lbl_DiasAvisoExpiraFolio.TabIndex = 100
        Me.Lbl_DiasAvisoExpiraFolio.Text = "Días de aviso para que expiren los folios DTE."
        '
        'Txt_NombreFormato_Correo
        '
        Me.Txt_NombreFormato_Correo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_Correo.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_Correo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_Correo.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato_Correo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Correo.ButtonCustom.Visible = True
        Me.Txt_NombreFormato_Correo.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato_Correo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Correo.ButtonCustom2.Visible = True
        Me.Txt_NombreFormato_Correo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_Correo.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_Correo.Location = New System.Drawing.Point(112, 376)
        Me.Txt_NombreFormato_Correo.Name = "Txt_NombreFormato_Correo"
        Me.Txt_NombreFormato_Correo.PreventEnterBeep = True
        Me.Txt_NombreFormato_Correo.ReadOnly = True
        Me.Txt_NombreFormato_Correo.Size = New System.Drawing.Size(425, 22)
        Me.Txt_NombreFormato_Correo.TabIndex = 23
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(6, 373)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(100, 20)
        Me.LabelX14.TabIndex = 22
        Me.LabelX14.Text = "For. Adjunto"
        '
        'Txt_Id_Correo
        '
        Me.Txt_Id_Correo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Id_Correo.Border.Class = "TextBoxBorder"
        Me.Txt_Id_Correo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Id_Correo.ButtonCustom.Image = CType(resources.GetObject("Txt_Id_Correo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Id_Correo.ButtonCustom.Visible = True
        Me.Txt_Id_Correo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Id_Correo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Id_Correo.ButtonCustom2.Visible = True
        Me.Txt_Id_Correo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Id_Correo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Id_Correo.Location = New System.Drawing.Point(111, 348)
        Me.Txt_Id_Correo.Name = "Txt_Id_Correo"
        Me.Txt_Id_Correo.PreventEnterBeep = True
        Me.Txt_Id_Correo.ReadOnly = True
        Me.Txt_Id_Correo.Size = New System.Drawing.Size(426, 22)
        Me.Txt_Id_Correo.TabIndex = 22
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 347)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(100, 20)
        Me.LabelX5.TabIndex = 21
        Me.LabelX5.Text = "Correo por defecto"
        '
        'Input_DiasAvisoExpiraFolio
        '
        '
        '
        '
        Me.Input_DiasAvisoExpiraFolio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_DiasAvisoExpiraFolio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_DiasAvisoExpiraFolio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_DiasAvisoExpiraFolio.ForeColor = System.Drawing.Color.Black
        Me.Input_DiasAvisoExpiraFolio.Location = New System.Drawing.Point(6, 452)
        Me.Input_DiasAvisoExpiraFolio.MaxValue = 30
        Me.Input_DiasAvisoExpiraFolio.MinValue = 5
        Me.Input_DiasAvisoExpiraFolio.Name = "Input_DiasAvisoExpiraFolio"
        Me.Input_DiasAvisoExpiraFolio.ShowUpDown = True
        Me.Input_DiasAvisoExpiraFolio.Size = New System.Drawing.Size(66, 22)
        Me.Input_DiasAvisoExpiraFolio.TabIndex = 100
        Me.Input_DiasAvisoExpiraFolio.Value = 14
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 60)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(240, 23)
        Me.LabelX7.TabIndex = 8
        Me.LabelX7.Text = "Formatos para salidas de impresión"
        '
        'Txt_Numero
        '
        Me.Txt_Numero.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Numero.Border.Class = "TextBoxBorder"
        Me.Txt_Numero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Numero.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Numero.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Numero.ForeColor = System.Drawing.Color.Black
        Me.Txt_Numero.Location = New System.Drawing.Point(98, 32)
        Me.Txt_Numero.Name = "Txt_Numero"
        Me.Txt_Numero.PreventEnterBeep = True
        Me.Txt_Numero.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Numero.TabIndex = 3
        Me.Txt_Numero.Text = "WCM0000000"
        Me.Txt_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Numeración"
        '
        'Lbl_Tipo
        '
        Me.Lbl_Tipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo.Location = New System.Drawing.Point(98, 3)
        Me.Lbl_Tipo.Name = "Lbl_Tipo"
        Me.Lbl_Tipo.Size = New System.Drawing.Size(344, 23)
        Me.Lbl_Tipo.TabIndex = 1
        Me.Lbl_Tipo.Text = "FCV - FACTURA DE VENTA"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Tipo documento"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 574)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(584, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 98
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Chk_Guarda_PDF_Auto
        '
        Me.Chk_Guarda_PDF_Auto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Guarda_PDF_Auto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Guarda_PDF_Auto.CheckBoxImageChecked = CType(resources.GetObject("Chk_Guarda_PDF_Auto.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Guarda_PDF_Auto.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Guarda_PDF_Auto.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Guarda_PDF_Auto.FocusCuesEnabled = False
        Me.Chk_Guarda_PDF_Auto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Guarda_PDF_Auto.Location = New System.Drawing.Point(6, 147)
        Me.Chk_Guarda_PDF_Auto.Name = "Chk_Guarda_PDF_Auto"
        Me.Chk_Guarda_PDF_Auto.Size = New System.Drawing.Size(172, 18)
        Me.Chk_Guarda_PDF_Auto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Guarda_PDF_Auto.TabIndex = 131
        Me.Chk_Guarda_PDF_Auto.Text = "Graba PDF automáticamente"
        '
        'Chk_Grabar_Con_Huella
        '
        Me.Chk_Grabar_Con_Huella.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Grabar_Con_Huella.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Grabar_Con_Huella.CheckBoxImageChecked = CType(resources.GetObject("Chk_Grabar_Con_Huella.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Grabar_Con_Huella.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Grabar_Con_Huella.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Grabar_Con_Huella.FocusCuesEnabled = False
        Me.Chk_Grabar_Con_Huella.ForeColor = System.Drawing.Color.Black
        Me.Chk_Grabar_Con_Huella.Location = New System.Drawing.Point(6, 171)
        Me.Chk_Grabar_Con_Huella.Name = "Chk_Grabar_Con_Huella"
        Me.Chk_Grabar_Con_Huella.Size = New System.Drawing.Size(252, 18)
        Me.Chk_Grabar_Con_Huella.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Grabar_Con_Huella.TabIndex = 132
        Me.Chk_Grabar_Con_Huella.Text = "Obliga a grabar documento con huella digital"
        '
        'Chk_Obliga_Despacho
        '
        Me.Chk_Obliga_Despacho.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Obliga_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Obliga_Despacho.CheckBoxImageChecked = CType(resources.GetObject("Chk_Obliga_Despacho.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Obliga_Despacho.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Obliga_Despacho.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Obliga_Despacho.FocusCuesEnabled = False
        Me.Chk_Obliga_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Chk_Obliga_Despacho.Location = New System.Drawing.Point(6, 195)
        Me.Chk_Obliga_Despacho.Name = "Chk_Obliga_Despacho"
        Me.Chk_Obliga_Despacho.Size = New System.Drawing.Size(162, 18)
        Me.Chk_Obliga_Despacho.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Obliga_Despacho.TabIndex = 133
        Me.Chk_Obliga_Despacho.Text = "Obliga a grabar despacho"
        '
        'Chk_Sugiere_Despacho
        '
        Me.Chk_Sugiere_Despacho.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sugiere_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sugiere_Despacho.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sugiere_Despacho.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sugiere_Despacho.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Sugiere_Despacho.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Sugiere_Despacho.FocusCuesEnabled = False
        Me.Chk_Sugiere_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sugiere_Despacho.Location = New System.Drawing.Point(6, 219)
        Me.Chk_Sugiere_Despacho.Name = "Chk_Sugiere_Despacho"
        Me.Chk_Sugiere_Despacho.Size = New System.Drawing.Size(149, 18)
        Me.Chk_Sugiere_Despacho.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sugiere_Despacho.TabIndex = 134
        Me.Chk_Sugiere_Despacho.Text = "Sugiere grabar despacho"
        '
        'Chk_Obliga_Despacho_BodDistintas
        '
        Me.Chk_Obliga_Despacho_BodDistintas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Obliga_Despacho_BodDistintas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Obliga_Despacho_BodDistintas.CheckBoxImageChecked = CType(resources.GetObject("Chk_Obliga_Despacho_BodDistintas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Obliga_Despacho_BodDistintas.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Obliga_Despacho_BodDistintas.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Obliga_Despacho_BodDistintas.FocusCuesEnabled = False
        Me.Chk_Obliga_Despacho_BodDistintas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Obliga_Despacho_BodDistintas.Location = New System.Drawing.Point(6, 243)
        Me.Chk_Obliga_Despacho_BodDistintas.Name = "Chk_Obliga_Despacho_BodDistintas"
        Me.Chk_Obliga_Despacho_BodDistintas.Size = New System.Drawing.Size(425, 18)
        Me.Chk_Obliga_Despacho_BodDistintas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Obliga_Despacho_BodDistintas.TabIndex = 135
        Me.Chk_Obliga_Despacho_BodDistintas.Text = "Obliga grabar despacho cuando hay bodegas distintas en el detalle del documento"
        '
        'Chk_Obliga_Transportista
        '
        Me.Chk_Obliga_Transportista.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Obliga_Transportista.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Obliga_Transportista.CheckBoxImageChecked = CType(resources.GetObject("Chk_Obliga_Transportista.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Obliga_Transportista.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Obliga_Transportista.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Obliga_Transportista.FocusCuesEnabled = False
        Me.Chk_Obliga_Transportista.ForeColor = System.Drawing.Color.Black
        Me.Chk_Obliga_Transportista.Location = New System.Drawing.Point(6, 267)
        Me.Chk_Obliga_Transportista.Name = "Chk_Obliga_Transportista"
        Me.Chk_Obliga_Transportista.Size = New System.Drawing.Size(172, 18)
        Me.Chk_Obliga_Transportista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Obliga_Transportista.TabIndex = 136
        Me.Chk_Obliga_Transportista.Text = "Obliga a ingresar transportista"
        '
        'Chk_Enviar_Correo
        '
        Me.Chk_Enviar_Correo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Enviar_Correo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Enviar_Correo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Enviar_Correo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Enviar_Correo.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Enviar_Correo.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Enviar_Correo.FocusCuesEnabled = False
        Me.Chk_Enviar_Correo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Enviar_Correo.Location = New System.Drawing.Point(6, 291)
        Me.Chk_Enviar_Correo.Name = "Chk_Enviar_Correo"
        Me.Chk_Enviar_Correo.Size = New System.Drawing.Size(252, 18)
        Me.Chk_Enviar_Correo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Enviar_Correo.TabIndex = 137
        Me.Chk_Enviar_Correo.Text = "Enviar correos despues de grabar documento"
        '
        'Rdb_TimbrarXRandom
        '
        Me.Rdb_TimbrarXRandom.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_TimbrarXRandom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_TimbrarXRandom.CheckBoxImageChecked = CType(resources.GetObject("Rdb_TimbrarXRandom.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_TimbrarXRandom.CheckBoxImageIndeterminate = CType(resources.GetObject("Rdb_TimbrarXRandom.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Rdb_TimbrarXRandom.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_TimbrarXRandom.FocusCuesEnabled = False
        Me.Rdb_TimbrarXRandom.ForeColor = System.Drawing.Color.Black
        Me.Rdb_TimbrarXRandom.Location = New System.Drawing.Point(6, 404)
        Me.Rdb_TimbrarXRandom.Name = "Rdb_TimbrarXRandom"
        Me.Rdb_TimbrarXRandom.Size = New System.Drawing.Size(212, 18)
        Me.Rdb_TimbrarXRandom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_TimbrarXRandom.TabIndex = 138
        Me.Rdb_TimbrarXRandom.Text = "Timbrar electrónicamente por Random"
        '
        'Rdb_TimbrarXBakapp
        '
        Me.Rdb_TimbrarXBakapp.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_TimbrarXBakapp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_TimbrarXBakapp.CheckBoxImageChecked = CType(resources.GetObject("Rdb_TimbrarXBakapp.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_TimbrarXBakapp.CheckBoxImageIndeterminate = CType(resources.GetObject("Rdb_TimbrarXBakapp.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Rdb_TimbrarXBakapp.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_TimbrarXBakapp.Checked = True
        Me.Rdb_TimbrarXBakapp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_TimbrarXBakapp.CheckValue = "Y"
        Me.Rdb_TimbrarXBakapp.FocusCuesEnabled = False
        Me.Rdb_TimbrarXBakapp.ForeColor = System.Drawing.Color.Black
        Me.Rdb_TimbrarXBakapp.Location = New System.Drawing.Point(6, 428)
        Me.Rdb_TimbrarXBakapp.Name = "Rdb_TimbrarXBakapp"
        Me.Rdb_TimbrarXBakapp.Size = New System.Drawing.Size(212, 18)
        Me.Rdb_TimbrarXBakapp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_TimbrarXBakapp.TabIndex = 139
        Me.Rdb_TimbrarXBakapp.Text = "Timbrar electrónicamente por Bakapp"
        '
        'Chk_Deshabilitar_ObsAdicionales
        '
        Me.Chk_Deshabilitar_ObsAdicionales.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Deshabilitar_ObsAdicionales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Deshabilitar_ObsAdicionales.CheckBoxImageChecked = CType(resources.GetObject("Chk_Deshabilitar_ObsAdicionales.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Deshabilitar_ObsAdicionales.CheckBoxImageIndeterminate = CType(resources.GetObject("Chk_Deshabilitar_ObsAdicionales.CheckBoxImageIndeterminate"), System.Drawing.Image)
        Me.Chk_Deshabilitar_ObsAdicionales.FocusCuesEnabled = False
        Me.Chk_Deshabilitar_ObsAdicionales.ForeColor = System.Drawing.Color.Black
        Me.Chk_Deshabilitar_ObsAdicionales.Location = New System.Drawing.Point(6, 315)
        Me.Chk_Deshabilitar_ObsAdicionales.Name = "Chk_Deshabilitar_ObsAdicionales"
        Me.Chk_Deshabilitar_ObsAdicionales.Size = New System.Drawing.Size(301, 18)
        Me.Chk_Deshabilitar_ObsAdicionales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Deshabilitar_ObsAdicionales.TabIndex = 140
        Me.Chk_Deshabilitar_ObsAdicionales.Text = "Deshabilitar observaciones adicionales en documento."
        '
        'Frm_ConfTidoXModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 615)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConfTidoXModal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento FACTURA DE VENTA Modalidad MODAL"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Input_AvisoSaldoFolios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_DiasAvisoExpiraFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Tipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Numero As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_InfNumeracion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_NombreFormato_PDF As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Nombreformato As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreFormato_Correo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Id_Correo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_DiasAvisoExpiraFolio As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_DiasAvisoExpiraFolio As DevComponents.Editors.IntegerInput
    Friend WithEvents Lbl_AvisoSaldoFolios As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_AvisoSaldoFolios As DevComponents.Editors.IntegerInput
    Friend WithEvents Txt_ListaPrecioDoc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_ListaPrecioDoc As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Guarda_PDF_Auto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Grabar_Con_Huella As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Obliga_Despacho As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Sugiere_Despacho As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Obliga_Despacho_BodDistintas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Enviar_Correo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Obliga_Transportista As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_TimbrarXRandom As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_TimbrarXBakapp As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Deshabilitar_ObsAdicionales As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
