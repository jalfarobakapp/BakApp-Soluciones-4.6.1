
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Mesones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Mesones As DataTable
    Dim _RowIndex As Integer
    Dim _Row_Meson As DataRow

    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Mesones, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Operarios, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Maquinas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Crear.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Mesones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddHandler Grilla_Mesones.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Operarios.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Maquinas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Mesones.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Operarios.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Maquinas.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grillas()

        AddHandler Rdb_Ordenar_Codigo.CheckedChanged, AddressOf Sb_Actualizar_Grillas
        AddHandler Rdb_Ordenar_Descripcion.CheckedChanged, AddressOf Sb_Actualizar_Grillas

    End Sub

    Sub Sb_Actualizar_Grillas()

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario Set Nombreob = Ob.NOMBREOB" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario Mo Inner Join PMAEOB Ob On Ob.CODIGOOB = Mo.Codigoob"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Ms.*,Case When Maestro = 1 Then Ms.Nommeson+' *** (MESON MAESTRO)' Else Ms.Nommeson End As NombreMeson,
                        Isnull(Op1.NOMBREOP,'') As Op1,Isnull(Op2.NOMBREOP,'') As Op2,Isnull(Op3.NOMBREOP,'') As Op3 
                        From " & _Global_BaseBk & "Zw_Pdc_Mesones Ms
                        Left Join POPER Op1 On Ms.Operacion = Op1.OPERACION
                        Left Join POPER Op2 On Ms.Operacion_Equivalente = Op2.OPERACION
                        Left Join POPER Op3 On Ms.Operacion_Reproceso = Op3.OPERACION
                        Where Activo = 1 
                        Order by Maestro Desc,Orden_Meson" & vbCrLf &
                       "Select Mo.Codigoob,Mo.Nombreob,Mo.Codmeson,Mo.Fecha_Hora_Asig As Fecha,Mo.Fecha_Hora_Asig As Hora,Cast(Case When INACTIVO = 0 Then 1 Else 0 end As bit) As Activo,Ob.INACTIVO" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario Mo" & vbCrLf &
                       "Inner Join PMAEOB Ob On Ob.CODIGOOB = Mo.Codigoob" &
                       vbCrLf &
                       "Select Codmeson,Codmaq,Nombremaq From " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  

        _Ds.Relations.Add("Rel_Operarios_x_Meson",
                         _Ds.Tables("Table").Columns("Codmeson"),
                         _Ds.Tables("Table1").Columns("Codmeson"), False)

        _Ds.Relations.Add("Rel_Maquinas_x_Meson",
                          _Ds.Tables("Table").Columns("Codmeson"),
                          _Ds.Tables("Table2").Columns("Codmeson"), False)

        _Tbl_Mesones = _Ds.Tables(0)
        Dim _Tbl_Maquinas = _Ds.Tables(1)

        Grilla_Mesones.DataSource = _Ds
        Grilla_Mesones.DataMember = "Table"

        'Muestra segunda relacion
        Grilla_Operarios.DataSource = _Ds
        Grilla_Operarios.DataMember = "Table.Rel_Operarios_x_Meson"

        'Muestra tercera relacion
        Grilla_Maquinas.DataSource = _Ds
        Grilla_Maquinas.DataMember = "Table.Rel_Maquinas_x_Meson"

        OcultarEncabezadoGrilla(Grilla_Mesones, True)
        OcultarEncabezadoGrilla(Grilla_Operarios)
        OcultarEncabezadoGrilla(Grilla_Maquinas)

        '_Tbl_Mesones = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Mesones

            .Columns("Codmeson").Visible = True
            .Columns("Codmeson").HeaderText = "Código"
            .Columns("Codmeson").Width = 100
            .Columns("Codmeson").Frozen = True
            .Columns("Codmeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreMeson").Visible = True
            .Columns("NombreMeson").HeaderText = "Nombre mesón"
            .Columns("NombreMeson").Width = 330
            .Columns("NombreMeson").Frozen = True
            .Columns("NombreMeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Virtual").Visible = True
            .Columns("Virtual").HeaderText = "Virtual"
            .Columns("Virtual").Width = 60
            '.Columns("Virtual").Frozen = True
            .Columns("Virtual").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Operacion").Visible = True
            .Columns("Operacion").HeaderText = "Operación"
            .Columns("Operacion").Width = 70
            '.Columns("Operacion").Frozen = True
            .Columns("Operacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Operacion").Visible = True
            '.Columns("Operacion").HeaderText = "Operación"
            '.Columns("Operacion").Width = 70
            '.Columns("Operacion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Operacion_Equivalente").Visible = True
            .Columns("Operacion_Equivalente").HeaderText = "Equiv."
            .Columns("Operacion_Equivalente").Width = 70
            '.Columns("Operacion_Equivalente").Frozen = True
            .Columns("Operacion_Equivalente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Operacion_Reproceso").Visible = True
            .Columns("Operacion_Reproceso").HeaderText = "Repro."
            .Columns("Operacion_Reproceso").Width = 70
            '.Columns("Operacion_Reproceso").Frozen = True
            .Columns("Operacion_Reproceso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Operacion_Serv_Tecnico").Visible = True
            .Columns("Operacion_Serv_Tecnico").HeaderText = "Serv. Téc."
            .Columns("Operacion_Serv_Tecnico").Width = 70
            .Columns("Operacion_Serv_Tecnico").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SolicitaConfOperaciones").Visible = True
            .Columns("SolicitaConfOperaciones").HeaderText = "Sol.COP"
            .Columns("SolicitaConfOperaciones").Width = 60
            .Columns("SolicitaConfOperaciones").ToolTipText = "Solicita confirmar las operaciones (Serv. Técnico)"
            .Columns("SolicitaConfOperaciones").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ActivaAlPrincipio").Visible = True
            .Columns("ActivaAlPrincipio").HeaderText = "Act.Pr."
            .Columns("ActivaAlPrincipio").Width = 60
            .Columns("ActivaAlPrincipio").ToolTipText = "Activar al principio, despues de que realiza el trabaj el mesón maestro."
            .Columns("ActivaAlPrincipio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        _DisplayIndex = 0

        With Grilla_Operarios

            .Columns("Codigoob").Visible = True
            .Columns("Codigoob").HeaderText = "Código"
            .Columns("Codigoob").Width = 80
            .Columns("Codigoob").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombreob").Visible = True
            .Columns("Nombreob").HeaderText = "Nombre operario"
            .Columns("Nombreob").Width = 400
            .Columns("Nombreob").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Activo").Visible = True
            .Columns("Activo").HeaderText = "Activo"
            .Columns("Activo").Width = 50
            .Columns("Activo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 80
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 60
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        _DisplayIndex = 0

        With Grilla_Maquinas

            .Columns("Codmaq").Visible = True
            .Columns("Codmaq").HeaderText = "Código"
            .Columns("Codmaq").Width = 100
            .Columns("Codmaq").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombremaq").Visible = True
            .Columns("Nombremaq").HeaderText = "Nombre maquina"
            .Columns("Nombremaq").Width = 570
            .Columns("Nombremaq").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla_Mesones.Rows
            If _Fila.Cells("Maestro").Value Then
                _Fila.DefaultCellStyle.BackColor = Amarillo
            End If
        Next

        Txt_Operacion.DataBindings.Clear()
        Txt_Operacion_Equivalente.DataBindings.Clear()
        Txt_Operacion_Reproceso.DataBindings.Clear()

        Txt_Operacion.DataBindings.Add("text", _Ds, "table.Op1")
        Txt_Operacion_Equivalente.DataBindings.Add("text", _Ds, "table.Op2")
        Txt_Operacion_Reproceso.DataBindings.Add("text", _Ds, "table.Op3")

    End Sub

    Private Sub Btn_Crear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear.Click

        Dim _Creado As Boolean

        Dim Fm As New Frm_Crear_Meson()
        Fm.ShowDialog(Me)
        _Creado = Fm.Pro_Grabar
        Fm.Dispose()

        If _Creado Then
            Sb_Actualizar_Grillas()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Mesones.CellDoubleClick

        Dim _Editado, _Eliminado As Boolean
        Dim _Fila As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)

        Dim _Codmeson = _Fila.Cells("Codmeson").Value
        Dim _Nommeson = _Fila.Cells("Nommeson").Value

        If Not Fx_Revisar_Meson_Abierto_En_Otro_Equipo(_Codmeson, "") Then
            Return
        End If

        Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_Crear_Meson(_Codmeson)
        Fm.ShowDialog(Me)
        _Editado = Fm.Pro_Grabar
        _Eliminado = Fm.Pro_Eliminar
        _Row_Meson = Fm.Pro_Row_Meson
        Fm.Dispose()

        If _Editado Then
            Sb_Actualizar_Grillas()
        ElseIf _Eliminado Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina Where Codmeson = '" & _Codmeson & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla_Mesones.Rows.RemoveAt(Grilla_Mesones.CurrentRow.Index)
            End If
        End If
    End Sub


    Function Fx_Revisar_Meson_Abierto_En_Otro_Equipo(_CodMeson As String, Nommeson As String) As Boolean

        Consulta_sql = "Select Codmeson,Nommeson,Activo,Abierto,NombreEquipo_Abierto,Abierto_FechaHora,Codigoob_Abierto,Isnull(NOMBREOB,'') As Nombreob 
                        From " & _Global_BaseBk & "Zw_Pdc_Mesones 
                            Left Join PMAEOB On CODIGOOB = Codigoob_Abierto
                        Where Codmeson  = '" & _CodMeson & "'"

        Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Abierto As Boolean = _Row_Meson.Item("Abierto")
        Dim _NombreEquipo_Abierto As String = _Row_Meson.Item("NombreEquipo_Abierto")
        Dim _Nombreob As String = _Row_Meson.Item("Nombreob").ToString.Trim

        If _Abierto Then

            MessageBoxEx.Show(Me, "El mesón " & Nommeson & " se encuentra abierto en el equipo: " & _NombreEquipo_Abierto & vbCrLf &
                              "Con el operario: " & _Nombreob & vbCrLf & vbCrLf &
                              "No es posible hacer gestión desde este equipo hasta que ese mesón haya cerrado su sesión",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return False

        End If

        Return True

    End Function


    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    If sender.Name = "Grilla_Mesones" Then
                        ShowContextMenu(Menu_Contextual_Meson)
                    ElseIf sender.Name = "Grilla_Operarios" Then
                        ShowContextMenu(Menu_Contextual_Operario)
                    ElseIf sender.Name = "Grilla_Maquinas" Then
                        ShowContextMenu(Menu_Contextual_Maquina)
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_Editar_Meson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Editar_Meson.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Agregar_Maquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Maquina.Click

        Dim _Fila As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)
        Dim _Codmeson = _Fila.Cells("Codmeson").Value

        Dim _Sql_Filtro_Condicion_Extra = "And CODMAQ Not In (Select Codmaq From " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Maquinas, _Sql_Filtro_Condicion_Extra,
                               Nothing, False) Then
            Dim _Tbl_Maquinas As DataTable = _Filtrar.Pro_Tbl_Filtro
            Consulta_sql = String.Empty
            For Each _Row As DataRow In _Tbl_Maquinas.Rows

                Dim _Codmaq = _Row.Item("Codigo")
                Dim _Nombremaq = _Row.Item("Descripcion")

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina (Codmeson, Codmaq, Nombremaq) Values" & Space(1) &
                               "('" & _Codmeson & "','" & _Codmaq & "','" & _Nombremaq & "')" & vbCrLf

            Next

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Sb_Actualizar_Grillas()
                    ToastNotification.Show(Me, "DATOS INGRESADOS CORRECTAMENTE", Nothing,
                                  2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    If BuscarDatoEnGrilla(Trim(_Codmeson), "Codmeson", Grilla_Mesones) Then
                        Grilla_Mesones.CurrentCell = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index).Cells("Codmeson")
                        Grilla_Mesones.Focus()
                    End If

                End If
            End If

        End If

    End Sub

    Private Sub Btn_Asociar_Operario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Operario.Click

        Dim _Fila As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)
        Dim _Codmeson = _Fila.Cells("Codmeson").Value
        Dim _Tbl_Operario As DataTable

        'Consulta_sql = "Select Codigoob As Codigo,Nombreob As Descripcion From " & _Global_BaseBk & "Zw_Pdc_MesonVsOper Where Codmeson = '" & _Codmeson & "'"
        '_Tbl_Operario = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Sql_Filtro_Condicion_Extra = "And CODIGOOB Not In" & Space(1) &
                                          "(Select Codigoob From " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario Where Codmeson = '" & _Codmeson & "')" & Space(1) &
                                          "And INACTIVO = 0"
        'Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operarios, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then
            _Tbl_Operario = _Filtrar.Pro_Tbl_Filtro

            For Each _Row As DataRow In _Tbl_Operario.Rows

                Dim _Codigoob = _Row.Item("Codigo")
                Dim _Nombreob = _Row.Item("Descripcion")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario (Codigoob,Nombreob,Codmeson) Values" & Space(1) &
                               "('" & _Codigoob & "','" & _Nombreob & "','" & _Codmeson & "')" & vbCrLf

            Next

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Sb_Actualizar_Grillas()
                    ToastNotification.Show(Me, "DATOS INGRESADOS CORRECTAMENTE", Nothing,
                                  2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    If BuscarDatoEnGrilla(Trim(_Codmeson), "Codmeson", Grilla_Mesones) Then
                        Grilla_Mesones.CurrentCell = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index).Cells("Codmeson")
                        Grilla_Mesones.Focus()
                    End If

                End If
            End If

        End If


    End Sub

    Private Sub Btn_Eliminar_Meson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_Meson.Click

        Dim _Fila As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)
        Dim _Codmeson = _Fila.Cells("Codmeson").Value.ToString.Trim

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_MesonVsOperario", "Codmeson = '" & _Codmeson & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Este mesón tiene trabajos asociados, no se puede eliminar el registro", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_MesonVsMaquina", "Codmeson = '" & _Codmeson & "'")

        Dim _MsgMaq As String

        If _Reg Then
            _MsgMaq = "Existen maquinas asociadas a este mesón, se quitaran todas la maquinas al eliminar el mesón." & vbCrLf & vbCrLf
        End If

        If MessageBoxEx.Show(Me, _MsgMaq & "¿Está seguro de eliminar este registro?", "Eliminar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina Where Codmeson = '" & _Codmeson & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla_Mesones.Rows.RemoveAt(Grilla_Mesones.CurrentRow.Index)
            End If
        End If

    End Sub

    Private Sub Grilla_Mesones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Mesones.CellClick
        Dim _Cabeza = sender.Columns(sender.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)

        If _Cabeza = "Btn_Opc" Then
            ShowContextMenu(Menu_Contextual_Meson)
        End If
    End Sub

    Private Sub Grilla_Operarios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Operarios.CellClick
        Dim _Cabeza = sender.Columns(sender.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)

        If _Cabeza = "Btn_Opc" Then
            ShowContextMenu(Menu_Contextual_Operario)
        End If
    End Sub

    Private Sub Grilla_Maquinas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maquinas.CellDoubleClick
        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)
        Sb_Opciones_Maquinas(_Fila)
    End Sub

    Private Sub Grilla_Maquinas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Maquinas.CellClick
        Dim _Cabeza = sender.Columns(sender.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)
        If _Cabeza = "Btn_Quitar" Then
            Sb_Opciones_Maquinas(_Fila)
        End If
    End Sub

    Sub Sb_Opciones_Maquinas(_Fila As DataGridViewRow)

        Dim _Codmeson = _Fila.Cells("Codmeson").Value
        Dim _Codmaq = _Fila.Cells("Codmaq").Value

        Dim _Reg As Boolean '= _Sql.Fx_Cuenta_Registros("PDATFAD", "IDPDATFAE In (Select IDPDATFAE From PDATFAE Where REQCONFIR = 1) And CODMAQ = '" & _Codmaq & "'")
        _Reg = _Sql.Fx_Cuenta_Registros("")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Esta maquina tien DFA en proceso, debe cerrar esas DFA antes de poder quitar la máquina de este mesón",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Está seguro de quitar esta máquina?", "Quitar operario",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina" & vbCrLf &
                           "Where Codmeson = '" & _Codmeson & "' And Codmaq = '" & _Codmaq & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla_Maquinas.Rows.RemoveAt(Grilla_Mesones.CurrentRow.Index)
            End If
        End If

    End Sub

    Private Sub Btn_Subir_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Subir_Producto.Click

        Try

            'Obtener el índice de la fila seleccionada
            _RowIndex = Grilla_Mesones.SelectedCells(0).OwningRow.Index

            'Crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Arriba As DataRow

            Dim _Subir As Boolean
            'Dim _Contador As Integer = 1

            If _RowIndex > 0 Then

                Dim _Fila_de_Arriba As DataGridViewRow
                'For _i = _RowIndex - 1 To 0 Step -1
                _Fila_de_Arriba = Grilla_Mesones.Rows(_RowIndex - 1)
                'Dim _Movible = _Fila_de_Arriba.Cells("Movible").Value
                'If _Movible Then
                _Fila_Arriba = Fx_Clonar_Fila(_RowIndex - 1)
                _Subir = True
                'Exit For
                'End If
                '_Contador += 1
                'Next

                If _Subir Then

                    'Eliminar la fila seleccionada
                    Grilla_Mesones.ClearSelection()
                    Grilla_Mesones.Rows(0).Selected = True
                    Grilla_Mesones.CurrentCell = Grilla_Mesones.Rows(0).Cells("Codmeson")

                    _Tbl_Mesones.Rows.RemoveAt(_RowIndex)
                    _Tbl_Mesones.Rows.InsertAt(_Fila_Actual, _RowIndex - 1)

                    'Inserte la nueva fila en una nueva posición
                    _Tbl_Mesones.Rows.RemoveAt(_Fila_de_Arriba.Index)
                    _Tbl_Mesones.Rows.InsertAt(_Fila_Arriba, _RowIndex)

                    Dim _Orden_Index = _Fila_Actual.Item("Orden_Meson")
                    Sb_Marcar_Fila_Seleccionada(_Orden_Index)

                Else
                    Beep()
                End If

                'If _Subir Then

                'Eliminar la fila seleccionada
                '_Tbl_Mesones.Rows.RemoveAt(_RowIndex)

                ''inserte la nueva fila en una nueva posición
                '_Tbl_Mesones.Rows.InsertAt(_Fila_Actual, _RowIndex - _Contador)
                'Grilla_Mesones.ClearSelection()
                'Grilla_Mesones.Rows(_RowIndex - 1).Selected = True
                'Grilla_Mesones.CurrentCell = Grilla_Mesones.Rows(_RowIndex - 1).Cells("Numot")
                ''Grilla_Potl.Focus()
                'Else
                'Beep()
                'End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Bajar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Bajar_Producto.Click

        Try

            'obtener el índice de la fila seleccionada
            _RowIndex = Grilla_Mesones.SelectedCells(0).OwningRow.Index

            'crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Abajo As DataRow

            Dim _Bajar As Boolean
            Dim _Contador As Integer = 1

            Dim _RowIndex_Abajo As Integer


            If _RowIndex + 1 < Grilla_Mesones.RowCount Then

                Dim _Fila_de_Abajo As DataGridViewRow
                'For _i = _RowIndex + 1 To Grilla_Mesones.RowCount - 1
                _Fila_de_Abajo = Grilla_Mesones.Rows(_RowIndex + 1)
                '   Dim _Movible = _Fila_de_Abajo.Cells("Movible").Value
                'If _Movible Then
                _Fila_Abajo = Fx_Clonar_Fila(_RowIndex + 1)
                _RowIndex_Abajo = _RowIndex + 1
                _Bajar = True
                '        Exit For
                'End If
                _Contador -= 1
                'Next

                If _Bajar Then

                    'eliminar la fila seleccionada

                    _Tbl_Mesones.Rows.RemoveAt(_RowIndex)
                    _Tbl_Mesones.Rows.InsertAt(_Fila_Actual, _RowIndex_Abajo) ' _RowIndex + _Contador)

                    'inserte la nueva fila en una nueva posición
                    _Tbl_Mesones.Rows.RemoveAt(_Fila_de_Abajo.Index)
                    _Tbl_Mesones.Rows.InsertAt(_Fila_Abajo, _RowIndex)

                    Dim _Orden_Index = _Fila_Actual.Item("Orden_Meson")
                    Sb_Marcar_Fila_Seleccionada(_Orden_Index)

                Else
                    Beep()
                End If


                ''eliminar la fila seleccionada
                '_Tbl_Mesones.Rows.RemoveAt(_RowIndex)

                ''inserte la nueva fila en una nueva posición
                '_Tbl_Mesones.Rows.InsertAt(row, _RowIndex + 1)
                'Grilla_Mesones.ClearSelection()
                'Grilla_Mesones.Rows(_RowIndex + 1).Selected = True
                'Grilla_Mesones.CurrentCell = Grilla_Mesones.Rows(_RowIndex + 1).Cells("Numot")
                ''Grilla_Potl.Focus()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Function Fx_Clonar_Fila(_RowIndex As Integer) As DataRow
        Dim row As DataRow
        row = _Tbl_Mesones.NewRow()

        'agregar datos a la fila

        For i = 0 To Grilla_Mesones.ColumnCount - 1
            row(i) = Grilla_Mesones.Rows(_RowIndex).Cells(i).Value
        Next
        Return row
    End Function

    Sub Sb_Marcar_Fila_Seleccionada(_Orden_Index As Integer)

        For Each _Fila As DataGridViewRow In Grilla_Mesones.Rows
            Dim _Orden_1 = _Fila.Cells("Orden_Meson").Value
            If _Orden_1 = _Orden_Index Then
                _Fila.Selected = True
                Grilla_Mesones.CurrentCell = Grilla_Mesones.Rows(_Fila.Index).Cells("Codmeson")
                Grilla_Mesones.Focus()
                Exit For
            End If
        Next

    End Sub

    Private Sub Btn_Mnu_Quitar_Operario_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Quitar_Operario.Click

        Dim _Fila_Ope As DataGridViewRow = Grilla_Operarios.Rows(Grilla_Operarios.CurrentRow.Index)
        Dim _Fila_Mes As DataGridViewRow = Grilla_Mesones.Rows(Grilla_Mesones.CurrentRow.Index)

        Dim _Codmeson = _Fila_Mes.Cells("Codmeson").Value
        Dim _Codigoob = _Fila_Ope.Cells("Codigoob").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MaquinaVsProductos",
                                            "Codmeson = '" & _Codmeson & "' And Obrero = '" & _Codigoob & "' And Estado = 'EMQ'")

        If CBool(_Reg) Then

            MessageBoxEx.Show(Me, "No se puede quitar al operacio ya que se encuentra trabajando en el mesón actualmente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop,
                              MessageBoxDefaultButton.Button1, True)

        Else

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdc_MesonVsOperario 
                            Where Codmeson = '" & _Codmeson & "' And Codigoob = '" & _Codigoob & "'"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla_Operarios.Rows.RemoveAt(Grilla_Operarios.CurrentRow.Index)
            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Quitar_Maquina_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Quitar_Maquina.Click

        Dim _Fila As DataGridViewRow = Grilla_Maquinas.Rows(Grilla_Maquinas.CurrentRow.Index)

        Dim _Codmeson = _Fila.Cells("Codmeson").Value.ToString.Trim
        Dim _Codmaq = _Fila.Cells("Codmaq").Value.ToString.Trim
        Dim _Nombremaq = _Fila.Cells("Nombremaq").Value.ToString.Trim

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MaquinaVsProductos",
                                                       "Codmeson = '" & _Codmeson & "' And CodMaq = '" & _Codmaq & "' And Estado = 'EMQ'")

        If CBool(_Reg) Then

            MessageBoxEx.Show(Me, "No se puede quitar la maquina, ya que esta siendo utilizada", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop,
                              MessageBoxDefaultButton.Button1, True)

        Else

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina Where Codmeson = '" & _Codmeson & "' And Codmaq = '" & _Codmaq & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla_Maquinas.Rows.RemoveAt(Grilla_Maquinas.CurrentRow.Index)
            End If

        End If

    End Sub

End Class
