Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports Lib_Bakapp_VarClassFunc


Public Class Frm_SeleccionarProductos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim TablaDePasoPr1 As String = "TblPasoPr" & FUNCIONARIO
    Public TablaDePasoPr2 As String = "TblMprPaso" & FUNCIONARIO

    Public CodInforme As String

    Dim SQLGrilla1, SQLGrilla2 As String

    Public _TablaG1 As DataTable
    Public _TablaG2 As DataTable

    Dim TablaPs As String = "Zw_TblPasoProductosSel" & FUNCIONARIO
    Public Datos As New DsFiltros
    Public _Filtro_Productos As String
    Public _NewFiltro_Productos As String
    Public _Filtrar As Boolean

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
                    ByVal TablaDePaso2 As String, _
                    ByVal Solo_Codigo As Boolean)

        Grilla2.RefreshEdit()
        Dim Filtro As String

        'Datos.WriteXml(AppPath() & "\Data\Filtro.xml") 'Documento_vta
        'Dim Dts As New DataSet
        'Dts.ReadXml(AppPath() & "\Data\Filtro.xml")

        Dim Filas As Integer = Grilla2.RowCount ' TablaG2.Rows.Count 'Datos.Tables("Filtro").Rows.Count

        If Filas > 0 Then

            'TablaG2 = Dts.Tables("Filtro")
            _NewFiltro_Productos = Generar_Filtro_IN(_TablaG2, "", "Codigo", False, False, "'")
            '_NewFiltro_Productos = Replace(_NewFiltro_Productos, "''", "'")
            '_NewFiltro_Productos = Replace(_NewFiltro_Productos, "()", "('')")

            Filtro = "AND KOPR NOT IN " & _NewFiltro_Productos & vbCrLf

        Else
            Filtro = String.Empty
        End If

        If Solo_Codigo Then
            Consulta_sql = "SELECT TOP 1000 CAST( 1 AS bit) AS Chk,KOPR,NOKOPR" & vbCrLf & _
                                   "FROM MAEPR" & vbCrLf & _
                                   "WHERE KOPR LIKE '" & codigo & "%'" & vbCrLf & _
                                   Filtro & _
                                   "ORDER BY NOKOPR"
        Else
            Consulta_sql = "SELECT TOP 1000 CAST( 1 AS bit) AS Chk,KOPR,NOKOPR" & vbCrLf & _
                                   "FROM MAEPR" & vbCrLf & _
                                   "WHERE KOPR+NOKOPR LIKE '%" & descripcion & "%'" & vbCrLf & _
                                   Filtro & _
                                   "ORDER BY NOKOPR"
        End If

        ActualizarGrillasProSelec(Consulta_sql, Grilla)

    End Function

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionL.TextChanged
        buscar("", _
               CADENA_A_BUSCAR(RTrim$(TxtDescripcionL.Text), _
                               "KOPR+NOKOPR LIKE '%"), Grilla1, TablaDePasoPr1, TablaDePasoPr2, False)
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
    Function ObtenerValoresFila(ByVal fila As DataGridViewRow, _
                                ByVal GrillaOrigen As DataGridView) As String()
        'Dimensionar el array al tamaño de columnas del DGVn
        Dim NroColumas As Long = GrillaOrigen.ColumnCount - 1
        Dim Contenido(NroColumas) As String
        'Rellenar el contenido con el valor de las celdas de la fila
        'Contenido(0) = True

        For Ndx As Integer = 0 To NroColumas
            Dim TipoDeDato As String = GrillaOrigen.Columns(Ndx).ValueType.ToString

            Contenido(Ndx) = Trim(fila.Cells(Ndx).Value)
        Next
        Return Contenido
    End Function

#End Region


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Formato_Generico_Grilla(Grilla1, 15, New Font("Tahoma", 7.5), Color.PaleGoldenrod, ScrollBars.Vertical, True, False, False)
        Formato_Generico_Grilla(Grilla2, 15, New Font("Tahoma", 7.5), Color.PaleGoldenrod, ScrollBars.Vertical, True, True, False)

    End Sub

    Function ActualizarGrillasProSelec(ByVal SQL As String, ByVal Grilla As DataGridView)

        'ActualizaLaGrilla(Grilla, tb, SQL, cn1)

        Grilla.DataSource = get_Tablas(SQL, cn1)

        With Grilla

            .Columns("Chk").Visible = False

            .Columns("KOPR").Width = 100
            .Columns("KOPR").HeaderText = "Código"

            .Columns("NOKOPR").Width = 230
            .Columns("NOKOPR").HeaderText = "Descripción"
        End With


    End Function

    Sub ActualizaGrilla2(ByVal SqlQuery As String)

        Datos.Clear()
        Grilla2.DataSource = Nothing

        Dim daAuthors As _
        New SqlDataAdapter(SqlQuery, cn1)

        daAuthors.Fill(Datos, "Filtro")

        With Grilla2

            .DataSource = Datos '.Tables("DetalleDocumento")
            .DataMember = Datos.Tables("Filtro").TableName

            .Columns("Chk").Visible = False

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True

            .Columns("Descripcion").Width = 230
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
        End With

        'Datos.WriteXml(AppPath() & "\Data\Filtro.xml") 'Documento_vta

    End Sub

