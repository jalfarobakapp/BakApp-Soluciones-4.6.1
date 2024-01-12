Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_Tarja

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Puerto, _Etiqueta As String
    Dim _Row_Tarja As DataRow

    Dim _Veces As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_ImpBarras_Tarja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        Dim _Arr_Filtro(,) As String

        _Arr_Filtro = {{"LPT1", "Puerto LPT1"},
                       {"LPT2", "Puerto LPT2"},
                       {"LPT3", "Puerto LPT3"},
                       {"LPT4", "Puerto LPT4"}}
        Sb_Llenar_Combos(_Arr_Filtro, CmbPuerto)
        CmbPuerto.SelectedValue = "LPT1"

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT NombreEtiqueta AS Padre,NombreEtiqueta+', Cantidad de etiquetas por fila '+RTRIM(LTRIM(STR(CantPorLinea))) AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Tbl_DisenoBarras order by NombreEtiqueta"
        Cmbetiquetas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmbetiquetas.SelectedValue = _Etiqueta

        AddHandler Cmbetiquetas.SelectedIndexChanged, AddressOf Sb_Cmbetiquetas_SelectedIndexChanged

        Call Sb_Cmbetiquetas_SelectedIndexChanged(Nothing, Nothing)

        If Not String.IsNullOrEmpty(Txt_Nro_CPT.Text) Then
            Call Txt_Nro_CPT_ButtonCustomClick(Nothing, Nothing)
        End If

        Me.ActiveControl = Txt_Nro_CPT

    End Sub

    Private Sub Txt_Nro_CPT_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Nro_CPT.ButtonCustomClick

        Dim _Nro_CPT As String = numero_(Txt_Nro_CPT.Text, 10)

        Consulta_sql = "Select Trj.*,Isnull(NOKOFU,'') As 'Analista_Str',Isnull(Plt.NombreTabla,'') As 'Planta_Str'" &
                       ",Isnull(Trn.NombreTabla,'') As 'Turno_Str',Isnull(Bar.NombreTabla,0) As SemillaBar" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja Trj" & vbCrLf &
                       "Left Join TABFU On KOFU = Analista" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Plt On Plt.Tabla = 'TARJA_PLANTA' And Plt.CodigoTabla = Planta" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Trn On Trn.Tabla = 'TARJA_TURNO' And Trn.CodigoTabla = Turno" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Bar On Bar.Tabla = 'TARJA_CODBARRA' And Bar.CodigoTabla = Tipo" & vbCrLf &
                       "Where Nro_CPT = '" & _Nro_CPT & "'"

        _Row_Tarja = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Tarja) Then
            MessageBoxEx.Show(Me, "No se encontro el registro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Nro_CPT.SelectAll()
            Return
        End If

        Txt_Nro_CPT.Text = _Nro_CPT
        Txt_NroLote.Text = _Row_Tarja.Item("Lote")
        Txt_Turno.Text = _Row_Tarja.Item("Turno_Str")
        Txt_Planta.Text = _Row_Tarja.Item("Planta_Str")
        Txt_Analista.Text = _Row_Tarja.Item("Analista_Str").ToString.Trim
        Txt_Observaciones.Text = _Row_Tarja.Item("Observaciones")
        Lbl_Tipo.Text = _Row_Tarja.Item("Tipo")
        Txt_Descripcion_Kopral.Text = _Row_Tarja.Item("Descripcion_Kopral")

        Dim _CantidadTipo As Double = _Row_Tarja.Item("CantidadTipo")

        ' Si Veces = 0 Se imprime 1
        ' Si veces > 1 Se imprime xveces * CantidadTipo

        _Veces = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                   "Valor", "Tabla = 'TARJA_MULTIMPETIQU' And CodigoTabla = '" & Lbl_Tipo.Text & "'", True, False)

        If CBool(_Veces) Then
            _Veces = _Veces * _CantidadTipo
        Else
            _Veces = 1
        End If

        Dim _Udm As String = _Row_Tarja.Item("Udm")
        Dim _Formato As Integer = _Row_Tarja.Item("Formato")

        If CBool(_Row_Tarja.Item("SemillaBar")) Then
            Dim _NombreEtiqueta As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras",
                                            "NombreEtiqueta", "Semilla = " & _Row_Tarja.Item("SemillaBar"))
            Cmbetiquetas.SelectedValue = _NombreEtiqueta
        End If

    End Sub

    Private Sub BtnImprimirEtiqueta_Click(sender As Object, e As EventArgs) Handles BtnImprimirEtiqueta.Click
        Sb_Imprimir_Etiquetas()
    End Sub

    Private Sub Sb_Cmbetiquetas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Semilla As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "Semilla",
                                                    "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'", True)
        Dim _Puerto As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras_SalPtoxEstacion", "Puerto",
                                                  "Semilla_Padre = " & _Semilla & " And NombreEquipo = '" & _NombreEquipo & "'")

        If Not String.IsNullOrEmpty(_Puerto) Then
            CmbPuerto.SelectedValue = _Puerto
        End If

    End Sub

    Private Sub Btn_Conf_PuertoEtiqueta_Click(sender As Object, e As EventArgs) Handles Btn_Conf_PuertoEtiqueta.Click

        If Not Fx_Tiene_Permiso(Me, "7Brr0006") Then Return

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            CmbPuerto.SelectedValue = Fm.Puerto
            Cmbetiquetas.SelectedValue = Fm.Etiqueta
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Conf_ConfEstacion_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfEstacion.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then

            Dim _Grabar As Boolean

            Dim _Id = _Global_Row_EstacionBk.Item("Id")
            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Editar, _Id, False)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            Dim _Mod As New Clas_Modalidades

            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _NombreEquipo & "'"
            _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _Grabar Then
                '_CerrarPorConfigurar = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Txt_Nro_CPT_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Nro_CPT.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Txt_Nro_CPT_ButtonCustomClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click

        Txt_Nro_CPT.Text = String.Empty
        Txt_NroLote.Text = String.Empty
        Txt_Turno.Text = String.Empty
        Txt_Planta.Text = String.Empty
        Txt_Analista.Text = String.Empty
        Txt_Descripcion_Kopral.Text = String.Empty
        Txt_Observaciones.Text = String.Empty
        Txt_Observaciones.ReadOnly = False
        Lbl_Tipo.Text = "TIPO..."
        _Row_Tarja = Nothing
        Txt_Nro_CPT.Focus()

    End Sub

    Sub Sb_Imprimir_Etiquetas()

        Try

            _Puerto = CmbPuerto.SelectedValue
            Dim _CantPorLinea As Integer

            If IsNothing(Cmbetiquetas.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            If String.IsNullOrEmpty(Cmbetiquetas.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            If IsNothing(_Row_Tarja) Then
                Beep()
                ToastNotification.Show(Me, "NO HAY DATOS QUE IMPRIMIR",
                                      My.Resources.cross,
                                     1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If

            _CantPorLinea = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "CantPorLinea",
                                      "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'")

            If _CantPorLinea = 0 Then _CantPorLinea = 1

            Dim _CanXlinea As Integer = _CantPorLinea

            Dim _Aceptar As Boolean

            _Aceptar = InputBox_Bk(Me, "Ingrese la cantidad de etiquetas que quiere imprimir",
                                   "Imprimir Etiquetas", _Veces, False,, 2, True, _Tipo_Imagen.Barra,,
                                   _Tipo_Caracter.Solo_Numeros_Enteros, False)

            If Not _Aceptar Then
                Return
            End If

            If _CanXlinea = _Veces Or _CanXlinea > _Veces Then
                _Veces = 1
            Else
                Dim _ModVeces = _Veces Mod 2
                Dim _ModCanXlinea = _CanXlinea Mod 2

                If _CanXlinea <> 1 Then

                    If CBool(_ModVeces) Or CBool(_ModCanXlinea) Then

                        _Veces = Math.Round((_Veces / _CanXlinea), 5)
                        Dim _Des = Split(_Veces, ",")

                        If _Des.Length = 2 Then
                            _Veces = _Des(0) + 1
                        End If

                    Else
                        _Veces = Math.Round((_Veces / _CanXlinea), 0)
                    End If
                End If
            End If

            If _Veces < 1 Then _Veces = 1

            For w = 1 To _Veces

                Dim _Imp As New Class_Imprimir_Barras

                _Imp.Sb_Imprimir_Tarja(Cmbetiquetas.SelectedValue, _Puerto, ModEmpresa, _Row_Tarja.Item("Id"))

                If Not String.IsNullOrEmpty(_Imp.Error) Then
                    If MessageBoxEx.Show(Me, _Imp.Error, "Problema al imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) <> DialogResult.OK Then
                        Return
                    End If
                End If

            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

        End Try

    End Sub

End Class
