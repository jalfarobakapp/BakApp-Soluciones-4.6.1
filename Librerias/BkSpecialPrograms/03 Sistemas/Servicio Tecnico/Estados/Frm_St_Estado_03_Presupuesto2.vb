﻿Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Frm_St_Estado_03_Presupuesto2

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ot As Integer
    Dim _Grabar As Boolean
    Dim _DsDocumento As DataSet

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Row_Notas As DataRow
    Dim _Tbl_OperacionesXServ As DataTable

    Dim _Editando_documento As Boolean
    Dim _Horas_Mano_de_Obra_Asignado As Double
    Dim Imagenes_32x32 As ImageList

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public Property CodTecnico_Presupuesta As String
    Public Property ObligaIngProdPresupuesto As Boolean

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(value As DataSet)
            _DsDocumento = value
            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Tbl_ChekIn = _DsDocumento.Tables(2)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_OperacionesXServ = _DsDocumento.Tables(10)
        End Set
    End Property

    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Pro_Editando_Documento() As Boolean
        Get
            Return _Editando_documento
        End Get
        Set(value As Boolean)
            _Editando_documento = value
        End Set
    End Property

    Public Property Pro_Imagenes_32x32() As ImageList
        Get
            Return Imagenes_32x32
        End Get
        Set(value As ImageList)
            Imagenes_32x32 = value
        End Set
    End Property

#End Region

    Public Sub New(Id_Ot As Integer, Accion As Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Accion = Accion
        _Id_Ot = Id_Ot

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

        ObligaIngProdPresupuesto = _Global_Row_Configuracion_Estacion.Item("ServTecnico_ObligaIngProdPresupuesto")

    End Sub

    Private Sub Frm_St_Estado_03_Presupuesto2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _CodFuncionario = _Row_Encabezado.Item("CodTecnico_Asignado")

        If _Accion = Accion.Editar Then
            CodTecnico_Presupuesta = _Row_Encabezado.Item("CodTecnico_Presupuesta").ToString.Trim
        End If

        If String.IsNullOrEmpty(CodTecnico_Presupuesta) Then
            CodTecnico_Presupuesta = _CodFuncionario
        Else
            _CodFuncionario = CodTecnico_Presupuesta
        End If

        Txt_Tecnico_Taller.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller", "NomFuncionario",
                                           "CodFuncionario = '" & _CodFuncionario & "'").ToString.Trim
        Sb_Actualizar_Grilla()

        If _Tbl_DetProd.Rows.Count = 0 Then Sb_New_OT_Agregar_Fila()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If _Accion = Accion.Nuevo Then

            AddHandler Grilla.CellEnter, AddressOf Grilla_CellEnter
            AddHandler Grilla.CellBeginEdit, AddressOf Grilla_CellBeginEdit
            AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit
            AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
            AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing

            AddHandler Btn_Fijar_Estado.Click, AddressOf Btn_Fijar_Estado_Click

            Btn_Editar.Visible = False

        ElseIf _Accion = Accion.Editar Then

            AddHandler Btn_Grabar.Click, AddressOf Btn_Fijar_Estado_Click

            _Horas_Mano_de_Obra_Asignado = _Row_Encabezado.Item("Horas_Mano_de_Obra_Asignado")

            Btn_Fijar_Estado.Visible = False
            Btn_Editar.Visible = True

            If _Row_Encabezado.Item("CodEstado") = "CE" Then
                Btn_Editar.Visible = False
            End If


        End If

        Btn_Grabar.Visible = False

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Codigo = NuloPorNro(_Row.Cells("Codigo").Value, "")
            Dim _Nuevo_Item = NuloPorNro(_Row.Cells("Nuevo_Item").Value, False)

            If Not _Nuevo_Item And String.IsNullOrEmpty(_Codigo) Then
                Try
                    Grilla.Rows.RemoveAt(_Row.Index)
                    Grilla.Refresh()
                Catch ex As Exception

                End Try

            End If
        Next

        Dim _Registros = False
        For Each _Fila As DataRow In _Tbl_DetProd.Rows
            If _Fila.RowState <> DataRowState.Deleted Then
                _Registros = True
                Exit For
            End If
        Next

        If _Registros Then
            Grilla.AllowUserToAddRows = False
        Else
            Grilla.AllowUserToAddRows = True
        End If

        'Me.ActiveControl = Txt_Horas_Mano_de_Obra

    End Sub

