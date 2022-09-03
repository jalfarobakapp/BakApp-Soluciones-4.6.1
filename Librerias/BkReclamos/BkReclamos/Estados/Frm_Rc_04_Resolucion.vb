Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Rc_04_Resolucion

    Dim _Row_Producto As DataRow
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Reclamo As Integer
    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Grabar As Boolean
    Dim _Aceptado As Boolean
    Dim _Rechazado As Boolean
    Dim _Enviar_A_Validacion As Boolean
    Dim _Accion As Cl_Reclamo.Enum_Accion

    Public Property Pro_Cl_Reclamo As Cl_Reclamo
        Get
            Return _Cl_Reclamo
        End Get
        Set(value As Cl_Reclamo)
            _Cl_Reclamo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public ReadOnly Property Pro_Aceptado As Boolean
        Get
            Return _Aceptado
        End Get
    End Property
    Public ReadOnly Property Pro_Rechazado As Boolean
        Get
            Return _Rechazado
        End Get
    End Property
    Public ReadOnly Property Pro_Enviar_A_Validacion As Boolean
        Get
            Return _Enviar_A_Validacion
        End Get
    End Property
    Public Sub New(Accion As Cl_Reclamo.Enum_Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aprobar.ForeColor = Color.White
            Btn_Rechazar.ForeColor = Color.White
            Btn_Reenviar_A_Validacion.ForeColor = Color.White
            Btn_Cancelar.ForeColor = Color.White
            Btn_Ver_Motivo_Rechazo.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Rc_04_Resolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Id_Reclamo = _Cl_Reclamo.Id_Reclamo

        If _Accion = Cl_Reclamo.Enum_Accion.Nuevo Then

            Sb_Habilitar_Controles(True)

        ElseIf _Accion = Cl_Reclamo.Enum_Accion.Editar Then

            Btn_Ver_Motivo_Rechazo.Visible = _Cl_Reclamo.Pro_Row_Resolucion.Item("Rechazada")
            Btn_Reenviar_A_Validacion.Visible = _Cl_Reclamo.Pro_Row_Resolucion.Item("Rechazada")
            Btn_Editar.Visible = True
            Sb_Habilitar_Controles(False)

        End If

        If Not IsNothing(_Cl_Reclamo.Pro_Row_Resolucion) Then

            Txt_Resolucion.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Resolucion")
            Txt_Metod_Utilizar.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Metod_Utilizar")
            Txt_Conclusion.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Conclusion")

            Txt_Acciones_Correctivas.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Acciones_Correctivas")
            Txt_Acciones_Preventivas.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Acciones_Preventivas")
            Txt_Causa_Raiz.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Causa_Raiz")
            Txt_Detalle_Visita.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Detalle_Visita")
            Txt_Medidas_Preventivas.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Medidas_Preventivas")

            Chk_Visita_Cliente.Checked = _Cl_Reclamo.Pro_Row_Resolucion.Item("Visita_Cliente")

            Txt_Respuesta_Cliente.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Respuesta_Cliente")

            Btn_Reenviar_A_Validacion.Enabled = (_Cl_Reclamo.Estado = "RSL")
            Btn_Reenviar_A_Validacion.Visible = (_Cl_Reclamo.Estado = "RSL")

            Btn_Aprobar.Visible = (_Cl_Reclamo.Estado = "VAL")
            Btn_Rechazar.Visible = (_Cl_Reclamo.Estado = "VAL")

            If _Cl_Reclamo.Estado = "RCI" Or _Cl_Reclamo.Estado = "RSL" Or _Cl_Reclamo.Estado = "VAL" Then
                Bar2.Visible = True
            Else
                Bar2.Visible = False
            End If

            St_Detalle_Visita.Enabled = Chk_Visita_Cliente.Checked

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Resolucion = Replace(Txt_Resolucion.Text, "'", "''")
        Dim _Respuesta_Cliente = Replace(Txt_Respuesta_Cliente.Text, "'", "''")
        Dim _Metod_Utilizar = Replace(Txt_Metod_Utilizar.Text, "'", "''")
        Dim _Conclusion = Replace(Txt_Conclusion.Text, "'", "''")

        Dim _Acciones_Correctivas = Replace(Txt_Acciones_Correctivas.Text, "'", "''")
        Dim _Acciones_Preventivas = Replace(Txt_Acciones_Preventivas.Text, "'", "''")
        Dim _Causa_Raiz = Replace(Txt_Causa_Raiz.Text, "'", "''")
        Dim _Detalle_Visita = Replace(Txt_Detalle_Visita.Text, "'", "''")
        Dim _Medidas_Preventivas = Replace(Txt_Medidas_Preventivas.Text, "'", "''")

        Dim _Visita_Cliente = CInt(Chk_Visita_Cliente.Checked * -1)

        If Fx_Se_Puede_Grabar() Then

            'If _Accion = Cl_Reclamo.Enum_Accion.Nuevo Then

            If IsNothing(_Cl_Reclamo.Pro_Row_Resolucion) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'RSL' Where Id_Reclamo = " & _Id_Reclamo & " 
                                --Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario) Values " & Space(0) &
                                "--(" & _Id_Reclamo & ",'RSL','" & FUNCIONARIO & "')
                                Insert Into " & _Global_BaseBk & "Zw_Reclamo_Resolucion (Id_Reclamo,CodFuncionario,Resolucion," &
                                "Respuesta_Cliente,Activa,Metod_Utilizar,Conclusion,Acciones_Correctivas,Acciones_Preventivas," &
                                "Causa_Raiz,Detalle_Visita,Medidas_Preventivas,Visita_Cliente) Values 
                                (" & _Id_Reclamo & ",'" & FUNCIONARIO & "','" & _Resolucion & "','" & _Respuesta_Cliente & "',1," &
                                "'" & _Metod_Utilizar & "','" & _Conclusion & "','" & _Acciones_Correctivas & "','" & _Acciones_Preventivas &
                                "','" & _Causa_Raiz & "','" & _Detalle_Visita & "','" & _Medidas_Preventivas & "'," & _Visita_Cliente & ")"
            Else

                Dim _Id_Resolucion = _Cl_Reclamo.Pro_Row_Resolucion.Item("Id_Resolucion")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo_Resolucion 
                                Set Resolucion = '" & _Resolucion & "'," &
                                "Metod_Utilizar = '" & _Metod_Utilizar & "'," &
                                "Conclusion = '" & _Conclusion & "'," &
                                "Respuesta_Cliente = '" & _Respuesta_Cliente & "'," &
                                "Acciones_Preventivas = '" & _Acciones_Preventivas & "'," &
                                "Acciones_Correctivas = '" & _Acciones_Correctivas & "'," &
                                "Causa_Raiz = '" & _Causa_Raiz & "'," &
                                "Detalle_Visita = '" & _Detalle_Visita & "'," &
                                "Medidas_Preventivas = '" & _Medidas_Preventivas & "'," &
                                "Visita_Cliente = " & _Visita_Cliente &
                                "Where Id_Resolucion = " & _Id_Resolucion

            End If

            _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            If _Grabar Then

                Btn_Editar.Visible = True
                Sb_Habilitar_Controles(False)

                _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)

                If _Cl_Reclamo.Estado = "RCI" Or _Cl_Reclamo.Estado = "RSL" Then

                    Btn_Reenviar_A_Validacion.Enabled = True
                    Btn_Reenviar_A_Validacion.Visible = True

                    If MessageBoxEx.Show(Me, "¿Desea enviar la resolución a validación?", "Enviar a validación",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Call Btn_Reenviar_A_Validacion_Click(Nothing, Nothing)
                    End If

                End If

            End If

        End If

    End Sub

    Private Function Fx_Se_Puede_Grabar() As Boolean

        '0 St_Resolucion
        '1 St_Metodo_Utilizar
        '2 St_Causa_Raiz
        '3 St_Conclusion
        '4 St_Acciones_Correctivas
        '5 St_Acciones_Preventivas
        '6 St_Respuesta_Cliente
        '7 St_Medidas_Preventivas
        '8 St_Detalle_Visita

        If String.IsNullOrEmpty(Txt_Resolucion.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA RESOLUCION",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 0
            Txt_Resolucion.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Trim(Txt_Metod_Utilizar.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA RESPUESTA AL CLIENTE",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 1
            Txt_Metod_Utilizar.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Causa_Raiz.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA CAUSA RAIZ",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 7
            Txt_Causa_Raiz.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Conclusion.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA CONCLUSION",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 2
            Txt_Conclusion.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Acciones_Correctivas.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA ACCIONES CORRECTIVAS",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 4
            Txt_Acciones_Correctivas.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Acciones_Preventivas.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA ACCIONES PREVENTIVAS",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 5
            Txt_Acciones_Preventivas.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Respuesta_Cliente.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA RESPUESTA AL CLIENTE",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 6
            Txt_Respuesta_Cliente.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Medidas_Preventivas.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA MEDIDAS PREVENTIVAS",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Stab_Control.SelectedTabIndex = 3
            Txt_Medidas_Preventivas.Focus()
            Return False
        End If

        If Chk_Visita_Cliente.Checked Then

            If String.IsNullOrEmpty(Txt_Detalle_Visita.Text) Then
                Beep()
                ToastNotification.Show(Me, "FALTA DETALLE DE VISITA",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
                Stab_Control.SelectedTabIndex = 8
                Txt_Detalle_Visita.Focus()
                Return False
            End If

        End If

        Return True

    End Function

    Sub Sb_Habilitar_Controles(_Habilitar As Boolean)

        Btn_Grabar.Enabled = _Habilitar

        Btn_Aprobar.Enabled = Not _Habilitar
        Btn_Rechazar.Enabled = Not _Habilitar
        Btn_Reenviar_A_Validacion.Enabled = Not _Habilitar

        Dim _BackColor As Color

        If _Habilitar Then
            If Global_Thema = Enum_Themas.Oscuro Then
                _BackColor = Color.Black
            Else
                _BackColor = Color.White
            End If
        Else
            If Global_Thema = Enum_Themas.Oscuro Then
                _BackColor = Color.Black
            Else
                _BackColor = Color.AliceBlue
            End If
        End If

        Txt_Resolucion.BackColor = _BackColor
        Txt_Resolucion.ReadOnly = Not _Habilitar
        Txt_Metod_Utilizar.BackColor = _BackColor
        Txt_Metod_Utilizar.ReadOnly = Not _Habilitar
        Txt_Conclusion.BackColor = _BackColor
        Txt_Conclusion.ReadOnly = Not _Habilitar

        Txt_Acciones_Correctivas.BackColor = _BackColor
        Txt_Acciones_Correctivas.ReadOnly = Not _Habilitar

        Txt_Acciones_Preventivas.BackColor = _BackColor
        Txt_Acciones_Preventivas.ReadOnly = Not _Habilitar

        Txt_Causa_Raiz.BackColor = _BackColor
        Txt_Causa_Raiz.ReadOnly = Not _Habilitar

        Txt_Detalle_Visita.BackColor = _BackColor
        Txt_Detalle_Visita.ReadOnly = Not _Habilitar

        Txt_Medidas_Preventivas.BackColor = _BackColor
        Txt_Medidas_Preventivas.ReadOnly = Not _Habilitar

        Txt_Respuesta_Cliente.BackColor = _BackColor
        Txt_Respuesta_Cliente.ReadOnly = Not _Habilitar

        Chk_Visita_Cliente.Enabled = _Habilitar

        If Btn_Editar.Visible Then
            Btn_Editar.Enabled = Not _Habilitar
            Btn_Grabar.Enabled = _Habilitar
            Btn_Cancelar.Visible = _Habilitar
        End If

        Select Case _Cl_Reclamo.Estado

            Case "RCI", "RSL"

                Txt_Resolucion.BackColor = _BackColor
                Txt_Resolucion.ReadOnly = Not _Habilitar
                Txt_Metod_Utilizar.BackColor = _BackColor
                Txt_Metod_Utilizar.ReadOnly = Not _Habilitar
                Txt_Conclusion.BackColor = _BackColor
                Txt_Conclusion.ReadOnly = Not _Habilitar
                Txt_Acciones_Correctivas.BackColor = _BackColor
                Txt_Acciones_Correctivas.ReadOnly = Not _Habilitar
                Txt_Acciones_Preventivas.BackColor = _BackColor
                Txt_Acciones_Preventivas.ReadOnly = Not _Habilitar
                Txt_Causa_Raiz.BackColor = _BackColor
                Txt_Causa_Raiz.ReadOnly = Not _Habilitar
                Txt_Detalle_Visita.BackColor = _BackColor
                Txt_Detalle_Visita.ReadOnly = Not _Habilitar
                Chk_Visita_Cliente.Enabled = _Habilitar
                Txt_Medidas_Preventivas.BackColor = _BackColor
                Txt_Medidas_Preventivas.ReadOnly = Not _Habilitar


                St_Detalle_Visita.Enabled = Chk_Visita_Cliente.Checked

                Txt_Resolucion.Focus()

            Case Else

                If Global_Thema = Enum_Themas.Oscuro Then
                    _BackColor = Color.Black
                Else
                    _BackColor = Color.AliceBlue
                End If


                Txt_Resolucion.BackColor = _BackColor
                Txt_Resolucion.ReadOnly = True
                Txt_Metod_Utilizar.BackColor = _BackColor
                Txt_Metod_Utilizar.ReadOnly = True
                Txt_Conclusion.BackColor = _BackColor
                Txt_Conclusion.ReadOnly = True
                Txt_Acciones_Correctivas.BackColor = _BackColor
                Txt_Acciones_Correctivas.ReadOnly = True
                Txt_Acciones_Preventivas.BackColor = _BackColor
                Txt_Acciones_Preventivas.ReadOnly = True
                Txt_Causa_Raiz.BackColor = _BackColor
                Txt_Causa_Raiz.ReadOnly = True
                Txt_Detalle_Visita.BackColor = _BackColor
                Txt_Detalle_Visita.ReadOnly = True
                Txt_Medidas_Preventivas.BackColor = _BackColor
                Txt_Medidas_Preventivas.ReadOnly = True

                Chk_Visita_Cliente.Enabled = False

                If _Cl_Reclamo.Estado = "VAL" Then
                    Btn_Ver_Motivo_Rechazo.Visible = False
                    Btn_Reenviar_A_Validacion.Visible = False
                End If

                If _Habilitar Then
                    Stab_Control.SelectedTabIndex = 6
                    Txt_Respuesta_Cliente.Focus()
                End If

        End Select

        Me.Refresh()

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Habilitar As Boolean
        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")
        Dim _Permiso As String

        If _Cl_Reclamo.Estado = "VAL" Then

            _Permiso = "RclVal" & _Tipo_Reclamo

            If Fx_Tiene_Permiso(Me, _Permiso) Then

                Btn_Ver_Motivo_Rechazo.Visible = False
                Btn_Reenviar_A_Validacion.Visible = False
                _Habilitar = True

            End If

        Else

            _Permiso = "RclRes" & _Tipo_Reclamo

            If Fx_Tiene_Permiso(Me, _Permiso) Then

                _Habilitar = True

            End If

        End If

        If _Habilitar Then

            Sb_Habilitar_Controles(True)

            Beep()
            ToastNotification.Show(Me, "EDICION ACTIVA",
                                   Btn_Editar.Image,
                                   1 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        Txt_Resolucion.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Resolucion")
        Txt_Respuesta_Cliente.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Respuesta_Cliente")

        Beep()
        ToastNotification.Show(Me, "EDICION CANCELADA, LOS CAMBIOS SERAN REVERTIDOS",
                               Btn_Editar.Image,
                               1 * 1000, eToastGlowColor.Green,
                               eToastPosition.MiddleCenter)

        Txt_Resolucion.Text = _Cl_Reclamo.Pro_Row_Resolucion.Item("Resolucion")
        Sb_Habilitar_Controles(False)

    End Sub
    Private Sub Btn_Aprobar_Click(sender As Object, e As EventArgs) Handles Btn_Aprobar.Click

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")

        Dim _Permiso = "RclVal" & _Tipo_Reclamo

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Dim Chk_Cambio_Mercaderia As New Command ' = New DevComponents.DotNetBar.Command(Me.components)
            Chk_Cambio_Mercaderia.Checked = False
            Chk_Cambio_Mercaderia.Name = "Chk_Cambio_Mercaderia"
            Chk_Cambio_Mercaderia.Text = "CAMBIO DE MERCADERIA"

            Dim Chk_Devolucion As New Command
            Chk_Devolucion.Checked = False
            Chk_Devolucion.Name = "Chk_Devolucion"
            Chk_Devolucion.Text = "DEVOLUCION"

            Dim Chk_Destruccion_Cliente As New Command
            Chk_Destruccion_Cliente.Checked = False
            Chk_Destruccion_Cliente.Name = "Chk_Destruccion_Cliente"
            Chk_Destruccion_Cliente.Text = "DESTRUCCION CLIENTE"

            Dim _Opciones() As Command = {Chk_Cambio_Mercaderia, Chk_Devolucion, Chk_Destruccion_Cliente}

            Dim _Info As New TaskDialogInfo("Validación de reclamo",
                              eTaskDialogIcon.ShieldOk,
                              "Indique su opción",
                              "Debe indicar la opción que corresponde a la gestión que se hara posterior a la validación de este reclamo",
                              eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                              , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

            If _Resultado = eTaskDialogResult.Ok Then

                If Chk_Cambio_Mercaderia.Checked Or Chk_Devolucion.Checked Or Chk_Destruccion_Cliente.Checked Then

                    Dim _Codigo_Accion As String
                    Dim _Sub_Estado As String
                    Dim _Observacion As String

                    If Chk_Cambio_Mercaderia.Checked Then

                        _Codigo_Accion = "CM" : _Observacion = "CAMBIO DE MERCADERIA" : _Sub_Estado = "REM"

                    ElseIf Chk_Destruccion_Cliente.Checked Then

                        _Codigo_Accion = "DC" : _Observacion = "DESTRUCCION CLIENTE" : _Sub_Estado = "RAC"

                    ElseIf Chk_Devolucion.Checked Then

                        _Codigo_Accion = "DV" : _Observacion = "DEVOLUCION" : _Sub_Estado = "REM"

                    End If

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'AVI',Sub_Estado = '" & _Sub_Estado & "',Codigo_Accion = '" & _Codigo_Accion & "' 
                                Where Id_Reclamo = " & _Id_Reclamo & "
                                Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values 
                                (" & _Id_Reclamo & ",'VAL','" & FUNCIONARIO & "','" & _Observacion & "')"

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                        _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                        _Aceptado = True
                        Dim Fm As New Frm_Rc_06_Aviso_Cliente
                        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
                        Fm.ShowDialog(Me)
                        Me.Close()

                    End If

                Else

                    MessageBoxEx.Show(Me, "Debe indicar una opción para la gestión posterior a la validación de reclamo", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            End If

        End If


    End Sub

    Private Sub Btn_Rechazar_Click(sender As Object, e As EventArgs) Handles Btn_Rechazar.Click

        Dim _Motivo_Rechazo As String

        Dim Chk_Reenviar_Resolucion As New Command
        Chk_Reenviar_Resolucion.Checked = False
        Chk_Reenviar_Resolucion.Name = "Chk_Reenviar_Resolucion"
        Chk_Reenviar_Resolucion.Text = "REENVIAR A RESOLUCION"

        Dim Chk_No_Aplica_Cambio_Ni_Devolucion As New Command
        Chk_No_Aplica_Cambio_Ni_Devolucion.Checked = False
        Chk_No_Aplica_Cambio_Ni_Devolucion.Name = "Chk_No_Aplica_Cambio_Ni_Devolucion"
        Chk_No_Aplica_Cambio_Ni_Devolucion.Text = "NO APLICA CAMBIO NI DEVOLUCION"

        Dim _Opciones() As Command = {Chk_Reenviar_Resolucion, Chk_No_Aplica_Cambio_Ni_Devolucion}

        Dim _Info As New TaskDialogInfo("Rechazar reclamo",
                                  eTaskDialogIcon.ShieldStop,
                                  "Indique su opción",
                                  "Debe indicar la opción que corresponde a la gestión que se hara posterior al rechzao de este reclamo",
                                  eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                                  , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado = eTaskDialogResult.Ok Then

            Dim _Permiso As String

            If Chk_Reenviar_Resolucion.Checked Then
                _Permiso = "Rcl00020"
            ElseIf Chk_No_Aplica_Cambio_Ni_Devolucion.Checked Then
                _Permiso = "RclVal" & _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")
            End If

            If Fx_Tiene_Permiso(Me, _Permiso) Then

                Dim _Aceptar As Boolean = InputBox_Bk(Me, "Motivo del rechazo", "Resolución rechazada", _Motivo_Rechazo,
                                                              True, _Tipo_Mayus_Minus.Mayusculas,, True)

                If _Aceptar Then

                    _Motivo_Rechazo = Replace(_Motivo_Rechazo, "'", "''")
                    Dim _Id_Resolucion = _Cl_Reclamo.Pro_Row_Resolucion.Item("Id_Resolucion")
                    Dim _Resolucion = Replace(Txt_Resolucion.Text, "'", "''")

                    If Chk_Reenviar_Resolucion.Checked Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'RSL' 
                            Where Id_Reclamo = " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo") & vbCrLf & "
                            Delete " & _Global_BaseBk & "Zw_Reclamo_Estados Where Id_Reclamo = " & _Id_Reclamo & " And Estado = 'RSL'
                            Update " & _Global_BaseBk & "Zw_Reclamo_Resolucion Set Rechazada = 1,Motivo_Rechazo = '" & _Motivo_Rechazo & "' 
                            Where Id_Resolucion = " & _Id_Resolucion
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                        _Cl_Reclamo.Sb_Enviar_Correo(Me, "RSL", _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo"), False)

                        _Rechazado = True
                        Me.Close()

                    ElseIf Chk_No_Aplica_Cambio_Ni_Devolucion.Checked Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'AVI',Sub_Estado = '',Codigo_Accion = 'NO' 
                                    Where Id_Reclamo = " & _Id_Reclamo & "
                                    Update " & _Global_BaseBk & "Zw_Reclamo_Resolucion Set Motivo_Rechazo = '" & _Motivo_Rechazo & "'
                                    Where Id_Resolucion = " & _Id_Resolucion & "
                                    Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values 
                                    (" & _Id_Reclamo & ",'VAL','" & FUNCIONARIO & "','NO APLICA CAMBIO NI DEVOLUCION')"

                        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                            _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                            _Aceptado = True

                            Dim Fm As New Frm_Rc_06_Aviso_Cliente
                            Fm.Pro_Cl_Reclamo = _Cl_Reclamo
                            Fm.ShowDialog(Me)
                            Me.Close()

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Ver_Motivo_Rechazo_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Motivo_Rechazo.Click

        Dim _Motivo_Rechazo = _Cl_Reclamo.Pro_Row_Resolucion.Item("Motivo_Rechazo")
        MessageBoxEx.Show(Me, _Motivo_Rechazo, "Motivo del rechazo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Dim Fm As New Frm_Archivo_TXT
        'Fm.Pro_Texto_Log = _Cl_Reclamo.Pro_Tbl_Resolucion.Rows(0).Item("Motivo_Rechazo")
        'Fm.Txt_Texto.ReadOnly = True
        'Fm.Btn_Grabar.Visible = False
        'Fm.ShowDialog(Me)

    End Sub

    Private Sub Btn_Reenviar_A_Validacion_Click(sender As Object, e As EventArgs) Handles Btn_Reenviar_A_Validacion.Click

        Dim _Id_Resolucion = _Cl_Reclamo.Pro_Row_Resolucion.Item("Id_Resolucion")

        If Fx_Se_Puede_Grabar() Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'VAL' 
                            Where Id_Reclamo = " & _Id_Reclamo & vbCrLf & "
                            Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario) Values " & Space(0) &
                            "(" & _Id_Reclamo & ",'RSL','" & FUNCIONARIO & "')
                            Update " & _Global_BaseBk & "Zw_Reclamo_Resolucion Set Rechazada = 0 Where Id_Resolucion = " & _Id_Resolucion & vbCrLf &
                            "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Archivos (Id_Reclamo,Estado,Sub_Estado,Nombre_Archivo,Archivo) " & vbCrLf &
                            "Select Id_Reclamo,'VAL','',Nombre_Archivo,Archivo From " & _Global_BaseBk & "Zw_Reclamo_Archivos " &
                            "Where Id_Reclamo = " & _Id_Reclamo & " And Estado = 'RCI'" & vbCrLf &
                            "And Nombre_Archivo Not In (Select Nombre_Archivo From " & _Global_BaseBk & "Zw_Reclamo_Archivos " &
                            "Where Id_Reclamo = " & _Id_Reclamo & " And Estado = 'VAL')"

            _Grabar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            If _Grabar Then

                _Cl_Reclamo.Sb_Enviar_Correo(Me, "VAL", _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo"), True)
                _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)

                _Enviar_A_Validacion = True
                Me.Close()

            End If

        End If

    End Sub

    Private Sub Chk_Visita_Cliente_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Visita_Cliente.CheckedChanged

        St_Detalle_Visita.Enabled = Chk_Visita_Cliente.Checked

        If Chk_Visita_Cliente.Checked Then
            Stab_Control.SelectedTabIndex = 8
            Txt_Detalle_Visita.Focus()
        End If

    End Sub
End Class