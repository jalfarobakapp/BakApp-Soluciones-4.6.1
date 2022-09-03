Public Class Frm_TrabMaq_Opciones_Cierre

    Dim _Hacer_Gestion As Boolean
    Dim _Accion_Gestion As Enum_Accion

    Public Property Hacer_Gestion As Boolean
        Get
            Return _Hacer_Gestion
        End Get
        Set(value As Boolean)
            _Hacer_Gestion = value
        End Set
    End Property

    Public Property Accion_Gestion As Enum_Accion
        Get
            Return _Accion_Gestion
        End Get
        Set(value As Enum_Accion)
            _Accion_Gestion = value
        End Set
    End Property

    Enum Enum_Accion
        Trabajo_Terminado
        Dejar_Pendiente
        Continuar
    End Enum

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_TrabMaq_Opciones_Cierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Frm_TrabMaq_Opciones_Cierre_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Hacer_Gestion(_Accion As Enum_Accion)

        Select Case _Accion
            Case Enum_Accion.Trabajo_Terminado
                Btn_Trabajo_Terminado.Tag = True
            Case Enum_Accion.Dejar_Pendiente
                Btn_Dejar_Pendiente.Tag = True
            Case Enum_Accion.Continuar
                Btn_Continuar.Tag = True
        End Select

        _Accion_Gestion = _Accion

        _Hacer_Gestion = True
        Me.Close()

    End Sub

    Private Sub Btn_Trabajo_Terminado_Click(sender As Object, e As EventArgs) Handles Btn_Trabajo_Terminado.Click
        Sb_Hacer_Gestion(Enum_Accion.Trabajo_Terminado)
    End Sub

    Private Sub Btn_Dejar_Pendiente_Click(sender As Object, e As EventArgs) Handles Btn_Dejar_Pendiente.Click
        Sb_Hacer_Gestion(Enum_Accion.Dejar_Pendiente)
    End Sub

    Private Sub Btn_Continuar_Click(sender As Object, e As EventArgs) Handles Btn_Continuar.Click
        Sb_Hacer_Gestion(Enum_Accion.Continuar)
    End Sub
End Class
