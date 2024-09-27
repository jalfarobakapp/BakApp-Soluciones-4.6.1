Imports DevComponents.DotNetBar

Public Class Frm_Ver_Documentos_Permisos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idmaeedo As Integer
    Dim _Tbl_Remotas As DataTable

    Public Property Pro_Tbl_Remotas As DataTable
        Get
            Return _Tbl_Remotas
        End Get
        Set(value As DataTable)
            _Tbl_Remotas = value
        End Set
    End Property

    Public Sub New(Idmaeedo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Idmaeedo = Idmaeedo

        Consulta_sql = "Select *,Case Heredado When 1 Then 'Heredado' Else Case Permiso_Presencial When 1 Then 'Presencial' Else 'Remoto' End End As 'Tipo_de_permiso'," &
                       "Isnull(FuA.NOKOFU,CodFuncionario_Autoriza+' ???') As Autorizado_por,Isnull(FuS.NOKOFU,CodFuncionario_Solicita+' ???') As FunSolicita  
                        From " & _Global_BaseBk & "Zw_Remotas 
                        Left Join TABFU FuA On FuA.KOFU = CodFuncionario_Autoriza
                        Left Join TABFU FuS On FuS.KOFU = CodFuncionario_Solicita
                        Where Idmaeedo = " & _Idmaeedo & " And Eliminada = 0"
        _Tbl_Remotas = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Ver_Documentos_Permisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Acualizar_Grilla()
        Me.Text = "PERMISOS DEL DOCUMENTO"

    End Sub

    Sub Sb_Acualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_Remotas

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("NroRemota").Visible = True
            .Columns("NroRemota").HeaderText = "Nro Acción"
            .Columns("NroRemota").Width = 70
            .Columns("NroRemota").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodPermiso").Visible = True
            .Columns("CodPermiso").HeaderText = "Permiso"
            .Columns("CodPermiso").Width = 70
            .Columns("CodPermiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion_Adicional").Visible = True
            .Columns("Descripcion_Adicional").HeaderText = "Descripcion" '"Cód. Permiso"
            .Columns("Descripcion_Adicional").Width = 300
            .Columns("Descripcion_Adicional").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo_de_permiso").Visible = True
            .Columns("Tipo_de_permiso").HeaderText = "Tipo"
            .Columns("Tipo_de_permiso").Width = 60
            .Columns("Tipo_de_permiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Autorizado_por").Visible = True
            .Columns("Autorizado_por").HeaderText = "Autoriza"
            .Columns("Autorizado_por").Width = 130
            .Columns("Autorizado_por").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Otorga").Visible = True
            .Columns("Fecha_Otorga").HeaderText = "Fecha/Hora"
            .Columns("Fecha_Otorga").DefaultCellStyle.Format = "yyyy/MM/dd, hh:mm"
            .Columns("Fecha_Otorga").Width = 100
            .Columns("Fecha_Otorga").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Frm_Ver_Documentos_Permisos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Lbl_Descripcion_Permiso.Text = "Permiso: " & _Fila.Cells("Descripcion_Adicional").Value.ToString.Trim &
                                       ", Solicitado por: " & _Fila.Cells("CodFuncionario_Solicita").Value.ToString.Trim & "-" & _Fila.Cells("FunSolicita").Value.ToString.Trim
    End Sub
End Class
