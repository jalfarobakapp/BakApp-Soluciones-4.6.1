Imports DevComponents.DotNetBar
Imports System.Drawing.Drawing2D

Public Class Frm_Trazabilidad_documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private m_EnumeratedTypes As Hashtable

    Dim _Idmaeedo_Origen As Integer
    Dim _Idmaeddo_Padre As Integer

    Dim _Tbl_Documento As DataTable

    Dim _Nodo_Seleccionado As New DevComponents.Tree.Node
    Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt

    Public Sub New(New_Idmaeedo_Origen As Integer, New_Idmaeddo_Padre As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Idmaeedo_Origen = New_Idmaeedo_Origen
        _Idmaeddo_Padre = New_Idmaeddo_Padre

    End Sub

    Private Sub Frm_Trazabilidad_documento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        treeGX1.LayoutType = DevComponents.Tree.eNodeLayout.Map
        treeGX1.RecalcLayout()

        treeGX1.MapLayoutFlow = DevComponents.Tree.eMapFlow.TopToBottom
        treeGX1.RecalcLayout()
        treeGX1.Refresh()

        Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
        _Tbl_Documento = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Crear_Arbol_Origens()

        comboLayout.Items.AddRange(System.Enum.GetNames(GetType(DevComponents.Tree.eNodeLayout)))
        comboLayout.SelectedItem = "Map"

    End Sub

#Region "PROCEDIMIENTOS"

#Region "CREAR EL NODO PRINCIPAL POSTERIOR"



#End Region

#Region "CREAR EL NODO PRINCIPAL ORIGENES"

    Private Sub Sb_Crear_Arbol_Origens()

        m_EnumeratedTypes = New Hashtable
        treeGX1.BeginUpdate()
        treeGX1.Nodes.Clear()
        Try
            Dim _Nodo As DevComponents.Tree.Node = New DevComponents.Tree.Node

            Dim _Tido As String = _Tbl_Documento.Rows(0).Item("TIDO")
            Dim _Nudo As String = _Tbl_Documento.Rows(0).Item("NUDO")

            _Nodo.Text = "Traza de documento " & _Tido & "-" & _Nudo 'GetTypeName(rootType)
            _Nodo.Image = Lista_Imagenes_32.Images.Item(0)
            _Nodo.Expanded = True

            Fx_Estilo_Documento(_Nodo, _Tido)

            treeGX1.Nodes.Add(_Nodo)

            Sb_Crear_Nodos_Hijos_Documentos(_Tbl_Documento.Rows(0), _Nodo, Traza.Origen, "ORIGENES", , , False)

            ' CREA ARBOL CON DOCUMENTOS EXTERNOS
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEDDO",
            "IDRST IN  (SELECT IDMAEDDO FROM MAEDDO WHERE IDMAEEDO = " & _Idmaeedo_Origen & ") AND ARCHIRST = 'MAEDDO' ")

            If CBool(_Reg) Then
                Sb_Crear_Nodos_Hijos_Documentos(_Tbl_Documento.Rows(0), _Nodo, Traza.Posterior, "DOCUMENTOS POSTERIORES", , , False)
            End If

            Consulta_sql = "Select IDRVE,KOTABLA,KOCARAC,NOKOCARAC,ARCHIRSE,IDRSE" & vbCrLf &
                           "From MEVENTO" & vbCrLf &
                           "Where ARCHIRVE = 'MAEEDO' And IDRVE = " & _Idmaeedo_Origen & " And ARCHIRSE = 'MAEEDO' And IDRSE <> 0"

            Dim _TblMevento As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_TblMevento.Rows.Count) Then

                For Each _Fila As DataRow In _TblMevento.Rows

                    Dim _Idrse As Integer = _Fila.Item("IDRSE")

                    Dim _Kotabla As String = Trim(_Fila.Item("KOTABLA"))
                    Dim _Kocarac As String = Trim(_Fila.Item("KOCARAC"))
                    Dim _Nokocarac As String = Trim(_Fila.Item("NOKOCARAC"))

                    Dim _Nombre_Nodo As String = _Kotabla & " " & _Kocarac & " -> " & _Nokocarac

                    Sb_Crear_Nodos_Hijos_Documentos_Enlace_Externo_BakApp(_Nodo, _Nombre_Nodo, _Idrse)
                Next

            End If

            'CREAR ARBOL CON ORDENES DE TRABAJO
            _Reg = _Sql.Fx_Cuenta_Registros("POTLCOM",
            "ARCHIRST = 'MAEDDO' And IDRST In (Select IDMAEDDO From MAEDDO Where IDMAEEDO = " & _Idmaeedo_Origen & ")")

            If CBool(_Reg) Then
                Sb_Crear_Nodos_Hijos_Documentos(_Tbl_Documento.Rows(0), _Nodo, Traza.OrdenTrabajo, "ORDENES DE TRABAJO", , , False)
            End If


            ' CREA ARBOL CON PAGOS
            _Reg = _Sql.Fx_Cuenta_Registros("MAEDPCD", "ARCHIRST = 'MAEEDO' And IDRST = " & _Idmaeedo_Origen)
            If _Reg Then

                Consulta_sql = "SELECT MC.IDMAEDPCE,MC.EMPRESA,MC.TIDP,MC.NUDP,MC.ENDP,MC.VADP,MC.VAASDP,MC.VAVUDP,MC.REFANTI," &
                               "MC.FEEMDP,MC.HORAGRAB,MD.IDMAEDPCD,MD.ARCHIRST,MD.IDRST,MD.VAASDP AS VAASDPDET,MD.TIDOPA," &
                               "MD.FEASDP,MC.NUCUDP,MC.MODP" & vbCrLf &
                               "FROM MAEDPCD MD WITH ( NOLOCK ) INNER JOIN MAEDPCE MC ON MD.IDMAEDPCE = MC.IDMAEDPCE" & vbCrLf &
                               "WHERE IDRST = " & _Idmaeedo_Origen & " AND ARCHIRST = 'MAEEDO'"

                Dim _TblPago As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblPago.Rows.Count) Then

                    Dim _Nodo_Pagos As DevComponents.Tree.Node = New DevComponents.Tree.Node

                    _Nodo_Pagos.Image = Lista_Imagnes_Pago_16.Images.Item(8)
                    _Nodo_Pagos.Expanded = False
                    _Nodo.Nodes.Add(_Nodo_Pagos)

                    Dim _Control_Pago = New Control_Detalle_Pagos_X_Documento
                    _Control_Pago._Fila_pago = _Tbl_Documento.Rows(0)
                    _Control_Pago.Expanded = False
                    _Nodo_Pagos.HostedControl = _Control_Pago

                    For Each _Fila As DataRow In _TblPago.Rows
                        Sb_Crear_Nodos_Hijos_Pagos(_Fila, _Nodo_Pagos)
                    Next

                End If
            End If

        Finally
            treeGX1.EndUpdate()
        End Try
        m_EnumeratedTypes.Clear()

    End Sub

    Enum Traza
        Origen
        Posterior
        OrdenTrabajo
        ComprobanteContable
    End Enum

    Sub Sb_Crear_Nodos_Hijos_Documentos(_Fila As DataRow,
                                        _Nodo_Padre As DevComponents.Tree.Node,
                                        _Traza As Traza,
                                        _Nombre_Nodo As String,
                                        Optional _Desde_Detalle As Boolean = False,
                                        Optional _Idmaeddo_Origen As Integer = 0,
                                        Optional _Expandir As Boolean = True)


        Dim _Nodo As DevComponents.Tree.Node = New DevComponents.Tree.Node

        Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
        Dim _Tido As String = _Fila.Item("TIDO")
        Dim _Nudo As String = _Fila.Item("NUDO")

        If String.IsNullOrEmpty(_Nombre_Nodo) Then
            _Nodo.Text = _Tido & "-" & _Nudo
        Else
            _Nodo.Text = " " & _Nombre_Nodo
        End If

        _Nodo.Tag = _Traza '.ToString
        _Nodo.Image = Lista_Imagenes_32.Images.Item(0)

        If _Traza = Traza.OrdenTrabajo Then
            _Nodo.Image = Lista_Imagenes_32.Images.Item("Ordendetrabajo")
            Fx_Estilo_Documento(_Nodo, "B")
        Else
            Fx_Estilo_Documento(_Nodo, _Tido)
        End If

        _Nodo.Expanded = _Expandir

        Dim _Cell As New DevComponents.Tree.Cell

        _Cell.Name = _Idmaeedo
        '_Cell.Text = _Tido & "-" & _Nudo
        _Nodo.Cells.Add(_Cell)

        _Nodo.DragDropEnabled = False
        _Nodo_Padre.Nodes.Add(_Nodo)

        '
        If String.IsNullOrEmpty(_Nombre_Nodo) Then
            AddHandler _Nodo.NodeDoubleClick, AddressOf Sb_Node_Documento_DoubleClick
        End If

        If _Traza = Traza.Origen Then
            If _Desde_Detalle Then
                Consulta_sql = "Select * From MAEDDO Where IDMAEDDO = " & _Idmaeddo_Origen
            Else
                Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo
            End If
        End If

        'Consulta_sql = String.Empty

        If _Traza = Traza.Posterior Then
            If _Desde_Detalle Then
                Dim _Idmaeddo As Integer = _Fila.Item("IDMAEDDO")
                Consulta_sql = "Select * From MAEDDO Where IDMAEDDO = " & _Idmaeddo
            Else
                Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo
            End If
        End If

        If _Traza = Traza.OrdenTrabajo Then
            If _Desde_Detalle Then
                Return
                Dim _Idmaeddo As Integer = _Fila.Item("IDMAEDDO")
                Consulta_sql = "Select * From MAEDDO Where IDMAEDDO = " & _Idmaeddo
            Else
                Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & " And CAPRODCO > 0"
            End If
        End If

        Dim _TblDetalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Crear_Nodos_hijos_detalle_documento(_TblDetalle, _Nodo, _Traza) ' EN ESTA FUNCION PONER UNA OPCION PARA DOCUMENTOS PRINCIPALES

    End Sub

    Sub Sb_Crear_Nodos_Hijos_Documentos_Enlace_Externo_BakApp(_Nodo_Padre As DevComponents.Tree.Node,
                                                              _Nombre_Nodo As String,
                                                              _Idrse As Integer)


        Dim _Nodo As DevComponents.Tree.Node = New DevComponents.Tree.Node

        Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _Idrse
        Dim _TblDocReferencia As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _TblDocReferencia.Rows.Count Then

            Dim _Fila As DataRow = _TblDocReferencia.Rows(0)
            Dim _Tido As String = _Fila.Item("TIDO")
            Dim _Nudo As String = _Fila.Item("NUDO")

            _Nodo.Text = _Nombre_Nodo

            _Nodo.Image = Lista_Imagenes_32.Images.Item(0)
            _Nodo.Expanded = False ' Lo dejamos oculto

            Dim _Cell As New DevComponents.Tree.Cell

            _Cell.Name = _Idrse

            _Nodo.Cells.Add(_Cell)
            _Nodo.Style = styleClass
            _Nodo.DragDropEnabled = False
            _Nodo_Padre.Nodes.Add(_Nodo)

            AddHandler _Nodo.NodeDoubleClick, AddressOf Sb_Node_Documento_DoubleClick

            Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idrse
            Dim _TblDetalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Sb_Crear_Nodos_hijos_detalle_documento(_TblDetalle, _Nodo, Traza.Origen) ' EN ESTA FUNCION PONER UNA OPCION PARA DOCUMENTOS PRINCIPALES

        End If

    End Sub

    Sub Sb_Crear_Nodos_Hijos_Pagos(_Fila As DataRow,
                                   _Nodo_Padre As DevComponents.Tree.Node)


        Dim _Nodo As DevComponents.Tree.Node = New DevComponents.Tree.Node
        Dim _Idmaedpcd As String = _Fila.Item("IDMAEDPCD")
        Dim _Idmaedpce As String = _Fila.Item("IDMAEDPCE")

        Dim _Tidp As String = _Fila.Item("TIDP")
        Dim _Vadp As String = _Fila.Item("VADP")     ' Valor documento de pago
        Dim _Vaasdp As String = _Fila.Item("VAASDP") ' Valor asignado
        Dim _Vavudp As String = _Fila.Item("VAVUDP") ' Valor vuelto
        Dim _Refanti As String = _Fila.Item("REFANTI")

        Dim _Nombre As String

        Select Case _Tidp.ToString
            Case "EFV", "EFC"
                _Nombre = "EFECTIVO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(0)
            Case "TJV", "TJC"
                _Nombre = "TARJETA"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(2)
            Case "CHV", "CHC"
                _Nombre = "CHEQUE"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(1)
            Case "LTV", "LTC"
                _Nombre = "LETRA"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(4)
            Case "PAV", "PAC"
                _Nombre = "PAGARE DE CREDITO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(4)
            Case "DEP"
                _Nombre = "PAGO POR DEPOSITO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(6)
            Case "ATB", "PTB"
                _Nombre = "TRANSFERENCIA BANCARIA"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(3)
            Case "ncv", "ncc", "ncx", "nev", "blv", "fcv", "fcc"
                _Nombre = String.Empty
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(5)
            Case Else
                _Nombre = "OTRA FORMA DE PAGO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(7)
        End Select


        _Nodo.Name = _Idmaedpcd
        _Nodo.Expanded = False

        Dim _Idmaaedo_pago = 0

        If _Tidp = "ncv" Or _Tidp = "ncc" Or _Tidp = "ncx" Or _Tidp = "nev" Or _Tidp = "blv" Or _Tidp = "fcv" Or _Tidp = "fcc" Then

            Dim _Nota = Split(_Refanti, "-")

            _Idmaaedo_pago = _Sql.Fx_Trae_Dato("MAEEDO", "IDMAEEDO",
                                                 "TIDO = '" & _Nota(0) & "' And NUDO = '" & _Nota(1) & "'", True)

            _Nombre = "DOCUMENTO (" & _Nota(0) & "-" & _Nota(1) & ")"

        End If

        _Nombre = "DOCUMENTO DE PAGO"

        Dim _Control_Pago = New Control_Pago
        _Control_Pago._Documento = _Nombre
        _Control_Pago._Fila_pago = _Fila
        _Control_Pago.Expanded = True
        _Control_Pago._Idmaeedo = _Idmaaedo_pago
        _Nodo.HostedControl = _Control_Pago

        _Nodo.Style = styleClass
        _Nodo.DragDropEnabled = False
        _Nodo_Padre.Nodes.Add(_Nodo)


        Consulta_sql = "SELECT *,ISNULL((SELECT TOP 1 CASE WHEN TD.TIDPEN IN ('CH','TJ') THEN NOKOENDP ELSE '' END " &
                       "FROM TABENDP TD WHERE TD.KOENDP =  MDC.EMDP ),'') AS BANCO" & vbCrLf &
                       "FROM MAEDPCE MDC WHERE IDMAEDPCE = " & _Idmaedpce

        Dim _TblDocPago As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblDocPago.Rows.Count) Then
            Sb_Crear_Nodos_Hijos_Pagos_Documentos(_TblDocPago.Rows(0), _Nodo)
        End If

    End Sub

    Sub Sb_Crear_Nodos_Hijos_Pagos_Documentos(_Fila As DataRow,
                                              _Nodo_Padre As DevComponents.Tree.Node)


        Dim _Nodo As DevComponents.Tree.Node = New DevComponents.Tree.Node

        Dim _Idmaedpce As String = _Fila.Item("IDMAEDPCE")

        Dim _Tidp As String = _Fila.Item("TIDP")

        Dim _Nombre As String

        Select Case _Tidp.ToString
            Case "EFV", "EFC"
                _Nombre = "EFECTIVO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(0)
            Case "TJV"
                _Nombre = "TARJETA"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(2)
            Case "CHV", "CHC"
                _Nombre = "CHEQUE"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(1)
            Case "LTV"
                _Nombre = "LETRA"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(4)
            Case "PAV"
                _Nombre = "PAGARE DE CREDITO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(4)
            Case "DEP"
                _Nombre = "PAGO POR DEPOSITO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(6)
            Case "ATB", "PTB"
                _Nombre = "TRANSFERENCIA BANCARIA"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(3)
            Case "ncv", "ncc", "ncx", "nev", "blv", "fcv", "fcc"
                _Nombre = "CRUCE DE DOCUMENTO" 'String.Empty
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(5)
            Case Else
                _Nombre = "OTRA FORMA DE PAGO"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(7)
        End Select

        _Nodo.Name = _Idmaedpce
        _Nodo.Expanded = False

        Dim _Control_Pago = New Control_Documento_Pago
        _Control_Pago._Documento = _Nombre
        _Control_Pago._Fila_pago = _Fila
        _Control_Pago.Expanded = False
        _Nodo.HostedControl = _Control_Pago

        _Nodo.Style = styleClass
        _Nodo.DragDropEnabled = False
        _Nodo_Padre.Nodes.Add(_Nodo)


        Consulta_sql = "SELECT TOP 20 MAEDPCD.*,MAEEDO.EMPRESA,MAEEDO.TIDO,MAEEDO.NUDO,MAEEDO.ENDO" & vbCrLf &
                       "FROM MAEDPCD LEFT OUTER JOIN MAEEDO ON MAEEDO.IDMAEEDO=MAEDPCD.IDRST AND MAEDPCD.ARCHIRST ='MAEEDO'" & vbCrLf &
                       "WHERE MAEDPCD.IDMAEDPCE= " & _Idmaedpce & "  ORDER BY IDMAEDPCD  OPTION ( FAST 20 )"

        Dim _TblDocPagados As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblDocPagados.Rows.Count) Then
            For Each _Documento As DataRow In _TblDocPagados.Rows
                If _Documento.Item("ARCHIRST").ToString.Trim = "MAEEDO" Then
                    Sb_Crear_Nodos_Hijos_Pagos_Documentos_Pagados(_Documento, _Nodo)
                End If
            Next
        End If

    End Sub

    Sub Sb_Crear_Nodos_Hijos_Pagos_Documentos_Pagados(_Fila As DataRow,
                                                      _Nodo_Padre As DevComponents.Tree.Node)


        Dim _Nodo As DevComponents.Tree.Node = New DevComponents.Tree.Node

        Dim _Idmaedpce As String = _Fila.Item("IDMAEDPCE")
        Dim _Tidp As String = _Sql.Fx_Trae_Dato("MAEDPCE", "TIDP", "IDMAEDPCE = " & _Idmaedpce)

        Dim _Tido As String = NuloPorNro(_Fila.Item("TIDO"), "")
        Dim _Nudo As String = NuloPorNro(_Fila.Item("NUDO"), "")

        Dim _Nombre As String = _Tido & "-" & _Nudo

        Fx_Estilo_Documento(_Nodo, _Tido)

        Select Case _Tidp.ToString
            Case "EFV", "EFC"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(0)
            Case "TJV"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(2)
            Case "CHV", "CHC"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(1)
            Case "LTV"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(4)
            Case "PAV"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(4)
            Case "DEP"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(6)
            Case "ATB", "PTB"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(3)
            Case "ncv", "ncc", "ncx", "nev", "blv", "fcv", "fcc"
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(5)
            Case Else
                _Nodo.Image = Lista_Imagnes_Pago_16.Images.Item(7)
        End Select

        _Nodo.Name = _Idmaedpce
        _Nodo.Expanded = False

        Dim _Control_Pago = New Control_Documento_Pagado
        _Control_Pago._Documento = _Nombre
        _Control_Pago._Fila_pago = _Fila
        _Control_Pago.Expanded = True
        _Nodo.HostedControl = _Control_Pago

        _Nodo.Style = styleClass
        _Nodo.DragDropEnabled = False
        _Nodo_Padre.Nodes.Add(_Nodo)

    End Sub

