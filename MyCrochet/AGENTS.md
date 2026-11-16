# AGENTS.md — MyCrochet

## Purpose

"MyCrochet" es un planner de escritorio **stand-alone (offline)** para una artesana
independiente: gestiona inventario de estambres/hilos, agenda pedidos personalizados
(amigurumis) y calcula costos de producción. Sin web, sin APIs, sin dependencias de red.

Actual: **WinForms sobre .NET 8** (`net8.0-windows`, `UseWindowsForms`), BD **SQL Server**
vía `System.Data.SqlClient`. Plan aprobado con la dueña: migrar a
**WPF + MVVM (CommunityToolkit.Mvvm) + SQLite (`Microsoft.Data.Sqlite`)** en una
subcarpeta nueva (`../MyCrochetWpf/`, hermana del proyecto WinForms), dejando el proyecto
WinForms intacto como referencia.

---

## Permanente — reglas que todo agente debe respetar (no ejecutar, solo obedecer)

### Proyecto original (WinForms) — lectura, no escritura
- Está **intocado como referencia**. Prohibido refactorizarlo.
- Punto de entrada: `Program.cs` → `Application.Run(new FmPedidos())` — **atajo de
  desarrollo**; el flujo real es `Form1` (clase `Login`) → `FmInicio`.
- `ConexGlobal.cs` tiene `cadena` (hardcode a `DESKTOP-HAPVSMC\SQLEXPRESS` / `CrochetDB`)
  y los valores de sesión estáticos: `RolUsuarioAct: int`, `NombreUsuarioAct: string`,
  `GeneroUsuarioAct: string`. Solo el Login los llena.
- Contraseñas en texto plano (así es; no "mejorarlo" sin consulta).
- Varias clases están en archivos no emparejados por nombre (p. ej. `Form1.cs`
  contiene la clase `Login`); buscar la clase real antes de editar.
- Sources con acentos/`ñ` y posible mojibake (encoding mixto): copiar el texto
  exactamente como está, no "corregirlo" a mano.

### Base de datos (SQL Server, actual) — migrar a SQLite
- No hay script SQL del esquema en el repo: **inferir tablas desde las queries**.
- Tablas: `Usuarios`, `Generos`, `Roles`, `Articulos`, `Categorias`, `Encargos`,
  `TipoPedidos`, `Estados`, `OpcionesEnvio`.
  `Articulos` incluye una columna `Modelo BLOB` que ninguna query usa, pero existe
  en CrochetDB: se conserva por fidelidad.
- Reglas de migración SQL: conservar la **lógica exacta**; usar parámetros `@nombre`;
  `TOP`→`LIMIT`, `GETDATE()`→`date('now')` (no proceden en la DB actual, no aplicar).
- Concatenación de strings: `+` de SQL Server → `||` en SQLite
  (caso real: `FmCotizador.cs`, `A.Marca + ' - ' + A.Tamaño`).
- Fechas: almacenar como `TEXT` en ISO 8601 (`yyyy-MM-dd HH:mm:ss`).
- Decisiones cerradas (2026-11-06): conservar columnas con `ñ` (`Contraseña`,
  `Tamaño`); FKs activas con `PRAGMA foreign_keys=ON`; repositorios devuelven
  **entidades tipadas** (no `DataTable`); seed mínimo al crear la BD (catálogos +
  un usuario admin `admin`/`admin`, a cambiar desde Configuración).
- `SqlDataAdapter`/`SqlCommandBuilder` (en `FmUsuarios.cs`) no existe en
  `Microsoft.Data.Sqlite` → CRUD manual parametrizado.
- Nombres de columna con `ñ` (`Contraseña`, `Tamaño`): SQLite los acepta, pero si
  alguna herramienta/API de SQL falla, escapar con `[Tamaño]` / `"Tamaño"`.
- SQLite crea `mycrochet.db` automáticamente al primer arranque.

### UI / identidad visual
- Paleta corporativa: fondo blanco hueso `#FFF7F8`, detalles rosa `#FEA9BE`,
  acentos tinto `#861940`. En WPF va en un `ResourceDictionary`, no en code-behind.
