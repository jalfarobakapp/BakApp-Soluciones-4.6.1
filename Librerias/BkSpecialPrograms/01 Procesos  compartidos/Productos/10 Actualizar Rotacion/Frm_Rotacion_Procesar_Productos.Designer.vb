<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rotacion_Procesar_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rotacion_Procesar_Productos))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Procesar_Asociados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Revisar_Log = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        Me.Barra_Progreso_Quiebres_Stock = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Chk_Incluir_Ventas_Entidades_Excluidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Porcesar_Stock_Asociados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Num_X_Dias = New System.Windows.Forms.NumericUpDown()
        Me.Rdb_Aso_Tbl_Asociacion = New System.Windows.Forms.RadioButton()
        Me.Rdb_Aso_Reemplazo = New System.Windows.Forms.RadioButton()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_X_Dias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar, Me.Btn_Procesar_Asociados, Me.Btn_Revisar_Log, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 281)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(762, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 15
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Text = "Procesar Informe"
        Me.Btn_Procesar.Tooltip = "Procesar el informe para el cálculo de las rotaciones por producto y/o sus reempl" &
    "azos"
        '
        'Btn_Procesar_Asociados
        '
        Me.Btn_Procesar_Asociados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar_Asociados.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar_Asociados.Image = CType(resources.GetObject("Btn_Procesar_Asociados.Image"), System.Drawing.Image)
        Me.Btn_Procesar_Asociados.Name = "Btn_Procesar_Asociados"
        Me.Btn_Procesar_Asociados.Text = "Procesar días existencia (asociados)"
        Me.Btn_Procesar_Asociados.Tooltip = "Procesa los días en que hubo stock en las bodegas y los quiebres de stock por pro" &
    "ducto en conjunto a sus asociados o productos de reemplazo"
        '
        'Btn_Revisar_Log
        '
        Me.Btn_Revisar_Log.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Revisar_Log.ForeColor = System.Drawing.Color.Black
        Me.Btn_Revisar_Log.Image = CType(resources.GetObject("Btn_Revisar_Log.Image"), System.Drawing.Image)
        Me.Btn_Revisar_Log.Name = "Btn_Revisar_Log"
        Me.Btn_Revisar_Log.Text = "Log"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Tooltip = "Cancelar el proceso"
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(8, 64)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 33
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(8, 12)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 32
        '
        'TxtLog
        '
        Me.TxtLog.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtLog.Border.Class = "TextBoxBorder"
        Me.TxtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLog.DisabledBackColor = System.Drawing.Color.White
        Me.TxtLog.ForeColor = System.Drawing.Color.Black
        Me.TxtLog.Location = New System.Drawing.Point(70, 12)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(680, 98)
        Me.TxtLog.TabIndex = 31
        '
        'Lbl_Producto
        '
        Me.Lbl_Producto.AutoSize = True
        Me.Lbl_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto.Location = New System.Drawing.Point(70, 116)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(41, 17)
        Me.Lbl_Producto.TabIndex = 34
        Me.Lbl_Producto.Text = "LabelX1"
        '
        'Barra_Progreso_Quiebres_Stock
        '
        Me.Barra_Progreso_Quiebres_Stock.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso_Quiebres_Stock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso_Quiebres_Stock.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso_Quiebres_Stock.Location = New System.Drawing.Point(12, 139)
        Me.Barra_Progreso_Quiebres_Stock.Name = "Barra_Progreso_Quiebres_Stock"
        Me.Barra_Progreso_Quiebres_Stock.Size = New System.Drawing.Size(738, 23)
        Me.Barra_Progreso_Quiebres_Stock.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Barra_Progreso_Quiebres_Stock.TabIndex = 35
        Me.Barra_Progreso_Quiebres_Stock.Text = "..."
        Me.Barra_Progreso_Quiebres_Stock.TextVisible = True
        '
        'Chk_Incluir_Ventas_Entidades_Excluidas
        '
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Enabled = False
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Location = New System.Drawing.Point(12, 172)
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Name = "Chk_Incluir_Ventas_Entidades_Excluidas"
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Size = New System.Drawing.Size(412, 23)
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.TabIndex = 49
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Text = "Incluir ventas de Entidades Excluidas"
        '
        'Chk_Porcesar_Stock_Asociados
        '
        Me.Chk_Porcesar_Stock_Asociados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Porcesar_Stock_Asociados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Porcesar_Stock_Asociados.Checked = True
        Me.Chk_Porcesar_Stock_Asociados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Porcesar_Stock_Asociados.CheckValue = "Y"
        Me.Chk_Porcesar_Stock_Asociados.Enabled = False
        Me.Chk_Porcesar_Stock_Asociados.ForeColor = System.Drawing.Color.Black
        Me.Chk_Porcesar_Stock_Asociados.Location = New System.Drawing.Point(12, 192)
        Me.Chk_Porcesar_Stock_Asociados.Name = "Chk_Porcesar_Stock_Asociados"
        Me.Chk_Porcesar_Stock_Asociados.Size = New System.Drawing.Size(154, 23)
        Me.Chk_Porcesar_Stock_Asociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Porcesar_Stock_Asociados.TabIndex = 50
        Me.Chk_Porcesar_Stock_Asociados.Text = "Procesar Stock asociados"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Enabled = False
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(211, 244)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(162, 17)
        Me.LabelX1.TabIndex = 54
        Me.LabelX1.Text = "Stock considerado como quiebre"
        '
        'Num_X_Dias
        '
        Me.Num_X_Dias.BackColor = System.Drawing.Color.White
        Me.Num_X_Dias.Enabled = False
        Me.Num_X_Dias.ForeColor = System.Drawing.Color.Black
        Me.Num_X_Dias.Location = New System.Drawing.Point(379, 239)
        Me.Num_X_Dias.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Num_X_Dias.Name = "Num_X_Dias"
        Me.Num_X_Dias.Size = New System.Drawing.Size(50, 22)
        Me.Num_X_Dias.TabIndex = 53
        '
        'Rdb_Aso_Tbl_Asociacion
        '
        Me.Rdb_Aso_Tbl_Asociacion.AutoSize = True
        Me.Rdb_Aso_Tbl_Asociacion.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Aso_Tbl_Asociacion.Enabled = False
        Me.Rdb_Aso_Tbl_Asociacion.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Aso_Tbl_Asociacion.Location = New System.Drawing.Point(12, 244)
        Me.Rdb_Aso_Tbl_Asociacion.Name = "Rdb_Aso_Tbl_Asociacion"
        Me.Rdb_Aso_Tbl_Asociacion.Size = New System.Drawing.Size(159, 17)
        Me.Rdb_Aso_Tbl_Asociacion.TabIndex = 56
        Me.Rdb_Aso_Tbl_Asociacion.Text = "Prod. Asociados (carpetas)"
        Me.Rdb_Aso_Tbl_Asociacion.UseVisualStyleBackColor = False
        '
        'Rdb_Aso_Reemplazo
        '
        Me.Rdb_Aso_Reemplazo.AutoSize = True
        Me.Rdb_Aso_Reemplazo.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Aso_Reemplazo.Checked = True
        Me.Rdb_Aso_Reemplazo.Enabled = False
        Me.Rdb_Aso_Reemplazo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Aso_Reemplazo.Location = New System.Drawing.Point(12, 221)
        Me.Rdb_Aso_Reemplazo.Name = "Rdb_Aso_Reemplazo"
        Me.Rdb_Aso_Reemplazo.Size = New System.Drawing.Size(111, 17)
        Me.Rdb_Aso_Reemplazo.TabIndex = 55
        Me.Rdb_Aso_Reemplazo.TabStop = True
        Me.Rdb_Aso_Reemplazo.Text = "Prod. Reemplazo"
        Me.Rdb_Aso_Reemplazo.UseVisualStyleBackColor = False
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "database-control_pause.png")
        Me.Imagenes_32x32.Images.SetKeyName(1, "database-control_play.png")
        '
        'Frm_Rotacion_Procesar_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 322)
        Me.Controls.Add(Me.Rdb_Aso_Tbl_Asociacion)
        Me.Controls.Add(Me.Rdb_Aso_Reemplazo)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Num_X_Dias)
        Me.Controls.Add(Me.Chk_Porcesar_Stock_Asociados)
        Me.Controls.Add(Me.Chk_Incluir_Ventas_Entidades_Excluidas)
        Me.Controls.Add(Me.Barra_Progreso_Quiebres_Stock)
        Me.Controls.Add(Me.Lbl_Producto)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.TxtLog)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rotacion_Procesar_Productos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe Asistente de compras"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_X_Dias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Barra_Progreso_Quiebres_Stock As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Chk_Incluir_Ventas_Entidades_Excluidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Porcesar_Stock_Asociados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Procesar_Asociados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Num_X_Dias As System.Windows.Forms.NumericUpDown
    Friend WithEvents Rdb_Aso_Tbl_Asociacion As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Aso_Reemplazo As System.Windows.Forms.RadioButton
    Friend WithEvents Btn_Revisar_Log As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
End Class
