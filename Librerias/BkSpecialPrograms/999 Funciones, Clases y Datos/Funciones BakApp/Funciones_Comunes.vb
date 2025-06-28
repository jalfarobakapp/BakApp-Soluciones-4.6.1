Imports System.Reflection.Assembly
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports System.Security.Cryptography
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Text
Imports System.Net.Sockets



Public Module Funciones_Comunes

    Public Function De_Num_a_Tx_01(lNumero As Double,
                               Optional bEntero As Boolean = False,
                               Optional nDecimales As Integer = 2) As String
        '-------------------------------------------------§§§----'
        ' FUNCION PARA CONVERTIR UN NUMERO EN TEXTO
        '-------------------------------------------------§§§----'
        '
        On Error GoTo fin
        '
        Dim sNumero As String
        Dim nLong1 As Integer
        Dim nCont1 As Integer
        '
        If bEntero = True Then
            sNumero = CStr(Format(lNumero, "########0"))
            ''
        Else
            Select Case nDecimales
                Case -1 : sNumero = CStr(Format(lNumero, "########0.#########"))
                Case 1 : sNumero = CStr(Format(lNumero, "########0.#"))
                Case 2 : sNumero = CStr(Format(lNumero, "########0.0#"))
                Case 3 : sNumero = CStr(Format(lNumero, "########0.00#"))
                Case 4 : sNumero = CStr(Format(lNumero, "########0.000#"))
                Case 5 : sNumero = CStr(Format(lNumero, "########0.0000#"))
                Case 6 : sNumero = CStr(Format(lNumero, "########0.00000#"))
                Case 7 : sNumero = CStr(Format(lNumero, "########0.000000#"))
                Case 8 : sNumero = CStr(Format(lNumero, "########0.0000000#"))
                Case 9 : sNumero = CStr(Format(lNumero, "########0.00000000#"))
                Case 9 : sNumero = CStr(Format(lNumero, "########0.00000000#"))
                Case 10 : sNumero = CStr(Format(lNumero, "########0.000000000#"))
                Case 11 : sNumero = CStr(Format(lNumero, "########0.0000000000#"))
                Case 12 : sNumero = CStr(Format(lNumero, "########0.00000000000#"))
                Case Else : sNumero = CStr(Format(lNumero, "########0.00#"))
            End Select
            ''
        End If
        '
        nLong1 = Len(sNumero)
        '
        For nCont1 = 1 To nLong1
            If Mid$(sNumero, nCont1, 1) = "," Then Mid(sNumero, nCont1, 1) = "."
            ''
        Next nCont1
        '
        If bEntero = True Then
            De_Num_a_Tx_01 = sNumero
            ''
        ElseIf InStr(sNumero, ".") > 0 Then
            If (Len(sNumero) = InStr(sNumero, ".")) And (nDecimales = -1) Then
                De_Num_a_Tx_01 = Mid$(sNumero, 1, InStr(sNumero, ".") - 1)
                ''
            Else
                De_Num_a_Tx_01 = sNumero
                ''
            End If
            ''
        Else
            De_Num_a_Tx_01 = sNumero & ".0"
            ''
        End If
        '
        Exit Function
        '
fin:
        De_Num_a_Tx_01 = "###.###"
        ''
    End Function

    '‘———————————————— -§§§— - ’
    '‘ FUNCION PARA CONVERTIR UN TEXTO EN NUMERO DECIMAL
    '‘———————————————— -§§§— - ’

    Public Function De_Txt_a_Num_01(sTexto As String,
                                       Optional nDecimales As Integer = 3,
                                       Optional sP_Formato_Decimal As String = "") As Double
        '-------------------------------------------------§§§----'
        ' FUNCION PARA CONVERTIR UN TEXTO EN NUMERO DECIMAL
        '-------------------------------------------------§§§----'
        '
        Dim bCte2 As Boolean
        '
        Dim nContador1 As Integer
        Dim nContador2 As Integer
        Dim nLong_Total As Integer
        Dim nPos_Punto As Integer
        Dim nCte1 As Integer
        Dim nDecimal As Integer
        '
        Dim lNumeruco As Double
        '
        Dim sNumero As String
        Dim sL_Aux_01 As String
        '
        Dim sL_Array_Pto_01() As String
        Dim sL_Array_Coma_01() As String
        '
        On Error GoTo Error_Numero
        '
        '-------------------------------------------------§§§----'
        Select Case sP_Formato_Decimal
            Case "."    ' USAMOS "." COMO SEPARADOR DE DECIMALES
                ' Y LA "," LA ELIMINAMOS
                sL_Array_Pto_01 = Split(sTexto, ".")
                sL_Array_Coma_01 = Split(sTexto, ",")
                '
                sL_Aux_01 = ""
                For nContador1 = LBound(sL_Array_Coma_01) To UBound(sL_Array_Coma_01)
                    sL_Aux_01 = sL_Aux_01 & sL_Array_Coma_01(nContador1)
                    ''
                Next nContador1
                '
                sTexto = sL_Aux_01
                ''
            Case ","    ' USAMOS "," COMO SEPARADOR DE DECIMALES
                ' Y EL "." LE ELIMINAMOS
                sL_Array_Pto_01 = Split(sTexto, ".")
                sL_Array_Coma_01 = Split(sTexto, ",")
                '
                sL_Aux_01 = ""
                For nContador1 = LBound(sL_Array_Pto_01) To UBound(sL_Array_Pto_01)
                    sL_Aux_01 = sL_Aux_01 & sL_Array_Pto_01(nContador1)
                    ''
                Next nContador1
                '
                sTexto = sL_Aux_01
                ''
        End Select
        '-------------------------------------------------§§§----'
        '
        lNumeruco = 0
        '
        If nDecimales >= 0 Then
            nDecimal = nDecimales
            ''
        Else
            nDecimal = 3
            ''
        End If
        '
        sTexto = Trim(sTexto)
        '
        If InStr(1, sTexto, "-") > 0 Then
            'Es un numero negativo
            bCte2 = True
            sTexto = Mid$(sTexto, 2)
            ''
        ElseIf InStr(1, sTexto, "+") > 0 Then
            'Es un numero positivo (con signo)
            bCte2 = False
            sTexto = Mid$(sTexto, 2)
            ''
        Else
            'Es un numero positivo
            bCte2 = False
            ''
        End If
        '
        nLong_Total = Len(sTexto)
        '
        For nContador1 = 1 To nLong_Total
            If Mid(sTexto, nContador1, 1) = "," Then Mid(sTexto, nContador1, 1) = "."
            ''
        Next nContador1
        '
        If InStr(1, sTexto, ".") <= 0 Then sTexto = sTexto & ".0"
        '
        nPos_Punto = InStr(1, sTexto, ".")
        '
        nContador2 = 0
        For nContador1 = 1 To nLong_Total
            If Mid$(sTexto, nContador1, 1) <> "." Then
                'No estamos en el caracte "."
                If nContador1 < nPos_Punto And nPos_Punto <> 0 Then
                    nCte1 = 1
                    ''
                Else
                    nContador2 = nContador2 + 1
                    nCte1 = 0
                    ''
                End If
                '
                sNumero = Mid$(sTexto, nContador1, 1)
                '
                If nContador2 > nDecimal Then
                    If sNumero > 5 Then lNumeruco = lNumeruco + (CSng(1) * (10 ^ (nPos_Punto - nContador1 - nCte1 + 1)))
                    nContador1 = nLong_Total
                    ''
                Else
                    lNumeruco = lNumeruco + (CSng(sNumero) * (10 ^ (nPos_Punto - nContador1 - nCte1)))
                    ''
                End If
                ''
            End If
            ''
        Next nContador1
        '
        If bCte2 = True Then
            De_Txt_a_Num_01 = (-1) * lNumeruco
            ''
        Else
            De_Txt_a_Num_01 = (1) * lNumeruco
            ''
        End If
        '
        If (nDecimales >= 0) Then De_Txt_a_Num_01 = Math.Round(De_Txt_a_Num_01, nDecimales)
        '
        Exit Function
        '
Error_Numero:
        '
        '-------------------------------------------------§§§----'
        ' ERROR DE NUMERO
        '-------------------------------------------------§§§----'
        '
        De_Txt_a_Num_01 = -1.75E+308
        ''
    End Function

    Function Encripta_md5(TextoAEncriptar As String) As String
        Dim vlo_MD5 As New MD5CryptoServiceProvider
        Dim vlby_Byte(), vlby_Hash() As Byte
        Dim vls_TextoEncriptado As String = ""

        'Convierte texto a encriptar a Bytes
        vlby_Byte = System.Text.Encoding.UTF8.GetBytes(TextoAEncriptar)

        'Aplicación del algoritmo hash
        vlby_Hash = vlo_MD5.ComputeHash(vlby_Byte)

        'Convierte la matriz de byte en una cadena
        For Each vlby_Aux As Byte In vlby_Hash
            vls_TextoEncriptado += vlby_Aux.ToString("x2")
        Next

        'Retorno de función
        Return vls_TextoEncriptado
    End Function

