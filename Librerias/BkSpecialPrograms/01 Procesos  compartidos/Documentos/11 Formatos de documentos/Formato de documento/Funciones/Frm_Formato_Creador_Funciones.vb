'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Formato_Creador_Funciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer ' Para revision
    Dim _Tbl_Documentos As DataTable
    Dim _Tbl_Comandos_SQL As DataTable
    Dim _Row_Maeedo As DataRow                  ' Facturas, etc...
    Dim _Row_Maedpce As DataRow                 ' Cheque
    Dim _Row_Prod_SolBodega As DataRow          ' Solicitud de productos a bodega
    Dim _Row_Servicio_Tecnico_Enc As DataRow    ' Datos encabezado Servicio Tecnico

    Dim _RowFuncion As DataRow

    Dim _Tbl_Maeddo As DataTable       ' Para documentos de venta o compra
    Dim _Tbl_Maeedo As DataTable       ' Para docuemntos pagados con CHEQUE
    Dim _Grabar As Boolean
    Dim _Cerrar_Al_Grabar As Boolean
    Dim _Sol_Prod_Bodega As Boolean

    Public Property Pro_Cerra_Al_Grabar() As Boolean
        Get
            Return _Cerrar_Al_Grabar
        End Get
        Set(ByVal value As Boolean)
            _Cerrar_Al_Grabar = value
        End Set
    End Property

    Public ReadOnly Property Pro_Grabar()
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Pro_Editar_Funcion() As String
        Get
            Return Txt_Nombre_Funcion.Text
        End Get
        Set(ByVal value As String)

            Txt_Nombre_Funcion.Text = value
            Txt_Nombre_Funcion.ReadOnly = True


            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Format_Fx" & vbCrLf &
                           "Where Nombre_Funcion = '" & value & "'"
            _RowFuncion = _Sql.Fx_Get_DataRow(Consulta_sql)

            Cmb_Seccion.SelectedValue = _RowFuncion.Item("Seccion")
            Cmb_Tipo_Dato.SelectedValue = _RowFuncion.Item("Tipo_de_dato")

            Txt_Columna.Text = _RowFuncion.Item("Campo")

            Txt_Formato.Text = _RowFuncion.Item("Formato")
            Txt_SqlQuery.Text = _RowFuncion.Item("SqlQuery")
            Txt_Descripcion_Funcion.Text = _RowFuncion.Item("Descripcion_Funcion")

            Chk_Borde_Variable.Checked = _RowFuncion.Item("Borde_Variable")
            Chk_Funcion_BakApp.Checked = _RowFuncion.Item("Funcion_Bk")
            Chk_Es_Descuento.Checked = _RowFuncion.Item("Es_Descuento")

            Chk_Query_Personalizada.Checked = _RowFuncion.Item("SQL_Personalizada")

            Rdb_Codigo_Normal.Checked = True
            Rdb_Codigo_De_Barras.Checked = _RowFuncion.Item("Codigo_De_Barras")
            Rdb_CodigoQR.Checked = _RowFuncion.Item("CodigoQR")

        End Set

    End Property

    Public Property Pro_Sol_Prod_Bodega As Boolean
        Get
            Return _Sol_Prod_Bodega
        End Get
        Set(value As Boolean)
            _Sol_Prod_Bodega = value
            Chk_Sol_Bodega.Checked = _Sol_Prod_Bodega
            Chk_Sol_Bodega.Visible = _Sol_Prod_Bodega
            If _Sol_Prod_Bodega Then
                Chk_Cheque.Enabled = False
                Cmb_Seccion.SelectedValue = "E"
                Cmb_Seccion.Enabled = False
            End If
        End Set
    End Property

    Public Sub New(ByVal Id As Integer, ByVal Es_Cheque As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Chk_Cheque.Checked = Es_Cheque

        Sb_Cargar_Combos()
        _Id = Id

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Formato_Creador_Funciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim _Ds As DataSet

        Dim _Tbl_Encabezado As DataTable
        Dim _Tbl_Detalle As DataTable

        If Pro_Sol_Prod_Bodega Then

            Dim _Nokosu = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", "EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "'")
            Dim _Nokobo = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO", "EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "'")

            Consulta_sql = "Select FLOOR(RAND()*(999-1)+1) As Id,'0060000005' As CodSolicitud,'PRB' As Estado," &
                           "'" & FUNCIONARIO & "' As Funcionario,'" & Nombre_funcionario_activo & "' As Nokofu," &
                           "'CODIGOXXXXXYZ' As Codigo," &
                           "'DESCRIPCION DEL PRODUCTO CINCUENTA CARACTERES..XYZ' As Descripcion," &
                           "'" & ModEmpresa & "' As Empresa,'" & ModSucursal & "' As Sucursal,'" & ModBodega & "' As Bodega," &
                           "'" & RazonEmpresa & "' As Razon,'" & _Nokosu & "' As Nokosu,'" & _Nokobo & "' As Nokobo," &
                           "'UBICACION Z-1' As Ubicacion," &
                           "FLOOR(RAND()*(999-1)+1) As StockUd1," &
                           "FLOOR(RAND()*(999-1)+1) As StockUd2," &
                           "Convert(Date, Getdate()) As Fecha," &
                           "CONVERT(VARCHAR, Getdate(), 108) As Hora," &
                           "Cast(1 As Bit) As Impreso"
            _Row_Prod_SolBodega = _Sql.Fx_Get_DataRow(Consulta_sql)

        Else

            If Chk_Cheque.Checked Then

                Consulta_sql = My.Resources.Recursos_Formato_Documento.SQLQuery_Traer_Cheque_Letra_Para_Imprimir
                Consulta_sql = Replace(Consulta_sql, "#Idmaedpce#", _Id)

                _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

                _Row_Maedpce = _Ds.Tables(0).Rows(0)
                _Tbl_Maeedo = _Ds.Tables(1)
                _Row_Maedpce = Fx_New_Inserta_Funciones_Bk_En_Encabezado_Cheque(_Row_Maedpce)

            Else

                Consulta_sql = My.Resources.Recursos_Formato_Documento.SQLQuery_Traer_Documento_Para_Imprimir
                Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _Id)
                Consulta_sql = Replace(Consulta_sql, "#Condicion_Extra_Maeddo#", "")
                Consulta_sql = Replace(Consulta_sql, "#Orden_Detalle#", "Order By IDMAEDDO")

                _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

                _Row_Maeedo = _Ds.Tables(0).Rows(0)
                _Tbl_Maeddo = _Ds.Tables(1)
                _Row_Maeedo = Fx_New_Inserta_Funciones_Bk_En_Encabezado(_Row_Maeedo)

                Dim _Tido As String = _Row_Maeedo.Item("TIDO")

                If _Tido.Contains("GRP") Or _Tido.Contains("GDP") Then

                    Consulta_sql = "Declare @Id_Ot_Padre Int 

                            Set @Id_Ot_Padre = (Select Top 1 Id_Ot_Padre From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Idmaeedo_" & _Tido & "_PRE = " & _Id & ")

                            Select ZEnc.Id_Ot, ZEnc.Nro_Ot,Empresa,ZEnc.Sucursal,ZEnc.Bodega,ZEnc.CodEntidad,ZEnc.SucEntidad,ZEnc.Rten,ZEnc.Rut, 
                            NOKOEN As Cliente,ZEnc.Fecha_Ingreso,ZEnc.Fecha_Compromiso,ZEnc.Fecha_Entrega,ZEnc.Fecha_Cierre,ZEnc.CodEstado, 
                            IsNull(ZCarac1.NombreTabla,'') As 'Estado',ZEnc.CodMaquina,ZEnc.CodMarca,ZEnc.CodModelo,ZEnc.CodCategoria,ZEnc.NroSerie,ZEnc.Chk_Serv_Domicilio,
	                        ZEnc.Pais,ZEnc.Ciudad,ZEnc.Comuna,ZEnc.Direccion,ZEnc.Nombre_Contacto,ZEnc.Telefono_Contacto,ZEnc.Email_Contacto,ZEnc.Chk_Serv_Reparacion_Stock,
	                        ZEnc.Chk_Serv_Mantenimiento_Correctivo,ZEnc.Chk_Serv_Presupuesto_Pre_Aprobado,ZEnc.Chk_Serv_Recoleccion,ZEnc.Chk_Serv_Mantenimiento_Preventivo,ZEnc.Chk_Serv_Garantia,
                            ZEnc.Chk_Serv_Demostracion_Maquina,ZEnc.CodTecnico_Asignado,Isnull(ZTecAsig.NomFuncionario,'') As Tecnico_Asignado,
                            ZEnc.CodTecnico_Repara,Isnull(ZTecRep.NomFuncionario,'') As Tecnico_Repara,IsNull(ZCarac2.NombreTabla,'') As Estado_Entrega, 
                            Chk_Equipo_Abandonado_Por_El_Cliente,Chk_No_Existe_COV_Ni_NVV,Codigo,Descripcion,Idmaeedo_GRP_PRE,Idmaeedo_GDP_PRE,
	                        Defecto_segun_cliente, Reparacion_a_realizar, Defecto_encontrado, Reparacion_Realizada, Chk_no_se_pudo_reparar, 
                            Motivo_no_reparo,Nota_Etapa_01,Nota_Etapa_02,Nota_Etapa_03,Nota_Etapa_04,Nota_Etapa_05,Nota_Etapa_06,Nota_Etapa_07,Nota_Etapa_08
                            From " & _Global_BaseBk & "Zw_St_OT_Encabezado ZEnc
	                            Inner Join " & _Global_BaseBk & "Zw_St_OT_Notas ZNotas On ZEnc.Id_Ot = ZNotas.Id_Ot
		                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones ZCarac1 On ZCarac1.Tabla = 'ESTADOS_ST' And ZCarac1.CodigoTabla = CodEstado
			                            Left Join " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller ZTecAsig On ZTecAsig.CodFuncionario = ZEnc.CodTecnico_Asignado
				                            Left Join " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller ZTecRep On ZTecRep.CodFuncionario = ZEnc.CodTecnico_Asignado
					                            Left Join MAEEN On KOEN = ZEnc.CodEntidad And SUEN = ZEnc.SucEntidad
						                                Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones ZCarac2 On ZCarac2.Tabla = 'ES_ENTREGA_ST' And ZCarac2.CodigoTabla =  Cod_Estado_Entrega
                            Where ZEnc.Id_Ot_Padre = @Id_Ot_Padre"

                    _Row_Servicio_Tecnico_Enc = _Sql.Fx_Get_DataRow(Consulta_sql)

                End If

            End If

            _Tbl_Encabezado = _Ds.Tables(0)
            _Tbl_Detalle = _Ds.Tables(1)

        End If

        Chk_Query_Personalizada.Enabled = True

    End Sub

    Sub Sb_Cargar_Combos()

        Dim _Arr_Seccion(,) As String = {{"", ""},
                                         {"D", "Detalle"},
                                         {"E", "Encabezado"},
                                         {"P", "Pie"}}
        Sb_Llenar_Combos(_Arr_Seccion, Cmb_Seccion)
        Cmb_Seccion.SelectedValue = ""

        Dim _Arr_Tipo_Dato(,) As String = {{"", ""},
                                         {"C", "Carácter"},
                                         {"F", "Fecha"},
                                         {"N", "Numerico"}}
        Sb_Llenar_Combos(_Arr_Tipo_Dato, Cmb_Tipo_Dato)
        Cmb_Tipo_Dato.SelectedValue = ""

        Consulta_sql = "SELECT CodigoTabla" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'SQL_COMMAND'"
        _Tbl_Comandos_SQL = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Private Sub Btn_Grabar_Funcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar_Funcion.Click

        If String.IsNullOrEmpty(Trim(Txt_Nombre_Funcion.Text)) Then
            MessageBoxEx.Show(Me, "Nombre no puede estar en blanco", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not Chk_Funcion_BakApp.Checked Then
            If Not Fx_New_Revisar_Formula() Then
                Return
            End If
        End If

        Consulta_sql = String.Empty

        Dim _Nombre_Funcion As String = Txt_Nombre_Funcion.Text.Trim

        Dim _Funcion_Bk As Integer = CInt(Chk_Funcion_BakApp.Checked) * -1
        Dim _Borde_Variable As Integer = CInt(Chk_Borde_Variable.Checked) * -1
        Dim _Codigo_De_Barras As Integer = CInt(Rdb_Codigo_De_Barras.Checked) * -1
        Dim _CodigoQR As Integer = CInt(Rdb_CodigoQR.Checked) * -1
        Dim _Es_Descuento As Integer = CInt(Chk_Es_Descuento.Checked) * -1
        Dim _Es_Cheque As Integer = CInt(Chk_Cheque.Checked) * -1
        Dim _Es_Sol_Bodega As Integer = CInt(Chk_Sol_Bodega.Checked) * -1
        Dim _SQL_Personalizada As Integer = CInt(Chk_Query_Personalizada.Checked) * -1

        If Chk_Funcion_BakApp.Checked Then
            Cmb_Tipo_Dato.SelectedValue = "C"
        End If

        Dim _SqlQuery As String = Replace(Txt_SqlQuery.Text, "'", "''")
        Dim _Descripcion_Funcion = Trim(Txt_Descripcion_Funcion.Text)

        Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Format_Fx",
                                                       "Nombre_Funcion = '" & Trim(Txt_Nombre_Funcion.Text) & "'" & Space(1) &
                                                       "And Cheque = " & CInt(Chk_Cheque.Checked) * -1)

        If Txt_Nombre_Funcion.ReadOnly Then
            _Reg = False
        End If

        If _Reg Then
            MessageBoxEx.Show(Me, "La función " & _Nombre_Funcion & " ya extiste",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            If Chk_Query_Personalizada.Checked And IsNothing(_RowFuncion) Then
                _Nombre_Funcion += Space(1) & "(P.SQLQuery)"
            End If

            If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Format_Fx", "SQL_Personalizada") Then

                Consulta_sql += "INSERT INTO " & _Global_BaseBk & "Zw_Format_Fx (Seccion,Nombre_Funcion,Funcion_Bk,Tipo_de_dato," &
                                "Formato,SqlQuery,Borde_Variable,Campo,Codigo_De_Barras,Es_Descuento,Descripcion_Funcion,Cheque,Sol_Bodega,SQL_Personalizada,CodigoQR) Values " &
                                "('" & Cmb_Seccion.SelectedValue & "','" & _Nombre_Funcion &
                                "'," & _Funcion_Bk & ",'" & Cmb_Tipo_Dato.SelectedValue & "','" & Txt_Formato.Text &
                                "','" & _SqlQuery & " '," & _Borde_Variable &
                                ",'" & Trim(Txt_Columna.Text) & "'," & _Codigo_De_Barras & "," &
                                _Es_Descuento & ",'" &
                                _Descripcion_Funcion & "'," &
                                _Es_Cheque & "," &
                                _Es_Sol_Bodega & "," &
                                _SQL_Personalizada & "," &
                                _CodigoQR & ")" & vbCrLf

            Else

                Consulta_sql += "INSERT INTO " & _Global_BaseBk & "Zw_Format_Fx (Seccion,Nombre_Funcion,Funcion_Bk,Tipo_de_dato," &
                                "Formato,SqlQuery,Borde_Variable,Campo,Codigo_De_Barras,Es_Descuento,Descripcion_Funcion,Cheque,Sol_Bodega,CodigoQR) Values " &
                                "('" & Cmb_Seccion.SelectedValue & "','" & _Nombre_Funcion &
                                "'," & _Funcion_Bk & ",'" & Cmb_Tipo_Dato.SelectedValue & "','" & Txt_Formato.Text &
                                "','" & _SqlQuery & " '," & _Borde_Variable &
                                ",'" & Trim(Txt_Columna.Text) & "'," & _Codigo_De_Barras & "," &
                                _Es_Descuento & ",'" &
                                _Descripcion_Funcion & "'," &
                                _Es_Cheque & "," &
                                _Es_Sol_Bodega & "," &
                                _CodigoQR & ")" & vbCrLf

            End If

            If Not IsNothing(_RowFuncion) Then

                Dim _Id = _RowFuncion.Item("Id")

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Format_Fx Where Id = " & _Id & vbCrLf & vbCrLf &
                                Consulta_sql
            End If

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                If _Cerrar_Al_Grabar Then
                    _Grabar = True
                    Me.Close()
                Else
                    Txt_Nombre_Funcion.Text = String.Empty
                    Txt_Nombre_Funcion.Focus()
                    Beep()
                    ToastNotification.Show(Me, "FUNCION INCORPORADA CORRECTAMENTE",
                                          My.Resources.save,
                                         2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If
            End If
        End If

    End Sub

    Private Sub Btn_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Documentos.Click

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Documentos)
        Fm.Pro_Tbl_Filtro = _Tbl_Documentos
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _Tbl_Documentos = Fm.Pro_Tbl_Filtro
            If (_Tbl_Documentos Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                'Rdb_Super_Familia_Todos.Checked = True
            End If
            'Else
            'Rdb_Super_Familia_Todos.Checked = True
        End If

    End Sub

    Private Sub Btn_Validar_Funcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Validar_Funcion.Click

        If Fx_New_Revisar_Formula() Then

            Dim _Dato

            Dim _Tbl As DataTable
            Dim _Row As DataRow

            Dim _Es_Documento As Boolean

            If Chk_Sol_Bodega.Checked Then
                _Row = _Row_Prod_SolBodega
            Else
                If Chk_Cheque.Checked Then
                    _Tbl = _Tbl_Maeedo
                    _Row = _Row_Maedpce
                Else
                    _Tbl = _Tbl_Maeddo
                    _Row = _Row_Maeedo
                    _Es_Documento = True
                End If
            End If

            If Cmb_Tipo_Dato.SelectedValue = "F" Then
                If String.IsNullOrEmpty(Txt_Formato.Text) Then
                    Txt_Formato.Text = "DD/MM/AAAA"
                End If
            End If

            If Cmb_Seccion.SelectedValue = "D" Then

                _Row = _Tbl.Rows(0)
                Dim _Campo As String = Txt_Columna.Text

                Dim _Moneda_Str As String = "$"

                If _Es_Documento Then
                    _Moneda_Str = _Row.Item("MOPPPR").ToString.Trim
                End If

                If Chk_Query_Personalizada.Checked Then

                    Dim _Error As String

                    _Id = _Row.Item("IDMAEDDO")

                    _Row = Fx_Funcion_SQL_Personalizada_Detalle(Txt_SqlQuery.Text, _Id, _Error)

                    If String.IsNullOrEmpty(_Error) Then
                        _Campo = "CAMPO"
                    Else
                        MessageBoxEx.Show(Me, _Error, "Error en consulta SQL Personalizada", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If

                _Dato = Fx_New_Trae_Valor_Detalle_Row(_Campo,
                                                      Cmb_Tipo_Dato.SelectedValue,
                                                      Chk_Es_Descuento.Checked,
                                                      _Row,
                                                      Txt_Formato.Text,
                                                      _Moneda_Str)

            Else

                Dim _Tido As String = _Row_Maeedo.Item("TIDO")
                Dim _Campo As String = Txt_Columna.Text

                Dim _Moneda_Str As String = "$"

                If _Es_Documento Then
                    _Moneda_Str = _Row.Item("MODO").ToString.Trim
                End If

                If _Campo.Contains("STEC_") Then

                    If _Tido.Contains("GRP") Or _Tido.Contains("GDP") Then
                        _Row = _Row_Servicio_Tecnico_Enc
                    End If

                    _Campo = Replace(_Campo, "STEC_", "")

                End If

                If Chk_Query_Personalizada.Checked Then

                    Dim _Error As String

                    _Row = Fx_Funcion_SQL_Personalizada_Enc_Pie(Txt_SqlQuery.Text, _Id, _Error)

                    If String.IsNullOrEmpty(_Error) Then
                        _Campo = "CAMPO"
                    Else
                        MessageBoxEx.Show(Me, _Error, "Error en consulta SQL Personalizada", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If

                If IsNothing(_Row) Then
                    _Dato = "No existe información Para la Query, pruebe con otro documento o entidad"
                Else

                    _Dato = Fx_New_Trae_Valor_Encabezado_Row(_Campo,
                                                             Cmb_Tipo_Dato.SelectedValue,
                                                             Chk_Es_Descuento.Checked,
                                                             _Row,
                                                             Txt_Formato.Text,
                                                             _Moneda_Str)

                End If

            End If

            If Not (_Dato Is Nothing) Then

                MessageBoxEx.Show(Me, _Dato, "Valor encontrado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Private Sub Sb_Txt_SqlQuery_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Posicion As Integer = Txt_SqlQuery.SelectionStart

        'Txt_SqlQuery.SelectionStart = 0
        Txt_SqlQuery.SelectionLength = _Posicion
        Txt_SqlQuery.SelectionColor = Color.Black

        Sb_Cambiar_Color(_Posicion, Txt_SqlQuery, _Tbl_Comandos_SQL)
        Txt_SqlQuery.SelectionStart = _Posicion

    End Sub

    Private Sub Frm_Formato_Creador_Funciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Function Fx_New_Revisar_Formula()

        Dim _Valor
        Dim _Campo As String = Trim(Txt_Columna.Text)

        Try

            If Chk_Query_Personalizada.Checked Then

                Dim _SqlQuery As String = UCase(Txt_SqlQuery.Text.Trim)

                If _SqlQuery.Contains("INSERT") Or _SqlQuery.Contains("UPDATE") Or _SqlQuery.Contains("DELETE") Then
                    MessageBoxEx.Show(Me, "NO SE PUEDEN UTILIZAR LOS COMANDOS (INSERT, DELETE, UPDATE)", "VALIDACION",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                Return True

            End If

            If String.IsNullOrEmpty(_Campo) Then
                If Not Chk_Funcion_BakApp.Checked Then
                    MessageBoxEx.Show(Me, "Falta el nombre del campo", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Return False
            End If

            If Chk_Sol_Bodega.Checked Then
                _Valor = _Row_Prod_SolBodega.Item(_Campo)
            Else
                If Chk_Cheque.Checked Then
                    'CHEQUES
                    If Cmb_Seccion.SelectedValue = "D" Then
                        _Valor = _Tbl_Maeedo.Rows(0).Item(_Campo)
                    Else
                        _Valor = _Row_Maedpce.Item(_Campo)
                    End If
                Else
                    'FACTURAS, ETC
                    If Cmb_Seccion.SelectedValue = "D" Then
                        _Valor = _Tbl_Maeddo.Rows(0).Item(_Campo)
                    Else

                        Dim _Tido As String = _Row_Maeedo.Item("TIDO")
                        Dim _Row As DataRow = _Row_Maeedo

                        If _Campo.Contains("STEC_") Then

                            If _Tido.Contains("GRP") Or _Tido.Contains("GDP") Then
                                _Row = _Row_Servicio_Tecnico_Enc
                            End If
                            _Campo = Replace(_Campo, "STEC_", "")

                        End If

                        _Valor = _Row.Item(_Campo)

                    End If

                End If

            End If

            Return True

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        End Try

    End Function

#Region "OLD FUNCIONES BAKAPP"

    Function Fx_Old_Trae_Funcion_Bk(ByVal _Nombre_Funcion As String,
                                ByVal _TblDocumento As DataTable)
        Dim _Valor
        Dim _Idmaeedo = _TblDocumento.Rows(0).Item("IDMAEEDO")
        Dim _Koen = _TblDocumento.Rows(0).Item("ENDO")
        Dim _Suen = _TblDocumento.Rows(0).Item("SUENDO")

        Select Case _Nombre_Funcion
            Case "Rut Entidad"

                _Valor = _Sql.Fx_Trae_Dato("MAEEN", "RTEN", "KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'")
                _Valor = Fx_Old_Rut(Trim(_Valor))

            Case "Total Escrito(1) Bruto"

                _Valor = _Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

                Dim _Palabra = UCase(Letras(_Valor))
                Dim _Palabra1, _Palabra2

                _Palabra1 = Mid(_Palabra, 1, 50)
                _Palabra2 = Mid(_Palabra, 51, 100)

                If String.IsNullOrEmpty(_Palabra2) Then
                    If Len(_Palabra1) <= 44 Then
                        _Palabra1 += "pesos"
                    End If
                End If

                _Valor = Rellenar(_Palabra1, 50, "-", True)

            Case "Total Escrito(2) Bruto"

                _Valor = _Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

                Dim _Palabra = UCase(Letras(_Valor))
                Dim _Palabra1, _Palabra2

                _Palabra1 = Mid(_Palabra, 1, 50)
                _Palabra2 = Mid(_Palabra, 51, 100)

                If Not String.IsNullOrEmpty(_Palabra2) Then
                    If Len(_Palabra2) <= 44 Then
                        _Palabra2 += "pesos"
                    End If
                Else
                    If Len(_Palabra1) > 44 Then
                        _Palabra2 += "pesos"
                    End If
                End If

                '_Palabra = Mid(_Palabra, 51, 100)
                _Valor = Rellenar(_Palabra2, 50, "-", True)

            Case "Caja Modalidad (Codigo)"

                _Valor = _Global_Row_Configuracion_Estacion.Item("ECAJA")

            Case "Caja Modalidad (Nombre)"

                Dim _Empresa = _Global_Row_Configuracion_Estacion.Item("ECAJA")
                Dim _Kosu = _Global_Row_Configuracion_Estacion.Item("ESUCURSAL")
                Dim _Kocj = _Global_Row_Configuracion_Estacion.Item("ECAJA")

                _Valor = _Sql.Fx_Trae_Dato("TABCJ", "NOKOCJ",
                                           "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Kosu & "' And KOCJ = '" & _Kocj & "'")

            Case "Sucursal Modalidad (Codigo)"

                _Valor = _Global_Row_Configuracion_Estacion.Item("ESUCURSAL")

            Case "Sucursal Modalidad (Nombre)"

                Dim _Empresa = _Global_Row_Configuracion_Estacion.Item("ECAJA")
                Dim _Kosu = _Global_Row_Configuracion_Estacion.Item("ESUCURSAL")

                _Valor = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU",
                                           "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Kosu & "'")


        End Select

        Return _Valor

    End Function

    Function Fx_Old_Rut(ByVal Rut As String) As String

        Dim _R = De_Txt_a_Num_01(Rut, 0)
        Dim _Rut = FormatNumber(_R, 0) & " - " & RutDigito(_R)

        Return _Rut

    End Function

    'Function Fx_Old_Trae_Valor_Encabezado_Pie(ByVal _Row_Maeedo As DataRow,
    '                                             ByVal _Row_Zw_Format_Fx As DataRow,
    '                                             Optional ByVal _Formato As String = "",
    '                                             Optional ByVal _Idmaeddo As Integer = 0)

    '    Dim _Valor As String
    '    Dim _Nombre_Funcion As String = _Row_Zw_Format_Fx.Item("Nombre_Funcion")
    '    'Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) & _
    '    '               "Where Nombre_Funcion = '" & _Nombre_Funcion & "'"

    '    'Dim _RowFuncion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '    If Not (_Row_Zw_Format_Fx Is Nothing) Then

    '        Dim _Funcion_Bk = _Row_Zw_Format_Fx.Item("Funcion_Bk")
    '        Dim _Tipo_de_dato = _Row_Zw_Format_Fx.Item("Tipo_de_dato")

    '        If String.IsNullOrEmpty(_Formato) Then _Formato = _Row_Zw_Format_Fx.Item("Formato")

    '        Dim _SqlQuery = _Row_Zw_Format_Fx.Item("SqlQuery")

    '        If _Funcion_Bk Then

    '            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Id
    '            Dim _Tb As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

    '            'Return Fx_Trae_Funcion_Bk(_Nombre_Funcion, _Tb)

    '        Else

    '            Dim _Sql_Declare = "Declare @Idmaeedo Int,@Idmaeddo Int,@Kopr Char(13),@Koen Char(13),@Suen Char(20)" & vbCrLf &
    '                               "Set @Idmaeedo = " & _Id & vbCrLf &
    '                               "Set @Idmaeddo = " & _Idmaeddo & vbCrLf &
    '                               "Set @Kopr = (SELECT Top 1 KOPRCT FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)" & vbCrLf &
    '                               "Set @Koen = (SELECT ENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf &
    '                               "Set @Suen = (SELECT SUENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf & vbCrLf &
    '                               _SqlQuery

    '            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(UCase(_Sql_Declare))

    '            If CBool(_Tbl.Rows.Count) Then

    '                _Valor = _Tbl.Rows(0).Item("CAMPO")
    '                Dim _Cant_Caracteres As Integer = Len(_Formato)

    '                Select Case _Tipo_de_dato

    '                    Case "N"

    '                        Dim _Div = Split(_Formato, ",", 2)
    '                        Dim _Decimales = 0

    '                        If _Div.Length = 2 Then
    '                            _Decimales = Len(_Div(1))
    '                        End If

    '                        Dim _Precio = FormatNumber(_Valor, _Decimales)

    '                        If Mid(_Formato, 1, 1) = 9 Then
    '                            _Precio = Rellenar(_Precio, _Cant_Caracteres, " ", False)
    '                        End If

    '                        _Valor = _Precio

    '                    Case "C"

    '                        _Valor = Trim(Mid(_Valor, 1, _Cant_Caracteres))

    '                    Case "F"

    '                        Dim _FValor As Date = _Tbl.Rows(0).Item("CAMPO")

    '                        If _Formato = "DD/MM/AAAA" Then
    '                            _Valor = Format(_FValor, "dd/MM/yyyy")
    '                        ElseIf _Formato = "DD-MM-AAAA" Then
    '                            _Valor = Format(_FValor, "dd-MM-yyyy")
    '                        Else
    '                            _Valor = FormatDateTime(_Valor, DateFormat.LongDate)
    '                        End If

    '                End Select

    '            End If


    '        End If

    '    Else
    '        Return "Fx????"
    '    End If

    '    Return _Valor

    'End Function

    'Function Fx_Old_Trae_Valor(ByVal _Idmaeedo As Integer,
    '                       ByVal _Nombre_Funcion As String,
    '                       Optional ByVal _Formato As String = "",
    '                       Optional ByVal _Idmaeddo As Integer = 0)

    '    Dim _Valor As String

    '    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
    '                   "Where Nombre_Funcion = '" & _Nombre_Funcion & "'"

    '    Dim _RowFuncion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '    If Not (_RowFuncion Is Nothing) Then

    '        Dim _Funcion_Bk = _RowFuncion.Item("Funcion_Bk")
    '        Dim _Tipo_de_dato = _RowFuncion.Item("Tipo_de_dato")

    '        If String.IsNullOrEmpty(_Formato) Then _Formato = _RowFuncion.Item("Formato")

    '        Dim _SqlQuery = _RowFuncion.Item("SqlQuery")

    '        If _Funcion_Bk Then

    '            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
    '            Dim _Tb As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

    '            'Return Fx_Trae_Funcion_Bk(_Nombre_Funcion, _Tb)

    '        Else

    '            Dim _Sql_Declare = "Declare @Idmaeedo Int,@Idmaeddo Int,@Kopr Char(13),@Koen Char(13),@Suen Char(20)" & vbCrLf &
    '                               "Set @Idmaeedo = " & _Idmaeedo & vbCrLf &
    '                               "Set @Idmaeddo = " & _Idmaeddo & vbCrLf &
    '                               "Set @Kopr = (SELECT Top 1 KOPRCT FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)" & vbCrLf &
    '                               "Set @Koen = (SELECT ENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf &
    '                               "Set @Suen = (SELECT SUENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf & vbCrLf &
    '                               _SqlQuery

    '            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(UCase(_Sql_Declare))

    '            If CBool(_Tbl.Rows.Count) Then

    '                _Valor = _Tbl.Rows(0).Item("CAMPO")
    '                Dim _Cant_Caracteres As Integer = Len(_Formato)

    '                Select Case _Tipo_de_dato

    '                    Case "N"

    '                        Dim _Div = Split(_Formato, ",", 2)
    '                        Dim _Decimales = 0

    '                        If _Div.Length = 2 Then
    '                            _Decimales = Len(_Div(1))
    '                        End If

    '                        Dim _Precio = FormatNumber(_Valor, _Decimales)

    '                        If Mid(_Formato, 1, 1) = 9 Then
    '                            _Precio = Rellenar(_Precio, _Cant_Caracteres, " ", False)
    '                        End If

    '                        _Valor = _Precio

    '                    Case "C"

    '                        _Valor = Trim(Mid(_Valor, 1, _Cant_Caracteres))

    '                    Case "F"

    '                        Dim _FValor As Date = _Tbl.Rows(0).Item("CAMPO")

    '                        If _Formato = "DD/MM/AAAA" Then
    '                            _Valor = Format(_FValor, "dd/MM/yyyy")
    '                        ElseIf _Formato = "DD-MM-AAAA" Then
    '                            _Valor = Format(_FValor, "dd-MM-yyyy")
    '                        Else
    '                            _Valor = FormatDateTime(_Valor, DateFormat.LongDate)
    '                        End If

    '                End Select

    '            End If


    '        End If

    '    Else
    '        Return "Fx????"
    '    End If

    '    Return _Valor

    'End Function

    'Function Fx_Old_Trae_Valor_Detalle(ByVal _Nombre_Funcion As String,
    '                               ByVal _RowDetalle As DataRow,
    '                               Optional ByVal _Formato As String = "")

    '    Dim _Valor As String

    '    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_Fx" & Space(1) &
    '                   "Where Nombre_Funcion = '" & _Nombre_Funcion & "'"

    '    Dim _RowFuncion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '    If Not (_RowFuncion Is Nothing) Then

    '        Dim _Funcion_Bk = _RowFuncion.Item("Funcion_Bk")
    '        Dim _Tipo_de_dato = _RowFuncion.Item("Tipo_de_dato")
    '        Dim _Campo = Trim(_RowFuncion.Item("Campo"))

    '        If String.IsNullOrEmpty(_Formato) Then _Formato = _RowFuncion.Item("Formato")

    '        Dim _SqlQuery = _RowFuncion.Item("SqlQuery")

    '        If _Funcion_Bk Then

    '            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Id
    '            Dim _Tb As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

    '            ' Return Fx_Trae_Funcion_Bk(_Nombre_Funcion, _Tb)

    '        Else


    '            _Valor = _RowDetalle.Item(_Campo)
    '            Dim _Cant_Caracteres As Integer = Len(_Formato)

    '            Select Case _Tipo_de_dato

    '                Case "N"

    '                    Dim _Precio = FormatNumber(Val(_Valor), 0)
    '                    _Precio = Rellenar(_Precio, _Cant_Caracteres, " ", False)
    '                    _Valor = _Precio

    '                Case "C"

    '                    _Valor = Trim(Mid(_Valor, 1, _Cant_Caracteres))

    '                Case "F"

    '                    Dim _FValor As Date = _RowDetalle.Item(_Campo)

    '                    If _Formato = "DD/MM/AAAA" Then
    '                        _Valor = Format(_FValor, "dd/MM/yyyy")
    '                    ElseIf _Formato = "DD-MM-AAAA" Then
    '                        _Valor = Format(_FValor, "dd-MM-yyyy")
    '                    Else
    '                        _Valor = FormatDateTime(_Valor, DateFormat.LongDate)
    '                    End If

    '            End Select

    '        End If

    '    End If


    '    Return _Valor

    'End Function

    'Function Fx_Old_Revisar_Formula(_SqlQuery As String,
    '                                _Idmaeedo As Integer,
    '                                _Idmaeddo As Integer,
    '                                _Mostra_Dato As Boolean)

    '    Try

    '        If String.IsNullOrEmpty(Trim(_SqlQuery)) Then
    '            MessageBoxEx.Show(Me, "No puede dejar la función en blanco", "Validación",
    '                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '            Return False
    '        End If

    '        _SqlQuery = "Declare @Idmaeedo Int,@Idmaeddo Int,@Kopr Char(13),@Koen Char(13),@Suen Char(20)" & vbCrLf &
    '                    "Set @Idmaeedo = " & _Idmaeedo & vbCrLf &
    '                    "Set @Idmaeddo = " & _Idmaeddo & vbCrLf &
    '                    "Set @Kopr = (SELECT Top 1 KOPRCT FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)" & vbCrLf &
    '                    "Set @Koen = (SELECT ENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf &
    '                    "Set @Suen = (SELECT SUENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf & vbCrLf &
    '                    _SqlQuery

    '        _SqlQuery = UCase(_SqlQuery)

    '        Consulta_sql = "SELECT CodigoTabla" & vbCrLf &
    '                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
    '                       "WHERE Tabla = 'SQL_COMMAND' And Valor = 0"

    '        Dim _TblSql As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

    '        If _TblSql.Rows.Count Then

    '            For Each _Fila As DataRow In _TblSql.Rows

    '                Dim _Comando = UCase(_Fila.Item("CodigoTabla"))

    '                If _SqlQuery.Contains(_Comando) Then
    '                    MessageBoxEx.Show(Me, "NO SE PUEDEN UTILIZAR LOS COMANDOS (INSERT, DELETE, UPDATE, REPLACE)", "VALIDACION",
    '                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                    Return False
    '                End If

    '            Next

    '        End If

    '        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

    '            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_SqlQuery)

    '            If CBool(_Tbl.Rows.Count) Then
    '                If _Mostra_Dato Then
    '                    Return _Tbl.Rows(0).Item("CAMPO")
    '                Else
    '                    Return True
    '                End If
    '            Else
    '                Return True
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MessageBoxEx.Show(Me, ex.Message)
    '    End Try

    'End Function

#End Region

    Private Sub Btn_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documento.Click

        If Chk_Cheque.Checked Then
            Dim Fm_C As New Frm_Pagos_Documentos_Pagados(_Id)
            Fm_C.ShowDialog(Me)
            Fm_C.Dispose()
        Else
            Dim Fm_D As New Frm_Ver_Documento(_Id, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm_D.ShowDialog(Me)
            Fm_D.Dispose()
        End If

    End Sub

    Private Sub Chk_Query_Personalizada_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Query_Personalizada.CheckedChanged

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Format_Fx", "SQL_Personalizada") Then
            Txt_SqlQuery.Enabled = Chk_Query_Personalizada.Checked
            GroupPanel3.Enabled = Chk_Query_Personalizada.Checked
        Else
            If Chk_Query_Personalizada.Checked Then
                MessageBoxEx.Show(Me, "Falta el campo SQL_Personalizada de la tabla Zw_Format_Fx" & vbCrLf &
                              "Debe crear el campo en la tabla para poder habilitar esta opción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Chk_Query_Personalizada.Checked = False
            End If
        End If

    End Sub

    Private Sub Btn_Ayuda_Sql_Query_Click(sender As Object, e As EventArgs) Handles Btn_Ayuda_Sql_Query.Click

        Dim _SqlQuery As String

        Select Case Cmb_Seccion.SelectedValue

            Case "D"

                _SqlQuery = "Declare @Idmaeddo Int,@Kopr Char(13),@Nokopr Varchar(50),@Empresa Char(2),@Sucursal Char(3),@Bodega Char(3),@Cantidad1 Float,@Cantidad2 Float" & vbCrLf &
                            "Select @Idmaeddo = <Idmaeddo>" & vbCrLf &
                            "Select " & vbCrLf &
                            "@Kopr = (SELECT KOPRCT FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                            "@Nokopr = (SELECT NOKOPR FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                            "@Empresa = (SELECT EMPRESA FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                            "@Sucursal = (SELECT SULIDO FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                            "@Bodega = (SELECT BOSULIDO FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                            "@Cantidad1 = (SELECT CAPRCO1 FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)," & vbCrLf &
                            "@Cantidad2 = (SELECT CAPRCO2 FROM MAEDDO WHERE IDMAEDDO = @Idmaeddo)" & vbCrLf & vbCrLf &
                            "-- Puede usar la variable @Idmaeddo para buscar datos en algun documento" & vbCrLf &
                            "-- Ejemplo: Select Top 1 NOKOPR As CAMPO From MAEDDO Where IDMAEDDO = @Idmaeddo" & vbCrLf &
                            "-- Siempre se debe poner << As CAMPO >>"

            Case "E", "P"

                _SqlQuery = "Declare @Idmaeedo Int,@Idmaeddo Int,@Kopr Char(13),@Koen Char(13),@Suen Char(20)" & vbCrLf &
                            "Set @Idmaeedo = <Idmaeddo>" & vbCrLf &
                            "Set @Koen = (SELECT ENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf &
                            "Set @Suen = (SELECT SUENDO FROM MAEEDO WHERE IDMAEEDO = @Idmaeedo)" & vbCrLf & vbCrLf &
                            "-- Puede usar la variable @Idmaeedo para buscar datos en algun documento" & vbCrLf &
                            "-- Ejemplo: Select Top 1 NUDO As CAMPO From MAEEDO Where IDMAEEDO = @Idmaeedo" & vbCrLf &
                            "-- Siempre se debe poner << As CAMPO >>"

            Case Else

                _SqlQuery = "Debe seleccionar la sección si es en el Encabezad/Pio o Detalle"

        End Select

        MessageBoxEx.Show(Me, _SqlQuery & vbCrLf & vbCrLf & "Este texto esta en el portapapeles", "Información de ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Clipboard.SetText(_SqlQuery)

    End Sub

End Class
