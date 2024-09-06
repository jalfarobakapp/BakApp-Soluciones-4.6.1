Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _Nombre_Excel As String
    Dim _Tbl_Informe As DataTable
    Dim _SqlFiltro As String
    Dim _SqlExcel As String
    Dim _Kofuen As String

    Dim _HitColumn As GridColumn

    Dim _Tbl_Excel As DataTable
    Dim _Tbl_Excel_Vista_Actual As DataTable

    Dim _Ds_Informe As DataSet
    Dim _Fecha_Desde As DateTime
    Dim _Fecha_Hasta As DateTime

    ' Formato de colores para las grillas

    Private _Background1 As New Background(Color.White, Color.FromArgb(238, 244, 251), 45)
    Private _Background2 As New Background(Color.FromArgb(249, 249, 234))
    Private _Background3 As New Background(Color.FromArgb(255, 247, 250))

    Private _Background1_Black As New Background(Color.Black)
    Private _Background2_Black As New Background(Color.Black)
    Private _Background3_Black As New Background(Color.Black)

    Dim _Grilla_Activa As String
    Dim _Panel_Activo As GridPanel

    Dim _Un_Solo_Cliente As Boolean

    Public ReadOnly Property Pro_Ds_Informe() As DataSet
        Get
            Return _Ds_Informe
        End Get
    End Property

    Public Property Fecha_Desde As Date
        Get
            Return _Fecha_Desde
        End Get
        Set(value As Date)
            _Fecha_Desde = value
        End Set
    End Property

    Public Property Fecha_Hasta As Date
        Get
            Return _Fecha_Hasta
        End Get
        Set(value As Date)
            _Fecha_Hasta = value
        End Set
    End Property

    Public Sub New(_Nombre_Tabla_Paso As String,
                   _SqlFiltro As String,
                   _Un_Solo_Cliente As Boolean,
                   _Kofuen As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Nombre_Tabla_Paso = _Nombre_Tabla_Paso
        Me._Un_Solo_Cliente = _Un_Solo_Cliente
        Me._SqlFiltro = _SqlFiltro
        Me._Kofuen = _Kofuen

        Sb_Initialize_Grid()
        Sb_Actualizar_Grilla()

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Sb_Initialize_Grid()

        Dim panel As GridPanel = Super_Grilla.PrimaryGrid

        panel.Name = "Informe"
        panel.ShowToolTips = True

        panel.MinRowHeight = 20
        panel.AutoGenerateColumns = True


        If Global_Thema = Enum_Themas.Oscuro Then
            panel.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1_Black
        Else
            panel.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1
        End If

        panel.SelectionGranularity = SelectionGranularity.Cell

        AddHandler Super_Grilla.CellValueChanged, AddressOf SuperGridControl1CellValueChanged
        AddHandler Super_Grilla.GetCellStyle, AddressOf SuperGridControl1GetCellStyle
        AddHandler Super_Grilla.DataBindingComplete, AddressOf SuperGridControl1DataBindingComplete

        'AddHandler Super_Grilla.MouseClick, AddressOf Sb_Super_Grilla_MouseClick
        AddHandler Super_Grilla.SelectionChanged, AddressOf SuperGridControl1SelectionChanged
    End Sub

    Sub Sb_Actualizar_Grilla()

        Me.Cursor = Cursors.WaitCursor

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtro_Abanzado.Text),
                                "ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR LIKE '%")

        If _Un_Solo_Cliente Then

            Consulta_sql = "Select IDMAEDDO Into #Paso From " & _Nombre_Tabla_Paso & " WHIT (NOLOCK)" & vbCrLf &
                           "Where 1 > 0" & vbCrLf &
                           _SqlFiltro & vbCrLf &
                           "And ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR Like '%" & _Cadena & "%'" &
                           vbCrLf &
                           vbCrLf &
                           "Select RTEN+KOFULIDO AS ID,RUT,ENDO,SUENDO,RAZON,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL," &
                           "SUM(VANELI) AS NETO,SUM(VAIVLI) AS IVA, SUM(VABRLI) AS TOTAL" & vbCrLf &
                           "Into #Paso_Entidad " & vbCrLf &
                           "From " & _Nombre_Tabla_Paso & vbCrLf &
                           "Where 1 > 0" & vbCrLf &
                           "And IDMAEDDO In (Select IDMAEDDO From #Paso)" & vbCrLf &
                           "Group By RTEN,RUT,ENDO,SUENDO,RAZON,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL" &
                           vbCrLf &
                           vbCrLf &
                           "Select RTEN+KOFULIDO AS ID,TIDO+'-'+NUDO+'-'+KOFULIDO AS IDD,IDMAEEDO,TIDO,NUDO,RTEN,RUT,ENDO,SUENDO,RAZON,FEEMDO,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL," &
                           "SUM(VANELI) AS NETO,SUM(VAIVLI) AS IVA, SUM(VABRLI) AS TOTAL" & vbCrLf &
                           "Into #Paso_Documentos " & vbCrLf &
                           "From " & _Nombre_Tabla_Paso & vbCrLf &
                           "Where 1 > 0" & vbCrLf &
                           "And IDMAEDDO In (Select IDMAEDDO From #Paso)" & vbCrLf &
                           "Group By IDMAEEDO,TIDO,NUDO,RTEN,RUT,ENDO,SUENDO,RAZON,FEEMDO,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL" &
                           vbCrLf &
                           "Order by TIDO,NUDO" & vbCrLf &
                           vbCrLf &
                           "Select TIDO+'-'+NUDO+'-'+KOFULIDO AS IDD,IDMAEEDO,KOPRCT,NOKOPR,TIDO,NUDO,ENDO,SUENDO,FEEMDO,KOFULIDO,UD," &
                           "SUM(CAPRCO1) AS CANTIDAD,PPPRNE,SUM(VANELI) AS VANELI,SUM(VAIVLI) AS VAIVLI, SUM(VABRLI) AS VABRLI," &
                           "FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,MRPR,MARCA,RUPR,RUBRO_PR,CLALIBPR,CLAS_LIBRE,ZOPR,ZONA_PR" & vbCrLf &
                           "Into #Paso_Detalle" & vbCrLf &
                           "From " & _Nombre_Tabla_Paso & vbCrLf &
                           "Where 1 > 0" & vbCrLf &
                           "And IDMAEDDO In (Select IDMAEDDO From #Paso)" & vbCrLf &
                           "Group By IDMAEEDO,IDMAEDDO,KOPRCT,NOKOPR,TIDO,NUDO,ENDO,SUENDO,FEEMDO,KOFULIDO,UD,PPPRNE,FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,MRPR,MARCA,RUPR,RUBRO_PR,CLALIBPR,CLAS_LIBRE,ZOPR,ZONA_PR" &
                           vbCrLf &
                           "Order by IDMAEDDO" & vbCrLf &
                           vbCrLf &
                           "Select * From #Paso_Entidad" & vbCrLf &
                           "Select * From #Paso_Documentos" & vbCrLf &
                           "Select * From #Paso_Detalle" & vbCrLf &
                           "Select * From " & _Nombre_Tabla_Paso & vbCrLf & "Where IDMAEDDO In (Select IDMAEDDO From #Paso)" & vbCrLf &
                           "Select ENDO,SUENDO,RAZON,KOFULIDO As CodVend,VENDEDOR As Vendedor,NETO As Neto,IVA As Iva,TOTAL As Bruto From #Paso_Entidad" &
                           vbCrLf &
                           vbCrLf &
                           "Drop Table #Paso_Entidad" & vbCrLf &
                           "Drop Table #Paso_Documentos" & vbCrLf &
                           "Drop Table #Paso_Detalle" & vbCrLf &
                           "Drop Table #Paso"

        Else

            _SqlFiltro = Replace(_SqlFiltro, "KOFUEN", "Mn.KOFUEN")

            If String.IsNullOrEmpty(_SqlFiltro) Then

                Consulta_sql = "Select Mn.RTEN+Mn.KOFUEN As ID,Mn.RTEN,KOEN As ENDO,SUEN As SUENDO,NOKOEN AS RAZON,Isnull(SUM(VANELI),0) As NETO,Isnull(SUM(VAIVLI),0) AS IVA,Isnull(SUM(VABRLI),0) AS TOTAL
                            From MAEEN Mn WITH (NOLOCK)
                            Left Join " & _Nombre_Tabla_Paso & " Inf On Inf.ENDO = Mn.KOEN and Inf.SUENDO = Mn.SUEN
                            Where 1 > 0
                            And Mn.KOFUEN = '" & _Kofuen & "'
                            Group By Mn.RTEN,Mn.KOFUEN,Mn.RTEN,KOEN,SUEN,NOKOEN"
            Else

                Consulta_sql = "Select Mn.RTEN+Mn.KOFUEN As ID,Mn.RTEN,KOEN As ENDO,SUEN As SUENDO,NOKOEN AS RAZON,Isnull(SUM(VANELI),0) As NETO,Isnull(SUM(VAIVLI),0) AS IVA,Isnull(SUM(VABRLI),0) AS TOTAL
                            From MAEEN Mn WITH (NOLOCK)
                            Left Join " & _Nombre_Tabla_Paso & " Inf On Inf.ENDO = Mn.KOEN and Inf.SUENDO = Mn.SUEN
                            Where 1 > 0
                            " & _SqlFiltro & "
                            Group By Mn.RTEN,Mn.KOFUEN,Mn.RTEN,KOEN,SUEN,NOKOEN"
            End If

        End If

        _Ds_Informe = _Sql.Fx_Get_DataSet(Consulta_sql)

        If _Un_Solo_Cliente Then
            _Ds_Informe.Relations.Add("1",
                                     _Ds_Informe.Tables("Table").Columns("ID"),
                                      _Ds_Informe.Tables("Table1").Columns("ID"), False)

            _Ds_Informe.Relations.Add("2",
                                      _Ds_Informe.Tables("Table1").Columns("IDD"),
                                      _Ds_Informe.Tables("Table2").Columns("IDD"), False)
            _Tbl_Excel_Vista_Actual = _Ds_Informe.Tables(4)
        Else
            _Tbl_Excel_Vista_Actual = _Ds_Informe.Tables(0)
        End If

        Super_Grilla.PrimaryGrid.DataSource = _Ds_Informe
        Super_Grilla.PrimaryGrid.DataMember = "Table"

        _SqlExcel = Consulta_sql

        Me.Cursor = Cursors.Default
        ' Dim panel As GridPanel = GRI.GridPanel

    End Sub

    Private Sub SuperGridControl1CellValueChanged(ByVal sender As Object, ByVal e As GridCellValueChangedEventArgs)
        Dim panel As GridPanel = e.GridPanel

        'Si el valor de una celda en el panel' Detalles del pedido 'ha cambiado
        'luego actualice su pie de página para reflejar el cambio

        If panel.Name.Equals("Order Details") = True Then
            UpdateDetailsFooter(panel, "VANELI", "VAIVLI", "VABRLI")
        End If
    End Sub

    Private Sub UpdateDetailsFooter(ByVal panel As GridPanel,
                                    ByVal _CNeto As String,
                                    ByVal _CIva As String,
                                    ByVal _CTotal As String)

        If panel.Footer Is Nothing Then
            panel.Footer = New GridFooter()
        End If

        Dim _Total_Neto As Double = TotalRows(panel.Rows, _CNeto) '"VANELI")
        Dim _Total_Iva As Double = TotalRows(panel.Rows, _CIva) '"VAIVLI")
        Dim _Total_Bruto As Double = TotalRows(panel.Rows, _CTotal) ' "VABRLI")

        Dim _Color As String = "Green"

        If Global_Thema = Enum_Themas.Oscuro Then

            _Color = "#69E495"

        End If

        Dim _Pie_Pag As String = "Neto <font color=""" & _Color & """><i>" & FormatCurrency(_Total_Neto, 0) & "</i></font>" & vbCrLf &
                                 ", I.V.A. <font color=""" & _Color & """><i>" & FormatCurrency(_Total_Iva, 0) & "</i></font>" & vbCrLf &
                                 ", Total <font color=""" & _Color & """><i>" & FormatCurrency(_Total_Bruto, 0) & "</i></font>"

        'String.Format("Total Neto <font color=""Green""><i>{0:C}</i></font>", _Total_Neto) & vbCrLf & _
        'String.Format("Total Iva <font color=""Green""><i>{0:C}</i></font>", _Total_Iva) & vbCrLf & _
        'String.Format("Total Bruto <font color=""Green""><i>{0:C}</i></font>", _Total_Bruto)

        panel.Footer.Text = _Pie_Pag 'String.Format("Total sales <font color=""Green""><i>{0:C}</i></font>", _Total_Neto)
    End Sub

    Private Function TotalRows(ByVal rows As IEnumerable(Of GridElement),
                               ByVal _Campo As String) As Double
        Dim total As Decimal = 0

        For Each item As GridContainer In rows
            If TypeOf item Is GridRow Then
                Dim row As GridRow = CType(item, GridRow)


                Dim _Vaneli = row(_Campo).Value
                'DirectCast(IIf(row("VANELI").Value Is Nothing, 0D, _
                '               row("VANELI").Value), Decimal)
                'Dim discount As Single = CSng(IIf(row("Discount").Value Is Nothing, 0D, row("Discount").Value))
                'Dim quantity As Short = CShort(Fix(IIf(row("Quantity").Value Is Nothing, 0D, row("Quantity").Value)))


                'Dim unitPrice As Decimal = DirectCast(IIf(row("UnitPrice").Value Is Nothing, 0D, row("UnitPrice").Value), Decimal)
                'Dim discount As Single = CSng(IIf(row("Discount").Value Is Nothing, 0D, row("Discount").Value))
                'Dim quantity As Short = CShort(Fix(IIf(row("Quantity").Value Is Nothing, 0D, row("Quantity").Value)))
                total += _Vaneli
                'total += (unitPrice - CDec(discount)) * quantity
            End If

            If item.Rows.Count > 0 Then
                total += TotalRows(item.Rows, _Campo)
            End If
        Next item

        Return (total)
    End Function

    Private Sub SuperGridControl1GetCellStyle(ByVal sender As Object, ByVal e As GridGetCellStyleEventArgs)

        Dim panel As GridPanel = e.GridPanel

        If panel.Name.Equals("Customers") Then
            If e.GridCell.GridColumn.Name.Equals("ContactTitle") = True Then
                If CStr(e.GridCell.Value).Equals("Owner") = True Then
                    e.Style.TextColor = Color.Red
                End If
            End If
        End If

        If Global_Thema = Enum_Themas.Oscuro Then

            If e.GridCell.GridColumn.Name = "Id" Then
                e.Style.TextColor = Color.Black
            End If

            e.Style.TextColor = Color.White
        Else
            e.Style.TextColor = Color.Black
        End If

    End Sub

    Private Sub SuperGridControl1DataBindingComplete(ByVal sender As Object, ByVal e As GridDataBindingCompleteEventArgs)
        Dim panel As GridPanel = e.GridPanel

        panel.GroupByRow.Visible = True
        panel.GroupByRow.Text = "GRUPOS"

        Select Case panel.DataMember
            Case "Table"
                Sb_Formato_Grilla_Clientes(panel)
            Case "Table1"
                Sb_Formato_Grilla_Documentos(panel)
            Case "Table2"
                Sb_Formato_Grilla_Detalle(panel)
        End Select
    End Sub

    Sub Sb_Formato_Grilla_Clientes(ByVal _Grilla As GridPanel)

        Sb_Ocultar_encabezados_Super_Grilla(_Grilla)

        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 30
            .ShowRowGridIndex = True
            .GroupByRow.Visible = True

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None

            If Global_Thema = Enum_Themas.Oscuro Then
                .Columns(0).CellStyles.Default.TextColor = Color.LightYellow
            Else
                .Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)
            End If

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
            Next column

            UpdateDetailsFooter(_Grilla, "NETO", "IVA", "TOTAL")

            .Columns("ID").HeaderText = "Id"
            .Columns("ID").Width = 130
            .Columns("ID").Visible = True

            '.Columns("RTEN").EditorType = GetType(GridDoubleInputEditControl)

            '.Columns("ENDO").HeaderText = "Entidad"
            '.Columns("ENDO").Width = 100
            '.Columns("ENDO").Visible = True
            '.Columns("ENDO").EditorType = GetType(GridDoubleInputEditControl)

            '.Columns("SUENDO").HeaderText = "Suc."
            '.Columns("SUENDO").Width = 50
            '.Columns("SUENDO").Visible = True
            '.Columns("SUENDO").EditorType = GetType(GridLabelXEditControl)

            .Columns("RAZON").HeaderText = "Razón Social"
            .Columns("RAZON").Width = 300
            .Columns("RAZON").Visible = True

            If _Un_Solo_Cliente Then
                .Columns("RAZON").GroupBoxEffects = GroupBoxEffects.Move
            Else
                .Columns("RAZON").GroupBoxEffects = GroupBoxEffects.None
            End If

            '.Columns("RAZON").EditorType = GetType(GridLabelXEditControl)

            '.Columns("KOFULIDO").HeaderText = "Cod."
            '.Columns("KOFULIDO").Width = 30
            '.Columns("KOFULIDO").Visible = True
            '.Columns("KOFULIDO").EditorType = GetType(GridLabelXEditControl)

            If _Un_Solo_Cliente Then
                .Columns("VENDEDOR").HeaderText = "Vendedor"
                .Columns("VENDEDOR").Width = 250
                .Columns("VENDEDOR").Visible = True
                .Columns("VENDEDOR").GroupBoxEffects = GroupBoxEffects.Move
            End If

            .Columns("NETO").HeaderText = "Neto"
            .Columns("NETO").Width = 100
            .Columns("NETO").Visible = True
            .Columns("NETO").CellStyles.Default.Alignment = Alignment.MiddleRight

            DirectCast(.Columns("NETO").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

            .Columns("IVA").HeaderText = "Iva"
            .Columns("IVA").Width = 100
            .Columns("IVA").Visible = True
            .Columns("IVA").CellStyles.Default.Alignment = Alignment.MiddleRight

            DirectCast(.Columns("IVA").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

            .Columns("TOTAL").HeaderText = "Total"
            .Columns("TOTAL").Width = 100
            .Columns("TOTAL").Visible = True
            .Columns("TOTAL").CellStyles.Default.Alignment = Alignment.MiddleRight

            DirectCast(.Columns("TOTAL").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"


        End With

    End Sub

    Sub Sb_Formato_Grilla_Documentos(ByVal _Grilla As GridPanel)

        Sb_Ocultar_encabezados_Super_Grilla(_Grilla)

        With _Grilla

            .ShowRowGridIndex = True
            .ShowRowDirtyMarker = True
            .ColumnHeader.RowHeight = 30

            .Columns(0).CellStyles.Default.Background = New Background(Color.Beige)

            .Caption = New GridCaption()

            Dim _Color As String = "Maroon"

            If Global_Thema = Enum_Themas.Oscuro Then
                _Color = "#A24B40"
            End If

            .Caption.Text = String.Format("Documentos ({0}), Cliente: <font color=""" & _Color & """><i>""{1}</i>""</font>",
                            .Rows.Count,
                            CType(.Parent, GridRow)("RAZON").Value)

            .DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft
            .DefaultVisualStyles.GroupByStyles.Default.Background = _Background2

            UpdateDetailsFooter(_Grilla, "NETO", "IVA", "TOTAL")

            '.Columns("ID").HeaderText = "Id"
            '.Columns("ID").Width = 75
            '.Columns("IDMAEEDO").Visible = True

            '.Columns("TIDO").HeaderText = "TD"
            '.Columns("TIDO").Width = 30
            '.Columns("TIDO").Visible = True
            '.Columns("RTEN").EditorType = GetType(GridDoubleInputEditControl)

            '.Columns("NUDO").HeaderText = "Número"
            '.Columns("NUDO").Width = 75
            '.Columns("NUDO").Visible = True

            .Columns("IDD").HeaderText = "Id"
            .Columns("IDD").Width = 20
            .Columns("IDD").Visible = True

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            '.Columns("RTEN").EditorType = GetType(GridDoubleInputEditControl)

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 75
            .Columns("NUDO").Visible = True

            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").Visible = True
            '.Columns("SUENDO").EditorType = GetType(GridLabelXEditControl)

            .Columns("NETO").HeaderText = "Neto"
            .Columns("NETO").Width = 80
            .Columns("NETO").Visible = True
            .Columns("NETO").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("NETO").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

            .Columns("IVA").HeaderText = "Iva"
            .Columns("IVA").Width = 80
            .Columns("IVA").Visible = True
            .Columns("IVA").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("IVA").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

            .Columns("TOTAL").HeaderText = "Total"
            .Columns("TOTAL").Width = 80
            .Columns("TOTAL").Visible = True
            .Columns("TOTAL").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("TOTAL").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

        End With

    End Sub

    Sub Sb_Formato_Grilla_Detalle(ByVal _Grilla As GridPanel)

        Sb_Ocultar_encabezados_Super_Grilla(_Grilla)

        With _Grilla

            .ColumnHeader.RowHeight = 30
            .ShowRowGridIndex = True

            .Columns(0).CellStyles.Default.Background = New Background(Color.LavenderBlush)

            .Columns("IDMAEEDO").CellStyles.Default.Alignment = Alignment.MiddleLeft

            .DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft
            '.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleRight

            If StyleManager.MetroColorGeneratorParameters.CanvasColor = Color.Black Then
                .DefaultVisualStyles.GroupByStyles.Default.Background = _Background3_Black
            Else
                .DefaultVisualStyles.GroupByStyles.Default.Background = _Background3
            End If

            UpdateDetailsFooter(_Grilla, "VANELI", "VAIVLI", "VABRLI")

            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").Visible = True
            '.Columns("RTEN").EditorType = GetType(GridDoubleInputEditControl)

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").Visible = True
            '.Columns("ENDO").EditorType = GetType(GridDoubleInputEditControl)

            .Columns("UD").HeaderText = "UM"
            .Columns("UD").Width = 30
            .Columns("UD").Visible = True

            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").Width = 80
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("CANTIDAD").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"

            .Columns("PPPRNE").HeaderText = "Precio"
            .Columns("PPPRNE").Width = 80
            .Columns("PPPRNE").Visible = True
            .Columns("PPPRNE").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("PPPRNE").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

            .Columns("VANELI").HeaderText = "Neto"
            .Columns("VANELI").Width = 80
            .Columns("VANELI").Visible = True
            .Columns("VANELI").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("VANELI").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

            .Columns("VAIVLI").HeaderText = "Iva"
            .Columns("VAIVLI").Width = 80
            .Columns("VAIVLI").Visible = True
            .Columns("VAIVLI").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("VAIVLI").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

            .Columns("VABRLI").HeaderText = "Total"
            .Columns("VABRLI").Width = 80
            .Columns("VABRLI").Visible = True
            .Columns("VABRLI").CellStyles.Default.Alignment = Alignment.MiddleRight
            DirectCast(.Columns("VABRLI").RenderControl, GridDoubleInputEditControl).DisplayFormat = "$ ###,##"

        End With

    End Sub

    Sub Sb_Ocultar_encabezados_Super_Grilla(ByVal _Grilla As GridPanel)

        With _Grilla

            Dim NCol As Integer = .Columns.Count 'ColumnCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 0 To NCol - 1

                Dim NomColumna = .Columns(i).Name.ToString()
                'Dim TipoColumna = .Columns(i).CellType.ToString 'DataGrid.Columns(i - 1).ValueType.ToString()

                .Columns(i).Visible = False
                .Columns(i).ReadOnly = True ' _ReadOnly
                .Columns(i).GroupBoxEffects = GroupBoxEffects.None
                '.Columns(i).CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
                '.Columns(i).EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIpAddressInputEditControl)
                '.Columns(i).HeaderStyles.Default.Image = My.Resources.ok_button 'CType(Resources.GetObject("resource.Image"), System.Drawing.Image)
                '.Columns(i).Name = "IpAddressInput"
                '.Columns(i).Width = 150
                'If Activar_Orden_Automatico Then

                'End If

            Next

        End With


        _Grilla.ShowToolTips = True
        _Grilla.GroupByRow.Visible = False

        _Grilla.MinRowHeight = 20
        _Grilla.AutoGenerateColumns = True

        If StyleManager.MetroColorGeneratorParameters.CanvasColor = Color.Black Then
            _Grilla.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1_Black
        Else
            _Grilla.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1
        End If

        _Grilla.SelectionGranularity = SelectionGranularity.Cell

    End Sub


    Private Sub SuperGridControl1SelectionChanged(ByVal sender As Object, ByVal e As GridEventArgs)

        Dim panel As GridPanel = e.GridPanel 'superGridControl1.PrimaryGrid
        Dim items As SelectedElementCollection = panel.GetSelectedElements()
        Dim cells As List(Of GridCell) = items.GetCells()

        _Grilla_Activa = panel.DataMember.ToString

        Dim s As String = Nothing

        If cells.Count > 0 Then
            For Each cell As GridCell In cells
                '  If ValuesMatch(s, DirectCast(cell.Value, String)) = False Then
                'Exit For
                'End If
            Next
        End If

        ' TbxCellText.Text = s
    End Sub

    Private Sub Txt_Filtro_Abanzado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Filtro_Abanzado.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Mnu_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Estadisticas_Producto.Click

        Dim _Fila As GridRow = _Panel_Activo.Rows(_Panel_Activo.ActiveRow.Index) 'Super_Grilla.PrimaryGrid.Rows(Super_Grilla.PrimaryGrid.ActiveRow.Index) 'Super_Grilla.PrimaryGrid.Rows(0)

        Dim _Kopr = _Fila.Cells("KOPRCT").Value
        Dim _Endo = _Fila.Cells("ENDO").Value

        Dim _Producto_Op As New Frm_BkpPostBusquedaEspecial_Mt
        _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)

    End Sub

    Private Sub Btn_Mnu_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ver_Documento.Click

        Dim _Fila As GridRow = _Panel_Activo.Rows(_Panel_Activo.ActiveRow.Index)
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Informeacion_Credito_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Informeacion_Credito_Cliente.Click
        Try
            If Fx_Tiene_Permiso(Me, "Inf00018") Then

                Dim _Fila As GridRow = _Panel_Activo.Rows(_Panel_Activo.ActiveRow.Index)

                Dim _Koen As String = _Fila.Cells("ENDO").Value
                Dim _Suen As String = _Fila.Cells("SUENDO").Value
                Dim _Razon As String = _Fila.Cells("RAZON").Value

                Dim Fm As New Frm_Infor_Ent_Estado_Creditos_Vigentes
                Fm.Pro_TxtDescripcion = _Razon
                Fm.ShowDialog(Me)
                Fm.Dispose()
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub Super_Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs) Handles Super_Grilla.CellDoubleClick

        _Panel_Activo = CType(sender, SuperGridControl).ActiveGrid

        'If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
        'Dim item As GridElement = Super_Grilla.GetElementAt(e.Location)

        'If TypeOf item Is GridCell Then

        If Not (e Is Nothing) Then
            _HitColumn = _Panel_Activo.Columns(e.GridCell.ColumnIndex)
        End If

        Btn_Mnu_Informeacion_Credito_Cliente.Visible = False
        Btn_Mnu_Ver_Documento.Visible = False
        Btn_Mnu_Estadisticas_Producto.Visible = False

        Select Case _Panel_Activo.DataMember
            Case "Table"
                Btn_Mnu_Informeacion_Credito_Cliente.Visible = True
            Case "Table1"
                Btn_Mnu_Ver_Documento.Visible = True
            Case "Table2"
                Btn_Mnu_Estadisticas_Producto.Visible = True
        End Select

        ShowContextMenu(Menu_Contextual)

        'End If

    End Sub

    Private Sub Super_Grilla_CellMouseDown(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs) Handles Super_Grilla.CellMouseDown

        _Panel_Activo = CType(sender, SuperGridControl).ActiveGrid

        If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            _HitColumn = _Panel_Activo.Columns(e.GridCell.ColumnIndex)
            Call Super_Grilla_CellDoubleClick(sender, Nothing)
        End If

    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click

        If String.IsNullOrEmpty(_Kofuen) Then
            ShowContextMenu(Menu_contextual_Exportar_Excel)
        Else
            Call Btn_Exportar_Vista_Actual_Click(Nothing, Nothing)
            'ExportarTabla_JetExcel_Tabla(_Tbl_Excel_Vista_Actual, Me, "Vista Actual")
        End If

    End Sub

    Private Sub Btn_Informe_X_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Productos.Click
        Try
            Dim _Fila As GridRow = _Panel_Activo.Rows(_Panel_Activo.ActiveRow.Index)

            Dim _Endo As String = _Fila.Cells("ENDO").Value
            Dim _Suendo As String = _Fila.Cells("SUENDO").Value

            Dim _Filtro As String = "And ENDO = '" & _Endo & "' And SUENDO = '" & _Suendo & "'"

            Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtro_Abanzado.Text),
                                    "ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR LIKE '%")

            _Filtro += "And ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR Like '%" & _Cadena & "%'"

            If Not String.IsNullOrEmpty(_SqlFiltro) Then
                _Filtro += vbCrLf & _SqlFiltro
                _Filtro = Replace(_Filtro, "Mn.", "")
            End If

            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso,
                                                                  _Filtro,
                                                                  Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Detalle)
            Fm.Txt_Filtro_Abanzado.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub Btn_Informe_X_Documentos_Entidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Documentos_Entidades.Click
        Try
            Dim _Fila As GridRow = _Panel_Activo.Rows(_Panel_Activo.ActiveRow.Index)

            Dim _Endo As String = _Fila.Cells("ENDO").Value
            Dim _Suendo As String = _Fila.Cells("SUENDO").Value

            Dim _Filtro As String = "And ENDO = '" & _Endo & "' And SUENDO = '" & _Suendo & "'" & vbCrLf


            Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtro_Abanzado.Text),
                                    "ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR LIKE '%")

            _Filtro += "And ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR Like '%" & _Cadena & "%'"

            If Not String.IsNullOrEmpty(_SqlFiltro) Then
                _Filtro += vbCrLf & _SqlFiltro
                _Filtro = Replace(_Filtro, "Mn.", "")
            End If

            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso,
                                                                  _Filtro,
                                                                  Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Documentos)
            Fm.Txt_Filtro_Abanzado.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub Btn_Exportar_Vista_Actual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Vista_Actual.Click
        If Fx_Tiene_Permiso(Me, "Inf00041") Then
            ExportarTabla_JetExcel_Tabla(_Tbl_Excel_Vista_Actual, Me, "Vista Actual")
        End If
    End Sub

    Private Sub Btn_Exportar_Detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Detalle.Click

        If Not Fx_Tiene_Permiso(Me, "Inf00048") Then
            Return
        End If

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtro_Abanzado.Text),
                               "ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR LIKE '%")

        Dim _VerCosto As String = "COSTO,MONTO,"

        If Fx_Tiene_Permiso(Me, "NO00001",, False) Then
            _VerCosto = String.Empty
        End If

        Consulta_sql = "Select IDMAEDDO Into #Paso From " & _Nombre_Tabla_Paso & " WHIT (NOLOCK)" & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _SqlFiltro & vbCrLf &
                       "And ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA+KOPRCT+NOKOPR Like '%" & _Cadena & "%'" & vbCrLf &
                       "Select EMPRESA,TIDO,NUDO,RTEN,RUT,ENDO,SUENDO,RAZON,KOFUEN,VENDEDOR_ASIGNADO,RUEN,RUBRO_EN,ZOEN,ZONA_EN,ACTIEN," & vbCrLf &
                       "ACTIVIDAD_ECONOMICA,TIPOEN,TIPO_ENTIDAD,TAMAEN,TAMANO_EMPRESA,TRANSPOEN,TRANSPORTISTA,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL," & vbCrLf &
                       "FEEMDO,KOFUDO,FUNCIONARIO,VANEDO,VAIVDO,VABRDO,LILG,NULIDO,SULIDO,BOSULIDO,BODEGA,KOFULIDO,VENDEDOR,PRCT,TICT,TIPR,KOPRCT,NOKOPR,UD," & vbCrLf &
                       "UDTRPR,RLUDPR,UD01PR,CAPRCO1,UD02PR,CAPRCO2,PPPRNE,PPPRBR,VANELI,VAIVLI,VAIMLI,VABRLI,FEEMLI,FEERLI,PPPRNERE1,PPPRNERE2," & vbCrLf &
                       "FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,MRPR,MARCA,RUPR,RUBRO_PR,CLALIBPR,CLAS_LIBRE,ZOPR,ZONA_PR," & vbCrLf &
                       _VerCosto & "OCDO,SUCURSALLIDO,KOLTPR,NOKOLTPR,LVEN,NOLVEN From " & _Nombre_Tabla_Paso & " WHIT (NOLOCK)" & vbCrLf &
                       "Where IDMAEDDO In (Select IDMAEDDO From #Paso)" &
                       vbCrLf &
                       "Drop Table #Paso"
        _Tbl_Excel = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl_Excel, Me, "Detalle de venta")
    End Sub

    Private Sub Btn_Nota_de_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nota_de_venta.Click

        If Fx_Tiene_Permiso(Me, "Bkp00040") Then

            Dim Fm_Post As New Frm_Formulario_Documento("NVV", csGlobales.Enum_Tipo_Documento.Venta, False)
            'Fm_Post.Btn_Minimizar.Visible = True
            Fm_Post.MinimizeBox = True
            Fm_Post.ShowDialog(Me)
            Fm_Post.Dispose()

        End If

    End Sub

    Private Sub Btn_Crear_Venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Venta.Click
        ShowContextMenu(Menu_Contextual_Ventas)
    End Sub

    Private Sub Btn_Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar.Click

        If Not (_HitColumn Is Nothing) Then

            '_Panel_Activo = CType(sender, SuperGridControl).ActiveGrid

            Dim _Cabeza = _HitColumn.Name ' Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)
            'Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim Copiar As String = _Fila.Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, "El código está en el portapapeles", Btn_Copiar.Image,
                                         2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If


    End Sub
End Class
