Imports DevComponents.DotNetBar

Public Class Frm_Kardex_Procesar_Estudio_X_Producto

    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String
    Dim _Codigo As String
    Dim _Unidad As Integer
    Dim _Cancelar As Boolean

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public Sub New(Empresa As String,
                    Sucursal As String,
                    Bodega As String,
                    Codigo As String,
                    Unidad As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Empresa = Empresa
        _Sucursal = Sucursal
        _Bodega = Bodega
        _Codigo = Codigo
        _Unidad = Unidad

        RdbBodega_act.Text = "Bodega actual (" & Trim(_Sucursal) & " - " & Trim(_Bodega) & ")"

        Progreso_Kardex.Text = "..."

        RdbBodega_todas.Enabled = True

        Sb_Color_Botones_Barra(Bar2)

    End Sub


#Region "Procedimientos"

    Function Fx_Generar_Kardex(_Empresa As String,
                                _Sucursal As String,
                                _Bodega As String,
                                _Codigo As String,
                                _Unidad As Integer,
                                _Todas_las_bodegas As Boolean) As DataTable

        Dim _Top, _Orden As String

        If Rdb_Pri10.Checked Then
            _Top = "Top 10"
            _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI,MAEEDO.HORAGRAB,MAEDDO.SEMILLA--,MAEDDO.IDMAEEDO"
        ElseIf Rdb_Pri100.Checked Then
            _Top = "Top 100"
            _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI,MAEEDO.HORAGRAB,MAEDDO.SEMILLA--,MAEDDO.IDMAEEDO"
        ElseIf Rdb_Ult10.Checked Then
            _Top = "Top 10"
            _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI Desc,MAEEDO.HORAGRAB,MAEDDO.SEMILLA--,MAEDDO.IDMAEEDO"
        ElseIf Rdb_Ult100.Checked Then
            _Top = "Top 100"
            _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI Desc,MAEEDO.HORAGRAB,MAEDDO.SEMILLA--,MAEDDO.IDMAEEDO"
        ElseIf RdbTodos.Checked Then
            _Top = String.Empty
            _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI,MAEEDO.HORAGRAB,MAEDDO.SEMILLA--,MAEDDO.IDMAEEDO"
        ElseIf RdbUltNmov.Checked Then
            _Top = "Top " & De_Txt_a_Num_01(TxtNmov.Text, 0)
            _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI Desc,MAEEDO.HORAGRAB,MAEDDO.SEMILLA--,MAEDDO.IDMAEEDO"
        End If


        Consulta_sql = My.Resources._24_Recursos.Kardex_de_inventario
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)

        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Top#", _Top)
        Consulta_sql = Replace(Consulta_sql, "#Orden#", _Orden)

        If _Todas_las_bodegas Then
            Consulta_sql = Replace(Consulta_sql, "AND MAEDDO.SULIDO=@Sucursal", "")
            Consulta_sql = Replace(Consulta_sql, "AND MAEDDO.BOSULIDO=@Bodega", "")
        Else
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        End If

        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Unidad)

        Dim _TblKardex As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _TblKardex

    End Function

