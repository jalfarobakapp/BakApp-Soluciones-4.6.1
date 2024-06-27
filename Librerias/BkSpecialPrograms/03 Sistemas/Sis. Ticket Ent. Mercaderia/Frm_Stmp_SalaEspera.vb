Public Class Frm_Stmp_SalaEspera

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_SalaEspera As DataTable
    Private _PaginaActual As Integer = 0
    Public Property _TamanoDePagina As Integer = 20
    Private _TotalDePaginas As Integer
    Private _Dv As DataView
    Private _Actualizar As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 45, New Font("Tahoma", 14), Color.AliceBlue, ScrollBars.Both, False, False, False)

    End Sub

    Private Sub Frm_Stmp_SalaEspera_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _TamanoDePagina = 12

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()
        Sb_MostrarRegistros()

        Timer_Paginar.Interval = (1000 * 10)
        Timer_Paginar.Start()
        CircularPgrs.IsRunning = True

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        _Condicion = vbCrLf & "And Estado = 'FACTU' Or (Estado = 'PREPA' And Planificada = 1 And Facturar = 1)"

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

        Consulta_sql = My.Resources.Recursos_WmsVillar.SQLQuery_Listado_Stmp
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)
        Consulta_sql = Replace(Consulta_sql, "--#Condicion#", _Condicion)
        Consulta_sql = Replace(Consulta_sql, "Select * From #Paso Order by Tido,Nudo", "Select * From #Paso Order by Numero")
        'Consulta_sql = Replace(Consulta_sql, "--#Select_Paginacion#", _Select_Paginacion)

        _Tbl_SalaEspera = _Sql.Fx_Get_DataTable(Consulta_sql)

        ' Asegúrate de que la columna exista
        If Not _Tbl_SalaEspera.Columns.Contains("NumeroDelItem") Then
            _Tbl_SalaEspera.Columns.Add("NumeroDelItem", GetType(Integer))
        End If

        For Each row As DataRow In _Tbl_SalaEspera.Rows
            'row("NumeroDelItem") = _Tbl_SalaEspera.Rows.IndexOf(row) + 1
            row("NumeroDelItem") = CInt(Replace(row.Item("Numero"), "#T", ""))
        Next

        ' Calcular el número total de páginas
        Dim totalDeRegistros As Integer = _Tbl_SalaEspera.Rows.Count
        _TotalDePaginas = Math.Ceiling(totalDeRegistros / _TamanoDePagina)

        _Actualizar = False

    End Sub

    Private Sub Sb_MostrarRegistros()

        Dim _TotalDePaginas As Integer = Math.Ceiling(_Tbl_SalaEspera.Rows.Count / _TamanoDePagina)
        _PaginaActual += 1

        If _PaginaActual > _TotalDePaginas Then
            _Actualizar = True
            Return
        End If

        Lbl_Estatus.Text = "Pagina: " & _PaginaActual & " de " & _TotalDePaginas

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
            .Columns("NumeroDelItem").HeaderText = "Item"
            .Columns("NumeroDelItem").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NumeroDelItem").DefaultCellStyle.Format = "0000"
            .Columns("NumeroDelItem").Visible = True
            .Columns("NumeroDelItem").Width = 130
            .Columns("NumeroDelItem").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Numero").Visible = True
            '.Columns("Numero").HeaderText = "#Ticket"
            '.Columns("Numero").Width = 110
            '.Columns("Numero").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Tido").Visible = True
            '.Columns("Tido").HeaderText = "TD"
            '.Columns("Tido").Width = 30
            '.Columns("Tido").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Nudo").Visible = True
            '.Columns("Nudo").HeaderText = "Número"
            '.Columns("Nudo").Width = 70
            '.Columns("Nudo").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 400
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

            '.Columns("FechaFactu").Visible = _TidoGen
            '.Columns("FechaFactu").HeaderText = "F.Factu."
            '.Columns("FechaFactu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("FechaFactu").DefaultCellStyle.Format = "dd/MM/yyyy"
            '.Columns("FechaFactu").Width = 70
            '.Columns("FechaFactu").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("HoraFactu").Visible = _TidoGen
            '.Columns("HoraFactu").HeaderText = "H.Factu."
            '.Columns("HoraFactu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("HoraFactu").DefaultCellStyle.Format = "HH:mm"
            '.Columns("HoraFactu").Width = 50
            '.Columns("HoraFactu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

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
                _Icono = _Imagenes_List.Images.Item("clock.png.png")
                _Fila.Cells("NOKOEN").Style.ForeColor = Color.Gray
                _Fila.Cells("NOKOEN").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Icono

            _Fila.Cells("NumeroDelItem").Style.Font = New Font("Arial", 24, FontStyle.Bold)
            _Fila.Cells("NumeroDelItem").Style.ForeColor = Azul
            _Fila.Cells("NumeroDelItem").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            _Fila.Cells("NumeroDelItem").Style.Format = "0000"

        Next

    End Sub

    Private Sub Timer_Paginar_Tick(sender As Object, e As EventArgs) Handles Timer_Paginar.Tick

        Sb_MostrarRegistros()

        If _Actualizar Then
            _PaginaActual = 0 ' Volver a empezar si se alcanza el final
            Sb_Actualizar_Grilla()
        End If

    End Sub

End Class
