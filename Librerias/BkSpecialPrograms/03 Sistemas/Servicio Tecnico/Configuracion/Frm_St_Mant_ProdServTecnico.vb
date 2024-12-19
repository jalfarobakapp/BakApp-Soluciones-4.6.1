Imports DevComponents
Imports DevComponents.DotNetBar

Public Class Frm_St_Mant_ProdServTecnico

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblProdIngreso As DataTable
    Dim _TblProdServicio As DataTable

    Public Property Grabar As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_St_Mant_ProdServTecnico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                       "Where Informe = 'ServicioTecnico' And Filtro = 'ProdIngreso'"
        _TblProdIngreso = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                       "Where Informe = 'ServicioTecnico' And Filtro = 'ProdServicio'"
        _TblProdServicio = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_ActualizarCantidades()

    End Sub

    Private Sub Btn_SelProdIngreso_Click(sender As Object, e As EventArgs) Handles Btn_SelProdIngreso.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblProdIngreso,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra, False, False,, True) Then

            _TblProdIngreso = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                _TblProdIngreso = Nothing
            End If

        End If

        Sb_ActualizarCantidades()

    End Sub

    Private Sub Btn_SelProdServicio_Click(sender As Object, e As EventArgs) Handles Btn_SelProdServicio.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'SSN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblProdServicio,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False,, True) Then

            _TblProdServicio = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                _TblProdServicio = Nothing
            End If

        End If

        Sb_ActualizarCantidades()

    End Sub

    Sub Sb_ActualizarCantidades()

        Dim _Reg_ProdIngreso As Integer
        Dim _Reg_ProdServicio As Integer

        If Not IsNothing(_TblProdIngreso) Then _Reg_ProdIngreso = _TblProdIngreso.Rows.Count
        If Not IsNothing(_TblProdServicio) Then _Reg_ProdServicio = _TblProdServicio.Rows.Count

        Lbl_SelProdIngreso.Text = "PRODUCTOS ASOCIADOS A INGRESO A TALLER... (Asignados: " & FormatNumber(_Reg_ProdIngreso, 0) & ")"
        Lbl_SelProdServicio.Text = "PRODUCTOS ASOCIADOS A SERVICIOS DE REPARACION... (Asignados: " & FormatNumber(_Reg_ProdServicio, 0) & ")"

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If IsNothing(_TblProdIngreso) Then
            Consulta_sql = "Delete From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '' And Informe = 'ServicioTecnico'" & Space(1) &
                           "And Filtro = 'ProdIngreso' And NombreEquipo = '' And Modalidad = ''"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        Else
            _Sql.Sb_Actualizar_Filtro_Tmp(_TblProdIngreso, "ServicioTecnico", "ProdIngreso", "", "", "")
        End If

        If IsNothing(_TblProdIngreso) Then
            Consulta_sql = "Delete From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '' And Informe = 'ServicioTecnico'" & Space(1) &
                           "And Filtro = 'ProdServicio' And NombreEquipo = '' And Modalidad = ''"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        Else
            _Sql.Sb_Actualizar_Filtro_Tmp(_TblProdServicio, "ServicioTecnico", "ProdServicio", "", "", "")
        End If

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Grabar = True

        Me.Close()

    End Sub

    Private Sub Frm_St_Mant_ProdServTecnico_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
