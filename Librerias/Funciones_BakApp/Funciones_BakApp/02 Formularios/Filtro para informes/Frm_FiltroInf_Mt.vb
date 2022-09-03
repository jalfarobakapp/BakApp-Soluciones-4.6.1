Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient


Public Class Frm_FiltroInf_Mt

    Public TipoDeFiltro As String
    Public CodInforme As String
    Public EsNumero As Boolean
    Public Campo_In As String = ""
    Public Chekeado As Boolean
    Public _SoloChequear As Boolean
    Public _Aceptar As Boolean

    Public _Tbl_Seleccionados As DataTable

    Dim TblFiltro, Campo1, Campo2, Condicion As String
    Dim Datos As New DsFiltros


    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        _Tbl_Seleccionados = Datos.Tables("Filtro")
        _Aceptar = True

        If Not _SoloChequear Then
            Grilla.Refresh()
            Chekeado = ChkSeleccionar.Checked

            Dim Filtro As String

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblFiltro_InfxUs" & vbCrLf & _
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = '" & CodInforme & "' And Tabla = '" & TipoDeFiltro & "'"
            Ej_consulta_IDU(Consulta_sql, cn1)

            If ChkSeleccionar.Checked Then

                Consulta_sql = _
                 "Insert Into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario,Informe,Tabla,Codigo,Filtro,MarcarTodo)" & vbCrLf & _
                 "Values ('" & FUNCIONARIO & "','" & CodInforme & _
                 "','" & TipoDeFiltro & "','" & Campo_In & "','''Ver Todo''',1)"

            Else

                Filtro = Generar_Filtro_IN(Datos.Tables("Filtro"), "Chk", "Codigo", False, True)

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario, Informe, Tabla, Codigo,Filtro,MarcarTodo)" & vbCrLf & _
                               "Values ('" & FUNCIONARIO & "','" & CodInforme & _
                               "','" & TipoDeFiltro & "','" & Campo_In & "','" & Filtro & "',0)"

            End If


            Ej_consulta_IDU(Consulta_sql, cn1)
        End If

        Me.Close()
    End Sub

    Private Function ChequearTodo(ByVal Grilla As DataGridView, _
                              ByVal Chk As Boolean, _
                              ByVal TipoFiltro As String)


        For i As Integer = 0 To Grilla.Rows.Count - 1
            Grilla.Rows(i).Cells(0).Value = Chk
        Next

    End Function

    Sub GrabarFiltroSQL(ByVal dt As DataTable)

        Grilla.Refresh()

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblFiltro_InfxUs Where Funcionario = '" & FUNCIONARIO & _
               "' And Informe = '" & CodInforme & "' And Tabla = '" & TipoDeFiltro & "'"

        'For i As Integer = 0 To Grilla.Rows.Count - 1

        For Each row As DataRow In dt.Rows 'Grilla.Rows
            'Dim Bodega = row.Cells("Bodega").Value

            Dim Chk = row.Item(0)
            Dim CodTipo = row.Item(1)

            If CBool(Chk) Then
                Consulta_sql = Consulta_sql & vbCrLf & "Insert Into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario, Informe, Tabla, Codigo) Values " & _
                               "('" & FUNCIONARIO & "','" & CodInforme & "','" & TipoDeFiltro & "','" & Trim(CodTipo) & "')"
            End If

        Next
        Ej_consulta_IDU(Consulta_sql, cn1)


    End Sub

    Sub CargarDatos(Optional ByVal Incluye_Sin_Clasificacion As Boolean = True)

        Select Case TipoDeFiltro

            Case "TABTIDO" ' DOCUMENTOS
                TblFiltro = "TABTIDO" : Campo1 = "TIDO" : Campo2 = "NOTIDO" _
                                : Condicion = "WHERE TIDO IN " & Documentos_Filtro
            Case "TABSU" ' SUCURSAL
                TblFiltro = "TABSU" : Campo1 = "KOSU" : Campo2 = "NOKOSU" _
                          : Condicion = "WHERE EMPRESA = '" & ModEmpresa & "'"
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

        Dim Fl As String = trae_dato(tb, cn1, "Filtro", _
                          _Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                          "Informe = '" & CodInforme & _
                          "' And Funcionario = '" & FUNCIONARIO & "' And Tabla = '" & TipoDeFiltro & "'")

        If Fl = "()" Then
            Fl = "('@$#')"
        ElseIf Fl = "'Ver Todo'" Or String.IsNullOrEmpty(Fl) Then
            Fl = "('VT')"
        End If


        If Incluye_Sin_Clasificacion Then

            Sql_IncluyeSc = "Select Case " & vbCrLf & _
                            "When '' in (Select Filtro From " & _Global_BaseBk & "Zw_TblFiltro_InfxUs" & vbCrLf & _
                            "Where Informe = '" & CodInforme & "' and Tabla = '" & TipoDeFiltro & _
                            "' And Funcionario = '" & FUNCIONARIO & "') Then 1" & vbCrLf & _
                            "else 0 end AS 'Chk'," & vbCrLf & _
                            "'' as Codigo,'SIN CLASIFICACION...' as Descripcion UNION"
        End If

        Consulta_sql = Sql_IncluyeSc & vbCrLf & _
                       "Select Case " & vbCrLf & _
                       "When " & Campo1 & " in " & Fl & " Then 1" & vbCrLf & _
                       "Else 0 End as Chk," & vbCrLf & _
                       Campo1 & " as 'Codigo'," & Campo2 & " as 'Descripcion' From " & TblFiltro & vbCrLf & _
                       Condicion & vbCrLf & _
                       "order by Codigo"

        Datos.Clear()
        Grilla.DataSource = Nothing


        Dim daAuthors As _
        New SqlDataAdapter(Consulta_sql, cn1)

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

        Chekeado = ChkSeleccionar.Checked

    End Sub

   


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Grilla.RowHeadersVisible = True

        'EstiloFormulario(StyleManager1)

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
        'ChequearTodo(Grilla, chk, TipoDeFiltro)
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