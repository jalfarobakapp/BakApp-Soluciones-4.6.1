Imports DevComponents.DotNetBar
Imports System.Drawing
Imports System.Windows.Forms
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Permisos_Usuario_Permisos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds As DataSet
    Dim _Dv As New DataView

    Dim _CodUsuario As String

    Public Sub New(ByVal CodUsuario As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _CodUsuario = CodUsuario

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

        Sb_Color_Botones_Barra(Bar2)

        Chk_Es_Supervisor.Visible = False

    End Sub

    Private Sub Frm_Permisos_Usuario_Permisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Formato_Generico_Grilla(Grilla_Familias, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Permisos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Actualizar_Grilla_Permisos()

        AddHandler Grilla_Permisos.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Permisos.KeyDown, AddressOf Grilla_KeyDown

        AddHandler Grilla_Familias.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        ActiveControl = Grilla_Familias

    End Sub

    Sub Sb_Actualizar_Grilla_Permisos()

        Consulta_sql = "Select 0 As Orden,'ZZ' As CodFamilia,'Todos los permisos...' As NombreFamiliaPermiso 
                        Union 
                        Select Distinct 1 As Orden,CodFamilia, NombreFamiliaPermiso From " & _Global_BaseBk & "ZW_Permisos
                        Order by Orden,NombreFamiliaPermiso"

        Consulta_sql = "Select Distinct 1 As Orden,CodFamilia, NombreFamiliaPermiso,Cast(0 As Int) As Nro_Permisos  Into #Paso From " & _Global_BaseBk & "ZW_Permisos
                        Insert Into #Paso (Orden,CodFamilia,NombreFamiliaPermiso,Nro_Permisos) Values (0,'ZZ','Todos los permisos...',0)

                        Update #Paso Set Nro_Permisos = (Select Count(*) From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Z2 " &
                            "Where Z2.CodUsuario = '" & _CodUsuario & "' And Z2.CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Z3 " &
                            "Where Z3.CodFamilia = Z1.CodFamilia))
                        From #Paso Z1

                        Select * From #Paso Order by Orden,NombreFamiliaPermiso

                        Drop Table #Paso"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Familias

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Familias, True)

            .Columns("NombreFamiliaPermiso").Width = 230 - 40
            .Columns("NombreFamiliaPermiso").HeaderText = "Grupo"
            .Columns("NombreFamiliaPermiso").Visible = True
            .Columns("NombreFamiliaPermiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_Permisos").Width = 40
            .Columns("Nro_Permisos").HeaderText = "Tiene"
            .Columns("Nro_Permisos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_Permisos").DefaultCellStyle.Format = "###,##.##"
            .Columns("Nro_Permisos").Visible = True
            .Columns("Nro_Permisos").DisplayIndex = _DisplayIndex

        End With

        Consulta_sql = "Select CAST((Case When Z1.CodPermiso = Z2.CodPermiso Then 1 Else 0 End) AS bit) AS Chk,Z1.*,Isnull(Z2.Valor_Dscto,0) As Valor_Dscto," &
                       "Isnull(Z2.Valor_Max_Compra,0) As Valor_Max_Compra,Cast(0 As Bit) As Permiso_Externo" & vbCrLf &
                       "Into #Paso_Permisos" & vbCrLf &
                       "From " & _Global_BaseBk & "ZW_Permisos Z1" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "ZW_PermisosVsUsuarios Z2 On Z1.CodPermiso = Z2.CodPermiso And Z2.CodUsuario = '" & _CodUsuario & "'" & vbCrLf &
                       "Update #Paso_Permisos Set Permiso_Externo = 1 Where CodPermiso = 'Comp0095'" & vbCrLf &
                       "Select * From #Paso_Permisos" & vbCrLf &
                       "Drop Table #Paso_Permisos"

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv.Table = _Ds.Tables(0)

        With Grilla_Permisos

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla_Permisos, True)

            _DisplayIndex = 0

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodPermiso").Width = 100
            .Columns("CodPermiso").HeaderText = "Código"
            .Columns("CodPermiso").Visible = True
            .Columns("CodPermiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DescripcionPermiso").Width = 500
            .Columns("DescripcionPermiso").HeaderText = "Descripción permiso"
            .Columns("DescripcionPermiso").Visible = True
            .Columns("DescripcionPermiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descuento").Width = 30
            .Columns("Descuento").HeaderText = "Ds"
            .Columns("Descuento").Visible = True
            .Columns("Descuento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valor_Dscto").Width = 50
            .Columns("Valor_Dscto").HeaderText = "% Dscto."
            .Columns("Valor_Dscto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Dscto").DefaultCellStyle.Format = "###,##.##"
            .Columns("Valor_Dscto").Visible = True
            .Columns("Valor_Dscto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Max_Compra").Width = 30
            .Columns("Max_Compra").HeaderText = "Cm"
            .Columns("Max_Compra").Visible = True
            .Columns("Max_Compra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valor_Max_Compra").Width = 80
            .Columns("Valor_Max_Compra").HeaderText = "$ Max.Compra"
            .Columns("Valor_Max_Compra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor_Max_Compra").DefaultCellStyle.Format = "###,##.##"
            .Columns("Valor_Max_Compra").Visible = True
            .Columns("Valor_Max_Compra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Lbl_Status.Text = "Permisos: " & Grilla_Permisos.Rows.Count

    End Sub

    Private Sub Sb_Buscar_En_Grilla_Dataview(_Descripcion_a_buscar As String)

        _Descripcion_a_buscar = Replace(_Descripcion_a_buscar, vbTab, "")
        _Descripcion_a_buscar = Trim(_Descripcion_a_buscar)

        Dim _Descripcion As String = Replace(_Descripcion_a_buscar, "'", "")

        If IsNothing(_Descripcion) Then _Descripcion = String.Empty

        Dim _Contiene_Espacios As Boolean = _Descripcion.Contains(" ")
        Dim _Lista_Descripciones() As String

        Dim _Lista_productos_A_Buscar As String = String.Empty

        If _Contiene_Espacios Then

            _Lista_Descripciones = Split(_Descripcion, " ")

            For i = 0 To _Lista_Descripciones.Length - 1
                If i = 0 Then
                    _Lista_productos_A_Buscar += "CodPermiso+DescripcionPermiso Like '%" & _Lista_Descripciones(i) & "%'" 'Fx_Descripcion(_Lista_Descripciones(i))
                Else
                    _Lista_productos_A_Buscar += " And CodPermiso+DescripcionPermiso Like '%" & _Lista_Descripciones(i) & "%'" 'Fx_Descripcion(_Lista_Descripciones(i), " Or ")
                End If
            Next

        Else

            _Lista_productos_A_Buscar += "CodPermiso+DescripcionPermiso Like '%" & _Descripcion_a_buscar & "%'"

        End If

        Dim _CodFamilia As String

        Try
            _CodFamilia = Grilla_Familias.Rows(Grilla_Familias.CurrentRow.Index).Cells("CodFamilia").Value
        Catch ex As Exception
            _CodFamilia = "ZZ"
        End Try

        If _CodFamilia = "ZZ" Then
            _Dv.RowFilter = _Lista_productos_A_Buscar
        Else
            _Dv.RowFilter = _Lista_productos_A_Buscar & " And CodFamilia = '" & _CodFamilia & "'"
        End If

        Lbl_Status.Text = "Permisos: " & Grilla_Permisos.Rows.Count

    End Sub

    Private Sub Grilla_Grupos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        'Dim _CodFamilia As String = Grilla_Grupos.Rows(Grilla_Grupos.CurrentRow.Index).Cells("CodFamilia").Value
        'Dim _NombreFamiliaPermiso As String = Grilla_Grupos.Rows(Grilla_Grupos.CurrentRow.Index).Cells("NombreFamiliaPermiso").Value

        'Grupo_Permisos.Text = "Permisos: " & UCase(_NombreFamiliaPermiso)
        'Sb_Actualizar_Grilla_Permisos(_CodFamilia)

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Permisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar_Permisos.Click

        Dim _Llave As String
        Dim _CodPermiso As String

        Consulta_sql = "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodUsuario = '" & _CodUsuario & "'" & vbCrLf & vbCrLf

        For Each _Fila As DataRow In _Dv.Table.Rows

            Dim _Chk As Boolean = _Fila.Item("Chk")

            If _Chk Then

                _CodPermiso = Trim(_Fila.Item("CodPermiso"))
                Dim _DescripcionPermiso As String = Trim(_Fila.Item("DescripcionPermiso"))

                Dim _Descuento As Boolean = Trim(_Fila.Item("Descuento"))
                Dim _Max_Compra As Boolean = Trim(_Fila.Item("Max_Compra"))
                Dim _Valor_Dscto As Double = _Fila.Item("Valor_Dscto")
                Dim _Valor_Max_Compra As Double = _Fila.Item("Valor_Max_Compra")

                'Dim _Clave_Admin As String = _Sql.Fx_Trae_Dato(, "ClaveAdministrador", _Global_BaseBk & "ZW_PermisosADM")

                'Dim _Llave As String = UCase(_CodPermiso & "@" & _CodUsuario)
                '_Llave = Encripta_md5(_Llave)

                _Llave = Fx_Hacer_Llave(_CodUsuario, _CodPermiso)

                If _Descuento And _Valor_Dscto <= 0 Then

                    MessageBoxEx.Show(Me, "Debe ingresar el % para los permisos de descuento" & vbCrLf &
                                      "Permiso: " & _CodPermiso & "-" & _DescripcionPermiso, "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Grilla_Familias.CurrentCell = Grilla_Familias.Rows(0).Cells("NombreFamiliaPermiso")
                    Txt_Descripcion.Text = _CodPermiso
                    Sb_Buscar_En_Grilla_Dataview(Txt_Descripcion.Text)
                    Return

                End If

                If _Max_Compra And _Valor_Max_Compra <= 0 Then

                    MessageBoxEx.Show(Me, "Debe ingresar el monto para las aprobaciones de ordenes de compra, no puede ser 0" & vbCrLf &
                                      "Permiso: " & _CodPermiso & "-" & _DescripcionPermiso, "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Grilla_Familias.CurrentCell = Grilla_Familias.Rows(0).Cells("NombreFamiliaPermiso")
                    Txt_Descripcion.Text = _CodPermiso
                    Sb_Buscar_En_Grilla_Dataview(Txt_Descripcion.Text)
                    Return

                End If

                Consulta_sql += "INSERT INTO " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario,CodPermiso,Llave,Valor_Dscto,Valor_Max_Compra) VALUES " &
                                     "('" & _CodUsuario & "','" & _CodPermiso & "','" & _Llave &
                                     "'," & De_Num_a_Tx_01(_Valor_Dscto, False, 5) & "," & De_Num_a_Tx_01(_Valor_Max_Compra, False, 5) & ")" & vbCrLf

            End If

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            Dim _Index = Grilla_Familias.CurrentRow.Index
            Dim _Descripcion = Txt_Descripcion.Text

            Sb_Actualizar_Grilla_Permisos()
            Grilla_Familias.CurrentCell = Grilla_Familias.Rows(_Index).Cells("NombreFamiliaPermiso")
            Txt_Descripcion.Text = _Descripcion
            Sb_Buscar_En_Grilla_Dataview(Txt_Descripcion.Text)

            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

    End Sub

    Function Fx_Hacer_Llave(ByVal _Kofu As String, ByVal _CodPermiso As String) As String

        Dim _Llave As String = UCase(_CodPermiso & "@" & _Kofu)
        _Llave = Encripta_md5(_Llave)

        Return _Llave

    End Function

    Private Sub Frm_Permisos_Usuario_Permisos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Function ChequearTodo(ByVal Grilla As DataGridView,
                                  ByVal Chk As Boolean)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _CodPermisoActual As String = _Fila.Cells("CodPermiso").Value

            If _CodPermisoActual <> "NO00021" And _CodPermisoActual <> "NO00022" Then
                _Fila.Cells("Chk").Value = Chk
            End If

        Next

    End Function

    Private Sub ChkSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles ChkSeleccionar.CheckedChanged
        Dim chk As Boolean = ChkSeleccionar.Checked
        ChequearTodo(Grilla_Permisos, chk)
    End Sub


    Private Sub Grilla_Permisos_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla_Permisos.MouseUp
        Grilla_Permisos.EndEdit()

        Dim _Fila As DataGridViewRow = Grilla_Permisos.CurrentRow
        Dim _CodPermisoActual As String = _Fila.Cells("CodPermiso").Value

        If _CodPermisoActual = "NO00021" Then
            ' Buscar y desmarcar NO00022
            For Each fila As DataGridViewRow In Grilla_Permisos.Rows
                If fila.Cells("CodPermiso").Value = "NO00022" Then
                    fila.Cells("Chk").Value = False
                    Exit For
                End If
            Next
        ElseIf _CodPermisoActual = "NO00022" Then
            ' Buscar y desmarcar NO00021
            For Each fila As DataGridViewRow In Grilla_Permisos.Rows
                If fila.Cells("CodPermiso").Value = "NO00021" Then
                    fila.Cells("Chk").Value = False
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub Btn_Asignar_Permiso_A_Otro_Usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Asignar_Permiso_A_Otro_Usuario.Click
        Sb_Otorgar_Este_Permiso_A_Otros_Usuarios()
    End Sub


    Private Sub Btn_Duplicar_Permisos_Usuario_A_Otro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Duplicar_Permisos_Usuario_A_Otro.Click
        Sb_Clonar_Permisos_A_Otros_Usuarios()
    End Sub


    Sub Sb_Otorgar_Este_Permiso_A_Otros_Usuarios()

        Dim _Fila_P As DataGridViewRow = Grilla_Permisos.Rows(Grilla_Permisos.CurrentRow.Index)

        Dim _CodPermiso As String = _Fila_P.Cells("CodPermiso").Value

        Dim _Valor_Dscto As String = De_Num_a_Tx_01(_Fila_P.Cells("Valor_Dscto").Value, False, 5)
        Dim _Valor_Max_Compra As String = De_Num_a_Tx_01(_Fila_P.Cells("Valor_Max_Compra").Value, False, 5)

        Dim _DescripcionPermiso As String = _Fila_P.Cells("DescripcionPermiso").Value
        Dim _Chk As Boolean = _Fila_P.Cells("Chk").Value

        Dim _Nota = "Permiso: " & _CodPermiso & " -> " & _DescripcionPermiso

        Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & Space(1) &
                       "Where CodUsuario = '" & _CodUsuario & "' And CodPermiso = '" & _CodPermiso & "'"
        Dim _TblPermiso As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


        Dim _Permiso As Boolean

        If _Chk Then _Permiso = CBool(_TblPermiso.Rows.Count)

        If _Permiso Then

            Dim _Tbl_Funcionarios_Seleccionados As DataTable

            Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodPermiso = '" & _CodPermiso & "'"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            Dim _Filtro_Usuarios_NOT_In As String

            If CBool(_Tbl.Rows.Count) Then

                _Filtro_Usuarios_NOT_In = "And KOFU Not In " & Generar_Filtro_IN(_Tbl, "", "CodUsuario", False, False, "'")

            End If

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0" & vbCrLf & _Filtro_Usuarios_NOT_In
            Fm.Text = _Nota
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then

                Dim _CantUsuarios As Integer

                _Tbl_Funcionarios_Seleccionados = Fm.Pro_Tbl_Filtro

                Dim _SqlQuery = String.Empty

                For Each _Fila As DataRow In _Tbl_Funcionarios_Seleccionados.Rows

                    If _Fila.Item("Chk") Then

                        Dim _CodUsuario_Destino = _Fila.Item("Codigo")
                        Dim _Llave = Fx_Hacer_Llave(_CodUsuario_Destino, _CodPermiso)

                        _SqlQuery += "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & Space(1) &
                                     "Where CodUsuario = '" & _CodUsuario_Destino & "' And CodPermiso = '" & _CodPermiso & "'" & vbCrLf &
                                     "Insert Into " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario, CodPermiso, Llave,Valor_Dscto,Valor_Max_Compra) VALUES " &
                                     "('" & _CodUsuario_Destino & "','" & _CodPermiso & "','" & _Llave & "'," & _Valor_Dscto & "," & _Valor_Max_Compra & ")" & vbCrLf
                        _CantUsuarios += 1

                    End If

                Next

                If CBool(_CantUsuarios) Then

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

                        Beep()
                        ToastNotification.Show(Me, "Permisos otorgados correctamente a " & _CantUsuarios & " usuarios",
                                               Btn_Asignar_Permiso_A_Otro_Usuario.Image,
                                               2 * 1000, eToastGlowColor.Green,
                                               eToastPosition.BottomCenter)

                    End If

                End If

            End If

        Else

            MessageBoxEx.Show(Me, "Debe tickear el permiso o este aún no está grabado en la base datos para el cliente" & vbCrLf &
                                 "Grabe los permisos y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Sub Sb_Clonar_Permisos_A_Otros_Usuarios()

        Dim _Tbl_Funcionarios_Seleccionados As DataTable

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
        Fm.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _Tbl_Funcionarios_Seleccionados = Fm.Pro_Tbl_Filtro

            Try

                Me.Enabled = False
                Dim _CantUsuarios = 0

                If _Tbl_Funcionarios_Seleccionados.Rows.Count > 1 Then

                    If MessageBoxEx.Show(Me, "ATENCION!!!" & vbCrLf & vbCrLf & "Esta a punto de clonar " & _Tbl_Funcionarios_Seleccionados.Rows.Count & " permisos, esto modificara TODOS los permisos de esos usuarios. " & vbCrLf & vbCrLf &
                                         "¿Desea seguir con la clonación de permisos?",
                                         "Duplicar permisos de usuarios",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                        Return

                    End If

                End If

                For Each _Fila As DataRow In _Tbl_Funcionarios_Seleccionados.Rows

                    If _Fila.Item("Chk") Then

                        Dim _CodUsuario_Destino = _Fila.Item("Codigo")
                        If Fx_Clonar_Permisos_A_Otro_Usuarios(_CodUsuario, _CodUsuario_Destino) Then
                            _CantUsuarios += 1
                        End If

                    End If

                Next

                If CBool(_CantUsuarios) Then
                    Beep()
                    ToastNotification.Show(Me, "Permisos otorgados correctamente a " & _CantUsuarios & " usuarios",
                                           Btn_Asignar_Permiso_A_Otro_Usuario.Image,
                                           2 * 1000, eToastGlowColor.Green,
                                           eToastPosition.MiddleCenter)
                End If

            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Me.Enabled = True

            End Try

        End If

    End Sub

    Function Fx_Clonar_Permisos_A_Otro_Usuarios(_CodUsuario_Origen As String,
                                                _CodUsuario_Destino As String) As Boolean

        Dim _Permisos_Clonados As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodUsuario = '" & _CodUsuario_Origen & "'"
        Dim _TblPermisos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


        If CBool(_TblPermisos.Rows.Count) Then

            Dim _SqlQuery = "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                            "Where CodUsuario = '" & _CodUsuario_Destino & "'" & vbCrLf

            For Each _Fila As DataRow In _TblPermisos.Rows

                Dim _CodPermiso = _Fila.Item("CodPermiso")
                Dim _Llave = Fx_Hacer_Llave(_CodUsuario_Destino, _CodPermiso)

                _SqlQuery += "Insert Into " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario, CodPermiso, Llave) VALUES " &
                                "('" & _CodUsuario_Destino & "','" & _CodPermiso & "','" & _Llave & "')" & vbCrLf

            Next

            _Permisos_Clonados = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)

        End If

        Return _Permisos_Clonados

    End Function

    Private Sub Btn_Ver_Usuario_Con_Este_Permiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Usuario_Con_Este_Permiso.Click

        Dim _Fila_P As DataGridViewRow = Grilla_Permisos.Rows(Grilla_Permisos.CurrentRow.Index)

        Dim _CodPermiso As String = Trim(_Fila_P.Cells("CodPermiso").Value)
        Dim _DescripcionPermiso As String = _Fila_P.Cells("DescripcionPermiso").Value

        Consulta_sql = "Select CodUsuario As Codigo From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & Space(1) &
                       "Where CodPermiso = '" & _CodPermiso & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


        Dim _Nota = "Permiso: " & _CodPermiso & " -> " & _DescripcionPermiso

        If CBool(_Tbl.Rows.Count) Then
            Dim Fm As New Frm_Permisos_Usuario_Lista
            Fm.Pro_Tbl_Solo_Estos_Funcionarios = _Tbl
            Fm.Text = _Nota
            Fm.ShowDialog(Me)
            Fm.Dispose()
        Else

            MessageBoxEx.Show(Me, "No hay usuarios con este permiso asignado", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub Btn_Exportar_Excel_Permisos_Usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel_Permisos_Usuario.Click

        Consulta_sql = "Select CodUsuario As Usuario,NOKOFU As Nombre,Z1.CodPermiso As Codigo,NombreFamiliaPermiso As Grupo,DescripcionPermiso As Permiso 
                        From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Z1 
                        Inner Join " & _Global_BaseBk & "ZW_Permisos Z2 On Z1.CodPermiso = Z2.CodPermiso
                        Inner Join TABFU On KOFU = Z1.CodUsuario
                        Where CodUsuario = '" & _CodUsuario & "'
                        Order by NombreFamiliaPermiso,Permiso"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Permisos Usuario " & _CodUsuario)

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Buscar_En_Grilla_Dataview(Txt_Descripcion.Text)
        End If
    End Sub

    Private Sub Txt_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Txt_Descripcion.TextChanged
        If String.IsNullOrEmpty(Txt_Descripcion.Text) Then
            _Dv.RowFilter = "CodPermiso+DescripcionPermiso Like '%%'"
            Lbl_Status.Text = "Permisos: " & Grilla_Permisos.Rows.Count
            Me.Refresh()
        End If
    End Sub

    Private Sub Btn_Ver_Permisos_Seleccionados_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Permisos_Seleccionados.Click
        _Dv.RowFilter = "Chk = True"
        Lbl_Status.Text = "Permisos: " & Grilla_Permisos.Rows.Count
        Me.Refresh()
    End Sub

    Private Sub Btn_Actualizar_Lista_Permisos_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Lista_Permisos.Click

        Me.Enabled = False
        Dim _Cl As New Class_Permiso_BakApp
        _Cl.Sb_Actualizar_Base_De_Permisos(Me, Lbl_Status)
        Me.Enabled = True

        Sb_Actualizar_Grilla_Permisos()
        Txt_Descripcion.Text = String.Empty

    End Sub

    Private Sub Btn_Porc_Dscto_Click(sender As Object, e As EventArgs) Handles Btn_Porc_Dscto.Click

        Dim _Fila As DataGridViewRow = Grilla_Permisos.Rows(Grilla_Permisos.CurrentRow.Index)
        Dim _Valor_Dscto As Double = _Fila.Cells("Valor_Dscto").Value
        Dim Fm As New Frm_Permisos_Usuario_Porc_Dscto
        Fm.Pro_Porcentaje = _Valor_Dscto
        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then
            _Fila.Cells("Valor_Dscto").Value = Fm.Pro_Porcentaje
        End If
        Fm.Dispose()

    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim tecla = e.KeyCode
        If Grilla_Permisos.RowCount = 0 Then Return

        Dim _Fila As DataGridViewRow = Grilla_Permisos.Rows(Grilla_Permisos.CurrentRow.Index)
        Dim _Cabeza = Grilla_Permisos.Columns(Grilla_Permisos.CurrentCell.ColumnIndex).Name

        Dim _Chk As Boolean = _Fila.Cells("Chk").Value
        Dim _Descuento As Boolean = _Fila.Cells("Descuento").Value
        Dim _Max_Compra As Boolean = _Fila.Cells("Max_Compra").Value

        If _Chk Then

            If e.KeyValue = Keys.Enter Then

                Dim _Editar As Boolean

                Select Case _Cabeza

                    Case "Valor_Dscto"

                        _Editar = _Descuento

                    Case "Valor_Max_Compra"

                        _Editar = _Max_Compra

                End Select

                If _Editar Then

                    Grilla_Permisos.Columns(_Cabeza).ReadOnly = False
                    Grilla_Permisos.BeginEdit(True)

                    e.SuppressKeyPress = False
                    e.Handled = True

                End If

            End If

        End If


    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Permisos.Rows(Grilla_Permisos.CurrentRow.Index)
        Dim _Cabeza = Grilla_Permisos.Columns(Grilla_Permisos.CurrentCell.ColumnIndex).Name

        Dim _Chk As Boolean = _Fila.Cells("Chk").Value
        Dim _Descuento As Boolean = _Fila.Cells("Descuento").Value
        Dim _Max_Compra As Boolean = _Fila.Cells("Max_Compra").Value

        Select Case _Cabeza

            Case "Chk"

                If _Chk Then

                    If _Descuento Then

                        If Not Convert.ToBoolean(_Fila.Cells("Valor_Dscto").Value) Then
                            MessageBoxEx.Show(Me, "Recuerde que debe asignar un valor al descuento en la columna [Dscto.]",
                                          "Permiso especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If

                    If _Max_Compra Then

                        If Not Convert.ToBoolean(_Fila.Cells("Valor_Max_Compra").Value) Then
                            MessageBoxEx.Show(Me, "Recuerde que debe asignar un valor al monto para la aprobación de ordenes de compra en la columna [$ Max.Compra]",
                                          "Permiso especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If

                Else

                    _Fila.Cells("Valor_Dscto").Value = 0
                    _Fila.Cells("Valor_Max_Compra").Value = 0

                End If

            Case Else

                Grilla_Permisos.Columns(_Cabeza).ReadOnly = True

        End Select

    End Sub

    Private Sub Grilla_Familias_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Familias.CellEnter
        Txt_Descripcion.Text = String.Empty
        Sb_Buscar_En_Grilla_Dataview(Txt_Descripcion.Text)
    End Sub

    Private Sub Btn_Mis_Jefes_Click(sender As Object, e As EventArgs) Handles Btn_Mis_Jefes.Click

        Dim Fm As New Frm_Permisos_Usuario_Mis_Jefes(_CodUsuario)
        Fm.Text += Space(1) & Me.Text.Trim
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla_Permisos.Rows(Grilla_Permisos.CurrentRow.Index)
                    Btn_Porc_Dscto.Visible = _Fila.Cells("Descuento").Value

                    ShowContextMenu(Menu_Contextual_Permisos)
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_Permisos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla_Permisos.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla_Permisos.Rows(Grilla_Permisos.CurrentRow.Index)
        Dim _Cabeza = Grilla_Permisos.Columns(Grilla_Permisos.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Chk" And _Fila.Cells("Permiso_Externo").Value Then
            MessageBoxEx.Show(Me, "Permiso externo, no se puede editar desde este administrador", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub

End Class
