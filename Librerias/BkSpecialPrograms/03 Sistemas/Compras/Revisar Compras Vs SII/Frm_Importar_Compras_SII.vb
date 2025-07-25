﻿Imports System.IO
Imports DevComponents.DotNetBar
Imports HEFSIIREGCOMPRAVENTAS.LIB
Imports Microsoft.Win32
Imports Newtonsoft.Json


Public Class Frm_Importar_Compras_SII

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim Conectar_SQL As String

    Dim _Cancelar As Boolean
    Dim _TblInforme As DataTable

    Dim _Periodo As Integer
    Dim _Mes As Integer

    Dim _Tabla_Paso As String

    Public Property Pro_Tbl_Informe() As DataTable
        Get
            Return _TblInforme
        End Get
        Set(value As DataTable)
            _TblInforme = value
        End Set
    End Property
    Public ReadOnly Property Pro_Tabla_Paso() As String
        Get
            Return _Tabla_Paso
        End Get
    End Property

    Public Sub New(Periodo As Integer, Mes As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Periodo = Periodo
        _Mes = Mes

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Importar_Compras_SII_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub Sb_Habilitar_Deshabilitar_Comandos(_Habilitar As Boolean,
                                           _Habilitar_Cancelar As Boolean)

        _Cancelar = False


        Chk_Primera_Fila_Es_encabezado.Enabled = _Habilitar

        Me.ControlBox = _Habilitar

        Circular_Progres_Porc.ProgressColor = Color.SteelBlue
        Circular_Progres_Val.ProgressColor = Color.SteelBlue
        Circular_Progres_Porc.Maximum = 100

        Circular_Progres_Porc.Value = 0
        Circular_Progres_Val.Value = 0

        Btn_Cancelar.Visible = _Habilitar_Cancelar

        Me.Refresh()

    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        If MessageBoxEx.Show(Me, "¿Esta seguro cancelar la acción?", "Cancelar",
                            MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            _Cancelar = True
            Sb_AddToLog("Importar SII", "Acción cancelada por el usuario", Txt_Log)
        End If
    End Sub

    Private Sub Btn_Buscar_Archivo_Click(sender As System.Object, e As System.EventArgs)

        Sb_Importar_Archivo_SII_Compras()

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Compras_en_SII"
        _TblInforme = _Sql.Fx_Get_DataTable(Consulta_Sql)

    End Sub

    Sub Sb_Importar_Archivo_SII_Compras()

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
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        End With

        Dim _ImpEx As New Class_Importar_Excel
        Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")
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


        Dim _Problemas As Integer
        Dim _SinProbremas As Integer

        Sb_Habilitar_Deshabilitar_Comandos(False, True)
        Circular_Progres_Val.Maximum = _Filas

        Dim _Contador As Integer = 0

        Dim _SqlQuery As String = String.Empty

        For i = _Desde To _Filas

            Dim _Error = String.Empty

            System.Windows.Forms.Application.DoEvents()


            Dim _TipoDoc As Integer
            Dim _Tido
            Dim _Rut_Proveedor As String
            Dim _Razon_Social As String
            Dim _Folio As String
            Dim _Fecha_Docto As Date
            Dim _Fecha_Recepcion As Date
            Dim _Fecha_Acuse As Date
            Dim _Monto_Exento As Double
            Dim _Monto_Neto As Double
            Dim _Monto_Iva_Recuperable As Double
            Dim _Monto_Iva_No_Recuperable As Double
            Dim _Monto_Total As Double
            Dim _Valor_Otro_impuesto As Double

            Dim _Total_Neto As Double
            Dim _Total_Impuestos As Double
            Dim _Total_Iva As Double
            Dim _Total_Bruto As Double

            Dim _Rut
            Dim _Rten As String
            Dim _Nudo As String

            Try

                _TipoDoc = NuloPorNro(_Arreglo(i, 1), 0)
                _Rut_Proveedor = NuloPorNro(_Arreglo(i, 3), "")

                _Rut = Split(_Rut_Proveedor, "-")
                _Rten = numero_(_Rut(0), 8)

                _Razon_Social = Trim(NuloPorNro(_Arreglo(i, 4), ""))
                _Folio = NuloPorNro(_Arreglo(i, 5), "")

                _Nudo = numero_(_Folio, 10)

                _Fecha_Docto = NuloPorNro(_Arreglo(i, 6), #1/1/2000#)
                _Fecha_Recepcion = NuloPorNro(_Arreglo(i, 7), #1/1/2000#)
                _Fecha_Acuse = NuloPorNro(_Arreglo(i, 8), #1/1/2000#)
                _Monto_Exento = NuloPorNro(_Arreglo(i, 9), 0)
                _Monto_Neto = NuloPorNro(_Arreglo(i, 10), 0)
                _Monto_Iva_Recuperable = NuloPorNro(_Arreglo(i, 11), 0)
                _Monto_Iva_No_Recuperable = NuloPorNro(_Arreglo(i, 12), 0)
                _Monto_Total = NuloPorNro(_Arreglo(i, 14), 0)
                _Valor_Otro_impuesto = NuloPorNro(_Arreglo(i, 25), 0)

                _Total_Neto = _Monto_Neto + _Monto_Exento + _Valor_Otro_impuesto
                _Total_Iva = _Monto_Iva_Recuperable
                _Total_Bruto = _Monto_Total

            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                _Tido = Fx_Tido(_TipoDoc)


                Consulta_Sql = "Select top 1 * From MAEEN Where RTEN = '" & _Rten & "'"
                Dim _RowProveedor As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Endo As String

                If Not (_RowProveedor Is Nothing) Then
                    _Endo = Trim(_RowProveedor.Item("KOEN"))
                End If

                Consulta_Sql = "Select Top 1 * From MAEEDO Where EMPRESA = '" & Mod_Empresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "' And ENDO = '" & _Endo & "'"
                Dim _RowMaeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Idmaeedo As Integer = 0
                Dim _Libro As String = String.Empty
                Dim _Vanedo As Double = 0
                Dim _Vaivdo As Double = 0
                Dim _Vabrdo As Double = 0
                Dim _Diferencia As Double = 0

                Dim _Idmaeedo_Sugerido As Integer = 0
                Dim _Libro_Sugerido As String = String.Empty
                Dim _Tido_Sugerido As String = String.Empty
                Dim _Nudo_Sugerido As String = String.Empty


                If Not (_RowMaeedo Is Nothing) Then
                    _Idmaeedo = _RowMaeedo.Item("IDMAEEDO")
                    _Libro = _RowMaeedo.Item("LIBRO")
                    _Vanedo = _RowMaeedo.Item("VANEDO")
                    _Vaivdo = _RowMaeedo.Item("VAIVDO")
                    _Vabrdo = _RowMaeedo.Item("VABRDO")
                    _Diferencia = _Vabrdo - _Monto_Total
                Else
                    Consulta_Sql = "Select Top 1 * From MAEEDO Where TIDO = '" & _Tido & "' And ENDO = '" & _Endo & "' And VABRDO = " & De_Num_a_Tx_01(_Monto_Total, False, 5)
                    _RowMaeedo = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    If Not (_RowMaeedo Is Nothing) Then
                        _Idmaeedo_Sugerido = _RowMaeedo.Item("IDMAEEDO")
                        _Libro_Sugerido = _RowMaeedo.Item("LIBRO")
                        _Tido_Sugerido = _RowMaeedo.Item("TIDO")
                        _Nudo_Sugerido = _RowMaeedo.Item("NUDO")
                    End If

                End If

                _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Compras_en_SII (Periodo,Mes,TipoDoc,Tido,Nudo,Endo,Rut_Proveedor," &
                            "Razon_Social,Folio,Fecha_Docto," &
                            "Fecha_Recepcion,Fecha_Acuse,Monto_Exento,Monto_Neto,Monto_Iva_Recuperable," &
                            "Monto_Iva_No_Recuperable,Monto_Total,Valor_Otro_impuesto" &
                            ",Idmaeedo,Libro,Vanedo,Vaivdo,Vabrdo,Diferencia," &
                            "Idmaeedo_Sugerido,Libro_Sugerido,Tido_Sugerido,Nudo_Sugerido) Values " & vbCrLf &
                            "(" & _Periodo & "," & _Mes & "," & _TipoDoc & ",'" & _Tido & "','" & _Nudo & "','" & _Endo & "','" & _Rut_Proveedor & "'" &
                            ",'" & _Razon_Social & "','" & _Folio & "'" &
                            ",'" & Format(_Fecha_Docto, "yyyyMMdd") & "','" & Format(_Fecha_Recepcion, "yyyMMdd") & "'" &
                            ",'" & Format(_Fecha_Acuse, "yyyyMMdd") & "'" &
                            "," & De_Num_a_Tx_01(_Monto_Exento, False, 5) &
                            "," & De_Num_a_Tx_01(_Monto_Neto, False, 5) &
                            "," & De_Num_a_Tx_01(_Monto_Iva_Recuperable, False, 5) &
                            "," & De_Num_a_Tx_01(_Monto_Iva_No_Recuperable, False, 5) &
                            "," & De_Num_a_Tx_01(_Monto_Total, False, 5) &
                            "," & _Valor_Otro_impuesto &
                            "," & _Idmaeedo &
                            ",'" & _Libro & "'" &
                            "," & De_Num_a_Tx_01(_Vanedo, False, 5) &
                            "," & De_Num_a_Tx_01(_Vaivdo, False, 5) &
                            "," & De_Num_a_Tx_01(_Vabrdo, False, 5) &
                            "," & De_Num_a_Tx_01(_Diferencia, False, 5) &
                            "," & _Idmaeedo_Sugerido &
                            ",'" & _Libro_Sugerido & "'" &
                            ",'" & _Tido_Sugerido & "'" &
                            ",'" & _Nudo_Sugerido & "')" & vbCrLf

            Else
                'Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & "Código: [" & _Kopr & "]", _
                ' _Txt_Log, False)
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
            Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas) 'Mas
            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value '& "%"

            'Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & _SinProbremas &
            '                      ", Problemas: " & _Problemas

        Next

        _SqlQuery = "Delete " & _Global_BaseBk & "Zw_Compras_en_SII Where Periodo = " & _Periodo & " And Mes = " & _Mes &
                    vbCrLf &
                    vbCrLf &
                    _SqlQuery
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set" & vbCrLf &
                       "Monto_Exento = Monto_Exento*-1," & vbCrLf &
                       "Monto_Neto = Monto_Neto*-1," & vbCrLf &
                       "Monto_Iva_Recuperable = Monto_Iva_Recuperable *-1," & vbCrLf &
                       "Monto_Iva_No_Recuperable = Monto_Iva_No_Recuperable *-1," & vbCrLf &
                       "Monto_Total = Monto_Total*-1," & vbCrLf &
                       "Valor_Otro_impuesto = Valor_Otro_impuesto*-1," & vbCrLf &
                       "Vanedo = Vanedo*-1," & vbCrLf &
                       "Vaivdo = Vaivdo*-1," & vbCrLf &
                       "Vabrdo = Vabrdo*-1" & vbCrLf &
                       "Where Periodo = " & _Periodo & " And Mes = " & _Mes & " And Tido = 'NCC'"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        Try

            Me.Close()


        Catch ex As Exception

        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            'Txt_Nombre_Archivo.Text = String.Empty
        End Try

    End Sub

    Private Function Fx_Tido(_TipoDoc As Integer) As String

        Select Case _TipoDoc
            Case 33, 34, 56
                Return "FCC"
            Case 39 '"BLV", "BSV"
                Return "BLC"
            Case 52 '"GDV", "GDP"
                Return "GRC"
            Case 61
                Return "NCC"
            Case Else
                Return "???"
        End Select

        'Return "FACTURA" 33
        'Return "FACTURA EXENTA" 34
        'Return "GUIA DE DESPACHO" 52
        'Return "FACTURA DE COMPRA" 46
        'Return "NOTA DE DEBITO" 56
        'Return "NOTA DE CREDITO" 61
        'Return "ORDEN DE COMPRA" 801

    End Function

    Private Sub Btn_Importar_Desde_XML_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Desde_XML.Click

        'Sb_Importar_Archivos_Json()

        Btn_Importar_Desde_XML.Enabled = False
        Sb_Importar_Archivos_Json_SIIRegCV()
        Btn_Importar_Desde_XML.Enabled = True

    End Sub
    Sub Sb_Importar_Archivos_Json()

        Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        _Clas_Hefesto_Dte_Libro.Circular_Progres_Porc = Circular_Progres_Porc
        _Clas_Hefesto_Dte_Libro.Circular_Progres_Val = Circular_Progres_Val

        Dim _RecuperarComprasRegistro As HefRespuesta
        Dim _RecuperarComprasPendientes As HefRespuesta

        _RecuperarComprasRegistro = _Clas_Hefesto_Dte_Libro.Fx_RecuperarComprasRegistro(_Periodo, _Mes)

        If _RecuperarComprasRegistro.EsCorrecto Then
            Sb_AddToLog("Importar SII", "Es correcto: " & _RecuperarComprasRegistro.EsCorrecto, Txt_Log)
            Sb_AddToLog("Importar SII", "Mensaje    : " & _RecuperarComprasRegistro.Mensaje, Txt_Log)
            Sb_AddToLog("Importar SII", "Detalle    :" & _RecuperarComprasRegistro.Directorio, Txt_Log)
        Else
            Sb_AddToLog("Importar SII", "Es correcto: " & _RecuperarComprasRegistro.EsCorrecto, Txt_Log)
            Sb_AddToLog("Importar SII", "Mensaje    : " & _RecuperarComprasRegistro.Mensaje, Txt_Log)
            MessageBoxEx.Show(Me, _RecuperarComprasRegistro.Mensaje, "Error al importar el archivo Registro de compras",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        _RecuperarComprasPendientes = _Clas_Hefesto_Dte_Libro.Fx_RecuperarComprasPendientes(_Periodo, _Mes)

        If _RecuperarComprasPendientes.EsCorrecto Then
            Sb_AddToLog("Importar SII", "Es correcto: " & _RecuperarComprasPendientes.EsCorrecto, Txt_Log)
            Sb_AddToLog("Importar SII", "Mensaje    : " & _RecuperarComprasPendientes.Mensaje, Txt_Log)
            Sb_AddToLog("Importar SII", "Detalle    :" & _RecuperarComprasPendientes.Directorio, Txt_Log)
        Else
            Sb_AddToLog("Importar SII", "Es correcto: " & _RecuperarComprasPendientes.EsCorrecto, Txt_Log)
            Sb_AddToLog("Importar SII", "Mensaje    : " & _RecuperarComprasPendientes.Mensaje, Txt_Log)
            MessageBoxEx.Show(Me, _RecuperarComprasPendientes.Mensaje, "Error al importar el archivo Registro de compras",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Sb_AddToLog("Importar SII", "Rescatando datos desde archivos Json...", Txt_Log)

        Dim _Fichero1 As String = File.ReadAllText(_RecuperarComprasRegistro.Directorio)
        Dim _Fichero2 As String = File.ReadAllText(_RecuperarComprasPendientes.Directorio)


        ' Convierte el contenido JSON de _Fichero1 a un DataSet usando Newtonsoft.Json
        Dim _DataSet As New DataSet()
        _DataSet = JsonConvert.DeserializeObject(Of DataSet)(_Fichero1)

        Dim _Tbl_Registro_Compras As DataTable '= Fx_TblFromJson(_Fichero1, "RegistroCompras")
        Dim _Tbl_Registro_Compras_Pendientes As DataTable = Fx_TblFromJson(_Fichero2, "RegistroComprasPendientes")

        _Tbl_Registro_Compras = _DataSet.Tables("RegistroCompras")

        If _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_Json(_Tbl_Registro_Compras,
                                                                              _Tbl_Registro_Compras_Pendientes,
                                                                              _Periodo, _Mes) Then
            Me.Close()
        End If

    End Sub

    Sub Sb_Importar_Archivos_Json_SIIRegCV()

        Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        _Clas_Hefesto_Dte_Libro.Circular_Progres_Porc = Circular_Progres_Porc
        _Clas_Hefesto_Dte_Libro.Circular_Progres_Val = Circular_Progres_Val

        Sb_AddToLog("Importar SII", "Rescatando datos desde archivos Json...", Txt_Log)

        Dim _periodo2 As String = _Periodo & "-" & Fx_Rellena_ceros(_Mes, 2)

        Dim _Directorio_SIIRegCV = Application.StartupPath & "\SIIRegCV\SIIRegCV.exe"
        Dim _Ejecutar As String = _Directorio_SIIRegCV & Space(1) & "" & _periodo2 & " " & RutEmpresa '& " True"

        Try
            Shell(_Ejecutar, AppWinStyle.NormalFocus, True)
        Catch ex As Exception
            MessageBoxEx.Show(Me,
                        ex.Message, "SIIRegCV", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End Try

        Dim _Directorio_Error = Application.StartupPath & "\SIIRegCV\Empresas\Errores.txt"

        ' Verificar si existe el archivo de error y mostrar alerta
        If File.Exists(_Directorio_Error) Then
            Dim mensajeError As String = File.ReadAllText(_Directorio_Error)
            Sb_AddToLog("Importar SII", mensajeError, Txt_Log)
            'MessageBoxEx.Show(Me, "Se detectó un error al ejecutar SIIRegCV:" & vbCrLf & mensajeError, "Error SIIRegCV", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Abrir la carpeta donde está el archivo de error
            Dim carpetaError As String = Path.GetDirectoryName(_Directorio_Error)
            If Directory.Exists(carpetaError) Then
                Process.Start("explorer.exe", carpetaError)
            End If
            'Shell(_Directorio_Error, AppWinStyle.NormalFocus, True)
            Return
        End If


        Dim _Dir_ComprasRegistro As String = Application.StartupPath & "\SIIRegCV\Empresas\" & RutEmpresa & "\Resultados\Compras\" & _periodo2 & "\RegistrosCompras.json"
        Dim _Dir_ComprasRegistroPendientes As String = Application.StartupPath & "\SIIRegCV\Empresas\" & RutEmpresa & "\Resultados\Compras\" & _periodo2 & "\RegistrosComprasPendientes.json"

        Dim _Tbl_Registro_Compras As DataTable
        Dim _Tbl_Registro_Compras_Pendientes As DataTable

        If File.Exists(_Dir_ComprasRegistro) Then
            Dim _Fichero1 As String = File.ReadAllText(_Dir_ComprasRegistro)
            ' Convierte el contenido JSON de _Fichero1 a un DataSet usando Newtonsoft.Json
            Dim _DataSet As New DataSet()
            _DataSet = JsonConvert.DeserializeObject(Of DataSet)(_Fichero1)
            _Tbl_Registro_Compras = _DataSet.Tables("RegistroCompras")
        Else
            _Tbl_Registro_Compras = Nothing
        End If

        If File.Exists(_Dir_ComprasRegistroPendientes) Then
            Dim _Fichero1 As String = File.ReadAllText(_Dir_ComprasRegistroPendientes)
            ' Convierte el contenido JSON de _Fichero1 a un DataSet usando Newtonsoft.Json
            Dim _DataSet As New DataSet()
            _DataSet = JsonConvert.DeserializeObject(Of DataSet)(_Fichero1)
            _Tbl_Registro_Compras_Pendientes = _DataSet.Tables("RegistroCompras")
        Else
            _Tbl_Registro_Compras_Pendientes = Nothing
        End If

        If _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_Json(_Tbl_Registro_Compras,
                                                                              _Tbl_Registro_Compras_Pendientes,
                                                                              _Periodo, _Mes) Then
            Me.Close()
        End If

    End Sub

    Sub Sb_Importar_XML_Old()

        Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        _Clas_Hefesto_Dte_Libro.Circular_Progres_Porc = Circular_Progres_Porc
        _Clas_Hefesto_Dte_Libro.Circular_Progres_Val = Circular_Progres_Val

        '_Ubic_Archivo = "D:\OneDrive\Documentos\Empresas\Sierralta\Hefesto_DTE\CONFIGURACION\Salida\" & RutEmpresa & "\" & _Periodo

        '_Clas_Hefesto_Dte_Libro.Estatus = Lbl_Procesando

        If System.IO.File.Exists(_Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe") Then 'Application.StartupPath & "\BakApp_Demonio.exe") Then

            Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
            Dim _Ejecutar As String = _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe" & Space(1) & RutEmpresa & Space(1) & _Periodo & "-" & numero_(_Mes, 2)

            Try
                Shell(_Ejecutar, AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBoxEx.Show(Me,
                        ex.Message, "Libro de compras...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End Try

        Else

            MessageBoxEx.Show(Me,
                        "No se encontro el archivo HEFESTO_LIBROS.exe en el directorio (" & _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA)",
                        "Hefesto_DTE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        'Lbl_Procesando.Text = "..."

        If _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_XML(_Periodo, _Mes) Then
            Me.Close()
        End If

    End Sub

End Class
