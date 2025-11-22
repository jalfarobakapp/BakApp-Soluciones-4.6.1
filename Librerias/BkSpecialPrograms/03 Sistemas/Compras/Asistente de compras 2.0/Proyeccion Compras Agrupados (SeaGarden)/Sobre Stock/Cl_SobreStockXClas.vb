Public Class Cl_SobreStockXClas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property TablaPasoRotacion As String

    Public Sub New()

        TablaPasoRotacion = "TablaPasoRotacion_" & FUNCIONARIO

    End Sub

    ' Pseudocódigo (plan detallado):
    ' 1. Inicializar un objeto _Mensaje de tipo LsValiciones.Mensajes.
    ' 2. Construir la consulta SQL para crear la tabla temporal identificada por _TablaPasoRotacion.
    ' 3. Ejecutar la consulta usando _Sql.Ej_consulta_IDU(Consulta_sql).
    ' 4. Si la ejecución devuelve False:
    '    4.1. Lanzar una excepción con información clara (nombre de la tabla y la consulta SQL).
    ' 5. Capturar cualquier excepción en el bloque Catch:
    '    5.1. (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite.
    '    5.2. Volver a lanzar la excepción para que el llamador la maneje y preserve la pila.
    ' 6. Devolver _Mensaje si no se produce una excepción.
    Function Fx_CrearTablaPaso_TablaPasoRotacion() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Sb_Eliminar_TablaPasoRotacion()

        Try

            Consulta_sql = $"-- Crear la tabla con la estructura
CREATE TABLE {TablaPasoRotacion}(
    Codigo_Nodo VARCHAR(50),
    Codigo_Nodo_Madre VARCHAR(50),
    Producto VARCHAR(200),
    StockUd1 INT,
    StockEnTransitoUd1 INT,
    StockPedidoUd1 INT,
    StockDisponible INT,
    RotM1 FLOAT,
    RotM2 FLOAT,
    RotM3 FLOAT,
    RotM4 FLOAT,
    RotCalculo VARCHAR(10),
    Rotacion FLOAT,
    Duracion_Stock_Meses FLOAT,
    MesesSobreStock INT,
    Syncro Float,
    KilosXPallet Float,
    PalletSY Float,
    SobreStock VARCHAR(2)
);"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaPasoRotacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Crear tabla de paso: " & TablaPasoRotacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaPasoRotacion(Tbl_Asc_02_Asociaciones As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = $"-- Insertar los datos en la tabla recién creada
INSERT INTO {TablaPasoRotacion} (
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockDisponible,
    RotM1,
    RotM2,
    RotM3,
    RotM4,
    RotCalculo,
    Rotacion,
    Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
	KilosXPallet
)
SELECT  
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockUd1 + StockEnTransitoUd1 AS StockDisponible,
    RotMensualUd1 AS RotM1,
    Promedio_Mensual AS RotM2,
    Promedio_UltMesMasPromUlt3Mes AS RotM3,
    Promedio_3Mes AS RotM4,
    -- Nombre del campo que resultó mayor
    CASE 
        WHEN RotMensualUd1 >= Promedio_Mensual 
             AND RotMensualUd1 >= Promedio_UltMesMasPromUlt3Mes 
             AND RotMensualUd1 >= Promedio_3Mes 
        THEN 'RotM1'
        WHEN Promedio_Mensual >= RotMensualUd1 
             AND Promedio_Mensual >= Promedio_UltMesMasPromUlt3Mes 
             AND Promedio_Mensual >= Promedio_3Mes 
        THEN 'RotM2'
        WHEN Promedio_UltMesMasPromUlt3Mes >= RotMensualUd1 
             AND Promedio_UltMesMasPromUlt3Mes >= Promedio_Mensual 
             AND Promedio_UltMesMasPromUlt3Mes >= Promedio_3Mes 
        THEN 'RotM3'
        ELSE 'RotM4'
    END AS RotCalculo,
	    -- Valor máximo
    (SELECT MAX(v) 
     FROM (VALUES (RotMensualUd1), (Promedio_Mensual), 
                  (Promedio_UltMesMasPromUlt3Mes), (Promedio_3Mes)) AS value(v)
    ) AS Rotacion,
    Duracion_Stock AS Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
	600
FROM {Tbl_Asc_02_Asociaciones}
WHERE StockUd1 + StockEnTransitoUd1 > 0

Update {_TablaPasoRotacion} Set Syncro = (Duracion_Stock_Meses-MesesSobreStock)*Rotacion
Update {_TablaPasoRotacion} Set SobreStock = 'No' Where Duracion_Stock_Meses <= MesesSobreStock
Update {_TablaPasoRotacion} Set SobreStock = 'Si' Where Duracion_Stock_Meses > MesesSobreStock
Update {_TablaPasoRotacion} Set PalletSY = Round(Syncro/KilosXPallet,0)
"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", _TablaPasoRotacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & _TablaPasoRotacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Sub Sb_Eliminar_TablaPasoRotacion()
        Try
            Consulta_sql = "DROP TABLE " & TablaPasoRotacion
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Catch ex As Exception
        End Try
    End Sub

End Class
