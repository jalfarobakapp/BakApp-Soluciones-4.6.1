Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_Filtro_Especial_MarcarMasivoExcel

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Nombre_Archivo_SExtencion As String
    Private _Nombre_Archivo_CExtencion As String
    Private _Cancelar As Boolean
    Private _Txt_Log As New TextBox
    Private _Limpiar As Boolean

    Public Property InitialDirectory As String
    Public Property ListaCodigos As List(Of String)

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ListaCodigos = New List(Of String)

    End Sub
    Private Sub Frm_Filtro_Especial_MarcarMasivoExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Habilitar_Deshabilitar_Comandos(True, False)
    End Sub
    Private Sub Btn_Buscar_Archivo_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Archivo_Excel.Click
        Sb_Importar_Productos_Excel()
    End Sub

    Sub Sb_Importar_Productos_Excel()

        Dim _Ubic_Archivo As String
        Dim _OpenFileDialog As New OpenFileDialog

        Dim _Problemas As Integer
        Dim _SinProbremas As Integer

        Try

            With _OpenFileDialog

                .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
                'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
                .FileName = String.Empty
                .CheckPathExists = True

                If Not Directory.Exists(InitialDirectory) Then
                    .InitialDirectory = InitialDirectory
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

            Txt_Nombre_Archivo.Text = _Ubic_Archivo

            Dim _ImpEx As New Class_Importar_Excel
            Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo_CExtencion), ".", "")
            Dim _ListaExcel As List(Of List(Of String)) = _ImpEx.Importar_Excel_Lista(_Ubic_Archivo, _Extencion, 0)

            Dim _Desde = 0

            If Chk_Primera_Fila_Es_encabezado.Checked Then
                _Desde = 1
            End If

            Sb_Habilitar_Deshabilitar_Comandos(False, True)
            Circular_Progres_Val.Maximum = _ListaExcel.Count

            Dim _Contador As Integer = 0

            For Each _Fila As Object In _ListaExcel

                If _Desde = 1 AndAlso _ListaExcel.IndexOf(_Fila) = 0 Then
                    Continue For
                End If

                Dim _Codigo As String = String.Empty
                Dim _Error As String = String.Empty

                Try
                    _Codigo = NuloPorNro(_Fila(0), "")
                Catch ex As Exception
                    _Error = ex.Message
                End Try

                If String.IsNullOrEmpty(_Error) Then
                    ListaCodigos.Add(_Codigo)
                Else
                    Sb_AddToLog("Fila: " & _ListaExcel.IndexOf(_Fila) + 1, "Problema: " & _Error & " Código: [" & _Codigo & "]", _Txt_Log, False)
                    _Problemas += 1
                End If

                If CBool(_Problemas) Then
                    Circular_Progres_Porc.ProgressColor = Color.Red
                    Circular_Progres_Val.ProgressColor = Color.Red
                End If

                If _Cancelar Then
                    Exit For
                End If

                Circular_Progres_Porc.Value = ((_ListaExcel.IndexOf(_Fila) + 1) * 100) / _ListaExcel.Count
                Circular_Progres_Val.Value += 1
                Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

                Lbl_Procesando.Text = "Procesando fila " & _ListaExcel.IndexOf(_Fila) + 1 & " de " & _ListaExcel.Count & ". Estado Ok: " & _SinProbremas & ", Problemas: " & _Problemas

            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Return
        End Try

        Try

            If _Cancelar Then
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

            End If

            If CBool(ListaCodigos.Count) Then

                ' Eliminar códigos duplicados de la lista
                ListaCodigos = ListaCodigos.Distinct().ToList()
                Me.Close()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty

        End Try

    End Sub

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

    Private Sub Btn_Archivo_Ayuda_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Archivo_Ayuda_Excel.Click

        Dim _Msj = "Debe crear un archivo en Excel el cual debe tener una columna con los códigos a tickear."

        MessageBoxEx.Show(Me, _Msj, "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class
