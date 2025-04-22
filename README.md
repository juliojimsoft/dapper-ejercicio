# dapper-ejercicio

## Configurar conexion base de datos

Este es un proyecto de ejemplo usando Dapper, un micro-ORM para .NET.

## Requisitos Previos

- SQL Server 2016+
- .NET 8 o superior
- Git (para clonación)

## Funcionalidades

- Conexión a base de datos.
- Consultas SQL mapeadas a objetos.
- Ejemplos de CRUD.

## Uso

```bash
git clone https://github.com/juliojimsoft/dapper-ejercicio.git
cd dapper-ejercicio


Crear la base de datos en SQL Server, Ejecutar en SQL Server Management Studio:
CREATE DATABASE api_v1;

## Instalación
Configuración de la Conexión
Modifica tu archivo appsettings.json con o configurar variables de entorno:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=servidorhost;Database=api_v1;User Id=usuario;Password=password;TrustServerCertificate=True;"
  }
}

##Reconstruir la base de datos con Entity Framework code first:
dotnet ef database update

```
