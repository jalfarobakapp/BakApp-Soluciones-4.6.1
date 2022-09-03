Imports DevComponents.DotNetBar

Public Class Frm_Imagenes_X_Producto_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Cancelar As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Productos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Imagenes, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Imagenes_X_Producto_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        Sb_Actualizar_Grilla()
        AddHandler Grilla_Productos.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Imagenes.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Imagenes.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_BuscarProducto.Text), "KOPR+NOKOPR LIKE '%")

        Consulta_sql = "Select Id,Codigo,NOKOPR,Desde_URL,Direccion_Imagen,Principal" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Imagenes" & vbCrLf &
                       "Inner Join MAEPR Mp On Mp.KOPR = Codigo" & vbCrLf &
                       "Where Desde_URL = 1" & vbCrLf &
                       "And Codigo+NOKOPR Like '%" & _Cadena & "%'" & vbCrLf &
                       "Order By Codigo,Principal Desc"

        Consulta_sql = "Select KOPR As Codigo, NOKOPR As Descripcion,(Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Imagenes Where Codigo = KOPR) As Imagenes" & vbCrLf &
                        "From MAEPR" & vbCrLf &
                        "Where TIPR = 'FPN'" & vbCrLf &
                        "And KOPR+NOKOPR Like '%" & _Cadena & "%'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Productos

            .DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla_Productos, True)

            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").Visible = True

            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 390
            .Columns("Descripcion").Visible = True

            .Columns("Imagenes").HeaderText = "Url"
            .Columns("Imagenes").Width = 50
            .Columns("Imagenes").Visible = True

        End With

    End Sub

    Private Sub Btn_Levantar_Imagenes_Click(sender As Object, e As EventArgs) Handles Btn_Levantar_Imagenes.Click

        If Not Fx_Tiene_Permiso(Me, "Prod071") Then
            Return
        End If

        Dim Fm As New Frm_Imagenes_X_Producto_Lev
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        If Not Fx_Tiene_Permiso(Me, "Prod070") Then
            Return
        End If

        Consulta_sql = "Select Id,Codigo,NOKOPR,Desde_URL,Direccion_Imagen,Principal" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Imagenes" & vbCrLf &
                       "Inner Join MAEPR Mp On Mp.KOPR = Codigo" & vbCrLf &
                       "Where Desde_URL = 1" & vbCrLf &
                       "Order By Codigo,Principal Desc"

        ExportarTabla_JetExcel(Consulta_sql, Me, "Productos VS Url imagenes")

    End Sub

    Private Sub Txt_BuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_BuscarProducto.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_RevisarUrlError_Click(sender As Object, e As EventArgs) Handles Btn_RevisarUrlError.Click

        If Not Fx_Tiene_Permiso(Me, "Prod070") Then
            Return
        End If

        GroupPanel1.Enabled = False
        GroupPanel2.Enabled = False
        Bar1.Enabled = False
        Me.ControlBox = False
        Barra_Progreso.Visible = True
        Btn_Cancelar.Visible = True
        _Cancelar = False

        Txt_BuscarProducto.Text = String.Empty
        Sb_Actualizar_Grilla()

        Dim _Contador = 0
        Dim _SinProbremas = 0
        Dim _Problemas = 0

        Consulta_sql = "Select Id,Codigo,NOKOPR,Desde_URL,Direccion_Imagen As Url,Principal,Cast('' As Varchar(300)) As Error_Url" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Imagenes" & vbCrLf &
                       "Inner Join MAEPR Mp On Mp.KOPR = Codigo" & vbCrLf &
                       "Where Desde_URL = 1" & vbCrLf &
                       "Order By Codigo,Principal Desc"
        Dim _Tbl_Imagenes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filas = _Tbl_Imagenes.Rows.Count

        Try

            For Each _Fila As DataRow In _Tbl_Imagenes.Rows

                Dim _Codigo As String = _Fila.Item("Codigo")
                Dim _Url As String = _Fila.Item("Url")
                Dim _Error As String = String.Empty

                Try
                    Dim MyWebClient As New System.Net.WebClient
                    Dim ImageInBytes() As Byte = MyWebClient.DownloadData(_Url)
                    _SinProbremas += 1
                Catch ex As Exception
                    _Fila.Item("Error_Url") = "Error 404 PAGE NOT FOUND." & ex.Message
                    _Problemas += 1
                End Try

                System.Windows.Forms.Application.DoEvents()

                If _Cancelar Then
                    Exit For
                End If

                _Contador += 1
                Barra_Progreso.Value = ((_Contador * 100) / _Filas)
                Barra_Progreso.Value += 1

                Lbl_Status.Text = "Leyendo fila " & _Contador & " de " & _Filas & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas & ", Producto: " & _Codigo

            Next

            If _Cancelar Then
                MessageBoxEx.Show(Me, "Acción cancelada por el usuario", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Problemas = 0 Then
                MessageBoxEx.Show(Me, "No hay registros con problemas, todas la URL llevana a un sitio", "Revisar Url",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If _Problemas > 0 Then
                MessageBoxEx.Show(Me, "Se encontraron " & _Problemas & " registros con problemas." & vbCrLf &
                                  "A continuación se exportara a Excel el resultado.", "Revisar Url",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ExportarTabla_JetExcel_Tabla(_Tbl_Imagenes, Me, "URL con problemas")
                Return
            End If

        Catch ex As Exception

        Finally
            GroupPanel1.Enabled = True
            GroupPanel2.Enabled = True
            Me.ControlBox = True
            Bar1.Enabled = True
            Barra_Progreso.Visible = False
            Btn_Cancelar.Visible = False
            Lbl_Status.Text = "Status..."
        End Try

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Btn_Ver_Imagen_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Imagen.Click

        Try

            Dim _Fila As DataGridViewRow = Grilla_Imagenes.Rows(Grilla_Imagenes.CurrentRow.Index)
            Dim _Url As String = _Fila.Cells("Direccion_Imagen").Value

            Dim MyWebClient As New System.Net.WebClient
            Dim ImageInBytes() As Byte = MyWebClient.DownloadData(_Url)
            'CREATE A MEMORY STREAM USING THE BYTES
            Dim _Imagen_Byte As New IO.MemoryStream(ImageInBytes)
            Dim _Imagen_Prod As Image = New System.Drawing.Bitmap(_Imagen_Byte)
            'w = 635
            'h = 435

            Dim _Eliminar As Boolean

            Dim Fm As New Frm_Ver_Imagen
            Fm.Text = "URL: " & _Url
            Fm.Btn_Cancelar.Text = "Eliminar"
            Fm.Imagen = _Imagen_Prod
            Fm.ShowDialog(Me)
            _Eliminar = Fm.Cancelar
            Fm.Dispose()

            If _Eliminar Then
                Call Btn_Eliminar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.CellDoubleClick
        ShowContextMenu(Menu_Contextual_Productos)
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.CellEnter
        Sb_Actualizar_Grilla_Imagenes()
    End Sub

    Sub Sb_Actualizar_Grilla_Imagenes()

        Dim _Fila As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)
        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Consulta_sql = "Select Id,Codigo,NOKOPR,Desde_URL,Direccion_Imagen,Principal" & vbCrLf &
               "From " & _Global_BaseBk & "Zw_Prod_Imagenes" & vbCrLf &
               "Inner Join MAEPR Mp On Mp.KOPR = Codigo" & vbCrLf &
               "Where Desde_URL = 1" & vbCrLf &
               "And Codigo = '" & _Codigo & "'" & vbCrLf &
               "Order By Codigo,Principal Desc"
        Dim _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Imagenes

            .DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla_Imagenes, True)

            '.Columns("Codigo").HeaderText = "Código"
            '.Columns("Codigo").Width = 100
            '.Columns("Codigo").Visible = True

            '.Columns("NOKOPR").HeaderText = "Descripción"
            '.Columns("NOKOPR").Width = 220
            '.Columns("NOKOPR").Visible = True

            .Columns("Direccion_Imagen").HeaderText = "Url"
            .Columns("Direccion_Imagen").Width = 220 + 220 + 100
            .Columns("Direccion_Imagen").Visible = True

        End With

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    If sender.Name = "Grilla_Productos" Then
                        ShowContextMenu(Menu_Contextual_Productos)
                    Else
                        ShowContextMenu(Menu_Contextual_Imagenes)
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_Imagenes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Imagenes.CellDoubleClick
        Call Btn_Ver_Imagen_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "Prod069") Then
            Return
        End If

        Try
            Dim _FilaPr As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)
            Dim _Fila As DataGridViewRow = Grilla_Imagenes.Rows(Grilla_Imagenes.CurrentRow.Index)

            Dim _Id As Integer = _Fila.Cells("Id").Value
            Dim _Codigo As String = _FilaPr.Cells("Codigo").Value
            Dim _Direccion_Imagen As String = _Fila.Cells("Direccion_Imagen").Value.ToString.Trim

            If MessageBoxEx.Show(Me, "¿Confirma la eliminación de este registro?" & vbCrLf & vbCrLf &
                                 "Url: " & _Direccion_Imagen, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Imagenes Where Id = " & _Id
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Dim _Imagenes As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Imagenes", "Codigo = '" & _Codigo & "'")
                    _FilaPr.Cells("Imagenes").Value = _Imagenes
                    Grilla_Imagenes.Rows.Remove(_Fila)
                End If
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_Agregar_Imagen_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Imagen.Click

        If Not Fx_Tiene_Permiso(Me, "Prod068") Then
            Return
        End If

        Dim _Aceptar As Boolean
        Dim _Url As String

        _Aceptar = InputBox_Bk(Me, "Ingrese la URL de la imagen a levantar", "Levantamiento de imagen",
                               _Url, False,,, True, _Tipo_Imagen.Imagen1)

        If _Aceptar Then

            _Aceptar = False
            Dim _Fila As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)
            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Imagenes",
                                  "Codigo = '" & _Codigo & "' And Direccion_Imagen = '" & _Url & "'"))

            If _Reg Then
                MessageBoxEx.Show(Me, "Esta URL ya esta registrada para este producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Try

                Dim MyWebClient As New System.Net.WebClient
                Dim ImageInBytes() As Byte = MyWebClient.DownloadData(_Url)
                'CREATE A MEMORY STREAM USING THE BYTES
                Dim _Imagen_Byte As New IO.MemoryStream(ImageInBytes)
                Dim _Imagen_Prod As Image = New System.Drawing.Bitmap(_Imagen_Byte)
                'Dim _bmp As New Bitmap(_Imagen_Prod)
                'Dim _Destino As Image = New Bitmap(_bmp, 630, 430) 'New Bitmap(_bmp, 125, 130)
                'w = 635
                'h = 435
                Dim Fm As New Frm_Ver_Imagen
                Fm.Text = "URL: " & _Url
                Fm.Imagen = _Imagen_Prod
                Fm.ShowDialog(Me)
                _Aceptar = Fm.Aceptar
                Fm.Dispose()

                Dim _Principal = 1

                If Grilla_Imagenes.Rows.Count > 0 Then
                    _Principal = 0
                End If

                If _Aceptar Then
                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Imagenes (Codigo,Desde_URL,Direccion_Imagen,Principal) Values " &
                                   "('" & _Codigo & "',1,'" & _Url & "'," & _Principal & ")"
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        Dim _Imagenes As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Imagenes", "Codigo = '" & _Codigo & "'")
                        _Fila.Cells("Imagenes").Value = _Imagenes
                        Sb_Actualizar_Grilla_Imagenes()
                    End If

                    If MessageBoxEx.Show(Me, "¿Desea agregar otra imagen?", "Agregar imagen",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Call Btn_Agregar_Imagen_Click(Nothing, Nothing)
                    End If

                End If

            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try

        End If

    End Sub

    Private Sub Btn_ImagenesDelProducto_Click(sender As Object, e As EventArgs) Handles Btn_ImagenesDelProducto.Click

        Dim _Fila As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Imagenes As Integer = _Fila.Cells("Imagenes").Value

        If Not CBool(_Imagenes) Then
            MessageBoxEx.Show(Me, "El producto no tiene imagenes que mostrar", "Producto sin imagenes", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Imagenes_X_Producto(_Codigo)
        Fm.Btn_Eliminar.Visible = False
        Fm.Btn_Subir_Imagen.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla_Imagenes()

    End Sub

    Private Sub Btn_DejarXDefecto_Click(sender As Object, e As EventArgs) Handles Btn_DejarXDefecto.Click
        Try

            Dim _FilaPr As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)
            Dim _Codigo As String = _FilaPr.Cells("Codigo").Value

            Dim _Fila As DataGridViewRow = Grilla_Imagenes.Rows(Grilla_Imagenes.CurrentRow.Index)
            Dim _Id As Integer = _Fila.Cells("Id").Value

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Imagenes Set Principal = 0 Where Codigo = '" & _Codigo & "'" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Prod_Imagenes Set Principal = 1 Where Id = " & _Id

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Registro cambiado correctamente", "Imagen por defecto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Sb_Actualizar_Grilla_Imagenes()
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

End Class
