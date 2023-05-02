Imports DevComponents.DotNetBar

Public Class Cl_Cerrar_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

#Region "PROPIEDADES"

    Public Property Chk_AsisComEjecLunes As Boolean
    Public Property Chk_AsisComEjecMartes As Boolean
    Public Property Chk_AsisComEjecMiercoles As Boolean
    Public Property Chk_AsisComEjecJueves As Boolean
    Public Property Chk_AsisComEjecViernes As Boolean
    Public Property Chk_AsisComEjecSabado As Boolean
    Public Property Chk_AsisComEjecDomingo As Boolean

    Public Property Txt_AsComModLunes As String
    Public Property Txt_AsComModMartes As String
    Public Property Txt_AsComModMiercoles As String
    Public Property Txt_AsComModJueves As String
    Public Property Txt_AsComModViernes As String
    Public Property Txt_AsComModSabado As String
    Public Property Txt_AsComModDomingo As String

    Public Property Chk_AsistenteDeCompras As Boolean
    Public Property Dtp_AsisCompra_Hora_Ejecucion As DateTime

    Public Property Ejecutado_Lunes As Boolean
    Public Property Ejecutado_Martes As Boolean
    Public Property Ejecutado_Miercoles As Boolean
    Public Property Ejecutado_Jueves As Boolean
    Public Property Ejecutado_Viernes As Boolean
    Public Property Ejecutado_Sabado As Boolean
    Public Property Ejecutado_Domingo As Boolean

    Public Property OCC As Boolean
    Public Property OCI As Boolean
    Public Property COV As Boolean
    Public Property NVV As Boolean
    Public Property NVI As Boolean
    Public Property GTI As Boolean
    Public Property GDI As Boolean

    Public Property DiasOCC As Integer
    Public Property DiasOCI As Integer
    Public Property DiasCOV As Integer
    Public Property DiasNVV As Integer
    Public Property DiasNVI As Integer
    Public Property DiasGTI As Integer
    Public Property DiasGDI As Integer

    Public Property Crear_Html As Crear_Html

#End Region

    Public Sub New()

    End Sub



End Class


