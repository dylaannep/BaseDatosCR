# Base de Datos de Provincias, Cantones y Distritos de Costa Rica
Este proyecto consiste en una aplicación de consola desarrollada con C# y .NET 8.0 que utiliza Entity Framework Core con la estrategia **Code First**, para crear una base de datos relacional sobre la división territorial de Costa Rica (Provincias, Cantones y Distritos). El programa también permite generar archivos CSV con los datos correspondientes a cada cantón seleccionado.

## 🧑‍💻 Autor

- **Estudiante:** Dylan Andrés Espinoza Pereira  
- **Carné:** FH23013870  
- **Profesor:** Luis Andrés Rojas Matey  
- **Universidad:** Fidélitas  
- **Curso:** Programación Avanzada en Web  
- **Año:** 2025 

## 📁 Archivos del Proyecto
- **Program.cs**: Punto de entrada principal de la aplicación. Contiene la lógica de lectura del CSV, verificación de datos y generación de archivos CSV.
- **Models/**: Carpeta que contiene las clases `Provincia.cs`, `Canton.cs` y `Distrito.cs` con sus relaciones y anotaciones para PK y FK.
- **Models/CRContext.cs**: Clase que extiende `DbContext` y configura la base de datos, incluyendo nombres de columnas personalizados usando Fluent API.
- **data/CR.csv**: Archivo CSV que contiene los datos originales de provincias, cantones y distritos.
- **data/CR.db**: Base de datos SQLite generada automáticamente.
- **TP4.sln**: Archivo de solución de .NET.
- **Tarea4DylanEspinozaPereira.csproj**: Archivo de configuración del proyecto.


## 🌐 Enlace al repositorio

[GitHub - dylaannep/BaseDatosCR](https://github.com/dylaannep/BaseDatosCR)


## 🔍 Fuentes de consulta
- https://learn.microsoft.com/en-us/ef/core/
- https://www.youtube.com/watch?app=desktop&v=lnOFMKKsaE8

## 🤖 Prompts y respuestas de IA utilizadas

**¿Qué es mejor para definir claves foráneas: Fluent API o anotaciones?**  
✔️ Es común usar `[ForeignKey]` por simplicidad y claridad directa en el modelo.

## 📦 Comandos .NET utilizados
- dotnet new sln -n TP4
- dotnet new console -o Tarea4DylanEspinozaPereira
- dotnet sln add Tarea4DylanEspinozaPereira
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.Sqlite
- dotnet ef migrations add InitialCreate
- dotnet ef database update
- dotnet run