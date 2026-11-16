# FASE_C.md — Pantallas

Detalle de ejecución de la Etapa C. Un paso = una sesión de agente.

---

## Decisiones previas (referidas como "C0" en los comentarios del código)

- En el Login el `fondologin.gif` se usa **estático**; la animación de GIFs se
  decidirá al migrar las pantallas que la necesitan (C4/C8). Por eso el paquete
  `WpfAnimatedGif 2.0.2` queda referenciado en el csproj pero sin uso todavía.
- Los PNG propios del Login (`panel_login`, `logo_login`, `campo_usuario`,
  `campo_contrasena`, `boton_entrar`, `icono_minimizar`, `icono_cerrar`) se
  extrajeron de `Form1.resx` y se **copiaron** a `MyCrochetWpf/Assets/Login/`.
  Los recursos originales del WinForms quedaron intactos.
- No se introdujeron iconos ni fuentes genéricos: se usan los recursos propios
  ya empaquetados (Comfortaa, Good Bakwan, KGRedHands, paleta corporativa).

---

## Paso C1 — Login  ✅ COMPLETADO (2026-11-06)

**Objetivo**: migrar `Form1.cs` (clase `Login`) a WPF + MVVM, autenticando contra
`Usuarios` y llenando la sesión.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/LoginWindow.xaml` | Ventana 546×489 sin bordes, barra rosa superior, fondo `fondologin.gif` estático, tarjeta/logo/campos con imágenes propias, etiqueta de error oculta, botón "Iniciar Sesión" como `IsDefault` |
| `Views/LoginWindow.xaml.cs` | DataContext, foco inicial en usuario, `PasswordChanged` → ViewModel, limpieza del `PasswordBox`, arrastre desde la barra (excluyendo botones), minimizar con fundido 150 ms, cerrar → `Shutdown()` |
| `ViewModels/LoginViewModel.cs` | Propiedades `Usuario`, `Contrasena`, `MensajeError`, `HayError`; comando `Entrar`; validación de campos vacíos; eventos `LoginExitoso` y `SolicitaLimpiarPassword` |
| `Services/SesionService.cs` | Singleton mínimo que reemplaza `ConexGlobal`: `Nombre`, `RolId`, `Genero`, `Autenticado`, `Iniciar()` y `Cerrar()` |
| `App.xaml.cs` | El arranque abre `LoginWindow` (flujo real `Form1` → `FmInicio`); se eliminó `MainWindow.xaml` (demo de A2) |
| `Data/RepositorioUsuarios.cs` | Se consume `Autenticar()` (ya existente desde B4) |

### Paridad con el WinForms

| Aspecto | WinForms (`Form1.cs`) | WPF (C1) |
|---|---|---|
| SQL | `SELECT U.Nombre, U.RolesId, G.Genero FROM Usuarios U INNER JOIN Generos G ... WHERE Nombre / Contraseña` | La misma query, parametrizada (`@nombre`, `@contrasena`) |
| Credencial inválida | `label3.Visible = true`, limpia usuario y contraseña | Mismo mensaje "Usuario o contraseña incorrectos", limpia ambos campos y el `PasswordBox` |
| Credencial válida | Llena `ConexGlobal`, oculta Login y abre `FmInicio` | Llena `SesionService` y dispara `LoginExitoso`; la navegación queda para C2 |
| Minimizar | Bucle de opacidad y `WindowState = Minimized`, opacidad restaurada | `DoubleAnimation` 150 ms con el mismo efecto |
| Cerrar | `Application.Exit()` | `Application.Current.Shutdown()` |
| Arrastre | `ReleaseCapture` + `SendMessage` | `DragMove()` desde la barra rosa |

Diferencias deliberadas (no afectan el SQL):
- Se valida que usuario y contraseña no estén vacíos antes de consultar (mejor UX;
  el WinForms hacía la consulta y fallaba).
- Un error de conexión muestra un mensaje en pantalla en lugar de una excepción.
- Al autenticar se muestra un `MessageBox` de bienvenida **provisional**;
  `TODO(C2)` lo reemplazará por la apertura de `FmInicio`.
- No se replicó el mojibake `Contrase�a` del source original: la columna se usa
  como `Contraseña`, igual que en B4.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] Login validado contra la BD real: `admin`/`admin` devuelve
      `Nombre=admin`, `RolId=1`, `Genero=Femenino`; contraseña incorrecta no
      devuelve filas.
- [x] Prueba funcional del ViewModel (harness temporal, ya eliminado) → **17/17**:
      éxito dispara `LoginExitoso` y llena `SesionService`; credencial inválida
      muestra el mensaje exacto, limpia campos y pide limpiar el `PasswordBox`;
      campos vacíos muestran su propio mensaje; la sesión no se abre si falla.
- [x] Smoke test visual: `login_smoke.png` muestra la ventana renderizada con la
      identidad visual (fondo, logo, campos, botón, barra rosa).
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C2**: reemplazar el `MessageBox` por la navegación Login → `FmInicio`.
- **D1**: completar `SesionService` con lo que falte de `ConexGlobal`.

---

## Paso C2b-1 — Ventana Inicio (layout)  ✅ COMPLETADO (2026-11-10)

**Objetivo**: crear `Views/InicioWindow.xaml(.cs)` replicando el layout de `FmInicio`
y mostrando los datos que ya prepara `InicioViewModel` (C2a). La navegación
Login → Inicio y los clicks del menú quedan para C2b-2 / pasos siguientes.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/InicioWindow.xaml` | Ventana 1400×1040 sin bordes con el layout del WinForms (1571×1167) dentro de un `Viewbox` proporcional: barra superior rosa con minimizar/cerrar, menú lateral con tarjeta del logo y 5 opciones, saludo 64 px, calendario, tabla de pendientes, panel de alertas con `ItemsControl` y "No hay alertas", botones "Ver más pedidos" / "Ver Inventario" |
| `Views/InicioWindow.xaml.cs` | Crea el `InicioViewModel`, llama a `Cargar()`, ajusta la ventana al área de trabajo (el `Viewbox` escala sin recortar), arrastre desde la barra, minimizar con fundido 150 ms y cerrar → `Shutdown()` |
| `Themes/Colores.xaml` | Nuevas claves `FondoSuave` (#FBE9E9) para el grid/panel de alertas y `FondoAlterno` (#FFF0F5) para las filas alternas |
| `Assets/Inicio/` | Copias con nombre limpio de `botonpinkbajo (1).png` → `boton_menu.png` y `escc (1).png` → `boton_accion.png` (los originales quedan intactos) |
| `ViewModels/InicioViewModel.cs` | Sin cambios: se consume tal como quedó en C2a |

### Paridad con el WinForms

| Aspecto | WinForms (`FmInicio`) | WPF (C2b-1) |
|---|---|---|
| Ventana | `ClientSize 1571×1167`, sin bordes, centrada | Mismo lienzo de 1571×1167 en un `Viewbox`; la ventana se limita al área de trabajo |
| Menú lateral | Panel rosa 384 px, tarjeta del logo, 5 botones con imagen de fondo e iconos 54×57 | Mismas coordenadas, imágenes y textos; iconos por nombre (`imginic/imgped/imginv/imgcoti/imgconfig`) |
| Saludo | Label 48 pt con `ConexGlobal.GeneroUsuarioAct` y nombre | `TextBlock` 64 px enlazado a `Saludo` del ViewModel |
| Pedidos | `SELECT` con `EstadoId = 1`, grid con encabezados tinto, filas alternas y fecha `dd/MM/yyyy` | Igual vía `PedidoPendiente` y `DataGrid` con los mismos estilos |
| Alertas | Labels rosas con `Marca - Color` / `Tamaño` / `Quedan`, mensaje "No hay alertas" si no hay filas | `ItemsControl` con plantilla equivalente y aviso controlado por `HayAlertas` |
| Barra superior | Minimizar con fundido, cerrar con `Application.Exit` | Mismo fundido y `Application.Current.Shutdown()` |

### Diferencias deliberadas
- El `Viewbox` escala el lienzo completo para pantallas menores que el diseño; el
  WinForms dependía del escalado por fuente.
- Tipografía Comfortaa en toda la pantalla (identidad de la migración); el WinForms
  usaba Microsoft Sans Serif.
- El `Calendar` de WPF no permite negritas (`BoldedDates`), así que las fechas
  pendientes se ven solo en la tabla. El color de texto del calendario es el nativo
  de WPF (#333); el borde es rosa corporativo. Se conserva la ubicación y el tamaño.
- Los iconos de minimizar/cerrar (`2.png`/`3.png`) llevan fondo crema en el PNG
  original, por lo que se ven como cuadros claros sobre la barra rosa, igual que en
  el WinForms.
- Botones del menú, "Ver más pedidos" / "Ver Inventario" y "Cerrar Sesión": visibles
  sin `Click`, con `TODO(C3/C7/C10/C13/C2c)`.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] Render de verificación `inicio_smoke.png` (1571×1167) con datos de ejemplo:
      saludo, calendario, 2 pedidos y 3 alertas de stock correctos.
- [x] El proyecto WinForms original permanece intacto.
- [x] El harness temporal de captura se eliminó después de verificar.

### Pendiente para pasos siguientes
- **C2b-2**: reemplazar el `MessageBox` del Login por abrir `InicioWindow` y cerrar
  el Login; añadir los clicks del menú cuando existan sus ventanas.
- **C2c**: cerrar sesión con confirmación y refresco al reactivar.

---

## Paso C2b-2 — Navegación Login → Inicio  ✅ COMPLETADO (2026-11-10)

**Objetivo**: reemplazar el `MessageBox` provisional del Login por el flujo real
`Login → FmInicio` del WinForms, con smoke test de la transición.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/LoginWindow.xaml.cs` | `LoginExitoso` ya no muestra el `MessageBox`: crea `InicioWindow`, la muestra y luego cierra el Login. Se eliminó el `TODO(C2)` |
| `App.xaml.cs` | Sin cambios permanentes (el harness temporal `--smoke-login` se eliminó tras verificar) |

### Paridad con el WinForms

| Aspecto | WinForms (`Form1.cs`) | WPF (C2b-2) |
|---|---|---|
| Credencial válida | `this.Hide(); new FmInicio().Show();` | `new InicioWindow().Show(); Close();` |
| Sesión | `ConexGlobal` estático | `SesionService.Actual` (ya desde C1); el saludo de Inicio lee la sesión |
| Ventanas | `FmInicio` única por nombre en `Application.OpenForms` | `InicioWindow` nueva instancia por login; C2c la recrea al cerrar sesión |

### Diferencias deliberadas
- El WinForms **oculta** el Login (`Hide()`) y lo reutiliza. En WPF se **cierra**
  porque con `ShutdownMode.OnLastWindowClose` una ventana oculta mantendría la
  aplicación viva e invisible al cerrar Inicio. El orden `Show()` → `Close()` evita
  que la app se apague en la transición; C2c creará un Login limpio al cerrar sesión.
- Los botones del menú, "Ver más pedidos", "Ver Inventario" y "Cerrar Sesión"
  siguen sin `Click` (C2c/C3/C7/C10/C13).

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] Smoke test con harness temporal (`--smoke-login`): autentica `admin`/`admin`
      contra la BD real, el Login se cierra (`Login cerrado: True`) y `InicioWindow`
      queda visible (`Inicio visible: True`).
- [x] Evidencia `login_smoke.png` (Login) e `inicio_smoke.png` (Inicio con
      "Bienvenida, admin!", calendario de noviembre de 2026 y estado vacío de
      pendientes/alertas del seed).
- [x] El proyecto WinForms original permanece intacto.
- [x] El harness temporal (`Smoke.cs` + rama en `App.xaml.cs`) se eliminó después de
      verificar y el build final volvió a dar 0 errores.

### Pendiente para pasos siguientes
- **C2c**: cerrar sesión con confirmación (recrear `LoginWindow`), refresco al
  reactivar y smoke test.
- **C3/C7/C10/C13**: clicks del menú lateral y botones de acción.

---

## Paso C2c-1 — Cerrar sesión  ✅ COMPLETADO (2026-11-10)

**Objetivo**: replicar `FmInicio.button5_Click` (Cerrar Sesión) con confirmación
Yes/No y volver al Login. El refresco al reactivar y el smoke test quedan para C2c-2.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/InicioWindow.xaml` | El botón "Cerrar Sesión" dejó de ser decorativo: `Click="CerrarSesion_Click"` y se eliminó el `TODO(C2c)` |
| `Views/InicioWindow.xaml.cs` | `CerrarSesion_Click` muestra `MessageBox` YesNo/Question con el texto exacto del WinForms y llama a `ProcesarCerrarSesion(confirmado)`; `ProcesarCerrarSesion(bool)` (interno, sin diálogo) hace `SesionService.Cerrar()` + `new LoginWindow().Show()` + `Close()` para que el smoke de C2c-2 pueda ejercer ambas ramas sin el modal |

### Paridad con el WinForms

| Aspecto | WinForms (`FmInicio.cs`) | WPF (C2c-1) |
|---|---|---|
| Pregunta | `"Deseas cerrar sesión?"` / `"Cerrar Sesión"` / YesNo + Question | Mismo texto, botones e icono |
| Cancelar (No) | No hace nada | No hace nada |
| Aceptar (Sí) | `Application.Restart()` (reinicia el proceso y vuelve al Login) | `SesionService.Cerrar()` + Login nuevo + `Close()` de Inicio |
| "X" de la barra | `Application.Exit()` | `Application.Current.Shutdown()` (sin cambios desde C2b-1) |

### Diferencias deliberadas
- No se reinicia el proceso (`Application.Restart`): se limpia `SesionService` y se
  recrea el Login, que es el efecto observable del original con menos coste. El orden
  `Show()` → `Close()` evita apagar la app con `ShutdownMode.OnLastWindowClose`.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] No quedan `TODO(C2c)` en `MyCrochetWpf`.
