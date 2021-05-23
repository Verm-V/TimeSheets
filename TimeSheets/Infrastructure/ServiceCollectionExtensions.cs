using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeSheets.Data;

namespace TimeSheets.Infrastructure
{
	internal static class ServiceCollectionExtensions
	{
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
	}
}