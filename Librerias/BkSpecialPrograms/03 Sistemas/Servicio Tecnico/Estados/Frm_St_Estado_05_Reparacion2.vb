Public Class Frm_St_Estado_05_Reparacion2

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ot As Integer
    Dim _Grabar As Boolean
    Dim _DsDocumento As DataSet

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Row_Notas As DataRow
    Dim _RowEntidad As DataRow
    Dim _Tbl_DetProd_Cov As DataTable
    Dim _Tbl_DetProd_Srv As DataTable

    Dim _Editando_documento As Boolean

    Dim _Motivo_no_reparo As String

    Dim _Horas_Mano_de_Obra_Repara As Double
    Dim Imagenes_32x32 As ImageList

    Dim _Fijar_Estado As Boolean

    Dim _Accion As Accion

    Public Property RowEntidad As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public Property CodTecnico_Repara As String

    Public Property DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(value As DataSet)
            _DsDocumento = value
            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_DetProd_Cov = _DsDocumento.Tables(7)
            _Tbl_DetProd_Srv = _DsDocumento.Tables(11)
        End Set
    End Property

    Public Property Fijar_Estado As Boolean
        Get
            Return _Fijar_Estado
        End Get
        Set(value As Boolean)
            _Fijar_Estado = value
        End Set
    End Property

    Public Property Id_Ot As Integer
        Get
            Return _Id_Ot
        End Get
        Set(value As Integer)
            _Id_Ot = value
        End Set
    End Property

    Public Sub New(_Accion As Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Accion = _Accion

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Estado_05_Reparacion2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InsertarBotonenGrilla(Grilla, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)

        Dim _CodFuncionario = _Row_Encabezado.Item("CodTecnico_Asignado")

        'If _Accion = Accion.Editar Then
        '    CodTecnico_Presupuesta = _Row_Encabezado.Item("CodTecnico_Presupuesta").ToString.Trim
        'End If

        'If String.IsNullOrEmpty(CodTecnico_Presupuesta) Then
        '    CodTecnico_Presupuesta = _CodFuncionario
        'Else
        '    _CodFuncionario = CodTecnico_Presupuesta
        'End If

        Txt_Tecnico_Taller.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller", "NomFuncionario",
                                           "CodFuncionario = '" & _CodFuncionario & "'").ToString.Trim

        Txt_NroSerie.Text = _Row_Encabezado.Item("NroSerie")

        Sb_Actualizar_Grilla()
        Sb_Marcar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_DetProd_Srv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").HeaderText = "Ev."
            .Columns("BtnImagen").Width = 30
            .Columns("BtnImagen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 320
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ud").Visible = True
            .Columns("Ud").HeaderText = "UM"
            .Columns("Ud").Width = 30
            .Columns("Ud").ReadOnly = True
            .Columns("Ud").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Cantidad_Utilizada").Visible = True
            '.Columns("Cantidad_Utilizada").HeaderText = "Cantidad Utilizada"
            '.Columns("Cantidad_Utilizada").Width = 120
            '.Columns("Cantidad_Utilizada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ''.Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            '.Columns("Cantidad_Utilizada").ReadOnly = True
            '.Columns("Cantidad_Utilizada").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In _Grilla.Rows

            Dim _Chk_Validado As Boolean = _Fila.Cells("Chk").Value
            Dim _Utilizado As Boolean = _Fila.Cells("Utilizado").Value

            'If Not _Editando_documento Then
            '    If _Accion = Accion.Editar Then _Chk_Validado = True
            'End If

            _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)

            If _Chk_Validado Then
                If _Utilizado Then
                    _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("OK")
                Else
                    _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                    _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("NO")
                End If
            Else
                _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("WARNING")
            End If

            _Fila.Cells("Codigo").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            _Fila.Cells("Cantidad_Utilizada").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)

        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Semilla As Integer = _Fila.Cells("Semilla").Value

        Dim _Grabar As Boolean

        Consulta_sql = "Select Serv.Id,Serv.Id_Ot,Serv.Semilla,Serv.Codigo,Isnull(Oper.Descripcion,'') As Descripcion," & vbCrLf &
                       "Serv.CodReceta,Serv.Operacion,Serv.Orden,Serv.CantMayor1,Serv.Cantidad,Serv.CantidadRealizada,Serv.Precio," &
                       "Serv.Total,Serv.Realizado,Serv.Externa,Cast(0 As Bit) As Chk" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_OpeXServ Serv" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On Serv.Operacion = Oper.Operacion" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & " And Semilla = " & _Semilla
        Dim _Tbl_Operaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm2 As New Frm_OperacionesXServicio("")
        Fm2.TblOperaciones = _Tbl_Operaciones
        Fm2.ShowDialog(Me)
        _Grabar = Fm2.Grabar
        '_Tbl_DetProd_Srv = Fm2.TblOperaciones
        Fm2.Dispose()

    End Sub

End Class