#End Region

    Private Sub BtnProcesar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Procesar.Click

        Grupo_01.Enabled = False
        Grupo_02.Enabled = False
        Btn_Procesar.Enabled = False

        Dim _TblKardex As DataTable = Fx_Generar_Kardex(_Empresa, _Sucursal, _Bodega, _Codigo, _Unidad, RdbBodega_todas.Checked)

        If Not (_TblKardex Is Nothing) Then

            If CBool(_TblKardex.Rows.Count) Then

                Dim _Marcar_dos As Boolean

                If Rdb_Ult10.Checked Or
                   Rdb_Ult100.Checked Or
                   RdbUltNmov.Checked Then
                    _Marcar_dos = True
                End If

                Dim Fm As New Frm_Kardex_Informe_X_Producto(_Codigo, _Unidad, _Marcar_dos, RdbBodega_todas.Checked)
                Fm.Pro_Empresa = _Empresa
                Fm.Pro_Sucursal = _Sucursal
                Fm.Pro_Bodega = _Bodega
                'Fm.Sb_Llenar_Grilla(_TblKardex)

                Fm.Pro_TblKardex = _TblKardex
                Fm.GrillaKardex.DataSource = Fm.Pro_TblKardex
                Fm.Sb_Formato_Grilla_Detalle()

                Btn_Cancelar.Enabled = True

                Dim _Mostrar_Kardex As Boolean = Fx_Marcar_Grilla(Fm.Pro_Grilla, _Marcar_dos)

                Grupo_01.Enabled = True
                Grupo_02.Enabled = True
                Btn_Procesar.Enabled = True
                Btn_Cancelar.Enabled = False

                Fm.Pro_TblKardex = _TblKardex

                If _Mostrar_Kardex Then Fm.ShowDialog(Me)
                Fm.Dispose()

                Progreso_Kardex.Text = "..."
                Progreso_Porc.Value = 0
                Progreso_Cont.Value = 0
                Progreso_Kardex.Value = 0

            Else
                MessageBoxEx.Show(Me, "No existen datos que mostrar", "Kardex",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Function Fx_Marcar_Grilla(Grilla As DataGridView, _Marcar_dos As Boolean) As Boolean

        Dim _Pasada As Integer = 1

        Progreso_Porc.Value = 0
        Progreso_Cont.Value = 0
        Progreso_Kardex.Value = 0

        Dim _FlechaDerecha As Char = ">" 'ChrW(&H2192)


        Try

            With Grilla

                Progreso_Kardex.Maximum = 100
                Progreso_Porc.Maximum = 100
                Progreso_Cont.Maximum = .Rows.Count

                Dim STFISICO,
                    DEVENGADO,
                    DESPSFACTURAR,
                    COMPROMETIDO,
                    COMPRANREC,
                    RECEPSFAC,
                    PEDIDO,
                    TRANSITO As Double

                Dim STFISICO_,
                    DEVENGADO_,
                    DESPSFACTURAR_,
                    COMPROMETIDO_,
                    COMPRANREC_,
                    RECEPSFAC_,
                    PEDIDO_,
                    TRANSITO_ As Double


                Dim i = 0

                For Each row As DataGridViewRow In .Rows

                    i = row.Index

                    System.Windows.Forms.Application.DoEvents()

                    STFISICO = row.Cells("STFISICO").Value
                    STFISICO_ = STFISICO_ + STFISICO

                    DEVENGADO = row.Cells("DEVENGADO").Value
                    DEVENGADO_ = DEVENGADO_ + DEVENGADO

                    DESPSFACTURAR = row.Cells("DESPSFACTURAR").Value
                    DESPSFACTURAR_ = DESPSFACTURAR_ + DESPSFACTURAR

                    COMPROMETIDO = row.Cells("COMPROMETIDO").Value
                    COMPROMETIDO_ = COMPROMETIDO_ + COMPROMETIDO

                    COMPRANREC = row.Cells("COMPRANREC").Value
                    COMPRANREC_ = COMPRANREC_ + COMPRANREC

                    RECEPSFAC = row.Cells("RECEPSFAC").Value
                    RECEPSFAC_ = RECEPSFAC_ + RECEPSFAC

                    PEDIDO = row.Cells("PEDIDO").Value
                    PEDIDO_ = PEDIDO_ + PEDIDO

                    TRANSITO = row.Cells("TRANSITO").Value
                    TRANSITO_ = TRANSITO_ + TRANSITO

                    Dim SUBTIDO As String = row.Cells("SUBTIDO").Value

                    If _Pasada = 1 Then

                        If SUBTIDO = "AJU" Then
                            .Rows.Item(i).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                        If CBool(STFISICO) Then
                            '.Rows.Item(i).Cells("Sfisico").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Sfisico").Style.ForeColor = Rojo
                            .Rows.Item(i).Cells("Sfisico").Value = _FlechaDerecha
                        End If

                        If CBool(DEVENGADO) Then
                            '.Rows.Item(i).Cells("Sdevengado").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Sdevengado").Style.ForeColor = Color.Red
                            .Rows.Item(i).Cells("Sdevengado").Value = _FlechaDerecha
                        End If

                        If CBool(DESPSFACTURAR) Then
                            '.Rows.Item(i).Cells("Sdespsfact").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Sdespsfact").Style.ForeColor = Color.Red
                            .Rows.Item(i).Cells("Sdespsfact").Value = _FlechaDerecha
                        End If

                        If CBool(COMPROMETIDO) Then
                            '.Rows.Item(i).Cells("Scomprometido").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Scomprometido").Style.ForeColor = Color.Red
                            .Rows.Item(i).Cells("Scomprometido").Value = _FlechaDerecha
                        End If

                        If CBool(COMPRANREC) Then
                            '.Rows.Item(i).Cells("Scompranorecep").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Scompranorecep").Style.ForeColor = Color.Red
                            .Rows.Item(i).Cells("Scompranorecep").Value = _FlechaDerecha
                        End If

                        If CBool(RECEPSFAC) Then
                            '.Rows.Item(i).Cells("Srecesfact").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Srecesfact").Style.ForeColor = Color.Red
                            .Rows.Item(i).Cells("Srecesfact").Value = _FlechaDerecha
                        End If

                        If CBool(PEDIDO) Then
                            '.Rows.Item(i).Cells("Spedido").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Spedido").Style.ForeColor = Color.Red
                            .Rows.Item(i).Cells("Spedido").Value = _FlechaDerecha
                        End If

                        If CBool(TRANSITO) Then
                            '.Rows.Item(i).Cells("Spedido").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            '.Rows.Item(i).Cells("Spedido").Style.ForeColor = Color.Red
                            .Rows.Item(i).Cells("Stransito").Value = _FlechaDerecha
                        End If

                    End If

                    If Not _Marcar_dos Then

                        .Rows.Item(i).Cells("STFISICO").Value = STFISICO_
                        .Rows.Item(i).Cells("DEVENGADO").Value = DEVENGADO_
                        .Rows.Item(i).Cells("DESPSFACTURAR").Value = DESPSFACTURAR_
                        .Rows.Item(i).Cells("COMPROMETIDO").Value = COMPROMETIDO_
                        .Rows.Item(i).Cells("COMPRANREC").Value = COMPRANREC_
                        .Rows.Item(i).Cells("RECEPSFAC").Value = RECEPSFAC_
                        .Rows.Item(i).Cells("PEDIDO").Value = PEDIDO_
                        .Rows.Item(i).Cells("TRANSITO").Value = TRANSITO_
                        .Rows.Item(i).Cells("Orden").Value = i

                    End If

                    System.Windows.Forms.Application.DoEvents()
                    'Contador += 1
                    Progreso_Porc.Value = ((Progreso_Cont.Value * 100) / .Rows.Count) 'Mas
                    Progreso_Kardex.Value = Progreso_Porc.Value
                    Progreso_Cont.Value += 1
                    Progreso_Kardex.Text = FormatNumber(Progreso_Cont.Value, 0) & " de " & FormatNumber(.Rows.Count, 0)

                    If _Cancelar Then
                        Return False
                    End If

                Next

                If _Marcar_dos Then

                    Consulta_sql = "Select * From MAEST" & vbCrLf &
                                   "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal &
                                   "'  And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'"
                    Dim _TblMaest As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    'MST.STFI#Ud#,        -- STOCK FISICO
                    'MST.STDV#Ud#,        -- STOCK DEVENGADO
                    'MST.DESPNOFAC#Ud#,   -- DESPACHADO SIN FACTURAR 
                    'MST.STOCNV#Ud#,      -- STOCK COMPROMETIDO
                    'MST.STDV#Ud#C,       -- COMPRAS NO RECEPCIONADAS
                    'MST.RECENOFAC#Ud#,   -- RECEPCIONADO SIN FACTURAR
                    'MST.STOCNV#Ud#C,     -- STOCK PEDIDO

                    If CBool(_TblMaest.Rows.Count) Then

                        STFISICO = _TblMaest.Rows(0).Item("STFI" & _Unidad) + -STFISICO_
                        DEVENGADO = _TblMaest.Rows(0).Item("STDV" & _Unidad) + -DEVENGADO_
                        DESPSFACTURAR = _TblMaest.Rows(0).Item("DESPNOFAC" & _Unidad) + -DESPSFACTURAR_
                        COMPROMETIDO = _TblMaest.Rows(0).Item("STOCNV" & _Unidad) + -COMPROMETIDO_
                        COMPRANREC = _TblMaest.Rows(0).Item("STDV" & _Unidad) + -COMPRANREC_
                        RECEPSFAC = _TblMaest.Rows(0).Item("RECENOFAC" & _Unidad) + -RECEPSFAC_
                        PEDIDO = _TblMaest.Rows(0).Item("STOCNV" & _Unidad & "C") + -PEDIDO_
                        TRANSITO = _TblMaest.Rows(0).Item("STTR" & _Unidad) + -TRANSITO_

                        .Rows.Item(0).Cells("STFISICO").Value = STFISICO
                        .Rows.Item(0).Cells("DEVENGADO").Value = DEVENGADO
                        .Rows.Item(0).Cells("DESPSFACTURAR").Value = DESPSFACTURAR
                        .Rows.Item(0).Cells("COMPROMETIDO").Value = COMPROMETIDO
                        .Rows.Item(0).Cells("COMPRANREC").Value = COMPRANREC
                        .Rows.Item(0).Cells("RECEPSFAC").Value = RECEPSFAC
                        .Rows.Item(0).Cells("PEDIDO").Value = PEDIDO
                        .Rows.Item(0).Cells("TRANSITO").Value = TRANSITO

                    End If

                    _Marcar_dos = False
                    _Pasada += 1
                    If Not Fx_Marcar_Grilla(Grilla, _Marcar_dos) Then
                        Return False
                    End If

                End If

            End With

            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0
            Progreso_Kardex.Value = 0


            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Function

    Private Sub RdbUltNmov_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdbUltNmov.CheckedChanged
        If RdbUltNmov.Checked Then
            TxtNmov.Enabled = True
            TxtNmov.Focus()
        Else
            TxtNmov.Enabled = False
        End If
    End Sub

    Private Sub PressEnter(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, True))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        Return
        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send("")
        ElseIf e.KeyChar = "-"c Then
            e.Handled = True
            SendKeys.Send("")
        End If
    End Sub

    Private Sub Frm_DocumentoKardex_flujo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler TxtNmov.KeyPress, AddressOf PressEnter
    End Sub

    Private Sub Frm_DocumentoKardex_flujo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
