Imports DevComponents.DotNetBar

Public Class Frm_Tickets_IngProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Tickets_Producto As New Tickets_Db.Tickets_Producto
    Public Property Grabar As Boolean
    Public Property Descripcion As String

    Dim _Row_Producto As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Tickets_IngProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Txt_Cantidad.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_StfiEnBodega.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        With Tickets_Producto

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & .Codigo & "'"
            _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Bodega.Text = .Bodega
            Txt_Producto.Text = .Codigo & " - " & .Descripcion

            Dim _Arr_Tipo_Entidad(,) As String = {{"1", .Ud1}, {"2", .Ud2}}
            Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_UdMedida)
            Cmb_UdMedida.SelectedValue = .UdMedida

            Txt_Cantidad.Text = .Cantidad
            Txt_StfiEnBodega.Text = .StfiEnBodega
            Txt_Diferencia.Text = .Diferencia

            Dtp_FechaRev.Value = .FechaRev
            Dtp_HoraRev.Value = .FechaRev

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        ' Definir la fecha y la hora como cadenas
        Dim _Fecha As String = Dtp_FechaRev.Value.ToShortDateString '"2021-10-01"
        Dim _Hora As String = Dtp_HoraRev.Value.ToLongTimeString '"12:00:00"
        ' Concatenar la fecha y la hora con un espacio entre ellas
        Dim _FechaHora As String = _Fecha & " " & _Hora
        ' Convertir la cadena en un objeto DateTime
        Dim _FechaRev As DateTime = DateTime.Parse(_FechaHora)

        With Tickets_Producto

            .Cantidad = Txt_Cantidad.Text
            .StfiEnBodega = Txt_StfiEnBodega.Text
            .Diferencia = Txt_StfiEnBodega.Text - Txt_Cantidad.Text
            .FechaRev = _FechaRev

            Descripcion = "PRODUCTO : " & .Codigo & " - " & .Descripcion.Trim & vbCrLf &
                          "BODEGA " & Txt_Bodega.Text & vbCrLf &
                          "CANTIDAD EN BODEGA SEGUN SISTEMA: " & .StfiEnBodega & vbCrLf &
                          "CANTIDAD INVENTARIADA: " & .Cantidad & vbCrLf &
                          "DIFERENCIA: " & .Cantidad & vbCrLf &
                          "FECHA Y HORA DE REV.: " & Dtp_FechaRev.Value

        End With

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Txt_Producto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustomClick

        Dim _ProductoSeleccionado As Boolean

        Try

            Txt_Producto.Enabled = False

            Dim _Codigo As String = Txt_Producto.Text

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowProducto) Then
                If Not String.IsNullOrEmpty(_RowProducto.Item("ATPR").ToString.Trim) Then
                    MessageBoxEx.Show(Me, "Producto oculto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                Else
                    Codigo_abuscar = _Codigo
                    Txt_Producto.Tag = _RowProducto.Item("KOPR")
                    Txt_Producto.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim
                End If
                Return
            End If

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_Tipo_Lista = "P"
            Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_Mostrar_Info = True
            Fm.BtnCrearProductos.Visible = False
            Fm.Txtdescripcion.Text = String.Empty
            Fm.BtnExportaExcel.Visible = False
            Fm.Pro_Actualizar_Precios = False

            Fm.ShowDialog(Me)
            _ProductoSeleccionado = Fm.Pro_Seleccionado

            If _ProductoSeleccionado Then

                _RowProducto = Fm.Pro_RowProducto

                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then

                    With Tickets_Producto

                        .Codigo = _RowProducto.Item("KOPR")
                        .Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
                        .Empresa = ModEmpresa
                        .Rtu = _RowProducto.Item("RLUD")
                        .Ud1 = _RowProducto.Item("UD01PR")
                        .Ud2 = _RowProducto.Item("UD02PR")

                        Txt_Producto.Tag = .Codigo
                        Txt_Producto.Text = .Codigo.ToString.Trim & "-" & .Descripcion.ToString.Trim
                        Txt_Cantidad.Focus()

                        Dim _Arr_Tipo_Entidad(,) As String = {{"1", .Ud1}, {"2", .Ud2}}
                        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_UdMedida)
                        Cmb_UdMedida.SelectedValue = 2
                        .UdMedida = 2

                    End With

                End If

            End If

            Fm.Dispose()

            Txt_Producto.ButtonCustom.Visible = Not _ProductoSeleccionado
            Txt_Producto.ButtonCustom2.Visible = _ProductoSeleccionado

            If _ProductoSeleccionado Then
                Call Txt_Bodega_ButtonCustomClick(Nothing, Nothing)
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Producto.Tag = String.Empty
            Txt_Producto.Text = String.Empty
        Finally
            Txt_Producto.Enabled = True
        End Try

    End Sub

    Private Sub Txt_Producto_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustom2Click

    End Sub

    Private Sub Txt_Bodega_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Bodega.ButtonCustomClick

        If String.IsNullOrEmpty(Tickets_Producto.Codigo) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = ModEmpresa
        Fm_b.Pro_Sucursal = NuloPorNro(Tickets_Producto.Sucursal, ModSucursal)
        Fm_b.Pro_Bodega = NuloPorNro(Tickets_Producto.Bodega, ModBodega)
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            With Tickets_Producto

                .Empresa = Fm_b.Pro_RowBodega.Item("EMPRESA")
                .Sucursal = Fm_b.Pro_RowBodega.Item("KOSU")
                .Bodega = Fm_b.Pro_RowBodega.Item("KOBO")
                Txt_Bodega.Text = Fm_b.Pro_RowBodega.Item("NOKOSU").ToString.Trim & " - " & Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

                Txt_StfiEnBodega.Text = 0
                Txt_StfiEnBodega.Focus()

            End With

        End If

        Fm_b.Dispose()

    End Sub
End Class
