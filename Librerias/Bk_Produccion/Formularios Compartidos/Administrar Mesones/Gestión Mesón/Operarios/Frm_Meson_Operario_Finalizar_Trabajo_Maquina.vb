Imports Bk_Produccion

Public Class Frm_Meson_Operario_Finalizar_Trabajo_Maquina

    Dim _Hacer_Gestion As Boolean
    Dim _Accion_Gestion As Enum_Accion

    Public Property Pro_Hacer_Gestion As Boolean
        Get
            Return _Hacer_Gestion
        End Get
        Set(value As Boolean)
            _Hacer_Gestion = value
        End Set
    End Property

    Public Property Pro_Accion_Gestion As Enum_Accion
        Get
            Return _Accion_Gestion
        End Get
        Set(value As Enum_Accion)
            _Accion_Gestion = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Meson_Operario_Finalizar_Trabajo_Maquina_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Fabricado_Completamente_Click(sender As Object, e As EventArgs) Handles Btn_Fabricado_Completamente.Click
        Sb_Hacer_Gestion(Enum_Accion.Fabricados_Completamente)
    End Sub

    Private Sub Btn_Avance_Porcentaje_Click(sender As Object, e As EventArgs) Handles Btn_Avance_Porcentaje.Click
        Sb_Hacer_Gestion(Enum_Accion.Solo_Un_Porcentaje)
    End Sub

    Private Sub Btn_Quitar_Por_Problemas_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Por_Problemas.Click
        Sb_Hacer_Gestion(Enum_Accion.Quitar_Productos_Problemas)
    End Sub

    Private Sub Btn_Solo_Quitar_Click(sender As Object, e As EventArgs) Handles Btn_Solo_Quitar.Click
        Sb_Hacer_Gestion(Enum_Accion.Quitar_Productos_Por_Error_Solo_Quitar)
    End Sub

    Private Sub Btn_Observaciones_Click(sender As Object, e As EventArgs) Handles Btn_Observaciones.Click
        Sb_Hacer_Gestion(Enum_Accion.Agregar_Observaciones)
    End Sub

    Public Enum Enum_Accion
        Fabricados_Completamente
        Solo_Un_Porcentaje
        Quitar_Productos_Problemas
        Quitar_Productos_Por_Error_Solo_Quitar
        Agregar_Observaciones
    End Enum

    Sub Sb_Hacer_Gestion(_Accion As Enum_Accion)

        Select Case _Accion
            Case Enum_Accion.Fabricados_Completamente
                Btn_Fabricado_Completamente.Tag = True
                _Accion_Gestion = Enum_Accion.Fabricados_Completamente
            Case Enum_Accion.Solo_Un_Porcentaje
                Btn_Avance_Porcentaje.Tag = True
                _Accion_Gestion = Enum_Accion.Solo_Un_Porcentaje
            Case Enum_Accion.Quitar_Productos_Problemas
                Btn_Quitar_Por_Problemas.Tag = True
                _Accion_Gestion = Enum_Accion.Quitar_Productos_Problemas
            Case Enum_Accion.Quitar_Productos_Por_Error_Solo_Quitar
                Btn_Solo_Quitar.Tag = True
                _Accion_Gestion = Enum_Accion.Quitar_Productos_Por_Error_Solo_Quitar
            Case Enum_Accion.Agregar_Observaciones
                Btn_Observaciones.Tag = True
                _Accion = 5
        End Select

        _Hacer_Gestion = True
        Me.Close()

    End Sub

    Private Sub Frm_Meson_Operario_Finalizar_Trabajo_Maquina_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Dim _Key As Keys = e.KeyValue

        Select Case _Key
            Case Keys.NumPad1, Keys.D1
                Call Btn_Fabricado_Completamente_Click(Nothing, Nothing)
            Case Keys.NumPad2, Keys.D2
                Call Btn_Avance_Porcentaje_Click(Nothing, Nothing)
            Case Keys.NumPad3, Keys.D3
                Call Btn_Quitar_Por_Problemas_Click(Nothing, Nothing)
            Case Keys.NumPad4, Keys.D4
                Call Btn_Solo_Quitar_Click(Nothing, Nothing)
            Case Keys.NumPad5, Keys.D5

            Case Keys.Escape
                Me.Close()
        End Select

    End Sub
End Class