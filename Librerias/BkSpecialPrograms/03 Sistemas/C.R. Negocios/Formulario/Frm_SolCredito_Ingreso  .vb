Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient
Imports BkSpecialPrograms

Public Class Frm_SolCredito_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsNegocioCr As New DsNegocioCr

    Dim _NroNegocio As String
    Dim _Stand_By As Boolean

    Dim _Row_Cia_Seguros As DataRow

    Dim _Editar_Negocio As Boolean

    Dim _Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf

    Dim _RowSucursal As DataRow
    Dim _Cadena_ConexionSQL_Seleccionada As String
    Dim _TblEntidad As DataTable

    Dim _TblEncabezado, _TblDetalle, _TblAprobacion, _TblParticipantes As DataTable

    Dim _Directorio_Negocios As String = String.Empty
    Dim _Estado_Doc As _Estado
    Dim _Cerrado As Boolean

    Dim _CodTipo_Negocio, _NomTipo_Negocio As String
    Dim _Tipo_de_Negocio As _Tipo_Negocio

    Dim _TipoDocumento As _TipoDos
    Dim _Cerrar As Boolean

    Dim _Dolar_Emision, _Dolar_Hoy As Double

    Dim Var_Valor_UF,
        Var_Linea_Credito_Int_Ac_Peso,
        Var_Linea_Credito_Int_Ac_UF, Var_Linea_Credito_SC_Ac_UF As Double

    Dim Var_Deuda_Actual,
        Var_Deuda_Actual_UF,
        Var_Prorroga_Negociacion_Vigente,
        Var_Monto_Prox_Vencimiento,
        Var_Margen As Double

    Dim Var_Monto_Venta_Civa,
        Var_Monto_Venta_Civa_UF,
        Var_Plazo_Venta_Dias As Double

    Dim Var_Total_Neto_Aprobado_Pesos,
        Var_Total_Neto_Aprobado_Uf As Double

    Dim _Observaciones_Rtf As New DevComponents.DotNetBar.Controls.RichTextBoxEx

    Dim _Observaciones, _Observaciones_Jefe, _Observaciones_Cierre, _Observaciones_Proximos_Vencimientos_CxC As String


    Dim _Directorio_temporales As String = AppPath(True) & "Temp"

    Dim _CodFuncionario_SCN As String

    Dim _Dir_Temp = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Negocios_Cli"
    Dim _Existe = File.Exists(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

    Dim _Ftp_Host, _Ftp_Puerto, _Ftp_Usuario, _Ftp_Contrasena
    Dim _Id_Correo_Al_Grabar, _Id_Correo_Al_Cerrar

    Dim _Correos_Enviados = 0
    Dim _Correos_Rechazados = 0

    Dim _Estado_Dc As String

    Dim _Nombre_Reporte As String

    Dim _Valor_Dolar_Hoy As Double

    Public Property Pro_NroNegocio As String
        Get
            Return _NroNegocio
        End Get
        Set(value As String)
            _NroNegocio = value
        End Set
    End Property

    Public Property Pro_Stand_By As Boolean
        Get
            Return _Stand_By
        End Get
        Set(value As Boolean)
            _Stand_By = value
        End Set
    End Property

    Public Property Pro_RowSucursal As DataRow
        Get
            Return _RowSucursal
        End Get
        Set(value As DataRow)
            _RowSucursal = value
        End Set
    End Property

    Public Property Pro_Cadena_ConexionSQL_Seleccionada As String
        Get
            Return _Cadena_ConexionSQL_Seleccionada
        End Get
        Set(value As String)
            _Cadena_ConexionSQL_Seleccionada = value
        End Set
    End Property

    Public Property Pro_TblEntidad As DataTable
        Get
            Return _TblEntidad
        End Get
        Set(value As DataTable)
            _TblEntidad = value
        End Set
    End Property

    Public Property Pro_Estado_Doc As _Estado
        Get
            Return _Estado_Doc
        End Get
        Set(value As _Estado)
            _Estado_Doc = value
        End Set
    End Property

    Public Property Pro_Tipo_de_Negocio As _Tipo_Negocio
        Get
            Return _Tipo_de_Negocio
        End Get
        Set(value As _Tipo_Negocio)
            _Tipo_de_Negocio = value
        End Set
    End Property

    Public Property Pro_TipoDocumento As _TipoDos
        Get
            Return _TipoDocumento
        End Get
        Set(value As _TipoDos)
            _TipoDocumento = value
        End Set
    End Property

    Public Property Pro_CodFuncionario_SCN As String
        Get
            Return _CodFuncionario_SCN
        End Get
        Set(value As String)
            _CodFuncionario_SCN = value
        End Set
    End Property

    Public Property Pro_Directorio_Negocios As String
        Get
            Return _Directorio_Negocios
        End Get
        Set(value As String)
            _Directorio_Negocios = value
        End Set
    End Property

    Enum _Tipo_Negocio
        Negocio_por_sobregiro
        Negocio_aumento_linea_credito
    End Enum

    Enum _TipoDos
        Nuevo
        VerDocumento
    End Enum

    Enum _Estado
        Ingresado
        Proceso
        Completado
        Cerrado
    End Enum

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Encabezado, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Cliente, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Llenar_Combos()

        Num_Margen.Minimum = -1000
        Num_Margen.Maximum = 1000

    End Sub

    Private Sub Frm_SolCredito_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Directory.Exists(_Dir_Temp) Then
            Directory.CreateDirectory(_Dir_Temp)
        End If

        If _Existe Then File.Delete(_Dir_Temp & "\Observaciones.rtf")

        Dim _DsNegocioCr As New DsNegocioCr

        _DsNegocioCr.ReadXml(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

        Dim _Fila As DataRow = _DsNegocioCr.Tables("Tbl_Configuracion_local").Rows(0)

        _Ftp_Usuario = _Fila.Item("Ftp_Usuario")
        _Ftp_Contrasena = _Fila.Item("Ftp_Contrasena")
        _Ftp_Host = _Fila.Item("Ftp_Host")
        _Ftp_Puerto = _Fila.Item("Ftp_Puerto")

        _Id_Correo_Al_Grabar = _Fila.Item("Correo_Al_Grabar")
        _Id_Correo_Al_Cerrar = _Fila.Item("Correo_Al_Cerrar")

        If _TipoDocumento = _TipoDos.Nuevo Then
            Sb_Nuevo_Negocio(_TblEntidad)
        ElseIf _TipoDocumento = _TipoDos.VerDocumento Then
            Sb_Abrir_Documento(_NroNegocio, _Stand_By)
            Sb_Formato_Grilla(_TblEncabezado, _TblEntidad)
        End If

        'Me.Text = _NomTipo_Negocio

        AddHandler Txt_Linea_Credito_SC_Ac_UF.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Linea_Credito_SC_Ac_UF.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Deuda_Actual.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Prorroga_Negociacion_Vigente.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Monto_Prox_Vencimiento.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Monto_Venta_Civa.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Total_Neto_Aprobado_Uf.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Total_Neto_Aprobado_Pesos.KeyPress, AddressOf Txt_KeyPress

        AddHandler Txt_Linea_Credito_SC_Ac_UF.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Deuda_Actual.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Prorroga_Negociacion_Vigente.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Monto_Prox_Vencimiento.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Monto_Venta_Civa.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Total_Neto_Aprobado_Uf.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Total_Neto_Aprobado_Pesos.KeyPress, AddressOf Txt_KeyPress_Enter



        AddHandler Txt_Deuda_Actual.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Clasif_Riesgo_comercial.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Morosidades_y_protestos.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Plazo_Venta_Dias.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Producto.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Precio.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Rentabilidad.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Dias_libres.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Taza_de_interes.KeyPress, AddressOf Txt_KeyPress_Enter


        AddHandler Txt_Linea_Credito_SC_Ac_UF.Enter, AddressOf Txt_Enter
        AddHandler Txt_Linea_Credito_SC_Ac_UF.Validated, AddressOf Txt_Validated

        AddHandler Txt_Deuda_Actual.Enter, AddressOf Txt_Enter
        AddHandler Txt_Deuda_Actual.Validated, AddressOf Txt_Validated

        AddHandler Txt_Prorroga_Negociacion_Vigente.Enter, AddressOf Txt_Enter
        AddHandler Txt_Prorroga_Negociacion_Vigente.Validated, AddressOf Txt_Validated

        AddHandler Txt_Monto_Venta_Civa.Enter, AddressOf Txt_Enter
        AddHandler Txt_Monto_Venta_Civa.Validated, AddressOf Txt_Validated

        AddHandler Txt_Deuda_Actual.Enter, AddressOf Txt_Enter
        AddHandler Txt_Deuda_Actual.Validated, AddressOf Txt_Validated

        AddHandler Txt_Clasif_Riesgo_comercial.Enter, AddressOf Txt_Enter
        AddHandler Txt_Clasif_Riesgo_comercial.Validated, AddressOf Txt_Validated

        AddHandler Txt_Morosidades_y_protestos.Enter, AddressOf Txt_Enter
        AddHandler Txt_Morosidades_y_protestos.Validated, AddressOf Txt_Validated

        AddHandler Txt_Plazo_Venta_Dias.Enter, AddressOf Txt_Enter
        AddHandler Txt_Plazo_Venta_Dias.Validated, AddressOf Txt_Validated

        AddHandler Txt_Producto.Enter, AddressOf Txt_Enter
        AddHandler Txt_Producto.Validated, AddressOf Txt_Validated

        AddHandler Txt_Precio.Enter, AddressOf Txt_Enter
        AddHandler Txt_Precio.Validated, AddressOf Txt_Validated

        AddHandler Txt_Rentabilidad.Enter, AddressOf Txt_Enter
        AddHandler Txt_Rentabilidad.Validated, AddressOf Txt_Validated

        AddHandler Txt_Dias_libres.Enter, AddressOf Txt_Enter
        AddHandler Txt_Dias_libres.Validated, AddressOf Txt_Validated

        AddHandler Txt_Taza_de_interes.Enter, AddressOf Txt_Enter
        AddHandler Txt_Taza_de_interes.Validated, AddressOf Txt_Validated

        AddHandler Txt_Score_Crediticio.Validated, AddressOf Txt_Validated
        AddHandler Txt_Score_Crediticio.KeyPress, AddressOf Txt_KeyPress_Enter

        'AddHandler Txt_Margen.Enter, AddressOf Txt_Enter
        'AddHandler Txt_Margen.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        'AddHandler Txt_Margen.Validated, AddressOf Txt_Validated
        AddHandler Num_Margen.KeyPress, AddressOf Txt_KeyPress_Enter



        AddHandler Rdb_Valores_Linea_Credito_Desde_Aseguradora.CheckedChanged, AddressOf Sb_Rdb_Valores_Linea_Credito_CheckedChanged
        AddHandler Rdb_Valores_Linea_Credito_Desde_Random.CheckedChanged, AddressOf Sb_Rdb_Valores_Linea_Credito_CheckedChanged

        '''AddHandler Txt_Linea_Credito_SC_Ac_UF.Validating, AddressOf Txt_Valor_Cero_Validating
        'AddHandler Txt_Linea_Credito_Int_Ac_Peso.Validating, AddressOf Txt_Valor_Cero_Validating
        'AddHandler Txt_Linea_Credito_Int_Ac_UF.Validating, AddressOf Txt_Valor_Cero_Validating

        '''AddHandler Txt_Deuda_Actual.Validating, AddressOf Txt_Valor_Cero_Validating
        '''AddHandler Txt_Prorroga_Negociacion_Vigente.Validating, AddressOf Txt_Valor_Cero_Validating
        '''AddHandler Txt_Monto_Prox_Vencimiento.Validating, AddressOf Txt_Valor_Cero_Validating

        '''AddHandler Txt_Monto_Venta_Civa.Validating, AddressOf Txt_Valor_Cero_Validating
        '''AddHandler Txt_Plazo_Venta_Dias.Validating, AddressOf Txt_Valor_Cero_Validating

        ' AddHandler Txt_Plazo_Venta_Dias.KeyPress, AddressOf Txt_KeyPress

        ' AddHandler Txt_Producto.KeyPress, AddressOf Txt_KeyPress
        ' AddHandler Txt_Precio.KeyPress, AddressOf Txt_KeyPress
        ' AddHandler Txt_Rentabilidad.KeyPress, AddressOf Txt_KeyPress

        _Row_Cia_Seguros = Fx_Trae_Row_Cia_Seguros()

        Dim _Fecha As Date = FormatDateTime(Grilla_Encabezado.Rows(0).Cells("Fecha_Emision").Value, DateFormat.ShortDate)
        _Dolar_Emision = _Sql.Fx_Trae_Dato("MAEMO", "VAMO",
                                           "KOMO = 'US$' AND FEMO = '" & Format(_Fecha, "yyyyMMdd") & "'", True)
        _Dolar_Hoy = _Sql.Fx_Trae_Dato("MAEMO", "VAMO",
                                           "KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "'", True)


    End Sub

    Public Sub Sb_Nuevo_Negocio(ByVal _TblEntidad As DataTable)

        Dim _Empresa = _RowSucursal.Item("EMPRESA")
        Dim _Sucursal = Trim(_RowSucursal.Item("KOSU"))
        Dim _NomSucursal = Trim(_RowSucursal.Item("NOKOSU"))

        Dtp_Fecha_Prox_Vencimiento.Value = FechaDelServidor()

        Btn_Observaciones_Jefe.Visible = False
        Btn_Observaciones_Generales.Visible = False
        Btn_Corregir_Negocio.Visible = False
        Btn_Anular_Documento.Visible = False
        Btn_Editar_Negocio.Visible = False

        Lbl_Etiqueta_ValorUF.Text = "Valor UF (" & FormatDateTime(FechaDelServidor, DateFormat.ShortDate) & ")"

        Var_Valor_UF = _Sql.Fx_Trae_Dato("MAEMO", "VAMO", "KOMO = 'UF' And FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "'", True)
        'trae_dato(tb, cn1, "VAMO", "MAEMO", "KOMO = 'UF' And FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "'", True)
        Lbl_ValorUF.Text = FormatNumber(Var_Valor_UF, 2)

        Sb_Actualizar_Datos_Linea_Credito()
        'Var_Linea_Credito_Int_Ac_Peso = _TblEntidad.Rows(0).Item("CRTO")
        'Lbl_Linea_Credito_Int_Ac_Peso.Text = FormatNumber(Var_Linea_Credito_Int_Ac_Peso, 0)

        'Var_Linea_Credito_Int_Ac_UF = Fx_Convert_UF2Peso(Var_Linea_Credito_Int_Ac_Peso, Var_Valor_UF, True)
        'Lbl_Linea_Credito_Int_Ac_UF.Text = FormatNumber(Var_Linea_Credito_Int_Ac_UF, 2)

        Dim _NroNegocio As String

        Consulta_sql = "Select 'En Curso' As 'Nro_Negocio',CONVERT(VARCHAR, Getdate(), 103)  As 'Fecha_Emision'" &
                       ",'" & FUNCIONARIO & "' As 'CodFuncionario'" &
                       ",'" & Nombre_funcionario_activo & "' As 'NomFuncionario','" & _Empresa & "' As 'Empresa'" &
                       ",'" & _Sucursal & "' As 'Sucursal', '" & _NomSucursal & "' as 'NomSucursal'"

        Dim _TblEncabezado As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Formato_Grilla(_TblEncabezado, _TblEntidad)

        Consulta_sql = "Select CAST( 1 AS bit) AS Chk,KOFU as Codigo,NOKOFU as Descripcion From TABFU" & vbCrLf &
                     "Where KOFU IN (SELECT CodFuncionario FROM " & _Global_BaseBk & "Zw_Negocios_02_Fun " &
                     "Where Nro_Negocio = '' And Stand_By = 0)"

        _TblParticipantes = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)
        Btn_Carpeta_negocio.Visible = False
        Btn_Calcular_Sobre_Giro.Visible = False

        _Estado_Dc = String.Empty

    End Sub

    Sub Sb_Actualizar_Datos_Linea_Credito()


        RemoveHandler Rdb_Valores_Linea_Credito_Desde_Aseguradora.CheckedChanged, AddressOf Sb_Rdb_Valores_Linea_Credito_CheckedChanged
        RemoveHandler Rdb_Valores_Linea_Credito_Desde_Random.CheckedChanged, AddressOf Sb_Rdb_Valores_Linea_Credito_CheckedChanged

        _Row_Cia_Seguros = Fx_Trae_Row_Cia_Seguros()

        If _Row_Cia_Seguros Is Nothing Then
            Rdb_Valores_Linea_Credito_Desde_Aseguradora.Checked = False
            Rdb_Valores_Linea_Credito_Desde_Random.Checked = True
        End If

        If Rdb_Valores_Linea_Credito_Desde_Aseguradora.Checked Then

            Dim _Clascrediticia = _Row_Cia_Seguros.Item("Clascrediticia")
            Dim _Monto_Asignado = _Row_Cia_Seguros.Item("Monto_Asignado")
            Dim _Moneda = Trim(_Row_Cia_Seguros.Item("Moneda"))

            Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.SelectedValue = _Clascrediticia

            If _Moneda = "$" Then
                Var_Linea_Credito_Int_Ac_Peso = _Monto_Asignado
                Var_Linea_Credito_Int_Ac_UF = Fx_Convert_UF2Peso(Var_Linea_Credito_Int_Ac_Peso, Var_Valor_UF, True)
            ElseIf _Moneda = "UF" Then
                Var_Linea_Credito_Int_Ac_UF = _Monto_Asignado
                Var_Linea_Credito_Int_Ac_Peso = Fx_Convert_UF2Peso(Var_Linea_Credito_Int_Ac_UF, Var_Valor_UF, False) '_Monto
            End If

            'Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Enabled = False
        ElseIf Rdb_Valores_Linea_Credito_Desde_Random.Checked Then
            Var_Linea_Credito_Int_Ac_Peso = _TblEntidad.Rows(0).Item("CRTO")
            Var_Linea_Credito_Int_Ac_UF = Fx_Convert_UF2Peso(Var_Linea_Credito_Int_Ac_Peso, Var_Valor_UF, True)
            Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.SelectedValue = ""
            'Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Enabled = True
        End If


        Lbl_Linea_Credito_Int_Ac_UF.Text = FormatNumber(Var_Linea_Credito_Int_Ac_UF, 2)
        Lbl_Linea_Credito_Int_Ac_Peso.Text = FormatNumber(Var_Linea_Credito_Int_Ac_Peso, 0)


        Lbl_Linea_Credito_Int_Ac_Peso.Text = FormatNumber(Var_Linea_Credito_Int_Ac_Peso, 0)
        Lbl_Linea_Credito_Int_Ac_UF.Text = FormatNumber(Var_Linea_Credito_Int_Ac_UF, 2)

        AddHandler Rdb_Valores_Linea_Credito_Desde_Aseguradora.CheckedChanged, AddressOf Sb_Rdb_Valores_Linea_Credito_CheckedChanged
        AddHandler Rdb_Valores_Linea_Credito_Desde_Random.CheckedChanged, AddressOf Sb_Rdb_Valores_Linea_Credito_CheckedChanged


    End Sub

    Function Fx_Trae_Row_Cia_Seguros() As DataRow

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
        Dim _Global_BaseBk_Original = _Global_BaseBk

        Try

            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Seleccionada

            Dim _New_Sql As New Class_SQL(_Cadena_ConexionSQL_Seleccionada)

            Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(Me)

            If _Class_BaseBk.Pro_Existe_Base Then
                _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")
            Else

                'MessageBoxEx.Show(Me, "No esta configurada la base de datos de BakApp", _
                '                  "Falta identificación de base BakApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Throw New Exception("No esta configurada la base de datos de BakApp" & vbCrLf &
                                    "Falta identificación de base BakApp")
            End If


            Dim _Koen = _TblEntidad.Rows(0).Item("KOEN")
            Dim _Suen = _TblEntidad.Rows(0).Item("SUEN")

            Dim _Rut = _TblEntidad.Rows(0).Item("RTEN")

            Consulta_sql = "Select Top 1 RTEN As _Rut,NOKOEN As Razon," &
                            "CAST(0 As Float) as Monto_Asignado,CAST('' As Varchar(3)) As Moneda," &
                            "CAST('' As Varchar(20)) As Clascrediticia,CAST(Null As Date) As Fecha_Vigencia," &
                            "CAST(0 As Float) as Porc_Exposicion" & vbCrLf &
                            "Into #Paso1" & vbCrLf &
                            "FROM MAEEN WHERE RTEN = '" & Trim(_Rut) & "' ORDER BY TIPOSUC" & vbCrLf &
                            "Update #Paso1 Set Monto_Asignado = Isnull((Select Monto_Asignado From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),0)," & vbCrLf &
                            "Moneda =  Isnull((Select Moneda From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),'$')," & vbCrLf &
                            "Clascrediticia = Isnull((Select Clascrediticia From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),'003')," & vbCrLf &
                            "Fecha_Vigencia = Isnull((Select Fecha_Vigencia From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),GETDATE())," & vbCrLf &
                            "Porc_Exposicion = Isnull((Select Porc_Exposicion From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),100)" & vbCrLf &
                            "Select Top 1 * From #Paso1" & vbCrLf &
                            "Drop Table #Paso1"

            Dim _Row As DataRow = _New_Sql.Fx_Get_DataRow(Consulta_sql)

            Return _Row

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al traer datos de la compañia de seguros del cliente")
        Finally
            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
            _Global_BaseBk = _Global_BaseBk_Original
        End Try

    End Function

    Sub Sb_Formato_Grilla(ByVal _TblEncabezado As DataTable, ByVal _TblEntidad As DataTable)

        With Grilla_Encabezado
            .DataSource = _TblEncabezado

            OcultarEncabezadoGrilla(Grilla_Encabezado, True)

            .Columns("Nro_Negocio").ReadOnly = True
            .Columns("Nro_Negocio").Width = 100
            .Columns("Nro_Negocio").HeaderText = "N° Negocio"
            .Columns("Nro_Negocio").Visible = True
            .Columns("Nro_Negocio").Frozen = True
            .Columns("Nro_Negocio").DisplayIndex = 0

            .Columns("NomSucursal").ReadOnly = True
            .Columns("NomSucursal").Width = 250
            .Columns("NomSucursal").HeaderText = "Sucursal"
            .Columns("NomSucursal").Visible = True
            .Columns("NomSucursal").Frozen = True
            .Columns("NomSucursal").DisplayIndex = 1

            .Columns("Fecha_Emision").ReadOnly = True
            .Columns("Fecha_Emision").Width = 100
            .Columns("Fecha_Emision").HeaderText = "Fecha emisión"
            .Columns("Fecha_Emision").Visible = True
            .Columns("Fecha_Emision").Frozen = True
            .Columns("Fecha_Emision").DisplayIndex = 2

            .Columns("NomFuncionario").ReadOnly = True
            .Columns("NomFuncionario").Width = 280
            .Columns("NomFuncionario").HeaderText = "Responsable"
            .Columns("NomFuncionario").Visible = True
            .Columns("NomFuncionario").Frozen = True
            .Columns("NomFuncionario").DisplayIndex = 3

        End With

        With Grilla_Cliente
            .DataSource = _TblEntidad
            OcultarEncabezadoGrilla(Grilla_Cliente, True)

            .Columns("Rut").ReadOnly = True
            .Columns("Rut").Width = 100
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Visible = True
            .Columns("Rut").Frozen = True
            .Columns("Rut").DisplayIndex = 0

            .Columns("NOKOEN").ReadOnly = True
            .Columns("NOKOEN").Width = 250
            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").Frozen = True
            .Columns("NOKOEN").DisplayIndex = 1

            .Columns("DIEN").ReadOnly = True
            .Columns("DIEN").Width = 250
            .Columns("DIEN").HeaderText = "Dirección"
            .Columns("DIEN").Visible = True
            .Columns("DIEN").Frozen = True
            .Columns("DIEN").DisplayIndex = 2

            .Columns("COMUNA").ReadOnly = True
            .Columns("COMUNA").Width = 160
            .Columns("COMUNA").HeaderText = "Comuna"
            .Columns("COMUNA").Visible = True
            .Columns("COMUNA").Frozen = True
            .Columns("COMUNA").DisplayIndex = 3

        End With


    End Sub

    Sub Sb_Abrir_Documento(ByVal _Nro_Negocio As String, ByVal _Stand_By As Boolean)

        Dim _Ds As DataSet

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_01_Enc" & vbCrLf &
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Negocios_02_Det" & vbCrLf &
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _Nro_Negocio & "'" & vbCrLf &
                       "Select CAST( 1 AS bit) AS Chk,CodFuncionario as Codigo,NomFuncionario as Descripcion," & vbCrLf &
                       "(SELECT top 1 Enviar_copia_al_cierre " &
                       "FROM " & _Global_BaseBk & "Zw_Negocios_02_Fun " &
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = 0) as Enviar_copia_al_cierre" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Usuarios" & vbCrLf &
                       "Where CodFuncionario IN (SELECT CodFuncionario FROM " & _Global_BaseBk & "Zw_Negocios_02_Fun " &
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & ")"

        '_TblParticipantes = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql) 'Get_DataSet(Consulta_sql, cn1)

        _TblEncabezado = _Ds.Tables(0)

        _Estado_Dc = _TblEncabezado.Rows(0).Item("Estado")

        If _Stand_By Then _TblEncabezado.Rows(0).Item("Nro_Negocio") = "En Curso"
        _TblDetalle = _Ds.Tables(1)

        _TblParticipantes = _Ds.Tables(3)

        Cmb_Tipo.SelectedValue = _TblEncabezado.Rows(0).Item("Tipo")

        _CodTipo_Negocio = Cmb_Tipo.SelectedValue
        _NomTipo_Negocio = Cmb_Tipo.Text
        'Btn_Corregir_Negocio.Visible = True


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _Nro_Negocio & "'"
        Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

        Btn_Imprimir.Visible = False

        If _TblAprobacion.Rows.Count >= 3 Then
            _Estado_Doc = _Estado.Completado

            Dim _Es = _TblEncabezado.Rows(0).Item("Estado")

            If _TblEncabezado.Rows(0).Item("Estado") = "C1" Or
               _TblEncabezado.Rows(0).Item("Estado") = "C2" Then

                _Estado_Doc = _Estado.Cerrado
                Btn_Cerrar_documento.Visible = False
                Btn_Anular_Documento.Visible = False
                Btn_Imprimir.Visible = True
                Btn_Reenbiar_Correo.Visible = True
                Btn_Corregir_Negocio.Visible = False

                _Cerrado = True

                Var_Total_Neto_Aprobado_Uf = _TblDetalle.Rows(0).Item("Total_Neto_Aprobado_Uf")
                Var_Total_Neto_Aprobado_Pesos = _TblDetalle.Rows(0).Item("Total_Neto_Aprobado_Pesos")

                Txt_Total_Neto_Aprobado_Uf.Text = FormatNumber(Var_Total_Neto_Aprobado_Uf, 5)
                Txt_Total_Neto_Aprobado_Pesos.Text = FormatNumber(Var_Total_Neto_Aprobado_Pesos, 0)

            ElseIf _TblEncabezado.Rows(0).Item("Estado") = "CM" Then

                _Estado_Doc = _Estado.Completado
                Btn_Cerrar_documento.Visible = True
                Grupo_Total_Aprobado.Enabled = True
                Btn_Corregir_Negocio.Visible = False

                ',Estado_Cerrado = 'PRE-APROBADO'

                Txt_Total_Neto_Aprobado_Uf.Text = ""
                Txt_Total_Neto_Aprobado_Pesos.Text = ""
                Txt_Total_Neto_Aprobado_Uf.ReadOnly = False
                'Txt_Total_Neto_Aprobado_Pesos.ReadOnly = False
                Me.ActiveControl = Txt_Total_Neto_Aprobado_Uf

            ElseIf _TblEncabezado.Rows(0).Item("Estado") = "C3" Then

                _Estado_Doc = _Estado.Completado
                Btn_Cerrar_documento.Visible = True
                Grupo_Total_Aprobado.Enabled = True
                Btn_Corregir_Negocio.Visible = False

                ',Estado_Cerrado = 'PRE-APROBADO'

                If _TblEncabezado.Rows(0).Item("Estado_Cerrado") = "PRE-APROBADO" Then

                    Var_Total_Neto_Aprobado_Uf = _TblDetalle.Rows(0).Item("Total_Neto_Aprobado_Uf")
                    Var_Total_Neto_Aprobado_Pesos = _TblDetalle.Rows(0).Item("Total_Neto_Aprobado_Pesos")

                    Txt_Total_Neto_Aprobado_Uf.Text = FormatNumber(Var_Total_Neto_Aprobado_Uf, 2)
                    Txt_Total_Neto_Aprobado_Pesos.Text = FormatNumber(Var_Total_Neto_Aprobado_Pesos, 0)

                Else

                    Txt_Total_Neto_Aprobado_Uf.Text = ""
                    Txt_Total_Neto_Aprobado_Pesos.Text = ""
                    Txt_Total_Neto_Aprobado_Uf.ReadOnly = False
                    'Txt_Total_Neto_Aprobado_Pesos.ReadOnly = False
                    Me.ActiveControl = Txt_Total_Neto_Aprobado_Uf

                End If

            End If

        End If

        _TblAprobacion = _Ds.Tables(2)

        Dim _CodEntidad = _TblEncabezado.Rows(0).Item("CodEntidad")
        Dim _CodSucursal = _TblEncabezado.Rows(0).Item("CodSucursal")
        Dim _Fecha_Emision = _TblEncabezado.Rows(0).Item("Fecha_Emision")
        _CodFuncionario_SCN = _TblEncabezado.Rows(0).Item("CodFuncionario")

        _CodTipo_Negocio = _TblEncabezado.Rows(0).Item("Tipo")
        _NomTipo_Negocio = _TblEncabezado.Rows(0).Item("NomTipo")

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server


        Cadena_ConexionSQL_Server = _TblEncabezado.Rows(0).Item("Cadena_Conexion")
        _Cadena_ConexionSQL_Seleccionada = Cadena_ConexionSQL_Server

        Dim Fm_e As New Frm_BuscarEntidad_Mt(False)
        _TblEntidad = Fx_Traer_Datos_Entidad_Tabla(_CodEntidad, _CodSucursal)

        Dim _Empresa = _TblEncabezado.Rows(0).Item("Empresa")
        Dim _Sucursal = _TblEncabezado.Rows(0).Item("Sucursal")
        Dim _NomSucursal = _TblEncabezado.Rows(0).Item("NomSucursal")

        Consulta_sql = "SELECT '" & _Empresa & "' As EMPRESA,'" & _Sucursal & "' As KOSU,'" & _NomSucursal & "' As NOKOSU"
        _RowSucursal = _Sql.Fx_Get_DataRow(Consulta_sql)

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

        'SQL_ServerClass.AbrirConexion_SQLServer(cn1)

        If CBool(_TblDetalle.Rows.Count) Then
            With _TblDetalle.Rows(0)

                Lbl_Etiqueta_ValorUF.Text = "Valor UF (" & FormatDateTime(_Fecha_Emision, DateFormat.ShortDate) & ")"
                Var_Valor_UF = .Item("Valor_UF")
                Lbl_ValorUF.Text = FormatCurrency(Var_Valor_UF, 2)

                Var_Linea_Credito_SC_Ac_UF = .Item("Linea_Credito_SC_Ac_UF")
                Txt_Linea_Credito_SC_Ac_UF.Text = "UF " & FormatNumber(Math.Round(Var_Linea_Credito_SC_Ac_UF), 0)

                Var_Linea_Credito_Int_Ac_Peso = .Item("Linea_Credito_Int_Ac_Peso")
                Lbl_Linea_Credito_Int_Ac_Peso.Text = FormatCurrency(Var_Linea_Credito_Int_Ac_Peso, 0)

                Var_Linea_Credito_Int_Ac_UF = .Item("Linea_Credito_Int_Ac_UF")
                Lbl_Linea_Credito_Int_Ac_UF.Text = "UF " & FormatNumber(Math.Round(Var_Linea_Credito_Int_Ac_UF), 0)

                Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.SelectedValue = .Item("Cod_Clas_Crediticia_Ac_Seg_Credito")

                Var_Deuda_Actual = .Item("Deuda_Actual")
                Txt_Deuda_Actual.Text = FormatCurrency(Var_Deuda_Actual, 0)

                Var_Deuda_Actual_UF = Fx_Convert_UF2Peso(Var_Deuda_Actual, Var_Valor_UF, True)
                Lbl_Deuda_Actual_UF.Text = "UF " & FormatNumber(Math.Round(Var_Deuda_Actual_UF), 0)

                Dtp_Fecha_Prox_Vencimiento.Value = .Item("Fecha_Prox_Vencimiento")

                Txt_Clasif_Riesgo_comercial.Text = .Item("Clasif_Riesgo_comercial")
                Txt_Morosidades_y_protestos.Text = .Item("Morosidades_y_protestos")

                Var_Prorroga_Negociacion_Vigente = .Item("Prorroga_Negociacion_Vigente")
                Txt_Prorroga_Negociacion_Vigente.Text = FormatCurrency(Var_Prorroga_Negociacion_Vigente, 0)

                Var_Monto_Prox_Vencimiento = .Item("Monto_Prox_Vencimiento")
                Txt_Monto_Prox_Vencimiento.Text = FormatCurrency(.Item("Monto_Prox_Vencimiento"), 0)

                Var_Monto_Venta_Civa = .Item("Monto_Venta_Civa")
                Txt_Monto_Venta_Civa.Text = FormatCurrency(Var_Monto_Venta_Civa, 0)

                Var_Monto_Venta_Civa_UF = Fx_Convert_UF2Peso(Var_Monto_Venta_Civa, Var_Valor_UF, True)
                Lbl_Monto_Venta_Civa_UF.Text = "UF " & FormatNumber(Math.Round(Var_Monto_Venta_Civa_UF), 0)

                Var_Plazo_Venta_Dias = .Item("Plazo_Venta_Dias")
                Txt_Plazo_Venta_Dias.Text = Var_Plazo_Venta_Dias

                Cmb_CodVendedor.SelectedValue = .Item("CodVendedor")

                Txt_Producto.Text = .Item("Producto")
                Txt_Precio.Text = .Item("Precio")
                Txt_Rentabilidad.Text = .Item("Rentabilidad")

                Txt_Dias_libres.Text = .Item("Dias_libres")
                Txt_Taza_de_interes.Text = .Item("Taza_de_interes")

                Rdb_Doc_Venta_SI.Checked = .Item("Doc_Venta_SI")
                Cmb_Cod_Doc_Venta_SI.SelectedValue = .Item("Cod_Doc_Venta_SI")
                Rdb_Doc_Venta_NO.Checked = .Item("Doc_Venta_NO")

                Rdb_Ficha_Int_Cli_Completa.Checked = .Item("Ficha_Int_Cli_Completa")
                Rdb_Ficha_Int_Cli_Parcial.Checked = .Item("Ficha_Int_Cli_Parcial")
                Rdb_Ficha_Int_Cli_SinAntecedentes.Checked = .Item("Ficha_Int_Cli_SinAntecedentes")

                Txt_Score_Crediticio.Text = .Item("Score_Crediticio")
                Var_Margen = .Item("Margen")

                Num_Margen.Value = Var_Margen 'FormatPercent(Var_Margen / 100, 2)
                'Lbl_Linea_Credito_Int_Ac_UF.Text = FormatNumber(Math.Round(Var_Linea_Credito_Int_Ac_UF), 0)
                Rdb_Valores_Linea_Credito_Desde_Aseguradora.Checked = .Item("Valores_Linea_Credito_Desde_Aseguradora")
                Rdb_Valores_Linea_Credito_Desde_Random.Checked = .Item("Valores_Linea_Credito_Desde_Random")

                If Not Rdb_Valores_Linea_Credito_Desde_Aseguradora.Checked And
                   Not Rdb_Valores_Linea_Credito_Desde_Random.Checked Then

                    Rdb_Valores_Linea_Credito_Desde_Random.Checked = True

                End If

                '_Observaciones_Rtf.SaveFile(_Dir_Temp & "\Observacion_Rtf.rtf")
                Dim Fm As New Frm_SolCredito_File_Attach(_Nro_Negocio)
                'Fm.Fx_Grabar_Observacion_Adjunta(_NroNegocio, _Dir_Temp & "\Observacion_Rtf.rtf", "Observacion_Rtf.rtf", _
                '                                Frm_SolCredito_File_Attach.Tipo_Obs.OBS_VENCIMIENTO)

                Dim _Semilla As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Negocios_04_Doc", "Semilla",
                                                            "Tipo_Obs = 'OBS_VENCIMIENTO' And NroNegocio = '" & _Nro_Negocio & "'", True)
                'trae_dato(tb, cn1, "Semilla", _
                '        _Global_BaseBk & "Zw_Negocios_04_Doc", _
                '        "Tipo_Obs = 'OBS_VENCIMIENTO' And NroNegocio = '" & _Nro_Negocio & "'", True)

                If CBool(_Semilla) Then

                    Fm.Fx_Extrae_Archivo_desde_BD(_Semilla, "Observacion_Rtf.rtf", _Dir_Temp)
                    Fm.Dispose()

                    _Observaciones_Rtf.LoadFile(_Dir_Temp & "\Observacion_Rtf.rtf")
                    File.Delete(_Dir_Temp & "\Observacion_Rtf.rtf")

                End If

                _Observaciones_Proximos_Vencimientos_CxC = .Item("Obs_Proximos_Vencimientos_CxC")
                _Observaciones = .Item("Observaciones")
                _Observaciones_Jefe = .Item("Observaciones_Jefe")
                _Observaciones_Cierre = .Item("Cierre_Observaciones")

                _Nombre_Reporte = "Reporte_" & _NroNegocio & ".pdf"

            End With
        End If

        If _Stand_By Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Negocios_01_Enc" & vbCrLf &
                           "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Negocios_02_Det" & vbCrLf &
                           "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Negocios_02_Fun" & vbCrLf &
                           "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1

            _Sql.Ej_consulta_IDU(Consulta_sql) 'Ej_consulta_IDU(Consulta_sql, cn1)

            Btn_Carpeta_negocio.Visible = False
            Btn_Anular_Documento.Visible = False
            _TipoDocumento = _TipoDos.Nuevo

            Btn_Observaciones_Jefe.Visible = False
            Btn_Observaciones_Generales.Visible = False
            Btn_Corregir_Negocio.Visible = False
            Btn_Anular_Documento.Visible = False
            Btn_Editar_Negocio.Visible = False

        Else

            If _Estado_Dc = "IN" Or _Estado_Dc = "CO" Then

                Btn_Observaciones_Jefe.Visible = False
                Btn_Editar_Negocio.Visible = True
                Btn_Gestion_Comite.Visible = False

                Btn_Grabar_Negocio.Visible = False
                Btn_Corregir_Negocio.Visible = False

                If _Estado_Dc = "CO" Then
                    Sb_Editar_Documento(False)
                    _Editar_Negocio = True
                    Exit Sub
                End If

            Else
                Btn_Editar_Negocio.Visible = False
                'Btn_Corregir_Negocio.Visible = True
            End If

            Btn_Calcular_Sobre_Giro.Visible = True
            Btn_Grabar_Stand_By.Visible = False

            Sb_No_Editar_Documento()

        End If

    End Sub


    Sub Sb_No_Editar_Documento()

        ' Return
        Btn_Grabar_Negocio.Visible = False
        Btn_Grabar_Stand_By.Visible = False
        Btn_Carpeta_negocio.Visible = True
        Btn_Observaciones_Jefe.Visible = True

        Rdb_Valores_Linea_Credito_Desde_Aseguradora.Enabled = False
        Rdb_Valores_Linea_Credito_Desde_Random.Enabled = False

        Txt_Linea_Credito_SC_Ac_UF.ReadOnly = True
        Txt_Clasif_Riesgo_comercial.ReadOnly = True
        Txt_Morosidades_y_protestos.ReadOnly = True
        Txt_Deuda_Actual.ReadOnly = True
        Txt_Prorroga_Negociacion_Vigente.ReadOnly = True
        Txt_Monto_Prox_Vencimiento.ReadOnly = True
        Dtp_Fecha_Prox_Vencimiento.Enabled = False
        Txt_Monto_Venta_Civa.ReadOnly = True
        Txt_Plazo_Venta_Dias.ReadOnly = True
        Cmb_CodVendedor.Enabled = False
        Txt_Producto.ReadOnly = True
        Txt_Precio.ReadOnly = True
        Txt_Score_Crediticio.ReadOnly = True
        Num_Margen.Enabled = False

        Txt_Rentabilidad.ReadOnly = True
        Txt_Dias_libres.ReadOnly = True
        Txt_Taza_de_interes.ReadOnly = True
        Grupo_Documento_Venta.Enabled = False
        Grupo_Ficha_interna_cliente.Enabled = False

        Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Enabled = False
        Cmb_Tipo.Enabled = False

        Me.Refresh()

    End Sub

    Sub Sb_Editar_Documento(ByVal _Mostrar_Mensaje As Boolean)

        Btn_Editar_Negocio.Visible = False
        Btn_Grabar_Negocio.Visible = True
        Btn_Grabar_Stand_By.Visible = False
        Btn_Carpeta_negocio.Visible = True
        Btn_Observaciones_Jefe.Visible = False

        Rdb_Valores_Linea_Credito_Desde_Aseguradora.Enabled = True
        Rdb_Valores_Linea_Credito_Desde_Random.Enabled = True

        Txt_Linea_Credito_SC_Ac_UF.ReadOnly = False
        Txt_Clasif_Riesgo_comercial.ReadOnly = False
        Txt_Morosidades_y_protestos.ReadOnly = False
        Txt_Deuda_Actual.ReadOnly = False
        Txt_Prorroga_Negociacion_Vigente.ReadOnly = False
        Txt_Monto_Prox_Vencimiento.ReadOnly = False
        Dtp_Fecha_Prox_Vencimiento.Enabled = False
        Txt_Monto_Venta_Civa.ReadOnly = False
        Txt_Plazo_Venta_Dias.ReadOnly = False
        Cmb_CodVendedor.Enabled = True
        Txt_Producto.ReadOnly = False
        Txt_Precio.ReadOnly = False
        Txt_Score_Crediticio.ReadOnly = False
        Num_Margen.Enabled = True

        Txt_Rentabilidad.ReadOnly = False
        Txt_Dias_libres.ReadOnly = False
        Txt_Taza_de_interes.ReadOnly = False

        Grupo_Documento_Venta.Enabled = True
        Grupo_Ficha_interna_cliente.Enabled = True

        Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Enabled = True
        Cmb_Tipo.Enabled = True

        'MessageBoxEx.Show(Me, "Ahora es posible editar el documento", "Editar", _
        '                  MessageBoxButtons.OK, MessageBoxIcon.Information)

        Txt_Linea_Credito_SC_Ac_UF.Focus()

        If _Mostrar_Mensaje Then
            Beep()
            ToastNotification.Show(Me, UCase("Ahora es posible editar el documento"),
                                   My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If
        Me.Refresh()

    End Sub


    Sub Sb_Llenar_Combos()

        caract_combo(Cmb_Tipo)
        Consulta_sql = _Union & "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf &
                        "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'NEGOCIO_TIPO'" & vbCrLf &
                        "ORDER BY Padre"
        Cmb_Tipo.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Tipo.SelectedValue = ""

        caract_combo(Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito)
        Consulta_sql = _Union & "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf &
                        "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'NEGOCIO_CLASCREDI'" & vbCrLf &
                        "ORDER BY Padre"

        Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.SelectedValue = ""

        caract_combo(Cmb_Cod_Doc_Venta_SI)
        Consulta_sql = _Union & "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf &
                        "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'NEGOCIO_DOCVTA'" & vbCrLf &
                        "ORDER BY Padre"


        Cmb_Cod_Doc_Venta_SI.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Cod_Doc_Venta_SI.SelectedValue = ""


        caract_combo(Cmb_CodVendedor)
        Consulta_sql = _Union & "SELECT CodFuncionario AS Padre,NomFuncionario AS Hijo" & vbCrLf &
                        "FROM " & _Global_BaseBk & "Zw_Usuarios" & vbCrLf &
                        "Where Es_Vendedor = 1" & vbCrLf &
                        "ORDER BY Hijo"

        Cmb_CodVendedor.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_CodVendedor.SelectedValue = ""


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_SolCredito_Ingreso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_SolCredito_Ingreso_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _Cerrar Then
            If MessageBoxEx.Show(Me, "¿Esta seguro de cerrar el formulario?", "Cerrar",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then

                Dim _Link As String = _Dir_Temp & "\" & _Nombre_Reporte
                If File.Exists(_Link) Then File.Delete(_Link)

                e.Cancel = True
            End If
        End If
    End Sub



    Function Fx_Grabar_Negocio(ByVal _Es_Stand_By As Boolean,
                               Optional ByVal _Nro_Negocio As String = "") As String

        Dim _Id_Negocio
        'Dim _Nro_Negocio = String.Empty

        Dim _CodEntidad = _TblEntidad.Rows(0).Item("KOEN")
        Dim _CodSucursal = _TblEntidad.Rows(0).Item("SUEN")
        Dim _NomEntidad = _TblEntidad.Rows(0).Item("NOKOEN")

        Dim _Empresa = _RowSucursal.Item("EMPRESA")
        Dim _Sucursal = _RowSucursal.Item("KOSU")
        Dim _NomSucursal = _RowSucursal.Item("NOKOSU")
        Dim _Estado = "PR"

        Dim _CodFuncionario, _NomFuncionario As String


        Dim _Stand_By = CInt(_Es_Stand_By) * -1
        Dim _Ult_Negocio

        Consulta_sql = String.Empty

        If String.IsNullOrEmpty(_Nro_Negocio) Then

            If _Es_Stand_By Then
                _Ult_Negocio = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Negocios_01_Enc", "MAX(Nro_Negocio)", "Stand_By = 1")
                'trae_dato(tb, cn1, "MAX(Nro_Negocio)", _Global_BaseBk & "Zw_Negocios_01_Enc", "Stand_By = 1")
                If String.IsNullOrEmpty(Trim(_Ult_Negocio)) Then
                    _Ult_Negocio = 1
                Else
                    _Ult_Negocio = Math.Round(Val(Mid(_Ult_Negocio, 2, 10)) + 1, 0)
                End If

                _Nro_Negocio = "S" & numero_(Val(_Ult_Negocio), 9)

            Else
                _Ult_Negocio = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Negocios_01_Enc", "MAX(Nro_Negocio)", "Stand_By = 0")
                'trae_dato(tb, cn1, "MAX(Nro_Negocio)", _Global_BaseBk & "Zw_Negocios_01_Enc", "Stand_By = 0")
                If String.IsNullOrEmpty(Trim(_Ult_Negocio)) Then
                    _Ult_Negocio = 1
                Else
                    _Ult_Negocio += 1
                End If
                _Nro_Negocio = numero_(Val(_Ult_Negocio), 10)
            End If

            _CodFuncionario = FUNCIONARIO
            _NomFuncionario = Nombre_funcionario_activo

        Else

            _CodFuncionario = Grilla_Encabezado.Rows(0).Cells("CodFuncionario").Value
            _NomFuncionario = Grilla_Encabezado.Rows(0).Cells("NomFuncionario").Value

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Negocios_01_Enc Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = 0" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Negocios_02_Det Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = 0" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Negocios_02_Fun Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = 0" & vbCrLf & vbCrLf


        End If


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        '-- Abrir conexión paralela
        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)
        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try

            '-- Empezar con la transaccion
            myTrans = cn2.BeginTransaction()


            '-- Grabar Encabezado
            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Negocios_01_Enc (Nro_Negocio,Stand_By,Estado,Tipo,NomTipo," &
                            "Fecha_Emision,CodEntidad,CodSucursal,NomEntidad,CodFuncionario,NomFuncionario," &
                            "Empresa,Sucursal,NomSucursal,Cadena_Conexion,Nom_Clas_Crediticia) Values " &
                            "('" & _Nro_Negocio & "'," & _Stand_By & ",'IN','" & _CodTipo_Negocio & "','" & _NomTipo_Negocio & "',GetDate()" &
                            ",'" & _CodEntidad & "','" & _CodSucursal & "','" & _NomEntidad & "','" & _CodFuncionario &
                            "','" & _NomFuncionario & "','" & _Empresa & "','" & _Sucursal & "','" & _NomSucursal &
                            "','" & _Cadena_ConexionSQL_Seleccionada & "','" & Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Text & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Dim Comando As SqlClient.SqlCommand
            Comando = New SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd As SqlClient.SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Id_Negocio = dfd("Identity")
            End While
            dfd.Close()

            Dim _Valor_UF = De_Num_a_Tx_01(Var_Valor_UF, False, 5)

            Dim _Linea_Credito_Int_Ac_Peso = De_Num_a_Tx_01(Var_Linea_Credito_Int_Ac_Peso, False, 5)
            Dim _Linea_Credito_Int_Ac_UF = De_Num_a_Tx_01(Var_Linea_Credito_Int_Ac_UF, False, 5)

            Dim _Linea_Credito_SC_Ac_UF = De_Num_a_Tx_01(Var_Linea_Credito_SC_Ac_UF, False, 5) ' linea de credito solicitada
            Dim _Cod_Clas_Crediticia_Ac_Seg_Credito = Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.SelectedValue

            Dim _Clasif_Riesgo_comercial = Txt_Clasif_Riesgo_comercial.Text
            Dim _Morosidades_y_protestos = Txt_Morosidades_y_protestos.Text
            Dim _Deuda_Actual = De_Num_a_Tx_01(Var_Deuda_Actual, False, 5)
            Dim _Deuda_Actual_UF = De_Num_a_Tx_01(Var_Deuda_Actual_UF, False, 5)

            Dim _Prorroga_Negociacion_Vigente = De_Num_a_Tx_01(Var_Prorroga_Negociacion_Vigente, False, 5)

            Dim _Monto_Prox_Vencimiento = De_Num_a_Tx_01(Var_Monto_Prox_Vencimiento, False, 5)
            If Not CBool(Var_Monto_Prox_Vencimiento) Then Dtp_Fecha_Prox_Vencimiento.Value = FechaDelServidor()
            Dim _Fecha_Prox_Vencimiento = Format(Dtp_Fecha_Prox_Vencimiento.Value, "yyyyMMdd")

            Dim _Monto_Venta_Civa = De_Num_a_Tx_01(Var_Monto_Venta_Civa, False, 5)
            Dim _Monto_Venta_Civa_UF = De_Num_a_Tx_01(Var_Monto_Venta_Civa_UF, False, 5)

            Dim _Plazo_Venta_Dias = De_Num_a_Tx_01(Var_Plazo_Venta_Dias, False, 5)

            Dim _CodVendedor = Cmb_CodVendedor.SelectedValue
            Dim _NomVendedor = Cmb_CodVendedor.Text

            Dim _Producto = Txt_Producto.Text
            Dim _Precio = Txt_Precio.Text
            Dim _Rentabilidad = Txt_Rentabilidad.Text

            Dim _Dias_libres = CInt(Val(Txt_Dias_libres.Text))
            Dim _Taza_de_interes = Txt_Taza_de_interes.Text

            Dim _Doc_Venta_SI = CInt(Rdb_Doc_Venta_SI.Checked) * -1
            Dim _Cod_Doc_Venta_SI = Cmb_Cod_Doc_Venta_SI.SelectedValue
            Dim _Doc_Venta_NO = CInt(Rdb_Doc_Venta_NO.Checked) * -1

            Dim _Ficha_Int_Cli_Completa = CInt(Rdb_Ficha_Int_Cli_Completa.Checked) * -1
            Dim _Ficha_Int_Cli_Parcial = CInt(Rdb_Ficha_Int_Cli_Parcial.Checked) * -1
            Dim _Ficha_Int_Cli_SinAntecedentes = CInt(Rdb_Ficha_Int_Cli_SinAntecedentes.Checked) * -1

            Dim _Direcctorio_Archivos_Adjuntos = _Directorio_Negocios '& "\" & _Nro_Negocio
            If _Stand_By Then _Direcctorio_Archivos_Adjuntos = String.Empty

            Dim _Score_Crediticio = Txt_Score_Crediticio.Text
            Dim _Margen = De_Num_a_Tx_01(Num_Margen.Value, False, 5)

            Dim _Valores_Linea_Credito_Desde_Aseguradora = CInt(Rdb_Valores_Linea_Credito_Desde_Aseguradora.Checked) * -1
            Dim _Valores_Linea_Credito_Desde_Random = CInt(Rdb_Valores_Linea_Credito_Desde_Random.Checked) * -1

            '-- Grabar Detalle
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Negocios_02_Det (Nro_Negocio,Stand_By,Valor_UF,Linea_Credito_SC_Ac_UF,Linea_Credito_Int_Ac_Peso,Linea_Credito_Int_Ac_UF," &
                           "Cod_Clas_Crediticia_Ac_Seg_Credito,Clasif_Riesgo_comercial, Morosidades_y_protestos,Deuda_Actual,Deuda_Actual_UF,Fecha_Prox_Vencimiento,Direcctorio_Archivos_Adjuntos," &
                           "Prorroga_Negociacion_Vigente,Monto_Prox_Vencimiento,Monto_Venta_Civa,Monto_Venta_Civa_UF,Plazo_Venta_Dias,CodVendedor, NomVendedor,Producto,Precio,Rentabilidad,Dias_libres, Taza_de_interes," &
                           "Doc_Venta_SI, Cod_Doc_Venta_SI,Doc_Venta_NO,Ficha_Int_Cli_Completa,Ficha_Int_Cli_Parcial,Ficha_Int_Cli_SinAntecedentes,Observaciones," &
                           "Observaciones_Jefe,Obs_Proximos_Vencimientos_CxC,Score_Crediticio," &
                           "Margen,Valores_Linea_Credito_Desde_Aseguradora,Valores_Linea_Credito_Desde_Random) Values " &
                           "('" & _Nro_Negocio & "'," & _Stand_By & "," & _Valor_UF & "," & _Linea_Credito_SC_Ac_UF & "," & _Linea_Credito_Int_Ac_Peso &
                           "," & _Linea_Credito_Int_Ac_UF & ",'" & _Cod_Clas_Crediticia_Ac_Seg_Credito & "','" & _Clasif_Riesgo_comercial & "','" & _Morosidades_y_protestos & "'," & _Deuda_Actual &
                           "," & _Deuda_Actual_UF & ",'" & _Fecha_Prox_Vencimiento & "','" & _Direcctorio_Archivos_Adjuntos & "'," & _Prorroga_Negociacion_Vigente &
                           "," & _Monto_Prox_Vencimiento & "," & _Monto_Venta_Civa & "," & _Monto_Venta_Civa_UF & "," & _Plazo_Venta_Dias &
                           ",'" & _CodVendedor & "','" & _NomVendedor & "','" & _Producto & "','" & _Precio & "','" & _Rentabilidad & "'," & _Dias_libres & ",'" & _Taza_de_interes & "'," & _Doc_Venta_SI &
                           ",'" & _Cod_Doc_Venta_SI & "'," & _Doc_Venta_NO &
                           "," & _Ficha_Int_Cli_Completa & "," & _Ficha_Int_Cli_Parcial & "," &
                           _Ficha_Int_Cli_SinAntecedentes & ",'" & _Observaciones & "','" & _Observaciones_Jefe &
                           "','" & _Observaciones_Proximos_Vencimientos_CxC & "','" & _Score_Crediticio &
                           "'," & _Margen & "," & _Valores_Linea_Credito_Desde_Aseguradora & "," & _Valores_Linea_Credito_Desde_Random & ")"

            'Obs_Proximos_Vencimientos_CxC = '" & _Observaciones_Proximos_Vencimientos_CxC

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            If CBool(_TblParticipantes.Rows.Count) Then

                Dim _Filtro = Generar_Filtro_IN(_TblParticipantes, "Chk", "Codigo", False, True, "'")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Negocios_02_Fun (Nro_Negocio,Stand_By,CodFuncionario,NomFuncionario,Email) " &
                               "Select '" & _Nro_Negocio & "'," & CInt(_Stand_By) * -1 & ",CodFuncionario,NomFuncionario,Email From " & _Global_BaseBk & "Zw_Usuarios Where CodFuncionario in " & _Filtro

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
            End If

            'Validar transaccion
            myTrans.Commit()

            'Cerrar conexión
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            Return _Nro_Negocio

        Catch ex As Exception


            'Error
            My.Computer.FileSystem.WriteAllText("ArchivoSalida", ex.Message & vbCrLf & ex.StackTrace, False)
            MessageBoxEx.Show(ex.Message, "Error",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            Return String.Empty

        End Try

    End Function

    Private Sub Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Private Sub Txt_KeyPress_Enter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Private Sub Btn_Grabar_Negocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar_Negocio.Click


        If Not CBool(Var_Linea_Credito_SC_Ac_UF) Then
            MessageBoxEx.Show(Me, "FALTA: " & UCase("Línea de Crédito solicitada en UF"), "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Linea_Credito_SC_Ac_UF.Focus()
            Return
        End If

        If Not Fx_Validar_Dato("TIPO DE NEGOCIO",
                               Cmb_Tipo, Cmb_Tipo.Text) Then Return

        If Not Fx_Validar_Dato("Clasificación Créditicia Actual en Seg. de Crédito",
                         Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito, Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.SelectedValue) Then Return

        'If Not Fx_Validar_Dato("Línea de Crédito interna actual en $", _
        '                       Txt_Linea_Credito_Int_Ac_Peso, Txt_Linea_Credito_Int_Ac_Peso.Text) Then Return


        If Not Fx_Validar_Dato("Deuda actual",
                               Txt_Deuda_Actual, Txt_Deuda_Actual.Text) Then Return

        If Not Fx_Validar_Dato("Prórrogas o Renegociados Vigentes $:",
                               Txt_Prorroga_Negociacion_Vigente, Txt_Prorroga_Negociacion_Vigente.Text) Then Return

        'If Not Fx_Validar_Dato("Próximos vencimientos", _
        '                       Btn_Informacion_Proximos_Vencimientos, _
        '                       _Observaciones_Proximos_Vencimientos_CxC) Then Return

        'If Not Fx_Validar_Dato("Monto próximo vencimiento $:", _
        '                       Txt_Monto_Prox_Vencimiento, Txt_Monto_Prox_Vencimiento.Text) Then Return

        If Not Fx_Validar_Dato("Monto de la Venta (C/Iva) $:",
                               Txt_Monto_Venta_Civa, Txt_Monto_Venta_Civa.Text) Then Return

        If Not Fx_Validar_Dato("Plazo de Venta (días):",
                               Txt_Plazo_Venta_Dias, Txt_Plazo_Venta_Dias.Text) Then Return


        If Not Fx_Validar_Dato("Producto",
                               Txt_Producto, Txt_Producto.Text) Then Return

        If Not Fx_Validar_Dato("Precio",
                               Txt_Precio, Txt_Precio.Text) Then Return

        If Not CBool(Num_Margen.Value) Then
            MessageBoxEx.Show(Me, "FALTA: MARGEN", "Validación",
                         MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        'If Not Fx_Validar_Dato("Rentabilidad", _
        '                       Txt_Rentabilidad, Txt_Rentabilidad.Text) Then Return

        If Not Fx_Validar_Dato("VENDEDOR",
                               Cmb_CodVendedor, Cmb_CodVendedor.Text) Then Return


        If Not Rdb_Doc_Venta_SI.Checked And Not Rdb_Doc_Venta_NO.Checked Then
            MessageBoxEx.Show(Me, "Falta indicar si documenta venta", "Participantes",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Rdb_Doc_Venta_SI.Focus()
            Return
        End If

        If Rdb_Doc_Venta_SI.Checked Then
            If Not Fx_Validar_Dato("Tipo de docuemto para documentar venta",
                               Cmb_Cod_Doc_Venta_SI, Cmb_Cod_Doc_Venta_SI.SelectedValue) Then Return
        End If


        If Not Rdb_Ficha_Int_Cli_Completa.Checked And
           Not Rdb_Ficha_Int_Cli_SinAntecedentes.Checked And
           Not Rdb_Ficha_Int_Cli_Parcial.Checked Then

            'Beep()
            'ToastNotification.Show(Me, "FALTA: Ficha interna del cliente: " & vbCrLf & _
            '                       "COMPLETA, PARCIAL O INCOMPLETA", _
            '                       My.Resources.cross, _
            '                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            MessageBoxEx.Show(Me, "FALTA: Ficha interna del cliente: " & vbCrLf &
                              "COMPLETA, PARCIAL O INCOMPLETA", "Participantes",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If


        If _TblParticipantes.Rows.Count = 0 Then
            MessageBoxEx.Show(Me, "Falta que ingresar participantes", "Participantes",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Ingresar_participantes()
            If _TblParticipantes.Rows.Count = 0 Then Return
        End If

        If Not _Editar_Negocio Then
            Sb_Grabar_Nuevo_Negocio()
        Else
            _Estado_Dc = String.Empty
            Sb_Editar_Negocio()
        End If

    End Sub


    Sub Sb_Grabar_Nuevo_Negocio()

        _CodTipo_Negocio = Cmb_Tipo.SelectedValue
        _NomTipo_Negocio = Cmb_Tipo.Text


        Dim _NroNegocio = Fx_Grabar_Negocio(False)

        Dim Fm_e As New Frm_BuscarEntidad_Mt(False)

        If Not String.IsNullOrEmpty(_NroNegocio) Then


            Dim info As New TaskDialogInfo("Creación de negocio",
                         eTaskDialogIcon.CheckMark2,
                         "Nro de negocio: " & _NroNegocio,
                         vbCrLf & "A continuación se enviara un correo de información a cada uno de los participantes anunciando el inicio de la gestión",
                         eTaskDialogButton.Ok _
                         , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Imagenes_16_16.Images.Item(0))

            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            _TipoDocumento = _TipoDos.VerDocumento
            _Stand_By = False


            Dim _Ruta As String = _Dir_Temp & "\Observacion_Rtf.rtf"

            _Observaciones_Rtf.SaveFile(_Ruta)
            Dim Fm As New Frm_SolCredito_File_Attach(_NroNegocio)
            Fm.Fx_Grabar_Observacion_Adjunta(_NroNegocio, _Ruta, "Observacion_Rtf.rtf",
                                             Frm_SolCredito_File_Attach.Tipo_Obs.OBS_VENCIMIENTO)
            Fm.Dispose()
            File.Delete(_Dir_Temp & "\Observacion_Rtf.rtf")

            If MessageBoxEx.Show(Me, "¿Desea ingresar alguna observación adicional al negocio?", "Observaciones",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Sb_Observaciones(_NroNegocio)
            End If


            If MessageBoxEx.Show(Me, "¿Desea adjuntar documentos al negocio?", "Adjuntar documentos",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Sb_Ver_Archivos_Adjuntos(_NroNegocio)
                'Sb_Ver_Carpeta_Negocio(_NroNegocio)
            End If

            ' ENVIAR CORREO A LOS PARTICIPANTES DEL NEGOCIO + EL VENDEDOR

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & Trim(_Id_Correo_Al_Grabar)
            Dim _TblCorreo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_TblCorreo.Rows.Count) Then

                Dim _Envio_Automatico As Boolean = _TblCorreo.Rows(0).Item("Envio_Automatico")

                Dim _CodVendedor As String = Cmb_CodVendedor.SelectedValue

                Sb_Abrir_Documento(_NroNegocio, False)

                Consulta_sql = "Select CodFuncionario,NomFuncionario,Enviar_copia_al_cierre From " & _Global_BaseBk & "Zw_Negocios_02_Fun " &
                               "Where Nro_Negocio = '" & _NroNegocio & "' And Stand_By = 0 And CodFuncionario <> '" & _CodVendedor & "'"

                _TblParticipantes = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

                If _Envio_Automatico Then
                    Sb_Enviar_Correo_De_Aviso_Participantes(_TblCorreo.Rows(0), _TblParticipantes, Correo_cerrar_grabar.Grabar)
                Else

                    Sb_Abrir_Documento(_NroNegocio, False)

                    Dim _Html As String = Fx_HTML_Apertura_Negocio()
                    Sb_Enviar_Correo_Manual(_TblCorreo.Rows(0), _Html, "Apertura de negocio Nro: " & _NroNegocio)
                End If

            End If


            _Cerrar = True
            Me.Close()

        End If


    End Sub

    Sub Sb_Editar_Negocio()

        Fx_Grabar_Negocio(False, _NroNegocio)

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Beep()
        'ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", _
        '                       My.Resources.ok_button, _
        '                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        '_Cerrar = True
        'Me.Close()
        _Editar_Negocio = False
        Sb_Abrir_Documento(_NroNegocio, False)

    End Sub


    Enum Correo_cerrar_grabar
        Grabar
        Cerrar
    End Enum

    Sub Sb_Enviar_Correo_De_Aviso_Participantes(ByVal _RowCorreo As DataRow,
                                                ByVal _TblPara As DataTable,
                                                ByVal _Accion As Correo_cerrar_grabar)

        _Correos_Enviados = 0
        _Correos_Rechazados = 0

        Try
            Me.Enabled = False

            'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & Trim(_Id_Correo)
            'Dim _TblCorreo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Remitente = _RowCorreo.Item("Remitente")
            Dim _CC = _RowCorreo.Item("CC")
            Dim _Host = _RowCorreo.Item("Host")
            Dim _Puerto = _RowCorreo.Item("Puerto")
            Dim _Contrasena = _RowCorreo.Item("Contrasena")
            Dim _Asunto = _RowCorreo.Item("Asunto")
            Dim _CuerpoMensaje = _RowCorreo.Item("CuerpoMensaje")
            Dim _SSL = _RowCorreo.Item("SSL")

            '_Para = "jalfaro@bakapp.cl"
            '_CC = "jalfaro@luferco.cl"

            '_CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Cuerpo_Html & vbCrLf)

            Dim EnviarCorreo As New Frm_Correos_Conf

            Btn_Grabar_Negocio.Visible = False
            Btn_Grabar_Stand_By.Visible = False
            Btn_Carpeta_negocio.Visible = False
            Btn_Participantes.Visible = False
            Btn_Observaciones_Jefe.Visible = False
            Btn_Anular_Documento.Visible = False
            Btn_Gestion_Comite.Visible = False
            Btn_Cerrar_documento.Visible = False
            Btn_Imprimir.Visible = False

            Progreso_correo.Visible = True
            Lbl_Envio_correo.Visible = True
            Progreso_correo.Maximum = _TblPara.Rows.Count

            Dim _ObsGerencia As String = Fx_HTML_Observaciones_Gerencia()

            For Each _Asistente As DataRow In _TblPara.Rows
                System.Windows.Forms.Application.DoEvents()
                Dim _Enviar As Boolean

                Dim _CodFuncionario = _Asistente.Item("CodFuncionario")
                Dim _NomFuncionario = _Asistente.Item("NomFuncionario")
                Dim _Enviar_copia_al_cierre As Boolean = _Asistente.Item("Enviar_copia_al_cierre")

                Dim _Para = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Usuarios", "Email", "CodFuncionario = '" & _CodFuncionario & "'")


                Dim _Html As String

                If _Accion = Correo_cerrar_grabar.Grabar Then
                    _Html = Fx_HTML_Apertura_Negocio()
                    _Enviar = True
                ElseIf _Accion = Correo_cerrar_grabar.Cerrar Then
                    _Html = Fx_HTML_Cierre_Negocio(_ObsGerencia)
                    _Enviar = _Enviar_copia_al_cierre
                End If

                _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Html)

                If _Enviar Then

                    Lbl_Envio_correo.Text = "Enviando correo informativo a: " & _NomFuncionario

                    If EnviarCorreo.Fx_Enviar_Mail(_Host, _Remitente, _Contrasena, _Para, _CC, _Asunto, _CuerpoMensaje, Nothing,
                                                   _Puerto, _SSL, False) Then

                        Consulta_sql = "Insert into " & _Global_BaseBk & "Zw_CorreosEnvioRecepcion (Remitente,Para,CC,Fecha, " &
                                       "Hora,Idmaeedo,Estado,Asunto,Mensaje) values " & vbCrLf &
                                       "('" & _Remitente & "','" & _Para & "','" & _CC & "',Getdate(),Getdate(),'','E'" &
                                       ",'" & _Asunto & "','Aviso: [" & _NroNegocio & "], Funcionario: " & _NomFuncionario & "')"
                        _Correos_Enviados += 1
                        Lbl_Envio_correo.Text = "Enviando correo informativo a: " & _NomFuncionario & " - ENVIADO"

                    Else

                        Consulta_sql = "Insert into " & _Global_BaseBk & "Zw_CorreosEnvioRecepcion (Remitente,Para,CC,Fecha," &
                                       "Hora,Idmaeedo,Estado,Asunto,Mensaje) values " & vbCrLf &
                                       "('" & _Remitente & "','" & _Para & "','" & _CC & "',Getdate(),Getdate(),'','R'" &
                                       ",'" & _Asunto & "','" & Replace(EnviarCorreo.Pro_Error, "'", "´") & "')"
                        _Correos_Rechazados += 1
                        Lbl_Envio_correo.Text = "Enviando correo informativo a: " & _NomFuncionario & " - ERROR"

                    End If

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Progreso_correo.Value += 1

            Next

            Progreso_correo.Value = 0

            MessageBoxEx.Show(Me, "Correos enviados: " & _Correos_Enviados & vbCrLf &
                              "Correos no enviados: " & _Correos_Rechazados, "Envío de correos",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Progreso_correo.Visible = False
            Lbl_Envio_correo.Visible = False
            Me.Enabled = True
            Me.Refresh()
        End Try
    End Sub

    Sub Sb_Enviar_Correo_Manual(ByVal _RowCorreo As DataRow,
                                ByVal _Cuerpo_Html As String,
                                ByVal _Asunto As String)

        Dim _Remitente = _RowCorreo.Item("Remitente")
        Dim _CC = _RowCorreo.Item("CC")
        Dim _Host = _RowCorreo.Item("Host")
        Dim _Puerto = _RowCorreo.Item("Puerto")
        Dim _Contrasena = _RowCorreo.Item("Contrasena")

        '_Asunto = _RowCorreo.Item("Asunto") '& " (" & Trim(_Razon_Social) & ")"

        Dim _CuerpoMensaje = _RowCorreo.Item("CuerpoMensaje")

        If String.IsNullOrEmpty(Trim(_CuerpoMensaje)) Then
            _CuerpoMensaje = "<HTML>"
        End If

        Dim _SSL = _RowCorreo.Item("SSL")
        Dim _Es_Html = _RowCorreo.Item("Es_Html")

        'Dim _Adjunto As String = _Ruta & "\Informe_cobranza.Html"
        'Dim _Cuerpo_Html = LeeArchivo(_Adjunto)

        _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Cuerpo_Html)

        Dim Envio_Occ_Mail As New Class_Outlook
        Dim _Para As String = String.Empty '"jalfaro@bakapp.cl"
        Dim _Cuerpo As String = _CuerpoMensaje

        Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, Nothing, _Asunto, _Cuerpo, _Es_Html)

    End Sub


    Function Fx_Validar_Dato(ByVal _Texto As String,
                             ByVal _Objeto As Object,
                             ByVal _Valor As String)

        If String.IsNullOrEmpty(_Valor) Then
            'Beep()
            'ToastNotification.Show(Me, "FALTA: " & _Texto, _
            '                       My.Resources.cross, _
            '                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            MessageBoxEx.Show(Me, "FALTA: " & UCase(_Texto), "Validación",
                         MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Objeto.Focus()
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub Txt_Linea_Credito_SC_Ac_UF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea_Credito_SC_Ac_UF.Enter
        'Btn_Grabar_Negocio.Enabled = False
        If CBool(Var_Linea_Credito_SC_Ac_UF) Then
            Txt_Linea_Credito_SC_Ac_UF.Text = Var_Linea_Credito_SC_Ac_UF
        Else
            Txt_Linea_Credito_SC_Ac_UF.Text = String.Empty
        End If

    End Sub

    Private Sub Txt_Linea_Credito_SC_Ac_UF_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea_Credito_SC_Ac_UF.Validated
        Var_Linea_Credito_SC_Ac_UF = Val(Txt_Linea_Credito_SC_Ac_UF.Text)
        Txt_Linea_Credito_SC_Ac_UF.Text = "UF " & FormatNumber(Var_Linea_Credito_SC_Ac_UF, 2)
        Btn_Grabar_Negocio.Enabled = True
    End Sub

    'Private Sub Txt_Linea_Credito_Int_Ac_Peso_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Txt_Linea_Credito_Int_Ac_Peso.Text = Var_Linea_Credito_Int_Ac_Peso
    'End Sub

    ' Private Sub Txt_Linea_Credito_Int_Ac_Peso_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea_Credito_Int_Ac_Peso.Validated

    'Input UF = Input peso * Uf del día 
    'Input Peso = Input Uf / Uf del día
    '    Var_Linea_Credito_Int_Ac_Peso = Txt_Linea_Credito_Int_Ac_Peso.Text
    '    Txt_Linea_Credito_Int_Ac_Peso.Text = FormatNumber(Var_Linea_Credito_Int_Ac_Peso, 0)

    '    Var_Linea_Credito_Int_Ac_UF = Fx_Convert_UF2Peso(Var_Linea_Credito_Int_Ac_Peso, Var_Valor_UF, True)
    '    Txt_Linea_Credito_Int_Ac_UF.Text = FormatNumber(Var_Linea_Credito_Int_Ac_UF, 2)

    'End Sub

    Function Fx_Convert_UF2Peso(ByVal _Valor As Double,
                                    ByVal _Uf As Double,
                                    ByVal _Convertir_En_UF As Boolean) As Double
        Dim _Total As Double = _Valor

        If CBool(_Valor) Then
            If _Convertir_En_UF Then
                _Total = Math.Round(_Valor / _Uf, 5)
            Else ' Convertir a Peso
                _Total = Math.Round(_Valor * _Uf, 2)
            End If
        End If

        Return _Total

    End Function

    'Private Sub Txt_Linea_Credito_Int_Ac_UF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Txt_Linea_Credito_Int_Ac_UF.Text = Var_Linea_Credito_Int_Ac_UF
    'End Sub

    'Private Sub Txt_Linea_Credito_Int_Ac_UF_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea_Credito_Int_Ac_UF.Validated
    'Var_Linea_Credito_Int_Ac_UF = Txt_Linea_Credito_Int_Ac_UF.Text
    'Txt_Linea_Credito_Int_Ac_UF.Text = FormatNumber(Var_Linea_Credito_Int_Ac_UF, 2)

    'Var_Linea_Credito_Int_Ac_Peso = Fx_Convert_UF2Peso(Var_Linea_Credito_Int_Ac_UF, Var_Valor_UF, False)
    'Txt_Linea_Credito_Int_Ac_Peso.Text = FormatNumber(Var_Linea_Credito_Int_Ac_Peso, 0)

    'End Sub

    Private Sub Txt_Deuda_Actual_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Deuda_Actual.Enter

        If CBool(Var_Deuda_Actual) Then
            Txt_Deuda_Actual.Text = Var_Deuda_Actual
        Else
            Txt_Deuda_Actual.Text = String.Empty
        End If

    End Sub

    Private Sub Txt_Deuda_Actual_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Deuda_Actual.Validated
        Var_Deuda_Actual = Val(Txt_Deuda_Actual.Text)
        Var_Deuda_Actual_UF = Fx_Convert_UF2Peso(Var_Deuda_Actual, Var_Valor_UF, True)
        Lbl_Deuda_Actual_UF.Text = "UF " & FormatNumber(Math.Round(Var_Deuda_Actual_UF), 0)
        Txt_Deuda_Actual.Text = FormatCurrency(Var_Deuda_Actual, 0)
    End Sub

    Private Sub Txt_Prorroga_Negociacion_Vigente_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Prorroga_Negociacion_Vigente.Enter

        If CBool(Var_Prorroga_Negociacion_Vigente) Then
            Txt_Prorroga_Negociacion_Vigente.Text = Var_Prorroga_Negociacion_Vigente
        Else
            Txt_Prorroga_Negociacion_Vigente.Text = String.Empty
        End If

    End Sub

    Private Sub Txt_Prorroga_Negociacion_Vigente_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Prorroga_Negociacion_Vigente.Validated
        Var_Prorroga_Negociacion_Vigente = Val(Txt_Prorroga_Negociacion_Vigente.Text)
        Txt_Prorroga_Negociacion_Vigente.Text = FormatCurrency(Var_Prorroga_Negociacion_Vigente, 0)
    End Sub

    Private Sub Txt_Monto_Prox_Vencimiento_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Monto_Prox_Vencimiento.Enter
        CType(sender, TextBox).SelectAll()
        Txt_Monto_Prox_Vencimiento.Text = Var_Monto_Prox_Vencimiento
    End Sub

    Private Sub Txt_Monto_Prox_Vencimiento_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Monto_Prox_Vencimiento.Validated

        Var_Monto_Prox_Vencimiento = Txt_Monto_Prox_Vencimiento.Text
        Txt_Monto_Prox_Vencimiento.Text = FormatCurrency(Var_Monto_Prox_Vencimiento, 0)
        Dim _VF = CBool(Var_Monto_Prox_Vencimiento)
        Lbl_Fecha_Prox_Vencimiento.Enabled = _VF
        Dtp_Fecha_Prox_Vencimiento.Enabled = _VF

    End Sub

    Private Sub Txt_Monto_Venta_Civa_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Monto_Venta_Civa.Enter
        Btn_Grabar_Negocio.Enabled = False
        If CBool(Var_Monto_Venta_Civa) Then
            Txt_Monto_Venta_Civa.Text = Var_Monto_Venta_Civa
        Else
            Txt_Monto_Venta_Civa.Text = String.Empty
        End If

    End Sub

    Private Sub Txt_Monto_Venta_Civa_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Monto_Venta_Civa.Validated

        Var_Monto_Venta_Civa = Val(Txt_Monto_Venta_Civa.Text)
        Var_Monto_Venta_Civa_UF = Fx_Convert_UF2Peso(Var_Monto_Venta_Civa, Var_Valor_UF, True)

        Dim _Uf = Var_Monto_Venta_Civa_UF

        Lbl_Monto_Venta_Civa_UF.Text = "UF " & FormatNumber(Math.Round(Var_Monto_Venta_Civa_UF), 0)
        Txt_Monto_Venta_Civa.Text = FormatCurrency(Var_Monto_Venta_Civa, 0)
        Btn_Grabar_Negocio.Enabled = True

    End Sub

    Private Sub Txt_Plazo_Venta_Dias_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Plazo_Venta_Dias.Enter

        If CBool(Var_Plazo_Venta_Dias) Then
            Txt_Plazo_Venta_Dias.Text = Var_Plazo_Venta_Dias
        Else
            Txt_Plazo_Venta_Dias.Text = String.Empty
        End If

    End Sub

    Private Sub Txt_Plazo_Venta_Dias_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Plazo_Venta_Dias.Validated
        Var_Plazo_Venta_Dias = Val(Txt_Plazo_Venta_Dias.Text)
        Txt_Plazo_Venta_Dias.Text = FormatNumber(Var_Plazo_Venta_Dias, 0)
    End Sub

    Private Sub Btn_Observaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Observaciones_Jefe.Click

        If _CodFuncionario_SCN <> FUNCIONARIO Then
            If Not Fx_Tiene_Permiso(Me, "Scn00012") Then Return
        End If

        Sb_Observaciones_Jefe()

    End Sub

    Sub Sb_Observaciones_Proximos_Vencimientos_CxC()

        Dim Fm As New Frm_SolCredito_Observaciones
        Fm.Text = "Observaciones próximos vencimientos"
        Fm.Txt_Observaciones.Text = _Observaciones_Proximos_Vencimientos_CxC

        _Estado_Dc = NuloPorNro(_Estado_Dc, "")

        If Not String.IsNullOrEmpty(_Estado_Dc) Then
            If _Estado_Dc <> "IN" And _Estado_Dc <> "AN" And _Estado_Dc <> "CO" And _Estado_Dc <> "ST" Then

                Fm.Btn_Grabar.Visible = False
                Fm.Txt_Observaciones.ReadOnly = True
                If _Estado_Doc = _Estado.Cerrado Then Fm.Btn_Observaciones_Cierre.Visible = True
                Fm.Pro_Cierre_Observaciones = _TblDetalle.Rows(0).Item("Cierre_Observaciones")

            End If
        End If

        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            _Observaciones_Proximos_Vencimientos_CxC = Fm.Txt_Observaciones.Text

            If _TipoDocumento = _TipoDos.VerDocumento Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_02_Det Set Obs_Proximos_Vencimientos_CxC = '" & _Observaciones_Proximos_Vencimientos_CxC & "'" & vbCrLf &
                               "Where Nro_Negocio = '" & _NroNegocio & "' And Stand_By = " & CInt(_Stand_By) * -1

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Beep()
                    ToastNotification.Show(Me, "OBSERVACIONES ACTUALIZADAS CORRECTAMENTE", My.Resources.ok_button,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    'MessageBoxEx.Show(Me, "El negocio pasara a evaluación por parte del comité", "Observaciones", _
                    '                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '_Cerrar = True
                    'Me.Close()

                End If
            End If

        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Observaciones(ByVal __NroNegocio As String)

        Dim Fm As New Frm_SolCredito_Observaciones
        Fm.Text = "Observaciones generales"
        Fm.Txt_Observaciones.Text = _Observaciones

        _Estado_Dc = NuloPorNro(_Estado_Dc, "")

        If Not String.IsNullOrEmpty(_Estado_Dc) Then

            If _Estado_Dc <> "IN" And _Estado_Dc <> "CO" And _Estado_Dc <> "ST" Then  ' And _Estado_Dc <> "AN" 

                Fm.Btn_Grabar.Visible = False
                Fm.Txt_Observaciones.ReadOnly = True
                If _Estado_Doc = _Estado.Cerrado Then Fm.Btn_Observaciones_Cierre.Visible = True
                Fm.Pro_Cierre_Observaciones = _TblDetalle.Rows(0).Item("Cierre_Observaciones")

            End If

        End If

        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            _Observaciones = Fm.Txt_Observaciones.Text

            If _TipoDocumento = _TipoDos.VerDocumento Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_02_Det Set Observaciones = '" & _Observaciones & "'" & vbCrLf &
                               "Where Nro_Negocio = '" & __NroNegocio & "' And Stand_By = " & CInt(_Stand_By) * -1

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Beep()
                    ToastNotification.Show(Me, "OBSERVACIONES ACTUALIZADAS CORRECTAMENTE", My.Resources.ok_button,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    'MessageBoxEx.Show(Me, "El negocio pasara a evaluación por parte del comité", "Observaciones", _
                    '                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '_Cerrar = True
                    'Me.Close()

                End If
            End If

        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Observaciones_Jefe()

        Dim Fm As New Frm_SolCredito_Observaciones
        'Fm.Txt_Observaciones_Old.Rtf = _Observaciones.Rtf
        Fm.Txt_Observaciones.Text = _Observaciones_Jefe
        Fm.Pro_Graba_Jefe = True

        If _Estado_Dc <> "IN" Then 'And _Estado_Dc <> "AN" Then

            Fm.Btn_Grabar.Visible = False
            Fm.Txt_Observaciones.ReadOnly = True
            If _Estado_Doc = _Estado.Cerrado Then Fm.Btn_Observaciones_Cierre.Visible = True
            Fm.Pro_Cierre_Observaciones = _TblDetalle.Rows(0).Item("Cierre_Observaciones")

        End If

        Fm.Btn_Grabar.Text = "Grabar observaciones y envía a ANALISIS (Comité)"

        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            'If Not Directory.Exists(_Dir_Temp) Then
            'System.IO.Directory.CreateDirectory(_Dir_Temp)
            'End If

            _Observaciones_Jefe = Fm.Txt_Observaciones.Text

            If _TipoDocumento = _TipoDos.VerDocumento Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'AN',Visado_Jefe = 1" & vbCrLf &
                               "Where Nro_Negocio = '" & _NroNegocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Negocios_02_Det Set Observaciones_Jefe = '" & _Observaciones_Jefe & "'" & vbCrLf &
                               "Where Nro_Negocio = '" & _NroNegocio & "' And Stand_By = " & CInt(_Stand_By) * -1

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    'Beep()
                    'ToastNotification.Show(Me, "OBSERVACIONES ACTUALIZADAS CORRECTAMENTE", My.Resources.ok_button, _
                    '                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    MessageBoxEx.Show(Me, "El negocio pasara a evaluación por parte del comité", "Observaciones",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Cerrar = True
                    Me.Close()

                End If
            End If

        End If

        Fm.Dispose()

    End Sub

    Private Sub Rdb_Doc_Venta_NO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Doc_Venta_NO.CheckedChanged
        If Rdb_Doc_Venta_NO.Checked Then
            Cmb_Cod_Doc_Venta_SI.SelectedValue = ""
            Cmb_Cod_Doc_Venta_SI.Enabled = False
        End If
    End Sub

    Private Sub Txt_Valor_Cero_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not CBool(Val(sender.TEXT)) Then
            If MessageBoxEx.Show(Me, "¿Confirma valor cero?", "Valor cero", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Txt_Plazo_Venta_Dias_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Plazo_Venta_Dias.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Btn_Grabar_Stand_By_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar_Stand_By.Click
        Dim _NroNegocio = Fx_Grabar_Negocio(True)

        If Not String.IsNullOrEmpty(_NroNegocio) Then
            MessageBoxEx.Show(Me, "El docuemnto esta en Stand-by, aun no ha sido enviado al comite de credito",
                              "Grabar Stand-By", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Cerrar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Participantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Participantes.Click
        Sb_Ingresar_participantes()
    End Sub

    Sub Sb_Ingresar_participantes()

        If _TipoDocumento = _TipoDos.Nuevo Or _Editar_Negocio Then

            Dim _Sql_Filtro_Condicion_Extra = "And CodFuncionario <> '" & FUNCIONARIO & "'"

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_TblParticipantes,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

                _TblParticipantes = _Filtrar.Pro_Tbl_Filtro

            End If

            'Dim _Fm As New Frm_Filtro_Tabla_Seleccion
            '_Fm.Pro_Tabla_Filtro = Frm_Filtro_Tabla_Seleccion._Select_Tabla._Funcionarios_BakApp
            '_Fm.Pro_TablaG2 = _TblParticipantes
            '_Fm.Grupo_Seleccion_Izquierda.Text = "FUNCIONARIOS DEL SISTEMA"
            '_Fm.Grupo_Seleccionados_Derecha.Text = "PARTICIPANTES SELECCIONADOS"
            '_Fm.Pro_Condicion_Adicional = "And CodFuncionario <> '" & FUNCIONARIO & "'"
            '_Fm.Text = "PARTICIPANTES"
            '_Fm.ShowDialog(Me)

            'If _Fm.Pro_Filtrar Then
            '_TblParticipantes = _Fm.Pro_TablaG2
            'End If
            '_Fm.Dispose()

        Else

            Dim Fm As New Frm_SolCredito_Participantes(_Cerrado)
            Fm.Pro_CodFuncionario_SCN = _CodFuncionario_SCN
            Fm.Pro_Nro_Negocio = _NroNegocio
            Fm.Pro_Stand_By = _Stand_By
            Fm.Text = "PARTICIPANTES"
            Fm.Btn_Agregar_Participantes.Enabled = False
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub


    Private Sub Rdb_Doc_Venta_SI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Doc_Venta_SI.CheckedChanged
        If Rdb_Doc_Venta_SI.Checked Then
            Cmb_Cod_Doc_Venta_SI.Enabled = True
        End If
    End Sub

    Private Sub Btn_Gestion_Comite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Gestion_Comite.Click

        Dim _Dejar_Ausente As Boolean

        If _Estado_Doc = _Estado.Completado Or _Estado_Doc = _Estado.Cerrado Then
            _Dejar_Ausente = True
        End If

        If Fx_Tiene_Permiso(Me, "Scn00010") Then
            Dim Fm As New Frm_SolCredito_Autorizar(_Dejar_Ausente, _Estado_Doc.ToString)
            Fm.Pro_Nro_Negocio = _NroNegocio
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                Fx_Completar_Negocio(_NroNegocio)
                _Cerrar = True
                MessageBoxEx.Show(Me, "Acción completada correctamente", "Gestión comite",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        End If

    End Sub


    Function Fx_Completar_Negocio(ByVal _NroNegocio As String)


        Dim _Nom_Clas_Crediticia As String = Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Text
        Dim _Autorizados, _Rechazados As Integer

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "'"
        Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) ''_Sql.Fx_Get_Tablas(Consulta_sql)


        If _TblAprobacion.Rows.Count > 2 Then Return True

        If CBool(_TblAprobacion.Rows.Count) Then

            For Each _Fila As DataRow In _TblAprobacion.Rows

                Dim _CodAprobacion = _Fila.Item("CodAprobacion")
                Dim _Autorizado = _Fila.Item("Autorizado")
                Dim _Tex_Autorizado

                If _Autorizado Then
                    _Tex_Autorizado = "AUTORIZADO"
                    _Autorizados += 1
                Else
                    _Tex_Autorizado = "RECHAZADO"
                    _Rechazados += 1
                End If

            Next


            If _Nom_Clas_Crediticia = "EXCLUIDO" Then
                If CBool(_Rechazados) Then

                    Consulta_sql = String.Empty
                    Dim _Ap = 4
                    Dim _Hasta As Integer

                    If _TblAprobacion.Rows.Count = 1 Then
                        _Hasta = 2
                    ElseIf _TblAprobacion.Rows.Count = 2 Then
                        _Hasta = 1
                    End If

                    For _i = 1 To _Hasta

                        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Negocios_03_Apr (Nro_Negocio,CodFuncionario," &
                                        "NombreAprueba,Fecha_Hora_Aprueba,Autorizado," &
                                        "CodAprobacion,NomAprobacion,Observaciones,Chk_01,Chk_02,Chk_03,Chk_04,Chk_05,CodAutoriza,NombreAutoriza) Values " &
                                        "('" & _NroNegocio & "','ZBK','BakApp Cierre Automatico',Getdate(),0,'0" & _Ap & "','BakApp Cierre Automatico'," &
                                        "'Negocio con cierre automatico',0,0,0,0,0,'ZBK','ZBK')" & vbCrLf & vbCrLf
                        _Ap += 1

                    Next

                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'PR' Where Nro_Negocio = '" & _NroNegocio & "'"

                    _Sql.Ej_consulta_IDU(Consulta_sql) 'Ej_consulta_IDU(Consulta_sql, cn1)

                End If
            Else

                If _Autorizados = 2 Or _Rechazados = 2 Then
                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Negocios_03_Apr (Nro_Negocio,CodFuncionario," &
                           "NombreAprueba,Fecha_Hora_Aprueba,Autorizado," &
                           "CodAprobacion,NomAprobacion,Observaciones,Chk_01,Chk_02,Chk_03,Chk_04,Chk_05,CodAutoriza,NombreAutoriza) Values " &
                           "('" & _NroNegocio & "','ZBK','BakApp Cierre Automatico',Getdate(),1,'04','BakApp Cierre Automatico'," &
                           "'Negocio con cierre automatico',0,0,0,0,0,'ZBK','ZBK')"

                    _Sql.Ej_consulta_IDU(Consulta_sql) ' Ej_consulta_IDU(Consulta_sql, cn1)
                End If

            End If
        End If

    End Function

    Private Sub Btn_Anular_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anular_Documento.Click

        If Fx_Tiene_Permiso(Me, "Scn00006") Then

            If MessageBoxEx.Show(Me, "¿Esta seguro de anular esta S.C.N.?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim _Aceptado As Boolean
                Dim _Motivo_Anula As String

                _Aceptado = InputBox_Bk(Me, "Escriba el motivo por el cual" & vbCrLf &
                                                          "Anula este documento", "Anular documento", _Motivo_Anula, True, _Tipo_Mayus_Minus.Mayusculas,
                                                          200, True, _Tipo_Imagen.Texto, False)

                If _Aceptado Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc" & vbCrLf &
                                                   "Set Estado = 'NL',Motivo_Anula = '" & _Motivo_Anula & "',Fecha_Cierre = GetDate()" & vbCrLf &
                                                   "Where Nro_Negocio = '" & _NroNegocio & "'"
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then 'Ej_consulta_IDU(Consulta_sql, cn1) Then
                        MessageBoxEx.Show(Me, "Negocio anulado correctamente", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _Cerrar = True
                        Me.Close()
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Carpeta_negocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Carpeta_negocio.Click
        Sb_Ver_Archivos_Adjuntos(_NroNegocio)
        'Sb_Ver_Carpeta_Negocio(_NroNegocio)
    End Sub

    Sub Sb_Ver_Archivos_Adjuntos(ByVal _NroNegocio As String)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "'"
        Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) ' _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _Bloqueada As Boolean

        _Bloqueada = CBool(_TblAprobacion.Rows.Count)

        If Fx_Tiene_Permiso(Me, "Scn00013") Then

            'Dim Fm As New Frm_SolCredito_File_Attach(_NroNegocio)
            Dim Fm As New Frm_SolCredito_Archivos_Adjuntos(_NroNegocio, _Bloqueada)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Sub Sb_Ver_Carpeta_Negocio(ByVal _NroNegocio As String)

        Dim _Dir = "ftp://" & _Ftp_Host & ":" & _Ftp_Puerto
        Dim _Carpeta = "SCN Negocios/" & _NroNegocio

        Dim _Ftp As New Class_FTP(_Dir, _Ftp_Usuario, _Ftp_Contrasena)

        If _Ftp.Fx_Verificar_Coneccion_FTP(Me, _Ftp_Host, _Ftp_Puerto) Then
            If Not _Ftp.Fx_Existe_Directorio(_Dir & "/" & _Carpeta) Then
                If Not String.IsNullOrEmpty(_Ftp.Fx_Crear_Directorio(_Dir & "/" & _Carpeta)) Then
                    MessageBoxEx.Show(Me, "Problemas con la carpeta del FTP", "Carpeta en FTP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If
        End If


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "'"
        Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) ' _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _Bloqueada As Boolean

        _Bloqueada = CBool(_TblAprobacion.Rows.Count)

        If Fx_Tiene_Permiso(Me, "Scn00013") Then

            Dim Fm As New Frm_FTP_Fichero

            Fm._Fichero = _Dir & "/" & _Carpeta
            Fm.Txt_Ftp_Host.Text = _Ftp_Host
            Fm.Txt_Ftp_Puerto.Text = _Ftp_Puerto
            Fm.Txt_Ftp_Usuario.Text = _Ftp_Usuario
            Fm.Txt_Ftp_Contrasena.Text = _Ftp_Contrasena
            Fm.Txt_Directorio_Seleccionado.Text = "...//" & _Carpeta

            Fm.Txt_Ftp_Host.Enabled = False
            Fm.Txt_Ftp_Puerto.Enabled = False
            Fm.Txt_Ftp_Usuario.Enabled = False
            Fm.Txt_Ftp_Contrasena.Enabled = False

            Dim _Cliente
            Dim _NomTipo

            Try
                _Cliente = _TblEntidad.Rows(0).Item("NOKOEN")
                _NomTipo = Me.Text 'Grilla_Encabezado.Rows(0).Cells("NomTipo").Value 'Trim(_TblEncabezado.Rows(0).Item("NomTipo"))

            Catch ex As Exception
                _Cliente = "" : _NomTipo = ""
            End Try

            Fm.Text = _Cliente & " - " & _NomTipo
            Fm.Btn_Eliminar_documento.Visible = True

            If _Bloqueada Then
                Fm.Btn_Eliminar_documento.Enabled = False
                Fm.Btn_Subir_Archivos.Enabled = False
                Fm.Btn_Eliminar_documento.Visible = False
                Fm.Btn_Renombrar.Visible = False
            End If

            ' Fm._Archivo_No_Se_Puede_Borrar = "Observaciones.rtf"
            Fm._Abrir_carpeta_despues_de_descargar = True
            Fm.ShowDialog(Me)

        End If

    End Sub

    Private Sub Btn_Agregar_Vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Vendedor.Click
        If Fx_Tiene_Permiso(Me, "User0001") Then

            Dim _CodVendedor = Cmb_CodVendedor.SelectedValue

            Dim Fm As New Frm_Usuarios_Bk
            Fm.ShowDialog(Me)

            caract_combo(Cmb_CodVendedor)
            Consulta_sql = _Union & "SELECT CodFuncionario AS Padre,NomFuncionario AS Hijo" & vbCrLf &
                            "FROM " & _Global_BaseBk & "Zw_Usuarios" & vbCrLf &
                            "Where Es_Vendedor = 1" & vbCrLf &
                            "ORDER BY Hijo"

            Cmb_CodVendedor.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql) ' _Sql.Fx_Get_Tablas(Consulta_sql)
            Cmb_CodVendedor.SelectedValue = _CodVendedor

        End If
    End Sub

    Private Function _Checks() As Command()
        Return New Command() {Chk_GGG, Chk_GAF, Chk_GCC}
    End Function

    Private Sub Btn_Cerrar_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cerrar_documento.Click

        If Fx_Tiene_Permiso(Me, "Scn00014") Then

            Btn_GGG.Text = Replace(Btn_GGG.Text, "No se pronuncia", "#Estado#")
            Btn_GAF.Text = Replace(Btn_GAF.Text, "No se pronuncia", "#Estado#")
            Btn_GCC.Text = Replace(Btn_GCC.Text, "No se pronuncia", "#Estado#")
            Btn_EXT.Text = Replace(Btn_EXT.Text, "No se pronuncia", "#Estado#")

            If String.IsNullOrEmpty(Txt_Total_Neto_Aprobado_Pesos.Text) Or String.IsNullOrEmpty(Txt_Total_Neto_Aprobado_Uf.Text) Then

                MessageBoxEx.Show(Me, "Faltan los montos para lor totales aprobados al negocio" & vbCrLf &
                                  "Si el negocio va a ser rechazado ponga cero", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Total_Neto_Aprobado_Uf.Focus()
                Return
            End If


            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "'"
            Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Cierre_CodAutoriza, _Cierre_NombreAutoriza As String
            Dim _Ap_GGG, _Ap_GAF, _Ap_GCC, _Ap_EXT As String
            Dim _Cta_SI, _Cta_NO As Integer

            Dim _Estado As String
            Dim _Existe_Autorizacion_Extraordinaria As Boolean

            If CBool(_TblAprobacion.Rows.Count) Then

                For Each _Fila As DataRow In _TblAprobacion.Rows

                    Dim _CodAprobacion = _Fila.Item("CodAprobacion")
                    Dim _Autorizado = _Fila.Item("Autorizado")
                    Dim _Ausente = _Fila.Item("Ausente")
                    Dim _Tex_Autorizado

                    If _CodAprobacion = "01" Or _CodAprobacion = "02" Or _CodAprobacion = "03" Or _CodAprobacion = "Ex" Then

                        If _Ausente Then
                            _Tex_Autorizado = "AUSENTE"
                        Else
                            If _Autorizado Then
                                _Cta_SI += 1
                                _Tex_Autorizado = "AUTORIZADO"
                            Else
                                _Cta_NO += 1
                                _Tex_Autorizado = "RECHAZADO"
                            End If
                        End If


                        Select Case _CodAprobacion
                            Case "01"
                                _Ap_GGG = _Tex_Autorizado

                                If _Ausente Then
                                    Btn_GGG.Image = Imagenes_botones.Images.Item(4)
                                Else
                                    If _Autorizado Then
                                        Btn_GGG.Image = Imagenes_botones.Images.Item(0)
                                    Else
                                        Btn_GGG.Image = Imagenes_botones.Images.Item(1)
                                    End If
                                End If

                                Btn_GGG.Text = Replace(Btn_GGG.Text, "#Estado#", _Tex_Autorizado)
                            Case "02"
                                _Ap_GAF = _Tex_Autorizado

                                If _Ausente Then
                                    Btn_GAF.Image = Imagenes_botones.Images.Item(4)
                                Else
                                    If _Autorizado Then
                                        Btn_GAF.Image = Imagenes_botones.Images.Item(0)
                                    Else
                                        Btn_GAF.Image = Imagenes_botones.Images.Item(1)
                                    End If
                                End If

                                Btn_GAF.Text = Replace(Btn_GAF.Text, "#Estado#", _Tex_Autorizado)
                            Case "03"
                                _Ap_GCC = _Tex_Autorizado

                                If _Ausente Then
                                    Btn_GCC.Image = Imagenes_botones.Images.Item(4)
                                Else
                                    If _Autorizado Then
                                        Btn_GCC.Image = Imagenes_botones.Images.Item(0)
                                    Else
                                        Btn_GCC.Image = Imagenes_botones.Images.Item(1)
                                    End If
                                End If

                                Btn_GCC.Text = Replace(Btn_GCC.Text, "#Estado#", _Tex_Autorizado)
                            Case "Ex"
                                _Ap_EXT = _Tex_Autorizado

                                If _Ausente Then
                                    Btn_EXT.Image = Imagenes_botones.Images.Item(4)
                                Else
                                    If _Autorizado Then
                                        Btn_EXT.Image = Imagenes_botones.Images.Item(0)
                                    Else
                                        Btn_EXT.Image = Imagenes_botones.Images.Item(1)
                                    End If
                                End If
                                _Existe_Autorizacion_Extraordinaria = True
                                Btn_EXT.Text = Replace(Btn_EXT.Text, "#Estado#", _Tex_Autorizado)
                        End Select

                    End If

                Next

                Btn_GGG.Text = Replace(Btn_GGG.Text, "#Estado#", "No se pronuncia")
                Btn_GAF.Text = Replace(Btn_GAF.Text, "#Estado#", "No se pronuncia")
                Btn_GCC.Text = Replace(Btn_GCC.Text, "#Estado#", "No se pronuncia")
                Btn_EXT.Text = Replace(Btn_EXT.Text, "#Estado#", "No se pronuncia")

                If (Btn_GGG.Image Is Nothing) Then Btn_GGG.Image = Imagenes_botones.Images.Item(3)
                If (Btn_GAF.Image Is Nothing) Then Btn_GAF.Image = Imagenes_botones.Images.Item(3)
                If (Btn_GCC.Image Is Nothing) Then Btn_GCC.Image = Imagenes_botones.Images.Item(3)
                If (Btn_EXT.Image Is Nothing) Then Btn_EXT.Image = Imagenes_botones.Images.Item(3)


            End If

            'NOMINADO, INNOMINADO, EXCLUIDO
            Dim _Aceptado As Boolean
            Dim _PreAprobado As Boolean

            Dim _Clas As String = Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Text

            ' _Cta_SI = 4

            If _Clas = "EXCLUIDO" Then

                If _Cta_SI >= 3 Then
                    _PreAprobado = True
                End If

            ElseIf _Clas = "NOMINADO" Or _Clas = "INNOMINADO" Then

                If _Cta_SI = 0 Then
                    _Aceptado = False
                ElseIf _Cta_SI = 1 Then
                    _Aceptado = False
                ElseIf _Cta_SI = 2 Then
                    _Aceptado = True
                ElseIf _Cta_SI >= 3 Then
                    _Aceptado = True
                End If

            End If


            If _PreAprobado Then

                If _Aceptado Then

                End If

                If MessageBoxEx.Show(Me, "El negocio aún se encuentra en proceso de pre-aprobación, " &
                                     "ya que la clasificación crediticia del clientes es EXCLUIDO." & vbCrLf &
                                     "Para poder cerrar este negocio debe ingresar la clave de autorización." & vbCrLf & vbCrLf &
                                     "¿Desea ingresar la clave de autorización para cerrar el negocio?", "Validación de aprobación",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    Dim Fm_ As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Scn00016", True, False)
                    Fm_.ShowDialog(Me)

                    If Fm_.Pro_Permiso_Aceptado Then '_Accion_Validada Then

                        Dim _Kofu As String = Fm_.Pro_RowUsuario.Item("KOFU")
                        Dim _Nokofu As String = Fm_.Pro_RowUsuario.Item("NOKOFU")

                        If Fm_.Pro_Permiso_Aceptado Then

                            _Cierre_CodAutoriza = _Kofu
                            _Cierre_NombreAutoriza = _Nokofu

                            Chk_GGG.Text = "APROBADO"
                            Chk_GGG.Checked = False

                            Chk_GAF.Text = "RECHAZADO"
                            Chk_GAF.Checked = False

                            Dim _Opciones() As Command = {Chk_GGG, Chk_GAF}

                            Dim _Info As New TaskDialogInfo("Cierre de negocio",
                              eTaskDialogIcon.Shield,
                              "Indique su opción",
                              "CLASIFICACION CREDITICIA: " & Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Text,
                              eTaskDialogButton.Ok _
                              , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

                            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                            If _Resultado = eTaskDialogResult.Ok Then

                                If Chk_GGG.Checked Then
                                    _Aceptado = True
                                ElseIf Chk_GAF.Checked Then
                                    _Aceptado = False
                                Else
                                    MessageBoxEx.Show(Me, "Debe eliegir una opción para cerrar el negocio", "Cerrar negocio",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Return
                                End If

                            Else
                                Return
                            End If
                        Else
                            MensajeSinPermiso("Scn00016", _Kofu, _Nokofu)
                            Sb_Pre_Aprobado()
                            Return
                        End If

                        'Else
                        'Sb_Pre_Aprobado()
                        'Return
                    End If
                    Fm_.Dispose()
                Else
                    Sb_Pre_Aprobado()
                    Return
                End If

            Else
                _Cierre_CodAutoriza = FUNCIONARIO
                _Cierre_NombreAutoriza = Nombre_funcionario_activo
            End If

            Dim _Informe_Cierre As String
            Dim _Icono As eTaskDialogIcon

            If _Aceptado Then
                _Informe_Cierre = "AUTORIZADO"
                _Icono = eTaskDialogIcon.CheckMark

                If Var_Total_Neto_Aprobado_Pesos <= 0 Or Var_Total_Neto_Aprobado_Uf <= 0 Then

                    Txt_Total_Neto_Aprobado_Uf.ReadOnly = False

                    MessageBoxEx.Show(Me, "El monto aprobado no puede ser menor o igual a cero", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Txt_Total_Neto_Aprobado_Uf.Focus()

                    Return
                End If

                _Estado = "C1"

            Else

                _Informe_Cierre = "RECHAZADO"
                _Icono = eTaskDialogIcon.Stop

                Var_Total_Neto_Aprobado_Pesos = 0
                Var_Total_Neto_Aprobado_Uf = 0

                _Estado = "C2"

            End If

            Dim _Botones() As Command '= {Btn_GGG, Btn_GAF, Btn_GCC, Btn_EXT}

            If _Existe_Autorizacion_Extraordinaria Then
                _Botones = New Command() {Btn_GGG, Btn_GAF, Btn_GCC, Btn_EXT}
            Else
                _Botones = New Command() {Btn_GGG, Btn_GAF, Btn_GCC}
            End If

            'Return New Command() { commandButton1, commandButton2 }

            Dim info As New TaskDialogInfo("Cierre de negocio",
                          _Icono,
                          _Informe_Cierre,
                          "CLASIFICACION CREDITICIA: " & Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Text,
                          eTaskDialogButton.Yes + eTaskDialogButton.Cancel _
                          , eTaskDialogBackgroundColor.Red, Nothing, _Botones, Nothing,
                          "Clic sobre las opciones para ver los comentarios de gerencia", Imagenes_16_16.Images.Item(0))

            Dim result As eTaskDialogResult = TaskDialog.Show(info)


            If result = eTaskDialogResult.Yes Then

                Dim _Aceptado_Obs As Boolean
                Dim _Cierre_Observaciones As String

                _Aceptado_Obs = InputBox_Bk(Me, "Ingrese alguna observación al cierre", "Cierre de negocio", _Cierre_Observaciones,
                                        True, _Tipo_Mayus_Minus.Normal, 500, True, _Tipo_Imagen.Texto, False)

                If _Aceptado_Obs Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc" & vbCrLf &
                                   "Set Estado = '" & _Estado & "',Estado_Cerrado = '" & _Informe_Cierre & "',Fecha_Cierre = Getdate()" & vbCrLf &
                                   "Where Nro_Negocio = '" & _NroNegocio & "'" & vbCrLf & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Negocios_02_Det" & vbCrLf &
                                   "Set Cierre_CodAutoriza = '" & _Cierre_CodAutoriza &
                                   "',Cierre_NombreAutoriza = '" & _Cierre_NombreAutoriza &
                                   "',Cierre_Observaciones = '" & _Cierre_Observaciones & "'" & vbCrLf &
                                   ",Total_Neto_Aprobado_Uf = " & De_Num_a_Tx_01(Var_Total_Neto_Aprobado_Uf, False, 5) & vbCrLf &
                                   ",Total_Neto_Aprobado_Pesos = " & De_Num_a_Tx_01(Var_Total_Neto_Aprobado_Pesos, False, 5) & vbCrLf &
                                   "Where Nro_Negocio = '" & _NroNegocio & "'"


                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        info = New TaskDialogInfo("Cierre de negocio",
                                                  eTaskDialogIcon.CheckMark2,
                                                  "NEGOCIO CERRADO CORRECTAMENTE",
                                                  vbCrLf & "A continuación se enviara un correo de información al vendedor y copias a cada uno de los participantes seleccionados",
                                                  eTaskDialogButton.Ok _
                         , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Imagenes_16_16.Images.Item(0))

                        result = TaskDialog.Show(info)

                        Sb_Abrir_Documento(_NroNegocio, False)


                        ' ENVIAR CORREO A LOS PARTICIPANTES DEL NEGOCIO + EL VENDEDOR

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & Trim(_Id_Correo_Al_Cerrar)
                        Dim _TblCorreo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

                        If CBool(_TblCorreo.Rows.Count) Then

                            Dim _Envio_Automatico As Boolean = _TblCorreo.Rows(0).Item("Envio_Automatico")

                            If _Envio_Automatico Then

                                Dim _CodVendedor As String = Cmb_CodVendedor.SelectedValue

                                Consulta_sql = "Select CodFuncionario,NomFuncionario,Enviar_copia_al_cierre From " & _Global_BaseBk & "Zw_Negocios_02_Fun " &
                                               "Where Nro_Negocio = '" & _NroNegocio & "' And Stand_By = " & CInt(_Stand_By) * -1 &
                                               " And CodFuncionario <> '" & _CodVendedor & "'" & vbCrLf &
                                               "Union" & vbCrLf &
                                               "Select '" & _CodVendedor & "' as CodFuncionario,'" & Cmb_CodVendedor.Text & "' as NomFuncionario,1 as Enviar_copia_al_cierre"

                                _TblParticipantes = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

                                Sb_Enviar_Correo_De_Aviso_Participantes(_TblCorreo.Rows(0), _TblParticipantes, Correo_cerrar_grabar.Cerrar)
                            Else

                                'Sb_Abrir_Documento(_NroNegocio, False)
                                Dim _ObsGerencia As String = Fx_HTML_Observaciones_Gerencia()
                                Dim _Html As String = Fx_HTML_Cierre_Negocio(_ObsGerencia)
                                Sb_Enviar_Correo_Manual(_TblCorreo.Rows(0), _Html, "Cierre de negocio Nro: " & _NroNegocio)

                            End If

                        End If

                        Try
                            Sb_Imprimir_Reporte(Accion_Reporte.Crear_PDF)
                        Catch ex As Exception

                        End Try
                        'If MessageBoxEx.Show(Me, "¿Desea imprimir el reporte final?", "Imprimir reporte", _
                        '                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        'Sb_Imprimir_Reporte()
                        ' End If

                        _Cerrar = True
                        Me.Close()
                    End If
                End If

            End If

        End If

    End Sub



    Sub Sb_Pre_Aprobado()

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc" & vbCrLf &
                       "Set Estado = 'C3',Estado_Cerrado = 'PRE-APROBADO'" & vbCrLf &
                       "Where Nro_Negocio = '" & _NroNegocio & "'" & vbCrLf & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Negocios_02_Det Set" & vbCrLf &
                       "Total_Neto_Aprobado_Uf = " & De_Num_a_Tx_01(Var_Total_Neto_Aprobado_Uf, False, 5) & vbCrLf &
                       ",Total_Neto_Aprobado_Pesos = " & De_Num_a_Tx_01(Var_Total_Neto_Aprobado_Pesos, False, 5) & vbCrLf &
                       "Where Nro_Negocio = '" & _NroNegocio & "'"

        _Sql.Ej_consulta_IDU(Consulta_sql) 'Ej_consulta_IDU(Consulta_sql, cn1)

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Negocios_01_Enc Where Nro_Negocio = '" & _NroNegocio & "'"
        Dim _RowEstado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql).Rows(0)

        Dim _Estado As String = _RowEstado.Item("Estado")
        Dim _Estado_Cerrado As String = _RowEstado.Item("Estado_Cerrado")

        If _Estado = "CM" And _Estado_Cerrado = "PRE-APROBADO" Then
            MessageBoxEx.Show(Me, "El documento quedo en estado de pre-aprobación y quedara a la espera " &
                              "del cierre por parte de la gerencia", "Negocio Pre-Aprobado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

        Me.Close()

    End Sub


    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Sb_Imprimir_Reporte(_NroNegocio)
    End Sub

    Sub Sb_Imprimir_Reporte(ByVal _NroNegocio As String)

        If Fx_Tiene_Permiso(Me, "Scn00015") Then

            Dim _Semilla As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Negocios_04_Doc", "Semilla",
                                                        "Tipo_Obs = 'INFORME_FINAL' And NroNegocio = '" & _NroNegocio & "'", True)
            ' trae_dato(tb, cn1, "Semilla", _
            'Global_BaseBk & "Zw_Negocios_04_Doc", _
            '"Tipo_Obs = 'INFORME_FINAL' And NroNegocio = '" & _NroNegocio & "'", True)
            Try
                If CBool(_Semilla) Then


                    Dim _Link As String = _Dir_Temp & "\" & _Nombre_Reporte

                    If File.Exists(_Link) Then File.Delete(_Link)

                    Dim Fm As New Frm_SolCredito_File_Attach(_NroNegocio)
                    Fm.Fx_Extrae_Archivo_desde_BD(_Semilla, _Nombre_Reporte, _Dir_Temp)
                    Fm.Dispose()

                    ' _Observaciones_Rtf.LoadFile(_Dir_Temp & "\Reporte.pdf")

                    Try
                        Dim psi As New ProcessStartInfo()
                        psi.UseShellExecute = True
                        psi.FileName = _Link
                        Process.Start(psi)
                    Catch ex As Exception
                        MessageBoxEx.Show(Me, ex.Message)
                    End Try
                Else

                    Sb_Imprimir_Reporte(Accion_Reporte.Crear_PDF)
                    Sb_Imprimir_Reporte(_NroNegocio)

                End If
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message)
            End Try

        End If
    End Sub

    Enum Accion_Reporte
        Crear_PDF
        Imprimir_En_Crystal
    End Enum

    Sub Sb_Imprimir_Reporte(ByVal _Accion_Reporte As Accion_Reporte)

        Try

            Consulta_sql = "SELECT Case Ausente When 1 Then '' Else NombreAutoriza End As 'NombreAutoriza'," & vbCrLf &
                   "Case Ausente When 0 Then Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END else 'AUSENTE' End As 'Estado'," &
                   "NomAprobacion as 'Cargo','Obs.: '+" & vbCrLf &
                   "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf &
                   "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf &
                   "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf &
                   "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf &
                   "Case Chk_05 When 1 Then 'Entrega de garantia real. ' Else '. ' End + Observaciones As 'Observaciones'" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "' And CodFuncionario <> 'ZBK'"

            Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) ' _Sql.Fx_Get_Tablas(Consulta_sql)



            If _TblAprobacion.Rows.Count > 0 Then
                'iniciamos el form y el reporte
                Dim form As New Frm_VerReportes
                Dim report As New Reporte_final_Detalle

                'le indicamos el datasource al report, que sera el recordset
                'que hemos llenado
                report.SetDataSource(_TblAprobacion)

                'le indicamos el reportsource al crviewer del segundo form
                'que sera el report que creamos

                Dim _Fecha_Cierre = NuloPorNro(_TblEncabezado.Rows(0).Item("Fecha_Cierre"), FechaDelServidor)
                Dim _NomTipo = _TblEncabezado.Rows(0).Item("NomTipo")


                report.SetParameterValue("Fecha_Cierre", _Fecha_Cierre)
                report.SetParameterValue("Nom_Tipo", _NomTipo)

                '_NroNegocio
                Dim _NomSucursal = _TblEncabezado.Rows(0).Item("NomSucursal")
                Dim _NomFuncionario = _TblEncabezado.Rows(0).Item("NomFuncionario")
                Dim _Fecha_Emision = _TblEncabezado.Rows(0).Item("Fecha_Emision")

                report.SetParameterValue("NomSucursal", _NomSucursal)
                report.SetParameterValue("NomFuncionario", _NomFuncionario)
                report.SetParameterValue("Fecha_Emision", _Fecha_Emision)
                report.SetParameterValue("Nro_Negocio", _NroNegocio)

                Dim _Rut = _TblEntidad.Rows(0).Item("Rut")
                Dim _NomEntidad = _TblEntidad.Rows(0).Item("NOKOEN")
                Dim _Direccion = _TblEntidad.Rows(0).Item("DIEN")
                Dim _Comuna = _TblEntidad.Rows(0).Item("COMUNA")

                report.SetParameterValue("Rut", _Rut)
                report.SetParameterValue("NomEntidad", _NomEntidad)
                report.SetParameterValue("Direccion", _Direccion)
                report.SetParameterValue("Comuna", _Comuna)

                report.SetParameterValue("Valor_UF", Var_Valor_UF)
                report.SetParameterValue("Linea_Credito_Int_Ac_UF", Var_Linea_Credito_Int_Ac_UF)
                report.SetParameterValue("Linea_Credito_Int_Ac_Peso", Var_Linea_Credito_Int_Ac_UF)
                report.SetParameterValue("Linea_Credito_SC_Ac_UF", Var_Linea_Credito_SC_Ac_UF)
                report.SetParameterValue("Nom_Clas_Crediticia_Ac_Seg_Credito", Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Text)

                report.SetParameterValue("Monto_Aprobado_UF", Var_Total_Neto_Aprobado_Uf)
                report.SetParameterValue("Monto_Aprobado_Pesos", Var_Total_Neto_Aprobado_Pesos)

                report.SetParameterValue("Clasif_Riesgo_comercial", Txt_Clasif_Riesgo_comercial.Text)
                report.SetParameterValue("Morosidades_y_protestos", Txt_Morosidades_y_protestos.Text)
                report.SetParameterValue("Deuda_Actual", Var_Deuda_Actual)
                report.SetParameterValue("Deuda_Actual_UF", Var_Deuda_Actual_UF)

                report.SetParameterValue("Prorroga_Negociacion_Vigente", Var_Prorroga_Negociacion_Vigente)
                report.SetParameterValue("Monto_Prox_Vencimiento", Var_Monto_Prox_Vencimiento)
                report.SetParameterValue("Fecha_Prox_Vencimiento", Dtp_Fecha_Prox_Vencimiento.Value)

                report.SetParameterValue("Monto_Venta_Civa", Var_Monto_Venta_Civa)
                report.SetParameterValue("Monto_Venta_Civa_UF", Var_Monto_Venta_Civa_UF)
                report.SetParameterValue("Plazo_Venta_Dias", Var_Plazo_Venta_Dias)
                report.SetParameterValue("NomVendedor", Cmb_CodVendedor.Text)

                report.SetParameterValue("Producto", Txt_Producto.Text)
                report.SetParameterValue("Precio", Txt_Precio.Text)
                report.SetParameterValue("Rentabilidad", Txt_Rentabilidad.Text)
                report.SetParameterValue("Dias_libres", Txt_Dias_libres.Text)
                report.SetParameterValue("Taza_de_interes", Txt_Taza_de_interes.Text)

                report.SetParameterValue("Observaciones", _Observaciones)
                report.SetParameterValue("Observaciones_Cierre", _Observaciones_Cierre)

                Dim _Documenta_Venta = String.Empty

                If Rdb_Doc_Venta_SI.Checked Then
                    _Documenta_Venta = "SI, " & Cmb_Cod_Doc_Venta_SI.Text
                Else
                    _Documenta_Venta = "NO"
                End If
                report.SetParameterValue("Documenta_Venta", _Documenta_Venta)

                Dim _Ficha_Interna_Cliente = String.Empty

                If Rdb_Ficha_Int_Cli_Completa.Checked Then
                    _Ficha_Interna_Cliente = "COMPLETA"
                ElseIf Rdb_Ficha_Int_Cli_Parcial.Checked Then
                    _Ficha_Interna_Cliente = "PARCIAL"
                ElseIf Rdb_Ficha_Int_Cli_SinAntecedentes.Checked Then
                    _Ficha_Interna_Cliente = "SIN ANTECEDENTE"
                End If

                report.SetParameterValue("Ficha_Interna_Cliente", _Ficha_Interna_Cliente)


                If _Accion_Reporte = Accion_Reporte.Imprimir_En_Crystal Then
                    form.CrystalReportViewer1.ReportSource = report
                    form.ShowInTaskbar = True
                    form.Show()

                    form = Nothing
                ElseIf _Accion_Reporte = Accion_Reporte.Crear_PDF Then

                    'If Not Directory.Exists(_Dir_Temp & "\Reportes") Then
                    'Directory.CreateDirectory(_Dir_Temp & "\Reportes")
                    'End If

                    Dim _ClPdf As New Clase_PDF
                    Dim _Directorio_Destino = _ClPdf.Fx_Exportar_Crystal_a_PDF(report,
                                                                               _Dir_Temp,
                                                                               "Reporte.pdf")

                    'Shell("explorer.exe " & _Dir_Temp, AppWinStyle.NormalFocus)

                    '*******
                    Dim Fm As New Frm_SolCredito_File_Attach(_NroNegocio)
                    Fm.Fx_Grabar_Observacion_Adjunta(_NroNegocio, _Dir_Temp & "\Reporte.pdf", "Reporte.pdf",
                                                     Frm_SolCredito_File_Attach.Tipo_Obs.INFORME_FINAL)
                    Fm.Dispose()
                    File.Delete(_Dir_Temp & "\Reporte.pdf")
                    '*****

                End If


            Else
                MessageBoxEx.Show(Me, "No hay datos en la tabla de aprobación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    Private Sub Btn_GGG_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GGG.Executed

        Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," &
                   "NomAprobacion as 'Cargo'," & vbCrLf &
                   "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf &
                   "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf &
                   "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf &
                   "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf &
                   "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "' And CodAprobacion = '01'"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Text = "Gerencia general"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.Btn_Anular_Autorizacion.Visible = False
                Fm.ShowDialog(Me)
            End If

        Else
            Beep()
            ToastNotification.Show(Me, Btn_GCC.Text,
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        End If


    End Sub

    Private Sub Btn_GAF_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GAF.Executed

        Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," &
                   "NomAprobacion as 'Cargo'," & vbCrLf &
                   "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf &
                   "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf &
                   "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf &
                   "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf &
                   "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "' And CodAprobacion = '02'"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)


        If CBool(_Tbl.Rows.Count) Then
            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Text = "Gerencia administración y finanzas"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.Btn_Anular_Autorizacion.Visible = False
                Fm.ShowDialog(Me)
            End If

        Else
            Beep()
            ToastNotification.Show(Me, Btn_GCC.Text,
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        End If


    End Sub

    Private Sub Btn_GCC_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GCC.Executed

        Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," &
                   "NomAprobacion as 'Cargo'," & vbCrLf &
                   "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf &
                   "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf &
                   "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf &
                   "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf &
                   "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "' And CodAprobacion = '03'"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)


        If CBool(_Tbl.Rows.Count) Then

            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")
            Dim _Observaciones = _Tbl.Rows(0).Item("Observaciones")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Text = "Gerencia crédito y cobranza"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.Btn_Anular_Autorizacion.Visible = False
                Fm.ShowDialog(Me)
            End If
        Else
            ' MessageBoxEx.Show(Me, Btn_GCC.Text, "No existe información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Beep()
            ToastNotification.Show(Me, Btn_GCC.Text,
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        End If

    End Sub

    Private Sub Btn_EXT_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EXT.Executed

        Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," &
                       "NomAprobacion as 'Cargo'," & vbCrLf &
                       "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf &
                       "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf &
                       "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf &
                       "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf &
                       "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Negocios_03_Apr" & Space(1) &
                       "Where Nro_Negocio = '" & _NroNegocio & "' And CodAprobacion = 'Ex'"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)



        If CBool(_Tbl.Rows.Count) Then

            Dim _Ausente = _Tbl.Rows(0).Item("Ausente")
            Dim _Observaciones = _Tbl.Rows(0).Item("Observaciones")

            If _Ausente Then
                MessageBoxEx.Show(Me, "Motivo ausencia:" & _Observaciones, "Funcionario se declara ausente para este negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Fm As New Frm_SolCredito_Autorizar_Formulario
                Fm.Text = "Aprobación Extraordinaria"
                Fm.Pro_RowAprobacion = _Tbl.Rows(0)
                Fm.Btn_Anular_Autorizacion.Visible = False
                Fm.ShowDialog(Me)
            End If
        Else
            ' MessageBoxEx.Show(Me, Btn_GCC.Text, "No existe información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Beep()
            ToastNotification.Show(Me, Btn_EXT.Text,
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        End If

    End Sub

#Region "PROCEDIMIENTOS CREAR HTML CORREOS"

    Function Fx_HTML_Apertura_Negocio() As String

        Dim _Documento_Html As String = My.Resources.Recursos_Negocios.Apertura_Negocio

        Dim _RowEntidad As DataRow = _TblEntidad.Rows(0)
        Dim _RowEncabezado As DataRow = _TblEncabezado.Rows(0)

        _NroNegocio = _RowEncabezado.Item("Nro_Negocio")

        _Documento_Html = Replace(_Documento_Html, "#Clienter#", _RowEntidad.Item("NOKOEN"))
        _Documento_Html = Replace(_Documento_Html, "#RUT_Cliente#", _RowEntidad.Item("Rut"))
        _Documento_Html = Replace(_Documento_Html, "#Direccion_Cliente#", _RowEntidad.Item("DIEN"))
        _Documento_Html = Replace(_Documento_Html, "#Tipo_de_negocio#", Cmb_Tipo.Text)
        _Documento_Html = Replace(_Documento_Html, "#Numero_de_negocio#", _NroNegocio)
        _Documento_Html = Replace(_Documento_Html, "#Fecha_Apertura#", FormatDateTime(_RowEncabezado.Item("Fecha_Emision"), DateFormat.ShortDate))
        _Documento_Html = Replace(_Documento_Html, "#Vendedor#", Cmb_CodVendedor.Text)

        _Documento_Html = Replace(_Documento_Html, "á", "&aacute;")
        _Documento_Html = Replace(_Documento_Html, "é", "&eacute;")
        _Documento_Html = Replace(_Documento_Html, "í", "&iacute;")
        _Documento_Html = Replace(_Documento_Html, "ó", "&oacute;")
        _Documento_Html = Replace(_Documento_Html, "ú", "&uacute;")
        _Documento_Html = Replace(_Documento_Html, "ñ", "&ntilde;")
        _Documento_Html = Replace(_Documento_Html, "Ñ", "&Ntilde;")

        Return _Documento_Html

    End Function

    Function Fx_HTML_Cierre_Negocio(ByVal _ObsGerencia As String) As String

        Dim _Documento_Html As String = My.Resources.Recursos_Negocios.Cierre_Negocio


        'Dim _TblEncabezado, _TblDetalle, _TblAprobacion, _TblParticipantes As DataTable

        Dim _RowEntidad As DataRow = _TblEntidad.Rows(0)
        Dim _RowEncabezado As DataRow = _TblEncabezado.Rows(0)
        Dim _RowDetalle As DataRow = _TblDetalle.Rows(0)

        Dim _Fecha_Emision = _RowEncabezado.Item("Fecha_Emision")
        Dim _Fecha_Cierre = _RowEncabezado.Item("Fecha_Cierre")
        Dim _Cierre_Observaciones = _RowDetalle.Item("Cierre_Observaciones")

        Dim _Estado_Cerrado As String = _RowEncabezado.Item("Estado_Cerrado")

        _Documento_Html = Replace(_Documento_Html, "#Estado#", _Estado_Cerrado)
        _Documento_Html = Replace(_Documento_Html, "#Clienter#", _RowEntidad.Item("NOKOEN"))
        _Documento_Html = Replace(_Documento_Html, "#RUT_Cliente#", _RowEntidad.Item("Rut"))
        _Documento_Html = Replace(_Documento_Html, "#Direccion_Cliente#", _RowEntidad.Item("DIEN"))
        _Documento_Html = Replace(_Documento_Html, "#Tipo_de_negocio#", _RowEncabezado.Item("NomTipo"))
        _Documento_Html = Replace(_Documento_Html, "#Numero_de_negocio#", _NroNegocio)
        _Documento_Html = Replace(_Documento_Html, "#Fecha_de_apertura#", FormatDateTime(_Fecha_Emision, DateFormat.ShortDate))
        _Documento_Html = Replace(_Documento_Html, "#Fecha_de_cierre#", FormatDateTime(_Fecha_Cierre, DateFormat.ShortDate))

        _Documento_Html = Replace(_Documento_Html, "#Responsable#", Cmb_CodVendedor.Text)

        Dim _Monto_Aprobado As Double = Fx_Convert_UF2Peso(Var_Linea_Credito_SC_Ac_UF, Var_Valor_UF, False)
        Dim _Dias As String = Txt_Plazo_Venta_Dias.Text

        If _Estado_Cerrado = "RECHAZADO" Then _Monto_Aprobado = 0 : _Dias = "-"

        _Documento_Html = Replace(_Documento_Html, "#Monto_Aprobado#", FormatCurrency(Var_Total_Neto_Aprobado_Pesos, 0))
        _Documento_Html = Replace(_Documento_Html, "#Plazo_dias#", _Dias)

        _Documento_Html = Replace(_Documento_Html, "#Observaciones#", _Cierre_Observaciones)

        'Cierre_Observaciones

        _Documento_Html = Replace(_Documento_Html, "á", "&aacute;")
        _Documento_Html = Replace(_Documento_Html, "é", "&eacute;")
        _Documento_Html = Replace(_Documento_Html, "í", "&iacute;")
        _Documento_Html = Replace(_Documento_Html, "ó", "&oacute;")
        _Documento_Html = Replace(_Documento_Html, "ú", "&uacute;")
        _Documento_Html = Replace(_Documento_Html, "ñ", "&ntilde;")
        _Documento_Html = Replace(_Documento_Html, "Ñ", "&Ntilde;")



        _Documento_Html = Replace(_Documento_Html, "#Obs_Gerencia#", _ObsGerencia)

        Return _Documento_Html

    End Function

#End Region

    Function Fx_HTML_Observaciones_Gerencia() As String

        Dim _ObsGerencia = String.Empty

        Consulta_sql = "SELECT *,Case Autorizado When 1 then 'AUTORIZADO' ELSE 'RECHAZADO' END As 'Estado'," &
                   "NomAprobacion as 'Cargo'," & vbCrLf &
                   "Case Chk_01 When 1 Then 'Documentar con cheque o letra - ' Else '' End + " & vbCrLf &
                   "Case Chk_02 When 1 Then 'Previa entrega de carpeta - ' Else '' End + " & vbCrLf &
                   "Case Chk_03 When 1 Then 'Previa liberación de fondos - ' Else '' End + " & vbCrLf &
                   "Case Chk_04 When 1 Then 'Pago anticipado de factura - ' Else '' End + " & vbCrLf &
                   "Case Chk_05 When 1 Then 'Entrega de garantia real - ' Else '. ' End As 'Observaciones_Chk'" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "' And CodAprobacion in ('01','02','03','Ex')"

        Dim _TblObsGerencia As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

        'Dim _ObsGerencia = String.Empty

        If MessageBoxEx.Show(Me, "¿Desea incluir las observaciones del comité?", "Observaciones comité",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' style="width: 921px; height: 31px;">

            _ObsGerencia = vbCrLf & "<table border=" & Chr(34) & "1" & Chr(34) & " cellspacing=" & Chr(34) & "2" & Chr(34) & " cellpadding=" & Chr(34) & "2" & Chr(34) & vbCrLf &
                           "summary = " & Chr(34) & "Especificaci&oacuten del Detalle del Documento" & vbCrLf &
                           "style=" & Chr(34) & "width: 921px; height: 31px;" & Chr(34) & ">" & vbCrLf &
                           "<caption>" & vbCrLf &
                           "<br />" & vbCrLf &
                           "</caption>"

            For Each _Fila As DataRow In _TblObsGerencia.Rows

                Dim _Cargo As String = _Fila.Item("Cargo")
                Dim _Ausente As Boolean = _Fila.Item("Ausente")
                Dim _Observaciones As String = UCase(_Fila.Item("Observaciones")) & vbCrLf & UCase(_Fila.Item("Observaciones_Chk"))

                If Not _Ausente Then
                    _ObsGerencia += vbCrLf & "<tr> " & vbCrLf &
                                    "<td bgcolor=" & Chr(34) & "LemonChiffon" & Chr(34) & " class=" & Chr(34) & "style27" & Chr(34) &
                                    " rowspan=" & Chr(34) & "0" & Chr(34) & "><b>" & _Cargo & "</b></td>" & vbCrLf &
                                    "<td bgcolor=" & Chr(34) & "LemonChiffon" & Chr(34) & " class=" & Chr(34) &
                                    "style26" & Chr(34) & ">" & _Observaciones & "</td>"
                End If
            Next
        End If

        Return _ObsGerencia

    End Function

    Private Sub Btn_Reenbiar_Correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Reenbiar_Correo.Click

        ' ENVIAR CORREO A LOS PARTICIPANTES DEL NEGOCIO + EL VENDEDOR

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & Trim(_Id_Correo_Al_Cerrar)
        Dim _TblCorreo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) '_Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblCorreo.Rows.Count) Then

            Dim _Html As String = Fx_HTML_Cierre_Negocio(Fx_HTML_Observaciones_Gerencia)
            Sb_Enviar_Correo_Manual(_TblCorreo.Rows(0), _Html, "Cierre de negocio Nro: " & _NroNegocio)

        Else
            MessageBoxEx.Show(Me, "Revise la configuración de los correos de BakApp", "No existen correos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Txt_Total_Neto_Aprobado_Uf_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_Total_Neto_Aprobado_Uf.Validating
        Var_Total_Neto_Aprobado_Uf = Val(Txt_Total_Neto_Aprobado_Uf.Text)
        Txt_Total_Neto_Aprobado_Uf.Text = "UF " & FormatNumber(Var_Total_Neto_Aprobado_Uf, 0)

        If Var_Linea_Credito_SC_Ac_UF < Var_Total_Neto_Aprobado_Uf Then
            MessageBoxEx.Show(Me, "El valor aprobado no puede ser mayor al monto solicitado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Var_Total_Neto_Aprobado_Pesos = 0
            Txt_Total_Neto_Aprobado_Pesos.Text = FormatCurrency(Var_Total_Neto_Aprobado_Pesos, 0)
            e.Cancel = True
        ElseIf Var_Linea_Credito_SC_Ac_UF > Var_Total_Neto_Aprobado_Uf Then
            Beep()
            If MessageBoxEx.Show(Me, "El monto aprobado es menor al solicitado" & vbCrLf & vbCrLf &
                                 "Monto solicitado: UF " & Txt_Linea_Credito_SC_Ac_UF.Text & vbCrLf &
                                 "Monto aprobado: " & Txt_Total_Neto_Aprobado_Uf.Text & vbCrLf & vbCrLf &
                                 "¿Confirma el valor del precio aprobado menor al solicitado?", "Validación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                Var_Total_Neto_Aprobado_Pesos = 0
                Txt_Total_Neto_Aprobado_Pesos.Text = FormatCurrency(Var_Total_Neto_Aprobado_Pesos, 0)
                e.Cancel = True
            Else
                Var_Total_Neto_Aprobado_Pesos = Fx_Convert_UF2Peso(Var_Total_Neto_Aprobado_Uf, Var_Valor_UF, False)
                Txt_Total_Neto_Aprobado_Pesos.Text = FormatCurrency(Var_Total_Neto_Aprobado_Pesos, 0)
                Btn_Cerrar_documento.Enabled = True
            End If

        Else

            Var_Total_Neto_Aprobado_Pesos = Fx_Convert_UF2Peso(Var_Total_Neto_Aprobado_Uf, Var_Valor_UF, False)
            Txt_Total_Neto_Aprobado_Pesos.Text = FormatCurrency(Var_Total_Neto_Aprobado_Pesos, 0)
            Btn_Cerrar_documento.Enabled = True
        End If

    End Sub

    Private Sub Txt_Total_Neto_Aprobado_Uf_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Total_Neto_Aprobado_Uf.Enter
        Btn_Cerrar_documento.Enabled = False
    End Sub

    Private Sub Txt_Total_Neto_Aprobado_Pesos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Total_Neto_Aprobado_Pesos.Enter
        '   Btn_Cerrar_documento.Enabled = False
    End Sub

    Private Sub Btn_Corregir_Negocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Corregir_Negocio.Click

        If Fx_Tiene_Permiso(Me, "Scn00018") Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Negocios_03_Apr Where Nro_Negocio = '" & _NroNegocio & "'"
            Dim _TblAprobacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Not CBool(_TblAprobacion.Rows.Count) Then

                If MessageBoxEx.Show(Me, "¿Está seguro de enviar a corregir este negocio?", "Corregir negocio",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim _Aceptado As Boolean
                    Dim _Motivo_Correccion As String

                    _Aceptado = InputBox_Bk(Me, "Ingrese el motivo por el cual se está " & vbCrLf &
                                           "mandando a el negocio",
                                           "Corregir negocio",
                                           _Motivo_Correccion,
                                           True, _Tipo_Mayus_Minus.Mayusculas,
                                           200, True, _Tipo_Imagen.Texto, False,
                                           _Tipo_Caracter.Cualquier_caracter)

                    If _Aceptado Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_01_Enc Set Estado = 'CO'," &
                                                           "Fun_Corregir = '" & FUNCIONARIO & "'," & vbCrLf &
                                                           "Fun_Corregir_Motivo = '" & _Motivo_Correccion & "'" & vbCrLf &
                                                           "Where Nro_Negocio = '" & _NroNegocio & "' And Stand_By = " & CInt(_Stand_By) * -1

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then 'Ej_consulta_IDU(Consulta_sql, cn1) Then

                            MessageBoxEx.Show(Me, "El negocio se enviara nuevamente al departamento de crédito para su corrección",
                                              "Corregir negocio",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                            _Cerrar = True
                            Me.Close()

                        End If
                    End If
                End If

            Else

                MessageBoxEx.Show(Me, "Este negocio no se puede enviar a corrección, " &
                                  "ya que tiene una aprobación o rechazo por parte de algún miembro del comite",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub Btn_Editar_Negocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Negocio.Click
        Sb_Editar_Documento(True)
        _Editar_Negocio = True
    End Sub

    Private Sub Btn_Observaciones_Generales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Observaciones_Generales.Click
        Sb_Observaciones(_NroNegocio)
    End Sub

    Private Sub Btn_Informacion_Proximos_Vencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informacion_Proximos_Vencimientos.Click

        Sb_Observaciones_Rtf(_NroNegocio)

        'Sb_Observaciones_Proximos_Vencimientos_CxC()
    End Sub

    Private Sub Grilla_Encabezado_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Encabezado.CellDoubleClick
        Return
        If _Editar_Negocio Then

            Dim _Cabeza = Grilla_Encabezado.Columns(Grilla_Encabezado.CurrentCell.ColumnIndex).Name

            If _Cabeza = "" Then

                Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server

                Dim _Fila As DataGridViewRow = Grilla_Encabezado.Rows(0)

                Cadena_ConexionSQL_Server = _Fila.Cells("Cadena_Conexion").Value

                Dim Fm_s As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Sucursal)
                Fm_s.Text = "Seleccione la Sucursal"
                Fm_s.ShowDialog(Me)

                If Fm_s.Pro_Seleccionado Then
                    _RowSucursal = Fm_s.Pro_RowBodega
                Else
                    Exit Sub
                End If

                Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

            End If
        End If

    End Sub

    Sub Sb_Observaciones_Rtf(ByVal __NroNegocio As String)

        Dim Fm As New Frm_SolCredito_Observaciones_Rtf
        Fm.Text = UCase(Btn_Informacion_Proximos_Vencimientos.Text)
        Fm.Rtf_Observaciones.Rtf = _Observaciones_Rtf.Rtf

        _Estado_Dc = NuloPorNro(_Estado_Dc, "")

        If Not String.IsNullOrEmpty(_Estado_Dc) Then

            If _Estado_Dc <> "IN" And _Estado_Dc <> "CO" And _Estado_Dc <> "ST" Then  ' And _Estado_Dc <> "AN" 

                Fm.Btn_Grabar.Visible = False
                Fm.Rtf_Observaciones.ReadOnly = True

            End If

        End If

        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            _Observaciones_Rtf.Rtf = Fm.Rtf_Observaciones.Rtf

            If _TipoDocumento = _TipoDos.VerDocumento Then


                Dim _Semilla As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Negocios_04_Doc", "Semilla",
                                                            "Tipo_Obs = 'OBS_VENCIMIENTO' And NroNegocio = '" & _NroNegocio & "'", True)
                'trae_dato(tb, cn1, "Semilla", _
                '_Global_BaseBk & "Zw_Negocios_04_Doc", _
                '"Tipo_Obs = 'OBS_VENCIMIENTO' And NroNegocio = '" & _NroNegocio & "'", True)

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Negocios_04_Doc Where Semilla = " & _Semilla

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Dim _Ruta As String = _Dir_Temp & "\Observacion_Rtf.rtf"

                    _Observaciones_Rtf.SaveFile(_Ruta)
                    Dim _Fm As New Frm_SolCredito_File_Attach(_NroNegocio)
                    _Fm.Fx_Grabar_Observacion_Adjunta(_NroNegocio, _Ruta, "Observacion_Rtf.rtf",
                                                     Frm_SolCredito_File_Attach.Tipo_Obs.OBS_VENCIMIENTO)
                    _Fm.Dispose()
                    File.Delete(_Dir_Temp & "\Observacion_Rtf.rtf")

                    'Consulta_sql = "Update " & _Global_BaseBk & "Zw_Negocios_02_Det Set Observaciones = '" & _Observaciones & "'" & vbCrLf & _
                    '               "Where Nro_Negocio = '" & __NroNegocio & "' And Stand_By = " & CInt(_Stand_By) * -1

                    'If Ej_consulta_IDU(Consulta_sql, cn1) Then
                    Beep()
                    ToastNotification.Show(Me, "OBSERVACIONES ACTUALIZADAS CORRECTAMENTE", My.Resources.ok_button,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If

                'MessageBoxEx.Show(Me, "El negocio pasara a evaluación por parte del comité", "Observaciones", _
                '                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                '_Cerrar = True
                'Me.Close()

                'End If
            End If

        End If

        Fm.Dispose()

    End Sub

    Private Sub Txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Btn_Grabar_Negocio.Enabled = False
    End Sub

    Private Sub Txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Btn_Grabar_Negocio.Enabled = True
    End Sub

    Private Sub Btn_Calcular_Sobre_Giro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular_Sobre_Giro.Click

        'Var_Linea_Credito_Int_Ac_Peso
        'Var_Deuda_Actual
        'Var_Monto_Venta_Civa()
        'Var_Linea_Credito_SC_Ac_UF    Uf solicitada

        ' If CBool(Var_Linea_Credito_Int_Ac_Peso) Then

        Dim _Dolar As Double

        Select Case _Estado_Doc
            Case _Estado.Ingresado, _Estado.Proceso
                _Dolar = _Dolar_Hoy
                'Case _Estado.Completado, _Estado.Cerrado
                '    _Dolar = _Dolar_Emision
            Case Else
                _Dolar = _Dolar_Emision
        End Select


        Dim _Fecha As Date = FormatDateTime(Grilla_Encabezado.Rows(0).Cells("Fecha_Emision").Value, DateFormat.ShortDate)
        Dim _Porc_Exposicion As Double = _Row_Cia_Seguros.Item("Porc_Exposicion")

        Dim Fm As New Frm_Sobregiro_Exposicion(_Fecha,
                                               Var_Monto_Venta_Civa,
                                               Var_Linea_Credito_Int_Ac_Peso,
                                               Var_Deuda_Actual,
                                               Var_Valor_UF,
                                               Var_Deuda_Actual,
                                               Var_Monto_Venta_Civa,
                                               _Porc_Exposicion,
                                               _Dolar,
                                               Cmb_Cod_Clas_Crediticia_Ac_Seg_Credito.Text)
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Return
        'Dim _Dolar As Double = _Sql.Fx_Trae_Dato("MAEMO", "VAMO", "KOMO = 'US$' AND FEMO = '" & Format(_Fecha, "yyyyMMdd") & "'", True)
        'trae_dato(tb, cn1, "VAMO", "MAEMO", _
        '"KOMO = 'US$' AND FEMO = '" & Format(_Fecha, "yyyyMMdd") & "'", True)

        Dim _Solicitado_Peso As Double = Var_Monto_Venta_Civa ' Fx_Convert_UF2Peso(Var_Linea_Credito_SC_Ac_UF, Var_Valor_UF, False)
        Dim _Saldo_Linea_Peso As Double = Var_Linea_Credito_Int_Ac_Peso - Var_Deuda_Actual
        _Saldo_Linea_Peso = _Solicitado_Peso - _Saldo_Linea_Peso 'Var_Linea_Credito_Int_Ac_Peso - (Var_Deuda_Actual + _Solicitado_Peso)
        Dim _Saldo_Linea_Uf As Double = _Saldo_Linea_Peso / Var_Valor_UF
        Dim _Saldo_Linea_Dolar As Double = _Saldo_Linea_Peso / _Dolar

        Dim _Msg As String = "SOBREGIRO" & vbCrLf & vbCrLf
        Dim _Icon As MessageBoxIcon = MessageBoxIcon.Warning

        If _Saldo_Linea_Peso = 0 Then
            _Saldo_Linea_Peso = 0
            _Msg = String.Empty
            _Icon = MessageBoxIcon.None
        ElseIf _Saldo_Linea_Peso < 0 Then
            _Msg = "NO HAY SOBREGIRO" & vbCrLf & vbCrLf
            _Icon = MessageBoxIcon.Information
        End If

        MessageBoxEx.Show(Me, _Msg & "Total $ " & FormatNumber(_Saldo_Linea_Peso, 0) & vbCrLf & vbCrLf &
                          "Total Uf " & FormatNumber(_Saldo_Linea_Uf, 0) & vbCrLf & vbCrLf &
                          "Total US$ " & FormatNumber(_Saldo_Linea_Dolar, 0), "Información", MessageBoxButtons.OK, _Icon)

        'Else
        'MessageBoxEx.Show(Me, "Cliente no tienen línea de crédito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

    End Sub

    Private Sub Sb_Rdb_Valores_Linea_Credito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            Sb_Actualizar_Datos_Linea_Credito()
        End If
    End Sub

    Private Sub Btn_Ficha_Cia_Seguros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ficha_Cia_Seguros.Click

        Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
        Dim _Global_BaseBk_Original = _Global_BaseBk

        Try

            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Seleccionada '_TblEncabezado.Rows(0).Item("Cadena_Conexion")
            '_Cadena_ConexionSQL_Seleccionada = Cadena_ConexionSQL_Server

            Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(Me)

            If _Class_BaseBk.Pro_Existe_Base Then
                _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")
            Else

                MessageBoxEx.Show(Me, "No esta configurada la base de datos de BakApp",
                                  "Falta identificación de base BakApp",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim _Rut = _TblEntidad.Rows(0).Item("RTEN")

            Dim Fm As New Frm_InfoEnt_Ficha_Aseguradora(_Rut)
            Fm.ShowDialog(Me)

            If Fm.Pro_Actualizado Then
                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If
            Fm.Dispose()
        Catch ex As Exception

        Finally
            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
            _Global_BaseBk = _Global_BaseBk_Original

            If Rdb_Valores_Linea_Credito_Desde_Aseguradora.Enabled Then
                Sb_Actualizar_Datos_Linea_Credito()
            End If

            'SQL_ServerClass.AbrirConexion_SQLServer(cn1)
        End Try

    End Sub


End Class
