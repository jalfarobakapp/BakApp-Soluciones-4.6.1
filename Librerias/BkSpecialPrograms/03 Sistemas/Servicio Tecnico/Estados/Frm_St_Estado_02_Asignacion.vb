Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms
Imports System.Data.SqlClient

Public Class Frm_St_Estado_02_Asignacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ot As Integer
    Dim _Grabar As Boolean
    Dim _Editando_documento As Boolean
    Dim _DsDocumento As DataSet

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Row_Notas As DataRow

    Dim _Accion As Accion

    Dim Imagenes_32x32 As ImageList

    Enum Accion
        Nuevo
        Editar
    End Enum

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(ByVal value As DataSet)
            _DsDocumento = value

            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Tbl_ChekIn = _DsDocumento.Tables(2)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)

        End Set
    End Property

    Public Property Pro_Imagenes_32x32() As ImageList
        Get
            Return Imagenes_32x32
        End Get
        Set(ByVal value As ImageList)
            Imagenes_32x32 = value
        End Set
    End Property

    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property Pro_Editando_Documento() As Boolean
        Get
            Return _Editando_documento
        End Get
        Set(ByVal value As Boolean)
            _Editando_documento = value
        End Set
    End Property

#End Region
    Public Sub New(ByVal Id_Ot As Integer, ByVal Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion
        _Id_Ot = Id_Ot

    End Sub

    Private Sub Frm_St_Estado_02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Accion = Accion.Nuevo Then
            Sb_Cargar_Tecnicos("")
            Btn_Grabar.Visible = False
            AddHandler Btn_Fijar_Estado.Click, AddressOf Sb_Grabar_Asignacion
        ElseIf _Accion = Accion.Editar Then

            Btn_Editar.Visible = True
            Btn_Grabar.Visible = False

            Dim _Tecnico As String = _Row_Encabezado.Item("CodTecnico_Asignado")
            Sb_Cargar_Tecnicos(_Tecnico, True)

            Cmb_Tecnico_SelectedValueChanged()

            Txt_Nota.Text = _Row_Notas.Item("Nota_Etapa_02")

            Txt_Nota.ReadOnly = True
            Btn_Fijar_Estado.Visible = False

            Txt_Nota.BackColor = Color.LightGray
            Txt_Nota.FocusHighlightEnabled = False
            'Btn_Direccion_Servicio.Visible = True

            AddHandler Btn_Grabar.Click, AddressOf Sb_Grabar_Asignacion

            If _Row_Encabezado.Item("CodEstado") = "CE" Then
                Btn_Editar.Visible = False
            End If

        End If

        Btn_Direccion_Servicio.Enabled = _Row_Encabezado.Item("Chk_Serv_Domicilio")

        Txt_Informacion.BackColor = Color.LightGray
        Txt_Informacion.FocusHighlightEnabled = False

        AddHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_Taller_Externo_CheckedChanging
        AddHandler Chk_Tec_Domicilio.CheckedChanging, AddressOf Chk_Tec_Domicilio_CheckedChanging

        AddHandler Cmb_Tecnico.SelectedValueChanged, AddressOf Cmb_Tecnico_SelectedValueChanged

    End Sub

    Sub Sb_Cargar_Tecnicos(ByVal _Tecnico As String, _
                           Optional ByVal _Solo_Este_Tecnico As Boolean = False)

        Dim _Condicion = String.Empty

        If _Solo_Este_Tecnico Then
            _Condicion = vbCrLf & "And CodFuncionario = '" & _Tecnico & "'" & vbCrLf
        End If

        caract_combo(Cmb_Tecnico)
        Consulta_sql = "SELECT CodFuncionario AS Padre,NomFuncionario AS Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & vbCrLf & _
                       "WHERE 1 > 0" & _Condicion & " ORDER BY Hijo"
        Cmb_Tecnico.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Tecnico.SelectedValue = _Tecnico

        'SELECT     TOP (200) CodFuncionario,NomFuncionario,Star,Chk_Taller_Externo,Chk_Habilitado,Chk_Supervisor,Chk_Domicilio
        'FROM         Zw_St_Conf_Tecnicos_Taller

    End Sub

    Private Sub Chk_Taller_Externo_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        e.Cancel = True
    End Sub

    Private Sub Chk_Tec_Domicilio_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        e.Cancel = True
    End Sub

    Private Sub Cmb_Tecnico_SelectedValueChanged()

        RemoveHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_Taller_Externo_CheckedChanging
        RemoveHandler Chk_Tec_Domicilio.CheckedChanging, AddressOf Chk_Tec_Domicilio_CheckedChanging

        Dim _CodFuncionario As String = Cmb_Tecnico.SelectedValue

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & " Zw_St_Conf_Tecnicos_Taller" & vbCrLf & _
                       "Where CodFuncionario = '" & _CodFuncionario & "'"

        Dim _TblTecnico As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblTecnico.Rows.Count) Then

            Rating_Star.Rating = _TblTecnico.Rows(0).Item("Star")
            Txt_Informacion.Text = _TblTecnico.Rows(0).Item("Informacion")

            Chk_Taller_Externo.Checked = _TblTecnico.Rows(0).Item("Chk_Taller_Externo")
            Chk_Tec_Domicilio.Checked = _TblTecnico.Rows(0).Item("Chk_Domicilio")
        End If

        AddHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_Taller_Externo_CheckedChanging
        AddHandler Chk_Tec_Domicilio.CheckedChanging, AddressOf Chk_Tec_Domicilio_CheckedChanging

    End Sub

    Sub Sb_Grabar_Asignacion()

        If String.IsNullOrEmpty(NuloPorNro(Cmb_Tecnico.SelectedValue, "")) Then
            Beep()
            ToastNotification.Show(Me, "DEBE ASIGNAR UN TECNICO U/O TALLER", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Cmb_Tecnico.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Nota.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA NOTA PARA LA ASIGNACION", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            Txt_Nota.Focus()
            Return
        End If

        If Fx_Fijar_Estado() Then

            _Row_Encabezado.Item("CodEstado") = "A"
            _Row_Encabezado.Item("CodTecnico_Asignado") = Cmb_Tecnico.SelectedValue
            _Row_Encabezado.Item("Tecnico_Asignado") = Trim(Cmb_Tecnico.Text)


            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Grabar = True
            Me.Close()

        End If

    End Sub

    Function Fx_Fijar_Estado() As Boolean

        Dim _Nota_Etapa_02 As String = Replace(Trim(Txt_Nota.Text), "'", "´")

        For _i = 0 To 31
            _Nota_Etapa_02 = Replace(_Nota_Etapa_02, Chr(_i), " ")
        Next


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Cn As New SqlConnection

        Try


            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            ' INSERTAR ENCABEZADO DE DOCUMENTO

            If _Accion = Accion.Nuevo Then

                Consulta_sql =
                               "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set" & vbCrLf &
                               "CodEstado = 'A',CodTecnico_Asignado = '" & Cmb_Tecnico.SelectedValue & "'" & vbCrLf &
                               "Where Id_Ot = " & _Id_Ot & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                               "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                               "(" & _Id_Ot & ",'A',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set Nota_Etapa_02 = '" & _Nota_Etapa_02 & "'" & vbCrLf &
                               "Where Id_Ot = " & _Id_Ot

            ElseIf _Accion = Accion.Editar Then

                Dim _Pais As String = _Row_Encabezado.Item("Pais")
                Dim _Ciudad As String = _Row_Encabezado.Item("Ciudad")
                Dim _Comuna As String = _Row_Encabezado.Item("Comuna")
                Dim _Direccion As String = _Row_Encabezado.Item("Direccion")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set" & vbCrLf &
                               "CodTecnico_Asignado = '" & Cmb_Tecnico.SelectedValue & "'," & vbCrLf &
                               "Pais = '" & _Pais & "'," & vbCrLf &
                               "Ciudad = '" & _Ciudad & "'," & vbCrLf &
                               "Comuna = '" & _Comuna & "'," & vbCrLf &
                               "Direccion = '" & _Direccion & "'" & vbCrLf &
                               "Where Id_Ot = " & _Id_Ot & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set Nota_Etapa_02 = '" & _Nota_Etapa_02 & "'" & vbCrLf &
                               "Where Id_Ot = " & _Id_Ot

            End If




            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            '**********************************'**********************************

            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            Return True


        Catch ex As Exception
            '
            'Consulta_sql = "ROLLBACK TRANSACTION"
            'Ej_consulta_IDU(Consulta_sql, cn1)
            MsgBox(ex.Message)
            myTrans.Rollback()

            Return 0
        End Try

    End Function

    Private Sub Frm_St_Estado_02_Asignacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Tecnicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tecnicos.Click

        If Fx_Tiene_Permiso(Me, "Stec0006") Then
            Dim Fm As New Frm_St_Lista_Tecnicos_Talleres 'Frm_St_Mant_Tecnicos_Talleres
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Dim _Solo_este_tecnico As Boolean

            If _Accion = Accion.Nuevo Then
                _Solo_este_tecnico = False
            ElseIf _Accion = Accion.Editar Then
                If Not _Editando_documento Then
                    _Solo_este_tecnico = True
                End If
            End If

            Sb_Cargar_Tecnicos(NuloPorNro(Cmb_Tecnico.SelectedValue, ""), _Solo_este_tecnico)
        End If

    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Estados", "Id_Ot = " & _Id_Ot & " And CodEstado = 'P'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede modificar el estado, ya que existe un estado posterior", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            _Editando_documento = True
            Beep()
            ToastNotification.Show(Me, "AHORA ES POSIBLE ACTUALIZAR EL DOCUMENTO", _
                                   Btn_Editar.Image, _
                                   1 * 1000, eToastGlowColor.Green, _
                                   eToastPosition.MiddleCenter)

            Btn_Grabar.Visible = True
            Btn_Cancelar.Visible = True
            Btn_Editar.Visible = False
            Me.ControlBox = False

            Txt_Nota.ReadOnly = False

            Txt_Nota.BackColor = Color.White
            Txt_Nota.FocusHighlightEnabled = True

            Sb_Cargar_Tecnicos(NuloPorNro(Cmb_Tecnico.SelectedValue, ""), False)

        End If

        Me.Refresh()
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub

   
    Private Sub Btn_Direccion_Servicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Direccion_Servicio.Click

        Dim Fm As New Frm_St_Documento_Dir_Serv_Domicilio
        Fm.Pro_DsDocumento = _DsDocumento

        Fm.Pro_Editar = _Editando_documento

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class