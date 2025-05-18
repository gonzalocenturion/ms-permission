# Permission

API desarrollada en ASP.NET Core 8.0 siguiendo los principios de **Clean Architecture, aplicando patrones de diseño(DI, Repository, UoW, ROP) y método de extensión)** . El proyecto utiliza tecnologías modernas para mensajería, almacenamiento y monitoreo.

## Estructura del Proyecto 📁

- **SharedKernel**  
  Proyecto con abstracciones y utilidades comunes.

- **Capa de Dominio**  
  Incluye entidades principales, enums e interfaces.

- **Capa de Aplicación**  
  - Implementación de CQRS usando MediatR.
  - Casos de uso.
  - Logging y Validaciones.

- **Capa de Infraestructura**  
  - Kafka.
  - EF Core, Sql Server
  - Implementacion de Interfaces


## Tecnologías Utilizadas 🌐

- **.NET 8**
- **Docker** (para orquestar servicios como Kafka, Elasticsearch, Kibana y SQL Server)
- **Apache Kafka** (mensajería distribuida)
- **Elasticsearch** (almacenamiento y búsqueda de logs)
- **Kibana** (visualización de logs)
- **SQL Server** (base de datos relacional)

## Requisitos 😊

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)

## Instalación 🚀

1. Clona el repositorio: `git clone https://github.com/gonzalocenturion/ms-permission.git`

2. Restaura los paquetes NuGet: `dotnet restore`

3. Levanta los servicios necesarios con Docker: `docker-compose up -d`

## Uso 🧑🏻‍💻

- Accede a la documentación Swagger en: `http://localhost:<your_port>/swagger`. Debes de setear el puerto indicado en la consola.


## Configuración 🔧

- Los servicios de Kafka, Elasticsearch, Kibana y SQL Server se configuran en `docker-compose.yml` dejando el `appsettings.json` lo más limpio posible .

## Mejoras Propuestas 💡

Existen varias oportunidades de mejora y evolución para este proyecto que me gustaria charlarlas. Mi mail es `centurion_gonzalo@hotmail.com` hagamos contacto 😉