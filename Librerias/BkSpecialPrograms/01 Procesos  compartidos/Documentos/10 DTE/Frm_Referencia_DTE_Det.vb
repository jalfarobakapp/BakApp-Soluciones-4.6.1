Imports DevComponents.DotNetBar

Public Class Frm_Referencia_DTE_Det

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Referencia_DTE As DataRow
    Dim _Grabar As Boolean

    Public Property Row_Referencia_DTE As DataRow
        Get
            Return _Row_Referencia_DTE
        End Get
        Set(value As DataRow)
            _Row_Referencia_DTE = value
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

    Public Sub New(Row_Referencia_DTE As DataRow,
                   Habilita_CodRef As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Referencia_DTE = Row_Referencia_DTE

        Lbl_CodRef.Enabled = Habilita_CodRef
        Cmb_CodRef.Enabled = Habilita_CodRef

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Referencia_DTE_Det_Load(sender As Object, e As EventArgs) Handles Me.Load

        Consulta_sql = "Select '' As Padre, '' As Hijo Union 
                        Select CodigoTabla As Padre,Ltrim(Rtrim(CodigoTabla))+' - '+Ltrim(Rtrim(NombreTabla)) As Hijo
                        From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones
                        Where (Tabla = 'DOCUMENTOS_DTE_SII')"
        caract_combo(Cmb_TpoDocRef)
        Cmb_TpoDocRef.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_TpoDocRef.SelectedValue = ""

        Consulta_sql = "Select '0' As Padre, '' As Hijo Union 
                        Select CodigoTabla As Padre,Ltrim(Rtrim(CodigoTabla))+' - '+Ltrim(Rtrim(NombreTabla)) As Hijo
                        From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones
                        Where (Tabla = 'CODREF_SII_NCV')"
        caract_combo(Cmb_CodRef)
        Cmb_CodRef.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_CodRef.SelectedValue = ""

        Sb_Llenar_Datos()

    End Sub

    Sub Sb_Llenar_Datos()

        Cmb_TpoDocRef.SelectedValue = _Row_Referencia_DTE.Item("TpoDocRef")

        If Cmb_TpoDocRef.SelectedValue = "801" Then
            Txt_FolioRef.Tag = _Row_Referencia_DTE.Item("FolioRef")
            Txt_FolioRef.Text = Txt_FolioRef.Tag
        Else
            Txt_FolioRef.Tag = Val(_Row_Referencia_DTE.Item("FolioRef"))
            If Convert.ToBoolean(Txt_FolioRef.Tag) Then Txt_FolioRef.Text = Txt_FolioRef.Tag
        End If


        Dtp_FchRef.Value = _Row_Referencia_DTE.Item("FchRef")

        Cmb_CodRef.SelectedValue = _Row_Referencia_DTE.Item("CodRef")
        Txt_RazonRef.Text = _Row_Referencia_DTE.Item("RazonRef")

    End Sub

    Sub Sb_Grabar_Datos()

        _Row_Referencia_DTE.Item("TpoDocRef") = Cmb_TpoDocRef.SelectedValue
        _Row_Referencia_DTE.Item("FolioRef") = Txt_FolioRef.Text
        _Row_Referencia_DTE.Item("FchRef") = Dtp_FchRef.Value
        _Row_Referencia_DTE.Item("CodRef") = Cmb_CodRef.SelectedValue
        _Row_Referencia_DTE.Item("RazonRef") = Txt_RazonRef.Text

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Trim(Cmb_TpoDocRef.Text)) Or
           String.IsNullOrEmpty(Trim(Txt_RazonRef.Text)) Or
           String.IsNullOrEmpty(Trim(Txt_FolioRef.Text)) Then

            MessageBoxEx.Show(Me, "Faltan datos en la referencia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            Sb_Grabar_Datos()
            _Grabar = True
            Me.Close()

        End If

    End Sub

    Private Sub Cmb_TpoDocRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_TpoDocRef.SelectedIndexChanged

        'Txt_RazonRef.Text = Replace(Cmb_TpoDocRef.Text, Cmb_TpoDocRef.SelectedValue & " - ", "")

    End Sub

    Private Sub Frm_Referencia_DTE_Det_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
