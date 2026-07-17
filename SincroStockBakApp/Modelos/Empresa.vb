Public Class Empresa
    Public Property Numero As String
    Public Property EntidadDeCompra As DataTable
    Public Property EntidadDeVenta As DataTable

    ' Modalidades
    Public Property ModalidadOCC As DataTable
    Public Property ModalidadFCV As DataTable
    Public Property ModalidadNVV As DataTable
    Public Property ModalidadFCC As DataTable

    ' Constructor para inicializar las tablas
    Public Sub New()
        EntidadDeCompra = New DataTable()
        EntidadDeVenta = New DataTable()

        ModalidadOCC = New DataTable()
        ModalidadFCV = New DataTable()
        ModalidadNVV = New DataTable()
        ModalidadFCC = New DataTable()
    End Sub
End Class
