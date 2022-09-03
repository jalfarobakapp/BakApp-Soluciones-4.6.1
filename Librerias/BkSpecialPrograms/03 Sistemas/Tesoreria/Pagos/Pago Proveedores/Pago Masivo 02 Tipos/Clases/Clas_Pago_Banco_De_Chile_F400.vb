Imports System.IO

Public Class Clas_Pago_Banco_De_Chile_F400

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _strError As String
    Dim _RutEmpresa As String
    Dim _DvEmpresa As String

    Dim _Directorio_Destino As String
    Dim _Nombre_Archivo As String

    Public Sub New()

        Dim _Rut = Split(RutEmpresaActiva, "-", 2)

        _RutEmpresa = _Rut(0)
        _DvEmpresa = _Rut(1)

        Directorio_Destino = AppPath() & "\Data\" & RutEmpresaActiva & "\Tmp"

        If Not Directory.Exists(Directorio_Destino) Then
            System.IO.Directory.CreateDirectory(Directorio_Destino)
        End If

        Directorio_Destino += "\Pago proveedores"

        If Not Directory.Exists(Directorio_Destino) Then
            System.IO.Directory.CreateDirectory(Directorio_Destino)
        End If

        Nombre_Archivo = "Pago Nomina BCH F400"

    End Sub

    Public Property StrError As String
        Get
            Return _strError
        End Get
        Set(value As String)
            _strError = value
        End Set
    End Property

    Public Property RutEmpresa As String
        Get
            Return _RutEmpresa
        End Get
        Set(value As String)
            _RutEmpresa = value
        End Set
    End Property

    Public Property DvEmpresa As String
        Get
            Return _DvEmpresa
        End Get
        Set(value As String)
            _DvEmpresa = value
        End Set
    End Property

    Public Property Directorio_Destino As String
        Get
            Return _Directorio_Destino
        End Get
        Set(value As String)
            _Directorio_Destino = value
        End Set
    End Property

    Public Property Nombre_Archivo As String
        Get
            Return _Nombre_Archivo
        End Get
        Set(value As String)
            _Nombre_Archivo = value
        End Set
    End Property

    Function Fx_CreaTXT_Banco_de_Chile_F400(_CC As Integer,
                                            _Nombre_Nomina As String,
                                            _Fecha_Pago As Date,
                                            _Monto_Total As Double,
                                            _Tbl_Transferencias As DataTable) As Boolean

        ' _CC = Codigo convenio - Maximo 3 caracteres

        Dim _Dv,
            _RutCompleto,
            _RutCompletoEmpresa,
            _Medio_Pago,
            _Banco,
            _ValeVista,
            _Encabezado,
            _CtaCte As String

        Dim i, _Rut, _NumeroMensaje, _CantidadRegistros As Integer
        Dim _MontoTotal As Double = 0
        Dim fechaActual As Date
        Dim fecha As Date

        StrError = String.Empty
        _NumeroMensaje = 0
        _CantidadRegistros = 0

        i = 0

        'se escribe la linea asociada al _Encabezado (tipo registro 01)

        _RutCompletoEmpresa = _RutEmpresa & "-" & _DvEmpresa

        Dim _Archivo_TXT As String = Path.GetTempFileName()

        Using _Archivo As StreamWriter = New StreamWriter(_Archivo_TXT)

            ' variable para almacenar la línea actual del dataview  
            Dim _Linea As String = String.Empty

            Dim _CC_Str As String = Rellenar(_CC, 3, "0", False)
            _RutCompleto = Rellenar(_RutEmpresa & _DvEmpresa, 10, "0", False)

            _Encabezado = "01" & _RutCompleto & _CC_Str & "00001"

            ' Maximo 25 pagos por nomina

            _Nombre_Nomina = _Nombre_Nomina.Trim

            If _Nombre_Nomina.Length > 25 Then
                StrError = StrError & "El nombre de la nomina no puede exceder los 25 caracteres." & vbCrLf
                Return False
            Else
                _Encabezado += Rellenar(_Nombre_Nomina, 25, " ", True)
            End If


            If IsDate(_Fecha_Pago) = True Then
                _Encabezado = _Encabezado & "01" & Format(_Fecha_Pago, "yyyyMMdd")
                fecha = _Fecha_Pago
            Else
                StrError = StrError & "La fecha de pago no tiene un formato valido sebe ser dd/mm/aaaa." & vbCrLf
                Return False
            End If

            If (_Monto_Total.ToString.Length > 11) Then
                StrError = StrError & "El monto total de pago no puede exceder los 11 caracteres." & vbCrLf
                Return False
            Else
                Dim _Monto_Total_Str As String = Convert.ToInt32(_Monto_Total)
                _Monto_Total_Str = Rellenar(_Monto_Total_Str, 11, "0", False) & "00"
                _Encabezado = _Encabezado & _Monto_Total_Str
            End If

            _Encabezado = _Encabezado & "   " & "N" & StrDup(322, " ") & "01"
            'flagTipoPago = Application.VLookup(Ht.Range("G2"), HtBBDD.Range("A4:B13"), 2, 0)

            'If IsError(flagTipoPago) Then
            '    strError = strError & "El Tipo de pago no corresponde." & vbCrLf
            'Else
            _Encabezado = _Encabezado & "0201" 'Application.VLookup(Ht.Range("G2"), HtBBDD.Range("A4:B13"), 2, 0)
            'End If

            '' Escribimos el encabezado del archiv txt

            _Linea = _Encabezado

            _Archivo.WriteLine(_Linea.ToString)

            If fecha < fechaActual Then
                StrError = StrError & "Fecha de pago es menor a fecha actual" & vbCrLf
            End If

            For Each _Fila As DataRow In _Tbl_Transferencias.Rows

                Dim _Endo = _Fila.Item("ENDO").ToString.Trim
                Dim _Suendo = _Fila.Item("SUENDO").ToString.Trim
                Dim _Mto_Total = _Fila.Item("SALDO")

                Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
                Dim _Row_Proveedor As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Proveedor) Then

                    Dim _Tipo_de_Operacion As String = _Row_Proveedor.Item("SUENDPEN").ToString.Trim
                    Dim _Koen As String = _Row_Proveedor.Item("KOEN").ToString.Trim
                    Dim _Rut_Beneficiario As String = _Row_Proveedor.Item("RTEN").ToString.Trim ': _Rut_Beneficiario = Rellenar2(Trim(_Rut_Beneficiario & RutDigito(_Rut_Beneficiario)), 10, "0", Enum_Relleno.Izquierda)
                    Dim _Nombre_Proveedor As String = Rellenar2(Mid(_Row_Proveedor.Item("NOKOEN").ToString.Trim, 1, 50), 60, " ", Enum_Relleno.Derecha).ToString.Trim
                    Dim _Cuenta_del_Beneficiario As String

                    _Cuenta_del_Beneficiario = Rellenar2(_Row_Proveedor.Item("CUENTABCO").ToString.Trim, 18, " ", Enum_Relleno.Derecha)

                    If String.IsNullOrEmpty(_Cuenta_del_Beneficiario.Trim) Then
                        _Cuenta_del_Beneficiario = "falta_cta_bnco_ben"
                    End If

                    Dim _Monto_de_Transferencia As String = Rellenar2(_Mto_Total, 11, "0", Enum_Relleno.Izquierda)

                    Dim _Asunto_email As String = Mid("PAGO " & UCase(RazonEmpresa), 1, 30).ToString.Trim
                    Dim _Direccion_emil As String = Mid(_Row_Proveedor.Item("EMAILCOMER").ToString.Trim, 1, 50).ToString.Trim

                    _Rut = _Row_Proveedor.Item("RTEN").ToString.Trim
                    _Dv = RutDigito(_Rut)

                    _ValeVista = "N"

                    _Medio_Pago = _Row_Proveedor.Item("ACTECOBCO").ToString.Trim

                    ' Medios de Pago

                    '  ***********************
                    '01  Abono en Cuenta Corriente del Banco de Chile
                    '02  Vale Vista entregado en Mesón del Banco de Chile
                    '06  Vale Vista entregado en Mesón del Banco de Chile
                    '07  Abono en Cuenta Corriente de Otros Bancos
                    '08  Abono en Cuenta de Ahorro de Otros Bancos
                    '11  Abono en Bancuenta Credichile
                    '12  Pago en efectivo Servipag

                    Select Case _Medio_Pago
                        Case "01", "02", "06", "07", "08", "11", "12"
                        Case Else
                            StrError = "El código del medio de pago del proveedor: " & _Nombre_Proveedor & " no es valido." & vbCrLf &
                                       "Revise la ficha del cliente campo [Código de actividad económica] -> (pestaña Cuentas)"
                            Return False
                    End Select

                    'If _Medio_Pago = "02" Or _Medio_Pago = "12" Then
                    '    If Ht.Cells(i + 4, 1).Value = "" Or Ht.Cells(i + 4, 2).Value = "" Or Ht.Cells(i + 4, 3).Value = "" Or Ht.Cells(i + 4, 4).Value = "" Or Ht.Cells(i + 4, 5).Value = "" Or Ht.Cells(i + 4, 7).Value = "" Then
                    '        strError = strError & "Los campos Rut Beneficiario, Dv, Nombre Beneficiario, Medio de Pago, Banco y Monto, de la fila: " & i + 4 & " deben tener informacion." & vbCrLf
                    '    End If
                    'Else
                    '    If Ht.Cells(i + 4, 1).Value = "" Or Ht.Cells(i + 4, 2).Value = "" Or Ht.Cells(i + 4, 3).Value = "" Or Ht.Cells(i + 4, 4).Value = "" Or Ht.Cells(i + 4, 5).Value = "" Or Ht.Cells(i + 4, 6).Value = "" Or Ht.Cells(i + 4, 7).Value = "" Then
                    '        strError = strError & "Los campos Rut Beneficiario, Dv, Nombre Beneficiario, Medio de Pago, Banco, Cuenta Corriente o Vista y Monto, de la fila: " & i + 4 & " deben tener informacion." & vbCrLf
                    '    End If
                    'End If

                    'If Rut < 1000000 Then

                    '    strError = strError & "El rut de la fila: " & i + 4 & " no es valido." & vbCrLf

                    'Else
                    '    If Dv <> dvrut(RutCompleto) Then
                    '        ' MsgBox Dv & "-" & dvrut(RutCompleto)
                    '        strError = strError & "El rut de la fila: " & i + 4 & " no es valido." & vbCrLf

                    '    End If
                    'End If

                    _Banco = _Row_Proveedor.Item("KOENDPEN").ToString.Trim



                    If (_Medio_Pago = "01" Or _Medio_Pago = "02" Or _Medio_Pago = "06" Or _Medio_Pago = "11" Or _Medio_Pago = "12") Then

                        'If (Ht.Cells(i + 4, 5).Value <> "BANCO DE CHILE /EDWARDS") Then
                        '    strAdvertencia = strAdvertencia & "El banco de la fila: " & i + 4 & " se cambiará a BANCO DE CHILE /EDWARDS." & vbCrLf
                        'End If

                        _Banco = "001"

                    End If

                    If (_Medio_Pago = "07" Or _Medio_Pago = "08") And _Banco = "001" Then
                        StrError = StrError & "El banco de la fila: " & i + 4 & " no puede ser BANCO DE CHILE /EDWARDS." & vbCrLf
                        Return False
                    End If

                    If _Banco <> "" Then

                        If Not Fx_Existe_Banco(_Banco) Then
                            StrError = "El Código del banco del proveedor: " & _Nombre_Proveedor & " no es valido." & vbCrLf &
                                       "Revise la ficha del cliente campo [Código del banco] -> (pestaña Cuentas)"
                            Return False
                        End If

                    End If

                    'Linea = "02" & WorksheetFunction.Rept("0", 9 - Len(Ht.Cells(2, 1).Value)) & Ht.Cells(2, 1).Value & Ht.Cells(2, 2).Value
                    _Linea = "02" & _RutCompleto & _CC_Str & "  00001"

                    _Linea = _Linea & _Medio_Pago & Rellenar(_Rut, 9, "0", False) & _Dv 'WorksheetFunction.Rept("0", 9 - Len(Rut)) & Rut & Dv

                    _Nombre_Proveedor = Rellenar2(Mid(_Row_Proveedor.Item("NOKOEN").ToString.Trim, 1, 50), 60, " ", Enum_Relleno.Derecha)

                    'If (Len(Ht.Cells(i + 4, 3).Value) > 60) Then
                    '    strError = strError & "El nombre beneficiario de la fila: " & i + 4 & " no puede exceder los 60 caracteres." & vbCrLf
                    'Else
                    'Linea = Linea & _ Ht.Cells(i + 4, 3).Value & WorksheetFunction.Rept(" ", 60 - Len(Ht.Cells(i + 4, 3).Value))
                    _Linea = _Linea & _Nombre_Proveedor

                    'End If
                    'StrDup(322, " ")

                    'Linea = Linea & "0" & WorksheetFunction.Rept(" ", 35)
                    'Linea = Linea & WorksheetFunction.Rept(" ", 15) & WorksheetFunction.Rept(" ", 15) & WorksheetFunction.Rept(" ", 7)

                    _Linea = _Linea & "0" & StrDup(35, " ")
                    _Linea = _Linea & StrDup(15, " ") & StrDup(15, " ") & StrDup(7, " ")

                    If (_Medio_Pago = "02") Then
                        'Personas Jurídicas  B1  Rut Beneficiarios sobre 50.000.000
                        'Persona Natural BC  Rut Beneficiarios Bajo 49.999.999
                        If CLng(_Rut) < 500000000 Then
                            _Linea = _Linea & "BC"
                        Else
                            _Linea = _Linea & "B1"
                        End If


                        'If Ht.Cells(i + 4, 10).Value = "" Then
                        'strError = strError & "El valor para vale vista acumulado de la fila: " & i + 4 & " no es valido." & vbCrLf
                        _ValeVista = "No"

                        'Else
                        'flagValeVista = Application.VLookup(Ht.Cells(i + 4, 10).Value, HtBBDD.Range("A54:B55"), 2, 0)

                        'If IsError(flagValeVista) Then
                        'strError = strError & "El valor para vale vista acumulado de la fila: " & i + 4 & " no es valido." & vbCrLf
                        'Else
                        'ValeVista = Application.VLookup(Ht.Cells(i + 4, 10).Value, HtBBDD.Range("A54:B55"), 2, 0)
                        'End If
                        'End If

                    Else
                        _Linea = _Linea & "  "
                    End If

                    'CtaCte = Replace(Ht.Cells(i + 4, 6).Value, "-", "")

                    _CtaCte = Replace(_Row_Proveedor.Item("CUENTABCO").ToString.Trim, "-", "")
                    _CtaCte = Rellenar2(_CtaCte, 22, " ", Enum_Relleno.Derecha)

                    _Linea = _Linea & _Banco

                    If _CtaCte.Length > 22 Then
                        StrError = StrError & "La cuenta corriente de la fila: " & i + 4 & " no puede exceder los 22 caracteres." & vbCrLf
                        StrError = "El Nro de la cuenta del proveedor: " & _Nombre_Proveedor & " no puede exceder los 22 caracteres." & vbCrLf &
                                   "Revise la ficha del cliente campo [Número de cuenta bancaria] -> (pestaña Cuentas)"
                        Return False
                    Else
                        _Linea = _Linea & _CtaCte
                    End If


                    _Linea = _Linea & "000"

                    Dim _Mto_Total_Str As String = _Mto_Total.ToString

                    If _Mto_Total < 1 Then
                        _Mto_Total_Str = String.Empty
                    End If


                    If (_Medio_Pago = "12" And _Mto_Total > 1000000) Then
                        StrError = "El monto de la fila: " & i + 4 & " no puede ser mayor a $1.000.000, para el medio de pago Servipag." & vbCrLf &
                                   "Proveedor: " & _Nombre_Proveedor
                        Return False
                    End If


                    If _Mto_Total_Str.Length > 11 Then
                        StrError = StrError & "El monto de la fila: " & i + 4 & " no puede exceder los 11 caracteres." & vbCrLf
                    Else
                        'Linea = Linea & WorksheetFunction.Rept("0", 11 - Len(Ht.Cells(i + 4, 7).Value)) & Ht.Cells(i + 4, 7).Value & "00"
                        _Linea = _Linea & Rellenar(_Mto_Total_Str, 11, "0", False) & "00"
                    End If

                    Dim _Descripcion_Del_Pago = "PAGO PROVEEDORES"

                    If _Descripcion_Del_Pago.Length > 119 Then
                        StrError = StrError & "La descripcion del pago de la fila: " & i + 4 & " no puede exceder los 119 caracteres." & vbCrLf
                        Return False
                    Else
                        'Linea = Linea & Ht.Cells(i + 4, 8).Value & WorksheetFunction.Rept(" ", 119 - Len(Ht.Cells(i + 4, 8).Value))
                        _Linea = _Linea & Rellenar(_Descripcion_Del_Pago, 119, " ", True) ' Ht.Cells(i + 4, 8).Value & WorksheetFunction.Rept(" ", 119 - Len(Ht.Cells(i + 4, 8).Value))
                    End If

                    Dim _Email As String = _Row_Proveedor.Item("EMAILCOMER").ToString.Trim
                    Dim _NroEmail As String

                    If _Email <> "" Then
                        _NumeroMensaje = _NumeroMensaje + 1
                        _NroEmail = Rellenar(_NumeroMensaje, 4, "0", False)
                        _Linea = _Linea & _NroEmail  ' WorksheetFunction.Rept("0", 4 - Len(NumeroMensaje)) & NumeroMensaje
                    Else
                        _Linea = _Linea & Rellenar(_NumeroMensaje, 4, "0", False) & "0"
                    End If

                    '  Linea = Linea & WorksheetFunction.Rept("0", 4 - Len(NumeroMensaje)) & NumeroMensaje
                    _Linea = _Linea & _ValeVista & "   " & "          " & " " & "000000" & "S" & StrDup(45, " ") 'WorksheetFunction.Rept(" ", 45)
                    '    MsgBox Linea

                    _Archivo.WriteLine(_Linea.ToString)

                    If Not String.IsNullOrEmpty(_Email) Then

                        Dim _LineaMensaje As String

                        'LineaMensaje = "03" & WorksheetFunction.Rept("0", 9 - Len(Ht.Cells(2, 1).Value)) & Ht.Cells(2, 1).Value & Ht.Cells(2, 2).Value
                        _LineaMensaje = "03" & _RutCompleto '& _CC_Str & "00001"

                        If _CC_Str.Length <= 3 Then
                            _LineaMensaje = _LineaMensaje & _CC_Str & "  " & "00001"
                        End If

                        'LineaMensaje = LineaMensaje & WorksheetFunction.Rept("0", 4 - Len(NumeroMensaje)) & NumeroMensaje & "EMA"
                        _LineaMensaje = _LineaMensaje & _NroEmail & "EMA"

                        If _Email.Length > 80 Then
                            StrError = "El email beneficiario de la fila: " & i + 4 & " no puede exceder los 80 caracteres." & vbCrLf &
                                       "Proveedor: " & _Nombre_Proveedor
                            Return False
                        Else
                            'LineaMensaje = LineaMensaje & Ht.Cells(i + 4, 9).Value & WorksheetFunction.Rept(" ", 80 - Len(Ht.Cells(i + 4, 9).Value))
                            _LineaMensaje = _LineaMensaje & Rellenar(_Email, 4, " ", True)
                        End If

                        'LineaMensaje = WorksheetFunction.Rept(" ", 16)
                        'LineaMensaje = LineaMensaje & Ht.Cells(i + 4, 8).Value & WorksheetFunction.Rept(" ", 250 - Len(Ht.Cells(i + 4, 8).Value))
                        'LineaMensaje = LineaMensaje & "  " & "000" & WorksheetFunction.Rept(" ", 20)

                        '_LineaMensaje = _LineaMensaje & StrDup(16 + 50, " ") 'WorksheetFunction.Rept(" ", 16)
                        _LineaMensaje = _LineaMensaje & StrDup(96 - _Email.Length, " ")

                        _LineaMensaje = _LineaMensaje & _Descripcion_Del_Pago & StrDup(250 - _Descripcion_Del_Pago.Length, " ")
                        _LineaMensaje = _LineaMensaje & "  " & "000" & StrDup(20, " ")

                        _Archivo.WriteLine(_LineaMensaje.ToString)

                    End If

                    'CantidadRegistros = CantidadRegistros + 1
                    'MontoTotal = MontoTotal + CCur(Ht.Cells(i + 4, 7).Value)

                End If

            Next

        End Using

        'Ht.Cells(2, 9).Value = CantidadRegistros
        'Ht.Cells(2, 10).Value = MontoTotal

        'tx.Close

        'If MontoTotal <> Ht.Cells(2, 5).Value Then
        '    strError = strError & "Monto total de pago y la suma de montos de la nomina no son iguales" & vbCrLf
        'End If

        'If Len(strError) > 0 Then

        '    MsgBox(strError)
        '    If Len(strAdvertencia) > 0 Then
        '        MsgBox(strAdvertencia)
        '    End If
        'Else

        '    If Len(strAdvertencia) > 0 Then
        '        MsgBox(strAdvertencia)
        '    End If

        '    MsgBox("- Archivo generado sin errores en la ruta = " & ActiveWorkbook.Path & vbCrLf & "- La cantidad de registros es = " & CantidadRegistros & vbCrLf & "- La suma de montos de la nomina es = " & MontoTotal)
        'End If

        'Set obj = Nothing

        'MsgBox "El txt se ha generado con exito..."
        Nombre_Archivo = Replace(Nombre_Archivo.ToString.ToUpper, ".TXT", "")
        Nombre_Archivo += ".txt"

        Dim _pFileName = Directorio_Destino & "\" & Nombre_Archivo
        System.IO.File.Copy(_Archivo_TXT, _pFileName, True)
        File.Delete(_Archivo_TXT)

        Return True

    End Function

    Function Fx_Existe_Banco(_CodBanco As String) As Boolean

        ' Bancos de Chile *******************************


        Select Case _CodBanco
            Case "001", "009", "012", "014", "016", "027", "028", "031", "037", "039", "045", "049", "051", "053", "054", "055", "504", "507", "672"
                Return True
            Case Else
                Return False
        End Select

        'Cód. NOMBRE BANCO

        '001 BANCO DE CHILE /EDWARDS
        '009 BANCO INTERNACIONAL
        '012 BANCO ESTADO
        '014 BANCO SCOTIABANK
        '016 BANCO DE CREDITO E INVERSIONES
        '027 BANCO CORPBANCA
        '028 BANCO BICE
        '031 BANCO HSBC
        '037 BANCO SANTANDER SANTIAGO
        '039 BANCO ITAU
        '045 THE BANK OF TOKIO
        '049 BANCO SECURITY
        '051 BANCO FALABELLA
        '053 BANCO RIPLEY
        '054 BANCO RABOBANK
        '055 BANCO CONSORCIO
        '504 BANCO BBVA
        '507 BANCO DEL DESARROLLO
        '672 BANCO COOPEUCH


    End Function

    'Function Fx_Crear_TXT(_Nombre_Archivo As String,
    '                      _Directorio_Destino As String,
    '                      _Separador As String,
    '                      Optional ByRef _Error As String = "") As String

    '    'Const DELIMITADOR As String = ";"

    '    Dim columna = 1
    '    Dim Contador = 0
    '    Dim _Fila = 0

    '    ' ruta del fichero de texto  
    '    Dim _Archivo_TXT As String = Path.GetTempFileName()

    '    Try

    '        'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas  
    '        Using _Archivo As StreamWriter = New StreamWriter(_Archivo_TXT)

    '            ' variable para almacenar la línea actual del dataview  
    '            Dim _Linea As String = String.Empty

    '            ' Recorrer las filas del dataGridView  
    '            For Each _Row As DataRow In _Tbl_Excel.Rows
    '                ' vaciar la línea  
    '                _Linea = String.Empty
    '                System.Windows.Forms.Application.DoEvents()
    '                ' Recorrer la cantidad de columnas que contiene el dataGridView  

    '                For Each dc In _Tbl_Excel.Columns

    '                    Dim _Valor = _Row(dc.ColumnName).ToString

    '                    Dim ty As Type = dc.DataType
    '                    Dim TipoDeDato As String = ty.Name.ToString

    '                    If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then
    '                        Dim _Valor_

    '                        Try
    '                            _Valor_ = De_Num_a_Tx_01(_Valor, False, 2)
    '                            _Valor = _Valor_
    '                        Catch ex As Exception
    '                            _Valor = 0
    '                        End Try

    '                    ElseIf TipoDeDato = "String" Then

    '                        _Valor = _Valor ' Replace(_Valor, ",", ".")

    '                    ElseIf TipoDeDato = "DateTime" Then

    '                        Dim _Fecha As Date = NuloPorNro(_Row(dc.ColumnName), "01-01-1900")

    '                        _Valor = _Fecha
    '                        _Valor = Replace(_Valor, "/", "-")

    '                    End If

    '                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador  
    '                    _Linea = _Linea & _Valor & _Separador
    '                    columna += 1

    '                Next

    '                ' Escribir una línea con el método WriteLine  
    '                _Archivo.WriteLine(_Linea.ToString)

    '                Contador += 1

    '                _Fila += 1
    '            Next

    '        End Using

    '        ' Abrir con Process.Start el archivo de texto  
    '        'Process.Start(_Archivo_CSV)

    '        _Nombre_Archivo += ".txt"

    '        Dim _pFileName = _Directorio_Destino & "\" & _Nombre_Archivo
    '        System.IO.File.Copy(_Archivo_TXT, _pFileName, True)
    '        File.Delete(_Archivo_TXT)

    '        Return _pFileName
    '        'error  
    '    Catch ex As Exception
    '        _Error = ex.Message & vbCrLf & "Fila: " & _Fila
    '        Return ""
    '    Finally

    '    End Try

    'End Function

End Class
