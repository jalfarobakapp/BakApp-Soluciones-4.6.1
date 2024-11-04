Imports DevComponents.DotNetBar

Public Class Frm_Mt_InvParc_02_Seleccion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim CodigoActivo As String
    Dim Item As Integer
    Dim Tabla_Paso_Inv As String = "Zw_TmpInv_" & FUNCIONARIO

    Dim ConsultaSQLGrilla As String
    Dim FechaInv As String
    'Public _Nombre_Ajuste As String

    Dim Ds_Invent As New Ds_Invent_parcial

    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String

    Dim _Ajuste_PM As Boolean

    Dim _Row_InvParcial_Inventarios As DataRow

    Dim _Producto_Op As New Frm_BkpPostBusquedaEspecial_Mt

    Dim _Tbl_Productos_A_Contar As DataTable
    Dim _Tbl_Productos_Contados As DataTable
    Dim _Autorizado_Ajustar As Boolean

    Public ReadOnly Property Pro_Cant_Productos() As Integer
        Get
            Dim _Cantidad As Integer
            If _Tbl_Productos_Contados.Rows.Count Then
                Dim _Fl = Generar_Filtro_IN(_Tbl_Productos_Contados, "", "CodigoPr", False, False, "'")
                Consulta_sql = "Select Distinct Count(*) As Cantidad From MAEPR Where KOPR IN " & _Fl
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                _Cantidad = _Row.Item("Cantidad")
            Else
                _Cantidad = 0
            End If
            Return _Cantidad
        End Get
    End Property

    Public Sub New(Empresa As String,
                   Sucursal As String,
                   Bodega As String,
                   Fecha As Date,
                   Ajuste_PM As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Levantados, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Dim _Fecha = Format(Fecha, "yyyyMMdd")

        DtFechaInv.Value = Fecha
        _Empresa = Empresa
        _Sucursal = Sucursal
        _Bodega = Bodega

        If Not Ajuste_PM Then

            Consulta_sql = "SELECT Top 1 Id,Ano,Mes,Dia,Fecha,Empresa,Sucursal,Bodega,Nombre_Ajuste,Funcionario,Estado" & vbCrLf &
                                   "From " & _Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios" & vbCrLf &
                                   "Where Empresa = '" & _Empresa &
                                   "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Fecha = '" & _Fecha & "'"

            _Row_InvParcial_Inventarios = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        _Ajuste_PM = Ajuste_PM

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnProcesar.ForeColor = Color.White
            Btn_Consolidar_Stock.ForeColor = Color.White
            Lbl_Nombre_Producto_Linea_Activa_Grilla.BackColor = Color.Black
        End If

        Btn_Foto_Stock.Visible = False

    End Sub

    Private Sub Frm_Mt_InvParc_02_Seleccion_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Sb_Actualizar_Formulario()

        AddHandler DtFechaInv.ValueChanged, AddressOf DtFechaInv_ValueChanged

        AddHandler Btn_Mnu_Editar_Descripcion_Producto.Click, AddressOf Sb_Editar_Descripcion_Del_Producto

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.Leave, AddressOf Grilla_Leave
        AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
        AddHandler Grilla.CellEnter, AddressOf Grilla_CellEnter
        AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit

        AddHandler Grilla_Levantados.MouseDown, AddressOf Sb_Grilla_MouseDown

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Levantados.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Me.ActiveControl = Grilla

        If FormatDateTime(DtFechaInv.Value, DateFormat.ShortDate) = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate) Then
            _Autorizado_Ajustar = True
        End If

        Sb_Marcar_Grilla(Grilla)

        Chk_Dejar_Doc_Final_Del_Dia.Enabled = True

    End Sub

    Private Sub Frm_Mt_InvParc_02_Seleccion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Sb_Nueva_Fila()

        Dim _Preguntar As Boolean

        If Grilla.Rows.Count > 0 Then

            If Grilla.RowCount = 1 Then
                Dim _Nuevo_Producto As Boolean = Grilla.Rows(0).Cells("Nuevo_Producto").Value = True
                If Not _Nuevo_Producto Then
                    _Preguntar = True
                End If
            Else
                _Preguntar = True
            End If

        End If

        If _Preguntar Then

            Dim dlg As System.Windows.Forms.DialogResult =
            MessageBoxEx.Show(Me, "Existen datos en la lista que aun no  han sido levantados" & vbCrLf &
                              "¿Desea salir sin hacer ninguna acción, los datos de la lista se perderán?",
                              "Cerrar ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dlg = System.Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else

                MessageBoxEx.Show(Me, "Los productos se desocultaran", "Salir",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                With Grilla
                    For Each row As DataGridViewRow In .Rows
                        Dim _Codigo As String = Trim(row.Cells("CodigoPr").Value)

                        Consulta_sql = "Update MAEPR Set ATPR = '' Where KOPR = '" & _Codigo & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    Next
                End With
            End If

        End If

    End Sub


    Sub Sb_Actualizar_Formulario()

        Me.Enabled = False

        Try

            Dim Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")
            Sb_Cargar_Grilla_Inv_Parcial(Fecha)

            If _Ajuste_PM Then

                Btn_Importar_Productos.Visible = False

            Else
                Sb_Cargar_Grilla_Inv_Parcial_Levantados(Fecha)
            End If

            Super_Tab.SelectedTabIndex = 0

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            'Fm.Dispose()
            Me.Enabled = True
        End Try

    End Sub

#Region "PROCEDIMIENTOS"

#Region "CREAR TABLA DE PASO"
    Private Sub Crear_Tabla_Paso(Fecha As String)

        Consulta_sql = "Drop table " & Tabla_Paso_Inv
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = My.Resources._23_ConsultasSQL.Crea_Tabla_de_paso_inventario
        Consulta_sql = Replace(Consulta_sql, "#Zw_TmpInv_#", Tabla_Paso_Inv)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Fecha)
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub
#End Region

#Region "CARGAR DATOS EN GRILLAS"

    Private Function Sb_Cargar_Grilla_Inv_Parcial(Fecha As String)

        Ds_Invent.Clear()

        _Tbl_Productos_A_Contar = Ds_Invent.Tables("Inv_InvParcial")

        Grilla.DataSource = Ds_Invent '.Tables("DetalleDocumento")
        Grilla.DataMember = Ds_Invent.Tables("Inv_InvParcial").TableName

        Sb_Formato_Grilla(Grilla)
        Sb_Nueva_Fila()
        Grilla.Focus()


    End Function

    Private Function Sb_Cargar_Grilla_Inv_Parcial_Levantados(Fecha As String)

        Consulta_sql = "Select *," &
                       "CAST(0 as Bit) As GDI_Cero_Nula," &
                       "CAST(0 as Bit) As GRI_Cero_Nula," &
                       "CAST(0 as Bit) As GRI_Ajuste_Nula" & vbCrLf &
                       "Into #Paso_Inv FROM " & _Global_BaseBk & "Zw_TmpInv_InvParcial" & vbCrLf &
                       "Where FechaInv = '" & Fecha & "'" & vbCrLf &
                       "And Levantado = 1" & vbCrLf &
                       "And DejaStockCero = 0" & vbCrLf &
                       "Order by CodigoPr,Semilla Desc" & vbCrLf & vbCrLf &
                       "Update #Paso_Inv Set StockActual = Isnull((Select Top 1 STFI1 From MAEST" & Space(1) &
                       "Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = CodigoPr),0)" & vbCrLf &
                       "Update #Paso_Inv Set GRI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GRI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Update #Paso_Inv Set GDI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GDI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Update #Paso_Inv Set GRI_Ajuste_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = IDMAEEDO_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Select * From #Paso_Inv" & vbCrLf &
                       "Order by CodigoPr,Semilla Desc" & vbCrLf &
                       "Drop Table #Paso_Inv"

        _Tbl_Productos_Contados = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Levantados

            .DataSource = _Tbl_Productos_Contados

            OcultarEncabezadoGrilla(Grilla_Levantados, True)

            '.Columns("Bodega").Width = 30
            '.Columns("Bodega").HeaderText = "Bod"
            '.Columns("Bodega").Visible = True
            '.Columns("Bodega").DisplayIndex = 0

            Dim _DisplayIndex = 0

            .Columns("CodigoPr").Width = 100
            .Columns("CodigoPr").HeaderText = "Código"
            .Columns("CodigoPr").ReadOnly = True
            .Columns("CodigoPr").Visible = True
            .Columns("CodigoPr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodBarras").Width = 110
            .Columns("CodBarras").HeaderText = "Código de Barras"
            .Columns("CodBarras").ReadOnly = True
            .Columns("CodBarras").Visible = True
            .Columns("CodBarras").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 165 + 150
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rtu").Width = 30
            .Columns("Rtu").ReadOnly = True
            .Columns("Rtu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rtu").Visible = True
            .Columns("Rtu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd1").Width = 40 ' columna 8
            .Columns("CantidadUd1").HeaderText = "Cant."
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").Visible = True
            .Columns("CantidadUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd2").Width = 40 ' columna 9
            .Columns("CantidadUd2").HeaderText = "Cant. Ud2"
            .Columns("CantidadUd2").ReadOnly = True
            .Columns("CantidadUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd2").Visible = True
            .Columns("CantidadUd2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_GDI_Stock_Cero").Width = 100 ' columna 9
            .Columns("Nro_GDI_Stock_Cero").HeaderText = "GDI Ajuste"
            .Columns("Nro_GDI_Stock_Cero").ReadOnly = True
            '.Columns("Nro_GDI_Stock_Cero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_GDI_Stock_Cero").Visible = True
            .Columns("Nro_GDI_Stock_Cero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_GRI_Stock_Cero").Width = 100 ' columna 9
            .Columns("Nro_GRI_Stock_Cero").HeaderText = "GRI Ajuste"
            .Columns("Nro_GRI_Stock_Cero").ReadOnly = True
            '.Columns("Nro_GRI_Stock_Cero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_GRI_Stock_Cero").Visible = True
            .Columns("Nro_GRI_Stock_Cero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_GRI_Ajuste_Stock").Width = 100 ' columna 9
            .Columns("Nro_GRI_Ajuste_Stock").HeaderText = "GRI Ajuste Def."
            .Columns("Nro_GRI_Ajuste_Stock").ReadOnly = True
            '.Columns("Nro_GRI_Ajuste_Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_GRI_Ajuste_Stock").Visible = True
            .Columns("Nro_GRI_Ajuste_Stock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockActual").Width = 45
            .Columns("StockActual").HeaderText = "Stock Actual"
            .Columns("StockActual").ReadOnly = True
            .Columns("StockActual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockActual").Visible = True
            .Columns("StockActual").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Foto_Stock_Ud1").Width = 45
            .Columns("Foto_Stock_Ud1").HeaderText = "Foto Stock"
            .Columns("Foto_Stock_Ud1").DefaultCellStyle.Format = "###,##"
            .Columns("Foto_Stock_Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Foto_Stock_Ud1").Visible = True
            .Columns("Foto_Stock_Ud1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("CostoUnitUd1").Width = 60
            '.Columns("CostoUnitUd1").HeaderText = "Costo"
            '.Columns("CostoUnitUd1").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("CostoUnitUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("CostoUnitUd1").Visible = True
            '.Columns("CostoUnitUd1").DisplayIndex = 8

            '.Columns("TotalCostoUd1").Width = 60
            '.Columns("TotalCostoUd1").HeaderText = "Total"
            '.Columns("TotalCostoUd1").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("TotalCostoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("TotalCostoUd1").Visible = True
            '.Columns("TotalCostoUd1").DisplayIndex = 9

            '.Columns("Levantado").Width = 40
            '.Columns("Levantado").HeaderText = "Lev."
            '.Columns("Levantado").ReadOnly = True
            '.Columns("Bodega").DisplayIndex = 10

            'Sb_Marcar_Grilla(Grilla_Levantados)


            'InsertarBotonenGrilla(Grilla, "Btn_GDI_Cero", "", "GDI 0", 8, _Tipo_Boton.Imagen)
            'InsertarBotonenGrilla(Grilla, "Btn_GRI_Cero", "", "GRI 0", 9, _Tipo_Boton.Imagen)
            'InsertarBotonenGrilla(Grilla, "Btn_GRI_Ajuste", "", "GRI Ajuste", 10, _Tipo_Boton.Imagen)

            'For Each _Row As DataGridViewRow In Grilla.Rows

            'Dim _GDI_Idmaeedo_Aj = CBool(_Row.Cells("GDI_Idmaeedo_Aj").Value)
            'Dim _GRI_Idmaeedo_Aj = CBool(_Row.Cells("GRI_Idmaeedo_Aj").Value)
            'Dim _IDMAEEDO_Aj = CBool(_Row.Cells("IDMAEEDO_Aj").Value)

            'If _GDI_Idmaeedo_Aj Then
            '_Row.Cells("Btn_GDI_Cero").Value = Img_Imagenes.Images("GDI_Cero_True")
            'Else
            '_Row.Cells("Btn_Cmb").Value = Img_Imagenes.Images("GDI_Cero_True")
            'End If

            'Next

            'Sb_Formato_Grilla(Grilla_Levantados)

        End With

    End Function

    Sub Sb_Formato_Grilla(Grilla As DataGridView)

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)


            Dim _Mostrar_Campo = True
            If _Ajuste_PM Then _Mostrar_Campo = False

            .Columns("Bodega").Width = 40
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Visible = _Mostrar_Campo

            .Columns("CodigoPr").Width = 100
            .Columns("CodigoPr").HeaderText = "Código"
            .Columns("CodigoPr").Visible = True

            .Columns("CodBarras").Width = 120
            .Columns("CodBarras").HeaderText = "Código de Barras"
            .Columns("CodBarras").Visible = True

            .Columns("Descripcion").Width = 290
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

            .Columns("Rtu").Width = 30
            .Columns("Rtu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rtu").Visible = True

            .Columns("StockActual").Width = 45
            .Columns("StockActual").HeaderText = "Foto Stock"
            .Columns("StockActual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockActual").Visible = _Mostrar_Campo

            .Columns("CantidadUd1").Width = 40 ' columna 8
            .Columns("CantidadUd1").HeaderText = "Cant."
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").Visible = _Mostrar_Campo

            .Columns("CantidadUd2").Width = 50 ' columna 9
            .Columns("CantidadUd2").HeaderText = "Cant. Ud2"
            .Columns("CantidadUd2").DefaultCellStyle.Format = "###,##"
            .Columns("CantidadUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd2").Visible = _Mostrar_Campo

            .Columns("CostoUnitUd1").Width = 60

            'If _Ajuste_PM Then
            .Columns("CostoUnitUd1").HeaderText = "PM"
            .Columns("CostoUnitUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("CostoUnitUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CostoUnitUd1").Visible = True

            .Columns("TotalCostoUd1").Width = 60
            .Columns("TotalCostoUd1").HeaderText = "Total"
            .Columns("TotalCostoUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCostoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCostoUd1").Visible = _Mostrar_Campo
            'Else
            '.Columns("CostoUnitUd1").HeaderText = "Costo"
            '.Columns("CostoUnitUd1").Visible = True
            'End If



            .Columns("Levantado").Width = 40
            .Columns("Levantado").HeaderText = "Lev."

            .Columns("Oculto").Width = 50
            .Columns("Oculto").HeaderText = "Oculto"
            .Columns("Oculto").Visible = True
            .Columns("Oculto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Horagrab").Width = 60
            .Columns("Horagrab").HeaderText = "Hora Inv."
            .Columns("Horagrab").Visible = True
            .Columns("Horagrab").DefaultCellStyle.Format = "HH:mm:ss"
            .Columns("Horagrab").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Sb_Marcar_Grilla(Grilla)

        End With
    End Sub

    Sub Sb_Marcar_Grilla(Grilla As Object)
        Return
        Try
            Me.Cursor = Cursors.WaitCursor



            With Grilla

                For Each _Fila As DataGridViewRow In CType(Grilla, DataGridView).Rows

                    Dim Levantado As Boolean = NuloPorNro(_Fila.Cells("Levantado").Value, False)
                    Dim Inventariado_Antes As Boolean

                    Try
                        Inventariado_Antes = _Fila.Cells("Inventariado_Antes").Value
                    Catch ex As Exception
                        Inventariado_Antes = True
                    End Try


                    If Levantado Then
                        '_Fila.DefaultCellStyle.ForeColor = Color.Gray
                        Dim _Contado As Double = _Fila.Cells("CantidadUd1").Value
                        Dim _Stock_Actual As Double = _Fila.Cells("StockActual").Value

                        If _Stock_Actual > 0 Then
                            _Fila.Cells("StockActual").Style.ForeColor = Color.DarkGreen
                        ElseIf _Stock_Actual < 0 Then
                            _Fila.Cells("StockActual").Style.ForeColor = Color.Red
                        End If


                        Dim _GDI_Cero_Nula = CBool(_Fila.Cells("GDI_Cero_Nula").Value)
                        Dim _GRI_Cero_Nula = CBool(_Fila.Cells("GRI_Cero_Nula").Value)
                        Dim _GRI_Ajuste_Nula = CBool(_Fila.Cells("GRI_Ajuste_Nula").Value)

                        Dim _GDI_Idmaeedo_Aj = CBool(_Fila.Cells("GDI_Idmaeedo_Aj").Value)
                        Dim _GRI_Idmaeedo_Aj = CBool(_Fila.Cells("GRI_Idmaeedo_Aj").Value)
                        Dim _IDMAEEDO_Aj = CBool(_Fila.Cells("IDMAEEDO_Aj").Value)

                        Dim _Ajuste_Nulo = False

                        If _GDI_Idmaeedo_Aj Then
                            If _GDI_Cero_Nula Then
                                _Fila.Cells("Nro_GDI_Stock_Cero").Style.ForeColor = Color.Red
                                _Fila.Cells("Nro_GDI_Stock_Cero").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                                _Ajuste_Nulo = True
                            Else
                                _Fila.Cells("Nro_GDI_Stock_Cero").Style.ForeColor = Color.Green
                            End If
                        End If

                        If _GRI_Idmaeedo_Aj Then
                            If _GRI_Cero_Nula Then
                                _Fila.Cells("Nro_GRI_Stock_Cero").Style.ForeColor = Color.Red
                                _Fila.Cells("Nro_GRI_Stock_Cero").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                                _Ajuste_Nulo = True
                            Else
                                _Fila.Cells("Nro_GRI_Stock_Cero").Style.ForeColor = Color.Green
                            End If
                        End If

                        If _IDMAEEDO_Aj Then
                            If _GRI_Ajuste_Nula Then
                                _Fila.Cells("Nro_GRI_Ajuste_Stock").Style.ForeColor = Color.Red
                                _Fila.Cells("Nro_GRI_Ajuste_Stock").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                                _Ajuste_Nulo = True
                            Else
                                _Fila.Cells("Nro_GRI_Ajuste_Stock").Style.ForeColor = Color.Green
                            End If
                        End If

                        If _Ajuste_Nulo Then
                            _Fila.Cells("Descripcion").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                            _Fila.Cells("CantidadUd1").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                            _Fila.Cells("CantidadUd2").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                        End If

                    End If

                    If Not Levantado And Inventariado_Antes Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Red
                    End If

                    If _Ajuste_PM Then
                        _Fila.Cells("CostoUnitUd1").Style.BackColor = Color.Yellow
                    Else
                        _Fila.Cells("CantidadUd1").Style.BackColor = Color.Yellow
                    End If

                Next
            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try

        Me.Refresh()

    End Sub

#End Region

#Region "AGREGAR NUEVA LINEA, CODIGO"

    'Sub Sb_Agregar_nueva_linea()
    '   With Grilla

    'Dim Columna As Integer = .CurrentCellAddress.X
    'Dim Fila As Integer = .CurrentCellAddress.Y

    'Dim Filas As Integer = .Rows.Count - 1

    '        If Filas = Fila Then '.CurrentRow.Index Then
    '            If Agregar_Nuevo_Producto_() Then
    '                If Not _Ajuste_PM Then .CurrentCell = .Rows(Fila + 1).Cells("CantidadUd1") '.Rows(.CurrentRow.Index).Cells("Codigo")
    '                .BeginEdit(True)
    '            End If
    '        End If
    '    End With
    'End Sub

    Sub Sb_Nueva_Fila()

        If CBool(Grilla.Rows.Count) Then
            Dim _Nuevo_Producto = Grilla.Rows(Grilla.Rows.Count - 1).Cells("Nuevo_Producto").Value
            If _Nuevo_Producto Then Return
        End If

        Dim NewFila As DataRow
        NewFila = Ds_Invent.Tables("Inv_InvParcial").NewRow
        With NewFila

            .Item("Empresa") = _Empresa
            .Item("Sucursal") = _Sucursal
            .Item("Bodega") = _Bodega
            .Item("CodigoPr") = ""
            .Item("Descripcion") = ""

            .Item("CodBarras") = ""
            .Item("Rtu") = 0

            If _Ajuste_PM Then
                .Item("CantidadUd1") = 0
                .Item("CantidadUd2") = 0
            Else
                .Item("CantidadUd1") = 0
                .Item("CantidadUd2") = 0
            End If

            .Item("CostoUnitUd1") = 0
            .Item("TotalCostoUd1") = 0
            .Item("StockActual") = 0
            .Item("Inventariado_Antes") = False
            .Item("Fecha_Antes") = DtFechaInv.Value
            .Item("Oculto") = ""
            .Item("Nuevo_Producto") = True

            .Item("GDI_Idmaeedo_Aj") = 0
            .Item("GRI_Idmaeedo_Aj") = 0
            .Item("IDMAEEDO_Aj") = 0

            .Item("Nro_GDI_Stock_Cero") = ""
            .Item("Nro_GRI_Stock_Cero") = ""
            .Item("Nro_GRI_Ajuste_Stock") = ""

            .Item("Horagrab") = FechaDelServidor()

            Ds_Invent.Tables("Inv_InvParcial").Rows.Add(NewFila)
        End With

        Grilla.CurrentCell = Grilla.Rows(Grilla.Rows.Count - 1).Cells("CodigoPr")

    End Sub

    Function Fx_Agregar_Nuevo_Producto_(_RowProducto As DataRow,
                                        _Fila As DataGridViewRow) As Boolean

        Dim _Codigo As String = _RowProducto.Item("KOPR")
        Dim _Descripcion As String = _RowProducto.Item("NOKOPR")

        Dim _Condicion_Maest As String

        If _Ajuste_PM Then
            _Condicion_Maest = "Where EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'"
        Else
            _Condicion_Maest = "Where EMPRESA = '" & _Empresa & "'" & vbCrLf &
                               "AND KOSU = '" & _Sucursal & "'" & vbCrLf &
                               "AND KOBO = '" & _Bodega & "'" & vbCrLf &
                               "AND KOPR = '" & _Codigo & "'"
        End If

        Consulta_sql = "Select ISNULL(SUM(STFI1),0) AS STFI1,ISNULL(SUM(STFI2),0) AS STFI2 FROM MAEST " & _Condicion_Maest
        Dim _TblStock As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _StockUd1 As Double
        Dim _StockUd2 As Double

        If CBool(_TblStock.Rows.Count) Then
            _StockUd1 = _TblStock.Rows(0).Item("STFI1")
            _StockUd2 = _TblStock.Rows(0).Item("STFI2")
        End If

        If _Ajuste_PM Then
            If Not CBool(_StockUd1) Then

                MessageBoxEx.Show(Me, "Este producto no tiene Stock, por lo tanto no se puede ajustar el PM",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If

        Dim _CodAlternativo As String = _Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL", "KOPR = '" & _Codigo & "' AND KOEN = ''")
        Dim _Rtu As Double = _RowProducto.Item("RLUD")


        Dim _Inventariado_Antes As Boolean
        Dim _Fecha_Antes As Date = Now.Date

        Dim RevisarPr As Integer

        Dim Existe_Object As Object
        Existe_Object = Ds_Invent.Tables("Inv_InvParcial").Compute("Count(CodigoPr)",
                                                                   "CodigoPr = '" & _Codigo & "'")
        Dim _tb = Ds_Invent.Tables("Inv_InvParcial")

        If Grilla.Rows.Count > 1 Then

            If CBool(Existe_Object) Then
                Dim Fecha = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TmpInv_InvParcial",
                                              "convert(varchar, FechaInv, 103)",
                                              "Empresa = '" & _Empresa & "' and " &
                                              "Sucursal = '" & _Sucursal & "'and " &
                                              "Bodega = '" & _Bodega & "' and " &
                                              "CodigoPr = '" & _Codigo & "' and " &
                                              "Levantado = 0")

                MessageBoxEx.Show(Me, "Este producto ya está siendo inventariado en la lista actual" & vbCrLf & vbCrLf &
                                  "El producto no será incorporado en la lista",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Return False
            End If

        End If

        If Not _Ajuste_PM Then

            RevisarPr = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TmpInv_InvParcial",
                                        "Empresa = '" & _Empresa & "' and " &
                                        "Sucursal = '" & _Sucursal & "'and " &
                                        "Bodega = '" & _Bodega & "' and " &
                                        "CodigoPr = '" & _Codigo & "' and " &
                                        "Levantado = 1 And DejaStockCero = 0")
            If RevisarPr > 0 Then

                Dim Fecha = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TmpInv_InvParcial",
                                               "FechaInv",
                                               "Empresa = '" & _Empresa & "' and " &
                                               "Sucursal = '" & _Sucursal & "'and " &
                                               "Bodega = '" & _Bodega & "' and " &
                                               "CodigoPr = '" & _Codigo & "' and " &
                                               "Levantado = 1" & vbCrLf &
                                               "ORDER BY FechaInv desc")
                _Fecha_Antes = CDate(Fecha)

                MessageBoxEx.Show(Me, "Este producto ya fue inventariado" & vbCrLf &
                             "Inventariado el día: " & FormatDateTime(_Fecha_Antes, DateFormat.LongDate), "Validación",
                             MessageBoxButtons.OK, MessageBoxIcon.Warning)

                If Fx_Tiene_Permiso(Me, "In0019") Then
                    _Inventariado_Antes = True
                Else
                    Return False
                End If

            End If

        End If

        Dim OpcCosto As String

        'If _Ajuste_PM Then
        OpcCosto = "PM#"
        'Else
        'OpcCosto = _Sql.Fx_Trae_Dato(, cn1, "OpcionCosto", _Global_BaseBk & "Zw_TmpInv_InvParcialConf")
        'End If

        Dim _ListaCosto As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TmpInv_InvParcialConf", "ListaDeCostos")

        Dim _Costo As Double

        Select Case OpcCosto
            Case "LT#"
                _Costo = _Sql.Fx_Trae_Dato("TABPRE", "PP01UD", "KOLT = '" & _ListaCosto & "' AND KOPR = '" & _Codigo & "'", True)
            Case "PM#"
                _Costo = _Sql.Fx_Trae_Dato("MAEPREM", "PM", "EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'", True)

                If _Costo = 0 Then
                    MessageBoxEx.Show(Me, "El PM del producto el 0 (cero) se traerá el costo de la ultima compra", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Costo = _Sql.Fx_Trae_Dato("MAEPREM", "PPUL01", "EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'", True)
                End If

            Case "UC#"
                _Costo = _Sql.Fx_Trae_Dato("MAEPREM", "PPUL01", "EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'", True)
        End Select


        With _Fila

            .Cells("Empresa").Value = _Empresa
            .Cells("Sucursal").Value = _Sucursal
            .Cells("Bodega").Value = _Bodega
            .Cells("CodigoPr").Value = _Codigo
            .Cells("Descripcion").Value = _Descripcion
            .Cells("CodBarras").Value = _CodAlternativo
            .Cells("Rtu").Value = _Rtu

            If _Ajuste_PM Then
                .Cells("CantidadUd1").Value = _StockUd1
                .Cells("CantidadUd2").Value = _StockUd2
            Else
                .Cells("CantidadUd1").Value = 0
                .Cells("CantidadUd2").Value = 0
            End If

            .Cells("CostoUnitUd1").Value = _Costo
            .Cells("TotalCostoUd1").Value = 0
            .Cells("StockActual").Value = _StockUd1
            .Cells("Inventariado_Antes").Value = _Inventariado_Antes
            .Cells("Fecha_Antes").Value = _Fecha_Antes
            .Cells("Oculto").Value = "OCU"
            .Cells("Nuevo_Producto").Value = False
            .Cells("Horagrab").Value = FechaDelServidor()

        End With

        Consulta_sql = "UPDATE MAEPR SET ATPR = 'OCU' WHERE KOPR = '" & _Codigo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Sb_Marcar_Grilla(Grilla)

        If _Ajuste_PM Then
            Grilla.CurrentCell = Grilla.Rows(_Fila.Index).Cells("CostoUnitUd1")
        Else
            Grilla.CurrentCell = Grilla.Rows(_Fila.Index).Cells("CantidadUd1")
        End If

        Return True
    End Function

    Function Fx_Buscar_Producto(_Codigo As String) As DataRow

        _Codigo = Trim(_Codigo)
        Dim _RowProducto As DataRow

        If Not String.IsNullOrEmpty(_Codigo) Then

            Dim _CodigoAlt As String

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)


            If Not (_RowProducto Is Nothing) Then
                Return _RowProducto
            Else

                Dim _RowTabcodal As DataRow

                _CodigoAlt = _Codigo

                Consulta_sql = "Select top 1 * From TABCODAL Where KOEN = '' And KOPRAL = '" & _CodigoAlt & "'"
                _RowTabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_RowTabcodal Is Nothing) Then

                    _Codigo = _RowTabcodal.Item("KOPR")
                    Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
                    _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Return _RowProducto

                End If

            End If

            Dim _CodEnTacodal = _Sql.Fx_Trae_Dato("TABCODAL", "KOPR", "KOPRAL = '" & _Codigo & "' And KOEN = ''")

        End If


        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        With Fm
            .Pro_Actualizar_Precios = False
            .Pro_Mostrar_Info = False
            .BtnBuscarAlternativos.Visible = True
            .Pro_Mostrar_Imagenes = True
            .BtnCrearProductos.Visible = True
            .Pro_Mostrar_Editar = True
            .Pro_Mostrar_Eliminar = True
            .BtnExportaExcel.Visible = True
            .Pro_Tipo_Lista = "C"
            .Pro_Maestro_Productos = False
            .Pro_Sucursal_Busqueda = ModSucursal
            .Pro_Bodega_Busqueda = ModBodega
            .Pro_Lista_Busqueda = ModListaPrecioVenta
            '.CambiarCodigoToolStripMenuItem.Visible = True
            .Txtdescripcion.Text = _Codigo
            .Pro_Mostrar_Info = True
            .ShowDialog(Me)

            If Not .Pro_Seleccionado Then
                Return Nothing
            End If
            '_RowProducto = ._Tbl_Producto_Seleccionado.Rows(0)
            _RowProducto = .Pro_RowProducto
            .Dispose()
        End With


        Return _RowProducto

    End Function

