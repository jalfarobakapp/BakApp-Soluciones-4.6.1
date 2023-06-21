Imports DevComponents.DotNetBar

Public Class Frm_St_Lista_Tecnicos_Talleres

    Dim _Cadena_de_conexion_SQL = Cadena_ConexionSQL_Server
    Dim _Sql As New Class_SQL(_Cadena_de_conexion_SQL)
    Dim Consulta_sql As String

    Dim _TblTecnicos As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Lista_Tecnicos_Talleres_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Txt_Informacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", _TblTecnicos, "Informacion", True))

    End Sub

#Region "PROCEDIMIENTO"

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select CodFuncionario,NomFuncionario,Direccion,Telefono,Email,Pais,Ciudad,Comuna,Star," &
                       "Chk_Taller_Externo,Chk_Habilitado,Chk_Supervisor,Chk_Domicilio,Informacion," & vbCrLf &
                       "Case Chk_Taller_Externo When 1 Then 'TALLER' Else 'TECNICO' End As 'Tipo'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "'"
        _TblTecnicos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _TblTecnicos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("NomFuncionario").Visible = True
            .Columns("NomFuncionario").HeaderText = "Nombre"
            .Columns("NomFuncionario").Width = 350
            .Columns("NomFuncionario").DisplayIndex = 0

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 100
            .Columns("Tipo").DisplayIndex = 1

            .Columns("Chk_Habilitado").Visible = True
            .Columns("Chk_Habilitado").HeaderText = "Habilitado"
            .Columns("Chk_Habilitado").Width = 100
            .Columns("Chk_Habilitado").DisplayIndex = 2
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

        Sb_Marcar_Grilla()

    End Sub

    Private Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Chk_Habilitado = _Fila.Cells("Chk_Habilitado").Value

            If _Chk_Habilitado Then
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            Else
                _Fila.DefaultCellStyle.ForeColor = Rojo
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

        Next

    End Sub

#End Region


    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _CodFuncionario = _Fila.Cells("CodFuncionario").Value

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & Space(1) &
                       "Where CodFuncionario = '" & _CodFuncionario & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim Fm As New Frm_St_Mant_Tecnicos_Talleres(Frm_St_Mant_Tecnicos_Talleres.Accion.Editar)
            Fm.Pro_Row_Tecnico = _Tbl.Rows(0)
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then

                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE",
                                       Fm.Btn_Grabar.Image,
                                       1 * 1000, eToastGlowColor.Green,
                                       eToastPosition.MiddleCenter)

                If Fm.Rdb_Chk_Taller_Externo.Checked Then
                    _Fila.Cells("Tipo").Value = "TALLER"
                Else
                    _Fila.Cells("Tipo").Value = "TECNICO"
                End If

                _Fila.Cells("NomFuncionario").Value = Fm.Txt_NomFuncionario.Text
                _Fila.Cells("Informacion").Value = Fm.Txt_Informacion.Text
                _Fila.Cells("Chk_Habilitado").Value = Fm.Chk_Habilitado.Checked

                _Fila.Cells("Chk_Taller_Externo").Value = Fm.Rdb_Chk_Taller_Externo.Checked
                _Fila.Cells("Chk_Supervisor").Value = Fm.Chk_Supervisor.Checked
                _Fila.Cells("Chk_Domicilio").Value = Fm.Chk_Domicilio.Checked

            End If

            If Fm.Pro_Eliminado Then

                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                Grilla.Refresh()

                Beep()
                ToastNotification.Show(Me, "REGISTRO ELIMINADO CORRECTAMENTE",
                                       Fm.Btn_Eliminar.Image,
                                       1 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
            End If

            Fm.Dispose()

            Sb_Marcar_Grilla()

        End If
        Grilla.EndEdit()
        Txt_Informacion.Refresh()
        Me.Refresh()

    End Sub

    Private Sub Btn_Crear_Tecnico_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Crear_Tecnico.Click

        If Fx_Tiene_Permiso(Me, "Stec0007") Then
            Dim Fm As New Frm_St_Mant_Tecnicos_Talleres(Frm_St_Mant_Tecnicos_Talleres.Accion.Nuevo)
            Fm.ShowDialog(Me)
            If Fm.Pro_Grabar Then
                Sb_Actualizar_Grilla()
            End If
            Fm.Dispose()
        End If

    End Sub

End Class
