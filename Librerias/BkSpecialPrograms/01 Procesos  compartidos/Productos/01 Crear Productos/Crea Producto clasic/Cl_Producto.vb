Public Class Cl_Producto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowProducto As DataRow
    Dim _Ds_Producto As DataSet
    Dim _Ds_Producto_Conf As DataSet
    Dim _Row_Maepr As DataRow

    Dim _Tbl_Maepr As DataTable
    Dim _Tbl_Maeprem As DataTable
    Dim _Tbl_Maefichd As DataTable
    Dim _Tbl_Tabimpr As DataTable
    Dim _Tbl_Maeprobs As DataTable

    Dim _Tbl_Empresas As DataTable
    Dim _Tbl_Bodegas As DataTable
    Dim _Tbl_Listas As DataTable
    Dim _Tbl_Impuestos As DataTable

    Public Property Ficha As String

    Public Property Zw_Producto As New Zw_Productos

#Region "VARIABLES"

    Dim _Accion As Enum_Accion

#Region "MAEPR"

    Dim _tipr As String
    Dim _kopr As String
    Dim _nokopr As String
    Dim _koprra As String
    Dim _nokoprra As String
    Dim _koprte As String
    Dim _koge As String
    Dim _nmarca As String
    Dim _ud01pr As String
    Dim _ud02pr As String
    Dim _rlud As String
    Dim _poivpr As String
    Dim _nuimpr As String
    Dim _rgpr As String
    Dim _stmipr As String
    Dim _stmapr As String
    Dim _mrpr As String
    Dim _atpr As String
    Dim _rupr As String
    Dim _stfi1 As String
    Dim _stdv1 As String
    Dim _stocnv1 As String
    Dim _stfi2 As String
    Dim _stdv2 As String
    Dim _stocnv2 As String
    Dim _ppul01 As String
    Dim _ppul02 As String
    Dim _moul As String
    Dim _timoul As String
    Dim _taul As String
    Dim _feul As String
    Dim _pm As String
    Dim _fepm As String
    Dim _fmpr As String
    Dim _pfpr As String
    Dim _hfpr As String
    Dim _vali As String
    Dim _fevali As String
    Dim _ttrepr As String
    Dim _prrg As Integer
    Dim _niprrg As String
    Dim _nfprrg As String
    Dim _pmin As String
    Dim _camico As String
    Dim _camifa As String
    Dim _lomifa As String
    Dim _plano As String
    Dim _stdv1c As String
    Dim _stocnv1c As String
    Dim _stdv2c As String
    Dim _stocnv2c As String
    Dim _metrco As String
    Dim _despnofac1 As String
    Dim _despnofac2 As String
    Dim _recenofac1 As String
    Dim _recenofac2 As String
    Dim _tratalote As Integer
    Dim _divisible As String
    Dim _mudefa As String
    Dim _exento As Integer
    Dim _komode As String
    Dim _prdesres As Integer
    Dim _liscosto As String
    Dim _stockaseg As Integer
    Dim _esactfi As Integer
    Dim _clalibpr As String
    Dim _kofupr As String
    Dim _koprdim As String
    Dim _nodim1 As String
    Dim _nodim2 As String
    Dim _nodim3 As String
    Dim _bloqueapr As String
    Dim _zonapr As String
    Dim _conubic As Integer
    Dim _ltsubic As String
    Dim _pesoubic As String
    Dim _funclote As String
    Dim _lomafa As String
    Dim _colegpr As String
    Dim _morgpr As String
    Dim _fecrpr As String
    Dim _femopr As String
    Dim _lotecaja As Integer
    Dim _sttr1 As String
    Dim _sttr2 As String
    Dim _podeivpr As String
    Dim _divisible2 As String
    Dim _movetiq As Integer
    Dim _repuesto As String
    Dim _vidamedia As String
    Dim _tratvmedia As Integer
    Dim _presalcli1 As String
    Dim _presalcli2 As String
    Dim _presdepro1 As String
    Dim _presdepro2 As String
    Dim _consalcli1 As String
    Dim _consalcli2 As String
    Dim _consdepro1 As String
    Dim _consdepro2 As String
    Dim _devengncv1 As String
    Dim _devengncv2 As String
    Dim _devengncc1 As String
    Dim _devengncc2 As String
    Dim _devsinncv1 As String
    Dim _devsinncv2 As String
    Dim _devsinncc1 As String
    Dim _devsinncc2 As String
    Dim _stenfab1 As String
    Dim _stenfab2 As String
    Dim _streqfab1 As String
    Dim _streqfab2 As String
    Dim _pmme As String
    Dim _fepmme As String
    Dim _valunflekm As String
    Dim _analizable As Integer
    Dim _tolelote As String
    Dim _pmifrs As String
    Dim _fepmifrs As String

    Dim _alto As String
    Dim _ancho As String
    Dim _largo As String

#End Region

