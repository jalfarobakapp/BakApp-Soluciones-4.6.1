Imports DevComponents.DotNetBar
Public Class Frm_Conceptos_ObliXDoc_Ing

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tido As String
    Dim _Tidp As String
    Dim _Concepto As String
    Dim _Modalidad As String

    Dim _Id As String
    Dim _Grabar As Boolean
    Dim _Editar As Boolean

    Public Property Tido As String
        Get
            _Tido = Txt_Tido.Tag
            Return _Tido
        End Get
        Set(value As String)
            _Tido = value
        End Set
    End Property

    Public Property Tidp As String
        Get
            _Tidp = Txt_Tidp.Tag
            Return _Tidp
        End Get
        Set(value As String)
            _Tidp = value
        End Set
    End Property

    Public Property Concepto As String
        Get
            _Concepto = Txt_Concepto.Tag
            Return _Concepto
        End Get
        Set(value As String)
            _Concepto = value
        End Set
    End Property

    Public Property Editar As Boolean
        Get
            Return _Editar
        End Get
        Set(value As Boolean)
            _Editar = value
        End Set
    End Property

    Public Sub New(_Modalidad As String, _Id As Integer, _Editar As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Modalidad = _Modalidad
        Me._Id = _Id
        Me._Editar = _Editar

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Conceptos_ObliXDoc_Ing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Arr_Tipo_Entidad(,) As String = {{"", "Siempre será obligatorio"},
                                              {"CONDSCTO", "Obligatorio si el documento TIENE descuentos"},
                                              {"SINDSCTO", "Obligatorio si el documento NO TIENE descuentos"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Vista_Informe)
        Cmb_Vista_Informe.SelectedValue = ""

        If _Editar Then

            Consulta_sql = "Select Id,Modalidad,Tido,NOTIDO,Tidp,Concepto,NOKOCT,NombreTabla,DescripcionTabla,Cond_Obliga
                            From " & _Global_BaseBk & "Zw_Docu_ObligPg
                            Left Join TABTIDO Doc On Doc.TIDO = Tido
                            Left Join TABCT On KOCT = Concepto
                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones On Tabla = 'TIDP_Cli' And CodigoTabla = Tidp 
                            Where Id = " & _Id

            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Tido.Tag = _Row.Item("Tido")
            Txt_Tido.Text = _Row.Item("Tido").ToString.Trim & " - " & _Row.Item("NOTIDO")

            Txt_Tidp.Tag = _Row.Item("Tidp")
            Txt_Tidp.Text = _Row.Item("Tidp").ToString.Trim & " - " & _Row.Item("NombreTabla")

            Txt_Concepto.Tag = _Row.Item("Concepto")
            Txt_Concepto.Text = _Row.Item("Concepto").ToString.Trim & " - " & _Row.Item("NOKOCT")

            Cmb_Vista_Informe.SelectedValue = _Row.Item("Cond_Obliga").ToString.Trim
            Btn_Buscar_Tido.Enabled = False

        End If

    End Sub

    Private Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click

        If String.IsNullOrEmpty(Tido) Then
            MessageBoxEx.Show(Me, "Falta tipo de documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Tidp) Then
            MessageBoxEx.Show(Me, "Falta tipo de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Concepto) Then
            MessageBoxEx.Show(Me, "Falta concepto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Editar And _Id > 0 Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Docu_ObligPg Set " &
                           "Tidp = '" & Tidp & "'" & vbCrLf &
                           ",Concepto = '" & Concepto & "'" & vbCrLf &
                           ",Cond_Obliga = '" & Cmb_Vista_Informe.SelectedValue & "'" & vbCrLf &
                           "Where Id = " & _Id
        Else
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_ObligPg (Modalidad,Tido,Tidp,Concepto,Cond_Obliga) Values 
                            ('" & _Modalidad & "','" & Tido & "','" & Tidp & "','" & Concepto & "','" & Cmb_Vista_Informe.SelectedValue & "')"
        End If

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Condición incorporada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Grabar = True
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Buscar_Tido_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Tido.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "DOCUMENTOS DE VENTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Documentos_Venta, "",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Txt_Tido.Tag = _Row.Item("Codigo")
            Txt_Tido.Text = _Row.Item("Codigo").trim & " - " & _Row.Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Btn_Buscar_Tidp_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Tidp.Click

        Dim _Filtro_Extra_Sql = "And CodigoTabla In ('EFV','CHV','TJV','DEP','ATB','CRV')"

        Dim Fm As New Frm_Pagos_Seleccion_Tipo_Pago(0)
        Fm.Pro_Filtro_Extra_Sql = _Filtro_Extra_Sql
        Fm.ShowDialog(Me)
        Dim _Tidp_Seleccionado As Boolean = Fm.Pro_Precio_Tidp_Seleccionado
        Dim _Row_Tidp As DataRow = Fm.Pro_Row_Tidp
        Fm.Dispose()

        If _Tidp_Seleccionado Then
            Txt_Tidp.Tag = _Row_Tidp.Item("TIDP")
            Txt_Tidp.Text = _Row_Tidp.Item("TIDP").ToString.Trim & " - " & _Row_Tidp.Item("Descripcion")
        End If

    End Sub

    Private Sub Btn_Buscar_Concepto_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Concepto.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "CONCEPTOS"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Conceptos, "",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_ObligPg",
                                                "Modalidad = '" & _Modalidad & "' And Tido = '" & Txt_Tido.Tag & "' And Tidp = '" & Txt_Tidp.Tag & "' And Concepto = '" & _Row.Item("Codigo") & "'")

            Dim _Codigo = _Row.Item("Codigo")
            Dim _Descripcion = _Row.Item("Codigo").trim & " - " & _Row.Item("Descripcion").ToString.Trim

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Esta combinación: " & vbCrLf & vbCrLf &
                                                          "Modalidad -> " & _Modalidad & vbCrLf &
                                                          "Documento -> " & Txt_Tido.Text & vbCrLf &
                                                          "Forma de pago -> " & Txt_Tidp.Text & vbCrLf &
                                                          "Concepto -> " & _Descripcion & vbCrLf & vbCrLf &
                                                          "Ya existe en el sistema" & vbCrLf &
                                                          "No puede crear la misma condición más de una vez", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Txt_Concepto.Tag = _Codigo
            Txt_Concepto.Text = _Descripcion

        End If

    End Sub


End Class
