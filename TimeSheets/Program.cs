using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets
{
	[ExcludeFromCodeCoverage]
	public class Program
	{
		public static void Main(string[] args)
		{
			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
			try
			{
				logger.Trace("---- [BEGIN]----");
				logger.Debug("---- [BEGIN]----");
				logger.Info("---- [BEGIN]----");
				CreateHostBuilder(args).Build().Run();
			}
			// ����� ���� ���������� � ������ ������ ����������
			catch (Exception exception)
			{
				// NLog: ������������� ����� ����������
				logger.Error(exception, "Stopped program because of exception");
			}
			finally
			{
				// ��������� ������ 
				logger.Info("---- [ END ]----");
				logger.Debug("---- [ END ]----");
				logger.Trace("---- [ END ]----");
				NLog.LogManager.Shutdown();
			}
		}
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				})
				.ConfigureLogging(logging =>
				{
					logging.AddDebug();
					logging.ClearProviders(); // �������� ����������� �����������
					logging.SetMinimumLevel(LogLevel.Trace); // ������������� ����������� ������� �����������
				})
				.UseNLog(); // ��������� ���������� nlog

	}
}
