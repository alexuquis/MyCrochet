# FASE_A.md — Esqueleto y recursos

Detalle de ejecución de la Etapa A. Un paso = una sesión de agente.

---

## Paso A1 — Esqueleto del proyecto WPF  ✅ COMPLETADO (2026-11-06)

**Objetivo**: proyecto `MyCrochetWpf` que compila dentro de la solución y abre una ventana vacía.

### Tareas
- [x] Crear `../MyCrochetWpf/` (hermana de `../MyCrochet/`, dentro de la solución).
- [x] Crear `MyCrochetWpf.csproj`:
  - `TargetFramework`: `net8.0-windows`
  - `OutputType`: `WinExe`, `UseWPF`: `true` (sin WinForms)
  - `Nullable` / `ImplicitUsings`: `enable`
  - `EnableWindowsTargeting`: `true` (permite build desde WSL)
  - Paquetes reservados para la Fase B: `CommunityToolkit.Mvvm 8.4.0`,
    `Microsoft.Data.Sqlite 9.0.0`
- [x] `App.xaml` + `App.xaml.cs` con `StartupUri="MainWindow.xaml"`.
- [x] `MainWindow.xaml` + `.xaml.cs` con `Background="#FFF7F8"` y placeholder
      "MyCrochet" en tinto `#861940`.
- [x] `AssemblyInfo.cs` con `ThemeInfo`.
- [x] Agregar a `../MyCrochet.sln`.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → **0 errores** (168 warnings preexistentes del
      proyecto WinForms, ninguno del proyecto nuevo).
- [x] Proyecto WinForms compila igual que antes (no se tocó ningún archivo suyo).
- [x] Binario generado: `MyCrochetWpf/bin/Debug/net8.0-windows/MyCrochetWpf.exe`.
- [ ] Abrir el `.exe` en Windows y ver la ventana en blanco hueso (verificación visual
      que debe hacerse en Windows; pendiente de confirmación de la dueña).

### Exclusiones respetadas
- No se creó `mycrochet.db`, no se usó SQLite, no se migró ninguna pantalla,
  no se modificó el proyecto WinForms.

---

## Paso A2 — Recursos corporativos  ✅ COMPLETADO (2026-11-06)

**Objetivo**: assets e identidad visual cargados en WPF, listos para las pantallas.

### Tareas
- [x] Crear estructura: `MyCrochetWpf/Assets/`, `MyCrochetWpf/Assets/Gifs/`,
      `MyCrochetWpf/Fonts/`, `MyCrochetWpf/Themes/`.
- [x] **Copiar** (no mover, el WinForms queda intacto):
  - PNG de `RecursosMyCrochet/` → `Assets/`
  - `fondologin.gif` + `AnimacionesFinal/*` → `Assets/Gifs/`
  - Fuentes de `RecursosMyCrochet/` y `fuentes/` → `Fonts/`
- [x] Registrar assets y fuentes como `<Resource>` en el csproj
      (`Assets\**\*` y `Fonts\**\*`).
- [x] `Themes/Colores.xaml`:
  - `FondoCrema` `#FFF7F8`, `RosaDetalle` `#FEA9BE`, `TintoAcento` `#861940`.
  - Estilo `BotonRosa` (fondo rosa, hover tinto, esquinas redondeadas 18 px).
  - Fusionado en `App.xaml` con `MergedDictionaries`.
- [x] `Themes/Fuentes.xaml` con `FontFamily` empaquetadas:
  - `FuenteAdelia`, `FuenteComfortaa`, `FuenteGoodBakwan`,
    `FuenteKGPerfect`, `FuenteKGRedHands`, `FuenteSuperMindset`.
  - Estilos `TextoTitulo` (ADELIA 42), `TextoSubtitulo` (Good Bakwan 24),
    `TextoCuerpo` (Comfortaa 16). Sin color fijo: el color lo pone cada vista.
- [x] `MainWindow.xaml` demo: imagen `log2.png`, título ADELIA en tinto,
      subtítulo Comfortaa y botón rosa con hover.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → 0 errores, 0 advertencias del proyecto WPF.
- [x] Recursos verificados dentro de `MyCrochetWpf.dll` (fuentes y assets
      aparecen en el stream `g.resources`).
- [x] Smoke test runtime: el `.exe` arranca y se mantiene vivo (cierre forzado
      a los 4 s). Si una fuente o imagen no resolviera, habría crasheado al cargar.
- [ ] Confirmación visual fina de la dueña (colores/tipografías a gusto).

### Decisión sobre GIFs (cierre de A2)
WPF **no anima GIFs nativamente**. Por ahora los 8 GIFs quedan empaquetados como
recurso estático (se verá el primer frame). La animación real se decide en la
**Fase C, antes de migrar el Login**:
- Opción 1: paquete `XamlAnimatedGif` (simple, mantiene GIFs originales).
- Opción 2: player code-behind con `WpfAnimatedGif`/`ImageAnimator`.
- Opción 3: convertir a APNG/WebP animado.
Recomendación inicial: Opción 1 solo para el Login y la pantalla de inicio.

### Exclusiones respetadas
- No se animaron GIFs, no se agregaron paquetes fuera de los 2 ya declarados,
  no se migró ninguna pantalla.

---

## Notas de entorno
- Build desde WSL con el SDK de Windows:
  `"/mnt/c/Program Files/dotnet/dotnet.exe" build MyCrochet.sln`
  (desde `../`, la carpeta de la solución).
- SDK usado: .NET 9.0.317 construyendo target `net8.0-windows`; runtimes
  `Microsoft.WindowsDesktop.App 8.0.30` y `9.0.19` presentes.
