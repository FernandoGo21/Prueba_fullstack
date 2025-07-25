# Prueba Técnica – Desarrollador (.NET + Framework Frontend)

Este proyecto es una aplicación web que consume datos de dos APIs públicas (**Cat Facts** y **Giphy**) a través de un backend en **.NET 8**, mostrando resultados en una interfaz desarrollada con **Angular**.

## 📌 Estructura del repositorio
- /GodoyTest/ <-- Proyecto principal ASP.NET Core (contiene frontend embebido en wwwroot)
- /front-app/ <-- Código fuente del frontend Angular
- README.md <-- Este archivo

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
cd Prueba_fullstack
cd GodoyTest
```
2.  Crea una base de datos en SQL Server que se llame `GodoyTestDb`:
```sql
CREATE DATABASE GodoyTestDb;
```
3.  Abre el archivo appsettings.json y ajusta la cadena de conexión segun donde hayas creado la base de datos y segun tus datos de usuario
```c#
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GodoyTestDb;User Id=sa;Password=YourStrong!Passw0rd;"
}
```
4.  Ejecuta las migraciones de Entity Framework para crear automáticamente sus tablas, para este caso usaremos los comandos de dotnet-ef Nota: Si no tienes instalado dotnet-ef, puedes agregarlo con:
```bash
dotnet tool install --global dotnet-ef
```
5. Despues de que tengas instalado dotnet corremos las migraciones para actualizar la base de datos:
```bash
dotnet ef database update
```
6. Ejecuta la aplicación
```bash
dotnet run
```
7. La app estará disponible en:
    https://localhost:7065
8. Y la documentación Swagger en:
    https://localhost:7065/swagger

📌 Notas Finales
El frontend fue compilado y embebido en el backend en wwwroot, sin embargo el codigo del frontend se encuentra en la carpeta de front-app
   

