<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PreciosLC_Mt01
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PreciosLC_Mt01))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnBuscarProducto = New DevComponents.DotNetBar.ButtonX()
        Me.Txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GrillaProducto = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Btndimensiones = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.TxtMcostoOld = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TxtFlete1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TxtNetoPropuesto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtBrutoPropuesto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtPrecioDigitado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMargenDigitado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GrillaPrecios = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarFormulasDeValoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MargeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarFormulasDeEcuacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Btn_Grabar_Flete = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtFlete2 = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GrillaRecargos = New System.Windows.Forms.DataGridView()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSimular = New DevComponents.DotNetBar.ButtonItem()
        Me.Btnimprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnFormulas = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnFormulasListas = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.CmmdFxPrecios = New DevComponents.DotNetBar.Command(Me.components)
        Me.CmmdFxRangos = New DevComponents.DotNetBar.Command(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtRango1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtRango2 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Btn_RecalcularPPP = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GrillaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GrillaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.GrillaRecargos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.BtnBuscarProducto)
        Me.GroupBox2.Controls.Add(Me.Txtcodigo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(759, 132)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto"
        '
        'BtnBuscarProducto
        '
        Me.BtnBuscarProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscarProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscarProducto.Image = Global.BkSpecialPrograms.My.Resources.Resources.search2
        Me.BtnBuscarProducto.Location = New System.Drawing.Point(193, 19)
        Me.BtnBuscarProducto.Name = "BtnBuscarProducto"
        Me.BtnBuscarProducto.Size = New System.Drawing.Size(125, 23)
        Me.BtnBuscarProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscarProducto.TabIndex = 0
        Me.BtnBuscarProducto.Text = "Buscar producto..."
        '
        'Txtcodigo
        '
        Me.Txtcodigo.BackColor = System.Drawing.Color.White
        Me.Txtcodigo.ForeColor = System.Drawing.Color.Black
        Me.Txtcodigo.Location = New System.Drawing.Point(55, 19)
        Me.Txtcodigo.Name = "Txtcodigo"
        Me.Txtcodigo.Size = New System.Drawing.Size(127, 22)
        Me.Txtcodigo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.GrillaProducto)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(745, 80)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información del producto"
        '
        'GrillaProducto
        '
        Me.GrillaProducto.AllowUserToAddRows = False
        Me.GrillaProducto.AllowUserToDeleteRows = False
        Me.GrillaProducto.BackgroundColor = System.Drawing.Color.White
        Me.GrillaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaProducto.Location = New System.Drawing.Point(3, 18)
        Me.GrillaProducto.Name = "GrillaProducto"
        Me.GrillaProducto.ReadOnly = True
        Me.GrillaProducto.Size = New System.Drawing.Size(739, 59)
        Me.GrillaProducto.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(3, 152)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(759, 424)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox12)
        Me.TabPage1.Controls.Add(Me.GroupBox11)
        Me.TabPage1.Controls.Add(Me.GroupBox10)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.ForeColor = System.Drawing.Color.Black
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(751, 398)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Calculo de precios"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Btndimensiones)
        Me.GroupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.ForeColor = System.Drawing.Color.Black
        Me.GroupBox12.Location = New System.Drawing.Point(600, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(148, 70)
        Me.GroupBox12.TabIndex = 18
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Variables"
        '
        'Btndimensiones
        '
        Me.Btndimensiones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btndimensiones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btndimensiones.Location = New System.Drawing.Point(6, 25)
        Me.Btndimensiones.Name = "Btndimensiones"
        Me.Btndimensiones.Size = New System.Drawing.Size(136, 39)
        Me.Btndimensiones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btndimensiones.TabIndex = 1
        Me.Btndimensiones.Text = "Dimensiones"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.DataGridView1)
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(4, 303)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(742, 88)
        Me.GroupBox11.TabIndex = 17
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Formular de la lista"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 18)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(736, 67)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.TxtMcostoOld)
        Me.GroupBox10.Controls.Add(Me.Label7)
        Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.ForeColor = System.Drawing.Color.Black
        Me.GroupBox10.Location = New System.Drawing.Point(395, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(110, 70)
        Me.GroupBox10.TabIndex = 16
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Archivo"
        '
        'TxtMcostoOld
        '
        Me.TxtMcostoOld.BackColor = System.Drawing.Color.White
        Me.TxtMcostoOld.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMcostoOld.ForeColor = System.Drawing.Color.Black
        Me.TxtMcostoOld.Location = New System.Drawing.Point(9, 41)
        Me.TxtMcostoOld.Name = "TxtMcostoOld"
        Me.TxtMcostoOld.ReadOnly = True
        Me.TxtMcostoOld.Size = New System.Drawing.Size(91, 22)
        Me.TxtMcostoOld.TabIndex = 7
        Me.TxtMcostoOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Ult. M. Costo $"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TxtFlete1)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(511, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(83, 70)
        Me.GroupBox7.TabIndex = 15
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Recargos"
        '
        'TxtFlete1
        '
        Me.TxtFlete1.BackColor = System.Drawing.Color.White
        Me.TxtFlete1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFlete1.ForeColor = System.Drawing.Color.Black
        Me.TxtFlete1.Location = New System.Drawing.Point(9, 40)
        Me.TxtFlete1.Name = "TxtFlete1"
        Me.TxtFlete1.ReadOnly = True
        Me.TxtFlete1.Size = New System.Drawing.Size(62, 22)
        Me.TxtFlete1.TabIndex = 11
        Me.TxtFlete1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Flete $"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TxtNetoPropuesto)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.TxtBrutoPropuesto)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(208, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(181, 70)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Valores propuestos"
        '
        'TxtNetoPropuesto
        '
        Me.TxtNetoPropuesto.BackColor = System.Drawing.Color.White
        Me.TxtNetoPropuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetoPropuesto.ForeColor = System.Drawing.Color.Black
        Me.TxtNetoPropuesto.Location = New System.Drawing.Point(12, 40)
        Me.TxtNetoPropuesto.Name = "TxtNetoPropuesto"
        Me.TxtNetoPropuesto.ReadOnly = True
        Me.TxtNetoPropuesto.Size = New System.Drawing.Size(72, 22)
        Me.TxtNetoPropuesto.TabIndex = 5
        Me.TxtNetoPropuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Neto $"
        '
        'TxtBrutoPropuesto
        '
        Me.TxtBrutoPropuesto.BackColor = System.Drawing.Color.White
        Me.TxtBrutoPropuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBrutoPropuesto.ForeColor = System.Drawing.Color.Black
        Me.TxtBrutoPropuesto.Location = New System.Drawing.Point(101, 40)
        Me.TxtBrutoPropuesto.Name = "TxtBrutoPropuesto"
        Me.TxtBrutoPropuesto.ReadOnly = True
        Me.TxtBrutoPropuesto.Size = New System.Drawing.Size(72, 22)
        Me.TxtBrutoPropuesto.TabIndex = 3
        Me.TxtBrutoPropuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(98, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Bruto $"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtPrecioDigitado)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.TxtMargenDigitado)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(196, 70)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Variables"
        '
        'TxtPrecioDigitado
        '
        Me.TxtPrecioDigitado.BackColor = System.Drawing.Color.White
        Me.TxtPrecioDigitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecioDigitado.ForeColor = System.Drawing.Color.Black
        Me.TxtPrecioDigitado.Location = New System.Drawing.Point(92, 40)
        Me.TxtPrecioDigitado.Name = "TxtPrecioDigitado"
        Me.TxtPrecioDigitado.Size = New System.Drawing.Size(94, 22)
        Me.TxtPrecioDigitado.TabIndex = 3
        Me.TxtPrecioDigitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(89, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Precio final $"
        '
        'TxtMargenDigitado
        '
        Me.TxtMargenDigitado.BackColor = System.Drawing.Color.White
        Me.TxtMargenDigitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMargenDigitado.ForeColor = System.Drawing.Color.Black
        Me.TxtMargenDigitado.Location = New System.Drawing.Point(7, 39)
        Me.TxtMargenDigitado.Name = "TxtMargenDigitado"
        Me.TxtMargenDigitado.Size = New System.Drawing.Size(66, 22)
        Me.TxtMargenDigitado.TabIndex = 1
        Me.TxtMargenDigitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Margen %"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GrillaPrecios)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(6, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(742, 215)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listas de precios"
        '
        'GrillaPrecios
        '
        Me.GrillaPrecios.AllowUserToAddRows = False
        Me.GrillaPrecios.AllowUserToDeleteRows = False
        Me.GrillaPrecios.BackgroundColor = System.Drawing.Color.White
        Me.GrillaPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaPrecios.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GrillaPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaPrecios.Location = New System.Drawing.Point(3, 18)
        Me.GrillaPrecios.Name = "GrillaPrecios"
        Me.GrillaPrecios.Size = New System.Drawing.Size(736, 194)
        Me.GrillaPrecios.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarFormulasDeValoresToolStripMenuItem, Me.MargeToolStripMenuItem, Me.EditarFormulasDeEcuacionesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(134, 70)
        '
        'EditarFormulasDeValoresToolStripMenuItem
        '
        Me.EditarFormulasDeValoresToolStripMenuItem.Name = "EditarFormulasDeValoresToolStripMenuItem"
        Me.EditarFormulasDeValoresToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.EditarFormulasDeValoresToolStripMenuItem.Text = "Precios"
        '
        'MargeToolStripMenuItem
        '
        Me.MargeToolStripMenuItem.Name = "MargeToolStripMenuItem"
        Me.MargeToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.MargeToolStripMenuItem.Text = "Margenes"
        '
        'EditarFormulasDeEcuacionesToolStripMenuItem
        '
        Me.EditarFormulasDeEcuacionesToolStripMenuItem.Name = "EditarFormulasDeEcuacionesToolStripMenuItem"
        Me.EditarFormulasDeEcuacionesToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.EditarFormulasDeEcuacionesToolStripMenuItem.Text = "Ecuaciones"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Btn_Grabar_Flete)
        Me.TabPage3.Controls.Add(Me.GroupBox9)
        Me.TabPage3.Controls.Add(Me.GroupBox8)
        Me.TabPage3.ForeColor = System.Drawing.Color.Black
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(751, 398)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Recargos (Fletes)"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Btn_Grabar_Flete
        '
        Me.Btn_Grabar_Flete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Grabar_Flete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Grabar_Flete.Image = CType(resources.GetObject("Btn_Grabar_Flete.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Flete.Location = New System.Drawing.Point(107, 50)
        Me.Btn_Grabar_Flete.Name = "Btn_Grabar_Flete"
        Me.Btn_Grabar_Flete.Size = New System.Drawing.Size(118, 37)
        Me.Btn_Grabar_Flete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Grabar_Flete.TabIndex = 18
        Me.Btn_Grabar_Flete.Text = "GRABAR FLETE"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label2)
        Me.GroupBox9.Controls.Add(Me.TxtFlete2)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.ForeColor = System.Drawing.Color.Black
        Me.GroupBox9.Location = New System.Drawing.Point(13, 10)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(88, 77)
        Me.GroupBox9.TabIndex = 16
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Recargos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Flete $"
        '
        'TxtFlete2
        '
        Me.TxtFlete2.BackColor = System.Drawing.Color.White
        Me.TxtFlete2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFlete2.ForeColor = System.Drawing.Color.Black
        Me.TxtFlete2.Location = New System.Drawing.Point(9, 40)
        Me.TxtFlete2.Name = "TxtFlete2"
        Me.TxtFlete2.Size = New System.Drawing.Size(69, 22)
        Me.TxtFlete2.TabIndex = 11
        Me.TxtFlete2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.GrillaRecargos)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(10, 93)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(735, 210)
        Me.GroupBox8.TabIndex = 11
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Recargos"
        '
        'GrillaRecargos
        '
        Me.GrillaRecargos.AllowUserToAddRows = False
        Me.GrillaRecargos.AllowUserToDeleteRows = False
        Me.GrillaRecargos.BackgroundColor = System.Drawing.Color.White
        Me.GrillaRecargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaRecargos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaRecargos.Location = New System.Drawing.Point(3, 18)
        Me.GrillaRecargos.Name = "GrillaRecargos"
        Me.GrillaRecargos.ReadOnly = True
        Me.GrillaRecargos.Size = New System.Drawing.Size(729, 189)
        Me.GrillaRecargos.TabIndex = 0
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnSimular, Me.Btnimprimir, Me.BtnFormulas, Me.Btn_RecalcularPPP})
        Me.Bar2.Location = New System.Drawing.Point(0, 591)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(767, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 51
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = Global.BkSpecialPrograms.My.Resources.Resources.save
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'BtnSimular
        '
        Me.BtnSimular.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSimular.ForeColor = System.Drawing.Color.Black
        Me.BtnSimular.Image = CType(resources.GetObject("BtnSimular.Image"), System.Drawing.Image)
        Me.BtnSimular.Name = "BtnSimular"
        Me.BtnSimular.Text = "Simular"
        '
        'Btnimprimir
        '
        Me.Btnimprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btnimprimir.ForeColor = System.Drawing.Color.Black
        Me.Btnimprimir.Image = Global.BkSpecialPrograms.My.Resources.Resources.print2
        Me.Btnimprimir.Name = "Btnimprimir"
        Me.Btnimprimir.Text = "Imprimir flejes"
        Me.Btnimprimir.Visible = False
        '
        'BtnFormulas
        '
        Me.BtnFormulas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFormulas.ForeColor = System.Drawing.Color.Black
        Me.BtnFormulas.Name = "BtnFormulas"
        Me.BtnFormulas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFormulasListas, Me.ButtonItem1})
        Me.BtnFormulas.Text = "Formulas"
        '
        'BtnFormulasListas
        '
        Me.BtnFormulasListas.Name = "BtnFormulasListas"
        Me.BtnFormulasListas.Text = "Funcion para actualizar valores de lista de precios"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Funcion para actualizar ecuaciones en lista de precios"
        '
        'CmmdFxPrecios
        '
        Me.CmmdFxPrecios.Name = "CmmdFxPrecios"
        '
        'CmmdFxRangos
        '
        Me.CmmdFxRangos.Name = "CmmdFxRangos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(4, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 16)
        Me.Label10.TabIndex = 0
        '
        'TxtRango1
        '
        Me.TxtRango1.BackColor = System.Drawing.Color.White
        Me.TxtRango1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRango1.ForeColor = System.Drawing.Color.Black
        Me.TxtRango1.Location = New System.Drawing.Point(6, 42)
        Me.TxtRango1.Name = "TxtRango1"
        Me.TxtRango1.Size = New System.Drawing.Size(66, 22)
        Me.TxtRango1.TabIndex = 1
        Me.TxtRango1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(112, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 16)
        Me.Label9.TabIndex = 2
        '
        'TxtRango2
        '
        Me.TxtRango2.BackColor = System.Drawing.Color.White
        Me.TxtRango2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRango2.ForeColor = System.Drawing.Color.Black
        Me.TxtRango2.Location = New System.Drawing.Point(115, 42)
        Me.TxtRango2.Name = "TxtRango2"
        Me.TxtRango2.Size = New System.Drawing.Size(66, 22)
        Me.TxtRango2.TabIndex = 3
        Me.TxtRango2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'Btn_RecalcularPPP
        '
        Me.Btn_RecalcularPPP.ForeColor = System.Drawing.Color.Black
        Me.Btn_RecalcularPPP.Name = "Btn_RecalcularPPP"
        Me.Btn_RecalcularPPP.Text = "Recalcular PPP"
        '
        'Frm_PreciosLC_Mt01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 632)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PreciosLC_Mt01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantención de listas de precios por rangos y formulas externas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GrillaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GrillaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.GrillaRecargos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaProducto As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMcostoOld As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFlete1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNetoPropuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtBrutoPropuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrecioDigitado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMargenDigitado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaPrecios As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtFlete2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaRecargos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSimular As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtRango1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtRango2 As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarFormulasDeValoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarFormulasDeEcuacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnBuscarProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btnimprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MargeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnFormulas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btndimensiones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnFormulasListas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CmmdFxPrecios As DevComponents.DotNetBar.Command
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CmmdFxRangos As DevComponents.DotNetBar.Command
    Friend WithEvents Btn_Grabar_Flete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_RecalcularPPP As DevComponents.DotNetBar.ButtonItem
End Class
