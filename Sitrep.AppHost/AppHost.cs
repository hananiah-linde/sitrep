var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak")
    .WithDataVolume()
    .WithRealmImport("./KeycloakConfiguration");

var apiService = builder.AddProject<Projects.Sitrep_ApiService>("api")
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithHttpHealthCheck("/health");

builder.AddViteApp("frontend", "../frontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(keycloak)
    .WaitFor(apiService);

builder.Build().Run();