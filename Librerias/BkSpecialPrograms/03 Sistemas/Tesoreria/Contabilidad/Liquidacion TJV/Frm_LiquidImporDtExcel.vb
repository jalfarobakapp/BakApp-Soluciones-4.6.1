Imports DevComponents.DotNetBar
Imports System.Globalization

' Pseudocódigo detallado (plan):
' 1. El problema es que los índices del arreglo importado son 0-based, mientras que las filas de Excel se cuentan desde 1.
' 2. Para mostrar correctamente las filas al usuario hay que convertir el índice del arreglo (i) a número de fila de Excel:
'      displayRow = i + 1
' 3. Además, el total de filas mostrado debe corresponder al último índice más 1:
'      totalRows = _Filas + 1
' 4. El progreso en la barra circular debe basarse en la cantidad de filas a procesar:
'      totalToProcess = _Filas - _Desde + 1
'    - Prevenir división por cero si totalToProcess <= 0.
' 5. Ajustar todos los mensajes y logs:
'    - Reemplazar "Fila Nro : i" por "Fila Nro : displayRow"
'    - Reemplazar "primera aparición en fila dictFirstIndex(key)" por dictFirstIndex(key) + 1
'    - Reemplazar "Leyendo fila i de _Filas" por "Leyendo fila displayRow de totalRows"
' 6. Mantener la lógica existente de detección de duplicados y validaciones sin cambios funcionales.
' 7. Aplicar el cambio mínimo y coherente en todos los puntos de salida/registro de fila para que el usuario vea las filas tal como están numeradas en Excel.

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
        _Txt_Log.Text = String.Empty

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

        ' --- Detección de duplicados en el arreglo (codigo + monto) ---
        Dim _Problemas As Integer
        Dim _Diferencias As Integer
        Dim _Diferencias1peso As Integer
        Dim _SinProbremas As Integer

        Dim dictCount As New Dictionary(Of String, Integer)
        Dim dictFirstIndex As New Dictionary(Of String, Integer)
        Dim _FilaDuplicada(_Filas) As Boolean

        ' Primera pasada: construir conteos y primera aparición usando normalización coherente
        For i = _Desde To _Filas
            Dim normaCod As String = String.Empty
            Dim normaMonto As Double = 0

            Try
                normaCod = NuloPorNro(numero_(NuloPorNro(_Arreglo(i, 0), ""), 6), "").ToString.Trim
                Dim montoStr As String = NuloPorNro(_Arreglo(i, 1), "").ToString.Trim

                If Not Double.TryParse(montoStr, NumberStyles.Any, CultureInfo.InvariantCulture, normaMonto) Then
                    ' Intentar con la conversión cultural por defecto si falla
                    Double.TryParse(montoStr, NumberStyles.Any, CultureInfo.CurrentCulture, normaMonto)
                End If
            Catch ex As Exception
                normaCod = String.Empty
                normaMonto = 0
            End Try

            Dim key = normaCod & "|" & normaMonto.ToString("G17", CultureInfo.InvariantCulture)

            If dictCount.ContainsKey(key) Then
                dictCount(key) += 1
            Else
                dictCount.Add(key, 1)
                dictFirstIndex.Add(key, i)
            End If
        Next

        ' Marcar como duplicadas todas las filas que no sean la primera aparición
        For i = _Desde To _Filas
            Dim normaCod As String = String.Empty
            Dim normaMonto As Double = 0

            Try
                normaCod = NuloPorNro(numero_(NuloPorNro(_Arreglo(i, 0), ""), 6), "").ToString.Trim
                Dim montoStr As String = NuloPorNro(_Arreglo(i, 1), "").ToString.Trim

                If Not Double.TryParse(montoStr, NumberStyles.Any, CultureInfo.InvariantCulture, normaMonto) Then
                    Double.TryParse(montoStr, NumberStyles.Any, CultureInfo.CurrentCulture, normaMonto)
                End If
            Catch ex As Exception
                normaCod = String.Empty
                normaMonto = 0
            End Try

            Dim key = normaCod & "|" & normaMonto.ToString("G17", CultureInfo.InvariantCulture)

            If dictCount.ContainsKey(key) AndAlso dictCount(key) > 1 Then
                If dictFirstIndex.ContainsKey(key) AndAlso dictFirstIndex(key) <> i Then
                    _FilaDuplicada(i) = True
                    _Problemas += 1
                    ' Mostrar fila según numeración de Excel (índice + 1)
                    Sb_AddToLog("Fila Nro :" & (i + 1), "Problema: Duplicado (mismo código y monto) - primera aparición en fila " & (dictFirstIndex(key) + 1) & ", Key: " & key, _Txt_Log, False)
                End If
            End If
        Next
        '--- fin detección duplicados ---

        If CBool(_Problemas) Then

            MessageBoxEx.Show(Me, "Existen registros duplicados." & vbCrLf &
                              "A continuación se mostrar una lista con los errores",
                              "Validacón", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Dim Fm As New Frm_Archivo_TXT
            Fm.Pro_Nombre_Archivo = "Error_LevLista_X_Codigo.txt"
            Fm.Pro_Texto_Log = _Txt_Log.Text
            Fm.ShowDialog(Me)
            Fm.Dispose()
            Return

        End If

        Sb_Habilitar_Deshabilitar_Comandos(False, True)

        ' Calcular total a procesar y ajustar máximos de progreso
        Dim totalToProcess As Integer = _Filas - _Desde + 1
        If totalToProcess <= 0 Then totalToProcess = 1

        Circular_Progres_Val.Maximum = totalToProcess

        Dim _Contador As Integer = 0
        TotalValSelec = 0

        Dim totalRows As Integer = _Filas + 1 ' número de fila Excel del último índice

        For i = _Desde To _Filas

            Dim displayRow As Integer = i + 1 ' fila real en Excel

            ' Si la fila fue marcada como duplicada, saltarla
            If _FilaDuplicada(i) Then
                If CBool(_Problemas) Then
                    Circular_Progres_Porc.ProgressColor = Color.Red
                    Circular_Progres_Val.ProgressColor = Color.Red
                End If

                _Contador += 1
                Circular_Progres_Porc.Value = CInt((_Contador * 100) / totalToProcess)
                If Circular_Progres_Porc.Value < 0 Then Circular_Progres_Porc.Value = 0
                Circular_Progres_Val.Value += 1
                Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

                Lbl_Procesando.Text = "Leyendo fila " & displayRow & " de " & totalRows & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas & ", Diferencias: " & _Diferencias

                Continue For
            End If

            Dim _Error = String.Empty

            System.Windows.Forms.Application.DoEvents()

            Dim _CodAutoVenta_Ori As String = String.Empty
            Dim _MontoParaAbono_Ori As String = String.Empty

            Dim _CodAutoVenta As String = String.Empty
            Dim _MontoParaAbono As Double = 0

            Try
                _CodAutoVenta_Ori = NuloPorNro(_Arreglo(i, 0), "").ToString.Trim
                _MontoParaAbono_Ori = NuloPorNro(_Arreglo(i, 1), "").ToString.Trim

                If Not String.IsNullOrWhiteSpace(_CodAutoVenta_Ori) AndAlso Not String.IsNullOrWhiteSpace(_MontoParaAbono_Ori) Then
                    _CodAutoVenta = NuloPorNro(numero_(_CodAutoVenta_Ori, 6), "")
                    Dim montoStr As String = NuloPorNro(_Arreglo(i, 1), 0).ToString.Trim

                    If Not Double.TryParse(montoStr, NumberStyles.Any, CultureInfo.InvariantCulture, _MontoParaAbono) Then
                        Double.TryParse(montoStr, NumberStyles.Any, CultureInfo.CurrentCulture, _MontoParaAbono)
                    End If
                End If

            Catch ex As Exception
                _Error = ex.Message
            End Try

            ' CORRECCIÓN: No usar TypeOf con un tipo valor (Double). Comprobar solo si es NaN.
            If Double.IsNaN(_MontoParaAbono) Then
                _Error = "La columna Monto debe ser un valor numérico. Valor: " & _MontoParaAbono_Ori
            End If

            If String.IsNullOrWhiteSpace(_CodAutoVenta_Ori) Then
                _Error = "La columna Código esta vacía"
            End If

            If String.IsNullOrWhiteSpace(_MontoParaAbono_Ori) Then
                _Error = "La columna Monto esta vacía"
            End If

            Dim _TieneError As Boolean
            Dim _TieneDiferencia As Boolean
            Dim _TieneDiferencia1peso As Boolean

            If String.IsNullOrEmpty(_Error) Then

                _TieneError = False
                _TieneDiferencia = False

                Dim _Msg = String.Empty
                Dim _Encontrado = False
                Dim _Diferencia As Double

                Dim _Filtro As String = "(NUCUDP = '" & _CodAutoVenta & "' And VADP = " & _MontoParaAbono & ") Or (CUDP = '" & _CodAutoVenta & "' And VADP = " & _MontoParaAbono & ")"

                If Chk_Refanti.Checked Then
                    _Filtro += " Or (REFANTI = '" & _CodAutoVenta & "' And VADP = " & _MontoParaAbono & ")"
                End If

                Dim _FilasEncontradas As DataRow() = _Tbl_Liquidacion.Select(_Filtro)

                ' Verificar si se encontraron filas y trabajar con ellas

                If _FilasEncontradas.Length > 0 Then

                    ' Por ejemplo, acceder al primer registro encontrado
                    Dim primeraFila As DataRow = _FilasEncontradas(0)

                    primeraFila.Item("Incluir") = True
                    TotalValSelec += _MontoParaAbono
                    _Encontrado = True

                Else

                    _Filtro = "(NUCUDP = '" & _CodAutoVenta & "' And VADP <> " & _MontoParaAbono & ") Or (CUDP = '" & _CodAutoVenta & "' And VADP <> " & _MontoParaAbono & ")"

                    If Chk_Refanti.Checked Then
                        _Filtro += " Or (REFANTI = '" & _CodAutoVenta & "' And VADP = " & _MontoParaAbono & ")"
                    End If

                    Dim _FilasDiferencias As DataRow() = _Tbl_Liquidacion.Select(_Filtro)

                    If _FilasDiferencias.Length > 0 Then
                        ' Por ejemplo, acceder al primer registro encontrado
                        Dim primeraFila As DataRow = _FilasDiferencias(0)

                        _TieneDiferencia = True

                        Dim _Str_Nucudp = primeraFila.Item("NUCUDP").ToString.Trim
                        Dim _Str_Cudp = primeraFila.Item("CUDP").ToString.Trim

                        _Diferencia = _MontoParaAbono - primeraFila.Item("VADP")

                        If _Str_Nucudp = _CodAutoVenta Then
                            _Error = "Se encuentra el Numero Doc: [" & _CodAutoVenta_Ori & "], pero el monto no coincide $ " & FormatNumber(_MontoParaAbono, 0) & ", Diferencia: " & _Diferencia
                        End If

                        If _Str_Cudp = _CodAutoVenta Then
                            _Error = "Se encuentra la cuenta: [" & _CodAutoVenta_Ori & "], pero el monto no coincide $ " & FormatNumber(_MontoParaAbono, 0) & ", Diferencia: " & _Diferencia
                        End If

                        _Encontrado = True

                        If Chk_Dif1Peso.Checked AndAlso (_Diferencia = 1 Or _Diferencia = -1) Then

                            ' Por ejemplo, acceder al primer registro encontrado
                            'Dim primeraFila As DataRow = _FilasEncontradas(0)
                            _TieneDiferencia1peso = True
                            _TieneDiferencia = False
                            primeraFila.Item("Incluir") = True
                            TotalValSelec += _FilasDiferencias(0).Item("VADP") '_MontoParaAbono

                        End If

                    End If

                End If

                If Not _Encontrado Then

                    Consulta_sql = "Select IDMAEDPCE From MAEDPCE Where TIDP = 'TJV' And (CUDP = '" & _CodAutoVenta & "' Or NUCUDP = '" & _CodAutoVenta & "' )"

                    Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not IsNothing(_Row) Then

                        _Error = ", El pago se encontro en la MAEDPCE, pero no ha sido contabilizado."

                    End If

                End If

                If Not _Encontrado Then
                    _TieneError = True
                End If

                If _TieneError Then
                    _Error = "No se encuentra El código: [" & _CodAutoVenta_Ori & "] por el monto $ " & FormatNumber(_MontoParaAbono, 0) & _Error
                End If

            End If

            If String.IsNullOrEmpty(_Error) Then

                Dim _Liquid_Transbank As New LiqTransbank.Liquid_Transbank

                _Liquid_Transbank._CodAutoVenta = _CodAutoVenta
                _Liquid_Transbank._MontoParaAbono = _MontoParaAbono.ToString(CultureInfo.InvariantCulture)

                Ls_Liquid_Transbank.Add(_Liquid_Transbank)

                _SinProbremas += 1

            Else

                If _TieneError Then _Problemas += 1
                If _TieneDiferencia Then _Diferencias += 1
                If _TieneDiferencia1peso Then _Diferencias1peso += 1

                ' Ajustar log para mostrar fila real de Excel
                Sb_AddToLog("Fila Nro :" & (displayRow), "Problema: " & _Error, _Txt_Log, False)

            End If

            If CBool(_Problemas) Then
                Circular_Progres_Porc.ProgressColor = Color.Red
                Circular_Progres_Val.ProgressColor = Color.Red
            End If

            If _Cancelar Then
                Exit For
            End If

            _Contador += 1
            Circular_Progres_Porc.Value = CInt((_Contador * 100) / totalToProcess)
            If Circular_Progres_Porc.Value < 0 Then Circular_Progres_Porc.Value = 0
            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

            If Chk_Dif1Peso.Checked Then
                Lbl_Procesando.Text = "Leyendo fila " & displayRow & " de " & totalRows & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas & ", Diferencias: " & _Diferencias & ", Diferencias 1 peso: " & _Diferencias1peso

            Else
                Lbl_Procesando.Text = "Leyendo fila " & displayRow & " de " & totalRows & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas & ", Diferencias: " & _Diferencias

            End If


            System.Windows.Forms.Application.DoEvents()

            _Error = String.Empty

        Next

        Try

            If _Cancelar Then
                _Limpiar_Lista = True
                Return
            End If

            If CBool(_Problemas) Or CBool(_Diferencias) Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(_Problemas)))

                If Chk_Dif1Peso.Checked Then
                    _Leyend = "Existen líneas con problemas en el archivo de lectura." & vbCrLf & vbCrLf &
                          "No encontradas:" & _Problemas & vbCrLf &
                          "Diferencias: " & _Diferencias & vbCrLf &
                          "Diferencias 1 peso: " & _Diferencias1peso
                Else
                    _Leyend = "Existen líneas con problemas en el archivo de lectura." & vbCrLf & vbCrLf &
                          "No encontradas:" & _Problemas & vbCrLf &
                          "Diferencias: " & _Diferencias
                End If

                Sb_AddToLog("Resumen", Lbl_Procesando.Text, _Txt_Log, False)

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
