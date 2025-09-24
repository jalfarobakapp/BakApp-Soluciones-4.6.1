<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PreVenta_IngDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PreVenta_IngDet))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_FormatoPqte = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_UDisponibles = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Contenido = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_VtaMinima = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Moneda = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Moneda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Precio = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DInput_Ud1XPqte = New DevComponents.Editors.DoubleInput()
        Me.DInput_PrecioXUd1 = New DevComponents.Editors.DoubleInput()
        Me.Lbl_StcfiUd1 = New DevComponents.DotNetBar.LabelX()
        Me.Input_PqteHabilitado = New DevComponents.Editors.IntegerInput()
        Me.Input_CantMinFormato = New DevComponents.Editors.IntegerInput()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DInput_Ud1XPqte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DInput_PrecioXUd1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_PqteHabilitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_CantMinFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 255)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(558, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar1.TabIndex = 35
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 74)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(187, 23)
        Me.LabelX1.TabIndex = 150
        Me.LabelX1.Text = "Formato"
        '
        'Txt_FormatoPqte
        '
        Me.Txt_FormatoPqte.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FormatoPqte.Border.Class = "TextBoxBorder"
        Me.Txt_FormatoPqte.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FormatoPqte.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FormatoPqte.ForeColor = System.Drawing.Color.Black
        Me.Txt_FormatoPqte.Location = New System.Drawing.Point(163, 77)
        Me.Txt_FormatoPqte.Name = "Txt_FormatoPqte"
        Me.Txt_FormatoPqte.PreventEnterBeep = True
        Me.Txt_FormatoPqte.Size = New System.Drawing.Size(116, 22)
        Me.Txt_FormatoPqte.TabIndex = 0
        Me.Txt_FormatoPqte.Text = "PALLET"
        '
        'Lbl_UDisponibles
        '
        Me.Lbl_UDisponibles.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_UDisponibles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_UDisponibles.ForeColor = System.Drawing.Color.Black
        Me.Lbl_UDisponibles.Location = New System.Drawing.Point(12, 131)
        Me.Lbl_UDisponibles.Name = "Lbl_UDisponibles"
        Me.Lbl_UDisponibles.Size = New System.Drawing.Size(145, 23)
        Me.Lbl_UDisponibles.TabIndex = 152
        Me.Lbl_UDisponibles.Text = "Habilitar (pallet disponibles)"
        '
        'Lbl_Contenido
        '
        Me.Lbl_Contenido.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Contenido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Contenido.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Contenido.Location = New System.Drawing.Point(12, 103)
        Me.Lbl_Contenido.Name = "Lbl_Contenido"
        Me.Lbl_Contenido.Size = New System.Drawing.Size(145, 23)
        Me.Lbl_Contenido.TabIndex = 154
        Me.Lbl_Contenido.Text = "Contenido (kg/pallet)"
        '
        'Lbl_VtaMinima
        '
        Me.Lbl_VtaMinima.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_VtaMinima.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_VtaMinima.ForeColor = System.Drawing.Color.Black
        Me.Lbl_VtaMinima.Location = New System.Drawing.Point(12, 160)
        Me.Lbl_VtaMinima.Name = "Lbl_VtaMinima"
        Me.Lbl_VtaMinima.Size = New System.Drawing.Size(145, 23)
        Me.Lbl_VtaMinima.TabIndex = 156
        Me.Lbl_VtaMinima.Text = "Venta mínima (pallets)"
        '
        'Lbl_Moneda
        '
        Me.Lbl_Moneda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Moneda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Moneda.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Moneda.Location = New System.Drawing.Point(12, 189)
        Me.Lbl_Moneda.Name = "Lbl_Moneda"
        Me.Lbl_Moneda.Size = New System.Drawing.Size(145, 23)
        Me.Lbl_Moneda.TabIndex = 157
        Me.Lbl_Moneda.Text = "Moneda"
        '
        'Txt_Moneda
        '
        Me.Txt_Moneda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Moneda.Border.Class = "TextBoxBorder"
        Me.Txt_Moneda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Moneda.ButtonCustom.Image = CType(resources.GetObject("Txt_Moneda.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Moneda.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Moneda.ForeColor = System.Drawing.Color.Black
        Me.Txt_Moneda.Location = New System.Drawing.Point(163, 189)
        Me.Txt_Moneda.Name = "Txt_Moneda"
        Me.Txt_Moneda.PreventEnterBeep = True
        Me.Txt_Moneda.ReadOnly = True
        Me.Txt_Moneda.Size = New System.Drawing.Size(80, 22)
        Me.Txt_Moneda.TabIndex = 4
        Me.Txt_Moneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_Precio
        '
        Me.Lbl_Precio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Precio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Precio.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Precio.Location = New System.Drawing.Point(12, 216)
        Me.Lbl_Precio.Name = "Lbl_Precio"
        Me.Lbl_Precio.Size = New System.Drawing.Size(145, 23)
        Me.Lbl_Precio.TabIndex = 160
        Me.Lbl_Precio.Text = "Precio"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(12, 12)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(123, 23)
        Me.LabelX7.TabIndex = 161
        Me.LabelX7.Text = "Producto"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(12, 41)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(123, 23)
        Me.LabelX8.TabIndex = 162
        Me.LabelX8.Text = "Descripción"
        '
        'Txt_Codigo
        '
        Me.Txt_Codigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo.Location = New System.Drawing.Point(141, 15)
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.PreventEnterBeep = True
        Me.Txt_Codigo.ReadOnly = True
        Me.Txt_Codigo.Size = New System.Drawing.Size(116, 22)
        Me.Txt_Codigo.TabIndex = 163
        Me.Txt_Codigo.TabStop = False
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(141, 44)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ReadOnly = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(403, 22)
        Me.Txt_Descripcion.TabIndex = 164
        Me.Txt_Descripcion.TabStop = False
        '
        'DInput_Ud1XPqte
        '
        Me.DInput_Ud1XPqte.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DInput_Ud1XPqte.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DInput_Ud1XPqte.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DInput_Ud1XPqte.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.DInput_Ud1XPqte.ForeColor = System.Drawing.Color.Black
        Me.DInput_Ud1XPqte.Increment = 1.0R
        Me.DInput_Ud1XPqte.Location = New System.Drawing.Point(163, 105)
        Me.DInput_Ud1XPqte.MinValue = 0R
        Me.DInput_Ud1XPqte.Name = "DInput_Ud1XPqte"
        Me.DInput_Ud1XPqte.ShowUpDown = True
        Me.DInput_Ud1XPqte.Size = New System.Drawing.Size(80, 22)
        Me.DInput_Ud1XPqte.TabIndex = 1
        '
        'DInput_PrecioXUd1
        '
        Me.DInput_PrecioXUd1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DInput_PrecioXUd1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DInput_PrecioXUd1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DInput_PrecioXUd1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.DInput_PrecioXUd1.ForeColor = System.Drawing.Color.Black
        Me.DInput_PrecioXUd1.Increment = 0.1R
        Me.DInput_PrecioXUd1.Location = New System.Drawing.Point(163, 216)
        Me.DInput_PrecioXUd1.MinValue = 0R
        Me.DInput_PrecioXUd1.Name = "DInput_PrecioXUd1"
        Me.DInput_PrecioXUd1.ShowUpDown = True
        Me.DInput_PrecioXUd1.Size = New System.Drawing.Size(80, 22)
        Me.DInput_PrecioXUd1.TabIndex = 5
        '
        'Lbl_StcfiUd1
        '
        Me.Lbl_StcfiUd1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_StcfiUd1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_StcfiUd1.ForeColor = System.Drawing.Color.Black
        Me.Lbl_StcfiUd1.Location = New System.Drawing.Point(298, 105)
        Me.Lbl_StcfiUd1.Name = "Lbl_StcfiUd1"
        Me.Lbl_StcfiUd1.Size = New System.Drawing.Size(246, 23)
        Me.Lbl_StcfiUd1.TabIndex = 165
        Me.Lbl_StcfiUd1.Text = "Kilos disponibles: 99.999"
        '
        'Input_PqteHabilitado
        '
        Me.Input_PqteHabilitado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_PqteHabilitado.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_PqteHabilitado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_PqteHabilitado.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_PqteHabilitado.ForeColor = System.Drawing.Color.Black
        Me.Input_PqteHabilitado.Location = New System.Drawing.Point(163, 134)
        Me.Input_PqteHabilitado.Name = "Input_PqteHabilitado"
        Me.Input_PqteHabilitado.ShowUpDown = True
        Me.Input_PqteHabilitado.Size = New System.Drawing.Size(80, 22)
        Me.Input_PqteHabilitado.TabIndex = 2
        '
        'Input_CantMinFormato
        '
        Me.Input_CantMinFormato.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_CantMinFormato.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_CantMinFormato.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_CantMinFormato.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_CantMinFormato.ForeColor = System.Drawing.Color.Black
        Me.Input_CantMinFormato.Location = New System.Drawing.Point(163, 162)
        Me.Input_CantMinFormato.Name = "Input_CantMinFormato"
        Me.Input_CantMinFormato.ShowUpDown = True
        Me.Input_CantMinFormato.Size = New System.Drawing.Size(80, 22)
        Me.Input_CantMinFormato.TabIndex = 3
        '
        'Frm_PreVenta_IngDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 296)
        Me.Controls.Add(Me.Input_CantMinFormato)
        Me.Controls.Add(Me.Input_PqteHabilitado)
        Me.Controls.Add(Me.Lbl_StcfiUd1)
        Me.Controls.Add(Me.DInput_PrecioXUd1)
        Me.Controls.Add(Me.DInput_Ud1XPqte)
        Me.Controls.Add(Me.Txt_Descripcion)
        Me.Controls.Add(Me.Txt_Codigo)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.Lbl_Precio)
        Me.Controls.Add(Me.Txt_Moneda)
        Me.Controls.Add(Me.Lbl_Moneda)
        Me.Controls.Add(Me.Lbl_VtaMinima)
        Me.Controls.Add(Me.Lbl_Contenido)
        Me.Controls.Add(Me.Lbl_UDisponibles)
        Me.Controls.Add(Me.Txt_FormatoPqte)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PreVenta_IngDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cantidades para vender en Pre-Venta/Sobre Stock"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DInput_Ud1XPqte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DInput_PrecioXUd1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_PqteHabilitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_CantMinFormato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_FormatoPqte As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_UDisponibles As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Contenido As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_VtaMinima As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Moneda As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Moneda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Precio As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Codigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DInput_Ud1XPqte As DevComponents.Editors.DoubleInput
    Friend WithEvents DInput_PrecioXUd1 As DevComponents.Editors.DoubleInput
    Friend WithEvents Lbl_StcfiUd1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_PqteHabilitado As DevComponents.Editors.IntegerInput
    Friend WithEvents Input_CantMinFormato As DevComponents.Editors.IntegerInput
End Class