- [x] El proyecto WinForms original permanece intacto.
- [x] Smoke test de las dos ramas de la confirmación y del refresco → ver C2c-2.

### Pendiente para pasos siguientes
- **C2c-2**: refresco al reactivar (`IsVisibleChanged` → `Cargar()`), smoke test
  (No/Sí, re-login y refresco con un artículo temporal) y cierre de C2c.

---

## Paso C2c-2 — Refresco al reactivar + smoke test  ✅ COMPLETADO (2026-11-10)

**Objetivo**: replicar `FmInicio_VisibleChanged` (recargar pedidos y alertas cada vez
que Inicio vuelve a mostrarse) y verificar todo el C2c con un smoke test automatizado.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/InicioWindow.xaml.cs` | El constructor ya no llama a `Cargar()`: se suscribe a `IsVisibleChanged` y carga solo cuando `e.NewValue == true` (punto único de carga, equivalente exacto al `VisibleChanged` del WinForms, sin la doble consulta inicial) |
| `Views/InicioWindow.xaml.cs` | `ProcesarCerrarSesion(bool confirmado)` queda como única puerta del cierre de sesión; `CerrarSesion_Click` solo pregunta y delega |
| `App.xaml.cs` | Sin cambios permanentes (el harness temporal `--smoke-session` se eliminó tras verificar) |

### Paridad con el WinForms

| Aspecto | WinForms (`FmInicio.cs`) | WPF (C2c-2) |
|---|---|---|
| Refresco al reactivar | `VisibleChanged` → `if (Visible) { CargarPedidos(); Alertas(); }` | `IsVisibleChanged` → `if (e.NewValue == true) Cargar()` (saludo, pedidos, fechas y alertas) |
| Carga inicial | `VisibleChanged` al mostrarse | Igual: `Show()` dispara `IsVisibleChanged` |
| Ocultar/mostrar entre pantallas | `this.Hide()` / `.Show()` de FmInicio | `Hide()`/`Show()` disparan el mismo refresco (lo usarán C3/C7/C10/C13) |

### Diferencias deliberadas
- El refresco también recalcula el saludo (`CargarSaludo()`), algo que el WinForms solo
  hacía al construir la ventana; es inocuo y mantiene el saludo coherente con la sesión.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] Smoke test con harness temporal (`--smoke-session`) → **6/6**:
      1. Login `admin`/`admin` → Inicio visible.
      2. Cancelar (rama No) → Inicio sigue visible y no se crea Login.
      3. Aceptar (rama Sí) → Login nuevo visible, Inicio cerrado, `Autenticado: False`.
      4. Re-login limpio → saludo `"Bienvenida, admin!"`.
      5. Refresco al reactivar → alerta antes `False`, después `True` con un artículo
         `SMOKE-REFRESCO` insertado entre `Hide()` y `Show()`.
      6. Limpieza → el artículo temporal se elimina y la BD queda como estaba.
- [x] Evidencia `cerrar_sesion_smoke.png` (Login limpio tras cerrar sesión) y
      `refresco_smoke.png` (Inicio mostrando la alerta nueva tras reactivarse).
- [x] El proyecto WinForms original permanece intacto.
- [x] Harness temporal (`Smoke.cs` + rama en `App.xaml.cs`) eliminado; build final
      0 errores.

### Pendiente para pasos siguientes
- **C3/C7/C10/C13**: clicks del menú lateral (usarán `Hide()`/`Show()` y el refresco
  ya funcionará) y botones de acción.
- **D1**: completar `SesionService` con lo que falte de `ConexGlobal`.

---

## Paso C3-1a — PedidosViewModel: datos y filtros  ✅ COMPLETADO (2026-11-10)

**Objetivo**: primera mitad de `FmPedidos` en MVVM: catálogos de los combos, grid de
pedidos y filtrado en vivo. Comandos y ventana quedan para C3-1b / C3-2.

### Implementado

| Archivo | Contenido |
|---|---|
| `ViewModels/PedidosViewModel.cs` | `Pedidos` (`ObservableCollection<PedidoResumen>`), combos `Tipos`/`Estados` con fila "Todos" (Id 0) al inicio, filtros `FiltroTexto`, `TipoIdSeleccionado`, `EstadoIdSeleccionado` con recarga en sus `On*Changed`, `Cargar()` (combos + primera carga) y `Filtrar()` (Id 0 → `null`) |

### Paridad con el WinForms

| Aspecto | WinForms (`FmPedidos.cs`) | WPF (C3-1a) |
|---|---|---|
| Combos | `SELECT Id, Nombre FROM TipoPedidos` + `NewRow` "Todos" (Id 0) insertada al inicio; igual para Estados | Mismos SELECT vía `RepositorioCatalogos`; entidad "Todos" con Id 0 insertada primero |
| Selección inicial | `SelectedIndex = 0` (Todos) | `TipoIdSeleccionado = 0` / `EstadoIdSeleccionado = 0` |
| Filtro texto | `txtBusc_TextChanged` → `Filtrar()` | `OnFiltroTextoChanged` → `Filtrar()` |
| Filtro tipo/estado | `SelectedIndexChanged` → `Filtrar()`; Id 0 → `null` | `On*Changed` → `Filtrar()`; Id 0 → `null` |
| Query | `Listar(filtro, tipo, estado)` con `LIKE` sobre Cliente/Id y `OR @tipo IS NULL` | La misma query ya migrada en B7 |

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] El proyecto WinForms original permanece intacto.
- [x] Prueba funcional de filtros y comandos → **C3-1b** completada (ver sección
      C3-1b al final).

### Pendiente para pasos siguientes
- **C3-1b**: comandos Nuevo/Ver/Modificar/Eliminar, visibilidad según rol, eventos
  de navegación y prueba funcional del VM. (Completado — ver sección C3-1b abajo.)

---

## Paso C3-1b — PedidosViewModel: comandos + prueba funcional  ✅ COMPLETADO (2026-11-11)

**Objetivo**: completar el ViewModel de FmPedidos con los comandos, el rol de
eliminar y los eventos que consumirán las ventanas en C3-2 / C3-3, y verificar el
flujo de datos con una prueba funcional.

### Implementado

| Archivo | Contenido |
|---|---|
| `ViewModels/PedidosViewModel.cs` | `EliminarPedido` (comando + evento `SolicitaConfirmarEliminar`) → `ProcesarEliminarPedido(id, confirmado)` → `Eliminar(id)` + `Filtrar()`; `PuedeEliminarPedidos` (`SesionService.Actual.RolId == 1`); eventos `SolicitaNuevoPedido`, `SolicitaVerPedido`, `SolicitaModificarPedido`, `SolicitaIrAInicio`, `SolicitaCerrarSesion`; comandos `NuevoPedido`, `VerPedido`, `ModificarPedido`, `EliminarPedido`, `IrAInicio`, `CerrarSesion` |

### Paridad con el WinForms

| Aspecto | WinForms (`FmPedidos.cs`) | WPF (C3-1b) |
|---|---|---|
| Eliminar | `EliminarPedido_Click`: `MessageBox` "Deseas eliminar este pedido?" / "Confirmar" / YesNo → `DELETE` → `Pedidos()` | Comando → evento `SolicitaConfirmarEliminar` → `ProcesarEliminarPedido(id, confirmado)` → `Eliminar(id)` + `Filtrar()` |
| Visibilidad eliminar | `eliminarPedido.Visible = (RolUsuarioAct == 1)` | `PuedeEliminarPedidos` → `SesionService.Actual.RolId == 1` |
| Tras eliminar | `Pedidos()` (sin filtros) | `Filtrar()` (mantiene filtros) — **diferencia deliberada**: coherente, evita inconsistencia UI |

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (tras finalizar el harness).
- [x] Prueba funcional con harness temporal (`--test-pedidos-vm`) sobre la BD real:
       combos con "Todos" (tipos=4, estados=5), carga sin filtro (2 pedidos de la seed),
      filtros texto/tipo/estado, eliminación vía comando → recarga y conteo, y visibilidad
      por rol (RolId=1 → true, RolId=2 → false).
- [x] Harness temporal (`SmokeVm.cs` + rama en `App.xaml.cs`) eliminado y build final
      0 errores.
- [x] Proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C3-2**: `Views/PedidosWindow.xaml(.cs)` (tipografía del WinForms: Super Mindset / KG Red Hands) + render. (2a completado — ver sección C3-2a abajo.)
- **C3-3**: navegación Inicio ↔ Pedidos, cerrar sesión y smoke test.

---

## Paso C3-2a — PedidosWindow (ventana)  ✅ COMPLETADO (2026-11-11)

**Objetivo**: construir `Views/PedidosWindow.xaml(.cs)` replicando el layout de
`FmPedidos` (ClientSize 1100x700) y conectándolo al `PedidosViewModel` de C3-1.
El render de verificación queda para C3-2b.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/PedidosWindow.xaml` | Ventana 1100x700 sin bordes con Viewbox + Canvas 1100x700: barra rosa 1102x29 (arrastre, minimizar, cerrar), lateral 269x678 con tarjeta del logo clicable, 5 botones del menú (Pedidos activo en blanco), "Cerrar Sesión" en Good Bakwan; panel principal con título "Gestión de Pedidos" (Super Mindset 64 px), línea rosa, labels/combos de filtro y búsqueda en KG Red Hands, "Nuevo Pedido" y DataGrid 706x371 con ContextMenu estilizado (Ver/Modificar/Eliminar; Eliminar visible por rol) |
| `Views/PedidosWindow.xaml.cs` | Crea `PedidosViewModel`, `Cargar()`, refresco del grid en `IsVisibleChanged`, suscripción a `SolicitaConfirmarEliminar` (MessageBox YesNo Warning), `SolicitaCerrarSesion` (patrón `ProcesarCerrarSesion`) y `SolicitaIrAInicio` (TODO C3-3); selección de fila al clic derecho (paridad `CellMouseDown`); arrastre, minimizar con fundido y cerrar → `Shutdown()`; ventana limitada al área de trabajo |

