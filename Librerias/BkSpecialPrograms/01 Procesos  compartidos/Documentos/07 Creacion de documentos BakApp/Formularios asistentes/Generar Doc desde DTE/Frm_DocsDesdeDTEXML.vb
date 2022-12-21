Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_DocsDesdeDTEXML

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Proveedor As DataRow

    Public Property Folio As String
    Public Property Seleccionado As Boolean

    Public Sub New(_Row_Proveedor As DataRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Row_Proveedor = _Row_Proveedor

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_DocsDesdeDTEXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Fecha = FechaDelServidor()

        Dtp_FechaDesde.Value = Primerdiadelmes(_Fecha)
        Dtp_FechaHasta.Value = ultimodiadelmes(_Fecha)

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseDown, AddressOf Grilla_Detalle_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Chk_Ver_Solo_Pendientes.CheckedChanged, AddressOf Sb_Actualizar_Grilla

    End Sub


    Sub Sb_Actualizar_Grilla()

        Dim _Descripcion As String = Txt_Descripcion.Text.Trim

        Dim _Cadena_SII As String = CADENA_A_BUSCAR(_Descripcion, "Tido+Nudo+Endo+Libro+Rut_Proveedor+Razon_Social+Folio+STR(Monto_Total) LIKE '%")

        Dim _Filtro_SII As String = "And Tido+Nudo+Endo+Libro+Rut_Proveedor+Razon_Social+Folio+STR(Monto_Total) LIKE '%" & _Cadena_SII & "%'"

        Dim _Endo As String = _Row_Proveedor.Item("KOEN")

        Dim _Ver_Solo_Pendienetes = String.Empty

        If Chk_Ver_Solo_Pendientes.Checked Then
            _Ver_Solo_Pendienetes = "And Idmaeedo = 0"
        End If

        Consulta_sql = "-- Tabla 2
                        --Update " & _Global_BaseBk & "Zw_Compras_en_SII Set Idmaeedo_GRC = Isnull((Select IDMAEEDO From MAEEDO Where TIDO = 'GRC' And NUDO = Nudo And ENDO = Endo),0)
                        --Where Endo = '' And Fecha_Docto Between '' And ''

                        Select *,Case When Isnull((Select Top 1 Id From " & _Global_BaseBk & "Zw_DTE_ReccDet Z1 Where Cmp.Rut_Proveedor = Z1.RutEmisor And Z1.Folio = Cmp.Folio And Cmp.TipoDoc = Z1.TipoDTE),0) = 0 Then 'No' Else 'Si' End As TPDF From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
                        Where Endo = '" & _Endo & "' And TipoDoc = 33 And Fecha_Docto Between '" & Format(Dtp_FechaDesde.Value, "yyyyMMdd") & "' And " &
                        "'" & Format(Dtp_FechaHasta.Value, "yyyyMMdd") & "' " & vbCrLf &
                        _Ver_Solo_Pendienetes & vbCrLf &
                       _Filtro_SII

        Dim _Inf_02_Solo_SII As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Inf_02_Solo_SII

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Rut_Proveedor").Visible = True
            '.Columns("Rut_Proveedor").HeaderText = "Rut Proveedor"
            '.Columns("Rut_Proveedor").Width = 80
            '.Columns("Rut_Proveedor").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Razon_Social").Visible = True
            '.Columns("Razon_Social").HeaderText = "Razón Social"
            '.Columns("Razon_Social").Width = 200 + 190 - 30
            '.Columns("Razon_Social").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Folio").Visible = True
            .Columns("Folio").HeaderText = "Folio"
            .Columns("Folio").Width = 80
            .Columns("Folio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TPDF").Visible = True
            .Columns("TPDF").HeaderText = "PDF"
            .Columns("TPDF").Width = 30
            .Columns("TPDF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Docto").Visible = True
            .Columns("Fecha_Docto").HeaderText = "Fecha"
            .Columns("Fecha_Docto").Width = 80
            .Columns("Fecha_Docto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Docto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Exento").Visible = True
            .Columns("Monto_Exento").HeaderText = "Exento"
            .Columns("Monto_Exento").Width = 80
            .Columns("Monto_Exento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Exento").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Exento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Neto").Visible = True
            .Columns("Monto_Neto").HeaderText = "Neto"
            .Columns("Monto_Neto").Width = 80
            .Columns("Monto_Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Neto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Neto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Iva_Recuperable").Visible = True
            .Columns("Monto_Iva_Recuperable").HeaderText = "Iva"
            .Columns("Monto_Iva_Recuperable").Width = 80
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Iva_Recuperable").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Iva_Recuperable").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valor_Otro_Impuesto").Visible = True
            .Columns("Valor_Otro_Impuesto").HeaderText = "Otro Imp."
            .Columns("Valor_Otro_Impuesto").Width = 90
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Otro_Impuesto").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Valor_Otro_Impuesto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Monto_Total").Visible = True
            .Columns("Monto_Total").HeaderText = "Total"
            .Columns("Monto_Total").Width = 80
            .Columns("Monto_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Monto_Total").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Monto_Total").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Idmaeedo = _Fila.Cells("Idmaeedo").Value
            Dim _Idmaeedo_GRC = _Fila.Cells("Idmaeedo_GRC").Value

            If Not Convert.ToBoolean(_Idmaeedo) And Convert.ToBoolean(_Idmaeedo_GRC) Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.GreenYellow
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.GreenYellow
                End If
            End If

            Dim _Libro_cp As String = _Fila.Cells("Libro").Value
            Dim _TipoDoc As Integer = _Fila.Cells("TipoDoc").Value

            If _TipoDoc = 61 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Amarillo
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            End If

        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        If MessageBoxEx.Show(Me, "¿Confirma la selección del documento Folio: " & _Fila.Cells("Folio").Value & "?",
                             "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Folio = _Fila.Cells("Folio").Value
        Seleccionado = True

        Me.Close()

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Exportar_PDF_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_PDF.Click

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            Dim _Folio = _Fila.Cells("Folio").Value
            Dim _TipoDoc = _Fila.Cells("TipoDoc").Value
            Dim _Rut_Proveedor = _Fila.Cells("Rut_Proveedor").Value

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_ReccDet" & vbCrLf &
                           "Where TipoDTE = " & _TipoDoc & " And Folio = " & _Folio & " And RutEmisor = '" & _Rut_Proveedor & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Throw New System.Exception("No se encontro el archivo PDF")
            End If

            Dim _Xml As String = _Row.Item("Xml")

            Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\DTE\Descargas"

            If Not Directory.Exists(_Directorio) Then
                Directory.CreateDirectory(_Directorio)
            End If

            Dim _NombreArchivo As String = _Folio & "_" & _TipoDoc & _Rut_Proveedor '& ".XML"
            Dim _Archivo As String = _Directorio & "\" & _NombreArchivo.Trim

            Dim oSW As New StreamWriter(_Archivo & ".XML")
            oSW.WriteLine(_Xml)
            oSW.Close()

            Dim Ds_Xml As New DataSet
            Ds_Xml.ReadXml(_Archivo & ".XML")

            If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF") Then
                System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF")
            End If

            Dim _File As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _NombreArchivo & ".pdf"

            If Not El_Archivo_Esta_Abierto(_File) Then

                Dim _RecepXMLCmp_MarcaAgua As String = _Global_Row_Configuracion_General.Item("RecepXMLCmp_MarcaAgua")
                Dim _RecepXMLCmp_ImpMarcaAgua As Boolean = Not String.IsNullOrEmpty(_RecepXMLCmp_MarcaAgua)

                Dim Cl_Dte2XmlIPDF As New Cl_Dte2XmlPDF
                Cl_Dte2XmlIPDF.Sb_Crear_PDF2XML(Me, Ds_Xml, _NombreArchivo, _RecepXMLCmp_MarcaAgua, _RecepXMLCmp_ImpMarcaAgua)
                File.Delete(_Archivo & ".XML")

            Else
                Throw New System.Exception("El Archivo se encuentra abierto")
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error al exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            Call Grilla_CellDoubleClick(Nothing, Nothing)
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Idmaeedo_GRC = _Fila.Cells("Idmaeedo").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo_GRC, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Detalle_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                Else
                    Return
                End If

                Dim _Idmaeedo As Integer = .Rows(.CurrentRow.Index).Cells("Idmaeedo").Value
                Dim _TPDF As String = .Rows(.CurrentRow.Index).Cells("TPDF").Value
                Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name

                Btn_Ver_Documento.Visible = CBool(_Idmaeedo)
                Btn_Seleccionar_Documento.Visible = Not CBool(_Idmaeedo)
                Btn_VerXMLPDF.Visible = (_TPDF = "Si")

                ShowContextMenu(Menu_Contextual_Solo_en_SII)

            End With

        End If

    End Sub

    Private Sub Btn_Seleccionar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Seleccionar_Documento.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_VerXMLPDF_Click(sender As Object, e As EventArgs) Handles Btn_VerXMLPDF.Click
        Call Btn_Exportar_PDF_Click(Nothing, Nothing)
    End Sub

End Class
