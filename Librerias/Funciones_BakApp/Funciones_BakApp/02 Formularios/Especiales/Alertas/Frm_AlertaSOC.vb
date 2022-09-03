Imports Funciones_BakApp
Imports DevComponents

Imports System.Windows.Forms
Imports System.Drawing

Public Class Frm_AlertaSOC
    Inherits DevComponents.DotNetBar.Balloon
    Public _SQL_Query As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Imagen_ As DevComponents.DotNetBar.Controls.ReflectionImage
    Public WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AlertaSOC))
        Me.Imagen_ = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.SuspendLayout()
        '
        'Imagen_
        '
        Me.Imagen_.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Imagen_.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_.Image = CType(resources.GetObject("Imagen_.Image"), System.Drawing.Image)
        Me.Imagen_.Location = New System.Drawing.Point(12, 12)
        Me.Imagen_.Name = "Imagen_"
        Me.Imagen_.Size = New System.Drawing.Size(66, 100)
        Me.Imagen_.TabIndex = 8
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(84, 22)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(394, 90)
        Me.LabelX1.TabIndex = 9
        Me.LabelX1.Text = "."
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'Frm_AlertaSOC
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(490, 125)
        Me.ControlBox = True
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Imagen_)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "Frm_AlertaSOC"
        Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
        Me.ResumeLayout(False)

    End Sub

#End Region



   
End Class
