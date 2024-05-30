Imports DevComponents.DotNetBar
Public Class Frm_Inv_Crear_Inventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Cl_Inventario As New Cl_Inventario
    Public Property Id_Inventario As Integer
    Public Property Grabar As Boolean

    Public Sub New(_Empresa As String, _Sucursal As String, _Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cl_Inventario.Zw_Inv_Inventario.Empresa = _Empresa
        _Cl_Inventario.Zw_Inv_Inventario.Sucursal = _Sucursal
        _Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_Id)

    End Sub

    Private Sub Frm_Crear_Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With _Cl_Inventario.Zw_Inv_Inventario

            If CBool(.Id) Then
                Txt_Nombre.Text = .Nombre_Inventario
                Dtp_FechaInicio.Value = .FechaInicio
                Sw_Activo.Value = .Activo
                Dtp_FechaCierre.Value = .FechaCierre
            Else
                Lbl_Estado.Enabled = False
                Sw_Activo.Enabled = False
                Lbl_FechaCierre.Enabled = False
                Dtp_FechaCierre.Enabled = False
                Txt_Nombre.ReadOnly = False
                Txt_Nombre.Enabled = True
                Dtp_FechaInicio.Enabled = True
                Me.ActiveControl = Txt_Nombre
            End If

            Lbl_Empresa.Text = RazonEmpresa
            Lbl_Sucursal.Text = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", "EMPRESA = '" & .Empresa & "' And KOSU = '" & .Sucursal & "'")

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _FechaInicio As String = Format(Dtp_FechaInicio.Value, "yyyyMMdd")
        Dim _FechaCierre As String = Format(Dtp_FechaCierre.Value, "yyyyMMdd")

        With _Cl_Inventario

            .Zw_Inv_Inventario.Nombre_Inventario = Txt_Nombre.Text
            .Zw_Inv_Inventario.FechaInicio = Dtp_FechaInicio.Value
            .Zw_Inv_Inventario.Activo = Sw_Activo.Value
            '.FechaCierre = Dtp_FechaCierre.Value

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = .Fx_Crear_Inventario

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

            If Not _Mensaje.EsCorrecto Then
                Return
            End If

            Id_Inventario = _Mensaje.Id
            _Grabar = True

        End With


        Me.Close()

    End Sub

End Class
