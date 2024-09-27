Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_SolCreaProducto

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Grabar As Boolean
    Dim _Moneda As String

    Dim _Cl_SolCreaProducto As New Cl_SolCreaProducto

    Dim _Row_Configuracion_BkCompra As DataRow
    Dim _TblProductosEnList As DataTable
    Dim _SOC_Prod_Crea_Solo_Marcas_Proveedor

    Dim SuperFamilia, Familia, SubFamilia As String
    Dim ListaCostoPro As String

    Dim _Id As Integer
    Dim Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf

    Public Property Pro_Moneda As String
        Get
            Return _Moneda
        End Get
        Set(value As String)
            _Moneda = Trim(value)
        End Set
    End Property

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Row_Proveedor As DataRow
        Get
            Return _Cl_SolCreaProducto.Row_Proveedor
        End Get
        Set(value As DataRow)
            _Cl_SolCreaProducto.Row_Proveedor = value
        End Set
    End Property

    Public Property Pro_Cl_SolCreaProducto As Cl_SolCreaProducto
        Get
            Return _Cl_SolCreaProducto
        End Get
        Set(value As Cl_SolCreaProducto)
            _Cl_SolCreaProducto = value
        End Set
    End Property

    Public Sub New(Id As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _SOC_Prod_Crea_Solo_Marcas_Proveedor = _Global_Row_Configuracion_General.Item("SOC_Prod_Crea_Solo_Marcas_Proveedor")

        _Cl_SolCreaProducto.Sb_Llenar_RowProducto(Id)
        _Id = _Cl_SolCreaProducto.Id_CPr

        Sb_Llenar_Combo()

    End Sub

    Private Sub Frm_SolicitudCompra_Z_CrearProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_Nokopr

        AddHandler Cmb_Ud01pr.SelectedValueChanged, AddressOf Sb_Cambio_Ud1
        AddHandler Cmb_Ud02pr.SelectedValueChanged, AddressOf Sb_Cambio_Ud2

        Txt_Nokopr.MaxLength = _Global_Row_Configuracion_General.Item("SOC_Prod_Crea_Max_Carac_Nom")

        Chk_Pr_Desc_Producto_Solo_Mayusculas.Checked = _Global_Row_Configuracion_General.Item("Pr_Desc_Producto_Solo_Mayusculas")

        If Chk_Pr_Desc_Producto_Solo_Mayusculas.Checked Then
            Txt_Nokopr.CharacterCasing = CharacterCasing.Upper
        End If

        AddHandler Chk_Pr_Desc_Producto_Solo_Mayusculas.CheckedChanging, AddressOf Sb_Chk_Pr_Desc_Producto_Solo_Mayusculas_CheckedChanging
        AddHandler Chk_Pr_Desc_Producto_Solo_Mayusculas.CheckedChanged, AddressOf Sb_Chk_Pr_Desc_Producto_Solo_Mayusculas_CheckedChanged

        Sb_llenar_Formulario()

    End Sub

    Sub Sb_llenar_Formulario()

        'LblUd1.Text = "Costo Unidad 1 " & _Moneda
        'LblUd2.Text = "Costo Unidad 2 " & _Moneda

        Txt_Nokopr.Text = _Cl_SolCreaProducto.Row_NewMaepr.Item("Nokopr")

        Txt_Codproveedor.Text = _Cl_SolCreaProducto.Row_Proveedor.Item("KOEN")
        Txt_RazonProveedor.Text = _Cl_SolCreaProducto.Row_Proveedor.Item("NOKOEN")
        Txt_Kopral.Text = _Cl_SolCreaProducto.Row_NewMaepr.Item("Kopral")

        Txt_Rlud.Text = _Cl_SolCreaProducto.Row_NewMaepr.Item("Rlud")
        Cmb_Tipr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Tipr")

        Txt_Observaciones.Text = _Cl_SolCreaProducto.Row_NewMaepr.Item("Observaciones")

        Cmb_Mrpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Mrpr")
        Cmb_Rupr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Rupr")
        Cmb_Clalibpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Clalibpr")
        Cmb_Fmpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Fmpr")
        Cmb_Pfpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Pfpr")
        Cmb_Hfpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Hfpr")
        Cmb_Kofupr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Kofupr")
        Cmb_Zonapr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Zonapr")

        Txt_CostoUd1.Tag = _Cl_SolCreaProducto.Row_NewMaepr.Item("CostoUd1")
        Txt_CostoUd2.Tag = _Cl_SolCreaProducto.Row_NewMaepr.Item("CostoUd2")

        Txt_CostoUd1.Text = _Moneda & " " & FormatNumber(Txt_CostoUd1.Tag, 0)
        Txt_CostoUd2.Text = _Moneda & " " & FormatNumber(Txt_CostoUd2.Tag, 0)

    End Sub

    Private Sub TxtCostoUd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CostoUd1.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))

        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True

            Txt_CostoUd1.Tag = Val(Txt_CostoUd1.Text)
            Txt_CostoUd1.Text = _Moneda & " " & FormatNumber(Txt_CostoUd1.Tag, 0)

            Txt_CostoUd2.Tag = Math.Round(De_Txt_a_Num_01(Txt_CostoUd1.Tag, 3) * De_Txt_a_Num_01(Txt_Rlud.Text, 3), 2)
            Txt_CostoUd2.Text = _Moneda & " " & FormatNumber(Txt_CostoUd2.Tag, 0)
            ' TxtCantUD1.Text = Math.Round(Val(TxtCantUD2.Text) * RTU, 3)

            'MsgBox(Nivel1)
        ElseIf e.KeyChar = "."c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Private Sub TxtCostoUd2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CostoUd2.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))

        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True

            Txt_CostoUd1.Tag = Math.Round(De_Txt_a_Num_01(Txt_CostoUd2.Tag, 3) / De_Txt_a_Num_01(Txt_Rlud.Text, 3), 2)
            Txt_CostoUd1.Text = _Moneda & " " & FormatNumber(Txt_CostoUd1.Tag, 0)

            'MsgBox(Nivel1)
        ElseIf e.KeyChar = "."c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Private Sub Txtrtu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Rlud.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Dim _Problem As Boolean
        Dim _Problema As String
        Dim _Sugerencia As String

        If String.IsNullOrEmpty(Trim(Txt_Nokopr.Text)) Then
            _Problema = "FALTA DESCRIPCION DEL PRODUCTO"
            Sb_Problema(Txt_Nokopr, _Problema, 3)
            Return
        End If

        'If De_Txt_a_Num_01(Txt_CostoUd1.Tag) = 0 Or De_Txt_a_Num_01(Txt_CostoUd2.Tag) = 0 Then
        '    _Problema = "FALTA EL COSTO DEL PRODUCTO"
        '    Sb_Problema(Txt_CostoUd1, _Problema, 3)
        '    Return
        'End If

        If String.IsNullOrEmpty(Trim(Txt_Kopral.Text)) Then

            If Not Fx_Tiene_Permiso(Me, "Comp0030") Then
                _Problema = "FALTA CODIGO DEL PROVEEDOR" & vbCrLf & "CODIGO ALTERNATIVO"
                'Sb_Problema(Txt_Kopral, _Problema, 3)
                Return
            End If

        Else

            Consulta_sql = "Select * From TABCODAL" & vbCrLf &
                           "Where KOEN = '" & Txt_Codproveedor.Text & "' AND KOPRAL = '" & Txt_Kopral.Text & "' And KOPR <> ''"
            Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SolCreapr",
                                                    "Id_CPr <> " & _Cl_SolCreaProducto.Id_CPr & " And Codproveedor = '" & Txt_Codproveedor.Text & "' And Kopral = '" & Txt_Kopral.Text & "'")

            Dim _Existe_Kopral As Boolean '= IsNothing(_Row_Tabcodal)
            _Existe_Kopral = CBool(_Reg)

            If Not _Existe_Kopral Then

                If Not IsNothing(_Row_Tabcodal) Then

                    Dim _CodigoRd = _Row_Tabcodal.Item("KOPR")
                    Dim _DescripcionRd = _Row_Tabcodal.Item("NOKOPRAL")

                    MessageBoxEx.Show(Me, "Código de producto ya existe en el sistema, Código Random : " & _CodigoRd & vbCrLf &
                       "Descripción: " & _DescripcionRd, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return

                Else

                    If Not (_TblProductosEnList Is Nothing) Then

                        If Not Fx_Tiene_Permiso(Me, "Comp0030", , True) Then

                            For Each _Fila As DataRow In _TblProductosEnList.Rows

                                Dim _Nuevo_Item = _Fila.Item("Nuevo_Item")
                                Dim _CodigoAlternativo As String = Trim(NuloPorNro(_Fila.Item("CodigoAlternativo"), ""))
                                Dim _Descripcion As String = Trim(NuloPorNro(_Fila.Item("Descripcion"), ""))

                                If Not _Nuevo_Item Then

                                    If _CodigoAlternativo = Trim(Txt_Kopral.Text) Then

                                        MessageBoxEx.Show(Me, "Código de producto ya esta en la lista de compra" & vbCrLf &
                                                      "Descripción en lista: " & _Descripcion & vbCrLf & vbCrLf &
                                                      "No puede mandar a crear 2 productos con el mismo código alternativo",
                                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Txt_Kopral.Focus()
                                        Return

                                    End If

                                End If

                            Next

                        End If

                    End If

                End If

            Else

                MessageBoxEx.Show(Me, "Este producto, según su código alternativo ya fue enviado a crear", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If


        End If

        If String.IsNullOrEmpty(Trim(Cmb_Mrpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Comp0031") Then
                'MessageBoxEx.Show(Me, "Falta la Marca", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Problema = "FALTA LA MARCA"
                'Sb_Problema(Cmb_Mrpr, _Problema, 3)
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Rupr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Comp0032") Then
                'MessageBoxEx.Show(Me, "Falta el Rubro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Problema = "FALTA EL RUBRO"
                'Sb_Problema(Cmb_Rupr, _Problema, 3)
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Fmpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Comp0033") Then
                'MessageBoxEx.Show(Me, "Falta la Super Familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Problema = "FALTA LA SUPER FAMILIA"
                'Sb_Problema(Cmb_Fmpr, _Problema, 3)
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Pfpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Comp0034") Then
                'MessageBoxEx.Show(Me, "Falta la Familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Problema = "FALTA LA FAMILIA"
                'Sb_Problema(Cmb_Pfpr, _Problema, 3)
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Hfpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Comp0035") Then
                'MessageBoxEx.Show(Me, "Falta la Sub Familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Problema = "FALTA LA SUB FAMILIA"
                'Sb_Problema(Txt_Kopral, _Problema, 3)
                Return
            End If
        End If



        Dim _Ud1 As String = Trim(Cmb_Ud01pr.SelectedValue)
        Dim _Ud2 As String = Trim(Cmb_Ud02pr.SelectedValue)

        If _Ud1 <> _Ud2 And Txt_Rlud.Text = 1 Then

            _Problem = True
            _Problema = "Unidades distintas y Rtu = 1, ¡!"
            _Sugerencia = "Si la Rtu es igual a 1 debe dejar las unidades iguales, " &
            "de lo contrario cambie el valor de la Rtu"

        End If

        If _Ud1 = _Ud2 And Txt_Rlud.Text <> 1 Then

            _Problem = 2
            _Problema = "Unidades iguales y Rtu distinta de 1, ¡!"
            _Sugerencia = "Si la Rtu es distinto a 1 debe dejar las Unidades distintas también"

        End If

        If _Problem Then

            MessageBoxEx.Show(Me, "Hay inconsistencia en las unidades de medida." & vbCrLf &
                       "Problema: " & _Problema & vbCrLf &
                       "Sugerencia: " & _Sugerencia & vbCrLf &
                       "Debe regularizar la situación antes de seguir", "Validación",
                       MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Txt_Rlud.Focus()
            Return

        End If

        If Txt_Rlud.Text <> 1 And Rdb_CompraUd1.Checked = True Then

            If MessageBoxEx.Show(Me, "¡Se sugiere comprar en 2da Unidad y no en 1ra Unidad!" & vbCrLf &
                           "¿Desea corregir esta situación [SI], dejarlo tal cual esta [NO]?", "Verificar unidad de compra",
                       MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                Return
            End If

        End If

        Dim UdCompras As Integer = 1
        If Rdb_CompraUd2.Checked = True Then UdCompras = 2

        _Grabar = True

        If CBool(_Cl_SolCreaProducto.Id_CPr) Then

            If _Cl_SolCreaProducto.Row_NewMaepr.Item("Nokopr") <> Txt_Nokopr.Text Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Codproveedor") <> Txt_Codproveedor.Text Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Kopral") <> Txt_Kopral.Text Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Rlud") <> Txt_Rlud.Text Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Ud01pr") <> _Ud1 Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Ud02pr") <> _Ud2 Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Tipr") <> Cmb_Tipr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Observaciones") <> Txt_Observaciones.Text Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Mrpr") <> Cmb_Mrpr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Rupr") <> Cmb_Rupr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Clalibpr") <> Cmb_Clalibpr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Fmpr") <> Cmb_Fmpr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Pfpr") <> Cmb_Pfpr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Hfpr") <> Cmb_Hfpr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Kofupr") <> Cmb_Kofupr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("Zonapr") <> Cmb_Zonapr.SelectedValue Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("CostoUd1") <> Txt_CostoUd1.Tag Or
               _Cl_SolCreaProducto.Row_NewMaepr.Item("CostoUd2") <> Txt_CostoUd2.Tag Then

                _Grabar = False

            End If

        End If

        _Cl_SolCreaProducto.Row_NewMaepr.Item("Nokopr") = Txt_Nokopr.Text

        _Cl_SolCreaProducto.Row_NewMaepr.Item("Codproveedor") = Txt_Codproveedor.Text
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Kopral") = Txt_Kopral.Text
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Rlud") = Txt_Rlud.Text
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Ud01pr") = _Ud1
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Ud02pr") = _Ud2
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Tipr") = Cmb_Tipr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Observaciones") = Txt_Observaciones.Text
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Mrpr") = Cmb_Mrpr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Rupr") = Cmb_Rupr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Clalibpr") = Cmb_Clalibpr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Fmpr") = Cmb_Fmpr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Pfpr") = Cmb_Pfpr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Hfpr") = Cmb_Hfpr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Kofupr") = Cmb_Kofupr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("Zonapr") = Cmb_Zonapr.SelectedValue
        _Cl_SolCreaProducto.Row_NewMaepr.Item("CostoUd1") = Txt_CostoUd1.Tag
        _Cl_SolCreaProducto.Row_NewMaepr.Item("CostoUd2") = Txt_CostoUd2.Tag

        If _Grabar Then

            If CBool(_Cl_SolCreaProducto.Id_CPr) Then
                _Cl_SolCreaProducto.Fx_Editar_Producto()
            Else
                _Cl_SolCreaProducto.Fx_Crear_Producto()
            End If

        End If

        Me.Close()

    End Sub

    Sub Sb_Problema(ByVal _Objeto As Object, ByVal _Leyenda As String, ByVal _Duracion As Integer)
        Beep()
        ToastNotification.Show(Me, _Leyenda, My.Resources.cross,
                                       _Duracion * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        _Objeto.focus()
    End Sub

    Private Sub Btn_RefrescarMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Marca = NuloPorNro(Cmb_Mrpr.SelectedValue, "")
        caract_combo(Cmb_Mrpr)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT Marca AS Padre,Marca As Hijo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_MrVsPro Where CodProveedor = '" & Txt_Codproveedor.Text & "'" ' WHERE SEMILLA = " & Actividad
        Cmb_Mrpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Mrpr.SelectedValue = _Marca

    End Sub

    Private Sub Btn_Marca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Consulta_sql = "Select top 1 * From MAEEN Where KOEN = '" & Txt_Codproveedor.Text & "'"
        Dim _Tbl_Entidad As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl_Entidad.Rows.Count) Then

            Dim _CodEntidad As String = Trim(_Tbl_Entidad.Rows(0).Item("KOEN"))
            Dim _CodSucursal As String = Trim(_Tbl_Entidad.Rows(0).Item("SUEN"))
            Dim _RazonEntidad As String = Trim(_Tbl_Entidad.Rows(0).Item("NOKOEN"))

            Dim Fm As New Frm_ProveedoresVSMarcas
            Fm.TxtCodigo.Text = _CodEntidad
            Fm.Txtdescripcion.Text = _RazonEntidad

            Fm.ShowDialog(Me)

        End If

    End Sub

    Public Sub Sb_Llenar_Combo()

        caract_combo(Cmb_Ud01pr)
        Consulta_sql = "SELECT CodigoTabla AS Padre,Rtrim(Ltrim(CodigoTabla))+' - '+NombreTabla AS Hijo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'RTU'"
        Cmb_Ud01pr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmb_Ud02pr)
        Consulta_sql = "SELECT CodigoTabla AS Padre,Rtrim(Ltrim(CodigoTabla))+' - '+NombreTabla AS Hijo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'RTU'"
        Cmb_Ud02pr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        Cmb_Ud01pr.SelectedValue = "UN"
        Cmb_Ud02pr.SelectedValue = "UN"
        Txt_Rlud.Text = 1


        Dim _Arr_Tipo_Productos(,) As String = {{"FIN", "Insumo productivo"},
                                           {"FLN", "Artículo multiproposito"},
                                           {"FPN", "Articulo estándar"},
                                           {"FPS", "Articulo seriado"},
                                           {"FUN", "Herramienta estándar"},
                                           {"FUS", "Herramienta seriada"},
                                           {"GEN", "Génerico o agrupador de artículos"},
                                           {"SSN", "Servicios y similares"}}
        Sb_Llenar_Combos(_Arr_Tipo_Productos, Cmb_Tipr)
        Cmb_Tipr.SelectedValue = "FPN"

        Sb_Cargar_Combos_Clasificaciones()

    End Sub

    Private Sub Sb_Cambio_Ud1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Lblunidad1.Text = Cmb_Ud01pr.SelectedValue
    End Sub

    Private Sub Sb_Cambio_Ud2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Lblunidad2.Text = Cmb_Ud02pr.SelectedValue
    End Sub

    Private Sub Btn_Buscar_Cliente_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Cliente.Click

        Dim _RowProveedor As DataRow
        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
        Fm_Ent.Text = "SELECCIONE EL PROVEEDOR"
        Fm_Ent.ShowDialog(Me)

        If Fm_Ent.Pro_Entidad_Seleccionada Then _RowProveedor = Fm_Ent.Pro_RowEntidad

        Fm_Ent.Dispose()

        If Not IsNothing(_RowProveedor) Then

            Txt_Codproveedor.Text = _RowProveedor.Item("KOEN")
            Txt_RazonProveedor.Text = _RowProveedor.Item("NOKOEN")
            Txt_Kopral.Focus()

        End If

    End Sub

    Private Sub Txt_CostoUd1_Validated(sender As Object, e As EventArgs) Handles Txt_CostoUd1.Validated

        'Txt_CostoUd1.Tag = Val(Txt_CostoUd1.Text)
        Txt_CostoUd1.Text = _Moneda & " " & FormatNumber(Txt_CostoUd1.Tag, 0)

    End Sub

    Private Sub Txt_CostoUd2_Validated(sender As Object, e As EventArgs) Handles Txt_CostoUd2.Validated

        'Txt_CostoUd2.Tag = Val(Txt_CostoUd2.Text)
        Txt_CostoUd2.Text = _Moneda & " " & FormatNumber(Txt_CostoUd2.Tag, 0)

    End Sub

    Private Sub Txt_CostoUd1_Enter(sender As Object, e As EventArgs) Handles Txt_CostoUd1.Enter
        Txt_CostoUd1.Text = Txt_CostoUd1.Tag
        Txt_CostoUd1.SelectAll()
    End Sub

    Private Sub Txt_CostoUd2_Enter(sender As Object, e As EventArgs) Handles Txt_CostoUd2.Enter
        Txt_CostoUd2.Text = Txt_CostoUd2.Tag
        Txt_CostoUd2.SelectAll()
    End Sub

    Sub Sb_Cargar_Combos_Clasificaciones()

        caract_combo(Cmb_Mrpr)

        If _SOC_Prod_Crea_Solo_Marcas_Proveedor Then

            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                      "SELECT Marca AS Padre,Marca As Hijo" & vbCrLf &
                      "From " & _Global_BaseBk & "Zw_MrVsPro Where CodProveedor = '" & Txt_Codproveedor.Text & "'"
            Cmb_Mrpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        Else

            Consulta_sql = Union & "SELECT KOMR AS Padre,NOKOMR AS Hijo FROM TABMR ORDER BY Hijo"
            Cmb_Mrpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
            Cmb_Mrpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Mrpr")

        End If

        caract_combo(Cmb_Rupr)
        Consulta_sql = Union & "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        Cmb_Rupr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Rupr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Rupr")

        caract_combo(Cmb_Clalibpr)
        Consulta_sql = Union & "SELECT KOCARAC AS Padre,LTRIM(RTRIM(KOCARAC))+'-'+LTRIM(RTRIM(NOKOCARAC)) AS Hijo FROM TABCARAC WHERE KOTABLA = 'CLALIBPR' ORDER BY Hijo"
        Cmb_Clalibpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Clalibpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Clalibpr")

        SuperFamilia = String.Empty
        caract_combo(Cmb_Fmpr)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOFM AS Padre,NOKOFM AS Hijo FROM TABFM ORDER BY Hijo"
        Cmb_Fmpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Fmpr.SelectedValue = SuperFamilia

        Familia = ""
        SubFamilia = ""

        caract_combo(Cmb_Kofupr)
        Consulta_sql = Union & "SELECT KOFU AS Padre,NOKOFU AS Hijo FROM TABFU"
        Cmb_Kofupr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Kofupr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Kofupr")

        caract_combo(Cmb_Zonapr)
        Consulta_sql = Union & "SELECT KOZO AS Padre,NOKOZO AS Hijo FROM TABZO"
        Cmb_Zonapr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Zonapr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Zonapr")

    End Sub

    Private Sub CmbSuperFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Fmpr.SelectedIndexChanged

        Try

            SuperFamilia = Cmb_Fmpr.SelectedValue.ToString
            Familia = String.Empty
            SubFamilia = String.Empty

            Cmb_Pfpr.DataSource = Nothing
            Cmb_Hfpr.DataSource = Nothing

            caract_combo(Cmb_Pfpr)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOPF AS Padre,NOKOPF AS Hijo FROM TABPF WHERE KOFM = '" & SuperFamilia & "'"
            Cmb_Pfpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

            Cmb_Pfpr.SelectedValue = Familia

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Pfpr.SelectedIndexChanged

        Try
            Familia = Cmb_Pfpr.SelectedValue.ToString
        Catch ex As Exception

        Finally

            SubFamilia = String.Empty
            Cmb_Hfpr.DataSource = Nothing

            caract_combo(Cmb_Hfpr)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOHF AS Padre, NOKOHF AS Hijo FROM TABHF" & vbCrLf &
                           "WHERE KOFM = '" & SuperFamilia & "' AND KOPF = '" & Familia & "'"
            Cmb_Hfpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
            Cmb_Hfpr.SelectedValue = SubFamilia

        End Try

    End Sub

    Private Sub CmbSubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Hfpr.SelectedIndexChanged

        Try
            SubFamilia = Cmb_Hfpr.SelectedValue.ToString
        Catch ex As Exception
            SubFamilia = String.Empty
        End Try

    End Sub

    Private Sub Sb_Chk_Pr_Desc_Producto_Solo_Mayusculas_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

        If Not Fx_Tiene_Permiso(Me, "Prod042") Then
            e.Cancel = True
        End If

    End Sub

    Private Sub Sb_Chk_Pr_Desc_Producto_Solo_Mayusculas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Chk_Pr_Desc_Producto_Solo_Mayusculas.Checked Then
            Txt_Nokopr.CharacterCasing = CharacterCasing.Upper
        Else
            Txt_Nokopr.CharacterCasing = CharacterCasing.Normal
        End If

    End Sub

    Private Sub Btn_Marcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marcas.Click

        If Fx_Tiene_Permiso(Me, "Tbl00016") Then

            Dim _Marca = NuloPorNro(Cmb_Mrpr.SelectedValue, "")

            If _SOC_Prod_Crea_Solo_Marcas_Proveedor Then

                Consulta_sql = "Select top 1 * From MAEEN Where KOEN = '" & Txt_Codproveedor.Text & "'"

                Dim _Tbl_Entidad As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                If CBool(_Tbl_Entidad.Rows.Count) Then

                    Dim _CodEntidad As String = Trim(_Tbl_Entidad.Rows(0).Item("KOEN"))
                    Dim _CodSucursal As String = Trim(_Tbl_Entidad.Rows(0).Item("SUEN"))
                    Dim _RazonEntidad As String = Trim(_Tbl_Entidad.Rows(0).Item("NOKOEN"))

                    Dim Fm As New Frm_ProveedoresVSMarcas
                    Fm.TxtCodigo.Text = _CodEntidad
                    Fm.Txtdescripcion.Text = _RazonEntidad

                    Fm.ShowDialog(Me)

                    caract_combo(Cmb_Mrpr)
                    Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                                   "SELECT Marca AS Padre,Marca As Hijo" & vbCrLf &
                                   "From " & _Global_BaseBk & "Zw_MrVsPro Where CodProveedor = '" & Txt_Codproveedor.Text & "'" ' WHERE SEMILLA = " & Actividad
                    Cmb_Mrpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
                    Cmb_Mrpr.SelectedValue = _Marca

                End If

            Else

                _Cl_SolCreaProducto.Row_NewMaepr.Item("Mrpr") = Cmb_Mrpr.SelectedValue
                Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Marcas,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
                Fm.Text = "MARCAS"
                Fm.ShowDialog(Me)
                Fm.Dispose()

                caract_combo(Cmb_Mrpr)

                Consulta_sql = Union & "SELECT KOMR AS Padre,NOKOMR AS Hijo FROM TABMR ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
                Cmb_Mrpr.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
                Cmb_Mrpr.SelectedValue = _Cl_SolCreaProducto.Row_NewMaepr.Item("Mrpr")

            End If

        End If

    End Sub

End Class