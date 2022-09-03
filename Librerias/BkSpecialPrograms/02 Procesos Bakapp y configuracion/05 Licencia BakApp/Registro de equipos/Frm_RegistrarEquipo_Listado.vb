Imports DevComponents.DotNetBar

Public Class Frm_RegistrarEquipo_Listado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Mostrar_Solo_Equipo_Local As Boolean
    Dim _Tbl_Equipos As DataTable
    Private _dv As New DataView

    Dim _Solo_Seleccionar As Boolean
    Dim _Row_Estacion_Seleccionada As DataRow

    Enum Enum_Tipo_Estacion
        Normal
        B4A
    End Enum

    Dim _Tipo_Estacion As Enum_Tipo_Estacion

    Public Property Pro_Row_Estacion_Seleccionada As DataRow
        Get
            Return _Row_Estacion_Seleccionada
        End Get
        Set(value As DataRow)
            _Row_Estacion_Seleccionada = value
        End Set
    End Property

    Public Sub New(Mostrar_Solo_Equipo_Local As Boolean, _Tipo_Estacion As Enum_Tipo_Estacion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tipo_Estacion = _Tipo_Estacion
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        _Mostrar_Solo_Equipo_Local = Mostrar_Solo_Equipo_Local

        Btn_Agregar_Movil.Visible = (_Tipo_Estacion = Enum_Tipo_Estacion.B4A)

    End Sub

    Private Sub Frm_RegistrarEquipo_Listado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion = String.Empty
        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _Mostrar_Solo_Equipo_Local Then
            _Condicion = "Where NombreEquipo = '" & _NombreEquipo & "'"
            Txt_Equipo.Enabled = False
        Else

            If _Tipo_Estacion = Enum_Tipo_Estacion.Normal Then
                _Condicion = "Where TipoEstacion <> 'B4A'"
            End If

            If _Tipo_Estacion = Enum_Tipo_Estacion.B4A Then
                _Condicion = "Where TipoEstacion = 'B4A'"
            End If

        End If



        Consulta_sql = "Select *,Case Alias When '' Then NombreEquipo Else Rtrim(Ltrim(Alias))+'... ('+Rtrim(Ltrim(NombreEquipo))+')' End As Equipo,
                        Case TipoEstacion When 'C' then 'Consultor de precios'
                        When 'N' then 'Estación Normal'
                        When 'P' then 'Post-Venta'
                        When 'C1' then 'Caja Pago Documento'
                        When 'Cd' then 'CashDro'
                        When 'Nvv' then 'solo Notas de venta'
                        When 'B4A' then 'Bakapp Movil (B4A)'
                        End As Tipo_De_Estacion
                        From " & _Global_BaseBk & "Zw_EstacionesBkp" & vbCrLf &
                       _Condicion

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Tbl_Equipos = _Ds.Tables(0)

        _dv.Table = _Tbl_Equipos

        With Grilla

            .DataSource = _dv

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("NombreEquipo").Width = 150
            .Columns("NombreEquipo").HeaderText = "Nombre Equipo"
            .Columns("NombreEquipo").Visible = True
            .Columns("NombreEquipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Alias").Width = 200
            .Columns("Alias").HeaderText = "Alias"
            .Columns("Alias").Visible = True
            .Columns("Alias").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo_De_Estacion").Width = 100
            .Columns("Tipo_De_Estacion").HeaderText = "Tipo estación"
            .Columns("Tipo_De_Estacion").Visible = True
            .Columns("Tipo_De_Estacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("IpEstacion").Width = 80
            .Columns("IpEstacion").HeaderText = "Ip Estación"
            .Columns("IpEstacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("IpEstacion").Visible = True
            .Columns("IpEstacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Buscar_Actualizacion_En_FTP").Width = 50
            .Columns("Buscar_Actualizacion_En_FTP").HeaderText = "Buscar Actualización"
            .Columns("Buscar_Actualizacion_En_FTP").Visible = True
            .Columns("Buscar_Actualizacion_En_FTP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value
        Dim _TipoEstacion = _Fila.Cells("TipoEstacion").Value

        If _Solo_Seleccionar Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where Id = " & _Id
            _Row_Estacion_Seleccionada = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()

        Else

            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Editar, _Id, (_TipoEstacion = "B4A"))
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Actualizar_Grilla()
            _dv.RowFilter = String.Format("NombreEquipo+Alias Like '%{0}%'", Txt_Equipo.Text)

        End If

    End Sub

    Private Sub Txt_Equipo_TextChanged(sender As Object, e As EventArgs) Handles Txt_Equipo.TextChanged
        _dv.RowFilter = String.Format("NombreEquipo+Alias Like '%{0}%'", Txt_Equipo.Text)
    End Sub

    Private Sub Btn_Btn_Exportar_Excel_Estaciones_Click(sender As Object, e As EventArgs) Handles Btn_Btn_Exportar_Excel_Estaciones.Click

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Estaciones_Bk")

    End Sub

    Private Sub Btn_Btn_Exportar_Excel_Estaciones_Diablito_Click(sender As Object, e As EventArgs) Handles Btn_Btn_Exportar_Excel_Estaciones_Diablito.Click

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_Impresion"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Estaciones_Bk_ImpDiablito")

    End Sub

    Private Sub Btn_Agregar_Movil_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Movil.Click

        Dim _NombreEquipo As String

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el nombre del equipo", "Agregar Movil", _NombreEquipo, False,,, True, _Tipo_Imagen.Texto)

        If Not _Aceptar Then
            Return
        End If

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp", "NombreEquipo = '" & _NombreEquipo & "'"))

        If _Reg Then
            MessageBoxEx.Show(Me, "Este dispositivo ya se encuentra registrado en la base de datos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Nuevo, 0, True)
        Fm.Pro_Nombre_Equipo = _NombreEquipo
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Dim _Condicion As String

        If _Tipo_Estacion = Enum_Tipo_Estacion.Normal Then
            _Condicion = "Where TipoEstacion <> 'B4A'"
        End If

        If _Tipo_Estacion = Enum_Tipo_Estacion.B4A Then
            _Condicion = "Where TipoEstacion = 'B4A'"
        End If

        Consulta_sql = "Select *,Isnull(NOKOFU,'') As Nomre_Usuario_X_Defecto From " & _Global_BaseBk & "Zw_EstacionesBkp" &
                       "Left Join TABFU On KOFU = KOFU = Usuario_X_Defecto" & vbCrLf &
                        vbCrLf & _Condicion
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Estaciones_Bk")

    End Sub
End Class
