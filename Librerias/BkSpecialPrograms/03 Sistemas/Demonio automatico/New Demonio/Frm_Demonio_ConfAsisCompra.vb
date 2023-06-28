Imports DevComponents.DotNetBar

Public Class Frm_Demonio_ConfAsisCompra

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _Row_Configuracion As DataRow
    Dim _Row_Programacion As DataRow

    Dim _Programacion As Cl_NewProgramacion

    Public Property Grabar As Boolean

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property Programacion As Cl_NewProgramacion
        Get
            Return _Programacion
        End Get
        Set(value As Cl_NewProgramacion)
            _Programacion = value
        End Set
    End Property

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto Where Id = " & _Id
        _Row_Configuracion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Demonio_ConfAsisCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Id_Padre = _Global_Row_EstacionBk.Item("Id")
        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion" & vbCrLf &
                       "Where Id_Padre = " & _Id_Padre & " And NombreEquipo = '" & _NombreEquipo & "' And Nombre = 'AsistenteCompras'"
        Dim _Row_Programacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Configuracion) Then
            Txt_Modalidad.Text = _Row_Configuracion.Item("Modalidad")
            Chk_NVI.Checked = _Row_Configuracion.Item("NVI")
            Chk_OCC_Star.Checked = _Row_Configuracion.Item("OCC_Star")
            Chk_OCC_Prov.Checked = _Row_Configuracion.Item("OCC_Prov")
        End If

        If Not CBool(_Id) Then
            _Programacion = New Cl_NewProgramacion
            _Programacion.Nombre = "Nueva programacion"
        End If

        _Programacion.FrecuSemanal = True
        _Programacion.SucedeUnaVez = True
        _Programacion.HoraUnaVez = _Row_Programacion.Item("HoraUnaVez")

        Btn_ConfProgramacion.Enabled = True
        Txt_Resumen.Text = _Programacion.Resumen

        Btn_Eliminar.Visible = CBool(_Id)
        Txt_Modalidad.Enabled = Not CBool(_Id)

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        If String.IsNullOrEmpty(Txt_Modalidad.Text) Then
            MessageBoxEx.Show(Me, "Falta la modalidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not Chk_NVI.Checked And Not Chk_OCC_Star.Checked And Not Chk_OCC_Prov.Checked Then
            MessageBoxEx.Show(Me, "Falta el tipo de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not CBool(_Id) Then
            Dim _Id_Existe As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfAcpAuto", "Id",
                                    "NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Txt_Modalidad.Text & "'" &
                                    " And NVI = " & Convert.ToInt32(Chk_NVI.Checked) &
                                    " And OCC_Star = " & Convert.ToInt32(Chk_OCC_Star.Checked) &
                                    " And OCC_Prov = " & Convert.ToInt32(Chk_OCC_Prov.Checked), True)

            If CBool(_Id_Existe) Then
                MessageBoxEx.Show(Me, "Ya existe una programación para esta modalidad y combinación de documentos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Not _Programacion.Validada Then
            MessageBoxEx.Show(Me, "Falta programación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_OCC_Star.Checked Then

            Dim _CodProveedor_Pstar = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                         "Valor",
                                         "Informe = 'Compras_Asistente' And Campo = 'Koen_Especial' And NombreEquipo = '" & _NombreEquipo & "' " &
                                         "And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Txt_Modalidad.Text & "'")
            Dim _CodSucProveedor_Pstar = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                         "Valor",
                                         "Informe = 'Compras_Asistente' And Campo = 'Suen_Especial' And NombreEquipo = '" & _NombreEquipo & "' " &
                                         "And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Txt_Modalidad.Text & "'")

            Consulta_sql = "Select * From MAEEN Where KOEN = '" & _CodProveedor_Pstar & "' And SUEN = '" & _CodSucProveedor_Pstar & "'"
            Dim _RowProveedor As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_RowProveedor) Then
                MessageBoxEx.Show(Me, "No esta asignado el proveedore especial para OCC al proveedor estrella." & vbCrLf & vbCrLf &
                                  "Revise la pestaña [Bod.Ext. Prov. Especial] en la configuración del asistente para la modalidad: " & Txt_Modalidad.Text,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

            If Not CBool(_Id) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto (NombreEquipo,Modalidad,NVI,OCC_Star,OCC_Prov) Values " &
               "('" & _NombreEquipo & "','" & Txt_Modalidad.Text & "'" &
               "," & Convert.ToInt32(Chk_NVI.Checked) & "," & Convert.ToInt32(Chk_OCC_Star.Checked) & "," & Convert.ToInt32(Chk_OCC_Prov.Checked) & ")"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

            _Programacion.Tbl_Padre = "AcoAuto"
            _Programacion.Id_Padre = _Id

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion (NombreEquipo,Tbl_Padre,Id_Padre,Nombre,FrecuDiaria,SucedeUnaVez) Values " &
                           "('" & _NombreEquipo & "','AcoAuto'," & _Id & ",'',1,1)"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Programacion.Id)

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto Set " &
                       "Modalidad = '" & Txt_Modalidad.Text & "'" &
                       ",NVI = " & Convert.ToInt32(Chk_NVI.Checked) &
                       ",OCC_Star = " & Convert.ToInt32(Chk_OCC_Star.Checked) &
                       ",OCC_Prov = " & Convert.ToInt32(Chk_OCC_Prov.Checked) & vbCrLf &
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Grb_Programacion As New Grb_Programacion
        _Grb_Programacion.Sb_Actualizar_programacion(_Programacion)

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Btn_ConfProgramacion_Click(sender As Object, e As EventArgs) Handles Btn_ConfProgramacion.Click

        'Programacion = New Cl_NewProgramacion
        'Programacion.SucedeUnaVez = True
        'Programacion.HoraUnaVez = "01-01-1900 00:00"
        Programacion.Validada = True

        Dim Fm As New Frm_Demonio_ConfProgramacion(False, False, False, "")
        Fm.Programacion = _Programacion
        Fm.Grupo_Frecuencia.Enabled = False
        Fm.Txt_Nombre.ReadOnly = True
        Fm.Rdb_FrecuDiaria.Enabled = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Txt_Resumen.Text = _Programacion.Resumen

    End Sub

    Private Sub Txt_Modalidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Modalidad.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        Dim _Tbl As DataTable

        If Not String.IsNullOrEmpty(Txt_Modalidad.Text) Then

            Consulta_sql = "Select Distinct Cast(1 As Bit) As Chk,MODALIDAD As Codigo, MODALIDAD As Descripcion" & vbCrLf &
                           "From CONFIEST" & vbCrLf &
                           "Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD In " & Txt_Modalidad.Text
            _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

        If _Filtrar.Fx_Filtrar(_Tbl,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And EMPRESA = '" & ModEmpresa & "'",
                               Nothing, False, True) Then

            Txt_Modalidad.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")

        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de esta programación?", "Eliminar programación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_ConfAcpAuto Where Id = " & _Id & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Demonio_ConfProgramacion Where Id = " & _Programacion.Id
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grabar = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_ConfAsisCompra_Click(sender As Object, e As EventArgs) Handles Btn_ConfAsisCompra.Click

        If String.IsNullOrEmpty(Txt_Modalidad.Text) Then
            MessageBoxEx.Show(Me, "Falta la modalidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_00_Asis_Compra_Menu(Txt_Modalidad.Text)
        Fm.Tipo_Informe = "Asistente de compras Configuración de OCC automatizadas"
        Fm.Modo_OCC = True
        Fm.Modo_ConfAuto = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
