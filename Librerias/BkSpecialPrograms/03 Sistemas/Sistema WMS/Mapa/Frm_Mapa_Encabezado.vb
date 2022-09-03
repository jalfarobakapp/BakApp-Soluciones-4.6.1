Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Mapa_Encabezado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowBodega As DataRow
    Dim _Grabar As Boolean
    Dim _RowMapa As DataRow

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public ReadOnly Property Pro_RowMapa() As DataRow
        Get
            Return _RowMapa
        End Get
    End Property

    Public Sub New(ByVal RowBodega As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _RowBodega = RowBodega
    End Sub

    Private Sub Frm_Mapa_Encabezado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LblEmpresa.Text = _RowBodega.Item("RAZON")
        LblSucursal.Text = _RowBodega.Item("NOKOSU")
        LblBodega.Text = _RowBodega.Item("NOKOBO")

        AddHandler Btn_Grabar.Click, AddressOf Sb_Nuevo_Mapa

    End Sub

#Region "PROCEDIMIENTOS"

#Region "CREAR MAPA"

    Sub Sb_Nuevo_Mapa()

        Dim _Largo = 100000 'TxtLargo.Text * 100
        Dim _Ancho = 100000 'TxtAncho.Text * 100

        Dim _Empresa = _RowBodega.Item("EMPRESA")
        Dim _Sucursal = _RowBodega.Item("KOSU")
        Dim _Bodega = _RowBodega.Item("KOBO")


        If String.IsNullOrEmpty(Trim(TxtNombreMapa.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA NOMBRE DEL MAPA",
                                  My.Resources.cross,
                                 2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            TxtNombreMapa.Focus()
            Return
        End If

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc",
                                                             "Empresa = '" & _Empresa & "' And " &
                                                             "Sucursal = '" & _Sucursal & "' And " &
                                                             "Bodega = '" & _Bodega & "' And Nombre_Mapa = '" & Trim(TxtNombreMapa.Text) & "'"))

        If _Reg Then
            MessageBoxEx.Show(Me, "El nombre de este mapa ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        Else

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc " &
                     "(Empresa,Sucursal,Bodega,Nombre_Mapa) Values " & vbCrLf &
                     "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & Trim(TxtNombreMapa.Text) & "')" & vbCrLf &
                      "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc" & Space(1) &
                      "Where Nombre_Mapa = '" & Trim(TxtNombreMapa.Text) & "'"

            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                _RowMapa = _Tbl.Rows(0)
                _Grabar = True
                Me.Close()
            End If

        End If


    End Sub

#End Region

#End Region

    Private Sub Frm_Mapa_Encabezado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class