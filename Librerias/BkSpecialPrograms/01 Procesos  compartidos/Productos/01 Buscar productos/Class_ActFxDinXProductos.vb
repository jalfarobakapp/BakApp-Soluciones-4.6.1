Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Class_ActFxDinXProductos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Tbl_Productos As DataTable
    Dim _Lista As String
    Dim _CirProgress As CircularProgressItem

    Dim _Mostrar_Stock_Disponible As Boolean
    Dim _Tido_Stock As String
    Dim _Tbl_Bodegas As DataTable

    Dim _Realizar_Busqueda As Boolean
    Public Property Pro_Tbl_Productos As DataTable
        Get
            Return _Tbl_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Productos = value
        End Set
    End Property

    Public Sub New()
        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True
    End Sub

    Sub Sb_Iniciar(_Tbl_Productos As DataTable,
                   Lista As String,
                   ByRef CirProgress As CircularProgressItem,
                   _Mostrar_Stock_Disponible As Boolean,
                   _Tido_Stock As String,
                   _Tbl_Bodegas As DataTable)

        _Lista = Lista
        Pro_Tbl_Productos = _Tbl_Productos
        _CirProgress = CirProgress
        _CirProgress.IsRunning = True
        _CirProgress.Visible = True
        _Realizar_Busqueda = True

        Me._Mostrar_Stock_Disponible = _Mostrar_Stock_Disponible
        Me._Tido_Stock = _Tido_Stock
        Me._Tbl_Bodegas = _Tbl_Bodegas

        _BackgroundWorker.RunWorkerAsync()

    End Sub

    Sub Sb_Detener()
        _Realizar_Busqueda = False
        If Not IsNothing(_CirProgress) Then _CirProgress.Visible = False
        If _BackgroundWorker.IsBusy Then
            _BackgroundWorker.CancelAsync()
        End If
    End Sub

    Sub Sb_Ejecutar_Ecuacion_Dinamica(ByVal _Fila As DataRow)

        Dim _Codigo = _Fila.Item("Codigo")
        Dim _Ecuacion = _Fila.Item("Ecuacion_Ud1")
        Dim _Precio As Double

        If Not String.IsNullOrEmpty(Trim(_Ecuacion)) Then

            Consulta_Sql = "Select Top 1 *," & vbCrLf &
                           "(Select top 1 MELT From TABPP Where KOLT = '" & _Lista & "') as MELT" & Space(1) &
                           "From TABPRE" & Space(1) &
                           "Where KOLT = '" & _Lista & "' And KOPR = '" & _Codigo & "'"

            Dim _RowPrecio As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

                Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

                If _Tiene_Cor Then
                    _Precio = Fx_Funcion_Ecuacion_Random(Nothing, "", _Ecuacion, _Codigo, 1, _RowPrecio, 1, 1, 1)
                Else
                    _Precio = Fx_Precio_Formula_Random(_RowPrecio, "PP01UD", "ECUACION", Nothing, True, "", 1, 1)
                End If

                _Fila.Item("Precio_UD1") = _Precio
                _Fila.Item("Ecuacion_Generada") = True

            End If

        End If

        If _Mostrar_Stock_Disponible Then

            For Each _FilaSt As DataRow In _Tbl_Bodegas.Rows

                Dim _Emp = Trim(_FilaSt.Item("EMPRESA"))
                Dim _Suc = Trim(_FilaSt.Item("KOSU"))
                Dim _Bod = Trim(_FilaSt.Item("KOBO"))

                Dim _Sigla = _Emp & _Suc & _Bod

                Dim _St_Disponible = Fx_Stock_Disponible(_Tido_Stock, _Emp, _Suc, _Bod, _Codigo, 1, "STFI1")
                If _St_Disponible < 0 Then _St_Disponible = 0

                _Fila.Item("STOCK_Ud1_" & _Sigla) = _St_Disponible

            Next

        End If

    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)
        Try
            If Not worker.CancellationPending Then
                Dim _Filas = _Tbl_Productos.Select("Ecuacion_Generada = False")
                _CirProgress.Visible = True
                For Each _Fila As DataRow In _Filas

                    If worker.CancellationPending = True Then
                        e.Cancel = True
                        Exit For
                    Else
                        Sb_Ejecutar_Ecuacion_Dinamica(_Fila)
                        System.Windows.Forms.Application.DoEvents()
                    End If

                Next
                _CirProgress.Visible = False
            End If
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
        _CirProgress.Visible = False
        
    End Sub


End Class
