using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Proveedores.Dominio.Puerto.Repositorios;
using Proveedores.Dominio.Puertos.Integraciones;
using Proveedores.Dominio.Servicios.Proveedores;
using Proveedores.Infraestructura.Adaptadores.Integraciones;
using Proveedores.Infraestructura.Adaptadores.RepositorioGenerico;
using Proveedores.Infraestructura.Adaptadores.Repositorios;
using Proveedores.Infraestructura.Repositorios;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V.1.0.1",
        Title = "Servicio Proveedores",
        Description = "Administración de proveedores"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            Array.Empty<string>()
            }
        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Proveedores.Aplicacion")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Capa Infraestructura
builder.Services.AddDbContext<ProveedoresDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ProveedoresDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IDocumentoRepositorio, DocumentosRepositorio>();
builder.Services.AddTransient<IProveedorRepositorio, ProveedorRepositorio>();
builder.Services.AddTransient<ICiudadRepositorio, CiudadRepositorio>();
builder.Services.AddHttpClient<IServicioAuditoriaApi, ServicioAuditoriaApi>();
//Capa Dominio - Servicios
builder.Services.AddTransient<Registrar>();
builder.Services.AddTransient<Obtener>();
builder.Services.AddTransient<Listar>();
builder.Services.AddTransient<Proveedores.Dominio.Servicios.Ciudades.Listar>();
builder.Services.AddTransient<Proveedores.Dominio.Servicios.Documentos.Listar>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
