Imports Funciones_BakApp
Imports DevComponents.DotNetBar

Public Class Frm_Remotas_Rd

    Dim _Sql As Class_SQL
    Dim Consulta_sql As String

    Dim _TblRemotas As DataTable
    Dim _Cadena_ConexionSQL_Server_Remotas = Cadena_ConexionSQL_Server
    Dim _Row_Funcionario As DataRow
    Dim _Ipotorga As String = Mid(getIp(), 15)

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
    End Sub

    Private Sub Frm_Permisos_Remotos_Solicitados_Rd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        _Sql = New Class_SQL(_Cadena_ConexionSQL_Server_Remotas)
        Consulta_sql = "Select Top 1 * From TABFU Where KOFU = '" & FUNCIONARIO & "'"
        _Row_Funcionario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Actualizar_Grilla()

        AddHandler Btn_Refresh.Click, AddressOf Sb_Actualizar_Grilla



    End Sub

    Sub Sb_Actualizar_Grilla()

        _Sql = New Class_SQL(_Cadena_ConexionSQL_Server_Remotas)

        Consulta_sql = "SELECT Tr.KOFU,(SELECT TOP 1 NOKOFU FROM TABFU WHERE TABFU.KOFU = Tr.KOFU) As NOKOFU,NUDOKASI," & _
                       "Tr.KOOP,Mop.NOKOOP,Tr.NUREMOT,Tr.TEMA,Tr.LAHORA,Tr.HORAGRAB,Tr.IPPIDE," & _
                       "Convert(Nvarchar, Convert(Datetime, (Tr.HORAGRAB*1.0/3600)/24), 108) AS HH,Tr.KOEN,Tr.NOKOEN," & vbCrLf & _
                       "ISNULL((SELECT TOP 1 VABRDO FROM KASIEDO WHERE IDMAEEDO = Tr.NUDOKASI),0) AS VABRDO" & vbCrLf & _
                       "FROM TABREMOT Tr LEFT JOIN MAEOP Mop ON Mop.KOOP=Tr.KOOP " & vbCrLf & _
                       "WHERE COALESCE(Tr.OTORGA,'')=''" & vbCrLf & _
                       "ORDER BY Tr.KOFU ,Tr.NUREMOT OPTION ( FAST 20 )"

        _TblRemotas = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _TblRemotas

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").Visible = True
            .Columns("KOFU").HeaderText = "Func."
            .Columns("KOFU").Width = 35

            .Columns("KOOP").Visible = True
            .Columns("KOOP").HeaderText = "Permiso"
            .Columns("KOOP").Width = 80

            .Columns("NOKOOP").Visible = True
            .Columns("NOKOOP").HeaderText = "Descripción del permisos solicitado"
            .Columns("NOKOOP").Width = 430

            '.Columns("TipoDoc").Visible = True
            '.Columns("TipoDoc").HeaderText = "TD"
            '.Columns("TipoDoc").Width = 30


            .Columns("LAHORA").Visible = True
            .Columns("LAHORA").HeaderText = "Fecha"
            .Columns("LAHORA").Width = 100
            .Columns("LAHORA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("HH").Visible = True
            .Columns("HH").HeaderText = "Hora"
            .Columns("HH").Width = 60
            .Columns("HH").DefaultCellStyle.Format = "hh:mm:ss"

        End With

        Consulta_sql = "Select Top 1 * From CONFIGP"
        Dim _RowConfigP As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Dim _Razon = Trim(_RowConfigP.Item("RAZON"))

        Me.Text = "PERMISOS SOLICITADOS REMOTAMENTE, EMPRESA: " & _Razon

    End Sub

    Private Sub Btn_Cambiar_de_empresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_de_empresa.Click

        Dim _Conexion_establecida As Boolean
        Dim _Cadena_ConexionSQL_Seleccionada = String.Empty
        Dim _Razon As String

        Try

            Dim DatosConex As New ConexionBK

            Dim Directorio As String = Application.StartupPath & "\Data\"
            Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

            If Not _Exists Then
                DatosConex.WriteXml(Directorio & "Conexiones.xml")
                MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            DatosConex.ReadXml(Directorio & "Conexiones.xml")

            Dim Frm_ConexionBD As New Frm_ConexionBD
            Frm_ConexionBD.BtnAgregar.Visible = False
            Frm_ConexionBD.BtnGenerateKey.Visible = False
            Frm_ConexionBD.ShowDialog(Me)

            If Frm_ConexionBD.NombreConexionActiva = String.Empty Then
                Frm_ConexionBD.Dispose()
                Return
            Else
                _Cadena_ConexionSQL_Seleccionada = Fx_CadenaConexionSQL(Frm_ConexionBD.NombreConexionActiva, DatosConex)
            End If
            Frm_ConexionBD.Dispose()

            If _Cadena_ConexionSQL_Seleccionada = _Cadena_ConexionSQL_Server_Remotas Then
                Beep()
                ToastNotification.Show(Me, "YA ESTA CONECTADO A ESTA EMPRESA", Btn_Cambiar_de_empresa.Image, _
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If


            Dim _Pwfu = _Row_Funcionario.Item("PWFU") 'Trim(trae_dato(tb, cn1, "PWFU", "TABFU", "KOFU = '" & FUNCIONARIO & "'"))


            _Sql = New Class_SQL(_Cadena_ConexionSQL_Seleccionada)

            Consulta_sql = "Select Top 1 * From TABFU Where KOFU = '" & FUNCIONARIO & "'"
            Dim _Row_New_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Consulta_sql = "Select Top 1 * From CONFIGP"
            Dim _RowConfigP As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
            _Razon = Trim(_RowConfigP.Item("RAZON"))


            If Not _Row_New_Funcionario Is Nothing Then 'CBool(_TblFun.Rows.Count) Then

                Dim _Kofu = Trim(_Row_New_Funcionario.Item("KOFU"))
                Dim _Nokofu = Trim(_Row_New_Funcionario.Item("NOKOFU"))

                Dim Fm_L As New Frm_Login

                If Fm_L.Fx_Sesion_Star(Me, _Kofu, _Nokofu) Then
                    _Conexion_establecida = True
                End If

                _Row_Funcionario = _Row_New_Funcionario
                _Cadena_ConexionSQL_Server_Remotas = _Cadena_ConexionSQL_Seleccionada

            Else

                MessageBoxEx.Show(Me, "No se reconoce el usuario en la empresa: " & _Razon & vbCrLf & _
                                  "Revise la clave, puede que sea distinta entre ambas bases", "Validación", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If


        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        Finally

            Sb_Actualizar_Grilla()

            If _Conexion_establecida Then
                Beep()
                ToastNotification.Show(Me, "CONEXION ESTABLECIDA: " & _Razon, Btn_Cambiar_de_empresa.Image, _
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If
        End Try


    End Sub

    Private Sub Grilla_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _CodPermiso = String.Empty
        Dim _Nombre_Funcionario = String.Empty
        Dim _Descripcion_Adicional = String.Empty
        Dim _Descripcion_del_permiso = String.Empty
        Dim _TotalBruto As Double

        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            _CodPermiso = _Fila.Cells("KOOP").Value
            _Nombre_Funcionario = _Fila.Cells("NOKOFU").Value
            _Descripcion_Adicional = _Fila.Cells("TEMA").Value
            _TotalBruto = _Fila.Cells("VABRDO").Value
            _Descripcion_del_permiso = _Fila.Cells("NOKOOP").Value

        Catch ex As Exception

        Finally
            Lbl_Nombre_Solicitante.Text = _Nombre_Funcionario
            Lbl_Descripcion_Adicional.Text = _Descripcion_Adicional
            Lbl_TotalBruto.Text = FormatCurrency(_TotalBruto, 0)
            Lbl_Descripcion_del_permiso.Text = "( " & _CodPermiso & " ) - " & _Descripcion_del_permiso
        End Try

    End Sub

    Private Sub Frm_Remotas_Rd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koop = _Fila.Cells("KOOP").Value
        Dim _Nokoop = _Fila.Cells("NOKOOP").Value
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Nudokasi = _Fila.Cells("NUDOKASI").Value
        Dim _Nuremot = _Fila.Cells("NUREMOT").Value

        Dim _Kofuauto = _Row_Funcionario.Item("KOFU")

        Select Case _Koop

            Case "TO000006"

                Consulta_sql = "Select Top 1 * From TABREMOT Where NUREMOT = '" & _Nuremot & "' And KOFU = '" & _Kofu & "'"
                Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim Fm As New Frm_Remotas_Analisi_Dscto_X_Documento_Rd(_Cadena_ConexionSQL_Server_Remotas,
                                                                       _Row,
                                                                       _Row_Funcionario, Frm_Remotas_Analisi_Dscto_X_Documento_Rd.Enum_Tabla.Kasiedo, 0)
                If Fm.Pro_Existe_Documento Then
                    Fm.ShowDialog(Me)
                    If Fm.Pro_Aceptado Then

                        Sb_Grabara_Tabactus()

                        Beep()
                        ToastNotification.Show(Me, "SOLICITUD ACEPTADA", Btn_Autorizar_Permiso.Image, _
                                               1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                    End If
                Else
                    MessageBoxEx.Show(Me, "El documento señalado ya no existe en la base de datos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Consulta_sql = "Delete TABREMOT Where NUREMOT = '" & _Nuremot & "' And KOFU = '" & _Kofu & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If


                Fm.Dispose()
                Sb_Actualizar_Grilla()

            Case Else

                Btn_Ver_deuda_pendiente.Visible = IIf(_Koop = "TO000055", True, False)
                Lbl_Opciones_adicionales.Visible = Btn_Ver_deuda_pendiente.Visible
                'Case "TO000055"
                ShowContextMenu(Menu_Contextual_01)

        End Select

    End Sub

    Private Sub Btn_Autorizar_Permiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Autorizar_Permiso.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koop = _Fila.Cells("KOOP").Value
        Dim _Nokoop = _Fila.Cells("NOKOOP").Value
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Ippide = _Fila.Cells("IPPIDE").Value
        Dim _Nuremot = _Fila.Cells("NUREMOT").Value

        Dim _Kofuauto = _Row_Funcionario.Item("KOFU")
        Dim _Horagrab = Hora_Grab_fx(False)

        If Fx_Tiene_Permiso() Then
            If Fx_Existe_Remota(_Nuremot, _Kofu) Then

                Consulta_sql = "UPDATE TABREMOT SET KOFUAUTO = '" & _Kofuauto & "',OTORGA = 'Autorizo',IPOTORGA = '" & _Ipotorga & "'" & vbCrLf & _
                               "WHERE NUREMOT = '" & _Nuremot & "'"
                               
                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    Sb_Grabara_Tabactus()

                    Beep()
                    ToastNotification.Show(Me, "SOLICITUD ACEPTADA", Btn_Autorizar_Permiso.Image, _
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                End If
            End If
        End If

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Rechazar_Permiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rechazar_Permiso.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koop = _Fila.Cells("KOOP").Value
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Kofuauto = _Row_Funcionario.Item("KOFU")
        Dim _Nuremot = _Fila.Cells("NUREMOT").Value

        _Ipotorga = Mid(getIp(), 1, 15)

        If Fx_Tiene_Permiso() Then
            If Fx_Existe_Remota(_Nuremot, _Kofu) Then
                Consulta_sql = "UPDATE TABREMOT SET KOFUAUTO = '" & _Kofuauto & "',OTORGA = 'No_autorizo',IPOTORGA = '" & _Ipotorga & "'" & vbCrLf & _
                               "WHERE NUREMOT = '" & _Nuremot & "'"

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Beep()
                    ToastNotification.Show(Me, "SOLICITUD ACEPTADA", Btn_Autorizar_Permiso.Image, _
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                End If
            End If
        End If

        Sb_Actualizar_Grilla()

    End Sub

    Function Fx_Tiene_Permiso() As Boolean

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koop = _Fila.Cells("KOOP").Value
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Kofuauto = _Row_Funcionario.Item("KOFU")
        Dim _Nuremot = _Fila.Cells("NUREMOT").Value

        Consulta_sql = "Select Top 1 * From MAEUS" & vbCrLf & _
                       "Where KOUS = '" & _Kofuauto & "' And KOOP = '" & _Koop & "'"
        Dim _Row_Maeus As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _Kofuauto = _Kofu Then
            MessageBoxEx.Show(Me, "Usted no puede auto-otorgarse un permiso", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            If _Row_Maeus IsNot Nothing Then
                Return True
            Else
                MessageBoxEx.Show(Me, "No posee permisos para gestionar esta solicitud", "Valización", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Function

    Function Fx_Existe_Remota(ByVal _Nuremot As String, ByVal _Kofu As String)

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABREMOT", "NUREMOT = '" & _Nuremot & "' And KOFU = '" & _Kofu & "'"))

        If Not _Reg Then
            MessageBoxEx.Show(Me, "La solicitud remota ya no está vigente." & vbCrLf & _
            "Puede que haya sido cancelada por el usuario o el permiso fue gestionado por otro usuario", _
            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Return _Reg

    End Function

    Sub Sb_Grabara_Tabactus()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koop = _Fila.Cells("KOOP").Value
        Dim _Nokoop = Trim(_Fila.Cells("NOKOOP").Value)
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Ippide = _Fila.Cells("IPPIDE").Value
        Dim _Nuremot = _Fila.Cells("NUREMOT").Value

        Dim _Kofuauto = _Row_Funcionario.Item("KOFU")
        Dim _Horagrab = Hora_Grab_fx(False)

        _Ipotorga = Mid(getIp(), 1, 15)

        Consulta_sql = "INSERT INTO TABACTUS (KOFU,KOFUAUTO,KOOP,FECHA,HORAGRAB,ACCION,IPPIDE,IPOTORGA,VERSION) VALUES " & vbCrLf & _
                       "('" & _Kofu & "','" & _Kofuauto & "','" & _Koop & "',GetDate()," & _Horagrab & _
                       ",'Autorización remota: " & _Nokoop & "','" & _Ippide & "','" & _Ipotorga & "','Desde BakApp')"

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Btn_Ver_deuda_pendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_deuda_pendiente.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koop = _Fila.Cells("KOOP").Value
        Dim _Nokoop = _Fila.Cells("NOKOOP").Value
        Dim _Kofu = _Fila.Cells("KOFU").Value
        Dim _Ippide = _Fila.Cells("IPPIDE").Value
        Dim _Nuremot = _Fila.Cells("NUREMOT").Value
        Dim _Koen = _Fila.Cells("KOEN").Value

        Dim _Kofuauto = _Row_Funcionario.Item("KOFU")

        If Fx_Existe_Remota(_Nuremot, _Kofu) Then

            Consulta_sql = "Select * From MAEEN Where KOEN = '" & _Koen & "'"
            Dim _Tbl_Inf_Entidad As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim _Row_Entidad As DataRow

            If _Tbl_Inf_Entidad.Rows.Count Then

                If _Tbl_Inf_Entidad.Rows.Count > 1 Then
                    Dim Fm_Ent As New Frm_BuscarEntidad_MtSuc
                    Fm_Ent._CodEntidad = _Koen
                    Fm_Ent._Seleccionar = True
                    Fm_Ent.BtnCrearUser.Visible = False
                    Fm_Ent.BtnEditarEntidad.Visible = False
                    Fm_Ent.ShowDialog(Me)

                    If Fm_Ent._Suc_Seleccionada Then
                        _Row_Entidad = Fm_Ent._Tbl_SucursalSelec.Rows(0)
                    End If

                Else
                    _Row_Entidad = _Tbl_Inf_Entidad.Rows(0)
                End If

            End If

            If _Row_Entidad IsNot Nothing Then

                'Dim Fm_D As New Frm_InfoEnt_Deudas_Doc_Comerciales(_Tbl_Inf_Entidad.Rows(0), 0, 0, 0, 0, _Kofuauto)
                'Fm_D.SuperTabControl1.SelectedTabIndex = 1
                'Fm_D.Btn_CambCodPago.Visible = False
                'Fm_D.Btn_Vender_con_deuda_vencida.Visible = True
                'Fm_D.ShowDialog(Me)

                'If Fm_D._Autorizar_Venta Then
                'Call Btn_Autorizar_Permiso_Click(Nothing, Nothing)
                'End If

            End If

        End If

    End Sub

    

End Class
