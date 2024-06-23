Imports DevComponents.DotNetBar
Public Class Frm_Pagos_CtasEntidades_Expor_Banco_ImpExcel

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Modp = "$"
    Dim _Timodp = "N"
    Dim _Tamodp = 1

    Dim _Aceptar As Boolean

    Dim _Tbl_Resultado As DataTable

    Dim _Limpiar As Boolean
    Dim _Cancelar As Boolean
    Dim _Hay_Problemas As Boolean

    Public Property Tbl_Resultado As DataTable
        Get
            Return _Tbl_Resultado
        End Get
        Set(value As DataTable)
            _Tbl_Resultado = value
        End Set
    End Property

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "SELECT TOP 1 IDMAEDPCE,EMPRESA,SUREDP,CJREDP,TIDP,NUDP,ENDP,EMDP,Cast('' As Varchar(50)) As RAZON,SUEMDP,CUDP,NUCUDP,FEEMDP,FEVEDP,MODP," & vbCrLf &
                       "TIMODP,TAMODP,VADP,VAABDP,VAASDP,VAVUDP,ESPGDP,REFANTI,KOTU,NUTRANSMI,DOCUENANTI,KOFUDP,KOTNDP,SUTNDP,ESASDP,ESPGDP,CUOTAS," &
                       "CAST(0 AS INT) AS IDMAEEDO,CAST(0 AS FLOAT) AS SALDO,Cast(0 As Float) As LEY20956" & vbCrLf &
                       "FROM MAEDPCE WITH ( NOLOCK ) " & vbCrLf &
                       "WHERE 1 = 0"

        _Tbl_Resultado = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Buscar_Archivo.ForeColor = Color.White
            Btn_Archivo_Ayuda_Excel.ForeColor = Color.White
            Btn_Cancelar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Pagos_CtasEntidades_Expor_Banco_ImpExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function Fx_Nueva_Linea_De_Pago(ByVal _Tbl As DataTable) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow

        Dim _FechaDelServidor As DateTime = FechaDelServidor()

        With NewFila

            .Item("IDMAEDPCE") = 0
            .Item("EMPRESA") = ModEmpresa
            .Item("SUREDP") = ModSucursal
            .Item("CJREDP") = ModCaja

            .Item("TIDP") = String.Empty
            .Item("NUDP") = String.Empty

            .Item("ENDP") = String.Empty
            .Item("EMDP") = String.Empty   ' CODIGO EMISOR DE DOCUMENTO, BANCO, TIPO TARJETA, ETC.
            .Item("SUEMDP") = String.Empty ' ??
            .Item("CUDP") = String.Empty   ' NRO CTA. CTE.
            .Item("NUCUDP") = String.Empty ' NRO DEL CHEQUE
            .Item("FEEMDP") = _FechaDelServidor
            .Item("FEVEDP") = _FechaDelServidor

            .Item("MODP") = _Modp
            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp

            .Item("VADP") = 0
            .Item("VAABDP") = 0
            .Item("VAASDP") = 0
            .Item("VAVUDP") = 0
            .Item("SALDO") = 0
            .Item("ESPGDP") = String.Empty
            .Item("REFANTI") = String.Empty
            .Item("KOTU") = 1
            .Item("KOFUDP") = FUNCIONARIO
            .Item("KOTNDP") = RutEmpresa
            .Item("SUTNDP") = ModCaja

            .Item("NUTRANSMI") = ""
            .Item("DOCUENANTI") = ""

            .Item("ESASDP") = "P" ' ESTADO ASIGNACION DEL PAGO A = ASIGNADO A UN DOCUMENTO, P = NO ASIGNADO O PARCIALMENTE ASIGNADO, ES DECIR, 
            .Item("ESPGDP") = ""
            .Item("CUOTAS") = 0

        End With

        Return NewFila

    End Function

    Sub Sb_Habilitar_Deshabilitar_Comandos(ByVal _Habilitar As Boolean,
                                           ByVal _Habilitar_Cancelar As Boolean)

        _Cancelar = False

        Chk_Primera_Fila_Es_encabezado.Enabled = _Habilitar

        Btn_Buscar_Archivo.Enabled = _Habilitar
        Btn_Archivo_Ayuda_Excel.Enabled = _Habilitar

        Me.ControlBox = _Habilitar

        Circular_Progres_Porc.ProgressColor = Color.SteelBlue
        Circular_Progres_Val.ProgressColor = Color.SteelBlue
        Circular_Progres_Porc.Maximum = 100

        Circular_Progres_Porc.Value = 0
        Circular_Progres_Val.Value = 0

        Btn_Cancelar.Visible = _Habilitar_Cancelar
        Lbl_Procesando.Visible = _Habilitar_Cancelar

        Me.Refresh()

    End Sub

    Private Sub Btn_Buscar_Archivo_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Archivo.Click

        Sb_Importar_Archivo()

    End Sub

    Sub Sb_Importar_Archivo()

        Dim _Nombre_Archivo As String
        Dim _Ubic_Archivo As String

        Dim _OpenFileDialog As New OpenFileDialog

        With _OpenFileDialog

            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty

            If .ShowDialog(Me) = DialogResult.OK Then

                _Nombre_Archivo = .SafeFileName
                _Ubic_Archivo = .FileName
                Txt_Nombre_Archivo.Text = _Ubic_Archivo

            Else

                Beep()
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return

            End If

        End With

