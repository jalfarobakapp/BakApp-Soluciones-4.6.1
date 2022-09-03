Imports DevComponents.DotNetBar
Public Class Frm_MantCostosPrecios_CreaLista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Enum Enum_Accion
        Crear
        Editar
    End Enum

    Dim _Accion As Enum_Accion
    Dim _Koen As String
    Dim _Suen As String
    Dim _RowProveedor As DataRow
    Dim _RowListaPreCosto_Enc As DataRow
    Dim _Grabar As Boolean
    Dim _Id_Lista As Integer

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(_RowProveedor As DataRow, _Id_Lista As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Lista = _Id_Lista
        Me._Koen = _RowProveedor.Item("KOEN")
        Me._Suen = _RowProveedor.Item("SUEN")
        Me._RowProveedor = _RowProveedor

        Consulta_sql = "Select '' As Padre, '' As Hijo" & vbCrLf &
                       "Union" & vbCrLf &
                       "Select KOLT As Padre,KOLT+'-'+NOKOLT As Hijo" & vbCrLf &
                       "From TABPP" & vbCrLf &
                       "Where TILT = 'C'" & vbCrLf &
                       "And KOLT In (Select SUBSTRING(CodPermiso,4,6) From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & Space(1) &
                       "Where CodUsuario = '" & FUNCIONARIO & "' And CodPermiso LIKE 'Lp-%')"
        caract_combo(Cmb_Lista)
        Cmb_Lista.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Lista.SelectedValue = ""

        If CBool(_Id_Lista) Then

            Me._Accion = Enum_Accion.Editar

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Where Id = " & _Id_Lista
            _RowListaPreCosto_Enc = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_NombreLista.Text = _RowListaPreCosto_Enc.Item("NombreLista")
            Dtp_FechaVigenciaDesde.Value = _RowListaPreCosto_Enc.Item("FechaVigenciaDesde")
            Dtp_FechaVigenciaHasta.Value = _RowListaPreCosto_Enc.Item("FechaVigenciaHasta")

            Cmb_Lista.SelectedValue = _RowListaPreCosto_Enc.Item("Lista")

            If _RowListaPreCosto_Enc.Item("Vigente") Then
                Lbl_Estado.Text = "VIGENTE"
            Else
                Lbl_Estado.Text = "INACTIVA"
            End If

        Else
            Me._Accion = Enum_Accion.Crear
            Btn_Eliminar.Visible = False

            Dtp_FechaVigenciaDesde.Value = FechaDelServidor()
            Dtp_FechaVigenciaHasta.Value = ultimodiadelmes(FechaDelServidor)

        End If

        Lbl_Proveedor.Text = _RowProveedor.Item("KOEN").ToString.Trim &
                               "(" & _RowProveedor.Item("SUEN").ToString.Trim & ") - " & _RowProveedor.Item("NOKOEN")

    End Sub

    Private Sub Frm_MantCostosPrecios_CreaLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Sb_Crear_Lista()

        If Not Fx_Validar_Datos(Cmb_Lista.SelectedValue) Then
            Return
        End If

        Dim _Id_Padre As Integer
        Dim _FechaCreacion As String = Format(FechaDelServidor, "yyyyMMdd")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_ListaPreCosto_Enc (Lista,Proveedor,Sucursal,FechaVigenciaDesde,FechaVigenciaHasta,NombreLista,FechaCreacion,CodFuncionario_Crea) Values " &
                       "('" & Cmb_Lista.SelectedValue & "','" & _Koen & "','" & _Suen & "','" & Format(Dtp_FechaVigenciaDesde.Value, "yyyyMMdd") & "'" &
                       ",'" & Format(Dtp_FechaVigenciaHasta.Value, "yyyyMMdd") & "','" & Txt_NombreLista.Text & "',Getdate(),'" & FUNCIONARIO & "')"
        If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Padre) Then
            Return
        End If

        Dim Fm As New Frm_MantCostosPrecios(_RowProveedor, Cmb_Lista.SelectedValue)
        Fm.Id_Padre = _Id_Padre
        Fm.Dtp_FechaVigenciaDesde.Value = Dtp_FechaVigenciaDesde.Value
        Fm.Dtp_FechaVigenciaHasta.Value = Dtp_FechaVigenciaHasta.Value
        Fm.EsNuevaLista = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Grabar = True
        Me.Close()

    End Sub

    Sub Sb_Editar_Lista()

        If Not Fx_Validar_Datos(Cmb_Lista.SelectedValue) Then
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Set " &
                       "FechaVigenciaDesde = '" & Format(Dtp_FechaVigenciaDesde.Value, "yyyyMMdd") & "'" &
                       ",FechaVigenciaHasta = '" & Format(Dtp_FechaVigenciaHasta.Value, "yyyyMMdd") & "'" &
                       ",NombreLista = '" & Txt_NombreLista.Text.Trim & "'" &
                       ",CodFuncionario_Activa = '" & FUNCIONARIO & "'" &
                       ",FechaActivacionVigencia = Getdate()" & vbCrLf &
                       "Where Id = " & _Id_Lista
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
            Me.Close()
        End If

    End Sub

    Function Fx_Validar_Datos(_Lista As String) As Boolean

        If String.IsNullOrEmpty(Txt_NombreLista.Text.Trim) Then
            MessageBoxEx.Show(Me, "Debe ingresar un nombre a la lista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NombreLista.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Cmb_Lista.SelectedValue.ToString.Trim) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una lista de costos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If Dtp_FechaVigenciaHasta.Value < Dtp_FechaVigenciaDesde.Value Then
            MessageBoxEx.Show(Me, "La fecha ""Desde"" no puede ser mayor que la fecha ""Hasta""", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_ListaPreCosto_Enc",
                  "Id <> " & _Id_Lista & " And Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "'" &
                  " And Lista = '" & _Lista & "' And FechaVigenciaDesde = '" & Format(Dtp_FechaVigenciaDesde.Value, "yyyyMMdd") & "'")

        If CBool(Reg) Then
            If MessageBoxEx.Show(Me, "La lista de costos para esta fecha ya existe", "Validación",
                                 MessageBoxButtons.OK, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return False
            End If
        End If

        Dim _FechaDesde As Date = FormatDateTime(Dtp_FechaVigenciaDesde.Value, DateFormat.ShortDate)
        Dim _FechaHoy As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

        If _FechaDesde < _FechaHoy And Not CBool(_Id_Lista) Then
            MessageBoxEx.Show(Me, "La fecha ""Desde"" no puede ser menor a la fecha de hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Consulta_sql = "Select Max(FechaVigenciaHasta) As FechaHastaMax From " & _Global_BaseBk & "Zw_ListaPreCosto_Enc" & vbCrLf &
                       "Where Id <> " & _Id_Lista & " And Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) And Not (_Row.Item("FechaHastaMax") Is DBNull.Value) Then

            Dim _FechaHastaMax As Date = NuloPorNro(_Row.Item("FechaHastaMax"), _FechaDesde)

            If _FechaDesde <= _FechaHastaMax Then
                MessageBoxEx.Show(Me, "La fecha ""Desde"" no puede ser menor o igual a la fecha " & _FechaHastaMax, "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        End If

        Return True

    End Function

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Vigente As Boolean = _RowListaPreCosto_Enc.Item("Vigente")

        If _Vigente Then
            MessageBoxEx.Show(Me, "No puede eliminar una lista de precios vigente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar esta lista de costos de este proveedor?", "Eliminar lista",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Where Id = " & _Id_Lista & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Id_Padre = " & _Id_Lista
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Lista eliminada correctamente", "Eliminar lista", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click
        If _Accion = Enum_Accion.Crear Then
            Sb_Crear_Lista()
        End If

        If _Accion = Enum_Accion.Editar Then
            Sb_Editar_Lista()
        End If
    End Sub
End Class
