Imports DevComponents.DotNetBar

Public Class Frm_MantCostosPrecios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tbl_Paso_Costos As String ' = _Global_BaseBk & "Zw_PsLc" & FUNCIONARIO
    Dim _NombreEquipo As String

    Dim _Tbl_Lista_Proveedor As DataTable
    Dim _TipoValor As String
    Dim _RowProveedor As DataRow
    Dim _Grabacion_Realizada As Boolean
    Dim _Cerrar_al_Grabar As Boolean
    Dim _Producto_Unico As Boolean
    Dim _Codigo_Producto_Unico As String
    Dim _Arr_Copiar(0, 2) As String
    Dim _Filtro_Productos As String
    Dim _DsFiltros As New DsFiltros
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Cancelar As Boolean
    Dim _PrestaShop As Boolean
    Dim _Index_Fila_En_Edicion As Integer
    Dim _Tbl_Listas_Seleccionadas As DataTable
    Dim _CodProveedor As String
    Dim _SucProveedor As String
    Dim _FechaVigencia As String
    Dim _Id_Padre As Integer
    Dim _EsNuevaLista As Boolean

    Dim _Dv As New DataView
    Dim _Ds As DataSet

    Public Property EsListaOferta As Boolean

    Public ReadOnly Property Pro_Grabacion_Realizada()
        Get
            Return _Grabacion_Realizada
        End Get
    End Property

    Public Property Id_Padre As Integer
        Get
            Return _Id_Padre
        End Get
        Set(value As Integer)
            _Id_Padre = value
        End Set
    End Property

    Public Property EsNuevaLista As Boolean
        Get
            Return _EsNuevaLista
        End Get
        Set(value As Boolean)
            _EsNuevaLista = value
        End Set
    End Property

    '' Nuevas Variables

    Dim _CodLista As String

    Public Sub New(RowProveedor As DataRow, CodLista As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Grilla.RowHeadersVisible = True

        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
        _Nombre_Tbl_Paso_Costos = "Zw_PsLc" & FUNCIONARIO.Trim  '_Rd.Next(100, 999)

        _RowProveedor = RowProveedor
        _CodLista = CodLista

        _CodProveedor = _RowProveedor.Item("KOEN")
        _SucProveedor = _RowProveedor.Item("SUEN")

        Sb_Color_Botones_Barra(Barrar_Menu)

    End Sub

    Private Sub Frm_MantCostosPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _FechaVigencia = Format(Dtp_FechaVigenciaDesde.Value, "yyyyMMdd")

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown

        Sb_Actualizar_Grilla(True, True)

        AddHandler Chk_Quitar_Sin_Usar.CheckedChanged, AddressOf Chk_CheckedChanged
        AddHandler Chk_Quitar_Bloqueados_venta.CheckedChanged, AddressOf Chk_CheckedChanged
        AddHandler Chk_NoUsar_Bloqueados.CheckedChanged, AddressOf Chk_CheckedChanged

        Me.ActiveControl = Txt_Buscar

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Sb_Ver_Menu_Linea_Activa()
                End If

            End With

        End If

    End Sub

    Sub Sb_Ver_Menu_Linea_Activa()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Select" Or
                           _Cabeza = "Lista" Or
                           _Cabeza = "Codigo" Or
                           _Cabeza = "Descripcion" Or
                           _Cabeza = "CodAlternativo" Then

            ShowContextMenu(Menu_Contextual_Productos)
        ElseIf _Cabeza = "Costo" Or _Cabeza = "Costo2" Then
            ShowContextMenu(Menu_Contextual_Costo)
        ElseIf _Cabeza = "Precio" Or _Cabeza = "Precio2" Then
            ShowContextMenu(Menu_Contextual_Formula)
        Else
            ShowContextMenu(Menu_Contextual_Copiar)
        End If

    End Sub

    Sub Sb_Actualizar_Grilla(_Actualizar_Desde_Cero As Boolean)

        _Nombre_Tbl_Paso_Costos = "Zw_PsLc" & FUNCIONARIO.Trim

        If _Actualizar_Desde_Cero Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Codigo Not In (Select KOPR From MAEPR)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Proveedor = '" & _CodProveedor & "' And Lista = '" & _CodLista & "' And CodAlternativo = ''
                            Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Proveedor = '" & _CodProveedor & "' And CodAlternativo = ''

                            Delete " & _Global_BaseBk & "Zw_ListaPreCosto
                            Where CodAlternativo Not In (Select KOPRAL From TABCODAL Where KOEN = '" & _CodProveedor & "')
                            And Proveedor = '" & _CodProveedor & "' And Sucursal= '" & _SucProveedor & "' And Lista = '" & _CodLista & "'
                                                       
                            Insert Into " & _Global_BaseBk & "Zw_ListaPreCosto (Lista,Proveedor,Sucursal,CodAlternativo,Codigo,Descripcion,Descripcion_Alt,CostoUd1, 
                            CostoUd2,Rtu,FechaVigencia,Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete,Un_Compra,Un_MinCompra,Ac_Oferta,Ac_Disponible,Ac_Cotizar)
                            Select Distinct '" & _CodLista & "','" & _CodProveedor & "','" & _SucProveedor & "',Tc.KOPRAL,Mp.KOPR,Mp.NOKOPR,Tc.NOKOPRAL,0,0,RLUD,Getdate(),0,0,0,0,0,0,0,1,0,0,0,0
                                From TABCODAL Tc 
                                    Inner Join MAEPR Mp On Tc.KOPR = Mp.KOPR
                                        Where Tc.KOEN = '" & _CodProveedor & "' And Tc.KOPR Not In
                                            (Select Codigo From " & _Global_BaseBk & "Zw_ListaPreCosto " &
                                                "Where Proveedor = '" & _CodProveedor & "' And Sucursal = '" & _SucProveedor & "' And Lista = '" & _CodLista & "')

                            Update " & _Global_BaseBk & "Zw_ListaPreCosto Set Flete = RECARGO
                            From " & _Global_BaseBk & "Zw_ListaPreCosto 
                            Inner Join TABRECPR On KOEN = Proveedor And KOPR = Codigo
                            Where Proveedor = '" & _CodProveedor & "'"

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            Consulta_sql = "Drop table " & _Global_BaseBk & _Nombre_Tbl_Paso_Costos
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Dim _Tabla As String = "LcCosto"
            Dim _RazonProveedor As String = _RowProveedor.Item("NOKOEN")

            Dim _Suc As String

            If Not String.IsNullOrEmpty(_SucProveedor.Trim) Then
                _Suc = ", Sucursal (" & _SucProveedor.Trim & ")"
            End If

            Me.Text = "Tratamiento de costos (" & _CodLista & ") del proveedor: " & _CodProveedor.Trim & " - " & _RazonProveedor.Trim & _Suc

            Dim _Base = Replace(_Global_BaseBk, ".dbo.", "")

            Consulta_sql = My.Resources.Consultas_SQL_Lp.SQLQuery_Cargar_LC
            Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
            Consulta_sql = Replace(Consulta_sql, "#Base#", _Base)
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set Rtu = (Select RLUD From MAEPR Where KOPR = Codigo)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set CodAlternativo = KOPRAL 
                            From " & _Global_BaseBk & "Zw_ListaPreCosto Lpc
                            Inner Join TABCODAL On KOEN = Proveedor And KOPR = Codigo
                            Where Proveedor = '" & _CodProveedor & "' And Lista = '" & _CodLista & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Insert Into " & _Nombre_Tbl_Paso_Costos & " (Lista,Proveedor,Sucursal,CodAlternativo,Codigo,Descripcion,Descripcion_Alt,CostoUd1,CostoUd2,Rtu,FechaVigencia,
                            Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete,Un_Compra,Un_MinCompra,Ac_Oferta,Ac_Disponible,Ac_Cotizar,Ud1,Ud2,Pm,Uc1,Uc2,No_Usar)
                            Select Distinct Lista,Proveedor,Sucursal,CodAlternativo,Codigo,Mp.NOKOPR As Descripcion,Tda.NOKOPRAL As Descripcion_Alt,CostoUd1,CostoUd2,Rtu,FechaVigencia,
                            Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete,Un_Compra,Un_MinCompra,Ac_Oferta,Ac_Disponible,Ac_Cotizar,UD01PR As Ud1,UD02PR As Ud2,Map.PM As Pm,Map.PPUL01 As Uc1,Map.PPUL02 As Uc2,No_Usar --,NMARCA             
                            From " & _Global_BaseBk & "Zw_ListaPreCosto 
	                            Inner Join MAEPR Mp On Mp.KOPR = Codigo
		                            Inner Join MAEPREM Map On EMPRESA = '" & ModEmpresa & "' And Map.KOPR = Codigo
                                        Inner Join TABCODAL Tda On KOEN = '" & _CodProveedor & "' And Tda.KOPR = Codigo And Tda.KOPRAL = CodAlternativo 
                            Where Proveedor = '" & _CodProveedor & "' And Sucursal = '" & _SucProveedor & "' And Lista = '" & _CodLista & "'"

            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set Repetidos = (Select Count(*) From " & _Nombre_Tbl_Paso_Costos & " Z2 Where Z1.Codigo = Z2.Codigo And Z1. And Z2.No_Usar = 0)
                            From " & _Nombre_Tbl_Paso_Costos & " Z1
                            Update " & _Nombre_Tbl_Paso_Costos & " Set RepetidosAlt = (Select Count(*) From " & _Nombre_Tbl_Paso_Costos & " Z2 Where Z1.CodAlternativo = Z2.CodAlternativo And Z2.No_Usar = 0)
                            From " & _Nombre_Tbl_Paso_Costos & " Z1
                            Update " & _Nombre_Tbl_Paso_Costos & " Set Descripcion = Rtrim(Ltrim(Descripcion))+' [Repetido '+Rtrim(Ltrim(Str(Repetidos)))+']'
                            Where Repetidos > 1"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            Consulta_sql = "Select * From " & _Nombre_Tbl_Paso_Costos & " Where RepetidosAlt > 1"
            Dim _Tbl_Repetidos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            For Each _Flr As DataRow In _Tbl_Repetidos.Rows

            Next

            Chk_OrdenDeLlegada.Visible = False

            Me.Refresh()

        End If

        Dim _Filtro_Sin_Usar As String

        If Chk_Quitar_Sin_Usar.Checked Then

            _Filtro_Sin_Usar = "And No_Usar = 0"

        End If

        Consulta_sql = "Select PrPro.*,MAEPR.BLOQUEAPR,Cast(0 As Float) As Neto_Cn_Dscto,Cast(0 As Float) As Impuestos 
                        From " & _Nombre_Tbl_Paso_Costos & " As PrPro
                        Inner Join MAEPR On KOPR = Codigo
                        Where 1 > 0 And BLOQUEAPR = '' " & _Filtro_Sin_Usar & "
                        Order by Codigo"

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Dv.Table = _Ds.Tables("Table")

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, False)

            Dim _Displayindex = 0
            Dim _Campo As String

            _Campo = "Select"
            .Columns(_Campo).Width = 25
            .Columns(_Campo).HeaderText = "S."
            ' .Columns(_Campo).Frozen = True
            '.Columns(_Campo).ReadOnly = False
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            '_Campo = "Lista"
            '.Columns(_Campo).Width = 35
            '.Columns(_Campo).HeaderText = "LP"
            '.Columns(_Campo).ReadOnly = True
            ''.Columns(_Campo).Frozen = True
            '.Columns(_Campo).Visible = True
            '.Columns(_Campo).DisplayIndex = _Displayindex
            '_Displayindex += 1

            _Campo = "Codigo"
            .Columns(_Campo).Width = 90
            .Columns(_Campo).HeaderText = "Código (Random)"
            .Columns(_Campo).ReadOnly = True
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "No_Usar"
            .Columns(_Campo).Width = 35
            .Columns(_Campo).HeaderText = "No usar"
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).ReadOnly = False
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Codalternativo"
            .Columns(_Campo).Width = 110
            .Columns(_Campo).HeaderText = "SKU. Proveedor"
            .Columns(_Campo).ReadOnly = True
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Descripcion"
            .Columns(_Campo).Width = 300
            .Columns(_Campo).HeaderText = "Descripción"
            .Columns(_Campo).ReadOnly = True
            '.Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "CostoUd1"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Costo Ud1"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "CostoUd2"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Costo Ud2"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "$ ###,##.##"
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc1"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 1°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc2"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 2°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc3"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 3°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc4"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 4°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc5"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 5°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Flete"
            .Columns(_Campo).Width = 70
            .Columns(_Campo).HeaderText = "Flete"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "$ ###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

        End With

        Lbl_Rtu.DataBindings.Clear()
        Lbl_Descripcion.DataBindings.Clear()
        Lbl_Ud1.DataBindings.Clear()
        Lbl_Ud2.DataBindings.Clear()
        Lbl_Uc1.DataBindings.Clear()
        Lbl_Uc2.DataBindings.Clear()
        Lbl_Pm.DataBindings.Clear()
        Lbl_Neto_Cn_Dscto.DataBindings.Clear()
        Lbl_Impuestos.DataBindings.Clear()

        Lbl_Rtu.DataBindings.Add("text", _Dv, "Rtu", True, Nothing, Nothing, "N2")

        Lbl_Descripcion.DataBindings.Add("text", _Dv, "Descripcion")
        Lbl_Ud1.DataBindings.Add("text", _Dv, "Ud1")
        Lbl_Ud2.DataBindings.Add("text", _Dv, "Ud2")

        Lbl_Uc1.DataBindings.Add("text", _Dv, "Uc1", True, Nothing, Nothing, "C2")
        Lbl_Uc2.DataBindings.Add("text", _Dv, "Uc2", True, Nothing, Nothing, "C2")
        Lbl_Pm.DataBindings.Add("text", _Dv, "Pm", True, Nothing, Nothing, "C2")
        Lbl_Neto_Cn_Dscto.DataBindings.Add("text", _Dv, "Neto_Cn_Dscto", True, Nothing, Nothing, "C2")

        Lbl_Impuestos.DataBindings.Add("text", _Dv, "Impuestos", True, Nothing, Nothing, "C2")

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Repetidos = _Fila.Cells("Repetidos").Value
            Dim _No_Usar = _Fila.Cells("No_Usar").Value

            If _Repetidos > 1 Then
                _Fila.DefaultCellStyle.ForeColor = Color.Purple
            End If

            If _No_Usar Then
                _Fila.DefaultCellStyle.ForeColor = Color.Red
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

            Dim _Desc1 = _Fila.Cells("Desc1").Value
            Dim _Desc2 = _Fila.Cells("Desc2").Value
            Dim _Desc3 = _Fila.Cells("Desc3").Value
            Dim _Desc4 = _Fila.Cells("Desc4").Value
            Dim _Desc5 = _Fila.Cells("Desc5").Value

            Dim _DescSuma As Double = 100 * (1 - (
                                         (1 - (_Desc1 / 100.0)) *
                                         (1 - (_Desc2 / 100.0)) *
                                         (1 - (_Desc3 / 100.0)) *
                                         (1 - (_Desc4 / 100.0)) *
                                         (1 - (_Desc5 / 100.0))))

            _DescSuma = Math.Round(_DescSuma, 2)

            Dim _Neto = _Fila.Cells("CostoUd1").Value

            If CBool(_DescSuma) Then
                _DescSuma = (_DescSuma / 100)
                _Neto = _Neto - (_Neto * _DescSuma)
            End If

            _Fila.Cells("Neto_Cn_Dscto").Value = _Neto

            Dim _Codigo = _Fila.Cells("Codigo").Value

            Consulta_sql = "Select Case Isnull(Sum(POIM), 0) As Impuesto From TABIM Where KOIM In (Select KOIM From TABIMPR Where KOPR = '" & _Codigo & "')"
            Dim _RowImp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_RowImp) Then
                _Fila.Cells("Neto_Cn_Dscto").Value = 0
            Else
                _Fila.Cells("Neto_Cn_Dscto").Value = _RowImp.Item("Impuesto")
            End If

        Next

    End Sub

    Sub Sb_Actualizar_Grilla(_Actualizar_Desde_Cero As Boolean, _NuevoMetodo As Boolean) ' Nuevo metodo

        _FechaVigencia = Format(Dtp_FechaVigenciaDesde.Value, "yyyyMMdd")

        Me.Cursor = Cursors.WaitCursor

        _Nombre_Tbl_Paso_Costos = _Global_BaseBk & "Zw_PsLc" & FUNCIONARIO.Trim

        If _Actualizar_Desde_Cero Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Codigo Not In (Select KOPR From MAEPR)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Proveedor = '" & _CodProveedor & "' And Lista = '" & _CodLista & "' And CodAlternativo = '' And Id_Padre = " & _Id_Padre & "
                            Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Proveedor = '" & _CodProveedor & "' And CodAlternativo = '' And Id_Padre = " & _Id_Padre & "
                            Delete " & _Global_BaseBk & "Zw_ListaPreCosto Where Proveedor = '" & _CodProveedor & "' And Descripcion = '' And Descripcion_Alt = '' And Id_Padre = " & _Id_Padre & "

                            Delete " & _Global_BaseBk & "Zw_ListaPreCosto
                            Where CodAlternativo In (Select Tcd.KOPRAL From TABCODAL Tcd
                            Left Join " & _Global_BaseBk & "Zw_ListaPreCosto Lc  On KOEN = Proveedor And KOPRAL = CodAlternativo And KOPR = Codigo And Id_Padre = " & _Id_Padre & "
                            Where KOEN = '" & _CodProveedor & "' And Codigo Is Null) And Id_Padre = " & _Id_Padre & "


                            Delete " & _Global_BaseBk & "Zw_ListaPreCosto
                            Where CodAlternativo Not In (Select KOPRAL From TABCODAL Where KOEN = '" & _CodProveedor & "')
                            And Proveedor = '" & _CodProveedor & "' And Sucursal= '" & _SucProveedor & "' And Lista = '" & _CodLista & "' And Id_Padre = " & _Id_Padre & "
                                                       
                            Insert Into " & _Global_BaseBk & "Zw_ListaPreCosto (Id_Padre,Lista,Proveedor,Sucursal,CodAlternativo,Codigo,Descripcion,Descripcion_Alt,CostoUd1, 
                            CostoUd2,Rtu,FechaVigencia,Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete,Un_Compra,Un_MinCompra,Ac_Oferta,Ac_Disponible,Ac_Cotizar)
                            Select Distinct " & _Id_Padre & ",'" & _CodLista & "','" & _CodProveedor & "','" & _SucProveedor & "',Tc.KOPRAL,Mp.KOPR,Mp.NOKOPR,Tc.NOKOPRAL,0,0,RLUD,'" & _FechaVigencia & "',0,0,0,0,0,0,0,1,0,0,0,0
                                From TABCODAL Tc 
                                    Inner Join MAEPR Mp On Tc.KOPR = Mp.KOPR
                                        Where Tc.KOEN = '" & _CodProveedor & "' And Tc.KOPRAL Not In
                                            (Select CodAlternativo From " & _Global_BaseBk & "Zw_ListaPreCosto " &
                                                "Where Id_Padre = " & _Id_Padre & ")--Where Proveedor = '" & _CodProveedor & "' And Sucursal = '" & _SucProveedor & "' And Lista = '" & _CodLista & "' And FechaVigencia = '" & _FechaVigencia & "')

                            Update " & _Global_BaseBk & "Zw_ListaPreCosto Set Flete = RECARGO
                            From " & _Global_BaseBk & "Zw_ListaPreCosto 
                            Inner Join TABRECPR On KOEN = Proveedor And KOPR = Codigo
                            Where Proveedor = '" & _CodProveedor & "'"

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            Consulta_sql = "Drop table " & _Nombre_Tbl_Paso_Costos
            _Sql.Ej_consulta_IDU(Consulta_sql, False)


            Dim _Tabla As String = "LcCosto"
            Dim _RazonProveedor As String = _RowProveedor.Item("NOKOEN")

            Dim _Suc As String

            If Not String.IsNullOrEmpty(_SucProveedor.Trim) Then
                _Suc = ", Sucursal (" & _SucProveedor.Trim & ")"
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Where Id = " & _Id_Padre
            Dim _RowEnc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _NombreLista As String

            If Not IsNothing(_RowEnc) Then
                _NombreLista = _RowEnc.Item("NombreLista").ToString.Trim
            End If

            Me.Text = "Tratamiento de costos (" & _CodLista & ") del proveedor: " & _CodProveedor.Trim & " - " & _RazonProveedor.Trim & _Suc & " (Lista: " & _NombreLista & ")"

            Dim _Base = Replace(_Global_BaseBk, ".dbo.", "")

            Consulta_sql = My.Resources.Consultas_SQL_Lp.SQLQuery_Cargar_LC
            Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO.Trim)
            Consulta_sql = Replace(Consulta_sql, "#Base#", _Base)
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set Rtu = (Select RLUD From MAEPR Where KOPR = Codigo)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Insert Into " & _Nombre_Tbl_Paso_Costos & " (Lista,Proveedor,Sucursal,CodAlternativo,Codigo,Descripcion,Descripcion_Alt,CostoUd1,CostoUd2,Rtu,FechaVigencia,
                            Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete,Un_Compra,Un_MinCompra,Ac_Oferta,Ac_Disponible,Ac_Cotizar,Ud1,Ud2,Pm,Uc1,Uc2,No_Usar,Id_Hijo,Id_Padre)
                            Select Distinct Lista,Proveedor,Sucursal,CodAlternativo,Codigo,Mp.NOKOPR As Descripcion,Tda.NOKOPRAL As Descripcion_Alt,CostoUd1,CostoUd2,Rtu,FechaVigencia,
                            Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete,Un_Compra,Un_MinCompra,Ac_Oferta,Ac_Disponible,Ac_Cotizar,UD01PR As Ud1,UD02PR As Ud2,
                            Map.PM As Pm,Map.PPUL01 As Uc1,Map.PPUL02 As Uc2,No_Usar,Id,Id_Padre
                            From " & _Global_BaseBk & "Zw_ListaPreCosto 
	                            Inner Join MAEPR Mp On Mp.KOPR = Codigo
		                            Inner Join MAEPREM Map On EMPRESA = '" & ModEmpresa & "' And Map.KOPR = Codigo
                                        Inner Join TABCODAL Tda On KOEN = '" & _CodProveedor & "' And Tda.KOPR = Codigo And Tda.KOPRAL = CodAlternativo 
                            Where Id_Padre = " & _Id_Padre & "
                            --Where Proveedor = '" & _CodProveedor & "' And Sucursal = '" & _SucProveedor & "' And Lista = '" & _CodLista & "' And FechaVigencia = '" & _FechaVigencia & "'"

            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set Repetidos = (Select Count(*) From " & _Nombre_Tbl_Paso_Costos & " Z2 Where Z1.Codigo = Z2.Codigo)
                            From " & _Nombre_Tbl_Paso_Costos & " Z1"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set RepetidosAlt = (Select Count(*) From " & _Nombre_Tbl_Paso_Costos & " Z2 Where Z1.CodAlternativo = Z2.CodAlternativo)
                            From " & _Nombre_Tbl_Paso_Costos & " Z1"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set Repetido = 1" & vbCrLf &
                           "Where Repetidos > 1 or RepetidosAlt > 1"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            Consulta_sql = "Select * From " & _Nombre_Tbl_Paso_Costos & " Where RepetidosAlt > 1"
            Dim _Tbl_Repetidos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Chk_OrdenDeLlegada.Visible = False

            Me.Refresh()

        End If

        If Chk_NoUsar_Bloqueados.Checked Then
            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set No_Usar = 1" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Costos & " As PrPro
                            Inner Join MAEPR On KOPR = Codigo And BLOQUEAPR <> ''"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Dim _Filtro_Adicional As String

        If Chk_Quitar_Sin_Usar.Checked Then
            _Filtro_Adicional = "And No_Usar = 0" & vbCrLf
        End If

        If Chk_Quitar_Bloqueados_venta.Checked Then
            _Filtro_Adicional += "And Bloqueapr = ''"
        End If

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set Bloqueapr = BLOQUEAPR" & vbCrLf &
                       "From " & _Nombre_Tbl_Paso_Costos & " As PrPro
                        Inner Join MAEPR On KOPR = Codigo"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        'Consulta_sql = "Select PrPro.*,MAEPR.BLOQUEAPR,Cast(0 As Float) As Neto_Cn_Dscto 
        '                From " & _Nombre_Tbl_Paso_Costos & " As PrPro
        '                Inner Join MAEPR On KOPR = Codigo
        '                Where 1 > 0 And BLOQUEAPR = '' " & _Filtro_Sin_Usar & "
        '                Order by Codigo"

        Consulta_sql = "Select *,Cast(0 As Float) As Impuestos From " & _Nombre_Tbl_Paso_Costos & vbCrLf &
                       "Where 1 > 0 " & vbCrLf & _Filtro_Adicional & vbCrLf &
                       "Order by Codigo"
        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Dv.Table = _Ds.Tables("Table")

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, False)

            Dim _Displayindex = 0
            Dim _Campo As String

            _Campo = "Select"
            .Columns(_Campo).Width = 25
            .Columns(_Campo).HeaderText = "S."
            ' .Columns(_Campo).Frozen = True
            '.Columns(_Campo).ReadOnly = False
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Bloqueapr"
            .Columns(_Campo).Width = 15
            .Columns(_Campo).HeaderText = "B"
            .Columns(_Campo).ToolTipText = "Bloquedados ('vacía' = No bloqueado, 'C' = Bloq. Compras, 'V' = Bloq. Ventas, 'T' = Bloqueado compras, ventas y producción)"
            .Columns(_Campo).ReadOnly = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            'Ojo... Hay que agregar este campo en la creación de la tabla de paso
            '_Campo = "EsOferta"
            '.Columns(_Campo).Width = 35
            '.Columns(_Campo).HeaderText = "Oferta"
            '.Columns(_Campo).ReadOnly = False
            '.Columns(_Campo).Visible = EsListaOferta
            '.Columns(_Campo).DisplayIndex = _Displayindex
            '_Displayindex += 1

            _Campo = "Codigo"
            .Columns(_Campo).Width = 90
            .Columns(_Campo).HeaderText = "Código (Random)"
            .Columns(_Campo).ReadOnly = True
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "No_Usar"
            .Columns(_Campo).Width = 35
            .Columns(_Campo).HeaderText = "No usar"
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).ReadOnly = False
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Repetido"
            .Columns(_Campo).Width = 30
            .Columns(_Campo).HeaderText = "R"
            .Columns(_Campo).ToolTipText = "Código repetido"
            .Columns(_Campo).ReadOnly = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Codalternativo"
            .Columns(_Campo).Width = 110
            .Columns(_Campo).HeaderText = "SKU. Proveedor"
            .Columns(_Campo).ReadOnly = True
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Descripcion"
            .Columns(_Campo).Width = 295 - 15 - 30
            .Columns(_Campo).HeaderText = "Descripción"
            .Columns(_Campo).ReadOnly = True
            '.Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "CostoUd1"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Costo Ud1"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "CostoUd2"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Costo Ud2"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "$ ###,##.##"
            ' .Columns(_Campo).Frozen = True
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc1"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 1°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc2"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 2°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc3"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 3°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc4"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 4°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Desc5"
            .Columns(_Campo).Width = 45
            .Columns(_Campo).HeaderText = "D% 5°"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

            _Campo = "Flete"
            .Columns(_Campo).Width = 65
            .Columns(_Campo).HeaderText = "Flete"
            .Columns(_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Campo).DefaultCellStyle.Format = "$ ###,##.##"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _Displayindex
            _Displayindex += 1

        End With

        Lbl_Rtu.DataBindings.Clear()
        Lbl_Descripcion.DataBindings.Clear()
        Lbl_Ud1.DataBindings.Clear()
        Lbl_Ud2.DataBindings.Clear()
        Lbl_Uc1.DataBindings.Clear()
        Lbl_Uc2.DataBindings.Clear()
        Lbl_Pm.DataBindings.Clear()
        Lbl_Neto_Cn_Dscto.DataBindings.Clear()
        Lbl_Impuestos.DataBindings.Clear()

        Lbl_Rtu.DataBindings.Add("text", _Dv, "Rtu", True, Nothing, Nothing, "N2")

        Lbl_Descripcion.DataBindings.Add("text", _Dv, "Descripcion")
        Lbl_Ud1.DataBindings.Add("text", _Dv, "Ud1")
        Lbl_Ud2.DataBindings.Add("text", _Dv, "Ud2")

        Lbl_Uc1.DataBindings.Add("text", _Dv, "Uc1", True, Nothing, Nothing, "C2")
        Lbl_Uc2.DataBindings.Add("text", _Dv, "Uc2", True, Nothing, Nothing, "C2")
        Lbl_Pm.DataBindings.Add("text", _Dv, "Pm", True, Nothing, Nothing, "C2")
        Lbl_Neto_Cn_Dscto.DataBindings.Add("text", _Dv, "Neto_Cn_Dscto", True, Nothing, Nothing, "C2")

        Lbl_Impuestos.DataBindings.Add("text", _Dv, "Impuestos", True, Nothing, Nothing, "C2")

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Repetidos = _Fila.Cells("Repetidos").Value
            Dim _No_Usar = _Fila.Cells("No_Usar").Value

            If _Repetidos > 1 Then
                _Fila.DefaultCellStyle.ForeColor = Color.Purple
            End If

            If _No_Usar Then
                _Fila.DefaultCellStyle.ForeColor = Rojo
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

            Dim _Desc1 = _Fila.Cells("Desc1").Value
            Dim _Desc2 = _Fila.Cells("Desc2").Value
            Dim _Desc3 = _Fila.Cells("Desc3").Value
            Dim _Desc4 = _Fila.Cells("Desc4").Value
            Dim _Desc5 = _Fila.Cells("Desc5").Value

            Dim _DescSuma As Double = 100 * (1 - (
                                         (1 - (_Desc1 / 100.0)) *
                                         (1 - (_Desc2 / 100.0)) *
                                         (1 - (_Desc3 / 100.0)) *
                                         (1 - (_Desc4 / 100.0)) *
                                         (1 - (_Desc5 / 100.0))))

            _DescSuma = Math.Round(_DescSuma, 2)

            Dim _Neto = _Fila.Cells("CostoUd1").Value

            If CBool(_DescSuma) Then
                _DescSuma = (_DescSuma / 100)
                _Neto = _Neto - (_Neto * _DescSuma)
            End If

            _Fila.Cells("Neto_Cn_Dscto").Value = _Neto

            Dim _Codigo = _Fila.Cells("Codigo").Value

            Consulta_sql = "Select Isnull(Sum(POIM), 2) As Impuesto From TABIM Where KOIM In (Select KOIM From TABIMPR Where KOPR = '" & _Codigo & "')"
            Dim _RowImp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_RowImp) Then
                _Fila.Cells("Impuestos").Value = 0
            Else
                _Fila.Cells("Impuestos").Value = _RowImp.Item("Impuesto")
            End If

        Next

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Frm_MantCostosPrecios_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Consulta_sql = "Drop table " & _Nombre_Tbl_Paso_Costos
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Function Fx_Revisar_Si_Hay_Tickeados() As Boolean

        Dim _Contador = 0
        For Each _Filas As DataRow In _Tbl_Lista_Proveedor.Rows
            If _Filas.Item("Select") Then
                _Contador += 1
            End If
        Next

        If CBool(_Contador) Then
            Return True
        Else
            MessageBoxEx.Show(Me, "No hay poductos seleccionados", "Prestashop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Function

    Private Sub validar_Keypress(ByVal sender As Object,
                                 ByVal e As System.Windows.Forms.KeyPressEventArgs)

        With Grilla

            Dim Registros As Integer = .RowCount

            Dim columna As Integer = .CurrentCellAddress.X 'Current.ColumnIndex
            Dim fila As Integer = .CurrentCellAddress.Y 'Current.ColumnIndex


            Dim Cabeza = .Columns(columna).Name
            Dim Codigo = .Rows(fila).Cells("Codigo").Value
            Dim Descripcion = .Rows(fila).Cells("Descripcion").Value

            ' comprobar si la celda en edición corresponde a la columna 1 o 2
            'If Cabeza = "Margen2" Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            If e.KeyChar = "."c Then
                ' si se pulsa la coma se convertirá en punto
                'e.Handled = True
                SendKeys.Send(",")
                e.KeyChar = ","c
                caracter = ","
            End If

            Dim Caracter_Raro = ChrW(Keys.Back)
            Dim EsNumero As Boolean = Char.IsNumber(caracter)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ",") And
            (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
            'End If
        End With


    End Sub

    Private Sub GrillaPC_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
    End Sub


    Private Sub GrillaPC_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Try

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Rtu As Double = _Fila.Cells("Rtu").Value

            Dim _CostoUd1v As Double = _Fila.Cells("CostoUd1").Value
            Dim _CostoUd2v As Double = _Fila.Cells("CostoUd2").Value

            If _Cabeza = "CostoUd1" Or _Cabeza = "CostoUd2" Then

                If ChkUd1XUd2.Checked Then

                    If _Cabeza = "CostoUd1" Then

                        _CostoUd2v = Math.Round(_CostoUd1v * _Rtu, 5)
                        _Fila.Cells("CostoUd2").Value = _CostoUd2v

                    ElseIf _Cabeza = "CostoUd2" Then

                        _CostoUd1v = Math.Round(_CostoUd2v / _Rtu, 5)
                        _Fila.Cells("CostoUd1").Value = _CostoUd1v

                    End If

                End If

            End If

            Dim _Desc1v = _Fila.Cells("Desc1").Value
            Dim _Desc2v = _Fila.Cells("Desc2").Value
            Dim _Desc3v = _Fila.Cells("Desc3").Value
            Dim _Desc4v = _Fila.Cells("Desc4").Value
            Dim _Desc5v = _Fila.Cells("Desc5").Value

            Dim _DescSumav As Double = 100 * (1 - (
                                                 (1 - (_Desc1v / 100.0)) *
                                                 (1 - (_Desc2v / 100.0)) *
                                                 (1 - (_Desc3v / 100.0)) *
                                                 (1 - (_Desc4v / 100.0)) *
                                                 (1 - (_Desc5v / 100.0))))

            _DescSumav = Math.Round(_DescSumav, 2)
            _Fila.Cells("DescSuma").Value = _DescSumav

            Dim _Neto = _Fila.Cells("CostoUd1").Value

            If CBool(_DescSumav) Then
                _DescSumav = (_DescSumav / 100)
                _Neto = _Neto - (_Neto * _DescSumav)
            End If

            _Fila.Cells("Neto_Cn_Dscto").Value = _Neto


            _Fila.Cells("Select").Value = True

            Dim _Id As Integer = _Fila.Cells("Id").Value
            Dim _Lista As String = _Fila.Cells("Lista").Value
            Dim _Codigo As String = _Fila.Cells("Codigo").Value.ToString.Trim
            Dim _CodAlternativo As String = _Fila.Cells("CodAlternativo").Value.ToString.Trim
            Dim _No_Usar As Boolean = _Fila.Cells("No_Usar").Value

            Dim _CostoUd1 As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("CostoUd1").Value, 0), , 5)
            Dim _CostoUd2 As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("CostoUd2").Value, 0), , 5)

            Dim _Desc1 As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("Desc1").Value, 0), , 5)
            Dim _Desc2 As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("Desc2").Value, 0), , 5)
            Dim _Desc3 As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("Desc3").Value, 0), , 5)
            Dim _Desc4 As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("Desc4").Value, 0), , 5)
            Dim _Desc5 As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("Desc5").Value, 0), , 5)
            Dim _DescSuma As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("DescSuma").Value, 0), , 5)

            Dim _Flete As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("Flete").Value, 0), , 5)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set" & vbCrLf &
                            "[Select] = 1," & vbCrLf &
                            "No_Usar = " & Convert.ToInt32(_No_Usar) & "," & vbCrLf &
                            "CostoUd1 = " & _CostoUd1 & "," & vbCrLf &
                            "CostoUd2 = " & _CostoUd2 & "," & vbCrLf &
                            "Desc1 = " & _Desc1 & "," & vbCrLf &
                            "Desc2=" & _Desc2 & "," & vbCrLf &
                            "Desc3=" & _Desc3 & "," & vbCrLf &
                            "Desc4=" & _Desc4 & "," & vbCrLf &
                            "Desc5=" & _Desc5 & "," & vbCrLf &
                            "DescSuma=" & _DescSuma & "," & vbCrLf &
                            "Flete=" & _Flete & vbCrLf &
                            "Where Id = " & _Id

            _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Cabeza = "No_Usar" Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set No_Usar = " & Convert.ToInt32(_No_Usar) & "
                                Where Proveedor = '" & _CodProveedor & "'  And Codigo = '" & _Codigo & "' And CodAlternativo = '" & _CodAlternativo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If _No_Usar Then
                    _Fila.DefaultCellStyle.ForeColor = Rojo
                    _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                Else
                    _Fila.DefaultCellStyle.ForeColor = Color.Purple 'Color.Black
                    _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        If Chk_Ver_Solo_Repetidos.Checked Then
            MessageBoxEx.Show(Me, "Debe quitar el Check [" & Chk_Ver_Solo_Repetidos.Text & "]", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Sb_Grabar()

    End Sub

    Sub Sb_Grabar()

        Grilla.Refresh()

        Consulta_sql = "Select Z2.*," & vbCrLf &
                        "(Select Count(*) From " & _Nombre_Tbl_Paso_Costos & " Z1 Where Z1.Codigo = Z2.Codigo And Z1.No_Usar = 0) As Veces_NoUsar" & vbCrLf &
                        "Into #Paso" & vbCrLf &
                        "From " & _Nombre_Tbl_Paso_Costos & " Z2" &
                        vbCrLf &
                        vbCrLf &
                        "Select Distinct Codigo From #Paso" & vbCrLf &
                        "Where (Repetidos > 1 Or RepetidosAlt > 1) And Veces_NoUsar > 1" & vbCrLf &
                        vbCrLf &
                        "Select * From #Paso" & vbCrLf &
                        "Where (Repetidos > 1 Or RepetidosAlt > 1) And Veces_NoUsar > 1" & vbCrLf &
                        vbCrLf &
                        "Drop table #Paso"

        Dim _TblRepetidos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If _TblRepetidos.Rows.Count Then
            MessageBoxEx.Show(Me, "Existen " & _TblRepetidos.Rows.Count & " producto(s) que tienen mas de un código alternativo para el proveedor." & vbCrLf & vbCrLf &
                              "Debe dejar solo un código alternativo activo para cada producto." & vbCrLf &
                              "El código alternativo que no corresponda debe marcarlo como [No Usar]", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_ListaPreCosto" & vbCrLf &
                       "Where Id In (Select Id_Hijo From " & _Nombre_Tbl_Paso_Costos & " Where RepetidosAlt > 1 And No_Usar = 1)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Reg = Grilla.RowCount

        Dim _SqlActListaRandom As String = String.Empty

        Consulta_sql = "Select Id, Tabla_Random, Campo_Random, Tabla_Bakapp, Campo_Bakapp
                        From " & _Global_BaseBk & "Zw_Tablas_Equivalentes_Rd_Bk
                        Where Tabla_Bakapp = 'Zw_ListaPreCosto'"
        Dim _Tbl_Equivalentes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Sql_Equivalentes As String

        For Each _Fila As DataRow In _Tbl_Equivalentes.Rows

            Dim _Campo_Rd As String = _Fila.Item("Campo_Random")
            Dim _Campo_Bk As String = _Fila.Item("Campo_Bakapp")

            _Sql_Equivalentes += "," & _Campo_Rd & " = " & _Campo_Bk

        Next

        Consulta_sql = "Insert Into TABRECPR (KOPR,RECARGO,KOEN,ECUARECAR,EMPRESA)
                        Select Codigo,Flete,Proveedor,'','" & ModEmpresa & "' From " & _Nombre_Tbl_Paso_Costos & " 
                        Where Codigo Not In (Select KOPR From TABRECPR Where KOEN = '" & _CodProveedor & "' And EMPRESA = '" & ModEmpresa & "') And Flete > 0 

                        Update TABRECPR Set EMPRESA = '" & ModEmpresa & "' 
                        Where KOEN = '" & _CodProveedor & "' And KOPR In (Select Codigo From " & _Nombre_Tbl_Paso_Costos & ") And EMPRESA = ''"
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        _SqlActListaRandom = "Update TABPRE Set PP01UD = CostoUd1,PP02UD = CostoUd2" & _Sql_Equivalentes & vbCrLf &
                             "From " & _Nombre_Tbl_Paso_Costos & " Tbp Inner Join TABPRE On KOLT = Tbp.Lista And KOPR = Tbp.Codigo And No_Usar = 0" & vbCrLf

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set 
                        Descripcion = Tbp.Descripcion,
	                    Descripcion_Alt = Tbp.Descripcion_Alt,
	                    CostoUd1 = Tbp.CostoUd1,
	                    CostoUd2 = Tbp.CostoUd2,
	                    Desc1 = Tbp.Desc1,
	                    Desc2 = Tbp.Desc2,
	                    Desc3 = Tbp.Desc3,
	                    Desc4 = Tbp.Desc4,
	                    Desc5 = Tbp.Desc5,
                        DescSuma = Tbp.DescSuma,
	                    Flete = Tbp.Flete,
                        CodFuncionario_Edita = '" & FUNCIONARIO & "',
                           FechaEdita = Getdate()
                                 From " & _Nombre_Tbl_Paso_Costos & " Tbp 
	                                  Inner Join " & _Global_BaseBk & "Zw_ListaPreCosto Tlc On Tbp.Id_Padre = Tlc.Id_Padre And Tbp.Id_Hijo = Tlc.Id --Tbp.Lista = Tlc.Lista 
                                            --And Tbp.Proveedor = Tlc.Proveedor And Tbp.Codigo = Tlc.Codigo 
                                                --And Tbp.FechaVigencia = Tlc.FechaVigencia 
                                                    --And Tbp.CodAlternativo = Tlc.CodAlternativo 
                                                         And Tbp.[Select] = 1

                            Update TABRECPR Set RECARGO = Flete 
                            From " & _Nombre_Tbl_Paso_Costos & " Tbp Inner Join TABRECPR On KOEN = Tbp.Proveedor And KOPR = Tbp.Codigo And Tbp.[Select] = 1 And No_Usar = 0" & vbCrLf &
                            _SqlActListaRandom & vbCrLf &
                            "Update " & _Nombre_Tbl_Paso_Costos & " Set [Select] = 0"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            'For Each _Fila As DataRow In _Ds.Tables(0).Rows
            '    _Fila.Item("Select") = False
            'Next

            Chk_Ver_Solo_Repetidos.Checked = False

            Sb_Actualizar_Grilla(True, True)

            MessageBoxEx.Show(Me, FormatNumber(_Reg, 0) & " Dato(s) actualizado(s) lista: " & _CodLista, "Actualizar Costos",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        _Grabacion_Realizada = True

    End Sub

    Private Sub Frm_MantCostosPrecios_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Dim _Tecla As Keys = e.KeyValue

        Select Case _Tecla
            Case Keys.F5
                'Sb_Actualizar_Grilla(True)
                Sb_Actualizar_Grilla(True, True)
        End Select

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub BtnBuscarProductoEnGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Codigo As String

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_CodSucEntidad = String.Empty
        Fm.Pro_Tipo_Lista = "P"
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.Pro_Sucursal_Busqueda = ModSucursal
        Fm.Pro_Bodega_Busqueda = ModBodega
        Fm.Pro_Mostrar_Info = False
        Fm.Pro_Actualizar_Precios = False

        Fm.ShowDialog(Me)
        If Fm.Pro_Seleccionado Then
            If Not (Fm.Pro_RowProducto Is Nothing) Then
                _Codigo = Fm.Pro_RowProducto.Item("KOPR")
            End If

            If Not String.IsNullOrEmpty(Trim(_Codigo)) Then
                If BuscarDatoEnGrilla(Trim(_Codigo), "Codigo", Grilla) = True Then
                    Grilla.Focus()
                End If
            End If
        End If
    End Sub

#Region "Importar desde Excel"

    Sub Sb_Buscar_Archivo_e_Importar()

        Dim _Nombre_Archivo As String
        Dim _UbicArchivo As String

        With OpenFileDialog1

            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            '.ShowDialog(Me)

            If .ShowDialog(Me) = DialogResult.OK Then
                _Nombre_Archivo = .SafeFileName
                _UbicArchivo = .FileName
            Else
                _UbicArchivo = String.Empty
            End If

        End With

        Dim Archivo_Importado_correctamente As Boolean
        If Not String.IsNullOrEmpty(_UbicArchivo) Then

            BtnOrdenarRegistros.Enabled = False

            Btn_Cancelar.Visible = True
            _Tbl_Filtro_Productos = Nothing

            Dim _RazonProveedor = _RowProveedor.Item("NOKOEN")

            Radio1.Text = "Códigos propios (Código principal del sistema)"
            Radio2.Text = "Códigos del proveedor: (" & _RazonProveedor.ToString.Trim & ")"

            Dim _Foot As String = "Nota: Si la columna Flete esta vacía el sistema no cambiara este dato en la tabla."

            Dim info As New TaskDialogInfo("Productos a levantar",
                         eTaskDialogIcon.ShieldOk,
                          "¿Que código estan incluidos en la lista?",
                          "Debe indicar cual es el código que estudiara el sistema" & vbCrLf & vbCrLf,
                          eTaskDialogButton.Ok _
                          , eTaskDialogBackgroundColor.Red, GetRadioButtons, Nothing, Nothing, _Foot, Nothing)

            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            If result = eTaskDialogResult.None Then Return

            Dim _Codigo_Del_Proveedor
            If Radio1.Checked Then
                _Codigo_Del_Proveedor = False
            ElseIf Radio2.Checked Then
                _Codigo_Del_Proveedor = True
            End If

            Archivo_Importado_correctamente = Importar_LcCosto(_Nombre_Archivo, _UbicArchivo, 0, _Codigo_Del_Proveedor)


            If Archivo_Importado_correctamente Then

                MessageBoxEx.Show(Me, "Datos cargados correctamente", "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Sb_Actualizar_Grilla(False)
                Sb_Actualizar_Grilla(False, True)
            End If

        Else

            Beep()
            ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

        Me.Refresh()

    End Sub

    Private Function GetRadioButtons() As Command()
        Return New Command() {Radio1, Radio2}
    End Function

    Private Function Importar_LcCosto(ByVal Nombre_Archivo As String,
                                      ByVal Ubic_Archivo As String,
                                      ByVal Nro_Hoja As Integer,
                                      ByVal _Codigo_Del_Proveedor As Boolean) As Boolean

        Dim i As Integer

        Dim _Lista As String
        Dim _Codigo As String
        Dim _Cod_Barras As String
        Dim _Ud1 As String
        Dim _Ud2 As String
        Dim _Rtu As Double
        Dim _CostoUd1 As Double
        Dim _CostoUd2 As Double
        Dim _Descripcion As String
        Dim _Descripcion_Alt As String
        Dim _Unidad_Compra As String
        Dim _Unidad_Minimo_De_Compra As Double
        Dim _Desc1 As Double
        Dim _Desc2 As Double
        Dim _Desc3 As Double
        Dim _Desc4 As Double
        Dim _Desc5 As Double
        Dim _DescSuma As Double
        Dim _Flete As Double
        Dim __Error As String
        Dim SinProbremas As Integer

        Dim _Tbl_Errores As DataTable

        Consulta_sql = "Select Cast('' As Varchar(20)) As Codigo,Cast('' As Varchar(300)) As Error Where 1<0"
        _Tbl_Errores = _Sql.Fx_Get_DataTable(Consulta_sql)

        Try

            Barra_Progreso.Value = 0
            Barra_Progreso.Visible = True
            Btn_Cancelar.Visible = True

            BtnGrabar.Enabled = False
            Btn_Refrescar.Enabled = False
            Btn_Importar_Desde_Excel.Enabled = False
            BtnExportarExcel.Enabled = False

            Btn_Actualizar_Lista_Random.Enabled = False
            Btn_ImportarFletes.Enabled = False
            Btn_ImportarPreciosOtraLista.Enabled = False

            Txt_Buscar.Enabled = False
            Grilla.Enabled = False

            Me.Refresh()
            System.Windows.Forms.Application.DoEvents()


            Dim ImpEx As New Class_Importar_Excel
            Dim Extencion As String = Replace(System.IO.Path.GetExtension(Nombre_Archivo), ".", "")
            Dim _Row_Producto_Lista As DataRow

            ToastNotification.Show(Me, "LEYENDO ARCHIVO.. POR FAVOR ESPERE.", My.Resources.ok_button,
                                              6 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


            Dim Arreglo = ImpEx.Importar_Excel_Array(Ubic_Archivo, Extencion, Nro_Hoja)
            Dim Filas = Arreglo.GetUpperBound(0)
            Dim RegInsert As Long = 0

            Barra_Progreso.Maximum = 100
            Dim Contador As Integer = 0


            ToastNotification.Show(Me, "Archivo Excel de origen leído completamante" & vbCrLf &
                                   "Ahora el sistema empezara a estudiar y levantar cada producto", My.Resources.ok_button,
                                   6 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            Dim _SqlQuery As String = String.Empty

            For i = 1 To Filas

                System.Windows.Forms.Application.DoEvents()

                _Lista = _CodLista
                _Codigo = NuloPorNro(Arreglo(i, 0), "")
                _Descripcion_Alt = Replace(NuloPorNro(Arreglo(i, 1), 0), "'", "''")
                _Cod_Barras = String.Empty

                If _Codigo = "P379" Then
                    Dim a = 1
                End If

                __Error = String.Empty

                Try : _CostoUd1 = NuloPorNro(Arreglo(i, 2), 0) : Catch ex As Exception : __Error += "[CostoUd1]" : End Try
                Try : _CostoUd2 = NuloPorNro(Arreglo(i, 3), 0) : Catch ex As Exception : __Error += "[CostoUd2]" : End Try
                Try : _Desc1 = NuloPorNro(Arreglo(i, 4), 0) : Catch ex As Exception : __Error += "[Desc1]" : End Try
                Try : _Desc2 = NuloPorNro(Arreglo(i, 5), 0) : Catch ex As Exception : __Error += "[Desc2" : End Try
                Try : _Desc3 = NuloPorNro(Arreglo(i, 6), 0) : Catch ex As Exception : __Error += "[Desc3]" : End Try
                Try : _Desc4 = NuloPorNro(Arreglo(i, 7), 0) : Catch ex As Exception : __Error += "[Desc4]" : End Try
                Try : _Desc5 = NuloPorNro(Arreglo(i, 8), 0) : Catch ex As Exception : __Error += "[Desc5]" : End Try

                Dim _Traer_Flete_Desde_Rd As Boolean = False

                Try

                    If Not IsNumeric(Arreglo(i, 9)) Then
                        _Traer_Flete_Desde_Rd = True
                    End If

                    _Flete = NuloPorNro(Arreglo(i, 9), 0)

                Catch ex As Exception
                    __Error += "[Flete]"
                End Try

                Try : _Unidad_Compra = NuloPorNro(Arreglo(i, 10), "UN") : Catch ex As Exception : __Error = "[Unidad de compra]" : End Try
                Try : _Unidad_Minimo_De_Compra = NuloPorNro(Arreglo(i, 11), 1) : Catch ex As Exception : __Error += "[Cant. Mínimo de compra]" : End Try

                If Not String.IsNullOrEmpty(__Error) Then

                    __Error = "Error en columna(s): " & __Error

                End If

                Dim _Existe_Pr As Boolean = False

                If String.IsNullOrEmpty(__Error) Then

                    _DescSuma = 100 * (1 - (
                                                 (1 - (_Desc1 / 100.0)) *
                                                 (1 - (_Desc2 / 100.0)) *
                                                 (1 - (_Desc3 / 100.0)) *
                                                 (1 - (_Desc4 / 100.0)) *
                                                 (1 - (_Desc5 / 100.0))))

                    _DescSuma = Math.Round(_DescSuma, 2)

                    Dim _Error As String = String.Empty

                    If _Codigo_Del_Proveedor Then

                        Consulta_sql = "Select * From " & _Nombre_Tbl_Paso_Costos & " Where CodAlternativo = '" & _Codigo & "'"
                        _Row_Producto_Lista = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Else

                        Consulta_sql = "Select * From " & _Nombre_Tbl_Paso_Costos & " Where Codigo = '" & _Codigo & "'"
                        _Row_Producto_Lista = _Sql.Fx_Get_DataRow(Consulta_sql)

                    End If


                    If Not IsNothing(_Row_Producto_Lista) Then

                        _Codigo = _Row_Producto_Lista.Item("Codigo").ToString.Trim
                        _Cod_Barras = _Row_Producto_Lista.Item("CodAlternativo").ToString.Trim

                        _Existe_Pr = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'")) 'CBool(_Tbl_Producto.Rows.Count)

                        If Not _Existe_Pr Then

                            Sb_Ingresar_Fila_Error(_Tbl_Errores, _Codigo, "Producto no existen maestra de productos de RANDOM", i)

                        End If

                    Else

                        _Existe_Pr = False
                        _Error = "Producto no se encuentra en tabla de códigos alternativos para el proveedor, "

                        Sb_Ingresar_Fila_Error(_Tbl_Errores, _Codigo, _Error, i)

                    End If

                Else

                    Sb_Ingresar_Fila_Error(_Tbl_Errores, _Codigo, __Error, i)

                End If

                If _Existe_Pr Then

                    If _Traer_Flete_Desde_Rd Then
                        _Flete = _Sql.Fx_Trae_Dato("TABRECPR", "RECARGO", "KOEN = '" & _CodProveedor & "' And KOPR = '" & _Codigo & "'", True)
                    End If

                    _Rtu = _Row_Producto_Lista.Item("Rtu")

                    If ChkUd1XUd2.Checked Then

                        If _CostoUd1 > 0 And _CostoUd2 = 0 Then
                            _CostoUd2 = Math.Round(_CostoUd1 * _Rtu, 5)
                        ElseIf _CostoUd2 > 0 And _CostoUd1 = 0 Then
                            _CostoUd1 = Math.Round(_CostoUd2 / _Rtu, 5)
                        End If

                    End If


                    _SqlQuery += "Update " & _Nombre_Tbl_Paso_Costos & " Set 
                                                [Select] = 1,
                                                CostoUd1 = " & De_Num_a_Tx_01(_CostoUd1, False, 5) & ",
                                                CostoUd2 = " & De_Num_a_Tx_01(_CostoUd2, False, 5) & ",
                                                Desc1 = " & De_Num_a_Tx_01(_Desc1, False, 5) & ",
                                                Desc2 = " & De_Num_a_Tx_01(_Desc2, False, 5) & ",
                                                Desc3 = " & De_Num_a_Tx_01(_Desc3, False, 5) & ",
                                                Desc4 = " & De_Num_a_Tx_01(_Desc4, False, 5) & ",
                                                Desc5 = " & De_Num_a_Tx_01(_Desc5, False, 5) & ",
                                                DescSuma = " & De_Num_a_Tx_01(_DescSuma, False, 5) & ",
                                                Flete = " & De_Num_a_Tx_01(_Flete, False, 5) & "
                                                Where Codigo = '" & _Codigo & "'" & vbCrLf & vbCrLf

                End If

                'If CBool(_Tbl_Errores.Rows.Count) Then
                '    Barra_Progreso.ProgressColor = Color.Red
                'End If

                System.Windows.Forms.Application.DoEvents()
                Lbl_Status.Text = "Leyendo fila " & FormatNumber(i, 0) & " de " & FormatNumber(Filas, 0) &
                                     ". Estado Ok: " & FormatNumber(SinProbremas, 0) & ", Problemas: " & Format(_Tbl_Errores.Rows.Count, 0)

                System.Windows.Forms.Application.DoEvents()
                Contador += 1
                Dim _Progreso = Math.Round(((Contador * 100) / Filas), 0)
                If _Progreso = 100 Then _Progreso = 99

                Barra_Progreso.Value = _Progreso
                'Barra_Progreso.Value += 1
                Barra_Progreso.Text = Barra_Progreso.Value & "%"


                If _Cancelar Then
                    If MessageBoxEx.Show(Me, "¿Esta seguro de cancelar el levantamiento?", "Cancelar",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Exit For
                    Else
                        _Cancelar = False
                    End If
                End If

            Next

            Barra_Progreso.Text = "100%"

            Dim _Actualizar As Boolean = Not (String.IsNullOrEmpty(_SqlQuery))



            If CBool(_Tbl_Errores.Rows.Count) Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(_Tbl_Errores.Rows.Count)))

                If _Tbl_Errores.Rows.Count = 1 Then
                    _Leyend = "Existe " & _Tbl_Errores.Rows.Count & " línea con problema en el archivo de lectura"
                Else
                    _Leyend = "Existen " & _Tbl_Errores.Rows.Count & " líneas con problemas en el archivo de lectura"
                End If

                _Actualizar = False

                If _Tbl_Errores.Rows.Count < Filas Then
                    If MessageBoxEx.Show(Me, "Existente resgistros que no fueron validados, sin embargo otros sí" & vbCrLf & vbCrLf &
                                         "¿Desea cargar igualmente las filas correctas?", "Importar datos",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                        _Actualizar = True
                    End If
                End If

                MessageBoxEx.Show(Me, _Leyend & vbCrLf &
                                  "a continuación se mostrar una lista con los errores",
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ExportarTabla_JetExcel_Tabla(_Tbl_Errores, Me, "Errores_Lista")

            End If

            If _Actualizar Then

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
                    Return True
                End If

            End If


        Catch ex As Exception

            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Finally

            Lbl_Status.Text = String.Empty
            Barra_Progreso.Value = 0
            Barra_Progreso.Visible = False
            Btn_Cancelar.Visible = False

            BtnGrabar.Enabled = True
            Btn_Refrescar.Enabled = True
            Btn_Importar_Desde_Excel.Enabled = True
            BtnExportarExcel.Enabled = True

            Btn_Actualizar_Lista_Random.Enabled = True
            Btn_ImportarFletes.Enabled = True
            Btn_ImportarPreciosOtraLista.Enabled = True

            Txt_Buscar.Enabled = True
            Grilla.Enabled = True

        End Try

        Me.Refresh()

    End Function

    Function Sb_Ingresar_Fila_Error(_Tbl_Errores As DataTable, _Codigo As String, _Error As String, _Nro_Fila As Integer)

        Dim NewFila As DataRow
        NewFila = _Tbl_Errores.NewRow

        NewFila.Item("Codigo") = _Codigo
        NewFila.Item("Error") = _Error & ", Fila: " & _Nro_Fila

        _Tbl_Errores.Rows.Add(NewFila)

    End Function

#End Region

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        ShowContextMenu(Menu_Contextual_Exportar_Excel)
        'Dim _NomArch As String

        'Dim _RazonProveedor = _RowProveedor.Item("NOKOEN")
        'Consulta_sql = "Select * From " & _Nombre_Tbl_Paso_Costos & vbCrLf &
        '           "Where Codigo <> ''"
        '_NomArch = "Lista de costos " & _RazonProveedor

        'Dim Tbl_Excel As DataTable
        'Tbl_Excel = _Sql.Fx_Get_Tablas(Consulta_sql)

        'ExportarTabla_JetExcel_Tabla(Tbl_Excel, Me, _NomArch.Trim)

    End Sub

    Sub Chk_Orden_Lista_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Chk_OrdenDeLlegada.Checked Then
            Btn_Ordenar_Codigo_Lista.Enabled = False
            Btn_Ordenar_Lista_Codigo.Enabled = False
            RdbOrdenCodigo.Enabled = False
            RdbOrdenDescripcion.Enabled = False
        Else
            Btn_Ordenar_Codigo_Lista.Enabled = True
            Btn_Ordenar_Lista_Codigo.Enabled = True
            RdbOrdenCodigo.Enabled = True
            RdbOrdenDescripcion.Enabled = True
        End If
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            Dim Fm As New Frm_EstadisticaProducto(_Codigo)
            Fm.VerEdicionProducto = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Codigos_Alternativos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Codigos_Alternativos.Click

        If Fx_Tiene_Permiso(Me, "Prod020") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value
            Dim _Rtu As Double = _Fila.Cells("Rtu").Value

            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _Codigo
            Fm.Txtdescripcion.Text = _Descripcion
            Fm.TxtRTU.Text = _Rtu
            Fm.ShowDialog(Me)

        End If

    End Sub

    Private Sub Grilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown

        Try

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Tecla As Keys = e.KeyValue

            Dim _No_Usar As Boolean = _Fila.Cells("No_Usar").Value

            Select Case _Tecla

                Case Keys.Enter

                    Select Case _Cabeza

                        Case "DsctoMax", "Dscto1", "Dscto2", "Dscto3", "Dscto4", "Dscto5", "Flete",
                              "CostoUd1", "CostoUd2", "Desc1", "Desc2", "Desc3", "Desc4", "Desc5"

                            If Not _No_Usar Then

                                Dim _Editar As Boolean

                                Select Case _Cabeza

                                    Case "Desc1", "Desc2", "Desc3", "Desc4", "Desc5"

                                        _Editar = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Tablas_Equivalentes_Rd_Bk",
                                                                           "Tabla_Random = 'TABPP' And Tabla_Bakapp = 'Zw_ListaPreCosto' And Campo_Bakapp = '" & _Cabeza & "'"))

                                        If Not _Editar Then
                                            MessageBoxEx.Show(Me, "El campo " & _Cabeza & " no es equivalente a ningun campo en la tabla TABPP de Random",
                                                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        End If

                                    Case Else
                                        _Editar = True
                                End Select

                                If _Editar Then
                                    Grilla.Columns(_Cabeza).ReadOnly = False
                                    Grilla.BeginEdit(True)
                                End If

                            Else

                                Beep()

                            End If

                            e.SuppressKeyPress = False
                            e.Handled = True

                    End Select

                Case Keys.Space

                    If _Cabeza = "No_Usar" Then

                        e.SuppressKeyPress = False
                        e.Handled = True
                        Grilla.EndEdit()

                    End If

                Case Keys.Delete

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txt_Buscar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscar.KeyDown

        If e.KeyValue = Keys.Enter Then

            If Chk_Ver_Solo_Repetidos.Checked Then
                _Dv.RowFilter = String.Format("Codigo+CodAlternativo+Descripcion Like '%{0}%' And Repetido = 1", Txt_Buscar.Text.Trim)
            Else
                _Dv.RowFilter = String.Format("Codigo+CodAlternativo+Descripcion Like '%{0}%'", Txt_Buscar.Text.Trim)
            End If

            For Each _Fila As DataGridViewRow In Grilla.Rows

                Dim _Repetidos = _Fila.Cells("Repetidos").Value
                Dim _No_Usar = _Fila.Cells("No_Usar").Value

                If _Repetidos > 1 Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Purple
                End If

                If _No_Usar Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Red
                    _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                End If

            Next

        End If

    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        'Sb_Actualizar_Grilla(True)
        Sb_Actualizar_Grilla(True, True)
    End Sub

    Private Sub ChkMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcarTodo.CheckedChanged

        If Grilla.RowCount > 0 Then

            For Each row As DataGridViewRow In Grilla.Rows

                If Not row.IsNewRow Then
                    row.Cells("Select").Value = ChkMarcarTodo.Checked
                End If

            Next

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set [Select] = " & Convert.ToInt32(ChkMarcarTodo.Checked)
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Private Sub Btn_Levantamiento_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Levantamiento_Excel.Click

        Sb_Buscar_Archivo_e_Importar()

        System.Windows.Forms.Application.DoEvents()

        Btn_Cancelar.Visible = False
        Barrar_Menu.Enabled = True

        BtnOrdenarRegistros.Visible = True

        Barra_Progreso.Text = ""
        Barra_Progreso.Value = 0
        Barra_Progreso.Value = 0
        Barra_Progreso.Text = ""

    End Sub

    Private Sub Btn_Levantamiento_Ejemplo_Click(sender As Object, e As EventArgs) Handles Btn_Levantamiento_Ejemplo.Click

        Dim _Nom_Excel As String

        Consulta_sql = "SELECT 'Caracter [13]' as 'Código','Caracter [100]' as 'Descripción','Númerico' as CostoUd1," &
            "'Númerico' as CostoUd2,'Númerico' as Desc1,'Númerico' as Desc2,'Númerico' as Desc3,'Númerico' as Desc4," &
            "'Númerico' as Desc5,'Númerico' as Flete,'Caracter [2] (Ej: UD, CJ, ...)' as 'Unidad de compra'," &
            "'Númerico' as 'Cant. Mínimo de compra'"
        _Nom_Excel = "Ejemplo levantamiento costos"

        ExportarTabla_JetExcel(Consulta_sql, Me, _Nom_Excel)

    End Sub

    Private Sub Btn_Levantar_Desde_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Desde_Excel.Click
        ShowContextMenu(Menu_Contextual_Importar_Lista)
    End Sub

    Private Sub Grilla_ColumnSortModeChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles Grilla.ColumnSortModeChanged

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Repetidos = _Fila.Cells("Repetidos").Value
            Dim _No_Usar = _Fila.Cells("No_Usar").Value

            If _Repetidos > 1 Then
                _Fila.DefaultCellStyle.ForeColor = Color.Purple
            End If

            If _No_Usar Then
                _Fila.DefaultCellStyle.ForeColor = Color.Red
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

        Next

    End Sub

    Private Sub Grill0a_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.ColumnHeaderMouseClick

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Repetidos = _Fila.Cells("Repetidos").Value
            Dim _No_Usar = _Fila.Cells("No_Usar").Value

            If _Repetidos > 1 Then
                _Fila.DefaultCellStyle.ForeColor = Color.Purple
            End If

            If _No_Usar Then
                _Fila.DefaultCellStyle.ForeColor = Color.Red
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

        Next

    End Sub

    Private Sub Grilla_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grilla.CellFormatting

        Dim _Columname As String = Grilla.Columns(e.ColumnIndex).Name

        If _Columname.Contains("Select") Then

            Dim _Valor As Boolean = e.Value
            Dim _Color As Color
            If _Valor Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Color = Azul
                Else
                    _Color = Color.Blue
                End If
                Grilla.Rows(e.RowIndex).Cells("CostoUd1").Style.ForeColor = _Color
                Grilla.Rows(e.RowIndex).Cells("CostoUd2").Style.ForeColor = _Color
            End If

        End If

    End Sub

    Private Sub Chk_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla(True, True)
    End Sub

    Private Sub Btn_Actualizar_Lista_Random_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Lista_Random.Click

        Grilla.Refresh()

        Consulta_sql = "Select Id, Tabla_Random, Campo_Random, Tabla_Bakapp, Campo_Bakapp
                        From " & _Global_BaseBk & "Zw_Tablas_Equivalentes_Rd_Bk
                        Where Tabla_Bakapp = 'Zw_ListaPreCosto'"
        Dim _Tbl_Equivalentes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Sql_Equivalentes As String

        For Each _Fila As DataRow In _Tbl_Equivalentes.Rows

            Dim _Campo_Rd As String = _Fila.Item("Campo_Random")
            Dim _Campo_Bk As String = _Fila.Item("Campo_Bakapp")

            _Sql_Equivalentes += "," & _Campo_Rd & " = " & _Campo_Bk

        Next

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Set Vigente = 0 
                        Where Proveedor = '" & _CodProveedor & "' And Sucursal = '" & _SucProveedor & "' And Lista = '" & _CodLista & "'
                        Update " & _Global_BaseBk & "Zw_ListaPreCosto_Enc Set Vigente = 1,CodFuncionario_Activa = '" & FUNCIONARIO & "',FechaActivacionVigencia = Getdate()
                        Where Id = " & _Id_Padre & "
                        Insert Into TABRECPR (KOPR,RECARGO,KOEN,ECUARECAR,EMPRESA)
                        Select Codigo,Flete,Proveedor,'','" & ModEmpresa & "' From " & _Nombre_Tbl_Paso_Costos & " 
                        Where Codigo Not In (Select KOPR From TABRECPR Where KOEN = '" & _CodProveedor & "') And Flete > 0
                            
                        Update TABRECPR Set RECARGO = Flete 
                        From " & _Nombre_Tbl_Paso_Costos & " Tbp Inner Join TABRECPR On KOEN = Tbp.Proveedor And KOPR = Tbp.Codigo And No_Usar = 0
                                  
                        Update TABPRE Set PP01UD = CostoUd1,PP02UD = CostoUd2" & _Sql_Equivalentes & "
                        From " & _Nombre_Tbl_Paso_Costos & " Tbp Inner Join TABPRE On KOLT = Tbp.Lista And KOPR = Tbp.Codigo And No_Usar = 0"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            For Each _Fila As DataRow In _Ds.Tables(0).Rows
                _Fila.Item("Select") = False
            Next

            MessageBoxEx.Show(Me, FormatNumber(Grilla.RowCount, 0) & " Dato(s) actualizado(s) lista: " & _CodLista, "Actualizar Costos",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_ImportarFletes_Click(sender As Object, e As EventArgs) Handles Btn_ImportarFletes.Click

        Dim _Reg = _Sql.Fx_Cuenta_Registros("TABRECPR", "KOEN = '" & _CodProveedor & "'")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen datos que importar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set Flete = RECARGO,[Select] = 1
                        From " & _Nombre_Tbl_Paso_Costos & "
                        Inner Join TABRECPR On KOEN = Proveedor And KOPR = Codigo
                        Where Proveedor = '" & _CodProveedor & "'"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos importados correctamente", "Importar fletes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sb_Actualizar_Grilla(False, True)
        End If

    End Sub

    Private Sub Btn_ImportarPreciosOtraLista_Click(sender As Object, e As EventArgs) Handles Btn_ImportarPreciosOtraLista.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _RowListaSeleccionada As DataRow

        Dim _Id_Padre_Destino As Integer = _Fila.Cells("Id_Padre").Value

        Dim Fm As New Frm_MantCostosPrecios_LV(_RowProveedor, _CodLista)
        Fm.SoloSeleccionar = True
        Fm.SeleccionarYCerrar = True
        Fm.Id_Padre_Destino = _Id_Padre_Destino
        Fm.Btn_AgregarLista.Enabled = False
        Fm.ShowDialog(Me)
        _RowListaSeleccionada = Fm.RowListaSeleccionada
        Fm.Dispose()

        If Not IsNothing(_RowListaSeleccionada) Then

            Dim _Id_Padre_Origen As Integer = _RowListaSeleccionada.Item("Id")

            Sb_Importar_Costos_Desde_Otra_Lista(_Id_Padre_Origen)

        End If

    End Sub

    Sub Sb_Importar_Costos_Desde_Otra_Lista(_Id_Padre_Origen As Integer)

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Costos & " Set
	                    CostoUd1 = CSt.CostoUd1, 
	                    CostoUd2 = CSt.CostoUd2, 
	                    Desc1 = CSt.Desc1, 
	                    Desc2 = CSt.Desc2, 
	                    Desc3 = CSt.Desc3, 
	                    Desc4 = CSt.Desc4, 
	                    Desc5 = CSt.Desc5, 
	                    DescSuma = CSt.DescSuma, 
	                    Flete = CSt.Flete,
                        No_Usar = CSt.No_Usar,
                        [Select] = 1
                 From " & _Nombre_Tbl_Paso_Costos & " Paso
                 Left Join " & _Global_BaseBk & "Zw_ListaPreCosto CSt On Paso.Proveedor = CSt.Proveedor And Paso.Sucursal = CSt.Sucursal And Paso.Codigo = CSt.Codigo
                 Where CSt.Id_Padre = " & _Id_Padre_Origen

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Me.Sb_Actualizar_Grilla(False, True)
            MessageBoxEx.Show(Me, "Datos importados", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Chk_Ver_Solo_Repetidos_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Ver_Solo_Repetidos.CheckedChanged

        Dim _e As New KeyEventArgs(Keys.Enter)
        Call Txt_Buscar_KeyDown(Nothing, _e)

    End Sub

    Private Sub Btn_Mnu_ExportarExcelVistaActual_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_ExportarExcelVistaActual.Click

        Dim _RazonProveedor = _RowProveedor.Item("NOKOEN")
        Dim _NomArch As String = "Lista de costos " & _RazonProveedor

        Dim Tbl_Excel As DataTable
        Tbl_Excel = _Dv.Table

        ExportarTabla_JetExcel_Tabla(Tbl_Excel, Me, _NomArch.Trim)
    End Sub

    Private Sub Btn_Mnu_ExportarExcelTodo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_ExportarExcelTodo.Click

        Dim _RazonProveedor = _RowProveedor.Item("NOKOEN")
        Consulta_sql = "Select * From " & _Nombre_Tbl_Paso_Costos & vbCrLf &
                   "Where Codigo <> ''"
        Dim _NomArch As String = "Lista de costos " & _RazonProveedor

        Dim Tbl_Excel As DataTable
        Tbl_Excel = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(Tbl_Excel, Me, _NomArch.Trim)
    End Sub


End Class
