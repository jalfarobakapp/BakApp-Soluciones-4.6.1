Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Crear_Conexion

    Public DsConexion As DataSet
    Public Directorio As String
    Public _Primera_Conexion As Boolean

    Dim _Rut, _Razon, _Nombre_Corto As String
    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Btn_Conectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Conectar.Click
        Me.Enabled = False
        Sb_Conectar()
        Me.Enabled = True
    End Sub

    Dim _Teclado As Boolean

    Sub Sb_Conectar()

        Dim Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        Dim SV, PT, BD, US, PW As String

        SV = Txt_Servidor.Text
        PT = Txt_Puerto.Text
        BD = Txt_Base_De_Datos.Text
        US = Txt_Usuario.Text
        PW = Txt_Clave.Text

        If Trim(PT) <> "" Then
            SV = Trim(SV & "," & PT)
        End If

        Cadena = Replace(Cadena, "#SV#", SV)
        Cadena = Replace(Cadena, "#BD#", BD)
        Cadena = Replace(Cadena, "#US#", US)
        Cadena = Replace(Cadena, "#PW#", PW)

        Cadena_ConexionSQL_Server = Cadena

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Try

            Consulta_sql = "SELECT TOP 1 RUT,RAZON,NCORTO FROM CONFIGP"

            Dim Tabla = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim Fila As DataRow
            Fila = Tabla.Rows(0)

            _Rut = Trim(Fila.Item("RUT").ToString)
            _Razon = Trim(Fila.Item("RAZON").ToString)
            _Nombre_Corto = Trim(Fila.Item("NCORTO").ToString)

            Dim Rt = Split(_Rut, "-")

            Dim info As New TaskDialogInfo("Conectar con base de datos", _
                                         eTaskDialogIcon.ShieldOk, _
                                         "CONEXIÓN EXITOSA", _
                                         "la conexión con la base de datos resulto exitosa." & vbCrLf & vbCrLf & _
                                         "Rut: " & FormatNumber(Rt(0), 0) & "-" & Rt(1) & vbCrLf & _
                                         "Empresa: " & _Razon, _
                                         eTaskDialogButton.Ok _
                                         , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            Btn_Grabar.Enabled = True

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Txt_Servidor.SelectAll()
            Txt_Servidor.Focus()
        End Try

    End Sub

    Private Sub Sb_Grabar()

        Dim NombreConexion As String
        Dim Directorio As String = Application.StartupPath & "\Data\"

        If _Primera_Conexion Then

            DsConexion = New ConexionBK
            DsConexion.ReadXml(Directorio & "Conexiones.xml")
            Dim _Aceptado As Boolean

            _Aceptado = Trim(InputBox_Bk(_Fm_Menu_Padre, "Ingrese nombre de conexión", "Grabar conexión", NombreConexion,
                                              False, _Tipo_Mayus_Minus.Mayusculas, 50, True, _Tipo_Imagen.Texto, False))

            If Not _Aceptado Then
                Return
            End If

            Try

                Sb_Ingresar_NuevaFila(Directorio, DsConexion, NombreConexion)
                MessageBoxEx.Show(_Fm_Menu_Padre, "Datos de conexión incorporados correctamente" & vbCrLf & _
                                  "El sistema se cerrara", "Conexión", _
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                End
            Catch ex As Exception
                MessageBoxEx.Show(_Fm_Menu_Padre, ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            End Try
        End If



        Dim Tbl As New DataTable
        Tbl = DsConexion.Tables(0)

        Dim Reg As Integer = 0
        Dim Contador As Integer = 0
        For Each Fila As DataRow In Tbl.Rows

            If Fila.Item("Rut").ToString = _Rut And _
               Fila.Item("Servidor").ToString = Trim(Txt_Servidor.Text) And _
               Fila.Item("Puerto").ToString = Trim(Txt_Puerto.Text) And _
               Fila.Item("Usuario").ToString = Trim(Txt_Usuario.Text) And _
               Fila.Item("Clave").ToString = Txt_Clave.Text And _
               Fila.Item("BaseDeDatos").ToString = Txt_Base_De_Datos.Text Then
                Reg = 1
                Exit For
            End If
            Contador += 1
        Next

        If Reg = 0 Then

            Dim _Aceptado As Boolean

            _Aceptado = Trim(InputBox_Bk(_Fm_Menu_Padre, "Ingrese nombre de conexión", "Grabar conexión", NombreConexion,
                                          False, _Tipo_Mayus_Minus.Mayusculas, 50, True, _Tipo_Imagen.Texto, False))

            If Not _Aceptado Then
                Exit Sub
            End If

            Try

                Sb_Ingresar_NuevaFila(Directorio, DsConexion, NombreConexion)
                MessageBoxEx.Show(_Fm_Menu_Padre, "Datos de conexión incorporados correctamente", "Conexión",
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)

                Dim NewPanel As Empresas_conectadas = Nothing
                NewPanel = New Empresas_conectadas(_Fm_Menu_Padre, False)
                _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

                _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)


            Catch ex As Exception
                MessageBoxEx.Show(_Fm_Menu_Padre, ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK,
                  Windows.Forms.MessageBoxIcon.Stop)
            End Try
        Else
            If MsgBox("Esta empresa ya esta incorporada en el sistema." & vbCrLf &
                       "¿Desea reemplazar los datos de conexión?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Conexión") = MsgBoxResult.Yes Then

                DsConexion.Tables(0).Rows.RemoveAt(Contador)
                DsConexion.WriteXml(Directorio & "Conexiones.xml")

                MessageBoxEx.Show(_Fm_Menu_Padre, "Datos de conexión actulizados correctamente", "Conexión",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If

    End Sub

    Sub Sb_Ingresar_NuevaFila(ByVal _Directorio As String, ByVal _Ds As DataSet, ByVal _Nombre_Conexion As String)

        Dim NewFila As DataRow
        NewFila = _Ds.Tables("CnBakApp").NewRow
        With NewFila
            .Item("NombreConexion") = _Nombre_Conexion
            .Item("Rut") = _Rut
            .Item("Razon") = _Razon
            .Item("NombreCorto") = _Nombre_Corto
            .Item("Servidor") = Txt_Servidor.Text
            .Item("Puerto") = Txt_Puerto.Text
            .Item("Usuario") = Txt_Usuario.Text
            .Item("Clave") = Txt_Clave.Text
            .Item("BaseDeDatos") = Txt_Base_De_Datos.Text
            .Item("TipoConexion") = "SqlServer"
            .Item("Conectado") = False
            DsConexion.Tables("CnBakApp").Rows.Add(NewFila)
        End With

        DsConexion.WriteXml(_Directorio & "Conexiones.xml")

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click
        Sb_Grabar()
    End Sub

    Private Sub Crear_Conexion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddHandler Txt_Servidor.TextChanged, AddressOf Sb_Cambiar_Char
        AddHandler Txt_Puerto.TextChanged, AddressOf Sb_Cambiar_Char
        AddHandler Txt_Base_De_Datos.TextChanged, AddressOf Sb_Cambiar_Char
        AddHandler Txt_Usuario.TextChanged, AddressOf Sb_Cambiar_Char
        AddHandler Txt_Clave.TextChanged, AddressOf Sb_Cambiar_Char

        Btn_Grabar.Enabled = False
        Txt_Servidor.Focus()

    End Sub

    Sub Sb_Cambiar_Char(ByVal sender As System.Object, ByVal e As System.EventArgs)

        _Rut = String.Empty
        _Razon = String.Empty
        _Nombre_Corto = String.Empty

        Btn_Grabar.Enabled = False

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click

        If _Primera_Conexion Then
            End
        Else
            Dim NewPanel As Empresas_conectadas = Nothing
            NewPanel = New Empresas_conectadas(_Fm_Menu_Padre, False)
            NewPanel._Crear_Conexion = True
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

            _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)
        End If

    End Sub

    Private Sub Btn_Teclado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Teclado.Click
        SendKeys.Send("{TAB}")
        If _Teclado Then

            Fx_Activar_Deactivar_Teclado(Me, False, TouchKeyboard1, Txt_Servidor)
            Fx_Activar_Deactivar_Teclado(Me, False, TouchKeyboard1, Txt_Puerto)
            Fx_Activar_Deactivar_Teclado(Me, False, TouchKeyboard1, Txt_Usuario)
            Fx_Activar_Deactivar_Teclado(Me, False, TouchKeyboard1, Txt_Clave)
            Fx_Activar_Deactivar_Teclado(Me, False, TouchKeyboard1, Txt_Base_De_Datos)

            Btn_Teclado.Text = "Ver"
            _Teclado = False
        Else

            Fx_Activar_Deactivar_Teclado(Me, True, TouchKeyboard1, Txt_Servidor)
            Fx_Activar_Deactivar_Teclado(Me, True, TouchKeyboard1, Txt_Puerto)
            Fx_Activar_Deactivar_Teclado(Me, True, TouchKeyboard1, Txt_Usuario)
            Fx_Activar_Deactivar_Teclado(Me, True, TouchKeyboard1, Txt_Clave)
            Fx_Activar_Deactivar_Teclado(Me, True, TouchKeyboard1, Txt_Base_De_Datos)

            Btn_Teclado.Text = "Ocultar"
            _Teclado = True
        End If
        Txt_Servidor.Focus()
    End Sub
End Class
