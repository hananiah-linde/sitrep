var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Sitrep_ApiService>("api")
    .WithHttpHealthCheck("/health");


builder.AddViteApp("frontend", "../frontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);


builder.Build().Run();