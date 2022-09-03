'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Schedule
Imports DevComponents.Schedule.Model
Imports DevComponents.DotNetBar.Rendering

Public Class Frm_Imprimir_Cierres_Transbank

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _NombreEquipo As String
    Dim _Tipo_Cierre As _Enum_Tipo_Cierre
    Dim _Row_Estacion_CashDro As DataRow

    Enum _Enum_Tipo_Cierre
        Efectivo
        Transbank
        Nota_de_credito
        Todos
    End Enum

    Public Sub New(ByVal NombreEquipo As String, ByVal Tipo_Cierre As _Enum_Tipo_Cierre)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _NombreEquipo = NombreEquipo
        _Tipo_Cierre = Tipo_Cierre

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_Estacion_CashDro = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Imprimir_Cierres_Transbank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Tipo As String

        Select Case _Tipo_Cierre
            Case _Enum_Tipo_Cierre.Efectivo
                _Tipo = "(PAGOS EN EFECTIVO)"
            Case _Enum_Tipo_Cierre.Nota_de_credito
                _Tipo = "(PAGOS CON NOTA DE CREDITO)"
            Case _Enum_Tipo_Cierre.Transbank
                _Tipo = "(PAGOS CON REDCOMPRA - TRANSBANK)"
            Case _Enum_Tipo_Cierre.Todos
                _Tipo = "(TODOS LOS MEDIOS DE PAGO)"
        End Select

        Me.Text = "IMPRESION DE VOCHER DE TERMINAL " & Trim(_NombreEquipo) & Space(2) & _Tipo

        AddHandler Btn_Imprimir_Cierre.Click, AddressOf Sb_Imprimir_Cierre
        AddHandler Btn_Exportar_Excel.Click, AddressOf Sb_Exportar_Excel
        AddHandler Btn_Mnu_Imprimir_Cierre.Click, AddressOf Sb_Imprimir_Cierre
        AddHandler Btn_Mnu_Exportar_Excel.Click, AddressOf Sb_Exportar_Excel

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Calendario_Mes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendario_Mes.ItemClick
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Sub Sb_Imprimir_Cierre()

        Dim _Impresora_Predeterminada = _Row_Estacion_CashDro.Item("Impresora_Predeterminada")

        Dim _Este_Nombre_Equipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _NombreEquipo <> _Este_Nombre_Equipo Then
            _Impresora_Predeterminada = String.Empty
        End If

        Dim _Fecha_Cierre As Date = Calendario_Mes.DateSelectionStart.GetValueOrDefault()

        Consulta_sql = "Declare @Fecha as date = '" & Format(_Fecha_Cierre, "yyyyMMdd") & "'" & vbCrLf &
                       "Select Top 1 *" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_CashDro_Transbank_Cierre" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "' And Fecha_Hora_Cierre >= @Fecha And Fecha_Hora_Cierre < DATEADD(dd,1,@Fecha)" & vbCrLf &
                       "Order By Fecha_Hora_Cierre Desc"
        Dim _Row_Cierre As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Cierre) Then

            Dim _IdCierre As Integer = _Row_Cierre.Item("Id")
            Dim _Cl_Voucher As New Clas_Imprimir_Voucher
            _Cl_Voucher.Pro_Impresora = _Impresora_Predeterminada
            _Cl_Voucher.Fx_Imprimir_Voucher_Cierre(Me, _IdCierre)
            _Impresora_Predeterminada = _Cl_Voucher.Pro_Impresora

        Else

            MessageBoxEx.Show(Me, "No se encontro cierre de caja", "Sin Cierre", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        Dim _Imp_Cierre As New Clas_Imprimir_Cierre(_NombreEquipo, _Fecha_Cierre)

        If _Imp_Cierre.Pro_Tbl_Detalle_Terminal.Rows.Count Then
            _Imp_Cierre.Fx_Imprimir_Archivo(Me, "Detalle Terminal " & FormatDateTime(_Fecha_Cierre, DateFormat.ShortDate),
                                            _Impresora_Predeterminada, Clas_Imprimir_Cierre._Enum_Tipo_Impresion.Detalle_Terminal)
        End If

    End Sub

    Sub Sb_Exportar_Excel()

        Dim _Fecha_Cierre As Date = Calendario_Mes.DateSelectionStart.GetValueOrDefault()
        Dim _FechaCierre = Format(_Fecha_Cierre, "yyyyMMdd")

        Consulta_sql = "Declare @Fecha as date = '" & _FechaCierre & "'" & vbCrLf &
                      "SELECT * Into #Paso1" & vbCrLf &
                      "FROM BAKAPP_SIERRALTA.dbo.Zw_CashDro_Operaciones" & vbCrLf &
                      "WHERE posid = '" & _NombreEquipo & "' And Pagado_Transbank = 1 And" & Space(1) &
                      "FechaHora_Inicio >= @Fecha And FechaHora_Inicio < DATEADD(dd,1,@Fecha)" & vbCrLf &
                      "ORDER BY Id DESC" & vbCrLf &
                      "--Select Sum(Monto) As Total From #Paso1" & vbCrLf &
                      "Select * From #Paso1 Order By FechaHora_Inicio" & vbCrLf &
                      "Drop table #Paso1"
        Dim _Tbl_Detalle_Terminal = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl_Detalle_Terminal, Me, "Detalle Transbank " & Format(_Fecha_Cierre, "dd_MM_yyyy"))

    End Sub

    Private Sub Btn_Imprimir_Vouchers_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Vouchers.Click

        Dim _Fecha_Cierre As Date = Calendario_Mes.DateSelectionStart.GetValueOrDefault()

        Dim _Impresora_Predeterminada = _Row_Estacion_CashDro.Item("Impresora_Predeterminada")

        Dim _Este_Nombre_Equipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _NombreEquipo <> _Este_Nombre_Equipo Then
            _Impresora_Predeterminada = String.Empty
        End If

        Consulta_sql = "Declare @Fecha as date = '" & Format(_Fecha_Cierre, "yyyyMMdd") & "'" & vbCrLf &
                       "SELECT Z1.*,Isnull(Log_Datos_Ultima_Venta_Transbank ,'') As Log_Datos_Ultima_Venta_Transbank" & vbCrLf &
                       "Into #Paso1" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_CashDro_Operaciones Z1" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Z2 On Z2.Idmaeedo_Referencia = Z1.Idmaeedo" & vbCrLf &
                       "WHERE posid = '" & _NombreEquipo & "' And Pagado_Transbank = 1 And" & Space(1) &
                       "FechaHora_Inicio >= @Fecha And FechaHora_Inicio < DATEADD(dd,1,@Fecha)" & vbCrLf &
                       "ORDER BY Z1.Id DESC" & vbCrLf &
                        vbCrLf &
                       "Select * From #Paso1" & vbCrLf &
                       "Drop table #Paso1"
        Dim _Tbl_Detalle_Terminal = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Detalle_Terminal.Rows.Count) Then
            Dim _Cl_Voucher As New Clas_Imprimir_Voucher
            _Cl_Voucher.Pro_Impresora = _Impresora_Predeterminada
            For Each _Fila As DataRow In _Tbl_Detalle_Terminal.Rows
                Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
                _Cl_Voucher.Fx_Imprimir_Voucher(Me, _Idmaeedo, _Impresora_Predeterminada)
                _Impresora_Predeterminada = _Cl_Voucher.Pro_Impresora
            Next
        End If

    End Sub

End Class
