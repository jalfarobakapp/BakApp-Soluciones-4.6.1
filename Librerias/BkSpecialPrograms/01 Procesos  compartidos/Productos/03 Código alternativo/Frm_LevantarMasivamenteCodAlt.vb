Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_LevantarMasivamenteCodAlt

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

        Consulta_sql = "Select KOPR As Codigo,Cast('' As Varchar(Max)) As CodAlternativo,Cast(0 As Bit) As EsQr,NOKOPR As Descripcion,Cast(0 As Int) As Multiplo," &
                       "Cast(0 As Int) As Unimulti,Cast('' As Varchar(13)) As Precio,Cast('' As Varchar(3)) As Koen,Cast('' As Varchar(Max)) As Log_Inf From MAEPR Where 1<0"
        _Tbl_Productos_Levantar = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_LevantarMasivamenteCodAlt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            Dim _CodAlternativo As String
            Dim _Descripcion As String
            Dim _Multiplo As Integer
            Dim _Unimulti As Integer
            Dim _Koen As String

            Try
                _Codigo = NuloPorNro(_Arreglo(i, 0), "")
                _CodAlternativo = NuloPorNro(_Arreglo(i, 1), "")
                _Descripcion = NuloPorNro(_Arreglo(i, 2), "")
                _Multiplo = NuloPorNro(_Arreglo(i, 3), 0)
                _Unimulti = NuloPorNro(_Arreglo(i, 4), 0)
                _Koen = NuloPorNro(_Arreglo(i, 5), "")
            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
                Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_RowProducto Is Nothing) Then

                    If String.IsNullOrEmpty(_Descripcion) Then
                        _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
                    End If

                    _Error = Fx_Agregar_Producto(_RowProducto, _CodAlternativo, _Descripcion, _Multiplo, _Unimulti, _Koen)

                    If String.IsNullOrEmpty(_Error) Then
                        _SinProbremas += 1
                    Else
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & ", Código [" & _Codigo & "]", _Txt_Log, False)
                        _Problemas += 1
                    End If

                Else

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
                                  ", Problemas: " & _Problemas & ", Producto: " & Trim(_Descripcion)

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

                    Dim _Log_Inf As String = Fx_GrabarCodigoAlternativoEnBD(_Fila)
                    Dim _Descripcion As String = _Fila.Item("Descripcion")

                    _Fila.Item("Log_Inf") = _Log_Inf


                    If String.IsNullOrEmpty(_Log_Inf) Then
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
                                  ", Insertados: " & _Insertado & ",Problemas: " & _Problemas & ", Producto: " & _Descripcion

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
                                 _CodAlternativo As String,
                                 _Descripcion As String,
                                 _Multiplo As Integer,
                                 _Unimulti As Integer,
                                 _Koen As String) As String

        Dim _Error = String.Empty
        Dim _Codigo = _RowProducto.Item("KOPR")

        Try
            Dim _Existe As Boolean

            If _Descripcion.Length > 50 Then
                Throw New System.Exception("La descripción no puede tener mas de 50 caracteres: " & _CodAlternativo)
            End If

            If Rdb_CodigoQR.Checked Then
                _Existe = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_CodQR", "CodigoQR = '" & _CodAlternativo & "' And Koen = '" & _Koen & "'"))

                If _Existe Then
                    Throw New System.Exception("Código QR ya existe: " & _CodAlternativo)
                End If
            End If

            If Rdb_CodigoDeBarras.Checked Then

                If _CodAlternativo.Length > 21 Then
                    Throw New System.Exception("El código alternativo no puede tener mas 21 caracteres: " & _CodAlternativo)
                End If

                _Existe = CBool(_Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & _CodAlternativo & "' And KOEN = '" & _Koen & "'"))

                If _Existe Then
                    Throw New System.Exception("Código de barras ya existe: " & _CodAlternativo)
                End If

            End If

            If String.IsNullOrEmpty(_CodAlternativo) Then
                Throw New System.Exception("Código alternativo no puede estar vacio")
            End If

            If Not String.IsNullOrEmpty(_Koen) Then
                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & _Koen & "'"))

                If Not _Reg Then
                    Throw New System.Exception("Código de entidad no existe: " & _Koen)
                End If
            End If

            Dim NewFila As DataRow
            NewFila = _Tbl_Productos_Levantar.NewRow
            With NewFila

                .Item("Codigo") = _Codigo
                .Item("CodAlternativo") = _CodAlternativo
                .Item("Descripcion") = _Descripcion
                .Item("Multiplo") = _Multiplo
                .Item("Unimulti") = _Unimulti
                .Item("Koen") = _Koen
                .Item("EsQr") = Rdb_CodigoQR.Checked

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

        Panel1.Enabled = _Habilitar
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

        Dim _Nom_Excel As String

        Consulta_sql = "Select 'Caracter [13]' As 'Código','Caracter [Max]' As 'CodAlternativo'," &
                       "'Caracter [50]' As 'Descripcion','Númerico' As 'Multiplo','Númerico (1 o 2)' As 'Unimulti'," &
                       "'Caracter [13]' As 'Koen'"

        _Nom_Excel = "Ejemplo levantamiento de codigos alternativos masivamente"

        ExportarTabla_JetExcel(Consulta_sql, Me, _Nom_Excel)

    End Sub

    Private Sub Btn_Buscar_Archivo_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Archivo_Excel.Click
        Sb_Importar_Productos_Excel()
    End Sub

    Function Fx_GrabarCodigoAlternativoEnBD(_RowProductoLev As DataRow) As String

        Dim _Error As String
        'Dim _Rtu As String = De_Num_a_Tx_01(_RowProducto.Item("RLUD"), False, 5)

        Dim _Kopr As String
        Dim _Kopral As String
        Dim _EsQr As Boolean
        Dim _Nokopral As String
        Dim _Koen As String
        Dim _Nmarca As String

        Dim _Cantmincom As Double
        Dim _Multdecom As Double

        Dim _Kopral2 As String
        Dim _Kopral3 As String
        Dim _Kopral4 As String
        Dim _Kopral5 As String

        Dim _Aux01 As String
        Dim _Aux02 As String
        Dim _Aux03 As String
        Dim _Aux04 As String
        Dim _Aux05 As String
        Dim _Aux06 As String

        Dim _Unimulti As Integer
        Dim _Multiplo As String
        Dim _Txtmulti As String

        Dim _Conmulti As Integer
        Dim _CodigoQR As String

        Dim _NroRd As Double

        Try

            _Kopr = _RowProductoLev.Item("Codigo")
            _Kopral = _RowProductoLev.Item("CodAlternativo")
            _EsQr = _RowProductoLev.Item("EsQr")
            _Nokopral = _RowProductoLev.Item("Descripcion")
            _Koen = _RowProductoLev.Item("Koen")

            _Unimulti = _RowProductoLev.Item("Unimulti")
            _Multiplo = _RowProductoLev.Item("Multiplo")

            _Conmulti = (_Multiplo > 1)
            _CodigoQR = _Kopral

            If _EsQr Then
                _Kopral = Fx_Kopral_Alearorios("QRBk")
            End If

            If String.IsNullOrEmpty(_Kopral) Then

                Consulta_sql = "Select KOPRAL,KOEN,KOPR As 'Codigo',NOKOPRAL," &
                           "IsNull((Select NOKOPR From MAEPR Mp Where Mp.KOPR = Td.KOPR),NOKOPRAL) as 'Descripcion'" & vbCrLf &
                           "From TABCODAL Td" & vbCrLf &
                           "Where Td.KOEN = '" & _Koen & "' And Td.KOPRAL = '" & _Kopral & "'"
                Dim _TblPr As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblPr.Rows.Count) Then

                    Dim _Codigo As String = _TblPr.Rows(0).Item("Codigo")
                    Dim _Descripcion As String = _TblPr.Rows(0).Item("Descripcion")

                    Throw New System.Exception("El código alternativo " & _Kopral & " ya existe en el sistema para el siguiente producto:" & "Código : " & _Codigo & " - Descripción: " & _Descripcion)

                End If

            End If

            Consulta_sql = "Delete TABCODAL Where KOPRAL = '" & _Kopral & "' And KOPR = '" & _Kopr & "' And KOEN = '" & _Koen & "'" &
                       vbCrLf &
                       "Insert Into TABCODAL (KOPRAL,KOPR,NOKOPRAL,KOEN,NMARCA,CANTMINCOM,MULTDECOM,KOPRAL2,KOPRAL3,KOPRAL4,KOPRAL5" &
                       ",AUX01,AUX02,AUX03,AUX04,AUX05,AUX06,CONMULTI,UNIMULTI,MULTIPLO,TXTMULTI) Values " &
                       "('" & _Kopral & "','" & _Kopr & "','" & _Nokopral & "','" & _Koen & "','" & _Nmarca & "'," & _Cantmincom & "," & _Multdecom &
                       ",'" & _Kopral2 & "','" & _Kopral3 & "','" & _Kopral4 & "','" & _Kopral5 & "'" &
                       ",'" & _Aux01 & "','" & _Aux02 & "','" & _Aux03 & "','" & _Aux04 & "','" & _Aux05 & "','" & _Aux06 &
                       "'," & _Conmulti & "," & _Unimulti & "," & _Multiplo & ",'" & _Txtmulti & "')" & vbCrLf

            If _EsQr Then

                Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_CodQR Where CodigoQR = '" & _CodigoQR & "' And Kopral = '" & _Kopral & "'" & vbCrLf &
                                "Insert Into " & _Global_BaseBk & "Zw_Prod_CodQR (CodigoQR,Kopral) Values ('" & _CodigoQR & "','" & _Kopral & "')"

            End If

            If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                'MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            Consulta_sql = "Select * From TABCODAL Where KOPRAL = '" & _Kopral & "' And KOEN = '" & _Koen & "' And KOPR = '" & _Kopr & "'"
            Dim RowTabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion where Clas_unica = 1" & vbCrLf &
                     "And Codigo = '" & _Kopr & "' And DescripcionBusqueda = '" & _Nokopral & "'" & vbCrLf & vbCrLf &
                     "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Clas_unica)" & vbCrLf &
                     "Values ('" & _Kopr & "',0,'" & _Nokopral & "',1)"

            _Sql.Ej_consulta_IDU(Consulta_sql)

        Catch ex As Exception
            _Error = ex.Message
        End Try

        Return _Error

    End Function

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Function Fx_Kopral_Alearorios(_Sufijo As String) As String

        _Sufijo = "QRBk"

        Dim _Rd As Random
        Dim _NroRd As Double = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_CodQR", "1>0") + 1
        _Rd = New Random
        _NroRd += _Rd.Next(1, 9999999)

        Dim _NewKopral As String = "QRBk" & numero_(_NroRd, 10)

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & _NewKopral & "' And KOEN = ''"))

        If _Reg Then
            _NewKopral = Fx_Kopral_Alearorios(_Sufijo)
        End If

        Return _NewKopral

    End Function

End Class
