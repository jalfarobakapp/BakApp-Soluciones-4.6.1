Public Class Cl_NewProgramacion

    Public Property Id As Integer
    Public Property NombreEquipo As String
    Public Property Tbl_Padre As String
    Public Property Id_Padre As Integer
    Public Property Nombre As String
    Public Property FrecuDiaria As Boolean
    Public Property FrecuSemanal As Boolean
    Public Property Lunes As Boolean
    Public Property Martes As Boolean
    Public Property Miercoles As Boolean
    Public Property Jueves As Boolean
    Public Property Viernes As Boolean
    Public Property Sabado As Boolean
    Public Property Domingo As Boolean
    Public Property SucedeUnaVez As Boolean
    Public Property HoraUnaVez As DateTime
    Public Property SucedeCada As Boolean
    Public Property IntervaloCada As Integer
    Public Property TipoIntervaloCada As String
    Public Property ApartirDeCada As DateTime
    Public Property FinalizaCada As DateTime
    Public Property Resumen As String
    Public Property Validada As Boolean
    Public Property Activo As Boolean

End Class

Public Class Grb_Programacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Grabar As Boolean
    Public Property Errores As Boolean

    Public Sub New()

    End Sub

    Sub Sb_Actualizar_programacion(Cl_Programacion As Cl_NewProgramacion)

        Dim _Nombre As String = Cl_Programacion.Nombre
        Dim _FrecuDiaria As Integer = Cl_Programacion.FrecuDiaria
        Dim _FrecuSemanal As Integer = Cl_Programacion.FrecuSemanal
        Dim _Lunes As Integer = Cl_Programacion.Lunes
        Dim _Martes As Integer = Cl_Programacion.Martes
        Dim _Miercoles As Integer = Cl_Programacion.Miercoles
        Dim _Jueves As Integer = Cl_Programacion.Jueves
        Dim _Viernes As Integer = Cl_Programacion.Viernes
        Dim _Sabado As Integer = Cl_Programacion.Sabado
        Dim _Domingo As Integer = Cl_Programacion.Domingo
        Dim _SucedeUnaVez As Integer = Cl_Programacion.SucedeUnaVez
        Dim _HoraUnaVez As String = Cl_Programacion.HoraUnaVez
        Dim _SucedeCada As Integer = Cl_Programacion.SucedeCada
        Dim _IntervaloCada As Integer = Cl_Programacion.IntervaloCada
        Dim _TipoIntervaloCada As String = Cl_Programacion.TipoIntervaloCada
        Dim _ApartirDeCada As String = Cl_Programacion.ApartirDeCada
        Dim _FinalizaCada As String = Cl_Programacion.FinalizaCada
        Dim _Resumen As String = Cl_Programacion.Resumen

        If _FrecuDiaria Then
            _Lunes = 0 : _Martes = 0 : _Miercoles = 0 : _Jueves = 0 : _Viernes = 0 : _Sabado = 0 : _Domingo = 0
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Set " & vbCrLf &
                       " Nombre = '" & _Nombre & "'" &
                       ",FrecuDiaria = " & _FrecuDiaria &
                       ",FrecuSemanal = " & _FrecuSemanal &
                       ",Lunes = " & _Lunes &
                       ",Martes = " & _Martes &
                       ",Miercoles = " & _Miercoles &
                       ",Jueves = " & _Jueves &
                       ",Viernes = " & _Viernes &
                       ",Sabado = " & _Sabado &
                       ",Domingo = " & _Domingo &
                       ",SucedeUnaVez = " & _SucedeUnaVez &
                       ",HoraUnaVez = '" & _HoraUnaVez & "'" &
                       ",SucedeCada = " & _SucedeCada &
                       ",IntervaloCada = " & _IntervaloCada &
                       ",TipoIntervaloCada = '" & _TipoIntervaloCada & "'" &
                       ",ApartirDeCada = '" & _ApartirDeCada & "'" &
                       ",FinalizaCada = '" & _FinalizaCada & "'" & vbCrLf &
                       ",Resumen = '" & _Resumen & "'" & vbCrLf &
                       "Where Id = " & Cl_Programacion.Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
        End If

    End Sub

    Function Fx_Llenar_Programacion(_Id As Integer) As Cl_NewProgramacion

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Where Id = " & _Id
        Dim _Row_Programacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _New_Programacion As New Cl_NewProgramacion

        With _New_Programacion

            .Id = _Row_Programacion.Item("Id")
            .Id_Padre = _Row_Programacion.Item("Id_Padre")
            .Nombre = _Row_Programacion.Item("Nombre")
            .FrecuDiaria = _Row_Programacion.Item("FrecuDiaria")
            .FrecuSemanal = _Row_Programacion.Item("FrecuSemanal")
            .Lunes = _Row_Programacion.Item("Lunes")
            .Martes = _Row_Programacion.Item("Martes")
            .Miercoles = _Row_Programacion.Item("Miercoles")
            .Jueves = _Row_Programacion.Item("Jueves")
            .Viernes = _Row_Programacion.Item("Viernes")
            .Sabado = _Row_Programacion.Item("Sabado")
            .Domingo = _Row_Programacion.Item("Domingo")
            .SucedeUnaVez = _Row_Programacion.Item("SucedeUnaVez")
            .HoraUnaVez = NuloPorNro(_Row_Programacion.Item("HoraUnaVez"), "01-01-1900 00:00")
            .SucedeCada = _Row_Programacion.Item("SucedeCada")
            .IntervaloCada = _Row_Programacion.Item("IntervaloCada")
            .TipoIntervaloCada = _Row_Programacion.Item("TipoIntervaloCada")
            .ApartirDeCada = NuloPorNro(_Row_Programacion.Item("ApartirDeCada"), "01-01-1900 00:00")
            .FinalizaCada = NuloPorNro(_Row_Programacion.Item("FinalizaCada"), "01-01-1900 23:59")
            .Resumen = _Row_Programacion.Item("Resumen")
            .Validada = True

        End With

        Return _New_Programacion

    End Function

End Class

Public Class DProgramaciones
    Public Property Sp_EnvioCorreo As New Cl_NewProgramacion
    Public Property Sp_ColaImpDoc As New Cl_NewProgramacion
    Public Property Sp_ColaImpPick As New Cl_NewProgramacion
    Public Property Sp_SolProdBod As New Cl_NewProgramacion
    Public Property Sp_Prestashop_Prod As New Cl_NewProgramacion
    Public Property Sp_Prestashop_Order As New Cl_NewProgramacion
    Public Property Sp_Prestashop_Total As New Cl_NewProgramacion
    Public Property Sp_ImporDTESII As New Cl_NewProgramacion
    Public Property Sp_ArchivarDoc As New Cl_NewProgramacion
    Public Property Sp_ConsStock As New Cl_NewProgramacion
    Public Property Sp_Wordpress_Prod As New Cl_NewProgramacion
    Public Property Sp_Wordpress_Stock As New Cl_NewProgramacion
    Public Property Sp_CierreDoc As New Cl_NewProgramacion
    Public Property Sp_FacturacionAuto As New Cl_NewProgramacion
    Public Property Sp_AsistenteCompras As New Cl_NewProgramacion
    Public Property Sp_SqlQueryEspecial As New Cl_NewProgramacion
    Public Property Sp_ListasProgramadas As New Cl_NewProgramacion
    Public Property Sp_EnviarDocSinRecepcion As New Cl_NewProgramacion
    Public Property Sp_NVVExterna As New Cl_NewProgramacion

End Class
