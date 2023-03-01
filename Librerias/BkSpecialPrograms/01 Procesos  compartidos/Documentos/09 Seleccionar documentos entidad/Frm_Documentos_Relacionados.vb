Imports DevComponents.DotNetBar

Public Class Frm_Documentos_Relacionados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tido As String
    Dim _Subtido As String
    Dim _Koen As String
    Dim _Suen As String

    Dim _Empresa As String = ModEmpresa
    Dim _Seleccionar As Boolean
    Dim _Idmaeedo As Integer

    Dim _Ds As DataSet
    Private _Dv As New DataView

    Dim _Tbl_Informe As DataTable

    Public Property Pro_Tbl_Informe As DataTable
        Get
            Return _Tbl_Informe
        End Get
        Set(value As DataTable)
            _Tbl_Informe = value
        End Set
    End Property

    Public Property Pro_Seleccionar As Boolean
        Get
            Return _Seleccionar
        End Get
        Set(value As Boolean)
            _Seleccionar = value
        End Set
    End Property

    Public Property Idmaeedo As Integer
        Get
            Return _Idmaeedo
        End Get
        Set(value As Integer)
            _Idmaeedo = value
        End Set
    End Property

    Public Sub New(_Tido As String,
                   _Koen As String,
                   _Suen As String,
                   _Subtido As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tido = _Tido
        Me._Subtido = _Subtido
        Me._Koen = _Koen
        Me._Suen = _Suen

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, True)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Documentos_Relacionados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Me.ActiveControl = Txt_Descripcion
        Sb_Actualizar_Grilla("")

        AddHandler Chk_Solo_Doc_Sucursal.CheckedChanged, AddressOf Sb_Chk_Solo_Doc_Sucursal_CheckedChanged

    End Sub

    Sub Sb_Generar_Informe_Crear_Dataset()

        Consulta_sql = "Select Cast(0 As Bit) As Chk,EDO.IDMAEEDO,EDO.EMPRESA,EDO.TIDO,EDO.SUBTIDO,EDO.NUDO,EDO.ENDO,EDO.SUENDO,EDO.SUDO,
                        EDO.FEEMDO,EDO.CAPRCO,EDO.CAPRAD,EDO.MEARDO,EDO.CAPREX,EDO.CAPRNC,EDO.MODO,EDO.TAMODO,
                        EDO.VABRDO,EDO.FEULVEDO,EDO.VAABDO,EDO.VABRDO-EDO.VAABDO As SALDO,EDO.ESFADO,EDO.KOFUAUDO,EDO.KOOPDO,EDO.ENDOFI,EDO.BODESTI,
                        EDO.PROYECTO,EDO.NUMOPERVEN,EDO.POIVARET,EDO.VAIVARET,OB.OBDO,OB.OCDO,EN.RUEN
                        Into #Paso
                        From MAEEDO EDO With ( Nolock )
                        Left Join MAEEDOOB As OB On OB.IDMAEEDO=EDO.IDMAEEDO
                        Left Join MAEEN AS EN On EN.KOEN=EDO.ENDO And EN.SUEN=EDO.SUENDO
                        Where 1 > 0" & vbCrLf &
                       Fx_Condicion_Informe() & vbCrLf &
                       "
                        Delete #Paso Where IDMAEEDO Not In (Select IDMAEEDO From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso) And ESLIDO = '' And CAPRCO1-(CAPRAD1+CAPREX1) > 0) And TIDO = 'NVV'
                        --Select ESLIDO,CAPRCO1,CAPRAD1,CAPREX1,CAPRCO1-(CAPRAD1+CAPREX1) As Saldo,* From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso) And ESLIDO = '' And CAPRCO1-(CAPRAD1+CAPREX1) > 0
                        
                        Update #Paso Set VAABDO = Isnull((Select Sum(VABRLI) As FCV_NVV From MAEDDO Where IDRST In (Select IDMAEDDO From MAEDDO Where IDMAEEDO = #Paso.IDMAEEDO)),0)
                        Where TIDO = 'NVV'
                        Update #Paso Set SALDO = ROUND(VABRDO - VAABDO,2)
                        Where TIDO = 'NVV'

                        Select * From #Paso

                        Drop Table #Paso"

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Informe = _Ds.Tables(0)
        _Dv.Table = _Ds.Tables("Table")

    End Sub

    Private Sub Sb_Actualizar_Grilla(ByVal Sql_Query As String)

        Grilla.DataSource = _Dv

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Chk").HeaderText = "SS"
            .Columns("Chk").Width = 20
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = 0

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 2

            .Columns("SUDO").HeaderText = "Suc.Doc."
            .Columns("SUDO").Width = 55
            .Columns("SUDO").Visible = True
            .Columns("SUDO").DisplayIndex = 3

            .Columns("SUENDO").HeaderText = "Suc.Ent."
            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = 4

            .Columns("BODESTI").HeaderText = "Bod.Des."
            .Columns("BODESTI").Width = 55
            .Columns("BODESTI").Visible = True
            .Columns("BODESTI").DisplayIndex = 5

            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = 6

            .Columns("FEULVEDO").HeaderText = "F.Vencim."
            .Columns("FEULVEDO").Width = 80
            .Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").DisplayIndex = 7

            .Columns("MODO").HeaderText = "Mon"
            .Columns("MODO").Width = 30
            .Columns("MODO").Visible = True
            .Columns("MODO").DisplayIndex = 8

            .Columns("VABRDO").HeaderText = "Monto"
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DisplayIndex = 9

            .Columns("SALDO").HeaderText = "Saldo aprox."
            .Columns("SALDO").Width = 80
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").DisplayIndex = 10

            .Columns("OCDO").HeaderText = "Obs.O.Compra"
            .Columns("OCDO").Width = 80
            .Columns("OCDO").Visible = True
            .Columns("OCDO").DisplayIndex = 11

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Suendo As String = _Fila.Cells("SUENDO").Value

            If _Suen.Trim <> _Suendo.Trim Then

                _Fila.DefaultCellStyle.ForeColor = Color.Gray

            End If

        Next

    End Sub

    Private Function Fx_Condicion_Informe() As String

        Dim _Suendo As String = String.Empty
        Dim _SqlWhere As String

        If Chk_Solo_Doc_Sucursal.Checked Or _Tido = "GTI" Then
            _Suendo = " AND EDO.SUENDO = '" & _Suen & "'"
        End If

        Dim _Condicion_Idmaeedo = String.Empty

        If Convert.ToBoolean(_Idmaeedo) Then
            _Condicion_Idmaeedo = "And EDO.IDMAEEDO = " & _Idmaeedo & vbCrLf
        End If

        Select Case _Tido

            Case "NCV"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND (( EDO.TIDO IN ('FCV','FDV','BLV','BLX','FVT','FDB','FVX','FDX','FVL','FVZ','FDZ','FCT')" & vbCrLf &
                            "AND EDO.CAPRAD+EDO.CAPREX<>0 " & vbCrLf &
                            "AND EDO.CAPRCO-EDO.CAPRNC<>0 )  " & vbCrLf &
                            "OR (EDO.ESDO='' AND EDO.TIDO='GRD' AND EDO.SUBTIDO <> 'PRE' AND EDO.SUBTIDO <> 'CON'))" & vbCrLf &
                            "AND NUDONODEFI=0 " & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO,EDO.NUDO DESC"

            Case "GRD"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND ( ( EDO.TIDO IN ('FCV','BLV','BLX','FEV','FEE','FXV','FYV','FVZ','FVT','FDB','FVX','FDX','FVL','FVZ','FDZ')" & vbCrLf &
                            "AND EDO.CAPRAD+EDO.CAPREX<>0 AND EDO.CAPRCO-EDO.CAPRNC<>0 )  OR ( EDO.ESDO=' ' AND EDO.TIDO IN ('NCV','NCB','NCX','NEV','NCZ') ) )" & vbCrLf &
                            "AND NUDONODEFI=0 " & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO,EDO.NUDO DESC"

            Case "FCV", "BLV"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND EDO.ESDO=''" & vbCrLf &
                            "AND EDO.TIDO IN ('NVV','GDP','GDV') AND NUDONODEFI=0" & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO,EDO.NUDO"

            Case "NVV"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND EDO.ESDO=''" & vbCrLf &
                            "AND EDO.TIDO IN ('COV') AND NUDONODEFI=0" & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO,EDO.NUDO"

            Case "GDV"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND EDO.ESDO=''" & vbCrLf &
                            "AND EDO.TIDO IN ('NVV','FCV','FEV','FEE','FXV','FYV','FVZ','FDV','BLV','BLX','COV','FVT','FDB','FVX','FDX','FVL','FDZ','FVZ') AND NUDONODEFI=0" & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO,EDO.NUDO"

            Case "GRC"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND EDO.ESDO=''" & vbCrLf &
                            "And EDO.TIDO In ('OCC','FCC','FDC','BLC','FCT')  AND NUDONODEFI=0" & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO DESC "

            Case "GTI"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND EDO.ESDO=''" & vbCrLf &
                            "And EDO.TIDO = 'NVI' AND NUDONODEFI=0" & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO DESC "

            Case "GRI"

                _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                            "AND EDO.ENDO='" & _Koen & "'" & _Suendo & vbCrLf &
                            "AND EDO.ESDO=''" & vbCrLf &
                            "And EDO.TIDO In ('GDI','OCI','GTI') AND NUDONODEFI=0" & vbCrLf &
                            _Condicion_Idmaeedo &
                            "ORDER BY EDO.FEEMDO DESC "

            Case "GDD"

                If String.IsNullOrEmpty(_Subtido) Then

                    _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                                "AND EDO.ENDO='" & _Koen & "'" & vbCrLf &
                                "AND (( EDO.TIDO IN ('FCC','FDC','BLC','FCT')" & vbCrLf &
                                "AND EDO.CAPRAD+EDO.CAPREX<>0" & vbCrLf &
                                "AND EDO.CAPRCO-EDO.CAPRNC<>0) OR (EDO.ESDO=' ' AND EDO.TIDO = 'NCC' ))" & vbCrLf &
                                "AND NUDONODEFI=0" & vbCrLf &
                                _Condicion_Idmaeedo &
                                "ORDER BY EDO.FEEMDO DESC "

                End If

                If _Subtido = "PRE" Then

                    _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                                "AND EDO.ENDO='" & _Koen & "'" & vbCrLf &
                                "AND EDO.ESDO=''" & vbCrLf &
                                "AND EDO.TIDO = 'GRP'" & vbCrLf &
                                "AND EDO.SUBTIDO = 'PRE'" & vbCrLf &
                                "AND NUDONODEFI=0" & vbCrLf &
                                _Condicion_Idmaeedo &
                                "ORDER BY EDO.FEEMDO DESC "

                End If

                If _Subtido = "CON" Then

                    _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                                "AND EDO.ENDO='" & _Koen & "'" & vbCrLf &
                                "AND EDO.ESDO=''" & vbCrLf &
                                "AND EDO.TIDO = 'GRP'" & vbCrLf &
                                "AND EDO.SUBTIDO = 'CON'" & vbCrLf &
                                "AND NUDONODEFI=0" & vbCrLf &
                                _Condicion_Idmaeedo &
                                "ORDER BY EDO.FEEMDO DESC "

                End If

            Case "GDP"

                If _Subtido = "PRE" Then

                    _SqlWhere = "AND EDO.EMPRESA='" & _Empresa & "'" & vbCrLf &
                                "AND EDO.ENDO='" & _Koen & "'" & vbCrLf &
                                "AND EDO.ESDO='' AND EDO.TIDO IN ('NVV','COV')" & vbCrLf &
                                "AND NUDONODEFI=0" & vbCrLf &
                                _Condicion_Idmaeedo &
                                "ORDER BY EDO.FEEMDO DESC "
                End If

                If _Subtido = "CON" Then

                    _SqlWhere = "AND EDO.ENDO='" & _Koen & "'" & vbCrLf &
                                "AND EDO.TIDO IN ('BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FVZ','RIN','ESC','FEE','NCC','NCB')" & vbCrLf &
                                "AND EDO.ESPGDO = 'P'" & vbCrLf &
                                "AND EDO.NUDONODEFI = 0" & vbCrLf &
                                "AND EDO.EMPRESA = '" & _Empresa & "'" & vbCrLf &
                                "ORDER BY EDO.TIDO,EDO.NUDO "

                End If

            Case Else

                _SqlWhere = "And 1 < 0"

        End Select

        Return _SqlWhere

    End Function

    Private Sub Btn_Seleccionar_Marcadas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccionar_Marcadas.Click
        For Each _Fila As DataGridViewRow In Grilla.SelectedRows
            _Fila.Cells("Chk").Value = True
        Next
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim _Filtros As String = Generar_Filtro_IN(_Tbl_Informe, "Chk", "IDMAEEDO", True, True, "")

        _Seleccionar = True
        Me.Close()

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

    Private Sub Sb_Buscar_En_Grilla_Dataview()

        Dim _Descripcion_a_buscar = Txt_Descripcion.Text

        _Descripcion_a_buscar = Replace(_Descripcion_a_buscar, vbTab, "")

        Dim _Descripcion As String = Replace(_Descripcion_a_buscar, "'", "")

        If IsNothing(_Descripcion) Then _Descripcion = String.Empty

        Dim _Contiene_Punto_Coma As Boolean = _Descripcion.Contains(";")
        Dim _Lista_Descripciones() As String

        Dim _Lista_productos_A_Buscar As String = String.Empty

        _Lista_Descripciones = Split(_Descripcion, ";")

        For i = 0 To _Lista_Descripciones.Length - 1
            If i = 0 Then
                _Lista_productos_A_Buscar += "TIDO+NUDO Like '%" & _Lista_Descripciones(i) & "%'"
            Else
                _Lista_productos_A_Buscar += "Or TIDO+NUDO Like '%" & _Lista_Descripciones(i) & "%'"
            End If
        Next

        _Dv.RowFilter = _Lista_productos_A_Buscar

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Suendo As String = _Fila.Cells("SUENDO").Value

            If _Suen.Trim <> _Suendo.Trim Then

                _Fila.DefaultCellStyle.ForeColor = Color.Gray

            End If

        Next

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Space Then
            Sb_Buscar_En_Grilla_Dataview()
        End If
    End Sub

    Private Sub Frm_Documentos_Relacionados_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txt_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Txt_Descripcion.TextChanged
        If String.IsNullOrEmpty(Trim(Txt_Descripcion.Text)) Then
            Sb_Buscar_En_Grilla_Dataview()
        End If
    End Sub

    Private Sub Grilla_Detalle_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

        For Each _Fila As DataRow In _Tbl_Informe.Rows ' DataGridViewRow In Grilla.Rows

            Dim _Idmaeedo = _Fila.Item("IDMAEEDO") '_Fila.Cells("IDMAEEDO").Value

            If _Idmaeedo = _Idmaeedo_M Then
                '_Fila.Cells("Chk").Value = True
                _Fila.Item("Chk") = True
            End If

        Next

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

        Sb_Actualizar_Grilla("")

        If Not Convert.ToBoolean(_Tbl_Informe.Rows.Count) Then
            Me.Close()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Sb_Chk_Solo_Doc_Sucursal_CheckedChanged(sender As Object, e As EventArgs)

        Sb_Actualizar_Grilla("")

    End Sub

    Private Sub Grilla_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grilla.MouseDoubleClick

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            If Not Fx_NvvHabilitada(_Fila) Then
                _Fila.Cells("Chk").Value = False
            Else
                _Fila.Cells("Chk").Value = Not _Fila.Cells("Chk").Value
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        If Not Fx_NvvHabilitada(_Fila) Then
            e.Cancel = True
        End If

    End Sub

    Function Fx_NvvHabilitada(_Fila As DataGridViewRow) As Boolean

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Tido = _Fila.Cells("TIDO").Value

        If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") And _Tido = "NVV" Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Docu_Ent Where Idmaeedo = " & _Idmaeedo
            Dim _Row_Docu_Ent As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _HabilitadaFac = False

            If Not IsNothing(_Row_Docu_Ent) Then
                _HabilitadaFac = _Row_Docu_Ent.Item("HabilitadaFac")
            End If

            If Not _HabilitadaFac Then
                MessageBoxEx.Show(Me, "Esta nota de venta no esta habilitada para ser facturada." & vbCrLf &
                                      "Según la configuración General las notas de venta deben ser habilitadas para que se puedan facturar",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        End If

        Return True

    End Function

End Class
