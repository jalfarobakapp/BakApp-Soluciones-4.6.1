Imports Funciones_BakApp


Public Class Frm_ImpBarrasPorDocumento
    Dim ConsultaSQLGrilla As String = ""
    Dim TablaDePaso As String

    Function ActualizarGrilla()

        Consulta_sql = "SELECT Idmaeddo,Seleccion,CodProducto,CodProductoProveedor,Descripcion,Cantidad,Ubicacion FROM " & TablaDePaso
        ConsultaSQLGrilla = Consulta_sql

        Ejecutar_consulta_SQL(Consulta_sql, cn1)
        tb = New DataTable
        da.Fill(tb)
        Grilla.DataSource = tb

        With Grilla
            .Columns("CodProducto").HeaderText = "Código"
            .Columns("CodProductoProveedor").HeaderText = "Cód. Entidad"
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Ubicacion").HeaderText = "Ubicación"

            .Columns("CodProducto").ReadOnly = True
            .Columns("CodProductoProveedor").ReadOnly = True
            .Columns("Descripcion").ReadOnly = True
            .Columns("Ubicacion").ReadOnly = True

            .AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells

            .Columns("Idmaeddo").Visible = False
        End With

    End Function


    Private Sub Frm_ImpBarrasPorDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TablaDePaso = "Zw_TmpTblDocBarras" & FUNCIONARIO
        ActualizarGrilla()

        Txtipodocumento.Text = trae_dato(tb, cn1, "TIDO", "MAEEDO", "IDMAEEDO = " & IDdocumentoSeleccionado)
        Txtnrodocumento.Text = trae_dato(tb, cn1, "NUDO", "MAEEDO", "IDMAEEDO = " & IDdocumentoSeleccionado)
        Dim CodEntidad As String
        Dim CodSucursal As String

        CodEntidad = trae_dato(tb, cn1, "ENDO", "MAEEDO", "IDMAEEDO = " & IDdocumentoSeleccionado)
        CodSucursal = trae_dato(tb, cn1, "SUENDO", "MAEEDO", "IDMAEEDO = " & IDdocumentoSeleccionado)
        txtcodigoentidad.Text = CodEntidad

        txtrazonsocial.Text = trae_dato(tb, cn1, "NOKOEN", "MAEEN", "KOEN = '" & CodEntidad & "' AND SUEN = '" & CodSucursal & "'")

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT Semilla AS Padre,NombreEtiqueta AS Hijo FROM Zw_Tbl_DisenoBarras order by NombreEtiqueta"
        Cmbetiquetas.DataSource = get_Tablas(Consulta_sql, cn1)

        Puerto = LTrim$(RTrim$(Ruta_conexion(AppPath(True) & "Barras\Puerto.txt")))
        Txtveces.Text = trae_dato(tb, cn1, "CantPorLinea", "Zw_Tbl_DisenoBarras", "Semilla = " & Cmbetiquetas.SelectedValue.ToString)
    End Sub

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


    Private Sub Grilla_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyUp

        'ActualizarGrillaenSQL(ConsultaSQLGrilla, Grilla)
    End Sub
    Function ActualizarGrillaSQL()
        Dim sql1 As String = ConsultaSQLGrilla

        Try
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.

            Dim dt As DataTable = DirectCast(Grilla.DataSource, DataTable)

            ' Procedemos a actualizar la base de datos.

            Dim n As Integer = UpdateDatabase(dt, sql1, cn1)

            'MessageBox.Show("Nº de registros afectados: " & CStr(n))

        Catch ex As Exception
            ' Se ha producido un error

            MessageBox.Show(ex.Message)

        End Try
    End Function


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
                Dim Ubicacion As String = trae_dato(tb, cn1, "DATOSUBIC", "TABBOPR", "EMPRESA = '01'" & _
                                                    " AND KOSU = '" & Sucursar & "' AND KOBO = '" & Bodega & "' AND KOPR = '" & CodProducto & "'")

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
                                   Ubicacion, , Txtipodocumento.Text, Txtnrodocumento.Text)
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

    Private Sub Btnimprimiretiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnimprimiretiquetas.Click
        ActualizarGrillaSQL()
        ImprimirEtiquetas()
    End Sub

    Private Sub Cmbetiquetas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbetiquetas.SelectedIndexChanged
        Txtveces.Text = trae_dato(tb, cn1, "CantPorLinea", "Zw_Tbl_DisenoBarras", "Semilla = " & Cmbetiquetas.SelectedValue.ToString)
    End Sub




    Private Sub TxtDescripcionAbuscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcionAbuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Dim Columna As String

            If CmbBuscarProducto.Text = "CODIGO PRINCIPAL" Then Columna = "CodProducto"
            If CmbBuscarProducto.Text = "CODIGO ENTIDAD (ALTERNATIVO)" Then Columna = "CodProductoProveedor"
            If CmbBuscarProducto.Text = "DESCRIPCION" Then Columna = "Descripcion"

            BuscarDatoEnGrilla(TxtDescripcionAbuscar.Text, Columna, Grilla)

        End If

    End Sub

    Private Sub BtnImprimirCero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirCero.Click

        ActualizarGrillaSQL()

        Dim Ruta As String = AppPath(True)
        Dim Archivo As String = "Archivo.txt"

        Dim CodigoPrincipal As String
        Dim CodigoProveedor As String
        Dim Descripcion As String
        Dim Detalle As String = ""

        Try

            Consulta_sql = "SELECT CodProducto,CodProductoProveedor,Descripcion,Cantidad,Ubicacion FROM " & TablaDePaso & vbCrLf & _
                           "WHERE Cantidad = 0"
            Dim Tabla As New DataTable


            Tabla = get_Tablas(Consulta_sql, cn1)

            If Tabla.Rows.Count > 0 Then
                Dim Fila As DataRow

                For i = 0 To Tabla.Rows.Count - 1
                    Fila = Tabla.Rows(i)
                    CodigoPrincipal = Fila.Item("CodProducto").ToString
                    CodigoPrincipal = Rellenar(trae_dato(tb, cn1, "KOPRTE", "MAEPR", "KOPR = '" & CodigoPrincipal & "'"), 20, " ")
                    CodigoProveedor = Rellenar(Fila.Item("CodProductoProveedor").ToString, 20, " ")
                    Descripcion = Rellenar(Mid(Fila.Item("Descripcion").ToString, 1, 43), 43, " ")
                    Detalle = Detalle & "|  " & CodigoPrincipal & " | " & CodigoProveedor & " | " & Descripcion & "   | " & vbCrLf
                Next

                Dim Encabezado As String = ""
                Encabezado = RazonEmpresa & vbCrLf & RutEmpresa & vbCrLf & vbCrLf & _
                             "Entidad: " & Rellenar(txtrazonsocial.Text, 58, " ") & _
                             "Tipo Doc. " & Txtipodocumento.Text & " Nro:" & Txtnrodocumento.Text & vbCrLf & _
                             vbCrLf & _
                             " +----------------------------------------------------------------------------------------------+" & vbCrLf & _
                             " |  CODIGO RANDOM        | CODIGO ENTIDAD       | DESCRIPCION                                   |" & vbCrLf & _
                             " +----------------------------------------------------------------------------------------------+" & vbCrLf

                Dim Pie As String
                Pie = "+----------------------------------------------------------------------------------------------+"

                Dim Cuerpo As String = ""
                Cuerpo = Chr(15) & Encabezado & Detalle & Pie & Chr(18)

                CrearArchivoTxt(Ruta, Archivo, Cuerpo)
                System.IO.File.Copy(Ruta & Archivo, CmbpuertoLPT.Text)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Function CrearArchivoTxt(ByVal Ruta As String, ByVal NombreArchivo As String, ByVal Cuerpo As String)
        Dim RutaArchivo As String = Ruta & NombreArchivo
        'Kill(RutaArchivo)
        Dim oSW As New System.IO.StreamWriter(RutaArchivo)

        oSW.WriteLine(Cuerpo)
        oSW.Close()

        'aqui creo el archivo oculto,,, si no se pone este instrucion no pasa nada .. solo es para 
        'asignarles caracteristicas a los archivos 
        'quitalo como comentario y calalo
        'SetAttr(RutaArchivo, vbHidden)

    End Function


End Class