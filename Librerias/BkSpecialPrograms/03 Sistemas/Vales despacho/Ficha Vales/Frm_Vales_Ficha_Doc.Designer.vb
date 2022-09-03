<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vales_Ficha_Doc
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vales_Ficha_Doc))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GrupoDetalle = New System.Windows.Forms.GroupBox
        Me.Grilla_Detalle_Doc_Origen = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Grilla_Doc_Origen = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Grilla_Guias_DespachoNC = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnActivarVale = New DevComponents.DotNetBar.ButtonItem
        Me.BtnImprimirVale = New DevComponents.DotNetBar.ButtonItem
        Me.BtnDireccionDespacho = New DevComponents.DotNetBar.ButtonItem
        Me.BtnAnularVale = New DevComponents.DotNetBar.ButtonItem
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCambiarTipo = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grilla_Vale_Enc = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.LblRtu = New DevComponents.DotNetBar.LabelX
        Me.LblUd2 = New DevComponents.DotNetBar.LabelX
        Me.LblUd1 = New DevComponents.DotNetBar.LabelX
        Me.LblCodTecnico = New DevComponents.DotNetBar.LabelX
        Me.GrupoDetalle.SuspendLayout()
        CType(Me.Grilla_Detalle_Doc_Origen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Grilla_Doc_Origen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grilla_Guias_DespachoNC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla_Vale_Enc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrupoDetalle
        '
        Me.GrupoDetalle.BackColor = System.Drawing.Color.White
        Me.GrupoDetalle.Controls.Add(Me.Grilla_Detalle_Doc_Origen)
        Me.GrupoDetalle.ForeColor = System.Drawing.Color.Black
        Me.GrupoDetalle.Location = New System.Drawing.Point(6, 142)
        Me.GrupoDetalle.Name = "GrupoDetalle"
        Me.GrupoDetalle.Size = New System.Drawing.Size(816, 171)
        Me.GrupoDetalle.TabIndex = 42
        Me.GrupoDetalle.TabStop = False
        Me.GrupoDetalle.Text = "Detalle del documento origen"
        '
        'Grilla_Detalle_Doc_Origen
        '
        Me.Grilla_Detalle_Doc_Origen.AllowUserToAddRows = False
        Me.Grilla_Detalle_Doc_Origen.AllowUserToDeleteRows = False
        Me.Grilla_Detalle_Doc_Origen.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle_Doc_Origen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Detalle_Doc_Origen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Detalle_Doc_Origen.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Detalle_Doc_Origen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Detalle_Doc_Origen.EnableHeadersVisualStyles = False
        Me.Grilla_Detalle_Doc_Origen.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Detalle_Doc_Origen.Location = New System.Drawing.Point(3, 18)
        Me.Grilla_Detalle_Doc_Origen.Name = "Grilla_Detalle_Doc_Origen"
        Me.Grilla_Detalle_Doc_Origen.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle_Doc_Origen.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Detalle_Doc_Origen.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grilla_Detalle_Doc_Origen.Size = New System.Drawing.Size(810, 150)
        Me.Grilla_Detalle_Doc_Origen.StandardTab = True
        Me.Grilla_Detalle_Doc_Origen.TabIndex = 27
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Grilla_Doc_Origen)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(6, 71)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(816, 65)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Documento de origen"
        '
        'Grilla_Doc_Origen
        '
        Me.Grilla_Doc_Origen.AllowUserToAddRows = False
        Me.Grilla_Doc_Origen.AllowUserToDeleteRows = False
        Me.Grilla_Doc_Origen.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Doc_Origen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Doc_Origen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Doc_Origen.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Doc_Origen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Doc_Origen.EnableHeadersVisualStyles = False
        Me.Grilla_Doc_Origen.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Doc_Origen.Location = New System.Drawing.Point(3, 18)
        Me.Grilla_Doc_Origen.Name = "Grilla_Doc_Origen"
        Me.Grilla_Doc_Origen.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Doc_Origen.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Doc_Origen.RowHeadersVisible = False
        Me.Grilla_Doc_Origen.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grilla_Doc_Origen.Size = New System.Drawing.Size(810, 44)
        Me.Grilla_Doc_Origen.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Grilla_Guias_DespachoNC)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(6, 372)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(816, 94)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Guías de despacho de la línea activa"
        '
        'Grilla_Guias_DespachoNC
        '
        Me.Grilla_Guias_DespachoNC.AllowUserToAddRows = False
        Me.Grilla_Guias_DespachoNC.AllowUserToDeleteRows = False
        Me.Grilla_Guias_DespachoNC.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Guias_DespachoNC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla_Guias_DespachoNC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Guias_DespachoNC.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla_Guias_DespachoNC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Guias_DespachoNC.EnableHeadersVisualStyles = False
        Me.Grilla_Guias_DespachoNC.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Guias_DespachoNC.Location = New System.Drawing.Point(3, 18)
        Me.Grilla_Guias_DespachoNC.Name = "Grilla_Guias_DespachoNC"
        Me.Grilla_Guias_DespachoNC.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Guias_DespachoNC.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla_Guias_DespachoNC.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grilla_Guias_DespachoNC.Size = New System.Drawing.Size(810, 73)
        Me.Grilla_Guias_DespachoNC.StandardTab = True
        Me.Grilla_Guias_DespachoNC.TabIndex = 27
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnActivarVale, Me.BtnImprimirVale, Me.BtnDireccionDespacho, Me.BtnAnularVale, Me.BtnActualizar, Me.BtnCambiarTipo, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 472)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(830, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 84
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnActivarVale
        '
        Me.BtnActivarVale.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActivarVale.ForeColor = System.Drawing.Color.Black
        Me.BtnActivarVale.Image = CType(resources.GetObject("BtnActivarVale.Image"), System.Drawing.Image)
        Me.BtnActivarVale.Name = "BtnActivarVale"
        Me.BtnActivarVale.Text = "Activar Vale (dejar mercaderia pendiente)"
        '
        'BtnImprimirVale
        '
        Me.BtnImprimirVale.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImprimirVale.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimirVale.Image = CType(resources.GetObject("BtnImprimirVale.Image"), System.Drawing.Image)
        Me.BtnImprimirVale.Name = "BtnImprimirVale"
        Me.BtnImprimirVale.Tooltip = "Imprimir Vale"
        '
        'BtnDireccionDespacho
        '
        Me.BtnDireccionDespacho.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnDireccionDespacho.ForeColor = System.Drawing.Color.Black
        Me.BtnDireccionDespacho.Image = CType(resources.GetObject("BtnDireccionDespacho.Image"), System.Drawing.Image)
        Me.BtnDireccionDespacho.Name = "BtnDireccionDespacho"
        Me.BtnDireccionDespacho.Tooltip = "Dirección de despacho (Ver,editar,imprimir)"
        '
        'BtnAnularVale
        '
        Me.BtnAnularVale.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAnularVale.ForeColor = System.Drawing.Color.Black
        Me.BtnAnularVale.Image = CType(resources.GetObject("BtnAnularVale.Image"), System.Drawing.Image)
        Me.BtnAnularVale.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom
        Me.BtnAnularVale.Name = "BtnAnularVale"
        Me.BtnAnularVale.Tooltip = "Anular documento"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Tooltip = "Refrescar información"
        '
        'BtnCambiarTipo
        '
        Me.BtnCambiarTipo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCambiarTipo.ForeColor = System.Drawing.Color.Black
        Me.BtnCambiarTipo.Image = CType(resources.GetObject("BtnCambiarTipo.Image"), System.Drawing.Image)
        Me.BtnCambiarTipo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCambiarTipo.Name = "BtnCambiarTipo"
        Me.BtnCambiarTipo.Text = "Cambiar tipo de entrega"
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Grilla_Vale_Enc)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(816, 65)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encabezado del documento"
        '
        'Grilla_Vale_Enc
        '
        Me.Grilla_Vale_Enc.AllowUserToAddRows = False
        Me.Grilla_Vale_Enc.AllowUserToDeleteRows = False
        Me.Grilla_Vale_Enc.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Vale_Enc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Grilla_Vale_Enc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Vale_Enc.DefaultCellStyle = DataGridViewCellStyle11
        Me.Grilla_Vale_Enc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Vale_Enc.EnableHeadersVisualStyles = False
        Me.Grilla_Vale_Enc.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Vale_Enc.Location = New System.Drawing.Point(3, 18)
        Me.Grilla_Vale_Enc.Name = "Grilla_Vale_Enc"
        Me.Grilla_Vale_Enc.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Vale_Enc.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Grilla_Vale_Enc.RowHeadersVisible = False
        Me.Grilla_Vale_Enc.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grilla_Vale_Enc.Size = New System.Drawing.Size(810, 44)
        Me.Grilla_Vale_Enc.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.LblRtu)
        Me.GroupBox4.Controls.Add(Me.LblUd2)
        Me.GroupBox4.Controls.Add(Me.LblUd1)
        Me.GroupBox4.Controls.Add(Me.LblCodTecnico)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(6, 319)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(816, 47)
        Me.GroupBox4.TabIndex = 86
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle del producto de la línea activa"
        '
        'LblRtu
        '
        Me.LblRtu.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblRtu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblRtu.ForeColor = System.Drawing.Color.Black
        Me.LblRtu.Location = New System.Drawing.Point(710, 18)
        Me.LblRtu.Name = "LblRtu"
        Me.LblRtu.Size = New System.Drawing.Size(83, 23)
        Me.LblRtu.TabIndex = 3
        Me.LblRtu.Text = "R.T.U.: 1"
        '
        'LblUd2
        '
        Me.LblUd2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblUd2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblUd2.ForeColor = System.Drawing.Color.Black
        Me.LblUd2.Location = New System.Drawing.Point(627, 18)
        Me.LblUd2.Name = "LblUd2"
        Me.LblUd2.Size = New System.Drawing.Size(63, 23)
        Me.LblUd2.TabIndex = 2
        Me.LblUd2.Text = "Ud 2: UN"
        '
        'LblUd1
        '
        Me.LblUd1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblUd1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblUd1.ForeColor = System.Drawing.Color.Black
        Me.LblUd1.Location = New System.Drawing.Point(561, 18)
        Me.LblUd1.Name = "LblUd1"
        Me.LblUd1.Size = New System.Drawing.Size(60, 23)
        Me.LblUd1.TabIndex = 1
        Me.LblUd1.Text = "Ud 1: UN"
        '
        'LblCodTecnico
        '
        Me.LblCodTecnico.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblCodTecnico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblCodTecnico.ForeColor = System.Drawing.Color.Black
        Me.LblCodTecnico.Location = New System.Drawing.Point(6, 18)
        Me.LblCodTecnico.Name = "LblCodTecnico"
        Me.LblCodTecnico.Size = New System.Drawing.Size(230, 23)
        Me.LblCodTecnico.TabIndex = 0
        Me.LblCodTecnico.Text = "Cód. técnico: "
        '
        'Frm_Vales_Ficha_Doc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 513)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrupoDetalle)
        Me.Controls.Add(Me.GroupBox3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Vales_Ficha_Doc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VALE de mercaderia pendiente"
        Me.GrupoDetalle.ResumeLayout(False)
        CType(Me.Grilla_Detalle_Doc_Origen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Grilla_Doc_Origen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grilla_Guias_DespachoNC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grilla_Vale_Enc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrupoDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla_Detalle_Doc_Origen As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla_Doc_Origen As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla_Guias_DespachoNC As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnImprimirVale As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla_Vale_Enc As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LblRtu As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblUd2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblUd1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblCodTecnico As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnDireccionDespacho As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCambiarTipo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnAnularVale As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnActivarVale As DevComponents.DotNetBar.ButtonItem
End Class
