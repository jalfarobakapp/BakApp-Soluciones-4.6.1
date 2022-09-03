Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient


Public Class Frm_Tabla_Caracterizaciones_01_Listado

    Public _Nombre_Tabla_Rd As String ' Nombre de la tabla en Random
    Public _Campo_Id, _Campo_Descripcion As String ' Campos para llenar la tabla en Random 

    Public _CodTablaClass As String
    Public _CodClass As String
    Public _DesClassOrigen As String
    Public _DesClassAltern As String

    Dim FilaSeleccionada As Integer

    Dim _ConsultaSQLlocal As String
    Dim _Ds_Caract As New Ds_Especiales

    Public _Seleccionar As Boolean
    Public _FilaSeleccionada(5) As String
    Public _Seleccionada As Boolean

    Private _dv As New DataView

    Sub Sb_Actualizar_Grilla(ByVal Descripcion As String)

        Dim Condicion = _
               CADENA_A_BUSCAR(Descripcion, _
                               "CodigoTabla+DescripcionTabla LIKE '%")

        Consulta_sql = "SELECT CodigoTabla,DescripcionTabla,NombreTabla," & vbCrLf & _
                       "ApColor," & vbCrLf & _
                       "ApMedida," & vbCrLf & _
                       "ApModelo From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "Where Tabla = '" & _CodTablaClass & "'" & vbCrLf & _
                       "And CodigoTabla+DescripcionTabla like '%" & Condicion & "%'" & vbCrLf & _
                       "Order by DescripcionTabla"

        _ConsultaSQLlocal = Consulta_sql

        _Ds_Caract.Clear()

        Dim daAuthors As New SqlDataAdapter(Consulta_sql, cn1)
        daAuthors.Fill(_Ds_Caract, "Tbl_Caracterizaciones")


        _dv.Table = _Ds_Caract.Tables("Tbl_Caracterizaciones")

        With Grilla
            .DataSource = Nothing

            If _Seleccionar Then
                .DataSource = _dv
            Else
                .DataSource = _Ds_Caract
                .DataMember = _Ds_Caract.Tables("Tbl_Caracterizaciones").TableName
            End If

            
            
            OcultarEncabezadoGrilla(Grilla, True)

            '.Columns("CodigoTabla").HeaderText = "Código"
            '.Columns("CodigoTabla").Width = 50
            '.Columns("CodigoTabla").Visible = True

            .Columns("DescripcionTabla").HeaderText = "Descripción"
            .Columns("DescripcionTabla").Width = 425
            .Columns("DescripcionTabla").Visible = True

            If _Seleccionar Then
                .Columns("DescripcionTabla").ReadOnly = True
            End If

            '.Columns("NombreTabla").HeaderText = "Descripción alternativa"
            '.Columns("NombreTabla").Width = 250
            '.Columns("NombreTabla").Visible = True

            .Columns("ApColor").HeaderText = "Color"
            .Columns("ApColor").Width = 60

            .Columns("ApModelo").HeaderText = "Modelo"
            .Columns("ApModelo").Width = 60

            .Columns("ApMedida").HeaderText = "Medida"
            .Columns("ApMedida").Width = 60

            If _CodTablaClass = "ARTICULO" Then
                .Columns("ApColor").Visible = True
                .Columns("ApModelo").Visible = True
                .Columns("ApMedida").Visible = True
            End If



            If CBool(.RowCount) Then
                .FirstDisplayedScrollingRowIndex = .RowCount - 1
                .CurrentCell = .Rows(.RowCount - 1).Cells("DescripcionTabla")
            End If


        End With

    End Sub


    Private Sub BtnCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrear.Click

        If _Seleccionar Then
            If TienePermiso("Tbl00016") Then
                Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado
                Fm._CodTablaClass = _CodTablaClass
                Fm.Text = Me.Text
                Fm.ShowDialog(Me)

                TxtDescripcion.Text = String.Empty
                Sb_Actualizar_Grilla("")

            End If
        Else
            With Grilla
                If CBool(.RowCount) Then
                    .FirstDisplayedScrollingRowIndex = .RowCount - 1
                    .CurrentCell = .Rows(.RowCount - 1).Cells("DescripcionTabla")
                    .BeginEdit(True)
                End If
            End With
        End If

    End Sub

    Private Sub Frm_Tabla_Caracterizaciones_01_Listado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla("")

        If Not String.IsNullOrEmpty(TxtDescripcion.Text) Then
            If _Seleccionar Then
                _dv.RowFilter = String.Format("DescripcionTabla Like '%{0}%'", TxtDescripcion.Text)
            Else
                BuscarDatoEnGrilla(TxtDescripcion.Text, "DescripcionTabla", Grilla)
            End If
        End If

        If _Seleccionar Then
            Btn_Grabar.Visible = False
            Grilla.ContextMenuStrip = Nothing
        Else
            Me.ActiveControl = Grilla
            With Grilla
                .Focus()
                If CBool(.RowCount) Then
                    .FirstDisplayedScrollingRowIndex = .RowCount - 1
                    .CurrentCell = .Rows(.RowCount - 1).Cells("DescripcionTabla")
                    .BeginEdit(True)
                End If
            End With
        End If

    End Sub

    Private Sub Frm_Tabla_Caracterizaciones_01_Listado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Sb_Salir()
        End If
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    MenuContextual.Enabled = True
                Else
                    MenuContextual.Enabled = False
                End If
            End With
        End If
    End Sub

    Private Sub EditarDescripciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarDescripciónToolStripMenuItem.Click
        Grilla.BeginEdit(True)
    End Sub

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcion.TextChanged

        If _Seleccionar Then
            _dv.RowFilter = String.Format("DescripcionTabla Like '%{0}%'", TxtDescripcion.Text)
        Else
            BuscarDatoEnGrilla(TxtDescripcion.Text, "DescripcionTabla", Grilla)
        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Sb_Salir()
    End Sub


    Sub Sb_Salir()

        If Not _Seleccionar Then

            Dim _TblFiltroProductos As DataTable = _Ds_Caract.Tables("Tbl_Caracterizaciones")
            Dim _Modificado As Boolean = _Global_Fx_Cambio_en_la_Grilla(_TblFiltroProductos)

            If _Modificado Then

                Dim _Accion = MessageBoxEx.Show(Me, "¿Desea guardar los cambios?", "Salir", _
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If _Accion = Windows.Forms.DialogResult.Yes Then
                    Sb_Grabar()
                ElseIf _Accion = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If
            End If
        End If

        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click
        Sb_Grabar()
    End Sub



    Sub Sb_Grabar()
        'Sb_Grabar()
        'Return
        Dim _TblFiltroProductos As DataTable = _Ds_Caract.Tables("Tbl_Caracterizaciones")
        Dim Contado = 1
        Dim _Nuevas, _Modificadas, _Eliminadas, _SinCambios As Integer
        Dim _Codigo, _Descripcion As String
        Dim _Chk_Color, _Chk_Medida, _Chk_Modelo As Integer

        Consulta_sql = String.Empty


        For Each _Fila As DataRow In _TblFiltroProductos.Rows


            Select Case _Fila.RowState

                Case DataRowState.Added 'Nueva Fila
                    Dim _Grabo As Boolean
                    _Descripcion = _Fila.Item("DescripcionTabla")
                    '_Chk_Color = CInt(_Fila.Item("Chk_Color"))
                    '_Chk_Medida = CInt(_Fila.Item("Chk_Medida"))
                    '_Chk_Modelo = CInt(_Fila.Item("Chk_Modelo"))

                    Dim Nro As Integer = trae_dato(tb, cn1, "MAX(Orden)", _Global_BaseBk & "Zw_TablaDeCaracterizaciones", _
                                                   "Tabla = '" & _CodTablaClass & "'", True) + 1

                    Do

                        _Codigo = numero_(Nro, Fx_Cant_Codigo(_CodTablaClass))

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones " & vbCrLf & _
                                        "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo) Values " & vbCrLf & _
                                        "('" & _CodTablaClass & "'," & _
                                        "'" & _Descripcion & "'," & _
                                        "'" & _Codigo & "'," & _
                                        "'" & _Descripcion & "'," & Nro & ",0,0,0)" & vbCrLf

                        _Grabo = Ej_consulta_IDU(Consulta_sql, cn1, , , False)
                        Nro += 1
                    Loop Until _Grabo
                    _Fila.Item("CodigoTabla") = _Codigo
                    _Nuevas += 1

                Case DataRowState.Modified ' Modificadas

                    _Codigo = _Fila.Item("CodigoTabla")
                    _Descripcion = _Fila.Item("DescripcionTabla")

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Set DescripcionTabla = '" & _Descripcion & _
                                   "',NombreTabla = '" & _Descripcion & "'" & vbCrLf & _
                                   "Where Tabla = '" & _CodTablaClass & "' And CodigoTabla = '" & _Codigo & "'"
                    Ej_consulta_IDU(Consulta_sql, cn1)

                    _Modificadas += 1
                Case DataRowState.Unchanged ' Sin cambios
                    _SinCambios += 1
                Case DataRowState.Detached ' ???
                    _Nuevas += 1
                Case DataRowState.Deleted ' Eliminadas
                    _Eliminadas += 1
            End Select



            Contado += 1
        Next


        If CBool(_Eliminadas) Then

            '_TblFiltroProductos = _Ds_Caract.Tables("Tbl_Caracterizaciones")
            Dim _Filtro_Elimina As String = Generar_Filtro_IN(_TblFiltroProductos, "", "CodigoTabla", False, False, "'")
            Dim _CondiCodigos = "And CodigoTabla Not In " & _Filtro_Elimina

            If _Filtro_Elimina = "()" Then _CondiCodigos = String.Empty

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                           "Where Tabla = '" & _CodTablaClass & "'" & vbCrLf & _CondiCodigos

            Ej_consulta_IDU(Consulta_sql, cn1)

        End If

        Consulta_sql = Fx_SQL_Rd(_CodTablaClass)

        If Not String.IsNullOrEmpty(Trim(Consulta_sql)) Then
            Ej_consulta_IDU(Consulta_sql, cn1)
        End If


        Sb_Actualizar_Grilla("")


        ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button, _
                                         2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


    End Sub


    Function Fx_SQL_Rd(ByVal _CodTablaClass As String)

        Dim _Sql As String

        Select Case _CodTablaClass
            Case "ARTICULO"
                Return ""
            Case "COLOR"
                Return ""
            Case "MEDIDA"
                Return ""
            Case "MODELO"
                Return ""
            Case "MARCAS"
                _Sql = "Truncate table TABMR" & vbCrLf & _
                       "Insert Into TABMR (KOMR,NOKOMR)" & vbCrLf & _
                       "Select DISTINCT SUBSTRING(NombreTabla,1,20),SUBSTRING(NombreTabla,1,30)" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'MARCAS'" & vbCrLf & _
                       "And NombreTabla <> ''"
            Case "RUBROS"
                _Sql = "Truncate table TABRU'" & vbCrLf & _
                       "Insert Into TABRU (KORU,NOKORU) Select CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'RUBROS'"
            Case "CLASLIBRE"
                _Sql = "Delete TABCARAC Where KOTABLA = 'CLALIBPR'" & vbCrLf & _
                       "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select 'CLALIBPR','',CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'CLASLIBRE'"
            Case "ZONAS"
                _Sql = "Truncate table TABZO'" & vbCrLf & _
                       "Insert Into TABRU (KOZO,NOKOZO) Select CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'ZONAS'"
            Case "TIPOENTIDA"
                _Sql = "Delete TABCARAC Where KOTABLA = 'TIPOENTIDA'" & vbCrLf & _
                       "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'TIPOENTIDA'"
            Case "ACTIVIDADE"
                _Sql = "Delete TABCARAC Where KOTABLA = 'ACTIVIDADE'" & vbCrLf & _
                       "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'ACTIVIDADE'"
            Case "TAMA¥OEMPR"
                _Sql = "Delete TABCARAC Where KOTABLA = 'TAMA¥OEMPR'" & vbCrLf & _
                       "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'TAMA¥OEMPR'"
            Case "CARGOS"
                _Sql = "Delete TABCARAC Where KOTABLA = 'CARGOS'" & vbCrLf & _
                       "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select Tabla,'',CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'CARGOS'"
            Case "AREASACTIV"
                _Sql = "Delete TABCARAC Where KOTABLA = 'ACTIVIDADE'" & vbCrLf & _
                       "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) Select 'ACTIVIDADE','',CodigoTabla,NombreTabla" & vbCrLf & _
                       "From Zw_TablaDeCaracterizaciones Where Tabla = 'AREASACTIV'"
            Case Else
                _Sql = ""
        End Select

        Return _Sql

    End Function


    Function Fx_Cant_Codigo(ByVal _CodTablaClass As String)

        Dim CantCarac
        Select Case _CodTablaClass
            Case "ARTICULO"
                CantCarac = 4
            Case "COLOR"
                CantCarac = 4
            Case "MEDIDA"
                CantCarac = 4
            Case "MODELO"
                CantCarac = 4
            Case "MARCAS"
                CantCarac = 4
            Case "RUBROS"
                CantCarac = 3
            Case "CLASLIBRE"
                CantCarac = 4
            Case "TIPOENTIDA"
                CantCarac = 4
            Case "ACTIVIDADE"
                CantCarac = 4
            Case "TAMA¥OEMPR"
                CantCarac = 4
            Case "CARGOS"
                CantCarac = 4
            Case "AREASACTIV"
                CantCarac = 4
        End Select

        Return CantCarac
    End Function

    Private Sub EliminarFilaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
    End Sub

    Private Sub Btn_ExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExportarExcel.Click

        Dim _TblFiltroProductos As DataTable = _Ds_Caract.Tables("Tbl_Caracterizaciones")
        Dim _Modificado As Boolean = _Global_Fx_Cambio_en_la_Grilla(_TblFiltroProductos)

        If _Modificado Then
            MessageBoxEx.Show(Me, "SE EXOPOTARAN A EXCEL SOLO LAS FILAS QUE ESTAN GRABADAS EN LA BASE DE DATOS", _
                              "EXPORTAR A EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Consulta_sql = "SELECT CodigoTabla as 'Codigo',DescripcionTabla as 'Descripcion tabla',NombreTabla as 'Nombre tabla'" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "Where Tabla = '" & _CodTablaClass & "'" & vbCrLf & _
                       "Order by DescripcionTabla"

        ExportarTabla_JetExcel(Consulta_sql, Me, _CodTablaClass)

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        With Grilla
            If _Seleccionar Then
                Dim _Codigo As String = Trim(.Rows(.CurrentRow.Index).Cells("CodigoTabla").Value)

                If Not String.IsNullOrEmpty(_Codigo) Then

                    _FilaSeleccionada(0) = _Codigo
                    _FilaSeleccionada(1) = .Rows(.CurrentRow.Index).Cells("DescripcionTabla").Value
                    _FilaSeleccionada(2) = .Rows(.CurrentRow.Index).Cells("NombreTabla").Value
                    _FilaSeleccionada(3) = .Rows(.CurrentRow.Index).Cells("ApColor").Value
                    _FilaSeleccionada(4) = .Rows(.CurrentRow.Index).Cells("ApModelo").Value
                    _FilaSeleccionada(5) = .Rows(.CurrentRow.Index).Cells("ApMedida").Value
                    _Seleccionada = True
                    Me.Close()
                Else
                    Beep()
                    ToastNotification.Show(Me, "ESTA FILA NO ESTA GRABADA EN LA BASE DE DATOS" & vbCrLf & _
                                           "NO SE PUEDE SELECCIONAR", My.Resources.button_rounded_red_delete, _
                                             3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If
           
            End If

        End With


    End Sub



    Private Sub TxtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDescripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            BuscarDatoEnGrilla(TxtDescripcion.Text, "DescripcionTabla", Grilla)
        End If
    End Sub
End Class