Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Correos_EnvDocAdjunto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Row_Correo As DataRow
    Dim _Row_Documento As DataRow
    Dim _Tbl_Funcionarios As DataTable

    Dim _Accion As Enum_Tipo
    Enum Enum_Tipo
        Interno
        Externo
    End Enum
    Public Sub New(IdMaeedo As Integer, Accion As Enum_Tipo)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & IdMaeedo
        _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_Sql)

        _Accion = Accion

        Chk_Enviar_Notificacion.Enabled = (_Accion = Enum_Tipo.Interno)

    End Sub

    Private Sub Frm_Correos_EnvDocAdjunto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_Sql = "Select Id,Nombre_Correo,Remitente,Contrasena,Host,Puerto,Asunto,Auto_Asunto,Para,CC,CuerpoMensaje,Firma,SSL,Envio_Automatico,Es_Html
                        From " & _Global_BaseBk & "Zw_Correos
                        Where Nombre_Correo = 'automatico@sirrep.cl'"
        _Row_Correo = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Tido = _Row_Documento.Item("TIDO")
        Dim _Nudo = _Row_Documento.Item("NUDO")
        Dim _Notido = Trim(_Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'"))

        Txt_Asunto.Text = "Adjunto " & LCase(_Notido) & " Nro: " & _Nudo

    End Sub

    Private Sub Btn_Enviar_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Correo.Click

        Dim _NombreEquipo
        Dim _Nombre_Correo = _Row_Correo.Item("Nombre_Correo")
        Dim _Asunto = Txt_Asunto.Text
        Dim _Para = Txt_Para.Text
        Dim _Cc = Txt_Cc.Text
        Dim _Idmaeedo = _Row_Documento.Item("IDMAEEDO")
        Dim _Tido = _Row_Documento.Item("TIDO")
        Dim _Nudo = _Row_Documento.Item("NUDO")
        Dim _Mensaje = Txt_Respuesta.Text
        _Mensaje = Replace(_Mensaje, Chr(13), "<br/>")

        Consulta_Sql = String.Empty

        If _Accion = Enum_Tipo.Interno Then
            For Each _Fila As DataRow In _Tbl_Funcionarios.Rows

                _Para = Trim(_Sql.Fx_Trae_Dato("TABFU", "EMAIL", "KOFU = '" & _Fila.Item("Codigo") & "'"))

                _Para = "jalfaro@bakapp.cl"
                Consulta_Sql += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (NombreEquipo,Nombre_Correo,Asunto,Para,Cc,Idmaeedo,Tido,Nudo,
                                 Enviar,Intentos,Enviado, Adjuntar_Documento,Mensaje) Values 
                                 ('','" & _Nombre_Correo & "','" & _Asunto & "','" & _Para & "','" & _Cc & "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "',
                                 1,0,0,1,'" & _Mensaje & "')" & vbCrLf

                _Cc = String.Empty
            Next
        Else
            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (NombreEquipo,Nombre_Correo,Asunto,Para,Cc,Idmaeedo,Tido,Nudo,
                            Enviar,Intentos,Enviado, Adjuntar_Documento) Values 
                            ('','" & _Nombre_Correo & "','" & _Asunto & "','" & _Para & "','" & _Cc & "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "',
                            1,0,0,1)"
        End If

        If Not String.IsNullOrEmpty(Consulta_Sql) Then
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)
        End If

    End Sub

    Private Sub Txt_Para_TextChanged(sender As Object, e As EventArgs) Handles Txt_Para.TextChanged

    End Sub

    Private Sub Btn_Para_Click(sender As Object, e As EventArgs) Handles Btn_Para.Click

        'Dim _Sql_Filtro_Condicion_Extra 

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Funcionarios,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "", False, False) Then

            _Tbl_Funcionarios = _Filtrar.Pro_Tbl_Filtro

        End If

    End Sub
End Class