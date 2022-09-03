'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_ImpBarras_Ubicaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Puerto, _Etiqueta As String
    Dim _RowSector As DataRow

    Public Property Pro_Btn_Buscar_Sectores_Enable() As Boolean
        Get
            Return Btn_Buscar_Sectores.Enabled
        End Get
        Set(value As Boolean)
            Btn_Buscar_Sectores.Enabled = value
        End Set
    End Property

    Public Sub New(RowSector As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _RowSector = RowSector

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnImprimirEtiqueta.ForeColor = Color.White
            Btn_Buscar_Sectores.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_ImpBarras_Ubicaciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        caract_combo(Cmbetiquetas)
        Consulta_sql = "Select '' As Padre,'' As Hijo Union" & vbCrLf &
                       "SELECT NombreEtiqueta AS Padre,Upper(NombreEtiqueta)+', Cantidad de etiquetas '+RTRIM(LTRIM(STR(CantPorLinea))) AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Tbl_DisenoBarras order by Padre"
        Cmbetiquetas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        Cmbetiquetas.SelectedValue = ""

        Sb_Actualizar_Grilla()

        AddHandler BtnImprimirEtiqueta.Click, AddressOf Sb_Imprimir_Etiquetas
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

#Region "PROCEDIMIENTOS"

#Region "ACTUALIZAR GRILLA"

    Sub Sb_Actualizar_Grilla()

        Dim _Id_Mapa = _RowSector.Item("Id_Mapa")
        Dim _Empresa = _RowSector.Item("Empresa")
        Dim _Sucursal = _RowSector.Item("Sucursal")
        Dim _Bodega = _RowSector.Item("Bodega")
        Dim _Codigo_Sector = _RowSector.Item("Codigo_Sector")
        Dim _Nombre_Sector = _RowSector.Item("Nombre_Sector")
        Dim _Nombre_Mapa

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Where Id_Mapa = " & _Id_Mapa
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then
            _Nombre_Mapa = _Tbl.Rows(0).Item("Nombre_Mapa")
        End If

        Me.Text = "Sector: " & _Nombre_Mapa & " " & _Nombre_Sector & " - " & _Codigo_Sector

        Consulta_sql = "Select Distinct Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Descripcion_Ubic,Cast(0 as Int) as Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                       "Where Empresa = '" & _Empresa &
                       "' And Sucursal = '" & _Sucursal &
                       "' And Bodega = '" & _Bodega &
                       "' And Id_Mapa = " & _Id_Mapa &
                       "  And Codigo_Sector = '" & _Codigo_Sector &
                       "' And Es_SubSector = 0 And Descripcion_Ubic <> '.'" & vbCrLf &
                       "Order by Codigo_Ubic"

        Dim _TblUbicaciones = _Sql.Fx_Get_Tablas(Consulta_sql) ' _DsEstante.Tables(1)

        With Grilla

            Grilla.DataSource = _TblUbicaciones
            OcultarEncabezadoGrilla(Grilla, True, , False)

            .Columns("Codigo_Ubic").Width = 210
            .Columns("Codigo_Ubic").HeaderText = "Ubicación"
            .Columns("Codigo_Ubic").ReadOnly = True
            .Columns("Codigo_Ubic").Visible = True
            '.Columns("Codigo_Ubic").DisplayIndex = 0

            .Columns("Descripcion_Ubic").Width = 100
            .Columns("Descripcion_Ubic").HeaderText = "Coordenada"
            .Columns("Descripcion_Ubic").ReadOnly = True
            .Columns("Descripcion_Ubic").Visible = True
            .Columns("Descripcion_Ubic").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Descripcion_Ubic").DisplayIndex = 1

            '.Columns("Fila").Width = 50
            '.Columns("Fila").HeaderText = "Nivel"
            '.Columns("Fila").ReadOnly = True
            '.Columns("Fila").Visible = True
            '.Columns("Fila").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Fila").DisplayIndex = 2

            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Visible = True
            '.Columns("Cantidad").DisplayIndex = 1

        End With


    End Sub

#End Region

#Region "IMPRIMIR ETIQUETAS"

    Sub Sb_Imprimir_Etiquetas()
        Try

            If String.IsNullOrEmpty(Cmbetiquetas.Text) Then
                Beep()
                ToastNotification.Show(Me, "DEBE SELECCIONAR LA ETIQUETA",
                                      My.Resources.cross,
                                     2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If


            Dim _CantPorLinea As Integer

            _CantPorLinea = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "CantPorLinea",
                                              "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'")

            If _CantPorLinea = 0 Then _CantPorLinea = 1

            Dim _TblDetalle As DataTable = Grilla.DataSource

            Dim _Suma As Double = NuloPorNro(_TblDetalle.Compute("Sum(Cantidad)", "1>0"), 0)

            If Not CBool(_Suma) Then
                Beep()
                ToastNotification.Show(Me, "NO HAY DATOS QUE IMPRIMIR",
                                      My.Resources.cross,
                                     1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If


            Dim _Id_Mapa = _RowSector.Item("Id_Mapa")
            Dim _Empresa = _RowSector.Item("Empresa")
            Dim _Sucursal = _RowSector.Item("Sucursal")
            Dim _Bodega = _RowSector.Item("Bodega")
            Dim _Codigo_Sector = _RowSector.Item("Codigo_Sector")


            For Each _Fila As DataRow In _TblDetalle.Rows

                Dim CanXlinea As Double = _CantPorLinea
                Dim Veces As Double = _Fila("Cantidad").ToString()

                If CBool(Veces) Then

                    If CanXlinea = Veces Or CanXlinea > Veces Then
                        Veces = 1
                    Else
                        Dim _ModVeces = Veces Mod 2
                        Dim _ModCanXlinea = CanXlinea Mod 2

                        If CanXlinea <> 1 Then

                            If CBool(_ModVeces) Or CBool(_ModCanXlinea) Then

                                Veces = Math.Round((Veces / CanXlinea), 5)
                                Dim _Des = Split(Veces, ",")

                                If _Des.Length = 2 Then
                                    Veces = _Des(0) + 1
                                End If

                            Else
                                Veces = Math.Round((Veces / CanXlinea), 0)
                            End If
                        End If
                    End If

                    If Veces < 1 Then Veces = 1

                    Dim _CodUbicacion = Trim(_Fila.Item("Codigo_Ubic"))

                    For w = 1 To Veces

                        Dim _Imp As New Class_Imprimir_Barras

                        _Imp.Sb_Imprimir_Ubicacion(Cmbetiquetas.SelectedValue,
                                                   _Puerto,
                                                   _Empresa,
                                                   _Sucursal,
                                                   _Bodega,
                                                   _Id_Mapa,
                                                   _Codigo_Sector,
                                                   _CodUbicacion)

                    Next
                End If
            Next

        Catch ex As Exception
            MsgBox("Error inesperado", MsgBoxStyle.Exclamation, "Barras")
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#End Region

    Private Sub Frm_ImpBarras_Ubicaciones_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Dejar_En_1_Click(sender As Object, e As EventArgs) Handles Btn_Dejar_En_1.Click

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Cantidad").Value = 1
        Next

    End Sub

    Private Sub Btn_Buscar_Sectores_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Sectores.Click

        Dim _Row As DataRow

        Dim Fm As New Frm_Ubicaciones_Buscar
        Fm.ShowDialog(Me)
        _Row = Fm.Pro_RowSector
        Fm.Dispose()

        If Not (_Row Is Nothing) Then
            _RowSector = _Row
            Sb_Actualizar_Grilla()
        End If

    End Sub

End Class
