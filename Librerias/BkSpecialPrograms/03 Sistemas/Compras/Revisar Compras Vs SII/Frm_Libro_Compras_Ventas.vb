Imports System.IO
Imports DevComponents.DotNetBar


Public Class Frm_Libro_Compras_Ventas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Conectar_SQL As String

    Dim _TblInforme As DataTable

    Dim _Inf_00_SII As DataTable
    Dim _Inf_01_SII_y_Random As DataTable
    Dim _Inf_02_Solo_SII As DataTable
    Dim _Inf_03_SII_Random_Otro_Mes As DataTable
    Dim _Inf_04_SII_Random_Direfencias As DataTable
    Dim _Inf_05_Solo_Random As DataTable
    Dim _Inf_06_Libro_Compras As DataTable

    Dim _Periodo As Integer
    Dim _Mes As Integer
    Dim _Mes_Palabra As String
    Dim _Libro As String

    Public Sub New(Periodo As Integer,
                   Mes As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Periodo = Periodo
        _Mes = Mes

        _Libro = Periodo & numero_(Mes, 2)

        _Mes_Palabra = MonthName(Mes)
        _Mes_Palabra = UCase(Mid(_Mes_Palabra, 1, 1)) & Mid(_Mes_Palabra, 2, _Mes_Palabra.Length)

        Me.Text = "Periodo " & _Periodo & " Mes " & UCase(MonthName(Mes))

        Sb_Color_Botones_Barra(Bar1)

        Sb_Formato_Generico_Grilla(Grilla_00, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_01, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_02, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_03, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_04, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_05, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_06, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)

    End Sub

    Private Sub Frm_Libro_Compras_Ventas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Tab.SelectedTabChanged, AddressOf Sb_Tab_SelectedTabChanged

        'Sb_Actualizar_Tablas_SQL()
        Sb_Actualizar_Grillas(0)
        Sb_Actualizar_Totales_SII(_Inf_00_SII)

        Tab_00.Text = "SII " & _Mes_Palabra
        Tab_01.Text = "SII y Rd " & _Mes_Palabra
        Tab_02.Text = "Solo en SII"
        'Tab_03.Text = ""
        'Tab_04.Text = ""
        Tab_05.Text = "Libro compras " & _Mes_Palabra & " Random"
        'Tab_06.Text = ""

        AddHandler Grilla_00.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler Grilla_01.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler Grilla_02.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler Grilla_03.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler Grilla_04.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler Grilla_05.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler Grilla_06.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick

        AddHandler Grilla_00.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_01.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_02.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_03.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_04.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_05.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_06.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Cambiar_Libro.Visible = False

        Sb_Refrescar_Grillas()

        Me.Refresh()

    End Sub

    Private Sub Btn_Libro_SII_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Libro_SII.Click
        Sb_Actualizar_Grillas(Tab.SelectedTabIndex)
    End Sub

    Sub Sb_Actualizar_Tablas_SQL()

        Dim Consulta_sql As String

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set " & vbCrLf &
                       "Idmaeedo = Isnull((Select IDMAEEDO From MAEEDO Z2 Where Z1.Tido = Z2.TIDO And Z1.Nudo = Z2.NUDO And Z1.Endo = Z2.ENDO),0)," & vbCrLf &
                       "Libro = Isnull((Select LIBRO From MAEEDO Z2 Where Z1.Tido = Z2.TIDO And Z1.Nudo = Z2.NUDO And Z1.Endo = Z2.ENDO),'')," & vbCrLf &
                       "Vabrdo = Isnull((Select VABRDO From MAEEDO Z2 Where Z1.Tido = Z2.TIDO And Z1.Nudo = Z2.NUDO And Z1.Endo = Z2.ENDO),0)" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Compras_en_SII Z1" & vbCrLf &
                       "Where Periodo = " & _Periodo & " And Mes = " & _Mes & " And Revisado = 0 --(Vabrdo <> 0 or Monto_Total <> 0)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set" & vbCrLf &
                       "Monto_Exento = Monto_Exento*-1," & vbCrLf &
                       "Monto_Neto = Monto_Neto*-1," & vbCrLf &
                       "Monto_Iva_Recuperable = Monto_Iva_Recuperable *-1," & vbCrLf &
                       "Monto_Iva_No_Recuperable = Monto_Iva_No_Recuperable *-1," & vbCrLf &
                       "Monto_Total = Monto_Total*-1," & vbCrLf &
                       "Valor_Otro_impuesto = Valor_Otro_impuesto*-1--," & vbCrLf &
                       "--Vanedo = Vanedo*-1," & vbCrLf &
                       "--Vaivdo = Vaivdo*-1," & vbCrLf &
                       "--Vabrdo = Vabrdo*-1" & vbCrLf &
                       "Where Periodo = " & _Periodo & " And Mes = " & _Mes & " And Tido = 'NCC'" & " And Revisado = 0 --And (Vabrdo > 0 or Monto_Total > 0)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set" & vbCrLf &
                       "Vanedo = (Select VANEDO From MAEEDO Z2 Where Z2.IDMAEEDO = Z1.Idmaeedo)," &
                       "Vaivdo = (Select VAIVDO From MAEEDO Z2 Where Z2.IDMAEEDO = Z1.Idmaeedo)," &
                       "Vabrdo = (Select VABRDO From MAEEDO Z2 Where Z2.IDMAEEDO = Z1.Idmaeedo)" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Compras_en_SII Z1" & vbCrLf &
                       "Where Idmaeedo <> 0"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set Diferencia = Vabrdo - Monto_Total" & vbCrLf &
                       "Where Periodo = " & _Periodo & " And Mes = " & _Mes & " --And Revisado = 0" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set Libro = ''" & vbCrLf &
                       "Where Libro is null" & vbCrLf &
                       "And Periodo = " & _Periodo & " And Mes = " & _Mes & " --And Revisado = 0 --And (Vabrdo > 0 or Monto_Total > 0) "
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII" & Space(1) &
                       "Set" & vbCrLf &
                       "Idmaeedo_Sugerido = Isnull((Select Top 1 IDMAEEDO From MAEEDO" & Space(1) &
                       "Where ENDO = Endo And TIDO = Tido And Monto_Total = VABRDO And" & Space(1) &
                       "IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Compras_en_SII)),0)," & vbCrLf &
                       "Tido_Sugerido = Isnull((Select Top 1 TIDO From MAEEDO" & Space(1) &
                       "Where ENDO = Endo And TIDO = Tido And Monto_Total = VABRDO And" & Space(1) &
                       "IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Compras_en_SII)),'')," & vbCrLf &
                       "Nudo_Sugerido = Isnull((Select Top 1 NUDO From MAEEDO" & Space(1) &
                       "Where ENDO = Endo And TIDO = Tido And Monto_Total = VABRDO And" & Space(1) &
                       "IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Compras_en_SII)),'')," & vbCrLf &
                       "Libro_Sugerido = Isnull((Select Top 1 LIBRO From MAEEDO" & Space(1) &
                       "Where ENDO = Endo And TIDO = Tido And Monto_Total = VABRDO And" & Space(1) &
                       "IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Compras_en_SII)),'')" & vbCrLf &
                       "Where Libro = '' And Periodo = " & _Periodo & " And Mes = " & _Mes & " And Revisado = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set" & vbCrLf &
                       "Revisado = 1" & vbCrLf &
                       "Where Periodo = " & _Periodo & " And Mes = " & _Mes & " And Revisado = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_Actualizar_Grillas(_TabIndex As Integer)

        Dim _Descripcion As String = RTrim$(Txt_Descripcion.Text)

        Dim _Cadena_SII As String = CADENA_A_BUSCAR(_Descripcion, "Tido+Nudo+Endo+Libro+Rut_Proveedor+Razon_Social+Folio+STR(Monto_Total) LIKE '%")

        Dim _Filtro_SII As String = "And Tido+Nudo+Endo+Libro+Rut_Proveedor+Razon_Social+Cmp.Folio+STR(Monto_Total) LIKE '%" & _Cadena_SII & "%'"


        'Consulta_sql = "-- Tabla 0 
        '                Select * From " & _Global_BaseBk & "Zw_Compras_en_SII
        '                Where Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
        '                _Filtro_SII & "
        '                Order by Libro  

        '                -- Tabla 1
        '                Select * From " & _Global_BaseBk & "Zw_Compras_en_SII
        '                Where Libro <> '' And Libro Like '" & _Libro & "%' And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
        '                _Filtro_SII & "
        '                Order by Libro

        '                -- Tabla 2
        '                Update " & _Global_BaseBk & "Zw_Compras_en_SII Set Idmaeedo_GRC = Isnull((Select IDMAEEDO From MAEEDO Where TIDO = 'GRC' And NUDO = Nudo And ENDO = Endo),0)
        '                Where Libro = '' And Periodo = " & _Periodo & " And Mes = " & _Mes & " And Idmaeedo = 0

        '                Select *,Case When Isnull((Select Top 1 Id From " & _Global_BaseBk & "Zw_DTE_ReccDet Z1 Where Cmp.Rut_Proveedor = Z1.RutEmisor And Z1.Folio = Cmp.Folio And Cmp.TipoDoc = Z1.TipoDTE),0) = 0 Then 'No' Else 'Si' End As TPDF From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
        '                Where Libro = '' And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
        '               _Filtro_SII & "

        '                -- Tabla 3
        '                Select * From " & _Global_BaseBk & "Zw_Compras_en_SII
        '                Where Libro <> '' And Libro not Like '" & _Libro & "%' And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
        '                _Filtro_SII & "
        '                Order by Libro

        '                -- Tabla 4
        '                Select * From " & _Global_BaseBk & "Zw_Compras_en_SII
        '                Where Diferencia <> 0 And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
        '                _Filtro_SII


        Consulta_sql = "-- Tabla 0 
                        Select Case When DteD.[Xml] IS NULL then 'No' Else 'Si' End As 'TPDF',Cmp.*,DteD.[Xml],Cast(0 As Bit) As 'TieneOccRef',Cast('' As Varchar(20)) As 'OccRef' 
                        From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
                        Left Join " & _Global_BaseBk & "Zw_DTE_ReccDet DteD On Cmp.Rut_Proveedor = DteD.RutEmisor And Cmp.Folio = DteD.Folio
                        Where Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
                        _Filtro_SII & "
                        Order by Libro  

                        -- Tabla 1
                        Select * From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
                        Where Libro <> '' And Libro Like '" & _Libro & "%' And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
                        _Filtro_SII & "
                        Order by Libro
                       
                        -- Tabla 2
                        Update " & _Global_BaseBk & "Zw_Compras_en_SII Set Idmaeedo_GRC = Isnull((Select IDMAEEDO From MAEEDO Where TIDO = 'GRC' And NUDO = Nudo And ENDO = Endo),0)
                        Where Libro = '' And Periodo = " & _Periodo & " And Mes = " & _Mes & " And Idmaeedo = 0

                        Select Case When DteD.[Xml] IS NULL then 'No' Else 'Si' End As 'TPDF',Cmp.*,DteD.[Xml],Cast(0 As Bit) As 'TieneOccRef',Cast('' As Varchar(20)) As 'OccRef'
                        From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
                        Left Join " & _Global_BaseBk & "Zw_DTE_ReccDet DteD On Cmp.Rut_Proveedor = DteD.RutEmisor And Cmp.Folio = DteD.Folio
                        Where Libro = '' And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
                       _Filtro_SII & "
                       
                        -- Tabla 3 
                        Select * From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
                        Where Libro <> '' And Libro not Like '" & _Libro & "%' And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
                        _Filtro_SII & "
                        Order by Libro
                       
                        -- Tabla 4
                        Select * From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
                        Where Diferencia <> 0 And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
                        _Filtro_SII


        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Inf_00_SII = _Ds.Tables(0)
        _Inf_01_SII_y_Random = _Ds.Tables(1)
        _Inf_02_Solo_SII = _Ds.Tables(2)
        _Inf_03_SII_Random_Otro_Mes = _Ds.Tables(3)
        _Inf_04_SII_Random_Direfencias = _Ds.Tables(4)

        Dim _Cadena_Random As String = CADENA_A_BUSCAR(_Descripcion, "TIDO+NUDO+ENDO+LIBRO+NOKOEN+STR(VABRDO) LIKE '%")

        Dim _Filtro_Random As String = "And TIDO+NUDO+ENDO+LIBRO+NOKOEN+STR(VABRDO) LIKE '%" & _Cadena_Random & "%'"

        Dim _Filtro As String = "AND EDO.LIBRO LIKE '" & _Cadena_Random & "%' AND LIBRO NOT IN (Select Libro From " & _Global_BaseBk & "Zw_Compras_en_SII" & ")" & vbCrLf

        Consulta_sql = My.Resources.Recursos_Libros_Compra_Venta.SqlQuery_Libro_Compras
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Libro#", _Libro)
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro & _Filtro_Random)

        _Inf_05_Solo_Random = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = My.Resources.Recursos_Libros_Compra_Venta.SqlQuery_Libro_Compras
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Libro#", _Libro)
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro_Random)

        _Inf_06_Libro_Compras = _Sql.Fx_Get_Tablas(Consulta_sql)

        Tab.SelectedTabIndex = _TabIndex


        For Each _Fila As DataRow In _Inf_02_Solo_SII.Rows

            If _Fila.Item("TPDF") = "Si" Then

                Dim _Xml As String = _Fila.Item("XML")

                Dim _Archivo_Xml As New XmlDocument()
                _Archivo_Xml.LoadXml(_Xml)

                Dim fullPath As String = "...\\archivo.xml"
                File.WriteAllText(fullPath, _Xml)

                Dim _Dset_DTE As New DataSet
                _Dset_DTE.ReadXml(fullPath)

                Dim _Tbl_Referencia As DataTable

                Try
                    _Tbl_Referencia = _Dset_DTE.Tables("Referencia")
                Catch ex As Exception
                    _Tbl_Referencia = Nothing
                End Try

                If Not IsNothing(_Tbl_Referencia) Then
                    For Each _Fl As DataRow In _Tbl_Referencia.Rows
                        If _Fl.Item("TpoDocRef") = "801" Then
                            _Fila.Item("TieneOccRef") = True
                            _Fila.Item("OccRef") = _Fl.Item("FolioRef").ToString.Trim
                        End If
                    Next
                End If

            End If

        Next

        For Each _Fila As DataRow In _Inf_00_SII.Rows

            If _Fila.Item("TPDF") = "Si" Then

                Dim _Xml As String = _Fila.Item("XML")

                Dim _Archivo_Xml As New XmlDocument()
                _Archivo_Xml.LoadXml(_Xml)

                Dim fullPath As String = "...\\archivo.xml"
                File.WriteAllText(fullPath, _Xml)

                Dim _Dset_DTE As New DataSet
                _Dset_DTE.ReadXml(fullPath)

                Dim _Tbl_Referencia As DataTable

                Try
                    _Tbl_Referencia = _Dset_DTE.Tables("Referencia")
                Catch ex As Exception
                    _Tbl_Referencia = Nothing
                End Try

                If Not IsNothing(_Tbl_Referencia) Then
                    For Each _Fl As DataRow In _Tbl_Referencia.Rows
                        If _Fl.Item("TpoDocRef") = "801" Then
                            _Fila.Item("TieneOccRef") = True
                            _Fila.Item("OccRef") = _Fl.Item("FolioRef").ToString.Trim
                        End If
                    Next
                End If

            End If

        Next

        Try
            _Inf_02_Solo_SII.Columns.Remove("XML")
            _Inf_00_SII.Columns.Remove("XML")
            File.Delete("...\\archivo.xml")
        Catch ex As Exception

        End Try

    End Sub

    Sub Sb_Formato_Grilla_00()

        With Grilla_00

            .DataSource = _Inf_00_SII

            OcultarEncabezadoGrilla(Grilla_00, False)

            Dim _DisplayIndex = 0

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rut_Proveedor").Visible = True
            .Columns("Rut_Proveedor").HeaderText = "Rut Proveedor"
            .Columns("Rut_Proveedor").Width = 80
            .Columns("Rut_Proveedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Razon_Social").Visible = True
            .Columns("Razon_Social").HeaderText = "Razón Social"
            .Columns("Razon_Social").Width = 200
            .Columns("Razon_Social").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Folio").Visible = True
            .Columns("Folio").HeaderText = "Folio"
            .Columns("Folio").Width = 80
            .Columns("Folio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TPDF").Visible = True
            .Columns("TPDF").HeaderText = "PDF"
            .Columns("TPDF").Width = 30
            .Columns("TPDF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            'OccRef,FolioRef
            .Columns("TieneOccRef").Visible = True
            .Columns("TieneOccRef").HeaderText = "Tiene OC"
            .Columns("TieneOccRef").ToolTipText = "Tiene OC en referencia del XML"
            .Columns("TieneOccRef").Width = 40
            .Columns("TieneOccRef").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Libro").Visible = True
            .Columns("Libro").HeaderText = "Libro"
            .Columns("Libro").Width = 110
            .Columns("Libro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Docto").Visible = True
            .Columns("Fecha_Docto").HeaderText = "Fecha"
            .Columns("Fecha_Docto").Width = 80
            .Columns("Fecha_Docto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Docto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Exento").Visible = True
            .Columns("Monto_Exento").HeaderText = "Exento"
            .Columns("Monto_Exento").Width = 80
            .Columns("Monto_Exento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Exento").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Exento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Neto").Visible = True
            .Columns("Monto_Neto").HeaderText = "Neto"
            .Columns("Monto_Neto").Width = 80
            .Columns("Monto_Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Neto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Neto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Iva_Recuperable").Visible = True
            .Columns("Monto_Iva_Recuperable").HeaderText = "Iva"
            .Columns("Monto_Iva_Recuperable").Width = 80
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Iva_Recuperable").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valor_Otro_Impuesto").Visible = True
            .Columns("Valor_Otro_Impuesto").HeaderText = "Otro Impuesto"
            .Columns("Valor_Otro_Impuesto").Width = 80
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Valor_Otro_Impuesto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Total").Visible = True
            .Columns("Monto_Total").HeaderText = "Total"
            .Columns("Monto_Total").Width = 80
            .Columns("Monto_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Total").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Total").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Diferencia"
            .Columns("Diferencia").Width = 80
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Diferencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla_00.Rows

            Dim _TipoDoc As Integer = _Fila.Cells("TipoDoc").Value
            Dim _Libro_cp As String = _Fila.Cells("Libro").Value
            Dim _Diferencia As Double = NuloPorNro(_Fila.Cells("Diferencia").Value, 0)

            If _TipoDoc = 61 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Amarillo
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

            If String.IsNullOrEmpty(_Libro_cp) Then
                _Fila.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf _Libro_cp.Contains(_Libro) Then
                _Fila.Cells("Libro").Style.ForeColor = Verde
            Else
                _Fila.Cells("Libro").Style.ForeColor = Rojo
            End If

            If CBool(_Diferencia) Then
                _Fila.Cells("Diferencia").Style.ForeColor = Rojo
            End If

        Next

    End Sub

    Sub Sb_Formato_Grilla_01()

        With Grilla_01

            .DataSource = _Inf_01_SII_y_Random

            OcultarEncabezadoGrilla(Grilla_01, False)

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = 0

            .Columns("Rut_Proveedor").Visible = True
            .Columns("Rut_Proveedor").HeaderText = "Rut Proveedor"
            .Columns("Rut_Proveedor").Width = 80
            .Columns("Rut_Proveedor").DisplayIndex = 1

            .Columns("Razon_Social").Visible = True
            .Columns("Razon_Social").HeaderText = "Razón Social"
            .Columns("Razon_Social").Width = 200
            .Columns("Razon_Social").DisplayIndex = 2

            .Columns("Folio").Visible = True
            .Columns("Folio").HeaderText = "Folio"
            .Columns("Folio").Width = 80
            .Columns("Folio").DisplayIndex = 3

            .Columns("Libro").Visible = True
            .Columns("Libro").HeaderText = "Libro"
            .Columns("Libro").Width = 100
            .Columns("Libro").DisplayIndex = 4

            .Columns("Fecha_Docto").Visible = True
            .Columns("Fecha_Docto").HeaderText = "Fecha"
            .Columns("Fecha_Docto").Width = 80
            .Columns("Fecha_Docto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Docto").DisplayIndex = 5

            .Columns("Monto_Exento").Visible = True
            .Columns("Monto_Exento").HeaderText = "Exento"
            .Columns("Monto_Exento").Width = 80
            .Columns("Monto_Exento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Exento").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Exento").DisplayIndex = 6

            .Columns("Monto_Neto").Visible = True
            .Columns("Monto_Neto").HeaderText = "Neto"
            .Columns("Monto_Neto").Width = 80
            .Columns("Monto_Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Neto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Neto").DisplayIndex = 7

            .Columns("Monto_Iva_Recuperable").Visible = True
            .Columns("Monto_Iva_Recuperable").HeaderText = "Iva"
            .Columns("Monto_Iva_Recuperable").Width = 80
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Iva_Recuperable").DisplayIndex = 8

            .Columns("Valor_Otro_Impuesto").Visible = True
            .Columns("Valor_Otro_Impuesto").HeaderText = "Otro Impuesto"
            .Columns("Valor_Otro_Impuesto").Width = 80
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Valor_Otro_Impuesto").DisplayIndex = 9

            .Columns("Monto_Total").Visible = True
            .Columns("Monto_Total").HeaderText = "Total"
            .Columns("Monto_Total").Width = 80
            .Columns("Monto_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Total").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Total").DisplayIndex = 10

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Diferencia"
            .Columns("Diferencia").Width = 80
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Diferencia").DisplayIndex = 11

        End With


        For Each _Fila As DataGridViewRow In Grilla_01.Rows

            Dim _Libro_cp As String = _Fila.Cells("Libro").Value
            Dim _TipoDoc As Integer = _Fila.Cells("TipoDoc").Value

            If _TipoDoc = 61 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Amarillo
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

            If String.IsNullOrEmpty(_Libro_cp) Then
                _Fila.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf _Libro_cp.Contains(_Libro) Then
                _Fila.Cells("Libro").Style.ForeColor = Verde
            Else
                _Fila.Cells("Libro").Style.ForeColor = Rojo
            End If

        Next

    End Sub

    Sub Sb_Formato_Grilla_02()

        Dim _DisplayIndex = 0

        With Grilla_02

            .DataSource = _Inf_02_Solo_SII

            OcultarEncabezadoGrilla(Grilla_02, False)

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rut_Proveedor").Visible = True
            .Columns("Rut_Proveedor").HeaderText = "Rut Proveedor"
            .Columns("Rut_Proveedor").Width = 80
            .Columns("Rut_Proveedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Razon_Social").Visible = True
            .Columns("Razon_Social").HeaderText = "Razón Social"
            .Columns("Razon_Social").Width = 200 + 190 - 30
            .Columns("Razon_Social").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Folio").Visible = True
            .Columns("Folio").HeaderText = "Folio"
            .Columns("Folio").Width = 80
            .Columns("Folio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TPDF").Visible = True
            .Columns("TPDF").HeaderText = "PDF"
            .Columns("TPDF").Width = 30
            .Columns("TPDF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            'OccRef,FolioRef
            .Columns("TieneOccRef").Visible = True
            .Columns("TieneOccRef").HeaderText = "Tiene OC"
            .Columns("TieneOccRef").ToolTipText = "Tiene OC en referencia del XML"
            .Columns("TieneOccRef").Width = 40
            .Columns("TieneOccRef").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Docto").Visible = True
            .Columns("Fecha_Docto").HeaderText = "Fecha"
            .Columns("Fecha_Docto").Width = 80
            .Columns("Fecha_Docto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Docto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Exento").Visible = True
            .Columns("Monto_Exento").HeaderText = "Exento"
            .Columns("Monto_Exento").Width = 80
            .Columns("Monto_Exento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Exento").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Exento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Neto").Visible = True
            .Columns("Monto_Neto").HeaderText = "Neto"
            .Columns("Monto_Neto").Width = 80
            .Columns("Monto_Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Neto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Neto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Iva_Recuperable").Visible = True
            .Columns("Monto_Iva_Recuperable").HeaderText = "Iva"
            .Columns("Monto_Iva_Recuperable").Width = 80
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Iva_Recuperable").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valor_Otro_Impuesto").Visible = True
            .Columns("Valor_Otro_Impuesto").HeaderText = "Otro Impuesto"
            .Columns("Valor_Otro_Impuesto").Width = 80
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Valor_Otro_Impuesto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Total").Visible = True
            .Columns("Monto_Total").HeaderText = "Total"
            .Columns("Monto_Total").Width = 80
            .Columns("Monto_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Total").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Total").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

        For Each _Fila As DataGridViewRow In Grilla_02.Rows

            Dim _Libro_Sugerido As String = NuloPorNro(_Fila.Cells("Libro_Sugerido").Value, "")
            Dim _Folio = _Fila.Cells("Folio").Value
            Dim _Idmaeedo = _Fila.Cells("Idmaeedo").Value
            Dim _Idmaeedo_GRC = _Fila.Cells("Idmaeedo_GRC").Value

            If Not String.IsNullOrEmpty(_Libro_Sugerido) Then
                If _Libro_Sugerido.Contains(_Libro) Then
                    _Fila.Cells("Libro_Sugerido").Style.ForeColor = Verde
                Else
                    _Fila.Cells("Libro_Sugerido").Style.ForeColor = Rojo
                End If
            End If

            If _Folio = "155" Then
                Dim a = 1
            End If

            If Not Convert.ToBoolean(_Idmaeedo) And Convert.ToBoolean(_Idmaeedo_GRC) Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.GreenYellow
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.GreenYellow
                End If
            End If

            Dim _Libro_cp As String = _Fila.Cells("Libro").Value
            Dim _TipoDoc As Integer = _Fila.Cells("TipoDoc").Value

            If _TipoDoc = 61 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    If _Fila.DefaultCellStyle.BackColor <> Color.GreenYellow Then
                        _Fila.DefaultCellStyle.ForeColor = Amarillo
                    End If
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

        Next

    End Sub

    Sub Sb_Formato_Grilla_03()

        With Grilla_03

            .DataSource = _Inf_03_SII_Random_Otro_Mes

            OcultarEncabezadoGrilla(Grilla_03, False)

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = 0

            .Columns("Rut_Proveedor").Visible = True
            .Columns("Rut_Proveedor").HeaderText = "Rut Proveedor"
            .Columns("Rut_Proveedor").Width = 80
            .Columns("Rut_Proveedor").DisplayIndex = 1

            .Columns("Razon_Social").Visible = True
            .Columns("Razon_Social").HeaderText = "Razón Social"
            .Columns("Razon_Social").Width = 200
            .Columns("Razon_Social").DisplayIndex = 2

            .Columns("Folio").Visible = True
            .Columns("Folio").HeaderText = "Folio"
            .Columns("Folio").Width = 80
            .Columns("Folio").DisplayIndex = 3

            .Columns("Libro").Visible = True
            .Columns("Libro").HeaderText = "Libro"
            .Columns("Libro").Width = 100
            .Columns("Libro").DisplayIndex = 4

            .Columns("Fecha_Docto").Visible = True
            .Columns("Fecha_Docto").HeaderText = "Fecha"
            .Columns("Fecha_Docto").Width = 80
            .Columns("Fecha_Docto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Docto").DisplayIndex = 5

            .Columns("Monto_Exento").Visible = True
            .Columns("Monto_Exento").HeaderText = "Exento"
            .Columns("Monto_Exento").Width = 80
            .Columns("Monto_Exento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Exento").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Exento").DisplayIndex = 6

            .Columns("Monto_Neto").Visible = True
            .Columns("Monto_Neto").HeaderText = "Neto"
            .Columns("Monto_Neto").Width = 80
            .Columns("Monto_Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Neto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Neto").DisplayIndex = 7

            .Columns("Monto_Iva_Recuperable").Visible = True
            .Columns("Monto_Iva_Recuperable").HeaderText = "Iva"
            .Columns("Monto_Iva_Recuperable").Width = 80
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Iva_Recuperable").DisplayIndex = 8

            .Columns("Valor_Otro_Impuesto").Visible = True
            .Columns("Valor_Otro_Impuesto").HeaderText = "Otro Impuesto"
            .Columns("Valor_Otro_Impuesto").Width = 80
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Valor_Otro_Impuesto").DisplayIndex = 9

            .Columns("Monto_Total").Visible = True
            .Columns("Monto_Total").HeaderText = "Total"
            .Columns("Monto_Total").Width = 80
            .Columns("Monto_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Total").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Total").DisplayIndex = 10

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Diferencia"
            .Columns("Diferencia").Width = 80
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Diferencia").DisplayIndex = 11

        End With

        For Each _Fila As DataGridViewRow In Grilla_02.Rows

            Dim _TipoDoc As Integer = _Fila.Cells("TipoDoc").Value

            If _TipoDoc = 61 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Amarillo
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

        Next

    End Sub

    Sub Sb_Formato_Grilla_04()

        With Grilla_04

            .DataSource = _Inf_04_SII_Random_Direfencias

            OcultarEncabezadoGrilla(Grilla_04, False)

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = 0

            .Columns("Rut_Proveedor").Visible = True
            .Columns("Rut_Proveedor").HeaderText = "Rut Proveedor"
            .Columns("Rut_Proveedor").Width = 80
            .Columns("Rut_Proveedor").DisplayIndex = 1

            .Columns("Razon_Social").Visible = True
            .Columns("Razon_Social").HeaderText = "Razón Social"
            .Columns("Razon_Social").Width = 200
            .Columns("Razon_Social").DisplayIndex = 2

            .Columns("Folio").Visible = True
            .Columns("Folio").HeaderText = "Folio"
            .Columns("Folio").Width = 80
            .Columns("Folio").DisplayIndex = 3

            .Columns("Libro").Visible = True
            .Columns("Libro").HeaderText = "Libro"
            .Columns("Libro").Width = 100
            .Columns("Libro").DisplayIndex = 4

            .Columns("Fecha_Docto").Visible = True
            .Columns("Fecha_Docto").HeaderText = "Fecha"
            .Columns("Fecha_Docto").Width = 80
            .Columns("Fecha_Docto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Docto").DisplayIndex = 5

            .Columns("Monto_Exento").Visible = True
            .Columns("Monto_Exento").HeaderText = "Exento"
            .Columns("Monto_Exento").Width = 80
            .Columns("Monto_Exento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Exento").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Exento").DisplayIndex = 6

            .Columns("Monto_Neto").Visible = True
            .Columns("Monto_Neto").HeaderText = "Neto"
            .Columns("Monto_Neto").Width = 80
            .Columns("Monto_Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Neto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Neto").DisplayIndex = 7

            .Columns("Monto_Iva_Recuperable").Visible = True
            .Columns("Monto_Iva_Recuperable").HeaderText = "Iva"
            .Columns("Monto_Iva_Recuperable").Width = 80
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Iva_Recuperable").DisplayIndex = 8

            .Columns("Valor_Otro_Impuesto").Visible = True
            .Columns("Valor_Otro_Impuesto").HeaderText = "Otro Impuesto"
            .Columns("Valor_Otro_Impuesto").Width = 80
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Valor_Otro_Impuesto").DisplayIndex = 9

            .Columns("Monto_Total").Visible = True
            .Columns("Monto_Total").HeaderText = "Total"
            .Columns("Monto_Total").Width = 80
            .Columns("Monto_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Total").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Total").DisplayIndex = 10

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Diferencia"
            .Columns("Diferencia").Width = 80
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Diferencia").DisplayIndex = 11

        End With

        For Each _Fila As DataGridViewRow In Grilla_04.Rows

            Dim _Diferencia As Double = NuloPorNro(_Fila.Cells("Diferencia").Value, 0)
            Dim _TipoDoc As Integer = _Fila.Cells("TipoDoc").Value

            If CBool(_Diferencia) Then
                _Fila.Cells("Diferencia").Style.ForeColor = Rojo
            End If

            If _TipoDoc = 61 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Amarillo
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

        Next

    End Sub

    Sub Sb_Formato_Grilla_05()

        With Grilla_05

            .DataSource = _Inf_05_Solo_Random

            OcultarEncabezadoGrilla(Grilla_05, False)

            .Columns("TIDO").Visible = True
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").DisplayIndex = 0

            .Columns("RTEN").Visible = True
            .Columns("RTEN").HeaderText = "Rut Proveedor"
            .Columns("RTEN").Width = 80
            .Columns("RTEN").DisplayIndex = 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 200 + 190
            .Columns("NOKOEN").DisplayIndex = 2

            .Columns("NUDO").Visible = True
            .Columns("NUDO").HeaderText = "Folio"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").DisplayIndex = 3

            .Columns("LIBRO").Visible = True
            .Columns("LIBRO").HeaderText = "Libro"
            .Columns("LIBRO").Width = 100
            .Columns("LIBRO").DisplayIndex = 4

            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDO").DisplayIndex = 5

            '.Columns("VANEDO").Visible = True
            '.Columns("VANEDO").HeaderText = "Neto"
            '.Columns("VANEDO").Width = 80
            '.Columns("VANEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("VANEDO").DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns("VANEDO").DisplayIndex = 6

            .Columns("EXENTO").Visible = True
            .Columns("EXENTO").HeaderText = "Exento"
            .Columns("EXENTO").Width = 80
            .Columns("EXENTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("EXENTO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("EXENTO").DisplayIndex = 6

            .Columns("AFECTO").Visible = True
            .Columns("AFECTO").HeaderText = "Afecto"
            .Columns("AFECTO").Width = 80
            .Columns("AFECTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("AFECTO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("AFECTO").DisplayIndex = 7

            .Columns("VAIVDO").Visible = True
            .Columns("VAIVDO").HeaderText = "Iva"
            .Columns("VAIVDO").Width = 80
            .Columns("VAIVDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAIVDO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("VAIVDO").DisplayIndex = 8

            '.Columns("Monto_Iva_No_Recuperable").Visible = True
            '.Columns("Monto_Iva_No_Recuperable").HeaderText = "Iva N/R"
            '.Columns("Monto_Iva_No_Recuperable").Width = 80
            '.Columns("Monto_Iva_No_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Monto_Iva_No_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns("Monto_Iva_No_Recuperable").DisplayIndex = 8

            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").HeaderText = "Total"
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("VABRDO").DisplayIndex = 9

            '.Columns("Diferencia").Visible = True
            '.Columns("Diferencia").HeaderText = "Diferencia"
            '.Columns("Diferencia").Width = 80
            '.Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Diferencia").DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns("Diferencia").DisplayIndex = 10

        End With


        For Each _Fila As DataGridViewRow In Grilla_04.Rows

            Dim _Tido = _Fila.Cells("TIDO").Value

            If _Tido = "NCC" Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Amarillo
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

        Next

    End Sub

    Sub Sb_Formato_Grilla_06()

        With Grilla_06

            .DataSource = _Inf_06_Libro_Compras

            OcultarEncabezadoGrilla(Grilla_06, False)

            .Columns("TIDO").Visible = True
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").DisplayIndex = 0

            .Columns("RTEN").Visible = True
            .Columns("RTEN").HeaderText = "Rut Proveedor"
            .Columns("RTEN").Width = 80
            .Columns("RTEN").DisplayIndex = 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 200
            .Columns("NOKOEN").DisplayIndex = 2

            .Columns("NUDO").Visible = True
            .Columns("NUDO").HeaderText = "Folio"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").DisplayIndex = 3

            .Columns("LIBRO").Visible = True
            .Columns("LIBRO").HeaderText = "Libro"
            .Columns("LIBRO").Width = 100
            .Columns("LIBRO").DisplayIndex = 4

            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDO").DisplayIndex = 5

            .Columns("EXENTO").Visible = True
            .Columns("EXENTO").HeaderText = "Exento"
            .Columns("EXENTO").Width = 80
            .Columns("EXENTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("EXENTO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("EXENTO").DisplayIndex = 6

            .Columns("AFECTO").Visible = True
            .Columns("AFECTO").HeaderText = "Afecto"
            .Columns("AFECTO").Width = 80
            .Columns("AFECTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("AFECTO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("AFECTO").DisplayIndex = 7

            .Columns("VAIVDO").Visible = True
            .Columns("VAIVDO").HeaderText = "Iva"
            .Columns("VAIVDO").Width = 80
            .Columns("VAIVDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAIVDO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("VAIVDO").DisplayIndex = 8

            '.Columns("Monto_Iva_No_Recuperable").Visible = True
            '.Columns("Monto_Iva_No_Recuperable").HeaderText = "Iva N/R"
            '.Columns("Monto_Iva_No_Recuperable").Width = 80
            '.Columns("Monto_Iva_No_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Monto_Iva_No_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns("Monto_Iva_No_Recuperable").DisplayIndex = 8

            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").HeaderText = "Total"
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("VABRDO").DisplayIndex = 9

            '.Columns("Diferencia").Visible = True
            '.Columns("Diferencia").HeaderText = "Diferencia"
            '.Columns("Diferencia").Width = 80
            '.Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Diferencia").DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns("Diferencia").DisplayIndex = 10

        End With

        For Each _F01 As DataGridViewRow In Grilla_06.Rows

            Dim _Tido = _F01.Cells("TIDO").Value
            Dim _Idmaeedo_01 = _F01.Cells("IDMAEEDO").Value

            For Each _F02 As DataGridViewRow In Grilla_05.Rows

                Dim _Idmaeedo_02 = _F02.Cells("IDMAEEDO").Value

                If _Idmaeedo_01 = _Idmaeedo_02 Then
                    _F01.DefaultCellStyle.BackColor = Color.LightSalmon
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _F01.DefaultCellStyle.ForeColor = Color.Black
                    End If
                    Exit For
                End If

            Next

            If _Tido = "NCC" Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _F01.DefaultCellStyle.ForeColor = Amarillo
                Else
                    _F01.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

        Next

    End Sub

    Sub Sb_Actualizar_Totales_SII(_Tbl As DataTable)

        Dim _Neto As Double = NuloPorNro(_Tbl.Compute("Sum(Monto_Neto)", "Monto_Neto <> 0"), 0)
        Dim _Exento As Double = NuloPorNro(_Tbl.Compute("Sum(Monto_Exento)", "Monto_Exento <> 0"), 0)
        Dim _Valor_Otro_Impuesto As Double = NuloPorNro(_Tbl.Compute("Sum(Valor_Otro_Impuesto)", "Valor_Otro_Impuesto <> 0"), 0)

        Dim _Iva As Double = NuloPorNro(_Tbl.Compute("Sum(Monto_Iva_Recuperable)", "Monto_Iva_Recuperable <> 0"), 0)
        Dim _Total As Double = NuloPorNro(_Tbl.Compute("Sum(Monto_Total)", "Monto_Total <> 0"), 0)
        Dim _Diferencia As Double = NuloPorNro(_Tbl.Compute("Sum(Diferencia)", "Diferencia <> 0"), 0)

        Lbl_Total_Neto.Text = FormatCurrency(_Neto, 0)
        Lbl_Total_Exento.Text = FormatCurrency(_Exento, 0)
        Lbl_Total_Otros_Impuestos.Text = FormatCurrency(_Valor_Otro_Impuesto, 0)

        Lbl_Total_Iva.Text = FormatCurrency(_Iva, 0)

        Lbl_Total_Bruto.Text = FormatCurrency(_Total, 0)
        Lbl_Total_Diferencias.Text = FormatCurrency(_Diferencia, 0)

    End Sub

    Sub Sb_Actualizar_Totales_Random(_Tbl As DataTable)

        Dim _Neto As Double = NuloPorNro(_Tbl.Compute("Sum(AFECTO)", "AFECTO <> 0"), 0)
        Dim _Exento As Double = NuloPorNro(_Tbl.Compute("Sum(EXENTO)", "EXENTO <> 0"), 0)

        Dim _Iva As Double = NuloPorNro(_Tbl.Compute("Sum(VAIVDO)", "VAIVDO <> 0"), 0)
        Dim _Total As Double = NuloPorNro(_Tbl.Compute("Sum(VABRDO)", "VABRDO <> 0"), 0)


        Lbl_Total_Neto.Text = FormatCurrency(_Neto, 0)
        Lbl_Total_Exento.Text = FormatCurrency(_Exento, 0)
        Lbl_Total_Otros_Impuestos.Text = FormatCurrency(0, 0)
        Lbl_Total_Iva.Text = FormatCurrency(_Iva, 0)

        Lbl_Total_Bruto.Text = FormatCurrency(_Total, 0)
        Lbl_Total_Diferencias.Text = FormatCurrency(0, 0)

    End Sub

    Private Sub Sb_Tab_SelectedTabChanged(sender As System.Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs)
        Sb_Refrescar_Grillas()
    End Sub

    Sub Sb_Refrescar_Grillas()

        Btn_Cambiar_Libro.Visible = False

        Select Case Tab.SelectedTabIndex
            Case 0
                Sb_Actualizar_Totales_SII(_Inf_00_SII)
                Sb_Formato_Grilla_00()
            Case 1
                Sb_Actualizar_Totales_SII(_Inf_01_SII_y_Random)
                Sb_Formato_Grilla_01()
            Case 2
                Sb_Actualizar_Totales_SII(_Inf_02_Solo_SII)
                Sb_Formato_Grilla_02()
            Case 3
                Sb_Actualizar_Totales_SII(_Inf_03_SII_Random_Otro_Mes)
                Btn_Cambiar_Libro.Visible = CBool(_Inf_03_SII_Random_Otro_Mes.Rows.Count)
                Sb_Formato_Grilla_03()
            Case 4
                Sb_Actualizar_Totales_SII(_Inf_04_SII_Random_Direfencias)
                Sb_Formato_Grilla_04()
            Case 5
                Sb_Actualizar_Totales_Random(_Inf_05_Solo_Random)
                Sb_Formato_Grilla_05()
            Case 6
                Sb_Actualizar_Totales_Random(_Inf_06_Libro_Compras)
                Sb_Formato_Grilla_06()
        End Select

        Me.Refresh()

    End Sub

    Private Sub Btn_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Excel.Click

        Sb_ExportarListadoActualExcel(True)

    End Sub

    Sub Sb_ExportarListadoActualExcel(_MostrarSubMenu As Boolean)

        Select Case Tab.SelectedTabIndex
            Case 0
                ExportarTabla_JetExcel_Tabla(_Inf_00_SII, Me, "Inf_00_SII")
            Case 1
                ExportarTabla_JetExcel_Tabla(_Inf_01_SII_y_Random, Me, "Inf_01_SII_y_Random")
            Case 2
                If _MostrarSubMenu Then
                    ShowContextMenu(Menu_Contextual_ExportarExcel)
                Else
                    ExportarTabla_JetExcel_Tabla(_Inf_02_Solo_SII, Me, "Inf_02_Solo_SII")
                End If
            Case 3
                ExportarTabla_JetExcel_Tabla(_Inf_03_SII_Random_Otro_Mes, Me, "Inf_03_SII_Random_Otro_Mes")
            Case 4
                ExportarTabla_JetExcel_Tabla(_Inf_04_SII_Random_Direfencias, Me, "Inf_04_SII_Random_Direfencias")
            Case 5
                ExportarTabla_JetExcel_Tabla(_Inf_05_Solo_Random, Me, "Inf_05_Solo_Random")
            Case 6
                ExportarTabla_JetExcel_Tabla(_Inf_06_Libro_Compras, Me, "Inf_06_Libro_Compras")
        End Select

    End Sub

    Private Sub Btn_Cambiar_Libro_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cambiar_Libro.Click

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        For Each _Fila As DataRow In _Inf_03_SII_Random_Otro_Mes.Rows

            Dim _Idmaeedo = _Fila.Item("IDMAEEDO")
            Sb_Cambiar_Al_Libro_De_Compras(_Idmaeedo, _Libro)

        Next

        Sb_Actualizar_Grillas(0)
        Tab.SelectedTabIndex = 0
        Sb_Refrescar_Grillas()

        Me.Enabled = True
        Me.Cursor = Cursors.Default

        MessageBoxEx.Show(Me, "Los documentos se ingresaron al final del libro del periodo: " & _Periodo & "-" & _Mes,
                          "Cambiar documentos de libro", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Sub Sb_Cambiar_Al_Libro_De_Compras(_Idmaeedo As Integer, _Libro As String)

        'Dim _Num_Siguiente As String

        Dim _LibroEdo As String = _Sql.Fx_Trae_Dato("MAEEDO", "LIBRO", "IDMAEEDO = " & _Idmaeedo)
        Dim _SucLibro As String = Mid(_LibroEdo, 7, 3)

        Dim _Ult_Libro = _Sql.Fx_Trae_Dato("MAEEDO", "MAX(LIBRO)", "LIBRO LIKE '" & _Libro & "%' And LIBRO LIKE '%" & _SucLibro & "%'")

        Dim _Libro_Campo = Split(_Ult_Libro, " ", 2)
        Dim _Libro_Nex = numero_(CInt(_Libro_Campo(1)) + 1, 5)

        Dim _New_Libro = _Libro_Campo(0) & " " & _Libro_Nex

        Consulta_sql = "Update MAEEDO Set LIBRO = '" & _New_Libro & "'" & Space(1) &
                       "Where IDMAEEDO = " & _Idmaeedo & vbCrLf & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Compras_en_SII" & Space(1) &
                       "Set Libro = '" & _New_Libro & "' Where Idmaeedo = " & _Idmaeedo
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Grilla As DataGridView = sender
        Dim _Fila As DataGridViewRow = _Grilla.Rows(_Grilla.CurrentRow.Index)

        Dim _Id As Integer
        Dim _Libro As String
        Dim _Idmaeedo As Integer
        Dim _Idmaeedo_Sugerido As Integer
        Dim _Se_puede_actualizar As Boolean

        Dim _Cabeza = _Grilla.Columns(_Grilla.CurrentCell.ColumnIndex).Name

        Select Case Tab.SelectedTabIndex

            Case 0, 1, 3, 4

                _Id = _Fila.Cells("Id").Value
                _Libro = Trim(_Fila.Cells("Libro").Value)
                _Idmaeedo = NuloPorNro(_Fila.Cells("Idmaeedo").Value, 0)
                _Idmaeedo_Sugerido = NuloPorNro(_Fila.Cells("Idmaeedo_Sugerido").Value, 0)
                _Se_puede_actualizar = True

                Dim _Copiar As String = _Fila.Cells("Folio").Value
                Clipboard.SetText(_Copiar)

                If Tab.SelectedTabIndex = 0 And _Cabeza = "TPDF" Then
                    If _Fila.Cells("TPDF").Value = "Si" Then
                        Sb_Ver_PDF(_Fila)
                    Else
                        MessageBoxEx.Show(Me, "No hay archivo PDF adjunto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    Return
                End If

            Case 2

                Dim _Idmaeedo_GRC = _Fila.Cells("Idmaeedo_GRC").Value

                'If Convert.ToBoolean(_Idmaeedo_GRC) Then

                Dim _Folio = _Fila.Cells("Folio").Value
                Dim _TipoDoc = _Fila.Cells("TipoDoc").Value
                Dim _Rut_Proveedor = _Fila.Cells("Rut_Proveedor").Value

                Btn_Ver_GRC_Sugerida.Enabled = (Convert.ToBoolean(_Idmaeedo_GRC) And _TipoDoc <> 61)
                Btn_Crear_FCC_desde_GRC.Enabled = (Convert.ToBoolean(_Idmaeedo_GRC) And _TipoDoc <> 61)

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_ReccDet" & vbCrLf &
                               "Where TipoDTE = " & _TipoDoc & " And Folio = " & _Folio & " And RutEmisor = '" & _Rut_Proveedor & "'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Btn_VerXMLPDF.Enabled = Not (IsNothing(_Row))

                ShowContextMenu(Menu_Contextual_Solo_en_SII)
                Return

                'End If

            Case 5, 6

                _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        End Select

        If Not CBool(_Idmaeedo) Then

            If _Idmaeedo_Sugerido Then

                _Idmaeedo = _Idmaeedo_Sugerido

            End If

        End If

        If CBool(_Idmaeedo) Then

            Me.Enabled = False

            Dim _Folio_Cambiado As Boolean
            Dim _Row_Documento As DataRow

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.ShowDialog(Me)
            _Folio_Cambiado = Fm.Pro_Folio_Cambiado
            _Row_Documento = Fm.Pro_Row_Maeedo
            Fm.Dispose()

            If _Folio_Cambiado Then

                If _Se_puede_actualizar Then

                    Dim _Nudo As String = _Row_Documento.Item("NUDO")
                    _Idmaeedo = _Row_Documento.Item("IDMAEEDO")

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII" & Space(1) &
                                   "Set" & vbCrLf &
                                   "Idmaeedo = " & _Idmaeedo & "," &
                                   "Nudo = '" & _Nudo & "'," &
                                   "Libro = Libro_Sugerido," &
                                   "Idmaeedo_Sugerido = ''," &
                                   "Tido_Sugerido = ''," &
                                   "Nudo_Sugerido = ''," &
                                   "Libro_Sugerido = ''" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Sb_Actualizar_Grillas(2)
                Sb_Formato_Grilla_02()

            End If

            Me.Enabled = True

        Else

            MessageBoxEx.Show(Me, "No existe documento en Random de referecnia", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Txt_Descripcion.KeyDown

        If e.KeyValue = Keys.Enter Then

            Sb_Actualizar_Grillas(Tab.SelectedTabIndex)
            Sb_Refrescar_Grillas()

        End If

    End Sub

    Private Sub Btn_Actualizar_DTE_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_DTE.Click

        Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        '_Ubic_Archivo = "D:\OneDrive\Documentos\Empresas\Sierralta\Hefesto_DTE\CONFIGURACION\Salida\" & RutEmpresa & "\" & _Periodo

        If System.IO.File.Exists(_Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe") Then 'Application.StartupPath & "\BakApp_Demonio.exe") Then

            Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
            Dim _Ejecutar As String = _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe" & Space(1) & RutEmpresa & Space(1) & _Periodo

            Try
                Shell(_Ejecutar, AppWinStyle.NormalFocus, False)
            Catch ex As Exception
                MessageBoxEx.Show(Me,
                        ex.Message, "Libro de compras...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End Try

        Else

            MessageBoxEx.Show(Me,
                        "No se encontro el archivo HEFESTO_LIBROS.exe en el directorio (" & _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA)",
                        "Hefesto_DTE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

    End Sub

    Private Sub Btn_Ver_GRC_Sugerida_Click(sender As Object, e As EventArgs) Handles Btn_Ver_GRC_Sugerida.Click

        Dim _Fila As DataGridViewRow = Grilla_02.Rows(Grilla_02.CurrentRow.Index)
        Dim _Idmaeedo_GRC = _Fila.Cells("Idmaeedo_GRC").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo_GRC, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Crear_FCC_desde_GRC_Click(sender As Object, e As EventArgs) Handles Btn_Crear_FCC_desde_GRC.Click

        Dim _Fila As DataGridViewRow = Grilla_02.Rows(Grilla_02.CurrentRow.Index)

        Dim _Tido = "FCC"
        Dim _Id = _Fila.Cells("Id").Value
        Dim _CampoPrecio As String

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Compras_en_SII Where Id = " & _Id
        Dim _Row_DTE As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Endo = _Row_DTE.Item("Endo")
        Dim _Nudo = _Row_DTE.Item("Nudo")
        Dim _Fecha_Emision As DateTime = _Row_DTE.Item("Fecha_Docto")
        Dim _Razon_Social = _Row_DTE.Item("Razon_Social")

        Dim _Idmaeedo As Integer

        If True Then
            ' Neto
            _CampoPrecio = "PPPRNE"
        Else
            ' Bruto
            _CampoPrecio = "PPPRBR"
        End If

        Consulta_sql = "Select * From MAEEDO Where TIDO = 'GRC' And NUDO = '" & _Nudo & "' And ENDO = '" & _Endo & "'"
        Dim _Row_GRC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_GRC) Then

            Me.Enabled = False

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.Pro_Texto = "CREANDO DOCUMENTO, POR FAVOR ESPERE..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()

            Try

                _Idmaeedo = _Row_GRC.Item("IDMAEEDO")
                _Nudo = _Row_GRC.Item("NUDO")

                Consulta_sql = "SELECT * FROM MAEEDO Where IDMAEEDO = " & _Idmaeedo & "
                        SELECT *,CASE WHEN UDTRPR = 1 THEN CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 END AS 'Cantidad',
                        CAPRCO1-CAPREX1 AS 'CantUd1_Dori',CAPRCO2-CAPREX2 AS 'CantUd2_Dori',
                        CASE WHEN UDTRPR = 1 THEN " & _CampoPrecio & " ELSE " & _CampoPrecio & "*RLUDPR END AS 'Precio',
                        0 As Id_Oferta,
                        '' As Oferta,
                        0 As Es_Padre_Oferta,
                        0 As Padre_Oferta,
                        0 As Hijo_Oferta,
                        0 As Cantidad_Oferta,
                        0 As Porcdesc_Oferta
                        FROM MAEDDO  WITH ( NOLOCK ) 
                        Where IDMAEEDO = " & _Idmaeedo & "  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                        ORDER BY IDMAEEDO,IDMAEDDO 
                        SELECT * FROM MAEIMLI
                        Where IDMAEEDO = " & _Idmaeedo & " 
                        SELECT * FROM MAEDTLI
                        Where IDMAEEDO = " & _Idmaeedo & " 
                        SELECT TOP 1 * FROM MAEEDOOB Where IDMAEEDO = " & _Idmaeedo

                'Falta revisar el campo SUBTIDO, ya que al parecer se guardan datos dependiendo del tipo de FCC por ejemplo si tiene derecho a credito fiscal
                'Falta campo FECHATRIB = Fecha de ingreso

                ' SUBTIDO
                '-- 001 Sin derecho a credito fiscal y Sin documento contiene activo fijo
                '-- 000 Documento contiene activo fijo y Sin derecho a credito fiscal
                '-- 101 Conderecho a credito fiscal y documento contiene activo fijo
                '-- 100 Con derecho a credito fiscal y sin documento contiene activo fijo
                '-- '' -- No incluye este documento en el libro de compras 

                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                Dim Fm_Post As New Frm_Formulario_Documento(_Tido, csGlobales.Enum_Tipo_Documento.Compra, False)
                Fm_Post.Pro_SubTido = "100"
                Fm_Post.Sb_Limpiar(Modalidad)
                Fm_Post.Pro_Nudo = _Nudo
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, False)
                Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, False)
                Dim _Idmaeedo_FCC = Fm_Post.Pro_Idmaeedo
                Fm_Post.Dispose()

                If Convert.ToBoolean(_Idmaeedo_FCC) Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set Idmaeedo = " & _Idmaeedo_FCC & ",Idmaeedo_GRC = 0 Where Id = " & _Id

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set Libro = LIBRO, Vanedo = VANEDO,Vaivdo = VAIVDO,Vabrdo = VABRDO
                                    From MAEEDO Edo 
                                    Inner Join " & _Global_BaseBk & "Zw_Compras_en_SII Sii On Edo.IDMAEEDO = Sii.Idmaeedo
                                    Where Idmaeedo = " & _Idmaeedo_FCC
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_FCC
                        Dim _Row_FCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Libro As String = _Row_FCC.Item("LIBRO")
                        Dim _Feemdo As DateTime = _Row_FCC.Item("FEEMDO")

                        Fm_Espera.Dispose()
                        Fm_Espera = Nothing

                        MessageBoxEx.Show(Me, "Proveedor: " & _Razon_Social & vbCrLf & vbCrLf &
                                          "Factura Nro: " & _Nudo & vbCrLf &
                                          "Fecha Emisión: " & FormatDateTime(_Feemdo, DateFormat.ShortDate) & vbCrLf &
                                          "Corr. Libro: " & _Libro,
                                          "Documento incorporado correctamente al libro de compras.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

            Catch ex As Exception

                MessageBoxEx.Show(Me, ex.Message, "Problema al crear el documento", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Finally

                If Not Fm_Espera Is Nothing Then Fm_Espera.Dispose()
                Me.Enabled = True
                Sb_Actualizar_Grillas(Tab.SelectedTabIndex)
                Sb_Refrescar_Grillas()

            End Try

        Else

            MessageBoxEx.Show(Me, "No se encontro coincidencia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

    End Sub

    Private Sub Btn_VerXMLPDF_Click(sender As Object, e As EventArgs) Handles Btn_VerXMLPDF.Click

        Dim _Fila As DataGridViewRow = Grilla_02.Rows(Grilla_02.CurrentRow.Index)
        Sb_Ver_PDF(_Fila)

    End Sub

    Sub Sb_Ver_PDF(_Fila As DataGridViewRow)

        Dim _Folio = _Fila.Cells("Folio").Value
        Dim _TipoDoc = _Fila.Cells("TipoDoc").Value
        Dim _Rut_Proveedor = _Fila.Cells("Rut_Proveedor").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_ReccDet" & vbCrLf &
                       "Where TipoDTE = " & _TipoDoc & " And Folio = " & _Folio & " And RutEmisor = '" & _Rut_Proveedor & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            MessageBoxEx.Show(Me, "No se encontro el archivo PDF", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Xml As String = _Row.Item("Xml")

        Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\DTE\Descargas"

        If Not Directory.Exists(_Directorio) Then
            Directory.CreateDirectory(_Directorio)
        End If

        Dim _NombreArchivo As String = _Folio & "_" & _TipoDoc & _Rut_Proveedor '& ".XML"
        Dim _Archivo As String = _Directorio & "\" & _NombreArchivo.Trim

        Dim oSW As New StreamWriter(_Archivo & ".XML")
        oSW.WriteLine(_Xml)
        oSW.Close()

        Dim Ds_Xml As New DataSet
        Ds_Xml.ReadXml(_Archivo & ".XML")

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF")
        End If

        Dim _File As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _NombreArchivo & ".pdf"

        If Not El_Archivo_Esta_Abierto(_File) Then

            Dim _RecepXMLCmp_MarcaAgua As String = _Global_Row_Configuracion_General.Item("RecepXMLCmp_MarcaAgua")
            Dim _RecepXMLCmp_ImpMarcaAgua As Boolean = Not String.IsNullOrEmpty(_RecepXMLCmp_MarcaAgua)

            Dim Cl_Dte2XmlIPDF As New Cl_Dte2XmlPDF
            Cl_Dte2XmlIPDF.Sb_Crear_PDF2XML(Me, Ds_Xml, _NombreArchivo, _RecepXMLCmp_MarcaAgua, _RecepXMLCmp_ImpMarcaAgua)
            File.Delete(_Archivo & ".XML")

        Else

            MessageBoxEx.Show(Me, "El Archivo se encuentra abierto", "DTE2PDF", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Excel_ListadoActual_Click(sender As Object, e As EventArgs) Handles Btn_Excel_ListadoActual.Click
        Sb_ExportarListadoActualExcel(False)
    End Sub

    Private Sub Btn_Excel_ExportarProvSinPDF_Click(sender As Object, e As EventArgs) Handles Btn_Excel_ExportarProvSinPDF.Click

        Consulta_sql = "Select *," & vbCrLf &
                        "Case When Isnull((Select Top 1 Id From " & _Global_BaseBk & "Zw_DTE_ReccDet Z1" & vbCrLf &
                        "Where Cmp.Rut_Proveedor = Z1.RutEmisor And Z1.Folio = Cmp.Folio And Cmp.TipoDoc = Z1.TipoDTE),0) = 0 Then 'No' Else 'Si' End As TPDF" & vbCrLf &
                        "Into #Paso" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp" & vbCrLf &
                        "Where Libro = '' And Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
                        "And Tido+Nudo+Endo+Libro+Rut_Proveedor+Razon_Social+Folio+STR(Monto_Total) LIKE '%%'" &
                         vbCrLf &
                        "Select Distinct Rut_Proveedor As 'Rut',Razon_Social As 'Razon Social',FOEN As 'Telefono'," & vbCrLf &
                        "(Select COUNT(*) From #Paso Ps2 Where Ps1.Rut_Proveedor = Ps2.Rut_Proveedor) As 'Documentos'," & vbCrLf &
                        "(Select COUNT(*) From #Paso Ps2 Where Ps1.Rut_Proveedor = Ps2.Rut_Proveedor And TPDF = 'Si') As 'Con PDF'," & vbCrLf &
                        "(Select COUNT(*) From #Paso Ps2 Where Ps1.Rut_Proveedor = Ps2.Rut_Proveedor And TPDF = 'No') As 'Sin PDF' " & vbCrLf &
                        "From #Paso Ps1" & vbCrLf &
                        "Left Join MAEEN On KOEN = Endo" & vbCrLf &
                        "Where TPDF = 'No'" & vbCrLf &
                        "Order by Rut_Proveedor" & vbCrLf &
                        "Drop Table #Paso"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "PRoveedores Sin PDF")

    End Sub
End Class
