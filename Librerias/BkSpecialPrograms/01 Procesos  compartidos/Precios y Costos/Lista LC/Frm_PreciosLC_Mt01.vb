﻿Imports System.Globalization
Imports DevComponents.DotNetBar

Public Class Frm_PreciosLC_Mt01

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

#Region "VARIABLES"

    Dim Rango1 As Double
    Dim Rango2 As Double

    Dim Mcosto As Double
    Dim Mcosto_Old As Double
    Dim NetoPropuesto As Double
    Dim BrutoPropuesto As Double
    Dim BrutoDigitado As Double
    Dim MargenDigitado As Double
    Dim Flete As Double

    Dim Ila, Iva, Impuestos As Double

    Dim SqlGrillaPrecios As String

    Dim TablaDePasoLista_LC As String = "Zw_ListaLC_TblPasoListas" & FUNCIONARIO

    Dim _Grabar As Boolean
    Dim _Cerrar_Al_Grabar As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Cerrar_Al_Grabar As Boolean
        Get
            Return _Cerrar_Al_Grabar
        End Get
        Set(value As Boolean)
            _Cerrar_Al_Grabar = value
        End Set
    End Property

#End Region

#Region "FUNCIONES y PROCEDIMIENTOS"

    Function ver_codigo(ByVal ListaRango As String,
                        ByVal VerBruto As Boolean,
                        ByVal Codigo As String,
                        ByVal LtValoresConfig As String) As Boolean

        Dim costopm, costoultcompra As Double
        Dim Lblila, Lbliva As Double
        Dim TotalImpuestos As Double
        Dim Rango1, Rango2 As Double
        Dim Ecuacion1, Ecuacion2 As String
        Dim Mcosto As Double

        Dim MargenLista1 As Double
        Dim MargenLista2 As Double

        Dim Sql As String

        If VerBruto = True Then ListaRango = "PB7" ''-----*************

        costopm = _Sql.Fx_Trae_Dato("MAEPREM", "PM", " KOPR = '" & Codigo & "'")
        costoultcompra = _Sql.Fx_Trae_Dato("MAEPREM", "PPUL01", " KOPR = '" & Codigo & "'")

        Lblila = De_Txt_a_Num_01(_Sql.Fx_Trae_Dato("PDIMEN", "ILAVALOR", " CODIGO = '" & Codigo & "'"), 3)
        Lbliva = De_Txt_a_Num_01(_Sql.Fx_Trae_Dato("PDIMEN", "IVAFORM", " CODIGO = '" & Codigo & "'"), 3)

        TotalImpuestos = Lbliva + Lblila

        Rango1 = _Sql.Fx_Trae_Dato("PDIMEN", "RANGO01", " CODIGO = '" & Codigo & "'")
        Rango2 = _Sql.Fx_Trae_Dato("PDIMEN", "RANGO02", " CODIGO = '" & Codigo & "'")

        Ecuacion1 = _Sql.Fx_Trae_Dato("TABPRE", "ECUACION", " KOPR = '" & Codigo & "' AND KOLT = '" & ListaRango & "'")
        Ecuacion2 = _Sql.Fx_Trae_Dato("TABPRE", "ECUACIONU2", " KOPR = '" & Codigo & "' AND KOLT = '" & ListaRango & "'")

        If costopm > costoultcompra Then Mcosto = costopm
        If costopm <= costoultcompra Then Mcosto = costoultcompra

        MargenLista1 = _Sql.Fx_Trae_Dato("TABPRE", "MG01UD", " KOPR = '" & Codigo & "' AND KOLT = 'PB8'")
        MargenLista2 = _Sql.Fx_Trae_Dato("TABPRE", "MG01UD", " KOPR = '" & Codigo & "' AND KOLT = 'PB9'")



    End Function

    Function CargarProducto(Optional ByVal Codigo As String = "")
        'Try

        Dim TblPaso As String = "TblIMPILA" & FUNCIONARIO

        Consulta_sql = My.Resources.DetalleMcostoPm_eImpuestos.ToString
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", TblPaso)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", Codigo)
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "SELECT ISNULL(dbo.MAEPR.NOKOPR, 0) as NOKOPR,ISNULL(dbo.MAEPREM.PM, 0) as PM,ISNULL(dbo.MAEPREM.PPUL01, 0) as PUL," & vbCrLf &
                       "CASE WHEN ISNULL(dbo.MAEPREM.PPUL01, 0) > ISNULL(dbo.MAEPREM.PM, 0) THEN ISNULL(dbo.MAEPREM.PPUL01, 0) " & vbCrLf &
                       "ELSE ISNULL(dbo.MAEPREM.PM, 0) END as MCOSTO , ISNULL(dbo.MAEPR.RLUD,0) AS RLUD,ISNULL(dbo.MAEPR.UD01PR,0) AS UD01PR, " & vbCrLf &
                          "ISNULL(dbo.MAEPR.UD02PR,0) AS UD02PR, ISNULL(dbo.PDIMEN.IVAFORM/100,0) AS IVAFORM" & vbCrLf &
                          ",ISNULL(dbo.PDIMEN.ILAVALOR/100,0) AS ILAVALOR, " & vbCrLf &
                          "ISNULL((dbo.PDIMEN.ILAVALOR + dbo.PDIMEN.IVAFORM)/100,0) AS TotalImpuestos " & vbCrLf &
                          "FROM   dbo.MAEPR LEFT OUTER JOIN" & vbCrLf &
                          "dbo.MAEPREM ON dbo.MAEPR.KOPR = dbo.MAEPREM.KOPR LEFT OUTER JOIN" & vbCrLf &
                          "dbo.PDIMEN ON dbo.MAEPR.KOPR = dbo.PDIMEN.CODIGO" & vbCrLf &
                          "WHERE dbo.MAEPR.KOPR = '" & Codigo & "'"

        Consulta_sql = "SELECT * FROM " & TblPaso
        GrillaProducto.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Ila = De_Txt_a_Num_01(_Sql.Fx_Trae_Dato(TblPaso, "ILAVALOR"), 3) * 100
        Iva = De_Txt_a_Num_01(_Sql.Fx_Trae_Dato(TblPaso, "IVAFORM"), 3) * 100

        Consulta_sql = "DROP TABLE " & TblPaso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "CASE WHEN ISNULL(PPUL01, 0) > ISNULL(PM, 0) THEN ISNULL(PPUL01, 0) " & vbCrLf &
                       "ELSE ISNULL(PM, 0) END "

        Mcosto = _Sql.Fx_Trae_Dato("MAEPREM", Consulta_sql, "KOPR = '" & Codigo & "'")

        Dim RegValPro As Long
        RegValPro = _Sql.Fx_Cuenta_Registros("Zw_ListaLC_ValPro", "Codigo = '" & Codigo & "'")

        If RegValPro = 0 Then
            Consulta_sql = "INSERT INTO Zw_ListaLC_ValPro (Codigo,Mcosto,VproNeto,VproBruto,MgDigitado,ValDigitado) values" & vbCrLf &
                   "('" & Codigo & "',0,0,0,0,0)"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Mcosto_Old = _Sql.Fx_Trae_Dato("Zw_ListaLC_ValPro", "Mcosto", "Codigo = '" & Codigo & "'")

        MargenDigitado = _Sql.Fx_Trae_Dato("Zw_ListaLC_ValPro", "MgDigitado", "Codigo = '" & Codigo & "'")
        BrutoDigitado = _Sql.Fx_Trae_Dato("Zw_ListaLC_ValPro", "ValDigitado", "Codigo = '" & Codigo & "'")

        TxtMargenDigitado.Text = De_Num_a_Tx_01(MargenDigitado, False, 2)
        TxtPrecioDigitado.Text = BrutoDigitado
        TxtMcostoOld.Text = FormatCurrency(Mcosto_Old, 0)

        FormatoGrillaProducto(GrillaProducto, 1)

        Consulta_sql = "SELECT DISTINCT dbo.TABRECPR.KOEN, dbo.MAEEN.NOKOEN, dbo.TABRECPR.RECARGO" & vbCrLf &
                       "FROM dbo.TABRECPR LEFT OUTER JOIN " & vbCrLf &
                       "dbo.MAEEN ON dbo.TABRECPR.KOEN = dbo.MAEEN.KOEN" & vbCrLf &
                       "WHERE (dbo.TABRECPR.RECARGO > 0) AND " &
                       "(dbo.TABRECPR.KOPR = '" & Codigo & "') AND " &
                       "(dbo.TABRECPR.KOEN <> '')"
        GrillaRecargos.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        FormatoGrillaProducto(GrillaRecargos, 3)

        Flete = De_Txt_a_Num_01(_Sql.Fx_Trae_Dato("TABRECPR", "RECARGO", "KOPR = '" & Codigo & "' AND KOEN = ''"), 3)
        TxtFlete1.Text = Flete
        TxtFlete2.Text = Flete

        ActualizarGrillaPrecios(Codigo, Ila, Iva)
        CalcularPropuestos(MargenDigitado, Impuestos)

        If BrutoDigitado < BrutoPropuesto Then
            TxtPrecioDigitado.ForeColor = Color.Red
        Else
            TxtPrecioDigitado.ForeColor = Color.Black
        End If

        TxtPrecioDigitado.Focus()

        'Catch ex As Exception

        'End Try

    End Function

    Private Function CalcularPropuestos(ByVal MargenDig As Double,
                                        ByVal Impuestos As Double)

        'MargenDig = De_Txt_a_Num_01(TxtMargenDigitado.Text, 3)

        NetoPropuesto = Mcosto * (1 + (MargenDig / 100))
        BrutoPropuesto = Math.Round(NetoPropuesto * (1 + (Impuestos / 100)), 0)

        TxtNetoPropuesto.Text = FormatCurrency(NetoPropuesto)
        TxtBrutoPropuesto.Text = FormatCurrency(BrutoPropuesto)
    End Function

    Private Function ActualizarGrillaPrecios(ByVal Codigo As String,
                                             ByVal Ila As Double,
                                             ByVal Iva As Double)

        Try

            Impuestos = Ila + Iva

            Consulta_sql = My.Resources.Actualiza_Lsita_de_precios_PRECIOS_LC
            Consulta_sql = Replace(Consulta_sql, "Zw_ListaLC_TblPasoListas", TablaDePasoLista_LC)
            Consulta_sql = Replace(Consulta_sql, "#Codigo", Codigo)
            Consulta_sql = Replace(Consulta_sql, "#Ila", De_Num_a_Tx_01(Ila))
            Consulta_sql = Replace(Consulta_sql, "#Iva", De_Num_a_Tx_01(Iva))
            Consulta_sql = Replace(Consulta_sql, "#Impuestos", De_Num_a_Tx_01(Impuestos))
            Consulta_sql = Replace(Consulta_sql, "#PrecioDigitado", De_Num_a_Tx_01(BrutoDigitado))
            Consulta_sql = Replace(Consulta_sql, "#MargenPropuesto", De_Num_a_Tx_01(MargenDigitado))

            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select * From " & TablaDePasoLista_LC & " ORDER BY Lista "
            SqlGrillaPrecios = Consulta_sql

            GrillaPrecios.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            FormatoGrilla(GrillaPrecios)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function FormatoGrilla(ByVal Grilla As DataGridView)

        'Lista, NombreLista, Codigo, PrecioUd1,PrecioUd2,Rtu, MargenPorc, VarMcosto,VarPm, 
        'VarUc, VarFlete, VarIva, VarIla,VarNetoDigit,VarValorDigit

        With Grilla


            .Columns("Id").Visible = False
            .Columns("Rtu").Visible = False
            .Columns("Codigo").Visible = False
            .Columns("VarMcosto").Visible = False
            .Columns("VarPm").Visible = False
            .Columns("VarUc").Visible = False
            .Columns("VarFlete").Visible = False
            .Columns("VarIva").Visible = False
            .Columns("VarIla").Visible = False
            .Columns("VarNetoDigit").Visible = False
            .Columns("VarValorDigit").Visible = False
            .Columns("EcuacionUd1").Visible = False
            .Columns("EcuacionUd2").Visible = False

            '.Columns("Accion").Visible = False

            .Columns("Lista").Width = 40
            .Columns("Lista").HeaderText = "Lista"
            .Columns("Lista").ReadOnly = True

            .Columns("NombreLista").Width = 300
            .Columns("NombreLista").HeaderText = "Descripción lista"
            .Columns("NombreLista").ReadOnly = True

            .Columns("PrecioUd1").Width = 100
            .Columns("PrecioUd1").HeaderText = "Precio Ud1"
            .Columns("PrecioUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("PrecioUd1").ReadOnly = True

            .Columns("MargenPorc").Width = 100
            .Columns("MargenPorc").HeaderText = "Margen %"
            .Columns("MargenPorc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("PrecioUd2").Width = 100
            .Columns("PrecioUd2").HeaderText = "Precio Ud2"
            .Columns("PrecioUd2").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("PrecioUd2").ReadOnly = True

            '.Columns("Brutolinea").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("Brutolinea").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'TotalNeto = Math.Round(Val(SumarDatodeGrilla("Netolinea", Grilla)), 2)
            'TotalIva = Math.Round(TotalNeto * 0.19, 0)


            .Refresh()

        End With

    End Function

    Private Function FormatoGrillaProducto(ByVal Grilla As DataGridView, ByVal Gr As Integer)
        With Grilla
            If Gr = 1 Then

                .Columns("NOKOPR").Width = 250
                .Columns("NOKOPR").HeaderText = "Descripción"

                .Columns("PM").Width = 60
                .Columns("PM").HeaderText = "Costo PM"
                .Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                .Columns("PM").Width = 60
                .Columns("PM").HeaderText = "Costo PM"
                .Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns("PM").DefaultCellStyle.Format = "$ ###,##"

                .Columns("PUL").Width = 60
                .Columns("PUL").HeaderText = "Costo UC"
                .Columns("PUL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns("PUL").DefaultCellStyle.Format = "$ ###,##"

                .Columns("MCOSTO").Width = 60
                .Columns("MCOSTO").HeaderText = "M. Costo"
                .Columns("MCOSTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns("MCOSTO").DefaultCellStyle.Format = "$ ###,##"

                .Columns("RLUD").Width = 40
                .Columns("RLUD").HeaderText = "Rtu"
                .Columns("RLUD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("UD01PR").Width = 40
                .Columns("UD01PR").HeaderText = "Ud1"
                .Columns("UD01PR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("UD02PR").Width = 40
                .Columns("UD02PR").HeaderText = "Ud2"
                .Columns("UD02PR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("IVAFORM").Width = 45
                .Columns("IVAFORM").HeaderText = "Iva%"
                .Columns("IVAFORM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("IVAFORM").DefaultCellStyle.Format = "% ###,##.#"

                .Columns("ILAVALOR").Width = 45
                .Columns("ILAVALOR").HeaderText = "Ila%"
                .Columns("ILAVALOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("ILAVALOR").DefaultCellStyle.Format = "% ###,##.#"

                .Columns("TotalImpuestos").Width = 45
                .Columns("TotalImpuestos").HeaderText = "Imp.%"
                .Columns("TotalImpuestos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("TotalImpuestos").DefaultCellStyle.Format = "% ###,##.#"

                '.Columns("Brutolinea").DefaultCellStyle.Format = "$ ###,##"
                '.Columns("Brutolinea").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            ElseIf Gr = 2 Then


            ElseIf Gr = 3 Then

                .Columns("KOEN").Width = 100
                .Columns("KOEN").HeaderText = "Entidad"

                .Columns("NOKOEN").Width = 300
                .Columns("NOKOEN").HeaderText = "Razón Socila"

                .Columns("RECARGO").Width = 100
                .Columns("RECARGO").HeaderText = "Flete"
                .Columns("RECARGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            End If
        End With
    End Function

    Sub EditarFormulas(ByVal IdGrilla As String,
                       ByVal Campo As String,
                       ByVal Lista As String)

        Dim Tabla, Condicion As String
        'Dim Ejec As Boolean = False

        Tabla = "Zw_ListaLC_Listas"
        Condicion = "Lista = '" & Lista & "'"

        ''If Ejec = True Then
        Dim Frm_PreciosLCEditorFormulas As New Frm_PreciosLCEditorFormulas("")
        Dim Texto As String

        Texto = "Función Lista: " & Lista & ", Función: " & Campo
        'Frm_PreciosLCEditorFormulas.IdGrilla = IdGrilla
        'Frm_PreciosLCEditorFormulas.Texto = Texto
        'Frm_PreciosLCEditorFormulas.Tabla = Tabla
        'Frm_PreciosLCEditorFormulas.Campo = Campo
        'Frm_PreciosLCEditorFormulas.Condicion = Condicion
        Frm_PreciosLCEditorFormulas.ShowDialog(Me)

        'End If
    End Sub

#End Region

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillaPrecios, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(DataGridView1, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, False, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub
    Private Sub Frm_PreciosLC_Mt01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Txtcodigo
    End Sub

    Private Sub EditarFormulasDeEcuacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarFormulasDeEcuacionesToolStripMenuItem.Click

        Dim IdGrilla = GrillaPrecios.CurrentRow.Index
        Dim Id = GrillaPrecios.Rows(IdGrilla).Cells("Id").Value.ToString
        Dim Lista = GrillaPrecios.Rows(IdGrilla).Cells("Lista").Value.ToString

        Dim Condicion As String
        Dim Campo = "FormulaEcuaciones"

        Condicion = "Lista = '" & Lista & "'"
        EditarFormulas(Id, Campo, Lista)

    End Sub

    Private Sub EditarFormulasDeValoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarFormulasDeValoresToolStripMenuItem.Click

        Dim IdGrilla = GrillaPrecios.CurrentRow.Index
        Dim Id = GrillaPrecios.Rows(IdGrilla).Cells("Id").Value.ToString
        Dim Lista = GrillaPrecios.Rows(IdGrilla).Cells("Lista").Value.ToString

        Dim Condicion As String
        Dim Campo = "FormulaUd1"

        Condicion = "Lista = '" & Lista & "'"
        EditarFormulas(IdGrilla, Campo, Lista)

    End Sub

    Private Sub BtnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProducto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_Tipo_Lista = "C"
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_Mostrar_Info = False
        Fm.BtnCrearProductos.Visible = False

        Fm.BtnExportaExcel.Visible = False
        Fm.Pro_Actualizar_Precios = False

        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then

            Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

            If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then
                Txtcodigo.Text = Codigo_abuscar
                CargarProducto(Codigo_abuscar)
            End If
        Else
            Txtcodigo.Text = String.Empty
        End If

    End Sub

    Private Sub TxtFlete2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFlete2.TextChanged
        TxtFlete1.Text = TxtFlete2.Text
    End Sub

    Private Sub TxtPrecioDigitado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecioDigitado.Leave
        If BrutoDigitado < BrutoPropuesto Then
            MsgBox("El valor digitado es menor que el precio sugerido", MsgBoxStyle.Exclamation, "Precio")
        End If
    End Sub

    Private Sub TxtPrecioDigitado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecioDigitado.TextChanged
        BrutoDigitado = De_Txt_a_Num_01(TxtPrecioDigitado.Text, 3)
        If BrutoDigitado < BrutoPropuesto Then
            TxtPrecioDigitado.ForeColor = Color.Red
        Else
            TxtPrecioDigitado.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtPrecioDigitado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrecioDigitado.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            'TxtPrecioDigitado.Focus()
            'MsgBox(Nivel1)
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

    Private Sub BtnSimular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimular.Click

        Dim Flete As Double
        Flete = De_Txt_a_Num_01(TxtFlete1.Text, 3)

        Consulta_sql = "Update " & TablaDePasoLista_LC & " Set VarFlete = " & De_Num_a_Tx_01(Flete, False, 5) & vbCrLf &
                       ",VarValorDigit = " & De_Num_a_Tx_01(BrutoDigitado, False, 5) & vbCrLf &
                       ",VarNetoDigit = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Declare @Fxx Varchar(8000)" & vbCrLf &
                       "Set @Fxx = (Select Formula From Zw_ListaLC_Fx" & vbCrLf &
                       "where CodFormula = 'Lista_LC')" & vbCrLf &
                       "Set @Fxx = REPLACE(@Fxx,'#TblPaso#','" & TablaDePasoLista_LC & "')" & vbCrLf &
                       "Set @Fxx = REPLACE(@Fxx,'#TablaPaso#','" & TablaDePasoLista_LC & "')" & vbCrLf &
                       "Exec (@Fxx)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        '"Set @Fxx = REPLACE(@Fxx,'Zw_ListaLC_TblPasoListas','" & TablaDePasoLista_LC & "')" & vbCrLf & _

        Dim Codigo = Txtcodigo.Text

        Consulta_sql = "Declare @Fxx Varchar(8000)" & vbCrLf &
                          "Set @Fxx = (Select Formula From Zw_ListaLC_Fx" & vbCrLf &
                          "where CodFormula = 'Lista_LCRa')" & vbCrLf &
                          "Set @Fxx = REPLACE(@Fxx,'#Codigo#','" & Codigo & "')" & vbCrLf &
                          "Set @Fxx = REPLACE(@Fxx,'#TablaPaso#','" & TablaDePasoLista_LC & "')" & vbCrLf &
                          "Exec (@Fxx)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select * From " & TablaDePasoLista_LC & " ORDER BY Lista"
        GrillaPrecios.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        FormatoGrilla(GrillaPrecios)

    End Sub

    Private Sub Btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnimprimir.Click

        Dim Nro As String = "7Brr0005"

        If Fx_Tiene_Permiso(Me, Nro) Then
            Dim FM As New Frm_PrecioLC_ImpFleje
            FM.LlenarDatos(Txtcodigo.Text, FM.CmbLista.SelectedValue)
            FM.TxtPrecioUd1.Text = 0 : FM.TxtPrecioUd2.Text = 0
            FM.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If

    End Sub

    Private Sub MargeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MargeToolStripMenuItem.Click

        Dim IdGrilla = GrillaPrecios.CurrentRow.Index
        Dim Id = GrillaPrecios.Rows(IdGrilla).Cells("Id").Value.ToString
        Dim Lista = GrillaPrecios.Rows(IdGrilla).Cells("Lista").Value.ToString

        Dim Condicion As String
        Dim Campo = "FormulaMg1"

        Condicion = "Lista = '" & Lista & "'"
        EditarFormulas(IdGrilla, Campo, Lista)

    End Sub

    Private Sub BtnFormulas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFormulas.Click
        'Dim Nro As String = "Pre0003"
        'If Fx_Tiene_Permiso(Me,Nro) Then
        '    Dim Campo, Tabla, Condicion As String

        '    Campo = "Formula"
        '    Tabla = "Zw_ListaLC_Fx"
        '    Condicion = "CodFormula = 'Lista_LC'"


        '    Dim Frm_PreciosLCEditorFormulas As New Frm_PreciosLCEditorFormulas
        '    Dim Texto As String

        '    Texto = "Función para Configurar Formula de actualización para las listas"
        '    Frm_PreciosLCEditorFormulas.Id = _Sql.Fx_Trae_Dato(tb, cn1, "Id", "Zw_ListaLC_Fx", "CodFormula = 'Lista_LC'")
        '    Frm_PreciosLCEditorFormulas.Texto = Texto
        '    Frm_PreciosLCEditorFormulas.Tabla = Tabla
        '    Frm_PreciosLCEditorFormulas.Campo = Campo
        '    Frm_PreciosLCEditorFormulas.Condicion = Condicion
        '    Frm_PreciosLCEditorFormulas.ShowDialog(Me)

        'Else
        '    MensajeSinPermiso(Nro)
        'End If
    End Sub

    Private Sub Txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcodigo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True
            Codigo_abuscar = Txtcodigo.Text

            If _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & Codigo_abuscar & "'") = 0 Then

                Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
                Fm.Txtdescripcion.Text = Txtcodigo.Text
                Fm.Pro_CodEntidad = String.Empty
                Fm.Pro_Tipo_Lista = "C"
                Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
                Fm.Pro_Mostrar_Info = False
                Fm.BtnCrearProductos.Visible = False

                Fm.BtnExportaExcel.Visible = False
                Fm.Pro_Actualizar_Precios = False

                Fm.ShowDialog(Me)

                If Fm.Pro_Seleccionado Then

                    Codigo_abuscar = Fm.Pro_Tbl_Producto_Seleccionado.Rows(0).Item("KOPR")

                    If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then
                        Txtcodigo.Text = Codigo_abuscar
                        CargarProducto(Codigo_abuscar)
                    End If
                Else
                    Txtcodigo.Text = String.Empty
                End If
            End If

            If Codigo_abuscar <> "" Then
                Txtcodigo.Text = Codigo_abuscar
                CargarProducto(Codigo_abuscar)
            End If

        End If
    End Sub

    Private Sub GrillaPrecios_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaPrecios.CellEnter

        Try

            Dim IdGrilla = GrillaPrecios.CurrentRow.Index
            'IdGrilla = GrillaPrecios.Rows(IdGrilla).Cells("Id").Value.ToString
            Dim Lista = GrillaPrecios.Rows(IdGrilla).Cells(1).Value.ToString

            Consulta_sql = "SELECT 'Ecuación Ud1' AS Campo, EcuacionUd1 as Ecuacion FROM " & TablaDePasoLista_LC & vbCrLf &
                           "WHERE Lista = '" & Lista & "'" & vbCrLf &
                           "UNION" & vbCrLf &
                           "SELECT 'Ecuación Ud2' As Campo, EcuacionUd2 as Ecuacion FROM " & TablaDePasoLista_LC & vbCrLf &
                           "WHERE Lista = '" & Lista & "'"
            '_Sql.Ej_consulta_IDU(Consulta_sql)

            'Consulta_sql = "select * from " & TablaDePasoLista_LC & " ORDER BY Lista "
            'SqlGrillaPrecios = Consulta_sql

            With DataGridView1

                .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

                .Columns("Campo").Width = 80
                .Columns("Campo").HeaderText = "Lista"

                .Columns("Ecuacion").Width = 610
                .Columns("Ecuacion").HeaderText = "Ecuación"

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim dlg As System.Windows.Forms.DialogResult =
        MessageBoxEx.Show(Me, "¿Esta seguro de actualizar los valores?",
                          "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlg = System.Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "UPDATE TABPRE SET " & vbCrLf &
                           "TABPRE.PP01UD = " & TablaDePasoLista_LC & ".PrecioUd1," & vbCrLf &
                           "TABPRE.PP02UD = " & TablaDePasoLista_LC & ".PrecioUd2," & vbCrLf &
                           "TABPRE.ECUACION = " & TablaDePasoLista_LC & ".EcuacionUd1," & vbCrLf &
                           "TABPRE.ECUACIONU2 = " & TablaDePasoLista_LC & ".EcuacionUd2," & vbCrLf &
                           "TABPRE.MG01UD = " & TablaDePasoLista_LC & ".MargenPorc" & vbCrLf &
                           "FROM    " & TablaDePasoLista_LC & " LEFT OUTER JOIN" & vbCrLf &
                           "TABPRE ON " & TablaDePasoLista_LC &
                           ".Codigo = TABPRE.KOPR AND " & TablaDePasoLista_LC & ".Lista = TABPRE.KOLT"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "DELETE Zw_ListaLC_ValPro WHERE Codigo = '" & Txtcodigo.Text & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "INSERT INTO Zw_ListaLC_ValPro (Codigo,Mcosto,VproNeto,VproBruto,MgDigitado,ValDigitado,FechaModif,HoraModif) values" & vbCrLf &
                           "('" & Txtcodigo.Text & "'," & De_Num_a_Tx_01(Mcosto, False, 5) &
                           "," & De_Num_a_Tx_01(NetoPropuesto, False, 5) &
                           "," & De_Num_a_Tx_01(BrutoPropuesto, False, 5) &
                           "," & TxtMargenDigitado.Text &
                           "," & De_Num_a_Tx_01(BrutoDigitado, 5) & ",(SELECT replace(convert(varchar, getdate(), 111), '/','')),(SELECT convert(varchar, getdate(), 108)))"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("PDIMEN", "CODIGO = '" & Txtcodigo.Text & "' And EMPRESA = '" & ModEmpresa & "'"))

            If Not _Reg Then

                _Reg = CBool(_Sql.Fx_Cuenta_Registros("PDIMEN", "CODIGO = '" & Txtcodigo.Text & "' And EMPRESA = ''"))

                If Not _Reg Then
                    Consulta_sql = "Insert Into PDIMEN (EMPRESA,CODIGO) Values ('" & ModEmpresa & "','" & Txtcodigo.Text & "')"
                Else
                    Consulta_sql = "Update PDIMEN Set EMPRESA = '" & ModEmpresa & "' Where CODIGO = '" & Txtcodigo.Text & "'"
                End If

                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            Dim _Ila As Double = GrillaProducto.Rows(0).Cells("ILAVALOR").Value * 100

            Consulta_sql = "Update PDIMEN Set ILAVALOR = " & De_Num_a_Tx_01(_Ila, False, 5) & ",FLETE_PROD = " & De_Num_a_Tx_01(Flete, False, 5) & vbCrLf &
                           "WHERE CODIGO = '" & Txtcodigo.Text & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(Me, "Precios actualizados correctamente", "Grabar precios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Grabar = True

            If _Cerrar_Al_Grabar Then
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btndimensiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndimensiones.Click

        Dim Fm As New Frm_Dimensiones
        Fm.CodigoRd = Txtcodigo.Text
        Fm.Text = Txtcodigo.Text
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub TxtMargenDigitado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMargenDigitado.TextChanged
        CalcularPropuestos(De_Txt_a_Num_01(TxtMargenDigitado.Text, 3), Impuestos)
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        If Fx_Tiene_Permiso(Me, "Pre0004") Then

            Consulta_sql = "Select * From Zw_ListaLC_Fx Where CodFormula = 'Lista_LCRa'"
            Dim _Row_LitsaLC_Fx As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Formula As String = _Row_LitsaLC_Fx.Item("Formula")

            Dim Fm As New Frm_PreciosLCEditorFormulas(_Formula)

            Fm.Texto = "Función para Configurar Formula de actualización de Rangos para las listas"
            Fm.ShowDialog(Me)

            If Fm.Grabar Then
                _Formula = Replace(LTrim(RTrim(Fm.Formula)), "'", "''")
                Consulta_sql = "Update Zw_ListaLC_Fx Set Formula = '" & _Formula & "'" & vbCrLf &
                               "Where CodFormula = 'Lista_LCRa'"
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub GrillaPrecios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaPrecios.CellEndEdit

        Dim _Fila As DataGridViewRow = GrillaPrecios.Rows(GrillaPrecios.CurrentRow.Index)
        Dim _Cabeza = GrillaPrecios.Columns(GrillaPrecios.CurrentCell.ColumnIndex).Name

        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Valor As String = De_Num_a_Tx_01(_Fila.Cells(_Cabeza).Value, False, 5)
        Dim _Lista As String = _Fila.Cells("Lista").Value

        Consulta_sql = "Update " & TablaDePasoLista_LC & " Set " & _Cabeza & " = " & _Valor & " Where Lista = '" & _Lista & "' And Codigo = '" & _Codigo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Btn_RecalcularPPP_Click(sender As Object, e As EventArgs) Handles Btn_RecalcularPPP.Click

        Dim _Fecha = "31/12/2021"
        Dim _FechaTope As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)

        _FechaTope = _Global_Row_Configp.Item("FECHINIPPP")

        Dim _Recalculado As Boolean
        Dim _OldPpp As Double = _Sql.Fx_Trae_Dato("MAEPREM", "PM", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & Txtcodigo.Text & "'")
        Dim _NewPpp As Double

        Dim Fm As New Frm_Recalculo_PPPxProd(Txtcodigo.Text, _FechaTope)
        Fm.ShowDialog(Me)
        _Recalculado = Fm.Recalculado
        _NewPpp = Fm.NewPPP
        Fm.Dispose()

        If _Recalculado Then

            If _OldPpp <> _NewPpp Then

            End If

            MessageBoxEx.Show(Me, "PPP calculado: " & FormatCurrency(_NewPpp, 2), "Recalculo PM", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Grabar_Flete_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Flete.Click

        Flete = TxtFlete1.Text

        Consulta_sql = "DELETE TABRECPR WHERE KOPR = '" & Txtcodigo.Text & "' AND KOEN = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "INSERT INTO TABRECPR (KOPR,RECARGO) VALUES ('" & Txtcodigo.Text & "'," & De_Num_a_Tx_01(Flete, False, 5) & ")"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("PDIMEN", "CODIGO = '" & Txtcodigo.Text & "' And EMPRESA = '" & ModEmpresa & "'"))

        If Not _Reg Then

            _Reg = CBool(_Sql.Fx_Cuenta_Registros("PDIMEN", "CODIGO = '" & Txtcodigo.Text & "' And EMPRESA = ''"))

            If Not _Reg Then
                Consulta_sql = "Insert Into PDIMEN (EMPRESA,CODIGO) Values ('" & ModEmpresa & "','" & Txtcodigo.Text & "')"
            Else
                Consulta_sql = "Update PDIMEN Set EMPRESA = '" & ModEmpresa & "' Where CODIGO = '" & Txtcodigo.Text & "'"
            End If

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Consulta_sql = "Update PDIMEN Set FLETE_PROD = " & De_Num_a_Tx_01(Flete, False, 5) & " Where EMPRESA = '" & ModEmpresa & "' And CODIGO = '" & Txtcodigo.Text & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        MsgBox("Flete actualizado correctamente", MsgBoxStyle.Information, "Grabar Flete")

    End Sub

    Private Sub BtnFormulasListas_Click(sender As Object, e As EventArgs) Handles BtnFormulasListas.Click

        If Fx_Tiene_Permiso(Me, "Pre0003") Then

            Consulta_sql = "Select * From Zw_ListaLC_Fx Where CodFormula = 'Lista_LC'"
            Dim _Row_LitsaLC_Fx As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Formula As String = _Row_LitsaLC_Fx.Item("Formula")

            Dim Fm As New Frm_PreciosLCEditorFormulas(_Formula)

            Fm.Texto = "Función para Configurar Formula de actualización para las listas"
            Fm.ShowDialog(Me)

            If Fm.Grabar Then
                _Formula = Replace(LTrim(RTrim(Fm.Formula)), "'", "''")
                Consulta_sql = "Update Zw_ListaLC_Fx Set Formula = '" & _Formula & "'" & vbCrLf &
                               "Where CodFormula = 'Lista_LC'"
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

            Fm.Dispose()

        End If

    End Sub

End Class