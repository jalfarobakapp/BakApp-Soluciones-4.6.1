Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_Imagenes_X_Producto_Lev

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos_Levantar As DataTable
    Dim _InitialDirectory As String
    Dim _Txt_Log As New TextBox
    Dim _Cancelar As Boolean
    Dim _Limpiar As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select KOPR As Codigo,Cast('' As Varchar(Max)) As Url" & vbCrLf &
                       "From MAEPR Where 1<0"
        _Tbl_Productos_Levantar = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Imagenes_X_Producto_Lev_Load(sender As Object, e As EventArgs) Handles Me.Load
        Btn_Cancelar.Visible = False
    End Sub

    Sub Sb_Importar_Productos_Excel()

        Dim _Nombre_Archivo_SExtencion As String
        Dim _Nombre_Archivo_CExtencion As String
        Dim _Ubic_Archivo As String

        Dim _OpenFileDialog As New OpenFileDialog

        With _OpenFileDialog
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            .CheckPathExists = True

            If Not Directory.Exists(_InitialDirectory) Then
                .InitialDirectory = _InitialDirectory
            End If

            If .ShowDialog(Me) = DialogResult.OK Then
                _Nombre_Archivo_SExtencion = System.IO.Path.GetFileNameWithoutExtension(.SafeFileName)
                _Ubic_Archivo = System.IO.Path.GetDirectoryName(.FileName)

                _Nombre_Archivo_CExtencion = .SafeFileName
                _Ubic_Archivo = .FileName
            Else
                Beep()
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        End With

        _Tbl_Productos_Levantar.Clear()

        Txt_Nombre_Archivo.Text = _Ubic_Archivo

        Dim _ImpEx As New Class_Importar_Excel
        Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo_CExtencion), ".", "")
        Dim _Arreglo = _ImpEx.Importar_Excel_Array(_Ubic_Archivo, _Extencion, 0)
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

            Dim _Codigo As String
            Dim _Url As String

            Try
                _Codigo = NuloPorNro(_Arreglo(i, 0), "")
                _Url = NuloPorNro(_Arreglo(i, 1), "")
            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
                Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_RowProducto Is Nothing) Then

                    _Error = Fx_Agregar_Producto(_RowProducto, _Url)

                    If String.IsNullOrEmpty(_Error) Then
                        _SinProbremas += 1
                    Else
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & ", Código [" & _Codigo & "]", _Txt_Log, False)
                        _Problemas += 1
                    End If

                Else

                    Dim _Descripcion As String

                    If String.IsNullOrEmpty(_Codigo) Then
                        _Descripcion = "#CODVACIO#"
                    Else
                        _Descripcion = "#NO EXISTE#"
                    End If

                    If _Descripcion = "#NO EXISTE#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: El producto no existe, Código [" & _Codigo & "]",
                                    _Txt_Log, False)
                        _Problemas += 1
                    ElseIf _Descripcion = "#CODVACIO#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: Código en blanco",
                                   _Txt_Log, False)
                        _Problemas += 1
                    End If

                End If

            Else

                Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & "Código: [" & _Codigo & "]",
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

            System.Windows.Forms.Application.DoEvents()

            _Contador += 1
            Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas)
            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

            Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas & ", Producto: " & Trim(_Codigo)

        Next

        Try

            If _Cancelar Then
                MessageBoxEx.Show(Me, "Acción cancelada por el usuario", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Limpiar = True
                Return
            End If

            _Limpiar = False

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

                _Tbl_Productos_Levantar.Clear()

            End If

            _Filas = _Tbl_Productos_Levantar.Rows.Count
            Circular_Progres_Val.Maximum = _Filas

            Dim _Insertado As Integer = 0

            If CBool(_Tbl_Productos_Levantar.Rows.Count) Then

                For Each _Fila As DataRow In _Tbl_Productos_Levantar.Rows

                    Dim _Codigo As String = _Fila.Item("Codigo")
                    Dim _Url As String = _Fila.Item("Url")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Imagenes (Codigo,Direccion_Imagen,Desde_URL) Values " &
                                   "('" & _Codigo & "','" & _Url & "',1)"

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        _Insertado += 1
                    Else
                        _Problemas += 1
                    End If

                    System.Windows.Forms.Application.DoEvents()

                    _Contador += 1
                    Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas)
                    Circular_Progres_Val.Value += 1
                    Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

                    Lbl_Procesando.Text = "Leyendo fila " & _Contador & " de " & _Filas & ". Estado Ok: " & _SinProbremas &
                                  ", Insertados: " & _Insertado & ",Problemas: " & _Problemas & ", Producto: " & _Codigo

                Next

                Me.Close()

            End If

        Catch ex As Exception

        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty

        End Try

    End Sub

    Function Fx_Agregar_Producto(_RowProducto As DataRow,
                                 _Url As String) As String

        Dim _Error = String.Empty
        Dim _Codigo = _RowProducto.Item("KOPR")

        Try

            Try
                Dim MyWebClient As New System.Net.WebClient
                Dim ImageInBytes() As Byte = MyWebClient.DownloadData(_Url)
            Catch ex As Exception
                Throw New System.Exception("Error 404 PAGE NOT FOUND.: " & _Url)
            End Try

            _Url = Replace(_Url, "'", "''")

            Dim NewFila As DataRow
            NewFila = _Tbl_Productos_Levantar.NewRow
            With NewFila

                .Item("Codigo") = _Codigo
                .Item("Url") = _Url

                _Tbl_Productos_Levantar.Rows.Add(NewFila)

            End With
        Catch ex As Exception
            _Error = ex.Message
        End Try

        Return _Error

    End Function

    Sub Sb_Habilitar_Deshabilitar_Comandos(_Habilitar As Boolean,
                                           _Habilitar_Cancelar As Boolean)

        _Cancelar = False

        Chk_Primera_Fila_Es_encabezado.Enabled = _Habilitar

        Btn_Buscar_Archivo_Excel.Enabled = _Habilitar
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

    Private Sub Btn_Buscar_Archivo_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Archivo_Excel.Click
        Sb_Importar_Productos_Excel()
    End Sub

    Private Sub Btn_Archivo_Ayuda_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Archivo_Ayuda_Excel.Click
        Dim _Nom_Excel As String

        Consulta_sql = "Select 'Caracter [13]' As 'Código','Caracter [Max]' As 'Url'"

        _Nom_Excel = "Ejemplo levantamiento de imagenes URL VS codigos"

        ExportarTabla_JetExcel(Consulta_sql, Me, _Nom_Excel)
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub
End Class
