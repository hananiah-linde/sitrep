# SitRep — Tech Stack

> SitRep is an issue tracking app built as a learning project and YouTube series. The goal is to build a Linear-like experience using modern, production-grade tooling.

---

## Backend

| Tool | Purpose |
|------|---------|
| **.NET 10** | REST API (ASP.NET Core) |
| **Entity Framework Core** | ORM for data access and migrations |
| **ASP.NET Core Identity** | Authentication and authorization |
| **SignalR** | Real-time communication (live issue updates, notifications) |

---

## Database

| Tool | Purpose |
|------|---------|
| **PostgreSQL** | Primary relational database |

---

## Frontend

| Tool | Purpose |
|------|---------|
| **TanStack Router** | Type-safe, file-based SPA routing |
| **Vite** | Build tool and dev server |
| **React** | UI library |
| **Tailwind CSS** | CSS framework |
| **TypeScript** | Static type checking |
| **ESLint** | Static analysis |
| **Prettier** | Code formatting |
| **Shadcn UI** | React component library |

---

## Summary

```
┌──────────────────────────────────────┐
│  Frontend       API          DB      │
│  TanStack  ──▶  .NET 10  ──▶ Postgres│
│  Router/Vite    EF Core              │
│                 Identity             │
│                 SignalR              │
└──────────────────────────────────────┘
```
