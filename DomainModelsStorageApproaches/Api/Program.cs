using DirectStorageApproach.Infrastructure.Extensions;
using MappingToDbEntitiesApproach.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDirectStorageApproachInfrastructure(configuration);
builder.Services.AddMappingToDbEntitiesApproachInfrastructure(configuration);

builder
    .Build()
    .Run();