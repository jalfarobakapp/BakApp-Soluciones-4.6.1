Imports DevComponents.DotNetBar

Public Class Frm_Desp_03_Preparar_Armar_Bulto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Preparado As Boolean
    Dim _Cl_Despacho As Clas_Despacho

    Dim _Tbl_Lector_Prod_Despachados As DataTable

    Dim _Grabar_Con_Huella As Boolean

    Public Property Preparado As Boolean
        Get
            Return _Preparado
        End Get
        Set(value As Boolean)
            _Preparado = value
        End Set
    End Property

    Public Property Despachos As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Desp_03_Despachado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Grabar_Con_Huella = _Global_Row_Configuracion_Estacion.Item("Grabar_Despachos_Con_Huella")
        _Tbl_Lector_Prod_Despachados = _Cl_Despacho.Tbl_Lector_Prod_Despachados

        Rfle_Huella.Visible = _Grabar_Con_Huella

        Me.ActiveControl = Txt_Codigo_Barras

        For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

            Dim _Imagen As Integer

            Dim _CantC = _Fila.Item("CantC")
            Dim _CantD = _Fila.Item("CantD")
            Dim _CantE = _Fila.Item("CantE")
            Dim _CantDesp = _Fila.Item("CantDesp")
            Dim _Estado As String

            If Not CBool(_CantDesp) Then
                _Imagen = 5
                _Estado = "Por revisar..."
            Else
                If _CantC = _CantDesp Then
                    _Imagen = 4
                    _Estado = "Revisado completamente"
                Else
                    _Imagen = 3
                    _Estado = "Revisado parcialmente!"
                End If
            End If

            Dim lvi As ListViewItem = lvFics.Items.Add(_Fila.Item("Tido") & "-" & _Fila.Item("Nudo"), _Imagen)
            lvi.SubItems.Add(_Fila.Item("Nombre_Entidad"))
            lvi.SubItems.Add(_Estado)

        Next

        _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)

    End Sub

    Private Sub Txt_Codigo_Barras_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Codigo_Barras.KeyDown
        If e.KeyValue = Keys.Enter Then
            'Sb_Leer_Codigo(Txt_Codigo_Barras.Text)
            Sb_Leer_Codigo_Sin_Pistolear(Txt_Codigo_Barras.Text)
        End If
    End Sub

    'Sub Sb_Leer_Codigo(_Codigo_Barras As String)

    '    Dim _Documento As String = _Codigo_Barras.Trim

    '    Dim _Tido As String = Mid(_Documento, 1, 3)
    '    Dim _Nudo As String = numero_(Mid(_Documento, 4, 10), 10)

    '    Dim _ListV_Fila As ListViewItem
    '    lvFics.Focus()

    '    For Each item As ListViewItem In lvFics.Items

    '        If item.Text = _Tido & "-" & _Nudo Then
    '            item.Selected = True
    '            _ListV_Fila = item
    '            Exit For
    '        End If

    '    Next

    '    Dim _Idmaeedo As Integer = _Sql.Fx_Trae_Dato("MAEEDO", "IDMAEEDO",
    '                                                 "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'", True)

    '    Consulta_Sql = "Select Codigo,Descripcion,Case Untrans When 1 then CantCUd1 else CantCUd2 End As Cantidad
    '                    From " & _Global_BaseBk & "Zw_Despachos_Doc_Det
    '                    Where Id_Despacho = " & _Cl_Despacho.Id_Despacho & " And Idmaeedo = " & _Idmaeedo
    '    Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)


    '    Dim _CantDesp As Double = 0
    '    Dim _CantC As Double = 0

    '    Dim _Fila_Doc As DataRow

    '    Dim _Sobran As Boolean
    '    Dim _Faltan As Boolean
    '    Dim _Correcto As Boolean

    '    If CBool(_Idmaeedo) Then

    '        'Dim _Revisado As Boolean

    '        For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

    '            Dim _Id = _Fila.Item("Idrst")

    '            If _Id = _Idmaeedo Then
    '                _Correcto = _Fila.Item("Correcto")
    '                _Fila_Doc = _Fila
    '                Exit For
    '            End If

    '        Next

    '        Sb_Llenar_Tabla_Barras(_Cl_Despacho.Tbl_Lector_Prod_Despachados, _Tbl, _Cl_Despacho.Tbl_Despacho_Doc_Det, _Idmaeedo)

    '        If Not _Correcto Then

    '            Dim _Documento_Aceptado As Boolean

    '            Dim Fm As New Frm_Formulario_Lector_Barra(_Cl_Despacho.Tbl_Lector_Prod_Despachados, _Tbl)
    '            Fm.Permitir_Despachar_Menos = True
    '            Fm.ShowDialog(Me)

    '            '_Documento_Aceptado = Fm.Fx_Revisar_Pistoleo_Vs_Documento(False)

    '            _Documento_Aceptado = Fm.Pro_Documento_Aceptado

    '            _Sobran = CBool(Fm.Sobran)
    '            _Faltan = CBool(Fm.Faltan)
    '            Fm.Dispose()

    '            If _Documento_Aceptado Then

    '                Dim _Idmaeedo_Doc = _Fila_Doc.Item("Idrst")

    '                If _Idmaeedo_Doc = _Idmaeedo Then

    '                    For Each _Fila_Lector As DataRow In _Cl_Despacho.Tbl_Lector_Prod_Despachados.Rows

    '                        Dim _Codigo_Lector = _Fila_Lector.Item("Codigo")

    '                        For Each _Fila_Det As DataRow In _Cl_Despacho.Tbl_Despacho_Doc_Det.Rows

    '                            Dim _Idmaeedo_Det = _Fila_Det.Item("Idmaeedo")

    '                            If _Idmaeedo_Det = _Idmaeedo Then

    '                                Dim _Codigo_Det = _Fila_Det.Item("Codigo")

    '                                If _Codigo_Det = _Codigo_Lector Then

    '                                    Dim _Untrans = _Fila_Det.Item("Untrans")
    '                                    Dim _Cantidad_Det As Double = _Fila_Det.Item("CantCUd" & _Untrans)
    '                                    Dim _Cantidad_Desp As Double = _Fila_Lector.Item("Cantidad")
    '                                    Dim _Rtu As Double = _Fila_Det.Item("Rtu")

    '                                    Dim _Saldo As Double = _Cantidad_Det - _Cantidad_Desp

    '                                    Dim _CantDUd1 As Double = _Fila_Det.Item("DespUd1")
    '                                    Dim _CantDUd2 As Double

    '                                    If _CantDUd1 <> _Cantidad_Desp Then

    '                                        If _Cantidad_Desp > 0 Then

    '                                            'If _Saldo > 0 Then

    '                                            _CantDUd1 = _Cantidad_Desp '_Saldo
    '                                            _CantDUd2 = _Cantidad_Desp * _Rtu '_Saldo * _Rtu

    '                                            'ElseIf _Saldo = 0 Then

    '                                            '_CantDUd1 = _Cantidad_Det
    '                                            '_CantDUd2 = _Cantidad_Det * _Rtu

    '                                            'End If

    '                                            _Fila_Det.Item("CodFuncionario_Desp") = FUNCIONARIO

    '                                        Else

    '                                            _CantDUd1 = 0
    '                                            _CantDUd2 = 0
    '                                            _Fila_Det.Item("CodFuncionario_Desp") = String.Empty

    '                                        End If

    '                                        '_Fila_Det.Item("DespUd1") = _CantDespUd1
    '                                        '_Fila_Det.Item("DespUd2") = _CantDespUd2

    '                                        _Fila_Det.Item("CantDUd1") = _CantDUd1
    '                                        _Fila_Det.Item("CantDUd2") = _CantDUd2

    '                                        _CantDesp += _CantDUd1

    '                                    ElseIf _Saldo = 0 Then

    '                                        _CantDesp += _CantDUd1

    '                                    End If

    '                                End If

    '                            End If

    '                        Next

    '                    Next

    '                    Dim _Imagen As Integer
    '                    Dim _Estado As String

    '                    _CantC = _Fila_Doc.Item("CantC")

    '                    If Not CBool(_CantDesp) Then
    '                        _Imagen = 0
    '                        _Estado = "Falta confirmar despacho..."
    '                    Else
    '                        If _CantC = _CantDesp Then
    '                            _Imagen = 4
    '                            _Estado = "Revisado completamente"
    '                        Else
    '                            _Imagen = 3
    '                            _Estado = "Revisado parcialmente!"
    '                        End If
    '                    End If

    '                    _ListV_Fila.SubItems.Item(2).Text = _Estado
    '                    _ListV_Fila.ImageIndex = _Imagen

    '                End If

    '            Else

    '                If _Sobran Then
    '                    _ListV_Fila.SubItems.Item(2).Text = "Por revisar... Sobran productos,debe revisar nuevamente."
    '                    _ListV_Fila.ImageIndex = 0
    '                    MessageBoxEx.Show(Me, _ListV_Fila.SubItems.Item(2).Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                Else
    '                    If _Faltan Then
    '                        _ListV_Fila.SubItems.Item(2).Text = "Falta confirmar el despacho..."
    '                        _ListV_Fila.ImageIndex = 0
    '                        MessageBoxEx.Show(Me, _ListV_Fila.SubItems.Item(2).Text & vbCrLf &
    '                                          "Falta la guía de salida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                    End If
    '                End If

    '            End If

    '            _Correcto = (Not _Sobran And Not _Faltan And _Documento_Aceptado)

    '            _Fila_Doc.Item("CantDesp") = 0
    '            _Fila_Doc.Item("CantD") = 0

    '            For Each _FlD As DataRow In _Cl_Despacho.Tbl_Lector_Prod_Despachados.Rows

    '                _Fila_Doc.Item("CantDesp") += _FlD.Item("Cantidad")
    '                _Fila_Doc.Item("CantD") += _FlD.Item("Cantidad")

    '            Next

    '            _Fila_Doc.Item("Sobran") = _Sobran
    '            _Fila_Doc.Item("Faltan") = _Faltan
    '            _Fila_Doc.Item("Correcto") = _Correcto

    '        Else

    '            MessageBoxEx.Show(Me, "Documento revisado completamente", "Despachar documento", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If

    '    Else

    '        MessageBoxEx.Show(Me, "Este documento no se encuentra en el tratamiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

    '    End If

    '    Txt_Codigo_Barras.Text = String.Empty
    '    Txt_Codigo_Barras.Focus()

    'End Sub

    Sub Sb_Leer_Codigo_Sin_Pistolear(_Codigo_Barras As String)

        Dim _Documento As String = _Codigo_Barras.Trim

        If String.IsNullOrEmpty(_Documento) Then
            Return
        End If

        Dim _Tido As String = Mid(_Documento, 1, 3)
        Dim _Nudo As String = numero_(Mid(_Documento, 4, 10), 10)

        Dim _ListV_Fila As ListViewItem
        lvFics.Focus()

        For Each item As ListViewItem In lvFics.Items

            If item.Text = _Tido & "-" & _Nudo Then
                item.Selected = True
                _ListV_Fila = item
                Exit For
            End If

        Next

        Dim _Idmaeedo As Integer = _Sql.Fx_Trae_Dato("MAEEDO", "IDMAEEDO",
                                                     "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'", True)

        Dim _Tbl_Detalle_Documento As DataTable

        Dim _Confirmar As Boolean

        Dim Fm As New Frm_Validar_Documento_Detalle(_Cl_Despacho, _Idmaeedo)
        Fm.ShowDialog(Me)
        _Confirmar = Fm.Confirmar
        _Tbl_Detalle_Documento = Fm.Tbl_Detalle_Documento
        Fm.Dispose()


        Dim _CantDesp As Double = 0
        Dim _CantC As Double = 0

        Dim _Fila_Doc As DataRow

        Dim _Sobran As Boolean
        Dim _Faltan As Boolean
        Dim _Correcto As Boolean

        If _Confirmar Then

            For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                Dim _Id = _Fila.Item("Idrst")

                If _Id = _Idmaeedo Then
                    _Correcto = _Fila.Item("Correcto")
                    _Fila_Doc = _Fila
                    Exit For
                End If

            Next

            For Each _Fila_Lector As DataRow In _Tbl_Detalle_Documento.Rows

                Dim _Codigo_Lector = _Fila_Lector.Item("Codigo")
                Dim _Idmaeddo_Lector = _Fila_Lector.Item("Idmaeddo")

                For Each _Fila_Det As DataRow In _Cl_Despacho.Tbl_Despacho_Doc_Det.Rows

                    Dim _Idmaeedo_Det = _Fila_Det.Item("Idmaeedo")

                    If _Idmaeedo_Det = _Idmaeedo Then

                        Dim _Codigo_Det = _Fila_Det.Item("Codigo")

                        If _Codigo_Det = _Codigo_Lector Then

                            Dim _Untrans = _Fila_Det.Item("Untrans")
                            Dim _Cantidad_Det As Double = _Fila_Det.Item("CantCUd" & _Untrans)
                            Dim _Cantidad_Desp As Double = _Fila_Lector.Item("Cantidad_Despachada")
                            Dim _Rtu As Double = _Fila_Det.Item("Rtu")

                            Dim _Saldo As Double = _Cantidad_Det - _Cantidad_Desp

                            Dim _CantDUd1 As Double = _Fila_Det.Item("DespUd1")
                            Dim _CantDUd2 As Double

                            If _CantDUd1 <> _Cantidad_Desp Then

                                If _Cantidad_Desp > 0 Then

                                    _CantDUd1 = _Cantidad_Desp '_Saldo
                                    _CantDUd2 = _Cantidad_Desp * _Rtu '_Saldo * _Rtu

                                    _Fila_Det.Item("CodFuncionario_Desp") = FUNCIONARIO

                                Else

                                    _CantDUd1 = 0
                                    _CantDUd2 = 0
                                    _Fila_Det.Item("CodFuncionario_Desp") = String.Empty

                                End If

                                _Fila_Det.Item("CantDUd1") = _CantDUd1
                                _Fila_Det.Item("CantDUd2") = _CantDUd2

                                _CantDesp += _CantDUd1

                            ElseIf _Saldo = 0 Then

                                _CantDesp += _CantDUd1

                            End If

                        End If

                    End If

                Next

            Next

            Dim _Imagen As Integer
            Dim _Estado As String

            _CantC = _Fila_Doc.Item("CantC")

            If Not CBool(_CantDesp) Then
                _Imagen = 0
                _Estado = "Falta confirmar despacho..."
            Else
                If _CantC = _CantDesp Then
                    _Imagen = 4
                    _Estado = "Revisado completamente"
                    _Correcto = True
                Else
                    _Imagen = 3
                    _Estado = "Revisado parcialmente!"
                    _Faltan = True
                End If
            End If

            _ListV_Fila.SubItems.Item(2).Text = _Estado
            _ListV_Fila.ImageIndex = _Imagen


            '_Correcto = (Not _Sobran And Not _Faltan And _Documento_Aceptado)

            _Fila_Doc.Item("CantDesp") = 0
            _Fila_Doc.Item("CantD") = 0

            For Each _FlD As DataRow In _Tbl_Detalle_Documento.Rows

                _Fila_Doc.Item("CantDesp") += _FlD.Item("Cantidad_Despachada")
                _Fila_Doc.Item("CantD") += _FlD.Item("Cantidad_Despachada")

            Next

            _Fila_Doc.Item("Sobran") = _Sobran
            _Fila_Doc.Item("Faltan") = _Faltan
            _Fila_Doc.Item("Correcto") = _Correcto

        End If

        Txt_Codigo_Barras.Text = String.Empty
        Txt_Codigo_Barras.Focus()

    End Sub

    Sub Sb_Llenar_Tabla_Barras(ByRef _Tbl_Lector_Barra As DataTable,
                               _Tbl_Detalle_Doc As DataTable,
                               _Tbl_Despacho_Doc_Det As DataTable,
                               _Idmaeedo As Integer)

        _Tbl_Lector_Barra.Clear()

        For Each _Fila As DataRow In _Tbl_Detalle_Doc.Rows

            Dim _Codigo As String = _Fila.Item("Codigo")
            Dim _Descripcion As String = _Fila.Item("Descripcion")
            Dim _Cantidad_Documento As Double = _Fila.Item("Cantidad")

            If Not Fx_Existe_Producto(_Codigo, _Tbl_Lector_Barra) Then
                Sb_Insertar_Fila(_Codigo, _Descripcion, _Cantidad_Documento, _Tbl_Lector_Barra)
            End If

        Next

        For Each _Fila As DataRow In _Tbl_Lector_Barra.Rows

            Dim _Codigo As String = _Fila.Item("Codigo")
            Dim _Cantidad_Documento As Double = 0
            Dim _Cantidad_Desp As Double = 0

            For Each _Filad As DataRow In _Tbl_Despacho_Doc_Det.Rows

                Dim _Codigod = _Filad.Item("Codigo")
                Dim _Idmaeedo_Doc = _Filad.Item("Idmaeedo")

                If _Codigo = _Codigod And _Idmaeedo_Doc = _Idmaeedo Then

                    Dim _CantCUd1 = _Filad.Item("CantCUd1")
                    Dim _CantDUd1 = _Filad.Item("CantDUd1")
                    Dim _CantEUd1 = _Filad.Item("CantEUd1")

                    Dim _DespUd1 As Double

                    _DespUd1 = _Filad.Item("DespUd1")
                    _DespUd1 = _CantDUd1 + _CantEUd1

                    _Cantidad_Documento += _CantCUd1
                    _Cantidad_Desp += _DespUd1

                End If

            Next

            _Fila.Item("Cantidad") = _Cantidad_Desp
            _Fila.Item("Cantidad_Documento") = _Cantidad_Documento

            If CBool(_Cantidad_Desp) Then
                _Fila.Item("Codigo_Barras") = _Codigo
            End If

        Next

    End Sub

    Private Function Fx_Existe_Producto(_Codigo As String, _Tbl_Lector_Barra As DataTable) As Boolean

        Dim _Existe As Boolean
        _Codigo = Trim(_Codigo)

        For Each _Fila As DataRow In _Tbl_Lector_Barra.Rows

            Dim _Kopr = Trim(_Fila.Item("Codigo"))
            Dim _Kopral = Trim(_Fila.Item("Codigo_Barras"))

            If _Codigo = _Kopr Or _Codigo = _Kopral Then
                _Existe = True : Exit For
            End If

        Next

        Return _Existe

    End Function

    Sub Sb_Insertar_Fila(_Codigo As String,
                         _Descripcion As String,
                         _Cantidad_Documento As Double,
                         ByRef _Tbl_Lector_Barra As DataTable)

        Dim NewFila As DataRow
        NewFila = _Tbl_Lector_Barra.NewRow
        With NewFila

            .Item("Codigo_Barras") = Txt_Codigo_Barras.Text
            .Item("Codigo") = _Codigo
            .Item("Descripcion") = _Descripcion
            .Item("Cantidad") = 0
            .Item("Cantidad_Documento") = _Cantidad_Documento
            .Item("Problema") = String.Empty
            .Item("Es_Correcto") = False

        End With

        _Tbl_Lector_Barra.Rows.Add(NewFila)

    End Sub


    Private Sub lvFics_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvFics.MouseDoubleClick

        'With lvFics
        If lvFics.SelectedIndices.Count = 0 Then
            Exit Sub
        End If

        ' Comprobar en que columna se ha hecho doble clic
        ' El valor de e.X es relativo al control,
        ' por tanto, no hace falta añadir nada más.

        'If e.X < .Columns(0).Width Then

        ' El nombre

        ' Abrir el fichero indicado
        ' Combinar los paths para que se agregue el separador de directorio
        ' si así hiciera falta
        Dim _Archivo As String = Replace(lvFics.SelectedItems(0).SubItems(0).Text, "-", "") '.SelectedItems(0).SubItems(0).Text)
        'Process.Start(fic)

        'Sb_Leer_Codigo(_Archivo)
        Sb_Leer_Codigo_Sin_Pistolear(_Archivo)

        'Else

        ' El directorio

        ' Abrir la ventana con el directorio del fichero indicado

        'Dim dir As String = .SelectedItems(0).SubItems(1).Text
        'Process.Start("explorer.exe", dir)
        'End If

        'End With

    End Sub

    Private Sub Btn_Despachar_Click(sender As Object, e As EventArgs) Handles Btn_Despachar.Click

        Dim _CantC As Double
        Dim _CantD As Double

        Dim _Sobran As Integer
        Dim _Faltan As Integer

        For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

            _CantC += _Fila.Item("CantC")
            _CantD += _Fila.Item("CantD")

            If _Fila.Item("Faltan") Then _Faltan += 1
            If _Fila.Item("Sobran") Then _Sobran += 1

        Next

        If Not CBool(_CantD) Then
            MessageBoxEx.Show(Me, "Debe confirmar los documentos para poder despachar la orden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            If CBool(_Sobran) Then

                MessageBoxEx.Show(Me, "No puede generar el despacho ya que existen productos que han sido pistoleados de mas en alguno de los documentos",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Else

                If (Not CBool(_Sobran) And Not CBool(_Faltan)) Then

                    _Preparado = True

                ElseIf _Faltan Then

                    Dim _Pregunta = MessageBoxEx.Show(Me, "No se confirmaron todos los productos de los documentos." & vbCrLf &
                                        "Si despacha ahora, los productos que están pendientes se enviaran en una nueva orden de despacho." & vbCrLf & vbCrLf &
                                         "¿Desea despachar de todas formas?", "Despacho parcializado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

                    If _Pregunta = DialogResult.Yes Then
                        _Preparado = True
                    End If

                End If

            End If

        End If

        If _Preparado Then

            Dim _CodFuncionario As String = FUNCIONARIO

            If _Grabar_Con_Huella Then

                Dim _Verificado As Boolean
                Dim _Graba_Sin_Huella As Boolean
                Dim _Row_Usuario As DataRow

                Try
                    Dim Fm As New VerificationForm(Nothing)
                    Fm.Cerrar_Al_Confirmar = True
                    Fm.ShowDialog(Me)
                    _Verificado = Fm.Verificado
                    _Graba_Sin_Huella = Fm.Graba_Sin_Huella
                    _Row_Usuario = Fm.Row_Usuario
                    Fm.Dispose()
                Catch ex As Exception
                    MessageBoxEx.Show(Me, ex.Message, "Error Lector de huellas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Graba_Sin_Huella = True
                End Try

                If _Graba_Sin_Huella Then

                    If Not Fx_Tiene_Permiso(Me, "Doc00050") Then
                        _Preparado = False
                        Return
                    End If

                Else

                    If IsNothing(_Row_Usuario) Then
                        _Preparado = False
                        Return
                    End If

                    _CodFuncionario = _Row_Usuario.Item("KOFU")

                End If

            End If

            _Preparado = _Cl_Despacho.Fx_Accion_Preparacion(Txt_Observaciones.Text, _CodFuncionario)

            If _Preparado Then
                Me.Close()
            Else
                MessageBoxEx.Show(Me, _Cl_Despacho.Error, "Problemas!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub Frm_Desp_03_Preparar_Armar_Bulto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            If Not Me.ControlBox Then
                MessageBoxEx.Show(Me, "Debe confirmar los documentos para poder despachar la orden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Desp_03_Preparar_Armar_Bulto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
    End Sub
End Class