#End Region

#Region "CREAR NODOS HIJOS"

    Sub Sb_Crear_Nodos_hijos_detalle_documento(_TblDetalle As DataTable,
                                               _Nodo_Padre As DevComponents.Tree.Node,
                                               _Traza As Traza)

        For Each _Fila As DataRow In _TblDetalle.Rows

            Dim _Nodo As DevComponents.Tree.Node = New DevComponents.Tree.Node

            Dim _Idmaeddo As String = _Fila.Item("IDMAEDDO")

            Dim _Archirst As String = NuloPorNro(_Fila.Item("ARCHIRST"), 0)
            Dim _Idrst As Integer = NuloPorNro(_Fila.Item("IDRST"), 0)

            Dim _Tido As String = _Fila.Item("TIDO")
            Dim _Nudo As String = _Fila.Item("NUDO")
            Dim _Koprct As String = Trim(_Fila.Item("KOPRCT"))
            Dim _Nokopr As String = Trim(_Fila.Item("NOKOPR"))

            Dim _Udtrpr As Integer = Trim(_Fila.Item("UDTRPR"))
            Dim _Unidad As String
            Dim _Cantidad As String
            Dim _Eslido As String = Trim(_Fila.Item("ESLIDO"))

            If _Udtrpr = 2 Then
                _Unidad = Trim(_Fila.Item("UD02PR"))
                _Cantidad = Trim(_Fila.Item("CAPRCO2"))
            Else
                _Unidad = Trim(_Fila.Item("UD01PR"))
                _Cantidad = Trim(_Fila.Item("CAPRCO1"))
            End If

            Dim _Nombre As String = _Koprct

            Dim _Cell As New DevComponents.Tree.Cell

            _Cell = New DevComponents.Tree.Cell
            _Cell.Name = _Eslido

            If _Eslido = "C" Then
                _Cell.Images.Image = Lista_Imagenes_16.Images.Item(4)
            Else
                _Cell.Images.Image = Lista_Imagenes_16.Images.Item(5)
            End If
            _Nodo.Cells.Add(_Cell)

            If _Traza = Traza.Origen Then
                _Nodo.Image = Lista_Imagenes_16.Images.Item(2)
            ElseIf _Traza = Traza.Posterior Then
                _Nodo.Image = Lista_Imagenes_16.Images.Item(3)
            ElseIf _Traza = Traza.OrdenTrabajo Then

            End If


            Dim _Control_Producto = New Control_Producto
            _Control_Producto._Documento = _Nombre
            _Control_Producto._Fila_Producto = _Fila
            _Control_Producto.Expanded = False
            _Control_Producto.Formulario = Me
            _Nodo.HostedControl = _Control_Producto

            _Nodo.Expanded = True
            _Nodo.DragDropEnabled = False

            Dim _SinOrigen As Boolean

            If _Traza = Traza.Origen Then
                If CBool(_Idrst) Then
                    Consulta_sql = "Select * From MAEDDO Where IDMAEDDO = " & _Idrst
                Else
                    Consulta_sql = "Select * From MAEDDO Where IDMAEDDO = " & _Idmaeddo
                    _SinOrigen = True
                End If
            End If

            If _Traza = Traza.Posterior Then
                Consulta_sql = "Select * From MAEDDO Where ARCHIRST = 'MAEDDO' And IDRST = " & _Idmaeddo
            End If

            If _Traza = Traza.OrdenTrabajo Then
                Consulta_sql = "Select Pdoc.*,Potl.IDPOTE,'OTD' As TIDO,Pdoc.NUMOT As 'NUDO',Potl.IDPOTE As 'IDMAEEDO'" & vbCrLf &
                               "From POTLCOM Pdoc Left Join POTL Potl On Pdoc.IDPOTL = Potl.IDPOTL" & vbCrLf &
                               "Where ARCHIRST = 'MAEDDO' And IDRST = " & _Idmaeddo
            End If

            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then

                _Nodo_Padre.Nodes.Add(_Nodo)
                If Not _SinOrigen Then
                    If _Traza = Traza.Origen Then
                        Sb_Crear_Nodos_Hijos_Documentos(_Tbl.Rows(0), _Nodo, _Traza, "", True, _Idrst)
                    ElseIf _Traza = Traza.Posterior Then
                        For Each _Fila_posteriores As DataRow In _Tbl.Rows
                            Sb_Crear_Nodos_Hijos_Documentos(_Fila_posteriores, _Nodo, _Traza, "", True, _Idmaeddo)
                        Next
                    ElseIf _Traza = Traza.OrdenTrabajo Then
                        For Each _Fila_posteriores As DataRow In _Tbl.Rows
                            Sb_Crear_Nodos_Hijos_Documentos(_Fila_posteriores, _Nodo, _Traza, "", True, _Idmaeddo)
                        Next
                    End If
                End If
            End If

        Next

    End Sub

