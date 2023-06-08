<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Modulo_Programas_Especiales
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Programas_Especiales))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Demonio = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnSQL2Excel = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnDTE2PDF = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnCorreos_SMTP = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_CRV_Control_Ruta_Vehiculos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Etiquetas_De_Barra = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnCrearFormatos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_DTE_Respuestas_XML = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Precios_PrestaShop = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Huella = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Pocket_PC = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Archivador = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Cierre_Reactivacion_Documentos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Habilitar_Nvv_Para_Facturar = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Patentes_rvm = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCambiarDeUsuario = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.DragDropSupport = True
        Me.MetroTilePanel1.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialOtros})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 55)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(844, 619)
        Me.MetroTilePanel1.TabIndex = 10
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(1000, 550)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Demonio, Me.BtnSQL2Excel, Me.BtnDTE2PDF, Me.BtnCorreos_SMTP, Me.Btn_CRV_Control_Ruta_Vehiculos, Me.Btn_Etiquetas_De_Barra, Me.BtnCrearFormatos, Me.Btn_DTE_Respuestas_XML, Me.Btn_Precios_PrestaShop, Me.Btn_Huella, Me.Btn_Pocket_PC, Me.Btn_Archivador, Me.Btn_Cierre_Reactivacion_Documentos, Me.Btn_Habilitar_Nvv_Para_Facturar, Me.Btn_Patentes_rvm})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Demonio
        '
        Me.Btn_Demonio.Image = CType(resources.GetObject("Btn_Demonio.Image"), System.Drawing.Image)
        Me.Btn_Demonio.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Demonio.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Demonio.Name = "Btn_Demonio"
        Me.Btn_Demonio.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Demonio.Text = "<font size=""+4""><b>DEMONIO</b></font><br/><font size=""-1"">Ingresar al asistente d" &
    "e impresión de picking automatico...</font>"
        Me.Btn_Demonio.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_Demonio.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Demonio.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Demonio.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Demonio.TileStyle.PaddingBottom = 4
        Me.Btn_Demonio.TileStyle.PaddingLeft = 4
        Me.Btn_Demonio.TileStyle.PaddingRight = 4
        Me.Btn_Demonio.TileStyle.PaddingTop = 4
        Me.Btn_Demonio.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Demonio.TitleText = "BakApp"
        '
        'BtnSQL2Excel
        '
        Me.BtnSQL2Excel.Image = CType(resources.GetObject("BtnSQL2Excel.Image"), System.Drawing.Image)
        Me.BtnSQL2Excel.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnSQL2Excel.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSQL2Excel.Name = "BtnSQL2Excel"
        Me.BtnSQL2Excel.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSQL2Excel.Text = "<font size=""+4""><b>SQL2Excel</b></font><br/><font size=""-1"">Generar Query y Expor" &
    "tar a Excel</font>"
        Me.BtnSQL2Excel.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.BtnSQL2Excel.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnSQL2Excel.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnSQL2Excel.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnSQL2Excel.TileStyle.BackColorGradientAngle = 45
        Me.BtnSQL2Excel.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnSQL2Excel.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnSQL2Excel.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnSQL2Excel.TileStyle.PaddingBottom = 4
        Me.BtnSQL2Excel.TileStyle.PaddingLeft = 4
        Me.BtnSQL2Excel.TileStyle.PaddingRight = 4
        Me.BtnSQL2Excel.TileStyle.PaddingTop = 4
        Me.BtnSQL2Excel.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnSQL2Excel.TitleText = "BakApp"
        '
        'BtnDTE2PDF
        '
        Me.BtnDTE2PDF.Image = CType(resources.GetObject("BtnDTE2PDF.Image"), System.Drawing.Image)
        Me.BtnDTE2PDF.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnDTE2PDF.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnDTE2PDF.Name = "BtnDTE2PDF"
        Me.BtnDTE2PDF.SymbolColor = System.Drawing.Color.Empty
        Me.BtnDTE2PDF.Text = "<font size=""+4""><b>DTE2PDF</b></font><br/><font size=""-1"">Leer archivo DTE.xml e " &
    "Imprimir factura</font>"
        Me.BtnDTE2PDF.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnDTE2PDF.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnDTE2PDF.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnDTE2PDF.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnDTE2PDF.TileStyle.BackColorGradientAngle = 45
        Me.BtnDTE2PDF.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnDTE2PDF.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnDTE2PDF.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnDTE2PDF.TileStyle.PaddingBottom = 4
        Me.BtnDTE2PDF.TileStyle.PaddingLeft = 4
        Me.BtnDTE2PDF.TileStyle.PaddingRight = 4
        Me.BtnDTE2PDF.TileStyle.PaddingTop = 4
        Me.BtnDTE2PDF.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnDTE2PDF.TitleText = "BakApp"
        '
        'BtnCorreos_SMTP
        '
        Me.BtnCorreos_SMTP.Image = CType(resources.GetObject("BtnCorreos_SMTP.Image"), System.Drawing.Image)
        Me.BtnCorreos_SMTP.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnCorreos_SMTP.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCorreos_SMTP.Name = "BtnCorreos_SMTP"
        Me.BtnCorreos_SMTP.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCorreos_SMTP.Text = "<font size=""+4""><b>CONF. CORREOS</b></font><br/><font size=""-1"">Correos SMTP<br/>" &
    "Correos automaticos</font>"
        Me.BtnCorreos_SMTP.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnCorreos_SMTP.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnCorreos_SMTP.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCorreos_SMTP.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCorreos_SMTP.TileStyle.BackColorGradientAngle = 45
        Me.BtnCorreos_SMTP.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCorreos_SMTP.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCorreos_SMTP.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnCorreos_SMTP.TileStyle.PaddingBottom = 4
        Me.BtnCorreos_SMTP.TileStyle.PaddingLeft = 4
        Me.BtnCorreos_SMTP.TileStyle.PaddingRight = 4
        Me.BtnCorreos_SMTP.TileStyle.PaddingTop = 4
        Me.BtnCorreos_SMTP.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCorreos_SMTP.TitleText = "BakApp"
        '
        'Btn_CRV_Control_Ruta_Vehiculos
        '
        Me.Btn_CRV_Control_Ruta_Vehiculos.Image = CType(resources.GetObject("Btn_CRV_Control_Ruta_Vehiculos.Image"), System.Drawing.Image)
        Me.Btn_CRV_Control_Ruta_Vehiculos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_CRV_Control_Ruta_Vehiculos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CRV_Control_Ruta_Vehiculos.Name = "Btn_CRV_Control_Ruta_Vehiculos"
        Me.Btn_CRV_Control_Ruta_Vehiculos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CRV_Control_Ruta_Vehiculos.Text = "<font size=""+4""><b>C.R.V.</b></font><br/><font size=""-1"">Control de Rutas de Vehi" &
    "culos</font>"
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.PaddingBottom = 4
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.PaddingLeft = 4
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.PaddingRight = 4
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.PaddingTop = 4
        Me.Btn_CRV_Control_Ruta_Vehiculos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_CRV_Control_Ruta_Vehiculos.TitleText = "BakApp"
        '
        'Btn_Etiquetas_De_Barra
        '
        Me.Btn_Etiquetas_De_Barra.Image = CType(resources.GetObject("Btn_Etiquetas_De_Barra.Image"), System.Drawing.Image)
        Me.Btn_Etiquetas_De_Barra.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Etiquetas_De_Barra.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Etiquetas_De_Barra.Name = "Btn_Etiquetas_De_Barra"
        Me.Btn_Etiquetas_De_Barra.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Etiquetas_De_Barra.Text = "<font size=""+4""><b>CODIGOS DE BARRA</b></font><br/><font size=""-1"">Imprimir etiqu" &
    "etas de barra" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mantención de etiquetas</font>"
        Me.Btn_Etiquetas_De_Barra.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Etiquetas_De_Barra.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Etiquetas_De_Barra.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Etiquetas_De_Barra.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Etiquetas_De_Barra.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Etiquetas_De_Barra.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Etiquetas_De_Barra.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Etiquetas_De_Barra.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Etiquetas_De_Barra.TileStyle.PaddingBottom = 4
        Me.Btn_Etiquetas_De_Barra.TileStyle.PaddingLeft = 4
        Me.Btn_Etiquetas_De_Barra.TileStyle.PaddingRight = 4
        Me.Btn_Etiquetas_De_Barra.TileStyle.PaddingTop = 4
        Me.Btn_Etiquetas_De_Barra.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Etiquetas_De_Barra.TitleText = "BakApp"
        '
        'BtnCrearFormatos
        '
        Me.BtnCrearFormatos.Image = CType(resources.GetObject("BtnCrearFormatos.Image"), System.Drawing.Image)
        Me.BtnCrearFormatos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnCrearFormatos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCrearFormatos.Name = "BtnCrearFormatos"
        Me.BtnCrearFormatos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCrearFormatos.Text = "<font size=""+4""><b>FORMATOS</b></font><br/><font size=""-1"">Crear formatos de docu" &
    "mentos<br/> </font>"
        Me.BtnCrearFormatos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnCrearFormatos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnCrearFormatos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.BtnCrearFormatos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.BtnCrearFormatos.TileStyle.BackColorGradientAngle = 45
        Me.BtnCrearFormatos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.BtnCrearFormatos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.BtnCrearFormatos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnCrearFormatos.TileStyle.PaddingBottom = 4
        Me.BtnCrearFormatos.TileStyle.PaddingLeft = 4
        Me.BtnCrearFormatos.TileStyle.PaddingRight = 4
        Me.BtnCrearFormatos.TileStyle.PaddingTop = 4
        Me.BtnCrearFormatos.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCrearFormatos.TitleText = "BakApp"
        '
        'Btn_DTE_Respuestas_XML
        '
        Me.Btn_DTE_Respuestas_XML.Image = CType(resources.GetObject("Btn_DTE_Respuestas_XML.Image"), System.Drawing.Image)
        Me.Btn_DTE_Respuestas_XML.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_DTE_Respuestas_XML.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_DTE_Respuestas_XML.Name = "Btn_DTE_Respuestas_XML"
        Me.Btn_DTE_Respuestas_XML.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_DTE_Respuestas_XML.Text = "<font size=""+4""><b>DTE Acuse recibo</b></font><br/><font size=""-1"">Importar XML d" &
    "esde correo</font>"
        Me.Btn_DTE_Respuestas_XML.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_DTE_Respuestas_XML.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_DTE_Respuestas_XML.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_DTE_Respuestas_XML.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_DTE_Respuestas_XML.TileStyle.BackColorGradientAngle = 45
        Me.Btn_DTE_Respuestas_XML.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_DTE_Respuestas_XML.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_DTE_Respuestas_XML.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_DTE_Respuestas_XML.TileStyle.PaddingBottom = 4
        Me.Btn_DTE_Respuestas_XML.TileStyle.PaddingLeft = 4
        Me.Btn_DTE_Respuestas_XML.TileStyle.PaddingRight = 4
        Me.Btn_DTE_Respuestas_XML.TileStyle.PaddingTop = 4
        Me.Btn_DTE_Respuestas_XML.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_DTE_Respuestas_XML.TitleText = "BakApp"
        '
        'Btn_Precios_PrestaShop
        '
        Me.Btn_Precios_PrestaShop.Image = CType(resources.GetObject("Btn_Precios_PrestaShop.Image"), System.Drawing.Image)
        Me.Btn_Precios_PrestaShop.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Precios_PrestaShop.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Precios_PrestaShop.Name = "Btn_Precios_PrestaShop"
        Me.Btn_Precios_PrestaShop.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Precios_PrestaShop.Text = "<font size=""+4""><b>PRESTASHOP</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</font><br/><font size=""-1"">Productos / Precio" &
    "s / Stock</font>"
        Me.Btn_Precios_PrestaShop.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_Precios_PrestaShop.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Precios_PrestaShop.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Precios_PrestaShop.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Precios_PrestaShop.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Precios_PrestaShop.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Precios_PrestaShop.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Precios_PrestaShop.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Precios_PrestaShop.TileStyle.PaddingBottom = 4
        Me.Btn_Precios_PrestaShop.TileStyle.PaddingLeft = 4
        Me.Btn_Precios_PrestaShop.TileStyle.PaddingRight = 4
        Me.Btn_Precios_PrestaShop.TileStyle.PaddingTop = 4
        Me.Btn_Precios_PrestaShop.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Precios_PrestaShop.TitleText = "BakApp"
        '
        'Btn_Huella
        '
        Me.Btn_Huella.Image = CType(resources.GetObject("Btn_Huella.Image"), System.Drawing.Image)
        Me.Btn_Huella.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Huella.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Huella.Name = "Btn_Huella"
        Me.Btn_Huella.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Huella.Text = "<font size=""+4""><b>HUELLAS</b></font><br/><font size=""-1"">Registro de Huellas</fo" &
    "nt><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lector U.are. 4500"
        Me.Btn_Huella.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Huella.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Huella.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Huella.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Huella.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Huella.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Huella.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Huella.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Huella.TileStyle.PaddingBottom = 4
        Me.Btn_Huella.TileStyle.PaddingLeft = 4
        Me.Btn_Huella.TileStyle.PaddingRight = 4
        Me.Btn_Huella.TileStyle.PaddingTop = 4
        Me.Btn_Huella.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Huella.TitleText = "BakApp"
        '
        'Btn_Pocket_PC
        '
        Me.Btn_Pocket_PC.Image = CType(resources.GetObject("Btn_Pocket_PC.Image"), System.Drawing.Image)
        Me.Btn_Pocket_PC.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Pocket_PC.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Pocket_PC.Name = "Btn_Pocket_PC"
        Me.Btn_Pocket_PC.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Pocket_PC.Text = "<font size=""+4"">Pocket-PC</font><br/><font size=""-1"">BakApp para Windows CE</font" &
    ">"
        Me.Btn_Pocket_PC.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Pocket_PC.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Pocket_PC.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Pocket_PC.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Pocket_PC.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Pocket_PC.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Pocket_PC.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Pocket_PC.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Pocket_PC.TileStyle.PaddingBottom = 4
        Me.Btn_Pocket_PC.TileStyle.PaddingLeft = 4
        Me.Btn_Pocket_PC.TileStyle.PaddingRight = 4
        Me.Btn_Pocket_PC.TileStyle.PaddingTop = 4
        Me.Btn_Pocket_PC.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Pocket_PC.TitleText = "BakApp"
        '
        'Btn_Archivador
        '
        Me.Btn_Archivador.Image = CType(resources.GetObject("Btn_Archivador.Image"), System.Drawing.Image)
        Me.Btn_Archivador.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Archivador.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Archivador.Name = "Btn_Archivador"
        Me.Btn_Archivador.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Archivador.Text = "<font size=""+4""><b>ARCHIVADOR</b></font><br/><font size=""-1"">Documentos archivado" &
    "s desde Bakapp...</font>"
        Me.Btn_Archivador.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_Archivador.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Archivador.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Archivador.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Archivador.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Archivador.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Archivador.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Archivador.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Archivador.TileStyle.PaddingBottom = 4
        Me.Btn_Archivador.TileStyle.PaddingLeft = 4
        Me.Btn_Archivador.TileStyle.PaddingRight = 4
        Me.Btn_Archivador.TileStyle.PaddingTop = 4
        Me.Btn_Archivador.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Archivador.TitleText = "BakApp"
        '
        'Btn_Cierre_Reactivacion_Documentos
        '
        Me.Btn_Cierre_Reactivacion_Documentos.Image = CType(resources.GetObject("Btn_Cierre_Reactivacion_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Cierre_Reactivacion_Documentos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Cierre_Reactivacion_Documentos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Cierre_Reactivacion_Documentos.Name = "Btn_Cierre_Reactivacion_Documentos"
        Me.Btn_Cierre_Reactivacion_Documentos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Cierre_Reactivacion_Documentos.Text = "<font size=""+4""><b>CERRAR DOC.</b></font><br/><font size=""-1"">" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Orden de compra<b" &
    "r/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cotización<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nota de venta<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nota venta intena</font>"
        Me.Btn_Cierre_Reactivacion_Documentos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.Btn_Cierre_Reactivacion_Documentos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.PaddingBottom = 4
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.PaddingLeft = 4
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.PaddingRight = 4
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.PaddingTop = 4
        Me.Btn_Cierre_Reactivacion_Documentos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Cierre_Reactivacion_Documentos.TitleText = "BakApp"
        '
        'Btn_Habilitar_Nvv_Para_Facturar
        '
        Me.Btn_Habilitar_Nvv_Para_Facturar.Image = CType(resources.GetObject("Btn_Habilitar_Nvv_Para_Facturar.Image"), System.Drawing.Image)
        Me.Btn_Habilitar_Nvv_Para_Facturar.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Habilitar_Nvv_Para_Facturar.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Habilitar_Nvv_Para_Facturar.Name = "Btn_Habilitar_Nvv_Para_Facturar"
        Me.Btn_Habilitar_Nvv_Para_Facturar.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Habilitar_Nvv_Para_Facturar.Text = "<font size=""+4""><b>HABILITAR NVV PARA FACTURAR</b></font><br/><font size=""-1"">Pro" &
    "ceso masivo<br/> </font>"
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.PaddingBottom = 4
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.PaddingLeft = 4
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.PaddingRight = 4
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.PaddingTop = 4
        Me.Btn_Habilitar_Nvv_Para_Facturar.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Habilitar_Nvv_Para_Facturar.TitleText = "BakApp"
        '
        'Btn_Patentes_rvm
        '
        Me.Btn_Patentes_rvm.Image = CType(resources.GetObject("Btn_Patentes_rvm.Image"), System.Drawing.Image)
        Me.Btn_Patentes_rvm.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Patentes_rvm.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Patentes_rvm.Name = "Btn_Patentes_rvm"
        Me.Btn_Patentes_rvm.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Patentes_rvm.Text = "<font size=""+4""><b>PATENTES RVM</b></font><br/><font size=""-1"">Mantención de regi" &
    "stro de patentes en registro de vehiculos motorizados</font>"
        Me.Btn_Patentes_rvm.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Patentes_rvm.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Patentes_rvm.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Patentes_rvm.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Patentes_rvm.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Patentes_rvm.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Patentes_rvm.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Patentes_rvm.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Patentes_rvm.TileStyle.PaddingBottom = 4
        Me.Btn_Patentes_rvm.TileStyle.PaddingLeft = 4
        Me.Btn_Patentes_rvm.TileStyle.PaddingRight = 4
        Me.Btn_Patentes_rvm.TileStyle.PaddingTop = 4
        Me.Btn_Patentes_rvm.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Patentes_rvm.TitleText = "BakApp"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCambiarDeUsuario})
        Me.Bar2.Location = New System.Drawing.Point(0, 527)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(838, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 38
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
        '
        'BtnCambiarDeUsuario
        '
        Me.BtnCambiarDeUsuario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCambiarDeUsuario.ForeColor = System.Drawing.Color.Black
        Me.BtnCambiarDeUsuario.Image = CType(resources.GetObject("BtnCambiarDeUsuario.Image"), System.Drawing.Image)
        Me.BtnCambiarDeUsuario.ImageAlt = CType(resources.GetObject("BtnCambiarDeUsuario.ImageAlt"), System.Drawing.Image)
        Me.BtnCambiarDeUsuario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCambiarDeUsuario.Name = "BtnCambiarDeUsuario"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(368, 49)
        Me.LabelX1.TabIndex = 40
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PROGRAMAS ESPECIALES</b></font>"
        '
        'Modulo_Programas_Especiales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Programas_Especiales"
        Me.Size = New System.Drawing.Size(838, 568)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Demonio As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnSQL2Excel As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Private WithEvents BtnDTE2PDF As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCorreos_SMTP As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnCambiarDeUsuario As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_CRV_Control_Ruta_Vehiculos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Etiquetas_De_Barra As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCrearFormatos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_DTE_Respuestas_XML As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Precios_PrestaShop As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Huella As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Pocket_PC As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Archivador As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Cierre_Reactivacion_Documentos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Habilitar_Nvv_Para_Facturar As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Patentes_rvm As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
