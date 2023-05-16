Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms
Imports System.Data.SqlClient


Public Class Frm_St_Estado_06_Aviso_Cliente

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ot As Integer
    Dim _Grabar As Boolean
    Dim _DsDocumento As DataSet

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Row_Notas As DataRow
    Dim _RowEntidad As DataRow
    Dim _Tbl_DetProd_Cov As DataTable

    Dim _Motivo_no_reparo As String

    Dim _Horas_Mano_de_Obra As Double
    Dim Imagenes_32x32 As ImageList

    Dim _Fijar_Estado As Boolean

    Dim _Accion As Accion
    Dim _Id_Correo As Integer

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public Sub New(ByVal Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Estado_06_Aviso_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Accion = Accion.Editar Then

            Txt_Nota.ReadOnly = True
            Txt_Nota.BackColor = Color.LightGray
            Txt_Nota.FocusHighlightEnabled = False
            Btn_Fijar_Estado.Visible = False
            Txt_Nota.Text = _Row_Notas.Item("Nota_Etapa_06")

            If _Row_Encabezado.Item("CodEstado") = "CE" Then
                Btn_Editar.Visible = False
            End If

            'ElseIf _Accion = Accion.Nuevo Then
            '    Txt_Nota.FocusHighlightEnabled = True

        End If

        Btn_Informacion_Entidad.Visible = True

        Me.Refresh()

    End Sub

    Private Sub Btn_Informacion_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informacion_Entidad.Click
        Dim Fm As New Frm_InfoEnt_Informacion_General(_RowEntidad)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub



    Private Sub Btn_Fijar_Estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fijar_Estado.Click
        Sb_Fijar_Estado()
    End Sub

    Sub Sb_Fijar_Estado()

        If String.IsNullOrEmpty(Txt_Nota.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA INGRESAR ALGUN COMENTARIO",
                                   Imagenes_32x32.Images.Item("warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Nota.Focus()
            Return
        End If

        If Fx_Fijar_Estado() Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Fijar_Estado = True
            Me.Close()
        End If

    End Sub

    Function Fx_Fijar_Estado() As Boolean

        Consulta_sql = String.Empty


        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Nota_Etapa_06 As String = Txt_Nota.Text

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                       "Nota_Etapa_06 = '" & _Nota_Etapa_06 & "'" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

        '**********************************'**********************************


        ' ACTUALIZAR ENCABEZADO DE DOCUMENTO

        If _Accion = Accion.Nuevo Then
            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                           "CodEstado = 'F'" & vbCrLf &
                           "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf

            ' ACTUALIZAR ESTADO

            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                           "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                           "(" & _Id_Ot & ",'V',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf


        End If
        '**********************************'**********************************


        Fx_Fijar_Estado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


    End Function

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(ByVal value As DataSet)

            _DsDocumento = value
            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_DetProd_Cov = _DsDocumento.Tables(7)

        End Set
    End Property

    Public Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(ByVal value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Public Property Pro_Id_Ot() As Integer
        Get
            Return _Id_Ot
        End Get
        Set(ByVal value As Integer)
            _Id_Ot = value
        End Set
    End Property

    Public Property Pro_Fijar_Estado() As Boolean
        Get
            Return _Fijar_Estado
        End Get
        Set(ByVal value As Boolean)
            _Fijar_Estado = value
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

    Public Property Pro_IdCorreo() As Integer
        Get

        End Get
        Set(ByVal value As Integer)
            _Id_Correo = value
        End Set
    End Property


#End Region

    Private Sub Frm_St_Estado_06_Aviso_Cliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Enviar_correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Enviar_correo.Click

        Dim _Nro_Ot = _Row_Encabezado.Item("Nro_Ot")

        Dim _Asunto = "Aviso por reparación OT Nro: " & _Nro_Ot
        Dim _Adjunto As String

        Dim Envio_Occ_Mail As New Class_Outlook
        Dim _Para As String = _Row_Encabezado.Item("Email_Contacto")
        Dim _Cuerpo As String = Txt_Nota.Text

        Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Adjunto, _Asunto, _Cuerpo, False)

        Dim _CodEstado = Trim(_Row_Encabezado.Item("CodEstado"))

        If _CodEstado = "V" Then

            If MessageBoxEx.Show(Me, "¿Se envío el correo de aviso?",
                                 "Aviso al cliente",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Sb_Fijar_Estado()

            End If

        End If

    End Sub

End Class