### Paridad con el WinForms

| Aspecto | WinForms (`FmPedidos.Designer.cs`) | WPF (C3-2a) |
|---|---|---|
| Ventana | `ClientSize 1100x700`, sin bordes, centrada | Mismo lienzo 1100x700 en un Viewbox; se limita al área de trabajo |
| Barra superior | `panel1` 1102x29 rosa; minimizar (1029,3) / cerrar (1063,3) | Mismas coordenadas e imágenes (`3.png` / `2.png`) |
| Lateral | `panel2` 269x678, tarjeta `panel3` 231x151, menú 197x41, "Cerrar Sesión" (55,634) Good Bakwan | Mismas coordenadas absolutas (offset de `panel2` sumado); Pedidos activo con `log2.png` y texto blanco |
| Título | `label2` Super Mindset 48 pt | `TextBlock` Super Mindset 64 px |
| Filtros | labels KG Red Hands 9.75; combos con "Todos"; `txtBusc` en vivo | Mismos textos/posiciones; binding `FiltroTexto` con `UpdateSourceTrigger=PropertyChanged` |
| Grid | `dataGridViewPedidos` 706x371, filas alternas, fecha `dd/MM/yyyy` | `DataGrid` con estilos corporativos, columnas Id/Cliente/Tipo de Pedido/Estado/Fecha |
| Menú contextual | `EditorPedidos` (Ver / Modificar / Eliminar según rol) | `ContextMenu` estilizado rosa/tinto con los mismos ítems; comandos con `CommandParameter=SelectedItem` |
| Clic derecho | `CellMouseDown` selecciona la fila | `PreviewMouseRightButtonDown` selecciona la fila antes del menú |

### Diferencias deliberadas
- Tipografía: título en Super Mindset y labels/botones en KG Red Hands (decisión de C3),
  con Comfortaa en el grid y en el resto de textos donde el WinForms usaba Segoe UI.
- "Nuevo Pedido" usa `Assets/Inicio/boton_menu.png` (rosa con texto tinto) porque el PNG
  original del `.resx` no está disponible como asset suelto.
- Los botones sin ventana destino (Inventario/Cotización/Configuración, logo e Inicio) y
  Nuevo/Ver/Modificar quedan con `TODO(C4/C5/C6/C7/C10/C13/C3-3)`.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] El proyecto WinForms original permanece intacto.
- [x] Render de verificación `pedidos_smoke.png` → ver **C3-2b**.

### Pendiente para pasos siguientes
- **C3-2b**: render de verificación y ajustes de layout. ✅ Completado — ver abajo.

---

## Paso C3-2b — Render de verificación  ✅ COMPLETADO (2026-11-11)