#Region " Funciones para saber el path y nombre del ejecutable (y esta DLL) "
    '
    '<summary>
    ' Devuelve el path de la aplicación.
    ' Al usarse desde una librería (DLL), hay que usar GetCallingAssembly
    ' para que devuelva el path del ejecutable (o librería) que llama a esta función.
    ' Si no se usa GetCallingAssembly, devolvería el path de la librería.
    '</summary>
    '<param name="backSlash">Opcional. True si debe devolver el path terminado en \</param>
    '<returns>
    ' El path de la aplicación con o sin backslash, según el valor del parámetro.
    '</returns>
    Public Function AppPath(Optional backSlash As Boolean = False) As String

        Dim s As String = IO.Path.GetDirectoryName(
           GetExecutingAssembly.GetCallingAssembly.Location)

        If backSlash Then
            s &= "\"
        End If

        ' si hay que añadirle el backslash
        Return s

    End Function
    '
    '<summary>
    ' Devuelve el nombre del ejecutable.
    ' Al usarse desde una librería (DLL), hay que usar GetCallingAssembly
    ' para que devuelva el nombre del ejecutable (o librería) que llama a esta función.
    ' Si no se usa GetCallingAssembly, devolvería el nombre de esta librería.
    '</summary>
    '<param name="fullPath">Opcional. True si debe devolver nombre completo.</param>
    '<returns>El nombre del ejecutable, con o sin el path completo, según el valor del parámetro.
    '</returns>
    Public Function AppExeName(
                Optional fullPath As Boolean = False
                ) As String
        Dim s As String = GetExecutingAssembly.GetCallingAssembly.Location
        Dim fi As New IO.FileInfo(s)
        If fullPath Then
            s = fi.FullName
        Else
            s = fi.Name
        End If
        '
        Return s
    End Function
    '
    '<summary>
    ' Devuelve el path de esta librería.
    '</summary>
    '<param name="backSlash">Opcional. True si debe devolver el path terminado en \
    '</param>
    '<returns>
    ' El path de esta librería, con o sin backslash, según el valor del parámetro.
    '</returns>
    Public Function DLLPath(
                Optional backSlash As Boolean = False
                ) As String
        Dim s As String = IO.Path.GetDirectoryName(GetExecutingAssembly.Location)
        ' si hay que añadirle el backslash
        If backSlash Then
            s &= "\"
        End If
        Return s
    End Function
    '
    '<summary>
    ' Devuelve el nombre de esta librería.
    '</summary>
    '<param name="fullPath">Opcional. True si debe devolver nombre completo.</param>
    '<returns>El nombre de esta librería, con o sin el path completo, según el valor del parámetro.
    '</returns>
    Public Function DLLName(
                Optional fullPath As Boolean = False
                ) As String
        Dim s As String = GetExecutingAssembly.Location
        Dim fi As New IO.FileInfo(s)
        If fullPath Then
            s = fi.FullName
        Else
            s = fi.Name
        End If
        '
        Return s
    End Function
    '
