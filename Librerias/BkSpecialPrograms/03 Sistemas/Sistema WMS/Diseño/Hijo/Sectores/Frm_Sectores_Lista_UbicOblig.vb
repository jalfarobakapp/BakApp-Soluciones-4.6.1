Imports System.Security.Cryptography
Imports DevComponents.DotNetBar

Public Class Frm_Sectores_Lista_UbicOblig

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Id_Mapa As Integer
    Private _Row_Mapa As DataRow
    Public Property FechaRevision As Date

    Public Sub New(_Id_Mapa As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Mapa = _Id_Mapa
        FechaRevision = FechaDelServidor()

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Where Id_Mapa = " & _Id_Mapa
        _Row_Mapa = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Sectores_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

        Dtp_FechaRevision.Value = FechaRevision

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

        AddHandler Dtp_FechaRevision.ValueChanged, AddressOf Dtp_FechaRevision_ValueChanged
        AddHandler Rdb_MostrarSesctoresEnMapa.CheckedChanged, AddressOf Rdb_MostrarSesctoresEnMapa_CheckedChanged
        AddHandler Rdb_MostrarTodosSectores.CheckedChanged, AddressOf Rdb_MostrarTodosSectores_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _CondicionSectores = String.Empty

        If Rdb_MostrarSesctoresEnMapa.Checked Then
            _CondicionSectores = "Where EstaEnMapa = 1" & vbCrLf
        End If

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Id_Sector,Id_Mapa,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector,Es_SubSector,EsCabecera,SoloUnaUbicacion,OblConfimarUbic," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Ubicaciones," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector" & vbCrLf &
                       "And CONVERT(varchar, FechaIngreso, 112) = CONVERT(varchar,'" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "', 112)) As Productos," & vbCrLf &
                       "CAST(0 As Bit) As 'ProdConfimadaUbic'," & vbCrLf &
                       "CAST(0 As Bit) As 'EstaEnMapa'" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Sect" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And OblConfimarUbic = 1" & vbCrLf & vbCrLf &
                       "Update #Paso Set EstaEnMapa = 1 Where Codigo_Sector In (Select Codigo_Sector From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Where Id_Mapa = " & _Id_Mapa & ")" & vbCrLf &
                       "Update #Paso Set ProdConfimadaUbic = 1 Where Productos > 0" & vbCrLf &
                       "Select * From #Paso" & vbCrLf & _CondicionSectores &
                       "Drop Table #Paso"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("EstaEnMapa").Width = 60
            .Columns("EstaEnMapa").HeaderText = "En Mapa"
            .Columns("EstaEnMapa").ToolTipText = "Indica si el sector se encuantra visible en el mapa actualmente"
            .Columns("EstaEnMapa").Visible = True
            .Columns("EstaEnMapa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("BtnImagen_Estado").Width = 30
            .Columns("BtnImagen_Estado").HeaderText = "Est."
            .Columns("BtnImagen_Estado").Visible = True
            .Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo_Sector").Width = 80
            .Columns("Codigo_Sector").HeaderText = "Sector"
            .Columns("Codigo_Sector").Visible = True
            .Columns("Codigo_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Sector").Width = 230
            .Columns("Nombre_Sector").HeaderText = "Nombre Sector"
            .Columns("Nombre_Sector").Visible = True
            .Columns("Nombre_Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Es_SubSector").Width = 30
            .Columns("Es_SubSector").HeaderText = "S.S."
            .Columns("Es_SubSector").ToolTipText = "Es Sub-Sector"
            .Columns("Es_SubSector").Visible = True
            .Columns("Es_SubSector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("EsCabecera").Width = 30
            .Columns("EsCabecera").HeaderText = "CBRA"
            .Columns("EsCabecera").ToolTipText = "Es un sector tipo cabecera"
            .Columns("EsCabecera").Visible = True
            .Columns("EsCabecera").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SoloUnaUbicacion").Width = 30
            .Columns("SoloUnaUbicacion").HeaderText = "U.U."
            .Columns("SoloUnaUbicacion").ToolTipText = "Solo acepta una ubicación"
            .Columns("SoloUnaUbicacion").Visible = True
            .Columns("SoloUnaUbicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OblConfimarUbic").Width = 30
            .Columns("OblConfimarUbic").HeaderText = "C.U."
            .Columns("OblConfimarUbic").ToolTipText = "Obliga a confirmar ubicaciones diariamente"
            .Columns("OblConfimarUbic").Visible = True
            .Columns("OblConfimarUbic").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Productos").Width = 80
            '.Columns("Productos").HeaderText = "P.Asignados"
            '.Columns("Productos").ToolTipText = "Productos asignados a ubicaciones en este sector"
            '.Columns("Productos").Visible = True
            '.Columns("Productos").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Productos").Width = 80
            .Columns("Productos").HeaderText = "P.Asignados"
            .Columns("Productos").ToolTipText = "Productos asignados en las ubicaciones el día " & Dtp_FechaRevision.Value.ToLongDateString & " en este sector"
            .Columns("Productos").Visible = True
            .Columns("Productos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _ProdSinConfirmar = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _ProdConfimadaUbic As Boolean = _Fila.Cells("ProdConfimadaUbic").Value
            Dim _EstaEnMapa As Boolean = _Fila.Cells("EstaEnMapa").Value

            'warning.png
            Dim _Icono As Image

            Dim _Imagenes_List As ImageList
            If Global_Thema = Enum_Themas.Oscuro Then
                _Imagenes_List = Imagenes_16x16_Dark
            Else
                _Imagenes_List = Imagenes_16x16
            End If

            _Icono = Nothing

            If _ProdConfimadaUbic Then
                _Icono = _Imagenes_List.Images.Item("ok.png")
            Else
                _Icono = _Imagenes_List.Images.Item("symbol-remove.png")
                _ProdSinConfirmar += 1
            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Icono

            If Not _EstaEnMapa Then
                _Fila.DefaultCellStyle.ForeColor = Color.Gray
            End If

        Next

        If CBool(_ProdSinConfirmar) Then
            MessageBoxEx.Show(Me, "Existen productos sin confirmar en las ubicaciones el día " & Dtp_FechaRevision.Value.ToLongDateString,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Dtp_FechaRevision_ValueChanged(sender As Object, e As EventArgs)
        If Dtp_FechaRevision.Value.Date > Now.Date Then
            MessageBoxEx.Show(Me, "La fecha no puede ser mayor a la fecha de hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_FechaRevision.Value = FechaDelServidor()
        End If
        Sb_Actualizar_Grilla()
        Chk_Seleccionar_Todos.Checked = False
    End Sub

    Private Sub Btn_ConfProdUbic_Click(sender As Object, e As EventArgs) Handles Btn_ConfProdUbic.Click

        If Not Fx_RevisarProductosSeleccionados() Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma nuevamente los productos de la ultima fecha de ingreso el día " & Dtp_FechaRevision.Value.ToLongDateString & "?", "Confirmación mavisa",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Lista As List(Of LsValiciones.Mensajes) = New List(Of LsValiciones.Mensajes)

            If _Fila.Cells("Chk").Value Then

                Dim _Mensaje As LsValiciones.Mensajes = Fx_ConfirmarProdUltimaUbicacion(_Fila, False)

                _Lista.Add(_Mensaje)

                If _Mensaje.EsCorrecto Then
                    Sb_ActualizarDatosFila(_Fila)
                End If

            End If

        Next

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Sb_Actualizar_Grilla()

        Return

        Consulta_sql = "Select Id_Sector,Id_Mapa,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector,Es_SubSector,EsCabecera,SoloUnaUbicacion,OblConfimarUbic," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Ubicaciones," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Productos," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector" & vbCrLf &
                       "And CONVERT(varchar, FechaIngreso, 112) = CONVERT(varchar,'" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "', 112)) As Productos2," & vbCrLf &
                       "CAST(0 As Bit) As 'ProdConfimadaUbic'" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Sect" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And OblConfimarUbic = 1" & vbCrLf &
                       "Update #Paso Set ProdConfimadaUbic = 1 Where Productos = Productos2" & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _ProdSinConfirmar = 0

        For Each _Fila As DataRow In _Tbl.Rows
            If Not _Fila.Item("ProdConfimadaUbic") Then
                _ProdSinConfirmar += 1
            End If
        Next

        If _ProdSinConfirmar = 0 Then
            MessageBoxEx.Show(Me, "Todos los productos ya han sido confirmados en las ubicaciones el día " & Dtp_FechaRevision.Value.ToLongDateString,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma dejar nuevamente los productos " & vbCrLf &
                             "en las mismas ubicaciones el día " & Dtp_FechaRevision.Value.ToLongDateString & "?",
                             "Confirmar productos en la ubicaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector," &
                       "Codigo_Ubic,Codigo,NombreEquipo,CodFuncionario_Ing,FechaIngreso)" & vbCrLf &
                       "Select Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo,'" & _NombreEquipo & "','" & FUNCIONARIO & "',1,'" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Ubicacion" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Codigo Not In " &
                       "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal " &
                       "Where Id_Mapa = " & _Id_Mapa &
                       " And CONVERT(varchar, FechaIngreso, 112) = '" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = CType(sender, DataGridView).Rows(CType(sender, DataGridView).CurrentRow.Index)
                    Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

                    'Dim _Hoy As Boolean = (FechaDelServidor.Date = Dtp_FechaRevision.Value.Date)

                    'Btn_VerProdUbicacion.Visible = True
                    'Btn_AgregarProductosUbic.Visible = _Fila.Cells("EstaEnMapa").Value
                    'Btn_QuitarProductosUbic.Visible = _Fila.Cells("EstaEnMapa").Value
                    'LabelItem2.Visible = Not _Hoy

                    ShowContextMenu(Menu_Contextual_01)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_AgregarProductosUbic_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProductosUbic.Click

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            If Not Fx_EstaEnMapa(_Fila) Then
                Return
            End If

            Dim _Empresa As String = _Fila.Cells("Empresa").Value
            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value
            Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
            Dim _Codigo_Ubic As String = _Codigo_Sector
            Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

            Me.Enabled = False

            Dim _Filtrar As New Clas_Filtros_Random(Me)
            Dim _Tbl_Productos As DataTable
            Dim _Filtrar_Pr As Boolean

            Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN' And KOPR Not In " &
                                              "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where " &
                                              "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' " &
                                              "And Codigo_Ubic = '" & _Codigo_Ubic & "' " &
                                              "And CONVERT(varchar, FechaIngreso, 112) = '" & Format(_FechaIngreso, "yyyyMMdd") & "')"

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                                   False, False) Then

                _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    _Tbl_Productos = Nothing
                End If
                _Filtrar_Pr = True
            End If

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
            Dim _Contador = 0

            If _Filtrar_Pr Then

                For Each _Fl As DataRow In _Tbl_Productos.Rows

                    Dim _Codigo As String = _Fl.Item("Codigo")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo," &
                       "CodFuncionario_Ing,NombreEquipo,FechaIngreso) Values " & vbCrLf &
                       "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','" & _Codigo_Ubic & "'" &
                       ",'" & _Codigo & "','" & FUNCIONARIO & "','" & _NombreEquipo & "','" & Format(_FechaIngreso, "yyyyMMdd") & "')"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    _Contador += 1

                Next

            End If

            If CBool(_Contador) Then

                Sb_ActualizarDatosFila(_Fila)

                Beep()
                ToastNotification.Show(Me, "DATOS GUARDADOS CORRECTAMENTE (" & _Contador & ")",
                                       My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Btn_QuitarProductosUbic_Click(sender As Object, e As EventArgs) Handles Btn_QuitarProductosUbic.Click

        If Not Fx_Tiene_Permiso(Me, "Ubic0006") Then
            Return
        End If

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            If Not Fx_EstaEnMapa(_Fila) Then
                Return
            End If

            Dim _Empresa As String = _Fila.Cells("Empresa").Value
            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value
            Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
            Dim _Codigo_Ubic As String = _Codigo_Sector
            Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

            Me.Enabled = False

            Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN' And KOPR In " &
                                              "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where " &
                                              "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' " &
                                              "And Codigo_Ubic = '" & _Codigo_Ubic & "' " &
                                              "And CONVERT(varchar, FechaIngreso, 112) = '" & Format(_FechaIngreso, "yyyyMMdd") & "')"
            Dim _Filtrar As New Clas_Filtros_Random(Me)
            Dim _Tbl_Productos As DataTable
            Dim _Filtrar_Pr As Boolean

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra, False, False,,,,,, True) Then

                _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
                'If _Filtrar.Pro_Filtro_Todas Then
                '    _Tbl_Productos = Nothing
                'End If
                _Filtrar_Pr = True
            End If

            Dim _Contador = 0
            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = String.Empty

            If _Filtrar_Pr Then

                For Each _Fl As DataRow In _Tbl_Productos.Rows

                    Dim _Codigo As String = _Fl.Item("Codigo")

                    If Not String.IsNullOrEmpty(_Codigo) Then

                        Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal " &
                                        "Where Empresa = '" & _Empresa &
                                        "' And Sucursal = '" & _Sucursal &
                                        "' And Bodega = '" & _Bodega &
                                        "' And Codigo_Sector = '" & _Codigo_Sector &
                                        "' And Codigo_Ubic = '" & _Codigo_Ubic &
                                        "' And Codigo = '" & _Codigo &
                                        "' And CONVERT(varchar, FechaIngreso, 112) = '" & Format(_FechaIngreso, "yyyyMMdd") & "'" & vbCrLf

                        _Contador += 1

                    End If

                Next

            End If

            If CBool(_Contador) Then

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Sb_ActualizarDatosFila(_Fila)

                Beep()
                ToastNotification.Show(Me, "Productos quitados correctamente (" & _Contador & ")",
                                       My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Call Btn_VerProdUbicacion_Click(Nothing, Nothing)
        Return

        Dim _Hoy As Boolean = (FechaDelServidor.Date = Dtp_FechaRevision.Value.Date)

        If Not _Hoy Then

            Btn_VerProdUbicacion.Visible = _Hoy
            Btn_AgregarProductosUbic.Visible = Not _Hoy
            Btn_QuitarProductosUbic.Visible = Not _Hoy

            ShowContextMenu(Menu_Contextual_01)
            Return

        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Empresa As String = _Fila.Cells("Empresa").Value
        Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
        Dim _Bodega As String = _Fila.Cells("Bodega").Value
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
        Dim _Codigo_Ubic As String = _Codigo_Sector
        Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

        Dim _Row_Bodega As DataRow = Fx_Trar_Datos_De_Bodega_Seleccionada(_Empresa, _Sucursal, _Bodega)
        Dim _Row_Ubicacion As DataRow

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Empresa = '" & _Empresa & "' " &
                       "And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' " &
                       "And Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic = '" & _Codigo_Ubic & "'"
        _Row_Ubicacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_05_UbicXpro_UbicacionConProductos(_Row_Bodega, _Id_Mapa, _Codigo_Sector, _Codigo_Ubic)
        Fm.TxtUbicacion.Text = _Codigo_Ubic.Trim & ": " & _Row_Ubicacion.Item("Descripcion_Ubic")
        Fm.Text = "Productos en la ubicación -> " & _Codigo_Ubic
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_ExportarExcelProductos_Click(sender As Object, e As EventArgs) Handles Btn_ExportarExcelProductos.Click

        Consulta_sql = "Select PrUbic.Codigo_Sector,Mp.KOPR,Mp.NOKOPR" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal PrUbic" & vbCrLf &
                       "Left Join MAEPR Mp On Mp.KOPR = PrUbic.Codigo" & vbCrLf &
                       "Where FechaIngreso = '" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Productos en ubicaciones")

    End Sub

    Private Sub Btn_VerProdUbicacion_Click(sender As Object, e As EventArgs) Handles Btn_VerProdUbicacion.Click

        Try
            Me.Enabled = False

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            Dim _Empresa As String = _Fila.Cells("Empresa").Value
            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value
            Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
            Dim _Nombre_Sector As String = _Fila.Cells("Nombre_Sector").Value
            Dim _Codigo_Ubic As String = _Codigo_Sector
            Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

            Dim _Hoy As Boolean = (FechaDelServidor.Date = Dtp_FechaRevision.Value.Date)

            If True Then 'Not _Hoy Then

                Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN' And KOPR In " &
                                                      "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where " &
                                                      "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "' " &
                                                      "And Codigo_Ubic = '" & _Codigo_Ubic & "' " &
                                                      "And CONVERT(varchar, FechaIngreso, 112) = '" & Format(_FechaIngreso, "yyyyMMdd") & "')"

                Consulta_sql = "Select Top 1 KOPR From MAEPR Where 1> 0 " & _Sql_Filtro_Condicion_Extra
                Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                If Not CBool(_Tbl.Rows.Count) Then
                    MessageBoxEx.Show(Me, "No existen datos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Dim _Filtrar As New Clas_Filtros_Random(Me)

                _Filtrar.Fx_Filtrar(Nothing, Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra, False, False,, False,, False,, True)

                Return

            End If

            Dim _Row_Bodega As DataRow = Fx_Trar_Datos_De_Bodega_Seleccionada(_Empresa, _Sucursal, _Bodega)
            Dim _Row_Ubicacion As DataRow

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                           "Where Id_Mapa = " & _Id_Mapa & " And Empresa = '" & _Empresa & "' " &
                           "And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' " &
                           "And Codigo_Sector = '" & _Codigo_Sector & "' And Codigo_Ubic = '" & _Codigo_Ubic & "'"
            _Row_Ubicacion = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim Fm As New Frm_05_UbicXpro_UbicacionConProductos(_Row_Bodega, _Id_Mapa, _Codigo_Sector, _Codigo_Ubic)
            Fm.TxtUbicacion.Text = _Codigo_Ubic.Trim & ": " & _Nombre_Sector
            Fm.Text = "Productos en la ubicación -> " & _Codigo_Ubic
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                "Id_Mapa = " & _Id_Mapa & " And " &
                                                "Codigo_Sector = '" & _Codigo_Sector & "' And " &
                                                "Codigo_Ubic = '" & _Codigo_Ubic & "'")

            _Fila.Cells("Productos2").Value = _Reg

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Btn_VerProdUbicacionMensual_Click(sender As Object, e As EventArgs) Handles Btn_VerProdUbicacionMensual.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Empresa As String = _Fila.Cells("Empresa").Value
        Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
        Dim _Bodega As String = _Fila.Cells("Bodega").Value
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
        Dim _Codigo_Ubic As String = _Codigo_Sector
        Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

        Dim Fm As New Frm_Sectores_ProductosEnSector(_Id_Mapa, _Codigo_Sector, Dtp_FechaRevision.Value)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_ConfProdUbicSoloUna_Click(sender As Object, e As EventArgs) Handles Btn_ConfProdUbicSoloUna.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        If Not Fx_EstaEnMapa(_Fila) Then
            Return
        End If

        Dim _Empresa As String = _Fila.Cells("Empresa").Value
        Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
        Dim _Bodega As String = _Fila.Cells("Bodega").Value
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
        Dim _Codigo_Ubic As String = _Codigo_Sector
        Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion",
                                                       "Id_Mapa = " & _Id_Mapa &
                                                       " And Empresa = '" & _Empresa & "' " &
                                                       "And Sucursal = '" & _Sucursal & "' " &
                                                       "And Bodega = '" & _Bodega & "' " &
                                                       "And Codigo_Sector = '" & _Codigo_Sector & "'")

        If _Reg = 0 Then

            MessageBoxEx.Show(Me, "No hay productos registros que cargar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If MessageBoxEx.Show(Me, "¿Confirma importar los productos desde la ubicación en el mapa" & vbCrLf &
                             "para el día " & Dtp_FechaRevision.Value.ToLongDateString & "?" & vbCrLf &
                             "Esto borrara los productos que actualmente se encuentran en el sector",
                     "Confirmar productos en la ubicaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal " &
                       "Where Id_Mapa = " & _Id_Mapa &
                       " And CONVERT(varchar, FechaIngreso, 112) = '" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") &
                       "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo_Sector = '" & _Codigo_Sector & "'" & vbCrLf & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector," &
                       "Codigo_Ubic,Codigo,NombreEquipo,CodFuncionario_Ing,FechaIngreso)" & vbCrLf &
                       "Select Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo,'" & _NombreEquipo & "','" & FUNCIONARIO & "','" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Ubicacion" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Codigo Not In " &
                       "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal " &
                       "Where Id_Mapa = " & _Id_Mapa &
                       " And CONVERT(varchar, FechaIngreso, 112) = '" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo_Sector = '" & _Codigo_Sector & "')" & vbCrLf &
                       "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo_Sector = '" & _Codigo_Sector & "'"

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Sb_ActualizarDatosFila(_Fila)
        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Btn_ConfProdUltUbic_Click(sender As Object, e As EventArgs) Handles Btn_ConfProdUltUbic.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        If Not Fx_EstaEnMapa(_Fila) Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes = Fx_ConfirmarProdUltimaUbicacion(_Fila, True)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Sb_ActualizarDatosFila(_Fila)

    End Sub

    Function Fx_ConfirmarProdUltimaUbicacion(_Fila As DataGridViewRow, _Preguntar As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Detalle = "Confirmar productos"

        Try

            Dim _Empresa As String = _Fila.Cells("Empresa").Value
            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value
            Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
            Dim _Codigo_Ubic As String = _Codigo_Sector
            Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

            Dim _FechaUltUbic As DateTime?

            Try
                _FechaUltUbic = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_Ubicacion_IngSal", "MAX(FechaIngreso)",
                                                          "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector &
                                                          "' And Codigo_Ubic = '" & _Codigo_Ubic & "' " &
                                                          "And FechaIngreso < '" & Format(_FechaIngreso, "yyyyMMdd") & "'",, False)
            Catch ex As Exception

            End Try

            If IsNothing(_FechaUltUbic) Then
                Throw New System.Exception("No hay productos registros que cargar")
            End If

            If _Preguntar Then

                If MessageBoxEx.Show(Me, "¿Confirma dejar nuevamente los productos " & vbCrLf &
                         "en las mismas ubicaciones del día " & _FechaUltUbic.Value.ToLongDateString & " en el día " & Dtp_FechaRevision.Value.ToLongDateString & "?",
                         "Confirmar productos en la ubicaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Throw New System.Exception("Acción cancelada por el usuario")
                    _Mensaje.Cancelado = True
                End If

            End If

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo,NombreEquipo,CodFuncionario_Ing,FechaIngreso)" & vbCrLf &
                           "Select Distinct Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo,'" & _NombreEquipo & "','" & FUNCIONARIO & "','" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "'" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal" & vbCrLf &
                           "Where Id_Mapa = " & _Id_Mapa & " And CONVERT(varchar, FechaIngreso, 112) = '" & Format(_FechaUltUbic, "yyyyMMdd") & "'" & vbCrLf &
                           "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo_Sector = '" & _Codigo_Sector & "'" & vbCrLf &
                           "And Codigo Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal " &
                           "Where Id_Mapa = " & _Id_Mapa & " And CONVERT(varchar, FechaIngreso, 112) = '" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") &
                           "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo_Sector = '" & _Codigo_Sector & "')"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos actualizados correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function


    Private Sub Chk_Seleccionar_Todos_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleccionar_Todos.CheckedChanged
        For Each _Fila As DataGridViewRow In Grilla.Rows
            If _Fila.Cells("EstaEnMapa").Value Then
                _Fila.Cells("Chk").Value = Chk_Seleccionar_Todos.Checked
            End If
        Next
    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Function Fx_RevisarProductosSeleccionados() As Boolean

        For Each _Fila As DataGridViewRow In Grilla.Rows
            If _Fila.Cells("Chk").Value Then
                Return True
            End If
        Next

        MessageBoxEx.Show(Me, "No hay sectores seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Return False

    End Function

    Sub Sb_ActualizarDatosFila(_Fila As DataGridViewRow)

        Dim _Empresa As String = _Fila.Cells("Empresa").Value
        Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
        Dim _Bodega As String = _Fila.Cells("Bodega").Value
        Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
        Dim _Codigo_Ubic As String = _Codigo_Sector

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Id_Sector,Id_Mapa,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector,Es_SubSector,EsCabecera,SoloUnaUbicacion,OblConfimarUbic," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Ubicaciones," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector" & vbCrLf &
                       "And CONVERT(varchar, FechaIngreso, 112) = CONVERT(varchar,'" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "', 112)) As Productos," & vbCrLf &
                       "CAST(0 As Bit) As 'ProdConfimadaUbic'" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Sect" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And OblConfimarUbic = 1" & vbCrLf &
                       "And Codigo_Sector = '" & _Codigo_Sector & "'" & vbCrLf &
                       "Update #Paso Set ProdConfimadaUbic = 1 Where Productos > 0" & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        _Fila.Cells("Ubicaciones").Value = _Tbl.Rows(0).Item("Ubicaciones")
        _Fila.Cells("Productos").Value = _Tbl.Rows(0).Item("Productos")
        _Fila.Cells("ProdConfimadaUbic").Value = _Tbl.Rows(0).Item("ProdConfimadaUbic")

        Dim _ProdConfimadaUbic As Boolean = _Fila.Cells("ProdConfimadaUbic").Value

        'warning.png
        Dim _Icono As Image

        Dim _Imagenes_List As ImageList
        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

        _Icono = Nothing

        If _ProdConfimadaUbic Then
            _Icono = _Imagenes_List.Images.Item("ok.png")
        Else
            _Icono = _Imagenes_List.Images.Item("cancel.png")
        End If

        _Fila.Cells("BtnImagen_Estado").Value = _Icono

    End Sub

    Private Sub Rdb_MostrarSesctoresEnMapa_CheckedChanged(sender As Object, e As EventArgs)
        If Rdb_MostrarSesctoresEnMapa.Checked Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Rdb_MostrarTodosSectores_CheckedChanged(sender As Object, e As EventArgs)
        If Rdb_MostrarTodosSectores.Checked Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Grilla_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        If Not Fx_EstaEnMapa(_Fila) Then
            e.Cancel = True
        End If

    End Sub

    Function Fx_EstaEnMapa(_Fila As DataGridViewRow)

        If Not _Fila.Cells("EstaEnMapa").Value Then
            MessageBoxEx.Show(Me, "El sector no esta en el mapa no se pueden cargar datos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True

    End Function

End Class
