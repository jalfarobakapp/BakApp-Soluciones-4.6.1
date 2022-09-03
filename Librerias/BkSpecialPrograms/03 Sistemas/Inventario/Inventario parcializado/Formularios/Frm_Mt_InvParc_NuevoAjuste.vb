Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_Mt_InvParc_NuevoAjuste

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowBodega As DataRow
    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _Nuevo_Inventario_Creado As Boolean

    Public ReadOnly Property Pro_Inventario_Creado() As Boolean
        Get
            Return _Nuevo_Inventario_Creado
        End Get
    End Property

    Public Sub New(ByVal RowBodega As DataRow)

        ' Llamada necesaria para el Dise�ador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicializaci�n despu�s de la llamada a InitializeComponent().
        DtFechaInv.Value = Date.Now
        _RowBodega = RowBodega

    End Sub

    Private Sub Frm_Mt_InvParc_NuevoAjuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Empresa = _RowBodega.Item("EMPRESA")
        _Sucursal = _RowBodega.Item("KOSU")
        _Bodega = _RowBodega.Item("KOBO")

        LblEmpresa.Text = Trim(_RowBodega.Item("RAZON"))
        LblSucursal.Text = Trim(_RowBodega.Item("NOKOSU"))
        LblBodega.Text = Trim(_RowBodega.Item("NOKOBO"))

        TxtNombreAjuste.Text = "AJUSTE PARCIALIZADO (" & FormatDateTime(DtFechaInv.Value, DateFormat.LongDate) & ")"

        AddHandler DtFechaInv.ValueChanged, AddressOf DtFechaInv_ValueChanged

    End Sub

    Private Sub BtnLimpiarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiarCodigo.Click

        If String.IsNullOrEmpty(Trim(TxtNombreAjuste.Text)) Then
            MessageBoxEx.Show(Me, "Debe ingresar un nombre para los ajustes", "Validaci�n", MessageBoxButtons.OK,
            MessageBoxIcon.Stop)
            TxtNombreAjuste.Focus()
            Return
        End If

        Dim Ano As String = numero_(DtFechaInv.Value.Year, 4)
        Dim Mes As String = numero_(DtFechaInv.Value.Month, 2)
        Dim Dia As String = numero_(DtFechaInv.Value.Day, 2)

        Dim Registros As Integer =
        _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios",
                           "Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal &
                           "' and Bodega = '" & _Bodega & "' And Fecha = '" & Format(DtFechaInv.Value, "yyyyMMdd") & "'")

        If CBool(Registros) Then
            MessageBoxEx.Show(Me, "Ya existe archivo de ajuste con la fecha indicada",
                              "Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _NombreAJ As String = UCase(TxtNombreAjuste.Text)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios (Ano, Mes, Dia, Fecha, Empresa, Sucursal," &
                       "Bodega, Nombre_Ajuste, Funcionario, Estado) Values" & vbCrLf &
                       "('" & Ano & "','" & Mes & "','" & Dia & "','" & Format(DtFechaInv.Value, "yyyyMMdd") &
                       "','" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _NombreAJ &
                       "','" & FUNCIONARIO & "',1)"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Fecha de ajuste incorporada correctamente", "Datos guardados correctamente",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Nuevo_Inventario_Creado = True
            Me.Close()

        End If

    End Sub

    Private Sub Frm_Mt_InvParc_NuevoAjuste_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Cambiar_Fecha_Ajuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Fecha_Ajuste.Click
        If Fx_Tiene_Permiso(Me, "In0016") Then
            DtFechaInv.Enabled = True
            Btn_Cambiar_Fecha_Ajuste.Enabled = False
        End If
    End Sub

    Private Sub Btn_Cambiar_Nombre_Ajuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Nombre_Ajuste.Click
        If Fx_Tiene_Permiso(Me, "In0017") Then
            TxtNombreAjuste.Enabled = True
            Btn_Cambiar_Nombre_Ajuste.Enabled = False
            TxtNombreAjuste.Focus()
        End If
    End Sub

    
    Private Sub DtFechaInv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtNombreAjuste.Text = "AJUSTE PARCIALIZADO (" & FormatDateTime(DtFechaInv.Value, DateFormat.LongDate) & ")"
    End Sub

End Class