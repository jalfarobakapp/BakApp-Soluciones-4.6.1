'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Inf_Vencimientos_Correos_Proveedores_Pagos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id_Correo As Integer

    Dim _TblInf As New DataTable
    Dim _TblEnt As New DataTable
    Dim _Correo_Problema As Integer
    Dim _Cerrar As Boolean
    Dim _Correo_Manual As Boolean

    Public Sub New(ByVal Id_Correo As Integer,
                   ByRef TblInf As DataTable,
                   ByRef TblEnt As DataTable,
                   Optional ByVal Correo_Manual As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Id_Correo = Id_Correo
        _TblInf = TblInf
        _TblEnt = TblEnt
        _Correo_Manual = Correo_Manual

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Lbl_Envio_correo.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Inf_Vencimientos_Correos_Proveedores_Pagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Grilla_Detalle.DataSource = _TblEnt
        Sb_Actualizar_Grilla()

        AddHandler Grilla_Detalle.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Chk_Marcar_todo.CheckedChanged, AddressOf Sb_Chk_Marcar_todo_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        _Correo_Problema = 0

        _TblEnt.Columns("Chk").ReadOnly = False

        With Grilla_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle)

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False

            .Columns("KOEN").Width = 80
            .Columns("KOEN").HeaderText = "Código"
            .Columns("KOEN").Visible = True
            '.Columns("KOEN").ReadOnly = True

            .Columns("NOKOEN").Width = 250
            .Columns("NOKOEN").HeaderText = "Entidad"
            .Columns("NOKOEN").Visible = True
            '.Columns("NOKOEN").ReadOnly = True

            .Columns("EMAILCOMER").Width = 240
            .Columns("EMAILCOMER").HeaderText = "Email (Secundario, Comercial)"
            .Columns("EMAILCOMER").Visible = True
            '.Columns("EMAILCOMER").ReadOnly = True

        End With

        '

        'im _Problemas = 0
        Sb_Revisar_Grilla()



    End Sub

    Sub Sb_Revisar_Grilla()

        _Correo_Problema = 0

        For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows

            Dim _Correo = Trim(_Fila.Cells("EMAILCOMER").Value)
            Dim _Correo_Valido As Boolean = Fx_Validar_Email(_Correo)
            Dim _Chk As Boolean = _Fila.Cells("Chk").Value

            If Global_Thema = Enum_Themas.Oscuro Then
                If String.IsNullOrEmpty(_Correo) Or Not _Correo_Valido Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Yellow
                    If _Chk Then _Correo_Problema += 1
                Else
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                End If
            Else
                If String.IsNullOrEmpty(_Correo) Or Not _Correo_Valido Then
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    If _Chk Then _Correo_Problema += 1
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

        Next

    End Sub

    Private Sub Btn_Enviar_Correos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Enviar_Correos.Click

        Dim _Tickeados = 0
        For Each _Fila As DataRow In _TblEnt.Rows
            Dim _Chk As Boolean = _Fila.Item("Chk")
            If _Chk Then _Tickeados += 1
        Next

        If CBool(_Tickeados) Then

            Sb_Revisar_Grilla()

            Try


                If CBool(_Correo_Problema) Then
                    MessageBoxEx.Show(Me, "Existen entidades con problema en el correo, favor corrija antes de enviar la información" & vbCrLf &
                                      "Marcados con amarillo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If


                If _Correo_Manual Then

                    Dim Fm As New Frm_Correos_SMTP
                    Fm.Pro_Filtro_Extra = "And Envio_Automatico = 0" & vbCrLf
                    Fm.Pro_Seleccionar = True
                    Fm.ShowDialog(Me)

                    If Fm.Pro_Seleccionado Then
                        _Id_Correo = Fm.Pro_Row_Fila_Seleccionada.Item("Id")
                        Fm.Dispose()
                    Else
                        MessageBoxEx.Show(Me, "Debe seleccionar un correo por defecto para el cuerpo del mensaje",
                                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Fm.Dispose()
                        Return
                    End If

                End If

                Grilla_Detalle.Enabled = False
                Btn_Enviar_Correos.Visible = False
                Chk_Marcar_todo.Visible = False
                Me.ControlBox = False

                Progreso_correo.Visible = True
                Lbl_Envio_correo.Visible = True
                Me.Refresh()

                Progreso_correo.Maximum = _TblEnt.Rows.Count

                Dim _Correos_Enviados = 0
                Dim _Correos_Rechazados = 0

                For Each _Fila As DataRow In _TblEnt.Rows

                    Dim _Chk As Boolean = _Fila.Item("Chk")

                    System.Windows.Forms.Application.DoEvents()
                    If _Chk Then
                        Dim _Nokoen = Trim(_Fila.Item("NOKOEN"))
                        Lbl_Envio_correo.Text = "Enviando correo informativo a: " & _Nokoen

                        If Fx_Enviar_Detalle_Pago_Proveedores_Por_Mail(Me, _Fila, _TblInf) Then
                            _Correos_Enviados += 1
                        Else
                            _Correos_Rechazados += 1
                        End If

                        Progreso_correo.Value += 1
                    End If
                Next

                Progreso_correo.Value = 0

                If Not _Correo_Manual Then

                    MessageBoxEx.Show(Me, "Correos enviados: " & _Correos_Enviados & vbCrLf &
                                          "Correos no enviados: " & _Correos_Rechazados, "Envío de correos",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If


                _Cerrar = True
                Me.Close()

            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            Finally

                Grilla_Detalle.Enabled = True
                Btn_Enviar_Correos.Visible = True
                Chk_Marcar_todo.Visible = True
                Me.ControlBox = True

                Progreso_correo.Visible = False
                Lbl_Envio_correo.Visible = False

            End Try

        Else
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Enviar correos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

#Region "ENVIO CORREO PAGO PROVEEDORES"

    Public Function Fx_Enviar_Detalle_Pago_Proveedores_Por_Mail(ByVal _Formulario As Form,
                                                                ByVal _RowEntidad As DataRow,
                                                                ByVal _TblInforme As DataTable) As Boolean


        Dim Crea_Htm As New Clase_Crear_Documento_Htm
        Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        Dim _Registros = 0

        If CBool(_TblInforme.Rows.Count) Then

            For Each _Detalle As DataRow In _TblInforme.Rows
                If _Detalle.Item("Chk") Then _Registros += 1
            Next

            If CBool(_Registros) Then

                Dim _Nudo As String '= _Enc_Documento.Rows(0).Item("NUDO")
                Dim _Tido As String '= _Enc_Documento.Rows(0).Item("TIDO")
                Dim _TipoDoc As String '= Trim(_Sql.Fx_Trae_Dato(, "NOTIDO", "TABTIDO", "TIDO = '" & _Tido & "'"))
                Dim _Estado As String ' = _Enc_Documento.Rows(0).Item("ESDO")

                Dim _Razon_Social As String = Trim(_RowEntidad.Item("NOKOEN"))

                Dim _Para As String = Trim(_RowEntidad.Item("EMAILCOMER"))

                If Fx_Crear_Informe_Html_Pago_Proveedores(_Ruta, _RowEntidad, _TblInforme, "Informe_cobranza") Then

                    Dim Envio_Occ_Mail As New Class_Outlook

                    Dim _Asunto As String
                    ' Dim _Cuerpo As String

                    'ACA CONFIGURAR LOS TAG DEL DOCUMENTO DE PAGO PARA EL MAIL

                    Dim _Adjunto As String = _Ruta & "\Informe_cobranza.Html"
                    Dim _Cuerpo_Html = LeeArchivo(_Adjunto)
                    Dim _CuerpoMensaje As String
                    Dim _Idmaedpce = _TblInforme.Rows(0).Item("IDMAEDPCE")


                    Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & _Id_Correo
                    Dim _TblCorreo As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                    Consulta_Sql = "Select Top 1 * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
                    Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    Dim _Emdp = _Row_Maedpce.Item("EMDP")

                    Consulta_Sql = "Select Top 1 * From TABENDP Where KOENDP = '" & _Emdp & "'"
                    Dim _Row_Tabendp As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)



                    If CBool(_TblCorreo.Rows.Count) Then

                        _CuerpoMensaje = _TblCorreo.Rows(0).Item("CuerpoMensaje")
                        Dim _Remitente = _TblCorreo.Rows(0).Item("Remitente")
                        Dim _CC = _TblCorreo.Rows(0).Item("CC")
                        Dim _Host = _TblCorreo.Rows(0).Item("Host")
                        Dim _Puerto = _TblCorreo.Rows(0).Item("Puerto")
                        Dim _Contrasena = _TblCorreo.Rows(0).Item("Contrasena")

                        _CuerpoMensaje = Replace(_CuerpoMensaje, "&lt;", "<")
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "&gt;", ">")

                        _Asunto = _TblCorreo.Rows(0).Item("Asunto") & " (" & Trim(_Razon_Social) & ")"
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Cuerpo_Html)


                        If String.IsNullOrEmpty(Trim(_CuerpoMensaje)) Then
                            _CuerpoMensaje = "<HTML>"
                        End If

                        Dim _SSL = _TblCorreo.Rows(0).Item("SSL")
                        Dim _Es_Html = _TblCorreo.Rows(0).Item("Es_Html")

                        'CUENTABCO -- char  =  Nro Cta Cte (Cuenta para depositos)
                        'KOENDPEN   -- char  =  Código del banco (Cuenta para depositos)

                        Dim _CodBanco = Trim(_RowEntidad.Item("KOENDPEN"))
                        Dim _Banco_Entidad = _Sql.Fx_Trae_Dato("TABENDP", "NOKOENDP", "TIDPEN = 'CH' AND KOENDP = '" & _CodBanco & "'")
                        Dim _Ctacte_Entidad = Trim(_RowEntidad.Item("CUENTABCO"))

                        Dim _Saludo_Hora_Dia As String = "Buenos días"

                        Dim _Dia As String = Fx_Es_Dia_Tarde_Noche_Madrugada(DateTime.Now.ToShortTimeString())

                        Select Case _Dia
                            Case "MAÑANA", "MADRUGADA"
                                _Saludo_Hora_Dia = "Buenos días"
                            Case "TARDE"
                                _Saludo_Hora_Dia = "Buenas tardes"
                            Case "NOCHE"
                                _Saludo_Hora_Dia = "Buenas noches"
                        End Select

                        Dim _Num_Doc_Pago As String = _Row_Maedpce.Item("NUCUDP")
                        Dim _Valor_Doc_Pago As String = FormatCurrency(_Row_Maedpce.Item("VADP"), 0)

                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<BANCO_ENTIDAD>", _Banco_Entidad)
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<CTACTE_ENTIDAD>", _Ctacte_Entidad)
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<NOMBRE_EMPRESA>", RazonEmpresa)

                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<SALUDO_HORA_DIA>", _Saludo_Hora_Dia)
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<NUM_DOC_PAGO>", _Num_Doc_Pago)
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<VALOR_DOC_PAGO>", _Valor_Doc_Pago)


                        If _Correo_Manual Then
                            Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Adjunto, _Asunto, _CuerpoMensaje, True)
                        Else


                            'If CBool(_TblCorreo.Rows.Count) Then


                            'Dim _Para As String = String.Empty '"jalfaro@bakapp.cl"
                            '_Cuerpo = _CuerpoMensaje

                            Dim _Envio_Automatico As Boolean = _TblCorreo.Rows(0).Item("Envio_Automatico")


                            If _Envio_Automatico Then
                                Dim EnviarCorreo As New Frm_Correos_Conf
                                EnviarCorreo.Fx_Enviar_Mail(_Host,
                                                            _Remitente,
                                                            _Contrasena,
                                                            _Para,
                                                            _CC,
                                                            _Asunto,
                                                            _CuerpoMensaje,
                                                            Nothing,
                                                            _Puerto,
                                                            _SSL,
                                                            False)

                            Else
                                Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Adjunto, _Asunto, _CuerpoMensaje, _Es_Html)
                            End If


                            Return True
                        End If

                    Else

                        MessageBoxEx.Show(_Formulario, "Debe asignar un correo por defecto", "Falta correo en configuración",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If

                End If
            Else
                MessageBoxEx.Show(_Formulario, "No hay documentos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            MessageBoxEx.Show(_Formulario, "No se encontro el documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Function Fx_Crear_Informe_Html_Pago_Proveedores(ByVal _Ruta_Archivo As String,
                                                    ByVal _RowEntidad As DataRow,
                                                    ByVal _TblDetalle As DataTable,
                                                    ByVal _Nombre_Archivo_Adjunto As String) As Boolean
        Try


            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Crear_Html_Facturas_Cobranza

            Dim _Documento_Html As String = My.Resources.Recursos_Inf_Compras_Vencimiento.Crear_Html_Facturas_Pago_Proveedores
            Dim _Detalle_Doc, _Ncc_Doc As String
            Dim _Suma_saldo As Double

            'Consulta_sql = "Select * From MAEEN Where KOEN = '" & _CodEntidad & "' And SUEN = '" & _CodSucEntidad & "'"
            'Dim _Tbl_Entidad As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

            Dim _Koen = Trim(_RowEntidad.Item("KOEN"))
            Dim _Suen = Trim(_RowEntidad.Item("SUEN"))
            Dim _Nokoen = Trim(_RowEntidad.Item("NOKOEN"))

            _Documento_Html = Replace(_Documento_Html, "#Razon_Social#", _Nokoen)

            Dim _Arr_Idmaeedo(_TblDetalle.Rows.Count - 1) As String
            Dim _i = 0

            For Each _Detalle As DataRow In _TblDetalle.Rows

                Dim _Chk As Boolean = _Detalle.Item("Chk")
                Dim _Endo = Trim(_Detalle.Item("ENDO"))
                Dim _Suendo = Trim(_Detalle.Item("SUENDO"))

                If _Chk And _Endo = _Koen And _Suendo = _Suen Then

                    Dim _Idmaeedo As String = UCase(_Detalle.Item("IDMAEEDO"))
                    Dim _Libro As String = _Sql.Fx_Trae_Dato("MAEEDO", "LIBRO", "IDMAEEDO = " & _Idmaeedo)
                    Dim _Tido As String = UCase(_Detalle.Item("TIDO"))
                    Dim _Nudo As String = _Detalle.Item("NUDO")
                    Dim _Feemdo As String = FormatDateTime(_Detalle.Item("FEEMDO"), DateFormat.ShortDate)

                    Dim _Feve As String
                    Try
                        _Feve = FormatDateTime(_Detalle.Item("FEVE"), DateFormat.ShortDate)
                    Catch ex As Exception
                        _Feve = String.Empty
                    End Try

                    Dim _Vave As String = FormatCurrency(_Detalle.Item("VAVE"), 0)
                    Dim _Vaabve As String = FormatCurrency(_Vave, 0)


                    If _Tido = "FCC" Then
                        _Tido = "Factura"
                    ElseIf _Tido = "BLC" Then
                        _Tido = "Boleta"
                    End If

                    _Detalle_Doc +=
                     "<tr bgcolor=" & Chr(34) & "PaleGoldenrod" & Chr(34) & ">" & vbCrLf &
                     "<td align=right class=" & Chr(34) & "style20" & Chr(34) &
                     " align=" & Chr(34) & "center" & Chr(34) & ">" & _Tido & "</td>" & vbCrLf &
                     "<td align=center class=" & Chr(34) & "style17" & Chr(34) & ">" & _Nudo & "</td>" & vbCrLf &
                     "<!--<td align=right class=" & Chr(34) & "style17" & Chr(34) & ">" & _Libro & "</td>-->" & vbCrLf &
                     "<td align=center class=" & Chr(34) & "style18" & Chr(34) & ">" & _Feemdo & "</td>" & vbCrLf &
                     "<!--<td align=right class=" & Chr(34) & "style21" & Chr(34) & ">" & _Feve & "</td>-->" & vbCrLf &
                     "<td align=right class=" & Chr(34) & "style14" & Chr(34) & ">" & _Vaabve & "</td>" & vbCrLf

                    _Suma_saldo += _Detalle.Item("SALDO")

                    _Arr_Idmaeedo(_i) = _Idmaeedo
                    _i += 1

                End If

            Next

            Dim _TblNcc As DataTable
            Dim _Filtro As String = Generar_Filtro_IN_Arreglo(_Arr_Idmaeedo, True)

            If _Filtro <> "()" Then

                Consulta_Sql = "SELECT SUBSTRING(MC.REFANTI,1,3) As Tido,SUBSTRING(MC.REFANTI,5,10) As Nudo," & vbCrLf &
                                "(Select top 1 TIDO From MAEEDO Where IDMAEEDO = MD.IDRST) As Tidp_P," & vbCrLf &
                                "(Select top 1 NUDO From MAEEDO Where IDMAEEDO = MD.IDRST) As Nudo_P," & vbCrLf &
                                "MC.VAASDP" & vbCrLf &
                                "Into #Paso" & vbCrLf &
                                "FROM MAEDPCD MD WITH ( NOLOCK ) INNER JOIN MAEDPCE MC ON MD.IDMAEDPCE = MC.IDMAEDPCE " & vbCrLf &
                                "WHERE IDRST IN " & _Filtro & " AND ARCHIRST = 'MAEEDO' AND TIDP in ('ncv','ncc','ncx')" & vbCrLf &
                                "Select * From #Paso Order By Nudo_P " & vbCrLf &
                                "Drop Table #Paso"

                _TblNcc = _Sql.Fx_Get_Tablas(Consulta_Sql)

                If Not (_TblNcc Is Nothing) Then

                    For Each _Fila As DataRow In _TblNcc.Rows

                        Dim _Nudo_Ncc As String = _Fila.Item("Nudo")
                        Dim _Nudo_Documento As String = _Fila.Item("Tidp_P") & "-" & _Fila.Item("Nudo_P")
                        Dim _Valor As String = FormatCurrency(_Fila.Item("VAASDP"), 0)

                        _Ncc_Doc += My.Resources.Recursos_Inf_Compras_Vencimiento.Enc_Nota_Credito_Inf_Pago_Proveedor.ToString & vbCrLf

                        _Ncc_Doc = Replace(_Ncc_Doc, "#Ncc#", _Nudo_Ncc)
                        _Ncc_Doc = Replace(_Ncc_Doc, "#Documento#", _Nudo_Documento)
                        _Ncc_Doc = Replace(_Ncc_Doc, "#Valor#", _Valor)

                    Next

                    _Documento_Html = Replace(_Documento_Html, "#Notas_de_credito#", _Ncc_Doc)

                End If

            End If


            Dim _Total_Deuda As String = FormatCurrency(_Suma_saldo, 0)

            _Documento_Html = Replace(_Documento_Html, "#Detalle#", _Detalle_Doc)
            _Documento_Html = Replace(_Documento_Html, "#Total_deuda#", _Total_Deuda)

            _Documento_Html = Replace(_Documento_Html, "á", "&aacute;")
            _Documento_Html = Replace(_Documento_Html, "é", "&eacute;")
            _Documento_Html = Replace(_Documento_Html, "í", "&iacute;")
            _Documento_Html = Replace(_Documento_Html, "ó", "&oacute;")
            _Documento_Html = Replace(_Documento_Html, "ú", "&uacute;")
            _Documento_Html = Replace(_Documento_Html, "ñ", "&ntilde;")
            _Documento_Html = Replace(_Documento_Html, "Ñ", "&Ntilde;")

            ' Acento en Html
            'a = &aacute;
            'é = &eacute;
            'í = &iacute;
            'ó = &oacute;
            'ú = &uacute;
            'ñ = &ntilde;
            'Ñ = &Ntilde;

            CrearArchivoTxt(_Ruta_Archivo & "\", _Nombre_Archivo_Adjunto & ".Html", _Documento_Html, False)

            Return True
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try

    End Function

#End Region

    Private Sub Btn_Ingresar_Correo_Solo_Esta_Ocacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ingresar_Correo_Solo_Esta_Ocacion.Click

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Nokoen = Trim(_Fila.Cells("NOKOEN").Value)
        Dim _Correo As String = Trim(_Fila.Cells("EMAILCOMER").Value)
        Dim _Aceptado As Boolean

        _Aceptado = InputBox_Bk(Me, _Nokoen, "Envio de correo de información al proveedor", _Correo, False,
                            _Tipo_Mayus_Minus.Minusculas, , False, _Tipo_Imagen.Correo, False,
                            _Tipo_Caracter.Cualquier_caracter, True)

        Dim _Koen = _Fila.Cells("KOEN").Value
        Dim _Suen = _Fila.Cells("SUEN").Value

        If _Aceptado Then

            Dim _Correo_Valido As Boolean = Fx_Validar_Email(_Correo)

            If Not _Correo_Valido Then Return

            _Fila.Cells("EMAILCOMER").Value = _Correo

            If MessageBoxEx.Show(Me, "¿Desea grabar este correo en la ficha de la entidad permanentemente?" & vbCrLf & vbCrLf &
                                 _Correo,
                                 "Grabar correo", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Consulta_Sql = "Update MAEEN Set EMAILCOMER = '" & _Correo & "'" & vbCrLf &
                               "Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                    Beep()
                    ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                    1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If

            End If

        End If

        Sb_Actualizar_Grilla()

    End Sub


    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_Ficha_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ficha_Entidad.Click

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Koen = _Fila.Cells("KOEN").Value
        Dim _Suen = _Fila.Cells("SUEN").Value

        Dim Fm As New Frm_Crear_Entidad_Mt
        Fm.Fx_Llenar_Entidad(_Koen, _Suen)
        Fm.Pro_Crear_Entidad = False
        Fm.Pro_Editar_Entidad = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

        _Fila.Cells("EMAILCOMER").Value = _Sql.Fx_Trae_Dato("MAEEN", "EMAILCOMER",
                                                    "KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'")

        Fm.Dispose()
        Sb_Actualizar_Grilla()


    End Sub

    Private Sub Frm_Inf_Vencimientos_Correos_Proveedores_Pagos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _Cerrar Then
            If MessageBoxEx.Show(Me, "Si cierra el formulario los correos no se enviaran" & vbCrLf &
                                 "¿Desea salir sin enviar los correos de información?", "Salir sin enviar correos",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Frm_Inf_Vencimientos_Correos_Proveedores_Pagos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Chk_Marcar_todo_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)

        Dim chk As Boolean = Chk_Marcar_todo.Checked
        For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows
            _Fila.Cells("Chk").Value = chk
        Next

        Grilla_Detalle.Refresh()

    End Sub

    Private Sub Grilla_Detalle_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla_Detalle.CellMouseUp
        Grilla_Detalle.EndEdit()
    End Sub

End Class
