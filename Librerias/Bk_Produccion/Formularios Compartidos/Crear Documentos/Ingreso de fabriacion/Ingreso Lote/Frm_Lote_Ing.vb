Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Lote_Ing

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property NroLote As String
    Public Property Grabar As Boolean

    Dim _Row_Producto As DataRow

    Public Sub New(_CodProducto As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _CodProducto & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Lote_Ing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_NroLote

        Txt_Producto.Text = _Row_Producto.Item("KOPR").ToString.Trim & "-" & _Row_Producto.Item("NOKOPR").ToString.Trim

    End Sub

    Private Sub Txt_Producto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustomClick

        Try

            Txt_Producto.Enabled = False

            Dim _Codigo As String = Txt_Producto.Text

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Producto) Then
                If Not String.IsNullOrEmpty(_Row_Producto.Item("ATPR").ToString.Trim) Then
                    MessageBoxEx.Show(Me, "Producto oculto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                Else
                    Codigo_abuscar = _Codigo
                    Txt_Producto.Tag = _Row_Producto.Item("KOPR")
                    Txt_Producto.Text = _Row_Producto.Item("KOPR").ToString.Trim & "-" & _Row_Producto.Item("NOKOPR").ToString.Trim
                End If
                Return
            End If

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_Tipo_Lista = "P"
            Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_Mostrar_Info = True
            Fm.BtnCrearProductos.Visible = False
            Fm.BtnExportaExcel.Visible = False
            Fm.Pro_Actualizar_Precios = False

            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then

                _Row_Producto = Fm.Pro_RowProducto

                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then
                    Txt_Producto.Tag = _Row_Producto.Item("KOPR")
                    Txt_Producto.Text = _Row_Producto.Item("KOPR").ToString.Trim & "-" & _Row_Producto.Item("NOKOPR").ToString.Trim
                    Txt_Producto.Focus()
                End If

            End If

            Txt_Producto.ButtonCustom.Visible = Not Fm.Pro_Seleccionado
            Txt_Producto.ButtonCustom2.Visible = Fm.Pro_Seleccionado

            Fm.Dispose()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Producto.Tag = String.Empty
            Txt_Producto.Text = String.Empty
        Finally
            Txt_Producto.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_NroLote.Text) Then
            MessageBoxEx.Show(Me, "Falta el numero de lote", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NroLote.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Producto.Text) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Producto.Focus()
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Lotes_Enc",
                                                       "NroLote = '" & Txt_NroLote.Text & "' And Codigo = '" & Txt_Producto.Text & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "El número de Lote ya esta registrado en el sistema", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Lotes_Enc (NroLote,Codigo,FechaVenci) Values " &
                       "('" & Txt_NroLote.Text & "','" & Txt_Producto.Text & "','" & Format(Dtp_FechaVenci.Value, "yyyyMMdd") & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            NroLote = Txt_NroLote.Text
            Grabar = True
            Me.Close()
        End If

    End Sub

End Class
