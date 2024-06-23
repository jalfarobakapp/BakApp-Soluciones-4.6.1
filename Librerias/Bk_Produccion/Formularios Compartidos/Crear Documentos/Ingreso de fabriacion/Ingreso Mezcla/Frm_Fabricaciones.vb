Imports System.Reflection.Emit
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Fabricaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Mezcla As New Cl_Mezcla
    Dim _Tbl_Fabricaciones As DataTable

    Private _Id_Det As Integer
    Public Property OTCreada As Boolean
    Public Property MaxCantidadFabricar As Integer

    Public Sub New(Id_Det As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Id_Det = Id_Det

        '_Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDet(_Id_Det)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_Fabricaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()
        Dtp_Fecha_Ingreso.Value = FechaDelServidor()

        Dim _Fabricada As Boolean = CBool(_Cl_Mezcla.Zw_Pdp_CPT_MzDet.Idmaeddo)

        Btn_Grabar.Enabled = Not _Fabricada
        Btn_IngresarNuevaFabricacion.Enabled = Not _Fabricada
        Dtp_Fecha_Ingreso.Enabled = Not _Fabricada

        If Not _Fabricada Then
            Dtp_Fecha_Ingreso.Value = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.FechaCreacion
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDet(_Id_Det)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab" & vbCrLf &
                       "Where Id_Det = " & _Id_Det
        _Tbl_Fabricaciones = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Fabricaciones

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 290
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Udad").Width = 30
            .Columns("Udad").HeaderText = "Udad"
            .Columns("Udad").Visible = True
            .Columns("Udad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantIngresada").Visible = True
            .Columns("CantIngresada").HeaderText = "Ingresado"
            .Columns("CantIngresada").Width = 60
            .Columns("CantIngresada").Visible = True
            .Columns("CantIngresada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantIngresada").DefaultCellStyle.Format = "###,###.##"
            .Columns("CantIngresada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantFabricada").Visible = True
            .Columns("CantFabricada").HeaderText = "Fabricado"
            .Columns("CantFabricada").Width = 60
            .Columns("CantFabricada").Visible = True
            .Columns("CantFabricada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantFabricada").DefaultCellStyle.Format = "###,###.##"
            .Columns("CantFabricada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaFabricacion").Width = 110
            .Columns("FechaFabricacion").HeaderText = "F.Fabricación"
            .Columns("FechaFabricacion").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            .Columns("FechaFabricacion").Visible = True
            .Columns("FechaFabricacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        'Consulta_sql = "Select Isnull(SUM(CantFabricada),0) As 'CantFabricada',Isnull(SUM(CantIngresada),0) As 'CantIngresada'" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab" & vbCrLf &
        '               "Where Id_Det = " & _Id_Det

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Where Id = " & _Id_Det
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_Fabricado.Text = FormatNumber(_Row.Item("CantFabricada"), 0)
        Lbl_Fabricar.Text = FormatNumber(_Row.Item("CantFabricar"), 0)

        If _Row.Item("CantFabricada") > _Row.Item("CantFabricar") Then

            Dim nombreFuente = Lbl_Fabricar.Name
            Dim tamanoFuente = Lbl_Fabricar.Size
            Dim estiloFuente As FontStyle = Lbl_Fabricar.Style

            Lbl_Fabricado.Font = New Font(nombreFuente, 12, FontStyle.Bold)
            Lbl_Fabricado.ForeColor = Rojo

        Else
            Lbl_Fabricado.Font = Lbl_Fabricar.Font
            Lbl_Fabricado.ForeColor = Lbl_Fabricado.ForeColor
        End If

    End Sub

    Private Sub Btn_IngresarNuevaFabricacion_Click(sender As Object, e As EventArgs) Handles Btn_IngresarNuevaFabricacion.Click

        Dim _Aceptar As Boolean

        Dim _CantFabricada As Double

        _Aceptar = InputBox_Bk(Me, "Ingrese la cantidad fabricada, debe incluir solo solidos",
                               "Ingresar fabricación",
                               _CantFabricada, False, ,, True, _Tipo_Imagen.Product,, _Tipo_Caracter.Moneda, False)

        If Not _Aceptar Then
            Return
        End If

        If CBool(MaxCantidadFabricar) Then

            If _CantFabricada > MaxCantidadFabricar Then
                MessageBoxEx.Show(Me, "La cantidad a fabricar no puede ser mayor que " & FormatNumber(MaxCantidadFabricar, 0), "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Call Btn_IngresarNuevaFabricacion_Click(Nothing, Nothing)
                Return
            End If

        End If

        Consulta_sql = "Select SUM(CANTIDAD) As Factor" & vbCrLf &
                       "From PNPD" & vbCrLf &
                       "Inner Join MAEPR On KOPR = ELEMENTO" & vbCrLf &
                       "Where CODIGO = '" & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codnomen & "'" & vbCrLf &
                       "And MRPR In ('06MAPVIT','06MAPLIQ')"
        Dim _Row_Facto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Factor As Double = _Row_Facto.Item("Factor")

        'Consulta_sql = "Select * From PNPD Where CODIGO = '" & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codnomen & "'"
        'Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Zw_Pdp_CPT_MzDetIngFab As New Zw_Pdp_CPT_MzDetIngFab

        With _Zw_Pdp_CPT_MzDetIngFab

            .Id_Det = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id
            .Id_Enc = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id_Enc
            .Codigo = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codigo
            .Descripcion = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Descripcion
            .Udad = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Udad
            .CantIngresada = _CantFabricada
            .CantFabricada = _CantFabricada + _Factor
            .CodFuncionario = FUNCIONARIO
            .FechaFabricacion = FechaDelServidor()

        End With

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Ingresar_Fabricaciones(_Zw_Pdp_CPT_MzDetIngFab)

        Dim _Icon As MessageBoxIcon

        If _Mensaje.EsCorrecto Then
            _Icon = MessageBoxIcon.Information
        Else
            _Icon = MessageBoxIcon.Error
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Icon)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If CBool(_Cl_Mezcla.Zw_Pdp_CPT_MzDet.Idpotl_New) Then
            MessageBoxEx.Show(Me, "La OT la fue creada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDetIngFab(_Id)

        Dim _Aceptar As Boolean

        Consulta_sql = "Select SUM(CANTIDAD) As Factor" & vbCrLf &
                       "From PNPD" & vbCrLf &
                       "Inner Join MAEPR On KOPR = ELEMENTO" & vbCrLf &
                       "Where CODIGO = '" & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Codnomen & "'" & vbCrLf &
                       "And MRPR In ('06MAPVIT','06MAPLIQ')"
        Dim _Row_Facto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Factor As Double = _Row_Facto.Item("Factor")

        With _Cl_Mezcla.Zw_Pdp_CPT_MzDetIngFab

            _Aceptar = InputBox_Bk(Me, "Ingrese la cantidad fabricada, debe incluir solo solidos",
                               "Ingresar fabricación",
                               .CantIngresada, False, ,, True, _Tipo_Imagen.Product,, _Tipo_Caracter.Moneda, False)

            If Not _Aceptar Then
                Return
            End If

            If CBool(MaxCantidadFabricar) Then

                If .CantIngresada > MaxCantidadFabricar Then
                    MessageBoxEx.Show(Me, "La cantidad a fabricar no puede ser mayor que " & FormatNumber(MaxCantidadFabricar, 0), "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Call Grilla_CellDoubleClick(Nothing, Nothing)
                    Return
                End If

            End If

            .CantFabricada = .CantIngresada + _Factor
            .CodFuncionario = FUNCIONARIO

        End With

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Editar_Fabricaciones(_Cl_Mezcla.Zw_Pdp_CPT_MzDetIngFab)

        Dim _Icon As MessageBoxIcon

        If _Mensaje.EsCorrecto Then
            _Icon = MessageBoxIcon.Information
        Else
            _Icon = MessageBoxIcon.Error
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Icon)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de esta fabricación?", "Eliminar fabricación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDetIngFab(_Id)

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Mezcla.Fx_Eliminar_Fabricaciones(_Cl_Mezcla.Zw_Pdp_CPT_MzDetIngFab)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Delete Then
            Call Btn_Eliminar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If _Cl_Mezcla.Zw_Pdp_CPT_MzDet.CantFabricada = 0 Then
            MessageBoxEx.Show(Me, "No existen datos de fabricación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Fecha As DateTime = Dtp_Fecha_Ingreso.Value

        If MessageBoxEx.Show(Me, "¿Confirma la creación de OT?" & vbCrLf & vbCrLf &
                                 "Fecha: " & Dtp_Fecha_Ingreso.Value.ToShortDateString & vbCrLf &
                                 "Cantidad fabricada:" & FormatNumber(_Cl_Mezcla.Zw_Pdp_CPT_MzDet.CantFabricada, 0),
                                 "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes

        ' Si no tiene Idpote se crea la OT
        If _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Idpote_New = 0 Then

            _Mensaje = Fx_Crear_OT()

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

            If Not _Mensaje.EsCorrecto Then
                Return
            End If

        End If

        _Mensaje = Fx_GrabarGRI(_Cl_Mezcla.Zw_Pdp_CPT_MzDet.Idpotl_New)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

    End Sub

    Function Fx_Crear_OT() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try


            Dim _Id_Enc As Integer = _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id_Enc

            _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzEnc(_Id_Enc)

            Dim _Idpote_Otm As Integer = _Cl_Mezcla.Zw_Pdp_CPT_MzEnc.Idpote_Otm
            Dim _Fecha As DateTime = Dtp_Fecha_Ingreso.Value

            Consulta_sql = "EXEC Genero_OT_MEZCLAS  " & _Id_Enc & ",'" & FUNCIONARIO & "','" & Format(_Fecha, "dd/MM/yyyy") & "'"
            Dim _Row_Respuesta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzEnc(_Id_Enc)
            _Cl_Mezcla.Fx_Llenar_Zw_Pdp_CPT_MzDet(_Id_Det)

            If Not CBool(_Cl_Mezcla.Zw_Pdp_CPT_MzDet.Idpotl_New) Then
                _Mensaje.Detalle = "Error en procedimiento almacenado"
                Throw New System.Exception("Consulta: " & Consulta_sql)
            End If

            OTCreada = True

            Consulta_sql = "Select * From POTE Where IDPOTE = " & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Idpote_New
            Dim _Row_NewOT As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            'Consulta_sql = "Select top 1 IDMAEDDO,NUDO From MAEDDO Where IDMAEEDO = " & _Mensaje.Id
            'Dim _Row_Maeddo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = _Row_NewOT.Item("IDPOTE")
            _Mensaje.Detalle = "Creación de OT"
            _Mensaje.Mensaje = "Se creo la OT " & _Row_NewOT.Item("NUMOT")
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = _Row_NewOT

        Catch ex As Exception
            _Mensaje.Icono = MessageBoxIcon.Stop
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_GrabarGRI(_Idpotl As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _New_Idmaeedo As Integer
            Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
            Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Koen As String = _Row_Configp.Item("RUT").ToString.Trim
            Dim _Observaciones As String

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
            Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _FechaEmision As DateTime

            _Observaciones = "Datos de fabricación ingresados directamente desde Bakapp en sistema de ingreso de mezclas"
            _FechaEmision = Dtp_Fecha_Ingreso.Value

            Dim _Cantidad As String = De_Num_a_Tx_01(Math.Round(_Cl_Mezcla.Zw_Pdp_CPT_MzDet.CantFabricada, 0), False, 5)

            Consulta_sql = "Select *," & _Cantidad & " As Cantidad,'" & ModSucursal & "' As Sucursal,'" & ModBodega & "' As Bodega" & vbCrLf &
                           "From POTL Where IDPOTL = " & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Idpotl_New
            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim Fm As New Frm_Formulario_Documento("GRI", csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Recepcion_Interna,
                                                   False, False, False, False, False, False)

            Fm.Pro_RowEntidad = _Row_Entidad
            Fm.Sb_Crear_Documento_Interno_Con_Tabla3Potl(Me, _Tbl_Productos, _FechaEmision, "CODIGO", "Cantidad", "C_FABRIC", _Observaciones, False, False, 1)
            _New_Idmaeedo = Fm.Fx_Grabar_Documento(False)
            Fm.Dispose()

            Consulta_sql = "Select top 1 IDMAEDDO,NUDO,KOPRCT,NOKOPR,CAPRCO1 From MAEDDO Where IDMAEEDO = " & _New_Idmaeedo
            Dim _Row_Maeddo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Set Idmaeddo = " & _Row_Maeddo.Item("IDMAEDDO") & vbCrLf &
                           "Where Id = " & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros2(_Global_BaseBk & "Zw_Pdp_CPT_MzDet",
                                                            "Id_Enc = " & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id_Enc & " And Idmaeddo = 0")

            If _Reg = 0 Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc Set Estado = 'FABRI' Where Id = " & _Cl_Mezcla.Zw_Pdp_CPT_MzDet.Id_Enc
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = _Row_Maeddo.Item("IDMAEDDO")
            _Mensaje.Detalle = "GRI Creada correctamente"
            _Mensaje.Mensaje = "Grabación Exitosa"
            '"Se crea GRI Nro " & _Row_Maeddo.Item("NUDO") & vbCrLf &
            '               "Producto: " & _Row_Maeddo.Item("KOPRCT") & " - " & _Row_Maeddo.Item("NOKOPR") & vbCrLf &
            '               "Cantidad: " & FormatNumber(_Row_Maeddo.Item("CAPRCO1"), 0)

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Resultado = Consulta_sql
        End Try

        Return _Mensaje

    End Function

End Class
