Imports Funciones_BakApp
Imports BkSpecialPrograms

Public Class Frm_ImpBarrasDisenoDeFormatos2
    Dim Codigo As String
    Dim ConsultaSQLGrilla As String
    Dim TablaDePaso As String

    Dim Frm_BuscarXProducto_Mts As New Frm_BuscarXProducto_Mt


    Private Sub AbrirToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripButton.Click


        SQL_ServerClass.ActualizarGrillaUpInsDel(ConsultaSQLGrilla, Grilla, cn1)
        Frm_BuscarXProducto_Mts.ShowDialog(Me)
        Codigo = Codigo_abuscar
        CrearDetalleParaGenerarEtiquetasDeBarraPorProducto("01", "CM", "PR", Codigo, TablaDePaso)
        ActualizarGrilla()

    End Sub


    Private Sub Frm_ImpBarrasDisenoDeFormatos2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TablaDePaso = "Zw_TmpTblDocBarras" & FUNCIONARIO

        Dim Registros As Long = Cuenta_registros(TablaDePaso, "CodProducto <> ''")
        If Registros = 0 Then
            CrearTablaDePaso(TablaDePaso)
        End If

        ActualizarGrilla()

        caract_combo(Cmbbodega)
        Consulta_sql = "SELECT KOBO AS Padre,NOKOBO AS Hijo FROM TABBO" ' WHERE SEMILLA = " & Actividad
        Cmbbodega.DataSource = get_Tablas(Consulta_sql, cn1)

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT Semilla AS Padre,NombreEtiqueta AS Hijo FROM Zw_Tbl_DisenoBarras order by NombreEtiqueta"
        Cmbetiquetas.DataSource = get_Tablas(Consulta_sql, cn1)

    End Sub

    Function ActualizarGrilla()

        Consulta_sql = "SELECT Idmaeddo, CodProducto, Descripcion, Cantidad, Ubicacion FROM Zw_TmpTblDocBarras" & FUNCIONARIO
        ConsultaSQLGrilla = Consulta_sql

        Ejecutar_consulta_SQL(Consulta_sql, cn1)
        tb = New DataTable
        da.Fill(tb)
        Grilla.DataSource = tb

        Grilla.AutoSizeColumnsMode = _
        DataGridViewAutoSizeColumnsMode.AllCells

        Grilla.Columns("Idmaeddo").Visible = False

    End Function

    Private Sub Grilla_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyUp
        SQL_ServerClass.ActualizarGrillaUpInsDel(ConsultaSQLGrilla, Grilla, cn1)

    End Sub

    Private Sub NuevoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripButton.Click
        EliminarDatosTblBarras()
        ActualizarGrilla()
    End Sub


    Private Sub Btnimprimiretiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnimprimiretiquetas.Click
        SQL_ServerClass.ActualizarGrillaUpInsDel(ConsultaSQLGrilla, Grilla, cn1)
        ImprimirEtiquetas()
    End Sub
    Function ImprimirEtiquetas()
        Try

            If Txtveces.Text = "" Then Txtveces.Text = "1"

            Consulta_sql = "SELECT * FROM " & TablaDePaso & " WHERE Cantidad > 0"
            ConsultaSQLGrilla = Consulta_sql

            Ejecutar_consulta_SQL(Consulta_sql, cn1)
            tb2 = New DataTable
            da.Fill(tb2)
            Grilla.DataSource = tb2

            Dim Filas As Long = tb2.Rows.Count

            For f = 0 To Filas - 1
                Dim dr As DataRow = tb2.Rows(f)

                Dim Diseno As String = trae_dato(tb, cn1, "FUNCION", "Zw_Tbl_DisenoBarras", "Semilla = " & Cmbetiquetas.SelectedValue.ToString)
                Dim CanXlinea As Double = trae_dato(tb, cn1, "CantPorLinea", "Zw_Tbl_DisenoBarras", "Semilla = " & Cmbetiquetas.SelectedValue.ToString)
                Dim cond_barra As String
                Dim CodProducto As String = dr("CodProducto").ToString()
                Dim Descripcionpr As String = Trim(dr("Descripcion").ToString())
                Dim Sucursar As String = Trim(dr("Sucursal").ToString())
                Dim Bodega As String = Trim(dr("Bodega").ToString())
                'Dim Ubicacion As String = trae_dato(tb, cn1, "DATOSUBIC", "TABBOPR", "EMPRESA = '01'" & _
                '                                    " AND KOSU = '" & Sucursar & "' AND KOBO = '" & Bodega & "' AND KOPR = '" & CodProducto & "'")
                Dim Ubicacion = Trim(dr("Ubicacion").ToString())
                Dim Veces As Double = dr("Cantidad").ToString()

                If Len(CodProducto) = 13 Then
                    cond_barra = Mid(CodProducto, 1, 12) & ">6" & Mid(CodProducto, 13, 1)
                Else
                    cond_barra = CodProducto
                End If

                Descripcionpr = Replace(Descripcionpr, "ñ", "n")
                Descripcionpr = Replace(Descripcionpr, "Ñ", "N")

                Puerto = LTrim$(RTrim$(Ruta_conexion(AppPath(True) & "Barras\Puerto.txt")))
                'If Txtveces.Text = "" Then Txtveces.Text = "1"

                If Veces Mod 2 <> 0 Then
                    Veces = Veces + 1
                End If

                Veces = Veces / CanXlinea

                For w = 1 To Val(Veces)
                    imprimir_barra(Puerto, _
                                   False, _
                                   Diseno, _
                                   CodProducto, _
                                   cond_barra, _
                                   "", _
                                   Descripcionpr, , , , , , _
                                   Ubicacion, , _
                                   "Ds.", _
                                   "Bodega")
                Next

                'MsgBox(cond_barra & " - " & dr("CodigoVenta").ToString() & " - " & _
                '       dr("Descripcion").ToString() & " - " & _
                '       FormatNumber(Val(dr("precioNuevo").ToString()), 0))
            Next
            'Kill("C:\Barra.prn")
        Catch ex As Exception
            MsgBox("Error inesperado", MsgBoxStyle.Exclamation, "Barras")
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Grilla_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress

    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  
        Dim columna As Integer = Grilla.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        If columna = 3 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or _
            (caracter = ChrW(Keys.Back)) Or _
            (caracter = ",") And _
            (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Grilla_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellValueChanged
        'ActualizarGrillaenSQL(ConsultaSQLGrilla, Grilla)
    End Sub



    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.F2 Then
            e.Handled = True

            ActualizaLaGrilla(Grilla, tb, Consulta_sql, cn1)
            Frm_BuscarXProducto_Mts.ShowDialog(Me)
            Codigo = Codigo_abuscar
            CrearDetalleParaGenerarEtiquetasDeBarraPorProducto("01", "CM", "PR", Codigo, TablaDePaso)
            ActualizarGrilla()

        End If
    End Sub

    Private Sub Grilla_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grilla.Enter
        GroupBox3.Text = "Detalle del documento, Preciona F2 para agregar un nuevo producto"
    End Sub

    Private Sub GroupBox3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Leave
        GroupBox3.Text = "Detalle del documento"
    End Sub
End Class