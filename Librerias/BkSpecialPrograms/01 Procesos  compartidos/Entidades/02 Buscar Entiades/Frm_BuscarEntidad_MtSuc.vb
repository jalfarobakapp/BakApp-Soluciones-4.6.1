'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_BuscarEntidad_MtSuc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public _CodEntidad As String
    Public CodSucEntidad As String
    Public _Suc_Seleccionada As Boolean
    Public _Tbl_SucursalSelec As DataTable

    Public _Seleccionar As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)

        CodSucEntidad = String.Empty

        _Suc_Seleccionada = False
        Sb_Color_Botones_Barra(Bar2)

    End Sub
    Private Sub Frm_BuscarEntidad_MtSuc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Seleccionar sucursal de la entidad: " & _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _CodEntidad & "'")
        Sb_Actualizar_Grilla()
    End Sub
    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select KOEN,SUEN,SIEN,Rtrim(Ltrim(DIEN))+'... '+Rtrim(Ltrim(NOKOCM)) As DIEN  
                        From MAEEN 
                        Left Join TABPA On KOPA = PAEN
                        Left Join TABCI On TABCI.KOPA = PAEN And TABCI.KOCI = CIEN
                        Left Join TABCM On TABCM.KOPA = PAEN And TABCM.KOCI = CIEN And TABCM.KOCM = CMEN
                        Where KOEN = '" & _CodEntidad & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        With Grilla
            .DataSource = _Tbl
            .Columns("KOEN").HeaderText = "Código"
            .Columns("KOEN").Width = 80
            .Columns("SUEN").HeaderText = "Sucursal"
            .Columns("SUEN").Width = 60
            .Columns("SIEN").HeaderText = "Sigla"
            .Columns("SIEN").Width = 100
            .Columns("DIEN").HeaderText = "Dirección"
            .Columns("DIEN").Width = 350
        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If _Seleccionar Then

            Dim _CodEntidad_Suc As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOEN").Value
            Dim _SucEntidad_Suc As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("SUEN").Value

            'Consulta_Sql = "Select * From MAEEN Where KOEN = '" & _CodEntidad_Suc & "' And SUEN = '" & _SucEntidad_Suc & "'"
            _Tbl_SucursalSelec = Fx_Traer_Datos_Entidad_Tabla(_CodEntidad_Suc, _SucEntidad_Suc) ' _Sql.Fx_Get_Tablas(Consulta_Sql)

            _Suc_Seleccionada = True

            Me.Close()
        Else
            Sb_Editar_sucursal()
        End If

    End Sub



    Private Sub BtnEditarEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditarEntidad.Click
        Sb_Editar_sucursal()
    End Sub

    Sub Sb_Editar_sucursal()

        If Fx_Tiene_Permiso(Me, "CfEnt001") Then

            With Grilla

                Dim _CodEntidad_Suc As String = .Rows(.CurrentRow.Index).Cells("KOEN").Value
                Dim _SucEntidad_Suc As String = .Rows(.CurrentRow.Index).Cells("SUEN").Value

                Dim Fm As New Frm_Crear_Entidad_Mt
                Fm.Fx_Llenar_Entidad(_CodEntidad_Suc, _SucEntidad_Suc)
                Fm.CrearEntidad = False
                Fm.EditarEntidad = True
                Fm.BtnEliminarUser.Visible = False
                Fm.ShowDialog(Me)

                Sb_Actualizar_Grilla()

            End With

        End If

    End Sub

    Private Sub BtnCrearUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrearUser.Click

        If Fx_Tiene_Permiso(Me, "CfEnt001") Then

            Dim Fm As New Frm_Crear_Entidad_Mt
            Fm.CrearEntidad = True
            Fm.Txt_Koen.Text = _CodEntidad
            Fm.Txt_Koen.Enabled = False
            Fm.EditarEntidad = False
            Fm.Sb_Crear_Sucursal()
            Fm.ShowDialog(Me)

            If Fm.CreaNuevaEntidad Then
                Sb_Actualizar_Grilla()
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Frm_BuscarEntidad_MtSuc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        Try
            If e.KeyValue = Keys.Enter Then
                SendKeys.Send("{LEFT}")
                e.Handled = True
                Call Grilla_CellDoubleClick(Nothing, Nothing)
            End If
        Catch ex As Exception
            Beep()
        End Try

    End Sub

    'Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

    '    Try
    '        If e.KeyValue = Keys.Enter Then
    '            SendKeys.Send("{F2}")
    '            e.Handled = True
    '            Call Grilla_CellDoubleClick(Nothing, Nothing)
    '        End If
    '    Catch ex As Exception
    '        Beep()
    '    End Try

    'End Sub
End Class
