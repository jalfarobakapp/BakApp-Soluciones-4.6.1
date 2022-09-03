Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Cl_Nomenclatura

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Nomenclaturas As DataSet
    Dim _Tbl_Nomenclatura As DataTable
    Dim _Tbl_Productos_Nomenclatura As DataTable

    Dim _Codigo As String
    Dim _Descripcion As String
    Dim _Ds_Nomenclatura As DataSet
    Dim _Tbl_Pnpe As DataTable
    Dim _Tbl_Pnpd As DataTable
    Dim _Tbl_Pnpa As DataTable
    Dim _Tbl_Pnpr As DataTable
    Dim _Tbl_Pnpra As DataTable

    Dim _Accion As Enum_Accion

    Enum Enum_Accion
        Nuevo
        Editar
    End Enum

    Public Property Ds_Nomenclaturas As DataSet
        Get
            Return _Ds_Nomenclaturas
        End Get
        Set(value As DataSet)
            _Ds_Nomenclaturas = value
        End Set
    End Property

    Public Property Ds_Nomenclatura As DataSet
        Get
            Return _Ds_Nomenclatura
        End Get
        Set(value As DataSet)
            _Ds_Nomenclatura = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return _Codigo
        End Get
        Set(value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Accion As Enum_Accion
        Get
            Return _Accion
        End Get
        Set(value As Enum_Accion)
            _Accion = value
        End Set
    End Property

    Public Property Tbl_Pnpe As DataTable
        Get
            Return _Tbl_Pnpe
        End Get
        Set(value As DataTable)
            _Tbl_Pnpe = value
        End Set
    End Property

    Public Property Tbl_Pnpd As DataTable
        Get
            Return _Tbl_Pnpd
        End Get
        Set(value As DataTable)
            _Tbl_Pnpd = value
        End Set
    End Property

    Public Property Tbl_Pnpa As DataTable
        Get
            Return _Tbl_Pnpa
        End Get
        Set(value As DataTable)
            _Tbl_Pnpa = value
        End Set
    End Property

    Public Property Tbl_Pnpr As DataTable
        Get
            Return _Tbl_Pnpr
        End Get
        Set(value As DataTable)
            _Tbl_Pnpr = value
        End Set
    End Property

    Public Property Tbl_Pnpra As DataTable
        Get
            Return _Tbl_Pnpra
        End Get
        Set(value As DataTable)
            _Tbl_Pnpra = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Sub Sb_Llenar_Ds_Nomenclatura(_Filtro As String)

        _Filtro = CADENA_A_BUSCAR(RTrim$(_Filtro), "PNPE.CODIGO+PNPE.DESCRIPTOR LIKE '%")

        Consulta_sql = "Select PNPE.CODIGO,PNPE.DESCRIPTOR,PNPE.PLANO,PNPE.CANTIDAD,PNPE.UDAD,PNPE.ESODD,PNPE.INACTIVA,
                        Case When PNPE.INACTIVA = 0 Then 'Activa' Else 'Inactiva' End As Estado
                        Into #Paso1
                        From PNPE 
                        Where PNPE.CODIGO+PNPE.DESCRIPTOR LIKE '%" & _Filtro & "%' 
                        Order By PNPE.CODIGO

                        Select Pr.CODNOMEN,Pr.ESMODELO,Mp.KOPR,Mp.NOKOPR,Isnull(Tm.KOMODE,'') As KOMODE,Isnull(Tm.NOKOMODE,'') As NOKOMODE
                        Into #Paso2
                        From PRELA Pr
                        Left Join MAEPR Mp ON Pr.CODIGO=Mp.KOPR 
	                    Left Join TABMODE Tm ON Pr.CODIGO=Tm.KOMODE
                        Where Pr.CODNOMEN In (Select CODIGO From #Paso1)

                        Select * From #Paso1
                        Select * From #Paso2

                        Drop Table #Paso1
                        Drop Table #Paso2"

        _Ds_Nomenclaturas = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Nomenclaturas.Tables(0).TableName = "Nomenclaturas"
        _Ds_Nomenclaturas.Tables(1).TableName = "Nom_Productos"

        _Ds_Nomenclaturas.Relations.Add("Rel_Nom_vs_Prod",
                 _Ds_Nomenclaturas.Tables("Nomenclaturas").Columns("CODIGO"),
                 _Ds_Nomenclaturas.Tables("Nom_Productos").Columns("CODNOMEN"), False)


    End Sub

    Sub Sb_Cargar_Nomenclatura(_Codigo As String)

        Consulta_sql = "Declare @Codigo Varchar(20)

                        Select @Codigo = '" & _Codigo & "'

                        SELECT TOP 1 *,Cast(Case ESODD When '' Then 'Orden de trabajo' Else 'Orden de despacho' End As Varchar(20)) As Orientado_A,
                        Cast(Case INACTIVA When 0 Then 'Activo' Else 'Inactiva' End As Varchar(20)) As Estado 
                        FROM PNPE WITH ( NOLOCK )  WHERE CODIGO=@Codigo

                        SELECT PNPD.*,'XTIENENO'=0, MAEPR.NOKOPR, POPER.NOMBREOP, TABMODE.NOKOMODE  
                        FROM PNPD WITH ( NOLOCK ) 
	                        LEFT OUTER JOIN MAEPR ON PNPD.ELEMENTO=MAEPR.KOPR  
		                        LEFT OUTER JOIN TABMODE ON PNPD.ELEMENTO=TABMODE.KOMODE  
			                        LEFT OUTER JOIN POPER ON PNPD.OPERACION=POPER.OPERACION  
                        WHERE PNPD.CODIGO=@Codigo ORDER BY NREG 

                        SELECT PNPA.*,'XTIENENO'=0,MAEPR.NOKOPR, POPER.NOMBREOP, TABMODE.NOKOMODE  
	                    FROM PNPA WITH ( NOLOCK )  
		                    LEFT OUTER JOIN MAEPR ON PNPA.ELEMENTO=MAEPR.KOPR  
			                    LEFT OUTER JOIN TABMODE ON PNPA.ELEMENTO=TABMODE.KOMODE  
				                    LEFT OUTER JOIN POPER ON PNPA.OPERACION=POPER.OPERACION  
                        WHERE PNPA.CODIGO=@Codigo  ORDER BY NREG 

                        SELECT PNPR.*, POPER.UDAD,POPER.TIPOOP, POPER.NOMBREOP 
                        FROM PNPR WITH ( NOLOCK ) 
	                        LEFT OUTER JOIN POPER ON PNPR.OPERACION=POPER.OPERACION 
                        WHERE PNPR.CODIGO=@Codigo ORDER BY PNPR.CODIGO,PNPR.ORDEN 

                        SELECT PNPRA.*, POPER.UDAD,POPER.TIPOOP, POPER.NOMBREOP 
                        FROM PNPRA WITH ( NOLOCK ) 
	                        LEFT OUTER JOIN POPER ON PNPRA.OPERACION=POPER.OPERACION 
                        WHERE PNPRA.CODIGO=@Codigo ORDER BY PNPRA.CODIGO,PNPRA.ORDEN"

        _Ds_Nomenclatura = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Nomenclatura.Tables(0).TableName = "Pnpe"
        _Ds_Nomenclatura.Tables(1).TableName = "Pnpd"
        _Ds_Nomenclatura.Tables(2).TableName = "Pnpa"
        _Ds_Nomenclatura.Tables(3).TableName = "Pnpr"
        _Ds_Nomenclatura.Tables(4).TableName = "Pnpra"

        _Tbl_Pnpe = _Ds_Nomenclatura.Tables(0)
        _Tbl_Pnpd = _Ds_Nomenclatura.Tables(1)
        _Tbl_Pnpa = _Ds_Nomenclatura.Tables(2)
        _Tbl_Pnpr = _Ds_Nomenclatura.Tables(3)
        _Tbl_Pnpra = _Ds_Nomenclatura.Tables(4)

        Codigo = _Codigo
        Descripcion = _Tbl_Pnpe.Rows(0).Item("DESCRIPTOR")

    End Sub

    Sub Sb_Nueva_Nomenclatura()

        Consulta_sql = "SELECT TOP 1 *,Cast('Orden de trabajo' As Varchar(20)) As Orientado_A,Cast('Activo' As Varchar(20)) As Estado FROM PNPE WITH ( NOLOCK )  WHERE 1<0

                        SELECT PNPD.*,'XTIENENO'=0, MAEPR.NOKOPR, POPER.NOMBREOP, TABMODE.NOKOMODE  
                        FROM PNPD WITH ( NOLOCK ) 
	                        LEFT OUTER JOIN MAEPR ON PNPD.ELEMENTO=MAEPR.KOPR  
		                        LEFT OUTER JOIN TABMODE ON PNPD.ELEMENTO=TABMODE.KOMODE  
			                        LEFT OUTER JOIN POPER ON PNPD.OPERACION=POPER.OPERACION  
                        WHERE 1<0

                        SELECT PNPA.*,'XTIENENO'=0,MAEPR.NOKOPR, POPER.NOMBREOP, TABMODE.NOKOMODE  
	                    FROM PNPA WITH ( NOLOCK )  
		                    LEFT OUTER JOIN MAEPR ON PNPA.ELEMENTO=MAEPR.KOPR  
			                    LEFT OUTER JOIN TABMODE ON PNPA.ELEMENTO=TABMODE.KOMODE  
				                    LEFT OUTER JOIN POPER ON PNPA.OPERACION=POPER.OPERACION  
                        WHERE 1<0

                        SELECT PNPR.*, POPER.UDAD,POPER.TIPOOP, POPER.NOMBREOP 
                        FROM PNPR WITH ( NOLOCK ) 
	                        LEFT OUTER JOIN POPER ON PNPR.OPERACION=POPER.OPERACION 
                        WHERE 1<0

                        SELECT PNPRA.*, POPER.UDAD,POPER.TIPOOP, POPER.NOMBREOP 
                        FROM PNPRA WITH ( NOLOCK ) 
	                        LEFT OUTER JOIN POPER ON PNPRA.OPERACION=POPER.OPERACION 
                        WHERE 1<0"

        _Ds_Nomenclatura = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Nomenclatura.Tables(0).TableName = "Pnpe"
        _Ds_Nomenclatura.Tables(1).TableName = "Pnpd"
        _Ds_Nomenclatura.Tables(2).TableName = "Pnpa"
        _Ds_Nomenclatura.Tables(3).TableName = "Pnpr"
        _Ds_Nomenclatura.Tables(4).TableName = "Pnpra"

        _Tbl_Pnpe = _Ds_Nomenclatura.Tables(0)
        _Tbl_Pnpd = _Ds_Nomenclatura.Tables(1)
        _Tbl_Pnpa = _Ds_Nomenclatura.Tables(2)
        _Tbl_Pnpr = _Ds_Nomenclatura.Tables(3)
        _Tbl_Pnpra = _Ds_Nomenclatura.Tables(4)

        Codigo = String.Empty

        Dim NewFila As DataRow
        NewFila = _Tbl_Pnpe.NewRow
        With NewFila

            .Item("CODIGO") = Codigo
            .Item("CANTIDAD") = 0
            .Item("UDAD") = String.Empty
            .Item("DESCRIPTOR") = 0
            .Item("PLANO") = String.Empty
            .Item("ESODD") = String.Empty
            .Item("INACTIVA") = False
            .Item("EMPRESA") = String.Empty

            _Tbl_Pnpe.Rows.Add(NewFila)

        End With

    End Sub

    Sub Fx_Nuevo_Elemento_de_la_nomenclatura()

        Dim _Nreg = 1

        If CBool(_Tbl_Pnpd.Rows.Count) Then
            _Nreg = _Tbl_Pnpd.Rows.Count + 1
        End If

        Dim NewFila As DataRow
        NewFila = _Tbl_Pnpd.NewRow
        With NewFila

            .Item("CODIGO") = Codigo
            .Item("NREG") = _Nreg
            .Item("ELEMENTO") = String.Empty
            .Item("CANTIDAD") = 0
            .Item("UDAD") = String.Empty
            .Item("OPERACION") = String.Empty
            .Item("ECUCANT") = String.Empty
            .Item("COMODIN") = String.Empty
            .Item("TIPO") = String.Empty
            .Item("CALIDAD") = String.Empty
            .Item("ESMODELO") = String.Empty
            .Item("DEPENDENCI") = String.Empty
            .Item("KOSUDEFE") = String.Empty
            .Item("KOBODEFE") = String.Empty
            .Item("EMPRESA") = String.Empty
            .Item("XTIENENO") = 0
            .Item("NOKOPR") = String.Empty
            .Item("NOMBREOP") = String.Empty
            .Item("NOKOMODE") = String.Empty

            _Tbl_Pnpd.Rows.Add(NewFila)

        End With

    End Sub

    Sub Fx_Nuevo_Elemento_de_la_nomenclatura_alternativo_al_elemento(_Nreg As Integer,
                                                                     _Elemento As String,
                                                                     _Cantidad As Double,
                                                                     _Udad As String,
                                                                     _Operacion As String,
                                                                     _Ecucant As String,
                                                                     _Comodin As String,
                                                                     _Tipo As String,
                                                                     _Calidad As String,
                                                                     _Esmodelo As String,
                                                                     _Dependenci As String,
                                                                     _Kosudefe As String,
                                                                     _Kobodefe As String,
                                                                     _Empresa As String,
                                                                     _Nokopr As String,
                                                                     _Nombreope As String,
                                                                     _Nokomode As String)

        Dim NewFila As DataRow
        NewFila = _Tbl_Pnpa.NewRow
        With NewFila

            .Item("CODIGO") = Codigo
            .Item("NREG") = _Nreg
            .Item("ELEMENTO") = _Elemento
            .Item("CANTIDAD") = _Cantidad
            .Item("UDAD") = _Udad
            .Item("OPERACION") = _Operacion
            .Item("ECUCANT") = _Ecucant
            .Item("COMODIN") = _Comodin
            .Item("TIPO") = _Tipo
            .Item("CALIDAD") = _Calidad
            .Item("ESMODELO") = _Esmodelo
            .Item("DEPENDENCI") = _Dependenci
            .Item("KOSUDEFE") = _Kosudefe
            .Item("KOBODEFE") = _Kobodefe
            .Item("EMPRESA") = _Empresa
            .Item("XTIENENO") = 0
            .Item("NOKOPR") = _Nokomode
            .Item("NOMBREOP") = _Nombreope
            .Item("NOKOMODE") = _Nokomode

            _Tbl_Pnpd.Rows.Add(NewFila)

        End With

    End Sub

    Sub Fx_Nueva_Operacion()

        Dim _Orden = 1

        If CBool(_Tbl_Pnpd.Rows.Count) Then
            _Orden = _Tbl_Pnpd.Rows.Count + 1
        End If

        Dim NewFila As DataRow
        NewFila = _Tbl_Pnpr.NewRow
        With NewFila

            .Item("CODIGO") = Codigo
            .Item("OPERACION") = String.Empty
            .Item("ORDEN") = _Orden
            .Item("POROPANT") = 0
            .Item("PORREQCOMP") = 0
            .Item("SALPROXJOR") = String.Empty
            .Item("UDAD") = String.Empty
            .Item("TIPOOP") = String.Empty
            .Item("NOMBREOP") = String.Empty

            _Tbl_Pnpd.Rows.Add(NewFila)

        End With

    End Sub

    Sub Fx_Nueva_Operacion_Alternativa(_Operacion As String,
                                       _Orden As Integer,
                                       _Poropant As Double,
                                       _Porreqcomp As Double,
                                       _Salproxjor As String,
                                       _Udad As String,
                                       _Tioop As String,
                                       _Nombreop As String)


        Dim NewFila As DataRow
        NewFila = _Tbl_Pnpr.NewRow
        With NewFila

            .Item("CODIGO") = Codigo
            .Item("OPERACION") = _Operacion
            .Item("ORDEN") = _Orden
            .Item("POROPANT") = _Poropant
            .Item("PORREQCOMP") = _Porreqcomp
            .Item("SALPROXJOR") = _Salproxjor
            .Item("UDAD") = _Udad
            .Item("TIPOOP") = _Tioop
            .Item("NOMBREOP") = _Nombreop

            _Tbl_Pnpr.Rows.Add(NewFila)

        End With

    End Sub

    Function Fx_Copiar_Nomenclatura(_Codigo As String, _Codigo_New As String, _Descripcion_New As String)

        Consulta_sql = "Declare @Codigo Varchar(20),
                                @Codigo_New Varchar(20),
                                @Descripcion_New Varchar(50)

                        Select @Codigo = '" & _Codigo & "',@Codigo_New = '" & _Codigo_New & "',@Descripcion_New = '" & _Descripcion_New & "' 
                        
                        Insert Into PNPE (CODIGO,CANTIDAD,UDAD,DESCRIPTOR,PLANO,ESODD,INACTIVA,EMPRESA)    
                        Select @Codigo_New,CANTIDAD,UDAD,@Descripcion_New,PLANO,ESODD,INACTIVA,EMPRESA 
                        From PNPE Where CODIGO=@Codigo

                        Insert Into PNPD (CODIGO,NREG,ELEMENTO,CANTIDAD,UDAD,OPERACION,ECUCANT,COMODIN,TIPO,CALIDAD,ESMODELO,DEPENDENCI,KOSUDEFE,KOBODEFE,EMPRESA)
                        Select CODIGO,NREG,ELEMENTO,CANTIDAD,UDAD,OPERACION,ECUCANT,COMODIN,TIPO,CALIDAD,ESMODELO,DEPENDENCI,KOSUDEFE,KOBODEFE,EMPRESA 
                        From PNPD
                        Where CODIGO=@Codigo
                        
                        Insert Into PNPA (CODIGO,NREG,ELEMENTO,CANTIDAD,UDAD,OPERACION,ECUCANT,COMODIN,TIPO,CALIDAD,ESMODELO,DEPENDENCI,KOSUDEFE,KOBODEFE,EMPRESA)
                        Select CODIGO, NREG,ELEMENTO,CANTIDAD,UDAD,OPERACION,ECUCANT,COMODIN,TIPO,CALIDAD,ESMODELO,DEPENDENCI,KOSUDEFE,KOBODEFE,EMPRESA
                        From PNPA
	                    Where CODIGO=@Codigo
                        
                        Insert Into PNPR (CODIGO,OPERACION,ORDEN,POROPANT,PORREQCOMP,SALPROXJOR)
                        Select CODIGO,OPERACION,ORDEN,POROPANT,PORREQCOMP,SALPROXJOR
                        From PNPR 
                        Where CODIGO=@Codigo
                    
                        Insert Into PNPRA (CODIGO,OPERACION,ORDEN,POROPANT,PORREQCOMP,SALPROXJOR)
                        Select CODIGO,OPERACION,ORDEN,POROPANT,PORREQCOMP,SALPROXJOR
                        Where CODIGO=@Codigo"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Return True
        End If

    End Function

End Class
