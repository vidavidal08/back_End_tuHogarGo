using MediatR;
using System.Reflection;
using TuHogarGO.BL.Contracts;
using TuHogarGO.BL.Implementation;
using TuHogarGO.DB;
using TuHogarGO.Infraestructura.Auth;
using TuHogarGO.Infraestructura.Config;
using TuHogarGO.Repositories;

var builder = WebApplication.CreateBuilder(args);

var currentAssembly = Assembly.GetExecutingAssembly();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TuHogarDBContext>();

builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Automapper Scans for all profiles in an assembly
// See automapper profiles in ~/Automapper/Profiles/
builder.Services.AddAutoMapper(x =>
{
    x.AddMaps(currentAssembly);
});
builder.Services.AddMediatR(currentAssembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
