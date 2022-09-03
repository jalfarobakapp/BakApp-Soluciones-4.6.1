Public Class Frm_Ver_Imagen

    Dim _Imagen As Image
    Dim _Aceptar As Boolean
    Dim _Cancelar As Boolean

    Public Property Imagen As Image
        Get
            Return _Imagen
        End Get
        Set(value As Image)
            _Imagen = value
        End Set
    End Property

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Property Cancelar As Boolean
        Get
            Return _Cancelar
        End Get
        Set(value As Boolean)
            _Cancelar = value
        End Set
    End Property

    Private Sub Frm_Ver_Imagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Color_Botones_Barra(Bar1)
        Pbx_Imagen.Image = _Imagen
    End Sub

    Private Sub Frm_Ver_Imagen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        _Aceptar = True
        Me.Close()
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
        Me.Close()
    End Sub

End Class
