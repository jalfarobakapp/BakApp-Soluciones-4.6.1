<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_Treeview
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
        Me.Tree_ = New System.Windows.Forms.TreeView()
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.SuspendLayout()
        '
        'Tree_
        '
        Me.Tree_.AllowDrop = True
        Me.Tree_.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tree_.BackColor = System.Drawing.Color.White
        Me.Tree_.CheckBoxes = True
        Me.Tree_.ForeColor = System.Drawing.Color.Black
        Me.Tree_.Location = New System.Drawing.Point(12, 12)
        Me.Tree_.Name = "Tree_"
        Me.Tree_.Size = New System.Drawing.Size(286, 638)
        Me.Tree_.TabIndex = 1
        '
        'ListViewEx1
        '
        Me.ListViewEx1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx1.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx1.HideSelection = False
        Me.ListViewEx1.Location = New System.Drawing.Point(304, 12)
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(853, 638)
        Me.ListViewEx1.TabIndex = 2
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        '
        'Frm_Tickets_Treeview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 708)
        Me.Controls.Add(Me.ListViewEx1)
        Me.Controls.Add(Me.Tree_)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_Tickets_Treeview"
        Me.Text = "MetroForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tree_ As TreeView
    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
End Class
