Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Familias

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim ConsultaSQLlocal As String

    Enum Tablas
        TABFM
        TABPF
        TABHF
    End Enum

    Public SuperFamilia As String
    Public Familia As String
    Public SubFamilia As String

    Dim TablActiva As String = "TABFM"

    Dim TablaFM As String = "TABFM"
    Dim TablaPF As String = ""
    Dim TablaHF As String = ""



#Region "FUNCIONES Y PROCEDIMIENTOS"

    Function CargarTabla() As DataTable

        Dim Campo1 As String
        Dim Campo2 As String
        Dim Condicion As String

        If TablActiva = Tablas.TABFM.ToString Then
            Campo1 = "KOFM"
            Campo2 = "NOKOFM"
            Condicion = ""
        ElseIf TablActiva = Tablas.TABPF.ToString Then
            Campo1 = "KOPF"
            Campo2 = "NOKOPF"
            Condicion = "AND KOFM = '" & SuperFamilia & "'"
        ElseIf TablActiva = Tablas.TABHF.ToString Then
            Campo1 = "KOHF"
            Campo2 = "NOKOHF"
            Condicion = "AND KOFM = '" & SuperFamilia & "' AND KOPF = '" & Familia & "'"
        End If


        Dim cadena = ""
        cadena = CADENA_A_BUSCAR(RTrim$(TxtDescripcion.Text), Campo2 & " LIKE '%")

        cadena = "WHERE " & Campo2 & " LIKE '%" & cadena


        Consulta_sql = "SELECT * From " & TablActiva & vbCrLf & cadena & "%'" & vbCrLf & Condicion


        ConsultaSQLlocal = Consulta_sql

        Dim Tabla = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim Spf = _Sql.Fx_Trae_Dato("TABFM", "NOKOFM", "KOFM = '" & SuperFamilia & "'")
        Dim Fam = _Sql.Fx_Trae_Dato("TABPF", "NOKOPF", "KOFM = '" & SuperFamilia & "' and KOPF = '" & Familia & "'")
        Dim Suf = _Sql.Fx_Trae_Dato("TABHF", "NOKOHF", "KOFM = '" & SuperFamilia & "' and KOPF = '" & Familia & "' and KOHF = '" & SubFamilia & "'")
        LblFamilia.Text = Spf & " - " & Fam & " - " & Suf

        Return Tabla

    End Function

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  
        Dim columna As Integer = GrillaFamilias.CurrentCell.ColumnIndex

        Dim IdColumna As Integer

        Dim row As DataGridViewRow = GrillaFamilias.CurrentRow
        If (row.IsNewRow) Then Return

        If TablActiva = Tablas.TABFM.ToString Then
            IdColumna = 0
        ElseIf TablActiva = Tablas.TABPF.ToString Then
            IdColumna = 1
        ElseIf TablActiva = Tablas.TABHF.ToString Then
            IdColumna = 2
        End If

        Dim Codigo = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(IdColumna).Value

        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        If columna = IdColumna Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' Si es la fila de nuevos registros, abandonamos el
            ' procedimiento.
            ' Valor de la columna "Unidades" de la fila actual

            'Dim Cod As Object = row.Cells(IdColumna).Value

            'If Codigo <> String.Empty Then

            e.Handled = False
            'Else
            '   e.Handled = False
        End If

        GrillaFamilias.Refresh()
        ' Valor de la columna "Concepto" de la fila actual



        ' End If



        ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
        ' es el separador decimal, y que no contiene ya el separador  
        'If ((Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ",") _
        '   And (txt.Text.Contains(",") = False)) _
        '   And Codigo <> "" Then
        'e.Handled = False
        'Else
        'e.Handled = True
        'End If


    End Sub

    Sub CargarGrilla(ByVal Tb As DataTable)
        Try

            Dim Codigo, Descripcion As String

            With GrillaFamilias

                .DataSource = Nothing
                .DataSource = Tb

                If TablActiva = Tablas.TABFM.ToString Then
                    Codigo = "KOFM"
                    Descripcion = "NOKOFM"
                ElseIf TablActiva = Tablas.TABPF.ToString Then
                    .Columns("KOFM").Visible = False
                    Codigo = "KOPF"
                    Descripcion = "NOKOPF"
                ElseIf TablActiva = Tablas.TABHF.ToString Then
                    .Columns("KOFM").Visible = False
                    .Columns("KOPF").Visible = False
                    Codigo = "KOHF"
                    Descripcion = "NOKOHF"
                End If


                .Columns(Codigo).Width = 80
                .Columns(Codigo).HeaderText = "Código"

                .Columns(Descripcion).Width = 250
                .Columns(Descripcion).HeaderText = "Descripción"

            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#End Region

    Private Sub GrillaFamilias_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaFamilias.CellDoubleClick
        Dim UltTablaActiva = TablActiva
        Try

            If TablActiva = Tablas.TABFM.ToString Then
                TablActiva = Tablas.TABPF.ToString
                SuperFamilia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(0).Value
                TxtDescripcion.Text = ""
            ElseIf TablActiva = Tablas.TABPF.ToString Then
                TablActiva = Tablas.TABHF.ToString
                Familia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(1).Value
                TxtDescripcion.Text = ""
            ElseIf TablActiva = Tablas.TABHF.ToString Then
                Exit Sub
            End If

            CargarGrilla(CargarTabla)
        Catch ex As Exception
            TablActiva = UltTablaActiva
        End Try

    End Sub

    Private Sub Frm_Familias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Formato_Generico_Grilla(GrillaFamilias, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        GrillaFamilias.RowHeadersVisible = True

        TablActiva = Tablas.TABFM.ToString
        SuperFamilia = ""
        Familia = ""
        SubFamilia = ""
        CargarGrilla(CargarTabla)
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click

        If TablActiva = Tablas.TABFM.ToString Then
            Exit Sub
        ElseIf TablActiva = Tablas.TABPF.ToString Then
            SuperFamilia = ""
            TablActiva = Tablas.TABFM.ToString
        ElseIf TablActiva = Tablas.TABHF.ToString Then
            TablActiva = Tablas.TABPF.ToString
            Familia = ""
            SubFamilia = ""
        End If

        Dim Spf = trae_dato(tb, cn1, "NOKOFM", "TABFM", "KOFM = '" & SuperFamilia & "'")
        Dim Fam = trae_dato(tb, cn1, "NOKOPF", "TABPF", "KOFM = '" & SuperFamilia & "' and KOPF = '" & Familia & "'")
        Dim Suf = trae_dato(tb, cn1, "NOKOHF", "TABHF", "KOFM = '" & SuperFamilia & "' and KOPF = '" & Familia & "' and KOHF = '" & SubFamilia & "'")
        LblFamilia.Text = Spf & " - " & Fam '& " - " & Suf


        CargarGrilla(CargarTabla)

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Try
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.

            If TablActiva = Tablas.TABPF.ToString Then
                For Each dRow As DataGridViewRow In GrillaFamilias.Rows
                    dRow.Cells(0).Value = SuperFamilia
                Next
            ElseIf TablActiva = Tablas.TABHF.ToString Then
                For Each dRow As DataGridViewRow In GrillaFamilias.Rows
                    dRow.Cells(0).Value = SuperFamilia
                    dRow.Cells(1).Value = Familia
                Next
            End If

            Dim dt As DataTable = DirectCast(GrillaFamilias.DataSource, DataTable)

            ' Procedemos a actualizar la base de datos.
            '
            Dim n As Integer = UpdateDatabase(dt, ConsultaSQLlocal)

            MessageBox.Show("Nº de registros afectados: " & CStr(n))

        Catch ex As Exception
            ' Se ha producido un error
            '
            MessageBox.Show(ex.Message)

        End Try


        Exit Sub

        Dim Frm_IngresarDato As New Frm_IngresarDato

        Dim CampoDe As String
        Dim Codigo As String
        Dim Descripcion As String
        Dim UltTablaActiva = TablActiva
        Dim Nueva As String
        
        If TablActiva = Tablas.TABFM.ToString Then
            'TablActiva = Tablas.TABPF.ToString
            Codigo = SuperFamilia
            Nueva = "Super Familia"
            CampoDe = "NOKOFM"
        ElseIf TablActiva = Tablas.TABPF.ToString Then
            'TablActiva = Tablas.TABHF.ToString
            Codigo = Familia
            Nueva = "Familia"
            CampoDe = "NOKOPF"
        ElseIf TablActiva = Tablas.TABHF.ToString Then
            Codigo = SubFamilia
            Nueva = "Sub Familia"
            CampoDe = "NOKOHF"
        End If


        With Frm_IngresarDato
            .SuperFamilia = SuperFamilia
            .Familia = Familia
            .SubFamilia = SubFamilia
            .TablaSQL = TablActiva
            .Text = "Nueva " & Nueva
            .ShowInTaskbar = False
            .Accion = "Grabar"
            .ShowDialog(Me)

            If .Proceso = True Then
                CargarGrilla(CargarTabla)
            End If

        End With

    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        Dim Frm_IngresarDato As New Frm_IngresarDato

        Dim CampoDe As String
        Dim Codigo As String
        Dim Descripcion As String
        Dim UltTablaActiva = TablActiva
        Dim Nueva As String
        Try

            If TablActiva = Tablas.TABFM.ToString Then
                TablActiva = Tablas.TABPF.ToString
                SuperFamilia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells("Codigo").Value
                Codigo = SuperFamilia
                Nueva = "Super Familia"
                CampoDe = "NOKOFM"
            ElseIf TablActiva = Tablas.TABPF.ToString Then
                TablActiva = Tablas.TABHF.ToString
                Familia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells("Codigo").Value
                Codigo = Familia
                Nueva = "Familia"
                CampoDe = "NOKOPF"
            ElseIf TablActiva = Tablas.TABHF.ToString Then
                SubFamilia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells("Codigo").Value
                Codigo = SubFamilia
                Nueva = "Sub Familia"
                CampoDe = "NOKOHF"
                'Exit Sub
            End If

            Descripcion = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells("Descripcion").Value

        Catch ex As Exception
            Exit Sub
        End Try




        With Frm_IngresarDato
            .SuperFamilia = SuperFamilia
            .Familia = Familia
            .SubFamilia = SubFamilia
            .TablaSQL = TablActiva
            .Text = "Actualizar " & Nueva
            .ShowInTaskbar = False
            .Accion = "Editar"
            .TxtCodigo.Enabled = False
            .TxtCodigo.Text = Codigo
            .TxtDecripcion.Text = Descripcion
            .CampoDet = CampoDe
            .ShowDialog(Me)

            If .Proceso = True Then
                CargarGrilla(CargarTabla)
            End If

        End With

    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click

        Try


            'Dim Descripcion = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells("Descripcion").Value

            Dim dlg As System.Windows.Forms.DialogResult = _
            MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) línea(s) seleccionada(s)?", _
                              "Eliminar línea", MessageBoxButtons.YesNo)


            If dlg = System.Windows.Forms.DialogResult.Yes Then

                For Each Seleccion As DataGridViewRow In GrillaFamilias.SelectedRows

                    Dim Cod = ObtenerValoresFila(Seleccion, GrillaFamilias)

                    If TablActiva = Tablas.TABFM.ToString Then
                        'SuperFamilia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(0).Value
                        'Consulta_sql = "DELETE TABFM WHERE KOFM = '" & Cod(0) & "'"
                    ElseIf TablActiva = Tablas.TABPF.ToString Then
                        'Familia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(1).Value
                        'Consulta_sql = "DELETE TABPF WHERE KOFM = '" & SuperFamilia & "' AND KOPF = '" & Cod(1) & "'"
                        Familia = ""
                    ElseIf TablActiva = Tablas.TABHF.ToString Then
                        'SubFamilia = GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells("Codigo").Value
                        ' Consulta_sql = "DELETE TABHF WHERE KOFM = '" & SuperFamilia & _
                        ''                             "' AND KOPF = '" & Familia & _
                        '                            "' AND KOHF = '" & Cod(2) & "'"
                        SubFamilia = ""
                    End If

                    'If Ej_consulta_IDU(Consulta_sql, cn1) Then
                    GrillaFamilias.Rows.Remove(Seleccion)
                    'End If

                Next


            End If
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ObtenerValoresFila(ByVal fila As DataGridViewRow, ByVal GrillaOrigen As DataGridView) As String()
        'Dimensionar el array al tamaño de columnas del DGVn
        Dim NroColumas As Long = GrillaOrigen.ColumnCount - 1
        Dim Contenido(NroColumas) As String
        'Rellenar el contenido con el valor de las celdas de la fila
        For Ndx As Integer = 0 To NroColumas
            Contenido(Ndx) = fila.Cells(Ndx).Value
        Next
        Return Contenido
    End Function

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub



    


    Private Sub GrillaFamilias_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaFamilias.CellEnter

        Try

            Dim row As DataGridViewRow = GrillaFamilias.CurrentRow
            Dim Registro As Integer
            Dim Columna As Integer
            Dim Valor As String

            If (row.IsNewRow) Then

                If TablActiva = Tablas.TABFM.ToString Then
                    Columna = 0
                ElseIf TablActiva = Tablas.TABPF.ToString Then
                    Columna = 1
                ElseIf TablActiva = Tablas.TABHF.ToString Then
                    Columna = 2
                End If

                GrillaFamilias.Columns(Columna).ReadOnly = False
                Return
            End If

            If TablActiva = Tablas.TABFM.ToString Then
                Valor = (GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(0).Value)
                Registro = Cuenta_registros("TABFM", "KOFM = '" & Valor & "'")
                Columna = 0
            ElseIf TablActiva = Tablas.TABPF.ToString Then
                Valor = (GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(1).Value)
                Registro = Cuenta_registros("TABPF", "KOFM = '" & SuperFamilia & "' and KOPF = '" & Valor & "'")
                Columna = 1
            ElseIf TablActiva = Tablas.TABHF.ToString Then
                Valor = (GrillaFamilias.Rows(GrillaFamilias.CurrentRow.Index).Cells(2).Value)
                Registro = Cuenta_registros("TABHF", "KOFM = '" & SuperFamilia & "' and KOPF = '" & Familia & "' and KOHF = '" & Valor & "'")
                Columna = 2
            End If

          

            If Registro = 0 Then
                GrillaFamilias.Columns(Columna).ReadOnly = False
            Else
                GrillaFamilias.Columns(Columna).ReadOnly = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcion.TextChanged
        CargarGrilla(CargarTabla)
    End Sub
End Class