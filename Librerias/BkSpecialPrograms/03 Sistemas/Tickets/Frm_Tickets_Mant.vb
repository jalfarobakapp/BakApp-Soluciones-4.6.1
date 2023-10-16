Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Mant

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ticket As Integer
    Dim _Row_Ticket As DataRow

    Public Sub New(_Id_Ticket As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Ticket = _Id_Ticket

        Consulta_sql = "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario_Crea" & vbCrLf &
                       "Where Id = " & _Id_Ticket
        _Row_Ticket = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Tickets_Mant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Arr_Tipo_Entidad(,) As String = {{"", ""},
                                             {"AL", "Alta"},
                                             {"NR", "Normal"},
                                             {"BJ", "Baja"},
                                             {"UR", "Urgente"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Prioridad)
        Cmb_Prioridad.SelectedValue = ""

        If Not IsNothing(_Row_Ticket) Then

            Txt_CodFuncionario_Crea.Tag = _Row_Ticket.Item("CodFuncionario_Crea")
            Txt_CodFuncionario_Crea.Text = _Row_Ticket.Item("NOKOFU")
            Txt_Asunto.Text = _Row_Ticket.Item("Asunto")
            Cmb_Prioridad.SelectedValue = _Row_Ticket.Item("Prioridad")
            Txt_Area.Tag = _Row_Ticket.Item("Id_Area")
            Txt_Area.Text = _Row_Ticket.Item("Area")
            Txt_Tipo.Tag = _Row_Ticket.Item("Id_Tipo")
            Txt_Tipo.Text = _Row_Ticket.Item("Tipo")
            Txt_Descripcion.Text = _Row_Ticket.Item("Descripcion")
            Chk_Asignar.Checked = _Row_Ticket.Item("Asignar")
            Txt_Agente.Tag = _Row_Ticket.Item("CodAgente")
            Txt_Agente.Text = _Row_Ticket.Item("NomAgente")
            Txt_Grupo.Tag = _Row_Ticket.Item("Id_Grupo")
            Txt_Grupo.Text = _Row_Ticket.Item("Grupo")

        Else

            Txt_CodFuncionario_Crea.Text = Nombre_funcionario_activo.Trim

        End If

        Me.ActiveControl = Txt_Asunto

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If IsNothing(_Row_Ticket) Then

            Dim _Numero As String = Fx_NvoNro_OT()

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets (Numero,Estado,Asunto,Descripcion,FechaCreacion) Values " &
                           "('" & _Numero & "','ING','" & Txt_Asunto.Text.Trim & "','" & Txt_Descripcion.Text & "',Getdate())"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Ticket)

        End If

        Dim _Asignado As Integer = Convert.ToInt32(Chk_Asignar.Checked)
        Dim _AsignadoGrupo As Integer
        Dim _AsignadoFuncionario As Integer

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set " & vbCrLf &
                       "Id_Area = " & Txt_Area.Tag &
                       ",Id_Tipo = " & Txt_Tipo.Tag &
                       ",Prioridad = ''" &
                       ",CodFuncionario_Crea = '" & FUNCIONARIO & "'" &
                       ",Asunto = '" & Txt_Asunto.Text & "'" &
                       ",Descripcion = '" & Txt_Descripcion.Text & "'" &
                       ",Asignado = " & _Asignado &
                       ",AsignadoGrupo = " & _AsignadoGrupo &
                       ",Id_Grupo = 0" &
                       ",AsignadoFuncionario = " & _AsignadoFuncionario &
                       ",CodAgente = '" & Txt_Agente.Tag & "'" & vbCrLf &
                       "Where Id = " & _Id_Ticket
        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Private Sub Txt_Area_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Area.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Areas"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Area"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "AREA/DEPARTAMENTO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "", False, False, True, False,, False) Then

            Txt_Area.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Area.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            Txt_Tipo.Tag = 0
            Txt_Tipo.Text = String.Empty

            Call Txt_Tipo_ButtonCustomClick(Nothing, Nothing)

        End If

    End Sub

    Private Sub Txt_Tipo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Tipo.ButtonCustomClick

        If String.IsNullOrEmpty(Txt_Area.Text) Then
            MessageBoxEx.Show(Me, "Falta el Area/Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Tipos"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Tipo"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPO DE REQUERIMIENTO DEL AREA: " & Txt_Area.Text

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Id In (Select Id_Tipo From " & _Global_BaseBk & "Zw_Stk_AreaVsTipo Where Id_Area = " & Txt_Area.Tag & ")",
                               False, False, True, False,, False) Then

            Txt_Tipo.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Tipo.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

        End If

    End Sub

    Private Sub Txt_Area_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Area.ButtonCustom2Click

    End Sub

    Private Sub Txt_Tipo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Tipo.ButtonCustom2Click

    End Sub

    Function Fx_NvoNro_OT() As String

        Dim _NvoNro_OT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Numero) As Numero From " & _Global_BaseBk & "Zw_Stk_Tickets")

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

            If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
                _Ult_Nro_OT = 1
            Else
                _Ult_Nro_OT += 1
            End If
            _NvoNro_OT = numero_(Val(_Ult_Nro_OT), 10)
        Else
            _NvoNro_OT = numero_(1, 10)
        End If

        Return _NvoNro_OT

    End Function
End Class
