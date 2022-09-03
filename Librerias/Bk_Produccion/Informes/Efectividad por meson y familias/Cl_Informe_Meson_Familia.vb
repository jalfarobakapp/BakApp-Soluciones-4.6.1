Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Cl_Informe_Meson_Familia

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Dim _Tabla_Paso As String = _Global_BaseBk & "Tbl_Paso" & FUNCIONARIO & "_Cnd"
    Dim _Informe_Generado As Boolean
    Dim _Tipo_Informe As Enum_Tipo_Informe
    Dim _Tipo_Vista_Informe As Enum_Tipo_Vista_Informe

    Dim _Codmeson As String
    Dim _SuperFamilia As String
    Dim _Familia As String
    Dim _SubFamilia As String

    Enum Enum_Tipo_Vista_Informe
        MESONES
        SUPER_FAMILIA
    End Enum

    Enum Enum_Tipo_Informe
        Mesones
        Ms_Super_Familia
        Ms_SP_Familias
        Ms_Sp_FM_SubFamilia
    End Enum

    Public Property Tabla_Paso As String
        Get
            Return _Tabla_Paso
        End Get
        Set(value As String)
            _Tabla_Paso = value
        End Set
    End Property

    Public Property Informe_Generado As Boolean
        Get
            Return _Informe_Generado
        End Get
        Set(value As Boolean)
            _Informe_Generado = value
        End Set
    End Property

    Public Property Tipo_Informe As Enum_Tipo_Informe
        Get
            Return _Tipo_Informe
        End Get
        Set(value As Enum_Tipo_Informe)
            _Tipo_Informe = value
        End Set
    End Property

    Public Property Codmeson As String
        Get
            Return _Codmeson
        End Get
        Set(value As String)
            _Codmeson = value
        End Set
    End Property

    Public Property SuperFamilia As String
        Get
            Return _SuperFamilia
        End Get
        Set(value As String)
            _SuperFamilia = value
        End Set
    End Property

    Public Property Familia As String
        Get
            Return _Familia
        End Get
        Set(value As String)
            _Familia = value
        End Set
    End Property

    Public Property SubFamilia As String
        Get
            Return _SubFamilia
        End Get
        Set(value As String)
            _SubFamilia = value
        End Set
    End Property

    Public Property Tipo_Vista_Informe As Enum_Tipo_Vista_Informe
        Get
            Return _Tipo_Vista_Informe
        End Get
        Set(value As Enum_Tipo_Vista_Informe)
            _Tipo_Vista_Informe = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Sub Sb_Generar_Informe(_Fecha_Desde As Date)

        Dim _Fdesde As String = Format(_Fecha_Desde, "yyyyMMdd")

        _Sql.Sb_Eliminar_Tabla_De_Paso(_Tabla_Paso)

        Consulta_sql = My.Resources.Recursos_Informe_Meson_Familias.SQLQuery_Informe_de_tiempos_de_productos_por_meson
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Desde#", _Fdesde)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)

        _Sql.Fx_Ejecutar_Consulta(Consulta_sql)

        _Informe_Generado = True

    End Sub

    Function Fx_Trae_Informe_X_Meson(_CodMeson As String) As DataTable

        Consulta_sql = "Declare @Fabricado Float
                        Set @Fabricado = (Select Sum(Fabricado) From " & _Tabla_Paso & ")

                        Select Codmeson As Codigo,Nommeson As Descripcion,Round(Sum(Dd),2) As Dias,Round(Sum(Fabricado)/@Fabricado,3) As Porc,Sum(Fabricado) As Fabricado,Sum(Uno) As Productos," &
                       "Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
                        From " & _Tabla_Paso & vbCrLf &
                        "Where Codmeson = '" & _CodMeson & "'" & vbCrLf &
                        "Group By Codmeson,Nommeson,[Prom.Carga SubOt],[Prom.Carga xPiezas]"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Trae_Informe_X_Mesones(_Campo_Codigo As String, _Campo_Descripcion As String, _Condicion As String, _Agrupar As String) As DataTable

        Consulta_sql = "Declare @Fabricado Float
                        Set @Fabricado = (Select Sum(Fabricado) From " & _Tabla_Paso & ")

                        Select " & _Campo_Codigo & " As Codigo," & _Campo_Descripcion & " As Descripcion," &
                       "Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Round(Sum(Fabricado)/@Fabricado,3) As Porc,Sum(Uno) As Productos," &
                       "Round(Sum(Dd)/Sum(Uno),3) As 'Prom.',[Prom.Carga SubOt],[Prom.Carga xPiezas]
                        From " & _Tabla_Paso & vbCrLf &
                        "Where 1 > 0 " & vbCrLf &
                        _Condicion & vbCrLf &
                       _Agrupar

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Trae_Informe_X_SuperFamilias(_Campo_Codigo As String, _Campo_Descripcion As String, _Condicion As String, _Agrupar As String) As DataTable

        Consulta_sql = "Declare @Fabricado Float
                        Set @Fabricado = (Select Sum(Fabricado) From " & _Tabla_Paso & ")

                        Select " & _Campo_Codigo & " As Codigo," & _Campo_Descripcion & " As Descripcion," &
                       "Round(Sum(Dd),2) As Dias,Sum(Fabricado) As Fabricado,Round(Sum(Fabricado)/@Fabricado,3) As Porc,Sum(Uno) As Productos,Round(Sum(Dd)/Sum(Uno),3) As 'Prom.'" & vbCrLf &
                       "From " & _Tabla_Paso & vbCrLf &
                       "Where 1 > 0 " & vbCrLf &
                        _Condicion & vbCrLf &
                       _Agrupar

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function


    Function Fx_Ds_Graficos(_Campo_Codigo As String,
                            _Campo_Descripcion As String,
                            _Codigo As String,
                            _Descripcion As String,
                            _Campo_Cantidad As String,
                            _Campo_Fecha As String,
                            _Fecha_Desde As DateTime,
                            _Fecha_Hasta As DateTime,
                            _SqlFiltroExtra As String) As DataSet

        Dim _TblPaso As String = "#TblPaso" & FUNCIONARIO

        _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)

        Consulta_sql = "CREATE TABLE [dbo].[#Tabla_de_Paso#](
                        [Codigo]                [Varchar](20)   DEFAULT '',
                        [Descripcion]           [Varchar](50)   DEFAULT '',
                        [Mes_Palabra]           [Varchar](20)   DEFAULT '',
                        [Semana]                [Int]           DEFAULT (0),
                        [Dia]                   [Int]           DEFAULT (0),
                        [Mes]                   [Int]           DEFAULT (0),
                        [Ano]                   [Int]           DEFAULT (0),
                        [Fabricado]             [float]         DEFAULT (0))
                        ON [PRIMARY]

                        Insert Into #Tabla_de_Paso# (Codigo,Descripcion,Mes_Palabra,Semana,Dia,Mes,Ano,Fabricado)

                        Select " & _Campo_Codigo & "," & _Campo_Descripcion & ",
                                DATENAME(month," & _Campo_Fecha & ") As 'Mes Palabra',
                                DATEPART(week," & _Campo_Fecha & ") As 'Semana',
                                DAY(" & _Campo_Fecha & ") As 'Dia',
                                MONTH(" & _Campo_Fecha & ") As 'Mes',
                                YEAR(" & _Campo_Fecha & ") As 'Año',
                                Sum(" & _Campo_Cantidad & ") As Fabricado 
                        From " & _Tabla_Paso & "
                        Where " & _Campo_Codigo & " = '" & _Codigo & "'
                        " & _SqlFiltroExtra & "
                        Group By " & _Campo_Codigo & "," & _Campo_Descripcion & ",YEAR(" & _Campo_Fecha & "),MONTH(" & _Campo_Fecha & ")," & _Campo_Fecha & "
                        Order By " & _Campo_Codigo & ",YEAR(" & _Campo_Fecha & "),MONTH(" & _Campo_Fecha & ")"


        Dim _dias = -365
        Dim FechaInicio As String = Format(_Fecha_Desde, "yyyyMMdd")
        Dim FechaFin As String = Format(_Fecha_Hasta, "yyyyMMdd")

        Dim Meses As Integer = DateDiff(DateInterval.Month, _Fecha_Desde, _Fecha_Hasta)

        Dim Meses_(Meses) As String
        Dim Fecha As Date = _Fecha_Desde

        For Mes = 0 To Meses

            Dim FechaNw As String = MonthName(Month(Fecha), True) & "-" & Fecha.Year
            Meses_(Mes) = FechaNw

            Dim FStr As String = Format(Primerdiadelmes(Fecha), "yyyyMMdd")

            Consulta_sql += "Insert Into #Tabla_de_Paso#(Codigo,Descripcion,Mes_Palabra,Semana,Dia,Mes,Ano,Fabricado)" & vbCrLf &
                            "Values ('" & _Codigo & "','" & _Descripcion & "'," & vbCrLf &
                            "DATENAME(month,'" & FStr & "')," & vbCrLf &
                            "DATEPART(week, '" & FStr & "')," & vbCrLf &
                            "DAY('" & FStr & "')," & vbCrLf &
                            "MONTH('" & FStr & "')," & vbCrLf &
                            "YEAR('" & FStr & "'),0)" & vbCrLf

            Fecha = DateAdd(DateInterval.Month, 1, Fecha)

        Next

        Consulta_sql += "Select Ltrim(Rtrim(substring(Mes_Palabra,1,3)))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo," & vbCrLf &
                        "Case When ROUND(SUM(Fabricado),2) = 0 then Null" & vbCrLf &
                        "Else ROUND(SUM(Fabricado),2) End as Ud" & vbCrLf &
                        "From #Tabla_de_Paso#" & vbCrLf &
                        "Group By Mes_Palabra,Ano,Mes" & vbCrLf &
                        "Order by Ano,Mes" & vbCrLf &
                        "Drop Table #Tabla_de_Paso#"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Return _Ds

    End Function

End Class