**Objetivo**: generar `pedidos_smoke.png` con datos de ejemplo, comparar contra el
layout de `FmPedidos` y corregir las diferencias visuales detectadas.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/PedidosWindow.xaml` | Fondo del grid a blanco, `RowHeight` 25, "Nuevo Pedido" a 19 px, plantilla propia para la caja de búsqueda (borde rosa fijo, sin foco azul del tema) y plantilla plana corporativa para los combos (crema/rosa, flecha tinta) con estilo de ítems |
| `Views/PedidosWindow.xaml.cs` | Sin cambios: el wiring del ViewModel y los eventos quedó como en C3-2a |
| Harness temporal | `SmokePedidos.cs` + rama `--smoke-pedidos` en `App.xaml.cs`; sembró 5 pedidos, capturó el PNG y limpió la BD; **eliminado** tras verificar |

Ajustes concretos tras el primer render:

- `DataGrid.Background`: `FondoSuave` → `White` (`FmPedidos.disenoPedidos()` fuerza `BackgroundColor = White`).
- `DataGrid.RowHeight`: 30 → 25 para acercarse a la densidad del WinForms.
- "Nuevo Pedido": 17 → 19 px (el WinForms usa 14.25 pt ≈ 19 px).
- `CajaBusqueda`: plantilla con `PART_ContentHost` y borde rosa fijo; se eliminó el borde azul de foco del tema WPF.
- `ComboFiltro`: plantilla plana con fondo crema, borde rosa y flecha tinta; `ItemComboFiltro` con hover rosa y selección alterna. Se reemplazó `DisplayMemberPath` por `ItemTemplate` porque el `SelectionBoxItem` del template propio mostraba el nombre del tipo (`MyCrochetWpf.Models.TipoPedido`) en lugar de `Nombre`.

### Paridad con el WinForms

| Aspecto | WinForms (`FmPedidos`) | WPF (C3-2b) |
|---|---|---|
| Fondo del grid | `disenoPedidos()` → `BackgroundColor = White` | `Background="White"` |
| Altura de fila | ~23 px | 25 px |
| "Nuevo Pedido" | KG Red Hands 14.25 pt ≈ 19 px | 19 px |
| Combos | `DropDownList`, fondo crema, catálogos con "Todos" | Plantilla plana crema/rosa, mismos catálogos y filtros |
| Buscador | Sin borde de foco azul | Borde rosa fijo |
| Anchos de columna | `Fill` equitativo | Ponderados 0.4/1.4/1.6/1.2/1.0 |
| Encabezados | `TipoPedido` / `FechaEntrega` | "Tipo de Pedido" / "Fecha" |

### Diferencias deliberadas
- Anchos de columna ponderados en lugar del `Fill` equitativo: la columna `Id`
  no necesita el mismo espacio que `Cliente` o `Tipo de Pedido`.
- Encabezados más legibles ("Tipo de Pedido", "Fecha") que los nombres técnicos
  del `DataTable` original; se documentan para el checklist de paridad E1.
- Tipografía Comfortaa/KG Red Hands/Super Mindset según la identidad de la migración.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Evidencia `pedidos_smoke.png` (1650×1050 px, DPI 144) en la raíz de la solución:
      5 pedidos de ejemplo, combos en "Todos", sidebar con Pedidos activo, filas
      alternas, fecha `dd/MM/yyyy` y sin recortes ni imágenes faltantes.
- [x] Prueba funcional del harness: 2 combos, desplegable abre, 4 tipos y 5 estados;
      filtro Tipo=Animal → 2 pedidos, Estado=Cancelado → 1, reset → 5;
      `PuedeEliminar=True` con rol administrador.
- [x] BD limpia tras la captura: 0 filas en `Encargos` y 0 con `SMOKE-RENDER`.
- [x] Harness temporal y artefactos (`smoke_info.txt`, PNG junto al `.exe`) eliminados.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C3-3**: navegación Inicio ↔ Pedidos, cerrar sesión y smoke test. ✅ Completado — ver abajo.

---

## Paso C3-3 — Navegación Inicio ↔ Pedidos + cerrar sesión + smoke test  ✅ COMPLETADO (2026-11-13)

**Objetivo**: cerrar `FmPedidos` conectando el menú lateral y los botones de acción
entre Inicio y Pedidos con el patrón `Hide()`/`Show()` del WinForms, completar el
cierre de sesión desde Pedidos y verificarlo con un smoke test automatizado.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/PedidosWindow.xaml` | `IrAInicioCommand` en el botón "Inicio" del menú lateral y en el logo de la tarjeta (`btnInicio_Click` / `btnlogo_Click`) |
| `Views/PedidosWindow.xaml.cs` | `IrAInicioSolicitado()`: reutiliza la `InicioWindow` de `Application.Current.Windows` (o la crea), `Show()` + `Activate()` y `Hide()` de Pedidos; `ProcesarCerrarSesion(bool)` con el patrón de Inicio |
| `ViewModels/InicioViewModel.cs` | Evento `SolicitaIrAPedidos` + comando `IrAPedidosCommand` (mismo patrón que `PedidosViewModel`) |
| `Views/InicioWindow.xaml.cs` | `IrAPedidosSolicitado()`: reutiliza/crea `PedidosWindow`, `Show()` + `Activate()` y `Hide()` de Inicio |
| `Views/InicioWindow.xaml` | `IrAPedidosCommand` en "Pedidos" del menú lateral y en "Ver más pedidos" (`btnPedidos_Click` / `btnNuevoPed_Click`) |
| `Services/NavegacionSesion.cs` | `VolverAlLogin()`: limpia la sesión, abre el Login y cierra **todas** las demás ventanas (visibles u ocultas); reemplazo del `Application.Restart()` del WinForms |
| `App.xaml.cs` | Sin cambios permanentes (harness temporal `--smoke-nav` eliminado tras verificar) |

### Paridad con el WinForms

| Aspecto | WinForms | WPF (C3-3) |
|---|---|---|
| Inicio → Pedidos | `btnPedidos_Click` / `btnNuevoPed_Click`: `Hide()` + `Application.OpenForms["FmPedidos"]` o nueva | Comando → evento → `Hide()` + reutilizar/crear `PedidosWindow` |
| Pedidos → Inicio | `btnInicio_Click` / `btnlogo_Click`: `Hide()` + `Application.OpenForms["FmInicio"]` o nueva | Igual con `Application.Current.Windows.OfType<InicioWindow>()` |
| Refresco al volver | `VisibleChanged` → recargar datos | `IsVisibleChanged` ya existente en ambas ventanas (C2c / C3-2a) |
| Cerrar sesión | `button5_Click` → Yes/No → `Application.Restart()` | Yes/No → `NavegacionSesion.VolverAlLogin()` (cierra también las ventanas ocultas) |

### Diferencias deliberadas
- El WinForms cerraba todo con `Application.Restart()` (reinicio del proceso); aquí
  se limpia la sesión y se recrea el Login, cerrando explícitamente las ventanas
  ocultas para evitar instancias huérfanas al volver a entrar.
- Se muestra la pantalla destino antes de ocultar la actual (igual que el WinForms),
  evitando un instante sin ventanas visibles con `ShutdownMode.OnLastWindowClose`.
- Inventario, Cotización y Configuración siguen inertes (C7/C10/C13).
- El parámetro `confirmado` de `ProcesarCerrarSesion(bool)` existe para que el smoke
  test ejerza ambas ramas sin el `MessageBox` modal (mismo criterio que C2c-2).

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Smoke test con harness temporal (`--smoke-nav`) → **20/20**:
      1. Login `admin`/`admin` → Inicio visible y sin Pedidos abierto.
      2. Los 2 botones de Inicio (menú + "Ver más pedidos") enlazados a `IrAPedidosCommand`.
      3. Inicio → Pedidos: Pedidos visible, Inicio oculto.
      4. Los 2 botones de Pedidos (logo + "Inicio") enlazados a `IrAInicioCommand`.
      5. Artículo `SMOKE-NAV` insertado con Inicio oculto.
      6. Pedidos → Inicio: misma instancia reutilizada y alerta refrescada al reaparecer.
      7. Segunda ida: Pedidos reutiliza su instancia.
      8. Cerrar sesión rama No: sigue en Pedidos con sesión activa.
      9. Rama Sí: vuelve al Login, Pedidos e Inicio (oculta) cerrados, sesión limpia
         y solo queda 1 ventana.
      10. BD limpia de `SMOKE-NAV` (0 filas).
- [x] Evidencia `nav_pedidos_smoke.png` (1650×1050) y `nav_inicio_smoke.png`
      (1920×1128, con la alerta `SMOKE-NAV` visible tras el refresco).
- [x] Harness temporal (`SmokeNav.cs` + rama en `App.xaml.cs`) eliminado.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C4**: `FmNuevoPedido` (el evento `SolicitaNuevoPedido` ya está listo en `PedidosViewModel`).
  ✅ C4-1 completado — ver abajo.

---

## Paso C4-1 — NuevoPedidoViewModel + prueba funcional  ✅ COMPLETADO (2026-11-13)

**Objetivo**: migrar la lógica de `FmNuevoPedido` a un ViewModel (catálogos, total en
vivo, validaciones, INSERT y limpieza) y verificarla con una prueba funcional antes
de construir la ventana en C4-2.

### Implementado

