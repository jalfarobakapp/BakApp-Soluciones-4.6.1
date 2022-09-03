'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO


Public Class Frm_Informe_Gerencia_On_Line_Filtros

    Dim _TblFiltro_Entidades, _
        _TblFiltro_Sucursal, _
        _TblFiltro_Super_Familia, _
        _TblFiltro_Anotaciones As DataTable


    Dim _Ds As New Ds_Inf_Ventas_OnLine
    Dim _NombreConexion As String
    Dim _Directorio_Informe

    Public ReadOnly Property Pro_Ds() As DataSet
        Get
            _Ds.Clear()
            _Ds.ReadXml(_Directorio_Informe & "\Conf_Filtros.xml")
            Return _Ds
        End Get
    End Property

    Public Sub New(ByVal NombreConexion As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _NombreConexion = NombreConexion

        _Directorio_Informe = Application.StartupPath & _
       "\Data\Configuracion_Local\Informes\Informe ventas\Ventas On Line\" & _NombreConexion
        
    End Sub

    Private Sub Frm_Informe_Gerencia_On_Line_Filtros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Directory.Exists(_Directorio_Informe) Then
            System.IO.Directory.CreateDirectory(_Directorio_Informe)

            Sb_Parametros_Actualizar()

        End If

        Sb_Parametros_Revisar()


        AddHandler Rdb_Sucursales_Algunas.CheckedChanged, AddressOf Rdb_Sucursales_Algunas_CheckedChanged
        AddHandler Rdb_Super_Familia_Algunos.CheckedChanged, AddressOf Rdb_Super_Familia_Algunos_CheckedChanged

    End Sub

    Sub Sb_Parametros_Actualizar()

        Dim _Ds_New As New Ds_Inf_Ventas_OnLine
        _Ds_New.Clear()

        '_Ds_New.ReadXml(_Directorio_Informe & "\Conf_Filtros.xml")
        If Rdb_Sucursales_Algunas.Checked Then
            Sb_Llenar_Tabla_Filtro(_Ds_New.Tables("TblFiltro_Sucursal"), _TblFiltro_Sucursal)
        End If

        If Rdb_Super_Familia_Algunos.Checked Then
            Sb_Llenar_Tabla_Filtro(_Ds_New.Tables("TblFiltro_Super_Familia"), _TblFiltro_Super_Familia)
        End If

        Dim NewFila As DataRow
        NewFila = _Ds_New.Tables("Tbl_Configuracion_Filtros").NewRow
        With NewFila

            .Item("Rdb_Sucursales_Todas") = Rdb_Sucursales_Todas.Checked '
            .Item("Rdb_Sucursales_Algunas") = Rdb_Sucursales_Algunas.Checked
            .Item("Rdb_Super_Familia_Todos") = Rdb_Super_Familia_Todos.Checked
            .Item("Rdb_Super_Familia_Algunos") = Rdb_Super_Familia_Algunos.Checked
            .Item("Chk_Solo_Stock_Fisico") = Chk_Solo_Stock_Fisico.Checked

        End With
        '
        _Ds_New.Tables("Tbl_Configuracion_Filtros").Rows.Add(NewFila)
        _Ds_New.WriteXml(_Directorio_Informe & "\Conf_Filtros.xml")

    End Sub

    Sub Sb_Parametros_Revisar()

        _Ds.Clear()
        _Ds.ReadXml(_Directorio_Informe & "\Conf_Filtros.xml")

        Dim _Tbl_Configuracion_Filtros As DataTable

        _Tbl_Configuracion_Filtros = _Ds.Tables("Tbl_Configuracion_Filtros")
        Dim Fila As DataRow
        Fila = _Tbl_Configuracion_Filtros.Rows(0)
        With Fila

            Rdb_Sucursales_Todas.Checked = .Item("Rdb_Sucursales_Todas")
            Rdb_Sucursales_Algunas.Checked = .Item("Rdb_Sucursales_Algunas")
            Rdb_Super_Familia_Todos.Checked = .Item("Rdb_Super_Familia_Todos")
            Rdb_Super_Familia_Algunos.Checked = .Item("Rdb_Super_Familia_Algunos")
            Chk_Solo_Stock_Fisico.Checked = .Item("Chk_Solo_Stock_Fisico")

        End With

        _TblFiltro_Sucursal = _Ds.Tables("TblFiltro_Sucursal")
        _TblFiltro_Super_Familia = _Ds.Tables("TblFiltro_Super_Familia")


    End Sub


    Private Sub Rdb_Sucursales_Algunas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Rdb_Sucursales_Algunas.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Sucursales)
            Fm.Pro_Tbl_Filtro = _TblFiltro_Sucursal
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then

                _TblFiltro_Sucursal = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Sucursal Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Sucursales_Todas.Checked = True
                End If
            Else
                Rdb_Sucursales_Todas.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Super_Familia_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Rdb_Super_Familia_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Tabla_Super_Familia)
            Fm.Pro_Tbl_Filtro = _TblFiltro_Super_Familia
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then

                _TblFiltro_Super_Familia = Fm.Pro_Tbl_Filtro
                If (_TblFiltro_Sucursal Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Super_Familia_Todos.Checked = True
                End If
            Else
                Rdb_Super_Familia_Todos.Checked = True
            End If

        End If
    End Sub

    Private Sub Btn_Agregar_Conexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Conexion.Click
        Sb_Parametros_Actualizar()
        Me.Close()
    End Sub

    Sub Sb_Llenar_Tabla_Filtro(ByVal _Tbl_Destino As DataTable, ByVal _Tbl_Origen As DataTable)

        'Dim _Tbl As DataTable = _Ds_Informe_Masisa.Tables("Tbl_Filtro_Clalibpr")

        Dim NewFila As DataRow

        For Each _Fila As DataRow In _Tbl_Origen.Rows

            NewFila = _Tbl_Destino.NewRow
            With NewFila
                .Item("Codigo") = Trim(_Fila.Item("Codigo"))
                .Item("Descripcion") = Trim(_Fila.Item("Descripcion"))
                _Tbl_Destino.Rows.Add(NewFila)
            End With

        Next

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_Informe_Gerencia_On_Line_Filtros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class