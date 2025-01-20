using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cw12_git.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Cw12_gitContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cw12_gitContext") ?? throw new InvalidOperationException("Connection string 'Cw12_gitContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<Cw12_gitContext>().Database.EnsureCreated();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//obsługa pliku index.html jako strony domyślnej
app.UseDefaultFiles();
//obsługa plików html z katalogu wwwroot, który trzeba utworzyć w projekcie
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
