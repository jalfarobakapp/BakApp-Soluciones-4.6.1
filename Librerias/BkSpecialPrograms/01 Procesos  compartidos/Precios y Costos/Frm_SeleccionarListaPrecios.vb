Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_SeleccionarListaPrecios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _MultiSeleccion As Boolean

    'Dim _Datos_Lp As New Ds_Especiales
    Dim _Tbl_Listas As DataTable
    Dim _Tbl_Listas_Seleccionadas As DataTable

    Enum Enum_Tipo_Lista
        Costo
        Precio
    End Enum
    Dim _Tipo_Lista As Enum_Tipo_Lista

    Public ReadOnly Property Pro_Tbl_Listas_Seleccionadas() As DataTable
        Get
            Return _Tbl_Listas_Seleccionadas
        End Get
    End Property

    Public Property NoPedirPermiso As Boolean
    Public Property Permiso As String
    Public Property FiltroAdicional As String
    Public Property MostraTodasLasListas As Boolean

    Public Sub New(Tipo_Listas As Enum_Tipo_Lista,
                   Multiseleccion As Boolean,
                   Ver_Mis_Listas As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(GrillaListas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        _Tipo_Lista = Tipo_Listas
        _MultiSeleccion = Multiseleccion

        Consulta_sql = "Delete " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Lp'
                        Insert Into " & _Global_BaseBk & "ZW_Permisos 
                        (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso)
                        Select 'Lp-'+KOLT As CodPermiso,NOKOLT as DescripcionPermiso,'Lp','Listas de precios'
                        From TABPP"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnAceptar.ForeColor = Color.White
        End If

        Rdb_Ver_Mis_Listas.Checked = Ver_Mis_Listas

    End Sub

    Private Sub Frm_SeleccionarListaPrecios_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AddHandler GrillaListas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Parametro_Informe_Sql(False)
        Sb_Llenar_Grilla()

        AddHandler GrillaListas.CellBeginEdit, AddressOf GrillaListas_CellBeginEdit
        AddHandler Rdb_Ver_Todas_Las_Listas.CheckedChanged, AddressOf Sb_Llenar_Grilla
        AddHandler Rdb_Ver_Mis_Listas.CheckedChanged, AddressOf Sb_Llenar_Grilla

    End Sub

    Sub Sb_Llenar_Grilla()

        Consulta_sql = "Select Cast(0 as Bit) As Seleccionada,'Lp-'+KOLT As Permiso,TILT As Tipo,KOLT As Lista,NOKOLT As Nombre_Lista," &
                       "Case When MELT  = 'N' Then 'Netos' Else 'Brutos' End as Valores,MOLT As Moneda" & vbCrLf &
                       "From TABPP" & vbCrLf &
                       "Where 1 > 0" & vbCrLf

        If Not MostraTodasLasListas Then

            Select Case _Tipo_Lista
                Case Enum_Tipo_Lista.Costo
                    Consulta_sql += "And TILT = 'C'"
                Case Enum_Tipo_Lista.Precio
                    Consulta_sql += "And TILT = 'P'"
            End Select

        End If

        If Rdb_Ver_Mis_Listas.Checked Then
            Consulta_sql += "And KOLT In (Select SUBSTRING(CodPermiso,4,6) From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & Space(1) &
                            "Where CodUsuario = '" & FUNCIONARIO & "' And CodPermiso LIKE 'Lp-%')"
        End If

        Consulta_sql += vbCrLf & FiltroAdicional

        _Tbl_Listas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With GrillaListas

            .DataSource = _Tbl_Listas

            OcultarEncabezadoGrilla(GrillaListas, False, , False)

            Dim _DisplayIndex = 0

            If _MultiSeleccion Then
                .Columns("Seleccionada").Width = 50
                .Columns("Seleccionada").HeaderText = "Select."
                .Columns("Seleccionada").Visible = True
                .Columns("Seleccionada").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1
            End If

            .Columns("Lista").Width = 35
            .Columns("Lista").HeaderText = "LP"
            .Columns("Lista").ReadOnly = True
            .Columns("Lista").Visible = True
            .Columns("Lista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Moneda").Width = 45
            .Columns("Moneda").HeaderText = "Mon"
            .Columns("Moneda").ReadOnly = True
            .Columns("Moneda").Visible = True
            .Columns("Moneda").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Lista").Width = 220
            .Columns("Nombre_Lista").HeaderText = "Nombre lista"
            .Columns("Nombre_Lista").ReadOnly = True
            .Columns("Nombre_Lista").Visible = True
            .Columns("Nombre_Lista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valores").Width = 70
            .Columns("Valores").HeaderText = "Valores"
            .Columns("Valores").ReadOnly = True
            .Columns("Valores").Visible = True
            .Columns("Valores").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub GrillaListas_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        If _MultiSeleccion Then

            Dim _Fila As DataGridViewRow = GrillaListas.Rows(GrillaListas.CurrentRow.Index)

            Dim _Permiso As String = _Fila.Cells("Permiso").Value
            Dim _Lista As String = _Fila.Cells("Lista").Value

            If Not NoPedirPermiso Then

                If Not Fx_Tiene_Permiso(Me, _Permiso, , False) Then

                    e.Cancel = True

                    ToastNotification.Show(Me, "NO TIENE PERMISOS PARA TRABAJAR CON LA LISTA " & _Lista, My.Resources.cross,
                               2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                End If

            End If

        End If

    End Sub

    Private Sub GrillaListas_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaListas.CellDoubleClick

        If Not _MultiSeleccion Then

            Dim _Fila As DataGridViewRow = GrillaListas.Rows(GrillaListas.CurrentRow.Index)

            Permiso = _Fila.Cells("Permiso").Value

            Dim _TienePermiso As Boolean

            If NoPedirPermiso Then
                _TienePermiso = True
            Else
                _TienePermiso = Fx_Tiene_Permiso(Me, _Permiso)
            End If

            If Not _TienePermiso Then
                Return
            End If

            'If Fx_Tiene_Permiso(Me, _Permiso) Then

            Dim _Lista = _Fila.Cells("Lista").Value

            Consulta_sql = "Select Cast(1 as Bit) As Seleccionada,'Lp-'+KOLT As Permiso,TILT As Tipo,KOLT As Lista,NOKOLT As Nombre_Lista," &
                            "Case When MELT = 'N' Then 'Netos' Else 'Brutos' End as Valores,MELT As Melt,MOLT as Molt,TIMOLT as Timolt" & vbCrLf &
                            "From TABPP" & vbCrLf &
                            "Where KOLT = '" & _Lista & "'"

            _Tbl_Listas_Seleccionadas = _Sql.Fx_Get_DataTable(Consulta_sql)

            Me.Close()

            'End If

        End If

    End Sub

    Private Sub Frm_SeleccionarListaPrecios_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.Enter Then
            SendKeys.Send("{F2}")
            e.Handled = True
            Call GrillaListas_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click

        If Not _MultiSeleccion Then
            Call GrillaListas_CellDoubleClick(Nothing, Nothing)
        Else

            Dim _Fl As String = Generar_Filtro_IN(_Tbl_Listas, "Seleccionada", "Lista", False, True, "'")

            If _Fl = "" Or _Fl = "()" Then
                MessageBoxEx.Show(Me, "Debe seleccionar una lista para el tratamiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Consulta_sql = "Select * From TABPP Where KOLT In " & _Fl
                _Tbl_Listas_Seleccionadas = _Sql.Fx_Get_DataTable(Consulta_sql)
                Me.Close()
            End If

        End If

    End Sub

    Private Sub GrillaListas_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles GrillaListas.MouseUp
        GrillaListas.EndEdit()
    End Sub

    Private Sub Frm_SeleccionarListaPrecios_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Sb_Parametro_Informe_Sql(True)
    End Sub

    Sub Sb_Parametro_Informe_Sql(_Actualizar As Boolean)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Informe = "SelLista_Precios"

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ver_Mis_Listas, _Informe, Rdb_Ver_Mis_Listas.Name,
                                      Class_SQLite.Enum_Type._Boolean, Rdb_Ver_Mis_Listas.Checked, _Actualizar, "SelLista")

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ver_Todas_Las_Listas, _Informe, Rdb_Ver_Todas_Las_Listas.Name,
                                      Class_SQLite.Enum_Type._Boolean, Rdb_Ver_Todas_Las_Listas.Checked, _Actualizar, "SelLista")

    End Sub

End Class
