﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TimeSheets.Data;
using TimeSheets.Data.Implementation;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Implementation;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.ComponentModel;

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
					Title = "API for Time Sheets service (short)",
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
				c.SwaggerDoc("v2", new OpenApiInfo
				{
					Version = "v2",
					Title = "API for Time Sheets service (Full)",
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
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme()
						{
							Reference = new OpenApiReference()
							{
								Type = ReferenceType.SecurityScheme, 
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
				});
				// Указываем файл из которого брать комментарии для Swagger UI
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath, true);
				c.OrderActionsBy(apiDesc => apiDesc.RelativePath.Replace("/", "|"));
			});
		}

		/// <summary>Обработчики данных (репозитории и менеджеры)</summary>
		public static void ConfigureDataHandlers(this IServiceCollection services,
			IConfiguration configuration)
		{
			// Репозитории
			services.AddScoped<IClientRepo, ClientRepo>();
			services.AddScoped<IContractRepo, ContractRepo>();
			services.AddScoped<IEmployeeRepo, EmployeeRepo>();
			services.AddScoped<IInvoiceRepo, InvoiceRepo>();
			services.AddScoped<IServiceRepo, ServiceRepo>();
			services.AddScoped<ISheetRepo, SheetRepo>();
			services.AddScoped<IUserRepo, UserRepo>();

			// Менеджеры работы с запросами
			services.AddScoped<IClientManager, ClientManager>();
			services.AddScoped<IContractManager, ContractManager>();
			services.AddScoped<IEmployeeManager, EmployeeManager>();
			services.AddScoped<IInvoiceManager, InvoiceManager>();
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddScoped<ISheetManager, SheetManager>();
			services.AddScoped<IUserManager, UserManager>();
		}

		/// <summary>Аутнетификация пользователей</summary>
		public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));
			services.Configure<JwtRefreshOptions>(configuration.GetSection("Authentication:JwtRefreshOptions"));

			var jwtSettings = new JwtOptions();
			configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

			services.AddTransient<ILoginManager, LoginManager>();

			services
				.AddAuthentication(
					x =>
					{
						x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
						x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
				});
		}

	}
}