# FASE_B.md — Capa de datos (SQLite)

Detalle de ejecución de la Etapa B. Un paso = una sesión de agente.
Decisiones cerradas con la dueña (2026-11-06):

- Columnas con `ñ` se conservan tal cual (`Contraseña`, `Tamaño`).
- FKs activas: `PRAGMA foreign_keys = ON` en cada conexión.
- Repositorios devuelven **entidades tipadas** (no `DataTable`).
- Seed mínimo al crear la BD: catálogos + un usuario admin.
- Dialecto: `+` de SQL Server → `||` en SQLite; fechas como `TEXT` ISO 8601.

---

## Paso B1 — Infraestructura de conexión  ✅ COMPLETADO (2026-11-06)

**Objetivo**: acceso centralizado a SQLite y creación del archivo al primer arranque.

### Implementado
- `MyCrochetWpf/Data/Db.cs`:
  - `DatabasePath` = `AppContext.BaseDirectory/mycrochet.db` (junto al ejecutable).
  - `ConnectionString` con `SqliteOpenMode.ReadWriteCreate`.
  - `OpenConnection()` abre la conexión y ejecuta `PRAGMA foreign_keys = ON`.
  - `EnsureDatabase()` garantiza la creación del archivo.
- `App.xaml.cs`: `Db.EnsureDatabase()` en `OnStartup`.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → 0 errores.
- [x] Smoke test: el `.exe` arranca y permanece vivo (cierre forzado a los 4 s).
- [x] `mycrochet.db` creado en `bin/Debug/net8.0-windows/` al arrancar.
- [x] Archivo validado como SQLite (sin tablas todavía; eso es B2).

---

## Paso B2 — Esquema + seed mínimo  ✅ COMPLETADO (2026-11-06)

**Objetivo**: crear las 9 tablas con `CREATE TABLE IF NOT EXISTS` y sembrar datos mínimos.

### Fuente del esquema
Se consultó `CrochetDB` real en `DESKTOP-HAPVSMC\SQLEXPRESS` en modo **solo lectura**
(`INFORMATION_SCHEMA.COLUMNS` y SELECT de catálogos), así que el DDL refleja los tipos
y `NOT NULL` reales, no solo lo inferido de las queries.

### Esquema creado (`MyCrochetWpf/Data/Schema.cs`)
| Tabla | Columnas / tipo |
|---|---|
| `Generos` | `Id` PK, `Genero` TEXT NOT NULL |
| `Roles` | `Id` PK, `Rol` TEXT NOT NULL |
| `Usuarios` | `Id` PK, `Nombre` TEXT NOT NULL, `GeneroId` INTEGER NOT NULL FK, `RolesId` INTEGER NOT NULL FK, `Contraseña` TEXT NOT NULL |
| `Categorias` | `Id` PK, `Categoria` TEXT NOT NULL |
| `Articulos` | `Id` PK, `CategoriaId` INTEGER NOT NULL FK, `Inventario` INTEGER, `Tamaño` TEXT NOT NULL, `Color` TEXT NOT NULL, `Precio` REAL NOT NULL, `Modelo` BLOB, `Marca` TEXT |
| `TipoPedidos` | `Id` PK, `Nombre` TEXT NOT NULL |
| `Estados` | `Id` PK, `Estado` TEXT NOT NULL |
| `OpcionesEnvio` | `Id` PK, `Nombre` TEXT NOT NULL |
| `Encargos` | `Id` PK, `Cliente` TEXT NOT NULL, `TipoPedidoId` INTEGER NOT NULL FK, `DescripcionPersonalizada` TEXT, `PrecioFinal` REAL NOT NULL, `FechaEntrega` TEXT NOT NULL, `EstadoId` INTEGER NOT NULL FK, `OpcionEnvioId` INTEGER FK, `CostoEnvio` REAL, `Subtotal` REAL, `Anticipo` REAL, `Contacto` TEXT |

Nota: `Articulos.Modelo BLOB` existe en CrochetDB y no lo usa ninguna query; se conserva.

### Seed (solo si la tabla está vacía; valores reales de CrochetDB)
- Géneros: Femenino, Masculino, Prefiero no decirlo (Id 1–3).
- Roles: Administrador, Empleado (Id 1–2).
- Categorías: Estambre, Empaque, Accesorios (Id 1–3).
- Tipos de pedido: Amigurumi, Animal, Flores (Id 1–3).
- Estados: Pendiente, En Proceso, Completado, Cancelado (Id 1–4).
- Opciones de envío: Entrega personal, Estafeta, DHL, Ninguna (Id 1–4).
- Usuario inicial: **`admin` / `admin`** (Género 1, Rol 1). Cambiar desde Configuración.

### Implementado
- `Schema.EnsureCreated()` con DDL idempotente y seed transaccional.
- `App.OnStartup` llama `EnsureDatabase()` → `EnsureCreated()` → ventana.

