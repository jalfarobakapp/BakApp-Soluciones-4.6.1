Imports DevComponents.DotNetBar
Imports System.IO

Imports System.Text
Imports System.Security.Cryptography

Public Class Frm_Licencia_Empresa

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo_Encryptador As String = "ARDILLA."
    Dim _DiasExpira As Integer

    Dim _Primera_Licencia As Boolean
    Dim _Actualizar_Licencia As Boolean

    Public Property Pro_Primera_Licencia As Boolean
        Get
            Return _Primera_Licencia
        End Get
        Set(value As Boolean)
            _Primera_Licencia = value
        End Set
    End Property
    Public Property Pro_Actualizar_Licencia As Boolean
        Get
            Return _Actualizar_Licencia
        End Get
        Set(value As Boolean)
            _Actualizar_Licencia = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnAceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Licencia_Empresa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Licencia"

        Dim _TblEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        TxtRut.Text = _TblEmpresa.Rows(0).Item("Rut")
        TxtRazonSocial.Text = _TblEmpresa.Rows(0).Item("Razon")
        TxtNombreCorto.Text = _TblEmpresa.Rows(0).Item("NombreCorto")
        TxtDireccion.Text = _TblEmpresa.Rows(0).Item("Direccion")
        TxtGiro.Text = _TblEmpresa.Rows(0).Item("Giro")
        DtpFechaExpiracion.Value = NuloPorNro(_TblEmpresa.Rows(0).Item("Fecha_caduca"), Now.Date)
        TxtPais.Text = _TblEmpresa.Rows(0).Item("Pais")
        TxtCiudad.Text = _TblEmpresa.Rows(0).Item("Ciudad")
        TxtTelefonos.Text = _TblEmpresa.Rows(0).Item("Telefonos")

        TxtCant_licencias.Text = _TblEmpresa.Rows(0).Item("Cant_licencias")

        Txt_Llave1.Text = _TblEmpresa.Rows(0).Item("Llave1")
        Txt_Llave2.Text = _TblEmpresa.Rows(0).Item("Llave2")
        Txt_Llave3.Text = _TblEmpresa.Rows(0).Item("Llave3")
        Txt_Llave4.Text = _TblEmpresa.Rows(0).Item("Llave4")

        _DiasExpira = DateDiff(DateInterval.Day, FechaDelServidor, DtpFechaExpiracion.Value)

        If _DiasExpira <= 0 Then
            Imagen_LLave_1.Image = ImageList1.Images.Item(2)
            Imagen_LLave_2.Image = ImageList1.Images.Item(2)
            Imagen_LLave_3.Image = ImageList1.Images.Item(2)
            Imagen_LLave_4.Image = ImageList1.Images.Item(2)
        End If

    End Sub

    Function Fx_Encriptar(ByVal Input As String, ByVal _Codigo_Encryptador As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes(_Codigo_Encryptador) 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function

    Function Fx_Desencriptar(ByVal Input As String, ByVal _Codigo_Encryptador As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes(_Codigo_Encryptador) 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Convert.FromBase64String(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub

    Function Fx_Generar_Llave(ByVal _RutEmpresa As String) As String
        ' Obtenemos la longitud de la cadena de _RutEmpresa
        Dim longitud As Byte = _RutEmpresa.Length
        ' Declaramos valorEntrada para obtener el valor general
        ' correspondiente a la entrada de _RutEmpresa
        Dim valorEntrada As Long = 0
        ' Recorremos la cadena entera para sumar el valor
        ' total de sus cASCII
        For I As Byte = 0 To longitud - 1
            valorEntrada += Asc(_RutEmpresa.Substring(I, 1))
        Next
        ' Dividimos el valor final resultante de la suma de
        ' sus valores ASCII entre la longitud de la cadena
        valorEntrada \= longitud
        ' Obtenemos un valor base que corresponde con el
        ' cdel producto entre el valor de entrada 
        ' anteriormente calcula por su longitud
        Dim valorBase As Integer = valorEntrada * longitud
        Dim key As String = ""
        ' Empezamos obteniento valores
        ' Obtenemos el valor hexadecimal
        Dim valor As String = Hex(valorBase + (123 * 10000))
        key &= valor.Substring(valor.Length - 6, 6)
        ' Obtenemos el valor hexadecimal
        valor = Hex(valorBase + (98 * 12500))
        ' Obtenemos el valor de clave
        key &= "-" & valor.Substring(0, 6)
        ' Obtenemos el valor hexadecimal
        valor = Hex(valorBase + (77 * 15000))
        ' Obtenemos el valor de clave
        key &= "-" & valor.Substring(valor.Length - 6, 6)
        ' Obtenemos el valor hexadecimal
        valor = Hex(valorBase + (121 * 17500))
        ' Obtenemos el valor de clave
        key &= "-" & valor.Substring(0, 6)
        ' Obtenemos el valor hexadecimal
        Return key


        valor = Hex(valorBase + (55 * 20000))
        ' Obtenemos el valor de clave
        key &= "-" & valor.Substring(valor.Length - 6, 6)
        ' Obtenemos el valor hexadecimal
        valor = Hex(valorBase + (134 * 22500))
        ' Obtenemos el valor de clave
        key &= "-" & valor.Substring(0, 6)
        ' Obtenemos el valor hexadecimal
        valor = Hex(valorBase + (63 * 25000))
        ' Obtenemos el valor de clave
        key &= "-" & valor.Substring(valor.Length - 6, 6)
        ' Obtenemos el valor hexadecimal
        valor = Hex(valorBase + (117 * 27500))
        ' Obtenemos el valor de clave
        key &= "-" & valor.Substring(0, 6)
        ' Devolvemos el valor final (xxxxxx-xxxxxx-xxxxxx-xxxxxx-xxxxxx-xxxxxx-xxxxxx-xxxxxx)
        Return key
    End Function

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Dim _Fecha As String = Format(DtpFechaExpiracion.Value, "yyyyMMdd")

        Dim _Llave1 = Replace(Txt_Llave1.Text, "'", "''")
        Dim _Llave2 = Replace(Txt_Llave2.Text, "'", "''")
        Dim _Llave3 = Replace(Txt_Llave3.Text, "'", "''")
        Dim _Llave4 = Replace(Txt_Llave4.Text, "'", "''")

        Dim _Rut = TxtRut.Text
        Dim _Fecha_caduca As Date = DtpFechaExpiracion.Value
        Dim _Cant_licencias = TxtCant_licencias.Text

        Dim _LLaves = Fx_Genera_Licencia_BakApp(_Rut, _Fecha_caduca, _Cant_licencias, "b4s1ng4")

        Dim _Llave1_R = _LLaves(0) 'Rut
        Dim _Llave2_R = _LLaves(1) 'Fecha
        Dim _Llave3_R = _LLaves(2) 'Cantidad
        Dim _Llave4_R = _LLaves(3) '= Encripta_md5(_Llave1 & _Llave2 & _Llave3)

        If _Llave1 = _Llave1_R And _Llave2 = _Llave2_R And _Llave3 = _Llave3_R And _Llave4 = _Llave4_R Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Licencia" & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Licencia (Rut,Razon,NombreCorto,Direccion,Giro,Ciudad,Pais,Telefonos," &
                           "Fecha_caduca,Cant_licencias,Llave1,Llave2,Llave3,Llave4,Libre) Values " & vbCrLf &
                           "('" & TxtRut.Text & "','" & TxtRazonSocial.Text & "','" & TxtNombreCorto.Text &
                           "','" & TxtDireccion.Text & "','" & TxtGiro.Text & "','" & TxtCiudad.Text &
                           "','" & TxtPais.Text & "','" & TxtTelefonos.Text &
                           "','" & Format(DtpFechaExpiracion.Value, "yyyyMMdd") & "'," & TxtCant_licencias.Text &
                           ",'" & Txt_Llave1.Text & "','" & Txt_Llave2.Text &
                           "','" & Txt_Llave3.Text & "','" & Txt_Llave4.Text & "',0)"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                MessageBoxEx.Show(Me, "Estaciones: " & TxtCant_licencias.Text & vbCrLf & vbCrLf &
                            "Valida hasta el " & FormatDateTime(DtpFechaExpiracion.Value, DateFormat.LongDate) & vbCrLf & vbCrLf &
                            "Días que faltan para que expire: " & FormatNumber(_DiasExpira, 0),
                            "Licencia asignada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            End If
        Else
            MessageBoxEx.Show(Me, "Licencia no corresponde", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Imagen_LLave_1.Image = ImageList1.Images.Item(2)
            Imagen_LLave_2.Image = ImageList1.Images.Item(2)
            Imagen_LLave_3.Image = ImageList1.Images.Item(2)
            Imagen_LLave_4.Image = ImageList1.Images.Item(2)
        End If


    End Sub

    Private Sub Frm_Licencia_Empresa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub Txt_Llave1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Llave1.TextChanged
        Dim _Llave1 = Encripta_md5(Trim(TxtRut.Text) & "b4s1ng4")

        If _Llave1 = Txt_Llave1.Text Then
            Imagen_LLave_1.Image = ImageList1.Images.Item(0)
        Else
            Imagen_LLave_1.Image = ImageList1.Images.Item(1)
        End If
    End Sub

    Private Sub Txt_Llave2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Llave2.TextChanged

        Dim _Llave2 = Encripta_md5(Format(DtpFechaExpiracion.Value, "yyyyMMdd"))

        If _Llave2 = Txt_Llave2.Text Then
            Imagen_LLave_2.Image = ImageList1.Images.Item(0)
        Else
            Imagen_LLave_2.Image = ImageList1.Images.Item(1)
        End If
    End Sub

    Private Sub Txt_Llave3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Llave3.TextChanged

        Dim _Llave3 = Encripta_md5(TxtCant_licencias.Text & "b4s1ng4")

        If _Llave3 = Txt_Llave3.Text Then
            Imagen_LLave_3.Image = ImageList1.Images.Item(0)
        Else
            Imagen_LLave_3.Image = ImageList1.Images.Item(1)
        End If
    End Sub

    Private Sub Txt_Llave4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Llave4.TextChanged

        Dim _Llave4 = Encripta_md5(Txt_Llave1.Text & Txt_Llave2.Text & Txt_Llave3.Text & "b4s1ng4")

        If _Llave4 = Txt_Llave4.Text Then
            Imagen_LLave_4.Image = ImageList1.Images.Item(0)
        Else
            Imagen_LLave_4.Image = ImageList1.Images.Item(1)
        End If

    End Sub
End Class
