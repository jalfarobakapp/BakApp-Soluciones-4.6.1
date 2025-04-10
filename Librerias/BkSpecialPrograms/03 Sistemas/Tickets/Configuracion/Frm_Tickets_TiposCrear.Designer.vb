<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Tickets_TiposCrear
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_TiposCrear))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_TidoDocCierra = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_ExigeDocCerrar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_CierraRaiz = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_EsTicketUnico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_NoEsTicketUnico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_RespuestaXDefectoCerrar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_PreguntaCreaNewTicket = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_CerrarAgenteSinPerm = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_BodModalXDefecto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_RespuestaXDefecto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_AsignadoGrupo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_AsignadoAgente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel_Productos = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Inc_Cantidades = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Inc_Fecha = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Inc_Hora = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Tipo_Cie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Area_Cie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Tipo_Cie = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Area_Cie = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Agente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Grupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Asignado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_Area = New DevComponents.DotNetBar.LabelX()
        Me.Chk_ExigeProducto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Tipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Tipo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel_Productos.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_TidoDocCierra)
        Me.GroupPanel1.Controls.Add(Me.Chk_ExigeDocCerrar)
        Me.GroupPanel1.Controls.Add(Me.Chk_CierraRaiz)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel1.Controls.Add(Me.Txt_RespuestaXDefectoCerrar)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Chk_PreguntaCreaNewTicket)
        Me.GroupPanel1.Controls.Add(Me.Chk_CerrarAgenteSinPerm)
        Me.GroupPanel1.Controls.Add(Me.Chk_BodModalXDefecto)
        Me.GroupPanel1.Controls.Add(Me.Txt_RespuestaXDefecto)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.Controls.Add(Me.Panel_Productos)
        Me.GroupPanel1.Controls.Add(Me.Txt_Tipo_Cie)
        Me.GroupPanel1.Controls.Add(Me.Txt_Area_Cie)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Tipo_Cie)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Area_Cie)
        Me.GroupPanel1.Controls.Add(Me.Txt_Agente)
        Me.GroupPanel1.Controls.Add(Me.Txt_Grupo)
        Me.GroupPanel1.Controls.Add(Me.Chk_Asignado)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Area)
        Me.GroupPanel1.Controls.Add(Me.Chk_ExigeProducto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Tipo)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Line1)
        Me.GroupPanel1.Controls.Add(Me.Line2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(568, 580)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Ficha tipo"
        '
        'Txt_TidoDocCierra
        '
        Me.Txt_TidoDocCierra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_TidoDocCierra.Border.Class = "TextBoxBorder"
        Me.Txt_TidoDocCierra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_TidoDocCierra.ButtonCustom.Image = CType(resources.GetObject("Txt_TidoDocCierra.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_TidoDocCierra.ButtonCustom.Visible = True
        Me.Txt_TidoDocCierra.ButtonCustom2.Image = CType(resources.GetObject("Txt_TidoDocCierra.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_TidoDocCierra.ButtonCustom2.Visible = True
        Me.Txt_TidoDocCierra.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_TidoDocCierra.ForeColor = System.Drawing.Color.Black
        Me.Txt_TidoDocCierra.Location = New System.Drawing.Point(257, 391)
        Me.Txt_TidoDocCierra.Name = "Txt_TidoDocCierra"
        Me.Txt_TidoDocCierra.PreventEnterBeep = True
        Me.Txt_TidoDocCierra.ReadOnly = True
        Me.Txt_TidoDocCierra.Size = New System.Drawing.Size(289, 22)
        Me.Txt_TidoDocCierra.TabIndex = 151
        Me.Txt_TidoDocCierra.TabStop = False
        '
        'Chk_ExigeDocCerrar
        '
        Me.Chk_ExigeDocCerrar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ExigeDocCerrar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ExigeDocCerrar.CheckBoxImageChecked = CType(resources.GetObject("Chk_ExigeDocCerrar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ExigeDocCerrar.FocusCuesEnabled = False
        Me.Chk_ExigeDocCerrar.ForeColor = System.Drawing.Color.Black
        Me.Chk_ExigeDocCerrar.Location = New System.Drawing.Point(19, 391)
        Me.Chk_ExigeDocCerrar.Name = "Chk_ExigeDocCerrar"
        Me.Chk_ExigeDocCerrar.Size = New System.Drawing.Size(259, 22)
        Me.Chk_ExigeDocCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ExigeDocCerrar.TabIndex = 150
        Me.Chk_ExigeDocCerrar.TabStop = False
        Me.Chk_ExigeDocCerrar.Text = "Exige adjuntar documento para cerrar Ticket"
        '
        'Chk_CierraRaiz
        '
        Me.Chk_CierraRaiz.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_CierraRaiz.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_CierraRaiz.CheckBoxImageChecked = CType(resources.GetObject("Chk_CierraRaiz.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_CierraRaiz.FocusCuesEnabled = False
        Me.Chk_CierraRaiz.ForeColor = System.Drawing.Color.Black
        Me.Chk_CierraRaiz.Location = New System.Drawing.Point(19, 372)
        Me.Chk_CierraRaiz.Name = "Chk_CierraRaiz"
        Me.Chk_CierraRaiz.Size = New System.Drawing.Size(277, 22)
        Me.Chk_CierraRaiz.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_CierraRaiz.TabIndex = 149
        Me.Chk_CierraRaiz.TabStop = False
        Me.Chk_CierraRaiz.Text = "Aceptar Ticket cierra Raiz"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_EsTicketUnico, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_NoEsTicketUnico, 0, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(19, 219)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(527, 46)
        Me.TableLayoutPanel2.TabIndex = 146
        '
        'Rdb_EsTicketUnico
        '
        Me.Rdb_EsTicketUnico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_EsTicketUnico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_EsTicketUnico.CheckBoxImageChecked = CType(resources.GetObject("Rdb_EsTicketUnico.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_EsTicketUnico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_EsTicketUnico.FocusCuesEnabled = False
        Me.Rdb_EsTicketUnico.ForeColor = System.Drawing.Color.Black
        Me.Rdb_EsTicketUnico.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_EsTicketUnico.Name = "Rdb_EsTicketUnico"
        Me.Rdb_EsTicketUnico.Size = New System.Drawing.Size(521, 17)
        Me.Rdb_EsTicketUnico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_EsTicketUnico.TabIndex = 11
        Me.Rdb_EsTicketUnico.TabStop = False
        Me.Rdb_EsTicketUnico.Text = "<b>Es Ticket único</b>: No permite crear otro ticket a partir de este, si permite" &
    " tener ticket anteriores"
        '
        'Rdb_NoEsTicketUnico
        '
        Me.Rdb_NoEsTicketUnico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_NoEsTicketUnico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_NoEsTicketUnico.CheckBoxImageChecked = CType(resources.GetObject("Rdb_NoEsTicketUnico.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_NoEsTicketUnico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_NoEsTicketUnico.FocusCuesEnabled = False
        Me.Rdb_NoEsTicketUnico.ForeColor = System.Drawing.Color.Black
        Me.Rdb_NoEsTicketUnico.Location = New System.Drawing.Point(3, 26)
        Me.Rdb_NoEsTicketUnico.Name = "Rdb_NoEsTicketUnico"
        Me.Rdb_NoEsTicketUnico.Size = New System.Drawing.Size(521, 17)
        Me.Rdb_NoEsTicketUnico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_NoEsTicketUnico.TabIndex = 12
        Me.Rdb_NoEsTicketUnico.TabStop = False
        Me.Rdb_NoEsTicketUnico.Text = "<b>No es Ticket único</b>: Se abrirá un ticket inmediatamente al aceptar este tip" &
    "o de requerimiento."
        '
        'Txt_RespuestaXDefectoCerrar
        '
        Me.Txt_RespuestaXDefectoCerrar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RespuestaXDefectoCerrar.Border.Class = "TextBoxBorder"
        Me.Txt_RespuestaXDefectoCerrar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RespuestaXDefectoCerrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_RespuestaXDefectoCerrar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RespuestaXDefectoCerrar.ForeColor = System.Drawing.Color.Black
        Me.Txt_RespuestaXDefectoCerrar.Location = New System.Drawing.Point(19, 511)
        Me.Txt_RespuestaXDefectoCerrar.MaxLength = 200
        Me.Txt_RespuestaXDefectoCerrar.Multiline = True
        Me.Txt_RespuestaXDefectoCerrar.Name = "Txt_RespuestaXDefectoCerrar"
        Me.Txt_RespuestaXDefectoCerrar.PreventEnterBeep = True
        Me.Txt_RespuestaXDefectoCerrar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_RespuestaXDefectoCerrar.Size = New System.Drawing.Size(527, 38)
        Me.Txt_RespuestaXDefectoCerrar.TabIndex = 18
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(19, 488)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(216, 17)
        Me.LabelX6.TabIndex = 145
        Me.LabelX6.Text = "Respuesta automática al cerrar Ticket"
        '
        'Chk_PreguntaCreaNewTicket
        '
        Me.Chk_PreguntaCreaNewTicket.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_PreguntaCreaNewTicket.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_PreguntaCreaNewTicket.CheckBoxImageChecked = CType(resources.GetObject("Chk_PreguntaCreaNewTicket.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_PreguntaCreaNewTicket.FocusCuesEnabled = False
        Me.Chk_PreguntaCreaNewTicket.ForeColor = System.Drawing.Color.Black
        Me.Chk_PreguntaCreaNewTicket.Location = New System.Drawing.Point(19, 336)
        Me.Chk_PreguntaCreaNewTicket.Name = "Chk_PreguntaCreaNewTicket"
        Me.Chk_PreguntaCreaNewTicket.Size = New System.Drawing.Size(398, 22)
        Me.Chk_PreguntaCreaNewTicket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_PreguntaCreaNewTicket.TabIndex = 15
        Me.Chk_PreguntaCreaNewTicket.TabStop = False
        Me.Chk_PreguntaCreaNewTicket.Text = "Preguntar si el usuario quiere crear otro ticket igual a este después de grabar"
        '
        'Chk_CerrarAgenteSinPerm
        '
        Me.Chk_CerrarAgenteSinPerm.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_CerrarAgenteSinPerm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_CerrarAgenteSinPerm.CheckBoxImageChecked = CType(resources.GetObject("Chk_CerrarAgenteSinPerm.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_CerrarAgenteSinPerm.FocusCuesEnabled = False
        Me.Chk_CerrarAgenteSinPerm.ForeColor = System.Drawing.Color.Black
        Me.Chk_CerrarAgenteSinPerm.Location = New System.Drawing.Point(19, 354)
        Me.Chk_CerrarAgenteSinPerm.Name = "Chk_CerrarAgenteSinPerm"
        Me.Chk_CerrarAgenteSinPerm.Size = New System.Drawing.Size(291, 22)
        Me.Chk_CerrarAgenteSinPerm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_CerrarAgenteSinPerm.TabIndex = 16
        Me.Chk_CerrarAgenteSinPerm.TabStop = False
        Me.Chk_CerrarAgenteSinPerm.Text = "Permitir cerrar Ticket por Agente sin permiso de cierre"
        '
        'Chk_BodModalXDefecto
        '
        Me.Chk_BodModalXDefecto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_BodModalXDefecto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_BodModalXDefecto.CheckBoxImageChecked = CType(resources.GetObject("Chk_BodModalXDefecto.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_BodModalXDefecto.FocusCuesEnabled = False
        Me.Chk_BodModalXDefecto.ForeColor = System.Drawing.Color.Black
        Me.Chk_BodModalXDefecto.Location = New System.Drawing.Point(127, 75)
        Me.Chk_BodModalXDefecto.Name = "Chk_BodModalXDefecto"
        Me.Chk_BodModalXDefecto.Size = New System.Drawing.Size(440, 22)
        Me.Chk_BodModalXDefecto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_BodModalXDefecto.TabIndex = 2
        Me.Chk_BodModalXDefecto.TabStop = False
        Me.Chk_BodModalXDefecto.Text = "Bodega por defecto será la bodega de la modalidad, de lo contrario elegir bodega"
        '
        'Txt_RespuestaXDefecto
        '
        Me.Txt_RespuestaXDefecto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RespuestaXDefecto.Border.Class = "TextBoxBorder"
        Me.Txt_RespuestaXDefecto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RespuestaXDefecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_RespuestaXDefecto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RespuestaXDefecto.ForeColor = System.Drawing.Color.Black
        Me.Txt_RespuestaXDefecto.Location = New System.Drawing.Point(19, 442)
        Me.Txt_RespuestaXDefecto.MaxLength = 200
        Me.Txt_RespuestaXDefecto.Multiline = True
        Me.Txt_RespuestaXDefecto.Name = "Txt_RespuestaXDefecto"
        Me.Txt_RespuestaXDefecto.PreventEnterBeep = True
        Me.Txt_RespuestaXDefecto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_RespuestaXDefecto.Size = New System.Drawing.Size(527, 40)
        Me.Txt_RespuestaXDefecto.TabIndex = 17
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_AsignadoGrupo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_AsignadoAgente, 0, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(19, 153)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(130, 51)
        Me.TableLayoutPanel1.TabIndex = 136
        '
        'Rdb_AsignadoGrupo
        '
        Me.Rdb_AsignadoGrupo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoGrupo.CheckBoxImageChecked = CType(resources.GetObject("Rdb_AsignadoGrupo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_AsignadoGrupo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoGrupo.FocusCuesEnabled = False
        Me.Rdb_AsignadoGrupo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoGrupo.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_AsignadoGrupo.Name = "Rdb_AsignadoGrupo"
        Me.Rdb_AsignadoGrupo.Size = New System.Drawing.Size(124, 19)
        Me.Rdb_AsignadoGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoGrupo.TabIndex = 7
        Me.Rdb_AsignadoGrupo.TabStop = False
        Me.Rdb_AsignadoGrupo.Text = "Asignar a un grupo"
        '
        'Rdb_AsignadoAgente
        '
        Me.Rdb_AsignadoAgente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoAgente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoAgente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_AsignadoAgente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_AsignadoAgente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoAgente.FocusCuesEnabled = False
        Me.Rdb_AsignadoAgente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoAgente.Location = New System.Drawing.Point(3, 28)
        Me.Rdb_AsignadoAgente.Name = "Rdb_AsignadoAgente"
        Me.Rdb_AsignadoAgente.Size = New System.Drawing.Size(124, 20)
        Me.Rdb_AsignadoAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoAgente.TabIndex = 9
        Me.Rdb_AsignadoAgente.TabStop = False
        Me.Rdb_AsignadoAgente.Text = "Asignar a un agente"
        '
        'Panel_Productos
        '
        Me.Panel_Productos.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Productos.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Panel_Productos.ColumnCount = 3
        Me.Panel_Productos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Panel_Productos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.Panel_Productos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.Panel_Productos.Controls.Add(Me.Chk_Inc_Cantidades, 0, 0)
        Me.Panel_Productos.Controls.Add(Me.Chk_Inc_Fecha, 1, 0)
        Me.Panel_Productos.Controls.Add(Me.Chk_Inc_Hora, 2, 0)
        Me.Panel_Productos.ForeColor = System.Drawing.Color.Black
        Me.Panel_Productos.Location = New System.Drawing.Point(35, 103)
        Me.Panel_Productos.Name = "Panel_Productos"
        Me.Panel_Productos.RowCount = 1
        Me.Panel_Productos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Panel_Productos.Size = New System.Drawing.Size(329, 22)
        Me.Panel_Productos.TabIndex = 135
        '
        'Chk_Inc_Cantidades
        '
        Me.Chk_Inc_Cantidades.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Inc_Cantidades.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Inc_Cantidades.CheckBoxImageChecked = CType(resources.GetObject("Chk_Inc_Cantidades.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Inc_Cantidades.FocusCuesEnabled = False
        Me.Chk_Inc_Cantidades.ForeColor = System.Drawing.Color.Black
        Me.Chk_Inc_Cantidades.Location = New System.Drawing.Point(4, 4)
        Me.Chk_Inc_Cantidades.Name = "Chk_Inc_Cantidades"
        Me.Chk_Inc_Cantidades.Size = New System.Drawing.Size(110, 13)
        Me.Chk_Inc_Cantidades.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Inc_Cantidades.TabIndex = 3
        Me.Chk_Inc_Cantidades.TabStop = False
        Me.Chk_Inc_Cantidades.Text = "Incluye cantidades"
        '
        'Chk_Inc_Fecha
        '
        Me.Chk_Inc_Fecha.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Inc_Fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Inc_Fecha.CheckBoxImageChecked = CType(resources.GetObject("Chk_Inc_Fecha.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Inc_Fecha.FocusCuesEnabled = False
        Me.Chk_Inc_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Chk_Inc_Fecha.Location = New System.Drawing.Point(121, 4)
        Me.Chk_Inc_Fecha.Name = "Chk_Inc_Fecha"
        Me.Chk_Inc_Fecha.Size = New System.Drawing.Size(90, 13)
        Me.Chk_Inc_Fecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Inc_Fecha.TabIndex = 4
        Me.Chk_Inc_Fecha.TabStop = False
        Me.Chk_Inc_Fecha.Text = "Incluye fecha"
        '
        'Chk_Inc_Hora
        '
        Me.Chk_Inc_Hora.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Inc_Hora.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Inc_Hora.CheckBoxImageChecked = CType(resources.GetObject("Chk_Inc_Hora.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Inc_Hora.FocusCuesEnabled = False
        Me.Chk_Inc_Hora.ForeColor = System.Drawing.Color.Black
        Me.Chk_Inc_Hora.Location = New System.Drawing.Point(218, 4)
        Me.Chk_Inc_Hora.Name = "Chk_Inc_Hora"
        Me.Chk_Inc_Hora.Size = New System.Drawing.Size(106, 14)
        Me.Chk_Inc_Hora.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Inc_Hora.TabIndex = 5
        Me.Chk_Inc_Hora.TabStop = False
        Me.Chk_Inc_Hora.Text = "Incluye hora"
        '
        'Txt_Tipo_Cie
        '
        Me.Txt_Tipo_Cie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo_Cie.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo_Cie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo_Cie.ButtonCustom.Image = CType(resources.GetObject("Txt_Tipo_Cie.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Tipo_Cie.ButtonCustom.Visible = True
        Me.Txt_Tipo_Cie.ButtonCustom2.Image = CType(resources.GetObject("Txt_Tipo_Cie.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Tipo_Cie.ButtonCustom2.Visible = True
        Me.Txt_Tipo_Cie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo_Cie.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo_Cie.Location = New System.Drawing.Point(162, 303)
        Me.Txt_Tipo_Cie.Name = "Txt_Tipo_Cie"
        Me.Txt_Tipo_Cie.PreventEnterBeep = True
        Me.Txt_Tipo_Cie.ReadOnly = True
        Me.Txt_Tipo_Cie.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Tipo_Cie.TabIndex = 14
        '
        'Txt_Area_Cie
        '
        Me.Txt_Area_Cie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Area_Cie.Border.Class = "TextBoxBorder"
        Me.Txt_Area_Cie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Area_Cie.ButtonCustom.Image = CType(resources.GetObject("Txt_Area_Cie.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Area_Cie.ButtonCustom.Visible = True
        Me.Txt_Area_Cie.ButtonCustom2.Image = CType(resources.GetObject("Txt_Area_Cie.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Area_Cie.ButtonCustom2.Visible = True
        Me.Txt_Area_Cie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Area_Cie.ForeColor = System.Drawing.Color.Black
        Me.Txt_Area_Cie.Location = New System.Drawing.Point(162, 274)
        Me.Txt_Area_Cie.Name = "Txt_Area_Cie"
        Me.Txt_Area_Cie.PreventEnterBeep = True
        Me.Txt_Area_Cie.ReadOnly = True
        Me.Txt_Area_Cie.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Area_Cie.TabIndex = 13
        '
        'Lbl_Tipo_Cie
        '
        Me.Lbl_Tipo_Cie.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo_Cie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo_Cie.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo_Cie.Location = New System.Drawing.Point(22, 300)
        Me.Lbl_Tipo_Cie.Name = "Lbl_Tipo_Cie"
        Me.Lbl_Tipo_Cie.Size = New System.Drawing.Size(130, 23)
        Me.Lbl_Tipo_Cie.TabIndex = 130
        Me.Lbl_Tipo_Cie.Text = "Tipo (Cierre Tieckets)"
        '
        'Lbl_Area_Cie
        '
        Me.Lbl_Area_Cie.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Area_Cie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Area_Cie.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Area_Cie.Location = New System.Drawing.Point(22, 271)
        Me.Lbl_Area_Cie.Name = "Lbl_Area_Cie"
        Me.Lbl_Area_Cie.Size = New System.Drawing.Size(134, 23)
        Me.Lbl_Area_Cie.TabIndex = 129
        Me.Lbl_Area_Cie.Text = "Area (Cierre Tickets)"
        '
        'Txt_Agente
        '
        Me.Txt_Agente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Agente.Border.Class = "TextBoxBorder"
        Me.Txt_Agente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Agente.ButtonCustom.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Agente.ButtonCustom.Visible = True
        Me.Txt_Agente.ButtonCustom2.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Agente.ButtonCustom2.Visible = True
        Me.Txt_Agente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Agente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Agente.Location = New System.Drawing.Point(162, 182)
        Me.Txt_Agente.Name = "Txt_Agente"
        Me.Txt_Agente.PreventEnterBeep = True
        Me.Txt_Agente.ReadOnly = True
        Me.Txt_Agente.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Agente.TabIndex = 10
        Me.Txt_Agente.TabStop = False
        '
        'Txt_Grupo
        '
        Me.Txt_Grupo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Grupo.Border.Class = "TextBoxBorder"
        Me.Txt_Grupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Grupo.ButtonCustom.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Grupo.ButtonCustom.Visible = True
        Me.Txt_Grupo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Grupo.ButtonCustom2.Visible = True
        Me.Txt_Grupo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Grupo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Grupo.Location = New System.Drawing.Point(162, 153)
        Me.Txt_Grupo.Name = "Txt_Grupo"
        Me.Txt_Grupo.PreventEnterBeep = True
        Me.Txt_Grupo.ReadOnly = True
        Me.Txt_Grupo.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Grupo.TabIndex = 8
        Me.Txt_Grupo.TabStop = False
        '
        'Chk_Asignado
        '
        Me.Chk_Asignado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Asignado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Asignado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Asignado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Asignado.FocusCuesEnabled = False
        Me.Chk_Asignado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Asignado.Location = New System.Drawing.Point(19, 131)
        Me.Chk_Asignado.Name = "Chk_Asignado"
        Me.Chk_Asignado.Size = New System.Drawing.Size(291, 22)
        Me.Chk_Asignado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Asignado.TabIndex = 6
        Me.Chk_Asignado.TabStop = False
        Me.Chk_Asignado.Text = "ASIGNAR POR DEFECTO EL REQUERIMIENTO A:"
        '
        'Lbl_Area
        '
        Me.Lbl_Area.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Area.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Area.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Area.Location = New System.Drawing.Point(19, 3)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(516, 23)
        Me.Lbl_Area.TabIndex = 121
        Me.Lbl_Area.Text = "AREA: XXXXXXXXXXWWWWWWWWWYYYYYYYYSSSSSSSS"
        '
        'Chk_ExigeProducto
        '
        Me.Chk_ExigeProducto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ExigeProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ExigeProducto.CheckBoxImageChecked = CType(resources.GetObject("Chk_ExigeProducto.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ExigeProducto.FocusCuesEnabled = False
        Me.Chk_ExigeProducto.ForeColor = System.Drawing.Color.Black
        Me.Chk_ExigeProducto.Location = New System.Drawing.Point(19, 75)
        Me.Chk_ExigeProducto.Name = "Chk_ExigeProducto"
        Me.Chk_ExigeProducto.Size = New System.Drawing.Size(91, 22)
        Me.Chk_ExigeProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ExigeProducto.TabIndex = 1
        Me.Chk_ExigeProducto.TabStop = False
        Me.Chk_ExigeProducto.Text = "Exige producto"
        '
        'Txt_Tipo
        '
        Me.Txt_Tipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tipo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo.Location = New System.Drawing.Point(127, 47)
        Me.Txt_Tipo.MaxLength = 50
        Me.Txt_Tipo.Name = "Txt_Tipo"
        Me.Txt_Tipo.PreventEnterBeep = True
        Me.Txt_Tipo.Size = New System.Drawing.Size(419, 22)
        Me.Txt_Tipo.TabIndex = 0
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(19, 46)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(102, 23)
        Me.LabelX3.TabIndex = 49
        Me.LabelX3.Text = "Tipo requerimiento"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(19, 419)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(216, 23)
        Me.LabelX2.TabIndex = 140
        Me.LabelX2.Text = "Respuesta automática al aceptar Ticket"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(19, 200)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(527, 23)
        Me.Line1.TabIndex = 147
        Me.Line1.Text = "Line1"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.Transparent
        Me.Line2.ForeColor = System.Drawing.Color.Black
        Me.Line2.Location = New System.Drawing.Point(19, 322)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(527, 23)
        Me.Line2.TabIndex = 148
        Me.Line2.Text = "Line2"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Tipo, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 601)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(588, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 115
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Crear_Tipo
        '
        Me.Btn_Crear_Tipo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Tipo.Image = CType(resources.GetObject("Btn_Crear_Tipo.Image"), System.Drawing.Image)
        Me.Btn_Crear_Tipo.ImageAlt = CType(resources.GetObject("Btn_Crear_Tipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Tipo.Name = "Btn_Crear_Tipo"
        Me.Btn_Crear_Tipo.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Grabar"
        '
        'Frm_Tickets_TiposCrear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 642)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_TiposCrear"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIPO DE REQUERIMIENTO"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel_Productos.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Tipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_ExigeProducto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Tipo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Area As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Agente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Grupo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_AsignadoGrupo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_AsignadoAgente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Asignado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Tipo_Cie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Area_Cie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Tipo_Cie As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Area_Cie As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Inc_Fecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Inc_Cantidades As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Inc_Hora As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel_Productos As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RespuestaXDefecto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_BodModalXDefecto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_CerrarAgenteSinPerm As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_PreguntaCreaNewTicket As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_RespuestaXDefectoCerrar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Rdb_EsTicketUnico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_NoEsTicketUnico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_ExigeDocCerrar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_CierraRaiz As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_TidoDocCierra As DevComponents.DotNetBar.Controls.TextBoxX
End Class
