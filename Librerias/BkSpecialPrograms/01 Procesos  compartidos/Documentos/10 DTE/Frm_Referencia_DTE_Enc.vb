Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Referencia_DTE_Enc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idmaeedo As Integer
    Dim _Tido As String
    Dim _Nudo As String

    Dim _Tbl_Referencias As DataTable
    Dim _Habilita_CodRef As Boolean
    Dim _Class_Referencias_DTE As Class_Referencias_DTE

    Public Property Class_Referencias_DTE As Class_Referencias_DTE
        Get
            Return _Class_Referencias_DTE
        End Get
        Set(value As Class_Referencias_DTE)
            _Class_Referencias_DTE = value
        End Set
    End Property

    Public Property Tido As String
        Get
            Return _Tido
        End Get
        Set(value As String)
            _Tido = value
        End Set
    End Property

    Public Property Nudo As String
        Get
            Return _Nudo
        End Get
        Set(value As String)
            _Nudo = value
        End Set
    End Property

    Public Sub New(Idmaeedo As Integer, Habilita_CodRef As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Idmaeedo = Idmaeedo
        _Habilita_CodRef = Habilita_CodRef

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Referencias_DTE_Enc_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsNothing(_Class_Referencias_DTE) Then
            _Class_Referencias_DTE = New Class_Referencias_DTE(_Idmaeedo)
        End If

        _Tbl_Referencias = _Class_Referencias_DTE.Tbl_Referencias

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Referencias_Dte Where Idmaeedo = " & _Idmaeedo
        '_Tbl_Referencias = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Referencias

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("TpoDocRef").HeaderText = "Doc. Ref"
            .Columns("TpoDocRef").Width = 60
            .Columns("TpoDocRef").Visible = True

            .Columns("FolioRef").HeaderText = "Folio"
            .Columns("FolioRef").Width = 80
            .Columns("FolioRef").Visible = True

            .Columns("FchRef").HeaderText = "Fecha"
            .Columns("FchRef").Width = 80
            .Columns("FchRef").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FchRef").Visible = True

            .Columns("CodRef").HeaderText = "Cód."
            .Columns("CodRef").Width = 30
            .Columns("CodRef").Visible = True

            .Columns("RazonRef").HeaderText = "Descripción"
            .Columns("RazonRef").Width = 300
            .Columns("RazonRef").Visible = True

        End With

    End Sub

    Private Sub Btn_Nueva_Referancia_Click(sender As Object, e As EventArgs) Handles Btn_Nueva_Referancia.Click

        If Fx_Tiene_Permiso(Me, "Doc00027") Then

            Dim _NroLinRef = _Tbl_Referencias.Rows.Count + 1

            Dim _Row_Referencia As DataRow = _Class_Referencias_DTE.Fx_Row_Nueva_Referencia(0, _Idmaeedo, "", "", _NroLinRef, 0, "", "", "", Now.Date, 0, "")
            Dim _Grabar As Boolean

            Dim Fm As New Frm_Referencia_DTE_Det(_Row_Referencia, _Habilita_CodRef)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            If _Grabar Then

                If Convert.ToBoolean(_Idmaeedo) Then

                    Dim _Tido = _Row_Referencia.Item("Tido")
                    Dim _Nudo = _Row_Referencia.Item("Nudo")
                    'Dim _NroLinRef = _Row_Referencia.Item("NroLinRef")
                    Dim _TpoDocRef = _Row_Referencia.Item("TpoDocRef")
                    Dim _FolioRef = _Row_Referencia.Item("FolioRef")
                    Dim _FchRef = Format(_Row_Referencia.Item("FchRef"), "yyyyMMdd")
                    Dim _CodRef = _Row_Referencia.Item("CodRef")
                    Dim _RUTOt = _Row_Referencia.Item("RUTOt")
                    Dim _IdAdicOtr = _Row_Referencia.Item("IdAdicOtr")
                    Dim _RazonRef = _Row_Referencia.Item("RazonRef")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Referencias_Dte " &
                                   "(Id_Doc,Tido,Nudo,NroLinRef,TpoDocRef,FolioRef,RUTOt,IdAdicOtr,FchRef,CodRef,RazonRef, Kasi)
                               Values
                               (" & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "'," & _NroLinRef & "," & _TpoDocRef &
                                   ",'" & _FolioRef & "','" & _RUTOt & "','" & _IdAdicOtr & "','" & _FchRef & "'," & _CodRef & ",'" & _RazonRef & "',0)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Else
                _Tbl_Referencias.Rows.Remove(_Row_Referencia)
            End If

        End If

    End Sub

    Private Sub Btn_Editar_Referencia_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Referencia.Click

        If Fx_Tiene_Permiso(Me, "Doc00027") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _NroLinRef = _Fila.Cells("NroLinRef").Value
            Dim _Id_Ref = _Fila.Cells("Id_Ref").Value

            Dim _Row_Referencia As DataRow
            Dim _Grabar As Boolean

            For Each _Row As DataRow In _Tbl_Referencias.Rows

                If _NroLinRef = _Row.Item("NroLinRef") Then
                    _Row_Referencia = _Row
                    Exit For
                End If

            Next

            Dim Fm As New Frm_Referencia_DTE_Det(_Row_Referencia, _Habilita_CodRef)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            If _Grabar Then

                If CBool(_Id_Ref) Then

                    Dim _TpoDocRef = _Row_Referencia.Item("TpoDocRef")
                    Dim _FolioRef = _Row_Referencia.Item("FolioRef")
                    Dim _FchRef = Format(_Row_Referencia.Item("FchRef"), "yyyyMMdd")
                    Dim _CodRef = _Row_Referencia.Item("CodRef")
                    Dim _RazonRef = _Row_Referencia.Item("RazonRef")

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Referencias_Dte Set 
                                TpoDocRef = " & _TpoDocRef & ", 
                                FolioRef = '" & _FolioRef & "', 
                                FchRef = '" & _FchRef & "', 
                                CodRef = '" & _CodRef & "', 
                                RazonRef = '" & _RazonRef & "'
                                Where Id_Ref = " & _Id_Ref

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        End If

    End Sub

    Function Fx_Trar_Row_Referencia(_NroLinRef As Integer) As DataRow

        For Each _Row As DataRow In _Tbl_Referencias.Rows

            If _NroLinRef = _Row.Item("NroLinRef") Then
                Return _Row
                Exit For
            End If

        Next

    End Function

    Private Sub Btn_Eliminar_Referencia_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Referencia.Click

        If Fx_Tiene_Permiso(Me, "Doc00027") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Index As Integer = _Fila.Index

            Dim _Id_Ref = _Fila.Cells("Id_Ref").Value

            If CBool(_Idmaeedo) Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Referencias_Dte Where Id_Ref = " & _Id_Ref
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            Grilla.Rows.RemoveAt(_Index)

        End If

    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_01)

                End If

            End With

        End If

    End Sub

    Private Sub Frm_Referencia_DTE_Enc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
