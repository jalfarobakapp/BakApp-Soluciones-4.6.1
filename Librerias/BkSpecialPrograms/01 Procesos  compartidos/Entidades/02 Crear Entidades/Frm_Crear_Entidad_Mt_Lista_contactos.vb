Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_Lista_contactos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    'Dim _Crear_Editar_Eliminar As Boolean
    Dim _CodEntidad As String
    Dim _SucEntidad As String

    Dim _Tbl_ListaContactos As DataTable
    Dim _Tbl_DatosContacto As DataTable

    Dim _ContactoSeleccionado As Boolean
    Dim _Seleccionar_Contacto As Boolean

    'Public Property Pro_Crear_Editar_Eliminar As Boolean
    '    Get
    '        Return _Crear_Editar_Eliminar
    '    End Get
    '    Set(value As Boolean)
    '        _Crear_Editar_Eliminar = value
    '    End Set
    'End Property
    Public Property Pro_CodEntidad As String
        Get
            Return _CodEntidad
        End Get
        Set(value As String)
            _CodEntidad = value
        End Set
    End Property
    Public Property Pro_SucEntidad As String
        Get
            Return _SucEntidad
        End Get
        Set(value As String)
            _SucEntidad = value
        End Set
    End Property

    Public Property Pro_Tbl_ListaContactos As DataTable
        Get
            Return _Tbl_ListaContactos
        End Get
        Set(value As DataTable)
            _Tbl_ListaContactos = value
        End Set
    End Property
    Public Property Pro_Tbl_DatosContacto As DataTable
        Get
            Return _Tbl_DatosContacto
        End Get
        Set(value As DataTable)
            _Tbl_DatosContacto = value
        End Set
    End Property

    Public Property Pro_ContactoSeleccionado As Boolean
        Get
            Return _ContactoSeleccionado
        End Get
        Set(value As Boolean)
            _ContactoSeleccionado = value
        End Set
    End Property

    Public Sub New(_Seleccionar_Contacto As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Seleccionar_Contacto = _Seleccionar_Contacto
        Sb_Formato_Generico_Grilla(GrillaContactos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Lista_contactos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Llenar_Contactos_Entidad()

        If _Seleccionar_Contacto Then
            Me.Text = "Lista de contactos de la entidad: " & Trim(_Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _CodEntidad & "'"))
        Else
            Me.Text = "SELECCIONE UN CONTACTO"
        End If

    End Sub

    Private Sub GrillaContactos_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrillaContactos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

#Region "Procedimientos"

    Sub Sb_Llenar_Contactos_Entidad()



        Consulta_Sql = "SELECT KOEN,RUTCONTACT,NOKOCON,FONOCON,FAXCON,EMAILCON,AREACON,CARGOCON," & vbCrLf &
                       "ISNULL((SELECT NOKOCARAC FROM TABCARAC WHERE KOTABLA = 'AREASACTIV' AND KOCARAC = AREACON),'') AS AREA," & vbCrLf &
                       "ISNULL((SELECT NOKOCARAC FROM TABCARAC WHERE KOTABLA = 'CARGOS' AND KOCARAC = CARGOCON),'') AS CARGO" & vbCrLf &
                       "FROM MAEENCON" & vbCrLf &
                       "WHERE KOEN = '" & _CodEntidad & "'"


        With GrillaContactos
            .DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)

            OcultarEncabezadoGrilla(GrillaContactos, True)

            .Columns("RUTCONTACT").HeaderText = "Rut (Código)"
            .Columns("RUTCONTACT").Width = 120
            .Columns("RUTCONTACT").Visible = True

            .Columns("NOKOCON").HeaderText = "Contacto"
            .Columns("NOKOCON").Width = 400
            .Columns("NOKOCON").Visible = True

        End With

        TxtTelefono.Text = String.Empty
        TxtFax.Text = String.Empty
        TxtEmail.Text = String.Empty
        TxtArea.Text = String.Empty
        TxtCargo.Text = String.Empty

        GrillaContactos.Focus()

    End Sub

    Sub Sb_Editar_Contacto()
        If CBool(GrillaContactos.RowCount) Then
            If Fx_Tiene_Permiso(Me, "CfEnt012") Then
                Dim _RutContacto As String = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("RUTCONTACT").Value
                Dim Fm As New Frm_Crear_Entidad_Mt_Crear_Contactos
                Fm._CodEntidad = _CodEntidad
                Fm.Sb_Llenar_Contacto(_RutContacto)
                Fm.ShowDialog(Me)

                If Fm._DatosActualizados Then
                    Sb_Llenar_Contactos_Entidad()
                End If
                Fm.Dispose()
            End If
        End If
    End Sub

    Sub Sb_Eliminar_Contacto()
        If CBool(GrillaContactos.RowCount) Then
            Dim _RutContacto As String = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("RUTCONTACT").Value
            Dim Fm As New Frm_Crear_Entidad_Mt_Crear_Contactos
            Fm._CodEntidad = _CodEntidad

            If Fm.Fx_Eliminar_Contacto(_CodEntidad, _RutContacto) Then
                Sb_Llenar_Contactos_Entidad()
            End If
            GrillaContactos.Focus()
            Fm.Dispose()
        End If
    End Sub