#Region "VARIABLES"

        Dim _Idmaedpce = 0
        Dim _Empresa = ModEmpresa
        Dim _Suredp = ModSucursal
        Dim _Cjredp = ModCaja

        Dim _Tidp = String.Empty
        Dim _Nudp = String.Empty

        Dim _Endp = String.Empty
        Dim _Emdp = String.Empty
        Dim _Suemdp = String.Empty
        Dim _Cudp = String.Empty
        Dim _Nucudp = String.Empty
        Dim _Feemdp = FechaDelServidor()
        Dim _Fevedp = _Feemdp

        Dim _Modp = "$"
        Dim _Timodp = "N"
        Dim _Tamodp = 1

        Dim _Vadp = 0
        Dim _Vaabdp = 0
        Dim _Vaasdp = 0
        Dim _Vavudp = 0
        Dim _Saldo = 0
        Dim _Espgdp = String.Empty
        Dim _Refanti = String.Empty
        Dim _Kotu = 1
        Dim _Kofudp = FUNCIONARIO
        Dim _Kotndp = RutEmpresa
        Dim _Sutndp = ModCaja

        Dim _Nutransmi = String.Empty
        Dim _Docuenanti = String.Empty

        Dim _Esasdp = "P"
        Dim _Cuotas = 0

#End Region

        Dim _Error As String
        Dim Problemas As Integer
        Dim SinProbremas As Integer

        Dim _ImpEx As New Class_Importar_Excel
        Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")
        Dim _Arreglo = _ImpEx.Importar_Excel_Array(_Ubic_Archivo, _Extencion, 0)
        Dim _Filas = _Arreglo.GetUpperBound(0)
        Dim _RegInsert As Long = 0

        Sb_Habilitar_Deshabilitar_Comandos(False, True)
        Circular_Progres_Val.Maximum = _Filas

        Dim _Contador As Integer = 0

        Dim _Desde = 0

        If Chk_Primera_Fila_Es_encabezado.Checked Then
            _Desde = 1
        End If

        For i = _Desde To _Filas

            System.Windows.Forms.Application.DoEvents()

            Try

                _Tidp = NuloPorNro(_Arreglo(i, 0), "")
                _Endp = NuloPorNro(_Arreglo(i, 1), "")
                _Emdp = NuloPorNro(_Arreglo(i, 2), "")
                _Suemdp = NuloPorNro(_Arreglo(i, 3), "")
                _Cudp = NuloPorNro(_Arreglo(i, 4), "")
                _Nucudp = NuloPorNro(_Arreglo(i, 5), "")
                _Vadp = NuloPorNro(_Arreglo(i, 6), 0)
                _Feemdp = NuloPorNro(_Arreglo(i, 7), #01-01-1900#)
                _Fevedp = NuloPorNro(_Arreglo(i, 8), #01-01-1900#)
                _Refanti = NuloPorNro(_Arreglo(i, 9), "")


                _Error = String.Empty

            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                Dim _Row_NewLineas As DataRow = Fx_Nueva_Linea_De_Pago(_Tbl_Resultado)

                With _Row_NewLineas

                    .Item("TIDP") = _Tidp
                    .Item("NUDP") = _Nudp
                    .Item("ENDP") = _Endp
                    .Item("EMDP") = _Emdp
                    .Item("SUEMDP") = _Suemdp
                    .Item("CUDP") = _Cudp
                    .Item("NUCUDP") = _Nucudp
                    .Item("VADP") = _Vadp
                    .Item("FEEMDP") = _Feemdp
                    .Item("FEVEDP") = _Fevedp
                    .Item("REFANTI") = _Refanti

                End With

                _Tbl_Resultado.Rows.Add(_Row_NewLineas)

            Else

                Problemas += 1

            End If

            If CBool(Problemas) Then
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

            Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & SinProbremas &
                                  ", Problemas: " & Problemas

        Next


        Try

            If _Cancelar Then

                _Limpiar = True
                MessageBoxEx.Show(Me, "Acción cancelada", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            _Hay_Problemas = CBool(Problemas)

            If _Hay_Problemas Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(Problemas)))

                If Problemas = 1 Then
                    _Leyend = "Existe " & Problemas & " línea con problema en el archivo de lectura"
                Else
                    _Leyend = "Existen " & Problemas & " líneas con problemas en el archivo de lectura"
                End If

                _Limpiar = True

                MessageBoxEx.Show(Me, _Leyend & vbCrLf &
                                  "a continuación se mostrar una lista con los errores",
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Else

                _Aceptar = True
                Me.Close()

            End If

        Catch ex As Exception

        Finally
            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
        End Try

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Btn_Archivo_Ayuda_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Archivo_Ayuda_Excel.Click

        Consulta_sql = "Select '3 caracteres' As TIDP,'Max 13 Caracteres' As ENDP,'Max 13 Caracteres' As EMDP,'Max 3 Caracteres' As SUEMDP," &
                       "'Max 16 Caracteres' As CUDP,'Max 8 Caracteres' As NUCUDP,'Valor númerico' As VADP,Getdate() As FEEMDP,Getdate() As FEVEDP," &
                       "'Max 80 Caracteres' As REFANTI"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Levantamiento_Pagos")

    End Sub

End Class