#End Region

    Private Function GetTypeName(type As Type) As String
        Return type.Name
    End Function

#End Region

    Private Sub trackBar1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles trackBar1.ValueChanged
        treeGX1.Zoom = trackBar1.Value / 100
        labelZoom.Text = trackBar1.Value.ToString() + "%"
    End Sub

    Private Sub comboLayout_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comboLayout.SelectedIndexChanged
        comboLayoutType.Items.Clear()

        If comboLayout.SelectedItem Is Nothing Then Exit Sub

        Dim layout As DevComponents.Tree.eNodeLayout = CType(System.Enum.Parse(GetType(DevComponents.Tree.eNodeLayout), comboLayout.SelectedItem.ToString()), DevComponents.Tree.eNodeLayout)

        If treeGX1.LayoutType <> layout Then
            treeGX1.LayoutType = layout
            treeGX1.RecalcLayout()
        End If

        If layout = DevComponents.Tree.eNodeLayout.Map Then
            comboLayoutType.Items.AddRange(System.Enum.GetNames(GetType(DevComponents.Tree.eMapFlow)))
            comboLayoutType.SelectedItem = treeGX1.MapLayoutFlow.ToString()
        ElseIf layout = DevComponents.Tree.eNodeLayout.Diagram Then
            comboLayoutType.Items.AddRange(System.Enum.GetNames(GetType(DevComponents.Tree.eDiagramFlow)))
            comboLayoutType.SelectedItem = treeGX1.DiagramLayoutFlow.ToString()
        End If
    End Sub

    Private Sub buttonPrint_Click(sender As System.Object, e As System.EventArgs) Handles buttonPrint.Click
        printPreviewDialog1.Bounds = Me.Bounds
        printPreviewDialog1.ShowDialog()
    End Sub

    Private Sub button1_Click(sender As System.Object, e As System.EventArgs) Handles button1.Click
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim bmp As Bitmap = New Bitmap(treeGX1.TreeSize.Width, treeGX1.TreeSize.Height)
            Dim g As Graphics = Graphics.FromImage(bmp)
            ' Perform actual rendering
            treeGX1.PaintTo(g, True, Rectangle.Empty)
            g.Dispose()
            bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
            bmp.Dispose()
        End If
    End Sub

    Private Sub comboLayoutType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comboLayoutType.SelectedIndexChanged
        If comboLayoutType.SelectedItem Is Nothing Or comboLayout.SelectedItem Is Nothing Then Exit Sub

        Dim layout As DevComponents.Tree.eNodeLayout = CType(System.Enum.Parse(GetType(DevComponents.Tree.eNodeLayout), comboLayout.SelectedItem.ToString()), DevComponents.Tree.eNodeLayout)
        If layout = DevComponents.Tree.eNodeLayout.Map Then
            Dim mapFlow As DevComponents.Tree.eMapFlow = CType(System.Enum.Parse(GetType(DevComponents.Tree.eMapFlow), comboLayoutType.SelectedItem.ToString()), DevComponents.Tree.eMapFlow)
            If treeGX1.MapLayoutFlow <> mapFlow Then

                treeGX1.MapLayoutFlow = mapFlow
                treeGX1.RecalcLayout()
                treeGX1.Refresh()
            End If
        ElseIf layout = DevComponents.Tree.eNodeLayout.Diagram Then
            Dim diagramFlow As DevComponents.Tree.eDiagramFlow = CType(System.Enum.Parse(GetType(DevComponents.Tree.eDiagramFlow), comboLayoutType.SelectedItem.ToString()), DevComponents.Tree.eDiagramFlow)
            If treeGX1.DiagramLayoutFlow <> diagramFlow Then
                treeGX1.DiagramLayoutFlow = diagramFlow
                treeGX1.RecalcLayout()
                treeGX1.Refresh()
            End If
        End If
    End Sub

    Private Sub printDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles printDocument1.PrintPage
        ' Center tree on the page
        Dim p As Point = New Point((e.PageBounds.Width - treeGX1.TreeSize.Width) / 2, (e.PageBounds.Height - treeGX1.TreeSize.Height) / 2)
        If p.X > 0 And p.Y > 0 Then
            e.Graphics.TranslateTransform(p.X, p.Y, MatrixOrder.Append)
        End If

        ' Perform actual rendering
        treeGX1.PaintTo(e.Graphics, False, e.PageBounds)
    End Sub

    Sub Sb_Node_Documento_DoubleClick(sender As System.Object, e As System.EventArgs)

        _Nodo_Seleccionado = CType(sender, DevComponents.Tree.Node)

        Dim _Celda = _Nodo_Seleccionado.Cells(1)
        Dim _Idmaeedo = _Nodo_Seleccionado.Cells(1).Name

        Dim _Traza As Traza = sender.tag

        If _Traza = Traza.OrdenTrabajo Then

            Dim _Numot As String = _Sql.Fx_Trae_Dato("POTE", "NUMOT", "IDPOTE = " & _Idmaeedo)

            Dim Fm As New Frm_Inf_Prod_Avance_OT
            Fm.Pro_Numot = _Numot
            Fm.WindowState = FormWindowState.Normal
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Sb_Node_Documento_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            _Nodo_Seleccionado = CType(sender, DevComponents.Tree.Node)
            ShowContextMenu(Menu_Contextual_Encabezado)
        End If
    End Sub

    Private Sub Btn_Ver_documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_documento.Click

        Dim _Idmaeedo = _Nodo_Seleccionado.Cells(1).Name

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs)
        Dim _Codigo As String = _Nodo_Seleccionado.Cells(2).Name
        Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
    End Sub

    Private Sub Btn_Anotaciones_a_la_linea_Click(sender As System.Object, e As System.EventArgs)

        Dim _Celda = _Nodo_Seleccionado.Cells(2)
        Dim _Idmaeddo = _Nodo_Seleccionado.Cells(1).Name

        Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Idmaeddo, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEDDO)
        Fm.ShowDialog(Me)

        Fm.Dispose()

    End Sub

    Enum Estilo_Nodo
        Blue
        Yellow
        Green
        Red
        Purple
        Cyan
        Orange
        Magenta
        Tan
        Lemon
        Apple
        Silver
        Gray
    End Enum

    Function Fx_Estilo_Tree(_Estilo_Nodo As Estilo_Nodo) As DevComponents.Tree.ElementStyle

        Select Case _Estilo_Nodo

            Case Estilo_Nodo.Blue
                Return ElementStyle1
            Case Estilo_Nodo.Yellow
                Return ElementStyle2
            Case Estilo_Nodo.Green
                Return ElementStyle3
            Case Estilo_Nodo.Red
                Return ElementStyle4
            Case Estilo_Nodo.Purple
                Return ElementStyle5
            Case Estilo_Nodo.Cyan
                Return ElementStyle6
            Case Estilo_Nodo.Orange
                Return ElementStyle7
            Case Estilo_Nodo.Magenta
                Return ElementStyle8
            Case Estilo_Nodo.Tan
                Return ElementStyle9
            Case Estilo_Nodo.Lemon
                Return ElementStyle10
            Case Estilo_Nodo.Apple
                Return ElementStyle11
            Case Estilo_Nodo.Silver
                Return ElementStyle12
            Case Estilo_Nodo.Gray
                Return ElementStyle13

        End Select

    End Function

    Function Fx_Estilo_Documento(_Nodo As DevComponents.Tree.Node, _Tido As String)

        Select Case Mid(_Tido, 1, 1)

            Case "B"
                _Nodo.Style = Fx_Estilo_Tree(Estilo_Nodo.Blue)
            Case "F"
                _Nodo.Style = Fx_Estilo_Tree(Estilo_Nodo.Yellow)
            Case "G"
                _Nodo.Style = Fx_Estilo_Tree(Estilo_Nodo.Green)
            Case "N"
                _Nodo.Style = Fx_Estilo_Tree(Estilo_Nodo.Red)
            Case "O"
                _Nodo.Style = Fx_Estilo_Tree(Estilo_Nodo.Orange)
            Case "C"
                _Nodo.Style = Fx_Estilo_Tree(Estilo_Nodo.Silver)

        End Select

    End Function

End Class
