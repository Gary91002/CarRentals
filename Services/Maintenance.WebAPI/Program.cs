using Maintenance.WebAPI.Services;
using Microsoft.OpenApi.Models; // Add this using directive
using Swashbuckle.AspNetCore.SwaggerUI; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IRepairHistoryService, FakeRepairHistoryService>();

builder.Services.AddScoped<IRepairHistoryService, FakeRepairHistoryService>();

builder.Services.AddSwaggerGen();	

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); // This requires Swashbuckle.AspNetCore and the correct using directives

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
