Imports DevComponents.DotNetBar

Public Class Frm_Importar_Stock_OEBD

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblProductos As DataTable
    Dim _Cancelar As Boolean

    Dim _Empresa_Ori, _Sucursal_Ori, _Bodega_Ori As String
    Dim _Empresa_Des, _Sucursal_Des, _Bodega_Des As String

    Dim _Row_DnExt As DataRow
    Dim _Cadena_ConexionSQL_Server_Origen As String
    Dim _Ejecutar_Automaticamente As Boolean

    Dim _Campo_Codigo As String

    Public Property Empresa_Ori As String
        Get
            Return _Empresa_Ori
        End Get
        Set(value As String)
            _Empresa_Ori = value
        End Set
    End Property

    Public Property Sucursal_Ori As String
        Get
            Return _Sucursal_Ori
        End Get
        Set(value As String)
            _Sucursal_Ori = value
        End Set
    End Property

    Public Property Bodega_Ori As String
        Get
            Return _Bodega_Ori
        End Get
        Set(value As String)
            _Bodega_Ori = value
        End Set
    End Property

    Public Property Empresa_Des As String
        Get
            Return _Empresa_Des
        End Get
        Set(value As String)
            _Empresa_Des = value
        End Set
    End Property

    Public Property Sucursal_Des As String
        Get
            Return _Sucursal_Des
        End Get
        Set(value As String)
            _Sucursal_Des = value
        End Set
    End Property

    Public Property Bodega_Des As String
        Get
            Return _Bodega_Des
        End Get
        Set(value As String)
            _Bodega_Des = value
        End Set
    End Property

    Public Property Ejecutar_Automaticamente As Boolean
        Get
            Return _Ejecutar_Automaticamente
        End Get
        Set(value As Boolean)
            _Ejecutar_Automaticamente = value
        End Set
    End Property

    Public Property SoloProductosConStock As Boolean

    Public Sub New(_TblProductos As DataTable, _Cadena_ConexionSQL_Server_Origen As String, _Campo_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'Dim _Servidor = _Row_DnExt.Item("Servidor")
        'Dim _Puerto = _Row_DnExt.Item("Puerto")
        'Dim _Usuario = _Row_DnExt.Item("Usuario")
        'Dim _Clave = _Row_DnExt.Item("Clave")
        'Dim _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")

        'If Not String.IsNullOrEmpty(_Puerto) Then
        '    _Servidor = _Servidor & "," & _Puerto
        'End If

        Me._Campo_Codigo = _Campo_Codigo
        Me._TblProductos = _TblProductos
        Me._Cadena_ConexionSQL_Server_Origen = _Cadena_ConexionSQL_Server_Origen

        Sb_Color_Botones_Barra(Bar2)

    End Sub
    Private Sub Frm_Importar_Stock_OEBD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tiempo_Accion_Automatico.Enabled = Ejecutar_Automaticamente
        BtnProcesar.Enabled = Not Ejecutar_Automaticamente
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Tiempo_Accion_Automatico_Tick(sender As Object, e As EventArgs) Handles Tiempo_Accion_Automatico.Tick
        Tiempo_Accion_Automatico.Enabled = False
        If Not (_TblProductos Is Nothing) Then
            Sb_Procesar(_TblProductos, True)
        End If
    End Sub

    Private Sub BtnProcesar_Click(sender As Object, e As EventArgs) Handles BtnProcesar.Click
        Sb_Procesar(_TblProductos, True)
    End Sub

    Sub Sb_Procesar(_TblProductos As DataTable, _Mostrar_Mensajes As Boolean)

        Try

            BtnCancelar.Enabled = True
            BtnProcesar.Enabled = False
            Me.ControlBox = False

            _Cancelar = False

            Dim _Contador As Integer = 0
            Dim _Contador_Encontrados As Integer = 0
            Dim _Contador_Insertados As Integer = 0
            Dim _Contador_No_Encontrados As Integer = 0
            Dim _Cant_Productos As Integer

            Dim _Consolidar_Stock As New Class_Consolidar_Stock()

            AddToLog("Importar Stock desde otra bodega de otra empresa", FormatNumber(_TblProductos.Rows.Count, 0) & " Productos")

            Dim _SqlQuery = String.Empty
            Dim _Cl_Importar_Stock As New Cl_Importar_Stock_Otra_Bodega(_Cadena_ConexionSQL_Server_Origen)

            Dim _TblProductos_Encontrados As DataTable

            If SoloProductosConStock Then
                _TblProductos_Encontrados = _Cl_Importar_Stock.Fx_Traer_Productos_Con_Stock_Positivo(_TblProductos,
                                                                                                     _Campo_Codigo,
                                                                                                     _Empresa_Ori,
                                                                                                     _Sucursal_Ori,
                                                                                                     _Bodega_Ori)
            Else
                _TblProductos_Encontrados = _Cl_Importar_Stock.Fx_Traer_Productos(_TblProductos, _Campo_Codigo)
            End If

            If CBool(_TblProductos_Encontrados.Rows.Count) Then
                If _Mostrar_Mensajes Then
                    MessageBoxEx.Show(Me, "Se encontraron " & FormatNumber(_TblProductos_Encontrados.Rows.Count, 0) & " relacionados entre ambas bases",
                                  "Productos encontrador", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBoxEx.Show(Me, "No se encontraron productos relacionados entre ambas bases en el listado enviado",
                                  "Productos no encontrados", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                Return
            End If

            _Cant_Productos = _TblProductos_Encontrados.Rows.Count

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = _Cant_Productos
            Barra_Progreso.Maximum = _Cant_Productos

            Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server

            For Each _Fila As DataRow In _TblProductos_Encontrados.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Codigo As String = Trim(_Fila.Item("Codigo"))
                Dim _Descripcion As String = Trim(_Fila.Item("Descripcion"))

                Dim _FECHA As Date = FechaDelServidor()

                LblEstado.Text = "Producto: " & _Codigo & " - " & _Descripcion

                Dim _Stock_ConsUd1 As Double = 0
                Dim _Stock_ConsUd2 As Double = 0

                Dim _Cl_Importar_Stock_Otra_Bodega As New Cl_Importar_Stock_Otra_Bodega(_Cadena_ConexionSQL_Server_Origen)

                Dim _Query = _Cl_Importar_Stock_Otra_Bodega.Fx_Extraer_Stock_X_Producto(_Empresa_Ori, _Sucursal_Ori, _Bodega_Ori,
                                                                                        _Empresa_Des, _Sucursal_Des, _Bodega_Des,
                                                                                        _Codigo)

                If String.IsNullOrEmpty(_Query) Then
                    _Contador_No_Encontrados += 1
                Else
                    AddToLog(_Codigo & "-" & _Descripcion & ", Sincronizado Ok", FormatNumber(_Contador_Encontrados, 0) & " Productos")
                    _SqlQuery += _Query & vbCrLf
                    _Contador_Encontrados += 1
                End If

                _Contador += 1

                Lbl_Contador.Text = "Productos en bodega " & _Bodega_Ori & ". Encontrados: " & FormatNumber(_Contador_Encontrados, 0) & ", No encontrados: " & FormatNumber(_Contador_No_Encontrados, 0)

                System.Windows.Forms.Application.DoEvents()

                Progreso_Porc.Value = ((_Contador * 100) / _Cant_Productos)
                Progreso_Cont.Value += 1
                Barra_Progreso.Value += 1

                Barra_Progreso.Text = "Consolidando Stock, " & FormatNumber(_Contador + 1, 0) & " de " &
                               FormatNumber(_Cant_Productos, 0)

                If _Cancelar Then
                    AddToLog("Consolidación Stock", "Acción cancelada por el usuario")
                    MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf &
                                      "Total productos IMPORTADOS " & _Contador_Encontrados,
                                      "Cancelar importación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

            Next

            If Not String.IsNullOrEmpty(_SqlQuery) Then
                If _Sql.Ej_consulta_IDU(_SqlQuery) Then
                    AddToLog("Datos importados correctamente", "Fin importación")
                    MessageBoxEx.Show(Me, FormatNumber(_Contador_Encontrados, 0) & " Productos importados correctamente",
                             "Importar stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            System.Windows.Forms.Application.DoEvents()

        Catch ex As Exception
        Finally
            Barra_Progreso.Text = String.Empty
            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0
            Barra_Progreso.Value = 0

            BtnCancelar.Enabled = False
            BtnProcesar.Enabled = True
            Me.ControlBox = True
        End Try

        Me.Close()

    End Sub

    Private Sub AddToLog(ByVal Accion As String,
                         ByVal Descripcion As String)

        If String.IsNullOrEmpty(Accion) And String.IsNullOrEmpty(Descripcion) Then
            TxtLog.Text += "" & vbCrLf
        Else
            If Not String.IsNullOrEmpty(Descripcion) Then Descripcion = "(" & Descripcion & ")"
            TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & Space(1) & Descripcion & vbCrLf
        End If

        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()

    End Sub


End Class
