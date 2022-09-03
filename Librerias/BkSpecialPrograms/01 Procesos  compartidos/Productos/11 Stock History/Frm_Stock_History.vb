Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Stock_History

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos As DataTable


    Public Sub New(ByVal Tbl_Productos As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Tbl_Productos = Tbl_Productos
    End Sub

    Private Sub Frm_Stock_History_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Procesar.Click

        Dim _Contador = 0
        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = _Tbl_Productos.Rows.Count

        Dim _Codigo As String

        For Each _Fila_St As DataRow In _Tbl_Productos.Rows

            _Codigo = _Fila_St.Item("Codigo")

            Consulta_sql = "Select DISTINCT EMPRESA As Empresa,SULIDO AS Sucursal,BOSULIDO AS Bodega" & vbCrLf & _
                           "From MAEDDO WHERE KOPRCT = '" & _Codigo & "'"

            Dim _TblBodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila_Bod As DataRow In _TblBodegas.Rows

                Dim _Empresa = _Fila_Bod.Item("Empresa")
                Dim _Sucursal = _Fila_Bod.Item("Sucursal")
                Dim _Bodega = _Fila_Bod.Item("Bodega")

                Consulta_sql = "Select Top 1 FEEMLI From MAEDDO" & Space(1) & _
                               "Where TIDO in ('FCC','BLC','GRC','GRI','OCC','BLV','FCV') And KOPRCT = '" & _Codigo & "'" & vbCrLf & _
                               "And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf & _
                               "Order by FEEMLI"

                Dim _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
                Dim _Fecha_Nacimiento As Date
                Dim _Fecha_Actual As Date = FechaDelServidor()
                Dim _Un_Ano_Atras As Date = DateAdd(DateInterval.Year, -1, _Fecha_Actual)

                _Un_Ano_Atras = DateAdd(DateInterval.Month, -1, _Un_Ano_Atras)
                _Un_Ano_Atras = Primerdiadelmes(_Un_Ano_Atras)

                If CBool(_Tbl.Rows.Count) Then
                    _Fecha_Nacimiento = _Tbl.Rows(0).Item("FEEMLI")
                    If _Fecha_Nacimiento < _Un_Ano_Atras Then
                        _Fecha_Nacimiento = _Un_Ano_Atras
                    End If
                End If

                _Fecha_Nacimiento = FormatDateTime(_Fecha_Nacimiento, DateFormat.ShortDate)
                'Barra_Progreso_Quiebres_Stock.Value += 1
                'Barra_Progreso_Quiebres_Stock.Value = ((Barra_Progreso_Quiebres_Stock.Value * 100) / _Tbl_Productos.Rows.Count) 'Mas

                Dim _Dias = DateDiff(DateInterval.Day, _Fecha_Nacimiento, FechaDelServidor)
                Dim _Fecha As Date = _Fecha_Nacimiento

                Barra_Progreso_Quiebres_Stock.Value = 0
                Barra_Progreso_Quiebres_Stock.Maximum = _Dias

                Dim _SqlQuery = String.Empty

                Consulta_sql = "Select Distinct FEEMLI From MAEDDO" & vbCrLf & _
                               "Where KOPRCT = '" & _Codigo & "' And" & Space(1) & _
                               "FEEMLI between '" & _Fecha_Nacimiento & "' And '" & _Fecha_Actual & "'"

                Dim _Tbl_Movimientos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Dim _Dias_Movimiento As Integer = _Tbl_Movimientos.Rows.Count
                Dim _Contador_Dias_Movimiento = 0
                Dim _Feemli As Date

                If CBool(_Dias_Movimiento) Then
                    _Feemli = FormatDateTime(_Tbl_Movimientos.Rows(0).Item("FEEMLI"), DateFormat.ShortDate)
                End If

                Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

                Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
                Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
                Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
                Consulta_sql = Replace(Consulta_sql, "#@Codigo#", _Codigo)
                Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Nacimiento, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

                Dim _Row_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _StockUd1 As Double = _Row_Stock.Item("StockUd1")
                Dim _StockUd2 As Double = _Row_Stock.Item("StockUd2")

                For i = 1 To _Dias

                    System.Windows.Forms.Application.DoEvents()

                    If _Fecha = _Feemli Then

                        Dim _Fecha_Revision As Date = DateAdd(DateInterval.Day, -1, _Fecha)
                        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

                        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
                        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
                        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
                        Consulta_sql = Replace(Consulta_sql, "#@Codigo#", _Codigo)
                        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
                        Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

                        _Row_Stock = _Sql.Fx_Get_DataRow(Consulta_sql)

                        _StockUd1 = _Row_Stock.Item("StockUd1")
                        _StockUd2 = _Row_Stock.Item("StockUd2")

                        _Contador_Dias_Movimiento += 1
                        If _Contador_Dias_Movimiento < _Dias_Movimiento Then
                            _Feemli = _Tbl_Movimientos.Rows(_Contador_Dias_Movimiento).Item("FEEMLI")
                        End If

                    End If

                    Dim _Dia = Weekday(_Fecha)
                    Dim _Dia_Habil = 0
                    Dim _Dia_Sabado = 0
                    Dim _Dia_Domingo = 0

                    Select Case _Dia
                        Case 1
                            _Dia_Domingo = 1
                        Case 7
                            _Dia_Sabado = 1
                        Case Else
                            _Dia_Habil = 1
                    End Select

                    Dim _Fecha_Stock = Format(_Fecha, "yyyyMMdd")

                    _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_History (Empresa,Sucursal,Bodega," & _
                                 "Codigo,Fecha_Stock,StockUd1,StockUd2,Dia_Habil,Dia_Sabado,Dia_Domingo) Values " & _
                                 "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "'," & _
                                 "'" & _Fecha_Stock & "'," & _
                                 De_Num_a_Tx_01(_StockUd1, False, 5) & "," & _
                                 De_Num_a_Tx_01(_StockUd2, False, 5) & "," & _Dia_Habil & "," & _
                                 _Dia_Sabado & "," & _Dia_Domingo & ")"

                    _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

                    Barra_Progreso_Quiebres_Stock.Value = i

                Next

                _SqlQuery = "Delete " & _Global_BaseBk & "Zw_Prod_Stock_History Where Codigo = '" & _Codigo & "'" & vbCrLf & vbCrLf & _SqlQuery
                _Sql.Ej_consulta_IDU(_SqlQuery)

            Next

            _Contador += 1
            Progreso_Porc.Value = ((_Contador * 100) / _Tbl_Productos.Rows.Count) 'Mas
            Progreso_Cont.Value += 1

        Next


    End Sub

    Private Function Fx_Row_Stock() As DataRow

    End Function


End Class