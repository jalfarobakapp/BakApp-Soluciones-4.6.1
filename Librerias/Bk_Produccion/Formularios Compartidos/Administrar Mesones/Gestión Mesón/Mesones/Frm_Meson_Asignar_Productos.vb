Imports System.IO
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Meson_Asignar_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Enum Enum_Tipo_OT
        Fabricacion
        Servicio_Tecnico
    End Enum

    Dim _Tipo_OT As Enum_Tipo_OT

    Dim _Ds As DataSet
    Private _dv As New DataView

    Public Sub New(Tipo_OT As Enum_Tipo_OT)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Pote, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Potl, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Potpr, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Tipo_OT = Tipo_OT

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_OT_Buscador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Pote.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Potl.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Potpr.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Rdb_Prioridad_0.Click, AddressOf Sb_Rdb_Prioridad_Click
        AddHandler Rdb_Prioridad_1.Click, AddressOf Sb_Rdb_Prioridad_Click
        AddHandler Rdb_Prioridad_2.Click, AddressOf Sb_Rdb_Prioridad_Click

        AddHandler Rdb_Ver_Abiertas.CheckedChanged, AddressOf Sb_Rdb_Ver_CheckedChanged
        AddHandler Rdb_Ver_Terminadas.CheckedChanged, AddressOf Sb_Rdb_Ver_CheckedChanged
        AddHandler Rdb_Ver_Suspendidas.CheckedChanged, AddressOf Sb_Rdb_Ver_CheckedChanged
        AddHandler Rdb_Ver_Todas.CheckedChanged, AddressOf Sb_Rdb_Ver_CheckedChanged

        Sb_InsertarBotonenGrilla(Grilla_Potpr, "Btn_Ico", "Ico", "Inf.", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grillas()

        Me.ActiveControl = Txt_Descripcion

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

    End Sub

    Sub Sb_Actualizar_Grillas_Old()

        Try

            Me.Enabled = False

            Dim _Filtro As String
            _Filtro = CADENA_A_BUSCAR(RTrim$(Txt_Descripcion.Text), "NUMOT+REFERENCIA LIKE '%")

            Dim _Select_Tablas As String

            Dim _Filtro_Tipo_OT = String.Empty

            If _Tipo_OT = Enum_Tipo_OT.Fabricacion Then

                _Filtro_Tipo_OT = String.Empty

            ElseIf _Tipo_OT = Enum_Tipo_OT.Servicio_Tecnico Then

                _Filtro_Tipo_OT = "T"

            End If


            If Rdb_Ver_Abiertas.Checked Or Rdb_Ver_Terminadas.Checked Or Rdb_Ver_Suspendidas.Checked Then

                Dim _Chk As Integer = Convert.ToInt32(Not Rdb_Ver_Abiertas.Checked)

                Dim _Estado As String

                If Rdb_Ver_Suspendidas.Checked Then

                    _Select_Tablas = Environment.NewLine &
                                     "Delete #Paso_Pote Where ESTADO <> 'S'
                              SELECT Cast(0 As Bit) As Chk,*,Case ESTADO When 'C' Then 'Cerrada' When 'S' Then 'Suspendida' When 'V' Then 'Vigente' Else '??' End As ESTADO_OT 
                              FROM #Paso_Pote Order By NUMOT
                              SELECT * FROM #Paso_Potl WHERE IDPOTE In (SELECT IDPOTE FROM #Paso_Pote)
                                Order By PERTENECE,NREG
                              SELECT * FROM #Paso_Potpr WHERE IDPOTL In (SELECT IDPOTL FROM #Paso_Potl WHERE IDPOTE IN 
                              (SELECT IDPOTE FROM #Paso_Pote))
                              Order By ORDEN"

                Else

                    _Select_Tablas = Environment.NewLine &
                                     "UPDATE #Paso_Pote Set Terminada = 1 WHERE ESTADO = 'C'
                              SELECT Cast(0 As Bit) As Chk,*,Case ESTADO When 'C' Then 'Cerrada' When 'S' Then 'Suspendida' When 'V' Then 'Vigente' Else '??' End As ESTADO_OT 
                              FROM #Paso_Pote WHERE Terminada = " & _Chk & " Order By NUMOT
                              SELECT * FROM #Paso_Potl WHERE IDPOTE In (SELECT IDPOTE FROM #Paso_Pote WHERE Terminada = " & _Chk & ")
                                Order By PERTENECE,NREG
                              SELECT * FROM #Paso_Potpr WHERE IDPOTL In (SELECT IDPOTL FROM #Paso_Potl WHERE IDPOTE IN 
                              (SELECT IDPOTE FROM #Paso_Pote WHERE Terminada = " & _Chk & ")) 
                               Order By ORDEN"

                End If

            ElseIf Rdb_Ver_Todas.Checked Then

                _Select_Tablas = Environment.NewLine &
                                 "SELECT Cast(0 As Bit) As Chk,*,Case ESTADO When 'C' Then 'Cerrada' When 'S' Then 'Suspendida' When 'V' Then 'Vigente' Else '??' End As ESTADO_OT 
                                FROM #Paso_Pote Order By NUMOT
                              SELECT * FROM #Paso_Potl
                                Order By PERTENECE,NREG
                              SELECT * FROM #Paso_Potpr
                              Order By ORDEN"

            End If

            Consulta_sql = My.Resources.Recursos_Gestion_Meson.Buscar_OT_Para_Asignar_Meson
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)
            Consulta_sql = Replace(Consulta_sql, "#Tipo_OT#", _Filtro_Tipo_OT)
            Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)
            Consulta_sql = Replace(Consulta_sql, "#Select_Tablas#", _Select_Tablas)


            _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

            ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
            ' Table.Rel_Entidad_Documentos.Rel_Documentos_Detalle

            _Ds.Relations.Add("Rel_OT_x_SOT",
                             _Ds.Tables("Table").Columns("NUMOT"),
                             _Ds.Tables("Table1").Columns("NUMOT"), False)

            _Ds.Relations.Add("Rel_SOT_x_PROC",
                             _Ds.Tables("Table1").Columns("IDPOTL"),
                             _Ds.Tables("Table2").Columns("IDPOTL"), False)

            Grilla_Pote.DataSource = _Ds
            Grilla_Pote.DataMember = "Table"

            Grilla_Potl.DataSource = _Ds
            Grilla_Potl.DataMember = "Table.Rel_OT_x_SOT"

            Grilla_Potpr.DataSource = _Ds
            Grilla_Potpr.DataMember = "Table.Rel_OT_x_SOT.Rel_SOT_x_PROC"

            'Muestra tercera relacion
            'Grilla_Maquinas.DataSource = _Ds
            'Grilla_Maquinas.DataMember = "Table.Rel_Maquinas_x_Meson"

            OcultarEncabezadoGrilla(Grilla_Pote, True)
            OcultarEncabezadoGrilla(Grilla_Potl, True)
            OcultarEncabezadoGrilla(Grilla_Potpr, True)

            '_Tbl_Mesones = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _DisplayIndex = 0

            With Grilla_Pote

                .Columns("Chk").Visible = True
                .Columns("Chk").HeaderText = "Sel"
                .Columns("Chk").ReadOnly = False
                .Columns("Chk").Width = 30
                .Columns("Chk").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NUMOT").Visible = True
                .Columns("NUMOT").HeaderText = "Nro. OT"
                .Columns("NUMOT").Width = 75
                .Columns("NUMOT").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("ESTADO_OT").Visible = True
                .Columns("ESTADO_OT").HeaderText = "Estado"
                .Columns("ESTADO_OT").Width = 70
                .Columns("ESTADO_OT").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("REFERENCIA").Visible = True
                .Columns("REFERENCIA").HeaderText = "Referencia"
                .Columns("REFERENCIA").Width = 305
                .Columns("REFERENCIA").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FIOT").Visible = True
                .Columns("FIOT").HeaderText = "Fecha"
                .Columns("FIOT").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FIOT").Width = 65
                .Columns("FIOT").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Grado_Prioridad").Visible = True
                .Columns("Grado_Prioridad").HeaderText = "Prioridad"
                .Columns("Grado_Prioridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Grado_Prioridad").Width = 60
                .Columns("Grado_Prioridad").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

            For Each _Fila As DataGridViewRow In Grilla_Pote.Rows

                Dim _Grado = _Fila.Cells("Grado_Prioridad").Value

                If _Grado = 1 Then

                    If Global_Thema <> Enum_Themas.Oscuro Then
                        _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
                    End If

                    _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.Red

                ElseIf _Grado = 2 Then

                    _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.Yellow

                Else

                    If Global_Thema <> Enum_Themas.Oscuro Then
                        _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
                        _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.White
                    End If

                End If

            Next

            With Grilla_Potl

                _DisplayIndex = 0

                .Columns("ACTIVE").Visible = True
                .Columns("ACTIVE").HeaderText = "Estatus"
                .Columns("ACTIVE").Width = 80
                .Columns("ACTIVE").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("PERTENECE").Visible = True
                .Columns("PERTENECE").HeaderText = "Padre"
                .Columns("PERTENECE").Width = 40
                .Columns("PERTENECE").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NREG").Visible = True
                .Columns("NREG").HeaderText = "SubOt"
                .Columns("NREG").Width = 45
                .Columns("NREG").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("CODIGO").Visible = True
                .Columns("CODIGO").HeaderText = "Código"
                .Columns("CODIGO").Width = 100
                .Columns("CODIGO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("GLOSA").Visible = True
                .Columns("GLOSA").HeaderText = "Descripción producto"
                .Columns("GLOSA").Width = 360 - 70
                .Columns("GLOSA").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FABRICAR").Visible = True
                .Columns("FABRICAR").HeaderText = "Cant.Fab"
                .Columns("FABRICAR").Width = 50
                .Columns("FABRICAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("FABRICAR").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With


            With Grilla_Potpr

                _DisplayIndex = 0

                .Columns("Btn_Ico").Visible = True
                .Columns("Btn_Ico").HeaderText = "A."
                .Columns("Btn_Ico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Btn_Ico").Width = 30
                .Columns("Btn_Ico").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("OPERACION").Visible = True
                .Columns("OPERACION").HeaderText = "Oper."
                .Columns("OPERACION").Width = 50
                .Columns("OPERACION").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Est_Meson").Visible = True
                .Columns("Est_Meson").HeaderText = "ES"
                .Columns("Est_Meson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Est_Meson").Width = 25
                .Columns("Est_Meson").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NOMBREOP").Visible = True
                .Columns("NOMBREOP").HeaderText = "Nombre operación"
                .Columns("NOMBREOP").Width = 250
                .Columns("NOMBREOP").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nommeson").Visible = True
                .Columns("Nommeson").HeaderText = "Mesón por defecto"
                .Columns("Nommeson").Width = 260
                .Columns("Nommeson").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

            If Convert.ToBoolean(Grilla_Pote.Rows.Count) Then
                Grilla_Pote.CurrentCell = Grilla_Pote.Rows(0).Cells("NUMOT")
            End If

            If Convert.ToBoolean(Grilla_Potl.Rows.Count) Then
                Grilla_Potl.CurrentCell = Grilla_Potl.Rows(0).Cells("ACTIVE")
            End If

            If Convert.ToBoolean(Grilla_Potpr.Rows.Count) Then
                Grilla_Potpr.CurrentCell = Grilla_Potpr.Rows(0).Cells("OPERACION")
            End If

            Sb_Pintar_Grillas_Potl()

        Catch ex As Exception
        Finally

            Btn_Abrir_OT_Ms.Enabled = (Rdb_Ver_Suspendidas.Checked Or Rdb_Ver_Terminadas.Checked)
            Btn_Suspender_OT_Ms.Enabled = (Rdb_Ver_Abiertas.Checked Or Rdb_Ver_Terminadas.Checked)
            Btn_Cerrar_OT_Ms.Enabled = (Rdb_Ver_Abiertas.Checked Or Rdb_Ver_Suspendidas.Checked)

            'Fm_Espera.Dispose()
            Me.Enabled = True
        End Try

    End Sub

    Sub Sb_Actualizar_Grillas()

        Try

            Me.Enabled = False

            Dim _Filtro As String
            _Filtro = CADENA_A_BUSCAR(RTrim$(Txt_Descripcion.Text), "NUMOT+REFERENCIA LIKE '%")

            Dim _NuevoFiltro = String.Empty

            If Not String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
                _Filtro = CADENA_A_BUSCAR(RTrim$(Txt_Descripcion.Text), "NUMOT+REFERENCIA LIKE '%")
                _NuevoFiltro += "And NUMOT+REFERENCIA LIKE '%" & _Filtro & "%'" & vbCrLf
            End If

            If Not String.IsNullOrEmpty(Txt_BuscarXEntidad.Text.Trim) Then
                _NuevoFiltro += "And IDPOTE In" & vbCrLf &
                               "(SELECT IDPOTE FROM POTL WITH (NOLOCK) INNER JOIN POTLCOM WITH (NOLOCK) ON POTLCOM.IDPOTL=POTL.IDPOTL" & vbCrLf &
                                "WHERE POTLCOM.ENDO LIKE '%" & Txt_BuscarXEntidad.Text.Trim & "%' And POTL.EMPRESA = '" & ModEmpresa & "')" & vbCrLf
            End If

            If Not String.IsNullOrEmpty(Txt_BuscarXProducto.Text.Trim) Then
                '_Filtro = CADENA_A_BUSCAR(RTrim$(Txt_BuscarXProducto.Text), "NUMOT+REFERENCIA LIKE '%")
                _NuevoFiltro += "And IDPOTE In (SELECT IDPOTE FROM POTL WITH (NOLOCK) " &
                    "WHERE CODIGO LIKE '%" & Txt_BuscarXProducto.Text.Trim & "%' And EMPRESA = '" & ModEmpresa & "')" & vbCrLf
            End If

            If Not String.IsNullOrEmpty(Txt_BuscarXInsumo.Text.Trim) Then
                '_Filtro = CADENA_A_BUSCAR(RTrim$(Txt_BuscarXProducto.Text), "NUMOT+REFERENCIA LIKE '%")
                _NuevoFiltro += "And IDPOTE In (Select IDPOTE From POTL Where IDPOTL In " &
                    "(SELECT IDPOTL FROM POTD WITH (NOLOCK) WHERE EMPRESA = '" & ModEmpresa & "' AND CODIGO LIKE '%" & Txt_BuscarXInsumo.Text.Trim & "%'))" & vbCrLf
            End If

            Dim _Select_Tablas As String

            Dim _Filtro_Tipo_OT = String.Empty

            If _Tipo_OT = Enum_Tipo_OT.Fabricacion Then

                _Filtro_Tipo_OT = String.Empty

            ElseIf _Tipo_OT = Enum_Tipo_OT.Servicio_Tecnico Then

                _Filtro_Tipo_OT = "T"

            End If


            If Rdb_Ver_Abiertas.Checked Or Rdb_Ver_Terminadas.Checked Or Rdb_Ver_Suspendidas.Checked Then

                Dim _Chk As Integer = Convert.ToInt32(Not Rdb_Ver_Abiertas.Checked)

                Dim _Estado As String

                If Rdb_Ver_Suspendidas.Checked Then

                    _Select_Tablas = Environment.NewLine &
                                     "Delete #Paso_Pote Where ESTADO <> 'S'
                              SELECT Cast(0 As Bit) As Chk,*,Case ESTADO When 'C' Then 'Cerrada' When 'S' Then 'Suspendida' When 'V' Then 'Vigente' Else '??' End As ESTADO_OT 
                              FROM #Paso_Pote Order By NUMOT
                              SELECT * FROM #Paso_Potl WHERE IDPOTE In (SELECT IDPOTE FROM #Paso_Pote)
                                Order By PERTENECE,NREG"

                Else

                    _Select_Tablas = Environment.NewLine &
                                     "UPDATE #Paso_Pote Set Terminada = 1 WHERE ESTADO = 'C'
                              SELECT Cast(0 As Bit) As Chk,*,Case ESTADO When 'C' Then 'Cerrada' When 'S' Then 'Suspendida' When 'V' Then 'Vigente' Else '??' End As ESTADO_OT 
                              FROM #Paso_Pote WHERE Terminada = " & _Chk & " Order By NUMOT
                              SELECT * FROM #Paso_Potl WHERE IDPOTE In (SELECT IDPOTE FROM #Paso_Pote WHERE Terminada = " & _Chk & ")
                                Order By PERTENECE,NREG"

                End If

            ElseIf Rdb_Ver_Todas.Checked Then

                _Select_Tablas = Environment.NewLine &
                                 "SELECT Cast(0 As Bit) As Chk,*,Case ESTADO When 'C' Then 'Cerrada' When 'S' Then 'Suspendida' When 'V' Then 'Vigente' Else '??' End As ESTADO_OT 
                                FROM #Paso_Pote Order By NUMOT
                              SELECT * FROM #Paso_Potl
                                Order By PERTENECE,NREG"

            End If

            Consulta_sql = My.Resources.Recursos_Gestion_Meson.Buscar_OT_Para_Asignar_Meson2
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            'Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)
            Consulta_sql = Replace(Consulta_sql, "#NuevoFiltro#", _NuevoFiltro)
            Consulta_sql = Replace(Consulta_sql, "#Tipo_OT#", _Filtro_Tipo_OT)
            Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)
            Consulta_sql = Replace(Consulta_sql, "#Select_Tablas#", _Select_Tablas)

            _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

            ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
            ' Table.Rel_Entidad_Documentos.Rel_Documentos_Detalle

            _Ds.Relations.Add("Rel_OT_x_SOT",
                             _Ds.Tables("Table").Columns("NUMOT"),
                             _Ds.Tables("Table1").Columns("NUMOT"), False)

            '_Ds.Relations.Add("Rel_SOT_x_PROC",
            '                 _Ds.Tables("Table1").Columns("IDPOTL"),
            '                 _Ds.Tables("Table2").Columns("IDPOTL"), False)

            '_dv.Table = _Sql.Fx_Get_DataSet(Consulta_sql, _Ds_Filtros_Busqueda, "Tbl_Filtro").Tables("Tbl_Filtro")

            Grilla_Pote.DataSource = _Ds
            Grilla_Pote.DataMember = "Table"

            Grilla_Potl.DataSource = _Ds
            Grilla_Potl.DataMember = "Table.Rel_OT_x_SOT"

            'Grilla_Potpr.DataSource = _Ds
            'Grilla_Potpr.DataMember = "Table.Rel_OT_x_SOT.Rel_SOT_x_PROC"

            'Muestra tercera relacion
            'Grilla_Maquinas.DataSource = _Ds
            'Grilla_Maquinas.DataMember = "Table.Rel_Maquinas_x_Meson"

            OcultarEncabezadoGrilla(Grilla_Pote, True)
            OcultarEncabezadoGrilla(Grilla_Potl, True)

            '_Tbl_Mesones = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _DisplayIndex = 0

            With Grilla_Pote

                .Columns("Chk").Visible = True
                .Columns("Chk").HeaderText = "Sel"
                .Columns("Chk").ReadOnly = False
                .Columns("Chk").Width = 30
                .Columns("Chk").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NUMOT").Visible = True
                .Columns("NUMOT").HeaderText = "Nro. OT"
                .Columns("NUMOT").Width = 75
                .Columns("NUMOT").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("ESTADO_OT").Visible = True
                .Columns("ESTADO_OT").HeaderText = "Estado"
                .Columns("ESTADO_OT").Width = 70
                .Columns("ESTADO_OT").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("REFERENCIA").Visible = True
                .Columns("REFERENCIA").HeaderText = "Referencia"
                .Columns("REFERENCIA").Width = 305 + 110
                .Columns("REFERENCIA").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FIOT").Visible = True
                .Columns("FIOT").HeaderText = "Fecha"
                .Columns("FIOT").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FIOT").Width = 65
                .Columns("FIOT").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Grado_Prioridad").Visible = True
                .Columns("Grado_Prioridad").HeaderText = "Prioridad"
                .Columns("Grado_Prioridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Grado_Prioridad").Width = 60
                .Columns("Grado_Prioridad").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("IDPOTE").Visible = True
                .Columns("IDPOTE").HeaderText = "idpote"
                .Columns("IDPOTE").Width = 40 + 10
                .Columns("IDPOTE").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

            For Each _Fila As DataGridViewRow In Grilla_Pote.Rows

                Dim _Grado = _Fila.Cells("Grado_Prioridad").Value

                If _Grado = 1 Then

                    If Global_Thema <> Enum_Themas.Oscuro Then
                        _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
                    End If

                    _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.Red

                ElseIf _Grado = 2 Then

                    _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.Yellow

                Else

                    If Global_Thema <> Enum_Themas.Oscuro Then
                        _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
                        _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.White
                    End If

                End If

            Next

            With Grilla_Potl

                _DisplayIndex = 0

                .Columns("ACTIVE").Visible = True
                .Columns("ACTIVE").HeaderText = "Estatus"
                .Columns("ACTIVE").Width = 80
                .Columns("ACTIVE").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("PERTENECE").Visible = True
                .Columns("PERTENECE").HeaderText = "Padre"
                .Columns("PERTENECE").Width = 40
                .Columns("PERTENECE").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NREG").Visible = True
                .Columns("NREG").HeaderText = "SubOt"
                .Columns("NREG").Width = 45
                .Columns("NREG").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("CODIGO").Visible = True
                .Columns("CODIGO").HeaderText = "Código"
                .Columns("CODIGO").Width = 100
                .Columns("CODIGO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("GLOSA").Visible = True
                .Columns("GLOSA").HeaderText = "Descripción producto"
                .Columns("GLOSA").Width = 440
                .Columns("GLOSA").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FABRICAR").Visible = True
                .Columns("FABRICAR").HeaderText = "Cant.Fab"
                .Columns("FABRICAR").Width = 60
                .Columns("FABRICAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("FABRICAR").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

            Dim _Idpotl As Integer

            Try
                _Idpotl = Grilla_Potl.Rows(0).Cells("IDPOTL").Value
            Catch ex As Exception
                _Idpotl = 0
            End Try

            Sb_Actualizar_Grilla_Potpr(_Idpotl)

            If Convert.ToBoolean(Grilla_Pote.Rows.Count) Then
                Grilla_Pote.CurrentCell = Grilla_Pote.Rows(0).Cells("NUMOT")
            End If

            If Convert.ToBoolean(Grilla_Potl.Rows.Count) Then
                Grilla_Potl.CurrentCell = Grilla_Potl.Rows(0).Cells("ACTIVE")
            End If

            If Convert.ToBoolean(Grilla_Potpr.Rows.Count) Then
                Grilla_Potpr.CurrentCell = Grilla_Potpr.Rows(0).Cells("OPERACION")
            End If

            Sb_Pintar_Grillas_Potl()

        Catch ex As Exception
        Finally

            Btn_Abrir_OT_Ms.Enabled = (Rdb_Ver_Suspendidas.Checked Or Rdb_Ver_Terminadas.Checked)
            Btn_Suspender_OT_Ms.Enabled = (Rdb_Ver_Abiertas.Checked Or Rdb_Ver_Terminadas.Checked)
            Btn_Cerrar_OT_Ms.Enabled = (Rdb_Ver_Abiertas.Checked Or Rdb_Ver_Suspendidas.Checked)

            'Fm_Espera.Dispose()
            Me.Enabled = True
        End Try

    End Sub

    Sub Sb_Actualizar_Grilla_Potpr(_Idpotl As Integer)

        Consulta_sql = "SELECT IDPOTPR,IDPOTL,NUMOT,NREGOTL,CODIGO,CODMAQOT,
                           POTPR.OPERACION,POTPR.ORDEN,
                           COALESCE(ORDEN,'000') As Orden2,
	                       FABRICAR,REALIZADO,FABRICAR-REALIZADO AS FALTANTE,
                           " & _Global_BaseBk & "Zw_Pdc_Mesones.Codmeson,NOMBREOP,Nommeson,Virtual,
	                       Isnull((SELECT Top 1 Estado
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),'') as Est_Meson,
	                       (SELECT COUNT(*) 
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR) as Activos, 
	                       (SELECT COUNT(*) 
	                        FROM " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos
		                    WHERE Idpotpr=IDPOTPR And Estado <> 'FMQ') as ActivosMaq,
		                    Isnull((SELECT Top 1 Saldo_Fabricar
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Saldo_Fabricar,
			                    Isnull((SELECT Top 1 Porc_Fabricacion
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Porc_Fabricacion,
			                    Isnull((SELECT Top 1 Reproceso
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Reproceso,
			                    Isnull((SELECT Top 1 Cant_Reproceso
		                    FROM  " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos 
			                    WHERE Idpotpr=IDPOTPR),0) as Cant_Reproceso

                    --Into #Paso_Potpr

		                    FROM POTPR 
			                    Left JOIN " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina ON 
				                    " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina.Codmaq=POTPR.CODMAQOT 
					                    Left JOIN " & _Global_BaseBk & "Zw_Pdc_Mesones ON 
						                    " & _Global_BaseBk & "Zw_Pdc_MesonVsMaquina.Codmeson=" & _Global_BaseBk & "Zw_Pdc_Mesones.Codmeson 
							                    INNER JOIN POPER ON 
								                    POPER.OPERACION=POTPR.OPERACION 
                    WHERE IDPOTL = " & _Idpotl & "
                    ORDER BY ORDEN"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        OcultarEncabezadoGrilla(Grilla_Potpr, True)

        With Grilla_Potpr

            Dim _DisplayIndex = 0

            .DataSource = _Tbl

            .Columns("Btn_Ico").Visible = True
            .Columns("Btn_Ico").HeaderText = "A."
            .Columns("Btn_Ico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Btn_Ico").Width = 30
            .Columns("Btn_Ico").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OPERACION").Visible = True
            .Columns("OPERACION").HeaderText = "Oper."
            .Columns("OPERACION").Width = 50
            .Columns("OPERACION").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Est_Meson").Visible = True
            .Columns("Est_Meson").HeaderText = "ES"
            .Columns("Est_Meson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Est_Meson").Width = 25
            .Columns("Est_Meson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOMBREOP").Visible = True
            .Columns("NOMBREOP").HeaderText = "Nombre operación"
            .Columns("NOMBREOP").Width = 330
            .Columns("NOMBREOP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nommeson").Visible = True
            .Columns("Nommeson").HeaderText = "Mesón por defecto"
            .Columns("Nommeson").Width = 340
            .Columns("Nommeson").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Sb_CheckActiveSOT()
        'cambia el color de alguna columna de la grilla dependiendo su valor
        For Each Row As DataGridViewRow In Grilla_Potl.Rows
            If Grilla_Potl.Item("ACTIVE", Row.Index).Value > 0 Then
                Grilla_Potl.Item("NREG", Row.Index).Style.BackColor = Color.FromName("Green")
            Else
                Grilla_Potl.Item("NREG", Row.Index).Style.BackColor = Color.FromName("White")
            End If
        Next
    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grillas()
        End If
    End Sub

    Private Sub Btn_Mnu_Enviar_Al_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Enviar_Al_Meson.Click

        Dim _Fila_Pote As DataGridViewRow
        Dim _Fila_Potl As DataGridViewRow
        Dim _Fila_Potpr As DataGridViewRow

        Try
            _Fila_Pote = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Pote = Grilla_Pote.Rows(0)
        End Try

        Try
            _Fila_Potl = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potl = Grilla_Potl.Rows(0)
        End Try

        Try
            _Fila_Potpr = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potpr = Grilla_Potpr.Rows(0)
        End Try

        Dim _Codmeson As String = _Fila_Potpr.Cells("Codmeson").Value
        Dim _Idpotpr As Integer = _Fila_Potpr.Cells("IDPOTPR").Value
        Dim _Idpotl As Integer = _Fila_Potpr.Cells("IDPOTL").Value
        Dim _Idpote As Integer = _Fila_Pote.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila_Pote.Cells("NUMOT").Value
        Dim _Nreg As String = _Fila_Potl.Cells("NREG").Value
        Dim _Nivel As Integer = _Fila_Potl.Cells("NIVEL").Value
        Dim _Codigo As String = _Fila_Potpr.Cells("CODIGO").Value
        Dim _Operacion As String = _Fila_Potpr.Cells("OPERACION").Value
        Dim _Nombreop As String = _Fila_Potpr.Cells("NOMBREOP").Value
        Dim _Glosa As String = _Fila_Potl.Cells("GLOSA").Value
        Dim _Fabricar As Integer = _Fila_Potpr.Cells("FABRICAR").Value
        Dim _Realizado As Integer = _Fila_Potpr.Cells("REALIZADO").Value
        Dim _Faltante As Integer = _Fila_Potpr.Cells("FALTANTE").Value
        Dim _Orden_Potpr As Integer = _Fila_Potpr.Cells("ORDEN").Value
        Dim _Est_Meson As String = _Fila_Potpr.Cells("Est_Meson").Value.ToString.Trim

        Dim _Orden_Meson As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                  "Max(Orden_Meson)", "Codmeson = '" & _Codmeson & "'", True) + 1

        If _Est_Meson = "PS" Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set " & vbCrLf &
                           "Fecha_Asignacion = Getdate(),Estado = 'PD'" & vbCrLf &
                           "Where Idpotpr = " & _Idpotpr
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                _Fila_Potpr.DefaultCellStyle.BackColor = Color.LightYellow
                _Fila_Potpr.DefaultCellStyle.ForeColor = Color.Black
                _Fila_Potpr.Cells("Est_Meson").Value = "PD"
                Beep()
                ToastNotification.Show(Me, "PRODUCTO ACTIVADO" & vbCrLf & "CORRECTAMENTE", Nothing,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                Return
            End If

        Else

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote,
                        Empresa,Numot,Nreg,Estado,Desde,Orden_Potpr,Operacion,Nombreop,Codigo,Glosa,Asignado_Por,
                        Fecha_Asignacion,Fabricar_Recep,Fabricado_Recep,
                        Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT,Fabricar,
                        Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Meson,Nivel) " & "
                        Values('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & ModEmpresa & "',
                        '" & _Numot & "','" & _Nreg & "','PD','OR'," & _Orden_Potpr & ",'" & _Operacion & "','" & _Nombreop & "',
                        '" & _Codigo & "','" & _Glosa & "','" & FUNCIONARIO & "',GETDATE(),
                        " & _Fabricar & "," & _Realizado & "," & _Fabricar & "," & _Realizado & ",
                        " & _Faltante & "," & _Fabricar & ",0," & _Fabricar &
                        ",'" & FUNCIONARIO & "'," & _Orden_Meson & "," & _Nivel & ")"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Sb_Actualizar_Grillas()

        If BuscarDatoEnGrilla(Trim(_Numot), "NUMOT", Grilla_Pote) Then

            Grilla_Pote.CurrentCell = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index).Cells("NUMOT")
            Grilla_Pote.Focus()

            If BuscarDatoEnGrilla(Trim(_Nreg), "NREG", Grilla_Potl) Then

                Grilla_Potl.CurrentCell = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index).Cells("ACTIVE")
                Grilla_Potl.Focus()

            End If

            Sb_Pintar_Grillas_Potl()

            Beep()
            ToastNotification.Show(Me, "PRODUCTO ASIGNADO AL MESON" & vbCrLf & "CORRECTAMENTE", Nothing,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Grilla_OT_Vigentes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Pote.CellEnter
        Sb_Pintar_Grillas_Potl()
    End Sub

    Sub Sb_Pintar_Grillas_Potl()

        For Each _Fila_01 As DataGridViewRow In Grilla_Potl.Rows

            Dim _Nivel As Integer = _Fila_01.Cells("NIVEL").Value
            Dim _Active As String = _Fila_01.Cells("ACTIVE").Value
            Dim _Padre As String = _Fila_01.Cells("PERTENECE").Value
            Dim _Nreg As String = _Fila_01.Cells("NREG").Value

            If _Nreg <> _Padre Then
                _Fila_01.Cells("PERTENECE").Value = String.Empty
            End If

            If _Nivel = 0 Then
                _Fila_01.DefaultCellStyle.BackColor = Color.LightYellow
            End If

            If _Active = "EN ESPERA" Then
                _Fila_01.DefaultCellStyle.ForeColor = Color.Black
            End If

            If _Active = "EN PROCESO" Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    If _Fila_01.DefaultCellStyle.BackColor = Color.LightYellow Then
                        _Fila_01.DefaultCellStyle.ForeColor = Color.Green
                    Else
                        _Fila_01.DefaultCellStyle.ForeColor = Color.LightGreen
                    End If
                Else
                    _Fila_01.DefaultCellStyle.ForeColor = Color.Green
                End If
            End If

        Next

        Sb_Pintar_Grillas_Potpr()

    End Sub

    Sub Sb_Pintar_Grillas_Potpr()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim _Fila_Potl As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
            Dim _Active As String = _Fila_Potl.Cells("ACTIVE").Value

            Dim _Normales_Activos = 0

            For Each _Fila_02 As DataGridViewRow In Grilla_Potpr.Rows

                Dim _Activos As Boolean = CBool(_Fila_02.Cells("Activos").Value)
                Dim _Virtual As Boolean = CBool(_Fila_02.Cells("Virtual").Value)

                If _Activos Then
                    If Not _Virtual Then
                        _Normales_Activos += 1
                    End If
                End If

            Next

            For Each _Fila_02 As DataGridViewRow In Grilla_Potpr.Rows

                Dim _Est_Meson As String = _Fila_02.Cells("Est_Meson").Value
                Dim _Activos As Boolean = CBool(_Fila_02.Cells("Activos").Value)
                Dim _Virtual As Boolean = CBool(_Fila_02.Cells("Virtual").Value)

                Dim _Idpote As Integer = _Fila_Potl.Cells("IDPOTE").Value
                Dim _Operacion As String = _Fila_02.Cells("OPERACION").Value

                Dim _Reg_Alertas = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MesonVsAlertas",
                                                            "Idpote = " & _Idpote & " And Operacion = '" & _Operacion & "' And Editada = 0 And Eliminada = 0")

                _Fila_02.Cells("Btn_Ico").Value = Imagenes_16x16.Images.Item(0)

                If CBool(_Reg_Alertas) Then
                    _Fila_02.Cells("Btn_Ico").Value = Imagenes_16x16.Images.Item(1)
                End If

                If _Activos Then

                    If _Est_Meson = "FZ" Or _Est_Meson = "RP" Or _Est_Meson = "PT" Or _Est_Meson = "CE" Then
                        _Fila_02.DefaultCellStyle.ForeColor = Color.Gray
                    ElseIf _Est_Meson = "PS" Then
                        _Fila_02.DefaultCellStyle.ForeColor = Rojo
                    Else
                        _Fila_02.DefaultCellStyle.BackColor = Color.LightYellow
                        If Global_Thema = Enum_Themas.Oscuro Then
                            _Fila_02.DefaultCellStyle.ForeColor = Color.Black
                        End If
                    End If

                Else

                    If Not _Virtual Then
                        If CBool(_Normales_Activos) Then
                            _Fila_02.DefaultCellStyle.ForeColor = Color.Gray
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Btn_Quitar_Del_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Del_Meson.Click

        Dim _Fila_Pote As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
        Dim _Numot = _Fila_Pote.Cells("NUMOT").Value

        Dim _Fila_Potl As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Dim _Nreg As String = _Fila_Potl.Cells("NREG").Value

        Dim _Fila_Potpr As DataGridViewRow = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)
        Dim _Codmeson As String = _Fila_Potpr.Cells("Codmeson").Value
        Dim _Idpotpr As Integer = _Fila_Potpr.Cells("IDPOTPR").Value

        Consulta_sql = "SELECT TOP 1 * FROM " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos WHERE Idpotpr = " & _Idpotpr
        Dim _Row_Maquina_vs_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Maquina_vs_Producto) Then
            Dim _Maquina As String = Trim(_Row_Maquina_vs_Producto.Item("CodMaq")) & " - " & Trim(_Row_Maquina_vs_Producto.Item("Descripcion"))
            MessageBoxEx.Show(Me, "No se puede quitar este producto del mesón ya que esta siendo procesado por la maquina:" & _Maquina,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            If MessageBoxEx.Show(Me, "¿ Desea retirar este trabajo del mesón asignado?", "Quitar producto del mesón",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "DELETE FROM " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos WHERE Idpotpr = " &
                                _Idpotpr & " AND Codmeson='" & _Codmeson & "';"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Sb_Actualizar_Grillas()

                If BuscarDatoEnGrilla(Trim(_Numot), "NUMOT", Grilla_Pote) Then
                    Grilla_Pote.CurrentCell = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index).Cells("NUMOT")
                    Grilla_Pote.Focus()

                    If BuscarDatoEnGrilla(Trim(_Nreg), "NREG", Grilla_Potl) Then
                        Grilla_Potl.CurrentCell = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index).Cells("ACTIVE")
                        Grilla_Potl.Focus()
                    End If

                    Sb_Pintar_Grillas_Potl()

                    Beep()
                    ToastNotification.Show(Me, "PRODUCTO QUITADO DEL MESON" & vbCrLf & "CORRECTAMENTE", Nothing,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If

            End If

        End If

    End Sub

    Private Sub Grilla_Potl_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Potl.CellEnter

        Try
            Dim _Fila_Potl As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)

            Dim _Idpotl As Integer = _Fila_Potl.Cells("IDPOTL").Value
            Sb_Actualizar_Grilla_Potpr(_Idpotl)

            Dim _SubOt = _Fila_Potl.Cells("NREG").Value
            GroupPanel3.Text = "Porcesos Sub-OT: " & _SubOt.ToString.Trim

            Sb_Pintar_Grillas_Potpr()

            If Not BuscarDatoEnGrilla("PD", "Est_Meson", Grilla_Potpr) Then
                BuscarDatoEnGrilla("MQ", "Est_Meson", Grilla_Potpr)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_Potpr_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Potpr.CellDoubleClick

        Dim _Cabeza = sender.Columns(sender.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)

        Dim _Fila_Potl As DataGridViewRow
        Dim _Fila_Potpr As DataGridViewRow

        Try
            _Fila_Potl = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potl = Grilla_Potl.Rows(0)
        End Try

        Try
            _Fila_Potpr = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potpr = Grilla_Potpr.Rows(0)
        End Try

        Dim _Idpotpr As Integer = _Fila_Potpr.Cells("IDPOTPR").Value
        Dim _Operacion As String = _Fila_Potpr.Cells("OPERACION").Value

        Dim _Producto_Activo As String = _Fila_Potl.Cells("ACTIVE").Value

        Dim _Activos_Maq As Integer = _Fila_Potpr.Cells("ActivosMaq").Value
        Dim _Activos As Boolean = CBool(_Fila_Potpr.Cells("Activos").Value)
        Dim _Virtual As Boolean = CBool(_Fila_Potpr.Cells("Virtual").Value)
        Dim _Est_Meson As String = Trim(_Fila_Potpr.Cells("Est_Meson").Value)
        Dim _Reproceso As Boolean = CBool(_Fila_Potpr.Cells("Reproceso").Value)

        Btn_Mnu_Enviar_Al_Meson.Enabled = (Not _Activos Or _Est_Meson = "PS")
        Btn_Mnu_Enviar_Al_Meson.Text = "Enviar producto al mesón"
        If _Est_Meson = "PS" Then Btn_Mnu_Enviar_Al_Meson.Text = "Activar producto en el mesón"

        Btn_Reimprimir_Comprobante_EnvRec.Enabled = (_Est_Meson = "FZ" Or _Est_Meson = "PT")

        Btn_Quitar_Del_Meson.Enabled = _Activos

        Btn_Mnu_Incorporar_Reproceso.Enabled = False

        Dim _Existe_Alerta As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MesonVsAlertas",
                                                                  "Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Eliminada = 0")

        If _Est_Meson <> "FZ" And Not String.IsNullOrEmpty(_Est_Meson) Then
            Btn_Mnu_Incorporar_Reproceso.Enabled = Not _Reproceso
        End If


        If _Producto_Activo = "EN PROCESO" Then

            If Not _Virtual And Not _Activos Then

                Dim _Normales_Activos = 0
                Dim _Fz = 0
                Dim _Pd = 0
                Dim _Vac = 0
                Dim _Pt = 0

                For Each _Fila_02 As DataGridViewRow In Grilla_Potpr.Rows

                    _Activos = CBool(_Fila_02.Cells("Activos").Value)
                    _Virtual = CBool(_Fila_02.Cells("Virtual").Value)
                    _Est_Meson = _Fila_02.Cells("Est_Meson").Value

                    If _Activos Then
                        If Not _Virtual Then
                            _Normales_Activos += 1
                        End If
                    End If

                    Select Case _Est_Meson
                        Case "FZ"
                            _Fz += 1
                        Case "PD"
                            _Pd += 1
                        Case ""
                            _Vac += 1
                        Case "PT"
                            _Pt += 1
                    End Select

                Next

                If ((_Fz + _Vac) < Grilla_Potpr.RowCount) And Not CBool(_Pd) Then

                Else
                    If CBool(_Normales_Activos) Then
                        Btn_Mnu_Enviar_Al_Meson.Enabled = False
                        Btn_Quitar_Del_Meson.Enabled = False
                    End If
                End If

            End If

        End If

        If _Cabeza = "Btn_Ico" Then
            Call Btn_Alertas_Click(Nothing, Nothing)
        Else
            ShowContextMenu(Menu_Contextual_Potpr)
        End If

    End Sub

    Private Sub Mnu_Btn_Imprimir_Hoja_De_Ruta_Todas_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Imprimir_Hoja_De_Ruta_Todas.Click

        Dim _Impresora As String = String.Empty

        For Each _Fila As DataGridViewRow In Grilla_Potl.Rows

            Dim _Numot = _Fila.Cells("NUMOT").Value
            Dim _SubOt = _Fila.Cells("NREG").Value

            Dim _Clas_Imp As New Clas_Impirmir_Operaciones_OT_Barras()

            _Clas_Imp.Pro_Nro_OT = _Numot
            _Clas_Imp.Pro_Sub_OT = _SubOt
            _Clas_Imp.Fx_Imprimir_Archivo(Me, "HOJA DE RUTA", _Impresora,
                                          Clas_Impirmir_Operaciones_OT_Barras._Enum_Tipo_Impresion.Hoja_de_ruta)

        Next

    End Sub

    Private Sub Mnu_Btn_Imprimir_Hoja_De_Ruta_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Imprimir_Hoja_De_Ruta.Click

        Dim _Fila As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)

        Dim _Numot = _Fila.Cells("NUMOT").Value
        Dim _SubOt = _Fila.Cells("NREG").Value

        Dim _Clas_Imp As New Clas_Impirmir_Operaciones_OT_Barras()
        _Clas_Imp.Pro_Nro_OT = _Numot
        _Clas_Imp.Pro_Sub_OT = _SubOt
        _Clas_Imp.Fx_Imprimir_Archivo(Me, "HOJA DE RUTA", "", Clas_Impirmir_Operaciones_OT_Barras._Enum_Tipo_Impresion.Hoja_de_ruta)

    End Sub

    Private Sub Grilla_Pote_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Pote.CellDoubleClick

        Sb_Opciones_Pote()

    End Sub

    Sub Sb_Opciones_Pote()

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Idpote = _Fila.Cells("IDPOTE").Value
        Dim _Estado = _Fila.Cells("ESTADO").Value

        Select Case _Estado

            Case "V"

                Btn_Abrir_OT.Enabled = False
                Btn_Cerrar_OT.Enabled = True
                Btn_Pausar_Iniciar_OT.Enabled = True
                Btn_Enviar_Productos_a_los_Mesones.Enabled = True
                Btn_Quitar_Todo.Enabled = False

                For Each _Fila_Potl As DataGridViewRow In Grilla_Potl.Rows

                    Dim _Active As String = _Fila_Potl.Cells("ACTIVE").Value

                    If _Active = "EN PROCESO" Then
                        Btn_Enviar_Productos_a_los_Mesones.Enabled = False
                        Btn_Quitar_Todo.Enabled = True
                        Exit For
                    End If

                Next

            Case "C", "S"

                Btn_Abrir_OT.Enabled = True
                Btn_Cerrar_OT.Enabled = False
                Btn_Pausar_Iniciar_OT.Enabled = False
                Btn_Enviar_Productos_a_los_Mesones.Enabled = False
                Btn_Quitar_Todo.Enabled = False

            Case Else

                Btn_Abrir_Cerrar_OT.Enabled = False

        End Select

        Mnu_Btn_Imprimir_Hoja_De_Ruta.Visible = False
        Mnu_Btn_Imprimir_Hoja_De_Ruta_Todas.Visible = True


        Dim _Grado_Prioridad As Integer = _Fila.Cells("Grado_Prioridad").Value

        If _Grado_Prioridad = 0 Then
            Rdb_Prioridad_0.Checked = True
        ElseIf _Grado_Prioridad = 1 Then
            Rdb_Prioridad_1.Checked = True
        ElseIf _Grado_Prioridad = 2 Then
            Rdb_Prioridad_2.Checked = True
        End If

        ShowContextMenu(Menu_Contextual_Pote)

    End Sub

    Private Sub Grilla_Potl_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Potl.CellDoubleClick
        Mnu_Btn_Imprimir_Hoja_De_Ruta.Visible = True
        ShowContextMenu(Menu_Contextual_Potl)
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)

        Dim _Idpote = _Fila.Cells("IDPOTE").Value
        Dim _SubOt = _Fila.Cells("NREG").Value

        Dim _Idpdatfae As Integer

        Dim _DFA As New Clas_Crear_DFA_Desde_Meson(_Idpote, _SubOt)
        _DFA.Sb_Crear_Dfa()
        _Idpdatfae = _DFA.Fx_Crear_Documento()

    End Sub

    Private Sub Grilla_Pote_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla_Pote.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Sb_Opciones_Pote()

                End If

            End With

        End If

    End Sub

    Private Sub Sb_Rdb_Prioridad_Click(sender As Object, e As EventArgs)

        If CType(sender, CheckBoxItem).Checked Then

            Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
            Dim _Msg As String

            If Rdb_Prioridad_0.Checked Then

                _Fila.Cells("Grado_Prioridad").Value = 0
                _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
                _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.White
                _Msg = "La OT se quito de las prioridades"

            End If

            If Rdb_Prioridad_1.Checked Then

                _Fila.Cells("Grado_Prioridad").Value = 1
                _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
                _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.Red
                _Msg = "La OT queda como prioridad Grado 1"

            End If

            If Rdb_Prioridad_2.Checked Then

                _Fila.Cells("Grado_Prioridad").Value = 2
                _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.Black
                _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.LightYellow
                _Msg = "La OT queda como prioridad Grado 2"

            End If

            Dim _Grado_Prioridad As Integer = _Fila.Cells("Grado_Prioridad").Value
            Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value
            Dim _Numot As String = _Fila.Cells("NUMOT").Value

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdp_OT_Prioridad WHERE Idpote = " & _Idpote
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_OT_Prioridad (Idpote,Numot,Fecha_Prioridad,Grado) Values 
                        (" & _Idpote & ",'" & _Numot & "',Getdate()," & _Grado_Prioridad & ")"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(Me, _Msg, "Prioridad de OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Enviar_Productos_a_los_Mesones_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Productos_a_los_Mesones.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila.Cells("NUMOT").Value
        Dim _Esodd As String = _Fila.Cells("ESODD").Value

        Consulta_sql = My.Resources.Recursos_Gestion_Meson.Buscar_OT_Para_Asignar_Meson
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Numot)
        Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Tipo_OT#", _Esodd)

        Consulta_sql = Replace(Consulta_sql, "#Select_Tablas#",
                                             "Select * FROM #Paso_Pote SELECT * FROM #Paso_Potl SELECT * FROM #Paso_Potpr Order By Orden2 Asc")

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl_Pote As DataTable = _Ds.Tables(0)
        Dim _Tbl_Potl As DataTable = _Ds.Tables(1)
        Dim _Tbl_Potpr As DataTable = _Ds.Tables(2)

        For Each _Fila_Potl As DataRow In _Tbl_Potl.Rows

            Dim _Nreg As String = _Fila_Potl.Item("NREG")
            Dim _Nivel As Integer = _Fila_Potl.Item("NIVEL")
            Dim _Glosa As String = _Fila_Potl.Item("GLOSA")
            Dim _Idpotl_P As Integer = _Fila_Potl.Item("IDPOTL")
            Dim _Idpotl_Padre As Integer = _Fila_Potl.Item("Idpotl_Padre")

            Dim _Reg = _Sql.Fx_Cuenta_Registros("POTD", "IDPOTL = " & _Idpotl_P)
            Dim _Buscar_Especial = False
            Dim _CodMesonManda As String = String.Empty

            For Each _Fila_Potpr As DataRow In _Tbl_Potpr.Rows

                Dim _Idpotl_H As Integer = _Fila_Potpr.Item("IDPOTL")

                If _Idpotl_P = _Idpotl_H Then

                    Dim _Codmeson As String = _Fila_Potpr.Item("Codmeson")
                    Dim _Idpotpr As Integer = _Fila_Potpr.Item("IDPOTPR")
                    Dim _Codigo As String = _Fila_Potpr.Item("CODIGO")
                    Dim _Operacion As String = _Fila_Potpr.Item("OPERACION")
                    Dim _Nombreop As String = _Fila_Potpr.Item("NOMBREOP").ToString.Trim

                    Dim _Fabricar As Integer = _Fila_Potpr.Item("FABRICAR")
                    Dim _Realizado As Integer = _Fila_Potpr.Item("REALIZADO")
                    Dim _Faltante As Integer = _Fila_Potpr.Item("FALTANTE")
                    Dim _Orden_Potpr As Integer = _Fila_Potpr.Item("ORDEN")

                    Dim _Virtual As Boolean = _Fila_Potpr.Item("Virtual")
                    Dim _ActivaAlPrincipio As Boolean = _Fila_Potpr.Item("ActivaAlPrincipio")
                    Dim _Est_Meson As String = Trim(_Fila_Potpr.Item("Est_Meson"))

                    If Not _ActivaAlPrincipio Then
                        _CodMesonManda = _Codmeson.Trim
                    End If

                    If Not _Virtual And _Reg > 1 Then
                        Exit For
                    End If

                    If _Operacion = "ICPD" Then
                        Dim as33 = 22
                    End If

                    If _ActivaAlPrincipio Then
                        Dim rrrr = 33
                    End If

                    If String.IsNullOrEmpty(_Est_Meson) Then

                        Dim _Orden_Meson As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdp_MesonVsProductos",
                                                      "Max(Orden_Meson)", "Codmeson = '" & _Codmeson & "'", True) + 1

                        If _Buscar_Especial And _ActivaAlPrincipio Then

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote,
                                        Empresa,Numot,Nreg,Estado,Desde,Orden_Potpr,Operacion,Nombreop,Codigo,Glosa,Asignado_Por,
                                        Fecha_Asignacion,
                                        Fabricar_Recep,Fabricado_Recep,
                                        Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT,Fabricar,
                                        Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Meson,Nivel,Idpotl_Padre,AsignadoAlPrincipio,CodMesonManda) " &
                                        "VALUES('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl_H & "," & _Idpote & ",'" & ModEmpresa &
                                        "','" & _Numot & "','" & _Nreg & "','PD','OR'" &
                                        "," & _Orden_Potpr & ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                        "','" & FUNCIONARIO & "',Getdate()," &
                                        _Fabricar & "," & _Realizado & "," & _Fabricar & "," & _Realizado & "," & _Faltante & "," & _Fabricar & ",0," & _Fabricar &
                                        ",'" & FUNCIONARIO & "'," & _Orden_Meson & "," & _Nivel & "," & _Idpotl_Padre & ",1,'" & _CodMesonManda & "')"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        Else

                            If Not _Buscar_Especial Then

                                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos(Codmeson,Idpotpr,Idpotl,Idpote,
                                        Empresa,Numot,Nreg,Estado,Desde,Orden_Potpr,Operacion,Nombreop,Codigo,Glosa,Asignado_Por,
                                        Fecha_Asignacion,
                                        Fabricar_Recep,Fabricado_Recep,
                                        Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT,Fabricar,
                                        Fabricado,Saldo_Fabricar,Cod_Funcionario_Asigna,Orden_Meson,Nivel,Idpotl_Padre) " &
                                        "VALUES('" & _Codmeson & "'," & _Idpotpr & "," & _Idpotl_H & "," & _Idpote & ",'" & ModEmpresa &
                                        "','" & _Numot & "','" & _Nreg & "','PD','OR'" &
                                        "," & _Orden_Potpr & ",'" & _Operacion & "','" & _Nombreop & "','" & _Codigo & "','" & _Glosa &
                                        "','" & FUNCIONARIO & "',Getdate()," &
                                        _Fabricar & "," & _Realizado & "," & _Fabricar & "," & _Realizado & "," & _Faltante & "," & _Fabricar & ",0," & _Fabricar &
                                        ",'" & FUNCIONARIO & "'," & _Orden_Meson & "," & _Nivel & "," & _Idpotl_Padre & ")"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                        End If

                        If Not _Virtual Then
                            If _ActivaAlPrincipio Then
                                _Buscar_Especial = False
                            Else
                                _Buscar_Especial = True
                            End If
                            If Not _Buscar_Especial Then
                                Exit For
                            End If
                        End If

                    End If

                End If

            Next

        Next

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PS'
                        Where Idpotl_Padre In
                        (Select Idpotl From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Mp
                        Inner Join " & _Global_BaseBk & "Zw_Pdc_Mesones Ms On Mp.Codmeson = Ms.Codmeson
                        Where (Idpote = " & _Idpote & ")
                        And Ms.Maestro = 1) And Codmeson In " &
                        "(Select Codmeson From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Virtual = 0 Or ActivaConMesonMaestro = 1)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Sb_Actualizar_Grillas()

        If BuscarDatoEnGrilla(Trim(_Numot), "NUMOT", Grilla_Pote) Then

            Grilla_Pote.CurrentCell = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index).Cells("NUMOT")
            Grilla_Pote.Focus()

            If BuscarDatoEnGrilla(Trim("0001"), "NREG", Grilla_Potl) Then

                Grilla_Potl.CurrentCell = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index).Cells("ACTIVE")
                Grilla_Potl.Focus()

            End If

            Sb_Pintar_Grillas_Potl()

            Beep()
            ToastNotification.Show(Me, "PRODUCTOS ENVIADOS A LOS MESONES DE PRODUCCION", Nothing,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Btn_Ver_Estado_De_Avance_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Estado_De_Avance.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Numot As String = _Fila.Cells("NUMOT").Value

        Dim Fm As New Frm_Inf_Prod_Avance_OT
        Fm.Pro_Numot = _Numot
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Rdb_Ver_CheckedChanged(sender As Object, e As EventArgs)

        If CType(sender, Controls.CheckBoxX).Checked Then

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()

            Sb_Actualizar_Grillas()

            Fm_Espera.Dispose()

        End If

    End Sub

    Private Sub Btn_Relacionar_Entidad_OT_Click(sender As Object, e As EventArgs) Handles Btn_Relacionar_Entidad_OT.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila.Cells("NUMOT").Value

        Dim _Filtro As String = _Fila.Cells("NUMOT").Value

        Consulta_sql = "SELECT DISTINCT IDPOTE,POTLCOM.DESDE AS TIDOD, POTLCOM.NUMECOTI AS NUDOD,EDO.ENDO,EDO.SUENDO,NOKOEN
                        FROM POTL WITH ( NOLOCK )
                        LEFT OUTER JOIN POTLCOM ON POTLCOM.IDPOTL = POTL.IDPOTL
                        INNER JOIN MAEEDO EDO ON EDO.TIDO = POTLCOM.DESDE AND POTLCOM.NUMECOTI = EDO.NUDO
                        LEFT OUTER JOIN MAEEN ON EDO.ENDO = KOEN AND EDO.SUENDO = SUEN
                        WHERE POTL.NUMOT='" & _Numot & "' AND POTL.EMPRESA = '" & ModEmpresa & "'" & vbCrLf

        Dim _TblDocRela As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _TblDocRela.Rows.Count = 1 Then

            Dim _Row = _TblDocRela.Rows(0)

            Dim _Endo = _Row.Item("ENDO")
            Dim _Suendo = _Row.Item("SUENDO")
            Dim _Nokoen = _Row.Item("NOKOEN")
            Dim _Tidod = _Row.Item("TIDOD")

            If _Tidod = "NVI" Then
                _Nokoen = RazonEmpresa
            End If

            Consulta_sql = "UPDATE POTE SET ENDO = '" & _Endo & "',SUENDO = '" & _Suendo & "' WHERE IDPOTE = " & _Idpote
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(Me, "Entidad: " & _Nokoen & vbCrLf & "Asociado correctamente a la OT",
                              "Asociar entidad a la OT según documentos relacionados", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            MessageBoxEx.Show(Me, "Esta OT no tiene relación con una Nota de venta" & vbCrLf & vbCrLf &
                              "Se debe seleccionar una entidad para el documento", "Relacionar entidad a la OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim Fm As New Frm_BuscarEntidad_Mt(False)
            Fm.ShowDialog(Me)
            Dim _RowEntidad = Fm.Pro_RowEntidad
            Fm.Dispose()

            If Not IsNothing(_RowEntidad) Then

                Dim _Endo = _RowEntidad.Item("KOEN")
                Dim _Suendo = _RowEntidad.Item("SUEN")
                Dim _Nokoen = _RowEntidad.Item("NOKOEN").ToString.Trim

                Consulta_sql = "UPDATE POTE SET ENDO = '" & _Endo & "',SUENDO = '" & _Suendo & "' WHERE IDPOTE = " & _Idpote
                _Sql.Ej_consulta_IDU(Consulta_sql)

                MessageBoxEx.Show(Me, "Entidad: " & _Nokoen & vbCrLf & "Asociado correctamente a la OT",
                                  "Asociar entidad a la OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Private Sub Mnu_Btn_Imprimir_Portada_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Imprimir_Portada.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Impresora As String = String.Empty
        Dim _Numot = _Fila.Cells("NUMOT").Value

        Dim _Clas_Imp As New Clas_Impirmir_Operaciones_OT_Barras()

        _Clas_Imp.Pro_Nro_OT = _Numot
        _Clas_Imp.Fx_Imprimir_Archivo(Me, "ORDEN DE TRABAJO", _Impresora,
                                          Clas_Impirmir_Operaciones_OT_Barras._Enum_Tipo_Impresion.Portada_OT)

    End Sub

    Private Sub Btn_Fecha_Confirmacion_Click(sender As Object, e As EventArgs) Handles Btn_Fecha_Confirmacion.Click

        Try

            Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

            Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value

            Dim _Texto As String
            Dim _Aceptar As Boolean = InputBox_Bk(Me, "OT: " & vbCrLf & vbCrLf &
                                                  "Ingrese la fecha de confirmación." & vbCrLf &
                                                  "dd-mm-aaaa", "Fecha de confirmación", _Texto, False,, 10, True, _Tipo_Imagen.Texto, False)

            If _Aceptar Then

                Dim _Fechaoc As Date

                _Fechaoc = CDate(_Texto)

                Consulta_sql = "UPDATE POTE SET FECHAOC = '" & Format(_Fechaoc, "yyyyMMdd") & "' WHERE IDPOTE = " & _Idpote

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Fecha de confirmación actualizada correctamente", "Fecha de confirmación", MessageBoxButtons.OK,
                                      MessageBoxIcon.Information)

                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error al inforcorporar la fecha", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Btn_Abrir_OT_Click(sender As Object, e As EventArgs) Handles Btn_Abrir_OT.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila.Cells("NUMOT").Value

        Dim _Nueva_Anotacion As String = "OT REABIERTA DESDE BAKAPP PRODUCCION"

        Dim _HoraGrab = Hora_Grab_fx(False)

        Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB) 
                        VALUES 
                        ('POTE'," & _Idpote & ",'',0,'" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") & "',
                        '','','" & _Nueva_Anotacion & "',GetDate()," & _HoraGrab & ")
                        Update POTE Set ESTADO = 'V',FTOT = Null Where IDPOTE = " & _Idpote & vbCrLf &
                        "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'PD' Where Idpote = " & _Idpote & " And Estado = 'CE' And Fabricado < Fabricar"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Orden de trabajo abierta", "Abrir OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Sb_Actualizar_Grillas()

        End If

    End Sub

    Private Sub Btn_Cerrar_OT_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar_OT.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila.Cells("NUMOT").Value

        Dim _Productos_en_maquinas As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MaquinaVsProductos",
                                                                         "Idpote = " & _Idpote & " And Estado = 'EMQ'")

        If Not Convert.ToBoolean(_Productos_en_maquinas) Then

            Dim _Nueva_Anotacion As String

            If InputBox_Bk(Me, "Observaciones por cierre de OT", "Observaciones", _Nueva_Anotacion,, _Tipo_Mayus_Minus.Mayusculas, 200, True) Then

                Dim _HoraGrab = Hora_Grab_fx(False)

                Consulta_sql = "Insert Into MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB) 
                                Values 
                               ('POTE'," & _Idpote & ",'',0,'" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") &
                               "','','','" & _Nueva_Anotacion & "',GetDate()," & _HoraGrab & ")
                               Update POTE Set ESTADO = 'C',FTOT = Getdate() Where IDPOTE = " & _Idpote & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'CE' Where Idpote = " & _Idpote & " And Estado = 'PD'"

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Orden de trabajo cerrada", "Abrir OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        Else

            MessageBoxEx.Show(Me, "Existen productos que están en las maquinas fabricándose en este momento" & Environment.NewLine &
                              "Debe cerrar primero las fabricaciones y luego cerrar la OT", "Validación",
                                                                                            MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Pausar_Iniciar_OT_Click(sender As Object, e As EventArgs) Handles Btn_Pausar_Iniciar_OT.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
        Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila.Cells("NUMOT").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MaquinaVsProductos", "Idpote = " & _Idpote & " And Estado = 'EMQ'")

        If Not Convert.ToBoolean(_Reg) Then

            Dim _Nueva_Anotacion As String '= "OT SUSPENDIDA (EN PAUSA...) DESDE BAKAPP PRODUCCION"

            Dim _Aceptar = InputBox_Bk(Me, "Motivo de suspención de la OT", "Suspender OT", _Nueva_Anotacion, True,
                                       _Tipo_Mayus_Minus.Mayusculas, 200, True, _Tipo_Imagen.Texto)

            If _Aceptar Then

                Dim _HoraGrab = Hora_Grab_fx(False)

                Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB) 
                            VALUES 
                            ('POTE'," & _Idpote & ",'',0,'" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") & "',
                            '','','" & _Nueva_Anotacion & "',GetDate()," & _HoraGrab & ")
                            Update POTE Set ESTADO = 'S',FTOT = Null Where IDPOTE = " & _Idpote

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Orden de trabajo en pausa", "Suspender OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        Else

            MessageBoxEx.Show(Me, "Primero debe cerrar los trabajos que están en las maquinas", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Anotaciones_Click(sender As Object, e As EventArgs) Handles Btn_Anotaciones.Click

        Dim _Fila As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)

        Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value

        Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Idpote, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.POTE)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Incorporar_Reproceso_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Incorporar_Reproceso.Click

        Dim _Fila_Pote As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
        Dim _Fila_Potl As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Dim _Fila_Potpr As DataGridViewRow = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)

        Dim _Idpotl = _Fila_Potl.Cells("IDPOTL").Value
        Dim _Idpotpr = _Fila_Potpr.Cells("IDPOTPR").Value
        Dim _Codmeson = Trim(_Fila_Potpr.Cells("Codmeson").Value)
        Dim _Nommeson As String
        Dim _Orden = _Fila_Potpr.Cells("ORDEN").Value
        Dim _Numot = _Fila_Potl.Cells("NUMOT").Value

        Dim _Codigo = _Fila_Potl.Cells("CODIGO").Value
        Dim _Descripcion = _Fila_Potl.Cells("GLOSA").Value
        Dim _Subot = _Fila_Potl.Cells("NREG").Value
        Dim _Saldo_Fabricar = _Fila_Potpr.Cells("Saldo_Fabricar").Value
        Dim _Cant_Reproceso = _Fila_Potpr.Cells("Cant_Reproceso").Value

        _Saldo_Fabricar = _Saldo_Fabricar - _Cant_Reproceso


        Dim _Productos_en_maquinas As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MaquinaVsProductos",
                                                                         "Idpotl = " & _Idpotl & " And Estado = 'EMQ'")

        If Not CBool(_Productos_en_maquinas) Then

            If CBool(_Saldo_Fabricar) Then


                Dim _Sql_Filtro_Condicion_Extra = "And OPERACION In (SELECT Operacion_Reproceso FROM " & _Global_BaseBk & "Zw_Pdc_Mesones 
                                                             Where Operacion_Reproceso <> '' And Codmeson <> '" & _Codmeson & "')"

                Dim _Filtrar As New Clas_Filtros_Random(Me)

                If _Filtrar.Fx_Filtrar(Nothing,
                                       Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operaciones, _Sql_Filtro_Condicion_Extra,
                                       Nothing, False, True) Then
                    Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro
                    Consulta_sql = String.Empty

                    Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

                    Dim _Operacion = Trim(_Row.Item("Codigo"))
                    Dim _Nombremop = Trim(_Row.Item("Descripcion"))

                    Consulta_sql = "Select * From POPER Where OPERACION = '" & _Operacion & "'"
                    Dim _Row_Operacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Codmaq = _Row_Operacion.Item("CODMAQ")

                    Consulta_sql = "Select Codmeson,Nommeson,Activo,Virtual,Orden_Meson,Operacion,Operacion_Equivalente,Codmaq,Permitir_Ing_DFA_Directo,Operacion_Reproceso
                                From " & _Global_BaseBk & "Zw_Pdc_Mesones
                                Where Operacion_Reproceso = '" & _Operacion & "'"
                    Dim _Row_Meson As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _Codmeson = Trim(_Row_Meson.Item("Codmeson"))
                    _Nommeson = _Row_Meson.Item("Nommeson")

                    Dim _Grabar As Boolean

                    Dim Fm_Cant As New Frm_Meson_Operario_Cantidad_A_Fabricar(Val(_Saldo_Fabricar), _Codigo, _Descripcion, _Numot, _Subot)
                    Fm_Cant.ShowDialog(Me)
                    _Grabar = Fm_Cant.Pro_Grabar
                    _Saldo_Fabricar = Fm_Cant.Pro_Fabricar
                    Fm_Cant.Dispose()

                    If _Grabar Then

                        Consulta_sql = "Declare @Idpotpr as int,@IdMeson as int,@IdMeson_Origen as int

                            UPDATE POTPR SET ORDEN = ORDEN + 1 WHERE POTPR.IDPOTL = " & _Idpotl & " AND ORDEN >= " & _Orden & "
                            
                            Insert Into POTPR (IDPOTL,EMPRESA,NUMOT,NREGOTL,CODIGO,OPERACION,ORDEN,POROPANT,PORREQCOMP,TIPOOP,ESTADO,SITPEDFAB,FABRICAR,REALIZADO,
                            SALPROXJOR,PORMAQUILA,LILG,NUMODC,NREGODC,CODMAQOT,C_FABRIC,C_INSUMOS,C_MAQUINAS,C_M_OBRA,P_FABRIC,P_INSUMOS,P_MAQUINAS,P_M_OBRA,
                            CCFABRIC,CCINSUMOS,CCMAQUINAS,CCM_OBRA,PCFABRIC,PCINSUMOS,PCMAQUINAS,PCM_OBRA,NOTAS,PERMAQALT,PERMAQPAR) 
                            
                            Select IDPOTL,EMPRESA,NUMOT,NREGOTL,CODIGO,'" & _Operacion & "'," & _Orden & ",POROPANT,PORREQCOMP,TIPOOP,ESTADO,SITPEDFAB,FABRICAR,0,
                            SALPROXJOR,PORMAQUILA,LILG,NUMODC,NREGODC,'" & _Codmaq & "',C_FABRIC,C_INSUMOS,C_MAQUINAS,C_M_OBRA,P_FABRIC,P_INSUMOS,P_MAQUINAS,P_M_OBRA,
                            CCFABRIC,CCINSUMOS,CCMAQUINAS,CCM_OBRA,PCFABRIC,PCINSUMOS,PCMAQUINAS,
                            PCM_OBRA,NOTAS,PERMAQALT,PERMAQPAR 
                            From POTPR
                            Where IDPOTPR = " & _Idpotpr & "
                            
                            Set @Idpotpr = (SELECT @@IDENTITY)
                            Set @IdMeson_Origen = (Select Top 1 IdMeson From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where Idpotpr = " & _Idpotpr & ")

                            Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos (Codmeson,Orden_Meson,Estado,Idpotpr,Idpotl,Idpote,Empresa,Numot,Orden_Potpr,Operacion,Nombreop,Nreg,Desde,Nivel,Codigo,Glosa,
                            Asignado_Por,Fecha_Asignacion,Fabricar_Recep,
                            Fabricado_Recep,Saldo_Fabricar_Recep,Porc_Fabricacion_Recep,Fabricar_OT,Fabricado_OT,Saldo_Fabricar_OT,Porc_Fabricacion,Fabricar,Fabricado,Fabricando,Saldo_Fabricar,Porc_Avance_Saldo_Fab,
                            Cod_Funcionario_Asigna,Prox_Meson,Pertenece,Reproceso)
                            
                            Select '" & _Codmeson & "',1,Estado,@Idpotpr,Idpotl,Idpote,Empresa,Numot," & _Orden & ",'" & _Operacion & "','" & _Nombremop & "',Nreg,'RP',Nivel,Codigo,Glosa,
                            '" & FUNCIONARIO & "',Getdate(),Fabricar_Recep,
                            Fabricado_Recep,Saldo_Fabricar_Recep,Porc_Fabricacion_Recep,Fabricar_OT,0,Saldo_Fabricar_OT,0,Fabricar,0,0," & De_Num_a_Tx_01(_Saldo_Fabricar, False, 5) & ",0,
                            '" & FUNCIONARIO & "','','',1
                            From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos
                            Where Idpotpr = " & _Idpotpr & "

                            Set @IdMeson = (SELECT @@IDENTITY)
                            
                            Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set 
                                    Orden_Potpr += 1,Cant_Reproceso = " & De_Num_a_Tx_01(_Saldo_Fabricar, False, 5) & " Where Idpotpr = " & _Idpotpr & "
                            --Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Estado = 'RP', Orden_Potpr += 1,Cant_Reproceso = " & De_Num_a_Tx_01(_Saldo_Fabricar, False, 5) & " Where Idpotpr = " & _Idpotpr & "
                            
                            Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Fabricado = Fabricar - Saldo_Fabricar,IdMeson_Reproceso = @IdMeson_Origen Where IdMeson = @IdMeson
                            Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Porc_Fabricacion = Saldo_Fabricar/Fabricar Where IdMeson = @IdMeson
                            
                            Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe (IdMaquina,IdMeson_Envia,IdMeson_Recibe,Codigo,CantEnvia,FechaHoraEnvia,EsReproceso,CodFuncionario) Values 
                            (0,@IdMeson_Origen,@IdMeson,'" & _Codigo & "'," & De_Num_a_Tx_01(_Saldo_Fabricar, False, 5) & ",Getdate(),1,'" & FUNCIONARIO & "')"


                        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                            MessageBoxEx.Show(Me, "Se ha incorporado con exito el reproceso en el mesón " & _Codmeson & " - " & _Nommeson, "Reproceso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)

                            Sb_Actualizar_Grillas()

                        End If

                        'Txt_Operacion_Reproceso.Tag = _Operacion
                        'Txt_Operacion_Reproceso.Text = _Operacion & " - " & _Nombremop

                    End If

                End If

            Else

                MessageBoxEx.Show(Me, "No existen productos con saldo para fabricar, no se pueden reprocesar en este mesón", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

            End If

        Else

            MessageBoxEx.Show(Me, "Existen productos que están en las maquina fabricándose en este momento" & Environment.NewLine &
                              "Debe cerrar primero las fabricaciones y luego proceder con el reproceso", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

        End If

    End Sub

    Private Sub Grilla_Potl_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla_Potl.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Mnu_Btn_Imprimir_Hoja_De_Ruta.Visible = True
                    ShowContextMenu(Menu_Contextual_Potl)

                End If

            End With

        End If

    End Sub

    Private Sub Grilla_Potpr_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla_Potpr.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Call Grilla_Potpr_CellDoubleClick(Grilla_Potpr, Nothing)
                End If
            End With
        End If

    End Sub

    Private Sub Btn_Quitar_Todo_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Todo.Click

        Dim _Fila_Pote As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
        Dim _Numot = _Fila_Pote.Cells("NUMOT").Value
        Dim _Idpote = _Fila_Pote.Cells("IDPOTE").Value


        Dim _Fila_Potl As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Dim _Nreg As String = _Fila_Potl.Cells("NREG").Value

        Dim _Fila_Potpr As DataGridViewRow = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)
        Dim _Codmeson As String = _Fila_Potpr.Cells("Codmeson").Value
        Dim _Idpotpr As Integer = _Fila_Potpr.Cells("IDPOTPR").Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MaquinaVsProductos", "Idpote = " & _Idpote)

        _Reg = _Sql.Fx_Cuenta_Registros("PDATFAD",
                             "IDPDATFAE In (Select Idpdatfae From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpote = " & _Idpote & ")")

        If CBool(_Reg) Then

            MessageBoxEx.Show(Me, "No se pueden quitar los productos de esta OT, ya que tienen trabajos realizados en maquinas",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If MessageBoxEx.Show(Me, "¿Desea retirar este trabajo de todos los mesones?", "Quitar productos del mesón",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where Idpote = " & _Idpote & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos_Repro Where Idpote = " & _Idpote & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpote = " & _Idpote & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe" & vbCrLf &
                           "Where IdMaquina In (Select IdMaquina From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpote = " & _Idpote & ")"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                MessageBoxEx.Show(Me, _Sql.Pro_Error & vbCrLf & vbCrLf &
                                      "No fue posible quitar las asignaciones", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Sb_Actualizar_Grillas()

            If BuscarDatoEnGrilla(Trim(_Numot), "NUMOT", Grilla_Pote) Then
                Grilla_Pote.CurrentCell = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index).Cells("NUMOT")
                Grilla_Pote.Focus()

                If BuscarDatoEnGrilla(Trim(_Nreg), "NREG", Grilla_Potl) Then
                    Grilla_Potl.CurrentCell = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index).Cells("ACTIVE")
                    Grilla_Potl.Focus()
                End If

                Sb_Pintar_Grillas_Potl()

                Beep()
                ToastNotification.Show(Me, "PRODUCTOS QUITADOS DE LOS MESONES" & vbCrLf & "CORRECTAMENTE", Nothing,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            End If

        End If



    End Sub
    Private Sub Btn_Abrir_OT_Ms_Click(sender As Object, e As EventArgs) Handles Btn_Abrir_OT_Ms.Click
        Sb_Abri_Suspender_Cerrar_OT_Masivamente(Enum_Abri_Supender_Cerrar_OT.Abrir)
    End Sub
    Private Sub Btn_Suspender_OT_Ms_Click(sender As Object, e As EventArgs) Handles Btn_Suspender_OT_Ms.Click
        Sb_Abri_Suspender_Cerrar_OT_Masivamente(Enum_Abri_Supender_Cerrar_OT.Suspender)
    End Sub
    Private Sub Btn_Cerrar_OT_Ms_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar_OT_Ms.Click
        Sb_Abri_Suspender_Cerrar_OT_Masivamente(Enum_Abri_Supender_Cerrar_OT.Cerrar)
    End Sub
    Enum Enum_Abri_Supender_Cerrar_OT
        Abrir
        Suspender
        Cerrar
    End Enum

    Sub Sb_Abri_Suspender_Cerrar_OT_Masivamente(_Estado As Enum_Abri_Supender_Cerrar_OT)

        Dim _HoraGrab = Hora_Grab_fx(False)
        Dim _Estado_Cod, _Estado_Msg As String

        Select Case _Estado
            Case Enum_Abri_Supender_Cerrar_OT.Abrir
                _Estado_Cod = "V" : _Estado_Msg = "Abierta(s)"
            Case Enum_Abri_Supender_Cerrar_OT.Suspender
                _Estado_Cod = "S" : _Estado_Msg = "Suspendida(s)"
            Case Enum_Abri_Supender_Cerrar_OT.Cerrar
                _Estado_Cod = "C" : _Estado_Msg = "Cerrada(s)"
        End Select


        Consulta_sql = String.Empty

        For Each _Fila As DataGridViewRow In Grilla_Pote.Rows

            If _Fila.Cells("Chk").Value Then

                Dim _Idpote = _Fila.Cells("IDPOTE").Value

                Consulta_sql += "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB)  
                                 VALUES 
                                 ('POTE'," & _Idpote & ",'',0,'" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") &
                                "','','','@Anotacion@',GetDate(),@HoraGrab@)
                                 Update POTE Set ESTADO = '" & _Estado_Cod & "',FTOT = Getdate() Where IDPOTE = " & _Idpote & vbCrLf & vbCrLf

            End If

        Next

        If String.IsNullOrEmpty(Consulta_sql) Then

            MessageBoxEx.Show(Me, "No existen ordenes de trabajo seleccionadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            Dim _Anotacion As String

            If InputBox_Bk(Me, "Observaciones por cierre de OT", "Observaciones", _Anotacion,, _Tipo_Mayus_Minus.Mayusculas, 200, True) Then

                _HoraGrab = Hora_Grab_fx(False)

                Consulta_sql = Replace(Consulta_sql, "@Anotacion@", _Anotacion)
                Consulta_sql = Replace(Consulta_sql, "@HoraGrab@", _HoraGrab)

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Orden(es) de trabajo " & _Estado_Msg, "Abrir OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Sb_Actualizar_Grillas()

                End If

            End If

        End If

    End Sub

    Private Sub Grilla_Pote_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla_Pote.CellBeginEdit

        Dim _Fila_Pote As DataGridViewRow = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
        Dim _Numot = _Fila_Pote.Cells("NUMOT").Value
        Dim _Idpote = _Fila_Pote.Cells("IDPOTE").Value
        Dim _Chk = _Fila_Pote.Cells("Chk").Value

        Dim _Productos_en_maquinas As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_MaquinaVsProductos",
                                                                         "Idpote = " & _Idpote & " And Estado = 'EMQ'")

        If Convert.ToBoolean(_Productos_en_maquinas) Then

            MessageBoxEx.Show(Me, "Existen productos que están en las maquinas fabricándose en este momento" & Environment.NewLine &
                              "Debe cerrar primero las fabricaciones y luego cerrar o suspender la OT", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            e.Cancel = True
            Return

        End If

        If Not _Chk Then

            If Rdb_Ver_Abiertas.Checked Or Rdb_Ver_Suspendidas.Checked Then

                Dim _Incompleto As Boolean

                For Each _Fila_01 As DataGridViewRow In Grilla_Potl.Rows

                    Dim _Active As String = _Fila_01.Cells("ACTIVE").Value

                    If _Active = "EN ESPERA" Then
                        _Incompleto = True
                        Exit For
                    End If

                Next

                Consulta_sql = "Select * From POTL
                            Where IDPOTE = " & _Idpote & " And IDPOTL In (Select Idpotl From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where Idpote = " & _Idpote & " And Estado In ('PD','PT'))"

                Dim _Tbl_Potl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_Tbl_Potl.Rows.Count) Or _Incompleto Then

                    If MessageBoxEx.Show(Me, "Existen productos incompletos por fabricar" & vbCrLf & vbCrLf &
                                     "¿Confirma la seleccion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                        _Fila_Pote.Cells("Chk").Value = True

                    Else

                        e.Cancel = True

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Grilla_Pote_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla_Pote.MouseUp
        Grilla_Pote.EndEdit()
    End Sub


    Private Sub Btn_Alerta_Ver_Historial_Click(sender As Object, e As EventArgs) Handles Btn_Alerta_Ver_Historial.Click

        Dim _Fila_Pote As DataGridViewRow
        Dim _Fila_Potl As DataGridViewRow
        Dim _Fila_Potpr As DataGridViewRow

        Dim _Idpote As Integer = _Fila_Pote.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila_Pote.Cells("NUMOT").Value

        Consulta_sql = "Select Aler.*,Lei.*,Isnull(NOMBREOB,'') As Nombre_Operario_Lee 
                        From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas Aler
                        Left Join " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas_Lectura Lei On Aler.Id_Alertas = Lei.Id_Alertas
                        Left Join PMAEOB On CODIGOOB = Lei.Codigoob_Lee
                        Where Aler.Idpote = " & _Idpote

        Dim _Tbl_Alertas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl_Alertas, Me, "Alertas_Ot_" & _Numot)

    End Sub

    Private Sub Btn_Alertas_Click(sender As Object, e As EventArgs) Handles Btn_Alertas.Click

        Dim _Fila_Pote As DataGridViewRow
        Dim _Fila_Potl As DataGridViewRow
        Dim _Fila_Potpr As DataGridViewRow

#Region "Variables"
        Try
            _Fila_Pote = Grilla_Pote.Rows(Grilla_Pote.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Pote = Grilla_Pote.Rows(0)
        End Try

        Try
            _Fila_Potl = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potl = Grilla_Potl.Rows(0)
        End Try

        Try
            _Fila_Potpr = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potpr = Grilla_Potpr.Rows(0)
        End Try

        Dim _Codmeson As String = _Fila_Potpr.Cells("Codmeson").Value
        Dim _Idpotpr As Integer = _Fila_Potpr.Cells("IDPOTPR").Value
        Dim _Idpotl As Integer = _Fila_Potpr.Cells("IDPOTL").Value
        Dim _Idpote As Integer = _Fila_Pote.Cells("IDPOTE").Value
        Dim _Numot As String = _Fila_Pote.Cells("NUMOT").Value
        Dim _Nreg As String = _Fila_Potl.Cells("NREG").Value
        Dim _Nivel As Integer = _Fila_Potl.Cells("NIVEL").Value
        Dim _Codigo As String = _Fila_Potpr.Cells("CODIGO").Value
        Dim _Operacion As String = _Fila_Potpr.Cells("OPERACION").Value
        Dim _Nombreop As String = _Fila_Potpr.Cells("NOMBREOP").Value
        Dim _Glosa As String = _Fila_Potl.Cells("GLOSA").Value
        Dim _Fabricar As Integer = _Fila_Potpr.Cells("FABRICAR").Value
        Dim _Realizado As Integer = _Fila_Potpr.Cells("REALIZADO").Value
        Dim _Faltante As Integer = _Fila_Potpr.Cells("FALTANTE").Value
        Dim _Orden_Potpr As Integer = _Fila_Potpr.Cells("ORDEN").Value
        Dim _Activos As Boolean = CBool(_Fila_Potpr.Cells("Activos").Value)

#End Region

        Dim _Se_Puede_Editar = True

        Dim _Est_Meson As String = _Fila_Potpr.Cells("Est_Meson").Value

        If _Est_Meson = "FZ" Or _Est_Meson = "RP" Then _Se_Puede_Editar = False

        'If _Fila_Potpr.DefaultCellStyle.ForeColor = Color.Gray Then
        '    _Se_Puede_Editar = False
        'End If

        Dim Fm As New Frm_Alertas_Pdc(_Idpote, _Idpotl, _Idpotpr, _Numot, _Operacion, _Codmeson)
        Fm.Se_Puede_Editar = _Se_Puede_Editar
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Pintar_Grillas_Potpr()

    End Sub

    Private Sub Btn_Ver_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Meson.Click

        Dim _Fila_Potpr As DataGridViewRow = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)

        Dim _Numot As String = _Fila_Potpr.Cells("NUMOT").Value
        Dim _Codmeson As String = _Fila_Potpr.Cells("Codmeson").Value

        Dim Fm As New Frm_Busqueda_OT
        Fm.Codemeson = _Codmeson
        Fm.Numot = _Numot
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Txt_Descripcion.Text = _Numot

        Sb_Actualizar_Grillas()

    End Sub

    Private Sub Btn_Ver_Doc_Comercial_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Doc_Comercial.Click

        Dim _Fila As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)

        Dim _Id_Doc_Comercial As Integer = _Fila.Cells("Id_Doc_Comercial").Value
        Dim _Tido_Doc_Comercial As String = _Fila.Cells("Tido_Doc_Comercial").Value
        Dim _Nudo_Doc_Comercial As String = _Fila.Cells("Nudo_Doc_Comercial").Value

        If Not CBool(_Id_Doc_Comercial) Then
            MessageBoxEx.Show(Me, "No existen documentos comerciales relacionados", "Bakapp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim _Idmaeedo = _Sql.Fx_Trae_Dato("MAEEDO", "IDMAEEDO", "TIDO = '" & _Tido_Doc_Comercial & "' And NUDO = '" & _Nudo_Doc_Comercial & "'")

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Reimprimir_Comprobante_EnvRec_Click(sender As Object, e As EventArgs) Handles Btn_Reimprimir_Comprobante_EnvRec.Click

        Dim _Impresora As String = String.Empty

        Dim _Fila_Potl As DataGridViewRow = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Dim _Fila_Potpr As DataGridViewRow = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)

        Dim _Idpote = _Fila_Potl.Cells("NUMOT").Value
        Dim _Idpotpr = _Fila_Potpr.Cells("IDPOTPR").Value

        'Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el código del Id", "Envio", _IdMeson_Envia, False, _Tipo_Mayus_Minus.Normal,, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

        'If Not _Aceptar Then
        '    Return
        'End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe" & vbCrLf &
                       "Where IdMaquina In (Select IdMaquina From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpotpr = " & _Idpotpr & ") "
        Dim _Tbl_MesonVsEnvioRecibe As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Clas_Imp As New Clas_Impirmir_Operaciones_OT_Barras()

        For Each _Fila As DataRow In _Tbl_MesonVsEnvioRecibe.Rows

            Dim _Id_MesonVsEnvioRecibe As String = _Fila.Item("Id")
            _Clas_Imp.Fx_Imprimir_Vale_Comprobante_Meson(Me, _Impresora, _Id_MesonVsEnvioRecibe)

            Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

            Dim _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
            Dim _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

            _Clas_Imp.Fx_Imprimir_Etiqueta_PRN(Me, _Id_MesonVsEnvioRecibe, _Etiqueta, _Puerto)

        Next

    End Sub

    Sub Sb_Imprimir_Impresora_Vales()

        Dim _DtsImp As New DatosBakApp
        _DtsImp.ReadXml(AppPath() & "\Data\" & RutEmpresa & "\Produccion\Impresoras\Imp_OTEnvioRecibe_Barras.xml")

        If CBool(_DtsImp.Tables("Conf_Impresora_Local").Rows.Count) Then

            Dim _Impresora As String = _DtsImp.Tables("Conf_Impresora_Local").Rows(0).Item("Impresora").ToString
            Dim _RowNombreFormato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
            Dim _NombreFormato = _RowNombreFormato.Item("NombreFormato")

            If Not String.IsNullOrEmpty(_Impresora) Then



            End If

        Else

            MessageBoxEx.Show(Me, "No existe dispositivo de impresión configurado" & vbCrLf & vbCrLf &
                              "Para configurar esta operación debe hacer lo siguiente:" & vbCrLf & vbCrLf &
                                "-> Clic en el botón de la AMPOLLETA (Opciones especiales)" & vbCrLf &
                                "-> Configuración impresora de salida" & vbCrLf &
                                "-> Impresora local o conectada a red", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Sub Sb_Configurar_Conexion_Impresora_Vales()

        Dim _Ruta_Impresora = AppPath() & "\Data\" & RutEmpresa & "\Produccion"

        If Not Directory.Exists(_Ruta_Impresora) Then
            Directory.CreateDirectory(_Ruta_Impresora)
        End If

        _Ruta_Impresora += "\ConfLocal"

        If Not Directory.Exists(_Ruta_Impresora) Then
            Directory.CreateDirectory(_Ruta_Impresora)
        End If

        _Ruta_Impresora += "\Impresoras"

        If Not Directory.Exists(_Ruta_Impresora) Then
            Directory.CreateDirectory(_Ruta_Impresora)
        End If

        Dim Fm As New Frm_Seleccionar_Impresoras("")
        Dim Archivo As String

        Archivo = _Ruta_Impresora & "\Imp_OTEnvioRecibe_Vales.xml"

        If File.Exists(Archivo) Then
            Kill(Archivo)
        End If

        Dim _DtsConfig As New DatosBakApp

        Fm.ShowDialog(Me)

        Dim NewFila As DataRow
        NewFila = _DtsConfig.Tables("Conf_Impresora_Local").NewRow
        With NewFila
            .Item("Modulo") = "Bkpost"
            .Item("Impresora") = Fm.Pro_Impresora_Seleccionada
            _DtsConfig.Tables("Conf_Impresora_Local").Rows.Add(NewFila)
        End With

        _DtsConfig.WriteXml(Archivo)
        _DtsConfig.Clear()

        If Not String.IsNullOrEmpty(Fm.Pro_Impresora_Seleccionada) Then
            MessageBoxEx.Show(Me, "Impresora seleccionada: " & Fm.Pro_Impresora_Seleccionada, "Impresora",
                              MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)
        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Configuracion_Salida_Impresora_Barras_LPT()

        Dim Fm As New Frm_Barras_ConfPuerto("Imp_OTEnvioRecibe.xml")
        Fm.ShowDialog(Me)
        Dim _TieneConfiguracion = Fm.Grabar
        Fm.Dispose()

    End Sub

    Private Sub Txt_BuscarXEntidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscarXEntidad.ButtonCustomClick

        Dim _CodEntidad = Txt_BuscarXEntidad.Text.Trim

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.Rdb_Clientes.Checked = True
        Fm.Txtdescripcion.Text = _CodEntidad
        Fm.ShowDialog(Me)
        Dim _RowEntidad = Fm.Pro_RowEntidad

        Fm.Dispose()

        If Not IsNothing(_RowEntidad) Then
            Txt_BuscarXEntidad.Text = _RowEntidad.Item("KOEN")
        End If

    End Sub

    Private Sub Txt_BuscarXProducto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscarXProducto.ButtonCustomClick

        Dim _RowProducto As DataRow = Fx_Buscar_Producto()

        If Not IsNothing(_RowProducto) Then
            Txt_BuscarXProducto.Text = _RowProducto.Item("KOPR")
        End If

    End Sub

    Private Sub Txt_BuscarXInsumo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscarXInsumo.ButtonCustomClick

        Dim _RowProducto As DataRow = Fx_Buscar_Producto()

        If Not IsNothing(_RowProducto) Then
            Txt_BuscarXInsumo.Text = _RowProducto.Item("KOPR")
        End If

    End Sub

    Function Fx_Buscar_Producto() As DataRow

        Dim _RowProducto As DataRow

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

        Fm.Seleccionar_Multiple = False
        Fm.Bloqueados = Frm_BkpPostBusquedaEspecial_Mt.Enum_Bloquear.Ventas
        Fm.Top20 = Frm_BkpPostBusquedaEspecial_Mt.Enum_Top20.Top_Ventas
        'Fm.Pro_CodEntidad = _CodEntidad
        'Fm.Pro_CodSucEntidad = _CodSucEntidad
        'Fm.Pro_Tipo_Lista = ModListaPrecioVenta
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.Pro_Sucursal_Busqueda = ModSucursal
        Fm.Pro_Bodega_Busqueda = ModBodega
        Fm.Pro_Mostrar_Info = False
        Fm.Pro_Actualizar_Precios = False
        Fm.Pro_Mostrar_Clasificaciones = True
        Fm.Pro_Mostrar_Imagenes = True
        Fm.BtnCrearProductos.Visible = False
        Fm.Pro_Mostrar_Precios = False
        Fm.Mostrar_Stock_Disponible = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            _RowProducto = Fm.Pro_RowProducto
        End If

        Return _RowProducto

    End Function

    Private Sub Btn_AplicarBusqueda_Click(sender As Object, e As EventArgs) Handles Btn_AplicarBusqueda.Click
        Sb_Actualizar_Grillas()
    End Sub

    Private Sub Txt_BuscarXEntidad_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscarXEntidad.ButtonCustom2Click
        Txt_BuscarXEntidad.Text = String.Empty
    End Sub

    Private Sub Txt_BuscarXProducto_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscarXProducto.ButtonCustom2Click
        Txt_BuscarXProducto.Text = String.Empty
    End Sub

    Private Sub Txt_BuscarXInsumo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscarXInsumo.ButtonCustom2Click
        Txt_BuscarXInsumo.Text = String.Empty
    End Sub

    Private Sub Txt_Descripcion_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Descripcion.ButtonCustomClick
        Txt_Descripcion.Text = String.Empty
    End Sub

    Private Sub Btn_AplicarBusqueda2_Click(sender As Object, e As EventArgs) Handles Btn_AplicarBusqueda2.Click
        Sb_Actualizar_Grillas()
    End Sub

    Private Sub Btn_Observaciones_Click(sender As Object, e As EventArgs) Handles Btn_Observaciones.Click

        Dim _Fila_Pote As DataGridViewRow
        Dim _Fila_Potl As DataGridViewRow
        Dim _Fila_Potpr As DataGridViewRow

        Try
            _Fila_Potl = Grilla_Potl.Rows(Grilla_Potl.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potl = Grilla_Potl.Rows(0)
        End Try
        Try
            _Fila_Potpr = Grilla_Potpr.Rows(Grilla_Potpr.CurrentRow.Index)
        Catch ex As Exception
            _Fila_Potpr = Grilla_Potpr.Rows(0)
        End Try

        Dim _Idpotpr As Integer = _Fila_Potpr.Cells("IDPOTPR").Value

        Dim Fm As New Frm_Meson_ObsXMaq(_Idpotpr)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
