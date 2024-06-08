<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscarDocumento_Mt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BuscarDocumento_Mt))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_Idmaeedo = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_Correo_Adjunto = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Cambiar_Entidad_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Firmar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Facturar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CopiarDocOtrEmpresa = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnActualizarLista = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_Correos_Masivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_Los_Correos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cerrar_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Abrir_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_GrabarHabilitarFacturar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Detalle = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LblEntFisica = New DevComponents.DotNetBar.LabelX()
        Me.CmbCantFilas = New System.Windows.Forms.ComboBox()
        Me.Lbl_Ver = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Marcar_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Barra_Progreso = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.Tiempo_Cerrar_Documentos_Automaticamente = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(310, 23)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 45
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_Idmaeedo, Me.Btn_Ver_Documento, Me.Btn_Enviar_Correo_Adjunto, Me.LabelItem2, Me.Btn_Cambiar_Entidad_Documento, Me.Btn_Imprimir_Documento, Me.Btn_Firmar_Documento, Me.Btn_Facturar, Me.Btn_CopiarDocOtrEmpresa, Me.LabelItem3, Me.Btn_Copiar})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_Mnu_Idmaeedo
        '
        Me.Lbl_Mnu_Idmaeedo.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_Idmaeedo.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_Idmaeedo.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_Idmaeedo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_Idmaeedo.Name = "Lbl_Mnu_Idmaeedo"
        Me.Lbl_Mnu_Idmaeedo.PaddingBottom = 1
        Me.Lbl_Mnu_Idmaeedo.PaddingLeft = 10
        Me.Lbl_Mnu_Idmaeedo.PaddingTop = 1
        Me.Lbl_Mnu_Idmaeedo.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_Idmaeedo.Text = "Opciones"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Enviar_Correo_Adjunto
        '
        Me.Btn_Enviar_Correo_Adjunto.Image = CType(resources.GetObject("Btn_Enviar_Correo_Adjunto.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Correo_Adjunto.ImageAlt = CType(resources.GetObject("Btn_Enviar_Correo_Adjunto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Enviar_Correo_Adjunto.Name = "Btn_Enviar_Correo_Adjunto"
        Me.Btn_Enviar_Correo_Adjunto.Text = "Enviar documento por correo"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Opciones especiales"
        '
        'Btn_Cambiar_Entidad_Documento
        '
        Me.Btn_Cambiar_Entidad_Documento.Image = CType(resources.GetObject("Btn_Cambiar_Entidad_Documento.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Entidad_Documento.ImageAlt = CType(resources.GetObject("Btn_Cambiar_Entidad_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cambiar_Entidad_Documento.Name = "Btn_Cambiar_Entidad_Documento"
        Me.Btn_Cambiar_Entidad_Documento.Text = "Cambiar entidad del documento"
        '
        'Btn_Imprimir_Documento
        '
        Me.Btn_Imprimir_Documento.Image = CType(resources.GetObject("Btn_Imprimir_Documento.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Documento.ImageAlt = CType(resources.GetObject("Btn_Imprimir_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir_Documento.Name = "Btn_Imprimir_Documento"
        Me.Btn_Imprimir_Documento.Text = "Imprimir documento"
        '
        'Btn_Firmar_Documento
        '
        Me.Btn_Firmar_Documento.Image = CType(resources.GetObject("Btn_Firmar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Firmar_Documento.ImageAlt = CType(resources.GetObject("Btn_Firmar_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Firmar_Documento.Name = "Btn_Firmar_Documento"
        Me.Btn_Firmar_Documento.Text = "Firmar documento Electrónicamente"
        '
        'Btn_Facturar
        '
        Me.Btn_Facturar.Image = CType(resources.GetObject("Btn_Facturar.Image"), System.Drawing.Image)
        Me.Btn_Facturar.ImageAlt = CType(resources.GetObject("Btn_Facturar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Facturar.Name = "Btn_Facturar"
        Me.Btn_Facturar.Text = "Facturar"
        '
        'Btn_CopiarDocOtrEmpresa
        '
        Me.Btn_CopiarDocOtrEmpresa.Image = CType(resources.GetObject("Btn_CopiarDocOtrEmpresa.Image"), System.Drawing.Image)
        Me.Btn_CopiarDocOtrEmpresa.ImageAlt = CType(resources.GetObject("Btn_CopiarDocOtrEmpresa.ImageAlt"), System.Drawing.Image)
        Me.Btn_CopiarDocOtrEmpresa.Name = "Btn_CopiarDocOtrEmpresa"
        Me.Btn_CopiarDocOtrEmpresa.Text = "Copiar documento en otra empresa"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "-----------------------------------------"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla.Size = New System.Drawing.Size(964, 313)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 28
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar, Me.BtnActualizarLista, Me.Btn_Enviar_Correos_Masivos, Me.Btn_Enviar_Los_Correos, Me.Btn_Cerrar_Documentos, Me.Btn_Abrir_Documentos, Me.Btn_Cancelar, Me.Btn_GrabarHabilitarFacturar})
        Me.Bar1.Location = New System.Drawing.Point(0, 556)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(994, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 11
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.ImageAlt = CType(resources.GetObject("BtnAceptar.ImageAlt"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Aceptar"
        '
        'BtnActualizarLista
        '
        Me.BtnActualizarLista.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizarLista.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizarLista.Image = CType(resources.GetObject("BtnActualizarLista.Image"), System.Drawing.Image)
        Me.BtnActualizarLista.ImageAlt = CType(resources.GetObject("BtnActualizarLista.ImageAlt"), System.Drawing.Image)
        Me.BtnActualizarLista.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnActualizarLista.Name = "BtnActualizarLista"
        Me.BtnActualizarLista.Tooltip = "Actualizar (F5)"
        '
        'Btn_Enviar_Correos_Masivos
        '
        Me.Btn_Enviar_Correos_Masivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Enviar_Correos_Masivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Enviar_Correos_Masivos.Image = CType(resources.GetObject("Btn_Enviar_Correos_Masivos.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Correos_Masivos.ImageAlt = CType(resources.GetObject("Btn_Enviar_Correos_Masivos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Enviar_Correos_Masivos.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_Enviar_Correos_Masivos.Name = "Btn_Enviar_Correos_Masivos"
        Me.Btn_Enviar_Correos_Masivos.Text = "Reenviar correos"
        Me.Btn_Enviar_Correos_Masivos.Tooltip = "Reenviar masivamente documentos al diablito para envio de correos"
        '
        'Btn_Enviar_Los_Correos
        '
        Me.Btn_Enviar_Los_Correos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Enviar_Los_Correos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Enviar_Los_Correos.Image = CType(resources.GetObject("Btn_Enviar_Los_Correos.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Los_Correos.ImageAlt = CType(resources.GetObject("Btn_Enviar_Los_Correos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Enviar_Los_Correos.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_Enviar_Los_Correos.Name = "Btn_Enviar_Los_Correos"
        Me.Btn_Enviar_Los_Correos.Text = "Enviar correos"
        '
        'Btn_Cerrar_Documentos
        '
        Me.Btn_Cerrar_Documentos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cerrar_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cerrar_Documentos.Image = CType(resources.GetObject("Btn_Cerrar_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Cerrar_Documentos.ImageAlt = CType(resources.GetObject("Btn_Cerrar_Documentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cerrar_Documentos.Name = "Btn_Cerrar_Documentos"
        Me.Btn_Cerrar_Documentos.Tooltip = "Cerrar documentos"
        '
        'Btn_Abrir_Documentos
        '
        Me.Btn_Abrir_Documentos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Abrir_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Abrir_Documentos.Image = CType(resources.GetObject("Btn_Abrir_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Abrir_Documentos.ImageAlt = CType(resources.GetObject("Btn_Abrir_Documentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Abrir_Documentos.Name = "Btn_Abrir_Documentos"
        Me.Btn_Abrir_Documentos.Tooltip = "Abrir documentos"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Detener proceso"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_GrabarHabilitarFacturar
        '
        Me.Btn_GrabarHabilitarFacturar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_GrabarHabilitarFacturar.ForeColor = System.Drawing.Color.Black
        Me.Btn_GrabarHabilitarFacturar.Image = CType(resources.GetObject("Btn_GrabarHabilitarFacturar.Image"), System.Drawing.Image)
        Me.Btn_GrabarHabilitarFacturar.ImageAlt = CType(resources.GetObject("Btn_GrabarHabilitarFacturar.ImageAlt"), System.Drawing.Image)
        Me.Btn_GrabarHabilitarFacturar.Name = "Btn_GrabarHabilitarFacturar"
        Me.Btn_GrabarHabilitarFacturar.Text = "Grabar habilitaciones"
        Me.Btn_GrabarHabilitarFacturar.Tooltip = "Habilitar para facturar"
        '
        'Grilla_Detalle
        '
        Me.Grilla_Detalle.AllowUserToAddRows = False
        Me.Grilla_Detalle.AllowUserToDeleteRows = False
        Me.Grilla_Detalle.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Grilla_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Detalle.DefaultCellStyle = DataGridViewCellStyle11
        Me.Grilla_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Detalle.EnableHeadersVisualStyles = False
        Me.Grilla_Detalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Detalle.Name = "Grilla_Detalle"
        Me.Grilla_Detalle.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Grilla_Detalle.Size = New System.Drawing.Size(964, 126)
        Me.Grilla_Detalle.StandardTab = True
        Me.Grilla_Detalle.TabIndex = 28
        '
        'LblEntFisica
        '
        Me.LblEntFisica.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEntFisica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEntFisica.ForeColor = System.Drawing.Color.Black
        Me.LblEntFisica.Location = New System.Drawing.Point(12, 348)
        Me.LblEntFisica.Name = "LblEntFisica"
        Me.LblEntFisica.Size = New System.Drawing.Size(485, 22)
        Me.LblEntFisica.TabIndex = 13
        Me.LblEntFisica.Text = "Entidad física:"
        '
        'CmbCantFilas
        '
        Me.CmbCantFilas.BackColor = System.Drawing.Color.White
        Me.CmbCantFilas.ForeColor = System.Drawing.Color.Black
        Me.CmbCantFilas.FormattingEnabled = True
        Me.CmbCantFilas.Items.AddRange(New Object() {"10", "20", "30", "40", "50", "100", "200", "1000", "10000", "100000"})
        Me.CmbCantFilas.Location = New System.Drawing.Point(890, 351)
        Me.CmbCantFilas.Name = "CmbCantFilas"
        Me.CmbCantFilas.Size = New System.Drawing.Size(92, 21)
        Me.CmbCantFilas.TabIndex = 27
        Me.CmbCantFilas.Text = "40"
        '
        'Lbl_Ver
        '
        Me.Lbl_Ver.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Ver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Ver.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Ver.Location = New System.Drawing.Point(795, 349)
        Me.Lbl_Ver.Name = "Lbl_Ver"
        Me.Lbl_Ver.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_Ver.TabIndex = 28
        Me.Lbl_Ver.Text = "Ver los primeros"
        Me.Lbl_Ver.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 7)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(970, 336)
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
        Me.GroupPanel1.TabIndex = 29
        Me.GroupPanel1.Text = "Documentos encontrados"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Detalle)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 375)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(970, 149)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 46
        Me.GroupPanel2.Text = "Detalle del documento"
        '
        'Chk_Marcar_Todas
        '
        Me.Chk_Marcar_Todas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Marcar_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Marcar_Todas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Marcar_Todas.Location = New System.Drawing.Point(12, 527)
        Me.Chk_Marcar_Todas.Name = "Chk_Marcar_Todas"
        Me.Chk_Marcar_Todas.Size = New System.Drawing.Size(100, 23)
        Me.Chk_Marcar_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Marcar_Todas.TabIndex = 47
        Me.Chk_Marcar_Todas.Text = "Marcar todas"
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Barra_Progreso, Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 597)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(994, 22)
        Me.MetroStatusBar1.TabIndex = 48
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Barra_Progreso
        '
        '
        '
        '
        Me.Barra_Progreso.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ChunkGradientAngle = 0!
        Me.Barra_Progreso.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.RecentlyUsed = False
        Me.Barra_Progreso.Visible = False
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Status..."
        '
        'Tiempo_Cerrar_Documentos_Automaticamente
        '
        Me.Tiempo_Cerrar_Documentos_Automaticamente.Interval = 2000
        '
        'Frm_BuscarDocumento_Mt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 619)
        Me.Controls.Add(Me.Chk_Marcar_Todas)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Lbl_Ver)
        Me.Controls.Add(Me.CmbCantFilas)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.LblEntFisica)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BuscarDocumento_Mt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar documentos del sistema"
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Detalle As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LblEntFisica As DevComponents.DotNetBar.LabelX
    Public WithEvents CmbCantFilas As System.Windows.Forms.ComboBox
    Friend WithEvents BtnActualizarLista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_Idmaeedo As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enviar_Correo_Adjunto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cambiar_Entidad_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Firmar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Facturar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Lbl_Ver As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Enviar_Correos_Masivos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enviar_Los_Correos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Marcar_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Cerrar_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Abrir_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tiempo_Cerrar_Documentos_Automaticamente As Timer
    Friend WithEvents Btn_CopiarDocOtrEmpresa As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_GrabarHabilitarFacturar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
End Class
