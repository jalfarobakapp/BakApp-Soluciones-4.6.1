Imports DevComponents.DotNetBar

Public Class Frm_Imagenes_X_Producto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _TblProducto, _TblProd_Imagenes As DataTable
    Dim Datos_Imagen As New Ds_Imagenes

    Dim _Solicitado As Boolean
    Dim _SucursalDoc, _BodegaDoc, _Ubicacion As String

    Public ReadOnly Property Pro_Solicitado_Bodega() As Boolean
        Get
            Return _Solicitado
        End Get
    End Property

    Public Sub New(_Codigo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Imagenes, 130, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Me._Codigo = _Codigo

    End Sub

    Private Sub Frm_Imagenes_X_Producto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'With Sld_Zoom
        '    .Maximum = 100 ' valor máximo 
        '    .Minimum = 0 ' minimo
        '    .Value = 10
        '    .Step = 1
        '    '.DecimalPlaces = 1
        'End With

        Fx_Llenar_Grilla_Imagenes()
        Sb_Cargar_Imagenes()

        If CBool(Grilla_Imagenes.RowCount) Then
            Pbx_Imagen.SizeMode = PictureBoxSizeMode.Zoom ' Para ajustar tamaño de la imagen
        Else
            Pbx_Imagen.SizeMode = PictureBoxSizeMode.CenterImage ' Para ajustar tamaño de la imagen
            'Sld_Zoom.Enabled = False
        End If

        'If Not Pro_Solicitado_Bodega Then
        '    AddHandler Grilla_Imagenes.MouseDown, AddressOf Sb_Grilla_MouseDown
        'End If

        Btn_Eliminar.Visible = False
        Btn_Subir_Imagen.Visible = False

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Sub Sb_Mostrar_Imagen(_Direccion_Imagen As String,
                          _EsURL As Boolean)
        Try
            If _EsURL Then
                'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Pbx_Imagen.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(_Direccion_Imagen)))
            Else
                Pbx_Imagen.Image = Image.FromFile(_Direccion_Imagen)
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK)
            Pbx_Imagen.Image = Pbx_Imagen.ErrorImage
        End Try

    End Sub
    Public Function Fx_Llenar_Grilla_Imagenes() As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Imagenes Where Codigo = '" & _Codigo & "' Order By Principal Desc"
        _TblProd_Imagenes = _Sql.Fx_Get_DataTable(Consulta_sql)

        Lbl_Url.Text = "Url: Not Found"

        With Grilla_Imagenes
            Datos_Imagen.Clear()

            Datos_Imagen = _Sql.Fx_Get_DataSet(Consulta_sql, Datos_Imagen, "Tbl_Prod_Imagenes")
            .DataSource = Datos_Imagen
            .DataMember = Datos_Imagen.Tables("Tbl_Prod_Imagenes").TableName

            OcultarEncabezadoGrilla(Grilla_Imagenes, True)

            Grilla_Imagenes.Columns("Imagen_Muestra").HeaderText = "Imagenes"
            Grilla_Imagenes.Columns("Imagen_Muestra").Width = 125
            Grilla_Imagenes.Columns("Imagen_Muestra").Visible = True

        End With

        Return CBool(Grilla_Imagenes.RowCount)



    End Function

    Sub Sb_Cargar_Imagenes()

        Dim Fm As New Frm_Form_Esperar
        Fm.BarraCircular.IsRunning = True
        Fm.Show()

        '' Esto sirve con Frameweork 4.5+
        'Es para poder descargar imagenes desde sitios segros https - se sugiere para este framework http solamente
        'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        If CBool(Datos_Imagen.Tables("Tbl_Prod_Imagenes").Rows.Count) Then
            Try

                For Each _Fila As DataRow In Datos_Imagen.Tables("Tbl_Prod_Imagenes").Rows
                    System.Windows.Forms.Application.DoEvents()
                    Dim _Desde_URL As Boolean = _Fila.Item("Desde_URL")
                    Dim _Direccion_Imagen As String = _Fila.Item("Direccion_Imagen")
                    Dim _Principal As Boolean = _Fila.Item("Principal")
                    If _Principal Then Sb_Mostrar_Imagen(_Direccion_Imagen, _Desde_URL)


                    Dim MyWebClient As New System.Net.WebClient
                    Dim ImageInBytes() As Byte = MyWebClient.DownloadData(_Direccion_Imagen)
                    'CREATE A MEMORY STREAM USING THE BYTES
                    Dim _Imagen_Byte As New IO.MemoryStream(ImageInBytes)
                    Dim _Imagen_Prod As Image = New System.Drawing.Bitmap(_Imagen_Byte)
                    Dim _bmp As New Bitmap(_Imagen_Prod)
                    Dim _Destino As Image = New Bitmap(_bmp, 125, 130)

                    'Dim _PBX As New PictureBox
                    '_'PBX.Image = 
                    Dim _Largo = Len(_Direccion_Imagen) - 2
                    Dim _Extencion = Mid(_Direccion_Imagen, _Largo, 3)

                    If UCase(_Extencion) = "JPG" Then
                        _Fila.Item("Imagen_Muestra") = imageToByteArray(_Destino, System.Drawing.Imaging.ImageFormat.Jpeg)
                    ElseIf UCase(_Extencion) = "PNG" Then
                        _Fila.Item("Imagen_Muestra") = imageToByteArray(_Destino, System.Drawing.Imaging.ImageFormat.Png)
                    ElseIf UCase(_Extencion) = "GIF" Then
                        _Fila.Item("Imagen_Muestra") = imageToByteArray(_Destino, System.Drawing.Imaging.ImageFormat.Gif)
                    ElseIf UCase(_Extencion) = "BMP" Then
                        _Fila.Item("Imagen_Muestra") = imageToByteArray(_Destino, System.Drawing.Imaging.ImageFormat.Bmp)
                    ElseIf UCase(_Extencion) = "ICO" Then
                        _Fila.Item("Imagen_Muestra") = imageToByteArray(_Destino, System.Drawing.Imaging.ImageFormat.Icon)
                    End If

                    _Fila.Item("Imagen_Real") = ImageInBytes

                Next
            Catch ex As Exception
                Pbx_Imagen.Image = Pbx_Imagen.ErrorImage
            End Try

        Else
            Pbx_Imagen.Image = Pbx_Imagen.ErrorImage
        End If
        Fm.Close()

    End Sub


    Public Function imageToByteArray(imageIn As System.Drawing.Image,
                                     pformato As System.Drawing.Imaging.ImageFormat) As Byte()

        Dim ms As New IO.MemoryStream

        Try

            imageIn.Save(ms, pformato)

        Catch ex As Exception

            MessageBox.Show("Ocurrió un error " & ex.Message)

        End Try

        Return ms.ToArray()

    End Function

    Sub Sb_Cambiar_Zoom_Imagen(Picbox As PictureBox, Escala As Single)

        Dim Ancho As Single, Alto As Single

        ' si hay una imagen ...
        If Not Picbox.Image Is Nothing Then

            Picbox.SizeMode = PictureBoxSizeMode.Zoom


            With Picbox
                ' Ancho y alto de la imagen   
                Ancho = .Image.Width * (Escala / 10)
                Alto = .Image.Height * (Escala / 10)
                .Width = Ancho
                .Height = Alto

                If Escala = 1.0 Then Picbox.SizeMode = PictureBoxSizeMode.CenterImage

            End With

        End If

    End Sub
    Private Sub Grilla_Imagenes_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Imagenes.CellClick
        Try
            With Grilla_Imagenes
                Dim _Desde_URL As Boolean = .Rows(.CurrentRow.Index).Cells.Item("Desde_URL").Value
                Dim _Direccion_Imagen As String = .Rows(.CurrentRow.Index).Cells.Item("Direccion_Imagen").Value
                Dim ImageInBytes() As Byte = .Rows(.CurrentRow.Index).Cells.Item("Imagen_Real").Value

                Dim _Imagen_Byte As New IO.MemoryStream(ImageInBytes)
                Dim _Imagen_Prod As Image = New System.Drawing.Bitmap(_Imagen_Byte)

                Pbx_Imagen.Image = _Imagen_Prod

            End With
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "Prod069") Then
            Return
        End If

        Try
            Dim _Fila As DataGridViewRow = Grilla_Imagenes.Rows(Grilla_Imagenes.CurrentRow.Index)

            Dim _Id As Integer = _Fila.Cells("Id").Value
            Dim _Direccion_Imagen As String = _Fila.Cells("Direccion_Imagen").Value.ToString.Trim

            If MessageBoxEx.Show(Me, "¿Confirma la eliminación de este registro?" & vbCrLf & vbCrLf &
                                 "Url: " & _Direccion_Imagen, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Imagenes Where Id = " & _Id
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Fx_Llenar_Grilla_Imagenes()
                    Sb_Cargar_Imagenes()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Subir_Imagen_Click(sender As Object, e As EventArgs) Handles Btn_Subir_Imagen.Click

        If Not Fx_Tiene_Permiso(Me, "Prod068") Then
            Return
        End If

        Dim _Aceptar As Boolean
        Dim _Url As String

        _Aceptar = InputBox_Bk(Me, "Ingrese la URL de la imagen a levantar", "Levantamiento de imagen", _Url, True,,, True)

        If _Aceptar Then
            Try

                Dim MyWebClient As New System.Net.WebClient
                Dim ImageInBytes() As Byte = MyWebClient.DownloadData(_Url)
                'CREATE A MEMORY STREAM USING THE BYTES
                Dim _Imagen_Byte As New IO.MemoryStream(ImageInBytes)
                Dim _Imagen_Prod As Image = New System.Drawing.Bitmap(_Imagen_Byte)
                Dim _bmp As New Bitmap(_Imagen_Prod)
                Dim _Destino As Image = New Bitmap(_bmp, 125, 130)

                Sb_Mostrar_Imagen(_Url, True)

                Dim _Principal = 1

                If Grilla_Imagenes.Rows.Count > 0 Then
                    _Principal = 0
                End If

                If MessageBoxEx.Show(Me, "¿Confirma la grabación de este registro?", "Levantar imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Imagenes (Codigo,Desde_URL,Direccion_Imagen,Principal) Values " &
                                   "('" & _Codigo & "',1,'" & _Url & "'," & _Principal & ")"
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        Fx_Llenar_Grilla_Imagenes()
                        Sb_Cargar_Imagenes()
                    End If
                Else
                    Throw New System.Exception("")
                End If
            Catch ex As Exception
                If Not String.IsNullOrEmpty(ex.Message) Then MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Pbx_Imagen.Image = Nothing
                Pbx_Imagen.SizeMode = PictureBoxSizeMode.AutoSize
                Pbx_Imagen.SizeMode = PictureBoxSizeMode.CenterImage
            End Try

        End If

    End Sub

    Private Sub Grilla_Imagenes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Imagenes.CellEnter
        Try
            Dim _Fila As DataGridViewRow = Grilla_Imagenes.Rows(Grilla_Imagenes.CurrentRow.Index)
            Dim _Direccion_Imagen As String = _Fila.Cells("Direccion_Imagen").Value

            Lbl_Url.Text = "Url: " & _Direccion_Imagen
        Catch ex As Exception
            Lbl_Url.Text = "Url: Not Found"
        End Try

    End Sub

    Private Sub Btn_DejarXDefecto_Click(sender As Object, e As EventArgs) Handles Btn_DejarXDefecto.Click
        Try
            Dim _Fila As DataGridViewRow = Grilla_Imagenes.Rows(Grilla_Imagenes.CurrentRow.Index)
            Dim _Id As Integer = _Fila.Cells("Id").Value

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Imagenes Set Principal = 0 Where Codigo = '" & _Codigo & "'" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Prod_Imagenes Set Principal = 1 Where Id = " & _Id

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Registro cambiado correctamente", "Imagen por defecto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Fx_Llenar_Grilla_Imagenes()
                Sb_Cargar_Imagenes()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Mnu_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Eliminar.Click
        Call Btn_Eliminar_Click(Nothing, Nothing)
    End Sub

    'Private Sub Sld_Zoom_ValueChanged(sender As System.Object, e As System.EventArgs)
    '    Sb_Cambiar_Zoom_Imagen(Pbx_Imagen, CSng(Sld_Zoom.Value))
    'End Sub

    Private Sub BtnSolicitarProductoBodega_Click(sender As System.Object, e As System.EventArgs) Handles BtnSolicitarProductoBodega.Click
        _Solicitado = True
        Me.Close()
    End Sub

    Private Sub Frm_Imagenes_X_Producto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Btn_DejarXDefecto.Enabled = (Grilla_Imagenes.Rows.Count > 1)
                    ShowContextMenu(Menu_Contextual_Imagenes)
                End If
            End With
        End If
    End Sub

End Class
