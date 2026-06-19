Shopify2Bakapp
Descripción del Proyecto
Shopify2Bakapp es un servicio en segundo plano (daemon) diseñado para integrarse de manera fluida con el ecosistema de BakApp. Su propósito principal es automatizar el flujo de información comercial mediante la extracción de ventas y pedidos realizados a través de la plataforma web de Shopify, para luego insertarlos y consolidarlos en la base de datos interna de la empresa.

Este servicio está diseñado para ejecutarse de forma continua, despertando cada cierto intervalo de tiempo  para consultar nuevos registros, garantizando que el sistema interno de BakApp  registro de ventas sincronizado casi en tiempo real.

Características Principales
Ejecución Programada (Daemon): Funciona como un proceso en segundo plano que se ejecuta automáticamente en intervalos de tiempo definidos (X minutos/horas) sin requerir intervención manual.

Prevención de Duplicados: Implementa mecanismos de validación para asegurar que una venta procesada no vuelva a ser ingresada en ciclos posteriores.

Trazabilidad y Logs: Mantiene un registro detallado de las operaciones exitosas, advertencias y errores técnicos para facilitar la auditoría y depuración del sistema
