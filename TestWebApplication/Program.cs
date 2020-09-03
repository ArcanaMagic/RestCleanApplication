using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TestWebApplication
{
    public class Program
    {
        public static AssemblyName ServiceName = Assembly.GetExecutingAssembly().GetName();
        public static string ServicePath = "";
        public static async Task Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                await host.RunAsync();
                Log.Information("Starting web host {@serviceName}", ServiceName.Name);
                
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The {@serviceName} service startup failed. {@message}", ServiceName.Name, ex.Message);
            }
            finally
            {
                Log.Information("The {@serviceName} service was stopped", ServiceName.Name);
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        ///  онфигурацию собираем статически из файлов appsettings, appsettings.{Environment} и переменных среды
        /// “ак изменени€ в run time не будут вли€ть на приложение, что сильно упрощает отладку и устран€ет магию
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configurationBuilder) =>
                {
                    var environment = context.HostingEnvironment;
                    ServicePath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && (Debugger.IsAttached)
                        ? environment.ContentRootPath
                        : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    configurationBuilder.SetBasePath(ServicePath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    configurationBuilder.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    configurationBuilder.AddEnvironmentVariables();

                    context.Configuration = configurationBuilder.Build();

                }).ConfigureServices((context, services) =>
                {
                    services.AddSingleton(context.Configuration);
                })
                .ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    loggingBuilder.ClearProviders();

                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(hostingContext.Configuration)
                        .Destructure.AsScalar<byte[]>()
                        .Enrich.WithProperty("Application", ServiceName.Name)
                        .Enrich.WithProperty("Version", ServiceName.Version)
                        .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment.EnvironmentName)
                        .CreateLogger();

                    loggingBuilder.AddSerilog(Log.Logger, dispose: true);

                    Serilog.Debugging.SelfLog.Enable(Log.Error);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureKestrel(options =>
                        {
                            options.Limits.MinRequestBodyDataRate = null;
                        })
                        .UseSerilog()
                        .UseStartup<Startup>();
                });
        }
    }
}