#End Region

#Region "GRABAR DATOS"
    Sub Grabar_datos()

        With Grilla
            For Each row As DataGridViewRow In .Rows

                Dim _Codigo As String = row.Cells("CodigoPr").Value
                Dim _CodBarras As String = row.Cells("CodigoPr").Value
                Dim _Descripcion As String = row.Cells("CodigoPr").Value
                Dim _Rtu As String = row.Cells("CodigoPr").Value
                Dim _CantidadUd1 As String = row.Cells("CodigoPr").Value
                Dim _CantidadUd2 As String = row.Cells("CodigoPr").Value
                Dim _CostoUnitUd1 As String = row.Cells("CodigoPr").Value
                Dim _CostoUnitUd2 As String = row.Cells("CodigoPr").Value
                Dim _TotalCostoUd1 As String = row.Cells("CodigoPr").Value
                Dim _TotalCostoUd2 As String = row.Cells("CodigoPr").Value
                Dim _StockActual As String = row.Cells("CodigoPr").Value
                Dim _FechaInv As String = row.Cells("CodigoPr").Value
                Dim _ConsolidStockUd1 As String = row.Cells("CodigoPr").Value
                Dim _ConsolidStockUd2 As String = row.Cells("CodigoPr").Value

                ',HoraInv,)"
                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TmpInv_InvParcial (Empresa,Sucursal,Bodega,CodigoPr," &
                                "CodBarras,Descripcion,Rtu,CantidadUd1,CantidadUd2," &
                                "CostoUnitUd1,CostoUnitUd2," &
                                "CostoUnitUd1,CostoUnitUd2,TotalCostoUd1,TotalCostoUd2,StockActual," &
                                "FechaInv) Values " & vbCrLf &
                                "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega &
                                "','" & _Codigo & "','" & _CodBarras & "','" & _Descripcion &
                                "'," & _Rtu & "," & _CantidadUd1 & "," & _CantidadUd2 &
                                "," & _CostoUnitUd1 & "," & _CostoUnitUd2 & ",0,0,0,0,0,'')"


            Next
        End With
    End Sub
#End Region

#Region "PROCESAR"

    Sub Sb_Procesar()

        Dim _TblProductos As DataTable = Ds_Invent.Tables("Inv_InvParcial")

        Dim _Nuevo_Producto As Boolean = Grilla.Rows(Grilla.Rows.Count - 1).Cells("Nuevo_Producto").Value

        If _Nuevo_Producto And Grilla.Rows.Count = 1 Then
            MessageBoxEx.Show(Me, "No hay productos que procesar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Nuevo_Producto Then
            Eliminar_Fila(Grilla.Rows.Count - 1, False)
        End If

        If Grilla.RowCount > 0 Then

            If _Ajuste_PM Then

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", "Codigo", False, False, "'")

                Dim _Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                _Fm.ShowDialog(Me)
                _Fm.Dispose()

                Dim _TblNewDetalle As DataTable = Fx_Crear_Detalle_para_PM(_TblProductos)

                _TblProductos = _TblNewDetalle
            End If

            If CBool(_TblProductos.Rows.Count) Then

                Dim Fm As New Frm_InvParc_06_ProcesarDatos(_Row_InvParcial_Inventarios,
                                                           _TblProductos,
                                                           DtFechaInv.Value,
                                                           _Ajuste_PM,
                                                           Chk_Dejar_Doc_Final_Del_Dia.Checked)
                Fm.ChkDejaStockCero.Checked = False
                Fm.ShowDialog(Me)

                If Fm.Pro_Datos_Procesados Then
                    Dim Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")
                    'Crear_Tabla_Paso(Fecha)
                    Sb_Cargar_Grilla_Inv_Parcial(Fecha)
                    Sb_Cargar_Grilla_Inv_Parcial_Levantados(Fecha)
                End If
            Else
                MessageBoxEx.Show(Me, "Producto sin stock o stock negativo" & vbCrLf &
                                     "No se puede ajustar PM", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

    Sub Sb_Procesar_Ajuste()

        Dim _TblProductos As DataTable = Ds_Invent.Tables("Inv_InvParcial")

        Dim _CostoPMCero = _TblProductos.Compute("Count(CantidadUd1)", "CostoUnitUd1 <= 0 And Nuevo_Producto = 0")

        If CBool(_CostoPMCero) Then

            MessageBoxEx.Show(Me, "No pueden haber productos con costo <= 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Nuevo_Producto As Boolean = Grilla.Rows(Grilla.Rows.Count - 1).Cells("Nuevo_Producto").Value

        If _Nuevo_Producto And Grilla.Rows.Count = 1 Then
            MessageBoxEx.Show(Me, "No hay productos que procesar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Nuevo_Producto Then
            Eliminar_Fila(Grilla.Rows.Count - 1, False)
        End If

        If Grilla.RowCount > 0 Then

            If _Ajuste_PM Then

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", "Codigo", False, False, "'")

                Dim _Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                _Fm.ShowDialog(Me)
                _Fm.Dispose()

                Dim _TblNewDetalle As DataTable = Fx_Crear_Detalle_para_PM(_TblProductos)

                _TblProductos = _TblNewDetalle

            End If

            If CBool(_TblProductos.Rows.Count) Then

                Dim Fm As New Frm_Crear_Guias_De_Ajuste_De_Stock(_Row_InvParcial_Inventarios,
                                                           _TblProductos,
                                                           DtFechaInv.Value,
                                                           _Ajuste_PM,
                                                           Chk_Dejar_Doc_Final_Del_Dia.Checked)
                Fm.ChkDejaStockCero.Checked = False
                Fm.ShowDialog(Me)

                If Fm.Pro_Datos_Procesados Then
                    Dim Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")
                    Sb_Cargar_Grilla_Inv_Parcial(Fecha)
                    Sb_Cargar_Grilla_Inv_Parcial_Levantados(Fecha)
                End If

            Else

                MessageBoxEx.Show(Me, "Producto sin stock o stock negativo" & vbCrLf &
                                     "No se puede ajustar PM", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)


            End If

        End If

    End Sub

#Region "CREAR DETALLE SEGUN PM"

    Function Fx_Crear_Detalle_para_PM(_TblProductos As DataTable) As DataTable

        Dim _Ds As New Ds_Invent_parcial
        For Each _Fila As DataRow In _TblProductos.Rows


            Consulta_sql = "Select * From MAEST" & vbCrLf &
                           "Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Fila.Item("CodigoPr") & "' And STFI1 > 0"
            Dim _TblBodegas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            For Each _Flb As DataRow In _TblBodegas.Rows

                Dim NewFila As DataRow
                NewFila = _Ds.Tables("Inv_InvParcial").NewRow

                Dim _Empresa As String = _Flb.Item("EMPRESA")
                Dim _Sucursal As String = _Flb.Item("KOSU")
                Dim _Bodega As String = _Flb.Item("KOBO")
                Dim _CantidadUd1 = _Flb.Item("STFI1")
                Dim _CantidadUd2 = _Flb.Item("STFI2")

                With NewFila

                    .Item("Empresa") = _Empresa
                    .Item("Sucursal") = _Sucursal
                    .Item("Bodega") = _Bodega
                    .Item("CodigoPr") = _Fila.Item("CodigoPr")
                    .Item("Descripcion") = _Fila.Item("Descripcion")

                    .Item("CodBarras") = _Fila.Item("CodBarras")
                    .Item("Rtu") = _Fila.Item("Rtu")

                    .Item("CantidadUd1") = _CantidadUd1
                    .Item("CantidadUd2") = _CantidadUd2

                    .Item("CostoUnitUd1") = _Fila.Item("CostoUnitUd1")
                    .Item("TotalCostoUd1") = 0
                    .Item("StockActual") = _CantidadUd1
                    .Item("Inventariado_Antes") = _Fila.Item("Inventariado_Antes")
                    .Item("Fecha_Antes") = _Fila.Item("Fecha_Antes")
                    .Item("Oculto") = "OCU"


                End With
                _Ds.Tables("Inv_InvParcial").Rows.Add(NewFila)
            Next

        Next

        Return _Ds.Tables("Inv_InvParcial")

    End Function

#End Region

#End Region

#Region "ELIMINAR FILA"
    Sub Eliminar_Fila(_Nro_Fila As Integer, _Preguntar As Boolean)

        'Sb_Nueva_Fila()

        Dim _Fila As DataGridViewRow = Grilla.Rows(_Nro_Fila)

        Dim _Codigo As String = _Fila.Cells("CodigoPr").Value
        Dim _Nuevo_Producto = _Fila.Cells("Nuevo_Producto").Value

        If Grilla.Rows.Count = 1 Then
            If String.IsNullOrEmpty(_Codigo) Then
                Beep()
                Return
            End If
        End If

        If _Preguntar Then

            If _Nuevo_Producto Then
                Grilla.Rows.RemoveAt(_Nro_Fila)
                Beep()
                Return
            End If

            Dim dlg As System.Windows.Forms.DialogResult =
                          MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                           "Eliminar fila", MessageBoxButtons.YesNo)

            With Grilla
                If dlg = System.Windows.Forms.DialogResult.Yes Then

                    _Codigo = .Rows(_Nro_Fila).Cells("CodigoPr").Value

                    Consulta_sql = "Update MAEPR Set ATPR = '' Where KOPR = '" & _Codigo & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    .Rows.RemoveAt(_Nro_Fila)
                    'Bar_Menu_Producto.Enabled = False

                    If Not CBool(Grilla.Rows.Count) Then
                        Sb_Nueva_Fila()
                    Else
                        If _Ajuste_PM Then
                            Grilla.CurrentCell = Grilla.Rows(Grilla.CurrentRow.Index).Cells("CostoUnitUd1")
                        Else
                            Grilla.CurrentCell = Grilla.Rows(Grilla.CurrentRow.Index).Cells("CantidadUd1")
                        End If
                    End If


                End If
            End With
        Else
            Grilla.Rows.RemoveAt(_Nro_Fila)
        End If

    End Sub
#End Region

#End Region





    Private Sub Frm_Mt_InvParc_02_Seleccion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Dim tecla = e.KeyCode

            If e.KeyValue = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyValue = Keys.Down Then 'Or e.KeyValue = Keys.Up Then

                If Super_Tab.SelectedTabIndex = 0 Then 'Paginas.SelectedPage.Name = Pagina_1.Name Then
                    With Grilla

                        Dim Columna As Integer = .CurrentCellAddress.X
                        Dim Fila As Integer = .CurrentCellAddress.Y

                        Dim Filas As Integer = .Rows.Count - 1

                        If Filas = Fila Then '.CurrentRow.Index Then

                            Dim _Codigo = Grilla.Rows(Fila).Cells("CodigoPr").Value
                            If Not String.IsNullOrEmpty(_Codigo) Then
                                Sb_Nueva_Fila()
                                .CurrentCell = .Rows(Fila).Cells("CodigoPr") '.Rows(.CurrentRow.Index).Cells("Codigo")
                            End If
                            'Return
                            'If Agregar_Nuevo_Producto_() Then
                            'If Not _Ajuste_PM Then .CurrentCell = .Rows(Fila + 1).Cells("CantidadUd1") '.Rows(.CurrentRow.Index).Cells("Codigo")
                            '.BeginEdit(True)
                            'End If
                        End If
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        Dim tecla = e.KeyCode
        If Grilla.RowCount = 0 Then Return

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Nuevo_Producto = _Fila.Cells("Nuevo_Producto").Value

            If e.KeyValue = Keys.Enter Then

                Dim _Editar As Boolean


                Select Case _Cabeza
                    Case "CodigoPr"
                        If _Nuevo_Producto Then

                            If _Autorizado_Ajustar Then
                                _Editar = True
                            Else
                                _Editar = Fx_Tiene_Permiso(Me, "In0018")
                                _Autorizado_Ajustar = _Editar
                            End If

                        End If
                    Case "CantidadUd1", "CostoUnitUd1"
                        If Not _Nuevo_Producto Then
                            _Editar = True
                        End If
                End Select

                If _Editar Then

                    Grilla.Columns(_Cabeza).ReadOnly = False
                    Grilla.BeginEdit(True)

                    e.SuppressKeyPress = False
                    e.Handled = True

                End If

            ElseIf e.KeyValue = Keys.Delete Then 'Keys.Up Then

                e.Handled = True
                Eliminar_Fila(Grilla.CurrentRow.Index, True)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo = NuloPorNro(_Fila.Cells("CodigoPr").Value, "")

        If _Cabeza = "CodigoPr" Then

            Dim _RowProducto As DataRow = Fx_Buscar_Producto(_Codigo)

            If Not (_RowProducto Is Nothing) Then
                If Not Fx_Agregar_Nuevo_Producto_(_RowProducto, _Fila) Then
                    _Fila.Cells("CodigoPr").Value = String.Empty
                End If
            Else
                _Fila.Cells("CodigoPr").Value = String.Empty
            End If

        ElseIf _Cabeza = "CantidadUd1" Then

            Dim Cant1, Cant2, CostoUd1, CostoUd2, TotalUd1, TotalUd2, Rtu As Double
            With Grilla
                Rtu = .Rows.Item(e.RowIndex).Cells("Rtu").Value
                Cant1 = .Rows.Item(e.RowIndex).Cells("CantidadUd1").Value
                Cant2 = Math.Round(Cant1 / Rtu, 5)

                CostoUd1 = NuloPorNro(.Rows.Item(e.RowIndex).Cells("CostoUnitUd1").Value, 0)
                CostoUd2 = NuloPorNro(.Rows.Item(e.RowIndex).Cells("CostoUnitUd2").Value, 0)

                TotalUd1 = CostoUd1 * Cant1
                TotalUd2 = CostoUd2 * Cant2

                .Rows.Item(e.RowIndex).Cells("CantidadUd2").Value = Cant2

                .Rows.Item(e.RowIndex).Cells("TotalCostoUd1").Value = TotalUd1

            End With

        End If

        Grilla.Columns(_Cabeza).ReadOnly = True

    End Sub

    Private Sub Grilla_Leave(sender As System.Object, e As System.EventArgs)
        Lbl_Nombre_Producto_Linea_Activa_Grilla.Text = String.Empty
    End Sub

    Private Sub Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try
            Lbl_Nombre_Producto_Linea_Activa_Grilla.Text = Space(1) & Fx_Producto_Grilla_Activa.Item("NOKOPR")
        Catch ex As Exception
            Lbl_Nombre_Producto_Linea_Activa_Grilla.Text = String.Empty
        End Try

    End Sub


    Private Sub OcultaDesocultarProductosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("CodigoPr").Value
        Dim Fm As New Frm_OcultarPr
        Fm.TxtCodigo.Text = Trim(Codigo)
        Fm.MostrarPR()
        Fm.ShowDialog(Me)
        Codigo_abuscar = String.Empty
    End Sub

    Private Sub BtnMaestroProductos_Click(sender As System.Object, e As System.EventArgs) Handles BtnMaestroProductos.Click

        If Fx_Tiene_Permiso(Me, "Prod012") Then

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt()

            With Fm
                .Pro_Actualizar_Precios = False
                .Pro_Mostrar_Info = False
                .BtnBuscarAlternativos.Visible = True
                .BtnCrearProductos.Visible = True
                '.BtnEditarProducto.Visible = True
                '.BtnEliminarProducto.Visible = True
                .BtnExportaExcel.Visible = True
                .Pro_Tipo_Lista = "P"
                .ShowDialog(Me)
            End With

        End If

    End Sub


    Private Sub Btn_Mnu_Pr_Codigo_Alternativo_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Sub Sb_Codigos_Alternativos(_Codigo As String)

        ' Dim Nro As Integer = 32
        If Fx_Tiene_Permiso(Me, "Prod020") Then

            Dim _Descripcion As String = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & _Codigo & "'")
            Dim _Rtu As String = _Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & _Codigo & "'")

            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _Codigo
            Fm.Txtdescripcion.Text = _Descripcion
            Fm.TxtRTU.Text = _Rtu
            Fm.ShowDialog(Me)

            Dim _CodBarra As String = _Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL",
                                               "KOPR = '" & _Codigo & "' AND KOEN = ''")

            Dim _Pagina = Super_Tab.SelectedTabIndex 'Paginas.SelectedPage.Name

            If Super_Tab.SelectedTabIndex = 0 Then 'If _Pagina = Pagina_1.Name Then
                Grilla.Rows(Grilla.CurrentRow.Index).Cells("CodBarras").Value = _CodBarra
            Else
                Grilla_Levantados.Rows(Grilla_Levantados.CurrentRow.Index).Cells("CodBarras").Value = _CodBarra
            End If

        End If

    End Sub


    Sub Sb_Editar_Descripcion_Del_Producto()

        If Fx_Tiene_Permiso(Me, "Prod014") Then

            Dim _RowProducto = Fx_Producto_Grilla_Activa()

            Dim _Codigo = _RowProducto.Item("KOPR")
            Dim _Descripcion = _RowProducto.Item("NOKOPR")
            Dim _Aceptado As Boolean

            _Aceptado = InputBox_Bk(Me, "Ingrese nueva descripción", "Cambiar descripción", _Descripcion, False,
                                            _Tipo_Mayus_Minus.Normal, 50, True, _Tipo_Imagen.Texto, False)

            If _Aceptado Then

                Consulta_sql = "UPDATE MAEPR SET NOKOPR = '" & _Descripcion & "' WHERE KOPR = '" & _Codigo & "'" & vbCrLf &
                               "UPDATE " & _Global_BaseBk & "Zw_TmpInv_InvParcial SET  Descripcion = '" & _Descripcion & "'" & vbCrLf &
                               "WHERE CodigoPr = '" & _Codigo & "'"

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    Dim _Pagina = Super_Tab.SelectedTabIndex ' Paginas.SelectedPage.Name

                    If _Pagina = 0 Then
                        Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value = _Descripcion
                    Else
                        Grilla_Levantados.Rows(Grilla_Levantados.CurrentRow.Index).Cells("Descripcion").Value = _Descripcion
                    End If

                    ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button, 2 * 1000,
                                           eToastGlowColor.Blue, eToastPosition.MiddleCenter)

                End If
            End If
        End If

    End Sub

    Function Fx_Producto_Grilla_Activa() As DataRow
        Dim _Codigo As String

        Dim _Pagina = Super_Tab.SelectedTabIndex ' Paginas.SelectedPage.Name

        If _Pagina = 0 Then 'If _Pagina = Pagina_1.Name Then
            _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("CodigoPr").Value
        Else
            _Codigo = Grilla_Levantados.Rows(Grilla_Levantados.CurrentRow.Index).Cells("CodigoPr").Value
        End If

        Consulta_sql = "Select top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"

        Dim _TblProducto As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblProducto.Rows.Count) Then
            Return _TblProducto.Rows(0)
        Else
            Return Nothing
        End If

    End Function



    Private Sub Btn_Mnu_Pr_Estadistica_Producto_Click(sender As System.Object, e As System.EventArgs)
        _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Btn_Mnu_Pr_Codigo_De_Reemplazo_Click(sender As System.Object, e As System.EventArgs)
        _Producto_Op.Sb_Ver_Codigos_de_reemplazo(Me, Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Btn_Mnu_Pr_Ver_Clasificacion_Producto_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Btn_Mnu_Pr_Mantencion_Clasificacion_Producto_Click(sender As System.Object, e As System.EventArgs)
        _Producto_Op.Sb_Mantencion_Clasificacion_Codigos(Me, Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Btn_Mnu_Pr_Kardex_Inventario_Click(sender As System.Object, e As System.EventArgs)
        _Producto_Op.Sb_Ver_Kardex_Inventario(Me, Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Btn_Mnu_Pr_Ubicacion_Producto_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub Grilla_Levantados_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Levantados.CellEnter

        Try
            Lbl_Nombre_Producto_Linea_Activa_Grilla.Text = Space(1) & Fx_Producto_Grilla_Activa.Item("NOKOPR")
        Catch ex As Exception
            Lbl_Nombre_Producto_Linea_Activa_Grilla.Text = String.Empty
        End Try

    End Sub


    Private Sub Btn_Consolidar_Stock_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Consolidar_Stock.Click

        Dim _Index_Tab = Super_Tab.SelectedTabIndex

        If _Index_Tab = 0 Then 'Paginas.SelectedPage.Name = Pagina_1.Name Then

            Dim _TblProductos As DataTable = Ds_Invent.Tables("Inv_InvParcial")

            Dim _Nuevo_Producto As Boolean = Grilla.Rows(Grilla.Rows.Count - 1).Cells("Nuevo_Producto").Value

            If _Nuevo_Producto And Grilla.Rows.Count = 1 Then
                MessageBoxEx.Show(Me, "No hay productos que procesar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", "CodigoPr", False, False, "'")

            Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            Dim Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")

            Consulta_sql = "Select CodigoPr, Descripcion" & vbCrLf &
                           "FROM " & _Global_BaseBk & "Zw_TmpInv_InvParcial" & vbCrLf &
                           "Where FechaInv = '" & Fecha & "'" & vbCrLf &
                           "And Levantado = 1" & vbCrLf &
                           "And DejaStockCero = 0" &
                           "Order by Semilla DESC"

            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl_Productos.Rows.Count) Then

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "CodigoPr", False, False, "'")

                Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                Fm.ShowDialog(Me)
                Fm.Dispose()

                If _Index_Tab = 0 Then 'Paginas.SelectedPage.Name = Pagina_2.Name Then
                    Sb_Cargar_Grilla_Inv_Parcial_Levantados(DtFechaInv.Value)
                End If
            Else
                MessageBoxEx.Show(Me, "No hay productos que procesar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
    End Sub

    Private Sub DtFechaInv_ValueChanged(sender As System.Object, e As System.EventArgs)
        Sb_Actualizar_Formulario()
    End Sub

    Private Sub BtnProcesar_Click(sender As System.Object, e As System.EventArgs) Handles BtnProcesar.Click
        'Sb_Procesar()
        Sb_Procesar_Ajuste()
    End Sub

    Private Sub Btn_Mnu_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Estadisticas_Producto.Click
        _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    'Dim _Grilla As Object = CType(sender, DataGridView) 'CType(sender, DevComponents.DotNetBar.Controls.DataGridViewX)

                    Dim _Fila As DataGridViewRow = CType(sender, DataGridView).Rows(CType(sender, DataGridView).CurrentRow.Index)
                    Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

                    Dim _Index_Tab = Super_Tab.SelectedTabIndex
                    Dim _Nuevo_Producto As Boolean

                    If _Index_Tab = 0 Then
                        _Nuevo_Producto = CType(sender, DataGridView).Rows _
                                         (CType(sender, DataGridView).CurrentRow.Index).Cells("Nuevo_Producto").Value

                        If Not _Nuevo_Producto Then

                            Dim _RowPr As DataRow = Fx_Producto_Grilla_Activa()

                            If Not (_RowPr Is Nothing) Then
                                Dim _Oculto As String = _RowPr.Item("ATPR")

                                If _Oculto = "OCU" Then
                                    Btn_Mnu_Ocultar_Desocultar.Text = "Desocultar Producto"
                                Else
                                    Btn_Mnu_Ocultar_Desocultar.Text = "Ocultar Producto"
                                End If

                                Btn_Mnu_Ocultar_Desocultar.Enabled = True
                                Btn_Mnu_Quitar_Producto_De_La_Lista.Enabled = True
                                ShowContextMenu(Menu_Contextual_Productos)
                            Else
                                Beep()
                                ToastNotification.Show(Me, "PRODCUTO NO EXISTE", My.Resources.cross,
                                          1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                            End If

                        End If
                    Else

                        If _Cabeza = "Nro_GDI_Stock_Cero" Or _Cabeza = "Nro_GRI_Stock_Cero" Or _Cabeza = "Nro_GRI_Ajuste_Stock" Then

                            Dim _GDI_Idmaeedo_Aj = sender.Rows(sender.CurrentRow.Index).Cells("GDI_Idmaeedo_Aj").Value
                            Dim _Nro_GDI_Stock_Cero = sender.Rows(sender.CurrentRow.Index).Cells("Nro_GDI_Stock_Cero").Value
                            Dim _GRI_Idmaeedo_Aj = sender.Rows(sender.CurrentRow.Index).Cells("GRI_Idmaeedo_Aj").Value
                            Dim _Nro_GRI_Stock_Cero = sender.Rows(sender.CurrentRow.Index).Cells("Nro_GRI_Stock_Cero").Value
                            Dim _IDMAEEDO_Aj = sender.Rows(sender.CurrentRow.Index).Cells("IDMAEEDO_Aj").Value
                            Dim _Nro_GRI_Ajuste_Stock = sender.Rows(sender.CurrentRow.Index).Cells("Nro_GRI_Ajuste_Stock").Value

                            Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero.Enabled = CBool(_GDI_Idmaeedo_Aj)
                            Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero.Enabled = CBool(_GRI_Idmaeedo_Aj)
                            Btn_Mnu_Ver_GRI_Definitiva_Ajuste.Enabled = CBool(_IDMAEEDO_Aj)

                            Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero.Text = "Ver GDI deja stock en cero (" & _Nro_GDI_Stock_Cero & ")"
                            Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero.Text = "Ver GRI deja stock en cero (" & _Nro_GRI_Stock_Cero & ")"
                            Btn_Mnu_Ver_GRI_Definitiva_Ajuste.Text = "Ver GRI de ajuste de Stock (" & _Nro_GRI_Ajuste_Stock & ")"

                            ShowContextMenu(Menu_Contextual_Guias_Ajuste)
                        Else
                            Btn_Mnu_Ocultar_Desocultar.Enabled = False
                            Btn_Mnu_Quitar_Producto_De_La_Lista.Enabled = False
                            ShowContextMenu(Menu_Contextual_Productos)
                        End If

                    End If

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero.Click

        Dim _Fila As DataGridViewRow = Grilla_Levantados.Rows(Grilla_Levantados.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("GDI_Idmaeedo_Aj").Value
        Dim _Tido_Nudo = _Fila.Cells("Nro_GDI_Stock_Cero").Value
        Dim _Nulo = _Fila.Cells("GDI_Cero_Nula").Value
        Dim _Codigo = _Fila.Cells("CodigoPr").Value

        Sb_Ver_Documento(_Idmaeedo, _Nulo, _Tido_Nudo, _Codigo)

    End Sub

    Private Sub Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero.Click

        Dim _Fila As DataGridViewRow = Grilla_Levantados.Rows(Grilla_Levantados.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("GRI_Idmaeedo_Aj").Value
        Dim _Tido_Nudo = _Fila.Cells("Nro_GRI_Stock_Cero").Value
        Dim _Nulo = _Fila.Cells("GRI_Cero_Nula").Value
        Dim _Codigo = _Fila.Cells("CodigoPr").Value

        Sb_Ver_Documento(_Idmaeedo, _Nulo, _Tido_Nudo, _Codigo)

    End Sub

    Private Sub Btn_Mnu_Ver_GRI_Definitiva_Ajuste_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ver_GRI_Definitiva_Ajuste.Click

        Dim _Fila As DataGridViewRow = Grilla_Levantados.Rows(Grilla_Levantados.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO_Aj").Value
        Dim _Tido_Nudo = _Fila.Cells("Nro_GRI_Ajuste_Stock").Value
        Dim _Nulo = _Fila.Cells("GRI_Ajuste_Nula").Value
        Dim _Codigo = _Fila.Cells("CodigoPr").Value

        Sb_Ver_Documento(_Idmaeedo, _Nulo, _Tido_Nudo, _Codigo)

    End Sub

    Sub Sb_Ver_Documento(_Idmaeedo As Integer,
                         _Nulo As Boolean,
                         _Tido_Nudo As String,
                         _Codigo_Marcar As String)

        Dim _TdNdo = Split(_Tido_Nudo, "-", 2)
        Dim _Tido, _Nudo As String

        Try
            If _Nulo Then

                _Tido = _TdNdo(0)
                _Nudo = _TdNdo(1)

                _Idmaeedo = _Sql.Fx_Trae_Dato("MAEEDO",
                                              "IDMAEEDO",
                                              "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'")

                MessageBoxEx.Show(Me,
                                    "El documento " & _Nudo & " No fue encontrado, puede haber sido anulado o eliminado",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

        Catch ex As Exception
            _Idmaeedo = 0
        End Try

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Codigo_Marcar = _Codigo_Marcar
        If Fm.Pro_Existe_Documento Then
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "Documento no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Quitar_Producto_De_La_Lista_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Quitar_Producto_De_La_Lista.Click
        Eliminar_Fila(Grilla.CurrentRow.Index, True)
    End Sub

    Private Sub Btn_Mnu_Ocultar_Desocultar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ocultar_Desocultar.Click

        Dim _RowPr As DataRow = Fx_Producto_Grilla_Activa()

        Dim _Oculto As String = _RowPr.Item("ATPR")
        Dim _Accion As Integer

        If _Oculto = "OCU" Then
            _Accion = _Producto_Op._Ocu.Desocultar
            Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value = ""
        Else
            _Accion = _Producto_Op._Ocu.Ocultar
            Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value = "OCU"
        End If

        _Producto_Op.Fx_Ocultar_Desocultar_Producto(Me, _RowPr.Item("KOPR"), _Accion)

    End Sub

    Private Sub Btn_Mnu_Arbol_Clasificaciones_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Arbol_Clasificaciones.Click
        _Producto_Op.Sb_Ver_Clasificaciones_del_producto(Me, Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Btn_Mnu_Codigo_Alternativo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Codigo_Alternativo.Click
        Sb_Codigos_Alternativos(Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Btn_Mnu_Kardex_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Kardex.Click
        _Producto_Op.Sb_Ver_Kardex_Inventario(Me, Fx_Producto_Grilla_Activa.Item("KOPR"))
    End Sub

    Private Sub Btn_Mnu_Ubicaciones_Del_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ubicaciones_Del_Producto.Click
        _Producto_Op.Sb_Ver_Ubicacion_Bodega(Me, Fx_Producto_Grilla_Activa.Item("KOPR"), _Empresa, _Sucursal, _Bodega)
    End Sub

    Private Sub SuperTabItem1_Click(sender As System.Object, e As System.EventArgs) Handles SuperTabItem1.Click
        Grilla.Focus()
        Dim _Indice_fila = Grilla.Rows.Count - 1
        Grilla.CurrentCell = Grilla.Rows(_Indice_fila).Cells("CodigoPr")

        Lbl_Nombre_Producto_Linea_Activa_Grilla.Text = String.Empty
    End Sub

    Private Sub SuperTabItem2_Click(sender As System.Object, e As System.EventArgs) Handles SuperTabItem2.Click
        Lbl_Nombre_Producto_Linea_Activa_Grilla.Text = String.Empty
    End Sub


    Private Sub Grilla_Levantados_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Levantados.CellDoubleClick

        Try
            Me.Enabled = False

            Dim _Fila As DataGridViewRow = CType(sender, DataGridView).Rows(CType(sender, DataGridView).CurrentRow.Index)
            Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

            If _Cabeza = "Nro_GDI_Stock_Cero" Or _Cabeza = "Nro_GRI_Stock_Cero" Or _Cabeza = "Nro_GRI_Ajuste_Stock" Then

                Dim _GDI_Idmaeedo_Aj = CBool(_Fila.Cells("GDI_Idmaeedo_Aj").Value)
                Dim _GRI_Idmaeedo_Aj = CBool(_Fila.Cells("GRI_Idmaeedo_Aj").Value)
                Dim _IDMAEEDO_Aj = CBool(_Fila.Cells("IDMAEEDO_Aj").Value)

                Dim _GRI_Cero_Nula = CBool(_Fila.Cells("GRI_Cero_Nula").Value)
                Dim _GDI_Cero_Nula = CBool(_Fila.Cells("GDI_Cero_Nula").Value)
                Dim _GRI_Ajuste_Nula = CBool(_Fila.Cells("GRI_Ajuste_Nula").Value)

                Dim _Nro_Documento = _Fila.Cells(_Cabeza).Value
                ' Dim _Nulo As Boolean


                Select Case _Cabeza

                    Case "Nro_GDI_Stock_Cero"

                        If _GDI_Idmaeedo_Aj Then
                            Call Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero_Click(Nothing, Nothing)
                        End If

                    Case "Nro_GRI_Stock_Cero"

                        If _GRI_Idmaeedo_Aj Then
                            Call Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero_Click(Nothing, Nothing)
                        End If

                    Case "Nro_GRI_Ajuste_Stock"

                        If _IDMAEEDO_Aj Then
                            Call Btn_Mnu_Ver_GRI_Definitiva_Ajuste_Click(Nothing, Nothing)
                        End If

                End Select

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub


    Private Sub Btn_Importar_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Importar_Productos.Click

        'If Not _Autorizado_Ajustar Then
        '    _Autorizado_Ajustar = Fx_Tiene_Permiso(Me, "In0018")
        'End If

        'If _Autorizado_Ajustar Then

        Dim Fm As New Frm_Mt_InvParc_Importar(Ds_Invent, _Empresa, _Sucursal, _Bodega)
        Fm.ShowDialog(Me)

        If Fm.Pro_Archivo_Importado_correctamente Then

            Ds_Invent.Clear()
            Ds_Invent = Fm.Pro_Ds_Invent

            Grilla.DataSource = Ds_Invent '.Tables("DetalleDocumento")
            Grilla.DataMember = Ds_Invent.Tables("Inv_InvParcial").TableName

            Sb_Formato_Grilla(Grilla)
            Sb_Nueva_Fila()
            Grilla.Focus()

            Sb_Formato_Grilla(Grilla)
        End If
        Fm.Dispose()

        'End If

    End Sub

    Private Sub Btn_Imprimir_Codigos_de_Barra_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Codigos_de_Barra.Click

        Dim _Index_Tab = Super_Tab.SelectedTabIndex
        Dim _Tbl As DataTable

        If _Index_Tab = 0 Then
            _Tbl = Ds_Invent.Tables("Inv_InvParcial")
        Else
            _Tbl = _Tbl_Productos_Contados
        End If

        Dim _NoHayProductos As Boolean

        If _Tbl.Rows.Count = 0 Then
            _NoHayProductos = True
        Else
            If _Tbl.Rows.Count = 1 Then
                If String.IsNullOrWhiteSpace(_Tbl.Rows(0).Item("CodigoPr")) Then
                    _NoHayProductos = True
                End If
            End If
        End If

        If _NoHayProductos Then
            MessageBoxEx.Show(Me, "No hay productos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Fl As String = Generar_Filtro_IN(_Tbl, "", "CodigoPr", False, False, "'")

        Consulta_sql = "Select Cast(1 as Bit) As Chk,KOPR As Codigo,NOKOPR As Descripcion" & vbCrLf &
                       "From MAEPR Where KOPR In " & _Fl

        Dim _TblProductos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_ImpBarras_PorProducto
        Fm.Pro_Chk_Imprimir_Todas_Las_Ubicaciones = True
        Fm.Pro_Tbl_Filtro_Productos = _TblProductos
        Fm.Pro_Cantidad_Uno = True
        Fm.BtnBuscarProducto.Visible = False
        Fm.BtnLimpiar.Visible = False
        Fm.Grupo_Ubicaciones.Enabled = False
        Fm.Grupo_Lista_Precios.Enabled = False
        Fm.Btn_imprimir_Archivo.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    Private Sub Btn_Imprimir_Ubicacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Ubicacion.Click

        Dim _Grilla As Object

        Dim _Index_Tab = Super_Tab.SelectedTabIndex
        If _Index_Tab = 0 Then
            _Grilla = Grilla
        Else
            _Grilla = Grilla_Levantados
        End If

        Dim _Fila As DataGridViewRow = CType(_Grilla, DataGridView).Rows(CType(_Grilla, DataGridView).CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("CodigoPr").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value

        Consulta_sql = "Select Cast(1 as Bit) As Chk,'" & _Codigo & "' As Codigo,'" & _Descripcion & "' As Descripcion"
        Dim _TblProductos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_ImpBarras_PorProducto
        Fm.Pro_Chk_Imprimir_Todas_Las_Ubicaciones = True
        Fm.Pro_Tbl_Filtro_Productos = _TblProductos
        Fm.Pro_Cantidad_Uno = True
        Fm.BtnBuscarProducto.Visible = False
        Fm.BtnLimpiar.Visible = False
        Fm.Grupo_Ubicaciones.Enabled = False
        Fm.Grupo_Lista_Precios.Enabled = False
        Fm.Btn_imprimir_Archivo.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Super_Tab_SelectedTabChanged(sender As System.Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles Super_Tab.SelectedTabChanged
        Dim _Index As Integer = Super_Tab.SelectedTabIndex
        Dim _Informe As String

        Select Case _Index
            Case 0
                Sb_Marcar_Grilla(Grilla)
            Case 1
                Sb_Marcar_Grilla(Grilla_Levantados)
        End Select

    End Sub

    Private Sub Chk_Dejar_Doc_Final_Del_Dia_CheckedChanged(sender As System.Object, e As System.EventArgs)

        If Chk_Dejar_Doc_Final_Del_Dia.Checked Then

            If Not Fx_Tiene_Permiso(Me, "Invp0004") Then
                Chk_Dejar_Doc_Final_Del_Dia.Checked = False
            Else
                MessageBoxEx.Show(Me, "Esto dejara todos los documentos generados con hora 23:59:59." & vbCrLf &
                                 "Esto quiere decir que los ajustes se tomaran como si las guías fueron los últimos documentos del día" & vbCrLf &
                                 "Solo recomendado si el ajuste de stock es para inventario general.",
                                 "Observación importante", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub

    Function Fx_Saldo_Foto_Stock(_Row_Producto As DataRow) As DataRow

        Dim _Idmaeedo_Gri_Cero = _Row_Producto.Item("IDMAEEDO_Aj")
        Dim _Idmaeedo_Gri = _Row_Producto.Item("GDI_Idmaeedo_Aj")
        Dim _Idmaeedo_Gdi = _Row_Producto.Item("GRI_Idmaeedo_Aj")

        Dim _IdMenor As String

        If _Idmaeedo_Gri_Cero > 0 Then _IdMenor = "And MAEDDO.IDMAEEDO < " & _Idmaeedo_Gri_Cero & vbCrLf
        If _Idmaeedo_Gri > 0 Then _IdMenor += "And MAEDDO.IDMAEEDO < " & _Idmaeedo_Gri & vbCrLf
        If _Idmaeedo_Gdi > 0 Then _IdMenor += "And MAEDDO.IDMAEEDO < " & _Idmaeedo_Gdi & vbCrLf

        Dim _Codigo = _Row_Producto.Item("CodigoPr")

        Dim _Filtro, _Filtro_A, _Filtro_Bodega As String
        Dim _Filtro_Condicion_Extra As String


        Dim _Fecha_Informe = Format(DtFechaInv.Value, "yyyyMMdd")

        _Filtro_Condicion_Extra = "And MAEDDO.IDMAEEDO Not In (" & _Idmaeedo_Gri_Cero & "," & _Idmaeedo_Gri & "," & _Idmaeedo_Gdi & ")" & vbCrLf &
                                  "And MAEDDO.FEEMLI <= '" & _Fecha_Informe & "'" & vbCrLf & _IdMenor

        Consulta_sql = My.Resources._23_ConsultasSQL.Foto_StockXProducto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "--Filtro_Condicion_Extra", _Filtro_Condicion_Extra)


        Dim _TblKardex As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

        Return _TblKardex.Rows(0)



    End Function

    Private Sub Btn_Foto_Stock_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Foto_Stock.Click
        If Fx_Tiene_Permiso(Me, "In0031") Then
            Try
                Progreso_Porc.Maximum = 100
                Progreso_Cont.Maximum = _Tbl_Productos_Contados.Rows.Count
                Dim _Contador As Integer = 0

                Super_Tab.Enabled = False
                Chk_Dejar_Doc_Final_Del_Dia.Enabled = False
                Bar1.Enabled = False

                Progreso_Cont.Visible = True
                Progreso_Porc.Visible = True
                Lbl_Actualizar_Stock.Visible = True

                Me.Refresh()

                For Each _Fila As DataRow In _Tbl_Productos_Contados.Rows

                    System.Windows.Forms.Application.DoEvents()

                    Dim _Codigo = _Fila.Item("CodigoPr")
                    Dim _Semilla = _Fila.Item("Semilla")

                    If _Fila.Item("Foto_Stock_Ud1") = 0 Then

                        Dim _RowStfi As DataRow = Fx_Saldo_Foto_Stock(_Fila)

                        Dim _Foto_Stock_Ud1 As Double = _RowStfi.Item("STFISICOUD1")
                        Dim _Foto_Stock_Ud2 As Double = _RowStfi.Item("STFISICOUD2")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_InvParcial Set" & Space(1) &
                                       "Foto_Stock_Ud1 = " & De_Num_a_Tx_01(_Foto_Stock_Ud1, False, 5) &
                                       ",Foto_Stock_Ud2 = " & De_Num_a_Tx_01(_Foto_Stock_Ud2, False, 5) & vbCrLf &
                                       "Where Semilla = " & _Semilla

                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        _Fila.Item("Foto_Stock_Ud1") = _Foto_Stock_Ud1
                        _Fila.Item("Foto_Stock_Ud2") = _Foto_Stock_Ud2

                    End If

                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / _Tbl_Productos_Contados.Rows.Count) 'Mas
                    Progreso_Cont.Value += 1

                Next
            Catch ex As Exception
                MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Progreso_Porc.Maximum = 100
                Progreso_Cont.Maximum = _Tbl_Productos_Contados.Rows.Count

                Super_Tab.Enabled = True
                Chk_Dejar_Doc_Final_Del_Dia.Enabled = True
                Bar1.Enabled = True

                Progreso_Cont.Visible = False
                Progreso_Porc.Visible = False
                Lbl_Actualizar_Stock.Visible = False

                Me.Refresh()
            End Try
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        Dim _Index_Tab = Super_Tab.SelectedTabIndex


        If _Index_Tab = 0 Then 'Paginas.SelectedPage.Name = Pagina_1.Name Then

            Dim _Tbl As DataTable

            If _Tbl_Productos_A_Contar.Rows.Count = 1 Then
                If String.IsNullOrEmpty(_Tbl_Productos_A_Contar.Rows(0).Item("CodigoPr")) Then
                    _Tbl = Nothing
                Else
                    _Tbl = _Tbl_Productos_A_Contar
                End If
            Else
                _Tbl_Productos_Contados = Ds_Invent.Tables("Inv_InvParcial")
                _Tbl = _Tbl_Productos_Contados
            End If

            ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Prod_A_Levantar")
        Else
            ExportarTabla_JetExcel_Tabla(_Tbl_Productos_Contados, Me, "Prod_Contados")
        End If
    End Sub


End Class
