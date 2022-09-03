'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Imports System
Imports System.Text
Imports System.Windows
Imports System.IO

Public Class Frm_Cashdro_Presentacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tiempo As Integer
    Dim _Row_Estacion_CashDro As DataRow

    Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
    Dim _Post_Autoservicio, _Post_Integrado As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Btn_Opciones.Visible = False
        Btn_Habilitar_Opciones.Visible = False
        Btn_Volver_Ejecutar_CashDro.Visible = False
        Btn_Cerrar.Visible = False

    End Sub

    Private Sub Frm_Cashdro_Presentacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Estaciones_CashDro", "TJV_Emdp_Credito") Or
           Not _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Estaciones_CashDro", "TJV_Emdp_Debito") Then

            MessageBoxEx.Show(Me, "Faltan campos en la tabla (Zw_Estaciones_CashDro)" & vbCrLf &
                              "Informe al administrador del sistema", "Validación Versión Bakapp", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Me.Close()
            Exit Sub

        End If


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        Dim _Row_CashDro As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Post_Autoservicio = _Row_CashDro.Item("Post_Autoservicio")
        _Post_Integrado = _Row_CashDro.Item("Post_Integrado")

        Dim _TJV_Emdp_Credito = _Row_CashDro.Item("TJV_Emdp_Credito")
        Dim _TJV_Emdp_Debito = _Row_CashDro.Item("TJV_Emdp_Debito")

        Dim _Tjv_C As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABENDP", "KOENDP = '" & _TJV_Emdp_Credito & "' And TIDPEN = 'TJ'"))
        Dim _Tjv_D As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABENDP", "KOENDP = '" & _TJV_Emdp_Debito & "' And TIDPEN = 'TJ'"))

        If _Tjv_C And _Tjv_D Then

            Tiempo_Espera.Enabled = True

        Else

            MessageBoxEx.Show(Me, "FALTA CONFIGURAR LAS TARJETAS DE CREDITO Y DEBITO DE ESTA ESTACION" & vbCrLf & vbCrLf &
                              "De ir a la configuración de Cashdro" & vbCrLf & vbCrLf &
                              "-> CONFIGURACION LOCAL CAJERO AUTOMATICO" & vbCrLf &
                              "--> Código de banco para tarjeta de CREDITO" & vbCrLf &
                              "--> Código de banco para tarjeta de DEBITO",
                              "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Dim Fm As New Frm_Equipos_CashDro_Equipo(_NombreEquipo)
            Fm.ShowDialog(Me)
            Me.Close()
            Fm.Dispose()

        End If

    End Sub

    Private Sub Tiempo_Espera_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Espera.Tick

        If _Tiempo = 3 Then
            Tiempo_Espera.Stop()
            Dim _Volver_A_Cargar As Boolean

            _Tiempo = 0

            Btn_Opciones.Visible = False
            Btn_Habilitar_Opciones.Visible = False
            Btn_Volver_Ejecutar_CashDro.Visible = False
            Btn_Cerrar.Visible = False

            Dim _Fm As New Frm_Cashdro_Ingreso_Documento
            _Fm.ShowDialog(Me)
            _Volver_A_Cargar = _Fm.Pro_Volver_A_Cargar
            '_Fm.Dispose()

            Dim ProcesosLocales As Process() = Process.GetProcessesByName("BakApp_Demonio")
            ' Saber si existe mas de una aplicacion
            ' con el mismo nombre en ejecucion
            If ProcesosLocales.Length > 1 Then
                Demonio.Visible = True
            Else
                Demonio.Visible = False
            End If

            Dim _Cl_Pago_Cashdro As New Cl_Pago_Cashdro(_NombreEquipo)
            _Cl_Pago_Cashdro.Sb_Pagar_Pendientes_Efectivo(False)
            _Cl_Pago_Cashdro.Sb_Pagar_Pendientes_Nota_De_Credito()
            _Cl_Pago_Cashdro.Sb_Pagar_Pendientes_Tarjeta(False)
            _Cl_Pago_Cashdro.Sb_Pagar_Pendientes_Vuelto_Casdro()

            If _Volver_A_Cargar Then
                Tiempo_Espera.Start()
            Else
                Demonio.Visible = True
                Btn_Opciones.Visible = True
                Btn_Habilitar_Opciones.Visible = True
                Btn_Volver_Ejecutar_CashDro.Visible = True
                Btn_Cerrar.Visible = True
                Tiempo_Espera.Enabled = False
            End If

        End If

        _Tiempo += 1

    End Sub

    Private Sub Demonio_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Demonio.DoubleClick
        Return
        If Not Tiempo_Espera.Enabled Then

            Dim _Autorizado As Boolean

            Dim Fm_Pass As New Frm_Clave_Administrador(True)
            Fm_Pass.ShowDialog(Me)
            _Autorizado = Fm_Pass.Pro_Autorizado
            Fm_Pass.Dispose()

            If _Autorizado Then
                Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                Dim Fm As New Frm_Equipos_CashDro_Equipo(_NombreEquipo)
                Fm.ShowDialog(Me)

                If Fm.Pro_Grabar Then
                    Tiempo_Espera.Enabled = True
                    Tiempo_Espera.Start()
                End If
                Fm.Dispose()
            End If

        End If

    End Sub


    Sub Sb_Leer_Informe(ByVal _Texto As String, ByRef _Array() As String)

        Dim cont As Integer = 0
        Dim strAcum As String = String.Empty
        Dim Acum As String = String.Empty

        Dim _Tope = 40
        Dim _ContTope = 0

        Dim _Cont_Array = 0
        Dim _Encontro_Total As Boolean = False

        For cont = 1 To Len(_Texto)
            Acum &= Mid(_Texto, cont, 1)
            strAcum &= Asc(Mid(_Texto, cont, 1)) 'Hex(Asc(Mid(StrName, cont, 1)))
            Dim _CodAsc = Asc(Mid(_Texto, cont, 1))
            If _CodAsc = 0 Then

            End If


            If Not _Encontro_Total Then
                If Len(Acum) > 5 Then
                    Dim _Total = Acum.Substring(Len(Acum) - 5)
                    If _Total = "TOTAL" Then
                        Acum = String.Empty
                        _Encontro_Total = True
                    End If
                End If
            Else
                If _ContTope = _Tope Then
                    ReDim Preserve _Array(_Cont_Array)
                    _Array(_Cont_Array) = Acum
                    Acum += vbCrLf
                    _ContTope = 0
                    _Cont_Array += 1
                End If
                _ContTope += 1
            End If

        Next cont


    End Sub

    Function Fx_Traer_Cierre_Informe(ByVal _Texto As String) As String

        Dim cont As Integer = 0
        Dim _Acum As String = String.Empty

        Dim _Tope = 40
        Dim _ContTope = 1

        Dim _Encontro_Total As Boolean = False

        For cont = 1 To Len(_Texto)
            _Acum &= Mid(_Texto, cont, 1)

            If Not _Encontro_Total Then
                If Len(_Acum) > 5 Then
                    Dim _Total = _Acum.Substring(Len(_Acum) - 5)
                    If _Total = "TOTAL" Then
                        _Acum = String.Empty
                        _Encontro_Total = True
                    End If
                End If
            Else
                If _ContTope = _Tope Then
                    _Acum += ";"
                    _ContTope = 0
                End If
                _ContTope += 1
            End If

        Next cont

        Return _Acum

    End Function

    Private Sub Btn_Mnu_Cerrar_Terminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Cerrar_Terminal.Click

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_CashDro Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_Estacion_CashDro = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0", 0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Cerrar_Terminal, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Respuesta_Transbank As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status
        Dim _Error As Boolean = Fm.Pro_Erro_Conexion
        Dim _Puerto_Serial_Bloqueado As Boolean = Fm.Pro_Puerto_Bloqueado

        If _Puerto_Serial_Bloqueado Then
            MessageBoxEx.Show(Me, "Problema de conexión con puerto Serial (COM)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Error = True
        End If

        Fm.Dispose()

        If Not _Error Then

            Dim _Fecha_Cierre As Date = FechaDelServidor()

            If Not String.IsNullOrEmpty(_Respuesta_Transbank) Then

                Dim _IdCierre As Integer
                Dim _Respuesta_Arreglo = Split(_Respuesta_Transbank, "|")
                Dim _Voucher As String = _Respuesta_Arreglo(4)

                _Respuesta_Transbank = Replace(_Respuesta_Transbank, "'", "")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Cierre (NombreEquipo,Fecha_Hora_Cierre,Respuesta_Transbank,Detalle) Values" & Space(1) &
                               "('" & _NombreEquipo & "',Getdate(),'" & _Respuesta_Transbank & "','" & _Voucher & "')"

                If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _IdCierre) Then

                    Dim _Impresora_Predeterminada = _Row_Estacion_CashDro.Item("Impresora_Predeterminada")

                    MessageBoxEx.Show(Me, "Cierre generado correctamente", "Cierre Transbank",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim _Este_Nombre_Equipo = _Global_Row_EstacionBk.Item("NombreEquipo")

                    If _NombreEquipo <> _Este_Nombre_Equipo Then
                        _Impresora_Predeterminada = String.Empty
                    End If

                    Consulta_sql = "Declare @Fecha as date = '" & Format(_Fecha_Cierre, "yyyyMMdd") & "'" & vbCrLf &
                                   "Select Top 1 *" & vbCrLf &
                                   "From " & _Global_BaseBk & "Zw_CashDro_Transbank_Cierre" & vbCrLf &
                                   "Where NombreEquipo = '" & _NombreEquipo & "' And Fecha_Hora_Cierre >= @Fecha And Fecha_Hora_Cierre < DATEADD(dd,1,@Fecha)" & vbCrLf &
                                   "Order By Fecha_Hora_Cierre Desc"
                    Dim _Row_Cierre As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not IsNothing(_Row_Cierre) Then

                        Dim _Cl_Voucher As New Clas_Imprimir_Voucher
                        _Cl_Voucher.Pro_Impresora = _Impresora_Predeterminada
                        _Cl_Voucher.Fx_Imprimir_Voucher_Cierre(Me, _IdCierre)
                        _Impresora_Predeterminada = _Cl_Voucher.Pro_Impresora

                        Dim _Imp_Cierre As New Clas_Imprimir_Cierre(_NombreEquipo, _Fecha_Cierre)

                        If _Imp_Cierre.Pro_Tbl_Detalle_Terminal.Rows.Count Then
                            _Imp_Cierre.Fx_Imprimir_Archivo(Me, "Detalle Terminal " & FormatDateTime(_Fecha_Cierre, DateFormat.ShortDate),
                                                            _Impresora_Predeterminada, Clas_Imprimir_Cierre._Enum_Tipo_Impresion.Detalle_Terminal)
                        End If

                    End If

                End If

            End If
        Else
            MessageBoxEx.Show(Me, "No es posible tener conexión con la maquina Transbank", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Mnu_Imprimir_Cierres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Imprimir_Cierres.Click

        Dim Fm As New Frm_Imprimir_Cierres_Transbank(_NombreEquipo, Frm_Imprimir_Cierres_Transbank._Enum_Tipo_Cierre.Transbank)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Configurar_Terminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Configurar_Terminal.Click

        Dim _Validar As Boolean

        Dim Fmp As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Cdro0002", True, False)
        Fmp.Pro_Cerrar_Automaticamente = True
        Fmp.ShowDialog(Me)
        _Validar = Fmp.Pro_Permiso_Aceptado
        Fmp.Dispose()

        If _Validar Then

            Dim Fm As New Frm_Equipos_CashDro_Equipo(_NombreEquipo)
            Fm.ShowDialog(Me)
            If Fm.Pro_Grabar Then
                Me.Close()
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Opciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Opciones.Click
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Private Sub Btn_Cambiar_Tipo_Estacion_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Tipo_Estacion.Click

        Dim Fm As New Frm_RegistrarEquipo_Listado(True, Frm_RegistrarEquipo_Listado.Enum_Tipo_Estacion.Normal)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Dim _TipoEstacion = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_EstacionesBkp", "TipoEstacion",
                                              "NombreEquipo ='" & _Global_Row_EstacionBk.Item("NombreEquipo") & "'")

        If _TipoEstacion <> _Global_Row_EstacionBk.Item("TipoEstacion") Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Volver_Ejecutar_CashDro_Click(sender As Object, e As EventArgs) Handles Btn_Volver_Ejecutar_CashDro.Click
        _Tiempo = 3
        Tiempo_Espera_Tick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Habilitar_Opciones_Click(sender As Object, e As EventArgs) Handles Btn_Habilitar_Opciones.Click

        Dim _Validar As Boolean

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Cdro0003", True, False)
        Fm.Pro_Cerrar_Automaticamente = True
        Fm.ShowDialog(Me)
        _Validar = Fm.Pro_Permiso_Aceptado
        Fm.Dispose()

        Btn_Habilitar_Opciones.Enabled = Not _Validar
        Btn_Opciones.Enabled = _Validar

    End Sub

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub

End Class
