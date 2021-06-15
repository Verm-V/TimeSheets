using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Infrastructure;

namespace TimeSheets
{
	[ExcludeFromCodeCoverage]
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
			// Контроллеры
			services.AddControllers();

			// Swagger
			services.ConfigureSwagger(Configuration);

			// Обработчики данных (менеджеры и репозитории)
			services.ConfigureDataHandlers(Configuration);

			// Контекст базы данных
			services.ConfigureDbContext(Configuration);

			// Аутентификация
			services.ConfigureAuthentication(Configuration);

			// Валидация
			services.ConfigureValidtion();
			services.AddControllers()
				.AddFluentValidation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервиса учета рабочего времени - сокращенный");
				c.SwaggerEndpoint("/swagger/v2/swagger.json", "API сервиса учета рабочего времени - полный");
				c.RoutePrefix = string.Empty;
			});

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
