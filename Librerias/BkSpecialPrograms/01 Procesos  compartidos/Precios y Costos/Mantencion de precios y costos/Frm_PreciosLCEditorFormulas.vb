'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_PreciosLCEditorFormulas

    'Public Lista As String
    'Public Grabacion As Boolean

    Dim TextoOriginal As String

    ' Dim _IdGrilla As String
    Dim _Texto As String
    Dim _Tabla As String
    Dim _Campo As String
    Dim _Condicion As String

    Dim _Formula As String
    Dim _Grabar As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Formula As String
        Get
            Return TxtFormulaFx.Text
        End Get
        Set(value As String)
            _Formula = value
        End Set
    End Property

    'Public Property IdGrilla As String
    '    Get
    '        Return _IdGrilla
    '    End Get
    '    Set(value As String)
    '        _IdGrilla = value
    '    End Set
    'End Property

    Public Property Texto As String
        Get
            Return _Texto
        End Get
        Set(value As String)
            _Texto = value
        End Set
    End Property

    Public Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property

    Public Property Campo As String
        Get
            Return _Campo
        End Get
        Set(value As String)
            _Campo = value
        End Set
    End Property

    Public Property Condicion As String
        Get
            Return _Condicion
        End Get
        Set(value As String)
            _Condicion = value
        End Set
    End Property

    Public Sub New(ByVal New_Formula As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _Formula = New_Formula

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_PreciosLCEditorFormulas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Edición de formula"
        TxtFormulaFx.Text = _Formula
        TextoOriginal = _Formula

        Sb_Llenar_Grilla()

    End Sub

    Private Sub NuevoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripButton.Click
        TxtFormulaFx.Text = ""
    End Sub

    Private Sub CopiarToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripButton.Click
        Clipboard.SetDataObject(TxtFormulaFx.SelectedText)
    End Sub

    Private Sub CortarToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CortarToolStripButton.Click
        Clipboard.SetDataObject(TxtFormulaFx.SelectedText)
        TxtFormulaFx.SelectedText = ""
    End Sub

    Private Sub PegarToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarToolStripButton.Click
        Dim idata As IDataObject = Clipboard.GetDataObject
        If idata.GetDataPresent(DataFormats.Text) Then
            TxtFormulaFx.Text &= idata.GetData(DataFormats.Text)
        End If
    End Sub

    Private Sub BtnSeleccionarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionarTodo.Click
        Me.TxtFormulaFx.SelectAll()
    End Sub

    Private Sub GuardarToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarToolStripButton.Click
        _Texto = TxtFormulaFx.Text
        _Grabar = True
        Me.Close()
    End Sub


    'Sub Grabar()
    'Consulta_sql = "Update " & Tabla & " Set " & Campo & " = '" & _
    '               Replace(LTrim(RTrim(TxtFormulaFx.Text)), "'", "''") & "'" & vbCrLf & _
    '               "Where " & Condicion 'Lista = '" & Lista & "'" ' & Id
    'If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
    'MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualización de Consulta", _
    '                      MessageBoxButtons.OK, MessageBoxIcon.Information)
    'Preguntar = False
    'Grabacion = True
    'Me.Close()
    'Else
    'MsgBox("Problemas en la grabación", MsgBoxStyle.Critical, "Actualización de Consulta")
    'End If
    'End Sub


    Private Sub Frm_PreciosLCEditorFormulas_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If TxtFormulaFx.Text <> TextoOriginal Then
            If MessageBoxEx.Show(Me, "¿Desea guardar los cambios?", "Salir", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _Grabar = True
            End If
        End If

    End Sub


    Sub Sb_Llenar_Grilla()

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))

        ',,,,,,

        dr = dt.NewRow() : dr("Codigo") = "Flete" : dr("Descripcion") = "Valor flete" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Ila" : dr("Descripcion") = "Porcentaje de Ila del producto" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Iva" : dr("Descripcion") = "Porcentaje de Iva del producto" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Costo" : dr("Descripcion") = "Costo Ud1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Pm" : dr("Descripcion") = "Precio promedio ponderado" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "UC_Ud1" : dr("Descripcion") = "Precio última compra 1ra unidad" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "UC_Ud2" : dr("Descripcion") = "Precio última compra 2da unidad" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Margen" : dr("Descripcion") = "Margen Ud1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Margen_Adicional" : dr("Descripcion") = "Margen adicional Ud1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Margen2" : dr("Descripcion") = "Margen Ud2" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "Margen_Adicional2" : dr("Descripcion") = "Margen adicional Ud2" : dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With Grilla

            .DataSource = Nothing
            .DataSource = dt
            .Columns("Codigo").Width = 150
            .Columns("Codigo").HeaderText = "Código Variable"

            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").HeaderText = "Descripción"

        End With

    End Sub


End Class