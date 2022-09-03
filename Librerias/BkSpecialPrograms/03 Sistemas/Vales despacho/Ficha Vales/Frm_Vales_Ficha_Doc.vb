'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Vales_Ficha_Doc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public _Tbl_EntidadDoc, _
           _Zw_Vales_Enc, _
           _Zw_Vales_Obs, _
           _Tbl_Encab_Documento, _
           _Tbl_Detal_Documento As DataTable

    'Public _Activar_Vale As Boolean

    Public _NroVale_activo As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnDireccionDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDireccionDespacho.Click
        Dim Fm As New Frm_Vales_DatosDespacho
        Fm._Crear_Despacho = False
        Fm._NroVale = _NroVale_activo
        Fm._Tbl_DatosEntidad = _Tbl_EntidadDoc
        Fm.BtnGrabar.Enabled = False
        Fm.BtnEditar.Visible = True
        Fm.Sb_Bloquear(False)

        If CBool(_Zw_Vales_Obs.Rows.Count) Then
            Fm.TxtCiudad_Retiro.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Ciudad_Desp")), "")
            Fm.TxtComuna_Recibe.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Comuna_Desp")), "")
            Fm.TxtDireccion_Recibe.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Direccion_Desp")), "")
            Fm.TxtFono_Entidad.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Telefono_Desp")), "")
            Fm.TxtHora_Recibe.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Horario_Desp")), "")
            Fm.TxtObservaciones.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Observaciones")), "")
            Fm.TxtPersona_Contacto.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Contacto_Desp")), "")
            Fm.TxtFono_Contacto.Text = NuloPorNro(Trim(_Zw_Vales_Obs.Rows(0).Item("Contacto_Desp_Fono")), "")
        End If
        Fm.ShowDialog(Me)

        Consulta_sql = "Select * From Zw_Vales_Obs Where NroVale = '" & _NroVale_activo & "'"
        _Zw_Vales_Obs = _SQL.Fx_Get_Tablas(Consulta_sql)

    End Sub


    Sub Sb_Ver_Documento(ByVal _NroVale)

      
        Dim _Ds_Query As DataSet

        Consulta_sql = My.Resources.Rsc_Vales.Sql_Query_Vales
        Consulta_sql = Replace(Consulta_sql, "#NroVale#", _NroVale)

        _Ds_Query = _Sql.Fx_Get_DataSet(Consulta_sql)

     
        _Zw_Vales_Enc = _Ds_Query.Tables(0)

        If _Zw_Vales_Enc.Rows(0).Item("Estado") = "M" Then
            BtnActivarVale.Enabled = True
            BtnCambiarTipo.Enabled = True
            BtnImprimirVale.Enabled = False
        Else
            BtnActivarVale.Enabled = False
            BtnCambiarTipo.Enabled = False
            BtnImprimirVale.Enabled = True
        End If

        If _Zw_Vales_Enc.Rows(0).Item("Tipo_Entrega") = "C" Then
            BtnDireccionDespacho.Enabled = False
        Else
            BtnDireccionDespacho.Enabled = True
        End If

        'Grilla_Vale_Enc.Width 810 largo grilla
        With Grilla_Vale_Enc
            .DataSource = _Zw_Vales_Enc

            OcultarEncabezadoGrilla(Grilla_Vale_Enc, True)

            .Columns("NroVale").Width = 90
            .Columns("NroVale").HeaderText = "Número Vale"
            .Columns("NroVale").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NroVale").Visible = True
            .Columns("NroVale").DisplayIndex = 0

            .Columns("Razon").Width = 230
            .Columns("Razon").HeaderText = "Razón social"
            .Columns("Razon").Visible = True
            .Columns("Razon").DisplayIndex = 1

            .Columns("Fecha_Emision").Width = 90
            .Columns("Fecha_Emision").HeaderText = "Fecha emisión"
            .Columns("Fecha_Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Emision").Visible = True
            .Columns("Fecha_Emision").DisplayIndex = 2

            .Columns("Hora_Emision").Visible = True
            .Columns("Hora_Emision").HeaderText = "Hora"
            .Columns("Hora_Emision").Width = 70
            .Columns("Hora_Emision").DefaultCellStyle.Format = "hh:mm:ss"
            .Columns("Hora_Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora_Emision").DisplayIndex = 3
            'Dim ss = .Columns("TEntrega").Width
            .Columns("TEntrega").Width = 190
            .Columns("TEntrega").HeaderText = "Tipo de entrega"
            .Columns("TEntrega").Visible = True
            .Columns("TEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TEntrega").DisplayIndex = 4

            .Columns("Funcionario_Marca").Width = 70
            .Columns("Funcionario_Marca").HeaderText = "Func.Marca"
            .Columns("Funcionario_Marca").Visible = True
            .Columns("Funcionario_Marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Funcionario_Marca").DisplayIndex = 5

            .Columns("Funcionario_Activa").Width = 70
            .Columns("Funcionario_Activa").HeaderText = "Func.Activa"
            .Columns("Funcionario_Activa").Visible = True
            .Columns("Funcionario_Activa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Funcionario_Activa").DisplayIndex = 6

        End With

        _Zw_Vales_Obs = _Ds_Query.Tables(1)
        _Tbl_Encab_Documento = _Ds_Query.Tables(2)
        '810
        With Grilla_Doc_Origen

            .DataSource = _Tbl_Encab_Documento

            OcultarEncabezadoGrilla(Grilla_Doc_Origen, True)

            .Columns("Tipo").Width = 160
            .Columns("Tipo").HeaderText = "Tipo documento"
            .Columns("Tipo").Visible = True
            .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("NUDO").Width = 115
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("FEEMDO").Width = 115
            .Columns("FEEMDO").HeaderText = "Fecha emisión"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("FEULVEDO").Width = 115
            .Columns("FEULVEDO").HeaderText = "F. Ult.Vencimiento"
            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("PorcCumplimiento").Width = 100
            .Columns("PorcCumplimiento").HeaderText = "% Cumplimiento"
            .Columns("PorcCumplimiento").Visible = True
            .Columns("PorcCumplimiento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("PorcCumplimiento").DefaultCellStyle.Format = "###,##.## %"

            .Columns("Guias").Width = 100
            .Columns("Guias").HeaderText = "Cantidad Guías"
            .Columns("Guias").Visible = True
            .Columns("Guias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("NCredito").Width = 100
            .Columns("NCredito").HeaderText = "Cantidad N.C."
            .Columns("NCredito").Visible = True
            .Columns("NCredito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

        _Tbl_Detal_Documento = _Ds_Query.Tables(3)

        With Grilla_Detalle_Doc_Origen

            .DataSource = _Tbl_Detal_Documento

            OcultarEncabezadoGrilla(Grilla_Detalle_Doc_Origen, True)

            .Columns("SULIDO").Width = 30
            .Columns("SULIDO").HeaderText = "Suc"
            .Columns("SULIDO").Visible = True
            .Columns("SULIDO").DisplayIndex = 0

            .Columns("BOSULIDO").Width = 30
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").DisplayIndex = 1

            .Columns("LINCONDESP").Width = 30
            .Columns("LINCONDESP").HeaderText = "Des"
            .Columns("LINCONDESP").Visible = True
            .Columns("LINCONDESP").DisplayIndex = 2

            .Columns("KOPRCT").Width = 115
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").DisplayIndex = 3

            .Columns("NOKOPR").Width = 325
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = 4

            .Columns("UD").Width = 30
            .Columns("UD").HeaderText = "UN"
            .Columns("UD").Visible = True
            .Columns("UD").DisplayIndex = 5

            .Columns("CANTIDAD").Width = 75
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").DefaultCellStyle.Format = "###,##.##"
            .Columns("CANTIDAD").DisplayIndex = 6

            .Columns("DESPACHADO").Width = 75
            .Columns("DESPACHADO").HeaderText = "Despachado"
            .Columns("DESPACHADO").Visible = True
            .Columns("DESPACHADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DESPACHADO").DefaultCellStyle.Format = "###,##.##"
            .Columns("DESPACHADO").DisplayIndex = 7

            .Columns("SALDO").Width = 75
            .Columns("SALDO").HeaderText = "Saldo"
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").DefaultCellStyle.Format = "###,##.##"
            .Columns("SALDO").DisplayIndex = 8

            Dim _i = 0
            For Each row As DataGridViewRow In .Rows
                _i = row.Index
                Dim _Saldo As String = row.Cells("SALDO").Value

                Select Case _Saldo
                    Case Is = 0
                        .Rows.Item(_i).DefaultCellStyle.BackColor = Color.LightGreen
                    Case Is > 0
                        .Rows.Item(_i).DefaultCellStyle.BackColor = Color.Yellow
                    Case Else
                        .Rows.Item(_i).DefaultCellStyle.BackColor = Color.White
                End Select

                '.Rows.Item().Cells("BtnImagen").Value = My.Resources_rounded_green
            Next











        End With

        If Not CBool(_Tbl_Detal_Documento.Rows.Count) Then
            BtnActualizar.Enabled = False
            BtnAnularVale.Enabled = False
            BtnCambiarTipo.Enabled = False
            BtnDireccionDespacho.Enabled = False
            BtnImprimirVale.Enabled = False
        End If

        Dim _CodEntidad As String = _Tbl_Encab_Documento.Rows(0).Item("ENDO")
        Dim _SucEntidad As String = _Tbl_Encab_Documento.Rows(0).Item("SUENDO")

        Consulta_sql = "Select * From MAEEN Where KOEN = '" & _CodEntidad & "' And SUEN = '" & _SucEntidad & "'"
        _Tbl_EntidadDoc = _SQL.Fx_Get_Tablas(Consulta_sql)

        _Ds_Query.Dispose()

    End Sub


    Private Sub Frm_Vales_Ficha_Doc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Ver_Documento(_NroVale_activo)
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
       Sb_Formato_Generico_Grilla(Grilla_Vale_Enc, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(Grilla_Doc_Origen, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(Grilla_Detalle_Doc_Origen, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(Grilla_Guias_DespachoNC, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Bar1.Enabled = False
        Sb_Ver_Documento(_NroVale_activo)
        ToastNotification.Show(Me, "Refrech Ok", My.Resources.ok_button, _
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        Bar1.Enabled = True
    End Sub

    Private Sub BtnCambiarTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarTipo.Click

        If Fx_Tiene_Permiso(Me, "Vale0016") Then

            Dim _TidoPa = _Tbl_Encab_Documento.Rows(0).Item("TIDO")
            Dim _NudoPa = _Tbl_Encab_Documento.Rows(0).Item("NUDO")

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", "TIDOPA = '" & _TidoPa & "' And NUDOPA = '" & _NudoPa & "'"))

            If Not _Reg Then

                Dim _Tipo_Entrega As String = _Zw_Vales_Enc.Rows(0).Item("Tipo_Entrega")
                Dim _NewTE As String
                Dim _NewTipoEntrega As String

                If _Tipo_Entrega = "C" Then
                    _NewTE = "D"
                    _NewTipoEntrega = "DESPACHO A DOMICILIO"
                ElseIf _Tipo_Entrega = "D" Then
                    _NewTE = "C"
                    _NewTipoEntrega = "RETIRA CLIENTE"
                End If

                If MessageBoxEx.Show(Me, "Esta seguro de cambiar el tipo de entrega a " & vbCrLf & _
                                     _NewTipoEntrega, "Cambiar tipo de entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Update Zw_Vales_Enc Set Tipo_Entrega = '" & _NewTE & "' Where NroVale = '" & _NroVale_activo & "'"
                    If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                        ToastNotification.Show(Me, "CAMBIO DE TIPO DE ENTREGA REALIZADO CORRECATMENTE", My.Resources.ok_button, _
                                               5 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                        Sb_Ver_Documento(_NroVale_activo)
                    End If

                End If
            Else
                MessageBoxEx.Show(Me, "No se puede realizar esta acción con este vale, ya que tiene movimientos asociados", "Validación", _
                 MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub Grilla_Detalle_Doc_Origen_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Detalle_Doc_Origen.CellEnter

        With Grilla_Detalle_Doc_Origen

            Dim _Idmaeddo = .Rows(.CurrentRow.Index).Cells("IDMAEDDO").Value
            Dim _CodTecnico = .Rows(.CurrentRow.Index).Cells("COD_TECNICO").Value
            Dim _Rtu = .Rows(.CurrentRow.Index).Cells("RTU").Value
            Dim _Ud1 = .Rows(.CurrentRow.Index).Cells("UD01PR").Value
            Dim _Ud2 = .Rows(.CurrentRow.Index).Cells("UD01PR").Value

            LblCodTecnico.Text = "Cód. Técnico:  " & _CodTecnico
            LblRtu.Text = "Rtu: " & _Rtu
            LblUd1.Text = "Ud1: " & _Ud1
            LblUd2.Text = "Ud2: " & _Ud2

            Consulta_sql = My.Resources.Rsc_Vales.Sql_Query_Vales_x_Guias
            Consulta_sql = Replace(Consulta_sql, "#IdMaeddo#", _Idmaeddo)

     
            With Grilla_Guias_DespachoNC

                .DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

                OcultarEncabezadoGrilla(Grilla_Guias_DespachoNC, True)

                .Columns("TIDO").Width = 30
                .Columns("TIDO").HeaderText = "TD"
                .Columns("TIDO").Visible = True
                .Columns("TIDO").DisplayIndex = 0

                .Columns("NUDO").Width = 80
                .Columns("NUDO").HeaderText = "Número"
                .Columns("NUDO").Visible = True
                .Columns("NUDO").DisplayIndex = 1

                .Columns("SULIDO").Width = 30
                .Columns("SULIDO").HeaderText = "Suc"
                .Columns("SULIDO").Visible = True
                .Columns("SULIDO").DisplayIndex = 2

                .Columns("BOSULIDO").Width = 30
                .Columns("BOSULIDO").HeaderText = "Bod"
                .Columns("BOSULIDO").Visible = True
                .Columns("BOSULIDO").DisplayIndex = 3

                .Columns("UD").Width = 30
                .Columns("UD").HeaderText = "UN"
                .Columns("UD").Visible = True
                .Columns("UD").DisplayIndex = 4

                .Columns("CANTIDAD").Width = 60
                .Columns("CANTIDAD").HeaderText = "Cantidad"
                .Columns("CANTIDAD").Visible = True
                .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CANTIDAD").DisplayIndex = 5

                .Columns("FEEMLI").Width = 100
                .Columns("FEEMLI").HeaderText = "F. emisión"
                .Columns("FEEMLI").Visible = True
                .Columns("FEEMLI").DisplayIndex = 6
                .Columns("FEEMLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("OBSERVACION_DOC").Width = 470
                .Columns("OBSERVACION_DOC").HeaderText = "Observaciones del documento"
                .Columns("OBSERVACION_DOC").Visible = True
                .Columns("OBSERVACION_DOC").DisplayIndex = 7

                .Enabled = CBool(.RowCount)

            End With


        End With

    End Sub


    Private Sub BtnAnularVale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnularVale.Click
        Dim _IdMaeedo = Grilla_Doc_Origen.Rows(0).Cells("IDMAEEDO").Value
        If Sb_Eliminar_Vale(_NroVale_activo, _IdMaeedo, Me) Then Me.Close()
    End Sub

    Public Function Sb_Eliminar_Vale(ByVal _NroVale As String, _
                                ByVal _IdMaeedo As String, _
                                ByVal _Form As Form, Optional ByVal _Preguntar As Boolean = True) As Boolean

        If Fx_Tiene_Permiso(Me, "Vale0008") Then



            Dim _Estado As String = _Sql.Fx_Trae_Dato("Zw_Vales_Enc", "Estado", "NroVale = '" & _NroVale & "'")

            Dim _Tidopa = _Tbl_Encab_Documento.Rows(0).Item("TIDO")
            Dim _Nudopa = _Tbl_Encab_Documento.Rows(0).Item("NUDO")

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", "TIDOPA = '" & _Tidopa & "' And NUDOPA = '" & _Nudopa & "'"))


            If Not _Reg Then

                Dim _Eliminar As Boolean

                If _Preguntar Then
                    If MessageBoxEx.Show(_Form, "¿Esta seguro de anular este Vale?", _
                                     "Anular Vale", MessageBoxButtons.YesNo, _
                                     MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        _Eliminar = True
                    End If
                Else
                    _Eliminar = True
                End If


                If _Eliminar Then

                    Consulta_sql = "UPDATE MAEDDO SET CAPRAD1=CAPRCO1,CAPRAD2=CAPRCO1,ESLIDO='C',LINCONDESP=1" & vbCrLf & _
                                   "WHERE IDMAEEDO = " & _IdMaeedo & vbCrLf & _
                                   "UPDATE MAEEDO SET ESDO = 'C',CAPRAD = CAPRCO WHERE IDMAEEDO = " & _IdMaeedo & _
                                   vbCrLf & vbCrLf & "-- Actualiza Stock Fisico y Devengado " & vbCrLf & vbCrLf

                    For Each _Fila As DataRow In _Tbl_Detal_Documento.Rows

                        Dim _Empresa As String = _Fila.Item("EMPRESA")
                        Dim _Sucursal As String = _Fila.Item("SULIDO")
                        Dim _Bodega As String = _Fila.Item("BOSULIDO")

                        Dim _Codigo As String = _Fila.Item("KOPRCT")
                        Dim _Cantidad1 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO1"), False, 5)
                        Dim _Cantidad2 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO2"), False, 5)



                        Consulta_sql += "UPDATE MAEPREM SET STFI1 = STFI1 - " & _Cantidad1 & "," & vbCrLf & _
                                        "STFI2 = STFI2 - " & _Cantidad2 & "," & vbCrLf & _
                                        "STDV1 = STDV1 - " & _Cantidad1 & "," & vbCrLf & _
                                        "STDV2 = STDV2 - " & _Cantidad2 & vbCrLf & _
                                        "WHERE EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'" & _
                                        vbCrLf & vbCrLf & _
                                        "UPDATE MAEPR SET STFI1 = STFI1 - " & _Cantidad1 & "," & vbCrLf & _
                                        "STFI2 = STFI2 - " & _Cantidad2 & "," & vbCrLf & _
                                        "STDV1 = STDV1 - " & _Cantidad1 & "," & vbCrLf & _
                                        "STDV2 = STDV2 - " & _Cantidad2 & vbCrLf & _
                                        "WHERE KOPR = '" & _Codigo & "'" & _
                                        vbCrLf & vbCrLf & _
                                        "UPDATE MAEST SET STFI1 = STFI1 - " & _Cantidad1 & "," & vbCrLf & _
                                        "STFI2 = STFI2 - " & _Cantidad2 & "," & vbCrLf & _
                                        "STDV1 = STDV1 - " & _Cantidad1 & "," & vbCrLf & _
                                        "STDV2 = STDV2 - " & _Cantidad2 & vbCrLf & _
                                        "WHERE EMPRESA = '" & _Empresa & _
                                        "' AND KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'" & _
                                        vbCrLf & vbCrLf & "---------------------------" & vbCrLf & vbCrLf

                    Next


                    Consulta_sql += "Update Zw_Vales_Enc Set " & _
                                    "Id_Doc_As = 0,Estado='N',Funcionario_Anula = '" & FUNCIONARIO & "'" & vbCrLf & _
                                    ",Fecha_Cierre = Getdate()" & vbCrLf & _
                                    "Where NroVale = '" & _NroVale & "'" & vbCrLf & vbCrLf & _
                                    "Delete Zw_Vales_Obs Where NroVale = '" & _NroVale & "'"

                    Dim _SqlQuery_Anular = Consulta_sql

                    _Reg = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", "TIDOPA = '" & _Tidopa & "' And NUDOPA = '" & _Nudopa & "'"))


                    If Not _Reg Then
                        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                            MessageBoxEx.Show(_Form, "Documento anulado correctamente", "Anular Vale",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return True
                        End If
                    Else
                        Sb_Eliminar_Vale(_NroVale, _IdMaeedo, _Form, False)
                    End If
                End If
            Else
                MessageBoxEx.Show(_Form, "Este vale no se puede anular ya que tiene documentos relacionados" & vbCrLf & _
                                  "para anular debe reversar toda la gestión desde el sistema ERP", "Validación", _
                                   MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        End If
    End Function

    Private Sub Grilla_Guias_DespachoNC_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Guias_DespachoNC.CellDoubleClick

        Dim _IdMaeedo = Grilla_Guias_DespachoNC.Rows(Grilla_Guias_DespachoNC.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Ver_Documento(_IdMaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Doc_Origen_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Doc_Origen.CellDoubleClick

        Dim _IdMaeedo = Grilla_Doc_Origen.Rows(Grilla_Doc_Origen.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Ver_Documento(_IdMaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnImprimirVale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirVale.Click

        If Fx_Tiene_Permiso(Me, "Vale0009") Then

            Dim _Estado As String = _Sql.Fx_Trae_Dato("Zw_Vales_Enc", "Estado", "NroVale = '" & _NroVale_activo & "'")

            If _Estado = "A" Then

                Dim _IdMaeedo = Grilla_Doc_Origen.Rows(0).Cells("IDMAEEDO").Value

                Dim _Ds_Datos As DataSet

                Dim Fm As New Frm_Configuracion_vales

                Dim _Impresora As String = Fm._Datos_Conf.Tables("Tbl_Configuracion").Rows(0).Item("Impresora_pred")
                Dim _Ruta_Imagen As String = Fm._Datos_Conf.Tables("Tbl_Configuracion").Rows(0).Item("Ruta_Imagen")

                If Not String.IsNullOrEmpty(Trim(_Impresora)) Then
                    If Fx_Tiene_Permiso(Me, "Vale0011") Then


                        Consulta_sql = My.Resources.Rs_SQL_Impresion.Sql_Ds_Vale_impimir
                        Consulta_sql = Replace(Consulta_sql, "#NroVale#", _NroVale_activo) & vbCrLf & vbCrLf

                        Dim _Condicion_Adicional = String.Empty

                        Consulta_sql += My.Resources.Rs_SQL_Impresion.Sql_Ds_Documento_impimir
                        Consulta_sql = Replace(Consulta_sql, "#IdMaeedo#", _IdMaeedo)
                        Consulta_sql = Replace(Consulta_sql, " #Condicion_Adicional#", _Condicion_Adicional)

                        _Ds_Datos = _Sql.Fx_Get_DataSet(Consulta_sql)

                        Dim _Clase_Imp As New Cl_Imprimir_documento

                        If MessageBoxEx.Show(Me, "Imprimir o vista previa", "imprimir", _
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            _Clase_Imp._Imprimir_Documento(Cl_Imprimir_documento._Tipo_impresion.Vale, _
                                                                           _Ds_Datos, _Impresora, False, _Ruta_Imagen)
                        Else

                            _Clase_Imp._Imprimir_Documento(Cl_Imprimir_documento._Tipo_impresion.Vale, _
                                                       _Ds_Datos, _Impresora, True, _Ruta_Imagen)
                        End If



                    End If
                Else
                    ToastNotification.Show(Me, "FALTA CONFIGURACION DE IMPRESORA PREDETERMINADA", My.Resources.cross, _
                                                 3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If





            ElseIf _Estado = "C" Then
                MessageBoxEx.Show(Me, "No hay saldo que entregar", "Imprimir Vale", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf _Estado = "M" Then
                MessageBoxEx.Show(Me, "Vale aun no esta activo", "Imprimir Vale", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub


    Private Sub BtnActivarVale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivarVale.Click

        If Fx_Tiene_Permiso(Me, "Vale0005") Then

            Dim _IdMaeedo = Grilla_Doc_Origen.Rows(0).Cells("IDMAEEDO").Value
            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _IdMaeedo

            _Tbl_Encab_Documento = _SQL.Fx_Get_Tablas(Consulta_sql)

            Dim _Tido = _Tbl_Encab_Documento.Rows(0).Item("TIDO")
            Dim _Nudo = _Tbl_Encab_Documento.Rows(0).Item("NUDO")

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO", "TIDOPA = '" & _Tido & "' And NUDOPA = '" & _Nudo & "'"))

            If _Reg Then
                MessageBoxEx.Show(Me, "Este Vale no se puede activar, ya que existen movimientos asociados al documento", _
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                Consulta_sql = "UPDATE MAEDDO SET CAPRAD1=0,CAPRAD2=0,ESLIDO='',LINCONDESP=0 WHERE IDMAEEDO = " & _IdMaeedo & vbCrLf & _
                               "UPDATE MAEEDO SET ESDO = '',CAPRAD = 0 WHERE IDMAEEDO = " & _IdMaeedo & _
                               vbCrLf & vbCrLf & "-- Actualiza Stock Fisico y Devengado " & vbCrLf & vbCrLf

                For Each _Fila As DataRow In _Tbl_Detal_Documento.Rows

                    Dim _Empresa As String = _Fila.Item("EMPRESA")
                    Dim _Sucursal As String = _Fila.Item("SULIDO")
                    Dim _Bodega As String = _Fila.Item("BOSULIDO")

                    Dim _Codigo As String = _Fila.Item("KOPRCT")
                    Dim _Cantidad1 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO1"), False, 5)
                    Dim _Cantidad2 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO2"), False, 5)



                    Consulta_sql += "UPDATE MAEPREM SET STFI1 = STFI1 + " & _Cantidad1 & "," & vbCrLf & _
                                    "STFI2 = STFI2 + " & _Cantidad2 & "," & vbCrLf & _
                                    "STDV1 = STDV1 + " & _Cantidad1 & "," & vbCrLf & _
                                    "STDV2 = STDV2 + " & _Cantidad2 & vbCrLf & _
                                    "WHERE EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'" & _
                                    vbCrLf & vbCrLf & _
                                    "UPDATE MAEPR SET STFI1 = STFI1 + " & _Cantidad1 & "," & vbCrLf & _
                                    "STFI2 = STFI2 + " & _Cantidad2 & "," & vbCrLf & _
                                    "STDV1 = STDV1 + " & _Cantidad1 & "," & vbCrLf & _
                                    "STDV2 = STDV2 + " & _Cantidad2 & vbCrLf & _
                                    "WHERE KOPR = '" & _Codigo & "'" & _
                                    vbCrLf & vbCrLf & _
                                    "UPDATE MAEST SET STFI1 = STFI1 + " & _Cantidad1 & "," & vbCrLf & _
                                    "STFI2 = STFI2 + " & _Cantidad2 & "," & vbCrLf & _
                                    "STDV1 = STDV1 + " & _Cantidad1 & "," & vbCrLf & _
                                    "STDV2 = STDV2 + " & _Cantidad2 & vbCrLf & _
                                    "WHERE EMPRESA = '" & _Empresa & _
                                    "' AND KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'" & _
                                    vbCrLf & vbCrLf & "---------------------------" & vbCrLf & vbCrLf

                Next

                Dim _Fecha_Svr As String = Format(FechaDelServidor(), "yyyyMMdd")

                Consulta_sql += "-- Actualizar Vale ---" & vbCrLf & vbCrLf & _
                                "Update Zw_Vales_Enc Set Estado = 'A',Funcionario_Activa = '" & FUNCIONARIO & "'" & vbCrLf & _
                                ",Fecha_Activacion = '" & _Fecha_Svr & "',Hora_Activacion = convert(nvarchar, GETDATE(), 108)" & vbCrLf & _
                                "Where NroVale = '" & _NroVale_activo & "'"

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    Sb_Ver_Documento(_NroVale_activo)
                    Beep()
                    ToastNotification.Show(Me, "VALE ACTIVADO CORRECTAMENTE" & vbCrLf &
                                           "EL STOCK FUE REPUESTO EN LAS BODEGAS CORRESPONDIENTE", My.Resources.ok_button,
                                          6 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If

            End If
        End If
    End Sub

    Private Sub Frm_Vales_Ficha_Doc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class