<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolCredito_Autorizar_Formulario
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SolCredito_Autorizar_Formulario))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Grupo_Autorizar_Rechazar = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Rdb_Autorizar = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Rechazar = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Grupo_Texto = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Grupo_Chequeados = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Chk_Entrega_de_garantia_real = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Documentar_con_cheque_o_letra = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Previa_entrega_de_carpeta = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Previa_liberacion_de_fondos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Pago_anticipado_de_factura = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Imagen_AR = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.Imagenes_32 = New System.Windows.Forms.ImageList(Me.components)
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Anular_Autorizacion = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Autorizar_Rechazar.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Grupo_Texto.SuspendLayout()
        Me.Grupo_Chequeados.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Anular_Autorizacion, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 434)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(564, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 115
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Text = "Grabar"
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
        'Grupo_Autorizar_Rechazar
        '
        Me.Grupo_Autorizar_Rechazar.BackColor = System.Drawing.Color.White
        Me.Grupo_Autorizar_Rechazar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Autorizar_Rechazar.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Autorizar_Rechazar.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Autorizar_Rechazar.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Autorizar_Rechazar.Name = "Grupo_Autorizar_Rechazar"
        Me.Grupo_Autorizar_Rechazar.Size = New System.Drawing.Size(473, 71)
        '
        '
        '
        Me.Grupo_Autorizar_Rechazar.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Autorizar_Rechazar.Style.BackColorGradientAngle = 90
        Me.Grupo_Autorizar_Rechazar.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Autorizar_Rechazar.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Autorizar_Rechazar.Style.BorderBottomWidth = 1
        Me.Grupo_Autorizar_Rechazar.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Autorizar_Rechazar.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Autorizar_Rechazar.Style.BorderLeftWidth = 1
        Me.Grupo_Autorizar_Rechazar.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Autorizar_Rechazar.Style.BorderRightWidth = 1
        Me.Grupo_Autorizar_Rechazar.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Autorizar_Rechazar.Style.BorderTopWidth = 1
        Me.Grupo_Autorizar_Rechazar.Style.CornerDiameter = 4
        Me.Grupo_Autorizar_Rechazar.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Autorizar_Rechazar.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Autorizar_Rechazar.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Autorizar_Rechazar.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Autorizar_Rechazar.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Autorizar_Rechazar.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Autorizar_Rechazar.TabIndex = 116
        Me.Grupo_Autorizar_Rechazar.Text = "Autorizar/Rechazar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Autorizar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Rechazar, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(528, 26)
        Me.TableLayoutPanel1.TabIndex = 65
        '
        'Rdb_Autorizar
        '
        Me.Rdb_Autorizar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Autorizar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Autorizar.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Autorizar.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Autorizar.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Autorizar.Name = "Rdb_Autorizar"
        Me.Rdb_Autorizar.Size = New System.Drawing.Size(115, 20)
        Me.Rdb_Autorizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Autorizar.TabIndex = 59
        Me.Rdb_Autorizar.Text = "AUTORIZADO"
        '
        'Rdb_Rechazar
        '
        Me.Rdb_Rechazar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Rechazar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rechazar.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rechazar.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rechazar.Location = New System.Drawing.Point(179, 3)
        Me.Rdb_Rechazar.Name = "Rdb_Rechazar"
        Me.Rdb_Rechazar.Size = New System.Drawing.Size(152, 20)
        Me.Rdb_Rechazar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rechazar.TabIndex = 60
        Me.Rdb_Rechazar.Text = "RECHAZADO"
        '
        'Grupo_Texto
        '
        Me.Grupo_Texto.BackColor = System.Drawing.Color.White
        Me.Grupo_Texto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Texto.Controls.Add(Me.Txt_Observaciones)
        Me.Grupo_Texto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Texto.Location = New System.Drawing.Point(12, 236)
        Me.Grupo_Texto.Name = "Grupo_Texto"
        Me.Grupo_Texto.Size = New System.Drawing.Size(540, 192)
        '
        '
        '
        Me.Grupo_Texto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Texto.Style.BackColorGradientAngle = 90
        Me.Grupo_Texto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Texto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Texto.Style.BorderBottomWidth = 1
        Me.Grupo_Texto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Texto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Texto.Style.BorderLeftWidth = 1
        Me.Grupo_Texto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Texto.Style.BorderRightWidth = 1
        Me.Grupo_Texto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Texto.Style.BorderTopWidth = 1
        Me.Grupo_Texto.Style.CornerDiameter = 4
        Me.Grupo_Texto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Texto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Texto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Texto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Texto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Texto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Texto.TabIndex = 117
        Me.Grupo_Texto.Text = "Observaciones..."
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Observaciones.Size = New System.Drawing.Size(528, 163)
        Me.Txt_Observaciones.TabIndex = 0
        Me.Txt_Observaciones.TabStop = False
        '
        'Grupo_Chequeados
        '
        Me.Grupo_Chequeados.BackColor = System.Drawing.Color.White
        Me.Grupo_Chequeados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Chequeados.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Chequeados.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Chequeados.Location = New System.Drawing.Point(12, 89)
        Me.Grupo_Chequeados.Name = "Grupo_Chequeados"
        Me.Grupo_Chequeados.Size = New System.Drawing.Size(540, 141)
        '
        '
        '
        Me.Grupo_Chequeados.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Chequeados.Style.BackColorGradientAngle = 90
        Me.Grupo_Chequeados.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Chequeados.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chequeados.Style.BorderBottomWidth = 1
        Me.Grupo_Chequeados.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Chequeados.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chequeados.Style.BorderLeftWidth = 1
        Me.Grupo_Chequeados.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chequeados.Style.BorderRightWidth = 1
        Me.Grupo_Chequeados.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chequeados.Style.BorderTopWidth = 1
        Me.Grupo_Chequeados.Style.CornerDiameter = 4
        Me.Grupo_Chequeados.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Chequeados.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Chequeados.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Chequeados.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Chequeados.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Chequeados.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Chequeados.TabIndex = 118
        Me.Grupo_Chequeados.Text = "Observaciones por autorizar"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Entrega_de_garantia_real, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Documentar_con_cheque_o_letra, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Previa_entrega_de_carpeta, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Previa_liberacion_de_fondos, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Pago_anticipado_de_factura, 0, 3)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 12)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(528, 103)
        Me.TableLayoutPanel2.TabIndex = 65
        '
        'Chk_Entrega_de_garantia_real
        '
        Me.Chk_Entrega_de_garantia_real.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Entrega_de_garantia_real.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Entrega_de_garantia_real.ForeColor = System.Drawing.Color.Black
        Me.Chk_Entrega_de_garantia_real.Location = New System.Drawing.Point(3, 86)
        Me.Chk_Entrega_de_garantia_real.Name = "Chk_Entrega_de_garantia_real"
        Me.Chk_Entrega_de_garantia_real.Size = New System.Drawing.Size(499, 14)
        Me.Chk_Entrega_de_garantia_real.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Entrega_de_garantia_real.TabIndex = 63
        Me.Chk_Entrega_de_garantia_real.Text = "Entrega de garantia real"
        '
        'Chk_Documentar_con_cheque_o_letra
        '
        Me.Chk_Documentar_con_cheque_o_letra.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Documentar_con_cheque_o_letra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Documentar_con_cheque_o_letra.ForeColor = System.Drawing.Color.Black
        Me.Chk_Documentar_con_cheque_o_letra.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Documentar_con_cheque_o_letra.Name = "Chk_Documentar_con_cheque_o_letra"
        Me.Chk_Documentar_con_cheque_o_letra.Size = New System.Drawing.Size(499, 17)
        Me.Chk_Documentar_con_cheque_o_letra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Documentar_con_cheque_o_letra.TabIndex = 59
        Me.Chk_Documentar_con_cheque_o_letra.Text = "Documentar con cheque o letra"
        '
        'Chk_Previa_entrega_de_carpeta
        '
        Me.Chk_Previa_entrega_de_carpeta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Previa_entrega_de_carpeta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Previa_entrega_de_carpeta.ForeColor = System.Drawing.Color.Black
        Me.Chk_Previa_entrega_de_carpeta.Location = New System.Drawing.Point(3, 26)
        Me.Chk_Previa_entrega_de_carpeta.Name = "Chk_Previa_entrega_de_carpeta"
        Me.Chk_Previa_entrega_de_carpeta.Size = New System.Drawing.Size(499, 14)
        Me.Chk_Previa_entrega_de_carpeta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Previa_entrega_de_carpeta.TabIndex = 60
        Me.Chk_Previa_entrega_de_carpeta.Text = "Previa entrega de carpeta"
        '
        'Chk_Previa_liberacion_de_fondos
        '
        Me.Chk_Previa_liberacion_de_fondos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Previa_liberacion_de_fondos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Previa_liberacion_de_fondos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Previa_liberacion_de_fondos.Location = New System.Drawing.Point(3, 46)
        Me.Chk_Previa_liberacion_de_fondos.Name = "Chk_Previa_liberacion_de_fondos"
        Me.Chk_Previa_liberacion_de_fondos.Size = New System.Drawing.Size(499, 14)
        Me.Chk_Previa_liberacion_de_fondos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Previa_liberacion_de_fondos.TabIndex = 61
        Me.Chk_Previa_liberacion_de_fondos.Text = "Previa liberación de fondos"
        '
        'Chk_Pago_anticipado_de_factura
        '
        Me.Chk_Pago_anticipado_de_factura.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pago_anticipado_de_factura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pago_anticipado_de_factura.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pago_anticipado_de_factura.Location = New System.Drawing.Point(3, 66)
        Me.Chk_Pago_anticipado_de_factura.Name = "Chk_Pago_anticipado_de_factura"
        Me.Chk_Pago_anticipado_de_factura.Size = New System.Drawing.Size(499, 14)
        Me.Chk_Pago_anticipado_de_factura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pago_anticipado_de_factura.TabIndex = 62
        Me.Chk_Pago_anticipado_de_factura.Text = "Pago anticipado de factura"
        '
        'Imagen_AR
        '
        Me.Imagen_AR.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Imagen_AR.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_AR.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_AR.ForeColor = System.Drawing.Color.Black
        Me.Imagen_AR.Image = CType(resources.GetObject("Imagen_AR.Image"), System.Drawing.Image)
        Me.Imagen_AR.Location = New System.Drawing.Point(497, 22)
        Me.Imagen_AR.Name = "Imagen_AR"
        Me.Imagen_AR.Size = New System.Drawing.Size(55, 61)
        Me.Imagen_AR.TabIndex = 119
        '
        'Imagenes_32
        '
        Me.Imagenes_32.ImageStream = CType(resources.GetObject("Imagenes_32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32.Images.SetKeyName(0, "secure.png")
        Me.Imagenes_32.Images.SetKeyName(1, "Rechazado")
        Me.Imagenes_32.Images.SetKeyName(2, "Autorizado")
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Text = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Anular_Autorizacion
        '
        Me.Btn_Anular_Autorizacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Anular_Autorizacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Anular_Autorizacion.Image = CType(resources.GetObject("Btn_Anular_Autorizacion.Image"), System.Drawing.Image)
        Me.Btn_Anular_Autorizacion.Name = "Btn_Anular_Autorizacion"
        Me.Btn_Anular_Autorizacion.Text = "Anular autorización"
        '
        'Frm_SolCredito_Autorizar_Formulario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 475)
        Me.ControlBox = False
        Me.Controls.Add(Me.Imagen_AR)
        Me.Controls.Add(Me.Grupo_Chequeados)
        Me.Controls.Add(Me.Grupo_Texto)
        Me.Controls.Add(Me.Grupo_Autorizar_Rechazar)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_SolCredito_Autorizar_Formulario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Autorizar_Rechazar.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Grupo_Texto.ResumeLayout(False)
        Me.Grupo_Chequeados.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Autorizar_Rechazar As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Grupo_Texto As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Rdb_Autorizar As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Rechazar As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Chequeados As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Chk_Documentar_con_cheque_o_letra As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Entrega_de_garantia_real As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Previa_entrega_de_carpeta As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Previa_liberacion_de_fondos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Pago_anticipado_de_factura As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Imagen_AR As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Imagenes_32 As System.Windows.Forms.ImageList
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Anular_Autorizacion As DevComponents.DotNetBar.ButtonItem
End Class
