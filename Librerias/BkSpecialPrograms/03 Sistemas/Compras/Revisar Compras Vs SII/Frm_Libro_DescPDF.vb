Imports System.IO
Imports CrystalDecisions.Shared.Json
Imports DevComponents.DotNetBar

Public Class Frm_Libro_DescPDF

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Documentos As DataTable

    Private _Periodo As Integer
    Private _Mes As Integer
    Private _Mes_Palabra As String
    Private _Cancelar As Boolean

    Public Property SoloEnSII As Boolean
    Public Property Filtro_SII As String

    Public Sub New(_Periodo As Integer, _Mes As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Periodo = _Periodo
        Me._Mes = _Mes

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Libro_DescPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _CondicionSoloSII = String.Empty

        If SoloEnSII Then
            _CondicionSoloSII = "And Libro = '' And Idmaeedo = 0"
        End If

        Consulta_sql = "Select Cast(0 As Bit) As Chk, Case When DteD.[Xml] IS NULL then 'No' Else 'Si' End As 'TPDF',Cmp.*--,Cast(0 As Bit) As 'TieneOccRef',Cast('' As Varchar(20)) As 'OccRef' 
                        From " & _Global_BaseBk & "Zw_Compras_en_SII Cmp
                        Left Join " & _Global_BaseBk & "Zw_DTE_ReccDet DteD On Cmp.Rut_Proveedor = DteD.RutEmisor And Cmp.Folio = DteD.Folio
                        Where Periodo = " & _Periodo & " And Mes = " & _Mes & vbCrLf &
                        _CondicionSoloSII & vbCrLf &
                        "And DteD.[Xml] Is Not Null" & vbCrLf &
                        Filtro_SII &
                        "Order by Libro"

        _Tbl_Documentos = _Sql.Fx_Get_DataTable(Consulta_sql)


        With Grilla

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla, False)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rut_Proveedor").Visible = True
            .Columns("Rut_Proveedor").HeaderText = "Rut Proveedor"
            .Columns("Rut_Proveedor").Width = 80
            .Columns("Rut_Proveedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Razon_Social").Visible = True
            .Columns("Razon_Social").HeaderText = "Razón Social"
            .Columns("Razon_Social").Width = 240
            .Columns("Razon_Social").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

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

            ''OccRef,FolioRef
            '.Columns("TieneOccRef").Visible = True
            '.Columns("TieneOccRef").HeaderText = "Tiene OC"
            '.Columns("TieneOccRef").ToolTipText = "Tiene OC en referencia del XML"
            '.Columns("TieneOccRef").Width = 40
            '.Columns("TieneOccRef").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Libro").Visible = True
            '.Columns("Libro").HeaderText = "Libro"
            '.Columns("Libro").Width = 110
            '.Columns("Libro").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Fecha_Docto").Visible = True
            .Columns("Fecha_Docto").HeaderText = "Fecha"
            .Columns("Fecha_Docto").Width = 70
            .Columns("Fecha_Docto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Docto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub


    Sub Sb_Exportar_PDF()

        Dim _Cancelar = False

        Dim _Registros_Marcados = Grilla.Rows.Cast(Of DataGridViewRow)().Count(Function(row) row.Cells("Chk").Value = "True")

        If _Registros_Marcados = 0 Then

            MessageBoxEx.Show(Me, "No hay ningún registro seleccionado", "Cerrar documentos",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If


        Dim _FolderBrowserDialog As New FolderBrowserDialog
        _FolderBrowserDialog.Reset()

        Dim _Directorio As String

        ' leyenda  
        _FolderBrowserDialog.Description = "Seleccionar una carpeta "

        _Directorio = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF"

        If Not Directory.Exists(_Directorio) Then
            System.IO.Directory.CreateDirectory(_Directorio)
        End If

        ' Path " Mis documentos "  
        _FolderBrowserDialog.SelectedPath = _Directorio 'Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        'Habilita el botón " crear nueva carpeta "  
        _FolderBrowserDialog.ShowNewFolderButton = True

        Dim ret As DialogResult = _FolderBrowserDialog.ShowDialog

        ' si se presionó el botón aceptar ...  
        If ret = Windows.Forms.DialogResult.OK Then

            Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

            nFiles = My.Computer.FileSystem.GetFiles(_FolderBrowserDialog.SelectedPath)
            _Directorio = _FolderBrowserDialog.SelectedPath
        Else

            Return

        End If

        _FolderBrowserDialog.Dispose()

        Dim _Cerrado = 0
        Dim _Contador = 1

        'Sb_Habilitar_Desabilitar_Controles(False)

        Barra_Progreso.Maximum = 100
        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = True

        Btn_Cancelar.Visible = True
        Btn_Importar_PDF.Enabled = False

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Fila.Cells("Chk").Value Then

                Barra_Progreso.Value = ((_Contador * 100) / _Registros_Marcados)
                _Contador += 1

                Dim _Folio = _Fila.Cells("Folio").Value
                Dim _Tido = _Fila.Cells("Tido").Value.ToString.Trim
                Dim _TipoDoc = _Fila.Cells("TipoDoc").Value
                Dim _Rut_Proveedor = _Fila.Cells("Rut_Proveedor").Value

                Dim _NombreArchivo As String = _Rut_Proveedor & "_" & _Tido & "-" & numero_(_Folio, 10)

                Lbl_Status.Text = "(" & Barra_Progreso.Value & "%)" & _NombreArchivo & ".pdf"

                Application.DoEvents()

                Fx_Crear_PDF(_Fila, _Directorio)

                If _Cancelar Then
                    Lbl_Status.Text = "Status..."
                    Barra_Progreso.Visible = Not _Cancelar
                    Exit For
                End If

                Application.DoEvents()

            End If

        Next

        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = False
        Lbl_Status.Text = "Status..."
        Btn_Cancelar.Visible = False
        Btn_Importar_PDF.Enabled = True

        Me.Refresh()

        If CBool(_Contador) Then
            Process.Start("explorer.exe", _Directorio)
        End If

        Me.Refresh()

    End Sub


    Function Fx_Crear_PDF(_Fila As DataGridViewRow, _Directorio As String) As Boolean

        Dim _Folio = _Fila.Cells("Folio").Value
        Dim _Tido = _Fila.Cells("Tido").Value.ToString.Trim
        Dim _TipoDoc = _Fila.Cells("TipoDoc").Value
        Dim _Rut_Proveedor = _Fila.Cells("Rut_Proveedor").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_ReccDet" & vbCrLf &
                       "Where TipoDTE = " & _TipoDoc & " And Folio = " & _Folio & " And RutEmisor = '" & _Rut_Proveedor & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            MessageBoxEx.Show(Me, "No se encontro el archivo PDF", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim _Xml As String = _Row.Item("Xml")

        'Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\DTE\Descargas"

        'If Not Directory.Exists(_Directorio) Then
        '    Directory.CreateDirectory(_Directorio)
        'End If

        Dim _NombreArchivo As String = _Rut_Proveedor & "_" & _Tido & "-" & numero_(_Folio, 10)
        Dim _Archivo As String = _Directorio & "\" & _NombreArchivo.Trim

        Dim oSW As New StreamWriter(_Archivo & ".XML")
        oSW.WriteLine(_Xml)
        oSW.Close()

        Dim Ds_Xml As New DataSet
        Ds_Xml.ReadXml(_Archivo & ".XML")

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF")
        End If

        'Dim _File As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _NombreArchivo & ".pdf"

        'If Not El_Archivo_Esta_Abierto(_File) Then

        Dim _RecepXMLCmp_MarcaAgua As String = _Global_Row_Configuracion_General.Item("RecepXMLCmp_MarcaAgua")
        Dim _RecepXMLCmp_ImpMarcaAgua As Boolean = Not String.IsNullOrEmpty(_RecepXMLCmp_MarcaAgua)

        Dim Cl_Dte2XmlIPDF As New Cl_Dte2XmlPDF
        Cl_Dte2XmlIPDF.Crear_PDF_En_Directorio = True
        Cl_Dte2XmlIPDF.Directorio = _Directorio
        Cl_Dte2XmlIPDF.Sb_Crear_PDF2XML(Me, Ds_Xml, _NombreArchivo, _RecepXMLCmp_MarcaAgua, _RecepXMLCmp_ImpMarcaAgua, False)
        File.Delete(_Archivo & ".XML")


    End Function

    Private Sub Btn_Importar_PDF_Click(sender As Object, e As EventArgs) Handles Btn_Importar_PDF.Click
        Sb_Exportar_PDF()
    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged
        For Each _Fila As DataRow In _Tbl_Documentos.Rows
            _Fila.Item("Chk") = Chk_Marcar_Todas.Checked
        Next
    End Sub

    Private Sub Frm_Libro_DescPDF_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        Btn_Cancelar.Enabled = False

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer cancelar esta acción?", "Cancelar proceso",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Lbl_Status.Text = "Cancelando el proceso, por favor espere..."
            Barra_Progreso.Value = 0
            System.Windows.Forms.Application.DoEvents()
            Me.Refresh()
            _Cancelar = True
        Else
            Btn_Cancelar.Enabled = True
        End If

    End Sub

End Class
