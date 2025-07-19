Imports DevComponents.DotNetBar

Public Class Frm_St_Estado_05_Reparacion2

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ot As Integer
    Dim _Grabar As Boolean
    Dim _DsDocumento As DataSet

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Row_Notas As DataRow
    Dim _RowEntidad As DataRow
    Dim _Tbl_DetProd_Cov As DataTable
    Dim _Tbl_DetProd_Srv As DataTable
    Dim _Tbl_OperacionesXServ As DataTable

    Dim _Editando_documento As Boolean

    Dim _Motivo_no_reparo As String

    Dim _Horas_Mano_de_Obra_Repara As Double
    Dim Imagenes_32x32 As ImageList

    Dim _Fijar_Estado As Boolean

    Dim _Accion As Accion

    Public Property RowEntidad As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public Property CodTecnico_Repara As String
    Public Property SoloLectura As Boolean

    Public Property DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(value As DataSet)
            _DsDocumento = value
            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_DetProd_Cov = _DsDocumento.Tables(7)
            _Tbl_OperacionesXServ = _DsDocumento.Tables(10)
            _Tbl_DetProd_Srv = _DsDocumento.Tables(11)
        End Set
    End Property

    Public Property Fijar_Estado As Boolean
        Get
            Return _Fijar_Estado
        End Get
        Set(value As Boolean)
            _Fijar_Estado = value
        End Set
    End Property

    Public Property Id_Ot As Integer
        Get
            Return _Id_Ot
        End Get
        Set(value As Integer)
            _Id_Ot = value
        End Set
    End Property

    Public Sub New(_Accion As Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Accion = _Accion

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Estado_05_Reparacion2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)

        Dim _CodFuncionario = _Row_Encabezado.Item("CodTecnico_Asignado")

        Txt_Tecnico_Taller.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller", "NomFuncionario",
                                           "CodFuncionario = '" & _CodFuncionario & "'").ToString.Trim

        Txt_NroSerie.Text = _Row_Encabezado.Item("NroSerie")
        Txt_Nota.Text = _Row_Notas.Item("Nota_Etapa_05")
        Chk_No_se_pudo_reparar_el_equipo.Checked = _Row_Notas.Item("Chk_No_se_pudo_reparar")
        Btn_VerMotivo.Visible = Chk_No_se_pudo_reparar_el_equipo.Checked

        Sb_Actualizar_Grilla()
        Sb_Marcar_Grilla()

        If SoloLectura Then
            Btn_Fijar_Estado.Enabled = False
            Txt_Nota.ReadOnly = True
            Txt_NroSerie.ReadOnly = True
            Txt_Tecnico_Taller.ReadOnly = True
            Me.Text += " (Documento solo de lectura)"
            Chk_No_se_pudo_reparar_el_equipo.Enabled = False
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_DetProd_Srv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").HeaderText = "Ev."
            .Columns("BtnImagen").Width = 30
            .Columns("BtnImagen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 420
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ud").Visible = True
            .Columns("Ud").HeaderText = "UM"
            .Columns("Ud").Width = 30
            .Columns("Ud").ReadOnly = True
            .Columns("Ud").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In _Grilla.Rows

            Dim _Chk_Validado As Boolean = _Fila.Cells("Chk").Value
            Dim _Utilizado As Boolean = _Fila.Cells("Utilizado").Value

            _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)

            If _Chk_Validado Or SoloLectura Then
                If _Utilizado Then
                    _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("OK")
                Else
                    _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                    _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("NO")
                End If
            Else
                _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("WARNING")
            End If

            _Fila.Cells("Codigo").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            _Fila.Cells("Cantidad_Utilizada").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)

        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        'If SoloLectura Then
        '    MessageBoxEx.Show(Me, "Documento de solo lectura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Semilla As Integer = _Fila.Cells("Semilla").Value

        Dim _Grabar As Boolean

        Consulta_sql = "Select Serv.Id,Serv.Id_Ot,Serv.Semilla,Serv.Codigo,Isnull(Oper.Descripcion,'') As Descripcion," & vbCrLf &
                       "Serv.CodReceta,Serv.Operacion,Serv.Orden,Serv.CantMayor1,Serv.Cantidad,Serv.CantidadRealizada,Serv.Precio," &
                       "Serv.Total,Serv.Realizado,Serv.Externa,Cast(1 As Bit) As Chk" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_OpeXServ Serv" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones Oper On Serv.Operacion = Oper.Operacion" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & " And Semilla = " & _Semilla
        Dim _Tbl_Operaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)



        For Each _Fl As DataRow In _Tbl_OperacionesXServ.Rows

            If _Fl.Item("Semilla") = _Semilla Then

                For Each _Fl2 As DataRow In _Tbl_Operaciones.Rows

                    If _Fl.Item("Id") = _Fl2.Item("Id") Then

                        Dim _Chk As Boolean = _Fl.Item("Chk")
                        Dim _Cantidad As Integer = _Fl.Item("Cantidad")

                        '_Fl2.Item("Cantidad") = _Cantidad
                        _Fl2.Item("Chk") = _Chk

                    End If

                Next

            End If

        Next

        Dim Fm2 As New Frm_OperacionesXServicio("")
        Fm2.TblOperaciones = _Tbl_Operaciones
        Fm2.SoloLectura = SoloLectura
        Fm2.ShowDialog(Me)
        _Grabar = Fm2.Grabar
        Fm2.Dispose()

        If _Grabar Then

            For Each _Fl As DataRow In _Tbl_OperacionesXServ.Rows

                If _Fl.Item("Semilla") = _Semilla Then

                    For Each _Fl2 As DataRow In _Tbl_Operaciones.Rows

                        If _Fl.Item("Id") = _Fl2.Item("Id") Then

                            Dim _Chk As Boolean = _Fl2.Item("Chk")
                            Dim _Cantidad As Integer = _Fl2.Item("Cantidad")

                            _Fl.Item("Cantidad") = _Cantidad
                            _Fl.Item("Chk") = _Chk
                            _Fl.Item("Realizado") = _Chk
                            _Fl.Item("CantidadRealizada") = _Cantidad

                            If Not _Chk Then _Fl.Item("CantidadRealizada") = 0

                        End If

                    Next

                End If

            Next

            _Fila.Cells("Utilizado").Value = True
            _Fila.Cells("Chk").Value = True
            Sb_Marcar_Grilla()

        End If

    End Sub

    Function Fx_Fijar_Estado() As Boolean


        If Not Chk_No_se_pudo_reparar_el_equipo.Checked Then
            _Motivo_no_reparo = String.Empty
        End If

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Reparacion_Realizada = String.Empty

        For _i = 0 To 31
            _Reparacion_Realizada = Replace(_Reparacion_Realizada, Chr(_i), " ")
        Next

        Dim _Nota_Etapa_05 As String = Txt_Nota.Text
        Dim _Chk_no_se_pudo_reparar = CInt(Chk_No_se_pudo_reparar_el_equipo.Checked) * -1

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                       "Nota_Etapa_05 = '" & _Nota_Etapa_05 & "'" & vbCrLf &
                       ",Chk_no_se_pudo_reparar = " & _Chk_no_se_pudo_reparar & vbCrLf &
                       ",Reparacion_Realizada = '" & _Reparacion_Realizada & "'" & vbCrLf &
                       ",Motivo_no_reparo = '" & _Motivo_no_reparo & "'" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

        '**********************************'**********************************

        Dim _HH As String = De_Num_a_Tx_01(_Horas_Mano_de_Obra_Repara, False, 5)

        Dim _CodFuncionario = _Row_Encabezado.Item("CodTecnico_Asignado")

        ' ACTUALIZAR ENCABEZADO DE DOCUMENTO
        Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                       "CodTecnico_Repara = '" & _CodFuncionario & "'," & vbCrLf &
                       "Horas_Mano_de_Obra_Repara = " & _HH & vbCrLf &
                       "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf


        If _Accion = Accion.Nuevo Then

            ' ACTUALIZAR ENCABEZADO DE DOCUMENTO
            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                           "CodEstado = 'V'" & vbCrLf &
                           "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf


            ' ACTUALIZAR ESTADO
            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                           "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                           "(" & _Id_Ot & ",'R',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

        End If


        Consulta_sql += "Delete " & _Global_BaseBk & "Zw_St_OT_DetProd Where Desde_COV = 1 And Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf


        For Each _Fila_Cov As DataRow In _Tbl_DetProd_Cov.Rows


            Dim _Utilizado = CInt(_Fila_Cov.Item("Utilizado")) * -1

            Dim _Desde_COV = CInt(_Fila_Cov.Item("Desde_COV")) * -1
            Dim _Idmaeedo_Cov = _Fila_Cov.Item("Idmaeedo_Cov")
            Dim _Idmaeddo_Cov = _Fila_Cov.Item("Idmaeddo_Cov")

            Dim _Codigo = _Fila_Cov.Item("Codigo")
            Dim _Descripcion = _Fila_Cov.Item("Descripcion")

            Dim _Un As Integer = _Fila_Cov.Item("Un")

            Dim _Ud = _Fila_Cov.Item("Ud")

            Dim _Cantidad = _Fila_Cov.Item("Cantidad")
            Dim _Cantidad_Utilizada = _Fila_Cov.Item("Cantidad_Utilizada")

            Dim _CantUd1 = _Fila_Cov.Item("CantUd1")
            Dim _CantUd2 = _Fila_Cov.Item("CantUd2")
            Dim _Precio = _Fila_Cov.Item("Precio")
            Dim _Neto_Linea = _Fila_Cov.Item("Neto_Linea")
            Dim _Iva_Linea = _Fila_Cov.Item("Iva_Linea")
            Dim _Total_Linea = _Fila_Cov.Item("Total_Linea")

            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_DetProd (Id_Ot,Utilizado,Codigo,Descripcion," &
                           "Cantidad,Cantidad_Utilizada,Ud,Un," &
                           "CantUd1,CantUd2,Precio,Neto_Linea,Iva_Linea,Total_Linea,Desde_COV,Idmaeedo_Cov,Idmaeddo_Cov) Values " &
                           "(" & _Id_Ot & "," & _Utilizado & ",'" & _Codigo & "','" & _Descripcion &
                           "'," & De_Num_a_Tx_01(_Cantidad, False, 5) &
                           "," & De_Num_a_Tx_01(_Cantidad_Utilizada, False, 5) &
                           ",'" & _Ud & "'," & _Un &
                           "," & De_Num_a_Tx_01(_CantUd1, False, 5) &
                           "," & De_Num_a_Tx_01(_CantUd2, False, 5) &
                           "," & De_Num_a_Tx_01(_Precio, False, 5) &
                           "," & De_Num_a_Tx_01(_Neto_Linea, False, 5) &
                           "," & De_Num_a_Tx_01(_Iva_Linea, False, 5) &
                           "," & De_Num_a_Tx_01(_Total_Linea, False, 5) &
                           ",1," & _Idmaeedo_Cov & "," & _Idmaeddo_Cov & ")" & vbCrLf

        Next


        Dim _SerUtilizados As Integer

        For Each _Fila_Srv As DataRow In _Tbl_DetProd_Srv.Rows

            If _Fila_Srv.Item("Utilizado") Then
                _SerUtilizados += 1
            End If

        Next

        If _SerUtilizados = 0 Then
            MessageBoxEx.Show(Me, "Debe confirmar algun servicio para poder fijar el estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        For Each _Fila_Cov As DataRow In _Tbl_DetProd_Srv.Rows

            Dim _Semilla As Integer = _Fila_Cov.Item("Semilla")
            Dim _Cantidad_Utilizada As Integer = _Fila_Cov.Item("Cantidad")
            Dim _Utilizado As Integer = Convert.ToInt32(_Fila_Cov.Item("Utilizado"))

            If Not CBool(_Utilizado) Then
                _Cantidad_Utilizada = 0
            End If

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_DetProd Set " &
                            "Utilizado=" & _Utilizado & ",Cantidad_Utilizada = " & _Cantidad_Utilizada &
                            " Where Semilla = " & _Semilla & vbCrLf

            For Each _Fl As DataRow In _Tbl_OperacionesXServ.Rows

                Dim _Id As Integer = _Fl.Item("Id")
                Dim _Realizado As Integer = Convert.ToInt32(_Fl.Item("Realizado"))
                Dim _CantidadRealizada As Integer = Convert.ToInt32(_Fl.Item("CantidadRealizada"))

                If _Fl.Item("Semilla") = _Semilla Then

                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_OpeXServ Set " &
                                    "CantidadRealizada = " & _CantidadRealizada & ",Realizado = " & _Realizado &
                                    " Where Id = " & _Id & vbCrLf

                End If

            Next

        Next


        '**********************************'**********************************

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            Dim _CampoPrecio As String

            If True Then
                _CampoPrecio = "PPPRNE"
            Else ' Bruto
                _CampoPrecio = "PPPRBR"
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Id_Ot = " & _Id_Ot
            Dim _Doc_Asociados As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            For Each _FlDoc As DataRow In _Doc_Asociados.Rows

                Dim _Idmaeedo_Origen As Integer = _FlDoc.Item("Idmaeedo")

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen & "
                                Select *,CAse When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End As 'Cantidad',
                                CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori',
                                Case WHEN UDTRPR = 1 Then " & _CampoPrecio & " Else " & _CampoPrecio & "*RLUDPR End AS 'Precio',
                                0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                                From MAEDDO  With ( NOLOCK ) 
                                Where IDMAEEDO = " & _Idmaeedo_Origen & "  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                                Order by IDMAEEDO,IDMAEDDO 
                                Select * From MAEIMLI
                                Where IDMAEEDO = " & _Idmaeedo_Origen & " 
                                Select * From MAEDTLI
                                Where IDMAEEDO = " & _Idmaeedo_Origen & " 
                                Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Origen


                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                Dim _Fecha_Emision = FechaDelServidor()

                Dim Fm_Post As New Frm_Formulario_Documento("NVV", csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)
                Fm_Post.Sb_Limpiar(Mod_Modalidad)
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)
                Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False)
                Dim _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
                Fm_Post.Dispose()

                If CBool(_New_Idmaeedo) Then

                    Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _New_Idmaeedo
                    Dim _RowDocumento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Tido = _RowDocumento.Item("TIDO")
                    Dim _Nudo = _RowDocumento.Item("NUDO")
                    Dim _Fecha_Doc = _RowDocumento.Item("FEEMDO")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Doc,Fecha_Asociacion," &
                                   "Garantia,Seleccionado,Documento_Externo,MovTodasSubOT) Values " &
                                   "(" & _Id_Ot & "," & _New_Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','A','" & Format(_Fecha_Doc, "yyyyMMdd") & "'" &
                                   ",'" & Format(_Fecha_Doc, "yyyyMMdd") & "',0,0,0,0)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Next

            Return True

        End If

    End Function

    Function Fx_Fijar_Estado_No_Se_Pudo_Reparar() As Boolean

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Texto = "NO SE PUDO REPARAR EL EQUIPO"

        Dim _Chk_no_se_pudo_reparar = 1

        Dim _CodFuncionario = _Row_Encabezado.Item("CodTecnico_Asignado")

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "INDIQUE EL MOTIVO DEL PORQUE NO FUE POSIBLE REPARAR", "INFORMACION",
                               _Motivo_no_reparo,,, 300, True, _Tipo_Imagen.Texto)

        If Not _Aceptar Then
            Return False
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set" & Space(1) &
                       "CodEstado = 'V'," & vbCrLf &
                       "CodTecnico_Repara = '" & _CodFuncionario & "'," & vbCrLf &
                       "Horas_Mano_de_Obra_Repara = 0," & vbCrLf &
                       "Fecha_Cierre = Getdate()" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                        "Nota_Etapa_05 = '" & _Texto & "'" & vbCrLf &
                        ",Motivo_no_reparo = '" & _Motivo_no_reparo & "'" & vbCrLf &
                        ",Chk_no_se_pudo_reparar = " & _Chk_no_se_pudo_reparar & vbCrLf &
                        ",Nota_Etapa_06 = '" & _Texto & "'" & vbCrLf &
                        ",Nota_Etapa_07 = '" & _Texto & "'" & vbCrLf &
                        "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

        Consulta_sql += "Delete " & _Global_BaseBk & "Zw_St_OT_Estados Where Id_Ot = " & _Id_Ot & " And CodEstado In ('R','V','F')" & vbCrLf & vbCrLf

        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                     "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                     "(" & _Id_Ot & ",'R',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Return True
        End If

    End Function

    Private Sub Btn_Fijar_Estado_Click(sender As Object, e As EventArgs) Handles Btn_Fijar_Estado.Click

        If Fx_Fijar_Estado() Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado",
                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Fijar_Estado = True
            Me.Close()

        End If

    End Sub

    Private Sub Chk_No_se_pudo_reparar_el_equipo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_No_se_pudo_reparar_el_equipo.CheckedChanged

        If SoloLectura Then
            Return
        End If

        If Chk_No_se_pudo_reparar_el_equipo.Checked Then

            If Fx_Fijar_Estado_No_Se_Pudo_Reparar() Then

                If MessageBoxEx.Show(Me, "¿Confirma Fijar el estado como NO REPARADO?", "Confirmación",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then

                    _Fijar_Estado = True
                    Me.Close()

                End If

            End If

        End If

    End Sub

    Private Sub Btn_VerMotivo_Click(sender As Object, e As EventArgs) Handles Btn_VerMotivo.Click
        MessageBoxEx.Show(Me, _Row_Notas.Item("Motivo_no_reparo"), "Motivo",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
