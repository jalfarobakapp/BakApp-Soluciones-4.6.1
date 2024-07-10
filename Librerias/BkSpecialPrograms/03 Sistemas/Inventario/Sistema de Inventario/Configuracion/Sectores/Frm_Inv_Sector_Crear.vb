Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar

Public Class Frm_Inv_Sector_Crear

    Private _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private Consulta_sql As String

    Private _Id As Integer
    Public Property Cl_InvSectores As Cl_InvSectores
    Public Property Cl_Inventario As Cl_Inventario
    Public Property Grabar As Boolean
    Public Property Eliminar As Boolean

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id

        Cl_InvSectores = New Cl_InvSectores
        Cl_InvSectores.Fx_Llenar_Zw_Inv_Sector(_Id)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inv_UbicacionesCrear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If CBool(_Id) Then

            Txt_Sector.Text = Cl_InvSectores.Zw_Inv_Sector.Sector
            Txt_NombreSector.Text = Cl_InvSectores.Zw_Inv_Sector.NombreSector
            Txt_CodFuncionario.Tag = Cl_InvSectores.Zw_Inv_Sector.CodFuncionario
            Txt_CodFuncionario.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & Txt_CodFuncionario.Tag & "'")

        End If

        Btn_Eliminar.Visible = CBool(_Id)

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Sector.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Ubicación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Sector.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_NombreSector.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el nombre de la ubicación", "Nombre de la ubicación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NombreSector.Focus()
            Return
        End If

        With _Cl_InvSectores.Zw_Inv_Sector

            .Sector = Txt_Sector.Text
            .NombreSector = Txt_NombreSector.Text
            .IdInventario = _Cl_Inventario.Zw_Inv_Inventario.Id
            .Empresa = _Cl_Inventario.Zw_Inv_Inventario.Empresa
            .Sucursal = _Cl_Inventario.Zw_Inv_Inventario.Sucursal
            .Bodega = _Cl_Inventario.Zw_Inv_Inventario.Bodega

        End With

        Dim _Mensaje As New LsValiciones.Mensajes

        If CBool(_Id) Then
            _Mensaje = _Cl_InvSectores.Fx_Editar_Sector()
        Else
            _Mensaje = _Cl_InvSectores.Fx_Crear_Sector(_Cl_InvSectores.Zw_Inv_Sector)
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then Return

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Hoja_Detalle",
                                            "IdInventario = " & Cl_Inventario.Zw_Inv_Inventario.Id & " And IdSector = " & _Id)
        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar el sector, tiene registros inventariados", "Eliminar Sector",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar el Sector?", "Eliminar Sector",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = _Cl_InvSectores.Fx_Eliminar_Sector
        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Eliminar = True
            Me.Close()
        End If

    End Sub

    Private Sub Txt_CodFuncionario_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CodFuncionario.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random,
                               _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_CodFuncionario.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_CodFuncionario.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            _Cl_InvSectores.Zw_Inv_Sector.CodFuncionario = Txt_CodFuncionario.Tag

        End If

    End Sub

    Private Sub Txt_CodFuncionario_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CodFuncionario.ButtonCustom2Click
        Txt_CodFuncionario.Tag = String.Empty
        Txt_CodFuncionario.Text = String.Empty
        _Cl_InvSectores.Zw_Inv_Sector.CodFuncionario = String.Empty
    End Sub
End Class
