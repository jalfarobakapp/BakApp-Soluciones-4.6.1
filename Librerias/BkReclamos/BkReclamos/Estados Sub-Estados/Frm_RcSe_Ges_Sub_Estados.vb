Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_RcSe_Ges_Sub_Estados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Row_Documento As DataRow
    Dim _Tido_Adj As String
    Dim _Notido_Adj As String

    Dim _Id_Reclamo As Integer
    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Grabar As Boolean
    Dim _Fijar_Estado As Boolean
    Dim _Accion As Cl_Reclamo.Enum_Accion
    Dim _Row_Estado As DataRow
    Dim _Editar_Adjuntos As Boolean


    Dim _Estado As String
    Dim _Sub_Estado As String
    Dim _Sub_Estado_A_Revisar As String

    Dim _Doc_Adjunto_Obligatorio As Boolean
    Dim _Arc_Adjunto_Obligatorio As Boolean

    Public Property Pro_Cl_Reclamo As Cl_Reclamo
        Get
            Return _Cl_Reclamo
        End Get
        Set(value As Cl_Reclamo)
            _Cl_Reclamo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public Property Pro_Fijar_Estado As Boolean
        Get
            Return _Fijar_Estado
        End Get
        Set(value As Boolean)
            _Fijar_Estado = value
        End Set
    End Property

    'Dim _Sub_Estado As Cl_Reclamo.Enum_Sub_Estados

    Public Sub New(Estado As String, Sub_Estado As String, Accion As Cl_Reclamo.Enum_Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Estado = Estado
        _Sub_Estado = Sub_Estado
        _Accion = Accion

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Fijar_Estado.ForeColor = Color.White
            Btn_Cancelar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Rcse_01_Recepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Id_Reclamo = _Cl_Reclamo.Id_Reclamo
        Sb_Habilitar_Btn_Archivo_Adjunto(True)

        Me.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla",
                                    "Tabla = 'SIS_RECLAMOS_SUBESTADO' And CodigoTabla = '" & _Sub_Estado & "'")

        Select Case _Sub_Estado

            Case "REM" 'RECEPCION MERCADERIA

                _Tido_Adj = "GRD" : _Notido_Adj = "GUIA DE RECEPCION DE DEVOLUCION"
                Btn_Fijar_Estado.Text = "Enviar a revisión de devolución"
                Btn_Archivos_Adjuntos.Visible = False

                _Arc_Adjunto_Obligatorio = False
                _Doc_Adjunto_Obligatorio = True

                AddHandler Btn_Fijar_Estado.Click, AddressOf Sb_Aceptar_REM_Enviar_a_RVD

                Select Case _Accion

                    Case Cl_Reclamo.Enum_Accion.Nuevo

                        Btn_Fijar_Estado.Visible = True
                        _Editar_Adjuntos = True

                    Case Cl_Reclamo.Enum_Accion.Editar

                        Btn_Editar.Visible = True
                        Btn_Grabar.Visible = True
                        Btn_Cancelar.Visible = True

                        Sb_Cargar_Sub_Estado(_Sub_Estado)
                        Sb_Habilitar_Btn_Edicion(False, True)

                    Case Cl_Reclamo.Enum_Accion.Revisar

                        Sb_Cargar_Sub_Estado(_Sub_Estado)
                        Sb_Habilitar_Btn_Edicion(False, False)

                End Select

            Case "RVD" 'REVISION DE DEVOLUCION

                Btn_Fijar_Estado.Text = "Confirmar revisión de devolución"

                Sb_Cargar_Sub_Estado("REM")

                _Arc_Adjunto_Obligatorio = True
                _Doc_Adjunto_Obligatorio = True

                AddHandler Btn_Fijar_Estado.Click, AddressOf Sb_Aceptar_RVD

                Select Case _Accion

                    Case Cl_Reclamo.Enum_Accion.Nuevo

                        Btn_Fijar_Estado.Visible = True
                        Sb_Habilitar_Btn_Edicion(False, False)
                        Txt_Observacion.Text = String.Empty
                        Txt_Observacion.ReadOnly = False
                        _Editar_Adjuntos = True

                    Case Cl_Reclamo.Enum_Accion.Editar

                        Txt_Observacion.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Reclamo_Estados", "Observacion",
                                                                  "Id_Reclamo = " & _Id_Reclamo & " And Estado = 'RVD'")

                        Sb_Habilitar_Btn_Edicion(False, True)

                    Case Cl_Reclamo.Enum_Accion.Revisar

                        Txt_Observacion.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Reclamo_Estados", "Observacion",
                                                                  "Id_Reclamo = " & _Id_Reclamo & " And Estado = 'RVD'")

                        Sb_Habilitar_Btn_Edicion(False, False)

                End Select


            Case "DME", "REP", "EBV", "RAC" 'DESTRUCCION MERCADERIA

                _Arc_Adjunto_Obligatorio = True
                _Doc_Adjunto_Obligatorio = True

                Select Case _Sub_Estado
                    Case "DME"
                        _Tido_Adj = "GDI" : _Notido_Adj = "GUIA DE DESPACHO INTERNA"
                    Case "REP"
                        _Tido_Adj = "GAR" : _Notido_Adj = "GUIA DE ARMADO DE PRODUCTOS"
                    Case "EBV"
                        _Tido_Adj = "GAR" : _Notido_Adj = "GUIA DE ARMADO DE PRODUCTOS"
                    Case "RAC"
                        '_Tido_Adj = "GRD" : _Notido_Adj = "GUIA DE RECEPCION DE DEVOLUCION"
                        Grupo_Documento_Adjunto.Enabled = False
                        _Doc_Adjunto_Obligatorio = False
                        Lbl_Receptor.Tag = FUNCIONARIO
                        Lbl_Receptor.Text = "Receptor: " & Nombre_funcionario_activo
                        Lbl_Documento.Text = String.Empty
                        Lbl_Fecha_recepcion.Text = String.Empty

                End Select


                Btn_Fijar_Estado.Text = "Confirmar acción"

                AddHandler Btn_Fijar_Estado.Click, AddressOf Sb_Aceptar_Cerrar_Reclamo

                Select Case _Accion

                    Case Cl_Reclamo.Enum_Accion.Nuevo

                        Btn_Fijar_Estado.Visible = True
                        _Editar_Adjuntos = True

                        Sb_Habilitar_Btn_Archivo_Adjunto(True)
                        Txt_Observacion.Text = String.Empty
                        Txt_Observacion.ReadOnly = False

                    Case Cl_Reclamo.Enum_Accion.Editar

                        Sb_Cargar_Sub_Estado(_Sub_Estado)
                        Txt_Observacion.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Reclamo_Estados", "Observacion",
                                                                  "Id_Reclamo = " & _Id_Reclamo & " And Estado = '" & _Sub_Estado & "'")
                        Sb_Habilitar_Btn_Edicion(False, True)

                    Case Cl_Reclamo.Enum_Accion.Revisar

                        Sb_Cargar_Sub_Estado(_Sub_Estado)
                        Txt_Observacion.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Reclamo_Estados", "Observacion",
                                                                  "Id_Reclamo = " & _Id_Reclamo & " And Estado = '" & _Sub_Estado & "'")
                        Sb_Habilitar_Btn_Edicion(False, False)

                End Select

        End Select

    End Sub

    Sub Sb_Cargar_Sub_Estado(_Sub_Estado As String)

        'ERROR EN ESTA LINEA EN EL CAMPO Fecha_recepcion

        Consulta_Sql = "Select top 1 *,Isnull(NOKOFU,'') As NOKOFU From " & _Global_BaseBk & "Zw_Reclamo_Estados 
                        Left Join TABFU On KOFU = CodReceptor
                        Where Id_Reclamo = " & _Id_Reclamo & " And Estado = '" & _Sub_Estado & "'"
        _Row_Estado = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Txt_Observacion.Text = _Row_Estado.Item("Observacion")
        Lbl_Receptor.Text = "Receptor: " & NuloPorNro(_Row_Estado.Item("NOKOFU"), "")
        Lbl_Fecha_recepcion.Text = "Fecha recepción: " & FormatDateTime(_Row_Estado.Item("Fecha_recepcion"), DateFormat.ShortDate)

        Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Row_Estado.Item("Idmaeedo")
        _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Tido = _Row_Estado.Item("Tido")
        Dim _Nudo = _Row_Estado.Item("Nudo")

        If IsNothing(_Row_Documento) Then
            Lbl_Documento.Text = "No se encontro el documento: " & _Tido & "-" & _Nudo & " ???"
        Else
            Lbl_Documento.Text = "Documento Número: " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
        End If

    End Sub

    Private Sub Btn_Buscar_Vendedor_Click(sender As Object, e As EventArgs)

        Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0 And KOFU IN (Select KOFU From TABFUEM Where EMPRESA = '" & Mod_Empresa & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then
            Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

            Lbl_Receptor.Tag = Trim(_Row.Item("Codigo"))
            Lbl_Receptor.Text = Trim(_Row.Item("Descripcion"))

        End If

    End Sub

    Sub Sb_Buscar_Documento(ByVal _Tido_Buscar As String)

        Try

            Dim _IdMaeedo As Integer

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
            With _Fm

                .Grupo_Funcionario.Enabled = False
                .Pro_Sql_Filtro_Documentos_Extra = "And TIDO IN ('" & _Tido_Buscar & "')"
                .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
                .Rdb_Tipo_Documento_Uno.Checked = True
                .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, _Tido_Buscar,
                                      "WHERE TIDO IN ('" & _Tido_Buscar & "')")
                .Rdb_Estado_Vigente.Checked = True
                .Rdb_Funcionarios_Todos.Checked = True
                .Grupo_Funcionario.Enabled = True
                .Rdb_FEmision_EmitidosEntre.Checked = True
                .ShowDialog(Me)

                If Not (.Pro_Row_Documento_Seleccionado Is Nothing) Then
                    _IdMaeedo = .Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")
                End If

                .Dispose()

            End With


            If CBool(_IdMaeedo) Then

                Consulta_Sql = "Select *,Isnull(NOKOFU,'') As NOKOFU From MAEEDO 
                                Left Join TABFU On KOFU = KOFUDO
                                Where IDMAEEDO = " & _IdMaeedo
                _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Lbl_Documento.Text = "Documento Número: " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
                Lbl_Receptor.Tag = _Row_Documento.Item("KOFU")
                Lbl_Receptor.Text = "Receptor: " & _Row_Documento.Item("NOKOFU")
                Lbl_Fecha_recepcion.Text = "Fecha recepción: " & FormatDateTime(_Row_Documento.Item("FEEMDO"), DateFormat.ShortDate)

                Sb_Habilitar_Btn_Archivo_Adjunto(False)

            End If


        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

        End Try

    End Sub

    Private Sub Btn_Adjuntar_Doc_Click(sender As Object, e As EventArgs) Handles Btn_Adjuntar_Doc.Click

        Sb_Buscar_Documento(_Tido_Adj)

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Idmaeedo = _Row_Documento.Item("IDMAEEDO")

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Quitar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Documento.Click

        If MessageBoxEx.Show(Me, "¿Está seguro de querer quitar este documento?", "Quitar documento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            _Row_Documento = Nothing
            Lbl_Documento.Text = "FALTA LA " & _Notido_Adj & "..."
            Lbl_Receptor.Text = String.Empty
            Lbl_Fecha_recepcion.Text = String.Empty

            Sb_Habilitar_Btn_Archivo_Adjunto(True)

        End If

    End Sub

    Sub Sb_Habilitar_Btn_Archivo_Adjunto(_Habilitar As Boolean)

        Btn_Adjuntar_Doc.Enabled = _Habilitar
        Btn_Ver_Documento.Enabled = Not _Habilitar
        Btn_Quitar_Documento.Enabled = Not _Habilitar

        Me.Refresh()

    End Sub

    Sub Sb_Habilitar_Btn_Edicion(_Habilitar As Boolean, _Ver_Botones As Boolean)

        Btn_Editar.Visible = _Ver_Botones
        Btn_Grabar.Visible = _Ver_Botones
        Btn_Cancelar.Visible = _Ver_Botones

        Btn_Editar.Enabled = Not _Habilitar
        Btn_Grabar.Enabled = _Habilitar
        Btn_Cancelar.Enabled = _Habilitar

        If _Habilitar Then
            Btn_Adjuntar_Doc.Enabled = (IsNothing(_Row_Documento))
            Btn_Ver_Documento.Enabled = Not (IsNothing(_Row_Documento))
            Btn_Quitar_Documento.Enabled = Not (IsNothing(_Row_Documento))
        Else
            Btn_Adjuntar_Doc.Enabled = False
            Btn_Quitar_Documento.Enabled = False
            Btn_Ver_Documento.Enabled = Not (IsNothing(_Row_Documento))
        End If

        _Editar_Adjuntos = _Habilitar

        Txt_Observacion.ReadOnly = Not _Habilitar

        Me.Refresh()

    End Sub
    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        Dim Fm As New Frm_Archivos_Adjuntos(_Estado, _Sub_Estado)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Pro_Editar = _Editar_Adjuntos
        Fm.Text = "ARCHIVOS ADJUNTOS (" & Me.Text & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click
        Sb_Habilitar_Btn_Edicion(False, True)
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Permiso As String

        Select Case _Sub_Estado

            Case "REM"
                _Permiso = "Rcl00007"
            Case "RVD"
                _Permiso = "Rcl00008"
            Case "DME"
                _Permiso = "Rcl00009"
            Case "REP"
                _Permiso = "Rcl00010"
            Case "EBV"
                _Permiso = "Rcl00011"
            Case "RAC"
                _Permiso = "Rcl00012"

        End Select

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Sb_Habilitar_Btn_Edicion(True, True)

        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        If _Sub_Estado = "RVD" Then
            Sb_Cargar_Sub_Estado("REM")
        Else
            Sb_Cargar_Sub_Estado(_Sub_Estado)
        End If

        Sb_Habilitar_Btn_Edicion(False, True)

    End Sub

    Sub Sb_Aceptar_REM_Enviar_a_RVD()

        If Fx_Se_Puede_Grabar() Then

            Dim _Observacion = Replace(Txt_Observacion.Text, "'", "")
            Dim _CodReceptor = Lbl_Receptor.Tag
            Dim _Idmaeedo = _Row_Documento.Item("IDMAEEDO")
            Dim _Tido = _Row_Documento.Item("TIDO")
            Dim _Nudo = _Row_Documento.Item("NUDO")
            Dim _Fecha_recepcion = Format(_Row_Documento.Item("FEEMDO"), "yyyyMMdd")

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Sub_Estado = 'RVD' Where Id_Reclamo = " & _Id_Reclamo & "
                        Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion,CodReceptor,Idmaeedo,Tido,Nudo,Fecha_recepcion) Values 
                        (" & _Id_Reclamo & ",'REM','" & FUNCIONARIO & "','" & _Observacion & "','" & _CodReceptor & "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Fecha_recepcion & "')"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                _Fijar_Estado = True
                Me.Close()

            End If

        End If

    End Sub

    Sub Sb_Aceptar_RVD()

        If Fx_Se_Puede_Grabar() Then

            Dim Chk_Destruccion_Mercaderia As New Command
            Chk_Destruccion_Mercaderia.Checked = False
            Chk_Destruccion_Mercaderia.Name = "Chk_Destruccion_Mercaderia"
            Chk_Destruccion_Mercaderia.Text = "DESTRUCCION DE MERCADERIA"

            Dim Chk_Reproceso_Mercaderia As New Command
            Chk_Reproceso_Mercaderia.Checked = False
            Chk_Reproceso_Mercaderia.Name = "Chk_Reproceso_Mercaderia"
            Chk_Reproceso_Mercaderia.Text = "REPROCESO DE MERCADERIA"

            Dim Chk_Envio_Bodega_Ventas As New Command
            Chk_Envio_Bodega_Ventas.Checked = False
            Chk_Envio_Bodega_Ventas.Name = "Chk_Envio_Bodega_Ventas"
            Chk_Envio_Bodega_Ventas.Text = "ENVIO A BODEGA DE VENTAS"


            Dim _Opciones() As Command = {Chk_Destruccion_Mercaderia, Chk_Reproceso_Mercaderia, Chk_Envio_Bodega_Ventas}

            Dim _Info As New TaskDialogInfo("Validación de reclamo",
                                  eTaskDialogIcon.Shield,
                                  "Indique su opción",
                                  "Debe indicar la opción que corresponde a la gestión que se hara posterior a la validación de este reclamo",
                                  eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                                  , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

            If _Resultado = eTaskDialogResult.Ok Then

                If Chk_Destruccion_Mercaderia.Checked Or Chk_Reproceso_Mercaderia.Checked Or Chk_Envio_Bodega_Ventas.Checked Then

                    Dim _Sub_Estado As String
                    Dim _Observacion As String = Txt_Observacion.Text

                    If Chk_Destruccion_Mercaderia.Checked Then
                        _Sub_Estado = "DME"
                    ElseIf Chk_Reproceso_Mercaderia.Checked Then
                        _Sub_Estado = "REP"
                    ElseIf Chk_Envio_Bodega_Ventas.Checked Then
                        _Sub_Estado = "EBV"
                    End If

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Sub_Estado = '" & _Sub_Estado & "' Where Id_Reclamo = " & _Id_Reclamo & "
                        Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values 
                        (" & _Id_Reclamo & ",'RVD','" & FUNCIONARIO & "','" & _Observacion & "')"
                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                        _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                        _Fijar_Estado = True
                        Me.Close()

                    End If

                Else

                    MessageBoxEx.Show(Me, "Debe indicar una opción para la gestión posterior a la validación de reclamo", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            End If

        End If

    End Sub

    Sub Sb_Aceptar_Cerrar_Reclamo()

        If Fx_Se_Puede_Grabar() Then

            Dim _Observacion = Replace(Txt_Observacion.Text, "'", "")
            Dim _CodReceptor = Lbl_Receptor.Tag
            Dim _Idmaeedo = 0
            Dim _Tido = _Tido_Adj
            Dim _Nudo = "????"
            Dim _Fecha_recepcion As String

            If Not IsNothing(_Row_Documento) Then

                _Idmaeedo = _Row_Documento.Item("IDMAEEDO")
                _Tido = _Row_Documento.Item("TIDO")
                _Nudo = _Row_Documento.Item("NUDO")
                _Fecha_recepcion = Format(_Row_Documento.Item("FEEMDO"), "yyyyMMdd")

            Else

                _Tido = String.Empty
                _Nudo = String.Empty
                _Fecha_recepcion = Format(FechaDelServidor, "yyyyMMdd")

            End If

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'ACI' Where Id_Reclamo = " & _Id_Reclamo & "
                        Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values 
                        (" & _Id_Reclamo & ",'GES','" & FUNCIONARIO & "','Gestionado completamente')
                        Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion,CodReceptor," &
                        "Idmaeedo,Tido,Nudo,Fecha_recepcion) Values 
                        (" & _Id_Reclamo & ",'" & _Cl_Reclamo.Sub_Estado & "','" & FUNCIONARIO & "','" & _Observacion & "'" &
                        ",'" & _CodReceptor & "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Fecha_recepcion & "')"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                MessageBoxEx.Show(Me, "Acción incorporada correctamente", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                _Fijar_Estado = True
                Me.Close()

            End If

        End If

    End Sub

    Function Fx_Se_Puede_Grabar() As Boolean

        If String.IsNullOrEmpty(Txt_Observacion.Text) Then

            Beep()
            ToastNotification.Show(Me, "FALTA OBSERVACION",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Observacion.Focus()

            Return False

        End If

        If _Doc_Adjunto_Obligatorio Then
            If IsNothing(_Row_Documento) Then

                Beep()
                ToastNotification.Show(Me, "FALTA DOCUMENTO " & _Notido_Adj,
                                       Imagenes_32x32.Images.Item("Warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Return False

            End If

        End If

        If _Arc_Adjunto_Obligatorio Then

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Reclamo_Archivos",
                                            "Id_Reclamo = " & _Id_Reclamo & " And Estado = '" & _Estado & "' And Sub_Estado = '" & _Sub_Estado & "'")

            If Not CBool(_Reg) Then

                Beep()
                ToastNotification.Show(Me, "FALTAN DOCUMENTOS ADJUNTOS",
                                       Imagenes_32x32.Images.Item("Warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Return False

            End If

        End If

        Return True

    End Function

End Class
