'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Enum Tipo_Tabla
        Encabezado
        Detalle
    End Enum

    Enum Tipo_Grabacion
        Nuevo
        Editar
    End Enum

    Dim _Tipo_Tabla As Tipo_Tabla
    Dim _Tipo_Grabacion As Tipo_Grabacion

    Dim _Codigo_Tabla As String

    Public _Grabar As Boolean

    Public Sub New(ByVal Tipo_Tbl As Tipo_Tabla, _
                   ByVal Accion As Tipo_Grabacion, _
                   Optional ByVal Codigo As String = "", _
                   Optional ByVal Descripcion As String = "", _
                   Optional ByVal Codigo_tabla As String = "")

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _Tipo_Tabla = Tipo_Tbl
        _Tipo_Grabacion = Accion
        _Codigo_Tabla = Codigo_tabla
        Txt_Codigo.Text = Codigo
        Txt_Descripcion.Text = Descripcion
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Anotaciones_Tabuladas_03_Crear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Tipo_Grabacion = Tipo_Grabacion.Nuevo Then
            Me.ActiveControl = Txt_Codigo
        ElseIf _Tipo_Grabacion = Tipo_Grabacion.Editar Then
            Txt_Codigo.Enabled = False
            Me.ActiveControl = Txt_Descripcion
        End If

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If _Tipo_Tabla = Tipo_Tabla.Encabezado Then

            If _Tipo_Grabacion = Tipo_Grabacion.Nuevo Then
                Sb_Grabar_Nueva_Tabla()
            ElseIf _Tipo_Grabacion = Tipo_Grabacion.Editar Then
                Sb_Editar_Tabla()
            End If

        ElseIf _Tipo_Tabla = Tipo_Tabla.Detalle Then

            If _Tipo_Grabacion = Tipo_Grabacion.Nuevo Then
                Sb_Grabar_Nuevo_Detalle()
            ElseIf _Tipo_Grabacion = Tipo_Grabacion.Editar Then
                Sb_Editar_Detalle()
            End If

        End If

    End Sub

#Region "PROCEDIMIENTOS TABLA ENCABEZADO"

    Sub Sb_Grabar_Nueva_Tabla()

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABCARAE", "KOTABLA = '" & Txt_Codigo.Text & "'"))

        If Not _Reg Then

            Consulta_sql = "Insert Into TABCARAE (KOTABLA,NOKOTABLA) VALUES ('" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "')"
            If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                'MessageBoxEx.Show(Me, "Datos guardados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Grabar = True
                Me.Close()
            End If

        Else

            Beep()
            ToastNotification.Show(Me, "TABLA YA EXISTE", My.Resources.cross, _
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If

    End Sub

    Sub Sb_Editar_Tabla()

        Consulta_sql = "Update TABCARAE Set NOKOTABLA = '" & Txt_Descripcion.Text & "'" & vbCrLf & _
                       "Where KOTABLA = '" & Txt_Codigo.Text & "'"

        If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            _Grabar = True
            Me.Close()
        End If


    End Sub

#End Region

#Region "PROCEDIMIENTOS TABLA DETALLE"

    Sub Sb_Grabar_Nuevo_Detalle()

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABCARAC", _
                              "KOTABLA = '" & _Codigo_Tabla & "' AND KOCARAC = '" & Txt_Codigo.Text & "'"))

        If Not _Reg Then

            Consulta_sql = "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC,INFOCARA) VALUES " & _
                           "('" & _Codigo_Tabla & "','','" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "','')"
            If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                _Grabar = True
                Me.Close()
            End If

        Else

            Beep()
            ToastNotification.Show(Me, "CLASIFICACION YA EXISTE", My.Resources.cross, _
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    Sub Sb_Editar_Detalle()

        Consulta_sql = "Update TABCARAC Set NOKOCARAC = '" & Txt_Descripcion.Text & "'" & vbCrLf & _
                       "Where KOTABLA = '" & _Codigo_Tabla & "' AND KOCARAC = '" & Txt_Codigo.Text & "'"

        If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            _Grabar = True
            Me.Close()
        End If


    End Sub

#End Region

    Private Sub Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class