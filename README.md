# Test de conocimientos C#

Un reclutador necesita administrar una base de candidatos de un proceso selectivo. Utilizando de base el modelo relacional representado encima, desarrolla una aplicación web utilizando arquitectura MVC que permita al reclutador realizar las siguientes acciones:

- Consultar una lista de candidatos inscritos.
- Inscribir nuevos candidatos y sus experiencias profesionales.
- Editar la inscripción de un candidato y sus experiencias profesionales.
- Eliminar un candidato.

## Requisitos

- Utiliza .Net Core.
- Utiliza Entity Framework como ORM para las consultas y persistencia de datos.
- Desarrolla la aplicación utilizando de base el modelo relacional mostrado al inicio de este documento.
- Desarrolla el modelo de entidades utilizando Code-First con Entity Framework.
- Utiliza SQL in-memory o SQL Express (localdb)
- No pongas el foco en Frontend, lo importante es el Backend!
## Consejos
- Procura utilizar tus conocimientos y buenas prácticas de OOP, DDD, SOLID e Clean Code.
- En caso de tener conocimiento del patrón arquitectural CQRS, utilízalo!
- Nuestro objetivo es conocer tu estilo de programación, aquí no existe correcto o incorrecto.
- Y principalmente, diviértete!

# Estructura de entregable

## Application

- Implementación del patrón CQRS
- Comandos y consultas
- Handlers de los comandos y consultas
- DTOs (Data Transfer Object) y Mappings

## Controllers

- Controladores MVC
- Gestión de acciones del portal

## Domain

- Entidades principales:
  - Candidate
  - CandidateExperience
- Interfaces

## Infrastructure

- Contexto de Entity Framework Core
- Configuraciones de entidades
- Seeding de datos iniciales

## Migrations

- Historial de migraciones de base de datos
- Scripts de creación de esquema

## Views

- Vistas Razor
- Validaciones de lado del cliente

# Tecnologías Utilizadas
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- MediatR
- Bootstrap

# Patrones de Diseño
- CQRS (Command Query Responsibility Segregation)
- Mediator Pattern (usando MediatR)
- Repository Pattern (Separando la capa de datos de la lógica)
- Clean Architecture

# Instalación y Configuración

1. Clonar el repositorio
2. Actualizar la cadena de conexión en `appsettings.json` (Si se requiere)
3. Ejecutar las migraciones:
```powershell
dotnet ef database update
```
