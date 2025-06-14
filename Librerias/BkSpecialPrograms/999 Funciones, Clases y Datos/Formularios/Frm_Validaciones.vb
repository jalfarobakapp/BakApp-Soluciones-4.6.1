Imports BkSpecialPrograms.Frm_SolCredito_Ingreso

Public Class Frm_Validaciones

    Public Property Col1_Mensaje As LsValiciones.Columnas
    Public Property Col2_Descripcion As LsValiciones.Columnas
    Public Property Col3_Resultado As LsValiciones.Columnas
    Public Property Col4_Fecha As LsValiciones.Columnas
    Public Property UsarImagenesExternas As Boolean
    Public Property ListaDeImagenesExternas As ImageList

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Col1_Mensaje = New LsValiciones.Columnas
        Col2_Descripcion = New LsValiciones.Columnas
        Col3_Resultado = New LsValiciones.Columnas
        Col4_Fecha = New LsValiciones.Columnas

        Col1_Mensaje.Nombre = "Mensaje"
        Col1_Mensaje.Descripcion = "Mensaje"
        Col1_Mensaje.Ancho = 300
        Col1_Mensaje.Alineacion = HorizontalAlignment.Left
        Col1_Mensaje.Visible = True

        Col2_Descripcion.Nombre = "Descripcion"
        Col2_Descripcion.Descripcion = "Descripción"
        Col2_Descripcion.Ancho = 380
        Col2_Descripcion.Alineacion = HorizontalAlignment.Left
        Col2_Descripcion.Visible = True

        Col3_Resultado.Nombre = "Resultado"
        Col3_Resultado.Descripcion = "Resultado"
        Col3_Resultado.Ancho = 300
        Col3_Resultado.Alineacion = HorizontalAlignment.Left
        Col3_Resultado.Visible = True

        Col4_Fecha.Nombre = "Fecha"
        Col4_Fecha.Descripcion = "Fecha"
        Col4_Fecha.Ancho = 100
        Col4_Fecha.Alineacion = HorizontalAlignment.Left
        Col4_Fecha.Visible = False

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

        '' Cree las columnas de la grilla

        If Col1_Mensaje.Visible Then
            Lv_ListaDeMensajes.Columns.Add(Col1_Mensaje.Nombre, Col1_Mensaje.Ancho, Col1_Mensaje.Alineacion).Text = Col1_Mensaje.Descripcion
        End If

        If Col2_Descripcion.Visible Then
            Lv_ListaDeMensajes.Columns.Add(Col2_Descripcion.Nombre, Col2_Descripcion.Ancho, Col2_Descripcion.Alineacion).Text = Col2_Descripcion.Descripcion
        End If

        If Col3_Resultado.Visible Then
            Lv_ListaDeMensajes.Columns.Add(Col3_Resultado.Nombre, Col3_Resultado.Ancho, Col3_Resultado.Alineacion).Text = Col3_Resultado.Descripcion
        End If

        If Col4_Fecha.Visible Then
            Lv_ListaDeMensajes.Columns.Add(Col4_Fecha.Nombre, Col4_Fecha.Ancho, Col4_Fecha.Alineacion).Text = Col4_Fecha.Descripcion
        End If

        ' Cargue el formulario con respuestas

        If ListaMensajes IsNot Nothing Then

            For Each resp As LsValiciones.Mensajes In ListaMensajes

                Dim item As New ListViewItem(resp.Mensaje)

                If IsNothing(resp.Icono) Then
                    If resp.EsCorrecto Then
                        item.ImageIndex = 0
                    Else
                        item.ImageIndex = 1
                    End If
                Else
                    Select Case resp.Icono
                        Case MessageBoxIcon.Information
                            item.ImageIndex = 0
                        Case MessageBoxIcon.Error
                            item.ImageIndex = 1
                        Case MessageBoxIcon.Warning
                            item.ImageIndex = 2
                        Case MessageBoxIcon.Question
                            item.ImageIndex = 3
                        Case MessageBoxIcon.None
                            item.ImageIndex = Nothing
                        Case Else
                            item.ImageIndex = 1
                    End Select
                End If

                If UsarImagenesExternas Then
                    item.ImageKey = resp.NombreImagen
                End If

                item.SubItems.Add(resp.Detalle)
                item.SubItems.Add(resp.Resultado)
                item.SubItems.Add(resp.Fecha)

                Lv_ListaDeMensajes.Items.Add(item)

                Try
                    If String.IsNullOrEmpty(resp.Tag) Then
                        item.Tag = resp.Mensaje & vbCrLf & resp.Detalle
                    Else
                        item.Tag = resp.Tag
                    End If
                Catch ex As Exception

                End Try

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

        ''' <summary>
        ''' Mensaje de error o advertencia, Columna 1
        ''' </summary>
        ''' <returns></returns>
        Public Property Mensaje As String = String.Empty

        ''' <summary>
        ''' Descripción del error o advertencia, Columna 2
        ''' </summary>
        ''' <returns></returns>
        Public Property Detalle As String = String.Empty

        ''' <summary>
        ''' Resultado de la validación, Columna 3
        ''' </summary>
        ''' <returns></returns>
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
        Public Property ConsultaSQLEjecutada As String

    End Class

    Public Class Columnas

        Public Property Nombre As String
        Public Property Descripcion As String
        Public Property Ancho As Integer
        Public Property Alineacion As HorizontalAlignment = HorizontalAlignment.Left
        Public Property Visible As Boolean = True

    End Class

End Namespace

