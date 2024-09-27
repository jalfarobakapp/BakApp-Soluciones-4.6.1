'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Anotaciones_Tabuladas_01_Encabezados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Enum Tipo_Apertura
        Mantencion_tabla
        Seleccion_tabla
    End Enum

    Enum Incorporacion_clasificaciones
        Linea_Activa
        Tickeadas
        Todas
    End Enum

    Public _TblDetalle As DataTable
    Public _Idmaeedo_ligado As Integer
    Public _Incorporacion As Incorporacion_clasificaciones
    Dim _Tipo_Apertura As Tipo_Apertura
    Public _Incorporar As Boolean

    Public Sub New(ByVal Apertura As Tipo_Apertura)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _Tipo_Apertura = Apertura
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            Btn_Mantencion_tablas.ForeColor = Color.White

        End If

    End Sub

    Private Sub Frm_Anotaciones_Tabuladas_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick

        If _Tipo_Apertura = Tipo_Apertura.Mantencion_tabla Then
            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
            Btn_Mantencion_tablas.Visible = False
        ElseIf _Tipo_Apertura = Tipo_Apertura.Seleccion_tabla Then
            Btn_Crear_Tabla.Visible = False
            Grilla.ContextMenuStrip = Nothing
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From TABCARAE"

        With Grilla

            .DataSource = _SQL.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOTABLA").HeaderText = "Tabla" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("KOTABLA").Width = 100
            .Columns("KOTABLA").Visible = True

            .Columns("NOKOTABLA").HeaderText = "Descripción" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("NOKOTABLA").Width = 340
            .Columns("NOKOTABLA").Visible = True

        End With

    End Sub

    Private Sub Btn_Crear_Tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Tabla.Click

        Dim Fm As New Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det(
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Tabla.Encabezado,
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Grabacion.Nuevo)

        Fm.Text = "CREAR NUEVA TABLA"
        Fm.ShowDialog(Me)
        If Fm._Grabar Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZAOS CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If
        Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub Btn_Editar_tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_tabla.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)


        Dim Fm As New Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det(
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Tabla.Encabezado,
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Grabacion.Editar,
                                                         _Fila.Cells("KOTABLA").Value,
                                                         _Fila.Cells("NOKOTABLA").Value)

        Fm.Text = "EDITAR TABLA"
        Fm.ShowDialog(Me)
        If Fm._Grabar Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZAOS CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            _Fila.Cells("NOKOTABLA").Value = Fm.Txt_Descripcion.Text

        End If
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Eliminar_tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_tabla.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Kotabla As String = _Fila.Cells("KOTABLA").Value

        ' Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABCARAC", "KOTABLA = '" & _Kotabla & "'"))

        ' If Not _Reg Then

        If MessageBoxEx.Show(Me, "¿Está seguro de querer eliminar esta tabla?" & vbCrLf &
                             "Se eliminaran todas sus dependencias también", "Eliminar Tabla",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "DELETE TABCARAE WHERE KOTABLA = '" & _Kotabla & "'" & vbCrLf &
                           "DELETE TABCARAC WHERE KOTABLA = '" & _Kotabla & "'" & vbCrLf

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Beep()
                ToastNotification.Show(Me, "TABLA ELIMINADA CORRECTAMENTE", My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            End If
            'End If
        End If


    End Sub


    Private Sub Btn_VerLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_VerLista.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Kotabla As String = _Fila.Cells("KOTABLA").Value

        Dim Fm As New Frm_Anotaciones_Tabuladas_02_Detalle(_Kotabla,
                                                           Frm_Anotaciones_Tabuladas_02_Detalle.Tipo_Apertura.Mantencion_tabla)
        Fm.Text = "Detalle de tabla " & _Kotabla
        Fm.ShowDialog(Me)

        Fm.Dispose()

    End Sub

    Private Sub Frm_Anotaciones_Tabuladas_01_Encabezados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)


        If _Tipo_Apertura = Tipo_Apertura.Mantencion_tabla Then

            ShowContextMenu(Menu_Contextual_01)

        ElseIf _Tipo_Apertura = Tipo_Apertura.Seleccion_tabla Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Kotabla As String = _Fila.Cells("KOTABLA").Value

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABCARAC", "KOTABLA = '" & _Kotabla & "' AND KOCARAC <> ''"))

            If _Reg Then

                'Me.WindowState = FormWindowState.Minimized
                Dim Fm As New Frm_Anotaciones_Tabuladas_02_Detalle(_Kotabla,
                         Frm_Anotaciones_Tabuladas_02_Detalle.Tipo_Apertura.Seleccion_tabla)

                Fm.Text = "Seleccione una clasificación de la de tabla " & _Kotabla
                Fm.ShowDialog(Me)
                'Me.WindowState = FormWindowState.Normal

                If Fm._Incorporar Then
                    _Incorporacion = Fm._Incorporacion
                    _TblDetalle = Fm._TblDetalle
                    _Incorporar = True
                    _Idmaeedo_ligado = Fm._Idmaeedo_ligado
                    Me.Close()
                End If

                Fm.Dispose()
            Else
                Beep()
                ToastNotification.Show(Me, "NO POSEE ELEMENTOS", My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If

        End If


    End Sub

    Private Sub Btn_Mantencion_tablas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mantencion_tablas.Click

        If Fx_Tiene_Permiso(Me, "Tbl00023") Then
            Dim Fm As New Frm_Anotaciones_Tabuladas_01_Encabezados(
                Frm_Anotaciones_Tabuladas_01_Encabezados.Tipo_Apertura.Mantencion_tabla)
            Fm.Text = "Tabla de caracterizaciones, Mantención de tablas"
            Fm.ShowDialog(Me)
            Sb_Actualizar_Grilla()
            Fm.Dispose()
        End If

    End Sub
End Class
