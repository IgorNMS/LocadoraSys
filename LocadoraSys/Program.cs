using LocadoraSys.Data;
using LocadoraSys.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
builder.Services.AddDbContext<LocadoraSysContext>(
    dbContextOptions => dbContextOptions
    .UseMySql(builder.Configuration.GetConnectionString("MovieConnection"), serverVersion));

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FilmeService>();
builder.Services.AddScoped<LocacaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