#End Region

    Enum Enum_Accion
        Nuevo
        Editar
    End Enum

    Public Property Pro_Row_Maepr As DataRow
        Get
            Return _Row_Maepr
        End Get
        Set(value As DataRow)
            _Row_Maepr = value
        End Set
    End Property

    Public Property Pro_Accion As Enum_Accion
        Get
            Return _Accion
        End Get
        Set(value As Enum_Accion)
            _Accion = value
        End Set
    End Property

    Public Property Pro_Maepr As DataTable
        Get
            Return _Tbl_Maepr
        End Get
        Set(value As DataTable)
            _Tbl_Maepr = value
        End Set
    End Property

    Public Property Pro_Maeprem As DataTable
        Get
            Return _Tbl_Maeprem
        End Get
        Set(value As DataTable)
            _Tbl_Maeprem = value
        End Set
    End Property

    Public Property Pro_Maeficha As DataTable
        Get
            Return _Tbl_Maefichd
        End Get
        Set(value As DataTable)
            _Tbl_Maefichd = value
        End Set
    End Property

    Public Property Pro_Tabimpr As DataTable
        Get
            Return _Tbl_Tabimpr
        End Get
        Set(value As DataTable)
            _Tbl_Tabimpr = value
        End Set
    End Property

    Public Property Pro_Maeprobs As DataTable
        Get
            Return _Tbl_Maeprobs
        End Get
        Set(value As DataTable)
            _Tbl_Maeprobs = value
        End Set
    End Property

    Public Property Pro_Tbl_Empresas As DataTable
        Get
            Return _Tbl_Empresas
        End Get
        Set(value As DataTable)
            _Tbl_Empresas = value
        End Set
    End Property

    Public Property Pro_Tbl_Bodegas As DataTable
        Get
            Return _Tbl_Bodegas
        End Get
        Set(value As DataTable)
            _Tbl_Bodegas = value
        End Set
    End Property

    Public Property Pro_Tbl_Listas As DataTable
        Get
            Return _Tbl_Listas
        End Get
        Set(value As DataTable)
            _Tbl_Listas = value
        End Set
    End Property

    Public Property Pro_Tbl_Impuestos As DataTable
        Get
            Return _Tbl_Impuestos
        End Get
        Set(value As DataTable)
            _Tbl_Impuestos = value
        End Set
    End Property

    Public Sub New()

        'RowProducto As DataRow,
        ' Ds_Producto As DataSet)

        '_RowProducto = RowProducto
        '_Ds_Producto = Ds_Producto



        '  _New_CostoProductoUD1 As Double
        ' _New_CostoProductoUD2 As Double

    End Sub

    Function Fx_Grabar_Producto(Optional _Accion As Enum_Accion = Enum_Accion.Nuevo,
                                Optional _Reemplaza_Codigo As Boolean = False,
                                Optional _Crear_Alternativo As Boolean = False,
                                Optional _CodProveedor As String = "",
                                Optional _CodAlternativo As String = "")


        Dim _Tbl_Maepr As DataTable
        Dim _Tbl_Maeprem As DataTable
        Dim _Tbl_Maefichd As DataTable

        If (_RowProducto Is Nothing) Then
            Return False
        End If

        Dim _Tbl_Paso As DataTable

        Try

            Dim _SqlQuery = String.Empty

            Dim _Pm, _Ppul01, _Ppul02 As Double
            Dim _Ficha As String

            _SqlQuery += "Insert Into MAEPR (TIPR,KOPR,NOKOPR,KOPRRA,KOPRTE,KOGE,NOKOPRRA,POIVPR,EXENTO," & vbCrLf &
                         "RGPR,UD01PR,UD02PR,RLUD,NMARCA,TRATALOTE,FUNCLOTE,CONUBIC,ESACTFI,PRRG,NIPRRG," & vbCrLf &
                         "NFPRRG,NUIMPR,MRPR,RUPR,COLEGPR,FMPR,PFPR,HFPR,PLANO,ATPR,LISCOSTO,DIVISIBLE," & vbCrLf &
                         "DIVISIBLE2,STOCKASEG,MOVETIQ,TRATVMEDIA,PRDESRES,CLALIBPR,KOPRDIM,NODIM1,NODIM2," & vbCrLf &
                         "NODIM3,KOFUPR,ZONAPR,BLOQUEAPR,FECRPR,LOTECAJA,PODEIVPR,TOLELOTE,VIDAMEDIA,PESOUBIC," & vbCrLf &
                         "LTSUBIC,PPUL01,PPUL02,PM) " & vbCrLf &
                         "VALUES ( '" & _tipr & "','" & _kopr & "','" & _nokopr &
                         "','" & _koprra & "','" & _koprte & "','" & _koge &
                         "','" & Mid(_nokopr, 1, 20) &
                         "'," & _poivpr & "," & _exento & ",'" & _rgpr &
                         "','" & _ud01pr & "','" & _ud02pr & "'," & De_Num_a_Tx_01(_rlud, False, 5) &
                         ",'" & _nmarca & "'," & _tratalote & ",''," & _conubic &
                         "," & _esactfi & "," & _prrg & ",'',''," & _nuimpr & "," &
                         "'" & _mrpr & "','" & _rupr & "','','" & _fmpr &
                         "','" & _pfpr & "','" & _hfpr & "','" & _plano &
                         "','" & _atpr & "','" & _liscosto & "','" & _divisible & "','" & _divisible2 &
                         "'," & _stockaseg & "," & _movetiq & "," & _tratvmedia &
                         " ,0,'" & _clalibpr & " ','','','','','" & _kofupr &
                         "','" & _zonapr & "','" & _bloqueapr & "','" & Format(_fecrpr, "yyyyMMdd") &
                         "'," & _lotecaja & "," & _podeivpr & "," & _tolelote &
                         "," & _vidamedia & "," & _pesoubic &
                         "," & _ltsubic &
                         "," & De_Num_a_Tx_01(_Ppul01, False, 5) & "," & De_Num_a_Tx_01(_Ppul02, False, 5) &
                         "," & De_Num_a_Tx_01(_Pm, False, 5) & ")" & vbCrLf & vbCrLf

            If _Accion = Enum_Accion.Editar Then

                Consulta_sql = "Select * From MAEPR Where KOPR = ''
                            Select * From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _kopr & "'
                            Select Top 1 * From MAEFICHA Where KOPR = '" & _kopr & "'"
                Dim _Ds_Producto As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                _Tbl_Maepr = _Ds_Producto.Tables(0)
                _Tbl_Maeprem = _Ds_Producto.Tables(1)
                _Tbl_Maefichd = _Ds_Producto.Tables(2)

                If CBool(_Tbl_Maeprem.Rows.Count) Then
                    _Pm = _Tbl_Maeprem.Rows(0).Item("PM")
                    _Ppul01 = _Tbl_Maeprem.Rows(0).Item("PPUL01")
                    _Ppul02 = _Tbl_Maeprem.Rows(0).Item("PPUL02")
                End If

                _Ficha = NuloPorNro(_Tbl_Maefichd.Rows(0).Item("FICHA"), "") ' _Sql.Fx_Trae_Dato(, "FICHA", "MAEFICHA", "KOPR = '" & _Kopr & "'")

                _SqlQuery = "Delete MAEPR Where KOPR = '" & _kopr & "'" & vbCrLf &
                            "Delete MAEPREM Where KOPR = '" & _kopr & "'" & vbCrLf &
                            "Delete MAEFICHA Where KOPR = '" & _kopr & "'" & vbCrLf &
                            "Delete TABIMPR Where KOPR = '" & _kopr & "'" & vbCrLf &
                            "Delete MAEPROBS Where KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf

            End If

            If Not _Reemplaza_Codigo Then

                'INGRESO DE PRODUCTO EN TABLA DE FICHAS DEL PRODUCTO
                '_SqlQuery += "INSERT INTO MAEFICHA (KOPR,NOKOPR,FICHA) VALUES ('" & _kopr &
                '             "','" & _nokopr & "','')" & vbCrLf & vbCrLf

                _SqlQuery += "Delete MAEFICHD Where KOPR='" & _kopr & "'" & vbCrLf

                Dim _ListaFichas As New List(Of String)

                Dim _Div = Math.Ceiling(Ficha.Length / 80)
                Dim _Ini = 1
                For i = 1 To _Div
                    _ListaFichas.Add(Mid(Ficha.ToString, _Ini, 80))
                    _Ini += 80
                Next

                For Each _Fichas As String In _ListaFichas
                    _SqlQuery += "INSERT INTO MAEFICHD (KOPR,FICHA) VALUES ('" & _kopr & "','" & _Fichas & "')" & vbCrLf
                Next

                'INGRESO DE PRODUCTOS POR EMPRESA
                _Tbl_Paso = New DataTable
                _Tbl_Paso = _Ds_Producto.Tables("Tbl_Empresa")

                For Each _Fila As DataRow In _Tbl_Paso.Rows

                    Dim _Empresa = _Fila.Item("Codigo")
                    Dim _Insertar_En_Empresa = True

                    If _Accion = Enum_Accion.Editar Then
                        Dim _Row_Maeprem = _Tbl_Maeprem.Select("EMPRESA = '" & _Empresa & "'")
                        If CBool(_Row_Maeprem.Length) Then
                            _Insertar_En_Empresa = False
                        End If
                    End If

                    If _Insertar_En_Empresa Then

                        Dim _Select As Boolean = _Fila.Item("Select")
                        Dim _Cod As String = _Fila.Item("Codigo")
                        Dim _Des As String = _Fila.Item("Descripcion")

                        If _Select Then
                            _SqlQuery += "INSERT INTO MAEPREM ( EMPRESA,KOPR,LISCOSTO,PPUL01,PPUL02,PM) VALUES " &
                                         "( '" & _Empresa &
                                         "','" & _kopr &
                                         "',''," & De_Num_a_Tx_01(_Ppul01, False, 5) &
                                         "," & De_Num_a_Tx_01(_Ppul02, False, 5) &
                                         "," & De_Num_a_Tx_01(_Pm, False, 5) & ")" & vbCrLf & vbCrLf
                        End If

                    End If

                Next

                'INGRESO DE IMPUESTOS EN TABLA DE IMPUESTOS POR PRODUCTO
                _Tbl_Paso = New DataTable
                _Tbl_Paso = _Ds_Producto.Tables("Tbl_Impuestos")
                For Each _Fila As DataRow In _Tbl_Paso.Rows
                    Dim _Select As Boolean = _Fila.Item("Select")
                    Dim _Cod As String = _Fila.Item("Codigo")
                    Dim _Des As String = _Fila.Item("Descripcion")
                    If _Select Then
                        _SqlQuery += "INSERT INTO TABIMPR (KOPR,KOIM) VALUES ( '" & _kopr &
                                     "','" & _Cod & "')" & vbCrLf & vbCrLf
                    End If
                Next

                'INGRESO DE PRODUCTOS A LA LISTA DE PRECIOS

                _Tbl_Paso = New DataTable
                _Tbl_Paso = _Ds_Producto.Tables("Tbl_Listas")
                For Each _Fila As DataRow In _Tbl_Paso.Rows

                    Dim _Select As Boolean = _Fila.Item("Select")
                    Dim _Kolt As String = _Fila.Item("Codigo")
                    Dim _Des As String = _Fila.Item("Descripcion")

                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABPRE",
                                                "KOLT = '" & _Kolt & "' And KOPR = '" & _kopr & "'"))

                    If _Select Then
                        If Not _Reg Then

                            Dim _Ecuacion As String = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF01UD", "KOLT = '" & _Kolt & "'")
                            Dim _Ecuacionu2 As String = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF02UD", "KOLT = '" & _Kolt & "'")

                            _SqlQuery += "INSERT INTO TABPRE (KOPR,KOLT,KOPRRA,KOPRTE,RLUD,ECUACION,ECUACIONU2) VALUES ('" & _kopr &
                                        "','" & _Kolt & "','" & _koprra &
                                        "','" & _koprte & "'," & De_Num_a_Tx_01(_rlud, False, 5) &
                                        ",'" & _Ecuacion & "','" & _Ecuacionu2 & "')" & vbCrLf & vbCrLf
                        End If
                    Else
                        _SqlQuery += "Delete TABPRE Where KOLT = '" & _Kolt & "' And KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf
                    End If
                Next


                'INGRESO DE PRODUCTOS A LA BODEGA
                _Tbl_Paso = New DataTable
                _Tbl_Paso = _Ds_Producto.Tables("Tbl_Bodegas")

                For Each _Fila As DataRow In _Tbl_Paso.Rows
                    Dim _Select As Boolean = _Fila.Item("Select")
                    Dim _Cod As String = _Fila.Item("Codigo")
                    Dim _Des As String = _Fila.Item("Descripcion")

                    Dim EmSucBod = Split(_Cod, "-")

                    Dim _Em_Suc_Bod = Split(_Cod, "-")

                    Dim _Empresa = _Em_Suc_Bod(0)
                    Dim _Kosu = _Em_Suc_Bod(1)
                    Dim _Kobo = _Em_Suc_Bod(2)

                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABBOPR",
                                                "EMPRESA ='" & _Empresa &
                                                "' And KOSU = '" & _Kosu &
                                                "' And KOBO = '" & _Kobo &
                                                "' And KOPR = '" & _kopr & "'"))

                    If _Select Then
                        If Not _Reg Then
                            _SqlQuery += "INSERT INTO TABBOPR (KOPR,EMPRESA,KOSU,KOBO) VALUES ('" & _kopr &
                                         "','" & _Empresa & "','" & _Kosu & "','" & _Kobo & "')" & vbCrLf & vbCrLf
                        End If
                    Else
                        _SqlQuery += "Delete TABBOPR Where EMPRESA ='" & _Empresa &
                                     "' And KOSU = '" & _Kosu &
                                     "' And KOBO = '" & _Kobo &
                                     "' And KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf
                    End If
                Next

                'INGRESO DE MENSAJE A LA TABLA DE MENSAJES POR PRODUCTOS

                '_SqlQuery += "INSERT INTO MAEPROBS (KOPR,EMPRESA,MENSAJE01,MENSAJE02,MENSAJE03) VALUES ('" & _Kopr &
                '             "','','" & _Mensaje01 & "','" & _Mensaje02 & "','" & _Mensaje03 & "')" & vbCrLf & vbCrLf

            End If

            If _Accion = Enum_Accion.Editar Then

                Dim _Row_Maepr = _Tbl_Maepr.Rows(0)



                For Each _Fila As DataRow In _Tbl_Maeprem.Rows

                Next

            End If


            Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)

        Catch ex As Exception
            'myTrans.Rollback()
            'SQL_ServerClass.Sb_Cerrar_Conexion(Cn)
            MsgBox(ex.Message)
            '_Producto_Creado = False
        End Try

    End Function

    Sub Sb_Cargar_Producto(_Codigo As String)

        _kopr = _Codigo

        Dim _Llena_Tabimpr = String.Empty

        If _Sql.Fx_Exite_Campo("TABIMPR", "NOAPLICEN") Then

            _Llena_Tabimpr =
