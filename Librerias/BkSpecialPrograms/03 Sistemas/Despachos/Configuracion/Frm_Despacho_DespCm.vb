Imports DevComponents.DotNetBar
Public Class Frm_Despacho_DespCm

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Despacho_DespCm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        Consulta_Sql = $"
Select Empresa, Sucursal,Ts.NOKOSU As SucursalStr,Pais,Ciudad,Ci.NOKOCI As 'CiudadStr',Comuna,Cm.NOKOCM As 'ComunaStr',
CodDespacho,Mp.NOKOPR As 'Descripcion'
From {_Global_BaseBk}Zw_Despachos_DespCm DCm
    Inner Join TABSU Ts On Ts.EMPRESA = DCm.Empresa And Ts.KOSU = DCm.Sucursal
        Inner Join TABCI Ci On Ci.KOPA = DCm.Pais And Ci.KOCI = DCm.Ciudad
            Inner Join TABCM Cm On Cm.KOPA = DCm.Pais And Cm.KOCI = DCm.Ciudad And Cm.KOCM = DCm.Comuna
                Inner Join MAEPR Mp On Mp.KOPR = DCm.CodDespacho
Where DCm.Empresa = '{Mod_Empresa}' And DCm.Sucursal = '{Mod_Sucursal}'
Order By DCm.Pais,DCm.Ciudad,DCm.Comuna,DCm.CodDespacho
"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Comunas

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Comunas, True)

            .Columns("CiudadStr").Width = 180
            .Columns("CiudadStr").HeaderText = "Ciudad destino"
            .Columns("CiudadStr").Visible = True
            .Columns("CiudadStr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComunaStr").Width = 170
            .Columns("ComunaStr").HeaderText = "Comuna destino"
            .Columns("ComunaStr").Visible = True
            .Columns("ComunaStr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodDespacho").Width = 100
            .Columns("CodDespacho").HeaderText = "Código"
            .Columns("CodDespacho").Visible = True
            .Columns("CodDespacho").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 270
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_AgregarComuna_Click(sender As Object, e As EventArgs) Handles Btn_AgregarComuna.Click

        Dim _CodPais As String
        Dim _CodCiudad As String
        Dim _CodComuna As String

        Dim _Pais As String
        Dim _Ciudad As String
        Dim _Comuna As String

        Dim _Row_Localidad As DataRow

        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)
        _Row_Localidad = Fm.Row_Localidad
        Fm.Dispose()

        If IsNothing(_Row_Localidad) Then
            Return
        End If

        'MessageBoxEx.Show(Me, "A continuación debe seleccionar el producto de tipo servicio de despacho", "Servicio de despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)

        _CodPais = Fm.Row_Localidad.Item("KOPA")
        _CodCiudad = Fm.Row_Localidad.Item("KOCI")
        _CodComuna = Fm.Row_Localidad.Item("KOCM")

        _Pais = Fm.Row_Localidad.Item("NOKOPA")
        _Ciudad = Fm.Row_Localidad.Item("NOKOCI")
        _Comuna = Fm.Row_Localidad.Item("NOKOCM")


        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Sql_Filtro_Condicion_Extra As String = "And CLALIBPR = 'DESPACHOS'"
        Dim _Row_Producto As DataRow

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            _Row_Producto = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Consulta_Sql = $"
Insert Into {_Global_BaseBk}Zw_Despachos_DespCm (Empresa, Sucursal, Pais, Ciudad, Comuna, CodDespacho) Values 
('{Mod_Empresa}','{Mod_Sucursal}','{_CodPais}','{_CodCiudad}','{_CodComuna}','{_Row_Producto.Item("Codigo")}')"
            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Sb_Actualizar_Grilla()
            End If

        End If


    End Sub

End Class
