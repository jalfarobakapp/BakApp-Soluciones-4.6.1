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

        Sb_Actualizar_Grilla()

        Btn_NuevaMezcla.Visible = True

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Empresa, Idpote_Otm, Idpotl_Otm, Numot_Otm, Fiot_Otm, Codigo_Otm, Descripcion_Otm, FechaCreacion, Referencia, CodFuncionario, FechaCreacionOT, Idpote, Estado

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc" & vbCrLf &
                       "Where Estado = 'PROCE'"
        _Tbl_Mezclas = _Sql.Fx_Get_Tablas(Consulta_sql)

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

            .Columns("Fiot_Otm").Width = 70
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
            .Columns("Referencia").Width = 170
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
        Fm.FiltroExternoSql = vbCrLf & "And IDPOTE Not In (Select Idpote_Otm From " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc Where Estado <> 'NULA')"
        Fm.ShowDialog(Me)
        _Seleccionada = Fm.Seleccionada
        _Numot = Fm.Numot
        _Idpote_Otm = Fm.Idpote
        Fm.Dispose()

        If _Seleccionada Then

            Dim _Row_Pote As DataRow
            Dim _Row_Potl As DataRow

            Consulta_sql = "Select *,(FABRICAR-REALIZADO) As SALDO,0 As SALDO2 From POTL" & vbCrLf &
                           "Where IDPOTE = " & _Idpote_Otm & " And LILG <> 'IM'"

            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim Fm_Potl As New Frm_GRI_ProductosOT
            Fm_Potl.Tbl_Productos = _Tbl_Productos
            Fm_Potl.ModoSeleccion = True
            Fm_Potl.ShowDialog(Me)
            _Row_Potl = Fm_Potl.FilaSeleccionada
            Fm_Potl.Dispose()

            If IsNothing(_Row_Potl) Then
                Call Btn_NuevaMezcla_Click(Nothing, Nothing)
                Return
            End If

            Dim _RowNomenclatura As DataRow

            Dim FmNom As New Frm_Select_Nomenclatura(_Row_Potl.Item("CODIGO").ToString.Trim)
            FmNom.ShowDialog(Me)
            _RowNomenclatura = FmNom.RowNomenclatura
            FmNom.Dispose()

            If IsNothing(_RowNomenclatura) Then
                MessageBoxEx.Show(Me, "Debe seleccionar una nomeclatura para poder crear la Orden de fabricación", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql = "Select * From POTE Where IDPOTE = " & _Idpote_Otm
            _Row_Pote = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Cl_Mezcla As New Cl_Mezcla
            Dim _Mensaje As New LsValiciones.Mensajes

            With _Cl_Mezcla.MzEnc

                .Empresa = ModEmpresa
                .Idpote_Otm = _Row_Potl.Item("IDPOTE")
                .Idpotl_Otm = _Row_Potl.Item("IDPOTL")
                .Numot_Otm = _Row_Pote.Item("NUMOT")
                .Referencia = "CREACION DE MEZCLA PARA PRODUCTO: " & _Row_Potl.Item("GLOSA").ToString.Trim '_Row_Pote.Item("REFERENCIA").ToString.Trim
                .Codigo_Otm = _Row_Potl.Item("CODIGO").ToString.Trim
                .Descripcion_Otm = _Row_Potl.Item("GLOSA").ToString.Trim
                .Fiot_Otm = _Row_Pote.Item("FIOT")
                .Estado = "PROCE"
                .Codnomen = _RowNomenclatura.Item("CODIGO")
                .Descriptor = _RowNomenclatura.Item("DESCRIPTOR")
                .Udad = _RowNomenclatura.Item("UDAD")
                .Cantnomen = _RowNomenclatura.Item("CANTIDAD")
                .CantFabricar = _Row_Potl.Item("FABRICAR")

            End With

            'Consulta_sql = "Select PNPD.*,MAEPR.NOKOPR,MAEPR.UD01PR,MAEPR.UD02PR,MAEPR.TIPR,MAEPR.DIVISIBLE,MAEPR.LOMIFA," &
            '               "MAEPR.LOMAFA,MAEPR.MUDEFA,MAEPR.KOPRDIM,MAEPR.NODIM1,MAEPR.NODIM2,PCOMODI.COMODIN AS XXCOMODIN" & vbCrLf &
            '               "From PNPD" & vbCrLf &
            '               "Left Join MAEPR On PNPD.ELEMENTO=MAEPR.KOPR" & vbCrLf &
            '               "Left Join PCOMODI On PNPD.ELEMENTO=PCOMODI.KOCOMO" & vbCrLf &
            '               "Where PNPD.CODIGO=@Codnomen And PNPD.ELEMENTO In (Select CODIGO From PRELA) "
            'Dim _TblMzDet As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            'Dim _Id = 0

            'For Each _Fila As DataRow In _TblMzDet.Rows

            '    Dim _MzDet As New Modelos_Mezcla.MzDet

            '    With _MzDet

            '        .Id = _Id
            '        .Empresa = ModEmpresa
            '        .SucursalDef = ModSucursal
            '        .BodegaDef = ModBodega
            '        .Idpote_Otm = _Cl_Mezcla.MzEnc.Idpote_Otm
            '        .Idpotl_Otm = _Cl_Mezcla.MzEnc.Idpotl_Otm
            '        .

            '        _Cl_Mezcla.MzDet_ls.Add(_MzDet)

            '    End With

            '    _Id += 1

            'Next

            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese alguna Referencia para esta orden de fabricación", "Orden de fabricación",
                                                      _Cl_Mezcla.MzEnc.Referencia, False, _Tipo_Mayus_Minus.Mayusculas, 50, True, _Tipo_Imagen.Storage)

            If Not _Aceptar Then
                Return
            End If

            _Mensaje = _Cl_Mezcla.Fx_Crear_Nueva_Mezcla()

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If



                MessageBoxEx.Show(Me, _Mensaje.Detalle, "Crear Orden de fabricación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id_Enc As Integer = _Fila.Cells("Id").Value
        Dim _Codnomen As String = _Fila.Cells("Codnomen").Value
        Dim _Cantfabricar As Double = _Fila.Cells("Cantfabricar").Value

        Dim _RowNomenclatura As DataRow

        Dim _Cl_Mezcla As New Cl_Mezcla
        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Llenar_MzEnc(_Id_Enc)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_SelecProdMezclaFab()
        Fm.Cl_Mezcla = _Cl_Mezcla
        Fm.ShowDialog(Me)
        _RowNomenclatura = Fm.RowNomenclatura
        Fm.Dispose()

        If IsNothing(_RowNomenclatura) Then
            Return
        End If

    End Sub

End Class
