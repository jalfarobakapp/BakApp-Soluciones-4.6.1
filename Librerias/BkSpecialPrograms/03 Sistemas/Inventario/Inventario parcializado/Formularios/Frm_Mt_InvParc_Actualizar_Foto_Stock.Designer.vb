<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Mt_InvParc_Actualizar_Foto_Stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Mt_InvParc_Actualizar_Foto_Stock))
        Me.Lbl_Fecha_Inventario = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnProcesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_Fecha_Inventario
        '
        Me.Lbl_Fecha_Inventario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Fecha_Inventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fecha_Inventario.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_Inventario.Location = New System.Drawing.Point(12, 103)
        Me.Lbl_Fecha_Inventario.Name = "Lbl_Fecha_Inventario"
        Me.Lbl_Fecha_Inventario.Size = New System.Drawing.Size(408, 23)
        Me.Lbl_Fecha_Inventario.TabIndex = 41
        Me.Lbl_Fecha_Inventario.Text = "Presione Porocesar...."
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(75, 12)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 40
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(13, 12)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 39
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesar, Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 158)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(436, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 38
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnProcesar
        '
        Me.BtnProcesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesar.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Text = "Procesar"
        Me.BtnProcesar.Tooltip = "Grabar"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Tooltip = "Grabar"
        '
        'Barra_Progreso
        '
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(12, 74)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.Size = New System.Drawing.Size(408, 23)
        Me.Barra_Progreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Barra_Progreso.TabIndex = 46
        Me.Barra_Progreso.Text = "ProgressBarX1"
        Me.Barra_Progreso.TextVisible = True
        Me.Barra_Progreso.UseWaitCursor = True
        Me.Barra_Progreso.Value = 50
        '
        'Lbl_Producto
        '
        Me.Lbl_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto.Location = New System.Drawing.Point(12, 123)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(408, 23)
        Me.Lbl_Producto.TabIndex = 47
        Me.Lbl_Producto.Text = "Presione Porocesar...."
        '
        'Frm_Mt_InvParc_Actualizar_Foto_Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 199)
        Me.Controls.Add(Me.Lbl_Producto)
        Me.Controls.Add(Me.Barra_Progreso)
        Me.Controls.Add(Me.Lbl_Fecha_Inventario)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Mt_InvParc_Actualizar_Foto_Stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar foto stock todos los inventarios"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_Fecha_Inventario As DevComponents.DotNetBar.LabelX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnProcesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
End Class
