# Sitrep

A Linear-like issue tracking application built with .NET 10, ASP.NET Core Identity, EF Core, and a React/Vite frontend.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org)
- [Docker](https://www.docker.com)

---

## 1. Start the Database

Run a PostgreSQL container with a named volume for persistence. The `--restart unless-stopped` flag means it will start automatically when Docker starts (i.e. on host reboot).

```bash
docker run -d \
  --name sitrep-postgres \
  --restart unless-stopped \
  -e POSTGRES_USER=sitrep \
  -e POSTGRES_PASSWORD=sitrep_password \
  -e POSTGRES_DB=sitrepdb \
  -v sitrep-postgres-data:/var/lib/postgresql/data \
  -p 5432:5432 \
  postgres:17
```

To verify it's running:

```bash
docker ps --filter name=sitrep-postgres
```

---

## 2. Configure the Connection String

Store the connection string in [user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) so it never gets committed to source control.

```bash
# Initialise user secrets for the API project (only needed once)
dotnet user-secrets init --project Sitrep.ApiService

# Set the connection string
dotnet user-secrets set \
  "ConnectionStrings:postgres" \
  "Host=localhost;Port=5432;Database=sitrepdb;Username=sitrep;Password=sitrep_password" \
  --project Sitrep.ApiService
```

User secrets are automatically loaded by ASP.NET Core when `ASPNETCORE_ENVIRONMENT=Development` (the default when running locally).

---

## 3. Run the API

Migrations are applied automatically on startup.

```bash
dotnet run --project Sitrep.ApiService
```

---

## 4. Run the Frontend

```bash
cd frontend
npm install
npm run dev
```

---

## Adding EF Core Migrations

```bash
dotnet ef migrations add <MigrationName> \
  --project Sitrep.Data \
  --startup-project Sitrep.ApiService
```

---

## Test Credentials (ASP.NET Core Identity)

Use the `/register` endpoint to create users. The Identity API endpoints are available at:

| Endpoint | Method | Description |
|---|---|---|
| `/register` | POST | Create a new account |
| `/login` | POST | Sign in, returns a bearer token |
| `/refresh` | POST | Refresh an access token |
| `/logout` | POST | Sign out |

---

## Tech Stack

| Layer | Technology |
|---|---|
| API | .NET 10, ASP.NET Core |
| Auth | ASP.NET Core Identity |
| ORM | EF Core 10 + Npgsql |
| Database | PostgreSQL 17 |
| Frontend | React 19, TypeScript, Vite 8 |
| Routing | TanStack Router |
| UI | Tailwind CSS, Shadcn UI |