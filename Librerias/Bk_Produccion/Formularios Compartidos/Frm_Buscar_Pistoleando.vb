Imports DevComponents.DotNetBar
Imports BkSpecialPrograms


Public Class Frm_Buscar_Pistoleando

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Filtro_Extra As String
    Dim _Row_Fila As DataRow

    Public ReadOnly Property Pro_Row_Fila() As DataRow
        Get
            Return _Row_Fila
        End Get
    End Property
    Public Property Pro_Filtro_Extra() As String
        Get
            Return _Filtro_Extra
        End Get
        Set(ByVal value As String)
            _Filtro_Extra = value
        End Set
    End Property

    Public Property Pro_Cerrar_automaticamente As Boolean
        Get
            Return _Cerrar_automaticamente
        End Get
        Set(value As Boolean)
            _Cerrar_automaticamente = value
        End Set
    End Property

    Enum Enum_Tipo_Busqueda
        Maquinas
        OT
        Usuario
        Operario_Codigo
        Operario_Clave
    End Enum

    Dim _Tipo_Busqueda As Enum_Tipo_Busqueda
    Dim _Cerrar_automaticamente As Boolean

    Public Sub New(ByVal Tipo_Busqueda As Enum_Tipo_Busqueda)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Tipo_Busqueda = Tipo_Busqueda

        Lbl_Leyenda_01.Text = String.Empty
        Lbl_Leyenda_02.Text = String.Empty

    End Sub

    Private Sub Frm_Buscar_Pistoleando_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Tiempo_Cierre_Automatico.Interval = (1000 * 60) * 2
        Tiempo_Cierre_Automatico.Enabled = _Cerrar_automaticamente

        Select Case _Tipo_Busqueda

            Case Enum_Tipo_Busqueda.Maquinas
                Me.Text = "BUSCAR MAQUINAS"
            Case Enum_Tipo_Busqueda.Operario_Codigo
                Me.Text = "BUSCAR OPERARIO"
            Case Enum_Tipo_Busqueda.Operario_Clave
                Me.Text = "BUSCAR OPERARIO"
                Chk_Ver_Clave.Checked = False
                Chk_Ver_Clave.Visible = True
            Case Enum_Tipo_Busqueda.OT
                Me.Text = "BUSCAR ORDENES DE TRABAJO"
            Case Enum_Tipo_Busqueda.Usuario
                Me.Text = "BUSCAR OPERARIO"

        End Select

        Txt_Numero.Text = String.Empty
        Me.ActiveControl = Txt_Numero

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim _Campo As String
        Dim _Tabla As String

        Select Case _Tipo_Busqueda
            Case Enum_Tipo_Busqueda.Maquinas
                _Campo = "CODMAQ" : _Tabla = "PMAQUI"
            Case Enum_Tipo_Busqueda.OT
                _Campo = "NUMOT" : _Tabla = "POTE"
            Case Enum_Tipo_Busqueda.Usuario
                _Campo = "KOFU" : _Tabla = "TABFU"
            Case Enum_Tipo_Busqueda.Operario_Codigo
                _Campo = "CODIGOOB" : _Tabla = "PMAEOB"
            Case Enum_Tipo_Busqueda.Operario_Clave
                _Campo = "PWFU" : _Tabla = "PMAEOB"
        End Select

        Consulta_sql = "Select Top 1 * From " & _Tabla & vbCrLf & _
                       "Where 1 > 0 And " & _Campo & " = '" & Txt_Numero.Text & "'" & vbCrLf & _
                       _Filtro_Extra

        _Row_Fila = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _Row_Fila Is Nothing Then
            MessageBoxEx.Show(Me, "Registro no encontrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Numero.Text = String.Empty
            Txt_Numero.Focus()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Txt_Numero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Numero.KeyDown

        If e.KeyValue = Keys.Enter Then
            Call Btn_Aceptar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Chk_Ver_Clave_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Ver_Clave.CheckedChanged
        Txt_Numero.UseSystemPasswordChar = Not Chk_Ver_Clave.Checked
    End Sub

    Private Sub Tiempo_Cierre_Automatico_Tick(sender As Object, e As EventArgs) Handles Tiempo_Cierre_Automatico.Tick
        Me.Close()
    End Sub

    Private Sub Frm_Buscar_Pistoleando_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

    End Sub
End Class