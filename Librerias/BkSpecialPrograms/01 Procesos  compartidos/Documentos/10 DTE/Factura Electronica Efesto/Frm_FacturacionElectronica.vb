﻿Imports System.IO
Imports System.Text
Imports DevComponents.DotNetBar
Imports Ionic.Zip

Public Class Frm_FacturacionElectronica

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub Frm_FacturacionElectronica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If File.Exists(AppPath() & "\Dte.zip") Then

            Dim _AppPath = AppPath()

            If Not Directory.Exists(_AppPath & "\Data\Dte") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\Dte")
            End If

            If Not Directory.Exists(_AppPath & "\DocumentosSII") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\DocumentosSII")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos\Boleta") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos\Boleta")
            End If

            Dim _Fullpath = _AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos"

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF")
            End If

            Try

                Using Zip As ZipFile = ZipFile.Read(_AppPath & "\Dte.zip")
                    Zip.ExtractAll(AppPath())
                End Using

                'RarArchive.WriteToDirectory(_AppPath & "\Dte.Rar", AppPath() & "\Dte", ExtractOptions.Overwrite)

                'Copiamos la carpeta DocumentosSII en la raiz del sistema
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\DocumentosSII", _AppPath & "\DocumentosSII", True)
                'Copiamos la carpeta Dte dentro de la carpeta Data
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\Dte", _AppPath & "\Data\Dte", True)
                'Copiamos la carpeta Documentos dentro de la carpete DTE de la empresa
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\Documentos", _AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos", True)

                My.Computer.FileSystem.DeleteDirectory(AppPath() & "\Dtes", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception

            End Try

        End If

        Chk_AmbienteCertificacion.Checked = _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion")

    End Sub

    Private Sub Btn_Consumo_Folios_Click(sender As Object, e As EventArgs) Handles Btn_Consumo_Folios.Click

        Dim Fm As New Frm_Dte_ConsumoFolios
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Enviar_Documento_SII_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Documento_SII.Click

        'Dim _Resultado As String
        'Dim _Trackid As String
        'Dim _Class_DTE As New Class_Genera_DTE_RdBk(Txt_Idmaeedo.Text.Trim)

        'If _Class_DTE.Fx_Enviar_DTE_Al_SII(Txt_Idmaeedo.Text, _Resultado) Then
        '    _Trackid = _Resultado
        '    MessageBoxEx.Show(Me, _Trackid, "Trackid", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBoxEx.Show(Me, _Resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

        '6917909140
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        'Dim _Resultado As String
        'Dim _Class_DTE As New Class_Genera_DTE_RdBk(Txt_Idmaeedo.Text.Trim)

        'If _Class_DTE.Fx_Consultar_Trackid(Txt_Trackid.Text, _Resultado) Then
        '    MessageBoxEx.Show(Me, _Resultado, "Respuesta SII", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBoxEx.Show(Me, _Resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

    End Sub

    Private Sub Btn_Notificacion_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Notificacion_Correo.Click

        'Dim _Resultado As String
        'Dim _Class_DTE As New Class_Genera_DTE_RdBk(Txt_Idmaeedo.Text.Trim)

        'If _Class_DTE.Fx_Consultar_Trackid(Txt_Trackid.Text, _Resultado) Then

        '    Dim _Koen = _Class_DTE.Maeedo.Rows(0).Item("ENDO")
        '    Dim _Suen = _Class_DTE.Maeedo.Rows(0).Item("SUENDO")

        '    Dim _Para = _Class_DTE.Maeen.Rows(0).Item("EMAIL").ToString.Trim
        '    Dim _EnvioCorreo As String = _Class_DTE.Fx_Enviar_Notificacion_Correo_Al_Diablito(Txt_Idmaeedo.Text.Trim, _Para, "", Txt_Id_Trackid.Text)

        '    'MessageBoxEx.Show(Me, _Resultado, "Respuesta SII", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBoxEx.Show(Me, _Resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

    End Sub



    Private Sub Btn_CAF_Click(sender As Object, e As EventArgs) Handles Btn_CAF.Click

        Dim Fm As New Frm_Folios_Caf
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_FirmarYEnviarAlSII_Click(sender As Object, e As EventArgs) Handles Btn_FirmarYEnviarAlSII.Click

        Dim _Class_DTE As New Class_Genera_DTE_RdBk(Txt_Idmaeedo.Text.Trim)
        Dim _Id_Dte As Integer

        Try
            If _Class_DTE.Fx_Timbrar_Y_Enviar_DTE_SII_Hefesto(_Id_Dte, Me) Then

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Btn_Firmar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Firmar_Documento.Click

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Dim _AmbienteCertificacion As Integer = Convert.ToInt32(Chk_AmbienteCertificacion.Checked)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Firmar" & vbCrLf &
                       "Where Firmar = 1 And AmbienteCertificacion = " & _AmbienteCertificacion
        Dim _RowFirmar As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowFirmar) Then

            Dim _Id As Integer = _RowFirmar.Item("Id")
            Dim _Idmaeedo As Integer = _RowFirmar.Item("Idmaeedo")
            Dim _Tido As String = _RowFirmar.Item("Tido")
            Dim _Nudo As String = _RowFirmar.Item("Nudo")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Firmar = 0 Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

            Dim _Id_Dte As Integer = _Class_DTE.Fx_Timbrar_Documento_Hefesto(Me)

            If CBool(_Id_Dte) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Id_Dte = " & _Id_Dte & " Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)
            Else
                If CBool(_Class_DTE.Pro_Errores.Count) Then
                    Dim Log_Error As String
                    For Each _Error As String In _Class_DTE.Pro_Errores
                        Log_Error += _Error & vbCrLf
                    Next
                    Dim _NewLog_Error = Replace(Log_Error, "'", "''")
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Log_Error = '" & _NewLog_Error & "' Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If
            End If

        End If

    End Sub

    Enum Enum_Accion
        EnviarBoletaSII
        ConsultarTrackid
    End Enum

    Private Sub Btn_Enviar_Boleta_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Boleta.Click

        ' PARAMETROS 

        '1 _Empresa = Environment.GetCommandLineArgs(2)
        '2 _AmbienteCertificacion = Environment.GetCommandLineArgs(3)
        '3 _Id_Dte = Environment.GetCommandLineArgs(4)
        '4 _Trackid = Environment.GetCommandLineArgs(5)
        '5 _Accion = Environment.GetCommandLineArgs(6)

        ' Parametros para ejecutar BoletaBkHf.exe

        ' Se necesitan 5 parametros
        ' 1.- Empresa '01' -- String
        ' 2.- Ambiente cetificación: -- Numerico
        '  	 1 = Ambiente cetificación
        '	 0 = Producción
        ' 3.- Id_Dte Numerico -- Numerico
        ' 4.- Trackid -- Numerico
        ' 5.- Tipo de ejecución:  -- Numerico
        '	 0 = Enviar boleta
        '	 1 = Consultar Trackid

        ' Ejemplo consultar trackid: 
        ' \\BoletaBkHf.exe" 01 1 0 18499665 1

        ' Ejemplo enviar boleta al SII:
        ' \\BoletaBkHf.exe" 01 1 4 0 0

        Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
        Dim _Id_Dte As Integer = Txt_Id_Dte.Text
        Dim _Trackid As String = "0"
        Dim _Accion As Enum_Accion = Enum_Accion.EnviarBoletaSII

        Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
        Dim _Ejecutar As String = Application.StartupPath & "\BoletaSII\BoletaBkHf.exe" &
                                                                                Space(1) & ModEmpresa &
                                                                                Space(1) & _AmbienteCertificacion &
                                                                                Space(1) & _Id_Dte &
                                                                                Space(1) & _Trackid &
                                                                                Space(1) & _Accion

        Try
            Shell(_Ejecutar, AppWinStyle.NormalFocus, True)
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "DTEMonitor Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Consultar_Boleta_Click(sender As Object, e As EventArgs) Handles Btn_Consultar_Boleta.Click

        ' PARAMETROS 

        '1 _Empresa = Environment.GetCommandLineArgs(2)
        '2 _AmbienteCertificacion = Environment.GetCommandLineArgs(3)
        '3 _Id_Dte = Environment.GetCommandLineArgs(4)
        '4 _Trackid = Environment.GetCommandLineArgs(5)
        '5 _Accion = Environment.GetCommandLineArgs(6)

        Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
        Dim _Id_Dte As Integer = 0
        Dim _Trackid As String = Txt_Trackid2.Text
        Dim _Accion As Enum_Accion = Enum_Accion.ConsultarTrackid

        Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
        Dim _Ejecutar As String = Application.StartupPath & "\BoletaSII\BoletaBkHf.exe" &
                                                                                Space(1) & ModEmpresa &
                                                                                Space(1) & _AmbienteCertificacion &
                                                                                Space(1) & _Id_Dte &
                                                                                Space(1) & _Trackid &
                                                                                Space(1) & _Accion
        Try
            Shell(_Ejecutar, AppWinStyle.NormalFocus, True)
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "DTEMonitor Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub



End Class