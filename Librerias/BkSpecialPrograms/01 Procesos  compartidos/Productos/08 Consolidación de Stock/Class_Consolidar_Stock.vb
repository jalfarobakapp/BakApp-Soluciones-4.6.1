Public Class Class_Consolidar_Stock

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fecha As Date = FechaDelServidor()
    Dim _Tabla_Paso As String
    Dim _Tbl_Productos_Diferencia As DataTable
    Dim _Tbl_Productos_Diferencia_Bakapp As DataTable

    Public ReadOnly Property Pro_Tabla_Paso() As String
        Get
            Return _Tabla_Paso
        End Get
    End Property

    Public ReadOnly Property Pro_Tbl_Productos_Diferencia() As DataTable
        Get
            Return _Tbl_Productos_Diferencia
        End Get
    End Property

    Public ReadOnly Property Tbl_Productos_Diferencia_Bakapp() As DataTable
        Get
            Return _Tbl_Productos_Diferencia_Bakapp
        End Get
    End Property

    Public Sub New()

        'If Not String.IsNullOrEmpty(_Filtro_In_Productos) Then
        'Sb_Crear_Tabla_Paso(_Filtro_In_Productos)
        'End If

        Consulta_sql = My.Resources._SQLquery.Creacion_Tabla_Paso_Conolidacion_Stock
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Condicion#", "")
        _Tbl_Productos_Diferencia = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = "Select Codigo,Cast('' As Varchar(50)) As Descripcion,Empresa,Sucursal,Bodega,StComp1,StComp2,StPedi1,StPedi2," &
                       "Cast(0 As Bit) As Dif_StockCom_BkUd1,Cast(0 As Bit) As Dif_StockCom_BkUd2," &
                       "Cast(0 As Bit) As Dif_StockPedi_BkUd1,Cast(0 As Bit) As Dif_StockPedi_BkUd2," &
                       "Cast(0 As Float) As StockComp1,Cast(0 As Float) As StockComp2," &
                       "Cast(0 As Float) As StockPedi1,Cast(0 As Float) As StockPedi2" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Stock" & vbCrLf &
                       "Where 1 < 0"
        _Tbl_Productos_Diferencia_Bakapp = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Function Fx_Consolidar_Stock_x_producto(ByVal _Emp As String,
                                            ByVal _Suc As String,
                                            ByVal _Bod As String,
                                            ByVal _RowProducto As DataRow) As Boolean


        Dim _Codigo = _RowProducto.Item("KOPR")

        Dim _SqlQuery = String.Empty

        Dim _Stock_Fi(1) As Double
        Dim _StockF_Ud1, _StockF_Ud2 As String     ' STOCK FISICO

        Dim _Stock_Dev(1) As Double
        Dim _StockDev_Ud1, _StockDev_Ud2 As String ' STOCK DEVENGADO

        Dim _Stock_Dsf(1) As Double
        Dim _StockDsf_Ud1, _StockDsf_Ud2 As String ' STOCK DESPACHADO SIN FACTURAR

        Dim _Stock_Com(1) As Double
        Dim _StockCom_Ud1, _StockCom_Ud2 As String ' STOCK COMPROMETIDO

        Dim _Stock_Cnr(1) As Double
        Dim _StockCnr_Ud1, _StockCnr_Ud2 As String ' STOCK COMPRAS NO RECEPCIONADAS

        Dim _Stock_Rsf(1) As Double
        Dim _StockRsf_Ud1, _StockRsf_Ud2 As String ' STOCK RECEPCIONADO SIN FACTURAR

        Dim _Stock_Ped(1) As Double
        Dim _StockPed_Ud1, _StockPed_Ud2 As String ' STOCK PEDIDO


        Dim _StComp(1) As Double
        Dim _StComp1, _StComp2 As String ' STOCK COMPROMETIDO BAKAPP

        Dim _StPedi(1) As Double
        Dim _StPedi1, _StPedi2 As String ' STOCK PEDIDO BAKAPP

        Dim _Fecha_Max As Date = ultimodiadelmes(FechaDelServidor)

        'STOCK FISICO ************** STFI1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Fisico_X_producto
        _Stock_Fi = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockF_Ud1 = De_Num_a_Tx_01(_Stock_Fi(0), False, 5) '- _CantidadUd1
        _StockF_Ud2 = De_Num_a_Tx_01(_Stock_Fi(1), False, 5) '- _CantidadUd2


        'STOCK DEVENGADO ************ STDV1 -- ('FCV','FDB','FDV','FDX','FEV','FVL','FVT','FVX','BLV')
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Devengado_X_producto
        _Stock_Dev = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockDev_Ud1 = De_Num_a_Tx_01(_Stock_Dev(0), False, 5) '- _CantidadUd1
        _StockDev_Ud2 = De_Num_a_Tx_01(_Stock_Dev(1), False, 5) '- _CantidadUd2


        'STOCK DESPACHADO SIN FACTURAR ************ DESPNOFAC1 -- ('GDV')
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Despachado_Sin_Facturar_X_producto
        _Stock_Dsf = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockDsf_Ud1 = De_Num_a_Tx_01(_Stock_Dsf(0), False, 5) '- _CantidadUd1
        _StockDsf_Ud2 = De_Num_a_Tx_01(_Stock_Dsf(1), False, 5) '- _CantidadUd2


        'STOCK COMPROMETIDO ************ STOCNV1 -- NOTAS DE VENTA
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Comprometido_X_producto
        _Stock_Com = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockCom_Ud1 = De_Num_a_Tx_01(_Stock_Com(0), False, 5) '- _CantidadUd1
        _StockCom_Ud2 = De_Num_a_Tx_01(_Stock_Com(1), False, 5) '- _CantidadUd2


        'STOCK COMPRAS NO RECEPCIONADAS ************ STDV1C
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Compras_no_recepcionadas_X_producto
        _Stock_Cnr = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockCnr_Ud1 = De_Num_a_Tx_01(_Stock_Cnr(0), False, 5) '- _CantidadUd1
        _StockCnr_Ud2 = De_Num_a_Tx_01(_Stock_Cnr(1), False, 5) '- _CantidadUd2


        'STOCK RECEPCIONADO SIN FACTURAR ************ RECENOFAC1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Recepcionado_sin_facturar_X_producto
        _Stock_Rsf = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockRsf_Ud1 = De_Num_a_Tx_01(_Stock_Rsf(0), False, 5) '- _CantidadUd1
        _StockRsf_Ud2 = De_Num_a_Tx_01(_Stock_Rsf(1), False, 5) '- _CantidadUd2


        'STOCK PEDIDO *************** STOCNV1C
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Pedido_X_producto
        _Stock_Ped = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockPed_Ud1 = De_Num_a_Tx_01(_Stock_Ped(0), False, 5) '- _CantidadUd1
        _StockPed_Ud2 = De_Num_a_Tx_01(_Stock_Ped(1), False, 5) '- _CantidadUd2

        '*****************************************************************************************
        'Consulta_sql = "Select EMPRESA,KOSU,KOBO,KOPR,STFI1,STFI2,STDV1,STDV2,DESPNOFAC1,DESPNOFAC2," & _
        '               "STOCNV1,STOCNV2,STDV1C,STDV2C,RECENOFAC1,RECENOFAC2,STOCNV1C,STOCNV2C" & vbCrLf & _
        '               "From MAEST Where EMPRESA = '" & _Emp & "' AND KOSU = '" & _Suc & "' AND KOBO = '" & _Bod & "' AND KOPR = '" & _Codigo & "'"

        Consulta_sql = "UPDATE " & _Tabla_Paso & " SET" & vbCrLf &
                       " StockF_Ud1 = " & _StockF_Ud1 & vbCrLf &
                       ",StockF_Ud2 = " & _StockF_Ud2 & vbCrLf &
                       ",StockDev_Ud1 = " & _StockDev_Ud1 & vbCrLf &
                       ",StockDev_Ud2 = " & _StockDev_Ud2 & vbCrLf &
                       ",StockDsf_Ud1 = " & _StockDsf_Ud1 & vbCrLf &
                       ",StockDsf_Ud2 = " & _StockDsf_Ud2 & vbCrLf &
                       ",StockCom_Ud1 = " & _StockCom_Ud1 & vbCrLf &
                       ",StockCom_Ud2 = " & _StockCom_Ud2 & vbCrLf &
                       ",StockCnr_Ud1 = " & _StockCnr_Ud1 & vbCrLf &
                       ",StockCnr_Ud2 = " & _StockCnr_Ud2 & vbCrLf &
                       ",StockRsf_Ud1 = " & _StockRsf_Ud1 & vbCrLf &
                       ",StockRsf_Ud2 = " & _StockRsf_Ud2 & vbCrLf &
                       ",StockPed_Ud1 = " & _StockPed_Ud1 & vbCrLf &
                       ",StockPed_Ud2 = " & _StockPed_Ud2 & vbCrLf &
                       "Where EMPRESA = '" & _Emp &
                       "' And KOSU = '" & _Suc &
                       "' And KOBO = '" & _Bod &
                       "' And KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf


        '_SqlQuery += "Insert Into MAEST (EMPRESA,KOSU,KOBO,KOPR)" & vbCrLf & _
        '             "Values ('" & _Emp & "','" & _Suc & "','" & _Bod & "','" & _Codigo & "')" & vbCrLf & vbCrLf & _
        '             "UPDATE MAEST SET" & vbCrLf & _
        '             " STFI1 = " & _StockF_Ud1 & vbCrLf & _
        '             ",STFI2 = " & _StockF_Ud2 & vbCrLf & _
        '             ",STDV1 = " & _StockDev_Ud1 & vbCrLf & _
        '             ",STDV2 = " & _StockDev_Ud2 & vbCrLf & _
        '             ",DESPNOFAC1 = " & _StockDsf_Ud1 & vbCrLf & _
        '             ",DESPNOFAC2 = " & _StockDsf_Ud2 & vbCrLf & _
        '             ",STOCNV1 = " & _StockCom_Ud1 & vbCrLf & _
        '             ",STOCNV2 = " & _StockCom_Ud2 & vbCrLf & _
        '             ",STDV1C = " & _StockCnr_Ud1 & vbCrLf & _
        '             ",STDV2C = " & _StockCnr_Ud2 & vbCrLf & _
        '             ",RECENOFAC1 = " & _StockRsf_Ud1 & vbCrLf & _
        '             ",RECENOFAC2 = " & _StockRsf_Ud2 & vbCrLf & _
        '             ",STOCNV1C = " & _StockPed_Ud1 & vbCrLf & _
        '             ",STOCNV2C = " & _StockPed_Ud2 & vbCrLf & _
        '             "WHERE EMPRESA = '" & _Emp & _
        '             "' AND KOSU = '" & _Suc & _
        '             "' AND KOBO = '" & _Bod & _
        '             "' AND KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf

        'Consulta_sql = String.Empty

        'Consulta_sql = "Delete MAEST Where KOPR = '" & _Codigo & "' And EMPRESA = '" & _Emp & _
        '               "' And KOSU = '" & _Suc & "' And KOBO = '" & _Bod & "'" & vbCrLf & _
        '               _SqlQuery & vbCrLf & _
        '               Consulta_sql & vbCrLf & _
        '               "---------------------------" & vbCrLf & vbCrLf

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function

    Function Fx_Consolidar_Stock_x_producto_Unico(_Emp As String,
                                                  _Suc As String,
                                                  _Bod As String,
                                                  _RowProducto As DataRow,
                                                  ByRef _Con_Diferencias As Boolean,
                                                  _Reservar_Pendientes_Bakapp As Boolean) As Boolean

        Dim _Codigo = _RowProducto.Item("KOPR")
        Dim _Descripcion = _RowProducto.Item("NOKOPR")

        Dim _STFI1, _STFI2,
            _STDV1, _STDV2,
            _DESPNOFAC1, _DESPNOFAC2,
            _STOCNV1, _STOCNV2,
            _STDV1C, _STDV2C,
            _RECENOFAC1, _RECENOFAC2,
            _STOCNV1C, _STOCNV2C,
            _STTR1, _STTR2 As Double

        Dim _Dif_StockF_Ud1, _Dif_StockF_Ud2,
            _Dif_StockDev_Ud1, _Dif_StockDev_Ud2,
            _Dif_StockDsf_Ud1, _Dif_StockDsf_Ud2,
            _Dif_StockCom_Ud1, _Dif_StockCom_Ud2,
            _Dif_StockCnr_Ud1, _Dif_StockCnr_Ud2,
            _Dif_StockRsf_Ud1, _Dif_StockRsf_Ud2,
            _Dif_StockPed_Ud1, _Dif_StockPed_Ud2,
            _Dif_StockTrans_Ud1, _Dif_StockTrans_Ud2 As Boolean


        Consulta_sql = "Select * From MAEST Where EMPRESA = '" & _Emp & "' And KOSU = '" & _Suc & "' And KOBO = '" & _Bod & "' And KOPR = '" & _Codigo & "'"
        Dim _Row_Maest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Row_Maest Is Nothing) Then

            _STFI1 = Math.Round(_Row_Maest.Item("STFI1"), 5)
            _STFI2 = Math.Round(_Row_Maest.Item("STFI2"), 5)
            _STDV1 = Math.Round(_Row_Maest.Item("STDV1"), 5)
            _STDV2 = Math.Round(_Row_Maest.Item("STDV2"), 5)
            _DESPNOFAC1 = Math.Round(_Row_Maest.Item("DESPNOFAC1"), 5)
            _DESPNOFAC2 = Math.Round(_Row_Maest.Item("DESPNOFAC2"), 5)
            _STOCNV1 = Math.Round(_Row_Maest.Item("STOCNV1"), 5)
            _STOCNV2 = Math.Round(_Row_Maest.Item("STOCNV2"), 5)
            _STDV1C = Math.Round(_Row_Maest.Item("STDV1C"), 5)
            _STDV2C = Math.Round(_Row_Maest.Item("STDV2C"), 5)
            _RECENOFAC1 = Math.Round(_Row_Maest.Item("RECENOFAC1"), 5)
            _RECENOFAC2 = Math.Round(_Row_Maest.Item("RECENOFAC2"), 5)
            _STOCNV1C = Math.Round(_Row_Maest.Item("STOCNV1C"), 5)
            _STOCNV2C = Math.Round(_Row_Maest.Item("STOCNV2C"), 5)
            _STTR1 = Math.Round(_Row_Maest.Item("STTR1"), 5)
            _STTR2 = Math.Round(_Row_Maest.Item("STTR2"), 5)

        End If

        Dim _SqlQuery = String.Empty

        Dim _Stock_Fi(1) As Double
        Dim _StockF_Ud1, _StockF_Ud2 As String     ' STOCK FISICO

        Dim _Stock_Dev(1) As Double
        Dim _StockDev_Ud1, _StockDev_Ud2 As String ' STOCK DEVENGADO

        Dim _Stock_Dsf(1) As Double
        Dim _StockDsf_Ud1, _StockDsf_Ud2 As String ' STOCK DESPACHADO SIN FACTURAR

        Dim _Stock_Com(1) As Double
        Dim _StockCom_Ud1, _StockCom_Ud2 As String ' STOCK COMPROMETIDO

        Dim _Stock_Cnr(1) As Double
        Dim _StockCnr_Ud1, _StockCnr_Ud2 As String ' STOCK COMPRAS NO RECEPCIONADAS

        Dim _Stock_Rsf(1) As Double
        Dim _StockRsf_Ud1, _StockRsf_Ud2 As String ' STOCK RECEPCIONADO SIN FACTURAR

        Dim _Stock_Ped(1) As Double
        Dim _StockPed_Ud1, _StockPed_Ud2 As String ' STOCK PEDIDO

        Dim _Stock_Trans(1) As Double
        Dim _StockTrans_Ud1, _StockTrans_Ud2 As String ' STOCK EN TRANSITO

        Dim _Fecha_Max As Date = DateAdd(DateInterval.Year, 1, FechaDelServidor)

        'STOCK FISICO ************** STFI1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Fisico_X_producto
        _Stock_Fi = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockF_Ud1 = De_Num_a_Tx_01(_Stock_Fi(0), False, 5) '- _CantidadUd1
        _StockF_Ud2 = De_Num_a_Tx_01(_Stock_Fi(1), False, 5) '- _CantidadUd2

        _Dif_StockF_Ud1 = (_STFI1 <> _Stock_Fi(0))
        _Dif_StockF_Ud2 = (_STFI2 <> _Stock_Fi(1))

        'STOCK DEVENGADO ************ STDV1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Devengado_X_producto
        _Stock_Dev = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockDev_Ud1 = De_Num_a_Tx_01(_Stock_Dev(0), False, 5) '- _CantidadUd1
        _StockDev_Ud2 = De_Num_a_Tx_01(_Stock_Dev(1), False, 5) '- _CantidadUd2

        _Dif_StockDev_Ud1 = (_STDV1 <> _Stock_Dev(0))
        _Dif_StockDev_Ud2 = (_STDV2 <> _Stock_Dev(1))

        'STOCK DESPACHADO SIN FACTURAR ************ DESPNOFAC1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Despachado_Sin_Facturar_X_producto
        _Stock_Dsf = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockDsf_Ud1 = De_Num_a_Tx_01(_Stock_Dsf(0), False, 5) '- _CantidadUd1
        _StockDsf_Ud2 = De_Num_a_Tx_01(_Stock_Dsf(1), False, 5) '- _CantidadUd2fre

        _Dif_StockDsf_Ud1 = (_DESPNOFAC1 <> _Stock_Dsf(0))
        _Dif_StockDsf_Ud2 = (_DESPNOFAC2 <> _Stock_Dsf(1))


        'STOCK COMPROMETIDO ************ STOCNV1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Comprometido_X_producto
        _Stock_Com = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockCom_Ud1 = De_Num_a_Tx_01(_Stock_Com(0), False, 5) '- _CantidadUd1
        _StockCom_Ud2 = De_Num_a_Tx_01(_Stock_Com(1), False, 5) '- _CantidadUd2

        _Dif_StockCom_Ud1 = (_STOCNV1 <> _Stock_Com(0))
        _Dif_StockCom_Ud2 = (_STOCNV2 <> _Stock_Com(1))


        'STOCK COMPRAS NO RECEPCIONADAS ************ STDV1C
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Compras_no_recepcionadas_X_producto
        _Stock_Cnr = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockCnr_Ud1 = De_Num_a_Tx_01(_Stock_Cnr(0), False, 5) '- _CantidadUd1
        _StockCnr_Ud2 = De_Num_a_Tx_01(_Stock_Cnr(1), False, 5) '- _CantidadUd2

        _Dif_StockCnr_Ud1 = (_STDV1C <> _Stock_Cnr(0))
        _Dif_StockCnr_Ud2 = (_STDV2C <> _Stock_Cnr(1))

        'STOCK RECEPCIONADO SIN FACTURAR ************ RECENOFAC1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Recepcionado_sin_facturar_X_producto
        _Stock_Rsf = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockRsf_Ud1 = De_Num_a_Tx_01(_Stock_Rsf(0), False, 5) '- _CantidadUd1
        _StockRsf_Ud2 = De_Num_a_Tx_01(_Stock_Rsf(1), False, 5) '- _CantidadUd2

        _Dif_StockRsf_Ud1 = (_RECENOFAC1 <> _Stock_Rsf(0))
        _Dif_StockRsf_Ud2 = (_RECENOFAC2 <> _Stock_Rsf(1))

        'STOCK PEDIDO *************** STOCNV1C
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Pedido_X_producto
        _Stock_Ped = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockPed_Ud1 = De_Num_a_Tx_01(_Stock_Ped(0), False, 5) '- _CantidadUd1
        _StockPed_Ud2 = De_Num_a_Tx_01(_Stock_Ped(1), False, 5) '- _CantidadUd2

        _Dif_StockPed_Ud1 = (_STOCNV1C <> _Stock_Ped(0))
        _Dif_StockPed_Ud2 = (_STOCNV2C <> _Stock_Ped(1))


        'STOCK EN TRANSITO *************** STTR1
        Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_En_Transito
        _Stock_Trans = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

        _StockTrans_Ud1 = De_Num_a_Tx_01(_Stock_Trans(0), False, 5) '- _CantidadUd1
        _StockTrans_Ud2 = De_Num_a_Tx_01(_Stock_Trans(1), False, 5) '- _CantidadUd2

        _Dif_StockTrans_Ud1 = (_STTR1 <> _Stock_Trans(0))
        _Dif_StockTrans_Ud2 = (_STTR2 <> _Stock_Trans(1))

        '*****************************************************************************************
        'Consulta_sql = "Select EMPRESA,KOSU,KOBO,KOPR,STFI1,STFI2,STDV1,STDV2,DESPNOFAC1,DESPNOFAC2," & _
        '               "STOCNV1,STOCNV2,STDV1C,STDV2C,RECENOFAC1,RECENOFAC2,STOCNV1C,STOCNV2C" & vbCrLf & _
        '               "From MAEST Where EMPRESA = '" & _Emp & "' AND KOSU = '" & _Suc & "' AND KOBO = '" & _Bod & "' AND KOPR = '" & _Codigo & "'"

        If _Dif_StockF_Ud1 Or _Dif_StockF_Ud2 Or
           _Dif_StockDev_Ud1 Or _Dif_StockDev_Ud2 Or
           _Dif_StockDsf_Ud1 Or _Dif_StockDsf_Ud2 Or
           _Dif_StockCom_Ud1 Or _Dif_StockCom_Ud2 Or
           _Dif_StockCnr_Ud1 Or _Dif_StockCnr_Ud2 Or
           _Dif_StockRsf_Ud1 Or _Dif_StockRsf_Ud2 Or
           _Dif_StockPed_Ud1 Or _Dif_StockPed_Ud2 Or
           _Dif_StockTrans_Ud1 Or _Dif_StockTrans_Ud1 Then

            _Con_Diferencias = True

            Dim NewFila As DataRow
            NewFila = _Tbl_Productos_Diferencia.NewRow
            With NewFila

                .Item("EMPRESA") = ModEmpresa
                .Item("KOSU") = ModSucursal
                .Item("KOBO") = ModBodega
                .Item("KOPR") = _Codigo
                .Item("NOKOPR") = _Descripcion
                .Item("STFI1") = _STFI1
                .Item("STFI2") = _STFI2
                .Item("StockF_Ud1") = De_Txt_a_Num_01(_StockF_Ud1, 5)
                .Item("StockF_Ud2") = De_Txt_a_Num_01(_StockF_Ud2, 5)
                .Item("Dif_StockF_Ud1") = _Dif_StockF_Ud1
                .Item("Dif_StockF_Ud2") = _Dif_StockF_Ud2
                .Item("STDV1") = _STDV1
                .Item("STDV2") = _STDV2
                .Item("StockDev_Ud1") = De_Txt_a_Num_01(_StockDev_Ud1, 5)
                .Item("StockDev_Ud2") = De_Txt_a_Num_01(_StockDev_Ud2, 5)
                .Item("Dif_StockDev_Ud1") = _Dif_StockDev_Ud1
                .Item("Dif_StockDev_Ud2") = _Dif_StockDev_Ud2
                .Item("DESPNOFAC1") = _DESPNOFAC1
                .Item("DESPNOFAC2") = _DESPNOFAC2
                .Item("StockDsf_Ud1") = De_Txt_a_Num_01(_StockDsf_Ud1, 5)
                .Item("StockDsf_Ud2") = De_Txt_a_Num_01(_StockDsf_Ud2, 5)
                .Item("Dif_StockDsf_Ud1") = _Dif_StockDsf_Ud1
                .Item("Dif_StockDsf_Ud2") = _Dif_StockDsf_Ud2
                .Item("STOCNV1") = _STOCNV1
                .Item("STOCNV2") = _STOCNV2
                .Item("StockCom_Ud1") = De_Txt_a_Num_01(_StockCom_Ud1, 5)
                .Item("StockCom_Ud2") = De_Txt_a_Num_01(_StockCom_Ud2, 5)
                .Item("Dif_StockCom_Ud1") = _Dif_StockCom_Ud1
                .Item("Dif_StockCom_Ud2") = _Dif_StockCom_Ud2
                .Item("STDV1C") = _STDV1C
                .Item("STDV2C") = _STDV2C
                .Item("StockCnr_Ud1") = De_Txt_a_Num_01(_StockCnr_Ud1, 5)
                .Item("StockCnr_Ud2") = De_Txt_a_Num_01(_StockCnr_Ud2, 5)
                .Item("Dif_StockCnr_Ud1") = _Dif_StockCnr_Ud1
                .Item("Dif_StockCnr_Ud2") = _Dif_StockCnr_Ud2
                .Item("RECENOFAC1") = _RECENOFAC1
                .Item("RECENOFAC2") = _RECENOFAC2
                .Item("StockRsf_Ud1") = De_Txt_a_Num_01(_StockRsf_Ud1, 5)
                .Item("StockRsf_Ud2") = De_Txt_a_Num_01(_StockRsf_Ud2, 5)
                .Item("Dif_StockRsf_Ud1") = _Dif_StockRsf_Ud1
                .Item("Dif_StockRsf_Ud2") = _Dif_StockRsf_Ud2
                .Item("STOCNV1C") = _STOCNV1C
                .Item("STOCNV2C") = _STOCNV2C
                .Item("StockPed_Ud1") = De_Txt_a_Num_01(_StockPed_Ud1, 5)
                .Item("StockPed_Ud2") = De_Txt_a_Num_01(_StockPed_Ud2, 5)
                .Item("Dif_StockPed_Ud1") = _Dif_StockPed_Ud1
                .Item("Dif_StockPed_Ud2") = _Dif_StockPed_Ud2

                .Item("STTR1") = _STOCNV1C
                .Item("STTR2") = _STOCNV2C
                .Item("StockTrans_Ud1") = De_Txt_a_Num_01(_StockTrans_Ud1, 5)
                .Item("StockTrans_Ud2") = De_Txt_a_Num_01(_StockTrans_Ud2, 5)
                .Item("Dif_StockTrans_Ud1") = _Dif_StockTrans_Ud1
                .Item("Dif_StockTrans_Ud2") = _Dif_StockTrans_Ud2

                _Tbl_Productos_Diferencia.Rows.Add(NewFila)

            End With

            Consulta_sql = "UPDATE MAEPR SET STFI1=0,STDV1=0,STOCNV1=0,STDV1C=0,STOCNV1C=0,DESPNOFAC1=0,RECENOFAC1=0,STFI2=0,STDV2=0,STOCNV2=0," &
                           "STDV2C=0,STOCNV2C=0,DESPNOFAC2=0,RECENOFAC2=0,STTR1=0,STTR2=0,PRESALCLI1=0,PRESALCLI2=0,PRESDEPRO1=0," &
                           "PRESDEPRO2=0,CONSALCLI1=0,CONSALCLI2=0,CONSDEPRO1=0,CONSDEPRO2=0,DEVENGNCV1=0,DEVENGNCV2=0,DEVENGNCC1=0," &
                           "DEVENGNCC2=0,DEVSINNCV1=0,DEVSINNCV2=0,DEVSINNCC1=0,DEVSINNCC2=0,STENFAB1=0,STENFAB2=0,STREQFAB1=0,STREQFAB2=0" & vbCrLf &
                           "WHERE KOPR = '" & _Codigo & "'" &
                           vbCrLf &
                           vbCrLf &
                           "UPDATE MAEPREM SET STFI1=0,STDV1=0,STOCNV1=0,STDV1C=0,STOCNV1C=0,DESPNOFAC1=0,RECENOFAC1=0,STFI2=0,STDV2=0,STOCNV2=0,STDV2C=0," &
                           "STOCNV2C=0,DESPNOFAC2=0,RECENOFAC2=0,STTR1=0,STTR2=0, PRESALCLI1=0,PRESALCLI2=0,PRESDEPRO1=0,PRESDEPRO2=0,CONSALCLI1=0," &
                           "CONSALCLI2=0,CONSDEPRO1=0,CONSDEPRO2=0,DEVENGNCV1=0,DEVENGNCV2=0,DEVENGNCC1=0,DEVENGNCC2=0,DEVSINNCV1=0,DEVSINNCV2=0," &
                           "DEVSINNCC1=0,DEVSINNCC2=0,STENFAB1=0,STENFAB2=0,STREQFAB1=0,STREQFAB2=0" & vbCrLf &
                           "WHERE KOPR = '" & _Codigo & "' And EMPRESA = '" & _Emp & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        _SqlQuery += "Insert Into MAEST (EMPRESA,KOSU,KOBO,KOPR)" & vbCrLf &
                     "Values ('" & _Emp & "','" & _Suc & "','" & _Bod & "','" & _Codigo & "')" & vbCrLf & vbCrLf &
                     "Update MAEST Set" & vbCrLf &
                     " STFI1 = " & _StockF_Ud1 & vbCrLf &
                     ",STFI2 = " & _StockF_Ud2 & vbCrLf &
                     ",STDV1 = " & _StockDev_Ud1 & vbCrLf &
                     ",STDV2 = " & _StockDev_Ud2 & vbCrLf &
                     ",DESPNOFAC1 = " & _StockDsf_Ud1 & vbCrLf &
                     ",DESPNOFAC2 = " & _StockDsf_Ud2 & vbCrLf &
                     ",STOCNV1 = " & _StockCom_Ud1 & vbCrLf &
                     ",STOCNV2 = " & _StockCom_Ud2 & vbCrLf &
                     ",STDV1C = " & _StockCnr_Ud1 & vbCrLf &
                     ",STDV2C = " & _StockCnr_Ud2 & vbCrLf &
                     ",RECENOFAC1 = " & _StockRsf_Ud1 & vbCrLf &
                     ",RECENOFAC2 = " & _StockRsf_Ud2 & vbCrLf &
                     ",STOCNV1C = " & _StockPed_Ud1 & vbCrLf &
                     ",STOCNV2C = " & _StockPed_Ud2 & vbCrLf &
                     ",STTR1 = " & _StockTrans_Ud1 & vbCrLf &
                     ",STTR2 = " & _StockTrans_Ud2 & vbCrLf &
                     "Where EMPRESA = '" & _Emp &
                     "' And KOSU = '" & _Suc &
                     "' And KOBO = '" & _Bod &
                     "' And KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf

        _SqlQuery += "Update MAEPMSUC Set STFI1 = " & _StockF_Ud1 & ", STFI2 = " & _StockF_Ud2 & vbCrLf &
                     "Where EMPRESA = '" & _Emp & "' And KOSU = '" & _Suc & "' And KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf

        Consulta_sql = String.Empty

        Consulta_sql = "Delete MAEST" & Space(1) &
                       "Where KOPR = '" & _Codigo & "' And EMPRESA = '" & _Emp & "' And KOSU = '" & _Suc & "' And KOBO = '" & _Bod & "'" & vbCrLf &
                       _SqlQuery & vbCrLf &
                       Consulta_sql & vbCrLf &
                       "---------------------------" & vbCrLf & vbCrLf

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function

    Function Fx_Consolidar_Stock_x_producto_Unico_Bakapp(_Empresa As String,
                                                         _Sucursal As String,
                                                         _Bodega As String,
                                                         _RowProducto As DataRow) As Boolean

        Dim _Codigo = _RowProducto.Item("KOPR")
        Dim _Descripcion = _RowProducto.Item("NOKOPR")

        Dim _StComp1, _StComp2 As Double
        Dim _StPedi1, _StPedi2 As Double

        Dim _Dif_StockCom_BkUd1, _Dif_StockCom_BkUd2 As Boolean
        Dim _Dif_StockPedi_BkUd1, _Dif_StockPedi_BkUd2 As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Stock" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo = '" & _Codigo & "'"
        Dim _Row_Prod_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Row_Prod_Stock Is Nothing) Then

            _StComp1 = Math.Round(_Row_Prod_Stock.Item("StComp1"), 5)
            _StComp2 = Math.Round(_Row_Prod_Stock.Item("StComp2"), 5)
            _StPedi1 = Math.Round(_Row_Prod_Stock.Item("StPedi1"), 5)
            _StPedi2 = Math.Round(_Row_Prod_Stock.Item("StPedi2"), 5)

        End If

        Dim _SqlQuery = String.Empty

        '*************************************** STOCK BAKAPP ***************

        Dim _StComp(1) As Double
        Dim _StockComp1, _StockComp2 As String ' STOCK COMPROMETIDO BAKAPP

        Dim _StPedi(1) As Double
        Dim _StockPedi1, _StockPedi2 As String ' STOCK PEDIDO BAKAPP

        '********************************************************************

        'STOCK COMPROMETIDO ************ STOCNV1

        'Dim _Stock_Comp_Bk(1) As Double

        _StComp = Fx_Stock_Reservado_Bakapp(_RowProducto, _Empresa, _Sucursal, _Bodega, "NVV")

        _StockComp1 = De_Num_a_Tx_01(_StComp(0), False, 5) '- _CantidadUd1
        _StockComp2 = De_Num_a_Tx_01(_StComp(1), False, 5) '- _CantidadUd2

        _Dif_StockCom_BkUd1 = (_StComp1 <> _StComp(0))
        _Dif_StockCom_BkUd2 = (_StComp1 <> _StComp(1))



        'STOCK PEDIDO *************** STOCNV1C

        _StPedi = Fx_Stock_Reservado_Bakapp(_RowProducto, _Empresa, _Sucursal, _Bodega, "OCC")

        _StockPedi1 = De_Num_a_Tx_01(_StPedi(0), False, 5) '- _CantidadUd1
        _StockPedi2 = De_Num_a_Tx_01(_StPedi(1), False, 5) '- _CantidadUd2

        _Dif_StockPedi_BkUd1 = (_StPedi1 <> _StPedi(0))
        _Dif_StockPedi_BkUd2 = (_StPedi2 <> _StPedi(1))

        '*****************************************************************************************
        'Consulta_sql = "Select EMPRESA,KOSU,KOBO,KOPR,STFI1,STFI2,STDV1,STDV2,DESPNOFAC1,DESPNOFAC2," & _
        '               "STOCNV1,STOCNV2,STDV1C,STDV2C,RECENOFAC1,RECENOFAC2,STOCNV1C,STOCNV2C" & vbCrLf & _
        '               "From MAEST Where EMPRESA = '" & _Emp & "' AND KOSU = '" & _Suc & "' AND KOBO = '" & _Bod & "' AND KOPR = '" & _Codigo & "'"

        If _Dif_StockCom_BkUd1 Or _Dif_StockCom_BkUd2 Or
           _Dif_StockPedi_BkUd1 Or _Dif_StockPedi_BkUd2 Then

            '_Con_Diferencias = True

            Dim NewFila As DataRow
            NewFila = _Tbl_Productos_Diferencia_Bakapp.NewRow
            With NewFila

                .Item("Empresa") = _Empresa
                .Item("Sucursal") = _Sucursal
                .Item("Bodega") = _Bodega
                .Item("Codigo") = _Codigo
                .Item("Descripcion") = _Descripcion

                .Item("StComp1") = _StComp1
                .Item("StComp1") = _StComp2
                .Item("StockComp1") = De_Txt_a_Num_01(_StockComp1, 5)
                .Item("StockComp1") = De_Txt_a_Num_01(_StockComp2, 5)
                .Item("Dif_StockCom_BkUd1") = _Dif_StockCom_BkUd1
                .Item("Dif_StockCom_BkUd2") = _Dif_StockCom_BkUd2

                .Item("StPedi1") = _StPedi1
                .Item("StPedi2") = _StPedi2
                .Item("StockPedi1") = De_Txt_a_Num_01(_StockPedi1, 5)
                .Item("StockPedi2") = De_Txt_a_Num_01(_StockPedi2, 5)
                .Item("Dif_StockPedi_BkUd1") = _Dif_StockPedi_BkUd1
                .Item("Dif_StockPedi_BkUd2") = _Dif_StockPedi_BkUd2

                _Tbl_Productos_Diferencia_Bakapp.Rows.Add(NewFila)

            End With

        End If


        _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock (Empresa,Sucursal,Bodega,Codigo)" & vbCrLf &
                     "Values ('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "')" & vbCrLf & vbCrLf &
                     "Update " & _Global_BaseBk & "Zw_Prod_Stock SET" & vbCrLf &
                     "StComp1 = " & _StockComp1 & vbCrLf &
                     ",StComp2 = " & _StockComp2 & vbCrLf &
                     ",StPedi1 = " & _StockPedi1 & vbCrLf &
                     ",StPedi2 = " & _StockPedi2 & vbCrLf &
                     "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo = '" & _Codigo & "'" & vbCrLf & vbCrLf

        Consulta_sql = String.Empty

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Stock" & Space(1) &
                       "Where Codigo = '" & _Codigo & "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf &
                       _SqlQuery & vbCrLf &
                       Consulta_sql & vbCrLf &
                       "---------------------------" & vbCrLf & vbCrLf

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function

    Private Function Stock_A_Una_Fecha_X_Producto(_Row_Producto As DataRow,
                                                  _Empresa As String,
                                                  _Sucursal As String,
                                                  _Bodega As String,
                                                  _SQLquery As String,
                                                  _Fecha As Date) As Double()


        Dim Stock_(1) As Double

        If Not (_Row_Producto Is Nothing) Then

            Dim _Codigo = _Row_Producto.Item("KOPR")
            Dim _Rtu = _Row_Producto.Item("RLUD")

            'Dim _Redondeo As Integer

            'If _Rtu = 1 Then
            '_Redondeo = 0
            'Else
            '_Redondeo = 5
            'End If

            _SQLquery = Replace(_SQLquery, "#Empresa#", _Empresa)
            _SQLquery = Replace(_SQLquery, "#Sucursal#", _Sucursal)
            _SQLquery = Replace(_SQLquery, "#Bodega#", _Bodega)
            _SQLquery = Replace(_SQLquery, "#@Codigo#", _Codigo)
            _SQLquery = Replace(_SQLquery, "#Fecha#", Format(_Fecha, "yyyyMMdd"))
            _SQLquery = Replace(_SQLquery, "Zw_TblStockConsolid", "#Zw_TblStockConsolid")

            Dim Tbl As DataTable = _Sql.Fx_Get_DataTable(_SQLquery)

            If Tbl.Rows.Count > 0 Then
                Stock_(0) = Math.Round(Tbl.Rows(0).Item("CantidadUd1"), 5)
                Stock_(1) = Math.Round(Tbl.Rows(0).Item("CantidadUd2"), 5)
            Else
                Stock_(0) = 0
                Stock_(1) = 0
            End If

        Else
            Stock_(0) = 0
            Stock_(1) = 0
        End If

        Return Stock_

    End Function

    Private Function Fx_Stock_Reservado_Bakapp(_Row_Producto As DataRow,
                                               _Empresa As String,
                                               _Sucursal As String,
                                               _Bodega As String,
                                               _TipoDoc As String) As Double()

        Dim Stock_(1) As Double

        If Not (_Row_Producto Is Nothing) Then

            Dim _Codigo = _Row_Producto.Item("KOPR")
            Dim _Rtu = _Row_Producto.Item("RLUD")

            Consulta_sql = "Select Det.Codigo,Det.Descripcion,Det.Empresa,Det.Sucursal,Det.Bodega,Sum(CantUd1) As CantidadUd1,Sum(CantUd2) As CantidadUd2 
                            From " & _Global_BaseBk & "Zw_Casi_DocDet Det 
	                        Inner Join " & _Global_BaseBk & "Zw_Casi_DocEnc Enc On Enc.Id_DocEnc = Det.Id_DocEnc
                            Where Enc.Id_DocEnc In
                            (Select Id_DocEnc From " & _Global_BaseBk & "Zw_Casi_DocEnc
                            Where Id_DocEnc In (Select Id_Casi_DocEnc From " & _Global_BaseBk & "Zw_Remotas
                            Where NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det Where NroRemota <> '') And CodFuncionario_Autoriza = ''))
                            And Det.Empresa = '" & _Empresa & "' And Det.Sucursal = '" & _Sucursal & "' And Det.Bodega = '" & _Bodega & "' And Det.Codigo = '" & _Codigo & "' And Enc.TipoDoc = '" & _TipoDoc & "'
                            Group By Det.Codigo,Det.Descripcion,Det.Empresa,Det.Sucursal,Det.Bodega"

            Dim Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Tbl.Rows.Count > 0 Then
                Stock_(0) = Math.Round(Tbl.Rows(0).Item("CantidadUd1"), 5)
                Stock_(1) = Math.Round(Tbl.Rows(0).Item("CantidadUd2"), 5)
            Else
                Stock_(0) = 0
                Stock_(1) = 0
            End If

        Else
            Stock_(0) = 0
            Stock_(1) = 0
        End If

        Return Stock_

    End Function

End Class
