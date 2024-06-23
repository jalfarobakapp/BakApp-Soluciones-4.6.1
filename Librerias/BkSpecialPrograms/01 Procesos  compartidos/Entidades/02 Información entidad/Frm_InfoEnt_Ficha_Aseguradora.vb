Imports DevComponents.DotNetBar

Public Class Frm_InfoEnt_Ficha_Aseguradora

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Row_Entidad_Cia_Seguros As DataRow
    Dim _Actualizado As Boolean

    Public ReadOnly Property Pro_Actualizado() As Boolean
        Get
            Return _Actualizado
        End Get
    End Property

    Public Sub New(ByVal Rten As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select Top 1 RTEN As _Rut,NOKOEN As Razon," & _
                            "CAST(0 As Float) as Monto_Asignado,CAST('' As Varchar(3)) As Moneda," & _
                            "CAST('' As Varchar(20)) As Clascrediticia,CAST(Null As Date) As Fecha_Vigencia," & _
                            "CAST(0 As Float) as Porc_Exposicion" & vbCrLf & _
                            "Into #Paso1" & vbCrLf & _
                            "FROM MAEEN WHERE RTEN = '" & Trim(Rten) & "' ORDER BY TIPOSUC" & vbCrLf & _
                            "Update #Paso1 Set Monto_Asignado = Isnull((Select Monto_Asignado From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),0)," & vbCrLf & _
                            "Moneda =  Isnull((Select Moneda From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),'$')," & vbCrLf & _
                            "Clascrediticia = Isnull((Select Clascrediticia From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),'003')," & vbCrLf & _
                            "Fecha_Vigencia = Isnull((Select Fecha_Vigencia From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),GETDATE())," & vbCrLf & _
                            "Porc_Exposicion = Isnull((Select Porc_Exposicion From " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros Where Rut = _Rut),100)" & vbCrLf & _
                            "Select Top 1 * From #Paso1" & vbCrLf & _
                            "Drop Table #Paso1"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then
            _Row_Entidad_Cia_Seguros = _Tbl.Rows(0)
        End If


        Dim _Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf

        caract_combo(Cmb_Clascrediticia)
        Consulta_sql = _Union & "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "WHERE Tabla = 'NEGOCIO_CLASCREDI'" & vbCrLf & _
                       "ORDER BY Padre"
        Cmb_Clascrediticia.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmb_Moneda)
        Consulta_sql = "SELECT KOMO AS Padre,LTRIM(RTRIM(NOKOMO))+' - '+KOMO AS Hijo" & vbCrLf & _
                       "FROM TABMO" & vbCrLf & _
                       "Where KOMO In ('$','UF')" & vbCrLf & _
                       "ORDER BY Padre"
        Cmb_Moneda.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Private Sub Frm_InfoEnt_Ficha_Aseguradora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Cmb_Clascrediticia.Enabled = False
        Cmb_Moneda.Enabled = False
        Num_Monto_Asignado.Enabled = False
        Dtp_Fecha_Vigencia.Enabled = False
        Btn_Grabar.Enabled = False
        Btn_Editar.Enabled = True
        Num_Porc_Exposicion.Enabled = False

        Dim _Rut = _Row_Entidad_Cia_Seguros.Item("_Rut")
        _Rut = FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut)

        Txt_Rut.Text = _Rut
        Txt_Razon.Text = _Row_Entidad_Cia_Seguros.Item("Razon")
        Num_Monto_Asignado.Text = _Row_Entidad_Cia_Seguros.Item("Monto_Asignado")
        Cmb_Moneda.SelectedValue = _Row_Entidad_Cia_Seguros.Item("Moneda")
        Cmb_Clascrediticia.SelectedValue = _Row_Entidad_Cia_Seguros.Item("Clascrediticia")
        Dtp_Fecha_Vigencia.Value = _Row_Entidad_Cia_Seguros.Item("Fecha_Vigencia")
        Num_Porc_Exposicion.Value = _Row_Entidad_Cia_Seguros.Item("Porc_Exposicion")

        'AddHandler Txt_Monto_Asignado.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        'AddHandler Txt_Monto_Asignado.KeyPress, AddressOf Txt_KeyPress_Enter

    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click

        If Fx_Tiene_Permiso(Me, "CfEnt025") Then

            Cmb_Clascrediticia.Enabled = True
            Cmb_Moneda.Enabled = True
            Num_Monto_Asignado.Enabled = True
            Dtp_Fecha_Vigencia.Enabled = True
            Btn_Grabar.Enabled = True
            Btn_Editar.Enabled = False
            Num_Porc_Exposicion.Enabled = True

            Txt_Monto_Asignado.Focus()

        End If

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Dim _Rut = _Row_Entidad_Cia_Seguros.Item("_Rut")
        Dim _Monto_Asignado = De_Num_a_Tx_01(Num_Monto_Asignado.Value, False, 5)
        Dim _Moneda = Cmb_Moneda.SelectedValue
        Dim _Clascrediticia = Cmb_Clascrediticia.SelectedValue
        Dim _Fecha_Vigencia = Format(Dtp_Fecha_Vigencia.Value, "yyyyMMdd")
        Dim _Porc_Exposicion = De_Num_a_Tx_01(Num_Porc_Exposicion.Value, False, 2)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros" & vbCrLf & _
                       "Where Rut = '" & _Rut & "'" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_Entidad_Cia_Seguros" & Space(1) & _
                       "(Rut,Monto_Asignado,Moneda,Clascrediticia, Fecha_Vigencia,Porc_Exposicion) Values" & Space(1) & _
                       "('" & _Rut & "'," & _Monto_Asignado & ",'" & _Moneda & "','" & _Clascrediticia & "','" & _Fecha_Vigencia & "'," & _Porc_Exposicion & ")"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            _Actualizado = True
            Me.Close()
        End If

    End Sub


    Private Sub Frm_InfoEnt_Ficha_Aseguradora_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    'Private Sub Txt_Monto_Asignado_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Monto_Asignado.Validated

    '_Row_Entidad_Cia_Seguros.Item("Monto_Asignado") = Val(Txt_Monto_Asignado.Text)
    'Txt_Monto_Asignado.Text = FormatNumber(_Row_Entidad_Cia_Seguros.Item("Monto_Asignado"), 0)

    'End Sub

    'Private Sub Txt_Monto_Asignado_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Monto_Asignado.Enter
    'Dim _Monto_Asignado As Double = _Row_Entidad_Cia_Seguros.Item("Monto_Asignado")

    'If CBool(_Monto_Asignado) Then
    'Txt_Monto_Asignado.Text = _Monto_Asignado
    'Else
    'Txt_Monto_Asignado.Text = String.Empty
    'End If
    'End Sub

    Private Sub Txt_KeyPress_Enter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'Sb_Txt_KeyPress_Solo_Numeros

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

End Class