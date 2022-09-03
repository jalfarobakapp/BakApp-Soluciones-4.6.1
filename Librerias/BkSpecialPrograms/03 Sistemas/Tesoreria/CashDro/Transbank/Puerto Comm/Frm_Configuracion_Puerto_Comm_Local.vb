'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Configuracion_Puerto_Comm_Local

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Transbank\Puerto Comm"

    Dim _Ds_Comm_Local As New Ds_Comm_Local

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not Directory.Exists(_Path) Then
            System.IO.Directory.CreateDirectory(_Path)
        End If

        Dim _Existe = System.IO.File.Exists(_Path & "\Puerto_Comm.xml")

        If Not _Existe Then
            _Ds_Comm_Local.WriteXml(_Path & "\Puerto_Comm.xml")
        End If

    End Sub

    Private Sub Frm_Configuracion_Puerto_Comm_Local_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Dim _Ds As New Ds_Comm_Local

        _Ds.ReadXml(_Path & "\Puerto_Comm.xml")
        _Ds.Clear()

        Dim NewFila As DataRow
        NewFila = _Ds.Tables("Tbl_Puerto_Comm").NewRow
        With NewFila

            .Item("Puerto") = Cmb_Puerto.Text
            .Item("Tasa_de_baudios") = Cmb_Tasa_de_baudios.Text
            .Item("Paridad") = Cmb_Paridad.Text
            .Item("Bits_de_parada") = Cmb_Bits_de_parada.Text
            .Item("Bits_de_datos") = Cmb_Bits_de_datos.Text
            .Item("Rdb_Hexadecimal") = Rdb_Hexadecimal.Checked
            .Item("Rdb_Texto") = Rdb_Texto.Checked
            
            _Ds.Tables("Tbl_Puerto_Comm").Rows.Add(NewFila)

        End With

        _Ds.WriteXml(_Path & "\Puerto_Comm.xml")
        
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

End Class