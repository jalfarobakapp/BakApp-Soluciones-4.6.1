Imports BkSpecialPrograms.Frm_SolCredito_Ingreso

Public Class Frm_Validaciones

    Public Property Columan1 As LsValiciones.Columnas
    Public Property Columan2 As LsValiciones.Columnas
    Public Property Columan3 As LsValiciones.Columnas
    Public Property Columan4 As LsValiciones.Columnas
    Public Property UsarImagenesExternas As Boolean
    Public Property ListaDeImagenesExternas As ImageList

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Property ListaMensajes As List(Of LsValiciones.Mensajes)

    Private Sub Frm_Validaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lv_ListaDeMensajes.FullRowSelect = True
        Lv_ListaDeMensajes.View = View.Details

        If Global_Thema = Enum_Themas.Oscuro Then
            Lv_ListaDeMensajes.SmallImageList = Imagenes_16x16_Dark
        Else
            Lv_ListaDeMensajes.SmallImageList = Imagenes_16x16
        End If

        If UsarImagenesExternas Then
            Lv_ListaDeMensajes.SmallImageList = ListaDeImagenesExternas
        End If

        ' Cree las columnas de la grilla

        If Not IsNothing(Columan1) Then
            Lv_ListaDeMensajes.Columns.Add(Columan1.Nombre, Columan1.Ancho, HorizontalAlignment.Left).Text = Columan1.Descripcion
        Else
            Lv_ListaDeMensajes.Columns.Add("Mensaje.", 300, HorizontalAlignment.Left).Text = "Mensaje"
        End If

        If Not IsNothing(Columan2) Then
            Lv_ListaDeMensajes.Columns.Add(Columan2.Nombre, Columan2.Ancho, HorizontalAlignment.Left).Text = Columan2.Descripcion
        Else
            Lv_ListaDeMensajes.Columns.Add("Detalle", 380, HorizontalAlignment.Left).Text = "Detalle"
        End If

        If Not IsNothing(Columan3) Then
            Lv_ListaDeMensajes.Columns.Add(Columan3.Nombre, Columan3.Ancho, HorizontalAlignment.Left).Text = Columan3.Descripcion
        Else
            Lv_ListaDeMensajes.Columns.Add("Resultado", 300, HorizontalAlignment.Left).Text = "Resultado"
        End If

        If Not IsNothing(Columan4) Then
            Lv_ListaDeMensajes.Columns.Add(Columan4.Nombre, Columan4.Ancho, HorizontalAlignment.Left).Text = Columan4.Descripcion
        Else
            Lv_ListaDeMensajes.Columns.Add("Fecha", 100, HorizontalAlignment.Left).Text = "Fecha"
        End If


        ' Cargue el formulario con respuestas

        If ListaMensajes IsNot Nothing Then

            For Each resp As LsValiciones.Mensajes In ListaMensajes

                Dim item As New ListViewItem(resp.Mensaje)

                If resp.EsCorrecto Then
                    item.ImageIndex = 0
                Else
                    item.ImageIndex = 1
                End If

                If UsarImagenesExternas Then
                    item.ImageKey = resp.NombreImagen
                End If

                item.SubItems.Add(resp.Detalle)
                item.SubItems.Add(resp.Resultado)
                item.SubItems.Add(resp.Fecha)

                Lv_ListaDeMensajes.Items.Add(item)

                If String.IsNullOrEmpty(resp.Tag) Then
                    item.Tag = resp.Mensaje & vbCrLf & resp.Detalle
                Else
                    item.Tag = resp.Tag
                End If

            Next

        End If

        Lv_ListaDeMensajes.Refresh()

        If Lv_ListaDeMensajes.Items.Count > 0 Then
            Lv_ListaDeMensajes.Items(0).Selected = True
            Lv_ListaDeMensajes.Items(0).EnsureVisible()
        End If

        If Lv_ListaDeMensajes.SelectedIndices.Count > 0 Then
            Txt_Mensaje.Text = Lv_ListaDeMensajes.Items(0).Tag.ToString()
        End If

    End Sub

    Private Sub Lv_ListaDeMensajes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lv_ListaDeMensajes.SelectedIndexChanged

        Try
            If Lv_ListaDeMensajes.SelectedIndices.Count > 0 Then
                Txt_Mensaje.Text = Lv_ListaDeMensajes.Items(Lv_ListaDeMensajes.FocusedItem.Index).Tag.ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_Validaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click

        ' Crear un nuevo DataTable
        Dim _Tbl As New DataTable()

        ' Agregar columnas al DataTable basadas en las columnas del ListView
        For Each column As ColumnHeader In Lv_ListaDeMensajes.Columns
            _Tbl.Columns.Add(column.Text)
        Next

        ' Iterar a través de los elementos del ListView y agregarlos al DataTable
        For Each item As ListViewItem In Lv_ListaDeMensajes.Items
            ' Crear una nueva fila
            Dim row As DataRow = _Tbl.NewRow()

            ' Agregar los datos de cada subitem en la fila
            For i As Integer = 0 To item.SubItems.Count - 1
                row(i) = item.SubItems(i).Text
            Next

            ' Agregar la fila completa al DataTable
            _Tbl.Rows.Add(row)
        Next

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Lista")

    End Sub
End Class

Namespace LsValiciones

    Public Class Mensajes

        Public Property EsCorrecto As Boolean
        Public Property Id As String
        Public Property Fecha As DateTime
        Public Property Detalle As String = String.Empty
        Public Property Mensaje As String = String.Empty
        Public Property Resultado As String = String.Empty
        Public Property Tag As Object
        Public Property UsarImagen As Boolean
        Public Property NombreImagen As String = String.Empty
        Public Property Icono As Object
        Public Property Cancelado As Boolean
        Public Property MostrarMensaje As Boolean = True
        Public Property Cerrar As Boolean
        Public Property ErrorDeConexionSQL As Boolean
        Public Property HuboOtroError As Boolean

    End Class

    Public Class Columnas

        Public Property Nombre As String
        Public Property Descripcion As String
        Public Property Ancho As Integer

    End Class

End Namespace

