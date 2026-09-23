Imports BkSpecialPrograms
Imports BkSpecialPrograms.Frm_Filtro_Especial_Informes
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Frm_Bodega

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    ' Constructor modificado para recibir la empresa y su código identificador
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Inicializamos las variables locales con los parámetros recibidos




    End Sub

    Private Sub Frm_Informe_Stock_Valorizado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Sb_Rellenar_Formulario()

    End Sub

    Private Function GenerarInsert() As String
        Dim empresaA As String = "01"
        Dim empresaB As String = "02"
        Dim Consulta_sql As String = $"IF NOT EXISTS (SELECT 1 FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Equivalencia " &
                             $"               WHERE Empresa_A = '{empresaA}' AND Sucursal_A = '{Txt_Suc1.Text.Trim()}' AND Bodega_A = '{Txt_Bod1.Text.Trim()}' " &
                             $"               AND Empresa_B = '{empresaB}' AND Sucursal_B = '{Txt_Suc2.Text.Trim()}' AND Bodega_B = '{Txt_Bod2.Text.Trim()}') " &
                             $"BEGIN " &
                             $"   INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Equivalencia " &
                             $"   (Empresa_A, Sucursal_A, Bodega_A, Empresa_B, Sucursal_B, Bodega_B, Activo, FechaCreacion) " &
                             $"   VALUES ('{empresaA}', '{Txt_Suc1.Text.Trim()}', '{Txt_Bod1.Text.Trim()}', '{empresaB}', '{Txt_Suc2.Text.Trim()}', '{Txt_Bod2.Text.Trim()}', 1, GETDATE()) " &
                             $"END"
        Return Consulta_sql
    End Function
    Private Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String = GenerarInsert()
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Me.DialogResult = DialogResult.OK
        Else
            MessageBoxEx.Show(Me, "Error al guardar la información en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Btn_BscEmp1_Click(sender As Object, e As EventArgs) Handles Btn_BscEmp1.Click
        Dim Mensajes As Mensajes = traeBodegas("01")
        If Mensajes.EsCorrecto Then
            Dim _RowBodega As DataRow = Mensajes.Tag
            Txt_Bod1.Text = _RowBodega.Item("KOBO")
            Txt_Emp1.Text = _RowBodega.Item("RAZON")
            Txt_Nom1.Text = _RowBodega.Item("NOKOBO")
            Txt_Suc1.Text = _RowBodega.Item("KOSU")
        End If

    End Sub

    Private Sub Btn_BscEmp2_Click(sender As Object, e As EventArgs) Handles Btn_BscEmp2.Click
        Dim Mensajes As Mensajes = traeBodegas("02")
        If Mensajes.EsCorrecto Then
            Dim _RowBodega As DataRow = Mensajes.Tag
            Txt_Bod2.Text = _RowBodega.Item("KOBO")
            Txt_Emp2.Text = _RowBodega.Item("RAZON")
            Txt_Nom2.Text = _RowBodega.Item("NOKOBO")
            Txt_Suc2.Text = _RowBodega.Item("KOSU")
        End If
    End Sub
    Private Function traeBodegas(Empresa As String) As Mensajes

        Dim _RowBodega As DataRow

        Dim Fm_B As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_B.Pro_Empresa = Empresa
        'Fm_B.Pro_Sucursal = _Sucursal

        Fm_B.ShowDialog(Me)
        _RowBodega = Fm_B.Pro_RowBodega
        Dim _BodSelec As Boolean = Fm_B.Pro_Seleccionado
        Fm_B.Dispose()
        Dim MensajeR As New Mensajes

        If _BodSelec Then
            MensajeR.EsCorrecto = True
            MensajeR.Mensaje = "Bodega seleccionada correctamente."
            MensajeR.Tag = _RowBodega
        Else
            MensajeR.EsCorrecto = False
            MensajeR.Mensaje = "No se seleccionó ninguna bodega."
            MensajeR.Tag = Nothing
        End If

        Return MensajeR
    End Function
End Class
