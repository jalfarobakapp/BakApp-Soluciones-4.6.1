Public Module aletras
    '****************************************
    'Desarrollado por: Pedro Alex Taya Yactayo
    'Email: alextaya@hotmail.com
    'Web: http://es.geocities.com/wiseman_alextaya
    '     http://groups.msn.com/mugcanete
    '****************************************

    Public Function Letras(ByVal numero As String) As String
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

End Module
