
Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_CiasSeguro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodEntidad As String
    Dim _CodSucEntidad As String
    Dim _MontoCreditoTotal As Double
    Dim _SumMontoAsignado As Double

    Public Sub New(_CodEntidad As String, _CodSucEntidad As String, _MontoCreditoTotal As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._CodEntidad = _CodEntidad
        Me._CodSucEntidad = _CodSucEntidad
        Me._MontoCreditoTotal = _MontoCreditoTotal

        Sb_Formato_Generico_Grilla(GrillaContactos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_CiasSeguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler GrillaContactos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = $"
Select Cia.*, EN.NOKOEN From {_Global_BaseBk}Zw_Entidad_CiaSeguro Cia
Inner Join MAEEN EN On EN.KOEN = Cia.CodEntidad And EN.KOEN = Cia.CodSucEntidad And Cia.CodSucEntidad = EN.SUEN
Where CodEntidad = '{_CodEntidad}' And CodSucEntidad = '{_CodSucEntidad}'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        ' Calcular la suma de MontoAsignado y asignarla a la variable de instancia
        Dim _ObjSuma As Object = Nothing
        Try
            _ObjSuma = _Tbl.Compute("SUM(MontoAsignado)", "")
        Catch ex As Exception
            _ObjSuma = Nothing
        End Try

        If IsDBNull(_ObjSuma) OrElse _ObjSuma Is Nothing Then
            _SumMontoAsignado = 0
        Else
            _SumMontoAsignado = Convert.ToDouble(_ObjSuma)
        End If

        With GrillaContactos

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(GrillaContactos, True)

            Dim _DisplayIndex As Integer = 0

            .Columns("CodEntidad_Cia").HeaderText = "Código Cia"
            .Columns("CodEntidad_Cia").Width = 90
            .Columns("CodEntidad_Cia").Visible = True
            .Columns("CodEntidad_Cia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodSucEntidad_Cia").HeaderText = "Suc."
            .Columns("CodSucEntidad_Cia").Width = 50
            .Columns("CodSucEntidad_Cia").Visible = True
            .Columns("CodSucEntidad_Cia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").HeaderText = "Nombre compañia de seguros"
            .Columns("NOKOEN").Width = 300
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MontoAsignado").HeaderText = "Monto Asignado"
            .Columns("MontoAsignado").Width = 100
            .Columns("MontoAsignado").Visible = True
            .Columns("MontoAsignado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        GrillaContactos.Focus()

    End Sub

    Private Sub Btn_AsociarCiaSeguro_Click(sender As Object, e As EventArgs) Handles Btn_AsociarCiaSeguro.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Entidades", "EsCiaSeguro = 1")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen compañias de seguro asociadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Row As DataRow

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.VerSoloCiaSeguro = True
        Fm.ShowDialog(Me)
        _Row = Fm.Pro_RowEntidad
        Fm.Dispose()

        If IsNothing(_Row) Then
            Return
        End If

        Dim _CodEntidad_Cia As String = _Row.Item("KOEN")
        Dim _CodSucEntidad_Cia As String = _Row.Item("SUEN")

        Dim _MontoAsignado As Double = Fx_Asignar_Monto()

        If _MontoAsignado = 0 Then
            Return
        End If

        Consulta_Sql = $"
Insert Into {_Global_BaseBk}Zw_Entidad_CiaSeguro (CodEntidad,CodSucEntidad,CodEntidad_Cia,CodSucEntidad_Cia,MontoAsignado) 
Values ('{_CodEntidad}','{_CodSucEntidad}','{_CodEntidad_Cia}','{_CodSucEntidad_Cia}',{De_Num_a_Tx_01(_MontoAsignado, False, 5)})"
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Sb_Actualizar_Grilla()
        End If


    End Sub

    Function Fx_Asignar_Monto() As Double

        Dim _MontoAsignado As Double
        Dim _CerradoPorX As Boolean
        Dim _Cancelado As Boolean

        Do
            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el monto a asignar", "Monto asignado",
                                                  _MontoAsignado, False, _Tipo_Mayus_Minus.Normal, 10,
                                                  True, _Tipo_Imagen.Money1,, _Tipo_Caracter.Moneda, False,,,,,
                                                  _CerradoPorX, _Cancelado)

            If Not _Aceptar Then
                Return 0
            End If

            ' Validar que la suma actual más el monto ingresado no supere el monto de crédito total.
            If (_SumMontoAsignado + _MontoAsignado) > _MontoCreditoTotal Then
                MessageBoxEx.Show(Me, "El monto asignado no puede ser mayor al monto de crédito total" & vbCrLf &
                                  "Crédito total del cliente: " & FormatNumber(_MontoCreditoTotal, 0), "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' Volver a pedir el monto
            Else
                Return _MontoAsignado
            End If
        Loop

    End Function

End Class
