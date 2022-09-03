'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Documentos_Pagados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblEncabezado, _TblDetalle, _TblEntidades As DataTable
    Dim _Idmaedpce As Integer

    Public Sub New(Idmaedpce As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Encabezado, 19, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 15, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, True, False, False)

        _Idmaedpce = Idmaedpce

    End Sub

    Private Sub Frm_Pagos_Documentos_Pagados_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        InsertarBotonenGrilla(Grilla_Encabezado, "BtnImagen", "-", "Imagen", 0, _Tipo_Boton.Imagen)

        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Detalle.DoubleClick, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla(_Idmaedpce)

        Dim _Tidp As String = _TblEncabezado.Rows(0).Item("TIDP")

        Select Case _Tidp.ToString
            Case "TJV", "TJC", "CHV", "CHC", "LTV", "LTC", "PAV", "PAC", "DEP", "ATB", "PTB"
                Btn_Editar_Encabezado.Visible = True
                Select Case _Tidp.ToString
                    Case "TJV", "CHV", "CHC", "LTV", "PAC", "DEP", "ATB"
                        Btn_Cambiar_Nro_Cta_Cte.Visible = True

                        If _Tidp.ToString = "CHC" Then

                            Btn_Imprimir_Comprobante.Visible = True
                            Btn_Imprimir_Vista_Previa.Visible = True

                            AddHandler Btn_Mnu_Imprimir_Documento.Click, AddressOf Sb_Imprimir_Cheque
                            AddHandler Btn_Mnu_Vista_Previa.Click, AddressOf Sb_Vista_Previa_Cheque

                            Btn_Imprimir_Vista_Previa.Image = Lista_Imagenes_32.Images.Item("check-print.png")
                            Btn_Mnu_Imprimir_Documento.Image = Lista_Imagenes_32.Images.Item("check-print.png")

                        ElseIf _Tidp.ToString = "TJV" Then

                            Btn_Imprimir_Vista_Previa.Visible = True

                            AddHandler Btn_Mnu_Imprimir_Documento.Click, AddressOf Sb_Imprimir_Voucher
                            AddHandler Btn_Mnu_Vista_Previa.Click, AddressOf Sb_Vista_Previa_Voucher

                            Btn_Imprimir_Vista_Previa.Image = Lista_Imagenes_32.Images.Item("credit_card_front-print.png")
                            Btn_Mnu_Imprimir_Documento.Image = Lista_Imagenes_32.Images.Item("credit_card_front-print.png")

                        End If

                    Case Else
                        Btn_Cambiar_Nro_Cta_Cte.Visible = False
                End Select
            Case Else
                Btn_Editar_Encabezado.Visible = False
        End Select

    End Sub

    Sub Sb_Actualizar_Grilla(_Idmaedpce As Integer)

        Consulta_sql = My.Resources.Recursos_pagos.SQLQuery_Ver_Info_Documentos_Pagados
        Consulta_sql = Replace(Consulta_sql, "#Idmaedpce#", _Idmaedpce)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _TblEncabezado = _Ds.Tables(0)
        _TblDetalle = _Ds.Tables(1)
        _TblEntidades = _Ds.Tables(2)

        Dim _Tidp As String = _TblEncabezado.Rows(0).Item("TIDP")
        Dim _Nombre As String
        Dim _Imagen As Image

        Select Case _Tidp.ToString
            Case "EFV", "EFC"
                _Nombre = "EFECTIVO"
                _Imagen = Lista_Imagenes_16.Images.Item(0)
            Case "TJV", "TJC"
                _Nombre = "TARJETA"
                _Imagen = Lista_Imagenes_16.Images.Item(2)
            Case "CHV", "CHC"
                _Nombre = "CHEQUE"
                _Imagen = Lista_Imagenes_16.Images.Item(1)
            Case "LTV", "LTC"
                _Nombre = "LETRA"
                _Imagen = Lista_Imagenes_16.Images.Item(4)
            Case "PAV", "PAC"
                _Nombre = "PAGARE DE CREDITO"
                _Imagen = Lista_Imagenes_16.Images.Item(4)
            Case "DEP"
                _Nombre = "PAGO POR DEPOSITO"
                _Imagen = Lista_Imagenes_16.Images.Item(6)
            Case "ATB", "PTB"
                _Nombre = "TRANSFERENCIA BANCARIA"
                _Imagen = Lista_Imagenes_16.Images.Item(3)
            Case "ncv", "ncc", "ncx", "nev", "blv", "fcv", "fcc"
                _Nombre = _Tidp 'String.Empty
                _Imagen = Lista_Imagenes_16.Images.Item(5)
            Case Else
                _Nombre = _Tidp & " (OTRA FORMA DE PAGO)"
                _Imagen = Lista_Imagenes_16.Images.Item(7)
        End Select

        Select Case _Tidp
            Case "CHC", "LTC", "PTB", "PAC"
                Btn_Enviar_Correos.Visible = True
            Case Else
                Btn_Enviar_Correos.Visible = False
        End Select

        'If _Tidp = "CHC" Then
        'Btn_Imprimir_Vista_Previa.Visible = True
        'Else
        'Btn_Imprimir_Vista_Previa.Visible = False
        'End If

        'If _Tidp = "TJV" Then
        'Btn_Imprimir_Voucher.Visible = True
        'Else
        'Btn_Imprimir_Voucher.Visible = False
        'End If

        Me.Text = "PAGO: " & _Nombre & " (" & _Idmaedpce & ")"


        With Grilla_Encabezado

            .DataSource = _TblEncabezado
            Grilla_Encabezado.Rows(0).Cells("BtnImagen").Value = _Imagen

            OcultarEncabezadoGrilla(Grilla_Encabezado, True)

            .Columns("BtnImagen").HeaderText = "-"
            .Columns("BtnImagen").Width = 20
            .Columns("BtnImagen").Visible = True

            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 30
            .Columns("TIDP").Visible = True
            .Columns("TIDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("NUDP").HeaderText = "Número Int."
            .Columns("NUDP").Width = 100
            .Columns("NUDP").Visible = True
            .Columns("NUDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("NUCUDP").HeaderText = "Número Doc."
            .Columns("NUCUDP").Width = 100
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("FEEMDP").HeaderText = "Fecha Emi."
            .Columns("FEEMDP").Width = 80
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("FEVEDP").HeaderText = "Fecha Ven."
            .Columns("FEVEDP").Width = 80
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("TIMODP").HeaderText = "T.M."
            .Columns("TIMODP").Width = 30
            .Columns("TIMODP").Visible = True
            '.Columns("TIMODP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("TAMODP").Width = 90
            .Columns("TAMODP").HeaderText = "Tasa"
            .Columns("TAMODP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TAMODP").Visible = True
            .Columns("TAMODP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VADP").Width = 90
            .Columns("VADP").HeaderText = "Valor"
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VADP").Visible = True
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VAABDP").Width = 90
            .Columns("VAABDP").HeaderText = "Abonado"
            .Columns("VAABDP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAABDP").Visible = True
            .Columns("VAABDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VAASDP").Width = 90
            .Columns("VAASDP").HeaderText = "Asignado"
            .Columns("VAASDP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAASDP").Visible = True
            .Columns("VAASDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VAVUDP").Width = 90
            .Columns("VAVUDP").HeaderText = "Vuelto"
            .Columns("VAVUDP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAVUDP").Visible = True
            .Columns("VAVUDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("ESASDP").HeaderText = "Est.As."
            .Columns("ESASDP").Width = 80
            .Columns("ESASDP").Visible = True

            .Columns("ESPGDP").HeaderText = "Est.Pago"
            .Columns("ESPGDP").Width = 80
            .Columns("ESPGDP").Visible = True

            .Columns("SUREDP").HeaderText = "Suc."
            .Columns("SUREDP").Width = 80
            .Columns("SUREDP").Visible = True

            .Columns("CJREDP").HeaderText = "Caja"
            .Columns("CJREDP").Width = 80
            .Columns("CJREDP").Visible = True

            .Columns("KOFUDP").HeaderText = "Resp."
            .Columns("KOFUDP").Width = 80
            .Columns("KOFUDP").Visible = True

            '-- ESASDP  Estado Asignado
            '-- ESPGDP  Estado Pagado
            '-- SUREDP  Sucursal
            '-- CJREDP  Caja
            '-- KOFUDP  Responzable 


        End With


        With Grilla_Detalle

            .DataSource = _TblDetalle

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            .Columns("VAASDP").Width = 90
            .Columns("VAASDP").HeaderText = "$ Asignado"
            .Columns("VAASDP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAASDP").Visible = True
            .Columns("VAASDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("VAASDP").DisplayIndex = 7

            .Columns("FEASDP").HeaderText = "Fecha"
            .Columns("FEASDP").Width = 80
            .Columns("FEASDP").Visible = True
            .Columns("FEASDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("FEASDP").DisplayIndex = 8

            .Columns("Td").HeaderText = "Tipo"
            .Columns("Td").Width = 40
            .Columns("Td").Visible = True
            .Columns("Td").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("FEASDP").DisplayIndex = 8

            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 80
            .Columns("Numero").Visible = True
            .Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("FEASDP").DisplayIndex = 8

            .Columns("Entidad").HeaderText = "Entidad"
            .Columns("Entidad").Width = 75
            .Columns("Entidad").Visible = True

            .Columns("RazonSocial").HeaderText = "Razon social"
            .Columns("RazonSocial").Width = 310
            .Columns("RazonSocial").Visible = True
            '.Columns("FEASDP").DisplayIndex = 8


        End With


    End Sub

    Private Sub Btn_Enviar_Correos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Enviar_Correos.Click

        Dim Fm As New Frm_Inf_Vencimientos_Correos_Proveedores_Pagos(0, _TblDetalle, _TblEntidades, True)
        Fm.Text = "Envío de correo informativo a por el pago de los documentos a los proveedores"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_Ficha_Entidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ficha_Entidad.Click

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Koen = Trim(_Fila.Cells("ENDO").Value)
        Dim _Suen = Trim(_Fila.Cells("SUENDO").Value)

        Dim Fm As New Frm_Crear_Entidad_Mt
        Fm.Fx_Llenar_Entidad(_Koen, _Suen)
        Fm.Pro_Crear_Entidad = False
        Fm.Pro_Editar_Entidad = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_documento.Click

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Archirst As String = _Fila.Cells("ARCHIRST").Value.ToString.Trim
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If _Archirst = "MAEEDO" Then

            Dim Fm As New Frm_Ver_Documento(_Id, 0)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

        If _Archirst = "MAEDPCE" Then

            Dim Fm As New Frm_Pagos_Documentos_Pagados(_Id)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Sub Sb_Imprimir_Cheque()
        Sb_Imprimir(Enum_Tipo_Impresion.Cheque, False)
    End Sub

    Sub Sb_Vista_Previa_Cheque()
        Sb_Imprimir(Enum_Tipo_Impresion.Cheque, True)
    End Sub

    Sub Sb_Imprimir_Voucher()
        Sb_Imprimir(Enum_Tipo_Impresion.Tarjeta, False)
    End Sub

    Sub Sb_Vista_Previa_Voucher()
        Sb_Imprimir(Enum_Tipo_Impresion.Tarjeta, True)
    End Sub

    Enum Enum_Tipo_Impresion
        Cheque
        Tarjeta
        Comprobante
    End Enum

    Sub Sb_Imprimir(_Tipo_Impresion As Enum_Tipo_Impresion, _Vista_Previa As Boolean)

        Dim _NombreFormato As String
        Dim _Row_Formato As DataRow
        Dim _Row_Maedpce As DataRow = _TblEncabezado.Rows(0)

        Dim _Idmaedpce = _Row_Maedpce.Item("IDMAEDPCE")
        Dim _Tidp = _Row_Maedpce.Item("TIDP")
        Dim _Tip = _Tidp
        Dim _Nudp = _Row_Maedpce.Item("NUDP")
        Dim _Emdp = _Row_Maedpce.Item("EMDP")

        Consulta_sql = "Select Top 1 * From TABENDP WHERE TIDPEN = '" & Mid(_Tidp, 1, 2) & "' AND KOENDP = '" & _Emdp & "'"
        Dim _Row_Tabendp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _Tipo_Impresion = Enum_Tipo_Impresion.Cheque Or _Tipo_Impresion = Enum_Tipo_Impresion.Tarjeta Then

            If _Tipo_Impresion = Enum_Tipo_Impresion.Cheque Then
                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                               "Where TipoDoc = 'CHC' And Emdp = '" & _Emdp & "'"
                _NombreFormato = Trim("Cta.Cte: " & _Row_Tabendp.Item("CTACTE")) '000069764215
            ElseIf _Tipo_Impresion = Enum_Tipo_Impresion.Tarjeta Then
                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                               "Where TipoDoc = 'TJV' And Emdp = '" & _Emdp & "'"
                _NombreFormato = Trim(_Row_Tabendp.Item("KOENDP")) & "-" & Trim(_Row_Tabendp.Item("NOKOENDP")) '000069764215
            End If

            _Row_Formato = _Sql.Fx_Get_DataRow(Consulta_sql)

        Else
            _NombreFormato = "Comprobante de pago"
            _Tidp = "CPG"
            _Emdp = "zzz"
        End If

        Dim _Imprimir As New Clas_Imprimir_Documento(_Idmaedpce,
                                                     _Tidp,
                                                     _NombreFormato,
                                                     _Tip & "-" & _Nudp,
                                                     False, _Emdp, "")

        Dim pd As New System.Drawing.Printing.PrintDocument
        Dim _Seleccionar_Impresora As Boolean

        If _Vista_Previa Then
            _Imprimir.Pro_Impresora = pd.PrinterSettings.PrinterName
        Else
            _Seleccionar_Impresora = True
        End If

        If Not _Imprimir.Fx_seleccionar_Impresora(_Seleccionar_Impresora) Then
            Return
        End If

        _Imprimir.Fx_Imprimir_Documento(Nothing, _Vista_Previa)

        Dim _LogError = _Imprimir.Pro_Ultimo_Error

        If Not String.IsNullOrEmpty(_LogError) Then
            MessageBoxEx.Show(Me, _LogError, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Frm_Pagos_Documentos_Pagados_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Editar_Encabezado_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Editar_Encabezado.Click
        If Fx_Tiene_Permiso(Me, "Ppro0010") Then
            ShowContextMenu(Menu_Contextual_02)
        End If
    End Sub

    Private Sub Btn_Cambiar_Nro_Doc_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cambiar_Nro_Doc.Click

        Dim _Idmaedpce As String = _TblEncabezado.Rows(0).Item("IDMAEDPCE")
        Dim _Nucudp As String = Trim(_TblEncabezado.Rows(0).Item("NUCUDP"))
        Dim _Cudp As String = Trim(_TblEncabezado.Rows(0).Item("CUDP"))
        Dim _Aceptado As Boolean

        _Aceptado = InputBox_Bk(Me, "Ingrese el número del documento", "Cambiar número documento", _Nucudp, False,
                              _Tipo_Mayus_Minus.Normal, 8, True,
                              _Tipo_Imagen.Cheque_Numero, False,
                              _Tipo_Caracter.Solo_Numeros_Enteros, False)

        If _Aceptado Then
            Consulta_sql = "Update MAEDPCE Set NUCUDP = '" & _Nucudp & "' Where IDMAEDPCE = " & _Idmaedpce
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Número actualizado correctamente", "Cambiar Nro. documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Grilla_Encabezado.Rows(0).Cells("NUCUDP").Value = _Nucudp
            End If
        End If

    End Sub

    Private Sub Btn_Cambiar_Nro_Cta_Cte_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cambiar_Nro_Cta_Cte.Click

        Dim _Idmaedpce As String = _TblEncabezado.Rows(0).Item("IDMAEDPCE")
        Dim _Nucudp As String = Trim(_TblEncabezado.Rows(0).Item("NUCUDP"))
        Dim _Cudp As String = Trim(_TblEncabezado.Rows(0).Item("CUDP"))
        Dim _Aceptado As Boolean

        _Aceptado = InputBox_Bk(Me, "Ingrese el número de la Cta. Cte.", "Cambiar número Cta. Cte.", _Cudp,
                            False, _Tipo_Mayus_Minus.Normal, 8, True,
                            _Tipo_Imagen.Transferencia_bancaria, False,
                            _Tipo_Caracter.Cualquier_caracter, False)

        If _Aceptado Then
            Consulta_sql = "Update MAEDPCE Set CUDP = '" & _Cudp & "' Where IDMAEDPCE = " & _Idmaedpce
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Número actualizado correctamente", "Cambiar Nro. Cta. Cte.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Grilla_Encabezado.Rows(0).Cells("CUDP").Value = _Cudp
            End If
        End If

    End Sub

    Private Sub Btn_Imprimir_Vista_Previa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Vista_Previa.Click
        ShowContextMenu(Menu_Contextual_03)
    End Sub

    Private Sub Btn_Imprimir_Comprobante_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir_Comprobante.Click
        Sb_Imprimir(Enum_Tipo_Impresion.Comprobante, False)
    End Sub

End Class
