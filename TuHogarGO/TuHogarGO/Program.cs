using MediatR;
using System.Reflection;
using TuHogarGO.BL.Contracts;
using TuHogarGO.BL.Implementation;
using TuHogarGO.DB;
using TuHogarGO.Entities;
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

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

ConfigureServices(builder.Services);

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

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<TuHogarDBContext>();
    
    services.AddScoped<IUsuariosRepository, UsuariosRepository>();
    services.AddScoped<IRepository<Rol>, RolesRepository>();
    services.AddScoped<IRepository<Plan>, PlanesRepository>();

    services.AddScoped<IUsuarioService, UsuarioService>();
    services.AddScoped<IRolesBL, RolesBL>();
    services.AddScoped<IPlanesService, PlanesService>();
}