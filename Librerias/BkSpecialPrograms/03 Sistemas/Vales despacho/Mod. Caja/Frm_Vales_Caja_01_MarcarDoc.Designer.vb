<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vales_Caja_01_MarcarDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vales_Caja_01_MarcarDoc))
        Me.TxtNroDocumento = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.BtnBuscar = New DevComponents.DotNetBar.ButtonX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnMarcarDocumento = New DevComponents.DotNetBar.ButtonItem
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.LblTotalBruto = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Direccion = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Entidad = New DevComponents.DotNetBar.LabelX
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmbTipoDoc = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Btn_NominarBoleta = New DevComponents.DotNetBar.ButtonX
        Me.LayoutGroup1 = New DevComponents.DotNetBar.Layout.LayoutGroup
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem
        Me.LayoutSpacerItem3 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem
        Me.LayoutSpacerItem2 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem
        Me.LayoutGroup3 = New DevComponents.DotNetBar.Layout.LayoutGroup
        Me.LayoutGroup2 = New DevComponents.DotNetBar.Layout.LayoutGroup
        Me.Rdb_RetiraCliente = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Rdb_DespachoDomicilio = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtFono_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Link_PersonaContacto = New System.Windows.Forms.LinkLabel
        Me.TxtHora_Recibe = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtPersona_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.Btn_DireccionDespacho = New DevComponents.DotNetBar.ButtonX
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNroDocumento
        '
        Me.TxtNroDocumento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNroDocumento.Border.Class = "TextBoxBorder"
        Me.TxtNroDocumento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNroDocumento.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNroDocumento.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroDocumento.ForeColor = System.Drawing.Color.Black
        Me.TxtNroDocumento.Location = New System.Drawing.Point(182, 21)
        Me.TxtNroDocumento.MaxLength = 10
        Me.TxtNroDocumento.Name = "TxtNroDocumento"
        Me.TxtNroDocumento.PreventEnterBeep = True
        Me.TxtNroDocumento.Size = New System.Drawing.Size(178, 35)
        Me.TxtNroDocumento.TabIndex = 80
        Me.TxtNroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnBuscar
        '
        Me.BtnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.Location = New System.Drawing.Point(366, 21)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(86, 35)
        Me.BtnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscar.TabIndex = 81
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.Tooltip = "Buscar documento"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnMarcarDocumento, Me.BtnLimpiar, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 506)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(477, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 47
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnMarcarDocumento
        '
        Me.BtnMarcarDocumento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnMarcarDocumento.ForeColor = System.Drawing.Color.Black
        Me.BtnMarcarDocumento.Image = CType(resources.GetObject("BtnMarcarDocumento.Image"), System.Drawing.Image)
        Me.BtnMarcarDocumento.Name = "BtnMarcarDocumento"
        Me.BtnMarcarDocumento.Text = "Marcar documento"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Tooltip = "Limpiar, buscar nuevo documento"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'LblTotalBruto
        '
        Me.LblTotalBruto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblTotalBruto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotalBruto.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalBruto.ForeColor = System.Drawing.Color.Black
        Me.LblTotalBruto.Location = New System.Drawing.Point(91, 79)
        Me.LblTotalBruto.Name = "LblTotalBruto"
        Me.LblTotalBruto.Size = New System.Drawing.Size(132, 23)
        Me.LblTotalBruto.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LblTotalBruto.TabIndex = 84
        Me.LblTotalBruto.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(5, 79)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(80, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 81
        Me.LabelX3.Text = "TOTAL"
        '
        'Lbl_Direccion
        '
        Me.Lbl_Direccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Lbl_Direccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Direccion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Direccion.Location = New System.Drawing.Point(6, 50)
        Me.Lbl_Direccion.Name = "Lbl_Direccion"
        Me.Lbl_Direccion.Size = New System.Drawing.Size(446, 23)
        Me.Lbl_Direccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Direccion.TabIndex = 80
        Me.Lbl_Direccion.Text = "DIRECCION"
        '
        'Lbl_Entidad
        '
        Me.Lbl_Entidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Lbl_Entidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Entidad.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Entidad.Location = New System.Drawing.Point(6, 21)
        Me.Lbl_Entidad.Name = "Lbl_Entidad"
        Me.Lbl_Entidad.Size = New System.Drawing.Size(399, 23)
        Me.Lbl_Entidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Entidad.TabIndex = 79
        Me.Lbl_Entidad.Text = "ENTIDAD"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.CmbTipoDoc)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.TxtNroDocumento)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 73)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar documento"
        '
        'CmbTipoDoc
        '
        Me.CmbTipoDoc.DisplayMember = "Text"
        Me.CmbTipoDoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipoDoc.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbTipoDoc.FocusHighlightEnabled = True
        Me.CmbTipoDoc.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipoDoc.ForeColor = System.Drawing.Color.Black
        Me.CmbTipoDoc.ItemHeight = 29
        Me.CmbTipoDoc.Location = New System.Drawing.Point(13, 21)
        Me.CmbTipoDoc.Name = "CmbTipoDoc"
        Me.CmbTipoDoc.Size = New System.Drawing.Size(158, 35)
        Me.CmbTipoDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.CmbTipoDoc.TabIndex = 82
        Me.CmbTipoDoc.Text = "BOLETA"
        Me.CmbTipoDoc.WatermarkText = "Tipo de entidad"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Btn_NominarBoleta)
        Me.GroupBox2.Controls.Add(Me.LblTotalBruto)
        Me.GroupBox2.Controls.Add(Me.Lbl_Entidad)
        Me.GroupBox2.Controls.Add(Me.Lbl_Direccion)
        Me.GroupBox2.Controls.Add(Me.LabelX3)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(8, 139)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 108)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de la entidad del documento"
        '
        'Btn_NominarBoleta
        '
        Me.Btn_NominarBoleta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_NominarBoleta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_NominarBoleta.Image = CType(resources.GetObject("Btn_NominarBoleta.Image"), System.Drawing.Image)
        Me.Btn_NominarBoleta.Location = New System.Drawing.Point(411, 21)
        Me.Btn_NominarBoleta.Name = "Btn_NominarBoleta"
        Me.Btn_NominarBoleta.Size = New System.Drawing.Size(41, 23)
        Me.Btn_NominarBoleta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_NominarBoleta.TabIndex = 85
        Me.Btn_NominarBoleta.Tooltip = "NOMINAR BOLETA"
        '
        'LayoutGroup1
        '
        Me.LayoutGroup1.Height = 100
        Me.LayoutGroup1.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutSpacerItem1, Me.LayoutSpacerItem3, Me.LayoutSpacerItem2, Me.LayoutGroup3})
        Me.LayoutGroup1.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup1.Name = "LayoutGroup1"
        Me.LayoutGroup1.Width = 200
        '
        'LayoutSpacerItem1
        '
        Me.LayoutSpacerItem1.Height = 32
        Me.LayoutSpacerItem1.Name = "LayoutSpacerItem1"
        Me.LayoutSpacerItem1.Width = 32
        '
        'LayoutSpacerItem3
        '
        Me.LayoutSpacerItem3.Height = 32
        Me.LayoutSpacerItem3.Name = "LayoutSpacerItem3"
        Me.LayoutSpacerItem3.Width = 32
        '
        'LayoutSpacerItem2
        '
        Me.LayoutSpacerItem2.Height = 32
        Me.LayoutSpacerItem2.Name = "LayoutSpacerItem2"
        Me.LayoutSpacerItem2.Width = 32
        '
        'LayoutGroup3
        '
        Me.LayoutGroup3.Height = 100
        Me.LayoutGroup3.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup3.Name = "LayoutGroup3"
        Me.LayoutGroup3.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup3.Width = 200
        '
        'LayoutGroup2
        '
        Me.LayoutGroup2.Height = 100
        Me.LayoutGroup2.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup2.Name = "LayoutGroup2"
        Me.LayoutGroup2.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup2.Width = 200
        '
        'Rdb_RetiraCliente
        '
        Me.Rdb_RetiraCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Rdb_RetiraCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_RetiraCliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_RetiraCliente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_RetiraCliente.Location = New System.Drawing.Point(6, 21)
        Me.Rdb_RetiraCliente.Name = "Rdb_RetiraCliente"
        Me.Rdb_RetiraCliente.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_RetiraCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_RetiraCliente.TabIndex = 51
        Me.Rdb_RetiraCliente.Text = "RETIRA CLIENTE"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Rdb_DespachoDomicilio)
        Me.GroupBox3.Controls.Add(Me.Rdb_RetiraCliente)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(8, 81)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(458, 52)
        Me.GroupBox3.TabIndex = 52
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Acción"
        '
        'Rdb_DespachoDomicilio
        '
        Me.Rdb_DespachoDomicilio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Rdb_DespachoDomicilio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_DespachoDomicilio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_DespachoDomicilio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_DespachoDomicilio.Location = New System.Drawing.Point(224, 21)
        Me.Rdb_DespachoDomicilio.Name = "Rdb_DespachoDomicilio"
        Me.Rdb_DespachoDomicilio.Size = New System.Drawing.Size(228, 23)
        Me.Rdb_DespachoDomicilio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_DespachoDomicilio.TabIndex = 52
        Me.Rdb_DespachoDomicilio.Text = "DESPACHO A DOMICILIO"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox4.Controls.Add(Me.TxtFono_Contacto)
        Me.GroupBox4.Controls.Add(Me.LabelX2)
        Me.GroupBox4.Controls.Add(Me.Link_PersonaContacto)
        Me.GroupBox4.Controls.Add(Me.TxtHora_Recibe)
        Me.GroupBox4.Controls.Add(Me.TxtPersona_Contacto)
        Me.GroupBox4.Controls.Add(Me.LabelX5)
        Me.GroupBox4.Controls.Add(Me.Btn_DireccionDespacho)
        Me.GroupBox4.Controls.Add(Me.ComboBoxEx1)
        Me.GroupBox4.Controls.Add(Me.LabelX1)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(8, 253)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(458, 237)
        Me.GroupBox4.TabIndex = 53
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Dirección de despacho"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtObservaciones.Border.Class = "TextBoxBorder"
        Me.TxtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservaciones.DisabledBackColor = System.Drawing.Color.White
        Me.TxtObservaciones.FocusHighlightEnabled = True
        Me.TxtObservaciones.ForeColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Location = New System.Drawing.Point(8, 152)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.PreventEnterBeep = True
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(444, 77)
        Me.TxtObservaciones.TabIndex = 3
        '
        'TxtFono_Contacto
        '
        Me.TxtFono_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtFono_Contacto.Border.Class = "TextBoxBorder"
        Me.TxtFono_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFono_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFono_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.TxtFono_Contacto.FocusHighlightEnabled = True
        Me.TxtFono_Contacto.ForeColor = System.Drawing.Color.Black
        Me.TxtFono_Contacto.Location = New System.Drawing.Point(304, 71)
        Me.TxtFono_Contacto.Name = "TxtFono_Contacto"
        Me.TxtFono_Contacto.PreventEnterBeep = True
        Me.TxtFono_Contacto.Size = New System.Drawing.Size(148, 22)
        Me.TxtFono_Contacto.TabIndex = 1
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(304, 51)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(153, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 89
        Me.LabelX2.Text = "Teléfono (Contacto)"
        '
        'Link_PersonaContacto
        '
        Me.Link_PersonaContacto.AutoSize = True
        Me.Link_PersonaContacto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Link_PersonaContacto.ForeColor = System.Drawing.Color.Black
        Me.Link_PersonaContacto.Location = New System.Drawing.Point(6, 55)
        Me.Link_PersonaContacto.Name = "Link_PersonaContacto"
        Me.Link_PersonaContacto.Size = New System.Drawing.Size(116, 13)
        Me.Link_PersonaContacto.TabIndex = 88
        Me.Link_PersonaContacto.TabStop = True
        Me.Link_PersonaContacto.Text = "PERSONA CONTACTO"
        '
        'TxtHora_Recibe
        '
        Me.TxtHora_Recibe.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtHora_Recibe.Border.Class = "TextBoxBorder"
        Me.TxtHora_Recibe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtHora_Recibe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHora_Recibe.DisabledBackColor = System.Drawing.Color.White
        Me.TxtHora_Recibe.FocusHighlightEnabled = True
        Me.TxtHora_Recibe.ForeColor = System.Drawing.Color.Black
        Me.TxtHora_Recibe.Location = New System.Drawing.Point(8, 111)
        Me.TxtHora_Recibe.Name = "TxtHora_Recibe"
        Me.TxtHora_Recibe.PreventEnterBeep = True
        Me.TxtHora_Recibe.Size = New System.Drawing.Size(444, 22)
        Me.TxtHora_Recibe.TabIndex = 2
        '
        'TxtPersona_Contacto
        '
        Me.TxtPersona_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtPersona_Contacto.Border.Class = "TextBoxBorder"
        Me.TxtPersona_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPersona_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPersona_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.TxtPersona_Contacto.FocusHighlightEnabled = True
        Me.TxtPersona_Contacto.ForeColor = System.Drawing.Color.Black
        Me.TxtPersona_Contacto.Location = New System.Drawing.Point(6, 71)
        Me.TxtPersona_Contacto.Name = "TxtPersona_Contacto"
        Me.TxtPersona_Contacto.PreventEnterBeep = True
        Me.TxtPersona_Contacto.Size = New System.Drawing.Size(292, 22)
        Me.TxtPersona_Contacto.TabIndex = 0
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(8, 130)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(361, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 90
        Me.LabelX5.Text = "Observaciones generales/calles de referencia"
        '
        'Btn_DireccionDespacho
        '
        Me.Btn_DireccionDespacho.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_DireccionDespacho.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_DireccionDespacho.Image = CType(resources.GetObject("Btn_DireccionDespacho.Image"), System.Drawing.Image)
        Me.Btn_DireccionDespacho.Location = New System.Drawing.Point(411, 20)
        Me.Btn_DireccionDespacho.Name = "Btn_DireccionDespacho"
        Me.Btn_DireccionDespacho.Size = New System.Drawing.Size(41, 23)
        Me.Btn_DireccionDespacho.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_DireccionDespacho.TabIndex = 1
        Me.Btn_DireccionDespacho.Tooltip = "EDITAR DATOS DE DESPACHO"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 16
        Me.ComboBoxEx1.Location = New System.Drawing.Point(5, 21)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(400, 22)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(8, 91)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(153, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 87
        Me.LabelX1.Text = "Horario"
        '
        'Frm_Vales_Caja_01_MarcarDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Vales_Caja_01_MarcarDoc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcar documento"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtNroDocumento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Direccion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Entidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblTotalBruto As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnMarcarDocumento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CmbTipoDoc As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LayoutGroup1 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutSpacerItem1 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem3 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem2 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutGroup3 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutGroup2 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents Rdb_RetiraCliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_DespachoDomicilio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_DireccionDespacho As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtFono_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Link_PersonaContacto As System.Windows.Forms.LinkLabel
    Public WithEvents TxtHora_Recibe As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtPersona_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_NominarBoleta As DevComponents.DotNetBar.ButtonX
End Class
