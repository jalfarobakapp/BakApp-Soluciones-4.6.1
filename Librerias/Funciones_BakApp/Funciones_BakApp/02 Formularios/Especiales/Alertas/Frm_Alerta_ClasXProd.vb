Imports Funciones_BakApp
Imports DevComponents

Imports System.Windows.Forms
Imports System.Drawing

Public Class Frm_Alerta_ClasXProd
    Inherits DevComponents.DotNetBar.Balloon
    Public _SQL_Query As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

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
    Friend WithEvents GrupoDetalle As System.Windows.Forms.GroupBox
    Public WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LblProducto As DevComponents.DotNetBar.LabelX

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GrupoDetalle = New System.Windows.Forms.GroupBox
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.LblProducto = New DevComponents.DotNetBar.LabelX
        Me.GrupoDetalle.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrupoDetalle
        '
        Me.GrupoDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrupoDetalle.Controls.Add(Me.Grilla)
        Me.GrupoDetalle.ForeColor = System.Drawing.Color.Black
        Me.GrupoDetalle.Location = New System.Drawing.Point(12, 30)
        Me.GrupoDetalle.Name = "GrupoDetalle"
        Me.GrupoDetalle.Size = New System.Drawing.Size(584, 110)
        Me.GrupoDetalle.TabIndex = 40
        Me.GrupoDetalle.TabStop = False
        Me.GrupoDetalle.Text = "Clasificaciones del producto"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(3, 16)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(578, 91)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 27
        '
        'LblProducto
        '
        '
        '
        '
        Me.LblProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblProducto.Location = New System.Drawing.Point(18, 9)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(540, 23)
        Me.LblProducto.TabIndex = 41
        Me.LblProducto.Text = "PRODUCTO: "
        '
        'Frm_Alerta_ClasXProd
        '
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(604, 146)
        Me.ControlBox = True
        Me.Controls.Add(Me.LblProducto)
        Me.Controls.Add(Me.GrupoDetalle)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "Frm_Alerta_ClasXProd"
        Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
        Me.GrupoDetalle.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region




    Private Sub Frm_Alerta_ClasXProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Consulta_sql = "Select DescripcionBusqueda From Zw_Prod_Asociacion" & vbCrLf & _
                      "Where Codigo = '" & Codigo_abuscar & "' And Para_filtro = 0"

        LblProducto.Text = "PRODUCTO: " & trae_dato(tb, cn1, "NOKOPR", "MAEPR", "KOPR = '" & Codigo_abuscar & "'")
        With Grilla

            .DataSource = get_Tablas(Consulta_sql, cn1)
            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("DescripcionBusqueda").Width = 600
            .Columns("DescripcionBusqueda").HeaderText = "Descripción de clasificación"
            .Columns("DescripcionBusqueda").Visible = True

        End With
    End Sub
End Class
