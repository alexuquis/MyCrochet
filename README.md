# MyCrochet

Planner de escritorio **stand-alone (offline)** para una artesana independiente:
gestiona el inventario de estambres e hilos, la agenda de pedidos personalizados
(amigurumis) y el cálculo de costos de producción.

## Estructura del repositorio

| Ruta | Descripción |
| --- | --- |
| `MyCrochet/` | Aplicación original en **WinForms** (.NET 8 + SQL Server). Se conserva como referencia. |
| `MyCrochetWpf/` | Versión en migración: **WPF + MVVM (CommunityToolkit.Mvvm) + SQLite**. |
| `MyCrochet.sln` | Solución con los dos proyectos. |

## Requisitos

- .NET 8 SDK.
- Windows (ambos proyectos apuntan a `net8.0-windows`). El proyecto WPF incluye
  `EnableWindowsTargeting=true`, por lo que puede compilarse también desde Linux/WSL.
- SQL Server (`SQLEXPRESS`, base `CrochetDB`) para ejecutar la versión WinForms.

## Compilar

```bash
dotnet build MyCrochet.sln
```

La versión WPF crea automáticamente la base `mycrochet.db` (SQLite) junto al
ejecutable en el primer arranque.

## Estado del proyecto

La migración está documentada por etapas en `MyCrochet/FASE_A.md`,
`MyCrochet/FASE_B.md` y `MyCrochet/FASE_C.md`.
