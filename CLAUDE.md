# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What is Sitrep?

A Linear-like issue tracking application built with .NET Aspire, EF Core, Keycloak, and a React/Vite frontend. All services are orchestrated locally via Aspire's AppHost.

## Build & Run Commands

```bash
# Run the full stack (AppHost orchestrates all services)
dotnet run --project Sitrep.AppHost

# Run backend tests (xUnit integration tests using Aspire.Hosting.Testing)
dotnet test --project Sitrep.Tests

# Add an EF Core migration (from repo root)
dotnet ef migrations add <MigrationName> --project Sitrep.Data --startup-project Sitrep.ApiService

# Frontend (from frontend/ directory)
npm run dev        # Vite dev server
npm run build      # TypeScript check + Vite production build
npm run lint       # ESLint
```

Migrations auto-apply on API startup — no manual `dotnet ef database update` needed.

## Architecture

**Aspire AppHost** (`Sitrep.AppHost/AppHost.cs`) orchestrates the dependency graph:
- **Keycloak** (OIDC provider) — realm config imported from `Sitrep.AppHost/KeycloakConfiguration/sitrep-realm.json`
- **PostgreSQL** + PgAdmin — database `sitrepdb`
- **API Service** — waits for Keycloak + Postgres; health check at `/health`
- **Frontend** (Vite) — waits for API; external HTTP endpoints enabled

**Sitrep.ServiceDefaults** — shared extensions for OpenTelemetry, health checks (`/health`, `/alive`), service discovery, and HTTP resilience. All services call `AddServiceDefaults()`.

**Sitrep.Data** — EF Core layer with `AppDbContext`. 25 entities modeling workspaces, teams, projects, issues, cycles, comments, notifications, etc. Key conventions:
- GUIDs as PKs, soft deletes via `ArchivedAt` with global query filters
- `CreatedAt`/`UpdatedAt` auto-set in `SaveChangesAsync` override
- Enums stored as text, metadata/filter fields as JSON columns
- Entity configurations in `Sitrep.Data/Configurations/` using `IEntityTypeConfiguration<T>`

**Sitrep.ApiService** — ASP.NET Core API with JWT Bearer auth against Keycloak (`sitrep` realm, `sitrep-api` audience).

## Keycloak Test Credentials

- admin@sitrep.local / admin (admin + user roles)
- testuser@sitrep.local / testuser (user role)
- Frontend client: `sitrep-frontend` (public, PKCE)
- API client: `sitrep-api` (bearer-only, secret: `sitrep-api-secret`)

## Tech Stack

- .NET 10, ASP.NET Core, EF Core 10 + Npgsql, .NET Aspire 13.2
- React 19, TypeScript, Vite 8, ESLint + Prettier
- PostgreSQL, Keycloak (containerized via Aspire)
- xUnit + Aspire.Hosting.Testing for integration tests

## Other resources
Please reference the TechStack.md file in the root of this repository.