- Recursos propios (copiar, nunca mover): imágenes en `RecursosMyCrochet/`,
  GIFs en `AnimacionesFinal/` (Animal, Estambre1, Estambre2, Flor, Gancho, Ojo,
  Personaje, fondologin), fuentes en `fuentes/` (ADELIA, Comfortaa Bold/Regular,
  "Good Bakwan") y raíz (KGPerfectPenmanship, KGRedHands, Super Mindset).
  **No introducir iconos/fuentes genéricos.**

### Build
- Runtime solo **Windows**.
- Construir sobre la solución hermana (una carpeta arriba de este `MyCrochet/`):
  `dotnet build MyCrochet.sln`.
- Desde WSL se puede usar el SDK de Windows si está instalado:
  `"/mnt/c/Program Files/dotnet/dotnet.exe" build MyCrochet.sln`. El proyecto
  `MyCrochetWpf` lleva `EnableWindowsTargeting=true` para permitirlo.

---

## Roadmap de migración (marcar [x] al completar cada paso)

### Etapa A — Esqueleto y recursos
- [x] **A1.** Crear `MyCrochetWpf/` + agregar a sln + csproj + App + ventana demo.
      Hecho: build `0 errores` y `MyCrochetWpf.exe` generado. Ver `FASE_A.md`.
- [x] **A2.** Recursos corporativos: paleta en ResourceDictionary, fuentes, assets
      e imágenes. Hecho: build 0 errores + smoke test OK. GIFs empaquetados como
      estáticos; animación se decide en Fase C antes del Login. Ver `FASE_A.md`.

### Etapa B — Capa de datos ✅ (detalle en FASE_B.md)
- [x] **B1.** Infra SQLite: `MyCrochetWpf/Data/Db.cs` (factory de conexión,
      `PRAGMA foreign_keys=ON`, `EnsureDatabase()` que crea `mycrochet.db` junto al
      ejecutable). Hecho: build 0 errores + archivo creado al arrancar.
- [x] **B2.** Esquema SQLite + seed mínimo. Hecho: 9 tablas creadas con
      restricciones reales (incluida `Articulos.Modelo BLOB`, no usada por las
      pantallas), catálogos reales de CrochetDB y usuario `admin`/`admin`.
      Ver `FASE_B.md`. Idempotente verificado.
- [x] **B3.** Entidades tipadas en `MyCrochetWpf/Models/` (9 clases, sin SQL).
      Los catálogos usan la propiedad `Nombre`; el repositorio mapea las columnas
      reales `Genero` / `Rol` / `Categoria` / `Estado`.
- [x] **B4.** Repositorio Usuarios (`Data/RepositorioUsuarios.cs`): login, listar,
      insertar, actualizar por Id, verificar credencial, actualizar perfil por
      nombre y eliminar. CRUD manual reemplaza `SqlDataAdapter`. SQL validado.
- [x] **B5.** Repositorio Catálogos (`Data/RepositorioCatalogos.cs`): 5 SELECTs
      tipados (Géneros, Roles, TipoPedidos, Estados, OpcionesEnvío). SQL validado.
- [x] **B6.** Repositorio Artículos + Categorías (`Data/RepositorioArticulos.cs`):
      listar con JOIN/filtros, insertar, obtener por Id, actualizar, eliminar,
      consulta del cotizador (`+`→`||`) y alertas de stock bajo. SQL validado.
- [x] **B7.** Repositorio Encargos (`Data/RepositorioEncargos.cs`): listar con
      filtros, insertar, detalle con JOIN, obtener por Id, actualizar, eliminar y
      pendientes de FmInicio. SQL validado con `||` y `CAST(... AS TEXT)`.

### Etapa C — Pantallas (1 paso = 1 ViewModel + 1 View + su repositorio ya listo)
- [x] C1. Login (`Form1.cs` → clase `Login`). Hecho: `LoginWindow` +
      `LoginViewModel` + `SesionService` mínimo, arranque en Login; build 0 errores
      y 17/17 pruebas de autenticación OK. Ver `FASE_C.md`.
