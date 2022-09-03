Imports DevComponents.DotNetBar

Public Class Frm_DatosConexion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _Grabar As Boolean
    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Enum Enum_Accion
        Nuevo
        Editar
    End Enum

    Dim _Accion As Enum_Accion

    Public Sub New(_Accion As Enum_Accion, _Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Accion = _Accion
        Me._Id = _Id

    End Sub


    Private Sub Frm_DatosConexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_Nombre_Conexion.Enabled = Not (_Accion = Enum_Accion.Editar)
        Btn_Grabar.Enabled = False

    End Sub

    Private Sub Btn_Conectar_Click(sender As Object, e As EventArgs) Handles Btn_Conectar.Click
        Btn_Grabar.Enabled = Me.Fx_Conectar()
        Btn_Conectar.Enabled = Not Btn_Grabar.Enabled
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Nombre_Conexion = Txt_Nombre_Conexion.Text.Trim
        Dim _Servidor = Txt_Servidor.Text.Trim
        Dim _Puerto = Txt_Puerto.Text.Trim
        Dim _Usuario = Txt_Usuario.Text.Trim
        Dim _Clave = Txt_Usuario.Text.Trim
        Dim _BaseDeDatos = Txt_BaseDeDatos.Text.Trim

        If String.IsNullOrEmpty(Txt_Nombre_Conexion.Text) Then
            MessageBoxEx.Show(Me, "Falta el nombre de la conexión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Nombre_Conexion.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Servidor.Text) Then
            MessageBoxEx.Show(Me, "Falta el servidor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Servidor.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Usuario.Text) Then
            MessageBoxEx.Show(Me, "Falta el usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Usuario.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Clave.Text) Then
            MessageBoxEx.Show(Me, "Falta la clave", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Clave.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_BaseDeDatos.Text) Then
            MessageBoxEx.Show(Me, "Falta la base de datos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_BaseDeDatos.Focus()
            Return
        End If

        If _Accion = Enum_Accion.Nuevo Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DbExt_Conexion (Nombre_Conexion,Servidor,Puerto,Usuario,Clave,BaseDeDatos) Values " &
                           "('" & _Nombre_Conexion & "','" & _Servidor & "','" & _Puerto & "','" & _Usuario & "','" & _Clave & "','" & _BaseDeDatos & "')"
        End If

        If _Accion = Enum_Accion.Editar Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DbExt_Conexion Set " &
                           "Servidor = '" & _Servidor & "'," &
                           "Puerto = '" & _Puerto & "'," &
                           "Usuario = '" & _Usuario & "'," &
                           "Clave = '" & _Clave & "'," &
                           "BaseDeDatos = '" & _BaseDeDatos & "' " & vbCrLf &
                           "Where Id = " & _Id
        End If

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Datos actuializados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Grabar = True
            Me.Close()
        End If

    End Sub

    Function Fx_Conectar() As Boolean

        If String.IsNullOrEmpty(Txt_Nombre_Conexion.Text) Then
            MessageBoxEx.Show(Me, "Falta el nombre de la conexión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Servidor.Text) Then
            MessageBoxEx.Show(Me, "Falta el servidor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Usuario.Text) Then
            MessageBoxEx.Show(Me, "Falta el usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Clave.Text) Then
            MessageBoxEx.Show(Me, "Falta la clave", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If String.IsNullOrEmpty(Txt_BaseDeDatos.Text) Then
            MessageBoxEx.Show(Me, "Falta la base de datos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        Dim SV, PT, BD, US, PW As String

        SV = Txt_Servidor.Text
        PT = Txt_Puerto.Text
        BD = Txt_BaseDeDatos.Text
        US = Txt_Usuario.Text
        PW = Txt_Clave.Text

        If Trim(PT) <> "" Then
            SV = Trim(SV & "," & PT)
        End If

        Cadena = Replace(Cadena, "#SV#", SV)
        Cadena = Replace(Cadena, "#BD#", BD)
        Cadena = Replace(Cadena, "#US#", US)
        Cadena = Replace(Cadena, "#PW#", PW)

        Dim _New_Cadena_ConexionSQL_Server = Cadena

        Dim _Sql As New Class_SQL(_New_Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Try

            Consulta_sql = "SELECT TOP 1 RUT,RAZON,NCORTO FROM CONFIGP"

            Dim Tabla = _Sql.Fx_Get_Tablas(Consulta_sql)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Return False
            End If

            Dim Fila As DataRow
            Fila = Tabla.Rows(0)

            Dim _Rut = Fila.Item("RUT").ToString.Trim
            Dim _Razon = Fila.Item("RAZON").ToString.Trim
            Dim _Nombre_Corto = Fila.Item("NCORTO").ToString.Trim

            Dim Rt = Split(_Rut, "-")

            Dim info As New TaskDialogInfo("Conectar con base de datos",
                                         eTaskDialogIcon.ShieldOk,
                                         "CONEXIÓN EXITOSA",
                                         "la conexión con la base de datos resulto exitosa." & vbCrLf & vbCrLf &
                                         "Rut: " & FormatNumber(Rt(0), 0) & "-" & Rt(1) & vbCrLf &
                                         "Empresa: " & _Razon,
                                         eTaskDialogButton.Ok _
                                         , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            Return True

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Txt_Servidor.SelectAll()
            Txt_Servidor.Focus()
        End Try

    End Function

End Class
