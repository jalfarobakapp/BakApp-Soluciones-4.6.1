Imports System.IO
Imports System.Threading

Public Class Frm_Demonio_New

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_ConfXEstacion As DataRow
    Dim _Tbl_Diablito As DataTable
    Dim _NombreEquipo As String

    Dim _DProgramaciones As DProgramaciones

    Dim _Cl_Correos As New Cl_Correos
    Dim _Cl_Imprimir_Documentos As New Cl_Imprimir_Documentos
    Dim _Cl_Imprimir_Picking As New Cl_Imprimir_Picking

    Private _Timer_Correos As Timer
    Private _Timer_ImprimirDocumentos As Timer
    Private _Timer_ImprimirPicking As Timer

    Private logFilePath As String = "Log_Demonio.txt"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select Cast(1 As Bit) As Chk,Cast('' As Varchar(20)) As Nombre,Cast('' As Varchar(100)) As Programacion,Cast('' As Varchar(100)) As Resumen Where 1<0"
        _Tbl_Diablito = _Sql.Fx_Get_Tablas(Consulta_sql)

        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        _DProgramaciones = New DProgramaciones

    End Sub

    Private Sub Frm_Demonio_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Load()

    End Sub

    Sub Sb_Load()

        Dim _Grb_Programacion As New Grb_Programacion

        Dim _Id As Integer = _Global_Row_EstacionBk.Item("Id") '_Row_ConfXEstacion.Item("Id")

        If Fx_InsertarRegistroDeProgramacion("EnvioCorreo", _DProgramaciones.Sp_EnvioCorreo, "Envio de correos") Then
            _DProgramaciones.Sp_EnvioCorreo.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("ColaImpDoc", _DProgramaciones.Sp_ColaImpDoc, "Imprimir documentos") Then
            _DProgramaciones.Sp_ColaImpDoc.Activo = True
        End If

        If Fx_InsertarRegistroDeProgramacion("ColaImpPick", _DProgramaciones.Sp_ColaImpPick, "Imprimir pickings") Then
            _DProgramaciones.Sp_ColaImpPick.Activo = True
        End If

        Dim _CantidadFilas As Integer = Listv_Programaciones.Items.Count

        If _CantidadFilas = 1 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_1
        If _CantidadFilas = 2 Then Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink_number_2

        If CBool(_CantidadFilas) Then
            Lbl_Monitoreo.Text = "MONITOREO ACTIVO"
            Circular_Monitoreo.IsRunning = True
        Else
            Lbl_Monitoreo.Text = "MONITOREO INACTIVO"
            Circular_Monitoreo.IsRunning = False
            Me.Icon = My.Resources.Recursos_NewDemonio.emoticon_wink
        End If

        If _DProgramaciones.Sp_EnvioCorreo.Activo Then Sb_Timer_Correo()
        If _DProgramaciones.Sp_ColaImpDoc.Activo Then Sb_Timer_ImprimirDocumentos()
        If _DProgramaciones.Sp_ColaImpPick.Activo Then Sb_Timer_ImprimirPicking()

    End Sub

    Function Fx_InsertarRegistroDeProgramacion(_Campo As String,
                                               ByRef _CI_Programacion As Cl_NewProgramacion,
                                               _Codigo As String) As Boolean


        Dim _Descripcion As String
        Dim _Grb_Programacion As New Grb_Programacion
        Dim _Chk As Boolean
        Dim _IndexImagen As Integer
        Dim _ChkStr As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                      "Informe = 'Demonio' And Campo = 'Chk_" & _Campo & "' And NombreEquipo = '" & _NombreEquipo & "'")

        If Boolean.TryParse(_ChkStr, _Chk) Then

            Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id",
                                                       "NombreEquipo = '" & _NombreEquipo & "' And Tbl_Padre = 'Diablito' And Nombre = '" & _Campo & "'", True)
            _CI_Programacion = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

            Select Case _Campo
                Case "EnvioCorreo"

                    Dim _CantCorreo As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Demonio' And Campo = 'Input_CantCorreo' And NombreEquipo = '" & _NombreEquipo & "'", True)
                    _Descripcion = "Se enviaran paquetes de " & _CantCorreo & " correos." & "; " & _CI_Programacion.Resumen
                    _IndexImagen = 0

                Case "ColaImpDoc"

                    _Descripcion = "Se imprimiran documentos. " & _CI_Programacion.Resumen
                    _IndexImagen = 1

                Case "ColaImpPick"

                    _Descripcion = "Se imprimiran pickings. " & _CI_Programacion.Resumen
                    _IndexImagen = 2

            End Select

            Dim _NewFila As ListViewItem = New ListViewItem(_Codigo, _IndexImagen)
            _NewFila.SubItems.Add(_Descripcion)
            Listv_Programaciones.Items.Add(_NewFila)

            Return True

        End If

    End Function

    Sub Sb_Insertar_Registro(_Nombre As String, _Programacion As String, _Resumen As String)

        Dim NewFila As DataRow
        NewFila = _Tbl_Diablito.NewRow
        With NewFila

            .Item("Chk") = True
            .Item("Nombre") = _Nombre
            .Item("Programacion") = _Programacion
            .Item("Resumen") = _Resumen

            _Tbl_Diablito.Rows.Add(NewFila)

        End With

    End Sub

    Sub Sb_Timer_Correo()

        _Timer_Correos = Nothing
        Dim horaProgramada As DateTime

        If _DProgramaciones.Sp_EnvioCorreo.FrecuDiaria Then
            Dim _IntervaloCada As Integer = _DProgramaciones.Sp_EnvioCorreo.IntervaloCada
            If _DProgramaciones.Sp_EnvioCorreo.SucedeCada Then
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
            End If
        End If

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        _Timer_Correos = New Timer(AddressOf Sb_Enviar_Correos, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub

    Sub Sb_Timer_ImprimirDocumentos()

        _Timer_ImprimirDocumentos = Nothing
        Dim horaProgramada As DateTime

        If _DProgramaciones.Sp_ColaImpDoc.FrecuDiaria Then
            Dim _IntervaloCada As Integer = _DProgramaciones.Sp_ColaImpDoc.IntervaloCada
            If _DProgramaciones.Sp_EnvioCorreo.SucedeCada Then
                If _DProgramaciones.Sp_ColaImpDoc.TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                If _DProgramaciones.Sp_ColaImpDoc.TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                If _DProgramaciones.Sp_ColaImpDoc.TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
            End If
        End If

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        _Timer_ImprimirDocumentos = New Timer(AddressOf Sb_Imprimir_Documentos, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub

    Sub Sb_Timer_ImprimirPicking()

        _Timer_ImprimirPicking = Nothing
        Dim horaProgramada As DateTime

        If _DProgramaciones.Sp_ColaImpPick.FrecuDiaria Then
            Dim _IntervaloCada As Integer = _DProgramaciones.Sp_ColaImpPick.IntervaloCada
            If _DProgramaciones.Sp_EnvioCorreo.SucedeCada Then
                If _DProgramaciones.Sp_ColaImpPick.TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                If _DProgramaciones.Sp_ColaImpPick.TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                If _DProgramaciones.Sp_ColaImpPick.TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
            End If
        End If

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        _Timer_ImprimirPicking = New Timer(AddressOf Sb_Imprimir_Picking, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

    End Sub


    Sub Sb_Enviar_Correos(state As Object)

        If _Cl_Correos.Procesando Or _Cl_Imprimir_Documentos.Procesando Or _Cl_Imprimir_Picking.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(15) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_Correos.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Envío correo (Proceso en curso se volverá a revisar en 15 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Correos.Procesando = False

        Else

            _Cl_Correos.Fecha_Revision = DtpFecharevision.Value
            _Cl_Correos.Sb_Procedimiento_Correos()

            Sb_Timer_Correo()

            Dim registro As String = "Tarea ejecutada (Correo) a las: " & DateTime.Now.ToString() & vbCrLf

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Correos.Procesando = True

        End If

    End Sub

    Sub Sb_Imprimir_Documentos(state As Object)

        If _Cl_Imprimir_Documentos.Procesando Or _Cl_Imprimir_Picking.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(5) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_ImprimirDocumentos.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Imprimir documentos (Proceso en curso se volverá a revisar en 5 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Imprimir_Documentos.Procesando = False

        Else

            _Cl_Imprimir_Documentos.Fecha_Revision = DtpFecharevision.Value
            _Cl_Imprimir_Documentos.Nombre_Equipo = _NombreEquipo
            _Cl_Imprimir_Documentos.Log_Registro = String.Empty
            _Cl_Imprimir_Documentos.Sb_Procedimiento_Cola_Impresion()

            Sb_Timer_ImprimirDocumentos()

            Dim registro As String = "Tarea ejecutada (Imprimir documentos) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Imprimir_Documentos.Log_Registro) Then
                registro += vbCrLf & _Cl_Imprimir_Documentos.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

            '_Cl_Imprimir_Documentos.Procesando = True

        End If

    End Sub

    Sub Sb_Imprimir_Picking(state As Object)

        If _Cl_Imprimir_Picking.Procesando Or _Cl_Imprimir_Picking.Procesando Then

            Dim horaProgramada As DateTime = DateTime.Now.AddSeconds(5) 'DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_ImprimirPicking.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 1 minuto adicional)
            Dim registro As String = DateTime.Now.ToString() & " - Imprimir picking (Proceso en curso se volverá a revisar en 5 segundos mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

            '_Cl_Imprimir_Documentos.Procesando = False

        Else

            _Cl_Imprimir_Picking.Fecha_Revision = DtpFecharevision.Value
            _Cl_Imprimir_Picking.Nombre_Equipo = _NombreEquipo
            _Cl_Imprimir_Picking.Log_Registro = String.Empty
            _Cl_Imprimir_Picking.Sb_Procedimiento_Picking()

            Sb_Timer_ImprimirPicking()

            Dim registro As String = "Tarea ejecutada (Imprimir picking) a las: " & DateTime.Now.ToString()

            If Not String.IsNullOrWhiteSpace(_Cl_Imprimir_Picking.Log_Registro) Then
                registro += vbCrLf & _Cl_Imprimir_Picking.Log_Registro

                ' Registrar la información en un archivo de registro
                RegistrarLog(registro)
                MostrarRegistro(registro)
            End If

            '_Cl_Imprimir_Documentos.Procesando = True

        End If

    End Sub

    Private Sub RegistrarLog(registro As String)
        ' Escribir la información en el archivo de registro
        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine(registro)
        End Using
    End Sub

    Private Sub MostrarRegistro(registro As String)
        ' Agregar el registro al TextBox
        Try
            Txt_Log.Invoke(Sub() Txt_Log.AppendText(registro & Environment.NewLine))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Frm_Demonio_New_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Timer_Correos = Nothing
        _Timer_ImprimirDocumentos = Nothing
        _Timer_ImprimirPicking = Nothing
    End Sub

End Class