#End Region

    Private Sub BtnCrearContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrearContacto.Click
        If Fx_Tiene_Permiso(Me, "CfEnt011") Then
            Dim Fm As New Frm_Crear_Entidad_Mt_Crear_Contactos
            Fm._CodEntidad = _CodEntidad
            Fm._Crear = True
            Fm.ShowDialog(Me)
            If Fm._DatosActualizados Then
                Sb_Llenar_Contactos_Entidad()
            End If
        End If
    End Sub

    Private Sub GrillaContactos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaContactos.CellContentDoubleClick

        If _Seleccionar_Contacto Then
            _Tbl_DatosContacto = Fx_Buscar_Contacto(_CodEntidad)
            _ContactoSeleccionado = True
            Me.Close()
            Return
        End If

        'If _Crear_Editar_Eliminar Then
        Sb_Editar_Contacto()
        'Else
        '    _Tbl_DatosContacto = Fx_Buscar_Contacto(_CodEntidad)
        '    _ContactoSeleccionado = True
        '    Me.Close()
        'End If

    End Sub


    Private Sub GrillaContactos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaContactos.CellEnter

        Try
            TxtTelefono.Text = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("FONOCON").Value
            TxtFax.Text = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("FAXCON").Value
            TxtEmail.Text = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("EMAILCON").Value
            TxtArea.Text = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("AREA").Value
            TxtCargo.Text = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("CARGO").Value
        Catch ex As Exception
            TxtTelefono.Text = String.Empty
            TxtFax.Text = String.Empty
            TxtEmail.Text = String.Empty
            TxtArea.Text = String.Empty
            TxtCargo.Text = String.Empty
        End Try
    End Sub

    Public Function Fx_Buscar_Contacto(ByVal _CodEntidad As String) As DataTable

        Dim _RutContacto As String = GrillaContactos.Rows(GrillaContactos.CurrentRow.Index).Cells("RUTCONTACT").Value

        Consulta_Sql = "Select * From MAEENCON Where KOEN = '" & _CodEntidad &
                       "' AND RUTCONTACT = '" & _RutContacto & "'"
        _Tbl_DatosContacto = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Return _Tbl_DatosContacto

    End Function

    Private Sub Frm_Crear_Entidad_Mt_Lista_contactos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Editar_Contacto_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Contacto.Click
        Sb_Editar_Contacto()
    End Sub

    Private Sub Btn_Eliminar_Contacto_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Contacto.Click
        Sb_Eliminar_Contacto()
    End Sub
End Class
