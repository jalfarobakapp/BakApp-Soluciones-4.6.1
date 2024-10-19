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

    End Sub

    Private Sub Frm_Sectores_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

        Dtp_FechaRevision.Value = FechaRevision

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

        AddHandler Dtp_FechaRevision.ValueChanged, AddressOf Dtp_FechaRevision_ValueChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Id_Sector,Id_Mapa,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector,Es_SubSector,EsCabecera,SoloUnaUbicacion,OblConfimarUbic," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Ubicaciones," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Productos," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector" & vbCrLf &
                       "And CONVERT(varchar, FechaIngreso, 112) = CONVERT(varchar,'" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "', 112) And Salida = 0) As Productos2," & vbCrLf &
                       "CAST(0 As Bit) As 'ProdConfimadaUbic'" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Sect" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And OblConfimarUbic = 1" & vbCrLf &
                       "Update #Paso Set ProdConfimadaUbic = 1 Where (Productos = 0 And Productos = 0) Or (Productos2 > 0)" & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

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

            .Columns("Nombre_Sector").Width = 250
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

            .Columns("Productos2").Width = 80
            .Columns("Productos2").HeaderText = "P.Asignados"
            .Columns("Productos2").ToolTipText = "Productos asignados en las ubicaciones el día " & Dtp_FechaRevision.Value.ToLongDateString & " en este sector"
            .Columns("Productos2").Visible = True
            .Columns("Productos2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _ProdSinConfirmar = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

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
                _ProdSinConfirmar += 1
            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Icono

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
    End Sub

    Private Sub Btn_ConfProdUbic_Click(sender As Object, e As EventArgs) Handles Btn_ConfProdUbic.Click

        Consulta_sql = "Select Id_Sector,Id_Mapa,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector,Es_SubSector,EsCabecera,SoloUnaUbicacion,OblConfimarUbic," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Ubicaciones," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector) As Productos," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Where Id_Mapa = Sect.Id_Mapa And Codigo_Sector = Sect.Codigo_Sector" & vbCrLf &
                       "And CONVERT(varchar, FechaIngreso, 112) = CONVERT(varchar,'" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "', 112) And Salida = 0) As Productos2," & vbCrLf &
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

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Semilla,Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector," &
                       "Codigo_Ubic,Codigo,NombreEquipo,CodFuncionario_Ing,Ingreso,FechaIngreso)" & vbCrLf &
                       "Select Semilla,Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo,'" & _NombreEquipo & "','" & FUNCIONARIO & "',1,'" & Format(Dtp_FechaRevision.Value, "yyyyMMdd") & "'" & vbCrLf &
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

                    Dim _Hoy As Boolean = (FechaDelServidor.Date = Dtp_FechaRevision.Value.Date)

                    Btn_VerProdUbicacion.Visible = _Hoy
                    Btn_AgregarProductosUbic.Visible = Not _Hoy
                    Btn_QuitarProductosUbic.Visible = Not _Hoy

                    ShowContextMenu(Menu_Contextual_01)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_AgregarProductosUbic_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProductosUbic.Click

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            Dim _Empresa As String = _Fila.Cells("Empresa").Value
            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value
            Dim _Codigo_Sector As String = _Fila.Cells("Codigo_Sector").Value
            Dim _Codigo_Ubic As String = _Codigo_Sector
            Dim _FechaIngreso As Date = Dtp_FechaRevision.Value

            Me.Enabled = False

            Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"
            Dim _Filtrar As New Clas_Filtros_Random(Me)
            Dim _Tbl_Productos As DataTable
            Dim _Filtrar_Pr As Boolean

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

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Semilla,Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo," &
                       "CodFuncionario_Ing,NombreEquipo,Ingreso,FechaIngreso) Values " & vbCrLf &
                       "(0,'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','" & _Codigo_Ubic & "'" &
                       ",'" & _Codigo & "','" & FUNCIONARIO & "','" & _NombreEquipo & "',1,'" & Format(_FechaIngreso, "yyyyMMdd") & "')"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    _Contador += 1

                Next

            End If

            If CBool(_Contador) Then

                Sb_Actualizar_Grilla()

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
                                              "And Codigo_Ubic = '" & _Codigo_Ubic & "' And Ingreso = 1 And Salida = 0 " &
                                              "And CONVERT(varchar, FechaIngreso, 112) = '" & Format(_FechaIngreso, "yyyyMMdd") & "')"
            Dim _Filtrar As New Clas_Filtros_Random(Me)
            Dim _Tbl_Productos As DataTable
            Dim _Filtrar_Pr As Boolean

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                                   False, False) Then

                _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    _Tbl_Productos = Nothing
                End If
                _Filtrar_Pr = True
            End If

            Dim _Contador = 0
            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = String.Empty

            If _Filtrar_Pr Then

                For Each _Fl As DataRow In _Tbl_Productos.Rows

                    Dim _Codigo As String = _Fl.Item("Codigo")

                    Dim _Semilla = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_Ubicacion", "Semilla",
                                                      "Id_Mapa = " & _Id_Mapa &
                                                      " And Codigo_Sector = '" & _Codigo_Sector &
                                                      "' And Codigo_Ubic = '" & _Codigo_Ubic &
                                                      "' And Codigo = '" & _Codigo & "'")

                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Set " & vbCrLf &
                                    "Empresa = '" & _Empresa & "'" &
                                    ",Sucursal = '" & _Sucursal & "'" &
                                    ",Bodega = '" & _Bodega & "'" &
                                    ",Id_Mapa = " & _Id_Mapa &
                                    ",Codigo_Sector = '" & _Codigo_Sector & "'" &
                                    ",Codigo_Ubic = '" & _Codigo_Ubic & "'" &
                                    ",Codigo = '" & _Codigo & "'" &
                                    ",CodFuncionario_Sal = '" & FUNCIONARIO & "'" &
                                    ",NombreEquipo = '" & _NombreEquipo & "'" &
                                    ",Salida = 1" &
                                    ",FechaSalida = '" & Format(_FechaIngreso, "yyyyMMdd") & "'" & vbCrLf &
                                    "Where Semilla = " & _Semilla & vbCrLf

                    _Contador += 1

                Next


            End If

            If CBool(_Contador) Then

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Sb_Actualizar_Grilla()

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

End Class
