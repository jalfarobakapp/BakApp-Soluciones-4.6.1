Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_St_Filtrar_Ordenes_de_trabajo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Filtro As String
    Dim _TblFiltro_Informe As DataTable
    Dim _TblFiltro_Tecnicos_Asignados As DataTable
    Dim _TblFiltro_Tecnicos_Reparan As DataTable
    Dim _TblFiltro_Clientes As DataTable
    Dim _TblFiltro_Estados As DataTable

    Dim _TblFiltro_Maquinas, _TblFiltro_Marcas, _TblFiltro_Modelos, _TblFiltro_Categorias As DataTable

    Dim _Tbl_Informe As DataTable
    Dim _Filtrar As Boolean

    Public Sub New()

        ' Llamada necesaria para el Dise�ador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicializaci�n despu�s de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_St_Filtrar_Ordenes_de_trabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Rdb_Orden_de_trabajo_Una.Checked = True
        Me.ActiveControl = Txt_Nro_OT
        'Sb_Habilitar_Etiquetas()


        Dtp_Fecha_Emision_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Emision_Hasta.Value = FechaDelServidor()

        Dtp_Fecha_Cierre_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Cierre_Hasta.Value = FechaDelServidor()

    End Sub


    Private Sub Rdb_Entidades_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Entidades_Algunas.CheckedChanged
        If Rdb_Entidades_Algunas.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10) '(Frm_Filtro_Especial_Informes._Tabla_Fl._Entidades)

            Fm.Pro_Tabla = "MAEEN"
            Fm.Pro_Campo = "RTEN"
            Fm.Pro_Descripcion = "NOKOEN"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Clientes = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Clientes Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Entidades_Todas.Checked = True
                End If
            Else
                Rdb_Entidades_Todas.Checked = True
            End If
        End If
    End Sub

    Private Sub Rdb_Tecnico_Asignado_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Tecnico_Asignado_Algunos.CheckedChanged

        If Rdb_Tecnico_Asignado_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller"
            Fm.Pro_Campo = "CodFuncionario"
            Fm.Pro_Descripcion = "NomFuncionario"

            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "T�cnico o Taller Asignado"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Tecnicos_Asignados = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Tecnicos_Asignados Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Tecnico_Asignado_Todos.Checked = True
                End If
            Else
                Rdb_Tecnico_Asignado_Todos.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Tecnico_Repara_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Tecnico_Repara_Algunos.CheckedChanged

        If Rdb_Tecnico_Repara_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller"
            Fm.Pro_Campo = "CodFuncionario"
            Fm.Pro_Descripcion = "NomFuncionario"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "T�cnico o Taller Repara"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Tecnicos_Reparan = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Tecnicos_Reparan Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Tecnico_Repara_Todos.Checked = True
                End If
            Else
                Rdb_Tecnico_Repara_Todos.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Estados_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Estados_Algunos.CheckedChanged

        If Rdb_Estados_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "Estados de Ordenes de Trabajo"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'ESTADOS_ST')" & vbCrLf & "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Estados = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Estados Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Estados_Todas.Checked = True
                End If
            Else
                Rdb_Estados_Todas.Checked = True
            End If

        End If

        ' SELECT     Tabla, DescripcionTabla, CodigoTabla, NombreTabla, Orden, ApColor, ApModelo, ApMedida, Porcentaje, Valor
        'FROM(Zw_TablaDeCaracterizaciones)
        'WHERE     (Tabla = 'ESTADOS_ST') AND (CodigoTabla <> 'N')
        'ORDER BY Orden
    End Sub


    


    Private Sub Rdb_Fecha_Emision_Rango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Fecha_Emision_Rango.CheckedChanged
        Sb_Habilitar_Etiquetas()
    End Sub

    Private Sub Rdb_Fecha_Cierre_Rango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Fecha_Cierre_Rango.CheckedChanged
        Sb_Habilitar_Etiquetas()
    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub

    Private Sub Rdb_Orden_de_trabajo_Una_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Orden_de_trabajo_Una.CheckedChanged
        Sb_Habilitar_Etiquetas()
        If Rdb_Orden_de_trabajo_Una.Checked Then
            Txt_Nro_OT.Focus()
        End If
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Sb_Filtrar()
    End Sub


    Sub Sb_Filtrar()

        Dim _Filtro_OT = String.Empty
        Dim _Filtro_Entidades = String.Empty
        Dim _Filtro_Tecnico_Asignado = String.Empty
        Dim _Filtro_Tecnico_Repara = String.Empty
        Dim _Filtro_Estados = String.Empty
        Dim _Filtro_Fecha_Emision = String.Empty
        Dim _Filtro_Fecha_Cierre = String.Empty
        Dim _Filtro_Maquina = String.Empty
        Dim _Filtro_Marca = String.Empty
        Dim _Filtro_Modelo = String.Empty
        Dim _Filtro_Categoria = String.Empty
        Dim _Filtro_Nro_Serie = String.Empty
        Dim _Filtro_Serv_Demostracion_Maquina = String.Empty
        Dim _Filtro_Serv_Domicilio = String.Empty
        Dim _Filtro_Serv_Garantia = String.Empty
        Dim _Filtro_Serv_Mantenimiento_Correctivo = String.Empty
        Dim _Filtro_Serv_Mantenimiento_Preventivo = String.Empty
        Dim _Filtro_Serv_Presupuesto_Pre_Aprobado = String.Empty
        Dim _Filtro_Serv_Recoleccion = String.Empty
        Dim _Filtro_Serv_Reparacion_Stock = String.Empty


        If Rdb_Orden_de_trabajo_Una.Checked Then
            If String.IsNullOrEmpty(Trim(Txt_Nro_OT.Text)) Then
                Beep()
                ToastNotification.Show(Me, "NUMERO NO PUEDE ESTAR VACIO", Imagenes_32x32.Images.Item("Warning"), _
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Txt_Nro_OT.Focus()
                Return
            End If
        End If

        Dim _Nro_Ot As String = Txt_Nro_OT.Text
        Dim _Filtro_SQl As String

        If Rdb_Orden_de_trabajo_Una.Checked Then
            Txt_Nro_OT.Text = Fx_Rellena_ceros(Txt_Nro_OT.Text, 10)
            _Filtro_OT = "And Nro_Ot = '" & _Nro_Ot & "'" & vbCrLf
        End If

        If Rdb_Orden_de_trabajo_Todas.Checked Then

            If Rdb_Entidades_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Clientes, "Chk", "Codigo", False, True, "'")
                _Filtro_Entidades = "And Rten in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Tecnico_Asignado_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Tecnicos_Asignados, "Chk", "Codigo", False, True, "'")
                _Filtro_Tecnico_Asignado = "And CodTecnico_Asignado in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Tecnico_Repara_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Tecnicos_Reparan, "Chk", "Codigo", False, True, "'")
                _Filtro_Tecnico_Repara = "And CodTecnico_Repara in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Estados_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Estados, "Chk", "Codigo", False, True, "'")
                _Filtro_Estados = "And CodEstado in " & _Filtro_SQl & vbCrLf
            End If

            ' MAQUINAS
            If Rdb_Manquina_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Maquinas, "Chk", "Codigo", False, True, "'")
                _Filtro_Maquina = "And CodMaquina in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Marca_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Marcas, "Chk", "Codigo", False, True, "'")
                _Filtro_Marca = "And CodMarca in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Modelo_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Modelos, "Chk", "Codigo", False, True, "'")
                _Filtro_Modelo = "And CodModelo in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Categoria_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Categorias, "Chk", "Codigo", False, True, "'")
                _Filtro_Categoria = "And CodCategoria in " & _Filtro_SQl & vbCrLf
            End If

            If Not String.IsNullOrEmpty(Trim(Txt_Nro_Serie.Text)) Then
                _Filtro_Nro_Serie = "And NroSerie Like '%" & Txt_Nro_Serie.Text & "%'" & vbCrLf
            End If

            'If Rdb_Estados_Algunos.Checked Then
            '_Filtro_SQl = Generar_Filtro_IN(_TblFiltro_Estados, "Chk", "Codigo", False, True, "'")
            '_Filtro_Estados = "And CodCategoria in " & _Filtro_SQl & vbCrLf
            'End If

            If Rdb_Fecha_Emision_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Emision_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Emision_Hasta.Value.Year

                _Filtro_Fecha_Emision = "And (Fecha_Ingreso BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf & _
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


            End If

            If Rdb_Fecha_Cierre_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Cierre_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Cierre_Hasta.Value.Year

                _Filtro_Fecha_Cierre = "And (Fecha_Entrega BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf & _
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


            End If

            If Chk_Serv_Demostracion_Maquina.Checked Then
                _Filtro_Serv_Demostracion_Maquina = "And Chk_Serv_Demostracion_Maquina = 1 " & vbCrLf
            End If

            If Chk_Serv_Domicilio.Checked Then
                _Filtro_Serv_Domicilio = "And Chk_Serv_Domicilio = 1 " & vbCrLf
            End If

            If Chk_Serv_Garantia.Checked Then
                _Filtro_Serv_Garantia = "And Chk_Serv_Garantia = 1 " & vbCrLf
            End If

            If Chk_Serv_Mantenimiento_Correctivo.Checked Then
                _Filtro_Serv_Mantenimiento_Correctivo = "And Chk_Serv_Mantenimiento_Correctivo = 1 " & vbCrLf
            End If

            If Chk_Serv_Mantenimiento_Preventivo.Checked Then
                _Filtro_Serv_Mantenimiento_Preventivo = "And Chk_Serv_Mantenimiento_Preventivo = 1 " & vbCrLf
            End If
            If Chk_Serv_Presupuesto_Pre_Aprobado.Checked Then
                _Filtro_Serv_Presupuesto_Pre_Aprobado = "And Chk_Serv_Presupuesto_Pre_Aprobado = 1 " & vbCrLf
            End If

            If Chk_Serv_Recoleccion.Checked Then
                _Filtro_Serv_Recoleccion = "And Chk_Serv_Recoleccion = 1 " & vbCrLf
            End If

            If Chk_Serv_Reparacion_Stock.Checked Then
                _Filtro_Serv_Reparacion_Stock = "And Chk_Serv_Reparacion_Stock = 1 " & vbCrLf
            End If


        End If

        _Filtro_SQl = _Filtro_OT & _
                      _Filtro_Entidades & _
                      _Filtro_Tecnico_Asignado & _
                      _Filtro_Tecnico_Repara & _
                      _Filtro_Estados & _
                      _Filtro_Fecha_Emision & _
                      _Filtro_Fecha_Cierre & _
                      _Filtro_Maquina & _
                      _Filtro_Marca & _
                      _Filtro_Modelo & _
                      _Filtro_Categoria & _
                      _Filtro_Nro_Serie & _
                      _Filtro_Serv_Demostracion_Maquina & _
                      _Filtro_Serv_Domicilio & _
                      _Filtro_Serv_Garantia & _
                      _Filtro_Serv_Mantenimiento_Correctivo & _
                      _Filtro_Serv_Mantenimiento_Preventivo & _
                      _Filtro_Serv_Presupuesto_Pre_Aprobado & _
                      _Filtro_Serv_Recoleccion & _
                      _Filtro_Serv_Reparacion_Stock


        Consulta_sql = My.Resources.Recursos_Locales.SqlQuery_Lista_OT
        Consulta_sql = Replace(Consulta_sql, "#Db_BakApp#", _Global_BaseBk)

        Consulta_sql += vbCrLf & "Where 1 > 0" & vbCrLf & _Filtro_SQl

        _Tbl_Informe = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Informe.Rows.Count) Then

            Dim _Mostrar As Boolean

            If _Tbl_Informe.Rows.Count <= 20 Then
                _Mostrar = True
            Else
                If MessageBoxEx.Show(Me, _Tbl_Informe.Rows.Count & " registros encontrados" & vbCrLf & vbCrLf & _
                                                "�Desea ver la informaci�n?", "Filtrar", _
                                              MessageBoxButtons.OKCancel, _
                                              MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then

                    _Mostrar = True
                End If
            End If

            If _Mostrar Then

                Dim Fm_Fl As New Frm_St_Ordenes_de_trabajo
                Fm_Fl.Pro_Tbl_Informe = _Tbl_Informe
                Fm_Fl.Pro_Correr_a_la_derecha = True
                Fm_Fl.ShowDialog(Me)
                Fm_Fl.Dispose()

            End If

        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISEN DATOS QUE MOSTRAR", Imagenes_32x32.Images.Item("Delete"), _
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            _Tbl_Informe = Nothing
        End If

    End Sub

    Public Property Pro_Tbl_Informe() As DataTable
        Get
            Return _Tbl_Informe
        End Get
        Set(ByVal value As DataTable)

        End Set
    End Property

    Public Property Pro_Filtrar() As Boolean
        Get
            Return _Filtrar
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Private Sub Rdb_Manquina_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Manquina_Algunas.CheckedChanged
        If Rdb_Manquina_Algunas.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "MAQUINAS"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'MAQUINA_ST')" & vbCrLf & "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Maquinas = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Maquinas Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Manquina_Todas.Checked = True
                End If
            Else
                Rdb_Manquina_Todas.Checked = True
            End If

        End If
    End Sub

    Private Sub Rdb_Modelo_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Modelo_Algunos.CheckedChanged
        If Rdb_Modelo_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "MODELOS"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'MODELOS_ST')" & vbCrLf & "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Modelos = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Modelos Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Modelo_Todos.Checked = True
                End If
            Else
                Rdb_Modelo_Todos.Checked = True
            End If

        End If
    End Sub

    Private Sub Rdb_Marca_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Marca_Algunas.CheckedChanged
        If Rdb_Marca_Algunas.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "MARCAS"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'MARCAS')" & vbCrLf & "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Marcas = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Marcas Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Marca_Todas.Checked = True
                End If
            Else
                Rdb_Marca_Todas.Checked = True
            End If

        End If
    End Sub



    Private Sub Rdb_Categoria_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Categoria_Algunas.CheckedChanged
        If Rdb_Categoria_Algunas.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(10)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = Nothing
            Fm.Text = "CATEGORIAS"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'CATEGORIAS_ST')" & vbCrLf & "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _TblFiltro_Categorias = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Categorias Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Categoria_Todas.Checked = True
                End If
            Else
                Rdb_Categoria_Todas.Checked = True
            End If

        End If
    End Sub

    Private Sub Txt_Nro_OT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Nro_OT.KeyDown
        If e.KeyValue = Keys.Enter Then
            Txt_Nro_OT.Text = Fx_Rellena_ceros(Txt_Nro_OT.Text, 10)
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Sb_Habilitar_Etiquetas()

        Lbl_FE_desde.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Lbl_FE_hasta.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Dtp_Fecha_Emision_Desde.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Dtp_Fecha_Emision_Hasta.Enabled = Rdb_Fecha_Emision_Rango.Checked

        Lbl_FC_desde.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Lbl_FC_hasta.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Dtp_Fecha_Cierre_Desde.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Dtp_Fecha_Cierre_Hasta.Enabled = Rdb_Fecha_Cierre_Rango.Checked

        Txt_Nro_OT.Enabled = Rdb_Orden_de_trabajo_Una.Checked

        Grupo_Entidad.Enabled = Rdb_Orden_de_trabajo_Todas.Checked
        Grupo_Maquina.Enabled = Rdb_Orden_de_trabajo_Todas.Checked
        Grupo_Fechas.Enabled = Rdb_Orden_de_trabajo_Todas.Checked


        Grupo_Chk_Tipo_Reparacion.Enabled = Rdb_Orden_de_trabajo_Todas.Checked

        If Rdb_Orden_de_trabajo_Todas.Checked Then
            Txt_Nro_OT.Text = String.Empty
        End If

    End Sub

End Class