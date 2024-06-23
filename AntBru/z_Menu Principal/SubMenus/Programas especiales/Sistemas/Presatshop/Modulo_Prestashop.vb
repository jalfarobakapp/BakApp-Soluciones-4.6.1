Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_Prestashop

    Dim _Fm_Menu_Padre As Metro.MetroAppForm
    Dim _Menu_Extra As Boolean

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Prestashop_Configuracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Prestashop_Configuracion.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pshop002") Then

            Dim Fm As New Frm_Conexiones_Prestashop
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Prestashop_Peticion_Manual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Prestashop_Peticion_Manual.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pshop003") Then

            Dim _Nombre_Equipo = My.Computer.Name

            Consulta_sql = "Select KOPR From MAEPR Where KOPR In (Select KOPR From TABCODAL" & Space(1) &
                           "Where KOEN In (Select Codigo_Pagina From " & _Global_BaseBk & "Zw_PrestaShop" & Space(1) &
                           "Where Conexion_Activa = 1))"

            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl_Productos.Rows.Count) Then

                _Tbl_Productos = Nothing

                If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pshop001") Then


                    Dim _Sql_Filtro_Condicion_Extra = "And KOPR In (Select KOPR From TABCODAL" & Space(1) &
                                                      "Where KOEN In (Select Codigo_Pagina From " & _Global_BaseBk & "Zw_PrestaShop" & Space(1) &
                                                      "Where Conexion_Activa = 1))"

                    Dim _Filtrar As New Clas_Filtros_Random(_Fm_Menu_Padre)
                    _Filtrar.Pro_Nombre_Encabezado_Informe = "FILTRO PRODUCTOS"

                    If _Filtrar.Fx_Filtrar(_Tbl_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

                        _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro

                    End If


                    Dim _Duplicados As Integer
                    Dim _NoDuplicados As Integer

                    If Not (_Tbl_Productos Is Nothing) Then

                        Consulta_sql = String.Empty

                        For Each _Fila As DataRow In _Tbl_Productos.Rows

                            Dim _Codigo = _Fila.Item("Codigo")
                            Dim _Descripcion = _Fila.Item("Descripcion")
                            Dim _Fecha = Format(FechaDelServidor, "yyyyMMdd")

                            Dim _Reg = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Demonio_Prestashop",
                                                        "Codigo = '" & _Codigo & "' And Peticion_Manual = 1 And Revisado = 0"))

                            If Not CBool(_Reg) Then
                                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Prestashop" & Space(1) &
                                                                            "(NombreEquipo,Idmaeedo,Idmaeddo,Codigo,Descripcion," &
                                                                            "Fecha,Peticion_Manual) Values" & Space(1) &
                                                                            "('" & _Nombre_Equipo & "',0,0,'" & _Codigo & "','" & _Descripcion & "','" & _Fecha & "',1)" & vbCrLf
                                _NoDuplicados += 1
                            Else
                                _Duplicados += 1
                            End If

                        Next

                        If CBool(_NoDuplicados) Then

                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                                MessageBoxEx.Show(_Fm_Menu_Padre, "Productos enviados correctamente" & vbCrLf &
                                                  "La actualización se llevara a cabo conforme a la programación",
                                                  "Prestashop, solicitud manual", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        End If

                        If CBool(_Duplicados) Then

                            If String.IsNullOrEmpty(Consulta_sql) Then
                                MessageBoxEx.Show(_Fm_Menu_Padre, "Existen productos que ya estan siendo procesados",
                                                  "Prestashop, solicitud manual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                        End If


                    End If

                End If

            Else

                MessageBoxEx.Show(_Fm_Menu_Padre, "No hay registros asociados en la base de datos para Prestashop",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

End Class
