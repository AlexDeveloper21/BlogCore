# BlogCore

BlogCore es una aplicación de blog desarrollada en **ASP.NET Core** que implementa el patrón de diseño **Repository Pattern** y sigue una arquitectura en **capas**. La aplicación utiliza la metodología **Code First** con **migraciones** para gestionar la base de datos y proporciona funcionalidades CRUD completas.

## Tecnologías y Dependencias

Este proyecto utiliza las siguientes dependencias de .NET:

- **Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (8.0.10)**
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.10)**
- **Microsoft.AspNetCore.Identity.UI (8.0.10)**
- **Microsoft.EntityFrameworkCore.Relational (8.0.10)**
- **Microsoft.EntityFrameworkCore.Sqlite (8.0.10)**
- **Microsoft.EntityFrameworkCore.SqlServer (8.0.10)**
- **Microsoft.EntityFrameworkCore.Tools (8.0.10)**
- **Microsoft.VisualStudio.Web.CodeGeneration.Design (8.0.6)**

## Características

- Implementación de operaciones **CRUD** para gestionar las publicaciones del blog.
- **Repository Pattern** para separación de lógica de acceso a datos.
- **Arquitectura en Capas**, con clases organizadas por responsabilidad (Main, AccesoDatos, Models, Utilidades).
- **Migraciones y Code First** para configuración de la base de datos.
- **Identity** para la gestión de usuarios (log in y register)

## Instalación

1. Clona el repositorio:
   `git clone https://github.com/AlexDeveloper21/BlogCore.git`
2. Navega al directorio del proyecto:
`cd BlogCore`
3. Configura la base de datos en appsettings.json y aplica las migraciones:
`dotnet ef database update`
4. Ejecuta el proyecto:
`dotnet run`

Accede a la interfaz web para gestionar las publicaciones del blog con funcionalidades CRUD. La aplicación está diseñada para ser extensible.

Estructura del Proyecto
Capas: Estructura en capas mediante librerías de clases, promoviendo modularidad.
Repository Pattern: Abstracción para el acceso a datos sin acoplamiento.
Contribuciones
Las contribuciones son bienvenidas. Por favor, sigue los lineamientos del proyecto y realiza pruebas antes de enviar cambios.
