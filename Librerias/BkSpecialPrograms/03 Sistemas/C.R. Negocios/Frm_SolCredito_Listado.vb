Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_SolCredito_Listado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Directorio_Seleccionado As String

    Dim _Segundos As Integer
    Dim Segundos As Long = 0
    Dim _Dir_Temp = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Negocios_Cli"
    Dim _Existe = System.IO.File.Exists(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

    Dim _DsNegocioCr As New DsNegocioCr

    Dim _Tipo_Informe As _Filtro_Negocios
    Dim _Filtro_Informe = "Where 1 > 0" & vbCrLf

    Dim _Tbl_Informe As DataTable

    Public Property Pro_Directorio_Seleccionado As String
        Get
            Return _Directorio_Seleccionado
        End Get
        Set(value As String)
            _Directorio_Seleccionado = value
        End Set
    End Property

    Public Property Pro_Tipo_Informe As _Filtro_Negocios
        Get
            Return _Tipo_Informe
        End Get
        Set(value As _Filtro_Negocios)
            _Tipo_Informe = value
        End Set
    End Property

    Public Property Pro_Filtro_Informe As Object
        Get
            Return _Filtro_Informe
        End Get
        Set(value As Object)
            _Filtro_Informe = value
        End Set
    End Property

    Enum _Filtro_Negocios
        Mis_Negocios
        Resolucion
        Filtro
    End Enum

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Inf, 22, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_LlenaCombo_Segundos()
        Cmb_MinutosActualizacion.SelectedValue = 3

    End Sub

    Private Sub Frm_SolCredito_Listado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        St_00.Text = String.Empty
        St_01.Text = String.Empty
        St_02.Text = String.Empty
        St_03.Text = String.Empty
        St_04.Text = String.Empty
        St_Extra.Text = String.Empty


        Sb_InsertarBotonenGrilla(Grilla_Inf, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)
        Sb_Actualizar_Grilla("", False)

        LblBarraEstado.Text = "Usuario activo: " & Nombre_funcionario_activo


        _DsNegocioCr.ReadXml(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

        Dim _Fila As DataRow = _DsNegocioCr.Tables("Tbl_Configuracion_local").Rows(0)


        Switch_.Value = True
        Tiempo_Act_Informe.Enabled = Switch_.Value
        'Txt_Ftp_Usuario.Text = _Fila.Item("Ftp_Usuario")
        'Txt_Ftp_Contrasena.Text = _Fila.Item("Ftp_Contrasena")
        'Txt_Ftp_Host.Text = _Fila.Item("Ftp_Host")
        'Txt_Ftp_Puerto.Text = _Fila.Item("Ftp_Puerto")

        'Txt_Directorio_Seleccionado.Text = _Fila.Item("Direcctorio_Archivos_Adjuntos")
        'Cmb_Correo_Al_Grabar.SelectedValue = _Fila.Item("Correo_Al_Grabar")
        'Cmb_Correo_Al_Cerrar.SelectedValue = _Fila.Item("Correo_Al_Cerrar")


    End Sub

    Public Function Sb_Buscar_Cliente() As DataTable

        Dim Fm As New Frm_BuscarEntidad_Mt(True)
        Fm.ShowInTaskbar = False
        Fm.Text = "BUSCAR CLIENTE"
        Fm.ShowDialog(Me)

        If Fm.Pro_Entidad_Seleccionada Then

            Dim _TblEntidad As DataTable = Fm.Pro_TblEntidad
            Return _TblEntidad

        Else
            Return Nothing
        End If


    End Function

    Sub Sb_Actualizar_Grilla(ByVal _Filtro As String,
                             ByVal _Filtrar As Boolean)

        Sb_Limpiar_WF()

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
                       "And Estado = 'PR' And Stand_By = 0" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'CM'" & vbCrLf &
                       "Where Nro_Negocio In (Select Nro_Negocio From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z1" & vbCrLf &
                       "Group by Nro_Negocio" & vbCrLf &
                       "having (Select COUNT(*) From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z2 Where Z2.Nro_Negocio = Z1.Nro_Negocio) = 4) " &
                       "And Estado = 'AN' And Stand_By = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        If Not _Filtrar Then
            If _Tipo_Informe = _Filtro_Negocios.Mis_Negocios Then
                _Filtro = "Where (Estado In ('ST','IN','CO','AN','CM','C3','PR'))" & vbCrLf &
                                  "OR (Estado = 'CE' And Fecha_Cierre = '" & Format(FechaDelServidor, "yyyyMMdd") & "')" & vbCrLf &
                                  "OR (Estado = 'NL' And Fecha_Cierre = '" & Format(FechaDelServidor, "yyyyMMdd") & "')"
            ElseIf _Tipo_Informe = _Filtro_Negocios.Resolucion Then
                _Filtro = "Where Estado In ('AN','PR','CM','C3')"
            End If
        End If

        Consulta_sql = "SELECT Id_Negocio,Nro_Negocio,Stand_By,Estado,Estado_Cerrado,Tipo,NomTipo," &
                       "CONVERT(VARCHAR, Fecha_Emision, 103) Fecha,CONVERT(VARCHAR, Fecha_Emision, 108) Hora," &
                       "Fecha_Emision,Fecha_Cierre,CodEntidad,CodSucursal,NomEntidad," &
                       "CodFuncionario,NomFuncionario," &
                       "(Select top 1 Linea_Credito_SC_Ac_UF From " & _Global_BaseBk & "Zw_Negocios_02_Det Z02 " &
                       "Where Z02.Nro_Negocio = Z01.Nro_Negocio) As 'CRED_SOL_UF'," &
                       "Empresa,Sucursal,NomSucursal,Cadena_Conexion," &
                       "(Select Count(*) From " & _Global_BaseBk & "Zw_Negocios_03_Apr Z03 " &
                       "Where Z03.Nro_Negocio = Z01.Nro_Negocio ) as St,'' As Color_Estatus,'' As Estatus," &
                       "Nom_Clas_Crediticia,Motivo_Anula,Fun_Corregir" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Negocios_01_Enc Z01" & vbCrLf &
                       _Filtro
        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)


        With Grilla_Inf

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla_Inf, True)

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").HeaderText = "Situación"
            .Columns("BtnImagen").Width = 50

            .Columns("Nro_Negocio").Visible = True
            .Columns("Nro_Negocio").HeaderText = "N° Negocio"
            .Columns("Nro_Negocio").Width = 90

            .Columns("NomTipo").Visible = True
            .Columns("NomTipo").HeaderText = "Tipo negocio"
            .Columns("NomTipo").Width = 230

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha creación"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").Width = 60
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm:ss"

            .Columns("NomEntidad").Visible = True
            .Columns("NomEntidad").HeaderText = "Cliente"
            .Columns("NomEntidad").Width = 280

            .Columns("CRED_SOL_UF").Visible = True
            .Columns("CRED_SOL_UF").HeaderText = "Monto Solicitud UF"
            .Columns("CRED_SOL_UF").Width = 130
            .Columns("CRED_SOL_UF").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CRED_SOL_UF").DefaultCellStyle.Format = "UF ###,##.##"

            .Columns("NomSucursal").Visible = True
            .Columns("NomSucursal").HeaderText = "Sucursal"
            .Columns("NomSucursal").Width = 200

            .Columns("Color_Estatus").Visible = True
            .Columns("Color_Estatus").HeaderText = "."
            .Columns("Color_Estatus").Width = 20

            .Columns("Estatus").Visible = True
            .Columns("Estatus").HeaderText = "Estatus"
            .Columns("Estatus").Width = 180

            .Columns("Nom_Clas_Crediticia").Visible = True
            .Columns("Nom_Clas_Crediticia").HeaderText = "Clas. Crediticia"
            .Columns("Nom_Clas_Crediticia").Width = 150

        End With

        Sb_Marcar_Grilla()

    End Sub

    Sub Sb_Marcar_Grilla()

        Try

            With Grilla_Inf


                If CBool(.RowCount) Then

                    'Dim i = 0
                    LblEspera.Visible = True
                    Barra_progreso.Visible = True

                    Barra_progreso.Maximum = .RowCount '100
                    For Each row As DataGridViewRow In .Rows
                        System.Windows.Forms.Application.DoEvents()
                        Dim i = row.Index

                        Barra_progreso.Value = i '((i * 100) / .RowCount)
                        Barra_progreso.Text = "Marcando Fila: " & FormatNumber(i, 0) & " de " & FormatNumber(.RowCount, 0) 'Barra_progreso.Value

                        Dim Estado As String = NuloPorNro(row.Cells("Estado").Value, "")
                        Dim _St = row.Cells("St").Value
                        Dim _Stan_By As Boolean = NuloPorNro(row.Cells("Stand_By").Value, False)
                        Dim _Estado_Cerrado As String = Trim(row.Cells("Estado_Cerrado").Value)

                        'Dim _IdMaeedo_OCC = NuloPorNro((row.Cells("IdMaeedo_OCC").Value), 0)
                        'Dim _Nro_OCC = NuloPorNro((row.Cells("Nro_OCC").Value), 0)
                        'Dim _Fecha_Apelacion As Date = row.Cells("Fecha_Apelacion").Value

                        Dim _Fecha_Emision As Date = row.Cells("Fecha_Emision").Value

                        row.Cells("Nro_Negocio").Style.ForeColor = Color.Black
                        row.Cells("Estatus").Style.Font = New Font("Tahoma", 9, FontStyle.Bold)
                        row.Cells("Estatus").Style.BackColor = Color.White

                        If _Stan_By Then

                            row.DefaultCellStyle.BackColor = Color.WhiteSmoke ' Color.Coral
                            row.DefaultCellStyle.ForeColor = Color.Black ' Color.Coral
                            row.Cells("Estado").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                            row.Cells("Nro_Negocio").Style.ForeColor = Color.White
                            row.Cells("BtnImagen").Value = My.Resources.Rs_NegocioCr.cloud3
                            row.Cells("Estatus").Value = "Stand-By"
                            row.Cells("Color_Estatus").Style.BackColor = Color.White
                        Else

                            If Estado = "IN" Then

                                row.Cells("Estatus").Value = "Ingresado"
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(1)
                                row.Cells("Color_Estatus").Style.BackColor = Color.OrangeRed

                                '.row.Cells("Estado").Style.ForeColor = Color.Green
                                '.row.DefaultCellStyle.BackColor = Color.White ' Color.Coral
                                '.row.Cells("Estado").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)

                            ElseIf Estado = "CO" Then

                                Dim _Fun_Corregir = row.Cells("Fun_Corregir").Value
                                row.Cells("Estatus").Value = "CORREGIR (" & _Fun_Corregir & ")"
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(1)
                                row.Cells("Estatus").Style.BackColor = Color.Yellow
                                row.Cells("Color_Estatus").Style.BackColor = Color.Yellow

                            ElseIf Estado = "AN" Then

                                row.Cells("Estatus").Value = "Analisis"
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(1)
                                row.Cells("Color_Estatus").Style.BackColor = Color.IndianRed

                            ElseIf Estado = "PR" Then

                                row.Cells("Estatus").Value = "En proceso"
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(3)
                                row.Cells("Color_Estatus").Style.BackColor = Color.Gold

                            ElseIf Estado = "CM" Then

                                row.Cells("Estatus").Value = "Completado"

                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(2)
                                row.Cells("Color_Estatus").Style.BackColor = Color.LightGreen

                            ElseIf Estado = "C1" Then ' ACEPTADO

                                row.Cells("Estatus").Value = "Cerrado: " & _Estado_Cerrado
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(4)
                                row.Cells("Color_Estatus").Style.BackColor = Color.LightBlue

                            ElseIf Estado = "C2" Then ' RECHAZADO

                                row.Cells("Estatus").Value = "Cerrado:  " & _Estado_Cerrado
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(5)
                                row.Cells("Color_Estatus").Style.BackColor = Color.Red

                            ElseIf Estado = "C3" Then

                                row.Cells("Estatus").Value = _Estado_Cerrado
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(6)
                                row.Cells("Color_Estatus").Style.BackColor = Color.Goldenrod


                            ElseIf Estado = "NL" Then

                                row.DefaultCellStyle.BackColor = Color.LightGray ' Color.Coral
                                row.DefaultCellStyle.ForeColor = Color.Gray ' Color.Coral
                                row.Cells("Estado").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
                                row.Cells("Color_Estatus").Style.BackColor = Color.Black
                                row.Cells("BtnImagen").Value = Imagenes_listado_20x20.Images.Item(7)

                            End If

                        End If

                    Next

                End If

            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Barra_progreso.Value = 0
            LblEspera.Visible = False
            Barra_progreso.Visible = False
        End Try

    End Sub

    Function Fx_Crear_Filtro() As String

        Dim Dia_1 As String = numero_(Now.Day, 2)
        Dim Mes_1 As String = numero_(Now.Month, 2)
        Dim Ano_1 As String = Now.Year

        Dim Dia_2 As String = numero_(Now.Day, 2)
        Dim Mes_2 As String = numero_(Now.Month, 2)
        Dim Ano_2 As String = Now.Year

        Dim _FiltroConsulta = String.Empty

        _FiltroConsulta = "And Fecha_Emision BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                          "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102)"

    End Function

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Sb_Actualizar_Grilla("", False)
    End Sub

    Private Sub Tiempo_Act_Informe_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Act_Informe.Tick
        If _Segundos = 0 Then
            _Segundos = Cmb_MinutosActualizacion.SelectedValue * 60
            Sb_Actualizar_Grilla("", False)

        End If
        _Segundos -= 1
        LblSegundosF.Text = _Segundos

    End Sub

    Sub Sb_LlenaCombo_Segundos()

        caract_combo(Cmb_MinutosActualizacion)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "1" : dr("Hijo") = "1 minuto" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "2" : dr("Hijo") = "2 minutos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "3" : dr("Hijo") = "3 minutos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "5" : dr("Hijo") = "5 minutos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "10" : dr("Hijo") = "10 minutos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "15" : dr("Hijo") = "15 minutos" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "30" : dr("Hijo") = "30 minutos" : dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With Cmb_MinutosActualizacion
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Sub

    Private Sub Switch__ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Switch_.ValueChanged
        Tiempo_Act_Informe.Enabled = Switch_.Value
        Progreso_Monitoreo.IsRunning = Switch_.Value
        LblSegundosF.Visible = Switch_.Value
        _Segundos = Cmb_MinutosActualizacion.SelectedValue * 60

        If Switch_.Value Then
            Cmb_MinutosActualizacion.Enabled = False
        Else
            Cmb_MinutosActualizacion.Enabled = True
            '_Filtro_Activo = False
        End If
    End Sub

    Sub Sb_Abrir_Documento(ByVal _Nro_Negocio As String,
                           ByVal _Stand_By As Boolean,
                           ByVal _CodFuncionario_SCN As String,
                           ByVal _Cadena_Conexion As String)

        If _CodFuncionario_SCN <> FUNCIONARIO Then
            If Not Fx_Tiene_Permiso(Me, "Scn00012") Then Return
        End If

        Dim Fm As New Frm_SolCredito_Ingreso

        'Fm._RowSucursal = _RowSucursal
        Fm.Pro_TipoDocumento = Frm_SolCredito_Ingreso._TipoDos.VerDocumento
        Fm.Pro_NroNegocio = _Nro_Negocio
        Fm.Pro_Stand_By = _Stand_By
        Fm.pro_Cadena_ConexionSQL_Seleccionada = _Cadena_Conexion

        If _Stand_By Then
            Fm.Btn_Gestion_Comite.Visible = False
        Else
            Fm.Btn_Gestion_Comite.Visible = True
        End If

        Fm.Btn_Anular_Documento.Visible = True
        Fm.Pro_Directorio_Negocios = _Directorio_Seleccionado
        Fm.ShowDialog(Me)
        Sb_Actualizar_Grilla("", False)
    End Sub

    Private Sub Grilla_Inf_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla_Inf.CellMouseDoubleClick

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
        Switch_.Value = False

        Dim _Fila As DataGridViewRow = Grilla_Inf.Rows(Grilla_Inf.CurrentRow.Index)

        Dim _Nro_Negocio As String = _Fila.Cells("Nro_Negocio").Value
        Dim _Stand_By As Boolean = _Fila.Cells("Stand_By").Value
        Dim _Cadena_Conexion = _Fila.Cells("Cadena_Conexion").Value
        Dim _CodFuncionario = _Fila.Cells("CodFuncionario").Value
        Dim _EstadoOld = _Fila.Cells("Estado").Value
        Dim _Motivo_Anula = _Fila.Cells("Motivo_Anula").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_01_Enc" & vbCrLf &
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1

        Dim _Estado As String

        Dim _TblFilaSeleccionada As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblFilaSeleccionada.Rows.Count) Then

            _Estado = _TblFilaSeleccionada.Rows(0).Item("Estado")

            If _Estado <> _EstadoOld Then
                MessageBoxEx.Show(Me, "El estado de este negocio ha cambiado", "Cambio de estado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_Actualizar_Grilla("", False)
                Return
            End If

            If _Estado = "NL" Then
                'Beep()
                'ToastNotification.Show(Me, "DOCUMENTO NULO", _
                '                      My.Resources.cross, _
                '                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                MessageBoxEx.Show(Me, "MOTIVO: " & _Motivo_Anula, "Documento anulado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)


                Return
            ElseIf _Estado = "CO" Then

                Dim _Fun_Corregir_Motivo As String = _TblFilaSeleccionada.Rows(0).Item("Fun_Corregir_Motivo")

                MessageBoxEx.Show(Me, _Fun_Corregir_Motivo, "Motivo corrección", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If String.IsNullOrEmpty(_Cadena_Conexion) Then
                MessageBoxEx.Show(Me, "Documento con problemas!!", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Sb_Abrir_Documento(_Nro_Negocio, _Stand_By, _CodFuncionario, _Cadena_Conexion)
            End If

            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
        Else
            MessageBoxEx.Show(Me, "No se encontro el registro en la base de datos", "Error desconocido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Sb_Actualizar_Grilla("", False)
        End If

        Switch_.Value = True

    End Sub

    Enum _Tipo_Negocio
        Negocio_por_sobregiro
        Negocio_aumento_linea_credito
    End Enum

    Sub Sb_Crear_Negocio()

        If Fx_Tiene_Permiso(Me, "Scn00004") Then

            Switch_.Value = False

            Dim _Msj_Tsc As LsValiciones.Mensajes

            _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Me, FechaDelServidor)

            If Not _Msj_Tsc.EsCorrecto Then
                Return
            End If

            'If Not Fx_Revisar_Tasa_Cambio(Me, FechaDelServidor) Then
            '    Exit Sub
            'End If

            Dim _Rut_Empresa_Seleccionada = String.Empty

            Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
            Dim _Global_BaseBk_Original = _Global_BaseBk

            Dim _Cadena_ConexionSQL_Seleccionada = String.Empty
            Dim _Global_BaseBk_Seleccionada = String.Empty

            Dim Directorio As String = Application.StartupPath & "\Data\"

            Try

                Dim DatosConex As New ConexionBK

                Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

                If Not _Exists Then
                    DatosConex.WriteXml(Directorio & "Conexiones.xml")
                    MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                DatosConex.ReadXml(Directorio & "Conexiones.xml")

                Dim Frm_ConexionBD As New Frm_ConexionBD
                Frm_ConexionBD.BtnAgregar.Visible = False
                Frm_ConexionBD.BtnGenerateKey.Visible = False
                Frm_ConexionBD.ShowDialog(Me)

                Dim _RowConexion As DataRow

                If Frm_ConexionBD.NombreConexionActiva = String.Empty Then
                    Frm_ConexionBD.Dispose()
                    Return
                Else
                    _RowConexion = Frm_ConexionBD.Pro_RowConexion
                    _Rut_Empresa_Seleccionada = _RowConexion.Item("Rut")

                    _Cadena_ConexionSQL_Seleccionada = Fx_CadenaConexionSQL(Frm_ConexionBD.NombreConexionActiva, DatosConex)
                    Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Seleccionada

                    Dim _Clas_Bk As New Class_Conectar_Base_BakApp(Me)
                    If _Clas_Bk.Pro_Existe_Base Then
                        _Global_BaseBk = _Clas_Bk.Pro_Row_Tabcarac.Item("Global_BaseBk")
                    Else
                        Throw New Exception("No se encontro base de datos BakApp")
                    End If

                End If
                Frm_ConexionBD.Dispose()

                Dim _TblEntidad As DataTable = Sb_Buscar_Cliente()
                Dim _RowSucursal As DataRow

                If Not (_TblEntidad Is Nothing) Then

                    Dim Fm_s As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Sucursal)
                    Fm_s.Pro_Empresa = ModEmpresa
                    Fm_s.Pro_Sucursal = ModSucursal
                    Fm_s.Text = "Seleccione la Sucursal"
                    Fm_s.ShowDialog(Me)

                    If Fm_s.Pro_Seleccionado Then
                        _RowSucursal = Fm_s.Pro_RowBodega
                    Else
                        Exit Sub
                    End If

                    Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
                    _Global_BaseBk = _Global_BaseBk_Original

                    'SQL_ServerClass.AbrirConexion_SQLServer(cn1)

                    Dim Fm As New Frm_SolCredito_Ingreso
                    Fm.Pro_TblEntidad = _TblEntidad
                    Fm.Pro_RowSucursal = _RowSucursal
                    Fm.Pro_TipoDocumento = Frm_SolCredito_Ingreso._TipoDos.Nuevo
                    Fm.Pro_Cadena_ConexionSQL_Seleccionada = _Cadena_ConexionSQL_Seleccionada
                    Fm.Pro_Directorio_Negocios = _Directorio_Seleccionado
                    Fm.Btn_Gestion_Comite.Visible = False
                    Fm.Btn_Anular_Documento.Visible = False

                    'Fm.Btn_Participantes.Visible = False
                    Fm.ShowDialog(Me)

                End If

            Catch ex As Exception
                MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
                _Global_BaseBk = _Global_BaseBk_Original
                Sb_Actualizar_Grilla("", False)
                Switch_.Value = True
            End Try
        End If
    End Sub


    Private Sub Grilla_Inf_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Inf.CellEnter

        Dim _Fila_dg As DataGridViewRow = Grilla_Inf.Rows(Grilla_Inf.CurrentRow.Index)

        With _Fila_dg

            Dim _Nro_Negocio As String = .Cells("Nro_Negocio").Value
            Dim _Stand_By As Boolean = .Cells("Stand_By").Value
            Dim _Cadena_Conexion = .Cells("Cadena_Conexion").Value
            Dim _CodFuncionario = .Cells("CodFuncionario").Value
            Dim _Estado = .Cells("Estado").Value
            Dim _NomTipo = .Cells("NomTipo").Value
            Dim _Fecha = .Cells("Fecha").Value

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr" & vbCrLf &
                           "Where Nro_Negocio = '" & _Nro_Negocio & "'" & vbCrLf &
                           "Order by Fecha_Hora_Aprueba"

            Sb_Limpiar_WF()

            If _Stand_By Then
                Return
            End If

            With St_00
                .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>Negocio N°: " & _Nro_Negocio &
                        "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _NomTipo & "<br/>Fecha: " & _Fecha & "</font>"
                .Value = 100
                .TextColor = Color.Black
                .ProgressColors = New System.Drawing.Color() {Color.GreenYellow, Color.GreenYellow}
            End With


        End With

        Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblAprobacion.Rows.Count) Then

            Dim _Contado = 1

            For Each _Fila As DataRow In _TblAprobacion.Rows

                Dim _CodAprobacion = _Fila.Item("CodAprobacion")
                Dim _CodAutoriza = _Fila.Item("CodAutoriza")
                Dim _Autorizado = _Fila.Item("Autorizado")
                Dim _Ausente = _Fila.Item("Ausente")
                Dim _NombreAprueba = "Revisado" '_Fila.Item("NombreAprueba")
                Dim _NomAprobacion = _Fila.Item("NomAprobacion")
                Dim _Colores_Texto
                Dim _Colores_Progreso
                Dim _Tex_Autorizado

                If _Autorizado Then
                    _Tex_Autorizado = "<b>AUTORIZADO</b>"
                    _Colores_Texto = Color.Black
                    _Colores_Progreso = New System.Drawing.Color() {Color.GreenYellow, Color.GreenYellow}
                Else
                    _Tex_Autorizado = "<b>RECHAZADO</b>"
                    _Colores_Texto = Color.White
                    _Colores_Progreso = New System.Drawing.Color() {Color.Red, Color.Red}
                End If

                If _Ausente Then
                    _NombreAprueba = "No se pronuncia"
                    _Tex_Autorizado = "<b>AUSENTE</b>"
                    _Colores_Texto = Color.Black
                    _Colores_Progreso = New System.Drawing.Color() {Color.Yellow, Color.Yellow}
                End If



                If _CodAprobacion = "01" Then
                    _NomAprobacion = "Gerencia G.G.G. (" & _CodAutoriza & ")"
                    With St_01
                        .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _NomAprobacion &
                                "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _NombreAprueba & "<br/>" & _Tex_Autorizado & "</font>"

                        .Value = 100
                        .TextColor = _Colores_Texto
                        .ProgressColors = _Colores_Progreso
                    End With
                ElseIf _CodAprobacion = "02" Then
                    _NomAprobacion = "Gerencia G.A.F. (" & _CodAutoriza & ")"
                    With St_02
                        .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _NomAprobacion &
                                "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _NombreAprueba & "<br/>" & _Tex_Autorizado & "</font>"

                        .Value = 100
                        .TextColor = _Colores_Texto
                        .ProgressColors = _Colores_Progreso
                    End With
                ElseIf _CodAprobacion = "03" Then
                    _NomAprobacion = "Gerencia G.C.C. (" & _CodAutoriza & ")"
                    With St_03
                        .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _NomAprobacion &
                                "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _NombreAprueba & "<br/>" & _Tex_Autorizado & "</font>"

                        .Value = 100
                        .TextColor = _Colores_Texto
                        .ProgressColors = _Colores_Progreso
                    End With
                ElseIf _CodAprobacion = "Ex" Then
                    _NomAprobacion = "Autorización Extraordinaria (" & _CodAutoriza & ")"
                    With St_Extra
                        .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _NomAprobacion &
                                "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _NombreAprueba & "<br/>" & _Tex_Autorizado & "</font>"

                        .Value = 100
                        .TextColor = _Colores_Texto
                        .ProgressColors = _Colores_Progreso
                        .Visible = True
                    End With
                End If



                '<font size="+2"><b>" & _NomAprobacion & "</b></font><br/><font size="-1">" & _NombreAprueba & "<br/>" & _Tex_Autorizado & "</font>

                'If _Contado = 1 Then
                'With St_01
                '.Text = _Leyenda
                '.Value = 100
                '.TextColor = _Colores_Texto
                '.ProgressColors = _Colores_Progreso
                'End With
                'ElseIf _Contado = 2 Then
                'With St_02
                '.Text = _Leyenda
                '.Value = 100
                '.TextColor = _Colores_Texto
                '.ProgressColors = _Colores_Progreso
                'End With
                'ElseIf _Contado = 3 Then
                'With St_03
                '.Text = _Leyenda
                '.Value = 100
                '.TextColor = _Colores_Texto
                '.ProgressColors = _Colores_Progreso
                'End With
                'ElseIf _Contado = 4 Then
                'With St_04
                '.Text = _Leyenda
                '.Value = 100
                '.TextColor = _Colores_Texto
                '.ProgressColors = _Colores_Progreso
                'End With
                'End If
                _Contado += 1
            Next

        End If

        Me.Refresh()

    End Sub


    Sub Sb_Limpiar_WF()

        With St_00
            .Text = "<font size=" & Chr(34) & "+2" & Chr(34) &
                    "><b>Solicitud de negocio</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">Espera<br/>1ra etapa</font>"
            .Value = 100
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {Color.White, Color.White}
        End With

        With St_01
            .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>Gerencia G.G.  </b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">Espera              <br/>...</font>"
            .Value = 100
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {Color.White, Color.White}
        End With

        With St_02
            .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>Gerencia G.A.F.</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">Espera              <br/>...</font>"
            .Value = 100
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {Color.White, Color.White}
        End With

        With St_03
            .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>Gerencia G.C.C.</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">Espera              <br/>...</font>"
            .Value = 100
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {Color.White, Color.White}
        End With

        With St_Extra
            .Text = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>Autorización Extraordinaria</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">Espera              <br/>...</font>"
            .Value = 100
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {Color.White, Color.White}
            .Visible = False
        End With

        Me.Refresh()
        'With St_04
        ' .Text = "..."
        ' .Value = 100
        ' .TextColor = Color.Black
        ' .ProgressColors = New System.Drawing.Color() {Color.White, Color.White}
        ' End With

    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click

        Dim Fm As New Frm_SolCredito_Filtrar
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then
            _Filtro_Informe = Fm.Pro_Filtro
            Sb_Actualizar_Grilla(_Filtro_Informe, True)
            Switch_.Value = False
        End If

    End Sub

    Private Sub Btn_Crear_Negocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Negocio.Click
        Sb_Crear_Negocio()
    End Sub

    Private Sub Btn_Mantencion_Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mantencion_Usuarios.Click

        If Fx_Tiene_Permiso(Me, "User0001") Then
            Switch_.Value = False
            Dim Fm As New Frm_Usuarios_Bk
            Fm.ShowDialog(Me)
            Fm.Dispose()
            Switch_.Value = True
        End If

    End Sub

    Private Sub Btn_Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimizar.Click
        Me.Close()
        Return
        Me.Hide()
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(5, "Info. BakApp", "Sistema de negocios quedara en barra de tareas", ToolTipIcon.Info)
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click

        If _Tipo_Informe = _Filtro_Negocios.Resolucion Then

            If Not Fx_Tiene_Permiso(Me, "Scn00010", FUNCIONARIO, True) Then
                MessageBoxEx.Show(Me, "Usted no tiene permiso para ver este formulario",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                Exit Sub
            End If
        End If

        NotifyIcon1.Visible = False
        Me.WindowState = FormWindowState.Maximized
        Me.Show()

        _Segundos = Cmb_MinutosActualizacion.SelectedValue * 60

        Sb_Actualizar_Grilla("", False)
        Switch_.Value = True

        'If _Tipo_Informe = _Filtro_Negocios.Mis_Negocios Then
        'Me.Text = "LISTADO DE MIS SOLICITUDES DE COMPRA. USUARIO ACTIVO: " & Nombre_funcionario_activo
        'Else
        'Me.Text = "LISTADO DE SOLICITUDES DE COMPRA"
        'End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click

        If Fx_Tiene_Permiso(Me, "Scn00020") Then
            Switch_.Value = False
            If CBool(_Tbl_Informe.Rows.Count) Then

                Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Informe, "", "Nro_Negocio", False, False, "'")


                Consulta_sql = My.Resources.Rs_NegocioCr.SqlQuery_Informe_Negocios & vbCrLf & vbCrLf &
                              "Where Enc.Nro_Negocio In " & _Filtro

                Dim _TblExcel As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                ExportarTabla_JetExcel_Tabla(_TblExcel, Me, "Negocios")
            Else

                Beep()
                ToastNotification.Show(Me, "NO EXISEN DATOS QUE MOSTRAR", My.Resources.cross,
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            End If
            Switch_.Value = True
        End If


    End Sub

    Private Sub Btn_Mantencion_De_Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mantencion_De_Usuarios.Click

        If Fx_Tiene_Permiso(Me, "CfEnt001") Then

            Switch_.Value = False

            Dim _Rut_Empresa_Seleccionada = String.Empty

            Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
            Dim _Global_BaseBk_Original = _Global_BaseBk

            Dim _Cadena_ConexionSQL_Seleccionada = String.Empty
            Dim _Global_BaseBk_Seleccionada = String.Empty

            Dim Directorio As String = Application.StartupPath & "\Data\"

            Try

                Dim DatosConex As New ConexionBK

                Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

                If Not _Exists Then
                    DatosConex.WriteXml(Directorio & "Conexiones.xml")
                    MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                DatosConex.ReadXml(Directorio & "Conexiones.xml")

                Dim Frm_ConexionBD As New Frm_ConexionBD
                Frm_ConexionBD.BtnAgregar.Visible = False
                Frm_ConexionBD.BtnGenerateKey.Visible = False
                Frm_ConexionBD.ShowDialog(Me)

                Dim _RowConexion As DataRow

                If Frm_ConexionBD.NombreConexionActiva = String.Empty Then
                    Frm_ConexionBD.Dispose()
                    Return
                Else
                    _RowConexion = Frm_ConexionBD.Pro_RowConexion
                    _Rut_Empresa_Seleccionada = _RowConexion.Item("Rut")
                    Cadena_ConexionSQL_Server = Fx_CadenaConexionSQL(Frm_ConexionBD.NombreConexionActiva, DatosConex)


                    Dim _Clas_Bk As New Class_Conectar_Base_BakApp(Me)
                    If _Clas_Bk.Pro_Existe_Base Then
                        _Global_BaseBk = _Clas_Bk.Pro_Row_Tabcarac.Item("Global_BaseBk")
                    Else
                        Throw New Exception("No se encontro base de datos BakApp")
                    End If
                End If

                Frm_ConexionBD.Dispose()

                Dim Fm As New Frm_BuscarEntidad_Mt(False)
                Fm.Pro_Crear_Entidad = True
                Fm.ShowInTaskbar = False
                Fm.Text = "MANTENCION DE ENTIDADES"
                Fm.ShowDialog(Me)
                Fm.Dispose()

            Catch ex As Exception
                MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
                _Global_BaseBk = _Global_BaseBk_Original
                Sb_Actualizar_Grilla("", False)
                Switch_.Value = True
            End Try
        End If

    End Sub
End Class
