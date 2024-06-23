Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports System.Text
Imports System.Security.Cryptography
'Imports Lib_Bakapp_VarClassFunc


Public Class Clase_Solicita_Producto_Bodega

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo, _Descripcion As String

    Dim _RowProducto As DataRow

    Dim _Solicitado As Boolean

    Public ReadOnly Property Pro_Solicitado() As Boolean
        Get
            Return _Solicitado
        End Get
    End Property


    Sub Sb_Solicitar_Producto(ByVal _Formulario As Form, _
                              ByVal _Codigo As String, _
                              ByVal _Funcionario As String, _
                              ByVal _Empresa As String, _
                              ByVal _Sucursal As String, _
                              ByVal _Bodega As String, _
                              ByVal _Ubicacion As String)

        Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Descripcion = _RowProducto.Item("NOKOPR")


        If Fx_Tiene_Permiso(_Formulario, "Bkp00022") Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_SolBodega" & vbCrLf &
                           "Where Codigo = '" & _Codigo & "' And Funcionario = '" & _Funcionario & "'" & vbCrLf &
                           "And Estado IN ('SOL','ENT')"

            Dim _TblProdSol As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


            If Not CBool(_TblProdSol.Rows.Count) Then

                Dim _Ult_SOC As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SolBodega")

                Dim _Uc As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_SolBodega", "MAX(CodSolicitud)",
                                    "CodSolicitud like '" & _Funcionario & "%'")

                _Ult_SOC = Val(Mid(_Uc, 4, 7))

                If String.IsNullOrEmpty(Trim(_Ult_SOC)) Then
                    _Ult_SOC = 1
                Else
                    _Ult_SOC += 1
                End If
                Dim _NroSolicitud As String = _Funcionario & numero_(Val(_Ult_SOC), 7)

                Dim _CodSolicitud = _NroSolicitud

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_SolBodega " &
                "(CodSolicitud,Funcionario,Codigo,Descripcion,Empresa,Sucursal,Bodega,Ubicacion,FechaHora_Solicita,Estado)" & vbCrLf &
                "Values ('" & _CodSolicitud & "','" & _Funcionario & "','" & _Codigo & "','" & _Descripcion & "','" & _Empresa &
                "','" & _Sucursal & "','" & _Bodega & "','" & _Ubicacion &
                "',GetDate(),'SOL')"
                _Sql.Ej_consulta_IDU(Consulta_sql)


                MessageBoxEx.Show(_Formulario, "Producto solicitado a bodega", "Solicitar",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Solicitado = True
            Else

                Dim _FechaSol = FormatDateTime(_TblProdSol.Rows(0).Item("FechaHora_Solicita"), DateFormat.LongDate) ', "dd/MM/yyyy")
                Dim _HoraSol = Format(_TblProdSol.Rows(0).Item("FechaHora_Solicita"), "HH:MM:ss")

                MessageBoxEx.Show(_Formulario, "Este producto ya fue solicitado por usted" & vbCrLf &
                                  "Fecha: " & _FechaSol & " a las " & _HoraSol,
                                  "No puede pedir 2 veces el mismo producto", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        End If


    End Sub


    Function Fx_Tiene_Prod_Solicitados_Bodega(ByVal _Formulario As Form, _
                                              ByVal _Funcionario As String, _
                                              Optional ByVal _Mostrar_mensaje As Boolean = True, _
                                              Optional ByVal _SoloCierra As Boolean = False) As Boolean


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_SolBodega" & vbCrLf & _
                       "Where Funcionario = '" & _Funcionario & "'" & vbCrLf & _
                       "And Estado IN ('SOL','ENT')"

        Dim _TblProdSol As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblProdSol.Rows.Count) Then

            If _Mostrar_mensaje Then

                If MessageBoxEx.Show(_Formulario, "NO PUEDE GENERAR VENTAS CON PRODUCTOS PENDIENTES EN SOLICITUD A BODEGA" & vbCrLf & vbCrLf &
                                     "¿Desea ver el detalle de los productos solicitados?",
                                     "Productos pendientes", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Stop) = DialogResult.Yes Then

                    Dim Fm As New Frm_Sol_Pro_Bodega_ListaPendientes
                    Fm.Pro_SoloCierra = _SoloCierra
                    Fm.Pro_Condicion = "And (Funcionario ='" & _Funcionario & "'" & vbCrLf & "And Estado In ('SOL','ENT'))"
                    If _SoloCierra Then Fm.BtnExportarExcel.Visible = False
                    Fm.ShowDialog(_Formulario)
                    Fm.Dispose()

                End If

            Else

                Dim Fm As New Frm_Sol_Pro_Bodega_ListaPendientes
                Fm.Pro_SoloCierra = _SoloCierra
                Fm.Pro_Condicion = "And (Funcionario ='" & _Funcionario & "'" & vbCrLf &
                                "And Estado In ('SOL','ENT'))"
                If _SoloCierra Then Fm.BtnExportarExcel.Visible = False
                Fm.ShowDialog(_Formulario)
                Fm.Dispose()

            End If

            Return True

        End If

    End Function


    Function Fx_Encriptar(ByVal Input As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("qualityi") 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function

    Function Fx_Desencriptar(ByVal Input As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("qualityi") 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Convert.FromBase64String(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function






End Class
