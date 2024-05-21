Imports DevComponents.DotNetBar

Public Class Frm_BuscarDocumento_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Documentos As DataTable

    Dim _IdMaeedo_Doc As Integer
    Dim _Sql_Query As String
    Dim _Abrir_Seleccionado As Boolean

    Dim _Pago_a_Documento As Boolean
    Dim _Enviar_Correos_Masivamente As Boolean
    Dim _Seleccion_Multiple As Boolean
    Dim _Tbl_DocSeleccionados As DataTable
    Dim _Ocultar_Envio_Correos_Masivamente As Boolean
    Dim _Cancelar As Boolean
    Dim _Abrir_Cerrar_Documentos_Compromiso As Boolean
    Dim _Abrir_Documentos As Boolean
    Dim _Cerrar_Documentos As Boolean
    Dim _Cerrar_Documentos_Automaticamente As Boolean

    Public Property HabilitarNVVParaFacturar As Boolean

    Public Property Pro_Pago_a_Documento() As Boolean
        Get
            Return _Pago_a_Documento
        End Get
        Set(ByVal value As Boolean)
            _Pago_a_Documento = value
        End Set
    End Property

    Public Property Pro_IdMaeedo_Doc As Integer
        Get
            Return _IdMaeedo_Doc
        End Get
        Set(value As Integer)
            _IdMaeedo_Doc = value
        End Set
    End Property

    Public Property Pro_Sql_Query As String
        Get
            Return _Sql_Query
        End Get
        Set(value As String)
            _Sql_Query = value
        End Set
    End Property

    Public Property Pro_Abrir_Seleccionado As Boolean
        Get
            Return _Abrir_Seleccionado
        End Get
        Set(value As Boolean)
            _Abrir_Seleccionado = value
        End Set
    End Property

    Public Property Enviar_Correos_Masivamente As Boolean
        Get
            Return _Enviar_Correos_Masivamente
        End Get
        Set(value As Boolean)
            _Enviar_Correos_Masivamente = value
        End Set
    End Property

    Public Property Seleccion_Multiple As Boolean
        Get
            Return _Seleccion_Multiple
        End Get
        Set(value As Boolean)
            _Seleccion_Multiple = value
        End Set
    End Property

    Public Property Tbl_DocSeleccionados As DataTable
        Get
            Return _Tbl_DocSeleccionados
        End Get
        Set(value As DataTable)
            _Tbl_DocSeleccionados = value
        End Set
    End Property

    Public Property Ocultar_Envio_Correos_Masivamente As Boolean
        Get
            Return _Ocultar_Envio_Correos_Masivamente
        End Get
        Set(value As Boolean)
            _Ocultar_Envio_Correos_Masivamente = value
        End Set
    End Property

    Public Property Abrir_Cerrar_Documentos_Compromiso As Boolean
        Get
            Return _Abrir_Cerrar_Documentos_Compromiso
        End Get
        Set(value As Boolean)
            _Abrir_Cerrar_Documentos_Compromiso = value
        End Set
    End Property

    Public Property Abrir_Documentos As Boolean
        Get
            Return _Abrir_Documentos
        End Get
        Set(value As Boolean)
            _Abrir_Documentos = value
        End Set
    End Property

    Public Property Cerrar_Documentos As Boolean
        Get
            Return _Cerrar_Documentos
        End Get
        Set(value As Boolean)
            _Cerrar_Documentos = value
        End Set
    End Property

    Public Property Cerrar_Documentos_Automaticamente As Boolean
        Get
            Return _Cerrar_Documentos_Automaticamente
        End Get
        Set(value As Boolean)
            _Cerrar_Documentos_Automaticamente = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_BuscarDocumento_Mt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Enviar_Correos_Masivamente Then
            Me.Top += 20
            Me.Left += 20
        End If

        If _Pago_a_Documento Then
            Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Else
            Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        End If

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Btn_Enviar_Correos_Masivos.Visible = False
        Btn_Enviar_Los_Correos.Visible = False
        Chk_Marcar_Todas.Visible = False

        If _Sql.Fx_Existe_Tabla("MAEENMAIL") And Not Abrir_Cerrar_Documentos_Compromiso Then
            If Not _Ocultar_Envio_Correos_Masivamente Then
                Btn_Enviar_Correos_Masivos.Visible = Not _Enviar_Correos_Masivamente
                Btn_Enviar_Los_Correos.Visible = _Enviar_Correos_Masivamente
                Chk_Marcar_Todas.Visible = _Enviar_Correos_Masivamente
            End If
        End If

        Btn_Cerrar_Documentos.Visible = Abrir_Cerrar_Documentos_Compromiso
        Btn_Abrir_Documentos.Visible = False
        Btn_Cerrar_Documentos.Visible = False

        If Abrir_Cerrar_Documentos_Compromiso Then

            Chk_Marcar_Todas.Visible = True
            BtnAceptar.Visible = False
            CmbCantFilas.SelectedValue = 6

            If _Abrir_Documentos Then
                Me.Text = "DOCUMENTOS PARA ABRIR"
                Btn_Abrir_Documentos.Text = "Abrir documentos"
            End If

            If _Cerrar_Documentos Then
                Me.Text = "DOCUMENTOS PARA CERRAR"
                Btn_Cerrar_Documentos.Text = "Cerrar documentos"
            End If

            Btn_Abrir_Documentos.Visible = _Abrir_Documentos
            Btn_Cerrar_Documentos.Visible = _Cerrar_Documentos

        End If

        Btn_GrabarHabilitarFacturar.Visible = HabilitarNVVParaFacturar

        Sb_Actualizar()

        AddHandler BtnActualizarLista.Click, AddressOf Sb_Actualizar

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Tiempo_Cerrar_Documentos_Automaticamente.Enabled = Cerrar_Documentos_Automaticamente

        Btn_CopiarDocOtrEmpresa.Visible = (RutEmpresa = "77458040-9" Or RutEmpresa = "07251245-6" Or RutEmpresa = "77634877-5" Or RutEmpresa = "77634879-1")

    End Sub

    Public Sub Sb_Llenar_Grilla(ByVal Sql_Query As String)

        _Tbl_Documentos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If HabilitarNVVParaFacturar Then

            Dim dc As DataColumn
            dc = New DataColumn("FunAutoriza", Type.GetType("System.String"))
            _Tbl_Documentos.Columns.Add(dc)

        End If

        ' Return

        With Grilla

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Chk").HeaderText = "Sel"

            If HabilitarNVVParaFacturar Then .Columns("Chk").HeaderText = "Hab"

            .Columns("Chk").Width = 30
            .Columns("Chk").Visible = (_Enviar_Correos_Masivamente Or _Seleccion_Multiple Or Abrir_Cerrar_Documentos_Compromiso Or HabilitarNVVParaFacturar)
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").HeaderText = "SD"
            .Columns("SUDO").Width = 35
            .Columns("SUDO").Visible = True
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 90
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 75
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Width = 40
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RAZON").HeaderText = "Razón Social"
            .Columns("RAZON").Width = 280
            .Columns("RAZON").Visible = True
            .Columns("RAZON").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").HeaderText = "Monto"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEULVEDO").HeaderText = "Vencim."
            .Columns("FEULVEDO").Width = 70
            .Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFUDO").HeaderText = "Resp"
            .Columns("KOFUDO").Width = 35
            .Columns("KOFUDO").Visible = True
            .Columns("KOFUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ESTADO").HeaderText = "Estado"
            .Columns("ESTADO").Width = 60
            .Columns("ESTADO").Visible = True
            .Columns("ESTADO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Pintar_Grilla()

        If CBool(Grilla.Rows.Count) Then

            _Grilla.CurrentCell = _Grilla.Rows(0).Cells("TIDO")

            With Grilla

                If _Pago_a_Documento Then

                    For Each row As DataGridViewRow In .Rows

                        Dim _Nudonodefi As Boolean = row.Cells("NUDONODEFI").Value

                        If _Nudonodefi Then

                            row.Cells("NRO_DEF").Style.BackColor = Color.Yellow
                            row.Cells("NRO_DEF").Style.ForeColor = Color.Black

                        Else

                            If Global_Thema = Enum_Themas.Oscuro Then
                                row.Cells("NRO_DEF").Style.BackColor = Color.Black
                            Else
                                row.Cells("NRO_DEF").Style.BackColor = Color.White
                            End If

                        End If

                    Next

                Else

                    For Each row As DataGridViewRow In .Rows

                        Dim _Estado As String = row.Cells("ESTADO").Value
                        Dim _Nudonodefi As Boolean = row.Cells("NUDONODEFI").Value

                        If _Estado = "Cerrado" Then
                            .Rows.Item(row.Index).Cells("ESTADO").Style.ForeColor = Rojo
                        ElseIf _Estado = "Vigente" Then
                            .Rows.Item(row.Index).Cells("ESTADO").Style.ForeColor = Verde
                        ElseIf _Estado = "Nulo" Then
                            row.DefaultCellStyle.ForeColor = Color.Gray
                            '.Rows.Item(row.Index).Cells("ESTADO").Style.ForeColor = Verde
                        End If

                        If _Nudonodefi Then

                            If _Estado = "Nulo" Then
                                'row.Cells("NUDO").Style.ForeColor = Color.Black
                                row.Cells("NUDO").Style.BackColor = Color.LightYellow
                            Else
                                row.Cells("NUDO").Style.ForeColor = Color.Black
                                row.Cells("NUDO").Style.BackColor = Color.Yellow
                            End If

                        End If

                    Next

                End If

            End With

        End If

    End Sub

    Public Sub Sb_Llenar_Grilla_Pago_A_Documentos(ByVal Sql_Query As String)

        _Tbl_Documentos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 35
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 0

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 90
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 1

            .Columns("ENDO").HeaderText = "Cod. Entidad"
            .Columns("ENDO").Width = 80
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = 2

            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Width = 40
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = 3

            .Columns("RAZON").HeaderText = "Razón Social"
            .Columns("RAZON").Width = 200 + 25 + 105
            .Columns("RAZON").Visible = True
            .Columns("RAZON").DisplayIndex = 4

            .Columns("SUDO").HeaderText = "Suc."
            .Columns("SUDO").Width = 35
            .Columns("SUDO").Visible = True
            .Columns("SUDO").DisplayIndex = 5

            .Columns("NRO_DEF").HeaderText = "Situación"
            .Columns("NRO_DEF").Width = 60
            .Columns("NRO_DEF").Visible = True
            .Columns("NRO_DEF").DisplayIndex = 6

            .Columns("MODO").HeaderText = "M."
            .Columns("MODO").Width = 30
            .Columns("MODO").Visible = True
            .Columns("MODO").DisplayIndex = 7
            .Columns("MODO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("VABRDO").HeaderText = "Valor Doc."
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = 8
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##.##"

            .Columns("SALDO_ACTUAL").HeaderText = "Saldo Actual"
            .Columns("SALDO_ACTUAL").Width = 80
            .Columns("SALDO_ACTUAL").Visible = True
            .Columns("SALDO_ACTUAL").DisplayIndex = 9
            .Columns("SALDO_ACTUAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_ACTUAL").DefaultCellStyle.Format = "$ ###,##.##"

        End With

    End Sub

    Sub Sb_Ver_Documento()

        Me.Enabled = False

        Dim _Actualizar As Boolean

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.ShowDialog(Me)

            Dim _Row As DataRow = Fm.Pro_Row_Maeedo

            Dim _Estado As String = _Row.Item("ESTADO")

            If _Estado = "Cerrado" Then
                _Fila.Cells("ESTADO").Style.ForeColor = Rojo
            ElseIf _Estado = "Vigente" Then
                _Fila.Cells("ESTADO").Style.ForeColor = Verde
            End If

            _Fila.Cells("ESTADO").Value = _Estado

            _Actualizar = (Fm.Anulado Or Fm.Eliminado)

            Fm.Dispose()

            If HabilitarNVVParaFacturar Then
                _Actualizar = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Docu_Ent", "HabilitadaFac", "Idmaeedo = " & _Idmaeedo,,,, True)
                If _Estado = "Cerrado" Then _Actualizar = True
            End If

            If _Actualizar Then Sb_Actualizar()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        _IdMaeedo_Doc = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("IDMAEEDO").Value)

        If _Abrir_Seleccionado Then
            Sb_Ver_Documento()
        Else
            Call BtnAceptar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        If _Seleccion_Multiple Then

            Dim _Reg = 0

            For Each _Fila As DataGridViewRow In Grilla.Rows
                If _Fila.Cells("Chk").Value Then
                    _Reg += 1
                End If
            Next

            If _Reg = 0 Then
                MessageBoxEx.Show(Me, "No hay ningún registro seleccionado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Tbl_Documentos, "Chk", "IDMAEEDO", False, True, "")

            Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO In " & _Filtro_Idmaeedo
            _Tbl_DocSeleccionados = _Sql.Fx_Get_Tablas(Consulta_Sql)

            Me.Close()

        Else

            If Grilla.RowCount > 0 Then

                _IdMaeedo_Doc = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("IDMAEEDO").Value)
                Me.Close()

            Else
                MessageBoxEx.Show(Me, "No existen registros que traspasar", "Seleccionar documento",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Sub Sb_Actualizar_Grilla_Detalle(ByVal Idmaeedo As String)

        Consulta_Sql = "SELECT KOFULIDO,SULIDO,BOSULIDO,KOPRCT,ALTERNAT,NOKOPR,
                        CASE UDTRPR WHEN 1 THEN CAPRCO1 ELSE CAPRCO2 END AS CAPRCO,   
                        CASE
                            WHEN UDTRPR = 1 THEN
                            (CAPRCO1-(CAPRAD1+CAPREX1))
                        ELSE (CAPRCO2-(CAPRAD2+CAPREX2))
                        END     
                        AS SALDO, -- Saldo Cantidad
                        CASE UDTRPR WHEN 1 THEN UD01PR ELSE UD02PR END AS UD,PPPRNE FROM MAEDDO WHERE IDMAEEDO = " & Idmaeedo

        With Grilla_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle)

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)

            Dim _DisplayIndex = 0

            .Columns("KOFULIDO").Width = 35
            .Columns("KOFULIDO").HeaderText = "Ven"
            .Columns("KOFULIDO").DisplayIndex = _DisplayIndex
            .Columns("KOFULIDO").Visible = True
            _DisplayIndex += 1

            .Columns("SULIDO").Width = 35
            .Columns("SULIDO").HeaderText = "Suc"
            .Columns("SULIDO").DisplayIndex = _DisplayIndex
            .Columns("SULIDO").Visible = True
            _DisplayIndex += 1

            .Columns("BOSULIDO").Width = 35
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").DisplayIndex = _DisplayIndex
            .Columns("BOSULIDO").Visible = True
            _DisplayIndex += 1

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            .Columns("KOPRCT").Visible = True
            _DisplayIndex += 1

            '.Columns("ALTERNAT").Width = 80
            '.Columns("ALTERNAT").HeaderText = "Alternativo"
            '.Columns("ALTERNAT").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NOKOPR").Width = (310 + 120 + 10) - 35
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            .Columns("NOKOPR").Visible = True
            _DisplayIndex += 1

            .Columns("UD").Width = 25
            .Columns("UD").HeaderText = "UD"
            .Columns("UD").DisplayIndex = _DisplayIndex
            .Columns("UD").Visible = True
            _DisplayIndex += 1

            .Columns("CAPRCO").Width = 70
            .Columns("CAPRCO").HeaderText = "Cantidad"
            .Columns("CAPRCO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO").DefaultCellStyle.Format = "###,##"
            .Columns("CAPRCO").DisplayIndex = _DisplayIndex
            .Columns("CAPRCO").Visible = True
            _DisplayIndex += 1

            .Columns("SALDO").Width = 70
            .Columns("SALDO").HeaderText = "Saldo"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").DefaultCellStyle.Format = "###,##.##"
            .Columns("SALDO").DisplayIndex = _DisplayIndex
            .Columns("SALDO").Visible = True
            _DisplayIndex += 1

            .Columns("PPPRNE").Width = 90
            .Columns("PPPRNE").HeaderText = "Precio neto"
            .Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PPPRNE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PPPRNE").DisplayIndex = _DisplayIndex
            .Columns("PPPRNE").Visible = True
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Razon_Fisica As String
        Dim _Sucursal As String

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _IdMaeedo_Doc = Trim(_Fila.Cells("IDMAEEDO").Value)
            Dim _Nudonodefi = _Fila.Cells("NUDONODEFI").Value

            _Razon_Fisica = Trim(_Fila.Cells("RAZON_FISICA").Value)
            _Sucursal = Space(1) & ",Sucursal doc.: " & Trim(_Fila.Cells("NOKOSU").Value)

            If _Nudonodefi Then
                _Sucursal += " ...(Vale Transitorio)"
            End If

            Sb_Actualizar_Grilla_Detalle(_IdMaeedo_Doc)

        Catch ex As Exception
            _Razon_Fisica = String.Empty
        End Try

        LblEntFisica.Text = "Entidad física: " & _Razon_Fisica & _Sucursal

    End Sub

    Sub Sb_Enviar_documento_por_correo()

        Dim _IdMaeedo_Doc = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("IDMAEEDO").Value)

        Dim _Nudo = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("NUDO").Value)
        Dim _TipoDoc As String = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("TipoDoc").Value)
        Dim _Koen = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("ENDO").Value)
        Dim _Suen = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("SUENDO").Value)
        Dim _DatosEntidad As DataTable = Fx_Traer_Datos_Entidad_Tabla(_Koen, _Suen)
        Dim _Email_Para As String

        Try
            _Email_Para = _DatosEntidad.Rows(0).Item("EMAIL")
        Catch ex As Exception
            _Email_Para = String.Empty
        End Try

        Dim Crea_Htm As New Clase_Crear_Documento_Htm
        Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        If Not IO.Directory.Exists(_Ruta) Then
            System.IO.Directory.CreateDirectory(_Ruta)
        End If

        Sb_Enviar_Doc_Por_Mail(_IdMaeedo_Doc, _Email_Para, "Estimados.", "", Me, True)

    End Sub

    Private Function Fx_Enviar_documento_por_correo_Diablito_MAEENMAIL(_Idmaeedo As Integer,
                                                                       _Nombre_Correo As String) As Boolean

        Dim _Para_Maeenmail = True

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo = '" & _Nombre_Correo & "'"
        Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Consulta_Sql = "Select TIDO,NUDO,ENDO,SUENDO From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Koen = _Row_Maeedo.Item("ENDO")
        Dim _Suen = _Row_Maeedo.Item("SUENDO")

        Consulta_Sql = "Select Distinct Rtrim(Ltrim(MAILTO)) As MAILTO,Rtrim(Ltrim(MAILCC)) As MAILCC From MAEENMAIL Where KOEN = '" & _Koen & "' And KOMAIL = '001'"

        Dim _Tbl_Maeenmail As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        System.Windows.Forms.Application.DoEvents()

        Consulta_Sql = String.Empty

        Dim _Asunto = _Row_Correo.Item("Asunto")
        Dim _Mensaje = _Row_Correo.Item("Asunto")

        If Convert.ToBoolean(_Tbl_Maeenmail.Rows.Count) Then

            For Each _Fila_Mail As DataRow In _Tbl_Maeenmail.Rows

                Dim _Para As String = Trim(_Fila_Mail.Item("MAILTO"))
                Dim _Cc As String = Trim(_Fila_Mail.Item("MAILCC"))

                _Para = _Para.Trim()
                _Cc = _Cc.Trim()

                Consulta_Sql += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (NombreEquipo,Nombre_Correo,CodFuncionario,Asunto," &
                                "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Informacion,Para_Maeenmail)" &
                                vbCrLf &
                                "Values" & vbCrLf &
                                "('','" & _Nombre_Correo & "','" & FUNCIONARIO & "','Asunto',Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Intentos,enviado,Adjuntar_Documento,Mensaje,Fecha,Informacion,Para_Maeenmail)"

            Next

        End If


        'Consulta_Sql = "Select Distinct TipoDoc,Codigo,Nombre_Funcionario,Impresora,NombreFormato,Nro_Copias_Impresion,Nombre_Correo,
        '                Correo_Para,Correo_CC,Correo_Body,Picking,NombreFormato_Correo,Para_Maeenmail
        '                From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion
        '                Where TipoDoc = '" & _Tido & "' And Codigo = '" & _Kofudo & "'"

        'Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        'Dim _Documentos_Enviados = 0

        'For Each _Fila As DataRow In _Tbl.Rows

        '    Dim _Nombre_Correo = _Fila.Item("Nombre_Correo")
        '    Dim _NombreFormato_Correo = _Fila.Item("NombreFormato_Correo")
        '    Dim _Para_Maeenmail = _Fila.Item("Para_Maeenmail")

        '    Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo = '" & _Nombre_Correo & "'"
        '    Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        '    If Not IsNothing(_Row_Correo) Then

        '        Dim _Asunto = _Row_Correo.Item("Asunto")
        '        Dim _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje")

        '        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & Space(1) &
        '                       "(NombreEquipo,Nombre_Correo,CodFuncionario,Asunto,Para,Cc,Idmaeedo," &
        '                       "Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Para_Maeenmail) " & vbCrLf &
        '                       "Select '','" & _Nombre_Correo & "','" & _Kofudo & "','" & _Asunto & "','','',IDMAEEDO,TIDO,NUDO," &
        '                       "'" & _NombreFormato_Correo & "',1,0,0,1,'" & _CuerpoMensaje & "',Getdate()," & Convert.ToInt32(_Para_Maeenmail) & vbCrLf &
        '                       "From MAEEDO Where IDMAEEDO = " & _Idmaeedo

        '        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
        '            Return True
        '        End If

        '    End If

        'Next

    End Function

    Private Function Fx_Enviar_documento_por_correo_Diablito_MAEENMAIL(_Idmaeedo As Integer, _Tido As String, _Kofudo As String) As Boolean

        Consulta_Sql = "SELECT Distinct TipoDoc,Codigo,Nombre_Funcionario,Impresora,NombreFormato,Nro_Copias_Impresion,Nombre_Correo,
                        Correo_Para,Correo_CC,Correo_Body,Picking, NombreFormato_Correo,Para_Maeenmail
                        From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion
                        Where TipoDoc = '" & _Tido & "' And Codigo = '" & _Kofudo & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Documentos_Enviados = 0

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Nombre_Correo = _Fila.Item("Nombre_Correo")
            Dim _NombreFormato_Correo = _Fila.Item("NombreFormato_Correo")
            Dim _Para_Maeenmail = _Fila.Item("Para_Maeenmail")

            Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo = '" & _Nombre_Correo & "'"
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not IsNothing(_Row_Correo) Then

                Dim _Asunto = _Row_Correo.Item("Asunto")
                Dim _CuerpoMensaje = Replace(_Row_Correo.Item("CuerpoMensaje"), "'", "''")

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & Space(1) &
                               "(NombreEquipo,Nombre_Correo,CodFuncionario,Asunto,Para,Cc,Idmaeedo," &
                               "Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Para_Maeenmail) " & vbCrLf &
                               "Select '','" & _Nombre_Correo & "','" & _Kofudo & "','" & _Asunto & "','','',IDMAEEDO,TIDO,NUDO,'" & _NombreFormato_Correo & "',1,0,0,1,'" & _CuerpoMensaje & "',Getdate()," & Convert.ToInt32(_Para_Maeenmail) & vbCrLf &
                               "From MAEEDO Where IDMAEEDO = " & _Idmaeedo
                Return _Sql.Ej_consulta_IDU(Consulta_Sql)

            End If

        Next

    End Function

    Private Sub Frm_BuscarDocumento_Mt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            _IdMaeedo_Doc = 0
            Me.Close()
        ElseIf e.KeyValue = Keys.F5 Then
            Sb_Actualizar()
        End If

    End Sub

    Function Fx_Cambiar_Entidad_Doc(ByVal _IdMaeedo As Integer, ByVal _Permiso As String) As DataTable

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", "ARCHIRST = 'MAEDDO' And IDRST = " & _IdMaeedo))

            If _Reg Then

                MessageBoxEx.Show(Me, "¡Este documento tiene documentos dependientes, no se puede cambiar la entidad!",
                                  "Validación",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return Nothing

            End If

            Dim Fm As New Frm_BuscarEntidad_Mt(False)
            Fm.ShowDialog(Me)

            If Not (Fm.Pro_RowEntidad Is Nothing) Then

                Dim _Cod_Entidad As String = Fm.Pro_RowEntidad.Item("KOEN")
                Dim _Suc_Entidad As String = Fm.Pro_RowEntidad.Item("SUEN")
                Dim _Razon_Entidad As String = Fm.Pro_RowEntidad.Item("NOKOEN")
                Dim _Rut As String = Fm.Pro_RowEntidad.Item("Rut")

                If MessageBoxEx.Show(Me, "¿Está seguro de incorporar esta entidad como nueva razón social del documento?" & vbCrLf & vbCrLf &
                                     "Rut: " & _Rut & ", " & _Razon_Entidad,
                                     "Cambiar entidad del documento",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                    Consulta_Sql = "UPDATE MAEEDO SET ENDO='" & _Cod_Entidad & "', SUENDO = '" & _Suc_Entidad & "'" & vbCrLf &
                                      "WHERE IDMAEEDO = " & _IdMaeedo & vbCrLf &
                                      "UPDATE MAEDDO SET ENDO='" & _Cod_Entidad & "', SUENDO = '" & _Suc_Entidad & "'" & vbCrLf &
                                      "WHERE IDMAEEDO = " & _IdMaeedo & vbCrLf &
                                      "UPDATE MAEDPCE SET ENDP = '" & _Cod_Entidad & "'" & vbCrLf &
                                      "WHERE IDMAEDPCE IN (SELECT IDMAEDPCE FROM MAEDPCD WHERE IDRST = " & _IdMaeedo & ")"

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Cambiar entidad del documento",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Return Fm.Pro_TblEntidad

                    Else
                        Return Nothing
                    End If

                End If

            End If

        End If

        Return Nothing

    End Function

    Sub Sb_Actualizar()

        Consulta_Sql = _Sql_Query
        Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", CmbCantFilas.Text)

        If _Pago_a_Documento Then
            Sb_Llenar_Grilla_Pago_A_Documentos(Consulta_Sql)
        Else
            Sb_Llenar_Grilla(Consulta_Sql)
        End If

        Sb_Pintar_Grilla()

        _Sql_Query = Replace(_Sql_Query, "Top" & CmbCantFilas.Text, "Top #CantidadDoc#")

    End Sub

    Private Sub Btn_Cambiar_Entidad_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Entidad_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _IdMaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Tipo As String = _Fila.Cells("TIDO").Value
        Dim _Numero As String = _Fila.Cells("NUDO").Value

        Dim _Permiso As String

        If _Tipo = "COV" Then
            _Permiso = "Espr0011"
        Else
            _Permiso = "Espr0004"
        End If

        Dim _Tbl_Inf_Entidad As DataTable = Fx_Cambiar_Entidad_Doc(_IdMaeedo, _Permiso)

        If Not (_Tbl_Inf_Entidad Is Nothing) Then

            _Fila.Cells("ENDO").Value = _Tbl_Inf_Entidad.Rows(0).Item("KOEN")
            _Fila.Cells("SUENDO").Value = _Tbl_Inf_Entidad.Rows(0).Item("SUEN")
            _Fila.Cells("RAZON").Value = _Tbl_Inf_Entidad.Rows(0).Item("NOKOEN")

        End If

    End Sub

    Private Sub Btn_Imprimir_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Documento.Click

        If Fx_Tiene_Permiso(Me, "Doc00012") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _IdMaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
            Dim _Tido = _Fila.Cells("TIDO").Value
            Dim _Subtido = String.Empty

            If _Tido = "GDD" Or _Tido = "GDP" Then
                _Subtido = _Fila.Cells("SUBTIDO").Value
            End If

            Consulta_Sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _IdMaeedo
            Dim _RowEncabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _NombreFormato As String

            Dim Fm As New Frm_Seleccionar_Formato(_Tido)
            If CBool(Fm.Tbl_Formatos.Rows.Count) Then
                Fm.ShowDialog(Me)

                If Fm.Formato_Seleccionado Then
                    _Subtido = Fm.Row_Formato_Seleccionado.Item("Subtido")
                    _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                    If _NombreFormato = "" Then
                        _NombreFormato = String.Empty
                    End If

                    Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _IdMaeedo,
                                                             False, True, "", False, 0, False, _Subtido)

                    If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                        MessageBox.Show(Me, _Imprime, "Problemas al Imprimir",
                                   MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Else
                MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
                    Dim _Tido = _Fila.Cells("TIDO").Value
                    Dim _Estado = _Fila.Cells("ESTADO").Value

                    Btn_Facturar.Visible = False

                    If _Tido = "NVV" Then
                        Btn_Facturar.Visible = (_Estado = "Vigente")
                    End If

                    LabelItem1.Text = "Opciones (Id: " & _Idmaeedo & ")"

                    ShowContextMenu(Menu_Contextual_01)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Enviar_Correo_Adjunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Enviar_Correo_Adjunto.Click
        Sb_Enviar_documento_por_correo()
    End Sub

    Private Sub Btn_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documento.Click
        Sb_Ver_Documento()
    End Sub

    Private Sub Grilla_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.ColumnHeaderMouseClick
        Sb_Pintar_Grilla()
    End Sub

    Private Sub Btn_Enviar_Correos_Masivos_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Correos_Masivos.Click

        Dim Fm As New Frm_BuscarDocumento_Mt
        Fm.Lbl_Ver.Text = Me.Text
        Fm.BtnAceptar.Visible = False
        Fm.Pro_Sql_Query = Pro_Sql_Query
        Fm.CmbCantFilas.Text = CmbCantFilas.Text
        Fm.Pro_Pago_a_Documento = Pro_Pago_a_Documento
        Fm.Pro_Abrir_Seleccionado = Pro_Abrir_Seleccionado
        Fm.BtnActualizarLista.Visible = False
        Fm.Enviar_Correos_Masivamente = True
        Fm.CmbCantFilas.Visible = False
        Fm.Lbl_Ver.Visible = False
        Fm.ShowDialog(Me)

        Fm.Dispose()

    End Sub

    Private Sub Btn_Enviar_Los_Correos_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Los_Correos.Click

        Dim _Reg = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Fila.Cells("Chk").Value Then
                _Reg += 1
            End If

        Next

        If _Reg = 0 Then

            MessageBoxEx.Show(Me, "No hay ningún registro seleccionado", "Reenviar correos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Enviados = 0

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            If _Fila.Item("Chk") Then

                Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
                Dim _Tido As String = _Fila.Item("TIDO")
                Dim _Kofudo As String = _Fila.Item("KOFUDO")

                If Fx_Enviar_documento_por_correo_Diablito_MAEENMAIL(_Idmaeedo, _Tido, _Kofudo) Then
                    _Enviados += 1
                End If

            End If

        Next

        If CBool(_Enviados) Then
            MessageBoxEx.Show(Me, "Documento(s) reenviado(s) " & _Enviados, "Renvio de correos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "No fue posible reenviar ningún documento" & vbCrLf &
                              "Debe revisar la configuración del diablito de envio de correos", "Renvio de correos",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged

        If Abrir_Cerrar_Documentos_Compromiso Then
            For Each _Fila As DataRow In _Tbl_Documentos.Rows

                If Not ((_Abrir_Documentos And _Fila.Item("ESTADO") = "Vigente") Or (_Cerrar_Documentos And _Fila.Item("ESTADO") = "Cerrado")) Then
                    _Fila.Item("Chk") = Chk_Marcar_Todas.Checked
                End If

            Next
            Return
        End If

        Dim _Sin_Emial = 0

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            _Fila.Item("Chk") = Chk_Marcar_Todas.Checked

            Dim _Koen As String = _Fila.Item("ENDO")

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEENMAIL", "KOEN = '" & _Koen & "' And KOMAIL = '001'"))

            If Not _Reg Then

                _Sin_Emial += 1
                _Fila.Item("Chk") = False

            End If

        Next

        If CBool(_Sin_Emial) And Chk_Marcar_Todas.Checked Then

            MessageBoxEx.Show(Me, "Existen entidades que no tiene Email en la tabla de notificaciones por email" & vbCrLf &
                              "Para poder reenviar un correo debe actualizar los datos desde el maestro de entidades..." & vbCrLf &
                              "Ficha de la entidad -> Notificaciones vía correo" & vbCrLf & vbCrLf &
                              "Los registros con problemas no fueron marcados",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value

        If _Fila.Cells("Chk").Value Then

            If _Enviar_Correos_Masivamente Then

                Dim _Tido = _Fila.Cells("TIDO").Value
                Dim _Koen = _Fila.Cells("ENDO").Value

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEENMAIL", "KOEN = '" & _Koen & "' And KOMAIL = '001'"))

                If Not _Reg Then
                    MessageBoxEx.Show(Me, "Esta entidad no tiene Email en la tabla de notificaciones por email" & vbCrLf &
                                      "Para poder reenviar un correo debe actualizar los datos desde el maestro de entidades..." & vbCrLf &
                                      "Ficha de la entidad -> Notificaciones vía correo",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Fila.Cells("Chk").Value = False
                End If

            End If

            If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") And _Fila.Cells("TIDO").Value = "NVV" Then

                Dim _Autorizado = False

                If FUNCIONARIO = _Fila.Cells("KOFUDO").Value Then
                    _Autorizado = True
                Else
                    For Each _Fila2 As DataGridViewRow In Grilla_Detalle.Rows
                        If _Fila2.Cells("KOFULIDO").Value = FUNCIONARIO Then
                            _Autorizado = True
                            Exit For
                        End If
                    Next
                End If

                If HabilitarNVVParaFacturar Then

                    Dim _FunAutorizaFac = FUNCIONARIO

                    _Fila.Cells("FunAutoriza").Value = String.Empty

                    If Not _Autorizado Then

                        Dim _Rows_Usuario_Autoriza As DataRow

                        _Autorizado = Fx_Tiene_Permiso(Me, "Doc00082",,,,,,,,, _Rows_Usuario_Autoriza)

                        If Not _Autorizado Then
                            _Fila.Cells("Chk").Value = False
                            Return
                        End If

                        _FunAutorizaFac = _Rows_Usuario_Autoriza.Item("KOFU")

                    End If

                    _Fila.Cells("FunAutoriza").Value = _FunAutorizaFac

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Firmar_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Firmar_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Tido = _Fila.Cells("TIDO").Value
        Dim _Nro_Documento As String = Traer_Numero_Documento(_Tido)
        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Tidoelec As Integer = _Fila.Cells("TIDOELEC").Value

        If CBool(_Tidoelec) Then

            If Fx_Tiene_Permiso(Me, "Dte00001") Then

                'FIRMA ELECTRONICA 

                Dim _Firma_Bakapp As Boolean
                Dim _Firma_RunMonitor As Boolean

                Try
                    If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                        _Firma_Bakapp = True
                    Else
                        _Firma_RunMonitor = True
                    End If
                Catch ex As Exception
                    _Firma_RunMonitor = True
                End Try

                If _Firma_RunMonitor Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
                    Dim _Iddt As Integer = _Class_DTE.Fx_Dte_Genera_Documento(Me, True)

                    If CBool(_Iddt) Then
                        _Class_DTE.Fx_Dte_Firma(Me, _Iddt, True)
                    End If
                    Me.Cursor = Cursors.Default
                End If

                If _Firma_Bakapp Then
                    Sb_Firmar_Documento_HefestoBakapp(_Idmaeedo)
                End If

            End If

        Else

            MessageBoxEx.Show(Me, "Esta acción no esta permitida para este documento",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Facturar_Click(sender As Object, e As EventArgs) Handles Btn_Facturar.Click

        If Fx_Tiene_Permiso(Me, "Bkp00054") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

            Sb_Crear_Documento_Desde_Otro_Automaticamente(Me, "FCV", _Idmaeedo)

            If Not Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo) Then

                _Fila.Cells("Estado").Value = "Cerrado"
                _Fila.Cells("ESTADO").Style.ForeColor = Color.Red

            End If

        End If

    End Sub
    Private Sub Btn_Abrir_Documentos_Click(sender As Object, e As EventArgs) Handles Btn_Abrir_Documentos.Click
        If Fx_Tiene_Permiso(Me, "Doc00055") Then
            Sb_Abrir_Cerrar_Documentos()
        End If
    End Sub
    Private Sub Btn_Cerrar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar_Documentos.Click
        If Fx_Tiene_Permiso(Me, "Doc00011") Then
            Sb_Abrir_Cerrar_Documentos()
        End If
    End Sub

    Sub Sb_Habilitar_Desabilitar_Controles(_Habilitar As Boolean)

        Grilla.Enabled = _Habilitar
        Grilla_Detalle.Enabled = _Habilitar
        Chk_Marcar_Todas.Enabled = _Habilitar
        CmbCantFilas.Enabled = _Habilitar
        Btn_Cancelar.Visible = _Abrir_Cerrar_Documentos_Compromiso
        Btn_Cancelar.Enabled = Not _Habilitar
        Lbl_Status.Visible = Not _Habilitar
        Btn_Abrir_Documentos.Enabled = _Habilitar
        Btn_Cerrar_Documentos.Enabled = _Habilitar
        BtnActualizarLista.Enabled = _Habilitar

        Me.Refresh()

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        Btn_Cancelar.Enabled = False
        If MessageBoxEx.Show(Me, "¿Esta seguro de querer cancelar esta acción?", "Cancelar proceso",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Lbl_Status.Text = "Cancelando el proceso, por favor espere..."
            Barra_Progreso.Value = 0
            System.Windows.Forms.Application.DoEvents()
            Me.Refresh()
            _Cancelar = True
        Else
            Btn_Cancelar.Enabled = True
        End If

    End Sub

    Private Sub Grilla_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        If _Cabeza = "Chk" Then

            If Abrir_Cerrar_Documentos_Compromiso Then

                If (_Abrir_Documentos And _Fila.Cells("ESTADO").Value = "Vigente") Or
                    (_Cerrar_Documentos And _Fila.Cells("ESTADO").Value = "Cerrado") Then
                    e.Cancel = True
                    Beep()
                End If

            End If

        End If

    End Sub

    Sub Sb_Abrir_Cerrar_Documentos()

        Dim _Registros_Marcados = 0
        Dim _Cancelar = False

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Fila.Cells("Chk").Value Then
                _Registros_Marcados += 1
            End If

        Next

        If _Registros_Marcados = 0 Then

            MessageBoxEx.Show(Me, "No hay ningún registro seleccionado", "Cerrar documentos",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Cerrado = 0
        Dim _Contador = 1

        Sb_Habilitar_Desabilitar_Controles(False)

        Barra_Progreso.Maximum = 100
        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = True

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            If _Fila.Item("Chk") Then

                Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
                Dim _Tido As String = _Fila.Item("TIDO")
                Dim _Kofudo As String = _Fila.Item("KOFUDO")

                Dim Cerrar_Doc As New Clas_Cerrar_Documento

                Consulta_Sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo)

                Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

                Dim _Row_Maeedo = _Ds.Tables(0).Rows(0)
                Dim _Tbl_Maeddo = _Ds.Tables(1)

                Dim _Porc = _Contador / _Registros_Marcados

                If _Abrir_Documentos Then
                    Lbl_Status.Text = "Abriendo documento: " & _Row_Maeedo.Item("TIDO") & " - " & _Row_Maeedo.Item("NUDO")
                    If Cerrar_Doc.Fx_Abrir_Documento(_Idmaeedo, _Tbl_Maeddo) Then
                        _Fila.Item("ESTADO") = "Vigente"
                        _Cerrado += 1
                        _Fila.Item("Chk") = False
                    End If
                End If

                If _Cerrar_Documentos Then
                    Lbl_Status.Text = "Cerrando documento: " & _Row_Maeedo.Item("TIDO") & " - " & _Row_Maeedo.Item("NUDO")
                    If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo, _Tbl_Maeddo) Then
                        _Fila.Item("ESTADO") = "Cerrado"
                        _Cerrado += 1
                        _Fila.Item("Chk") = False
                    End If
                End If

                'Application.DoEvents()

                Barra_Progreso.Value = ((_Contador * 100) / _Registros_Marcados)
                _Contador += 1

                Lbl_Status.Text = "(" & Barra_Progreso.Value & "%) - " & Lbl_Status.Text

                If _Cancelar Then
                    Lbl_Status.Text = "Status..."
                    Barra_Progreso.Visible = Not _Cancelar
                End If

                Application.DoEvents()

                If _Cancelar Then
                    Sb_Habilitar_Desabilitar_Controles(True)
                    Lbl_Status.Text = "Status..."
                    Me.Enabled = True
                    Me.Refresh()
                    Return
                End If

            End If

        Next

        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = False
        Me.Refresh()

        If Cerrar_Documentos_Automaticamente Then
            Return
        End If

        If CBool(_Cerrado) Then
            Sb_Pintar_Grilla()
            If _Abrir_Documentos Then MessageBoxEx.Show(Me, "Documento(s) abierto(s) " & _Cerrado, "Abrir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If _Cerrar_Documentos Then MessageBoxEx.Show(Me, "Documento(s) cerrado(s) " & _Cerrado, "Cerrar documentos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sb_Habilitar_Desabilitar_Controles(True)
        End If

    End Sub

    Sub Sb_GrabarHabilitarNVVparaFacturar()

        Dim _Registros_Marcados = 0
        Dim _Cancelar = False

        For Each _Fila As DataGridViewRow In Grilla.Rows

            _Fila.Cells("Chk").Value = NuloPorNro(_Fila.Cells("Chk").Value, False)

            If _Fila.Cells("Chk").Value Then
                _Registros_Marcados += 1
            End If

        Next

        If _Registros_Marcados = 0 Then

            MessageBoxEx.Show(Me, "No hay ningún registro seleccionado", "Habilitar notas de venta para facturar.",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Habilitado = 0
        Dim _Contador = 1

        Sb_Habilitar_Desabilitar_Controles(False)

        Barra_Progreso.Maximum = 100
        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = True

        Dim _HayRegistrosSinHabilitar As Boolean

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            If _Fila.Item("Chk") Then

                Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")

                If Not Fx_RevisarFincred(_Idmaeedo, False) Then
                    If MessageBoxEx.Show(Me, "¿Desea habilitar de todas formas la nota de venta?", "Rechazado por FINCRED",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                        _Fila.Item("Chk") = False
                        _HayRegistrosSinHabilitar = True
                    End If
                End If

                If _Fila.Item("Chk") Then
                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Docu_Ent Set" &
                                   " HabilitadaFac = 1" &
                                   ",FunAutorizaFac = '" & FUNCIONARIO & "'" &
                                   ",FechaHoraAutoriza = Getdate()" & vbCrLf &
                                   "Where Idmaeedo = " & _Idmaeedo
                    If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                        _Habilitado += 1
                    End If
                End If

                Barra_Progreso.Value = ((_Contador * 100) / _Registros_Marcados)
                _Contador += 1

                Lbl_Status.Text = "(" & Barra_Progreso.Value & "%) - " & Lbl_Status.Text

                If _Cancelar Then
                    Lbl_Status.Text = "Status..."
                    Barra_Progreso.Visible = Not _Cancelar
                End If

                Application.DoEvents()

                If _Cancelar Then
                    Sb_Habilitar_Desabilitar_Controles(True)
                    Lbl_Status.Text = "Status..."
                    Me.Enabled = True
                    Me.Refresh()
                    Return
                End If

            End If

        Next

        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = False
        Me.Refresh()

        Sb_Habilitar_Desabilitar_Controles(True)

        If CBool(_Habilitado) Then
            MessageBoxEx.Show(Me, "Documento(s) habilitado(s) " & _Habilitado, "Habilitar documentos",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            If _HayRegistrosSinHabilitar Then
                Sb_Actualizar()
            Else
                Me.Close()
            End If
        End If

    End Sub


    Function Fx_RevisarFincred(_Idmaeedo As Integer, _MostrarMensaje As Boolean) As Boolean

        Dim _RowMaeedo As DataRow
        Dim _RowEntidad As DataRow

        Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _RowMaeedo = _Sql.Fx_Get_DataRow(Consulta_Sql)

        _RowEntidad = Fx_Traer_Datos_Entidad(_RowMaeedo.Item("ENDO"), _RowMaeedo.Item("SUENDO"))

        Dim _RevFincredEnt As Boolean

        If _Global_Row_Configuracion_General.Item("Fincred_Usar") Or _Global_Row_Configuracion_Estacion.Item("Fincred_Usar") Then

            _RevFincredEnt = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades",
                             "RevFincred",
                             "CodEntidad = '" & _RowEntidad.Item("KOEN") & "' And CodSucEntidad = '" & _RowEntidad.Item("SUEN") & "'",,,, True)

            '_Revisar_Fincred = _TblEncabezado.Rows(0).Item("RevFincred")
            '_RevFincredEnt = _TblEncabezado.Rows(0).Item("RevFincredEnt")
        End If

        If Not _RevFincredEnt Then
            Return True
        End If

        Consulta_Sql = "Select FResp.*,Isnull(FDoc.Autorizacion,'RECHAZADO') As CodAutorizacion" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Fincred_TramaRespuesta FResp" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Fincred_Documentos FDoc On FResp.Id = FDoc.Id_TR" & vbCrLf &
                        "Where (Idmaeedo = " & _Idmaeedo & ")"
        Dim _RowFincred As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Codigo_negacion_transaccion = 0
        Dim _Descripcion_negacion As String
        Dim _CodAutorizacion As String

        If Not IsNothing(_RowFincred) Then

            _Codigo_negacion_transaccion = _RowFincred.Item("Codigo_negacion_transaccion")
            _Descripcion_negacion = _RowFincred.Item("Descripcion_negacion")
            _CodAutorizacion = _RowFincred.Item("CodAutorizacion")

            If _Codigo_negacion_transaccion = 0 Then
                If _MostrarMensaje Then
                    MessageBoxEx.Show(Me, "Revisión de parte de FINCRED autorizada" & vbCrLf & vbCrLf &
                                      "Documento: " & _RowMaeedo.Item("NUDO") & "-" & _RowMaeedo.Item("NUDO") & vbCrLf & vbCrLf &
                                      "Código autorización: " & _CodAutorizacion & vbCrLf &
                                      "Respuesta Fincred: " & _Descripcion_negacion, "Información FINCRED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Return True
            Else
                MessageBoxEx.Show(Me, "Revisión de parte de FINCRED RECHAZADA" & vbCrLf & vbCrLf &
                                  "Documento: " & _RowMaeedo.Item("NUDO") & "-" & _RowMaeedo.Item("NUDO") & vbCrLf & vbCrLf &
                                  "Respuesta Fincred: " & _Descripcion_negacion, "Información FINCRED", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        End If

        Dim _Fincred_Respuesta As New Fincred_API.Respuesta

        _Fincred_Respuesta = Fx_Vaidar_Fincred(_Idmaeedo,
                                               _RowMaeedo.Item("TIDO"),
                                               _RowMaeedo.Item("NUDO"),
                                               _RowEntidad.Item("Rut"),
                                               _RowMaeedo.Item("VABRDO"),
                                               _RowMaeedo.Item("FE01VEDO"),
                                               _RowEntidad.Item("FOEN").ToString.Trim)

        If _Fincred_Respuesta.EsCorrecto Then

            MessageBoxEx.Show(Me, _Fincred_Respuesta.TramaRespuesta.descripcion_negacion & vbCrLf &
                                  "Código de autorización: " & _Fincred_Respuesta.TramaRespuesta.documentos(0).autorizacion,
                                  "Validación FINCRED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            If _Fincred_Respuesta.MensajeError.Contains("(500) Error interno del servidor") Then
                _Fincred_Respuesta.MensajeError += vbCrLf & "Chequee los datos del teléfono del cliente, no puede tener caracteres extraños"
            End If

            MessageBoxEx.Show(Me, "Código de autorización: RECHAZADO" & vbCrLf &
                              "Respuesta FINCRED: " & _Fincred_Respuesta.MensajeError & vbCrLf & vbCrLf &
                              "El documento debera seguir el conducto regular, se quitaran los plazos de vencimineto.",
                              "Validación FINCRED", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Consulta_Sql = "Update MAEEDO Set FE01VEDO = FEEMDO,FEULVEDO = FEEMDO,NUVEDO = 1 Where IDMAEEDO = " & _Idmaeedo
                _Sql.Ej_consulta_IDU(Consulta_Sql)

                Return False

            End If

            Return True

    End Function


    Private Sub Tiempo_Cerrar_Documentos_Automaticamente_Tick(sender As Object, e As EventArgs) Handles Tiempo_Cerrar_Documentos_Automaticamente.Tick
        Tiempo_Cerrar_Documentos_Automaticamente.Stop()
        Sb_Abrir_Cerrar_Documentos()
        Me.Close()
    End Sub

    Sub Sb_Firmar_Documento_HefestoBakapp(_Idmaeedo As Integer)

        Dim _AmbienteCertificacion As Integer = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        Dim _Filtro = "And IDMAEEDO = " & _Idmaeedo

        Consulta_Sql = My.Resources.Recursos_Dte_Hefesto.SQLQuery_Estado_de_avance_de_envios_de_DTE_vs_Trackid
        Consulta_Sql = Replace(Consulta_Sql, "#Global_BaseBk#", _Global_BaseBk)
        Consulta_Sql = Replace(Consulta_Sql, "#Filtros#", _Filtro)
        Consulta_Sql = Replace(Consulta_Sql, "And FEEMDO Between '#Fecha_Desde#' And '#Fecha_Hasta#'", "")
        Consulta_Sql = Replace(Consulta_Sql, "#AmbienteCertificacion#", _AmbienteCertificacion)
        Consulta_Sql = Replace(Consulta_Sql, "#SoloFirmadosPorBakapp#", "")

        Dim _Tbl_Informe As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If CBool(_Tbl_Informe.Rows.Count) Then

            Dim _Fila As DataRow = _Tbl_Informe.Rows(0)

            'Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
            Dim _Id_Dte As Integer = _Fila.Item("Id_Dte")
            Dim _Trackid As String = _Fila.Item("Trackid")
            Dim _Procesar As Boolean = _Fila.Item("Procesar")
            Dim _DocFirmado As Boolean = _Fila.Item("DocFirmado")
            Dim _AceptadoSII As Boolean = _Fila.Item("AceptadoSII")
            Dim _InformadoSII As Boolean = _Fila.Item("InformadoSII")
            Dim _RechazadoSII As Boolean = _Fila.Item("RechazadoSII")
            Dim _ReparoSII As Boolean = _Fila.Item("ReparoSII")
            Dim _Estado As String = _Fila.Item("Estado")
            Dim _Glosa As String = _Fila.Item("Glosa")

            If Not _DocFirmado Then

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Firmar Where Idmaeedo = " & _Idmaeedo & " And AmbienteCertificacion = " & _AmbienteCertificacion
                Dim _RowFirmar As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                If Not IsNothing(_RowFirmar) Then

                    If _RowFirmar.Item("Firmar") Then
                        MessageBoxEx.Show(Me, "El documento no fue firmado, pero quedo a la espera de ser firmado por el DTEMonitor" & vbCrLf &
                                      "Informe de esta situación al administrador del sistema para que revise que el DTEMonitor este corriendo en algún equipo",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If

            End If

            If _Procesar Then
                MessageBoxEx.Show(Me, "Este documento esta a la espera de ser procesado por el DTEMonitor" & vbCrLf &
                                  "Debe esperar a que esta situación se concrete", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If _AceptadoSII Or (_InformadoSII And _ReparoSII) Then
                MessageBoxEx.Show(Me, "Este documento ya fue enviado al SII" & vbCrLf &
                              "Respueta SII:" & vbCrLf &
                              "Estado: " & _Estado & "-" & _Glosa, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            'If _RechazadoSII Then

            'End If

            Dim _Firmar As Boolean = Not _DocFirmado

            If _DocFirmado And Not String.IsNullOrEmpty(_Trackid) Then
                MessageBoxEx.Show(Me, "Este documento esta a la espera de ser procesado por el DTEMonitor" & vbCrLf &
                                  "Debe esperar a que esta situación se concrete", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Dim _Icono As Image = My.Resources.Recursos_DTE.script_edit
            Dim _Respuesta As String

            Me.Cursor = Cursors.WaitCursor

            Try

                If _Firmar Then

                    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

                    If CBool(_Class_DTE.Fx_FirmarXHefesto()) Then
                        MessageBoxEx.Show(Me, "DOCUMENTO FIRMADO, QUEDARA A LA ESPERA DE SER ENVIADO AL SII ...", "Firmar documento",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBoxEx.Show(Me, "El documento no fue firmado, pero quedo a la espera de ser firmado por el DTEMonitor" & vbCrLf &
                                      "Informe de esta situación al administrador del sistema para que revise que el DTEMonitor este corriendo en algún equipo",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If

    End Sub

    Private Sub Btn_CopiarDocOtrEmpresa_Click(sender As Object, e As EventArgs) Handles Btn_CopiarDocOtrEmpresa.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Tido As String = _Fila.Cells("TIDO").Value
        Dim _Nudo As String = _Fila.Cells("NUDO").Value

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbOCC_Nuevas = 1"
        Dim _Tbl_DnExt As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If Not CBool(_Tbl_DnExt.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen conexiones a otras bases de datos para poder hacer esta gestión", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        For Each _Fl_Emp As DataRow In _Tbl_DnExt.Rows

            Dim _Id_Conexion = _Fl_Emp.Item("Id")

            Dim _Respuesta As New Bk_ExpotarDoc.Respuesta

            Me.Cursor = Cursors.WaitCursor

            Dim _Cl_ExportarDoc As New Bk_ExpotarDoc.Cl_ExpotarDoc
            _Respuesta = _Cl_ExportarDoc.Fx_Importar_Documento(_Idmaeedo, _Id_Conexion, True, Modalidad)

            Me.Cursor = Cursors.Default

            Dim _Msg As String

            For Each _Inf As String In _Respuesta.Mensajes
                _Msg += vbCrLf & _Inf
            Next

            Dim _Empresa = _Respuesta.RowEmpresa.Item("EMPRESA")
            Dim _Razon = _Respuesta.RowEmpresa.Item("RAZON")

            If _Respuesta.EsCorrecto Then
                MessageBoxEx.Show(Me, "Se grabo correctamente la " & _Tido & " en la empresa: " & _Empresa & " - " & _Razon & vbCrLf & _Msg, "Grabar OCC",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBoxEx.Show(Me, "Problema al grabar la " & _Tido & " en la empresa: " & _Empresa & " - " & _Razon & vbCrLf & _Msg, "Problema :(",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Next

    End Sub

    Private Sub Btn_GrabarHabilitarFacturar_Click(sender As Object, e As EventArgs) Handles Btn_GrabarHabilitarFacturar.Click
        Sb_GrabarHabilitarNVVparaFacturar()
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
End Class