"Update #Paso_Tabim Set Compras = (Case When ISNULL(NOAPLICEN,'') = '' Then 'Si' When NOAPLICEN like '%compras%' Then 'No' Else 'Si' End )
From TABIMPR WITH (NOLOCK) Where KOPR = '" & _kopr & "' And Codigo = KOIM
Update #Paso_Tabim Set Ventas = (Case When ISNULL(NOAPLICEN,'') = '' Then 'Si' When NOAPLICEN like '%ventas%' Then 'No' Else 'Si' End )
From TABIMPR WITH (NOLOCK) Where KOPR = '" & _kopr & "' And Codigo = KOIM
Update #Paso_Tabim Set Stock = (Case When ISNULL(NOAPLICEN,'') = '' Then 'Si' When NOAPLICEN like '%stock%' Then 'No' Else 'Si' End )
From TABIMPR WITH (NOLOCK) Where KOPR = '" & _kopr & "' And Codigo = KOIM
Update #Paso_Tabim Set Boleta = (Case When ISNULL(NOAPLICEN,'') = '' Then 'Si' When NOAPLICEN like '%BSV,BLV%' Then 'No' Else 'Si' End )
From TABIMPR WITH (NOLOCK) Where KOPR = '" & _kopr & "' And Codigo = KOIM"

        End If

        Consulta_sql = "If Not Exists(Select * From MAEFICHA WITH (NOLOCK) Where KOPR = '" & _kopr & "')" & vbCrLf &
                       "Begin" & vbCrLf &
                       "Insert Into MAEFICHA (KOPR,NOKOPR,FICHA) Select KOPR,NOKOPR,'' From MAEPR WITH (NOLOCK) Where KOPR = '" & _kopr & "'" & vbCrLf &
                       "End" & vbCrLf &
                       "If Not Exists(Select * From MAEFICHD WITH (NOLOCK) Where KOPR = '" & _kopr & "')" & vbCrLf &
                       "Begin" & vbCrLf &
                       "Insert Into MAEFICHD (KOPR,FICHA) Select KOPR,'' From MAEPR WITH (NOLOCK) Where KOPR = '" & _kopr & "'" & vbCrLf &
                       "End" & vbCrLf &
                       "-- 0" & vbCrLf &
                       "Select * From MAEPR WITH (NOLOCK) Where KOPR = '" & _kopr & "'" & vbCrLf &
                       "-- 1" & vbCrLf &
                       "Select * From MAEPREM WITH (NOLOCK) Where KOPR = '" & _kopr & "'" & vbCrLf &
                       "-- 2" & vbCrLf &
                       "Select KOPR,Isnull(FICHA,'') As FICHA From MAEFICHD WITH (NOLOCK) Where KOPR = '" & _kopr & "'" & vbCrLf &
                       "-- 3" & vbCrLf &
                       "Select * From MAEPROBS WITH (NOLOCK) Where KOPR = '" & _kopr & "'" & vbCrLf &
                       "-- 4" & vbCrLf &
                       "Select Cast((Select COUNT(*) From MAEPREM MP WITH (NOLOCK)" & vbCrLf &
                       "Where MP.EMPRESA = EMPRESA AND MP.KOPR = '" & _Codigo & "') As Bit) as 'Select',EMPRESA AS Codigo,RAZON as Descripcion" & vbCrLf &
                       "From CONFIGP WITH (NOLOCK)" & vbCrLf &
                       "-- 5" & vbCrLf &
                       "Select Cast((Select COUNT(*) From TABBOPR TB WITH (NOLOCK)" & vbCrLf &
                       "Where TB.EMPRESA = TTB.EMPRESA AND TB.KOSU = TTB.KOSU AND TB.KOBO = TTB.KOBO AND KOPR = '" & _Codigo & "') As Bit) as 'Select'," & vbCrLf &
                       "EMPRESA+'-'+KOSU+'-'+KOBO as Codigo,NOKOBO as Descripcion" & vbCrLf &
                       "From TABBO TTB WITH (NOLOCK)" & vbCrLf &
                       "-- 6" & vbCrLf &
                       "Select Cast((Select COUNT(*) From TABPRE TP WITH (NOLOCK)" & vbCrLf &
                       "Where TP.KOLT = TPP.KOLT And KOPR = '" & _Codigo & "' ) As Bit) AS 'Select', KOLT as Codigo,NOKOLT as Descripcion" & vbCrLf &
                       "From TABPP TPP WITH (NOLOCK)" & vbCrLf &
                       "-- 7" & vbCrLf &
                       "Select Cast((Select COUNT(*) From TABIMPR TIP WITH (NOLOCK)
Where TI.KOIM = TIP.KOIM And TIP.KOPR = '" & _kopr & "' ) As Bit) As 'Select',KOIM as Codigo,NOKOIM as Descripcion,
	  CAST('' As varchar(2)) As Compras,CAST('' As varchar(2)) As Ventas,CAST('' As varchar(2)) As Stock,CAST('' As varchar(2)) As Boleta,POIM,MEIM
Into #Paso_Tabim
From TABIM TI WITH (NOLOCK)

" & _Llena_Tabimpr & "

Select * From #Paso_Tabim

