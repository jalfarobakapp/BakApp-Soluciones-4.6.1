Imports DevComponents.DotNetBar

Public Class Frm_Aec_CesionExt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Row_Maeedo As DataRow

    Public Property Id_Aec As Integer
    Public Property AmbienteCertificacion As Boolean

    Public Sub New(_Idmaeedo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Aec_CesionExt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Feemdo As Date = CDate(_Row_Maeedo.Item("FEEMDO"))

        Lbl_Documento.Text = _Row_Maeedo.Item("TIDO") & "-" & _Row_Maeedo.Item("NUDO") &
                         " / Fecha emisión: " & Format(_Feemdo, "dd/MM/yyyy")
        Lbl_RazonSocialCedente.Text = RazonEmpresa
        Lbl_RutCedente.Text = RutEmpresaActiva
        Lbl_DireccionCedente.Text = DireccionEmpresa

        Dtp_FEmision_Desde.Text = String.Empty

    End Sub

    Private Sub Txt_Cesionario_Entidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Cesionario_Entidad.ButtonCustomClick

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.Rdb_Clientes.Checked = True
        Fm.ShowDialog(Me)
        Dim _RowEntidad = Fm.Pro_RowEntidad
        Fm.Dispose()

        If Not IsNothing(_RowEntidad) Then

            Txt_Cesionario_Entidad.Text = _RowEntidad.Item("Rut") & "-" & _RowEntidad.Item("NOKOEN").ToString.Trim
            Txt_Cesionario_Entidad.Tag = _RowEntidad

        End If

    End Sub

    Private Sub Txt_Cesionario_Entidad_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Cesionario_Entidad.ButtonCustom2Click
        Txt_Cesionario_Entidad.Text = String.Empty
        Txt_Cesionario_Entidad.Tag = Nothing
    End Sub

    Private Sub Btn_Grabar_Cesion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Cesion.Click

        Dim _Feemdo As Date = CDate(_Row_Maeedo.Item("FEEMDO"))

        If String.IsNullOrWhiteSpace(Txt_Cesionario_Entidad.Text) OrElse IsNothing(Txt_Cesionario_Entidad.Tag) Then
            MessageBoxEx.Show(Me, "Debe seleccionar el cesionario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cesionario_Entidad.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Dtp_FEmision_Desde.Text) OrElse Dtp_FEmision_Desde.Value = Date.MinValue Then
            MessageBoxEx.Show(Me, "Debe ingresar una fecha válida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_FEmision_Desde.Focus()
            Return
        End If

        Dim _FechaCesion As Date = Dtp_FEmision_Desde.Value.Date
        Dim _FechaServidor As Date = FechaDelServidor().Date

        If _FechaCesion < _Feemdo.Date Then
            MessageBoxEx.Show(Me,
                              "La fecha ingresada no puede ser menor a la fecha del documento, fecha emisión: " &
                              Format(_Feemdo, "dd/MM/yyyy"),
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
            Dtp_FEmision_Desde.Focus()
            Return
        End If

        If _FechaCesion > _FechaServidor Then
            MessageBoxEx.Show(Me,
                          "La fecha ingresada no puede ser mayor a la fecha del servidor: " &
                          Format(_FechaServidor, "dd/MM/yyyy"),
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
            Dtp_FEmision_Desde.Focus()
            Return
        End If

        Dim _Idmaeedo As Integer = _Row_Maeedo.Item("IDMAEEDO")
        Dim _Tido As String = _Row_Maeedo.Item("TIDO")
        Dim _Nudo As String = _Row_Maeedo.Item("NUDO")
        Dim _CodEntidad_Cedente As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("KOEN")
        Dim _CodSucEntidad_Cedente As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("SUEN")
        Dim _RutCedente As String = RutEmpresa
        Dim _RutCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("Rut")
        Dim _RazonSocialCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("NOKOEN").ToString.Trim
        Dim _DireccionCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("DIEN")
        Dim _eMailCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("EMAIL")
        Dim _MontoCesion As Double = _Row_Maeedo.Item("VABRDO")
        Dim _FUltimoVencimiento As Date = _Row_Maeedo.Item("FEULVEDO")

        Dim _HoraGrab = Hora_Grab_fx(False)

        Consulta_sql = $"
        Insert Into {_Global_BaseBk}Zw_DTE_Aec (Idmaeedo,Id_Dte,Tido,Nudo,FechaSolicitud,RutCedente,RutCesionario,
        RazonSocialCesionario,DireccionCesionario,eMailCesionario,MontoCesion,FUltimoVencimiento,RutAutoriza,NombreAutoriza,
        eMailCedente,NmbContacto,FonoContacto,MailContacto,Xml,Procesar,ErrorEnvioAEC,AmbienteCertificacion,CesionExterna,
        CodEntidad_Cedente,CodSucEntidad_Cedente,CodFuncionario_CE) Values 
        ({_Idmaeedo},0,'{_Tido}','{_Nudo}','{Format(_FechaCesion, "yyyyMMdd")}','{_RutCedente}','{_RutCesionario}','{_RazonSocialCesionario}',
        '{_DireccionCesionario}','{_eMailCesionario}',
        {De_Num_a_Tx_01(_MontoCesion, False, 5)},
        '{Format(_FUltimoVencimiento, "yyyyMMdd")}','','','','','','','',0,0,
        {Convert.ToInt32(_AmbienteCertificacion)},1,'{_CodEntidad_Cedente}','{_CodSucEntidad_Cedente}','{FUNCIONARIO}')"

        If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Aec, False) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = $"
                INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB) VALUES 
                ('MAEEDO',{_Idmaeedo},'',0,'{FUNCIONARIO}','{Format(_FechaServidor, "yyyyMMdd")}','CESION','CECIONARIO','{_RazonSocialCesionario}',GetDate(),{_HoraGrab})
                INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB) VALUES 
                ('MAEEDO',{_Idmaeedo},'',0,'{FUNCIONARIO}','{Format(_FechaServidor, "yyyyMMdd")}','CESION','FECHACECIO','{ FormatDateTime(_FechaCesion, DateFormat.ShortDate)}',GetDate(),{_HoraGrab})
                INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB) VALUES 
                ('MAEEDO',{_Idmaeedo},'',0,'{FUNCIONARIO}','{Format(_FechaServidor, "yyyyMMdd")}','CESION','RUTCECIONA','{_RutCesionario}',GetDate(),{_HoraGrab})"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Accion As String = $"Cesion de documento externamiente, Cecionario: {_RutCesionario} - {_RazonSocialCesionario}, Fecha: {_FechaCesion}"

        Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "MAEEDO", _Idmaeedo, "CesionExt",
                           _Accion, "", "", "", "", False, FUNCIONARIO, False, 0, "", _Tido, _Nudo)

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Frm_Aec_CesionExt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