#End Region

    Public Function NuloPorNro(Of T)(value As T, defaultValue As T) As T

        Dim obj1 As Object = value
        Dim obj2 As Object = defaultValue

        Try
            If ((obj1 Is DBNull.Value) OrElse (obj1 Is Nothing)) Then
                ' Es NULL; devolvemos el valor por defecto siempre
                ' y cuando éste tampoco sea NULL.
                '
                If (Not obj2 Is DBNull.Value) Then
                    Return defaultValue
                Else
                    Return Nothing
                End If
            Else
                ' No es NULL ni Nothing; devolvemos el valor pasado.
                '
                Return value
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function numero_(Num As String, d As Integer) As String
        Dim i As Integer
        Dim nro As String
        nro = Len(RTrim$(Num))

        For i = nro To d - 1
            Num = "0" & Num
        Next

        Return RTrim$(Num)
    End Function

    Function Generar_Filtro_IN(Tabla As DataTable,
                               _CodChk As String,
                               _CodCampo As String,
                               _EsNumero As Boolean,
                               _TieneChk As Boolean,
                               Optional _Separador As String = "''",
                               Optional _Entre_Parentesis As Boolean = True)

        Dim Cadena As String = String.Empty
        Dim Vcampo As String = String.Empty
        Dim Separador As String = ""

        If _EsNumero Then
            Separador = "#"
        Else
            Separador = "@"
        End If

        If (Tabla Is Nothing) Then Return "()"

        Dim i = 0

        For Each Rd As DataRow In Tabla.Rows

            Dim Estado As DataRowState = Rd.RowState

            If Estado <> DataRowState.Deleted Then

                'Dim _Cadena As String = Rd.Item(_CodCampo).ToString().Trim
                Vcampo = Rd.Item(_CodCampo).ToString() '.Trim

                If String.IsNullOrEmpty(Vcampo) Then
                    Vcampo = "%%"
                End If

                Dim _Encadenar As Boolean = False

                If _TieneChk Then
                    If Rd.Item(_CodChk) Then
                        _Encadenar = True
                    End If
                Else
                    If Not String.IsNullOrEmpty(Trim(Vcampo)) Then _Encadenar = True
                End If

                If Vcampo.Contains(Separador) Then
                    Vcampo = Replace(Vcampo, Separador, "|")
                End If

                If _Encadenar Then
                    Cadena = Cadena & Separador & Vcampo & Separador '& Coma
                End If
            End If
            i += 1
        Next

        If _EsNumero Then
            Cadena = Replace(Cadena, "##", ",")
            Cadena = Replace(Cadena, "#", "")
        Else
            Cadena = Replace(Cadena, "@@", "@,@")
            Cadena = Replace(Cadena, "@", _Separador)
            Cadena = Replace(Cadena, "%%", "")
        End If

        Cadena = Replace(Cadena, "|", Separador)

        If _Entre_Parentesis Then Cadena = "(" & Cadena & ")"

        Return Cadena

    End Function

    Function Generar_Filtro_IN_Email(_Tabla As DataTable,
                                     _CodCampo As String)

        Dim _Cadena As String = String.Empty

        If (_Tabla Is Nothing) Then Return ""

        Dim i = 0

        For Each _Rd As DataRow In _Tabla.Rows

            Dim Estado As DataRowState = _Rd.RowState

            If Estado <> DataRowState.Deleted Then

                Dim _Campo As String = _Rd.Item(_CodCampo).ToString()
                Dim _Encadenar As Boolean = False

                If Not String.IsNullOrEmpty(Trim(_Campo)) Then _Encadenar = True

                If _Encadenar Then
                    If i < 1 Then '_Tabla.Rows.Count Then
                        _Cadena += Trim(_Rd.Item(_CodCampo).ToString)
                    Else
                        _Cadena += ";" & Trim(_Rd.Item(_CodCampo).ToString)
                    End If
                End If

            End If

            i += 1

        Next

        Return _Cadena

    End Function

    Function Generar_Filtro_IN_Lista(_Lista As Object,
                                     _EsNumero As Boolean,
                                     _Separador As String)

        Dim Cadena As String = String.Empty
        Dim Vcampo As String = String.Empty
        Dim Separador As String = ""

        If _EsNumero Then
            Separador = "#"
        Else
            Separador = "@"
        End If

        If (_Lista Is Nothing) Then
            Return "()"
        End If

        Dim i = 0

        For Each _Fila In _Lista

            Vcampo = _Fila.Codigo

            If String.IsNullOrEmpty(Vcampo) Then
                Vcampo = "%%"
            End If

            Dim _Encadenar As Boolean = False

            If Not String.IsNullOrEmpty(Trim(Vcampo)) Then _Encadenar = True

            If Vcampo.Contains(Separador) Then
                Vcampo = Replace(Vcampo, Separador, "|")
            End If

            If _Encadenar Then
                Cadena = Cadena & Separador & Vcampo & Separador '& Coma
            End If

            i += 1
        Next

        If _EsNumero Then
            Cadena = Replace(Cadena, "##", ",")
            Cadena = Replace(Cadena, "#", "")
        Else
            Cadena = Replace(Cadena, "@@", "@,@")
            Cadena = Replace(Cadena, "@", _Separador)
            Cadena = Replace(Cadena, "%%", "")
        End If

        Cadena = Replace(Cadena, "|", Separador)

        Cadena = "(" & Cadena & ")"

        Return Cadena

    End Function

    Function Generar_Filtro_IN_Lista2(_Lista As List(Of String),
                                     _EsNumero As Boolean,
                                     _Separador As String)

        Dim Cadena As String = String.Empty
        Dim Vcampo As String = String.Empty
        Dim Separador As String = ""

        If _EsNumero Then
            Separador = "#"
        Else
            Separador = "@"
        End If

        If (_Lista Is Nothing) Then
            Return "()"
        End If

        Dim i = 0

        For Each _Fila In _Lista

            Vcampo = _Fila

            If String.IsNullOrEmpty(Vcampo) Then
                Vcampo = "%%"
            End If

            Dim _Encadenar As Boolean = False

            If Not String.IsNullOrEmpty(Trim(Vcampo)) Then _Encadenar = True

            If Vcampo.Contains(Separador) Then
                Vcampo = Replace(Vcampo, Separador, "|")
            End If

            If _Encadenar Then
                Cadena = Cadena & Separador & Vcampo & Separador '& Coma
            End If

            i += 1
        Next

        If _EsNumero Then
            Cadena = Replace(Cadena, "##", ",")
            Cadena = Replace(Cadena, "#", "")
        Else
            Cadena = Replace(Cadena, "@@", "@,@")
            Cadena = Replace(Cadena, "@", _Separador)
            Cadena = Replace(Cadena, "%%", "")
        End If

        Cadena = Replace(Cadena, "|", Separador)

        Cadena = "(" & Cadena & ")"

        Return Cadena

    End Function

    Public Function Primerdiadelmes(fecha As Date) As Date
        Dim rtn As New Date
        rtn = fecha 'Date.Now
        rtn = rtn.AddDays(-rtn.Day + 1)
        Return rtn
    End Function

    Public Function ultimodiadelmes(fecha As Date) As Date
        Dim rtn As New Date
        rtn = fecha.Date ' fecha 'Date.Now
        rtn = rtn.AddDays(-rtn.Day + 1).AddMonths(1).AddDays(-1)
        Return rtn
    End Function

    Function es_numero(numero As String) As Boolean

        Dim w As Integer
        Dim lineax As String

        w = 0

        Select Case RTrim$(Mid(numero, 1, 1)) & RTrim$(Mid(numero, 2, 1))
            Case "00" : w = 1
            Case "01" : w = 1
            Case "02" : w = 1
            Case "03" : w = 1
            Case "04" : w = 1
            Case "05" : w = 1
            Case "06" : w = 1
            Case "07" : w = 1
            Case "08" : w = 1
            Case "09" : w = 1
        End Select

        If w = 1 Then
            es_numero = False
            Exit Function
        End If

        For w = 1 To Len(numero)
            lineax = RTrim$(Mid(numero, w, 1))

            If lineax = "" Then
                es_numero = False
                Exit Function
            End If

            If InStr("-.,1234567890", RTrim$(lineax)) = 0 Then
                es_numero = False
                Exit Function
            Else
                es_numero = True
            End If
        Next


    End Function

    Function SoloNumeros(Keyascii As Short,
                        Optional _Solo_Nros As Boolean = True) As Short


        Dim _Sd = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator

        Dim T As String = Chr(Keyascii)
        ' Dim dd '= InStr("1234567890,.-", T)

        If _Solo_Nros Then
            'dd = InStr("1234567890", T)
            If InStr("1234567890,.", Chr(Keyascii)) = 0 Then
                SoloNumeros = 0
            Else
                SoloNumeros = Keyascii
            End If
        Else
            ' dd = InStr("1234567890,.-", T)
            If InStr("1234567890,.-", Chr(Keyascii)) = 0 Then
                SoloNumeros = 0
            Else
                SoloNumeros = Keyascii
            End If
        End If

        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function


    Function SoloNumerosSinPuntosNiComas(Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumerosSinPuntosNiComas = 0
        Else
            SoloNumerosSinPuntosNiComas = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosSinPuntosNiComas = Keyascii
            Case 13
                SoloNumerosSinPuntosNiComas = Keyascii
        End Select
    End Function

    Function SoloLetrasNumeros(Keyascii As Short) As Short
        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890,.-", Chr(Keyascii)) = 0 Then
            SoloLetrasNumeros = 0
        Else
            SoloLetrasNumeros = Keyascii
        End If
    End Function

    'Function Fx_Es_Funcion_Numerica(Keyascii As Short) As Boolean
    '    If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890,.-", Chr(Keyascii)) = 0 Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function

    Function llenar_combobox(listado() As String, Combo As ComboBox)
        Try

            Combo.Items.Clear()
            If Not listado Is Nothing Then
                Combo.Items.AddRange(listado)
            End If
        Catch ex As Exception

        End Try

    End Function

    Function CreateXMLFile(ds As DataSet,
                           fileNameXML As String,
                           fileNameStyleSheetXSL As String,
                           overWrite As Boolean) As Boolean

        '*******************************************************************
        ' Nombre: CreateXMLFile
        ' por Enrique Martínez Montejo - 24/06/2006
        '
        ' Versión: 1.0     (Compatible con Framework 1.0, 1.1 y 2.0)    
        '
        ' Finalidad: Crear un archivo XML con el contenido existente
        '            en un objeto DataSet.
        '
        ' Entradas:
        '
        '     ds: DataSet. Un objeto DataSet válido.
        '
        '     fileNameXML:
        '         String. Ruta y nombre del archivo XML de salida.
        '
        '    fileNameStyleSheetXSL:
        '         String. Ruta y nombre, si procede, de la hoja de
        '         de estilo del lenguaje extensible a la cual se
        '         vinculará el archivo XML.
        '         Si no desea especificar ninguna hoja de estilo, pase
        '         al procedimiento una cadena de longitud cero ("").
        '
        '     overWrite:
        '         Boolean. De ser False, y existir el archivo XML,
        '         se pedirá confirmación para sobrescribir el archivo.
        '
        '*******************************************************************

        ' Verificamos los parámetros pasados al procedimiento.
        '
        If ((ds Is Nothing) OrElse (fileNameXML = "")) Then
            MessageBox.Show("Parámetros incorrectos.",
                            "Crear XML",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Si el archivo existe, pedimos confirmación para sobrescribirlo,
        ' siempre y cuando no se haya especificado explícitamente.
        '
        If ((overWrite = False) AndAlso (System.IO.File.Exists(fileNameXML) = True)) Then
            If MessageBox.Show("Ya existe un archivo con el mismo nombre " &
                               "en la ruta indicada. " & vbCrLf & vbCrLf &
                               "¿Desea sobrescribirlo?",
                               "Crear XML", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        ' A fin de controlar la posible excepción que se puede
        ' dar al no poder obtener acceso al archivo.
        '
        Try
            ' Creamos un objeto FileStream para escritura.
            '
            Dim fs As New System.IO.FileStream(fileNameXML, System.IO.FileMode.Create)

            ' Creamos un objeto XmlTextWriter para el
            ' objeto FileStream.
            '
            Dim xtw As New System.Xml.XmlTextWriter(fs, System.Text.Encoding.Unicode)

            ' Procesamos las instrucciones, indicando la hoja de estilos,
            ' si procede, al comienzo del archivo XML.
            '
            With xtw
                .WriteProcessingInstruction("xml", "version='1.0'")
                .WriteProcessingInstruction("xml-stylesheet",
                                            "type='text/xsl' href='" &
                                            fileNameStyleSheetXSL &
                                            "'")
                ' Escribimos los datos del objeto DataSet en el archivo XML.
                '
                ds.WriteXml(xtw)

                ' Cerramos el objeto
                '
                .Close()
            End With

            MessageBox.Show("Se ha creado con éxito el archivo XML.",
                            "Crear XML",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As IO.IOException
            MessageBox.Show(ex.Message,
                            "Crear XML",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            "Crear XML",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return True

    End Function

    Function CrearArchivoTxt(Ruta As String,
                             NombreArchivo As String,
                             Cuerpo As String,
                             Optional _Mostrar_OK As Boolean = True)
        Try

            Dim _Palo = Right(Ruta, 1)

            If _Palo <> "\" Then
                Ruta += "\"
            End If

            Dim RutaArchivo As String = Ruta & NombreArchivo

            Dim oSW As New System.IO.StreamWriter(RutaArchivo)

            oSW.WriteLine(Cuerpo)
            oSW.Close()

            If _Mostrar_OK Then
                MessageBoxEx.Show("Archivo guardado correctamente en el siguiente directorio:" & vbCrLf &
                                  RutaArchivo, "Crear archivo txt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'aqui creo el archivo oculto,,, si no se pone este instrucion no pasa nada .. solo es para 
            'asignarles caracteristicas a los archivos 
            'quitalo como comentario y calalo
            'SetAttr(RutaArchivo, vbHidden)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Public Function _Global_Fx_Cambio_en_la_Grilla(_Tbl_Grilla As DataTable,
                                                   Optional _Rev_Insertas As Boolean = True,
                                                   Optional _Rev_Eliminadas As Boolean = True,
                                                   Optional _Rev_Modificada As Boolean = True) As Boolean

        Dim _Modificado As Boolean

        For Each _Fila As DataRow In _Tbl_Grilla.Rows
            Select Case _Fila.RowState
                Case DataRowState.Added
                    If _Rev_Insertas Then _Modificado = True
                Case DataRowState.Deleted
                    If _Rev_Eliminadas Then _Modificado = True
                Case DataRowState.Detached
                    _Modificado = True
                Case DataRowState.Modified
                    If _Rev_Modificada Then _Modificado = True
            End Select

            If _Modificado Then Exit For
        Next

        Return _Modificado

    End Function

    Public Sub Sb_AddToLog(_Accion As String,
                           _Descripcion As String,
                           _TxtLog As Object,
                           Optional _Incluir_FechaHora As Boolean = True,
                           Optional _Incluir_Parentesis As Boolean = True)

        Dim _P1 = String.Empty
        Dim _P2 = String.Empty

        If _Incluir_Parentesis Then
            _P1 = "("
            _P2 = ")"
        End If

        If _Incluir_FechaHora Then
            _TxtLog.Text += DateTime.Now.ToString() & " - " & _Accion & " " & _P1 & _Descripcion & _P2 & vbCrLf
        Else
            _TxtLog.Text += _Accion & " " & _P1 & _Descripcion & _P2 & vbCrLf
        End If

        _TxtLog.Select(_TxtLog.Text.Length - 1, 0)
        _TxtLog.ScrollToCaret()

    End Sub

    Function Generar_Filtro_IN_Arreglo(Arreglo() As String,
                                       EsNumero As Boolean)

        Dim Cadena As String = String.Empty
        Dim Separador As String = ""

        If EsNumero Then
            Separador = "#"
        Else
            Separador = "@"
        End If

        Dim _ContieneSeparador As Boolean

        Dim i = 0
        For Each Valor As String In Arreglo
            If Not String.IsNullOrEmpty(Valor) Then
                If Valor.Contains(Separador) Then
                    Valor = Valor.Replace(Separador, ";")
                    _ContieneSeparador = True
                End If
                Cadena = Cadena & Separador & Trim(Valor) & Separador '& Coma
                i += 1
            End If
        Next

        If EsNumero Then
            Cadena = Replace(Cadena, "##", ",")
            Cadena = Replace(Cadena, "#", "")
        Else
            Cadena = Replace(Cadena, "@@", "@,@")
            Cadena = Replace(Cadena, "@", "'")
        End If

        If _ContieneSeparador Then
            Cadena = Replace(Cadena, ";", Separador)
        End If

        Cadena = "(" & Cadena & ")"

        Return Cadena

    End Function

    Function Generar_Filtro_IN_Arreglo(Arreglo As List(Of String),
                                       EsNumero As Boolean)

        Dim Cadena As String = String.Empty
        Dim Separador As String = ""

        If EsNumero Then
            Separador = "#"
        Else
            Separador = "@"
        End If

        'If (Tabla Is Nothing) Then Return "()"

        Dim i = 0
        For Each Valor As String In Arreglo
            If Not String.IsNullOrEmpty(Valor) Then
                Cadena = Cadena & Separador & Trim(Valor) & Separador '& Coma
                i += 1
            End If
        Next

        If EsNumero Then
            Cadena = Replace(Cadena, "##", ",")
            Cadena = Replace(Cadena, "#", "")
        Else
            Cadena = Replace(Cadena, "@@", "@,@")
            Cadena = Replace(Cadena, "@", "'")
        End If

        Cadena = "(" & Cadena & ")"

        Return Cadena

    End Function

    Sub OcultarEncabezadoGrilla(Grilla As DataGridView,
                                Optional _Desactivar_Orden_Automatico As Boolean = False,
                                Optional _Ancho1raColumna As Integer = 15,
                                Optional _ReadOnly As Boolean = True)

        With Grilla

            'Cambiamos el color de las letras cuando el usuario haya seleccionado una fila

            '.RowsDefaultCellStyle.SelectionForeColor = Color.Black
            '.RowsDefaultCellStyle.SelectionBackColor = Color.AliceBlue

            '.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Gold
            '.DefaultCellStyle.SelectionForeColor = Color.Gold

            '.RowsDefaultCellStyle.SelectionForeColor = Color.Gold

            '.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.AliceBlue

            '.DefaultCellStyle.SelectionBackColor = Color.Blue

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = .ColumnCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 0 To NCol - 1

                Dim NomColumna = .Columns(i).Name.ToString()
                Dim TipoColumna = .Columns(i).CellType.ToString 'DataGrid.Columns(i - 1).ValueType.ToString()

                .Columns(i).Visible = False
                .Columns(i).ReadOnly = _ReadOnly

                If _Desactivar_Orden_Automatico Then
                    .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Else
                    .Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                End If

            Next

            '.RowHeadersWidth = _Ancho1raColumna

        End With

    End Sub

    Function Rellenar(Cadena As String,
                      CantCaracteres As Integer,
                      Relleno As String,
                      Optional Derecha As Boolean = True) As String

        Dim i As Integer
        Dim nro As String
        nro = Len(Cadena)

        Dim Cantidad As Integer = CantCaracteres - nro

        If Cantidad > 0 Then
            For i = 0 To Cantidad - 1
                If Derecha = True Then
                    Cadena = Cadena & Relleno
                Else
                    Cadena = Relleno & Cadena
                End If
            Next
        End If

        Return Cadena
    End Function

    Enum Enum_Relleno
        Derecha
        Izquierda
    End Enum
    Function Rellenar2(_Cadena As String,
                      _CantCaracteres As Integer,
                      _Relleno As String,
                      _Rellenar As Enum_Relleno) As String

        Dim i As Integer
        Dim nro As String
        nro = Len(_Cadena)

        Dim _Cantidad As Integer = _CantCaracteres - nro

        If _Cantidad > 0 Then
            For i = 0 To _Cantidad - 1
                If _Rellenar = Enum_Relleno.Derecha Then
                    _Cadena = _Cadena & _Relleno
                Else
                    _Cadena = _Relleno & _Cadena
                End If
            Next
        End If

        Return _Cadena

    End Function

    Function caract_combo(combo As Object,
                          Optional Padre As String = "Padre",
                          Optional Hijo As String = "Hijo")

        With combo
            '.datasourse = Nothing
            .ValueMember = Padre
            .DisplayMember = Hijo

            'If Global_Thema = Enum_Themas.Oscuro Then
            '    CType(combo, ComboBoxEx).FocusHighlightColor = Color.Black
            'End If

            .AutoCompleteSource = AutoCompleteSource.ListItems
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .DropDownStyle = ComboBoxStyle.DropDownList

        End With

    End Function

    Function Sb_Llenar_Combos(_Arreglo(,) As String, _ComboBox As Object) As DataTable

        caract_combo(_ComboBox)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))

        Dim _Filas As Integer = (_Arreglo.Length / 2) - 1

        For i = 0 To _Filas
            Dim _Padre = _Arreglo(i, 0)
            Dim _Hijo = _Arreglo(i, 1)
            If Not IsNothing(_Padre) And Not IsNothing(_Hijo) Then
                dr = dt.NewRow() : dr("Padre") = _Padre : dr("Hijo") = _Hijo : dt.Rows.Add(dr)
            End If
        Next
        rs.Tables.Add(dt)


        With _ComboBox
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Function

    Function Sb_Llenar_Combos2(_Arreglo As Object, _ComboBox As Object) As DataTable

        caract_combo(_ComboBox)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))

        Dim _Filas As Integer = _Arreglo.Length - 1

        For i = 0 To _Filas
            Dim _Padre = i '_Arreglo(i) '_Arreglo(i, 0)
            Dim _Hijo = _Arreglo(i).ToString '_Arreglo(i, 1)
            dr = dt.NewRow() : dr("Padre") = _Padre : dr("Hijo") = _Hijo : dt.Rows.Add(dr)
        Next
        rs.Tables.Add(dt)


        With _ComboBox
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Function

    Sub ShowContextMenu(cm As ButtonItem)
        Dim pt As Point = Control.MousePosition
        cm.Popup(pt)
    End Sub

    Public Function getIp() As String

        Dim valorIp As String

        'Dim host As String = Dns.GetHostName()
        'Dim ip As String = Dns.GetHostEntry(host).AddressList _
        '    .FirstOrDefault(Function(addr) addr.AddressFamily = Net.Sockets.AddressFamily.InterNetwork).ToString()
        ''Return ip

        valorIp = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) _
                    i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()

        Return valorIp

    End Function

    Function Fx_GetLocalIPAddress() As String
        Dim host As String = Dns.GetHostName()
        Dim ipAddresses = Dns.GetHostAddresses(host)

        For Each ip As IPAddress In ipAddresses
            If ip.AddressFamily = AddressFamily.InterNetwork Then
                Return ip.ToString()
            End If
        Next

        Throw New Exception("No se encontró una dirección IPv4 válida.")
    End Function

    Public Function CADENA_A_BUSCAR(cadena As String,
                             CAMPO As String,
                             Optional _And_Or As String = "And") As String

        Dim linea1, linea2 As String
        Dim CONCATENA As String = ""
        Dim w As Integer

        For w = 1 To Len(cadena)
            linea1 = UCase(RTrim$(Mid(cadena, w, 1)))
            linea2 = LCase(linea1)

            If linea1 = "" Then
                CONCATENA = CONCATENA & "%' " & _And_Or & vbCrLf & CAMPO
            Else
                CONCATENA = CONCATENA & "[" & linea1 & linea2 & "]"
            End If
        Next
        CADENA_A_BUSCAR = CONCATENA
        'MsgBox CONCATENA
    End Function

    Function Cuentadias(FechaInicio As Date,
                    FechaFin As Date,
                    Diadelasemana As FirstDayOfWeek) As Integer

        Dim n As Integer
        Dim Fechaini As Date = FechaInicio

        Do Until FechaFin < Fechaini

            If Weekday(Fechaini) = Diadelasemana Then
                n = n + 1
            End If
            Fechaini = Fechaini.AddDays(1)
        Loop
        Return n

    End Function

    Function BuscarDatoEnGrilla(TextoABuscar As String,
                                Columna As String, ByRef grid As DataGridView) As Boolean

        TextoABuscar = UCase(TextoABuscar)

        Dim encontrado As Boolean = False
        If TextoABuscar = String.Empty Then Return False
        If grid.RowCount = 0 Then Return False
        grid.ClearSelection()
        If Columna = String.Empty Then
            For Each row As DataGridViewRow In grid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Value.ToString() = TextoABuscar Then
                        row.Selected = True
                        Return True
                    End If
                Next
            Next
        Else
            Dim Descripcion As String
            For Each row As DataGridViewRow In grid.Rows
                If row.IsNewRow Then Return False

                Try
                    Descripcion = UCase(Trim(row.Cells(Columna).Value.ToString()))
                Catch ex As Exception
                    Return False
                End Try

                If BuscarTextoGrilla(Descripcion.ToString.Trim, TextoABuscar.ToString.Trim) Then
                    grid.ClearSelection()
                    grid.FirstDisplayedScrollingRowIndex = row.Index.ToString
                    grid.CurrentCell = grid.Rows(row.Index.ToString).Cells(Columna)
                    grid.Refresh()
                    row.Selected = True
                    Return True
                End If

            Next
        End If
        Return encontrado
    End Function

    Private Function BuscarTextoGrilla(Texto As String, Busqueda As String) As Boolean
        Dim i As Integer
        i = InStr(1, Texto, Busqueda)
        If i > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function VisualizarFormulario(Formulario As Object,
                                  FormularioPadre As Form,
                                  Optional VerEnShowDialong As Boolean = True,
                                  Optional EsMDI As Boolean = False
                                  )

        If EsMDI = True Then
            Formulario.MdiParent = FormularioPadre
            If Formulario Is Nothing Then
                Formulario.Show()
            ElseIf Not Formulario.Visible Then
                Formulario.Show()
            Else
                Formulario.Focus()
            End If
        Else

            If VerEnShowDialong = True Then
                If Formulario Is Nothing Then
                    Formulario.ShowDialog(FormularioPadre)
                ElseIf Not Formulario.Visible Then
                    Formulario.ShowDialog(FormularioPadre)
                Else
                    Formulario.Focus()
                End If
            Else
                If Formulario Is Nothing Then
                    Formulario.Show()
                ElseIf Not Formulario.Visible Then
                    Formulario.Show()
                Else
                    Formulario.Focus()
                End If
            End If
        End If


    End Function

    Public Sub _Configuracion_Regional_(Optional _Moneda As String = "$")

        'despues en el load del formulario inicial de la aplicacion escriben esto 

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CL")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = _Moneda
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        ' SEPARADOR DE DECIMALES MONEDA
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        ' SEPARADOR DE DECIMALES EN NUMEROS
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "."

    End Sub

    Public Sub Validar_Keypress_Nros_Grilla(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  
        'With Grilla
        'Dim Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
        'Dim Codigo = .Rows(.CurrentRow.Index).Cells("Codigo").Value
        'Dim Descripcion = .Rows(.CurrentRow.Index).Cells("Descripcion").Value
        Dim caracter As Char = e.KeyChar

        If e.KeyChar = "."c Then
            ' si se pulsa la coma se convertirá en punto
            'e.Handled = True
            SendKeys.Send(",")
            e.KeyChar = ","c
            caracter = ","
        End If

        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        'If Cabeza = "CantComprar" Then
        ' Obtener caracter  

        ' referencia a la celda  
        Dim txt As TextBox = CType(sender, TextBox)

        ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
        ' es el separador decimal, y que no contiene ya el separador  
        If (Char.IsNumber(caracter)) Or
        (caracter = ChrW(Keys.Back)) Or
        (caracter = ",") And
        (txt.Text.Contains(",") = False) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'End If
        'End With
    End Sub

    Public Function Fx_Rellena_ceros(_NroDoc As String,
                                    _NroCaracateres As Integer,
                                    Optional _Suma_uno As Boolean = False) As String

        Dim _Contador = 1
        Dim _Tot_carac = Len(_NroDoc)


        Do While _Contador < _NroCaracateres
            Dim _Pl = Microsoft.VisualBasic.Strings.Right(_NroDoc, _Contador)
            If Not IsNumeric(_Pl) Then
                Exit Do
            End If

            _Contador += 1
        Loop

        Dim _Cadena As String
        Dim _Cadena2 = Microsoft.VisualBasic.Strings.Right(_NroDoc, _Contador - 1)

        If _Cadena2 = _NroDoc Then
            _Cadena = numero_(_Cadena2, _NroCaracateres)
            Return _Cadena
        End If


        Dim _Cadena1 = Mid(_NroDoc, 1, _Tot_carac - (_Contador - 1))

        If _Suma_uno Then _Cadena2 += 1

        If String.IsNullOrEmpty(_Cadena2) Then
            Return _Cadena1
        End If

        Dim _nr = Len(_Cadena1)

        _Cadena = _Cadena1 & numero_(_Cadena2, _NroCaracateres - _nr)

        Return _Cadena

    End Function

    Enum _Tipo_Boton
        Imagen
        Boton
        Texto
        Combo_Box
    End Enum

    Function Sb_InsertarBotonenGrilla(_Grilla As Object,
                                      _Name As String,
                                      _Text As String,
                                      _HeaderText As String,
                                      _Nrocolumna As Integer,
                                      Optional TipoBoton As _Tipo_Boton = _Tipo_Boton.Boton)

        Dim _Column As Object

        Select Case TipoBoton
            Case _Tipo_Boton.Boton

                _Column = New DataGridViewButtonColumn()

                With _Column
                    .Name = _Name
                    .HeaderText = _HeaderText
                    .Text = _Text
                    .UseColumnTextForButtonValue = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

            Case _Tipo_Boton.Imagen

                _Column = New DataGridViewImageColumn

                With _Column
                    .Name = _Name
                    .HeaderText = _HeaderText
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

            Case _Tipo_Boton.Texto

                _Column = New DataGridViewTextBoxColumn

                With _Column
                    .Name = _Name
                    .HeaderText = _HeaderText
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

            Case _Tipo_Boton.Combo_Box

                _Column = New DataGridViewComboBoxColumn

                With _Column
                    .Name = _Name
                    .HeaderText = _HeaderText
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

        End Select

        _Grilla.Columns.Insert(_Nrocolumna, _Column) 'Está en la segunda fila

    End Function

    Function RutDigito(numero As String) As String

        Dim cuenta, Suma, resto, Digito As Integer
        Dim dig As Decimal
        Suma = 0
        cuenta = 2

        Do
            dig = numero Mod 10
            numero = Int(numero / 10)
            Suma = Suma + (dig * cuenta)
            cuenta = cuenta + 1
            If cuenta = 8 Then cuenta = 2
        Loop Until numero = 0

        resto = Suma Mod 11
        Digito = 11 - resto

        Select Case Digito
            Case 10 : Return "K"
            Case 11 : Return "0"
            Case Else : Return Trim(Str(Digito))
        End Select

    End Function

    Function VerificaDigito(RUT As String) As Boolean
        Try

            Dim Rt(1) As String
            Rt = Split(RUT, "-")

            Dim DigitoVerdadero, Digi As String
            DigitoVerdadero = UCase(RutDigito(Rt(0)))
            Digi = UCase(Rt(1))


            If Trim(Digi) = Trim(DigitoVerdadero) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SumarDatodeGrilla(
       nombre_Columna As String,
       Dgv As DataGridView,
       Optional Resta As Integer = 1) As Double

        Dim total As Double = 0
        Dim valor As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"
        Try
            For i As Integer = 0 To Dgv.RowCount - Resta

                'MsgBox(Dgv.Item(nombre_Columna.ToLower, i).Value)

                valor = De_Txt_a_Num_01(Dgv.Item(nombre_Columna.ToLower, i).Value, 2, "")

                'valor = CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
                total = total + valor
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor
        Return total

    End Function

    Sub Eliminar_Campos(
        dt As DataTable, Id As String)
        Try

            ' Seleccionamos todas las filas del objeto DataTable
            ' donde el campo ROL sea igual al valor pasado al
            ' procedimiento.
            '"Id = " & IdTipoConexion
            Dim filter As String = String.Format("Id = " & Id)
            Dim rows() As DataRow = dt.Select(filter)

            ' Número de registros seleccionados.
            '
            Dim totalValoresIguales As Integer = rows.Count

            ' Eliminamos todos los registros menos el último.
            '
            For Each row In rows

                'If (totalValoresIguales = 1) Then Exit For

                dt.Rows.Remove(row)

                'totalValoresIguales -= 1

            Next

            ' Aceptamos los cambios en el objeto DataTable.      
            '
            dt.AcceptChanges()
        Catch ex As Exception

        End Try

    End Sub

    Public Function LeeArchivo(Ruta As String) As String
        Dim texto As String
        Dim sr As New System.IO.StreamReader(Ruta)
        texto = sr.ReadToEnd()
        sr.Close()
        Return texto
    End Function

    Sub Sb_Formato_Generico_Grilla(_Grilla As DataGridView,
                                   _Alto As Integer,
                                   _Fuente As Font,
                                   _Colores As Color,
                                   _ScrollBars As ScrollBars,
                                   _VerEncFila As Boolean,
                                   _SeleccionarTodaLaFila As Boolean,
                                   _Multiselect As Boolean)

        With _Grilla

            .RowHeadersVisible = _VerEncFila
            .RowTemplate.Height = _Alto

            .DefaultCellStyle.Font = _Fuente 'Font("Tahoma", 7)
            .AlternatingRowsDefaultCellStyle.Font = _Fuente 'Font("Tahoma", 7)

            'Dim _Color_Highlight As Integer = 14120960

            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(_Color_Highlight)

            .AlternatingRowsDefaultCellStyle.BackColor = Color.Black

            Dim _ForeColor As Color = Color.White

            If Global_Thema = Enum_Themas.Oscuro Or Global_Thema = Enum_Themas.Oscuro_Ligth Then ' Dark

                .EnableHeadersVisualStyles = False

                Dim _Color_Back As Color

                If Global_Thema = Enum_Themas.Oscuro Then
                    _Color_Back = Color.FromArgb(32, 32, 32) ' Dark
                Else
                    _Color_Back = Color.FromArgb(45, 45, 45) ' Dark Ligth
                End If

                .BackgroundColor = _Color_Back

                .DefaultCellStyle.BackColor = _Color_Back ' 2
                .DefaultCellStyle.ForeColor = _ForeColor ' 1

                '.DefaultCellStyle.SelectionBackColor = _ForeColor ' 3
                .DefaultCellStyle.SelectionForeColor = Color.Black 'Color.FromArgb(106, 106, 106) ' _Color_Back

                .AlternatingRowsDefaultCellStyle.ForeColor = _ForeColor ' 4
                .AlternatingRowsDefaultCellStyle.BackColor = _Color_Back ' 5

                '.RowsDefaultCellStyle.BackColor = _Color_Back
                .RowsDefaultCellStyle.ForeColor = _ForeColor
                '.RowsDefaultCellStyle.SelectionBackColor = _ForeColor
                .RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(106, 106, 106)

                '.ColumnHeadersDefaultCellStyle.BackColor = _Color_Back
                .ColumnHeadersDefaultCellStyle.ForeColor = _ForeColor
                .ColumnHeadersDefaultCellStyle.SelectionBackColor = _ForeColor
                '.ColumnHeadersDefaultCellStyle.SelectionForeColor = _Color_Back

                '.RowHeadersDefaultCellStyle.BackColor = _Color_Back
                .RowHeadersDefaultCellStyle.ForeColor = _ForeColor
                '.RowHeadersDefaultCellStyle.SelectionBackColor = _ForeColor
                .RowHeadersDefaultCellStyle.SelectionForeColor = _Color_Back


            Else

                .BackgroundColor = Color.White

                .AlternatingRowsDefaultCellStyle.BackColor = _Colores

                .RowsDefaultCellStyle.SelectionForeColor = Color.Black ' Color.FromArgb(203, 203, 203)
                .AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black 'Color.FromArgb(203, 203, 203)

            End If

            .RowTemplate.Resizable = DataGridViewTriState.False
            .ScrollBars = _ScrollBars

            If _SeleccionarTodaLaFila Then
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Else
                .SelectionMode = DataGridViewSelectionMode.CellSelect
            End If

            .MultiSelect = _Multiselect

            '.ColumnHeadersHeight = _Alto
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

        End With

    End Sub

    Function Fx_Validar_Impresora(_Impresora As String) As Boolean

        Dim pd As New PrintDocument

        For i = 1 To PrinterSettings.InstalledPrinters.Count '– 1

            Dim _Impresora_De_Lista = PrinterSettings.InstalledPrinters.Item(i - 1).ToString '_Lista_Impresoras.Items.Item(i - 1).ToString

            If Trim(_Impresora) = Trim(_Impresora_De_Lista) Then
                Return True
            End If

        Next

    End Function

    Public Function Fx_Clonar_Fila_Grilla(_Fila As DataGridViewRow) As DataGridViewRow

        Fx_Clonar_Fila_Grilla = _Fila.Clone

        For index As Int32 = 0 To _Fila.Cells.Count - 1

            Fx_Clonar_Fila_Grilla.Cells(index).Value = _Fila.Cells(index).Value

        Next

    End Function

    Public Function Letras(numero As String) As String

        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"
        Dim _Largo_entero = Len(entero)

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                    flag = "N"
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                                flag = "N"
                            Case "3"
                                palabras = palabras & "trescientos "
                                flag = "N"
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                                flag = "N"
                            Case "5"
                                palabras = palabras & "quinientos "
                                flag = "N"
                            Case "6"
                                palabras = palabras & "seiscientos "
                                flag = "N"
                            Case "7"
                                palabras = palabras & "setecientos "
                                flag = "N"
                            Case "8"
                                palabras = palabras & "ochocientos "
                                flag = "N"
                            Case "9"
                                palabras = palabras & "novecientos "
                                flag = "N"
                        End Select
                    Case 2, 5, 8

                        Dim _Numero_Actual = Mid(entero, num, 1)

                        '*********Asigna las palabras para las decenas************
                        Select Case _Numero_Actual
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********

                        Dim _Numero_Actual = Mid(entero, num, 1)

                        Select Case _Numero_Actual
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        If _Largo_entero > 4 Then
                                            palabras = palabras & "un "
                                        Else
                                            palabras = palabras & ""
                                        End If
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then

                    Dim _Uno = Mid(entero, 1, 1)
                    Dim _Dos = Mid(entero, 2, 1)
                    Dim _Tres = Mid(entero, 3, 1)
                    Dim _Cuatro = Mid(entero, 4, 1)
                    Dim _Cinco = Mid(entero, 5, 1)
                    Dim _Seis = Mid(entero, 6, 1)
                    Dim _Siete = Mid(entero, 7, 1)
                    Dim _Ocho = Mid(entero, 8, 1)
                    Dim _Nueve = Mid(entero, 9, 1)

                    Dim _Len_Entero_6 = Len(entero) <= 6
                    '1 2 3 4 5 6 7 8
                    '2 0 1 5 0 0 0 0
                    '3 0 0 0 0
                    Dim _Anadir_Mil As Boolean


                    If _Cuatro = "0" And _Cinco = "0" And _Seis = "0" And _Siete = "0" And Len(entero) <= 8 Then
                        _Anadir_Mil = True
                    End If

                    If _Cinco = "0" And _Seis = "0" And _Siete = "0" And Len(entero) <= 8 Then
                        _Anadir_Mil = True
                    End If

                    If _Seis = "0" And _Cinco = "0" And _Cuatro = "0" And Len(entero) <= 6 Then
                        _Anadir_Mil = True
                    End If

                    If _Siete = "0" And _Seis = "0" And _Cinco = "0" And _Cuatro = "0" And Len(entero) <= 7 Then
                        _Anadir_Mil = True
                    End If

                    If _Cuatro = "0" And _Tres = "0" And _Dos <> "0" Then
                        _Anadir_Mil = True
                    End If

                    If _Dos = "0" And _Tres = "0" And _Cuatro = "0" Then
                        _Anadir_Mil = False
                    End If

                    If _Seis <> "0" Or _Cinco <> "0" Or _Cuatro <> "0" Then
                        _Anadir_Mil = True
                    End If

                    If _Anadir_Mil Then
                        palabras = palabras & "mil "
                    End If

                    'If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    '  (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And Len(entero) <= 6) Or _
                    '  (Mid(entero, 7, 1) = "0" And Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And Len(entero) <= 7) Then
                    'palabras = palabras & "mil "

                End If


                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If

    End Function

    Function Fx_Es_Dia_Tarde_Noche_Madrugada(_Hora As DateTime) As String

        '_Hora = Convert.ToDateTime("09:00:00").ToShortTimeString

        Dim _Dia As DateTime = Convert.ToDateTime("11:59:00").ToShortTimeString
        Dim _Tarde As DateTime = Convert.ToDateTime("19:59:00").ToShortTimeString
        Dim _Noche As DateTime = Convert.ToDateTime("23:59:00").ToShortTimeString
        Dim _Madrugada As DateTime = Convert.ToDateTime("05:59:00").ToShortTimeString

        Dim fecha1 As DateTime = FormatDateTime(_Hora, DateFormat.ShortTime) ' Convert.ToDateTime("23:58:00")

        If _Hora < _Dia Then
            'Es de noche
            If _Hora < _Madrugada Then
                Return "MADRUGADA"
            Else
                Return "MAÑANA"
            End If
        ElseIf _Hora > _Dia Then
            If _Hora < _Tarde Then
                Return "TARDE"
            Else
                Return "NOCHE"
            End If
            'Es la tarde
        End If

    End Function


    Public Function Fx_GetDCBarCodEAN13(ByRef _Numero As String) As String

        If (_Numero.Length <> 12) Then
            _Numero = ""
            Return ""
        Else
            Dim ch As Char
            For Each ch In _Numero
                If (Not Char.IsNumber(ch)) Then
                    _Numero = ""
                    Return ""
                End If
            Next
        End If

        Dim x, digito, sumaCod As Integer

        ' Extraigo el valor del dígito, y voy
        ' sumando los valores resultantes.
        '
        For x = 11 To 0 Step -1

            digito = CInt(_Numero.Substring(x, 1))

            Select Case x
                Case 1, 3, 5, 7, 9, 11
                    ' Las posiciones impares se multiplican por 3
                    sumaCod += (digito * 3)

                Case Else
                    ' Las posiciones pares se multiplican por 1
                    sumaCod += (digito * 1)
            End Select

        Next

        ' Calculo la decena superior
        '
        digito = (sumaCod Mod 10)

        ' Calculo el dígito de control
        '
        digito = 10 - digito

        ' Código de barras completo
        '
        _Numero &= CStr(digito)

        ' Devuelvo el dígito de control
        '
        Return digito

    End Function

    Function HacerFiltro(Campo As String,
                         Filtro As String)
        If Filtro = "()" Then
            Filtro = "And " & Campo & " In ('#@$')"
        ElseIf Filtro = "'Ver Todo'" Or String.IsNullOrEmpty(Filtro) Then
            Filtro = String.Empty
        Else
            Filtro = "And " & Campo & " In " & Filtro
        End If
        Return Filtro
    End Function

    Function Fx_IsFileOpen(filePath As String) As Boolean
        Dim rtnvalue As Boolean = False
        Try
            Dim fs As System.IO.FileStream = System.IO.File.OpenWrite(filePath)
            fs.Close()
        Catch ex As System.IO.IOException
            rtnvalue = True
        End Try
        Return rtnvalue
    End Function

#Region "CAMBIAR COLOR DE PALABRA EN TEXTO"

    Sub Sb_Cambiar_Color(_Posicion As Integer,
                         _Texto As DevComponents.DotNetBar.Controls.RichTextBoxEx,
                         _Tbl As DataTable,
                         Optional _Campo As String = "CodigoTabla")

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Fx As String = Trim(_Fila.Item(_Campo))

            _Fx = QuitaEspacios_ParaCodigos(_Fx, Len(_Fx))

            Fx_Cambiar_Color(_Fx, Color.Blue, _Texto, _Posicion)

        Next

        _Texto.ForeColor = Color.Black

        '_Texto.SelectionStart = _Posicion
        '_Texto.SelectionLength = 0

    End Sub

    Private Function Fx_Cambiar_Color(_Palabra As String,
                                      _Color As Color,
                                      _Texto As DevComponents.DotNetBar.Controls.RichTextBoxEx,
                                      _Posicion As Long) As Boolean

        Dim _Fx = _Palabra
        Dim _LargoFx = Len(_Fx)

        Dim _Cadena As String = _Texto.Text

        For i = 0 To _Posicion '_Texto.TextLength

            Dim _Resto = _Texto.TextLength - i

            If _Resto > _LargoFx Then
                Dim _Cadena_Extraida = _Cadena.Substring(i, _LargoFx)
                If _Cadena_Extraida = _Fx Then

                    Dim currentFont As System.Drawing.Font = _Texto.SelectionFont
                    'Dim newFontStyle As System.Drawing.FontStyle

                    With _Texto
                        .Select(i, _LargoFx)
                        _Texto.SelectionColor = _Color
                        .SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold)
                        '.Select(0, 0)
                    End With
                    i += 1
                End If
            End If

        Next

    End Function


