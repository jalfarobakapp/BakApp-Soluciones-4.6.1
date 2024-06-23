Imports DevComponents.DotNetBar
Imports System.Drawing
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_ProveedoresVSMarcas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Tbl_Marcas As DataTable
    Dim _Seleccionar_Mr As Boolean
    Dim _Seleccionada As Boolean
    Dim _Marca_Seleccionada As String
    Dim _Mostrar_Mensaje As Boolean

    Public Property Pro_Tbl_Marcas As DataTable
        Get
            Return _Tbl_Marcas
        End Get
        Set(value As DataTable)
            _Tbl_Marcas = value
        End Set
    End Property
    Public Property Pro_Seleccionar_Mr As Boolean
        Get
            Return _Seleccionar_Mr
        End Get
        Set(value As Boolean)
            _Seleccionar_Mr = value
        End Set
    End Property
    Public Property Pro_Seleccionada As Boolean
        Get
            Return _Seleccionada
        End Get
        Set(value As Boolean)
            _Seleccionada = value
        End Set
    End Property
    Public Property Pro_Marca_Seleccionada As String
        Get
            Return _Marca_Seleccionada
        End Get
        Set(value As String)
            _Marca_Seleccionada = value
        End Set
    End Property
    Public Property Pro_Mostrar_Mensaje As Boolean
        Get
            Return _Mostrar_Mensaje
        End Get
        Set(value As Boolean)
            _Mostrar_Mensaje = value
        End Set
    End Property

    Private Sub BtnAgregarMarcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarMarcas.Click

        If Fx_Tiene_Permiso(Me, "CfEnt010") Then
            Consulta_sql = "Select CodMarca as Codigo,Marca as Descripcion From Zw_MrVsPro Where CodProveedor = '" & TxtCodigo.Text & "' "
            Dim _Tbl_Marcas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Sql_Filtro_Condicion_Extra = String.Empty

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Tbl_Marcas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Marcas, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

                _Tbl_Marcas = _Filtrar.Pro_Tbl_Filtro

                Dim _Filtro = Generar_Filtro_IN(_Tbl_Marcas, "Chk", "Codigo", False, True, "'")

                Consulta_sql = "Delete Zw_MrVsPro Where CodProveedor = '" & TxtCodigo.Text & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If _Filtro <> "()" Then
                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_MrVsPro (CodMarca,Marca,CodProveedor)" & vbCrLf &
                                   "Select Rtrim(LTrim(CodigoTabla)),SubString(DescripcionTabla,1,20) as DescripcionTabla,'" & TxtCodigo.Text & "'" & vbCrLf &
                                   "From Zw_TablaDeCaracterizaciones" & vbCrLf &
                                   "Where Tabla = 'MARCAS' And CodigoTabla In " & _Filtro
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

                Sb_ActualizarGrillas()
            End If

        End If

    End Sub

    Sub Sb_ActualizarGrillas()

        Consulta_sql = "Select Marca,(Select top 1 NOKOMR From TABMR Where KOMR = Marca) As DesMarca,CodProveedor" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_MrVsPro" & vbCrLf &
                       "Where CodProveedor = '" & TxtCodigo.Text & "'" & vbCrLf &
                       "Order by Marca"
        _Tbl_Marcas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Marcas
            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Marca").Width = 120
            .Columns("Marca").HeaderText = "Código Marca"
            .Columns("Marca").Visible = True

            .Columns("DesMarca").Width = 490
            .Columns("DesMarca").HeaderText = "Marca"
            .Columns("DesMarca").Visible = True

        End With

    End Sub

    Private Sub Frm_ProveedoresVSMarcas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If _Mostrar_Mensaje Then
            Beep()
            ToastNotification.Show(Me, "EL PRODUCTO SE DEBE CREAR" & vbCrLf & _
                                   "DEBE SELECCIONAR UNA MARCA DEL PROVEEDOR PARA EL PRODUCTO", My.Resources.ok_button, _
                                   3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If

        Sb_ActualizarGrillas()

    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If _Seleccionar_Mr Then

            _Marca_Seleccionada = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Marca").Value)

            _Seleccionada = True
            Me.Close()
        End If

    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Sb_ActualizarGrillas()
    End Sub

    Private Sub BtnCrearMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrearMarca.Click

        If Fx_Tiene_Permiso(Me, "Tbl00016") Then

            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Marcas,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "MARCAS"
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class