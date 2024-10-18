Imports DevComponents.DotNetBar

Public Class Frm_Sectores_Lista_UbicOblig

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Id_Mapa As Integer
    Public Property FechaRevision As Date

    Public Sub New(_Id_Mapa As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Mapa = _Id_Mapa
        FechaRevision = FechaDelServidor()

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

    End Sub

    Private Sub Frm_Sectores_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

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

End Class
