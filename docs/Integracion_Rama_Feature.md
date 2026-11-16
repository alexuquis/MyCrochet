# Documentación de integración — Filtro por rango de fechas en Pedidos

Entrega de avances: repositorio en GitHub con flujo de ramas y pull request de integración.

## 1. Repositorio

- **URL:** https://github.com/alexuquis/MyCrochet
- **Visibilidad:** privada
- **Rama principal:** `main`
- **Rama de funcionalidad:** `feature/filtros-fecha-pedidos`

## 2. Estrategia de ramas

| Rama | Propósito | Contenido |
| --- | --- | --- |
| `main` | Versión estable del proyecto | Solución completa (WinForms de referencia + migración WPF/MVVM/SQLite) tal como estaba antes del avance |
| `feature/filtros-fecha-pedidos` | Funcionalidad nueva desarrollada para esta entrega | Filtro por rango de fechas de entrega y botón "Limpiar filtros" en la vista Pedidos |

El flujo seguido es **feature branch**: la funcionalidad se desarrolla aislada en
`feature/filtros-fecha-pedidos`, se prueba y luego se integra a `main` mediante un
Pull Request (no se hace push directo a la rama principal).

## 3. Funcionalidad desarrollada

La vista **Pedidos** ya permitía filtrar por texto (cliente o Id), tipo de pedido y
estado. El avance agrega un **filtro por rango de fechas de entrega**, útil para
planificar la agenda semanal de encargos:

- Campo **"Entrega desde"**: muestra solo pedidos con fecha de entrega igual o posterior.
- Campo **"Entrega hasta"**: muestra solo pedidos con fecha de entrega igual o anterior.
- El filtrado es **en vivo**: cada cambio de fecha refresca el grid automáticamente
  (mismo patrón `partial void On...Changed` que ya usaban los demás filtros).
- Si se eligen las fechas al revés (`desde > hasta`), el ViewModel las **normaliza**
  en lugar de mostrar un grid vacío.
- Botón **"Limpiar filtros"**: restablece texto, tipo, estado y rango de fechas de
  una sola vez.
- El rango vacío (sin fechas) se interpreta como "sin límite", por lo que el
  comportamiento previo de la pantalla no cambia.

### Archivos modificados

| Archivo | Cambio |
| --- | --- |
| `MyCrochetWpf/Data/RepositorioEncargos.cs` | `Listar()` acepta `desde`/`hasta` opcionales; la consulta SQL filtra con `date(e.FechaEntrega)` entre ambos extremos |
| `MyCrochetWpf/ViewModels/PedidosViewModel.cs` | Nuevas propiedades observables `FechaDesde`/`FechaHasta`, normalización del rango y `LimpiarFiltrosCommand` |
| `MyCrochetWpf/Views/PedidosWindow.xaml` | Dos `DatePicker`, botón "Limpiar filtros" y reubicación del grid para dar espacio a la nueva fila |

### Decisiones de diseño

- **Filtrado en SQL, no en memoria:** el repositorio compone el `WHERE` con
  parámetros (`@desde`, `@hasta`), manteniendo el patrón existente y evitando
  cargar toda la tabla para descartar filas en C#.
- **Compatibilidad:** los parámetros son opcionales (`null` = sin filtro), así que
  las llamadas existentes a `Listar()` siguen funcionando sin cambios.
- **UI:** se mantiene la paleta y tipografías del proyecto; el grid se desplazó
  36 px hacia abajo para acomodar la nueva fila sin recortar el panel principal.

## 4. Cómo probar

1. Compilar la solución: `dotnet build MyCrochet.sln`
2. Ejecutar `MyCrochetWpf` e iniciar sesión.
3. Ir a **Pedidos** y verificar que el grid muestra todos los pedidos.
4. Elegir **"Entrega desde"** y **"Entrega hasta"** con un rango que contenga
   algunas fechas: el grid debe mostrar solo los pedidos dentro del rango.
5. Invertir las fechas (desde posterior a hasta): el grid debe mostrar el mismo
   resultado que el rango normalizado (no queda vacío).
6. Pulsar **"Limpiar filtros"**: todos los filtros vuelven a "Todos"/vacío y el
   grid se recarga completo.
7. Repetir combinando el rango de fechas con texto, tipo y estado.

## 5. Pull request de integración

- **PR:** `feature/filtros-fecha-pedidos` → `main`
- El PR incluye la descripción del cambio, los archivos modificados y los pasos
  de prueba de esta sección; la revisión y el merge quedan registrados como
  evidencia de la integración.
