Public Class Frm_Stmp_SalaEspera

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_SalaEspera As DataTable
    Private _PaginaActual As Integer = 0
    Public Property _TamanoDePagina As Integer = 20
    Private _TotalDePaginas As Integer
    Private _Dv As DataView
    Private _Actualizar As Boolean = False
    Private parpadeo As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 45, New Font("Tahoma", 14), Color.AliceBlue, ScrollBars.None, False, False, False)

    End Sub

    Private Sub Frm_Stmp_SalaEspera_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _TamanoDePagina = 12

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()
        Sb_MostrarRegistros()

        Timer_Paginar.Interval = (1000 * 6)
        Timer_Paginar.Start()

        Timer_Parpadeo.Interval = 500
        Timer_Parpadeo.Start()

        Timer_Beep.Interval = 1000 * 60
        Timer_Beep.Stop()

        CircularPgrs.IsRunning = True

        Lbl_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm")

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty
        Dim _DocConBeep = 0

        _Condicion = vbCrLf & "And Estado = 'FACTU' Or (Estado IN ('PREPA','COMPL') And Planificada = 1 And Facturar = 1)"

        Consulta_sql = My.Resources.Recursos_WmsVillar.SQLQuery_Lista_de_espera_Sgem
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)
        Consulta_sql = Replace(Consulta_sql, "--#Condicion#", _Condicion)
        Consulta_sql = Replace(Consulta_sql, "Select * From #Paso Order by Tido,Nudo", "Select * From #Paso Order by Numero")
        Consulta_sql = Replace(Consulta_sql, "Zw_Stmp_Enc", _Global_BaseBk & "Zw_Stmp_Enc")
        Consulta_sql = Replace(Consulta_sql, "Zw_Stmp_SalaEspera", _Global_BaseBk & "Zw_Stmp_SalaEspera")

        'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_SalaEspera"

        _Tbl_SalaEspera = _Sql.Fx_Get_DataTable(Consulta_sql)

        ' Asegúrate de que la columna exista
        If Not _Tbl_SalaEspera.Columns.Contains("NumeroDelItem") Then
            _Tbl_SalaEspera.Columns.Add("NumeroDelItem", GetType(Integer))
        End If

        For Each row As DataRow In _Tbl_SalaEspera.Rows

            row("NumeroDelItem") = row.Item("NroTicket") 'CInt(Replace(row.Item("Numero"), "#T", ""))

            If row.Item("Estado") = "FACTU" AndAlso row.Item("Beep") = 0 Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_SalaEspera Set Beep = 1 Where Id = " & row.Item("Id")
                _Sql.Ej_consulta_IDU(Consulta_sql)

                'Console.Beep(500, 2000)
                'Console.Beep(500, 2000)

                _DocConBeep += 1

            End If

        Next

        'If CBool(_DocConBeep) Then
        '    'Beep()
        '    Console.Beep(500, 1000)
        '    Console.Beep(500, 1000)
        'End If

        ' Calcular el número total de páginas
        Dim totalDeRegistros As Integer = _Tbl_SalaEspera.Rows.Count
        _TotalDePaginas = Math.Ceiling(totalDeRegistros / _TamanoDePagina)

        _Actualizar = False

    End Sub

    Sub Sb_Actualizar_Grilla_Old()

        Dim _Condicion As String = String.Empty
        Dim _DocGenerados = 0

        _Condicion = vbCrLf & "And Estado = 'FACTU' Or (Estado IN ('PREPA','COMPL') And Planificada = 1 And Facturar = 1)"

        Dim _Select_Paginacion As String = "-- Definir la página que deseas mostrar y el tamaño de página" & vbCrLf &
                                           "DECLARE @TamañoDePágina INT = 10;" & vbCrLf &
                                           "DECLARE @NúmeroDePágina INT -- Cambia este valor para navegar entre páginas" & vbCrLf &
                                           "Set @NúmeroDePágina = 4" & vbCrLf &
                                           "-- Consulta con paginación" & vbCrLf &
                                           "SELECT Numero,Tido,Nudo,NOKOEN,Estado_Str,InfoCliente" & vbCrLf &
                                           "FROM #Paso" & vbCrLf &
                                           "ORDER BY Numero -- Es importante definir por qué columna(s) quieres ordenar" & vbCrLf &
                                           "OFFSET (@NúmeroDePágina - 1) * @TamañoDePágina ROWS" & vbCrLf &
                                           "FETCH NEXT @TamañoDePágina ROWS ONLY;"

        Consulta_sql = My.Resources.Recursos_WmsVillar.SQLQuery_Lista_de_espera_Sgem
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)
        Consulta_sql = Replace(Consulta_sql, "--#Condicion#", _Condicion)
        Consulta_sql = Replace(Consulta_sql, "Select * From #Paso Order by Tido,Nudo", "Select * From #Paso Order by Numero")
        Consulta_sql = Replace(Consulta_sql, "Zw_Stmp_Enc", _Global_BaseBk & "Zw_Stmp_Enc")
        _Tbl_SalaEspera = _Sql.Fx_Get_DataTable(Consulta_sql)

        ' Asegúrate de que la columna exista
        If Not _Tbl_SalaEspera.Columns.Contains("NumeroDelItem") Then
            _Tbl_SalaEspera.Columns.Add("NumeroDelItem", GetType(Integer))
        End If

        For Each row As DataRow In _Tbl_SalaEspera.Rows
            'row("NumeroDelItem") = _Tbl_SalaEspera.Rows.IndexOf(row) + 1
            row("NumeroDelItem") = CInt(Replace(row.Item("Numero"), "#T", ""))
            If row.Item("Estado") = "FACTU" Then
                _DocGenerados += 1
            End If
        Next

        ' Calcular el número total de páginas
        Dim totalDeRegistros As Integer = _Tbl_SalaEspera.Rows.Count
        _TotalDePaginas = Math.Ceiling(totalDeRegistros / _TamanoDePagina)

        _Actualizar = False

        If CBool(_DocGenerados) Then
            'Beep()
            Console.Beep(500, 1000)
        End If

    End Sub

    Private Sub Sb_MostrarRegistros()

        Dim _TotalDePaginas As Integer = Math.Ceiling(_Tbl_SalaEspera.Rows.Count / _TamanoDePagina)
        _PaginaActual += 1

        If _PaginaActual > _TotalDePaginas Then
            _Actualizar = True
            Return
        End If

        If _TotalDePaginas = 0 Then
            Grilla.DataSource = Nothing
            Return
        End If

        Lbl_Estatus.Text = "Pagina: " & _PaginaActual & " de " & _TotalDePaginas
        LabelX1.Text = "PEDIDOS PARA RETIRO, " & Lbl_Estatus.Text

        ' Crear un nuevo DataTable para la página actual
        Dim dataTablePaginado As DataTable = _Tbl_SalaEspera.Clone() ' Clonar la estructura, no los datos

        Dim inicio As Integer = (_PaginaActual - 1) * _TamanoDePagina

        For i As Integer = inicio To Math.Min(inicio + _TamanoDePagina - 1, _Tbl_SalaEspera.Rows.Count - 1)
            dataTablePaginado.ImportRow(_Tbl_SalaEspera.Rows(i))
        Next

        With Grilla

            .DataSource = dataTablePaginado

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen_Estado").Width = 30
            .Columns("BtnImagen_Estado").HeaderText = "Est."
            .Columns("BtnImagen_Estado").Visible = True
            .Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NumeroDelItem").DefaultCellStyle.Font = New Font("Arial", 20, FontStyle.Bold)
            .Columns("NumeroDelItem").DefaultCellStyle.ForeColor = Color.Blue
            .Columns("NumeroDelItem").HeaderText = "TICKET Nro."
            .Columns("NumeroDelItem").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NumeroDelItem").DefaultCellStyle.Format = "0000"
            .Columns("NumeroDelItem").Visible = True
            .Columns("NumeroDelItem").Width = 130
            .Columns("NumeroDelItem").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 500
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado_Str").Visible = True
            .Columns("Estado_Str").HeaderText = "Estado"
            .Columns("Estado_Str").Width = 150
            .Columns("Estado_Str").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("InfoCliente").Visible = True
            .Columns("InfoCliente").HeaderText = "Información"
            .Columns("InfoCliente").Width = 400
            .Columns("InfoCliente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _DocConBeep = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Estado As String = _Fila.Cells("Estado").Value

            Dim _Icono As Image

            Dim _Imagenes_List As ImageList
            If Global_Thema = Enum_Themas.Oscuro Then
                _Imagenes_List = Imagenes_16x16_Dark
            Else
                _Imagenes_List = Imagenes_16x16
            End If

            _Icono = Nothing

            If _Estado = "FACTU" Or _Estado = "COMPL" Then
                _Icono = _Imagenes_List.Images.Item("ok.png")
            End If

            If _Estado = "NULO" Or _Estado = "CANCE" Then
                _Icono = _Imagenes_List.Images.Item("cancel.png")
            End If

            If _Estado = "PREPA" Then
                _Icono = _Imagenes_List.Images.Item("menu-more.png")
                _Fila.Cells("NOKOEN").Style.ForeColor = Color.Gray
                '_Fila.Cells("NOKOEN").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Icono

            _Fila.Cells("NumeroDelItem").Style.Font = New Font("Arial", 24, FontStyle.Bold)
            _Fila.Cells("NumeroDelItem").Style.ForeColor = Azul
            _Fila.Cells("NumeroDelItem").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            _Fila.Cells("NumeroDelItem").Style.Format = "00000"

            If _Fila.Cells("Estado").Value = "FACTU" Then
                If _Fila.Cells("Beep").Value = 0 Then
                    Console.Beep(500, 2000)
                    _DocConBeep += 1
                    _Fila.Cells("Beep").Value = 1
                End If
            End If

        Next

        'If _DocConBeep > 0 Then
        '    Console.Beep(500, 2000)
        '    Console.Beep(500, 2000)
        'End If

        Grilla.ClearSelection()
        Grilla.CurrentCell = Nothing
        Grilla.Focus()
    End Sub

    Private Sub Timer_Paginar_Tick(sender As Object, e As EventArgs) Handles Timer_Paginar.Tick

        Sb_MostrarRegistros()

        If _Actualizar Then
            _PaginaActual = 0 ' Volver a empezar si se alcanza el final
            Sb_Actualizar_Grilla()
        End If
        Lbl_Fecha.Text = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy") & "       Hora: " & DateTime.Now.ToString("HH:mm")

    End Sub

    Private Sub Timer_Parpadeo_Tick(sender As Object, e As EventArgs) Handles Timer_Parpadeo.Tick

        ' Asume que quieres hacer parpadear la celda en la fila 0, columna 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If parpadeo Then
                If _Fila.Cells("Estado").Value = "FACTU" Then
                    _Fila.Cells("NumeroDelItem").Style.BackColor = Grilla.DefaultCellStyle.BackColor
                End If
            Else
                If _Fila.Cells("Estado").Value = "FACTU" Then
                    _Fila.Cells("NumeroDelItem").Style.BackColor = Amarillo
                End If
            End If
            Me.Refresh()
        Next

        parpadeo = Not parpadeo

    End Sub

    Private Sub Timer_Beep_Tick(sender As Object, e As EventArgs) Handles Timer_Beep.Tick

        Timer_Beep.Stop()

        Dim _Beep0 = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stmp_SalaEspera", "Estado = 'FACTU' And Beep = 0")
        Dim _Beep1 = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stmp_SalaEspera", "Estado = 'FACTU' And Beep = 1")

        If _Beep0 = 0 AndAlso _Beep1 > 0 Then
            Console.Beep(500, 2000)
            Console.Beep(500, 2000)
        End If

        Timer_Beep.Start()

        'Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_SalaEspera Set Beep = 2 Where Estado = 'FACTU' And Beep = 0 "
        '_Sql.Ej_consulta_IDU(Consulta_sql)
    End Sub
End Class
