Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_ListaEtiquetas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnNuevaEtiqueta.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_ImpBarras_ListaEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler BtnNuevaEtiqueta.Click, AddressOf Sb_Crear_etiqueta
        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Editar_Etiqueta

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Mouse_Clic_Boton_derecho_Grilla
        AddHandler Mnu_EliminarEtiquetaToolStripMenuItem.Click, AddressOf Sb_Eliminar_Etiqueta
        AddHandler Mnu_CambiarNombreDeLaEtiquetaToolStripMenuItem.Click, AddressOf Sb_Cambiar_Nombre_Etiqueta

    End Sub

    Private Sub Frm_ImpBarras_ListaEtiquetas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "PROCEDIMIENTOS"

#Region "CREAR NUEVA ETIQUETA"

    Sub Sb_Crear_etiqueta()

        Dim Fm As New Frm_ImpBarras_EdicionEtiquetas(0)
        Fm.TxtNombreEtiqueta.ReadOnly = False
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Actualizar_Grilla()

    End Sub

#End Region

#Region "EDITAR ETIQUETA"

    Sub Sb_Editar_Etiqueta()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Semilla As Integer = _Fila.Cells("Semilla").Value
        Dim _NombreEtiqueta As String = _Fila.Cells("NombreEtiqueta").Value
        Dim _Funcion As String = _Fila.Cells("FUNCION").Value
        Dim _CantPorLinea As Integer = _Fila.Cells("CantPorLinea").Value

        Dim Fm As New Frm_ImpBarras_EdicionEtiquetas(_Semilla)
        'Fm._NombreEtiqueta = _NombreEtiqueta
        'Fm._Funcion = _Funcion
        'Fm._CantPorLinea = _CantPorLinea
        Fm.TxtNombreEtiqueta.ReadOnly = True
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Actualizar_Grilla()

    End Sub


#End Region

#Region "CAMBIAR NOMBRE DE ETIQUETA"

    Sub Sb_Cambiar_Nombre_Etiqueta()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Semilla As String = _Fila.Cells("Semilla").Value
        Dim _NombreEtiqueta As String = _Fila.Cells("NombreEtiqueta").Value
        Dim _Aceptado As Boolean
        Dim _NuevoNombre As String = _NombreEtiqueta

        _Aceptado = InputBox_Bk(Me, "Ingrese el nuevo nombre de la etiqueta",
                                                 "Cambiar nombre de etiqueta", _NuevoNombre,
                                                 False, _Tipo_Mayus_Minus.Normal, , True, _Tipo_Imagen.Barra)

        If _Aceptado Then

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Tbl_DisenoBarras",
                                        "Semilla <> " & _Semilla & " And NombreEtiqueta = '" & _NuevoNombre & "'"))

            If _Reg Then
                Beep()
                ToastNotification.Show(Me, "ESE NOMBRE DE ETIQUETA YA EXISTE",
                                      My.Resources.cross,
                                     2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Else
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Set NombreEtiqueta = '" & _NuevoNombre & "' Where Semilla = " & _Semilla
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    _Fila.Cells("NombreEtiqueta").Value = _NuevoNombre
                    Beep()
                    ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE",
                                          My.Resources.ok_button,
                                         1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If
            End If
        End If

    End Sub

#End Region

#Region "ELIMINAR ETIQUETA"

    Sub Sb_Eliminar_Etiqueta()

        Dim _Semilla As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Semilla").Value
        Dim _NombreEtiqueta As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreEtiqueta").Value

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta etiqueta?" & vbCrLf & vbCrLf & _
                             "ETIQUETA: " & _NombreEtiqueta, "Eliminar etiqueta", _
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Where Semilla = " & _Semilla
            If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            End If
        End If
    End Sub


#End Region

#Region "ACTUALIZAR GRILLA"

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Tbl_DisenoBarras"

        Try


            With Grilla

                .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

                OcultarEncabezadoGrilla(Grilla)

                .Columns("Semilla").Width = 40
                .Columns("Semilla").HeaderText = "ID"
                .Columns("Semilla").Visible = True

                .Columns("NombreEtiqueta").Width = 420 - 40
                .Columns("NombreEtiqueta").HeaderText = "Nombre etiqueta"
                .Columns("NombreEtiqueta").Visible = True

                .Columns("CantPorLinea").Width = 60
                .Columns("CantPorLinea").HeaderText = "Etiquetas"
                .Columns("CantPorLinea").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("CantPorLinea").Visible = True

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "CLIC DERECHO EN GRILLA"
    Sub Sb_Grilla_Mouse_Clic_Boton_derecho_Grilla(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        'Menu_Contextual.Enabled = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Grilla.ContextMenuStrip = ContextMenuStrip1
                Else
                    Grilla.ContextMenuStrip = Nothing
                End If
            End With
        End If

    End Sub
#End Region

#End Region


End Class
