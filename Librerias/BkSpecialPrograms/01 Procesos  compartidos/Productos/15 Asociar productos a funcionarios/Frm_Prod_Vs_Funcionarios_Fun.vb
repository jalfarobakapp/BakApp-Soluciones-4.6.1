Imports DevComponents.DotNetBar
Public Class Frm_Prod_Vs_Funcionarios_Fun

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Funcionarios As DataTable
    Dim _Dv As New DataView

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Prod_Vs_Funcionarios_Fun_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select KOFU,NOKOFU," &
                       "(Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Usuario_Validador " &
                       "Where Empresa = '" & ModEmpresa & "' And CodFuncionario = KOFU) As Prod_Asignados," & vbCrLf &
                       "Cast((Select Count(*) From " & _Global_BaseBk & "ZW_PermisosVsUsuarios " &
                       "Where CodUsuario = KOFU And CodPermiso = 'Comp0095') As Bit) As Tiene_Permiso" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Where INACTIVO = 0" & vbCrLf &
                       "Order By KOFU"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Tbl_Funcionarios = _Ds.Tables("Table")
        _Dv.Table = _Tbl_Funcionarios

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Tiene_Permiso").Width = 20
            .Columns("Tiene_Permiso").HeaderText = "TP"
            .Columns("Tiene_Permiso").ToolTipText = "¿Tiene permiso para porder autorizar compras de productos?"
            .Columns("Tiene_Permiso").Visible = True
            .Columns("Tiene_Permiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFU").Width = 50
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").Visible = True
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Width = 230
            .Columns("NOKOFU").HeaderText = "Nombre funcionario"
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Prod_Asignados").Width = 90
            .Columns("Prod_Asignados").HeaderText = "Prod.Asignados"
            .Columns("Prod_Asignados").Visible = True
            .Columns("Prod_Asignados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Prod_Asignados").DefaultCellStyle.Format = "###,###.##"
            .Columns("Prod_Asignados").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Consulta_Sql = "Select Codigo AS CodigoProducto,C.NOKOPR as DescripcionProducto,CodFuncionario as CodigoValidador," &
                       "F.NOKOFU as NombreValidador,Empresa as CodigoEmpresa,RAZON as NombreEmpresa 
                        From " & _Global_BaseBk & "Zw_Prod_Usuario_Validador AS U 
                        Inner Join MAEPR AS C ON U.Codigo=C.KOPR
                        Inner Join TABFU AS F ON U.CodFuncionario =F.KOFU
                        Inner Join CONFIGP AS E ON U.Empresa =E.EMPRESA"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Funcionarios")
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Codpermiso = "Comp0095"

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _CodFuncionario = _Fila.Cells("KOFU").Value

        Dim Fm As New Frm_Prod_Vs_Funcionarios(_CodFuncionario)
        Fm.ShowDialog(Me)
        _Fila.Cells("Prod_Asignados").Value = Fm.Tbl_Productos.Rows.Count

        Consulta_Sql = "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodUsuario = '" & _CodFuncionario & "' And CodPermiso = 'Comp0095'"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        If CBool(Fm.Tbl_Productos.Rows.Count) Then

            Dim _Llave As String = UCase("Comp0095" & "@" & _CodFuncionario.Trim)
            _Llave = Encripta_md5(_Llave)

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario, CodPermiso, Llave) VALUES " &
                           "('" & _CodFuncionario & "','Comp0095','" & _Llave & "')"
            _Sql.Ej_consulta_IDU(Consulta_Sql)

        End If

        _Fila.Cells("Tiene_Permiso").Value = CBool(Fm.Tbl_Productos.Rows.Count)

        Fm.Dispose()

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            _Dv.RowFilter = "KOFU+NOKOFU Like '%" & Txt_Descripcion.Text.Trim & "%'"
        End If
    End Sub
End Class
