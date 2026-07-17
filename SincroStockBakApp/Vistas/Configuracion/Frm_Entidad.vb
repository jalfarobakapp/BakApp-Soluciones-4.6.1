Imports BkSpecialPrograms
Imports BkSpecialPrograms.Frm_Filtro_Especial_Informes
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Frm_Entidad

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private _Empresa As Empresa          ' Referencia al objeto Empresa (01 o 02)
    Private _CodigoEmpresa As String     ' Guardará "01" o "02" para los filtros SQL

    ' Constructor modificado para recibir la empresa y su código identificador
    Public Sub New(Empresa As Empresa)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Inicializamos las variables locales con los parámetros recibidos
        _Empresa = Empresa
        _CodigoEmpresa = Empresa.Numero


    End Sub

    Private Sub Frm_Informe_Stock_Valorizado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Rellenar el formulario con los datos actuales de la empresa al cargar
        Sb_Rellenar_Formulario()
    End Sub

    Private Sub Sb_Rellenar_Formulario()
        If _Empresa Is Nothing Then Return

        ' Mostrar valores iniciales en los TextBox
        Sb_Asignar_Texto_TextBox(_Empresa.EntidadDeCompra, Txt_EntidadCompra)
        Sb_Asignar_Texto_TextBox(_Empresa.EntidadDeVenta, Txt_EntidadVenta)

        Sb_Asignar_Texto_TextBox(_Empresa.ModalidadOCC, Txt_ModOCC)
        Sb_Asignar_Texto_TextBox(_Empresa.ModalidadFCV, Txt_ModFCV)
        Sb_Asignar_Texto_TextBox(_Empresa.ModalidadNVV, Txt_ModNVV)
        Sb_Asignar_Texto_TextBox(_Empresa.ModalidadFCC, Txt_ModFCC)
    End Sub

    Private Sub Sb_Asignar_Texto_TextBox(tbl As DataTable, txtBox As TextBoxX)
        If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
            Dim codigo As String = tbl.Rows(0).Item("Codigo").ToString.Trim()
            Dim descripcion As String = tbl.Rows(0).Item("Descripcion").ToString.Trim()
            txtBox.Text = codigo & " - " & descripcion
        Else
            txtBox.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Función centralizada que abre el formulario de filtro especial y retorna el DataTable con la selección
    ''' </summary>
    Private Function Fx_Abrir_Filtro(tipoFiltro As Object, condicionExtra As String, tablaSql As String, campoCodigo As String, campoDescripcion As String, esModalidad As Boolean) As DataTable
        Dim _Tbl_Filtro As New DataTable()
        _Tbl_Filtro.Columns.Add("ChkV", GetType(Boolean))
        _Tbl_Filtro.Columns.Add("Codigo", GetType(String))
        _Tbl_Filtro.Columns.Add("Descripcion", GetType(String))

        If esModalidad Then
            _Tbl_Filtro.Columns.Add("MODALIDAD", GetType(String))
        End If

        Dim Fm As New Frm_Filtro_Especial_Informes(tipoFiltro,, condicionExtra, tablaSql, campoCodigo, campoDescripcion)
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.Pro_Seleccionar_Solo_Uno = True
        Fm.ShowDialog(Me)

        Dim _Tbl_Resultado As DataTable = Nothing

        If Fm.DialogResult = DialogResult.OK Then
            If Fm.Pro_Tbl_Filtro IsNot Nothing AndAlso Fm.Pro_Tbl_Filtro.Rows.Count > 0 Then
                _Tbl_Resultado = Fm.Pro_Tbl_Filtro
            End If
        End If

        Fm.Dispose()
        Return _Tbl_Resultado
    End Function

#Region "Eventos de los Botones de Búsqueda (ButtonCustomClick)"

    ' --- ENTIDADES ---
    Private Sub Txt_EntidadCompra_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_EntidadCompra.ButtonCustomClick
        Dim tbl As DataTable = Fx_Abrir_Filtro(_Tabla_Fl._Entidades, "", "MAEEMO", "KOEN", "NOKOEN", False)
        If tbl IsNot Nothing Then
            _Empresa.EntidadDeCompra = tbl
            Sb_Asignar_Texto_TextBox(_Empresa.EntidadDeCompra, Txt_EntidadCompra)
        End If
    End Sub

    Private Sub Txt_EntidadVenta_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_EntidadVenta.ButtonCustomClick
        Dim tbl As DataTable = Fx_Abrir_Filtro(_Tabla_Fl._Entidades, "", "MAEEMO", "KOEN", "NOKOEN", False)
        If tbl IsNot Nothing Then
            _Empresa.EntidadDeVenta = tbl
            Sb_Asignar_Texto_TextBox(_Empresa.EntidadDeVenta, Txt_EntidadVenta)
        End If
    End Sub

    ' --- MODALIDADES (Utilizan el código de empresa dinámico) ---
    Private Sub Txt_ModOCC_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ModOCC.ButtonCustomClick
        Dim condicion As String = "AND EMPRESA = '" & _CodigoEmpresa & "'"
        Dim tbl As DataTable = Fx_Abrir_Filtro(_Tabla_Fl._Otra, condicion, "CONFIEST", "MODALIDAD", "MODALIDAD", True)
        If tbl IsNot Nothing Then
            _Empresa.ModalidadOCC = tbl
            Sb_Asignar_Texto_TextBox(_Empresa.ModalidadOCC, Txt_ModOCC)
        End If
    End Sub

    Private Sub Txt_ModFCV_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ModFCV.ButtonCustomClick
        Dim condicion As String = "AND EMPRESA = '" & _CodigoEmpresa & "'"
        Dim tbl As DataTable = Fx_Abrir_Filtro(_Tabla_Fl._Otra, condicion, "CONFIEST", "MODALIDAD", "MODALIDAD", True)
        If tbl IsNot Nothing Then
            _Empresa.ModalidadFCV = tbl
            Sb_Asignar_Texto_TextBox(_Empresa.ModalidadFCV, Txt_ModFCV)
        End If
    End Sub

    Private Sub Txt_ModNVV_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ModNVV.ButtonCustomClick
        Dim condicion As String = "AND EMPRESA = '" & _CodigoEmpresa & "'"
        Dim tbl As DataTable = Fx_Abrir_Filtro(_Tabla_Fl._Otra, condicion, "CONFIEST", "MODALIDAD", "MODALIDAD", True)
        If tbl IsNot Nothing Then
            _Empresa.ModalidadNVV = tbl
            Sb_Asignar_Texto_TextBox(_Empresa.ModalidadNVV, Txt_ModNVV)
        End If
    End Sub

    Private Sub Txt_ModFCC_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ModFCC.ButtonCustomClick
        Dim condicion As String = "AND EMPRESA = '" & _CodigoEmpresa & "'"
        Dim tbl As DataTable = Fx_Abrir_Filtro(_Tabla_Fl._Otra, condicion, "CONFIEST", "MODALIDAD", "MODALIDAD", True)
        If tbl IsNot Nothing Then
            _Empresa.ModalidadFCC = tbl
            Sb_Asignar_Texto_TextBox(_Empresa.ModalidadFCC, Txt_ModFCC)
        End If
    End Sub

#End Region

    Private Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        ' Al usar DialogResult.OK, el formulario padre sabe que los cambios deben procesarse o guardarse en el JSON
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


End Class
