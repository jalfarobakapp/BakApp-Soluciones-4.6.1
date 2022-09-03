Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_Permisos_Usuario_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Tbl_Solo_Estos_Funcionario As DataTable
    Dim _Filtro_Solo_Estos_Funcionario As String

    Public Property Pro_Tbl_Solo_Estos_Funcionarios() As DataTable
        Get
            Return _Tbl_Solo_Estos_Funcionario
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Solo_Estos_Funcionario = value

            If CBool(_Tbl_Solo_Estos_Funcionario.Rows.Count) Then
                _Filtro_Solo_Estos_Funcionario = "And KOFU In " & Generar_Filtro_IN(_Tbl_Solo_Estos_Funcionario, "", "Codigo", False, False, "'")
            End If

        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Permisos_Usuario_Lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Consulta_sql = "Delete " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Lp'" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "ZW_Permisos " &
                       "(CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso)" & vbCrLf &
                       "--SELECT Case TILT WHEN 'C' Then 'Lc-'+KOLT Else 'Lp-'+KOLT End As CodPermiso," & vbCrLf &
                       "SELECT 'Lp-'+KOLT As CodPermiso," & vbCrLf &
                       "NOKOLT as DescripcionPermiso,'Lp','Listas de precios'" & vbCrLf &
                       "FROM TABPP"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Delete " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega'" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "ZW_Permisos " &
                       "(CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso)" & vbCrLf &
                       "SELECT 'Bo'+EMPRESA+KOSU+KOBO,'BODEGA: '+NOKOBO,'Bodega','Bodegas'" & vbCrLf &
                       "FROM TABBO"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Sb_Actualizar_Grilla()

        AddHandler Chk_Solo_Activos.CheckedChanged, AddressOf Chk_Solo_Activos_CheckedChanged

        Me.ActiveControl = Txtdescripcion

        If String.IsNullOrEmpty(_Filtro_Solo_Estos_Funcionario) Then

            AddHandler Grilla.CellDoubleClick, AddressOf Sb_Revisar_Permiso_Usuario
            AddHandler Btn_Ver_Permisos_de_usuarios_activo.Click, AddressOf Sb_Revisar_Permiso_Usuario
            Grupo_Funcionarios.Text = "Seleccione la entidad con doble clic o enter sobre la línea"

        Else

            Grupo_Funcionarios.Text = "Funcionarios encontrados"
            Btn_Ver_Permisos_de_usuarios_activo.Visible = False

        End If

        Dim _Mod As New Clas_Modalidades
        _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion", "Solo_Supervisores_Dan_Permisos") Then

            Rdb_Solo_Supervisores_Dan_Permisos.Checked = _Global_Row_Configuracion_General.Item("Solo_Supervisores_Dan_Permisos")

            'Else

            '    Rdb_Solo_Supervisores_Dan_Permisos.Enabled = False
            '    Rdb_Todos_Pueden_Dar_Permisos.Enabled = False

        End If

        AddHandler Rdb_Solo_Supervisores_Dan_Permisos.CheckedChanged, AddressOf Rdb_Solo_Supervisores_Dan_Permisos_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim cadena As String = CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text), "KOFU+NOKOFU" & " LIKE '%")

        Dim _Filtro_Inactivos = String.Empty

        If Chk_Solo_Activos.Checked Then
            _Filtro_Inactivos = "And INACTIVO = 0"
        End If

        Consulta_sql = "SELECT *,Isnull(Llave,'') As Llave,Case When Llave Is null Then 'Usuario' Else 'Supervisor' End As Supervisor FROM TABFU" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "ZW_PermisosVsUsuarios On CodUsuario = KOFU And CodPermiso = 'Admin001'" & vbCrLf &
                       "WHERE KOFU+NOKOFU LIKE '%" & cadena & "%'" & vbCrLf & _Filtro_Inactivos & vbCrLf & _Filtro_Solo_Estos_Funcionario

        With Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").Width = 60
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").Visible = True

            .Columns("NOKOFU").Width = 300
            .Columns("NOKOFU").HeaderText = "Nombre usuario"
            .Columns("NOKOFU").Visible = True

            .Columns("Supervisor").Width = 100
            .Columns("Supervisor").HeaderText = "Tipo usuario"
            .Columns("Supervisor").Visible = True

            For Each _Fila As DataGridViewRow In .Rows

                If _Fila.Cells("INACTIVO").Value Then
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                End If

                If _Fila.Cells("Supervisor").Value = "Supervisor" Then
                    _Fila.DefaultCellStyle.BackColor = Color.LightGreen
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                End If

            Next

        End With

    End Sub

    Sub Sb_Actualizar_Grilla2()

        Dim cadena As String = CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text), "KOFU+NOKOFU" & " LIKE '%")

        Dim _Filtro_Inactivos = String.Empty

        If Chk_Solo_Activos.Checked Then
            _Filtro_Inactivos = "And INACTIVO = 0"
        End If

        Consulta_sql = "Select * From TABFU
                        Inner Join " & _Global_BaseBk & "Zw_Usuarios On CodFuncionario = KOFU
                        Where KOFU+NOKOFU LIKE '%" & cadena & "%'" & vbCrLf & _Filtro_Inactivos & vbCrLf & _Filtro_Solo_Estos_Funcionario

        With Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").Width = 60
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").Visible = True

            .Columns("NOKOFU").Width = 340
            .Columns("NOKOFU").HeaderText = "Nombre usuario"
            .Columns("NOKOFU").Visible = True

            .Columns("Es_Supervisor").Width = 340
            .Columns("Es_Supervisor").HeaderText = "Supervisor"
            .Columns("Es_Supervisor").Visible = True

            .Columns("Es_Administrador").Width = 340
            .Columns("Es_Administrador").HeaderText = "Administrador"
            .Columns("Es_Administrador").Visible = True

            For Each _Fila As DataGridViewRow In .Rows

                If _Fila.Cells("INACTIVO").Value Then
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next

        End With

    End Sub

    Sub Sb_Revisar_Permiso_Usuario()

        Try

            If Grilla.SelectedRows.Count Then

                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                Dim _Index = _Fila.Index

                Dim _CodUsuario As String = _Fila.Cells("KOFU").Value
                Dim _Nombre_Usuario As String = _Fila.Cells("NOKOFU").Value

                Dim Fm As New Frm_Permisos_Usuario_Permisos(_CodUsuario)
                Fm.Text = "Usuario: [" & _CodUsuario & "], " & _Nombre_Usuario
                Fm.ShowDialog(Me)

                Sb_Actualizar_Grilla()

                Grilla.Focus()
                Me.ActiveControl = Grilla
                Grilla.CurrentCell = Grilla.Rows(_Index).Cells("KOFU")

            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY USUARIOS SELECCIONADOS", My.Resources.cross,
                                  1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Frm_Permisos_Usuario_Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Chk_Solo_Activos_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grilla.Enter
        Btn_Ver_Permisos_de_usuarios_activo.Enabled = True
    End Sub

    Private Sub Txtdescripcion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.Enter
        Btn_Ver_Permisos_de_usuarios_activo.Enabled = False
    End Sub

    Private Sub Btn_Actualizar_Lista_Permisos_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Lista_Permisos.Click

        Me.Enabled = False
        Dim _Cl As New Class_Permiso_BakApp
        _Cl.Sb_Actualizar_Base_De_Permisos(Me, Lbl_Status)
        Me.Enabled = True

    End Sub

    Sub Sb_Actualizar_Todos_Los_Key_Permisos_X_Usuarios()

        Consulta_sql = "Select * 
                        From " & _Global_BaseBk & "ZW_PermisosVsUsuarios 
                        Where CodUsuario In (Select KOFU From TABFU)
                        Order by CodUsuario"

        Dim _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _CodUsuario As String = _Fila.Item("CodUsuario")
            Dim _CodPermiso As String = _Fila.Item("CodPermiso")
            Dim _Valor_Dscto As Double = _Fila.Item("Valor_Dscto")
            Dim _Valor_Max_Compra As Double = _Fila.Item("Valor_Max_Compra")

            Dim _Llave As String = UCase(_CodPermiso.Trim & "@" & _CodUsuario.Trim)
            _Llave = Encripta_md5(_Llave)

            System.Windows.Forms.Application.DoEvents()

            Lbl_Status.Text = "Usuario: " & _CodUsuario & " Asignado permiso: " & _CodPermiso

            Consulta_sql += "INSERT INTO " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario,CodPermiso,Llave,Valor_Dscto,Valor_Max_Compra) VALUES " &
                            "('" & _CodUsuario & "','" & _CodPermiso & "','" & _Llave &
                            "'," & De_Num_a_Tx_01(_Valor_Dscto, False, 5) & "," & De_Num_a_Tx_01(_Valor_Max_Compra, False, 5) & ")" & vbCrLf

        Next

        Consulta_sql = "Truncate Table " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf & vbCrLf & vbCrLf & Consulta_sql

        Lbl_Status.Text = "Actualizando permisos en la base de datos..."

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

        Lbl_Status.Text = String.Empty

    End Sub

    Private Sub Btn_Reparar_Permisos_Click(sender As Object, e As EventArgs) Handles Btn_Reparar_Permisos.Click

        Sb_Actualizar_Todos_Los_Key_Permisos_X_Usuarios()

    End Sub

    Private Sub Rdb_Solo_Supervisores_Dan_Permisos_CheckedChanged(sender As Object, e As EventArgs)

        Dim _Existe_Campo As Boolean = _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion", "Solo_Supervisores_Dan_Permisos")

        If Rdb_Solo_Supervisores_Dan_Permisos.Checked Then

            If Not _Existe_Campo Then

                MessageBoxEx.Show(Me, "Falta el campo [Solo_Supervisores_Dan_Permisos] en la tabla [Zw_Configuracion]" & vbCrLf &
                                  "Debe revisar las bases del sistema pata poder utilizar esta configuración.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Rdb_Todos_Pueden_Dar_Permisos.Checked = True
                Return

            End If

            MessageBoxEx.Show(Me, "Recuerde que ahora los usuarios que tengan permisos de Supervisor podrán otorgar sus permisos a otros usuarios",
                              "Perfil de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        If Rdb_Todos_Pueden_Dar_Permisos.Checked Then

            MessageBoxEx.Show(Me, "Cualquier usuario si tiene el permiso correspondiente podrá dar permisos remotos o presenciales a otros usuarios" & vbCrLf &
                              "No importa si es Supervisor o Usuario",
                              "Perfil de usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


        End If

        If _Existe_Campo Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Configuracion Set 
                            Solo_Supervisores_Dan_Permisos = " & Convert.ToInt32(Rdb_Solo_Supervisores_Dan_Permisos.Checked) & " 
                            Where Empresa = '" & ModEmpresa & "' And Modalidad = '  '"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            _Global_Row_Configuracion_General.Item("Solo_Supervisores_Dan_Permisos") = Rdb_Solo_Supervisores_Dan_Permisos.Checked

        End If

    End Sub

    Private Sub Btn_Exportar_Excel_Permisos_Usuarios_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel_Permisos_Usuarios.Click

        Dim _Tbl As DataTable

        Consulta_sql = "Select CodPermiso,DescripcionPermiso As Permiso,CodFamilia,NombreFamiliaPermiso As Familia,Descuento,Max_Compra 
                        From " & _Global_BaseBk & "ZW_Permisos"
        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Permisos")

        Consulta_sql = "Select CodUsuario,NOKOFU As Usuario,Z1.CodPermiso,DescripcionPermiso As Permiso,CodFamilia,NombreFamiliaPermiso,Descuento,Max_Compra
                        From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Z1 
                        Inner Join " & _Global_BaseBk & "ZW_Permisos Z2 On Z1.CodPermiso = Z2.CodPermiso
                        Left Join TABFU On KOFU = CodUsuario"
        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "PermisosVsUsuarios")

    End Sub

End Class