- [x] C2. FmInicio (dividido: a) ViewModel de datos, b) ventana + Login→Inicio, c) sesión/refresco)
      - [x] C2a. `ViewModels/InicioViewModel.cs`: saludo desde `SesionService`, pedidos
            pendientes, fechas del calendario y alertas de stock con los repositorios de
            B6/B7. Hecho: build 0 errores.
      - [ ] C2b. `Views/InicioWindow.xaml(.cs)` + navegación Login → Inicio
            (dividido: b1) ventana con layout, b2) Login → Inicio).
            - [x] C2b-1. `Views/InicioWindow.xaml(.cs)` con el layout de FmInicio
                  (barra superior, menú lateral, saludo, calendario, tabla de
                  pendientes y alertas de inventario), datos del C2a y colores
                  nuevos `FondoSuave`/`FondoAlterno`. Hecho: build 0 errores +
                  render de verificación (`inicio_smoke.png`). Ver `FASE_C.md`.
            - [x] C2b-2. Navegación Login → Inicio + smoke test.
      - [x] C2c. Cerrar sesión, refresco al reactivar y smoke test
            (dividido: c1) cerrar sesión, c2) refresco + smoke).
            - [x] C2c-1. Botón "Cerrar Sesión" con confirmación Yes/No
                  (`MessageBox` con el texto del WinForms), `SesionService.Cerrar()`
                  y Login nuevo. Hecho: build 0 errores. Ver `FASE_C.md`.
            - [x] C2c-2. Refresco al reactivar (`IsVisibleChanged` → `Cargar()`) +
                  smoke test de cerrar sesión y refresco. Hecho: build 0 errores,
                  6/6 aserciones y evidencia `cerrar_sesion_smoke.png` /
                  `refresco_smoke.png`. Ver `FASE_C.md`.
- [x] C3. FmPedidos (dividido: 1) ViewModel, 2) ventana, 3) navegación + smoke)
      - [x] C3-1. `ViewModels/PedidosViewModel.cs` (dividido: 1a) datos/filtros, 1b) comandos + prueba)
            - [x] C3-1a. Datos y filtros en vivo: `Pedidos`, combos `Tipos`/`Estados`
                  con "Todos" (Id 0) y `FiltroTexto`/`TipoIdSeleccionado`/
                  `EstadoIdSeleccionado` que recargan al cambiar. Hecho: build
                  0 errores. Ver `FASE_C.md`.
            - [x] C3-1b. Comandos (Nuevo/Ver/Modificar/Eliminar), rol para eliminar,
                  eventos de navegación y prueba funcional del VM.
                  Hecho: build 0 errores + prueba con harness temporal
                  (`--test-pedidos-vm`, filtros, eliminación y rol; harness retiro).
                  Ver sección C3-1b en `FASE_C.md`.
      - [x] C3-2. `Views/PedidosWindow.xaml(.cs)` con tipografía del WinForms
            (Super Mindset / KG Red Hands) + render de verificación
            (dividido: 2a) ventana, 2b) render).
            - [x] C3-2a. Ventana 1100x700 (Viewbox + Canvas), barra, lateral con
                  logo/menú, título, filtros, Nuevo Pedido y DataGrid con
                  ContextMenu estilizado; wiring del VM y eventos. Hecho: build
                  0 errores. Ver `FASE_C.md`.
            - [x] C3-2b. Render de verificación `pedidos_smoke.png` + ajustes.
      - [x] C3-3. Navegación Inicio ↔ Pedidos, cerrar sesión y smoke test.
            Hecho: `Hide()`/`Show()` reutilizando instancias (como
            `Application.OpenForms`), `NavegacionSesion.VolverAlLogin()` cierra
            también las ventanas ocultas, build 0 errores, 20/20 aserciones y
            evidencia `nav_pedidos_smoke.png` / `nav_inicio_smoke.png`.
            Ver sección C3-3 en `FASE_C.md`.
