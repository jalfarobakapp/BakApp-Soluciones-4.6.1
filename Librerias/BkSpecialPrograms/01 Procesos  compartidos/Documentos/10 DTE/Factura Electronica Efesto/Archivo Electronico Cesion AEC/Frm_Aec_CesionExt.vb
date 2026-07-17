Imports DevComponents.DotNetBar

Public Class Frm_Aec_CesionExt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Row_Maeedo As DataRow

    Public Property Id_Aec As Integer
    Public Property AmbienteCertificacion As Boolean
    Public Property Modolectura As Boolean
    Public Property Accion As String

    Public Sub New(_Idmaeedo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Aec_CesionExt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Feemdo As Date = CDate(_Row_Maeedo.Item("FEEMDO"))
        Dim _Feulvedo As Date = CDate(_Row_Maeedo.Item("FEULVEDO"))


        Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Row_Maeedo.Item("ENDO"), _Row_Maeedo.Item("SUENDO"))

        Lbl_Documento.Text = _Row_Maeedo.Item("TIDO") & "-" & _Row_Maeedo.Item("NUDO") &
                         " / Fecha emisión: " & Format(_Feemdo, "dd/MM/yyyy") &
                         " / Fecha últ. vencimiento: " & Format(_Feulvedo, "dd/MM/yyyy")
        Lbl_RazonSocialCedente.Text = _Row_Entidad.Item("NOKOEN").ToString.Trim
        Lbl_RutCedente.Text = _Row_Entidad.Item("Rut")
        Lbl_DireccionCedente.Text = _Row_Entidad.Item("DIEN").ToString.Trim

        Dtp_FechaCesion.Value = Nothing
        Dtp_FUltimoVencimiento.Value = Nothing

        Dtp_FechaCesion.Text = String.Empty
        Dtp_FUltimoVencimiento.Value = _Feulvedo

        If Modolectura Then

            Consulta_sql = $"Select * From {_Global_BaseBk}Zw_DTE_Aec Where Id_Aec = " & Id_Aec
            Dim _Row_Aec As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Cesionario_Entidad.Text = _Row_Aec.Item("RutCesionario").ToString.Trim & "-" & _Row_Aec.Item("RazonSocialCesionario").ToString.Trim
            Dtp_FechaCesion.Value = _Row_Aec.Item("FechaSolicitud")
            Dtp_FUltimoVencimiento.Value = _Row_Aec.Item("FUltimoVencimiento")

            Btn_Grabar_Cesion.Enabled = False
            Dtp_FechaCesion.Enabled = False
            Dtp_FUltimoVencimiento.Enabled = False
            Txt_Cesionario_Entidad.Enabled = False

            If Not _Row_Aec.Item("CesionExterna") Then
                Me.Text = "REGISTRO DE DOCUMENTO CESIONADO DESDE BAKAPP"
            End If

        End If

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
        Dim _Feulvedo As Date = CDate(_Row_Maeedo.Item("FEULVEDO"))

        If String.IsNullOrWhiteSpace(Txt_Cesionario_Entidad.Text) OrElse IsNothing(Txt_Cesionario_Entidad.Tag) Then
            MessageBoxEx.Show(Me, "Debe seleccionar el cesionario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cesionario_Entidad.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Dtp_FechaCesion.Text) OrElse Dtp_FechaCesion.Value = Date.MinValue Then
            MessageBoxEx.Show(Me, "Debe ingresar una fecha válida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_FechaCesion.Focus()
            Return
        End If

        Dim _FechaSolicitud As Date = Dtp_FechaCesion.Value.Date
        Dim _FUltimoVencimiento As Date = Dtp_FUltimoVencimiento.Value.Date

        Dim _FechaServidor As Date = FechaDelServidor().Date

        If _FechaSolicitud < _Feemdo.Date Then
            MessageBoxEx.Show(Me,
                              "La fecha ingresada no puede ser menor a la fecha del documento, fecha emisión: " &
                              Format(_Feemdo, "dd/MM/yyyy"),
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
            Dtp_FechaCesion.Focus()
            Return
        End If

        If _FechaSolicitud > _FechaServidor Then
            MessageBoxEx.Show(Me,
                          "La fecha ingresada no puede ser mayor a la fecha del servidor: " &
                          Format(_FechaServidor, "dd/MM/yyyy"),
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
            Dtp_FechaCesion.Focus()
            Return
        End If

        If _FUltimoVencimiento < _FechaServidor Then
            MessageBoxEx.Show(Me,
                              "La fecha de vencimiento no puede ser menor a la fecha del servidor: " &
                              Format(_FechaServidor, "dd/MM/yyyy"),
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
            Dtp_FUltimoVencimiento.Focus()
            Return
        End If

        Dim _Idmaeedo As Integer = _Row_Maeedo.Item("IDMAEEDO")
        Dim _Tido As String = _Row_Maeedo.Item("TIDO")
        Dim _Nudo As String = _Row_Maeedo.Item("NUDO")
        Dim _CodEntidad_Cedente As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("KOEN")
        Dim _CodSucEntidad_Cedente As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("SUEN")
        Dim _RutCedente As String = RutEmpresa
        Dim _RutCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("Rut").ToString.Trim
        Dim _RazonSocialCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("NOKOEN").ToString.Trim
        Dim _DireccionCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("DIEN")
        Dim _eMailCesionario As String = CType(Txt_Cesionario_Entidad.Tag, DataRow).Item("EMAIL")
        Dim _MontoCesion As Double = _Row_Maeedo.Item("VABRDO")

        Dim _HoraGrab = Hora_Grab_fx(False)

        Dim _FechaUlVenciDistintaOri As Boolean

        If _FUltimoVencimiento.Date <> _Feulvedo.Date Then
            _FechaUlVenciDistintaOri = True
        End If

        Consulta_sql = $"Select Top 1 * From MAEVEN Where IDMAEEDO = {_Idmaeedo} Order By FEVE Desc"
        Dim _Row_Maeven As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Idmaeven As Integer = _Row_Maeven.Item("IDMAEVEN")

        Consulta_sql = $"
        Insert Into {_Global_BaseBk}Zw_DTE_Aec (Idmaeedo,Id_Dte,Tido,Nudo,FechaSolicitud,RutCedente,RutCesionario,
        RazonSocialCesionario,DireccionCesionario,eMailCesionario,MontoCesion,FUltimoVencimiento,RutAutoriza,NombreAutoriza,
        eMailCedente,NmbContacto,FonoContacto,MailContacto,Xml,Procesar,ErrorEnvioAEC,AmbienteCertificacion,CesionExterna,
        CodEntidad_Cedente,CodSucEntidad_Cedente,CodFuncionario_CE) Values 
        ({_Idmaeedo},0,'{_Tido}','{_Nudo}','{Format(_FechaSolicitud, "yyyyMMdd")}','{_RutCedente}','{_RutCesionario}','{_RazonSocialCesionario}',
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
                ('MAEEDO',{_Idmaeedo},'',0,'{FUNCIONARIO}','{Format(_FechaServidor, "yyyyMMdd")}','CESION','FECHACECIO','{ FormatDateTime(_FechaSolicitud, DateFormat.ShortDate)}',GetDate(),{_HoraGrab})
                INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,FECHAREF,HORAGRAB) VALUES 
                ('MAEEDO',{_Idmaeedo},'',0,'{FUNCIONARIO}','{Format(_FechaServidor, "yyyyMMdd")}','CESION','RUTCECIONA','{_RutCesionario}',GetDate(),{_HoraGrab})"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _FechaUlVenciDistintaOri Then
            Consulta_sql = $"
                Update MAEEDO Set FEULVEDO = '{Format(_FUltimoVencimiento, "yyyyMMdd")}' Where IDMAEEDO = {_Idmaeedo}   
                Update MAEVEN Set FEVE = '{Format(_FUltimoVencimiento, "yyyyMMdd")}' Where IDMAEVEN = {_Idmaeven}"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Accion = $"Cesion de documento externamente, Cecionario: {_RutCesionario} - {_RazonSocialCesionario}, Fecha: {_FechaSolicitud}"

        Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "MAEEDO", _Idmaeedo, "CesionExt",
                           Accion, "", "", "", "", False, FUNCIONARIO, False, 0, "", _Tido, _Nudo)

        If _FechaUlVenciDistintaOri Then

            Accion = $"Cesion de documento externamente." & vbCrLf &
            $"Cecionario: {_RutCesionario} - {_RazonSocialCesionario}" & vbCrLf &
            $"Fecha: {_FechaSolicitud} Se cambia la fecha último vencimiento: {_FUltimoVencimiento}"

            Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "MAEEDO", _Idmaeedo, "CesionExt",
                   $"Se cambia la fecha de vencimiento del documento, Fecha anterior: {_Feulvedo.Date.ToShortDateString}, nueva fecha: {_FUltimoVencimiento.Date.ToShortDateString}",
                   "", "", "", "", False, FUNCIONARIO, False, 0, "", _Tido, _Nudo)

        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Frm_Aec_CesionExt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
