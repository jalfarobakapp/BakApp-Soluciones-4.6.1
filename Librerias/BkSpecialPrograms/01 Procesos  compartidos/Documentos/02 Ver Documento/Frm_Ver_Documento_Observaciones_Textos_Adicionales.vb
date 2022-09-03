'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_Ver_Documento_Observaciones_Textos_Adicionales

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    'Dim _Idmaeedo As Integer
    Dim _Tbl_Textos As DataTable
    Dim _Row_Observaciones As DataRow
    Dim _Doc_Random As Boolean
    Dim _Grabar As Boolean

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(Row_Observaciones As DataRow, Doc_Random As Boolean) '(ByVal New_Idmaeedo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        '_Idmaeedo = New_Idmaeedo

        _Row_Observaciones = Row_Observaciones
        _Doc_Random = Doc_Random
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_DocumentoTraza_Observaciones_Textos_Adicionales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _Tbl_Textos = Fx_Crear_Tabla2() 'Fx_Crear_Tabla(_Idmaeedo)


        With Grilla

            .DataSource = _Tbl_Textos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Campo").HeaderText = "Texto"
            .Columns("Campo").Visible = True
            .Columns("Campo").Width = 110
            .Columns("Campo").ReadOnly = True

            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").ReadOnly = True

        End With

        'Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        'Dim _TblDocumento As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        'Dim _Tido As String = _TblDocumento.Rows(0).Item("TIDO")
        'Dim _Nudo As String = _TblDocumento.Rows(0).Item("NUDO")

        'Me.Text = "Observaciones adicionales " & _Tido & "-" & _Nudo

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Descripcion").Style.BackColor = Color.LightGray
        Next

        'AddHandler Grilla.RowPostPaint, AddressOf Sb_RowsPostPaint

    End Sub

    Function Fx_Crear_Tabla(ByVal _Idmaeedo As Integer)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Nom_Columna", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Campo", System.Type.[GetType]("System.String"))

        Dim _Columna_d As New DataColumn

        _Columna_d.ColumnName = "Descripcion"
        _Columna_d.DataType = System.Type.[GetType]("System.String")
        _Columna_d.MaxLength = 80
        _Columna_d.DefaultValue = ""

        dt.Columns.Add(_Columna_d) '"Descripcion", System.Type.[GetType]("System.String"))
        ',,,,,,

        Dim _i = 1

        'For Each _Columna As DataColumn In _RowObservaciones.Table.Columns ' _I = 1 To 32

        'Dim _Campo As String = _Columna.ColumnName & _i

        For _i = 1 To 35

            'If _Campo = "TEXTO" & _i Then
            dr = dt.NewRow()
            dr("Nom_Columna") = "TEXTO" & _i
            dr("Campo") = "Texto adicional " & numero_(_i, 2)
            dr("Descripcion") = _Sql.Fx_Trae_Dato("MAEEDOOB", "TEXTO" & _i, "IDMAEEDO = " & _Idmaeedo)
            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

    Function Fx_Crear_Tabla2()

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Nom_Columna", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Campo", System.Type.[GetType]("System.String"))

        Dim _Columna_d As New DataColumn

        _Columna_d.ColumnName = "Descripcion"
        _Columna_d.DataType = System.Type.[GetType]("System.String")
        _Columna_d.MaxLength = 80
        _Columna_d.DefaultValue = ""

        dt.Columns.Add(_Columna_d) '"Descripcion", System.Type.[GetType]("System.String"))
        ',,,,,,

        Dim _i = 1

        'For Each _Columna As DataColumn In _RowObservaciones.Table.Columns ' _I = 1 To 32

        'Dim _Campo As String = _Columna.ColumnName & _i

        Dim _Nombre_Columna As String

        If _Doc_Random Then
            _Nombre_Columna = "TEXTO"
        Else
            _Nombre_Columna = "Obs"
        End If

        For _i = 1 To 35

            'If _Campo = "TEXTO" & _i Then
            dr = dt.NewRow()
            dr("Nom_Columna") = _Nombre_Columna & _i
            dr("Campo") = "Texto adicional " & numero_(_i, 2)
            dr("Descripcion") = _Row_Observaciones.Item(_Nombre_Columna & _i) '_Sql.Fx_Trae_Dato("MAEEDOOB", "TEXTO" & _i, "IDMAEEDO = " & _Idmaeedo)
            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

    Private Sub Frm_DocumentoTraza_Observaciones_Textos_Adicionales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Grilla.DataError
        MessageBoxEx.Show(Me, e.Exception.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Descripcion As String = NuloPorNro(_Fila.Cells("Descripcion").Value, "")

        _Fila.Cells("Descripcion").Value = Mid(_Descripcion, 1, 80)

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl_Textos.Rows

            Dim _Campo As String = _Fila.Item("Nom_Columna")
            Dim _Descripcion As String = _Fila.Item("Descripcion")

            If _Doc_Random Then
                Dim _Idmaeedo As Integer = _Row_Observaciones.Item("IDMAEEDO")
                Consulta_sql += "Update MAEEDOOB Set " & _Campo & " = '" & _Descripcion & "' Where IDMAEEDO = " & _Idmaeedo & vbCrLf
            Else
                Dim _Id_DocEnc As Integer = _Row_Observaciones.Item("Id_DocEnc")
                Consulta_sql += "Update " & _Global_BaseBk & "Zw_Casi_DocObs Set " & _Campo & " = '" & _Descripcion & "' Where Id_DocEnc = " & _Id_DocEnc & vbCrLf
            End If
        Next

        If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            _Grabar = True
            Me.Close()
        End If

    End Sub

    Public Sub Sb_Validar_Keypress_Comillas_Simple(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        Dim caracter As Char = e.KeyChar

        If e.KeyChar = "'"c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            Beep()
            'SendKeys.Send("´")
            'e.KeyChar = "´"c
            'caracter = "´"
        End If

        ' referencia a la celda  
        Dim txt As TextBox = CType(sender, TextBox)


    End Sub

    Private Sub Grilla_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf Sb_Validar_Keypress_Comillas_Simple
    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Delete Then
            If Btn_Grabar.Visible Then
                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                _Fila.Cells("Descripcion").Value = String.Empty
            End If
        End If

    End Sub

    Private Sub Btn_Editar_Observaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Observaciones.Click

        If Fx_Tiene_Permiso(Me, "Doc00007") Then

            Btn_Grabar.Visible = True
            Btn_Editar_Observaciones.Visible = False

            ToastNotification.Show(Me, "AHORA ES POSIBLE EDITAR LAS OBSERVACIONES", My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            Grilla.Columns("Descripcion").ReadOnly = False

            For Each _Fila As DataGridViewRow In Grilla.Rows
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.Cells("Descripcion").Style.BackColor = Color.Black
                Else
                    _Fila.Cells("Descripcion").Style.BackColor = Color.White
                End If
            Next

            Me.Refresh()

        End If

    End Sub

End Class
