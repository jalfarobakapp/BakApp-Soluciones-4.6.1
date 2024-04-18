Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Fabricaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Mezcla As New Cl_Mezcla
    Dim _Tbl_Fabricaciones As DataTable
    Private _Id_Det As Integer

    Public Sub New(Id_Det As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Id_Det = Id_Det

        _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDet(_Id_Det)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_Fabricaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab" & vbCrLf &
                       "Where Id_Det = " & _Id_Det
        _Tbl_Fabricaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Fabricaciones

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 290
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Udad").Width = 30
            .Columns("Udad").HeaderText = "Udad"
            .Columns("Udad").Visible = True
            .Columns("Udad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantIngresada").Visible = True
            .Columns("CantIngresada").HeaderText = "Ingresado"
            .Columns("CantIngresada").Width = 60
            .Columns("CantIngresada").Visible = True
            .Columns("CantIngresada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantIngresada").DefaultCellStyle.Format = "###,###.##"
            .Columns("CantIngresada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantFabricada").Visible = True
            .Columns("CantFabricada").HeaderText = "Fabricado"
            .Columns("CantFabricada").Width = 60
            .Columns("CantFabricada").Visible = True
            .Columns("CantFabricada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantFabricada").DefaultCellStyle.Format = "###,###.##"
            .Columns("CantFabricada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaFabricacion").Width = 110
            .Columns("FechaFabricacion").HeaderText = "F.Fabricación"
            .Columns("FechaFabricacion").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            .Columns("FechaFabricacion").Visible = True
            .Columns("FechaFabricacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        'Consulta_sql = "Select Isnull(SUM(CantFabricada),0) As 'CantFabricada',Isnull(SUM(CantIngresada),0) As 'CantIngresada'" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab" & vbCrLf &
        '               "Where Id_Det = " & _Id_Det

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Where Id = " & _Id_Det
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_Fabricado.Text = FormatNumber(_Row.Item("CantFabricada"), 0)
        Lbl_Fabricar.Text = FormatNumber(_Row.Item("CantFabricar"), 0)

    End Sub

    Private Sub Btn_IngresarNuevaFabricacion_Click(sender As Object, e As EventArgs) Handles Btn_IngresarNuevaFabricacion.Click

        Dim _Aceptar As Boolean

        Dim _CantFabricada As Double

        _Aceptar = InputBox_Bk(Me, "Ingrese la cantidad fabricada, debe incluir solo solidos",
                               "Ingresar fabricación",
                               _CantFabricada, False, ,, True, _Tipo_Imagen.Product,, _Tipo_Caracter.Moneda, False)

        If Not _Aceptar Then
            Return
        End If

        Consulta_sql = "Select SUM(CANTIDAD) As Factor" & vbCrLf &
                       "From PNPD" & vbCrLf &
                       "Inner Join MAEPR On KOPR = ELEMENTO" & vbCrLf &
                       "Where CODIGO = '" & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codnomen & "'" & vbCrLf &
                       "And MRPR In ('06MAPVIT','06MAPLIQ')"
        Dim _Row_Facto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Factor As Double = _Row_Facto.Item("Factor")

        'Consulta_sql = "Select * From PNPD Where CODIGO = '" & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codnomen & "'"
        'Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Zw_Pdp_CPT_MzDetIngFab As New Zw_Pdp_CPT_MzDetIngFab

        With _Zw_Pdp_CPT_MzDetIngFab

            .Id_Det = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id
            .Id_Enc = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id_Enc
            .Codigo = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codigo
            .Descripcion = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Descripcion
            .Udad = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Udad
            .CantIngresada = _CantFabricada
            .CantFabricada = _CantFabricada + _Factor
            .CodFuncionario = FUNCIONARIO
            .FechaFabricacion = FechaDelServidor()

        End With

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Ingresar_Fabricaciones(_Zw_Pdp_CPT_MzDetIngFab)

        Dim _Icon As MessageBoxIcon

        If _Mensaje.EsCorrecto Then
            _Icon = MessageBoxIcon.Information
        Else
            _Icon = MessageBoxIcon.Error
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Icon)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDetIngFab(_Id)

        Dim _Aceptar As Boolean

        Consulta_sql = "Select SUM(CANTIDAD) As Factor" & vbCrLf &
                       "From PNPD" & vbCrLf &
                       "Inner Join MAEPR On KOPR = ELEMENTO" & vbCrLf &
                       "Where CODIGO = '" & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codnomen & "'" & vbCrLf &
                       "And MRPR In ('06MAPVIT','06MAPLIQ')"
        Dim _Row_Facto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Factor As Double = _Row_Facto.Item("Factor")

        With _Cl_Mezcla.Zw_Pdp_CPT_MzDetIngFab

            _Aceptar = InputBox_Bk(Me, "Ingrese la cantidad fabricada, debe incluir solo solidos",
                               "Ingresar fabricación",
                               .CantIngresada, False, ,, True, _Tipo_Imagen.Product,, _Tipo_Caracter.Moneda, False)

            If Not _Aceptar Then
                Return
            End If

            .CantFabricada = .CantIngresada + _Factor
            .CodFuncionario = FUNCIONARIO

        End With

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Editar_Fabricaciones(_Cl_Mezcla.Zw_Pdp_CPT_MzDetIngFab)

        Dim _Icon As MessageBoxIcon

        If _Mensaje.EsCorrecto Then
            _Icon = MessageBoxIcon.Information
        Else
            _Icon = MessageBoxIcon.Error
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Icon)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de esta fabricación?", "Eliminar fabricación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDetIngFab(_Id)

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Eliminar_Fabricaciones(_Cl_Mezcla.Zw_Pdp_CPT_MzDetIngFab)

        Dim _Icon As MessageBoxIcon

        If _Mensaje.EsCorrecto Then
            _Icon = MessageBoxIcon.Information
        Else
            _Icon = MessageBoxIcon.Error
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Icon)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Delete Then
            Call Btn_Eliminar_Click(Nothing, Nothing)
        End If
    End Sub
End Class
