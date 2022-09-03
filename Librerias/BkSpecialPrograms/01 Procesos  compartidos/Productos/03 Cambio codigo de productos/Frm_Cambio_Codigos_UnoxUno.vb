'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_Cambio_Codigos_UnoxUno

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _CodigoCambiado As Boolean
    Public _Cerrar_al_cambiar As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Cambio_Codigos_UnoxUno_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_Codigo_Tecnico_New.Enabled = False

        AddHandler ChkCambiarCodigoTecnico.CheckedChanging, AddressOf ChkCambiarCodigoTecnico_CheckedChanging
        AddHandler ChkCambiarCodigoTecnico.CheckValueChanged, AddressOf ChkCambiarCodigoTecnico_CheckValueChanged

        BtnLimpiar.Visible = Not _Cerrar_al_cambiar

    End Sub

    Private Sub BtnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProducto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_Actualizar_Precios = False
        Fm.Pro_Mostrar_Info = False
        Fm.BtnBuscarAlternativos.Visible = True
        Fm.Pro_Mostrar_Imagenes = True
        Fm.BtnCrearProductos.Visible = False
        Fm.Pro_Mostrar_Editar = False
        Fm.Pro_Mostrar_Eliminar = False
        Fm.BtnExportaExcel.Visible = False
        Fm.Pro_Tipo_Lista = "P"
        Fm.Pro_Maestro_Productos = False
        Fm.Pro_Sucursal_Busqueda = ModSucursal
        Fm.Pro_Bodega_Busqueda = ModBodega
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then

            Txt_Codigo_Old.Text = Fm.Pro_RowProducto.Item("KOPR").ToString.Trim
            Txt_Descripcion.Text = Fm.Pro_RowProducto.Item("NOKOPR").ToString.Trim
            Txt_Codigo_Tecnico_Old.Text = Fm.Pro_RowProducto.Item("KOPRTE").ToString.Trim
            Txt_Codigo_Tecnico_New.Text = Fm.Pro_RowProducto.Item("KOPRTE").ToString.Trim

            Txt_Codigo_New.Text = String.Empty
            Txt_Codigo_New.Focus()

        End If

    End Sub

    Private Sub BtnCambiarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarCodigo.Click

        Try

            GroupPanel1.Enabled = False
            Bar2.Enabled = False

            'If Fx_Tiene_Permiso(Me, "Prod003") Then

            If String.IsNullOrEmpty(Trim(Txt_Codigo_Old.Text)) Then
                Beep()
                ToastNotification.Show(Me, "FALTA EL PRODUCTO A CAMBIAR", My.Resources.cross,
                                             1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                Return
            End If

            If String.IsNullOrEmpty(Trim(Txt_Codigo_New.Text)) Then
                Beep()
                ToastNotification.Show(Me, "FALTA NUEVO CODIGO", My.Resources.cross,
                                             1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                Return
            End If

            Dim Fm As New Frm_Cambio_Codigos
            Dim _Existe_PrNew As Boolean = Fm.Fx_Existe_Producto(Me, Txt_Codigo_New.Text, True)


            If Not _Existe_PrNew Then

                _Existe_PrNew = CBool(_Sql.Fx_Cuenta_Registros("MAEPR",
                                "KOPR <> '" & Txt_Codigo_Old.Text & "' And (KOPRTE = '" & Txt_Codigo_Tecnico_New.Text & "' Or KOPR = '" & Txt_Codigo_Tecnico_New.Text & "')"))

                If _Existe_PrNew Then
                    MessageBoxEx.Show(Me, "¡CODIGO TECNICO YA EXISTE!" & vbCrLf &
                                  "El código técnico: " & Trim(Txt_Codigo_Tecnico_New.Text) & " No esta permitido",
                                  "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If MessageBoxEx.Show("¿Esta seguro de cambiar el código?", "Cambiar código",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Consulta_sql = "Select * From MAEPR Where KOPR = '" & Txt_Codigo_Old.Text & "'"
                        Dim _TblPro As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        If Fm.Fx_Cambiar_Codigo(Txt_Codigo_New.Text, Txt_Codigo_Old.Text,
                                            ChkCambiarCodigoTecnico.Checked, True, FUNCIONARIO,
                                            _TblPro.Rows(0), Txt_Codigo_Tecnico_New.Text) Then

                            If _Cerrar_al_cambiar Then
                                _CodigoCambiado = True
                                Me.Close()
                            Else

                                Call BtnLimpiar_Click(Nothing, Nothing)

                                Beep()
                                ToastNotification.Show(Me, "CODIGO CAMBIADO CORRECTAMENTE", My.Resources.ok_button,
                                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                            End If
                        End If

                    End If
                Else
                    Txt_Codigo_New.SelectAll()
                Txt_Codigo_New.Focus()
                Return
            End If

        Catch ex As Exception

        Finally
            GroupPanel1.Enabled = True
            Bar2.Enabled = True
        End Try

    End Sub


    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

        Txt_Codigo_New.Text = String.Empty
        Txt_Descripcion.Text = String.Empty
        Txt_Codigo_Old.Text = String.Empty
        Txt_Codigo_Tecnico_New.Text = String.Empty
        Txt_Codigo_Tecnico_Old.Text = String.Empty
        Txt_Codigo_Tecnico_New.Enabled = False
        ChkCambiarCodigoTecnico.Checked = False

    End Sub

    Private Sub ChkCambiarCodigoTecnico_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

        If Fx_Tiene_Permiso(Me, "Prod041") Then
            Txt_Codigo_Tecnico_New.Enabled = True
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub ChkCambiarCodigoTecnico_CheckValueChanged(sender As Object, e As EventArgs)
        Txt_Codigo_Tecnico_New.Enabled = ChkCambiarCodigoTecnico.Checked
        If Not ChkCambiarCodigoTecnico.Checked Then Txt_Codigo_Tecnico_New.Text = Txt_Codigo_Tecnico_Old.Text
    End Sub
End Class