| Archivo | Contenido |
|---|---|
| `ViewModels/NuevoPedidoViewModel.cs` | Catálogos `Tipos`/`Estados`/`OpcionesEnvio` sin fila "Todos" y sin selección inicial; `Cliente`, `Contacto`, `Descripcion`, `FechaEntrega` (`DateTime?`, inicia hoy), `Subtotal`/`Envio`/`Anticipo` (texto, inician en "0"); `Total` recalculado en cada cambio; `GifActual`/`HayGif` según el tipo (Personaje/Animal/Flor); comandos `Guardar` y `Cerrar`; eventos `SolicitaAdvertencia`, `PedidoGuardado` y `SolicitaCerrar` |
| `ViewModels/NuevoPedidoViewModel.cs` | `Guardar`: validación ampliada (nombre, tipo, estado, envío, fecha y montos con parse seguro), `RepositorioEncargos.Insertar`, evento de éxito y `Limpiar()` (la ventana sigue abierta) |
| `Data/RepositorioEncargos.cs` | Sin cambios: se consume `Insertar(Encargo)` (B7) |
| `Data/RepositorioCatalogos.cs` | Sin cambios: se consumen `ListarTiposPedido`, `ListarEstados` y `ListarOpcionesEnvio` (B5) |
| `App.xaml.cs` | Sin cambios permanentes (harness temporal `--test-nuevo-pedido-vm` eliminado) |

### Paridad con el WinForms

| Aspecto | WinForms (`FmNuevoPedido.cs`) | WPF (C4-1) |
|---|---|---|
| Combos | `SELECT Id, Nombre/Estado FROM ...` vía `SqlDataAdapter`; `SelectedIndex = -1` | Mismos SELECT vía `RepositorioCatalogos`; propiedades nullable en `null` |
| Fecha | `DateTimePicker` formato Short (solo fecha) | `FechaEntrega: DateTime?` (DatePicker en C4-2), guardada con `.Date` |
| Total | `textBox6_TextChanged` → `(subtotal + envio) − anticipo`, `ToString("0.00")` | `OnSubtotalChanged`/`OnEnvioChanged`/`OnAnticipoChanged` → `Total`; formato `0.00` en la vista |
| Montos | `TryParse` para el total y `Convert.ToDecimal` al guardar | `TryParse` seguro también al guardar; texto vacío = 0 |
| GIF por tipo | `cmbNTipo_SelectedIndexChanged` con rutas absolutas a `AnimacionesFinal` | `GifActual` con pack URI a `Assets/Gifs/` (animación con WpfAnimatedGif en C4-2) |
| Guardar | Solo valida el nombre; combos sin selección lanzan excepción | Validación ampliada con mensajes por campo (decisión aprobada) |
| Tras guardar | `MessageBox` → `Limpiartext()`; la ventana sigue abierta | `PedidoGuardado` → `Limpiar()`; misma fidelidad |
| Cerrar | `btnCerrar_Click` → `Close()` | `CerrarCommand` → `SolicitaCerrar` (la vista cierra en C4-2) |

### Diferencias deliberadas
- Validación ampliada: se exige tipo, estado, envío, fecha y montos numéricos (el
  original solo validaba el nombre y fallaba con excepción en los combos vacíos).
- Un monto vacío se trata como 0; un texto no numérico muestra advertencia (el
  original lanzaba excepción con `Convert.ToDecimal`).
- Un error de base de datos muestra "No se pudo registrar el pedido. Intente
  nuevamente." en lugar de propagar la excepción (mismo criterio que el Login).
- La fecha se guarda como `FechaEntrega.Date` (`yyyy-MM-dd 00:00:00`), equivalente
  al `DateTimePicker` en formato corto.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Prueba funcional con harness temporal (`--test-nuevo-pedido-vm`) → **23/23**:
      catálogos (3/4/4) y combos sin selección; total `(100+20)-10 = 110.00` y
      texto inválido = 0 en el cálculo vivo; GIF Personaje/Animal/Flor/oculto;
      las 6 validaciones con sus mensajes sin insertar; guardado válido con todos
      los campos y `EstadoId = 1` (verificado con `ListarPendientes`); `Limpiar()`
      tras guardar; `CerrarCommand`; BD limpia de `SMOKE-NUEVO`.
- [x] Nota: `ObtenerPorId` no lee `EstadoId` (fiel a `FmEditarPedido`, que no edita
      estado), por eso el smoke valida el estado con `ListarPendientes`.
- [x] Harness temporal (`SmokeNuevoPedido.cs` + rama en `App.xaml.cs`) eliminado.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C4-2**: `Views/NuevoPedidoWindow.xaml(.cs)` (597×471, Viewbox + Canvas, GIF
  animado con WpfAnimatedGif) + wiring de mensajes y render de verificación.
- **C4-3**: abrir el modal desde `PedidosWindow` (`ShowDialog` + `Filtrar()`) y
  smoke test de flujo completo.

---

## Paso C4-2a — Views/NuevoPedidoWindow.xaml(.cs)  ✅ COMPLETADO (2026-11-13)

**Objetivo**: construir la ventana del formulario de pedido nuevo (layout del
WinForms, paleta corporativa y wiring con `NuevoPedidoViewModel`) antes del render
de verificación de C4-2b.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/NuevoPedidoWindow.xaml` | Ventana sin bordes 597x471 (ClientSize del WinForms) con `Canvas`: línea rosa, título "Nuevo Pedido" (Super Mindset), etiquetas KG Red Hands 13, campos, combos, DatePicker, Descripción multilínea, GIF del tipo, Total tinto y botón "Registrar Pedido" (imagen `boton_accion.png`) |
| `Views/NuevoPedidoWindow.xaml` | Estilos propios: `Etiqueta`, `CampoPedido`/`CampoDescripcion` (borde rosa), `ComboCampo` (misma plantilla plana de Pedidos), `SelectorFecha` (plantilla de DatePicker con `PART_TextBox`/`PART_Button`/`PART_Popup`/`PART_Calendar`) y `DiaCalendario`/`MesCalendario` |
| `Views/NuevoPedidoWindow.xaml.cs` | `DataContext = NuevoPedidoViewModel`; suscripción a `SolicitaAdvertencia` ("Faltan datos", Warning), `PedidoGuardado` ("Registro Exitoso", Information) y `SolicitaCerrar` → `Close()`; `Cargar()` al abrir; arrastre desde la barra superior y `Cerrar_Click` |
| `AGENTS.md` | Roadmap: C4-2a marcado; C4-2b pendiente |
| Recursos | Sin archivos nuevos: el botón usa `Assets/Inicio/boton_accion.png` (misma píldora rosa del resx `btnNPedido`) y la X usa `Assets/Login/icono_cerrar.png` (misma del resx `btnCerrar`) |

### Paridad con el WinForms

| Aspecto | WinForms (`FmNuevoPedido`) | WPF (C4-2a) |
|---|---|---|
| Ventana | `FormBorderStyle.None`, ClientSize 597x471, fondo `#FBE9E9` (`FondoSuave`) | `WindowStyle=None`, 597x471, `Background=FondoSuave` |
| Arrastre | `panel1_MouseDown` → `SendMessage` | `DragMove()` desde la barra superior (ignora clics en botones) |
| Título | `label6` Super Mindset 30 pt | TextBlock Super Mindset 40 px en la misma posición |
| Campos | TextBox sin borde y combos `DropDownList` con `SelectedIndex = -1` | TextBox con borde rosa y combos con `SelectedItem` nullable (sin selección inicial) |
| Fecha | `DateTimePicker` formato Short | `DatePicker` con plantilla plana y calendario tinto |
| Descripción | `txtNDesc` multilínea 356x92 | TextBox multilínea con scroll vertical |
| GIF | `picBox1` visible solo para Amigurumi/Animal/Flores | `Image` con `ImageBehavior.AnimatedSource` (WpfAnimatedGif) y visibilidad por `HayGif` |
| Total | `lblNTotal` Good Bakwan sobre fondo tinto, `ToString("0.00")` | Border tinto con TextBlock Good Bakwan, `StringFormat=0.00` |
| Mensajes | `MessageBox` de advertencia y de registro exitoso | Mismos textos/títulos/iconos desde el code-behind |
| Cerrar | `btnCerrar_Click` → `Close()` | Comando `Cerrar` → `Close()` |

### Diferencias deliberadas
- Los TextBox del WinForms no tenían borde (quedaban invisibles sobre el fondo
  rosa); en WPF llevan borde rosa y fondo blanco, como `CajaBusqueda` en Pedidos.
- Se usa `Canvas` fijo (sin `Viewbox`) porque la ventana es moda y no redimensionable,
  igual que el WinForms.
- El DatePicker usa plantilla propia para evitar el chrome gris de Windows; el
  calendario del desplegable reutiliza los estilos tintos de Inicio.
- El GIF se anima con WpfAnimatedGif (paquete ya previsto en C4-1).

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] Verificación temporal de carga (`--verificar-nuevo-pedido`, eliminada): la
      ventana abre sin excepciones, el `DatePicker` se encuentra y acepta fecha,
      y los catálogos llegan con 3 tipos / 4 estados / 4 opciones de envío; Total
      inicial `0.00` y cliente vacío. Se corrigió `Stretch="Zoom"` (inválido en WPF)
      por `Uniform`.
