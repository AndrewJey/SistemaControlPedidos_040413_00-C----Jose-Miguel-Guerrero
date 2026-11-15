# SistemaControlPedidos_040413_00-C----Jose-Miguel-Guerrero

<!-- local-development:start -->
## Desarrollo local

Consulta [RUNNING.md](RUNNING.md) para ubicar cada componente, abrirlo en su IDE, compilarlo y conocer las comprobaciones realizadas y los requisitos pendientes.
<!-- local-development:end -->

<!-- build-repairs-20261115:start -->
## Reparación y comprobación — 2026-11-15

- Se añadieron comprobantes con System.Drawing/PrintDocument y vista previa de Windows, con encabezados y detalle consultado mediante parámetros ODBC.
- Las plantillas originales de Crystal Reports se conservan. Sus referencias y clases generadas son opcionales mediante EnableLegacyCrystalReports; la compilación normal usa el nuevo módulo.

Comprobado:

- Compila con .NET Framework 4.8.1.
- La prueba de CrearLineas conservó encabezado, importe y detalle Unicode. No se enviaron trabajos a una impresora.

Comandos:

```powershell
msbuild 'Sistema Control Pedidos.sln' /t:Build
```

Alcance pendiente:

- El formato visual de los comprobantes cambia respecto a los RPT originales. Se necesita configurar la conexión ODBC y la base histórica para comprobar facturación, pedidos e impresión con datos reales.

<!-- build-repairs-20261115:end -->
