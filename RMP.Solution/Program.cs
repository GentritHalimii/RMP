using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RMP.Host.Exceptions;
using RMP.Host.Extensions;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddEndpointsApiExplorer();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }); 
});

builder.Services.AddSwaggerGen();
builder.Services.
    AddSQLDatabaseConfiguration(builder.Configuration)
    .AddMediatRConfiguration(assembly)
    .AddValidatorsFromAssembly(assembly)
    .AddCarter()
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddHealthChecksConfiguration();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new IgnoreAntiforgeryTokenAttribute());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseHealthChecks();
app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseStaticFiles();


app.Run();