- [x] Captura de revisión local generada y revisada; archivo temporal borrado
      (la evidencia oficial `nuevo_pedido_smoke.png` corresponde a C4-2b).
- [x] Harness temporal (`VerificacionNuevoPedidoTemporal.cs` + rama en `App.xaml.cs`)
      eliminado y build final repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C4-2b**: render de verificación `nuevo_pedido_smoke.png` y ajustes finos.
- **C4-3**: abrir el modal desde `PedidosWindow` (`ShowDialog` + `Filtrar()`).

---

## Paso C4-2b — Render de verificación de NuevoPedidoWindow  ✅ COMPLETADO (2026-11-13)

**Objetivo**: generar la evidencia visual del formulario con datos representativos y
confirmar que el layout, el GIF y el total se muestran como en el WinForms.

### Implementado

| Archivo | Contenido |
|---|---|
| `nuevo_pedido_smoke.png` (raíz del repo) | Render 598x472 de `NuevoPedidoWindow` con cliente "María López", contacto "555 123 4567", tipo **Amigurumi** (GIF Personaje), estado **Pendiente**, envío **Entrega personal**, fecha 24/12/2026, subtotal 450, envío 60, anticipo 100 → **Total 410.00** |
| `MyCrochetWpf/SmokeNuevoPedidoWindow.cs` | Harness temporal (selección de tipo/estado/envío, montos, espera de 800 ms para el primer fotograma del GIF y `RenderTargetBitmap`); **eliminado** |
| `App.xaml.cs` | Sin cambios permanentes (rama `--smoke-nuevo-pedido-ventana` eliminada) |

### Revisión del render
- Título, etiquetas, cajas, combos y fechas en las coordenadas del Designer.
- El **GIF se anima** y se escala a 155x155 centrado (equivalente al `SizeMode.Zoom`
  del PictureBox); su fondo gris es el propio del archivo.
- El calendario del DatePicker muestra el formato corto localizado (`24/12/2026`).
- **Total** en vivo sobre el bloque tinto con formato `0.00` (`410.00`).
- Botón "Registrar Pedido" con la píldora rosa y la X de cierre en la barra superior.
- Sin ajustes de layout necesarios; se conservó el borde rosa de los campos
  (diferencia deliberada ya documentada en C4-2a).

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Harness temporal de render ejecutado sin excepciones; reporte `OK 598x472 |
      Total: 410.00` y evidencia `nuevo_pedido_smoke.png` (81 KB) revisada.
- [x] Archivos temporales (`SmokeNuevoPedidoWindow.cs`, rama de `App.xaml.cs` y
      `nuevo_pedido_smoke.txt`) eliminados; build final repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C4-3**: abrir el modal desde `PedidosWindow` (`ShowDialog` + `Filtrar()`) y
  smoke test del flujo completo (registrar pedido y verlo en el grid).

---

## Paso C4-3 — Modal desde Pedidos + smoke del flujo completo  ✅ COMPLETADO (2026-11-13)

**Objetivo**: conectar el botón "Nuevo Pedido" de `PedidosWindow` con el modal
`NuevoPedidoWindow` (equivalente a `btnNuevoPed_Click` del WinForms) y verificar el
flujo completo de captura y refresco del grid.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/PedidosWindow.xaml.cs` | Suscripción a `PedidosViewModel.SolicitaNuevoPedido` y método `AbrirNuevoPedido()`: crea `NuevoPedidoWindow` con `Owner = this`, `ShowDialog()` y al cerrar `viewModel.Filtrar()` |
| `AGENTS.md` | Roadmap: C4-3 y el paso C4 completados; siguiente C5 |
| `pedidos_flujo_smoke.png` (raíz del repo) | Render 1100x700 del grid con el pedido de prueba visible y el filtro vigente |
| `MyCrochetWpf/SmokeNuevoPedidoFlujo.cs` | Harness temporal del flujo (comando real, llenado del modal, cierre automático del `MessageBox` por `FindWindow`/`PostMessage`, captura y limpieza); **eliminado** |
| `App.xaml.cs` | Sin cambios permanentes (rama `--smoke-nuevo-pedido-flujo` eliminada) |

### Paridad con el WinForms

| Aspecto | WinForms (`FmPedidos.cs`) | WPF (C4-3) |
|---|---|---|
| Abrir modal | `new FmNuevoPedido().ShowDialog()` | `NuevoPedidoWindow` con `Owner = this` y `ShowDialog()` |
| Al cerrar | `Pedidos()` recarga sin filtros | `Filtrar()` reaplica el filtro vigente (mismo criterio que al eliminar) |
| Guardado | El modal inserta y limpia; el grid se recarga al cerrar | Igual: el VM inserta y limpia; `Filtrar()` al cerrar muestra la fila nueva |
| Mensajes | `MessageBox` del modal | Sin cambios (C4-2a) |

### Smoke test del flujo completo (12/12)
Harness temporal que ejercita la ruta real del botón:
1. Sesión admin (`RolId = 1`), BD limpia de `SMOKE-C4-3` y filtro del grid en `SMOKE-C4-3`.
2. `NuevoPedidoCommand.Execute` → `SolicitaNuevoPedido` → `ShowDialog` (el modal se detecta en `Application.Windows`).
3. Desde el modal real: cliente `SMOKE-C4-3 Flujo`, Amigurumi, primer estado/envío, 31/12/2026, descripción, 300 + 50 − 100.
4. `GuardarCommand`: el `MessageBox` "Registro Exitoso" se cierra desde un hilo con `FindWindow`/`PostMessage`; después se cierra el modal.
5. Al volver, `Filtrar()` conserva el filtro y muestra exactamente la fila nueva.
6. Verificación en BD: subtotal 300.00, envío 50.00, anticipo 100.00, **total 250.00** y fecha 31/12/2026.
7. Captura `pedidos_flujo_smoke.png`, eliminación del pedido de prueba y comprobación de BD/grid limpios.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Smoke del flujo completo → **12/12 aserciones correctas**.
- [x] Evidencia `pedidos_flujo_smoke.png` revisada (grid con el pedido y filtro vigente).
- [x] Harness temporal y reporte `.txt` eliminados; build final repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C5**: `FmVerPedido` (detalle del pedido desde el menú contextual, `ShowDialog`).

---

## Paso C5-1 — VerPedidoViewModel + prueba funcional  ✅ COMPLETADO (2026-11-14)

**Objetivo**: migrar la carga del detalle de `FmVerPedido` a un ViewModel de solo
lectura y verificarlo con una prueba funcional antes de construir la ventana (C5-2).

### Implementado

| Archivo | Contenido |
|---|---|
| `ViewModels/VerPedidoViewModel.cs` | Constructor con `idPedido`; `Cargar()` usa `RepositorioEncargos.ObtenerDetalle` (B7); propiedades observables `Cliente`, `Contacto`, `TipoPedido`, `FechaEntrega`, `Descripcion`, `Subtotal`, `Envio`, `Anticipo`, `CostoEnvio`, `Total`; eventos `SolicitaError` y `SolicitaCerrar` |
| `ViewModels/VerPedidoViewModel.cs` | Formateo fijo: montos `"$#,##0.00"` con `InvariantCulture` (negativos con el signo antes del `$`), fecha `dd/MM/yyyy`; nulos → `$0.00`, contacto/descripción vacíos y envío `"No especificado"` |
| `App.xaml.cs` | Sin cambios permanentes (harness temporal `--test-ver-pedido-vm` eliminado) |

### Decisiones de C5 aplicadas
- Montos con **`"$#,##0.00"` fijo** (elegido por la dueña), no `C2` dependiente de la
  configuración regional.
- Detalle inexistente → mensaje `"Error al cargar el detalle del pedido."` y cierre
  (el WinForms dejaba la ventana vacía).
- Error de BD → conserva el texto del original
  (`"Error al cargar el detalle del pedido: …"`) y cierra.
- `Cargar()` se llama desde la vista **después** de suscribir los eventos, para no
  perder el aviso de error (el WinForms lo hacía en `Load`).

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] Prueba funcional con harness temporal (`--test-ver-pedido-vm`) → **22/22**:
      - Fila completa: cliente, contacto, tipo Amigurumi, fecha 24/12/2026,
        descripción, subtotal `$450.00`, anticipo `$100.00`, envío `$60.00`,
        total `$1,234.50` y opción `Entrega personal`.
      - Fila con nulos: contacto/descripción `''`, subtotal/anticipo/costo/total
        `$0.00`, envío `"No especificado"`, fecha 15/01/2027.
      - Id inexistente: mensaje acordado y `SolicitaCerrar` disparado.
      - BD limpia al iniciar y al terminar (filas `SMOKE-C5`).
- [x] Harness temporal (`SmokeVerPedidoViewModel.cs` + rama en `App.xaml.cs`) y
      reporte eliminados; build final repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C5-2**: `Views/VerPedidoWindow.xaml(.cs)` 410×510 con título "Ver Pedido"
  (aprobado), campos ReadOnly y render de verificación.
- **C5-3**: abrir desde el menú contextual de Pedidos (`ShowDialog`) + smoke.

---

## Paso C5-2a — VerPedidoWindow (ventana + wiring)  ✅ COMPLETADO (2026-11-14)

**Objetivo**: construir la ventana de detalle con el layout del Designer y conectar
el `VerPedidoViewModel` de C5-1 (mensaje de error, cierre y carga al mostrarse).

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/VerPedidoWindow.xaml` | Ventana sin bordes 410x510 (ClientSize del WinForms) con `Canvas`: línea rosa en y=33, título "Ver Pedido" (Super Mindset 24), etiquetas KG Red Hands 13, descripción multilínea 356x126 y campos blancos sin borde |
| `Views/VerPedidoWindow.xaml` | Estilos propios: `Etiqueta`, `CampoLectura` (TextBox solo lectura, `BorderThickness=0`, `IsTabStop=False`) y `CampoDescripcionLectura`; X de cierre con `Assets/Login/icono_cerrar.png` (la misma del resx `btnCerrar`) |
| `Views/VerPedidoWindow.xaml.cs` | Constructor con `idPedido` → `VerPedidoViewModel`; suscripción a `SolicitaError` (MessageBox `"Error de Lectura"`, icono Error) y `SolicitaCerrar` → `Close()`; `Cargar()` en `Loaded`; arrastre desde la barra superior y `Cerrar_Click` |
| `AGENTS.md` | Roadmap: C5-2a marcado; C5-2b pendiente |

