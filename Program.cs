using MicroserviceProject.Data;
using MicroserviceProject.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register ITodoRepository and TodoRepository
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

/*var serviceProvider = app.Services;
foreach (var service in serviceProvider.GetServices<ITodoRepository>())
{
    Console.WriteLine($"Service: {service.GetType().Name}");
}*/

app.Run();
