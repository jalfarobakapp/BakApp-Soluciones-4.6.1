Imports DevComponents.DotNetBar

Public Class Zw_Inv_Sector_vs_Ubicaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer
    Dim _Codigo_Sector As String
    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String
    Dim _Row_Inventario As DataRow

    Public Sub New(_Id_Inventario As Integer, _Bodega As String, _Codigo_Sector As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Inventario = _Id_Inventario
        Me._Codigo_Sector = _Codigo_Sector

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Inventario Inv" & vbCrLf &
                       "Where Id_Inventario = " & _Id_Inventario
        _Row_Inventario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me._Empresa = _Row_Inventario.Item("Empresa")
        Me._Sucursal = _Row_Inventario.Item("Sucursal")
        Me._Bodega = _Bodega

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Zw_Inv_Sector_vs_Ubicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()
    End Sub


    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones" & vbCrLf &
                        "Where Codigo_Sector = '" & _Codigo_Sector & "' And Id_Inventario = '" & _Id_Inventario & "' " &
                        "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf &
                        "Order By Codigo_Ubic"
        Dim _Tbl_Inventarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Inventarios

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo_Ubic").Visible = True
            .Columns("Codigo_Ubic").HeaderText = "Ubicación"
            .Columns("Codigo_Ubic").Width = 280
            .Columns("Codigo_Ubic").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Ubicacion_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ubicacion.Click

        Dim _Aceptar As Boolean
        Dim _Codigo_Ubic As String

        _Aceptar = InputBox_Bk(Me, "Ingrese el código de la ubicación", "Crear ubicación", _Codigo_Ubic, False, _Tipo_Mayus_Minus.Normal, 20, True, _Tipo_Imagen.Ubicacion)

        If Not _Aceptar Then
            Return
        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones", "Id_Inventario = " & _Id_Inventario & " And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal &
                                            "' And Bodega = '" & _Bodega & "' And Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic = '" & _Codigo_Ubic & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Ubicación ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Crear_Ubicacion_Click(Nothing, Nothing)
            Return
        End If

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones (Id_Inventario,Empresa,Sucursal,Bodega,Codigo_Sector,Codigo_Ubic) Values " &
                       "(" & _Id_Inventario & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo_Sector & "','" & _Codigo_Ubic & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Sb_Actualizar_Grilla()
            If MessageBoxEx.Show(Me, "Ubicación creada correctamente" & vbCrLf & vbCrLf &
                                 "¿Desea ingresar otra ubicación?", "Crea ubicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Call Btn_Crear_Ubicacion_Click(Nothing, Nothing)
            End If
        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Aceptar As Boolean
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Codigo_Ubic As String = _Fila.Cells("Codigo_Ubic").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Plan",
                                             "Id_Inventario = " & _Id_Inventario & " And Empresa = '" & _Empresa & "' " &
                                             "And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' " &
                                             "And Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic = '" & _Codigo_Ubic & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede editar la ubiación ya que se encuentra dentro de un plan de trabajo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Editar_Click(Nothing, Nothing)
            Return
        End If

        _Aceptar = InputBox_Bk(Me, "Editar ubicación", "Crear ubicación", _Codigo_Ubic, False, _Tipo_Mayus_Minus.Normal, 20, True, _Tipo_Imagen.Ubicacion)

        If Not _Aceptar Then
            Return
        End If

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones", "Id <> " & _Id & " And Codigo_Ubic = '" & _Codigo_Ubic & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Ubicación ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Editar_Click(Nothing, Nothing)
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones Set Codigo_Ubic = '' Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            _Fila.Cells("Codigo_Ubic").Value = _Codigo_Ubic
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar ubicación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Codigo_Ubic As String = _Fila.Cells("Codigo_Ubic").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Plan",
                                             "Id_Inventario = " & _Id_Inventario & " And Empresa = '" & _Empresa & "' " &
                                             "And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' " &
                                             "And Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic = '" & _Codigo_Ubic & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar la ubiación ya que se encuentra dentro de un plan de trabajo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de esta ubicación?", "Eliminar ubicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Sector_vs_Ubicaciones Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Sb_Actualizar_Grilla()
            End If
        End If

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual)
                End If
            End With
        End If
    End Sub
End Class
