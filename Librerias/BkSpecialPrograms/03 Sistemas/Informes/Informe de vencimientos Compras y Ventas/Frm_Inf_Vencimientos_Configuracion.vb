'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Inf_Vencimientos_Configuracion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _Id_Correo As Integer
    Public _Ds_Filtro As New Ds_Inf_Venc_ComVta

    Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\Filtro_Informes"
    Dim _Nombre_Archivo_XML As String '= "DS_Filtro_Informe_vencimientos.xml"

    Dim _Fecha_Emision_Desde, _Fecha_Emision_Hasta As Date

    Public Sub New(ByVal New_Nombre_Archivo_XML As String, _
                   ByVal New_Fecha_Emision_Desde As Date, _
                   ByVal New_Fecha_Emision_Hasta As Date)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Nombre_Archivo_XML = New_Nombre_Archivo_XML
        _Fecha_Emision_Desde = New_Fecha_Emision_Desde
        _Fecha_Emision_Hasta = New_Fecha_Emision_Hasta

        Dim exists = File.Exists(_Directorio & "\" & _Nombre_Archivo_XML)

        If exists Then

            _Ds_Filtro.ReadXml(_Directorio & "\" & _Nombre_Archivo_XML)

            If CBool(_Ds_Filtro.Tables("Tbl_Monto").Rows.Count) Then
                Txt_Monto_Maximo.Text = _Ds_Filtro.Tables("Tbl_Monto").Rows(0).Item("Monto_Max")
            Else
                Txt_Monto_Maximo.Text = 0
            End If

            If CBool(_Ds_Filtro.Tables("Tbl_Conf_Correo").Rows.Count) Then
                _Id_Correo = _Ds_Filtro.Tables("Tbl_Conf_Correo").Rows(0).Item("Id_Correo")
                Txt_Nombre_Correo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Correos", "Nombre_Correo", "Id = " & _Id_Correo)
            Else
                _Id_Correo = 0
                Txt_Nombre_Correo.Text = String.Empty
                Txt_Monto_Maximo.Text = 0
            End If
        Else
            _Ds_Filtro.WriteXml(_Directorio & "\" & _Nombre_Archivo_XML)
        End If


    End Sub

    Private Sub Frm_Inf_Vencimientos_Configuracion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click
        If Fx_Actualizar_Filtros(Me) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Inf_Vencimientos_Configuracion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Correo.Click
        Sb_Buscar_Correo()
    End Sub

    Sub Sb_Buscar_Correo()

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            _Id_Correo = Fm.Pro_Row_Fila_Seleccionada.Item("Id")
            Txt_Nombre_Correo.Text = Fm.Pro_Row_Fila_Seleccionada.Item("Nombre_Correo")
        End If
        Fm.Dispose()

    End Sub


#Region "ARCHIVO XML PARA FILTRO"

    Public Function Fx_Actualizar_Filtros(ByVal _Formulario As Form)

        Try


            If String.IsNullOrEmpty(Trim(Txt_Monto_Maximo.Text)) Then Txt_Monto_Maximo.Text = 0

            _Ds_Filtro.Clear()

            Dim NewFila As DataRow

            ' OPCIONES DE FILTRO DE DOCUMENTOS
            NewFila = _Ds_Filtro.Tables("Tbl_Monto").NewRow
            With NewFila
                .Item("Monto_Max") = Txt_Monto_Maximo.Text
            End With
            _Ds_Filtro.Tables("Tbl_Monto").Rows.Add(NewFila)


            ' OPCIONES DE FILTRO VENDEDOR
            NewFila = _Ds_Filtro.Tables("Tbl_Conf_Correo").NewRow
            With NewFila
                .Item("Id_Correo") = _Id_Correo
            End With
            _Ds_Filtro.Tables("Tbl_Conf_Correo").Rows.Add(NewFila)


            ' RANGO DE FECHAS DE EMISION
            NewFila = _Ds_Filtro.Tables("Tbl_Rango_Fecha_Emision").NewRow
            With NewFila
                .Item("Dtp_Fecha_Emision_Desde") = FormatDateTime(_Fecha_Emision_Desde, DateFormat.ShortDate) ' Dtp_Fecha_Emision_Desde.Value
                .Item("Dtp_Fecha_Emision_Hasta") = FormatDateTime(_Fecha_Emision_Hasta, DateFormat.ShortDate) 'Dtp_Fecha_Emision_Hasta.Value
            End With
            _Ds_Filtro.Tables("Tbl_Rango_Fecha_Emision").Rows.Add(NewFila)

            _Ds_Filtro.WriteXml(_Directorio & "\" & _Nombre_Archivo_XML)
            Return True
        Catch ex As Exception
            MessageBoxEx.Show(_Formulario, ex.Message)
        End Try

    End Function


#End Region

End Class