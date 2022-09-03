Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class Frm_SeleccionarProductos

    Dim TablaDePasoPr1 As String = "TblPasoPr" & FUNCIONARIO
    Public TablaDePasoPr2 As String = "TblMprPaso" & FUNCIONARIO


    Dim SQLGrilla1, SQLGrilla2 As String

    Dim TablaG1 As DataTable
    Dim TablaG2 As DataTable

    Dim TablaPs As String = "Zw_TblPasoProductosSel" & FUNCIONARIO

    Public Sub CrearTblPasoPrd()

        Consulta_sql = My.Resources.Crear_Tabla_de_paso_de_productos
        Consulta_sql = Replace(Consulta_sql, "TblMaeprPaso", TablaDePasoPr1)
        Consulta_sql = Replace(Consulta_sql, "TblMprPaso", TablaDePasoPr2)
        Ej_consulta_IDU(Consulta_sql, cn1)

    End Sub

    Function buscar(ByVal codigo As String, _
                    ByVal descripcion As String, _
                    ByVal Grilla As DataGridView, _
                    ByVal TablaDePaso1 As String, _
                    ByVal TablaDePaso2 As String)

        Consulta_sql = "SELECT TOP (100) KOPR,NOKOPR" & vbCrLf & _
                       "FROM " & TablaDePaso1 & vbCrLf & _
                       "WHERE KOPR LIKE '" & codigo & "%' " & _
                       "AND NOKOPR  LIKE '%" & descripcion & "%'" & vbCrLf & _
                       "AND KOPR NOT IN (SELECT KOPR FROM " & TablaDePaso2 & ")" & vbCrLf & _
                       "ORDER BY KOPR"

        With Grilla
            .DataSource = get_Tablas(Consulta_sql, cn1)

            .Columns("KOPR").Width = 100
            .Columns("KOPR").HeaderText = "Código"

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción"

        End With

    End Function

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionL.TextChanged
        buscar("", _
               CADENA_A_BUSCAR(RTrim$(TxtDescripcionL.Text), _
                               "NOKOPR LIKE '%"), Grilla1, TablaDePasoPr1, TablaDePasoPr2)
    End Sub


#Region "FUNCIONES PARA MOVER DATOS DE UNA GRILLA A OTRA"

    'Mover los elementos seleccionados del DGV1 al DGV2
    Function MoverSeleccionadosDGVaDGV(ByVal GrillaOrigen As DataGridView, _
                                         ByVal GrillaDestino As DataGridView, _
                                         ByVal Tabla As DataTable)

        'Para cada fila seleccionada
        For Each Seleccion As DataGridViewRow In GrillaOrigen.SelectedRows
            'Añadir los valores obtenidos de la fila seleccionada
            'al segundo datagridview
            'GrillaDestino.Rows.Add(ObtenerValoresFila(Seleccion, GrillaOrigen))
            Tabla.Rows.Add(ObtenerValoresFila(Seleccion, GrillaOrigen))
            'eliminar la fila del DataGridView origen
            GrillaOrigen.Rows.Remove(Seleccion)

        Next


    End Function

    'Obtener el contenido de la fila en un string()
    'con el proposito de copiarlo o moverlo

    'Recibe el 'row' y retorna su contenido en un array tipo string
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