- [x] C4. FmNuevoPedido (dividido: 1) ViewModel, 2) ventana, 3) navegación + smoke)
      - [x] C4-1. `ViewModels/NuevoPedidoViewModel.cs` (dividido: 1a) VM, 1b) prueba)
            - [x] C4-1a. Catálogos sin "Todos", campos de captura, `Total` en vivo
                  `(Subtotal + Envío) − Anticipo`, comandos `Guardar`/`Cerrar`,
                  validación ampliada, GIF por tipo y `Limpiar()` tras guardar.
                  Hecho: build 0 errores. Ver `FASE_C.md`.
            - [x] C4-1b. Prueba funcional con harness temporal
                  (`--test-nuevo-pedido-vm`): 23/23 aserciones, INSERT verificado
                  y BD limpia; harness retirado. Ver `FASE_C.md`.
      - [x] C4-2. `Views/NuevoPedidoWindow.xaml(.cs)` + wiring + render
            (dividido: 2a) ventana, 2b) render de verificación).
            - [x] C4-2a. `Views/NuevoPedidoWindow.xaml(.cs)`: ventana 597x471 sin
                  bordes, layout del Designer, campos y combos con la paleta,
                  DatePicker con calendario corporativo, GIF del tipo con
                  WpfAnimatedGif, total en vivo y wiring de mensajes/cierre.
                  Hecho: build 0 errores + verificación temporal de carga
                  (DatePicker y catálogos 3/4/4; harness retirado).
                  Ver sección C4-2a en `FASE_C.md`.
            - [x] C4-2b. Render de verificación `nuevo_pedido_smoke.png` + ajustes.
                  Hecho: 410.00 con Amigurumi y GIF visible; sin ajustes
                  adicionales; harness retirado. Ver sección C4-2b en `FASE_C.md`.
      - [x] C4-3. Abrir el modal desde Pedidos (`ShowDialog` + `Filtrar()`) +
            smoke test de flujo completo. Hecho: `AbrirNuevoPedido` con
            `ShowDialog` + `Filtrar()` (reaplica el filtro vigente), 12/12
            aserciones y evidencia `pedidos_flujo_smoke.png`. Ver `FASE_C.md`.
- [x] C5. FmVerPedido (dividido: 1) ViewModel, 2) ventana, 3) navegación + smoke)
      - [x] C5-1. `ViewModels/VerPedidoViewModel.cs` (dividido: 1a) VM, 1b) prueba)
            - [x] C5-1a. Detalle de solo lectura por Id con `ObtenerDetalle`; montos
                  `"$#,##0.00"` fijo, fecha `dd/MM/yyyy`, nulos `$0.00` /
                  "No especificado"; detalle inexistente o error de BD → mensaje
                  y cierre (decisiones C5). Hecho: build 0 errores.
            - [x] C5-1b. Prueba funcional con harness temporal
                  (`--test-ver-pedido-vm`): 22/22 aserciones (datos completos,
                  nulos e Id inexistente) y BD limpia; harness retirado.
                  Ver `FASE_C.md`.
      - [x] C5-2. `Views/VerPedidoWindow.xaml(.cs)` + wiring + render
            (dividido: 2a) ventana, 2b) render de verificación).
            - [x] C5-2a. `Views/VerPedidoWindow.xaml(.cs)`: ventana 410x510 sin
                  bordes con el layout del Designer, campos de solo lectura blancos
                  sin borde, título "Ver Pedido", X de cierre y arrastre de la
                  barra; wiring del VM (`Error de Lectura` + cierre) y `Cargar()`
                  al mostrarse. Hecho: build 0 errores + verificación temporal
                  30/30 (10 campos enlazados; harness retirado). Ver `FASE_C.md`.
            - [x] C5-2b. Render de verificación `ver_pedido_smoke.png` + ajustes.
                  Hecho: 410x510 con María López, Amigurumi, opción de envío y
                  total `$1,234.50`; sin ajustes de layout; harness retirado.
                  Ver `FASE_C.md`.
      - [x] C5-3. Abrir desde el menú contextual de Pedidos (`ShowDialog`) +
            smoke de flujo completo. Hecho: `AbrirVerPedido` con `Owner` +
            `ShowDialog` (sin recargar el grid), 24/24 aserciones y evidencia
            `ver_pedido_flujo_smoke.png`. Ver `FASE_C.md`.