Drop Table #Paso_Tabim"


        '"Select Cast((Select COUNT(*) From TABIMPR TIP" & vbCrLf &
        '"Where TI.KOIM = TIP.KOIM And TIP.KOPR = '" & _Codigo & "' ) As Bit) As 'Select',KOIM as Codigo,NOKOIM as Descripcion" & vbCrLf &
        '"From TABIM TI" 

        _Ds_Producto = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Maepr = _Ds_Producto.Tables(0)
        _Tbl_Maeprem = _Ds_Producto.Tables(1)
        _Tbl_Maefichd = _Ds_Producto.Tables(2)
        '_Tbl_Tabimpr = _Ds_Producto.Tables(3)
        _Tbl_Maeprobs = _Ds_Producto.Tables(3)

        _Tbl_Empresas = _Ds_Producto.Tables(4)
        _Tbl_Bodegas = _Ds_Producto.Tables(5)
        _Tbl_Listas = _Ds_Producto.Tables(6)
        _Tbl_Impuestos = _Ds_Producto.Tables(7)

        Dim dc As DataColumn

        If Not _Sql.Fx_Exite_Campo("MAEPR", "NOKOPRAMP") Then
            dc = New DataColumn("NOKOPRAMP", Type.GetType("System.String"))
            _Tbl_Maepr.Columns.Add(dc)
        End If

        If Not _Sql.Fx_Exite_Campo("MAEPR", "CAMBIOSUJ") Then
            dc = New DataColumn("CAMBIOSUJ", Type.GetType("System.Boolean"))
            _Tbl_Maepr.Columns.Add(dc)
        End If

        If Not _Sql.Fx_Exite_Campo("MAEPROBS", "ALTO") Then
            dc = New DataColumn("ALTO", Type.GetType("System.Double"))
            _Tbl_Maeprobs.Columns.Add(dc)
        End If

        If Not _Sql.Fx_Exite_Campo("MAEPROBS", "LARGO") Then
            dc = New DataColumn("LARGO", Type.GetType("System.Double"))
            _Tbl_Maeprobs.Columns.Add(dc)
        End If

        If Not _Sql.Fx_Exite_Campo("MAEPROBS", "ANCHO") Then
            dc = New DataColumn("ANCHO", Type.GetType("System.Double"))
            _Tbl_Maeprobs.Columns.Add(dc)
        End If

        If Not CBool(_Tbl_Maepr.Rows.Count) Then

            _RowProducto = _Tbl_Maepr.NewRow()
            _RowProducto.Item("KOPR") = String.Empty
            _RowProducto.Item("TIPR") = "FPN"
            _RowProducto.Item("KOPRRA") = numero_(Val(_Sql.Fx_Trae_Dato("MAEPR", "MAX(KOPRRA)+1")), 6)
            _RowProducto.Item("POIVPR") = _Global_Row_Configp.Item("IVAPAIS")
            _RowProducto.Item("PODEIVPR") = False
            _RowProducto.Item("PRRG") = False
            _RowProducto.Item("TRATALOTE") = False
            _RowProducto.Item("EXENTO") = False
            _RowProducto.Item("PRDESRES") = False
            _RowProducto.Item("STOCKASEG") = False
            _RowProducto.Item("ESACTFI") = False
            _RowProducto.Item("CONUBIC") = False
            _RowProducto.Item("LOTECAJA") = False
            _RowProducto.Item("MOVETIQ") = False
            _RowProducto.Item("TRATVMEDIA") = False
            _RowProducto.Item("ANALIZABLE") = False
            _RowProducto.Item("LOMAFA") = 0

            If _Sql.Fx_Exite_Campo("MAEPR", "CONTROLADO") Then
                _RowProducto.Item("CONTROLADO") = False
            End If

            If _Sql.Fx_Exite_Campo("MAEPR", "CAMBIOSUJ") Then
                _RowProducto.Item("CAMBIOSUJ") = False
            End If

            _Tbl_Maepr.Rows.Add(_RowProducto)

        End If

        If CBool(_Tbl_Maefichd.Rows.Count) Then
            For Each _Fichas As DataRow In _Tbl_Maefichd.Rows
                Ficha += _Fichas.Item("FICHA")
            Next
        Else
            Ficha = String.Empty
        End If

        If Not CBool(_Tbl_Maeprobs.Rows.Count) Then

            Dim _Row As DataRow = _Tbl_Maeprobs.NewRow()
            _Row.Item("KOPR") = _kopr
            _Row.Item("EMPRESA") = String.Empty
            _Row.Item("MENSAJE01") = String.Empty
            _Row.Item("MENSAJE02") = String.Empty
            _Row.Item("MENSAJE03") = String.Empty

            _Tbl_Maeprobs.Rows.Add(_Row)

        End If

        _RowProducto = _Tbl_Maepr.Rows(0)

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Fx_Llenar_Zw_Producto(_Codigo)

    End Sub

    Function Fx_Crear_Nuevo_Producto()

        If (_RowProducto Is Nothing) Then
            Return False
        End If

        Try

            Dim _SqlQuery = String.Empty

            _SqlQuery += My.Resources.Recursos_Producto.SqlQuery_Crear_Producto & vbCrLf & vbCrLf
            Sb_Cargar_Variables(_SqlQuery)

            'INGRESO DE PRODUCTO EN TABLA DE FICHAS DEL PRODUCTO

            'Dim _Ficha As String = Replace(NuloPorNro(_Tbl_Maefichd.Rows(0).Item("FICHA"), ""), "'", "''")
            '_SqlQuery += "INSERT INTO MAEFICHA (KOPR,NOKOPR,FICHA) VALUES ('" & _kopr &
            '             "','" & _nokopr & "','" & _Ficha & "')" & vbCrLf & vbCrLf

            _SqlQuery += "DELETE MAEFICHD Where KOPR='" & _kopr & "'" & vbCrLf &
                         "INSERT INTO MAEFICHD (KOPR,FICHA) Values ('" & _kopr & "','" & _Ficha & "')" & vbCrLf

            'INGRESO DE PRODUCTOS POR EMPRESA

            For Each _Fila As DataRow In _Tbl_Empresas.Rows

                Dim _Empresa = _Fila.Item("Codigo")

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Cod As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                If _Select Then
                    _SqlQuery += "INSERT INTO MAEPREM ( EMPRESA,KOPR,LISCOSTO,PPUL01,PPUL02,PM) VALUES " &
                                         "( '" & _Empresa &
                                         "','" & _kopr &
                                         "',''," & De_Num_a_Tx_01(_ppul01, False, 5) &
                                         "," & De_Num_a_Tx_01(_ppul02, False, 5) &
                                         "," & De_Num_a_Tx_01(_pm, False, 5) & ")" & vbCrLf & vbCrLf
                End If

            Next

            'INGRESO DE IMPUESTOS EN TABLA DE IMPUESTOS POR PRODUCTO

            For Each _Fila As DataRow In _Tbl_Impuestos.Rows
                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Cod As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")
                If _Select Then
                    _SqlQuery += "INSERT INTO TABIMPR (KOPR,KOIM) VALUES ( '" & _kopr &
                                     "','" & _Cod & "')" & vbCrLf & vbCrLf
                End If
            Next

            'INGRESO DE PRODUCTOS A LA LISTA DE PRECIOS

            For Each _Fila As DataRow In _Tbl_Listas.Rows

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Kolt As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABPRE",
                                                "KOLT = '" & _Kolt & "' And KOPR = '" & _kopr & "'"))

                If _Select Then
                    If Not _Reg Then

                        Dim _Ecuacion As String = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF01UD", "KOLT = '" & _Kolt & "'")
                        Dim _Ecuacionu2 As String = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF02UD", "KOLT = '" & _Kolt & "'")

                        _SqlQuery += "INSERT INTO TABPRE (KOPR,KOLT,KOPRRA,KOPRTE,RLUD,ECUACION,ECUACIONU2) VALUES ('" & _kopr &
                                        "','" & _Kolt & "','" & _koprra &
                                        "','" & _koprte & "'," & _rlud &
                                        ",'" & _Ecuacion & "','" & _Ecuacionu2 & "')" & vbCrLf & vbCrLf
                    End If
                Else
                    _SqlQuery += "Delete TABPRE Where KOLT = '" & _Kolt & "' And KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf
                End If
            Next


            'INGRESO DE PRODUCTOS A LA BODEGA

            For Each _Fila As DataRow In _Tbl_Bodegas.Rows

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Cod As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                Dim EmSucBod = Split(_Cod, "-")

                Dim _Em_Suc_Bod = Split(_Cod, "-")

                Dim _Empresa = _Em_Suc_Bod(0)
                Dim _Kosu = _Em_Suc_Bod(1)
                Dim _Kobo = _Em_Suc_Bod(2)

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABBOPR",
                                                "EMPRESA ='" & _Empresa &
                                                "' And KOSU = '" & _Kosu &
                                                "' And KOBO = '" & _Kobo &
                                                "' And KOPR = '" & _kopr & "'"))

                If _Select Then
                    If Not _Reg Then
                        _SqlQuery += "INSERT INTO TABBOPR (KOPR,EMPRESA,KOSU,KOBO) VALUES ('" & _kopr &
                                         "','" & _Empresa & "','" & _Kosu & "','" & _Kobo & "')" & vbCrLf & vbCrLf
                    End If
                Else
                    _SqlQuery += "Delete TABBOPR Where EMPRESA ='" & _Empresa &
                                     "' And KOSU = '" & _Kosu &
                                     "' And KOBO = '" & _Kobo &
                                     "' And KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf
                End If

            Next

            'INGRESO DE MENSAJE A LA TABLA DE MENSAJES POR PRODUCTOS

            Dim _Mensaje01 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE01"), "'", "''")
            Dim _Mensaje02 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE02"), "'", "''")
            Dim _Mensaje03 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE03"), "'", "''")

            _SqlQuery += "INSERT INTO MAEPROBS (KOPR,EMPRESA,MENSAJE01,MENSAJE02,MENSAJE03) VALUES ('" & _kopr &
                         "','','" & _Mensaje01 & "','" & _Mensaje02 & "','" & _Mensaje03 & "')" & vbCrLf & vbCrLf

            With Zw_Producto

                _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Productos (Codigo,Descripcion,ExluyeTipoVenta) Values " &
                             "('" & .Codigo & "','" & .Descripcion & "','" & Convert.ToInt32(.ExluyeTipoVenta) & "')"

            End With

            Dim _Ippide As String = getIp()
            Dim _Horagrab As String = Hora_Grab_fx(False)

            Dim _SqlTabactus As String

            _SqlTabactus = "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ") ','Creación de Productos : " & _kopr & "')"

            _SqlQuery += vbCrLf & vbCrLf & _SqlTabactus

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)

            Return _Sql.Pro_Error

        Catch ex As Exception
            'myTrans.Rollback()
            'SQL_ServerClass.Sb_Cerrar_Conexion(Cn)
            Return ex.Message
            '_Producto_Creado = False
        End Try

    End Function

    Function Fx_Editar_Producto()

        Try

            Dim _SqlQuery = String.Empty

            Dim _Ficha As String = Replace(NuloPorNro(_Tbl_Maefichd.Rows(0).Item("FICHA"), ""), "'", "''")

            _SqlQuery = "Delete TABIMPR Where KOPR = '" & _kopr & "'" & vbCrLf &
                        "Delete MAEPROBS Where KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf

            '_SqlQuery += My.Resources.Recursos_Producto.SqlQuery_Crear_Producto & vbCrLf & vbCrLf
            _SqlQuery += My.Resources.Recursos_Producto.SqlQuery_Editar_Producto & vbCrLf & vbCrLf
            Sb_Cargar_Variables(_SqlQuery)

            'INGRESO DE PRODUCTO EN TABLA DE FICHAS DEL PRODUCTO

            _SqlQuery += "Delete FROM MAEFICHD Where KOPR='" & _kopr & "'" & vbCrLf

            Dim _ListaFichas As New List(Of String)

            Dim _Div = Math.Ceiling(Ficha.Length / 80)
            Dim _Ini = 1
            For i = 1 To _Div
                _ListaFichas.Add(Mid(Ficha.ToString, _Ini, 80))
                _Ini += 80
            Next

            For Each _Fichas As String In _ListaFichas
                _SqlQuery += "Insert Into MAEFICHD (KOPR,FICHA) Values ('" & _kopr & "','" & _Fichas & "')" & vbCrLf
            Next


            'INGRESO DE PRODUCTOS POR EMPRESA

            For Each _Fila As DataRow In _Tbl_Empresas.Rows

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Cod As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                If _Select Then

                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEPREM", "EMPRESA = '" & _Cod & "' And KOPR = '" & _kopr & "'"))

                    If Not _Reg Then
                        _SqlQuery += "Insert Into MAEPREM ( EMPRESA,KOPR,LISCOSTO,PPUL01,PPUL02,PM) Values " &
                                     "( '" & _Cod &
                                     "','" & _kopr &
                                     "',''," & De_Num_a_Tx_01(_ppul01, False, 5) &
                                     "," & De_Num_a_Tx_01(_ppul02, False, 5) &
                                     "," & De_Num_a_Tx_01(_pm, False, 5) & ")" & vbCrLf & vbCrLf
                    End If
                Else
                    _SqlQuery += "Delete MAEPREM Where KOPR = '" & _kopr & "' AND EMPRESA = '" & _Cod & "'" & vbCrLf & vbCrLf
                End If

            Next

            'INGRESO DE IMPUESTOS EN TABLA DE IMPUESTOS POR PRODUCTO

            For Each _Fila As DataRow In _Tbl_Impuestos.Rows

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Cod As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                If _Select Then

                    If _Sql.Fx_Exite_Campo("TABIMPR", "NOAPLICEN") Then

                        Dim _ListNoaplicen As New List(Of String)

                        Dim _Compras = _Fila.Item("Compras")
                        Dim _Ventas = _Fila.Item("Ventas")
                        Dim _Stock = _Fila.Item("Stock")
                        Dim _Boleta = _Fila.Item("Boleta")

                        If _Compras = "No" Then _ListNoaplicen.Add("compras")
                        If _Ventas = "No" Then _ListNoaplicen.Add("ventas")
                        If _Stock = "No" Then _ListNoaplicen.Add("stock")
                        If _Boleta = "No" Then _ListNoaplicen.Add("BSV,BLV")

                        Dim _Noaplicen As String = String.Empty

                        For Each _Valor As String In _ListNoaplicen
                            If String.IsNullOrEmpty(_Noaplicen) Then
                                _Noaplicen = _Valor
                            Else
                                _Noaplicen += "," & _Valor
                            End If
                        Next

                        _SqlQuery += "Insert Into TABIMPR (KOPR,KOIM,NOAPLICEN) Values ( '" & _kopr & "','" & _Cod & "','" & _Noaplicen & "')" & vbCrLf & vbCrLf
                    Else
                        _SqlQuery += "Insert Into TABIMPR (KOPR,KOIM) Values ( '" & _kopr & "','" & _Cod & "')" & vbCrLf & vbCrLf
                    End If

                End If

            Next

            'INGRESO DE PRODUCTOS A LA LISTA DE PRECIOS


            For Each _Fila As DataRow In _Tbl_Listas.Rows

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Kolt As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                If _Select Then

                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABPRE",
                                            "KOLT = '" & _Kolt & "' And KOPR = '" & _kopr & "'"))

                    If Not _Reg Then

                        Dim _Ecuacion As String = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF01UD", "KOLT = '" & _Kolt & "'")
                        Dim _Ecuacionu2 As String = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF02UD", "KOLT = '" & _Kolt & "'")

                        _SqlQuery += "Insert Into TABPRE (KOPR,KOLT,KOPRRA,KOPRTE,RLUD,ECUACION,ECUACIONU2) Values ('" & _kopr &
                                        "','" & _Kolt & "','" & _koprra &
                                        "','" & _koprte & "'," & De_Num_a_Tx_01(_rlud, False, 5) &
                                        ",'" & _Ecuacion & "','" & _Ecuacionu2 & "')" & vbCrLf & vbCrLf
                    End If

                Else
                    _SqlQuery += "Delete TABPRE Where KOLT = '" & _Kolt & "' And KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf
                End If

            Next

            _SqlQuery += "Update TABPRE Set KOPRRA = '" & _koprra & "',KOPRTE = '" & _koprte & "' Where KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf


            'INGRESO DE PRODUCTOS A LA BODEGA

            For Each _Fila As DataRow In _Tbl_Bodegas.Rows

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Cod As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                Dim EmSucBod = Split(_Cod, "-")

                Dim _Em_Suc_Bod = Split(_Cod, "-")

                Dim _Empresa = _Em_Suc_Bod(0)
                Dim _Kosu = _Em_Suc_Bod(1)
                Dim _Kobo = _Em_Suc_Bod(2)

                If _Select Then

                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABBOPR",
                                                                          "EMPRESA ='" & _Empresa &
                                                                          "' And KOSU = '" & _Kosu &
                                                                          "' And KOBO = '" & _Kobo &
                                                                          "' And KOPR = '" & _kopr & "'"))

                    If Not _Reg Then
                        _SqlQuery += "Insert Into TABBOPR (KOPR,EMPRESA,KOSU,KOBO) Values ('" & _kopr &
                                         "','" & _Empresa & "','" & _Kosu & "','" & _Kobo & "')" & vbCrLf & vbCrLf
                    End If

                Else

                    _SqlQuery += "Delete TABBOPR Where EMPRESA ='" & _Empresa &
                                     "' And KOSU = '" & _Kosu &
                                     "' And KOBO = '" & _Kobo &
                                     "' And KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf

                End If
            Next

            'INGRESO DE MENSAJE A LA TABLA DE MENSAJES POR PRODUCTOS

            Dim _Mensaje01 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE01"), "'", "''")
            Dim _Mensaje02 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE02"), "'", "''")
            Dim _Mensaje03 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE03"), "'", "''")

            _SqlQuery += "Insert Into MAEPROBS (KOPR,EMPRESA,MENSAJE01,MENSAJE02,MENSAJE03) VALUES ('" & _kopr &
                         "','','" & _Mensaje01 & "','" & _Mensaje02 & "','" & _Mensaje03 & "')" & vbCrLf & vbCrLf

            If _Sql.Fx_Exite_Campo("MAEPROBS", "ALTO") Then
                Dim _Alto = De_Num_a_Tx_01(_Tbl_Maeprobs.Rows(0).Item("ALTO"), False, 5)
                _SqlQuery += "Update MAEPROBS Set ALTO = " & _Alto & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPROBS", "LARGO") Then
                Dim _Largo = De_Num_a_Tx_01(_Tbl_Maeprobs.Rows(0).Item("LARGO"), False, 5)
                _SqlQuery += "Update MAEPROBS Set LARGO = " & _Largo & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPROBS", "ANCHO") Then
                Dim _Ancho = De_Num_a_Tx_01(_Tbl_Maeprobs.Rows(0).Item("ANCHO"), False, 5)
                _SqlQuery += "Update MAEPROBS Set ANCHO = " & _Ancho & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPR", "CAMBIOSUJ") Then
                _SqlQuery += "Update MAEPR Set CAMBIOSUJ = " & CInt(_RowProducto.Item("CAMBIOSUJ")) & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPR", "NOKOPRAMP") Then
                _SqlQuery += "Update MAEPR Set NOKOPRAMP = '" & _RowProducto.Item("NOKOPRAMP").ToString.Trim & "' Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            With Zw_Producto

                _SqlQuery += vbCrLf & "Update " & _Global_BaseBk & "Zw_Productos Set " & vbCrLf &
                             "Descripcion = '" & .Descripcion & "'" &
                             ",ExluyeTipoVenta = " & Convert.ToInt32(.ExluyeTipoVenta) & vbCrLf &
                             ",RtuXWms = " & Convert.ToInt32(.RtuXWms) & vbCrLf &
                             "Where Codigo = '" & .Codigo & "'"

            End With

            'Insertar datos en TABACTUS

            Dim _Ippide As String = getIp()
            Dim _Horagrab As String = Hora_Grab_fx(False)

            Dim _SqlTabactus As String

            _SqlTabactus = "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ") ','modificacion de producto : " & _kopr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOPR :" & _kopr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NOKOPR :" & _nokopr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOPRRA :" & _koprra & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOPRTE :" & _koprte & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NOKOPRRA :" & _nokoprra & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','POIVPR :" & _poivpr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','EXENTO :" & _exento & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','RGPR :" & _rgpr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','UD01PR :" & _ud01pr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','UD02PR :" & _ud02pr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','RLUD :" & _rlud & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NMARCA :" & _nmarca & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','TRATALOTE :" & _tratalote & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NUIMPR :" & _nuimpr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','ATPR :" & _atpr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','LISCOSTO :" & _liscosto & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','DIVISIBLE :" & _divisible & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','DIVISIBLE2:" & _divisible2 & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','STOCKASEG :" & _stockaseg & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOFUPR :" & _kofupr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','ZONAPR :" & _zonapr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','BLOQUEAPR :" & _bloqueapr & "')" & vbCrLf

            _SqlQuery += vbCrLf & vbCrLf & _SqlTabactus

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)

            Return _Sql.Pro_Error

        Catch ex As Exception
            'myTrans.Rollback()
            'SQL_ServerClass.Sb_Cerrar_Conexion(Cn)
            'MsgBox(ex.Message)
            '_Producto_Creado = False
            Return ex.Message
        End Try

    End Function

    Function Fx_Editar_Producto_Base_Externa(_Global_BaseBk As String,
                                             _EditarRtu As Boolean) As String

        Dim _SqlQuery = String.Empty

        Try

            Dim _Ficha As String = Replace(NuloPorNro(_Tbl_Maefichd.Rows(0).Item("FICHA"), ""), "'", "''")

            _SqlQuery = "Delete TABIMPR Where KOPR = '" & _kopr & "'" & vbCrLf &
                        "Delete MAEPROBS Where KOPR = '" & _kopr & "'" & vbCrLf & vbCrLf

            _SqlQuery += My.Resources.Recursos_Producto.SqlQuery_Editar_Producto & vbCrLf & vbCrLf
            Sb_Cargar_Variables(_SqlQuery)

            If Not _EditarRtu Then
                _SqlQuery = Replace(_SqlQuery, "UD01PR = @UD01PR,", "--UD01PR = @UD01PR,")
                _SqlQuery = Replace(_SqlQuery, "UD02PR = @UD02PR,", "--UD01PR = @UD01PR,")
                _SqlQuery = Replace(_SqlQuery, "RLUD = @RLUD,", "--RLUD = @RLUD,")
                _SqlQuery = Replace(_SqlQuery, "NMARCA = @NMARCA,", "--NMARCA = @NMARCA,")
            End If

            'INGRESO DE PRODUCTO EN TABLA DE FICHAS DEL PRODUCTO

            _SqlQuery += "Delete FROM MAEFICHD Where KOPR='" & _kopr & "'" & vbCrLf

            Dim _ListaFichas As New List(Of String)

            Dim _Div = Math.Ceiling(Ficha.Length / 80)
            Dim _Ini = 1
            For i = 1 To _Div
                _ListaFichas.Add(Mid(Ficha.ToString, _Ini, 80))
                _Ini += 80
            Next

            For Each _Fichas As String In _ListaFichas
                _SqlQuery += "Insert Into MAEFICHD (KOPR,FICHA) Values ('" & _kopr & "','" & _Fichas & "')" & vbCrLf
            Next

            'INGRESO DE IMPUESTOS EN TABLA DE IMPUESTOS POR PRODUCTO

            For Each _Fila As DataRow In _Tbl_Impuestos.Rows

                Dim _Select As Boolean = _Fila.Item("Select")
                Dim _Cod As String = _Fila.Item("Codigo")
                Dim _Des As String = _Fila.Item("Descripcion")

                If _Select Then

                    If _Sql.Fx_Exite_Campo("TABIMPR", "NOAPLICEN") Then

                        Dim _ListNoaplicen As New List(Of String)

                        Dim _Compras = _Fila.Item("Compras")
                        Dim _Ventas = _Fila.Item("Ventas")
                        Dim _Stock = _Fila.Item("Stock")
                        Dim _Boleta = _Fila.Item("Boleta")

                        If _Compras = "No" Then _ListNoaplicen.Add("compras")
                        If _Ventas = "No" Then _ListNoaplicen.Add("ventas")
                        If _Stock = "No" Then _ListNoaplicen.Add("stock")
                        If _Boleta = "No" Then _ListNoaplicen.Add("BSV,BLV")

                        Dim _Noaplicen As String = String.Empty

                        For Each _Valor As String In _ListNoaplicen
                            If String.IsNullOrEmpty(_Noaplicen) Then
                                _Noaplicen = _Valor
                            Else
                                _Noaplicen += "," & _Valor
                            End If
                        Next

                        _SqlQuery += "Insert Into TABIMPR (KOPR,KOIM,NOAPLICEN) Values ( '" & _kopr & "','" & _Cod & "','" & _Noaplicen & "')" & vbCrLf & vbCrLf
                    Else
                        _SqlQuery += "Insert Into TABIMPR (KOPR,KOIM) Values ( '" & _kopr & "','" & _Cod & "')" & vbCrLf & vbCrLf
                    End If

                End If

            Next

            'INGRESO DE MENSAJE A LA TABLA DE MENSAJES POR PRODUCTOS

            Dim _Mensaje01 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE01"), "'", "''")
            Dim _Mensaje02 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE02"), "'", "''")
            Dim _Mensaje03 = Replace(_Tbl_Maeprobs.Rows(0).Item("MENSAJE03"), "'", "''")

            _SqlQuery += "Insert Into MAEPROBS (KOPR,EMPRESA,MENSAJE01,MENSAJE02,MENSAJE03) VALUES ('" & _kopr &
                         "','','" & _Mensaje01 & "','" & _Mensaje02 & "','" & _Mensaje03 & "')" & vbCrLf & vbCrLf

            If _Sql.Fx_Exite_Campo("MAEPROBS", "ALTO") Then
                Dim _Alto = De_Num_a_Tx_01(_Tbl_Maeprobs.Rows(0).Item("ALTO"), False, 5)
                _SqlQuery += "Update MAEPROBS Set ALTO = " & _Alto & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPROBS", "LARGO") Then
                Dim _Largo = De_Num_a_Tx_01(_Tbl_Maeprobs.Rows(0).Item("LARGO"), False, 5)
                _SqlQuery += "Update MAEPROBS Set LARGO = " & _Largo & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPROBS", "ANCHO") Then
                Dim _Ancho = De_Num_a_Tx_01(_Tbl_Maeprobs.Rows(0).Item("ANCHO"), False, 5)
                _SqlQuery += "Update MAEPROBS Set ANCHO = " & _Ancho & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPR", "CAMBIOSUJ") Then
                _SqlQuery += "Update MAEPR Set CAMBIOSUJ = " & CInt(_RowProducto.Item("CAMBIOSUJ")) & " Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            If _Sql.Fx_Exite_Campo("MAEPR", "NOKOPRAMP") Then
                _SqlQuery += "Update MAEPR Set NOKOPRAMP = '" & _RowProducto.Item("NOKOPRAMP").ToString.Trim & "' Where KOPR = '" & _kopr & "'" & vbCrLf
            End If

            _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set DescripcionBusqueda = '" & _kopr.Trim & " " & _nokopr & "'" & vbCrLf &
                         "Where Codigo = '" & _kopr & "' And Producto = 1" & vbCrLf

            _alto = Pro_Maeprobs.Rows(0).Item("ALTO")
            _largo = Pro_Maeprobs.Rows(0).Item("LARGO")
            _ancho = Pro_Maeprobs.Rows(0).Item("ANCHO")

            _SqlQuery += "Delete " & _Global_BaseBk & "Zw_Prod_Dimensiones Where Codigo = '" & _kopr & "'" & vbCrLf &
                         "Insert Into " & _Global_BaseBk & "Zw_Prod_Dimensiones (Codigo,Peso,Alto,Largo,Ancho) Values " &
                           "('" & _kopr & "'," &
                           _pesoubic & "," &
                           De_Num_a_Tx_01(_alto, False, 5) & "," &
                           De_Num_a_Tx_01(_largo, False, 5) & "," &
                           De_Num_a_Tx_01(_ancho, False, 5) & ")" & vbCrLf

            _SqlQuery += "Update MAEPR Set KOPRTE = '" & _koprte & "' Where KOPR = '" & _kopr & "'" & vbCrLf

            _SqlQuery += "Update TABPRE Set KOPRRA = Mp.KOPRRA,KOPRTE = Mp.KOPRTE " & vbCrLf &
                         "From MAEPR Mp" & vbCrLf &
                         "Inner Join TABPRE Tp On Mp.KOPR = Tp.KOPR" & vbCrLf &
                         "Where Mp.KOPR = '" & _kopr & "'" & vbCrLf

            'Insertar datos en TABACTUS

            Dim _Ippide As String = getIp()
            Dim _Horagrab As String = Hora_Grab_fx(False)

            Dim _SqlTabactus As String
            Dim _SqlEidRtu As String

            If _EditarRtu Then
                _SqlEidRtu = "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','UD01PR :" & _ud01pr & "')" & vbCrLf &
                             "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','UD02PR :" & _ud02pr & "')" & vbCrLf &
                             "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','RLUD :" & _rlud & "')" & vbCrLf &
                             "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NMARCA :" & _nmarca & "')" & vbCrLf
            End If

            _SqlTabactus = "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ") ','modificacion de producto : " & _kopr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOPR :" & _kopr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NOKOPR :" & _nokopr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOPRRA :" & _koprra & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOPRTE :" & _koprte & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NOKOPRRA :" & _nokoprra & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','POIVPR :" & _poivpr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','EXENTO :" & _exento & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','RGPR :" & _rgpr & "')" & vbCrLf &
                           _SqlEidRtu &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','TRATALOTE :" & _tratalote & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','NUIMPR :" & _nuimpr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','ATPR :" & _atpr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','LISCOSTO :" & _liscosto & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','DIVISIBLE :" & _divisible & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','DIVISIBLE2:" & _divisible2 & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','STOCKASEG :" & _stockaseg & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','KOFUPR :" & _kofupr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','ZONAPR :" & _zonapr & "')" & vbCrLf &
                           "INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '" & _Ippide & "','','" & FUNCIONARIO & "'," & _Horagrab & ",'(" & _Version_BakApp & ")','BLOQUEAPR :" & _bloqueapr & "')" & vbCrLf

            _SqlQuery += vbCrLf & vbCrLf & _SqlTabactus

        Catch ex As Exception
            _SqlQuery = String.Empty
        End Try

        Return _SqlQuery

    End Function

    Sub Sb_Cargar_Variables(ByRef _SqlQuery As String)

        _tipr = NuloPorNro(_RowProducto.Item("tipr"), "")
        _kopr = NuloPorNro(_RowProducto.Item("kopr"), "")
        _nokopr = NuloPorNro(_RowProducto.Item("nokopr"), "")
        _koprra = NuloPorNro(_RowProducto.Item("koprra"), "")
        _nokoprra = NuloPorNro(_RowProducto.Item("nokoprra"), "")
        _koprte = NuloPorNro(_RowProducto.Item("koprte"), "")
        _koge = NuloPorNro(_RowProducto.Item("koge"), "")
        _nmarca = NuloPorNro(_RowProducto.Item("nmarca"), "")
        _ud01pr = NuloPorNro(_RowProducto.Item("ud01pr"), "")
        _ud02pr = NuloPorNro(_RowProducto.Item("ud02pr"), "")
        _rlud = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("rlud"), 0), False, 5)
        _poivpr = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("poivpr"), 0), False, 5)
        _nuimpr = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("nuimpr"), 0), False, 5)
        _rgpr = NuloPorNro(_RowProducto.Item("rgpr"), "")
        _stmipr = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stmipr"), 0), False, 5)
        _stmapr = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stmapr"), 0), False, 5)
        _mrpr = NuloPorNro(_RowProducto.Item("mrpr"), "")
        _atpr = NuloPorNro(_RowProducto.Item("atpr"), "")
        _rupr = NuloPorNro(_RowProducto.Item("rupr"), "")
        _stfi1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stfi1"), 0), False, 5)
        _stdv1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stdv1"), 0), False, 5)
        _stocnv1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stocnv1"), 0), False, 5)
        _stfi2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stfi2"), 0), False, 5)
        _stdv2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stdv2"), 0), False, 5)
        _stocnv2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stocnv2"), 0), False, 5)
        _ppul01 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("ppul01"), 0), False, 5)
        _ppul02 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("ppul02"), 0), False, 5)
        _moul = NuloPorNro(_RowProducto.Item("moul"), "")
        _timoul = NuloPorNro(_RowProducto.Item("timoul"), "")
        _taul = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("taul"), 0), False, 5)
        _feul = NuloPorNro(_RowProducto.Item("FEUL"), "Null") : If _feul <> "Null" Then _feul = Format(_RowProducto.Item("FEUL"), "yyyyMMdd")
        _pm = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("pm"), 0), False, 5)
        _fepm = NuloPorNro(_RowProducto.Item("FEPM"), "Null") : If _fepm <> "Null" Then _fepm = Format(_RowProducto.Item("FEPM"), "yyyyMMdd")
        _fmpr = NuloPorNro(_RowProducto.Item("fmpr"), "")
        _pfpr = NuloPorNro(_RowProducto.Item("pfpr"), "")
        _hfpr = NuloPorNro(_RowProducto.Item("hfpr"), "")
        _vali = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("vali"), 0), False, 5)
        _fevali = NuloPorNro(_RowProducto.Item("FEVALI"), "Null") : If _fevali <> "Null" Then _fevali = Format(_RowProducto.Item("FEVALI"), "yyyyMMdd")
        _ttrepr = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("ttrepr"), 0), False, 5)
        _prrg = NuloPorNro(_RowProducto.Item("prrg"), 0)
        _niprrg = NuloPorNro(_RowProducto.Item("niprrg"), "")
        _nfprrg = NuloPorNro(_RowProducto.Item("nfprrg"), "")
        _pmin = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("pmin"), 0), False, 5)
        _camico = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("camico"), 0), False, 5)
        _camifa = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("camifa"), 0), False, 5)
        _lomifa = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("lomifa"), 0), False, 5)
        _plano = NuloPorNro(_RowProducto.Item("plano"), "")
        _stdv1c = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stdv1c"), 0), False, 5)
        _stocnv1c = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stocnv1c"), 0), False, 5)
        _stdv2c = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stdv2c"), 0), False, 5)
        _stocnv2c = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stocnv2c"), 0), False, 5)
        _metrco = NuloPorNro(_RowProducto.Item("metrco"), "")
        _despnofac1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("despnofac1"), 0), False, 5)
        _despnofac2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("despnofac2"), 0), False, 5)
        _recenofac1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("recenofac1"), 0), False, 5)
        _recenofac2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("recenofac2"), 0), False, 5)
        _tratalote = NuloPorNro(_RowProducto.Item("tratalote"), 0)
        _divisible = NuloPorNro(_RowProducto.Item("divisible"), "")
        _mudefa = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("mudefa"), 0), False, 5)
        _exento = NuloPorNro(_RowProducto.Item("exento"), 0)
        _komode = NuloPorNro(_RowProducto.Item("komode"), "")
        _prdesres = NuloPorNro(_RowProducto.Item("prdesres"), 0)
        _liscosto = NuloPorNro(_RowProducto.Item("liscosto"), "")
        _stockaseg = NuloPorNro(_RowProducto.Item("stockaseg"), 0)
        _esactfi = NuloPorNro(_RowProducto.Item("esactfi"), 0)
        _clalibpr = NuloPorNro(_RowProducto.Item("clalibpr"), "")
        _kofupr = NuloPorNro(_RowProducto.Item("kofupr"), "")
        _koprdim = NuloPorNro(_RowProducto.Item("koprdim"), "")
        _nodim1 = NuloPorNro(_RowProducto.Item("nodim1"), "")
        _nodim2 = NuloPorNro(_RowProducto.Item("nodim2"), "")
        _nodim3 = NuloPorNro(_RowProducto.Item("nodim3"), "")
        _bloqueapr = NuloPorNro(_RowProducto.Item("bloqueapr"), "")
        _zonapr = NuloPorNro(_RowProducto.Item("zonapr"), "")
        _conubic = NuloPorNro(_RowProducto.Item("conubic"), 0)
        _ltsubic = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("ltsubic"), 0), False, 5)
        _pesoubic = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("pesoubic"), 0), False, 5)
        _funclote = NuloPorNro(_RowProducto.Item("funclote"), "")
        _lomafa = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("lomafa"), 0), False, 5)
        _colegpr = NuloPorNro(_RowProducto.Item("colegpr"), "")
        _morgpr = NuloPorNro(_RowProducto.Item("morgpr"), "")
        _fecrpr = NuloPorNro(_RowProducto.Item("FECRPR"), "Null") : If _fecrpr <> "Null" Then _fecrpr = Format(_RowProducto.Item("FECRPR"), "yyyyMMdd")
        _femopr = NuloPorNro(_RowProducto.Item("FEMOPR"), "Null") : If _femopr <> "Null" Then _femopr = Format(_RowProducto.Item("FEMOPR"), "yyyyMMdd")
        _lotecaja = NuloPorNro(_RowProducto.Item("lotecaja"), 0)
        _sttr1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("sttr1"), 0), False, 5)
        _sttr2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("sttr2"), 0), False, 5)
        _podeivpr = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("podeivpr"), 0), False, 5)
        _divisible2 = NuloPorNro(_RowProducto.Item("divisible2"), "")
        _movetiq = NuloPorNro(_RowProducto.Item("movetiq"), 0)
        _repuesto = NuloPorNro(_RowProducto.Item("repuesto"), "")
        _vidamedia = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("vidamedia"), 0), False, 5)
        _tratvmedia = NuloPorNro(_RowProducto.Item("tratvmedia"), 0)
        _presalcli1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("presalcli1"), 0), False, 5)
        _presalcli2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("presalcli2"), 0), False, 5)
        _presdepro1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("presdepro1"), 0), False, 5)
        _presdepro2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("presdepro2"), 0), False, 5)
        _consalcli1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("consalcli1"), 0), False, 5)
        _consalcli2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("consalcli2"), 0), False, 5)
        _consdepro1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("consdepro1"), 0), False, 5)
        _consdepro2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("consdepro2"), 0), False, 5)
        _devengncv1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devengncv1"), 0), False, 5)
        _devengncv2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devengncv2"), 0), False, 5)
        _devengncc1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devengncc1"), 0), False, 5)
        _devengncc2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devengncc2"), 0), False, 5)
        _devsinncv1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devsinncv1"), 0), False, 5)
        _devsinncv2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devsinncv2"), 0), False, 5)
        _devsinncc1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devsinncc1"), 0), False, 5)
        _devsinncc2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("devsinncc2"), 0), False, 5)
        _stenfab1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stenfab1"), 0), False, 5)
        _stenfab2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("stenfab2"), 0), False, 5)
        _streqfab1 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("streqfab1"), 0), False, 5)
        _streqfab2 = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("streqfab2"), 0), False, 5)
        _pmme = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("pmme"), 0), False, 5)
        _fepmme = NuloPorNro(_RowProducto.Item("FEPMME"), "Null") : If _fepmme <> "Null" Then _fepmme = Format(_RowProducto.Item("FEPMME"), "yyyyMMdd")
        _valunflekm = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("valunflekm"), 0), False, 5)
        _analizable = NuloPorNro(_RowProducto.Item("analizable"), 0)
        _tolelote = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("tolelote"), 0), False, 5)
        _pmifrs = De_Num_a_Tx_01(NuloPorNro(_RowProducto.Item("pmifrs"), 0), False, 5)
        _fepmifrs = NuloPorNro(_RowProducto.Item("FEPMIFRS"), "Null") : If _fepmifrs <> "Null" Then _fepmifrs = Format(_RowProducto.Item("FEPMIFRS"), "yyyyMMdd")


        _SqlQuery = Replace(_SqlQuery, "#tipr#", _tipr)
        _SqlQuery = Replace(_SqlQuery, "#kopr#", _kopr)
        _SqlQuery = Replace(_SqlQuery, "#nokopr#", _nokopr)
        _SqlQuery = Replace(_SqlQuery, "#koprra#", _koprra)
        _SqlQuery = Replace(_SqlQuery, "#nokoprra#", _nokoprra)
        _SqlQuery = Replace(_SqlQuery, "#koprte#", _koprte)
        _SqlQuery = Replace(_SqlQuery, "#koge#", _koge)
        _SqlQuery = Replace(_SqlQuery, "#nmarca#", _nmarca)
        _SqlQuery = Replace(_SqlQuery, "#ud01pr#", _ud01pr)
        _SqlQuery = Replace(_SqlQuery, "#ud02pr#", _ud02pr)
        _SqlQuery = Replace(_SqlQuery, "#rlud#", _rlud)
        _SqlQuery = Replace(_SqlQuery, "#poivpr#", _poivpr)
        _SqlQuery = Replace(_SqlQuery, "#nuimpr#", _nuimpr)
        _SqlQuery = Replace(_SqlQuery, "#rgpr#", _rgpr)
        _SqlQuery = Replace(_SqlQuery, "#stmipr#", _stmipr)
        _SqlQuery = Replace(_SqlQuery, "#stmapr#", _stmapr)
        _SqlQuery = Replace(_SqlQuery, "#mrpr#", _mrpr)
        _SqlQuery = Replace(_SqlQuery, "#atpr#", _atpr)
        _SqlQuery = Replace(_SqlQuery, "#rupr#", _rupr)
        _SqlQuery = Replace(_SqlQuery, "#stfi1#", _stfi1)
        _SqlQuery = Replace(_SqlQuery, "#stdv1#", _stdv1)
        _SqlQuery = Replace(_SqlQuery, "#stocnv1#", _stocnv1)
        _SqlQuery = Replace(_SqlQuery, "#stfi2#", _stfi2)
        _SqlQuery = Replace(_SqlQuery, "#stdv2#", _stdv2)
        _SqlQuery = Replace(_SqlQuery, "#stocnv2#", _stocnv2)
        _SqlQuery = Replace(_SqlQuery, "#ppul01#", _ppul01)
        _SqlQuery = Replace(_SqlQuery, "#ppul02#", _ppul02)
        _SqlQuery = Replace(_SqlQuery, "#moul#", _moul)
        _SqlQuery = Replace(_SqlQuery, "#timoul#", _timoul)
        _SqlQuery = Replace(_SqlQuery, "#taul#", _taul)
        _SqlQuery = Replace(_SqlQuery, "#feul#", _feul)
        _SqlQuery = Replace(_SqlQuery, "#pm#", _pm)
        _SqlQuery = Replace(_SqlQuery, "#fepm#", _fepm)
        _SqlQuery = Replace(_SqlQuery, "#fmpr#", _fmpr)
        _SqlQuery = Replace(_SqlQuery, "#pfpr#", _pfpr)
        _SqlQuery = Replace(_SqlQuery, "#hfpr#", _hfpr)
        _SqlQuery = Replace(_SqlQuery, "#vali#", _vali)
        _SqlQuery = Replace(_SqlQuery, "#fevali#", _fevali)
        _SqlQuery = Replace(_SqlQuery, "#ttrepr#", _ttrepr)
        _SqlQuery = Replace(_SqlQuery, "#prrg#", _prrg)
        _SqlQuery = Replace(_SqlQuery, "#niprrg#", _niprrg)
        _SqlQuery = Replace(_SqlQuery, "#nfprrg#", _nfprrg)
        _SqlQuery = Replace(_SqlQuery, "#pmin#", _pmin)
        _SqlQuery = Replace(_SqlQuery, "#camico#", _camico)
        _SqlQuery = Replace(_SqlQuery, "#camifa#", _camifa)
        _SqlQuery = Replace(_SqlQuery, "#lomifa#", _lomifa)
        _SqlQuery = Replace(_SqlQuery, "#plano#", _plano)
        _SqlQuery = Replace(_SqlQuery, "#stdv1c#", _stdv1c)
        _SqlQuery = Replace(_SqlQuery, "#stocnv1c#", _stocnv1c)
        _SqlQuery = Replace(_SqlQuery, "#stdv2c#", _stdv2c)
        _SqlQuery = Replace(_SqlQuery, "#stocnv2c#", _stocnv2c)
        _SqlQuery = Replace(_SqlQuery, "#metrco#", _metrco)
        _SqlQuery = Replace(_SqlQuery, "#despnofac1#", _despnofac1)
        _SqlQuery = Replace(_SqlQuery, "#despnofac2#", _despnofac2)
        _SqlQuery = Replace(_SqlQuery, "#recenofac1#", _recenofac1)
        _SqlQuery = Replace(_SqlQuery, "#recenofac2#", _recenofac2)
        _SqlQuery = Replace(_SqlQuery, "#tratalote#", _tratalote)
        _SqlQuery = Replace(_SqlQuery, "#divisible#", _divisible)
        _SqlQuery = Replace(_SqlQuery, "#mudefa#", _mudefa)
        _SqlQuery = Replace(_SqlQuery, "#exento#", _exento)
        _SqlQuery = Replace(_SqlQuery, "#komode#", _komode)
        _SqlQuery = Replace(_SqlQuery, "#prdesres#", _prdesres)
        _SqlQuery = Replace(_SqlQuery, "#liscosto#", _liscosto)
        _SqlQuery = Replace(_SqlQuery, "#stockaseg#", _stockaseg)
        _SqlQuery = Replace(_SqlQuery, "#esactfi#", _esactfi)
        _SqlQuery = Replace(_SqlQuery, "#clalibpr#", _clalibpr)
        _SqlQuery = Replace(_SqlQuery, "#kofupr#", _kofupr)
        _SqlQuery = Replace(_SqlQuery, "#koprdim#", _koprdim)
        _SqlQuery = Replace(_SqlQuery, "#nodim1#", _nodim1)
        _SqlQuery = Replace(_SqlQuery, "#nodim2#", _nodim2)
        _SqlQuery = Replace(_SqlQuery, "#nodim3#", _nodim3)
        _SqlQuery = Replace(_SqlQuery, "#bloqueapr#", _bloqueapr)
        _SqlQuery = Replace(_SqlQuery, "#zonapr#", _zonapr)
        _SqlQuery = Replace(_SqlQuery, "#conubic#", _conubic)
        _SqlQuery = Replace(_SqlQuery, "#ltsubic#", _ltsubic)
        _SqlQuery = Replace(_SqlQuery, "#pesoubic#", _pesoubic)
        _SqlQuery = Replace(_SqlQuery, "#funclote#", _funclote)
        _SqlQuery = Replace(_SqlQuery, "#lomafa#", _lomafa)
        _SqlQuery = Replace(_SqlQuery, "#colegpr#", _colegpr)
        _SqlQuery = Replace(_SqlQuery, "#morgpr#", _morgpr)
        _SqlQuery = Replace(_SqlQuery, "#fecrpr#", _fecrpr)
        _SqlQuery = Replace(_SqlQuery, "#femopr#", _femopr)
        _SqlQuery = Replace(_SqlQuery, "#lotecaja#", _lotecaja)
        _SqlQuery = Replace(_SqlQuery, "#sttr1#", _sttr1)
        _SqlQuery = Replace(_SqlQuery, "#sttr2#", _sttr2)
        _SqlQuery = Replace(_SqlQuery, "#podeivpr#", _podeivpr)
        _SqlQuery = Replace(_SqlQuery, "#divisible2#", _divisible2)
        _SqlQuery = Replace(_SqlQuery, "#movetiq#", _movetiq)
        _SqlQuery = Replace(_SqlQuery, "#repuesto#", _repuesto)
        _SqlQuery = Replace(_SqlQuery, "#vidamedia#", _vidamedia)
        _SqlQuery = Replace(_SqlQuery, "#tratvmedia#", _tratvmedia)
        _SqlQuery = Replace(_SqlQuery, "#presalcli1#", _presalcli1)
        _SqlQuery = Replace(_SqlQuery, "#presalcli2#", _presalcli2)
        _SqlQuery = Replace(_SqlQuery, "#presdepro1#", _presdepro1)
        _SqlQuery = Replace(_SqlQuery, "#presdepro2#", _presdepro2)
        _SqlQuery = Replace(_SqlQuery, "#consalcli1#", _consalcli1)
        _SqlQuery = Replace(_SqlQuery, "#consalcli2#", _consalcli2)
        _SqlQuery = Replace(_SqlQuery, "#consdepro1#", _consdepro1)
        _SqlQuery = Replace(_SqlQuery, "#consdepro2#", _consdepro2)
        _SqlQuery = Replace(_SqlQuery, "#devengncv1#", _devengncv1)
        _SqlQuery = Replace(_SqlQuery, "#devengncv2#", _devengncv2)
        _SqlQuery = Replace(_SqlQuery, "#devengncc1#", _devengncc1)
        _SqlQuery = Replace(_SqlQuery, "#devengncc2#", _devengncc2)
        _SqlQuery = Replace(_SqlQuery, "#devsinncv1#", _devsinncv1)
        _SqlQuery = Replace(_SqlQuery, "#devsinncv2#", _devsinncv2)
        _SqlQuery = Replace(_SqlQuery, "#devsinncc1#", _devsinncc1)
        _SqlQuery = Replace(_SqlQuery, "#devsinncc2#", _devsinncc2)
        _SqlQuery = Replace(_SqlQuery, "#stenfab1#", _stenfab1)
        _SqlQuery = Replace(_SqlQuery, "#stenfab2#", _stenfab2)
        _SqlQuery = Replace(_SqlQuery, "#streqfab1#", _streqfab1)
        _SqlQuery = Replace(_SqlQuery, "#streqfab2#", _streqfab2)
        _SqlQuery = Replace(_SqlQuery, "#pmme#", _pmme)
        _SqlQuery = Replace(_SqlQuery, "#fepmme#", _fepmme)
        _SqlQuery = Replace(_SqlQuery, "#valunflekm#", _valunflekm)
        _SqlQuery = Replace(_SqlQuery, "#analizable#", _analizable)
        _SqlQuery = Replace(_SqlQuery, "#tolelote#", _tolelote)
        _SqlQuery = Replace(_SqlQuery, "#pmifrs#", _pmifrs)
        _SqlQuery = Replace(_SqlQuery, "#fepmifrs#", _fepmifrs)

        _SqlQuery = Replace(_SqlQuery, "'Null'", "Null")

    End Sub

    Function Fx_Llenar_Zw_Producto(_Codigo As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Productos Where Codigo = '" & _Codigo & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Productos (Codigo,Descripcion)" & vbCrLf &
                           "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigo & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Productos Where Codigo = '" & _Codigo & "'"
                _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

            End If

        End If

        If IsNothing(_Row) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Productos () Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigo & "'"

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_Productos con el Código " & _Codigo

            Return _Mensaje

        End If

        With Zw_Producto

            .Codigo = _Row.Item("Codigo")
            .Descripcion = _Row.Item("Descripcion")
            .ExluyeTipoVenta = _Row.Item("ExluyeTipoVenta")
            .RtuXWms = _Row.Item("RtuXWms")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registro encontrado."
        _Mensaje.Tag = Zw_Producto

        Return _Mensaje

    End Function

    Function Fx_ActualizarRtuAutomaticaWMS(_Codigo As String,
                                           _Empresa As String,
                                           _Sucursal As String,
                                           _Bodega As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Productos Where Codigo = '" & _Codigo & "'"
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _Row_Producto.Item("RtuXWms") = 0 Then

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "El producto " & _Codigo & " no tiene la actualización de RTU por WMS activa."
            _Mensaje.Detalle = "Actualizar RTU"

            Return _Mensaje

        End If

        Consulta_sql = "Select Isnull(SUM(STOCNV1),0) As STOCNV1,Isnull(SUM(STOCNV2),0) As STOCNV2" &
                       ",Isnull(Sum(StPedi1),0) As StPedi1,Isnull(Sum(StPedi2),0) As StPedi2" & vbCrLf &
                       "From MAEST" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Prod_Stock On Empresa = EMPRESA And Sucursal = KOSU And Bodega = KOBO And Codigo = KOPR" & vbCrLf &
                       "Where KOPR = '" & _Codigo & "' And EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _PedidoUd1 As Double = _Row.Item("STOCNV1") + _Row.Item("StPedi1")
        Dim _PedidoUd2 As Double = _Row.Item("STOCNV2") + _Row.Item("StPedi2")

        Dim _Top As Integer = Math.Round(_PedidoUd2, 0)

        Consulta_sql = "Select Round(AVG(Stock_Ud1),5) AS Promedio,(Round(AVG(Stock_Ud1),5)+MAX(Stock_Ud1))/2 As Prom2,MAX(Stock_Ud1) As Max_Stock_Ud1" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto" & vbCrLf &
                       "Where Codigo = '" & _Codigo & "' And Disponible = 1"
        _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Rtu As Double = _Row.Item("Prom2")

        Consulta_sql = "Update MAEPR Set RLUD = " & De_Num_a_Tx_01(_Rtu, False, 5) & vbCrLf &
                       "Where KOPR = '" & _Codigo & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Se actualizo el RTU del producto " & _Codigo & " a " & _Rtu
            _Mensaje.Detalle = "Actualizar RTU"
            _Mensaje.Tag = _Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & _Codigo & "'", True)

        Else

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se pudo actualizar el RTU del producto " & _Codigo & " a " & _Rtu
            _Mensaje.Detalle = "Actualizar RTU"
            _Mensaje.Resultado = _Sql.Pro_Error

        End If

        Return _Mensaje

    End Function

End Class



