using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TimeSheets.Data;

namespace TimeSheets.Infrastructure
{
	/// <summary>Расширения для коллекций сервисов</summary>
	internal static class ServiceCollectionExtensions
	{
		/// <summary>Конфигурация контекста базы данных</summary>
		public static void ConfigureDbContext(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<TimeSheetDbContext>(options =>
			{
				options.UseNpgsql(
					configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly("TimeSheets"));
			});
		}

		/// <summary>Конфигурация swagger'а</summary>
		public static void ConfigureSwagger(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "API for Time Sheets service",
					Description = "Additional information",
					//TermsOfService = new Uri("https://example.com/"),
					Contact = new OpenApiContact
					{
						Name = "Vasiliy Mykitenko",
						Email = string.Empty,
						Url = new Uri("http://verm-v.ru"),
					},
					License = new OpenApiLicense
					{
						Name = "License - СС0",
						Url = new Uri("https://creativecommons.org/choose/zero/"),
					}
				});
				// Указываем файл из которого брать комментарии для Swagger UI
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
				c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.DisplayName}");
			});
		}
	}
}