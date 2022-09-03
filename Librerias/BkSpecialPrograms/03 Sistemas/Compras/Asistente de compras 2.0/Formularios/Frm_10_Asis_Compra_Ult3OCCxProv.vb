Imports DevComponents.DotNetBar

Public Class Frm_10_Asis_Compra_Ult3OCCxProv

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String = "Zw_InfCompras01" & FUNCIONARIO
    Dim _RowProveedor As DataRow
    Dim _Accion_Automatica As Boolean
    Dim _Proceso_Realizado As Boolean

    Public Property Accion_Automatica As Boolean
        Get
            Return _Accion_Automatica
        End Get
        Set(value As Boolean)
            _Accion_Automatica = value
        End Set
    End Property

    Public Property Proceso_Realizado As Boolean
        Get
            Return _Proceso_Realizado
        End Get
        Set(value As Boolean)
            _Proceso_Realizado = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._RowProveedor = _RowProveedor

    End Sub

    Private Sub Frm_10_Asis_Compra_Ult3OCCxProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '   Meses estudiar ultimas compras por proveedor
        _Sql.Sb_Parametro_Informe_Sql(Input_MesesCP, "Compras_Asistente",
                                             Input_MesesCP.Name, Class_SQLite.Enum_Type._Double, Input_MesesCP.Value, False)

        '   Docuementos estudiar ultimas compras por proveedor
        _Sql.Sb_Parametro_Informe_Sql(Input_UltDocumentosCP, "Compras_Asistente",
                                             Input_UltDocumentosCP.Name, Class_SQLite.Enum_Type._Double, Input_UltDocumentosCP.Value, False)

        Tiempo_Accion_Automatica.Enabled = _Accion_Automatica
    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        Me.GroupPanel1.Enabled = False
        Btn_Procesar.Enabled = False

        Consulta_sql = "Select * From " & _Tabla_Paso
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ProgressBarX1.Maximum = _Tbl.Rows.Count
        ProgressBarX1.Value = 0

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Codigo = _Fila.Item("Codigo")
            Dim _Codigo_Nodo_Madre = _Fila.Item("Codigo_Nodo_Madre")

            Dim _Endo = _Fila.Item("CodProveedor")
            Dim _Suendo = _Fila.Item("CodSucProveedor")

            System.Windows.Forms.Application.DoEvents()

            If Not String.IsNullOrEmpty(_Endo) Then

                Consulta_sql = "Declare @Endo Char(10) = '" & _Endo & "'" & vbCrLf &
                               "Declare @Suendo Char(10) = '" & _Suendo & "'" & vbCrLf &
                               "Declare @Meses Int = " & Input_MesesCP.Value & vbCrLf &
                               "Declare @UltDocumentos Int = " & Input_UltDocumentosCP.Value & vbCrLf &
                               "Declare @Codigo Char(13) = '" & _Codigo & "'" & vbCrLf &
                               "Declare @Codigo_Nodo_Madre Varchar(20) = '" & _Codigo_Nodo_Madre & "'" & vbCrLf &
                               "Declare @Porc_CumpUlt3Pedidos Float" &
                                vbCrLf &
                                vbCrLf &
                               "Select Distinct Edo.IDMAEEDO,Edo.FEEMDO" & vbCrLf &
                               "Into #Paso_Documentos" & vbCrLf &
                               "From MAEDDO Ddo" & vbCrLf &
                               "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                               "Where Ddo.IDMAEEDO In (Select IDMAEEDO From MAEEDO Where TIDO = 'OCC' And ENDO = @Endo And SUENDO = @Suendo And FEEMDO > DATEADD(M,-@Meses,Getdate()))" & vbCrLf &
                               "And KOPRCT = @Codigo_Nodo_Madre" &
                               vbCrLf &
                               vbCrLf &
                               "Select Top 3 * Into #Paso_DocUlt3 From #Paso_Documentos Order By IDMAEEDO Desc" & vbCrLf &
                               "Set @Porc_CumpUlt3Pedidos = (Select Round(SUM(CAPREX1)/SUM(CAPRCO1),2) From MAEDDO Where IDMAEEDO In (Select IDMAEEDO From #Paso_DocUlt3) And KOPRCT = @Codigo_Nodo_Madre)" & vbCrLf &
                               "Update " & _Tabla_Paso & " Set Porc_CumpUlt3Pedidos = Isnull(@Porc_CumpUlt3Pedidos,0)" & vbCrLf &
                               "Where Codigo_Nodo_Madre = @Codigo_Nodo_Madre" &
                               vbCrLf &
                               vbCrLf &
                               "Drop Table #Paso_DocUlt3" & vbCrLf &
                               "Drop Table #Paso_Documentos"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            ProgressBarX1.Value += 1
            ProgressBarX1.Text = "Procesados " & FormatNumber(ProgressBarX1.Value, 0) & " de " & FormatNumber(_Tbl.Rows.Count, 0)

        Next

        If Not _Accion_Automatica Then
            MessageBoxEx.Show(Me, "Proceso generado correctamente", "Asociación automática", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ProgressBarX1.Value = 0
        ProgressBarX1.Text = String.Empty

        Me.GroupPanel1.Enabled = True
        Btn_Procesar.Enabled = True

        _Proceso_Realizado = True

        Me.Close()

    End Sub

    Private Sub Tiempo_Accion_Automatica_Tick(sender As Object, e As EventArgs) Handles Tiempo_Accion_Automatica.Tick
        Tiempo_Accion_Automatica.Stop()
        Call Btn_Procesar_Click(Nothing, Nothing)
    End Sub

    Private Sub Frm_10_Asis_Compra_Ult3OCCxProv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        '   Meses estudiar ultimas compras por proveedor
        _Sql.Sb_Parametro_Informe_Sql(Input_MesesCP, "Compras_Asistente",
                                             Input_MesesCP.Name, Class_SQLite.Enum_Type._Double, Input_MesesCP.Value, True)

        '   Docuementos estudiar ultimas compras por proveedor
        _Sql.Sb_Parametro_Informe_Sql(Input_UltDocumentosCP, "Compras_Asistente",
                                             Input_UltDocumentosCP.Name, Class_SQLite.Enum_Type._Double, Input_UltDocumentosCP.Value, True)

    End Sub
End Class
