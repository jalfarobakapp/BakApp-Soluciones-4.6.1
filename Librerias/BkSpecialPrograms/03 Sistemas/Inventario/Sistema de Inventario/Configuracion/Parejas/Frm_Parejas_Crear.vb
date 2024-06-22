Imports DevComponents.DotNetBar

Public Class Frm_Parejas_Crear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer
    Dim _Id_Pareja As Integer
    Dim _Row_Pareja As DataRow
    Dim _Grabar As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(_Id_Inventario As Integer, _Id_Pareja As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Pareja = _Id_Pareja
        Me._Id_Inventario = _Id_Inventario

        Consulta_sql = "Select Prj.*,Isnull(Op1.Nombre,'') As NombreOp1,Isnull(Op2.Nombre,'') As NombreOp2 From " & _Global_BaseBk & "Zw_Inv_Parejas Prj" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Inv_Operadores Op1 On Prj.Id_Operador1 = Op1.Id_Operador" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Inv_Operadores Op2 On Prj.Id_Operador2 = Op2.Id_Operador" & vbCrLf &
                        "Where Id_Pareja = " & _Id_Pareja
        _Row_Pareja = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Parejas_Crear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(_Row_Pareja) Then

            Txt_Nombre_Pareja.Text = _Row_Pareja.Item("Nombre_Pareja")
            Txt_Operario1.Tag = _Row_Pareja.Item("Id_Operador1")
            Txt_Operario1.Text = _Row_Pareja.Item("NombreOp1")
            Txt_Operario2.Tag = _Row_Pareja.Item("Id_Operador2")
            Txt_Operario2.Text = _Row_Pareja.Item("NombreOp2")

            Txt_Capturador.Tag = _Row_Pareja.Item("Id_Estacion")
            Txt_Capturador.Text = _Row_Pareja.Item("NombreEquipo")

            Btn_Agregar_Operador1.Enabled = Not CBool(Txt_Operario1.Tag)
            Btn_Quitar_Operador1.Enabled = CBool(Txt_Operario1.Tag)

            Btn_Agregar_Operador2.Enabled = Not CBool(Txt_Operario2.Tag)
            Btn_Quitar_Operador2.Enabled = CBool(Txt_Operario2.Tag)

            Btn_Agregar_Capturador.Enabled = Not CBool(Txt_Capturador.Tag)
            Btn_Quitar_Capturador.Enabled = CBool(Txt_Capturador.Tag)

        Else

            Btn_Quitar_Operador1.Enabled = False
            Btn_Quitar_Operador2.Enabled = False
            Btn_Eliminar.Visible = False

        End If

        ActiveControl = Txt_Nombre_Pareja

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Nombre_Pareja.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el nombre de la pareja", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Nombre_Pareja.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Operario1.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Operario 1", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Operario2.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Operario 2", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If IsNothing(_Row_Pareja) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Parejas (Id_Inventario,Nombre_Pareja,Id_Operador1,Id_Operador2,Habilitada) Values " &
                           "(" & _Id_Inventario & ",'" & Txt_Nombre_Pareja.Text.Trim & "'," & Txt_Operario1.Tag & "," & Txt_Operario2.Tag & ",1)"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Pareja)

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_Parejas Set " &
                       "Nombre_Pareja = '" & Txt_Nombre_Pareja.Text.Trim & "'" &
                       ",Id_Operador1 = '" & Txt_Operario1.Tag & "'" &
                       ",Id_Operador2 = '" & Txt_Operario2.Tag & "'" & vbCrLf &
                       ",Habilitada = '" & Convert.ToInt32(Sw_Habilitado.Value) & "'" & vbCrLf &
                       ",Id_Estacion = " & Txt_Capturador.Tag & vbCrLf &
                       ",NombreEquipo = '" & Txt_Capturador.Text.Trim & "'" & vbCrLf &
                       "Where Id_Pareja = " & _Id_Pareja
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            _Grabar = True
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Toma", "Id_Inventario = " & _Id_Inventario & " And Id_Pareja = " & _Id_Pareja)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar esta pareja ya que tiene movimiento en la toma de inventario" & vbCrLf &
                              "Si quiere deshacer esta pareja debe deshabilitarlos para que que los operadores puedan ser asignados a otra pareja", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Plan", "Id_Inventario = " & _Id_Inventario & " And Id_Pareja = " & _Id_Pareja)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar esta pareja ya que tiene ubicaciones asignadas" & vbCrLf &
                              "Quite el Plan de trabajo de esta pareja para que puedea eliminarla", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la pareja?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Parejas Where Id_Pareja = " & _Id_Pareja
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Pareja eliminada correctamente", "Elominar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Grabar = True
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Btn_Agregar_Operador1_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Operador1.Click
        Sb_Buscar_Operador(Txt_Operario1, Txt_Operario2.Tag)
        Btn_Agregar_Operador1.Enabled = Not CBool(Txt_Operario1.Tag)
        Btn_Quitar_Operador1.Enabled = CBool(Txt_Operario1.Tag)
    End Sub
    Private Sub Btn_Quitar_Operador1_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Operador1.Click
        Txt_Operario1.Tag = 0
        Txt_Operario1.Text = String.Empty
        Btn_Agregar_Operador1.Enabled = True
        Btn_Quitar_Operador1.Enabled = False
    End Sub

    Sub Sb_Buscar_Operador(Txt As Object, _Id_Operador_Hno As Integer)

        Consulta_sql = "Select Count(*) As Cuenta From " & _Global_BaseBk & "Zw_Inv_Operadores" & vbCrLf &
                       "Where Id_Inventario = " & _Id_Inventario & " And " &
                       "Id_Operador Not In (Select Id_Operador1 From " & _Global_BaseBk & "Zw_Inv_Parejas Where Id_Inventario = " & _Id_Inventario & ") And " &
                       "Id_Operador Not In (Select Id_Operador2 From " & _Global_BaseBk & "Zw_Inv_Parejas Where Id_Inventario = " & _Id_Inventario & ")"
        Dim _OpeDisponible As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not CBool(_OpeDisponible.Item("Cuenta")) Then

            If MessageBoxEx.Show(Me, "No existente operadores diponibles, todos estan en pareja" & vbCrLf &
                                 "¿Desea crear un operador?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim _Id_Operador As Integer
                Dim _Grabar As Boolean

                'Dim Fm As New Frm_CrearContador(_Id_Inventario, _Id_Operador)
                'Fm.ShowDialog(Me)
                '_Grabar = Fm.Grabar
                'Fm.Dispose()

                If Not _Grabar Then
                    Return
                End If

            End If

        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Inv_Operadores"
        _Filtrar.Campo = "Id_Operador"
        _Filtrar.Descripcion = "Nombre"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "OPERADORES DISPONIBLES"

        Dim _FiltroSql = "And Id_Inventario = " & _Id_Inventario & " And Habilitado = 1 And (" &
            "Id_Operador Not In (Select Id_Operador1 From " & _Global_BaseBk & "Zw_Inv_Parejas Where Id_Inventario = " & _Id_Inventario & ") And " &
            "Id_Operador Not In (Select Id_Operador2 From " & _Global_BaseBk & "Zw_Inv_Parejas Where Id_Inventario = " & _Id_Inventario & ")) And " &
            "Id_Operador <> " & _Id_Operador_Hno

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _FiltroSql,
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt.Tag = _Codigo
            Txt.Text = _Descripcion

        End If

    End Sub

    Private Sub Btn_Agregar_Operador2_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Operador2.Click
        Sb_Buscar_Operador(Txt_Operario2, Txt_Operario1.Tag)
        Btn_Agregar_Operador2.Enabled = Not CBool(Txt_Operario2.Tag)
        Btn_Quitar_Operador2.Enabled = CBool(Txt_Operario2.Tag)
    End Sub

    Private Sub Btn_Quitar_Operador2_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Operador2.Click
        Txt_Operario2.Tag = 0
        Txt_Operario2.Text = String.Empty
        Btn_Agregar_Operador2.Enabled = True
        Btn_Quitar_Operador2.Enabled = False
    End Sub

    Private Sub Btn_Crear_Operador_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Operador.Click
        'Dim Fm As New Frm_Contadores(_Id_Inventario)
        'Fm.ShowDialog(Me)
        'Fm.Dispose()
    End Sub

    Private Sub Btn_Ubicaciones_Plan_Click(sender As Object, e As EventArgs) Handles Btn_Ubicaciones_Plan.Click

        Dim Fm As New Frm_Parejas_Plan(_Id_Inventario, _Id_Pareja)
        Fm.Text = "Pareja: " & _Id_Pareja & " - " & Txt_Nombre_Pareja.Text.Trim & " (" & Txt_Operario1.Text.Trim & " Y " & Txt_Operario2.Text.Trim & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Agregar_Capturador_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Capturador.Click

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp",
                                            "TipoEstacion = 'B4A' And NombreEquipo Not In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Inv_Parejas " &
                                            "Where Id_Inventario = " & _Id_Inventario & ")")

        If Not CBool(_Reg) Then

            MessageBoxEx.Show(Me, "No hay capturadores disponibles", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_EstacionesBkp"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "NombreEquipo"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "CAPTURADORES DISPONIBLES"

        Dim _FiltroSql = "And TipoEstacion = 'B4A' And NombreEquipo Not In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Inv_Parejas " &
                                            "Where Id_Inventario = " & _Id_Inventario & ")"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _FiltroSql,
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Parejas Where Id_Inventario = " & _Id_Inventario & " And NombreEquipo = '" & _Descripcion & "'"
            Dim _Row_Pareja As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Pareja) Then

                MessageBoxEx.Show(Me, "Este dispositivo ya esta asignado a la pareja: " & _Row_Pareja.Item("Nombre_Pareja"),
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            Txt_Capturador.Tag = _Codigo
            Txt_Capturador.Text = _Descripcion

        End If

    End Sub

    Private Sub Btn_Quitar_Capturador_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Capturador.Click
        Txt_Capturador.Tag = 0
        Txt_Capturador.Text = String.Empty
        Btn_Agregar_Capturador.Enabled = True
        Btn_Quitar_Capturador.Enabled = False
    End Sub
End Class