#Region "PROCEDIMIENTOS"

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_DetProd

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = 0
            .Columns("Codigo").ReadOnly = True

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 320
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").DisplayIndex = 1

            .Columns("Ud").Visible = True
            .Columns("Ud").HeaderText = "UM"
            .Columns("Ud").Width = 30
            .Columns("Ud").ReadOnly = True
            .Columns("Ud").DisplayIndex = 2

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 80
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cantidad").ReadOnly = True
            .Columns("Cantidad").DisplayIndex = 3

        End With

    End Sub

    Sub Sb_New_OT_Agregar_Fila()

        Dim NewFila As DataRow
        NewFila = _Tbl_DetProd.NewRow
        With NewFila

            .Item("Id_Ot") = _Id_Ot
            .Item("Nuevo_Item") = True
            .Item("Utilizado") = False
            .Item("Codigo") = String.Empty
            .Item("Descripcion") = String.Empty
            .Item("Cantidad") = 0
            .Item("Ud") = String.Empty
            .Item("Un") = 0
            .Item("CantUd1") = 0
            .Item("CantUd2") = 0
            .Item("Precio") = 0
            .Item("Neto_Linea") = 0
            .Item("Iva_Linea") = 0
            .Item("Total_Linea") = 0

            _Tbl_DetProd.Rows.Add(NewFila)

        End With

    End Sub

    Sub Sb_New_OT_Agregar_Fila_Operacion(ByRef _Tbl As DataTable,
                                          _Semilla As Integer,
                                          _Codigo As String,
                                          _CodReceta As String,
                                          _Operacion As String,
                                          _Descripcion As String,
                                          _CantMayor1 As Boolean,
                                          _Cantidad As Integer,
                                          _CantidadRealizada As Integer,
                                          _Precio As Double,
                                          _Total As Double,
                                          _Realizado As Boolean)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id_Ot") = _Id_Ot
            .Item("Chk") = True
            .Item("Semilla") = _Semilla
            .Item("Codigo") = _Codigo
            .Item("CodReceta") = _CodReceta
            .Item("Operacion") = _Operacion
            .Item("Descripcion") = _Descripcion
            .Item("CantMayor1") = _CantMayor1
            .Item("Cantidad") = _Cantidad
            .Item("CantidadRealizada") = _CantidadRealizada
            .Item("Precio") = _Precio
            .Item("Total") = _Total
            .Item("Orden") = 0
            .Item("Realizado") = _Realizado

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

    Sub Sb_New_Ot_Grabar_Partes()

        If Fx_Fijar_Estado() Then
            _Row_Encabezado.Item("_Horas_Mano_de_Obra_Asignado") = 1 '_Horas_Mano_de_Obra_Asignado
            '_Row_Notas.Item("Defecto_encontrado") = Txt_Defecto_encontrado.Text
            '_Row_Notas.Item("Reparacion_a_realizar") = Txt_Reparacion_a_realizar.Text
            _Grabar = True
            Me.Close()
        End If

    End Sub

    Function Fx_Fijar_Estado() As Boolean

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        Dim _Tipo_compra As String

        Dim _Cn As New SqlConnection

        Try


            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            ' INSERTAR ENCABEZADO DE DOCUMENTO

            If _Accion = Accion.Nuevo Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                               "CodEstado = 'P',CodTecnico_Presupuesta = '" & CodTecnico_Presupuesta & "'" & vbCrLf &
                               "Where Id_Ot  = " & _Id_Ot

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Dim _HH As String = De_Num_a_Tx_01(_Horas_Mano_de_Obra_Asignado, False, 5)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                           "Horas_Mano_de_Obra_Asignado = " & _HH & vbCrLf &
                           ",Horas_Mano_de_Obra_Repara = " & _HH & vbCrLf &
                           "Where Id_Ot  = " & _Id_Ot

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()



            ' ----------------------------------------------------- DETALLE PRODUCTOS ------------------------------------------------

            If _Accion = Accion.Editar Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_DetProd Where Id_Ot = " & _Id_Ot
                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If


            If _Tbl_DetProd.Rows.Count > 0 Then

                'For i As Integer = 0 To TblDetalle.Rows.Count - 1
                For Each _Fila As DataRow In _Tbl_DetProd.Rows

                    Dim Estado As DataRowState = _Fila.RowState

                    If Estado <> DataRowState.Deleted Then

                        Dim _Utilizado As Integer = CBool(_Fila.Item("Utilizado")) * -1
                        Dim _Codigo As String = _Fila.Item("Codigo")
                        Dim _Descripcion As String = Trim(_Fila.Item("Descripcion"))
                        Dim _Cantidad As String = De_Txt_a_Num_01(_Fila.Item("Cantidad"), 5)
                        Dim _Ud As String = _Fila.Item("Ud")
                        Dim _Un As Integer = _Fila.Item("Un")
                        Dim _CantUd1 As String = De_Txt_a_Num_01(_Fila.Item("CantUd1"), 5)
                        Dim _CantUd2 As String = De_Txt_a_Num_01(_Fila.Item("CantUd2"), 5)
                        Dim _Precio As String = De_Txt_a_Num_01(_Fila.Item("Precio"), 5)
                        Dim _Neto_Linea As String = De_Txt_a_Num_01(_Fila.Item("Neto_Linea"), 5)
                        Dim _Iva_Linea As String = De_Txt_a_Num_01(_Fila.Item("Iva_Linea"), 5)
                        Dim _Total_Linea As String = De_Txt_a_Num_01(_Fila.Item("Total_Linea"), 5)

                        Dim _Nuevo_Item As Boolean = _Fila.Item("Nuevo_Item")

                        If Not _Nuevo_Item Then

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_DetProd (Id_Ot,Utilizado,Codigo,Descripcion,Cantidad,Ud,Un," &
                                           "CantUd1,CantUd2,Precio,Neto_Linea,Iva_Linea,Total_Linea) Values " &
                                           "(" & _Id_Ot & "," & _Utilizado & ",'" & _Codigo & "','" & _Descripcion & "'," & _Cantidad &
                                           ",'" & _Ud & "'," & _Un & "," & _CantUd1 & "," & _CantUd2 & "," & _Precio &
                                           "," & _Neto_Linea & "," & _Iva_Linea & "," & _Total_Linea & ")"

                            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End If

                Next

            End If


            ' --------------------------------------------------- NOTAS ---------------------------------------

            Dim _Reparacion_a_realizar As String '= Trim(Txt_Reparacion_a_realizar.Text)
            Dim _Defecto_encontrado As String '= Trim(Txt_Defecto_encontrado.Text)
            Dim _Chk_no_se_pudo_reparar As Integer = CInt(_Row_Notas.Item("Chk_no_se_pudo_reparar")) * -1
            Dim _Motivo_no_reparo As String = _Row_Notas.Item("Motivo_no_reparo")


            For _i = 0 To 31
                _Reparacion_a_realizar = Replace(_Reparacion_a_realizar, Chr(_i), " ")
                _Defecto_encontrado = Replace(_Defecto_encontrado, Chr(_i), " ")
            Next

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                           "Defecto_encontrado = '" & _Defecto_encontrado & "',Reparacion_a_realizar = '" & _Reparacion_a_realizar & "'" & vbCrLf &
                           "Where Id_Ot = " & _Id_Ot


            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()
            '**********************************'**********************************

            ' CAMBIO DE ESTADO

            If _Accion = Accion.Nuevo Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                               "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                               "(" & _Id_Ot & ",'P',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            '**********************************'**********************************



            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            Return True


        Catch ex As Exception
            '
            'Consulta_sql = "ROLLBACK TRANSACTION"
            'Ej_consulta_IDU(Consulta_sql, cn1)
            MsgBox(ex.Message)
            myTrans.Rollback()

            Return 0
        End Try


    End Function

#End Region

#Region "EVENTOS GRILLA"

    Private Sub Grilla_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        'Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        If _Fila.IsNewRow Then
            Dim _Descripcion As String = NuloPorNro(_Fila.Cells("Descripcion").Value, "")
            If _Cabeza = "Cantidad" Then
                If String.IsNullOrEmpty(_Descripcion) Then
                    SendKeys.Send("{LEFT}")
                    SendKeys.Send("{LEFT}")
                    SendKeys.Send("{LEFT}")

                End If
            End If
        Else
            Grilla.AllowUserToAddRows = False
        End If


    End Sub

    Private Sub Grilla_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Bar2.Enabled = False

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        If _Cabeza = "Codigo" Then
            If _Fila.IsNewRow Or _Nuevo_Item Then
                If Not String.IsNullOrEmpty(_Descripcion) Then
                    e.Cancel = True
                End If
            Else
                e.Cancel = True
            End If
            'If Not _Nuevo_Item Then
            'e.Cancel = True
            'End If
        ElseIf _Cabeza = "Cantidad" Then
            If _Fila.IsNewRow Then
                If String.IsNullOrEmpty(_Descripcion) Then
                    e.Cancel = True
                End If
            End If

        End If

        ' If Not _Fila.IsNewRow Then Grilla.AllowUserToAddRows = False

    End Sub

    Private Sub Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Semilla As Integer = _Fila.Cells("Semilla").Value

        Dim _RowProducto As DataRow

        If _Cabeza = "Codigo" Then

            If (_Fila.Cells("Codigo").Value Is DBNull.Value) Then
                _Fila.Cells("Codigo").Value = String.Empty
                Grilla.EndEdit()
            End If

            If _Codigo Is Nothing Then Return

            _RowProducto = Fx_Buscar_Producto(_Codigo)

            If Not (_RowProducto Is Nothing) Then

                If Not Fx_Buscar_Receta(_RowProducto.Item("KOPR"), _Semilla) Then
                    _Fila.Cells("Codigo").Value = String.Empty
                    Return
                End If

                _Fila.Cells("Id_Ot").Value = _Id_Ot
                _Fila.Cells("Codigo").Value = _RowProducto.Item("KOPR")
                _Fila.Cells("Descripcion").Value = _RowProducto.Item("NOKOPR")
                _Fila.Cells("Ud").Value = _RowProducto.Item("UD01PR")
                _Fila.Cells("Nuevo_Item").Value = False
                _Fila.Cells("Cantidad").Value = 1

                Sb_New_OT_Agregar_Fila()

            End If

        ElseIf _Cabeza = "Cantidad" Then

            If Grilla.Rows.Count - 1 = _Fila.Index Then
                SendKeys.Send("{LEFT}")
                SendKeys.Send("{LEFT}")
                SendKeys.Send("{LEFT}")
            End If

        End If

        Bar2.Enabled = True
        Me.Refresh()

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
            'Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter
                    If _Fila.IsNewRow Or _Nuevo_Item Then
                        If _Cabeza = "Codigo" Or _Cabeza = "Cantidad" Then
                            Grilla.Columns(_Cabeza).ReadOnly = False
                            SendKeys.Send("{F2}")
                            e.Handled = True
                            Grilla.BeginEdit(True)
                        End If
                    Else
                        If _Cabeza = "Cantidad" Then
                            Grilla.Columns(_Cabeza).ReadOnly = False
                            SendKeys.Send("{F2}")
                            e.Handled = True
                            Grilla.BeginEdit(True)
                        End If
                    End If
                Case Keys.Delete

                    If Not _Nuevo_Item Then '_Fila.IsNewRow Then

                        If (_Fila.Cells("Cantidad").Value Is DBNull.Value) Then
                            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                            Grilla.Refresh()
                        Else
                            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                                                     "Eliminar fila", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                                Grilla.Refresh()

                                If Grilla.Rows.Count = 0 Then
                                    Grilla.AllowUserToAddRows = True
                                End If

                            End If
                        End If

                    End If

                Case Else
                    Grilla.Columns(_Cabeza).ReadOnly = True
            End Select


        Catch ex As Exception

        Finally
            Bar2.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim validar As TextBox = CType(e.Control, TextBox)

        If _Cabeza = "Cantidad" Then
            AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        Else
            RemoveHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        End If

    End Sub


    Function Fx_Buscar_Producto(_Codigo As String) As DataRow

        Dim _TblProducto As DataTable

        Dim _CodigoAlt = _Codigo
        _CodigoAlt = _Sql.Fx_Trae_Dato("TABCODAL", "KOPR", "KOEN = '' And KOPRAL = '" & _CodigoAlt & "'")

        If Not String.IsNullOrEmpty(_CodigoAlt) Then
            _Codigo = _CodigoAlt
        End If

        Consulta_sql = "Select top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
        _TblProducto = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblProducto.Rows.Count) Then
            Return _TblProducto.Rows(0)
        Else

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_CodSucEntidad = String.Empty
            Fm.Pro_Tipo_Lista = "P"
            'Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_Sucursal_Busqueda = ModSucursal
            Fm.Pro_Bodega_Busqueda = ModBodega
            Fm.Txtdescripcion.Text = _Codigo
            Fm.Pro_Mostrar_Info = True
            Fm.Pro_Actualizar_Precios = True

            Codigo_abuscar = String.Empty
            Fm.Pro_Mostrar_Clasificaciones = True
            Fm.Pro_Mostrar_Imagenes = True

            Fm.Pro_Filtro_Sql_Extra = "And TIPR = 'SSN'"

            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then
                '_TblProducto = Fm.Pro_RowProducto
                Return Fm.Pro_RowProducto '_TblProducto.Rows(0)
            Else
                Return Nothing
            End If

        End If

    End Function

#End Region


#Region "EVENTOS BOTON GRABAR"

    Private Sub Btn_Fijar_Estado_Click(sender As System.Object, e As System.EventArgs)

        If Not CBool(Grilla.Rows.Count) Or Grilla.Rows.Count = 1 Then

            Dim _Fila As DataGridViewRow

            If CBool(Grilla.Rows.Count) Then
                _Fila = Grilla.Rows(0)

                If Not _Fila.IsNewRow Then
                    If Not _Fila.Cells("Nuevo_Item").Value And _Fila.Cells("Cantidad").Value <= 0 Then
                        MessageBoxEx.Show(Me, "No pueden haber productos con cantidad igual o menor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                End If

            End If

            If ObligaIngProdPresupuesto Then
                If Not CBool(Grilla.Rows.Count) Or _Fila.IsNewRow Then
                    MessageBoxEx.Show(Me, "Falta agregar un producto en el presupuesto" & vbCrLf &
                                         "Debe por lo menos ingresar algun servicio de reparación" & vbCrLf & vbCrLf &
                                         "Para agregar un producto debe hacer lo siguiente:" & vbCrLf &
                                         "Debe posicionarse sobre la celda del Coódigo y hacer doble [Enter] para buscar algún producto e ingresarlo al presupuesto",
                                         "Validación", MessageBoxButtons.OK,
                                         MessageBoxIcon.Stop)

                    Grilla.Focus()
                    Return

                End If
            Else
                If Not CBool(Grilla.Rows.Count) Or _Fila.IsNewRow Then
                    If MessageBoxEx.Show(Me, "¿Desea agregar productos a la reparación?",
                                         "No incluyo productos al presupuesto", MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Return
                    End If
                End If
            End If

        End If

        If Fx_Fijar_Estado() Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Grabar = True
            Me.Close()

        End If

    End Sub

#End Region

    Function Fx_Buscar_Receta(_Codigo As String, _Semilla As Integer) As Boolean

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Recetas_Enc",
                                    "CodReceta In (Select CodReceta From " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod Where Codigo = '" & _Codigo & "')"))

        If Not _Reg Then
            MessageBoxEx.Show(Me, "No existen receta asociada a este producto" & vbCrLf &
                              "Informe a la administración", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
        Fm.Pro_Tabla = _Global_BaseBk & "Zw_St_OT_Recetas_Enc"
        Fm.Pro_Campo = "CodReceta"
        Fm.Pro_Descripcion = "Descripcion"
        Fm.Text = "TIPO DE RECLAMO"
        Fm.Pro_Sql_Filtro_Condicion_Extra = "And CodReceta In (Select CodReceta From " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod Where Codigo = '" & _Codigo & "')" & vbCrLf
        Fm.Pro_Seleccionar_Solo_Uno = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            Dim _CodReceta As String = Fm.Pro_Tbl_Filtro.Rows(0).Item("Codigo")

            Consulta_sql = "Select Rece.*,Oper.Descripcion,Cast(0 As Bit) As Chk From " & _Global_BaseBk & "Zw_St_OT_Recetas_Ope Rece" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On Rece.Operacion = Oper.Operacion" & vbCrLf &
                           "Where CodReceta = '" & _CodReceta & "'"

            Dim _TblOperaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Grabar As Boolean

            Dim Fm2 As New Frm_OperacionesXServicio(_CodReceta)
            Fm2.TblOperaciones = _TblOperaciones
            Fm2.ShowDialog(Me)
            _Grabar = Fm2.Grabar
            _TblOperaciones = Fm2.TblOperaciones
            Fm2.Dispose()

            If Not _Grabar Then
                Return False
            End If

            For Each _Fl As DataRow In _TblOperaciones.Rows

                Dim _Total As Double = _Fl.Item("Cantidad") * _Fl.Item("Precio")

                If _Fl.Item("Chk") Then
                    Sb_New_OT_Agregar_Fila_Operacion(_Tbl_OperacionesXServ,
                                                     _Semilla,
                                                     _Codigo,
                                                     _Fl.Item("CodReceta"),
                                                     _Fl.Item("Operacion"),
                                                     _Fl.Item("Descripcion"),
                                                     _Fl.Item("CantMayor1"),
                                                     _Fl.Item("Cantidad"),
                                                     False,
                                                     _Fl.Item("Precio"),
                                                     _Total,
                                                     False)
                End If

            Next

        Else

            If MessageBoxEx.Show(Me, "Debe seleccionar una receta para generar el servicio", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) = DialogResult.OK Then
                Return Fx_Buscar_Receta(_Codigo, _Semilla)
            Else
                Return False
            End If

        End If

        Return True

    End Function

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Semilla As Integer = _Fila.Cells("Semilla").Value

        If Not _Nuevo_Item Then

            Dim _Operaciones As New List(Of DataRow)
            Dim _Tbl_OperacionesXServ2 As DataTable = _Tbl_OperacionesXServ.Clone

            '_Tbl_OperacionesXServ2.Clear()

            For Each _Fl As DataRow In _Tbl_OperacionesXServ.Rows

                If _Fl.Item("Semilla") = _Semilla Then

                    Dim _Total As Double = _Fl.Item("Cantidad") * _Fl.Item("Precio")

                    Sb_New_OT_Agregar_Fila_Operacion(_Tbl_OperacionesXServ2,
                                                     _Semilla,
                                                     _Codigo,
                                                     _Fl.Item("CodReceta"),
                                                     _Fl.Item("Operacion"),
                                                     _Fl.Item("Descripcion"),
                                                     _Fl.Item("CantMayor1"),
                                                     _Fl.Item("Cantidad"),
                                                     False,
                                                     _Fl.Item("Precio"),
                                                     _Total,
                                                     False)
                    _Operaciones.Add(_Fl)
                End If

            Next

            Dim _CodReceta As String = _Tbl_OperacionesXServ2.Rows(0).Item("CodReceta")

            Dim _Grabar As Boolean

            Dim Fm2 As New Frm_OperacionesXServicio(_CodReceta)
            Fm2.TblOperaciones = _Tbl_OperacionesXServ2
            Fm2.ShowDialog(Me)
            _Grabar = Fm2.Grabar
            _Tbl_OperacionesXServ2 = Fm2.TblOperaciones
            Fm2.Dispose()

            If _Grabar Then

                For i = 0 To _Operaciones.Count - 1
                    _Operaciones.Item(i).Delete()
                Next

                For Each _Fl As DataRow In _Tbl_OperacionesXServ2.Rows

                    If _Fl.Item("Chk") Then

                        Dim _Total As Double = _Fl.Item("Cantidad") * _Fl.Item("Precio")

                        Sb_New_OT_Agregar_Fila_Operacion(_Tbl_OperacionesXServ,
                                                         _Semilla,
                                                         _Codigo,
                                                         _Fl.Item("CodReceta"),
                                                         _Fl.Item("Operacion"),
                                                         _Fl.Item("Descripcion"),
                                                         _Fl.Item("CantMayor1"),
                                                         _Fl.Item("Cantidad"),
                                                         False,
                                                         _Fl.Item("Precio"),
                                                         _Total,
                                                         False)
                    End If

                Next

            End If

        End If

    End Sub

End Class
