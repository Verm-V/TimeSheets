using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TimeSheets
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Swagger
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
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			// Включение middleware в пайплайн для обработки Swagger запросов.
			app.UseSwagger();
			// включение middleware для генерации swagger-ui
			// указываем Swagger JSON эндпоинт (куда обращаться за сгенерированной спецификацией
			// по которой будет построен UI).
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервиса учета рабочего времени");
				c.RoutePrefix = string.Empty;
			});
		}
	}
}
