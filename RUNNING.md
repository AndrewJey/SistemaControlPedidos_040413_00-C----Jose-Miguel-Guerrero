

<!-- local-development:start -->
# Desarrollo local

Puedes abrir este repositorio en VS Code, Antigravity o Sublime Text. El compilador y los servicios necesarios dependen del componente indicado abajo.

## Visual Studio 2022 / .NET Framework

Instala la carga de trabajo de escritorio .NET y el paquete de destino indicado en la tabla. Los proyectos ASP.NET también requieren la carga web e IIS Express. Abre la solución `.sln` correspondiente y selecciona el proyecto de aplicación para iniciar.

```powershell
# Ejecutar desde Developer PowerShell de Visual Studio 2022
$solutionDir = (Resolve-Path '.').Path + '\'
MSBuild.exe 'Sistema Control Pedidos/Sistema Control Pedidos.vbproj' /restore /p:RestorePackagesConfig=true /p:Configuration=Debug /p:DeployOnBuild=false "/p:SolutionDir=$solutionDir"
```

## Componentes y validación

Inventario y compilaciones locales del 2026-11-15. Una compilación correcta no acredita todavía interacción, compatibilidad de base de datos, instalador ni despliegue.

| Componente | Tipo / destino | Validación |
| --- | --- | --- |
| [Sistema Control Pedidos.sln](<Sistema Control Pedidos.sln>) | solution | Sin ejecutar |
| [Sistema Control Pedidos/Sistema Control Pedidos.vbproj](<Sistema Control Pedidos/Sistema Control Pedidos.vbproj>) | dotnet / v4.8.1 | Compila; comprobado el 2026-11-15; ver alcance actualizado abajo |

## Archivos ignorados

`.gitignore` excluye credenciales locales, estado del editor y salidas de las herramientas detectadas. No deja de versionar archivos que ya estaban en Git. Los manifiestos, archivos de bloqueo, recursos fuente y scripts de esquema forman parte del código.
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

<!-- improvements-20261119:start -->
## Mejoras y verificación — 2026-11-19 (Cadena ODBC configurable y mejoras de impresión local)

- Añadida `Base_de_Datos.ObtenerCadenaConexion()` con soporte para `SCP_ODBC_CONNECTION_STRING` manteniendo `DSN=SCPBD` por defecto.
- Reforzado `ImpresionLocal` ante encabezados o tablas vacías (`Nothing`/0 filas) y añadido `CalcularTotalColumna` para totales numéricos seguros.
- Validación: compilación MSBuild VB.NET y 6 aserciones de generación de comprobantes Unicode, tablas vacías, totales y configuración ODBC.
<!-- improvements-20261119:end -->
