'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Remotas_Revisar_Documentos_En_Espera

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblDocumentos As DataTable
    Dim _Ds_Documento As DataSet
    Dim _Id_DocEnc As String
    Dim _CodFuncionario As String

    Dim _Row_Documento_Seleccionado As DataRow

    Public ReadOnly Property Pro_Row_Documento_Seleccionado() As DataRow
        Get
            Return _Row_Documento_Seleccionado
        End Get
    End Property
    Public Property _TblDoc() As DataTable
        Get
            Return _TblDocumentos
        End Get
        Set(ByVal value As DataTable)

        End Set
    End Property

    Public Sub New(ByVal CodFuncionario As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 30, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        _CodFuncionario = CodFuncionario

        Consulta_sql = "Select Zcd.Id_DocEnc,Zr.NroRemota,Zr.Otorga,Zcd.TipoDoc," & _
                       "Isnull((Select Top 1 NUDO From MAEEDO Where IDMAEEDO = Zr.Idmaeedo),'') As NroDocumento," & _
                       "Zcd.FechaEmision,Zcd.CodEntidad," & _
                       "Zcd.CodSucEntidad,Zcd.CodSucEntidad,Zcd.Nombre_Entidad,Zcd.TotalBrutoDoc,Zr.Observaciones" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_Casi_DocEnc Zcd LEFT OUTER JOIN" & vbCrLf & _
                       _Global_BaseBk & "Zw_Remotas Zr ON Zcd.Id_DocEnc = Zr.Id_Casi_DocEnc" & vbCrLf & _
                       "WHERE Zcd.CodFuncionario = '" & _CodFuncionario & "' And Zr.Eliminada = 0"

        _TblDocumentos = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Private Sub Frm_Remotas_Revisar_Documentos_En_Espera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = "Documentos en espera, usuario: " & Nombre_funcionario_activo
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        InsertarBotonenGrilla(Grilla, "BtnImagen", "Est.", "Estado", 0, _Tipo_Boton.Imagen)
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Zcd.Id_DocEnc,Zr.NroRemota,Zr.Otorga,Zcd.TipoDoc,Zcd.NroDocumento,Zcd.FechaEmision,Zcd.CodEntidad," & _
                       "Zcd.CodSucEntidad,Zcd.CodSucEntidad,Zcd.Nombre_Entidad,Zcd.TotalBrutoDoc,Zr.Observaciones" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_Casi_DocEnc Zcd LEFT OUTER JOIN" & vbCrLf & _
                       _Global_BaseBk & "Zw_Remotas Zr ON Zcd.Id_DocEnc = Zr.Id_Casi_DocEnc" & vbCrLf & _
                       "WHERE Zcd.CodFuncionario = '" & _CodFuncionario & "' And Zr.Eliminada = 0"

        Consulta_sql = "Select Zcd.Id_DocEnc,Zr.NroRemota,Zr.Otorga,Zcd.TipoDoc," & _
                       "Isnull((Select Top 1 NUDO From MAEEDO Where IDMAEEDO = Zr.Idmaeedo),'') As NroDocumento," & _
                       "Zcd.FechaEmision,Zcd.CodEntidad," & _
                       "Zcd.CodSucEntidad,Zcd.CodSucEntidad,Zcd.Nombre_Entidad,Zcd.TotalBrutoDoc,Zr.Observaciones," & vbCrLf & _
                       "Zr.Crear_Doc_Def_Al_Grabar,Zr.Idmaeedo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_Casi_DocEnc Zcd LEFT OUTER JOIN" & vbCrLf & _
                       _Global_BaseBk & "Zw_Remotas Zr ON Zcd.Id_DocEnc = Zr.Id_Casi_DocEnc" & vbCrLf & _
                       "WHERE Zcd.CodFuncionario = '" & _CodFuncionario & "' And Zr.Eliminada = 0"


        _TblDocumentos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _TblDocumentos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("BtnImagen").Width = 50
            .Columns("BtnImagen").HeaderText = "Est."
            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").DisplayIndex = 0

            .Columns("NroRemota").Visible = True
            .Columns("NroRemota").HeaderText = "Nro Remota"
            .Columns("NroRemota").Width = 75
            .Columns("NroRemota").DisplayIndex = 1

            .Columns("Otorga").Visible = True
            .Columns("Otorga").HeaderText = "Estatus"
            .Columns("Otorga").Width = 85
            .Columns("Otorga").DisplayIndex = 2

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = 3

            .Columns("NroDocumento").Visible = True
            .Columns("NroDocumento").HeaderText = "Número"
            .Columns("NroDocumento").Width = 80
            .Columns("NroDocumento").DisplayIndex = 4

            .Columns("FechaEmision").Visible = True
            .Columns("FechaEmision").HeaderText = "Fecha"
            .Columns("FechaEmision").Width = 70
            .Columns("FechaEmision").DisplayIndex = 5

            .Columns("CodEntidad").Visible = True
            .Columns("CodEntidad").HeaderText = "Entidad"
            .Columns("CodEntidad").Width = 75
            .Columns("CodEntidad").DisplayIndex = 6

            .Columns("CodSucEntidad").Visible = True
            .Columns("CodSucEntidad").HeaderText = "Suc."
            .Columns("CodSucEntidad").Width = 30
            .Columns("CodSucEntidad").DisplayIndex = 7

            .Columns("Nombre_Entidad").Visible = True
            .Columns("Nombre_Entidad").HeaderText = "Razón Social"
            .Columns("Nombre_Entidad").Width = 280
            .Columns("Nombre_Entidad").DisplayIndex = 8

            .Columns("TotalBrutoDoc").Visible = True
            .Columns("TotalBrutoDoc").HeaderText = "Total"
            .Columns("TotalBrutoDoc").Width = 75
            .Columns("TotalBrutoDoc").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalBrutoDoc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalBrutoDoc").DisplayIndex = 9

        End With

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Otorga = _Row.Cells("Otorga").Value

            Select Case _Otorga
                Case "Autorizado"
                    _Row.Cells("BtnImagen").Value = Imagenes_20x20.Images.Item("ok_button.png")
                Case "Rechazado"
                    _Row.Cells("BtnImagen").Value = Imagenes_20x20.Images.Item("cancel.png")
                Case Else
                    _Row.Cells("BtnImagen").Value = Imagenes_20x20.Images.Item("clock-internet.png")
            End Select

        Next

        Grilla.Refresh()

    End Sub

    Private Sub Frm_Remotas_Revisar_Documentos_En_Espera_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        _Id_DocEnc = _Fila.Cells("Id_DocEnc").Value

        Dim _NroRemota = _Fila.Cells("NroRemota").Value
        Dim _Otorga = _Fila.Cells("Otorga").Value
        Dim _Observaciones = _Fila.Cells("Observaciones").Value
        Dim _Usuario_Solicita = FUNCIONARIO


        Consulta_sql = "Select *,(Select Top 1 NOKOFU From TABFU Where KOFU = CodFuncionario) As Funcionario" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Casi_DocTom Where Id_DocEnc = " & _Id_DocEnc
        Dim _Row_Zw_Casi_DocTom As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If (_Row_Zw_Casi_DocTom Is Nothing) Then

            Dim _Autorizado = 0
            Dim _Rechazado = 0

            If _Otorga = "Autorizado" Then
                _Autorizado = 1
            End If

            If _Otorga = "Rechazado" Then
                If Not String.IsNullOrEmpty(Trim(_Observaciones)) Then
                    MessageBoxEx.Show(Me, _Observaciones, "Motivo rechazo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                _Rechazado = 1
            End If

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Notificaciones" & vbCrLf &
                           "Where Usuario_Solicita = '" & FUNCIONARIO & "' And NroRemota = '" & _NroRemota & "'"
            Dim _RowNotificaciones As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_RowNotificaciones Is Nothing) Then
                Dim _Id = _RowNotificaciones.Item("Id")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set Rev_Usuario_Solicita = 1" & vbCrLf &
                               "Where NroRemota = '" & _NroRemota & "'" & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Notificaciones Set Autorizado = " & _Autorizado & ",Rechazado = " & _Rechazado & vbCrLf &
                               "Where NroRemota = '" & _NroRemota & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO,
                                                   _Usuario_Solicita, "Confirmación",
                                                   "confirmación de lectura",
                                                   csNotificaciones.Notificacion.Imagen.Confirmacion,
                                                   _NroRemota, False, _Id, False, 0, False, "", "", "")

            End If

            Consulta_sql = "Select Zcd.*,Zr.*" & vbCrLf &
                           "FROM " & _Global_BaseBk & "Zw_Casi_DocEnc Zcd LEFT OUTER JOIN" & vbCrLf &
                           _Global_BaseBk & "Zw_Remotas Zr ON Zcd.Id_DocEnc = Zr.Id_Casi_DocEnc" & vbCrLf &
                           "WHERE Zcd.Id_DocEnc = " & _Id_DocEnc
            _Row_Documento_Seleccionado = _Sql.Fx_Get_DataRow(Consulta_sql)

            Me.Close()

        Else
            Dim _Funcionario = _Row_Zw_Casi_DocTom.Item("Funcionario")
            MessageBoxEx.Show(Me, "El documento se encuentra tomado por: " & _Funcionario,
                              "El permisos esta siendo atentido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Row_Documento_Seleccionado = Nothing
        End If

    End Sub



    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Sb_Actualizar_Grilla()
    End Sub

End Class
