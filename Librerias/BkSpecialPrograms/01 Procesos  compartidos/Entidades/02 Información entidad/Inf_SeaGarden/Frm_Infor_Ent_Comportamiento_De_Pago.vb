'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Infor_Ent_Comportamiento_De_Pago

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowEntidad As DataRow

    Private _Dv_Documentos As New DataView
    Private _Dv_Detalle As New DataView

    Public Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(ByVal value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Documento, 15, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 15, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            TxtDescripcion.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Infor_Ent_Comportamiento_De_Pago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Sb_Actualiar_Grilla()
        AddHandler TxtDescripcion.KeyDown, AddressOf TxtDescripcion_KeyDown
        AddHandler Super_Tab.SelectedTabChanged, AddressOf Sb_Super_Tab_SelectedTabChanged
        Me.Refresh()

    End Sub

    Sub Sb_Actualiar_Grilla()

        Dim _Mostrar_NCV = String.Empty

        If Not Chk_Mostrar_NCV.Checked Then _Mostrar_NCV = "And TIPO_DOC <> 'NCV'"

        Dim _Koen = Trim(_RowEntidad.Item("KOEN"))

        Lbl_Rut.Text = "R.U.T.: " & _RowEntidad.Item("Rut")
        Lbl_Razon.Text = "RAZON SOCIAL: " & _RowEntidad.Item("NOKOEN")

        Consulta_sql = My.Resources.Recursos_Inf.SQLQuery_Informe_de_comportamiento_de_pagos
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidad#", "And ENDO = '" & _Koen & "'")
        Consulta_sql = Replace(Consulta_sql, "#Filtro_2#", _Mostrar_NCV)

        '_Tbl_Informe = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv_Documentos.Table = _Ds.Tables(0)
        _Dv_Detalle.Table = _Ds.Tables(1)

        With Grilla_Documento

            .DataSource = _Dv_Documentos

            OcultarEncabezadoGrilla(Grilla_Documento, True)

            .Columns("TIPO_DOC").HeaderText = "TD"
            .Columns("TIPO_DOC").Width = 30
            .Columns("TIPO_DOC").Visible = True

            .Columns("NO_DOC").HeaderText = "Número"
            .Columns("NO_DOC").Width = 65
            .Columns("NO_DOC").Visible = True

            .Columns("ESTADO_PAGO").HeaderText = "Est."
            .Columns("ESTADO_PAGO").Width = 30
            .Columns("ESTADO_PAGO").Visible = True
            .Columns("ESTADO_PAGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("VALOR_DOCTO").HeaderText = "Valor Doc."
            .Columns("VALOR_DOCTO").Width = 80
            .Columns("VALOR_DOCTO").Visible = True
            .Columns("VALOR_DOCTO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VALOR_DOCTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("EMISION").HeaderText = "Fecha Emisión"
            .Columns("EMISION").Width = 80
            .Columns("EMISION").Visible = True

            .Columns("FECHA_VCMTO").HeaderText = "Fecha Vencimiento"
            .Columns("FECHA_VCMTO").Width = 80
            .Columns("FECHA_VCMTO").Visible = True

            .Columns("DIAS_VCTO").HeaderText = "Días Vcto"
            .Columns("DIAS_VCTO").Width = 35
            .Columns("DIAS_VCTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DIAS_VCTO").Visible = True

            .Columns("FECHA_ULT_PAGO").HeaderText = "Fecha Venc. Pago"
            .Columns("FECHA_ULT_PAGO").Width = 80
            .Columns("FECHA_ULT_PAGO").Visible = True

            .Columns("MAX_DIAS_REAL_PAGO").HeaderText = "Días Pago"
            .Columns("MAX_DIAS_REAL_PAGO").Width = 35
            .Columns("MAX_DIAS_REAL_PAGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MAX_DIAS_REAL_PAGO").DefaultCellStyle.Format = "###,##"
            .Columns("MAX_DIAS_REAL_PAGO").Visible = True


        End With


        With Grilla_Detalle

            .DataSource = _Dv_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            .Columns("TIPO_DOC").HeaderText = "TD"
            .Columns("TIPO_DOC").Width = 30
            .Columns("TIPO_DOC").Visible = True

            .Columns("NO_DOC").HeaderText = "Número"
            .Columns("NO_DOC").Width = 65
            .Columns("NO_DOC").Visible = True

            .Columns("ESTADO_PAGO").HeaderText = "Est."
            .Columns("ESTADO_PAGO").Width = 30
            .Columns("ESTADO_PAGO").Visible = True
            .Columns("ESTADO_PAGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("EMISION").HeaderText = "Fecha Emision"
            .Columns("EMISION").Width = 60
            .Columns("EMISION").Visible = True

            .Columns("FECHA_VCMTO").HeaderText = "Fecha Vencimiento"
            .Columns("FECHA_VCMTO").Width = 60
            .Columns("FECHA_VCMTO").Visible = True

            .Columns("DIAS_VCTO").HeaderText = "Días Vcto"
            .Columns("DIAS_VCTO").Width = 35
            .Columns("DIAS_VCTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DIAS_VCTO").Visible = True

            .Columns("VALOR_DOCTO").HeaderText = "Valor Doc."
            .Columns("VALOR_DOCTO").Width = 80
            .Columns("VALOR_DOCTO").Visible = True
            .Columns("VALOR_DOCTO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VALOR_DOCTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("ABONOS").HeaderText = "Abono"
            .Columns("ABONOS").Width = 80
            .Columns("ABONOS").Visible = True
            .Columns("ABONOS").DefaultCellStyle.Format = "$ ###,##"
            .Columns("ABONOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("SALDO_DOCTO").HeaderText = "Saldo Doc."
            .Columns("SALDO_DOCTO").Width = 80
            .Columns("SALDO_DOCTO").Visible = True
            .Columns("SALDO_DOCTO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("SALDO_DOCTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("TDP").HeaderText = "TDP"
            .Columns("TDP").Width = 30
            .Columns("TDP").Visible = True

            .Columns("NUCUDP").HeaderText = "Nro."
            .Columns("NUCUDP").Width = 60
            .Columns("NUCUDP").Visible = True

            .Columns("MONTO_DP").HeaderText = "Monto TDP"
            .Columns("MONTO_DP").Width = 80
            .Columns("MONTO_DP").Visible = True
            .Columns("MONTO_DP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("MONTO_DP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("FEC_VCMTO").HeaderText = "Fecha Venc. Pago"
            .Columns("FEC_VCMTO").Width = 80
            .Columns("FEC_VCMTO").Visible = True

            .Columns("DIAS_PAGO").HeaderText = "Días Pago"
            .Columns("DIAS_PAGO").Width = 35
            .Columns("DIAS_PAGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DIAS_PAGO").DefaultCellStyle.Format = "###,##"
            .Columns("DIAS_PAGO").Visible = True

            .Columns("DIAS_REAL_PAGO").HeaderText = "Días Real"
            .Columns("DIAS_REAL_PAGO").Width = 35
            .Columns("DIAS_REAL_PAGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DIAS_REAL_PAGO").DefaultCellStyle.Format = "###,##"
            .Columns("DIAS_REAL_PAGO").Visible = True

        End With

        'TIPO_DOC,NO_DOC,EMISION,FECHA_VCMTO,DIAS_VCTO,MAX_DIAS_REAL_PAGO,FECHA_ULT_PAGO 
        Call Sb_Super_Tab_SelectedTabChanged(Nothing, Nothing)
        'Sb_Marcar_Grillas()

    End Sub

    Private Sub Btn_Buscar_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Entidad.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)

        Fm.BtnCrearUser.Visible = False
        Fm.BtnEditarUser.Visible = False
        Fm.BtnEliminarUser.Visible = False
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then
            _RowEntidad = Fm.Pro_RowEntidad
            Sb_Actualiar_Grilla()
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Actualizar_Datos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Datos.Click
        Sb_Actualiar_Grilla()
    End Sub

    Private Sub Frm_Infor_Ent_Comportamiento_De_Pago_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Dim _Key As Keys = e.KeyValue

        Select Case _Key
            Case Keys.F5
                Sb_Actualiar_Grilla()
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick

        Dim _Idmaeedo = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Sub Sb_Marcar_Grillas()

        Dim _Index As Integer = Super_Tab.SelectedTabIndex
        'Dim _Informe As String

        Dim _Rojo, _Azul, _Verde As Color

        If Global_Thema = Enum_Themas.Oscuro Then

            _Rojo = Color.FromArgb(220, 78, 66)
            _Azul = Color.FromArgb(37, 136, 213)
            _Verde = Color.FromArgb(30, 215, 96)

        Else

            _Rojo = Color.Red
            _Azul = Color.Blue
            _Verde = Color.Green

        End If



        Select Case _Index
            Case 0
                With Grilla_Detalle
                    For Each _Fila As DataGridViewRow In .Rows

                        Dim _Tipo_Doc = _Fila.Cells("TIPO_DOC").Value

                        Dim _Dias_Vcto As Double = NuloPorNro(_Fila.Cells("DIAS_VCTO").Value, 0)
                        Dim _Dias_Real_Pago As Double = NuloPorNro(_Fila.Cells("DIAS_REAL_PAGO").Value, 0)

                        Dim _Diferencia As Double = _Dias_Real_Pago - _Dias_Vcto

                        Select Case _Diferencia
                            Case Is = 0
                                _Fila.Cells("DIAS_REAL_PAGO").Style.ForeColor = _Verde
                            Case Is > 0
                                _Fila.Cells("DIAS_REAL_PAGO").Style.ForeColor = _Rojo
                            Case Is < 0
                                _Fila.Cells("DIAS_REAL_PAGO").Style.ForeColor = _Verde
                        End Select

                        If _Tipo_Doc = "NCV" Then
                            _Fila.DefaultCellStyle.BackColor = Color.Yellow
                            'Else
                            '    _Fila.Cells("DIAS_REAL_PAGO").Style.ForeColor = Color.Green
                        End If

                    Next
                End With
            Case 1
                With Grilla_Documento
                    For Each _Fila As DataGridViewRow In .Rows

                        Dim _Tipo_Doc = _Fila.Cells("TIPO_DOC").Value

                        Dim _Dias_Vcto As Double = NuloPorNro(_Fila.Cells("DIAS_VCTO").Value, 0)
                        Dim _Max_Dias_Real_Pago As Double = NuloPorNro(_Fila.Cells("MAX_DIAS_REAL_PAGO").Value, 0)

                        Dim _Diferencia As Double = _Max_Dias_Real_Pago - _Dias_Vcto

                        Select Case _Diferencia
                            Case Is = 0
                                _Fila.Cells("MAX_DIAS_REAL_PAGO").Style.ForeColor = _Verde
                            Case Is > 0
                                _Fila.Cells("MAX_DIAS_REAL_PAGO").Style.ForeColor = _Rojo
                            Case Is < 0
                                _Fila.Cells("MAX_DIAS_REAL_PAGO").Style.ForeColor = _Verde
                        End Select

                        If _Tipo_Doc = "NCV" Then
                            _Fila.DefaultCellStyle.BackColor = Color.Yellow
                            'Else
                            '    _Fila.Cells("DIAS_REAL_PAGO").Style.ForeColor = Color.Green
                        End If

                    Next
                End With
        End Select


    End Sub

    Private Sub TxtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = Keys.Enter Then
            Dim _Descripcion As String = Trim(TxtDescripcion.Text)
            _Dv_Documentos.RowFilter = String.Format("NO_DOC Like '%{0}%'", _Descripcion)
            _Dv_Detalle.RowFilter = String.Format("NO_DOC Like '%{0}%'", _Descripcion)
            Sb_Marcar_Grillas()
        ElseIf e.KeyValue = Keys.Delete Then
            _Dv_Documentos.RowFilter = String.Format("NO_DOC Like '%{0}%'", "")
            _Dv_Detalle.RowFilter = String.Format("NO_DOC Like '%{0}%'", "")
            TxtDescripcion.Text = String.Empty
            Sb_Marcar_Grillas()
        End If

    End Sub

    Private Sub Grilla_Documento_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Documento.CellDoubleClick
        Dim _Idmaeedo = Grilla_Documento.Rows(Grilla_Documento.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click

        Dim _Index As Integer = Super_Tab.SelectedTabIndex
        Dim _Tbl As DataTable
        Dim _Informe As String

        Select Case _Index
            Case 0
                _Tbl = _Dv_Documentos.Table
                _Informe = "Comport_Doc_total"
            Case 1
                _Tbl = _Dv_Detalle.Table
                _Informe = "Comport_Doc_Detalle"
        End Select

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, _Informe)


    End Sub

    Private Sub Sb_Super_Tab_SelectedTabChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs)
        Sb_Marcar_Grillas()
    End Sub
End Class
