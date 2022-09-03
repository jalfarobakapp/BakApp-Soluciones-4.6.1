Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports DevComponents.DotNetBar
Imports System.Data.SqlClient
Imports System.Windows.Forms



Public Module Md_Encrypta

    Public Dias_Caducidad_BakApp As Long
    Public Ds_Licencia As New DataSet
    'Debe ser 64 bits, 8 bytes.
    Private Const sSecretKey As String = "BakApp_K"
    Dim Directorio As String = AppPath(True)

    Sub RealizarEnCryp(ByVal NombreArchivoLlave As String)


        EncryptFile(Directorio & "\Data\LlaveBk.txt", _
                    Directorio & "\" & NombreArchivoLlave & ".sct", _
                    sSecretKey)

        Return

        DecryptFile(Directorio & "\LlaveBk.sct", _
                    Directorio & "\Data\LlaveBk.txt", _
                    sSecretKey)

    End Sub
     
    Function RevisarLlave_BakApp(ByVal Llave As String, _
                                 ByVal NombreArchivoLlave As String)

        Try

        
            Dim fsDecrypted As New StreamWriter(Directorio & "\Data\LlaveBk.txt")
            fsDecrypted.Write(Llave)
            fsDecrypted.Flush()
            fsDecrypted.Close()

            Dim Desglo_Llave() As String
            Dim _Extencion As String
            Dim texto As String

            If NombreArchivoLlave <> "BakApp" Then
                _Extencion = ".xml"
                DecryptFile(Directorio & "\" & NombreArchivoLlave & ".sct", _
                                        Directorio & "\Data\LlaveBk" & _Extencion, _
                                        sSecretKey)

                Ds_Licencia.Clear()
                Ds_Licencia.ReadXml(Directorio & "\Data\LlaveBk.xml")

                texto = Trim(Ds_Licencia.Tables("Empresa").Rows(0).Item("Rut")) & "_" & _
                        Trim(Ds_Licencia.Tables("Empresa").Rows(0).Item("Razon"))

                Ds_Licencia.WriteXml(Directorio & "\Data\" & RutEmpresa & "\Licencia.xml")
            Else
                _Extencion = ".txt"
                DecryptFile(Directorio & "\" & NombreArchivoLlave & ".sct", _
                                       Directorio & "\Data\LlaveBk" & _Extencion, _
                                       sSecretKey)
                Dim sr As New System.IO.StreamReader(Directorio & "\Data\LlaveBk" & _Extencion)
                texto = Trim(sr.ReadToEnd())
                sr.Close()
            End If





            If NombreArchivoLlave <> "BakApp" Then
                'Desglo_Llave = Split(texto, ";")

                'texto = Desglo_Llave(0)
                Dim Fe As Date = Ds_Licencia.Tables("Empresa").Rows(0).Item("Fecha_Expiracion")
                'CDate(Desglo_Llave(1)) ' CDate("25-07-2014")
                Dim Fecha_Servidor As Date = FechaDelServidor()

                Dias_Caducidad_BakApp = DateDiff(DateInterval.Day, Fecha_Servidor, Fe)

                If Dias_Caducidad_BakApp <= 0 Then
                    MessageBoxEx.Show("Licencia de Uso expirada" & vbCrLf & _
                                       "Pongase en contacto con BakApp Soluciones [www.bakapp.cl]", "Licencia de uso", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                    Return False
                End If

                If Dias_Caducidad_BakApp <= 10 Then
                    MessageBoxEx.Show("Quedan " & Dias_Caducidad_BakApp & " días para que expire su licencia" & vbCrLf & _
                                       "Pongase en contacto con BakApp Soluciones [www.bakapp.cl]", _
                                       "Licencia de uso", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)

                End If
            End If


            My.Computer.FileSystem.DeleteFile(Directorio & "\Data\LlaveBk" & _Extencion)

            If texto = Llave Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Sub EncryptFile(ByVal sInputFilename As String, _
                    ByVal sOutputFilename As String, _
                    ByVal sKey As String)


        Dim fsInput As New FileStream(sInputFilename, _
                           FileMode.Open, FileAccess.Read)



        Dim fsEncrypted As New FileStream(sOutputFilename, _
                                    FileMode.Create, FileAccess.Write)

        Dim DES As New DESCryptoServiceProvider()

        'Establecer la clave secreta para el algoritmo DES.
        'Se necesita una clave de 64 bits y IV para este proveedor
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Establecer el vector de inicialización.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'crear cifrado DES a partir de esta instancia
        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()
        'Crear una secuencia de cifrado que transforma la secuencia
        'de archivos mediante cifrado DES
        Dim cryptostream As New CryptoStream(fsEncrypted, _
                                            desencrypt, _
                                            CryptoStreamMode.Write)

        'Leer el texto del archivo en la matriz de bytes
        Dim bytearrayinput(fsInput.Length - 1) As Byte
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)
        'Escribir el archivo cifrado con DES
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Close()
        fsInput.Close()
    End Sub

    Sub DecryptFile(ByVal sInputFilename As String, _
       ByVal sOutputFilename As String, _
       ByVal sKey As String)

        Dim DES As New DESCryptoServiceProvider()
        'Se requiere una clave de 64 bits y IV para este proveedor.
        'Establecer la clave secreta para el algoritmo DES.
        DES.Key() = ASCIIEncoding.ASCII.GetBytes(sKey)
        'Establecer el vector de inicialización.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'crear la secuencia de archivos para volver a leer el archivo cifrado
        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)
        'crear descriptor DES a partir de nuestra instancia de DES
        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()
        'crear conjunto de secuencias de cifrado para leer y realizar 
        'una transformación de descifrado DES en los bytes entrantes
        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)
        'imprimir el contenido de archivo descifrado
        Dim fsDecrypted As New StreamWriter(sOutputFilename)
        fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd)
        fsDecrypted.Flush()
        fsDecrypted.Close()
    End Sub


    


End Module
