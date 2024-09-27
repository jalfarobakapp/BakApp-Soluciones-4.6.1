Imports DevComponents.DotNetBar

Public Class Frm_MantCostosPrecios_LV

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowProveedor As DataRow
    Dim _Kolt As String
    Dim _Koen As String
    Dim _Suen As String
    Dim _RowListaSeleccionada As DataRow
    Dim _SeleccionarYCerrar As Boolean
    Dim _BuscarOtroProveedor As Boolean
    Dim _SoloSeleccionar As Boolean
    Dim _Id_Padre_Destino As Integer

    Public Property RowListaSeleccionada As DataRow
        Get
            Return _RowListaSeleccionada
        End Get
        Set(value As DataRow)
            _RowListaSeleccionada = value
        End Set
    End Property

    Public Property SeleccionarYCerrar As Boolean
        Get
            Return _SeleccionarYCerrar
        End Get
        Set(value As Boolean)
            _SeleccionarYCerrar = value
        End Set
    End Property

    Public Property BuscarOtroProveedor As Boolean
        Get
            Return _BuscarOtroProveedor
        End Get
        Set(value As Boolean)
            _BuscarOtroProveedor = value
        End Set
    End Property

    Public Property SoloSeleccionar As Boolean
        Get
            Return _SoloSeleccionar
        End Get
        Set(value As Boolean)
            _SoloSeleccionar = value
        End Set
    End Property

    Public Property Id_Padre_Destino As Integer
        Get
            Return _Id_Padre_Destino
        End Get
        Set(value As Integer)
            _Id_Padre_Destino = value
        End Set
    End Property

    Public Sub New(_RowProveedor As DataRow, _Kolt As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._RowProveedor = _RowProveedor
        Me._Kolt = _Kolt

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Color_Botones_Barra(Barrar_Menu)
        _RowListaSeleccionada = Nothing

    End Sub

    Private Sub Frm_MantCostosPrecios_LV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Koen = _RowProveedor.Item("KOEN").ToString.Trim
        _Suen = _RowProveedor.Item("SUEN").ToString.Trim

        Txt_Proveedor.Text = _Koen & "(" & _Suen & ") - " & _RowProveedor.Item("NOKOEN").ToString.Trim

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_ListaPreCosto_Enc",
                                                       "Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "'"))

        If Not _Reg Then Sb_Insertar_Lista_Costos(False)

        '_Reg = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_ListaPreCosto_Enc",
        '                                               "Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "' And EsListaOferta = 1"))

        'If Not _Reg Then Sb_Insertar_Lista_Costos(True)

        Sb_Actualizar_Grilla()

        If Not _SoloSeleccionar Then
            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreCosto_Enc" & vbCrLf &
                       "Where Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "'" & vbCrLf &
                       "Order By FechaVigenciaDesde"

        Dim _Tbl_Listas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Displayindex = 0

        With Grilla

            .DataSource = _Tbl_Listas

            OcultarEncabezadoGrilla(Grilla, False)

            Dim _Campo As String

            _Campo = "Vigente"
            .Columns(_Campo).Width = 50
            .Columns(_Campo).HeaderText = "Vigente"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Lista"
            .Columns(_Campo).Width = 40
            .Columns(_Campo).HeaderText = "Lista RD"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "FechaVigenciaDesde"
            .Columns(_Campo).Width = 90
            .Columns(_Campo).HeaderText = "Vigencia desde"
            .Columns(_Campo).ReadOnly = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "FechaVigenciaHasta"
            .Columns(_Campo).Width = 90
            .Columns(_Campo).HeaderText = "Vigencia hasta"
            .Columns(_Campo).ReadOnly = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "NombreLista"
            .Columns(_Campo).Width = 280
            .Columns(_Campo).HeaderText = "Nombre lista"
            .Columns(_Campo).ReadOnly = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Call Btn_Ver_Lista_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_AgregarLista_Click(sender As Object, e As EventArgs) Handles Btn_AgregarLista.Click

        Dim _Grabar As Boolean

        Dim Fm As New Frm_MantCostosPrecios_CreaLista(_RowProveedor, 0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Ver_Lista_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Lista.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Padre As Integer = _Fila.Cells("Id").Value

        If _SeleccionarYCerrar Then

            If _SoloSeleccionar And CBool(_Id_Padre_Destino) Then
                If _Id_Padre_Destino = _Id_Padre Then
                    MessageBoxEx.Show(Me, "No puede seleccionar esta lista de costos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Where Id = " & _Id_Padre
            _RowListaSeleccionada = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()
            Return
        End If

        Dim _FechaVigenciaDesde As Date = _Fila.Cells("FechaVigenciaDesde").Value
        Dim _FechaVigenciaHasta As Date = _Fila.Cells("FechaVigenciaHasta").Value

        Dim Fm As New Frm_MantCostosPrecios(_RowProveedor, _Kolt)
        Fm.Id_Padre = _Id_Padre
        Fm.Dtp_FechaVigenciaDesde.Value = _FechaVigenciaDesde
        Fm.Dtp_FechaVigenciaHasta.Value = _FechaVigenciaHasta
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Lista As Integer = _Fila.Cells("Id").Value
        Dim _Grabar As Boolean

        Dim Fm As New Frm_MantCostosPrecios_CreaLista(_RowProveedor, _Id_Lista)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _FechaVigencia As Date = _Fila.Cells("FechavigenciaDesde").Value
        Dim _Id_Padre As Integer = _Fila.Cells("Id").Value
        Dim _Lista As String = _Fila.Cells("Lista").Value
        Dim _Vigente As Boolean = _Fila.Cells("Vigente").Value

        If _Vigente Then
            MessageBoxEx.Show(Me, "No puede eliminar una lista de precios vigente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar esta lista de costos de este proveedor?", "Eliminar lista",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Where Id = " & _Id_Padre & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Id_Padre = " & _Id_Padre
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Lista eliminada correctamente", "Eliminar lista", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Frm_MantCostosPrecios_LV_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Vigente As Boolean = _Fila.Cells("Vigente").Value

                    Btn_ListaVigente.Enabled = Not _Vigente

                    ShowContextMenu(Menu_Contextual_Productos)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_ListaVigente_Click(sender As Object, e As EventArgs) Handles Btn_ListaVigente.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _FechaVigencia As Date = _Fila.Cells("FechavigenciaDesde").Value
        Dim _Lista As String = _Fila.Cells("Lista").Value
        Dim _Proveedor As String = _Fila.Cells("Proveedor").Value
        Dim _Sucursal As String = _Fila.Cells("Sucursal").Value

        Dim _FechaVigenciaDesde As DateTime = FormatDateTime(_Fila.Cells("FechaVigenciaDesde").Value, DateFormat.ShortDate)
        Dim _FechaVigenciaHasta As DateTime = FormatDateTime(_Fila.Cells("FechaVigenciaHasta").Value, DateFormat.ShortDate)
        Dim _NombreLista As String = _Fila.Cells("NombreLista").Value

        Dim _FechaDelServidor As DateTime = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

        If _FechaVigenciaDesde > _FechaDelServidor Then
            MessageBoxEx.Show(Me, "No puede dejar esta lista de costos como vigente." & vbCrLf &
                              "La fecha de ""Vigencia Desde"" no puede ser mayor a fecha de hoy" & vbCrLf & vbCrLf &
                              "Fecha V.Desde: " & _FechaVigenciaDesde & " - " & "Fecha Hoy: " & _FechaDelServidor, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _FechaVigenciaHasta < _FechaDelServidor Then
            MessageBoxEx.Show(Me, "No puede dejar esta lista de costos como vigente." & vbCrLf &
                              "La fecha de ""Vigencia Hasta"" ya esta caducada" & vbCrLf & vbCrLf &
                              "Fecha V.Hasta: " & _FechaVigenciaHasta & " - " & "Fecha Hoy: " & _FechaDelServidor, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, "Si cambia la lista los usuarios que en este momento esten" & vbCrLf &
                              "haciendo OCC con este proveedor deberian cerrar el sistema",
                              "Advertencia de recomendación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)

        If MessageBoxEx.Show(Me, "Lista: " & _NombreLista & vbCrLf & vbCrLf &
                             "¿Esta seguro de dejar esta lista como vigente?", "Lista vigente",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Set Vigente = 0" & vbCrLf &
                           "Where Proveedor = '" & _Proveedor & "' And Sucursal = '" & _Sucursal & "' And Lista = '" & _Lista & "'" &
                           vbCrLf &
                           vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Set " &
                           "Vigente = 1,FechaActivacionVigencia = Getdate(),CodFuncionario_Activa = '" & FUNCIONARIO & "'" &
                           vbCrLf &
                           "Where Id = " & _Id
            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                Sb_Actualizar_Grilla()
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Lista Vigente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub Btn_CambiarProveedor_Click(sender As Object, e As EventArgs) Handles Btn_CambiarProveedor.Click
        _BuscarOtroProveedor = True
        Me.Close()
    End Sub

    Sub Sb_Insertar_Lista_Costos(_EsListaOferta As Boolean)

        Dim _Elf As Integer = Convert.ToUInt32(_EsListaOferta)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto " & vbCrLf &
                       "Where Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "' And CostoUd1 = 0 And CostoUd2 = 0 And EsOferta = " & _Elf
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set FechaVigencia = CONVERT(VARCHAR(10), GETDATE(), 103),Id_Padre = 0" & vbCrLf &
                       "Where Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "' And EsOferta = " & _Elf
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Distinct Cast(0 As Bit) As Vigente,Lista,Proveedor,Sucursal,FechaVigencia" & vbCrLf &
           "From " & _Global_BaseBk & "Zw_ListaPreCosto" & vbCrLf &
           "Where Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "' And Id_Padre = 0 And CostoUd1 <> 0" & vbCrLf &
           "Order By FechaVigencia"
        Dim _Tbl_Listas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Listas.Rows

            Dim _Id_Padre As Integer
            Dim _Lista As String = _Fila.Item("Lista")
            Dim _FechaVigenciaDesde As String = Format(_Fila.Item("FechaVigencia"), "yyyyMMdd")
            Dim _FechaVigenciaHasta As String = Format(DateAdd(DateInterval.Month, 1, _Fila.Item("FechaVigencia")), "yyyyMMdd")
            Dim _Nombre_Lista As String

            _Nombre_Lista = Fx_Mes_Palabra(CType(_Fila.Item("FechaVigencia"), Date).Month) & " - " & CType(_Fila.Item("FechaVigencia"), Date).Year

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_ListaPreCosto_Enc (Lista,Proveedor,Sucursal,FechaVigenciaDesde,FechaVigenciaHasta,NombreLista,Vigente,EsListaOferta) Values " &
                           "('" & _Lista & "','" & _Koen & "','" & _Suen & "','" & _FechaVigenciaDesde & "','" & _FechaVigenciaHasta & "','" & _Nombre_Lista.ToUpper & "',1," & _Elf & ")"
            If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Padre) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set Id_Padre = " & _Id_Padre & vbCrLf &
                               "Where Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "' And Lista = '" & _Lista & "' And FechaVigencia = '" & _FechaVigenciaDesde & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set Flete = RECARGO
                                    From " & _Global_BaseBk & "Zw_ListaPreCosto
                                    Inner Join TABRECPR On KOEN = Proveedor And KOPR = Codigo
                                    Where Id_Padre = " & _Id_Padre
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        Next

    End Sub

End Class
