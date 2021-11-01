using Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Configurations
{
  public static class CommandQueryInjectionSetup
  {
    public static void AddCommandQueryInjectionSetup(this IServiceCollection services)
    {
      if(services == null)
        throw new ArgumentNullException(nameof(services));

      CommandQueryInjector.AddCommandQueryInjection(services);

    }
  }
}
