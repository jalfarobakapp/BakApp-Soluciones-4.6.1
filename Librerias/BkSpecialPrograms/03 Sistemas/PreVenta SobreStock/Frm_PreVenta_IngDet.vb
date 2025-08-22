Imports DevComponents.DotNetBar

Public Class Frm_PreVenta_IngDet

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cl_PreVenta As New PreVenta.Cl_PreVenta
    Public Property Grabar As Boolean

    Dim _Row_Producto As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_PreVenta_IngDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Cl_PreVenta

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & .Codigo & "'"
            _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Codigo.Text = .Codigo
            Txt_Descripcion.Text = .Descripcion
            Txt_FormatoPqte.Text = .FormatoPqte
            Input_PqteHabilitado.Value = .PqteHabilitado
            DInput_Ud1XPqte.Value = .Ud1XPqte
            Input_CantMinFormato.Value = .CantMinFormato
            Txt_Moneda.Text = .Moneda
            DInput_PrecioXUd1.Value = .PrecioXUd1
            Lbl_StcfiUd1.Text = _Row_Producto.Item("UD01PR").ToString.Trim & " Disponibles: " & .StcfiUd1.ToString("#,##")

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _KilosHabilitados As Double
        Dim _PqtesMaximo As Double
        Dim _Ud = _Row_Producto.Item("UD01PR")

        With Cl_PreVenta
            .Codigo = Txt_Codigo.Text
            .Descripcion = Txt_Descripcion.Text
            .FormatoPqte = Txt_FormatoPqte.Text
            .PqteHabilitado = Input_PqteHabilitado.Value
            .Ud1XPqte = DInput_Ud1XPqte.Value
            .CantMinFormato = Input_CantMinFormato.Value
            .Moneda = Txt_Moneda.Text
            .PrecioXUd1 = DInput_PrecioXUd1.Value

            _KilosHabilitados = .Ud1XPqte * .PqteHabilitado
            _PqtesMaximo = .StcfiUd1 / .Ud1XPqte

            If String.IsNullOrWhiteSpace(.Codigo) Then
                MessageBoxEx.Show(Me, "Falta el código del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Codigo.Focus()
                Return
            End If
            If String.IsNullOrWhiteSpace(.Descripcion) Then
                MessageBoxEx.Show(Me, "Falta la descripción del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Descripcion.Focus()
                Return
            End If
            If String.IsNullOrWhiteSpace(.FormatoPqte) Then
                MessageBoxEx.Show(Me, "Falta el formato del paquete", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_FormatoPqte.Focus()
                Return
            End If
            If .Ud1XPqte <= 0 Then
                MessageBoxEx.Show(Me, "La cantidad de " & _Ud & " por paquete debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                DInput_Ud1XPqte.Focus()
                Return
            End If
            If .Ud1XPqte > .StcfiUd1 Then
                MessageBoxEx.Show(Me, "La cantidad de " & _Ud & " por paquete no puede ser mayor que " & FormatNumber(.StcfiUd1, 0), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                DInput_Ud1XPqte.Focus()
                Return
            End If
            If .PqteHabilitado <= 0 Then
                MessageBoxEx.Show(Me, "Los " & .FormatoPqte & " habilitados (disponibles) debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Input_PqteHabilitado.Focus()
                Return
            End If
            If .CantMinFormato <= 0 Then
                MessageBoxEx.Show(Me, "La cantidad mínima de venta de " & .FormatoPqte & " debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Input_CantMinFormato.Focus()
                Return
            End If
            If String.IsNullOrWhiteSpace(.Moneda) Then
                MessageBoxEx.Show(Me, "Falta la moneda de venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Moneda.Focus()
                Return
            End If
            If .PrecioXUd1 <= 0 Then
                MessageBoxEx.Show(Me, "El precio por unidad debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                DInput_PrecioXUd1.Focus()
                Return
            End If

            If _PqtesMaximo < .PqteHabilitado Then

                Dim _Msj As String

                _Msj = "No es posible habilitar " & .PqteHabilitado & " " & .FormatoPqte & " para la venta." & vbCrLf & vbCrLf &
                       "El máximo permitido es " & _PqtesMaximo & " " & .FormatoPqte & ", según el cálculo de " & .Ud1XPqte & " " & _Ud & " por " & .FormatoPqte & " y un " & vbCrLf &
                       "stock disponible de " & FormatNumber(.StcfiUd1, 0) & " " & _Ud & "."
                MessageBoxEx.Show(Me, _Msj, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Input_PqteHabilitado.Focus()
                Return

            End If

        End With

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Txt_Moneda_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Moneda.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABMO"
        _Filtrar.Campo = "KOMO"
        _Filtrar.Descripcion = "NOKOMO"

        Dim _Komo As String
        Dim _Nokomo As String

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And KOMO In (Select Distinct KOMO From MAEMO Where TIMO = 'E')",
                               Nothing, False, True) Then

            Dim _Tbl_Modena As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Modena.Rows(0)

            _Komo = _Row.Item("Codigo").ToString.Trim
            _Nokomo = _Row.Item("Descripcion").ToString.Trim

            Txt_Moneda.Text = _Komo

        End If

    End Sub

End Class
