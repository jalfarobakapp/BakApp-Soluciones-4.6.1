'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Seleccion_Empresas

    Dim _Directorio_Informe As String

    Dim _Ds_Inf_Ventas_OnLine As New Ds_Inf_Ventas_OnLine
    ' Dim _DatosConex As New ConexionBK
    Dim _Tbl_Conexiones As DataTable
    Dim _Row_Conexion As DataRow

    Dim _Accion As Enum_Accion

    Enum Enum_Accion
        Seleccionar
        Crear
    End Enum

    Public ReadOnly Property Pro_Row_Conexion() As DataRow
        Get
            Return _Row_Conexion
        End Get
    End Property

    Public ReadOnly Property Pro_Tbl_Conexiones() As DataTable
        Get
            Return _Tbl_Conexiones
        End Get
    End Property

    Public Sub New(ByVal Accion As Enum_Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not Directory.Exists(Application.StartupPath & "\Data\Configuracion_Local\Informes") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\Configuracion_Local\Informes")
        End If

        If Not Directory.Exists(Application.StartupPath & "\Data\Configuracion_Local\Informes\Informe ventas") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\Configuracion_Local\Informes\Informe ventas")
        End If

        If Not Directory.Exists(Application.StartupPath & "\Data\Configuracion_Local\Informes\Informe ventas\Ventas On Line") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\Configuracion_Local\Informes\Informe ventas\Ventas On Line")
        End If

        _Directorio_Informe = Application.StartupPath & "\Data\Configuracion_Local\Informes\Informe ventas\Ventas On Line"
        Dim _Directorio As String = Application.StartupPath & "\Data\"

        Dim _Exists = System.IO.File.Exists(_Directorio_Informe & "\Conexion_Inf_Ventas_On_Line.xml")

        If Not _Exists Then
            _Ds_Inf_Ventas_OnLine.WriteXml(_Directorio_Informe & "\Conexion_Inf_Ventas_On_Line.xml")
        End If

        _Ds_Inf_Ventas_OnLine.ReadXml(_Directorio_Informe & "\Conexion_Inf_Ventas_On_Line.xml")

        _Tbl_Conexiones = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Sel_Conexion")

       Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Accion = Accion

    End Sub

    Private Sub Frm_Seleccion_Empresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        'DatosConex.WriteXml(AppPath() & "\Data\filename.xml") 'Documento_vta

        'Dim _Tbl = New DataTable
        '_Tbl = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Sel_Conexion")

        With Grilla

            .DataSource = Nothing
            .DataSource = _Tbl_Conexiones

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Rut").Width = 100
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Visible = True

            .Columns("NombreConexion").Width = 230
            .Columns("NombreConexion").HeaderText = "Nombre de conexión"
            .Columns("NombreConexion").Visible = True

            .Columns("BaseDeDatos").Width = 130
            .Columns("BaseDeDatos").HeaderText = "Base de Datos"
            .Columns("BaseDeDatos").Visible = True

        End With

        'Sb_Marcar_Grilla()

    End Sub

    Function Fx_Row_Agregar_Empresa() As DataRow

        Dim DatosConex As New ConexionBK

        Dim Directorio As String = Application.StartupPath & "\Data\"
        Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

        If Not _Exists Then
            DatosConex.WriteXml(Directorio & "Conexiones.xml")
            MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End If

        DatosConex.ReadXml(Directorio & "Conexiones.xml")

        Dim Fm As New Frm_ConexionBD
        Fm.BtnAgregar.Visible = False
        Fm.BtnGenerateKey.Visible = False
        Fm.ShowDialog(Me)
        Fx_Row_Agregar_Empresa = Fm.Pro_RowConexion()
        '_Cadena_ConexionSQL_Seleccionada = CadenaConexionSQL(Fm.NombreConexionActiva, DatosConex)
        Fm.Dispose()

    End Function

    Private Sub Btn_Agregar_Conexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Conexion.Click

        Dim _Row_Conexion As DataRow = Fx_Row_Agregar_Empresa()

        Try
            If Not (_Row_Conexion Is Nothing) Then

                Dim _NombreConexion As String = _Row_Conexion.Item("NombreConexion")
                Dim _Rut As String = _Row_Conexion.Item("Rut")
                Dim _BaseDeDatos As String = _Row_Conexion.Item("BaseDeDatos")

                Dim NewFila As DataRow
                NewFila = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Sel_Conexion").NewRow
                With NewFila
                    .Item("NombreConexion") = _NombreConexion
                    .Item("Rut") = _Rut
                    .Item("BaseDeDatos") = _BaseDeDatos
                    _Ds_Inf_Ventas_OnLine.Tables("Tbl_Sel_Conexion").Rows.Add(NewFila)
                End With

            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        _Ds_Inf_Ventas_OnLine.WriteXml(_Directorio_Informe & "\Conexion_Inf_Ventas_On_Line.xml")

        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_Seleccion_Empresas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If _Accion = Enum_Accion.Seleccionar Then

            Dim _Row As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _NombreConexion = _Row.Cells("NombreConexion").Value

            For Each _Fila As DataRow In _Tbl_Conexiones.Rows

                If _Fila.Item("NombreConexion") = _NombreConexion Then
                    _Row_Conexion = _Fila
                    Exit For
                End If

            Next

            Me.Close()

        End If

    End Sub


End Class