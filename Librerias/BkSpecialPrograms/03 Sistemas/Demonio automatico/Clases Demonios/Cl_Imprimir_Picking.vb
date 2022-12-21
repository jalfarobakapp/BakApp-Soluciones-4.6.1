Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Cl_Imprimir_Picking

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    'Dim _CirProgress As CircularProgress

    Dim _Lbl_Estado As String
    Dim _Procesando As Boolean
    Dim _Fecha_Revision As Date
    Dim _Nombre_Equipo As String
    Dim _Path As String
    Dim _Solo_Marcar_No_Imprimir As Boolean

    Dim _Segundos_Correo As Integer
    Dim _Input_Tiempo_Correo As Integer

    Public Property Lbl_Estado As String
        Get
            Return _Lbl_Estado
        End Get
        Set(value As String)
            _Lbl_Estado = value
        End Set
    End Property

    Public Property Procesando As Boolean
        Get
            Return _Procesando
        End Get
        Set(value As Boolean)
            _Procesando = value
        End Set
    End Property

    Public Property Fecha_Revision As Date
        Get
            Return _Fecha_Revision
        End Get
        Set(value As Date)
            _Fecha_Revision = value
        End Set
    End Property

    Public Property Nombre_Equipo As String
        Get
            Return _Nombre_Equipo
        End Get
        Set(value As String)
            _Nombre_Equipo = value
        End Set
    End Property

    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property

    Public Property Segundos_Correo As Integer
        Get
            Return _Segundos_Correo
        End Get
        Set(value As Integer)
            _Segundos_Correo = value
        End Set
    End Property

    Public Property Input_Tiempo_Correo As Integer
        Get
            Return _Input_Tiempo_Correo
        End Get
        Set(value As Integer)
            _Input_Tiempo_Correo = value
        End Set
    End Property

    Public Property Solo_Marcar_No_Imprimir As Boolean
        Get
            Return _Solo_Marcar_No_Imprimir
        End Get
        Set(value As Boolean)
            _Solo_Marcar_No_Imprimir = value
        End Set
    End Property

    Public Sub New()

        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True

        _Lbl_Estado = "Monitoreo Cola Impresión Automática"

    End Sub

    Sub Sb_Iniciar()

        _Procesando = True
        _BackgroundWorker.RunWorkerAsync()

    End Sub

    Sub Sb_Detener()

        If _BackgroundWorker.IsBusy Then
            _BackgroundWorker.CancelAsync()
        End If

    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        Try

            Sb_Procedimiento_Picking()

        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged
        'Lbl_Progreso.Text = (e.ProgressPercentage.ToString() & "%")
        'ProgressBarItem1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

        If e.Cancelled = True Then
            'Lbl_Progreso.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            'Lbl_Progreso.Text = "Error: " & e.[Error].Message
        Else
            'Lbl_Progreso.Text = "Done!"
            'If _BackgroundWorker.IsBusy <> True Then
            '_BackgroundWorker.RunWorkerAsync()
            'End If
        End If

        _Procesando = False
        _Lbl_Estado = "Monitoreo Cola Impresión Automática"

    End Sub

    Sub Sb_Procedimiento_Picking() 'IMPRIMIR DOCUMENTOS AUTOMATICAMENTE CUANDO LLEGAN

        Dim _Consulta_sql = String.Empty

        _Procesando = True

        Dim _Fecha = Format(_Fecha_Revision, "yyyyMMdd")

        Dim Dia_1 As String = numero_(_Fecha_Revision.Day, 2)
        Dim Mes_1 As String = numero_(_Fecha_Revision.Month, 2)
        Dim Ano_1 As String = _Fecha_Revision.Year

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion Set Fecha = Getdate(),Log_Error = 'Documento no impreso desde el día anterior' 
                        Where Fecha In (Select Max(Fecha) From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion Where Impreso = 0 And Fecha <> '" & _Fecha & "')"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Dim _Filtro_Fecha =
                      "FEEMLI BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                        "Where Fecha < '" & _Fecha & "' And NombreEquipo = '" & _Nombre_Equipo & "' -- And Impreso = 1"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)



        _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                        "Where NombreEquipo = '" & _Nombre_Equipo & "' And Imprimir_Picking = 1"

        Dim _Tbl_Zw_Demonio_Cof_Estacion As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql, False)

        Dim _SqlQuery_Cola = String.Empty

        If Not IsNothing(_Tbl_Zw_Demonio_Cof_Estacion) Then

            For Each _Fila As DataRow In _Tbl_Zw_Demonio_Cof_Estacion.Rows

                Dim _Tido As String = _Fila.Item("TipoDoc")
                Dim _NombreFormato As String = _Fila.Item("NombreFormato")
                Dim _IdPadre As String = _Fila.Item("Id")

                Dim _Imprimir_Picking = _Fila.Item("Imprimir_Picking")
                Dim _Imp_Suc_Modal = _Fila.Item("Imp_Suc_Modal")

                'PICKING
                If _Imprimir_Picking Then

                    _Consulta_sql = "Select Codigo From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & vbCrLf &
                                    "Where IdPadre = " & _IdPadre & " And Impresora <> '' And Picking = 1"
                    Dim _TblFiltroFunc As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

                    If CBool(_TblFiltroFunc.Rows.Count) Then

                        _SqlQuery_Cola += Fx_Insertar_Documento_Para_Imprimir_Picking(_Tido, _NombreFormato, _Filtro_Fecha, 0, 1, _Imp_Suc_Modal)

                    End If

                End If

            Next

        End If

        If Not String.IsNullOrEmpty(_SqlQuery_Cola) Then

            _Sql.Ej_consulta_IDU(_SqlQuery_Cola, False)

        End If

        ' **********************************************************************

        '_Nombre_Equipo = "CAJA_NUEVO"

        _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                        "Where Revizado_Demonio = 0 And NombreEquipo = '" & _Nombre_Equipo & "' And" & Space(1) &
                        "Convert(varchar,Fecha,112) = '" & Format(_Fecha_Revision, "yyyyMMdd") & "' And Picking = 1"

        Dim _Tbl_Doc_Sin_Imprimir As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql, False)

        Dim _Solo_Marcar_No_Imprimir As Boolean = _Solo_Marcar_No_Imprimir

        If Not IsNothing(_Tbl_Doc_Sin_Imprimir) Then

            If CBool(_Tbl_Doc_Sin_Imprimir.Rows.Count) Then

                If _Tbl_Doc_Sin_Imprimir.Rows.Count > 5 Then

                    Dim _Frm As New Form

                    If MessageBoxEx.Show(_Frm, "Hay " & _Tbl_Doc_Sin_Imprimir.Rows.Count & " documentos en Cola" & vbCrLf &
                                         "¿Desea imprimirlos de todas formas?",
                                       "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, True) <> Windows.Forms.DialogResult.Yes Then

                        _Solo_Marcar_No_Imprimir = True

                    End If

                End If

                For Each _Fila_Imp As DataRow In _Tbl_Doc_Sin_Imprimir.Rows

                    Dim _Id As Integer = _Fila_Imp.Item("Id")
                    Dim _IdMaeedo = _Fila_Imp.Item("Idmaeedo")
                    Dim _Tido = _Fila_Imp.Item("Tido")
                    Dim _Funcionario = _Fila_Imp.Item("Funcionario")
                    Dim _Picking = _Fila_Imp.Item("Picking")
                    Dim _NombreFormato = _Fila_Imp.Item("NombreFormato").ToString.Trim
                    Dim _Nro_Copias_Impresion = 0
                    Dim _Impresora = String.Empty

                    If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion", "Nro_Copias_Impresion") Then
                        _Nro_Copias_Impresion = _Fila_Imp.Item("Nro_Copias_Impresion")
                    End If

                    If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion", "Impresora") Then
                        _Impresora = _Fila_Imp.Item("Impresora")
                    End If

                    If Not _Solo_Marcar_No_Imprimir Then

                        Dim _Log_Error = String.Empty

                        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                                       "Where NombreEquipo = '" & _Nombre_Equipo & "' And TipoDoc = '" & _Tido & "'"

                        Dim _Row_Demonio_Cof_Estacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)
                        Dim _IdPadre As Integer

                        If IsNothing(_Row_Demonio_Cof_Estacion) Then
                            _Log_Error = "No existe configuración en Servidor: " & _Nombre_Equipo & ". "
                        Else
                            _IdPadre = _Row_Demonio_Cof_Estacion.Item("Id")
                        End If

                        Consulta_Sql = "Select Top 1 * " &
                                       "From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion " &
                                       "Where IdPadre = " & _IdPadre & " And TipoDoc = '" & _Tido & "' And Codigo = '" & _Funcionario & "' And Picking = 1"
                        Dim _Row_Demonio_Filtros_X_Estacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        Dim _NombreFormato_Est = String.Empty
                        Dim _Nro_Copias_Impresion_Est = 0
                        Dim _Impresora_Est = String.Empty

                        If Not IsNothing(_Row_Demonio_Filtros_X_Estacion) Then
                            _NombreFormato_Est = _Row_Demonio_Filtros_X_Estacion.Item("NombreFormato")
                            _Nro_Copias_Impresion_Est = _Row_Demonio_Filtros_X_Estacion.Item("Nro_Copias_Impresion")
                            _Impresora_Est = _Row_Demonio_Filtros_X_Estacion.Item("Impresora")
                        End If

                        If String.IsNullOrEmpty(_Impresora) Then
                            _Impresora = _Impresora_Est
                        End If

                        If String.IsNullOrEmpty(_NombreFormato) Then
                            _NombreFormato = _NombreFormato_Est
                            _Nro_Copias_Impresion = _Nro_Copias_Impresion_Est
                        End If

                        If Fx_Validar_Impresora(_Impresora) Then

                            _Log_Error += Fx_Enviar_A_Imprimir_Documento(Nothing, _NombreFormato,
                                                                        _IdMaeedo, False, False, _Impresora, False, _Nro_Copias_Impresion, False, "")

                            If String.IsNullOrEmpty(_Log_Error) Then

                                _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                                "Set Revizado_Demonio = 1,Impreso = 1,Error_Al_Imprimir = 0," & vbCrLf &
                                                "Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                                "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(_Consulta_sql)

                            Else

                                _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                                "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 1," &
                                                "Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                                "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(_Consulta_sql)

                            End If

                        Else

                            _Log_Error += "No existe impresora seleccionada (" & _Impresora & "). Revise la configuración de los funcionarios en cola de impresión"

                            _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                            "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 1,Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                            "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(_Consulta_sql)

                        End If

                    Else

                        _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion " &
                                        "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 0,Log_Error = 'No se imprime, se marca como impreso por el usuario'" & vbCrLf &
                                        "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(_Consulta_sql)

                    End If

                Next

            End If

        End If

        _Procesando = False

    End Sub

    Private Function Fx_Insertar_Documento_Para_Imprimir_Picking(_Tido As String,
                                                                 _NombreFormato As String,
                                                                 _Filtro_Fecha As String,
                                                                 _Nudonodefi As Integer,
                                                                 _Picking As Integer,
                                                                 _Imp_Suc_Modal As Boolean)

        Dim _Filtro_Sucursal = String.Empty

        If _Imp_Suc_Modal Then
            _Filtro_Sucursal = "And SULIDO = '" & ModSucursal & "' And BOSULIDO = '" & ModBodega & "'"
        End If

        Fx_Insertar_Documento_Para_Imprimir_Picking =
                         "-- INSERTANDO " & _Tido &
                         vbCrLf &
                         vbCrLf &
                         "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                         "(NombreEquipo,Idmaeedo,Tido,Nudo,Funcionario,Fecha,NombreFormato,Nudonodefi,Picking,Insertado_Desde_Diablito)" & vbCrLf &
                         "Select '" & _Nombre_Equipo & "',IDMAEEDO,TIDO,NUDO,KOFUDO,GetDate()," &
                         "'" & _NombreFormato & "'," & _Nudonodefi & "," & _Picking & ",1" & vbCrLf &
                         "From MAEEDO" & vbCrLf &
                         "Where" & vbCrLf &
                         "IDMAEEDO IN (Select Distinct IDMAEEDO From MAEDDO" & vbCrLf &
                         "Where" & vbCrLf &
                         "TIDO = '" & _Tido & "' " & vbCrLf &
                         _Filtro_Sucursal & vbCrLf &
                         "And " & _Filtro_Fecha & vbCrLf & "And NUDONODEFI = " & _Nudonodefi & vbCrLf &
                         "And IDMAEEDO not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                         "Where NombreEquipo = '" & _Nombre_Equipo & "'  And Nudonodefi = " & _Nudonodefi & " And Picking = " & _Picking & "))" & vbCrLf &
                         vbCrLf & "-------------------------------------------------" & vbCrLf


    End Function

End Class
