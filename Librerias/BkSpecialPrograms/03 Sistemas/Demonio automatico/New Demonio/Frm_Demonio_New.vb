Imports System.IO
Imports System.Threading
Imports System.Web.Services

Public Class Frm_Demonio_New

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_ConfXEstacion As DataRow
    Dim _Tbl_Diablito As DataTable
    Dim _NombreEquipo As String

    Dim _DProgramaciones As DProgramaciones

    Dim _Cl_Correos As New Cl_Correos

    Private _Timer_Correos As Timer
    Private logFilePath As String = "log.txt"

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

        'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfXEstacion Where NombreEquipo = '" & _NombreEquipo & "'"
        '_Row_ConfXEstacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id As Integer = _Global_Row_EstacionBk.Item("Id") '_Row_ConfXEstacion.Item("Id")


        Dim _Chk As Boolean
        Dim _ChkCorreo As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                      "Informe = 'Demonio' And Campo = 'Chk_EnvioCorreo' And NombreEquipo = '" & _NombreEquipo & "'")

        If Boolean.TryParse(_ChkCorreo, _Chk) Then

            Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id",
                                                       "NombreEquipo = '" & _NombreEquipo & "' And Tbl_Padre = 'Diablito' And Nombre = 'EnvioCorreo'", True)
            _DProgramaciones.Sp_EnvioCorreo = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

            Dim _CantCorreo As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                      "Informe = 'Demonio' And Campo = 'Input_CantCorreo' And NombreEquipo = '" & _NombreEquipo & "'", True)

            Dim _NewFila As ListViewItem = New ListViewItem("Envio de correos", 0)
            _NewFila.SubItems.Add("Se enviaran paquetes de " & _CantCorreo & " correos." & "; " & _DProgramaciones.Sp_EnvioCorreo.Resumen)
            Listv_Programaciones.Items.Add(_NewFila)

            Sb_Insertar_Registro("EnvioCorreo", "Envio de correos (Cant. " & _CantCorreo & ")", _DProgramaciones.Sp_EnvioCorreo.Resumen)
            Sb_Timer_Correo()

        End If

        If False Then

            If _Row_ConfXEstacion.Item("ColaImpDoc") Then

                Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id & " And Nombre = 'ColaImpDoc'", True)
                _DProgramaciones.Sp_ColaImpDoc = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

                Dim _NewFila As ListViewItem = New ListViewItem("Monitoreo Cola Impresión Documentos", 4)
                _NewFila.SubItems.Add(_DProgramaciones.Sp_ColaImpDoc.Resumen)
                Listv_Programaciones.Items.Add(_NewFila)

                Sb_Insertar_Registro("ColaImpDoc", "Monitoreo Cola Impresión Documentos", _DProgramaciones.Sp_ColaImpDoc.Resumen)

            End If

            If _Row_ConfXEstacion.Item("ColaImpPick") Then

                Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id & " And Nombre = 'ColaImpPick'", True)
                _DProgramaciones.Sp_ColaImpPick = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

                Dim _NewFila As ListViewItem = New ListViewItem("Monitoreo Cola Impresión Picking", 4)
                _NewFila.SubItems.Add(_DProgramaciones.Sp_ColaImpPick.Resumen)
                Listv_Programaciones.Items.Add(_NewFila)

                Sb_Insertar_Registro("ColaImpPick", "Monitoreo Cola Impresión Picking", _DProgramaciones.Sp_ColaImpPick.Resumen)

            End If

        End If

        If CBool(_Tbl_Diablito.Rows.Count) Then
            Lbl_Monitoreo.Text = "MONITOREO ACTIVO"
            Circular_Monitoreo.IsRunning = True
        Else
            Lbl_Monitoreo.Text = "MONITOREO INACTIVO"
            Circular_Monitoreo.IsRunning = False
        End If

    End Sub

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
        'Dim _Milisegundos As Integer
        Dim horaProgramada As DateTime

        If _DProgramaciones.Sp_EnvioCorreo.FrecuDiaria Then
            Dim _IntervaloCada As Integer = _DProgramaciones.Sp_EnvioCorreo.IntervaloCada
            If _DProgramaciones.Sp_EnvioCorreo.SucedeCada Then
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "HH" Then horaProgramada = DateTime.Now.AddHours(_IntervaloCada)
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "MM" Then horaProgramada = DateTime.Now.AddMinutes(_IntervaloCada)
                If _DProgramaciones.Sp_EnvioCorreo.TipoIntervaloCada = "SS" Then horaProgramada = DateTime.Now.AddSeconds(_IntervaloCada)
            End If
        End If

        ' Hora programada 10 segundos después del tiempo actual

        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        'Dim minutos As Integer = 5
        'Dim milisegundos As Double = TimeSpan.FromMinutes(minutos).TotalMilliseconds

        ' Crear un temporizador con un intervalo de 5 minutos (300,000 milisegundos)
        _Timer_Correos = New Timer(AddressOf Sb_Enviar_Correos, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

        'Txt_Log.Text += DateTime.Now.ToString() & " - Envío correo (Proceso configurado para " & tiempoRestante.ToString & "...)" & vbCrLf

    End Sub

    Sub Sb_Enviar_Correos(state As Object)

        If _Cl_Correos.Procesando Then
            'Txt_Log.Text += DateTime.Now.ToString() & " - Envío correo (Proceso en curso se volvera a revisar en 1 minuto mas...)" & vbCrLf
            Dim horaProgramada As DateTime = DateTime.Now.AddMinutes(1)
            Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now
            _Timer_Correos.Change(tiempoRestante, Timeout.InfiniteTimeSpan)

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 5 minutos)
            Dim registro As String = DateTime.Now.ToString() & " - Envío correo (Proceso en curso se volvera a revisar en 1 minuto mas...)"

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

        Else

            'Txt_Log.Text += DateTime.Now.ToString() & " - Envío correo (Proceso ejecutado...)" & vbCrLf

            _Cl_Correos.Fecha_Revision = DtpFecharevision.Value
            _Cl_Correos.Sb_Procedimiento_Correos()
            'Txt_Log.Text += DateTime.Now.ToString() & " - Envío correo (Proceso ejecutado...)" & vbCrLf

            Sb_Timer_Correo()

            ' Este método se ejecuta cada vez que se activa el temporizador (cada 5 minutos)
            Dim registro As String = "Tarea ejecutada a las: " & DateTime.Now.ToString()

            ' Registrar la información en un archivo de registro
            RegistrarLog(registro)
            MostrarRegistro(registro)

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

    End Sub

End Class