#End Region


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        With Grilla1
            .RowTemplate.Height = 15
            .DefaultCellStyle.Font = New Font("Tahoma", 8)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod
        End With

        With Grilla2
            .RowTemplate.Height = 15
            .DefaultCellStyle.Font = New Font("Tahoma", 8)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod
        End With





        Consulta_sql = "SELECT * FROM " & TablaDePasoPr1
        SQLGrilla1 = Consulta_sql
        ActualizarGrillasProSelec(SQLGrilla1, Grilla1)
        TablaG1 = DirectCast(Grilla1.DataSource, DataTable)


        'buscar(TxtCodigo.Text, TxtDescripcion.Text)


        Consulta_sql = "SELECT * FROM " & TablaDePasoPr2
        SQLGrilla2 = Consulta_sql
        ActualizarGrillasProSelec(SQLGrilla2, Grilla2)
        TablaG2 = DirectCast(Grilla2.DataSource, DataTable)

        'ActualizarGd2()

    End Sub

    Function ActualizarGrillasProSelec(ByVal SQL As String, ByVal Grilla As DataGridView)

        'ActualizaLaGrilla(Grilla, tb, SQL, cn1)

        Grilla.DataSource = get_Tablas(SQL, cn1)

        With Grilla
            .Columns("KOPR").Width = 100
            .Columns("KOPR").HeaderText = "Código"

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción"
        End With


    End Function



    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click

        'SQL_ServerClass.ActualizarGrillaUpInsDel(SQLGrilla2, Grilla2, cn1)

        For Each Seleccion As DataGridViewRow In Grilla1.SelectedRows
            Dim Cod = ObtenerValoresFila(Seleccion, Grilla1)
            Consulta_sql = "INSERT INTO " & TablaDePasoPr2 & " (KOPR,NOKOPR) VALUES ('" & Cod(0) & "','" & Cod(1) & "') "
            Ej_consulta_IDU(Consulta_sql, cn1)
        Next

        MoverSeleccionadosDGVaDGV(Grilla1, Grilla2, TablaG2)

        Dim Ch As DataGridViewColumn = Grilla2.Columns.Item(0)
        Grilla2.Sort(Ch, ListSortDirection.Ascending)


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

        For Each Seleccion As DataGridViewRow In Grilla2.SelectedRows
            Dim Cod = ObtenerValoresFila(Seleccion, Grilla2)
            Consulta_sql = "DELETE " & TablaDePasoPr2 & vbCrLf & _
                           "WHERE KOPR = '" & Cod(0) & "'"
            Ej_consulta_IDU(Consulta_sql, cn1)
        Next

        MoverSeleccionadosDGVaDGV(Grilla2, Grilla1, TablaG1)

        Dim Ch As DataGridViewColumn = Grilla1.Columns.Item(0)
        Grilla1.Sort(Ch, ListSortDirection.Ascending)


    End Sub



    Private Function CrearTablaDePasoProdcutsoSeleccionados() As DataTable



        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='" & TablaPs & "') BEGIN " & vbCrLf & _
                           "DROP TABLE " & TablaPs & " End " & vbCrLf
        Ej_consulta_IDU(Consulta_sql, cn1)

        Consulta_sql = "CREATE TABLE [dbo].[" & TablaPs & "](" & vbCrLf & _
                       "[CodProducto] [varchar] (13) NOT NULL," & vbCrLf & _
                       "[Descripcion] [varchar] (50) NULL," & vbCrLf & _
                       ") ON [PRIMARY]" & vbCrLf & _
                       "SET ANSI_PADDING OFF" & vbCrLf & _
                       "CREATE UNIQUE NONCLUSTERED INDEX [IX_" & TablaPs & _
                       "] ON [dbo].[" & TablaPs & "] ([CodProducto])"

        'Ej_consulta_IDU(Consulta_sql, cn1)

        Dim Tab As DataTable
        Tab = get_Tablas(Consulta_sql, cn1)

        'Consulta_sql = " INSERT INTO " & Tabla & " (CodFuncionario,NombreFuncionario) SELECT KOFU,NOKOFU FROM TABFU WHERE KOFU NOT IN (SELECT CodFuncionario from ZW_TmpInvFuncionariosLideres)"
        'Ej_consulta_IDU(Consulta_sql, cn1)
        Return Tab

    End Function


    
    Private Sub TxtDescripcionR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionR.TextChanged
        buscar("", _
              CADENA_A_BUSCAR(RTrim$(TxtDescripcionR.Text), _
                              "NOKOPR LIKE '%"), Grilla2, TablaDePasoPr2, TablaDePasoPr1)
    End Sub

    Private Sub Frm_SeleccionarProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Me.Close()
    End Sub
End Class