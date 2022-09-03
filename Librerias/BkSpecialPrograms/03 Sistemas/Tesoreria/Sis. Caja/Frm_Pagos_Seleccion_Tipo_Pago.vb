Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Seleccion_Tipo_Pago

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Filtro_Extrae_Sql As String
    Dim _Tidp_Seleccionado As Boolean

    Dim _Row_Tidp As DataRow

    Enum Enum_Cliente_Proveedor
        TIDP_Cli
        TIDP_Pro
    End Enum
    Dim _Cliente_Proveedo As Enum_Cliente_Proveedor

    Public ReadOnly Property Pro_Precio_Tidp_Seleccionado()
        Get
            Return _Tidp_Seleccionado
        End Get
    End Property

    Public Property Pro_Filtro_Extra_Sql() As String
        Get
            Return _Filtro_Extrae_Sql
        End Get
        Set(value As String)
            _Filtro_Extrae_Sql = value
        End Set
    End Property

    Public ReadOnly Property Pro_Row_Tidp() As DataRow
        Get
            Return _Row_Tidp
        End Get
    End Property

    Public Sub New(Cliente_Proveedor As Enum_Cliente_Proveedor)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Cliente_Proveedo = Cliente_Proveedor

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Mt04_Post_Seleccion_Tipo_Pago_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 10), Color.AliceBlue, ScrollBars.Vertical, False, True, False)

        InsertarBotonenGrilla(Grilla, "BtnImagen", "Est.", "Estado", 0, _Tipo_Boton.Imagen)

        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Pago
        AddHandler Btn_Aceptar.Click, AddressOf Sb_Seleccionar_Pago

        Sb_Actualizar_Grilla()

        Me.Top = Me.Top - 50

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _Cliente_Proveedo.ToString & "'" & vbCrLf &
                       _Filtro_Extrae_Sql & vbCrLf &
                       "Order by Orden"

        Dim _Tbl_Tidp As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Tidp

            OcultarEncabezadoGrilla(Grilla)

            .Columns("BtnImagen").Width = 20
            .Columns("BtnImagen").HeaderText = "Est."
            .Columns("BtnImagen").Visible = True

            .Columns("CodigoTabla").Width = 35
            .Columns("CodigoTabla").HeaderText = "Cód."
            .Columns("CodigoTabla").Visible = True

            .Columns("NombreTabla").Width = 380
            .Columns("NombreTabla").HeaderText = "Forma de pago"
            .Columns("NombreTabla").Visible = True

        End With

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Tidp = _Row.Cells("CodigoTabla").Value

            _Row.Cells("BtnImagen").Value = Fx_Imagen(_Tidp)

        Next

    End Sub

    Function Fx_Imagen(_Tidp As String) As Image

        Dim _Imagen As Image
        Dim _Objeto As ImageList

        If Global_Thema = Enum_Themas.Oscuro Then
            _Objeto = Lista_Imagnes_Pago_16_Dark
        Else
            _Objeto = Lista_Imagnes_Pago_16
        End If

        Select Case _Tidp.ToString
            Case "EFV", "EFC"
                _Imagen = _Objeto.Images.Item("money.png")
            Case "TJV", "TJC"
                _Imagen = _Objeto.Images.Item("credit-card-back.png")
            Case "CHV", "CHC"
                _Imagen = _Objeto.Images.Item("check.png")
            Case "LTV", "LTC"
                _Imagen = _Objeto.Images.Item("quote.png")
            Case "PAV", "PAC"
                _Imagen = _Objeto.Images.Item("quote.png")
            Case "DEP"
                _Imagen = _Objeto.Images.Item("bank-deposit.png")
            Case "ATB", "PTB"
                _Imagen = _Objeto.Images.Item("bank-transfer.png")
            Case "ncv", "ncc", "ncx", "nev", "blv", "fcv", "fcc", "fdc"
                _Imagen = _Objeto.Images.Item("document-text.png")
            Case "CTA"
                _Imagen = _Objeto.Images.Item("credit-card-front-customer.png")
            Case Else
                _Imagen = _Objeto.Images.Item("tag-price-red.png")
        End Select

        Return _Imagen

    End Function

    Sub Sb_Seleccionar_Pago()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Tabla = _Fila.Cells("Tabla").Value
        Dim _CodigoTabla = _Fila.Cells("CodigoTabla").Value

        Consulta_sql = "Select Top 1 CodigoTabla as TIDP,NombreTabla as Descripcion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _Tabla & "' And CodigoTabla = '" & _CodigoTabla & "'"

        _Row_Tidp = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Tidp_Seleccionado = True
        Me.Close()

    End Sub

    Private Sub Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Enter Then
            Me.Enabled = False
            'SendKeys.Send("{RIGHT}")
            SendKeys.Send("{BREAK}")
            e.Handled = True
            Sb_Seleccionar_Pago()
            Me.Enabled = True
        End If

    End Sub

    Private Sub Frm_Pagos_Seleccion_Tipo_Pago_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


End Class
