Public Class Cl_PesoVariable

    Public Property probabilidad As Double
    Public Property kilosPasados As Double
    Public Sub New()

        'Dim totalCajas As Integer = 100
        'Dim diferenciaPeso As Integer = 6
        'Dim cajasSeleccionadas As Integer = 3

        'probabilidad = CalcularProbabilidad(totalCajas, diferenciaPeso, cajasSeleccionadas)
        'kilosPasados = CalcularKilosPasados(totalCajas, diferenciaPeso, cajasSeleccionadas)

        'Console.WriteLine($"La probabilidad es aproximadamente: {probabilidad:P}")
        'Console.WriteLine($"La cantidad de kilos pasados es aproximadamente: {kilosPasados} kilos")

    End Sub

    Function Fx_Cacular(totalCajas As Integer, diferenciaPeso As Integer, cajasSeleccionadas As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Fx_CalcularCombinaciones()

        Dim _Rtu As Double = Fx_CalcularRTUVariable(539.8, 25, 23.65)
        Dim _Rtu2 As Double = Fx_CalcularRTUVariable(1941, 92, 24.05)
        Dim _Rtu3 As Double = Fx_CalcularRTUVariable(5740.41, 270, 24.98)
        Dim _Rtu4 As Double = Fx_CalcularRTUVariable(654, 31, 24.05)

        probabilidad = CalcularProbabilidad(totalCajas, diferenciaPeso, cajasSeleccionadas)
        kilosPasados = CalcularKilosPasados(totalCajas, diferenciaPeso, cajasSeleccionadas)

        _Mensaje.EsCorrecto = True
        _Mensaje.Col2_Detalle = "Calculo realizado"
        _Mensaje.Col1_Mensaje = $"La probabilidad es aproximadamente: {probabilidad:P}" & vbCrLf &
                           $"La cantidad de kilos pasados es aproximadamente: {kilosPasados} kilos"
        _Mensaje.Icono = MessageBoxIcon.Information

        Return _Mensaje

    End Function

    Public Shared Function CalcularProbabilidad(totalCajas As Integer, diferenciaPeso As Integer, cajasSeleccionadas As Integer) As Double
        Dim combinacionesPosibles As Double = CalcularCombinaciones(totalCajas, cajasSeleccionadas)
        Dim combinacionesDiferenciaPeso As Double = CalcularCombinaciones(1, 1) * CalcularCombinaciones(1, 1) * CalcularCombinaciones(totalCajas - 2, cajasSeleccionadas - 2)

        Return combinacionesDiferenciaPeso / combinacionesPosibles
    End Function

    Public Shared Function CalcularKilosPasados(totalCajas As Integer, diferenciaPeso As Integer, cajasSeleccionadas As Integer) As Double
        Dim pesoPromedio As Double = totalCajas * (diferenciaPeso / 2)
        Dim kilosPasados As Double = cajasSeleccionadas * diferenciaPeso

        Return kilosPasados - pesoPromedio
    End Function

    Public Shared Function CalcularCombinaciones(n As Integer, k As Integer) As Double
        Dim numerador As Double = Factorial(n)
        Dim denominador As Double = Factorial(k) * Factorial(n - k)
        Return numerador / denominador
    End Function

    Public Shared Function Factorial(n As Integer) As Double
        If n = 0 Then
            Return 1
        Else
            Return n * Factorial(n - 1)
        End If
    End Function

    Function Fx_CalcularCombinaciones()

        ' Supongamos que los pesos de las cajas están en la lista "pesosCajas"
        Dim pesosCajas As New List(Of Double) From {22, 23, 20, 21.5, 22, 23.5, 20.1, 19.5, 18.9, 23,
                                                    24, 20, 21.6, 22, 22.3, 23, 25, 24, 23.0, 23.2,
                                                    24, 20, 21.6, 22, 22.3, 23, 25, 24, 23.0, 23.2,
                                                    22, 23, 20, 21.5, 22, 23.5, 20.1, 19.5, 18.9, 23,
                                                    23.3, 23.5, 23.6, 23.8, 24.0, 24.1, 24.3, 24.4,
                                                    24.6, 24.8, 24.9, 23.3, 23.5, 23.6, 23.8, 24.0,
                                                    24.1, 24.3, 24.4, 24.6, 24.8, 24.9, 19.5, 18.9, 23} ' Agrega los pesos reales aquí

        Dim pesoMaximo As Double = pesosCajas.Max()
        Dim pesoMinimo As Double = pesosCajas.Min()

        ' Calculamos la diferencia de peso
        Dim diferenciaPeso As Double = Math.Round(pesoMaximo - pesoMinimo, 2)
        Dim masmenos As Double = Math.Round(diferenciaPeso / 2, 2)

        ' Calculamos el promedio general
        Dim promedio As Double = Math.Round(pesosCajas.Average(), 2)

        ' Definimos el rango de ±3 kilos alrededor del promedio
        Dim rangoMin As Double = promedio - masmenos
        Dim rangoMax As Double = promedio + masmenos

        ' Contamos las combinaciones dentro y fuera del rango
        Dim combinacionesDentro As Integer = 0
        Dim combinacionesTotal As Integer = 0

        For i As Integer = 0 To pesosCajas.Count - 1
            For j As Integer = i + 1 To pesosCajas.Count - 1
                For k As Integer = j + 1 To pesosCajas.Count - 1
                    Dim sumaPesos As Double = pesosCajas(i) + pesosCajas(j) + pesosCajas(k)
                    If sumaPesos >= rangoMin AndAlso sumaPesos <= rangoMax Then
                        combinacionesDentro += 1
                    End If
                    combinacionesTotal += 1
                Next
            Next
        Next

        ' Cantidad de cajas a vender
        Dim cantidadCajas As Integer = 10

        ' Ordenamos la lista de pesos de forma descendente
        pesosCajas.Sort()


        ' Calculamos el peso total considerando las cajas más pesadas
        'Dim pesoTotal As Integer = 0
        Dim pesoTotal_Min As Integer = 0
        For i As Integer = 0 To cantidadCajas - 1
            pesoTotal_Min += pesosCajas(i)
        Next

        ' Calculamos el promedio de los pesos
        Dim Promedio_MasBajas = Math.Round(pesoTotal_Min / cantidadCajas, 0)

        pesosCajas.Reverse()

        ' Calculamos el peso total considerando las cajas más pesadas
        Dim pesoTotal_Mayor As Integer = 0
        For i As Integer = 0 To cantidadCajas - 1
            pesoTotal_Mayor += pesosCajas(i)
        Next

        ' Calculamos el promedio de los pesos
        Dim Promedio_MasAltas = Math.Round(pesoTotal_Mayor / cantidadCajas, 0)

        Dim Difmayor = Promedio_MasAltas - Promedio_MasBajas
        Dim DifPromedio = Promedio_MasAltas - promedio

        ' Calculamos las probabilidades
        Dim probabilidadDentro As Double = combinacionesDentro / combinacionesTotal
        Dim probabilidadFuera As Double = 1 - probabilidadDentro

    End Function



End Class
