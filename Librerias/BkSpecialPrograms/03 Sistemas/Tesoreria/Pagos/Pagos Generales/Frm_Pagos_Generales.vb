Imports DevComponents.DotNetBar
Public Class Frm_Pagos_Generales

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _FechaDelServidor As DateTime
    Dim _Ds_Pago As New DataSet

    Dim _Koen As String
    Dim _Nokoen As String

    Dim _Tbl_Encabezado As DataTable
    Dim _Row_Entidad As DataRow
    Dim _Tbl_Maedpce As DataTable
    Dim _Tbl_Estado_Cuenta As DataTable

    Dim _Grabar As Boolean
    Dim _Cerrar_al_grabar As Boolean

    Dim _Modp = "$"
    Dim _Timodp = "N"
    Dim _Tamodp = 1

    Dim _Aplica_Ley_20956 As Boolean
    Dim _Row_Caja As DataRow

    Dim _Grilla_Activa As Object

    Enum Enum_Tipo_Pago
        Clientes
        Proveedores
    End Enum

    Dim _Tipo_Pago As Enum_Tipo_Pago

    Public Property Koen As String
        Get
            Return _Koen
        End Get
        Set(value As String)
            _Koen = value
        End Set
    End Property

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Cerrar_al_grabar As Boolean
        Get
            Return _Cerrar_al_grabar
        End Get
        Set(value As Boolean)
            _Cerrar_al_grabar = value
        End Set
    End Property

    Public Property Tbl_Maedpce As DataTable
        Get
            Return _Tbl_Maedpce
        End Get
        Set(value As DataTable)
            _Tbl_Maedpce = value
        End Set
    End Property

    Public Property Tbl_Estado_Cuenta As DataTable
        Get
            Return _Tbl_Estado_Cuenta
        End Get
        Set(value As DataTable)
            _Tbl_Estado_Cuenta = value
        End Set
    End Property

    Public Sub New(_Tipo_Pago As Enum_Tipo_Pago)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Encabezado, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Pagos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Estado_de_Cuentas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Consulta_sql = "SELECT TOP 1 * FROM MAEMO WHERE KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "' ORDER BY IDMAEMO DESC"
        Dim _RowMoneda_USdolar = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowMoneda_USdolar) Then
            _Tamodp = _RowMoneda_USdolar.Item("VAMO")
        Else
            _Tamodp = 1
        End If

        Consulta_sql = "Select * From TABCJ Where EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' and KOCJ = '" & ModCaja & "'"
        _Row_Caja = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnGrabar.ForeColor = Color.White
        End If

        Me._Tipo_Pago = _Tipo_Pago

        _FechaDelServidor = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

        Consulta_sql = "Select KOMO,VAMO,NOKOMO From MAEMO Where FEMO = '" & Format(_FechaDelServidor, "yyyyMMdd") & "' ORDER BY IDMAEMO "
        Dim _Tbl_Monedas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Ct = 0
        Lbl_Estatus.Text = "Indicadores: "

        For Each _Fila As DataRow In _Tbl_Monedas.Rows

            Lbl_Estatus.Text += _Fila.Item("KOMO").ToString.Trim & " " & FormatNumber(_Fila.Item("VAMO"), 2)
            _Ct += 1

            If _Ct <> _Tbl_Monedas.Rows.Count Then
                Lbl_Estatus.Text += " - "
            End If

        Next

        Me.Text = "PAGOS GENERALES " & _Tipo_Pago.ToString.ToUpper

        _Aplica_Ley_20956 = _Sql.Fx_Exite_Campo("MAEDPCE", "LEY20956")

    End Sub

    Private Sub Frm_Pagos_Generales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Sb_Traer_Entidad(_Koen, "")

        If Not String.IsNullOrEmpty(_Koen) Then Sb_Llenar_Grillas()

        Me.ActiveControl = Grilla_Encabezado

        AddHandler Grilla_Pagos.EditingControlShowing, AddressOf Grilla_EditingControlShowing
        AddHandler Grilla_Estado_de_Cuentas.EditingControlShowing, AddressOf Grilla_EditingControlShowing

    End Sub

    Sub Sb_Traer_Entidad(ByVal _Koen As String, ByVal _Suen As String)

        Chk_Fecha_Asignacion.Checked = True

        Dim _ReadOnly As Boolean

        If String.IsNullOrEmpty(_Koen) Then

            Consulta_sql = "Select '' As KOEN,'' As NOKOEN,'" & Modalidad & "' As Modalidad,'" & ModSucursal & "' As Sucursal,'" & ModCaja & "' As Caja,'" & FUNCIONARIO & "' As KOFU,'" & Nombre_funcionario_activo & "' As Funcionario"

            Grupo_Pagos.Enabled = False
            Grupo_Estado_Cta.Enabled = False
            Btn_Agregar_Pago.Enabled = False

        Else

            Consulta_sql = "Select top 1 KOEN,NOKOEN,'" & Modalidad & "' As Modalidad,'" & ModSucursal & "' As Sucursal,'" & ModCaja & "' As Caja,'" & FUNCIONARIO & "' As KOFU,'" & Nombre_funcionario_activo & "' As Funcionario" & vbCrLf &
                           "From MAEEN" & vbCrLf &
                           "Where KOEN = '" & _Koen & "'"
            _ReadOnly = True

        End If

        _Tbl_Encabezado = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Encabezado

            .DataSource = _Tbl_Encabezado

            OcultarEncabezadoGrilla(Grilla_Encabezado, True)

            Dim _DisplayIndex = 0

            .Columns("KOEN").HeaderText = "Entidad"
            .Columns("KOEN").Width = 80
            .Columns("KOEN").Visible = True
            .Columns("KOEN").ReadOnly = _ReadOnly
            .Columns("KOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Width = 300
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Modalidad").HeaderText = "Mod."
            .Columns("Modalidad").Width = 50
            .Columns("Modalidad").Visible = True
            .Columns("Modalidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").HeaderText = "Suc."
            .Columns("Sucursal").Width = 50
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Caja").HeaderText = "Caja"
            .Columns("Caja").Width = 50
            .Columns("Caja").Visible = True
            .Columns("Caja").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFU").HeaderText = "Resp."
            .Columns("KOFU").Width = 40
            .Columns("KOFU").Visible = True
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Funcionario").HeaderText = "Funcionario"
            .Columns("Funcionario").Width = 180
            .Columns("Funcionario").Visible = True
            .Columns("Funcionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With


        If String.IsNullOrEmpty(_Koen) Then
            Grilla_Encabezado.Focus()
            Grilla_Encabezado.CurrentCell = Grilla_Encabezado.Rows(0).Cells("KOEN")
        End If

    End Sub

    Sub Sb_Llenar_Grillas()

        Consulta_sql = My.Resources.Recursos_pagos.SQLQuery_Abrir_informacion_Entidad

        Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

        Consulta_sql = Replace(Consulta_sql, "#Koen#", Me._Koen)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", _Fecha)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)

        _Ds_Pago = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Pagos

            _Tbl_Maedpce = _Ds_Pago.Tables(8)

            .DataSource = _Tbl_Maedpce

            OcultarEncabezadoGrilla(Grilla_Pagos, True)

            .Columns("ID").HeaderText = "Id"
            .Columns("ID").Width = 40
            .Columns("ID").Visible = True
            .Columns("ID").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 40
            .Columns("TIDP").Visible = True
            .Columns("TIDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUCUDP").HeaderText = "Número"
            .Columns("NUCUDP").Width = 80
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDP").HeaderText = "F.Emisión"
            .Columns("FEEMDP").Width = 80
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").DefaultCellStyle.Format = "dd-MM-yyyy"
            .Columns("FEEMDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEVEDP").HeaderText = "F.venci."
            .Columns("FEVEDP").Width = 80
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DefaultCellStyle.Format = "dd-MM-yyyy"
            .Columns("FEVEDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MODP").HeaderText = "Mon"
            .Columns("MODP").Width = 20
            .Columns("MODP").Visible = True
            .Columns("MODP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VADP").HeaderText = "Monto"
            .Columns("VADP").Width = 80
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "###,#0.##"
            .Columns("VADP").Visible = True
            .Columns("VADP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VAASDP").HeaderText = "Asignado"
            .Columns("VAASDP").Width = 80
            .Columns("VAASDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAASDP").DefaultCellStyle.Format = "###,#0.##"
            .Columns("VAASDP").Visible = True
            '.Columns("VAASDP").ReadOnly = False
            .Columns("VAASDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SALDO").HeaderText = "Saldo"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").DefaultCellStyle.Format = "###,#0.##"
            .Columns("SALDO").Width = 80
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("REFANTI").HeaderText = "Referencia"
            .Columns("REFANTI").Width = 150
            .Columns("REFANTI").Visible = True
            .Columns("REFANTI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        With Grilla_Estado_de_Cuentas

            _Tbl_Estado_Cuenta = _Ds_Pago.Tables(10)

            .DataSource = _Tbl_Estado_Cuenta

            OcultarEncabezadoGrilla(Grilla_Estado_de_Cuentas, True)

            _DisplayIndex = 0

            .Columns("ID_PAGO").HeaderText = "Dp_Id"
            .Columns("ID_PAGO").Width = 40
            .Columns("ID_PAGO").Visible = True
            .Columns("ID_PAGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ID_PAGO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DP").HeaderText = "DP"
            .Columns("DP").Width = 40
            .Columns("DP").Visible = True
            .Columns("DP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDP").HeaderText = "Número"
            .Columns("NUDP").Width = 80
            .Columns("NUDP").Visible = True
            .Columns("NUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUEMDP").HeaderText = "S.Ent"
            .Columns("SUEMDP").Width = 40
            .Columns("SUEMDP").Visible = True
            .Columns("SUEMDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fevedp_Str").HeaderText = "F.venci."
            .Columns("Fevedp_Str").Width = 80
            .Columns("Fevedp_Str").Visible = True
            .Columns("Fevedp_Str").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Modp_Str").HeaderText = "Mon"
            .Columns("Modp_Str").Width = 20
            .Columns("Modp_Str").Visible = True
            .Columns("Modp_Str").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Vadp_Str").HeaderText = "Valor Doc."
            .Columns("Vadp_Str").Width = 80
            .Columns("Vadp_Str").Visible = True
            .Columns("Vadp_Str").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Vadp_Str").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Saldo_Str").HeaderText = "Saldo Ant"
            .Columns("Saldo_Str").Width = 80
            .Columns("Saldo_Str").Visible = True
            .Columns("Saldo_Str").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo_Str").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ABONO").HeaderText = "Abonado"
            .Columns("ABONO").Width = 80
            .Columns("ABONO").Visible = True
            .Columns("ABONO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ABONO").DefaultCellStyle.Format = "###,#0.##"
            .Columns("ABONO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Saldo_Act_Str").HeaderText = "Saldo Act"
            .Columns("Saldo_Act_Str").Width = 80
            .Columns("Saldo_Act_Str").Visible = True
            .Columns("Saldo_Act_Str").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo_Act_Str").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _Id = 1

        For Each _Fila As DataRow In _Tbl_Estado_Cuenta.Rows

            _Fila.Item("ID") = _Id
            _Fila.Item("ID_PADRE") = _Id
            _Id += 1

            Dim _Fevedp_Str As String = FormatDateTime(_Fila.Item("FEVEDP"), DateFormat.ShortDate).ToString
            Dim _Modp_Str As String = _Fila.Item("MODP")
            Dim _Vadp_Str As String = FormatNumber(_Fila.Item("VADP"), 0)
            Dim _Saldo_Str As String = FormatNumber(_Fila.Item("SALDO"), 0)
            Dim _Saldo_Act_Str As String = FormatNumber(_Fila.Item("SALDO_ACT"), 0)

            _Fila.Item("Fevedp_Str") = _Fevedp_Str
            _Fila.Item("Modp_Str") = _Modp_Str
            _Fila.Item("Vadp_Str") = _Vadp_Str
            _Fila.Item("Saldo_Str") = _Saldo_Str
            _Fila.Item("Saldo_Act_Str") = _Saldo_Act_Str

        Next

        _Id = 1

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            _Fila.Item("ID") = _Id

            _Id += 1

            Dim _Tidp = _Fila.Item("TIDP")
            Dim _Nudp = _Fila.Item("NUDP")
            Dim _Emdp = _Fila.Item("EMDP")
            Dim _Cudp = _Fila.Item("CUDP")
            Dim _Nucudp = _Fila.Item("NUCUDP")

            Dim _Archirsd = NuloPorNro(_Fila.Item("ARCHIRSD"), "")
            Dim _Idrsd = NuloPorNro(_Fila.Item("IDRSD"), 0)

            Dim _Nokoendp = String.Empty
            Dim _Doc_Asociado = _Sql.Fx_Trae_Dato("MAEEDO", "'Documento asociado: '+TIDO+'-'+NUDO", "IDMAEEDO = " & _Idrsd)

            If Not String.IsNullOrEmpty(_Doc_Asociado) Then
                _Doc_Asociado = Space(5) & " - (" & _Doc_Asociado & ")"
            End If

            If _Tidp = "DEP" Or _Tidp = "ATB" Then
                Consulta_sql = "Select Top 1 * From TABENDP Where TIDPEN = 'CH' And KOENDP = '" & _Emdp & "' And CTACTE = '" & _Cudp & "'"
            Else
                Consulta_sql = "Select Top 1 * From TABENDP Where TIDPEN = 'CH' And KOENDP = '" & _Emdp & "'"
            End If

            Dim _Row_Cuenta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Cuenta) Then
                _Nokoendp = _Row_Cuenta.Item("NOKOENDP").ToString.Trim
                _Fila.Item("Estatus") = "(" & _Tidp & _Nudp & ") - " & _Nokoendp & ", Cta. Cte: " & _Cudp.ToString.Trim & ", Nro: " & _Nucudp.ToString.Trim & _Doc_Asociado
            Else
                _Fila.Item("Estatus") = "(" & _Tidp & _Nudp & ")" & _Doc_Asociado
            End If

        Next

        Grilla_Encabezado.Columns("KOEN").ReadOnly = True

        Grupo_Pagos.Enabled = True
        Grupo_Estado_Cta.Enabled = True
        Btn_Agregar_Pago.Enabled = True

    End Sub

    Private Function Fx_Insertar_Linea_Pagada(_Id_Padre As Integer,
                                              _Fila_Pago As DataGridViewRow,
                                              _Fila_Pagada As DataGridViewRow) As Boolean

        Dim _Index As Integer = _Fila_Pagada.Index + 1

        Dim _Saldo As Double = _Fila_Pagada.Cells("SALDO").Value
        Dim _Abono As Double = _Fila_Pagada.Cells("ABONO").Value
        Dim _Ley20956 As Double = _Fila_Pagada.Cells("LEY20956").Value
        Dim _Saldo_Act As Double = _Saldo - _Abono + _Ley20956

        Dim _Id = _Tbl_Estado_Cuenta.Compute("MAX(ID)", "") + 1

        Dim NewFila As DataRow
        NewFila = _Tbl_Estado_Cuenta.NewRow

        With NewFila

            .Item("ID") = _Id
            .Item("ID_PADRE") = _Id_Padre

            .Item("ID_PAGO") = 0
            .Item("IDMAEDPCE") = _Fila_Pago.Cells("IDMAEDPCE").Value
            .Item("IDRST") = _Fila_Pagada.Cells("IDRST").Value
            .Item("ARCHIRST") = _Fila_Pagada.Cells("ARCHIRST").Value
            .Item("TCASIG") = _Fila_Pagada.Cells("TCASIG").Value

            .Item("EMPRESA") = ModEmpresa

            .Item("DP") = _Fila_Pagada.Cells("DP").Value
            .Item("NUDP") = _Fila_Pagada.Cells("NUDP").Value
            .Item("ENDP") = _Fila_Pagada.Cells("ENDP").Value
            .Item("EMDP") = String.Empty
            .Item("SUEMDP") = String.Empty
            .Item("CUDP") = String.Empty
            .Item("NUCUDP") = String.Empty
            .Item("FEEMDP") = FechaDelServidor()
            .Item("FEVEDP") = _Fila_Pagada.Cells("FEVEDP").Value
            .Item("MODP") = _Fila_Pagada.Cells("MODP").Value

            .Item("TIMODP") = _Fila_Pagada.Cells("TIMODP").Value
            .Item("TAMODP") = _Fila_Pagada.Cells("TAMODP").Value
            .Item("VADP") = _Fila_Pagada.Cells("VADP").Value
            .Item("VAABDP") = 0
            .Item("ABONO") = 0
            .Item("ABONO2") = 0

            .Item("SALDO") = _Saldo_Act
            .Item("SALDO_ACT") = _Saldo_Act

            .Item("Fevedp_Str") = String.Empty
            .Item("Modp_Str") = String.Empty
            .Item("Vadp_Str") = String.Empty
            .Item("Saldo_Str") = String.Empty
            .Item("Saldo_Act_Str") = FormatNumber(_Saldo_Act, 0)
            .Item("LEY20956") = 0

            _Tbl_Estado_Cuenta.Rows.InsertAt(NewFila, _Index)

        End With

    End Function

    Private Function Fx_Insertar_Linea_Pagada(_Id_Padre As Integer,
                                              _Fila_Pago As DataRow) As DataRow

        Dim _Id = _Tbl_Estado_Cuenta.Compute("MAX(ID)", "") + 1

        Dim NewFila As DataRow
        NewFila = _Tbl_Estado_Cuenta.NewRow

        With NewFila

            .Item("ID") = _Id
            .Item("ID_PADRE") = _Id_Padre

            .Item("ID_PAGO") = 0
            .Item("IDMAEDPCE") = _Fila_Pago.Item("IDMAEDPCE")
            .Item("IDRST") = 0
            .Item("ARCHIRST") = String.Empty
            .Item("TCASIG") = 0
            .Item("EMPRESA") = ModEmpresa

            .Item("DP") = String.Empty
            .Item("NUDP") = String.Empty
            .Item("ENDP") = String.Empty
            .Item("EMDP") = String.Empty
            .Item("SUEMDP") = String.Empty
            .Item("CUDP") = String.Empty
            .Item("NUCUDP") = String.Empty
            .Item("FEEMDP") = _FechaDelServidor
            .Item("FEVEDP") = _FechaDelServidor
            .Item("MODP") = _Modp

            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp
            .Item("VADP") = 0
            .Item("VAABDP") = 0
            .Item("ABONO") = 0
            .Item("ABONO2") = 0
            .Item("SALDO") = 0
            .Item("SALDO_ACT") = 0

            .Item("Fevedp_Str") = String.Empty
            .Item("Modp_Str") = String.Empty
            .Item("Vadp_Str") = String.Empty
            .Item("Saldo_Str") = String.Empty
            .Item("Saldo_Act_Str") = String.Empty
            .Item("LEY20956") = 0

            _Tbl_Estado_Cuenta.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

    Private Sub Grilla_Encabezado_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Encabezado.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla_Encabezado.Rows(0)
        Dim _Cabeza = Grilla_Encabezado.Columns(0).Name

        Dim _Koen = NuloPorNro(_Fila.Cells("KOEN").Value, "")

        Fx_Buscar_Entidad(_Koen)

    End Sub

    Function Fx_Buscar_Entidad(ByVal _Koen As String)

        Dim Fm As New Frm_BuscarEntidad_Mt(False)

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & _Koen & "'"))

        If Not _Reg Then

            Fm.Pro_Descripcion = _Koen
            Fm.ShowDialog(Me)

            If Fm.Pro_Entidad_Seleccionada Then

                _Koen = Fm.Pro_RowEntidad.Item("KOEN")
                _Nokoen = Fm.Pro_RowEntidad.Item("NOKOEN")

            Else

                _Koen = String.Empty

                Me._Koen = String.Empty
                Me._Nokoen = String.Empty

                _Tbl_Encabezado.Rows(0).Item("KOEN") = Me._Koen
                _Tbl_Encabezado.Rows(0).Item("NOKOEN") = Me._Nokoen

            End If

            Fm.Dispose()

        End If

        If Not String.IsNullOrEmpty(_Koen) Then

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
            _Row_Entidad = _Sql.Fx_Get_DataRow(Consulta_sql)

            Me._Koen = _Row_Entidad.Item("KOEN")
            Me._Nokoen = _Row_Entidad.Item("NOKOEN")

            _Tbl_Encabezado.Rows(0).Item("KOEN") = Me._Koen
            _Tbl_Encabezado.Rows(0).Item("NOKOEN") = Me._Nokoen

            Sb_Llenar_Grillas()

        End If

    End Function

    Private Sub Grilla_Estado_de_Cuentas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Estado_de_Cuentas.KeyDown

        Try

            Dim _Fila_Pago As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)
            Dim _Fila_Pagada As DataGridViewRow = Grilla_Estado_de_Cuentas.Rows(Grilla_Estado_de_Cuentas.CurrentRow.Index)
            Dim _Cabeza = Grilla_Estado_de_Cuentas.Columns(Grilla_Estado_de_Cuentas.CurrentCell.ColumnIndex).Name

            Dim _Tidp As String = _Fila_Pago.Cells("TIDP").Value

            If e.KeyValue = Keys.Enter Then

                Dim _Dp As String = _Fila_Pagada.Cells("DP").Value

                If _Dp = "DEP" Or _Dp = "ATB" Then
                    MessageBoxEx.Show(Me, "La asignación que intenta realizar no es valida" & vbCrLf &
                                      "(Transferencias bancarias o depósitos no pueden pagarse)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.SuppressKeyPress = False
                    e.Handled = True
                    Return
                End If

                If _Cabeza = "ABONO" Then

                    Dim _Id As Integer = _Fila_Pagada.Cells("ID").Value
                    Dim _Id_Padre As Integer = _Fila_Pagada.Cells("ID_PADRE").Value

                    Dim _Id2 As Integer = _Fila_Pago.Cells("ID").Value
                    Dim _Id_Pago As Integer = _Fila_Pagada.Cells("ID_PAGO").Value

                    If _Id_Pago <> 0 Then
                        If _Id2 <> _Id_Pago Then
                            Beep()
                            'e.SuppressKeyPress = True
                            e.Handled = True
                            Return
                        End If
                    End If

                    Try

                        Dim _Fila_Pagada_Next As DataGridViewRow = Grilla_Estado_de_Cuentas.Rows(Grilla_Estado_de_Cuentas.CurrentRow.Index + 1)
                        Dim _Id_Padre_Nexy = _Fila_Pagada_Next.Cells("ID_PADRE").Value

                        If _Id <> _Id_Padre Then

                            If _Id_Padre_Nexy = _Id_Padre Then
                                MessageBoxEx.Show(Me, "Debe manipular el documento que quiere pagar desde el ultimo registro que se inserto para este registro",
                                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                        End If
                    Catch ex As Exception

                    End Try

                    Grilla_Estado_de_Cuentas.Columns("ABONO").ReadOnly = False
                    'SendKeys.Send("{F2}")
                    Grilla_Estado_de_Cuentas.BeginEdit(True)

                    e.SuppressKeyPress = False
                    e.Handled = True

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_Encabezado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Encabezado.KeyDown

        Dim _Cabeza = Grilla_Encabezado.Columns(0).Name

        If e.KeyValue = Keys.Enter Then

            If _Cabeza = "KOEN" Then

                SendKeys.Send("{F2}")
                e.Handled = True
                Grilla_Encabezado.BeginEdit(True)

            End If

        End If

    End Sub

    Private Sub Grilla_Estado_de_Cuentas_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grilla_Estado_de_Cuentas.CellBeginEdit

        Try

            Dim _Fila_Pago As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)
            Dim _Fila_Pagada As DataGridViewRow = Grilla_Estado_de_Cuentas.Rows(Grilla_Estado_de_Cuentas.CurrentRow.Index)

            Dim _Saldo_DocPago01 As Double = _Fila_Pago.Cells("SALDO").Value
            Dim _Saldo_DocPagar2 As Double = _Fila_Pagada.Cells("SALDO_ACT").Value

            Dim _Tidp As String = _Fila_Pago.Cells("TIDP").Value
            Dim _Abono As Double = _Fila_Pagada.Cells("ABONO2").Value

            If Not CBool(_Abono) Then

                Dim _Ley20956 = 0

                If _Aplica_Ley_20956 Then

                    If _Tidp = "EFV" Then

                        If _Saldo_DocPago01 > 0 Then

                            _Ley20956 = Mid(_Saldo_DocPagar2, _Saldo_DocPagar2.ToString.Length, 1)

                            If _Ley20956 <= 5 Then
                                _Fila_Pagada.Cells("LEY20956").Value = _Ley20956
                                _Fila_Pagada.Cells("SALDO_ACT").Value -= _Ley20956
                                _Fila_Pagada.Cells("SALDO").Value -= _Ley20956
                            Else
                                _Ley20956 = (10 - _Ley20956) ' * -1

                                'If _Saldo_DocPago01 < _Saldo_DocPagar2 Then
                                '    _Fila_Pagada.Cells("SALDO_ACT").Value += _Ley20956
                                '    _Fila_Pagada.Cells("SALDO").Value += _Ley20956
                                'Else
                                _Fila_Pagada.Cells("SALDO_ACT").Value += _Ley20956
                                _Fila_Pagada.Cells("SALDO").Value += _Ley20956

                                'If _Saldo_DocPago01 > _Saldo_DocPagar2 Then

                                _Ley20956 = _Ley20956 * -1

                                _Fila_Pagada.Cells("LEY20956").Value = _Ley20956
                                'End If
                                'End If
                                If _Fila_Pagada.Cells("SALDO_ACT").Value = 10 Then
                                    _Saldo_DocPagar2 = _Fila_Pagada.Cells("SALDO_ACT").Value
                                End If

                            End If

                            If Not String.IsNullOrEmpty(_Fila_Pagada.Cells("Saldo_Str").Value) Then
                                _Fila_Pagada.Cells("Saldo_Str").Value = FormatNumber(_Fila_Pagada.Cells("SALDO_ACT").Value, 0)
                            End If

                            _Fila_Pagada.Cells("Saldo_Act_Str").Value = FormatNumber(_Fila_Pagada.Cells("SALDO_ACT").Value, 0)

                        End If

                    End If

                End If

                If _Saldo_DocPago01 > _Saldo_DocPagar2 Then
                    _Abono = _Saldo_DocPagar2 - _Ley20956
                Else
                    _Abono = _Saldo_DocPago01
                End If

            End If

            _Fila_Pagada.Cells("ABONO").Value = _Abono

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_Estado_de_Cuentas_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Estado_de_Cuentas.CellEndEdit
        Try

            Dim _Fila_Pago As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)
            Dim _Fila_Pagada As DataGridViewRow = Grilla_Estado_de_Cuentas.Rows(Grilla_Estado_de_Cuentas.CurrentRow.Index)

            Dim _Saldo_Act2 As Double = _Fila_Pagada.Cells("SALDO_ACT").Value
            Dim _Saldo As Double = _Fila_Pagada.Cells("SALDO").Value
            Dim _Vadp As Double = _Fila_Pagada.Cells("VADP").Value
            Dim _Abono As Double = NuloPorNro(_Fila_Pagada.Cells("ABONO").Value, 0)
            Dim _Abono2 As Double = NuloPorNro(_Fila_Pagada.Cells("ABONO2").Value, 0)
            Dim _Vaabdp As Double = _Fila_Pagada.Cells("VAABDP").Value
            Dim _Idmaedpce As Integer = _Fila_Pago.Cells("IDMAEDPCE").Value
            Dim _Id_Pago As Integer = _Fila_Pago.Cells("ID").Value

            Dim _Ley20956 As Double = NuloPorNro(_Fila_Pagada.Cells("LEY20956").Value, 0)

            Dim _Idmaedpce2 As Integer = _Fila_Pagada.Cells("IDMAEDPCE").Value

            Dim _Id = _Fila_Pagada.Cells("ID").Value
            Dim _Id_Padre = _Fila_Pagada.Cells("ID_PADRE").Value

            Dim _Saldo_Pago = _Fila_Pago.Cells("SALDO").Value

            If _Abono > _Saldo_Act2 Or _Abono > _Saldo_Pago Then
                _Fila_Pagada.Cells("ABONO").Value = _Abono2
                Return
            End If

            If _Id = _Id_Padre Then

                If _Abono > 0 Then

                    If _Id = _Id_Padre Then

                        Dim _Contador = 0

                        For Each _Fc As DataRow In _Tbl_Estado_Cuenta.Rows
                            If _Fc.Item("ID_PADRE") = _Id_Padre And _Fc.Item("ID") <> _Fc.Item("ID_PADRE") Then
                                _Contador += 1
                            End If
                        Next

                        If CBool(_Contador) Then
                            Sb_Eliminar_Filas_Doc_Pagados_Estado_de_Cuentas(_Id)
                            Return
                        End If

                    End If

                End If

            End If

            Grilla_Estado_de_Cuentas.Columns("ABONO").ReadOnly = True

            If _Saldo_Act2 < _Abono Or _Abono <= 0 Then

                If _Abono <= 0 Then

                    If _Id = _Id_Padre Then

                        Dim _Contador = 0

                        For Each _Fc As DataRow In _Tbl_Estado_Cuenta.Rows
                            If _Fc.Item("ID_PADRE") = _Id_Padre And _Fc.Item("ID") <> _Fc.Item("ID_PADRE") Then
                                _Contador += 1
                            End If
                        Next

                        If CBool(_Contador) Then

                            Sb_Eliminar_Filas_Doc_Pagados_Estado_de_Cuentas(_Id)
                            Return

                        End If

                    End If

                End If

                _Fila_Pago.Cells("SALDO").Value += _Abono2 '+ _Ley20956 ' _Vaabdp
                _Fila_Pago.Cells("VAASDP").Value -= _Abono2 '+ _Ley20956 '_Vaabdp

                If _Abono = 0 Then
                    _Fila_Pagada.Cells("SALDO").Value = _Saldo + _Ley20956
                End If

                _Fila_Pagada.Cells("ID_PAGO").Value = 0
                _Fila_Pagada.Cells("SALDO_ACT").Value = _Saldo + _Ley20956
                _Fila_Pagada.Cells("ABONO").Value = 0
                _Fila_Pagada.Cells("ABONO2").Value = 0
                _Fila_Pagada.Cells("IDMAEDPCE").Value = 0

                If Not String.IsNullOrEmpty(_Fila_Pagada.Cells("Saldo_Str").Value) Then
                    _Fila_Pagada.Cells("Saldo_Str").Value = FormatNumber(_Fila_Pagada.Cells("SALDO_ACT").Value, 0)
                End If

                _Fila_Pagada.Cells("Saldo_Act_Str").Value = FormatNumber(_Fila_Pagada.Cells("SALDO_ACT").Value, 0)

                _Fila_Pagada.Cells("LEY20956").Value = 0

                Return

            End If

            _Fila_Pago.Cells("VAASDP").Value += _Abono
            _Fila_Pago.Cells("SALDO").Value -= _Abono

            _Fila_Pagada.Cells("ABONO2").Value = _Abono
            _Fila_Pagada.Cells("ID_PAGO").Value = _Id_Pago
            _Fila_Pagada.Cells("IDMAEDPCE").Value = _Idmaedpce

            Dim _Tidp As String = _Fila_Pago.Cells("TIDP").Value

            If _Saldo_Act2 = _Abono Then

                _Fila_Pagada.Cells("SALDO_ACT").Value -= _Abono
                _Fila_Pagada.Cells("Saldo_Act_Str").Value = FormatNumber(_Fila_Pagada.Cells("SALDO_ACT").Value, 0)

            Else

                _Fila_Pagada.Cells("Saldo_Act_Str").Value = "....."
                Fx_Insertar_Linea_Pagada(_Id_Padre, _Fila_Pago, _Fila_Pagada)

            End If

            Grilla_Estado_de_Cuentas.CurrentCell = Grilla_Estado_de_Cuentas.Rows(_Fila_Pagada.Index).Cells("ABONO")

            Dim _Tbl1 As DataTable = _Tbl_Maedpce
            Dim _Tbl2 As DataTable = _Tbl_Estado_Cuenta

        Catch ex As Exception

        End Try

    End Sub

    Sub Sb_Eliminar_Filas_Doc_Pagados_Estado_de_Cuentas(_Id_Padre As Integer)

        Dim _Index_Filas As New List(Of Integer)
        Dim _Filas_Eliminadas As New List(Of DataRow)

        'Dim _Idmaedpce_List As List(Of Integer)
        'Dim _Fila_Padre As DataGridViewRow

        For Each _Fila As DataRow In _Tbl_Estado_Cuenta.Rows

            Dim _Id_F As Integer = _Fila.Item("ID")
            Dim _Id_Padre_F As Integer = _Fila.Item("ID_PADRE")
            Dim _Idmaedpce_F As Integer = _Fila.Item("IDMAEDPCE")
            Dim _Saldo_F As Double = _Fila.Item("SALDO")

            Dim _Abono As Double = _Fila.Item("ABONO")
            Dim _Abono2 As Double = _Fila.Item("ABONO2")

            If _Id_F = _Id_Padre Or _Id_Padre = _Id_Padre_F Then

                For Each _Fila_Pago As DataRow In _Tbl_Maedpce.Rows

                    Dim _Idmaedpce_Pg = _Fila_Pago.Item("IDMAEDPCE")

                    If _Idmaedpce_Pg = _Idmaedpce_F Then
                        _Fila_Pago.Item("SALDO") += _Abono2
                        _Fila_Pago.Item("VAASDP") -= _Abono2
                    End If

                Next

                If _Id_F = _Id_Padre_F Then

                    Dim _Ley20956 As Double = _Fila.Item("LEY20956")

                    _Saldo_F += _Ley20956

                    _Fila.Item("ID_PAGO") = 0
                    _Fila.Item("SALDO") = _Saldo_F
                    _Fila.Item("SALDO_ACT") = _Saldo_F
                    _Fila.Item("ABONO2") = _Abono
                    _Fila.Item("Saldo_Str") = FormatNumber(_Saldo_F, 0)
                    _Fila.Item("Saldo_Act_Str") = FormatNumber(_Saldo_F, 0)
                    _Fila.Item("LEY20956") = 0
                    If _Abono <= 0 Then _Fila.Item("IDMAEDPCE") = 0

                Else
                    _Filas_Eliminadas.Add(_Fila)
                End If

            End If

        Next

        If CBool(_Filas_Eliminadas.Count) Then

            For Each _Fila In _Filas_Eliminadas
                _Tbl_Estado_Cuenta.Rows.Remove(_Fila)
            Next

            _Tbl_Estado_Cuenta.AcceptChanges()

        End If

        Me.Refresh()

    End Sub

    Private Sub BtnActualizarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizarLista.Click

        Grilla_Pagos.DataSource = Nothing
        Grilla_Estado_de_Cuentas.DataSource = Nothing
        Sb_Traer_Entidad("", "")

    End Sub

    Sub Sb_Nueva_Linea_De_Pago()

        Dim NewFila As DataRow

        NewFila = Fx_Insertar_Linea_De_Pago(_Tbl_Maedpce)

        _Tbl_Maedpce.Rows.Add(NewFila)

        'Dim _Filas = Grilla_Pagos.RowCount

        'If _Filas > 0 Then
        '    _Filas -= 1
        'End If

    End Sub

    Function Fx_Insertar_Linea_De_Pago(ByVal _Tbl As DataTable) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow

        Dim _Id = 1
        Dim _Idmaedpce = 1

        If CBool(_Tbl_Maedpce.Rows.Count) Then
            _Id = _Tbl_Maedpce.Compute("MAX(ID)", "") + 1
            _Idmaedpce = _Tbl_Maedpce.Compute("MAX(IDMAEDPCE)", "") + 1
        End If

        Dim rnd As New Random()

        With NewFila

            .Item("Id") = _Id
            .Item("IDMAEDPCE") = _Idmaedpce 'rnd.Next(100, 10000)
            .Item("Nueva_Linea") = True
            .Item("EMPRESA") = ModEmpresa
            .Item("SUREDP") = ModSucursal
            .Item("CJREDP") = ModCaja

            .Item("TIDP") = String.Empty
            .Item("NUDP") = String.Empty

            .Item("ENDP") = _Koen ' String.Empty
            .Item("EMDP") = String.Empty   ' CODIGO EMISOR DE DOCUMENTO, BANCO, TIPO TARJETA, ETC.
            .Item("SUEMDP") = String.Empty ' ??
            .Item("CUDP") = String.Empty   ' NRO CTA. CTE.
            .Item("NUCUDP") = String.Empty ' NRO DEL CHEQUE
            .Item("FEEMDP") = _FechaDelServidor
            .Item("FEVEDP") = _FechaDelServidor

            .Item("MODP") = _Modp
            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp

            .Item("VADP") = 0
            .Item("VADP2") = 0
            .Item("VAABDP") = 0
            .Item("VAASDP") = 0
            .Item("VAASDP_ORI") = 0
            .Item("VAVUDP") = 0
            .Item("SALDO") = 0

            .Item("REFANTI") = String.Empty
            .Item("KOTU") = 1
            .Item("KOFUDP") = FUNCIONARIO
            .Item("KOTNDP") = RutEmpresa
            .Item("SUTNDP") = ModCaja

            .Item("NUTRANSMI") = String.Empty
            .Item("DOCUENANTI") = String.Empty

            .Item("ESASDP") = "P" ' ESTADO ASIGNACION DEL PAGO A = ASIGNADO A UN DOCUMENTO, P = NO ASIGNADO O PARCIALMENTE ASIGNADO, ES DECIR, 
            .Item("ESPGDP") = "P"
            .Item("CUOTAS") = 1

            .Item("ARCHIRSD") = String.Empty
            .Item("IDRSD") = 0
            .Item("Usar") = False
            .Item("LEY20956") = 0

        End With

        Return NewFila

    End Function

    Private Sub Grilla_Pagos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Pagos.CellDoubleClick

        If CBool(Grilla_Pagos.RowCount) Then
            Call Grilla_Pagos_KeyDown(Nothing, Nothing)
        Else
            Sb_Nueva_Linea_De_Pago()
            Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.RowCount - 1).Cells("TIDP")
        End If

    End Sub

    Sub Sb_Ingresar_Linea_de_pago()

        Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)
        Dim _Tidp As String
        'Dim _Tipo_Pago As Integer
        Dim _Tidp_Seleccionado As Boolean
        Dim _Row_Tidp As DataRow

        Dim _Filtro_Extra_Sql As String


        'EFV; EFECTIVO
        'CHV; CHEQUE BANCARIO
        'TJV; TARJETA DE CREDITO
        'PAV; PAGARE DE CREDITO
        'DEP; PAGO POR DEPOSITO
        'ATB; TRANSFERENCIA BANCARIA

        'ncv; PAGO CON NOTA DE CREDITO
        'nev; PAGO CON NOTA DE CREDITO EXPORTACION
        'ncx; PAGO CON NOTA DE CREDITO EXENTA
        'fcc; PAGO CON FACTURA DEL CLIENTE/PROVEEDOR
        'fdc; PAGO CON NOTA DE DEBITO DEL CLIENTE/PROVEEDOR

        'CRV; COMPROBANTE DE RETENCION VENTA
        'RIV; COMPROBANTE RETENCION IVA VENTA
        'RBV; COMPROBANTE RETENCION ING. BRUTOS VENTA
        'RGV; COMPROBANTE RETENCION GANANCIAS VENTA


        Select Case _Tipo_Pago
            Case Enum_Tipo_Pago.Clientes
                _Filtro_Extra_Sql = "And CodigoTabla In ('EFV','CHV','TJV','LTV','PAV','DEP','ATB','ncv','nev','ncx','fcc','fdc','CRV','RIV','RBV','RGV')"
                '_Filtro_Extra_Sql = "And CodigoTabla In ('EFV','CHV','TJV','DEP','ATB','ncv','CRV')"
            Case Enum_Tipo_Pago.Proveedores
                _Filtro_Extra_Sql = "And CodigoTabla In ('EFC','CHC','TJC','DEC','ATC')"
        End Select


        Dim Fm As New Frm_Pagos_Seleccion_Tipo_Pago(_Tipo_Pago)
        Fm.Pro_Filtro_Extra_Sql = _Filtro_Extra_Sql
        Fm.ShowDialog(Me)
        _Tidp_Seleccionado = Fm.Pro_Precio_Tidp_Seleccionado
        _Row_Tidp = Fm.Pro_Row_Tidp
        Fm.Dispose()

        If _Tidp_Seleccionado Then

            _Tidp = _Row_Tidp.Item("TIDP")

            If Not String.IsNullOrEmpty(_Tidp) Then

                Select Case _Tidp
                    Case "EFV", "EFC"
                        Sb_Pago_Efectivo(_Tidp)
                    Case "CHV", "TJV", "DEP", "ATB", "CRV"
                        Sb_Pago_Cheque_o_Tarjeta(_Tidp)
                    Case "ncv"
                        Sb_Pago_Nota_De_Credito()
                    Case Else
                        MessageBoxEx.Show(Me, "Condición de pago no habilitada", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Select

            End If

        End If

    End Sub

    Sub Sb_Pago_Efectivo(ByVal _Tidp As String)

        Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)

        _Fila.Cells("TIDP").Value = _Tidp
        _Fila.Cells("CUOTAS").Value = 0
        _Fila.Cells("ESPGDP").Value = "C"

        Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index).Cells("VADP")

    End Sub

    Sub Sb_Pago_Cheque_o_Tarjeta(ByVal _Tidp As String)

        Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)
        Dim _Tipo_Pago_Fx As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago  ' Enum_Tipo_Pago_Ch_Tj
        Dim _Row_Tabendp As DataRow

        Dim _Mostrar_Cuentas_Del_Cliente_Proveedor As Boolean
        Dim _Mostrar_Cuentas_De_La_Empresa As Boolean

        Dim _Koen As String = _Tbl_Encabezado.Rows(0).Item("KOEN")

        If _Tidp = "CHV" Then

            _Tipo_Pago_Fx = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CH
            _Mostrar_Cuentas_Del_Cliente_Proveedor = True

        ElseIf _Tidp = "TJV" Then

            _Tipo_Pago_Fx = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ

            Dim Fm_Emisor As New Frm_Seleccionar_Emisor_Doc_Pago(_Tipo_Pago_Fx)
            Fm_Emisor.ShowDialog(Me)
            _Row_Tabendp = Fm_Emisor.Pro_Row_Tabendp
            Fm_Emisor.Dispose()

            If IsNothing(_Row_Tabendp) Then
                Return
            End If

        ElseIf _Tidp = "DEP" Then

            _Tipo_Pago_Fx = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.DP
            _Mostrar_Cuentas_De_La_Empresa = True

        ElseIf _Tidp = "ATB" Then

            _Tipo_Pago_Fx = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.PT
            _Mostrar_Cuentas_De_La_Empresa = True

        ElseIf _Tidp = "CRV" Then

            _Tipo_Pago_Fx = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CR
            _Mostrar_Cuentas_De_La_Empresa = False

        End If

        Dim _Tipo_de_pago As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_De_Pago

        If _Tipo_Pago = Enum_Tipo_Pago.Clientes Then
            _Tipo_de_pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_De_Pago.Cliente
        ElseIf _Tipo_Pago = Enum_Tipo_Pago.Proveedores Then
            _Tipo_de_pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_De_Pago.Proveedor
        End If

        Dim Fm As New Frm_Pagos_Seleccionar_CH_TJ(_Tipo_Pago_Fx, _Row_Tabendp, _Tipo_de_pago, 0)
        Fm.Mostrar_Cuentas_De_La_Empresa = _Mostrar_Cuentas_De_La_Empresa
        Fm.Mostrar_Cuentas_Del_Cliente_Proveedor = _Mostrar_Cuentas_Del_Cliente_Proveedor
        Fm.Koen = _Koen
        Fm.Btn_Traer_Saldo.Visible = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            _Fila.Cells("EMDP").Value = Fm.Pro_Emdp
            _Fila.Cells("SUEMDP").Value = Fm.Pro_Suemdp
            _Fila.Cells("CUDP").Value = Fm.Pro_Cudp
            _Fila.Cells("NUCUDP").Value = Fm.Pro_Nucudp
            _Fila.Cells("CUOTAS").Value = Fm.Pro_Cuotas
            _Fila.Cells("VADP").Value = Fm.Pro_Monto
            _Fila.Cells("VADP2").Value = Fm.Pro_Monto
            _Fila.Cells("SALDO").Value = Fm.Pro_Monto

            _Fila.Cells("TIDP").Value = Fm.Pro_Tipd
            _Fila.Cells("ESPGDP").Value = "P"

            If _Tidp = "CRV" Then
                _Fila.Cells("ESPGDP").Value = "C"
                _Fila.Cells("SUEMDP").Value = ""
            End If

            If _Fila.Cells("CUOTAS").Value = 0 Then
                _Fila.Cells("CUOTAS").Value = 1
            End If

            If _Tidp.Contains("CH") Then
                Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index).Cells("FEVEDP")
            Else
                Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index).Cells("VADP")
            End If

        End If

    End Sub

    Sub Sb_Pago_Nota_De_Credito()

        Try

            Dim _Endo As String = _Tbl_Encabezado.Rows(0).Item("KOEN")
            Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)

            Dim _Idmaeedo_Nc As Integer '= Fx_Buscar_NVV(_Fila)

            Dim _Filtro_Idrsd As String = Generar_Filtro_IN(_Tbl_Maedpce, "", "IDRSD", True, False, "")

            Dim _Condicion_Extra = "And IDMAEEDO Not In " & _Filtro_Idrsd

            _Condicion_Extra = Replace(_Condicion_Extra, "%%,", "")

            Dim Fm As New Frm_Pagos_Trae_NCV_Vigentes_X_Cliente(_Endo, _Condicion_Extra)

            If Not CBool(Fm.Pro_Tbl_Notas_de_credito.Rows.Count) Then
                Throw New System.Exception("No existen notas de crédito a favor")
            End If

            Fm.ShowDialog(Me)
            _Idmaeedo_Nc = Fm.Idmaeedo
            Fm.Dispose()

            If CBool(_Idmaeedo_Nc) Then

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Nc
                Dim _Row_NCV As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Tido = _Row_NCV.Item("TIDO")
                Dim _Nudo = _Row_NCV.Item("NUDO")

                Dim _Koen = _Row_NCV.Item("ENDO")
                Dim _Rut = RutEmpresa
                Dim _Id = _Fila.Cells("ID").Value

                Dim _Vabrdo As Double = _Row_NCV.Item("VABRDO")
                Dim _Vaabdo As Double = _Row_NCV.Item("VAABDO")
                Dim _Saldo As Double = _Vabrdo - _Vaabdo ' VABRDO-VAABDO AS SALDO
                Dim _Vadp As Double = _Saldo

                For Each _Row As DataRow In _Tbl_Maedpce.Rows

                    Dim _Idrsd = NuloPorNro(_Row.Item("IDRSD"), 0)

                    If _Idrsd = _Idmaeedo_Nc Then
                        Throw New System.Exception("El documento ya está asociado a los pagos" & vbCrLf & vbCrLf &
                                                    "No puede asignar la nota de crédito Nro: " & _Nudo & " más de una vez")
                    End If

                Next

                _Fila.Cells("TIDP").Value = "ncv"
                _Fila.Cells("ESPGDP").Value = "C"
                _Fila.Cells("ESASDP").Value = "A"

                _Fila.Cells("ENDP").Value = _Koen
                _Fila.Cells("EMDP").Value = _Rut

                _Fila.Cells("REFANTI").Value = _Tido & "-" & _Nudo & "-" & _Koen
                _Fila.Cells("IDRSD").Value = _Idmaeedo_Nc
                _Fila.Cells("VADP").Value = _Vadp
                _Fila.Cells("SALDO").Value = _Saldo
                _Fila.Cells("CUOTAS").Value = 0

            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Function Fx_Buscar_NVV(_Fila As DataGridViewRow) As Integer

        'Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

        Dim _Endp = _Tbl_Encabezado.Rows(0).Item("KOEN") '_Fila.Cells("ENDP").Value
        'Dim _Archirsd = _Fila.Cells("ARCHIRSD").Value
        'Dim _Idrsd = _Fila.Cells("IDRSD").Value

        'If CBool(_Idrsd) Then

        '    Dim _Idmaeedo = _Idrsd

        '    Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        '    Fm.Btn_Ver_Orden_de_despacho.Visible = False
        '    Fm.ShowDialog(Me)
        '    Fm.Dispose()

        '    Return False

        'End If

        If String.IsNullOrEmpty(_Endp.ToString.Trim) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return 0
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Tbl As DataTable

        _Filtrar.Tabla = "MAEEDO"
        _Filtrar.Campo = "IDMAEEDO"
        _Filtrar.Descripcion = "TIDO+'-'+NUDO+'    '+Rtrim(LTrim(MODO))+'      '+PARSENAME(CONVERT(VARCHAR,CAST(VABRDO AS MONEY),1),2)"

        'Where ENDO = '" & _Endo & "' And TIDO = 'NCV' AND ESPGDO = 'P'

        Dim _Filtro_Idrsd As String = Generar_Filtro_IN(_Tbl_Maedpce, "", "IDRSD", True, False, "")

        Dim _Condicion = "And EMPRESA='" & ModEmpresa & "'  AND ENDO='" & _Endp & "'  AND TIDO IN ('NCV') AND ESPGDO = 'P'   
                          And IDMAEEDO Not In " & _Filtro_Idrsd

        _Filtrar.Ver_Codigo = False

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEEDO", "1 > 0 " & _Condicion)

        If _Reg = 0 Then

            MessageBoxEx.Show(Me, "No hay documentos que mostrar", "Buscar documentos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return 0

        End If

        If _Filtrar.Fx_Filtrar(_Tbl,
                           Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Condicion,
                           False, False, True) Then

            _Tbl = _Filtrar.Pro_Tbl_Filtro

            '_Fila.Cells("ARCHIRSD").Value = "MAEEDO"
            '_Fila.Cells("IDRSD").Value = _Tbl.Rows(0).Item("Codigo")
            '_Fila.Cells("Doc_Anticipo").Value = Mid(_Tbl.Rows(0).Item("Descripcion").ToString, 1, 14)

            'Dim _New_FilaPago As DataRow

            '_New_FilaPago = Fx_Insertar_Linea_De_Pago(_Tbl_Maedpce)

            '_Tbl_Maedpce.Rows.Add(_New_FilaPago)

            '_Fila.Cells("ARCHIRSD").Value = "MAEEDO"
            '_Fila.Cells("IDRSD").Value = _Tbl.Rows(0).Item("Codigo")
            '_Fila.Cells("REFANTI").Value = Mid(_Tbl.Rows(0).Item("Descripcion").ToString, 1, 14)

            Return _Tbl.Rows(0).Item("Codigo")

        End If

    End Function

    Private Sub Grilla_Pagos_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Pagos.KeyDown

        Try

            Dim _Cabeza = Grilla_Pagos.Columns(Grilla_Pagos.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)

            Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
            Dim _Tidp As String = _Fila.Cells("TIDP").Value
            Dim _Vadp As Double = NuloPorNro(_Fila.Cells("VADP").Value, 0)
            Dim _Saldo As Double = _Fila.Cells("SALDO").Value
            Dim _Nueva_Linea As Boolean = _Fila.Cells("Nueva_Linea").Value

            Dim _Tecla As Keys

            If IsNothing(sender) Then
                _Tecla = Keys.Enter
                _Cabeza = "TIDP"
            Else
                _Tecla = e.KeyValue
            End If

            Select Case _Tecla

                Case Keys.Down

                    If Not String.IsNullOrEmpty(_Tidp) Then

                        If CBool(_Vadp) Then

                            Dim _Filas As Integer = Grilla_Pagos.Rows.Count - 1

                            Dim _X_Columna As Integer = Grilla_Pagos.CurrentCellAddress.X
                            Dim _Y_Fila As Integer = Grilla_Pagos.CurrentCellAddress.Y

                            If _Filas = _Y_Fila Then

                                Sb_Nueva_Linea_De_Pago()
                                Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(_Filas + 1).Cells("TIDP")

                            End If

                        End If

                    End If

                Case Keys.Delete

                    If _Nueva_Linea Then

                        Dim _Id As Integer = _Fila.Cells("ID").Value
                        Dim _Reg As Integer = _Tbl_Estado_Cuenta.Select("ID_PAGO = " & _Id).Count

                        If CBool(_Reg) Then
                            MessageBoxEx.Show(Me, "Tiene documentos enlazados en la grilla de Estado de cuenta." & vbCrLf &
                                              "Debe quitar las asociaciones para eliminar esta fila",
                                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                        Grilla_Pagos.Rows.RemoveAt(Grilla_Pagos.CurrentRow.Index)
                        Grilla_Pagos.Refresh()

                        If Grilla_Pagos.Rows.Count = 0 Then
                            Sb_Nueva_Linea_De_Pago()
                            Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.Rows.Count - 1).Cells("TIDP")
                        End If

                    End If

                'If Grilla_Pagos.Rows.Count = 0 Then
                '    Sb_Tabla_Maedpce()
                'Else
                '    Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.Rows.Count - 1).Cells("TIDP")
                'End If

                Case Keys.Enter

                    If _Cabeza = "VADP" Then

                        If Not String.IsNullOrEmpty(_Tidp) Then

                            If _Tidp = "ncv" Then

                                Beep()
                                ToastNotification.Show(Me, "NO SE PUEDE CAMBIAR EL VALOR DE LA NOTA DE CREDITO",
                                                       My.Resources.cross,
                                                      1 * 1000, eToastGlowColor.Red,
                                                       eToastPosition.MiddleCenter)

                                Return

                            End If

                            If Not _Nueva_Linea Then

                                Beep()
                                Return

                            End If

                            Grilla_Pagos.Columns("VADP").ReadOnly = False

                            If _Vadp = 0 Then

                                Dim _Aplicar_Redondeo As Boolean
                                Dim _Ley20956 As Double
                                Dim _Monto_Saldo As Double

                                If _Aplica_Ley_20956 Then

                                    Dim _FilaPg As DataRow = _Tbl_Maedpce.Rows(_Tbl_Maedpce.Rows.Count - 1)

                                    _Aplicar_Redondeo = (_FilaPg.Item("TIDP") = "EFV")

                                    Dim _Ult_Unidad As Double = Mid(_Monto_Saldo, _Monto_Saldo.ToString.Length, 1)

                                    If _Ult_Unidad <= 5 Then
                                        _Ley20956 = _Ult_Unidad
                                        _Vadp = _Monto_Saldo - _Ley20956
                                    Else
                                        _Ley20956 = _Ult_Unidad - 10
                                        _Vadp = _Monto_Saldo + (_Ley20956 * -1)
                                    End If

                                Else

                                    _Vadp = _Monto_Saldo
                                    _Saldo = _Fila.Cells("SALDO").Value

                                End If

                                If _Tidp = "ncv" Then
                                    If _Vadp > _Saldo Then
                                        _Vadp = _Saldo
                                    End If
                                End If

                                _Fila.Cells("VADP").Value = _Vadp

                            End If

                            SendKeys.Send("{BREAK}")
                            e.Handled = True
                            Grilla_Pagos.BeginEdit(True)

                        Else

                            Beep()
                            ToastNotification.Show(Me, "DEBE INGRESAR EL TIPO DE PAGO",
                                                       My.Resources.cross,
                                                      1 * 1000, eToastGlowColor.Red,
                                                       eToastPosition.MiddleCenter)

                        End If

                    ElseIf _Cabeza = "TIDP" Then

                        If String.IsNullOrEmpty(_Tidp) Then

                            Sb_Ingresar_Linea_de_pago()

                        End If

                    ElseIf _Cabeza = "FEEMDP" Or _Cabeza = "FEVEDP" Then

                        If _Tidp <> "EFV" And _Nueva_Linea Then

                            Grilla_Pagos.Columns(_Cabeza).ReadOnly = False
                            SendKeys.Send("{F2}")
                            e.Handled = True
                            Grilla_Pagos.BeginEdit(True)

                        End If

                    End If

            End Select

        Catch ex As Exception
            'MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    Private Sub Grilla_Pagos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla_Pagos.CellBeginEdit

        Dim _Cabeza = Grilla_Pagos.Columns(Grilla_Pagos.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)

    End Sub

    Private Sub Grilla_Pagos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Pagos.CellEndEdit

        Dim _Cabeza = Grilla_Pagos.Columns(Grilla_Pagos.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)

        Dim _Vadp As Double = NuloPorNro(_Fila.Cells("VADP").Value, 0)
        Dim _Vadp2 As Double = _Fila.Cells("VADP2").Value
        Dim _Vaasdp As Double = _Fila.Cells("VAASDP").Value
        Dim _Saldo As Double = _Fila.Cells("SALDO").Value
        Dim _Tidp As String = _Fila.Cells("TIDP").Value

        Select Case _Cabeza

            Case "VADP"

                If _Aplica_Ley_20956 And _Tidp = "EFV" Then

                    Dim _Ult_Nro = Mid(_Vadp, _Vadp.ToString.Length, 1)

                    If _Ult_Nro <> 0 Then
                        _Fila.Cells("VADP").Value = 0
                        _Fila.Cells("VADP2").Value = 0
                        _Fila.Cells("SALDO").Value = 0
                        MessageBoxEx.Show(Me, "El valor del pago en efectivo debe terminar en 0, ley 20956", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If

                If _Vaasdp > _Vadp Then
                    _Fila.Cells("VADP").Value = _Vadp2
                    Return
                End If

                If _Vaasdp > 0 Then

                    _Fila.Cells("VADP2").Value = _Vadp
                    _Fila.Cells("SALDO").Value = _Vadp - _Vaasdp

                Else

                    If CBool(_Vadp) Then
                        _Fila.Cells("SALDO").Value = _Vadp
                        _Fila.Cells("VADP2").Value = _Vadp
                    Else
                        If CBool(_Vaasdp) Then
                            _Fila.Cells("VADP").Value = _Vadp2
                        End If
                        _Fila.Cells("SALDO").Value = 0
                        _Fila.Cells("VADP2").Value = 0
                    End If

                End If

            Case "FEEMDP", "FEVEDP"

                Dim _Feemdp As Date = _Fila.Cells("FEEMDP").Value
                Dim _Fevedp As Date = _Fila.Cells("FEVEDP").Value

                If Chk_Fecha_Asignacion.Checked Then
                    _Feemdp = _FechaDelServidor
                End If

                If _Fevedp < _Feemdp Then
                    Beep()
                    _Fila.Cells("FEVEDP").Value = _Feemdp
                End If

        End Select

        Grilla_Pagos.Columns(_Cabeza).ReadOnly = True

    End Sub

    Private Sub Chk_Fecha_Asignacion_MouseUp(sender As Object, e As MouseEventArgs) Handles Chk_Fecha_Asignacion.MouseUp

        If Chk_Fecha_Asignacion.Checked Then
            MessageBoxEx.Show(Me, "Asignación de pago tomará fecha actual: " & _FechaDelServidor, "Fecha asignación",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, "Asignación de pagos tomará fecha de emisión del pago", "Fecha asignación",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_Agregar_Pago_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Pago.Click

        Dim _Insertar_Fila As Boolean

        If Grilla_Pagos.Rows.Count = 0 Then
            _Insertar_Fila = True
        Else

            Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.RowCount - 1)

            If Not (String.IsNullOrEmpty(_Fila.Cells("TIDP").Value)) Then
                _Insertar_Fila = True
            Else
                Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.RowCount - 1).Cells("TIDP")
                Call Grilla_Pagos_KeyDown(Nothing, Nothing)
            End If

        End If

        If _Insertar_Fila Then
            Sb_Nueva_Linea_De_Pago()
            Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.RowCount - 1).Cells("TIDP")
            Call Grilla_Pagos_KeyDown(Nothing, Nothing)
        End If

        Grilla_Pagos.Focus()

    End Sub

    Private Sub Grilla_Pagos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla_Pagos.DataError

        Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)
        Dim _Cabeza = Grilla_Pagos.Columns(Grilla_Pagos.CurrentCell.ColumnIndex).Name

        Select Case _Cabeza

            Case "FEEMDP", "FEVEDP"

                'MessageBoxEx.Show(Me, "Fecha fuera del rango esperado", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                _Fila.Cells(_Cabeza).Value = Date.Now

        End Select

        MessageBoxEx.Show(Me, e.Exception.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        Dim _Tbl_Estado_Cuenta2 As DataTable = _Tbl_Estado_Cuenta.Copy()
        Dim _Tbl_Maedpce2 As DataTable = _Tbl_Maedpce.Copy()

        For Each _Fila As DataRow In _Tbl_Estado_Cuenta2.Rows

            Dim _Tido As String = _Fila.Item("DP")
            Dim _Nudo As String = _Fila.Item("NUDP")
            Dim _Endo As String = _Fila.Item("ENDP")
            Dim _Vadp As Double = _Fila.Item("ABONO")

            Dim _Idmaeedo_FB As Integer = _Fila.Item("IDRST")
            Dim _Id_Padre As Integer = _Fila.Item("ID_PAGO")

            If _Tido = "FCV" Or _Tido = "BLV" Then

                For Each _Fl_ncv As DataRow In _Tbl_Maedpce2.Rows

                    Dim _Tidp As String = _Fl_ncv.Item("TIDP")
                    Dim _Idmaeedo_NCV As Integer = NuloPorNro(_Fl_ncv.Item("IDRSD"), 0)

                    If _Tidp = "NCV" Or _Tidp = "ncv" Then

                        If _Fl_ncv.Item("ID") = _Id_Padre Then

                            Sb_Pagar_NCV(_Idmaeedo_FB, _Idmaeedo_NCV, _Vadp)

                        End If

                    End If

                Next

            End If

        Next

        Dim _Cta_Usar = 0

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            Dim _Tido As String = _Fila.Item("TIDP")
            Dim _Id_Pago_Padre As Integer = _Fila.Item("ID")
            Dim _Nueva_Linea As Boolean = _Fila.Item("Nueva_Linea")
            Dim _Vadp As Double = _Fila.Item("VADP")
            Dim _Saldo As Double = _Fila.Item("SALDO")
            Dim _Vavudp As Double = _Fila.Item("VAVUDP")
            Dim _Cuotas As Double = _Fila.Item("CUOTAS")

            _Fila.Item("Usar") = False

            Select Case _Tido
                Case "EFV", "CRV"
                    _Fila.Item("VAABDP") = _Vadp
                Case "TJV"
                    If CBool(_Saldo) And _Cuotas > 1 Then
                        MessageBoxEx.Show(Me, "Si la tarjeta de crédito indica pago en cuotas, entonces debe" & vbCrLf &
                                          "Distribuirse como pago completamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
            End Select

            If _Saldo = 0 And _Tido <> "ncv" Then ' Documento totalmente asignado 
                _Fila.Item("ESASDP") = "A"
            End If

            For Each _Fl_ncv As DataRow In _Tbl_Estado_Cuenta.Rows

                Dim _Id_Pago As Integer = _Fl_ncv.Item("ID_PAGO")

                If _Id_Pago = _Id_Pago_Padre Then
                    _Fila.Item("Usar") = True
                    Exit For
                End If

            Next

            If Not _Fila.Item("Usar") And _Nueva_Linea Then
                Select Case _Tido
                    Case "EFV", "CHV", "TJV", "LTV", "PAV", "DEP", "ATB", "CRV", "RIV", "RBV", "RGV"
                        If _Vadp <> 0 Then _Fila.Item("Usar") = True
                End Select
            End If

            If _Fila.Item("Usar") Then

                _Cta_Usar += 1

                If _Nueva_Linea And _Saldo > 0 Then

                    If _Tido <> "ncv" Then

                        Dim _Grabar As Boolean

                        Dim Fm As New Frm_Pagos_Generales_Saldo_NoAsig(_Tbl_Encabezado.Rows(0).Item("KOEN"), _Fila, "")
                        Fm.ShowDialog(Me)
                        _Grabar = Fm.Grabar

                        If _Grabar Then

                            _Fila.Item("VAVUDP") = Fm.Vavudp
                            _Fila.Item("IDRSD") = Fm.Idrsd
                            _Fila.Item("ARCHIRSD") = Fm.Archirsd
                            _Fila.Item("REFANTI") = Fm.Refanti

                        Else
                            Return
                        End If

                        Fm.Dispose()

                    End If

                End If

            End If

        Next


        _Tbl_Estado_Cuenta2 = _Tbl_Estado_Cuenta.Copy()
        _Tbl_Maedpce2 = _Tbl_Maedpce.Copy()

        Consulta_sql = "Select * From CONFIEST WITH (NOLOCK) Where MODALIDAD = '  '"
        Dim _Row_Confiest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cuotacomer As Boolean = _Row_Confiest.Item("CUOTACOMER")
        Dim _Cuotacanti As Integer = _Row_Confiest.Item("CUOTACANTI")

        Dim _List_No_Usar_Maedpce As New List(Of Integer)
        Dim _List_No_Usar_Est_Cta As New List(Of Integer)

        For Each _Fila As DataRow In _Tbl_Maedpce2.Rows

            Dim _Tidp As String = _Fila.Item("TIDP")
            Dim _Nudo As String = _Fila.Item("NUDP")
            Dim _Endo As String = _Fila.Item("ENDP")
            Dim _Cuotas As Double = _Fila.Item("CUOTAS")
            Dim _Vadp As Double = _Fila.Item("VADP")
            Dim _Vaasdp As Double = _Fila.Item("VAASDP")
            Dim _Nueva_Linea As Boolean = _Fila.Item("Nueva_Linea")

            Dim _Id_Padre As Integer = _Fila.Item("ID")

            If _Tidp = "TJV" And _Cuotas > 1 And _Nueva_Linea Then

                If _Cuotacomer Then

                    If _Cuotas = _Cuotacanti And _Cuotas > 1 Then

                        _List_No_Usar_Maedpce.Add(_Id_Padre)

                        Dim _Valor_Cuota As Double
                        Dim _Fevedp As Date = FormatDateTime(_Fila.Item("FEVEDP"), DateFormat.ShortDate)

                        Dim _Suma_Valores_Cuotas As Double

                        For i = 1 To _Cuotas

                            Dim _Decimal As Double = 0

                            _Valor_Cuota = _Vaasdp / _Cuotas

                            Dim _Decimales = Split(_Valor_Cuota, ",")

                            If _Decimales.Length > 1 Then

                                _Decimal = _Decimales(1)
                                _Valor_Cuota = _Decimales(0)

                                If _Valor_Cuota Mod 2 <> 0 Then  ' Pregunta si es par
                                    _Valor_Cuota = CInt(_Valor_Cuota - 1)
                                End If

                            End If

                            If i <> 1 Then

                                _Fevedp = DateAdd(DateInterval.Day, 30, _Fevedp)

                            End If

                            Dim _New_FilaPago As DataRow
                            _New_FilaPago = Fx_Insertar_Linea_De_Pago(_Tbl_Maedpce)
                            _Tbl_Maedpce.Rows.Add(_New_FilaPago)

                            Dim _New_Id_Pago = _New_FilaPago.Item("ID")

                            _New_FilaPago.Item("ESPGDP") = _Fila.Item("ESPGDP")

                            _New_FilaPago.Item("TIDP") = "TJV"
                            _New_FilaPago.Item("FEVEDP") = _Fevedp
                            _New_FilaPago.Item("ENDP") = _Fila.Item("ENDP")
                            _New_FilaPago.Item("EMDP") = _Fila.Item("EMDP")
                            _New_FilaPago.Item("CUDP") = _Fila.Item("CUDP")
                            _New_FilaPago.Item("NUCUDP") = _Fila.Item("NUCUDP")
                            _New_FilaPago.Item("CUOTAS") = i

                            _New_FilaPago.Item("REFANTI") = ""
                            _New_FilaPago.Item("ESASDP") = "A"
                            _New_FilaPago.Item("Usar") = True

                            Dim _Suma_Abonos As Double = 0

                            For Each _Fila_Pd As DataRow In _Tbl_Estado_Cuenta2.Rows

                                Dim _Id_Pago As Integer = _Fila_Pd.Item("ID_PAGO")
                                Dim _Abono As Double = _Fila_Pd.Item("ABONO")
                                Dim _Vadp_Origen As Double = _Fila.Item("VADP")
                                Dim _Asig_TJV As Double = NuloPorNro(_Fila.Item("Asig_TJV"), 0)

                                If _Id_Padre = _Id_Pago Then

                                    Dim _Abonito As Double = _Abono / _Cuotas
                                    Dim _Abonito_Arr = Split(_Abonito, ",")

                                    _Abonito = _Abonito_Arr(0)

                                    If _Abonito > 0 Then

                                        If i = _Cuotas Then

                                            _Abonito = _Fila_Pd.Item("SALDO")

                                        Else

                                            If i = 1 Then
                                                _Fila_Pd.Item("SALDO") = _Abono - _Abonito
                                            Else
                                                _Fila_Pd.Item("SALDO") = _Fila_Pd.Item("SALDO") - _Abonito
                                            End If

                                        End If

                                        Dim _New_FilaPagada As DataRow

                                        _New_FilaPagada = Fx_Insertar_Linea_Pagada(_Id_Pago, _Fila)

                                        With _New_FilaPagada

                                            .Item("ID_PAGO") = _New_Id_Pago
                                            .Item("IDRST") = _Fila_Pd.Item("IDRST")
                                            .Item("ARCHIRST") = _Fila_Pd.Item("ARCHIRST")
                                            .Item("TCASIG") = _Fila_Pd.Item("TCASIG").Value
                                            .Item("EMPRESA") = ModEmpresa

                                            .Item("DP") = _Fila_Pd.Item("DP")
                                            .Item("NUDP") = _Fila_Pd.Item("NUDP")
                                            .Item("ENDP") = _Fila_Pd.Item("ENDP")
                                            .Item("EMDP") = String.Empty
                                            .Item("SUEMDP") = String.Empty
                                            .Item("CUDP") = String.Empty
                                            .Item("NUCUDP") = String.Empty
                                            .Item("FEEMDP") = _Fila_Pd.Item("FEEMDP")
                                            .Item("FEVEDP") = _Fevedp
                                            .Item("MODP") = _Modp

                                            .Item("TIMODP") = _Timodp
                                            .Item("TAMODP") = _Tamodp

                                            .Item("ABONO2") = 0

                                            .Item("VADP") = _Abonito
                                            .Item("VAABDP") = _Abonito
                                            .Item("ABONO") = _Abonito

                                            .Item("SALDO") = 0
                                            .Item("SALDO_ACT") = 0

                                        End With

                                        _Fila.Item("Asig_TJV") = NuloPorNro(_Fila.Item("Asig_TJV"), 0) + _Abonito

                                        _Suma_Abonos += _Abonito

                                    End If

                                End If

                            Next

                            If _Vadp = _Vaasdp Then

                                _Valor_Cuota = _Suma_Abonos

                            Else

                                If i = _Cuotas Then
                                    _Valor_Cuota = _Vadp - _Suma_Valores_Cuotas
                                End If

                            End If

                            _Suma_Valores_Cuotas += _Valor_Cuota

                            _New_FilaPago.Item("VADP") = _Valor_Cuota
                            _New_FilaPago.Item("VAASDP") = _Valor_Cuota

                        Next

                    End If

                End If

            End If

        Next

        For Each _Id In _List_No_Usar_Maedpce

            For Each _Fila As DataRow In _Tbl_Maedpce.Rows

                If _Id = _Fila.Item("ID") Then
                    _Fila.Item("Usar") = False
                End If

            Next

        Next

#Region "LEY20956"

        If _Aplica_Ley_20956 Then

            For Each _Fila_Pagada_Real As DataRow In _Tbl_Estado_Cuenta.Rows

                Dim _Saldo_Act As Double = _Fila_Pagada_Real.Item("SALDO_ACT")

                If _Saldo_Act <> 0 Then
                    _Fila_Pagada_Real.Item("LEY20956") = 0
                End If

            Next

            _Tbl_Estado_Cuenta2 = _Tbl_Estado_Cuenta.Copy()
            _Tbl_Maedpce2 = _Tbl_Maedpce.Copy()

            For Each _Fila_Pagada As DataRow In _Tbl_Estado_Cuenta2.Rows

                Dim _Id_Fp As Integer = _Fila_Pagada.Item("ID")
                Dim _Id_Pago As Integer = _Fila_Pagada.Item("ID_PAGO")
                Dim _Ley20956 As Double
                Dim _Saldo_Act As Double = _Fila_Pagada.Item("SALDO_ACT")

                If _Saldo_Act <> 0 Then
                    _Fila_Pagada.Item("LEY20956") = 0
                End If

                _Ley20956 = _Fila_Pagada.Item("LEY20956")

                If CBool(_Id_Pago) And _Ley20956 <> 0 Then

                    For Each _Fila_Pago As DataRow In _Tbl_Maedpce2.Rows

                        Dim _Id As Integer = _Fila_Pago.Item("ID")
                        Dim _Tidp As String = _Fila_Pago.Item("TIDP")
                        Dim _Nueva_Linea As Boolean = _Fila_Pago.Item("Nueva_Linea")

                        If _Nueva_Linea And _Tidp = "EFV" And _Id = _Id_Pago Then

                            If _Ley20956 < 0 Then

                                For Each _Fila_Pago_Real As DataRow In _Tbl_Maedpce.Rows

                                    If _Id_Pago = _Fila_Pago_Real.Item("ID") Then

                                        _Fila_Pago_Real.Item("VAASDP") += _Ley20956
                                        _Fila_Pago_Real.Item("LEY20956") = _Ley20956

                                        For Each _Fila_Pagada_Real As DataRow In _Tbl_Estado_Cuenta.Rows

                                            If _Id_Fp = _Fila_Pagada_Real.Item("ID") Then

                                                _Fila_Pagada_Real.Item("ABONO") += _Ley20956

                                            End If

                                        Next

                                    End If

                                Next

                            Else

                                Dim _New_FilaPago As DataRow
                                _New_FilaPago = Fx_Insertar_Linea_De_Pago(_Tbl_Maedpce)
                                _Tbl_Maedpce.Rows.Add(_New_FilaPago)

                                Dim _New_Id_Pago = _New_FilaPago.Item("ID")

                                _New_FilaPago.Item("ESPGDP") = _Fila_Pago.Item("ESPGDP")

                                _New_FilaPago.Item("TIDP") = "EFV"
                                _New_FilaPago.Item("FEVEDP") = _Fila_Pago.Item("FEVEDP")
                                _New_FilaPago.Item("ENDP") = _Fila_Pago.Item("ENDP")
                                _New_FilaPago.Item("EMDP") = _Fila_Pago.Item("EMDP")
                                _New_FilaPago.Item("CUDP") = _Fila_Pago.Item("CUDP")
                                _New_FilaPago.Item("NUCUDP") = _Fila_Pago.Item("NUCUDP")
                                _New_FilaPago.Item("CUOTAS") = 0

                                _New_FilaPago.Item("REFANTI") = _Fila_Pago.Item("REFANTI")

                                _New_FilaPago.Item("VADP") = _Ley20956
                                _New_FilaPago.Item("VAASDP") = _Ley20956
                                _New_FilaPago.Item("VAABDP") = _Ley20956
                                _New_FilaPago.Item("ESASDP") = "A"
                                _New_FilaPago.Item("Usar") = True
                                _New_FilaPago.Item("LEY20956") = _Ley20956

                                Dim _New_FilaPagada As DataRow

                                _New_FilaPagada = Fx_Insertar_Linea_Pagada(_Id_Pago, _New_FilaPago)

                                With _New_FilaPagada

                                    .Item("ID_PAGO") = _New_Id_Pago
                                    .Item("IDRST") = _Fila_Pagada.Item("IDRST")
                                    .Item("ARCHIRST") = _Fila_Pagada.Item("ARCHIRST")
                                    .Item("TCASIG") = _Fila_Pagada.Item("TCASIG")
                                    .Item("EMPRESA") = ModEmpresa

                                    .Item("DP") = _Fila_Pagada.Item("DP")
                                    .Item("NUDP") = _Fila_Pagada.Item("NUDP")
                                    .Item("ENDP") = _Fila_Pagada.Item("ENDP")
                                    .Item("EMDP") = String.Empty
                                    .Item("SUEMDP") = String.Empty
                                    .Item("CUDP") = String.Empty
                                    .Item("NUCUDP") = String.Empty
                                    .Item("FEEMDP") = _Fila_Pagada.Item("FEEMDP")
                                    .Item("FEVEDP") = _Fila_Pagada.Item("FEVEDP")
                                    .Item("MODP") = _Modp

                                    .Item("TIMODP") = _Timodp
                                    .Item("TAMODP") = _Tamodp

                                    .Item("ABONO2") = 0

                                    .Item("VADP") = _Ley20956
                                    .Item("VAABDP") = _Ley20956
                                    .Item("ABONO") = _Ley20956

                                    .Item("SALDO") = 0
                                    .Item("SALDO_ACT") = 0

                                End With


                                'For Each _Fila_Pago_Real As DataRow In _Tbl_Maedpce.Rows

                                '    If _Id_Fp = _Fila_Pago_Real.Item("ID") Then

                                '        _Fila_Pago_Real.Item("LEY20956") = 0

                                '    End If

                                'Next

                            End If

                        End If

                    Next

                End If

            Next

        End If

#End Region

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            Dim _Tido = _Fila.Item("TIDP")
            Dim _Vadp As Double = _Fila.Item("VADP")
            Dim _Vaasdp As Double = _Fila.Item("VAASDP")
            Dim _Vavudp As Double = _Fila.Item("VAVUDP")
            Dim _LEY20956 As Double = _Fila.Item("LEY20956")

            If _LEY20956 < 0 Then _LEY20956 *= -1
            If _LEY20956 < 0 Then _LEY20956 = 0

            If _Tido <> "ncv" Then

                Dim _Suma_Vaasdp_Vavudp As Double = _Vaasdp + _Vavudp + _LEY20956
                Dim _Esasdp As String

                If _Vadp - _Suma_Vaasdp_Vavudp = 0 Then
                    _Esasdp = "A"
                End If

                If _Vadp - _Suma_Vaasdp_Vavudp > 0 Then
                    _Esasdp = "P"
                End If

                _Fila.Item("ESASDP") = _Esasdp

            End If

        Next

        If Not CBool(_Cta_Usar) Then

            MessageBoxEx.Show(Me, "No hay cambios que guardar", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Traer_Entidad(_Tbl_Encabezado.Rows(0).Item("KOEN"), "")
            Return

        End If

        Dim _Clas_Pagar As New Clas_Pagar

        If _Clas_Pagar.Fx_Crear_Pago_MAEDPCE_Generales(Me, _Tbl_Maedpce, _Tbl_Estado_Cuenta, Chk_Fecha_Asignacion.Checked, _FechaDelServidor, _Aplica_Ley_20956) Then

            If MessageBoxEx.Show(Me, "Pagos realizados correctamente" & vbCrLf & vbCrLf & "¿Desea imprimir compobante de pago?",
                                 "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim _ClImp As New Cl_Imprimir_CompPagoClientes(_Tbl_Encabezado.Rows(0).Item("KOEN"), ModSucursal, _Tbl_Maedpce, _Tbl_Estado_Cuenta)
                _ClImp.Fx_Imprimir_Archivo(Me, "")

            End If

            If _Cerrar_al_grabar Then
                _Grabar = True
                Me.Close()
                Return
            End If

            Grilla_Pagos.DataSource = Nothing
            Grilla_Estado_de_Cuentas.DataSource = Nothing
            Sb_Traer_Entidad("", "")

        End If

    End Sub

    Sub Sb_Pagar_NCV(_Idmaeedo_FB As Integer,
                     _Idmaeedo_Ncv As Integer,
                     _Vadp As Double)

        Dim _Clas_Pagar As New Clas_Pagar

        Dim _New_FilaPago As DataRow
        _New_FilaPago = Fx_Insertar_Linea_De_Pago(_Tbl_Maedpce)
        _Tbl_Maedpce.Rows.Add(_New_FilaPago)

        Dim _Id_Pago = _New_FilaPago.Item("ID")

        Dim _Row_Fcv_Blv As DataRow
        Dim _Row_Ncv As DataRow

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_FB
        _Row_Fcv_Blv = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Ncv
        _Row_Ncv = _Sql.Fx_Get_DataRow(Consulta_sql)

        _New_FilaPago.Item("ESPGDP") = "C"

        Dim _Rut = RutEmpresa
        Dim _Tido_FB = _Row_Fcv_Blv.Item("TIDO")
        Dim _Nudo_FB = _Row_Fcv_Blv.Item("NUDO")
        Dim _Endo_FB = _Row_Fcv_Blv.Item("ENDO")

        _New_FilaPago.Item("TIDP") = LCase(_Tido_FB)
        _New_FilaPago.Item("ENDP") = _Endo_FB
        _New_FilaPago.Item("EMDP") = _Rut

        _New_FilaPago.Item("REFANTI") = _Tido_FB & "-" & _Nudo_FB & "-" & _Endo_FB

        _New_FilaPago.Item("VADP") = _Vadp
        _New_FilaPago.Item("VAABDP") = _Vadp
        _New_FilaPago.Item("VAASDP") = _Vadp
        _New_FilaPago.Item("VAABDP") = _Vadp
        _New_FilaPago.Item("ESASDP") = "A"

        Dim _New_FilaPagada As DataRow

        _New_FilaPagada = Fx_Insertar_Linea_Pagada(_Id_Pago, _New_FilaPago)

        Dim _Tido_Ncv As String = _Row_Ncv.Item("TIDO")
        Dim _Nudo_Ncv As String = _Row_Ncv.Item("NUDO")
        Dim _Endo_Ncv As String = _Row_Ncv.Item("ENDO")
        Dim _Tamodo As Double = _Row_Ncv.Item("TAMODO")

        With _New_FilaPagada

            .Item("ID_PAGO") = _Id_Pago
            '.Item("IDMAEDPCE") = _Fila_Pago.Item("IDMAEDPCE")
            .Item("IDRST") = _Idmaeedo_Ncv
            .Item("ARCHIRST") = "MAEEDO"
            .Item("TCASIG") = _Tamodo
            .Item("EMPRESA") = ModEmpresa

            .Item("DP") = _Tido_Ncv
            .Item("NUDP") = _Nudo_Ncv
            .Item("ENDP") = _Endo_Ncv
            .Item("EMDP") = String.Empty
            .Item("SUEMDP") = String.Empty
            .Item("CUDP") = String.Empty
            .Item("NUCUDP") = String.Empty
            .Item("FEEMDP") = _FechaDelServidor
            .Item("FEVEDP") = _FechaDelServidor
            .Item("MODP") = _Modp

            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp
            .Item("VADP") = _Vadp
            .Item("VAABDP") = _Vadp
            .Item("ABONO") = _Vadp
            .Item("ABONO2") = 0
            .Item("SALDO") = 0
            .Item("SALDO_ACT") = 0

        End With

    End Sub

    Private Sub Grilla_Estado_de_Cuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Estado_de_Cuentas.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Estado_de_Cuentas.Rows(Grilla_Estado_de_Cuentas.CurrentRow.Index)
        Dim _Cabeza = Grilla_Estado_de_Cuentas.Columns(Grilla_Estado_de_Cuentas.CurrentCell.ColumnIndex).Name

        If _Cabeza = "DP" Or _Cabeza = "NUDP" Then

            Dim _Idrst = _Fila.Cells("IDRST").Value
            Dim _Archirst = _Fila.Cells("ARCHIRST").Value

            If CBool(_Idrst) Then

                If _Archirst = "MAEEDO" Then

                    Dim _Idmaeedo = _Idrst

                    Dim Fm_D As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                    Fm_D.Btn_Ver_Orden_de_despacho.Visible = False
                    Fm_D.ShowDialog(Me)
                    Fm_D.Dispose()

                End If

                If _Archirst = "MAEDPCE" Then

                    Dim _Idmaedpce = _Idrst

                    Dim Fm_P As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
                    Fm_P.ShowDialog(Me)
                    Fm_P.Dispose()

                End If

            End If

        End If

    End Sub

    Private Sub Grilla_Pagos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Pagos.CellClick

        If Not CBool(Grilla_Pagos.RowCount) Then
            Sb_Nueva_Linea_De_Pago()
            Grilla_Pagos.CurrentCell = Grilla_Pagos.Rows(Grilla_Pagos.RowCount - 1).Cells("TIDP")
        End If

    End Sub

    Private Sub Grilla_Pagos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Pagos.CellEnter

        Lbl_Banco_Cta_Cte.Text = String.Empty

        Try

            Dim _Fila As DataGridViewRow = Grilla_Pagos.Rows(Grilla_Pagos.CurrentRow.Index)

            Dim _Nueva_Linea As Boolean = _Fila.Cells("Nueva_Linea").Value

            If _Nueva_Linea Then
                Lbl_Banco_Cta_Cte.Text = "Nueva línea..."
            Else
                Dim _Estatus As String = _Fila.Cells("Estatus").Value
                Lbl_Banco_Cta_Cte.Text = _Estatus
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim validar As TextBox = CType(e.Control, TextBox)
        _Grilla_Activa = sender
        AddHandler validar.KeyPress, AddressOf Sb_Validar_Keypress
    End Sub

    Private Sub Sb_Validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna

        Dim _Columna As Integer = _Grilla_Activa.CurrentCellAddress.X 'Current.ColumnIndex
        Dim _Fila As Integer = _Grilla_Activa.CurrentCellAddress.Y 'Current.ColumnIndex

        Dim _Cabeza = _Grilla_Activa.Columns(_Columna).Name

        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        If _Cabeza = "VADP" Or _Cabeza = "ABONO" Then

            ' Obtener caracter  
            Dim _Caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim _Txt As TextBox = CType(sender, TextBox)

            If e.KeyChar = "."c Then
                ' si se pulsa la coma se convertirá en punto
                'e.Handled = True
                SendKeys.Send(",")
                e.KeyChar = ","c
                _Caracter = ","
            End If

            Dim _Caracter_Raro = ChrW(Keys.Back)
            Dim _EsNumero As Boolean = Char.IsNumber(_Caracter)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(_Caracter)) Or
               (_Caracter = ChrW(Keys.Back)) Or
               (_Caracter = ",") And
               (_Txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        End If

    End Sub

    Private Sub Btn_BuscarDocumento_Click(sender As Object, e As EventArgs) Handles Btn_BuscarDocumento.Click

        If Not CBool(Grilla_Estado_de_Cuentas.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen datos que buscar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _NroDocumento As String
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el numero de documento a buscar...", "Buscar documento", _NroDocumento, False, , 10, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

        If Not _Aceptar Then
            Return
        End If

        _NroDocumento = numero_(_NroDocumento, 10)

        Dim resultado() As DataRow
        resultado = _Tbl_Estado_Cuenta.Select("NUDP = '" & _NroDocumento & "'")

        If resultado.Length > 0 Then
            BuscarDatoEnGrilla(_NroDocumento, "NUDP", Grilla_Estado_de_Cuentas)
        Else
            MessageBoxEx.Show(Me, "Documento no encontrado", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_BuscarDocumento_Click(Nothing, Nothing)
        End If

    End Sub

End Class
