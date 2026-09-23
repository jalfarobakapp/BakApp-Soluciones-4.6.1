Public Class DocumentoEncabezado

    Public Property Id_Enc As Integer
    Public Property Idmaeedo As Integer
    Public Property Empresa As String
    Public Property Tido As String
    Public Property Nudo As String
    Public Property Endo As String
    Public Property Suendo As String
    Public Property Nokoen As String
    Public Property Estado As String
    Public Property Procesar As Boolean
    Public Property Procesando As Boolean
    Public Property Procesada As Boolean

    ' Se utilizan corchetes [] porque "Error" es una palabra reservada en VB.NET
    Public Property [Error] As Boolean

    Public Property Observacion As String

    ' Se utiliza DateTime? (Nullable) porque en la tabla SQL tienen el check "Allow Nulls"
    Public Property FechaIngreso As DateTime?
    Public Property FechaProceso As DateTime?



    Public Sub New()
    End Sub

    ' Constructor a partir de un DataRow
    Public Sub New(row As DataRow)
        If row IsNot Nothing Then
            If Not IsDBNull(row("Id_Enc")) Then Me.Id_Enc = Convert.ToInt32(row("Id_Enc"))
            If Not IsDBNull(row("Idmaeedo")) Then Me.Idmaeedo = Convert.ToInt32(row("Idmaeedo"))
            If Not IsDBNull(row("Empresa")) Then Me.Empresa = row("Empresa").ToString()
            If Not IsDBNull(row("Tido")) Then Me.Tido = row("Tido").ToString()
            If Not IsDBNull(row("Nudo")) Then Me.Nudo = row("Nudo").ToString()
            If Not IsDBNull(row("Endo")) Then Me.Endo = row("Endo").ToString()
            If Not IsDBNull(row("Suendo")) Then Me.Suendo = row("Suendo").ToString()
            If Not IsDBNull(row("Nokoen")) Then Me.Nokoen = row("Nokoen").ToString()
            If Not IsDBNull(row("Estado")) Then Me.Estado = row("Estado").ToString()
            If Not IsDBNull(row("Procesar")) Then Me.Procesar = Convert.ToBoolean(row("Procesar"))
            If Not IsDBNull(row("Procesando")) Then Me.Procesando = Convert.ToBoolean(row("Procesando"))
            If Not IsDBNull(row("Procesada")) Then Me.Procesada = Convert.ToBoolean(row("Procesada"))
            If Not IsDBNull(row("Error")) Then Me.[Error] = Convert.ToBoolean(row("Error"))
            If Not IsDBNull(row("Observacion")) Then Me.Observacion = row("Observacion").ToString()

            ' Mapeo de campos Fecha que permiten Nulos (Nullable)
            If Not IsDBNull(row("FechaIngreso")) Then Me.FechaIngreso = Convert.ToDateTime(row("FechaIngreso")) Else Me.FechaIngreso = Nothing
            If Not IsDBNull(row("FechaProceso")) Then Me.FechaProceso = Convert.ToDateTime(row("FechaProceso")) Else Me.FechaProceso = Nothing
        End If
    End Sub
End Class
