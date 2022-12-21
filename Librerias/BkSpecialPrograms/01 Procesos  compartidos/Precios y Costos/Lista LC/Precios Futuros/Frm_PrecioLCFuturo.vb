Imports DevComponents.DotNetBar

Public Class Frm_PrecioLCFuturo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Grabar As Boolean
    Public Property ListaPrecios As New DataTable
    Public Property CodProducto As String
    Public Property IdListaProgramada As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Sb_Formato_Generico_Grilla(GrillaListasProgramadas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, False, False, False)
        Sb_Formato_Generico_Grilla(GrillaPrecios, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, False, False, False)

    End Sub

    Private Sub Frm_PrecioLCFuturo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Grabar Then
            GrillaPrecios.DataSource = ListaPrecios
            FormatoGrilla(GrillaPrecios)
            Txtcodigo.Text = CodProducto
            LlenarListasProgramadas(False)
        Else
            'ButtonX4.Visible = True
            ButtonX3.Visible = True
            ButtonX1.Visible = True
            LlenarListasProgramadas(False)
        End If

    End Sub

    Private Function FormatoGrilla(ByVal Grilla As DataGridView)

        'Lista, NombreLista, Codigo, PrecioUd1,PrecioUd2,Rtu, MargenPorc, VarMcosto,VarPm, 
        'VarUc, VarFlete, VarIva, VarIla,VarNetoDigit,VarValorDigit

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            '.Columns("Accion").Visible = False

            .Columns("Lista").Width = 40
            .Columns("Lista").HeaderText = "Lista"
            .Columns("Lista").Visible = True
            .Columns("Lista").ReadOnly = True

            .Columns("NombreLista").Width = 300
            .Columns("NombreLista").HeaderText = "Descripción lista"
            .Columns("NombreLista").Visible = True
            .Columns("NombreLista").ReadOnly = True

            .Columns("PrecioUd1").Width = 100
            .Columns("PrecioUd1").HeaderText = "Precio Ud1"
            .Columns("PrecioUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioUd1").Visible = True

            .Columns("MargenPorc").Width = 100
            .Columns("MargenPorc").HeaderText = "Margen %"
            .Columns("MargenPorc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("MargenPorc").Visible = True

            .Columns("PrecioUd2").Width = 100
            .Columns("PrecioUd2").HeaderText = "Precio Ud2"
            .Columns("PrecioUd2").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioUd2").Visible = True

            '.Columns("Brutolinea").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("Brutolinea").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'TotalNeto = Math.Round(Val(SumarDatodeGrilla("Netolinea", Grilla)), 2)
            'TotalIva = Math.Round(TotalNeto * 0.19, 0)


            .Refresh()

        End With

    End Function
    Private Sub LlenarListasProgramadas(todas As Boolean)

        If Not todas Then
            If Grabar Then
                Consulta_sql = "Select * From " & _Global_BaseBk & "[Zw_ListaLC_Programadas]" & vbCrLf &
                               "Where Producto='" & Txtcodigo.Text & "' And Funcionario='" & FUNCIONARIO & "' And FechaProgramada > '" & Now.ToString("yyyy-MM-ddT00:00:00") & "';"
            Else
                Consulta_sql = "Select * From " & _Global_BaseBk & "[Zw_ListaLC_Programadas]" & vbCrLf &
                               "Where Funcionario='" & FUNCIONARIO & "' And FechaRegistro > '" & Now.ToString("yyyy-MM-ddT00:00:00") & "';;"
            End If
        Else
            Consulta_sql = "Select * From " & _Global_BaseBk & "[Zw_ListaLC_Programadas]" & vbCrLf &
                           "Where FechaRegistro > '" & Now.ToString("yyyy-MM-ddT00:00:00") & "';;"


        End If

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        GrillaListasProgramadas.DataSource = _Tbl

        OcultarEncabezadoGrilla(GrillaListasProgramadas, True)

        Dim _DisplayIndex = 0

        With GrillaListasProgramadas

            .Columns("Producto").Width = 100
            .Columns("Producto").HeaderText = "Producto"
            '.Columns("Producto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Producto").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Producto").Visible = True
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaRegistro").Width = 80
            .Columns("FechaRegistro").HeaderText = "Fecha. Reg."
            .Columns("FechaRegistro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaRegistro").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaRegistro").Visible = True
            .Columns("FechaRegistro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaProgramada").Width = 80
            .Columns("FechaProgramada").HeaderText = "Fecha. Prog."
            .Columns("FechaProgramada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaProgramada").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaProgramada").Visible = True
            .Columns("FechaProgramada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Aplicado").Width = 80
            .Columns("Aplicado").HeaderText = "Aplicado"
            .Columns("Aplicado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Aplicado").Visible = True
            .Columns("Aplicado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Funcionario").Width = 80
            .Columns("Funcionario").HeaderText = "Funcionario"
            .Columns("Funcionario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Funcionario").Visible = True
            .Columns("Funcionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub LlenarListasPrecios()
        Consulta_sql = "SELECT *  FROM " & _Global_BaseBk & "[Zw_ListaLC_Programadas_Detalles] WHERE Id_Enc='" & IdListaProgramada & "';"
        GrillaPrecios.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        FormatoGrilla(GrillaPrecios)
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        GuardarListaProgramada()
    End Sub
    Function ConsultarFecha(fecha As String) As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "[Zw_ListaLC_Programadas]" & vbCrLf &
                       "Where [Producto]='" & Txtcodigo.Text & "' And FechaProgramada='" & fecha & "';"
        Dim Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        If Ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub GuardarListaProgramada()

        Dim dlg As System.Windows.Forms.DialogResult =
        MessageBoxEx.Show(Me, "¿Esta seguro de programar la actuualizacion de los valores?",
                          "Guardar Programado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlg = System.Windows.Forms.DialogResult.Yes Then
            If ConsultarFecha(FechaProgramada.Value.ToString("yyyy-MM-ddT00:00:00")) = True Then
                MessageBoxEx.Show(Me, "Ya hay una lista programada para esta fecha.",
                          "Guardar Programado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql = "Declare @Id_Enc Int" & vbCrLf & vbCrLf &
                "Insert Into " & _Global_BaseBk & "[Zw_ListaLC_Programadas]
           ([Producto]
           ,[FechaRegistro]
           ,[FechaProgramada]
           ,[Aplicado],[Funcionario],[Activo])
     Values
           ('" & Txtcodigo.Text & "'
           ,'" & Now.ToString("yyyy-MM-ddTHH:mm:ss") & "'
           ,'" & FechaProgramada.Value.ToString("yyyy-MM-ddT00:00:00") & "'
           ,0,'" & FUNCIONARIO & "','1')" & vbCrLf &
           "Set Id_Enc = (SELECT @@IDENTITY AS Id)" & vbCrLf & vbCrLf &
           "--;DECLARE @Id_Enc AS int;SET @Id_Enc = (SELECT SCOPE_IDENTITY());
"
            For Each _Row As DataGridViewRow In GrillaPrecios.Rows

                Dim _Lista As String = _Row.Cells("Lista").Value
                Dim _NombreLista As String = _Row.Cells("NombreLista").Value
                Dim _Codigo As String = _Row.Cells("Codigo").Value
                Dim _PrecioUd1 As String = De_Num_a_Tx_01(_Row.Cells("PrecioUd1").Value, False, 5)
                Dim _PrecioUd2 As String = De_Num_a_Tx_01(_Row.Cells("PrecioUd2").Value, False, 5)
                Dim _EcuacionUd1 As String = _Row.Cells("EcuacionUd1").Value
                Dim _EcuacionUd2 As String = _Row.Cells("EcuacionUd2").Value
                Dim _Rtu As String = De_Num_a_Tx_01(_Row.Cells("Rtu").Value, False, 5)
                Dim _MargenPorc As String = De_Num_a_Tx_01(_Row.Cells("MargenPorc").Value, False, 5)
                Dim _VarMcosto As String = De_Num_a_Tx_01(_Row.Cells("VarMcosto").Value, False, 5)
                Dim _VarPm As String = De_Num_a_Tx_01(_Row.Cells("VarPm").Value, False, 5)
                Dim _VarUc As String = De_Num_a_Tx_01(_Row.Cells("VarUc").Value, False, 5)
                Dim _VarFlete As String = De_Num_a_Tx_01(_Row.Cells("VarFlete").Value, False, 5)
                Dim _VarIva As String = De_Num_a_Tx_01(_Row.Cells("VarIva").Value, False, 5)
                Dim _VarIla As String = De_Num_a_Tx_01(_Row.Cells("VarIla").Value, False, 5)
                Dim _VarNetoDigit As String = De_Num_a_Tx_01(_Row.Cells("VarNetoDigit").Value, False, 5)
                Dim _VarValorDigit As String = De_Num_a_Tx_01(_Row.Cells("VarValorDigit").Value, False, 5)


                Consulta_sql += "Insert Into " & _Global_BaseBk & "[Zw_ListaLC_Programadas_Detalles]
           ([Id_Enc]
           ,[Lista]
           ,[NombreLista]
           ,[Codigo]
           ,[PrecioUd1]
           ,[PrecioUd2]
           ,[EcuacionUd1]
           ,[EcuacionUd2]
           ,[Rtu]
           ,[MargenPorc]
           ,[VarMcosto]
           ,[VarPm]
           ,[VarUc]
           ,[VarFlete]
           ,[VarIva]
           ,[VarIla]
           ,[VarNetoDigit]
           ,[VarValorDigit])
     Values
           (@Id_Enc
           ,'" & _Lista & "'
           ,'" & _NombreLista & "'
           ,'" & _Codigo & "'
           ," & _PrecioUd1 & "
           ," & _PrecioUd2 & "
           ,'" & _EcuacionUd1 & "'
           ,'" & _EcuacionUd2 & "'
           ," & _Rtu & "
           ," & _MargenPorc & "
           ," & _VarMcosto & "
           ," & _VarPm & "
           ," & _VarUc & "
           ," & _VarFlete & "
           ," & _VarIva & "
           ," & _VarIla & "
           ," & _VarNetoDigit & "
           ," & _VarValorDigit & ");
"
            Next

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Actualizacion de Precios Programada Correctamente", "Grabar Precios Programado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                LlenarListasProgramadas(False)
                GrillaPrecios.DataSource = Nothing
            End If

        End If

    End Sub

    Private Sub ActualizarListaProgramada()

        If MessageBoxEx.Show(Me, "¿Esta seguro de Actualizar la lista programada?",
                          "Actualizar Programado", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

            If ConsultarFecha(FechaProgramada.Value.ToString("yyyy-MM-ddT00:00:00")) = True Then

                MessageBoxEx.Show(Me, "Ya hay una lista programada para esta fecha.",
                          "Actualizar Programado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return

            End If

            Consulta_sql = "UPDATE " & _Global_BaseBk & "[Zw_ListaLC_Programadas]
                            SET [FechaRegistro] = '" & Now.ToString("yyyy-MM-ddTHH:mm:ss") & "',[FechaProgramada] = '" & FechaProgramada.Value.ToString("yyyy-MM-ddT00:00:00") & "', [Funcionario] = '" & FUNCIONARIO & "'
                            WHERE Id='" & IdListaProgramada & ";'"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Actualizacion de Precios Programada Correctamente", "Actualizar Precios Programado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LlenarListasProgramadas(False)
                GrillaPrecios.DataSource = Nothing
            End If

        End If

    End Sub

    Private Sub EliminarListaProgramada()

        Dim dlg As System.Windows.Forms.DialogResult =
        MessageBoxEx.Show(Me, "¿Esta seguro de Eliminar la lista programada?",
                          "Eliminar Programado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlg = System.Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Update " & _Global_BaseBk & "[Zw_ListaLC_Programadas]
                            Set [FechaRegistro] = '" & Now.ToString("yyyy-MM-ddTHH:mm:ss") & "',[FechaProgramada] = '" & FechaProgramada.Value.ToString("yyyy-MM-ddT00:00:00") & "', [Funcionario] = '" & FUNCIONARIO & "', [Activo]='0'
                            Where Id='" & IdListaProgramada & ";'"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                MessageBoxEx.Show(Me, "Actualizacion de Precios Eliminada Correctamente", "Eliminar Precios Programado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LlenarListasProgramadas(False)
                GrillaPrecios.DataSource = Nothing

            End If

        End If

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        ActualizarListaProgramada()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        EliminarListaProgramada()
    End Sub

    'Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
    '    LlenarListasProgramadas(True)
    'End Sub

    Private Sub GrillaListasProgramadas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaListasProgramadas.CellEnter

        Dim Fila As DataGridViewRow = GrillaListasProgramadas.CurrentRow

        IdListaProgramada = Fila.Cells("Id").Value.ToString
        Txtcodigo.Text = Fila.Cells("Producto").Value.ToString
        FechaProgramada.Value = DateTime.Parse(Fila.Cells("FechaProgramada").Value.ToString)
        LlenarListasPrecios()

    End Sub

End Class
