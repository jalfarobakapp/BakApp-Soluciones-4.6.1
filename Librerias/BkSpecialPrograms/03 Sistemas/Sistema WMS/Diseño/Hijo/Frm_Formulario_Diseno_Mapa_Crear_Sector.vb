Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Diseno_Mapa_Crear_Sector

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Mapa As Integer
    Dim _Grabar As Boolean

    Dim _Accion As _Enum_Accion
    Enum _Enum_Accion
        Nuevo
        Editar
        Pegar
        Editar_Codigo
    End Enum

    Public Property Pro_Codigo_Sector() As String
        Get
            Return Txt_Codigo_Sector.Text
        End Get
        Set(value As String)
            Txt_Codigo_Sector.Text = value
        End Set
    End Property

    Public Property Pro_Nombre_Sector() As String
        Get
            Return Txt_Nombre_Sector.Text
        End Get
        Set(value As String)
            Txt_Nombre_Sector.Text = value
        End Set
    End Property

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Es_SubSector As Boolean
    Public Sub New(Id_Mapa As Integer, Accion As _Enum_Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Id_Mapa = Id_Mapa
        _Accion = Accion

    End Sub

    Private Sub Frm_Formulario_Diseno_Mapa_Crear_Sector_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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

    End Sub

    Private Sub Frm_Formulario_Diseno_Mapa_Crear_Sector_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

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

        _Grabar = True
        Me.Close()

    End Sub
End Class
