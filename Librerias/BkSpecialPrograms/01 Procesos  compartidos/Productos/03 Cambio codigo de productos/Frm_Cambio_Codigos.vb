'Imports Lib_Bakapp_VarClassFunc
Imports System.Data.SqlClient
Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_Cambio_Codigos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cancelar As Boolean


#Region "Procedimientos"

    Function Fx_Existe_Producto(ByVal _Formulario As Form,
                                ByVal _Codigo As String,
                                ByVal _Mostrar_mensaje As Boolean) As Boolean

        Dim _TblProducto As DataTable

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _TblProducto = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblProducto.Rows.Count) Then
            If _Mostrar_mensaje Then
                MessageBoxEx.Show(_Formulario, "¡CODIGO YA EXISTE!" & vbCrLf &
                                  "Producto: " & Trim(_Codigo) & ", " & _TblProducto.Rows(0).Item("NOKOPR"),
                                  "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return True
        Else
            Return False
        End If

    End Function

    Function Fx_Cambiar_Codigo(_CodigoNew As String,
                               _CodigoOld As String,
                               _CambiarCodTecnico As Boolean,
                               _Cambiar_BakApp As Boolean,
                               _Responzable As String,
                               _Fila_InfoProducto As DataRow,
                               _CodigoTecnicoNew As String) As Boolean

        Dim _Descripcion As String = _Fila_InfoProducto.Item("NOKOPR")
        Dim _Rtu As String = De_Num_a_Tx_01(_Fila_InfoProducto.Item("RLUD"), False, 5)
        Dim _Ud01 As String = _Fila_InfoProducto.Item("UD01PR")
        Dim _Ud02 As String = _Fila_InfoProducto.Item("UD02PR")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Cn As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            SQL_ServerClass.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            If _CambiarCodTecnico = True Then

                Consulta_sql = "UPDATE MAEPR SET KOPRTE='" & _CodigoTecnicoNew & "' WHERE KOPR='" & _CodigoOld & "'" & vbCrLf &
                               "UPDATE TABPRE SET KOPRTE='" & _CodigoTecnicoNew & "' WHERE KOPR='" & _CodigoOld & "'"
                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Consulta_sql = My.Resources.Recursos_cambio_productos.SQLQuery_Cambiar_Codigo_Productos_RD
            Consulta_sql = Replace(Consulta_sql, "#CodigoNew#", _CodigoNew)
            Consulta_sql = Replace(Consulta_sql, "#CodigoOld#", _CodigoOld)
            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            If _Cambiar_BakApp Then

                Consulta_sql = My.Resources.Recursos_cambio_productos.SQLQuery_Cambiar_Codigo_Productos_BakApp
                Consulta_sql = Replace(Consulta_sql, "#CodigoNew#", _CodigoNew)
                Consulta_sql = Replace(Consulta_sql, "#CodigoOld#", _CodigoOld)
                Consulta_sql = Replace(Consulta_sql, "#Descripcion#", _Descripcion)
                Consulta_sql = Replace(Consulta_sql, "#Base#", _Global_BaseBk)

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_sql = String.Empty

                'For Each _Fila As DataRow In _Tbl_Informes_Ventas_Bakapp.Rows

                '    Dim _Tabla As String = _Fila.Item("Tabla")
                '    Consulta_sql += "Update " & _Tabla & " Set KOPRCT = '" & _CodigoNew & "' Where KOPRCT = '" & _CodigoOld & "'" & vbCrLf

                'Next

                Consulta_sql += "Update Zw_Informe_Venta Set KOPRCT = '" & _CodigoNew & "' Where KOPRCT = '" & _CodigoOld & "'" & vbCrLf

                If Not String.IsNullOrEmpty(Consulta_sql) Then

                    Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

            End If

            Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_UnificadosHitory (CodNew,CodOld,DescripcionOld,Ud1Old,Ud2Old," &
                           "RtuOld,Responzable,Fecha,Accion) VALUES " & vbCrLf &
                           "('" & _CodigoNew & "','" & _CodigoOld & "','" & _Descripcion & "','" & _Ud01 &
                           "','" & _Ud02 & "'," & _Rtu & ",'" & _Responzable & "',GetDate(),'Cambio de código')"
            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(_Cn)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            myTrans.Rollback()
            MessageBoxEx.Show(Me, "Transacción desecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(_Cn)
        End Try

    End Function

    Function Fx_Cambiar_Codigo_EmpExterna(_CodigoNew As String,
                                          _CodigoOld As String,
                                          _CambiarCodTecnico As Boolean,
                                          _Cambiar_BakApp As Boolean,
                                          _Responzable As String,
                                          _Fila_InfoProducto As DataRow,
                                          _CodigoTecnicoNew As String) As Cl_CambioCodigo

        Dim _Cl_CambioCodigo As New Cl_CambioCodigo

        Dim _Descripcion As String = _Fila_InfoProducto.Item("NOKOPR")
        Dim _Rtu As String = De_Num_a_Tx_01(_Fila_InfoProducto.Item("RLUD"), False, 5)
        Dim _Ud01 As String = _Fila_InfoProducto.Item("UD01PR")
        Dim _Ud02 As String = _Fila_InfoProducto.Item("UD02PR")

        'Dim myTrans As SqlClient.SqlTransaction
        'Dim Comando As SqlClient.SqlCommand

        'Dim _Cn As New SqlConnection
        'Dim SQL_ServerClass As New Class_SQL(_Cadena_ConexionSQL_Server_Ext)

        Dim _SqlQuery As String = String.Empty

        Try

            'SQL_ServerClass.Sb_Abrir_Conexion(_Cn)
            'myTrans = _Cn.BeginTransaction()

            If _CambiarCodTecnico = True Then

                _SqlQuery += "UPDATE MAEPR SET KOPRTE='" & _CodigoTecnicoNew & "' WHERE KOPR='" & _CodigoOld & "'" & vbCrLf &
                             "UPDATE TABPRE SET KOPRTE='" & _CodigoTecnicoNew & "' WHERE KOPR='" & _CodigoOld & "'" & vbCrLf
                'Comando = New SqlClient.SqlCommand(_SqlQuery, _Cn)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()

            End If

            _SqlQuery += My.Resources.Recursos_cambio_productos.SQLQuery_Cambiar_Codigo_Productos_RD
            _SqlQuery = Replace(_SqlQuery, "#CodigoNew#", _CodigoNew)
            _SqlQuery = Replace(_SqlQuery, "#CodigoOld#", _CodigoOld)
            'Comando = New SqlClient.SqlCommand(_SqlQuery, _Cn)
            'Comando.Transaction = myTrans
            'Comando.ExecuteNonQuery()

            If _Cambiar_BakApp Then

                Dim _SqlQueryBakapp As String

                _SqlQueryBakapp = My.Resources.Recursos_cambio_productos.SQLQuery_Cambiar_Codigo_Productos_BakApp

                _SqlQueryBakapp = Replace(_SqlQueryBakapp, "Declare @CodigoNew Char(13) = '#CodigoNew#',", "")
                _SqlQueryBakapp = Replace(_SqlQueryBakapp, "@CodigoOld Char(13) = '#CodigoOld#',", "")
                _SqlQueryBakapp = Replace(_SqlQueryBakapp, "@Descripcion Varchar(50) = '#Descripcion#'", "Declare @Descripcion Varchar(50) = '#Descripcion#'")

                _SqlQueryBakapp = Replace(_SqlQueryBakapp, "#CodigoNew#", _CodigoNew)
                _SqlQueryBakapp = Replace(_SqlQueryBakapp, "#CodigoOld#", _CodigoOld)
                _SqlQueryBakapp = Replace(_SqlQueryBakapp, "#Descripcion#", _Descripcion)
                _SqlQueryBakapp = Replace(_SqlQueryBakapp, "#Base#", _Global_BaseBk)


                _SqlQuery += _SqlQueryBakapp

                'Comando = New SqlClient.SqlCommand(_SqlQuery, _Cn)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()

                _SqlQuery += "Update Zw_Informe_Venta Set KOPRCT = '" & _CodigoNew & "' Where KOPRCT = '" & _CodigoOld & "'" & vbCrLf

                'If Not String.IsNullOrEmpty(_SqlQuery) Then

                '    Comando = New SqlClient.SqlCommand(_SqlQuery, _Cn)
                '    Comando.Transaction = myTrans
                '    Comando.ExecuteNonQuery()

                'End If

            End If

            _SqlQuery += "INSERT INTO " & _Global_BaseBk & "Zw_UnificadosHitory (CodNew,CodOld,DescripcionOld,Ud1Old,Ud2Old," &
                           "RtuOld,Responzable,Fecha,Accion) VALUES " & vbCrLf &
                           "('" & _CodigoNew & "','" & _CodigoOld & "','" & _Descripcion & "','" & _Ud01 &
                           "','" & _Ud02 & "'," & _Rtu & ",'" & _Responzable & "',GetDate(),'Cambio de código')"
            'Comando = New SqlClient.SqlCommand(_SqlQuery, _Cn)
            'Comando.Transaction = myTrans
            'Comando.ExecuteNonQuery()

            'myTrans.Commit()
            'SQL_ServerClass.Sb_Cerrar_Conexion(_Cn)

            'Return True

            _Cl_CambioCodigo.EsCorrecto = True
            _Cl_CambioCodigo.SqlQuery = _SqlQuery

        Catch ex As Exception
            _Cl_CambioCodigo.EsCorrecto = False
            _Cl_CambioCodigo.SqlQuery = String.Empty
            _Cl_CambioCodigo.Mensaje = ex.Message
        End Try

        Return _Cl_CambioCodigo

    End Function

    Sub Sb_Cambiar_productos_masivamente(ByVal _Lista_Productos_Arr As Object)

        Dim Filas = _Lista_Productos_Arr.GetUpperBound(0)
        Dim RegInsert As Long = 0

        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = Filas
        Dim Contador As Integer = 0

        Consulta_sql = String.Empty

        Sb_AddToLog("Iniciando proceso paso 1 de 2", "Revisando lista de productos -----------------------------------------", TxtLog, True)

        Dim _SQl_ As String = String.Empty

        Dim _Filas_Buenas = 0
        Dim _Filas_Malas = 0

        For i = 1 To Filas

            System.Windows.Forms.Application.DoEvents()
            Dim _Mala As Boolean = False

            Dim _CodigoNew = _Lista_Productos_Arr(i, 0)
            Dim _CodigoOld = _Lista_Productos_Arr(i, 1)
            Dim _CodigoTecnico = _Lista_Productos_Arr(i, 2)

            If Not Fx_Existe_Producto(Me, _CodigoOld, False) Then
                _Mala = True
                Sb_AddToLog("Fila : " & i & ",Código: " & _CodigoOld,
                            "Código a reemplazar no existe", TxtLog, False)
            End If

            If Fx_Existe_Producto(Me, _CodigoNew, False) Then
                _Mala = True
                Sb_AddToLog("Fila : " & i & ",Código: " & _CodigoNew,
                            "Código nuevo ya existe", TxtLog, False)
            End If

            If ChkCambiarCodigoTecnico.Checked Then

                _CodigoTecnico = NuloPorNro(_CodigoTecnico, "")

                Dim _Existe_PrNew = CBool(_Sql.Fx_Cuenta_Registros("MAEPR",
                                 "KOPR <> '" & _CodigoTecnico & "' And (KOPRTE = '" & _CodigoTecnico & "' Or KOPR = '" & _CodigoTecnico & "')"))

                If _Existe_PrNew Then
                    _Mala = True
                    Sb_AddToLog("Fila : " & i & ",Código : " & _CodigoNew,
                            "Código técnico ya existe o bien existe como código principal de otro producto", TxtLog, False)

                Else
                    If String.IsNullOrEmpty(_CodigoTecnico) Then
                        _Mala = True
                        Sb_AddToLog("Fila : " & i & ",Código : " & _CodigoNew,
                                "Código técnico no puede estar vacío", TxtLog, False)
                    End If
                End If



            End If

            If _Mala Then
                _Filas_Malas += 1
            Else
                _Filas_Buenas += 1
            End If


            Dim _Descripcion = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & _CodigoOld & "'", , , "NO EXISTE")

            LblEstado_1.Text = "Procesando " & FormatNumber(Contador, 0) & " de " & FormatNumber(Filas, 0) &
                               ", Filas buenas: " & FormatNumber(_Filas_Buenas) & ", Filas malas: " & FormatNumber(_Filas_Malas, 0)
            LblEstado_1.Text = "Producto " & FormatNumber(Contador, 0) & " de " & FormatNumber(Filas, 0) & ",Producto: " & _Descripcion

            Contador += 1
            Progreso_Porc.Value = ((Contador * 100) / Filas)
            Progreso_Cont.Value += 1

            If _Cancelar Then

                LblEstado_1.Text = "Proceso cancelado por el usuario"
                LblEstado_2.Text = String.Empty
                Sb_AddToLog("Proceso terminado", "-----------------------------------------", TxtLog, True)

                System.Windows.Forms.Application.DoEvents()

                Progreso_Cont.Value = 0
                Progreso_Porc.Value = 0

                Return
            End If



        Next

        LblEstado_1.Text = "Proceso terminado paso 1"
        LblEstado_2.Text = String.Empty
        Sb_AddToLog("Proceso terminado paso 1", "-----------------------------------------", TxtLog, True)

        System.Windows.Forms.Application.DoEvents()

        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0

        If CBool(_Filas_Malas) Then

            MessageBoxEx.Show(Me, "Existen " & _Filas_Malas & " filas con problemas" & vbCrLf &
                                 "a continuación la lista de ellas, pero el sistema igualmente continuara" & vbCrLf &
                                 "trabajando con las filas buenas " & _Filas_Buenas, "Problemas",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning)


            Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Cambio_codigos"

            If Not Directory.Exists(_Ruta) Then
                System.IO.Directory.CreateDirectory(_Ruta)
            End If

            CrearArchivoTxt(_Ruta & "\",
                            "Error_CambioCodigos.txt", TxtLog.Text, False)

            TxtLog.Text = String.Empty
            Process.Start("notepad.exe", _Ruta & "\Error_CambioCodigos.txt")

            MessageBoxEx.Show(Me, "Debe solucionar los problemas de la lista antes de seguir",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return

        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de cambiar los códigos?",
                                 "Cambiar códigos",
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then

            System.Windows.Forms.Application.DoEvents()
            Sb_AddToLog("Iniciando proceso paso 2 de 2", "Cambiar códigos -----------------------------------------", TxtLog, True)
            Sb_AddToLog("Paso 2", "Insertando información en la base de datos ...", TxtLog, False)



            Filas = _Lista_Productos_Arr.GetUpperBound(0)
            RegInsert = 0

            Progreso_Porc.Maximum = 100
            Barra_Progreso_.Maximum = 100
            Progreso_Cont.Maximum = Filas
            Contador = 0

            Consulta_sql = String.Empty

            Sb_AddToLog("Iniciando proceso paso 1 de 2", "Revisando lista de productos -----------------------------------------", TxtLog, True)


            For i = 1 To Filas

                System.Windows.Forms.Application.DoEvents()

                Dim _CodigoNew = _Lista_Productos_Arr(i, 0)
                Dim _CodigoOld = _Lista_Productos_Arr(i, 1)
                Dim _CodigoTecnico = _Lista_Productos_Arr(i, 2)

                If Not ChkCambiarCodigoTecnico.Checked Then
                    _CodigoTecnico = _CodigoNew
                End If

                Consulta_sql = "Select * From MAEPR Where KOPR = '" & _CodigoOld & "'"
                Dim _TblPro As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Fx_Cambiar_Codigo(_CodigoNew, _CodigoOld, ChkCambiarCodigoTecnico.Checked, True, FUNCIONARIO, _TblPro.Rows(0), _CodigoTecnico)

                Dim _Descripcion = _TblPro.Rows(0).Item("NOKOPR")

                LblEstado_1.Text = "Procesando " & Contador & " de " & Filas &
                                   ", Filas buenas: " & _Filas_Buenas & ", Filas malas: " & _Filas_Malas
                LblEstado_1.Text = "Producto " & FormatNumber(Contador, 0) & " de " & FormatNumber(Filas, 0) & ",Producto: " & _Descripcion

                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Filas)
                Barra_Progreso_.Value = Progreso_Porc.Value
                Progreso_Cont.Value += 1

            Next

            LblEstado_1.Text = "Proceso terminado paso 1"
            LblEstado_2.Text = String.Empty
            Sb_AddToLog("Proceso terminado paso 1", "-----------------------------------------", TxtLog, True)

            System.Windows.Forms.Application.DoEvents()

            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0
            Barra_Progreso_.Value = 0

        End If

    End Sub

#End Region

    Private Sub BtnListadoEjemplo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListadoEjemplo.Click

        Consulta_sql = "Select 'Caracter [13]' as 'Nuevo Código','Caracter [13]' as 'Código a reemplazar','Caracter [20]' as 'Código técnico (si es en blanco se deja el mismo código del producto)'"

        ExportarTabla_JetExcel(Consulta_sql, Me, "Ejemplo cambio codigos masivamente")

    End Sub

    Private Sub BtnBuscarArchivoLevantar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarArchivoLevantar.Click

        BtnCancelar.Enabled = True
        Btn_ImportarListado.Enabled = False
        Me.ControlBox = False

        Dim _OpenFile As New OpenFileDialog
        Dim _Lista_Productos_Arr

        With _OpenFile
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            '.ShowDialog(Me)
            Dim _Resultado = .ShowDialog(Me)
            Dim _Nombre_Archivo As String

            If _Resultado = Windows.Forms.DialogResult.OK Then
                _Nombre_Archivo = .SafeFileName
                _Nombre_Archivo = .FileName
            Else
                Return
            End If

            Dim _ImpEx As New Class_Importar_Excel
            Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")

            _Lista_Productos_Arr = _ImpEx.Importar_Excel_Array(_Nombre_Archivo, _Extencion, 0)

        End With


        If _Lista_Productos_Arr Is Nothing Then
            Return
        Else
            Bar2.Enabled = False
            Sb_Cambiar_productos_masivamente(_Lista_Productos_Arr)
            Bar2.Enabled = True
        End If

        BtnCancelar.Enabled = False
        Btn_ImportarListado.Enabled = True
        Me.ControlBox = True

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If MessageBoxEx.Show(Me, "¿Esta seguro de cancelar la acción?", "Cancelar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            _Cancelar = True
        End If
    End Sub

    Private Sub Frm_Cambio_Codigos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Class Cl_CambioCodigo
    Public Property EsCorrecto As Boolean
    Public Property Mensaje As String
    Public Property SqlQuery As String
End Class
