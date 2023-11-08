Imports DevComponents.DotNetBar
Public Class Frm_Direc_Cli_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Entidad As DataRow
    Dim _Tbl_Direcciones As DataTable
    Dim _Row_Direccion As DataRow
    Dim _Seleccionar As Boolean

    Dim _Rojo, _Azul, _Verde As Color

    Public Property Seleccionar As Boolean
        Get
            Return _Seleccionar
        End Get
        Set(value As Boolean)
            _Seleccionar = value
        End Set
    End Property

    Public Property Row_Direccion As DataRow
        Get
            Return _Row_Direccion
        End Get
        Set(value As DataRow)
            _Row_Direccion = value
        End Set
    End Property

    Public Sub New(_CodEntidad As String, _SucEntidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Entidad = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Direc_Cli_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Btn_Seleccionar_Direccion.Visible = _Seleccionar

        Me.Text = _Row_Entidad.Item("Rut").ToString.Trim & " - " & _Row_Entidad.Item("NOKOEN")

        Dim _CodEntidad As String = _Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad As String = _Row_Entidad.Item("SUEN")

        Chk_EntregaPaletizada.Checked = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades",
                                                          "EntregaPaletizada", "CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'",,,, True)

        Sb_Actualizar_Grilla()

        If Not IsNothing(_Row_Direccion) Then
            BuscarDatoEnGrilla(_Row_Direccion.Item("Direccion"), "Direccion", Grilla)
        End If

        AddHandler Chk_EntregaPaletizada.CheckedChanged, AddressOf Sb_Chk_EntregaPaletizada_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Btn_Editar.Enabled = False
        Btn_Eliminar.Enabled = False

        Consulta_sql = "Select Desp.*,NOKOPA,NOKOCI,NOKOCM,Isnull(Tvta.NombreTabla,'') As Nom_Tipo_Venta,Isnull(NORETI,'') As Nom_Transportista 
                        From " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Desp
                        Left Join TABPA Pa On Pa.KOPA = Pais
                        Left Join TABCI Ci On Ci.KOPA = Pais And Ci.KOCI = Ciudad
                        Left Join TABCM Cm On Cm.KOPA = Pais And Cm.KOCI = Ciudad And Cm.KOCM = Comuna
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tvta On Tvta.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Tvta.CodigoTabla = Tipo_Venta
                        Left Join TABRETI On KORETI = Transportista
                        Where CodEntidad = '" & _Row_Entidad.Item("KOEN") & "' And CodSucEntidad = '" & _Row_Entidad.Item("SUEN") & "' Order By Por_Defecto Desc"
        _Tbl_Direcciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Direcciones

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Direccion").HeaderText = "Dirección"
            .Columns("Direccion").Width = 200
            .Columns("Direccion").Visible = True
            .Columns("Direccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOCM").HeaderText = "Comuna"
            .Columns("NOKOCM").Width = 130
            .Columns("NOKOCM").Visible = True
            .Columns("NOKOCM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOCI").HeaderText = "Ciudad"
            .Columns("NOKOCI").Width = 130
            .Columns("NOKOCI").Visible = True
            .Columns("NOKOCI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nom_Tipo_Venta").HeaderText = "Tipo Venta"
            .Columns("Nom_Tipo_Venta").Width = 100
            .Columns("Nom_Tipo_Venta").Visible = True
            .Columns("Nom_Tipo_Venta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nom_Transportista").HeaderText = "Transportista"
            .Columns("Nom_Transportista").Width = 100
            .Columns("Nom_Transportista").Visible = True
            .Columns("Nom_Transportista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        If Not IsNothing(_Row_Direccion) Then

            Dim _Id = _Row_Direccion.Item("Id")

            For Each _Fila As DataGridViewRow In Grilla.Rows

                If _Id = _Fila.Cells("Id").Value Then
                    _Fila.DefaultCellStyle.BackColor = Color.LightGreen
                    Exit For
                End If

            Next

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Crear_Direccion_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Direccion.Click

        Dim _CodEntidad As String = _Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad As String = _Row_Entidad.Item("SUEN")

        Dim Fm As New Frm_Direc_Cli(_CodEntidad, _CodSucEntidad, 0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id As Integer = _Fila.Cells("Id").Value

        If _Seleccionar Then

            If Not IsNothing(_Row_Direccion) Then

                If _Row_Direccion.Item("Id") = _Id Then
                    Me.Close()
                    Return
                End If

            End If

            Consulta_sql = "Select Top 1 Desp.*,NOKOPA,NOKOCI,NOKOCM,Isnull(Tvta.NombreTabla,'') As Nom_Tipo_Venta,Isnull(NORETI,'') As Nom_Transportista 
                            From " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Desp
                            Left Join TABPA Pa On Pa.KOPA = Pais
                            Left Join TABCI Ci On Ci.KOPA = Pais And Ci.KOCI = Ciudad
                            Left Join TABCM Cm On Cm.KOPA = Pais And Cm.KOCI = Ciudad And Cm.KOCM = Comuna
                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tvta On Tvta.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Tvta.CodigoTabla = Tipo_Venta
                            Left Join TABRETI On KORETI = Transportista
                            Where Id = " & _Id
            _Row_Direccion = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()

        Else

            Dim _CodEntidad As String = _Row_Entidad.Item("KOEN")
            Dim _CodSucEntidad As String = _Row_Entidad.Item("SUEN")

            Dim Fm As New Frm_Direc_Cli(_CodEntidad, _CodSucEntidad, _Id)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Index As Integer = Grilla.CurrentRow.Index
        Dim _Grabar As Boolean

        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _CodEntidad As String = _Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad As String = _Row_Entidad.Item("SUEN")

        Dim Fm As New Frm_Direc_Cli(_CodEntidad, _CodSucEntidad, _Id)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If Not _Grabar Then
            Return
        End If

        If Not IsNothing(_Row_Direccion) Then

            Consulta_sql = "Select Top 1 Desp.*,NOKOPA,NOKOCI,NOKOCM,Isnull(Tvta.NombreTabla,'') As Nom_Tipo_Venta,Isnull(NORETI,'') As Nom_Transportista 
                            From " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Desp
                            Left Join TABPA Pa On Pa.KOPA = Pais
                            Left Join TABCI Ci On Ci.KOPA = Pais And Ci.KOCI = Ciudad
                            Left Join TABCM Cm On Cm.KOPA = Pais And Cm.KOCI = Ciudad And Cm.KOCM = Comuna
                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tvta On Tvta.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Tvta.CodigoTabla = Tipo_Venta
                            Left Join TABRETI On KORETI = Transportista
                            Where Id = " & _Id
            _Row_Direccion = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()
            Return

        End If

        Sb_Actualizar_Grilla()

        Grilla.CurrentCell = Grilla.Rows(_Index).Cells("Direccion")

        Btn_Editar.Enabled = False
        Btn_Eliminar.Enabled = False

        Me.Refresh()

    End Sub

    Private Sub Btn_Seleccionar_Direccion_Click(sender As Object, e As EventArgs) Handles Btn_Seleccionar_Direccion.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Direccion_Agencia_Click(sender As Object, e As EventArgs) Handles Btn_Direccion_Agencia.Click

        Dim Fm As New Frm_Agencia_Entidad(_Row_Entidad.Item("KOEN"), _Row_Entidad.Item("SUEN"))
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()

    End Sub

    Private Sub Sb_Chk_EntregaPaletizada_CheckedChanged(sender As Object, e As EventArgs)

        Dim _CodEntidad As String = _Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad As String = _Row_Entidad.Item("SUEN")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set EntregaPaletizada = " & Convert.ToInt32(Chk_EntregaPaletizada.Checked) & vbCrLf &
                       "Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim Msg As String

        If Chk_EntregaPaletizada.Checked Then
            Msg = "El cliente necesita entrega paletizada"
        Else
            Msg = "El cliente NO necesita entrega paletizada"
        End If

        MessageBoxEx.Show(Me, "Datos actualizados correctamente, no es necesario grabar" & vbCrLf & Msg, "Entrega paletizada", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Chk_EntregaPaletizada.Enabled = False
        Btn_EditarEntregaPaletizada.Enabled = True

    End Sub

    Private Sub Btn_EditarEntregaPaletizada_Click(sender As Object, e As EventArgs) Handles Btn_EditarEntregaPaletizada.Click
        Chk_EntregaPaletizada.Enabled = Fx_Tiene_Permiso(Me, "ODp00019")
        Btn_EditarEntregaPaletizada.Enabled = Not Chk_EntregaPaletizada.Enabled
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id As Integer = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar este registro?", "Eliminar dirección",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Sb_Actualizar_Grilla()

            Btn_Editar.Enabled = False
            Btn_Eliminar.Enabled = False

            Me.Refresh()

        End If

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Btn_Editar.Enabled = True
        Btn_Eliminar.Enabled = True

    End Sub

End Class
