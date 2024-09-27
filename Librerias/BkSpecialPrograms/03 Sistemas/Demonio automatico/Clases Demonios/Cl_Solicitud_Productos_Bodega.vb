Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Cl_Solicitud_Productos_Bodega

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Lbl_Estado As String
    Dim _Procesando As Boolean
    Dim _Fecha_Revision As Date
    Dim _Nombre_Equipo As String
    Dim _Path As String
    Dim _Solo_Marcar_No_Imprimir As Boolean
    Dim _Ruta_Archivador As String
    Dim _Impresora_Prod_Sol_Bodega As String

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

    Public Property Ruta_Archivador As String
        Get
            Return _Ruta_Archivador
        End Get
        Set(value As String)
            _Ruta_Archivador = value
        End Set
    End Property

    Public Property Impresora_Prod_Sol_Bodega As String
        Get
            Return _Impresora_Prod_Sol_Bodega
        End Get
        Set(value As String)
            _Impresora_Prod_Sol_Bodega = value
        End Set
    End Property

    Public Property Log_Registro As String
    Public Sub New()

        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True

        _Lbl_Estado = "Monitoreo archivador de documentos"

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

            Sb_Procedimiento_Solicitud_De_Productos_A_Bodega()

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
        _Lbl_Estado = "Monitoreo archivador de documentos"

    End Sub

    Sub Sb_Procedimiento_Solicitud_De_Productos_A_Bodega()

        _Procesando = True

        Log_Registro = String.Empty

        Dim _Id As Integer

        Consulta_Sql = "Select Id From " & _Global_BaseBk & "Zw_Prod_SolBodega " &
                       "Where Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "'  And Bodega = '" & ModBodega & "' And Impreso = 0"

        Dim _TblProd_SolBodega = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If CBool(_TblProd_SolBodega.Rows.Count) Then

            If _TblProd_SolBodega.Rows.Count > 10 Then

                Dim _Frm As New Form

                If MessageBoxEx.Show(_Frm, "Hay " & _TblProd_SolBodega.Rows.Count & " documentos en Cola" & vbCrLf &
                                     "¿Desea imprimirlos de todas formas?",
                                   "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                   MessageBoxDefaultButton.Button1, True) <> Windows.Forms.DialogResult.Yes Then

                    _Solo_Marcar_No_Imprimir = True

                End If

            End If

            For Each _Fila As DataRow In _TblProd_SolBodega.Rows

                _Id = _Fila.Item("Id")

                If _Solo_Marcar_No_Imprimir Then

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Prod_SolBodega set Impreso = 1 where Id = " & _Id
                    If _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro = "Id: " & _Id & " solo marcado como impreso" & vbCrLf
                    Else
                        Log_Registro = _Sql.Pro_Error
                    End If

                Else

                    Dim _NombreFormato = "Solicitud_PrBd"

                    Dim _Log_Error As String = Fx_Imprimir_Documento(_Id, "SPB", "", _NombreFormato, False, False, False, _Impresora_Prod_Sol_Bodega, "")

                    If String.IsNullOrEmpty(_Log_Error) Then
                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Prod_SolBodega set Impreso = 1 where Id = " & _Id
                        If _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                            Log_Registro = vbTab & "Solicutud de producto a bodega Id: " & _Id & " Impreso correctamente" & vbCrLf
                        Else
                            Log_Registro += _Sql.Pro_Error
                        End If
                    Else
                        Log_Registro += _Log_Error
                    End If

                End If

            Next

        End If

        _Procesando = False

    End Sub

End Class
