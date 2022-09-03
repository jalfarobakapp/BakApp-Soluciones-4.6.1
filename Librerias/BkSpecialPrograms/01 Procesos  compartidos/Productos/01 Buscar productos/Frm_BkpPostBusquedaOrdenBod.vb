Imports DevComponents.DotNetBar

Public Class Frm_BkpPostBusquedaOrdenBod

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Bodegas As DataTable
    Dim _Grabar As Boolean
    Dim _Orden_Bod As String
    Dim _RowIndex As Integer

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Orden_Bod = "ORDEN_BOD_" & ModEmpresa.Trim & ModSucursal.Trim

        Consulta_sql = "Select * From TABBO Where EMPRESA = '" & ModEmpresa & "'"
        _Tbl_Bodegas = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Bodegas.Rows

            Dim _Empresa As String = _Fila.Item("EMPRESA")
            Dim _Kosu As String = _Fila.Item("KOSU")
            Dim _Kobo As String = _Fila.Item("KOBO")
            Dim _Nokobo As String = _Fila.Item("NOKOBO")

            Dim _Tabla = _Orden_Bod
            Dim _CodigoTabla As String = _Empresa.Trim & _Kosu.Trim & _Kobo.Trim

            Dim _Cuenta As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                               "Tabla = '" & _Tabla & "' And CodigoTabla = '" & _CodigoTabla.Trim & "'"))

            If Not _Cuenta Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla) 
                                Values ('" & _Tabla & "','Orden para mostrar productos en buscador de productos','" & _CodigoTabla & "','" & _Nokobo & "')"
                _Sql.Ej_consulta_IDU(Consulta_sql, False)

            End If

        Next

        Sb_Formato_Generico_Grilla(Grilla_Bodegas, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Btn_Dehacer_los_cambios.Enabled = True

    End Sub

    Private Sub Frm_BkpPostBusquedaOrdenBod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Bodegas.RowPostPaint, AddressOf Sb_Grilla_RowsPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select DISTINCT Cast(0 As int) As Orden,Ltrim(Rtrim(EMPRESA))+Ltrim(Rtrim(KOSU))+Ltrim(Rtrim(KOBO)) As Bodega,* 
                        Into #Paso
                        From TABBO
                        Where EMPRESA = '" & ModEmpresa & "'
   
                        Update #Paso Set Orden = Isnull((Select Orden From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
						                        		 Where Tabla = '" & _Orden_Bod & "' And CodigoTabla = Bodega),0)

                        Select * From #Paso Order by Orden
                        Drop Table #Paso"

        _Tbl_Bodegas = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Bodegas

            .DataSource = _Tbl_Bodegas

            OcultarEncabezadoGrilla(Grilla_Bodegas)

            .Columns("EMPRESA").Visible = True
            .Columns("EMPRESA").HeaderText = "Emp."
            .Columns("EMPRESA").Width = 40
            .Columns("EMPRESA").DisplayIndex = 0

            .Columns("KOSU").Visible = True
            .Columns("KOSU").HeaderText = "Suc."
            .Columns("KOSU").Width = 40
            .Columns("KOSU").DisplayIndex = 1

            .Columns("KOBO").Visible = True
            .Columns("KOBO").HeaderText = "Bod."
            .Columns("KOBO").Width = 40
            .Columns("KOBO").DisplayIndex = 2

            .Columns("NOKOBO").Visible = True
            .Columns("NOKOBO").HeaderText = "Bodega"
            .Columns("NOKOBO").Width = 300
            .Columns("NOKOBO").DisplayIndex = 3

        End With

    End Sub

    Private Sub Btn_Subir_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Subir_Producto.Click

        Try

            'obtener el índice de la fila seleccionada
            _RowIndex = Grilla_Bodegas.SelectedCells(0).OwningRow.Index

            'crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Arriba As DataRow

            Dim _Subir As Boolean
            Dim _Contador As Integer = 1

            If _RowIndex > 0 Then

                Dim _Fila_de_Arriba As DataGridViewRow

                For _i = _RowIndex - 1 To 0 Step -1

                    _Fila_de_Arriba = Grilla_Bodegas.Rows(_i)

                    _Fila_Arriba = Fx_Clonar_Fila(_i)
                    _Subir = True
                    Exit For
                    _Contador += 1

                Next

                If _Subir Then

                    'eliminar la fila seleccionada
                    Grilla_Bodegas.ClearSelection()
                    Grilla_Bodegas.Rows(0).Selected = True
                    Grilla_Bodegas.CurrentCell = Grilla_Bodegas.Rows(0).Cells("KOBO")

                    _Tbl_Bodegas.Rows.RemoveAt(_RowIndex)
                    _Tbl_Bodegas.Rows.InsertAt(_Fila_Actual, _RowIndex - _Contador)

                    'inserte la nueva fila en una nueva posición
                    _Tbl_Bodegas.Rows.RemoveAt(_Fila_de_Arriba.Index)
                    _Tbl_Bodegas.Rows.InsertAt(_Fila_Arriba, _RowIndex)

                    Dim _Orden_Index = _Fila_Actual.Item("Orden")
                    Sb_Marcar_Fila_Seleccionada(_Orden_Index)

                Else
                    Beep()
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Function Fx_Clonar_Fila(_RowIndex As Integer) As DataRow
        Dim row As DataRow
        row = _Tbl_Bodegas.NewRow()

        'agregar datos a la fila

        For i = 0 To Grilla_Bodegas.ColumnCount - 1
            row(i) = Grilla_Bodegas.Rows(_RowIndex).Cells(i).Value
        Next
        Return row
    End Function

    Private Sub Btn_Bajar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Bajar_Producto.Click

        Try

            'obtener el índice de la fila seleccionada
            _RowIndex = Grilla_Bodegas.SelectedCells(0).OwningRow.Index

            'crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Abajo As DataRow

            Dim _Bajar As Boolean
            Dim _Contador As Integer = 1

            Dim _RowIndex_Abajo As Integer


            If _RowIndex >= 0 Then

                Dim _Fila_de_Abajo As DataGridViewRow

                For _i = _RowIndex + 1 To Grilla_Bodegas.RowCount - 1

                    _Fila_de_Abajo = Grilla_Bodegas.Rows(_i)

                    'Dim _Movible = _Fila_de_Abajo.Cells("Movible").Value

                    'If _Movible Then
                    _Fila_Abajo = Fx_Clonar_Fila(_i)
                    _RowIndex_Abajo = _i
                    _Bajar = True
                    Exit For
                    'End If

                    _Contador -= 1

                Next

                If _Bajar Then

                    'eliminar la fila seleccionada

                    _Tbl_Bodegas.Rows.RemoveAt(_RowIndex)
                    _Tbl_Bodegas.Rows.InsertAt(_Fila_Actual, _RowIndex_Abajo) ' _RowIndex + _Contador)

                    'inserte la nueva fila en una nueva posición
                    _Tbl_Bodegas.Rows.RemoveAt(_Fila_de_Abajo.Index)
                    _Tbl_Bodegas.Rows.InsertAt(_Fila_Abajo, _RowIndex)

                    Dim _Orden = _Fila_Actual.Item("Orden")
                    Sb_Marcar_Fila_Seleccionada(_Orden)

                Else
                    Beep()
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Sub Sb_Marcar_Fila_Seleccionada(_Orden_Index As Integer)

        For Each _Fila As DataGridViewRow In Grilla_Bodegas.Rows

            Dim _Orden_1 = _Fila.Cells("Orden").Value

            If _Orden_1 = _Orden_Index Then

                _Fila.Selected = True
                Grilla_Bodegas.CurrentCell = Grilla_Bodegas.Rows(_Fila.Index).Cells("KOBO")
                Grilla_Bodegas.Focus()
                Btn_Dehacer_los_cambios.Enabled = True
                Exit For

            End If

        Next

    End Sub

    Private Sub Btn_Dehacer_los_cambios_Click(sender As Object, e As EventArgs) Handles Btn_Dehacer_los_cambios.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If MessageBoxEx.Show(Me, "¿Desea guardar los cambios?", "Guardar cambios",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim _Orden = 0
            Dim Consulta_sql = String.Empty

            For Each _Fila As DataGridViewRow In Grilla_Bodegas.Rows

                Dim _Empresa As String = _Fila.Cells("EMPRESA").Value
                Dim _Kosu As String = _Fila.Cells("KOSU").Value
                Dim _Kobo As String = _Fila.Cells("KOBO").Value
                Dim _Nokobo As String = _Fila.Cells("NOKOBO").Value

                Dim _Tabla = _Orden_Bod
                Dim _CodigoTabla As String = _Empresa.Trim & _Kosu.Trim & _Kobo.Trim

                Consulta_sql += "Update " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Set Orden = " & _Orden & " 
                                 Where Tabla = '" & _Tabla & "' And CodigoTabla = '" & _CodigoTabla & "'" & vbCrLf & vbCrLf
                _Orden += 1

            Next

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
                Me.Close()
            End If

        End If

    End Sub

    Sub Sb_Grilla_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < Grilla_Bodegas.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If Grilla_Bodegas.RowHeadersWidth < CInt(size.Width + 20) Then
                Grilla_Bodegas.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class