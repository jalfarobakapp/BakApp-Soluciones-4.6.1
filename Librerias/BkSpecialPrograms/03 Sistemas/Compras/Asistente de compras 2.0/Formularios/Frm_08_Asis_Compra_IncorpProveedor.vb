﻿Imports DevComponents.DotNetBar

Public Class Frm_08_Asis_Compra_IncorpProveedor

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String = "Zw_InfCompras01" & FUNCIONARIO
    Dim _Tbl_Genericos As DataTable
    Dim _RowParametros As DataRow
    Dim _Proceso_Generado As Boolean

    Dim _Accion_Automatica As Boolean
    Public Property CodProveedor_Pstar As String
    Public Property CodSucProveedor_Pstar As String

    Public Property Accion_Automatica As Boolean
        Get
            Return _Accion_Automatica
        End Get
        Set(value As Boolean)
            _Accion_Automatica = value
        End Set
    End Property

    Public ReadOnly Property Pro_Proceso_Generado() As Boolean
        Get
            Return _Proceso_Generado
        End Get
    End Property

    Public Sub New(RowParametros As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Cargar_Combo_Dias(Cmb_Proyeccion_Metodo_Abastecer_)
        Sb_Cargar_Combo_Dias(Cmb_Proyeccion_Tiempo_Reposicion_)

        _RowParametros = RowParametros

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnProcesarInf.ForeColor = Color.White
            BtnEntidadesExcluidas.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_08_Asis_Compra_IncorpProveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim _Arr_Tipo_Documento(,) As String = {{"GRC", "Guía recepción compra (GRC)"},
                                                {"OCC", "Orden de compra (OCC)"},
                                                {"FCC", "Factura de compra (FCC)"}}

        Sb_Llenar_Combos(_Arr_Tipo_Documento, Cmb_Documento_Compra)
        Cmb_Documento_Compra.SelectedValue = "GRC"

        'Sb_Parametros_Informe_Conf_Local(True)

        '   Costos desde ultimo documento segun seleccion
        _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Lista_Proveedor, "Compras_Asistente",
                                             Rd_Costo_Lista_Proveedor.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Lista_Proveedor.Checked)
        '   Costos desde ultimo documento segun seleccion
        _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Ultimo_Documento_Seleccionado, "Compras_Asistente",
                                             Rd_Costo_Ultimo_Documento_Seleccionado.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Ultimo_Documento_Seleccionado.Checked)
        '   Costos de la lista del proveedor
        _Sql.Sb_Parametro_Informe_Sql(Cmb_Documento_Compra, "Compras_Asistente",
                                             Cmb_Documento_Compra.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Documento_Compra.SelectedValue)
        '   Costos de la lista del proveedor
        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Tope_Proveedores_Automaticos, "Compras_Asistente",
                                             Dtp_Fecha_Tope_Proveedores_Automaticos.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Tope_Proveedores_Automaticos.Value)

        ' Check para proveedor estrella de estudio para incorporar a proveedor con mejor precio.
        _Sql.Sb_Parametro_Informe_Sql(Chk_QuitarDeEstudioAutomatico, "Compras_Asistente",
                                      Chk_QuitarDeEstudioAutomatico.Name, Class_SQLite.Enum_Type._Boolean, Chk_QuitarDeEstudioAutomatico.Checked)


        Chk_QuitarDeEstudioAutomatico.Enabled = False

        Dtp_Fecha_Tope_Proveedores_Automaticos.Value = Primerdiadelmes(Dtp_Fecha_Tope_Proveedores_Automaticos.Value)

        Chk_Incluir_Ent_Excluidas.Enabled = True

        AddHandler Chk_MarcarProvQueNoTiene.CheckedChanged, AddressOf Chk_MarcarProvQueNoTiene_CheckedChanged

        If _Accion_Automatica Then
            Timer_Ejecucion_Automatica.Start()
        End If


    End Sub

    Private Sub BtnEntidadesExcluidas_Click(sender As System.Object, e As System.EventArgs) Handles BtnEntidadesExcluidas.Click
        Dim Fm As New Frm_EntExcluidas
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub BtnProcesarInf_Click(sender As System.Object, e As System.EventArgs) Handles BtnProcesarInf.Click

        If Not _Accion_Automatica Then
            If Chk_MarcarProvQueNoTiene.Checked And Input_DiasMarcarProvQueNoTiene.Value = 0 Then
                MessageBoxEx.Show(Me, "Debe poner la cantidad de días para saber cuando marcar a los proveedores con productos sin stock", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        _Proceso_Generado = Fx_Incorporar_Proveedores()

        If _Proceso_Generado Then

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Log_Compras Set" & vbCrLf &
                           "CantComprar = Tpaso.CantComprar," &
                           "CantSugeridaTot = Tpaso.CantSugeridaTot," &
                           "CodProveedor = Tpaso.CodProveedor," &
                           "CodSucProveedor = Tpaso.CodSucProveedor," &
                           "CodAlternativo = Tpaso.CodAlternativo" & vbCrLf &
                           "From " & _Tabla_Paso & " Tpaso" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_Prod_Log_Compras Zlog On Tpaso.Codigo = Zlog.Codigo" & vbCrLf &
                           "Where NombreEquipo = '" & _NombreEquipo & "' And CodFuncionario = '" & FUNCIONARIO & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)



            '   Costos desde ultimo documento segun seleccion
            _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Lista_Proveedor, "Compras_Asistente",
                                                 Rd_Costo_Lista_Proveedor.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Lista_Proveedor.Checked, True)
            '   Costos desde ultimo documento segun seleccion
            _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Ultimo_Documento_Seleccionado, "Compras_Asistente",
                                                 Rd_Costo_Ultimo_Documento_Seleccionado.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Ultimo_Documento_Seleccionado.Checked, True)
            '   Costos de la lista del proveedor
            _Sql.Sb_Parametro_Informe_Sql(Cmb_Documento_Compra, "Compras_Asistente",
                                                 Cmb_Documento_Compra.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Documento_Compra.SelectedValue, True)
            '   Costos de la lista del proveedor
            _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Tope_Proveedores_Automaticos, "Compras_Asistente",
                                                 Dtp_Fecha_Tope_Proveedores_Automaticos.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Tope_Proveedores_Automaticos.Value, True)


            Me.Close()
        End If

    End Sub

    Function Fx_Incorporar_Proveedores() As Boolean

        Dim _Codigo_Comprar As String
        Dim _Tbl_Codigos_Madre As DataTable

        Dim _Fecha As Date = Dtp_Fecha_Tope_Proveedores_Automaticos.Value

        Try

            Me.Enabled = False

            Dim _NoIncluirProveedoresConProdBloqueados As Boolean = True

            'BUSCA LA ULTIMA COMPRA DE LOS PRODUCTOS QUE NO ENCONTRO GRC DENTRO DE LA FECHA TOPE, ES DECIR

            Dim _QuitarProveedorStar As Boolean = True

            If _QuitarProveedorStar Then

                Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                _CodProveedor_Pstar = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                 "Valor",
                                                 "Informe = 'Compras_Asistente' And Campo = 'Koen_Especial' And NombreEquipo = '" & _NombreEquipo & "' " &
                                                 "And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Mod_Modalidad & "'")
                _CodSucProveedor_Pstar = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                        "Valor",
                                                        "Informe = 'Compras_Asistente' And Campo = 'Suen_Especial' And NombreEquipo = '" & _NombreEquipo & "' " &
                                                        "And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Mod_Modalidad & "'")

                'Consulta_sql = "Select * From MAEEN Where KOEN = '" & _CodProveedor_Pstar & "' And SUEN = '" & _CodSucProveedor_Pstar & "'"
                '_RowProveedorStar = _Sql.Fx_Get_DataRow(Consulta_sql)

            End If


            If _NoIncluirProveedoresConProdBloqueados Then

                If Chk_QuitarDeEstudioAutomatico.Checked AndAlso Not String.IsNullOrWhiteSpace(_CodProveedor_Pstar) Then

                    Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                                   "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                                   "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' and KOPRCT = Codigo" & vbCrLf &
                                   "And FEEMLI >= '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                                   "And ENDO+SUENDO Not In (Select CodEntidad+CodSucEntidad From " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos Z1 " &
                                   "Where Z1.Chk = 1 And Z1.CodEntidad+Z1.CodSucEntidad = ENDO+SUENDO And Z1.Codigo = KOPRCT)" & vbCrLf &
                                   "And ENDO <> '" & _CodProveedor_Pstar & "'" & vbCrLf &
                                   "Order by PPPRNERE1),0)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    'LITERALMETE LA ULTIMA VEZ QUE SE COMPRO EL PRODUCTO SIN IMPORTAR LA FECHA TOPE
                    Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                                   "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                                   "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' and KOPRCT = Codigo" & vbCrLf &
                                   "And ENDO+SUENDO Not In (Select CodEntidad+CodSucEntidad From " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos Z1 " &
                                   "Where Z1.Chk = 1 And Z1.CodEntidad+Z1.CodSucEntidad = ENDO+SUENDO And Z1.Codigo = KOPRCT)" & vbCrLf &
                                   "And ENDO <> '" & _CodProveedor_Pstar & "'" & vbCrLf &
                                   "Order by FEEMLI DESC),0)" & vbCrLf &
                                   "Where Id_Ult_Compra = 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                Else

                    Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                                   "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                                   "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' and KOPRCT = Codigo" & vbCrLf &
                                   "And FEEMLI >= '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                                   "And ENDO+SUENDO Not In (Select CodEntidad+CodSucEntidad From " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos Z1 " &
                                   "Where Z1.Chk = 1 And Z1.CodEntidad+Z1.CodSucEntidad = ENDO+SUENDO And Z1.Codigo = KOPRCT)" & vbCrLf &
                                   "Order by PPPRNERE1),0)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    'LITERALMETE LA ULTIMA VEZ QUE SE COMPRO EL PRODUCTO SIN IMPORTAR LA FECHA TOPE
                    Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                                   "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                                   "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' and KOPRCT = Codigo" & vbCrLf &
                                   "And ENDO+SUENDO Not In (Select CodEntidad+CodSucEntidad From " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos Z1 " &
                                   "Where Z1.Chk = 1 And Z1.CodEntidad+Z1.CodSucEntidad = ENDO+SUENDO And Z1.Codigo = KOPRCT)" & vbCrLf &
                                   "Order by FEEMLI DESC),0)" & vbCrLf &
                                   "Where Id_Ult_Compra = 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Else

                Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                               "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                               "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' and KOPRCT = Codigo" & vbCrLf &
                               "And FEEMLI >= '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                               "Where Z1.CodEntidad+Z1.CodSucEntidad = ENDO+SUENDO And Z1.Codigo = Codigo)" & vbCrLf &
                               "Order by PPPRNERE1),0)"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                'LITERALMETE LA ULTIMA VEZ QUE SE COMPRO EL PRODUCTO SIN IMPORTAR LA FECHA TOPE
                Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                               "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                               "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' and KOPRCT = Codigo" & vbCrLf &
                               "Order by FEEMLI DESC),0)" & vbCrLf &
                               "Where Id_Ult_Compra = 0"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            'INCORPORAR LOS DATOS DE LAS ULTIMAS COMPRAS A LOS PRODUCTOS MASIVAMENTE
            Consulta_sql = "Update " & _Tabla_Paso & " Set Endo_Utl_Compra = Ddo.ENDO,Suendo_Utl_Compra = Ddo.SUENDO," & vbCrLf &
                           "Costo_Ult_Compra_RealUd1 = Ddo.PPPRNERE1," & vbCrLf &
                           "Costo_Ult_Compra_RealUd2 = Ddo.PPPRNERE2,Costo_Ult_Compra = Ddo.PPPRNE,Dscto_Ult_Compra =PODTGLLI," & vbCrLf &
                           "Udtpr_Ult_Compra = Ddo.UDTRPR,Fecha_Ult_Compra = Ddo.FEEMLI" & vbCrLf &
                           "From " & _Tabla_Paso & " Left Outer Join" & vbCrLf &
                           "dbo.MAEDDO Ddo ON Id_Ult_Compra = Ddo.IDMAEDDO" & vbCrLf &
                           "Where " & _Tabla_Paso & ".Id_Ult_Compra <> 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            'ELIMINAMOS LOS PRODUCTOS QUE NUNCA HAN SIDO COMPRADOS
            Consulta_sql = "Delete " & _Tabla_Paso & " Where Id_Ult_Compra = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'ELIMINA LOS PRODUCTOS QUE HAN SIDO COMPRADOS POR ENTIDADES EXCLUIDAS
            ' Se recomienda dejarlo activado para cuando se requieren estudiart todos los productos del sistema, para poder hacer NVI

            If Not Chk_Incluir_Ent_Excluidas.Checked Then

                ' ACA HAY QUE MEJORAR EL PROCESO, YA QUE SI EL PROVEEDOR AL CUAL SE LE COMPRO ESTABA EXCLUIDO
                ' SE BORRA Y NO SE PIDEN LOS ARTICULOS, CREO QUE HAY QUE PONER UN FILTRO PARA ESTO UN POCO MAS ARRIBA.

                Consulta_sql = "Delete " & _Tabla_Paso & vbCrLf &
                               "Where Es_Agrupador = 0" & vbCrLf &
                               "And Ltrim(Rtrim(Endo_Utl_Compra))+Ltrim(Rtrim(Suendo_Utl_Compra)) In " &
                               "(Select Ltrim(Rtrim(Codigo))+Ltrim(Rtrim(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas Where Excluida in ('A','C','T'))"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            Consulta_sql = "Select Distinct Codigo_Nodo_Madre,Descripcion_Madre" & vbCrLf &
                           "From " & _Tabla_Paso & vbCrLf &
                           "Where Comprar = 1"
            _Tbl_Codigos_Madre = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _SqlQuery_2 As String = String.Empty

            Consulta_sql = "Select * From " & _Tabla_Paso & vbCrLf &
                           "Where Codigo+Endo_Utl_Compra+Suendo_Utl_Compra In (Select Codigo+CodEntidad+CodSucEntidad From " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos Where Chk = 1)"
            Dim _Tbl_ProdBloqueadoProveedores As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


            If CBool(_Tbl_Codigos_Madre.Rows.Count) Then

                'System.Windows.Forms.Application.DoEvents()

                ProgressBarX1.Maximum = _Tbl_Codigos_Madre.Rows.Count
                ProgressBarX1.Value = 0

                For Each Fila As DataRow In _Tbl_Codigos_Madre.Rows

                    System.Windows.Forms.Application.DoEvents()

                    Dim _Codigo_Nodo_Madre As String = Trim(Fila.Item("Codigo_Nodo_Madre"))
                    Dim _Descripcion_Madre As String = Trim(Fila.Item("Descripcion_Madre"))
                    _Codigo_Comprar = String.Empty

                    If ProgressBarX1.Value = 644 Then
                        Dim _ACA = 0
                    End If

                    'BUSCA LOS PRODUCTOS AGRUPANDOLOS EN UNA TABLA DE PASO, PRODUCTOS HERMANOS
                    Consulta_sql = "Select * From " & _Tabla_Paso & vbCrLf &
                                   "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And ProductoExcluido = 0" & vbCrLf &
                                   "Order by Id_Ult_Compra"
                    Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    Dim _CantSugeridaTot As Double = 0
                    Dim _CantComprar As Double = 0

                    If CBool(_Tbl_Detalle.Rows.Count) Then
                        _CantSugeridaTot = _Tbl_Detalle.Rows(0).Item("CantSugeridaTot")
                        _CantComprar = Math.Ceiling(_CantSugeridaTot)
                    End If

                    If _Tbl_Detalle.Rows.Count = 1 Then

                        Dim _Codigo = _Tbl_Detalle.Rows(0).Item("Codigo")
                        Dim _Endo = _Tbl_Detalle.Rows(0).Item("Endo_Utl_Compra")

                        If Fx_RevisarComprarSinEnvioXProveedor(_Codigo, _Endo, Input_DiasMarcarProvQueNoTiene.Value, FechaDelServidor) Then

                            _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                           "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                           "Where Codigo = '" & _Codigo & "'" & vbCrLf

                        Else

                            _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                           "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                           ",Comprar = 0,NoComprarProvNoTiene = 1" & vbCrLf &
                                           "Where Codigo = '" & _Codigo & "'" & vbCrLf

                        End If

                    ElseIf _Tbl_Detalle.Rows.Count > 1 Then

                        Consulta_sql = "Select * From " & _Tabla_Paso & vbCrLf &
                                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And ProductoExcluido = 0" & Space(1) &
                                       "And Fecha_Ult_Compra >= '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                                       "Order by Costo_Ult_Compra_RealUd1" & vbCrLf &
                                       "Select * From " & _Tabla_Paso & vbCrLf &
                                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And ProductoExcluido = 0" & Space(1) &
                                       "And Fecha_Ult_Compra < '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                                       "Order by Fecha_Ult_Compra Desc --,Costo_Ult_Compra_RealUd1"
                        Dim _Ds_Detalle As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                        Dim _Tbl_Detalle_Compras1 As DataTable = _Ds_Detalle.Tables(0)
                        Dim _Tbl_Detalle_Compras2 As DataTable = _Ds_Detalle.Tables(1)

                        If CBool(_Tbl_Detalle_Compras1.Rows.Count) Then

                            _Codigo_Comprar = _Tbl_Detalle_Compras1.Rows(0).Item("Codigo")

                            For Each _Fila As DataRow In _Tbl_Detalle_Compras1.Rows

                                Dim _Codigo = _Fila.Item("Codigo")

                                If _Codigo = _Codigo_Comprar Then

                                    Dim _Endo = _Fila.Item("Endo_Utl_Compra")

                                    If Fx_RevisarComprarSinEnvioXProveedor(_Codigo, _Endo, Input_DiasMarcarProvQueNoTiene.Value, FechaDelServidor) Then

                                        _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                                       "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf

                                    Else

                                        _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                                       "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                                       ",Comprar = 0,NoComprarProvNoTiene = 1" & vbCrLf &
                                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf

                                    End If

                                    _SqlQuery_2 += "Delete " & _Tabla_Paso & Space(1) &
                                               "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And Codigo <> '" & _Codigo_Comprar & "'" & vbCrLf

                                    Exit For

                                End If

                            Next

                        Else

                            _Codigo_Comprar = _Tbl_Detalle_Compras2.Rows(0).Item("Codigo")

                            For Each _Fila As DataRow In _Tbl_Detalle_Compras2.Rows

                                Dim _Codigo = _Fila.Item("Codigo")

                                If _Codigo = _Codigo_Comprar Then

                                    Dim _Endo = _Fila.Item("Endo_Utl_Compra")

                                    If Fx_RevisarComprarSinEnvioXProveedor(_Codigo, _Endo, Input_DiasMarcarProvQueNoTiene.Value, FechaDelServidor) Then

                                        _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                                       "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf

                                    Else

                                        _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                                       "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                                       ",Comprar = 0,NoComprarProvNoTiene = 1" & vbCrLf &
                                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf

                                    End If

                                    _SqlQuery_2 += "Delete " & _Tabla_Paso & Space(1) &
                                                   "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And Codigo <> '" & _Codigo_Comprar & "'" & vbCrLf

                                    Exit For

                                End If

                            Next

                        End If

                    End If

                    ProgressBarX1.Value += 1
                    ProgressBarX1.Text = "Procesados " & FormatNumber(ProgressBarX1.Value, 0) & " de " & FormatNumber(_Tbl_Codigos_Madre.Rows.Count, 0)

                Next

            End If

            _SqlQuery_2 += vbCrLf & "Delete " & _Tabla_Paso & vbCrLf &
                           "Where Comprar = 0 And NoComprarProvNoTiene = 0" & vbCrLf

            _SqlQuery_2 += vbCrLf & "Update " & _Tabla_Paso & vbCrLf &
                           "Set CodProveedor = Endo_Utl_Compra,CodSucProveedor = Suendo_Utl_Compra" & vbCrLf &
                           "Where Comprar = 1"

            If Not String.IsNullOrEmpty(_SqlQuery_2) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery_2)
            End If

            If Not _Accion_Automatica Then
                MessageBoxEx.Show(Me, "Proceso generado correctamente", "Asociación automática", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ProgressBarX1.Value = 0
                ProgressBarX1.Text = String.Empty
            End If

            Return True

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message & vbCrLf & Consulta_sql, _Codigo_Comprar)
            Return False
        Finally
            Me.Enabled = True
        End Try

    End Function

    Function Fx_RevisarComprarSinEnvioXProveedor(_Codigo As String, _Endo As String, _DiasDif As Integer, _FechaServidor As DateTime) As Boolean

        If Not Chk_MarcarProvQueNoTiene.Checked Then Return True

        Dim _FechaMinima As DateTime = DateAdd(DateInterval.Day, -_DiasDif, _FechaServidor)

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEDDO", "TIDO = 'OCC' And ENDO = '" & _Endo & "' And KOPRCT = '" & _Codigo & "' And FEEMLI > '" & _FechaMinima & "'")

        If Not CBool(_Reg) Then Return True

        _Reg = _Sql.Fx_Cuenta_Registros("MAEDDO",
                                        "IDRST In (Select IDMAEDDO From MAEDDO " &
                                        "Where TIDO = 'OCC' And ENDO = '" & _Endo & "' And KOPRCT = '" & _Codigo & "' And FEEMLI > '" & Format(_FechaMinima, "yyyyMMdd") & "')")

        Return CBool(_Reg)

    End Function

    Function Fx_Incorporar_Proveedores2() As Boolean

        Dim _Codigo_Comprar As String
        Dim _Tbl_Codigos_Madre As DataTable

        Dim _Fecha As Date = Dtp_Fecha_Tope_Proveedores_Automaticos.Value

        Try

            Me.Enabled = False


            'BUSCA LA ULTIMA COMPRA DE LOS PRODUCTOS QUE NO ENCONTRO GRC DENTRO DE LA FECHA TOPE, ES DECIR
            Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                           "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                           "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' And KOPRCT = Codigo" & vbCrLf &
                           "And FEEMLI >= '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                           "Order by PPPRNERE1),0)"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            'LITARALMETE LA ULTIMA VEZ QUE SE COMPRO EL PRODUCTO SIN IMPORTAR LA FECHA TOPE
            Consulta_sql = "Update " & _Tabla_Paso & vbCrLf &
                           "Set Id_Ult_Compra = Isnull((Select top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                           "Where TIDO = '" & Cmb_Documento_Compra.SelectedValue & "' and KOPRCT = Codigo" & vbCrLf &
                           "Order by FEEMLI DESC),0)"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            'INCORPORAR LOS DATOS DE LAS ULTIMAS COMPRAS A LOS PRODUCTOS MASIVAMENTE
            Consulta_sql = "Update " & _Tabla_Paso & " Set Endo_Utl_Compra = Ddo.ENDO,Suendo_Utl_Compra = Ddo.SUENDO," & vbCrLf &
                           "Costo_Ult_Compra_RealUd1 = Ddo.PPPRNERE1," & vbCrLf &
                           "Costo_Ult_Compra_RealUd2 = Ddo.PPPRNERE2," & vbCrLf &
                           "Costo_Ult_Compra = Ddo.PPPRNE," & vbCrLf &
                           "Dscto_Ult_Compra = PODTGLLI," & vbCrLf &
                           "Udtpr_Ult_Compra = Ddo.UDTRPR," & vbCrLf &
                           "Fecha_Ult_Compra = Ddo.FEEMLI" & vbCrLf &
                           "From " & _Tabla_Paso & " Left Outer Join" & vbCrLf &
                           "MAEDDO Ddo ON Id_Ult_Compra = Ddo.IDMAEDDO" & vbCrLf &
                           "Where " & _Tabla_Paso & ".Id_Ult_Compra <> 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            'ELIMINAMOS LOS PRODUCTOS QUE NUNCA HAN SIDO COMPRADOS
            Consulta_sql = "Delete " & _Tabla_Paso & " Where Id_Ult_Compra = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'ELIMINA LOS PRODUCTOS QUE HAN SIDO COMPRADOS POR ENTIDADES EXCLUIDAS
            ' Se recomienda dejarlo activado para cuando se requieren estudiart todos los productos del sistema, para poder hacer NVI

            If Not Chk_Incluir_Ent_Excluidas.Checked Then

                Consulta_sql = "Delete " & _Tabla_Paso & vbCrLf &
                               "Where Es_Agrupador = 0" & vbCrLf &
                               "And Ltrim(Rtrim(Endo_Utl_Compra))+Ltrim(Rtrim(Suendo_Utl_Compra)) In " &
                               "(Select Ltrim(Rtrim(Codigo))+Ltrim(Rtrim(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas Where Excluida in ('A','C','T'))"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            Consulta_sql = "Select Distinct Codigo_Nodo_Madre,Descripcion_Madre" & vbCrLf &
                           "From " & _Tabla_Paso & vbCrLf &
                           "Where Comprar = 1"
            _Tbl_Codigos_Madre = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _SqlQuery_2 As String = String.Empty



            If CBool(_Tbl_Codigos_Madre.Rows.Count) Then

                'System.Windows.Forms.Application.DoEvents()

                ProgressBarX1.Maximum = _Tbl_Codigos_Madre.Rows.Count
                ProgressBarX1.Value = 0

                For Each Fila As DataRow In _Tbl_Codigos_Madre.Rows

                    System.Windows.Forms.Application.DoEvents()

                    Dim _Codigo_Nodo_Madre As String = Trim(Fila.Item("Codigo_Nodo_Madre"))
                    Dim _Descripcion_Madre As String = Trim(Fila.Item("Descripcion_Madre"))
                    _Codigo_Comprar = String.Empty


                    'BUSCA LOS PRODUCTOS AGRUPANDOLOS EN UNA TABLA DE PASO, PRODUCTOS HERMANOS
                    Consulta_sql = "Select * From " & _Tabla_Paso & vbCrLf &
                                   "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'" & vbCrLf &
                                   "Order by Id_Ult_Compra"
                    Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    Dim _CantSugeridaTot As Double = _Tbl_Detalle.Rows(0).Item("CantSugeridaTot")
                    Dim _CantComprar As Double = Math.Ceiling(_CantSugeridaTot)

                    If _Tbl_Detalle.Rows.Count = 1 Then

                        Dim _Codigo = _Tbl_Detalle.Rows(0).Item("Codigo")

                        _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                       "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf

                    ElseIf _Tbl_Detalle.Rows.Count > 1 Then

                        Consulta_sql = "Select * From " & _Tabla_Paso & vbCrLf &
                                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'" & Space(1) &
                                       "And Fecha_Ult_Compra >= '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                                       "Order by Costo_Ult_Compra_RealUd1" & vbCrLf &
                                       "Select * From " & _Tabla_Paso & vbCrLf &
                                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'" & Space(1) &
                                       "And Fecha_Ult_Compra < '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                                       "Order by Fecha_Ult_Compra Desc --,Costo_Ult_Compra_RealUd1"
                        Dim _Ds_Detalle As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                        Dim _Tbl_Detalle_Compras1 As DataTable = _Ds_Detalle.Tables(0)
                        Dim _Tbl_Detalle_Compras2 As DataTable = _Ds_Detalle.Tables(1)

                        If _Tbl_Detalle_Compras1.Rows.Count Then

                            _Codigo_Comprar = _Tbl_Detalle_Compras1.Rows(0).Item("Codigo")

                            For Each _Fila As DataRow In _Tbl_Detalle_Compras1.Rows

                                Dim _Codigo = _Fila.Item("Codigo")

                                If _Codigo = _Codigo_Comprar Then

                                    _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                                   "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                                   "Where Codigo = '" & _Codigo & "'" & vbCrLf

                                Else

                                    _SqlQuery_2 += "Delete " & _Tabla_Paso & Space(1) &
                                                   "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And Codigo = '" & _Codigo & "'" & vbCrLf

                                End If

                            Next

                        Else

                            _Codigo_Comprar = _Tbl_Detalle_Compras2.Rows(0).Item("Codigo")

                            For Each _Fila As DataRow In _Tbl_Detalle_Compras2.Rows

                                Dim _Codigo = _Fila.Item("Codigo")

                                If _Codigo = _Codigo_Comprar Then

                                    _SqlQuery_2 += "Update " & _Tabla_Paso & Space(1) &
                                                   "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & Space(1) &
                                                   "Where Codigo = '" & _Codigo & "'" & vbCrLf

                                Else

                                    _SqlQuery_2 += "Delete " & _Tabla_Paso & Space(1) &
                                                   "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And Codigo = '" & _Codigo & "'" & vbCrLf

                                End If

                            Next

                        End If

                    End If

                    ProgressBarX1.Value += 1
                    ProgressBarX1.Text = "Procesados " & FormatNumber(ProgressBarX1.Value, 0) & " de " & FormatNumber(_Tbl_Codigos_Madre.Rows.Count, 0)

                Next

            End If

            _SqlQuery_2 += vbCrLf & "Update " & _Tabla_Paso & vbCrLf &
                           "Set CodProveedor = Endo_Utl_Compra,CodSucProveedor = Suendo_Utl_Compra" & vbCrLf &
                           "Where Comprar = 1"

            If Not String.IsNullOrEmpty(_SqlQuery_2) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery_2)
            End If

            If Not _Accion_Automatica Then
                MessageBoxEx.Show(Me, "Proceso generado correctamente", "Asociación automática", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ProgressBarX1.Value = 0
                ProgressBarX1.Text = String.Empty
            End If

            Return True

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, _Codigo_Comprar)
            Return False
        Finally
            Me.Enabled = True
        End Try

    End Function

    Sub Sb_Parametros_Revisar()

        caract_combo(Cmb_Documento_Compra)
        Consulta_sql = "SELECT TIDO AS Padre,NOTIDO AS Hijo FROM TABTIDO Where TIDO In ('GRC','FCC','OCC') ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        Cmb_Documento_Compra.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Documento_Compra.SelectedValue = "GRC"

        With _RowParametros

            Chk_Traer_Productos_De_Reemplazo.Checked = .Item("Chk_Traer_Productos_De_Reemplazo")
            Chk_Ent_Fisica.Checked = .Item("Chk_Ent_Fisica")

            Input_Tiempo_Reposicion.Value = .Item("Input_Tiempo_Reposicion")
            Input_Dias_a_Abastecer.Value = .Item("Input_Dias_a_Abastecer")
            Chk_Mostrar_Solo_Stock_Critico.Checked = .Item("Chk_Mostrar_Solo_Stock_Critico")

            Rd_Costo_Lista_Proveedor.Checked = .Item("Rd_Costo_Lista_Proveedor")
            Rd_Costo_Ultimo_Documento_Seleccionado.Checked = .Item("Rd_Costo_Ultima_GRC")
            Rdb_Ud1_Compra.Checked = .Item("Rdb_Ud1_Compra")
            Rdb_Ud2_Compra.Checked = .Item("Rdb_Ud2_Compra")

            Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked = .Item("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI")
            Chk_Restar_Stok_Bodega.Checked = .Item("Chk_Restar_Stok_Bodega")

            Dtp_Fecha_Tope_Proveedores_Automaticos.Value = .Item("Dtp_Fecha_Tope_Proveedores_Automaticos")

            If Chk_Traer_Productos_De_Reemplazo.Checked Then
                Chk_Traer_Productos_De_Reemplazo.Enabled = False
            Else
                Chk_Traer_Productos_De_Reemplazo.Enabled = True
            End If
            Chk_Agrupar_Productos_De_Reemplazo.Checked = Chk_Traer_Productos_De_Reemplazo.Checked

            Chk_Sumar_Rotacion_Hermanos.Checked = Chk_Traer_Productos_De_Reemplazo.Checked
            Chk_Sumar_Rotacion_Hermanos.Enabled = Chk_Traer_Productos_De_Reemplazo.Enabled

            Chk_Sabado.Checked = .Item("Chk_Sabado")
            Chk_Domingo.Checked = .Item("Chk_Domingo")

            Cmb_Proyeccion_Metodo_Abastecer_.SelectedValue = .Item("Cmb_Proyeccion_Metodo_Abastecer")
            Cmb_Proyeccion_Tiempo_Reposicion_.SelectedValue = .Item("Cmb_Proyeccion_Tiempo_Reposicion")

        End With

    End Sub

    Sub Sb_Parametros_Actualizar()

        With _RowParametros

            .Item("Chk_Traer_Productos_De_Reemplazo") = Chk_Traer_Productos_De_Reemplazo.Checked
            .Item("Chk_Ent_Fisica") = Chk_Ent_Fisica.Checked

            .Item("Input_Tiempo_Reposicion") = Input_Tiempo_Reposicion.Value
            .Item("Input_Dias_a_Abastecer") = Input_Dias_a_Abastecer.Value
            .Item("Chk_Mostrar_Solo_Stock_Critico") = Chk_Mostrar_Solo_Stock_Critico.Checked

            .Item("Rd_Costo_Lista_Proveedor") = Rd_Costo_Lista_Proveedor.Checked
            .Item("Rd_Costo_Ultima_GRC") = Rd_Costo_Ultimo_Documento_Seleccionado.Checked
            .Item("Rdb_Ud1_Compra") = Rdb_Ud1_Compra.Checked
            .Item("Rdb_Ud2_Compra") = Rdb_Ud2_Compra.Checked

            'Chk_Cargar_Rotacion_Estacional.Checked = .Item("Chk_Cargar_Rotacion_Estacional")
            'Dtp_Fecha_Estacional_Desde.Value = .Item("Dtp_Fecha_Estacional_Desde")
            'Dtp_Fecha_Estacional_Hasta.Value = .Item("Dtp_Fecha_Estacional_Hasta")

            .Item("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI") = Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked
            .Item("Chk_Restar_Stok_Bodega") = Chk_Restar_Stok_Bodega.Checked
            .Item("Dtp_Fecha_Tope_Proveedores_Automaticos") = Dtp_Fecha_Tope_Proveedores_Automaticos.Value

            .Item("Chk_Sabado") = Chk_Sabado.Checked
            .Item("Chk_Domingo") = Chk_Domingo.Checked

        End With

    End Sub

    Private Sub Frm_00_AsisCompra_IncorpProveedor_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Sb_Parametros_Actualizar()
    End Sub

    Sub Sb_Cargar_Combo_Dias(Cmb As DevComponents.DotNetBar.Controls.ComboBoxEx)

        caract_combo(Cmb)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = 1 : dr("Hijo") = "Dias" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Padre") = 7 : dr("Hijo") = "Semanas" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = 30 : dr("Hijo") = "Meses" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        Cmb.DataSource = dt
        Cmb.SelectedValue = 1

    End Sub

    Private Sub Cmb_Dias_Abastecer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Proyeccion_Metodo_Abastecer_.SelectedValue

        Cmb_Proyeccion_Tiempo_Reposicion_.SelectedValue = _Valor

        Select Case _Valor

            Case 1
                Input_Dias_a_Abastecer.MaxValue = 60
                Input_Dias_a_Abastecer.Value = 7
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 1
            Case 7
                Input_Dias_a_Abastecer.MaxValue = 4
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Dias_a_Abastecer.MaxValue = 6
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub
    Private Sub Cmb_Tiempo_Reposicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Proyeccion_Tiempo_Reposicion_.SelectedValue

        Select Case _Valor

            Case 1
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 7
            Case 7
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub

    Private Sub Timer_Ejecucion_Automatica_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecucion_Automatica.Tick
        Timer_Ejecucion_Automatica.Stop()
        Call BtnProcesarInf_Click(Nothing, Nothing)
    End Sub

    Private Sub Chk_MarcarProvQueNoTiene_CheckedChanged(sender As Object, e As EventArgs)
        Input_DiasMarcarProvQueNoTiene.Enabled = Chk_MarcarProvQueNoTiene.Checked
    End Sub

End Class
