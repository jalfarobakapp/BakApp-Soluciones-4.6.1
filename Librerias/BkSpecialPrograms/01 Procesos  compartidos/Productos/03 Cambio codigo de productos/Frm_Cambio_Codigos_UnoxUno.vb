'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

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

        'BtnLimpiar.Visible = Not _Cerrar_al_cambiar

        If String.IsNullOrEmpty(Txt_Codigo_Old.Text.Trim) Then
            Call Txt_Codigo_Old_ButtonCustom2Click(Nothing, Nothing)
        End If

        CheckBoxX1.Checked = True

    End Sub


    Sub Sb_Cargar_Producto(_RowProducto As DataRow)

        Txt_Codigo_Old.Text = _RowProducto.Item("KOPR").ToString.Trim
        Txt_Descripcion.Text = _RowProducto.Item("NOKOPR").ToString.Trim
        Txt_Codigo_Tecnico_Old.Text = _RowProducto.Item("KOPRTE").ToString.Trim
        Txt_Codigo_Tecnico_New.Text = _RowProducto.Item("KOPRTE").ToString.Trim

        Txt_Codigo_Old.ReadOnly = True
        Txt_Codigo_Old.ButtonCustom2.Enabled = True
        Txt_Codigo_Old.ButtonCustom.Enabled = False

        Txt_Codigo_New.Text = String.Empty
        Txt_Codigo_New.Focus()

    End Sub

    Private Sub BtnCambiarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarCodigo.Click

        Try

            GroupPanel1.Enabled = False
            Bar2.Enabled = False

            If String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
                MessageBoxEx.Show(Me, "PRODUCTO NO EXISTE", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Call Txt_Codigo_Old_ButtonCustom2Click(Nothing, Nothing)
                Return
            End If

            If String.IsNullOrEmpty(Txt_Codigo_Old.Text.Trim) Then
                MessageBoxEx.Show(Me, "FALTA EL PRODUCTO A CAMBIAR", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If String.IsNullOrEmpty(Txt_Codigo_New.Text.Trim) Then
                MessageBoxEx.Show(Me, "FALTA NUEVO CODIGO", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Codigo_New.Focus()
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

                _Existe_PrNew = CBool(_Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & Txt_Codigo_New.Text & "'"))

                If _Existe_PrNew Then
                    MessageBoxEx.Show(Me, "¡NUEVO CODIGO EXISTE COMO ALTERNATIVO!" & vbCrLf & vbCrLf &
                                  "El código : " & Trim(Txt_Codigo_Tecnico_New.Text) & " existe como código alternativo y" & vbCrLf &
                                  "no se puede crear un código de producto que ya exista en la base de datos como alternativo.",
                                  "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                _Existe_PrNew = CBool(_Sql.Fx_Cuenta_Registros("TABRECPR", "KOPR = '" & Txt_Codigo_New.Text & "'"))

                If _Existe_PrNew Then
                    Consulta_sql = "Delete TABRECPR Where KOPR = '" & Txt_Codigo_New.Text & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

                If MessageBoxEx.Show("¿Esta seguro de cambiar el código?", "Cambiar código",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Select * From MAEPR Where KOPR = '" & Txt_Codigo_Old.Text & "'"
                    Dim _TblPro As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    If Fm.Fx_Cambiar_Codigo(Txt_Codigo_New.Text, Txt_Codigo_Old.Text,
                                        ChkCambiarCodigoTecnico.Checked, True, FUNCIONARIO,
                                        _TblPro.Rows(0), Txt_Codigo_Tecnico_New.Text) Then

                        Dim _Cl_CambioCodigo As New Cl_CambioCodigo

                        _Cl_CambioCodigo = Fm.Fx_Cambiar_Codigo_EmpExterna(Txt_Codigo_New.Text, Txt_Codigo_Old.Text,
                                                                       ChkCambiarCodigoTecnico.Checked, True, FUNCIONARIO,
                                                                       _TblPro.Rows(0), Txt_Codigo_Tecnico_New.Text)

                        If _Cl_CambioCodigo.EsCorrecto Then
                            Sb_EjecConsultaBasesExternas(Me, _Cl_CambioCodigo.SqlQuery, True)
                        End If

                        If CheckBoxX1.Checked Then
                            Dim FmAlt As New Frm_CreaProductos_04_CodAlternativo(Txt_Codigo_New.Text, Txt_Codigo_Old.Text, "",
                                                                                 Frm_CreaProductos_04_CodAlternativo.Enum_Accion.Ambos)
                            FmAlt.UsarNMarcaDeKOPR = True
                            FmAlt.Txt_Kopral.Enabled = False
                            FmAlt.Grupo_Proveedor.Enabled = False
                            FmAlt.ShowDialog(Me)
                            FmAlt.Dispose()
                        End If

                        If _Cerrar_al_cambiar Then
                            _CodigoCambiado = True
                            Me.Close()
                        Else

                            Call Txt_Codigo_Old_ButtonCustom2Click(Nothing, Nothing)

                            MessageBoxEx.Show(Me, "CODIGO CAMBIADO CORRECTAMENTE", "Cambiar código", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Txt_Codigo_Old_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Codigo_Old.ButtonCustomClick
        Try

            'Txt_Codigo_Old.Enabled = False

            Dim _Codigo As String = Txt_Codigo_Old.Text

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowProducto) Then
                If Not String.IsNullOrEmpty(_RowProducto.Item("ATPR").ToString.Trim) Then
                    MessageBoxEx.Show(Me, "Producto oculto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                Else
                    Codigo_abuscar = _Codigo
                    Sb_Cargar_Producto(_RowProducto)
                End If
                Return
            End If

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_Tipo_Lista = "P"
            Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_Mostrar_Info = False
            Fm.BtnCrearProductos.Visible = False
            Fm.Txtdescripcion.Text = _Codigo
            Fm.BtnExportaExcel.Visible = False
            Fm.Pro_Actualizar_Precios = False
            Fm.TraerTodosLosProductos = True

            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then

                _RowProducto = Fm.Pro_RowProducto
                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then
                    Sb_Cargar_Producto(_RowProducto)
                End If

            Else

                If String.IsNullOrEmpty(Txt_Descripcion.Text) Then
                    Call Txt_Codigo_Old_ButtonCustom2Click(Nothing, Nothing)
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Txt_Codigo_Old_ButtonCustom2Click(Nothing, Nothing)
        Finally
            'Txt_Codigo_Old.Enabled = True
        End Try
    End Sub

    Private Sub Txt_Codigo_Old_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Codigo_Old.ButtonCustom2Click
        GroupPanel1.Enabled = True
        Txt_Codigo_Old.ReadOnly = False
        Txt_Codigo_New.Text = String.Empty
        Txt_Descripcion.Text = String.Empty
        Txt_Codigo_Old.Text = String.Empty
        Txt_Codigo_Tecnico_New.Text = String.Empty
        Txt_Codigo_Tecnico_Old.Text = String.Empty
        Txt_Codigo_Tecnico_New.Enabled = False
        ChkCambiarCodigoTecnico.Checked = False
        Txt_Codigo_Old.ButtonCustom2.Enabled = False
        Txt_Codigo_Old.ButtonCustom.Enabled = True
        Txt_Codigo_Old.Focus()
    End Sub

    Private Sub Txt_Codigo_Old_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Codigo_Old.KeyDown
        If Txt_Codigo_Old.ButtonCustom.Visible Then
            If e.KeyValue = Keys.Enter Then
                Call Txt_Codigo_Old_ButtonCustomClick(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Frm_Cambio_Codigos_UnoxUno_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
