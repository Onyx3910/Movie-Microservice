var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.eShop_Tickets_ApiService>("apiservice");

builder.AddProject<Projects.eShop_Tickets_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.AddProject<Projects.Audit_Api>("audit.api");

builder.Build().Run();
