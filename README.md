 <p align="left">
  <img src="wwwroot/images/stockpilot-logo.png" alt="StockPilot" width="300">
</p>

**Sistema de gestión de inventario desarrollado con C# y ASP.NET Core.**

StockPilot es una aplicación web para gestionar productos e inventario de forma sencilla. Permite registrar productos, consultar existencias, actualizar información y controlar los niveles de stock.

## Funcionalidades

- **Gestión de productos:** crear, consultar, editar y eliminar productos.
- **Control de existencias:** consultar las unidades disponibles de cada producto.
- **Stock mínimo:** identificar productos cuyo inventario necesita atención.
- **Validación de datos:** comprobar campos obligatorios, precios y cantidades.
- **Control de SKU:** evitar códigos de producto duplicados.
- **Panel de resumen:** visualizar información general del inventario.
- **Interfaz web:** diseño sencillo y adaptable para gestionar los productos.

## Tecnologías utilizadas

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- HTML
- CSS
- JavaScript
- Git y GitHub

## Requisitos previos

Para ejecutar el proyecto en tu ordenador necesitas:

- .NET SDK compatible con el proyecto.
- Visual Studio Code u otro editor compatible.
- Una terminal, como PowerShell.

## Cómo ejecutar el proyecto

1. Clona este repositorio:

   ```bash
   git clone https://github.com/16-aurora/StockPilot.git
   ```

2. Entra en la carpeta del proyecto:

   ```bash
   cd StockPilot
   ```

3. Ejecuta la aplicación:

   ```bash
   dotnet run
   ```

4. Abre en el navegador la dirección local que indique la terminal. En la configuración de desarrollo actual, puede ser:

   `http://localhost:5020`

La base de datos SQLite se utiliza para almacenar los productos. La aplicación puede crear su base de datos local al iniciarse, según la configuración del proyecto.

## Estructura del proyecto

```text
StockPilot.Api/
├── Data/
│   └── AppDbContext.cs
├── Endpoints/
│   └── ProductsEndpoints.cs
├── Models/
│   └── Product.cs
├── wwwroot/
│   ├── images/
│   │   └── stockpilot-logo.png
│   └── index.html
├── Program.cs
├── StockPilot.Api.csproj
├── .gitignore
└── README.md
```

## Mejoras futuras

Algunas posibles mejoras para futuras versiones:

- Incorporar autenticación y gestión de usuarios.
- Añadir búsquedas, filtros y ordenación de productos.
- Registrar movimientos de entrada y salida de inventario.
- Implementar alertas de stock bajo.
- Añadir pruebas automatizadas.
- Mejorar los informes y las estadísticas del inventario.

## Autora

Proyecto personal desarrollado como parte de mi aprendizaje de desarrollo de aplicaciones web con C# y .NET.

---

**StockPilot** — Gestión de inventario sencilla y eficiente.