Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Cerrar_Abrir_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Maeedo As DataRow
    Dim _Tbl_Maeedo As DataTable
    Dim _Tbl_Maeddo As DataTable

    Dim _Idmaeedo As Integer

    Public ReadOnly Property Pro_Row_Maeedo() As DataRow
        Get
            Return _Row_Maeedo
        End Get
    End Property

    Public Sub New(Idmaeedo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Idmaeedo = Idmaeedo

       Sb_Formato_Generico_Grilla(Grilla_Encabezado, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Actualizar_Grillas()

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Cerrar_Documento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        InsertarBotonenGrilla(Grilla_Encabezado, "BtnImagen", "Est.", "Estado", 0, _Tipo_Boton.Imagen)
        InsertarBotonenGrilla(Grilla_Detalle, "BtnImagen", "Est.", "Estado", 0, _Tipo_Boton.Imagen)

        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.CellEnter, AddressOf Sb_Grilla_Detalle_CellEnter

        Lbl_Informacion_Linea.Text = String.Empty


        Sb_Formato_Grillas()

    End Sub

    Sub Sb_Actualizar_Grillas()

        Consulta_sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Maeedo = _Ds.Tables(0)
        _Tbl_Maeddo = _Ds.Tables(1)

        _Row_Maeedo = _Tbl_Maeedo.Rows(0)

        Grilla_Encabezado.DataSource = _Tbl_Maeedo
        Grilla_Detalle.DataSource = _Tbl_Maeddo

        Dim _Esdo = Trim(_Row_Maeedo.Item("ESDO"))

        Btn_Abrir_Documento.Enabled = False
        Btn_Cerrar_Documento.Enabled = False

        If String.IsNullOrEmpty(_Esdo) Then
            Btn_Cerrar_Documento.Enabled = True
        ElseIf _Esdo = "C" Then
            Btn_Abrir_Documento.Enabled = True
        End If

        Bar2.Refresh()

    End Sub

    Sub Sb_Formato_Grillas()

        With Grilla_Encabezado

            OcultarEncabezadoGrilla(Grilla_Encabezado, True)

            .Columns("BtnImagen").Width = 50
            .Columns("BtnImagen").HeaderText = "Est."
            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").DisplayIndex = 0

            .Columns("ESTADO").HeaderText = "Estado"
            .Columns("ESTADO").Width = 70
            .Columns("ESTADO").DisplayIndex = 1
            .Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("ESTADO").Visible = True

            .Columns("TIDO").HeaderText = "T.D."
            .Columns("TIDO").Width = 35
            .Columns("TIDO").DisplayIndex = 2
            .Columns("TIDO").Visible = True

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").DisplayIndex = 3
            .Columns("NUDO").Visible = True

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 75
            .Columns("ENDO").DisplayIndex = 4
            .Columns("ENDO").Visible = True

            .Columns("RAZON").HeaderText = "Razón Social"
            .Columns("RAZON").Width = 200
            .Columns("RAZON").DisplayIndex = 5
            .Columns("RAZON").Visible = True

            '.Columns("SUDO").HeaderText = "Suc"
            '.Columns("SUDO").Width = 30
            '.Columns("SUDO").DisplayIndex = 5
            '.Columns("SUDO").Visible = True

            '.Columns("LUVTDO").HeaderText = "C.C."
            '.Columns("LUVTDO").Width = 50
            '.Columns("LUVTDO").DisplayIndex = 6
            '.Columns("LUVTDO").Visible = True

            .Columns("FEEMDO").HeaderText = "Emisión"
            .Columns("FEEMDO").Width = 75
            .Columns("FEEMDO").DisplayIndex = 6
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDO").Visible = True

            '.Columns("FEULVEDO").HeaderText = "Ult.Venci."
            '.Columns("FEULVEDO").Width = 75
            '.Columns("FEULVEDO").DisplayIndex = 7
            '.Columns("FEULVEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("FEULVEDO").Visible = True

            .Columns("FEER").HeaderText = "F.Recep"
            .Columns("FEER").Width = 75
            .Columns("FEER").DisplayIndex = 8
            .Columns("FEER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEER").Visible = True

        End With



        With Grilla_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            .Columns("BtnImagen").Width = 50
            .Columns("BtnImagen").HeaderText = "Est."
            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").DisplayIndex = 0

            .Columns("ESTADO").HeaderText = "Estado"
            .Columns("ESTADO").Visible = True
            .Columns("ESTADO").Width = 60
            .Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("ESTADO").DisplayIndex = 1

            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").Width = 40
            .Columns("BOSULIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("BOSULIDO").DisplayIndex = 2

            .Columns("KOFULIDO").HeaderText = "Ven"
            .Columns("KOFULIDO").Visible = True
            .Columns("KOFULIDO").Width = 35
            .Columns("KOFULIDO").DisplayIndex = 3

            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").Width = 95
            .Columns("KOPRCT").DisplayIndex = 4

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").Width = 220
            .Columns("NOKOPR").DisplayIndex = 5

            .Columns("UD").HeaderText = "Ud."
            .Columns("UD").Visible = True
            .Columns("UD").Width = 30
            .Columns("UD").DisplayIndex = 6

            '.Columns("CANTIDAD").HeaderText = "Cant."
            '.Columns("CANTIDAD").Visible = True
            '.Columns("CANTIDAD").Width = 50
            '.Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("CANTIDAD").DefaultCellStyle.Format = "###,##.##"
            '.Columns("CANTIDAD").DisplayIndex = 6

            '.Columns("CANT_AUTO_JUST").HeaderText = "Auto D."
            '.Columns("CANT_AUTO_JUST").Visible = True
            '.Columns("CANT_AUTO_JUST").Width = 50
            '.Columns("CANT_AUTO_JUST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("CANT_AUTO_JUST").DefaultCellStyle.Format = "###,##.##"
            '.Columns("CANT_AUTO_JUST").DisplayIndex = 7

            '.Columns("CANT_POR_RELACION").HeaderText = "Ext. D"
            '.Columns("CANT_POR_RELACION").Visible = True
            '.Columns("CANT_POR_RELACION").Width = 50
            '.Columns("CANT_POR_RELACION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("CANT_POR_RELACION").DefaultCellStyle.Format = "###,##.##"
            '.Columns("CANT_POR_RELACION").DisplayIndex = 8

            .Columns("SALDO").HeaderText = "Saldo"
            .Columns("SALDO").Visible = True
            .Columns("SALDO").Width = 70
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("SALDO").DisplayIndex = 7

        End With


        Dim _Esdo = Trim(_Row_Maeedo.Item("ESDO"))
        Dim _Row As DataGridViewRow = Grilla_Encabezado.Rows(0)

        If String.IsNullOrEmpty(_Esdo) Then
            _Row.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("padlock-open.png")
            _Row.Cells("ESTADO").Style.ForeColor = Verde
        ElseIf _Esdo = "C" Then
            _Row.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("padlock.png")
            _Row.Cells("ESTADO").Style.ForeColor = Rojo
        ElseIf _Esdo = "N" Then
            _Row.Cells("BtnImagen").Value = Nothing
            _Row.DefaultCellStyle.ForeColor = Color.Gray
        End If

        For Each _Row In Grilla_Detalle.Rows

            Dim _Eslido = Trim(_Row.Cells("ESLIDO").Value)
            Dim _Saldo As Double = _Row.Cells("Saldo").Value

            If CBool(_Saldo) Then
                _Row.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("padlock-open.png")
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Row.DefaultCellStyle.ForeColor = Color.White
                Else
                    _Row.DefaultCellStyle.ForeColor = Color.Black
                End If
                _Row.Cells("ESTADO").Style.ForeColor = Verde
            Else
                _Row.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("padlock.png")
                _Row.DefaultCellStyle.ForeColor = Color.Gray
                _Row.Cells("ESTADO").Style.ForeColor = Rojo
            End If

        Next

        If CBool(_Tbl_Maeddo.Rows.Count) Then
            Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(0).Cells("KOPRCT")
        End If

    End Sub

    Private Sub Frm_Cerrar_Documento_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_Detalle_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick

        Dim _Idmaeedo = _Row_Maeedo.Item("IDMAEEDO")
        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)
        Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value
        Dim _Eslido = Trim(_Fila.Cells("ESLIDO").Value)

        Dim _Caprco1 As Double = _Fila.Cells("CAPRCO1").Value
        Dim _Caprex1 As Double = _Fila.Cells("CAPREX1").Value

        Dim _Abrir As Boolean

        If _Eslido = "C" Then
            _Abrir = True
        Else
            _Abrir = False
        End If

        If _Caprco1 <> _Caprex1 Then

            Btn_Abrir_Documento.Enabled = False
            Btn_Cerrar_Documento.Enabled = False
            Me.Refresh()

            Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Maeddo, "IDMAEDDO = " & _Idmaeddo, "IDMAEDDO")

            Dim Cerrar_Doc As New Clas_Cerrar_Documento

            If String.IsNullOrEmpty(_Eslido) Then

                If Fx_Revisar_Linea_Cerrada(_Idmaeddo, False) Then

                    If Fx_Tiene_Permiso(Me, "Doc00011") Then
                        Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo, _Tbl)
                    End If

                Else
                    Return
                End If
            Else

                If Fx_Revisar_Linea_Cerrada(_Idmaeddo, True) Then

                    If Fx_Tiene_Permiso(Me, "Doc00055") Then
                        Cerrar_Doc.Fx_Abrir_Documento(_Idmaeedo, _Tbl)
                    End If

                End If

            End If

            Beep()
            Sb_Actualizar_Grillas()
            Sb_Formato_Grillas()

            Dim _Esdo = Trim(_Row_Maeedo.Item("ESDO"))
            Dim _Saldo As Double = Math.Round(_Row_Maeedo.Item("CAPRCO") - (_Row_Maeedo.Item("CAPRAD") + _Row_Maeedo.Item("CAPREX")), 5)
            Dim _Caprad As Double = _Row_Maeedo.Item("CAPRAD")

            If _Abrir Then
                If String.IsNullOrEmpty(_Esdo) Then
                    If _Caprad = 0 Then
                        MessageBoxEx.Show(Me, "Documento reactivado completamente", "Abrir documento", _
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                End If
            Else
                If _Esdo = "C" Then
                    MessageBoxEx.Show(Me, "Documento cerrado completamente", "Cerrar documento", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If

        Else

            MessageBoxEx.Show(Me, "Esta línea está ligada externamente", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If


    End Sub

    Private Sub Sb_Grilla_Detalle_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)
        Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value
        Dim _Eslido = Trim(_Fila.Cells("ESLIDO").Value)

        Dim _Cantidad As Double = _Fila.Cells("CANTIDAD").Value
        Dim _Cant_auto_justificada As Double = _Fila.Cells("CANT_AUTO_JUST").Value
        Dim _Cant_por_relacion_externa As Double = _Fila.Cells("CANT_POR_RELACION").Value


        Lbl_Informacion_Linea.Text = "Cantidad original del documento: " & FormatNumber(_Cantidad, 2) & vbCrLf & _
                                     "Cantidad auto justificada      : " & FormatNumber(_Cant_auto_justificada, 2) & vbCrLf & _
                                     "Cantidad por relación externa  : " & FormatNumber(_Cant_por_relacion_externa, 2)


    End Sub

    Private Sub Btn_Cerrar_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cerrar_Documento.Click

        Dim _Idmaeedo = _Row_Maeedo.Item("IDMAEEDO")

        If Fx_Revisar_Documento_Cerrado(_Idmaeedo, False) Then

            Dim _Tbl = _Tbl_Maeddo.Select("IDMAEEDO = " & _Idmaeedo)

            Dim Cerrar_Doc As New Clas_Cerrar_Documento
            Dim _Rows_Usuario_Autoriza As DataRow

            If Not Fx_Tiene_Permiso(Me, "Doc00011",,,,,,,,, _Rows_Usuario_Autoriza,,,,,,,, _Idmaeedo) Then
                Return
            End If

            If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo, _Tbl_Maeddo) Then

                Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _Idmaeedo, "", "", "Doc00011", "", "", "", False, _Rows_Usuario_Autoriza.Item("KOFU"))

                Sb_Actualizar_Grillas()
                Sb_Formato_Grillas()

                MessageBoxEx.Show(Me, "Documento cerrado completamente", "Cerrar documento",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            End If

        End If

    End Sub

    Private Sub Btn_Abrir_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Abrir_Documento.Click

        Dim _Idmaeedo = _Row_Maeedo.Item("IDMAEEDO")

        If Fx_Revisar_Documento_Cerrado(_Idmaeedo, True) Then

            'If Not Fx_Tiene_Permiso(Me, "Doc00055") Then
            '    Return
            'End If

            Dim Cerrar_Doc As New Clas_Cerrar_Documento
            Dim _Rows_Usuario_Autoriza As DataRow

            If Not Fx_Tiene_Permiso(Me, "Doc00055",,,,,,,,, _Rows_Usuario_Autoriza,,,,,,,, _Idmaeedo) Then
                Return
            End If

            If Cerrar_Doc.Fx_Abrir_Documento(_Idmaeedo, _Tbl_Maeddo) Then

                Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _Idmaeedo, "", "", "Doc00055", "", "", "", False, _Rows_Usuario_Autoriza.Item("KOFU"))

                Sb_Actualizar_Grillas()
                Sb_Formato_Grillas()

                MessageBoxEx.Show(Me, "Documento reactivado completamente", "Abrir documento",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            End If

        End If

    End Sub

    Function Fx_Revisar_Linea_Cerrada(_Idmaeddo As Integer, _Abrir As Boolean) As Boolean

        Consulta_sql = "Select Top 1 * From MAEDDO Where IDMAEDDO = " & _Idmaeddo
        Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Accion

        If _Abrir Then
            _Accion = "abrir"
        Else
            _Accion = "cerrar"
        End If

        If Not (_Row Is Nothing) Then

            Dim _Caprco1 As Double = _Row.Item("CAPRCO1")
            Dim _Caprex1 As Double = _Row.Item("CAPREX1")

            If _Caprco1 <> _Caprex1 Then
                Return True
            Else
                MessageBoxEx.Show(Me, "Línea completamente ligada a relación esterna" & vbCrLf & _
                                  "No se puede " & _Accion, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Else
            MessageBoxEx.Show(Me, "No se encontro información", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Function Fx_Revisar_Documento_Cerrado(_Idmaeedo As Integer, _Abrir As Boolean) As Boolean

        Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Accion

        If _Abrir Then
            _Accion = "abrir"
        Else
            _Accion = "cerrar"
        End If

        If Not (_Row Is Nothing) Then

            Dim _Caprco As Double = _Row.Item("CAPRCO")
            Dim _Caprex As Double = _Row.Item("CAPREX")

            If _Caprco <> _Caprex Then
                Return True
            Else
                MessageBoxEx.Show(Me, "Documento completamente ligado a relación externa" & vbCrLf &
                                  "No se puede " & _Accion, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Else
            MessageBoxEx.Show(Me, "No se encontro el docuemnto", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Private Sub GroupPanel1_Click(sender As Object, e As EventArgs) Handles GroupPanel1.Click

    End Sub
End Class