- [ ] C6. FmEditarPedido (dividido: 1) ViewModel, 2) ventana, 3) navegación + smoke)
      - [x] C6-1. `ViewModels/EditarPedidoViewModel.cs` (dividido: 1a) VM, 1b) prueba)
            - [x] C6-1a. Catálogos sin "Todos", carga por Id con `ObtenerPorId`,
                  campos editables, total en vivo con el costo de envío tecleado
                  (decisión C6), validación de C4-1a, `Guardar` con `Actualizar` y
                  bloqueo por rol (Descripción/Fecha siempre habilitadas).
                  Hecho: build 0 errores. Ver `FASE_C.md`.
            - [x] C6-1b. Prueba funcional con harness temporal
                  (`--test-editar-pedido-vm`). Hecho: 58/58 aserciones (carga,
                  total en vivo, validaciones, UPDATE, rol e Id inexistente) y BD
                  limpia; harness retirado. Ver `FASE_C.md`.
      - [ ] C6-2. `Views/EditarPedidoWindow.xaml(.cs)` + wiring + render
            (dividido: 2a) ventana, 2b) render de verificación).
      - [ ] C6-3. Abrir desde el menú contextual de Pedidos (`ShowDialog` +
            `Filtrar()`) + smoke de flujo completo.
- [ ] C7. FmInventario
- [ ] C8. FmNuevoMaterial
- [ ] C9. FmEditarMaterial
- [ ] C10. FmCotizador
- [ ] C11. FmUsuarios
- [ ] C12. FmNuevoUs
- [ ] C13. FmConfiguracion

### Etapa D — Sesión y navegación
- [ ] D1. `SesionService` (reemplaza los estáticos de `ConexGlobal`).
- [ ] D2. Navegación Login → FmInicio + flujo entre ventanas.

### Etapa E — Cierre
- [ ] E1. Checklist de paridad pantalla por pantalla contra WinForms.
- [ ] E2. Build final + limpieza + actualizar este roadmap.

---

## Anti-saturación — reglas de trabajo por sesión
- **1 paso del roadmap = 1 sesión del agente.** No "avanzar" pasos siguientes
  aunque quede contexto; cerrar la sesión y retomar en una nueva.
- Al terminar un paso: **solo marcar su casilla**, no reescribir este archivo.
- Prohibido refactorizar el proyecto WinForms original.
- Los `.Designer.cs` solo se leen para replicar layout/controles, nunca de corrido.
- Si un paso se descubre más grande de lo previsto, dividirlo y anotar el subpaso
  en este roadmap antes de continuar.

---

## Estructura del repositorio

```
MyCrochet/                  (repositorio)
├── MyCrochet.sln           (solución con los 2 proyectos)
├── MyCrochet/              (WinForms original, referencia — solo lectura)
└── MyCrochetWpf/           (WPF + MVVM + SQLite — proyecto de la migración)
    ├── MyCrochetWpf.csproj
    ├── App.xaml / App.xaml.cs
    ├── MainWindow.xaml / MainWindow.xaml.cs   (demo de A2, se reemplaza en Fase C)
    ├── AssemblyInfo.cs
    ├── Data/            (Db.cs, Schema.cs, RepositorioUsuarios.cs,
    │                     RepositorioCatalogos.cs, próximos repositorios)
    ├── Models/          (9 entidades + UsuarioSesion y proyecciones:
    │                     ArticuloInventario, MaterialCotizacion, ArticuloStockBajo,
    │                     PedidoResumen, EncargoDetalle, PedidoPendiente)
    ├── Assets/          (PNG copiados de RecursosMyCrochet)
    ├── Assets/Gifs/     (GIFs de AnimacionesFinal + fondologin.gif)
    ├── Fonts/           (ADELIA, Comfortaa, Good Bakwan, KG…, Super Mindset)
    └── Themes/          (Colores.xaml, Fuentes.xaml)
```