### Verificación (DoD)
- [x] `dotnet build MyCrochet.sln` → 0 errores.
- [x] Las 9 tablas existen (verificado por `sqlite_master`).
- [x] FKs declaradas y verificadas con `PRAGMA foreign_key_list` (Usuarios y Encargos).
- [x] Seed completo y sin duplicados tras un segundo arranque.
- [x] Archivo recreado desde cero en `bin/Debug/net8.0-windows/mycrochet.db`.

---

## Paso B3 — Entidades  ✅ COMPLETADO (2026-11-06)

9 clases planas en `MyCrochetWpf/Models/`, sin SQL, alineadas con las columnas reales:

| Clase | Propiedades |
|---|---|
| `Usuario` | Id, Nombre, GeneroId, RolesId, Contraseña |
| `Genero` | Id, Nombre → columna `Genero` |
| `Rol` | Id, Nombre → columna `Rol` |
| `Categoria` | Id, Nombre → columna `Categoria` |
| `TipoPedido` | Id, Nombre |
| `Estado` | Id, Nombre → columna `Estado` |
| `OpcionEnvio` | Id, Nombre |
| `Articulo` | Id, CategoriaId, Inventario?, Tamaño, Color, Precio (decimal), Modelo (byte[]?), Marca? |
| `Encargo` | Id, Cliente, TipoPedidoId, DescripcionPersonalizada?, PrecioFinal, FechaEntrega (DateTime), EstadoId, OpcionEnvioId?, CostoEnvio?, Subtotal?, Anticipo?, Contacto? |

Nota: C# no permite una propiedad con el mismo nombre que su clase; por eso los
catálogos usan `Nombre` y el repositorio (B5) mapea la columna real correspondiente.

### DoD
- [x] Build 0 errores.
- [x] Propiedades 1:1 con las columnas (incluidas `Contraseña` y `Tamaño`).

---

## Paso B4 — Repositorio Usuarios  ✅ COMPLETADO (2026-11-06)

`MyCrochetWpf/Data/RepositorioUsuarios.cs` + `Models/UsuarioSesion.cs`.

| Método | Origen | SQL |
|---|---|---|
| `Autenticar(nombre, contrasena)` | `Form1.cs` | `SELECT U.Nombre, U.RolesId, G.Genero ... INNER JOIN Generos ... WHERE Nombre / Contraseña` |
| `Listar()` | `FmUsuarios.cs` | `SELECT Id, Nombre, Contraseña, GeneroId, RolesId FROM Usuarios` |
| `Insertar(usuario)` | `FmNuevoUs.cs` | `INSERT INTO Usuarios (Nombre, GeneroId, RolesId, Contraseña)` |
| `Actualizar(usuario)` | `FmUsuarios.cs` (grid) | `UPDATE ... WHERE Id = @id` — reemplaza `SqlCommandBuilder` |
| `ExisteCredencial(nombre, contra)` | `FmConfiguracion.cs` | `SELECT COUNT(*) ... WHERE Nombre / Contraseña` |
| `ActualizarPerfil(...)` | `FmConfiguracion.cs` | `UPDATE ... WHERE Nombre = @nombreActual` |
| `Eliminar(id)` | `FmUsuarios.cs` | `DELETE FROM Usuarios WHERE Id = @id` |

Notas:
- La columna se escribe `Contraseña` correctamente (en `Form1.cs` aparece con
  mojibake `Contrase�a` por encoding mixto; no se replicó el mojibake).
- `UsuarioSesion` (Nombre, RolId, Genero) alimenta los futuros valores de sesión.
- Todos los comandos son parametrizados y usan `Db.OpenConnection()`.

### Verificación (DoD)
- [x] Build 0 errores.
- [x] SQL validado contra una copia de `mycrochet.db`: login, listar, insertar,
      actualizar por Id, verificar credencial, actualizar perfil y eliminar.

---

## Paso B5 — Repositorio Catálogos  ✅ COMPLETADO (2026-11-06)

`MyCrochetWpf/Data/RepositorioCatalogos.cs`, con un helper privado `Consultar<T>`
(conexión + comando + mapeo) y cinco métodos públicos:

| Método | SQL | Usado por |
|---|---|---|
| `ListarGeneros()` | `SELECT Id, Genero FROM Generos` | FmNuevoUs, FmConfiguracion |
| `ListarRoles()` | `SELECT Id, Rol FROM Roles` | FmNuevoUs, FmConfiguracion |
| `ListarTiposPedido()` | `SELECT Id, Nombre FROM TipoPedidos` | FmNuevoPedido, FmEditarPedido, FmPedidos |
| `ListarEstados()` | `SELECT Id, Estado FROM Estados` | FmNuevoPedido, FmPedidos |
| `ListarOpcionesEnvio()` | `SELECT Id, Nombre FROM OpcionesEnvio` | FmNuevoPedido, FmEditarPedido, FmPedidos |

