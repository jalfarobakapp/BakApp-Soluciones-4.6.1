Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient


Public Class Frm_FiltroInf_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _TipoDeFiltro As String
    Dim _CodInforme As String
    Dim _EsNumero As Boolean
    Dim _Campo_In As String
    Dim _Chekeado As Boolean
    Dim _SoloChequear As Boolean
    Dim _Aceptar As Boolean
    Dim _Documentos_Filtro As String

    Dim _Tbl_Seleccionados As DataTable

    Dim TblFiltro, Campo1, Campo2, Condicion As String
    Dim Datos As New DsFiltros

    Public Property Pro_TipoDeFiltro As String
        Get
            Return _TipoDeFiltro
        End Get
        Set(value As String)
            _TipoDeFiltro = value
        End Set
    End Property
    Public Property Pro_CodInforme As String
        Get
            Return _CodInforme
        End Get
        Set(value As String)
            _CodInforme = value
        End Set
    End Property
    Public Property Pro_EsNumero As Boolean
        Get
            Return _EsNumero
        End Get
        Set(value As Boolean)
            _EsNumero = value
        End Set
    End Property
    Public Property Pro_Campo_In As String
        Get
            Return _Campo_In
        End Get
        Set(value As String)
            _Campo_In = value
        End Set
    End Property
    Public Property Pro_Chekeado As Boolean
        Get
            Return _Chekeado
        End Get
        Set(value As Boolean)
            _Chekeado = value
        End Set
    End Property
    Public Property Pro_SoloChequear As Boolean
        Get
            Return _SoloChequear
        End Get
        Set(value As Boolean)
            _SoloChequear = value
        End Set
    End Property
    Public Property Pro_Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property
    Public Property Pro_Documentos_Filtro As String
        Get
            Return _Documentos_Filtro
        End Get
        Set(value As String)
            _Documentos_Filtro = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Grilla.RowHeadersVisible = True

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        _Tbl_Seleccionados = Datos.Tables("Filtro")
        _Aceptar = True

        If Not _SoloChequear Then
            Grilla.Refresh()
            _Chekeado = ChkSeleccionar.Checked

            Dim Filtro As String

            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_TblFiltro_InfxUs" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = '" & _CodInforme & "' And Tabla = '" & _TipoDeFiltro & "'"
            _Sql.Ej_consulta_IDU(Consulta_Sql)

            If ChkSeleccionar.Checked Then

                Consulta_Sql =
                 "Insert Into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario,Informe,Tabla,Codigo,Filtro,MarcarTodo)" & vbCrLf &
                 "Values ('" & FUNCIONARIO & "','" & _CodInforme &
                 "','" & _TipoDeFiltro & "','" & _Campo_In & "','''Ver Todo''',1)"

            Else

                Filtro = Generar_Filtro_IN(Datos.Tables("Filtro"), "Chk", "Codigo", False, True)

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario, Informe, Tabla, Codigo,Filtro,MarcarTodo)" & vbCrLf &
                               "Values ('" & FUNCIONARIO & "','" & _CodInforme &
                               "','" & _TipoDeFiltro & "','" & _Campo_In & "','" & Filtro & "',0)"

            End If
            _Sql.Ej_consulta_IDU(Consulta_Sql)

        End If

        Me.Close()
    End Sub

    Private Function ChequearTodo(ByVal Grilla As DataGridView,
                              ByVal Chk As Boolean,
                              ByVal TipoFiltro As String)


        For i As Integer = 0 To Grilla.Rows.Count - 1
            Grilla.Rows(i).Cells(0).Value = Chk
        Next

    End Function

    Sub GrabarFiltroSQL(ByVal dt As DataTable)

        Grilla.Refresh()

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_TblFiltro_InfxUs Where Funcionario = '" & FUNCIONARIO &
               "' And Informe = '" & _CodInforme & "' And Tabla = '" & _TipoDeFiltro & "'"

        For Each row As DataRow In dt.Rows 'Grilla.Rows

            Dim Chk = row.Item(0)
            Dim CodTipo = row.Item(1)

            If CBool(Chk) Then
                Consulta_Sql = Consulta_Sql & vbCrLf & "Insert Into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario, Informe, Tabla, Codigo) Values " &
                               "('" & FUNCIONARIO & "','" & _CodInforme & "','" & _TipoDeFiltro & "','" & Trim(CodTipo) & "')"
            End If

        Next
        _Sql.Ej_consulta_IDU(Consulta_Sql)

    End Sub

    Sub CargarDatos(Optional ByVal Incluye_Sin_Clasificacion As Boolean = True)

        Select Case _TipoDeFiltro

            Case "TABTIDO" ' DOCUMENTOS
                TblFiltro = "TABTIDO" : Campo1 = "TIDO" : Campo2 = "NOTIDO"
                Condicion = "WHERE TIDO IN " & _Documentos_Filtro
            Case "TABSU" ' SUCURSAL
                TblFiltro = "TABSU" : Campo1 = "KOSU" : Campo2 = "NOKOSU"
                Condicion = "WHERE EMPRESA = '" & ModEmpresa & "'"
            Case "TABBO" ' BODEGAS
                TblFiltro = "TABBO" : Campo1 = "KOBO" : Campo2 = "NOKOBO" : Condicion = ""
            Case "MRPR" ' MARCAS
                TblFiltro = "TABMR" : Campo1 = "KOMR" : Campo2 = "NOKOMR" : Condicion = ""
            Case "RUPR" ' RUBROS
                TblFiltro = "TABRU" : Campo1 = "KORU" : Campo2 = "NOKORU" : Condicion = ""
            Case "ZONAPR" ' ZONAS
                TblFiltro = "TABZO" : Campo1 = "KOZO" : Campo2 = "NOKOZO" : Condicion = ""
            Case "CLALIBPR" ' CLASIFICACION LIBRE
                TblFiltro = "TABCARAC" : Campo1 = "KOCARAC" : Campo2 = "NOKOCARAC"
                Condicion = "WHERE KOTABLA = 'CLALIBPR'"
            Case "FMPR" ' SUPER FAMILIAS
                TblFiltro = "TABFM" : Campo1 = "KOFM" : Campo2 = "NOKOFM" : Condicion = ""
            Case "TABFU" ' FUNCIONARIOS
                TblFiltro = "TABFU" : Campo1 = "KOFU" : Campo2 = "NOKOFU" : Condicion = ""

        End Select

        Dim Sql_IncluyeSc As String = String.Empty

        Dim Fl As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblFiltro_InfxUs", "Filtro",
                          "Informe = '" & _CodInforme &
                          "' And Funcionario = '" & FUNCIONARIO & "' And Tabla = '" & _TipoDeFiltro & "'")

        If Fl = "()" Then
            Fl = "('@$#')"
        ElseIf Fl = "'Ver Todo'" Or String.IsNullOrEmpty(Fl) Then
            Fl = "('VT')"
        End If


        If Incluye_Sin_Clasificacion Then

            Sql_IncluyeSc = "Select Case " & vbCrLf &
                            "When '' in (Select Filtro From " & _Global_BaseBk & "Zw_TblFiltro_InfxUs" & vbCrLf &
                            "Where Informe = '" & _CodInforme & "' and Tabla = '" & _TipoDeFiltro &
                            "' And Funcionario = '" & FUNCIONARIO & "') Then 1" & vbCrLf &
                            "else 0 end AS 'Chk'," & vbCrLf &
                            "'' as Codigo,'SIN CLASIFICACION...' as Descripcion UNION"
        End If

        Consulta_Sql = Sql_IncluyeSc & vbCrLf &
                       "Select Case " & vbCrLf &
                       "When " & Campo1 & " in " & Fl & " Then 1" & vbCrLf &
                       "Else 0 End as Chk," & vbCrLf &
                       Campo1 & " as 'Codigo'," & Campo2 & " as 'Descripcion' From " & TblFiltro & vbCrLf &
                       Condicion & vbCrLf &
                       "order by Codigo"

        Datos.Clear()
        Grilla.DataSource = Nothing

        Dim cn1 As New SqlConnection

        Dim daAuthors As _
        New SqlDataAdapter(Consulta_Sql, cn1)

        daAuthors.Fill(Datos, "Filtro")

        With Grilla

            .DataSource = Datos '.Tables("DetalleDocumento")
            .DataMember = Datos.Tables("Filtro").TableName

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel."

            .Columns("Codigo").Width = 70
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True

            .Columns("Descripcion").Width = 200
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
        End With

        If Fl = "('VT')" Then ChkSeleccionar.Checked = True

        _Chekeado = ChkSeleccionar.Checked

    End Sub





    Private Sub ChkSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles ChkSeleccionar.CheckedChanged

        Dim chk As Boolean = ChkSeleccionar.Checked

        ChequearTodo(Grilla, chk, "")

        If chk Then
            Grilla.DefaultCellStyle.ForeColor = Color.Gray
            Grilla.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray
            Grilla.Enabled = False
        Else
            Grilla.DefaultCellStyle.ForeColor = Color.Black
            Grilla.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black
            Grilla.Enabled = True
        End If
        'ChequearTodo(Grilla, chk, _TipoDeFiltro)
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Tbl_Seleccionados = Nothing
        _Aceptar = False
        Me.Close()
    End Sub

   
    Private Sub Grilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Frm_FiltroInf_Mt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class