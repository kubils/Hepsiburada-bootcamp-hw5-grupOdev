using API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.IntegrationTest.AppIntegrationTest
{
  public class CustomWebApiFactory : WebApplicationFactory<Startup>
  {
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      // AppSettings dosyasının yerini programatik olarak almaya çalıştım ama yemedi
      // Bunu halletmek lazım şu an absolute path kullandım mecbur, siz o yolu kendi
      // klasör yapınıza göre değiştirin.

      //var projectDir = Directory.GetCurrentDirectory();
      //var configPath = Path.Combine(projectDir, "appsettings.json");

      string absoluteAppSettingsTestJsonPath = "C:\\Users\\Furkan\\Desktop\\Projeler\\Patika_HB_Backend_Bootcamp_HWs\\HW4\\ECommerce_Refactor\\hw4-gitpub-ecommerce\\TestProject\\appsettings.test.json";

      builder
        .ConfigureAppConfiguration((context, config) => {
          config
            .AddJsonFile(absoluteAppSettingsTestJsonPath)
            .AddEnvironmentVariables();
        });
    }
  }
}
