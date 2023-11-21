Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_GRI_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_GRI_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Ingresar_GRI_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_GRI.Click

        If Not Fx_Revisar_Taza_Cambio(Me) Then
            Return
        End If

        Dim Fm As New Frm_GRI_FabXProducto
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_ImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles Btn_ImprimirEtiquetas.Click

        Dim Fm As New Frm_ImpBarras_Tarja
        Fm.ShowDialog(Me)
        Fm.Dispose()

        'Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        '_Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "GRI")
        '_Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
        '_Fm.Rdb_Tipo_Documento_Algunos.Enabled = False

        '_Fm.Rdb_Fecha_Emision_Cualquiera.Checked = False
        '_Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True

        '_Fm.Rdb_Tipo_Documento_Algunos.Checked = False
        '_Fm.Rdb_Tipo_Documento_Uno.Checked = True

        '_Fm.ShowDialog(Me)
        'Dim _RowDocumento As DataRow = _Fm.Pro_Row_Documento_Seleccionado
        '_Fm.Dispose()

        'If Not (_RowDocumento Is Nothing) Then

        'Dim _Aceptar As Boolean
        'Dim _Numot As String

        '_Aceptar = InputBox_Bk(Me, "Numero de OT", "Imprimir etquetas de OT", _Numot, False,, 10, True,,,, False)

        'If Not _Aceptar Then
        '    Return
        'End If

        'Dim _Nudo As String = Fx_Rellena_ceros(_Numot, 10)
        'Dim _Nro As String

        '_Nro = Replace(_Nudo, "-", ",")

        'Dim _Cadena = Split(_Nro, ",")

        'If _Cadena.Length = 2 Then
        '    _Nudo = Fx_Rellena_ceros(_Cadena(1), 10)
        'Else
        '    _Numot = _Nudo
        'End If

        'Consulta_sql = "Select * From POTE Where NUMOT = '" & _Numot & "'"
        'Dim _Row_Pote As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        'If IsNothing(_Row_Pote) Then
        '    MessageBoxEx.Show(Me, "No existe la OT Nro: " & _Numot, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    _Numot = String.Empty
        '    Return
        'End If

        'Dim _Idpote As Integer = _Row_Pote.Item("IDPOTE")
        'Dim _Idpotl As Integer

        'Dim _Row_Potl As DataRow = Fx_Buscar_Potl(_Idpote)

        'If IsNothing(_Row_Potl) Then
        '    Return
        'End If

        '_Idpotl = _Row_Potl.Item("IDPOTL")

        'Dim Fm As New Frm_ImpBarras_PorOT(_Idpote, _Idpotl)
        'Fm.ShowDialog(Me)
        'Fm.Dispose()

    End Sub

    Function Fx_Buscar_Potl(_Idpote As Integer) As DataRow

        Dim _Row_Potl As DataRow

        Consulta_sql = "Select *,(FABRICAR-REALIZADO) As SALDO From POTL" & vbCrLf &
                       "Where IDPOTE = " & _Idpote & " And LILG <> 'IM'"

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_GRI_ProductosOT
        Fm.Tbl_Productos = _Tbl_Productos
        Fm.ShowDialog(Me)
        _Row_Potl = Fm.FilaSeleccionada
        Fm.Dispose()

        Return _Row_Potl

    End Function

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles BtnConfiguracion.Click

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
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Frm_GRI_Ingreso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Fx_Tiene_Permiso(Me, "7Brr0007") Then
            e.Cancel = True
        End If
    End Sub
End Class
