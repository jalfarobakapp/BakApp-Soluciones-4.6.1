Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_ListaMezclas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Mezclas As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_ListaMezclas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Tab_Preparacion.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Fabricadas.Click, AddressOf Sb_Actualizar_Grilla

        Sb_Actualizar_Grilla()

        Btn_NuevaMezcla.Visible = True

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String
        Dim _Tbas = Super_TabS.SelectedTab

        Select Case _Tbas.Name
            Case "Tab_Preparacion"
                _Condicion = "And Estado = 'PROCE'"
            Case "Tab_Fabricadas"
                _Condicion = "And Estado = 'FABRI'"
        End Select

        Dim _Filtro As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtrar.Text), "Nro_MZC+Numot_Otm+Codigo_Otm+Descripcion_Otm Like '%")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc" & vbCrLf &
                       "Where 1>0" & vbCrLf & _Condicion & vbCrLf &
                       "And Nro_MZC+Numot_Otm+Codigo_Otm+Descripcion_Otm Like '%" & _Filtro & "%'"
        _Tbl_Mezclas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Mezclas

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            'Sb_InsertarBotonenGrilla(Grilla, "Btn_Opciones", "Opciones...", "Opciones", 0, _Tipo_Boton.Boton)

            .Columns("Empresa").Width = 30
            .Columns("Empresa").HeaderText = "Emp."
            .Columns("Empresa").Visible = True
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_MZC").Width = 80
            .Columns("Nro_MZC").HeaderText = "Num. MZC"
            .Columns("Nro_MZC").Visible = True
            .Columns("Nro_MZC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaCreacion").Width = 70
            .Columns("FechaCreacion").HeaderText = "F.Emisión"
            .Columns("FechaCreacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Numot_Otm").Width = 80
            .Columns("Numot_Otm").HeaderText = "Num.(OT.M)"
            .Columns("Numot_Otm").Visible = True
            .Columns("Numot_Otm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fiot_Otm").Width = 80
            .Columns("Fiot_Otm").HeaderText = "F.Emis(OT.M)"
            .Columns("Fiot_Otm").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fiot_Otm").Visible = True
            .Columns("Fiot_Otm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo_Otm").Visible = True
            .Columns("Codigo_Otm").HeaderText = "Cód.Madre"
            .Columns("Codigo_Otm").ToolTipText = "Código de producto de OT Madre"
            .Columns("Codigo_Otm").Width = 100
            .Columns("Codigo_Otm").Visible = True
            .Columns("Codigo_Otm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion_Otm").Visible = True
            .Columns("Descripcion_Otm").HeaderText = "Descripción"
            .Columns("Descripcion_Otm").Width = 170
            .Columns("Descripcion_Otm").Visible = True
            .Columns("Descripcion_Otm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Referencia").Visible = True
            .Columns("Referencia").HeaderText = "Saldo SC"
            .Columns("Referencia").Width = 230
            .Columns("Referencia").Visible = True
            .Columns("Referencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantFabricar").Visible = True
            .Columns("CantFabricar").HeaderText = "Fabricar"
            .Columns("CantFabricar").Width = 60
            .Columns("CantFabricar").Visible = True
            .Columns("CantFabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantFabricar").DefaultCellStyle.Format = "###,###.##"
            .Columns("CantFabricar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Btn_Edit").DisplayIndex = True

        End With

        'If MarcarFilasSinSaldo Then

        '    For Each row As DataGridViewRow In Grilla.Rows

        '        Dim _Saldo As Double = row.Cells("SALDO").Value

        '        If _Saldo = 0 Then
        '            row.DefaultCellStyle.ForeColor = Color.Gray
        '        End If

        '    Next

        'End If

    End Sub

    Private Sub Btn_NuevaMezcla_Click(sender As Object, e As EventArgs) Handles Btn_NuevaMezcla.Click

        Dim _Seleccionada As Boolean
        Dim _Idpote_Otm As Integer
        Dim _Numot As String

        Dim Fm As New Frm_BuscarOT
        Fm.FiltroExternoSql = vbCrLf & " And CARGO = 'M'"
        Fm.ShowDialog(Me)
        _Seleccionada = Fm.Seleccionada
        _Numot = Fm.Numot
        _Idpote_Otm = Fm.Idpote
        Fm.Dispose()

        If Not CBool(_Idpote_Otm) Then
            Return
        End If

        Sb_Traer_Producto_De_OT(_Idpote_Otm, _Numot)

    End Sub

    Sub Sb_Traer_Producto_De_OT(_Idpote_Otm As Integer, _Numot As String)

        Consulta_sql = "Select *,(FABRICAR-REALIZADO) As SALDO,0 As SALDO2,Cast((Case When Det.Id Is null Then 0 Else 1 End) As bit) As Marcar" & vbCrLf &
                       "From POTL" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Det On POTL.IDPOTL = Det.Idpotl_Otm" & vbCrLf &
                       "Where IDPOTE = " & _Idpote_Otm & " And LILG <> 'IM'"

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Marcados As Integer

        For Each _Fila As DataRow In _Tbl_Productos.Rows
            If _Fila.Item("Marcar") Then
                _Marcados += 1
            End If
        Next

        If _Marcados >= _Tbl_Productos.Rows.Count Then
            MessageBoxEx.Show(Me, "OT " & _Numot & " completamente ingresada" & vbCrLf & "Todos los productos de esta OT ya ingresado en las ordenes de fabricación",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Btn_NuevaMezcla_Click(Nothing, Nothing)
            Return
        End If

        Dim Fm_Potl As New Frm_GRI_ProductosOT
        Fm_Potl.Tbl_Productos = _Tbl_Productos
        Fm_Potl.ModoSeleccion = True
        Fm_Potl.MarcarFilasSinSaldo = True
        Fm_Potl.ShowDialog(Me)
        Dim _Row_Potl As DataRow = Fm_Potl.FilaSeleccionada
        Fm_Potl.Dispose()

        If IsNothing(_Row_Potl) Then
            Btn_NuevaMezcla_Click(Nothing, Nothing)
            Return
        End If

        Consulta_sql = "Select Enc.* From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Det" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc Enc On Enc.Id = Det.Id_Enc" & vbCrLf &
                       "Where Det.Idpotl_Otm = " & _Row_Potl.Item("IDPOTL")
        Dim _Row_MzDet As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_MzDet) Then
            MessageBoxEx.Show(Me, "Este registro ya esta ingresado en la orden de fabricación " & _Row_MzDet.Item("Nro_MZC"),
                              "Validación registro ya ingresado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Traer_Producto_De_OT(_Idpote_Otm, _Numot)
            Return
        End If

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Agregar_Mezcla(_Idpote_Otm, _Row_Potl.Item("IDPOTL"), _Numot)

        Dim _Icon As MessageBoxIcon

        If _Mensaje.EsCorrecto Then
            _Icon = MessageBoxIcon.Information
        Else
            _Icon = MessageBoxIcon.Error
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Icon)

        Sb_Actualizar_Grilla()


    End Sub

    Function Fx_RowPotl(_Idpote_Otm As Integer) As DataRow

        Dim _Row_Potl As DataRow

        Consulta_sql = "Select *,(FABRICAR-REALIZADO) As SALDO,0 As SALDO2 From POTL" & vbCrLf &
                       "Where IDPOTE = " & _Idpote_Otm & " And LILG <> 'IM'"

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm_Potl As New Frm_GRI_ProductosOT
        Fm_Potl.Tbl_Productos = _Tbl_Productos
        Fm_Potl.ModoSeleccion = True
        Fm_Potl.ShowDialog(Me)
        _Row_Potl = Fm_Potl.FilaSeleccionada
        Fm_Potl.Dispose()

        Return _Row_Potl

    End Function

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id_Enc As Integer = _Fila.Cells("Id").Value
        Dim _Referencia As String = _Fila.Cells("Referencia").Value
        Dim _Nro_MZC As String = _Fila.Cells("Nro_MZC").Value
        Dim _Numot_Otm As String = _Fila.Cells("Numot_Otm").Value

        Dim _RowNomenclatura As DataRow

        Dim _Cl_Mezcla As New Cl_Mezcla
        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzEnc(_Id_Enc)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_SelecProdMezclaFab(_Id_Enc)
        Fm.Text = "Nro: " & _Nro_MZC & " OTM: " & _Numot_Otm & ", " & _Referencia.Trim
        Fm.Cl_Mezcla = _Cl_Mezcla
        Fm.ShowDialog(Me)
        _RowNomenclatura = Fm.RowNomenclatura
        Fm.Dispose()

        'If IsNothing(_RowNomenclatura) Then
        '    Return
        'End If

        Sb_Actualizar_Grilla()

    End Sub

    Function Fx_Agregar_Mezcla(_Idpote As Integer, _Idpotl As Integer, _Numot As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Row_Potl As DataRow
        Dim _Row_Pote As DataRow

        Try

            Consulta_sql = "Select * From POTL Where IDPOTL = " & _Idpotl
            _Row_Potl = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Potl) Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception("No se encontro registro en POTL")
            End If

            Consulta_sql = "Select * From POTE Where IDPOTE = " & _Idpote
            _Row_Pote = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Cl_Mezcla As New Cl_Mezcla

            With _Cl_Mezcla.Zw_Pdp_CPT_MzEnc

                .Empresa = _Row_Potl.Item("EMPRESA")
                .Idpote_Otm = _Row_Potl.Item("IDPOTE")
                .Idpotl_Otm = _Row_Potl.Item("IDPOTL")
                .Numot_Otm = _Row_Pote.Item("NUMOT")
                .Referencia = "CREACION DE MEZCLA PARA PRODUCTO: " & _Row_Potl.Item("GLOSA").ToString.Trim
                .Codigo_Otm = _Row_Potl.Item("CODIGO").ToString.Trim
                .Descripcion_Otm = _Row_Potl.Item("GLOSA").ToString.Trim
                .CantFabricar = _Row_Potl.Item("FABRICAR")
                .Fiot_Otm = _Row_Pote.Item("FIOT")
                .Estado = "PROCE"
                .CodFuncionario = FUNCIONARIO

            End With

            Consulta_sql = "Select * From ZNUEVA_PRODUCCIOND Where IDPOTL = " & _Idpotl

            Consulta_sql = "Select Distinct Znpt.*,NOKOPR,CODNOMEN,DESCRIPTOR,PNPE.CANTIDAD,PNPE.UDAD " & vbCrLf &
                           "From ZNUEVA_PRODUCCIOND Znpd" & vbCrLf &
                           "Inner Join ZNUEVA_PRODUCCIONT Znpt On Znpd.NUMERO = Znpt.NUMERO" & vbCrLf &
                           "Left Join MAEPR On KOPR = Znpt.CODIGO" & vbCrLf &
                           "Inner Join POTD On POTD.IDPOTL = Znpd.IDPOTL And NIVEL = 1 and Znpt.CODIGO = POTD.CODIGO And POTD.CODNOMEN is not null" & vbCrLf &
                           "Inner Join PNPE On PNPE.CODIGO = POTD.CODNOMEN" & vbCrLf &
                           "Where Znpd.IDPOTL = " & _Idpotl

            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Not CBool(_Tbl.Rows.Count) Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception("No se encontro registro en la tabla ZNUEVA_PRODUCCIOND")
            End If

            For Each _Fl_potl As DataRow In _Tbl.Rows

                Dim _Codigomz As String = _Fl_potl.Item("CODIGO") '_Fl_potl.Item("CODIGOMZ")
                Dim _Formulamz As String = _Fl_potl.Item("CODNOMEN") '_Fl_potl.Item("FORMULAMZ")

                'Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigomz & "'"
                'Dim _Row_Maepr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                'Consulta_sql = "Select * From PNPE Where CODIGO = '" & _Formulamz & "'"
                'Dim _Row_Pnpe As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Factor As Double = _Row_Potl.Item("FABRICAR") / _Fl_potl.Item("CANTIDAD") ' _Row_Pnpe.Item("CANTIDAD")
                Dim _Fab As String = De_Num_a_Tx_01(_Factor,, 5)

                Dim _Zw_Pdp_CPT_MzDet As New Zw_Pdp_CPT_MzDet

                With _Zw_Pdp_CPT_MzDet

                    .Empresa = ModEmpresa
                    .SucursalDef = ModSucursal
                    .BodegaDef = ModBodega
                    .FechaCreacion = FechaDelServidor()
                    .Idpote_Otm = _Cl_Mezcla.Zw_Pdp_CPT_MzEnc.Idpote_Otm
                    .Idpotl_Otm = _Cl_Mezcla.Zw_Pdp_CPT_MzEnc.Idpotl_Otm
                    .CodFuncionario = FUNCIONARIO
                    .Codigo = _Fl_potl.Item("CODIGO") '_Row_Maepr.Item("KOPR")
                    .Descripcion = _Fl_potl.Item("NOKOPR").ToString.Trim '_Row_Maepr.Item("NOKOPR").ToString.Trim
                    .Codnomen = _Fl_potl.Item("CODNOMEN") '_Row_Pnpe.Item("CODIGO")
                    .Descriptor = _Fl_potl.Item("DESCRIPTOR").ToString.Trim ''_Row_Pnpe.Item("DESCRIPTOR").ToString.Trim
                    .Cantnomen = _Fl_potl.Item("CANTIDAD") ''_Row_Pnpe.Item("CANTIDAD")
                    .Udad = _Fl_potl.Item("UDAD") '_Row_Pnpe.Item("UDAD")
                    .CantFabricar = _Fl_potl.Item("CANTIDADF") '_Row_Potl.Item("FABRICAR")
                    .CantFabricada = 0

                    _Cl_Mezcla.Ls_Zw_Pdp_CPT_MzDet.Add(_Zw_Pdp_CPT_MzDet)

                End With

            Next

            'Consulta_sql = "Select * From PNPD Where CODIGO = '" & _Formulamz & "'"
            'Dim _Tbl_Pnpd As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            _Mensaje = _Cl_Mezcla.Fx_Crear_Nueva_Mezcla()

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Filtrar_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustomClick
        Txt_Filtrar.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub
End Class
