'Imports Lib_Bakapp_VarClassFunc
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DocumentFormat.OpenXml.Vml

Public Class Frm_Kardex_Informe_X_Producto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _Row_Producto As DataRow
    Dim _Codigo As String
    Dim _Unidad As Integer

    Dim _TblKardex As DataTable
    Dim _Marcar_dos As Boolean
    Dim _Pasada As Integer = 1
    Dim _Todas_Las_Bodegas As Boolean

    Private _DecimalesGl As Integer = 0

    Public Property Pro_Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(value As String)
            _Empresa = value
        End Set
    End Property
    Public Property Pro_Sucursal() As String
        Get
            Return _Sucursal
        End Get
        Set(value As String)
            _Sucursal = value
        End Set
    End Property
    Public Property Pro_Bodega() As String
        Get
            Return _Bodega
        End Get
        Set(value As String)
            _Bodega = value
        End Set
    End Property
    Public Property Pro_Row_Producto() As DataRow
        Get
            Return _Row_Producto
        End Get
        Set(value As DataRow)
            _Row_Producto = value
        End Set
    End Property
    Public Property Pro_Unidad() As Integer
        Get
            Return _Unidad
        End Get
        Set(value As Integer)
            _Unidad = value
        End Set
    End Property
    Public Property Pro_TblKardex() As DataTable
        Get
            Return _TblKardex
        End Get
        Set(value As DataTable)
            _TblKardex = value
        End Set
    End Property
    Public Property Pro_Marcar_dos() As Boolean
        Get
            Return _Marcar_dos
        End Get
        Set(value As Boolean)
            _Marcar_dos = value
        End Set
    End Property
    Public Property Pro_Grilla() As DataGridViewX
        Get
            Return GrillaKardex
        End Get
        Set(value As DataGridViewX)
            GrillaKardex = value
        End Set
    End Property

    Public Sub New(Codigo As String, Unidad As String, Marcar_dos As Boolean, Todas_Las_Bodegas As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(GrillaKardex, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        GrillaKardex.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        _Codigo = Codigo
        _Unidad = Unidad
        _Marcar_dos = Marcar_dos
        _Todas_Las_Bodegas = Todas_Las_Bodegas

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_InsertarBotonenGrilla(GrillaKardex, "Orden", "I", "Or", 0, _Tipo_Boton.Texto)

        If Fx_Tiene_Permiso(Me, "NO00001", , False) Then

            TxtPrecioUnitario.PasswordChar = "*"
            TxtDsctoLinea.PasswordChar = "*"
            TxtValorNetoLinea.PasswordChar = "*"
            TxtPrecioNetoReal.PasswordChar = "*"
            TxtPrPromPonderado.PasswordChar = "*"

        End If

    End Sub

    Private Sub Frm_DocumentoKardex_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AddHandler GrillaKardex.CellEnter, AddressOf Sb_CellEnter

        Lbl_NroDecimales.Text = FormatNumber(0, _DecimalesGl)

        Sb_CellEnter()
        'Sb_Llenar_Grilla(_TblKardex)
        Sb_Formato_Grilla_Detalle()

        Dim _Texto = String.Empty

        If _Todas_Las_Bodegas Then

            _Texto = "Movimientos y situación de Stock de todas las bodegas de la empresa..."

        Else

            Dim _Row_Bodega As DataRow = Fx_Trar_Datos_De_Bodega_Seleccionada(_Empresa, _Sucursal, _Bodega)
            _Texto = "Movimientos y situación de Stock, Sucursal: " & Trim(_Row_Bodega.Item("NOKOSU")) &
                  ", Bodega: " & Trim(_Row_Bodega.Item("NOKOBO")) & " (" & Trim(_Sucursal) & " - " & Trim(_Bodega) & ")"

        End If

        If _Unidad = 1 Then
            Me.Text = "Primera Unidad - " & _Texto
        Else
            Me.Text = "Segunda Unidad - " & _Texto
        End If

        Me.Text = _Texto

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Sub Sb_Llenar_Grilla(_TblKardex As DataTable)

        With GrillaKardex

            .DataSource = _TblKardex

            OcultarEncabezadoGrilla(GrillaKardex, True)

            Dim _Nveces As String = New String("0", _DecimalesGl)
            Dim _FormatoPrecio As String

            If Not String.IsNullOrEmpty(_Nveces) Then
                _Nveces = "." & _Nveces
            End If

            Dim _DisplayIndex = 0

            .Columns("TIDO").DisplayIndex = 0
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").DisplayIndex = 1
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 75
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").HeaderText = "F.Emisión"
            .Columns("FEEMLI").Width = 70
            .Columns("FEEMLI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NULIDO").DisplayIndex = 2
            .Columns("NULIDO").HeaderText = "Lín"
            .Columns("NULIDO").Width = 35
            .Columns("NULIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NULIDO").Visible = True
            .Columns("NULIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("BOSULIDO").DisplayIndex = 3
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Width = 35
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO" & _Unidad).DisplayIndex = 4
            .Columns("CAPRCO" & _Unidad).HeaderText = "Cantidad"
            .Columns("CAPRCO" & _Unidad).Width = 65
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = _FormatoPrecio '"###,#0.###"
            .Columns("CAPRCO" & _Unidad).Visible = True
            .Columns("CAPRCO" & _Unidad).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sfisico").DisplayIndex = 5
            .Columns("Sfisico").HeaderText = ""
            .Columns("Sfisico").Width = 20
            .Columns("Sfisico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Sfisico").Visible = True
            .Columns("Sfisico").DefaultCellStyle.ForeColor = Rojo
            .Columns("Sfisico").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("STFISICO").DisplayIndex = 6
            .Columns("STFISICO").HeaderText = "Stock Físico"
            .Columns("STFISICO").Width = 60
            .Columns("STFISICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFISICO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("STFISICO").Visible = True
            .Columns("STFISICO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sdevengado").DisplayIndex = 7
            .Columns("Sdevengado").HeaderText = ""
            .Columns("Sdevengado").Width = 20
            .Columns("Sdevengado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Sdevengado").Visible = True
            .Columns("Sdevengado").DefaultCellStyle.ForeColor = Rojo
            .Columns("Sdevengado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DEVENGADO").DisplayIndex = 8
            .Columns("DEVENGADO").HeaderText = "Devengado"
            .Columns("DEVENGADO").Width = 70
            .Columns("DEVENGADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DEVENGADO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("DEVENGADO").Visible = True
            .Columns("DEVENGADO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sdespsfact").DisplayIndex = 9
            .Columns("Sdespsfact").HeaderText = ""
            .Columns("Sdespsfact").Width = 20
            .Columns("Sdespsfact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Sdespsfact").Visible = True
            .Columns("Sdespsfact").DefaultCellStyle.ForeColor = Rojo
            .Columns("Sdespsfact").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DESPSFACTURAR").DisplayIndex = 10
            .Columns("DESPSFACTURAR").HeaderText = "Desp. S/Fac"
            .Columns("DESPSFACTURAR").Width = 60
            .Columns("DESPSFACTURAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DESPSFACTURAR").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("DESPSFACTURAR").Visible = True
            .Columns("DESPSFACTURAR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Scomprometido").DisplayIndex = 11
            .Columns("Scomprometido").HeaderText = ""
            .Columns("Scomprometido").Width = 20
            .Columns("Scomprometido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Scomprometido").Visible = True
            .Columns("Scomprometido").DefaultCellStyle.ForeColor = Rojo
            .Columns("Scomprometido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COMPROMETIDO").DisplayIndex = 12
            .Columns("COMPROMETIDO").HeaderText = "Compro."
            .Columns("COMPROMETIDO").Width = 70
            .Columns("COMPROMETIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COMPROMETIDO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("COMPROMETIDO").Visible = True
            .Columns("COMPROMETIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Scompranorecep").DisplayIndex = 13
            .Columns("Scompranorecep").HeaderText = ""
            .Columns("Scompranorecep").Width = 20
            .Columns("Scompranorecep").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Scompranorecep").Visible = True
            .Columns("Scompranorecep").DefaultCellStyle.ForeColor = Rojo
            .Columns("Scompranorecep").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COMPRANREC").DisplayIndex = 14
            .Columns("COMPRANREC").HeaderText = "Compra N/R"
            .Columns("COMPRANREC").Width = 60
            .Columns("COMPRANREC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COMPRANREC").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("COMPRANREC").Visible = True
            .Columns("COMPRANREC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Srecesfact").DisplayIndex = 15
            .Columns("Srecesfact").HeaderText = ""
            .Columns("Srecesfact").Width = 20
            .Columns("Srecesfact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Srecesfact").Visible = True
            .Columns("Srecesfact").DefaultCellStyle.ForeColor = Rojo
            .Columns("Srecesfact").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RECEPSFAC").DisplayIndex = 16
            .Columns("RECEPSFAC").HeaderText = "Recep. S/F"
            .Columns("RECEPSFAC").Width = 60
            .Columns("RECEPSFAC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RECEPSFAC").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("RECEPSFAC").Visible = True
            .Columns("RECEPSFAC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Spedido").DisplayIndex = 17
            .Columns("Spedido").HeaderText = ""
            .Columns("Spedido").Width = 20
            .Columns("Spedido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Spedido").Visible = True
            .Columns("Spedido").DefaultCellStyle.ForeColor = Rojo
            .Columns("Spedido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PEDIDO").DisplayIndex = 18
            .Columns("PEDIDO").HeaderText = "Pedido"
            .Columns("PEDIDO").Width = 70
            .Columns("PEDIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PEDIDO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("PEDIDO").Visible = True
            .Columns("PEDIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Formato_Grilla_Detalle()

        With GrillaKardex

            '.DataSource = _TblKardex

            OcultarEncabezadoGrilla(GrillaKardex, True)

            Dim _Nveces As String = New String("0", _DecimalesGl)
            Dim _FormatoPrecio As String

            If Not String.IsNullOrEmpty(_Nveces) Then
                _Nveces = "." & _Nveces
            End If

            _FormatoPrecio = "###,#0" & _Nveces

            Dim _DisplayIndex = 0

            .Columns("TIDO").DisplayIndex = 0
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").DisplayIndex = 1
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 75
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").HeaderText = "F.Emisión"
            .Columns("FEEMLI").Width = 70
            .Columns("FEEMLI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NULIDO").DisplayIndex = 2
            .Columns("NULIDO").HeaderText = "Lín"
            .Columns("NULIDO").Width = 35
            .Columns("NULIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NULIDO").Visible = True
            .Columns("NULIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("BOSULIDO").DisplayIndex = 3
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Width = 35
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO" & _Unidad).DisplayIndex = 4
            .Columns("CAPRCO" & _Unidad).HeaderText = "Cantidad"
            .Columns("CAPRCO" & _Unidad).Width = 65
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = _FormatoPrecio '"###,#0.###"
            .Columns("CAPRCO" & _Unidad).Visible = True
            .Columns("CAPRCO" & _Unidad).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sfisico").DisplayIndex = 5
            .Columns("Sfisico").HeaderText = ""
            .Columns("Sfisico").Width = 20
            .Columns("Sfisico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Sfisico").Visible = True
            .Columns("Sfisico").DefaultCellStyle.ForeColor = Rojo
            .Columns("Sfisico").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("STFISICO").DisplayIndex = 6
            .Columns("STFISICO").HeaderText = "Stock Físico"
            .Columns("STFISICO").Width = 60
            .Columns("STFISICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFISICO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("STFISICO").Visible = True
            .Columns("STFISICO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sdevengado").DisplayIndex = 7
            .Columns("Sdevengado").HeaderText = ""
            .Columns("Sdevengado").Width = 20
            .Columns("Sdevengado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Sdevengado").Visible = True
            .Columns("Sdevengado").DefaultCellStyle.ForeColor = Rojo
            .Columns("Sdevengado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DEVENGADO").DisplayIndex = 8
            .Columns("DEVENGADO").HeaderText = "Devengado"
            .Columns("DEVENGADO").Width = 70
            .Columns("DEVENGADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DEVENGADO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("DEVENGADO").Visible = True
            .Columns("DEVENGADO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sdespsfact").DisplayIndex = 9
            .Columns("Sdespsfact").HeaderText = ""
            .Columns("Sdespsfact").Width = 20
            .Columns("Sdespsfact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Sdespsfact").Visible = True
            .Columns("Sdespsfact").DefaultCellStyle.ForeColor = Rojo
            .Columns("Sdespsfact").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DESPSFACTURAR").DisplayIndex = 10
            .Columns("DESPSFACTURAR").HeaderText = "Desp. S/Fac"
            .Columns("DESPSFACTURAR").Width = 60
            .Columns("DESPSFACTURAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DESPSFACTURAR").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("DESPSFACTURAR").Visible = True
            .Columns("DESPSFACTURAR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Scomprometido").DisplayIndex = 11
            .Columns("Scomprometido").HeaderText = ""
            .Columns("Scomprometido").Width = 20
            .Columns("Scomprometido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Scomprometido").Visible = True
            .Columns("Scomprometido").DefaultCellStyle.ForeColor = Rojo
            .Columns("Scomprometido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COMPROMETIDO").DisplayIndex = 12
            .Columns("COMPROMETIDO").HeaderText = "Compro."
            .Columns("COMPROMETIDO").Width = 70
            .Columns("COMPROMETIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COMPROMETIDO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("COMPROMETIDO").Visible = True
            .Columns("COMPROMETIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Scompranorecep").DisplayIndex = 13
            .Columns("Scompranorecep").HeaderText = ""
            .Columns("Scompranorecep").Width = 20
            .Columns("Scompranorecep").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Scompranorecep").Visible = True
            .Columns("Scompranorecep").DefaultCellStyle.ForeColor = Rojo
            .Columns("Scompranorecep").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("COMPRANREC").DisplayIndex = 14
            .Columns("COMPRANREC").HeaderText = "Compra N/R"
            .Columns("COMPRANREC").Width = 60
            .Columns("COMPRANREC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COMPRANREC").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("COMPRANREC").Visible = True
            .Columns("COMPRANREC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Srecesfact").DisplayIndex = 15
            .Columns("Srecesfact").HeaderText = ""
            .Columns("Srecesfact").Width = 20
            .Columns("Srecesfact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Srecesfact").Visible = True
            .Columns("Srecesfact").DefaultCellStyle.ForeColor = Rojo
            .Columns("Srecesfact").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RECEPSFAC").DisplayIndex = 16
            .Columns("RECEPSFAC").HeaderText = "Recep. S/F"
            .Columns("RECEPSFAC").Width = 60
            .Columns("RECEPSFAC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RECEPSFAC").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("RECEPSFAC").Visible = True
            .Columns("RECEPSFAC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Spedido").DisplayIndex = 17
            .Columns("Spedido").HeaderText = ""
            .Columns("Spedido").Width = 20
            .Columns("Spedido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Spedido").Visible = True
            .Columns("Spedido").DefaultCellStyle.ForeColor = Rojo
            .Columns("Spedido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PEDIDO").DisplayIndex = 18
            .Columns("PEDIDO").HeaderText = "Pedido"
            .Columns("PEDIDO").Width = 70
            .Columns("PEDIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PEDIDO").DefaultCellStyle.Format = _FormatoPrecio '"###,##.###"
            .Columns("PEDIDO").Visible = True
            .Columns("PEDIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub GrillaKardex_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaKardex.CellDoubleClick

        Me.Enabled = False

        Dim _Idmaeedo As Integer = GrillaKardex.Rows(GrillaKardex.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim _Idmaeddo = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEDDO", "IDMAEEDO = " & _Idmaeedo & " And KOPRCT = '" & _Codigo & "'")

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL) ', _Idmaeddo)
        Fm.Idrst = _Idmaeddo
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    'Sub Sb_MarcarGrilla(Grilla As DataGridView)

    '    'Progreso_Porc.Value = 0
    '    Progreso_Cont.Value = 0

    '    Try

    '        With Grilla

    '            Progreso_Cont.Maximum = .Rows.Count

    '            Dim STFISICO,
    '                DEVENGADO,
    '                DESPSFACTURAR,
    '                COMPROMETIDO,
    '                COMPRANREC,
    '                RECEPSFAC,
    '                PEDIDO As Double

    '            Dim STFISICO_,
    '                DEVENGADO_,
    '                DESPSFACTURAR_,
    '                COMPROMETIDO_,
    '                COMPRANREC_,
    '                RECEPSFAC_,
    '                PEDIDO_ As Double


    '            Dim i = 0
    '            For Each row As DataGridViewRow In .Rows

    '                i = row.Index

    '                System.Windows.Forms.Application.DoEvents()

    '                STFISICO = row.Cells("STFISICO").Value
    '                STFISICO_ = STFISICO_ + STFISICO

    '                DEVENGADO = row.Cells("DEVENGADO").Value
    '                DEVENGADO_ = DEVENGADO_ + DEVENGADO

    '                DESPSFACTURAR = row.Cells("DESPSFACTURAR").Value
    '                DESPSFACTURAR_ = DESPSFACTURAR_ + DESPSFACTURAR

    '                COMPROMETIDO = row.Cells("COMPROMETIDO").Value
    '                COMPROMETIDO_ = COMPROMETIDO_ + COMPROMETIDO

    '                COMPRANREC = row.Cells("COMPRANREC").Value
    '                COMPRANREC_ = COMPRANREC_ + COMPRANREC

    '                RECEPSFAC = row.Cells("RECEPSFAC").Value
    '                RECEPSFAC_ = RECEPSFAC_ + RECEPSFAC

    '                PEDIDO = row.Cells("PEDIDO").Value
    '                PEDIDO_ = PEDIDO_ + PEDIDO

    '                Dim SUBTIDO As String = row.Cells("SUBTIDO").Value

    '                If _Pasada = 1 Then

    '                    If SUBTIDO = "AJU" Then

    '                        .Rows.Item(i).DefaultCellStyle.BackColor = Color.Yellow

    '                        If Global_Thema = Enum_Themas.Oscuro Then
    '                            .Rows.Item(i).DefaultCellStyle.ForeColor = Color.Black
    '                        End If

    '                    End If

    '                    If CBool(STFISICO) Then
    '                        .Rows.Item(i).Cells("Sfisico").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                        .Rows.Item(i).Cells("Sfisico").Style.ForeColor = Color.Red
    '                        .Rows.Item(i).Cells("Sfisico").Value = ">"
    '                    End If

    '                    If CBool(DEVENGADO) Then
    '                        .Rows.Item(i).Cells("Sdevengado").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                        .Rows.Item(i).Cells("Sdevengado").Style.ForeColor = Color.Red
    '                        .Rows.Item(i).Cells("Sdevengado").Value = ">"
    '                    End If

    '                    If CBool(DESPSFACTURAR) Then
    '                        .Rows.Item(i).Cells("Sdespsfact").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                        .Rows.Item(i).Cells("Sdespsfact").Style.ForeColor = Color.Red
    '                        .Rows.Item(i).Cells("Sdespsfact").Value = ">"
    '                    End If

    '                    If CBool(COMPROMETIDO) Then
    '                        .Rows.Item(i).Cells("Scomprometido").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                        .Rows.Item(i).Cells("Scomprometido").Style.ForeColor = Color.Red
    '                        .Rows.Item(i).Cells("Scomprometido").Value = ">"
    '                    End If

    '                    If CBool(COMPRANREC) Then
    '                        .Rows.Item(i).Cells("Scompranorecep").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                        .Rows.Item(i).Cells("Scompranorecep").Style.ForeColor = Color.Red
    '                        .Rows.Item(i).Cells("Scompranorecep").Value = ">"
    '                    End If

    '                    If CBool(RECEPSFAC) Then
    '                        .Rows.Item(i).Cells("Srecesfact").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                        .Rows.Item(i).Cells("Srecesfact").Style.ForeColor = Color.Red
    '                        .Rows.Item(i).Cells("Srecesfact").Value = ">"
    '                    End If

    '                    If CBool(PEDIDO) Then
    '                        .Rows.Item(i).Cells("Spedido").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                        .Rows.Item(i).Cells("Spedido").Style.ForeColor = Color.Red
    '                        .Rows.Item(i).Cells("Spedido").Value = ">"
    '                    End If

    '                End If

    '                If Not _Marcar_dos Then

    '                    .Rows.Item(i).Cells("STFISICO").Value = STFISICO_
    '                    .Rows.Item(i).Cells("DEVENGADO").Value = DEVENGADO_
    '                    .Rows.Item(i).Cells("DESPSFACTURAR").Value = DESPSFACTURAR_
    '                    .Rows.Item(i).Cells("COMPROMETIDO").Value = COMPROMETIDO_
    '                    .Rows.Item(i).Cells("COMPRANREC").Value = COMPRANREC_
    '                    .Rows.Item(i).Cells("RECEPSFAC").Value = RECEPSFAC_
    '                    .Rows.Item(i).Cells("PEDIDO").Value = PEDIDO_
    '                    .Rows.Item(i).Cells("Orden").Value = i

    '                End If

    '                System.Windows.Forms.Application.DoEvents()
    '                'Contador += 1
    '                'Progreso_Porc.Value = ((Contador * 100) / Tbl_Detalle_Aj.Rows.Count) 'Mas
    '                Progreso_Cont.Value += 1


    '            Next

    '            If _Marcar_dos Then

    '                Consulta_sql = "Select * From MAEST" & vbCrLf &
    '                               "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal &
    '                               "'  And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'"
    '                Dim _TblMaest As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

    '                'MST.STFI#Ud#,        -- STOCK FISICO
    '                'MST.STDV#Ud#,        -- STOCK DEVENGADO
    '                'MST.DESPNOFAC#Ud#,   -- DESPACHADO SIN FACTURAR 
    '                'MST.STOCNV#Ud#,      -- STOCK COMPROMETIDO
    '                'MST.STDV#Ud#C,       -- COMPRAS NO RECEPCIONADAS
    '                'MST.RECENOFAC#Ud#,   -- RECEPCIONADO SIN FACTURAR
    '                'MST.STOCNV#Ud#C,     -- STOCK PEDIDO

    '                STFISICO = _TblMaest.Rows(0).Item("STFI" & _Unidad) + -STFISICO_
    '                DEVENGADO = _TblMaest.Rows(0).Item("STDV" & _Unidad) + -DEVENGADO_
    '                DESPSFACTURAR = _TblMaest.Rows(0).Item("DESPNOFAC" & _Unidad) + -DESPSFACTURAR_
    '                COMPROMETIDO = _TblMaest.Rows(0).Item("STOCNV" & _Unidad) + -COMPROMETIDO_
    '                COMPRANREC = _TblMaest.Rows(0).Item("STDV" & _Unidad) + -COMPRANREC_
    '                RECEPSFAC = _TblMaest.Rows(0).Item("RECENOFAC" & _Unidad) + -RECEPSFAC_
    '                PEDIDO = _TblMaest.Rows(0).Item("STOCNV" & _Unidad & "C") + -PEDIDO_

    '                .Rows.Item(0).Cells("STFISICO").Value = STFISICO
    '                .Rows.Item(0).Cells("DEVENGADO").Value = DEVENGADO
    '                .Rows.Item(0).Cells("DESPSFACTURAR").Value = DESPSFACTURAR
    '                .Rows.Item(0).Cells("COMPROMETIDO").Value = COMPROMETIDO
    '                .Rows.Item(0).Cells("COMPRANREC").Value = COMPRANREC
    '                .Rows.Item(0).Cells("RECEPSFAC").Value = RECEPSFAC
    '                .Rows.Item(0).Cells("PEDIDO").Value = PEDIDO
    '                _Marcar_dos = False
    '                _Pasada += 1
    '                'Sb_MarcarGrilla(Grilla)

    '            End If

    '        End With
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub GrillaKardex_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles GrillaKardex.Scroll
        'GrillaKardex.CurrentCell = GrillaKardex.Rows(e.NewValue).Cells("TIDO")
    End Sub

    Sub Sb_CellEnter()

        Dim _Fila As DataGridViewRow = GrillaKardex.Rows(GrillaKardex.CurrentRow.Index)

        Dim FECHA As String = FormatDateTime(_Fila.Cells("FEEMLI").Value, DateFormat.ShortDate)
        Dim HORA As String = _Fila.Cells("HORA").Value
        Dim NOKOEN As String = _Fila.Cells("NOKOEN").Value
        Dim TIDOPA As String = _Fila.Cells("TIDOPA").Value
        Dim NUDOPA As String = _Fila.Cells("NUDOPA").Value
        Dim SUBTIDO As String = _Fila.Cells("SUBTIDO").Value

        Dim NULOTE As String = _Fila.Cells("NULOTE").Value
        Dim SUBLOTE As String = _Fila.Cells("SUBLOTE").Value
        Dim VANELI As Double = _Fila.Cells("VANELI").Value
        Dim VADTNELI As Double = _Fila.Cells("VADTNELI").Value
        Dim PPPRNE As Double = _Fila.Cells("PPPRNE").Value
        Dim PPPRNERE As Double = _Fila.Cells("PPPRNERE" & _Unidad).Value
        Dim PPPRPM As Double = _Fila.Cells("PPPRPM").Value
        Dim PPPRPMSUC As Double = 0

        Dim _Descripcion As String = _Row_Producto.Item("NOKOPR")

        TxtDescripcionProducto.Text = _Codigo.Trim & " - " & _Descripcion.Trim
        TxtNroLote.Text = NULOTE

        If String.IsNullOrWhiteSpace(TIDOPA.Trim & NUDOPA.Trim) Then
            TxtTidopa.Text = String.Empty
        Else
            TxtTidopa.Text = TIDOPA & " - " & NUDOPA
        End If

        TxtFechaEmisionHora.Text = Trim(FECHA) & " - " & Trim(HORA)

        TxtPrecioUnitario.Text = FormatCurrency(PPPRNE, 0)
        TxtDsctoLinea.Text = FormatCurrency(VADTNELI, 0)
        TxtValorNetoLinea.Text = FormatCurrency(VANELI, 0)
        TxtPrecioNetoReal.Text = FormatCurrency(PPPRNERE, 0)
        TxtPrPromPonderado.Text = FormatCurrency(PPPRPM, 0)

        If SUBTIDO = "AJU" Then
            TxtEntidad.Text = "<< AJUSTE >>"
        Else
            TxtEntidad.Text = NOKOEN
        End If

    End Sub

    Private Sub GrillaKardex_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles GrillaKardex.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With GrillaKardex
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    '.CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub BtnIrAptincipio_Click(sender As System.Object, e As System.EventArgs) Handles BtnIrAptincipio.Click

        If CBool(GrillaKardex.RowCount) Then
            GrillaKardex.FirstDisplayedScrollingRowIndex = 0
            GrillaKardex.CurrentCell = GrillaKardex.Rows(0).Cells("NUDO")
        End If

    End Sub

    Private Sub GrillaKardex_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles GrillaKardex.CellFormatting

        Dim _Columname As String = GrillaKardex.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = GrillaKardex.Rows(e.RowIndex)

        Dim _Subtido As String = _Fila.Cells("SUBTIDO").Value

        If _Subtido = "AJU" Then

            _Fila.DefaultCellStyle.BackColor = Color.Yellow

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

        End If

        If _Columname = "Sfisico" Or
           _Columname = "Sdevengado" Or
           _Columname = "Sdespsfact" Or
           _Columname = "Scomprometido" Or
           _Columname = "Scompranorecep" Or
           _Columname = "Srecesfact" Or
           _Columname = "Spedido" Then

            If Not String.IsNullOrWhiteSpace(_Fila.Cells(_Columname).Value) Then

                '_Fila.Cells(_Columname).Style.BackColor = Rojo
                '_Fila.Cells(_Columname).Style.ForeColor = Color.White

                _Fila.Cells(_Columname).Style.ForeColor = Rojo
                _Fila.Cells(_Columname).Style.Font = New Font("Arial Black", 10, FontStyle.Bold)

            End If

        End If

    End Sub

    Private Sub Btn_DecimalAgregar_Click(sender As Object, e As EventArgs) Handles Btn_DecimalAgregar.Click

        If _DecimalesGl < 3 Then _DecimalesGl += 1
        Lbl_NroDecimales.Text = FormatNumber(0, _DecimalesGl)
        Dim _Palabra = Letras(_DecimalesGl)
        Lbl_NroDecimales.Tooltip = _Palabra & " decimal(es)"
        Sb_Formato_Grilla_Detalle()

    End Sub

    Private Sub Btn_DecimalRestar_Click(sender As Object, e As EventArgs) Handles Btn_DecimalRestar.Click

        If _DecimalesGl > 0 And _DecimalesGl <= 3 Then _DecimalesGl -= 1
        Lbl_NroDecimales.Text = FormatNumber(0, _DecimalesGl)
        Dim _Palabra = Letras(_DecimalesGl)
        Lbl_NroDecimales.Tooltip = _Palabra & " decimal(es)"
        Sb_Formato_Grilla_Detalle()

    End Sub

    Private Sub BtnIrAlFin_Click(sender As System.Object, e As System.EventArgs) Handles BtnIrAlFin.Click
        If CBool(GrillaKardex.RowCount) Then
            GrillaKardex.FirstDisplayedScrollingRowIndex = GrillaKardex.RowCount - 1
            GrillaKardex.CurrentCell = GrillaKardex.Rows(GrillaKardex.RowCount - 1).Cells("NUDO")
        End If
    End Sub

    Private Sub Frm_DocumentoKardex_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


End Class
