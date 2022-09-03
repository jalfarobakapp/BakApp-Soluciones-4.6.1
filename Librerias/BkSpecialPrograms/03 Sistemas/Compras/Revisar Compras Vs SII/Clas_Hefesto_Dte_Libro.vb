Imports System.Globalization
Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Clas_Hefesto_Dte_Libro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Directorio_Hefesto As String = AppPath() & "\Data\Hefesto_Dte"

    Dim _Circular_Progres_Val As New CircularProgress
    Dim _Circular_Progres_Porc As New CircularProgress
    Dim _Cancelar As Boolean
    Dim _Estatus As Object
    Dim _Problemas As Integer
    Dim _SinProbremas As Integer
    Dim _Formulario As Form

    Public Property Directorio_Hefesto As String
        Get
            Return _Directorio_Hefesto
        End Get
        Set(value As String)
            _Directorio_Hefesto = value
        End Set
    End Property

    Public Property Circular_Progres_Val As CircularProgress
        Get
            Return _Circular_Progres_Val
        End Get
        Set(value As CircularProgress)
            _Circular_Progres_Val = value
        End Set
    End Property

    Public Property Circular_Progres_Porc As CircularProgress
        Get
            Return _Circular_Progres_Porc
        End Get
        Set(value As CircularProgress)
            _Circular_Progres_Porc = value
        End Set
    End Property

    Public Property Cancelar As Boolean
        Get
            Return _Cancelar
        End Get
        Set(value As Boolean)
            _Cancelar = value
        End Set
    End Property

    Public Property Estatus As Object
        Get
            Return _Estatus
        End Get
        Set(value As Object)
            _Estatus = value
        End Set
    End Property

    Public Property Problemas As Integer
        Get
            Return _Problemas
        End Get
        Set(value As Integer)
            _Problemas = value
        End Set
    End Property

    Public Property SinProbremas As Integer
        Get
            Return _SinProbremas
        End Get
        Set(value As Integer)
            _SinProbremas = value
        End Set
    End Property

    Public Property Formulario As Form
        Get
            Return _Formulario
        End Get
        Set(value As Form)
            _Formulario = value
        End Set
    End Property

    Public Sub New()
        Sb_Directorio_Hefecto_DTE_Libro_Compra_Venta()
    End Sub

    Sub Sb_Directorio_Hefecto_DTE_Libro_Compra_Venta()

        If Not Directory.Exists(_Directorio_Hefesto) Then
            System.IO.Directory.CreateDirectory(_Directorio_Hefesto)
        End If

        _Directorio_Hefesto = _Directorio_Hefesto & "\Libros_CV"

        If Not Directory.Exists(_Directorio_Hefesto) Then
            System.IO.Directory.CreateDirectory(_Directorio_Hefesto)
        End If

        If Not Directory.Exists(_Directorio_Hefesto & "\CONFIGURACION") Then
            System.IO.Directory.CreateDirectory(_Directorio_Hefesto & "\CONFIGURACION")
        End If

        If Not Directory.Exists(_Directorio_Hefesto & "\CONFIGURACION\Empresas") Then
            System.IO.Directory.CreateDirectory(_Directorio_Hefesto & "\CONFIGURACION\Empresas")
        End If

        If Not Directory.Exists(_Directorio_Hefesto & "\CONFIGURACION\NoProcesadas") Then
            System.IO.Directory.CreateDirectory(_Directorio_Hefesto & "\CONFIGURACION\NoProcesadas")
        End If

        If Not Directory.Exists(_Directorio_Hefesto & "\CONFIGURACION\Salida") Then
            System.IO.Directory.CreateDirectory(_Directorio_Hefesto & "\CONFIGURACION\Salida")
        End If

        If Not Directory.Exists(_Directorio_Hefesto & "\CONFIGURACION\Salida\" & RutEmpresa) Then
            System.IO.Directory.CreateDirectory(_Directorio_Hefesto & "\CONFIGURACION\Salida\" & RutEmpresa)
        End If

    End Sub

    Function Fx_Importar_Archivo_SII_Compras_Desde_XML(_Year As Integer,
                                                       _Month As Integer) As Boolean

        Dim _Periodo As String = _Year & "-" & Fx_Rellena_ceros(_Month, 2)

        Dim _Ubic_Archivo As String = _Directorio_Hefesto & "\CONFIGURACION\Salida\" & RutEmpresa & "\" & _Periodo

        Dim _Nombre_Archivo = "HEF_P" & _Periodo & "_COMPRAS_REGISTRO.XML"

        Dim _Tbl_Registro As DataTable

        Dim _SqlQuery As String = String.Empty

        Dim _Ds_Libro_Compra_Registro As New DataSet
        _Ds_Libro_Compra_Registro.Clear()

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Compras_en_SII Where Periodo = " & _Year & " And Mes = " & _Month
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If System.IO.File.Exists(_Ubic_Archivo & "\" & _Nombre_Archivo) Then

            _Ds_Libro_Compra_Registro.ReadXml(_Ubic_Archivo & "\" & _Nombre_Archivo)
            _Tbl_Registro = _Ds_Libro_Compra_Registro.Tables("Registro")
            _SqlQuery = Fx_Traer_Informacion_Desde_Xml(_Tbl_Registro, _Year, _Month)

            If Not String.IsNullOrEmpty(_SqlQuery) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)
            End If

        End If

        _Nombre_Archivo = "HEF_P" & _Periodo & "_COMPRAS_PENDIENTES.XML"

        Dim _Ds_Libro_Compra_Pendientes As New DataSet
        _Ds_Libro_Compra_Pendientes.Clear()

        _SqlQuery = String.Empty

        If System.IO.File.Exists(_Ubic_Archivo & "\" & _Nombre_Archivo) Then

            _Ds_Libro_Compra_Pendientes.ReadXml(_Ubic_Archivo & "\" & _Nombre_Archivo)
            _Tbl_Registro = _Ds_Libro_Compra_Pendientes.Tables("Registro")
            _SqlQuery = Fx_Traer_Informacion_Desde_Xml(_Tbl_Registro, _Year, _Month)

            If Not String.IsNullOrEmpty(_SqlQuery) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)
            End If

        End If

        'If String.IsNullOrEmpty(_SqlQuery) Then
        '    Return False
        'End If

        '_SqlQuery = "Delete " & _Global_BaseBk & "Zw_Compras_en_SII Where Periodo = " & _Year & " And Mes = " & _Month &
        '            vbCrLf &
        '            vbCrLf &
        '            _SqlQuery

        'If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Compras_en_SII Set" & vbCrLf &
                           "Monto_Exento = Monto_Exento*-1," & vbCrLf &
                           "Monto_Neto = Monto_Neto*-1," & vbCrLf &
                           "Monto_Iva_Recuperable = Monto_Iva_Recuperable *-1," & vbCrLf &
                           "Monto_Iva_No_Recuperable = Monto_Iva_No_Recuperable *-1," & vbCrLf &
                           "Monto_Total = Monto_Total*-1," & vbCrLf &
                           "Valor_Otro_impuesto = Valor_Otro_impuesto*-1," & vbCrLf &
                           "Vanedo = Vanedo*-1," & vbCrLf &
                           "Vaivdo = Vaivdo*-1," & vbCrLf &
                           "Vabrdo = Vabrdo*-1" & vbCrLf &
                           "Where Periodo = " & _Year & " And Mes = " & _Month & " And Tido = 'NCC'"
        Return _Sql.Ej_consulta_IDU(Consulta_sql)

        'End If

    End Function

    Function Fx_Importar_Archivo_SII_Ventas_Desde_XML(_Year As Integer,
                                                      _Month As Integer,
                                                      _Reenviar_Documentos_al_SII As Boolean) As Boolean

        Dim _Periodo As String = _Year & "-" & Fx_Rellena_ceros(_Month, 2)

        Dim _Ubic_Archivo As String = _Directorio_Hefesto & "\CONFIGURACION\Salida\" & RutEmpresa & "\" & _Periodo

        Dim _Nombre_Archivo = "HEF_P" & _Periodo & "_VENTAS.XML"

        Dim _Tbl_Registro As DataTable

        Dim _SqlQuery As String = String.Empty

        Dim _Ds_Libro_Venta_Registro As New DataSet
        _Ds_Libro_Venta_Registro.Clear()

        _Estatus.Text = "Revisando Libro de Ventas..."
        System.Windows.Forms.Application.DoEvents()

        If System.IO.File.Exists(_Ubic_Archivo & "\" & _Nombre_Archivo) Then

            _Ds_Libro_Venta_Registro.ReadXml(_Ubic_Archivo & "\" & _Nombre_Archivo)
            _Tbl_Registro = _Ds_Libro_Venta_Registro.Tables("Registro")

            Dim _Fecha = "01/" & numero_(_Month, 2) & "/" & _Year
            Dim _Fecha_Desde As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)
            Dim _Fecha_Hasta As DateTime = ultimodiadelmes(_Fecha_Desde)

            Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,FEEMDO,Cast(0 As Bit) As ENVIADO From MAEEDO Where TIDO In ('FCV','NCV')" & Space(1) &
                           "And FEEMDO Between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' And NUDONODEFI = 0"
            Dim _Tbl_Maeddo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Registro.Rows

                Dim _TipoDte = _Fila.Item("TipoDte")
                Dim _Tido1 = Fx_Tido_Venta(_TipoDte)
                Dim _Folio = _Fila.Item("Folio")
                Dim _Nudo1 = numero_(_Folio, 10)

                For Each _Fila_Ddo As DataRow In _Tbl_Maeddo.Rows

                    Dim _Tido2 = _Fila_Ddo.Item("TIDO")
                    Dim _Nudo2 = _Fila_Ddo.Item("NUDO")

                    If _Tido1 = _Tido2 And _Nudo1 = _Nudo2 Then
                        _Fila_Ddo.Item("ENVIADO") = 1
                        Exit For
                    End If

                Next

            Next

            Dim _Tbl_Maeddo_Enviar As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Maeddo, "ENVIADO = False", "TIDO")

            'Dim _RunMonitor_Corriendo As Boolean

            'For Each prog As Process In Process.GetProcesses
            '    If prog.ProcessName = "cmd" Then
            '        _RunMonitor_Corriendo = True
            '        'prog.Kill()
            '    End If
            'Next

            'If Not _RunMonitor_Corriendo Then

            '    Fx_Ejecutar_runMonitor_BAT(_Formulario)

            'End If

            If _Reenviar_Documentos_al_SII Then

                If _Tbl_Maeddo_Enviar.Rows.Count Then

                    'Consulta_sql = "Delete FMAEPETD Where IDDTE Not In (Select IDDTE From FMAEDTE)
                    '            Delete FMAEPETE Where IDPET NOT IN (SELECT IDPET FROM FMAEPETD)
                    '            Delete FMAESOBE WHERE IDPET NOT IN (SELECT IDPET FROM FMAEPETE)
                    '            Delete FMAERESE WHERE IDSOBE NOT IN (SELECT IDSOBE FROM FMAESOBE)"
                    '_Sql.Ej_consulta_IDU(Consulta_sql)

                    For Each _Fila_Ddo As DataRow In _Tbl_Maeddo_Enviar.Rows

                        Dim _Idmaeedo = _Fila_Ddo.Item("IDMAEEDO")
                        Dim _Tido = _Fila_Ddo.Item("TIDO")
                        Dim _Nudo = _Fila_Ddo.Item("TIDO")
                        Dim _Enviado = _Fila_Ddo.Item("ENVIADO")

                        If Not _Enviado Then

                            'FIRMA ELECTRONICA 
                            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
                            Dim _Iddt As Integer = _Class_DTE.Fx_Dte_Genera_Documento(Formulario, True)
                            Dim _Idpet As Integer

                            If CBool(_Iddt) Then
                                _Idpet = _Class_DTE.Fx_Dte_Firma(Formulario, _Iddt, True)
                            End If

                        End If

                    Next

                End If

            End If



            'ExportarTabla_JetExcel_Tabla(_Tbl_Maeddo, Nothing, "Libro Ventas")

        End If

    End Function

    Function Fx_Ejecutar_runMonitor_BAT(ByVal _Formulario As Form) As Boolean

        Dim _FolderBrowserDialog As New FolderBrowserDialog

        Dim _Directorio_GenDTE As String = _Global_Row_EstacionBk.Item("Directorio_GenDTE")

        If Not Directory.Exists(_Directorio_GenDTE) Then

            MessageBoxEx.Show(_Formulario, "El directorio GenDTE no existe o no esta registrado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, True)

            With _FolderBrowserDialog

                .Reset()

                ' leyenda  
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then

                    Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                    Dim _Directorio_Seleccionado As String = .SelectedPath

                    If File.Exists(_Directorio_Seleccionado & "\runMonitor.BAT") Then
                        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Directorio_GenDTE = '" & _Directorio_Seleccionado & "'" & vbCrLf &
                                       "Where NombreEquipo = '" & _NombreEquipo & "'"

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                            _Directorio_GenDTE = _Directorio_Seleccionado
                            _Global_Row_EstacionBk.Item("Directorio_GenDTE") = _Directorio_GenDTE
                        Else
                            Return False
                        End If

                    Else

                        MessageBoxEx.Show(_Formulario,
                        "No se encontro el archivo GenDTE.BAT en el directorio (" & _Directorio_Seleccionado & ")",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, True)

                    End If

                End If

                .Dispose()

            End With

        End If

        If File.Exists(_Directorio_GenDTE & "\runMonitor.BAT") Then

            Dim _Ejecutar As String = _Directorio_GenDTE & "\runMonitor.BAT"

            Try
                Shell(_Ejecutar, AppWinStyle.MinimizedNoFocus, False)
                Return True
            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            End Try

        Else

            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Demonio",
                               "No se encontro el archivo runMonitor.BAT en el directorio (" & _Directorio_GenDTE & ")", "", "", "", "", 0, FUNCIONARIO)

        End If

    End Function

    Function Fx_Traer_Informacion_Desde_Xml(_Tbl_Registro As DataTable,
                                            _Year As Integer,
                                            _Month As Integer) As String

        Dim _Color = Circular_Progres_Val.ProgressColor

        Circular_Progres_Val.Maximum = _Tbl_Registro.Rows.Count

        Dim _Contador As Integer = 0

        Dim _SqlQuery As String = String.Empty

        Dim _Filas = _Tbl_Registro.Rows.Count

        For Each _Fila As DataRow In _Tbl_Registro.Rows

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
            'Dim _Total_Impuestos As Double
            Dim _Total_Iva As Double
            Dim _Total_Bruto As Double

            Dim _Rut
            Dim _Rten As String
            Dim _Nudo As String

            '<TipoDte>33</TipoDte>
            '<RutCons>79514800-0</RutCons>
            '<Tipo_Compra>Del Giro</Tipo_Compra>
            '<RUT_Proveedor>96719620-7</RUT_Proveedor>
            '<Razon_Social>ADT SECURITY SERVICES S. A.</Razon_Social>
            '<Folio>10045848</Folio>
            '<Fecha_Docto>2019-10-01</Fecha_Docto>
            '<Fecha_Recepcion>2019-09-28 18:04:35</Fecha_Recepcion>
            '<Fecha_Acuse />
            '<Monto_Exento>0</Monto_Exento>
            '<Monto_Neto>33472</Monto_Neto>
            '<Monto_IVA_Recuperable>6360</Monto_IVA_Recuperable>
            '<Monto_Iva_No_Recuperable />
            '<Codigo_IVA_No_Rec. />
            '<Monto_Total>39832</Monto_Total>
            '<Monto_Neto_Activo_Fijo />
            '<IVA_Activo_Fijo />
            '<IVA_uso_Comun />
            '<Impto._Sin_Derecho_a_Credito />
            '<IVA_No_Retenido>0</IVA_No_Retenido>
            '<Tabacos_Puros />
            '<Tabacos_Cigarrillos />
            '<Tabacos_Elaborados />
            '<NCE_o_NDE_sobre_Fact._de_Compra>0</NCE_o_NDE_sobre_Fact._de_Compra>
            '<Codigo_Otro_Impuesto />
            '<Valor_Otro_Impuesto />
            '<Tasa_Otro_Impuesto />

            Try

                Try
                    _TipoDoc = _Fila.Item("TipoDte") '_ro NuloPorNro(_Arreglo(i, 1), 0)
                Catch ex As Exception
                    _TipoDoc = _Fila.Item("Tipo_Doc") '_ro NuloPorNro(_Arreglo(i, 1), 0)
                End Try

                _Rut_Proveedor = _Fila.Item("RUT_Proveedor")

                _Rut = Split(_Rut_Proveedor, "-")
                _Rten = numero_(_Rut(0), 8)

                _Razon_Social = Replace(_Fila.Item("Razon_Social"), "'", "")
                _Folio = _Fila.Item("Folio")

                'If _Compras_Pendientes Then

                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Compras_en_SII",
                                                    "Periodo = " & _Year & " And Mes = " & _Month & " And Rut_Proveedor = '" & _Rut_Proveedor & "' And Folio = '" & _Folio & "'")

                If CBool(_Reg) Then
                    Throw New System.Exception("Folio: " & _Folio & " ya esta registrado")
                End If

                'End If

                _Nudo = numero_(_Folio, 10)

                _Fecha_Docto = NuloPorNro(_Fila.Item("Fecha_Docto"), #1/1/2000#)
                _Fecha_Recepcion = NuloPorNro(_Fila.Item("Fecha_Recepcion"), #1/1/2000#)

                Try
                    If String.IsNullOrEmpty(_Fila.Item("Fecha_Acuse")) Then
                        _Fecha_Acuse = #1/1/2000#
                    Else
                        _Fecha_Acuse = NuloPorNro(_Fila.Item("Fecha_Acuse"), #1/1/2000#)
                    End If
                Catch ex As Exception
                    _Fecha_Acuse = #1/1/2000#
                End Try

                _Monto_Exento = NuloPorNro(_Fila.Item("Monto_Exento"), 0)
                _Monto_Neto = NuloPorNro(_Fila.Item("Monto_Neto"), 0)
                _Monto_Iva_Recuperable = NuloPorNro(De_Txt_a_Num_01(_Fila.Item("Monto_IVA_Recuperable")), 0)
                _Monto_Iva_No_Recuperable = NuloPorNro(De_Txt_a_Num_01(_Fila.Item("Monto_Iva_No_Recuperable")), 0)
                _Monto_Total = NuloPorNro(_Fila.Item("Monto_Total"), 0)
                _Valor_Otro_impuesto = NuloPorNro(De_Txt_a_Num_01(_Fila.Item("Valor_Otro_Impuesto")), 0)

                _Total_Neto = _Monto_Neto + _Monto_Exento + _Valor_Otro_impuesto
                _Total_Iva = _Monto_Iva_Recuperable
                _Total_Bruto = _Monto_Total

            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                _Tido = Fx_Tido_Compra(_TipoDoc)

                Consulta_sql = "Select top 1 * From MAEEN Where RTEN = '" & _Rten & "'"
                Dim _RowProveedor As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Endo As String

                If Not (_RowProveedor Is Nothing) Then
                    _Endo = Trim(_RowProveedor.Item("KOEN"))
                End If

                Consulta_sql = "Select Top 1 * From MAEEDO Where EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "' And ENDO = '" & _Endo & "'"
                Dim _RowMaeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

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
                    Consulta_sql = "Select Top 1 * From MAEEDO Where TIDO = '" & _Tido & "' And ENDO = '" & _Endo & "' And VABRDO = " & De_Num_a_Tx_01(_Monto_Total, False, 5)
                    _RowMaeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

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
                            "(" & _Year & "," & _Month & "," & _TipoDoc & ",'" & _Tido & "','" & _Nudo & "','" & _Endo & "','" & _Rut_Proveedor & "'" &
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

            _Estatus.Text = "Leyendo fila " & _Contador & " de " & _Filas & ". Estado Ok: " & _SinProbremas & ", Problemas: " & _Problemas

        Next

        Circular_Progres_Val.Value = 0
        Circular_Progres_Val.Text = 0
        Circular_Progres_Porc.Value = 0

        Circular_Progres_Val.ProgressColor = _Color
        Circular_Progres_Porc.ProgressColor = _Color

        Return _SqlQuery & vbCrLf

    End Function

    Private Function Fx_Tido_Compra(ByVal _TipoDoc As Integer) As String

        Select Case _TipoDoc
            Case 33, 34
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

    Private Function Fx_Tido_Venta(ByVal _TipoDoc As Integer) As String

        Select Case _TipoDoc
            Case 33
                Return "FCV"
            Case 34
                Return "FVX"
            Case 39
                Return "BLV"
            Case 43
                Return "FVL"
            Case 56
                Return "FDV"
            Case 52
                Return "GDV"
            Case 61
                Return "NCV"
            Case Else
                Return "???"
        End Select

        'FVZ FACTURA VENTA ZONA FRANCA                         	102       
        'FDE FACTURA DEBITO EXPORTACION                        	104       
        'FEE FACTURA VTA.MERCAD.EXTRANJERO                     	110       
        'FEV FACTURA DE EXPORTACION                            	110       
        'FDX FACTURA DEBITO EXENTA                             	111       
        'FCV FACTURA DE VENTA                                  	33        
        'FVT FACTURA VENTA TERCEROS                            	33        
        'FVX FACTURA DE VENTA EXENTA                           	34        
        'BLV BOLETA DE VENTA                                   	39        
        'BSV BOLETA DE VENTA SIMPLE                            	39        
        'BLX BOLETA DE VENTA EXENTA                            	41        
        'FVL FACTURA LIQUIDACION VENTAS                        	43        
        'GDD GUIA DESPACHO POR DEVOLUCION                      	52        
        'GDP GUIA DESPACHO PRESTAMO                            	52        
        'GDV GUIA DESPACHO VENTA                               	52        
        'FDV FACTURA DEBITO DE VENTA                           	56        
        'ESC ESCRITURA                                         	ESC       
        'FDB FACTURA DEBITO TIPO B                             	FDB       
        'FDZ FACTURA DEBITO ZONA FRANCA                        	FDZ       
        'RIN RECIBO DE INGRESOS                                	RIN       

    End Function

End Class