#End Region


    Function Fx_Validar_Email(email As String) As Boolean

        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex("^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$")
        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)

    End Function

    Function Fx_Validar_Sitio_Web(_Sitio As String) As String 'As Boolean

        Dim Peticion As System.Net.WebRequest
        Dim Respuesta As System.Net.HttpWebResponse

        Dim _Respuestas As String

        Try
            Peticion = System.Net.WebRequest.Create(_Sitio) 'La direccion debe tener el formato ('http://www.direccion.com, es, net, org, vns, etc...))
            Respuesta = Peticion.GetResponse()
            _Respuestas = Respuesta.StatusDescription
            ' Return True
        Catch ex As System.Net.WebException
            _Respuestas = ex.Message
            If ex.Status = Net.WebExceptionStatus.NameResolutionFailure Then

                'Return False
            End If
        End Try

        Return _Respuestas

    End Function

    Function Fx_Exite_Sitio_Web(_Url) As Boolean
        Try
            Dim req As WebRequest = WebRequest.Create(_Url)
            Dim res As WebResponse = req.GetResponse()
            Return True
        Catch ex As WebException
            Return False
        End Try
    End Function

    Sub Sb_Txt_KeyPress_Solo_Numeros(sender As System.Object,
                                     e As System.Windows.Forms.KeyPressEventArgs)


        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Sub Sb_Txt_KeyPress_Solo_Numeros_Enteros(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSinPuntosNiComas(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Sub Sbb_Corrector_ortografico(sender As System.Object, e As System.EventArgs)

        If CType(sender, TextBox).Text.Length > 0 Then
            Dim _WordApp As New Word.Application
            _WordApp.Visible = False
            Dim _doc As Word.Document = _WordApp.Documents.Add
            Dim _range As Word.Range
            _range = _doc.Range
            _range.Text = CType(sender, TextBox).Text
            _doc.Activate()
            _doc.CheckSpelling()
            Dim _chars() As Char = {CType(vbCr, Char), CType(vbLf, Char)}
            CType(sender, TextBox).Text = _doc.Range().Text.Trim(_chars)
            _doc.Close(SaveChanges:=False)
            _WordApp.Quit()
        End If

    End Sub

    Function QuitaEspacios_ParaCodigos(s As String,
                           lon As Integer) As String

        Dim arr(lon - 1) As Char '= s.ToCharArray
        arr = s.ToCharArray
        Dim Contador = arr.Length - 1
        Dim _palabra As String

        ' arr = s.ToCharArray

        Do While (Contador >= 0)

            Dim _Asc As Integer
            Dim _Letra As String = arr(Contador)
            _Asc = Asc(_Letra)

            If _Asc <> 160 Then
                If Contador = arr.Length - 1 Then
                    _palabra = s
                Else
                    _palabra = Mid(s, 1, Contador)
                End If

                Exit Do
            End If

            If Contador = 0 Then

            End If

            Contador -= 1
        Loop

        Return _palabra
        ' Return corre
    End Function

    Public Function abre_formulario(form_hijo As Form, form_padre As Form) As Boolean
        'Dim Mdiform As New form_hijo
        form_hijo.MdiParent = form_padre
        form_hijo.MdiParent.Show()
        form_hijo.Visible = True
    End Function


    Function Fx_Dias_Habiles(_Fecha_inicial As Date, _Fecha_final As Date) As Integer

        Dim dias As Integer
        _Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial) 'agrego un dia adicional para la cuenta ya veraz porque 

        Dim dha As Integer = DateDiff(DateInterval.Day, _Fecha_inicial, _Fecha_final)

        Dim _Dia As Integer
        For _x = 0 To dha '- 1
            _Dia = Weekday(_Fecha_inicial)
            If _Dia <> "1" And _Dia <> "7" Then
                dias += 1
            End If
            _Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial)
        Next

        Return dias

    End Function

    Enum Opcion_Dias
        Habiles
        Lunes
        Marte
        Miercoles
        Jueves
        Viernes
        Sabado
        Domingo
        Todos
    End Enum

    Function Fx_Cuenta_Dias(_Fecha_inicial As Date,
                            _Fecha_final As Date,
                            _Dias_a_contar As Opcion_Dias) As Integer

        _Fecha_inicial = FormatDateTime(_Fecha_inicial, DateFormat.ShortDate)
        _Fecha_final = FormatDateTime(_Fecha_final, DateFormat.ShortDate)

        Dim dias As Integer

        '_Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial) 'agrego un dia adicional para la cuenta ya veraz porque 

        Dim dha As Integer = DateDiff(DateInterval.Day, _Fecha_inicial, _Fecha_final)

        Dim _Dia As Integer
        For _x = 0 To dha '- 1
            _Dia = Weekday(_Fecha_inicial)

            Select Case _Dias_a_contar
                Case Opcion_Dias.Habiles
                    If _Dia <> "1" And _Dia <> "7" Then
                        dias += 1
                    End If
                Case Opcion_Dias.Todos
                    dias = dha 'dias += 1
                    Exit For
                Case Else
                    If _Dia = _Dias_a_contar Then
                        dias += 1
                    End If
            End Select

            _Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial)

        Next

        Return dias

    End Function

    Function Fx_Crea_Tabla_Con_Filtro(dt As DataTable, filter As String, sort As String) As DataTable

        Dim rows As DataRow()

        Dim dtNew As DataTable

        ' copy table structure
        dtNew = dt.Clone()

        ' sort and filter data
        rows = dt.Select(filter, sort)

        ' fill dtNew with selected rows

        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        ' return filtered dt
        Return dtNew

    End Function

    Function Fx_Redondeo_Descuento(_Descuento As Double, _Redondear_Dscto As Boolean)

        Dim _Precio_R As Double = Math.Round(_Descuento, 0)

        If _Redondear_Dscto Then
            Dim _Decena = Split(_Precio_R, ".")
            Dim _Len As Integer = Len(_Decena(0))
            Dim _Ult_Dig = Mid(_Decena(0), _Len, 1)

            _Precio_R = _Precio_R - _Ult_Dig
        End If

        Return _Precio_R

    End Function

    Function Fx_Mes_Palabra(_Mes As String) As String

        _Mes = CInt(_Mes)

        Select Case _Mes
            Case 1
                Return "Enero"
            Case 2
                Return "Febrero"
            Case 3
                Return "Marzo"
            Case 4
                Return "Abril"
            Case 5
                Return "Mayo"
            Case 6
                Return "Junio"
            Case 7
                Return "Julio"
            Case 8
                Return "Agosto"
            Case 9
                Return "Septiembre"
            Case 10
                Return "Octubre"
            Case 11
                Return "Noviembre"
            Case 12
                Return "Diciembre"
        End Select

    End Function

    Public Sub Sb_Grilla_Detalle_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)

        Try

            Dim _Fuente As Font = CType(sender, DataGridView).Font

            'Captura el numero de filas del datagridview

            Dim RowsNumber As String = (e.RowIndex + 1).ToString

            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While

            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, _Fuente)

            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If

            Dim ob As Brush = SystemBrushes.ControlText

            If Global_Thema = Enum_Themas.Oscuro Or Global_Thema = Enum_Themas.Oscuro_Ligth Then
                ob = New SolidBrush(Color.White)
            End If

            e.Graphics.DrawString(RowsNumber, _Fuente, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "vb.net", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub Sb_Ver_Direccion_En_Mapa(_Pais As String, _Ciudad As String, _Comuna As String, _Direccion As String)

        Dim _UrlDireccion As New System.Text.StringBuilder

        _UrlDireccion.Append("http://maps.google.com/maps?q=")

        If Not String.IsNullOrEmpty(_Direccion) Then
            _UrlDireccion.Append(_Direccion + "," & "+")
        End If

        If Not String.IsNullOrEmpty(_Comuna) Then
            _UrlDireccion.Append(_Comuna + "," & "+")
        End If

        If Not String.IsNullOrEmpty(_Pais) Then
            _UrlDireccion.Append(_Pais + "," & "+")
        End If

        Process.Start(_UrlDireccion.ToString)

    End Sub

    Function El_Archivo_Esta_Abierto(filePath As String) As Boolean
        Dim rtnvalue As Boolean = False
        Try
            Dim fs As System.IO.FileStream = System.IO.File.OpenWrite(filePath)
            fs.Close()
        Catch ex As System.IO.IOException
            rtnvalue = True
        End Try
        Return rtnvalue
    End Function

    Function Fx_AjustarTexto(texto As String, maximo As Integer) As String

        Dim _Palabras As String()    ' Un arreglo para almacenar las palabras del texto
        Dim _Linea As String         ' Una variable para construir cada línea
        Dim _Resultado As String     ' Una variable para almacenar el resultado

        texto = texto.Replace("  ", "")
        texto = texto.Replace(Str(13), " ")
        ' texto = texto.Replace(vbCrLf, " ")  ' Reemplazar saltos de línea por espacios

        _Palabras = Split(texto, " ") ' Separar el texto por espacios

        For Each palabra In _Palabras ' Recorrer cada palabra
            If palabra.Contains(vbCrLf) Then ' Si la palabra contiene un "Enter"
                _Resultado = _Resultado & _Linea & vbCrLf ' Agregar la línea al resultado con un salto de línea
                _Linea = "" ' Vaciar la línea
            End If

            If Len(_Linea & palabra) > maximo Then ' Si la línea actual más la palabra supera el máximo
                _Resultado = _Resultado & _Linea & vbCrLf ' Agregar la línea al resultado con un salto de línea
                _Linea = "" ' Vaciar la línea
            End If

            _Linea = _Linea & palabra & " " ' Agregar la palabra a la línea con un espacio
        Next

        _Resultado = (_Resultado & _Linea).ToString.Trim ' Agregar la última línea al resultado
        Fx_AjustarTexto = _Resultado ' Devolver el resultado

    End Function

    Public Function Fx_seleccionar_Impresora(_Formulario As Form) As Sel_Impresora

        Dim _Impresora As New Sel_Impresora

        Dim _prtDialog As New PrintDialog
        Dim _PrtSettings As New PrinterSettings

        If _PrtSettings Is Nothing Then
            _PrtSettings = New PrinterSettings
        End If

        With _prtDialog

            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True

            .PrinterSettings = _PrtSettings
            .PrinterSettings.Copies = 1

            If .ShowDialog(_Formulario) = DialogResult.OK Then
                _PrtSettings = .PrinterSettings
                _Impresora.ImpresoraSeleccionada = True
                _Impresora.prtDialog = _prtDialog
                _Impresora.PrtSettings = _PrtSettings
            End If

        End With

        Return _Impresora

    End Function

    Function Fx_ReemplazarCaracteresRaros(texto As String) As String

        Dim caracteresExtraños As String = "Ã¡Ã©Ã­Ã³ÃºÃ±Ã¿Ã¼"  ' Añade aquí los caracteres extraños que necesitas reemplazar
        Dim caracteresNormales As String = "áéíóúñÿü"         ' Añade aquí los caracteres normales correspondientes
        Dim resultado As String = texto

        For i As Integer = 1 To Len(caracteresExtraños)
            resultado = Replace(resultado, Mid(caracteresExtraños, i, 1), Mid(caracteresNormales, i, 1))
        Next i

        Return resultado

    End Function

    Function Fx_ReemplazarCaracteresRaros2(texto As String) As String

        Dim caracteresExtraños() As String
        Dim caracteresNormales() As String
        Dim resultado As String = texto
        Dim i As Integer

        ' Definir los caracteres extraños y sus reemplazos correspondientes
        caracteresExtraños = Split("Ã¡,Ã©,Ã­,Ã³,Ãº,Ã±,Ã¼,Ã‰", ",")
        caracteresNormales = Split("á,é,í,ó,ú,ñ,ü,E", ",")

        ' Reemplazar los caracteres extraños por los caracteres normales
        For i = LBound(caracteresExtraños) To UBound(caracteresExtraños)
            resultado = Replace(resultado, caracteresExtraños(i), caracteresNormales(i))
        Next i

        If IsNothing(resultado) Then
            resultado = String.Empty
        End If

        Return resultado

    End Function

    Public Function Fx_SanitizaNombreArchivo(_NombreArchivo As String) As String
        Dim invalidChars As Char() = Path.GetInvalidFileNameChars()
        Dim sanitizedFileName As New StringBuilder()

        For Each ch As Char In _NombreArchivo
            If Not invalidChars.Contains(ch) Then
                sanitizedFileName.Append(ch)
            End If
        Next

        Return sanitizedFileName.ToString()
    End Function

End Module

Public Class Sel_Impresora

    Public Property ImpresoraSeleccionada As Boolean
    Public Property prtDialog As New PrintDialog
    Public Property PrtSettings As New PrinterSettings

End Class


