Imports BkSpecialPrograms.Frm_SolCredito_Ingreso

Public Class Frm_Validaciones
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Property ListaMensajes As List(Of LsValiciones.Mensajes)

    Private Sub Frm_Validaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lv_ListaDeMensajes.View = View.Details

        If Global_Thema = Enum_Themas.Oscuro Then
            Lv_ListaDeMensajes.SmallImageList = Imagenes_16x16_Dark
        Else
            Lv_ListaDeMensajes.SmallImageList = Imagenes_16x16
        End If

        ' Cree las columnas de la grilla
        Lv_ListaDeMensajes.Columns.Add("Est.", 300, HorizontalAlignment.Left).Text = "Detalle"
        Lv_ListaDeMensajes.Columns.Add("Mensaje", 380, HorizontalAlignment.Left).Text = "Mensaje"

        ' Cargue el formulario con respuestas

        If ListaMensajes IsNot Nothing Then

            For Each resp As LsValiciones.Mensajes In ListaMensajes

                Dim item As New ListViewItem(resp.Detalle)

                If resp.EsCorrecto Then
                    item.ImageIndex = 0
                Else
                    item.ImageIndex = 1
                End If

                item.SubItems.Add(resp.Mensaje)
                Lv_ListaDeMensajes.Items.Add(item)


                'Dim lvi As ListViewItem = lvFics.Items.Add(_Fila.Item("Tido") & "-" & _Fila.Item("Nudo"), _Imagen)
                'lvi.SubItems.Add(_Fila.Item("Nombre_Entidad"))
                'lvi.SubItems.Add(_Estado)


                item.Tag = resp.Mensaje & vbCrLf & resp.Detalle

            Next

        End If

        Lv_ListaDeMensajes.Refresh()

    End Sub

    Private Sub Lv_ListaDeMensajes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lv_ListaDeMensajes.SelectedIndexChanged

        If Lv_ListaDeMensajes.SelectedIndices.Count > 0 Then
            Txt_Mensaje.Text = Lv_ListaDeMensajes.Items(Lv_ListaDeMensajes.FocusedItem.Index).Tag.ToString()
        End If

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_Validaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class



Namespace LsValiciones

    Public Class Mensajes

        Public Property EsCorrecto As Boolean
        Public Property Mensaje As String
        Public Property Detalle As String
        Public Property Resultado As String

    End Class

End Namespace