#Region "Mover"

    Sub _Mover_De_Izquierda_a_Derecha()
        MoverSeleccionadosDGVaDGV(Grilla1, Grilla2, Datos.Tables("Filtro"))

        If Grilla2.RowCount > 0 Then
            Dim Ch As DataGridViewColumn = Grilla2.Columns.Item(0)
            Grilla2.Sort(Ch, ListSortDirection.Ascending)
        End If

        _TablaG2 = Datos.Tables("Filtro")

        If Grilla1.Rows.Count = 0 Then
            If String.IsNullOrEmpty(Trim(TxtCodigo.Text)) Then
                buscar("", _
                       CADENA_A_BUSCAR(RTrim$(TxtDescripcionL.Text), _
                                       "KOPR+NOKOPR LIKE '%"), Grilla1, TablaDePasoPr1, TablaDePasoPr2, False)
            ElseIf String.IsNullOrEmpty(Trim(TxtDescripcionL.Text)) Then
                buscar(TxtCodigo.Text, "", Grilla1, TablaDePasoPr1, TablaDePasoPr2, True)
            End If
        End If



    End Sub


    Sub _Mover_De_Derecha_a_Izquierda()

        _TablaG1 = DirectCast(Grilla1.DataSource, DataTable)
        MoverSeleccionadosDGVaDGV(Grilla2, Grilla1, _TablaG1)

        buscar("", _
             CADENA_A_BUSCAR(RTrim$(TxtDescripcionL.Text), _
                             "KOPR+NOKOPR LIKE '%"), Grilla1, TablaDePasoPr1, TablaDePasoPr2, False)

        Dim Ch As DataGridViewColumn = Grilla1.Columns.Item(0)
        Grilla1.Sort(Ch, ListSortDirection.Ascending)
        _TablaG2 = Datos.Tables("Filtro")


    End Sub
#End Region


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        If (_TablaG2 Is Nothing) Then
            _Filtrar = False
            Me.Close()
        End If
 
        'Datos.WriteXml(AppPath() & "\Data\Filtro.xml")
        'Dim Dts As New DataSet
        'Dts.ReadXml(AppPath() & "\Data\Filtro.xml")

        'Dim Filtro = Generar_Filtro_IN(_TablaG2, "", "Codigo", False, False, "'")

        _Filtro_Productos = Generar_Filtro_IN(_TablaG2, "", "Codigo", False, False, "'")
        '_Filtro_Productos = Replace(_Filtro_Productos, "''", "'")
        '_Filtro_Productos = Replace(_Filtro_Productos, "()", "('')")
        '_Filtrar = True
        '_TablaG2 = Dts.Tables("Filtro")

        'If (TablaG2 Is Nothing) Then _Filtrar = False
        _Filtrar = True 'CBool(_TablaG2.Rows.Count)


        Me.Close()

    End Sub

    Private Sub Frm_SeleccionarProductos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Fl As String ' = Generar_Filtro_IN(_TablaG2, "", "Codigo", False, False, "'") '_Filtro_Productos

        Dim _Cargar As Boolean

        If Not (_TablaG2 Is Nothing) Then
            _Cargar = CBool(_TablaG2.Rows.Count)
        End If

        If _Cargar Then
            Fl = Generar_Filtro_IN(_TablaG2, "", "Codigo", False, False, "'")
            Consulta_sql = "Select CAST( 1 AS bit) AS Chk,KOPR as Codigo,NOKOPR as Descripcion From MAEPR" & vbCrLf & _
            "Where KOPR in " & Fl
        Else
            Consulta_sql = "Select CAST( 1 AS bit) AS Chk,KOPR as Codigo,NOKOPR as Descripcion From MAEPR" & vbCrLf & _
            "Where 1 = 0"
        End If



        ActualizaGrilla2(Consulta_sql)

        'Dim Filtro = Generar_Filtro_IN(Datos.Tables("Filtro"), "", "Codigo", False, False)

        'Generar_Filtro_IN(Datos.Tables("Filtro"), "", "Codigo", False, False)

        buscar("", _
              CADENA_A_BUSCAR("", _
                              "KOPR+NOKOPR LIKE '%"), Grilla1, TablaDePasoPr1, TablaDePasoPr2, False)

        Me.ActiveControl = TxtDescripcionL

    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Filtro = Generar_Filtro_IN(Datos.Tables("Filtro"), "", "Codigo", False, False)

        Consulta_sql = "Delete Zw_TblFiltro_InfxUs" & vbCrLf & _
                       "Where Informe = '" & CodInforme & "' And Funcionario = '" & FUNCIONARIO & "' And Tabla = 'MAEPR'" & vbCrLf & _
                       "Insert into Zw_TblFiltro_InfxUs (Funcionario, Informe, Tabla, Codigo,Filtro,MarcarTodo)" & vbCrLf & _
                       "Values ('" & FUNCIONARIO & "','" & CodInforme & _
                       "','MAEPR','Productos','" & Filtro & "',0)"
        Ej_consulta_IDU(Consulta_sql, cn1)

        Me.Close()
    End Sub


    Private Sub BtnFiltroPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Fm As New Frm_Filtro_ProductosClass
        Fm.CodInforme = "FlProductos"
        Fm.ShowDialog(Me)
    End Sub


    Private Sub BtnDeIzqDer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeIzqDer.Click
        _Mover_De_Izquierda_a_Derecha()
    End Sub


    Private Sub BtnDeDerIzq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeDerIzq.Click
        _Mover_De_Derecha_a_Izquierda()
    End Sub

    Private Sub Grilla1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla1.CellDoubleClick
        _Mover_De_Izquierda_a_Derecha()
    End Sub

    Private Sub Grilla2_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla2.CellDoubleClick
        _Mover_De_Derecha_a_Izquierda()
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged
        TxtDescripcionL.Text = String.Empty
        buscar(TxtCodigo.Text, "", Grilla1, TablaDePasoPr1, TablaDePasoPr2, True)
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        _Filtrar = False
        Me.Close()
    End Sub
End Class