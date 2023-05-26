Public Class Frm_Demonio_Configuraciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _row_ConfEstacion As DataRow

    Public Property Grabar As Boolean

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Demonio_Configuraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfXEstacion (NombreEquipo) Values ('" & _NombreEquipo & "')"



        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_ConfXEstacion Set" &
                       " EnvioCorreo = " & Convert.ToInt32(Chk_EnvioCorreo.Checked) &
                       ",CantCorreo = 0" &
                       ",ColaImpDoc = " & Convert.ToInt32(Chk_ColaImpDoc.Checked) &
                       ",ColaImpPick = " & Convert.ToInt32(Chk_ColaImpPick.Checked) &
                       ",SolProdBod = " & Convert.ToInt32(Chk_SolProdBod.Checked) &
                       ",ImpSolProdBod = '" & Txt_ImpSolProdBod.Text & "'" &
                       ",Prestashop_Prod = " & Convert.ToInt32(Chk_Prestashop_Prod.Checked) &
                       ",Prestashop_Order = " & Convert.ToInt32(Chk_Prestashop_Order.Checked) &
                       ",Prestashop_Total = " & Convert.ToInt32(Chk_Prestashop_Total.Checked) &
                       ",ImporDTESII = " & Convert.ToInt32(Chk_ImporDTESII.Checked) &
                       ",ArchivarDoc = " & Convert.ToInt32(Chk_ArchivarDoc.Checked) &
                       ",DirArchivarDoc = '" & Txt_DirArchivarDoc.Text & "'" &
                       ",ConsStock = " & Convert.ToInt32(Chk_ConsStock.Checked) &
                       ",ConsStock_Todos = " & Convert.ToInt32(Rdb_Cons_Stock_Todos.Checked) &
                       ",ConsStock_Hoy = " & Convert.ToInt32(Rdb_Cons_Stock_Mov_Hoy.Checked) &
                       ",Wordpress_Prod = " & Convert.ToInt32(Chk_Wordpress_Prod.Checked) &
                       ",Wordpress_Stock = " & Convert.ToInt32(Chk_Wordpress_Stock.Checked) &
                       ",CierreDoc = " & Convert.ToInt32(Chk_CierreDoc.Checked) &
                       ",FacturacionAuto = " & Convert.ToInt32(Chk_FacturacionAuto.Checked) &
                       ",AsistenteCompras = " & Convert.ToInt32(Chk_Wordpress_Prod.Checked) & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
            Me.Close()
        End If

    End Sub


End Class