### Paridad con el WinForms

| Aspecto | WinForms (`FmVerPedido`) | WPF (C5-2a) |
|---|---|---|
| Ventana | `FormBorderStyle.None`, ClientSize 410x510, fondo `#FBE9E9` (`FondoSuave`) | `WindowStyle=None`, 410x510, `Background=FondoSuave` |
| Arrastre | `panel1_MouseDown` → `SendMessage` | `DragMove()` desde la barra superior (ignora clics en botones) |
| Título | Solo barra roja, sin texto | "Ver Pedido" (aprobado en C5-2) |
| Campos | `TextBox` `ReadOnly`, `BorderStyle.None`, fondo blanco | `TextBox` solo lectura con la misma apariencia y sin foco de tabulación |
| Descripción | `txtDesc` multilínea 356x126 | TextBox multilínea con scroll vertical |
| Montos / fecha | `txt*` con `ToString("C2")` / `dd/MM/yyyy` | Vienen formateados del VM (`$#,##0.00` / `dd/MM/yyyy`) |
| Cerrar | `btnCerrar_Click` → `Close()` | Botón X → `Close()` |
| Error | `MessageBox` título "Error de Lectura" | Mismo texto, título e icono desde el code-behind |

### Diferencias deliberadas
- `Cargar()` se ejecuta en `Loaded`, no en el constructor: así el `MessageBox` de
  error tiene owner visible y, si el Id no existe, el cierre no invalida una
  ventana que aún no se mostró (C5-3 abrirá con `ShowDialog`).
- El `Canvas` es fijo (sin `Viewbox`) porque la ventana es modal y no redimensionable.
- Se mantiene el aspecto plano del WinForms (campos blancos sin borde ni color de
  foco), que en este formulario de solo lectura se lee bien sobre el fondo rosa.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] Verificación temporal (`--verificar-ver-pedido`, eliminada) → **30/30**:
      título/ancho/alto/estilo, `DataContext` con el VM, las 10 propiedades del VM
      con los valores esperados (`$450.00`, `$100.00`, `$60.00`, `$1,234.50`,
      `24/12/2026`, `Entrega personal`), 10 TextBox encontrados con el mismo texto,
      todos `IsReadOnly` y sin `IsTabStop`, cierre de la ventana y BD limpia.
- [x] Render de revisión local 410x510 revisado (layout del Designer: título, dos
      columnas, descripción, montos y total `$1,234.50`); archivo temporal borrado
      (la evidencia oficial `ver_pedido_smoke.png` corresponde a C5-2b).
- [x] Harness temporal (`SmokeVerPedidoWindow.cs` + rama en `App.xaml.cs`) y
      reporte eliminados; build final repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C5-2b**: render de verificación `ver_pedido_smoke.png` y ajustes finos.
- **C5-3**: abrir desde el menú contextual de Pedidos (`ShowDialog`) + smoke.

---

## Paso C5-2b — Render de verificación de VerPedidoWindow  ✅ COMPLETADO (2026-11-14)

**Objetivo**: generar la evidencia visual del detalle con datos representativos y
confirmar que el layout de solo lectura se muestra como en el WinForms.

### Implementado

| Archivo | Contenido |
|---|---|
| `ver_pedido_smoke.png` (raíz del repo) | Render 410x510 de `VerPedidoWindow` con cliente "María López", contacto 555 123 4567, tipo **Amigurumi**, fecha 24/12/2026, descripción de dos párrafos, opción **Entrega personal**, subtotal `$450.00`, costo de envío `$60.00`, anticipo `$100.00` y total `$1,234.50` |
| `MyCrochetWpf/SmokeVerPedidoRender.cs` | Harness temporal (INSERT del pedido, apertura de la ventana real, espera del `DataBind`, `RenderTargetBitmap` 410x510 y DELETE de la fila); **eliminado** |
| `App.xaml.cs` | Sin cambios permanentes (rama `--smoke-ver-pedido` eliminada) |

### Revisión del render
- Ventana 410x510 con el título "Ver Pedido" y la X sobre la barra superior.
- Etiquetas y campos en las coordenadas del Designer (dos columnas): cliente,
  contacto, tipo, fecha, subtotal, opción de envío, anticipo y costo de envío.
- La descripción multilínea conserva los dos párrafos y el ajuste de línea dentro
  del recuadro blanco de 356x126.
- Montos con el formato fijo de C5 (`$450.00`, `$60.00`, `$100.00`, `$1,234.50`) y
  fecha `24/12/2026`; el total se lee sin recortes.
- Los 10 campos se ven blancos y sin borde, en modo solo lectura como el original.
- Sin ajustes de layout necesarios.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Harness temporal de render ejecutado sin excepciones; reporte
      `OK 410x510 | Cliente: María López | Total: $1,234.50 | 51 KB` y evidencia
      `ver_pedido_smoke.png` (52,831 bytes) revisada.
- [x] Archivos temporales (`SmokeVerPedidoRender.cs`, rama de `App.xaml.cs` y
      `ver_pedido_smoke.txt`) eliminados; BD limpia (0 filas del pedido de prueba)
      y build final repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C5-3**: abrir desde el menú contextual de Pedidos (`ShowDialog`) + smoke del
  flujo completo.

---

## Paso C5-3 — Abrir desde Pedidos + smoke del flujo completo  ✅ COMPLETADO (2026-11-14)

**Objetivo**: conectar el ítem "Ver Pedido" del menú contextual de `PedidosWindow`
con el modal `VerPedidoWindow` (equivalente a `VerPedido_Click` del WinForms) y
verificar el flujo completo con un smoke test.

### Implementado

| Archivo | Contenido |
|---|---|
| `Views/PedidosWindow.xaml.cs` | Suscripción a `PedidosViewModel.SolicitaVerPedido` y método `AbrirVerPedido(int id)`: crea `VerPedidoWindow` con `Owner = this` y `ShowDialog()`; al ser solo lectura no recarga el grid (igual que el WinForms) |
| `AGENTS.md` | Roadmap: C5, C5-2b y C5-3 completados; siguiente C6 |
| `ver_pedido_flujo_smoke.png` (raíz del repo) | Render 410x510 del modal abierto desde el menú con el pedido de prueba de la fila seleccionada |
| `MyCrochetWpf/SmokeVerPedidoFlujo.cs` | Harness temporal (filtro, selección de fila, apertura del `ContextMenu`, ejecución del comando del ítem, comprobación del modal dentro del bucle de `ShowDialog`, render y limpieza); **eliminado** |
| `App.xaml.cs` | Sin cambios permanentes (rama `--smoke-ver-pedido-flujo` eliminada) |

### Paridad con el WinForms

| Aspecto | WinForms (`FmPedidos.cs`) | WPF (C5-3) |
|---|---|---|
| Ítem del menú | `VerPedido_Click` (EditorPedidos) | `MenuItem` "Ver Pedido" → `VerPedidoCommand` con `CommandParameter = SelectedItem` |
| Apertura | `new FmVerPedido(id).ShowDialog()` | Evento `SolicitaVerPedido` → `AbrirVerPedido(id)` → `ShowDialog()` |
| Propietario | Modal sin owner explícito | `Owner = this` (modal sobre Pedidos) |
| Tras cerrar | No recarga el grid | No recarga el grid (detalle de solo lectura) |
| Id | `CurrentRow.Cells["Id"]` | `PedidoResumen.Id` de la fila seleccionada |

