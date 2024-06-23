Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Ranking_Resultado

    Dim _TblProductos As DataTable
    Dim _Ranking_Actual As Boolean

    Dim _SQL As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CodTablaRanking As String
    Dim _TblRanking_Origen As String
    Dim _TblResultado As DataTable

    Public Sub New(ByVal TblProductos As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _TblProductos = TblProductos

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Courier New", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_Ranking_Resultado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Lbl_Estatus.Text = String.Empty

        Consulta_sql = My.Resources.Consultas.Ranking_productos_Resultado
        _TblResultado = _SQL.Fx_Get_DataTable(Consulta_sql)



        Actualizar_Datos_Grilla()

        Dim Fm As New Frm_Ranking_Resultado_Clasificar(_TblProductos, _TblResultado)
        Fm.Sb_Actualizar_Star()
        Fm.Dispose()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click

        ExportarTabla_JetExcel_Tabla(_TblProductos, Me, "Ranking Productos")

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub




    Private Sub BtnClasificarRk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClasificarRk.Click

        If Fx_Tiene_Permiso(Me, "Inf00008") Then

            For Each _Fila As DataGridViewRow In Grilla.Rows
                ' _Fila.Cells("Star2").Style.BackColor = Color.Blue
                _Fila.Cells("Star2").Style.ForeColor = Color.Black
            Next

            Dim Fm As New Frm_Ranking_Resultado_Clasificar(_TblProductos, _TblResultado)
            Fm.Pro_Grilla_Productos = Grilla
            Fm.ShowDialog(Me)
            Fm.Dispose()
            'Campo_Clas = Fm.Campo_Clas
            '_CodTablaRanking = Fm._CodTablaRanking
            Me.Text = "Ranking de productos, Tabla de clasificación productos estrella" ' & _CodTablaRanking


            'Else
            '   MessageBoxEx.Show(Me, "Debe configurar una tabla para poder procesar los datos", _
            '                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            'End If
        End If
    End Sub




    Sub Actualizar_Datos_Grilla()

        'Consulta_sql = "Select  Codigo,Descripcion,Ranking_Top,Rk_Presencia,Rk_Cantidad," & vbCrLf & _
        '              "Rk_Margen,Rk_Precio,Pc_Presencia,Pc_Cantidad,Pc_Margen,Pc_Precio" & vbCrLf & _
        '              "From " & TablaRanking_Paso & vbCrLf & _
        '              "Order by Ranking_Top"

        'Consulta_sql = "Select * From " & TablaRanking_Paso & vbCrLf & _
        '              "Order by Ranking_Top"

        With Grilla
            .DataSource = _TblProductos '_SQL.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla)

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = 0

            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = 1

            .Columns("Ranking_Top").Width = 100
            .Columns("Ranking_Top").HeaderText = "Rk Top"
            .Columns("Ranking_Top").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ranking_Top").DefaultCellStyle.Format = "###,##.##"
            .Columns("Ranking_Top").Visible = True
            .Columns("Ranking_Top").DisplayIndex = 2

            .Columns("Rk_Presencia").Width = 100
            .Columns("Rk_Presencia").HeaderText = "Rk Presencia"
            .Columns("Rk_Presencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rk_Presencia").DefaultCellStyle.Format = "###,##.##"
            .Columns("Rk_Presencia").Visible = True
            .Columns("Rk_Presencia").DisplayIndex = 3

            .Columns("Rk_Cantidad").Width = 100
            .Columns("Rk_Cantidad").HeaderText = "Rk Cantidad"
            .Columns("Rk_Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rk_Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Rk_Cantidad").Visible = True
            .Columns("Rk_Cantidad").DisplayIndex = 4

            .Columns("Rk_Precio").Width = 100
            .Columns("Rk_Precio").HeaderText = "Rk Precio"
            .Columns("Rk_Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rk_Precio").DefaultCellStyle.Format = "###,##.##"
            .Columns("Rk_Precio").Visible = True
            .Columns("Rk_Precio").DisplayIndex = 5

            .Columns("Rk_Margen").Width = 100
            .Columns("Rk_Margen").HeaderText = "Rk Margen"
            .Columns("Rk_Margen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rk_Margen").DefaultCellStyle.Format = "###,##.##"
            .Columns("Rk_Margen").Visible = True
            .Columns("Rk_Margen").DisplayIndex = 6

            .Columns("Presencia").Width = 100
            .Columns("Presencia").HeaderText = "Nro. Presencia"
            .Columns("Presencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Presencia").DefaultCellStyle.Format = "###,##.##"
            .Columns("Presencia").Visible = True
            .Columns("Presencia").DisplayIndex = 7

            .Columns("TotalCantid").Width = 100
            .Columns("TotalCantid").HeaderText = "Total Cant."
            .Columns("TotalCantid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCantid").DefaultCellStyle.Format = "###,##.##"
            .Columns("TotalCantid").Visible = True
            .Columns("TotalCantid").DisplayIndex = 8

            .Columns("TotalPrecio").Width = 100
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True
            .Columns("TotalPrecio").DisplayIndex = 9

            .Columns("Total_Mrg").Width = 100
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True
            .Columns("Total_Mrg").DisplayIndex = 10

            .Columns("Star2").Width = 100
            .Columns("Star2").HeaderText = "Estrellas"
            .Columns("Star2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Star2").Visible = True
            .Columns("Star2").DisplayIndex = 11

            ' .Columns("BtnImagen").Visible = True
            ' .Columns("BtnImagen").HeaderText = "Star"
            ' .Columns("BtnImagen").Width = 50
            ' .Columns("BtnImagen").DisplayIndex = 11

        End With


        'For Each _Fila As DataGridViewRow In Grilla.Rows

        '_Fila.Cells.A(DefaultCellStyle.Font = Fuente) 'Font("Tahoma", 7)
        '.AlternatingRowsDefaultCellStyle.Font = Fuente 'Font("Tahoma", 7)

        '_Fila.Cells("Star2").Style.Font = New Font("Courier New", 10, FontStyle.Bold)
        '_Fila.Cells("Star2").Style.ForeColor = Color.Yellow

        'Next

    End Sub


    Private Sub BtnGrabarRankingTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabarRankingTop.Click

        If Fx_Tiene_Permiso(Me, "Inf00007") Then

            Try

                Grilla.Enabled = False
                BtnxSalir.Enabled = False
                BtnClasificarRk.Enabled = False
                BtnGrabarRankingTop.Enabled = False
                BtnCancelar.Enabled = False
            
                'If Not String.IsNullOrEmpty(Campo_Clas) Then

                'Dim dlg As System.Windows.Forms.DialogResult = _
                'MessageBoxEx.Show(Me, _
                '                  "¿Esta seguro de grabar los nuevos datos de clasificación de Ranking en el maestro de productos en el campo de " & _CodTablaRanking & "?" & vbCrLf & _
                '                  "Esto reemplazara el antiguo campo de Ranking", _
                '                  "Grabar datos", MessageBoxButtons.YesNo)

                'If dlg = System.Windows.Forms.DialogResult.Yes Then

                Consulta_sql = String.Empty

                ProgressBarX1.Maximum = _TblProductos.Rows.Count

                Dim _Cant_Productos = _TblProductos.Rows.Count

                Consulta_sql = "Truncate Table " & _Global_BaseBk & "Zw_Prod_Ranking" & vbCrLf & vbCrLf & _
                              Consulta_sql
                _SQL.Ej_consulta_IDU(Consulta_sql)

                For Each _Fila As DataRow In _TblProductos.Rows

                    System.Windows.Forms.Application.DoEvents()

                    Dim _Codigo = _Fila.Item("Codigo")
                    Dim _Descripcion = Trim(_Fila.Item("Descripcion"))
                    Dim _Puntos_Rk = De_Num_a_Tx_01(_Fila.Item("Puntos_Rk"), False, 5)
                    Dim _Ranking_Top = De_Num_a_Tx_01(_Fila.Item("Ranking_Top"), False, 5)
                    Dim _Rk_Presencia = De_Num_a_Tx_01(_Fila.Item("Rk_Presencia"), False, 5)
                    Dim _Rk_Cantidad = De_Num_a_Tx_01(_Fila.Item("Rk_Cantidad"), False, 5)
                    Dim _Rk_Precio = De_Num_a_Tx_01(_Fila.Item("Rk_Precio"), False, 5)
                    Dim _Rk_Margen = De_Num_a_Tx_01(_Fila.Item("Rk_Margen"), False, 5)
                    Dim _Bv = De_Num_a_Tx_01(_Fila.Item("Bv"), False, 5)
                    Dim _Fv = De_Num_a_Tx_01(_Fila.Item("Fv"), False, 5)
                    Dim _Gv = De_Num_a_Tx_01(_Fila.Item("Gv"), False, 5)
                    Dim _Nc = De_Num_a_Tx_01(_Fila.Item("Nc"), False, 5)
                    Dim _Otro = De_Num_a_Tx_01(_Fila.Item("Otro"), False, 5)
                    Dim _Presencia = De_Num_a_Tx_01(_Fila.Item("Presencia"), False, 5)

                    Dim _Top_Ranking = _Fila.Item("Top_Ranking")
                    Dim _Top_Presencia = _Fila.Item("Top_Presencia")
                    Dim _Top_Cantidad = _Fila.Item("Top_Cantidad")
                    Dim _Top_Precio = _Fila.Item("Top_Precio")
                    Dim _Top_Margen = _Fila.Item("Top_Margen")
                    Dim _Cod_Clas = _Fila.Item("Cod_Clas")
                    Dim _Clasificacion = _Fila.Item("Clasificacion")

                    Dim _Pc_Ranking = De_Num_a_Tx_01(_Fila.Item("Pc_Ranking"), False, 5)
                    Dim _Pc_Presencia = De_Num_a_Tx_01(_Fila.Item("Pc_Presencia"), False, 5)
                    Dim _Pc_Cantidad = De_Num_a_Tx_01(_Fila.Item("Pc_Cantidad"), False, 5)
                    Dim _Pc_Precio = De_Num_a_Tx_01(_Fila.Item("Pc_Precio"), False, 5)
                    Dim _Pc_Margen = De_Num_a_Tx_01(_Fila.Item("Pc_Margen"), False, 5)
                    Dim _TotalCosto = De_Num_a_Tx_01(_Fila.Item("TotalCosto"), False, 5)
                    Dim _TotalPrecio = De_Num_a_Tx_01(_Fila.Item("TotalPrecio"), False, 5)
                    Dim _TotalCantid = De_Num_a_Tx_01(_Fila.Item("TotalCantid"), False, 5)
                    Dim _Total_Mrg = De_Num_a_Tx_01(_Fila.Item("Total_Mrg"), False, 5)
                    Dim _Porc_Markup = De_Num_a_Tx_01(_Fila.Item("Porc_Markup"), False, 5)
                    Dim _Porc_Margen = De_Num_a_Tx_01(_Fila.Item("Porc_Margen"), False, 5)
                    Dim _Star = De_Num_a_Tx_01(_Fila.Item("Star"), False, 5)

                    'FROM(Zw_Prod_Ranking)

                    'Consulta_sql = "--" & vbCrLf & _
                    '                "Update Zw_Prod_Ranking Set " & Space(1) & _
                    '                "Descripcion = '" & _Descripcion & "'," & _
                    '                "Puntos_Rk = " & _Puntos_Rk & "," & _
                    '                "Ranking_Top = " & _Ranking_Top & "," & _
                    '                "Rk_Presencia = " & _Rk_Presencia & "," & _
                    '                "Rk_Cantidad = " & _Rk_Cantidad & "," & _
                    '                "Rk_Precio = " & _Rk_Precio & "," & _
                    '                "Rk_Margen = " & _Rk_Margen & "," & _
                    '                "Bv = " & _Bv & "," & _
                    '                "Fv = " & _Fv & "," & _
                    '                "Gv = " & _Gv & "," & _
                    '                "Nc = " & _Nc & "," & _
                    '                "Otro = " & _Otro & "," & _
                    '                "Presencia = " & _Presencia & "," & _
                    '                "Top_Ranking = '" & _Top_Ranking & "'," & _
                    '                "Top_Presencia = '" & _Top_Presencia & "'," & _
                    '                "Top_Cantidad = '" & _Top_Cantidad & "'," & _
                    '                "Top_Precio = '" & _Top_Precio & "'," & _
                    '                "Top_Margen= '" & _Top_Margen & "'," & _
                    '                "Cod_Clas = '" & _Cod_Clas & "'," & _
                    '                "Clasificacion = '" & _Clasificacion & "'," & _
                    '                "Pc_Ranking = " & _Pc_Ranking & "," & _
                    '                "Pc_Presencia = " & _Pc_Presencia & "," & _
                    '                "Pc_Cantidad = " & _Pc_Cantidad & "," & _
                    '                "Pc_Precio = " & _Pc_Precio & "," & _
                    '                "Pc_Margen = " & _Pc_Margen & "," & _
                    '                "TotalCosto = " & _TotalCosto & "," & _
                    '                "TotalPrecio = " & _TotalPrecio & "," & _
                    '                "TotalCantid = " & _TotalCantid & "," & _
                    '                "Total_Mrg = " & _Total_Mrg & "," & _
                    '                "Porc_Markup = " & _Porc_Markup & "," & _
                    '                "Porc_Margen = " & _Porc_Margen & "," & _
                    '                "Star = " & _Star & Space(1) & _
                    '                "Where Codigo = '" & _Codigo & "'" & vbCrLf

                    Consulta_sql = _
                                   "--" & vbCrLf & _
                                   "Insert Into " & _Global_BaseBk & "Zw_Prod_Ranking (Codigo,Descripcion,Puntos_Rk,Ranking_Top,Rk_Presencia,Rk_Cantidad," & _
                                   "Rk_Precio,Rk_Margen,Bv,Fv,Gv,Nc,Otro,Presencia,Top_Ranking,Top_Presencia,Top_Cantidad," & _
                                   "Top_Precio,Top_Margen,Cod_Clas,Clasificacion,Pc_Ranking,Pc_Presencia,Pc_Cantidad,Pc_Precio," & _
                                   "Pc_Margen,TotalCosto,TotalPrecio,TotalCantid,Total_Mrg,Porc_Markup,Porc_Margen,Star) Values " & _
                                   "('" & _Codigo & "','" & _Descripcion & "'," & _Puntos_Rk & "," & _Ranking_Top & _
                                   "," & _Rk_Presencia & "," & _Rk_Cantidad & "," & _Rk_Precio & "," & _Rk_Margen & "," & _Bv & "," & _
                                   _Fv & "," & _Gv & "," & _Nc & "," & _Otro & "," & _Presencia & ",'" & _Top_Ranking & _
                                   "','" & _Top_Presencia & "','" & _Top_Cantidad & "','" & _Top_Precio & "','" & _Top_Margen & _
                                   "','" & _Cod_Clas & "','" & _Clasificacion & "'," & _Pc_Ranking & "," & _Pc_Presencia & "," & _
                                   _Pc_Cantidad & "," & _Pc_Precio & "," & _Pc_Margen & "," & _TotalCosto & "," & _
                                   _TotalPrecio & "," & _TotalCantid & "," & _Total_Mrg & "," & _Porc_Markup & "," & _
                                   _Porc_Margen & "," & _Star & ")" & vbCrLf

                    If _SQL.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                        Lbl_Estatus.Text = _Descripcion & " Ok"
                    Else
                        MessageBoxEx.Show(Me, "Producto: " & _Codigo & " -> " & _Descripcion, "Problema con un producto!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Lbl_Estatus.Text = _Descripcion & " Problema!!"
                    End If

                    ProgressBarX1.Value += 1
                    ProgressBarX1.Text = "Procesados " & FormatNumber(ProgressBarX1.Value, 0) & " de " & FormatNumber(_Cant_Productos, 0)

                Next



                'System.Windows.Forms.Application.DoEvents()
                'Dim Fm As New Frm_Form_Esperar
                'Fm.BarraCircular.IsRunning = True
                'Fm.Show()

                'Consulta_sql = "Truncate Table Zw_Prod_Ranking" & vbCrLf & vbCrLf & _
                ' Consulta_sql


                ' Dim _Proceso_End As Boolean = _SQL.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                'Fm.Close()
                'Fm.Dispose()

                'If _Proceso_End Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally

                Grilla.Enabled = True
                BtnxSalir.Enabled = True
                BtnClasificarRk.Enabled = True
                BtnGrabarRankingTop.Enabled = True
                BtnCancelar.Enabled = True

                ProgressBarX1.Value = 0
                Lbl_Estatus.Text = String.Empty

            End Try

        End If
    End Sub

    
    
End Class