'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Vales_DatosDespacho

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public _NroVale As String
    Public _Tbl_DatosEntidad As DataTable
    Public _GrabarDatos As Boolean
    Public _Crear_Despacho As Boolean

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click

        _GrabarDatos = False
        Me.Close()

    End Sub


    Function Fx_GrabarDatos(ByVal _NroVale As String) As Boolean
        If _Crear_Despacho Then
            Return True
        Else

            Dim _Fecha As String = Format(Dtp_Fecha_Recibe.Value, "yyyyMMdd")

            Consulta_sql = "Delete Zw_Vales_Obs Where NroVale = '" & _NroVale & "'" & vbCrLf &
                           "Insert Into Zw_Vales_Obs " &
                           "(NroVale,Observaciones,Direccion_Desp,Comuna_Desp,Ciudad_Desp,Telefono_Desp,Horario_Desp,Fecha_Desp,Contacto_Desp)" & vbCrLf &
                           "Values ('" & _NroVale & "','" & TxtObservaciones.Text & "','" & TxtDireccion_Recibe.Text &
                           "','" & TxtComuna_Recibe.Text & "','" & TxtCiudad_Retiro.Text & "','" & TxtFono_Entidad.Text &
                           "','" & TxtHora_Recibe.Text & "','" & _Fecha & "','" & TxtPersona_Contacto.Text & "')"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Sub Sb_Buscar_Sucursal()

        Dim Fm As New Frm_BuscarEntidad_MtSuc
        Fm._CodEntidad = _Tbl_DatosEntidad.Rows(0).Item("KOEN")
        Fm.ShowDialog(Me)

        If Fm._Suc_Seleccionada Then

            _Tbl_DatosEntidad = Fm._Tbl_SucursalSelec

            Dim _Pais = _Tbl_DatosEntidad.Rows(0).Item("PAEN")
            Dim _Ciud = _Tbl_DatosEntidad.Rows(0).Item("CIEN")
            Dim _Comu = _Tbl_DatosEntidad.Rows(0).Item("CMEN")

            TxtCiudad_Retiro.Text = _Sql.Fx_Trae_Dato("TABCI", "NOKOCI", "KOPA = '" & _Pais & "' And KOCI = '" & _Ciud & "'")
            TxtComuna_Recibe.Text = _Sql.Fx_Trae_Dato("TABCM", "NOKOCM", "KOPA = '" & _Pais & "' And KOCI = '" & _Ciud & "' And KOCM = '" & _Comu & "'")

            TxtDireccion_Recibe.Text = _Tbl_DatosEntidad.Rows(0).Item("DIEN")
            TxtFono_Entidad.Text = _Tbl_DatosEntidad.Rows(0).Item("FOEN")
            TxtPersona_Contacto.Text = String.Empty
            TxtHora_Recibe.Text = String.Empty
            Dtp_Fecha_Recibe.Value = Date.Now

        End If

    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Fx_GrabarDatos(_NroVale) Then
            _GrabarDatos = True
            If _Crear_Despacho Then Me.Close()
        End If
    End Sub

    Private Sub Frm_Vales_DatosDespacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If String.IsNullOrEmpty(Trim(TxtDireccion_Recibe.Text)) Then
            Sb_Buscar_Sucursal()
            Sb_Buscar_Contacto()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_Direccion.LinkClicked
        Sb_Buscar_Sucursal()
    End Sub

    Private Sub LinkPersonaContacto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_PersonaContacto.LinkClicked
        Sb_Buscar_Contacto()
    End Sub

    Sub Sb_Buscar_Contacto()

        If CBool(_Tbl_DatosEntidad.Rows.Count) Then

            TxtPersona_Contacto.Text = String.Empty

            Dim _CodEntidada As String = _Tbl_DatosEntidad.Rows(0).Item("KOEN")

            Dim Fm_c As New Frm_Crear_Entidad_Mt_Lista_contactos(True)
            Fm_c.Pro_CodEntidad = _CodEntidada
            Fm_c.ShowDialog(Me)

            If Fm_c.Pro_ContactoSeleccionado Then

                TxtPersona_Contacto.Text = Fm_c.Pro_Tbl_DatosContacto.Rows(0).Item("NOKOCON")
                TxtFono_Contacto.Text = Fm_c.Pro_Tbl_DatosContacto.Rows(0).Item("FONOCON")

            End If

        End If
        TxtPersona_Contacto.Focus()
    End Sub

    Public Sub Sb_Bloquear(ByVal _Accion As Boolean)
        TxtCiudad_Retiro.Enabled = _Accion
        TxtComuna_Recibe.Enabled = _Accion
        TxtDireccion_Recibe.Enabled = _Accion
        TxtFono_Contacto.Enabled = _Accion
        TxtHora_Recibe.Enabled = _Accion
        TxtObservaciones.Enabled = _Accion
        TxtPersona_Contacto.Enabled = _Accion
        Link_Direccion.Enabled = _Accion
        Link_PersonaContacto.Enabled = _Accion
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If Fx_Tiene_Permiso(Me, "Vale0010") Then

            Sb_Bloquear(True)

            ToastNotification.Show(Me, "AHORA ES POSIBLE MODIFICAR LOS DATOS DE DESPACHO", My.Resources.note_text_edit,
                                         3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            BtnGrabar.Enabled = True
            BtnEditar.Enabled = False
            TxtDireccion_Recibe.Focus()
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        Dim Fm As New Frm_Configuracion_vales

        Dim _Impresora As String = Fm._Datos_Conf.Tables("Tbl_Configuracion").Rows(0).Item("Impresora_pred")
        Dim _Ruta_Imagen As String = Fm._Datos_Conf.Tables("Tbl_Configuracion").Rows(0).Item("Ruta_Imagen")

        If Not String.IsNullOrEmpty(Trim(_Impresora)) Then
            If Fx_Tiene_Permiso(Me, "Vale0011") Then

                Dim _Ds_Datos As DataSet

                Consulta_sql = My.Resources.Rs_SQL_Impresion.Sql_Ds_Vale_impimir
                Consulta_sql = Replace(Consulta_sql, "#NroVale#", _NroVale)

                _Ds_Datos = _Sql.Fx_Get_DataSet(Consulta_sql)

                Dim _Clase_Imp As New Cl_Imprimir_documento

                If MessageBoxEx.Show(Me, "Imprimir o vista previa", "imprimir",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    _Clase_Imp._Imprimir_Documento(Cl_Imprimir_documento._Tipo_impresion.Vale_direccion,
                                                                   _Ds_Datos, _Impresora, False, _Ruta_Imagen)
                Else

                    _Clase_Imp._Imprimir_Documento(Cl_Imprimir_documento._Tipo_impresion.Vale_direccion,
                                               _Ds_Datos, _Impresora, True, _Ruta_Imagen)
                End If



            End If
        Else
            ToastNotification.Show(Me, "FALTA CONFIGURACION DE IMPRESORA PREDETERMINADA", My.Resources.cross,
                                             3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If
    End Sub

    Private Sub Frm_Vales_DatosDespacho_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
