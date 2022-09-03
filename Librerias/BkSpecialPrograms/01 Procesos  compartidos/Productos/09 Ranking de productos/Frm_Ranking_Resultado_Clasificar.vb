Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms

Public Class Frm_Ranking_Resultado_Clasificar

    'Dim TablaRanking_Paso As String
    Dim _TblProductos As DataTable
    Dim _TblResultado As DataTable
    'Dim Campo_Clas, _CodTablaRanking As String
    Dim _Grilla_Productos As DataGridView

    Dim _Cancelar As Boolean

    Public Property Pro_Grilla_Productos() As DataGridView
        Get
            Return _Grilla_Productos
        End Get
        Set(ByVal value As DataGridView)
            _Grilla_Productos = value
        End Set
    End Property

    Public Sub New(ByVal TblProductos As DataTable, ByVal TblResultado As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _TblProductos = TblProductos
        _TblResultado = TblResultado
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Ranking_Resultado_Clasificar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblEstado1.Text = "Esperando acción..."
        Btn_Cancelar.Enabled = False
        With GrillaClasRK
            .DataSource = _TblResultado '_SQL.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(GrillaClasRK, True)

            .Columns("CodRanking_desc").Width = 200
            .Columns("CodRanking_desc").HeaderText = "Descripción"
            .Columns("CodRanking_desc").Visible = True

            '.Columns("Presencia").Width = 250
            '.Columns("Presencia").HeaderText = "Descripción"
            '.Columns("Presencia").Visible = True

            '.Columns("CantProdMarcados").Width = 100
            '.Columns("CantProdMarcados").HeaderText = "Cantidad productos marcados"
            '.Columns("CantProdMarcados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("CantProdMarcados").DefaultCellStyle.Format = "###,##.##"
            '.Columns("CantProdMarcados").Visible = True

            .Columns("PorcentMarcar").Width = 100
            .Columns("PorcentMarcar").HeaderText = "% Porcentaje prod. marcar"
            .Columns("PorcentMarcar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcentMarcar").DefaultCellStyle.Format = "###,##.##"
            .Columns("PorcentMarcar").ReadOnly = False
            .Columns("PorcentMarcar").Visible = True

            .Columns("CantProdMarcados").Width = 100
            .Columns("CantProdMarcados").HeaderText = "Cantidad productos marcados"
            .Columns("CantProdMarcados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantProdMarcados").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantProdMarcados").Visible = True

            .Columns("PorcAcumuladoProd").Width = 100
            .Columns("PorcAcumuladoProd").HeaderText = "% Acumulado según revisión"
            .Columns("PorcAcumuladoProd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcAcumuladoProd").DefaultCellStyle.Format = "% ###,##.###"
            .Columns("PorcAcumuladoProd").Visible = True

        End With

    End Sub

    Private Sub GrillaClasRK_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaClasRK.CellEnter

        TxtDescripcionRk.Text = GrillaClasRK.Rows(GrillaClasRK.CurrentRow.Index).Cells("DescripRk").Value

    End Sub

    Private Sub BtnClasificarRk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Clasificar_Rk.Click

        Try

            GrillaClasRK.Enabled = False
            Btn_Clasificar_Rk.Enabled = False
            Me.ControlBox = False
            Btn_Cancelar.Enabled = True

            With GrillaClasRK

                'Consulta_sql = "Update " & TablaRanking_Paso & " Set" & vbCrLf & _
                '               "Top_Cantidad = '',Top_Margen = ''," & vbCrLf & _
                '               "Top_Precio='',Top_Presencia='',Top_Ranking=''"
                ' _Sql.Ej_consulta_IDU(Consulta_Sql)

                Dim _Total_Cantidades As Double ' = Fx_Suma_cantidades( CampoRk, TablaRanking_Paso)
                Dim _Total_Margen As Double
                Dim _Total_Precio As Double
                Dim _Total_Presencia As Double
                Dim _Total_Ranking As Double

                For Each _Fila As DataRow In _TblProductos.Rows

                    _Fila.Item("Top_Presencia") = String.Empty
                    _Fila.Item("Top_Margen") = String.Empty
                    _Fila.Item("Top_Precio") = String.Empty
                    _Fila.Item("Top_Cantidad") = String.Empty
                    _Fila.Item("Top_Ranking") = String.Empty

                    _Total_Presencia += _Fila.Item("Presencia")
                    _Total_Margen += _Fila.Item("Total_Mrg")
                    _Total_Precio += _Fila.Item("TotalPrecio")
                    _Total_Cantidades += _Fila.Item("TotalCantid")
                    _Total_Ranking += _Fila.Item("Puntos_Rk")

                    _Fila.Item("Clasificacion") = String.Empty
                    _Fila.Item("Star") = 0

                Next

                Dim view As DataView = New DataView(_TblProductos)

                view.Sort = "Presencia DESC"
                Dim _Tbl_Presencia_Ordenado As DataTable = view.ToTable

                view.Sort = "Total_Mrg DESC"
                Dim _Tbl_Margen_Ordenado As DataTable = view.ToTable

                view.Sort = "TotalPrecio DESC"
                Dim _Tbl_Precio_Ordenado As DataTable = view.ToTable

                view.Sort = "TotalCantid DESC"
                Dim _Tbl_Cantidad_Ordenado As DataTable = view.ToTable

                view.Sort = "Puntos_Rk DESC"
                Dim _Tbl_Top_Ordenado As DataTable = view.ToTable



                If Not Fx_Clasificar_Rk("Presencia", "Top_Presencia", "Presencia", _
                              .Rows(0).Cells("PorcentMarcar").Value, _
                              .Rows(0).Cells("CantProdMarcados"), _
                              .Rows(0).Cells("PorcAcumuladoProd"), _
                              _Total_Presencia, _
                              _Tbl_Presencia_Ordenado) Then
                    Return
                End If


                If Not Fx_Clasificar_Rk("Total_Mrg", "Top_Margen", "Margen", _
                              .Rows(1).Cells("PorcentMarcar").Value, _
                              .Rows(1).Cells("CantProdMarcados"), _
                              .Rows(1).Cells("PorcAcumuladoProd"), _
                              _Total_Margen, _
                              _Tbl_Margen_Ordenado) Then
                    Return
                End If


                If Not Fx_Clasificar_Rk("TotalPrecio", "Top_Precio", "Precios", _
                              .Rows(2).Cells("PorcentMarcar").Value, _
                              .Rows(2).Cells("CantProdMarcados"), _
                              .Rows(2).Cells("PorcAcumuladoProd"), _
                              _Total_Precio, _
                              _Tbl_Precio_Ordenado) Then
                    Return
                End If

                If Not Fx_Clasificar_Rk("TotalCantid", "Top_Cantidad", "Cantidad", _
                              .Rows(3).Cells("PorcentMarcar").Value, _
                              .Rows(3).Cells("CantProdMarcados"), _
                              .Rows(3).Cells("PorcAcumuladoProd"), _
                              _Total_Cantidades, _
                              _Tbl_Cantidad_Ordenado) Then
                    Return
                End If

                If Not Fx_Clasificar_Rk("Puntos_Rk", "Top_Ranking", "Top Ranking", _
                             .Rows(4).Cells("PorcentMarcar").Value, _
                             .Rows(4).Cells("CantProdMarcados"), _
                             .Rows(4).Cells("PorcAcumuladoProd"), _
                             _Total_Ranking, _
                             _Tbl_Top_Ordenado) Then
                    Return
                End If

            End With

            Sb_Actualizar_Star()

            MessageBoxEx.Show(Me, "Proceso completado correctamente", "Ranking", _
                               MessageBoxButtons.OK, MessageBoxIcon.Information)

            LblEstado1.Text = "Esperando acción..."

        Catch ex As Exception

            MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Finally
            GrillaClasRK.Enabled = True
            Btn_Clasificar_Rk.Enabled = True
            Me.ControlBox = True
            Btn_Cancelar.Enabled = False
        End Try

    End Sub


    Public Sub Sb_Actualizar_Star()



        Dim _I = 0
        For Each _Fila As DataRow In _TblProductos.Rows

            Dim _Star = 0

            Dim _Top_Presencia = _Fila.Item("Top_Presencia")
            Dim _Top_Margen = _Fila.Item("Top_Margen")
            Dim _Top_Precio = _Fila.Item("Top_Precio")
            Dim _Top_Cantidad = _Fila.Item("Top_Cantidad")
            Dim _Top_Ranking = _Fila.Item("Top_Ranking")

            If _Top_Presencia = "X" Then

                If _Top_Margen = "X" And _Top_Precio = "X" And _Top_Cantidad = "X" Then
                    _Fila.Item("Clasificacion") = "Vip"
                ElseIf _Top_Margen = "X" Then
                    _Fila.Item("Clasificacion") = "Pro-Margen"
                ElseIf _Top_Precio = "X" Then
                    _Fila.Item("Clasificacion") = "Pro-Ventas"
                ElseIf _Top_Cantidad = "X" Then
                    _Fila.Item("Clasificacion") = "Pro-Cantidad"
                Else
                    _Fila.Item("Clasificacion") = "Pro-Presencia"
                End If

            ElseIf _Top_Presencia = "" Then

                If _Top_Margen = "X" Then
                    _Fila.Item("Clasificacion") = "Margen"
                Else
                    If _Top_Precio = "X" Then
                        _Fila.Item("Clasificacion") = "Precio"
                    Else
                        If _Top_Cantidad = "X" Then
                            _Fila.Item("Clasificacion") = "Cantidfad"
                        Else
                            _Fila.Item("Clasificacion") = "S/Rk"
                        End If
                    End If
                End If
            End If


            If _Top_Presencia = "X" Then _Star += 1
            If _Top_Margen = "X" Then _Star += 1
            If _Top_Precio = "X" Then _Star += 1
            If _Top_Cantidad = "X" Then _Star += 1
            If _Top_Ranking = "X" Then _Star += 1

            Dim _St As String = String.Empty

            If CBool(_Star) Then
                For _I = 1 To _Star
                    _St += "* "
                Next
            End If

            _Fila.Item("Star") = _Star
            _Fila.Item("Star2") = _St
            '_Grilla_Productos.Rows(_I).Cells("BtnImagen").Value = Imagenes.Images.Item(_Star)
            System.Windows.Forms.Application.DoEvents()
            _I += 1
        Next


    End Sub

    Function Fx_Clasificar_Rk(ByVal _CampoRk As String, _
                              ByVal _CampoTop As String, _
                              ByVal _ColAnalizando As String, _
                              ByVal _Porcent_Max As Double, _
                              ByVal _TotalActualizados As Object, _
                              ByVal _TotalAcumulado As Object, _
                              ByVal _Total_ As Double, _
                              ByVal _Tabla As DataTable) As Boolean


        'Consulta_sql = "Select  Codigo,Descripcion," & CampoRk & " from " & TablaRanking_Paso & vbCrLf & _
        '               "Order by " & CampoRk & " Desc"

        'Dim Tabla As DataTable
        'Tabla = _SQL.Fx_Get_Tablas(Consulta_sql)

        Dim _Suma As Double = 0
        Dim _NroFila = 0
        Dim _Porcentaje As Double


        ' Dim Total_ As Double = Fx_Suma_cantidades( CampoRk, TablaRanking_Paso)
        Dim _Maximo_ As Double = _Total_ * (_Porcent_Max / 100)

        'Bar.Maximum = Tabla.Rows.Count
        'Bar.value = 0
        Dim _Contador = 1

        For Each _Fila As DataRow In _Tabla.Rows

            System.Windows.Forms.Application.DoEvents()

            Dim _Codigo = Trim(_Fila.Item("Codigo").ToString)
            Dim _Descripcion = Trim(_Fila.Item("Descripcion").ToString)


            _Porcentaje = De_Txt_a_Num_01(_Fila.Item(_CampoRk).ToString)
            _Suma += _Porcentaje

            Dim Pc = Math.Round(_Suma / _Total_, 7) * 100

            LblEstado1.Text = "Marcando " & _ColAnalizando & _
                           ", Producto: " & FormatNumber(_Contador, 0) & _
                           " de " & FormatNumber(_TblProductos.Rows.Count, 0) & " productos" & vbCrLf & _
                           "Porcentaje acumulado " & Pc & "%"

            '_Fila.Item(_CampoTop) = "X"

            'Consulta_sql = "Update " & TablaRanking_Paso & " Set " & CampoTop & " = 'X' Where Codigo = '" & Codigo & "'"
            ' _Sql.Ej_consulta_IDU(Consulta_Sql)

            Dim rows() As DataRow = _TblProductos.Select("Codigo = '" & _Codigo & "'")

            ' Actualizamos los valores
            '
            For Each row As DataRow In rows
                row(_CampoTop) = "X"
            Next

            Dim _Diferencia As Double = Math.Round(Pc - _Porcent_Max, 5)

            Dim _Porc As Double = Math.Round(Pc / 100, 4)

            _TotalActualizados.value = _Contador
            _TotalAcumulado.value = _Porc 'Math.Round(Pc, 3) / 100

            If _Diferencia > 0.45 Then
                Exit For
            End If

            If _Cancelar Then

                If MessageBoxEx.Show(Me, "¿Esta seguro de cancelar la acción?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then
                    _Cancelar = False
                    Return False
                End If

            End If

            _Contador += 1
            '   Bar.Value = ((Contador * 100) / Tabla.Rows.Count) 'Mas

        Next

        Return True

    End Function



    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Frm_Ranking_Resultado_Clasificar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class