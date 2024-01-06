Imports DevComponents.DotNetBar
Imports System.Globalization

Module Mod_Imprimir

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowMaeedo As DataRow
    Dim _RowMaedpce As DataRow

    Private _Impresora_Seleccionada As String

    Public ReadOnly Property Pro_RowMaeedo_Ultimo_Doc_Impreso() As DataRow
        Get
            Return _RowMaeedo
        End Get
    End Property
    Public ReadOnly Property Pro_RowMaeedo_Ultimo_Chc_Impreso() As DataRow
        Get
            Return _RowMaedpce
        End Get
    End Property

    Function Fx_Enviar_A_Imprimir_Documento(_Formulario As Form,
                                            _NombreFormato As String,
                                            _Idmaeedo As Integer,
                                            _Preguntar_Si_Imprime_Cedible As Boolean,
                                            _Seleccionar_Impresora As Boolean,
                                            _Impresora As String,
                                            _Vista_Previa As Boolean,
                                            _Nro_Copias As Integer,
                                            _Reimprimir As Boolean,
                                            _Subtido As String) As String
        _RowMaeedo = Nothing
        Dim _LogError As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _RowMaeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _RowMaeedo Is Nothing Then
            Return "No se encontro documento IDMAEEDO:" & _Idmaeedo
        End If

        Dim _Tido = _RowMaeedo.Item("TIDO")
        Dim _Nudo = _RowMaeedo.Item("NUDO")

        Consulta_sql = "Select Top 1 NombreFormato_Destino From " & _Global_BaseBk & "Zw_Prod_ImpAdicional" & vbCrLf &
                       "Where Tido = '" & _Tido & "' And Subtido = '" & _Subtido & "' And NombreFormato_Origen = '" & _NombreFormato & "' " &
                       "And Codigo In (Select KOPRCT From MAEDDO Where IDMAEEDO = " & _Idmaeedo & ") And Reemplazar_Formato_Origen = 1"
        Dim _Row_FormatoAdicional As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_FormatoAdicional) Then
            _NombreFormato = _Row_FormatoAdicional.Item("NombreFormato_Destino")
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _Tido & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "'"

        Dim _RowEncFormato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_RowEncFormato Is Nothing) Then
            Dim _Copias = _RowEncFormato.Item("Copias")
            If _Nro_Copias = 0 Then
                _Nro_Copias = _Copias
            End If
        Else
            Return "No existe el formato (''" & _NombreFormato & "'') para el documento: " & _Tido
        End If

        Dim _Doc_Electronico As Boolean = _RowEncFormato.Item("Doc_Electronico")

        If _Reimprimir Then
            _Nro_Copias = 1
        End If


        Dim _Imprimir_Cedible As Boolean

        If _Doc_Electronico Then

            If _Preguntar_Si_Imprime_Cedible Then

                If IsNothing(_Formulario) Then

                    _Imprimir_Cedible = True

                Else

                    If MessageBoxEx.Show(_Formulario, "¿Desea imprimir la copia CEDIBLE?", "Imprimir CEDIBLE",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        _Imprimir_Cedible = True
                    End If

                End If

            Else

                _Imprimir_Cedible = True

            End If

        End If

        Dim _Nro_Impreso = 1

        For _i = 1 To _Nro_Copias

            If _Nro_Copias > 1 Then

                If _i > 1 Then

                    _Nudo = _Nudo & "_Copia_" & numero_(_i - 1, 2)

                End If

            End If

            _LogError = Fx_Imprimir_Documento(_Idmaeedo, _Tido, _Nudo, _NombreFormato, False,
                                              _Seleccionar_Impresora, _Vista_Previa, _Impresora, _Subtido)

            If String.IsNullOrEmpty(_LogError) Then

                If _Imprimir_Cedible And _Nro_Impreso = 1 And _Tido <> "BLV" Then

                    If _Doc_Electronico Then

                        Dim _Imp = _Impresora

                        If _Seleccionar_Impresora Then

                            _Imp = _Impresora_Seleccionada

                        End If

                        _LogError = Fx_Imprimir_Documento(_Idmaeedo, _Tido, _Nudo, _NombreFormato, True,
                                                      False, _Vista_Previa,
                                                      _Imp, _Subtido)
                    End If

                End If

                Consulta_sql = "Select Distinct NombreFormato_Destino From " & _Global_BaseBk & "Zw_Prod_ImpAdicional" & vbCrLf &
                               "Where Tido = '" & _Tido & "' And Subtido = '" & _Subtido & "' And NombreFormato_Origen = '" & _NombreFormato & "' " &
                               "And Codigo In (Select KOPRCT From MAEDDO Where IDMAEEDO = " & _Idmaeedo & ") And Reemplazar_Formato_Origen = 0"
                Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                For Each _Fila As DataRow In _Tbl.Rows
                    _LogError = Fx_Imprimir_Documento(_Idmaeedo, _Tido, _Nudo, _Fila.Item("NombreFormato_Destino"), False,
                                  _Seleccionar_Impresora, _Vista_Previa, _Impresora, _Subtido)
                Next

            Else

                Return _LogError

            End If

            _Nro_Impreso += 1

        Next

        Return _LogError

    End Function

    Function Fx_Imprimir_Documento(_Id As Integer,
                                   _TipoDoc As String,
                                   _Nudo As String,
                                   _NombreFormato As String,
                                   _Imprimir_Cedible As Boolean,
                                   _Seleccionar_Impresora As Boolean,
                                   _Vista_Previa As Boolean,
                                   _Impresora As String,
                                   _Subtido As String) As String

        '_Imprimir_Cedible

        Dim _Imprimir As New Clas_Imprimir_Documento(_Id,
                                                     _TipoDoc,
                                                     _NombreFormato,
                                                     _TipoDoc & "-" & _Nudo, _Imprimir_Cedible, "", _Subtido)
        Dim _Documento_Impreso As Boolean


        If Not String.IsNullOrEmpty(_Impresora) Then
            _Imprimir.Pro_Impresora = _Impresora
        End If

        If _Seleccionar_Impresora Then
            If _Imprimir.Fx_seleccionar_Impresora(_Seleccionar_Impresora) Then
                _Impresora_Seleccionada = _Imprimir.Pro_Impresora
            Else
                Return "No se selecciona impresora"
            End If
        End If

        _Imprimir.Fx_Imprimir_Documento(Nothing, _Vista_Previa, False)

        '_Imprimir.MostrarError

        Dim _LogError = _Imprimir.Pro_Ultimo_Error

        _Documento_Impreso = _Imprimir.Pro_Documento_Impreso

        _Imprimir.PrintDoc1 = Nothing

        _Imprimir = Nothing

        If _Documento_Impreso Then
            Return ""
        Else
            Return _LogError
        End If

    End Function

    Function Fx_New_Inserta_Funciones_Bk_En_Encabezado(ByVal _Row_Maeedo As DataRow) As DataRow

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Valor
        Dim _Idmaeedo = _Row_Maeedo.Item("IDMAEEDO")
        Dim _Koen = _Row_Maeedo.Item("ENDO")
        Dim _Suen = _Row_Maeedo.Item("SUENDO")

        Dim _Palabra As String
        Dim _Palabra1, _Palabra2 As String


        ' Rut Entidad
        _Valor = NuloPorNro(_Row_Maeedo.Item("RTEN"), "")

        Dim _R = De_Txt_a_Num_01(_Valor, 0)
        Dim _Rut = FormatNumber(_R, 0) & "-" & RutDigito(_R)

        _Valor = _Rut 'Fx_Rut(Trim(_Valor))
        _Row_Maeedo.Item("Bk_Rut") = _Valor


        ' T_Escrito_1_Bruto As String
        _Valor = _Row_Maeedo.Item("VABRDO") '_Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

        _Palabra = UCase(Letras(_Valor))

        _Palabra1 = Mid(_Palabra, 1, 50)
        _Palabra2 = Mid(_Palabra, 51, 100)

        Dim _Komo As String = _Row_Maeedo.Item("MODO")

        Dim _Nokomo As String = _Sql.Fx_Trae_Dato("TABMO", "NOKOMO", "KOMO = '" & _Komo & "'").ToLower.Trim

        If _Komo = "US$" Then
            _Nokomo = "dolares"
        End If

        If String.IsNullOrEmpty(_Palabra2) Then
            If Len(_Palabra1) <= 44 Then
                _Palabra1 += _Nokomo '"pesos"
            End If
        End If

        _Valor = Rellenar(_Palabra1, 50, "-", True)
        _Row_Maeedo.Item("Bk_T_Escrito_1_Bruto") = _Valor

        '"Total Escrito(2) Bruto"

        _Valor = _Row_Maeedo.Item("VABRDO") '_Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

        _Palabra = UCase(Letras(_Valor))

        _Palabra1 = Mid(_Palabra, 1, 50)
        _Palabra2 = Mid(_Palabra, 51, 100)

        If Not String.IsNullOrEmpty(_Palabra2) Then
            If Len(_Palabra2) <= 44 Then
                _Palabra2 += _Nokomo '"pesos"
            End If
        Else
            If Len(_Palabra1) > 44 Then
                _Palabra2 += _Nokomo '"pesos"
            End If
        End If

        '_Palabra = Mid(_Palabra, 51, 100)
        _Valor = Rellenar(_Palabra2, 50, "-", True)
        _Row_Maeedo.Item("Bk_T_Escrito_2_Bruto") = _Valor


        'Caja Modalidad (Codigo)"
        _Valor = _Global_Row_Configuracion_Estacion.Item("ECAJA")
        _Row_Maeedo.Item("Bk_Caja_Mod_Codigo") = _Valor

        'Case "Caja Modalidad (Nombre)"
        Dim _Empresa = _Global_Row_Configuracion_Estacion.Item("EMPRESA")
        Dim _Kosu = _Global_Row_Configuracion_Estacion.Item("ESUCURSAL")
        Dim _Kocj = _Global_Row_Configuracion_Estacion.Item("ECAJA")

        _Valor = _Sql.Fx_Trae_Dato("TABCJ", "NOKOCJ", _
                                   "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Kosu & "' And KOCJ = '" & _Kocj & "'")

        _Row_Maeedo.Item("Bk_Caja_Mod_Nombre") = Trim(_Valor)

        'Case "Sucursal Modalidad (Codigo)"
        _Valor = _Global_Row_Configuracion_Estacion.Item("ESUCURSAL")
        _Row_Maeedo.Item("Bk_Sucursal_Mod_Codigo") = Trim(_Valor)

        'Case "Sucursal Modalidad (Nombre)"
        _Empresa = _Global_Row_Configuracion_Estacion.Item("EMPRESA")
        _Kosu = _Global_Row_Configuracion_Estacion.Item("ESUCURSAL")

        _Valor = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", _
                                   "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Kosu & "'")
        _Row_Maeedo.Item("Bk_Sucursal_Mod_Nombre") = Trim(_Valor)

        Return _Row_Maeedo

    End Function

    Function Fx_New_Inserta_Funciones_Bk_En_Encabezado_Cheque(ByVal _Row_Encabezado As DataRow) As DataRow

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Valor
        Dim _Idmaedpce = _Row_Encabezado.Item("IDMAEDPCE")
        '0'Dim _Koen = _Row_Encabezado.Item("ENDO")
        'Dim _Suen = _Row_Encabezado.Item("SUENDO")

        Dim _Palabra As String
        Dim _Palabra1, _Palabra2 As String

        ' Rut Entidad
        _Valor = _Row_Encabezado.Item("RTEN")

        Dim _R = De_Txt_a_Num_01(_Valor, 0)
        Dim _Rut = FormatNumber(_R, 0) & "-" & RutDigito(_R)

        _Valor = _Rut 'Fx_Rut(Trim(_Valor))
        _Row_Encabezado.Item("Bk_Rut") = _Valor


        ' T_Escrito_1_Bruto As String
        _Valor = _Row_Encabezado.Item("VADP")

        _Palabra = UCase(Letras(_Valor))

        _Palabra1 = Mid(_Palabra, 1, 50)
        _Palabra2 = Mid(_Palabra, 51, 100)

        If String.IsNullOrEmpty(_Palabra2) Then
            If Len(_Palabra1) <= 44 Then
                _Palabra1 += "pesos"
            End If
        End If

        _Valor = Rellenar(_Palabra1, 50, "-", True)
        _Row_Encabezado.Item("Bk_Chc_Escrito_1_Bruto") = _Valor

        '"Total Escrito(2) Bruto"

        _Valor = _Row_Encabezado.Item("VADP") '_Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

        _Palabra = UCase(Letras(_Valor))

        _Palabra1 = Mid(_Palabra, 1, 50)
        _Palabra2 = Mid(_Palabra, 51, 100)

        If Not String.IsNullOrEmpty(_Palabra2) Then
            If Len(_Palabra2) <= 44 Then
                _Palabra2 += "pesos"
            End If
        Else
            If Len(_Palabra1) > 44 Then
                _Palabra2 += "pesos"
            End If
        End If

        '_Palabra = Mid(_Palabra, 51, 100)
        _Valor = Rellenar(_Palabra2, 50, "-", True)
        _Row_Encabezado.Item("Bk_Chc_Escrito_2_Bruto") = _Valor


        Return _Row_Encabezado

    End Function

    Function Fx_New_Trae_Valor_Detalle_Row(ByVal _Campo As String,
                                      ByVal _Tipo_de_dato As String,
                                      ByVal _Es_Descuento As Boolean,
                                      ByVal _RowDetalle As DataRow,
                                      Optional ByVal _Formato As String = "",
                                      Optional _Moneda_Str As String = "$")

        Dim _Valor As String
        Dim _Prct As Boolean

        Try
            _Prct = _RowDetalle.Item("PRCT")
        Catch ex As Exception
            _Prct = False
        End Try

        If String.IsNullOrEmpty(_Formato) Then Return "?S/formato" '_Formato = _Row_Zw_Format_Fx.Item("Formato")

        Try
            _Valor = NuloPorNro(_RowDetalle.Item(Trim(_Campo)), "")
        Catch ex As Exception
            If _Prct Then
                _Valor = String.Empty
            Else
                _Valor = "Error_"
            End If
            _Tipo_de_dato = "C"
            Return _Valor
        End Try

        Dim _Cant_Caracteres As Integer = Len(_Formato)

        Select Case _Tipo_de_dato

            Case "N"

                If _Prct And (_Campo = "Bk_Cant_Trans" Or _Campo = "CAPRCO1" Or _Campo = "CAPRCO2") Then
                    _Valor = String.Empty
                Else
                    _Valor = Fx_Formato_Numerico(_Valor, _Formato, _Es_Descuento, _Moneda_Str)
                End If

            Case "C"

                If Mid(UCase(_Formato), 1, 1) = "R" Then ' 
                    _Valor = Right(_Valor, _Cant_Caracteres)
                Else
                    _Valor = Trim(Mid(_Valor, 1, _Cant_Caracteres))
                End If

                If Not String.IsNullOrEmpty(_Valor) Then
                    _Valor = Replace(_Valor, vbCrLf, " ").Trim
                End If

            Case "F"

                Dim _FValor As Date = FormatDateTime(_RowDetalle.Item(_Campo), DateFormat.ShortDate)

                _Formato = UCase(Trim(_Formato))

                Select Case _Formato
                    Case "DD/MM/AAAA"
                        _Valor = Format(_FValor, "dd/MM/yyyy")
                    Case "DD-MM-AAAA"
                        _Valor = Format(_FValor, "dd-MM-yyyy")
                    Case "LONG DATE"
                        _Valor = FormatDateTime(_FValor, DateFormat.LongDate)
                    Case "DD"
                        _Valor = numero_(_FValor.Day, 2)
                    Case "MM"
                        _Valor = numero_(_FValor.Month, 2)
                    Case "AAAA"
                        _Valor = _FValor.Year
                    Case "AA"
                        _Valor = Format(_FValor, "yy")
                    Case "DIA PALABRA"
                        _Valor = _FValor.ToString("dddd", New CultureInfo("es-ES"))
                    Case "MES PALABRA"
                        _Valor = MonthName(Month(_FValor))
                    Case Else
                        _Valor = FormatDateTime(_FValor, DateFormat.ShortDate)
                End Select

        End Select

        Return _Valor

    End Function

    Function Fx_New_Trae_Valor_Encabezado_Row(_Campo As String,
                                              _Tipo_de_dato As String,
                                              _Es_Descuento As Boolean,
                                              _RowEncabezado As DataRow,
                                              Optional ByVal _Formato As String = "",
                                              Optional _Moneda_Str As String = "$")

        Dim _Valor As String = String.Empty

        If String.IsNullOrEmpty(_Formato) Then Return "?S/formato" '_Formato = _Row_Zw_Format_Fx.Item("Formato")

        If IsNothing(_RowEncabezado) Then
            Return ""
        End If

        Try
            _Valor = _RowEncabezado.Item(Trim(_Campo))
        Catch ex As Exception

            Try
                _Valor = NuloPorNro(_RowEncabezado.Item(Trim(_Campo)), "")
            Catch ex2 As Exception
                _Valor = "Error_"
                _Tipo_de_dato = "C"
            End Try

        End Try

        Dim _Cant_Caracteres As Integer = Len(_Formato)

        Select Case _Tipo_de_dato

            Case "N"

                'Dim _Moneda_Str As String = "$"

                'If _Formato.Contains("$") Then
                '    _Moneda_Str = _RowEncabezado.Item("MODO").ToString.Trim
                'End If

                _Valor = Fx_Formato_Numerico(_Valor, _Formato, _Es_Descuento, _Moneda_Str)

            Case "C"

                _Valor = Trim(Mid(_Valor, 1, _Cant_Caracteres))

            Case "F"

                Dim _FValor As Date

                Try
                    _FValor = FormatDateTime(_RowEncabezado.Item(_Campo), DateFormat.ShortDate)
                Catch ex As Exception
                    Return ""
                End Try


                _Formato = UCase(Trim(_Formato))

                Select Case _Formato
                    Case "DD/MM/AAAA"
                        _Valor = Format(_FValor, "dd/MM/yyyy")
                    Case "DD-MM-AAAA"
                        _Valor = Format(_FValor, "dd-MM-yyyy")
                    Case "LONG DATE"
                        _Valor = FormatDateTime(_FValor, DateFormat.LongDate)
                    Case "DD"
                        _Valor = numero_(_FValor.Day, 2)
                    Case "MM"
                        _Valor = numero_(_FValor.Month, 2)
                    Case "AAAA"
                        _Valor = _FValor.Year
                    Case "AA"
                        _Valor = Format(_FValor, "yy")
                    Case "DIA PALABRA"
                        _Valor = _FValor.ToString("dddd", New CultureInfo("es-ES"))
                    Case "MES PALABRA"
                        _Valor = MonthName(Month(_FValor))
                    Case Else
                        _Valor = FormatDateTime(_FValor, DateFormat.ShortDate)
                End Select

        End Select

        Return _Valor

    End Function

    Function Fx_Formato_Numerico_Old(ByVal _Valor As String,
                                 ByVal _Formato As String,
                                 ByVal _Es_Descuento As Boolean) As String

        Dim _Cant_Caracteres As Integer = Len(_Formato)
        Dim _Moneda As Boolean

        Dim _Precio_Val As Double

        Dim _Decimales = 0
        If _Formato.Contains(",") Then
            Dim _Dec = Split(_Formato, ",", 2)
            _Decimales = Len(_Dec(1))
        End If

        Dim _FORMAT As String

        If Not _Valor.Contains(",") Then

            _Decimales = 0
            Dim _Frmt = Split(_Formato, ",", 2)
            _Formato = _Frmt(0)

        End If

        Dim _Relleno As String = Mid(_Formato, 1, 1)

        If IsNumeric(_Relleno) Then
            _Relleno = " "
        Else
            _Formato = Replace(_Formato, _Relleno, "")
        End If

        If _Relleno = "$" Then
            _Moneda = True
            _Relleno = " "
            _Cant_Caracteres -= 1
        End If

        _Precio_Val = De_Txt_a_Num_01(_Valor, _Decimales)
        _Precio_Val = Math.Round(_Precio_Val, _Decimales)

        If _Es_Descuento Then
            _Precio_Val = _Precio_Val * -1
        End If

        Dim _Precio = FormatNumber(_Precio_Val, _Decimales)

        ' Alinear a la derecha si el formato contiene 8
        If _Formato.Contains(9) Then 'Mid(_Formato, 1, 1) <> 8 Then
            _Precio = Rellenar(_Precio, _Cant_Caracteres, _Relleno, False)
        End If

        If _Moneda Then
            '_Valor = Mid(_Precio, 1, Len(_Precio) - 1)
            _Valor = "$" & _Precio
        Else
            _Valor = _Precio
        End If

        Fx_Formato_Numerico_Old = _Valor

    End Function

    Function Fx_Funcion_SQL_Personalizada_Enc_Pie(_SqlQuery As String,
                                                  _Idmaeedo As Integer,
                                                  ByRef _Error As String) As DataRow

        _SqlQuery = "Declare @Idmaeedo Int,@Koen Char(13),@Suen Char(20)" & vbCrLf &
                    "Set @Idmaeedo = " & _Idmaeedo & vbCrLf &
                    "Set @Koen = (SELECT ENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf &
                    "Set @Suen = (SELECT SUENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf & vbCrLf &
                    _SqlQuery

        '_SqlQuery = UCase(_SqlQuery)

        Dim _Row As DataRow

        _Row = _Sql.Fx_Get_DataRow(_SqlQuery, False)
        _Error = _Sql.Pro_Error

        If Not String.IsNullOrEmpty(_Error) Then
            Try
                My.Computer.Clipboard.SetText(_SqlQuery)
            Catch ex As Exception

            End Try
        End If

        Return _Row

    End Function

    Function Fx_Funcion_SQL_Personalizada_Detalle(_SqlQuery As String,
                                                  _Idmaeddo As Integer,
                                                  ByRef _Error As String) As DataRow

        _SqlQuery = "Declare @Idmaeddo Int,@Kopr Char(13),@Nokopr Varchar(50),@Empresa Char(2),@Sucursal Char(3),@Bodega Char(3),@Cantidad1 Float,@Cantidad2 Float" & vbCrLf &
                    "Select @Idmaeddo = " & _Idmaeddo & vbCrLf &
                    "Select " & vbCrLf &
                    "@Kopr = (SELECT KOPRCT FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                    "@Nokopr = (SELECT NOKOPR FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                    "@Empresa = (SELECT EMPRESA FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                    "@Sucursal = (SELECT SULIDO FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                    "@Bodega = (SELECT BOSULIDO FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                    "@Cantidad1 = (SELECT CAPRCO1 FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                    "@Cantidad2 = (SELECT CAPRCO2 FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)" & vbCrLf & vbCrLf &
                    _SqlQuery

        '_SqlQuery = UCase(_SqlQuery)

        Dim _Row As DataRow

        _Row = _Sql.Fx_Get_DataRow(_SqlQuery, False)
        _Error = _Sql.Pro_Error

        Return _Row

    End Function

End Module
