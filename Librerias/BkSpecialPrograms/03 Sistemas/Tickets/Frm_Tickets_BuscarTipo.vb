Imports DevComponents.DotNetBar

Public Class Frm_Tickets_BuscarTipo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Id_Area As Integer
    Public Property Id_Tipo As Integer

    Public ModoSeleccion As Boolean
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Tipos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_BuscarTipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Tipos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Me.ActiveControl = Txt_Buscador

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "Area+Tipo Like '%")

        Consulta_sql = "Select Ar.Id As 'Id_Area',Tp.Id As 'Id_Tipo',Ar.Area,Tp.Tipo,Ar.Area+' - '+Tp.Tipo As 'AreaTipo'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Areas Ar" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tipos Tp On Tp.Id_Area = Ar.Id" & vbCrLf &
                       "Where Area+Tipo Like '%" & _Condicion & "%'" & vbCrLf &
                       "And Tp.CierraRaiz = 0" & vbCrLf & vbCrLf &
                       "Order By Area,Tipo"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Tipos, True)

            Dim _DisplayIndex = 0

            .Columns("Area").Visible = True
            .Columns("Area").HeaderText = "Area / Departamento"
            .Columns("Area").Width = 180
            .Columns("Area").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo de Ticket"
            .Columns("Tipo").Width = 380
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_Tipos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Tipos.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow

        Dim _AreaTipo As String = _Fila.Cells("AreaTipo").Value
        Dim _Area As String = _Fila.Cells("Area").Value
        Dim _Tipo As String = _Fila.Cells("Tipo").Value


        Id_Area = _Fila.Cells("Id_Area").Value
        Id_Tipo = _Fila.Cells("Id_Tipo").Value

        If ModoSeleccion Then

            Dim _Cl_Tickets As New Cl_Tickets
            Dim _Zw_Stk_Tipos As New Zw_Stk_Tipos

            _Zw_Stk_Tipos = _Cl_Tickets.Fx_Llenar_Tipo(Id_Tipo)

            If _Zw_Stk_Tipos.CierraRaiz Then
                MessageBoxEx.Show(Me, "Este Tipo de Ticket no permite generar un Ticket desde cero, es solo para hacer gestión en cadena de Tickets",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _CodPermiso As String = "Tkt" & numero_(Id_Area & Id_Tipo, 6)

            If Not Fx_Tiene_Permiso(Me, _CodPermiso) Then
                Id_Area = 0
                Id_Tipo = 0
                Return
            End If

        End If

        If MessageBoxEx.Show(Me, "¿Confirma la selección de esta Area/Tipo? " & vbCrLf & vbCrLf &
                             "Area: " & _Area & vbCrLf & "Tipo: " & _Tipo, "Seleccionar Tipo de Ticket",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Id_Area = 0
            Id_Tipo = 0
            Return
        End If

        Me.Close()

    End Sub

    Private Sub Frm_Tickets_BuscarTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
