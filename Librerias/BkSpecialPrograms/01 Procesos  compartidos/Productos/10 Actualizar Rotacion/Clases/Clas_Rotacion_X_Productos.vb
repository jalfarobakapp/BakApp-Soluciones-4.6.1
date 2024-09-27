'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Clas_Rotacion_X_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Barra_Progreso As Controls.ProgressBarX
    Dim _Incluir_Ventas_Entidades_Excluidas As Boolean

    Dim _Dias_Habiles As Integer
    Dim _Dias_Sabado As Integer
    Dim _Dias_Domingo As Integer
    Dim _Dias_Total As Integer

    Dim _Progreso_Porc As Object
    Dim _Progreso_Cont As Object

    Dim _Fecha_Desde As Date
    Dim _Fecha_Hasta As Date
    Dim _Log As Object

    Dim _Cancelar As Boolean

    Public Property Pro_Barra_Progreso() As Object
        Get
            Return _Barra_Progreso
        End Get
        Set(ByVal value As Object)
            _Barra_Progreso = value
        End Set
    End Property
    Public Property Pro_Progreso_Porc() As Object
        Get
            Return _Progreso_Porc
        End Get
        Set(ByVal value As Object)
            _Progreso_Porc = value
        End Set
    End Property
    Public Property Pro_Progreso_Cont() As Object
        Get
            Return _Progreso_Cont
        End Get
        Set(ByVal value As Object)
            _Progreso_Cont = value
        End Set
    End Property

    Public Property Pro_Incluir_Ventas_Entidades_Excluidas() As Boolean
        Get
            Return _Incluir_Ventas_Entidades_Excluidas
        End Get
        Set(ByVal value As Boolean)
            _Incluir_Ventas_Entidades_Excluidas = value
        End Set
    End Property

    Public Property Pro_Fecha_Desde() As Date
        Get
            Return _Fecha_Desde
        End Get
        Set(ByVal value As Date)
            _Fecha_Desde = value
        End Set
    End Property
    Public Property Pro_Fecha_Hasta() As Date
        Get
            Return _Fecha_Hasta
        End Get
        Set(ByVal value As Date)
            _Fecha_Hasta = value
        End Set
    End Property
    Public Property Pro_Cancelar() As Boolean
        Get
            Return _Cancelar
        End Get
        Set(ByVal value As Boolean)
            _Cancelar = value
        End Set
    End Property

    Public Property Pro_Log() As Object
        Get
            Return _Log
        End Get
        Set(ByVal value As Object)
            _Log = value
        End Set
    End Property

    Public Sub New(ByVal Incluir_Ventas_Entidades_Excluidas As Boolean, _
                   ByVal Dias_Habiles As Integer, _
                   ByVal Dias_Sabado As Integer, _
                   ByVal Dias_Domingo As Integer, _
                   ByVal Dias_Total As Integer, _
                   ByVal Fecha_Desde As Date, _
                   ByVal Fecha_Hasta As Date)


        _Incluir_Ventas_Entidades_Excluidas = Incluir_Ventas_Entidades_Excluidas
        _Dias_Habiles = Dias_Habiles
        _Dias_Sabado = Dias_Sabado
        _Dias_Domingo = Dias_Domingo
        _Dias_Total = Dias_Total

        _Fecha_Desde = Fecha_Desde
        _Fecha_Hasta = Fecha_Hasta


    End Sub

    Function Fx_Procesar_Informe_Por_Producto(ByVal _RowProducto As DataRow, _
                                              ByVal _Empresa As String, _
                                              ByVal _Sucursal As String, _
                                              ByVal _Bodega As String)

        Dim _SqlQuery = String.Empty


        Dim _Con_Ent_Excluidas As Integer

        _Con_Ent_Excluidas = CInt(_Incluir_Ventas_Entidades_Excluidas) * -1


        Dim _Codigo = Trim(_RowProducto.Item("KOPR"))
        Dim _Descripcion = Trim(_RowProducto.Item("NOKOPR"))
        Dim _Rubro = Trim(_RowProducto.Item("Rubro"))
        Dim _Marca = Trim(_RowProducto.Item("Marca"))
        Dim _Zona = Trim(_RowProducto.Item("Zona"))
        Dim _Super_Familia = Trim(_RowProducto.Item("Super_Familia"))
        Dim _Familia = Trim(_RowProducto.Item("Familia"))
        Dim _Sub_Familia = Trim(_RowProducto.Item("Sub_Familia"))
        Dim _Clasificacion_Libre = Trim(_RowProducto.Item("Clasificacion_Libre"))

        Dim _Bloqueapr = Trim(_RowProducto.Item("BLOQUEAPR"))
        Dim _Oculto = Trim(_RowProducto.Item("ATPR"))

        Dim _Gdv, _Blv, _Fcv, _Ncv, _Tdv As Integer


        If Not (_Log Is Nothing) Then _Log.Text = "Procesando producto: " & Trim(_Codigo) & " -> " & _Descripcion & " - Bodega (" & _Bodega & ")"

        System.Windows.Forms.Application.DoEvents()


        _SqlQuery = vbCrLf & "-- Producto " & _Codigo & " -> " & _Descripcion & vbCrLf & vbCrLf

        Dim _EntExcluidas As String = Space(1) & "And LTRIM(RTRIM(ENDO))+RTRIM(LTRIM(SUENDO))" & vbCrLf &
                                      "NOT IN (SELECT  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal))" & vbCrLf &
                                      "From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                                      "Where Funcionario = @CodFuncionario And Excluida in ('V','A','T'))"

        Consulta_sql = "Declare @CodFuncionario As Char = '" & FUNCIONARIO & "'" & vbCrLf & vbCrLf & _
                       "Select (select COUNT(TIDO) From MAEEDO" & vbCrLf & _
                       "Where IDMAEEDO In (Select IDMAEEDO From MAEDDO Where KOPRCT = '" & _Codigo & "' And" & vbCrLf & _
                       "EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "' And TIDO IN ('GDV','GDP') And Not (TIDO = 'GDV' And ARCHIRST IN ('POTD','POTPR','POTL') And " & vbCrLf & _
                       "FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' And " & _
                       "CAPRCO1-CAPREX1 > 0) And Not " & _
                       "(TIDO='GDP' AND SUBTIDO<>'CON') " & _EntExcluidas & ")) As 'GDV'," & _
                       vbCrLf & _
                       "(select COUNT(*) From MAEDDO Where TIDO IN ('BLV') and KOPRCT = '" & _Codigo & _
                       "' And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "' And" & vbCrLf & _
                       "FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' " & _EntExcluidas & ") As 'BLV'," & _
                       vbCrLf & _
                       "(select COUNT(*) From MAEDDO Where TIDO IN ('FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FVZ','FEE') " & _
                       "And KOPRCT = '" & _Codigo & "' And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf & _
                       "And FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' " & _EntExcluidas & ") As 'FCV'," & _
                       vbCrLf & _
                       "((select COUNT(*) From MAEDDO Where TIDO IN ('NCE','NCV','NCX','NCZ','NEV') And KOPRCT = '" & _Codigo & _
                       "' And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf & _
                       "And FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' " & _EntExcluidas & ")*- 1) As 'NCV'"


        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


        If CBool(_Tbl.Rows.Count) Then
            Dim _Row_Documento As DataRow = _Tbl.Rows(0)

            _Gdv = _Row_Documento.Item("GDV")
            _Blv = _Row_Documento.Item("BLV")
            _Fcv = _Row_Documento.Item("FCV")
            _Ncv = _Row_Documento.Item("NCV")
        Else
            _Gdv = 0 : _Blv = 0 : _Fcv = 0 : _Ncv = 0
        End If

        _Tdv = _Gdv + _Blv + _Fcv + _Ncv

        Consulta_sql = "Select Top 1 FEEMLI From MAEDDO" & Space(1) & _
                       "Where TIDO in ('GRC','GRI','OCC','BLV','FCV') And KOPRCT = '" & _Codigo & "'" & vbCrLf & _
                       "And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf & _
                       "Order by FEEMLI"

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Fecha_Nacimiento As Date

        If CBool(_Tbl.Rows.Count) Then
            _Fecha_Nacimiento = _Tbl.Rows(0).Item("FEEMLI")
        Else
            _Fecha_Nacimiento = _Fecha_Desde
        End If


        _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set" & _
                     " GDV = " & _Gdv & _
                     ",BLV = " & _Blv & _
                     ",FCV = " & _Fcv & _
                     ",NCV = " & _Ncv & _
                     ",TDV = " & _Tdv & _
                     ",Fecha_Nacimiento = '" & Format(_Fecha_Nacimiento, "yyyyMMdd") & "'" & vbCrLf & _
                     "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
                     "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf


        Dim _Dias_Vida_Habiles As Integer = Fx_Cuenta_Dias(_Fecha_Nacimiento, _Fecha_Hasta, Opcion_Dias.Habiles)
        Dim _Dias_Vida_Sabados As Integer = Fx_Cuenta_Dias(_Fecha_Nacimiento, _Fecha_Hasta, Opcion_Dias.Sabado)
        Dim _Dias_Vida_Domingos As Integer = Fx_Cuenta_Dias(_Fecha_Nacimiento, _Fecha_Hasta, Opcion_Dias.Domingo)
        Dim _Dias_Vida_Total As Integer = Fx_Cuenta_Dias(_Fecha_Nacimiento, _Fecha_Hasta, Opcion_Dias.Todos) + 1


        _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set " & _
                     "Dias_Vida_Habiles = " & _Dias_Vida_Habiles & "," & _
                     "Dias_Vida_Domingos = " & _Dias_Vida_Domingos & "," & _
                     "Dias_Vida_Sabados = " & _Dias_Vida_Sabados & "," & _
                     "Dias_Vida_Total = " & _Dias_Vida_Total & vbCrLf & _
                     "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
                     "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf


        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Asis_Compra_Rotacion_X_Producto

        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)

        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)

        Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Desde, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Hasta, "yyyyMMdd"))

        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Global_BaseBk & "Zw_Prod_Rotacion")



        If _Incluir_Ventas_Entidades_Excluidas Then
            _EntExcluidas = String.Empty
        End If

        Consulta_sql = Replace(Consulta_sql, "#Entidades_Excluidas#", _EntExcluidas)

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _SumTotalQtyUd1 = De_Num_a_Tx_01(_Tbl.Rows(0).Item("SumTotalQtyUd1"), False, 2)
            Dim _SumTotalQtyUd2 = De_Num_a_Tx_01(_Tbl.Rows(0).Item("SumTotalQtyUd2"), False, 2)

            _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set " & _
                         "SumTotalQtyUd1 = " & _SumTotalQtyUd1 & "," & _
                         "SumTotalQtyUd2 = " & _SumTotalQtyUd2 & vbCrLf & _
                         "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
                         "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf

        End If

        _SqlQuery += vbCrLf & _
                     "Update " & _Global_BaseBk & "Zw_Prod_Rotacion" & Space(1) & _
                     "Set Dias_Habiles = " & _Dias_Habiles & "," & _
                     "Dias_Sabados = " & _Dias_Sabado & "," & _
                     "Dias_Domingos = " & _Dias_Domingo & "," & _
                     "Dias_Total = " & _Dias_Total & "," & _
                     "Fecha_Inicio = '" & _Fecha_Desde & "'," & _
                     "Fecha_Fin = '" & _Fecha_Hasta & "'" & vbCrLf & _
                     "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf

        Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigo & "'"
        Dim _TblProducto As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        _SqlQuery += Fx_Traer_Dias_Existencia_Stock_En_Bodega(_RowProducto, _Empresa, _Sucursal, _Bodega)

        '_SqlQuery += Fx_Dias_Existencia_Stock_En_Bodega(_Codigo, _
        '                                                _TblProducto, _
        '                                                _Empresa, _
        '                                                _Sucursal, _
        '                                                _Bodega, 0, 0)

        '_SqlQuery += Fx_Dias_Existencia_Stock_En_Bodega(_RowProducto, _
        '                                                _Empresa, _
        '                                                _Sucursal, _
        '                                                _Bodega, _
        '                                                _Fecha_Estudio_Desde, _
        '                                                _Fecha_Estudio_Hasta)

        Return _SqlQuery

    End Function

    Function Fx_Traer_Dias_Existencia_Stock_En_Bodega(ByVal _RowProducto As DataRow, _
                                                      ByVal _Empresa As String, _
                                                      ByVal _Sucursal As String, _
                                                      ByVal _bodega As String)


        Dim _Codigo = _RowProducto.Item("KOPR")
        Dim _Descripcion = _RowProducto.Item("NOKOPR")

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Stock_History", _
                                            "Codigo = '" & _Codigo & "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _bodega & "'")


        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History Where Codigo = '" & _Codigo & "'"
        Dim _Row_Zw_Prod_Stock_Enc_History As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Fecha_Ult_Revision As Date

        If _Row_Zw_Prod_Stock_Enc_History Is Nothing Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History (Codigo,Fecha_Desde) Values ('" & _Codigo & "','" & Format(_Fecha_Desde, "yyyyMMdd") & "')"
            _Sql.Ej_consulta_IDU(Consulta_sql)
            _Fecha_Ult_Revision = DateAdd(DateInterval.Day, -1, FechaDelServidor)
        Else
            _Fecha_Ult_Revision = _Row_Zw_Prod_Stock_Enc_History.Item("Fecha_Ult_Revision")
        End If

        If Not CBool(_Reg) Then _Fecha_Ult_Revision = _Fecha_Desde

        Dim _Fecha_Servidor As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

        If _Fecha_Ult_Revision < _Fecha_Servidor Then 'FormatDateTime(_Fecha_Ult_Revision, DateFormat.ShortDate) < FormatDateTime(FechaDelServidor(), DateFormat.ShortDate) Then


            Dim _sqlqry = String.Empty

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Stock_History" & vbCrLf & _
                           "Where Codigo = '" & _Codigo & "'" & Space(1) & _
                           "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _bodega & "'" & vbCrLf & _
                           "Order by Fecha_Stock Desc"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Ejecutar As Boolean

            If Not (_Row Is Nothing) Then

                If FormatDateTime(_Fecha_Ult_Revision, DateFormat.ShortDate) <> FormatDateTime(FechaDelServidor(), DateFormat.ShortDate) Then
                    _Ejecutar = True
                Else
                    _Ejecutar = False
                End If

            Else
                _Ejecutar = True
            End If

            If _Ejecutar Then
                Fx_Dias_Existencia_Stock_En_Bodega(_Codigo, _
                                                   _Descripcion, _
                                                   _Empresa, _
                                                   _Sucursal, _
                                                   _bodega, _
                                                   _Fecha_Desde, _
                                                   _Fecha_Hasta, _
                                                   _Row, _
                                                   _Fecha_Ult_Revision)
            End If

            'Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History Set Fecha_Ult_Revision = Getdate()" & vbCrLf & _
            '               "Where Codigo = '" & _Codigo & "'"
            '_Sql.Ej_consulta_IDU(Consulta_sql)

        End If


        Dim _SqlQuery As String = String.Empty
        Dim _Row_Stock_History As DataRow

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Stock_History", _
                                            "Codigo = '" & _Codigo & "' And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _bodega & "'")

        If CBool(_Reg) Then
            Consulta_sql = My.Resources.Recursos_Act_Rot_Venta.SQLQuery_Consulta_Stock_Hitory_X_Producto
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", _bodega)
            Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
            Consulta_sql = Replace(Consulta_sql, "Zw_Prod_Stock_History", _Global_BaseBk & "Zw_Prod_Stock_History")

            _Row_Stock_History = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If


        Dim _Dias_Existencia_Habiles = 0
        Dim _Dias_Existencia_Sabados = 0
        Dim _Dias_Existencia_Domingos = 0

        Dim _Dias_Quiebre_Habiles = _Dias_Habiles
        Dim _Dias_Quiebre_Sabados = _Dias_Sabado
        Dim _Dias_Quiebre_Domingos = _Dias_Domingo

        If Not (_Row_Stock_History Is Nothing) Then

            _Dias_Existencia_Habiles = _Row_Stock_History.Item("Dia_Habil")
            _Dias_Existencia_Sabados = _Row_Stock_History.Item("Dia_Sabado")
            _Dias_Existencia_Domingos = _Row_Stock_History.Item("Dia_Domingo")

            _Dias_Quiebre_Habiles -= _Dias_Existencia_Habiles
            _Dias_Quiebre_Sabados -= _Dias_Existencia_Sabados
            _Dias_Quiebre_Domingos -= _Dias_Existencia_Domingos

        End If

        _SqlQuery = "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set" & vbCrLf & _
                     "Dias_Existencia_Habiles = " & De_Num_a_Tx_01(_Dias_Existencia_Habiles, True) & "," & vbCrLf & _
                     "Dias_Existencia_Sabados = " & De_Num_a_Tx_01(_Dias_Existencia_Sabados, True) & "," & vbCrLf & _
                     "Dias_Existencia_Domingos = " & De_Num_a_Tx_01(_Dias_Existencia_Domingos, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Habiles = " & De_Num_a_Tx_01(_Dias_Quiebre_Habiles, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Sabados = " & De_Num_a_Tx_01(_Dias_Quiebre_Sabados, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Domingos = " & De_Num_a_Tx_01(_Dias_Quiebre_Domingos, True) & _
                     vbCrLf & _
                     "Where Codigo = '" & _Codigo & "'" & Space(1) & _
                     "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                     "And Bodega = '" & _bodega & "'" & vbCrLf

        ' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _

        Return _SqlQuery

    End Function


    Function Fx_Dias_Existencia_Stock_En_Bodega3(ByVal _Codigo As String, _
                                                ByVal _TblProductos As DataTable, _
                                                ByVal _Empresa As String, _
                                                ByVal _Sucursal As String, _
                                                ByVal _Bodega As String, _
                                                ByVal _Stock_Minimo As Double, _
                                                ByVal _Es_Asociador As Boolean) As String


        Dim _SqlQuery = String.Empty

        Consulta_sql = "Select Top 1 FEEMLI From MAEDDO" & Space(1) & _
                       "Where TIDO in ('GRC','GRI','OCC','BLV','FCV') And KOPRCT = '" & _Codigo & "'" & vbCrLf & _
                       "And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf & _
                       "Order by FEEMLI"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Fecha_Nacimiento As Date

        If CBool(_Tbl.Rows.Count) Then
            _Fecha_Nacimiento = _Tbl.Rows(0).Item("FEEMLI")
        Else
            _Fecha_Nacimiento = _Fecha_Desde
        End If

        Dim _Dias = DateDiff(DateInterval.Day, _Fecha_Desde, _Fecha_Hasta)
        Dim _Fecha As Date = FormatDateTime(_Fecha_Desde, DateFormat.ShortDate)



        Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")

        Consulta_sql = "Select Distinct FEEMLI From MAEDDO" & vbCrLf & _
                       "Where EMPRESA = '" & _Empresa & "' AND SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & Space(1) & _
                       "And KOPRCT In " & _Filtro_Productos & " And" & Space(1) & _
                       "FEEMLI between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'" & vbCrLf & _
                       "And TIDO Not In (Select TIDO From TABTIDO  WHERE FIAD = 0 and FICO = 0)"
        '"And TIDO Not In (Select TIDO From TABTIDO where ( TABTIDO.FICO = -1 OR TABTIDO.FIAD = -1 )  AND TABTIDO.TIDO <> 'GDI'  AND TABTIDO.TIDO <> 'GTI' )"

        Dim _Tbl_Movimientos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Dias_Movimiento As Integer = _Tbl_Movimientos.Rows.Count
        Dim _Contador_Dias_Movimiento = 0
        Dim _Feemli As Date
        'Dim _Prox_Fecha As Date


        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

        Dim _Fecha_Revision As Date = DateAdd(DateInterval.Day, -1, _Fecha_Desde)


        'If _Fecha_Nacimiento > _Fecha_Revision Then
        '_Fecha_Revision = _Fecha_Nacimiento
        '_Dias = DateDiff(DateInterval.Day, _Fecha_Revision, _Fecha_Hasta)
        'End If

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

        Dim _Row_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _StockUd1 As Double = _Row_Stock.Item("StockUd1")
        Dim _StockUd2 As Double = _Row_Stock.Item("StockUd2")

        Dim _Dias_Existencia_Habiles = 0
        Dim _Dias_Existencia_Sabados = 0
        Dim _Dias_Existencia_Domingos = 0

        Dim _Dias_Quiebre_Habiles = 0
        Dim _Dias_Quiebre_Sabados = 0
        Dim _Dias_Quiebre_Domingos = 0

        Dim _Hubo_Stock As Boolean

        If CBool(_Dias_Movimiento) Then

            If Not (_Barra_Progreso Is Nothing) Then
                _Barra_Progreso.Value = 0
                _Barra_Progreso.Maximum = _Dias
            End If

            _Feemli = FormatDateTime(_Tbl_Movimientos.Rows(0).Item("FEEMLI"), DateFormat.ShortDate)

            'Try
            '_Prox_Fecha = FormatDateTime(_Tbl_Movimientos.Rows(1).Item("FEEMLI"), DateFormat.ShortDate)
            'Catch ex As Exception
            '_Prox_Fecha = _Feemli
            'End Try

            Dim _Fecha_Minima As Date = _Feemli


            For i = 1 To _Dias

                System.Windows.Forms.Application.DoEvents()

                Dim _Fecha_Manana = DateAdd(DateInterval.Day, 1, _Fecha)

                'Try
                '_Prox_Fecha = _Tbl_Movimientos.Rows(_Contador_Dias_Movimiento + 1).Item("FEEMLI")
                'Catch ex As Exception
                '_Prox_Fecha = _Fecha_Manana
                'End Try

                'Dim _DiasDif = DateDiff(DateInterval.Day, _Fecha, _Prox_Fecha, FirstDayOfWeek.Monday)

                'If Format(_Fecha, "yyyyMMdd") = "20171120" Then
                'Dim a = 1
                'End If

                If _Fecha = _Feemli Then

                    'If _DiasDif = 1 Then
                    '_StockUd1 = 1
                    '_StockUd2 = 1

                    '_Contador_Dias_Movimiento += 1
                    'If _Contador_Dias_Movimiento < _Dias_Movimiento Then
                    '_Feemli = _Tbl_Movimientos.Rows(_Contador_Dias_Movimiento).Item("FEEMLI")
                    'End If
                    'Else

                    _Fecha_Revision = DateAdd(DateInterval.Day, -1, _Fecha)

                    Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

                    Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
                    Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
                    Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
                    Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
                    Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
                    Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

                    _Row_Stock = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _StockUd1 = _Row_Stock.Item("StockUd1")
                    _StockUd2 = _Row_Stock.Item("StockUd2")

                    _Contador_Dias_Movimiento += 1
                    If _Contador_Dias_Movimiento < _Dias_Movimiento Then
                        _Feemli = _Tbl_Movimientos.Rows(_Contador_Dias_Movimiento).Item("FEEMLI")
                    End If

                    'End If


                End If

                If Not (_Log Is Nothing) Then _Log.Text = "Revisando Historia Stock Bodega: " & _Bodega & ", Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)
                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = i

                Dim _Dia = Weekday(_Fecha)


                If _StockUd1 > _Stock_Minimo Then
                    _Hubo_Stock = True
                Else
                    'Dim _Feemli_st = "'" & Format(_Fecha, "yyyyMMdd") & "'"
                    'Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", _
                    '                      "TIDO In ('FCV','GDV','BLV','FDV')" & Space(1) & _
                    '                      "And KOPRCT in " & _Filtro_Productos & " And FEEMLI = " & _Feemli_st))
                    _Hubo_Stock = False '_Reg
                End If

                Dim _Dia_Hab = 0
                Dim _Dia_Sab = 0
                Dim _Dia_Dom = 0

                Dim _Dia_de_quiebre As Boolean = False

                'If _Fecha_Minima <= _Fecha Then
                'If _Fecha_Nacimiento <= _Fecha Then
                '_Dia_de_quiebre = True
                'Else
                '_Dia_de_quiebre = False
                'End If
                ' End If


                Select Case _Dia
                    Case 1
                        'If _Hubo_Stock Then
                        '_Dias_Existencia_Domingos += 1
                        'Else
                        '_Dias_Quiebre_Domingos += 1
                        'End If
                        _Dia_Dom = 1
                    Case 7
                        'If _Hubo_Stock Then
                        '_Dias_Existencia_Sabados += 1
                        'Else
                        '_Dias_Quiebre_Sabados += 1
                        'End If
                        _Dia_Sab = 1
                    Case Else
                        'If _Hubo_Stock Then
                        '_Dias_Existencia_Habiles += 1
                        'Else
                        '_Dias_Quiebre_Habiles += 1
                        'End If
                        _Dia_Hab = 1
                End Select

                Dim _Fecha_Stock = Format(_Fecha, "yyyyMMdd")

                If _TblProductos.Rows.Count = 1 Then

                    Dim _sqlqry = "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_History" & Space(1) & _
                                  "(Empresa,Sucursal,Bodega,Codigo,Fecha_Stock,StockUd1,StockUd2,Dia_Habil,Dia_Sabado,Dia_Domingo) Values" & Space(1) & _
                                  "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "','" & _Fecha_Stock & "'" & _
                                  "," & De_Num_a_Tx_01(_StockUd1, False, 5) & "," & De_Num_a_Tx_01(_StockUd1, False, 5) & "," & _Dia_Hab & "," & _Dia_Sab & "," & _Dia_Dom & ")"
                    _Sql.Ej_consulta_IDU(_sqlqry)

                End If

                _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Value = i

            Next

        End If

        Dim _Con_Ent_Excluidas As Integer = CInt(_Incluir_Ventas_Entidades_Excluidas) * -1

        '_SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set" & vbCrLf & _
        '             "Dias_Existencia_Habiles = " & De_Num_a_Tx_01(_Dias_Existencia_Habiles, True) & "," & vbCrLf & _
        '             "Dias_Existencia_Sabados = " & De_Num_a_Tx_01(_Dias_Existencia_Sabados, True) & "," & vbCrLf & _
        '             "Dias_Existencia_Domingos = " & De_Num_a_Tx_01(_Dias_Existencia_Domingos, True) & "," & vbCrLf & _
        '             "Dias_Quiebre_Habiles = " & De_Num_a_Tx_01(_Dias_Quiebre_Habiles, True) & "," & vbCrLf & _
        '             "Dias_Quiebre_Sabados = " & De_Num_a_Tx_01(_Dias_Quiebre_Sabados, True) & "," & vbCrLf & _
        '             "Dias_Quiebre_Domingos = " & De_Num_a_Tx_01(_Dias_Quiebre_Domingos, True) & vbCrLf & _
        '             "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
        '             "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
        '             "And Bodega = '" & _Bodega & "'" & vbCrLf



        If Not (_Log Is Nothing) Then _Log.Text = String.Empty
        If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = String.Empty

        Return _SqlQuery

    End Function

    Function Fx_Dias_Existencia_Stock_En_Bodega2(ByVal _Codigo As String, _
                                                 ByVal _TblProductos As DataTable, _
                                                 ByVal _Empresa As String, _
                                                 ByVal _Sucursal As String, _
                                                 ByVal _Bodega As String, _
                                                 ByVal _Stock_Minimo As Double, _
                                                 ByVal _Es_Asociador As Boolean) As String


        Dim _SqlQuery = String.Empty


        Dim _Dias = DateDiff(DateInterval.Day, _Fecha_Desde, _Fecha_Hasta)
        Dim _Fecha As Date = FormatDateTime(_Fecha_Desde, DateFormat.ShortDate)

        If Not (_Barra_Progreso Is Nothing) Then
            _Barra_Progreso.Value = 0
            _Barra_Progreso.Maximum = _Dias
        End If

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")

        Consulta_sql = "Select Distinct FEEMLI From MAEDDO" & vbCrLf & _
                       "Where EMPRESA = '" & _Empresa & "' AND SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & Space(1) & _
                       "And KOPRCT In " & _Filtro_Productos & " And" & Space(1) & _
                       "FEEMLI between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'"

        Dim _Tbl_Movimientos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Dias_Movimiento As Integer = _Tbl_Movimientos.Rows.Count
        Dim _Contador_Dias_Movimiento = 0
        Dim _Feemli As Date


        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

        Dim _Fecha_Revision As Date = DateAdd(DateInterval.Day, -1, _Fecha_Desde)

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

        Dim _Row_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _StockUd1 As Double = _Row_Stock.Item("StockUd1")
        Dim _StockUd2 As Double = _Row_Stock.Item("StockUd2")

        Dim _Dias_Existencia_Habiles = 0
        Dim _Dias_Existencia_Sabados = 0
        Dim _Dias_Existencia_Domingos = 0

        Dim _Dias_Quiebre_Habiles = 0
        Dim _Dias_Quiebre_Sabados = 0
        Dim _Dias_Quiebre_Domingos = 0

        If CBool(_Dias_Movimiento) Then

            _Feemli = FormatDateTime(_Tbl_Movimientos.Rows(0).Item("FEEMLI"), DateFormat.ShortDate)

            For i = 1 To _Dias

                System.Windows.Forms.Application.DoEvents()

                If _Fecha = _Feemli Then

                    _Fecha_Revision = DateAdd(DateInterval.Day, -1, _Fecha)

                    Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

                    Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
                    Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
                    Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
                    Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
                    Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
                    Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

                    _Row_Stock = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _StockUd1 = _Row_Stock.Item("StockUd1")
                    _StockUd2 = _Row_Stock.Item("StockUd2")

                    _Contador_Dias_Movimiento += 1
                    If _Contador_Dias_Movimiento < _Dias_Movimiento Then
                        _Feemli = _Tbl_Movimientos.Rows(_Contador_Dias_Movimiento).Item("FEEMLI")
                    End If

                End If

                If Not (_Log Is Nothing) Then _Log.Text = "Revisando Historia Stock Bodega: " & _Bodega & ", Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)
                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = i

                Dim _Dia = Weekday(_Fecha)

                Dim _Hubo_Stock As Boolean

                If _StockUd1 > _Stock_Minimo Then
                    _Hubo_Stock = True
                Else
                    Dim _Feemli_st = "'" & Format(_Fecha, "yyyyMMdd") & "'"
                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", _
                                          "TIDO In ('FCV','GDV','BLV','FDV')" & Space(1) & _
                                          "And KOPRCT in " & _Filtro_Productos & " And FEEMLI = " & _Feemli_st))
                    _Hubo_Stock = _Reg
                End If

                Select Case _Dia
                    Case 1
                        '_Dia_Domingo = 1
                        If _Hubo_Stock Then
                            _Dias_Existencia_Domingos += 1
                        Else
                            'If CBool(_Dias_Existencia_Domingos) Then _Dias_Quiebre_Domingos += 1
                            _Dias_Quiebre_Domingos += 1
                        End If
                    Case 7
                        '_Dia_Sabado = 1
                        If _Hubo_Stock Then
                            _Dias_Existencia_Sabados += 1
                        Else
                            'If CBool(_Dias_Existencia_Sabados) Then _Dias_Quiebre_Sabados += 1
                            _Dias_Quiebre_Sabados += 1
                        End If
                    Case Else
                        '_Dia_Habil = 1
                        If _Hubo_Stock Then
                            _Dias_Existencia_Habiles += 1
                        Else
                            'If CBool(_Dias_Existencia_Habiles) Then _Dias_Quiebre_Habiles += 1
                            _Dias_Quiebre_Habiles += 1
                        End If
                End Select

                Dim _Fecha_Stock = Format(_Fecha, "yyyyMMdd")

                _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Value = i

            Next

        End If

        Dim _Con_Ent_Excluidas As Integer = CInt(_Incluir_Ventas_Entidades_Excluidas) * -1

        '_SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set" & vbCrLf & _
        '             "Dias_Existencia_Habiles = " & De_Num_a_Tx_01(_Dias_Existencia_Habiles, True) & "," & vbCrLf & _
        '             "Dias_Existencia_Sabados = " & De_Num_a_Tx_01(_Dias_Existencia_Sabados, True) & "," & vbCrLf & _
        '             "Dias_Existencia_Domingos = " & De_Num_a_Tx_01(_Dias_Existencia_Domingos, True) & "," & vbCrLf & _
        '             "Dias_Quiebre_Habiles = " & De_Num_a_Tx_01(_Dias_Quiebre_Habiles, True) & "," & vbCrLf & _
        '             "Dias_Quiebre_Sabados = " & De_Num_a_Tx_01(_Dias_Quiebre_Sabados, True) & "," & vbCrLf & _
        '             "Dias_Quiebre_Domingos = " & De_Num_a_Tx_01(_Dias_Quiebre_Domingos, True) & vbCrLf & _
        '             "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
        '             "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
        '             "And Bodega = '" & _Bodega & "' And Es_Asociador = " & CInt(_Es_Asociador) * -1 & vbCrLf

        _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set" & vbCrLf & _
                     "Dias_Existencia_Habiles = " & De_Num_a_Tx_01(_Dias_Existencia_Habiles, True) & "," & vbCrLf & _
                     "Dias_Existencia_Sabados = " & De_Num_a_Tx_01(_Dias_Existencia_Sabados, True) & "," & vbCrLf & _
                     "Dias_Existencia_Domingos = " & De_Num_a_Tx_01(_Dias_Existencia_Domingos, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Habiles = " & De_Num_a_Tx_01(_Dias_Quiebre_Habiles, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Sabados = " & De_Num_a_Tx_01(_Dias_Quiebre_Sabados, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Domingos = " & De_Num_a_Tx_01(_Dias_Quiebre_Domingos, True) & vbCrLf & _
                     "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
                     "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                     "And Bodega = '" & _Bodega & "'" & vbCrLf



        If Not (_Log Is Nothing) Then _Log.Text = String.Empty
        If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = String.Empty

        Return _SqlQuery

    End Function

    Function Fx_Dias_Existencia_Stock_En_Bodega4(ByVal _Codigo As String, _
                                                ByVal _Empresa As String, _
                                                ByVal _Sucursal As String, _
                                                ByVal _Bodega As String, _
                                                ByVal _Fecha_Desde As Date) As String

        Dim _Fecha_Hasta As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

        Dim _SqlQuery = String.Empty

        Dim _Filtro_Productos As String = "('" & _Codigo & "')"

        ' REVISAMOS LA FECHA DE NACIMEINTO DEL PRODUCTO, ES LA FECHA EN QUE POR PRIMERA VEZ SE HIZO ALGUN DOCUMENTO QUE MUEVE STOCK
        Consulta_sql = "Select Top 1 FEEMLI From MAEDDO" & Space(1) & _
                       "Where TIDO in ('GRC','GRI','OCC','BLV','FCV') And KOPRCT = '" & _Codigo & "'" & vbCrLf & _
                       "And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf & _
                       "Order by FEEMLI"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Fecha_Nacimiento As Date

        If CBool(_Tbl.Rows.Count) Then
            _Fecha_Nacimiento = _Tbl.Rows(0).Item("FEEMLI")
        Else
            _Fecha_Nacimiento = _Fecha_Desde
        End If


        Consulta_sql = "Select Distinct FEEMLI From MAEDDO" & vbCrLf & _
                       "Where EMPRESA = '" & _Empresa & "' AND SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & Space(1) & _
                       "And KOPRCT In " & _Filtro_Productos & " And" & Space(1) & _
                       "FEEMLI between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'"
        Dim _Tbl_Movimientos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Dias_Movimiento As Integer = _Tbl_Movimientos.Rows.Count
        Dim _Contador_Dias_Movimiento = 0
        Dim _Feemli As Date

        Dim _Dias = DateDiff(DateInterval.Day, _Fecha_Desde, _Fecha_Hasta)
        Dim _Fecha As Date = FormatDateTime(_Fecha_Desde, DateFormat.ShortDate)

        Dim _Fecha_Revision As Date = _Fecha_Desde 'DateAdd(DateInterval.Day, -1, _Fecha_Desde)

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

        Dim _Row_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _StockUd1 As Double = _Row_Stock.Item("StockUd1")
        Dim _StockUd2 As Double = _Row_Stock.Item("StockUd2")

        Dim _Hubo_Stock As Boolean

        If Not (_Barra_Progreso Is Nothing) Then
            _Barra_Progreso.Value = 0
            _Barra_Progreso.Maximum = _Dias
        End If

        _Feemli = FormatDateTime(_Tbl_Movimientos.Rows(0).Item("FEEMLI"), DateFormat.ShortDate)

        If CBool(_Dias_Movimiento) Then

            _Feemli = FormatDateTime(_Tbl_Movimientos.Rows(0).Item("FEEMLI"), DateFormat.ShortDate)

            For i = 1 To _Dias

                System.Windows.Forms.Application.DoEvents()

                If _Fecha = _Feemli Then

                    _Fecha_Revision = DateAdd(DateInterval.Day, -1, _Fecha)

                    Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

                    Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
                    Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
                    Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
                    Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
                    Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
                    Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

                    _Row_Stock = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _StockUd1 = _Row_Stock.Item("StockUd1")
                    _StockUd2 = _Row_Stock.Item("StockUd2")

                    If _Contador_Dias_Movimiento < _Dias_Movimiento Then
                        _Feemli = _Tbl_Movimientos.Rows(_Contador_Dias_Movimiento).Item("FEEMLI")
                    End If
                    _Contador_Dias_Movimiento += 1

                End If

                If Not (_Log Is Nothing) Then _Log.Text = "Revisando Historia Stock Bodega: " & _Bodega & ", Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)
                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = i

                Dim _Dia = Weekday(_Fecha, FirstDayOfWeek.Monday) ' Lunes 1

                Dim _Dia_Semana As FirstDayOfWeek = Weekday(_Fecha, FirstDayOfWeek.Monday)

                Dim _Dia_Hab = 0
                Dim _Dia_Sab = 0
                Dim _Dia_Dom = 0

                Select Case _Dia_Semana
                    Case FirstDayOfWeek.Saturday
                        _Dia_Sab = 1
                    Case FirstDayOfWeek.Sunday
                        _Dia_Dom = 1
                    Case Else
                        _Dia_Hab = 1
                End Select

                Dim _Fecha_Stock = Format(_Fecha, "yyyyMMdd")

                _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Value = i

                Dim _sqlqry = "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_History" & Space(1) & _
                              "(Empresa,Sucursal,Bodega,Codigo,Fecha_Stock,StockUd1,StockUd2,Dia_Habil,Dia_Sabado,Dia_Domingo) Values" & Space(1) & _
                              "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "','" & _Fecha_Stock & "'" & _
                              "," & De_Num_a_Tx_01(_StockUd1, False, 5) & "," & De_Num_a_Tx_01(_StockUd1, False, 5) & "," & _Dia_Hab & "," & _Dia_Sab & "," & _Dia_Dom & ")"
                _Sql.Ej_consulta_IDU(_sqlqry)

            Next

        End If

        If Not (_Log Is Nothing) Then _Log.Text = String.Empty
        If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = String.Empty

    End Function

    Function Fx_Calcular_Rotacion_X_Asociacion(ByVal _Stock_Minimo As Double, _
                                               ByVal _TxtLog As Object) As Boolean

        _Cancelar = False

        '_Fecha_Inicio = Format(_Fecha_Estudio_Desde, "yyyyMMdd")
        '_Fecha_Fin = Format(_Fecha_Estudio_Hasta, "yyyyMMdd")

        '_Dias_Habiles = Fx_Cuenta_Dias(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        '_Dias_Sabado = Fx_Cuenta_Dias(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta, Opcion_Dias.Sabado)
        '_Dias_Domingo = Fx_Cuenta_Dias(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta, Opcion_Dias.Domingo)
        '_Dias_Total = Fx_Cuenta_Dias(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta, Opcion_Dias.Todos)


        Dim _Con_Ent_Excluidas As Integer = CInt(_Incluir_Ventas_Entidades_Excluidas) * -1



        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set RotDiariaUd1_Hab = Isnull((Select Sum(Isnull(RotDiariaUd1_Hab,0))" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion Z2" & vbCrLf & _
                       "Where Z1.Empresa = Z2.Empresa And Z1.Sucursal = Z2.Sucursal And Z1.Bodega = Z2.Bodega" & vbCrLf & _
                       "And Z1.Con_Ent_Excluidas = Z2.Con_Ent_Excluidas And Z2.Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = Z1.Codigo) And Z2.Es_Asociador = 0),0)," & vbCrLf & _
                       "RotDiariaUd1_Hab_y_Sab = Isnull((Select Sum(Isnull(RotDiariaUd1_Hab_y_Sab,0))" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion Z2" & vbCrLf & _
                       "Where Z1.Empresa = Z2.Empresa And Z1.Sucursal = Z2.Sucursal And Z1.Bodega = Z2.Bodega" & vbCrLf & _
                       "And Z1.Con_Ent_Excluidas = Z2.Con_Ent_Excluidas And Z2.Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = Z1.Codigo) And Z2.Es_Asociador = 0),0)," & vbCrLf & _
                       "RotDiariaUd1_Hab_y_Dom = Isnull((Select Sum(Isnull(RotDiariaUd1_Hab_y_Dom,0))" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion Z2" & vbCrLf & _
                       "Where Z1.Empresa = Z2.Empresa And Z1.Sucursal = Z2.Sucursal And Z1.Bodega = Z2.Bodega" & vbCrLf & _
                       "And Z1.Con_Ent_Excluidas = Z2.Con_Ent_Excluidas And Z2.Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = Z1.Codigo) And Z2.Es_Asociador = 0),0)," & vbCrLf & _
                       "RotDiariaUd1_Hab_Sab_Dom = Isnull((Select Sum(Isnull(RotDiariaUd1_Hab_Sab_Dom,0))" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion Z2" & vbCrLf & _
                       "Where Z1.Empresa = Z2.Empresa And Z1.Sucursal = Z2.Sucursal And Z1.Bodega = Z2.Bodega" & vbCrLf & _
                       "And Z1.Con_Ent_Excluidas = Z2.Con_Ent_Excluidas And Z2.Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = Z1.Codigo) And Z2.Es_Asociador = 0),0)," & vbCrLf & _
                       "SumTotalQtyUd1 = Isnull((Select Sum(Isnull(SumTotalQtyUd1,0))" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion Z2" & vbCrLf & _
                       "Where Z1.Empresa = Z2.Empresa And Z1.Sucursal = Z2.Sucursal And Z1.Bodega = Z2.Bodega" & vbCrLf & _
                       "And Z1.Con_Ent_Excluidas = Z2.Con_Ent_Excluidas And Z2.Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = Z1.Codigo) And Z2.Es_Asociador = 0),0)," & vbCrLf & _
                       "SumTotalQtyUd2 = Isnull((Select Sum(Isnull(SumTotalQtyUd1,0))" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion Z2" & vbCrLf & _
                       "Where Z1.Empresa = Z2.Empresa And Z1.Sucursal = Z2.Sucursal And Z1.Bodega = Z2.Bodega" & vbCrLf & _
                       "And Z1.Con_Ent_Excluidas = Z2.Con_Ent_Excluidas And Z2.Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = Z1.Codigo) And Z2.Es_Asociador = 0),0)" & _
                       vbCrLf & _
                       vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion Z1" & vbCrLf & _
                       "Where Con_Ent_Excluidas = " & _Con_Ent_Excluidas & " And Es_Asociador = 1"

        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = "Select Distinct Codigo," & vbCrLf & _
                       "(Select Top 1 Descripcion From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = Codigo) As Descripcion" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Prod_Rotacion" & vbCrLf & _
                       "Where Es_Asociador = 1 And Con_Ent_Excluidas = " & _Con_Ent_Excluidas

        Dim _Tbl_Productos_Estudio As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Try

            'Btn_Procesar.Enabled = False
            'Btn_Salir.Enabled = False
            'Btn_Cancelar.Enabled = True

            Sb_AddToLog("Producto encontrados", _Tbl_Productos_Estudio.Rows.Count, _TxtLog)
            Sb_AddToLog("Proceso", "Inicio de proceso", _TxtLog)

            Dim _Contador As Integer = 0

            Dim _SqlQuery = String.Empty

            Dim _Empresa As String
            Dim _Sucursal As String
            Dim _Bodega As String

            If Not (_Progreso_Porc Is Nothing) Then _Progreso_Porc.Maximum = 100
            If Not (_Progreso_Porc Is Nothing) Then _Progreso_Cont.Maximum = _Tbl_Productos_Estudio.Rows.Count

            For Each _Fila As DataRow In _Tbl_Productos_Estudio.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Codigo_Nodo_ As String = _Fila.Item("Codigo")

                _SqlQuery = String.Empty


                Consulta_sql = "Select Codigo,Codigo_Nodo,DescripcionBusqueda" & vbCrLf & _
                               "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf & _
                               "Where Codigo_Nodo = " & _Codigo_Nodo_


                Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR IN (" & vbCrLf & _
                               "Select Codigo" & Space(1) & _
                               "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) & _
                               "Where Codigo_Nodo = " & _Codigo_Nodo_ & ")"

                Dim _Tbl_Productos_Asociados As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                Dim _Filtro_Prod_Asoc = Generar_Filtro_IN(_Tbl_Productos_Asociados, "", "KOPR", False, False, "'")

                Consulta_sql = "Select KOPR,NOKOPR" & vbCrLf & _
                               "From MAEPR Where KOPR In " & _Filtro_Prod_Asoc

                'Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                Dim _TblBodegas As DataTable

                If CBool(_Tbl_Productos_Asociados.Rows.Count) Then

                    Dim _Descripcion = Trim(_Fila.Item("Descripcion"))

                    Sb_AddToLog(Trim(_Codigo_Nodo_), _Descripcion & " Procesando...", _TxtLog)

                    Consulta_sql = "Select DISTINCT EMPRESA,SULIDO AS KOSU,BOSULIDO AS KOBO " & vbCrLf & _
                                   "From MAEDDO WHERE KOPRCT In " & _Filtro_Prod_Asoc

                    _TblBodegas = _Sql.Fx_Get_DataTable(Consulta_sql)

                    If CBool(_TblBodegas.Rows.Count) Then

                        For Each _Fila_Bo As DataRow In _TblBodegas.Rows

                            _Empresa = _Fila_Bo.Item("EMPRESA")
                            _Sucursal = _Fila_Bo.Item("KOSU")
                            _Bodega = _Fila_Bo.Item("KOBO")

                            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Rotacion" & vbCrLf & _
                                           "Where Codigo = '" & _Codigo_Nodo_ & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas
                            Dim _Campo_Rotacion = "RotDiariaUd1_Hab"

                            Dim _Row_Rotacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                            Dim _Rotacion As Double = _Row_Rotacion.Item("RotDiariaUd1_Hab")

                            'Dim _Stock_Minimo As Double = Num_X_Dias.Value 'Math.Round(_Rotacion * Num_X_Dias.Value, 2)

                            '_SqlQuery += Fx_Dias_Existencia_Stock_En_Bodega(_Codigo_Nodo_, _
                            '                                                _Tbl_Productos_Asociados, _
                            '                                                _Empresa, _
                            '                                                _Sucursal, _
                            '                                                _Bodega, _
                            '                                                _Stock_Minimo, _
                            '                                                True) & vbCrLf & vbCrLf

                        Next

                    End If


                    If String.IsNullOrEmpty(_SqlQuery) Then
                        Sb_AddToLog(Trim(_Codigo_Nodo_), _Descripcion & " No está asociado a ninguna bodega", _TxtLog)

                    Else
                        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
                            Sb_AddToLog(Trim(_Codigo_Nodo_), _Descripcion & " OK", _TxtLog)
                        End If
                    End If

                Else
                    Sb_AddToLog(Trim(_Codigo_Nodo_), "PROBLEMA!!", _TxtLog)
                End If

                _Contador += 1

                _Progreso_Porc.Value = ((_Contador * 100) / _Tbl_Productos_Estudio.Rows.Count)
                _Progreso_Cont.Value += 1

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set " & _
                               "Fecha_Inicio = '" & Format(_Fecha_Desde, "yyyyMMdd") & "'," & vbCrLf & _
                               "Fecha_Fin = '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'," & vbCrLf & _
                               "Fecha_Ultima_Ejecucion = GetDate()," & vbCrLf & _
                               "RotDiariaUd1_Hab = round(case When SumTotalQtyUd1 > 0 and Dias_Existencia_Habiles > 0 then SumTotalQtyUd1/Dias_Existencia_Habiles else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd1_Hab_y_Sab = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Sabados) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd1_Hab_y_Dom = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd1_Hab_Sab_Dom = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab = round(case When SumTotalQtyUd2 > 0 and Dias_Existencia_Habiles > 0 then SumTotalQtyUd2/Dias_Existencia_Habiles else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab_y_Sab = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Sabados) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab_y_Dom = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab_Sab_Dom = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) else 0 end,5)" & vbCrLf & _
                               "Where Codigo = '" & _Codigo_Nodo_ & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


                If _Cancelar Then
                    Sb_AddToLog("Proceso", "Acción cancelada por el usuario", _TxtLog)
                    MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf & _
                                      "Ultimo producto procesado: " & _Codigo_Nodo_, "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

            Next



            MessageBoxEx.Show(Me, "FIN DEL PROCESO", _
                                  "PROCESAR ROTACION", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True




        Catch ex As Exception
            'MsgBox(ex.Message)
            'myTrans.Rollback()
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            'Btn_Procesar.Enabled = True
            'Btn_Salir.Enabled = True
            'Btn_Cancelar.Enabled = False

            'Progreso_Porc.Value = 0
            'Progreso_Cont.Value = 0
            'Barra_Progreso_Quiebres_Stock.Value = 0

            'Me.KeyPreview = True

        End Try

        '   Me.Refresh()

    End Function


    Sub Sb_AddToLog(ByVal _Accion As String, _
                            ByVal _Descripcion As String, _
                            ByVal _TxtLog As Object)

        _TxtLog.Text += DateTime.Now.ToString() & " - " & _Accion & " (" & _Descripcion & ")" & vbCrLf
        _TxtLog.Select(_TxtLog.Text.Length - 1, 0)
        _TxtLog.ScrollToCaret()

    End Sub

    Function Fx_Dias_Existencia_Stock_En_Bodega(ByVal _Codigo As String, _
                                                ByVal _Descripcion As String, _
                                                ByVal _Empresa As String, _
                                                ByVal _Sucursal As String, _
                                                ByVal _Bodega As String, _
                                                ByVal _Fecha_Estudio_Desde As Date, _
                                                ByVal _Fecha_Estudio_Hasta As Date, _
                                                ByVal _Row_Ult_Stock_Hitory As DataRow, _
                                                ByVal _Fecha_Ult_Revision As Date) As String


        Dim _TblKardex As DataTable
        Dim _Feemli As Date
        Dim _StockUd1 As Double
        Dim _StockUd2 As Double

        Dim _Dias As Double
        Dim _Fecha As Date
        Dim _Hubo_Stock As Boolean

        Dim _Fecha_Revision As Date
        'Dim _Fecha_Ult_Revision As Date


        If (_Row_Ult_Stock_Hitory Is Nothing) Then
            _Fecha_Ult_Revision = _Fecha_Estudio_Desde
        Else
            '_Fecha_Ult_Revision = _Row_Ult_Stock_Hitory.Item("Fecha_Ult_Revision")
            'Dim _Fecha_Stock = _Row_Ult_Stock_Hitory.Item("Fecha_Stock")

            'If _Fecha_Stock < _Fecha_Ult_Revision Then
            _Fecha_Estudio_Desde = _Fecha_Ult_Revision
            'End If

        End If

        Dim _Mov = _Sql.Fx_Cuenta_Registros("MAEDDO", _
                                            "EMPRESA = '" & _Empresa & "' AND SULIDO = '" & _Sucursal & "' AND BOSULIDO = '" & _Bodega & _
                                            "' AND KOPRCT = '" & _Codigo & "'" & Space(1) & _
                                            "And FEEMLI BETWEEN '" & Format(_Fecha_Estudio_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Estudio_Hasta, "yyyyMMdd") & "'")


        Dim _SqlQuery = String.Empty

        If CBool(_Mov) Then

            Dim _Filtro_Productos As String = "('" & _Codigo & "')"



            ' REVISAMOS LA FECHA DE NACIMEINTO DEL PRODUCTO, ES LA FECHA EN QUE POR PRIMERA VEZ SE HIZO ALGUN DOCUMENTO QUE MUEVE STOCK
            Consulta_sql = "Select Top 1 FEEMLI From MAEDDO" & Space(1) & _
                           "Where TIDO in ('GRC','GRI','OCC','BLV','FCV') And KOPRCT = '" & _Codigo & "'" & vbCrLf & _
                           "And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf & _
                           "Order by FEEMLI"

            Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Fecha_Nacimiento As Date

            If CBool(_Tbl.Rows.Count) Then
                _Fecha_Nacimiento = _Tbl.Rows(0).Item("FEEMLI")
            Else
                _Fecha_Nacimiento = _Fecha_Estudio_Desde
            End If

            Dim _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI,MAEEDO.HORAGRAB,MAEDDO.SEMILLA,MAEDDO.IDMAEEDO"
            Dim _Filtro_Condicion_Extra = "AND MAEDDO.FEEMLI >= '" & Format(_Fecha_Estudio_Desde, "yyyyMMdd") & "' AND MAEDDO.TIDO NOT IN ('OCC','NVV','NVI','OCI','COV')"

            Consulta_sql = My.Resources._24_Recursos.Kardex_de_inventario
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
            Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
            Consulta_sql = Replace(Consulta_sql, "#Top#", "")
            Consulta_sql = Replace(Consulta_sql, "#Orden#", _Orden)
            Consulta_sql = Replace(Consulta_sql, "--Filtro_Condicion_Extra", _Filtro_Condicion_Extra)
            Consulta_sql = Replace(Consulta_sql, "#Ud#", 1)

            _TblKardex = _Sql.Fx_Get_DataTable(Consulta_sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

            _Fecha_Revision = Primerdiadelmes(DateAdd(DateInterval.Day, -1, _Fecha_Estudio_Desde))

            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
            Consulta_sql = Replace(Consulta_sql, "#Codigo#", "('" & _Codigo & "')")
            Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

            Dim _Row_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _StockUd1 = _Row_Stock.Item("StockUd1")
            _StockUd2 = _Row_Stock.Item("StockUd2")

            _Dias = DateDiff(DateInterval.Day, _Fecha_Revision, _Fecha_Hasta)
            _Fecha = FormatDateTime(_Fecha_Revision, DateFormat.ShortDate)

        End If


        Dim _sqlqry

        Dim _Revisar_Kardex As Boolean

        If (_TblKardex Is Nothing) Then
            _Revisar_Kardex = False
        Else
            _Revisar_Kardex = CBool(_TblKardex.Rows.Count)
        End If


        If _Revisar_Kardex Then

            _Feemli = _TblKardex.Rows(0).Item("FEEMLI")

            If _StockUd1 > 0 Then
                _Hubo_Stock = True
            Else
                _Fecha_Revision = DateAdd(DateInterval.Day, -1, _Feemli)
                _Fecha = _Fecha_Revision
                _Hubo_Stock = False
            End If

            _Dias = DateDiff(DateInterval.Day, _Fecha_Revision, _Fecha_Hasta)

            If Not (_Barra_Progreso Is Nothing) Then
                _Barra_Progreso.Value = 0
                _Barra_Progreso.Maximum = _Dias
            End If

            _sqlqry = "Delete " & _Global_BaseBk & "Zw_Prod_Stock_History" & vbCrLf & _
                      "Where Codigo = '" & _Codigo & "' And Fecha_Stock >= '" & Format(_Fecha_Revision, "yyyyMMdd") & "'" & Space(1) & _
                      "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf & vbCrLf

            Dim _Contador_Kardex = 0

            For i = 1 To _Dias

                System.Windows.Forms.Application.DoEvents()

                If _Contador_Kardex = 93 Then
                    Dim a = 1
                End If

                Dim _Stfisico As Double = 0
                Dim _Devengado As Double = 0

                If _Fecha = _Feemli Then



                    Do

                        _Stfisico = _TblKardex.Rows(_Contador_Kardex).Item("STFISICO")
                        _Devengado = _TblKardex.Rows(_Contador_Kardex).Item("DEVENGADO")

                        If _Devengado < 0 Then
                            _Devengado = _Devengado * -1
                        End If

                        _StockUd1 += _Stfisico
                        Dim _Idmaeedo = _TblKardex.Rows(_Contador_Kardex).Item("IDMAEEDO")
                        _Contador_Kardex += 1

                        If _Contador_Kardex < _TblKardex.Rows.Count Then
                            _Feemli = _TblKardex.Rows(_Contador_Kardex).Item("FEEMLI")
                        Else
                            Exit Do
                        End If

                    Loop While _Fecha = _Feemli

                    If Format(_Fecha, "yyyyMMdd") = "20171015" Then ' 2017 - 10 - 15 Then
                        Dim a = 0
                    End If

                End If

                If _StockUd1 < 0 Then
                    Dim A = 0
                End If

                If _Contador_Kardex < _TblKardex.Rows.Count Then
                    _Hubo_Stock = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", _
                                                                 "EMPRESA = '" & _Empresa & "' AND SULIDO = '" & _Sucursal & "' AND BOSULIDO = '" & _Bodega & _
                                                                 "' AND KOPRCT = '" & _Codigo & _
                                                                 "' And TIDO In ('FCV','BLV','GDV','NCC','GRC','GRI') And FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'"))
                End If

                If Not _Hubo_Stock Then
                    If _StockUd1 > 0 Then
                        _Hubo_Stock = True
                    Else
                        _Hubo_Stock = False
                    End If
                End If

                If Not (_Log Is Nothing) Then _Log.Text = "Revisando Historia Stock Bodega: " & _Bodega & _
                                                           ", Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate) & " - " & _Codigo & " - " & _Descripcion
                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = i

                Dim _Dia = Weekday(_Fecha, FirstDayOfWeek.Monday) ' Lunes 1

                Dim _Dia_Semana As FirstDayOfWeek = Weekday(_Fecha, FirstDayOfWeek.Monday)

                Dim _Dia_Hab = 0
                Dim _Dia_Sab = 0
                Dim _Dia_Dom = 0

                Select Case _Dia_Semana
                    Case FirstDayOfWeek.Saturday
                        _Dia_Sab = 1
                    Case FirstDayOfWeek.Sunday
                        _Dia_Dom = 1
                    Case Else
                        _Dia_Hab = 1
                End Select

                Dim _Fecha_Stock = Format(_Fecha, "yyyyMMdd")

                _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

                If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Value = i

                If _Hubo_Stock Then
                    _sqlqry += "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_History" & Space(1) & _
                              "(Empresa,Sucursal,Bodega,Codigo,Fecha_Stock,StockUd1,StockUd2,Dia_Habil,Dia_Sabado,Dia_Domingo,Hubo_Stock) Values" & Space(1) & _
                              "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "','" & _Fecha_Stock & "'" & _
                              "," & De_Num_a_Tx_01(_StockUd1, False, 5) & "," & De_Num_a_Tx_01(_StockUd2, False, 5) & _
                              "," & _Dia_Hab & "," & _Dia_Sab & "," & _Dia_Dom & "," & CInt(_Hubo_Stock) * -1 & ")" & vbCrLf

                End If

            Next

            'If (_Row_Ult_Stock_Hitory Is Nothing) Then
            '_sqlqry += "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_History" & Space(1) & _
            '           "(Empresa,Sucursal,Bodega,Codigo,Fecha_Stock,StockUd1,StockUd2,Dia_Habil,Dia_Sabado,Dia_Domingo,Hubo_Stock) Values" & Space(1) & _
            '           "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "',Getdate(),0,0,0,0,0,0)" & vbCrLf
            'End If


        Else

            'If Not (_Row_Ult_Stock_Hitory Is Nothing) Then

            '_StockUd1 = _Row_Ult_Stock_Hitory.Item("StockUd1")
            '_Hubo_Stock = _Row_Ult_Stock_Hitory.Item("Hubo_Stock")

            'Dim _Dia_Semana As FirstDayOfWeek = Weekday(_Fecha_Estudio_Hasta, FirstDayOfWeek.Monday)

            'Dim _Dia_Hab = 0
            'Dim _Dia_Sab = 0
            'Dim _Dia_Dom = 0

            'Select Case _Dia_Semana
            'Case FirstDayOfWeek.Saturday
            '_Dia_Sab = 1
            'Case FirstDayOfWeek.Sunday
            '_Dia_Dom = 1'
            'Case Else
            '_Dia_Hab = 1
            'End Select

            '_sqlqry = "Delete " & _Global_BaseBk & "Zw_Prod_Stock_History" & vbCrLf & _
            '          "Where Codigo = '" & _Codigo & "' And Fecha_Stock >= '" & Format(_Fecha_Ult_Revision, "yyyyMMdd") & "'" & Space(1) & _
            '          "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf & vbCrLf & _
            '          "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_History" & Space(1) & _
            '          "(Empresa,Sucursal,Bodega,Codigo,Fecha_Stock,StockUd1,StockUd2,Dia_Habil,Dia_Sabado,Dia_Domingo,Hubo_Stock) Values" & Space(1) & _
            '          "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "',Getdate()," & De_Num_a_Tx_01(_StockUd1, False, 5) & _
            '          ",0," & _Dia_Hab & "," & _Dia_Sab & "," & _Dia_Dom & "," & CBool(_Hubo_Stock) * -1 & ")" & vbCrLf

            'End If

        End If

        If Not String.IsNullOrEmpty(_sqlqry) Then
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_sqlqry)
        End If

        If Not (_Log Is Nothing) Then _Log.Text = String.Empty
        If Not (_Barra_Progreso Is Nothing) Then _Barra_Progreso.Text = String.Empty

    End Function


    Function Fx_Generar_Kardex(ByVal _Empresa As String, _
                               ByVal _Sucursal As String, _
                               ByVal _Bodega As String, _
                               ByVal _Codigo As String, _
                               ByVal _Unidad As Integer) As DataTable

        Dim _Orden = "ORDER BY MAEDDO.KOPRCT,MAEDDO.FEEMLI,MAEEDO.HORAGRAB,MAEDDO.SEMILLA,MAEDDO.IDMAEEDO"

        Consulta_sql = My.Resources._24_Recursos.Kardex_de_inventario
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Top#", "")
        Consulta_sql = Replace(Consulta_sql, "#Orden#", _Orden)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Unidad)

        Dim _TblKardex As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

        Return _TblKardex


    End Function

End Class
