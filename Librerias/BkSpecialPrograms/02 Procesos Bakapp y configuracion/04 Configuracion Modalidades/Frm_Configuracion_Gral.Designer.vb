﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Configuracion_Gral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Configuracion_Gral))
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Permisos_Descuentos_Por_Responzable = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Conservar_Responzable_Doc_Relacionado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Preguntar_Documento = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Redondear_Dscto_Cero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Dias_Max_Fecha_Despacho_Sab = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Dias_Max_Fecha_Despacho_Dom = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Monto_Max_CRV_FacMasiva = New DevComponents.Editors.IntegerInput()
        Me.Lbl_Monto_CRV = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Input_Dias_Max_Fecha_Despacho = New DevComponents.Editors.IntegerInput()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Dias_Venci_Coti = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Cmb_TipoValor_Bruto_Neto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_LeerSoloUnaVezCodBarra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Utilizar_Lectura_Codigo_QR = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_FacElect_Usar_AmbienteCertificacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_FacElec_Bakapp_Hefesto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Revisar_Tasa_de_Cambio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Grabar_Despachos_Con_Huella = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_BloqEdiConcepDescuento = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_BloqEdiConcepRecargo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.SpTab_General = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_CpActeco = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpComuna = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpEmpresa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Editar_Datos_Empresa = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_CpGiro = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpPais = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpDireccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpRazon = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpNcorto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CpRut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.SpTab_DatosEmpresa = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Asociar_Prod_Funcionarios = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Usar_Validador_Prod_X_Compras = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Centro_Costo_Obligatorio_OCC = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Revisar_OCC_Pendientes_X_Productos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Solicitar_Permiso_OCC_SOC = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.SpTab_Compras = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Cmb_Nodo_Raiz_Asociados = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chk_Pr_Creacion_Exigir_Dimensiones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Creacion_Exigir_Precio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.SpTab_Productos = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_ValorMinimoNVV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Cliente = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SpTab_Ventas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Numeraciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excluir_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_DocConceptosVsPagos = New DevComponents.DotNetBar.ButtonItem()
        Me.CheckBoxX2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.Input_Dias_Max_Fecha_Despacho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuperTabControlPanel5.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuperTabControlPanel7.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuperTabControlPanel6.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Las_Cotizaciones_No_Revisan_Permisos, 0, 13)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Permisos_Descuentos_Por_Responzable, 0, 12)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV, 0, 11)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado, 0, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Conservar_Responzable_Doc_Relacionado, 0, 10)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Utilizar_NVV_En_Credito_X_Cliente, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxX1, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Preguntar_Documento, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Redondear_Dscto_Cero, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Conservar_Bodega_Sig_Linea_Venta, 0, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Dias_Max_Fecha_Despacho_Sab, 0, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.Chk_Dias_Max_Fecha_Despacho_Dom, 0, 8)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 14
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(657, 282)
        Me.TableLayoutPanel3.TabIndex = 85
        '
        'Chk_Las_Cotizaciones_No_Revisan_Permisos
        '
        '
        '
        '
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.Location = New System.Drawing.Point(3, 263)
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.Name = "Chk_Las_Cotizaciones_No_Revisan_Permisos"
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.Size = New System.Drawing.Size(635, 14)
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.TabIndex = 121
        Me.Chk_Las_Cotizaciones_No_Revisan_Permisos.Text = "Las Cotizaciones no necesitan de permisos especiale para ser grabadas"
        '
        'Chk_Permisos_Descuentos_Por_Responzable
        '
        '
        '
        '
        Me.Chk_Permisos_Descuentos_Por_Responzable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Permisos_Descuentos_Por_Responzable.ForeColor = System.Drawing.Color.Black
        Me.Chk_Permisos_Descuentos_Por_Responzable.Location = New System.Drawing.Point(3, 243)
        Me.Chk_Permisos_Descuentos_Por_Responzable.Name = "Chk_Permisos_Descuentos_Por_Responzable"
        Me.Chk_Permisos_Descuentos_Por_Responzable.Size = New System.Drawing.Size(635, 14)
        Me.Chk_Permisos_Descuentos_Por_Responzable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Permisos_Descuentos_Por_Responzable.TabIndex = 120
        Me.Chk_Permisos_Descuentos_Por_Responzable.Text = "El permiso por descuento será revisado a nivel de responsable. (de lo contrario s" &
    "era al primer vendedor del detalle)"
        '
        'Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV
        '
        '
        '
        '
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.ForeColor = System.Drawing.Color.Black
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Location = New System.Drawing.Point(3, 223)
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Name = "Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV"
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Size = New System.Drawing.Size(635, 14)
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.TabIndex = 118
        Me.Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Text = "Volver a solicitar permiso FCV desde NVV"
        '
        'Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado
        '
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Location = New System.Drawing.Point(3, 183)
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Name = "Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado"
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Size = New System.Drawing.Size(483, 14)
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.TabIndex = 118
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Text = "Preguntar si cambia al responsable del documento cuando se genera desde otro docu" &
    "mento"
        '
        'Chk_Conservar_Responzable_Doc_Relacionado
        '
        Me.Chk_Conservar_Responzable_Doc_Relacionado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Conservar_Responzable_Doc_Relacionado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Conservar_Responzable_Doc_Relacionado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Location = New System.Drawing.Point(3, 203)
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Name = "Chk_Conservar_Responzable_Doc_Relacionado"
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Size = New System.Drawing.Size(635, 14)
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Conservar_Responzable_Doc_Relacionado.TabIndex = 118
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Text = "Conservar como responsable del documento al funcionario de origen cuando se gener" &
    "a un documento desde otro documento"
        '
        'Chk_No_Permitir_Grabar_Con_Dscto_Superado
        '
        '
        '
        '
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.ForeColor = System.Drawing.Color.Black
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Location = New System.Drawing.Point(3, 3)
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Name = "Chk_No_Permitir_Grabar_Con_Dscto_Superado"
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Size = New System.Drawing.Size(276, 14)
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.TabIndex = 86
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Text = "No Permitir Grabar Venta Con Dscto Superado"
        '
        'Chk_Utilizar_NVV_En_Credito_X_Cliente
        '
        '
        '
        '
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Location = New System.Drawing.Point(3, 23)
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Name = "Chk_Utilizar_NVV_En_Credito_X_Cliente"
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Size = New System.Drawing.Size(276, 14)
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.TabIndex = 108
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Text = "Considera NVV abiertas como cupo utilizado"
        '
        'CheckBoxX1
        '
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX1.Location = New System.Drawing.Point(3, 43)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(276, 14)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 110
        Me.CheckBoxX1.Text = "No Permitir Grabar Venta Con Dscto Superado"
        '
        'Chk_Preguntar_Documento
        '
        Me.Chk_Preguntar_Documento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Preguntar_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Preguntar_Documento.ForeColor = System.Drawing.Color.Black
        Me.Chk_Preguntar_Documento.Location = New System.Drawing.Point(3, 63)
        Me.Chk_Preguntar_Documento.Name = "Chk_Preguntar_Documento"
        Me.Chk_Preguntar_Documento.Size = New System.Drawing.Size(461, 14)
        Me.Chk_Preguntar_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Preguntar_Documento.TabIndex = 114
        Me.Chk_Preguntar_Documento.Text = "Preguntar documento primero (Post-Venta)"
        '
        'Chk_Redondear_Dscto_Cero
        '
        Me.Chk_Redondear_Dscto_Cero.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Redondear_Dscto_Cero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Redondear_Dscto_Cero.ForeColor = System.Drawing.Color.Black
        Me.Chk_Redondear_Dscto_Cero.Location = New System.Drawing.Point(3, 83)
        Me.Chk_Redondear_Dscto_Cero.Name = "Chk_Redondear_Dscto_Cero"
        Me.Chk_Redondear_Dscto_Cero.Size = New System.Drawing.Size(461, 14)
        Me.Chk_Redondear_Dscto_Cero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Redondear_Dscto_Cero.TabIndex = 114
        Me.Chk_Redondear_Dscto_Cero.Text = "Redondear en los descuentos a cero"
        '
        'Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente
        '
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.ForeColor = System.Drawing.Color.Black
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Location = New System.Drawing.Point(3, 103)
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Name = "Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente"
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Size = New System.Drawing.Size(461, 14)
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.TabIndex = 114
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Text = "Ofrecer otras bodegas cuando hay stock insuficiente"
        '
        'Chk_Conservar_Bodega_Sig_Linea_Venta
        '
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.ForeColor = System.Drawing.Color.Black
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Location = New System.Drawing.Point(3, 123)
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Name = "Chk_Conservar_Bodega_Sig_Linea_Venta"
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Size = New System.Drawing.Size(651, 14)
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.TabIndex = 115
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Text = "Conservar la bodega en la siguiente línea de un documento de ventas"
        '
        'Chk_Dias_Max_Fecha_Despacho_Sab
        '
        '
        '
        '
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.ForeColor = System.Drawing.Color.Black
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Location = New System.Drawing.Point(3, 143)
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Name = "Chk_Dias_Max_Fecha_Despacho_Sab"
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Size = New System.Drawing.Size(248, 14)
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.TabIndex = 114
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Text = "Considerar sábado en despacho"
        '
        'Chk_Dias_Max_Fecha_Despacho_Dom
        '
        '
        '
        '
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.ForeColor = System.Drawing.Color.Black
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Location = New System.Drawing.Point(3, 163)
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Name = "Chk_Dias_Max_Fecha_Despacho_Dom"
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Size = New System.Drawing.Size(216, 14)
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.TabIndex = 115
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Text = "Considerar domingo en despacho"
        '
        'Input_Monto_Max_CRV_FacMasiva
        '
        '
        '
        '
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Monto_Max_CRV_FacMasiva.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Monto_Max_CRV_FacMasiva.ForeColor = System.Drawing.Color.Black
        Me.Input_Monto_Max_CRV_FacMasiva.Location = New System.Drawing.Point(317, 78)
        Me.Input_Monto_Max_CRV_FacMasiva.MaxValue = 10000
        Me.Input_Monto_Max_CRV_FacMasiva.MinValue = 0
        Me.Input_Monto_Max_CRV_FacMasiva.Name = "Input_Monto_Max_CRV_FacMasiva"
        Me.Input_Monto_Max_CRV_FacMasiva.ShowUpDown = True
        Me.Input_Monto_Max_CRV_FacMasiva.Size = New System.Drawing.Size(64, 22)
        Me.Input_Monto_Max_CRV_FacMasiva.TabIndex = 113
        '
        'Lbl_Monto_CRV
        '
        '
        '
        '
        Me.Lbl_Monto_CRV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Monto_CRV.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Monto_CRV.Location = New System.Drawing.Point(3, 78)
        Me.Lbl_Monto_CRV.Name = "Lbl_Monto_CRV"
        Me.Lbl_Monto_CRV.Size = New System.Drawing.Size(308, 19)
        Me.Lbl_Monto_CRV.TabIndex = 112
        Me.Lbl_Monto_CRV.Text = "Monto máximo para pagar saldo con CRV (facturación masiva)"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.81128!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.18872!))
        Me.TableLayoutPanel4.Controls.Add(Me.Input_Dias_Max_Fecha_Despacho, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX16, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX9, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Monto_CRV, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Txt_Dias_Venci_Coti, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Cmb_TipoValor_Bruto_Neto, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Input_Monto_Max_CRV_FacMasiva, 1, 3)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 393)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(471, 102)
        Me.TableLayoutPanel4.TabIndex = 114
        '
        'Input_Dias_Max_Fecha_Despacho
        '
        '
        '
        '
        Me.Input_Dias_Max_Fecha_Despacho.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_Max_Fecha_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_Max_Fecha_Despacho.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Dias_Max_Fecha_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Input_Dias_Max_Fecha_Despacho.Location = New System.Drawing.Point(317, 53)
        Me.Input_Dias_Max_Fecha_Despacho.MaxValue = 365
        Me.Input_Dias_Max_Fecha_Despacho.Name = "Input_Dias_Max_Fecha_Despacho"
        Me.Input_Dias_Max_Fecha_Despacho.ShowUpDown = True
        Me.Input_Dias_Max_Fecha_Despacho.Size = New System.Drawing.Size(49, 22)
        Me.Input_Dias_Max_Fecha_Despacho.TabIndex = 94
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(3, 53)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(301, 14)
        Me.LabelX16.TabIndex = 96
        Me.LabelX16.Text = "máximo de días para despacho en notas de venta"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 28)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(280, 19)
        Me.LabelX9.TabIndex = 72
        Me.LabelX9.Text = "Tipo de valor en documentos de venta"
        '
        'Txt_Dias_Venci_Coti
        '
        Me.Txt_Dias_Venci_Coti.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Dias_Venci_Coti.Border.Class = "TextBoxBorder"
        Me.Txt_Dias_Venci_Coti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Dias_Venci_Coti.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Dias_Venci_Coti.ForeColor = System.Drawing.Color.Black
        Me.Txt_Dias_Venci_Coti.Location = New System.Drawing.Point(317, 3)
        Me.Txt_Dias_Venci_Coti.Name = "Txt_Dias_Venci_Coti"
        Me.Txt_Dias_Venci_Coti.PreventEnterBeep = True
        Me.Txt_Dias_Venci_Coti.Size = New System.Drawing.Size(49, 22)
        Me.Txt_Dias_Venci_Coti.TabIndex = 13
        '
        'Cmb_TipoValor_Bruto_Neto
        '
        Me.Cmb_TipoValor_Bruto_Neto.DisplayMember = "Text"
        Me.Cmb_TipoValor_Bruto_Neto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_TipoValor_Bruto_Neto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TipoValor_Bruto_Neto.FormattingEnabled = True
        Me.Cmb_TipoValor_Bruto_Neto.ItemHeight = 16
        Me.Cmb_TipoValor_Bruto_Neto.Location = New System.Drawing.Point(317, 28)
        Me.Cmb_TipoValor_Bruto_Neto.Name = "Cmb_TipoValor_Bruto_Neto"
        Me.Cmb_TipoValor_Bruto_Neto.Size = New System.Drawing.Size(140, 22)
        Me.Cmb_TipoValor_Bruto_Neto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_TipoValor_Bruto_Neto.TabIndex = 73
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(280, 19)
        Me.LabelX1.TabIndex = 12
        Me.LabelX1.Text = "Días para el vencimiento de las cotizaciones"
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel7)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel6)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 12)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 3
        Me.SuperTabControl1.Size = New System.Drawing.Size(672, 539)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 97
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SpTab_General, Me.SpTab_Compras, Me.SpTab_Ventas, Me.SpTab_Productos, Me.SpTab_DatosEmpresa})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.TableLayoutPanel5)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(672, 512)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SpTab_General
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_LeerSoloUnaVezCodBarra, 0, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Utilizar_Lectura_Codigo_QR, 0, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_FacElect_Usar_AmbienteCertificacion, 0, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_FacElec_Bakapp_Hefesto, 0, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Revisar_Tasa_de_Cambio, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Grabar_Despachos_Con_Huella, 0, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_BloqEdiConcepDescuento, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_BloqEdiConcepRecargo, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Pedir_Permiso_Para_Usar_Stanby, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras, 0, 1)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 17
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(489, 343)
        Me.TableLayoutPanel5.TabIndex = 86
        '
        'Chk_LeerSoloUnaVezCodBarra
        '
        '
        '
        '
        Me.Chk_LeerSoloUnaVezCodBarra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_LeerSoloUnaVezCodBarra.ForeColor = System.Drawing.Color.Black
        Me.Chk_LeerSoloUnaVezCodBarra.Location = New System.Drawing.Point(3, 183)
        Me.Chk_LeerSoloUnaVezCodBarra.Name = "Chk_LeerSoloUnaVezCodBarra"
        Me.Chk_LeerSoloUnaVezCodBarra.Size = New System.Drawing.Size(483, 14)
        Me.Chk_LeerSoloUnaVezCodBarra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_LeerSoloUnaVezCodBarra.TabIndex = 117
        Me.Chk_LeerSoloUnaVezCodBarra.Text = "Permitir ingrsar solo una vez la lectura de un código de barras o QR"
        '
        'Chk_Utilizar_Lectura_Codigo_QR
        '
        '
        '
        '
        Me.Chk_Utilizar_Lectura_Codigo_QR.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Utilizar_Lectura_Codigo_QR.ForeColor = System.Drawing.Color.Black
        Me.Chk_Utilizar_Lectura_Codigo_QR.Location = New System.Drawing.Point(3, 163)
        Me.Chk_Utilizar_Lectura_Codigo_QR.Name = "Chk_Utilizar_Lectura_Codigo_QR"
        Me.Chk_Utilizar_Lectura_Codigo_QR.Size = New System.Drawing.Size(483, 14)
        Me.Chk_Utilizar_Lectura_Codigo_QR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Utilizar_Lectura_Codigo_QR.TabIndex = 116
        Me.Chk_Utilizar_Lectura_Codigo_QR.Text = "Utilizar revisión de códigos QR en lectura de códigos de barra para recepción o d" &
    "espacho."
        '
        'Chk_FacElect_Usar_AmbienteCertificacion
        '
        '
        '
        '
        Me.Chk_FacElect_Usar_AmbienteCertificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_FacElect_Usar_AmbienteCertificacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_FacElect_Usar_AmbienteCertificacion.Location = New System.Drawing.Point(3, 143)
        Me.Chk_FacElect_Usar_AmbienteCertificacion.Name = "Chk_FacElect_Usar_AmbienteCertificacion"
        Me.Chk_FacElect_Usar_AmbienteCertificacion.Size = New System.Drawing.Size(483, 14)
        Me.Chk_FacElect_Usar_AmbienteCertificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_FacElect_Usar_AmbienteCertificacion.TabIndex = 117
        Me.Chk_FacElect_Usar_AmbienteCertificacion.Text = "Ambiente de pruebas y certificación SII Factura electrónica"
        '
        'Chk_FacElec_Bakapp_Hefesto
        '
        '
        '
        '
        Me.Chk_FacElec_Bakapp_Hefesto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_FacElec_Bakapp_Hefesto.ForeColor = System.Drawing.Color.Black
        Me.Chk_FacElec_Bakapp_Hefesto.Location = New System.Drawing.Point(3, 123)
        Me.Chk_FacElec_Bakapp_Hefesto.Name = "Chk_FacElec_Bakapp_Hefesto"
        Me.Chk_FacElec_Bakapp_Hefesto.Size = New System.Drawing.Size(483, 14)
        Me.Chk_FacElec_Bakapp_Hefesto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_FacElec_Bakapp_Hefesto.TabIndex = 116
        Me.Chk_FacElec_Bakapp_Hefesto.Text = "Facturación electrónica desde Hefesto Bakapp"
        '
        'Chk_Revisar_Tasa_de_Cambio
        '
        '
        '
        '
        Me.Chk_Revisar_Tasa_de_Cambio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Revisar_Tasa_de_Cambio.ForeColor = System.Drawing.Color.Black
        Me.Chk_Revisar_Tasa_de_Cambio.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Revisar_Tasa_de_Cambio.Name = "Chk_Revisar_Tasa_de_Cambio"
        Me.Chk_Revisar_Tasa_de_Cambio.Size = New System.Drawing.Size(283, 14)
        Me.Chk_Revisar_Tasa_de_Cambio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Revisar_Tasa_de_Cambio.TabIndex = 87
        Me.Chk_Revisar_Tasa_de_Cambio.Text = "Revisar tasa de cambio"
        '
        'Chk_Grabar_Despachos_Con_Huella
        '
        '
        '
        '
        Me.Chk_Grabar_Despachos_Con_Huella.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Grabar_Despachos_Con_Huella.ForeColor = System.Drawing.Color.Black
        Me.Chk_Grabar_Despachos_Con_Huella.Location = New System.Drawing.Point(3, 103)
        Me.Chk_Grabar_Despachos_Con_Huella.Name = "Chk_Grabar_Despachos_Con_Huella"
        Me.Chk_Grabar_Despachos_Con_Huella.Size = New System.Drawing.Size(483, 14)
        Me.Chk_Grabar_Despachos_Con_Huella.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Grabar_Despachos_Con_Huella.TabIndex = 115
        Me.Chk_Grabar_Despachos_Con_Huella.Text = "Grabar gestión de despacho validando al usuario con la huella digital"
        '
        'Chk_BloqEdiConcepDescuento
        '
        '
        '
        '
        Me.Chk_BloqEdiConcepDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_BloqEdiConcepDescuento.ForeColor = System.Drawing.Color.Black
        Me.Chk_BloqEdiConcepDescuento.Location = New System.Drawing.Point(3, 43)
        Me.Chk_BloqEdiConcepDescuento.Name = "Chk_BloqEdiConcepDescuento"
        Me.Chk_BloqEdiConcepDescuento.Size = New System.Drawing.Size(297, 14)
        Me.Chk_BloqEdiConcepDescuento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_BloqEdiConcepDescuento.TabIndex = 111
        Me.Chk_BloqEdiConcepDescuento.Text = "Bloquear la edición de conceptos de descuento en doc."
        '
        'Chk_BloqEdiConcepRecargo
        '
        '
        '
        '
        Me.Chk_BloqEdiConcepRecargo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_BloqEdiConcepRecargo.ForeColor = System.Drawing.Color.Black
        Me.Chk_BloqEdiConcepRecargo.Location = New System.Drawing.Point(3, 63)
        Me.Chk_BloqEdiConcepRecargo.Name = "Chk_BloqEdiConcepRecargo"
        Me.Chk_BloqEdiConcepRecargo.Size = New System.Drawing.Size(297, 14)
        Me.Chk_BloqEdiConcepRecargo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_BloqEdiConcepRecargo.TabIndex = 112
        Me.Chk_BloqEdiConcepRecargo.Text = "Bloquear la edición de conceptos de recargo en doc."
        '
        'Chk_Pedir_Permiso_Para_Usar_Stanby
        '
        '
        '
        '
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Location = New System.Drawing.Point(3, 83)
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Name = "Chk_Pedir_Permiso_Para_Usar_Stanby"
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Size = New System.Drawing.Size(324, 14)
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.TabIndex = 113
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Text = "Pedir permisos para utilizar opción Stand-By en documentos"
        '
        'Chk_Revisar_Taza_Solo_Mon_Extranjeras
        '
        '
        '
        '
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.ForeColor = System.Drawing.Color.Black
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Location = New System.Drawing.Point(3, 23)
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Name = "Chk_Revisar_Taza_Solo_Mon_Extranjeras"
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Size = New System.Drawing.Size(483, 14)
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.TabIndex = 110
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Text = "Revisar taza de cambio solo de monedas extranjeras"
        '
        'SpTab_General
        '
        Me.SpTab_General.AttachedControl = Me.SuperTabControlPanel1
        Me.SpTab_General.GlobalItem = False
        Me.SpTab_General.Name = "SpTab_General"
        Me.SpTab_General.Text = "General"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(672, 539)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SpTab_DatosEmpresa
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_CpActeco)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpComuna)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpEmpresa)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.Btn_Editar_Datos_Empresa)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpGiro)
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpCiudad)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpPais)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpDireccion)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpRazon)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpNcorto)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_CpRut)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(15, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(645, 360)
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
        Me.GroupPanel1.Text = "Datos de la empresa"
        '
        'Txt_CpActeco
        '
        Me.Txt_CpActeco.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpActeco.Border.Class = "TextBoxBorder"
        Me.Txt_CpActeco.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpActeco.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpActeco.Enabled = False
        Me.Txt_CpActeco.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpActeco.Location = New System.Drawing.Point(105, 266)
        Me.Txt_CpActeco.Name = "Txt_CpActeco"
        Me.Txt_CpActeco.PreventEnterBeep = True
        Me.Txt_CpActeco.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CpActeco.TabIndex = 27
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(24, 266)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(75, 23)
        Me.LabelX14.TabIndex = 26
        Me.LabelX14.Text = "Acteco"
        '
        'Txt_CpComuna
        '
        Me.Txt_CpComuna.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpComuna.Border.Class = "TextBoxBorder"
        Me.Txt_CpComuna.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpComuna.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpComuna.Enabled = False
        Me.Txt_CpComuna.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpComuna.Location = New System.Drawing.Point(105, 210)
        Me.Txt_CpComuna.Name = "Txt_CpComuna"
        Me.Txt_CpComuna.PreventEnterBeep = True
        Me.Txt_CpComuna.Size = New System.Drawing.Size(173, 22)
        Me.Txt_CpComuna.TabIndex = 25
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(24, 209)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(99, 23)
        Me.LabelX13.TabIndex = 24
        Me.LabelX13.Text = "Comuna"
        '
        'Txt_CpEmpresa
        '
        Me.Txt_CpEmpresa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpEmpresa.Border.Class = "TextBoxBorder"
        Me.Txt_CpEmpresa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpEmpresa.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpEmpresa.Enabled = False
        Me.Txt_CpEmpresa.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpEmpresa.Location = New System.Drawing.Point(105, 8)
        Me.Txt_CpEmpresa.Name = "Txt_CpEmpresa"
        Me.Txt_CpEmpresa.PreventEnterBeep = True
        Me.Txt_CpEmpresa.Size = New System.Drawing.Size(37, 22)
        Me.Txt_CpEmpresa.TabIndex = 16
        Me.Txt_CpEmpresa.Text = "01"
        Me.Txt_CpEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(24, 8)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(75, 23)
        Me.LabelX12.TabIndex = 15
        Me.LabelX12.Text = "Empresa"
        '
        'Btn_Editar_Datos_Empresa
        '
        Me.Btn_Editar_Datos_Empresa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Editar_Datos_Empresa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Editar_Datos_Empresa.Location = New System.Drawing.Point(24, 304)
        Me.Btn_Editar_Datos_Empresa.Name = "Btn_Editar_Datos_Empresa"
        Me.Btn_Editar_Datos_Empresa.Size = New System.Drawing.Size(144, 23)
        Me.Btn_Editar_Datos_Empresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Editar_Datos_Empresa.TabIndex = 14
        Me.Btn_Editar_Datos_Empresa.Text = "Editar datos de la empresa"
        '
        'Txt_CpGiro
        '
        Me.Txt_CpGiro.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpGiro.Border.Class = "TextBoxBorder"
        Me.Txt_CpGiro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpGiro.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpGiro.Enabled = False
        Me.Txt_CpGiro.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpGiro.Location = New System.Drawing.Point(105, 238)
        Me.Txt_CpGiro.Name = "Txt_CpGiro"
        Me.Txt_CpGiro.PreventEnterBeep = True
        Me.Txt_CpGiro.Size = New System.Drawing.Size(357, 22)
        Me.Txt_CpGiro.TabIndex = 23
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(24, 238)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(99, 23)
        Me.LabelX11.TabIndex = 12
        Me.LabelX11.Text = "Giro"
        '
        'Txt_CpCiudad
        '
        Me.Txt_CpCiudad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpCiudad.Border.Class = "TextBoxBorder"
        Me.Txt_CpCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpCiudad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpCiudad.Enabled = False
        Me.Txt_CpCiudad.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpCiudad.Location = New System.Drawing.Point(105, 182)
        Me.Txt_CpCiudad.Name = "Txt_CpCiudad"
        Me.Txt_CpCiudad.PreventEnterBeep = True
        Me.Txt_CpCiudad.Size = New System.Drawing.Size(173, 22)
        Me.Txt_CpCiudad.TabIndex = 22
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(24, 183)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(99, 23)
        Me.LabelX8.TabIndex = 10
        Me.LabelX8.Text = "Ciudad"
        '
        'Txt_CpPais
        '
        Me.Txt_CpPais.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpPais.Border.Class = "TextBoxBorder"
        Me.Txt_CpPais.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpPais.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpPais.Enabled = False
        Me.Txt_CpPais.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpPais.Location = New System.Drawing.Point(105, 154)
        Me.Txt_CpPais.Name = "Txt_CpPais"
        Me.Txt_CpPais.PreventEnterBeep = True
        Me.Txt_CpPais.Size = New System.Drawing.Size(173, 22)
        Me.Txt_CpPais.TabIndex = 21
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(24, 155)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(99, 23)
        Me.LabelX7.TabIndex = 8
        Me.LabelX7.Text = "Pais"
        '
        'Txt_CpDireccion
        '
        Me.Txt_CpDireccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpDireccion.Border.Class = "TextBoxBorder"
        Me.Txt_CpDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpDireccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpDireccion.Enabled = False
        Me.Txt_CpDireccion.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpDireccion.Location = New System.Drawing.Point(105, 124)
        Me.Txt_CpDireccion.Name = "Txt_CpDireccion"
        Me.Txt_CpDireccion.PreventEnterBeep = True
        Me.Txt_CpDireccion.Size = New System.Drawing.Size(357, 22)
        Me.Txt_CpDireccion.TabIndex = 20
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(24, 125)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(99, 23)
        Me.LabelX6.TabIndex = 6
        Me.LabelX6.Text = "Dirección"
        '
        'Txt_CpRazon
        '
        Me.Txt_CpRazon.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpRazon.Border.Class = "TextBoxBorder"
        Me.Txt_CpRazon.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpRazon.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpRazon.Enabled = False
        Me.Txt_CpRazon.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpRazon.Location = New System.Drawing.Point(105, 94)
        Me.Txt_CpRazon.Name = "Txt_CpRazon"
        Me.Txt_CpRazon.PreventEnterBeep = True
        Me.Txt_CpRazon.Size = New System.Drawing.Size(357, 22)
        Me.Txt_CpRazon.TabIndex = 19
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(24, 95)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(99, 23)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Razón social"
        '
        'Txt_CpNcorto
        '
        Me.Txt_CpNcorto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpNcorto.Border.Class = "TextBoxBorder"
        Me.Txt_CpNcorto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpNcorto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpNcorto.Enabled = False
        Me.Txt_CpNcorto.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpNcorto.Location = New System.Drawing.Point(105, 64)
        Me.Txt_CpNcorto.Name = "Txt_CpNcorto"
        Me.Txt_CpNcorto.PreventEnterBeep = True
        Me.Txt_CpNcorto.Size = New System.Drawing.Size(173, 22)
        Me.Txt_CpNcorto.TabIndex = 18
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(24, 65)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(99, 23)
        Me.LabelX4.TabIndex = 2
        Me.LabelX4.Text = "Nombre corto"
        '
        'Txt_CpRut
        '
        Me.Txt_CpRut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CpRut.Border.Class = "TextBoxBorder"
        Me.Txt_CpRut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CpRut.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CpRut.Enabled = False
        Me.Txt_CpRut.ForeColor = System.Drawing.Color.Black
        Me.Txt_CpRut.Location = New System.Drawing.Point(105, 36)
        Me.Txt_CpRut.Name = "Txt_CpRut"
        Me.Txt_CpRut.PreventEnterBeep = True
        Me.Txt_CpRut.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CpRut.TabIndex = 17
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(24, 36)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 0
        Me.LabelX3.Text = "Rut"
        '
        'SpTab_DatosEmpresa
        '
        Me.SpTab_DatosEmpresa.AttachedControl = Me.SuperTabControlPanel2
        Me.SpTab_DatosEmpresa.GlobalItem = False
        Me.SpTab_DatosEmpresa.Name = "SpTab_DatosEmpresa"
        Me.SpTab_DatosEmpresa.Text = "Datos Empresa"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.TableLayoutPanel1)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(672, 539)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SpTab_Compras
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Asociar_Prod_Funcionarios, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Usar_Validador_Prod_X_Compras, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Centro_Costo_Obligatorio_OCC, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Revisar_OCC_Pendientes_X_Productos, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Solicitar_Permiso_OCC_SOC, 0, 4)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(539, 230)
        Me.TableLayoutPanel1.TabIndex = 86
        '
        'Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp
        '
        '
        '
        '
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.ForeColor = System.Drawing.Color.Black
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Location = New System.Drawing.Point(3, 210)
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Name = "Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp"
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Size = New System.Drawing.Size(533, 17)
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.TabIndex = 117
        Me.Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Text = "Actualizar lista de costos de Random desde Bakapp automáticamente"
        '
        'Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras
        '
        '
        '
        '
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Location = New System.Drawing.Point(3, 187)
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Name = "Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras"
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Size = New System.Drawing.Size(533, 17)
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.TabIndex = 116
        Me.Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Text = "Incorporar modo OCC y NVI en asistente de compras"
        '
        'Btn_Asociar_Prod_Funcionarios
        '
        Me.Btn_Asociar_Prod_Funcionarios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Asociar_Prod_Funcionarios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Asociar_Prod_Funcionarios.Image = CType(resources.GetObject("Btn_Asociar_Prod_Funcionarios.Image"), System.Drawing.Image)
        Me.Btn_Asociar_Prod_Funcionarios.Location = New System.Drawing.Point(3, 72)
        Me.Btn_Asociar_Prod_Funcionarios.Name = "Btn_Asociar_Prod_Funcionarios"
        Me.Btn_Asociar_Prod_Funcionarios.Size = New System.Drawing.Size(199, 16)
        Me.Btn_Asociar_Prod_Funcionarios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Asociar_Prod_Funcionarios.TabIndex = 87
        Me.Btn_Asociar_Prod_Funcionarios.Text = "Asociar productos por funcionarios"
        '
        'Rdb_Crear_FCC_Desde_GRC_Vinculado_SII
        '
        '
        '
        '
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Name = "Rdb_Crear_FCC_Desde_GRC_Vinculado_SII"
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Size = New System.Drawing.Size(342, 15)
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.TabIndex = 81
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Text = "Crear FCC al grabar GRC vinculada en el SII"
        '
        'Chk_No_Solicitar_Permiso_Entidad_Preferencial
        '
        '
        '
        '
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.ForeColor = System.Drawing.Color.Black
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Location = New System.Drawing.Point(3, 26)
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Name = "Chk_No_Solicitar_Permiso_Entidad_Preferencial"
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Size = New System.Drawing.Size(342, 15)
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.TabIndex = 82
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Text = "No solicitar permiso a entidades preferenciales"
        '
        'Chk_Usar_Validador_Prod_X_Compras
        '
        '
        '
        '
        Me.Chk_Usar_Validador_Prod_X_Compras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Usar_Validador_Prod_X_Compras.ForeColor = System.Drawing.Color.Black
        Me.Chk_Usar_Validador_Prod_X_Compras.Location = New System.Drawing.Point(3, 49)
        Me.Chk_Usar_Validador_Prod_X_Compras.Name = "Chk_Usar_Validador_Prod_X_Compras"
        Me.Chk_Usar_Validador_Prod_X_Compras.Size = New System.Drawing.Size(342, 15)
        Me.Chk_Usar_Validador_Prod_X_Compras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Usar_Validador_Prod_X_Compras.TabIndex = 83
        Me.Chk_Usar_Validador_Prod_X_Compras.Text = "Avisar a funcionario validador de códigos al generar OCC"
        '
        'Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor
        '
        '
        '
        '
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Location = New System.Drawing.Point(3, 164)
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Name = "Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor"
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Size = New System.Drawing.Size(533, 17)
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.TabIndex = 115
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Text = "Alertar si costos de proveedores son distintos al costo de lista del documento"
        '
        'Chk_Centro_Costo_Obligatorio_OCC
        '
        '
        '
        '
        Me.Chk_Centro_Costo_Obligatorio_OCC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Centro_Costo_Obligatorio_OCC.ForeColor = System.Drawing.Color.Black
        Me.Chk_Centro_Costo_Obligatorio_OCC.Location = New System.Drawing.Point(3, 141)
        Me.Chk_Centro_Costo_Obligatorio_OCC.Name = "Chk_Centro_Costo_Obligatorio_OCC"
        Me.Chk_Centro_Costo_Obligatorio_OCC.Size = New System.Drawing.Size(276, 15)
        Me.Chk_Centro_Costo_Obligatorio_OCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Centro_Costo_Obligatorio_OCC.TabIndex = 95
        Me.Chk_Centro_Costo_Obligatorio_OCC.Text = "Ingresar C.Costo en las compras obligatoriamente"
        '
        'Chk_Revisar_OCC_Pendientes_X_Productos
        '
        '
        '
        '
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Location = New System.Drawing.Point(3, 118)
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Name = "Chk_Revisar_OCC_Pendientes_X_Productos"
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Size = New System.Drawing.Size(324, 14)
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.TabIndex = 94
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Text = "Revisar si hay OCC Pendientes antes de grabar una OCC"
        '
        'Chk_Solicitar_Permiso_OCC_SOC
        '
        '
        '
        '
        Me.Chk_Solicitar_Permiso_OCC_SOC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Solicitar_Permiso_OCC_SOC.ForeColor = System.Drawing.Color.Black
        Me.Chk_Solicitar_Permiso_OCC_SOC.Location = New System.Drawing.Point(3, 95)
        Me.Chk_Solicitar_Permiso_OCC_SOC.Name = "Chk_Solicitar_Permiso_OCC_SOC"
        Me.Chk_Solicitar_Permiso_OCC_SOC.Size = New System.Drawing.Size(289, 15)
        Me.Chk_Solicitar_Permiso_OCC_SOC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Solicitar_Permiso_OCC_SOC.TabIndex = 84
        Me.Chk_Solicitar_Permiso_OCC_SOC.Text = "Solictar permisos al grabar OCC"
        '
        'SpTab_Compras
        '
        Me.SpTab_Compras.AttachedControl = Me.SuperTabControlPanel5
        Me.SpTab_Compras.GlobalItem = False
        Me.SpTab_Compras.Name = "SpTab_Compras"
        Me.SpTab_Compras.Text = "Compras"
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.Controls.Add(Me.Cmb_Nodo_Raiz_Asociados)
        Me.SuperTabControlPanel7.Controls.Add(Me.LabelX15)
        Me.SuperTabControlPanel7.Controls.Add(Me.TableLayoutPanel2)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(672, 539)
        Me.SuperTabControlPanel7.TabIndex = 0
        Me.SuperTabControlPanel7.TabItem = Me.SpTab_Productos
        '
        'Cmb_Nodo_Raiz_Asociados
        '
        Me.Cmb_Nodo_Raiz_Asociados.DisplayMember = "Text"
        Me.Cmb_Nodo_Raiz_Asociados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Nodo_Raiz_Asociados.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Nodo_Raiz_Asociados.FormattingEnabled = True
        Me.Cmb_Nodo_Raiz_Asociados.ItemHeight = 16
        Me.Cmb_Nodo_Raiz_Asociados.Location = New System.Drawing.Point(180, 482)
        Me.Cmb_Nodo_Raiz_Asociados.Name = "Cmb_Nodo_Raiz_Asociados"
        Me.Cmb_Nodo_Raiz_Asociados.Size = New System.Drawing.Size(161, 22)
        Me.Cmb_Nodo_Raiz_Asociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Nodo_Raiz_Asociados.TabIndex = 98
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(6, 482)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(168, 18)
        Me.LabelX15.TabIndex = 97
        Me.LabelX15.Text = "Carpeta raíz productos asociados"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_BloqCambNomCONCEPTOSEnDocumentos, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.chk_Pr_Creacion_Exigir_Dimensiones, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Pr_Desc_Producto_Solo_Mayusculas, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Pr_Creacion_Exigir_Precio, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda, 0, 2)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(576, 128)
        Me.TableLayoutPanel2.TabIndex = 86
        '
        'Chk_BloqCambNomCONCEPTOSEnDocumentos
        '
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.ForeColor = System.Drawing.Color.Black
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.Location = New System.Drawing.Point(3, 108)
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.Name = "Chk_BloqCambNomCONCEPTOSEnDocumentos"
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.Size = New System.Drawing.Size(551, 17)
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.TabIndex = 99
        Me.Chk_BloqCambNomCONCEPTOSEnDocumentos.Text = "Bloquear la opción de cambiar el nombre a los CONCEPTOS en los documentos"
        '
        'chk_Pr_Creacion_Exigir_Dimensiones
        '
        Me.chk_Pr_Creacion_Exigir_Dimensiones.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.chk_Pr_Creacion_Exigir_Dimensiones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chk_Pr_Creacion_Exigir_Dimensiones.ForeColor = System.Drawing.Color.Black
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Location = New System.Drawing.Point(3, 87)
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Name = "chk_Pr_Creacion_Exigir_Dimensiones"
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Size = New System.Drawing.Size(283, 15)
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chk_Pr_Creacion_Exigir_Dimensiones.TabIndex = 97
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Text = "Al crear el producto exigir dimensiones"
        '
        'Chk_Pr_Desc_Producto_Solo_Mayusculas
        '
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Name = "Chk_Pr_Desc_Producto_Solo_Mayusculas"
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Size = New System.Drawing.Size(283, 15)
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.TabIndex = 86
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Text = "Crear descripción de productos con solo mayúsculas"
        '
        'Chk_Pr_Creacion_Exigir_Codigo_Alternativo
        '
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Location = New System.Drawing.Point(3, 66)
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Name = "Chk_Pr_Creacion_Exigir_Codigo_Alternativo"
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Size = New System.Drawing.Size(283, 15)
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.TabIndex = 96
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Text = "Al crear el producto exigir código alternativo"
        '
        'Chk_Pr_Creacion_Exigir_Precio
        '
        Me.Chk_Pr_Creacion_Exigir_Precio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Creacion_Exigir_Precio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Creacion_Exigir_Precio.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Creacion_Exigir_Precio.Location = New System.Drawing.Point(3, 24)
        Me.Chk_Pr_Creacion_Exigir_Precio.Name = "Chk_Pr_Creacion_Exigir_Precio"
        Me.Chk_Pr_Creacion_Exigir_Precio.Size = New System.Drawing.Size(283, 15)
        Me.Chk_Pr_Creacion_Exigir_Precio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Creacion_Exigir_Precio.TabIndex = 94
        Me.Chk_Pr_Creacion_Exigir_Precio.Text = "Al crear el producto exigir el precio"
        '
        'Chk_Pr_Creacion_Exigir_Clasificacion_busqueda
        '
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Location = New System.Drawing.Point(3, 45)
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Name = "Chk_Pr_Creacion_Exigir_Clasificacion_busqueda"
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Size = New System.Drawing.Size(283, 15)
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.TabIndex = 95
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Text = "Al crear el producto exigir clasificación de búsqueda"
        '
        'SpTab_Productos
        '
        Me.SpTab_Productos.AttachedControl = Me.SuperTabControlPanel7
        Me.SpTab_Productos.GlobalItem = False
        Me.SpTab_Productos.Name = "SpTab_Productos"
        Me.SpTab_Productos.Text = "Productos/Conceptos"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX17)
        Me.SuperTabControlPanel6.Controls.Add(Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen)
        Me.SuperTabControlPanel6.Controls.Add(Me.Txt_ValorMinimoNVV)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX2)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX10)
        Me.SuperTabControlPanel6.Controls.Add(Me.Btn_Buscar_Cliente)
        Me.SuperTabControlPanel6.Controls.Add(Me.Txt_Cliente)
        Me.SuperTabControlPanel6.Controls.Add(Me.TableLayoutPanel3)
        Me.SuperTabControlPanel6.Controls.Add(Me.TableLayoutPanel4)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(672, 539)
        Me.SuperTabControlPanel6.TabIndex = 0
        Me.SuperTabControlPanel6.TabItem = Me.SpTab_Ventas
        '
        'Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio
        '
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.ForeColor = System.Drawing.Color.Black
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Location = New System.Drawing.Point(578, 336)
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Name = "Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio"
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Size = New System.Drawing.Size(79, 22)
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.TabIndex = 122
        Me.Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Text = "Obligatorio"
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(6, 316)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(583, 14)
        Me.LabelX17.TabIndex = 121
        Me.LabelX17.Text = "Criterio para poner fechas en GDV cuando la fecha es distinta al documento de ori" &
    "gen"
        '
        'Cmb_CriterioFechaGDVconFechaDistintaDocOrigen
        '
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.DisplayMember = "Text"
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.ForeColor = System.Drawing.Color.Black
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.FormattingEnabled = True
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.ItemHeight = 16
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.Location = New System.Drawing.Point(6, 336)
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.Name = "Cmb_CriterioFechaGDVconFechaDistintaDocOrigen"
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.Size = New System.Drawing.Size(566, 22)
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.TabIndex = 120
        '
        'Txt_ValorMinimoNVV
        '
        Me.Txt_ValorMinimoNVV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ValorMinimoNVV.Border.Class = "TextBoxBorder"
        Me.Txt_ValorMinimoNVV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ValorMinimoNVV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ValorMinimoNVV.ForeColor = System.Drawing.Color.Black
        Me.Txt_ValorMinimoNVV.Location = New System.Drawing.Point(292, 291)
        Me.Txt_ValorMinimoNVV.Name = "Txt_ValorMinimoNVV"
        Me.Txt_ValorMinimoNVV.PreventEnterBeep = True
        Me.Txt_ValorMinimoNVV.Size = New System.Drawing.Size(62, 22)
        Me.Txt_ValorMinimoNVV.TabIndex = 119
        Me.Txt_ValorMinimoNVV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 291)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(280, 19)
        Me.LabelX2.TabIndex = 118
        Me.LabelX2.Text = "Valor minimo para generar NVV (valor 0 = sin condición)"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(6, 364)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(97, 23)
        Me.LabelX10.TabIndex = 117
        Me.LabelX10.Text = "Cliente por defecto"
        '
        'Btn_Buscar_Cliente
        '
        Me.Btn_Buscar_Cliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Cliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Cliente.Image = CType(resources.GetObject("Btn_Buscar_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Cliente.ImageAlt = CType(resources.GetObject("Btn_Buscar_Cliente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Cliente.Location = New System.Drawing.Point(105, 364)
        Me.Btn_Buscar_Cliente.Name = "Btn_Buscar_Cliente"
        Me.Btn_Buscar_Cliente.Size = New System.Drawing.Size(39, 22)
        Me.Btn_Buscar_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Cliente.TabIndex = 115
        Me.Btn_Buscar_Cliente.Tooltip = "Buscar cliente"
        '
        'Txt_Cliente
        '
        Me.Txt_Cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cliente.Enabled = False
        Me.Txt_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cliente.Location = New System.Drawing.Point(148, 364)
        Me.Txt_Cliente.Name = "Txt_Cliente"
        Me.Txt_Cliente.PreventEnterBeep = True
        Me.Txt_Cliente.ReadOnly = True
        Me.Txt_Cliente.Size = New System.Drawing.Size(424, 22)
        Me.Txt_Cliente.TabIndex = 116
        '
        'SpTab_Ventas
        '
        Me.SpTab_Ventas.AttachedControl = Me.SuperTabControlPanel6
        Me.SpTab_Ventas.GlobalItem = False
        Me.SpTab_Ventas.Name = "SpTab_Ventas"
        Me.SpTab_Ventas.Text = "Ventas"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Numeraciones_Documento, Me.Btn_Excluir_Documentos, Me.Btn_DocConceptosVsPagos})
        Me.Bar1.Location = New System.Drawing.Point(0, 566)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(684, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 97
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Numeraciones_Documento
        '
        Me.Btn_Numeraciones_Documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Numeraciones_Documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Numeraciones_Documento.Image = CType(resources.GetObject("Btn_Numeraciones_Documento.Image"), System.Drawing.Image)
        Me.Btn_Numeraciones_Documento.ImageAlt = CType(resources.GetObject("Btn_Numeraciones_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Numeraciones_Documento.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Numeraciones_Documento.Name = "Btn_Numeraciones_Documento"
        Me.Btn_Numeraciones_Documento.Tooltip = "Numeración de documentos"
        '
        'Btn_Excluir_Documentos
        '
        Me.Btn_Excluir_Documentos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excluir_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excluir_Documentos.Image = CType(resources.GetObject("Btn_Excluir_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Excluir_Documentos.ImageAlt = CType(resources.GetObject("Btn_Excluir_Documentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excluir_Documentos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Excluir_Documentos.Name = "Btn_Excluir_Documentos"
        Me.Btn_Excluir_Documentos.Tooltip = "Documentos excluidos de la modalidad"
        '
        'Btn_DocConceptosVsPagos
        '
        Me.Btn_DocConceptosVsPagos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_DocConceptosVsPagos.ForeColor = System.Drawing.Color.Black
        Me.Btn_DocConceptosVsPagos.Image = CType(resources.GetObject("Btn_DocConceptosVsPagos.Image"), System.Drawing.Image)
        Me.Btn_DocConceptosVsPagos.ImageAlt = CType(resources.GetObject("Btn_DocConceptosVsPagos.ImageAlt"), System.Drawing.Image)
        Me.Btn_DocConceptosVsPagos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_DocConceptosVsPagos.Name = "Btn_DocConceptosVsPagos"
        Me.Btn_DocConceptosVsPagos.Tooltip = "Documentos con conceptos obligatorios según tipo de pago"
        '
        'CheckBoxX2
        '
        '
        '
        '
        Me.CheckBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX2.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX2.Location = New System.Drawing.Point(3, 143)
        Me.CheckBoxX2.Name = "CheckBoxX2"
        Me.CheckBoxX2.Size = New System.Drawing.Size(483, 14)
        Me.CheckBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX2.TabIndex = 117
        Me.CheckBoxX2.Text = "Ambiente de pruebas y certificación"
        '
        'Frm_Configuracion_Gral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 607)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Configuracion_Gral"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.Input_Dias_Max_Fecha_Despacho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel5.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel7.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel6.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Chk_No_Permitir_Grabar_Con_Dscto_Superado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Input_Monto_Max_CRV_FacMasiva As DevComponents.Editors.IntegerInput
    Friend WithEvents Lbl_Monto_CRV As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Utilizar_NVV_En_Credito_X_Cliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Cliente As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_Preguntar_Documento As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Redondear_Dscto_Cero As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Conservar_Bodega_Sig_Linea_Venta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Dias_Max_Fecha_Despacho_Sab As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Dias_Max_Fecha_Despacho_Dom As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Input_Dias_Max_Fecha_Despacho As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Dias_Venci_Coti As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Cmb_TipoValor_Bruto_Neto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SpTab_Ventas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Centro_Costo_Obligatorio_OCC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Crear_FCC_Desde_GRC_Vinculado_SII As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Revisar_OCC_Pendientes_X_Productos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Solicitar_Permiso_OCC_SOC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_No_Solicitar_Permiso_Entidad_Preferencial As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Usar_Validador_Prod_X_Compras As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents SpTab_Compras As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Chk_Revisar_Tasa_de_Cambio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Grabar_Despachos_Con_Huella As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_BloqEdiConcepDescuento As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_BloqEdiConcepRecargo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pedir_Permiso_Para_Usar_Stanby As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Revisar_Taza_Solo_Mon_Extranjeras As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents SpTab_General As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SpTab_Productos As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Numeraciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Excluir_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_DocConceptosVsPagos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Nodo_Raiz_Asociados As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents chk_Pr_Creacion_Exigir_Dimensiones As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pr_Desc_Producto_Solo_Mayusculas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pr_Creacion_Exigir_Codigo_Alternativo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pr_Creacion_Exigir_Precio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pr_Creacion_Exigir_Clasificacion_busqueda As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Conservar_Responzable_Doc_Relacionado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Asociar_Prod_Funcionarios As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_ValorMinimoNVV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SpTab_DatosEmpresa As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_CpEmpresa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Editar_Datos_Empresa As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_CpGiro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpPais As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpDireccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpRazon As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpNcorto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpRut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpActeco As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CpComuna As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_FacElec_Bakapp_Hefesto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Permisos_Descuentos_Por_Responzable As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_FacElect_Usar_AmbienteCertificacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Utilizar_Lectura_Codigo_QR As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Las_Cotizaciones_No_Revisan_Permisos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_CriterioFechaGDVconFechaDistintaDocOrigen As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_LeerSoloUnaVezCodBarra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_BloqCambNomCONCEPTOSEnDocumentos As DevComponents.DotNetBar.Controls.CheckBoxX
End Class