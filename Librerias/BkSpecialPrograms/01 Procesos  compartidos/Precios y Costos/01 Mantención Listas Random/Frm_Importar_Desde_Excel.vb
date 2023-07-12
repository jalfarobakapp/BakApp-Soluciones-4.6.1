Imports DevComponents.DotNetBar

Public Class Frm_Importar_Desde_Excel

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tbl_Paso_Precios As String
    Dim _Txt_Log As New TextBox

    Dim _Tbl_Precios As DataTable
    Dim _Tbl_Listas_Seleccionadas As DataTable
    Dim _Tbl_Productos_Seleccionados As DataTable

    Public Property Lista_Campos_Adicionales As List(Of ListaDePrecios.LsCamposAdicionalesTabpre) ' List(Of String)

    Dim _Traer_Productos As Boolean

    Dim _Limpiar As Boolean
    Dim _Cancelar As Boolean
    Dim _Hay_Problemas As Boolean

    Public ReadOnly Property Pro_Problemas() As Boolean
        Get
            Return _Hay_Problemas
        End Get
    End Property
    Public ReadOnly Property Pro_Traer_Productos() As Boolean
        Get
            Return _Traer_Productos
        End Get
    End Property
    Public ReadOnly Property Pro_Limpiar() As Boolean
        Get
            Return _Limpiar
        End Get
    End Property
    Public Property Pro_Tbl_Precios() As DataTable
        Get
            Return _Tbl_Precios
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Precios = value
        End Set
    End Property
    Public Property Pro_Tbl_Productos_Seleccionados() As DataTable
        Get
            Return _Tbl_Productos_Seleccionados
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Productos_Seleccionados = value
        End Set
    End Property

    Public Sub New(Nombre_Tbl_Paso_Precios As String,
                   Tbl_Listas_Seleccionadas As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Nombre_Tbl_Paso_Precios = Nombre_Tbl_Paso_Precios
        _Tbl_Listas_Seleccionadas = Tbl_Listas_Seleccionadas

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Importar_Desde_Excel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Buscar_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Archivo.Click

        If Rdb_Exportar_Solo_Codigo.Checked Then
            Sb_Importar_Solo_Codigos()
        ElseIf Rdb_Exportar_Valores.Checked Then
            Sb_Importar_Con_Valores()
        End If

    End Sub

    Private Sub Btn_Archivo_Ayuda_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Archivo_Ayuda_Excel.Click

        Dim _Nom_Excel As String

        If Rdb_Exportar_Solo_Codigo.Checked Then
            Consulta_sql = "SELECT 'Caracter [13]' as 'Código'"
        ElseIf Rdb_Exportar_Valores.Checked Then

            Dim _CamposAdicionales = String.Empty

            If Not IsNothing(Lista_Campos_Adicionales) Then
                Dim _Cc = 8
                For Each Cmp As ListaDePrecios.LsCamposAdicionalesTabpre In Lista_Campos_Adicionales
                    _CamposAdicionales += ",'Númerico' as '" & Cmp.Campo & "'"
                    _Cc += 1
                Next
            End If

            Consulta_sql = "SELECT 'Caracter [3]' as Lista,'Caracter [13]' as 'Código','Númerico' as 'Precio Ud1'," &
                           "'Númerico' as 'Margen Ud1','Númerico' as 'Desc. Max. Ud1','Númerico' as 'Precio Ud2'" &
                           ",'Númerico' as 'Margen Ud2','Númerico' as 'Desc. Max. Ud2'" & _CamposAdicionales
        End If

        _Nom_Excel = "Ejemplo levantamiento precios"

        ExportarTabla_JetExcel(Consulta_sql, Me, _Nom_Excel)

    End Sub

    Sub Sb_Importar_Con_Valores()

        Dim _Nombre_Archivo As String
        Dim _Ubic_Archivo As String

        With OpenFileDialog1
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            '.ShowDialog(Me)

            If .ShowDialog(Me) = DialogResult.OK Then
                _Nombre_Archivo = .SafeFileName
                _Ubic_Archivo = .FileName
                Txt_Nombre_Archivo.Text = _Ubic_Archivo
                '_Tbl_Precios = Nothing
                'Sb_Limpiar()
            Else
                Beep()
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross, _
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        End With

        Dim i As Integer

        Dim _Kolt As String
        Dim _Kopr As String

        Dim _Pp01ud, _
            _Mg01ud, _
            _Dtma01ud As Double

        Dim _Pp02ud, _
            _Mg02ud, _
            _Dtma02ud As Double

        Dim _Error As String
        Dim Problemas As Integer
        Dim SinProbremas As Integer

        Dim _ImpEx As New Class_Importar_Excel
        Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")
        Dim _Arreglo = _ImpEx.Importar_Excel_Array(_Ubic_Archivo, _Extencion, 0)
        Dim _Filas = _Arreglo.GetUpperBound(0)
        Dim _RegInsert As Long = 0

        Sb_Habilitar_Deshabilitar_Comandos(False, True)
        Circular_Progres_Val.Maximum = _Filas

        Dim _Contador As Integer = 0

        Dim _Desde = 0

        If Chk_Primera_Fila_Es_encabezado.Checked Then
            _Desde = 1
        End If

        Consulta_sql = "Truncate Table " & _Nombre_Tbl_Paso_Precios
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        _Error = String.Empty

        If Not IsNothing(Lista_Campos_Adicionales) Then
            Dim _Cc = 8
            For Each Cmp As ListaDePrecios.LsCamposAdicionalesTabpre In Lista_Campos_Adicionales
                Try
                    Dim _Valor = NuloPorNro(_Arreglo(1, _Cc), 0)
                Catch ex As Exception
                    _Error += "Falta el campo: " & Cmp.Campo & " en el documento Excel" & vbCrLf
                    Sb_AddToLog("Fila Nro :" & i + 1, "Problema!. " & _Error, _Txt_Log, False)
                End Try
                _Cc += 1
            Next

        End If

        If Not String.IsNullOrEmpty(_Error) Then
            MessageBoxEx.Show(Me, "Error en el formato del archivos Excel." & vbCrLf & vbCrLf &
                              _Error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty
            Return
        End If




        For i = _Desde To _Filas

            System.Windows.Forms.Application.DoEvents()

            Try

                _Kolt = NuloPorNro(_Arreglo(i, 0), "")
                _Kopr = NuloPorNro(_Arreglo(i, 1), "")

                _Pp01ud = NuloPorNro(_Arreglo(i, 2), 0)
                _Mg01ud = NuloPorNro(_Arreglo(i, 3), 0)
                _Dtma01ud = NuloPorNro(_Arreglo(i, 4), 0)

                _Pp02ud = NuloPorNro(_Arreglo(i, 5), 0)
                _Mg02ud = NuloPorNro(_Arreglo(i, 6), 0)
                _Dtma02ud = NuloPorNro(_Arreglo(i, 7), 0)

                _Error = String.Empty

                _Kopr = QuitaEspacios_ParaCodigos(_Kopr, 13)

            Catch ex As Exception
                _Error = ex.Message
            End Try

            Dim _Descripcion As String
            Dim _Rtu As Double
            Dim _Ud01pr As String
            Dim _Ud02pr As String

            If String.IsNullOrEmpty(_Error) Then

                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Kopr & "'"
                Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_RowProducto Is Nothing) Then

                    _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
                    _Rtu = _RowProducto.Item("RLUD")
                    _Ud01pr = _RowProducto.Item("UD01PR")
                    _Ud02pr = _RowProducto.Item("UD02PR")
                Else

                    If String.IsNullOrEmpty(_Kopr) Then
                        _Descripcion = "#CODVACIO#"
                    Else
                        _Descripcion = "#NO EXISTE#"
                    End If

                End If

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Nombre_Tbl_Paso_Precios, _
                                            "KOPR = '" & _Kopr & "' And KOLT = '" & _Kolt & "'"))

                If _Reg Then
                    Sb_AddToLog("Fila Nro :" & i, "Problema: Producto duplicado en listado, Código [" & _Kopr & "]", _
                                _Txt_Log, False)
                    Problemas += 1
                Else

                    If _Descripcion = "#NO EXISTE#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: El producto no existe, Código [" & _Kopr & "]", _
                                    _Txt_Log, False)
                        Problemas += 1
                    ElseIf _Descripcion = "#CODVACIO#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: Código en blanco", _
                                   _Txt_Log, False)
                        Problemas += 1
                    Else

                        Consulta_sql += My.Resources.Recursos_LP.SQLQuery_Traer_Productos_LP_New
                        Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", "And Mp.KOPR = '" & _Kopr & "'")
                        Consulta_sql = Replace(Consulta_sql, "#Listas#", "('" & _Kolt & "')")
                        Consulta_sql = Replace(Consulta_sql, "#Tbl_Paso_LP#", _Nombre_Tbl_Paso_Precios)

                        Consulta_sql = Replace(Consulta_sql, "#Otros_Campos1#", "")
                        Consulta_sql = Replace(Consulta_sql, "#Otros_Campos2#", "")

                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Consulta_sql += "Update " & _Nombre_Tbl_Paso_Precios & " Set" & vbCrLf &
                                        "PP01UD = " & De_Num_a_Tx_01(_Pp01ud, False, 5) & "," & vbCrLf &
                                        "MG01UD = " & De_Num_a_Tx_01(_Mg01ud, False, 5) & "," & vbCrLf &
                                        "DTMA01UD = " & De_Num_a_Tx_01(_Dtma01ud, False, 5) & "," & vbCrLf &
                                        "PP02UD = " & De_Num_a_Tx_01(_Pp02ud, False, 5) & "," & vbCrLf &
                                        "MG02UD = " & De_Num_a_Tx_01(_Mg02ud, False, 5) & "," & vbCrLf &
                                        "DTMA02UD = " & De_Num_a_Tx_01(_Dtma02ud, False, 5) & "," & vbCrLf &
                                        "FINMAES = 1," & vbCrLf &
                                        "Editado = 1" & vbCrLf &
                                        "Where KOLT = '" & _Kolt & "' And KOPR = '" & _Kopr & "'" & vbCrLf & vbCrLf


                        If Not IsNothing(Lista_Campos_Adicionales) Then
                            Dim _Cc = 8
                            For Each Cmp As ListaDePrecios.LsCamposAdicionalesTabpre In Lista_Campos_Adicionales
                                Try
                                    Dim _Valor As Double = NuloPorNro(_Arreglo(i, _Cc), 0)
                                    Consulta_sql += "Update " & _Nombre_Tbl_Paso_Precios & " Set" & vbCrLf &
                                                    Cmp.Campo & " = " & De_Num_a_Tx_01(_Valor, False, 5) & vbCrLf &
                                                    "Where KOLT = '" & _Kolt & "' And KOPR = '" & _Kopr & "'" & vbCrLf
                                Catch ex As Exception
                                    Problemas += 1
                                    _Error = "Falta el campo: " & Cmp.Campo & " en el documento Excel; " & ex.Message
                                    Sb_AddToLog("Fila Nro :" & i + 1, "Problema!. " & _Error, _Txt_Log, False)
                                    Problemas += 1
                                End Try
                                _Cc += 1
                            Next

                        End If

                        Dim _Ok_ As Boolean

                        If CBool(Problemas) Then
                            _Ok_ = True
                        Else
                            _Ok_ = _Sql.Ej_consulta_IDU(Consulta_sql, False)
                        End If

                        If _Ok_ Then
                            SinProbremas += 1
                        Else
                            Sb_AddToLog("Fila Nro :" & i + 1, "Problema!. " & _Error & " Código " & _Kopr,
                            _Txt_Log, False)
                            Problemas += 1
                        End If
                    End If
                End If

            Else

                Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & "Código: [" & _Kopr & "]", _
                 _Txt_Log, False)
                Problemas += 1

            End If

            If CBool(Problemas) Then
                Circular_Progres_Porc.ProgressColor = Color.Red
                Circular_Progres_Val.ProgressColor = Color.Red
            End If

            If _Cancelar Then
                Exit For
            End If

            System.Windows.Forms.Application.DoEvents()

            _Contador += 1
            Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas) 'Mas
            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value '& "%"

            Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & SinProbremas & _
                                  ", Problemas: " & Problemas & ", Producto: " & Trim(_Descripcion)

        Next


        Try

            If _Cancelar Then
                _Limpiar = True
                Return
            End If

            _Hay_Problemas = CBool(Problemas)

            If _Hay_Problemas Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(Problemas)))

                If Problemas = 1 Then
                    _Leyend = "Existe " & Problemas & " línea con problema en el archivo de lectura"
                Else
                    _Leyend = "Existen " & Problemas & " líneas con problemas en el archivo de lectura"
                End If

                _Limpiar = True

                MessageBoxEx.Show(Me, _Leyend & vbCrLf & _
                                  "a continuación se mostrar una lista con los errores", _
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fm As New Frm_Archivo_TXT
                Fm.Pro_Nombre_Archivo = "Error_LevLista.txt"
                Fm.Pro_Texto_Log = _Txt_Log.Text
                Fm.ShowDialog(Me)
                Fm.Dispose()

            Else

                Consulta_sql = My.Resources.Recursos_LP.SQLQuery_Actualizar_Costos_Impuestos_New
                Consulta_sql = Replace(Consulta_sql, "#Tbl_Paso_LP#", _Nombre_Tbl_Paso_Precios)
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)

                Consulta_sql += vbCrLf & "Select * From " & _Nombre_Tbl_Paso_Precios

                _Tbl_Precios = _Sql.Fx_Get_Tablas(Consulta_sql)
                _Tbl_Productos_Seleccionados = Nothing
                _Traer_Productos = True

                Me.Close()


            End If

        Catch ex As Exception

        Finally
            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty
        End Try



    End Sub

    Sub Sb_Importar_Solo_Codigos()

        Dim _Nombre_Archivo As String
        Dim _Ubic_Archivo As String

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
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross, _
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

        For i = _Desde To _Filas

            Dim _Error = String.Empty

            System.Windows.Forms.Application.DoEvents()

            Dim _Kopr As String
            Dim _Descripcion As String

            Try
                _Kopr = NuloPorNro(_Arreglo(i, 0), "")
            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Kopr & "'"
                Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_RowProducto Is Nothing) Then

                    _Descripcion = _RowProducto.Item("NOKOPR")

                    Dim _Ok_ As Boolean

                    If CBool(_Problemas) Then
                        _Ok_ = True
                    Else
                        _Ok_ = _Sql.Ej_consulta_IDU(Consulta_sql, False)
                    End If

                    If _Ok_ Then
                        _SinProbremas += 1
                    Else
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema!.  Código " & _Kopr,
                        _Txt_Log, False)
                        _Problemas += 1
                    End If

                Else

                    If String.IsNullOrEmpty(_Kopr) Then
                        _Descripcion = "#CODVACIO#"
                    Else
                        _Descripcion = "#NO EXISTE#"
                    End If

                    If _Descripcion = "#NO EXISTE#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: El producto no existe, Código [" & _Kopr & "]", _
                                    _Txt_Log, False)
                        _Problemas += 1
                    ElseIf _Descripcion = "#CODVACIO#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: Código en blanco", _
                                   _Txt_Log, False)
                        _Problemas += 1
                    End If

                End If

            Else

                Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & "Código: [" & _Kopr & "]", _
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

            Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & _SinProbremas & _
                                  ", Problemas: " & _Problemas & ", Producto: " & Trim(_Descripcion)

            System.Windows.Forms.Application.DoEvents()

        Next

        Try

            If _Cancelar Then
                _Limpiar = True
                Return
            End If

            _Limpiar = False

            Consulta_sql = "Select KOPR As Codigo From MAEPR" & vbCrLf &
                           "Where KOPR IN " & _Filtro_Productos
            _Tbl_Productos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)

            _Hay_Problemas = CBool(_Problemas)

            If _Hay_Problemas Then

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

                'CrearArchivoTxt(AppPath() & "\Data\" & RutEmpresa & "\Temp\", "Error_LevLista.txt", _Txt_Log.Text, False)
                'Process.Start("notepad.exe", AppPath() & "\Data\" & RutEmpresa & "\Temp\Error_LevLista.txt")

            End If

            If Not (_Tbl_Productos_Seleccionados Is Nothing) Then
                _Traer_Productos = True
                Me.Close()
            End If


        Catch ex As Exception

        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty

        End Try

    End Sub

    Sub Sb_Habilitar_Deshabilitar_Comandos(ByVal _Habilitar As Boolean, _
                                           ByVal _Habilitar_Cancelar As Boolean)

        _Cancelar = False

        Rdb_Exportar_Solo_Codigo.Enabled = _Habilitar
        Rdb_Exportar_Valores.Enabled = _Habilitar
        Chk_Primera_Fila_Es_encabezado.Enabled = _Habilitar

        Btn_Buscar_Archivo.Enabled = _Habilitar
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

    Private Sub Frm_Importar_Desde_Excel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro cancelar la acción?", "Cancelar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Cancelar = True
            Txt_Nombre_Archivo.Text = String.Empty
        End If

    End Sub

End Class
