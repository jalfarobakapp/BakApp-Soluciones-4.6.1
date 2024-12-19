Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Diseno_Mapa_Crear_Sector

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Id_Mapa As Integer
    Private _Row_Mapa As DataRow

    Private _Accion As _Enum_Accion
    Enum _Enum_Accion
        Nuevo
        Editar
        Pegar
        Editar_Codigo
    End Enum
    Public Property Id_Sector As Integer
    Public Property Codigo_Sector() As String
        Get
            Return Txt_Codigo_Sector.Text
        End Get
        Set(value As String)
            Txt_Codigo_Sector.Text = value
        End Set
    End Property
    Public Property Nombre_Sector() As String
        Get
            Return Txt_Nombre_Sector.Text
        End Get
        Set(value As String)
            Txt_Nombre_Sector.Text = value
        End Set
    End Property
    Public Property EsCabecera() As Boolean
        Get
            Return Chk_EsCabecera.Checked
        End Get
        Set(value As Boolean)
            Chk_EsCabecera.Checked = value
        End Set
    End Property
    Public Property OblConfimarUbic() As Boolean
        Get
            Return Chk_OblConfimarUbic.Checked
        End Get
        Set(value As Boolean)
            Chk_OblConfimarUbic.Checked = value
        End Set
    End Property
    Public Property SoloUnaUbicacion() As Boolean
        Get
            Return Chk_SoloUnaUbicacion.Checked
        End Get
        Set(value As Boolean)
            Chk_SoloUnaUbicacion.Checked = value
        End Set
    End Property

    Public ReadOnly Property Grabar() As Boolean

    Public Property Es_SubSector As Boolean
    Public Property ModoCreacionSector As Boolean
    Public Property ModoDiseñoMapa As Boolean = True

    Public Sub New(Id_Mapa As Integer, Accion As _Enum_Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Id_Mapa = Id_Mapa
        _Accion = Accion

    End Sub

    Private _Cl_WMS_Sectores As New Cl_WMS_Sectores

    Public Sub New(Id_Mapa As Integer, Id_Sector As Integer)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Id_Sector = Id_Sector

        If CBool(Id_Sector) Then
            _Accion = _Enum_Accion.Editar
        Else
            _Accion = _Enum_Accion.Nuevo
        End If

        _Id_Mapa = Id_Mapa
        ModoCreacionSector = True
        ModoDiseñoMapa = False

        _Cl_WMS_Sectores = New Cl_WMS_Sectores

    End Sub

    Private Sub Frm_Formulario_Diseno_Mapa_Crear_Sector_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If ModoDiseñoMapa Then

            If _Accion = _Enum_Accion.Editar Then
                Txt_Codigo_Sector.Enabled = False
                Me.ActiveControl = Txt_Nombre_Sector
            Else
                Me.ActiveControl = Txt_Codigo_Sector
            End If

            If Es_SubSector Then
                Txt_Codigo_Sector.Text = Replace(Txt_Codigo_Sector.Text, "...", "")
                Txt_Nombre_Sector.Enabled = False
            End If

            Chk_EsCabecera.Visible = Not Es_SubSector

            Chk_OblConfimarUbic.Visible = False
            Chk_SoloUnaUbicacion.Visible = False

        End If

        If ModoCreacionSector Then

            If _Accion = _Enum_Accion.Editar Then

                Dim _Mensaje As LsValiciones.Mensajes = _Cl_WMS_Sectores.Fx_Llenar_Sector(Id_Sector)

                'If Not _Mensaje.EsCorrecto Then
                '    MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Me.Close()
                'End If

                With _Cl_WMS_Sectores.Zw_WMS_Ubicaciones_Sectores

                    Txt_Codigo_Sector.Text = .Codigo_Sector
                    Txt_Nombre_Sector.Text = .Nombre_Sector
                    Chk_EsCabecera.Checked = .EsCabecera
                    Chk_OblConfimarUbic.Checked = .OblConfimarUbic
                    Chk_SoloUnaUbicacion.Checked = .SoloUnaUbicacion

                End With

                Me.ActiveControl = Txt_Nombre_Sector

            Else
                Me.ActiveControl = Txt_Codigo_Sector
            End If

        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Where Id_Mapa = " & _Id_Mapa
        _Row_Mapa = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Formulario_Diseno_Mapa_Crear_Sector_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

        If ModoDiseñoMapa Then
            Sb_Grabar_Diseño_Mapa()
        Else
            Sb_Grabar_Sector()
        End If

    End Sub

    Private Sub Sb_Grabar_Sector()

        Dim _Mensaje As New LsValiciones.Mensajes

        With _Cl_WMS_Sectores.Zw_WMS_Ubicaciones_Sectores

            .Id_Mapa = _Id_Mapa
            .Empresa = _Row_Mapa.Item("Empresa")
            .Sucursal = _Row_Mapa.Item("Sucursal")
            .Bodega = _Row_Mapa.Item("Bodega")
            .Codigo_Sector = Txt_Codigo_Sector.Text.Trim
            .Nombre_Sector = Txt_Nombre_Sector.Text.Trim
            .Es_SubSector = False
            .EsCabecera = Chk_EsCabecera.Checked
            .OblConfimarUbic = Chk_OblConfimarUbic.Checked
            .SoloUnaUbicacion = Chk_SoloUnaUbicacion.Checked

        End With

        Select Case _Accion
            Case _Enum_Accion.Nuevo
                _Mensaje = _Cl_WMS_Sectores.Fx_Crear_Sector()
            Case _Enum_Accion.Editar
                _Mensaje = _Cl_WMS_Sectores.Fx_Editar_Sector()
        End Select

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Id_Sector = _Mensaje.Id

        _Grabar = True
        Me.Close()

    End Sub

    Sub Sb_Grabar_Diseño_Mapa()

        Dim _Codigo_Sector = Txt_Codigo_Sector.Text.Trim

        If String.IsNullOrEmpty(_Codigo_Sector) Then
            MessageBoxEx.Show(Me, "El código no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Codigo_Sector.Focus()
            Return
        End If

        If Es_SubSector Then
            _Codigo_Sector = _Codigo_Sector & "..."
        End If

        If _Accion = _Enum_Accion.Nuevo Then

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & vbCrLf &
                           "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If _Accion = _Enum_Accion.Nuevo Then

                If CBool(_Tbl.Rows.Count) Then
                    MessageBoxEx.Show(Me, "Este sector ya existe, debe copiar y pegar el sector para poder crear otro igual",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

            End If

        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det",
                                                       "Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'")

        If _Reg > 1 Then
            MessageBoxEx.Show(Me, "Existen mas de una ubicación asociada a este sector." & vbCrLf &
                              "Este sector no puede tener solo una ubicación",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Grabar = True
        Me.Close()

    End Sub

End Class
