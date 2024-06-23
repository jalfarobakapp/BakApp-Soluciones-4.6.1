Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Sel_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tido As String
    Dim _Koen As String
    Dim _Suen As String

    Dim _Empresa As String = ModEmpresa
    Dim _Seleccionar As Boolean

    Dim _Endo As String
    Dim _Suendo As String

    Dim _Tbl_Documentos_Seleccionados As DataTable

    Dim _Ds As DataSet
    Private _Dv As New DataView

    Dim _Tbl_Informe As DataTable
    Dim _Cl_Despacho As Clas_Despacho

    Public Property Cl_Despacho As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property

    Public Property Tbl_Informe As DataTable
        Get
            Return _Tbl_Informe
        End Get
        Set(value As DataTable)
            _Tbl_Informe = value
        End Set
    End Property

    Public Property Seleccionar As Boolean
        Get
            Return _Seleccionar
        End Get
        Set(value As Boolean)
            _Seleccionar = value
        End Set
    End Property

    Public Property Tbl_Documentos_Seleccionados As DataTable
        Get
            Return _Tbl_Documentos_Seleccionados
        End Get
        Set(value As DataTable)
            _Tbl_Documentos_Seleccionados = value
            Sb_Generar_Informe_Crear_Dataset()
        End Set
    End Property

    Public Sub New(Endo As String, Suendo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Endo = Endo
        _Suendo = Suendo

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, True)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Sel_Documentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Me.ActiveControl = Txt_Descripcion

    End Sub

    Sub Sb_Generar_Informe_Crear_Dataset()

        Dim _Doc_Seleccionados As String = Generar_Filtro_IN(_Tbl_Documentos_Seleccionados, "", "IDMAEEDO", True, False)

        If _Doc_Seleccionados <> "()" Then
            _Doc_Seleccionados = "Or IDMAEEDO In " & _Doc_Seleccionados
        Else
            _Doc_Seleccionados = String.Empty
        End If

        Dim _Empresa = _Cl_Despacho.Row_Despacho.Item("Empresa")
        Dim _Sucursal = _Cl_Despacho.Row_Despacho.Item("Sucursal")
        Dim _Bodega = _Cl_Despacho.Row_Despacho.Item("Bodega")

        Consulta_sql = "Select Cast(0 As Bit) As Chk,EDO.IDMAEEDO,EDO.EMPRESA,EDO.TIDO,EDO.SUBTIDO,EDO.NUDO,EDO.ENDO,EDO.SUENDO,EDO.SUDO," & vbCrLf &
                       "EDO.FEEMDO,EDO.CAPRCO,EDO.CAPRAD,EDO.MEARDO,EDO.CAPREX,EDO.CAPRNC,EDO.MODO,EDO.TAMODO," & vbCrLf &
                       "EDO.VABRDO,EDO.FEULVEDO,EDO.VAABDO,EDO.VABRDO-EDO.VAABDO As SALDO,EDO.ESFADO,EDO.KOFUAUDO,EDO.KOOPDO,EDO.ENDOFI,EDO.BODESTI," & vbCrLf &
                       "EDO.PROYECTO,EDO.NUMOPERVEN,EDO.POIVARET,EDO.VAIVARET,OB.OBDO,OB.OCDO,EN.RUEN,Cast('' As Varchar(10)) As Nro_Despacho" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "FROM MAEEDO EDO  WITH ( NOLOCK )" & vbCrLf &
                       "LEFT JOIN MAEEDOOB AS OB ON OB.IDMAEEDO=EDO.IDMAEEDO" & vbCrLf &
                       "LEFT JOIN MAEEN AS EN ON EN.KOEN=EDO.ENDO And EN.SUEN=EDO.SUENDO" & vbCrLf &
                       "Where EDO.IDMAEEDO In" & vbCrLf &
                       "(Select Distinct IDMAEEDO From MAEDDO" & vbCrLf &
                       "Where EMPRESA = '" & _Empresa & "'" & vbCrLf &
                       "--And SULIDO = '" & _Sucursal & "'" & vbCrLf &
                       "--And BOSULIDO = '" & _Bodega & "'" & vbCrLf &
                       "And ENDO = '" & _Endo & "' And SUENDO = '" & _Suendo & "'" & vbCrLf &
                       "And TIDO In ('NVV')" & vbCrLf &
                       "--And IDMAEDDO Not In (Select IDRST From MAEDDO Where TIDO In ('FCV','FEV','FEE','FXV','FYV','FVZ','FDV','BLV','BLX','FVT','FDB','FVX','FDX','FVL','FDZ','FVZ','GDP','GDV'))" & vbCrLf &
                       "And ESLIDO <> 'C'" & vbCrLf &
                       "Union" & vbCrLf &
                       "Select Distinct IDMAEEDO From MAEDDO" & vbCrLf &
                       "Where EMPRESA = '" & _Empresa & "'" & vbCrLf &
                       "--And SULIDO = '" & _Sucursal & "'" & vbCrLf &
                       "--And BOSULIDO = '" & _Bodega & "'" & vbCrLf &
                       "And ENDO = '" & _Endo & "' And SUENDO = '" & _Suendo & "'" & vbCrLf &
                       "And TIDO In ('FCV','FEV','FEE','FXV','FYV','FVZ','FDV','BLV','BLX','FVT','FDB','FVX','FDX','FVL','FDZ','FVZ') And CAPRCO1-CAPRNC1 >= 1" & vbCrLf &
                       "Union" & vbCrLf &
                       "Select Distinct IDMAEEDO From MAEDDO" & vbCrLf &
                       "Where EMPRESA = '" & _Empresa & "'" & vbCrLf &
                       "--And SULIDO = '" & _Sucursal & "'" & vbCrLf &
                       "--And BOSULIDO = '" & _Bodega & "'" & vbCrLf &
                       "And ENDO = '" & _Endo & "' And SUENDO = '" & _Suendo & "'" & vbCrLf &
                       "And TIDO In ('GDP','GDV')" & vbCrLf &
                       "And IDRST = 0)" & vbCrLf &
                       "--And EDO.IDMAEEDO Not In " &
                       vbCrLf &
                       "--(Select Idmaeedo From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos Where Estado In ('ING','CON','PRE','DES')) And Id_Despacho <> 1)" & vbCrLf &
                       "--(Select Idmaeedo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det" & Space(1) &
                       "--Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos" & Space(1) &
                       "--Where Estado In ('ING','CON','PRE','DES') And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'))" & vbCrLf &
                       vbCrLf &
                       "Update #Paso Set Nro_Despacho = Isnull((Select Top 1 Nro_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where IDMAEEDO = Idmaeedo),'')" & vbCrLf &
                       vbCrLf &
                       "Update #Paso Set Chk = 1" & vbCrLf &
                       "Where IDMAEEDO In (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = 1 And Archidrst = 'MAEEDO')" & vbCrLf &
                       _Doc_Seleccionados & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Informe = _Ds.Tables(0)
        _Dv.Table = _Ds.Tables("Table")

    End Sub

    Private Sub Sb_Actualizar_Grilla()

        Grilla.DataSource = _Dv

        With Grilla

            Dim _DisplayIndex = 0

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Chk").HeaderText = "SS"
            .Columns("Chk").Width = 20
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").HeaderText = "Suc.Doc."
            .Columns("SUDO").Width = 55
            .Columns("SUDO").Visible = True
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").HeaderText = "Suc.Ent."
            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEULVEDO").HeaderText = "F.Vencim."
            .Columns("FEULVEDO").Width = 80
            .Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("MODO").HeaderText = "Mon"
            '.Columns("MODO").Width = 30
            '.Columns("MODO").Visible = True
            '.Columns("MODO").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("VABRDO").HeaderText = "Monto"
            '.Columns("VABRDO").Width = 80
            '.Columns("VABRDO").Visible = True
            '.Columns("VABRDO").DefaultCellStyle.Format = "###,##0.##"
            '.Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("VABRDO").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("OCDO").HeaderText = "Obs.O.Compra"
            .Columns("OCDO").Width = 330
            .Columns("OCDO").Visible = True
            '.Columns("OCDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("OCDO").DisplayIndex = 11

        End With

        'For Each _Fila As DataGridViewRow In Grilla.Rows

        '    Dim _Suendo = _Fila.Cells("SUENDO").Value

        '    If _Suen <> _Suendo Then

        '        _Fila.DefaultCellStyle.ForeColor = Color.Gray

        '    End If

        'Next

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Tbl_Informe, "Chk", "IDMAEEDO", False, True, "")

        If _Filtro_Idmaeedo <> "()" Then

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO In " & _Filtro_Idmaeedo

            Dim _Empresa = _Cl_Despacho.Row_Despacho.Item("Empresa")
            Dim _Sucursal = _Cl_Despacho.Row_Despacho.Item("Sucursal")
            Dim _Bodega = _Cl_Despacho.Row_Despacho.Item("Bodega")

            Consulta_sql = "Select 'MAEEDO' As Archidrst,Edo.IDMAEEDO As Idrst,Edo.TIDO As Tido,Edo.NUDO As Nudo,
                            Sum(Case UDTRPR When 1 Then CAPRCO1 Else CAPRCO2 End) As CantC,
                            Sum(Case UDTRPR When 1 Then CAPRAD1 Else CAPRAD2 End) As CantD,
                            Sum(Case UDTRPR When 1 Then CAPREX1 Else CAPREX2 End) As CantE,
                            NUDONODEFI As Nudonodefi
                            From MAEDDO Ddo
                            Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                            Where Ddo.IDMAEEDO In " & _Filtro_Idmaeedo & " 
                            --And Ddo.EMPRESA = '" & _Empresa & "' And Ddo.SULIDO = '" & _Sucursal & "' And Ddo.BOSULIDO = '" & _Bodega & "'
                            Group By Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.NUDONODEFI"

            _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        Else
            _Tbl_Informe = Nothing
        End If

        _Seleccionar = True
        Me.Close()

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Buscar_En_Grilla_Dataview()

        Dim _Descripcion_a_buscar = Txt_Descripcion.Text

        _Descripcion_a_buscar = Replace(_Descripcion_a_buscar, vbTab, "")

        Dim _Descripcion As String = Replace(_Descripcion_a_buscar, "'", "")

        If IsNothing(_Descripcion) Then _Descripcion = String.Empty

        Dim _Contiene_Punto_Coma As Boolean = _Descripcion.Contains(";")
        Dim _Lista_Descripciones() As String

        Dim _Lista_productos_A_Buscar As String = String.Empty

        'If _Contiene_Punto_Coma Then

        _Lista_Descripciones = Split(_Descripcion, ";")

        For i = 0 To _Lista_Descripciones.Length - 1
            If i = 0 Then
                _Lista_productos_A_Buscar += "TIDO+NUDO Like '%" & _Lista_Descripciones(i) & "%'"
            Else
                _Lista_productos_A_Buscar += "Or TIDO+NUDO Like '%" & _Lista_Descripciones(i) & "%'"
                '_Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i), " Or ")
            End If
        Next

        _Dv.RowFilter = _Lista_productos_A_Buscar

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Space Then
            Sb_Buscar_En_Grilla_Dataview()
        End If
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        Grilla.EndEdit()
    End Sub


    Private Sub Sb_Grilla_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim keysMod As Keys = Control.ModifierKeys

        If keysMod <> Keys.Control Then

            If Grilla.SelectedRows.Count > 1 Then
                For Each _Fila As DataGridViewRow In Grilla.SelectedRows
                    Dim _Chk As Boolean = _Fila.Cells("Chk").Value
                    If _Chk Then
                        _Fila.Cells("Chk").Value = False
                    Else
                        _Fila.Cells("Chk").Value = True
                    End If
                Next
            End If

        End If

        Grilla.EndEdit()

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim Hitest As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)

            If Hitest.Type = DataGridViewHitTestType.Cell Then
                sender.CurrentCell = sender.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                ShowContextMenu(Menu_Contextual_01)
            End If

        End If

    End Sub

    Sub Sb_Marcar_Una_Fila(_Tido_M As String, _Nudo_M As String)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Tido = _Fila.Cells("TIDO").Value
            Dim _Nudo = _Fila.Cells("NUDO").Value

            If _Tido = _Tido_M And _Nudo = _Nudo_M Then
                _Fila.Cells("Chk").Value = True
            End If

        Next

    End Sub

    Sub Sb_Marcar_Una_Fila(_Idmaeedo_M As Integer)

        For Each _Fila As DataRow In _Tbl_Informe.Rows

            Dim _Idmaeedo = _Fila.Item("IDMAEEDO")

            If _Idmaeedo = _Idmaeedo_M Then
                _Fila.Item("Chk") = True
            End If

        Next

    End Sub

    Private Sub Frm_Sel_Documentos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Dim _Fl As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Tido = _Fl.Cells("TIDO").Value
        Dim _Nudo = _Fl.Cells("NUDO").Value
        Dim _Nro_Despacho = _Fl.Cells("Nro_Despacho").Value

        If Not String.IsNullOrEmpty(_Nro_Despacho) Then ' And  _Fl.Cells("Chk").Value Then

            MessageBoxEx.Show(Me, "Este documento " & _Tido & "-" & _Nudo & " ya tiene una orden de despacho asociada" & vbCrLf &
                              "Orden de despacho: " & _Nro_Despacho, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Fl.Cells("Chk").Value = False

            e.Cancel = True

        End If

    End Sub

End Class
