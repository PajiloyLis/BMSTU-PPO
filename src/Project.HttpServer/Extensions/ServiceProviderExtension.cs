using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Npgsql;

namespace Project.HttpServer.Extensions;

public static class ServiceProviderExtension
{
    public static IServiceCollection AddProjectControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters
                .Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false));
        });

        return serviceCollection;
    }

    public static IServiceCollection AddProjectCors(this IServiceCollection serviceCollection, string policyName)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy(policyName,
                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });
        return serviceCollection;
    }

    public static IServiceCollection AddProjectSwaggerGen(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "PPO Project.HttpServer", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,

                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return serviceCollection;
    }

    public static IServiceCollection AddProjectServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        // TODO
        return serviceCollection;
    }

    public static IServiceCollection AddProjectDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var dataSource = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("DefaultConnection"))
            .EnableDynamicJson().Build();

        serviceCollection.AddSingleton(dataSource);

        // TODO serviceCollection.AddDbContext<>()

        return serviceCollection;
    }

    public static IServiceCollection AddProjectAuthorization(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        // TODO var jwtConfiguration = new JwtConfiguration();
        return serviceCollection;
    }

    public static IServiceCollection AddProjectDbRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddProjectDbRepositories();
        return serviceCollection;
    }
}