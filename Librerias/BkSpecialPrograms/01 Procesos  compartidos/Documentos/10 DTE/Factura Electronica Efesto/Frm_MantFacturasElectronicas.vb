Imports System.IO
Imports System.Text
Imports DevComponents.DotNetBar

Public Class Frm_MantFacturasElectronicas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_MFElec As New Class_MantFacturasElect
    Dim _AmbienteCertificacion As Integer

    Dim _Ult_Trackid_Procesado As String
    Dim _Dv As New DataView

    Dim _Ds As DataSet

    Public Property Cl_MFElec As Class_MantFacturasElect
        Get
            Return _Cl_MFElec
        End Get
        Set(value As Class_MantFacturasElect)
            _Cl_MFElec = value
        End Set
    End Property

    Public Property Ds As DataSet
        Get
            Return _Ds
        End Get
        Set(value As DataSet)
            _Ds = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

        _AmbienteCertificacion = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

    End Sub

    Private Sub Frm_MantFacturasElectronicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown

        Chk_SoloFirmadosXBakapp.Checked = False

        Sb_Actualizar_Grilla()

        If CBool(_AmbienteCertificacion) Then
            Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
            MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
            Lbl_Etiqueta.Text = "Ambiente de Certificación y Prueba"
        End If

        'bgWorker = New BackgroundWorker
        'AddHandler bgWorker.DoWork, AddressOf MyWorker_DoWork
        'AddHandler bgWorker.RunWorkerCompleted, AddressOf MyWorker_RunWorkerCompleted

        'bgWorker.RunWorkerAsync()

    End Sub


    Sub Sb_Actualizar_Grilla()

        Grilla.Columns.Clear()

        'Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        'Dim _Tbl_Informe As DataTable = _New_Ds.Tables(0)
        '_Dv.Table = _New_Ds.Tables("Table")

        _Dv.Table = _Ds.Tables("Table") 'Fx_Generar_Informe().Tables("Table")

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Tido_Nudo").Visible = True
            .Columns("Tido_Nudo").HeaderText = "TD-Número"
            .Columns("Tido_Nudo").Width = 100
            .Columns("Tido_Nudo").Frozen = True
            .Columns("Tido_Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Width = 230
            .Columns("NOKOEN").Frozen = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").Frozen = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").Visible = True
            .Columns("SUDO").HeaderText = "Suc"
            .Columns("SUDO").Width = 40
            .Columns("SUDO").Frozen = True
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFUDO").Visible = True
            .Columns("KOFUDO").HeaderText = "Resp"
            .Columns("KOFUDO").Width = 40
            .Columns("KOFUDO").Frozen = True
            .Columns("KOFUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Trackid").Visible = True
            .Columns("Trackid").HeaderText = "Trackid"
            .Columns("Trackid").Width = 70
            .Columns("Trackid").Frozen = True
            .Columns("Trackid").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DocFirmado").Visible = True
            .Columns("DocFirmado").HeaderText = "Firmado"
            .Columns("DocFirmado").Width = 50
            .Columns("DocFirmado").Frozen = True
            .Columns("DocFirmado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Est."
            .Columns("Estado").Width = 30
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Glosa").Visible = True
            .Columns("Glosa").HeaderText = "Glosa"
            .Columns("Glosa").Width = 160
            .Columns("Glosa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("LeyendaEmail").Visible = True
            .Columns("LeyendaEmail").HeaderText = "Correo"
            .Columns("LeyendaEmail").Width = 300
            .Columns("LeyendaEmail").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Id_Dte").Visible = True
            .Columns("Id_Dte").HeaderText = "Id_Dte"
            .Columns("Id_Dte").Width = 50
            .Columns("Id_Dte").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Id_Trackid").Visible = True
            .Columns("Id_Trackid").HeaderText = "Id_Trackid"
            .Columns("Id_Trackid").Width = 50
            .Columns("Id_Trackid").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        '_DisplayIndex += 1
        'InsertarBotonenGrilla(Grilla, "Btn_DocFirmado", "Documento firmado", "Firmado", _DisplayIndex, _Tipo_Boton.Imagen)
        '_DisplayIndex += 1
        'InsertarBotonenGrilla(Grilla, "Btn_EnviadoSII", "EnviadoSII", "Env.SII", _DisplayIndex, _Tipo_Boton.Imagen)
        '_DisplayIndex += 1
        'InsertarBotonenGrilla(Grilla, "Btn_EstadoEnv", "EstadoEnv", "Estado", _DisplayIndex, _Tipo_Boton.Imagen)
        '_DisplayIndex += 1
        'InsertarBotonenGrilla(Grilla, "Btn_Mail", "Mail", "Mail", _DisplayIndex, _Tipo_Boton.Imagen)

        'Dim Fm_Espera As New Frm_Form_Esperar
        'Fm_Espera.BarraCircular.IsRunning = True
        'Fm_Espera.Show()

        'For Each _Fila As DataGridViewRow In Grilla.Rows
        '    Sb_Pintar_Fila(_Fila)
        'Next

        'Fm_Espera.Dispose()

        Grilla.Refresh()
        Me.Refresh()

        'AddHandler Grilla.CellFormatting, AddressOf Sb_Grilla_CellFormatting

    End Sub

    Sub Sb_Pintar_Fila(_Fila As DataGridViewRow)

        Dim _ListaImagenes As ImageList

        Try

            If Global_Thema = Enum_Themas.Oscuro Then
                _ListaImagenes = Img_Imagenes_Dark
            Else
                _ListaImagenes = Img_Imagenes
            End If

            _Fila.Cells("Btn_DocFirmado").Value = _ListaImagenes.Images.Item("option-check-box-unselected.png")
            _Fila.Cells("Btn_EnviadoSII").Value = _ListaImagenes.Images.Item("option-check-box-unselected.png")
            _Fila.Cells("Btn_EstadoEnv").Value = _ListaImagenes.Images.Item("option-check-box-unselected.png")
            _Fila.Cells("Btn_Mail").Value = _ListaImagenes.Images.Item("option-check-box-unselected.png")

            If _Fila.Cells("DocFirmado").Value Then
                _Fila.Cells("Btn_DocFirmado").Value = _ListaImagenes.Images.Item("symbol-ok.png")
            Else
                _Fila.Cells("Btn_DocFirmado").Value = _ListaImagenes.Images.Item("symbol-cancel.png")
            End If

            If _Fila.Cells("EnviadoSII").Value Then
                _Fila.Cells("Btn_EnviadoSII").Value = _ListaImagenes.Images.Item("symbol-ok.png")
            Else
                If _Fila.Cells("DocFirmado").Value Then
                    If Not String.IsNullOrEmpty("Trackid") Then
                        _Fila.Cells("Btn_EnviadoSII").Value = _ListaImagenes.Images.Item("emoticon-wink.png")
                    Else
                        _Fila.Cells("Btn_EnviadoSII").Value = _ListaImagenes.Images.Item("symbol-cancel.png")
                    End If
                End If
            End If

            If _Fila.Cells("Procesar").Value And Not _Fila.Cells("Procesado").Value Then
                _Fila.Cells("Btn_EstadoEnv").Value = _ListaImagenes.Images.Item("emoticon-wink.png") '("btn-blue-play-pause.png")
            End If

            If _Fila.Cells("AceptadoSII").Value Then
                _Fila.Cells("Btn_EstadoEnv").Value = _ListaImagenes.Images.Item("symbol-ok.png")
            End If

            If _Fila.Cells("RechazadoSII").Value Then
                _Fila.Cells("Btn_EstadoEnv").Value = _ListaImagenes.Images.Item("symbol-cancel.png")
            End If

            If _Fila.Cells("ReparoSII").Value Then
                _Fila.Cells("Btn_EstadoEnv").Value = _ListaImagenes.Images.Item("symbol-ok-warning.png")
            End If

            If _Fila.Cells("EnviarMail").Value Then
                _Fila.Cells("Btn_Mail").Value = _ListaImagenes.Images.Item("emoticon-wink.png")
            End If

            If _Fila.Cells("MailToDiablito").Value Then
                _Fila.Cells("Btn_Mail").Value = _ListaImagenes.Images.Item("mailbox-in.png")
            End If

            If _Fila.Cells("ErrorMailToDiablito").Value Then
                _Fila.Cells("Btn_Mail").Value = _ListaImagenes.Images.Item("mailbox-junk.png")
            End If

            If _Fila.Cells("MailEnviado").Value Then
                _Fila.Cells("Btn_Mail").Value = _ListaImagenes.Images.Item("symbol-ok.png")
            End If

            If _Fila.Cells("ErrorEnviarMail").Value Then
                _Fila.Cells("Btn_Mail").Value = _ListaImagenes.Images.Item("symbol-cancel.png")
            End If

            If _Fila.Cells("Estado").Value = "RCT" Or _Fila.Cells("Estado").Value = "RFR" Then
                _Fila.Cells("Btn_DocFirmado").Value = _ListaImagenes.Images.Item("symbol-cancel.png")
                _Fila.Cells("Btn_EnviadoSII").Value = _ListaImagenes.Images.Item("symbol-cancel.png")
                _Fila.Cells("Btn_EstadoEnv").Value = _ListaImagenes.Images.Item("symbol-cancel.png")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Function Fx_Generar_Informe() As DataSet

        Me.Cursor = Cursors.WaitCursor

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Dim _Filtro_Idmaeedo As String = String.Empty
        Dim _Filtro_Documentos As String = String.Empty
        Dim _Filtro_Responsables As String = String.Empty
        Dim _Filtro_Sucursales As String = String.Empty
        Dim _Filtro_Entidades As String = String.Empty
        Dim _Filtro_Estado As String = String.Empty

        If CBool(_Cl_MFElec.Idmaeedo) Then
            _Filtro_Idmaeedo = "And IDMAEEDO = " & _Cl_MFElec.Idmaeedo & vbCrLf
        Else
            If _Cl_MFElec.Documentos_Todos Then
                _Filtro_Documentos = "And TIDO In ('BLV','FCL','FCT','FCV','FDE','FDV','FDX','FEV','FVX','FXV','FYV','GDD','GDP','GDV','GTI','NCV','NCX','NEV')"
            Else
                _Filtro_Documentos = Generar_Filtro_IN(_Cl_MFElec.Tbl_Documentos, "", "Codigo", False, False, "'")
                _Filtro_Documentos = "And TIDO In " & _Filtro_Documentos & vbCrLf
            End If

            If Not _Cl_MFElec.Responsables_Todos Then
                _Filtro_Responsables = Generar_Filtro_IN(_Cl_MFElec.Tbl_Responsables, "", "Codigo", False, False, "'")
                _Filtro_Responsables = "And KOFUDO In " & _Filtro_Responsables & vbCrLf
            End If

            If Not _Cl_MFElec.Sucursales_Todas Then
                _Filtro_Sucursales = Generar_Filtro_IN(_Cl_MFElec.Tbl_Sucursales, "", "Codigo", False, False, "'")
                _Filtro_Sucursales = "And SUDO In " & _Filtro_Sucursales & vbCrLf
            End If

            If Not _Cl_MFElec.Entidades_Todas Then
                _Filtro_Entidades = Generar_Filtro_IN(_Cl_MFElec.Tbl_Entidades, "", "Codigo", False, False, "'")
                _Filtro_Entidades = "And ENDO In " & _Filtro_Entidades & vbCrLf
            End If

            If _Cl_MFElec.Estado_Aceptado Then
                _Filtro_Estado = "And IDMAEEDO In (Select Distinct Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid" & vbCrLf &
                                 "Where Aceptado = 1 or (Informado = 1 and Reparo = 1))"
            End If

            If _Cl_MFElec.Estado_AceptadoReparos Then
                _Filtro_Estado = "And IDMAEEDO In (Select Distinct Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid" & vbCrLf &
                                 "Where Informado = 1 And Reparo = 1 And Aceptado = 0)"
            End If

            If _Cl_MFElec.Estado_Rechazado Then
                _Filtro_Estado = "And IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid" & vbCrLf &
                                 "Where Rechazado = 1 And Idmaeedo Not In (Select Idmaeedo" & vbCrLf &
                                 "From " & _Global_BaseBk & "Zw_DTE_Trackid" & vbCrLf &
                                 "Where Aceptado = 1 or (Informado = 1 and Reparo = 1)))" & vbCrLf
            End If

            If _Cl_MFElec.Estado_SinFirmar Then
                _Filtro_Estado = "And (IDMAEEDO Not In (Select Distinct Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid) " &
                                 "Or IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Documentos))" & vbCrLf
            End If

            If _Cl_MFElec.Estado_ErrorEnvioCorreo Then
                _Filtro_Estado = "And IDMAEEDO In (Select Distinct Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid" & Space(1) &
                                 "Where (Aceptado = 1 OR (Informado = 1 And Reparo = 1 And Aceptado = 0)) And" & Space(1) &
                                 "(ErrorMailToDiablito = 1 Or MailEnviado = 0 Or ErrorEnviarMail = 1))"
            End If

        End If


        Dim _Filtros As String = _Filtro_Idmaeedo & _Filtro_Entidades & _Filtro_Documentos & _Filtro_Responsables & _Filtro_Sucursales & _Filtro_Estado

        Consulta_sql = My.Resources.Recursos_Dte_Hefesto.SQLQuery_Estado_de_avance_de_envios_de_DTE_vs_Trackid
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Filtros#", _Filtros)

        If CBool(_Cl_MFElec.Idmaeedo) Then
            Consulta_sql = Replace(Consulta_sql, "And FEEMDO Between '#Fecha_Desde#' And '#Fecha_Hasta#'", "")
        End If

        Consulta_sql = Replace(Consulta_sql, "#Fecha_Desde#", Format(_Cl_MFElec.Fecha_Desde, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Hasta#", Format(_Cl_MFElec.Fecha_Hasta, "yyyyMMdd"))

        Consulta_sql = Replace(Consulta_sql, "#AmbienteCertificacion#", _AmbienteCertificacion)

        Dim _SoloFirmadosPorBakapp = String.Empty

        'If Chk_SoloFirmadosXBakapp.Checked Then
        '    _SoloFirmadosPorBakapp = "And Edo.IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Firmar)"
        'End If

        Consulta_sql = Replace(Consulta_sql, "#SoloFirmadosPorBakapp#", _SoloFirmadosPorBakapp)

        Dim Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Me.Cursor = Cursors.Default
        Fm_Espera.Close()
        Fm_Espera.Dispose()

        Return Ds

    End Function

    Private Sub Btn_Actualizar_Datos_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Datos.Click
        'Sb_Actualizar_Datos_SII()
    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Call Grilla_CellDoubleClick(Nothing, Nothing)
                    'ShowContextMenu(Menu_Contextual)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Firmar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Firmar_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Sb_Actualizar_Datos_Registro(_Fila)

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Tido_Nudo As String = _Fila.Cells("Tido_Nudo").Value
        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Trackid As String = _Fila.Cells("Trackid").Value
        Dim _DocFirmado As Boolean = _Fila.Cells("DocFirmado").Value
        Dim _AceptadoSII As Boolean = _Fila.Cells("AceptadoSII").Value
        Dim _InformadoSII As Boolean = _Fila.Cells("InformadoSII").Value
        Dim _RechazadoSII As Boolean = _Fila.Cells("RechazadoSII").Value
        Dim _ReparoSII As Boolean = _Fila.Cells("ReparoSII").Value
        Dim _ErrorEnvioDTE As Boolean = _Fila.Cells("ErrorEnvioDTE").Value

        If _AceptadoSII Or _ReparoSII Then
            MessageBoxEx.Show(Me, "Este documento ya esta aceptado por el SII" & vbCrLf &
                              "No se puede volver a tratar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _DocFirmado And Not _ErrorEnvioDTE Then
            MessageBoxEx.Show(Me, "Este documento ya esta firmado" & vbCrLf &
                              "Debe enviarlo al SII con la opción [Re-enviar documento al SII]", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Icono As Image = My.Resources.Recursos_DTE.script_edit

        CircularProgressItem1.IsRunning = True
        CircularProgressItem1.Visible = True
        Grilla.Enabled = False
        Bar1.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Try

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Firmar Where Idmaeedo = " & _Idmaeedo & " Order By Id Desc"
            Dim _Row_Firmar As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Firmar) Then

                If _Row_Firmar.Item("Firmar") Then
                    MessageBoxEx.Show(Me, "El documento ya esta a la espera de ser firmado por el DTEMonitor" & vbCrLf &
                                      "Informe de esta situación al administrador del sistema para que revise que el DTEMonitor este corriendo en algún equipo",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else

                    If CBool(_Row_Firmar.Item("Id_Dte")) Then
                        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_Documentos", "Id_Dte = " & _Row_Firmar.Item("Id_Dte")))

                        If Not _Reg Then
                            _Row_Firmar.Item("Log_Error") = "Error"
                        End If
                    End If

                    If Not _Row_Firmar.Item("Firmar") Then
                        _ErrorEnvioDTE = True
                    End If

                    If Not String.IsNullOrEmpty(_Row_Firmar.Item("Log_Error").ToString.Trim) Then
                        _Fila.Cells("ErrorEnvioDTE").Value = True
                        _Fila.Cells("Glosa").Value = _Row_Firmar.Item("Log_Error").ToString.Trim
                        _ErrorEnvioDTE = True
                    End If

                    If Not _ErrorEnvioDTE Then

                        MessageBoxEx.Show(Me, "Este documento ya esta firmado" & vbCrLf &
                                      "Debe enviarlo al SII con la opción [Re-enviar documento al SII]", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                        _Id_Dte = _Row_Firmar.Item("Id_Dte")

                        _Fila.Cells("Id_Dte").Value = _Id_Dte
                        _Fila.Cells("DocFirmado").Value = Not _Row_Firmar.Item("Id_Dte")
                        If _Fila.Cells("DocFirmado").Value Then
                            _Fila.Cells("Glosa").Value = "Firmado Ok"
                        End If

                    End If

                End If

                If Not _ErrorEnvioDTE Then
                    Return
                End If

            End If

            Dim _Old_Id_Dte = _Id_Dte

            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

            _Id_Dte = _Class_DTE.Fx_FirmarXHefesto()

            If CBool(_Id_Dte) Then

                Beep()
                _Fila.Cells("Glosa").Value = "Firmado Ok"
                _Fila.Cells("Id_Dte").Value = _Id_Dte
                _Fila.Cells("DocFirmado").Value = True
                'Sb_Actualizar_Datos_Registro(_Fila)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Eliminado = 1 Where Id_Dte = " & _Old_Id_Dte
                _Sql.Ej_consulta_IDU(Consulta_sql)

            Else
                MessageBoxEx.Show(Me, "El documento no fue firmado por el servidor DTEMonitor" & vbCrLf &
                                  "Informe de esta situación al administrador del sistema para que revise que el DTEMonitor este corriendo en algún equipo",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
        Finally
            CircularProgressItem1.IsRunning = False
            CircularProgressItem1.Visible = False
            Grilla.Enabled = True
            Bar1.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Btn_Reenviar_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Reenviar_Correo.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Id_Trackid As String = _Fila.Cells("Id_Trackid").Value
        Dim _Trackid As String = _Fila.Cells("Trackid").Value
        Dim _DocFirmado As Boolean = _Fila.Cells("DocFirmado").Value
        Dim _AceptadoSII As Boolean = _Fila.Cells("AceptadoSII").Value
        Dim _InformadoSII As Boolean = _Fila.Cells("InformadoSII").Value
        Dim _RechazadoSII As Boolean = _Fila.Cells("RechazadoSII").Value
        Dim _ReparoSII As Boolean = _Fila.Cells("ReparoSII").Value
        Dim _EnviadoSII As Boolean = _Fila.Cells("EnviadoSII").Value

        Dim _Msg As String = String.Empty

        If Not _DocFirmado Then
            _Msg = "-Falta firmar el documento" & vbCrLf
        End If

        If Not _EnviadoSII Then
            _Msg += "-No ha sido enviado al SII" & vbCrLf
        End If

        If String.IsNullOrEmpty(_Trackid) Or
            (Not CBool(_AceptadoSII) And Not CBool(_ReparoSII)) Then
            _Msg += "-Aun no ha sido autorizado por el SII" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(_Msg) Then
            MessageBoxEx.Show(Me, "No es posible reenviar el correo ya que el documento tiene algunos problemas:" & vbCrLf & vbCrLf & _Msg,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

        If CBool(_AceptadoSII) Then

            Dim _Koen = _Class_DTE.Maeedo.Rows(0).Item("ENDO")
            Dim _Suen = _Class_DTE.Maeedo.Rows(0).Item("SUENDO")

            Dim _Para = _Class_DTE.Maeen.Rows(0).Item("EMAIL").ToString.Trim
            Dim _Para2 = _Class_DTE.Maeen.Rows(0).Item("EMAILCOMER").ToString.Trim

            Dim _EnvioCorreo As String = _Class_DTE.Fx_Enviar_Notificacion_Correo_Al_Diablito(_Idmaeedo, _Para, "", _Id_Trackid)

            _Fila.Cells("MailToDiablito").Value = False
            _Fila.Cells("ErrorMailToDiablito").Value = False
            _Fila.Cells("MailEnviado").Value = False
            _Fila.Cells("EnviarMail").Value = False

            If String.IsNullOrEmpty(_EnvioCorreo) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 1,ErrorMailToDiablito = 0,MailEnviado = 0,ErrorEnviarMail = 0 Where Id = " & _Id_Trackid
                _Sql.Ej_consulta_IDU(Consulta_sql)
                _Fila.Cells("MailToDiablito").Value = True
                MessageBoxEx.Show(Me, "Correo reenviado al diablito de correos...", "Reenviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If String.IsNullOrEmpty(_Para) Then
                    _EnvioCorreo += vbCrLf & "Revise la ficha del cliente"
                End If
                _Fila.Cells("ErrorMailToDiablito").Value = True
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 0,ErrorMailToDiablito = 1,MailEnviado = 0 Where Id = " & _Id_Trackid
                _Sql.Ej_consulta_IDU(Consulta_sql)
                MessageBoxEx.Show(Me, _EnvioCorreo, "Problema al enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub Btn_Reenviar_SII_Click(sender As Object, e As EventArgs) Handles Btn_Reenviar_SII.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Sb_Actualizar_Datos_Registro(_Fila)

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Id_Trackid As Integer = _Fila.Cells("Id_Trackid").Value
        Dim _Tido_Nudo As String = _Fila.Cells("Tido_Nudo").Value
        Dim _Trackid As String = _Fila.Cells("Trackid").Value
        Dim _DocFirmado As Boolean = _Fila.Cells("DocFirmado").Value
        Dim _AceptadoSII As Boolean = _Fila.Cells("AceptadoSII").Value
        Dim _InformadoSII As Boolean = _Fila.Cells("InformadoSII").Value
        Dim _RechazadoSII As Boolean = _Fila.Cells("RechazadoSII").Value
        Dim _ReparoSII As Boolean = _Fila.Cells("ReparoSII").Value
        Dim _Estado As String = _Fila.Cells("Estado").Value
        Dim _Glosa As String = _Fila.Cells("Glosa").Value

        Dim _Procesar As Boolean = _Fila.Cells("Procesar").Value
        Dim _Procesado As Boolean = _Fila.Cells("Procesado").Value

        Dim _Msg2 As String

        If _Estado = "RPT" Or _Estado = "RFR" Or _Estado = "RCT" Or _Estado = "RCH" Or _Estado = "007" Or _Estado = "001" Or _Estado = "107" Or _Estado = "REC" Or
                       (_Id_Dte <> 0 And Not _DocFirmado) Then

            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
            If CBool(_Class_DTE.Fx_FirmarXHefesto()) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Eliminado = 1 Where Id_Dte = " & _Id_Dte
                _Sql.Ej_consulta_IDU(Consulta_sql)

                MessageBoxEx.Show(Me, "Documento firmado correctamente, espere la gestión del DTEMonitor", "Información Bakapp", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Ds = Fx_Generar_Informe()
                Sb_Actualizar_Grilla()
                BuscarDatoEnGrilla(_Tido_Nudo, "Tido_Nudo", Grilla)
                If Not String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
                    _Dv.RowFilter = String.Format("Tido_Nudo+NOKOEN+FEEMDO+Trackid Like '%{0}%'", Txt_Descripcion.Text.Trim)
                End If

                Return
            End If

        End If

        If _Estado = "EPR" Or _Estado = "RPR" Or _Estado = "RLV" Then
            MessageBoxEx.Show(Me, "Este documento ya fue enviado al SII" & vbCrLf &
                              "Respueta SII:" & vbCrLf &
                              "Estado: " & _Estado & "-" & _Glosa & _Msg2, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If _Estado = "EPR" Or _Estado = "-11" Then

            _RechazadoSII = False

            If _Estado = "-11" Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Intentos = 1 Where Id = " & _Id_Trackid
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Documentos Where Id_Dte = " & _Id_Dte
        Dim _RowDTE As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_RowDTE) Then
            MessageBoxEx.Show(Me, "Documento no ha sido firmado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Procesar = _RowDTE.Item("Procesar")
        _Procesado = _RowDTE.Item("Procesado")

        If _Procesar Then
            MessageBoxEx.Show(Me, "Este documento en breve sera procesado por el DTEMonitor" & vbCrLf &
                              "Debe esperar a que termine su ejecución", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If _Procesado Then
            MessageBoxEx.Show(Me, "Este documento ya fue procesado por el DTEMonitor" & vbCrLf &
                                  "En breve tendremos la respuesta desde el SII", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1,Procesado = 0 Where Id_Dte = " & _Id_Dte
        _Sql.Ej_consulta_IDU(Consulta_sql)

        _Fila.Cells("Procesar").Value = True
        _Fila.Cells("Procesado").Value = False

        Sb_Actualizar_Datos_Registro(_Fila)

        MessageBoxEx.Show(Me, "Documento a la espera de ser procesado por el DTEMonitor...",
                          "Renviar DTE al SII", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Sb_Actualizar_Datos_Registro(_Fila)

        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Id_Trackid = _Fila.Cells("Id_Trackid").Value
        Dim _ErrorEnvioDTE As Boolean = _Fila.Cells("ErrorEnvioDTE").Value
        Dim _Esdo = _Fila.Cells("Esdo").Value
        Dim _Tido_Nudo = _Fila.Cells("Tido_Nudo").Value

        Lbl_LeyendaDoc.Text = "Id_Dte: " & _Id_Dte & ", Id_Trackid: " & _Id_Trackid

        Btn_Firmar_Documento.Visible = Not (CBool(_Id_Dte))
        Btn_Reenviar_SII.Visible = CBool(_Id_Dte)
        Btn_ReConsultar_Trackid.Visible = CBool(_Id_Dte)
        Btn_Reenviar_Correo.Visible = CBool(_Id_Dte)
        Btn_Mnu_Exportar_XML_Hefesto.Visible = CBool(_Id_Dte)

        If _ErrorEnvioDTE Then
            Btn_Firmar_Documento.Visible = True
            Btn_Reenviar_SII.Visible = False
            Btn_ReConsultar_Trackid.Visible = False
            Btn_Reenviar_Correo.Visible = False
            Btn_Mnu_Exportar_XML_Hefesto.Visible = False
        End If

        If Btn_Firmar_Documento.Visible Then
            If _Esdo = "N" Then Btn_Firmar_Documento.Enabled = False
        End If

        Btn_CesionarDTE.Visible = _Tido_Nudo.ToString.Contains("FCV")
        Lbl_AEC.Visible = _Tido_Nudo.ToString.Contains("FCV")

        ShowContextMenu(Menu_Contextual)

    End Sub

    Private Sub Actualizar_Click(sender As Object, e As EventArgs) Handles Actualizar.Click

        Dim _Fila As DataGridViewRow
        Dim _Tido_Nudo As String

        Try
            _Fila = Grilla.Rows(Grilla.CurrentRow.Index)
            _Tido_Nudo = _Fila.Cells("Tido_Nudo").Value
        Catch ex As Exception
            _Tido_Nudo = String.Empty
        End Try

        _Ds = Fx_Generar_Informe()
        Sb_Actualizar_Grilla()

        If Not String.IsNullOrEmpty(_Tido_Nudo) Then
            BuscarDatoEnGrilla(_Tido_Nudo, "Tido_Nudo", Grilla)
        End If

        If Not String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            _Dv.RowFilter = String.Format("Tido_Nudo+NOKOEN+FEEMDO+Trackid Like '%{0}%'", Txt_Descripcion.Text.Trim)
        End If

    End Sub

    'Function Fx_Consultar_El_Trackid(_Id_Dte As Integer,
    '                                 _Idmaeedo As Integer,
    '                                 _Trackid As String,
    '                                 ByRef _Respuesta As String) As DataRow

    '    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

    '    If _Class_DTE.Fx_Consultar_Trackid(_Trackid, _Respuesta) Then

    '        Dim _Estado = String.Empty
    '        Dim _Glosa = String.Empty

    '        Dim _Aceptados As Integer
    '        Dim _Informados As Integer
    '        Dim _Rechazados As Integer
    '        Dim _Reparos As Integer

    '        _Class_DTE.Sb_Revisar_Respuesta_Trackid(_Respuesta, _Estado, _Glosa, _Aceptados, _Informados, _Rechazados, _Reparos,
    '                                                _VolverProcesar:=False)

    '        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set" & vbCrLf &
    '                       "Informado = " & _Informados &
    '                       ",Aceptado = " & _Aceptados &
    '                       ",Rechazado = " & _Rechazados &
    '                       ",Reparo = " & _Reparos &
    '                       ",Estado = '" & _Estado & "'" &
    '                       ",Glosa = '" & _Glosa & "'" &
    '                       ",Respuesta = '" & _Respuesta & "'" & vbCrLf &
    '                       "Where Trackid = '" & _Trackid & "'"
    '        _Sql.Ej_consulta_IDU(Consulta_sql)

    '    End If

    '    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Trackid = '" & _Trackid & "'"
    '    Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '    Return _Row

    'End Function

    Private Sub Btn_ReConsultar_Trackid_Click(sender As Object, e As EventArgs) Handles Btn_ReConsultar_Trackid.Click

        Me.Cursor = Cursors.WaitCursor

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Sb_Actualizar_Datos_Registro(_Fila)

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Id_Trackid As String = _Fila.Cells("Id_Trackid").Value
        Dim _Trackid As String = _Fila.Cells("Trackid").Value
        Dim _DocFirmado As Boolean = _Fila.Cells("DocFirmado").Value
        Dim _AceptadoSII As Boolean = _Fila.Cells("AceptadoSII").Value
        Dim _InformadoSII As Boolean = _Fila.Cells("InformadoSII").Value
        Dim _RechazadoSII As Boolean = _Fila.Cells("RechazadoSII").Value
        Dim _ReparoSII As Boolean = _Fila.Cells("ReparoSII").Value
        Dim _Estado As String = _Fila.Cells("Estado").Value
        Dim _Glosa As String = _Fila.Cells("Glosa").Value

        'Dim _Msg2 As String

        Try
            Me.Enabled = False

            If String.IsNullOrEmpty(_Trackid) Then
                MessageBoxEx.Show(Me, "Este registro aun no tiene Trackid para consultar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            'Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Trackid = '" & _Trackid & "' And Id_Dte = " & _Id_Dte
            'Dim _Row_Trackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not CBool(_Id_Trackid) Then ' IsNothing(_Row_Trackid) Then
                MessageBoxEx.Show(Me, "Error, no se encontro el registro en la tabla Zw_DTE_Trackid", "Validación")
                Return
            End If

            If String.IsNullOrEmpty(_Estado) Then
                _AceptadoSII = False
                _InformadoSII = False
                _RechazadoSII = False
            End If

            If _AceptadoSII Or (_InformadoSII Or _RechazadoSII) Then
                If MessageBoxEx.Show(Me, "Este documento ya fue enviado al SII" & vbCrLf &
                                      "Respueta SII:" & vbCrLf &
                                      "Estado: " & _Estado & "-" & _Glosa & vbCrLf & vbCrLf &
                                      "¿Desea volver a consultar igual el Trackid?", "Información",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                    Return
                End If
            End If

            If Not _AceptadoSII Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set " &
                               "Procesar = 1,Aceptado = 0,Rechazado = 0,Reparo = 0,Procesado = 0,Estado = '',Intentos = 0" & vbCrLf &
                               "Where Trackid = '" & _Trackid & "' And Id_Dte = " & _Id_Dte
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Sb_Actualizar_Datos_Registro(_Fila)

                    MessageBoxEx.Show(Me, "El documento fue nuevamente enviado a la consulta de Trackid" & vbCrLf &
                                      "Debera eseprar un momento para que el servidor DTEMonitor obtenga la llamada",
                                      "Consultar Trackid", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Grilla_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla.DataError

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Leyenda As String

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Chk_DocFirmado.Checked = _Fila.Cells("DocFirmado").Value
            Chk_AceptadoSII.Checked = _Fila.Cells("AceptadoSII").Value
            Chk_EnviadoSII.Checked = _Fila.Cells("EnviadoSII").Value
            Chk_AceptadoReparos.Checked = (_Fila.Cells("InformadoSII").Value And _Fila.Cells("ReparoSII").Value)
            Chk_RechazadoSII.Checked = _Fila.Cells("RechazadoSII").Value

            _Leyenda = "Estado: " & _Fila.Cells("Estado").Value.ToString.Trim & " - " & _Fila.Cells("Glosa").Value.ToString.Trim & ". " & _Fila.Cells("LeyendaEmail").Value.ToString.Trim

            If _Fila.Cells("ErrorEnvioDTE").Value Then
                _Leyenda += _Fila.Cells("Respuesta").Value
            End If

        Catch ex As Exception
            _Leyenda = String.Empty
        End Try

        Txt_Leyenda.Text = _Leyenda

    End Sub


    Sub Sb_Actualizar_Datos_Registro(ByRef _Fila As DataGridViewRow)

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Id_Trackid As String = _Fila.Cells("Id_Trackid").Value
        Dim _Trackid As String = _Fila.Cells("Trackid").Value
        Dim _DocFirmado As Boolean = _Fila.Cells("DocFirmado").Value
        Dim _AceptadoSII As Boolean = _Fila.Cells("AceptadoSII").Value
        Dim _InformadoSII As Boolean = _Fila.Cells("InformadoSII").Value
        Dim _RechazadoSII As Boolean = _Fila.Cells("RechazadoSII").Value
        Dim _ReparoSII As Boolean = _Fila.Cells("ReparoSII").Value
        Dim _Estado As String = _Fila.Cells("Estado").Value
        Dim _Glosa As String = _Fila.Cells("Glosa").Value

        If Not CBool(_Id_Dte) Then
            Return
        End If

        Dim _AmbienteCertificacion As Integer = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        Dim _Filtro = "And IDMAEEDO = " & _Idmaeedo

        Consulta_sql = "Select  Doc.Id_Dte,
                                Isnull(Tid.Id,'') As 'Id_Trackid',
                                Isnull(Tid.Trackid,'') As 'Trackid',
                                Cast((Case When Isnull(Doc.Firma,'') <> '' Then 1 Else 0 End) As Bit) As 'DocFirmado',
		                        Cast((Case When Isnull(Tid.Aceptado,0) = 1 
                                                Or Isnull(Tid.Informado,0) = 1 
                                                    Or Isnull(Tid.Rechazado,0) = 1 
                                                        Or Isnull(Tid.Reparo,0) = 1 Then 1 Else 0 End) As Bit) As 'EnviadoSII',
		                        Cast(Isnull(Tid.Aceptado,0) As Bit) As 'AceptadoSII',
		                        Cast(Isnull(Tid.Informado,0) As Bit) As 'InformadoSII',
		                        Cast(Isnull(Tid.Rechazado,0) As Bit) As 'RechazadoSII',
		                        Cast(Isnull(Tid.Reparo,0) As Bit) As 'ReparoSII',
		                        Cast(Isnull(Tid.MailEnviado,0) As Bit) As 'MailEnviado',
                                Cast(Isnull(Tid.MailToDiablito,0) As Bit) As 'MailToDiablito',
		                        Cast(Isnull(Tid.ErrorMailToDiablito,0) As Bit) As 'ErrorMailToDiablito',
		                        Cast(Isnull(Tid.ErrorEnviarMail,0) As Bit) As 'ErrorEnviarMail',
		                        Cast(Isnull(Tid.EnviarMail,0) As Bit) As 'EnviarMail',        
		                        Isnull(Tid.Estado,'') As 'Estado',
		                        Isnull(Tid.Glosa,'') As 'Glosa',
		                        Isnull(Doc.Procesar,'') As 'Procesar',
		                        Isnull(Doc.Procesado,'') As 'Procesado',								   
                                Case When Doc.ErrorEnvioDTE = 0 Then Isnull(Tid.Respuesta,'') Else Isnull(Doc.Respuesta,'') End As 'Respuesta',
                                Isnull(Correo.Destinatarios,'') As 'Destinatarios',
                                Isnull(Doc.ErrorEnvioDTE,0) As 'ErrorEnvioDTE'
                        From " & _Global_BaseBk & "Zw_DTE_Documentos Doc 
                         Left Join " & _Global_BaseBk & "Zw_DTE_Trackid Tid On Tid.Id_Dte = Doc.Id_Dte And Tid.AmbienteCertificacion = 0
                           Left Join " & _Global_BaseBk & "Zw_DTE_NotifxCorreo Correo On Correo.Id_Dte = Doc.Id_Dte And Correo.AmbienteCertificacion = 0
                        Where Doc.Id_Dte = " & _Id_Dte & " And Doc.AmbienteCertificacion = 0"

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Return
        End If

        If _Row.Item("DocFirmado") And Not CBool(_Row.Item("Id_Trackid")) Then
            _Row.Item("Glosa") = "Firmado Ok"
        End If

        If _Row.Item("DocFirmado") And String.IsNullOrEmpty(_Row.Item("Estado")) And CBool(_Row.Item("Id_Trackid")) Then
            _Row.Item("Glosa") = "A la espera de consultar Trackid en SII"
        End If

        If _Row.Item("ErrorEnvioDTE") Then
            _Row.Item("Glosa") = "Error al enviar DTE al SII"
        End If

        _Fila.Cells("Id_Dte").Value = _Row.Item("Id_Dte")
        _Fila.Cells("Id_Trackid").Value = _Row.Item("Id_Trackid")
        _Fila.Cells("Trackid").Value = _Row.Item("Trackid")
        _Fila.Cells("DocFirmado").Value = _Row.Item("DocFirmado")
        _Fila.Cells("AceptadoSII").Value = _Row.Item("AceptadoSII")
        _Fila.Cells("InformadoSII").Value = _Row.Item("InformadoSII")
        _Fila.Cells("RechazadoSII").Value = _Row.Item("RechazadoSII")
        _Fila.Cells("ReparoSII").Value = _Row.Item("ReparoSII")
        _Fila.Cells("Estado").Value = _Row.Item("Estado")
        _Fila.Cells("Glosa").Value = _Row.Item("Glosa")

        Dim _Destinatarios As String = _Row.Item("Destinatarios")

        If _Fila.Cells("EnviarMail").Value Then
            _Fila.Cells("LeyendaEmail").Value = "A la espera de envia el correo."
        End If

        If _Fila.Cells("MailToDiablito").Value Then
            _Fila.Cells("LeyendaEmail").Value = "El correo esta en la bandeja de salida del diablito de correos."
        End If

        If _Fila.Cells("ErrorMailToDiablito").Value And Not String.IsNullOrEmpty("Destinatarios") Then
            _Fila.Cells("LeyendaEmail").Value = "Error, el correo no pudo ser enviado al diablito de correos. Revise la ficha del cliente"
        End If

        If _Fila.Cells("ErrorMailToDiablito").Value And String.IsNullOrEmpty("Destinatarios") Then
            _Fila.Cells("LeyendaEmail").Value = "Error, el correo no pudo ser enviado al diablito de correos. No existe destinatario, revise la ficha del cliente"
        End If

        If _Fila.Cells("MailEnviado").Value Then
            _Fila.Cells("LeyendaEmail").Value = "Correo enviado correctamente."
        End If

        If _Fila.Cells("ErrorEnviarMail").Value And Not String.IsNullOrEmpty("Destinatarios") Then
            _Fila.Cells("LeyendaEmail").Value = "Error, correo no enviado al cliente. avise al administrador del sistema"
        End If

        If _Fila.Cells("ErrorEnviarMail").Value And String.IsNullOrEmpty("Destinatarios") Then
            _Fila.Cells("LeyendaEmail").Value = "Error, correo no enviado al cliente. Falta correo de destinatario, revise la ficha del cliente"
        End If

        Dim _Leyenda = "Estado: " & _Fila.Cells("Estado").Value.ToString.Trim & " - " & _Fila.Cells("Glosa").Value.ToString.Trim & ". " & _Fila.Cells("LeyendaEmail").Value.ToString.Trim

        Txt_Leyenda.Text = _Leyenda

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown

        If e.KeyValue = Keys.Enter Or String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            _Dv.RowFilter = String.Format("Tido_Nudo+NOKOEN+FEEMDO+Trackid+Glosa Like '%{0}%'", Txt_Descripcion.Text.Trim)
        End If

    End Sub

    Private Sub Btn_CesionarDTE_Click(sender As Object, e As EventArgs) Handles Btn_CesionarDTE.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Idmaeedo As Integer = _Fila.Cells("Idmaeedo").Value
        Dim _Id_Aec As Integer

        Consulta_sql = "Select Top 1 Tid.Id As Id_Trackid,Tid.Id_Dte,Isnull(Aec.Id_Aec,0) As Id_Aec" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Trackid Tid" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_DTE_Aec Aec On Aec.Idmaeedo = Tid.Idmaeedo" & vbCrLf &
                       "Where Doc.Idmaeedo = " & _Idmaeedo & " And Tid.Id_Dte <> 0 And Estado In ('EPR','RPR','RLV') "
        Dim _Row_TidDoc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_TidDoc) Then
            '_Errores.Add("No se encontro el archivo XML en la tabla [Zw_DTE_Documentos]")
            Return
        End If

        If CBool(_Row_TidDoc.Item("Id_Aec")) Then
            MessageBoxEx.Show(Me, "Ya existe una solicitud AEC para este documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Aec_CesionDTE(_Id_Dte, _Idmaeedo)
        Fm.ShowDialog(Me)
        _Id_Aec = Fm.Id_Aec
        Fm.Dispose()

        If CBool(_Id_Aec) Then
            MessageBoxEx.Show(Me, "Archivo sera enviado por el DTEMonitor a la brevedad", "Archivo Electrónico de Cesión (AEC)",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_Mnu_Exportar_XML_Hefesto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Exportar_XML_Hefesto.Click

        If Not Fx_Tiene_Permiso(Me, "Doc00025") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Id_Dte As Integer = _Fila.Cells("Id_Dte").Value
        Dim _Id_Trackid As String = _Fila.Cells("Id_Trackid").Value
        Dim _Trackid As String = _Fila.Cells("Trackid").Value
        Dim _DocFirmado As Boolean = _Fila.Cells("DocFirmado").Value
        Dim _AceptadoSII As Boolean = _Fila.Cells("AceptadoSII").Value
        Dim _InformadoSII As Boolean = _Fila.Cells("InformadoSII").Value
        Dim _RechazadoSII As Boolean = _Fila.Cells("RechazadoSII").Value
        Dim _ReparoSII As Boolean = _Fila.Cells("ReparoSII").Value
        Dim _EnviadoSII As Boolean = _Fila.Cells("EnviadoSII").Value

        Dim _Msg As String = String.Empty

        If Not _DocFirmado Then
            _Msg = "-Falta firmar el documento" & vbCrLf
        End If

        If Not _EnviadoSII Then
            _Msg += "-No ha sido enviado al SII" & vbCrLf
        End If

        If String.IsNullOrEmpty(_Trackid) Or
            (Not CBool(_AceptadoSII) And Not CBool(_ReparoSII)) Then
            _Msg += "-Aun no ha sido autorizado por el SII" & vbCrLf
        End If

        If CBool(_AceptadoSII) Then

            Dim SaveFileDialog1 As New SaveFileDialog
            Dim _CaratulaXml As String

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Documentos Where Id_Dte = " & _Id_Dte
            Dim _Row_Zw_DTE_Documentos As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Tido = _Row_Zw_DTE_Documentos.Item("Tido")
            Dim _Nudo = _Row_Zw_DTE_Documentos.Item("Nudo")

            _CaratulaXml = _Row_Zw_DTE_Documentos.Item("CaratulaXml")

            Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\Temp"

            If Not Directory.Exists(_Directorio) Then
                System.IO.Directory.CreateDirectory(_Directorio)
            End If

            If Not String.IsNullOrEmpty(_CaratulaXml) Then

                SaveFileDialog1.FileName = _Tido & "-" & _Nudo & "_DTE"

                SaveFileDialog1.Filter = "XML Files (*.xml)|*.xml"
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                    _Directorio = SaveFileDialog1.FileName

                    Dim oSW As New System.IO.StreamWriter(_Directorio)

                    oSW.WriteLine(_CaratulaXml)
                    oSW.Close()

                    '' Crea un objeto XmlDocument para cargar el archivo XML
                    Dim xmlDoc As New XmlDocument()

                    xmlDoc.Load(_Directorio)

                    Dim settings As New XmlWriterSettings()
                    settings.Indent = True  ' Indentación para el formato
                    settings.IndentChars = "	"
                    settings.NewLineChars = vbCrLf  ' Separadores de líneas
                    settings.Encoding = Encoding.GetEncoding("ISO-8859-1")


                    Using writer As XmlWriter = XmlWriter.Create(_Directorio, settings)
                        'Replace(writer.WriteString, "ISO-8859-1", "ISO-8859-1")
                        xmlDoc.Save(writer)
                    End Using

                    'Transforme "iso-8859-1" a "ISO-8859-1"
                    Dim contenido As String = File.ReadAllText(_Directorio, Encoding.GetEncoding("ISO-8859-1"))
                    contenido = contenido.Replace("iso-8859-1", "ISO-8859-1")
                    contenido = contenido.Replace(""" />", """/>")

                    File.WriteAllText(_Directorio, contenido, Encoding.GetEncoding("ISO-8859-1"))

                    MessageBoxEx.Show(Me, "Archivo guardado correctamente" & vbCrLf &
                                             "Ruta: " & _Directorio, "Exportar a Xml", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Process.Start("explorer.exe", _Directorio)

                End If

            Else
                MessageBoxEx.Show(Me, "No exiten datos que exportar",
                                      "Exportar a .csv", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub
End Class
