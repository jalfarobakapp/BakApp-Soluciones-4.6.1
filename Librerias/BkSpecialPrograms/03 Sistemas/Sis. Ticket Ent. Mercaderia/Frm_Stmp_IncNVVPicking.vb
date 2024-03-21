Imports DevComponents.DotNetBar

Public Class Frm_Stmp_IncNVVPicking

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _Ds As DataSet
    'Dim _Dv As New DataView

    Dim _Tbl_Documentos As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Stmp_IncNVVPicking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_FechaParaFacturacion.Value = FechaDelServidor()

        Input_Monto_Max_CRV_FacMasiva.Value = _Global_Row_Configuracion_General.Item("Monto_Max_CRV_FacMasiva")
        Input_Monto_Max_CRV_FacMasiva.Visible = False
        Chk_Pagar_Saldos_CRV.Visible = False

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint


        Dim _Arr_Tipo_Entidad(,) As String = {{"", "Todas"},
                                             {"Contado", "Contado"},
                                             {"Credito", "Crédito"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, ComboBoxEx1)
        ComboBoxEx1.SelectedValue = ""

        Dtp_BuscaXFechaEmision.Value = #1/1/0001 12:00:00 AM#
        Dtp_BuscaXFechaDespacho.Value = #1/1/0001 12:00:00 AM#

        Sb_Actualizar_Grilla()

        'Circular_Progres_Run.IsRunning = True

        Sb_Color_Botones_Barra(Bar1)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Me.ActiveControl = Txt_BuscaXNudoNVV

    End Sub

    Public Sub Sb_Actualizar_Grilla()

        Dtp_BuscaXFechaDespacho.Value = FechaDelServidor()

        Consulta_sql = "Select Cast(0 As Bit) As Pickear,Cast(0 As Bit) As Facturar,Edo.IDMAEEDO,TIDO,Edo.NUDO," & vbCrLf &
                       "Cast(ENDO As Varchar(10)) As ENDO,Cast(SUENDO As Varchar(10)) As SUENDO," & vbCrLf &
                       "Cast('' As Varchar(15)) As Rut,NOKOEN,SUDO,FEEMDO,FEER,FE01VEDO,FEULVEDO," & vbCrLf &
                       "Case When FEEMDO < FE01VEDO Then 'Credito' Else 'Contado' End As TipoVenta," & vbCrLf &
                       "CONVERT(NVARCHAR, CONVERT(datetime, (Edo.HORAGRAB*1.0/3600)/24), 108) AS HORA,VANEDO," & vbCrLf &
                       "VAIVDO,VAIMDO,VABRDO,VAABDO,KOFUDO,NOKOFU," & vbCrLf &
                       "Cast(0 As Bit) As Facturado,Cast(0 As Int) As IDMAEEDO_FCV,Cast('' As Varchar(10)) As NUDO_FCV," & vbCrLf &
                       "FEEMDO AS Fecha_Emision,Edo.FEER AS Fecha_Despacho,Cast(0 As Float) As VABRDO_FCV,Cast(0 As Float) As VAABDO_FCV," & vbCrLf &
                       "Cast(0 As Bit) As FCV_PAGADA,Cast(0 As Bit) As FCV_IMPRESA," & vbCrLf &
                       "Cast(0 As Int) As IDMAEDPCE,Cast(0 As Float) As VADP,Cast(0 As Float) As VAASDP," & vbCrLf &
                       "Cast(0 As Float) As SALDO,Cast(0 As Bit) As CRV, Cast(0 as Float) SALDO_CRV,Isnull(OBDO,'') As OBDO," & vbCrLf &
                       "Isnull(DocE.HabilitadaFac,1) As HabilitadaFac" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                        "From MAEEDO Edo" & vbCrLf &
                        "Left Join MAEEDOOB Obs On Obs.IDMAEEDO = Edo.IDMAEEDO" & vbCrLf &
                        "Left Join MAEEN On KOEN = ENDO And SUENDO = SUEN" & vbCrLf &
                        "Left Join TABFU On KOFU = KOFUEN" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Docu_Ent DocE On DocE.Idmaeedo = Edo.IDMAEEDO" & vbCrLf &
                        "Where 1 > 0" & vbCrLf &
                        "And Edo.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado <> 'NULO')" & vbCrLf &
                        "And Edo.FEER = '" & Format(Dtp_BuscaXFechaDespacho.Value, "yyyyMMdd") & "'" & vbCrLf &
                        "And DocE.Pickear = 1" & vbCrLf &
                        "Order By HORAGRAB" & vbCrLf &
                        "Update #Paso Set IDMAEDPCE = Isnull((Select Top 1 IDMAEDPCE From MAEDPCE Where IDRSD = IDMAEEDO),0)" & vbCrLf &
                        "Update #Paso Set VADP = Isnull((Select VADP From MAEDPCE Mp Where Mp.IDMAEDPCE = #Paso.IDMAEDPCE),0)" & vbCrLf &
                        "Update #Paso Set HORA = SUBSTRING(HORA,1,5),ENDO = Ltrim(Rtrim(ENDO)),SUENDO = Ltrim(Rtrim(SUENDO))" & vbCrLf &
                        "Update #Paso Set SALDO_CRV = VABRDO-VADP Where VADP > 0" & vbCrLf &
                        "Select * From #Paso" & vbCrLf &
                        "Order By ENDO,SUENDO,NUDO" & vbCrLf &
                        "Drop Table #Paso"

        _Tbl_Documentos = _Sql.Fx_Get_Tablas(Consulta_sql)

        '_Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        '_Dv.Table = _Ds.Tables("Table")

        With Grilla

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Pickear").HeaderText = "Pickear"
            .Columns("Pickear").Width = 50
            .Columns("Pickear").Visible = True
            .Columns("Pickear").ReadOnly = False
            .Columns("Pickear").DisplayIndex = _DisplayIndex
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
            .Columns("NUDO").Width = 70
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Facturar").HeaderText = "Facturar"
            .Columns("Facturar").Width = 60
            .Columns("Facturar").Visible = True
            .Columns("Facturar").ReadOnly = False
            .Columns("Facturar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HabilitadaFac").HeaderText = "Habilitada Facturar"
            .Columns("HabilitadaFac").ToolTipText = "Habilitada ser facturada"
            .Columns("HabilitadaFac").Width = 70
            .Columns("HabilitadaFac").Visible = True
            .Columns("HabilitadaFac").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 60
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFUDO").HeaderText = "Resp"
            .Columns("KOFUDO").Width = 35
            .Columns("KOFUDO").Visible = True
            .Columns("KOFUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Width = 40
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 190
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").HeaderText = "Monto"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VADP").Width = 70
            .Columns("VADP").HeaderText = "Abonado"
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VADP").Visible = True
            .Columns("VADP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OBDO").HeaderText = "Observaciones"
            .Columns("OBDO").Width = 200
            .Columns("OBDO").Visible = True
            .Columns("OBDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TipoVenta").HeaderText = "T.Venta"
            .Columns("TipoVenta").Width = 60
            .Columns("TipoVenta").Visible = True
            .Columns("TipoVenta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEER").HeaderText = "F.Despacho"
            .Columns("FEER").Width = 70
            .Columns("FEER").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEER").Visible = True
            .Columns("FEER").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("FEULVEDO").HeaderText = "F.Vencimiento"
            '.Columns("FEULVEDO").Width = 70
            '.Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            '.Columns("FEULVEDO").Visible = True
            '.Columns("FEULVEDO").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("HORA").HeaderText = "Hora"
            '.Columns("HORA").Width = 50
            '.Columns("HORA").Visible = True
            '.Columns("HORA").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1


        End With

        'Call Grilla_CellEnter(Nothing, Nothing)

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        If _Fila.Cells("Facturar").Value Then

            Dim _Msg = String.Empty

            If Not _Fila.Cells("HabilitadaFac").Value Then
                _Msg = "Esta nota de venta no ha sido habilitada para ser facturada"
            End If

            If Not String.IsNullOrEmpty(_Msg) Then

                _Fila.Cells("Facturar").Value = False
                MessageBoxEx.Show(Me, _Msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

        End If

    End Sub

    Private Sub Chk_PickearTodo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_PickearTodo.CheckedChanged

        For Each _Fila As DataRow In _Tbl_Documentos.Rows
            _Fila.Item("Pickear") = Chk_PickearTodo.Checked
        Next

        Return

        Dim _Marcar As Boolean
        Dim _SinHabilitar = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If Not _Fila.Cells("Facturado").Value Then

                _Marcar = True
                If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then
                    If Not _Fila.Cells("HabilitadaFac").Value Then
                        _Fila.Cells("Chk").Value = False
                        _Marcar = False
                        _SinHabilitar += 1
                    End If
                End If

                'If _Marcar Then
                '    _Fila.Cells("Chk").Value = Not Chk_Marcar_todo.Checked
                '    If _Fila.Cells("Chk").Value Then
                '        Lbl_Total_Facturar.Tag += _Fila.Cells("VABRDO").Value
                '    End If
                'End If
            End If
        Next

        If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then
            If Not Chk_PickearTodo.Checked Then
                If CBool(_SinHabilitar) Then
                    MessageBoxEx.Show(Me, "Existente " & _SinHabilitar & " documento(s) sin habilitar para ser facturado(s)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If

    End Sub

    Private Sub Chk_FacturarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_FacturarTodo.CheckedChanged

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            If Chk_FacturarTodo.Checked Then

                If Not _Fila.Item("HabilitadaFac") Then

                    MessageBoxEx.Show(Me, "Existen notas de venta que no ha sido habilitadas para ser facturadas",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Chk_FacturarTodo.Checked = False
                    Return

                End If

            End If

            _Fila.Item("Facturar") = Chk_FacturarTodo.Checked

        Next

    End Sub

    Private Sub Btn_EnviarPickear_Click(sender As Object, e As EventArgs) Handles Btn_EnviarPickear.Click

        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            Dim _Estado = _Fila.RowState

            If _Estado <> DataRowState.Deleted Then

                If _Fila.Item("Pickear") Then
                    _Contador += 1
                End If

            End If

        Next

        If _Contador = 0 Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Lista As List(Of LsValiciones.Mensajes) = Fx_Cargar_NVV_FechaDespachoHoy()

        Dim ListaQr As LsValiciones.Mensajes = _Lista.FirstOrDefault(Function(p) p.EsCorrecto = False)

        If Not IsNothing(ListaQr) Then

            MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Dim Fmv As New Frm_Validaciones
        Fmv.ListaMensajes = _Lista
        Fmv.ShowDialog(Me)
        Fmv.Dispose()

        Sb_Actualizar_Grilla()



    End Sub

    Function Fx_Cargar_NVV_FechaDespachoHoy() As List(Of LsValiciones.Mensajes)

        Dim _Lista As New List(Of LsValiciones.Mensajes)
        Dim _FechaHoy As DateTime = FechaDelServidor()

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            Dim _Mensaje_Stem As New LsValiciones.Mensajes

            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
            Dim _Pickear As Boolean = _Fila.Item("Pickear")
            Dim _Facturar As Boolean = _Fila.Item("Facturar")

            If _Pickear Then

                _Mensaje_Stem = Fx_Crear_Ticket(_Idmaeedo, _Facturar, Dtp_FechaParaFacturacion.Value, "R")

                _Lista.Add(_Mensaje_Stem)

            End If

        Next

        Return _Lista

    End Function

    Function Fx_Crear_Ticket(_Idmaeedo As Integer,
                             _Facturar As Boolean,
                             _FechaParaFacturar As DateTime,
                             _TipoPago As String) As LsValiciones.Mensajes

        Dim _FechaServidor As DateTime = FechaDelServidor()

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Idmaeedo = " & _Idmaeedo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "El documento ya esta ingresado en el sistema de Ticket Picking (Ticket Nro: " & _Row.Item("Numero") & ")"
            _Mensaje_Stem.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
            Return _Mensaje_Stem
        End If

        Consulta_sql = "Select Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,Edo.SUDO,Doc.Pickear,HabilitadaFac,FunAutorizaFac" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Docu_Ent Doc On Edo.IDMAEEDO = Doc.Idmaeedo" & vbCrLf &
                       "Where IDMAEEDO = " & _Idmaeedo
        Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Documento) Then
            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla MAEEDO, Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
            _Mensaje_Stem.Detalle = "IDMAEEDO " & _Idmaeedo
            Return _Mensaje_Stem
        End If

        If Not _Row_Documento.Item("Pickear") Then
            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "Este documento no esta marcado para ser Pickeado en la tabla Zw_Docu_Ent"
            _Mensaje_Stem.Detalle = "Documento: " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
            Return _Mensaje_Stem
        End If


        Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Row_Documento.Item("ENDO"), _Row_Documento.Item("SUENDO"))
        Dim _Cl_Stem As New Cl_Stmp

        With _Cl_Stem.Stem_Enc

            .Empresa = ModEmpresa
            .Sucursal = ModSucursal
            .Idmaeedo = _Row_Documento.Item("IDMAEEDO")
            .Tido = _Row_Documento.Item("TIDO")
            .Nudo = _Row_Documento.Item("NUDO")
            .Endo = _Row_Documento.Item("ENDO")
            .Suendo = _Row_Documento.Item("SUENDO")
            .CodFuncionario_Crea = FUNCIONARIO
            .FechaCreacion = _FechaServidor
            .Estado = "PREPA"
            .Facturar = _Facturar
            .FechaParaFacturar = _FechaParaFacturar
            .TipoPago = _TipoPago

            Try
                .Secueven = _Row_Entidad.Item("SECUEVEN")
            Catch ex As Exception
                .Secueven = String.Empty

                If _Facturar Then
                    .Secueven = "NFG"
                End If

            End Try

        End With

        Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO")
        Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Detalle.Rows

            Dim _Stem_Det As New Stmp_BD.Stmp_Det

            With _Stem_Det

                .Idmaeedo = _Fila.Item("IDMAEEDO")
                .Idmaeddo = _Fila.Item("IDMAEDDO")
                .Codigo = _Fila.Item("KOPRCT")
                .Descripcion = _Fila.Item("NOKOPR")
                .Nulido = _Fila.Item("NULIDO")
                .Udtrpr = _Fila.Item("UDTRPR")
                .Rludpr = _Fila.Item("RLUDPR")
                .Caprco1_Ori = _Fila.Item("CAPRCO1")
                .Caprco1_Real = 0
                .Udpr = _Fila.Item("UD0" & .Udtrpr & "PR")
                .Ud01pr = _Fila.Item("UD01PR")
                .Caprco2_Ori = _Fila.Item("CAPRCO2")
                .Caprco2_Real = 0
                .Ud02pr = _Fila.Item("UD02PR")
                .Pickeado = False
                .EnProceso = True

            End With

            _Cl_Stem.Stem_Det.Add(_Stem_Det)

        Next

        _Mensaje_Stem = _Cl_Stem.Fx_Grabar_Nuevo_Tickets

        Return _Mensaje_Stem

    End Function

End Class
