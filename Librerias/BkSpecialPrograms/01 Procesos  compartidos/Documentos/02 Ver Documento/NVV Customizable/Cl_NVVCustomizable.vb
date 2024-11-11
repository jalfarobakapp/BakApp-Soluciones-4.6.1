Public Class Cl_NVVCustomizable

    Public Property Ls_Detalle As List(Of Nvv_Customizable.Detalle)

    Public Sub New()

        Ls_Detalle = New List(Of Nvv_Customizable.Detalle)

        'Dim _Detalle As New Nvv_Customizable.Detalle

        '_Detalle.Idmaeddo = 0
        '_Detalle.NuevoItem = True
        '_Detalle.CodigoAlternativo = String.Empty
        '_Detalle.Descripcion = String.Empty
        '_Detalle.Cantidad = 0

        'Ls_Detalle.Add(_Detalle)

    End Sub

    Public Sub Fx_AgregarDetalle(_Detalle As Nvv_Customizable.Detalle)

        Ls_Detalle.Add(_Detalle)

    End Sub

    Public Sub Fx_EliminarDetalle(_Detalle As Nvv_Customizable.Detalle)

        Ls_Detalle.Remove(_Detalle)

    End Sub

    Public Sub Fx_ModificarDetalle(_Detalle As Nvv_Customizable.Detalle)

        Dim _DetalleModificar As Nvv_Customizable.Detalle = Ls_Detalle.Find(Function(x) x.Idmaeddo = _Detalle.Idmaeddo)

        _DetalleModificar = _Detalle

    End Sub



End Class

Namespace Nvv_Customizable

    Public Class Detalle

        Public Property Idmaeddo As Integer
        Public Property NuevoItem As Boolean
        Public Property CodigoAlternativo As String
        Public Property Descripcion As String
        Public Property Cantidad As Double

    End Class

End Namespace
