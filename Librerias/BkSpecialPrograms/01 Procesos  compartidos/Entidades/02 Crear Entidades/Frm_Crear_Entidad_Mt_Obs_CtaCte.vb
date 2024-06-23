Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Crear_Entidad_Mt_Obs_CtaCte

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodEntidad As String
    Dim _SucEntidad As String

    Public Property Pro_CodEntidad As String
        Get
            Return _CodEntidad
        End Get
        Set(value As String)
            _CodEntidad = value
        End Set
    End Property
    Public Property Pro_SucEntidad As String
        Get
            Return _SucEntidad
        End Get
        Set(value As String)
            _SucEntidad = value
        End Set
    End Property

    Private Sub Btn_CrearObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CrearObservacion.Click

        Dim _Aceptado As Boolean
        Dim _Observacion As String

        _Aceptado = InputBox_Bk(Me, "Ingrese una observación",
                               "Observación", _Observacion, True, _Tipo_Mayus_Minus.Mayusculas, 100, True)

        If _Aceptado Then

            _Observacion = Replace(_Observacion, vbCrLf, " ")

            Dim _HoraGrab = Hora_Grab_fx(False)

            Consulta_Sql = "Insert Into MAEENOBS (KOEN,SUEN,KOFU,FECHA,HORAGRAB,POSIT) Values " & vbCrLf &
                           "('" & _CodEntidad & "','" & _SucEntidad & "','" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") &
                           "'," & _HoraGrab & ",'" & _Observacion & "')"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Beep()
                ToastNotification.Show(Me, "OBSERVACION INCORPORADA CORRECTAMENTE", Btn_CrearObservacion.Image,
                                      3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                Sb_Actualizar_Grilla()

            End If

        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select SEMILLA,KOFU,FECHA,convert(nvarchar, convert(datetime, (HORAGRAB*1.0/3600)/24), 108) AS HH,POSIT" & vbCrLf & _
                       "From MAEENOBS" & vbCrLf & _
                       "Where KOEN = '" & _CodEntidad & "' And SUEN = '" & _SucEntidad & "'" & vbCrLf & _
                       "Order by FECHA, HORAGRAB Desc"

        With Grilla

            Grilla.DataSource = _SQL.Fx_Get_DataTable(Consulta_sql)
            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").HeaderText = "Func"
            .Columns("KOFU").Width = 30
            .Columns("KOFU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("KOFU").Visible = True

            .Columns("FECHA").HeaderText = "Fecha"
            .Columns("FECHA").Width = 80
            .Columns("FECHA").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FECHA").Visible = True

            .Columns("HH").HeaderText = "Hora"
            .Columns("HH").Width = 80
            .Columns("HH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("HH").Visible = True

            .Columns("POSIT").HeaderText = "Comentarios"
            .Columns("POSIT").Width = 550
            .Columns("POSIT").Visible = True

        End With

    End Sub

    Private Sub Sb_Eliminar_Fila()

        Try

            Dim _Semilla As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("SEMILLA").Value
            Dim _CodFun As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOFU").Value

            If _CodFun = FUNCIONARIO Then

                If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar este comentario?", "Eliminar", _
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Delete MAEENOBS Where SEMILLA = " & _Semilla

                    If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                        Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                        ToastNotification.Show(Me, "COMENTARIO ELIMINADO", Btn_Eliminar_Fila.Image,
                                      3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                    End If

                End If

            Else
                Beep()
                ToastNotification.Show(Me, "NO PUEDE ELIMINAR COMENTARIOS DE OTROS USUARIOS", My.Resources.cross,
                                      3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Obs_CtaCte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
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

    Private Sub Btn_Eliminar_Fila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_Fila.Click
        Sb_Eliminar_Fila()
    End Sub
End Class
