Imports Funciones_BakApp
Imports DevComponents

Imports System.Windows.Forms
Imports System.Drawing

Public Class AlertCustom
    Inherits DevComponents.DotNetBar.Balloon
    Public _SQL_Query As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue)

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents GrupoDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents LblConsolidadoUd1 As System.Windows.Forms.Label
    Friend WithEvents LblConsolidadoUd2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents reflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertCustom))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.reflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.GrupoDetalle = New System.Windows.Forms.GroupBox
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.label2 = New System.Windows.Forms.Label
        Me.LblConsolidadoUd1 = New System.Windows.Forms.Label
        Me.LblConsolidadoUd2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrupoDetalle.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'reflectionImage1
        '
        Me.reflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.reflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.reflectionImage1.Image = CType(resources.GetObject("reflectionImage1.Image"), System.Drawing.Image)
        Me.reflectionImage1.Location = New System.Drawing.Point(412, 41)
        Me.reflectionImage1.Name = "reflectionImage1"
        Me.reflectionImage1.Size = New System.Drawing.Size(66, 100)
        Me.reflectionImage1.TabIndex = 8
        '
        'GrupoDetalle
        '
        Me.GrupoDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrupoDetalle.Controls.Add(Me.Grilla)
        Me.GrupoDetalle.ForeColor = System.Drawing.Color.Black
        Me.GrupoDetalle.Location = New System.Drawing.Point(12, 12)
        Me.GrupoDetalle.Name = "GrupoDetalle"
        Me.GrupoDetalle.Size = New System.Drawing.Size(383, 184)
        Me.GrupoDetalle.TabIndex = 39
        Me.GrupoDetalle.TabStop = False
        Me.GrupoDetalle.Text = "Stock por bodega"
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
        Me.Grilla.Size = New System.Drawing.Size(377, 165)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 27
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Firebrick
        Me.label2.Location = New System.Drawing.Point(12, 199)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(205, 16)
        Me.label2.TabIndex = 40
        Me.label2.Text = "Stock físico consolidado Ud 1"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblConsolidadoUd1
        '
        Me.LblConsolidadoUd1.BackColor = System.Drawing.Color.Transparent
        Me.LblConsolidadoUd1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsolidadoUd1.ForeColor = System.Drawing.Color.Firebrick
        Me.LblConsolidadoUd1.Location = New System.Drawing.Point(235, 198)
        Me.LblConsolidadoUd1.Name = "LblConsolidadoUd1"
        Me.LblConsolidadoUd1.Size = New System.Drawing.Size(67, 19)
        Me.LblConsolidadoUd1.TabIndex = 41
        Me.LblConsolidadoUd1.Text = "0"
        Me.LblConsolidadoUd1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblConsolidadoUd2
        '
        Me.LblConsolidadoUd2.BackColor = System.Drawing.Color.Transparent
        Me.LblConsolidadoUd2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsolidadoUd2.ForeColor = System.Drawing.Color.Firebrick
        Me.LblConsolidadoUd2.Location = New System.Drawing.Point(235, 215)
        Me.LblConsolidadoUd2.Name = "LblConsolidadoUd2"
        Me.LblConsolidadoUd2.Size = New System.Drawing.Size(67, 16)
        Me.LblConsolidadoUd2.TabIndex = 43
        Me.LblConsolidadoUd2.Text = "0"
        Me.LblConsolidadoUd2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Firebrick
        Me.Label3.Location = New System.Drawing.Point(12, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 16)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Stock devengado consolidado Ud 1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AlertCustom
        '
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(490, 248)
        Me.ControlBox = True
        Me.Controls.Add(Me.LblConsolidadoUd2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblConsolidadoUd1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.GrupoDetalle)
        Me.Controls.Add(Me.reflectionImage1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "AlertCustom"
        Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
        Me.GrupoDetalle.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    

    Public Sub LlenarStockPorProducto()

        Consulta_sql = My.Resources._Rec_Alertas.Stock_productos_por_emp_suc_bod
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", Codigo_abuscar)

        With Grilla

            .DataSource = get_Tablas(Consulta_sql, cn1)

            OcultarEncabezadoGrilla(Grilla)

            .Columns("SUC_BOD").Visible = True
            .Columns("SUC_BOD").HeaderText = "Suc-Bod"
            .Columns("SUC_BOD").Width = 60

            .Columns("NOKOBO").Visible = True
            .Columns("NOKOBO").HeaderText = "Bodega"
            .Columns("NOKOBO").Width = 160

            .Columns("STOCKUD1").Visible = True
            .Columns("STOCKUD1").HeaderText = "Físico"
            .Columns("STOCKUD1").Width = 60
            .Columns("STOCKUD1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STOCKUD1").DefaultCellStyle.Format = "###,##.##"
            .Columns("STOCKUD1").ToolTipText = "Stock Ud1"

            .Columns("STDV1").Visible = True
            .Columns("STDV1").HeaderText = "Devengado"
            .Columns("STDV1").Width = 70
            .Columns("STDV1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STDV1").DefaultCellStyle.Format = "###,##.##"
            .Columns("STDV1").ToolTipText = "Stock Devengado"

            '.Columns("STOCKUD2").Visible = True
            '.Columns("STOCKUD2").HeaderText = "Stock Físico"
            '.Columns("STOCKUD2").Width = 55
            '.Columns("STOCKUD2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("STOCKUD2").DefaultCellStyle.Format = "###,##.##"
            '.Columns("STOCKUD2").ToolTipText = "Stock Ud2"
            'STDV1

        End With
        Dim StockUd1, StockUd2 As Double

        StockUd1 = trae_dato(tb, cn1, "SUM(STFI1)", "MAEST", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & Codigo_abuscar & "'", True)
        StockUd2 = trae_dato(tb, cn1, "SUM(STDV1)", "MAEST", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & Codigo_abuscar & "'", True)
        LblConsolidadoUd1.Text = FormatNumber(StockUd1, 2)
        LblConsolidadoUd2.Text = FormatNumber(StockUd2, 2)

    End Sub

    Private Sub AlertCustom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarStockPorProducto()
    End Sub
End Class
