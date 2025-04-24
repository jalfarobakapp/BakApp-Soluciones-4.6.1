Imports DevComponents.DotNetBar

Public Class Frm_Inv_Sector_ImporExcel

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private Ls_Zw_Inv_Ubicaciones As List(Of Zw_Inv_Sector)
    Private Ls_Errores As New List(Of LsValiciones.Mensajes)
    Private _Cancelar As Boolean
    Private _Cl_inventario As Cl_Inventario

    Public UbicacionesInsertadas As Boolean

    Public Sub New(_IdInventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cl_inventario = New Cl_Inventario
        _Cl_inventario.Fx_Llenar_Zw_Inv_Inventario(_IdInventario)

        Sb_Color_Botones_Barra(Bar1)

    End Sub
    Private Sub Frm_Inv_UbicacionesImporExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Btn_Importar_Archivo_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Archivo.Click

        Dim _Nombre_Archivo As String
        Dim _Ubic_Archivo As String

        Dim _Limpiar_Lista As Boolean
        Ls_Zw_Inv_Ubicaciones = New List(Of Zw_Inv_Sector)

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
        Dim _Diferencias As Integer
        Dim _SinProbremas As Integer

        Sb_Habilitar_Deshabilitar_Comandos(False, True)
        Circular_Progres_Val.Maximum = _Filas

        Dim _Contador As Integer = 0
        Dim _ListaUbicaciones As New List(Of String)

        For i = _Desde To _Filas

            Dim _Msg_Error As New LsValiciones.Mensajes
            Dim _Zw_Inv_Ubicaciones As New Zw_Inv_Sector

            System.Windows.Forms.Application.DoEvents()

            If CBool(Ls_Errores.Count) Then
                Circular_Progres_Porc.ProgressColor = Color.Red
                Circular_Progres_Val.ProgressColor = Color.Red
            End If

            Dim _Sector As String
            Dim _NombreSector As String
            Dim _CodFuncionario As String

            Try

                _Sector = If(_Arreglo(i, 0) Is Nothing, "", _Arreglo(i, 0).ToString().Trim())
                _NombreSector = If(_Arreglo(i, 1) Is Nothing, "", _Arreglo(i, 1).ToString().Trim())
                _CodFuncionario = If(_Arreglo(i, 2) Is Nothing, "", _Arreglo(i, 2).ToString().Trim())

                If String.IsNullOrWhiteSpace(_Sector) Then
                    Throw New System.Exception("La columna Sector esta vacía")
                End If

                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector",
                                            "Sector = '" & _Sector & "' And IdInventario = " & _Cl_inventario.Zw_Inv_Inventario.Id)

                If CBool(_Reg) Then
                    Throw New System.Exception("El Sector """ & _Sector & """ ya existe en este inventario")
                End If

                If _Sector.Length > 30 Then
                    Throw New System.Exception("El Sector """ & _Sector & """ excede los 30 caracteres")
                End If

                If _NombreSector.Length > 50 Then
                    Throw New System.Exception("El Sector """ & _NombreSector & """ excede los 50 caracteres")
                End If

                'Verificar si el encargado existe
                If String.IsNullOrWhiteSpace(_CodFuncionario) Then
                    _CodFuncionario = "''"
                    Throw New System.Exception("Falta el Cód.Encargado")
                End If

                Consulta_sql = "Select * From TABFU Where KOFU = '" & _CodFuncionario & "'"
                Dim _Row_Encargado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_Row_Encargado) Then
                    Throw New System.Exception("El Cód.Encargado """ & _CodFuncionario & """ No existe")
                End If

                If _Row_Encargado.Item("INACTIVO") Then
                    Throw New System.Exception("El Cód.Encargado """ & _CodFuncionario & "-" & _Row_Encargado.Item("NOKOFU").ToString.Trim & """ esta inactivo en Random")
                End If

                ' Verificando si el valor existe en la lista
                If _ListaUbicaciones.Contains(_Sector) And Not String.IsNullOrEmpty(_Sector) Then
                    Throw New System.Exception("El Sector """ & _Sector & """ aparece varias veces en la lista.")
                End If

                _ListaUbicaciones.Add(_Sector)

                If _Cancelar Then
                    Exit For
                End If

                System.Windows.Forms.Application.DoEvents()
                _Msg_Error.EsCorrecto = True

                With _Zw_Inv_Ubicaciones
                    .IdInventario = _Cl_inventario.Zw_Inv_Inventario.Id
                    .Sector = _Sector
                    .NombreSector = _NombreSector
                    .Abierto = True
                    .Empresa = _Cl_inventario.Zw_Inv_Inventario.Empresa
                    .Sucursal = _Cl_inventario.Zw_Inv_Inventario.Sucursal
                    .Bodega = _Cl_inventario.Zw_Inv_Inventario.Bodega
                    .CodFuncionario = _CodFuncionario
                End With

            Catch ex As Exception
                _Msg_Error.Col1_Mensaje = ex.Message
                _Msg_Error.Col2_Detalle = "Fila (" & i & ") - " & _Sector & " - " & _NombreSector & ", CodEncargado: " & _CodFuncionario
                _Msg_Error.EsCorrecto = False
                _Msg_Error.Icono = MessageBoxIcon.Error
            End Try

            If Not _Msg_Error.EsCorrecto Then
                _Problemas += 1
                Ls_Errores.Add(_Msg_Error)
            End If

            _Contador += 1
            Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas)
            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

            Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & _SinProbremas &
                          ", Problemas: " & _Problemas & ", Diferencias: " & _Diferencias

            If _Msg_Error.EsCorrecto Then
                Ls_Zw_Inv_Ubicaciones.Add(_Zw_Inv_Ubicaciones)
            End If

        Next


        Try

            If _Cancelar Then
                _Limpiar_Lista = True
                Return
            End If

            If CBool(Ls_Errores.Count) Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(_Problemas)))

                MessageBoxEx.Show(Me, _Leyend & vbCrLf &
                                  "a continuación se mostrar una lista con los errores",
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fmv As New Frm_Validaciones
                Fmv.ListaMensajes = Ls_Errores
                Fmv.ShowDialog(Me)
                Fmv.Dispose()

                Ls_Zw_Inv_Ubicaciones.Clear()

                'If CBool(Ls_Zw_Inv_Ubicaciones.Count) Then
                '    If MessageBoxEx.Show(Me, "¿Desea incorporar de todas maneras las ubicaciones que estan bien??", "Gestión",
                '                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                '        _Limpiar_Lista = True
                '        Return
                '    End If
                'End If

                'CrearArchivoTxt(AppPath() & "\Data\" & RutEmpresa & "\Temp\", "Error_LevLista.txt", _Txt_Log.Text, False)
                'Process.Start("notepad.exe", AppPath() & "\Data\" & RutEmpresa & "\Temp\Error_LevLista.txt")

            End If

            If CBool(Ls_Zw_Inv_Ubicaciones.Count) Then
                Sb_GrabarUbicaciones()
                Me.Close()
            Else
                _Limpiar_Lista = True
            End If

        Catch ex As Exception

        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            If _Limpiar_Lista Then
                Ls_Errores.Clear()
                Ls_Zw_Inv_Ubicaciones.Clear()
            End If

        End Try

    End Sub

    Sub Sb_GrabarUbicaciones()

        Dim _Cl_InvUbicacion As New Cl_InvSectores
        Dim _Ls_Mensajes As New List(Of LsValiciones.Mensajes)
        Dim _CuentaInsertadas As Integer

        For Each _Ubicacion In Ls_Zw_Inv_Ubicaciones

            _Cl_InvUbicacion.Zw_Inv_Sector = _Ubicacion

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_InvUbicacion.Fx_Crear_Sector(_Ubicacion)

            If _Mensaje.EsCorrecto Then
                _CuentaInsertadas += 1
            Else
                _Ls_Mensajes.Add(_Mensaje)
            End If

        Next

        If CBool(_Ls_Mensajes.Count) Then

            MessageBoxEx.Show(Me, "Hubo algunos problemas al insertar algunas ubicaciones",
                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim Fmv As New Frm_Validaciones
            Fmv.ListaMensajes = _Ls_Mensajes
            Fmv.ShowDialog(Me)
            Fmv.Dispose()

        End If

        UbicacionesInsertadas = True

        MessageBoxEx.Show(Me, "Se insertaron correctamente " & _CuentaInsertadas & " ubicaciones",
                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)


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

    Private Sub Btn_Archivo_Ayuda_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Archivo_Ayuda_Excel.Click
        Dim _Nom_Excel As String
        Consulta_sql = "Select 'Caracter [30]' As 'Sector','Caracter [50]' As 'NombreSector','Caracter [3]' As 'Cód.Encargado'"
        _Nom_Excel = "Ejemplo importar ubicaciones"
        ExportarTabla_JetExcel(Consulta_sql, Me, _Nom_Excel)
    End Sub
End Class
