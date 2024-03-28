Imports DevComponents.DotNetBar
Public Class Frm_LiquidImporDtExcel

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Txt_Log As New TextBox
    Dim _Cancelar As Boolean
    Dim _Tbl_Liquidacion As DataTable

    Public Property Ls_Liquid_Transbank As New List(Of LiqTransbank.Liquid_Transbank)
    Public Property TotalValSelec As Double

    Public Sub New(ByRef _Tbl_Liquidacion As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tbl_Liquidacion = _Tbl_Liquidacion

    End Sub

    Private Sub Frm_LiquidImporDtExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Ls_Liquid_Transbank = New List(Of LiqTransbank.Liquid_Transbank)
        Sb_Habilitar_Deshabilitar_Comandos(True, False)

    End Sub

    Private Sub Btn_Archivo_Ayuda_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Archivo_Ayuda_Excel.Click

        Dim _Nom_Excel As String

        Consulta_sql = "Select 'Caracter [10]' As 'Cód. Autorización Venta','Númerico' As 'Monto para abono'"

        _Nom_Excel = "Ejemplo levantamiento Liquidación transbank"

        ExportarTabla_JetExcel(Consulta_sql, Me, _Nom_Excel)

    End Sub

    Private Sub Btn_Importar_Archivo_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Archivo.Click

        Dim _Nombre_Archivo As String
        Dim _Ubic_Archivo As String

        Dim _Limpiar_Lista As Boolean
        Ls_Liquid_Transbank = New List(Of LiqTransbank.Liquid_Transbank)

        With OpenFileDialog1
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            '.ShowDialog(Me)

            If .ShowDialog(Me) = DialogResult.OK Then

                _Nombre_Archivo = System.IO.Path.GetFileNameWithoutExtension(.SafeFileName)
                _Ubic_Archivo = System.IO.Path.GetDirectoryName(.FileName)

                _Nombre_Archivo = .SafeFileName
                _Ubic_Archivo = .FileName
            Else
                Beep()
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        End With

        Txt_Nombre_Archivo.Text = _Ubic_Archivo

        Dim _ImpEx As New Class_Importar_Excel
        Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")
        Dim _Arreglo = _ImpEx.Importar_Excel_Array(_Ubic_Archivo, _Extencion, 0)

        If Not String.IsNullOrEmpty(_ImpEx.Errores) Then
            MessageBoxEx.Show(Me, _ImpEx.Errores & vbCrLf &
                              "- Revise que el archivo no tenga hipervínculos en alguna celda", "Problema al intentar cargar el archivo Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filas = _Arreglo.GetUpperBound(0)

        Dim _Arreglo_Cd(_Filas) As String

        Dim _Desde = 0

        If Chk_Primera_Fila_Es_encabezado.Checked Then
            _Desde = 1
        End If

        For i = _Desde To _Filas
            _Arreglo_Cd(i) = NuloPorNro(_Arreglo(i, 0), "")
        Next

        Dim _Filtro_Productos As String = Generar_Filtro_IN_Arreglo(_Arreglo_Cd, False)

        Dim _Problemas As Integer
        Dim _SinProbremas As Integer

        Sb_Habilitar_Deshabilitar_Comandos(False, True)
        Circular_Progres_Val.Maximum = _Filas

        Dim _Contador As Integer = 0
        TotalValSelec = 0

        For i = _Desde To _Filas

            Dim _Error = String.Empty

            System.Windows.Forms.Application.DoEvents()

            Dim _CodAutoVenta_Ori As String
            Dim _MontoParaAbono_Ori As String

            Dim _CodAutoVenta As String
            Dim _MontoParaAbono As String

            Try
                _CodAutoVenta_Ori = _Arreglo(i, 0).ToString.Trim
                _MontoParaAbono_Ori = _Arreglo(i, 1)

                If Not String.IsNullOrWhiteSpace(_CodAutoVenta_Ori) AndAlso Not String.IsNullOrWhiteSpace(_MontoParaAbono_Ori) Then
                    _CodAutoVenta = NuloPorNro(numero_(_CodAutoVenta_Ori, 6), "")
                    _MontoParaAbono = NuloPorNro(_Arreglo(i, 1), 0)
                End If

            Catch ex As Exception
                _Error = ex.Message
            End Try

            If Not IsNumeric(_MontoParaAbono) Then
                _Error = "La columna Monto debe ser un valor numérico. Valor: " & _MontoParaAbono
            End If

            If String.IsNullOrWhiteSpace(_CodAutoVenta_Ori) Then
                _Error = "La columna Código esta vacía"
            End If

            If String.IsNullOrWhiteSpace(_MontoParaAbono_Ori) Then
                _Error = "La columna Monto esta vacía"
            End If

            If String.IsNullOrEmpty(_Error) Then

                Dim _TieneError = True

                For Each _Fila As DataRow In _Tbl_Liquidacion.Rows

                    If _Fila.Item("VADP") = _MontoParaAbono Then

                        Dim _Str_Nucudp As String = _Fila.Item("NUCUDP").ToString.Trim
                        Dim _Int_Nucudp As Integer = Convert.ToInt64(_Fila.Item("NUCUDP").ToString.Trim)
                        Dim _Str_Cudp As String = Convert.ToInt64(_Fila.Item("CUDP").ToString.Trim)
                        Dim _Int_Cudp = _Fila.Item("CUDP").ToString.Trim

                        If IsNumeric(_CodAutoVenta) Then
                            If _Int_Nucudp = Convert.ToInt64(_CodAutoVenta) Then
                                _Fila.Item("Incluir") = True
                                _TieneError = False
                                _Error = String.Empty
                                TotalValSelec += _MontoParaAbono
                                Exit For
                            ElseIf _Int_Cudp = Convert.ToInt64(_CodAutoVenta) Then
                                _Fila.Item("Incluir") = True
                                _TieneError = False
                                _Error = String.Empty
                                TotalValSelec += _MontoParaAbono
                                Exit For
                            End If
                        Else
                            If _Str_Nucudp = _CodAutoVenta Then
                                _Fila.Item("Incluir") = True
                                _TieneError = False
                                _Error = String.Empty
                                TotalValSelec += _MontoParaAbono
                                Exit For
                            ElseIf _Str_Cudp = _CodAutoVenta Then
                                _Fila.Item("Incluir") = True
                                _TieneError = False
                                _Error = String.Empty
                                TotalValSelec += _MontoParaAbono
                                Exit For
                            End If
                        End If
                        'If _Str_Nucudp = _CodAutoVenta Or _Int_Nucudp = Convert.ToInt32(_CodAutoVenta) Then
                        '    _Fila.Item("Incluir") = True
                        '    _TieneError = False
                        '    _Error = String.Empty
                        '    TotalValSelec += _MontoParaAbono
                        '    Exit For
                        'ElseIf _Str_Cudp = _CodAutoVenta Or _Int_Cudp = Convert.ToInt32(_CodAutoVenta) Then
                        '    _Fila.Item("Incluir") = True
                        '    _TieneError = False
                        '    _Error = String.Empty
                        '    TotalValSelec += _MontoParaAbono
                        '    Exit For
                        'End If

                    End If

                Next

                If _TieneError Then
                    _Error = "No se encuentra El código: [" & _CodAutoVenta_Ori & "] por el monto $ " & FormatNumber(_MontoParaAbono, 0)
                End If

            End If

            If String.IsNullOrEmpty(_Error) Then

                Dim _Liquid_Transbank As New LiqTransbank.Liquid_Transbank

                _Liquid_Transbank._CodAutoVenta = _CodAutoVenta
                _Liquid_Transbank._MontoParaAbono = _MontoParaAbono

                Ls_Liquid_Transbank.Add(_Liquid_Transbank)

            Else

                Sb_AddToLog("Fila Nro :" & i, "Problema: " & _Error,
                 _Txt_Log, False)
                _Problemas += 1

            End If

            If CBool(_Problemas) Then
                Circular_Progres_Porc.ProgressColor = Color.Red
                Circular_Progres_Val.ProgressColor = Color.Red
            End If

            If _Cancelar Then

                Exit For
            End If

            _Contador += 1
            Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas)
            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

            Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas

            System.Windows.Forms.Application.DoEvents()

        Next

        Try

            If _Cancelar Then
                _Limpiar_Lista = True
                Return
            End If

            If CBool(_Problemas) Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(_Problemas)))

                If _Problemas = 1 Then
                    _Leyend = "Existe " & _Problemas & " línea con problema en el archivo de lectura"
                Else
                    _Leyend = "Existen " & _Problemas & " líneas con problemas en el archivo de lectura"
                End If

                MessageBoxEx.Show(Me, _Leyend & vbCrLf &
                                  "a continuación se mostrar una lista con los errores",
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fm As New Frm_Archivo_TXT
                Fm.Pro_Nombre_Archivo = "Error_LevLista_X_Codigo.txt"
                Fm.Pro_Texto_Log = _Txt_Log.Text
                Fm.ShowDialog(Me)
                Fm.Dispose()

                If CBool(Ls_Liquid_Transbank.Count) Then
                    If MessageBoxEx.Show(Me, "¿Desea continuar con la implementación?", "Gestión",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                        _Limpiar_Lista = True
                        Return
                    End If
                End If

                'CrearArchivoTxt(AppPath() & "\Data\" & RutEmpresa & "\Temp\", "Error_LevLista.txt", _Txt_Log.Text, False)
                'Process.Start("notepad.exe", AppPath() & "\Data\" & RutEmpresa & "\Temp\Error_LevLista.txt")

            End If

            If CBool(Ls_Liquid_Transbank.Count) Then
                MessageBoxEx.Show(Me, "Se han encontrado " & Ls_Liquid_Transbank.Count & " Registros" & vbCrLf &
                                  "Por un total de " & FormatCurrency(TotalValSelec, 0),
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                _Limpiar_Lista = True
            End If

        Catch ex As Exception

        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty
            If _Limpiar_Lista Then
                Ls_Liquid_Transbank = New List(Of LiqTransbank.Liquid_Transbank)
            End If

        End Try

    End Sub


    Sub Sb_Habilitar_Deshabilitar_Comandos(ByVal _Habilitar As Boolean,
                                           ByVal _Habilitar_Cancelar As Boolean)

        _Cancelar = False
        Chk_Primera_Fila_Es_encabezado.Enabled = _Habilitar

        Btn_Importar_Archivo.Enabled = _Habilitar
        Btn_Archivo_Ayuda_Excel.Enabled = _Habilitar

        Me.ControlBox = _Habilitar

        Circular_Progres_Porc.ProgressColor = Color.SteelBlue
        Circular_Progres_Val.ProgressColor = Color.SteelBlue
        Circular_Progres_Porc.Maximum = 100

        Circular_Progres_Porc.Value = 0
        Circular_Progres_Val.Value = 0

        Btn_Cancelar.Visible = _Habilitar_Cancelar
        Lbl_Procesando.Visible = _Habilitar_Cancelar

        Me.Refresh()

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro cancelar la acción?", "Cancelar",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Cancelar = True
            Txt_Nombre_Archivo.Text = String.Empty
        End If

    End Sub
End Class

Namespace LiqTransbank

    Public Class Liquid_Transbank

        Public Property _CodAutoVenta As String
        Public Property _MontoParaAbono As String

    End Class

End Namespace
