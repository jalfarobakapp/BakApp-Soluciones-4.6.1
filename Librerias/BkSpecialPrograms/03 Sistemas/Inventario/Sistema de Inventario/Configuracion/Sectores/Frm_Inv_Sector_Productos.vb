Imports System.Drawing.Printing
Imports DevComponents.DotNetBar

Public Class Frm_Inv_Sector_Productos

    Private _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private Consulta_sql As String

    Private _IdSector As Integer
    Private _Pagina As Integer
    Private _Tbl As DataTable
    Private _CampoCodigo As String
    Public Property Cl_InvSectores As Cl_InvSectores

    Public Sub New(_IdSector As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._IdSector = _IdSector
        Cl_InvSectores = New Cl_InvSectores
        Cl_InvSectores.Fx_Llenar_Zw_Inv_Sector(_IdSector)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Inv_Sector_Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Id,IdHoja,Nro_Hoja,IdInventario,Empresa,Sucursal,Bodega,Responsable," &
                       "IdContador1,IdContador2,Item_Hoja,IdSector,Sector,Ubicacion,TipoConteo,Codigo,KOPR,KOPRRA,KOPRTE,NOKOPR," &
                       "EsSeriado,NroSerie,FechaHoraToma,Rtu,RtuVariable,Udtrpr,Case Udtrpr When 1 Then Ud1 Else Ud2 End As 'Ud'," &
                       "Cantidad,Ud1,CantidadUd1,Ud2,CantidadUd2,Observaciones,Recontado,Actualizado_por,Obs_Actualizacion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle" & vbCrLf &
                       "Left Join MAEPR On KOPR = Codigo" & vbCrLf &
                       "Where IdSector = " & _IdSector & vbCrLf &
                       "Order By IdHoja,Id"

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            With Grilla

                .DataSource = _Tbl

                OcultarEncabezadoGrilla(Grilla)

                Dim _DisplayIndex = 0

                .Columns("Nro_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Nro_Hoja").HeaderText = "Hoja"
                .Columns("Nro_Hoja").Width = 50
                .Columns("Nro_Hoja").Visible = True
                .Columns("Nro_Hoja").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Item_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Item_Hoja").HeaderText = "Item"
                .Columns("Item_Hoja").Width = 40
                .Columns("Item_Hoja").Visible = True
                .Columns("Item_Hoja").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Codigo").HeaderText = "Código"
                .Columns("Codigo").Width = 100
                .Columns("Codigo").Visible = True
                .Columns("Codigo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("KOPRTE").HeaderText = "Cód. técnico"
                .Columns("KOPRTE").Width = 110
                .Columns("KOPRTE").Visible = True
                .Columns("KOPRTE").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NOKOPR").HeaderText = "Descripción"
                .Columns("NOKOPR").Width = 280
                .Columns("NOKOPR").Visible = True
                .Columns("NOKOPR").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Ud").HeaderText = "Ud"
                .Columns("Ud").Width = 30
                .Columns("Ud").Visible = True
                .Columns("Ud").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
                .Columns("Cantidad").HeaderText = "Cant."
                .Columns("Cantidad").Width = 65
                .Columns("Cantidad").Visible = True
                .Columns("Cantidad").DisplayIndex = _DisplayIndex

                .Columns("Ubicacion").HeaderText = "Ubicación"
                .Columns("Ubicacion").Width = 80
                .Columns("Ubicacion").Visible = True
                .Columns("Ubicacion").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

        End If

    End Sub

    Public Function Sb_Imprimir_Listado(_PrinterSettings As PrinterSettings)

        Try

            Dim printDoc As New PrintDocument

            AddHandler printDoc.PrintPage, AddressOf print_PrintPage

            _Pagina = 0
            printDoc.PrinterSettings = _PrinterSettings
            printDoc.Print()

            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub print_PrintPage(sender As Object, e As PrintPageEventArgs)

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

            Dim _FuncionarioCargo As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & Cl_InvSectores.Zw_Inv_Sector.CodFuncionario & "'")

            e.Graphics.DrawString("FUNCIONARIO A CARGO : " & _FuncionarioCargo, FteCourier_New_N_13, Brushes.Black, xPos, yPos)
            yPos += 30
            e.Graphics.DrawString("SECTOR  : " & Cl_InvSectores.Zw_Inv_Sector.Sector, FteCourier_New_N_13, Brushes.Black, xPos, yPos)
            yPos += 20
            e.Graphics.DrawString("NOMBRE  : " & Cl_InvSectores.Zw_Inv_Sector.NombreSector, FteCourier_New_N_13, Brushes.Black, xPos, yPos)

            'yPos = yPos + 110
            'e.Graphics.DrawString("SECTOR : " & _CodSector, Dt2Font, Brushes.Black, xPos + 5, yPos)
            yPos += 40


            ' Calculamos el número de líneas que caben en cada página. 
            Dim _LineasPorPagina = 50 'e.MarginBounds.Height / FteArial_R_8.GetHeight(e.Graphics)

            'Dim _Total = FormatNumber(Total, 0)
            '_Total = Rellenar(_Total, 9, " ", False)

            Dim _Hoja, _Item, _Codigo, _Descripcion, _Ud, _Ubicacion, _Cant As String
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
            xPos += 40
            e.Graphics.DrawString("Cantidad", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 70
            e.Graphics.DrawString("Reconteo", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 80
            e.Graphics.DrawString("Ubicación", FteArial_N_8, Brushes.Black, xPos, yPos)
            xPos += 30
            'e.Graphics.DrawString("Fil", FteArial_N_8, Brushes.Black, xPos, yPos)
            yPos += 20

            xPos = XX

            Dim Cuenta As Integer = 0


            ''For Each _Filas As DataRow In _Tbl.Rows
            While Cuenta < _LineasPorPagina AndAlso _Pagina < _Tbl.Rows.Count

                Dim _Filas As DataRow = _Tbl.Rows(_Pagina)

                _Hoja = _Filas.Item("Nro_Hoja")
                _Item = _Filas.Item("Item_Hoja")
                _Codigo = _Filas.Item(_CampoCodigo)
                _Descripcion = _Filas.Item("NOKOPR")
                _Ud = _Filas.Item("Ud")
                _Cantidad = _Filas.Item("Cantidad")
                _Ubicacion = _Filas.Item("Ubicacion")

                _Cant = Rellenar(_Hoja, 3, " ", False)
                e.Graphics.DrawString(_Hoja, FteCourier_New_N_8, Brushes.Black, xPos + 5, yPos)
                xPos += 55
                _Cant = Rellenar(_Item, 2, " ", False)
                e.Graphics.DrawString(_Item, FteCourier_New_N_8, Brushes.Black, xPos, yPos)
                xPos += 50
                e.Graphics.DrawString(_Codigo, FteArial_R_8, Brushes.Black, xPos, yPos)
                xPos += 100
                e.Graphics.DrawString(_Descripcion, FteCourier_New_N_7, Brushes.Black, xPos, yPos)
                xPos += 320
                e.Graphics.DrawString(_Ud, FteArial_R_8, Brushes.Black, xPos, yPos)
                xPos += 30
                _Cant = Rellenar(_Cantidad, 8, " ", False)
                e.Graphics.DrawString(_Cant, FteCourier_New_N_8, Brushes.Black, xPos, yPos)
                xPos += 80
                e.Graphics.DrawString("_________", FteArial_N_8, Brushes.Black, xPos, yPos)
                xPos += 80
                e.Graphics.DrawString(_Ubicacion, FteArial_R_8, Brushes.Black, xPos, yPos) '_Columna
                'xPos += 30
                'e.Graphics.DrawString("XX", FteArial_R_8, Brushes.Black, xPos, yPos) '_Fila

                yPos += 15
                'e.Graphics.DrawString(Cantidades, DtFont, Brushes.Black, xPos, yPos)
                xPos = XX

                Cuenta += 1
                _Pagina += 1

            End While
            'Next


            ' Una vez fuera del bucle comprobamos si nos quedan más filas
            ' por imprimir, si quedan saldrán en la siguente página
            If _Pagina < _Tbl.Rows.Count Then
                e.HasMorePages = True
            Else
                ' si llegamos al final, se establece HasMorePages a
                ' false para que se acabe la impresión
                e.HasMorePages = False
                ' Es necesario poner el contador a 0 porque, por ejemplo si se hace
                ' una impresión desde PrintPreviewDialog, se vuelve disparar este
                ' evento como si fuese la primera vez, y si i está con el valor de la
                ' última fila del grid no se imprime nada
                _Pagina = 0
            End If
            'Next

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click


        Dim _Sel_Impresora As Sel_Impresora = Fx_seleccionar_Impresora(Me)

        If Not _Sel_Impresora.ImpresoraSeleccionada Then
            Return
        End If


        Dim Rdb_Kopr As New Command
        Rdb_Kopr.Checked = True
        Rdb_Kopr.Name = "Rdb_Kopr"
        Rdb_Kopr.Text = "Principal"

        Dim Rdb_Koprra As New Command
        Rdb_Koprra.Checked = False
        Rdb_Koprra.Name = "Rdb_Koprra"
        Rdb_Koprra.Text = "Rapido"

        Dim Rdb_Tecnico As New Command
        Rdb_Tecnico.Checked = False
        Rdb_Tecnico.Name = "Rdb_Tecnico"
        Rdb_Tecnico.Text = "Técnico"

        Dim _Opciones() As Command = {Rdb_Kopr, Rdb_Koprra, Rdb_Tecnico}

        Dim _Info As New TaskDialogInfo("Tipo de código",
                eTaskDialogIcon.Information2,
                "Seleccione el tipo de código a imprmir",
                "Indique su opción",
                eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado <> eTaskDialogResult.Ok Then
            Return
        End If

        If _Resultado = eTaskDialogResult.Ok Then

            If Rdb_Kopr.Checked Then
                _CampoCodigo = "KOPR"
            End If

            If Rdb_Koprra.Checked Then
                _CampoCodigo = "KOPRRA"
            End If

            If Rdb_Tecnico.Checked Then
                _CampoCodigo = "KOPRTE"
            End If

        End If

        Sb_Imprimir_Listado(_Sel_Impresora.PrtSettings)

    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Productos del sector " & Cl_InvSectores.Zw_Inv_Sector.Sector)
    End Sub
End Class