### Smoke test del flujo completo (24/24)
Harness temporal que ejercita la ruta real del menú:
1. Sesión admin (`RolId = 1`) y pedido de prueba `SMOKE-C5-3 Flujo` (Amigurumi,
   Estafeta, 15/01/2027, 300 + 50 − 100 → **$250.00**).
2. `PedidosWindow` con filtro `SMOKE-C5-3`; la fila de prueba queda seleccionada
   en el `DataGrid`.
3. Se abre el `ContextMenu` real: 3 ítems, "Ver Pedido" con el comando del VM y la
   fila seleccionada como parámetro (bindings de `PlacementTarget` resueltos).
4. Ejecución del comando del ítem → `SolicitaVerPedido` → `AbrirVerPedido` →
   `ShowDialog`; el modal se detecta en `Application.Windows` con `Owner = Pedidos`.
5. El detalle muestra cliente, contacto, tipo, fecha, subtotal, envío, anticipo,
   costo de envío y total del pedido de prueba; render del modal guardado.
6. Al cerrar: `ShowDialog` regresa, el modal desaparece, el filtro y la fila del
   grid se conservan, Pedidos queda habilitado y la fila sigue en la BD.
7. Eliminación de la fila de prueba y verificación de BD limpia.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Smoke del flujo completo → **24/24 aserciones correctas**.
- [x] Evidencia `ver_pedido_flujo_smoke.png` (43,677 bytes) revisada: modal con el
      detalle del pedido abierto desde el menú contextual.
- [x] Harness temporal (`SmokeVerPedidoFlujo.cs`, rama de `App.xaml.cs` y reporte)
      eliminado; build final repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C6**: `FmEditarPedido` (modificar el pedido desde el menú contextual).

---

## Paso C6-1a — EditarPedidoViewModel  ✅ COMPLETADO (2026-11-14)

**Objetivo**: migrar la carga, el cálculo del total, la validación y el UPDATE de
`FmEditarPedido` a un ViewModel antes de construir la ventana (C6-2).

### Decisiones de C6 aplicadas
- **Costo de envío = campo tecleado**: el original lo sobreescribía con el Id de la
  opción del combo (`cmbEnvio.SelectedValue`, 1–4); se alinea con FmNuevoPedido.
- **Validación "Faltan datos"** con los mismos criterios de C4-1a (cliente, tipo,
  opción de envío, fecha y montos válidos).
- Título **"Editar Pedido"** (se aplica en C6-2a, como "Ver Pedido" en C5).
- Detalle inexistente o error de carga → mensaje y cierre (mismo criterio de C5).

### Implementado

| Archivo | Contenido |
|---|---|
| `ViewModels/EditarPedidoViewModel.cs` | Constructor con `idPedido`; `Cargar()` con catálogos (`Tipos`, `OpcionesEnvio` sin "Todos") y `ObtenerPorId` (B7); propiedades observables `Cliente`, `Contacto`, `TipoSeleccionado`, `FechaEntrega`, `Descripcion`, `Subtotal`, `Anticipo`, `CostoEnvio`, `EnvioSeleccionado` y `Total`; `Guardar` con `Actualizar` y `Cerrar`; eventos `SolicitaAdvertencia`, `SolicitaError`, `PedidoActualizado` y `SolicitaCerrar` |
| `ViewModels/EditarPedidoViewModel.cs` | Total en vivo `(Subtotal + CostoEnvio) − Anticipo` mostrado como `"$0.00"` (formato del WinForms); carga sin recalcular para conservar el total inicial de `PrecioFinal`; montos `"0.00"` y vacío para `NULL`; `PuedeEditarPedido` (`RolId == 1`) |
| `AGENTS.md` | Roadmap: C6 dividido en C6-1/C6-2/C6-3; C6-1a marcado |

### Paridad con el WinForms

| Aspecto | WinForms (`FmEditarPedido`) | WPF (C6-1a) |
|---|---|---|
| Catálogos | `SELECT Id, Nombre FROM TipoPedidos` / `OpcionesEnvio` | `ListarTiposPedido()` / `ListarOpcionesEnvio()` (B5) |
| Carga | `SELECT … FROM Encargos WHERE Id = @id` | `ObtenerPorId(id)` (B7, mismas columnas y sin `EstadoId`) |
| Total inicial | `txtTotal = "$" + PrecioFinal.ToString("0.00")` | `totalPed = PrecioFinal`; `Total = "$0.00"` formateado |
| Recálculo | `TextChanged` de sub/anticipo/envío | `OnSubtotal/Anticipo/CostoEnvioChanged` (con el envío tecleado) |
| Guardar | `UPDATE … WHERE Id = @id` con el decimal parseado | `Actualizar(encargo)` con `Id`, `0` en vacíos y `FechaEntrega.Date` |
| Rol Empleado | Deshabilita cliente, contacto, tipo, envío, montos y total; deja descripción y fecha | `PuedeEditarPedido` para esos mismos campos |
| Mensajes | "Error al cargar los datos…" / "Ocurrió un error al guardar…" / "Pedido actualizado correctamente." | Mismos textos vía `SolicitaError` / `PedidoActualizado`; títulos los pone la vista |

### Diferencias deliberadas
- **Bug del costo de envío corregido**: ya no se pisa `txtEnv` con el Id de la
  opción; se guarda el costo tecleado, como en FmNuevoPedido (decisión de la dueña).
- **Validación añadida**: el original guardaba sin validar; C6 reutiliza los
  criterios de C4-1a para no dejar un pedido con campos vacíos.
- **Detalle inexistente** → aviso y cierre en lugar de dejar la ventana vacía.
- El total se conserva como `decimal` (`totalPed`) y se guarda tal cual, sin
  reparsear el texto con `$` (el original también usaba `totalPed`).

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias**.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C6-1b**: prueba funcional con harness temporal (`--test-editar-pedido-vm`):
  carga completa, bloqueo por rol, total en vivo, UPDATE verificado y BD limpia.

---

## Paso C6-1b — Prueba funcional de EditarPedidoViewModel  ✅ COMPLETADO (2026-11-15)

**Objetivo**: ejercitar el ViewModel de C6-1a contra la BD real (carga, validaciones,
total en vivo, UPDATE y rol) antes de construir la ventana (C6-2).

### Implementado

| Archivo | Contenido |
|---|---|
| `MyCrochetWpf/SmokeEditarPedidoViewModel.cs` | Harness temporal: siembra un pedido, prueba el VM con rol admin y empleado, verifica la BD y limpia las filas `SMOKE-C6-1B`; **eliminado** |
| `App.xaml.cs` | Sin cambios permanentes (rama `--test-editar-pedido-vm` eliminada) |
| `ViewModels/EditarPedidoViewModel.cs` | **Sin cambios**: la prueba confirmó el comportamiento implementado en C6-1a |

### Cobertura de la prueba (58/58)
1. Catálogos sin "Todos" (3 tipos, 4 envíos) y carga completa: cliente, contacto,
   tipo Amigurumi, fecha 10/02/2027, descripción, subtotal 400.00, anticipo 100.00,
   costo de envío 60.00 y opción Estafeta.
2. **Total inicial = `PrecioFinal`** ($350.00 aunque la fórmula diera $360.00),
   igual que el WinForms; sin error ni cierre al cargar.
3. **Guardado sin tocar montos**: conserva `PrecioFinal` (350.00) y el estado
   "En Proceso" (el UPDATE no toca `EstadoId`).
4. Recarga y **total en vivo**: subtotal 500 → `$460.00`; cambiar la opción de
   envío **no pisa** el costo de 60.00 (decisión C6).
5. **Siete validaciones** con el texto de C4-1a, todas sin ejecutar el UPDATE:
   cliente vacío, tipo, envío, fecha y los tres montos inválidos.
6. **Guardado completo**: cliente, contacto, tipo Animal, descripción, fecha
   20/03/2027, subtotal 500, envío 60, anticipo 100 → total `460.00`; verificado
   campo por campo con `ObtenerPorId`, incluido `OpcionEnvioId` y estado intacto.
7. **Rol Empleado**: `PuedeEditarPedido = false` (la vista deshabilitará los campos
   y dejará Descripción y Fecha habilitadas).
8. **Id inexistente**: mensaje "Error al cargar los datos." y cierre solicitado.
9. BD limpia al iniciar y al terminar (0 filas `SMOKE-C6-1B`).

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores, 0 advertencias** (harness retirado).
- [x] Prueba funcional → **58/58 aserciones correctas**.
- [x] La primera corrida (56/58) falló por dos supuestos del propio harness (montos
      ya modificados antes de probar la conservación de `PrecioFinal` y falta de
      suscripción al evento en la segunda instancia); se corrigió el harness sin
      tocar el ViewModel.
- [x] Harness temporal y reporte `editar_pedido_vm.txt` eliminados; build final
      repetido.
- [x] El proyecto WinForms original permanece intacto.

### Pendiente para pasos siguientes
- **C6-2a**: `Views/EditarPedidoWindow.xaml(.cs)` 410×510 con título "Editar
  Pedido", campos editables, combos, DatePicker y botón "Guardar cambios".
