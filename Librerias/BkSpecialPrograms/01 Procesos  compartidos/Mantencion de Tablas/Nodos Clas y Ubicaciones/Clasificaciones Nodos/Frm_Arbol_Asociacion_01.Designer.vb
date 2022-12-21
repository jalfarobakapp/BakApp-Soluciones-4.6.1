<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Arbol_Asociacion_01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Arbol_Asociacion_01))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TxtFullPath = New System.Windows.Forms.TextBox()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExpandirTodo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnContraerTodo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Refrescar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnMantencion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_MoverCarpetas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_RearmarArbol = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnImprimirArbol = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportarCsv = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarAsociaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Chk_Ver_Clas_Unicas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.ForeColor = System.Drawing.Color.Black
        Me.TreeView1.ImageIndex = 3
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(3, 63)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 3
        Me.TreeView1.Size = New System.Drawing.Size(590, 422)
        Me.TreeView1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "table_stack.png")
        Me.ImageList1.Images.SetKeyName(3, "folder.png")
        Me.ImageList1.Images.SetKeyName(4, "folder_open.png")
        Me.ImageList1.Images.SetKeyName(5, "folder.png")
        Me.ImageList1.Images.SetKeyName(6, "folder_open.png")
        '
        'TxtFullPath
        '
        Me.TxtFullPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFullPath.BackColor = System.Drawing.Color.White
        Me.TxtFullPath.ForeColor = System.Drawing.Color.Black
        Me.TxtFullPath.Location = New System.Drawing.Point(3, 12)
        Me.TxtFullPath.Multiline = True
        Me.TxtFullPath.Name = "TxtFullPath"
        Me.TxtFullPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtFullPath.Size = New System.Drawing.Size(590, 45)
        Me.TxtFullPath.TabIndex = 2
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnExpandirTodo, Me.BtnContraerTodo, Me.Btn_Refrescar, Me.BtnMantencion, Me.Btn_MoverCarpetas, Me.Btn_RearmarArbol, Me.BtnImprimirArbol, Me.BtnExportarCsv})
        Me.Bar2.Location = New System.Drawing.Point(0, 520)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(593, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 33
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlt = CType(resources.GetObject("BtnGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'BtnExpandirTodo
        '
        Me.BtnExpandirTodo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExpandirTodo.ForeColor = System.Drawing.Color.Black
        Me.BtnExpandirTodo.Image = CType(resources.GetObject("BtnExpandirTodo.Image"), System.Drawing.Image)
        Me.BtnExpandirTodo.ImageAlt = CType(resources.GetObject("BtnExpandirTodo.ImageAlt"), System.Drawing.Image)
        Me.BtnExpandirTodo.Name = "BtnExpandirTodo"
        Me.BtnExpandirTodo.Tooltip = "Expandir todo el árbol"
        '
        'BtnContraerTodo
        '
        Me.BtnContraerTodo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnContraerTodo.ForeColor = System.Drawing.Color.Black
        Me.BtnContraerTodo.Image = CType(resources.GetObject("BtnContraerTodo.Image"), System.Drawing.Image)
        Me.BtnContraerTodo.ImageAlt = CType(resources.GetObject("BtnContraerTodo.ImageAlt"), System.Drawing.Image)
        Me.BtnContraerTodo.Name = "BtnContraerTodo"
        Me.BtnContraerTodo.Tooltip = "Contraer todo el árbol"
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refrescar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Refrescar.Image = CType(resources.GetObject("Btn_Refrescar.Image"), System.Drawing.Image)
        Me.Btn_Refrescar.ImageAlt = CType(resources.GetObject("Btn_Refrescar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Tooltip = "Actualizar información"
        '
        'BtnMantencion
        '
        Me.BtnMantencion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnMantencion.ForeColor = System.Drawing.Color.Black
        Me.BtnMantencion.Image = CType(resources.GetObject("BtnMantencion.Image"), System.Drawing.Image)
        Me.BtnMantencion.ImageAlt = CType(resources.GetObject("BtnMantencion.ImageAlt"), System.Drawing.Image)
        Me.BtnMantencion.Name = "BtnMantencion"
        Me.BtnMantencion.Tooltip = "Mantención de clasificaciones"
        Me.BtnMantencion.Visible = False
        '
        'Btn_MoverCarpetas
        '
        Me.Btn_MoverCarpetas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_MoverCarpetas.ForeColor = System.Drawing.Color.Black
        Me.Btn_MoverCarpetas.Image = CType(resources.GetObject("Btn_MoverCarpetas.Image"), System.Drawing.Image)
        Me.Btn_MoverCarpetas.ImageAlt = CType(resources.GetObject("Btn_MoverCarpetas.ImageAlt"), System.Drawing.Image)
        Me.Btn_MoverCarpetas.Name = "Btn_MoverCarpetas"
        Me.Btn_MoverCarpetas.Tooltip = "Mover carpetas"
        Me.Btn_MoverCarpetas.Visible = False
        '
        'Btn_RearmarArbol
        '
        Me.Btn_RearmarArbol.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_RearmarArbol.ForeColor = System.Drawing.Color.Black
        Me.Btn_RearmarArbol.Image = CType(resources.GetObject("Btn_RearmarArbol.Image"), System.Drawing.Image)
        Me.Btn_RearmarArbol.ImageAlt = CType(resources.GetObject("Btn_RearmarArbol.ImageAlt"), System.Drawing.Image)
        Me.Btn_RearmarArbol.Name = "Btn_RearmarArbol"
        Me.Btn_RearmarArbol.Tooltip = "Volver a re-clasificar productos"
        Me.Btn_RearmarArbol.Visible = False
        '
        'BtnImprimirArbol
        '
        Me.BtnImprimirArbol.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImprimirArbol.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimirArbol.Image = CType(resources.GetObject("BtnImprimirArbol.Image"), System.Drawing.Image)
        Me.BtnImprimirArbol.ImageAlt = CType(resources.GetObject("BtnImprimirArbol.ImageAlt"), System.Drawing.Image)
        Me.BtnImprimirArbol.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnImprimirArbol.Name = "BtnImprimirArbol"
        Me.BtnImprimirArbol.Tooltip = "Exportar a .txt"
        '
        'BtnExportarCsv
        '
        Me.BtnExportarCsv.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarCsv.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarCsv.Image = CType(resources.GetObject("BtnExportarCsv.Image"), System.Drawing.Image)
        Me.BtnExportarCsv.ImageAlt = CType(resources.GetObject("BtnExportarCsv.ImageAlt"), System.Drawing.Image)
        Me.BtnExportarCsv.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnExportarCsv.Name = "BtnExportarCsv"
        Me.BtnExportarCsv.Tooltip = "Exportar a .csv"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarAsociaciónToolStripMenuItem, Me.EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(407, 48)
        '
        'AgregarAsociaciónToolStripMenuItem
        '
        Me.AgregarAsociaciónToolStripMenuItem.Name = "AgregarAsociaciónToolStripMenuItem"
        Me.AgregarAsociaciónToolStripMenuItem.Size = New System.Drawing.Size(406, 22)
        Me.AgregarAsociaciónToolStripMenuItem.Text = "Crear nueva asociaón"
        '
        'EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem
        '
        Me.EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem.Name = "EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem"
        Me.EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem.Size = New System.Drawing.Size(406, 22)
        Me.EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem.Text = "Eliminar asociación (solo si ha sido creada desde este asistente)"
        Me.EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem.Visible = False
        '
        'Chk_Ver_Clas_Unicas
        '
        Me.Chk_Ver_Clas_Unicas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_Ver_Clas_Unicas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Ver_Clas_Unicas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ver_Clas_Unicas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ver_Clas_Unicas.Location = New System.Drawing.Point(3, 491)
        Me.Chk_Ver_Clas_Unicas.Name = "Chk_Ver_Clas_Unicas"
        Me.Chk_Ver_Clas_Unicas.Size = New System.Drawing.Size(224, 23)
        Me.Chk_Ver_Clas_Unicas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ver_Clas_Unicas.TabIndex = 34
        Me.Chk_Ver_Clas_Unicas.Text = "Ver clasificaciones únicas"
        '
        'Frm_Arbol_Asociacion_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 561)
        Me.Controls.Add(Me.Chk_Ver_Clas_Unicas)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.TxtFullPath)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(609, 39)
        Me.Name = "Frm_Arbol_Asociacion_01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ARBOL DE ASOCIACIONES DE PRODUCTOS"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TxtFullPath As System.Windows.Forms.TextBox
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarAsociaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnExportarCsv As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Public WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnImprimirArbol As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents BtnExpandirTodo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnContraerTodo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnMantencion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Refrescar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_MoverCarpetas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_RearmarArbol As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Ver_Clas_Unicas As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
