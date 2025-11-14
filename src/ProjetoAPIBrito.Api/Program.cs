

using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoAPIBrito.Api.Infrastructure.Data;
using ProjetoAPIBrito.Api.Infrastructure.Repository;
using ProjetoAPIBrito.Api.Application.Services;


var builder = WebApplication.CreateBuilder(args);

ConfigurarServices(builder);
ConfigurarInjecaoDeDependencia(builder);

var app = builder.Build();

ConfigurarAplicacao(app);

app.Run();

static void ConfigurarInjecaoDeDependencia(WebApplicationBuilder builder)
{
    string connectionString = builder.Configuration.GetConnectionString("PADRAO");

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString),
        ServiceLifetime.Transient);

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddScoped<ProdutoRepository>();
    builder.Services.AddScoped<ProdutoService>();
    builder.Services.AddHttpContextAccessor();

    builder.Services
        .AddSingleton(builder.Configuration)
        .AddSingleton(builder.Environment)
        .AddScoped<AppDbContext>();
  
    

       
}

static void ConfigurarServices(WebApplicationBuilder builder)
{
    builder.Services
        .AddCors()
        .AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            // .AddNewtonsoftJson();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "ProjetoAPIBrito.Api",
            Version = "v1",
            Description = "Documentação da API do ProjetoAPIBrito."
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header usando o esquema Bearer (Ex: 'Bearer 12345abcdef')",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });     
}

static void ConfigurarAplicacao(WebApplication app)
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    if (app.Environment.IsDevelopment())
        app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPIBrito.Api v1");
    });

    app.UseRouting();

    app.UseCors(policy => policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // app.UseAuthentication();
    // app.UseAuthorization();

    app.MapControllers();
}
