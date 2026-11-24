Imports DevComponents.DotNetBar
Public Class Frm_Despacho_DespCm

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Despacho_DespCm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Comunas.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        Consulta_Sql = $"
Select Empresa, Sucursal,Ts.NOKOSU As SucursalStr,Pais,Ciudad,Ci.NOKOCI As 'CiudadStr',Comuna,Cm.NOKOCM As 'ComunaStr',
CodDespacho,Mp.NOKOPR As 'Descripcion'
From {_Global_BaseBk}Zw_Despachos_DespCm DCm
    Inner Join TABSU Ts On Ts.EMPRESA = DCm.Empresa And Ts.KOSU = DCm.Sucursal
        Inner Join TABCI Ci On Ci.KOPA = DCm.Pais And Ci.KOCI = DCm.Ciudad
            Inner Join TABCM Cm On Cm.KOPA = DCm.Pais And Cm.KOCI = DCm.Ciudad And Cm.KOCM = DCm.Comuna
                Inner Join MAEPR Mp On Mp.KOPR = DCm.CodDespacho
Where DCm.Empresa = '{Mod_Empresa}' And DCm.Sucursal = '{Mod_Sucursal}'
Order By DCm.Pais,DCm.Ciudad,DCm.Comuna,DCm.CodDespacho
"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Comunas

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Comunas, True)

            .Columns("CiudadStr").Width = 180
            .Columns("CiudadStr").HeaderText = "Ciudad destino"
            .Columns("CiudadStr").Visible = True
            .Columns("CiudadStr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComunaStr").Width = 170
            .Columns("ComunaStr").HeaderText = "Comuna destino"
            .Columns("ComunaStr").Visible = True
            .Columns("ComunaStr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodDespacho").Width = 100
            .Columns("CodDespacho").HeaderText = "Código"
            .Columns("CodDespacho").Visible = True
            .Columns("CodDespacho").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 270
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_AgregarComuna_Click(sender As Object, e As EventArgs) Handles Btn_AgregarComuna.Click

        If Not Fx_Tiene_Permiso(Me, "ODp00020") Then
            Return
        End If

        Dim _CodPais As String
        Dim _CodCiudad As String
        Dim _CodComuna As String

        Dim _Pais As String
        Dim _Ciudad As String
        Dim _Comuna As String

        Dim _Row_Localidad As DataRow

        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)
        _Row_Localidad = Fm.Row_Localidad
        Fm.Dispose()

        If IsNothing(_Row_Localidad) Then
            Return
        End If

        'MessageBoxEx.Show(Me, "A continuación debe seleccionar el producto de tipo servicio de despacho", "Servicio de despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)

        _CodPais = Fm.Row_Localidad.Item("KOPA")
        _CodCiudad = Fm.Row_Localidad.Item("KOCI")
        _CodComuna = Fm.Row_Localidad.Item("KOCM")

        _Pais = Fm.Row_Localidad.Item("NOKOPA")
        _Ciudad = Fm.Row_Localidad.Item("NOKOCI")
        _Comuna = Fm.Row_Localidad.Item("NOKOCM")


        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Sql_Filtro_Condicion_Extra As String = "And CLALIBPR = 'DESPACHOS'"
        Dim _Row_Producto As DataRow

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            _Row_Producto = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Consulta_Sql = $"
Insert Into {_Global_BaseBk}Zw_Despachos_DespCm (Empresa, Sucursal, Pais, Ciudad, Comuna, CodDespacho) Values 
('{Mod_Empresa}','{Mod_Sucursal}','{_CodPais}','{_CodCiudad}','{_CodComuna}','{_Row_Producto.Item("Codigo")}')"
            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Sb_Actualizar_Grilla()
            End If

        End If


    End Sub

    Private Sub Btn_Mnu_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Editar.Click

        If Not Fx_Tiene_Permiso(Me, "ODp00021") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Comunas.CurrentRow

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _CodPais As String = _Fila.Cells("CodPais").Value
        Dim _CodCiudad As String = _Fila.Cells("CodCiudad").Value
        Dim _CodComuna As String = _Fila.Cells("CodComuna").Value
        Dim _CodDespacho As String = _Fila.Cells("CodDespacho").Value

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Sql_Filtro_Condicion_Extra As String = $"And CLALIBPR = 'DESPACHOS' And KOPR <> '{_CodDespacho}'"
        Dim _Row_Producto As DataRow

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            _Row_Producto = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _NewCodDespacho As String = _Row_Producto.Item("Codigo")
            Dim _Descipcion As String = _Row_Producto.Item("Descripcion")

            If _CodDespacho = _NewCodDespacho Then
                MessageBoxEx.Show(Me, "Este producto ya esta asociado a esta comuna", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_Sql = $"
Update {_Global_BaseBk}Zw_Despachos_DespCm
Set 
CodDespacho = '{_NewCodDespacho}'
Where Id = {_Id}"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                _Fila.Cells("CodDespcho").Value = _NewCodDespacho
                _Fila.Cells("Descripcion").Value = _Descipcion

                MessageBoxEx.Show(Me, "Código de despacho actualizado correctamente", "Cambiar código",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "ODp00022") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Comunas.CurrentRow

        If _Fila Is Nothing Then
            Return
        End If

        Dim _FilaDatos As DataRowView = TryCast(_Fila.DataBoundItem, DataRowView)
        Dim _Id As Integer = Convert.ToInt32(_Fila.Cells("Id").Value)

        If MessageBoxEx.Show(Me, "¿Confirma?", "Eliminar registro",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_Sql = $"Delete From {_Global_BaseBk}Zw_Despachos_DespCm Where Id = {_Id}"

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            If _FilaDatos IsNot Nothing Then
                _FilaDatos.Delete()
            End If

            MessageBoxEx.Show(Me, "Registro eliminado correctamente", "Eliminar registro",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla_Comunas.CurrentRow

                    ShowContextMenu(Menu_Contextual_01)

                End If

            End With

        End If

    End Sub

End Class
