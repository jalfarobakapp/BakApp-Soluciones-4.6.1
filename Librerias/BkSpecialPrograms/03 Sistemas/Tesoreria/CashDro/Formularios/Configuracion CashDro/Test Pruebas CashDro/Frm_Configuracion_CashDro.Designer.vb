<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Configuracion_CashDro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Configuracion_CashDro))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Btn_Consultar_Operacion = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Cancelar_Solicitud = New DevComponents.DotNetBar.ButtonItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Respuesta_Arturito = New System.Windows.Forms.TextBox
        Me.Txt_Peticion_Venta_Valor = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_operationId = New System.Windows.Forms.TextBox
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Consultar_Operacion, Me.Btn_Cancelar_Solicitud})
        Me.Bar1.Location = New System.Drawing.Point(0, 307)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(670, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 39
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Consultar_Operacion
        '
        Me.Btn_Consultar_Operacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Consultar_Operacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Consultar_Operacion.Image = CType(resources.GetObject("Btn_Consultar_Operacion.Image"), System.Drawing.Image)
        Me.Btn_Consultar_Operacion.Name = "Btn_Consultar_Operacion"
        Me.Btn_Consultar_Operacion.Text = "GRABAR"
        Me.Btn_Consultar_Operacion.Tooltip = "(F3)"
        '
        'Btn_Cancelar_Solicitud
        '
        Me.Btn_Cancelar_Solicitud.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar_Solicitud.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar_Solicitud.Image = CType(resources.GetObject("Btn_Cancelar_Solicitud.Image"), System.Drawing.Image)
        Me.Btn_Cancelar_Solicitud.Name = "Btn_Cancelar_Solicitud"
        Me.Btn_Cancelar_Solicitud.Text = "Documentos pendientes (Hoy)"
        Me.Btn_Cancelar_Solicitud.Tooltip = "(F5)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Respuesta de Arturito"
        '
        'Txt_Respuesta_Arturito
        '
        Me.Txt_Respuesta_Arturito.Location = New System.Drawing.Point(149, 115)
        Me.Txt_Respuesta_Arturito.Multiline = True
        Me.Txt_Respuesta_Arturito.Name = "Txt_Respuesta_Arturito"
        Me.Txt_Respuesta_Arturito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Respuesta_Arturito.Size = New System.Drawing.Size(513, 173)
        Me.Txt_Respuesta_Arturito.TabIndex = 44
        '
        'Txt_Peticion_Venta_Valor
        '
        Me.Txt_Peticion_Venta_Valor.Location = New System.Drawing.Point(222, 40)
        Me.Txt_Peticion_Venta_Valor.Name = "Txt_Peticion_Venta_Valor"
        Me.Txt_Peticion_Venta_Valor.Size = New System.Drawing.Size(90, 22)
        Me.Txt_Peticion_Venta_Valor.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Petición operacion, Venta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(174, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Valor $"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Id"
        '
        'Txt_operationId
        '
        Me.Txt_operationId.Location = New System.Drawing.Point(72, 76)
        Me.Txt_operationId.Name = "Txt_operationId"
        Me.Txt_operationId.Size = New System.Drawing.Size(90, 22)
        Me.Txt_operationId.TabIndex = 65
        '
        'Frm_Configuracion_CashDro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 348)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_operationId)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Respuesta_Arturito)
        Me.Controls.Add(Me.Txt_Peticion_Venta_Valor)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Frm_Configuracion_CashDro"
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Consultar_Operacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar_Solicitud As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Respuesta_Arturito As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Peticion_Venta_Valor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_operationId As System.Windows.Forms.TextBox
End Class
