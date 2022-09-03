Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Imports System.Drawing
Imports System.Drawing.Printing

Public Class Frm_04_Productos_por_sector

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _IdInventario, _
           _CodSector, _
           _Nombre_Lugar, _
           _Codigo_Sector, _
           _CampoCodigo, _
           _FuncionarioCargo As String

    Dim _Ult_Semilla As Integer
    Dim i As Integer
    Dim _Tbl As DataTable



    Public Function Act_Grilla() As Long

        Consulta_sql = "SELECT Semilla,Nro_Hoja,Item_Hoja,Codproducto, Codrapido, Codtecnico,CodBarras, DescripcionProducto, Unidad_Medida," & vbCrLf & _
                       "CantidadInventariada,Columna, Fila FROM dbo.ZW_TmpInvProductosInventariados" & vbCrLf & _
                       "Where   (IdInventario = " & _IdInventario & _
                       ") AND (CodSectorInt = '" & _CodSector & "') " & vbCrLf & _
                       "ORDER BY Semilla"

        _Tbl = _SQL.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            With Grilla

                .DataSource = _Tbl

                OcultarEncabezadoGrilla(Grilla)

                .Columns("Nro_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Nro_Hoja").HeaderText = "Hoja"
                .Columns("Nro_Hoja").Width = 40
                .Columns("Nro_Hoja").Visible = True

                .Columns("Item_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Item_Hoja").HeaderText = "Item"
                .Columns("Item_Hoja").Width = 40
                .Columns("Item_Hoja").Visible = True

                .Columns("Codproducto").HeaderText = "Código"
                .Columns("Codproducto").Width = 100
                .Columns("Codproducto").Visible = True

                .Columns("Codtecnico").HeaderText = "Cód. técnico"
                .Columns("Codtecnico").Width = 110
                .Columns("Codtecnico").Visible = True

                .Columns("DescripcionProducto").HeaderText = "Descripción"
                .Columns("DescripcionProducto").Width = 280
                .Columns("DescripcionProducto").Visible = True

                .Columns("Unidad_Medida").HeaderText = "Ud"
                .Columns("Unidad_Medida").Width = 30
                .Columns("Unidad_Medida").Visible = True

                .Columns("CantidadInventariada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CantidadInventariada").DefaultCellStyle.Format = "###,##.##"
                .Columns("CantidadInventariada").HeaderText = "Cant."
                .Columns("CantidadInventariada").Width = 65
                .Columns("CantidadInventariada").Visible = True

                .Columns("Columna").HeaderText = "Col."
                .Columns("Columna").Width = 40
                .Columns("Columna").Visible = True

                .Columns("Fila").HeaderText = "Fila"
                .Columns("Fila").Width = 40
                .Columns("Fila").Visible = True


            End With

        End If

        Return _Tbl.Rows.Count

    End Function

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Act_Grilla()
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Inventario Sector " & _CodSector)
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        Dim Fm_Imp As New Frm_Seleccionar_Impresoras("")
        Fm_Imp.ShowDialog(Me)
        Dim Impresora As String = Fm_Imp.Pro_Impresora_Seleccionada

        If Not String.IsNullOrEmpty(Impresora) Then

            'Dim Fm As New Frm_SeleccionarTipoBusquedaCodProducto
            'Fm.ShowDialog(Me)

            'If Not Fm._Aceptado Then
            'MessageBoxEx.Show("No se selecciono ningún tipo de código para el levantamiento", _
            '                      "Tipo de código", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Return
            'End If
            'Codproducto, Codrapido, Codtecnico,CodBarras

            'If Fm.RdbCodPrincipal.Checked Then
            _CampoCodigo = "Codproducto"
            'ElseIf Fm.RdbCodRapido.Checked Then
            '_CampoCodigo = "Codrapido"
            'ElseIf Fm.RdbCodTecnico.Checked Then
            '_CampoCodigo = "Codtecnico"
            'ElseIf Fm.RdbCodAlternativo.Checked Then
            '_CampoCodigo = "CodBarras"
            'End If

            ImprimirPicking(Impresora)

        End If


    End Sub




    Public Function ImprimirPicking(ByVal _Impresora As String)

        Try

            Dim printDoc As New PrintDocument

            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 612, 792) ' CARTA
            'printDoc.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
            ' printDoc.DefaultPageSettings.Landscape = True
            ' asignamos el método de evento para cada página a imprimir
            AddHandler printDoc.PrintPage, AddressOf print_PrintPage

            'Indicamos la impresora
            'Dim Imp As String
            'Imp = trae_datoAccess(tb, "Impresora", "Tmp_Conf_Local", "Modulo = 'Imp_Picking'")
            i = 0
            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub print_PrintPage(ByVal sender As Object, _
                                ByVal e As PrintPageEventArgs)


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita


        Try
            'Vale-BkPost

            ' imprimimos la cadena en el margen izquierdo
            Dim xPos As Single = 20 'e.MarginBounds.Left
            ' La fuente a usar

            Dim FteArial_R_8 As New Font("Arial", 8, FontStyle.Regular) ' Fuente del detalle
            Dim FteArial_R_10 As New Font("Arial", 10, FontStyle.Regular) ' Fuente del detalle
            Dim FteArial_R_12 As New Font("Arial", 12, FontStyle.Regular) ' Fuente del detalle
            Dim FteArial_R_14 As New Font("Arial", 14, FontStyle.Regular) ' Fuente del detalle
            Dim FteArial_R_16 As New Font("Arial", 16, FontStyle.Regular) ' Fuente del detalle
            Dim FteArial_R_18 As New Font("Arial", 18, FontStyle.Regular) ' Fuente del detalle

            Dim FteArial_N_8 As New Font("Arial", 8, FontStyle.Bold) ' Fuente del detalle
            Dim FteArial_N_10 As New Font("Arial", 10, FontStyle.Bold) ' Fuente del detalle
            Dim FteArial_N_12 As New Font("Arial", 12, FontStyle.Bold) ' Fuente del detalle
            Dim FteArial_N_14 As New Font("Arial", 14, FontStyle.Bold) ' Fuente del detalle
            Dim FteArial_N_16 As New Font("Arial", 16, FontStyle.Bold) ' Fuente del detalle
            Dim FteArial_N_18 As New Font("Arial", 18, FontStyle.Bold) ' Fuente del detalle

            Dim FteTimes_New_Roman_N_8 As New Font("Times New Roman", 8, FontStyle.Bold)
            Dim FteTimes_New_Roman_N_10 As New Font("Times New Roman", 10, FontStyle.Bold)
            Dim FteTimes_New_Roman_N_12 As New Font("Times New Roman", 12, FontStyle.Bold)
            Dim FteTimes_New_Roman_N_14 As New Font("Times New Roman", 14, FontStyle.Bold)
            Dim FteTimes_New_Roman_N_16 As New Font("Times New Roman", 16, FontStyle.Bold)

            Dim Dt2Font As New Font("Arial", 40, FontStyle.Bold) ' Fuente del detalle
            Dim prFont As New Font("Arial", 35, FontStyle.Bold)    ' Fuente Encabezado
            Dim FontNro As New Font("Times New Roman", 50, FontStyle.Bold)
            Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)


            Dim FteCourier_New_N_6 As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_7 As New Font("Courier New", 7, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_8 As New Font("Courier New", 8, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_9 As New Font("Courier New", 9, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_10 As New Font("Courier New", 10, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_11 As New Font("Courier New", 11, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_12 As New Font("Courier New", 12, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_13 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente
            Dim FteCourier_New_N_14 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente


            ' la posición superior
            Dim yPos As Single = prFont.GetHeight(e.Graphics) - 10


            'Encabezado
            'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 5, 830, 150))
            'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 180, 830, 200))
            'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 180, 830, 300))


            Dim Rt() As String = Split(RutEmpresa, "-")
            Dim Rut_Emp As String = RutEmpresa 'FormatNumber(Rt(0), 0) & "-" & Rt(1)

            e.Graphics.DrawString("Rut: " & Rut_Emp, FteCourier_New_N_13, Brushes.Black, xPos, yPos)
            yPos += 20
            e.Graphics.DrawString("Nombre : " & RazonEmpresa, FteCourier_New_N_13, Brushes.Black, xPos, yPos)
            yPos += 30

            'Dim Hora = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
            'Dim Fecha = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

            Dim NroLineasPagina As Integer = e.PageBounds.Height / Dt2Font.GetHeight(e.Graphics)

            e.Graphics.DrawString("FUNCIONARIO A CARGO : " & _FuncionarioCargo, FteCourier_New_N_13, Brushes.Black, xPos, yPos)
            yPos += 30
            e.Graphics.DrawString("LUGAR  : " & _Nombre_Lugar, FteCourier_New_N_13, Brushes.Black, xPos, yPos)
            yPos += 20
            e.Graphics.DrawString("SECTOR : " & _Codigo_Sector, FteCourier_New_N_13, Brushes.Black, xPos, yPos)

            'yPos = yPos + 110
            'e.Graphics.DrawString("SECTOR : " & _CodSector, Dt2Font, Brushes.Black, xPos + 5, yPos)
            yPos += 40


            ' Calculamos el número de líneas que caben en cada página. 
            Dim _LineasPorPagina = 50 'e.MarginBounds.Height / FteArial_R_8.GetHeight(e.Graphics)

            'Dim _Total = FormatNumber(Total, 0)
            '_Total = Rellenar(_Total, 9, " ", False)

            Dim _Hoja, _Item, _Codigo, _Descripcion, _Ud, _Columna, _Fila, _Cant As String
            Dim _Cantidad As Double
            Dim XX = xPos

            e.Graphics.DrawString("Hoja", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 50
            e.Graphics.DrawString("Item", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 50
            e.Graphics.DrawString("Código", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 100
            e.Graphics.DrawString("Descripcion", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 320
            e.Graphics.DrawString("Ud", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 60
            e.Graphics.DrawString("Cantidad", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 70
            e.Graphics.DrawString("Reconteo", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 80
            e.Graphics.DrawString("Col", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 30
            e.Graphics.DrawString("Fil", FteArial_N_8, Brushes.Black, xPos, yPos)
            yPos += 20

            xPos = XX

            Dim Cuenta As Integer = 0


            ''For Each _Filas As DataRow In _Tbl.Rows
            While Cuenta < _LineasPorPagina AndAlso i < _Tbl.Rows.Count

                Dim _Filas As DataRow = _Tbl.Rows(i)

                _Hoja = _Filas.Item("Nro_Hoja")
                _Item = _Filas.Item("Item_Hoja")
                _Codigo = _Filas.Item(_CampoCodigo)
                _Descripcion = _Filas.Item("DescripcionProducto")
                _Ud = _Filas.Item("Unidad_Medida")
                _Cantidad = _Filas.Item("CantidadInventariada")
                _Columna = _Filas.Item("Columna")
                _Fila = _Filas.Item("Fila")

                _Cant = Rellenar(_Hoja, 3, " ", False)
                e.Graphics.DrawString(_Hoja, FteCourier_New_N_8, Brushes.Black, xPos + 15, yPos)
                xPos += 50
                _Cant = Rellenar(_Item, 2, " ", False)
                e.Graphics.DrawString(_Item, FteCourier_New_N_8, Brushes.Black, xPos + 15, yPos)
                xPos += 50
                e.Graphics.DrawString(_Codigo, FteArial_R_8, Brushes.Black, xPos, yPos)
                xPos += 100
                e.Graphics.DrawString(_Descripcion, FteCourier_New_N_7, Brushes.Black, xPos, yPos)
                xPos += 320
                e.Graphics.DrawString(_Ud, FteArial_R_8, Brushes.Black, xPos, yPos)
                xPos += 50
                _Cant = Rellenar(_Cantidad, 8, " ", False)
                e.Graphics.DrawString(_Cant, FteCourier_New_N_8, Brushes.Black, xPos, yPos)
                xPos += 80
                e.Graphics.DrawString("_________", FteArial_N_8, Brushes.Black, xPos, yPos)
                xPos += 80
                e.Graphics.DrawString("XX", FteArial_R_8, Brushes.Black, xPos, yPos) '_Columna
                xPos += 30
                e.Graphics.DrawString("XX", FteArial_R_8, Brushes.Black, xPos, yPos) '_Fila

                yPos += 15
                'e.Graphics.DrawString(Cantidades, DtFont, Brushes.Black, xPos, yPos)
                xPos = XX

                Cuenta += 1
                i += 1

            End While
            'Next


            ' Una vez fuera del bucle comprobamos si nos quedan más filas
            ' por imprimir, si quedan saldrán en la siguente página
            If i < _Tbl.Rows.Count Then
                e.HasMorePages = True
            Else
                ' si llegamos al final, se establece HasMorePages a
                ' false para que se acabe la impresión
                e.HasMorePages = False
                ' Es necesario poner el contador a 0 porque, por ejemplo si se hace
                ' una impresión desde PrintPreviewDialog, se vuelve disparar este
                ' evento como si fuese la primera vez, y si i está con el valor de la
                ' última fila del grid no se imprime nada
                i = 0
            End If
            'Next

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
       Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub
End Class