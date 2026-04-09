var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak", port: 8080)
    .WithDataVolume()
    .WithRealmImport("./KeycloakConfiguration");

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithHostPort(5432)
    .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050));

var sitrepDb = postgres.AddDatabase("sitrepdb");

var apiService = builder.AddProject<Projects.Sitrep_ApiService>("api")
    .WithHttpEndpoint(port: 5001, name: "api-http")
    .WithReference(keycloak)
    .WithReference(sitrepDb)
    .WaitFor(keycloak)
    .WaitFor(sitrepDb)
    .WithHttpHealthCheck("/health");

builder.AddViteApp("frontend", "../frontend")
    .WithEndpoint("http", endpoint => endpoint.Port = 5173)
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(keycloak)
    .WaitFor(apiService);

builder.Build().Run();
