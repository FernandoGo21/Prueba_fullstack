# Prueba Técnica – Desarrollador (.NET + Framework Frontend)

Este proyecto es una aplicación web que consume datos de dos APIs públicas (**Cat Facts** y **Giphy**) a través de un backend en **.NET 8**, mostrando resultados en una interfaz desarrollada con **Angular**.

## 📌 Estructura del repositorio
/GodoyTest/ <-- Proyecto principal ASP.NET Core (contiene frontend embebido en wwwroot)
/front-app/ <-- Código fuente del frontend Angular
README.md <-- Este archivo

## 🧠 Descripción funcional

- Al cargar la app, se consulta un dato aleatorio desde `https://catfact.ninja/fact`.
- Se extraen las primeras 3 palabras y se realiza una búsqueda en Giphy con la API Key dada.
- El GIF retornado junto con el texto se muestra en la interfaz.
- Cada búsqueda se guarda en base de datos con:
  - Fecha
  - Texto completo del catfact
  - Las tres palabras usadas
  - URL del gif
- Existe una pestaña secundaria para ver el historial completo de búsquedas anteriores.

---

## ⚙️ Tecnologías utilizadas

- **Backend:** ASP.NET Core 8.0
- **Frontend:** Angular 17 (compilado dentro del proyecto backend)
- **Base de datos:** SQL Server
- **Consumo de APIs externas:** `https://catfact.ninja/fact` y Giphy Search

---

## 🚀 Cómo ejecutar el proyecto

### Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js + Angular CLI (opcional, si se desea modificar el frontend)](https://angular.io/cli)
- Instancia de **SQL Server** (local o remota)

---

### 1️⃣ Configurar base de datos

1.  Clona el repositorio
```bash
    git clone https://github.com/FernandoGo21/Prueba_fullstack.git
    cd GodoyTest
```
2.  Crea una base de datos llamada `GodoyTestDb`:
```sql
    CREATE DATABASE GodoyTestDb;
```
3.  Abre el archivo appsettings.json y ajusta la cadena de conexión
```c#
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=GodoyTestDb;User Id=sa;Password=YourStrong!Passw0rd;"
    }
```
4.  Ejecuta las migraciones de Entity Framework para crear automáticamente sus tablas
```bash
    dotnet ef database update
```
-   Nota: Si no tienes instalado dotnet-ef, puedes agregarlo con:
```bash
    dotnet tool install --global dotnet-ef
```

3. Ejecuta la aplicación
```bash
    dotnet run
```
4. La app estará disponible en:
    https://localhost:7065
5. Y la documentación Swagger en:
    https://localhost:7065/swagger

📌 Notas Finales
El frontend fue compilado y embebido en el backend en wwwroot, sin embargo el codigo del frontend se encuentra en la carpeta de front-app
   

