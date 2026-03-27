'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_CRV_Filtrar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _TblFiltro_Clientes As DataTable
    Dim _TblFiltro_Estados As DataTable

    
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Llenar_Combo_Chofer("")
        Sb_Llenar_Combo_Vehiculos("")

    End Sub

    Private Sub Frm_CRV_Filtrar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Rdb_CRV_Una.Checked = True
        Me.ActiveControl = Txt_Nro_CRV
        'Sb_Habilitar_Etiquetas()

        Dtp_Fecha_Salida_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Salida_Hasta.Value = FechaDelServidor()

        Dtp_Fecha_Llegada_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Llegada_Hasta.Value = FechaDelServidor()

    End Sub

    Private Sub Rdb_Entidades_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Entidades_Algunas.CheckedChanged

        If Rdb_Entidades_Algunas.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10) '(Frm_Filtro_Especial_Informes._Tabla_Fl._Entidades)

            Fm.Pro_Tabla = "MAEEN"
            Fm.Pro_Campo = "RTEN"
            Fm.Pro_Descripcion = "NOKOEN"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Clientes = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Clientes Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Entidades_Todas.Checked = True
                End If
            Else
                Rdb_Entidades_Todas.Checked = True
            End If
        End If

    End Sub

    Private Sub Rdb_Estados_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Estados_Algunos.CheckedChanged
        If Rdb_Estados_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "Estados de Ordenes de Trabajo"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'ESTADOS_CRV')" & vbCrLf & "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Estados = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Estados Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Estados_Todas.Checked = True
                End If
            Else
                Rdb_Estados_Todas.Checked = True
            End If

        End If
    End Sub

    Sub Sb_Llenar_Combo_Chofer(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'Todos' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT CodChofer As Padre,NomChofer As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TblChoferes_Empresa" & vbCrLf & _
                       "WHERE Habilitado = 1" & vbCrLf & _
                       "Order by Padre"
        Dim _TblChofer = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmb_Chofer)
        Cmb_Chofer.DataSource = _TblChofer
        Cmb_Chofer.SelectedValue = _Codigo

    End Sub

    Sub Sb_Llenar_Combo_Vehiculos(ByVal _Codigo As String)

        Consulta_sql = "Select '' As Padre,'Todos' As Hijo " & vbCrLf & "Union " & vbCrLf & _
                       "SELECT Patente As Padre,Rtrim(LTrim(Nombre_Vehiculo))+' - '+Patente  As Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TblVehiculos_Empresa" & vbCrLf & _
                       "WHERE 1 > 0" & vbCrLf & _
                       "Order by Padre"
        Dim _TblVehiculo = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmb_Nuevo_Vehiculo)
        Cmb_Nuevo_Vehiculo.DataSource = _TblVehiculo
        Cmb_Nuevo_Vehiculo.SelectedValue = _Codigo

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub



    Private Sub Frm_CRV_Filtrar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Sb_Filtrar()
    End Sub


    Sub Sb_Filtrar()

        Dim _Filtro_CRV = String.Empty
        Dim _Filtro_Entidades = String.Empty
        Dim _Filtro_Chofer = String.Empty
        Dim _Filtro_Vehiculo = String.Empty
        Dim _Filtro_Estados = String.Empty

        Dim _Filtro_Fecha_Salida = String.Empty
        Dim _Filtro_Fecha_Llegada = String.Empty
        


        If Rdb_CRV_Una.Checked Then
            If String.IsNullOrEmpty(Trim(Txt_Nro_CRV.Text)) Then
                Beep()
                ToastNotification.Show(Me, "NUMERO NO PUEDE ESTAR VACIO", Imagenes_32x32.Images.Item("Warning"), _
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Txt_Nro_CRV.Focus()
                Return
            End If
        End If

        Dim _Nro_CRV As String = Txt_Nro_CRV.Text
        Dim _Filtro_SQl As String

        If Rdb_CRV_Una.Checked Then
            Txt_Nro_CRV.Text = Fx_Rellena_ceros(Txt_Nro_CRV.Text, 10)
            _Filtro_CRV = "And Nro_CRV = '" & _Nro_CRV & "'" & vbCrLf
        End If

        If Rdb_CRV_Todas.Checked Then

            If Rdb_Entidades_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Clientes, "Chk", "Codigo", False, True, "'")
                _Filtro_Entidades = "And CodEntidad in " & _Filtro_SQl & vbCrLf
            End If

            If Not String.IsNullOrEmpty(Cmb_Chofer.SelectedValue) Then
                _Filtro_Chofer = "And CodChofer = '" & Cmb_Chofer.SelectedValue & "'"
            End If

            If Not String.IsNullOrEmpty(Cmb_Nuevo_Vehiculo.SelectedValue) Then
                _Filtro_Chofer = "And Patente = '" & Cmb_Nuevo_Vehiculo.SelectedValue & "'"
            End If

            If Rdb_Estados_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Estados, "Chk", "Codigo", False, True, "'")
                _Filtro_Estados = "And Estado in " & _Filtro_SQl & vbCrLf
            End If

            'If Rdb_Estados_Algunos.Checked Then
            '_Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Estados, "Chk", "Codigo", False, True, "'")
            '_Filtro_Estados = "And CodCategoria in " & _Filtro_SQl & vbCrLf
            'End If

            If Rdb_Fecha_Salida_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Salida_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Salida_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Salida_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Salida_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Salida_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Salida_Hasta.Value.Year

                _Filtro_Fecha_Salida = "And (Fecha_Hora_Salida BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf & _
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


            End If

            If Rdb_Fecha_Llegada_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Llegada_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Llegada_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Llegada_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Llegada_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Llegada_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Llegada_Hasta.Value.Year

                _Filtro_Fecha_Llegada = "And (Fecha_Hora_Llegada BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf & _
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


            End If


        End If

        _Filtro_SQl = _Filtro_CRV & _
                      _Filtro_Entidades & _
                      _Filtro_Chofer & _
                      _Filtro_Vehiculo & _
                      _Filtro_Estados & _
                      _Filtro_Fecha_Salida & _
                      _Filtro_Fecha_Llegada

        Dim Fm As New Frm_CRV_Lista
        Dim _Tbl_Informe As DataTable = Fm.Fx_Actualizar_Tbl_Crv(_Filtro_SQl)

        _Tbl_Informe = _SQL.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl_Informe.Rows.Count) Then

            Dim _Mostrar As Boolean

            If _Tbl_Informe.Rows.Count <= 20 Then
                _Mostrar = True
            Else
                If MessageBoxEx.Show(Me, _Tbl_Informe.Rows.Count & " registros encontrados" & vbCrLf & vbCrLf & _
                                                "¿Desea ver la información?", "Filtrar", _
                                              MessageBoxButtons.OKCancel, _
                                              MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then

                    _Mostrar = True
                End If
            End If

            If _Mostrar Then

                Fm.Pro_Tbl_CRV = _Tbl_Informe
                Fm.Pro_Filtrar = True
                Fm.ShowDialog(Me)

            End If

        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISEN DATOS QUE MOSTRAR", Imagenes_32x32.Images.Item("Delete"), _
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            _Tbl_Informe = Nothing
        End If

        Fm.Dispose()

    End Sub


    Private Sub Sb_Habilitar_Etiquetas()

        Lbl_FS_desde.Enabled = Rdb_Fecha_Salida_Rango.Checked
        Lbl_FS_hasta.Enabled = Rdb_Fecha_Salida_Rango.Checked
        Dtp_Fecha_Salida_Desde.Enabled = Rdb_Fecha_Salida_Rango.Checked
        Dtp_Fecha_Salida_Hasta.Enabled = Rdb_Fecha_Salida_Rango.Checked

        Lbl_FL_desde.Enabled = Rdb_Fecha_Llegada_Rango.Checked
        Lbl_FL_hasta.Enabled = Rdb_Fecha_Llegada_Rango.Checked
        Dtp_Fecha_Llegada_Desde.Enabled = Rdb_Fecha_Llegada_Rango.Checked
        Dtp_Fecha_Llegada_Hasta.Enabled = Rdb_Fecha_Llegada_Rango.Checked

        Txt_Nro_CRV.Enabled = Rdb_CRV_Una.Checked

        Grupo_Entidad.Enabled = Rdb_CRV_Todas.Checked
        Grupo_Fechas.Enabled = Rdb_CRV_Todas.Checked

        If Rdb_CRV_Todas.Checked Then
            Txt_Nro_CRV.Text = String.Empty
        End If

    End Sub

    Private Sub Rdb_CRV_Una_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_CRV_Una.CheckedChanged
        Sb_Habilitar_Etiquetas()
        If Rdb_CRV_Una.Checked Then
            Txt_Nro_CRV.Focus()
        End If
    End Sub

    Private Sub Txt_Nro_CRV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Nro_CRV.KeyDown
        If e.KeyValue = Keys.Enter Then
            Txt_Nro_CRV.Text = Fx_Rellena_ceros(Txt_Nro_CRV.Text, 10)
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Rdb_Fecha_Salida_Rango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Fecha_Salida_Rango.CheckedChanged
        Sb_Habilitar_Etiquetas()
    End Sub

    Private Sub Rdb_Fecha_Llegada_Rango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Fecha_Llegada_Rango.CheckedChanged
        Sb_Habilitar_Etiquetas()
    End Sub
End Class