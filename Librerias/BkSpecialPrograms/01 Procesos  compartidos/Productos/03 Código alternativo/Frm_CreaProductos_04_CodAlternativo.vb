Imports BkSpecialPrograms.Bk_Migrar_Producto
Imports DevComponents.DotNetBar

Public Class Frm_CreaProductos_04_CodAlternativo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Kopral As String
    Dim _Koen As String

    Dim _Grabar As Boolean
    Dim _Eliminado As Boolean

    Dim _RowProducto As DataRow
    Dim _RowTabcodal As DataRow

    Dim _Cl_CompUdMedidas As New Bk_Comporamiento_UdMedidas.Cl_CompUdMedidas
    Dim _NNmarca As New Bk_Comporamiento_UdMedidas.Nmarca

    Enum Enum_Accion
        Solo_Codigo_De_Barras
        Codigo_Barras_Proveedor
        Ambos
    End Enum

    Dim _Accion As Enum_Accion

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property RowTabcodal As DataRow
        Get
            Return _RowTabcodal
        End Get
        Set(value As DataRow)
            _RowTabcodal = value
        End Set
    End Property

    Public Property Eliminado As Boolean
        Get
            Return _Eliminado
        End Get
        Set(value As Boolean)
            _Eliminado = value
        End Set
    End Property

    Public Property UsarNMarcaDeKOPR As Boolean


    Public Sub New(_Codigo As String, _Kopral As String, _Koen As String, _Accion As Enum_Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

        Me._Codigo = _Codigo
        Me._Kopral = _Kopral
        Me._Koen = _Koen

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_CodigoDescripcion.Text = _RowProducto.Item("KOPR").ToString.Trim & " - " & _RowProducto.Item("NOKOPR").ToString.Trim

        Dim _Ud01pr = _RowProducto.Item("UD01PR")
        Dim _Ud02pr = _RowProducto.Item("UD02PR")

        Txt_Ud1.Text = _Ud01pr
        Txt_Ud2.Text = _Ud02pr

        Txt_Rlud.Text = _RowProducto.Item("RLUD")

        Txt_Nokopral.Text = _RowProducto.Item("NOKOPR").ToString.Trim

        Btn_Eliminar.Visible = False

        Dim _Arr_Comportamiento(,) As String = {
                                    {1, "1. Solicitar unidad en que se hará la transacción"},
                                    {2, "2. Comprar en 1era. Udad. Vender en 1era. Udad."},
                                    {3, "3. Comprar en 2da. Udad. Vender en 1era. Udad."},
                                    {4, "4. Comprar en 1era. Udad. Vender en 2da. Udad."},
                                    {5, "5. Comprar en 2da. Udad. Vender en 2da. Udad."},
                                    {6, "6. Solicitar Udad. si es compra, Vender en 1era. Udad."},
                                    {7, "7. Solicitar Udad. si es compra, Vender en 2da. Udad."},
                                    {8, "8. Comprar en 1era. Udad. Solicitar Udad. si es venta"},
                                    {9, "9. Comprar en 2da. Udad. Solicitar Udad. si es venta"},
                                    {10, "10. Utilizar la unidad indivisible (solo para RTU Constante)"},
                                    {11, "11. Vender en 1era. Udad. Sin dividir 2da. Udad"}}
        Sb_Llenar_Combos(_Arr_Comportamiento, Cmb_Nmarca_Comportamiento)
        Cmb_Nmarca_Comportamiento.SelectedValue = 1

        Dim _Arr_Tratamiento(,) As String = {
                            {1, "1. Caso normal, respetar RTU definida"},
                            {2, "2. Solicitar Ancho, Largo y Alto para obtener cantidad 1era. Udad"},
                            {3, "3. Solicitar Ancho y Largo para obtener cantidad 1era. Udad. (MT2)"},
                            {4, "4. Solicitar Ancho y Largo para obtener cantidad 1era. Udad. (CM2)"},
                            {5, "5. Solicitar cantidad solo en Udad. seleccionada y calcular por RTU la otra Udad."},
                            {6, "6. Calcular RTU en forma invertida"},
                            {7, "7. Solicitar cantidad para ambas unidades del producto"},
                            {8, "8. Solicitar RTU del producto"},
                            {9, "9. RTU variable"},
                            {10, "10. RTU constante"}}
        Sb_Llenar_Combos(_Arr_Tratamiento, Cmb_Nmarca_Tratamiento)
        Cmb_Nmarca_Tratamiento.SelectedValue = 1

        Txt_Kopral.ButtonCustom.Visible = False

        If Not String.IsNullOrEmpty(_Kopral) Then

            Consulta_sql = "Select * From TABCODAL Where KOPR = '" & _Codigo & "' And KOPRAL = '" & _Kopral & "' And KOEN = '" & _Koen.Trim & "'"
            _RowTabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowTabcodal) Then

                Txt_Nokopral.Text = _RowTabcodal.Item("NOKOPRAL").ToString.Trim

                Dim _Nmarca = NuloPorNro(_RowTabcodal.Item("NMARCA").ToString.Trim, "")

                _NNmarca = _Cl_CompUdMedidas.Fx_Decifra_Nmarca(_Nmarca)

                Cmb_Nmarca_Tratamiento.SelectedValue = CInt(_NNmarca.Tratamiento)
                Cmb_Nmarca_Comportamiento.SelectedValue = CInt(_NNmarca.Comportamiento)

                Chk_Conmulti.Checked = _RowTabcodal.Item("CONMULTI")

                Txt_Cantmincom.Text = NuloPorNro(_RowTabcodal.Item("CANTMINCOM"), 0)
                Txt_Multdecom.Text = NuloPorNro(_RowTabcodal.Item("MULTDECOM"), 0)
                Txt_Multiplo.Text = NuloPorNro(_RowTabcodal.Item("MULTIPLO"), 0)
                Txt_Txtmulti.Text = NuloPorNro(_RowTabcodal.Item("TXTMULTI"), "")

                Txt_Aux01.Text = _RowTabcodal.Item("AUX01").ToString.Trim
                Txt_Aux02.Text = _RowTabcodal.Item("AUX02").ToString.Trim
                Txt_Aux03.Text = _RowTabcodal.Item("AUX03").ToString.Trim
                Txt_Aux04.Text = _RowTabcodal.Item("AUX04").ToString.Trim
                Txt_Aux05.Text = _RowTabcodal.Item("AUX05").ToString.Trim
                Txt_Aux06.Text = _RowTabcodal.Item("AUX06").ToString.Trim

                Txt_Kopral2.Text = _RowTabcodal.Item("KOPRAL2").ToString.Trim
                Txt_Kopral3.Text = _RowTabcodal.Item("KOPRAL3").ToString.Trim
                Txt_Kopral4.Text = _RowTabcodal.Item("KOPRAL4").ToString.Trim
                Txt_Kopral5.Text = _RowTabcodal.Item("KOPRAL5").ToString.Trim

                Txt_CodigoQR.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_CodQR", "CodigoQR", "Kopral = '" & _Kopral & "'")

                Stab_3QR.Visible = Not String.IsNullOrEmpty(Txt_CodigoQR.Text)
                Btn_CodQR.Enabled = String.IsNullOrEmpty(Txt_CodigoQR.Text)

                Btn_Eliminar.Visible = True

                Txt_Kopral.ButtonCustom.Visible = True

            End If

        End If

        Cmb_Nmarca_Comportamiento.Enabled = (_Ud01pr <> _Ud02pr)
        Cmb_Nmarca_Tratamiento.Enabled = (_Ud01pr <> _Ud02pr)

        Txt_Kopral.ReadOnly = Not String.IsNullOrEmpty(_Kopral)

        Me._Accion = _Accion

        Select Case _Accion
            Case Enum_Accion.Codigo_Barras_Proveedor
                Grupo_Proveedor.Enabled = True
                Txt_Koen.Enabled = True
            Case Enum_Accion.Solo_Codigo_De_Barras
                Grupo_Proveedor.Enabled = False
                Txt_Koen.Enabled = False
            Case Enum_Accion.Ambos
                Grupo_Proveedor.Enabled = True
                Txt_Koen.Enabled = True
        End Select

        Dim _Arr_Tipo_Entidad(,) As String = {{"1", _Ud01pr}, {"2", _Ud02pr}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Unimulti)
        Cmb_Unimulti.SelectedValue = 1

        Txt_CodigoQR.ReadOnly = True
        Me.Text = "Verificación de código alternativo, SKU: " & _Codigo

    End Sub

    Private Sub Frm_CrearProductos_04_CodAlternativo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If UsarNMarcaDeKOPR Then

            Dim _Nmarca = NuloPorNro(_RowProducto.Item("NMARCA").ToString.Trim, "")
            Dim _Ud01pr = _RowProducto.Item("UD01PR")
            Dim _Ud02pr = _RowProducto.Item("UD02PR")

            _NNmarca = _Cl_CompUdMedidas.Fx_Decifra_Nmarca(_Nmarca)

            Cmb_Nmarca_Tratamiento.SelectedValue = CInt(_NNmarca.Tratamiento)
            Cmb_Nmarca_Comportamiento.SelectedValue = CInt(_NNmarca.Comportamiento)

            Cmb_Nmarca_Comportamiento.Enabled = (_Ud01pr <> _Ud02pr)
            Cmb_Nmarca_Tratamiento.Enabled = (_Ud01pr <> _Ud02pr)

        End If

        SuperTabControl1.SelectedTabIndex = 0

        Txt_RazonSocial.Text = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _Koen & "'")
        txtsigla.Text = _Sql.Fx_Trae_Dato("MAEEN", "SIEN", "KOEN = '" & _Koen & "'")

        Txt_Koen.Text = _Koen
        Txt_Kopral.Text = _Kopral

        AddHandler Chk_Conmulti.CheckedChanged, AddressOf Sb_Habilitar_Multiplos

        AddHandler Txt_Multiplo.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Cantmincom.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Multdecom.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        Sb_Habilitar_Multiplos()

        Me.ActiveControl = Txt_Kopral

    End Sub

    Public Function Fx_Revisar_Cod_Alternativo(_Formulario As Form,
                                               _CodigoAlternativo As String,
                                               _CodProveedor As String,
                                               Optional _Mostrar_Mensaje As Boolean = True) As Boolean

        If String.IsNullOrEmpty(_CodigoAlternativo) Then
            MessageBoxEx.Show(_Formulario, "Código alternativo no puede estar vacío",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Consulta_sql = "Select KOPRAL,KOEN,KOPR As 'Codigo',NOKOPRAL," &
                           "IsNull((Select NOKOPR From MAEPR Mp Where Mp.KOPR = Td.KOPR),NOKOPRAL) as 'Descripcion'" & vbCrLf &
                           "From TABCODAL Td" & vbCrLf &
                           "Where Td.KOEN = '" & _CodProveedor & "' And Td.KOPRAL = '" & _CodigoAlternativo & "'"
            Dim _TblPr As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_TblPr.Rows.Count) Then

                Dim _Codigo As String = _TblPr.Rows(0).Item("Codigo")
                Dim _Descripcion As String = _TblPr.Rows(0).Item("Descripcion")
                If _Mostrar_Mensaje Then
                    MessageBoxEx.Show(_Formulario, "Código de producto ya existe en el sistema" & vbCrLf & vbCrLf &
                                      "Código : " & _Codigo & vbCrLf &
                                      "Descripción: " & _Descripcion, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Return True
            End If
        End If

    End Function

    Private Sub BtnBuscarEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarEntidad.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then

            Txt_RazonSocial.Text = Fm.Pro_RowEntidad.Item("NOKOEN")
            txtsigla.Text = Fm.Pro_RowEntidad.Item("SIEN")
            Txt_Koen.Text = Fm.Pro_RowEntidad.Item("KOEN")
            _Koen = Fm.Pro_RowEntidad.Item("KOEN")

            Txt_Kopral.Focus()
            Txt_Kopral.SelectAll()

        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Habilitar_Multiplos()

        Cmb_Unimulti.Enabled = Chk_Conmulti.Checked
        Txt_Multiplo.Enabled = Chk_Conmulti.Checked
        Txt_Txtmulti.Enabled = Chk_Conmulti.Checked

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Rtu As String = De_Num_a_Tx_01(_RowProducto.Item("RLUD"), False, 5)

        Dim _Kopr As String = _Codigo
        Dim _Kopral As String = Txt_Kopral.Text.Trim
        Dim _Nokopral As String = Txt_Nokopral.Text.Trim
        Dim _Koen As String = Txt_Koen.Text.Trim
        Dim _Nmarca As String = _Cl_CompUdMedidas.Fx_Trae_NMARCA(CInt(Cmb_Nmarca_Comportamiento.SelectedValue), CInt(Cmb_Nmarca_Tratamiento.SelectedValue))

        Dim _Cantmincom As String = Txt_Cantmincom.Text
        Dim _Multdecom As String = Txt_Multdecom.Text

        Dim _Kopral2 As String = Txt_Kopral2.Text.Trim
        Dim _Kopral3 As String = Txt_Kopral3.Text.Trim
        Dim _Kopral4 As String = Txt_Kopral4.Text.Trim
        Dim _Kopral5 As String = Txt_Kopral5.Text.Trim

        Dim _Aux01 As String = Txt_Aux01.Text.Trim
        Dim _Aux02 As String = Txt_Aux02.Text.Trim
        Dim _Aux03 As String = Txt_Aux03.Text.Trim
        Dim _Aux04 As String = Txt_Aux04.Text.Trim
        Dim _Aux05 As String = Txt_Aux05.Text.Trim
        Dim _Aux06 As String = Txt_Aux06.Text.Trim

        Dim _Conmulti As Integer = Convert.ToInt32(Chk_Conmulti.Checked)

        Dim _Unimulti As Integer = Cmb_Unimulti.SelectedValue
        Dim _Multiplo As String = Txt_Multiplo.Text
        Dim _Txtmulti As String = Txt_Txtmulti.Text.Trim

        Dim _CodigoQR As String = Txt_CodigoQR.Text

        If String.IsNullOrEmpty(_Kopral) Then
            MessageBoxEx.Show(Me, "Código alternativo no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kopral.Focus()
            Return
        End If

        If _Accion = Enum_Accion.Codigo_Barras_Proveedor Then
            If String.IsNullOrEmpty(_Koen) Then
                MessageBoxEx.Show(Me, "Falta el proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Chk_Conmulti.Checked And Not CBool(Val(_Multiplo)) Then
            MessageBoxEx.Show(Me, "El multiplo no puede estar en cero si esta seleccionada la opción Utilizar múltiplo de unidad",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not Chk_Conmulti.Checked Then
            _Multiplo = 0
            _Txtmulti = String.Empty
        End If

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & Txt_Kopral.Text.Trim & "'"))

        If _Reg Then
            MessageBoxEx.Show(Me, "Código de acceso alternativo no puede ser igual" & vbCrLf &
                              "al código principal de un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kopral.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Me._Kopral) Then

            Consulta_sql = "Select KOPRAL,KOEN,KOPR As 'Codigo',NOKOPRAL," &
                       "IsNull((Select NOKOPR From MAEPR Mp Where Mp.KOPR = Td.KOPR),NOKOPRAL) as 'Descripcion'" & vbCrLf &
                       "From TABCODAL Td" & vbCrLf &
                       "Where Td.KOEN = '" & _Koen & "' And Td.KOPRAL = '" & _Kopral & "'"
            Dim _TblPr As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_TblPr.Rows.Count) Then

                Dim _Codigo As String = _TblPr.Rows(0).Item("Codigo")
                Dim _Descripcion As String = _TblPr.Rows(0).Item("Descripcion")

                MessageBoxEx.Show(Me, "El código alternativo " & _Kopral & " ya existe en el sistema para el siguiente producto:" & vbCrLf & vbCrLf &
                              "Código : " & _Codigo & vbCrLf &
                              "Descripción: " & _Descripcion, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If Not String.IsNullOrEmpty(_CodigoQR) Then

                _Reg = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_CodQR", "CodigoQR = '" & _CodigoQR & "'"))

                If _Reg Then
                    MessageBoxEx.Show(Me, "Código QR ya esta resgistrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

            End If

        End If

        If Not String.IsNullOrEmpty(_CodigoQR) Then

            If String.IsNullOrEmpty(Me._Kopral) Then

                _Reg = CBool(_Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & _Kopral & "' And KOEN = ''"))

                If _Reg Then
                    _Kopral = Fx_Kopral_Alearorios("QRBk")
                    Txt_Kopral.Text = _Kopral
                End If

            End If

        End If

        Consulta_sql = "Delete TABCODAL Where KOPRAL = '" & _Kopral & "' And KOPR = '" & _Kopr & "' And KOEN = '" & _Koen & "'" &
                   vbCrLf &
                   "Insert Into TABCODAL (KOPRAL,KOPR,NOKOPRAL,KOEN,NMARCA,CANTMINCOM,MULTDECOM,KOPRAL2,KOPRAL3,KOPRAL4,KOPRAL5" &
                   ",AUX01,AUX02,AUX03,AUX04,AUX05,AUX06,CONMULTI,UNIMULTI,MULTIPLO,TXTMULTI) Values " &
                   "('" & _Kopral & "','" & _Kopr & "','" & _Nokopral & "','" & _Koen & "','" & _Nmarca & "'," & _Cantmincom & "," & _Multdecom &
                   ",'" & _Kopral2 & "','" & _Kopral3 & "','" & _Kopral4 & "','" & _Kopral5 & "'" &
                   ",'" & _Aux01 & "','" & _Aux02 & "','" & _Aux03 & "','" & _Aux04 & "','" & _Aux05 & "','" & _Aux06 &
                   "'," & _Conmulti & "," & _Unimulti & "," & _Multiplo & ",'" & _Txtmulti & "')" & vbCrLf

        If Stab_3QR.Visible Then

            Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_CodQR Where CodigoQR = '" & _CodigoQR & "' And Kopral = '" & _Kopral & "'" & vbCrLf &
                            "Insert Into " & _Global_BaseBk & "Zw_Prod_CodQR (CodigoQR,Kopral) Values ('" & _CodigoQR & "','" & _Kopral & "')"

        End If

        Dim _SqlQueryExt = String.Empty

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            _SqlQueryExt = Consulta_sql
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Grabar = True

        Consulta_sql = "Select * From TABCODAL Where KOPRAL = '" & _Kopral & "' And KOEN = '" & _Koen & "' And KOPR = '" & _Kopr & "'"
        RowTabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set CodAlternativo = '" & _Kopral & "'" & vbCrLf &
                       "Where Codigo = '" & _Kopr & "' And Proveedor = '" & _Koen & "'" &
                       vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_ListaPreCosto Set Codigo = '" & _Kopr &
                       "',Descripcion = '" & _Kopral & "', Rtu = " & _Rtu & vbCrLf &
                       "Where CodAlternativo = '" & _Kopral & "' And Proveedor = '" & _Koen & "'"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            'Sb_EjecConsultaBasesExternas(Consulta_sql)
            _SqlQueryExt += vbCrLf & vbCrLf & Consulta_sql

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion where Clas_unica = 1" & vbCrLf &
                           "And Codigo = '" & _Kopr & "' And DescripcionBusqueda = '" & _Nokopral & "'" & vbCrLf & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Clas_unica)" & vbCrLf &
                           "Values ('" & _Kopr & "',0,'" & _Nokopral & "',1)"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                'Sb_EjecConsultaBasesExternas(Consulta_sql)
                _SqlQueryExt += vbCrLf & vbCrLf & Consulta_sql
            End If

        End If

        '-- HAY UN ERROR, EL SISTEMA NO DEBERIA GRABAR COIDGOS ALTERNATIVOS EN LA BASE EXTERNA SI ES QUE EL PRODUCTO AUN NO EXISTE EN LA MAEPR.

        _SqlQueryExt = "IF EXISTS (SELECT * FROM MAEPR WHERE KOPR = '" & _Kopr & "')" & vbCrLf &
                       "Begin" & vbCrLf &
                       _SqlQueryExt & vbCrLf &
                       "End"

        Sb_EjecConsultaBasesExternas(Me, _SqlQueryExt, True)

        Me.Close()

    End Sub

    Private Sub Txt_Kopral_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Kopral.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Grabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Frm_CreaProductos_04_CodAlternativo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub SuperTabItem1_Click(sender As Object, e As EventArgs) Handles SuperTabItem1.Click
        Txt_Kopral.Focus()
    End Sub

    Private Sub Btn_CodQR_Click(sender As Object, e As EventArgs) Handles Btn_CodQR.Click

        Dim _Aceptar As Boolean
        Dim _CodigoQR As String = Txt_CodigoQR.Text

        _Aceptar = InputBox_Bk(Me, "Ingrese el código QR", "Código QR", _CodigoQR, False,, 300, True, _Tipo_Imagen.CodQR)

        If _Aceptar Then

            If _CodigoQR.Contains("<STX>") And _CodigoQR.Contains("<ETX>") Then

                Dim _CodigoLeido As String = _CodigoQR

                Dim _CodPaso As String = Replace(_CodigoLeido, "<STX>", "")
                Dim _Cola As String
                Dim _SeparaCod() As String = Split(_CodPaso, "<ETX>", 2)

                _CodPaso = _SeparaCod(0)
                _Cola = _SeparaCod(1)

                _CodigoQR = _CodPaso

            End If

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_CodQR", "CodigoQR = '" & _CodigoQR & "'"))

            If _Reg Then
                MessageBoxEx.Show(Me, "Código QR ya esta resgistrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            'Dim _Rd As Random
            'Dim _NroRd As Double = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_CodQR", "1>0") + 1
            '_Rd = New Random
            '_NroRd += _Rd.Next(1, 999999)

            'Dim _Korpral As String = "QRBk" & numero_(_NroRd, 10)
            '_Kopral = _Sql.Fx_Trae_Dato("TABCODAL", "MAX(KOPRAL)", "KOPRAL Like 'QRBk%'").ToString.Trim

            'If String.IsNullOrEmpty(_Kopral) Then
            '    _Kopral = "QRBk0000000000"
            'End If

            '_Kopral = Fx_Proximo_NroDocumento(_Kopral, _Kopral.Length)

            Dim _NewKopral = Fx_Kopral_Alearorios("QRBk")
            Txt_Kopral.Text = _NewKopral
            'Txt_Kopral.Enabled = False
            Txt_Kopral.ReadOnly = True
            Txt_CodigoQR.Text = _CodigoQR
            Stab_3QR.Visible = True

        End If

    End Sub

    Private Sub Btn_Quitar_QR_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_QR.Click

        SuperTabControl1.SelectedTabIndex = 0
        Stab_3QR.Visible = False
        Txt_CodigoQR.Text = String.Empty
        Txt_Kopral.Text = String.Empty
        'Txt_Kopral.Enabled = True
        Txt_Kopral.ReadOnly = False
        Txt_Kopral.Focus()

    End Sub

    Sub Sb_Eliminar_Codigo()

        If Fx_Tiene_Permiso(Me, "Prod019") Then

            Dim _Kopr As String = _RowTabcodal.Item("KOPR")
            Dim _Kopral As String = _RowTabcodal.Item("KOPRAL")
            Dim _Koen As String = _RowTabcodal.Item("KOEN")
            Dim _CodigoQR As String = Txt_CodigoQR.Text

            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar este código?",
                                 "Eliminar código", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Delete TABCODAL" & vbCrLf &
                               "Where KOPRAL = '" & _Kopral & "' And KOEN = '" & _Koen & "' And KOPR = '" & _Kopr & "'" & vbCrLf & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion where Clas_unica = 1" & vbCrLf &
                               "And Codigo = '" & _Kopr & "' And DescripcionBusqueda = '" & _Kopral & "'" &
                               vbCrLf &
                               vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_ListaPreCosto" & vbCrLf &
                               "Where CodAlternativo = '" & _Kopral & "' And Proveedor = '" & _Koen & "'" &
                               vbCrLf &
                               vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Prod_CodQR Where CodigoQR = '" & _CodigoQR & "'"

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Sb_EjecConsultaBasesExternas(Me, Consulta_sql, True)

                _Eliminado = True
                Me.Close()

            End If

        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        Sb_Eliminar_Codigo()
    End Sub

    Function Fx_Kopral_Alearorios(_Sufijo As String) As String

        _Sufijo = "QRBk"

        Dim _Rd As Random
        Dim _NroRd As Double = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_CodQR", "1>0") + 1
        _Rd = New Random
        _NroRd += _Rd.Next(1, 9999999)

        Dim _NewKopral As String = "QRBk" & numero_(_NroRd, 10)

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & _NewKopral & "' And KOEN = ''"))

        If _Reg Then
            _NewKopral = Fx_Kopral_Alearorios(_Sufijo)
        End If

        Return _NewKopral

    End Function

    Private Sub Txt_Kopral_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Kopral.ButtonCustomClick

        Dim Copiar = Txt_Kopral.Text
        Clipboard.SetText(Copiar)

        MessageBoxEx.Show(Me, "Código copiado en el portapapeles", "Portapapeles", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Txt_Koen_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Koen.ButtonCustom2Click
        _Koen = String.Empty
        Txt_RazonSocial.Text = String.Empty
        txtsigla.Text = String.Empty
        Txt_Koen.Text = String.Empty
    End Sub

    Private Sub Txt_Koen_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Koen.ButtonCustomClick
        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then

            Txt_RazonSocial.Text = Fm.Pro_RowEntidad.Item("NOKOEN")
            txtsigla.Text = Fm.Pro_RowEntidad.Item("SIEN")
            Txt_Koen.Text = Fm.Pro_RowEntidad.Item("KOEN")
            _Koen = Fm.Pro_RowEntidad.Item("KOEN")

            Txt_Kopral.Focus()
            Txt_Kopral.SelectAll()

        End If

        Fm.Dispose()
    End Sub




End Class
