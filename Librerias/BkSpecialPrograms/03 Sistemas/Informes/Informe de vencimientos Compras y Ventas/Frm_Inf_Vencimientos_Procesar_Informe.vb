'Imports Lib_Bakapp_VarClassFunc
Imports System.IO
Imports DevComponents.DotNetBar

Public Class Frm_Inf_Vencimientos_Procesar_Informe

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String


    Public _Informe As Tipo_Informe
    Dim _Permiso_Informe As String

    Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server

    Dim _TblFiltro_Entidades,
        _TblFiltro_Sucursal,
        _TblFiltro_Vendedores,
        _TblFiltro_Anotaciones As DataTable

    Dim _Tabla_Anotaciones As String

    Enum Tipo_Informe
        Compras
        Ventas
    End Enum

    Dim _Nombre_Archivo_XML As String '= "DS_Filtro_Informe_vencimientos.xml"
    Dim _Ds_Filtro As New Ds_Inf_Venc_ComVta
    Dim _Monto_Max As Double
    Dim _Id_Correo As Integer

    Public Sub New(ByVal New_Nombre_Archivo_XML As String,
                   ByVal Permiso_Informe As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _Permiso_Informe = Permiso_Informe
        _Nombre_Archivo_XML = New_Nombre_Archivo_XML
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Actualizar_Configuracion_local()

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Procesar_Informe.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Inf_Vencimientos_Procesar_Informe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Informe = Tipo_Informe.Ventas Then
            Me.Text = "Informe de vencimientos de venta"
            Chk_Excluir_Documentos_Autorizados_Pago.Visible = False
        ElseIf _Informe = Tipo_Informe.Compras Then
            Me.Text = "Informe de vencimientos de compras"
        End If

        '-- ESTA INSTRUCCION CIERRA LOS VENCIMIENTOS QUE YA ESTAN CANCELADOS COMPLETAMENTE
        Dim Fm As New Frm_Reparar_Maeven(Nothing)
        Fm.Fx_Reparar_Maeven(Me)
        Fm.Dispose()

        Lbl_Nombre_Empresa.Text = " Empresa:  " & RazonEmpresa

    End Sub

    Sub Sb_Actualizar_Configuracion_local()

        Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\Filtro_Informes"

        _Ds_Filtro.Clear()

        If Not Directory.Exists(_Directorio) Then
            Directory.CreateDirectory(_Directorio)
        End If

        Dim exists = File.Exists(_Directorio & "\" & _Nombre_Archivo_XML)

        If exists Then
            _Ds_Filtro.ReadXml(_Directorio & "\" & _Nombre_Archivo_XML)

            If CBool(_Ds_Filtro.Tables("Tbl_Monto").Rows.Count) Then
                _Monto_Max = _Ds_Filtro.Tables("Tbl_Monto").Rows(0).Item("Monto_Max")
            Else
                _Monto_Max = 0
            End If

            If CBool(_Ds_Filtro.Tables("Tbl_Conf_Correo").Rows.Count) Then
                _Id_Correo = _Ds_Filtro.Tables("Tbl_Conf_Correo").Rows(0).Item("Id_Correo")
            Else
                _Id_Correo = 0
            End If

            If CBool(_Ds_Filtro.Tables("Tbl_Rango_Fecha_Emision").Rows.Count) Then
                Dtp_Fecha_Desde.Value = _Ds_Filtro.Tables("Tbl_Rango_Fecha_Emision").Rows(0).Item("Dtp_Fecha_Emision_Desde")
                Dtp_Fecha_Hasta.Value = Date.Now '_Ds_Filtro.Tables("Tbl_Rango_Fecha_Emision").Rows(0).Item("Dtp_Fecha_Emision_Hasta")
            End If

        Else
            Dtp_Fecha_Desde.Value = Now.Date
            Dtp_Fecha_Hasta.Value = Now.Date
            _Ds_Filtro.WriteXml(_Directorio & "\" & _Nombre_Archivo_XML)
        End If

        _Ds_Filtro.ReadXml(_Directorio & "\" & _Nombre_Archivo_XML)


    End Sub

    Private Sub Btn_Procesar_Informe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Procesar_Informe.Click


        Dim _Filtro_SQl As String

        Dim _SqlFiltro_Maeedo As String
        Dim _SqlFiltro_Maedpce As String
        Dim _SqlFiltro_Entidades_Excluidas_Maeedo As String
        Dim _SqlFiltro_Entidades_Excluidas_Maedpce As String
        Dim _SqlFiltro_Adicional As String

        Dim _Sql_Entidad_Maeedo As String
        Dim _Sql_Entidad_Maedpce As String

        Dim _Sql_Sucursal_Maeedo As String
        Dim _Sql_Sucursal_Maedpce As String

        Dim _Sql_Vendedores_Maeedo As String
        Dim _Sql_Vendedores_Maedpce As String

        Consulta_Sql = "Select IDMAEEDO,VABRDO-VAABDO,FEEMDO,FEULVEDO,* From MAEEDO" & vbCrLf &
                       "Where IDMAEEDO Not In (Select IDMAEEDO From MAEVEN) And TIDO In " &
                       "('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN') " &
                       "And VABRDO > VAABDO Order by NUDO"
        Dim _TblDocSinVenci As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If CBool(_TblDocSinVenci.Rows.Count) Then

            Dim _FiltroIdEdo As String = Generar_Filtro_IN(_TblDocSinVenci, "", "IDMAEEDO", False, False, "")

            Consulta_Sql = "Insert Into MAEVEN (IDMAEEDO,FEVE,ESPGVE,VAVE,VAABVE)" & vbCrLf &
                           "Select IDMAEEDO,FEULVEDO,'',VABRDO,VAABDO" & vbCrLf &
                           "From MAEEDO Where IDMAEEDO In " & _FiltroIdEdo
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        End If

        If Rdb_Entidades_Algunas.Checked Then
            _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Entidades, "Chk", "Codigo", False, True, "'")
            _Sql_Entidad_Maeedo = "And EDO.ENDO IN " & _Filtro_SQl
            _Sql_Entidad_Maedpce = "And DPCE.ENDP IN " & _Filtro_SQl
        End If

        If Chk_SoloClientesFincred.Checked Then

            _Sql_Entidad_Maeedo = "And ((EDO.ENDO IN (Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where RevFincred = 1)) Or " &
                                     " (EDO.ENDO In (Select KOEN From MAEEN Where ACTIEN = 'FINCRED')))"

            _Sql_Entidad_Maedpce = "And ((DPCE.ENDP IN (Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where RevFincred = 1)) Or " &
                                     " (DPCE.ENDP In (Select KOEN From MAEEN Where ACTIEN = 'FINCRED')))"

        End If

        If Rdb_Sucursales_Algunas.Checked Then
            _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Sucursal, "Chk", "Codigo", False, True, "'")
            _Sql_Sucursal_Maeedo = "And EDO.SUDO IN " & _Filtro_SQl
            _Sql_Sucursal_Maedpce = "And DPCE.SUREDP IN " & _Filtro_SQl
        End If

        If Rdb_Vendedores_Algunos.Checked Then
            _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Vendedores, "Chk", "Codigo", False, True, "'")
            _Sql_Vendedores_Maeedo = "And EDO.IDMAEEDO IN (SELECT IDMAEEDO FROM MAEDDO WHERE KOFULIDO IN " & _Filtro_SQl & ")"
            _Sql_Vendedores_Maedpce = ""
        End If

        If Rdb_Anotaciones_Algunas.Checked Then
            _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Anotaciones, "Chk", "Codigo", False, True, "'")
            _Sql_Vendedores_Maeedo = "And EDO.IDMAEEDO IN (SELECT IDRVE FROM MEVENTO " &
                                     "Where ARCHIRVE = 'MAEEDO' And KOTABLA = 'COBRANZA' And KOCARAC IN " & _Filtro_SQl & ")"
            _Sql_Vendedores_Maedpce = "And DPCE.IDMAEDPCE IN (SELECT IDRVE FROM MEVENTO " &
                                     "Where ARCHIRVE = 'MAEDPCE' And KOTABLA = 'COBRANZA' And KOCARAC IN " & _Filtro_SQl & ")"
        End If


        Consulta_Sql = "Select Codigo From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                      "Where Funcionario = '" & FUNCIONARIO & "' And Excluida in ('C','A')"
        Dim _TblEntExcluidas As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If CBool(_TblEntExcluidas.Rows.Count) Then

            _Filtro_SQl = Generar_Filtro_IN(_TblEntExcluidas, "", "Codigo", False, False, "'")

            _SqlFiltro_Entidades_Excluidas_Maeedo = "And EDO.ENDO Not In " & _Filtro_SQl '& " And"
            _SqlFiltro_Entidades_Excluidas_Maedpce = "And DPCE.ENDP Not In " & _Filtro_SQl

        End If


        _SqlFiltro_Maeedo = _Sql_Entidad_Maeedo & vbCrLf &
                            _Sql_Sucursal_Maeedo & vbCrLf &
                            _Sql_Vendedores_Maeedo & vbCrLf &
                            _SqlFiltro_Entidades_Excluidas_Maeedo

        _SqlFiltro_Maedpce = _Sql_Entidad_Maedpce & vbCrLf &
                             _Sql_Sucursal_Maedpce & vbCrLf &
                             _Sql_Vendedores_Maedpce & vbCrLf &
                             _SqlFiltro_Entidades_Excluidas_Maedpce


        If Chk_Excluir_Documentos_Autorizados_Pago.Checked Then
            _SqlFiltro_Adicional = "And VEN.IDMAEVEN Not In (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Autorizado = 1 And Pagado = 0)"
        End If

        Dim Fm As New Frm_Inf_Vencimientos_Mes(_Informe, _Monto_Max, _Id_Correo)

        Fm.Pro_Filtro_Maeedo = _SqlFiltro_Maeedo
        Fm.Pro_Filtro_Maedpce = _SqlFiltro_Maedpce
        Fm.Pro_Chk_Deuda_Efectiva = Chk_Deuda_Efectiva.Checked
        Fm.Pro_Filtro_Adicional = _SqlFiltro_Adicional

        Fm.Sb_Ejecutar_Informe(FormatDateTime(Dtp_Fecha_Desde.Value, DateFormat.ShortDate),
                               FormatDateTime(Dtp_Fecha_Hasta.Value, DateFormat.ShortDate))

        If CBool(Fm.Pro_Tbl_Informe.Rows.Count) Then
            Fm.Sb_Actualizar_Calendario(Progreso_Cont, Progreso_Porc)
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "No hay datos que mostrar", "Informe detallado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        '--#Filtro_Adicional_Maeedo#
        '--#Filtro_Adicional_Maedpce#

        Fm.Dispose()
    End Sub

    Private Sub Frm_Inf_Vencimientos_Procesar_Informe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Configuracion_Local_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Configuracion_Local.Click

        Dim Fm As New Frm_Inf_Vencimientos_Configuracion(_Nombre_Archivo_XML,
                                                         Dtp_Fecha_Desde.Value,
                                                         Dtp_Fecha_Hasta.Value)
        Fm.Text = "Configuración local " & Me.Text
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    Private Sub Frm_Inf_Vencimientos_Procesar_Informe_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Dim Fm As New Frm_Inf_Vencimientos_Configuracion(_Nombre_Archivo_XML,
                                                         Dtp_Fecha_Desde.Value,
                                                         Dtp_Fecha_Hasta.Value)
        Fm.Fx_Actualizar_Filtros(Me)
        Fm.Dispose()

        'Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
        'Fx_Conectar_Empresa(Me, True)
        'SQL_ServerClass.Sb_Cerrar_Conexion(cn1)

    End Sub

    Private Sub Rdb_Entidades_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Entidades_Algunas.CheckedChanged

        'If Rdb_Entidades_Algunas.Checked Then

        '    Dim _Filtro_Entidad_Todas As Boolean
        '    Dim _Filtro_Ciudad_Todas As Boolean
        '    Dim _Filtro_Comunas_Todas As Boolean
        '    Dim _Filtro_Rubro_Entidades_Todas As Boolean
        '    Dim _Filtro_Zonas_Entidades_Todas As Boolean

        '    Dim _Tbl_Filtro_Entidad As DataTable
        '    Dim _Tbl_Filtro_Ciudad As DataTable
        '    Dim _Tbl_Filtro_Comunas As DataTable
        '    Dim _Tbl_Filtro_Rubro_Entidades As DataTable
        '    Dim _Tbl_Filtro_Zonas_Entidades As DataTable

        '    Dim Fm As New Frm_Filtro_Especial_Entidades

        '    Fm.Pro_Filtro_Entidad_Todas = _Filtro_Entidad_Todas
        '    Fm.Pro_Filtro_Ciudades_Todas = _Filtro_Ciudad_Todas
        '    Fm.Pro_Filtro_Comunas_Todas = _Filtro_Comunas_Todas
        '    Fm.Pro_Filtro_Rubro_Entidad_Todas = _Filtro_Rubro_Entidades_Todas
        '    Fm.Pro_Filtro_Zonas_Entidad_Todas = _Filtro_Zonas_Entidades_Todas

        '    Fm.Pro_Tbl_Filtro_Entidades = _Tbl_Filtro_Entidad
        '    Fm.Pro_Tbl_Filtro_Ciudad = _Tbl_Filtro_Ciudad
        '    Fm.Pro_Tbl_Filtro_Comuna = _Tbl_Filtro_Comunas
        '    Fm.Pro_Tbl_Filtro_Rubro_Entidad = _Tbl_Filtro_Rubro_Entidades
        '    Fm.Pro_Tbl_Filtro_Zonas_Entidad = _Tbl_Filtro_Zonas_Entidades

        '    'Fm.Pro_Filtro_Extra_Entidad = _Filtro_Extra_Entidad
        '    'Fm.Pro_Filtro_Extra_Ciudad = _Filtro_Extra_Ciudad
        '    'Fm.Pro_Filtro_Extra_Comunas = _Filtro_Extra_Comuna
        '    'Fm.Pro_Filtro_Extra_Rubro_Entidad = _Filtro_Extra_Rubros
        '    'Fm.Pro_Filtro_Extra_Zonas_entidad = _Filtro_Extra_Zonas

        '    Fm.ShowDialog(Me)

        '    If Fm.Pro_Aceptar Then

        '        _Filtro_Entidad_Todas = Fm.Pro_Filtro_Entidad_Todas
        '        _Filtro_Ciudad_Todas = Fm.Pro_Filtro_Ciudades_Todas
        '        _Filtro_Comunas_Todas = Fm.Pro_Filtro_Comunas_Todas
        '        _Filtro_Rubro_Entidades_Todas = Fm.Pro_Filtro_Rubro_Entidad_Todas
        '        _Filtro_Zonas_Entidades_Todas = Fm.Pro_Filtro_Zonas_Entidad_Todas

        '        _Tbl_Filtro_Entidad = Fm.Pro_Tbl_Filtro_Entidades
        '        _Tbl_Filtro_Ciudad = Fm.Pro_Tbl_Filtro_Ciudad
        '        _Tbl_Filtro_Comunas = Fm.Pro_Tbl_Filtro_Comuna
        '        _Tbl_Filtro_Rubro_Entidades = Fm.Pro_Tbl_Filtro_Rubro_Entidad
        '        _Tbl_Filtro_Zonas_Entidades = Fm.Pro_Tbl_Filtro_Zonas_Entidad

        '    End If

        '    Fm.Dispose()

        Dim Fm2 As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Entidades)
        Fm2.Pro_Tbl_Filtro = Nothing
        Fm2.ShowDialog(Me)

        If Fm2.Pro_Filtrar Then

            _TblFiltro_Entidades = Fm2.Pro_Tbl_Filtro
            If (_TblFiltro_Entidades Is Nothing) Or Fm2.Pro_Filtrar_Todo Then
                Rdb_Entidades_Todas.Checked = True
            End If
        Else
            Rdb_Entidades_Todas.Checked = True
        End If

        'End If

    End Sub

    Private Sub Rdb_Sucursales_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Sucursales_Algunas.CheckedChanged

        If Rdb_Sucursales_Algunas.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Sucursales)
            Fm.Pro_Tbl_Filtro = _TblFiltro_Sucursal
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then

                _TblFiltro_Sucursal = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Sucursal Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Sucursales_Todas.Checked = True
                End If
            Else
                Rdb_Sucursales_Todas.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Vendedores_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Vendedores_Algunos.CheckedChanged

        If Rdb_Vendedores_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
            Fm.Pro_Tbl_Filtro = _TblFiltro_Vendedores
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then

                _TblFiltro_Vendedores = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Vendedores Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Vendedores_Todos.Checked = True
                End If
            Else
                Rdb_Vendedores_Todos.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Anotaciones_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Anotaciones_Algunas.CheckedChanged

        If Rdb_Anotaciones_Algunas.Checked Then

            Dim _Kotabla = _Tabla_Anotaciones

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Tabla_Tabcarac)
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And KOTABLA = 'COBRANZA'"
            Fm.Pro_Tbl_Filtro = _TblFiltro_Anotaciones
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Anotaciones = Fm.Pro_Tbl_Filtro
            Else
                Rdb_Anotaciones_Todas.Checked = True
            End If
        End If


    End Sub



    Private Sub Btn_Entidades_Excluidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Entidades_Excluidas.Click
        If Fx_Tiene_Permiso(Me, "CfEnt016") Then
            Dim Fm As New Frm_EntExcluidas
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Chk_Excluir_Documentos_Autorizados_Pago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Excluir_Documentos_Autorizados_Pago.CheckedChanged
        If Chk_Excluir_Documentos_Autorizados_Pago.Checked Then
            Chk_Excluir_Documentos_Autorizados_Pago.Checked = Fx_Tiene_Permiso(Me, "Ppro0003")
        End If
    End Sub


End Class