Mapeo: todos usan la propiedad `Nombre`; las columnas reales `Genero`, `Rol` y
`Estado` se leen por posición en el `SELECT`.

### Verificación (DoD)
- [x] Build 0 errores.
- [x] Los 5 SELECTs ejecutados contra una copia de `mycrochet.db`, devolviendo
      los catálogos reales sembrados en B2.

---

## Paso B6 — Repositorio Artículos + Categorías  ✅ COMPLETADO (2026-11-06)

`MyCrochetWpf/Data/RepositorioArticulos.cs` + proyecciones
`ArticuloInventario`, `MaterialCotizacion` y `ArticuloStockBajo`.

| Método | Origen | SQL |
|---|---|---|
| `Listar(filtro, categoriaId)` | `FmInventario.cs` | JOIN con `Categorias`, `LIKE @filtro` y filtro por categoría |
| `ListarCategorias()` | `FmInventario`/`FmNuevoMaterial`/`FmEditarMaterial` | `SELECT Id, Categoria FROM Categorias` |
| `Insertar(articulo)` | `FmNuevoMaterial.cs` | `INSERT INTO Articulos (CategoriaId, Inventario, Tamaño, Color, Precio, Marca)` |
| `ObtenerPorId(id)` | `FmEditarMaterial.cs` | `SELECT CategoriaId, Inventario, Tamaño, Color, Precio, Marca ... WHERE Id` |
| `Actualizar(articulo)` | `FmEditarMaterial.cs` | `UPDATE Articulos SET ... WHERE Id = @id` |
| `Eliminar(id)` | `FmInventario.cs` | `DELETE FROM Articulos WHERE Id = @id` |
| `ListarParaCotizador()` | `FmCotizador.cs` | `MIN(Id)` + `A.Marca \|\| ' - ' \|\| A.Tamaño` (traducción de `+`) |
| `ListarStockBajo()` | `FmInicio.cs` | `SELECT Marca, Tamaño, Color, Inventario ... WHERE Inventario <= 2` |

Notas:
- `Inventario` y `Marca` admiten NULL → se envían como `DBNull.Value`.
- `ObtenerPorId` no selecciona `Id`; se asigna el parámetro al entity, igual que
  el original (que usaba `idArt` del constructor).
- El filtro del inventario conserva el comportamiento original: `@filtro = ''`
  cuando no hay texto (`'%' + filtro + '%'`).

### Verificación (DoD)
- [x] Build 0 errores.
- [x] SQL validado contra copia de la BD: categorías, insertar, listar (sin filtro,
      con texto y por categoría), obtener por Id, actualizar, cotizador con `||`,
      stock bajo y eliminar.

---

## Paso B7 — Repositorio Encargos  ✅ COMPLETADO (2026-11-06)

`MyCrochetWpf/Data/RepositorioEncargos.cs` + proyecciones `PedidoResumen`,
`EncargoDetalle` y `PedidoPendiente`.

| Método | Origen | SQL |
|---|---|---|
| `Listar(filtro, tipo, estado)` | `FmPedidos.cs` | JOIN `TipoPedidos`/`Estados`; filtros opcionales con `IS NULL` |
| `Insertar(encargo)` | `FmNuevoPedido.cs` | `INSERT` de 11 columnas |
| `ObtenerDetalle(id)` | `FmVerPedido.cs` | `INNER JOIN TipoPedidos` + `LEFT JOIN OpcionesEnvio` |
| `ObtenerPorId(id)` | `FmEditarPedido.cs` | SELECT de 10 columnas (sin `EstadoId`, igual que el original) |
| `Actualizar(encargo)` | `FmEditarPedido.cs` | `UPDATE` de 10 columnas por `Id` (no toca `EstadoId`) |
| `Eliminar(id)` | `FmPedidos.cs` | `DELETE FROM Encargos WHERE Id = @id` |
| `ListarPendientes()` | `FmInicio.cs` | `WHERE EstadoId = 1 ORDER BY FechaEntrega ASC` |

Traducciones de dialecto aplicadas:
- `'%' + @filtro + '%'` → `'%' \|\| @filtro \|\| '%'`.
- `CAST(e.Id AS NVARCHAR)` → `CAST(e.Id AS TEXT)`.
- Parámetros nulos (`tipo`, `estado`, `OpcionEnvioId`, etc.) → `DBNull.Value`.

### Verificación (DoD)
- [x] Build 0 errores.
- [x] SQL validado contra copia de la BD: insertar, listar (todos / texto / por Id /
      tipo / estado / combinado), detalle, obtener para editar, actualizar,
      pendientes y eliminar.
