Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
Imports System.IO

Public Class Frm_ConexionBD

    Dim DatosConex As New ConexionBK
    Public NombreConexionActiva As String
    Dim Directorio As String = Application.StartupPath & "\Data\"

    Dim Rut, Razon, Ncorto As String

    Dim _TblConexiones As DataTable
    Dim _RowConexion As DataRow

    Public ReadOnly Property Pro_RowConexion() As DataRow
        Get
            Return _RowConexion
        End Get
    End Property

    Private Sub BtnxSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnxSalir.Click
        RutEmpresaActiva = ""
        Me.Close()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Dim exists As Boolean = System.IO.File.Exists(AppPath(True) & "BakApp.sct")

        If exists Then
            Dim Llave As String = "BakApp Soluciones"
            'BtnGenerateKey.Visible = RevisarLlave_BakApp(Llave, "BakApp")
        Else
            BtnGenerateKey.Visible = False
        End If

    End Sub

    Private Sub Frm_ConexionesBD_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Directorio = Application.StartupPath
        Dim infoDirectorio As New DirectoryInfo(Directorio)
        ' Obtener el directorio padre
        Dim directorioPadre As DirectoryInfo = infoDirectorio.Parent

        ' Si necesitas la ruta como string
        Dim rutaDirectorioPadre As String = directorioPadre.FullName
        Directorio = rutaDirectorioPadre & "\Data\"

        DatosConex.ReadXml(Directorio & "Conexiones.xml")
        ActualizarGrilla()
        Grilla.Focus()

    End Sub

    Sub ActualizarGrilla()

        'DatosConex.WriteXml(AppPath() & "\Data\filename.xml") 'Documento_vta
        'tb = New DataTable
        _TblConexiones = DatosConex.Tables("CnBakApp")


        With Grilla

            .DataSource = Nothing
            .DataSource = _TblConexiones

            .Columns("Razon").Visible = False
            .Columns("TipoConexion").Visible = False

            .Columns("Servidor").Visible = False
            .Columns("Puerto").Visible = False
            .Columns("Usuario").Visible = False
            .Columns("NombreCorto").Visible = False
            .Columns("Clave").Visible = False


            .Columns("Rut").Width = 100
            .Columns("Rut").HeaderText = "Rut"

            .Columns("NombreConexion").Width = 280
            .Columns("NombreConexion").HeaderText = "Nombre de conexión"

            .Columns("BaseDeDatos").Width = 130
            .Columns("BaseDeDatos").HeaderText = "Base de Datos"

        End With

        MarcarGrilla()

    End Sub

    Sub MarcarGrilla()
        With Grilla
            Dim Contador As Integer
            For Each row As DataGridViewRow In .Rows
                If .Rows(Contador).Cells("TipoConexion").Value <> "SqlServer" Then
                    .Rows(Contador).Visible = False
                End If
                Contador += 1
            Next
        End With
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        SeleccionarEmpresa()
    End Sub

    Private Sub Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter
        TxtRazon.Text = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Razon").Value
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregar.Click
        'Dim FM As New Frm_ConexionBD_02
        'FM.DsConexion = DatosConex
        'FM.Directorio = Directorio
        'FM.ShowDialog(Me)
        'ActualizarGrilla()
    End Sub

    Private Sub Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Enter Then

            SendKeys.Send("{TAB}")
            e.Handled = True

            SeleccionarEmpresa()

        End If
    End Sub

    'Sub GenerarKeyEmpresa()
    '    Try

    '        Dim Dst_ As New Dst_Llave_Sistema_


    '        RutEmpresaActiva = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Rut").Value
    '        Razon = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Razon").Value
    '        Ncorto = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreCorto").Value


    '        Dim FechaCaduc As Date
    '        FechaCaduc = InputBox("Ingrese fecha de caducidad del sistema", "Generación de Licencia de uso")

    '        Dim Llave As String = Trim(RutEmpresaActiva) & "_" & Trim(Razon) & ";" & FechaCaduc
    '        Dim Licencia As String = Encripta_md5(Llave)


    '        Dim NewFila As DataRow
    '        NewFila = Dst_.Tables("Empresa").NewRow
    '        With NewFila

    '            .Item("Rut") = RutEmpresaActiva
    '            .Item("Razon") = Razon
    '            .Item("NombreCorto") = String.Empty
    '            .Item("Comuna") = String.Empty
    '            .Item("Pais") = String.Empty
    '            .Item("Ciudad") = String.Empty
    '            .Item("Comuna") = String.Empty
    '            .Item("Giro") = String.Empty
    '            .Item("Licencia") = Licencia
    '            .Item("Fecha_Expiracion") = FechaCaduc
    '            .Item("Expira") = True

    '            Dst_.Tables("Empresa").Rows.Add(NewFila)
    '        End With


    '        Dst_.WriteXml(AppPath() & "\Data\" & RutEmpresa & "\Licencia.xml") 'Documento_vta
    '        Dim sr As New System.IO.StreamReader(AppPath() & "\Data\" & RutEmpresa & "\Licencia.xml")

    '        Llave = sr.ReadToEnd
    '        sr.Dispose()
    '        Directorio = AppPath() & "\Data\" ' & RutEmpresaActiva

    '        Dim fsDecrypted As New StreamWriter(Directorio & "LlaveBk.txt")
    '        fsDecrypted.Write(Llave)
    '        fsDecrypted.Flush()
    '        fsDecrypted.Dispose()
    '        fsDecrypted.Close()
    '        'BtnGenerateKey.Visible = RevisarLlave_BakApp(Llave, RutEmpresaActiva)

    '        'RealizarEnCryp(RutEmpresaActiva)

    '        MessageBoxEx.Show("Key generada correctamente", "Key-Gen BakApp", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        Kill(Directorio & "LlaveBk.txt")

    '        '    My.Computer.FileSystem.DeleteFile(Directorio & "LlaveBk.txt")
    '    Catch ex As Exception
    '        MessageBoxEx.Show(ex.Message, "Error en el ingreso de datos [Error Nro " & Err.Number & "]", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    '    'Me.Close()

    'End Sub

    Sub SeleccionarEmpresa(Optional _Mostrar_Info As Boolean = False)

        RutEmpresaActiva = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Rut").Value
        NombreConexionActiva = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreConexion").Value

        Dim _Tbl = New DataTable
        _Tbl = DatosConex.Tables("CnBakApp")

        For Each _Fila As DataRow In _Tbl.Rows
            Dim _NombreConexion = Trim(_Fila.Item("NombreConexion"))
            If Not _Fila.Item("Conectado") Then
                If _NombreConexion = NombreConexionActiva Then
                    _Fila.Item("Conectado") = True
                Else
                    _Fila.Item("Conectado") = False
                End If
            End If
        Next

        DatosConex.WriteXml(Directorio & "Conexiones.xml")

        Dim Rt = Split(RutEmpresaActiva, "-")
        Razon = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Razon").Value
        Ncorto = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreCorto").Value

        For Each _Fila As DataRow In _TblConexiones.Rows

            Dim _NombreConexion As String = _Fila.Item("NombreConexion")

            If _NombreConexion = NombreConexionActiva Then
                _RowConexion = _Fila
                Exit For
            End If

        Next

        If _Mostrar_Info Then

            Dim info As New TaskDialogInfo("Conectar con base de datos",
                                             eTaskDialogIcon.ShieldOk,
                                             Ncorto,
                                             "la conexión con la base de datos resulto exitosa." & vbCrLf & vbCrLf &
                                             "Rut: " & FormatNumber(Rt(0), 0) & "-" & Rt(1) & vbCrLf &
                                             "Empresa: " & Razon,
                                             eTaskDialogButton.Ok _
                                             , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

        End If

        Me.Close()

    End Sub





    Private Sub TxtRazon_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtRazon.KeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Down Or e.KeyValue = Keys.Up Then
            Grilla.Focus()
        End If

    End Sub



    Private Sub BtnGenerateKey_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerateKey.Click

        'Dim _NombreConexion As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreConexion").Value

        'Cadena_ConexionSQL_Server = Fx_CadenaConexionSQL(_NombreConexion, DatosConex)

        'Dim Fm As New Frm_Licencia_Empresa
        'Fm.ShowDialog(Me)

    End Sub

    Private Sub Frm_ConexionBD_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            RutEmpresaActiva = ""
            Me.Close()
        End If
    End Sub
End Class
