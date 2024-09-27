Imports DevComponents.DotNetBar

Public Class Frm_Pocket_Equipos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Poswii As DataRow
    Dim _Grabar As Boolean

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Pro_Row_Poswii() As DataRow
        Get
            Return _Row_Poswii
        End Get
        Set(ByVal value As DataRow)
            _Row_Poswii = value
        End Set
    End Property
   
    Public Sub New(ByVal NombreEquipo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        caract_combo(Cmb_Usuario)
        Dim Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf
        Consulta_sql = Union & "SELECT KOFU AS Padre,Ltrim(Rtrim(NOKOFU))+' - '+KOFU AS Hijo FROM TABFU" & vbCrLf & _
                      "ORDER BY Hijo"
        Cmb_Usuario.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Usuario.SelectedValue = ""

        caract_combo(Cmb_Modalidad)
        Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf
        Consulta_sql = Union & "SELECT MODALIDAD AS Padre,MODALIDAD AS Hijo FROM TABFU" & vbCrLf & _
                      "ORDER BY Hijo"
        Cmb_Modalidad.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Modalidad.SelectedValue = ""

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_Poswi" & vbCrLf & _
                       "Where NombreEquipo = '" & NombreEquipo & "'"
        _Row_Poswii = _Sql.Fx_Get_DataRow(Consulta_sql)


    End Sub

    Private Sub Frm_Pocket_Equipos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Cargar_Datos()
    End Sub

    Sub Sb_Cargar_Datos()

        With _Row_Poswii

            Txt_NombreEquipo.Text = .Item("NombreEquipo")
            Cmb_Usuario.SelectedValue = .Item("Usuario")
            Cmb_Modalidad.SelectedValue = .Item("Modalidad")

            Rdb_Impresion_X_Poswi.Checked = .Item("Impresion_X_Poswi")
            Rdb_Enviar_Mail_X_BakApp.Checked = .Item("Enviar_Mail_X_BakApp")

            Rdb_Impresion_X_BakApp.Checked = .Item("Impresion_X_BakApp")
            Rdb_Enviar_Mail_X_Poswi.Checked = .Item("Enviar_Mail_X_Poswi")

        End With

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Estaciones_Poswi Set" & Space(1) & _
                       "Usuario = '" & Cmb_Usuario.SelectedValue & "'," & _
                       "Modalidad = '" & Cmb_Modalidad.SelectedValue & "'," & _
                       "Impresion_X_Poswi = " & CInt(Rdb_Impresion_X_Poswi.Checked) * -1 & "," & _
                       "Enviar_Mail_X_BakApp = " & CInt(Rdb_Enviar_Mail_X_BakApp.Checked) * -1 & "," & _
                       "Impresion_X_BakApp = " & CInt(Rdb_Impresion_X_BakApp.Checked) * -1 & "," & _
                       "Enviar_Mail_X_Poswi = " & CInt(Rdb_Enviar_Mail_X_Poswi.Checked) * -1 & vbCrLf & _
                       "Where NombreEquipo = '" & Txt_NombreEquipo.Text & "'"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            _Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_Pocket_Equipos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class