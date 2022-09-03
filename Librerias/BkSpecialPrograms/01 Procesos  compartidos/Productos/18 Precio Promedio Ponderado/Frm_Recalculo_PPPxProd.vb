Imports System.Globalization
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Frm_Recalculo_PPPxProd

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Producto As DataRow
    Dim _FechaTope As DateTime
    Dim _Recalculado As Boolean
    Dim _NewPPP As Double

    Dim Cl_Pm As New Cl_PPPPr

    Public Property Recalculado As Boolean
        Get
            Return _Recalculado
        End Get
        Set(value As Boolean)
            _Recalculado = value
        End Set
    End Property

    Public Property NewPPP As Double
        Get
            Return _NewPPP
        End Get
        Set(value As Double)
            _NewPPP = value
        End Set
    End Property

    Public Sub New(_Codigo As String, _FechaTope As DateTime)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._FechaTope = _FechaTope

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Producto.Text = _Row_Producto.Item("KOPR").ToString.Trim & " - " & _Row_Producto.Item("NOKOPR").ToString.Trim
        Dtp_FechaTope.Value = _FechaTope
        Btn_Cancelar.Enabled = False

    End Sub

    Private Sub Frm_Recalculo_PPPxProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tiempo.Start()
    End Sub

    Sub Sb_Recalcupar_PPP()

        'Dim _Fecha = "31/12/2021"
        'Dim _FechaTope As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)

        Dim _Codigo = _Row_Producto.Item("KOPR").ToString.Trim

        If Cl_Pm.Fx_RecalcularPPPxPR(_Codigo, _FechaTope, ProgressBarX1) Then
            _Recalculado = True
            _NewPPP = Cl_Pm.Pm
            ExportarTabla_JetExcel_Tabla(Cl_Pm.TblDetalleDocs, Me, "Historia PPP " & _Codigo)
            Me.Close()
            'MessageBoxEx.Show(Me, "PPP calculado: " & FormatCurrency(_Pm, 2), "Recalculo PM", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'ExportarTabla_JetExcel_Tabla(Cl_Pm.TblDetalleDocs, Me, "Historia PPP " & Txtcodigo.Text)
        End If

    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick
        Tiempo.Stop()
        If MessageBoxEx.Show(Me, "¿confirma el racalculo?", "Recalcular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Btn_Cancelar.Enabled = True
            Sb_Recalcupar_PPP()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Cl_Pm.Cancelar = True
        MessageBoxEx.Show(Me, "Acción cancelada por el usuario", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Me.Close()
    End Sub

End Class
