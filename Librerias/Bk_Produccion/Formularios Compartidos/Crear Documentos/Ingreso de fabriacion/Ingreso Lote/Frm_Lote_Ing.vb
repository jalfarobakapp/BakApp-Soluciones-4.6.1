Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Lote_Ing

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property NroLote As String
    Public Property Grabar As Boolean

    Dim _Row_Producto As DataRow

    Public Sub New(_NroLote As String, _CodProducto As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _CodProducto & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_NroLote.Text = _NroLote

    End Sub

    Private Sub Frm_Lote_Ing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_NroLote

        Txt_Producto.Text = _Row_Producto.Item("KOPR").ToString.Trim & "-" & _Row_Producto.Item("NOKOPR").ToString.Trim

        Dtp_FechaVenci.Value = DateAdd(DateInterval.Year, 1, FechaDelServidor)

        Txt_Producto.ButtonCustom.Visible = False
        Txt_Producto.ButtonCustom2.Visible = False

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

        If String.IsNullOrEmpty(Txt_CodAlternativo.Text) Then
            MessageBoxEx.Show(Me, "Falta el código alternativo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CodAlternativo.Focus()
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Lotes_Enc",
                                                       "NroLote = '" & Txt_NroLote.Text & "' And Codigo = '" & Txt_Producto.Text & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "El número de Lote ya esta registrado en el sistema", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Lotes_Enc (NroLote,Codigo,FechaVenci,CodAlternativo) Values " &
                       "('" & Txt_NroLote.Text & "','" & _Row_Producto.Item("KOPR") &
                       "','" & Format(Dtp_FechaVenci.Value, "yyyyMMdd") & "','" & Txt_CodAlternativo.Tag & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            NroLote = Txt_NroLote.Text
            Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Txt_CodAlternativo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CodAlternativo.ButtonCustomClick

        Dim _Codigo As String = _Row_Producto.Item("KOPR")
        Dim _Descripcion As String = _Row_Producto.Item("NOKOPR")
        Dim _Rtu As Double = _Row_Producto.Item("RLUD")

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo & "'")

        If _Reg = 0 Then
            MessageBoxEx.Show(Me, "Este producto no tiene códigos alternativos asociados", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_CodAlternativo_Ver
        Fm.TxtCodigo.Text = _Codigo
        Fm.Txtdescripcion.Text = _Descripcion
        Fm.TxtRTU.Text = _Rtu
        Fm.ModoSeleccion = True
        Fm.ShowDialog(Me)
        Dim _Row_Tabcodal As DataRow = Fm.RowTabcodalSeleccionado
        Fm.Dispose()

        If Not IsNothing(_Row_Tabcodal) Then

            Dim _Kopral As String = _Row_Tabcodal.Item("KOPRAL")
            Dim _Nokopral As String = _Row_Tabcodal.Item("NOKOPRAL")

            Txt_CodAlternativo.Tag = _Kopral
            Txt_CodAlternativo.Text = _Kopral.ToString.Trim & " - " & _Nokopral

        End If

    End Sub
End Class
