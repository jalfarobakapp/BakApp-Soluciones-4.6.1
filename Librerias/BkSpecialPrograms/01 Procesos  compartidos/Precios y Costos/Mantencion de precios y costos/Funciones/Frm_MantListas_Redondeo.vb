'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_MantListas_Redondeo

    Dim _Seleccionar As Boolean
    Dim _Redondeo As Integer
    Dim _Lista_En_Neto As Boolean

    Dim _Tbl_Redondedor_10 As DataTable
    Dim _Tbl_Redondeos_Todos As DataTable

    Public ReadOnly Property Pro_Seleccionar() As Boolean
        Get
            Return _Seleccionar
        End Get
    End Property
    Public ReadOnly Property Pro_Redondeo() As String
        Get
            Return _Redondeo
        End Get
    End Property

    Public Sub New(ByVal Lista_En_Neto As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Lista_En_Neto = Lista_En_Neto

    End Sub

    Private Sub Frm_MantListas_Redondeo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8.5), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Tbl_Redondedor_10 = Fx_Crear_Tabla_Campos_Funciones(True)
        _Tbl_Redondeos_Todos = Fx_Crear_Tabla_Campos_Funciones(False)

        If _Lista_En_Neto Then
            Chk_Mostrar_Todos_Los_Redondeos.Checked = True
            Chk_Mostrar_Todos_Los_Redondeos.Visible = False
        End If

        Sb_Actualizar_Grilla()

        AddHandler Chk_Mostrar_Todos_Los_Redondeos.CheckedChanged, AddressOf Sb_Chk_Mostrar_Todos_Los_Redondeos_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Tbl As DataTable

        If Chk_Mostrar_Todos_Los_Redondeos.Checked Then
            _Tbl = _Tbl_Redondeos_Todos
        Else
            _Tbl = _Tbl_Redondedor_10
        End If

        With Grilla

            .DataSource = Nothing
            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").HeaderText = "Tipo de redondeo"
            .Columns("Descripcion").Visible = True

        End With

    End Sub

    Function Fx_Crear_Tabla_Campos_Funciones(ByVal _Valores_Brutos As Boolean)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))

        If _Valores_Brutos Then
            dr = dt.NewRow() : dr("Codigo") = "3" : dr("Descripcion") = "#3 Redondear a 0 decimales" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "5" : dr("Descripcion") = "#5 Redondear a la decena más próxima" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "8" : dr("Descripcion") = "#8 Redondear a la centena más próxima" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "9" : dr("Descripcion") = "#9 Redondear 990" : dt.Rows.Add(dr)
        Else
            dr = dt.NewRow() : dr("Codigo") = "7" : dr("Descripcion") = "#7 No aplicar redondeo" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "3" : dr("Descripcion") = "#3 Redondear a 0 decimales" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "2" : dr("Descripcion") = "#2 Redondear a 1 decimales" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "1" : dr("Descripcion") = "#1 Redondear a 2 decimales" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "T" : dr("Descripcion") = "#T Redondear a 3 decimales" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "F" : dr("Descripcion") = "#F Redondear a 4 decimales" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "6" : dr("Descripcion") = "#6 Redondear a 5 unidades" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "5" : dr("Descripcion") = "#5 Redondear a la decena más próxima" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "8" : dr("Descripcion") = "#8 Redondear a la centena más próxima" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "4" : dr("Descripcion") = "#4 Redondear con múltiplo de 5" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "9" : dr("Descripcion") = "#9 Redondear 990" : dt.Rows.Add(dr)
            dr = dt.NewRow() : dr("Codigo") = "E" : dr("Descripcion") = "#E Redondear al entero superior" : dt.Rows.Add(dr)
        End If

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset

        rs.Tables.Add(dt)

        Return dt

    End Function

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        _Redondeo = _Fila.Cells("Codigo").Value
        _Seleccionar = True
        Me.Close()

    End Sub

    Private Sub Frm_MantListas_Redondeo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Chk_Mostrar_Todos_Los_Redondeos_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)
        If Chk_Mostrar_Todos_Los_Redondeos.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Pre0020") Then
                Chk_Mostrar_Todos_Los_Redondeos.Checked = False
            End If
        End If
        Sb_Actualizar_Grilla()
    End Sub
End Class
