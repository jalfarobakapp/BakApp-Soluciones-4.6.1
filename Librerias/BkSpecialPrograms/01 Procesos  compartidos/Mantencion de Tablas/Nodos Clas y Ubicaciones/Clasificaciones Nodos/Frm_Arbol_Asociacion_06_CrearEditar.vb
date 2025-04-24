Imports DevComponents.DotNetBar

Public Class Frm_Arbol_Asociacion_06_CrearEditar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo_Nodo As Integer
    Dim _Identificacdor_NodoPadre As Integer
    Dim _Nodo_Raiz As Integer
    Dim _Fullpath As String
    Public Property Cl_Arbol_Asociaciones As New Cl_Arbol_Asociaciones
    Public Property Grabar As Boolean
    Private _Clas_Unica_X_Producto As Boolean

    Public Sub New(_Codigo_Nodo As Integer,
                   _Identificacdor_NodoPadre As Integer,
                   _Nodo_Raiz As Integer,
                   _Clas_Unica_X_Producto As Boolean,
                   _Fullpath As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigo_Nodo = _Codigo_Nodo
        Me._Identificacdor_NodoPadre = _Identificacdor_NodoPadre
        Me._Nodo_Raiz = _Nodo_Raiz
        Me._Clas_Unica_X_Producto = _Clas_Unica_X_Producto
        Me._Fullpath = _Fullpath

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Arbol_Asociacion_06_CrearEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TENGO QUE DEFINIR DESDE DONDE SACAR EL CAMPO Nodo_Raiz, no me acuerdo.

        _Cl_Arbol_Asociaciones.Fx_Llenar_Asociacion(_Codigo_Nodo)
        _Cl_Arbol_Asociaciones.Zw_TblArbol_Asociaciones.Identificacdor_NodoPadre = _Identificacdor_NodoPadre
        _Cl_Arbol_Asociaciones.Zw_TblArbol_Asociaciones.Nodo_Raiz = _Nodo_Raiz

        Txt_Codigo_Nodo.Text = _Codigo_Nodo

        If CBool(_Codigo_Nodo) Then

            With _Cl_Arbol_Asociaciones.Zw_TblArbol_Asociaciones
                Txt_Codigo_Madre.Text = .Codigo_Madre
                Txt_Descripcion.Text = .Descripcion
                Rdb_Es_Seleccionable.Checked = .Es_Seleccionable
                Rdb_Es_Padre.Checked = .Es_Padre
            End With

        End If

        Lbl_Codigo_Nodo.Visible = CBool(_Codigo_Nodo)
        Txt_Codigo_Nodo.Visible = CBool(_Codigo_Nodo)
        Txt_Codigo_Madre.ReadOnly = CBool(_Codigo_Nodo)

        Txt_Codigo_Madre.Enabled = _Clas_Unica_X_Producto
        Lbl_Codigo_Madre.Enabled = _Clas_Unica_X_Producto
        Txt_Fullpath.Text = _Fullpath

        If _Clas_Unica_X_Producto Then
            Me.ActiveControl = Txt_Codigo_Madre
        Else
            Me.ActiveControl = Txt_Descripcion
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Not Rdb_Es_Padre.Checked AndAlso Not Rdb_Es_Seleccionable.Checked Then
            MessageBoxEx.Show(Me, "Debe seleccionar un tipo de carpeta: Es Seleccionable o Es Padre", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Clas_Unica_X_Producto AndAlso Rdb_Es_Seleccionable.Checked And String.IsNullOrEmpty(Txt_Codigo_Madre.Text) Then
            MessageBoxEx.Show(Me, "Falta el código Madre", "Validación Es Seleccionable", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Codigo_Madre.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Descripcion.Text) Then
            MessageBoxEx.Show(Me, "Falta la descripción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        If _Clas_Unica_X_Producto And Not String.IsNullOrEmpty(Txt_Codigo_Madre.Text) Then

            Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                           "Clas_Unica_X_Producto = 1 And Codigo_Madre = '" & Txt_Codigo_Madre.Text & "' " &
                                                           "And Codigo_Nodo <> " & _Codigo_Nodo)

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Ya existe el código madre: " & Txt_Codigo_Madre.Text, "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        If CBool(_Codigo_Nodo) And Rdb_Es_Seleccionable.Checked Then

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                           "Identificacdor_NodoPadre = " & _Codigo_Nodo)
            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Esta clasificación no puede ser seleccionable, ya que tiene carpetas asociadas", "Validación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Rdb_Es_Padre.Checked = True
                Return
            End If

        End If

        If CBool(_Codigo_Nodo) And Rdb_Es_Padre.Checked Then

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                           "Identificacdor_NodoPadre = " & _Codigo_Nodo)

            If Not CBool(_Reg) Then

                _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                               "Codigo_Nodo = " & _Codigo_Nodo)
                If CBool(_Reg) Then
                    MessageBoxEx.Show(Me, "Esta clasificación no puede ser Padre, ya que tiene productos asociados", "Validación",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Rdb_Es_Seleccionable.Checked = True
                    Return
                End If

            End If

        End If

        With _Cl_Arbol_Asociaciones.Zw_TblArbol_Asociaciones
            .Codigo_Madre = Txt_Codigo_Madre.Text
            .Descripcion = Txt_Descripcion.Text
            .Es_Seleccionable = Rdb_Es_Seleccionable.Checked
            .Es_Padre = Rdb_Es_Padre.Checked
            .Clas_Unica_X_Producto = _Clas_Unica_X_Producto
        End With

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_Arbol_Asociaciones.Fx_Grabar_Clasificacion

        MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Grabar = True
            Me.Close()
        End If

    End Sub

End Class
