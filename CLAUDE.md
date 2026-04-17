# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What is Sitrep?

A Linear-like issue tracking application built with .NET, EF Core, ASP.NET Core Identity, and a React/Vite frontend. Each service is run manually.

## Build & Run Commands

```bash
# Run the API
dotnet run --project Sitrep.ApiService

# Run backend tests (xUnit integration tests)
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

Each service is started manually — there is no orchestrator.

**Sitrep.ApiService** — ASP.NET Core API with ASP.NET Core Identity for authentication and authorization. Connects directly to PostgreSQL.

**Sitrep.Data** — EF Core layer with `AppDbContext`. 25 entities modeling workspaces, teams, projects, issues, cycles, comments, notifications, etc. Key conventions:
- GUIDs as PKs, soft deletes via `ArchivedAt` with global query filters
- `CreatedAt`/`UpdatedAt` auto-set in `SaveChangesAsync` override
- Enums stored as text, metadata/filter fields as JSON columns
- Entity configurations in `Sitrep.Data/Configurations/` using `IEntityTypeConfiguration<T>`

**Frontend** — React/Vite SPA communicating with the API.

## Tech Stack

- .NET 10, ASP.NET Core, EF Core 10 + Npgsql
- ASP.NET Core Identity for auth
- React 19, TypeScript, Vite 8, ESLint + Prettier
- PostgreSQL

## Other resources
Please reference the TechStack.md file in the root of this repository.
