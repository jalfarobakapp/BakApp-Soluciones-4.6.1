'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.Data.SqlClient


Public Class Frm_Vales_Caja_01_MarcarDoc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public _Doc_Marcado As Boolean
    Dim _TblDocumento As DataTable
    Dim _TblEntDocumento As DataTable


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        caract_combo(CmbTipoDoc)
        Consulta_sql = "SELECT TIDO as Padre,SUBSTRING(NOTIDO,1,7) as Hijo From TABTIDO Where TIDO In ('BLV','FCV')"
        CmbTipoDoc.DataSource = _SQL.Fx_Get_DataTable(Consulta_sql)
        CmbTipoDoc.SelectedValue = "BLV"

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        _Doc_Marcado = False
        Me.Close()
    End Sub


    Sub Sb_Buscar_Documento(ByVal _IdMaeedo As Integer)

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _IdMaeedo
        _TblDocumento = _SQL.Fx_Get_DataTable(Consulta_sql)

        Dim _Tido As String = _TblDocumento.Rows(0).Item("TIDO")
        Dim _Nudo As String = _TblDocumento.Rows(0).Item("NUDO")
        Dim _CodEntidad As String = _TblDocumento.Rows(0).Item("ENDO")
        Dim _SucEntidad As String = _TblDocumento.Rows(0).Item("SUENDO")

        Dim _TotalBruto As Double = _TblDocumento.Rows(0).Item("VABRDO")
        LblTotalBruto.Text = FormatCurrency(_TotalBruto, 0)

        Consulta_sql = "Select * From MAEEN Where KOEN = '" & _CodEntidad & "' And SUEN = '" & _SucEntidad & "'"
        _TblEntDocumento = _SQL.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblEntDocumento.Rows.Count) Then

            Dim _Rut = Trim(_TblEntDocumento.Rows(0).Item("RTEN"))
            Dim _Dig = RutDigito(_Rut)

            _Rut = FormatNumber(_Rut, 0) & "-" & _Dig
            Lbl_Entidad.Text = "ENTIDAD: " & _Rut & ", " & _TblEntDocumento.Rows(0).Item("NOKOEN")
            Lbl_Direccion.Text = _TblEntDocumento.Rows(0).Item("DIEN")
        Else
            Lbl_Entidad.Text = "NO TIENE ENTIDAD ASIGNADA..."
            Lbl_Direccion.Text = "."
        End If

        Btn_NominarBoleta.Enabled = If(_Tido = "BLV", True, False)
        BtnMarcarDocumento.Enabled = True

        CmbTipoDoc.Enabled = False
        TxtNroDocumento.Enabled = False

        CmbTipoDoc.SelectedValue = _Tido
        TxtNroDocumento.Text = _Nudo

        ToastNotification.Show(Me, "DOCUMENTO ENCONTRADO", My.Resources.ok_button, _
                                         2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


    End Sub

    Private Sub TxtNroDocumento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNroDocumento.KeyDown

        If e.KeyValue = Keys.Return Then

            Dim _Tido As String = CmbTipoDoc.SelectedValue
            Dim _Nudo As String = numero_(TxtNroDocumento.Text, 10)

            Dim _Idmaeedo As Integer = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEEDO",
                                                 "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' AND NUDO = '" & _Nudo & "'", True)

            If CBool(_Idmaeedo) Then
                If Not Fx_BuscarSiExiste_Vale(_Idmaeedo) Then
                    Sb_Buscar_Documento(_Idmaeedo)
                End If
            Else
                MessageBoxEx.Show(Me, "Documento no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtNroDocumento.SelectAll()
            End If

        End If
    End Sub


    Public Function Fx_BuscarSiExiste_Vale(ByVal _Idmaeedo As String) As Boolean

        If CBool(_Idmaeedo) Then

            Consulta_sql = "Select * From Zw_Vales_Enc Where Id_Doc_As = " & _Idmaeedo
            Dim _Tbl_Vale As DataTable = _SQL.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl_Vale.Rows.Count) Then

                Dim _NroVale As String = _Tbl_Vale.Rows(0).Item("NroVale")
                Dim _Fecha = _Tbl_Vale.Rows(0).Item("Fecha_Emision")

                If MessageBoxEx.Show(Me, "Este documento ya tiene un vale de entrega asociado" & vbCrLf & vbCrLf & _
                                     "VALE NRO: " & _NroVale & vbCrLf & vbCrLf & _
                                     "Fecha: " & FormatDateTime(_Fecha, DateFormat.LongDate) & _
                                     ", Hora: " & FormatDateTime(_Fecha, DateFormat.ShortTime) & vbCrLf & vbCrLf & _
                                     "¿Desea ver la ficha del documento?", "Validación", _
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then

                    Dim Fm As New Frm_Vales_Ficha_Doc
                    Fm._NroVale_activo = _NroVale
                    Fm.ShowDialog(Me)

                End If

                Return True

            End If
        End If

    End Function

    Private Sub TxtNroDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocumento.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        TxtNroDocumento.Text = String.Empty
        _TblDocumento = Nothing
        _TblEntDocumento = Nothing

        Lbl_Entidad.Text = "ENTIDAD:"
        Lbl_Direccion.Text = "DIRECCION:"
        LblTotalBruto.Text = String.Empty

        BtnMarcarDocumento.Enabled = False
        TxtNroDocumento.Enabled = True
        CmbTipoDoc.Enabled = True
        TxtNroDocumento.Focus()
    End Sub

    Private Sub Frm_Vales_Caja_01_MarcarDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = TxtNroDocumento
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        Dim _Tido As String = CmbTipoDoc.SelectedValue
        Dim _Nudo As String = String.Empty
        Dim _Idmaeedo As Integer

        If Not String.IsNullOrEmpty(Trim(_Nudo)) Then

            _Nudo = numero_(TxtNroDocumento.Text, 10)
            _Idmaeedo = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEEDO",
                                                 "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' AND NUDO = '" & _Nudo & "'", True)
        Else
            _Idmaeedo = 0
        End If

        If CBool(_Idmaeedo) Then
            If Not Fx_BuscarSiExiste_Vale(_Idmaeedo) Then
                Sb_Buscar_Documento(_Idmaeedo)
            End If
        Else

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
            With _Fm
                .Grupo_Funcionario.Enabled = False
                .Rdb_Funcionarios_Uno.Checked = True

                .Pro_Sql_Filtro_Documentos_Extra = "And TIDO IN ('BLV','FCV')"
                .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
                .Rdb_Tipo_Documento_Uno.Checked = True


                .Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO Not In (Select Id_Doc_As From Zw_Vales_Enc)"
                .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, _
                                      CmbTipoDoc.SelectedValue, "WHERE TIDO IN ('BLV','FCV')")
                .Rdb_Estado_Cerradas.Checked = True
                .Rdb_Funcionarios_Uno.Checked = True
                .Grupo_Funcionario.Enabled = False
                .Rdb_Fecha_Emision_Desde_Hasta.Checked = True
                .ShowDialog(Me)

                If Not (.Pro_Row_Documento_Seleccionado Is Nothing) Then
                    _Idmaeedo = .Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")
                    If Not Fx_BuscarSiExiste_Vale(_Idmaeedo) Then
                        Sb_Buscar_Documento(_Idmaeedo)
                    End If
                End If
                .Dispose()
            End With
        End If


    End Sub

    Sub Sb_Nominar_Boleta()
        Dim _IdMaeedo As Integer = _TblDocumento.Rows(0).Item("IDMAEEDO")

        Dim Fm As New Frm_BuscarDocumento_Mt
        Dim _Tbl_Inf_Entidad As DataTable = Fm.Fx_Cambiar_Entidad_Doc(_IdMaeedo, "Espr0004")

        If Not (_Tbl_Inf_Entidad Is Nothing) Then

            _TblEntDocumento = _Tbl_Inf_Entidad

            If CBool(_TblEntDocumento.Rows.Count) Then

                Dim _Rut = Trim(_TblEntDocumento.Rows(0).Item("RTEN"))
                Dim _Dig = RutDigito(_Rut)

                _Rut = FormatNumber(_Rut, 0) & "-" & _Dig
                Lbl_Entidad.Text = "ENTIDAD: " & _Rut & ", " & _TblEntDocumento.Rows(0).Item("NOKOEN")
                Lbl_Direccion.Text = _TblEntDocumento.Rows(0).Item("DIEN")
            Else
                Lbl_Entidad.Text = "NO TIENE ENTIDAD ASIGNADA..."
                Lbl_Direccion.Text = "."
            End If

        End If
        Fm.Dispose()
        '_Tbl_Inf_Entidad.Dispose()
    End Sub

    Private Sub BtnMarcarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMarcarDocumento.Click

        If Fx_Tiene_Permiso(Me, "Vale0004") Then 'Funcionario_Activa_Anula

            Dim _Reg As Boolean = True

            Dim _CodEntidad = String.Empty '_TblEntDocumento.Rows(0).Item("KOEN")
            Dim _SucEntidad = String.Empty '_TblEntDocumento.Rows(0).Item("SUEN")

            If CBool(_TblEntDocumento.Rows.Count) Then
                _CodEntidad = _TblEntDocumento.Rows(0).Item("KOEN")
                _SucEntidad = _TblEntDocumento.Rows(0).Item("SUEN")
            End If

            _Reg = CBool(_Sql.Fx_Cuenta_Registros("Zw_TblInf_EntExcluidas", _
                                                         "Codigo = '" & _CodEntidad & "' And Sucursal = '" & _SucEntidad & "'"))


            If CBool(_TblEntDocumento.Rows.Count) And Not _Reg Then


                Dim _IdMaeedo = _TblDocumento.Rows(0).Item("IDMAEEDO")
                Fx_BuscarSiExiste_Vale(_IdMaeedo)

                If Not Fx_BuscarSiExiste_Vale(_IdMaeedo) Then

                    Dim Fm As New Frm_Vales_Marcar
                    Fm.ShowDialog(Me)

                    Dim _SqlInserta_Marca As String = String.Empty


                    If Fm._Marcar Then

                        Dim _Tipo_E As String
                        IIf(Fm._Retira_Cliente = True, _Tipo_E = "C", _Tipo_E = "D")

                        If Fm._Retira_Cliente Then
                            _Tipo_E = "C"
                        ElseIf Fm._Despacho_Domicilio Then
                            _Tipo_E = "D"
                        End If


                        If Fx_Marcar_Documento(_Tipo_E) Then
                            If _Tipo_E = "D" Then
                                MessageBoxEx.Show(Me, "Datos guardados correctamente", "Despacho a domicilio", _
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBoxEx.Show(Me, "Datos guardados correctamente", "Retira cliente", _
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            Me.Close()
                        End If
                    End If
                End If
            Else
                Beep()

                ToastNotification.Show(Me, "FALTA ENTIDAD EN DOCUMENTO" & vbCrLf & _
                                       "DEBE NOMINAR EL DOCUMENTO ANTES DE SEGUIR CON LA GESTION", My.Resources.cross, _
                                         4 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                'MessageBoxEx.Show(Me, "Falta entidad en documento" & vbCrLf & _
                '                     "Debe nominar el documento antes de seguir con la gestión", "Validación", _
                '                     MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Function Fx_Marcar_Documento(ByVal _Tipo_Entrega As String) As Boolean

        Dim _SqlInserta_Vale = String.Empty
        Dim _SqlInserta_Obs_Despacho = String.Empty


        Dim _NroVale As String

        Dim _CodEntidad = _TblEntDocumento.Rows(0).Item("KOEN")
        Dim _SucEntidad = _TblEntDocumento.Rows(0).Item("SUEN")
        Dim _IdMaeedo As Integer = _TblDocumento.Rows(0).Item("IDMAEEDO")
        Dim _Tipo As String = _TblDocumento.Rows(0).Item("TIDO")
        Dim _Numero As String = _TblDocumento.Rows(0).Item("NUDO")
        Dim _Fecha_Svr As Date = FechaDelServidor()

        _SqlInserta_Vale = "Insert Into Zw_Vales_Enc " &
                                "(NroVale,CodEntidad,SucEntidad,Tipo_Entrega,Estado,Fecha_Emision,Hora_Emision" &
                                ",Id_Doc_As,Tipo_Doc_As,NroDoc_Doc_As,Funcionario_Marca) Values ('#NroVale#','" & _CodEntidad &
                                "','" & _SucEntidad & "','" & _Tipo_Entrega & "','M','" & Format(_Fecha_Svr, "yyyyMMdd") &
                                "',convert(nvarchar, GETDATE(), 108)," & _IdMaeedo &
                                ",'" & _Tipo & "','" & _Numero & "','" & FUNCIONARIO & "')" & vbCrLf & "--" & vbCrLf



        If _Tipo_Entrega = "D" Then

            Dim Fm_D As New Frm_Vales_DatosDespacho
            Fm_D._Tbl_DatosEntidad = _TblEntDocumento
            Fm_D._Crear_Despacho = True
            Fm_D.BtnImprimir.Visible = False
            Fm_D._NroVale = "En Construcción"
            Fm_D.ShowDialog(Me)

            If Fm_D._GrabarDatos Then

                Dim _Observaciones As String = UCase(Fm_D.TxtObservaciones.Text)
                Dim _Direccion_Desp As String = UCase(Fm_D.TxtDireccion_Recibe.Text)
                Dim _Comuna_Desp As String = UCase(Fm_D.TxtComuna_Recibe.Text)
                Dim _Ciudad_Desp As String = UCase(Fm_D.TxtCiudad_Retiro.Text)
                Dim _Telefono_Desp As String = Fm_D.TxtFono_Entidad.Text
                Dim _Horario_Desp As String = UCase(Fm_D.TxtHora_Recibe.Text)
                Dim _Fecha_Desp As String = Format(Fm_D.Dtp_Fecha_Recibe.Value, "yyyyMMdd")
                Dim _Contacto_Desp As String = UCase(Fm_D.TxtPersona_Contacto.Text)
                Dim _Contacto_Desp_Fono As String = UCase(Fm_D.TxtFono_Contacto.Text)

                _SqlInserta_Obs_Despacho =
                               "Insert Into Zw_Vales_Obs(NroVale, Observaciones,Direccion_Desp,Comuna_Desp," &
                               "Ciudad_Desp,Telefono_Desp,Horario_Desp,Fecha_Desp,Contacto_Desp,Contacto_Desp_Fono) Values " & vbCrLf &
                               "('#NroVale#','" & _Observaciones & "','" & _Direccion_Desp & "','" & _Comuna_Desp &
                               "','" & _Ciudad_Desp & "','" & _Telefono_Desp & "','" & _Horario_Desp &
                               "','" & _Fecha_Desp & "','" & _Contacto_Desp & "','" & _Contacto_Desp_Fono & "')"
                'If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            Else
                Return False
            End If
        End If

        ' Declara variables para la transaccion


        Dim _Ult_Vale As String = _Sql.Fx_Trae_Dato("Zw_Vales_Enc", "MAX(NroVale)")
        Dim _Nv As Long = Val(_Ult_Vale)
        If String.IsNullOrEmpty(Trim(_Ult_Vale)) Then
            _Nv = 1
        Else
            _Nv += 1
        End If

        _NroVale = numero_(_Nv, 10)

        Consulta_sql = _SqlInserta_Vale & vbCrLf & _SqlInserta_Obs_Despacho
        Consulta_sql = Replace(Consulta_sql, "#NroVale#", _NroVale)

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function


    Private Sub Frm_Vales_Caja_01_MarcarDoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_NominarBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NominarBoleta.Click
        Sb_Nominar_Boleta()
    End Sub
End Class