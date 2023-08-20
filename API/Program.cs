using API.Extensions;
using API.Middleware;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
var context = service.GetRequiredService<DataContext>();
var logger = service.GetRequiredService<ILogger<Program>>();
try
{
   // await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
