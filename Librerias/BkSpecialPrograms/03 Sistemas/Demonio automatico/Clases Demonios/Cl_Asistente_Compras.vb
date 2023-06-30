Public Class Cl_Asistente_Compras

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

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
    Public Property Procesando As Boolean
    Public Property Ejecutar As Boolean
    Public Sub New()

    End Sub

    Sub Sb_Ejecutar(_Formulario As Form,
                    _Modalidad As String,
                    _Modo_OCC As Boolean,
                    _Modo_NVI As Boolean,
                    _Auto_GenerarAutomaticamenteOCCProveedores As Boolean,
                    _Auto_GenerarAutomaticamenteOCCProveedorStar As Boolean,
                    _Auto_GenerarAutomaticamenteNVI As Boolean)

        Dim Fm As New Frm_00_Asis_Compra_Menu(_Modalidad)
        Fm.Accion_Automatica = True
        Fm.Auto_GenerarAutomaticamenteOCCProveedores = _Auto_GenerarAutomaticamenteOCCProveedores
        Fm.Auto_GenerarAutomaticamenteOCCProveedorStar = _Auto_GenerarAutomaticamenteOCCProveedorStar
        Fm.Auto_GenerarAutomaticamenteNVI = _Auto_GenerarAutomaticamenteNVI
        Fm.Modo_OCC = _Modo_OCC
        Fm.Modo_NVI = _Modo_NVI
        Fm.Tipo_Informe = "Asistente de compras"
        Fm.ShowDialog(_Formulario)
        Fm.Dispose()

    End Sub

End Class
