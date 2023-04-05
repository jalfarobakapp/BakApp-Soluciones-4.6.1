Imports DevComponents.DotNetBar

Public Class Frm_RecargosXProd

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Ds_Matriz_Documentos As DataSet
    Dim _Tbl_Maedcr As DataTable
    Dim _Fila As DataGridViewRow
    Dim _Id As Integer
    Dim _Recargo_Distribuido As Boolean
    Dim _Decimales = 2

    Dim _Grabar As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Valor_Recargo As Double
        Get
            Return Txt_Valor_Recargo.Tag
        End Get
        Set(value As Double)
            Txt_Valor_Recargo.Tag = value
        End Set
    End Property

    Public Property Recargo_Distribuido As Boolean
        Get
            Return _Recargo_Distribuido
        End Get
        Set(value As Boolean)
            _Recargo_Distribuido = value
        End Set
    End Property

    Public Sub New(_Ds_Matriz_Documentos As DataSet, _Fila As DataGridViewRow)

        ' Esta llamada es exigida pOr el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Ds_Matriz_Documentos = _Ds_Matriz_Documentos
        Me._Fila = _Fila

        _Id = _Fila.Cells("Id").Value

        Sb_Formato_Generico_Grilla(Grilla, 16, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        'CircularProgress1.IsRunning = True
        Bar2.Enabled = True
        CmbTipoDeDocumentos.Enabled = False
        Chk_BuscarDocDeHoy.Enabled = False

    End Sub

    Private Sub Frm_RecargosXProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_Sql = "Select TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo" & vbCrLf &
                       "From TABTIDO Where TIDO In ('BLV','BLX','FCC','FCV','GDP','GDV','GRC','GRD','GRI','GTI','OCC','GDD')" & vbCrLf &
                       "ORDER BY TIDO"
        caract_combo(CmbTipoDeDocumentos)
        CmbTipoDeDocumentos.DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)
        CmbTipoDeDocumentos.SelectedValue = "FCV"

        _Sql.Sb_Parametro_Informe_Sql(CmbTipoDeDocumentos, "TraerDocumentos", CmbTipoDeDocumentos.Name, Class_SQLite.Enum_Type._ComboBox, "FCV", False, "RecargosXProd")
        _Sql.Sb_Parametro_Informe_Sql(Chk_BuscarDocDeHoy, "TraerDocumentos", Chk_BuscarDocDeHoy.Name, Class_SQLite.Enum_Type._Boolean, False, False, "RecargosXProd")

        _Decimales = 5

        Txt_Valor_Recargo.Text = FormatCurrency(Txt_Valor_Recargo.Tag, 2)

        _Tbl_Maedcr = Fx_Crea_Tabla_Con_Filtro(_Ds_Matriz_Documentos.Tables("Maedcr"), "Id = " & _Id, "Id")

        Sb_Formato_Grilla_Detalle_Bakapp()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Sumar_Cantidades()

        Bar2.Enabled = False
        Tiempo.Start()

    End Sub

    Function Fx_Nueva_Linea(ByRef _Tbl As DataTable,
                            _Id As Integer,
                            _Empresa As String,
                            _Sulido As String,
                            _Tido As String,
                            _Nudo As String,
                            _Endo As String,
                            _Suendo As String,
                            _Cantidad As Double,
                            _ValNeto As Double,
                            _VUnitario As Double,
                            _Recargo As String,
                            _Peso As Double,
                            _Volumen As Double,
                            _Codigo As String,
                            _Descripcion As String,
                            _Nulido As String,
                            _Recarcalcu As String,
                            _Idddodcr As Integer,
                            _Valdcr As Double)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id") = _Id
            .Item("Empresa") = _Empresa
            .Item("Tido") = _Tido
            .Item("Nudo") = _Nudo
            .Item("Sulido") = _Sulido
            .Item("Endo") = _Endo
            .Item("Suendo") = _Suendo
            .Item("Cantidad") = _Cantidad
            .Item("ValNeto") = _ValNeto
            .Item("VUnitario") = _VUnitario
            .Item("Recargo") = _Recargo
            .Item("Peso") = _Peso
            .Item("Volumen") = _Volumen
            .Item("Codigo") = _Codigo
            .Item("Descripcion") = _Descripcion
            .Item("Nulido") = _Nulido
            .Item("Recarcalcu") = _Recarcalcu
            .Item("Idddodcr") = _Idddodcr
            .Item("Valdcr") = _Valdcr

            _Tbl.Rows.Add(NewFila)

        End With

    End Function

    Function Fx_Nueva_Linea(ByRef _Tbl As DataTable, _Fl As DataRow)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id") = _Fl.Item("Id")
            .Item("Empresa") = _Fl.Item("Empresa")
            .Item("Tido") = _Fl.Item("Tido")
            .Item("Nudo") = _Fl.Item("Nudo")
            .Item("Sulido") = _Fl.Item("Sulido")
            .Item("Endo") = _Fl.Item("Endo")
            .Item("Suendo") = _Fl.Item("Suendo")
            .Item("Cantidad") = _Fl.Item("Cantidad")
            .Item("ValNeto") = _Fl.Item("ValNeto")
            .Item("VUnitario") = _Fl.Item("VUnitario")
            .Item("Recargo") = _Fl.Item("Recargo")
            .Item("Peso") = _Fl.Item("Peso")
            .Item("Volumen") = _Fl.Item("Volumen")
            .Item("Codigo") = _Fl.Item("Codigo")
            .Item("Descripcion") = _Fl.Item("Descripcion")
            .Item("Nulido") = _Fl.Item("Nulido")
            .Item("Recarcalcu") = _Fl.Item("Recarcalcu")
            .Item("Idddodcr") = _Fl.Item("Idddodcr")
            .Item("Valdcr") = _Fl.Item("Valdcr")

            _Tbl.Rows.Add(NewFila)

        End With

    End Function

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        'If Not CBool(_Tbl_Maedcr.Rows.Count) Then
        '    MessageBoxEx.Show(Me, "No hay datos que exportar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        If Not CBool(Math.Round(Txt_Valor_Recargo.Tag, 0)) Then

            If MessageBoxEx.Show(Me, "Si el valor del recargo es cero se eliminaran los registros del concepto" & vbCrLf & vbCrLf &
                                 "¿Confirma el valor cero?", "Valor cero", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

        End If

        Eliminar_Campos(_Ds_Matriz_Documentos.Tables("Maedcr"), _Id)

        If CBool(Txt_Valor_Recargo.Tag) Then
            For Each _Fila As DataRow In _Tbl_Maedcr.Rows
                Fx_Nueva_Linea(_Ds_Matriz_Documentos.Tables("Maedcr"), _Fila)
            Next
        End If

        _Recargo_Distribuido = CBool(Math.Round(Txt_Valor_Recargo.Tag, 0))

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Btn_Traer_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Traer_Documento.Click

        Dim _vTido As String = CmbTipoDeDocumentos.SelectedValue
        Dim _vFechaHoy As Boolean = Chk_BuscarDocDeHoy.Checked

        Dim _FechaServidor As Date = FechaDelServidor()
        Dim _Fecha_Inicio As Date = DateAdd(DateInterval.Month, -1, _FechaServidor)
        Dim _Fecha_Fin As Date = _FechaServidor

        '_Sql.Sb_Parametro_Informe_Sql_String(_vTido, "TraerDocumentos", "vTido", "FCV", False, "RecargosXProd")

        '_Sql.Sb_Parametro_Informe_Sql(_vTido, "TraerDocumentos", "vTido", Class_SQLite.Enum_Type._String, "FCV", False, "RecargosXProd", True)
        '_Sql.Sb_Parametro_Informe_Sql(_vFechaHoy, "TraerDocumentos", "vFechahoy", Class_SQLite.Enum_Type._Boolean, False, False, "RecargosXProd", True)

        If _vFechaHoy Then
            _Fecha_Inicio = _FechaServidor
            _Fecha_Fin = _FechaServidor
        End If

        Dim _Recarcalcu As String = Me._Fila.Cells("Codigo").Value.ToString.Trim

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(True)

        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, _vTido,
                                 "Where TIDO In ('BLV','BLX','FCC','FCV','GDP','GDV','GRC','GRD','GRI','GTI','OCC','GDD')")
        _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
        _Fm.Rdb_Fecha_Emision_Cualquiera.Enabled = False
        _Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True
        _Fm.DtpFechaInicio.Value = _Fecha_Inicio
        _Fm.DtpFechaFin.Value = _Fecha_Fin
        _Fm.Seleccion_Multiple = True
        _Fm.Ocultar_Envio_Correos_Masivamente = True
        _Fm.Filtrar_Doc_No_Asociados_Recargo = True
        _Fm.Codigo_Recargo = _Recarcalcu
        _Fm.Rdb_Ver_Primeros.Checked = True
        _Fm.ShowDialog(Me)
        _vTido = _Fm.CmbTipoDeDocumentos.SelectedValue
        _Fecha_Inicio = _Fm.DtpFechaInicio.Value
        _Fecha_Fin = _Fm.DtpFechaFin.Value

        'If _FechaServidor.ToShortDateString = _Fecha_Inicio.ToShortDateString And _Fecha_Inicio.CompareTo(_Fecha_Fin) = 0 Then
        '    _vFechaHoy = True
        'Else
        '    _vFechaHoy = False
        'End If

        '_Sql.Sb_Parametro_Informe_Sql(_vFechaHoy, "TraerDocumentos", "vFechahoy", Class_SQLite.Enum_Type._Boolean, False, True, "RecargosXProd", True)
        '_Sql.Sb_Parametro_Informe_Sql(_vTido, "TraerDocumentos", "vTido", Class_SQLite.Enum_Type._String, "FCV", True, "RecargosXProd", True)


        Dim _Tbl_DocSeleccionados As DataTable = _Fm.Tbl_DocSeleccionados

        _Fecha_Inicio = _Fm.DtpFechaInicio.Value
        _Fecha_Fin = _Fm.DtpFechaFin.Value

        _Fm.Dispose()

        If IsNothing(_Tbl_DocSeleccionados) Then
            Return
        End If

        If Not CBool(_Tbl_DocSeleccionados.Rows.Count) Then
            Return
        End If

        Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Tbl_DocSeleccionados, "", "IDMAEEDO", False, False, "")

        Consulta_Sql = "Select Distinct Ddo.IDMAEEDO 
                        From MAEDDO Ddo
                        Left Join TABTIDO Tdo On Ddo.TIDO = Tdo.TIDO
                        Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                        Where 
	                        Ddo.EMPRESA = '" & ModEmpresa & "' 
                        And Edo.TIDO = 'FCV'
                        And LILG In ('SI','CR') 
                        And PRCT = 0
                        And (Ddo.CAPRCO1 * Tdo.FICO + Ddo.CAPRAD1 * Tdo.FIAD ) <> 0
                        And Not Exists (Select * From MAEDCR Where MAEDCR.IDDDODCR = Ddo.IDMAEDDO And MAEDCR.RECARCALCU = '" & _Recarcalcu & "')
                        And Edo.FEEMDO BETWEEN '" & Format(_Fecha_Inicio, "yyyyMMdd") & "' And '" & Format(_Fecha_Fin, "yyyyMMdd") & "'"

        Dim _Tbl_Filtro_Idmaeedo As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Consulta_Sql = "Select MAEEDO.IDMAEEDO,MAEEDO.EMPRESA,MAEEDO.SUDO,MAEEDO.TIDO,
                        MAEEDO.NUDO,MAEEDO.ENDO,MAEEDO.SUENDO,MAEEDO.FEEMDO,MAEEDO.KOFUDO,
                        MAEEDO.MODO,MAEEDO.VANEDO,MAEDDO.IDMAEDDO,MAEDDO.NULIDO,
				        MAEDDO.KOPRCT,MAEDDO.NOKOPR,MAEDDO.CAPRCO1,MAEDDO.UD01PR,MAEDDO.VANELI,
                        MAEDDO.OPERACION,MAEDDO.POTENCIA AS RECARGO,MAEPR.PESOUBIC,MAEPR.LTSUBIC,MAEEN.NOKOEN 
				        --Into #LISTADCR 
                        From MAEDDO WITH (NOLOCK) 
					        Inner Join MAEEDO On MAEEDO.IDMAEEDO = MAEDDO.IDMAEEDO 
						        Inner Join MAEPR On MAEPR.KOPR = MAEDDO.KOPRCT 
							        Inner Join TABTIDO On TABTIDO.TIDO = MAEDDO.TIDO 
								        Left Join MAEEN On MAEEDO.ENDO = MAEEN.KOEN And MAEEN.TIPOSUC = 'P' 
									Where 
									    
									    MAEEDO.EMPRESA = '" & ModEmpresa & "'  And 
									    MAEDDO.LILG IN ('SI','CR')  And 
									    MAEDDO.PRCT = 0 And 
									    
									    (MAEDDO.CAPRCO1 * TABTIDO.FICO + MAEDDO.CAPRAD1 * TABTIDO.FIAD ) <> 0  And 
									    Not Exists ( Select * FROM MAEDCR WHERE MAEDCR.IDDDODCR = MAEDDO.IDMAEDDO And MAEDCR.RECARCALCU = '" & _Recarcalcu & "') 
                                        
                                        And MAEDDO.IDMAEEDO In " & _Filtro_Idmaeedo & vbCrLf & "
                        Order By MAEDDO.KOPRCT"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If Not CBool(_Tbl.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen productos disponibles en este documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        For Each _Row As DataRow In _Tbl.Rows

            Dim _Empresa As String = _Row.Item("EMPRESA")
            Dim _Tido As String = _Row.Item("TIDO")
            Dim _Nudo As String = _Row.Item("NUDO")
            Dim _Sulido As String = _Row.Item("SUDO")
            Dim _Endo As String = _Row.Item("ENDO")
            Dim _Suendo As String = _Row.Item("SUENDO")
            Dim _Cantidad As Double = _Row.Item("CAPRCO1")
            Dim _ValNeto As Double = _Row.Item("VANELI")
            Dim _VUnitario As Double = 0
            Dim _Recargo As String = _Row.Item("RECARGO")
            Dim _Peso As Double = _Row.Item("PESOUBIC")
            Dim _Volumen As Double = _Row.Item("LTSUBIC")
            Dim _Codigo As String = _Row.Item("KOPRCT")
            Dim _Descripcion As String = _Row.Item("NOKOPR")
            Dim _Nulido As String = String.Empty
            'Dim _Recarcalcu As String = Me._Fila.Cells("Codigo").Value.ToString.Trim
            Dim _Idddodcr As Integer = _Row.Item("IDMAEDDO")
            Dim _Valdcr As Double = 0

            Fx_Nueva_Linea(_Tbl_Maedcr, _Id, _Empresa, _Sulido, _Tido, _Nudo, _Endo, _Suendo, _Cantidad, _ValNeto, _VUnitario,
                           _Recargo, _Peso, _Volumen, _Codigo, _Descripcion, "", _Recarcalcu, _Idddodcr, _Valdcr)

        Next

        Sb_Sumar_Cantidades()

    End Sub

    Sub Sb_Formato_Grilla_Detalle_Bakapp()

        With Grilla

            .DataSource = _Tbl_Maedcr

            OcultarEncabezadoGrilla(Grilla, False)

            Dim _Displayindex = 0
            Dim _Campo As String

            _Campo = "Empresa"
            .Columns(_Campo).HeaderText = "Emp"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Sulido"
            .Columns(_Campo).HeaderText = "Suc"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Tido"
            .Columns(_Campo).HeaderText = "TD"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Nudo"
            .Columns(_Campo).HeaderText = "Número"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 100
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Endo"
            .Columns(_Campo).HeaderText = "Entidad"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 90
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Suendo"
            .Columns(_Campo).HeaderText = "Suc"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 35
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Codigo"
            .Columns(_Campo).HeaderText = "Producto"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 100
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Cantidad"
            .Columns(_Campo).HeaderText = "Cant."
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 80
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "ValNeto"
            .Columns(_Campo).HeaderText = "Valor Neto"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 80
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Valdcr"
            .Columns(_Campo).HeaderText = "Valor Distr."
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 80
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "VUnitario"
            .Columns(_Campo).HeaderText = "Unitario"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 80
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Recargo"
            .Columns(_Campo).HeaderText = "Recargo"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 80
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Peso"
            .Columns(_Campo).HeaderText = "Peso"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 80
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Volumen"
            .Columns(_Campo).HeaderText = "Volumen"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).Width = 80
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##0.##"
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

        End With

    End Sub

    Private Sub Btn_Calcular_Recargo_Click(sender As Object, e As EventArgs) Handles Btn_Calcular_Recargo.Click

        If Not CBool(_Tbl_Maedcr.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Chk_Distribuir_Segun_Valor As New Command
        Chk_Distribuir_Segun_Valor.Checked = True
        Chk_Distribuir_Segun_Valor.Name = "Chk_Distribuir_Segun_Valor"
        Chk_Distribuir_Segun_Valor.Text = "Ingresar valor y distribuir según valor"

        Dim Chk_Distribui_X_Peso_Producto As New Command
        Chk_Distribui_X_Peso_Producto.Checked = False
        Chk_Distribui_X_Peso_Producto.Name = "Chk_Distribui_X_Peso_Producto"
        Chk_Distribui_X_Peso_Producto.Text = "Ingresar valor y distribuir según peso del producto"

        Dim Chk_Distribui_X_Cantidad_Producto As New Command
        Chk_Distribui_X_Cantidad_Producto.Checked = False
        Chk_Distribui_X_Cantidad_Producto.Name = "Chk_Distribui_X_Cantidad_Producto"
        Chk_Distribui_X_Cantidad_Producto.Text = "Ingresar valor y distribuir según cantidad de cada producto"

        Dim Chk_Calcular_Segun_Porcentaje As New Command
        Chk_Calcular_Segun_Porcentaje.Checked = False
        Chk_Calcular_Segun_Porcentaje.Name = "Chk_Calcular_Segun_Porcentaje"
        Chk_Calcular_Segun_Porcentaje.Text = "Calcular valor según porcentaje a indicar y aplicar según valor"


        Dim _Opciones() As Command = {Chk_Distribuir_Segun_Valor, Chk_Distribui_X_Peso_Producto,
                                      Chk_Distribui_X_Cantidad_Producto, Chk_Calcular_Segun_Porcentaje}


        Dim _Info As New TaskDialogInfo("Calculo de valor del recargo",
                  eTaskDialogIcon.Bulb,
                  "Selección de criterio de calculo",
                  "Confirme su opción",
                  eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado = eTaskDialogResult.Ok Then

            Dim _Aceptar As Boolean
            Dim _Valor_Recargo As Double

            _Aceptar = InputBox_Bk(Me, "Valor:", "Ingrese el valor", _Valor_Recargo, False,,, True, _Tipo_Imagen.Texto, False, _Tipo_Caracter.Moneda, False)

            If Not _Aceptar Then
                Txt_Valor_Recargo.Tag = 0
                Txt_Valor_Recargo.Text = FormatCurrency(Txt_Valor_Recargo.Tag, 0)
                Return
            End If

            Dim _Tipo_Calculo As Enum_Tipo_Calculo

            If Chk_Distribuir_Segun_Valor.Checked Then _Tipo_Calculo = Enum_Tipo_Calculo.Distribuir_Segun_Valor
            If Chk_Distribui_X_Peso_Producto.Checked Then _Tipo_Calculo = Enum_Tipo_Calculo.Distribui_X_Peso_Producto
            If Chk_Distribui_X_Cantidad_Producto.Checked Then _Tipo_Calculo = Enum_Tipo_Calculo.Distribui_X_Cantidad_Producto
            If Chk_Calcular_Segun_Porcentaje.Checked Then _Tipo_Calculo = Enum_Tipo_Calculo.Calcular_Segun_Porcentaje

            Txt_Valor_Recargo.Tag = Fx_Recalcular_Valores(_Valor_Recargo, _Tipo_Calculo)
            Txt_Valor_Recargo.Text = FormatCurrency(Txt_Valor_Recargo.Tag, 2)

        End If

    End Sub

    Enum Enum_Tipo_Calculo
        Distribuir_Segun_Valor
        Distribui_X_Peso_Producto
        Distribui_X_Cantidad_Producto
        Calcular_Segun_Porcentaje
    End Enum

    Function Fx_Recalcular_Valores(_Valor_Recargo As Double, _Tipo_Calculo As Enum_Tipo_Calculo) As Double

        Dim _Suma_Valores, _Suma_Cantiades, _Suma_Peso As Double

        For Each _Fl As DataRow In _Tbl_Maedcr.Rows

            _Suma_Valores += _Fl.Item("ValNeto")
            _Suma_Peso += _Fl.Item("Peso")
            _Suma_Cantiades += _Fl.Item("Cantidad")

        Next

        Dim _VUnit_Valores As Double = Math.Round(_Valor_Recargo / _Suma_Valores, _Decimales)
        Dim _VUnit_Peso As Double = Math.Round(_Valor_Recargo / _Suma_Peso, _Decimales)
        Dim _VUnit_Cantidades As Double = Math.Round(_Valor_Recargo / _Suma_Cantiades, _Decimales)

        Dim _New_Valor_Recargo As Double

        For Each _Fl As DataRow In _Tbl_Maedcr.Rows

            Dim _Porc_Valor = _Fl.Item("ValNeto") / _Suma_Valores
            Dim _Porc_Peso = _Fl.Item("Peso") / _Suma_Peso
            Dim _Porc_Cantidad = _Fl.Item("Cantidad") / _Suma_Cantiades
            Dim _Porcentaje = _Valor_Recargo / 100

            Dim _Valdcr, _VUnitario As Double

            Select Case _Tipo_Calculo

                Case Enum_Tipo_Calculo.Distribuir_Segun_Valor

                    _Valdcr = Math.Round(_Porc_Valor * _Valor_Recargo, _Decimales)
                    _VUnitario = Math.Round(_Valdcr / _Fl.Item("Cantidad"), _Decimales)

                Case Enum_Tipo_Calculo.Distribui_X_Peso_Producto

                    _Valdcr = Math.Round(_Fl.Item("Peso") * _VUnit_Peso, _Decimales)
                    _VUnitario = Math.Round(_Valdcr / _Fl.Item("Cantidad"), _Decimales)

                Case Enum_Tipo_Calculo.Distribui_X_Cantidad_Producto

                    _Valdcr = Math.Round(_Fl.Item("Cantidad") * _VUnit_Cantidades, _Decimales)
                    _VUnitario = _VUnit_Cantidades

                Case Enum_Tipo_Calculo.Calcular_Segun_Porcentaje

                    _Valdcr = Math.Round(_Fl.Item("ValNeto") * _Porcentaje, _Decimales)
                    _VUnitario = Math.Round(_Valdcr / _Fl.Item("Cantidad"), _Decimales)

            End Select

            _Fl.Item("Valdcr") = _Valdcr
            _Fl.Item("VUnitario") = _VUnitario

            _New_Valor_Recargo += _Valdcr

        Next

        Return _New_Valor_Recargo

    End Function

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            If e.KeyValue = Keys.Delete Then

                If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar esta fila?", "Eliminar fila",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim _Valdcr = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Valdcr").Value

                    Txt_Valor_Recargo.Tag = Txt_Valor_Recargo.Tag - _Valdcr
                    Txt_Valor_Recargo.Text = FormatCurrency(Txt_Valor_Recargo.Tag, _Decimales)

                    Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                    Sb_Sumar_Cantidades()

                End If

            End If

            If e.KeyValue = Keys.Enter Then

                If _Cabeza = "VUnitario" Then

                    Grilla.Columns(_Cabeza).ReadOnly = False
                    Grilla.BeginEdit(True)

                    e.SuppressKeyPress = False
                    e.Handled = True

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _VUnitario As Double = _Fila.Cells("VUnitario").Value
        Dim _Valdcr As Double = _Fila.Cells("Valdcr").Value
        Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value

        _Valdcr = Math.Round(_VUnitario * _Cantidad, _Decimales)

        _Fila.Cells("Valdcr").Value = _Valdcr

        Dim _Suma_Recargos As Double

        For Each _Fl As DataRow In _Tbl_Maedcr.Rows
            _Suma_Recargos += _Fl.Item("Valdcr")
        Next

        Txt_Valor_Recargo.Tag = _Suma_Recargos
        Txt_Valor_Recargo.Text = FormatCurrency(Txt_Valor_Recargo.Tag, 2)

        Grilla.Columns(_Cabeza).ReadOnly = True

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla 'Sb_Validar_Keypress
    End Sub

    Sub Sb_Sumar_Cantidades()

        Txt_Total_Cantidades.Tag = 0

        For Each _Fila As DataRow In _Tbl_Maedcr.Rows
            Txt_Total_Cantidades.Tag += _Fila.Item("Cantidad")
        Next

        Txt_Total_Cantidades.Text = FormatNumber(Txt_Total_Cantidades.Tag, 2)

    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick
        CircularProgress1.Visible = False
        CircularProgress1.IsRunning = True
        Bar2.Enabled = True
        CmbTipoDeDocumentos.Enabled = True
        Chk_BuscarDocDeHoy.Enabled = True
        Tiempo.Stop()
    End Sub

    Private Sub Frm_RecargosXProd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Sql.Sb_Parametro_Informe_Sql(CmbTipoDeDocumentos, "TraerDocumentos", CmbTipoDeDocumentos.Name, Class_SQLite.Enum_Type._ComboBox, "FCV", True, "RecargosXProd")
        _Sql.Sb_Parametro_Informe_Sql(Chk_BuscarDocDeHoy, "TraerDocumentos", Chk_BuscarDocDeHoy.Name, Class_SQLite.Enum_Type._Boolean, False, True, "RecargosXProd")
    End Sub
End Class
