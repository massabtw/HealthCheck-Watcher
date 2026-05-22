using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitoramento.Core.Interfaces;
using Monitoramento.Infrastructure.APIs;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();
builder.Services.AddTransient<IHealthChecker, TotemHealthChecker>();
builder.Services.AddTransient<IHealthChecker, PdvHealthChecker>();
builder.Build().Run();
