<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_Lista_Tree
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
        Me.advTree1 = New DevComponents.AdvTree.AdvTree()
        Me.columnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.columnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.columnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.elementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        CType(Me.advTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'advTree1
        '
        Me.advTree1.AllowDrop = True
        Me.advTree1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advTree1.BackgroundStyle.Class = "TreeBorderKey"
        Me.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advTree1.Columns.Add(Me.columnHeader1)
        Me.advTree1.Columns.Add(Me.columnHeader2)
        Me.advTree1.Columns.Add(Me.columnHeader3)
        Me.advTree1.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle
        Me.advTree1.ExpandWidth = 14
        Me.advTree1.HotTracking = True
        Me.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advTree1.Location = New System.Drawing.Point(204, 28)
        Me.advTree1.Name = "advTree1"
        Me.advTree1.NodeStyle = Me.elementStyle1
        Me.advTree1.PathSeparator = ";"
        Me.advTree1.Size = New System.Drawing.Size(570, 317)
        Me.advTree1.Styles.Add(Me.elementStyle1)
        Me.advTree1.TabIndex = 1
        Me.advTree1.Text = "advTree1"
        '
        'columnHeader1
        '
        Me.columnHeader1.Name = "columnHeader1"
        Me.columnHeader1.Text = "Name"
        Me.columnHeader1.Width.Relative = 50
        '
        'columnHeader2
        '
        Me.columnHeader2.Name = "columnHeader2"
        Me.columnHeader2.Text = "Type"
        Me.columnHeader2.Width.Relative = 25
        '
        'columnHeader3
        '
        Me.columnHeader3.Name = "columnHeader3"
        Me.columnHeader3.Text = "Size"
        Me.columnHeader3.Width.Relative = 25
        '
        'elementStyle1
        '
        Me.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.elementStyle1.Name = "elementStyle1"
        Me.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Frm_Tickets_Lista_Tree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 572)
        Me.Controls.Add(Me.advTree1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_Tickets_Lista_Tree"
        Me.Text = "MetroForm"
        CType(Me.advTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents advTree1 As DevComponents.AdvTree.AdvTree
    Private WithEvents columnHeader1 As DevComponents.AdvTree.ColumnHeader
    Private WithEvents columnHeader2 As DevComponents.AdvTree.ColumnHeader
    Private WithEvents columnHeader3 As DevComponents.AdvTree.ColumnHeader
    Private WithEvents elementStyle1 As DevComponents.DotNetBar.ElementStyle
End Class
