Imports Lib_Bakapp_VarClassFunc

Public Class Frm_SeleccionarTipoCosto

    Dim _sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public TipoCosto As String
    Public ListaCosto As String

    Enum TipoC
        Pm
        Pm_Sucursal
        Pm_Transaccion
        Ultima_Compra
        Lista_Costos
    End Enum

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        caract_combo(CmbListaDeCostos)
        Consulta_sql = "SELECT KOLT AS Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'C'"
        CmbListaDeCostos.DataSource = _sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click

        If RdPmTrans.Checked Then ' Pm Transacción
            TipoCosto = TipoC.Pm_Transaccion.ToString
        End If

        If RdPM.Checked Then ' Pm
            TipoCosto = TipoC.Pm.ToString
        End If

        If RdPMSuc.Checked Then ' Pm Sucursal
            TipoCosto = TipoC.Pm_Sucursal.ToString
        End If

        If RdUC.Checked Then ' Ultima comptra
            TipoCosto = TipoC.Ultima_Compra.ToString
        End If

        If RdLP.Checked Then ' Costo Lista de Costos
            TipoCosto = TipoC.Lista_Costos.ToString
            ListaCosto = CmbListaDeCostos.SelectedValue
        End If

        Me.Close()

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        TipoCosto = String.Empty
        Me.Close()
    End Sub

    Private Sub RdLP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdLP.CheckedChanged
        CmbListaDeCostos.Enabled = RdLP.Checked
    End Sub

    Private Sub Frm_SeleccionarTipoCosto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CmbListaDeCostos.Enabled = RdLP.Checked
    End Sub
End Class