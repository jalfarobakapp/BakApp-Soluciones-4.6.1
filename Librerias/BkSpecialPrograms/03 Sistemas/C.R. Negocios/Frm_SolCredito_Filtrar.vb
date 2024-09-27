
Imports DevComponents.DotNetBar

Public Class Frm_SolCredito_Filtrar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf
    Dim _RowEntidad As DataRow

    Dim _Filtro As String
    Dim _Filtrar As Boolean

    Public Property Pro_Filtro As String
        Get
            Return _Filtro
        End Get
        Set(value As String)
            _Filtro = value
        End Set
    End Property

    Public Property Pro_Filtrar As Boolean
        Get
            Return _Filtrar
        End Get
        Set(value As Boolean)
            _Filtrar = value
        End Set
    End Property

    Function Fx_Filtrar()


        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'ST'" & vbCrLf &
                       "Where Stand_By = 1" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'IN'" & vbCrLf &
                       "Where Nro_Negocio Not In (Select Nro_Negocio From " & _Global_BaseBk & "Zw_Negocios_03_Apr) " & vbCrLf &
                       "And Stand_By = 0 And Estado Not In ('NL','CO') And Visado_Jefe = 0" & vbCrLf &
                        vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'AN'" & vbCrLf &
                       "Where Nro_Negocio Not In (Select Nro_Negocio From " & _Global_BaseBk & "Zw_Negocios_03_Apr) " & vbCrLf &
                       "And Stand_By = 0 And Estado Not In ('NL','CO') And Visado_Jefe = 1" & vbCrLf &
                        vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'PR'" & vbCrLf &
                       "Where Nro_Negocio In (Select Nro_Negocio From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z1" & vbCrLf &
                       "Group by Nro_Negocio" & vbCrLf &
                       "having (Select COUNT(*) From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z2 Where Z2.Nro_Negocio = Z1.Nro_Negocio) IN (1,2)) " &
                       "And Stand_By = 0" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'CM'" & vbCrLf &
                       "Where Nro_Negocio In (Select Nro_Negocio From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z1" & vbCrLf &
                       "Group by Nro_Negocio" & vbCrLf &
                       "having (Select COUNT(*) From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z2 Where Z2.Nro_Negocio = Z1.Nro_Negocio) = 3) " &
                       "And Estado = 'PR' And Stand_By = 0"

        _Sql.Ej_consulta_IDU(Consulta_sql)



        Dim _Filtro_Nro_Negocio = String.Empty

        Dim _Filtro_Fecha_Emision = String.Empty
        Dim _Filtro_Fecha_Cierre = String.Empty
        Dim _Filtro_Vendedor = String.Empty
        Dim _Filtro_Cliente = String.Empty

        Dim _Filtro_Estado = String.Empty


        If Rdb_NroNegocio_Una.Checked Then

            Txt_NroNegocio.Text = Fx_Rellena_ceros(Txt_NroNegocio.Text, 10)
            _Filtro_Nro_Negocio = "Where Nro_Negocio = '" & Txt_NroNegocio.Text & "'"


        Else

            If Rdb_Fecha_Emision_Entre.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Emision_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Emision_Hasta.Value.Year

                _Filtro_Fecha_Emision = "And (Fecha_Emision BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf

                '' _Filtro_Fecha_Emision = "And (Fecha_Emision BETWEEN '" & Format(Dtp_Fecha_Emision_Desde.Value, "yyyyMMdd") & _
                ''                        "' And '" & Format(Dtp_Fecha_Emision_Hasta.Value, "yyyyMMdd") & "')" & vbCrLf


            End If

            If Rdb_Fecha_Cierre_Entre.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Cierre_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Cierre_Hasta.Value.Year

                _Filtro_Fecha_Cierre = "And (Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                                       "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf

                ''_Filtro_Fecha_Cierre = "And (Fecha_Emision BETWEEN '" & Format(Dtp_Fecha_Cierre_Desde.Value, "yyyyMMdd") & _
                ''                        "' And '" & Format(Dtp_Fecha_Cierre_Hasta.Value, "yyyyMMdd") & "')" & vbCrLf

            End If


            If Rdb_Vendedor_Uno.Checked Then
                _Filtro_Vendedor = "And Nro_Negocio in (Select Nro_Negocio From " & _Global_BaseBk & "Zw_Negocios_02_Det" & vbCrLf &
                                  "Where CodVendedor = '" & Cmb_Vendedor.SelectedValue & "')" & vbCrLf
            End If


            If Rdb_Cliente_Uno.Checked Then
                _Filtro_Cliente = "And (CodEntidad = '" & _RowEntidad.Item("KOEN") & "')" & vbCrLf
            End If

            Dim _Estados(8) As String

            If Chk_StandBy.Checked Then _Estados(0) = "ST" Else _Estados(0) = String.Empty
            If Chk_Ingresado.Checked Then _Estados(1) = "IN" Else _Estados(1) = String.Empty
            If Chk_Analisis.Checked Then _Estados(2) = "AN" Else _Estados(2) = String.Empty
            If Chk_En_Procesado.Checked Then _Estados(3) = "PR" Else _Estados(3) = String.Empty
            If Chk_Completado.Checked Then _Estados(4) = "CM" Else _Estados(4) = String.Empty
            If Chk_Nulas.Checked Then _Estados(5) = "NL" Else _Estados(5) = String.Empty

            If Chk_Cerrados_Autorizado.Checked Then _Estados(6) = "C1" Else _Estados(6) = String.Empty
            If Chk_Cerrados_Rechazados.Checked Then _Estados(7) = "C2" Else _Estados(7) = String.Empty
            If Chk_Cerrados_Pre_Aprobados.Checked Then _Estados(8) = "C3" Else _Estados(8) = String.Empty

            Dim _Cerrados As String

            _Filtro_Estado = Generar_Filtro_IN_Arreglo(_Estados, False)

            If _Filtro_Estado = "()" Then
                _Filtro_Estado = "''"
            Else
                _Filtro_Estado = Replace(_Filtro_Estado, "(", "")
                _Filtro_Estado = Replace(_Filtro_Estado, ")", "")
            End If

            _Filtro_Estado = "Where Estado In (" & _Filtro_Estado & ")"


        End If


        _Filtro = _Filtro_Estado &
                  _Filtro_Nro_Negocio &
                  _Filtro_Fecha_Emision &
                  _Filtro_Fecha_Cierre &
                  _Filtro_Vendedor &
                  _Filtro_Cliente


        Consulta_sql = "SELECT Id_Negocio,Nro_Negocio,Stand_By,Estado,Tipo,NomTipo," &
                      "CONVERT(VARCHAR, Fecha_Emision, 103) Fecha,CONVERT(VARCHAR, Fecha_Emision, 108) Hora," &
                      "Fecha_Emision,Fecha_Cierre,CodEntidad,CodSucursal,NomEntidad," &
                      "CodFuncionario,NomFuncionario," &
                      "(Select top 1 Linea_Credito_SC_Ac_UF From " & _Global_BaseBk & "Zw_Negocios_02_Det Z02 " &
                      "Where Z02.Nro_Negocio = Z01.Nro_Negocio) As 'CRED_SOL_UF'," &
                      "Empresa,Sucursal,NomSucursal,Cadena_Conexion," &
                      "(Select Count(*) From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z03 " &
                      "Where Z03.Nro_Negocio = Z01.Nro_Negocio ) as St,'' As Color_Estatus,'' As Estatus,Nom_Clas_Crediticia,Motivo_Anula" & vbCrLf &
                      "From " & _Global_BaseBk & "Zw_Negocios_01_Enc Z01" & vbCrLf &
                      _Filtro

        Dim _TblInforme As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblInforme.Rows.Count) Then
            If MessageBoxEx.Show(Me, _TblInforme.Rows.Count & " registros encontrados" & vbCrLf & vbCrLf &
                                 "¿Desea ver la información?", "Filtrar",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then

                _Filtrar = True
                Me.Close()
            End If
        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISEN DATOS QUE MOSTRAR", My.Resources.cross,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            _Filtrar = False
        End If

    End Function

    Private Sub Frm_SolCredito_Filtrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        caract_combo(Cmb_Vendedor)
        Consulta_sql = _Union & "SELECT CodFuncionario AS Padre,NomFuncionario AS Hijo" & vbCrLf & _
                        "FROM " & _Global_BaseBk & "Zw_Usuarios" & vbCrLf & _
                        "Where Es_Vendedor = 1" & vbCrLf & _
                        "ORDER BY Hijo"

        Cmb_Vendedor.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Vendedor.SelectedValue = ""

        AddHandler Rdb_NroNegocio_Todas.CheckedChanged, AddressOf Sb_NroSOC
        AddHandler Rdb_NroNegocio_Una.CheckedChanged, AddressOf Sb_NroSOC

        AddHandler Rdb_Cliente_Todo.CheckedChanged, AddressOf Sb_Cliente
        AddHandler Rdb_Cliente_Uno.CheckedChanged, AddressOf Sb_Cliente

        AddHandler Rdb_Fecha_Emision_Entre.CheckedChanged, AddressOf Sb_Fecha_Emision
        AddHandler Rdb_Fecha_Emision_Todas.CheckedChanged, AddressOf Sb_Fecha_Emision

        AddHandler Rdb_Fecha_Cierre_Entre.CheckedChanged, AddressOf Sb_Fecha_Cierre
        AddHandler Rdb_Fecha_Cierre_Todas.CheckedChanged, AddressOf Sb_Fecha_Cierre

        AddHandler Rdb_Vendedor_Todos.CheckedChanged, AddressOf Sb_Vededor
        AddHandler Rdb_Vendedor_Uno.CheckedChanged, AddressOf Sb_Vededor

        Rdb_NroNegocio_Una.Checked = True
        Rdb_Vendedor_Todos.Checked = True
        Rdb_Cliente_Todo.Checked = True
        Rdb_Fecha_Emision_Todas.Checked = True
        Rdb_Fecha_Cierre_Todas.Checked = True


        

    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Fx_Filtrar()
    End Sub

    Private Sub BtnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCliente.Click
        Sb_Buscar_Cliente()
    End Sub

    Sub Sb_Buscar_Cliente()

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
        Dim _Cadena_ConexionSQL_Seleccionada = String.Empty

        Try

            Dim DatosConex As New ConexionBK

            Dim Directorio As String = Application.StartupPath & "\Data\"
            Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

            If Not _Exists Then
                DatosConex.WriteXml(Directorio & "Conexiones.xml")
                MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            DatosConex.ReadXml(Directorio & "Conexiones.xml")

            Dim Frm_ConexionBD As New Frm_ConexionBD
            Frm_ConexionBD.BtnAgregar.Visible = False
            Frm_ConexionBD.BtnGenerateKey.Visible = False
            Frm_ConexionBD.ShowDialog(Me)

            If Frm_ConexionBD.NombreConexionActiva = String.Empty Then
                Frm_ConexionBD.Dispose()
                Return
            Else
                _Cadena_ConexionSQL_Seleccionada = Fx_CadenaConexionSQL(Frm_ConexionBD.NombreConexionActiva, DatosConex)
            End If
            Frm_ConexionBD.Dispose()

            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Seleccionada

            Dim _TblEntidad As DataTable = Fx_Buscar_Cliente()
            'Dim _RowSucursal As DataRow

            If Not (_TblEntidad Is Nothing) Then
                _RowEntidad = _TblEntidad.Rows(0)
                TxtRazonCliente.Text = _RowEntidad.Item("NOKOEN")
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        Finally
            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
        End Try


    End Sub

    Private Function Fx_Buscar_Cliente() As DataTable

        Dim Fm As New Frm_BuscarEntidad_Mt(True)
        Fm.ShowInTaskbar = False
        Fm.Text = "BUSCAR CLIENTE"
        Fm.ShowDialog(Me)

        'Fm._Tbl_Inf_Entidad()

        If Fm.Pro_Entidad_Seleccionada Then

            Dim _TblEntidad As DataTable = Fm.Pro_TblEntidad
            Return _TblEntidad

        Else
            Return Nothing
        End If


    End Function



#Region "Eventos"

    Sub Sb_NroSOC()

        Grupo_Filtro_Fecha_Emision.Enabled = Rdb_NroNegocio_Todas.Checked
        Grupo_Filtro_Fecha_Cierre.Enabled = Rdb_NroNegocio_Todas.Checked
        Grupo_Filtro_Cliente.Enabled = Rdb_NroNegocio_Todas.Checked
        Grupo_Filtro_Vendedor.Enabled = Rdb_NroNegocio_Todas.Checked
        Grupo_Filtro_Estados.Enabled = Rdb_NroNegocio_Todas.Checked

        LblNroNegocio.Enabled = Rdb_NroNegocio_Todas.Checked

        If Rdb_NroNegocio_Una.Checked Then
            Txt_NroNegocio.Focus()
        Else
            Txt_NroNegocio.Text = String.Empty
        End If


    End Sub


    Sub Sb_Vededor()
        Cmb_Vendedor.Enabled = Rdb_Vendedor_Uno.Checked
    End Sub

    Sub Sb_Fecha_Emision()
        LblFecha_Emision1.Enabled = Rdb_Fecha_Emision_Entre.Checked
        LblFecha_Emision2.Enabled = Rdb_Fecha_Emision_Entre.Checked
        Dtp_Fecha_Emision_Desde.Enabled = Rdb_Fecha_Emision_Entre.Checked
        Dtp_Fecha_Emision_Hasta.Enabled = Rdb_Fecha_Emision_Entre.Checked
    End Sub

    Sub Sb_Fecha_Cierre()
        LblFecha_Cierre1.Enabled = Rdb_Fecha_Cierre_Entre.Checked
        LblFecha_Cierre2.Enabled = Rdb_Fecha_Cierre_Entre.Checked
        Dtp_Fecha_Cierre_Desde.Enabled = Rdb_Fecha_Cierre_Entre.Checked
        Dtp_Fecha_Cierre_Hasta.Enabled = Rdb_Fecha_Cierre_Entre.Checked
    End Sub

    Sub Sb_Cliente()
        BtnBuscarCliente.Enabled = Rdb_Cliente_Uno.Checked
        TxtRazonCliente.Enabled = Rdb_Cliente_Uno.Checked
        If Rdb_Cliente_Uno.Checked And String.IsNullOrEmpty(Trim(TxtRazonCliente.Text)) Then
            Sb_Buscar_Cliente()
        ElseIf Rdb_Cliente_Todo.Checked Then
            _RowEntidad = Nothing
            TxtRazonCliente.Text = String.Empty
        End If
    End Sub

#End Region

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub

    Private Sub Frm_SolCredito_Filtrar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txt_NroNegocio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_NroNegocio.KeyDown
        If e.KeyValue = Keys.Enter Then
            Fx_Filtrar()
        End If
    End Sub
End Class