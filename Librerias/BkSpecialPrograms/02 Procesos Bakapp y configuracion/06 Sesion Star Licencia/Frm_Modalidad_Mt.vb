﻿Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Modalidad_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _ListaPrecio_BusquedaPR As String

    Private Sub BtnxAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxAceptar.Click
        Try

            If CmbModalidad.Text <> "" Then

                Mod_Modalidad = CmbModalidad.SelectedValue.ToString

                Consulta_sql = "Select top 1 Cest.*,Cfgp.RAZON  
                                From CONFIEST Cest WITH (NOLOCK) Inner Join CONFIGP Cfgp On Cest.EMPRESA = Cfgp.EMPRESA  
                                Where MODALIDAD = '" & Mod_Modalidad & "'"
                _Global_Row_Modalidad = _Sql.Fx_Get_DataRow(Consulta_sql)

                Mod_Empresa = _Global_Row_Modalidad.Item("EMPRESA") '"01"
                Mod_Sucursal = _Global_Row_Modalidad.Item("ESUCURSAL") 'TxtSucursal.Text
                Mod_Bodega = _Global_Row_Modalidad.Item("EBODEGA") 'TxtBodega.Text
                Mod_Caja = _Global_Row_Modalidad.Item("ECAJA") 'TxtCaja.Text
                Mod_ListaPrecioVenta = Mid(_Global_Row_Modalidad.Item("ELISTAVEN"), 6, 3) 'Mid(TxtLPCompra.Text, 6, 3)
                Mod_ListaPrecioCosto = Mid(_Global_Row_Modalidad.Item("ELISTACOM"), 6, 3) 'Mid(TxtLPVenta.Text, 6, 3)

                _ListaPrecio_BusquedaPR = Mod_ListaPrecioVenta
                ' MsgBox("Modalidad Fue cambiada", MsgBoxStyle.Information, "Cambiar Modalidad")

                Me.Close()
            Else
                MsgBox("Debe seleccionar una modalidad", MsgBoxStyle.Critical, "Modalidad")
            End If

        Catch ex As Exception
            MsgBox("Debe seleccionar una modalidad", MsgBoxStyle.Critical, "Modalidad")
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Frm_Modalidad_Mt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "SELECCIONE MODALIDAD, EMPRESA: " & RazonEmpresa
        Actualizar()
    End Sub


    Sub Actualizar()

        caract_combo(CmbModalidad)
        Consulta_sql = "SELECT MODALIDAD AS Padre,MODALIDAD AS Hijo FROM CONFIEST WITH (NOLOCK) where EMPRESA = '01'" & vbCrLf &
                       "and MODALIDAD <> '  '"

        Consulta_sql = "SELECT SUBSTRING(KOOP,4,6) AS Padre ,SUBSTRING(KOOP,4,6) AS Hijo FROM MAEOP WHERE " & vbCrLf &
                      "KOOP IN (SELECT KOOP FROM MAEUS WHERE KOUS = '" & FUNCIONARIO & "' AND KOOP LIKE 'MO-%')" & vbCrLf &
                      "AND KOOP <> 'MO-  '"

        CmbModalidad.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CmbModalidad.Items.Count > 0 Then
            Mod_Modalidad = _Sql.Fx_Trae_Dato("TABFU", "MODALIDAD", "KOFU = '" & FUNCIONARIO & "'")

            If Mod_Modalidad <> "  " Then
                CmbModalidad.SelectedValue = Mod_Modalidad
                RevModalidad(Mod_Modalidad, "01")
            End If
        Else
            MsgBox("Usted no posee permiso para trabajar con ninguna modalidad de Random." & vbCrLf &
                   "Póngase en contacto con el administrador del sistema", MsgBoxStyle.Critical, "Modalidad")
        End If

    End Sub


    Function RevModalidad(ByVal Modalidad As String, ByVal Empresa As String)

        Consulta_sql = "Select Top 1 * From CONFIEST WITH (NOLOCK) Where MODALIDAD = '" & Modalidad & "'"
        Dim _RowConfiest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        TxtSucursal.Text = _RowConfiest.Item("ESUCURSAL")
        TxtBodega.Text = _RowConfiest.Item("EBODEGA")
        TxtCaja.Text = _RowConfiest.Item("ECAJA")
        TxtLPCompra.Text = _RowConfiest.Item("ELISTACOM")
        TxtLPVenta.Text = _RowConfiest.Item("ELISTAVEN")

    End Function

    Private Sub CmbModalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbModalidad.SelectedIndexChanged
        RevModalidad(CmbModalidad.SelectedValue.ToString, Mod_Modalidad)
    End Sub

    Private Sub BtnxActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxActualizar.Click
        Actualizar()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'EstiloFormulario(StyleManager1)
    End Sub
End Class
