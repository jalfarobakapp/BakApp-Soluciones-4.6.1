Imports DevComponents.DotNetBar

Public Class Frm_St_CotizacionesxOT

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Ot As DataSet
    Dim _Id_Ot As Integer
    Dim _Tbl_Documentos As DataTable

    Public Sub New(_Id_Ot As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Me._Id_Ot = _Id_Ot

    End Sub

    Private Sub Frm_St_CotizacionesxOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Rdb_DocTodos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_DocCOV.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_DocNVV.CheckedChanged, AddressOf Rdb_CheckedChanged

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Filtro_Documentos As String

        If Rdb_DocCOV.Checked Then _Filtro_Documentos = "And Edo.TIDO = 'COV'"
        If Rdb_DocNVV.Checked Then _Filtro_Documentos = "And Edo.TIDO = 'NVV'"
        If Rdb_DocTodos.Checked Then _Filtro_Documentos = "And Edo.TIDO In ('COV','NVV')"

        Consulta_sql = "Select Cast(0 As Bit) As Chk,OtEnc.Sub_Ot,OtEnc.Codigo,OtEnc.Descripcion,OtDet.*," &
                       "Edo.IDMAEEDO,Edo.SUDO,Edo.TIDO,Edo.NUDO,Edo.VABRDO,Edo.FEEMDO," &
                       "Case Edo.ESDO When 'C' Then 'Cerrado' Else 'Abierto' End As 'EstadoDoc'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados OtDet" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Idmaeedo" & vbCrLf &
                       "Inner Join MAEDDO Ddo on Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_St_OT_Encabezado OtEnc On OtEnc.Id_Ot = OtDet.Id_Ot" & vbCrLf &
                       "Where OtDet.Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado " &
                       "Where Id_Ot_Padre = " & _Id_Ot & ") " & vbCrLf &
                       _Filtro_Documentos & vbCrLf &
                       "Order By Edo.TIDO,Edo.NUDO"

        '_Ds_Ot = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Documentos = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 30
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sub_Ot").HeaderText = "Sub OT"
            .Columns("Sub_Ot").Width = 40
            .Columns("Sub_Ot").Visible = True
            .Columns("Sub_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").HeaderText = "SD"
            .Columns("SUDO").Width = 35
            .Columns("SUDO").Visible = True
            .Columns("SUDO").DisplayIndex = _DisplayIndex
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

            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 90
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 250
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").HeaderText = "Monto"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("EstadoDoc").HeaderText = "Estado"
            .Columns("EstadoDoc").Width = 60
            .Columns("EstadoDoc").Visible = True
            .Columns("EstadoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged

        For Each _Fila As DataRow In _Tbl_Documentos.Rows
            _Fila.Item("Chk") = Chk_Marcar_Todas.Checked
        Next

    End Sub

    Private Sub Btn_GenerarPDF_Click(sender As Object, e As EventArgs) Handles Btn_GenerarPDF.Click

        Dim _Marcadas As Boolean

        For Each _Fila As DataRow In _Tbl_Documentos.Rows
            If _Fila.Item("Chk") Then
                _Marcadas = True
                Exit For
            End If
        Next

        If Not _Marcadas Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Impresora As String

        Dim _Filtro_Documentos As String = Generar_Filtro_IN(_Tbl_Documentos, "Chk", "IDMAEEDO", True, True)

        _Filtro_Documentos = "And Edo.IDMAEEDO In " & _Filtro_Documentos

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Encabezado" & vbCrLf &
                       "Inner Join MAEEN On KOEN = CodEntidad And SUEN = SucEntidad" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf &
                       "Select Cast(0 As Bit) As Chk,OtEnc.Sub_Ot,OtEnc.Codigo,OtEnc.Descripcion,OtDet.*,Edo.*," &
                       "Case Edo.ESDO When 'C' Then 'Cerrado' Else 'Abierto' End As 'EstadoDoc'," &
                       "Ddo.*,1 As Contador,Cast(0 As Bit) As Impreso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados OtDet" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Idmaeedo" & vbCrLf &
                       "Inner Join MAEDDO Ddo on Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_St_OT_Encabezado OtEnc On OtEnc.Id_Ot = OtDet.Id_Ot" & vbCrLf &
                       "Where OtDet.Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado " &
                       "Where Id_Ot_Padre = " & _Id_Ot & ") " & vbCrLf &
                       _Filtro_Documentos & vbCrLf &
                       "Order By Edo.TIDO,Edo.NUDO"
        Dim _Ds_Ot As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Cl_Imprimir_PDFSt As New Cl_Imprimir_PDFSt(_Id_Ot)
        _Cl_Imprimir_PDFSt.Ds_Ot = _Ds_Ot
        _Cl_Imprimir_PDFSt.Fx_Imprimir_Archivo(Me, "PDF Cotizaciones OTS", _Impresora)

    End Sub

    Private Sub Rdb_CheckedChanged(sender As Object, e As EventArgs)

        Sb_Actualizar_Grilla()
        Chk_Marcar_Todas.Checked = False

    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub
End Class
