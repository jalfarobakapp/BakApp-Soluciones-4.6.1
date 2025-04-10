Public Class Configuracion
    Public Property Ls_Conexiones As List(Of Conexion)
    Public Property Global_BaseBk As String
    Public Property BodegaFacturacion As BodegaFacturacion
    Public Property Vendedor As String
    Public Property NoVendedor As String
    Public Property Responsable As String
    Public Property NomResponsable As String
    Public Property RutaEtiquetas As String
    Public Property Facturar As Boolean
    Public Property DocEmitir As String
    Public Property Concepto_R As String
    Public Property Concepto_D As String
    Public Property Pago As Pago
    Public Property ModalidadFac As String
End Class

Public Class BodegaFacturacion
    Public Property Empresa As String
    Public Property Razon As String
    Public Property Kosu As String
    Public Property Nokosu As String
    Public Property Kobo As String
    Public Property Nokobo As String
End Class

Public Class Pago
    Public Property Modalidad As String
    Public Property Razon As String
    Public Property Empresa As String
    Public Property RutEmpresa As String
    Public Property Sucursal As String
    Public Property NomSucursal As String
    Public Property Caja As String
    Public Property NomCaja As String
    Public Property TipoPago As String
    Public Property Banco As String
    Public Property NomBanco As String
    Public Property Funcionario As String
    Public Property NomFuncionario As String
    Public Property PagarAuto As Boolean
End Class
