Imports DevComponents.DotNetBar
Imports MySql.Data.Authentication

Public Class Frm_ComprasSinRecepcionar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String

    Dim _Tbl_Stock As DataTable
    Dim _Tbl_Documentos As DataTable

    Public Property Tido As String
    Public Property SegundaUnidad As Boolean

    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigo = _Codigo

        Sb_Formato_Generico_Grilla(Grilla_Stock, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ComprasSinRecepcionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Rdb_Ud1.Checked = Not SegundaUnidad
        Rdb_Ud2.Checked = SegundaUnidad

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Stock.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Rdb_Ud1.CheckedChanged, AddressOf Rdb_Ud_CheckedChanged
        AddHandler Rdb_Ud2.CheckedChanged, AddressOf Rdb_Ud_CheckedChanged

    End Sub
    Sub Sb_Actualizar_Grilla()

        If Tido = "NVI" Then

            Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* From TABBO" & vbCrLf &
                           "Where EMPRESA+KOSU+KOBO" & vbCrLf &
                           "In (" & vbCrLf &
                           "Select SUBSTRING(CodPermiso, 5, 10)" & vbCrLf &
                           "From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                           "Where CodUsuario = '" & FUNCIONARIO & "'" & Space(1) &
                           "And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega_NVI'))" & vbCrLf &
                           "Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')"

        Else

            Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* From TABBO" & vbCrLf &
                           "Where EMPRESA+KOSU+KOBO" & vbCrLf &
                           "In (" & vbCrLf &
                           "Select SUBSTRING(CodPermiso, 3, 10)" & vbCrLf &
                           "From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                           "Where CodUsuario = '" & FUNCIONARIO & "'" & Space(1) &
                           "And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega'))" & vbCrLf &
                           "Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')"

        End If

        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Bodegas, "", "Cod", False, False, "'")


        Consulta_sql = "Select Mst.*,Mst.KOSU+'-'+Mst.KOBO As 'SUC_BOD',Tb.NOKOBO From MAEST Mst" & vbCrLf &
                       "Left Join TABBO Tb On Mst.EMPRESA = Tb.EMPRESA And Mst.KOSU = Tb.KOSU And Mst.KOBO = Tb.KOBO" & vbCrLf &
                       "Where KOPR = '" & _Codigo & "' And Mst.EMPRESA+Mst.KOSU+Mst.KOBO In " & _Filtro
        _Tbl_Stock = _Sql.Fx_Get_Tablas(Consulta_sql)


        Dim _Unidad As Integer

        If Rdb_Ud1.Checked Then
            _Unidad = Rdb_Ud1.Tag
        Else
            _Unidad = Rdb_Ud2.Tag
        End If

        With Grilla_Stock

            .DataSource = _Tbl_Stock

            OcultarEncabezadoGrilla(Grilla_Stock, True)

            .Columns("SUC_BOD").HeaderText = "Suc-Bod"
            .Columns("SUC_BOD").Width = 70
            .Columns("SUC_BOD").Visible = True

            .Columns("STFI" & _Unidad).HeaderText = "Stock Físico"
            .Columns("STFI" & _Unidad).Width = 80
            .Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI" & _Unidad).DefaultCellStyle.Format = "##,#0"
            .Columns("STFI" & _Unidad).ToolTipText = "Stock Físico"
            .Columns("STFI" & _Unidad).Visible = True

            .Columns("STDV" & _Unidad).HeaderText = "Devengado"
            .Columns("STDV" & _Unidad).Width = 75
            .Columns("STDV" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STDV" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("STDV" & _Unidad).ToolTipText = "Facturado al cliente sin entregar físicamente, pendiente de generar guía de despacho"
            .Columns("STDV" & _Unidad).Visible = True

            .Columns("DESPNOFAC" & _Unidad).HeaderText = "Desp.S/Fac"
            .Columns("DESPNOFAC" & _Unidad).Width = 75
            .Columns("DESPNOFAC" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DESPNOFAC" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("DESPNOFAC" & _Unidad).ToolTipText = "Despachado con guía que aún no han sido facturadas"
            .Columns("DESPNOFAC" & _Unidad).Visible = True

            .Columns("STOCNV" & _Unidad).HeaderText = "Comprom."
            .Columns("STOCNV" & _Unidad).Width = 75
            .Columns("STOCNV" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STOCNV" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("STOCNV" & _Unidad).ToolTipText = "Notas de venta pendiente [NVV][NVI]"
            .Columns("STOCNV" & _Unidad).Visible = True

            .Columns("STDV" & _Unidad & "C").HeaderText = "Comp.N/Rec"
            .Columns("STDV" & _Unidad & "C").Width = 75
            .Columns("STDV" & _Unidad & "C").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STDV" & _Unidad & "C").DefaultCellStyle.Format = "###,#0"
            .Columns("STDV" & _Unidad & "C").ToolTipText = "Facturas de compra que no han movido Stock físico, aún falta la guía de recepción de mercadería"
            .Columns("STDV" & _Unidad & "C").Visible = True

            .Columns("RECENOFAC" & _Unidad).HeaderText = "Rece.S/Fac"
            .Columns("RECENOFAC" & _Unidad).Width = 75
            .Columns("RECENOFAC" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RECENOFAC" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("RECENOFAC" & _Unidad).ToolTipText = "Guías de proveedores que aún no han sido facturadas"
            .Columns("RECENOFAC" & _Unidad).Visible = True

            .Columns("STOCNV" & _Unidad & "C").HeaderText = "Pedido"
            .Columns("STOCNV" & _Unidad & "C").Width = 75
            .Columns("STOCNV" & _Unidad & "C").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STOCNV" & _Unidad & "C").DefaultCellStyle.Format = "###,#0"
            .Columns("STOCNV" & _Unidad & "C").ToolTipText = "Ordenes de compra pendientes [OCI][OCC]"
            .Columns("STOCNV" & _Unidad & "C").Visible = True

            Return

            For Each _Fila As DataGridViewRow In .Rows

                Dim _SUC_BOD = _Fila.Cells("SUC_BOD").Value

                If _SUC_BOD = "Total" Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Gold
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                End If

            Next

            For Each _Fila As DataGridViewRow In Grilla_Stock.Rows

                Dim _Suc_Bod = Trim(_Fila.Cells("SUC_BOD").Value)

                'Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
                'Dim _Bodega As String = _Fila.Cells("Bodega").Value

                If String.IsNullOrEmpty(_Suc_Bod) Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.BackColor = Color.Black
                        _Fila.DefaultCellStyle.ForeColor = Color.Gold
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.Gold
                    End If
                Else
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.BackColor = Color.Black
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.White
                    End If
                End If

                If _Suc_Bod = "Total" Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Gold
                        Exit For
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                End If

                For Each Columna As DataGridViewColumn In Grilla_Stock.Columns
                    Dim _Columna As String = Columna.Name
                    If _Columna.Contains("1") Or _Columna.Contains("2") Then

                        Dim _Valor As Double = _Fila.Cells(_Columna).Value

                        Dim _Color_Cero As Color = Color.LightGray
                        Dim _Color_Positivo As Color = Color.Black
                        Dim _Color_Negativo As Color = Rojo

                        If Global_Thema = Enum_Themas.Oscuro Then
                            _Color_Cero = Color.FromArgb(60, 60, 60)
                            _Color_Positivo = Verde
                        End If

                        If _Valor = 0 Then
                            _Fila.Cells(_Columna).Style.ForeColor = _Color_Cero
                        ElseIf _Valor < 0 Then
                            _Fila.Cells(_Columna).Style.ForeColor = Rojo
                        ElseIf _Valor > 0 Then
                            _Fila.Cells(_Columna).Style.ForeColor = _Color_Positivo
                        End If

                    End If
                Next

            Next

        End With


    End Sub

    Private Sub Grilla_Stock_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Stock.CellEnter

        Dim _Fila As DataGridViewRow = Grilla_Stock.CurrentRow

        Dim _Empresa As String = _Fila.Cells("EMPRESA").Value
        Dim _Sucursal As String = _Fila.Cells("KOSU").Value
        Dim _Bodega As String = _Fila.Cells("KOBO").Value

        Dim _Ud As Integer

        If Rdb_Ud1.Checked Then
            _Ud = Rdb_Ud1.Tag
        Else
            _Ud = Rdb_Ud2.Tag
        End If

        Consulta_sql = "Select *,CAPRCO" & _Ud & "-CAPREX" & _Ud & " As SALDO_Ud" & _Ud & vbCrLf &
                       "From MAEDDO Where TIDO In ('FCC','OCC') And KOPRCT = '" & _Codigo & "' And ESLIDO = ''" & vbCrLf &
                       "And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'"
        _Tbl_Documentos = _Sql.Fx_Get_Tablas(Consulta_sql)


        With Grilla_Detalle

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla_Detalle, False)

            Dim _DisplayIndex = 0

            .Columns("TIDO").Width = 35
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 95
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD0" & _Ud & "PR").Width = 30
            .Columns("UD0" & _Ud & "PR").HeaderText = "UD"
            .Columns("UD0" & _Ud & "PR").Visible = True
            .Columns("UD0" & _Ud & "PR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("NOKOPR").Width = 195
            '.Columns("NOKOPR").HeaderText = "Descripción"
            '.Columns("NOKOPR").Visible = True

            .Columns("CAPRCO" & _Ud).Width = 70
            .Columns("CAPRCO" & _Ud).HeaderText = "Cant."
            .Columns("CAPRCO" & _Ud).ToolTipText = "Cantidad del documento"
            .Columns("CAPRCO" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO" & _Ud).DefaultCellStyle.Format = "###,##"
            .Columns("CAPRCO" & _Ud).Visible = True
            .Columns("CAPRCO" & _Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPREX" & _Ud).Width = 70
            .Columns("CAPREX" & _Ud).HeaderText = "Recep."
            .Columns("CAPRCO" & _Ud).ToolTipText = "Cantidad recepcionada"
            .Columns("CAPREX" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX" & _Ud).DefaultCellStyle.Format = "###,##"
            .Columns("CAPREX" & _Ud).Visible = True
            .Columns("CAPREX" & _Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SALDO_Ud" & _Ud).Width = 70
            .Columns("SALDO_Ud" & _Ud).HeaderText = "Pend."
            .Columns("SALDO_Ud" & _Ud).ToolTipText = "Cantidad de saldo pendiente"
            .Columns("SALDO_Ud" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_Ud" & _Ud).DefaultCellStyle.Format = "###,##"
            .Columns("SALDO_Ud" & _Ud).Visible = True
            .Columns("SALDO_Ud" & _Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").Width = 80
            .Columns("FEEMLI").HeaderText = "F.Emisión"
            .Columns("FEEMLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FEEMLI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEERLI").Width = 80
            .Columns("FEERLI").HeaderText = "F.Recepción"
            .Columns("FEERLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FEERLI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEERLI").Visible = True
            .Columns("FEERLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("MODO").HeaderText = "TM."
            '.Columns("MODO").Visible = True
            '.Columns("MODO").Width = 30
            ''.Columns("MODO").DisplayIndex = 11

            '.Columns("PPPRNE").Width = 65
            '.Columns("PPPRNE").HeaderText = "Precio"
            '.Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("PPPRNE").DefaultCellStyle.Format = "###,##.##"
            '.Columns("PPPRNE").Visible = True
            ''.Columns("PPPRNE").DisplayIndex = 12

            '.Columns("STFI" & _Ud).Width = 70
            '.Columns("STFI" & _Ud).HeaderText = "Stock"
            '.Columns("STFI" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("STFI" & _Ud).DefaultCellStyle.Format = "###,##"
            '.Columns("STFI" & _Ud).Visible = True

        End With

    End Sub

    Private Sub Rdb_Ud_CheckedChanged(sender As Object, e As EventArgs)
        If sender.Checked Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_ComprasSinRecepcionar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
