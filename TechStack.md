# SitRep — Tech Stack

> SitRep is an issue tracking app built as a learning project and YouTube series. The goal is to build a Linear-like experience using modern, production-grade tooling — all running locally via .NET Aspire.

---

## Orchestration

| Tool | Purpose |
|------|---------|
| **Aspire** | Local orchestration of all services — provides a production-like experience (service discovery, dashboard, health checks, telemetry) without cloud hosting |

---

## Backend

| Tool | Purpose |
|------|---------|
| **.NET 10** | REST API (ASP.NET Core) |
| **Entity Framework Core** | ORM for data access and migrations |
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

---

## Auth

| Tool | Purpose |
|------|---------|
| **Keycloak** | Identity and access management (OIDC/OAuth2) — containerized and managed by Aspire |

---

## Summary

```
┌──────────────────────────────────────────┐
│              .NET Aspire                 │
│  ┌───────────┐  ┌──────────┐  ┌────────┐ │
│  │ Frontend  │  │   API    │  │  DB    │ │
│  │TanStack   │─▶│ .NET 10  │─▶│Postgres│ │
│  │Router/Vite│  │  EF Core │  └────────┘ │
│  └───────────┘  │  SignalR │  ┌────────┐ │
│                 └──────────┘  │Keycloak│ │
│                               └────────┘ │
└──────────────────────────────────────────┘
```