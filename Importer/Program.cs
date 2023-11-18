using Importer.Brokers.Spreadsheets;
using Importer.Brokers.Storages;
using Importer.Services.Foundations.Clients;
using Importer.Services.Foundations.Spreadsheets;
using Importer.Services.Orchestrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ISpreadsheetService, SpreadsheetService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IOrchestrationService, OrchestrationService>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
